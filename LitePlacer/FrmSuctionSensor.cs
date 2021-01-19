using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LitePlacer
{
    public partial class FrmSuctionSensor : Form
    {
        FormMain _Main;
        SuctionSensor _ss;
        bool _ChangesMade;
        public bool ChangesMade
        {
            get
            {
                return _ChangesMade;
            }
            set
            {
                _ChangesMade = value;
                buttonSave.Enabled = _ChangesMade;
            }
        }
        bool EventBlock = false;
        public FrmSuctionSensor(FormMain main)
        {
            _Main = main;
            InitializeComponent();
            _ss = SuctionSensor.GetInstance(_Main);
            _ss.OnCommsDropout += Ss_OnCommsDropout;
            _ss.OnConnectionChange += Ss_OnConnectionChange;
            _ss.OnPressureChange += Ss_OnPressureChange;
            buttonSave.Enabled = false;
        }

        void SaveSettings()
        {
            _Main.Setting.SuctionSensorPressureSettings = SuctionSensorPressureSettings.ToJson(_ss.PressureSettings);         
        }

        void LoadSettings()
        {
            EventBlock = true;
            var PressureSettings = _ss.PressureSettings;
            CbEnableSuctionSensor.Checked = PressureSettings.SuctionSensorEnable;
            buttonConnectSerial.Enabled = CbEnableSuctionSensor.Checked;
            CbIncrementComponent.Checked = PressureSettings.SuctionSensorIncrementEachRetry;
            NudPickupRetries.Value = PressureSettings.PickupRetryCount;

            labelAmbientPressure.Text = PressureSettings?.AmbientPressure.ToString() ?? "0";
            labelFullSuction.Text = PressureSettings?.FullSuctionPressure.ToString() ?? "0";
            if (PressureSettings?.NozzlePressureSettings?.Count > 0)
            {
                var ps = PressureSettings.NozzlePressureSettings;
                labelNozzle1Pressure.Text = (ps[0] ?? 0).ToString();
                labelNozzle2Pressure.Text = ps.Count >= 2 ? (ps[1] ?? 0).ToString() : "0";
                labelNozzle3Pressure.Text = ps.Count >= 3 ? (ps[2] ?? 0).ToString() : "0";
                labelNozzle4Pressure.Text = ps.Count >= 4 ? (ps[3] ?? 0).ToString() : "0";
                labelNozzle5Pressure.Text = ps.Count >= 5 ? (ps[4] ?? 0).ToString() : "0";
                labelNozzle6Pressure.Text = ps.Count >= 6 ? (ps[5] ?? 0).ToString() : "0";
            }
            TbBlockedPressureFactor.Text = PressureSettings.NozzleBlockedFactor.ToString();
            TbPickupPressureFactor.Text = PressureSettings.PickedUpComponentFactor.ToString();
            //set our serial port.
            RefreshPortList(PressureSettings.SuctionSensorPort);
            if (string.IsNullOrEmpty(PressureSettings.SuctionSensorPort) && comboBoxSerialPorts.SelectedIndex >= 0)
                PressureSettings.SuctionSensorPort = comboBoxSerialPorts.Text;
            EventBlock = false;
        }

        private void Ss_OnPressureChange(double obj)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<double>(Ss_OnPressureChange), obj);
                return;
            }
            labelSuctionSensorCurrentPressure.Text = obj.ToString();
        }

        private void Ss_OnConnectionChange(string obj)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<string>(Ss_OnConnectionChange), obj);
                return;
            }
            labelSerialPortStatus.Text = obj;
        }

        private void Ss_OnCommsDropout()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(Ss_OnCommsDropout));
                return;
            }
            labelSerialPortStatus.Text = _ss.ConnectionState;
        }

        private void buttonConnectSerial_Click(object sender, EventArgs e)
        {
            if (!_ss.Connected)
                _ss.Init();
            else _ss.Shutdown();
        }

        private void CbEnableSuctionSensor_CheckedChanged(object sender, EventArgs e)
        {
            if (EventBlock) return;
            ChangesMade = true;
            _ss.PressureSettings.SuctionSensorEnable = CbEnableSuctionSensor.Checked;
            buttonConnectSerial.Enabled = CbEnableSuctionSensor.Checked;
        }

        private void CbIncrementComponent_CheckedChanged(object sender, EventArgs e)
        {
            if (EventBlock) return;
            ChangesMade = true;
            _ss.PressureSettings.SuctionSensorIncrementEachRetry = CbEnableSuctionSensor.Checked;
        }

        private void buttonSetAmbient_Click(object sender, EventArgs e)
        {
            if (EventBlock) return;
            //save the pressure.
            //Make sure valve is released.
            _Main.Cnc.VacuumOff();
            _Main.Cnc.PumpOff();
            _Main.Vacuum_checkBox.Checked = false;
            _Main.Pump_checkBox.Checked = false;
            Thread.Sleep(1000);
            if (!CheckPressureOk(forAmbient: true)) return;
            var pressure = _ss.SuctionPressure;
            labelAmbientPressure.Text = pressure.ToString();
            _ss.PressureSettings.AmbientPressure = pressure;
            ChangesMade = true;
        }

        bool CheckPressureOk(bool forNozzle = false, bool forFullSuction = false, bool forAmbient = false, int manualPressure = 0)
        {
            //Make sure we're connected then save the setting.
            if (!_ss.Connected)
            {
                MessageBox.Show("Please connect to sensor first!");
                return false;
            }
            if (_ss.SuctionPressure < SuctionSensorPressureSettings.MinPressure)
            {
                MessageBox.Show($"Current suction pressure is below minimum (min: {SuctionSensorPressureSettings.MinPressure}), please check and try again.");
                return false;
            }
            if (_ss.SuctionPressure > SuctionSensorPressureSettings.MaxPressure)
            {
                MessageBox.Show($"Current suction pressure is above maximum (max: {SuctionSensorPressureSettings.MaxPressure}), please check and try again.");
                return false;
            }
            return true;
        }

        private void buttonSetFullSuction_Click(object sender, EventArgs e)
        {
            if (EventBlock) return;
            //save the pressure.
            //Make sure pump and vacuum are on.
            _Main.Cnc.PumpOn();
            _Main.Cnc.VacuumOn();
            Thread.Sleep(4000);
            if (!CheckPressureOk(forFullSuction: true))
            {
                _Main.Cnc.VacuumOff();
                _Main.Cnc.PumpOff();
                _Main.Vacuum_checkBox.Checked = false;
                _Main.Pump_checkBox.Checked = false;
                return;
            }
            var pressure = _ss.SuctionPressure;
            labelFullSuction.Text = pressure.ToString();
            _ss.PressureSettings.FullSuctionPressure = pressure;
            ChangesMade = true;
            _Main.Cnc.VacuumOff();
            _Main.Cnc.PumpOff();
            _Main.Vacuum_checkBox.Checked = false;
            _Main.Pump_checkBox.Checked = false;
        }

        void SetNozzlePressure(object sender)
        {
            if (EventBlock) return;
            //save the pressure.
            //Make sure pump and vacuum are on.
            _Main.Cnc.VacuumOn();
            _Main.Cnc.PumpOn();

            Thread.Sleep(2000);
            if (!CheckPressureOk(forNozzle: true))
            {
                _Main.Cnc.VacuumOff();
                _Main.Cnc.PumpOff();
                _Main.Vacuum_checkBox.Checked = false;
                _Main.Pump_checkBox.Checked = false;
                return;
            }
            var pressure = _ss.SuctionPressure;
            var button = (Button)sender;
            var index = 0;
            if (button.Name == buttonSetNozzle1.Name)
            {
                index = 0;
                _ss.PressureSettings.NozzlePressureSettings.RemoveAt(index);
                _ss.PressureSettings.NozzlePressureSettings.Insert(pressure, index);
                labelNozzle1Pressure.Text = pressure.ToString();
            }
            else if (button.Name == buttonSetNozzle2.Name)
            {
                index = 1;
                _ss.PressureSettings.NozzlePressureSettings.RemoveAt(index);
                _ss.PressureSettings.NozzlePressureSettings.Insert(pressure, index);
                labelNozzle2Pressure.Text = pressure.ToString();
            }
            else if (button.Name == buttonSetNozzle3.Name)
            {
                index = 2;
                _ss.PressureSettings.NozzlePressureSettings.RemoveAt(index);
                _ss.PressureSettings.NozzlePressureSettings.Insert(pressure, index);
                labelNozzle3Pressure.Text = pressure.ToString();
            }
            else if (button.Name == buttonSetNozzle4.Name)
            {
                index = 3;
                _ss.PressureSettings.NozzlePressureSettings.RemoveAt(index);
                _ss.PressureSettings.NozzlePressureSettings.Insert(pressure, index);
                labelNozzle4Pressure.Text = pressure.ToString();
            }
            else if (button.Name == buttonSetNozzle5.Name)
            {
                index = 4;
                _ss.PressureSettings.NozzlePressureSettings.RemoveAt(index);
                _ss.PressureSettings.NozzlePressureSettings.Insert(pressure, index);
                labelNozzle5Pressure.Text = pressure.ToString();
            }
            else if (button.Name == buttonSetNozzle6.Name)
            {
                index = 5;
                _ss.PressureSettings.NozzlePressureSettings.RemoveAt(index);
                _ss.PressureSettings.NozzlePressureSettings.Insert(pressure, index);
                labelNozzle6Pressure.Text = pressure.ToString();
            }
            ChangesMade = true;
            _Main.Cnc.VacuumOff();
            _Main.Cnc.PumpOff();
            _Main.Vacuum_checkBox.Checked = false;
            _Main.Pump_checkBox.Checked = false;
        }


        private void buttonSetNozzle_Click(object sender, EventArgs e)
        {
            SetNozzlePressure(sender);
        }

        private void TbBlockedPressureFactor_TextChanged(object sender, EventArgs e)
        {
            if (EventBlock) return;
            if (double.TryParse(TbBlockedPressureFactor.Text, out var factor))
            {
                if (factor < 0) factor = 0;
                else if (factor > 1) factor = 1;
                _ss.PressureSettings.NozzleBlockedFactor = factor;
                ChangesMade = true;
                TbBlockedPressureFactor.BackColor = System.Drawing.SystemColors.Window;
                return;
            }
            TbBlockedPressureFactor.BackColor = Color.Coral;
        }

        private void TbPickupPressureFactor_TextChanged(object sender, EventArgs e)
        {
            if (EventBlock) return;
            if (double.TryParse(TbPickupPressureFactor.Text, out var factor))
            {
                if (factor < 0.05)
                {
                    TbPickupPressureFactor.BackColor = Color.Coral;
                    return;
                }
                else if (factor > 0.5)
                {
                    TbPickupPressureFactor.BackColor = Color.Coral;
                    return;
                }
                _ss.PressureSettings.PickedUpComponentFactor = factor;
                ChangesMade = true;
                TbPickupPressureFactor.BackColor = System.Drawing.SystemColors.Window;
                return;
            }
            TbPickupPressureFactor.BackColor = Color.Coral;
        }

        private void buttonRefreshPortList_Click(object sender, EventArgs e)
        {
            EventBlock = true;
            RefreshPortList();
            EventBlock = false;
        }
        private void RefreshPortList(string select=null)
        {
            int pos = 0;
            comboBoxSerialPorts.Items.Clear();
            foreach (string s in SerialPort.GetPortNames())
            {
                comboBoxSerialPorts.Items.Add(s);
                if (!string.IsNullOrEmpty(select) && s.Equals(select, StringComparison.OrdinalIgnoreCase))
                    pos= comboBoxSerialPorts.Items.IndexOf(s);
            }

            if (comboBoxSerialPorts.Items.Count == 0)
                labelSerialPortStatus.Text = "No serial ports found!";
            else
                comboBoxSerialPorts.SelectedIndex = pos;
        }

        private void comboBoxSerialPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EventBlock) return;
            if (comboBoxSerialPorts.SelectedIndex >= 0)
                _ss.PressureSettings.SuctionSensorPort = comboBoxSerialPorts.Text;
            ChangesMade = true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
            _Main.AppSettingsSave_button_Click(sender, e);
            ChangesMade = false;
        }

        private void FrmSuctionSensor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ChangesMade)
            {
                var window = MessageBox.Show(
       "Unsaved changes",
       "Are you sure you want to exit?",
       MessageBoxButtons.YesNo);

                e.Cancel = (window == DialogResult.No);
            }
        }

        private void FrmSuctionSensor_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }
    }
}
