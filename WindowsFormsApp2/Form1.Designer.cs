namespace WindowsFormsApp2
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.cBoxCOMPORT = new System.Windows.Forms.ComboBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.tBoxDataIN = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cBoxATCMD = new System.Windows.Forms.ComboBox();
            this.btnATCMD = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tBoxTCPPort = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.tBoxTCPIP = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.tBoxSMSCTN = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.tBoxModemVer = new System.Windows.Forms.TextBox();
            this.btnModemVer = new System.Windows.Forms.Button();
            this.tBoxFOTAIndex = new System.Windows.Forms.TextBox();
            this.btnFOTAConti = new System.Windows.Forms.Button();
            this.tBoxDeviceVer = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.tBoxDeviceSN = new System.Windows.Forms.TextBox();
            this.btSNConst = new System.Windows.Forms.Button();
            this.tBoxDeviceModel = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.cBoxSERVER = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tBoxSVCCD = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tBoxIccid = new System.Windows.Forms.TextBox();
            this.btnICCID = new System.Windows.Forms.Button();
            this.tBoxActionState = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.tBoxIMEI = new System.Windows.Forms.TextBox();
            this.btnIMEI = new System.Windows.Forms.Button();
            this.tBoxIMSI = new System.Windows.Forms.TextBox();
            this.btnIMSI = new System.Windows.Forms.Button();
            this.tBoxManu = new System.Windows.Forms.TextBox();
            this.btnManufac = new System.Windows.Forms.Button();
            this.tBoxModel = new System.Windows.Forms.TextBox();
            this.btnModel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cBoxBaudRate
            // 
            this.cBoxBaudRate.FormattingEnabled = true;
            this.cBoxBaudRate.Items.AddRange(new object[] {
            "2400",
            "4800",
            "9600",
            "38400",
            "76800",
            "115200"});
            this.cBoxBaudRate.Location = new System.Drawing.Point(118, 10);
            this.cBoxBaudRate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cBoxBaudRate.Name = "cBoxBaudRate";
            this.cBoxBaudRate.Size = new System.Drawing.Size(70, 20);
            this.cBoxBaudRate.TabIndex = 2;
            this.cBoxBaudRate.Text = "115200";
            // 
            // cBoxCOMPORT
            // 
            this.cBoxCOMPORT.FormattingEnabled = true;
            this.cBoxCOMPORT.Location = new System.Drawing.Point(39, 10);
            this.cBoxCOMPORT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cBoxCOMPORT.Name = "cBoxCOMPORT";
            this.cBoxCOMPORT.Size = new System.Drawing.Size(73, 20);
            this.cBoxCOMPORT.TabIndex = 1;
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.progressBar1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.progressBar1.Location = new System.Drawing.Point(10, 10);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(22, 18);
            this.progressBar1.TabIndex = 2;
            this.progressBar1.Click += new System.EventHandler(this.ProgressBar1_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPort1_DataReceived);
            // 
            // tBoxDataIN
            // 
            this.tBoxDataIN.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tBoxDataIN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tBoxDataIN.Location = new System.Drawing.Point(3, 61);
            this.tBoxDataIN.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tBoxDataIN.Multiline = true;
            this.tBoxDataIN.Name = "tBoxDataIN";
            this.tBoxDataIN.ReadOnly = true;
            this.tBoxDataIN.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tBoxDataIN.Size = new System.Drawing.Size(460, 297);
            this.tBoxDataIN.TabIndex = 6;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tBoxDataIN);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(3, 96);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(466, 360);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1102, 547);
            this.panel1.TabIndex = 10;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.panel4);
            this.groupBox4.Controls.Add(this.groupBox3);
            this.groupBox4.Location = new System.Drawing.Point(225, -2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(472, 459);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cBoxATCMD);
            this.panel4.Controls.Add(this.btnATCMD);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 17);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(466, 20);
            this.panel4.TabIndex = 12;
            // 
            // cBoxATCMD
            // 
            this.cBoxATCMD.Dock = System.Windows.Forms.DockStyle.Left;
            this.cBoxATCMD.FormattingEnabled = true;
            this.cBoxATCMD.Items.AddRange(new object[] {
            "AT"});
            this.cBoxATCMD.Location = new System.Drawing.Point(0, 0);
            this.cBoxATCMD.Name = "cBoxATCMD";
            this.cBoxATCMD.Size = new System.Drawing.Size(381, 20);
            this.cBoxATCMD.Sorted = true;
            this.cBoxATCMD.TabIndex = 3;
            this.cBoxATCMD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CBoxATCMD_KeyDown);
            // 
            // btnATCMD
            // 
            this.btnATCMD.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnATCMD.Location = new System.Drawing.Point(381, 0);
            this.btnATCMD.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnATCMD.Name = "btnATCMD";
            this.btnATCMD.Size = new System.Drawing.Size(85, 20);
            this.btnATCMD.TabIndex = 2;
            this.btnATCMD.Text = "AT명령";
            this.btnATCMD.UseVisualStyleBackColor = true;
            this.btnATCMD.Click += new System.EventHandler(this.BtnATCMD_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tBoxTCPPort);
            this.groupBox1.Controls.Add(this.button8);
            this.groupBox1.Controls.Add(this.tBoxTCPIP);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.tBoxSMSCTN);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.tBoxModemVer);
            this.groupBox1.Controls.Add(this.btnModemVer);
            this.groupBox1.Controls.Add(this.tBoxFOTAIndex);
            this.groupBox1.Controls.Add(this.btnFOTAConti);
            this.groupBox1.Controls.Add(this.tBoxDeviceVer);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.tBoxDeviceSN);
            this.groupBox1.Controls.Add(this.btSNConst);
            this.groupBox1.Controls.Add(this.tBoxDeviceModel);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.cBoxSERVER);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.tBoxSVCCD);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.tBoxIccid);
            this.groupBox1.Controls.Add(this.btnICCID);
            this.groupBox1.Controls.Add(this.tBoxActionState);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.tBoxIMEI);
            this.groupBox1.Controls.Add(this.btnIMEI);
            this.groupBox1.Controls.Add(this.tBoxIMSI);
            this.groupBox1.Controls.Add(this.btnIMSI);
            this.groupBox1.Controls.Add(this.tBoxManu);
            this.groupBox1.Controls.Add(this.btnManufac);
            this.groupBox1.Controls.Add(this.tBoxModel);
            this.groupBox1.Controls.Add(this.btnModel);
            this.groupBox1.Location = new System.Drawing.Point(10, -1);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(209, 458);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // tBoxTCPPort
            // 
            this.tBoxTCPPort.Location = new System.Drawing.Point(77, 437);
            this.tBoxTCPPort.Name = "tBoxTCPPort";
            this.tBoxTCPPort.Size = new System.Drawing.Size(126, 21);
            this.tBoxTCPPort.TabIndex = 35;
            this.tBoxTCPPort.Text = "11101";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(6, 437);
            this.button8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(66, 24);
            this.button8.TabIndex = 34;
            this.button8.Text = "TCP port";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // tBoxTCPIP
            // 
            this.tBoxTCPIP.Location = new System.Drawing.Point(77, 411);
            this.tBoxTCPIP.Name = "tBoxTCPIP";
            this.tBoxTCPIP.Size = new System.Drawing.Size(126, 21);
            this.tBoxTCPIP.TabIndex = 33;
            this.tBoxTCPIP.Text = "106.103.228.139";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(6, 411);
            this.button7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(66, 24);
            this.button7.TabIndex = 32;
            this.button7.Text = "TCP IP";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // tBoxSMSCTN
            // 
            this.tBoxSMSCTN.Location = new System.Drawing.Point(77, 382);
            this.tBoxSMSCTN.Name = "tBoxSMSCTN";
            this.tBoxSMSCTN.Size = new System.Drawing.Size(126, 21);
            this.tBoxSMSCTN.TabIndex = 31;
            this.tBoxSMSCTN.Text = "01222990103";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(6, 382);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(66, 24);
            this.button5.TabIndex = 30;
            this.button5.Text = "전화번호";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // tBoxModemVer
            // 
            this.tBoxModemVer.Location = new System.Drawing.Point(77, 152);
            this.tBoxModemVer.Name = "tBoxModemVer";
            this.tBoxModemVer.ReadOnly = true;
            this.tBoxModemVer.Size = new System.Drawing.Size(126, 21);
            this.tBoxModemVer.TabIndex = 29;
            this.tBoxModemVer.Text = "알 수 없음";
            // 
            // btnModemVer
            // 
            this.btnModemVer.Location = new System.Drawing.Point(6, 149);
            this.btnModemVer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnModemVer.Name = "btnModemVer";
            this.btnModemVer.Size = new System.Drawing.Size(66, 24);
            this.btnModemVer.TabIndex = 28;
            this.btnModemVer.Text = "모뎀버전";
            this.btnModemVer.UseVisualStyleBackColor = true;
            this.btnModemVer.Click += new System.EventHandler(this.btnModemVer_Click);
            // 
            // tBoxFOTAIndex
            // 
            this.tBoxFOTAIndex.Location = new System.Drawing.Point(77, 327);
            this.tBoxFOTAIndex.Name = "tBoxFOTAIndex";
            this.tBoxFOTAIndex.Size = new System.Drawing.Size(126, 21);
            this.tBoxFOTAIndex.TabIndex = 27;
            this.tBoxFOTAIndex.Text = "2";
            // 
            // btnFOTAConti
            // 
            this.btnFOTAConti.Location = new System.Drawing.Point(6, 327);
            this.btnFOTAConti.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFOTAConti.Name = "btnFOTAConti";
            this.btnFOTAConti.Size = new System.Drawing.Size(66, 24);
            this.btnFOTAConti.TabIndex = 26;
            this.btnFOTAConti.Text = "이어받기";
            this.btnFOTAConti.UseVisualStyleBackColor = true;
            this.btnFOTAConti.Click += new System.EventHandler(this.BtnFOTAConti_Click);
            // 
            // tBoxDeviceVer
            // 
            this.tBoxDeviceVer.Location = new System.Drawing.Point(77, 299);
            this.tBoxDeviceVer.Name = "tBoxDeviceVer";
            this.tBoxDeviceVer.Size = new System.Drawing.Size(126, 21);
            this.tBoxDeviceVer.TabIndex = 25;
            this.tBoxDeviceVer.Text = "1.0.0";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(6, 299);
            this.button6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(66, 24);
            this.button6.TabIndex = 24;
            this.button6.Text = "단말버전";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Button6_Click);
            // 
            // tBoxDeviceSN
            // 
            this.tBoxDeviceSN.Location = new System.Drawing.Point(77, 270);
            this.tBoxDeviceSN.Name = "tBoxDeviceSN";
            this.tBoxDeviceSN.Size = new System.Drawing.Size(126, 21);
            this.tBoxDeviceSN.TabIndex = 23;
            this.tBoxDeviceSN.Text = "123456";
            // 
            // btSNConst
            // 
            this.btSNConst.Location = new System.Drawing.Point(6, 270);
            this.btSNConst.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btSNConst.Name = "btSNConst";
            this.btSNConst.Size = new System.Drawing.Size(66, 24);
            this.btSNConst.TabIndex = 22;
            this.btSNConst.Text = "폴더명/SN";
            this.btSNConst.UseVisualStyleBackColor = true;
            // 
            // tBoxDeviceModel
            // 
            this.tBoxDeviceModel.Location = new System.Drawing.Point(77, 242);
            this.tBoxDeviceModel.Name = "tBoxDeviceModel";
            this.tBoxDeviceModel.Size = new System.Drawing.Size(126, 21);
            this.tBoxDeviceModel.TabIndex = 21;
            this.tBoxDeviceModel.Text = "AMM5400LG";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 242);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(66, 24);
            this.button3.TabIndex = 20;
            this.button3.Text = "단말모델";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // cBoxSERVER
            // 
            this.cBoxSERVER.FormattingEnabled = true;
            this.cBoxSERVER.Items.AddRange(new object[] {
            "개발",
            "검증",
            "상용",
            "NMS개발",
            "NMS상용"});
            this.cBoxSERVER.Location = new System.Drawing.Point(77, 355);
            this.cBoxSERVER.Name = "cBoxSERVER";
            this.cBoxSERVER.Size = new System.Drawing.Size(126, 20);
            this.cBoxSERVER.TabIndex = 19;
            this.cBoxSERVER.Text = "개발";
            this.cBoxSERVER.SelectedIndexChanged += new System.EventHandler(this.CBoxSERVER_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 354);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(66, 24);
            this.button2.TabIndex = 18;
            this.button2.Text = "서버";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // tBoxSVCCD
            // 
            this.tBoxSVCCD.Location = new System.Drawing.Point(77, 213);
            this.tBoxSVCCD.Name = "tBoxSVCCD";
            this.tBoxSVCCD.Size = new System.Drawing.Size(126, 21);
            this.tBoxSVCCD.TabIndex = 17;
            this.tBoxSVCCD.Text = "CATO";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 213);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 24);
            this.button1.TabIndex = 16;
            this.button1.Text = "서비스코드";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tBoxIccid
            // 
            this.tBoxIccid.Location = new System.Drawing.Point(77, 97);
            this.tBoxIccid.Name = "tBoxIccid";
            this.tBoxIccid.ReadOnly = true;
            this.tBoxIccid.Size = new System.Drawing.Size(126, 21);
            this.tBoxIccid.TabIndex = 15;
            this.tBoxIccid.Text = "알 수 없음";
            // 
            // btnICCID
            // 
            this.btnICCID.Location = new System.Drawing.Point(6, 95);
            this.btnICCID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnICCID.Name = "btnICCID";
            this.btnICCID.Size = new System.Drawing.Size(66, 24);
            this.btnICCID.TabIndex = 14;
            this.btnICCID.Text = "ICCID";
            this.btnICCID.UseVisualStyleBackColor = true;
            this.btnICCID.Click += new System.EventHandler(this.btnICCID_Click);
            // 
            // tBoxActionState
            // 
            this.tBoxActionState.Location = new System.Drawing.Point(77, 181);
            this.tBoxActionState.Name = "tBoxActionState";
            this.tBoxActionState.ReadOnly = true;
            this.tBoxActionState.Size = new System.Drawing.Size(126, 21);
            this.tBoxActionState.TabIndex = 13;
            this.tBoxActionState.Text = "idle";
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(6, 181);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(66, 24);
            this.button4.TabIndex = 12;
            this.button4.Text = "동작상태";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // tBoxIMEI
            // 
            this.tBoxIMEI.Location = new System.Drawing.Point(77, 126);
            this.tBoxIMEI.Name = "tBoxIMEI";
            this.tBoxIMEI.ReadOnly = true;
            this.tBoxIMEI.Size = new System.Drawing.Size(126, 21);
            this.tBoxIMEI.TabIndex = 11;
            this.tBoxIMEI.Text = "알 수 없음";
            // 
            // btnIMEI
            // 
            this.btnIMEI.Location = new System.Drawing.Point(6, 123);
            this.btnIMEI.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIMEI.Name = "btnIMEI";
            this.btnIMEI.Size = new System.Drawing.Size(66, 24);
            this.btnIMEI.TabIndex = 10;
            this.btnIMEI.Text = "IMEI";
            this.btnIMEI.UseVisualStyleBackColor = true;
            this.btnIMEI.Click += new System.EventHandler(this.btnIMEI_Click);
            // 
            // tBoxIMSI
            // 
            this.tBoxIMSI.Location = new System.Drawing.Point(77, 71);
            this.tBoxIMSI.Name = "tBoxIMSI";
            this.tBoxIMSI.ReadOnly = true;
            this.tBoxIMSI.Size = new System.Drawing.Size(126, 21);
            this.tBoxIMSI.TabIndex = 9;
            this.tBoxIMSI.Text = "알 수 없음";
            // 
            // btnIMSI
            // 
            this.btnIMSI.Location = new System.Drawing.Point(6, 69);
            this.btnIMSI.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIMSI.Name = "btnIMSI";
            this.btnIMSI.Size = new System.Drawing.Size(66, 24);
            this.btnIMSI.TabIndex = 8;
            this.btnIMSI.Text = "CTN";
            this.btnIMSI.UseVisualStyleBackColor = true;
            this.btnIMSI.Click += new System.EventHandler(this.btnIMSI_Click);
            // 
            // tBoxManu
            // 
            this.tBoxManu.Location = new System.Drawing.Point(77, 42);
            this.tBoxManu.Name = "tBoxManu";
            this.tBoxManu.ReadOnly = true;
            this.tBoxManu.Size = new System.Drawing.Size(126, 21);
            this.tBoxManu.TabIndex = 7;
            this.tBoxManu.Text = "알 수 없음";
            // 
            // btnManufac
            // 
            this.btnManufac.Location = new System.Drawing.Point(6, 40);
            this.btnManufac.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnManufac.Name = "btnManufac";
            this.btnManufac.Size = new System.Drawing.Size(66, 24);
            this.btnManufac.TabIndex = 6;
            this.btnManufac.Text = "제조사";
            this.btnManufac.UseVisualStyleBackColor = true;
            this.btnManufac.Click += new System.EventHandler(this.btnManufac_Click);
            // 
            // tBoxModel
            // 
            this.tBoxModel.Location = new System.Drawing.Point(77, 12);
            this.tBoxModel.Name = "tBoxModel";
            this.tBoxModel.ReadOnly = true;
            this.tBoxModel.Size = new System.Drawing.Size(126, 21);
            this.tBoxModel.TabIndex = 2;
            this.tBoxModel.Text = "알 수 없음";
            // 
            // btnModel
            // 
            this.btnModel.Location = new System.Drawing.Point(6, 12);
            this.btnModel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnModel.Name = "btnModel";
            this.btnModel.Size = new System.Drawing.Size(66, 24);
            this.btnModel.TabIndex = 0;
            this.btnModel.Text = "모듈모델";
            this.btnModel.UseVisualStyleBackColor = true;
            this.btnModel.Click += new System.EventHandler(this.BtnModel_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.progressBar1);
            this.panel2.Controls.Add(this.cBoxCOMPORT);
            this.panel2.Controls.Add(this.cBoxBaudRate);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 492);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 2);
            this.panel2.Size = new System.Drawing.Size(1102, 55);
            this.panel2.TabIndex = 10;
            // 
            // timer1
            // 
            this.timer1.Interval = 15000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 10000;
            this.timer2.Tick += new System.EventHandler(this.Timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 547);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(1920, 1066);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(750, 522);
            this.Name = "Form1";
            this.Text = "LGU+ ATcommand TEST";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ComboBox cBoxBaudRate;
        private System.Windows.Forms.ComboBox cBoxCOMPORT;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox tBoxDataIN;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnModel;
        private System.Windows.Forms.TextBox tBoxActionState;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox tBoxIMEI;
        private System.Windows.Forms.Button btnIMEI;
        private System.Windows.Forms.TextBox tBoxIMSI;
        private System.Windows.Forms.Button btnIMSI;
        private System.Windows.Forms.TextBox tBoxManu;
        private System.Windows.Forms.Button btnManufac;
        private System.Windows.Forms.TextBox tBoxModel;
        private System.Windows.Forms.TextBox tBoxIccid;
        private System.Windows.Forms.Button btnICCID;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tBoxSVCCD;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cBoxSERVER;
        private System.Windows.Forms.TextBox tBoxDeviceModel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnATCMD;
        private System.Windows.Forms.ComboBox cBoxATCMD;
        private System.Windows.Forms.TextBox tBoxDeviceSN;
        private System.Windows.Forms.Button btSNConst;
        private System.Windows.Forms.TextBox tBoxDeviceVer;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.TextBox tBoxFOTAIndex;
        private System.Windows.Forms.Button btnFOTAConti;
        private System.Windows.Forms.TextBox tBoxModemVer;
        private System.Windows.Forms.Button btnModemVer;
        private System.Windows.Forms.TextBox tBoxSMSCTN;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox tBoxTCPPort;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox tBoxTCPIP;
        private System.Windows.Forms.Button button7;
    }
}

