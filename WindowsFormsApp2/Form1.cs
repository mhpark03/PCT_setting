using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Security.Cryptography;
using System.Xml;
using System.Xml.Linq;
using ExcelLibrary.SpreadSheet;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private enum states
        {
            booting,
            idle,
            getmodel,
            getmanufac,
            getimsi,
            getimei,
            geticcid,
            autogetmodel,
            autogetmodelgmm,
            autogetmanufac,
            autogetimsi,
            autogetimei,
            autogeticcid,
            bootstrap,
            setserverinfo,
            setserverinfotpb23,
            setmefserverinfo,
            sethttpserverinfo,
            setncdp,
            setservertype,
            setepns,
            setmbsps,
            setAutoBS,
            register,
            deregister,
            sendLWM2Mdata,
            receiveLWM2Mdata,
            downloadMDLFOTA,
            updateMDLFOTA,
            lwm2mreset,
            sendmsgstr,
            sendmsghex,
            sendmsgver,

            disable_bg96,
            enable_bg96,
            setcdp_bg96,

            holdoffbc95,
            lwm2mresetbc95,
            getsvripbc95,
            setsvrbsbc95,
            setsvripbc95,
            actsetsvrbsbc95,
            actsetsvripbc95,
            autosetsvrbsbc95,
            autosetsvripbc95,
            getepnsbc95,
            setepnsbc95,
            autosetepnsbc95,
            getmbspsbc95,
            setmbspsbc95,
            autosetmbspsbc95,
            bootstrapbc95,
            rebootbc95,

            sendonemsgstr,

            getonem2mmode,
            setonem2mmode,
            setmefauthnt,
            fotamefauthnt,
            mfotamefauth,
            getCSEbase,
            getremoteCSE,
            setremoteCSE,
            updateremoteCSE,
            setcontainer,
            setsubscript,
            getonem2mdata,

            setcereg,
            setceregtpb23,
            getcereg,
            reset,

            getimeitpb23,
            geticcidtpb23,
            autogetimeitpb23,
            autogeticcidtpb23,
            resettpb23,
            bootstrapmodetpb23,
            setepnstpb23,
            setmbspstpb23,
            bootstraptpb23,
            registertpb23,
            deregistertpb23,
            registerbc95,
            deregisterbc95,
            sendLWM2Mdatatpb23,
            receiveLWM2Mdatatpb23,
            downloadMDLFOTAtpb23,
            updateMDLFOTAtpb23,
            lwm2mresettpb23,
            sendmsgstrtpb23,
            sendmsgstrbc95,
            sendmsghextpb23,
            sendmsgvertpb23,
            sendmsgverbc95,

            geticcidamtel,
            autogeticcidamtel,

            geticcidme,
            autogeticcidme,
            setepnsme,
            sendmsgverme,

            geticcidlg,
            autogeticcidlg,

            geticcidbc95,
            autogeticcidbc95,

            getmodemSvrVer,
            modemFWUPfinish,
            modemFWUPfinishLTE,
            modemFWUPstart,

            getdeviceSvrVer,
            setdeviceSvrVer,
            deviceFWUPfinish,
            deviceFWUPstart,

            catm1check,
            catm1set,
            catm1apn1,
            catm1apn2,
            catm1psmode,
            rfoff,
            rfon,
            rfreset,

            catm1imscheck,
            catm1imsset,
            catm1imsapn1,
            catm1imsapn2,
            catm1imsmode,
            catm1imspco,

            nbcheck,
            nbset,
            nbapn1,
            nbapn2,
            nbpsmode,

            getmodemver,
            autogetmodemver,
            getmodemvernt,
            autogetmodemvernt,
            getmodemverbc95,
            autogetmodemverbc95,
            getNWmode,
            autogetNWmode,

            testatcmd,
            atdtatcmd,
        }

        string dataIN = string.Empty;
        string nextcommand = string.Empty;    //OK를 받은 후 전송할 명령어가 존재하는 경우
                                    //예를들어 +CEREG와 같이 OK를 포함한 응답 값을 받은 경우 OK처리 후에 명령어를 전송해야 한다
                                    // states 값을 바꾸고 명령어를 전송하면 명령의 응답을 받기전 이전에 받았던 OK에 동작할 수 있다.
        string nextresponse = string.Empty;   //응답에 prefix가 존재하는 경우
        string commmode = "catm1";
        string imsmode = "no";
        string actionState = "idle";
        Device dev = new Device();

        Dictionary<string, string> commands = new Dictionary<string, string>();
        Dictionary<char, int> bcdvalues = new Dictionary<char, int>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            if(ports.Length == 0)
            {
                logPrintInTextBox("연결 가능한 COM PORT가 없습니다.", "");
            }
            else
            {
                cBoxCOMPORT.Items.Clear();
                cBoxCOMPORT.Items.AddRange(ports);
                cBoxCOMPORT.SelectedIndex = 0;
            }

            bcdvalues.Add('0', 0);
            bcdvalues.Add('1', 1);
            bcdvalues.Add('2', 2);
            bcdvalues.Add('3', 3);
            bcdvalues.Add('4', 4);
            bcdvalues.Add('5', 5);
            bcdvalues.Add('6', 6);
            bcdvalues.Add('7', 7);
            bcdvalues.Add('8', 8);
            bcdvalues.Add('9', 9);
            bcdvalues.Add('A', 10);
            bcdvalues.Add('B', 11);
            bcdvalues.Add('C', 12);
            bcdvalues.Add('D', 13);
            bcdvalues.Add('E', 14);
            bcdvalues.Add('F', 15);
            bcdvalues.Add('a', 10);
            bcdvalues.Add('b', 11);
            bcdvalues.Add('c', 12);
            bcdvalues.Add('d', 13);
            bcdvalues.Add('e', 14);
            bcdvalues.Add('f', 15);

            commands.Add("getimsi", "AT+CIMI");
            commands.Add("geticcid", "AT+ICCID");
            commands.Add("getimei", "AT+GSN");
            commands.Add("geticcidtpb23", "AT+MUICCID");
            commands.Add("geticcidlg", "AT+MUICCID=?");
            commands.Add("geticcidme", "AT+ICCID");
            commands.Add("geticcidamtel", "AT@ICCID?");
            commands.Add("geticcidbc95", "AT+NCCID");
            commands.Add("getimeitpb23", "AT+CGSN=1");
            commands.Add("getmodel", "AT+CGMM");
            commands.Add("getmanufac", "AT+CGMI");
            commands.Add("setcereg", "AT+CEREG=1");
            commands.Add("setceregtpb23", "AT+CEREG=3");
            commands.Add("getcereg", "AT+CEREG?");
            commands.Add("reset", "AT+CFUN=3,3");

            commands.Add("resettpb23", "AT+NRB");

            commands.Add("autogetimsi", "AT+CIMI");
            commands.Add("autogeticcid", "AT+ICCID");
            commands.Add("autogetimei", "AT+GSN");
            commands.Add("autogeticcidtpb23", "AT+MUICCID");
            commands.Add("autogeticcidamtel", "AT@ICCID?");
            commands.Add("autogeticcidme", "AT+ICCID");
            commands.Add("autogeticcidlg", "AT+MUICCID=?");
            commands.Add("autogeticcidbc95", "AT+NCCID");
            commands.Add("autogetimeitpb23", "AT+CGSN=1");
            commands.Add("autogetmodel", "AT+CGMM");
            commands.Add("autogetmodelgmm", "AT+GMM");
            commands.Add("autogetmanufac", "AT+CGMI");

            commands.Add("bootstrap", "AT+QLWM2M=\"bootstrap\",1");
            commands.Add("setserverinfo", "AT+QLWM2M=\"cdp\",");
            commands.Add("setservertype", "AT+QLWM2M=\"select\",2");
            commands.Add("setepns", "AT+QLWM2M=\"epns\",0,\"");
            commands.Add("setmbsps", "AT+QLWM2M=\"mbsps\",\"");
            commands.Add("setAutoBS", "AT+QLWM2M=\"enable\",");
            commands.Add("register", "AT+QLWM2M=\"register\"");
            commands.Add("deregister", "AT+QLWM2M=\"deregister\"");
            commands.Add("lwm2mreset", "AT+QLWM2M=\"reset\"");
            commands.Add("sendmsgstr", "AT+QLWM2M=\"uldata\",10250,");
            commands.Add("sendmsghex", "AT+QLWM2M=\"ulhex\",10250,");
            commands.Add("sendmsgver", "AT+QLWM2M=\"uldata\",26241,");

            commands.Add("disable_bg96", "AT+QLWM2M=\"enable\",0");
            commands.Add("enable_bg96", "AT+QLWM2M=\"enable\",1");
            commands.Add("setcdp_bg96", "AT+QLWM2M=\"cdp\",");

            commands.Add("sendonemsgstr", "AT$OM_C_INS_REQ=");

            commands.Add("getonem2mmode", "AT$LGTMPF?");
            commands.Add("setonem2mmode", "AT$LGTMPF=5");
            commands.Add("setmefauthnt", "AT$OM_AUTH_REQ=");
            commands.Add("fotamefauthnt", "AT$OM_AUTH_REQ=");
            commands.Add("mfotamefauth", "AT$OM_AUTH_REQ=");
            commands.Add("getCSEbase", "AT$OM_B_CSE_REQ");
            commands.Add("getremoteCSE", "AT$OM_R_CSE_REQ");
            commands.Add("setremoteCSE", "AT$OM_C_CSE_REQ");
            commands.Add("updateremoteCSE", "AT$OM_U_CSE_REQ");
            commands.Add("setcontainer", "AT$OM_C_CON_REQ=");
            commands.Add("setsubscript", "AT$OM_C_SUB_REQ=");
            commands.Add("getonem2mdata", "AT$OM_R_INS_REQ=");

            commands.Add("setserverinfotpb23", "AT+NCDP=");
            commands.Add("setncdp", "AT+NCDP=");
            commands.Add("bootstrapmodetpb23", "AT+MBOOTSTRAPMODE=1");
            commands.Add("setepnstpb23", "AT+MLWEPNS=ASN_CSE-D-");
            commands.Add("setmbspstpb23", "AT+MLWMBSPS=serviceCode=");
            commands.Add("bootstraptpb23", "AT+MLWGOBOOTSTRAP=1");
            commands.Add("registertpb23", "AT+MLWSREGIND=0");
            commands.Add("deregistertpb23", "AT+MLWSREGIND=1");
            commands.Add("registerbc95", "AT+QLWSREGIND=0");
            commands.Add("deregisterbc95", "AT+QLWSREGIND=1");
            commands.Add("lwm2mresettpb23", "AT+FATORYRESET=0");
            commands.Add("sendmsgstrtpb23", "AT+MLWULDATA=");
            commands.Add("sendmsgstbc95", "AT+QLWULDATA=0,");
            commands.Add("sendmsgvertpb23", "AT+MLWULDATA=1,");
            commands.Add("sendmsgverbc95", "AT+QLWULDATA=1,");

            commands.Add("holdoffbc95", "AT+QBOOTSTRAPHOLDOFF=0");
            commands.Add("lwm2mresetbc95", "AT+QREGSWT=2");
            commands.Add("getsvripbc95", "AT+QLWSERVERIP?");
            commands.Add("setsvrbsbc95", "AT+QLWSERVERIP=BS,");
            commands.Add("setsvripbc95", "AT+QLWSERVERIP=LWM2M,");
            commands.Add("autosetsvrbsbc95", "AT+QLWSERVERIP=BS,");
            commands.Add("autosetsvripbc95", "AT+QLWSERVERIP=LWM2M,");
            commands.Add("getepnsbc95", "AT+QLWEPNS?");
            commands.Add("setepnsbc95", "AT+QLWEPNS=0,");
            commands.Add("getmbspsbc95", "AT+QLWMBSPS?");
            commands.Add("setmbspsbc95", "AT+QLWMBSPS=");
            commands.Add("bootstrapbc95", "AT+QREGSWT=1");      // auto (manual=0)
            commands.Add("rebootbc95", "AT+NRB");

            commands.Add("setepnsme", "AT+MLWGENEPNS=");
            commands.Add("sendmsgverme", "AT+MLWDFULDATA=");

            commands.Add("setmefserverinfo", "AT$OM_SVR_INFO=1,");
            commands.Add("sethttpserverinfo", "AT$OM_SVR_INFO=2,");

            commands.Add("getmodemSvrVer", "AT$OM_MODEM_FWUP_REQ");
            commands.Add("setmodemver", "AT$OM_C_MODEM_FWUP_REQ");
            commands.Add("modemFWUPfinish", "AT$OM_MODEM_FWUP_FINISH");
            commands.Add("modemFWUPfinishLTE", "AT$OM_MOD_FWUP_FINISH");
            commands.Add("modemFWUPstart", "AT$OM_MODEM_FWUP_START");

            commands.Add("getdeviceSvrVer", "AT$OM_DEV_FWUP_REQ");
            commands.Add("setdeviceSrvver", "AT$OM_C_DEV_FWUP_REQ");
            commands.Add("deviceFWUPfinish", "AT$OM_DEV_FWUP_FINISH");
            commands.Add("deviceFWUPstart", "AT$OM_DEV_FWUP_START");

            commands.Add("catm1check","AT+QCFG=\"iotopmode\"");
            commands.Add("catm1set", "AT+QCFG=\"iotopmode\",0");
            commands.Add("catm1apn1", "AT+CGDCONT=1,\"IPV4V6\",\"m2m-catm1.default.lguplus.co.kr\"");
            commands.Add("catm1apn2", "AT+CGDCONT=2");
            commands.Add("catm1psmode", "AT+QCFG=\"servicedomain\",1");
            commands.Add("rfoff", "AT+CFUN=0");
            commands.Add("rfon", "AT+CFUN=1");
            commands.Add("rfreset", "AT+CFUN=1,1");

            commands.Add("catm1imsset", "AT+QCFG=\"iotopmode\",0");
            commands.Add("catm1imsapn1", "AT+CGDCONT=1,\"IPV4V6\",\"m2m-catm1.default.lguplus.co.kr\"");
            commands.Add("catm1imsapn2", "AT+CGDCONT=2,\"IPV4V6\",\"imsv6-m2m.lguplus.co.kr\"");
            commands.Add("catm1imsmode", "AT+QCFG=\"servicedomain\",2");
            commands.Add("catm1imspco", "AT$QCPDPIMSCFGE=2,1,0,1");

            commands.Add("getNWmode", "AT+QCFG=\"iotopmode\"");
            commands.Add("autogetNWmode", "AT+QCFG=\"iotopmode\"");

            commands.Add("nbset", "AT+QCFG=\"iotopmode\",1");
            commands.Add("nbapn1", "AT+CGDCONT=1,\"IPV4V6\",\"\",\"0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0\",0,0,0,0");
            commands.Add("nbapn2", "AT+CGDCONT=2");
            commands.Add("nbpsmode", "AT+QCFG=\"servicedomain\",1");

            commands.Add("getmodemver", "AT+GMR");
            commands.Add("autogetmodemver", "AT+GMR");
            commands.Add("getmodemverbc95", "AT+CGMR");
            commands.Add("autogetmodemverbc95", "AT+CGMR");
            commands.Add("getmodemvernt", "AT*ST*INFO?");
            commands.Add("autogetmodemvernt", "AT*ST*INFO?");

            commmode = "catm1";
            button31.BackColor = SystemColors.Control;
            button33.BackColor = SystemColors.ButtonHighlight;
            button32.BackColor = SystemColors.Control;
            button68.Enabled = true;

            groupBox2.Enabled = false;
            groupBox6.Enabled = false;
            groupBox5.Enabled = false;
        }

        private void doOpenComPort()
        {
            if (!serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.PortName = cBoxCOMPORT.Text;
                    serialPort1.BaudRate = Convert.ToInt32(cBoxBaudRate.Text);
                    serialPort1.DataBits = (int)8;
                    serialPort1.StopBits = StopBits.One;
                    serialPort1.Parity = Parity.None;
                    serialPort1.DtrEnable = false;
                    serialPort1.RtsEnable = false;
                    serialPort1.ReadTimeout = (int)500;
                    serialPort1.WriteTimeout = (int)500;

                    serialPort1.Open();
                    progressBar1.Value = 50;
                    groupBox1.Enabled = true;
                    logPrintInTextBox("COM PORT가 연결 되었습니다.", "");
                }
                catch (Exception err)
                {
                    logPrintInTextBox(err.Message, "");

                    this.doCloseComPort();
                }
            }

        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                this.doCloseComPort();
            }
        }

        private void doCloseComPort()
        {
            progressBar1.Value = 0;
            groupBox1.Enabled = false;
            serialPort1.Close();
            logPrintInTextBox("COM PORT가 해제 되었습니다.","");

        }

        private void ProgressBar1_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                this.doCloseComPort();
            }
            else
            {
                this.doOpenComPort();
            }

        }

        private void sendDataOut(string dataOUT)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    string sendmsg = dataOUT;
                    sendmsg = dataOUT + "\r\n";

                    serialPort1.Write(sendmsg);
                    logPrintInTextBox(sendmsg, "tx");
                }
                else
                {
                    MessageBox.Show("COM 포트가 오픈되어 있지 않습니다.");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.doOpenComPort();     // Serial port가 끊어진 것으로 판단, 포트 재오픈
            }
        }

        // 송수신 명령/응답 값과 동작 설명을 textbox에 삽입하고 앱 종료시 로그파일로 저장한다.
        public void logPrintInTextBox(string message, string kind)
        {
            string displayMsg = makeLogPrintLine(message,kind);

            Console.WriteLine(displayMsg);
        }

        // 명령어에 대해 동작시각과 방향을 포함하여 저장한다.
        private string makeLogPrintLine(string msg, string kind)
        {
            string msg_form = "";
            DateTime currenttime = DateTime.Now;

            msg = msg.Replace("\0", "");
            msg = msg.Replace("\r", "");
            msg = msg.Replace("\n", "");

            if (kind == "tx")
            {
                msg_form = "\r\n";
            }
            msg_form += currenttime.ToString("hh:mm:ss.fff");

            if (kind == "tx")
            {
                msg_form += "==> : ";
            }
            else if (kind == "rx")
            {
                msg_form += "<== : ";
            }
            else
            {
                msg_form += "     : ";
            }

            msg_form = msg_form + msg + "\r\n";
            return msg_form;
        }

        // serial port에서 data 수신이 될 때, 발생하는 이벤트 함수
        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            dataIN += serialPort1.ReadExisting();    // 수신한 버퍼에 있는 데이터 모두 받음
            this.Invoke(new EventHandler(ShowData));
        }

        // 수신 데이터 처리 thread 시작
        private void ShowData(object sender, EventArgs e)
        {
            char[] charValues = dataIN.ToCharArray();

            /* Debug를 위해 Hex로 문자열 표시*/
            /*
            string hexOutput = "";
            foreach (char _eachChar in charValues)
            {
                // Get the integral value of the character.
                int value = Convert.ToInt32(_eachChar);
                // Convert the decimal value to a hexadecimal value in string form.
                if (value < 16)
                    hexOutput += "0";
                hexOutput += String.Format("{0:X}", value);
            }
            logPrintInTextBox(hexOutput, "");
            */

            if (charValues.Length >= 2)
            {
                if (charValues[charValues.Length - 1] == '\n' || charValues[charValues.Length - 2] == '\n' || charValues[charValues.Length - 2] == '>')
                {
                    string[] words = dataIN.Split('\n');    // 수신한 데이터를 한 문장씩 나누어 array에 저장

                    foreach (var word in words)
                    {
                        string str1;

                        int lflength = word.IndexOf("\r");
                        if (lflength > 1)
                        {
                            str1 = word.Substring(0, lflength);    // \r\n를 제외하고 명령어만 처리하기 위함
                        }
                        else
                        {
                            str1 = word;
                        }

                        if (str1 != "")             // 빈 줄은 제외하기 위함
                        {
                            this.parseRXData(str1);
                        }
                    }

                    if (charValues[charValues.Length - 1] != '\n')
                    {
                        dataIN = charValues[charValues.Length - 1].ToString();    // \r\n를 제외하고 나머지 한글자 저장
                    }
                    else
                    {
                        dataIN = "";
                    }
                }
            }
        }

        // 수신한 데이터 한 줄에 대해 후처리가 필요한 응답 값을 찾아서 설정함 
        private void parseRXData(string rxMsg)
        {
            string[] sentences =
            {
                "OK",           // 모든 응답이 완료한 경우, 다음 동작이 필요한지 확인 (nextcommand)
                "ERROR",        // 오류 응답을 받은 경우, 동작을 중지한다.
                "+ICCID:",      // ICCID 값을 저장한다.
                "ICCID:",      // ICCID 값을 저장한다.
                "@ICCID:",    // ICCID (AMTEL) 값을 저장한다.
                "+NCCID:",      // ICCID (BC95) 값을 저장한다.
                "APPLICATION_A,",    // Modem verion (BC95) 값을 저장한다.
                "AT+MLWDLDATA=",    // LWM2M서버에서 data 수신이벤트
                "+NNMI:",    // LWM2M서버에서 data 수신이벤트
                "AT+MLWEVTIND=",    // LWM2M서버와 연동 상태 이벤트
                "+QLWEVTIND:",    // LWM2M서버와 연동 상태 이벤트
                "AT+CGMI",
                "AT+MLWDFDLDATA=",  // LWM2M서버에서 26241 data 수신 이벤트 (모바일에코)
                "AT",           // AT는 Device가 modem으로 요청하는 명령어로 무시하기 위함
                //"AT+CIMI",
                //"AT+GSN",
                //"AT+CGMM",
                //"AT+CGMI",
                //"AT+CEREG=3",
                //"AT+CEREG?",
                "+CEREG:",      // LTE network 상태를 확인하고 연결이 되어 있지 않으면 재접속 시도
                "+QLWEVENT:",    // 모듈 부팅시, LWM2M 등록 상태 이벤트, 진행 상태를 status bar에 진행율 표시
                "+QLWDLDATA:",
                "+QLWOBSERVE:",

                "$OM_B_CSE_RSP=",
                "$OM_R_CSE_RSP=",
                "$OM_C_CSE_RSP=",
                "$OM_C_CON_RSP=",
                "$OM_C_SUB_RSP=",
                "$OM_NOTI_IND=",
                "$OM_R_INS_RSP=",
                "$OM_C_MODEM_FWUP_RSP=",
                "$OM_MODEM_FWUP_RSP=",
                "$OM_PUSH_MODEM_FWUP_RSP=",
                "$OM_MODEM_UPDATE_FINISH",
                "$OM_DEV_FWUP_RSP=",
                "$OM_PUSH_DEV_FWUP_RSP=",
                "$OM_DEV_FWDL_FINISH",
                "$LGTMPF=",

                "*ST*INFO:",
                "@NOTI:",
                "@NETSTI:",
                "$OM_AUTH_RSP=",
                "$OM_U_CSE_RSP=",

                "$OM_DEV_FWDL_START=",
                "$BIN_DATA=",

                "+QCFG: ",
                "FW_VER: ",

                "+QLWSERVERIP:BS,",
                "+QLWSERVERIP:LWM2M,",
                "+QLWEPNS: ",
                "+QLWMBSPS: ",

        };


            logPrintInTextBox(rxMsg,"rx");          // 수신한 데이터 한줄을 표시
            bool find_msg = false;

            if (nextresponse != string.Empty && rxMsg.StartsWith(nextresponse, System.StringComparison.CurrentCultureIgnoreCase))
            {
                //logPrintInTextBox(s + " : There is matching data.","");

                // 타겟으로 하는 문자열(s, 고정 값)과 이후 문자열(str2, 변하는 값)을 구분함.
                int first = rxMsg.IndexOf(nextresponse) + nextresponse.Length;
                string str2 = "";
                str2 = rxMsg.Substring(first, rxMsg.Length - first);

                this.parseNextReceiveData(str2);
                nextresponse = string.Empty;

                find_msg = true;
            }
            else
            {
                // 후처리가 필요한 명령어 목록에서 하나씩 순서대로 읽어서 비교한다.
                foreach (string s in sentences)
                {
                    //logPrintInTextBox(s,"");

                    // 수신한 데이터에 대해 후처리가 필요한 명령어가 포함되어 있는지 체크한다.
                    //if (System.Text.RegularExpressions.Regex.IsMatch(rxMsg, s, System.Text.RegularExpressions.RegexOptions.IgnoreCase))

                    // 수신한 데이터에 대해 후처리가 필요한 명령어로 시작하는지 체크한다.
                    if (rxMsg.StartsWith(s, System.StringComparison.CurrentCultureIgnoreCase))
                    {
                        //logPrintInTextBox(s + " : There is matching data.","");

                        // 타겟으로 하는 문자열(s, 고정 값)과 이후 문자열(str2, 변하는 값)을 구분함.
                        int first = rxMsg.IndexOf(s) + s.Length;
                        string str2 = "";
                        str2 = rxMsg.Substring(first, rxMsg.Length - first);
                        //logPrintInTextBox("남은 문자열 : " + str2,"");

                        this.parseReceiveData(s, str2);

                        find_msg = true;
                        break;
                    }
                }
            }


            // 후처리가 필요한 명령어인데 고정 값이 없고 data만 있는 경우
            //예를들어 IMSI, IMEI 요청에 대한 응답 값 등
            if ((find_msg == false)&&(rxMsg!="\r") && (rxMsg != "\n"))
            {
                //logPrintInTextBox("No Matching Data!!!","");

                this.parseNoPrefixData(rxMsg);
            }

        }

        private void parseNextReceiveData(string str2)
        {
            states state = (states)Enum.Parse(typeof(states), actionState);
            switch (state)
            {
                case states.getimei:
                    dev.imei = str2;
                    tbIMEI.Text = str2;
                    logPrintInTextBox("IMEI를 " + dev.imei + "로 저장하였습니다.", "");
                    break;
                case states.autogetimei:
                    // 단말 정보 자동 갱신 순서
                    // autogetmanufac - autogetmodel - (autogetimei) - (autogetmodemver)
                    dev.imei = str2;
                    tbIMEI.Text = str2;
                    logPrintInTextBox("IMEI를 " + dev.imei + "로 저장하였습니다.", "");
                    progressBar1.Value = 90;

                    nextcommand = states.autogetmodemver.ToString();       // 모듈 정보를 모두 읽고 모뎀 버전 정보 조회
                    break;
                case states.geticcid:
                    string[] strchs = str2.Split(' ');        // Remove first char ' '
                    if (strchs.Length > 1)
                        str2 = strchs[strchs.Length - 1];

                    if (str2.Length > 19)
                        dev.iccid = str2.Substring(str2.Length - 20, 19);
                    else
                        dev.iccid = str2;

                    logPrintInTextBox("ICCID가 "+ dev.iccid + "로 저장되었습니다.", "");
                    break;
                default:
                    break;
            }
        }

        // 수신한 응답 값과 특정 값과 일치하는 경우
        // 응답을 받고 후 작업이 필요한지 확인한다. 
        void parseReceiveData(string s, string str2)
        {
            switch(s)
            {
                case "OK":
                    if (actionState == states.testatcmd.ToString())
                    {
                        MessageBox.Show("OK 응답을 받았습니다.");
                        actionState = states.idle.ToString();
                    }
                    else if (actionState == states.atdtatcmd.ToString())
                    {
                        this.sendDataOut(textBox3.Text);
                        actionState = states.testatcmd.ToString();
                    }
                    else
                        OKReceived();
                    break;
                case "ERROR":
                    nextcommand = "";
                    if (actionState == states.testatcmd.ToString() || actionState == states.atdtatcmd.ToString())
                    {
                        MessageBox.Show("ERROR 응답을 받았습니다.");
                        actionState = states.idle.ToString();
                    }
                    break;
                case "AT+MLWEVTIND=":
                case "+QLWEVTIND:":
                    // 모듈이 LWM2M서버 연동 상태 이벤트,
                    // OK 응답 발생하지 않음
                    // AT+MLWEVTIND=<type>
                    int type = Convert.ToInt32(str2);
                    switch (str2)
                    {
                        case "0":
                            logPrintInTextBox("registration completed", " ");
                            break;
                        case "1":
                            logPrintInTextBox("deregistration completed", " ");
                            break;
                        case "2":
                            logPrintInTextBox("registration update completed", " ");
                            break;
                        case "3":
                            logPrintInTextBox("10250 object subscription completed", " ");
                            break;
                        case "4":
                            logPrintInTextBox("Bootstrap finished", " ");
                            break;
                        case "5":
                            logPrintInTextBox("5/0/3 object subscription completed", " ");
                            break;
                        case "6":
                            logPrintInTextBox("fota downloading request", " ");
                            break;
                        case "7":
                            logPrintInTextBox("fota update request", " ");
                            break;
                        case "8":
                            logPrintInTextBox("26241 object subscription completed", " ");
                            break;
                    }
                    break;
                case "+NNMI:":
                    // 모듈이 LWM2M서버에서 받은 데이터를 전달하는 이벤트,
                    // OK 응답 발생하지 않고 bcd를 ascii로 변경해야함
                    // +NNMI:<length>,<hex data>
                    string[] rxdatasbc95 = str2.Split(',');    // 수신한 데이터를 한 문장씩 나누어 array에 저장
                                                               // 10250 DATA object RECEIVED!!!
                    if (Convert.ToInt32(rxdatasbc95[0]) == rxdatasbc95[1].Length / 2)    // data size 비교
                    {
                        //received hex data make to ascii code
                        string receiveDataIN = BcdToString(rxdatasbc95[1].ToCharArray());
                        logPrintInTextBox("\"" + receiveDataIN + "\"를 수신하였습니다.", "");
                    }
                    else
                    {
                        logPrintInTextBox("data size가 맞지 않습니다.", "");
                    }
                    break;
                case "+QLWDLDATA:":
                    // 모듈이 LWM2M서버에서 받은 데이터를 전달하는 이벤트,
                    // OK 응답 발생하지 않고 bcd를 ascii로 변경해야함
                    string[] words = str2.Split(',');    // 수신한 데이터를 한 문장씩 나누어 array에 저장
                    if (words[0] == " \"/10250/0/1\"")       // data object인지 확인
                    {
                        if (words[1] == "4")     // string data received
                        {
                            if (Convert.ToInt32(words[2]) == (words[3].Length - 2))    // data size 비교 (양쪽 끝의 " 크기 빼고)
                            {
                                logPrintInTextBox(words[3] + "를 수신하였습니다.", "");
                            }
                            else
                            {
                                logPrintInTextBox("data size가 맞지 않습니다.", "");
                            }
                        }
                        else if (words[1] == "5")     // hex data received
                        {
                            if (Convert.ToInt32(words[2]) == (words[3].Length - 2) / 2)    // data size 비교 (양쪽 끝의 " 크기 빼고 2bytes가 1글자임)
                            {
                                //received hex data make to ascii code
                                string hexInPut = words[3].Substring(1, words[3].Length - 2);
                                string receiveDataIN = BcdToString(hexInPut.ToCharArray());
                                logPrintInTextBox("\"" + receiveDataIN + "\"를 수신하였습니다.", "");
                            }
                            else
                            {
                                logPrintInTextBox("data size가 맞지 않습니다.", "");
                            }
                        }
                        else
                        {
                            logPrintInTextBox("지원하지 않는 data object입니다.", "");
                        }
                    }
                    else
                    {
                        logPrintInTextBox("지원하지 않는 data object입니다.", "");
                    }

                    if (nextcommand == states.getcereg.ToString())
                        nextcommand = "";
                    break;
                case "+QLWOBSERVE:":
                    // 모듈이 LWM2M서버와 초기 접속시 받은 데이터를 전달하는 이벤트,
                    // OK 응답 발생하지 않고 bcd를 ascii로 변경해야함
                    string[] observes = str2.Split(',');    // 수신한 데이터를 한 문장씩 나누어 array에 저장
                    if (observes[1] == "\"/10250/0/0\"")       // data object인지 확인
                    {
                    }
                    else if (observes[1] == "\"/26241/0/0\"")       // device firmware object인지 확인
                    {
                        // 서버에서 모듈 펌웨어 처리 후에 디바이스 펌웨어 체크 가능, 일정 시간 후에 동작해야 함.
                        // DeviceFWVerSend(tBoxDeviceVer.Text, device_fota_state, device_fota_reseult);
                    }
                    else
                    {
                        logPrintInTextBox("지원하지 않는 data object입니다.", "");
                    }

                    if (nextcommand == states.getcereg.ToString())
                        nextcommand = "";
                    break;
                case "@NETSTI:":
                    // AMTEL booting end, device info rerequest
                    getDeviveInfo();
                    break;
                default:
                    break;
            }
        }

        private void OKReceived()
        {
            // 마지막 응답(OK)을 받은 후에 후속 작업이 필요한지 확인한다.
            if (nextcommand != "skip")
            {
                if (nextcommand != "")
                {
                    states state = (states)Enum.Parse(typeof(states), nextcommand);
                    switch (state)
                    {
                        // 단말 정보 자동 갱신 순서
                        // autogetmanufac - (autogetmodel) - autogetimei - autogetmodemver
                        case states.autogetmodel:
                            this.sendDataOut(textBox47.Text);
                            actionState = states.autogetmodel.ToString();
                            break;
                        // 단말 정보 자동 갱신 순서
                        // autogetmanufac - autogetmodel - (autogetimei) - autogetmodemver
                        case states.autogetimei:
                            this.sendDataOut(textBox49.Text);
                            nextresponse = textBox40.Text;
                            actionState = states.autogetimei.ToString();
                            break;
                        // 단말 정보 자동 갱신 순서
                        // autogetmanufac - autogetmodel - autogetimei - (autogetmodemver)
                        case states.autogetmodemver:
                            this.sendDataOut(textBox44.Text);
                            nextresponse = textBox57.Text;
                            actionState = states.autogetmodemver.ToString();
                            break;
                        default:
                            break;
                    }
                    nextcommand = "";
                }
            }
        }

        private void parseNoPrefixData(string str1)
        {
            states state = (states)Enum.Parse(typeof(states), actionState);
            switch (state)
            {
                case states.getmanufac:
                    dev.maker = str1;
                    actionState = states.idle.ToString();
                    this.logPrintInTextBox("제조사값이 " + dev.maker + "로 저장되었습니다.", "");
                    break;
                // 단말 정보 자동 갱신 순서
                // (autogetmanufac) - (autogetmodel) - autogetimei - autogetmodemver
                case states.autogetmanufac:
                    dev.maker = str1;
                    progressBar1.Value = 60;
                    this.logPrintInTextBox("제조사값이 " + dev.maker + "로 저장되었습니다.", "");
                    if (checkBox1.Checked == false)        //AMTEL등 OK가 오지 않음
                    {
                        this.sendDataOut(textBox47.Text);
                        actionState = states.autogetmodel.ToString();

                        nextcommand = "";
                    }
                    else
                    {
                        actionState = states.idle.ToString();
                        nextcommand = states.autogetmodel.ToString();
                    }
                    break;
                case states.getmodel:
                    dev.model = str1;
                    tbDeviceName.Text = str1;
                    this.logPrintInTextBox("모델값이 " + dev.model + "로 저장되었습니다.", "");
                    break;
                // 단말 정보 자동 갱신 순서
                // autogetmanufac - (autogetmodel) - (autogetimei) - autogetmodemver
                case states.autogetmodel:
                    dev.model = str1;
                    progressBar1.Value = 70;
                    tbDeviceName.Text = str1;
                    this.logPrintInTextBox("모델값이 " + dev.model + "로 저장되었습니다.", "");

                    setModelConfig(str1);

                    nextcommand = states.autogetimei.ToString();
                    break;
                case states.getimsi:
                    if (str1.StartsWith("45006"))
                    {
                        string ctn = "0" + str1.Substring(5, str1.Length - 5);

                        dev.imsi = ctn;
                        textBox1.Text = ctn;
                        actionState = states.idle.ToString();
                        this.logPrintInTextBox("IMSI값이 " + dev.imsi + "로 저장되었습니다.", "");
                    }
                    else
                        this.logPrintInTextBox("USIM 상태 확인이 필요합니다.", "");

                    actionState = states.idle.ToString();
                    break;
                case states.getmodemver:
                    dev.version = str1;
                    tbDeviceVer.Text = str1;
                    actionState = states.idle.ToString();
                    this.logPrintInTextBox("모뎀버전이 " + dev.version + "로 저장되었습니다.", "");

                    break;
                case states.autogetmodemver:
                    dev.version = str1;
                    progressBar1.Value = 100;
                    tbDeviceVer.Text = str1;
                    this.logPrintInTextBox("모뎀버전이 " + dev.version + "로 저장되었습니다.", "");
                    break;
                default:
                    break;
            }
        }

        private void setModelConfig(string model)
        {

        }

        private void getDeviveInfo()
        {
            this.logPrintInTextBox("DEVICE 정보 전체를 요청합니다.","");

            // 단말 정보 자동 갱신 순서
            // (autogetmanufac) - autogetmodel - autogetimei - autogetmodemver
            this.sendDataOut(textBox48.Text);
            actionState = states.autogetmanufac.ToString();
        }

        private string BcdToString(char[] charValues)
        {
            string bcdstring = "";
            for (int i = 0; i < charValues.Length - 1;)
            {
                // Convert to the first character.
                int value = bcdvalues[charValues[i++]] * 0x10;

                // Convert to the second character.
                value += bcdvalues[charValues[i++]];

                // Convert the decimal value to a hexadecimal value in string form.
                bcdstring += Char.ConvertFromUtf32(value);
            }
            return bcdstring;
        }

        private string StringToBCD(char[] charValues)
        {

            string hexstring = "";
            foreach (char _eachChar in charValues)
            {
                // Get the integral value of the character.
                int value = Convert.ToInt32(_eachChar);
                // Convert the decimal value to a hexadecimal value in string form.
                hexstring += String.Format("{0:X}", value);
            }
            return hexstring;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMultiPDN.Checked == true)
                cbMultiPDN.Text = "지원";
            else
                cbMultiPDN.Text = "미지원";
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (cbIPSec.Checked == true)
                cbIPSec.Text = "지원";
            else
                cbIPSec.Text = "미지원";
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSMS.Checked == true)
                cbSMS.Text = "지원";
            else
                cbSMS.Text = "미지원";
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (cbVoice.Checked == true)
                cbVoice.Text = "지원";
            else
                cbVoice.Text = "미지원";
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (cbVideo.Checked == true)
                cbVideo.Text = "지원";
            else
                cbVideo.Text = "미지원";
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAuto2ndPDN.Checked == true)
                cbAuto2ndPDN.Text = "올림";
            else
                cbAuto2ndPDN.Text = "안올림";
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCA.Checked == true)
                cbCA.Text = "지원";
            else
                cbCA.Text = "미지원";
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEMC.Checked == true)
                cbEMC.Text = "지원";
            else
                cbEMC.Text = "미지원";
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBand1.Checked == true)
                cbBand1.Text = "지원";
            else
                cbBand1.Text = "미지원";
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBand5.Checked == true)
                cbBand5.Text = "지원";
            else
                cbBand5.Text = "미지원";
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBand7.Checked == true)
                cbBand7.Text = "지원";
            else
                cbBand7.Text = "미지원";
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFGI4.Checked == true)
                cbFGI4.Text = "지원";
            else
                cbFGI4.Text = "미지원";
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFGI5.Checked == true)
                cbFGI5.Text = "지원";
            else
                cbFGI5.Text = "미지원";
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFGI17.Checked == true)
                cbFGI17.Text = "지원";
            else
                cbFGI17.Text = "미지원";
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFGI18.Checked == true)
                cbFGI18.Text = "지원";
            else
                cbFGI18.Text = "미지원";
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFGI28.Checked == true)
                cbFGI28.Text = "지원";
            else
                cbFGI28.Text = "미지원";
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRachR9.Checked == true)
                cbRachR9.Text = "지원";
            else
                cbRachR9.Text = "미지원";
        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLogR10.Checked == true)
                cbLogR10.Text = "지원";
            else
                cbLogR10.Text = "미지원";
        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            if (cbStandaloneGNSS.Checked == true)
                cbStandaloneGNSS.Text = "지원";
            else
                cbStandaloneGNSS.Text = "미지원";
        }

        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBandCombin.Checked == true)
                cbBandCombin.Text = "지원";
            else
                cbBandCombin.Text = "미지원";
        }

        private void button23_Click(object sender, EventArgs e)
        {
            string pathname = @"c:\temp\seriallog\";
            string filename = "Sample_" + tbDeviceName.Text + ".txt";

            Directory.CreateDirectory(pathname);

            // Create a file to write to.
            FileStream fs = null;
            try
            {
                fs = new FileStream(pathname + filename, FileMode.Create, FileAccess.Write);
                // Create a file to write to.
                StreamWriter sw = new StreamWriter(fs);

                sw.WriteLine("[Common]");
                if (cbImsPDN.SelectedIndex == 0)
                    sw.WriteLine("imsPDN_number = " + "1");
                else
                    sw.WriteLine("imsPDN_number = " + "2");
                sw.WriteLine("imsIPversion = " + cbImsIP.Text);
                if(cbMultiPDN.Checked == true)
                    sw.WriteLine("Multiple_PDN = true");
                else
                    sw.WriteLine("Multiple_PDN = false");
                sw.WriteLine("Channel1 = "+ tbChannel1.Text);
                sw.WriteLine("Channel2 = " + tbChannel2.Text);
                sw.WriteLine("Channel3 = " + tbChannel3.Text);
                sw.WriteLine("UE_IMEI = " + tbIMEI.Text);
                if (cbAuto2ndPDN.Checked == true)
                    sw.WriteLine("Auto2ndPDN = true");
                else
                    sw.WriteLine("Auto2ndPDN = false");
                if (cbEMC.Checked == true)
                    sw.WriteLine("EMC_Support = 1");
                else
                    sw.WriteLine("EMC_Support = 0");
                if(cbCA.Checked == true)
                    sw.WriteLine("CA_Support = true");
                else
                    sw.WriteLine("CA_Support = false");
                sw.WriteLine("");
                sw.WriteLine("[Capability]");
                if (cbCatagory.SelectedIndex == 0)
                    sw.WriteLine("LTE_Category = 1");
                else
                    sw.WriteLine("LTE_Category = 4");
                if (cbBand1.Checked == true)
                    sw.WriteLine("Supported_Band1 = 1");
                else
                    sw.WriteLine("Supported_Band1 = omitted");
                if (cbBand5.Checked == true)
                    sw.WriteLine("Supported_Band5 = 5");
                else
                    sw.WriteLine("Supported_Band5 = omitted");
                if (cbBand7.Checked == true)
                    sw.WriteLine("Supported_Band7 = 7");
                else
                    sw.WriteLine("Supported_Band7 = omitted");
                if (cbFGI4.Checked == true)
                    sw.WriteLine("FGI_4 = 1");
                else
                    sw.WriteLine("FGI_4 = 0");
                if (cbFGI5.Checked == true)
                    sw.WriteLine("FGI_5 = 1");
                else
                    sw.WriteLine("FGI_5 = 0");
                if (cbFGI17.Checked == true)
                    sw.WriteLine("FGI_17 = 1");
                else
                    sw.WriteLine("FGI_17 = 0");
                if (cbFGI18.Checked == true)
                    sw.WriteLine("FGI_18 = 1");
                else
                    sw.WriteLine("FGI_18 = 0");
                if (cbFGI28.Checked == true)
                    sw.WriteLine("FGI_28 = 1");
                else
                    sw.WriteLine("FGI_28 = 0");
                if (cbRachR9.Checked == true)
                    sw.WriteLine("Rach_Report_r9 = supported");
                else
                    sw.WriteLine("Rach_Report_r9 = omitted");
                if (cbLogR10.Checked == true)
                    sw.WriteLine("loggedMeasurementIdle_r10 = supported");
                else
                    sw.WriteLine("loggedMeasurementIdle_r10 = omitted");
                if(cbStandaloneGNSS.Checked == true)
                    sw.WriteLine("standaloneGNSS_Location_r10 = supported");
                else
                    sw.WriteLine("standaloneGNSS_Location_r10 = omitted");
                if (cbBandCombin.Checked == true)
                    sw.WriteLine("supportedBandCombination = supported");
                else
                    sw.WriteLine("supportedBandCombination = omitted");
                sw.WriteLine("");
                sw.WriteLine("[VOLTE_SMS]");
                sw.WriteLine("Device_Name = " + tbDeviceName.Text);
                sw.WriteLine("Device_Version = " + tbDeviceVer.Text);
                sw.WriteLine("Device_Type = " + tbDeviceType.Text);
                sw.WriteLine("TTA_Version = " + tbTTAVer.Text);
                if (cbIPSec.Checked == true)
                    sw.WriteLine("IPsec_enable = true");
                else
                    sw.WriteLine("IPsec_enable = false");
                if (cbSMS.Checked == true)
                    sw.WriteLine("SMS_Support = true");
                else
                    sw.WriteLine("SMS_Support = false");
                if (cbVoice.Checked == true)
                    sw.WriteLine("Voice_Support = true");
                else
                    sw.WriteLine("Voice_Support = false");
                if (cbVideo.Checked == true)
                    sw.WriteLine("Video_Support = true");
                else
                    sw.WriteLine("Video_Support = false");
                sw.WriteLine("");
                sw.WriteLine("[NBIoT]");
                if (cbNBIPVer.SelectedIndex == 0)
                    sw.WriteLine("IPversion = IPv4");
                else
                    sw.WriteLine("IPversion = IPv6");

                sw.Close();
                fs.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = "txt";
            ofd.Filter = "text files (*.txt)|*.txt";
            ofd.ShowDialog();
            if (ofd.FileName.Length > 0)
            {
                try
                {
                    FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                    // Open a file to read to.
                    StreamReader sr = new StreamReader(fs);

                    string rddata = sr.ReadLine();
                    if (rddata == "[Common]")
                    {
                        rddata = sr.ReadLine();
                        if (rddata.EndsWith("1"))
                            cbImsPDN.SelectedIndex = 0;
                        else
                            cbImsPDN.SelectedIndex = 1;

                        rddata = sr.ReadLine();
                        if (rddata.EndsWith("IPv4"))
                            cbImsIP.SelectedIndex = 0;
                        else
                            cbImsIP.SelectedIndex = 1;

                        rddata = sr.ReadLine();
                        if (rddata.EndsWith("true"))
                            cbMultiPDN.Checked = true;
                        else
                            cbMultiPDN.Checked = false;

                        rddata = sr.ReadLine();
                        tbChannel1.Text = rddata.Substring(11, rddata.Length - 11);
                        rddata = sr.ReadLine();
                        tbChannel2.Text = rddata.Substring(11, rddata.Length - 11);
                        rddata = sr.ReadLine();
                        tbChannel3.Text = rddata.Substring(11, rddata.Length - 11);
                        rddata = sr.ReadLine();
                        tbIMEI.Text = rddata.Substring(10, rddata.Length - 10);

                        rddata = sr.ReadLine();
                        if (rddata.EndsWith("true"))
                            cbAuto2ndPDN.Checked = true;
                        else
                            cbAuto2ndPDN.Checked = false;

                        rddata = sr.ReadLine();
                        if (rddata.EndsWith("1"))
                            cbEMC.Checked = true;
                        else
                            cbEMC.Checked = false;

                        rddata = sr.ReadLine();
                        if (rddata.EndsWith("true"))
                            cbCA.Checked = true;
                        else
                            cbCA.Checked = false;

                        rddata = sr.ReadLine();
                        rddata = sr.ReadLine();

                        rddata = sr.ReadLine();
                        if (rddata.EndsWith("1"))
                            cbCatagory.SelectedIndex = 0;
                        else
                            cbCatagory.SelectedIndex = 1;

                        rddata = sr.ReadLine();
                        if (rddata.EndsWith("1"))
                            cbBand1.Checked = true;
                        else
                            cbBand1.Checked = false;

                        rddata = sr.ReadLine();
                        if (rddata.EndsWith("5"))
                            cbBand5.Checked = true;
                        else
                            cbBand5.Checked = false;

                        rddata = sr.ReadLine();
                        if (rddata.EndsWith("7"))
                            cbBand7.Checked = true;
                        else
                            cbBand7.Checked = false;

                        rddata = sr.ReadLine();
                        if (rddata.EndsWith("1"))
                            cbFGI4.Checked = true;
                        else
                            cbFGI4.Checked = false;

                        rddata = sr.ReadLine();
                        if (rddata.EndsWith("1"))
                            cbFGI5.Checked = true;
                        else
                            cbFGI5.Checked = false;

                        rddata = sr.ReadLine();
                        if (rddata.EndsWith("1"))
                            cbFGI17.Checked = true;
                        else
                            cbFGI17.Checked = false;

                        rddata = sr.ReadLine();
                        if (rddata.EndsWith("1"))
                            cbFGI18.Checked = true;
                        else
                            cbFGI18.Checked = false;

                        rddata = sr.ReadLine();
                        if (rddata.EndsWith("1"))
                            cbFGI28.Checked = true;
                        else
                            cbFGI28.Checked = false;

                        rddata = sr.ReadLine();
                        if (rddata.EndsWith("supported"))
                            cbRachR9.Checked = true;
                        else
                            cbRachR9.Checked = false;

                        rddata = sr.ReadLine();
                        if (rddata.EndsWith("supported"))
                            cbLogR10.Checked = true;
                        else
                            cbLogR10.Checked = false;

                        rddata = sr.ReadLine();
                        if (rddata.EndsWith("supported"))
                            cbStandaloneGNSS.Checked = true;
                        else
                            cbStandaloneGNSS.Checked = false;

                        rddata = sr.ReadLine();
                        if (rddata.EndsWith("supported"))
                            cbBandCombin.Checked = true;
                        else
                            cbBandCombin.Checked = false;

                        rddata = sr.ReadLine();
                        rddata = sr.ReadLine();

                        rddata = sr.ReadLine();
                        tbDeviceName.Text = rddata.Substring(14, rddata.Length - 14);

                        rddata = sr.ReadLine();
                        tbDeviceVer.Text = rddata.Substring(17, rddata.Length - 17);

                        rddata = sr.ReadLine();
                        tbDeviceType.Text = rddata.Substring(14, rddata.Length - 14);

                        rddata = sr.ReadLine();
                        tbTTAVer.Text = rddata.Substring(14, rddata.Length - 14);

                        rddata = sr.ReadLine();
                        if (rddata.EndsWith("true"))
                            cbIPSec.Checked = true;
                        else
                            cbIPSec.Checked = false;

                        rddata = sr.ReadLine();
                        if (rddata.EndsWith("true"))
                            cbSMS.Checked = true;
                        else
                            cbSMS.Checked = false;

                        rddata = sr.ReadLine();
                        if (rddata.EndsWith("true"))
                            cbVoice.Checked = true;
                        else
                            cbVoice.Checked = false;

                        rddata = sr.ReadLine();
                        if (rddata.EndsWith("true"))
                            cbVideo.Checked = true;
                        else
                            cbVideo.Checked = false;

                        rddata = sr.ReadLine();
                        rddata = sr.ReadLine();

                        rddata = sr.ReadLine();
                        if (rddata.EndsWith("IPv4"))
                            cbNBIPVer.SelectedIndex = 0;
                        else
                            cbNBIPVer.SelectedIndex = 1;
                    }
                    else
                        MessageBox.Show("Bad PCF setting file");

                    sr.Close();
                    fs.Close();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void button41_Click(object sender, EventArgs e)
        {
            string pathname = @"c:\temp\seriallog\";
            string filename = "LTD_" + tbDeviceName.Text + "_proxy.xml.txt";

            Directory.CreateDirectory(pathname);

            try
            {
                // Create a file to write to.
                XDocument xdoc = new XDocument(new XDeclaration("1.0", "UTF-8", null));
                XNamespace xsi = "http://www.w3.org/2001/XMLSchema-instance";
                XElement xroot = new XElement("ProxyConfiguration",
                    new XAttribute(XNamespace.Xmlns + "xsi", "http://www.w3.org/2001/XMLSchema-instance"),
                    new XAttribute(xsi + "noNamespaceSchemaLocation", "AT-MMI Proxy Configuration.xsd")
                    );
                xdoc.Add(xroot);

                XElement xports = new XElement("Ports");
                xroot.Add(xports);

                XElement port = new XElement("Port",
                    new XAttribute("id", "1"),
                    new XElement("Socket",
                          new XAttribute("address", "127.0.0.1"),
                          new XAttribute("port", "10005")
                       )
                    );
                xports.Add(port);

                port = new XElement("Port",
                    new XAttribute("id", "2"),
                    new XElement("Socket",
                          new XAttribute("address", "127.0.0.1"),
                          new XAttribute("port", "10006")
                       )
                    );
                xports.Add(port);

                string comport = cBoxCOMPORT.Text;
                comport = comport.Substring(3, comport.Length - 3);
                string baudrate = cBoxBaudRate.Text;
                port = new XElement("Port",
                    new XAttribute("id", "3"),
                    new XElement("Serial",
                          new XAttribute("com", comport),
                          new XAttribute("baudrate", baudrate),
                          new XAttribute("parity", "0"),
                          new XAttribute("stopbits", "1"),
                          new XAttribute("byteSize", "8")
                       )
                    );
                xports.Add(port);

                port = new XElement("Port",
                    new XAttribute("id", "4"),
                    new XElement("Serial",
                          new XAttribute("com", comport),
                          new XAttribute("baudrate", baudrate),
                          new XAttribute("parity", "0"),
                          new XAttribute("stopbits", "1"),
                          new XAttribute("byteSize", "8")
                       )
                    );
                xports.Add(port);

                port = new XElement("Port",
                    new XAttribute("id", "5"),
                    new XElement("Socket",
                          new XAttribute("address", "127.0.0.1"),
                          new XAttribute("port", "10007")
                       )
                    );
                xports.Add(port);

                port = new XElement("Port",
                    new XAttribute("id", "6"),
                    new XElement("Socket",
                          new XAttribute("address", "127.0.0.1"),
                          new XAttribute("port", "10008")
                       )
                    );
                xports.Add(port);

                port = new XElement("Port",
                    new XAttribute("id", "7"),
                    new XElement("Serial",
                          new XAttribute("com", comport),
                          new XAttribute("baudrate", baudrate),
                          new XAttribute("parity", "0"),
                          new XAttribute("stopbits", "1"),
                          new XAttribute("byteSize", "8")
                       )
                    );
                xports.Add(port);

                port = new XElement("Port",
                    new XAttribute("id", "8"),
                    new XElement("Serial",
                          new XAttribute("com", comport),
                          new XAttribute("baudrate", baudrate),
                          new XAttribute("parity", "0"),
                          new XAttribute("stopbits", "1"),
                          new XAttribute("byteSize", "8")
                       )
                    );
                xports.Add(port);

                XElement xChannels = new XElement("Channels");
                xroot.Add(xChannels);

                XElement xChannel = new XElement("Channel",
                    new XAttribute("id", "1") ,
                    new XElement("ChannelApplication",
                        new XAttribute("name", "MUX_MMI"),
                        new XAttribute("id", "1")
                      ),
                    new XElement("ServerPorts",
                        new XElement("ServerPort", "1")
                      ),
                    new XElement("ClientPorts",
                        new XElement("ClientPort", "3")
                      )
                    );
                xChannels.Add(xChannel);

                xChannel = new XElement("Channel",
                    new XAttribute("id", "2"),
                    new XElement("ChannelApplication",
                        new XAttribute("name", "MUX_AT"),
                        new XAttribute("id", "2")
                      ),
                    new XElement("ServerPorts",
                        new XElement("ServerPort", "2")
                      ),
                    new XElement("ClientPorts",
                        new XElement("ClientPort", "4")
                      )
                    );
                xChannels.Add(xChannel);

                xChannel = new XElement("Channel",
                    new XAttribute("id", "3"),
                    new XElement("ChannelApplication",
                        new XAttribute("name", "MUX_MMI"),
                        new XAttribute("id", "3")
                      ),
                    new XElement("ServerPorts",
                        new XElement("ServerPort", "5")
                      ),
                    new XElement("ClientPorts",
                        new XElement("ClientPort", "7")
                      )
                    );
                xChannels.Add(xChannel);

                xChannel = new XElement("Channel",
                    new XAttribute("id", "4"),
                    new XElement("ChannelApplication",
                        new XAttribute("name", "MUX_AT"),
                        new XAttribute("id", "4")
                      ),
                    new XElement("ServerPorts",
                        new XElement("ServerPort", "6")
                      ),
                    new XElement("ClientPorts",
                        new XElement("ClientPort", "8")
                      )
                    );
                xChannels.Add(xChannel);

                XElement xApps = new XElement("Applications");
                xroot.Add(xApps);

                string selectmsg = "yes";
                if (comboBox3.SelectedIndex == 0)
                    selectmsg = "no";
                XElement xApp = new XElement("DisplayOnly",selectmsg);
                xApps.Add(xApp);
                XComment xComment = new XComment(" Display only or send command to the UE. Values: yes or no ");
                xApps.Add(xComment);

                xApp = new XElement("BypassAllRemap", "no");
                xApps.Add(xApp);
                xComment = new XComment(" Ignore all remapping options. Values: yes or no ");
                xApps.Add(xComment);

                xApp = new XElement("KeepSerialConnection", "yes");
                xApps.Add(xApp);
                xComment = new XComment(" Keep the serial connection opened after each AT command sent to the phone. Values: yes or no ");
                xApps.Add(xComment);

                xApp = new XElement("CreateLogFile", "yes");
                xApps.Add(xApp);
                xComment = new XComment(" Create automatically a log file in the \\bin directory. Values: yes or no ");
                xApps.Add(xComment);

                xApp = new XElement("ClearUeQueue", "yes");
                xApps.Add(xApp);
                xComment = new XComment(" Clear the UE queue before sending a new AT command ");
                xApps.Add(xComment);

                xApp = new XElement("Application",
                    new XAttribute("name", "MUX_MMI"),
                    new XAttribute("id", "1"),
                    new XElement("AutoConfirmationEnabled","no"),
                    new XComment(" Raise the MMI prompt or send auto reply. Values: yes or no ")
                 );
                xApps.Add(xApp);

                xApp = new XElement("Application",
                    new XAttribute("name", "MUX_AT"),
                    new XAttribute("id", "2"),
                    new XElement("AtManualControl", "no"),
                    new XComment(" Don't send AT commands to the phone and display a menu to the user. Values: yes or no ")
                 );

                XElement xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", "ATD123456789;<CR><LF>"),
                      new XComment(" Equivalent to ATD123456789;<CR><LF> "),
                      new XElement("To", textBox2.Text),
                      new XElement("To", textBox3.Text)
                      )
                    );
                xApp.Add(xOption);
                xApps.Add(xApp);

                xApp = new XElement("Application",
                    new XAttribute("name", "MUX_MMI"),
                    new XAttribute("id", "3"),
                    new XElement("AutoConfirmationEnabled", "yes"),
                    new XComment(" Raise the MMI prompt or send auto reply. Values: yes or no ")
                 );

                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", "Please disconnect pdn"),
                      new XElement("To", 
                        new XAttribute("closePort", "yes"),
                        textBox4.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", "Switch on the phone"),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        textBox5.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", "Activate SMS mode"),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        textBox6.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", "Try MO SMS"),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        textBox1.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", "Emergency call 111"),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        textBox7.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", "Emergency call 112"),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        textBox8.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", "Normal call 114"),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        textBox9.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", "Emergency call 113"),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        textBox10.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", "Emergency call 117"),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        textBox11.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", "Emergency call 118"),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        textBox12.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", "Emergency call 119"),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        textBox13.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", "Emergency call 122"),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        textBox14.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", "Emergency call 125"),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        textBox15.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", "Switch off the phone"),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        textBox16.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", "Please power off the UE"),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        textBox17.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", "Please make voice call from the UE"),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        textBox18.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", "Try MO Voice Call(15447769)"),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        textBox19.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", "Try MO Voice Call"),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        textBox20.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", "Try Call Answer"),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        textBox21.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", "Try Call End"),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        textBox22.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", "End voice call from the UE"),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        textBox43.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", "Check PDN Address"),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        textBox42.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", "Please set EMM/ESM cause"),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        textBox41.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", "Please reboot phone"),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        textBox23.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", "Please connect pdn"),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        textBox39.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                xComment = new XComment(" Jeong.Suyon ");
                xApp.Add(xComment);

                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", "Please PSM On"),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        textBox37.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", "Please PSM Off"),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        textBox36.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", "Deactivate Data PDN"),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        textBox35.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", "Activate Data PDN"),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        textBox34.Text
                      )
                    )
                  );
                xApp.Add(xOption);
                xComment = new XComment(" Jeong.Suyon  END ");
                xApp.Add(xComment);
                xApps.Add(xApp);

                xApp = new XElement("Application",
                    new XAttribute("name", "MUX_AT"),
                    new XAttribute("id", "4"),
                    new XElement("AutoConfirmationEnabled", "yes"),
                    new XComment(" Raise the MMI prompt or send auto reply. Values: yes or no ")
                 );

                XElement xOptions = new XElement("Options");

                xOption = new XElement("ClientReceiveRemap",
                      new XElement("From", "AT+CGACT=1,1"),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        textBox31.Text
                    )
                  );
                xOptions.Add(xOption);

                xOption = new XElement("ClientReceiveRemap",
                      new XElement("From", "AT+CGACT=1=0,1"),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        textBox30.Text
                    )
                  );
                xOptions.Add(xOption);

                xOption = new XElement("ClientReceiveRemap",
                      new XElement("From", "at+cops?"),
                      new XElement("Pause", textBox29.Text),
                      new XElement("To", textBox28.Text)
                  );
                xOptions.Add(xOption);

                xOption = new XElement("ClientReceiveRemap",
                      new XElement("From", "at+cfun=0"),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        textBox32.Text
                      )
                  );
                xOptions.Add(xOption);

                xOption = new XElement("ClientReceiveRemap",
                      new XElement("From", "at+cfun=1"),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        textBox27.Text
                      )
                  );
                xOptions.Add(xOption);

                xOption = new XElement("ClientReceiveRemap",
                      new XElement("From", "PSM On"),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        textBox26.Text
                      )
                  );
                xOptions.Add(xOption);

                xOption = new XElement("ClientReceiveRemap",
                      new XElement("From", "PSM Off"),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        textBox25.Text
                      )
                  );
                xOptions.Add(xOption);
                xApp.Add(xOptions);
                xApps.Add(xApp);

                xdoc.Save(pathname + filename);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button40_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = "txt";
            ofd.Filter = "text files (*.txt)|*.txt";
            ofd.ShowDialog();
            if (ofd.FileName.Length > 0)
            {
                try
                {
                    XDocument xdoc = XDocument.Load(ofd.FileName);

                    // <Employees> 노드 하나 리턴
                    IEnumerable<XElement> elems = xdoc.Elements();

                    // 복수 개의 <Employee> 노드들 리턴
                    IEnumerable<XElement> emps = xdoc.Root.Elements();
                    foreach (var emp in emps)
                    {
                        if (emp.Name == "Applications")
                        {
                            IEnumerable<XElement> apps = emp.Elements();
                            foreach (var app in apps)
                            {
                                if (app.Name == "Application")
                                {
                                    if (app.Attribute("id").Value == "2")
                                    {
                                        IEnumerable<XElement> atcmds = app.Element("Options").Element("ClientReceiveRemap").Elements();
                                        int first = 0;
                                        foreach (var atcmd in atcmds)
                                        {
                                            if (atcmd.Name == "To")
                                            {
                                                if (first == 0)
                                                    textBox2.Text = atcmd.Value;
                                                else
                                                    textBox3.Text = atcmd.Value;
                                                first++;
                                            }
                                        }
                                    }
                                    else if (app.Attribute("id").Value == "3")
                                    {
                                        IEnumerable<XElement> options = app.Elements();
                                        foreach (var option in options)
                                        {
                                            if(option.Name == "Options")
                                            {
                                                string msg = option.Element("ClientReceiveRemap").Element("To").Value;
                                                switch (option.Element("ClientReceiveRemap").Element("From").Value)
                                                {
                                                    case "Please disconnect pdn":
                                                        textBox4.Text = msg;
                                                        break;
                                                    case "Switch on the phone":
                                                        textBox5.Text = msg;
                                                        break;
                                                    case "Activate SMS mode":
                                                        textBox6.Text = msg;
                                                        break;
                                                    case "Try MO SMS":
                                                        textBox1.Text = msg;
                                                        break;
                                                    case "Emergency call 111":
                                                        textBox7.Text = msg;
                                                        break;
                                                    case "Emergency call 112":
                                                        textBox8.Text = msg;
                                                        break;
                                                    case "Normal call 114":
                                                        textBox9.Text = msg;
                                                        break;
                                                    case "Emergency call 113":
                                                        textBox10.Text = msg;
                                                        break;
                                                    case "Emergency call 117":
                                                        textBox11.Text = msg;
                                                        break;
                                                    case "Emergency call 118":
                                                        textBox12.Text = msg;
                                                        break;
                                                    case "Emergency call 119":
                                                        textBox13.Text = msg;
                                                        break;
                                                    case "Emergency call 122":
                                                        textBox14.Text = msg;
                                                        break;
                                                    case "Emergency call 125":
                                                        textBox15.Text = msg;
                                                        break;
                                                    case "Switch off the phone":
                                                        textBox16.Text = msg;
                                                        break;
                                                    case "Please power off the UE":
                                                        textBox17.Text = msg;
                                                        break;
                                                    case "Please make voice call from the UE":
                                                        textBox18.Text = msg;
                                                        break;
                                                    case "Try MO Voice Call(15447769)":
                                                        textBox19.Text = msg;
                                                        break;
                                                    case "Try MO Voice Call":
                                                        textBox20.Text = msg;
                                                        break;
                                                    case "Try Call Answer":
                                                        textBox21.Text = msg;
                                                        break;
                                                    case "Try Call End":
                                                        textBox22.Text = msg;
                                                        break;
                                                    case "End voice call from the UE":
                                                        textBox43.Text = msg;
                                                        break;
                                                    case "Check PDN Address":
                                                        textBox42.Text = msg;
                                                        break;
                                                    case "Please set EMM/ESM cause":
                                                        textBox41.Text = msg;
                                                        break;
                                                    case "Please reboot phone":
                                                        textBox23.Text = msg;
                                                        break;
                                                    case "Please connect pdn":
                                                        textBox39.Text = msg;
                                                        break;
                                                    case "Please PSM On":
                                                        textBox37.Text = msg;
                                                        break;
                                                    case "Please PSM Off":
                                                        textBox36.Text = msg;
                                                        break;
                                                    case "Deactivate Data PDN":
                                                        textBox35.Text = msg;
                                                        break;
                                                    case "Activate Data PDN":
                                                        textBox34.Text = msg;
                                                        break;
                                                    default:
                                                        MessageBox.Show("Check options count");
                                                        break;
                                                }
                                            }
                                        }
                                    }
                                    else if (app.Attribute("id").Value == "4")
                                    {
                                        IEnumerable<XElement> options = app.Element("Options").Elements();
                                        foreach (var option in options)
                                        {
                                            string msg = option.Element("To").Value;
                                            switch (option.Element("From").Value)
                                            {
                                                case "AT+CGACT=1,1":
                                                    textBox31.Text = msg;
                                                    break;
                                                case "AT+CGACT=1=0,1":
                                                    textBox30.Text = msg;
                                                    break;
                                                case "at+cops?":
                                                    textBox29.Text = option.Element("Pause").Value;
                                                    textBox28.Text = msg;
                                                    break;
                                                case "at+cfun=0":
                                                    textBox32.Text = msg;
                                                    break;
                                                case "at+cfun=1":
                                                    textBox27.Text = msg;
                                                    break;
                                                case "PSM On":
                                                    textBox26.Text = msg;
                                                    break;
                                                case "PSM Off":
                                                    textBox25.Text = msg;
                                                    break;
                                                default:
                                                    MessageBox.Show("Check options count");
                                                    break;
                                            }
                                        }
                                    }
                                }
                                else if (app.Name == "DisplayOnly")
                                {
                                    if (app.Value == "no")
                                        comboBox3.SelectedIndex = 0;
                                    else
                                        comboBox3.SelectedIndex = 1;
                                }
                            }
                        }

                        /*
                        else if (emp.Name == "Ports")
                        {
                            IEnumerable<XElement> ports = emp.Elements();
                            foreach (var port in ports)
                            {
                                if (port.Attribute("id").Value == "1")
                                {
                                    Console.WriteLine("$$$$$$$$$$$$$");
                                    Console.WriteLine(port);
                                }

                                Console.WriteLine("&&&&&&&&&&&&&&&");
                                Console.WriteLine(port);
                            }
                        }
                        */
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button34_Click(object sender, EventArgs e)
        {
            button34.BackColor = SystemColors.ButtonHighlight;
            button35.BackColor = SystemColors.ButtonShadow;
            button70.BackColor = SystemColors.ButtonShadow;
            pnSetting.Visible = true;
            pnProxy.Visible = false;
            pnOneM2M.Visible = false;
        }

        private void button35_Click(object sender, EventArgs e)
        {
            button35.BackColor = SystemColors.ButtonHighlight;
            button34.BackColor = SystemColors.ButtonShadow;
            button70.BackColor = SystemColors.ButtonShadow;
            pnSetting.Visible = false;
            pnProxy.Visible = true;
            pnOneM2M.Visible = false;
        }

        private void button70_Click(object sender, EventArgs e)
        {
            button35.BackColor = SystemColors.ButtonShadow;
            button34.BackColor = SystemColors.ButtonShadow;
            button70.BackColor = SystemColors.ButtonHighlight;
            pnSetting.Visible = false;
            pnProxy.Visible = false;
            pnOneM2M.Visible = true;
        }

        private void button63_Click(object sender, EventArgs e)
        {
            string pathname = @"c:\temp\seriallog\";
            string filename = "LTD_" + tbDeviceName.Text + "_proxy.xls";

            Directory.CreateDirectory(pathname);

            try
            {
                Workbook workbook = new Workbook();
                Worksheet worksheet = new Worksheet("options");
                worksheet.Cells[0, 0] = new Cell(button73.Text);
                worksheet.Cells[0, 1] = new Cell(comboBox3.Text);

                worksheet.Cells.ColumnWidth[0, 2] = 7000;
                workbook.Worksheets.Add(worksheet);

                int i = 0;
                worksheet = new Worksheet("atcommand1");
                worksheet.Cells[i, 0] = new Cell(button44.Text);
                worksheet.Cells[i, 1] = new Cell(textBox2.Text);
                worksheet.Cells[i, 2] = new Cell(textBox3.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button42.Text);
                worksheet.Cells[i, 1] = new Cell(textBox4.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button39.Text);
                worksheet.Cells[i, 1] = new Cell(textBox5.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button38.Text);
                worksheet.Cells[i, 1] = new Cell(textBox6.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button37.Text);
                worksheet.Cells[i, 1] = new Cell(textBox1.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button45.Text);
                worksheet.Cells[i, 1] = new Cell(textBox7.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button46.Text);
                worksheet.Cells[i, 1] = new Cell(textBox8.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button47.Text);
                worksheet.Cells[i, 1] = new Cell(textBox9.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button48.Text);
                worksheet.Cells[i, 1] = new Cell(textBox10.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button49.Text);
                worksheet.Cells[i, 1] = new Cell(textBox11.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button50.Text);
                worksheet.Cells[i, 1] = new Cell(textBox12.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button51.Text);
                worksheet.Cells[i, 1] = new Cell(textBox13.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button52.Text);
                worksheet.Cells[i, 1] = new Cell(textBox14.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button53.Text);
                worksheet.Cells[i, 1] = new Cell(textBox15.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button54.Text);
                worksheet.Cells[i, 1] = new Cell(textBox16.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button43.Text);
                worksheet.Cells[i, 1] = new Cell(textBox17.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button55.Text);
                worksheet.Cells[i, 1] = new Cell(textBox18.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button56.Text);
                worksheet.Cells[i, 1] = new Cell(textBox19.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button57.Text);
                worksheet.Cells[i, 1] = new Cell(textBox20.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button58.Text);
                worksheet.Cells[i, 1] = new Cell(textBox21.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button59.Text);
                worksheet.Cells[i, 1] = new Cell(textBox22.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button85.Text);
                worksheet.Cells[i, 1] = new Cell(textBox43.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button60.Text);
                worksheet.Cells[i, 1] = new Cell(textBox42.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button84.Text);
                worksheet.Cells[i, 1] = new Cell(textBox41.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button69.Text);
                worksheet.Cells[i, 1] = new Cell(textBox23.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button82.Text);
                worksheet.Cells[i, 1] = new Cell(textBox39.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button79.Text);
                worksheet.Cells[i, 1] = new Cell(textBox37.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button78.Text);
                worksheet.Cells[i, 1] = new Cell(textBox36.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button77.Text);
                worksheet.Cells[i, 1] = new Cell(textBox35.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button76.Text);
                worksheet.Cells[i, 1] = new Cell(textBox34.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell("");
                worksheet.Cells[i, 1] = new Cell("");
                i++;
                worksheet.Cells[i, 0] = new Cell("");
                worksheet.Cells[i, 1] = new Cell("");

                worksheet.Cells.ColumnWidth[0, 2] = 10000;
                workbook.Worksheets.Add(worksheet);

                i = 0;
                worksheet = new Worksheet("atcommand2");
                worksheet.Cells[i, 0] = new Cell(button61.Text);
                worksheet.Cells[i, 1] = new Cell(textBox31.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button75.Text);
                worksheet.Cells[i, 1] = new Cell(textBox30.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button74.Text);
                worksheet.Cells[i, 1] = new Cell(textBox29.Text);
                worksheet.Cells[i, 2] = new Cell(textBox28.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button67.Text);
                worksheet.Cells[i, 1] = new Cell(textBox32.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button66.Text);
                worksheet.Cells[i, 1] = new Cell(textBox27.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button65.Text);
                worksheet.Cells[i, 1] = new Cell(textBox26.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button64.Text);
                worksheet.Cells[i, 1] = new Cell(textBox25.Text);

                worksheet.Cells.ColumnWidth[0, 2] = 10000;
                workbook.Worksheets.Add(worksheet);

                i = 0;
                worksheet = new Worksheet("atcommand3");
                worksheet.Cells[i, 0] = new Cell(button80.Text);
                worksheet.Cells[i, 1] = new Cell(comboBox1.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button83.Text);
                worksheet.Cells[i, 1] = new Cell(textBox48.Text);
                if (checkBox1.Checked == true)
                    worksheet.Cells[i, 3] = new Cell("on");
                else
                    worksheet.Cells[i, 3] = new Cell("off");
                i++;
                worksheet.Cells[i, 0] = new Cell(button91.Text);
                worksheet.Cells[i, 1] = new Cell(textBox47.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button90.Text);
                worksheet.Cells[i, 1] = new Cell(textBox46.Text);
                worksheet.Cells[i, 2] = new Cell(textBox33.Text);
                if (checkBox3.Checked == true)
                    worksheet.Cells[i, 3] = new Cell("on");
                else
                    worksheet.Cells[i, 3] = new Cell("off");
                i++;
                worksheet.Cells[i, 0] = new Cell(button71.Text);
                worksheet.Cells[i, 1] = new Cell(textBox45.Text);
                worksheet.Cells[i, 2] = new Cell(textBox38.Text);
                if (checkBox4.Checked == true)
                    worksheet.Cells[i, 3] = new Cell("on");
                else
                    worksheet.Cells[i, 3] = new Cell("off");
                i++;
                worksheet.Cells[i, 0] = new Cell(button89.Text);
                worksheet.Cells[i, 1] = new Cell(textBox49.Text);
                worksheet.Cells[i, 2] = new Cell(textBox40.Text);
                if (checkBox5.Checked == true)
                    worksheet.Cells[i, 3] = new Cell("on");
                else
                    worksheet.Cells[i, 3] = new Cell("off");
                i++;
                worksheet.Cells[i, 0] = new Cell(button88.Text);
                worksheet.Cells[i, 1] = new Cell(textBox44.Text);
                worksheet.Cells[i, 2] = new Cell(textBox57.Text);
                if (checkBox6.Checked == true)
                    worksheet.Cells[i, 3] = new Cell("on");
                else
                    worksheet.Cells[i, 3] = new Cell("off");
                i++;
                worksheet.Cells[i, 0] = new Cell(button86.Text);
                worksheet.Cells[i, 1] = new Cell(textBox24.Text);

                worksheet.Cells.ColumnWidth[0, 2] = 10000;
                workbook.Worksheets.Add(worksheet);
                workbook.Save(pathname + filename);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button62_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = "xls";
            ofd.Filter = "text files (*.xls)|*.xls";
            ofd.ShowDialog();
            if (ofd.FileName.Length > 0)
            {
                try
                {
                    Workbook workbook = Workbook.Load(ofd.FileName);

                    Worksheet worksheet = workbook.Worksheets[0];
                    if (worksheet.Name == "options" && worksheet.Cells[0, 0].ToString() == button73.Text)
                    {
                        if (worksheet.Cells[0, 1].ToString() == "자동")
                            comboBox3.SelectedIndex = 0;
                        else
                            comboBox3.SelectedIndex = 1;

                        worksheet = workbook.Worksheets[1];
                        int i = 0;
                        textBox2.Text = worksheet.Cells[i, 1].ToString();
                        textBox3.Text = worksheet.Cells[i, 2].ToString();
                        i++;
                        textBox4.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        textBox5.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        textBox6.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        textBox1.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        textBox7.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        textBox8.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        textBox9.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        textBox10.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        textBox11.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        textBox12.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        textBox13.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        textBox14.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        textBox15.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        textBox16.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        textBox17.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        textBox18.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        textBox19.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        textBox20.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        textBox21.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        textBox22.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        textBox43.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        textBox42.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        textBox41.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        textBox23.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        textBox39.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        textBox37.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        textBox36.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        textBox35.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        textBox34.Text = worksheet.Cells[i, 1].ToString();

                        i = 0;
                        worksheet = workbook.Worksheets[2];
                        textBox31.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        textBox30.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        textBox29.Text = worksheet.Cells[i, 1].ToString();
                        textBox28.Text = worksheet.Cells[i, 2].ToString();
                        i++;
                        textBox32.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        textBox27.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        textBox26.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        textBox25.Text = worksheet.Cells[i, 1].ToString();

                        i = 0;
                        worksheet = workbook.Worksheets[3];
                        comboBox1.Text = worksheet.Cells[i, 1].ToString();
                        if (comboBox1.SelectedIndex == 1)
                            groupBox11.Enabled = true;
                        else
                            groupBox11.Enabled = false;
                        i++;
                        textBox48.Text = worksheet.Cells[i, 1].ToString();
                        if (worksheet.Cells[i, 3].ToString() == "on")
                            checkBox1.Checked = true;
                        else
                            checkBox1.Checked = false;
                        i++;
                        textBox47.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        textBox46.Text = worksheet.Cells[i, 1].ToString();
                        textBox33.Text = worksheet.Cells[i, 2].ToString();
                        if (worksheet.Cells[i, 3].ToString() == "on")
                            checkBox3.Checked = true;
                        else
                            checkBox3.Checked = false;
                        i++;
                        textBox45.Text = worksheet.Cells[i, 1].ToString();
                        textBox38.Text = worksheet.Cells[i, 2].ToString();
                        if (worksheet.Cells[i, 3].ToString() == "on")
                            checkBox4.Checked = true;
                        else
                            checkBox4.Checked = false;
                        i++;
                        textBox49.Text = worksheet.Cells[i, 1].ToString();
                        textBox40.Text = worksheet.Cells[i, 2].ToString();
                        if (worksheet.Cells[i, 3].ToString() == "on")
                            checkBox5.Checked = true;
                        else
                            checkBox5.Checked = false;
                        i++;
                        textBox44.Text = worksheet.Cells[i, 1].ToString();
                        textBox57.Text = worksheet.Cells[i, 2].ToString();
                        if (worksheet.Cells[i, 3].ToString() == "on")
                            checkBox6.Checked = true;
                        else
                            checkBox6.Checked = false;
                        i++;
                        textBox24.Text = worksheet.Cells[i, 1].ToString();
                    }
                    else
                        MessageBox.Show("정상적인 파일이 아닙니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void button31_Click(object sender, EventArgs e)
        {
            commmode = "lte";
            button31.BackColor = SystemColors.ButtonHighlight;
            button33.BackColor = SystemColors.Control;
            button32.BackColor = SystemColors.Control;
            button68.Enabled = true;

            groupBox2.Enabled = true;
            groupBox6.Enabled = false;
            if (imsmode == "yes")
                groupBox5.Enabled = true;
            else
                groupBox5.Enabled = false;
        }

        private void button33_Click(object sender, EventArgs e)
        {
            commmode = "catm1";
            button31.BackColor = SystemColors.Control;
            button33.BackColor = SystemColors.ButtonHighlight;
            button32.BackColor = SystemColors.Control;
            button68.Enabled = true;

            groupBox2.Enabled = false;
            groupBox6.Enabled = false;
            if (imsmode == "yes")
                groupBox5.Enabled = true;
            else
                groupBox5.Enabled = false;
        }

        private void button32_Click(object sender, EventArgs e)
        {
            commmode = "nbiot";
            button31.BackColor = SystemColors.Control;
            button33.BackColor = SystemColors.Control;
            button32.BackColor = SystemColors.ButtonHighlight;
            button68.Enabled = false;

            groupBox2.Enabled = false;
            groupBox6.Enabled = true;
            groupBox5.Enabled = false;
        }

        private void button68_Click(object sender, EventArgs e)
        {
            if (commmode != "nbiot")
            {
                if (imsmode == "yes")
                {
                    imsmode = "no";
                    button68.BackColor = SystemColors.Control;
                    groupBox5.Enabled = false;
                }
                else
                {
                    imsmode = "yes";
                    button68.BackColor = SystemColors.ButtonHighlight;
                    groupBox5.Enabled = true;
                }
            }
            else
                MessageBox.Show("NB-IoT에서는 IMS를 지원하지 않습니다.");
        }

        private void button61_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox31.Text);
            actionState = states.testatcmd.ToString();
        }

        private void button75_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox30.Text);
            actionState = states.testatcmd.ToString();
        }

        private void button67_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox32.Text);
            actionState = states.testatcmd.ToString();
        }

        private void button66_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox27.Text);
            actionState = states.testatcmd.ToString();
        }

        private void button65_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox26.Text);
            actionState = states.testatcmd.ToString();
        }

        private void button64_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox25.Text);
            actionState = states.testatcmd.ToString();
        }

        private void button84_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox41.Text);
            actionState = states.testatcmd.ToString();
        }

        private void button69_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox23.Text);
            actionState = states.testatcmd.ToString();
        }

        private void button82_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox39.Text);
            actionState = states.testatcmd.ToString();
        }

        private void button79_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox37.Text);
            actionState = states.testatcmd.ToString();
        }

        private void button78_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox36.Text);
            actionState = states.testatcmd.ToString();
        }

        private void button77_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox35.Text);
            actionState = states.testatcmd.ToString();
        }

        private void button76_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox34.Text);
            actionState = states.testatcmd.ToString();
        }

        private void button60_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox42.Text);
            actionState = states.testatcmd.ToString();
        }

        private void button85_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox43.Text);
            actionState = states.testatcmd.ToString();
        }

        private void button59_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox22.Text);
            actionState = states.testatcmd.ToString();
        }

        private void button58_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox21.Text);
            actionState = states.testatcmd.ToString();
        }

        private void button57_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox20.Text);
            actionState = states.testatcmd.ToString();
        }

        private void button56_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox19.Text);
            actionState = states.testatcmd.ToString();
        }

        private void button55_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox18.Text);
            actionState = states.testatcmd.ToString();
        }

        private void button43_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox17.Text);
            actionState = states.testatcmd.ToString();
        }

        private void button54_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox16.Text);
            actionState = states.testatcmd.ToString();
        }

        private void button53_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox15.Text);
            actionState = states.testatcmd.ToString();
        }

        private void button52_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox14.Text);
            actionState = states.testatcmd.ToString();
        }

        private void button51_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox13.Text);
            actionState = states.testatcmd.ToString();
        }

        private void button50_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox12.Text);
            actionState = states.testatcmd.ToString();
        }

        private void button49_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox11.Text);
            actionState = states.testatcmd.ToString();
        }

        private void button48_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox10.Text);
            actionState = states.testatcmd.ToString();
        }

        private void button47_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox9.Text);
            actionState = states.testatcmd.ToString();
        }

        private void button46_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox8.Text);
            actionState = states.testatcmd.ToString();
        }

        private void button45_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox7.Text);
            actionState = states.testatcmd.ToString();
        }

        private void button37_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox1.Text);
            actionState = states.testatcmd.ToString();
        }

        private void button38_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox6.Text);
            actionState = states.testatcmd.ToString();
        }

        private void button39_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox5.Text);
            actionState = states.testatcmd.ToString();
        }

        private void button42_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox4.Text);
            actionState = states.testatcmd.ToString();
        }

        private void button74_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox28.Text);
            actionState = states.testatcmd.ToString();
        }

        private void button44_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox2.Text);
            actionState = states.atdtatcmd.ToString();
        }

        private void button83_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox48.Text);
            actionState = states.getmanufac.ToString();
        }

        private void button91_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox47.Text);
            actionState = states.getmodel.ToString();
        }

        private void button89_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox49.Text);
            nextresponse = textBox40.Text;
            actionState = states.getimei.ToString();
        }

        private void button88_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox44.Text);
            nextresponse = textBox57.Text;
            actionState = states.getmodemver.ToString();
        }

        private void button90_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox46.Text);
            nextresponse = textBox33.Text;
            actionState = states.getimsi.ToString();
        }

        private void button71_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox45.Text);
            nextresponse = textBox38.Text;
            actionState = states.geticcid.ToString();
        }

        private void button86_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox24.Text);
            actionState = states.rfreset.ToString();
        }

        private void button87_Click(object sender, EventArgs e)
        {
            getDeviveInfo();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 1)
                groupBox11.Enabled = true;
            else
                groupBox11.Enabled = false;
        }
    }

    public class Device
    {
        public string imsi { get; set; }            // 디바이스 전화번호
        public string imei { get; set; }            // 디바이스 IMEI
        public string iccid { get; set; }           // 디바이스 ICCID
        public string entityId { get; set; }        // oneM2M 디바이스 EntityID

        public string maker { get; set; }           // 모듈 제조사
        public string model { get; set; }           // 모듈 모델명
        public string version { get; set; }         // 모듈 펌웨어 버전

        public string type { get; set; }            // 플랫폼 연동 방식 (None/oneM2M/LwM2M)
    }
}
