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
            this.pnSetting = new System.Windows.Forms.Panel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cbNBIPVer = new System.Windows.Forms.ComboBox();
            this.button36 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbVideo = new System.Windows.Forms.CheckBox();
            this.cbVoice = new System.Windows.Forms.CheckBox();
            this.cbSMS = new System.Windows.Forms.CheckBox();
            this.cbIPSec = new System.Windows.Forms.CheckBox();
            this.button21 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.button25 = new System.Windows.Forms.Button();
            this.button26 = new System.Windows.Forms.Button();
            this.tbTTAVer = new System.Windows.Forms.TextBox();
            this.button27 = new System.Windows.Forms.Button();
            this.button28 = new System.Windows.Forms.Button();
            this.tbDeviceVer = new System.Windows.Forms.TextBox();
            this.button29 = new System.Windows.Forms.Button();
            this.tbDeviceName = new System.Windows.Forms.TextBox();
            this.button30 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button18 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.cbBand5 = new System.Windows.Forms.CheckBox();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbCA = new System.Windows.Forms.CheckBox();
            this.cbAuto2ndPDN = new System.Windows.Forms.CheckBox();
            this.cbImsIP = new System.Windows.Forms.ComboBox();
            this.cbMultiPDN = new System.Windows.Forms.CheckBox();
            this.tbIMEI = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.tbChannel3 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tbChannel2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tbChannel1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.btnIMSI = new System.Windows.Forms.Button();
            this.btnManufac = new System.Windows.Forms.Button();
            this.btnModel = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cBoxATCMD = new System.Windows.Forms.ComboBox();
            this.btnATCMD = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.cbImsPDN = new System.Windows.Forms.ComboBox();
            this.cbEMC = new System.Windows.Forms.CheckBox();
            this.cbBand7 = new System.Windows.Forms.CheckBox();
            this.cbBand1 = new System.Windows.Forms.CheckBox();
            this.cbFGI18 = new System.Windows.Forms.CheckBox();
            this.cbFGI17 = new System.Windows.Forms.CheckBox();
            this.cbFGI5 = new System.Windows.Forms.CheckBox();
            this.cbFGI28 = new System.Windows.Forms.CheckBox();
            this.cbFGI4 = new System.Windows.Forms.CheckBox();
            this.cbRachR9 = new System.Windows.Forms.CheckBox();
            this.cbLogR10 = new System.Windows.Forms.CheckBox();
            this.cbStandaloneGNSS = new System.Windows.Forms.CheckBox();
            this.cbBandCombin = new System.Windows.Forms.CheckBox();
            this.cbCatagory = new System.Windows.Forms.ComboBox();
            this.button23 = new System.Windows.Forms.Button();
            this.button24 = new System.Windows.Forms.Button();
            this.button31 = new System.Windows.Forms.Button();
            this.button32 = new System.Windows.Forms.Button();
            this.button33 = new System.Windows.Forms.Button();
            this.tbDeviceType = new System.Windows.Forms.TextBox();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnSetting.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel4.SuspendLayout();
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
            this.cBoxBaudRate.Location = new System.Drawing.Point(1017, 14);
            this.cBoxBaudRate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cBoxBaudRate.Name = "cBoxBaudRate";
            this.cBoxBaudRate.Size = new System.Drawing.Size(70, 20);
            this.cBoxBaudRate.TabIndex = 2;
            this.cBoxBaudRate.Text = "115200";
            // 
            // cBoxCOMPORT
            // 
            this.cBoxCOMPORT.FormattingEnabled = true;
            this.cBoxCOMPORT.Location = new System.Drawing.Point(938, 14);
            this.cBoxCOMPORT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cBoxCOMPORT.Name = "cBoxCOMPORT";
            this.cBoxCOMPORT.Size = new System.Drawing.Size(73, 20);
            this.cBoxCOMPORT.TabIndex = 1;
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.progressBar1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.progressBar1.Location = new System.Drawing.Point(909, 14);
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
            this.panel1.Controls.Add(this.pnSetting);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1102, 817);
            this.panel1.TabIndex = 10;
            // 
            // pnSetting
            // 
            this.pnSetting.Controls.Add(this.button33);
            this.pnSetting.Controls.Add(this.button32);
            this.pnSetting.Controls.Add(this.button31);
            this.pnSetting.Controls.Add(this.button24);
            this.pnSetting.Controls.Add(this.button23);
            this.pnSetting.Controls.Add(this.groupBox6);
            this.pnSetting.Controls.Add(this.groupBox5);
            this.pnSetting.Controls.Add(this.groupBox2);
            this.pnSetting.Controls.Add(this.groupBox1);
            this.pnSetting.Location = new System.Drawing.Point(12, 12);
            this.pnSetting.Name = "pnSetting";
            this.pnSetting.Size = new System.Drawing.Size(809, 634);
            this.pnSetting.TabIndex = 13;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cbNBIPVer);
            this.groupBox6.Controls.Add(this.button36);
            this.groupBox6.Location = new System.Drawing.Point(411, 465);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox6.Size = new System.Drawing.Size(368, 73);
            this.groupBox6.TabIndex = 26;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "NBIoT";
            // 
            // cbNBIPVer
            // 
            this.cbNBIPVer.FormattingEnabled = true;
            this.cbNBIPVer.Items.AddRange(new object[] {
            "IPv4",
            "IPv6"});
            this.cbNBIPVer.Location = new System.Drawing.Point(216, 21);
            this.cbNBIPVer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbNBIPVer.Name = "cbNBIPVer";
            this.cbNBIPVer.Size = new System.Drawing.Size(126, 20);
            this.cbNBIPVer.TabIndex = 3;
            this.cbNBIPVer.Text = "IPv4";
            // 
            // button36
            // 
            this.button36.Location = new System.Drawing.Point(6, 18);
            this.button36.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button36.Name = "button36";
            this.button36.Size = new System.Drawing.Size(196, 24);
            this.button36.TabIndex = 0;
            this.button36.Text = "IP ver";
            this.button36.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tbDeviceType);
            this.groupBox5.Controls.Add(this.cbVideo);
            this.groupBox5.Controls.Add(this.cbVoice);
            this.groupBox5.Controls.Add(this.cbSMS);
            this.groupBox5.Controls.Add(this.cbIPSec);
            this.groupBox5.Controls.Add(this.button21);
            this.groupBox5.Controls.Add(this.button22);
            this.groupBox5.Controls.Add(this.button25);
            this.groupBox5.Controls.Add(this.button26);
            this.groupBox5.Controls.Add(this.tbTTAVer);
            this.groupBox5.Controls.Add(this.button27);
            this.groupBox5.Controls.Add(this.button28);
            this.groupBox5.Controls.Add(this.tbDeviceVer);
            this.groupBox5.Controls.Add(this.button29);
            this.groupBox5.Controls.Add(this.tbDeviceName);
            this.groupBox5.Controls.Add(this.button30);
            this.groupBox5.Location = new System.Drawing.Point(13, 373);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Size = new System.Drawing.Size(368, 247);
            this.groupBox5.TabIndex = 25;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "VoLTE/SMS";
            // 
            // cbVideo
            // 
            this.cbVideo.AutoSize = true;
            this.cbVideo.Location = new System.Drawing.Point(219, 214);
            this.cbVideo.Name = "cbVideo";
            this.cbVideo.Size = new System.Drawing.Size(60, 16);
            this.cbVideo.TabIndex = 27;
            this.cbVideo.Text = "미지원";
            this.cbVideo.UseVisualStyleBackColor = true;
            this.cbVideo.CheckedChanged += new System.EventHandler(this.checkBox6_CheckedChanged);
            // 
            // cbVoice
            // 
            this.cbVoice.AutoSize = true;
            this.cbVoice.Location = new System.Drawing.Point(219, 186);
            this.cbVoice.Name = "cbVoice";
            this.cbVoice.Size = new System.Drawing.Size(60, 16);
            this.cbVoice.TabIndex = 26;
            this.cbVoice.Text = "미지원";
            this.cbVoice.UseVisualStyleBackColor = true;
            this.cbVoice.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
            // 
            // cbSMS
            // 
            this.cbSMS.AutoSize = true;
            this.cbSMS.Checked = true;
            this.cbSMS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSMS.Location = new System.Drawing.Point(219, 158);
            this.cbSMS.Name = "cbSMS";
            this.cbSMS.Size = new System.Drawing.Size(48, 16);
            this.cbSMS.TabIndex = 25;
            this.cbSMS.Text = "지원";
            this.cbSMS.UseVisualStyleBackColor = true;
            this.cbSMS.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // cbIPSec
            // 
            this.cbIPSec.AutoSize = true;
            this.cbIPSec.Location = new System.Drawing.Point(219, 129);
            this.cbIPSec.Name = "cbIPSec";
            this.cbIPSec.Size = new System.Drawing.Size(60, 16);
            this.cbIPSec.TabIndex = 24;
            this.cbIPSec.Text = "미지원";
            this.cbIPSec.UseVisualStyleBackColor = true;
            this.cbIPSec.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // button21
            // 
            this.button21.Location = new System.Drawing.Point(6, 181);
            this.button21.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(196, 24);
            this.button21.TabIndex = 22;
            this.button21.Text = "음성통화";
            this.button21.UseVisualStyleBackColor = true;
            // 
            // button22
            // 
            this.button22.Location = new System.Drawing.Point(6, 209);
            this.button22.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(196, 24);
            this.button22.TabIndex = 20;
            this.button22.Text = "영상통화";
            this.button22.UseVisualStyleBackColor = true;
            // 
            // button25
            // 
            this.button25.Location = new System.Drawing.Point(6, 153);
            this.button25.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(196, 24);
            this.button25.TabIndex = 14;
            this.button25.Text = "SMS";
            this.button25.UseVisualStyleBackColor = true;
            // 
            // button26
            // 
            this.button26.Location = new System.Drawing.Point(6, 124);
            this.button26.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button26.Name = "button26";
            this.button26.Size = new System.Drawing.Size(196, 24);
            this.button26.TabIndex = 12;
            this.button26.Text = "IPSec";
            this.button26.UseVisualStyleBackColor = true;
            // 
            // tbTTAVer
            // 
            this.tbTTAVer.Location = new System.Drawing.Point(216, 99);
            this.tbTTAVer.Name = "tbTTAVer";
            this.tbTTAVer.Size = new System.Drawing.Size(126, 21);
            this.tbTTAVer.TabIndex = 11;
            this.tbTTAVer.Text = "1.0";
            // 
            // button27
            // 
            this.button27.Location = new System.Drawing.Point(6, 96);
            this.button27.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button27.Name = "button27";
            this.button27.Size = new System.Drawing.Size(196, 24);
            this.button27.TabIndex = 10;
            this.button27.Text = "TTA Version";
            this.button27.UseVisualStyleBackColor = true;
            // 
            // button28
            // 
            this.button28.Location = new System.Drawing.Point(6, 69);
            this.button28.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button28.Name = "button28";
            this.button28.Size = new System.Drawing.Size(196, 24);
            this.button28.TabIndex = 8;
            this.button28.Text = "Device Type";
            this.button28.UseVisualStyleBackColor = true;
            // 
            // tbDeviceVer
            // 
            this.tbDeviceVer.Location = new System.Drawing.Point(216, 43);
            this.tbDeviceVer.Name = "tbDeviceVer";
            this.tbDeviceVer.Size = new System.Drawing.Size(126, 21);
            this.tbDeviceVer.TabIndex = 7;
            this.tbDeviceVer.Text = "BG96MAR03A07M1G";
            // 
            // button29
            // 
            this.button29.Location = new System.Drawing.Point(6, 40);
            this.button29.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button29.Name = "button29";
            this.button29.Size = new System.Drawing.Size(196, 24);
            this.button29.TabIndex = 6;
            this.button29.Text = "Device Ver";
            this.button29.UseVisualStyleBackColor = true;
            // 
            // tbDeviceName
            // 
            this.tbDeviceName.Location = new System.Drawing.Point(216, 15);
            this.tbDeviceName.Name = "tbDeviceName";
            this.tbDeviceName.Size = new System.Drawing.Size(126, 21);
            this.tbDeviceName.TabIndex = 2;
            this.tbDeviceName.Text = "BG96";
            // 
            // button30
            // 
            this.button30.Location = new System.Drawing.Point(6, 12);
            this.button30.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button30.Name = "button30";
            this.button30.Size = new System.Drawing.Size(196, 24);
            this.button30.TabIndex = 0;
            this.button30.Text = "Device NAME";
            this.button30.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbCatagory);
            this.groupBox2.Controls.Add(this.cbBandCombin);
            this.groupBox2.Controls.Add(this.cbStandaloneGNSS);
            this.groupBox2.Controls.Add(this.cbLogR10);
            this.groupBox2.Controls.Add(this.cbRachR9);
            this.groupBox2.Controls.Add(this.cbFGI4);
            this.groupBox2.Controls.Add(this.cbFGI28);
            this.groupBox2.Controls.Add(this.cbFGI5);
            this.groupBox2.Controls.Add(this.cbFGI17);
            this.groupBox2.Controls.Add(this.cbFGI18);
            this.groupBox2.Controls.Add(this.cbBand1);
            this.groupBox2.Controls.Add(this.cbBand7);
            this.groupBox2.Controls.Add(this.button18);
            this.groupBox2.Controls.Add(this.button19);
            this.groupBox2.Controls.Add(this.button20);
            this.groupBox2.Controls.Add(this.cbBand5);
            this.groupBox2.Controls.Add(this.button8);
            this.groupBox2.Controls.Add(this.button9);
            this.groupBox2.Controls.Add(this.button10);
            this.groupBox2.Controls.Add(this.button11);
            this.groupBox2.Controls.Add(this.button12);
            this.groupBox2.Controls.Add(this.button13);
            this.groupBox2.Controls.Add(this.button14);
            this.groupBox2.Controls.Add(this.button15);
            this.groupBox2.Controls.Add(this.button16);
            this.groupBox2.Controls.Add(this.button17);
            this.groupBox2.Location = new System.Drawing.Point(411, 50);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(368, 387);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Capability";
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(6, 294);
            this.button18.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(196, 24);
            this.button18.TabIndex = 31;
            this.button18.Text = "logged Measurement Idle R10";
            this.button18.UseVisualStyleBackColor = true;
            // 
            // button19
            // 
            this.button19.Location = new System.Drawing.Point(6, 322);
            this.button19.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(196, 24);
            this.button19.TabIndex = 29;
            this.button19.Text = "standalone GNSS R10";
            this.button19.UseVisualStyleBackColor = true;
            // 
            // button20
            // 
            this.button20.Location = new System.Drawing.Point(6, 350);
            this.button20.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(196, 24);
            this.button20.TabIndex = 27;
            this.button20.Text = "supportedBandCombination";
            this.button20.UseVisualStyleBackColor = true;
            // 
            // cbBand5
            // 
            this.cbBand5.AutoSize = true;
            this.cbBand5.Checked = true;
            this.cbBand5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbBand5.Location = new System.Drawing.Point(220, 75);
            this.cbBand5.Name = "cbBand5";
            this.cbBand5.Size = new System.Drawing.Size(48, 16);
            this.cbBand5.TabIndex = 24;
            this.cbBand5.Text = "지원";
            this.cbBand5.UseVisualStyleBackColor = true;
            this.cbBand5.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(6, 181);
            this.button8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(196, 24);
            this.button8.TabIndex = 22;
            this.button8.Text = "FGI 17";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(6, 209);
            this.button9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(196, 24);
            this.button9.TabIndex = 20;
            this.button9.Text = "FGI 18";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(6, 237);
            this.button10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(196, 24);
            this.button10.TabIndex = 18;
            this.button10.Text = "FGI 28";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(6, 265);
            this.button11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(196, 24);
            this.button11.TabIndex = 16;
            this.button11.Text = "Rach Report R9";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(6, 153);
            this.button12.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(196, 24);
            this.button12.TabIndex = 14;
            this.button12.Text = "FGI 5";
            this.button12.UseVisualStyleBackColor = true;
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(6, 124);
            this.button13.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(196, 24);
            this.button13.TabIndex = 12;
            this.button13.Text = "FGI 4";
            this.button13.UseVisualStyleBackColor = true;
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(6, 96);
            this.button14.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(196, 24);
            this.button14.TabIndex = 10;
            this.button14.Text = "Band 7";
            this.button14.UseVisualStyleBackColor = true;
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(6, 69);
            this.button15.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(196, 24);
            this.button15.TabIndex = 8;
            this.button15.Text = "Band 5";
            this.button15.UseVisualStyleBackColor = true;
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(6, 40);
            this.button16.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(196, 24);
            this.button16.TabIndex = 6;
            this.button16.Text = "Band 1";
            this.button16.UseVisualStyleBackColor = true;
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(6, 12);
            this.button17.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(196, 24);
            this.button17.TabIndex = 0;
            this.button17.Text = "LTE Category";
            this.button17.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbEMC);
            this.groupBox1.Controls.Add(this.cbImsPDN);
            this.groupBox1.Controls.Add(this.cbCA);
            this.groupBox1.Controls.Add(this.cbAuto2ndPDN);
            this.groupBox1.Controls.Add(this.cbImsIP);
            this.groupBox1.Controls.Add(this.cbMultiPDN);
            this.groupBox1.Controls.Add(this.tbIMEI);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.tbChannel3);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.tbChannel2);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.tbChannel1);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.btnIMSI);
            this.groupBox1.Controls.Add(this.btnManufac);
            this.groupBox1.Controls.Add(this.btnModel);
            this.groupBox1.Location = new System.Drawing.Point(12, 50);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(368, 305);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "COMMON";
            // 
            // cbCA
            // 
            this.cbCA.AutoSize = true;
            this.cbCA.Location = new System.Drawing.Point(220, 270);
            this.cbCA.Name = "cbCA";
            this.cbCA.Size = new System.Drawing.Size(60, 16);
            this.cbCA.TabIndex = 29;
            this.cbCA.Text = "미지원";
            this.cbCA.UseVisualStyleBackColor = true;
            this.cbCA.CheckedChanged += new System.EventHandler(this.checkBox8_CheckedChanged);
            // 
            // cbAuto2ndPDN
            // 
            this.cbAuto2ndPDN.AutoSize = true;
            this.cbAuto2ndPDN.Location = new System.Drawing.Point(220, 214);
            this.cbAuto2ndPDN.Name = "cbAuto2ndPDN";
            this.cbAuto2ndPDN.Size = new System.Drawing.Size(60, 16);
            this.cbAuto2ndPDN.TabIndex = 28;
            this.cbAuto2ndPDN.Text = "안올림";
            this.cbAuto2ndPDN.UseVisualStyleBackColor = true;
            this.cbAuto2ndPDN.CheckedChanged += new System.EventHandler(this.checkBox7_CheckedChanged);
            // 
            // cbImsIP
            // 
            this.cbImsIP.FormattingEnabled = true;
            this.cbImsIP.Items.AddRange(new object[] {
            "IPv4",
            "IPv6"});
            this.cbImsIP.Location = new System.Drawing.Point(216, 44);
            this.cbImsIP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbImsIP.Name = "cbImsIP";
            this.cbImsIP.Size = new System.Drawing.Size(126, 20);
            this.cbImsIP.TabIndex = 4;
            this.cbImsIP.Text = "IPv4";
            // 
            // cbMultiPDN
            // 
            this.cbMultiPDN.AutoSize = true;
            this.cbMultiPDN.Checked = true;
            this.cbMultiPDN.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbMultiPDN.Location = new System.Drawing.Point(220, 75);
            this.cbMultiPDN.Name = "cbMultiPDN";
            this.cbMultiPDN.Size = new System.Drawing.Size(48, 16);
            this.cbMultiPDN.TabIndex = 24;
            this.cbMultiPDN.Text = "지원";
            this.cbMultiPDN.UseVisualStyleBackColor = true;
            this.cbMultiPDN.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // tbIMEI
            // 
            this.tbIMEI.Location = new System.Drawing.Point(216, 184);
            this.tbIMEI.Name = "tbIMEI";
            this.tbIMEI.Size = new System.Drawing.Size(126, 21);
            this.tbIMEI.TabIndex = 23;
            this.tbIMEI.Text = "868446031424969";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(6, 181);
            this.button7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(196, 24);
            this.button7.TabIndex = 22;
            this.button7.Text = "UE IMEI";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(6, 209);
            this.button6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(196, 24);
            this.button6.TabIndex = 20;
            this.button6.Text = "Auto 2nd PDN";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(6, 237);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(196, 24);
            this.button5.TabIndex = 18;
            this.button5.Text = "EMC support";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(6, 265);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(196, 24);
            this.button4.TabIndex = 16;
            this.button4.Text = "CA support";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // tbChannel3
            // 
            this.tbChannel3.Location = new System.Drawing.Point(216, 156);
            this.tbChannel3.Name = "tbChannel3";
            this.tbChannel3.Size = new System.Drawing.Size(126, 21);
            this.tbChannel3.TabIndex = 15;
            this.tbChannel3.Text = "3050";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 153);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(196, 24);
            this.button1.TabIndex = 14;
            this.button1.Text = "Channel 3";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tbChannel2
            // 
            this.tbChannel2.Location = new System.Drawing.Point(216, 127);
            this.tbChannel2.Name = "tbChannel2";
            this.tbChannel2.Size = new System.Drawing.Size(126, 21);
            this.tbChannel2.TabIndex = 13;
            this.tbChannel2.Text = "100";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 124);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(196, 24);
            this.button2.TabIndex = 12;
            this.button2.Text = "Channel 2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // tbChannel1
            // 
            this.tbChannel1.Location = new System.Drawing.Point(216, 99);
            this.tbChannel1.Name = "tbChannel1";
            this.tbChannel1.Size = new System.Drawing.Size(126, 21);
            this.tbChannel1.TabIndex = 11;
            this.tbChannel1.Text = "2600";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 96);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(196, 24);
            this.button3.TabIndex = 10;
            this.button3.Text = "Channel 1";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnIMSI
            // 
            this.btnIMSI.Location = new System.Drawing.Point(6, 69);
            this.btnIMSI.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIMSI.Name = "btnIMSI";
            this.btnIMSI.Size = new System.Drawing.Size(196, 24);
            this.btnIMSI.TabIndex = 8;
            this.btnIMSI.Text = "Multiple PDN";
            this.btnIMSI.UseVisualStyleBackColor = true;
            // 
            // btnManufac
            // 
            this.btnManufac.Location = new System.Drawing.Point(7, 41);
            this.btnManufac.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnManufac.Name = "btnManufac";
            this.btnManufac.Size = new System.Drawing.Size(196, 24);
            this.btnManufac.TabIndex = 6;
            this.btnManufac.Text = "IMS IP ver";
            this.btnManufac.UseVisualStyleBackColor = true;
            // 
            // btnModel
            // 
            this.btnModel.Location = new System.Drawing.Point(6, 12);
            this.btnModel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnModel.Name = "btnModel";
            this.btnModel.Size = new System.Drawing.Size(196, 24);
            this.btnModel.TabIndex = 0;
            this.btnModel.Text = "IMS PDN";
            this.btnModel.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.panel4);
            this.groupBox4.Controls.Add(this.groupBox3);
            this.groupBox4.Location = new System.Drawing.Point(618, 28);
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
            // panel2
            // 
            this.panel2.Controls.Add(this.progressBar1);
            this.panel2.Controls.Add(this.cBoxCOMPORT);
            this.panel2.Controls.Add(this.cBoxBaudRate);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 776);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 2);
            this.panel2.Size = new System.Drawing.Size(1102, 41);
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
            // cbImsPDN
            // 
            this.cbImsPDN.FormattingEnabled = true;
            this.cbImsPDN.Items.AddRange(new object[] {
            "1번째",
            "2번째"});
            this.cbImsPDN.Location = new System.Drawing.Point(216, 15);
            this.cbImsPDN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbImsPDN.Name = "cbImsPDN";
            this.cbImsPDN.Size = new System.Drawing.Size(126, 20);
            this.cbImsPDN.TabIndex = 30;
            this.cbImsPDN.Text = "1번째";
            // 
            // cbEMC
            // 
            this.cbEMC.AutoSize = true;
            this.cbEMC.Checked = true;
            this.cbEMC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbEMC.Location = new System.Drawing.Point(220, 242);
            this.cbEMC.Name = "cbEMC";
            this.cbEMC.Size = new System.Drawing.Size(48, 16);
            this.cbEMC.TabIndex = 31;
            this.cbEMC.Text = "지원";
            this.cbEMC.UseVisualStyleBackColor = true;
            this.cbEMC.CheckedChanged += new System.EventHandler(this.checkBox9_CheckedChanged);
            // 
            // cbBand7
            // 
            this.cbBand7.AutoSize = true;
            this.cbBand7.Location = new System.Drawing.Point(220, 101);
            this.cbBand7.Name = "cbBand7";
            this.cbBand7.Size = new System.Drawing.Size(60, 16);
            this.cbBand7.TabIndex = 33;
            this.cbBand7.Text = "미지원";
            this.cbBand7.UseVisualStyleBackColor = true;
            this.cbBand7.CheckedChanged += new System.EventHandler(this.checkBox10_CheckedChanged);
            // 
            // cbBand1
            // 
            this.cbBand1.AutoSize = true;
            this.cbBand1.Location = new System.Drawing.Point(220, 45);
            this.cbBand1.Name = "cbBand1";
            this.cbBand1.Size = new System.Drawing.Size(60, 16);
            this.cbBand1.TabIndex = 34;
            this.cbBand1.Text = "미지원";
            this.cbBand1.UseVisualStyleBackColor = true;
            this.cbBand1.CheckedChanged += new System.EventHandler(this.checkBox11_CheckedChanged);
            // 
            // cbFGI18
            // 
            this.cbFGI18.AutoSize = true;
            this.cbFGI18.Checked = true;
            this.cbFGI18.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFGI18.Location = new System.Drawing.Point(220, 214);
            this.cbFGI18.Name = "cbFGI18";
            this.cbFGI18.Size = new System.Drawing.Size(48, 16);
            this.cbFGI18.TabIndex = 35;
            this.cbFGI18.Text = "지원";
            this.cbFGI18.UseVisualStyleBackColor = true;
            this.cbFGI18.CheckedChanged += new System.EventHandler(this.checkBox12_CheckedChanged);
            // 
            // cbFGI17
            // 
            this.cbFGI17.AutoSize = true;
            this.cbFGI17.Checked = true;
            this.cbFGI17.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFGI17.Location = new System.Drawing.Point(220, 186);
            this.cbFGI17.Name = "cbFGI17";
            this.cbFGI17.Size = new System.Drawing.Size(48, 16);
            this.cbFGI17.TabIndex = 36;
            this.cbFGI17.Text = "지원";
            this.cbFGI17.UseVisualStyleBackColor = true;
            this.cbFGI17.CheckedChanged += new System.EventHandler(this.checkBox13_CheckedChanged);
            // 
            // cbFGI5
            // 
            this.cbFGI5.AutoSize = true;
            this.cbFGI5.Checked = true;
            this.cbFGI5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFGI5.Location = new System.Drawing.Point(220, 158);
            this.cbFGI5.Name = "cbFGI5";
            this.cbFGI5.Size = new System.Drawing.Size(48, 16);
            this.cbFGI5.TabIndex = 37;
            this.cbFGI5.Text = "지원";
            this.cbFGI5.UseVisualStyleBackColor = true;
            this.cbFGI5.CheckedChanged += new System.EventHandler(this.checkBox14_CheckedChanged);
            // 
            // cbFGI28
            // 
            this.cbFGI28.AutoSize = true;
            this.cbFGI28.Location = new System.Drawing.Point(216, 242);
            this.cbFGI28.Name = "cbFGI28";
            this.cbFGI28.Size = new System.Drawing.Size(60, 16);
            this.cbFGI28.TabIndex = 38;
            this.cbFGI28.Text = "미지원";
            this.cbFGI28.UseVisualStyleBackColor = true;
            this.cbFGI28.CheckedChanged += new System.EventHandler(this.checkBox15_CheckedChanged);
            // 
            // cbFGI4
            // 
            this.cbFGI4.AutoSize = true;
            this.cbFGI4.Location = new System.Drawing.Point(220, 129);
            this.cbFGI4.Name = "cbFGI4";
            this.cbFGI4.Size = new System.Drawing.Size(60, 16);
            this.cbFGI4.TabIndex = 39;
            this.cbFGI4.Text = "미지원";
            this.cbFGI4.UseVisualStyleBackColor = true;
            this.cbFGI4.CheckedChanged += new System.EventHandler(this.checkBox16_CheckedChanged);
            // 
            // cbRachR9
            // 
            this.cbRachR9.AutoSize = true;
            this.cbRachR9.Location = new System.Drawing.Point(216, 270);
            this.cbRachR9.Name = "cbRachR9";
            this.cbRachR9.Size = new System.Drawing.Size(60, 16);
            this.cbRachR9.TabIndex = 40;
            this.cbRachR9.Text = "미지원";
            this.cbRachR9.UseVisualStyleBackColor = true;
            this.cbRachR9.CheckedChanged += new System.EventHandler(this.checkBox17_CheckedChanged);
            // 
            // cbLogR10
            // 
            this.cbLogR10.AutoSize = true;
            this.cbLogR10.Location = new System.Drawing.Point(216, 299);
            this.cbLogR10.Name = "cbLogR10";
            this.cbLogR10.Size = new System.Drawing.Size(60, 16);
            this.cbLogR10.TabIndex = 41;
            this.cbLogR10.Text = "미지원";
            this.cbLogR10.UseVisualStyleBackColor = true;
            this.cbLogR10.CheckedChanged += new System.EventHandler(this.checkBox18_CheckedChanged);
            // 
            // cbStandaloneGNSS
            // 
            this.cbStandaloneGNSS.AutoSize = true;
            this.cbStandaloneGNSS.Location = new System.Drawing.Point(216, 327);
            this.cbStandaloneGNSS.Name = "cbStandaloneGNSS";
            this.cbStandaloneGNSS.Size = new System.Drawing.Size(60, 16);
            this.cbStandaloneGNSS.TabIndex = 42;
            this.cbStandaloneGNSS.Text = "미지원";
            this.cbStandaloneGNSS.UseVisualStyleBackColor = true;
            this.cbStandaloneGNSS.CheckedChanged += new System.EventHandler(this.checkBox19_CheckedChanged);
            // 
            // cbBandCombin
            // 
            this.cbBandCombin.AutoSize = true;
            this.cbBandCombin.Location = new System.Drawing.Point(216, 355);
            this.cbBandCombin.Name = "cbBandCombin";
            this.cbBandCombin.Size = new System.Drawing.Size(60, 16);
            this.cbBandCombin.TabIndex = 43;
            this.cbBandCombin.Text = "미지원";
            this.cbBandCombin.UseVisualStyleBackColor = true;
            this.cbBandCombin.CheckedChanged += new System.EventHandler(this.checkBox20_CheckedChanged);
            // 
            // cbCatagory
            // 
            this.cbCatagory.FormattingEnabled = true;
            this.cbCatagory.Items.AddRange(new object[] {
            "Cat 1",
            "Cat 4"});
            this.cbCatagory.Location = new System.Drawing.Point(216, 15);
            this.cbCatagory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbCatagory.Name = "cbCatagory";
            this.cbCatagory.Size = new System.Drawing.Size(126, 20);
            this.cbCatagory.TabIndex = 32;
            this.cbCatagory.Text = "Cat 1";
            // 
            // button23
            // 
            this.button23.Location = new System.Drawing.Point(612, 566);
            this.button23.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(167, 24);
            this.button23.TabIndex = 27;
            this.button23.Text = "파일 쓰기";
            this.button23.UseVisualStyleBackColor = true;
            this.button23.Click += new System.EventHandler(this.button23_Click);
            // 
            // button24
            // 
            this.button24.Location = new System.Drawing.Point(417, 566);
            this.button24.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(167, 24);
            this.button24.TabIndex = 28;
            this.button24.Text = "파일 읽기";
            this.button24.UseVisualStyleBackColor = true;
            this.button24.Click += new System.EventHandler(this.button24_Click);
            // 
            // button31
            // 
            this.button31.Location = new System.Drawing.Point(95, 16);
            this.button31.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button31.Name = "button31";
            this.button31.Size = new System.Drawing.Size(167, 24);
            this.button31.TabIndex = 29;
            this.button31.Text = "LTE";
            this.button31.UseVisualStyleBackColor = true;
            // 
            // button32
            // 
            this.button32.Location = new System.Drawing.Point(512, 16);
            this.button32.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button32.Name = "button32";
            this.button32.Size = new System.Drawing.Size(167, 24);
            this.button32.TabIndex = 30;
            this.button32.Text = "NB IoT";
            this.button32.UseVisualStyleBackColor = true;
            // 
            // button33
            // 
            this.button33.Location = new System.Drawing.Point(300, 16);
            this.button33.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button33.Name = "button33";
            this.button33.Size = new System.Drawing.Size(167, 24);
            this.button33.TabIndex = 31;
            this.button33.Text = "Cat M1";
            this.button33.UseVisualStyleBackColor = true;
            // 
            // tbDeviceType
            // 
            this.tbDeviceType.Location = new System.Drawing.Point(215, 72);
            this.tbDeviceType.Name = "tbDeviceType";
            this.tbDeviceType.Size = new System.Drawing.Size(126, 21);
            this.tbDeviceType.TabIndex = 28;
            this.tbDeviceType.Text = "modem";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 817);
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
            this.pnSetting.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnIMSI;
        private System.Windows.Forms.Button btnManufac;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnATCMD;
        private System.Windows.Forms.ComboBox cBoxATCMD;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Panel pnSetting;
        private System.Windows.Forms.TextBox tbChannel3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbChannel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tbChannel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox cbMultiPDN;
        private System.Windows.Forms.TextBox tbIMEI;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox cbNBIPVer;
        private System.Windows.Forms.Button button36;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox cbVideo;
        private System.Windows.Forms.CheckBox cbVoice;
        private System.Windows.Forms.CheckBox cbSMS;
        private System.Windows.Forms.CheckBox cbIPSec;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.Button button22;
        private System.Windows.Forms.Button button25;
        private System.Windows.Forms.Button button26;
        private System.Windows.Forms.TextBox tbTTAVer;
        private System.Windows.Forms.Button button27;
        private System.Windows.Forms.Button button28;
        private System.Windows.Forms.TextBox tbDeviceVer;
        private System.Windows.Forms.Button button29;
        private System.Windows.Forms.TextBox tbDeviceName;
        private System.Windows.Forms.Button button30;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.CheckBox cbBand5;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.ComboBox cbImsIP;
        private System.Windows.Forms.CheckBox cbCA;
        private System.Windows.Forms.CheckBox cbAuto2ndPDN;
        private System.Windows.Forms.ComboBox cbImsPDN;
        private System.Windows.Forms.Button button33;
        private System.Windows.Forms.Button button32;
        private System.Windows.Forms.Button button31;
        private System.Windows.Forms.Button button24;
        private System.Windows.Forms.Button button23;
        private System.Windows.Forms.ComboBox cbCatagory;
        private System.Windows.Forms.CheckBox cbBandCombin;
        private System.Windows.Forms.CheckBox cbStandaloneGNSS;
        private System.Windows.Forms.CheckBox cbLogR10;
        private System.Windows.Forms.CheckBox cbRachR9;
        private System.Windows.Forms.CheckBox cbFGI4;
        private System.Windows.Forms.CheckBox cbFGI28;
        private System.Windows.Forms.CheckBox cbFGI5;
        private System.Windows.Forms.CheckBox cbFGI17;
        private System.Windows.Forms.CheckBox cbFGI18;
        private System.Windows.Forms.CheckBox cbBand1;
        private System.Windows.Forms.CheckBox cbBand7;
        private System.Windows.Forms.CheckBox cbEMC;
        private System.Windows.Forms.TextBox tbDeviceType;
    }
}

