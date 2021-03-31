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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabCOM = new System.Windows.Forms.TabPage();
            this.button63 = new System.Windows.Forms.Button();
            this.textBox64 = new System.Windows.Forms.TextBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.button86 = new System.Windows.Forms.Button();
            this.textBox24 = new System.Windows.Forms.TextBox();
            this.button99 = new System.Windows.Forms.Button();
            this.textBox58 = new System.Windows.Forms.TextBox();
            this.button100 = new System.Windows.Forms.Button();
            this.textBox59 = new System.Windows.Forms.TextBox();
            this.button101 = new System.Windows.Forms.Button();
            this.textBox60 = new System.Windows.Forms.TextBox();
            this.textBox61 = new System.Windows.Forms.TextBox();
            this.button62 = new System.Windows.Forms.Button();
            this.gbDeviceLog = new System.Windows.Forms.GroupBox();
            this.tBoxDataIN = new System.Windows.Forms.TextBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.label47 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.lbModemVer = new System.Windows.Forms.TextBox();
            this.textBox89 = new System.Windows.Forms.TextBox();
            this.lbIccid = new System.Windows.Forms.TextBox();
            this.textBox87 = new System.Windows.Forms.TextBox();
            this.textBox86 = new System.Windows.Forms.TextBox();
            this.button87 = new System.Windows.Forms.Button();
            this.textBox85 = new System.Windows.Forms.TextBox();
            this.textBox57 = new System.Windows.Forms.TextBox();
            this.textBox40 = new System.Windows.Forms.TextBox();
            this.textBox38 = new System.Windows.Forms.TextBox();
            this.textBox33 = new System.Windows.Forms.TextBox();
            this.button71 = new System.Windows.Forms.Button();
            this.button83 = new System.Windows.Forms.Button();
            this.textBox44 = new System.Windows.Forms.TextBox();
            this.button88 = new System.Windows.Forms.Button();
            this.textBox45 = new System.Windows.Forms.TextBox();
            this.textBox46 = new System.Windows.Forms.TextBox();
            this.textBox47 = new System.Windows.Forms.TextBox();
            this.textBox48 = new System.Windows.Forms.TextBox();
            this.textBox49 = new System.Windows.Forms.TextBox();
            this.button89 = new System.Windows.Forms.Button();
            this.button90 = new System.Windows.Forms.Button();
            this.button91 = new System.Windows.Forms.Button();
            this.tabSMST = new System.Windows.Forms.TabPage();
            this.pnSetting = new System.Windows.Forms.Panel();
            this.button68 = new System.Windows.Forms.Button();
            this.button33 = new System.Windows.Forms.Button();
            this.button32 = new System.Windows.Forms.Button();
            this.button31 = new System.Windows.Forms.Button();
            this.button24 = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cbNBIPVer = new System.Windows.Forms.ComboBox();
            this.button36 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tbDeviceType = new System.Windows.Forms.TextBox();
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
            this.cbCatagory = new System.Windows.Forms.ComboBox();
            this.cbBandCombin = new System.Windows.Forms.CheckBox();
            this.cbStandaloneGNSS = new System.Windows.Forms.CheckBox();
            this.cbLogR10 = new System.Windows.Forms.CheckBox();
            this.cbRachR9 = new System.Windows.Forms.CheckBox();
            this.cbFGI4 = new System.Windows.Forms.CheckBox();
            this.cbFGI28 = new System.Windows.Forms.CheckBox();
            this.cbFGI5 = new System.Windows.Forms.CheckBox();
            this.cbFGI17 = new System.Windows.Forms.CheckBox();
            this.cbFGI18 = new System.Windows.Forms.CheckBox();
            this.cbBand1 = new System.Windows.Forms.CheckBox();
            this.cbBand7 = new System.Windows.Forms.CheckBox();
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
            this.cbEMC = new System.Windows.Forms.CheckBox();
            this.cbImsPDN = new System.Windows.Forms.ComboBox();
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
            this.tabPROXY = new System.Windows.Forms.TabPage();
            this.pnProxy = new System.Windows.Forms.Panel();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.button44 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.button73 = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.button61 = new System.Windows.Forms.Button();
            this.textBox25 = new System.Windows.Forms.TextBox();
            this.button64 = new System.Windows.Forms.Button();
            this.textBox26 = new System.Windows.Forms.TextBox();
            this.button65 = new System.Windows.Forms.Button();
            this.textBox27 = new System.Windows.Forms.TextBox();
            this.button66 = new System.Windows.Forms.Button();
            this.textBox28 = new System.Windows.Forms.TextBox();
            this.textBox29 = new System.Windows.Forms.TextBox();
            this.textBox30 = new System.Windows.Forms.TextBox();
            this.textBox31 = new System.Windows.Forms.TextBox();
            this.textBox32 = new System.Windows.Forms.TextBox();
            this.button67 = new System.Windows.Forms.Button();
            this.button74 = new System.Windows.Forms.Button();
            this.button75 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox23 = new System.Windows.Forms.TextBox();
            this.button69 = new System.Windows.Forms.Button();
            this.textBox34 = new System.Windows.Forms.TextBox();
            this.button76 = new System.Windows.Forms.Button();
            this.textBox35 = new System.Windows.Forms.TextBox();
            this.button77 = new System.Windows.Forms.Button();
            this.textBox36 = new System.Windows.Forms.TextBox();
            this.button78 = new System.Windows.Forms.Button();
            this.textBox37 = new System.Windows.Forms.TextBox();
            this.button79 = new System.Windows.Forms.Button();
            this.textBox39 = new System.Windows.Forms.TextBox();
            this.textBox41 = new System.Windows.Forms.TextBox();
            this.button82 = new System.Windows.Forms.Button();
            this.button84 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button60 = new System.Windows.Forms.Button();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.button59 = new System.Windows.Forms.Button();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.button58 = new System.Windows.Forms.Button();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.button57 = new System.Windows.Forms.Button();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.button56 = new System.Windows.Forms.Button();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.button55 = new System.Windows.Forms.Button();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.button43 = new System.Windows.Forms.Button();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.textBox42 = new System.Windows.Forms.TextBox();
            this.button54 = new System.Windows.Forms.Button();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.textBox43 = new System.Windows.Forms.TextBox();
            this.button53 = new System.Windows.Forms.Button();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.button52 = new System.Windows.Forms.Button();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.button51 = new System.Windows.Forms.Button();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.button85 = new System.Windows.Forms.Button();
            this.button50 = new System.Windows.Forms.Button();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.button49 = new System.Windows.Forms.Button();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.button48 = new System.Windows.Forms.Button();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.button47 = new System.Windows.Forms.Button();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.button46 = new System.Windows.Forms.Button();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.button45 = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button37 = new System.Windows.Forms.Button();
            this.button38 = new System.Windows.Forms.Button();
            this.button39 = new System.Windows.Forms.Button();
            this.button42 = new System.Windows.Forms.Button();
            this.button40 = new System.Windows.Forms.Button();
            this.button41 = new System.Windows.Forms.Button();
            this.tabOneM2M = new System.Windows.Forms.TabPage();
            this.button117 = new System.Windows.Forms.Button();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.label50 = new System.Windows.Forms.Label();
            this.textBox76 = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.textBox72 = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.textBox73 = new System.Windows.Forms.TextBox();
            this.button104 = new System.Windows.Forms.Button();
            this.label30 = new System.Windows.Forms.Label();
            this.btReset = new System.Windows.Forms.Button();
            this.textBox62 = new System.Windows.Forms.TextBox();
            this.btnDeviceFOTA = new System.Windows.Forms.Button();
            this.btnoneM2MModuleVer = new System.Windows.Forms.Button();
            this.btnModemFOTA = new System.Windows.Forms.Button();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.button70 = new System.Windows.Forms.Button();
            this.button102 = new System.Windows.Forms.Button();
            this.button103 = new System.Windows.Forms.Button();
            this.button80 = new System.Windows.Forms.Button();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.button116 = new System.Windows.Forms.Button();
            this.button115 = new System.Windows.Forms.Button();
            this.btnSetRxContainer = new System.Windows.Forms.Button();
            this.btnSendDataOneM2M = new System.Windows.Forms.Button();
            this.btnRcvDataOneM2M = new System.Windows.Forms.Button();
            this.lboneM2MRcvData = new System.Windows.Forms.Label();
            this.btnSetSubscript = new System.Windows.Forms.Button();
            this.btnDelRxContainer = new System.Windows.Forms.Button();
            this.button34 = new System.Windows.Forms.Button();
            this.lbSendedData = new System.Windows.Forms.Label();
            this.btnDelSubscript = new System.Windows.Forms.Button();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.btnGetCSED = new System.Windows.Forms.Button();
            this.btnGetDeviceCSR = new System.Windows.Forms.Button();
            this.btnCreateDeviceCSR = new System.Windows.Forms.Button();
            this.btnDelDeviceCSR = new System.Windows.Forms.Button();
            this.btnDeviceUpdateCSR = new System.Windows.Forms.Button();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.tbOneM2MDataIN = new System.Windows.Forms.TextBox();
            this.gbOneM2MDevice = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button114 = new System.Windows.Forms.Button();
            this.button112 = new System.Windows.Forms.Button();
            this.button111 = new System.Windows.Forms.Button();
            this.button110 = new System.Windows.Forms.Button();
            this.button109 = new System.Windows.Forms.Button();
            this.button106 = new System.Windows.Forms.Button();
            this.btnMEFAuthD = new System.Windows.Forms.Button();
            this.btnoneM2MFullTest = new System.Windows.Forms.Button();
            this.tabLwM2M = new System.Windows.Forms.TabPage();
            this.groupBox22 = new System.Windows.Forms.GroupBox();
            this.label39 = new System.Windows.Forms.Label();
            this.textBox70 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox65 = new System.Windows.Forms.TextBox();
            this.textBox71 = new System.Windows.Forms.TextBox();
            this.button35 = new System.Windows.Forms.Button();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.tbLwM2MDataIN = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tBoxDeviceVer = new System.Windows.Forms.TextBox();
            this.button113 = new System.Windows.Forms.Button();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.label43 = new System.Windows.Forms.Label();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.label42 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.textBox75 = new System.Windows.Forms.TextBox();
            this.textBox74 = new System.Windows.Forms.TextBox();
            this.textBox63 = new System.Windows.Forms.TextBox();
            this.textBox69 = new System.Windows.Forms.TextBox();
            this.button108 = new System.Windows.Forms.Button();
            this.lbLwM2MRcvData = new System.Windows.Forms.Label();
            this.textBox68 = new System.Windows.Forms.TextBox();
            this.lbDevLwM2MData = new System.Windows.Forms.Label();
            this.button107 = new System.Windows.Forms.Button();
            this.textBox67 = new System.Windows.Forms.TextBox();
            this.btnBootstrap = new System.Windows.Forms.Button();
            this.textBox66 = new System.Windows.Forms.TextBox();
            this.button105 = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.textBox52 = new System.Windows.Forms.TextBox();
            this.textBox50 = new System.Windows.Forms.TextBox();
            this.btnDeregister = new System.Windows.Forms.Button();
            this.button92 = new System.Windows.Forms.Button();
            this.textBox51 = new System.Windows.Forms.TextBox();
            this.btnDeviceVerLwM2M = new System.Windows.Forms.Button();
            this.textBox53 = new System.Windows.Forms.TextBox();
            this.button95 = new System.Windows.Forms.Button();
            this.textBox54 = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.textBox55 = new System.Windows.Forms.TextBox();
            this.textBox56 = new System.Windows.Forms.TextBox();
            this.button97 = new System.Windows.Forms.Button();
            this.button98 = new System.Windows.Forms.Button();
            this.button125 = new System.Windows.Forms.Button();
            this.tabServer = new System.Windows.Forms.TabPage();
            this.label23 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.label40 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbDevEntityId = new System.Windows.Forms.Label();
            this.button93 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.lbLwM2MRxData = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.btnDeviceStatusCheck = new System.Windows.Forms.Button();
            this.label36 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnLwM2MData = new System.Windows.Forms.Button();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lbDirectRxData = new System.Windows.Forms.Label();
            this.lboneM2MRxData = new System.Windows.Forms.Label();
            this.btnDataRetrive = new System.Windows.Forms.Button();
            this.button94 = new System.Windows.Forms.Button();
            this.button96 = new System.Windows.Forms.Button();
            this.lbmodemfwrver = new System.Windows.Forms.Label();
            this.btnDeviceCheck = new System.Windows.Forms.Button();
            this.lbdevicever = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSendData = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.tbSeverPort = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbSeverIP = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.btnDelRemoteCSE = new System.Windows.Forms.Button();
            this.btnSetRemoteCSE = new System.Windows.Forms.Button();
            this.btnGetRemoteCSE = new System.Windows.Forms.Button();
            this.btnMEFAuth = new System.Windows.Forms.Button();
            this.tbSvcCd = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.tbSvcSvrCd = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.tbSvcSvrNum = new System.Windows.Forms.TextBox();
            this.tabLOG = new System.Windows.Forms.TabPage();
            this.label49 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.button127 = new System.Windows.Forms.Button();
            this.label27 = new System.Windows.Forms.Label();
            this.tBResultCode = new System.Windows.Forms.TextBox();
            this.button126 = new System.Windows.Forms.Button();
            this.button122 = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.textBox94 = new System.Windows.Forms.TextBox();
            this.tbDeviceCTN = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.button123 = new System.Windows.Forms.Button();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox95 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnGetLogList = new System.Windows.Forms.Button();
            this.button124 = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tabTC = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listView2 = new System.Windows.Forms.ListView();
            this.listView1 = new System.Windows.Forms.ListView();
            this.gbTCResult = new System.Windows.Forms.GroupBox();
            this.tbTCResult = new System.Windows.Forms.TextBox();
            this.webpage = new System.Windows.Forms.TabPage();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.button81 = new System.Windows.Forms.Button();
            this.button72 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lbActionState = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.tBoxDeviceSN = new System.Windows.Forms.TextBox();
            this.tBoxDeviceModel = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabCOM.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.gbDeviceLog.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.tabSMST.SuspendLayout();
            this.pnSetting.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPROXY.SuspendLayout();
            this.pnProxy.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabOneM2M.SuspendLayout();
            this.groupBox21.SuspendLayout();
            this.groupBox20.SuspendLayout();
            this.groupBox19.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.gbOneM2MDevice.SuspendLayout();
            this.tabLwM2M.SuspendLayout();
            this.groupBox22.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.tabServer.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.tabLOG.SuspendLayout();
            this.tabTC.SuspendLayout();
            this.gbTCResult.SuspendLayout();
            this.webpage.SuspendLayout();
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
            this.cBoxBaudRate.Location = new System.Drawing.Point(186, 797);
            this.cBoxBaudRate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cBoxBaudRate.Name = "cBoxBaudRate";
            this.cBoxBaudRate.Size = new System.Drawing.Size(93, 20);
            this.cBoxBaudRate.TabIndex = 2;
            this.cBoxBaudRate.Text = "115200";
            // 
            // cBoxCOMPORT
            // 
            this.cBoxCOMPORT.FormattingEnabled = true;
            this.cBoxCOMPORT.Items.AddRange(new object[] {
            "COM103"});
            this.cBoxCOMPORT.Location = new System.Drawing.Point(55, 797);
            this.cBoxCOMPORT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cBoxCOMPORT.Name = "cBoxCOMPORT";
            this.cBoxCOMPORT.Size = new System.Drawing.Size(108, 20);
            this.cBoxCOMPORT.TabIndex = 1;
            this.cBoxCOMPORT.Text = "COM103";
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.progressBar1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.progressBar1.Location = new System.Drawing.Point(9, 800);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(35, 18);
            this.progressBar1.TabIndex = 2;
            this.progressBar1.Click += new System.EventHandler(this.ProgressBar1_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPort1_DataReceived);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Controls.Add(this.button81);
            this.panel1.Controls.Add(this.button72);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lbActionState);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.cBoxBaudRate);
            this.panel1.Controls.Add(this.label34);
            this.panel1.Controls.Add(this.tBoxDeviceSN);
            this.panel1.Controls.Add(this.cBoxCOMPORT);
            this.panel1.Controls.Add(this.tBoxDeviceModel);
            this.panel1.Controls.Add(this.label32);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1133, 829);
            this.panel1.TabIndex = 10;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabCOM);
            this.tabControl1.Controls.Add(this.tabSMST);
            this.tabControl1.Controls.Add(this.tabPROXY);
            this.tabControl1.Controls.Add(this.tabOneM2M);
            this.tabControl1.Controls.Add(this.tabLwM2M);
            this.tabControl1.Controls.Add(this.tabServer);
            this.tabControl1.Controls.Add(this.tabLOG);
            this.tabControl1.Controls.Add(this.tabTC);
            this.tabControl1.Controls.Add(this.webpage);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1133, 791);
            this.tabControl1.TabIndex = 44;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabCOM
            // 
            this.tabCOM.Controls.Add(this.button63);
            this.tabCOM.Controls.Add(this.textBox64);
            this.tabCOM.Controls.Add(this.groupBox9);
            this.tabCOM.Controls.Add(this.gbDeviceLog);
            this.tabCOM.Controls.Add(this.groupBox10);
            this.tabCOM.Location = new System.Drawing.Point(4, 22);
            this.tabCOM.Name = "tabCOM";
            this.tabCOM.Size = new System.Drawing.Size(1125, 765);
            this.tabCOM.TabIndex = 3;
            this.tabCOM.Text = "COM port";
            this.tabCOM.UseVisualStyleBackColor = true;
            // 
            // button63
            // 
            this.button63.Location = new System.Drawing.Point(24, 518);
            this.button63.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button63.Name = "button63";
            this.button63.Size = new System.Drawing.Size(147, 24);
            this.button63.TabIndex = 69;
            this.button63.Text = "ATCMD 전송";
            this.button63.UseVisualStyleBackColor = true;
            this.button63.Click += new System.EventHandler(this.button63_Click_1);
            // 
            // textBox64
            // 
            this.textBox64.Location = new System.Drawing.Point(174, 518);
            this.textBox64.Name = "textBox64";
            this.textBox64.Size = new System.Drawing.Size(310, 21);
            this.textBox64.TabIndex = 68;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.button86);
            this.groupBox9.Controls.Add(this.textBox24);
            this.groupBox9.Controls.Add(this.button99);
            this.groupBox9.Controls.Add(this.textBox58);
            this.groupBox9.Controls.Add(this.button100);
            this.groupBox9.Controls.Add(this.textBox59);
            this.groupBox9.Controls.Add(this.button101);
            this.groupBox9.Controls.Add(this.textBox60);
            this.groupBox9.Controls.Add(this.textBox61);
            this.groupBox9.Controls.Add(this.button62);
            this.groupBox9.Location = new System.Drawing.Point(24, 569);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(490, 177);
            this.groupBox9.TabIndex = 59;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "NW CONTROL";
            // 
            // button86
            // 
            this.button86.Location = new System.Drawing.Point(6, 19);
            this.button86.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button86.Name = "button86";
            this.button86.Size = new System.Drawing.Size(147, 24);
            this.button86.TabIndex = 48;
            this.button86.Text = "DATA REBOOT";
            this.button86.UseVisualStyleBackColor = true;
            this.button86.Click += new System.EventHandler(this.button86_Click);
            // 
            // textBox24
            // 
            this.textBox24.Location = new System.Drawing.Point(157, 19);
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new System.Drawing.Size(252, 21);
            this.textBox24.TabIndex = 49;
            this.textBox24.Text = "AT+NRB";
            // 
            // button99
            // 
            this.button99.Location = new System.Drawing.Point(5, 113);
            this.button99.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button99.Name = "button99";
            this.button99.Size = new System.Drawing.Size(147, 24);
            this.button99.TabIndex = 54;
            this.button99.Text = "NW ATTACH";
            this.button99.UseVisualStyleBackColor = true;
            this.button99.Click += new System.EventHandler(this.button99_Click);
            // 
            // textBox58
            // 
            this.textBox58.Location = new System.Drawing.Point(156, 113);
            this.textBox58.Name = "textBox58";
            this.textBox58.Size = new System.Drawing.Size(252, 21);
            this.textBox58.TabIndex = 55;
            this.textBox58.Text = "AT+CEREG=3";
            // 
            // button100
            // 
            this.button100.Location = new System.Drawing.Point(6, 47);
            this.button100.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button100.Name = "button100";
            this.button100.Size = new System.Drawing.Size(147, 24);
            this.button100.TabIndex = 56;
            this.button100.Text = "DATA CONNECT";
            this.button100.UseVisualStyleBackColor = true;
            this.button100.Click += new System.EventHandler(this.button100_Click);
            // 
            // textBox59
            // 
            this.textBox59.Location = new System.Drawing.Point(157, 47);
            this.textBox59.Name = "textBox59";
            this.textBox59.Size = new System.Drawing.Size(252, 21);
            this.textBox59.TabIndex = 57;
            this.textBox59.Text = "AT+CFUN=1";
            // 
            // button101
            // 
            this.button101.Location = new System.Drawing.Point(6, 75);
            this.button101.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button101.Name = "button101";
            this.button101.Size = new System.Drawing.Size(147, 24);
            this.button101.TabIndex = 58;
            this.button101.Text = "DATA DISCONNECT";
            this.button101.UseVisualStyleBackColor = true;
            this.button101.Click += new System.EventHandler(this.button101_Click);
            // 
            // textBox60
            // 
            this.textBox60.Location = new System.Drawing.Point(157, 75);
            this.textBox60.Name = "textBox60";
            this.textBox60.Size = new System.Drawing.Size(252, 21);
            this.textBox60.TabIndex = 59;
            this.textBox60.Text = "AT+CFUN=0";
            // 
            // textBox61
            // 
            this.textBox61.Location = new System.Drawing.Point(157, 141);
            this.textBox61.Name = "textBox61";
            this.textBox61.Size = new System.Drawing.Size(252, 21);
            this.textBox61.TabIndex = 61;
            this.textBox61.Text = "AT+CEREG?";
            // 
            // button62
            // 
            this.button62.Location = new System.Drawing.Point(6, 141);
            this.button62.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button62.Name = "button62";
            this.button62.Size = new System.Drawing.Size(147, 24);
            this.button62.TabIndex = 60;
            this.button62.Text = "NW STATUS";
            this.button62.UseVisualStyleBackColor = true;
            this.button62.Click += new System.EventHandler(this.button62_Click_1);
            // 
            // gbDeviceLog
            // 
            this.gbDeviceLog.Controls.Add(this.tBoxDataIN);
            this.gbDeviceLog.Location = new System.Drawing.Point(532, 18);
            this.gbDeviceLog.Name = "gbDeviceLog";
            this.gbDeviceLog.Size = new System.Drawing.Size(582, 728);
            this.gbDeviceLog.TabIndex = 44;
            this.gbDeviceLog.TabStop = false;
            this.gbDeviceLog.Text = "Device Message";
            // 
            // tBoxDataIN
            // 
            this.tBoxDataIN.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tBoxDataIN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tBoxDataIN.Location = new System.Drawing.Point(3, 17);
            this.tBoxDataIN.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tBoxDataIN.Multiline = true;
            this.tBoxDataIN.Name = "tBoxDataIN";
            this.tBoxDataIN.ReadOnly = true;
            this.tBoxDataIN.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tBoxDataIN.Size = new System.Drawing.Size(576, 708);
            this.tBoxDataIN.TabIndex = 22;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.label47);
            this.groupBox10.Controls.Add(this.label46);
            this.groupBox10.Controls.Add(this.label45);
            this.groupBox10.Controls.Add(this.label44);
            this.groupBox10.Controls.Add(this.lbModemVer);
            this.groupBox10.Controls.Add(this.textBox89);
            this.groupBox10.Controls.Add(this.lbIccid);
            this.groupBox10.Controls.Add(this.textBox87);
            this.groupBox10.Controls.Add(this.textBox86);
            this.groupBox10.Controls.Add(this.button87);
            this.groupBox10.Controls.Add(this.textBox85);
            this.groupBox10.Controls.Add(this.textBox57);
            this.groupBox10.Controls.Add(this.textBox40);
            this.groupBox10.Controls.Add(this.textBox38);
            this.groupBox10.Controls.Add(this.textBox33);
            this.groupBox10.Controls.Add(this.button71);
            this.groupBox10.Controls.Add(this.button83);
            this.groupBox10.Controls.Add(this.textBox44);
            this.groupBox10.Controls.Add(this.button88);
            this.groupBox10.Controls.Add(this.textBox45);
            this.groupBox10.Controls.Add(this.textBox46);
            this.groupBox10.Controls.Add(this.textBox47);
            this.groupBox10.Controls.Add(this.textBox48);
            this.groupBox10.Controls.Add(this.textBox49);
            this.groupBox10.Controls.Add(this.button89);
            this.groupBox10.Controls.Add(this.button90);
            this.groupBox10.Controls.Add(this.button91);
            this.groupBox10.Location = new System.Drawing.Point(24, 18);
            this.groupBox10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox10.Size = new System.Drawing.Size(490, 351);
            this.groupBox10.TabIndex = 40;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Device 정보";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(54, 290);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(97, 12);
            this.label47.TabIndex = 71;
            this.label47.Text = "버전 응답 메시지";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(56, 236);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(98, 12);
            this.label46.TabIndex = 70;
            this.label46.Text = "IMEI 응답 메시지";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(47, 178);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(105, 12);
            this.label45.TabIndex = 69;
            this.label45.Text = "ICCID 응답 메시지";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(55, 122);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(98, 12);
            this.label44.TabIndex = 68;
            this.label44.Text = "IMSI 응답 메시지";
            // 
            // lbModemVer
            // 
            this.lbModemVer.Location = new System.Drawing.Point(277, 262);
            this.lbModemVer.Name = "lbModemVer";
            this.lbModemVer.Size = new System.Drawing.Size(190, 21);
            this.lbModemVer.TabIndex = 67;
            // 
            // textBox89
            // 
            this.textBox89.Location = new System.Drawing.Point(277, 206);
            this.textBox89.Name = "textBox89";
            this.textBox89.Size = new System.Drawing.Size(190, 21);
            this.textBox89.TabIndex = 66;
            // 
            // lbIccid
            // 
            this.lbIccid.Location = new System.Drawing.Point(277, 150);
            this.lbIccid.Name = "lbIccid";
            this.lbIccid.Size = new System.Drawing.Size(190, 21);
            this.lbIccid.TabIndex = 65;
            // 
            // textBox87
            // 
            this.textBox87.Location = new System.Drawing.Point(277, 93);
            this.textBox87.Name = "textBox87";
            this.textBox87.Size = new System.Drawing.Size(190, 21);
            this.textBox87.TabIndex = 64;
            // 
            // textBox86
            // 
            this.textBox86.Location = new System.Drawing.Point(277, 65);
            this.textBox86.Name = "textBox86";
            this.textBox86.Size = new System.Drawing.Size(190, 21);
            this.textBox86.TabIndex = 63;
            // 
            // button87
            // 
            this.button87.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button87.Location = new System.Drawing.Point(132, 316);
            this.button87.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button87.Name = "button87";
            this.button87.Size = new System.Drawing.Size(156, 24);
            this.button87.TabIndex = 43;
            this.button87.Text = "단말 정보 조회";
            this.button87.UseVisualStyleBackColor = true;
            this.button87.Click += new System.EventHandler(this.button87_Click);
            // 
            // textBox85
            // 
            this.textBox85.Location = new System.Drawing.Point(277, 36);
            this.textBox85.Name = "textBox85";
            this.textBox85.Size = new System.Drawing.Size(190, 21);
            this.textBox85.TabIndex = 62;
            // 
            // textBox57
            // 
            this.textBox57.Location = new System.Drawing.Point(158, 287);
            this.textBox57.Name = "textBox57";
            this.textBox57.Size = new System.Drawing.Size(114, 21);
            this.textBox57.TabIndex = 53;
            // 
            // textBox40
            // 
            this.textBox40.Location = new System.Drawing.Point(158, 233);
            this.textBox40.Name = "textBox40";
            this.textBox40.Size = new System.Drawing.Size(114, 21);
            this.textBox40.TabIndex = 52;
            this.textBox40.Text = "+CGSN:";
            // 
            // textBox38
            // 
            this.textBox38.Location = new System.Drawing.Point(158, 175);
            this.textBox38.Name = "textBox38";
            this.textBox38.Size = new System.Drawing.Size(114, 21);
            this.textBox38.TabIndex = 51;
            this.textBox38.Text = "+MUICCID:";
            // 
            // textBox33
            // 
            this.textBox33.Location = new System.Drawing.Point(158, 119);
            this.textBox33.Name = "textBox33";
            this.textBox33.Size = new System.Drawing.Size(114, 21);
            this.textBox33.TabIndex = 50;
            // 
            // button71
            // 
            this.button71.Location = new System.Drawing.Point(7, 148);
            this.button71.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button71.Name = "button71";
            this.button71.Size = new System.Drawing.Size(147, 24);
            this.button71.TabIndex = 40;
            this.button71.Text = "ICCID";
            this.button71.UseVisualStyleBackColor = true;
            this.button71.Click += new System.EventHandler(this.button71_Click);
            // 
            // button83
            // 
            this.button83.Location = new System.Drawing.Point(7, 33);
            this.button83.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button83.Name = "button83";
            this.button83.Size = new System.Drawing.Size(147, 24);
            this.button83.TabIndex = 39;
            this.button83.Text = "제조사";
            this.button83.UseVisualStyleBackColor = true;
            this.button83.Click += new System.EventHandler(this.button83_Click);
            // 
            // textBox44
            // 
            this.textBox44.Location = new System.Drawing.Point(158, 260);
            this.textBox44.Name = "textBox44";
            this.textBox44.Size = new System.Drawing.Size(114, 21);
            this.textBox44.TabIndex = 22;
            this.textBox44.Text = "AT+CGMR";
            // 
            // button88
            // 
            this.button88.Location = new System.Drawing.Point(7, 260);
            this.button88.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button88.Name = "button88";
            this.button88.Size = new System.Drawing.Size(147, 24);
            this.button88.TabIndex = 21;
            this.button88.Text = "FW VERSION";
            this.button88.UseVisualStyleBackColor = true;
            this.button88.Click += new System.EventHandler(this.button88_Click);
            // 
            // textBox45
            // 
            this.textBox45.Location = new System.Drawing.Point(157, 148);
            this.textBox45.Name = "textBox45";
            this.textBox45.Size = new System.Drawing.Size(114, 21);
            this.textBox45.TabIndex = 20;
            this.textBox45.Text = "AT+MUICCID";
            // 
            // textBox46
            // 
            this.textBox46.Location = new System.Drawing.Point(158, 91);
            this.textBox46.Name = "textBox46";
            this.textBox46.Size = new System.Drawing.Size(114, 21);
            this.textBox46.TabIndex = 19;
            this.textBox46.Text = "AT+CIMI";
            // 
            // textBox47
            // 
            this.textBox47.Location = new System.Drawing.Point(157, 63);
            this.textBox47.Name = "textBox47";
            this.textBox47.Size = new System.Drawing.Size(114, 21);
            this.textBox47.TabIndex = 18;
            this.textBox47.Text = "AT+CGMM";
            // 
            // textBox48
            // 
            this.textBox48.Location = new System.Drawing.Point(157, 33);
            this.textBox48.Name = "textBox48";
            this.textBox48.Size = new System.Drawing.Size(114, 21);
            this.textBox48.TabIndex = 17;
            this.textBox48.Text = "AT+CGMI";
            // 
            // textBox49
            // 
            this.textBox49.Location = new System.Drawing.Point(158, 204);
            this.textBox49.Name = "textBox49";
            this.textBox49.Size = new System.Drawing.Size(114, 21);
            this.textBox49.TabIndex = 15;
            this.textBox49.Text = "AT+CGSN=1";
            // 
            // button89
            // 
            this.button89.Location = new System.Drawing.Point(7, 204);
            this.button89.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button89.Name = "button89";
            this.button89.Size = new System.Drawing.Size(147, 24);
            this.button89.TabIndex = 14;
            this.button89.Text = "IMEI";
            this.button89.UseVisualStyleBackColor = true;
            this.button89.Click += new System.EventHandler(this.button89_Click);
            // 
            // button90
            // 
            this.button90.Location = new System.Drawing.Point(7, 91);
            this.button90.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button90.Name = "button90";
            this.button90.Size = new System.Drawing.Size(147, 24);
            this.button90.TabIndex = 10;
            this.button90.Text = "IMSI";
            this.button90.UseVisualStyleBackColor = true;
            this.button90.Click += new System.EventHandler(this.button90_Click);
            // 
            // button91
            // 
            this.button91.Location = new System.Drawing.Point(6, 63);
            this.button91.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button91.Name = "button91";
            this.button91.Size = new System.Drawing.Size(147, 24);
            this.button91.TabIndex = 8;
            this.button91.Text = "모델";
            this.button91.UseVisualStyleBackColor = true;
            this.button91.Click += new System.EventHandler(this.button91_Click);
            // 
            // tabSMST
            // 
            this.tabSMST.Controls.Add(this.pnSetting);
            this.tabSMST.Location = new System.Drawing.Point(4, 22);
            this.tabSMST.Name = "tabSMST";
            this.tabSMST.Padding = new System.Windows.Forms.Padding(3);
            this.tabSMST.Size = new System.Drawing.Size(1125, 765);
            this.tabSMST.TabIndex = 0;
            this.tabSMST.Text = "SMST setting";
            this.tabSMST.UseVisualStyleBackColor = true;
            // 
            // pnSetting
            // 
            this.pnSetting.Controls.Add(this.button68);
            this.pnSetting.Controls.Add(this.button33);
            this.pnSetting.Controls.Add(this.button32);
            this.pnSetting.Controls.Add(this.button31);
            this.pnSetting.Controls.Add(this.button24);
            this.pnSetting.Controls.Add(this.button23);
            this.pnSetting.Controls.Add(this.groupBox6);
            this.pnSetting.Controls.Add(this.groupBox5);
            this.pnSetting.Controls.Add(this.groupBox2);
            this.pnSetting.Controls.Add(this.groupBox1);
            this.pnSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnSetting.Location = new System.Drawing.Point(3, 3);
            this.pnSetting.Name = "pnSetting";
            this.pnSetting.Size = new System.Drawing.Size(1119, 759);
            this.pnSetting.TabIndex = 13;
            // 
            // button68
            // 
            this.button68.Location = new System.Drawing.Point(581, 16);
            this.button68.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button68.Name = "button68";
            this.button68.Size = new System.Drawing.Size(167, 24);
            this.button68.TabIndex = 32;
            this.button68.Text = "IMS";
            this.button68.UseVisualStyleBackColor = true;
            this.button68.Click += new System.EventHandler(this.button68_Click);
            // 
            // button33
            // 
            this.button33.Location = new System.Drawing.Point(209, 16);
            this.button33.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button33.Name = "button33";
            this.button33.Size = new System.Drawing.Size(167, 24);
            this.button33.TabIndex = 31;
            this.button33.Text = "Cat M1";
            this.button33.UseVisualStyleBackColor = true;
            this.button33.Click += new System.EventHandler(this.button33_Click);
            // 
            // button32
            // 
            this.button32.Location = new System.Drawing.Point(396, 16);
            this.button32.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button32.Name = "button32";
            this.button32.Size = new System.Drawing.Size(167, 24);
            this.button32.TabIndex = 30;
            this.button32.Text = "NB IoT";
            this.button32.UseVisualStyleBackColor = true;
            this.button32.Click += new System.EventHandler(this.button32_Click);
            // 
            // button31
            // 
            this.button31.Location = new System.Drawing.Point(25, 16);
            this.button31.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button31.Name = "button31";
            this.button31.Size = new System.Drawing.Size(167, 24);
            this.button31.TabIndex = 29;
            this.button31.Text = "LTE";
            this.button31.UseVisualStyleBackColor = true;
            this.button31.Click += new System.EventHandler(this.button31_Click);
            // 
            // button24
            // 
            this.button24.Location = new System.Drawing.Point(442, 566);
            this.button24.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(167, 24);
            this.button24.TabIndex = 28;
            this.button24.Text = "파일 읽기";
            this.button24.UseVisualStyleBackColor = true;
            this.button24.Click += new System.EventHandler(this.button24_Click);
            // 
            // button23
            // 
            this.button23.Location = new System.Drawing.Point(637, 566);
            this.button23.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(167, 24);
            this.button23.TabIndex = 27;
            this.button23.Text = "파일 쓰기";
            this.button23.UseVisualStyleBackColor = true;
            this.button23.Click += new System.EventHandler(this.button23_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cbNBIPVer);
            this.groupBox6.Controls.Add(this.button36);
            this.groupBox6.Location = new System.Drawing.Point(438, 463);
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
            this.groupBox5.Size = new System.Drawing.Size(419, 247);
            this.groupBox5.TabIndex = 25;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "VoLTE/SMS";
            // 
            // tbDeviceType
            // 
            this.tbDeviceType.Location = new System.Drawing.Point(215, 72);
            this.tbDeviceType.Name = "tbDeviceType";
            this.tbDeviceType.Size = new System.Drawing.Size(197, 21);
            this.tbDeviceType.TabIndex = 28;
            this.tbDeviceType.Text = "modem";
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
            this.tbTTAVer.Size = new System.Drawing.Size(197, 21);
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
            this.tbDeviceVer.Size = new System.Drawing.Size(197, 21);
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
            this.tbDeviceName.Size = new System.Drawing.Size(197, 21);
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
            this.groupBox2.Location = new System.Drawing.Point(438, 50);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(368, 387);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Capability";
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
            this.groupBox1.Size = new System.Drawing.Size(420, 305);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "COMMON";
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
            // cbImsPDN
            // 
            this.cbImsPDN.FormattingEnabled = true;
            this.cbImsPDN.Items.AddRange(new object[] {
            "미지원",
            "1번째",
            "2번째"});
            this.cbImsPDN.Location = new System.Drawing.Point(216, 15);
            this.cbImsPDN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbImsPDN.Name = "cbImsPDN";
            this.cbImsPDN.Size = new System.Drawing.Size(197, 20);
            this.cbImsPDN.TabIndex = 30;
            this.cbImsPDN.Text = "1번째";
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
            this.cbImsIP.Size = new System.Drawing.Size(197, 20);
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
            this.tbIMEI.Size = new System.Drawing.Size(197, 21);
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
            this.tbChannel3.Size = new System.Drawing.Size(197, 21);
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
            this.tbChannel2.Size = new System.Drawing.Size(197, 21);
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
            this.tbChannel1.Size = new System.Drawing.Size(197, 21);
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
            // tabPROXY
            // 
            this.tabPROXY.Controls.Add(this.pnProxy);
            this.tabPROXY.Location = new System.Drawing.Point(4, 22);
            this.tabPROXY.Name = "tabPROXY";
            this.tabPROXY.Padding = new System.Windows.Forms.Padding(3);
            this.tabPROXY.Size = new System.Drawing.Size(1125, 765);
            this.tabPROXY.TabIndex = 1;
            this.tabPROXY.Text = "PROXY setting";
            this.tabPROXY.UseVisualStyleBackColor = true;
            // 
            // pnProxy
            // 
            this.pnProxy.Controls.Add(this.groupBox8);
            this.pnProxy.Controls.Add(this.comboBox3);
            this.pnProxy.Controls.Add(this.button73);
            this.pnProxy.Controls.Add(this.groupBox7);
            this.pnProxy.Controls.Add(this.groupBox4);
            this.pnProxy.Controls.Add(this.groupBox3);
            this.pnProxy.Controls.Add(this.button40);
            this.pnProxy.Controls.Add(this.button41);
            this.pnProxy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnProxy.Location = new System.Drawing.Point(3, 3);
            this.pnProxy.Name = "pnProxy";
            this.pnProxy.Size = new System.Drawing.Size(1119, 759);
            this.pnProxy.TabIndex = 34;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.button44);
            this.groupBox8.Controls.Add(this.textBox2);
            this.groupBox8.Controls.Add(this.textBox3);
            this.groupBox8.Location = new System.Drawing.Point(547, 307);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(513, 87);
            this.groupBox8.TabIndex = 43;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "AT COMMAND (ID=2)";
            // 
            // button44
            // 
            this.button44.Location = new System.Drawing.Point(8, 24);
            this.button44.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button44.Name = "button44";
            this.button44.Size = new System.Drawing.Size(196, 24);
            this.button44.TabIndex = 0;
            this.button44.Text = "ATD123456789;<CR><LF>";
            this.button44.UseVisualStyleBackColor = true;
            this.button44.Click += new System.EventHandler(this.button44_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(210, 27);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(291, 21);
            this.textBox2.TabIndex = 16;
            this.textBox2.Text = "at+cmec=2";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(210, 56);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(291, 21);
            this.textBox3.TabIndex = 17;
            this.textBox3.Text = "at+ckpd=\"123456789s\"";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "자동",
            "수동"});
            this.comboBox3.Location = new System.Drawing.Point(230, 22);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(99, 20);
            this.comboBox3.TabIndex = 30;
            this.comboBox3.Text = "자동";
            // 
            // button73
            // 
            this.button73.Location = new System.Drawing.Point(20, 19);
            this.button73.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button73.Name = "button73";
            this.button73.Size = new System.Drawing.Size(196, 24);
            this.button73.TabIndex = 0;
            this.button73.Text = "AT command 전송";
            this.button73.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.button61);
            this.groupBox7.Controls.Add(this.textBox25);
            this.groupBox7.Controls.Add(this.button64);
            this.groupBox7.Controls.Add(this.textBox26);
            this.groupBox7.Controls.Add(this.button65);
            this.groupBox7.Controls.Add(this.textBox27);
            this.groupBox7.Controls.Add(this.button66);
            this.groupBox7.Controls.Add(this.textBox28);
            this.groupBox7.Controls.Add(this.textBox29);
            this.groupBox7.Controls.Add(this.textBox30);
            this.groupBox7.Controls.Add(this.textBox31);
            this.groupBox7.Controls.Add(this.textBox32);
            this.groupBox7.Controls.Add(this.button67);
            this.groupBox7.Controls.Add(this.button74);
            this.groupBox7.Controls.Add(this.button75);
            this.groupBox7.Location = new System.Drawing.Point(547, 435);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox7.Size = new System.Drawing.Size(513, 253);
            this.groupBox7.TabIndex = 40;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "AT COMMAND (ID=4)";
            // 
            // button61
            // 
            this.button61.Location = new System.Drawing.Point(7, 14);
            this.button61.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button61.Name = "button61";
            this.button61.Size = new System.Drawing.Size(196, 24);
            this.button61.TabIndex = 39;
            this.button61.Text = "AT+CGACT=1,1";
            this.button61.UseVisualStyleBackColor = true;
            this.button61.Click += new System.EventHandler(this.button61_Click);
            // 
            // textBox25
            // 
            this.textBox25.Location = new System.Drawing.Point(208, 215);
            this.textBox25.Name = "textBox25";
            this.textBox25.Size = new System.Drawing.Size(291, 21);
            this.textBox25.TabIndex = 26;
            this.textBox25.Text = "AT+CPSMS=0";
            // 
            // button64
            // 
            this.button64.Location = new System.Drawing.Point(6, 212);
            this.button64.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button64.Name = "button64";
            this.button64.Size = new System.Drawing.Size(196, 24);
            this.button64.TabIndex = 25;
            this.button64.Text = "PSM Off";
            this.button64.UseVisualStyleBackColor = true;
            this.button64.Click += new System.EventHandler(this.button64_Click);
            // 
            // textBox26
            // 
            this.textBox26.Location = new System.Drawing.Point(208, 187);
            this.textBox26.Name = "textBox26";
            this.textBox26.Size = new System.Drawing.Size(291, 21);
            this.textBox26.TabIndex = 24;
            this.textBox26.Text = "AT+CPSMS=1,,,\"10000101\",\"00100010\"";
            // 
            // button65
            // 
            this.button65.Location = new System.Drawing.Point(6, 184);
            this.button65.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button65.Name = "button65";
            this.button65.Size = new System.Drawing.Size(196, 24);
            this.button65.TabIndex = 23;
            this.button65.Text = "PSM On";
            this.button65.UseVisualStyleBackColor = true;
            this.button65.Click += new System.EventHandler(this.button65_Click);
            // 
            // textBox27
            // 
            this.textBox27.Location = new System.Drawing.Point(208, 159);
            this.textBox27.Name = "textBox27";
            this.textBox27.Size = new System.Drawing.Size(291, 21);
            this.textBox27.TabIndex = 22;
            this.textBox27.Text = "at+cfun=1";
            // 
            // button66
            // 
            this.button66.Location = new System.Drawing.Point(6, 156);
            this.button66.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button66.Name = "button66";
            this.button66.Size = new System.Drawing.Size(196, 24);
            this.button66.TabIndex = 21;
            this.button66.Text = "at+cfun=1";
            this.button66.UseVisualStyleBackColor = true;
            this.button66.Click += new System.EventHandler(this.button66_Click);
            // 
            // textBox28
            // 
            this.textBox28.Location = new System.Drawing.Point(208, 99);
            this.textBox28.Name = "textBox28";
            this.textBox28.Size = new System.Drawing.Size(291, 21);
            this.textBox28.TabIndex = 20;
            this.textBox28.Text = "at+cops?";
            // 
            // textBox29
            // 
            this.textBox29.Location = new System.Drawing.Point(208, 74);
            this.textBox29.Name = "textBox29";
            this.textBox29.Size = new System.Drawing.Size(291, 21);
            this.textBox29.TabIndex = 19;
            this.textBox29.Text = "10000";
            // 
            // textBox30
            // 
            this.textBox30.Location = new System.Drawing.Point(208, 47);
            this.textBox30.Name = "textBox30";
            this.textBox30.Size = new System.Drawing.Size(291, 21);
            this.textBox30.TabIndex = 18;
            this.textBox30.Text = "AT+CGACT=1=0,2";
            // 
            // textBox31
            // 
            this.textBox31.Location = new System.Drawing.Point(208, 19);
            this.textBox31.Name = "textBox31";
            this.textBox31.Size = new System.Drawing.Size(291, 21);
            this.textBox31.TabIndex = 17;
            this.textBox31.Text = "AT+CGACT=1,2";
            // 
            // textBox32
            // 
            this.textBox32.Location = new System.Drawing.Point(208, 131);
            this.textBox32.Name = "textBox32";
            this.textBox32.Size = new System.Drawing.Size(291, 21);
            this.textBox32.TabIndex = 15;
            this.textBox32.Text = "at+cfun=0";
            // 
            // button67
            // 
            this.button67.Location = new System.Drawing.Point(6, 128);
            this.button67.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button67.Name = "button67";
            this.button67.Size = new System.Drawing.Size(196, 24);
            this.button67.TabIndex = 14;
            this.button67.Text = "at+cfun=0";
            this.button67.UseVisualStyleBackColor = true;
            this.button67.Click += new System.EventHandler(this.button67_Click);
            // 
            // button74
            // 
            this.button74.Location = new System.Drawing.Point(6, 71);
            this.button74.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button74.Name = "button74";
            this.button74.Size = new System.Drawing.Size(196, 24);
            this.button74.TabIndex = 10;
            this.button74.Text = "at+cops?";
            this.button74.UseVisualStyleBackColor = true;
            this.button74.Click += new System.EventHandler(this.button74_Click);
            // 
            // button75
            // 
            this.button75.Location = new System.Drawing.Point(6, 44);
            this.button75.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button75.Name = "button75";
            this.button75.Size = new System.Drawing.Size(196, 24);
            this.button75.TabIndex = 8;
            this.button75.Text = "AT+CGACT=1=0,1";
            this.button75.UseVisualStyleBackColor = true;
            this.button75.Click += new System.EventHandler(this.button75_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox23);
            this.groupBox4.Controls.Add(this.button69);
            this.groupBox4.Controls.Add(this.textBox34);
            this.groupBox4.Controls.Add(this.button76);
            this.groupBox4.Controls.Add(this.textBox35);
            this.groupBox4.Controls.Add(this.button77);
            this.groupBox4.Controls.Add(this.textBox36);
            this.groupBox4.Controls.Add(this.button78);
            this.groupBox4.Controls.Add(this.textBox37);
            this.groupBox4.Controls.Add(this.button79);
            this.groupBox4.Controls.Add(this.textBox39);
            this.groupBox4.Controls.Add(this.textBox41);
            this.groupBox4.Controls.Add(this.button82);
            this.groupBox4.Controls.Add(this.button84);
            this.groupBox4.Location = new System.Drawing.Point(547, 49);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Size = new System.Drawing.Size(513, 233);
            this.groupBox4.TabIndex = 36;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "AT COMMAND (ID=3) 2/2";
            // 
            // textBox23
            // 
            this.textBox23.Location = new System.Drawing.Point(210, 52);
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new System.Drawing.Size(291, 21);
            this.textBox23.TabIndex = 32;
            this.textBox23.Text = "AT+CFUN=1,1";
            // 
            // button69
            // 
            this.button69.Location = new System.Drawing.Point(8, 49);
            this.button69.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button69.Name = "button69";
            this.button69.Size = new System.Drawing.Size(196, 24);
            this.button69.TabIndex = 31;
            this.button69.Text = "Please reboot phone";
            this.button69.UseVisualStyleBackColor = true;
            this.button69.Click += new System.EventHandler(this.button69_Click);
            // 
            // textBox34
            // 
            this.textBox34.Location = new System.Drawing.Point(208, 202);
            this.textBox34.Name = "textBox34";
            this.textBox34.Size = new System.Drawing.Size(291, 21);
            this.textBox34.TabIndex = 30;
            this.textBox34.Text = "AT+CGACT=1,2";
            // 
            // button76
            // 
            this.button76.Location = new System.Drawing.Point(6, 199);
            this.button76.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button76.Name = "button76";
            this.button76.Size = new System.Drawing.Size(196, 24);
            this.button76.TabIndex = 29;
            this.button76.Text = "Activate Data PDN";
            this.button76.UseVisualStyleBackColor = true;
            this.button76.Click += new System.EventHandler(this.button76_Click);
            // 
            // textBox35
            // 
            this.textBox35.Location = new System.Drawing.Point(208, 170);
            this.textBox35.Name = "textBox35";
            this.textBox35.Size = new System.Drawing.Size(291, 21);
            this.textBox35.TabIndex = 28;
            this.textBox35.Text = "AT+CGACT=0,2";
            // 
            // button77
            // 
            this.button77.Location = new System.Drawing.Point(6, 167);
            this.button77.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button77.Name = "button77";
            this.button77.Size = new System.Drawing.Size(196, 24);
            this.button77.TabIndex = 27;
            this.button77.Text = "Deactivate Data PDN";
            this.button77.UseVisualStyleBackColor = true;
            this.button77.Click += new System.EventHandler(this.button77_Click);
            // 
            // textBox36
            // 
            this.textBox36.Location = new System.Drawing.Point(208, 139);
            this.textBox36.Name = "textBox36";
            this.textBox36.Size = new System.Drawing.Size(291, 21);
            this.textBox36.TabIndex = 26;
            this.textBox36.Text = "AT+CPSMS=0";
            // 
            // button78
            // 
            this.button78.Location = new System.Drawing.Point(6, 136);
            this.button78.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button78.Name = "button78";
            this.button78.Size = new System.Drawing.Size(196, 24);
            this.button78.TabIndex = 25;
            this.button78.Text = "Please PSM Off";
            this.button78.UseVisualStyleBackColor = true;
            this.button78.Click += new System.EventHandler(this.button78_Click);
            // 
            // textBox37
            // 
            this.textBox37.Location = new System.Drawing.Point(208, 111);
            this.textBox37.Name = "textBox37";
            this.textBox37.Size = new System.Drawing.Size(291, 21);
            this.textBox37.TabIndex = 24;
            this.textBox37.Text = "AT+CPSMS=1,,,\"10000101\",\"00100010\"";
            // 
            // button79
            // 
            this.button79.Location = new System.Drawing.Point(6, 108);
            this.button79.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button79.Name = "button79";
            this.button79.Size = new System.Drawing.Size(196, 24);
            this.button79.TabIndex = 23;
            this.button79.Text = "Please PSM On";
            this.button79.UseVisualStyleBackColor = true;
            this.button79.Click += new System.EventHandler(this.button79_Click);
            // 
            // textBox39
            // 
            this.textBox39.Location = new System.Drawing.Point(208, 77);
            this.textBox39.Name = "textBox39";
            this.textBox39.Size = new System.Drawing.Size(291, 21);
            this.textBox39.TabIndex = 20;
            this.textBox39.Text = "AT+CGACT=1,1";
            // 
            // textBox41
            // 
            this.textBox41.Location = new System.Drawing.Point(208, 22);
            this.textBox41.Name = "textBox41";
            this.textBox41.Size = new System.Drawing.Size(291, 21);
            this.textBox41.TabIndex = 18;
            this.textBox41.Text = "AT+CNEC=24";
            // 
            // button82
            // 
            this.button82.Location = new System.Drawing.Point(6, 77);
            this.button82.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button82.Name = "button82";
            this.button82.Size = new System.Drawing.Size(196, 24);
            this.button82.TabIndex = 12;
            this.button82.Text = "Please connect pdn";
            this.button82.UseVisualStyleBackColor = true;
            this.button82.Click += new System.EventHandler(this.button82_Click);
            // 
            // button84
            // 
            this.button84.Location = new System.Drawing.Point(6, 19);
            this.button84.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button84.Name = "button84";
            this.button84.Size = new System.Drawing.Size(196, 24);
            this.button84.TabIndex = 8;
            this.button84.Text = "Please set EMM/ESM cause";
            this.button84.UseVisualStyleBackColor = true;
            this.button84.Click += new System.EventHandler(this.button84_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button60);
            this.groupBox3.Controls.Add(this.textBox22);
            this.groupBox3.Controls.Add(this.button59);
            this.groupBox3.Controls.Add(this.textBox21);
            this.groupBox3.Controls.Add(this.button58);
            this.groupBox3.Controls.Add(this.textBox20);
            this.groupBox3.Controls.Add(this.button57);
            this.groupBox3.Controls.Add(this.textBox19);
            this.groupBox3.Controls.Add(this.button56);
            this.groupBox3.Controls.Add(this.textBox18);
            this.groupBox3.Controls.Add(this.button55);
            this.groupBox3.Controls.Add(this.textBox17);
            this.groupBox3.Controls.Add(this.button43);
            this.groupBox3.Controls.Add(this.textBox16);
            this.groupBox3.Controls.Add(this.textBox42);
            this.groupBox3.Controls.Add(this.button54);
            this.groupBox3.Controls.Add(this.textBox15);
            this.groupBox3.Controls.Add(this.textBox43);
            this.groupBox3.Controls.Add(this.button53);
            this.groupBox3.Controls.Add(this.textBox14);
            this.groupBox3.Controls.Add(this.button52);
            this.groupBox3.Controls.Add(this.textBox13);
            this.groupBox3.Controls.Add(this.button51);
            this.groupBox3.Controls.Add(this.textBox12);
            this.groupBox3.Controls.Add(this.button85);
            this.groupBox3.Controls.Add(this.button50);
            this.groupBox3.Controls.Add(this.textBox11);
            this.groupBox3.Controls.Add(this.button49);
            this.groupBox3.Controls.Add(this.textBox10);
            this.groupBox3.Controls.Add(this.button48);
            this.groupBox3.Controls.Add(this.textBox9);
            this.groupBox3.Controls.Add(this.button47);
            this.groupBox3.Controls.Add(this.textBox8);
            this.groupBox3.Controls.Add(this.button46);
            this.groupBox3.Controls.Add(this.textBox7);
            this.groupBox3.Controls.Add(this.button45);
            this.groupBox3.Controls.Add(this.textBox6);
            this.groupBox3.Controls.Add(this.textBox5);
            this.groupBox3.Controls.Add(this.textBox4);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.button37);
            this.groupBox3.Controls.Add(this.button38);
            this.groupBox3.Controls.Add(this.button39);
            this.groupBox3.Controls.Add(this.button42);
            this.groupBox3.Location = new System.Drawing.Point(20, 49);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(513, 657);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "AT COMMAND (ID=3) 1/2";
            // 
            // button60
            // 
            this.button60.Location = new System.Drawing.Point(11, 621);
            this.button60.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button60.Name = "button60";
            this.button60.Size = new System.Drawing.Size(196, 24);
            this.button60.TabIndex = 39;
            this.button60.Text = "Check PDN Address";
            this.button60.UseVisualStyleBackColor = true;
            this.button60.Click += new System.EventHandler(this.button60_Click);
            // 
            // textBox22
            // 
            this.textBox22.Location = new System.Drawing.Point(213, 567);
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new System.Drawing.Size(291, 21);
            this.textBox22.TabIndex = 52;
            this.textBox22.Text = "AT*VOICE*CEND";
            // 
            // button59
            // 
            this.button59.Location = new System.Drawing.Point(11, 564);
            this.button59.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button59.Name = "button59";
            this.button59.Size = new System.Drawing.Size(196, 24);
            this.button59.TabIndex = 51;
            this.button59.Text = "Try Call End";
            this.button59.UseVisualStyleBackColor = true;
            this.button59.Click += new System.EventHandler(this.button59_Click);
            // 
            // textBox21
            // 
            this.textBox21.Location = new System.Drawing.Point(213, 538);
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new System.Drawing.Size(291, 21);
            this.textBox21.TabIndex = 50;
            this.textBox21.Text = "ata";
            // 
            // button58
            // 
            this.button58.Location = new System.Drawing.Point(11, 535);
            this.button58.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button58.Name = "button58";
            this.button58.Size = new System.Drawing.Size(196, 24);
            this.button58.TabIndex = 49;
            this.button58.Text = "Try Call Answer";
            this.button58.UseVisualStyleBackColor = true;
            this.button58.Click += new System.EventHandler(this.button58_Click);
            // 
            // textBox20
            // 
            this.textBox20.Location = new System.Drawing.Point(212, 510);
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new System.Drawing.Size(291, 21);
            this.textBox20.TabIndex = 48;
            this.textBox20.Text = "AT*VOICE*ORI=01012345678";
            // 
            // button57
            // 
            this.button57.Location = new System.Drawing.Point(10, 507);
            this.button57.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button57.Name = "button57";
            this.button57.Size = new System.Drawing.Size(196, 24);
            this.button57.TabIndex = 47;
            this.button57.Text = "Try MO Voice Call";
            this.button57.UseVisualStyleBackColor = true;
            this.button57.Click += new System.EventHandler(this.button57_Click);
            // 
            // textBox19
            // 
            this.textBox19.Location = new System.Drawing.Point(213, 482);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(291, 21);
            this.textBox19.TabIndex = 46;
            this.textBox19.Text = "AT*VOICE*ORI=15447769";
            // 
            // button56
            // 
            this.button56.Location = new System.Drawing.Point(11, 479);
            this.button56.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button56.Name = "button56";
            this.button56.Size = new System.Drawing.Size(196, 24);
            this.button56.TabIndex = 45;
            this.button56.Text = "Try MO Voice Call(15447769)";
            this.button56.UseVisualStyleBackColor = true;
            this.button56.Click += new System.EventHandler(this.button56_Click);
            // 
            // textBox18
            // 
            this.textBox18.Location = new System.Drawing.Point(213, 454);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(291, 21);
            this.textBox18.TabIndex = 44;
            this.textBox18.Text = "AT*VOICE*ORI=0101234567";
            // 
            // button55
            // 
            this.button55.Location = new System.Drawing.Point(11, 451);
            this.button55.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button55.Name = "button55";
            this.button55.Size = new System.Drawing.Size(196, 24);
            this.button55.TabIndex = 43;
            this.button55.Text = "Please make voice call from UE";
            this.button55.UseVisualStyleBackColor = true;
            this.button55.Click += new System.EventHandler(this.button55_Click);
            // 
            // textBox17
            // 
            this.textBox17.Location = new System.Drawing.Point(213, 426);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(291, 21);
            this.textBox17.TabIndex = 42;
            this.textBox17.Text = "at+cfun=1,1";
            // 
            // button43
            // 
            this.button43.Location = new System.Drawing.Point(11, 423);
            this.button43.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button43.Name = "button43";
            this.button43.Size = new System.Drawing.Size(196, 24);
            this.button43.TabIndex = 41;
            this.button43.Text = "Please power off the UE";
            this.button43.UseVisualStyleBackColor = true;
            this.button43.Click += new System.EventHandler(this.button43_Click);
            // 
            // textBox16
            // 
            this.textBox16.Location = new System.Drawing.Point(213, 398);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(291, 21);
            this.textBox16.TabIndex = 40;
            this.textBox16.Text = "at+cfun=0";
            // 
            // textBox42
            // 
            this.textBox42.Location = new System.Drawing.Point(212, 626);
            this.textBox42.Name = "textBox42";
            this.textBox42.Size = new System.Drawing.Size(291, 21);
            this.textBox42.TabIndex = 17;
            this.textBox42.Text = "AT+CGPADDR";
            // 
            // button54
            // 
            this.button54.Location = new System.Drawing.Point(11, 395);
            this.button54.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button54.Name = "button54";
            this.button54.Size = new System.Drawing.Size(196, 24);
            this.button54.TabIndex = 39;
            this.button54.Text = "Switch off the phone";
            this.button54.UseVisualStyleBackColor = true;
            this.button54.Click += new System.EventHandler(this.button54_Click);
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(213, 370);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(291, 21);
            this.textBox15.TabIndex = 38;
            this.textBox15.Text = "AT*VOICE*ORI=125";
            // 
            // textBox43
            // 
            this.textBox43.Location = new System.Drawing.Point(213, 595);
            this.textBox43.Name = "textBox43";
            this.textBox43.Size = new System.Drawing.Size(291, 21);
            this.textBox43.TabIndex = 16;
            this.textBox43.Text = "AT*VOICE*CEND";
            // 
            // button53
            // 
            this.button53.Location = new System.Drawing.Point(11, 367);
            this.button53.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button53.Name = "button53";
            this.button53.Size = new System.Drawing.Size(196, 24);
            this.button53.TabIndex = 37;
            this.button53.Text = "Emergency call 125";
            this.button53.UseVisualStyleBackColor = true;
            this.button53.Click += new System.EventHandler(this.button53_Click);
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(213, 341);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(291, 21);
            this.textBox14.TabIndex = 36;
            this.textBox14.Text = "AT*VOICE*ORI=122";
            // 
            // button52
            // 
            this.button52.Location = new System.Drawing.Point(11, 338);
            this.button52.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button52.Name = "button52";
            this.button52.Size = new System.Drawing.Size(196, 24);
            this.button52.TabIndex = 35;
            this.button52.Text = "Emergency call 122";
            this.button52.UseVisualStyleBackColor = true;
            this.button52.Click += new System.EventHandler(this.button52_Click);
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(213, 312);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(291, 21);
            this.textBox13.TabIndex = 34;
            this.textBox13.Text = "AT*VOICE*ORI=119";
            // 
            // button51
            // 
            this.button51.Location = new System.Drawing.Point(11, 309);
            this.button51.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button51.Name = "button51";
            this.button51.Size = new System.Drawing.Size(196, 24);
            this.button51.TabIndex = 33;
            this.button51.Text = "Emergency call 119";
            this.button51.UseVisualStyleBackColor = true;
            this.button51.Click += new System.EventHandler(this.button51_Click);
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(212, 284);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(291, 21);
            this.textBox12.TabIndex = 32;
            this.textBox12.Text = "AT*VOICE*ORI=118";
            // 
            // button85
            // 
            this.button85.Location = new System.Drawing.Point(11, 592);
            this.button85.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button85.Name = "button85";
            this.button85.Size = new System.Drawing.Size(196, 24);
            this.button85.TabIndex = 0;
            this.button85.Text = "End voice call from the UE";
            this.button85.UseVisualStyleBackColor = true;
            this.button85.Click += new System.EventHandler(this.button85_Click);
            // 
            // button50
            // 
            this.button50.Location = new System.Drawing.Point(10, 281);
            this.button50.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button50.Name = "button50";
            this.button50.Size = new System.Drawing.Size(196, 24);
            this.button50.TabIndex = 31;
            this.button50.Text = "Emergency call 118";
            this.button50.UseVisualStyleBackColor = true;
            this.button50.Click += new System.EventHandler(this.button50_Click);
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(212, 256);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(291, 21);
            this.textBox11.TabIndex = 30;
            this.textBox11.Text = "ATD117";
            // 
            // button49
            // 
            this.button49.Location = new System.Drawing.Point(10, 253);
            this.button49.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button49.Name = "button49";
            this.button49.Size = new System.Drawing.Size(196, 24);
            this.button49.TabIndex = 29;
            this.button49.Text = "Emergency call 117";
            this.button49.UseVisualStyleBackColor = true;
            this.button49.Click += new System.EventHandler(this.button49_Click);
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(212, 224);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(291, 21);
            this.textBox10.TabIndex = 28;
            this.textBox10.Text = "AT*VOICE*ORI=113";
            // 
            // button48
            // 
            this.button48.Location = new System.Drawing.Point(10, 221);
            this.button48.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button48.Name = "button48";
            this.button48.Size = new System.Drawing.Size(196, 24);
            this.button48.TabIndex = 27;
            this.button48.Text = "Emergency call 113";
            this.button48.UseVisualStyleBackColor = true;
            this.button48.Click += new System.EventHandler(this.button48_Click);
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(212, 193);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(291, 21);
            this.textBox9.TabIndex = 26;
            this.textBox9.Text = "AT*VOICE*ORI=114";
            // 
            // button47
            // 
            this.button47.Location = new System.Drawing.Point(10, 190);
            this.button47.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button47.Name = "button47";
            this.button47.Size = new System.Drawing.Size(196, 24);
            this.button47.TabIndex = 25;
            this.button47.Text = "Normal call 114";
            this.button47.UseVisualStyleBackColor = true;
            this.button47.Click += new System.EventHandler(this.button47_Click);
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(212, 165);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(291, 21);
            this.textBox8.TabIndex = 24;
            this.textBox8.Text = "AT*VOICE*ORI=112";
            // 
            // button46
            // 
            this.button46.Location = new System.Drawing.Point(10, 162);
            this.button46.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button46.Name = "button46";
            this.button46.Size = new System.Drawing.Size(196, 24);
            this.button46.TabIndex = 23;
            this.button46.Text = "Emergency call 112";
            this.button46.UseVisualStyleBackColor = true;
            this.button46.Click += new System.EventHandler(this.button46_Click);
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(212, 137);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(291, 21);
            this.textBox7.TabIndex = 22;
            this.textBox7.Text = "AT*VOICE*ORI=111";
            // 
            // button45
            // 
            this.button45.Location = new System.Drawing.Point(10, 134);
            this.button45.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button45.Name = "button45";
            this.button45.Size = new System.Drawing.Size(196, 24);
            this.button45.TabIndex = 21;
            this.button45.Text = "Emergency call 111";
            this.button45.UseVisualStyleBackColor = true;
            this.button45.Click += new System.EventHandler(this.button45_Click);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(212, 77);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(291, 21);
            this.textBox6.TabIndex = 20;
            this.textBox6.Text = "at+cmms=0";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(212, 52);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(291, 21);
            this.textBox5.TabIndex = 19;
            this.textBox5.Text = "at+cfun=1,1";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(212, 25);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(291, 21);
            this.textBox4.TabIndex = 18;
            this.textBox4.Text = "AT+CGACT=0,1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(212, 109);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(291, 21);
            this.textBox1.TabIndex = 15;
            this.textBox1.Text = "AT*SMS*MO=01012345678,313233";
            // 
            // button37
            // 
            this.button37.Location = new System.Drawing.Point(10, 106);
            this.button37.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button37.Name = "button37";
            this.button37.Size = new System.Drawing.Size(196, 24);
            this.button37.TabIndex = 14;
            this.button37.Text = "Try MO SMS";
            this.button37.UseVisualStyleBackColor = true;
            this.button37.Click += new System.EventHandler(this.button37_Click);
            // 
            // button38
            // 
            this.button38.Location = new System.Drawing.Point(10, 77);
            this.button38.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button38.Name = "button38";
            this.button38.Size = new System.Drawing.Size(196, 24);
            this.button38.TabIndex = 12;
            this.button38.Text = "Activate SMS mode";
            this.button38.UseVisualStyleBackColor = true;
            this.button38.Click += new System.EventHandler(this.button38_Click);
            // 
            // button39
            // 
            this.button39.Location = new System.Drawing.Point(10, 49);
            this.button39.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button39.Name = "button39";
            this.button39.Size = new System.Drawing.Size(196, 24);
            this.button39.TabIndex = 10;
            this.button39.Text = "Switch on the phone";
            this.button39.UseVisualStyleBackColor = true;
            this.button39.Click += new System.EventHandler(this.button39_Click);
            // 
            // button42
            // 
            this.button42.Location = new System.Drawing.Point(10, 22);
            this.button42.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button42.Name = "button42";
            this.button42.Size = new System.Drawing.Size(196, 24);
            this.button42.TabIndex = 8;
            this.button42.Text = "Please disconnect pdn";
            this.button42.UseVisualStyleBackColor = true;
            this.button42.Click += new System.EventHandler(this.button42_Click);
            // 
            // button40
            // 
            this.button40.Location = new System.Drawing.Point(634, 692);
            this.button40.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button40.Name = "button40";
            this.button40.Size = new System.Drawing.Size(99, 24);
            this.button40.TabIndex = 28;
            this.button40.Text = "XML 파일 읽기";
            this.button40.UseVisualStyleBackColor = true;
            this.button40.Click += new System.EventHandler(this.button40_Click);
            // 
            // button41
            // 
            this.button41.Location = new System.Drawing.Point(792, 692);
            this.button41.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button41.Name = "button41";
            this.button41.Size = new System.Drawing.Size(111, 24);
            this.button41.TabIndex = 27;
            this.button41.Text = "XML 파일 쓰기";
            this.button41.UseVisualStyleBackColor = true;
            this.button41.Click += new System.EventHandler(this.button41_Click);
            // 
            // tabOneM2M
            // 
            this.tabOneM2M.Controls.Add(this.button117);
            this.tabOneM2M.Controls.Add(this.groupBox21);
            this.tabOneM2M.Controls.Add(this.groupBox20);
            this.tabOneM2M.Controls.Add(this.groupBox19);
            this.tabOneM2M.Controls.Add(this.groupBox18);
            this.tabOneM2M.Controls.Add(this.groupBox17);
            this.tabOneM2M.Controls.Add(this.gbOneM2MDevice);
            this.tabOneM2M.Controls.Add(this.btnoneM2MFullTest);
            this.tabOneM2M.Location = new System.Drawing.Point(4, 22);
            this.tabOneM2M.Name = "tabOneM2M";
            this.tabOneM2M.Size = new System.Drawing.Size(1125, 765);
            this.tabOneM2M.TabIndex = 4;
            this.tabOneM2M.Text = "oneM2M Device";
            this.tabOneM2M.UseVisualStyleBackColor = true;
            // 
            // button117
            // 
            this.button117.Location = new System.Drawing.Point(276, 7);
            this.button117.Name = "button117";
            this.button117.Size = new System.Drawing.Size(155, 31);
            this.button117.TabIndex = 83;
            this.button117.Text = "시험 리소스 생성";
            this.button117.UseVisualStyleBackColor = true;
            this.button117.Click += new System.EventHandler(this.button117_Click);
            // 
            // groupBox21
            // 
            this.groupBox21.Controls.Add(this.label50);
            this.groupBox21.Controls.Add(this.textBox76);
            this.groupBox21.Controls.Add(this.label38);
            this.groupBox21.Controls.Add(this.textBox72);
            this.groupBox21.Controls.Add(this.label37);
            this.groupBox21.Controls.Add(this.textBox73);
            this.groupBox21.Controls.Add(this.button104);
            this.groupBox21.Controls.Add(this.label30);
            this.groupBox21.Controls.Add(this.btReset);
            this.groupBox21.Controls.Add(this.textBox62);
            this.groupBox21.Controls.Add(this.btnDeviceFOTA);
            this.groupBox21.Controls.Add(this.btnoneM2MModuleVer);
            this.groupBox21.Controls.Add(this.btnModemFOTA);
            this.groupBox21.Location = new System.Drawing.Point(26, 434);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Size = new System.Drawing.Size(472, 204);
            this.groupBox21.TabIndex = 82;
            this.groupBox21.TabStop = false;
            this.groupBox21.Text = "oneM2M Firmware";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label50.Location = new System.Drawing.Point(31, 52);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(108, 11);
            this.label50.TabIndex = 80;
            this.label50.Text = "Device FOTA data";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox76
            // 
            this.textBox76.Location = new System.Drawing.Point(148, 48);
            this.textBox76.Name = "textBox76";
            this.textBox76.Size = new System.Drawing.Size(228, 21);
            this.textBox76.TabIndex = 79;
            this.textBox76.Text = "$BIN_DATA=";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label38.Location = new System.Drawing.Point(47, 138);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(101, 11);
            this.label38.TabIndex = 53;
            this.label38.Text = "재부팅 완료 이벤트";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox72
            // 
            this.textBox72.Location = new System.Drawing.Point(148, 134);
            this.textBox72.Name = "textBox72";
            this.textBox72.Size = new System.Drawing.Size(228, 21);
            this.textBox72.TabIndex = 52;
            this.textBox72.Text = "+QIND: PB DONE";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label37.Location = new System.Drawing.Point(47, 111);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(95, 11);
            this.label37.TabIndex = 51;
            this.label37.Text = "모듈FOTA 명령어";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox73
            // 
            this.textBox73.Location = new System.Drawing.Point(148, 107);
            this.textBox73.Name = "textBox73";
            this.textBox73.Size = new System.Drawing.Size(228, 21);
            this.textBox73.TabIndex = 50;
            this.textBox73.Text = "AT$OM_MODEM_FWUP_FINISH";
            // 
            // button104
            // 
            this.button104.Font = new System.Drawing.Font("굴림", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button104.Location = new System.Drawing.Point(24, 21);
            this.button104.Name = "button104";
            this.button104.Size = new System.Drawing.Size(119, 22);
            this.button104.TabIndex = 49;
            this.button104.Text = "DeviceFW 보고";
            this.button104.UseVisualStyleBackColor = true;
            this.button104.Click += new System.EventHandler(this.button104_Click);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(231, 177);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(89, 12);
            this.label30.TabIndex = 78;
            this.label30.Text = "디바이스 버전 :";
            // 
            // btReset
            // 
            this.btReset.Location = new System.Drawing.Point(24, 173);
            this.btReset.Name = "btReset";
            this.btReset.Size = new System.Drawing.Size(118, 21);
            this.btReset.TabIndex = 44;
            this.btReset.Text = "RESET 보고";
            this.btReset.UseVisualStyleBackColor = true;
            this.btReset.Click += new System.EventHandler(this.btReset_Click);
            // 
            // textBox62
            // 
            this.textBox62.Location = new System.Drawing.Point(326, 171);
            this.textBox62.Name = "textBox62";
            this.textBox62.Size = new System.Drawing.Size(94, 21);
            this.textBox62.TabIndex = 77;
            this.textBox62.Text = "1.0.0";
            this.textBox62.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnDeviceFOTA
            // 
            this.btnDeviceFOTA.Font = new System.Drawing.Font("굴림", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDeviceFOTA.Location = new System.Drawing.Point(234, 21);
            this.btnDeviceFOTA.Name = "btnDeviceFOTA";
            this.btnDeviceFOTA.Size = new System.Drawing.Size(118, 22);
            this.btnDeviceFOTA.TabIndex = 23;
            this.btnDeviceFOTA.Text = "DeviceFW 조회";
            this.btnDeviceFOTA.UseVisualStyleBackColor = true;
            this.btnDeviceFOTA.Click += new System.EventHandler(this.btnDeviceFOTA_Click);
            // 
            // btnoneM2MModuleVer
            // 
            this.btnoneM2MModuleVer.Font = new System.Drawing.Font("굴림", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnoneM2MModuleVer.Location = new System.Drawing.Point(25, 75);
            this.btnoneM2MModuleVer.Name = "btnoneM2MModuleVer";
            this.btnoneM2MModuleVer.Size = new System.Drawing.Size(118, 22);
            this.btnoneM2MModuleVer.TabIndex = 40;
            this.btnoneM2MModuleVer.Text = "ModemFW 보고";
            this.btnoneM2MModuleVer.UseVisualStyleBackColor = true;
            this.btnoneM2MModuleVer.Click += new System.EventHandler(this.btnoneM2MModuleVer_Click);
            // 
            // btnModemFOTA
            // 
            this.btnModemFOTA.Location = new System.Drawing.Point(234, 78);
            this.btnModemFOTA.Name = "btnModemFOTA";
            this.btnModemFOTA.Size = new System.Drawing.Size(118, 23);
            this.btnModemFOTA.TabIndex = 24;
            this.btnModemFOTA.Text = "ModemFW 조회";
            this.btnModemFOTA.UseVisualStyleBackColor = true;
            this.btnModemFOTA.Click += new System.EventHandler(this.btnModemFOTA_Click);
            // 
            // groupBox20
            // 
            this.groupBox20.Controls.Add(this.button70);
            this.groupBox20.Controls.Add(this.button102);
            this.groupBox20.Controls.Add(this.button103);
            this.groupBox20.Controls.Add(this.button80);
            this.groupBox20.Location = new System.Drawing.Point(26, 670);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(472, 84);
            this.groupBox20.TabIndex = 81;
            this.groupBox20.TabStop = false;
            this.groupBox20.Text = "oneM2M ACP";
            // 
            // button70
            // 
            this.button70.Font = new System.Drawing.Font("굴림", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button70.Location = new System.Drawing.Point(201, 20);
            this.button70.Name = "button70";
            this.button70.Size = new System.Drawing.Size(119, 22);
            this.button70.TabIndex = 46;
            this.button70.Text = "권한 관리 정보 생성";
            this.button70.UseVisualStyleBackColor = true;
            this.button70.Click += new System.EventHandler(this.button70_Click);
            // 
            // button102
            // 
            this.button102.Font = new System.Drawing.Font("굴림", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button102.Location = new System.Drawing.Point(201, 47);
            this.button102.Name = "button102";
            this.button102.Size = new System.Drawing.Size(119, 22);
            this.button102.TabIndex = 48;
            this.button102.Text = "권한 관리 정보 삭제";
            this.button102.UseVisualStyleBackColor = true;
            this.button102.Click += new System.EventHandler(this.button102_Click);
            // 
            // button103
            // 
            this.button103.Font = new System.Drawing.Font("굴림", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button103.Location = new System.Drawing.Point(24, 20);
            this.button103.Name = "button103";
            this.button103.Size = new System.Drawing.Size(119, 22);
            this.button103.TabIndex = 45;
            this.button103.Text = "권한 관리 정보 조회";
            this.button103.UseVisualStyleBackColor = true;
            this.button103.Click += new System.EventHandler(this.button103_Click);
            // 
            // button80
            // 
            this.button80.Font = new System.Drawing.Font("굴림", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button80.Location = new System.Drawing.Point(24, 47);
            this.button80.Name = "button80";
            this.button80.Size = new System.Drawing.Size(119, 22);
            this.button80.TabIndex = 47;
            this.button80.Text = "권한 관리 정보 수정";
            this.button80.UseVisualStyleBackColor = true;
            this.button80.Click += new System.EventHandler(this.button80_Click);
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.checkBox4);
            this.groupBox19.Controls.Add(this.button116);
            this.groupBox19.Controls.Add(this.button115);
            this.groupBox19.Controls.Add(this.btnSetRxContainer);
            this.groupBox19.Controls.Add(this.btnSendDataOneM2M);
            this.groupBox19.Controls.Add(this.btnRcvDataOneM2M);
            this.groupBox19.Controls.Add(this.lboneM2MRcvData);
            this.groupBox19.Controls.Add(this.btnSetSubscript);
            this.groupBox19.Controls.Add(this.btnDelRxContainer);
            this.groupBox19.Controls.Add(this.button34);
            this.groupBox19.Controls.Add(this.lbSendedData);
            this.groupBox19.Controls.Add(this.btnDelSubscript);
            this.groupBox19.Location = new System.Drawing.Point(26, 272);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(472, 157);
            this.groupBox19.TabIndex = 80;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "oneM2M DATA";
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Checked = true;
            this.checkBox4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox4.Location = new System.Drawing.Point(411, 132);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(48, 16);
            this.checkBox4.TabIndex = 45;
            this.checkBox4.Text = "지원";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // button116
            // 
            this.button116.Location = new System.Drawing.Point(285, 129);
            this.button116.Name = "button116";
            this.button116.Size = new System.Drawing.Size(120, 20);
            this.button116.TabIndex = 44;
            this.button116.Text = "자동수신 해제";
            this.button116.UseVisualStyleBackColor = true;
            this.button116.Click += new System.EventHandler(this.button116_Click);
            // 
            // button115
            // 
            this.button115.Location = new System.Drawing.Point(155, 129);
            this.button115.Name = "button115";
            this.button115.Size = new System.Drawing.Size(120, 20);
            this.button115.TabIndex = 43;
            this.button115.Text = "자동수신 설정";
            this.button115.UseVisualStyleBackColor = true;
            this.button115.Click += new System.EventHandler(this.button115_Click);
            // 
            // btnSetRxContainer
            // 
            this.btnSetRxContainer.Location = new System.Drawing.Point(25, 20);
            this.btnSetRxContainer.Name = "btnSetRxContainer";
            this.btnSetRxContainer.Size = new System.Drawing.Size(118, 20);
            this.btnSetRxContainer.TabIndex = 36;
            this.btnSetRxContainer.Text = "폴더생성";
            this.btnSetRxContainer.UseVisualStyleBackColor = true;
            this.btnSetRxContainer.Click += new System.EventHandler(this.btnSetRxContainer_Click);
            // 
            // btnSendDataOneM2M
            // 
            this.btnSendDataOneM2M.Location = new System.Drawing.Point(22, 103);
            this.btnSendDataOneM2M.Name = "btnSendDataOneM2M";
            this.btnSendDataOneM2M.Size = new System.Drawing.Size(121, 20);
            this.btnSendDataOneM2M.TabIndex = 19;
            this.btnSendDataOneM2M.Text = "데이터전송 (DB)";
            this.btnSendDataOneM2M.UseVisualStyleBackColor = true;
            this.btnSendDataOneM2M.Click += new System.EventHandler(this.btnSendDataOneM2M_Click);
            // 
            // btnRcvDataOneM2M
            // 
            this.btnRcvDataOneM2M.Location = new System.Drawing.Point(22, 77);
            this.btnRcvDataOneM2M.Name = "btnRcvDataOneM2M";
            this.btnRcvDataOneM2M.Size = new System.Drawing.Size(121, 20);
            this.btnRcvDataOneM2M.TabIndex = 30;
            this.btnRcvDataOneM2M.Text = "데이터 수신";
            this.btnRcvDataOneM2M.UseVisualStyleBackColor = true;
            this.btnRcvDataOneM2M.Click += new System.EventHandler(this.btnRcvDataOneM2M_Click);
            // 
            // lboneM2MRcvData
            // 
            this.lboneM2MRcvData.AutoSize = true;
            this.lboneM2MRcvData.Location = new System.Drawing.Point(160, 81);
            this.lboneM2MRcvData.Name = "lboneM2MRcvData";
            this.lboneM2MRcvData.Size = new System.Drawing.Size(9, 12);
            this.lboneM2MRcvData.TabIndex = 31;
            this.lboneM2MRcvData.Text = ".";
            this.lboneM2MRcvData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSetSubscript
            // 
            this.btnSetSubscript.Location = new System.Drawing.Point(23, 46);
            this.btnSetSubscript.Name = "btnSetSubscript";
            this.btnSetSubscript.Size = new System.Drawing.Size(120, 20);
            this.btnSetSubscript.TabIndex = 34;
            this.btnSetSubscript.Text = "구독신청";
            this.btnSetSubscript.UseVisualStyleBackColor = true;
            this.btnSetSubscript.Click += new System.EventHandler(this.btnSetSubscript_Click);
            // 
            // btnDelRxContainer
            // 
            this.btnDelRxContainer.Location = new System.Drawing.Point(174, 20);
            this.btnDelRxContainer.Name = "btnDelRxContainer";
            this.btnDelRxContainer.Size = new System.Drawing.Size(120, 20);
            this.btnDelRxContainer.TabIndex = 37;
            this.btnDelRxContainer.Text = "폴더삭제";
            this.btnDelRxContainer.UseVisualStyleBackColor = true;
            this.btnDelRxContainer.Click += new System.EventHandler(this.btnDelRxContainer_Click);
            // 
            // button34
            // 
            this.button34.Location = new System.Drawing.Point(23, 129);
            this.button34.Name = "button34";
            this.button34.Size = new System.Drawing.Size(121, 20);
            this.button34.TabIndex = 42;
            this.button34.Text = "데이터전송 (서버)";
            this.button34.UseVisualStyleBackColor = true;
            this.button34.Click += new System.EventHandler(this.button34_Click);
            // 
            // lbSendedData
            // 
            this.lbSendedData.AutoSize = true;
            this.lbSendedData.Location = new System.Drawing.Point(160, 107);
            this.lbSendedData.Name = "lbSendedData";
            this.lbSendedData.Size = new System.Drawing.Size(9, 12);
            this.lbSendedData.TabIndex = 38;
            this.lbSendedData.Text = ".";
            this.lbSendedData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnDelSubscript
            // 
            this.btnDelSubscript.Location = new System.Drawing.Point(174, 46);
            this.btnDelSubscript.Name = "btnDelSubscript";
            this.btnDelSubscript.Size = new System.Drawing.Size(120, 20);
            this.btnDelSubscript.TabIndex = 39;
            this.btnDelSubscript.Text = "구독삭제";
            this.btnDelSubscript.UseVisualStyleBackColor = true;
            this.btnDelSubscript.Click += new System.EventHandler(this.btnDelSubscript_Click);
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.checkBox3);
            this.groupBox18.Controls.Add(this.btnGetCSED);
            this.groupBox18.Controls.Add(this.btnGetDeviceCSR);
            this.groupBox18.Controls.Add(this.btnCreateDeviceCSR);
            this.groupBox18.Controls.Add(this.btnDelDeviceCSR);
            this.groupBox18.Controls.Add(this.btnDeviceUpdateCSR);
            this.groupBox18.Location = new System.Drawing.Point(26, 159);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(472, 109);
            this.groupBox18.TabIndex = 79;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "remoteCSE";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Location = new System.Drawing.Point(151, 23);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(48, 16);
            this.checkBox3.TabIndex = 41;
            this.checkBox3.Text = "지원";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // btnGetCSED
            // 
            this.btnGetCSED.Location = new System.Drawing.Point(24, 20);
            this.btnGetCSED.Name = "btnGetCSED";
            this.btnGetCSED.Size = new System.Drawing.Size(121, 20);
            this.btnGetCSED.TabIndex = 21;
            this.btnGetCSED.Text = "CSEBase 조회";
            this.btnGetCSED.UseVisualStyleBackColor = true;
            this.btnGetCSED.Click += new System.EventHandler(this.btnGetCSED_Click);
            // 
            // btnGetDeviceCSR
            // 
            this.btnGetDeviceCSR.Location = new System.Drawing.Point(24, 46);
            this.btnGetDeviceCSR.Name = "btnGetDeviceCSR";
            this.btnGetDeviceCSR.Size = new System.Drawing.Size(121, 20);
            this.btnGetDeviceCSR.TabIndex = 22;
            this.btnGetDeviceCSR.Text = "CSR 조회";
            this.btnGetDeviceCSR.UseVisualStyleBackColor = true;
            this.btnGetDeviceCSR.Click += new System.EventHandler(this.btnGetDeviceCSR_Click);
            // 
            // btnCreateDeviceCSR
            // 
            this.btnCreateDeviceCSR.Location = new System.Drawing.Point(225, 46);
            this.btnCreateDeviceCSR.Name = "btnCreateDeviceCSR";
            this.btnCreateDeviceCSR.Size = new System.Drawing.Size(118, 20);
            this.btnCreateDeviceCSR.TabIndex = 25;
            this.btnCreateDeviceCSR.Text = "CSR 생성";
            this.btnCreateDeviceCSR.UseVisualStyleBackColor = true;
            this.btnCreateDeviceCSR.Click += new System.EventHandler(this.btnCreateDeviceCSR_Click);
            // 
            // btnDelDeviceCSR
            // 
            this.btnDelDeviceCSR.Location = new System.Drawing.Point(225, 72);
            this.btnDelDeviceCSR.Name = "btnDelDeviceCSR";
            this.btnDelDeviceCSR.Size = new System.Drawing.Size(119, 20);
            this.btnDelDeviceCSR.TabIndex = 26;
            this.btnDelDeviceCSR.Text = "CSR 삭제";
            this.btnDelDeviceCSR.UseVisualStyleBackColor = true;
            this.btnDelDeviceCSR.Click += new System.EventHandler(this.btnDelDeviceCSR_Click);
            // 
            // btnDeviceUpdateCSR
            // 
            this.btnDeviceUpdateCSR.Location = new System.Drawing.Point(24, 72);
            this.btnDeviceUpdateCSR.Name = "btnDeviceUpdateCSR";
            this.btnDeviceUpdateCSR.Size = new System.Drawing.Size(119, 20);
            this.btnDeviceUpdateCSR.TabIndex = 32;
            this.btnDeviceUpdateCSR.Text = "CSR 수정";
            this.btnDeviceUpdateCSR.UseVisualStyleBackColor = true;
            this.btnDeviceUpdateCSR.Click += new System.EventHandler(this.btnDeviceUpdateCSR_Click);
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.tbOneM2MDataIN);
            this.groupBox17.Location = new System.Drawing.Point(534, 14);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(582, 720);
            this.groupBox17.TabIndex = 46;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Device Message";
            // 
            // tbOneM2MDataIN
            // 
            this.tbOneM2MDataIN.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbOneM2MDataIN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbOneM2MDataIN.Location = new System.Drawing.Point(3, 17);
            this.tbOneM2MDataIN.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tbOneM2MDataIN.Multiline = true;
            this.tbOneM2MDataIN.Name = "tbOneM2MDataIN";
            this.tbOneM2MDataIN.ReadOnly = true;
            this.tbOneM2MDataIN.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbOneM2MDataIN.Size = new System.Drawing.Size(576, 700);
            this.tbOneM2MDataIN.TabIndex = 22;
            // 
            // gbOneM2MDevice
            // 
            this.gbOneM2MDevice.Controls.Add(this.checkBox1);
            this.gbOneM2MDevice.Controls.Add(this.button114);
            this.gbOneM2MDevice.Controls.Add(this.button112);
            this.gbOneM2MDevice.Controls.Add(this.button111);
            this.gbOneM2MDevice.Controls.Add(this.button110);
            this.gbOneM2MDevice.Controls.Add(this.button109);
            this.gbOneM2MDevice.Controls.Add(this.button106);
            this.gbOneM2MDevice.Controls.Add(this.btnMEFAuthD);
            this.gbOneM2MDevice.Location = new System.Drawing.Point(26, 42);
            this.gbOneM2MDevice.Name = "gbOneM2MDevice";
            this.gbOneM2MDevice.Size = new System.Drawing.Size(472, 112);
            this.gbOneM2MDevice.TabIndex = 72;
            this.gbOneM2MDevice.TabStop = false;
            this.gbOneM2MDevice.Text = "oneM2M 인증";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(296, 75);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(48, 16);
            this.checkBox1.TabIndex = 40;
            this.checkBox1.Text = "지원";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button114
            // 
            this.button114.Location = new System.Drawing.Point(169, 72);
            this.button114.Name = "button114";
            this.button114.Size = new System.Drawing.Size(121, 20);
            this.button114.TabIndex = 39;
            this.button114.Text = "FOTA서버 설정";
            this.button114.UseVisualStyleBackColor = true;
            this.button114.Click += new System.EventHandler(this.button114_Click);
            // 
            // button112
            // 
            this.button112.Location = new System.Drawing.Point(6, 72);
            this.button112.Name = "button112";
            this.button112.Size = new System.Drawing.Size(121, 20);
            this.button112.TabIndex = 38;
            this.button112.Text = "MEF서버 설정";
            this.button112.UseVisualStyleBackColor = true;
            this.button112.Click += new System.EventHandler(this.button112_Click);
            // 
            // button111
            // 
            this.button111.Location = new System.Drawing.Point(169, 46);
            this.button111.Name = "button111";
            this.button111.Size = new System.Drawing.Size(121, 20);
            this.button111.TabIndex = 37;
            this.button111.Text = "BRK서버 설정";
            this.button111.UseVisualStyleBackColor = true;
            this.button111.Click += new System.EventHandler(this.button111_Click);
            // 
            // button110
            // 
            this.button110.Location = new System.Drawing.Point(6, 46);
            this.button110.Name = "button110";
            this.button110.Size = new System.Drawing.Size(121, 20);
            this.button110.TabIndex = 36;
            this.button110.Text = "서버 설정 조회";
            this.button110.UseVisualStyleBackColor = true;
            this.button110.Click += new System.EventHandler(this.button110_Click);
            // 
            // button109
            // 
            this.button109.Location = new System.Drawing.Point(169, 20);
            this.button109.Name = "button109";
            this.button109.Size = new System.Drawing.Size(121, 20);
            this.button109.TabIndex = 35;
            this.button109.Text = "oneM2M모드 설정";
            this.button109.UseVisualStyleBackColor = true;
            this.button109.Click += new System.EventHandler(this.button109_Click);
            // 
            // button106
            // 
            this.button106.Location = new System.Drawing.Point(6, 20);
            this.button106.Name = "button106";
            this.button106.Size = new System.Drawing.Size(121, 20);
            this.button106.TabIndex = 34;
            this.button106.Text = "oneM2M모드 조회";
            this.button106.UseVisualStyleBackColor = true;
            this.button106.Click += new System.EventHandler(this.button106_Click);
            // 
            // btnMEFAuthD
            // 
            this.btnMEFAuthD.Location = new System.Drawing.Point(333, 18);
            this.btnMEFAuthD.Name = "btnMEFAuthD";
            this.btnMEFAuthD.Size = new System.Drawing.Size(97, 46);
            this.btnMEFAuthD.TabIndex = 33;
            this.btnMEFAuthD.Text = "MEF 인증";
            this.btnMEFAuthD.UseVisualStyleBackColor = true;
            this.btnMEFAuthD.Click += new System.EventHandler(this.btnMEFAuthD_Click);
            // 
            // btnoneM2MFullTest
            // 
            this.btnoneM2MFullTest.Location = new System.Drawing.Point(70, 7);
            this.btnoneM2MFullTest.Name = "btnoneM2MFullTest";
            this.btnoneM2MFullTest.Size = new System.Drawing.Size(155, 31);
            this.btnoneM2MFullTest.TabIndex = 41;
            this.btnoneM2MFullTest.Text = "시험절차서 전체 실행";
            this.btnoneM2MFullTest.UseVisualStyleBackColor = true;
            this.btnoneM2MFullTest.Click += new System.EventHandler(this.btnoneM2MFullTest_Click);
            // 
            // tabLwM2M
            // 
            this.tabLwM2M.Controls.Add(this.groupBox22);
            this.tabLwM2M.Controls.Add(this.groupBox16);
            this.tabLwM2M.Controls.Add(this.label1);
            this.tabLwM2M.Controls.Add(this.tBoxDeviceVer);
            this.tabLwM2M.Controls.Add(this.button113);
            this.tabLwM2M.Controls.Add(this.groupBox11);
            this.tabLwM2M.Controls.Add(this.button125);
            this.tabLwM2M.Location = new System.Drawing.Point(4, 22);
            this.tabLwM2M.Name = "tabLwM2M";
            this.tabLwM2M.Size = new System.Drawing.Size(1125, 765);
            this.tabLwM2M.TabIndex = 5;
            this.tabLwM2M.Text = "LwM2M Device";
            this.tabLwM2M.UseVisualStyleBackColor = true;
            // 
            // groupBox22
            // 
            this.groupBox22.Controls.Add(this.label39);
            this.groupBox22.Controls.Add(this.textBox70);
            this.groupBox22.Controls.Add(this.label3);
            this.groupBox22.Controls.Add(this.textBox65);
            this.groupBox22.Controls.Add(this.textBox71);
            this.groupBox22.Controls.Add(this.button35);
            this.groupBox22.Location = new System.Drawing.Point(11, 58);
            this.groupBox22.Name = "groupBox22";
            this.groupBox22.Size = new System.Drawing.Size(513, 113);
            this.groupBox22.TabIndex = 63;
            this.groupBox22.TabStop = false;
            this.groupBox22.Text = "groupBox22";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(126, 79);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(78, 12);
            this.label39.TabIndex = 66;
            this.label39.Text = "모듈 FW 버전";
            // 
            // textBox70
            // 
            this.textBox70.Location = new System.Drawing.Point(210, 76);
            this.textBox70.Name = "textBox70";
            this.textBox70.Size = new System.Drawing.Size(291, 21);
            this.textBox70.TabIndex = 65;
            this.textBox70.Text = "AT+MLWEVTIND=5";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(107, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 12);
            this.label3.TabIndex = 64;
            this.label3.Text = "부팅 완료 메시지";
            // 
            // textBox65
            // 
            this.textBox65.Location = new System.Drawing.Point(210, 49);
            this.textBox65.Name = "textBox65";
            this.textBox65.Size = new System.Drawing.Size(291, 21);
            this.textBox65.TabIndex = 57;
            this.textBox65.Text = "+MBIPST:0";
            // 
            // textBox71
            // 
            this.textBox71.Location = new System.Drawing.Point(210, 22);
            this.textBox71.Name = "textBox71";
            this.textBox71.Size = new System.Drawing.Size(291, 21);
            this.textBox71.TabIndex = 56;
            this.textBox71.Text = "AT+NRB";
            // 
            // button35
            // 
            this.button35.Location = new System.Drawing.Point(8, 19);
            this.button35.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button35.Name = "button35";
            this.button35.Size = new System.Drawing.Size(196, 24);
            this.button35.TabIndex = 55;
            this.button35.Text = "Device Reboot";
            this.button35.UseVisualStyleBackColor = true;
            this.button35.Click += new System.EventHandler(this.button35_Click);
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.tbLwM2MDataIN);
            this.groupBox16.Location = new System.Drawing.Point(540, 15);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(582, 732);
            this.groupBox16.TabIndex = 45;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Device Message";
            // 
            // tbLwM2MDataIN
            // 
            this.tbLwM2MDataIN.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbLwM2MDataIN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLwM2MDataIN.Location = new System.Drawing.Point(3, 17);
            this.tbLwM2MDataIN.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tbLwM2MDataIN.Multiline = true;
            this.tbLwM2MDataIN.Name = "tbLwM2MDataIN";
            this.tbLwM2MDataIN.ReadOnly = true;
            this.tbLwM2MDataIN.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbLwM2MDataIN.Size = new System.Drawing.Size(576, 712);
            this.tbLwM2MDataIN.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(180, 732);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 62;
            this.label1.Text = "디바이스 버전 :";
            // 
            // tBoxDeviceVer
            // 
            this.tBoxDeviceVer.Location = new System.Drawing.Point(275, 726);
            this.tBoxDeviceVer.Name = "tBoxDeviceVer";
            this.tBoxDeviceVer.Size = new System.Drawing.Size(126, 21);
            this.tBoxDeviceVer.TabIndex = 61;
            this.tBoxDeviceVer.Text = "1.0.0";
            this.tBoxDeviceVer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button113
            // 
            this.button113.Location = new System.Drawing.Point(166, 24);
            this.button113.Name = "button113";
            this.button113.Size = new System.Drawing.Size(155, 28);
            this.button113.TabIndex = 55;
            this.button113.Text = "시험절차서 전체 실행";
            this.button113.UseVisualStyleBackColor = true;
            this.button113.Click += new System.EventHandler(this.button113_Click);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.label43);
            this.groupBox11.Controls.Add(this.checkBox5);
            this.groupBox11.Controls.Add(this.label42);
            this.groupBox11.Controls.Add(this.label41);
            this.groupBox11.Controls.Add(this.textBox75);
            this.groupBox11.Controls.Add(this.textBox74);
            this.groupBox11.Controls.Add(this.textBox63);
            this.groupBox11.Controls.Add(this.textBox69);
            this.groupBox11.Controls.Add(this.button108);
            this.groupBox11.Controls.Add(this.lbLwM2MRcvData);
            this.groupBox11.Controls.Add(this.textBox68);
            this.groupBox11.Controls.Add(this.lbDevLwM2MData);
            this.groupBox11.Controls.Add(this.button107);
            this.groupBox11.Controls.Add(this.textBox67);
            this.groupBox11.Controls.Add(this.btnBootstrap);
            this.groupBox11.Controls.Add(this.textBox66);
            this.groupBox11.Controls.Add(this.button105);
            this.groupBox11.Controls.Add(this.checkBox2);
            this.groupBox11.Controls.Add(this.textBox52);
            this.groupBox11.Controls.Add(this.textBox50);
            this.groupBox11.Controls.Add(this.btnDeregister);
            this.groupBox11.Controls.Add(this.button92);
            this.groupBox11.Controls.Add(this.textBox51);
            this.groupBox11.Controls.Add(this.btnDeviceVerLwM2M);
            this.groupBox11.Controls.Add(this.textBox53);
            this.groupBox11.Controls.Add(this.button95);
            this.groupBox11.Controls.Add(this.textBox54);
            this.groupBox11.Controls.Add(this.btnRegister);
            this.groupBox11.Controls.Add(this.textBox55);
            this.groupBox11.Controls.Add(this.textBox56);
            this.groupBox11.Controls.Add(this.button97);
            this.groupBox11.Controls.Add(this.button98);
            this.groupBox11.Location = new System.Drawing.Point(11, 188);
            this.groupBox11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox11.Size = new System.Drawing.Size(513, 533);
            this.groupBox11.TabIndex = 36;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "LwM2M COMMAND";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(74, 207);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(126, 12);
            this.label43.TabIndex = 66;
            this.label43.Text = "Bootstrap 완료 메시지";
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Checked = true;
            this.checkBox5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox5.Location = new System.Drawing.Point(210, 182);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(185, 16);
            this.checkBox5.TabIndex = 65;
            this.checkBox5.Text = "Bootstrap/Register 명령 구분";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged_1);
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(74, 324);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(130, 12);
            this.label42.TabIndex = 64;
            this.label42.Text = "Deregister 완료 메시지";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(85, 265);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(119, 12);
            this.label41.TabIndex = 63;
            this.label41.Text = "Register 완료 메시지";
            // 
            // textBox75
            // 
            this.textBox75.Location = new System.Drawing.Point(210, 321);
            this.textBox75.Name = "textBox75";
            this.textBox75.Size = new System.Drawing.Size(291, 21);
            this.textBox75.TabIndex = 56;
            this.textBox75.Text = "AT+MLWEVTIND=1";
            // 
            // textBox74
            // 
            this.textBox74.Location = new System.Drawing.Point(210, 262);
            this.textBox74.Name = "textBox74";
            this.textBox74.Size = new System.Drawing.Size(291, 21);
            this.textBox74.TabIndex = 55;
            this.textBox74.Text = "AT+MLWEVTIND=8";
            // 
            // textBox63
            // 
            this.textBox63.Location = new System.Drawing.Point(210, 204);
            this.textBox63.Name = "textBox63";
            this.textBox63.Size = new System.Drawing.Size(291, 21);
            this.textBox63.TabIndex = 54;
            this.textBox63.Text = "AT+MLWEVTIND=4";
            // 
            // textBox69
            // 
            this.textBox69.Location = new System.Drawing.Point(210, 485);
            this.textBox69.Name = "textBox69";
            this.textBox69.Size = new System.Drawing.Size(291, 21);
            this.textBox69.TabIndex = 53;
            this.textBox69.Text = "AT+MLWDLDATA=1,";
            // 
            // button108
            // 
            this.button108.Location = new System.Drawing.Point(8, 482);
            this.button108.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button108.Name = "button108";
            this.button108.Size = new System.Drawing.Size(196, 24);
            this.button108.TabIndex = 52;
            this.button108.Text = "Device FOTA receive";
            this.button108.UseVisualStyleBackColor = true;
            // 
            // lbLwM2MRcvData
            // 
            this.lbLwM2MRcvData.AutoSize = true;
            this.lbLwM2MRcvData.Location = new System.Drawing.Point(208, 427);
            this.lbLwM2MRcvData.Name = "lbLwM2MRcvData";
            this.lbLwM2MRcvData.Size = new System.Drawing.Size(101, 12);
            this.lbLwM2MRcvData.TabIndex = 40;
            this.lbLwM2MRcvData.Text = "No received data";
            this.lbLwM2MRcvData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox68
            // 
            this.textBox68.Location = new System.Drawing.Point(210, 403);
            this.textBox68.Name = "textBox68";
            this.textBox68.Size = new System.Drawing.Size(291, 21);
            this.textBox68.TabIndex = 51;
            this.textBox68.Text = "AT+MLWDLDATA=";
            // 
            // lbDevLwM2MData
            // 
            this.lbDevLwM2MData.AutoSize = true;
            this.lbDevLwM2MData.Location = new System.Drawing.Point(208, 376);
            this.lbDevLwM2MData.Name = "lbDevLwM2MData";
            this.lbDevLwM2MData.Size = new System.Drawing.Size(49, 12);
            this.lbDevLwM2MData.TabIndex = 39;
            this.lbDevLwM2MData.Text = "No data";
            this.lbDevLwM2MData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button107
            // 
            this.button107.Location = new System.Drawing.Point(8, 400);
            this.button107.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button107.Name = "button107";
            this.button107.Size = new System.Drawing.Size(196, 24);
            this.button107.TabIndex = 50;
            this.button107.Text = "DATA reveive";
            this.button107.UseVisualStyleBackColor = true;
            // 
            // textBox67
            // 
            this.textBox67.Location = new System.Drawing.Point(210, 146);
            this.textBox67.Name = "textBox67";
            this.textBox67.Size = new System.Drawing.Size(291, 21);
            this.textBox67.TabIndex = 49;
            this.textBox67.Text = "AT+MLWGOBOOTSTRAP=1";
            // 
            // btnBootstrap
            // 
            this.btnBootstrap.Location = new System.Drawing.Point(8, 146);
            this.btnBootstrap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBootstrap.Name = "btnBootstrap";
            this.btnBootstrap.Size = new System.Drawing.Size(196, 24);
            this.btnBootstrap.TabIndex = 48;
            this.btnBootstrap.Text = "BOOTSTRAP";
            this.btnBootstrap.UseVisualStyleBackColor = true;
            this.btnBootstrap.Click += new System.EventHandler(this.btnBootstrap_Click);
            // 
            // textBox66
            // 
            this.textBox66.Location = new System.Drawing.Point(210, 118);
            this.textBox66.Name = "textBox66";
            this.textBox66.Size = new System.Drawing.Size(291, 21);
            this.textBox66.TabIndex = 47;
            this.textBox66.Text = "AT+MBOOTSTRAPMODE=1";
            // 
            // button105
            // 
            this.button105.Location = new System.Drawing.Point(8, 118);
            this.button105.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button105.Name = "button105";
            this.button105.Size = new System.Drawing.Size(196, 24);
            this.button105.TabIndex = 46;
            this.button105.Text = "BOOTSTRAP mode";
            this.button105.UseVisualStyleBackColor = true;
            this.button105.Click += new System.EventHandler(this.button105_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(423, 65);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(48, 16);
            this.checkBox2.TabIndex = 45;
            this.checkBox2.Text = "수동";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged_1);
            // 
            // textBox52
            // 
            this.textBox52.Location = new System.Drawing.Point(210, 294);
            this.textBox52.Name = "textBox52";
            this.textBox52.Size = new System.Drawing.Size(291, 21);
            this.textBox52.TabIndex = 28;
            this.textBox52.Text = "AT+MLWSREGIND=1";
            // 
            // textBox50
            // 
            this.textBox50.Location = new System.Drawing.Point(212, 63);
            this.textBox50.Name = "textBox50";
            this.textBox50.Size = new System.Drawing.Size(205, 21);
            this.textBox50.TabIndex = 32;
            this.textBox50.Text = "AT+MLWEPNS=";
            // 
            // btnDeregister
            // 
            this.btnDeregister.Location = new System.Drawing.Point(8, 291);
            this.btnDeregister.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeregister.Name = "btnDeregister";
            this.btnDeregister.Size = new System.Drawing.Size(196, 24);
            this.btnDeregister.TabIndex = 27;
            this.btnDeregister.Text = "DEREGISTRATION";
            this.btnDeregister.UseVisualStyleBackColor = true;
            this.btnDeregister.Click += new System.EventHandler(this.btnDeregister_Click);
            // 
            // button92
            // 
            this.button92.Location = new System.Drawing.Point(10, 60);
            this.button92.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button92.Name = "button92";
            this.button92.Size = new System.Drawing.Size(196, 24);
            this.button92.TabIndex = 31;
            this.button92.Text = "Set Device Entity ID";
            this.button92.UseVisualStyleBackColor = true;
            this.button92.Click += new System.EventHandler(this.button92_Click);
            // 
            // textBox51
            // 
            this.textBox51.Location = new System.Drawing.Point(210, 457);
            this.textBox51.Name = "textBox51";
            this.textBox51.Size = new System.Drawing.Size(291, 21);
            this.textBox51.TabIndex = 30;
            this.textBox51.Text = "AT+MLWULDATA=1,";
            // 
            // btnDeviceVerLwM2M
            // 
            this.btnDeviceVerLwM2M.Location = new System.Drawing.Point(8, 454);
            this.btnDeviceVerLwM2M.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeviceVerLwM2M.Name = "btnDeviceVerLwM2M";
            this.btnDeviceVerLwM2M.Size = new System.Drawing.Size(196, 24);
            this.btnDeviceVerLwM2M.TabIndex = 29;
            this.btnDeviceVerLwM2M.Text = "Device 버전 보고";
            this.btnDeviceVerLwM2M.UseVisualStyleBackColor = true;
            this.btnDeviceVerLwM2M.Click += new System.EventHandler(this.btnDeviceVerLwM2M_Click);
            // 
            // textBox53
            // 
            this.textBox53.Location = new System.Drawing.Point(210, 352);
            this.textBox53.Name = "textBox53";
            this.textBox53.Size = new System.Drawing.Size(291, 21);
            this.textBox53.TabIndex = 26;
            this.textBox53.Text = "AT+MLWULDATA=";
            // 
            // button95
            // 
            this.button95.Location = new System.Drawing.Point(8, 349);
            this.button95.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button95.Name = "button95";
            this.button95.Size = new System.Drawing.Size(196, 24);
            this.button95.TabIndex = 25;
            this.button95.Text = "DATA send";
            this.button95.UseVisualStyleBackColor = true;
            this.button95.Click += new System.EventHandler(this.button95_Click);
            // 
            // textBox54
            // 
            this.textBox54.Location = new System.Drawing.Point(210, 235);
            this.textBox54.Name = "textBox54";
            this.textBox54.Size = new System.Drawing.Size(291, 21);
            this.textBox54.TabIndex = 24;
            this.textBox54.Text = "AT+MLWSREGIND=0";
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(8, 232);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(196, 24);
            this.btnRegister.TabIndex = 23;
            this.btnRegister.Text = "REGISTRATION";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // textBox55
            // 
            this.textBox55.Location = new System.Drawing.Point(210, 88);
            this.textBox55.Name = "textBox55";
            this.textBox55.Size = new System.Drawing.Size(291, 21);
            this.textBox55.TabIndex = 20;
            this.textBox55.Text = "AT+MLWMBSPS=";
            // 
            // textBox56
            // 
            this.textBox56.Location = new System.Drawing.Point(210, 33);
            this.textBox56.Name = "textBox56";
            this.textBox56.Size = new System.Drawing.Size(291, 21);
            this.textBox56.TabIndex = 18;
            this.textBox56.Text = "AT+NCDP=\"106.103.233.155\",5783";
            // 
            // button97
            // 
            this.button97.Location = new System.Drawing.Point(8, 88);
            this.button97.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button97.Name = "button97";
            this.button97.Size = new System.Drawing.Size(196, 24);
            this.button97.TabIndex = 12;
            this.button97.Text = "MBSPS";
            this.button97.UseVisualStyleBackColor = true;
            this.button97.Click += new System.EventHandler(this.button97_Click);
            // 
            // button98
            // 
            this.button98.Location = new System.Drawing.Point(8, 30);
            this.button98.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button98.Name = "button98";
            this.button98.Size = new System.Drawing.Size(196, 24);
            this.button98.TabIndex = 8;
            this.button98.Text = "Set Server IP";
            this.button98.UseVisualStyleBackColor = true;
            this.button98.Click += new System.EventHandler(this.button98_Click);
            // 
            // button125
            // 
            this.button125.Location = new System.Drawing.Point(25, 24);
            this.button125.Name = "button125";
            this.button125.Size = new System.Drawing.Size(131, 28);
            this.button125.TabIndex = 54;
            this.button125.Text = "펌웨어 이력초기화";
            this.button125.UseVisualStyleBackColor = true;
            this.button125.Click += new System.EventHandler(this.button125_Click);
            // 
            // tabServer
            // 
            this.tabServer.Controls.Add(this.label23);
            this.tabServer.Controls.Add(this.label25);
            this.tabServer.Controls.Add(this.groupBox13);
            this.tabServer.Controls.Add(this.groupBox12);
            this.tabServer.Controls.Add(this.groupBox14);
            this.tabServer.Controls.Add(this.groupBox15);
            this.tabServer.Controls.Add(this.btnMEFAuth);
            this.tabServer.Controls.Add(this.tbSvcCd);
            this.tabServer.Controls.Add(this.label28);
            this.tabServer.Controls.Add(this.label31);
            this.tabServer.Controls.Add(this.tbSvcSvrCd);
            this.tabServer.Controls.Add(this.label33);
            this.tabServer.Controls.Add(this.tbSvcSvrNum);
            this.tabServer.Location = new System.Drawing.Point(4, 22);
            this.tabServer.Name = "tabServer";
            this.tabServer.Size = new System.Drawing.Size(1125, 765);
            this.tabServer.TabIndex = 6;
            this.tabServer.Text = "Service Server";
            this.tabServer.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(160, 109);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(224, 22);
            this.label23.TabIndex = 77;
            this.label23.Text = ".";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(53, 114);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(99, 12);
            this.label25.TabIndex = 76;
            this.label25.Text = "Server EntityID : ";
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.label40);
            this.groupBox13.Controls.Add(this.label8);
            this.groupBox13.Controls.Add(this.lbDevEntityId);
            this.groupBox13.Controls.Add(this.button93);
            this.groupBox13.Controls.Add(this.label10);
            this.groupBox13.Controls.Add(this.lbLwM2MRxData);
            this.groupBox13.Controls.Add(this.label35);
            this.groupBox13.Controls.Add(this.btnDeviceStatusCheck);
            this.groupBox13.Controls.Add(this.label36);
            this.groupBox13.Controls.Add(this.label11);
            this.groupBox13.Controls.Add(this.btnLwM2MData);
            this.groupBox13.Location = new System.Drawing.Point(11, 520);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(458, 184);
            this.groupBox13.TabIndex = 48;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "LwM2M Device DATA";
            // 
            // label40
            // 
            this.label40.Location = new System.Drawing.Point(147, 78);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(242, 22);
            this.label40.TabIndex = 88;
            this.label40.Text = ".";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(210, 142);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(164, 16);
            this.label8.TabIndex = 48;
            this.label8.Text = ".";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbDevEntityId
            // 
            this.lbDevEntityId.Location = new System.Drawing.Point(104, 17);
            this.lbDevEntityId.Name = "lbDevEntityId";
            this.lbDevEntityId.Size = new System.Drawing.Size(224, 22);
            this.lbDevEntityId.TabIndex = 57;
            this.lbDevEntityId.Text = ".";
            this.lbDevEntityId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button93
            // 
            this.button93.Location = new System.Drawing.Point(15, 115);
            this.button93.Name = "button93";
            this.button93.Size = new System.Drawing.Size(126, 42);
            this.button93.TabIndex = 47;
            this.button93.Text = "펌웨어 버전";
            this.button93.UseVisualStyleBackColor = true;
            this.button93.Click += new System.EventHandler(this.button93_Click);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(210, 115);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(164, 16);
            this.label10.TabIndex = 50;
            this.label10.Text = ".";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbLwM2MRxData
            // 
            this.lbLwM2MRxData.Location = new System.Drawing.Point(150, 43);
            this.lbLwM2MRxData.Name = "lbLwM2MRxData";
            this.lbLwM2MRxData.Size = new System.Drawing.Size(245, 22);
            this.lbLwM2MRxData.TabIndex = 19;
            this.lbLwM2MRxData.Text = ".";
            this.lbLwM2MRxData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label35
            // 
            this.label35.Location = new System.Drawing.Point(147, 115);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(61, 16);
            this.label35.TabIndex = 51;
            this.label35.Text = "device =";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnDeviceStatusCheck
            // 
            this.btnDeviceStatusCheck.Location = new System.Drawing.Point(15, 42);
            this.btnDeviceStatusCheck.Name = "btnDeviceStatusCheck";
            this.btnDeviceStatusCheck.Size = new System.Drawing.Size(126, 23);
            this.btnDeviceStatusCheck.TabIndex = 18;
            this.btnDeviceStatusCheck.Text = "상태조회(단말)";
            this.btnDeviceStatusCheck.UseVisualStyleBackColor = true;
            this.btnDeviceStatusCheck.Click += new System.EventHandler(this.btnDeviceStatusCheck_Click);
            // 
            // label36
            // 
            this.label36.Location = new System.Drawing.Point(150, 140);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(60, 17);
            this.label36.TabIndex = 49;
            this.label36.Text = "modem =";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(13, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 22);
            this.label11.TabIndex = 13;
            this.label11.Text = "Device EntityID";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnLwM2MData
            // 
            this.btnLwM2MData.Location = new System.Drawing.Point(15, 78);
            this.btnLwM2MData.Name = "btnLwM2MData";
            this.btnLwM2MData.Size = new System.Drawing.Size(127, 23);
            this.btnLwM2MData.TabIndex = 11;
            this.btnLwM2MData.Text = "데이터 보내기";
            this.btnLwM2MData.UseVisualStyleBackColor = true;
            this.btnLwM2MData.Click += new System.EventHandler(this.btnLwM2MData_Click);
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.tbLog);
            this.groupBox12.Location = new System.Drawing.Point(489, 24);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(640, 715);
            this.groupBox12.TabIndex = 49;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "SERVER INTERFACE";
            // 
            // tbLog
            // 
            this.tbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLog.Location = new System.Drawing.Point(3, 17);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLog.Size = new System.Drawing.Size(634, 695);
            this.tbLog.TabIndex = 26;
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.label2);
            this.groupBox14.Controls.Add(this.label29);
            this.groupBox14.Controls.Add(this.label9);
            this.groupBox14.Controls.Add(this.comboBox2);
            this.groupBox14.Controls.Add(this.label13);
            this.groupBox14.Controls.Add(this.lbDirectRxData);
            this.groupBox14.Controls.Add(this.lboneM2MRxData);
            this.groupBox14.Controls.Add(this.btnDataRetrive);
            this.groupBox14.Controls.Add(this.button94);
            this.groupBox14.Controls.Add(this.button96);
            this.groupBox14.Controls.Add(this.lbmodemfwrver);
            this.groupBox14.Controls.Add(this.btnDeviceCheck);
            this.groupBox14.Controls.Add(this.lbdevicever);
            this.groupBox14.Controls.Add(this.label7);
            this.groupBox14.Controls.Add(this.btnSendData);
            this.groupBox14.Controls.Add(this.label14);
            this.groupBox14.Location = new System.Drawing.Point(8, 249);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(461, 251);
            this.groupBox14.TabIndex = 47;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "oneM2M Device DATA";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(147, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(242, 22);
            this.label2.TabIndex = 87;
            this.label2.Text = ".";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label29
            // 
            this.label29.Location = new System.Drawing.Point(150, 112);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(242, 22);
            this.label29.TabIndex = 86;
            this.label29.Text = ".";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(150, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(242, 22);
            this.label9.TabIndex = 85;
            this.label9.Text = ".";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "1. fwr-m2m_",
            "2. fwr-m2m_M",
            "3. fwr-m2m_M_"});
            this.comboBox2.Location = new System.Drawing.Point(152, 213);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(244, 20);
            this.comboBox2.TabIndex = 84;
            this.comboBox2.Text = "1. fwr-m2m_";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(15, 211);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(126, 22);
            this.label13.TabIndex = 83;
            this.label13.Text = "node name type";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbDirectRxData
            // 
            this.lbDirectRxData.Location = new System.Drawing.Point(150, 112);
            this.lbDirectRxData.Name = "lbDirectRxData";
            this.lbDirectRxData.Size = new System.Drawing.Size(242, 22);
            this.lbDirectRxData.TabIndex = 50;
            this.lbDirectRxData.Text = "No received data";
            this.lbDirectRxData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lboneM2MRxData
            // 
            this.lboneM2MRxData.Location = new System.Drawing.Point(150, 45);
            this.lboneM2MRxData.Name = "lboneM2MRxData";
            this.lboneM2MRxData.Size = new System.Drawing.Size(246, 22);
            this.lboneM2MRxData.TabIndex = 16;
            this.lboneM2MRxData.Text = ".";
            this.lboneM2MRxData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnDataRetrive
            // 
            this.btnDataRetrive.Location = new System.Drawing.Point(15, 45);
            this.btnDataRetrive.Name = "btnDataRetrive";
            this.btnDataRetrive.Size = new System.Drawing.Size(127, 23);
            this.btnDataRetrive.TabIndex = 14;
            this.btnDataRetrive.Text = "데이터 확인 (DB)";
            this.btnDataRetrive.UseVisualStyleBackColor = true;
            this.btnDataRetrive.Click += new System.EventHandler(this.btnDataRetrive_Click);
            // 
            // button94
            // 
            this.button94.Location = new System.Drawing.Point(15, 140);
            this.button94.Name = "button94";
            this.button94.Size = new System.Drawing.Size(126, 23);
            this.button94.TabIndex = 79;
            this.button94.Text = "데이터 전송 (단말)";
            this.button94.UseVisualStyleBackColor = true;
            this.button94.Click += new System.EventHandler(this.button94_Click);
            // 
            // button96
            // 
            this.button96.Location = new System.Drawing.Point(15, 111);
            this.button96.Name = "button96";
            this.button96.Size = new System.Drawing.Size(126, 23);
            this.button96.TabIndex = 78;
            this.button96.Text = "데이터 확인 (단말)";
            this.button96.UseVisualStyleBackColor = true;
            this.button96.Click += new System.EventHandler(this.button96_Click);
            // 
            // lbmodemfwrver
            // 
            this.lbmodemfwrver.Location = new System.Drawing.Point(210, 192);
            this.lbmodemfwrver.Name = "lbmodemfwrver";
            this.lbmodemfwrver.Size = new System.Drawing.Size(164, 16);
            this.lbmodemfwrver.TabIndex = 43;
            this.lbmodemfwrver.Text = ".";
            this.lbmodemfwrver.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnDeviceCheck
            // 
            this.btnDeviceCheck.Location = new System.Drawing.Point(15, 171);
            this.btnDeviceCheck.Name = "btnDeviceCheck";
            this.btnDeviceCheck.Size = new System.Drawing.Size(126, 37);
            this.btnDeviceCheck.TabIndex = 40;
            this.btnDeviceCheck.Text = "펌웨어 버전";
            this.btnDeviceCheck.UseVisualStyleBackColor = true;
            this.btnDeviceCheck.Click += new System.EventHandler(this.btnDeviceCheck_Click);
            // 
            // lbdevicever
            // 
            this.lbdevicever.Location = new System.Drawing.Point(210, 171);
            this.lbdevicever.Name = "lbdevicever";
            this.lbdevicever.Size = new System.Drawing.Size(164, 16);
            this.lbdevicever.TabIndex = 45;
            this.lbdevicever.Text = ".";
            this.lbdevicever.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(147, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 16);
            this.label7.TabIndex = 46;
            this.label7.Text = "device =";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSendData
            // 
            this.btnSendData.Location = new System.Drawing.Point(15, 74);
            this.btnSendData.Name = "btnSendData";
            this.btnSendData.Size = new System.Drawing.Size(126, 23);
            this.btnSendData.TabIndex = 3;
            this.btnSendData.Text = "데이터 전송 (DB)";
            this.btnSendData.UseVisualStyleBackColor = true;
            this.btnSendData.Click += new System.EventHandler(this.btnSendData_Click);
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(150, 190);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 17);
            this.label14.TabIndex = 44;
            this.label14.Text = "modem =";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.tbSeverPort);
            this.groupBox15.Controls.Add(this.label15);
            this.groupBox15.Controls.Add(this.tbSeverIP);
            this.groupBox15.Controls.Add(this.label17);
            this.groupBox15.Controls.Add(this.btnDelRemoteCSE);
            this.groupBox15.Controls.Add(this.btnSetRemoteCSE);
            this.groupBox15.Controls.Add(this.btnGetRemoteCSE);
            this.groupBox15.Location = new System.Drawing.Point(11, 138);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(458, 105);
            this.groupBox15.TabIndex = 46;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "CSE";
            // 
            // tbSeverPort
            // 
            this.tbSeverPort.Location = new System.Drawing.Point(99, 74);
            this.tbSeverPort.Name = "tbSeverPort";
            this.tbSeverPort.Size = new System.Drawing.Size(205, 21);
            this.tbSeverPort.TabIndex = 14;
            this.tbSeverPort.Text = "8180";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(6, 73);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(94, 22);
            this.label15.TabIndex = 13;
            this.label15.Text = "서비스서버 port";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbSeverIP
            // 
            this.tbSeverIP.Location = new System.Drawing.Point(98, 49);
            this.tbSeverIP.Name = "tbSeverIP";
            this.tbSeverIP.Size = new System.Drawing.Size(206, 21);
            this.tbSeverIP.TabIndex = 12;
            this.tbSeverIP.Text = "http://172.17.224.57";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(5, 48);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(94, 22);
            this.label17.TabIndex = 11;
            this.label17.Text = "서비스서버 IP";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnDelRemoteCSE
            // 
            this.btnDelRemoteCSE.Location = new System.Drawing.Point(176, 20);
            this.btnDelRemoteCSE.Name = "btnDelRemoteCSE";
            this.btnDelRemoteCSE.Size = new System.Drawing.Size(118, 23);
            this.btnDelRemoteCSE.TabIndex = 2;
            this.btnDelRemoteCSE.Text = "CSR 삭제";
            this.btnDelRemoteCSE.UseVisualStyleBackColor = true;
            this.btnDelRemoteCSE.Click += new System.EventHandler(this.btnDelRemoteCSE_Click);
            // 
            // btnSetRemoteCSE
            // 
            this.btnSetRemoteCSE.Location = new System.Drawing.Point(323, 48);
            this.btnSetRemoteCSE.Name = "btnSetRemoteCSE";
            this.btnSetRemoteCSE.Size = new System.Drawing.Size(127, 46);
            this.btnSetRemoteCSE.TabIndex = 0;
            this.btnSetRemoteCSE.Text = "CSR 생성";
            this.btnSetRemoteCSE.UseVisualStyleBackColor = true;
            this.btnSetRemoteCSE.Click += new System.EventHandler(this.btnSetRemoteCSE_Click);
            // 
            // btnGetRemoteCSE
            // 
            this.btnGetRemoteCSE.Location = new System.Drawing.Point(7, 20);
            this.btnGetRemoteCSE.Name = "btnGetRemoteCSE";
            this.btnGetRemoteCSE.Size = new System.Drawing.Size(119, 23);
            this.btnGetRemoteCSE.TabIndex = 0;
            this.btnGetRemoteCSE.Text = "CSR 조회";
            this.btnGetRemoteCSE.UseVisualStyleBackColor = true;
            this.btnGetRemoteCSE.Click += new System.EventHandler(this.btnGetRemoteCSE_Click);
            // 
            // btnMEFAuth
            // 
            this.btnMEFAuth.Location = new System.Drawing.Point(273, 24);
            this.btnMEFAuth.Name = "btnMEFAuth";
            this.btnMEFAuth.Size = new System.Drawing.Size(110, 74);
            this.btnMEFAuth.TabIndex = 0;
            this.btnMEFAuth.Text = "MEF 인증";
            this.btnMEFAuth.UseVisualStyleBackColor = true;
            this.btnMEFAuth.Click += new System.EventHandler(this.btnMEFAuth_Click);
            // 
            // tbSvcCd
            // 
            this.tbSvcCd.Location = new System.Drawing.Point(116, 24);
            this.tbSvcCd.Name = "tbSvcCd";
            this.tbSvcCd.Size = new System.Drawing.Size(67, 21);
            this.tbSvcCd.TabIndex = 34;
            this.tbSvcCd.Text = "CATO";
            this.tbSvcCd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbSvcCd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSvcCd_KeyDown);
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(24, 57);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(86, 16);
            this.label28.TabIndex = 6;
            this.label28.Text = "서버 SEQ";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label31
            // 
            this.label31.Location = new System.Drawing.Point(24, 24);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(86, 16);
            this.label31.TabIndex = 6;
            this.label31.Text = "서비스코드";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbSvcSvrCd
            // 
            this.tbSvcSvrCd.Location = new System.Drawing.Point(116, 51);
            this.tbSvcSvrCd.Name = "tbSvcSvrCd";
            this.tbSvcSvrCd.Size = new System.Drawing.Size(100, 21);
            this.tbSvcSvrCd.TabIndex = 7;
            this.tbSvcSvrCd.Text = "111";
            // 
            // label33
            // 
            this.label33.Location = new System.Drawing.Point(24, 82);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(86, 16);
            this.label33.TabIndex = 6;
            this.label33.Text = "서버 NUM";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbSvcSvrNum
            // 
            this.tbSvcSvrNum.Location = new System.Drawing.Point(116, 81);
            this.tbSvcSvrNum.Name = "tbSvcSvrNum";
            this.tbSvcSvrNum.Size = new System.Drawing.Size(100, 21);
            this.tbSvcSvrNum.TabIndex = 7;
            this.tbSvcSvrNum.Text = "1";
            // 
            // tabLOG
            // 
            this.tabLOG.Controls.Add(this.label49);
            this.tabLOG.Controls.Add(this.label48);
            this.tabLOG.Controls.Add(this.dateTimePicker1);
            this.tabLOG.Controls.Add(this.label18);
            this.tabLOG.Controls.Add(this.label16);
            this.tabLOG.Controls.Add(this.button127);
            this.tabLOG.Controls.Add(this.label27);
            this.tabLOG.Controls.Add(this.tBResultCode);
            this.tabLOG.Controls.Add(this.button126);
            this.tabLOG.Controls.Add(this.button122);
            this.tabLOG.Controls.Add(this.label19);
            this.tabLOG.Controls.Add(this.textBox94);
            this.tabLOG.Controls.Add(this.tbDeviceCTN);
            this.tabLOG.Controls.Add(this.label26);
            this.tabLOG.Controls.Add(this.label24);
            this.tabLOG.Controls.Add(this.label22);
            this.tabLOG.Controls.Add(this.button123);
            this.tabLOG.Controls.Add(this.listBox3);
            this.tabLOG.Controls.Add(this.comboBox1);
            this.tabLOG.Controls.Add(this.textBox95);
            this.tabLOG.Controls.Add(this.label12);
            this.tabLOG.Controls.Add(this.listBox1);
            this.tabLOG.Controls.Add(this.btnGetLogList);
            this.tabLOG.Controls.Add(this.button124);
            this.tabLOG.Controls.Add(this.label21);
            this.tabLOG.Controls.Add(this.listBox2);
            this.tabLOG.Controls.Add(this.label20);
            this.tabLOG.Location = new System.Drawing.Point(4, 22);
            this.tabLOG.Name = "tabLOG";
            this.tabLOG.Size = new System.Drawing.Size(1125, 765);
            this.tabLOG.TabIndex = 7;
            this.tabLOG.Text = "Platform LOG";
            this.tabLOG.UseVisualStyleBackColor = true;
            // 
            // label49
            // 
            this.label49.Location = new System.Drawing.Point(530, 43);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(94, 22);
            this.label49.TabIndex = 76;
            this.label49.Text = "/";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label48
            // 
            this.label48.Location = new System.Drawing.Point(430, 43);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(94, 22);
            this.label48.TabIndex = 75;
            this.label48.Text = "CellID 정보 : ";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker1.Location = new System.Drawing.Point(768, 37);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(116, 21);
            this.dateTimePicker1.TabIndex = 74;
            this.dateTimePicker1.Value = new System.DateTime(2021, 3, 22, 9, 17, 8, 0);
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(56, 12);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(94, 22);
            this.label18.TabIndex = 73;
            this.label18.Text = "Platform 종류";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(55, 40);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(94, 22);
            this.label16.TabIndex = 72;
            this.label16.Text = "CTN";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button127
            // 
            this.button127.Location = new System.Drawing.Point(935, 9);
            this.button127.Name = "button127";
            this.button127.Size = new System.Drawing.Size(126, 23);
            this.button127.TabIndex = 70;
            this.button127.Text = "Server 로그 조회";
            this.button127.UseVisualStyleBackColor = true;
            this.button127.Click += new System.EventHandler(this.button127_Click);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(817, 323);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(37, 12);
            this.label27.TabIndex = 69;
            this.label27.Text = "LogID";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tBResultCode
            // 
            this.tBResultCode.Location = new System.Drawing.Point(685, 89);
            this.tBResultCode.Name = "tBResultCode";
            this.tBResultCode.Size = new System.Drawing.Size(88, 21);
            this.tBResultCode.TabIndex = 53;
            this.tBResultCode.Text = "20000000";
            this.tBResultCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button126
            // 
            this.button126.Location = new System.Drawing.Point(782, 91);
            this.button126.Name = "button126";
            this.button126.Size = new System.Drawing.Size(82, 19);
            this.button126.TabIndex = 52;
            this.button126.Text = "코드조회";
            this.button126.UseVisualStyleBackColor = true;
            this.button126.Click += new System.EventHandler(this.button126_Click);
            // 
            // button122
            // 
            this.button122.Location = new System.Drawing.Point(983, 318);
            this.button122.Name = "button122";
            this.button122.Size = new System.Drawing.Size(121, 20);
            this.button122.TabIndex = 68;
            this.button122.Text = "상세 로그 조회";
            this.button122.UseVisualStyleBackColor = true;
            this.button122.Click += new System.EventHandler(this.button122_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(602, 96);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(82, 12);
            this.label19.TabIndex = 51;
            this.label19.Text = "ResultCode : ";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox94
            // 
            this.textBox94.Location = new System.Drawing.Point(873, 319);
            this.textBox94.Name = "textBox94";
            this.textBox94.Size = new System.Drawing.Size(104, 21);
            this.textBox94.TabIndex = 67;
            this.textBox94.Text = "12345678";
            // 
            // tbDeviceCTN
            // 
            this.tbDeviceCTN.Location = new System.Drawing.Point(155, 40);
            this.tbDeviceCTN.Name = "tbDeviceCTN";
            this.tbDeviceCTN.Size = new System.Drawing.Size(114, 21);
            this.tbDeviceCTN.TabIndex = 40;
            this.tbDeviceCTN.Text = "01222991234";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(821, 139);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(37, 12);
            this.label26.TabIndex = 66;
            this.label26.Text = "LogID";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(562, 350);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(302, 12);
            this.label24.TabIndex = 61;
            this.label24.Text = "  서버       TYPE      Method                   Description";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label22.Location = new System.Drawing.Point(572, 322);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(28, 12);
            this.label22.TabIndex = 60;
            this.label22.Text = "ID : ";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button123
            // 
            this.button123.Location = new System.Drawing.Point(983, 134);
            this.button123.Name = "button123";
            this.button123.Size = new System.Drawing.Size(121, 20);
            this.button123.TabIndex = 65;
            this.button123.Text = "LOGID 로그 조회";
            this.button123.UseVisualStyleBackColor = true;
            this.button123.Click += new System.EventHandler(this.button123_Click);
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 12;
            this.listBox3.Location = new System.Drawing.Point(561, 368);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(543, 364);
            this.listBox3.TabIndex = 58;
            this.listBox3.SelectedIndexChanged += new System.EventHandler(this.listBox3_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "oneM2M",
            "LwM2M",
            "미지원"});
            this.comboBox1.Location = new System.Drawing.Point(156, 12);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(114, 20);
            this.comboBox1.TabIndex = 30;
            this.comboBox1.Text = "LwM2M";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBox95
            // 
            this.textBox95.Location = new System.Drawing.Point(873, 135);
            this.textBox95.Name = "textBox95";
            this.textBox95.Size = new System.Drawing.Size(104, 21);
            this.textBox95.TabIndex = 64;
            this.textBox95.Text = "12345678";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 81);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(393, 12);
            this.label12.TabIndex = 50;
            this.label12.Text = "요청시간      ID      Event Description    ResultCode  결과 (요청  내용)";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(6, 96);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(543, 640);
            this.listBox1.TabIndex = 44;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // btnGetLogList
            // 
            this.btnGetLogList.Location = new System.Drawing.Point(935, 38);
            this.btnGetLogList.Name = "btnGetLogList";
            this.btnGetLogList.Size = new System.Drawing.Size(132, 23);
            this.btnGetLogList.TabIndex = 43;
            this.btnGetLogList.Text = "Device 로그 조회";
            this.btnGetLogList.UseVisualStyleBackColor = true;
            this.btnGetLogList.Click += new System.EventHandler(this.btnGetLogList_Click);
            // 
            // button124
            // 
            this.button124.Location = new System.Drawing.Point(281, 43);
            this.button124.Name = "button124";
            this.button124.Size = new System.Drawing.Size(117, 19);
            this.button124.TabIndex = 55;
            this.button124.Text = "Device 정보 조회";
            this.button124.UseVisualStyleBackColor = true;
            this.button124.Click += new System.EventHandler(this.button124_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label21.Location = new System.Drawing.Point(568, 139);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(84, 12);
            this.label21.TabIndex = 59;
            this.label21.Text = "서버로그  ID : ";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 12;
            this.listBox2.Location = new System.Drawing.Point(566, 187);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(543, 124);
            this.listBox2.TabIndex = 56;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(567, 167);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(279, 12);
            this.label20.TabIndex = 57;
            this.label20.Text = "요청시간      ID      ResultCode  결과 (요청  내용)";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabTC
            // 
            this.tabTC.Controls.Add(this.label5);
            this.tabTC.Controls.Add(this.label4);
            this.tabTC.Controls.Add(this.listView2);
            this.tabTC.Controls.Add(this.listView1);
            this.tabTC.Controls.Add(this.gbTCResult);
            this.tabTC.Location = new System.Drawing.Point(4, 22);
            this.tabTC.Name = "tabTC";
            this.tabTC.Size = new System.Drawing.Size(1125, 765);
            this.tabTC.TabIndex = 8;
            this.tabTC.Text = "시험절차서";
            this.tabTC.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(587, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(289, 25);
            this.label5.TabIndex = 48;
            this.label5.Text = "LwM2M 디바이스 시험절차서 결과";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(45, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(303, 25);
            this.label4.TabIndex = 47;
            this.label4.Text = "OneM2M 디바이스 시험절차서 결과";
            // 
            // listView2
            // 
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(565, 60);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(523, 257);
            this.listView2.TabIndex = 46;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(8, 60);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(523, 611);
            this.listView1.TabIndex = 45;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // gbTCResult
            // 
            this.gbTCResult.Controls.Add(this.tbTCResult);
            this.gbTCResult.Location = new System.Drawing.Point(565, 338);
            this.gbTCResult.Name = "gbTCResult";
            this.gbTCResult.Size = new System.Drawing.Size(523, 401);
            this.gbTCResult.TabIndex = 38;
            this.gbTCResult.TabStop = false;
            this.gbTCResult.Text = "TestCase Message";
            // 
            // tbTCResult
            // 
            this.tbTCResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbTCResult.Location = new System.Drawing.Point(3, 17);
            this.tbTCResult.Multiline = true;
            this.tbTCResult.Name = "tbTCResult";
            this.tbTCResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbTCResult.Size = new System.Drawing.Size(517, 381);
            this.tbTCResult.TabIndex = 35;
            // 
            // webpage
            // 
            this.webpage.Controls.Add(this.webBrowser1);
            this.webpage.Location = new System.Drawing.Point(4, 22);
            this.webpage.Name = "webpage";
            this.webpage.Size = new System.Drawing.Size(1125, 765);
            this.webpage.TabIndex = 9;
            this.webpage.Text = "Admin page";
            this.webpage.UseVisualStyleBackColor = true;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1125, 765);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.Url = new System.Uri("", System.UriKind.Relative);
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // button81
            // 
            this.button81.Location = new System.Drawing.Point(1036, 796);
            this.button81.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button81.Name = "button81";
            this.button81.Size = new System.Drawing.Size(72, 24);
            this.button81.TabIndex = 41;
            this.button81.Text = "엑셀 쓰기";
            this.button81.UseVisualStyleBackColor = true;
            this.button81.Click += new System.EventHandler(this.button63_Click);
            // 
            // button72
            // 
            this.button72.Location = new System.Drawing.Point(933, 796);
            this.button72.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button72.Name = "button72";
            this.button72.Size = new System.Drawing.Size(81, 24);
            this.button72.TabIndex = 42;
            this.button72.Text = "엑셀 읽기";
            this.button72.UseVisualStyleBackColor = true;
            this.button72.Click += new System.EventHandler(this.button62_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(307, 800);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 57;
            this.label6.Text = "통신 상태 :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbActionState
            // 
            this.lbActionState.AutoSize = true;
            this.lbActionState.Location = new System.Drawing.Point(378, 800);
            this.lbActionState.Name = "lbActionState";
            this.lbActionState.Size = new System.Drawing.Size(43, 12);
            this.lbActionState.TabIndex = 58;
            this.lbActionState.Text = "closed";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(456, 800);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(101, 12);
            this.label34.TabIndex = 74;
            this.label34.Text = "디바이스 모델명 :";
            // 
            // tBoxDeviceSN
            // 
            this.tBoxDeviceSN.Location = new System.Drawing.Point(813, 796);
            this.tBoxDeviceSN.Name = "tBoxDeviceSN";
            this.tBoxDeviceSN.Size = new System.Drawing.Size(100, 21);
            this.tBoxDeviceSN.TabIndex = 59;
            this.tBoxDeviceSN.Text = "123456";
            this.tBoxDeviceSN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tBoxDeviceModel
            // 
            this.tBoxDeviceModel.Location = new System.Drawing.Point(563, 797);
            this.tBoxDeviceModel.Name = "tBoxDeviceModel";
            this.tBoxDeviceModel.Size = new System.Drawing.Size(98, 21);
            this.tBoxDeviceModel.TabIndex = 36;
            this.tBoxDeviceModel.Text = "LWEMG";
            this.tBoxDeviceModel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(694, 800);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(113, 12);
            this.label32.TabIndex = 76;
            this.label32.Text = "디바이스 일련번호 :";
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 829);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(1920, 1066);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(750, 522);
            this.Name = "Form1";
            this.Text = "LGU+ PCT";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabCOM.ResumeLayout(false);
            this.tabCOM.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.gbDeviceLog.ResumeLayout(false);
            this.gbDeviceLog.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.tabSMST.ResumeLayout(false);
            this.pnSetting.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPROXY.ResumeLayout(false);
            this.pnProxy.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabOneM2M.ResumeLayout(false);
            this.groupBox21.ResumeLayout(false);
            this.groupBox21.PerformLayout();
            this.groupBox20.ResumeLayout(false);
            this.groupBox19.ResumeLayout(false);
            this.groupBox19.PerformLayout();
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.gbOneM2MDevice.ResumeLayout(false);
            this.gbOneM2MDevice.PerformLayout();
            this.tabLwM2M.ResumeLayout(false);
            this.tabLwM2M.PerformLayout();
            this.groupBox22.ResumeLayout(false);
            this.groupBox22.PerformLayout();
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.tabServer.ResumeLayout(false);
            this.tabServer.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.tabLOG.ResumeLayout(false);
            this.tabLOG.PerformLayout();
            this.tabTC.ResumeLayout(false);
            this.tabTC.PerformLayout();
            this.gbTCResult.ResumeLayout(false);
            this.gbTCResult.PerformLayout();
            this.webpage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ComboBox cBoxBaudRate;
        private System.Windows.Forms.ComboBox cBoxCOMPORT;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnModel;
        private System.Windows.Forms.Button btnIMSI;
        private System.Windows.Forms.Button btnManufac;
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
        private System.Windows.Forms.Panel pnProxy;
        private System.Windows.Forms.Button button40;
        private System.Windows.Forms.Button button41;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Button button73;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.Button button54;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.Button button53;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.Button button52;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.Button button51;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.Button button50;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.Button button49;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Button button48;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Button button47;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Button button46;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Button button45;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button37;
        private System.Windows.Forms.Button button38;
        private System.Windows.Forms.Button button39;
        private System.Windows.Forms.Button button42;
        private System.Windows.Forms.Button button44;
        private System.Windows.Forms.TextBox textBox22;
        private System.Windows.Forms.Button button59;
        private System.Windows.Forms.TextBox textBox21;
        private System.Windows.Forms.Button button58;
        private System.Windows.Forms.TextBox textBox20;
        private System.Windows.Forms.Button button57;
        private System.Windows.Forms.TextBox textBox19;
        private System.Windows.Forms.Button button56;
        private System.Windows.Forms.TextBox textBox18;
        private System.Windows.Forms.Button button55;
        private System.Windows.Forms.TextBox textBox17;
        private System.Windows.Forms.Button button43;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button60;
        private System.Windows.Forms.TextBox textBox34;
        private System.Windows.Forms.Button button76;
        private System.Windows.Forms.TextBox textBox35;
        private System.Windows.Forms.Button button77;
        private System.Windows.Forms.TextBox textBox36;
        private System.Windows.Forms.Button button78;
        private System.Windows.Forms.TextBox textBox37;
        private System.Windows.Forms.Button button79;
        private System.Windows.Forms.TextBox textBox39;
        private System.Windows.Forms.TextBox textBox41;
        private System.Windows.Forms.TextBox textBox42;
        private System.Windows.Forms.TextBox textBox43;
        private System.Windows.Forms.Button button82;
        private System.Windows.Forms.Button button84;
        private System.Windows.Forms.Button button85;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button button61;
        private System.Windows.Forms.TextBox textBox25;
        private System.Windows.Forms.Button button64;
        private System.Windows.Forms.TextBox textBox26;
        private System.Windows.Forms.Button button65;
        private System.Windows.Forms.TextBox textBox27;
        private System.Windows.Forms.Button button66;
        private System.Windows.Forms.TextBox textBox28;
        private System.Windows.Forms.TextBox textBox29;
        private System.Windows.Forms.TextBox textBox30;
        private System.Windows.Forms.TextBox textBox31;
        private System.Windows.Forms.TextBox textBox32;
        private System.Windows.Forms.Button button67;
        private System.Windows.Forms.Button button74;
        private System.Windows.Forms.Button button75;
        private System.Windows.Forms.Button button68;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox textBox23;
        private System.Windows.Forms.Button button69;
        private System.Windows.Forms.Button button72;
        private System.Windows.Forms.Button button81;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.TextBox textBox50;
        private System.Windows.Forms.Button button92;
        private System.Windows.Forms.TextBox textBox51;
        private System.Windows.Forms.TextBox textBox52;
        private System.Windows.Forms.TextBox textBox53;
        private System.Windows.Forms.Button button95;
        private System.Windows.Forms.TextBox textBox54;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.TextBox textBox55;
        private System.Windows.Forms.TextBox textBox56;
        private System.Windows.Forms.Button button97;
        private System.Windows.Forms.Button button98;
        private System.Windows.Forms.Button button87;
        private System.Windows.Forms.TextBox textBox69;
        private System.Windows.Forms.Button button108;
        private System.Windows.Forms.TextBox textBox68;
        private System.Windows.Forms.Button button107;
        private System.Windows.Forms.TextBox textBox67;
        private System.Windows.Forms.TextBox textBox66;
        private System.Windows.Forms.Button button105;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.TextBox tBoxDeviceModel;
        private System.Windows.Forms.TextBox tbSvcCd;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.TextBox textBox61;
        private System.Windows.Forms.Button button62;
        private System.Windows.Forms.TextBox textBox60;
        private System.Windows.Forms.Button button101;
        private System.Windows.Forms.TextBox textBox59;
        private System.Windows.Forms.Button button100;
        private System.Windows.Forms.TextBox textBox58;
        private System.Windows.Forms.Button button99;
        private System.Windows.Forms.TextBox textBox57;
        private System.Windows.Forms.TextBox textBox40;
        private System.Windows.Forms.TextBox textBox38;
        private System.Windows.Forms.TextBox textBox33;
        private System.Windows.Forms.TextBox textBox24;
        private System.Windows.Forms.Button button86;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button71;
        private System.Windows.Forms.Button button83;
        private System.Windows.Forms.TextBox textBox44;
        private System.Windows.Forms.Button button88;
        private System.Windows.Forms.TextBox textBox45;
        private System.Windows.Forms.TextBox textBox46;
        private System.Windows.Forms.TextBox textBox47;
        private System.Windows.Forms.TextBox textBox48;
        private System.Windows.Forms.TextBox textBox49;
        private System.Windows.Forms.Button button89;
        private System.Windows.Forms.Button button90;
        private System.Windows.Forms.Button button91;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSMST;
        private System.Windows.Forms.TabPage tabPROXY;
        private System.Windows.Forms.TabPage tabCOM;
        private System.Windows.Forms.TabPage tabOneM2M;
        private System.Windows.Forms.TabPage tabLwM2M;
        private System.Windows.Forms.TabPage tabServer;
        private System.Windows.Forms.TabPage tabLOG;
        private System.Windows.Forms.TextBox lbModemVer;
        private System.Windows.Forms.TextBox textBox89;
        private System.Windows.Forms.TextBox lbIccid;
        private System.Windows.Forms.TextBox textBox87;
        private System.Windows.Forms.TextBox textBox86;
        private System.Windows.Forms.TextBox textBox85;
        private System.Windows.Forms.TextBox tbDeviceCTN;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox tBResultCode;
        private System.Windows.Forms.Button button126;
        private System.Windows.Forms.Button button122;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox textBox94;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button button123;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.TextBox textBox95;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnGetLogList;
        private System.Windows.Forms.Button button124;
        private System.Windows.Forms.Button button125;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button button127;
        private System.Windows.Forms.Button button113;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.Label lbLwM2MRxData;
        private System.Windows.Forms.Button btnDeviceStatusCheck;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnLwM2MData;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.Label lboneM2MRxData;
        private System.Windows.Forms.Button btnDataRetrive;
        private System.Windows.Forms.Button btnSendData;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.TextBox tbSeverPort;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbSeverIP;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnDelRemoteCSE;
        private System.Windows.Forms.Button btnSetRemoteCSE;
        private System.Windows.Forms.Button btnGetRemoteCSE;
        private System.Windows.Forms.Button btnMEFAuth;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox tbSvcSvrCd;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox tbSvcSvrNum;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label lbDevEntityId;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox gbDeviceLog;
        private System.Windows.Forms.TextBox tBoxDataIN;
        private System.Windows.Forms.Button button63;
        private System.Windows.Forms.TextBox textBox64;
        private System.Windows.Forms.TabPage tabTC;
        private System.Windows.Forms.GroupBox gbTCResult;
        private System.Windows.Forms.TextBox tbTCResult;
        private System.Windows.Forms.GroupBox gbOneM2MDevice;
        private System.Windows.Forms.Button btReset;
        private System.Windows.Forms.Button button34;
        private System.Windows.Forms.Button btnoneM2MModuleVer;
        private System.Windows.Forms.Button btnDelSubscript;
        private System.Windows.Forms.Label lbSendedData;
        private System.Windows.Forms.Button btnDelRxContainer;
        private System.Windows.Forms.Button btnSetRxContainer;
        private System.Windows.Forms.Button btnSetSubscript;
        private System.Windows.Forms.Button btnMEFAuthD;
        private System.Windows.Forms.Button btnDeviceUpdateCSR;
        private System.Windows.Forms.Label lboneM2MRcvData;
        private System.Windows.Forms.Button btnRcvDataOneM2M;
        private System.Windows.Forms.Button btnDelDeviceCSR;
        private System.Windows.Forms.Button btnCreateDeviceCSR;
        private System.Windows.Forms.Button btnModemFOTA;
        private System.Windows.Forms.Button btnDeviceFOTA;
        private System.Windows.Forms.Button btnGetDeviceCSR;
        private System.Windows.Forms.Button btnGetCSED;
        private System.Windows.Forms.Button btnSendDataOneM2M;
        private System.Windows.Forms.Button btnoneM2MFullTest;
        private System.Windows.Forms.Label lbActionState;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDeviceVerLwM2M;
        private System.Windows.Forms.Button btnDeregister;
        private System.Windows.Forms.Button btnBootstrap;
        private System.Windows.Forms.Label lbLwM2MRcvData;
        private System.Windows.Forms.Label lbDevLwM2MData;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBoxDeviceVer;
        private System.Windows.Forms.TextBox tBoxDeviceSN;
        private System.Windows.Forms.Label lbDirectRxData;
        private System.Windows.Forms.Label lbmodemfwrver;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lbdevicever;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnDeviceCheck;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox textBox62;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox textBox63;
        private System.Windows.Forms.TextBox textBox71;
        private System.Windows.Forms.Button button35;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button93;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Button button94;
        private System.Windows.Forms.Button button96;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.TextBox tbOneM2MDataIN;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.TextBox tbLwM2MDataIN;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button104;
        private System.Windows.Forms.Button button102;
        private System.Windows.Forms.Button button80;
        private System.Windows.Forms.Button button70;
        private System.Windows.Forms.Button button103;
        private System.Windows.Forms.GroupBox groupBox21;
        private System.Windows.Forms.GroupBox groupBox20;
        private System.Windows.Forms.GroupBox groupBox19;
        private System.Windows.Forms.GroupBox groupBox18;
        private System.Windows.Forms.Button button112;
        private System.Windows.Forms.Button button111;
        private System.Windows.Forms.Button button110;
        private System.Windows.Forms.Button button109;
        private System.Windows.Forms.Button button106;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TabPage webpage;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button114;
        private System.Windows.Forms.TextBox textBox73;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.TextBox textBox72;
        private System.Windows.Forms.Button button116;
        private System.Windows.Forms.Button button115;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.Button button117;
        private System.Windows.Forms.GroupBox groupBox22;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TextBox textBox70;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox65;
        private System.Windows.Forms.TextBox textBox74;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.TextBox textBox75;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.TextBox textBox76;
    }
}

