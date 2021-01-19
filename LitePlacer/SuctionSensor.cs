using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;

namespace LitePlacer
{
    /// <summary>
    /// Controls the suction sensor and determines whether we've picked up a component or not.
    /// </summary>
    public class SuctionSensor
    {
        public enum ESuctionSensorState
        {
            PickupOk,
            RetryPickup,
            RetryAndIncrementPickup,
            RequireOkStopUserConfirmation,
            InitialisedOk,
            NozzleNotBlocked,
            NozzleBlocked,
        }


        //errors
        public const string PickupNotCalled = "SuctionSensor.cs: AttemptedPartPickup was not called prior to PickupComplete!";
        public const string SuctionSensorNoPort = "SuctionSensor.cs: Suction sensor is enabled but can't find serial port or it failed to open.";
        public const string SuctionSensorNoSettings = "SuctionSensor.cs: Suction sensor is enabled but has no/missing pressure settings";
        public const string SuctionSensorNozzleBlocked = "SuctionSensor.cs: Check nozzle, it might be blocked.";
        public const string SuctionSensorRetryExceeded = "SuctionSensor.cs: Exceeded retry pickup count ({0})";
        public const string SuctionSensorUnknownError = "SuctionSensor.cs: Unknown Error!! Err:  {0}";
        public const string SuctionSensorCantBlockCheckComponentPicked = "SuctionSensor.cs: Can't perform blocked nozzle check as component has been picked up";
        public const string SuctionSensorCommsDropout = "SuctionSensor.cs: Communications lost to sunction sensor!";

        //notifications
        public const string SuctionSensorNotEnabled = "SuctionSensor.cs: Suction sensor not enabled.";
        public const string SuctionSensorInitialisedOk = "SuctionSensor.cs: Suction sensor initialised OK";
        public const string SuctionSensorShutdown = "SuctionSensor.cs: Suction sensor shutdown";

        public string MessageForUser { get; private set; }      
        public string ConnectionState { get; private set; } = "Disconnected";
        public bool Connected => ConnectionState == "Connected!";

        SuctionSensorPressureSettings _PressureSettings = null;
        //load settings from main if they don't exist.
        public SuctionSensorPressureSettings PressureSettings => _PressureSettings ??
            (_PressureSettings = SuctionSensorPressureSettings.FromJson(_Main.Setting.SuctionSensorPressureSettings));
        public event Action<double> OnPressureChange;
        public event Action OnCommsDropout;
        public event Action<string> OnConnectionChange;


        //Current values
        int _SuctionPressure = 0;
        public int SuctionPressure => GetSetSuctionPressure();
        /// <summary>
        /// The current picked up component pressure.
        /// </summary>
        public int PressureAtPickup { get; private set; }
        /// <summary>
        /// Minimum pressure to indicate that our component has been picked up.
        /// </summary>
        public int ComponentPickedupMinPressure { get; private set; }
        //Current values

        bool CommsTimeout = false;

        byte[] _RxBuffer = new byte[8192];
        int _RxBufferPos = 0;

        object SuctionPressureLock = new object();
        DateTime? AttemptedPickupTime = null;
        DateTime? _LastPressureDate = null;
        Timer _TmrPeriodic;
        int TimerTickRate = 200;
        int _RetryCount = 0;

        static SuctionSensor Instance = null;
        SerialPort port = null;
        FormMain _Main;

        SuctionSensor(FormMain main)
        {
            Instance = this;
            _Main = main;
        }

        public static SuctionSensor GetInstance(FormMain main)
        {
            return Instance ?? (Instance = new SuctionSensor(main));
        }

        int GetSetSuctionPressure(double? pressure = null)
        {
            lock (SuctionPressureLock)
            {
                //check if we're updating or reading.
                if (pressure == null) return _SuctionPressure;
                _SuctionPressure = (int)pressure.Value;
                _LastPressureDate = DateTime.UtcNow;
                CommsTimeout = false;
            }
            OnPressureChange?.Invoke(pressure.Value);
            return (int)pressure.Value;
        }

        /// <summary>
        /// Returns current nozzle pressure for nozzle fitted at present.
        /// </summary>
        /// <returns></returns>
        int? GetCurrentNozzlePressure()
        {
            //Get our pressure settings.
            var ps = PressureSettings;
            if (ps.AmbientPressure == 0 ||
                ps.FullSuctionPressure == 0 ||
                ps.PickedUpComponentFactor == 0)
            {
                MessageForUser = SuctionSensorNoSettings;
                _Main.DisplayText(MessageForUser, System.Drawing.KnownColor.Red);
                return null;
            }

            var nozzlenumber = _Main.Setting.Nozzles_current;
            if (PressureSettings.NozzlePressureSettings == null ||
                PressureSettings.NozzlePressureSettings.Count < nozzlenumber ||
                PressureSettings.NozzlePressureSettings[nozzlenumber] == null)
            {
                return null;
            }
            return PressureSettings.NozzlePressureSettings[nozzlenumber];
        }
        /// <summary>
        /// Calculate pressure that would indicate nozzle is blocked, if sensor pressure is below this, then it could be blocked.
        /// E.g ambient (AMB) = 1023.0, FullSuction (FS) = 470, NozzlePressure (NP) = 840.
        /// FS + ((NP - FS) * NozzleBlockedFactor) = setpoint
        /// 470 + ((840 - 470) * 0.8)  = 766
        /// So, if the pressure is ABOVE 766, then the nozzle is NOT blocked.
        /// </summary>
        int? GetBlockedNozzlePressure(int nozzlePressure)
        {
            //Get our pressure settings.
            var ps = PressureSettings;
            if (ps.AmbientPressure == 0 ||
                ps.FullSuctionPressure == 0 ||
                ps.NozzleBlockedFactor == 0)
            {
                MessageForUser = SuctionSensorNoSettings;
                _Main.DisplayText(MessageForUser, System.Drawing.KnownColor.Red);
                return null;
            }

            var sp = (int)(PressureSettings.FullSuctionPressure +
                ((nozzlePressure - PressureSettings.FullSuctionPressure) * PressureSettings.NozzleBlockedFactor));
            return sp;
        }
        /// <summary>
        /// Get the pressure for the given nozzle pressure that indicates our component has been picked up.
        /// E.g ambient (AMB) = 1023.0, FullSuction (FS) = 470, NozzlePressure (NP) = 840.
        /// FS + ((NP - FS) * PickedUpComponentFactor) = setpoint
        /// 470 + ((840 - 470) * 0.4)  = 618
        /// So, if the pressure gets BELOW 618, then we will register that the component has been picked up.
        /// </summary>
        int? GetPickedupComponentPressure(int nozzlePressure)
        {
            //Get our pressure settings.
            var ps = PressureSettings;
            if (ps.AmbientPressure == 0 ||
                ps.FullSuctionPressure == 0 ||
                ps.PickedUpComponentFactor == 0)
            {
                MessageForUser = SuctionSensorNoSettings;
                _Main.DisplayText(MessageForUser, System.Drawing.KnownColor.Red);
                return null;
            }


            var sp = (int)(PressureSettings.FullSuctionPressure +
                ((nozzlePressure - PressureSettings.FullSuctionPressure) * PressureSettings.PickedUpComponentFactor));
            return sp;
        }

        bool CheckTimeOutOk()
        {
            lock (SuctionPressureLock)
            {
                //port closed, so technically, it's ok.... 
                if (port == null || !PressureSettings.SuctionSensorEnable) return true;
                //port has been opened, if we haven't seen a pressure reading yet, then create an epoch.
                if (_LastPressureDate == null) _LastPressureDate = DateTime.UtcNow;
                else if (_LastPressureDate < DateTime.UtcNow.AddMilliseconds(-PressureSettings.CommsTimeoutDelay)) return false;
            }
            return true;
        }

        public ESuctionSensorState Init()
        {
            //Get our settings.
            if (!PressureSettings.SuctionSensorEnable)
            {
                _Main.DisplayText(SuctionSensorNotEnabled);
                Shutdown();
                return ESuctionSensorState.InitialisedOk;
            }
            //Get our serial port.

       

            if (string.IsNullOrEmpty(PressureSettings.SuctionSensorPort))
            {
                MessageForUser = SuctionSensorNoPort;
                _Main.DisplayText(MessageForUser, System.Drawing.KnownColor.Red);
                return ESuctionSensorState.RequireOkStopUserConfirmation;
            }
            try
            {
                //init the port.
                port = new SerialPort(PressureSettings.SuctionSensorPort);
                port.BaudRate = 38400;
                port.StopBits = StopBits.One;
                port.Parity = Parity.None;
                port.DataReceived += Port_DataReceived;
                port.Open();
                CommsTimeout = false;
                ConnectionState = "Connected!";
                OnConnectionChange?.Invoke(ConnectionState);
            }
            catch (Exception ex)
            {
                Shutdown();
                MessageForUser = SuctionSensorNoPort + $"Err: {ex.Message}";
                _Main.DisplayText(MessageForUser, System.Drawing.KnownColor.Red);
                return ESuctionSensorState.RequireOkStopUserConfirmation;
            }
            //We might be trying to reconnect after a disconnection.
            if (_TmrPeriodic == null) _TmrPeriodic = new Timer(TmrTick, this, TimerTickRate, Timeout.Infinite);
            return ESuctionSensorState.InitialisedOk;
        }

        public void Shutdown()
        {
            try
            {
                if (port != null)
                {
                    var prt = port;
                    port = null;
                    if (prt.IsOpen) prt.Close();
                    prt.Dispose();
                }
            }
            catch (Exception) { }
            try
            {
                if (!CommsTimeout && _TmrPeriodic != null)
                {
                    var tmr = _TmrPeriodic;
                    _TmrPeriodic = null;
                    tmr.Dispose();
                }
            }
            catch (Exception) { }

            GetSetSuctionPressure(0);
            ComponentPickedupMinPressure = 0;
            PressureAtPickup = 0;
            ConnectionState = "Disconnected";
            OnConnectionChange?.Invoke(ConnectionState);
        }

        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var sp = (SerialPort)sender;
            if (sp.BytesToRead < 5) return;
            //make sure we don't overflow.
            if (_RxBufferPos + sp.BytesToRead > _RxBuffer.Length-10) _RxBufferPos = 0;
            _RxBufferPos += sp.Read(_RxBuffer, _RxBufferPos, sp.BytesToRead);
            //Find our \r\n
            var str = UTF8Encoding.UTF8.GetString(_RxBuffer, 0, _RxBufferPos);
            var split = str.Split('\r');
            if (split.Length < 2) return;
            double pressure;
            var splitpos = 1;
            if (split[split.Length - splitpos].StartsWith("\n") &&
                double.TryParse(split[split.Length - splitpos].Trim(), out pressure) &&
                pressure > SuctionSensorPressureSettings.MinPressure &&
                pressure < SuctionSensorPressureSettings.MaxPressure)
            {
                GetSetSuctionPressure(pressure);
                _RxBufferPos = 0;
            }
            splitpos = 2;
            if (split[split.Length - splitpos].StartsWith("\n") &&
               double.TryParse(split[split.Length - splitpos].Trim(), out pressure) &&
               pressure > SuctionSensorPressureSettings.MinPressure &&
               pressure < SuctionSensorPressureSettings.MaxPressure)
            {
                GetSetSuctionPressure(pressure);
                _RxBufferPos = 0;
            }
            //Try later...
        }

        static void TmrTick(object obj)
        {
            var ss = (SuctionSensor)obj;
            if (ss.CommsTimeout || !ss.CheckTimeOutOk())
            {
                //Show a message if we dropout.
                if (!ss.CommsTimeout)
                {
                    ss.ConnectionState = "Timed out!";
                    ss.OnConnectionChange?.Invoke(ss.ConnectionState);
                    ss._Main.ShowMessageBox(SuctionSensorCommsDropout, "Error!", System.Windows.Forms.MessageBoxButtons.OK);
                    ss.OnCommsDropout?.Invoke();
                }

                ss.CommsTimeout = true;
                //Wait for our timeout value and try to reconnect.
                Thread.Sleep(ss.PressureSettings.CommsReconnectDelay);
                //see if we're still disconnected, if so, try reconnect.
                if (!ss.CheckTimeOutOk()) ss.Init();
            }
            //restart the timer.
            ss._TmrPeriodic.Change(ss.TimerTickRate, Timeout.Infinite);
        }

        /// <summary>
        /// If the machine attempts to pickup a part, this method will be called as soon as
        /// the nozzle is against the component and the vacuum has been initialised.
        /// </summary>
        public void AttemptedPartPickup()
        {
            AttemptedPickupTime = DateTime.UtcNow;
        }

        /// <summary>
        /// When we get to the top of the Z axis, we call this.
        /// We determine whether we have picked up ok or need to retry.
        /// </summary>
        /// <returns>Whether to retry pickup</returns>
        public ESuctionSensorState PickupComplete()
        {
            try
            {
                if (AttemptedPickupTime == null)
                {
                    MessageForUser = PickupNotCalled;
                    return ESuctionSensorState.RequireOkStopUserConfirmation;
                }
                //Wait for suction delay to evacuate air from tube.
                //Generally the suction delay time in basic settings is enough.
                while (DateTime.UtcNow < AttemptedPickupTime.Value.AddMilliseconds(PressureSettings.CurrentPickupPressureDelay)) Thread.Sleep(50);
                AttemptedPickupTime = null;
                PressureAtPickup = GetSetSuctionPressure();
                //Get our nozzle suction value.
                var nozz = _Main.Setting.Nozzles_current;
                //No nozzle??
                if (nozz == 0) return ESuctionSensorState.PickupOk;

                var NozzlePressure = GetCurrentNozzlePressure();
                if (NozzlePressure == null)
                {
                    MessageForUser = SuctionSensorNoSettings;
                    _Main.DisplayText(MessageForUser, System.Drawing.KnownColor.Red);
                    return ESuctionSensorState.RequireOkStopUserConfirmation;
                }
                /// FS + ((NP - FS) * HasComponentFactor) = setpoint
                var pres = GetPickedupComponentPressure(NozzlePressure.Value);
                if (pres == null)
                {
                    MessageForUser = SuctionSensorNoSettings;
                    _Main.DisplayText(MessageForUser, System.Drawing.KnownColor.Red);
                    return ESuctionSensorState.RequireOkStopUserConfirmation;
                }

                ComponentPickedupMinPressure = pres.Value;
                if (PressureAtPickup < ComponentPickedupMinPressure)
                {
                    _RetryCount = 0;
                    return ESuctionSensorState.PickupOk;
                }
                if (_RetryCount > PressureSettings.PickupRetryCount)
                {
                    MessageForUser = string.Format(SuctionSensorRetryExceeded, _RetryCount);
                    _Main.DisplayText(MessageForUser, System.Drawing.KnownColor.Red);
                    PressureAtPickup = 0;
                    ComponentPickedupMinPressure = 0;
                    return ESuctionSensorState.RequireOkStopUserConfirmation;
                }
                _RetryCount++;
                if (PressureSettings.SuctionSensorIncrementEachRetry) return ESuctionSensorState.RetryAndIncrementPickup;
                else return ESuctionSensorState.RetryPickup;
            }
            catch (Exception ex)
            {
                MessageForUser = string.Format(SuctionSensorUnknownError, ex.Message);
            }
            _Main.DisplayText(MessageForUser, System.Drawing.KnownColor.Red);
            PressureAtPickup = 0;
            ComponentPickedupMinPressure = 0;
            return ESuctionSensorState.RequireOkStopUserConfirmation;
        }

        /// <summary>
        /// We call this after we've placed our component, during this time we'll monitor to make sure we don't drop it on the way.
        /// </summary>
        public void PlaceComplete()
        {
            //Great!
            //Clear our pickup pressure so we stop checking.
            PressureAtPickup = 0;
            ComponentPickedupMinPressure = 0;
        }

        /// <summary>
        /// Called after we've dropped the component and we're back at the top of our Z travel.
        /// We monitor the pressure and make sure we don't have a blocked nozzle / component stuck to it.
        /// If we smash a small nozzle into solder paste or something, we can gunk it up.
        /// </summary>
        public ESuctionSensorState BlockedNozzleCheck()
        {
            //don't perform a check if the user has disabled it.
            if (PressureSettings.NozzleBlockedFactor == 0)
                return ESuctionSensorState.NozzleNotBlocked;

            //Already have a component picked up.
            if (PressureAtPickup != 0)
            {
                //Bad pressure.
                MessageForUser = SuctionSensorCantBlockCheckComponentPicked;
                _Main.DisplayText(MessageForUser, System.Drawing.KnownColor.Red);
                return ESuctionSensorState.RequireOkStopUserConfirmation;
            }

            //Make sure our pressure is not too far from our nozzle value when no component has been picked up.
            var Pressure = GetSetSuctionPressure();
            var NozzlePressure = GetCurrentNozzlePressure();
            if (NozzlePressure == null)
            {
                //Bad pressure.
                MessageForUser = SuctionSensorNoSettings;
                _Main.DisplayText(MessageForUser, System.Drawing.KnownColor.Red);
                return ESuctionSensorState.RequireOkStopUserConfirmation;
            }
            var BlockedPressure = GetBlockedNozzlePressure(NozzlePressure.Value);
            if (BlockedPressure == null)
            {
                //Bad pressure.
                MessageForUser = SuctionSensorNoSettings;
                _Main.DisplayText(MessageForUser, System.Drawing.KnownColor.Red);
                return ESuctionSensorState.RequireOkStopUserConfirmation;
            }
            if (Pressure < BlockedPressure) return ESuctionSensorState.NozzleBlocked;
            return ESuctionSensorState.NozzleNotBlocked;
        }
    }

    public class SuctionSensorPressureSettings
    {
        public SuctionSensorPressureSettings()
        {

        }
        public static string ToJson(SuctionSensorPressureSettings settings)
        {
            return JsonConvert.SerializeObject(settings, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Include
            });
        }
        public static SuctionSensorPressureSettings FromJson(string json)
        {
            if (json == null) return new SuctionSensorPressureSettings();
            var sets = JsonConvert.DeserializeObject<SuctionSensorPressureSettings>(json, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Include
            });
            //make sure we've always got settings ready.
            for (int i = sets.NozzlePressureSettings.Count; i < 6; i++)
                sets.NozzlePressureSettings.Add(null);
            return sets;
        }


        public const int MinPressure = 200;
        public const int MaxPressure = 1600;

        public string SuctionSensorPort { get; set; }
        public bool SuctionSensorEnable { get; set; }

        /// <summary>
        /// How many times to try and pick up before we give up.
        /// </summary>
        public int PickupRetryCount { get; set; } = 3;
        /// <summary>
        /// Doesn't apply to direct component coordinate pickup.
        /// </summary>
        public bool SuctionSensorIncrementEachRetry { get; set; } = true;
        /// <summary>
        /// Depending on the current nozzle, this is how long we need to wait before we get an accurate reading.
        /// </summary>
        public int CurrentPickupPressureDelay { get; set; } = 200;
        /// <summary>
        /// How many ms we don't have a reading for before we determine we have lost communications.
        /// </summary>
        public int CommsTimeoutDelay { get; set; } = 2000;
        public int CommsReconnectDelay { get; set; } = 5000;

        /// <summary>
        /// Nozzle 1 is element 0, empty values are specified as null.
        /// Each pressure setting is the suction value each nozzle exhibits when not picking up any components.
        /// </summary>
        public List<int?> NozzlePressureSettings { get; set; } = new List<int?>();
        /// <summary>
        /// Our regular ambient pressure.
        /// </summary>
        public double AmbientPressure { get; set; }
        /// <summary>
        /// When the nozzles are completely blocked for a few seconds, what pressure do we see.
        /// </summary>
        public double FullSuctionPressure { get; set; }
        /// <summary>
        /// what % do we apply to the difference between our suction pressure and ambient
        /// E.g ambient (AMB) = 1023.0, FullSuction (FS) = 470, NozzlePressure (NP) = 840.
        /// FS + ((NP - FS) * PickedUpComponentFactor) = setpoint
        /// 470 + ((840 - 470) * 0.4)  = 618
        /// So, if the pressure gets BELOW 618, then we will register that the component has been picked up.
        /// </summary>
        public double PickedUpComponentFactor { get; set; } = 0.4;
        /// <summary>
        /// What factor do we use to check for a blocked nozzle, similar to picked up factor, but we check pressure is ABOVE, not below.
        /// E.g ambient (AMB) = 1023.0, FullSuction (FS) = 470, NozzlePressure (NP) = 840.
        /// FS + ((NP - FS) * NozzleBlockedFactor) = setpoint
        /// 470 + ((840 - 470) * 0.8)  = 766
        /// So, if the pressure is ABOVE 766, then the nozzle is NOT blocked.
        /// </summary>
        public double NozzleBlockedFactor { get; set; } = 0.8;

    }
}
