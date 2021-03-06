﻿
namespace LitePlacer
{
    partial class FrmSuctionSensor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSuctionSensor));
            this.label3 = new System.Windows.Forms.Label();
            this.buttonRefreshPortList = new System.Windows.Forms.Button();
            this.labelSerialPortStatus = new System.Windows.Forms.Label();
            this.buttonConnectSerial = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxSerialPorts = new System.Windows.Forms.ComboBox();
            this.CbEnableSuctionSensor = new System.Windows.Forms.CheckBox();
            this.labelSuctionSensorCurrentPressure = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelAmbientPressure = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelFullSuction = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonSetAmbient = new System.Windows.Forms.Button();
            this.buttonSetFullSuction = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.labelNozzle1Pressure = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonSetNozzle1 = new System.Windows.Forms.Button();
            this.labelNozzle2Pressure = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.buttonSetNozzle2 = new System.Windows.Forms.Button();
            this.labelNozzle3Pressure = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.buttonSetNozzle3 = new System.Windows.Forms.Button();
            this.labelNozzle4Pressure = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.buttonSetNozzle4 = new System.Windows.Forms.Button();
            this.labelNozzle5Pressure = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.buttonSetNozzle5 = new System.Windows.Forms.Button();
            this.labelNozzle6Pressure = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.buttonSetNozzle6 = new System.Windows.Forms.Button();
            this.TbPickupPressureFactor = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.TbBlockedPressureFactor = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.CbIncrementComponent = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NudPickupRetries = new System.Windows.Forms.NumericUpDown();
            this.CbBeepOnBlockedNozzle = new System.Windows.Forms.CheckBox();
            this.CbBeepOnPickupFail = new System.Windows.Forms.CheckBox();
            this.CbBeepOnPickupRetryExceeded = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LblPickupDetected = new System.Windows.Forms.Label();
            this.LblBlockDetected = new System.Windows.Forms.Label();
            this.BtnTestPickupBlockNozzle1 = new System.Windows.Forms.Button();
            this.BtnTestPickupBlockNozzle2 = new System.Windows.Forms.Button();
            this.BtnTestPickupBlockNozzle3 = new System.Windows.Forms.Button();
            this.BtnTestPickupBlockNozzle4 = new System.Windows.Forms.Button();
            this.BtnTestPickupBlockNozzle5 = new System.Windows.Forms.Button();
            this.BtnTestPickupBlockNozzle6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NudPickupRetries)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Status:";
            // 
            // buttonRefreshPortList
            // 
            this.buttonRefreshPortList.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonRefreshPortList.Location = new System.Drawing.Point(231, 8);
            this.buttonRefreshPortList.Name = "buttonRefreshPortList";
            this.buttonRefreshPortList.Size = new System.Drawing.Size(139, 24);
            this.buttonRefreshPortList.TabIndex = 10;
            this.buttonRefreshPortList.Text = "Refresh List";
            this.buttonRefreshPortList.UseVisualStyleBackColor = true;
            this.buttonRefreshPortList.Click += new System.EventHandler(this.buttonRefreshPortList_Click);
            // 
            // labelSerialPortStatus
            // 
            this.labelSerialPortStatus.AutoSize = true;
            this.labelSerialPortStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSerialPortStatus.Location = new System.Drawing.Point(67, 47);
            this.labelSerialPortStatus.Name = "labelSerialPortStatus";
            this.labelSerialPortStatus.Size = new System.Drawing.Size(100, 17);
            this.labelSerialPortStatus.TabIndex = 9;
            this.labelSerialPortStatus.Text = "Not connected";
            // 
            // buttonConnectSerial
            // 
            this.buttonConnectSerial.Location = new System.Drawing.Point(376, 9);
            this.buttonConnectSerial.Name = "buttonConnectSerial";
            this.buttonConnectSerial.Size = new System.Drawing.Size(139, 24);
            this.buttonConnectSerial.TabIndex = 8;
            this.buttonConnectSerial.Text = "Connect";
            this.buttonConnectSerial.UseVisualStyleBackColor = true;
            this.buttonConnectSerial.Click += new System.EventHandler(this.buttonConnectSerial_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Serial Port:";
            // 
            // comboBoxSerialPorts
            // 
            this.comboBoxSerialPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSerialPorts.FormattingEnabled = true;
            this.comboBoxSerialPorts.Location = new System.Drawing.Point(110, 9);
            this.comboBoxSerialPorts.Name = "comboBoxSerialPorts";
            this.comboBoxSerialPorts.Size = new System.Drawing.Size(115, 24);
            this.comboBoxSerialPorts.TabIndex = 6;
            this.comboBoxSerialPorts.SelectedIndexChanged += new System.EventHandler(this.comboBoxSerialPorts_SelectedIndexChanged);
            // 
            // CbEnableSuctionSensor
            // 
            this.CbEnableSuctionSensor.AutoSize = true;
            this.CbEnableSuctionSensor.Location = new System.Drawing.Point(13, 115);
            this.CbEnableSuctionSensor.Name = "CbEnableSuctionSensor";
            this.CbEnableSuctionSensor.Size = new System.Drawing.Size(170, 21);
            this.CbEnableSuctionSensor.TabIndex = 12;
            this.CbEnableSuctionSensor.Text = "Enable suction sensor";
            this.CbEnableSuctionSensor.UseVisualStyleBackColor = true;
            this.CbEnableSuctionSensor.CheckedChanged += new System.EventHandler(this.CbEnableSuctionSensor_CheckedChanged);
            // 
            // labelSuctionSensorCurrentPressure
            // 
            this.labelSuctionSensorCurrentPressure.AutoSize = true;
            this.labelSuctionSensorCurrentPressure.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSuctionSensorCurrentPressure.Location = new System.Drawing.Point(128, 3);
            this.labelSuctionSensorCurrentPressure.Name = "labelSuctionSensorCurrentPressure";
            this.labelSuctionSensorCurrentPressure.Size = new System.Drawing.Size(20, 24);
            this.labelSuctionSensorCurrentPressure.TabIndex = 9;
            this.labelSuctionSensorCurrentPressure.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Current pressure:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelAmbientPressure
            // 
            this.labelAmbientPressure.AutoSize = true;
            this.labelAmbientPressure.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAmbientPressure.Location = new System.Drawing.Point(331, 293);
            this.labelAmbientPressure.Name = "labelAmbientPressure";
            this.labelAmbientPressure.Size = new System.Drawing.Size(20, 24);
            this.labelAmbientPressure.TabIndex = 9;
            this.labelAmbientPressure.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(202, 296);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Ambient pressure:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelFullSuction
            // 
            this.labelFullSuction.AutoSize = true;
            this.labelFullSuction.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFullSuction.Location = new System.Drawing.Point(331, 344);
            this.labelFullSuction.Name = "labelFullSuction";
            this.labelFullSuction.Size = new System.Drawing.Size(20, 24);
            this.labelFullSuction.TabIndex = 9;
            this.labelFullSuction.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(237, 347);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 17);
            this.label7.TabIndex = 11;
            this.label7.Text = "Full suction:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonSetAmbient
            // 
            this.buttonSetAmbient.Location = new System.Drawing.Point(12, 293);
            this.buttonSetAmbient.Name = "buttonSetAmbient";
            this.buttonSetAmbient.Size = new System.Drawing.Size(75, 23);
            this.buttonSetAmbient.TabIndex = 13;
            this.buttonSetAmbient.Text = "Set";
            this.buttonSetAmbient.UseVisualStyleBackColor = true;
            this.buttonSetAmbient.Click += new System.EventHandler(this.buttonSetAmbient_Click);
            // 
            // buttonSetFullSuction
            // 
            this.buttonSetFullSuction.Location = new System.Drawing.Point(12, 344);
            this.buttonSetFullSuction.Name = "buttonSetFullSuction";
            this.buttonSetFullSuction.Size = new System.Drawing.Size(75, 23);
            this.buttonSetFullSuction.TabIndex = 13;
            this.buttonSetFullSuction.Text = "Set";
            this.buttonSetFullSuction.UseVisualStyleBackColor = true;
            this.buttonSetFullSuction.Click += new System.EventHandler(this.buttonSetFullSuction_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 635);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 17);
            this.label9.TabIndex = 11;
            this.label9.Text = "Picked up factor:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 748);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 17);
            this.label11.TabIndex = 11;
            this.label11.Text = "Blocked factor:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelNozzle1Pressure
            // 
            this.labelNozzle1Pressure.AutoSize = true;
            this.labelNozzle1Pressure.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNozzle1Pressure.Location = new System.Drawing.Point(333, 390);
            this.labelNozzle1Pressure.Name = "labelNozzle1Pressure";
            this.labelNozzle1Pressure.Size = new System.Drawing.Size(20, 24);
            this.labelNozzle1Pressure.TabIndex = 9;
            this.labelNozzle1Pressure.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(195, 393);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(127, 17);
            this.label10.TabIndex = 11;
            this.label10.Text = "Nozzle 1 pressure:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonSetNozzle1
            // 
            this.buttonSetNozzle1.Location = new System.Drawing.Point(14, 390);
            this.buttonSetNozzle1.Name = "buttonSetNozzle1";
            this.buttonSetNozzle1.Size = new System.Drawing.Size(75, 23);
            this.buttonSetNozzle1.TabIndex = 13;
            this.buttonSetNozzle1.Text = "Set";
            this.buttonSetNozzle1.UseVisualStyleBackColor = true;
            this.buttonSetNozzle1.Click += new System.EventHandler(this.buttonSetNozzle_Click);
            // 
            // labelNozzle2Pressure
            // 
            this.labelNozzle2Pressure.AutoSize = true;
            this.labelNozzle2Pressure.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNozzle2Pressure.Location = new System.Drawing.Point(333, 419);
            this.labelNozzle2Pressure.Name = "labelNozzle2Pressure";
            this.labelNozzle2Pressure.Size = new System.Drawing.Size(20, 24);
            this.labelNozzle2Pressure.TabIndex = 9;
            this.labelNozzle2Pressure.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(195, 422);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(127, 17);
            this.label13.TabIndex = 11;
            this.label13.Text = "Nozzle 2 pressure:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonSetNozzle2
            // 
            this.buttonSetNozzle2.Location = new System.Drawing.Point(14, 419);
            this.buttonSetNozzle2.Name = "buttonSetNozzle2";
            this.buttonSetNozzle2.Size = new System.Drawing.Size(75, 23);
            this.buttonSetNozzle2.TabIndex = 13;
            this.buttonSetNozzle2.Text = "Set";
            this.buttonSetNozzle2.UseVisualStyleBackColor = true;
            this.buttonSetNozzle2.Click += new System.EventHandler(this.buttonSetNozzle_Click);
            // 
            // labelNozzle3Pressure
            // 
            this.labelNozzle3Pressure.AutoSize = true;
            this.labelNozzle3Pressure.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNozzle3Pressure.Location = new System.Drawing.Point(333, 448);
            this.labelNozzle3Pressure.Name = "labelNozzle3Pressure";
            this.labelNozzle3Pressure.Size = new System.Drawing.Size(20, 24);
            this.labelNozzle3Pressure.TabIndex = 9;
            this.labelNozzle3Pressure.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(195, 451);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(127, 17);
            this.label15.TabIndex = 11;
            this.label15.Text = "Nozzle 3 pressure:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonSetNozzle3
            // 
            this.buttonSetNozzle3.Location = new System.Drawing.Point(14, 448);
            this.buttonSetNozzle3.Name = "buttonSetNozzle3";
            this.buttonSetNozzle3.Size = new System.Drawing.Size(75, 23);
            this.buttonSetNozzle3.TabIndex = 13;
            this.buttonSetNozzle3.Text = "Set";
            this.buttonSetNozzle3.UseVisualStyleBackColor = true;
            this.buttonSetNozzle3.Click += new System.EventHandler(this.buttonSetNozzle_Click);
            // 
            // labelNozzle4Pressure
            // 
            this.labelNozzle4Pressure.AutoSize = true;
            this.labelNozzle4Pressure.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNozzle4Pressure.Location = new System.Drawing.Point(333, 477);
            this.labelNozzle4Pressure.Name = "labelNozzle4Pressure";
            this.labelNozzle4Pressure.Size = new System.Drawing.Size(20, 24);
            this.labelNozzle4Pressure.TabIndex = 9;
            this.labelNozzle4Pressure.Text = "0";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(195, 480);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(127, 17);
            this.label17.TabIndex = 11;
            this.label17.Text = "Nozzle 4 pressure:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonSetNozzle4
            // 
            this.buttonSetNozzle4.Location = new System.Drawing.Point(14, 477);
            this.buttonSetNozzle4.Name = "buttonSetNozzle4";
            this.buttonSetNozzle4.Size = new System.Drawing.Size(75, 23);
            this.buttonSetNozzle4.TabIndex = 13;
            this.buttonSetNozzle4.Text = "Set";
            this.buttonSetNozzle4.UseVisualStyleBackColor = true;
            this.buttonSetNozzle4.Click += new System.EventHandler(this.buttonSetNozzle_Click);
            // 
            // labelNozzle5Pressure
            // 
            this.labelNozzle5Pressure.AutoSize = true;
            this.labelNozzle5Pressure.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNozzle5Pressure.Location = new System.Drawing.Point(333, 506);
            this.labelNozzle5Pressure.Name = "labelNozzle5Pressure";
            this.labelNozzle5Pressure.Size = new System.Drawing.Size(20, 24);
            this.labelNozzle5Pressure.TabIndex = 9;
            this.labelNozzle5Pressure.Text = "0";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(195, 509);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(127, 17);
            this.label19.TabIndex = 11;
            this.label19.Text = "Nozzle 5 pressure:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonSetNozzle5
            // 
            this.buttonSetNozzle5.Location = new System.Drawing.Point(14, 506);
            this.buttonSetNozzle5.Name = "buttonSetNozzle5";
            this.buttonSetNozzle5.Size = new System.Drawing.Size(75, 23);
            this.buttonSetNozzle5.TabIndex = 13;
            this.buttonSetNozzle5.Text = "Set";
            this.buttonSetNozzle5.UseVisualStyleBackColor = true;
            this.buttonSetNozzle5.Click += new System.EventHandler(this.buttonSetNozzle_Click);
            // 
            // labelNozzle6Pressure
            // 
            this.labelNozzle6Pressure.AutoSize = true;
            this.labelNozzle6Pressure.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNozzle6Pressure.Location = new System.Drawing.Point(333, 535);
            this.labelNozzle6Pressure.Name = "labelNozzle6Pressure";
            this.labelNozzle6Pressure.Size = new System.Drawing.Size(20, 24);
            this.labelNozzle6Pressure.TabIndex = 9;
            this.labelNozzle6Pressure.Text = "0";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(195, 538);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(127, 17);
            this.label21.TabIndex = 11;
            this.label21.Text = "Nozzle 6 pressure:";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonSetNozzle6
            // 
            this.buttonSetNozzle6.Location = new System.Drawing.Point(14, 535);
            this.buttonSetNozzle6.Name = "buttonSetNozzle6";
            this.buttonSetNozzle6.Size = new System.Drawing.Size(75, 23);
            this.buttonSetNozzle6.TabIndex = 13;
            this.buttonSetNozzle6.Text = "Set";
            this.buttonSetNozzle6.UseVisualStyleBackColor = true;
            this.buttonSetNozzle6.Click += new System.EventHandler(this.buttonSetNozzle_Click);
            // 
            // TbPickupPressureFactor
            // 
            this.TbPickupPressureFactor.BackColor = System.Drawing.SystemColors.Window;
            this.TbPickupPressureFactor.Location = new System.Drawing.Point(131, 632);
            this.TbPickupPressureFactor.Name = "TbPickupPressureFactor";
            this.TbPickupPressureFactor.Size = new System.Drawing.Size(100, 22);
            this.TbPickupPressureFactor.TabIndex = 14;
            this.TbPickupPressureFactor.Text = "0.4";
            this.TbPickupPressureFactor.TextChanged += new System.EventHandler(this.TbPickupPressureFactor_TextChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(11, 573);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(630, 51);
            this.label22.TabIndex = 11;
            this.label22.Text = resources.GetString("label22.Text");
            // 
            // TbBlockedPressureFactor
            // 
            this.TbBlockedPressureFactor.Location = new System.Drawing.Point(131, 745);
            this.TbBlockedPressureFactor.Name = "TbBlockedPressureFactor";
            this.TbBlockedPressureFactor.Size = new System.Drawing.Size(100, 22);
            this.TbBlockedPressureFactor.TabIndex = 14;
            this.TbBlockedPressureFactor.Text = "0.7";
            this.TbBlockedPressureFactor.TextChanged += new System.EventHandler(this.TbBlockedPressureFactor_TextChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(11, 663);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(426, 68);
            this.label23.TabIndex = 11;
            this.label23.Text = resources.GetString("label23.Text");
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(11, 273);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(187, 17);
            this.label24.TabIndex = 11;
            this.label24.Text = "Remove nozzle and click set";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(11, 319);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(397, 17);
            this.label25.TabIndex = 11;
            this.label25.Text = "Place finger over nozzle, then click set, wait for a few seconds";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(11, 370);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(326, 17);
            this.label26.TabIndex = 11;
            this.label26.Text = "Place nozzle x on and click set, wait a few seconds";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(521, 9);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(139, 24);
            this.buttonSave.TabIndex = 15;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // CbIncrementComponent
            // 
            this.CbIncrementComponent.AutoSize = true;
            this.CbIncrementComponent.Location = new System.Drawing.Point(12, 142);
            this.CbIncrementComponent.Name = "CbIncrementComponent";
            this.CbIncrementComponent.Size = new System.Drawing.Size(339, 21);
            this.CbIncrementComponent.TabIndex = 12;
            this.CbIncrementComponent.Text = "Increment component each time we fail to pick up";
            this.CbIncrementComponent.UseVisualStyleBackColor = true;
            this.CbIncrementComponent.CheckedChanged += new System.EventHandler(this.CbIncrementComponent_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Pickup retries before failing";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NudPickupRetries
            // 
            this.NudPickupRetries.Location = new System.Drawing.Point(12, 248);
            this.NudPickupRetries.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.NudPickupRetries.Name = "NudPickupRetries";
            this.NudPickupRetries.Size = new System.Drawing.Size(62, 22);
            this.NudPickupRetries.TabIndex = 16;
            // 
            // CbBeepOnBlockedNozzle
            // 
            this.CbBeepOnBlockedNozzle.AutoSize = true;
            this.CbBeepOnBlockedNozzle.Location = new System.Drawing.Point(12, 169);
            this.CbBeepOnBlockedNozzle.Name = "CbBeepOnBlockedNozzle";
            this.CbBeepOnBlockedNozzle.Size = new System.Drawing.Size(181, 21);
            this.CbBeepOnBlockedNozzle.TabIndex = 12;
            this.CbBeepOnBlockedNozzle.Text = "Beep on blocked nozzle";
            this.CbBeepOnBlockedNozzle.UseVisualStyleBackColor = true;
            this.CbBeepOnBlockedNozzle.CheckedChanged += new System.EventHandler(this.CbBeepOnBlockedNozzle_CheckedChanged);
            // 
            // CbBeepOnPickupFail
            // 
            this.CbBeepOnPickupFail.AutoSize = true;
            this.CbBeepOnPickupFail.Location = new System.Drawing.Point(12, 196);
            this.CbBeepOnPickupFail.Name = "CbBeepOnPickupFail";
            this.CbBeepOnPickupFail.Size = new System.Drawing.Size(150, 21);
            this.CbBeepOnPickupFail.TabIndex = 12;
            this.CbBeepOnPickupFail.Text = "Beep on pickup fail";
            this.CbBeepOnPickupFail.UseVisualStyleBackColor = true;
            this.CbBeepOnPickupFail.CheckedChanged += new System.EventHandler(this.CbBeepOnPickupFail_CheckedChanged);
            // 
            // CbBeepOnPickupRetryExceeded
            // 
            this.CbBeepOnPickupRetryExceeded.AutoSize = true;
            this.CbBeepOnPickupRetryExceeded.Location = new System.Drawing.Point(12, 221);
            this.CbBeepOnPickupRetryExceeded.Name = "CbBeepOnPickupRetryExceeded";
            this.CbBeepOnPickupRetryExceeded.Size = new System.Drawing.Size(226, 21);
            this.CbBeepOnPickupRetryExceeded.TabIndex = 12;
            this.CbBeepOnPickupRetryExceeded.Text = "Beep on pickup retry exceeded";
            this.CbBeepOnPickupRetryExceeded.UseVisualStyleBackColor = true;
            this.CbBeepOnPickupRetryExceeded.CheckedChanged += new System.EventHandler(this.CbBeepOnPickupRetryExceeded_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.labelSuctionSensorCurrentPressure);
            this.panel1.Location = new System.Drawing.Point(12, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(226, 37);
            this.panel1.TabIndex = 17;
            // 
            // LblPickupDetected
            // 
            this.LblPickupDetected.AutoSize = true;
            this.LblPickupDetected.Location = new System.Drawing.Point(237, 635);
            this.LblPickupDetected.Name = "LblPickupDetected";
            this.LblPickupDetected.Size = new System.Drawing.Size(71, 17);
            this.LblPickupDetected.TabIndex = 11;
            this.LblPickupDetected.Text = "Press test";
            this.LblPickupDetected.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblBlockDetected
            // 
            this.LblBlockDetected.AutoSize = true;
            this.LblBlockDetected.Location = new System.Drawing.Point(237, 748);
            this.LblBlockDetected.Name = "LblBlockDetected";
            this.LblBlockDetected.Size = new System.Drawing.Size(71, 17);
            this.LblBlockDetected.TabIndex = 11;
            this.LblBlockDetected.Text = "Press test";
            this.LblBlockDetected.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BtnTestPickupBlockNozzle1
            // 
            this.BtnTestPickupBlockNozzle1.Location = new System.Drawing.Point(95, 390);
            this.BtnTestPickupBlockNozzle1.Name = "BtnTestPickupBlockNozzle1";
            this.BtnTestPickupBlockNozzle1.Size = new System.Drawing.Size(75, 23);
            this.BtnTestPickupBlockNozzle1.TabIndex = 13;
            this.BtnTestPickupBlockNozzle1.Text = "Test";
            this.BtnTestPickupBlockNozzle1.UseVisualStyleBackColor = true;
            this.BtnTestPickupBlockNozzle1.Click += new System.EventHandler(this.BtnTestPickupBlockNozzle_Click);
            // 
            // BtnTestPickupBlockNozzle2
            // 
            this.BtnTestPickupBlockNozzle2.Location = new System.Drawing.Point(95, 419);
            this.BtnTestPickupBlockNozzle2.Name = "BtnTestPickupBlockNozzle2";
            this.BtnTestPickupBlockNozzle2.Size = new System.Drawing.Size(75, 23);
            this.BtnTestPickupBlockNozzle2.TabIndex = 13;
            this.BtnTestPickupBlockNozzle2.Text = "Test";
            this.BtnTestPickupBlockNozzle2.UseVisualStyleBackColor = true;
            this.BtnTestPickupBlockNozzle2.Click += new System.EventHandler(this.BtnTestPickupBlockNozzle_Click);
            // 
            // BtnTestPickupBlockNozzle3
            // 
            this.BtnTestPickupBlockNozzle3.Location = new System.Drawing.Point(95, 448);
            this.BtnTestPickupBlockNozzle3.Name = "BtnTestPickupBlockNozzle3";
            this.BtnTestPickupBlockNozzle3.Size = new System.Drawing.Size(75, 23);
            this.BtnTestPickupBlockNozzle3.TabIndex = 13;
            this.BtnTestPickupBlockNozzle3.Text = "Test";
            this.BtnTestPickupBlockNozzle3.UseVisualStyleBackColor = true;
            this.BtnTestPickupBlockNozzle3.Click += new System.EventHandler(this.BtnTestPickupBlockNozzle_Click);
            // 
            // BtnTestPickupBlockNozzle4
            // 
            this.BtnTestPickupBlockNozzle4.Location = new System.Drawing.Point(95, 477);
            this.BtnTestPickupBlockNozzle4.Name = "BtnTestPickupBlockNozzle4";
            this.BtnTestPickupBlockNozzle4.Size = new System.Drawing.Size(75, 23);
            this.BtnTestPickupBlockNozzle4.TabIndex = 13;
            this.BtnTestPickupBlockNozzle4.Text = "Test";
            this.BtnTestPickupBlockNozzle4.UseVisualStyleBackColor = true;
            this.BtnTestPickupBlockNozzle4.Click += new System.EventHandler(this.BtnTestPickupBlockNozzle_Click);
            // 
            // BtnTestPickupBlockNozzle5
            // 
            this.BtnTestPickupBlockNozzle5.Location = new System.Drawing.Point(95, 506);
            this.BtnTestPickupBlockNozzle5.Name = "BtnTestPickupBlockNozzle5";
            this.BtnTestPickupBlockNozzle5.Size = new System.Drawing.Size(75, 23);
            this.BtnTestPickupBlockNozzle5.TabIndex = 13;
            this.BtnTestPickupBlockNozzle5.Text = "Test";
            this.BtnTestPickupBlockNozzle5.UseVisualStyleBackColor = true;
            this.BtnTestPickupBlockNozzle5.Click += new System.EventHandler(this.BtnTestPickupBlockNozzle_Click);
            // 
            // BtnTestPickupBlockNozzle6
            // 
            this.BtnTestPickupBlockNozzle6.Location = new System.Drawing.Point(95, 535);
            this.BtnTestPickupBlockNozzle6.Name = "BtnTestPickupBlockNozzle6";
            this.BtnTestPickupBlockNozzle6.Size = new System.Drawing.Size(75, 23);
            this.BtnTestPickupBlockNozzle6.TabIndex = 13;
            this.BtnTestPickupBlockNozzle6.Text = "Test";
            this.BtnTestPickupBlockNozzle6.UseVisualStyleBackColor = true;
            this.BtnTestPickupBlockNozzle6.Click += new System.EventHandler(this.BtnTestPickupBlockNozzle_Click);
            // 
            // FrmSuctionSensor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 796);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.NudPickupRetries);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.TbBlockedPressureFactor);
            this.Controls.Add(this.TbPickupPressureFactor);
            this.Controls.Add(this.buttonSetNozzle6);
            this.Controls.Add(this.buttonSetNozzle5);
            this.Controls.Add(this.buttonSetNozzle4);
            this.Controls.Add(this.buttonSetNozzle3);
            this.Controls.Add(this.buttonSetNozzle2);
            this.Controls.Add(this.BtnTestPickupBlockNozzle6);
            this.Controls.Add(this.BtnTestPickupBlockNozzle5);
            this.Controls.Add(this.BtnTestPickupBlockNozzle4);
            this.Controls.Add(this.BtnTestPickupBlockNozzle3);
            this.Controls.Add(this.BtnTestPickupBlockNozzle2);
            this.Controls.Add(this.BtnTestPickupBlockNozzle1);
            this.Controls.Add(this.buttonSetNozzle1);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.buttonSetFullSuction);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.buttonSetAmbient);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.CbBeepOnPickupRetryExceeded);
            this.Controls.Add(this.CbBeepOnPickupFail);
            this.Controls.Add(this.CbBeepOnBlockedNozzle);
            this.Controls.Add(this.CbIncrementComponent);
            this.Controls.Add(this.CbEnableSuctionSensor);
            this.Controls.Add(this.labelNozzle6Pressure);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.labelNozzle5Pressure);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.LblBlockDetected);
            this.Controls.Add(this.LblPickupDetected);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.labelNozzle4Pressure);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.labelNozzle3Pressure);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labelNozzle2Pressure);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelNozzle1Pressure);
            this.Controls.Add(this.labelFullSuction);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelAmbientPressure);
            this.Controls.Add(this.buttonRefreshPortList);
            this.Controls.Add(this.labelSerialPortStatus);
            this.Controls.Add(this.buttonConnectSerial);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxSerialPorts);
            this.Name = "FrmSuctionSensor";
            this.Text = "FrmSuctionSensor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSuctionSensor_FormClosing);
            this.Load += new System.EventHandler(this.FrmSuctionSensor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NudPickupRetries)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonRefreshPortList;
        private System.Windows.Forms.Label labelSerialPortStatus;
        private System.Windows.Forms.Button buttonConnectSerial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxSerialPorts;
        private System.Windows.Forms.CheckBox CbEnableSuctionSensor;
        private System.Windows.Forms.Label labelSuctionSensorCurrentPressure;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelAmbientPressure;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelFullSuction;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonSetAmbient;
        private System.Windows.Forms.Button buttonSetFullSuction;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label labelNozzle1Pressure;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonSetNozzle1;
        private System.Windows.Forms.Label labelNozzle2Pressure;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button buttonSetNozzle2;
        private System.Windows.Forms.Label labelNozzle3Pressure;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button buttonSetNozzle3;
        private System.Windows.Forms.Label labelNozzle4Pressure;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button buttonSetNozzle4;
        private System.Windows.Forms.Label labelNozzle5Pressure;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button buttonSetNozzle5;
        private System.Windows.Forms.Label labelNozzle6Pressure;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button buttonSetNozzle6;
        private System.Windows.Forms.TextBox TbPickupPressureFactor;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox TbBlockedPressureFactor;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.CheckBox CbIncrementComponent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NudPickupRetries;
        private System.Windows.Forms.CheckBox CbBeepOnBlockedNozzle;
        private System.Windows.Forms.CheckBox CbBeepOnPickupFail;
        private System.Windows.Forms.CheckBox CbBeepOnPickupRetryExceeded;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblPickupDetected;
        private System.Windows.Forms.Label LblBlockDetected;
        private System.Windows.Forms.Button BtnTestPickupBlockNozzle1;
        private System.Windows.Forms.Button BtnTestPickupBlockNozzle2;
        private System.Windows.Forms.Button BtnTestPickupBlockNozzle3;
        private System.Windows.Forms.Button BtnTestPickupBlockNozzle4;
        private System.Windows.Forms.Button BtnTestPickupBlockNozzle5;
        private System.Windows.Forms.Button BtnTestPickupBlockNozzle6;
    }
}