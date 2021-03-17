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
using System.Net;
using Newtonsoft.Json.Linq;

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

        private enum lwm2mtc
        {
            tc0201,
            tc0202,
            tc0203,

            tc0301,
            tc0302,
            tc0303,

            tc0401,

            tc0501,
            tc0502,
            tc0503,

            tc0601,
            tc0602,
            tc0603,
        }

        private enum onem2mtc
        {
            tc020101,
            tc020102,

            tc020201,

            tc020301,

            tc020401,

            tc020501,
            tc020502,
            tc020503,
            tc020504,
            tc020505,

            tc020601,
            tc020602,
            tc020603,
            tc020604,

            tc020701,

            tc020801,

            tc020901,
            tc020902,
            tc020903,
            tc020904,

            tc021001,
            tc021002,
            tc021003,
            tc021004,

            tc021101,
            tc021102,
            tc021103,
            tc021104,

            //tc021201,
            tc021202,
            tc021203,
            tc021204,

            tc021301,
            tc021302,
            tc021303,

            tc021401,

        }

        string dataIN = string.Empty;
        string nextcommand = string.Empty;    //OK를 받은 후 전송할 명령어가 존재하는 경우
                                    //예를들어 +CEREG와 같이 OK를 포함한 응답 값을 받은 경우 OK처리 후에 명령어를 전송해야 한다
                                    // states 값을 바꾸고 명령어를 전송하면 명령의 응답을 받기전 이전에 받았던 OK에 동작할 수 있다.
        string nextresponse = string.Empty;   //응답에 prefix가 존재하는 경우
        string commmode = "catm1";
        string imsmode = "no";
        string actionState = "idle";
        ServiceServer svr = new ServiceServer();
        Device dev = new Device();
        TCResult tc = new TCResult();

        Dictionary<string, string> commands = new Dictionary<string, string>();
        Dictionary<char, int> bcdvalues = new Dictionary<char, int>();
        Dictionary<string, string> lwm2mtclist = new Dictionary<string, string>();
        Dictionary<string, string> onem2mtclist = new Dictionary<string, string>();

        HttpWebRequest wReq;
        HttpWebResponse wRes;

        string brkUrl = "https://testbrk.onem2m.uplus.co.kr:443"; // BRK(oneM2M 개발기)       
        string brkUrlL = "https://testbrks.onem2m.uplus.co.kr:8443"; // BRK(LwM2M 개발기)       
        string mefUrl = "https://testmef.onem2m.uplus.co.kr:443"; // MEF(개발기)
        string logUrl = "http://106.103.228.184/api/v1"; // oneM2M log(개발기)

        string tcStartTime = string.Empty;
        string tcmsg = string.Empty;

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

            lwm2mtclist.Add("tc0201", "2.1 LWM2M 단말 초기 설정 동작 확인 시험");
            lwm2mtclist.Add("tc0202", "2.2 Bootstrap 절차 및 AT command 확인 시험");
            lwm2mtclist.Add("tc0203", "2.3 Bootstrap 상세 동작 확인 시험");
            lwm2mtclist.Add("tc0301", "3.1 Register 절차 및 AT command 확인 시험");
            lwm2mtclist.Add("tc0302", "3.2 Register 상세 동작 확인 시험");
            lwm2mtclist.Add("tc0303", "3.3 Register Update 확인 시험");
            lwm2mtclist.Add("tc0401", "4.1 De-Register 절차 및 AT command 확인 시험");
            lwm2mtclist.Add("tc0501", "5.1 Data 송신 (Data Notification)");
            lwm2mtclist.Add("tc0502", "5.2 Data 수신 (Device Control)");
            lwm2mtclist.Add("tc0503", "5.3 Device Staus Check");
            lwm2mtclist.Add("tc0601", "6.1 펌웨어 체크 동작 확인");
            lwm2mtclist.Add("tc0602", "6.2 모듈 펌웨어 업그레이드 시험");
            lwm2mtclist.Add("tc0603", "6.3 단말 펌웨어 업그레이드 시험");

            onem2mtclist.Add("tc020101", "2.1.1 oneM2M URL 설정");
            onem2mtclist.Add("tc020102", "2.1.2 oneM2M 플랫폼 동작 설정");
            onem2mtclist.Add("tc020201", "2.2.1 MEF 인증 (at command oneM2M연동 모두 확인)");
            onem2mtclist.Add("tc020301", "2.3.1 단말 IP 송신(remoteCSE조회)");
            onem2mtclist.Add("tc020401", "2.4.1 CSEBase 조회");
            onem2mtclist.Add("tc020501", "2.5.1 remoteCSE 생성요청");
            onem2mtclist.Add("tc020502", "2.5.2 데이터 폴더 생성");
            onem2mtclist.Add("tc020503", "2.5.3 구독 등록");
            onem2mtclist.Add("tc020504", "2.5.4 데이터 생성");
            onem2mtclist.Add("tc020505", "2.5.5 remoteCSE 업데이트요청");
            onem2mtclist.Add("tc020601", "2.6.1 데이터 수신 이벤트");
            onem2mtclist.Add("tc020602", "2.6.2 데이터 자동 수신 모드 설정");
            onem2mtclist.Add("tc020603", "2.6.3 데이터 자동 수신");
            onem2mtclist.Add("tc020604", "2.6.4 데이터 수동 수신 모드 설정");
            onem2mtclist.Add("tc020701", "2.7.1 데이터 읽기");
            onem2mtclist.Add("tc020801", "2.8.1 M2MM(단말) IP 변경");
            onem2mtclist.Add("tc020901", "2.9.1 권한 관리 정보 생성");
            onem2mtclist.Add("tc020902", "2.9.2 권한 관리 정보 읽기");
            onem2mtclist.Add("tc020903", "2.9.3 권한 관리 정보 업데이트");
            onem2mtclist.Add("tc020904", "2.9.4 권한 관리 정보 삭제");
            onem2mtclist.Add("tc021001", "2.10.1 Device FW 신규 버전 요청");
            onem2mtclist.Add("tc021002", "2.10.2 Device FW update Noti");
            onem2mtclist.Add("tc021003", "2.10.3 Device FW update start");
            onem2mtclist.Add("tc021004", "2.10.4 Device FW update finish");
            onem2mtclist.Add("tc021101", "2.11.1 Modem FW 신규 버전 요청");
            onem2mtclist.Add("tc021102", "2.11.2 Modem FW update Noti");
            onem2mtclist.Add("tc021103", "2.11.3 Modem FW update start");
            onem2mtclist.Add("tc021104", "2.11.4 Modem FW update Finish");
            //onem2mtclist.Add("tc021201", "2.12.1 데이터 삭제");
            onem2mtclist.Add("tc021202", "2.12.2 구독 등록 삭제");
            onem2mtclist.Add("tc021203", "2.12.3 데이터 폴더 삭제");
            onem2mtclist.Add("tc021204", "2.12.4 remoteCSE 삭제");
            onem2mtclist.Add("tc021301", "2.13.1 Device data forwarding");
            onem2mtclist.Add("tc021302", "2.13.2 Device control");
            onem2mtclist.Add("tc021303", "2.13.3 Device Status Check");
            onem2mtclist.Add("tc021401", "2.14.1 Remote Reset");

            /////   디바이스 초기값 설정
            dev.entityId = string.Empty;
            dev.type = string.Empty;

            /////   서버 초기값 설정
            svr.enrmtKeyId = string.Empty;
            svr.entityId = string.Empty;

            tc.state = string.Empty;
            tc.lwm2m = new string[(int)lwm2mtc.tc0603 + 1, 5];
            for (int i = 0; i < (int)lwm2mtc.tc0603 + 1; i++)
            {
                tc.lwm2m[i, 0] = "Not TEST";
                tc.lwm2m[i, 1] = string.Empty;
                tc.lwm2m[i, 2] = string.Empty;
                tc.lwm2m[i, 3] = string.Empty;
                tc.lwm2m[i, 4] = string.Empty;
            }
            tc.onem2m = new string[(int)onem2mtc.tc021401 + 1, 5];
            for (int i = 0; i < (int)onem2mtc.tc021401 + 1; i++)
            {
                tc.onem2m[i, 0] = "Not TEST";
                tc.onem2m[i, 1] = string.Empty;
                tc.onem2m[i, 2] = string.Empty;
                tc.onem2m[i, 3] = string.Empty;
                tc.onem2m[i, 4] = string.Empty;
            }

            tbTCResult.Text = string.Empty;
            tBoxDataIN.Text = string.Empty;
            tbLog.Text = string.Empty;


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
            msg_form += currenttime.ToString("hh:mm:ss.fff") +"("+actionState+") ";

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
                "AT",
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

                // 후처리가 필요한 명령어인데 고정 값이 없고 data만 있는 경우
                //예를들어 IMSI, IMEI 요청에 대한 응답 값 등
                if ((find_msg == false) && (rxMsg != "\r") && (rxMsg != "\n"))
                {
                    //logPrintInTextBox("No Matching Data!!!","");

                    this.parseNoPrefixData(rxMsg);
                }
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
                case states.autogeticcid:
                    string[] strchs = str2.Split(' ');        // Remove first char ' '
                    if (strchs.Length > 1)
                        str2 = strchs[strchs.Length - 1];

                    if (str2.Length > 19)
                        textBox88.Text = dev.iccid = str2.Substring(str2.Length - 20, 19);
                    else
                        textBox88.Text = dev.iccid = str2;

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
                        // 단말 정보 자동 갱신 순서
                        // autogetmanufac - autogetmodel - autogetimei - autogetmodemver - (autoimsi)
                        case states.autogetimsi:

                            this.sendDataOut(textBox46.Text);
                            nextresponse = textBox33.Text;
                            actionState = states.autogetimsi.ToString();
                            break;
                        case states.autogeticcid:
                            this.sendDataOut(textBox45.Text);
                            nextresponse = textBox38.Text;
                            actionState = states.autogeticcid.ToString();
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
                    textBox85.Text = dev.maker = str1;
                    actionState = states.idle.ToString();
                    this.logPrintInTextBox("제조사값이 " + dev.maker + "로 저장되었습니다.", "");
                    break;
                // 단말 정보 자동 갱신 순서
                // (autogetmanufac) - (autogetmodel) - autogetimei - autogetmodemver
                case states.autogetmanufac:
                    textBox85.Text = dev.maker = str1;
                    progressBar1.Value = 60;
                    this.logPrintInTextBox("제조사값이 " + dev.maker + "로 저장되었습니다.", "");
                    nextcommand = states.autogetmodel.ToString();
                    break;
                case states.getmodel:
                    textBox86.Text = dev.model = str1;
                    tbDeviceName.Text = str1;
                    this.logPrintInTextBox("모델값이 " + dev.model + "로 저장되었습니다.", "");
                    break;
                // 단말 정보 자동 갱신 순서
                // autogetmanufac - (autogetmodel) - (autogetimei) - autogetmodemver
                case states.autogetmodel:
                    textBox86.Text = dev.model = str1;
                    progressBar1.Value = 70;
                    tbDeviceName.Text = str1;
                    this.logPrintInTextBox("모델값이 " + dev.model + "로 저장되었습니다.", "");

                    setModelConfig(str1);
                    nextcommand = states.autogetimei.ToString();
                    break;
                case states.getimei:
                    textBox89.Text = tbIMEI.Text = dev.imei = str1;
                    logPrintInTextBox("IMEI를 " + dev.imei + "로 저장하였습니다.", "");

                    actionState = states.idle.ToString();
                    break;
                case states.autogetimei:
                    // 단말 정보 자동 갱신 순서
                    // autogetmanufac - autogetmodel - (autogetimei) - (autogetmodemver)
                    textBox89.Text = tbIMEI.Text = dev.imei = str1;
                    tbIMEI.Text = str1;
                    logPrintInTextBox("IMEI를 " + dev.imei + "로 저장하였습니다.", "");
                    progressBar1.Value = 90;

                    nextcommand = states.autogetmodemver.ToString();       // 모듈 정보를 모두 읽고 모뎀 버전 정보 조회
                    break;
                case states.getimsi:
                    textBox87.Text = str1;
                    if (str1.StartsWith("45006"))
                    {
                        string ctn = "0" + str1.Substring(5, str1.Length - 5);

                        textBox93.Text = textBox97.Text = tbDeviceCTN.Text = textBox1.Text = dev.imsi = ctn;
                        this.logPrintInTextBox("IMSI값이 " + dev.imsi + "로 저장되었습니다.", "");
                    }
                    else
                        this.logPrintInTextBox("USIM 상태 확인이 필요합니다.", "");

                    actionState = states.idle.ToString();
                    break;
                case states.autogetimsi:
                    textBox87.Text = str1;
                    if (str1.StartsWith("45006"))
                    {
                        string ctn = "0" + str1.Substring(5, str1.Length - 5);

                        textBox93.Text = textBox97.Text = tbDeviceCTN.Text = textBox1.Text = dev.imsi = ctn;
                        this.logPrintInTextBox("IMSI값이 " + dev.imsi + "로 저장되었습니다.", "");
                    }
                    else
                        this.logPrintInTextBox("USIM 상태 확인이 필요합니다.", "");

                    nextcommand = states.autogeticcid.ToString();
                    break;
                case states.getmodemver:
                    tbDeviceVer.Text = textBox90.Text = dev.version = str1;
                    actionState = states.idle.ToString();
                    this.logPrintInTextBox("모뎀버전이 " + dev.version + "로 저장되었습니다.", "");

                    break;
                case states.autogetmodemver:
                    tbDeviceVer.Text = textBox90.Text = dev.version = str1;
                    progressBar1.Value = 100;
                    this.logPrintInTextBox("모뎀버전이 " + dev.version + "로 저장되었습니다.", "");

                    nextcommand = states.autogetimsi.ToString();
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
                if (cbImsPDN.SelectedIndex == 1)
                    sw.WriteLine("imsPDN_number = " + "1");
                else if (cbImsPDN.SelectedIndex == 2)
                    sw.WriteLine("imsPDN_number = " + "2");
                else
                    sw.WriteLine("imsPDN_number = " + "0");
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

        private void button63_Click(object sender, EventArgs e)
        {
            string pathname = @"c:\temp\seriallog\";
            string filename = "LTD_" + tbDeviceName.Text + "_proxy.xls";

            Directory.CreateDirectory(pathname);

            try
            {
                Workbook workbook = new Workbook();
                Worksheet worksheet = new Worksheet("options");
                int i = 0;
                worksheet.Cells[0, 0] = new Cell(button73.Text);
                worksheet.Cells[0, 1] = new Cell(comboBox3.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell("COM PORT");
                worksheet.Cells[i, 1] = new Cell(cBoxCOMPORT.Text);

                worksheet.Cells.ColumnWidth[0, 2] = 7000;
                workbook.Worksheets.Add(worksheet);

                i = 0;
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
                worksheet.Cells[i, 0] = new Cell(label18.Text);
                worksheet.Cells[i, 1] = new Cell(comboBox1.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button83.Text);
                worksheet.Cells[i, 1] = new Cell("getmanufac");
                worksheet.Cells[i, 2] = new Cell(textBox48.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button91.Text);
                worksheet.Cells[i, 1] = new Cell("getmodel");
                worksheet.Cells[i, 2] = new Cell(textBox47.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button90.Text);
                worksheet.Cells[i, 1] = new Cell("getimsi");
                worksheet.Cells[i, 2] = new Cell(textBox46.Text);
                worksheet.Cells[i, 3] = new Cell(textBox33.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button71.Text);
                worksheet.Cells[i, 1] = new Cell("geticcid");
                worksheet.Cells[i, 2] = new Cell(textBox45.Text);
                worksheet.Cells[i, 3] = new Cell(textBox38.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button89.Text);
                worksheet.Cells[i, 1] = new Cell("getimei");
                worksheet.Cells[i, 2] = new Cell(textBox49.Text);
                worksheet.Cells[i, 3] = new Cell(textBox40.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button88.Text);
                worksheet.Cells[i, 1] = new Cell("getmodemver");
                worksheet.Cells[i, 2] = new Cell(textBox44.Text);
                worksheet.Cells[i, 3] = new Cell(textBox57.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button86.Text);
                worksheet.Cells[i, 1] = new Cell("rfreset");
                worksheet.Cells[i, 2] = new Cell(textBox24.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button99.Text);
                worksheet.Cells[i, 1] = new Cell("setcereg");
                worksheet.Cells[i, 2] = new Cell(textBox58.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button100.Text);
                worksheet.Cells[i, 1] = new Cell("rfon");
                worksheet.Cells[i, 2] = new Cell(textBox59.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button101.Text);
                worksheet.Cells[i, 1] = new Cell("rfoff");
                worksheet.Cells[i, 2] = new Cell(textBox60.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button62.Text);
                worksheet.Cells[i, 1] = new Cell("getcereg");
                worksheet.Cells[i, 2] = new Cell(textBox61.Text);

                worksheet.Cells.ColumnWidth[0, 3] = 5000;
                workbook.Worksheets.Add(worksheet);


                i = 0;
                worksheet = new Worksheet("lwm2matcmd");
                worksheet.Cells[i, 0] = new Cell(label31.Text);
                worksheet.Cells[i, 1] = new Cell(textBox62.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button102.Text);
                worksheet.Cells[i, 1] = new Cell(textBox63.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(label28.Text);
                worksheet.Cells[i, 1] = new Cell(tbSvcSvrCd.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(label33.Text);
                worksheet.Cells[i, 1] = new Cell(tbSvcSvrNum.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button98.Text);
                worksheet.Cells[i, 1] = new Cell("setncdp");
                worksheet.Cells[i, 2] = new Cell(textBox56.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button92.Text);
                worksheet.Cells[i, 1] = new Cell("setepns");
                worksheet.Cells[i, 2] = new Cell(textBox50.Text);
                worksheet.Cells[i, 3] = new Cell(checkBox2.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button97.Text);
                worksheet.Cells[i, 1] = new Cell("setmbsps");
                worksheet.Cells[i, 2] = new Cell(textBox55.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button105.Text);
                worksheet.Cells[i, 1] = new Cell("bootstrapmode");
                worksheet.Cells[i, 2] = new Cell(textBox66.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button106.Text);
                worksheet.Cells[i, 1] = new Cell("bootstrap");
                worksheet.Cells[i, 2] = new Cell(textBox67.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button96.Text);
                worksheet.Cells[i, 1] = new Cell("register");
                worksheet.Cells[i, 2] = new Cell(textBox54.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button95.Text);
                worksheet.Cells[i, 1] = new Cell("sendmsghex");
                worksheet.Cells[i, 2] = new Cell(textBox53.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button107.Text);
                worksheet.Cells[i, 1] = new Cell("recvmsghex");
                worksheet.Cells[i, 2] = new Cell(textBox68.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button94.Text);
                worksheet.Cells[i, 1] = new Cell("deregister");
                worksheet.Cells[i, 2] = new Cell(textBox52.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button93.Text);
                worksheet.Cells[i, 1] = new Cell("sendmsgver");
                worksheet.Cells[i, 2] = new Cell(textBox51.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button108.Text);
                worksheet.Cells[i, 1] = new Cell("recvfota");
                worksheet.Cells[i, 2] = new Cell(textBox69.Text);

                worksheet.Cells.ColumnWidth[0] = 6000;
                worksheet.Cells.ColumnWidth[1] = 5000;
                worksheet.Cells.ColumnWidth[2] = 10000;
                workbook.Worksheets.Add(worksheet);

                i = 0;
                worksheet = new Worksheet("smstset");
                worksheet.Cells[i, 0] = new Cell("[Common]");
                i++;
                worksheet.Cells[i, 0] = new Cell(btnModel.Text);
                worksheet.Cells[i, 1] = new Cell(cbImsPDN.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(btnManufac.Text);
                worksheet.Cells[i, 1] = new Cell(cbImsIP.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(btnIMSI.Text);
                worksheet.Cells[i, 1] = new Cell(cbMultiPDN.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button3.Text);
                worksheet.Cells[i, 1] = new Cell(tbChannel1.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button2.Text);
                worksheet.Cells[i, 1] = new Cell(tbChannel2.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button1.Text);
                worksheet.Cells[i, 1] = new Cell(tbChannel3.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button7.Text);
                worksheet.Cells[i, 1] = new Cell(tbIMEI.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button6.Text);
                worksheet.Cells[i, 1] = new Cell(cbAuto2ndPDN.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button5.Text);
                worksheet.Cells[i, 1] = new Cell(cbEMC.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button4.Text);
                worksheet.Cells[i, 1] = new Cell(cbCA.Text);
                i += 2;
                worksheet.Cells[i, 0] = new Cell("[Capability]");
                i++;
                worksheet.Cells[i, 0] = new Cell(button17.Text);
                worksheet.Cells[i, 1] = new Cell(cbCatagory.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button16.Text);
                worksheet.Cells[i, 1] = new Cell(cbBand1.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button15.Text);
                worksheet.Cells[i, 1] = new Cell(cbBand5.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button14.Text);
                worksheet.Cells[i, 1] = new Cell(cbBand7.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button13.Text);
                worksheet.Cells[i, 1] = new Cell(cbFGI4.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button12.Text);
                worksheet.Cells[i, 1] = new Cell(cbFGI5.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button8.Text);
                worksheet.Cells[i, 1] = new Cell(cbFGI17.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button9.Text);
                worksheet.Cells[i, 1] = new Cell(cbFGI18.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button10.Text);
                worksheet.Cells[i, 1] = new Cell(cbFGI28.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button11.Text);
                worksheet.Cells[i, 1] = new Cell(cbRachR9.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button18.Text);
                worksheet.Cells[i, 1] = new Cell(cbLogR10.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button19.Text);
                worksheet.Cells[i, 1] = new Cell(cbStandaloneGNSS.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button20.Text);
                worksheet.Cells[i, 1] = new Cell(cbBandCombin.Text);
                i += 2;
                worksheet.Cells[i, 0] = new Cell("[VOLTE_SMS]");
                i++;
                worksheet.Cells[i, 0] = new Cell(button30.Text);
                worksheet.Cells[i, 1] = new Cell(tbDeviceName.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button29.Text);
                worksheet.Cells[i, 1] = new Cell(tbDeviceVer.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button28.Text);
                worksheet.Cells[i, 1] = new Cell(tbDeviceType.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button27.Text);
                worksheet.Cells[i, 1] = new Cell(tbTTAVer.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button26.Text);
                worksheet.Cells[i, 1] = new Cell(cbIPSec.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button25.Text);
                worksheet.Cells[i, 1] = new Cell(cbSMS.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button21.Text);
                worksheet.Cells[i, 1] = new Cell(cbVoice.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button22.Text);
                worksheet.Cells[i, 1] = new Cell(cbVideo.Text);
                i += 2;
                worksheet.Cells[i, 0] = new Cell("[NBIoT]");
                i++;
                worksheet.Cells[i, 0] = new Cell(button36.Text);
                worksheet.Cells[i, 1] = new Cell(cbNBIPVer.Text);

                worksheet.Cells.ColumnWidth[0] = 5000;
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
            openExcelFile();
        }

        private void openExcelFile()
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

                    ///////////////////////////////////////////////////////////// PCT장비 AT command 자동/수동
                    Worksheet worksheet = workbook.Worksheets[0];
                    if (worksheet.Name == "options" && worksheet.Cells[0, 0].ToString() == button73.Text)
                    {
                        int i = 0;
                        if (worksheet.Cells[0, 1].ToString() == "자동")
                            comboBox3.SelectedIndex = 0;
                        else
                            comboBox3.SelectedIndex = 1;
                        i++;
                        cBoxCOMPORT.Text = worksheet.Cells[i, 1].ToString();

                        ///////////////////////////////////////////////////////////////// PCT 장비 AT command 매핑 1
                        worksheet = workbook.Worksheets[1];
                        i = 0;
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

                        //////////////////////////////////////////////// PCT 장비 AT command 매핑 2
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

                        /////////////////////////////////////////////// 플랫폼 검증 앱 공통 AT command
                        i = 0;
                        worksheet = workbook.Worksheets[3];
                        comboBox1.Text = worksheet.Cells[i, 1].ToString();
                        if (comboBox1.SelectedIndex == 1)
                            groupBox11.Enabled = true;
                        else
                            groupBox11.Enabled = false;
                        i++;
                        textBox48.Text = worksheet.Cells[i, 2].ToString();
                        i++;
                        textBox47.Text = worksheet.Cells[i, 2].ToString();
                        i++;
                        textBox46.Text = worksheet.Cells[i, 2].ToString();
                        textBox33.Text = worksheet.Cells[i, 3].ToString();
                        i++;
                        textBox45.Text = worksheet.Cells[i, 2].ToString();
                        textBox38.Text = worksheet.Cells[i, 3].ToString();
                        i++;
                        textBox49.Text = worksheet.Cells[i, 2].ToString();
                        textBox40.Text = worksheet.Cells[i, 3].ToString();
                        i++;
                        textBox44.Text = worksheet.Cells[i, 2].ToString();
                        textBox57.Text = worksheet.Cells[i, 3].ToString();
                        i++;
                        textBox24.Text = worksheet.Cells[i, 2].ToString();
                        i++;
                        textBox58.Text = worksheet.Cells[i, 2].ToString();
                        i++;
                        textBox59.Text = worksheet.Cells[i, 2].ToString();
                        i++;
                        textBox60.Text = worksheet.Cells[i, 2].ToString();
                        i++;
                        textBox61.Text = worksheet.Cells[i, 2].ToString();

                        /////////////////////////////////////////////// 플랫폼 검증 앱 LwM2M AT command
                        i = 0;
                        worksheet = workbook.Worksheets[4];
                        textBox62.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        textBox63.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        tbSvcSvrCd.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        tbSvcSvrNum.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        textBox56.Text = worksheet.Cells[i, 2].ToString();
                        i++;
                        textBox50.Text = worksheet.Cells[i, 2].ToString();
                        checkBox2.Text = worksheet.Cells[i, 3].ToString();
                        i++;
                        textBox55.Text = worksheet.Cells[i, 2].ToString();
                        i++;
                        textBox66.Text = worksheet.Cells[i, 2].ToString();
                        i++;
                        textBox67.Text = worksheet.Cells[i, 2].ToString();
                        i++;
                        textBox54.Text = worksheet.Cells[i, 2].ToString();
                        i++;
                        textBox53.Text = worksheet.Cells[i, 2].ToString();
                        i++;
                        textBox68.Text = worksheet.Cells[i, 2].ToString();
                        i++;
                        textBox52.Text = worksheet.Cells[i, 2].ToString();
                        i++;
                        textBox51.Text = worksheet.Cells[i, 2].ToString();
                        i++;
                        textBox69.Text = worksheet.Cells[i, 2].ToString();

                        //////////////////////////////////////////////////////////////// PCT 장비 옵션 설정
                        i = 1;
                        worksheet = workbook.Worksheets[5];
                        cbImsPDN.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        cbImsIP.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        cbMultiPDN.Text = worksheet.Cells[i, 1].ToString();
                        if (cbMultiPDN.Text == "지원")
                            cbMultiPDN.Checked = true;
                        else
                            cbMultiPDN.Checked = false;
                        i++;
                        tbChannel1.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        tbChannel2.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        tbChannel3.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        tbIMEI.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        cbAuto2ndPDN.Text = worksheet.Cells[i, 1].ToString();
                        if (cbAuto2ndPDN.Text == "올림")
                            cbAuto2ndPDN.Checked = true;
                        else
                            cbAuto2ndPDN.Checked = false;
                        i++;
                        cbEMC.Text = worksheet.Cells[i, 1].ToString();
                        if (cbEMC.Text == "지원")
                            cbEMC.Checked = true;
                        else
                            cbEMC.Checked = false;
                        i++;
                        cbCA.Text = worksheet.Cells[i, 1].ToString();
                        if (cbCA.Text == "지원")
                            cbCA.Checked = true;
                        else
                            cbCA.Checked = false;
                        i += 3;
                        cbCatagory.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        cbBand1.Text = worksheet.Cells[i, 1].ToString();
                        if (cbBand1.Text == "지원")
                            cbBand1.Checked = true;
                        else
                            cbBand1.Checked = false;
                        i++;
                        cbBand5.Text = worksheet.Cells[i, 1].ToString();
                        if (cbBand5.Text == "지원")
                            cbBand5.Checked = true;
                        else
                            cbBand5.Checked = false;
                        i++;
                        cbBand7.Text = worksheet.Cells[i, 1].ToString();
                        if (cbBand7.Text == "지원")
                            cbBand7.Checked = true;
                        else
                            cbBand7.Checked = false;
                        i++;
                        cbFGI4.Text = worksheet.Cells[i, 1].ToString();
                        if (cbFGI4.Text == "지원")
                            cbFGI4.Checked = true;
                        else
                            cbFGI4.Checked = false;
                        i++;
                        cbFGI5.Text = worksheet.Cells[i, 1].ToString();
                        if (cbFGI5.Text == "지원")
                            cbFGI5.Checked = true;
                        else
                            cbFGI5.Checked = false;
                        i++;
                        cbFGI17.Text = worksheet.Cells[i, 1].ToString();
                        if (cbFGI17.Text == "지원")
                            cbFGI17.Checked = true;
                        else
                            cbFGI17.Checked = false;
                        i++;
                        cbFGI18.Text = worksheet.Cells[i, 1].ToString();
                        if (cbFGI18.Text == "지원")
                            cbFGI18.Checked = true;
                        else
                            cbFGI18.Checked = false;
                        i++;
                        cbFGI28.Text = worksheet.Cells[i, 1].ToString();
                        if (cbFGI28.Text == "지원")
                            cbFGI28.Checked = true;
                        else
                            cbFGI28.Checked = false;
                        i++;
                        cbRachR9.Text = worksheet.Cells[i, 1].ToString();
                        if (cbRachR9.Text == "지원")
                            cbRachR9.Checked = true;
                        else
                            cbRachR9.Checked = false;
                        i++;
                        cbLogR10.Text = worksheet.Cells[i, 1].ToString();
                        if (cbLogR10.Text == "지원")
                            cbLogR10.Checked = true;
                        else
                            cbLogR10.Checked = false;
                        i++;
                        cbStandaloneGNSS.Text = worksheet.Cells[i, 1].ToString();
                        if (cbStandaloneGNSS.Text == "지원")
                            cbStandaloneGNSS.Checked = true;
                        else
                            cbStandaloneGNSS.Checked = false;
                        i++;
                        cbBandCombin.Text = worksheet.Cells[i, 1].ToString();
                        if (cbBandCombin.Text == "지원")
                            cbBandCombin.Checked = true;
                        else
                            cbBandCombin.Checked = false;
                        i += 3;
                        tbDeviceName.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        tbDeviceVer.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        tbDeviceType.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        tbTTAVer.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        cbIPSec.Text = worksheet.Cells[i, 1].ToString();
                        if (cbIPSec.Text == "지원")
                            cbIPSec.Checked = true;
                        else
                            cbIPSec.Checked = false;
                        i++;
                        cbSMS.Text = worksheet.Cells[i, 1].ToString();
                        if (cbSMS.Text == "지원")
                            cbSMS.Checked = true;
                        else
                            cbSMS.Checked = false;
                        i++;
                        cbVoice.Text = worksheet.Cells[i, 1].ToString();
                        if (cbVoice.Text == "지원")
                            cbVoice.Checked = true;
                        else
                            cbVoice.Checked = false;
                        i++;
                        cbVideo.Text = worksheet.Cells[i, 1].ToString();
                        if (cbVideo.Text == "지원")
                            cbVideo.Checked = true;
                        else
                            cbVideo.Checked = false;
                        i += 3;
                        cbNBIPVer.Text = worksheet.Cells[i, 1].ToString();
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

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
                checkBox2.Text = "자동";
            else
                checkBox2.Text = "수동";
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            openExcelFile();
        }

        private void button63_Click_1(object sender, EventArgs e)
        {
            this.sendDataOut(textBox64.Text);
        }

        private void btnGetLogList_Click(object sender, EventArgs e)
        {
            string kind = "type=lwm2m";
            if (comboBox1.Text == "oneM2M")
                kind = "type=onem2m";
            if (textBox93.Text != string.Empty)
                kind += "&ctn=" + textBox93.Text;
            //if (tcStartTime != string.Empty)
            //    kind += "&from=" + tcStartTime;
            getSvrLoglists(kind, "man");
        }

        private void getSvrLoglists(string kind, string mode)
        {
            ReqHeader header = new ReqHeader();
            header.Url = logUrl + "/logs?" + kind;
            header.Method = "GET";
            header.ContentType = "application/json";
            header.X_M2M_RI = DateTime.Now.ToString("yyyyMMddHHmmss") + "LogList";
            header.X_M2M_Origin = svr.entityId;
            header.X_MEF_TK = svr.token;
            header.X_MEF_EKI = svr.enrmtKeyId;
            string retStr = GetHttpLog(header, string.Empty);

            if (retStr != string.Empty)
            {
                //LogWriteNoTime(retStr);
                try
                {
                    JArray jarr = JArray.Parse(retStr); //json 객체로

                    listBox1.Items.Clear();
                    listBox2.Items.Clear();
                    listBox3.Items.Clear();
                    foreach (JObject jobj in jarr)
                    {
                        string time = jobj["logTime"].ToString();
                        string logtime = time.Substring(8, 2) + ":" + time.Substring(10, 2) + ":" + time.Substring(12, 2);
                        var pathInfo = jobj["pathInfo"] ?? " ";
                        var trgAddr = jobj["trgAddr"] ?? "";
                        var resType = jobj["resType"] ?? " ";
                        var oprType = jobj["oprType"] ?? " ";

                        string path = pathInfo.ToString();
                        if (path == " ")
                            path = resType.ToString() + " : " + trgAddr.ToString();

                        tcmsg = string.Empty;
                        if (dev.type == "onem2m")
                            OneM2MTcResultReport(jobj["logId"].ToString(), jobj["resultCode"].ToString(), jobj["resultCodeName"].ToString(), resType.ToString(), trgAddr.ToString(), oprType.ToString());
                        else
                            LwM2MTcResultReport(path, jobj["logId"].ToString(), jobj["resultCode"].ToString(), jobj["resultCodeName"].ToString(), resType.ToString());

                        listBox1.Items.Add(logtime + "\t" + jobj["logId"].ToString() + "\t" + tcmsg + "\t" + jobj["resultCode"].ToString() + "\t   " + jobj["resultCodeName"].ToString() + " (" + path + ")");
                    }

                    if (listBox1.Items.Count != 0)
                        listBox1.SelectedIndex = 0;
                    else if (mode == "man")
                        MessageBox.Show("플랫폼 로그가 존재하지 않습니다.\nCTN을 확인하세요", textBox1.Text + " DEVICE 상태 정보");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            else if (mode == "man")
                MessageBox.Show("플랫폼 로그가 존재하지 않습니다.\nCTN을 확인하세요", textBox1.Text + " DEVICE 상태 정보");
        }

        private void OneM2MTcResultReport(string logId, string resultCode, string resultCodeName, string resType, string trgAddr, string oprType)
        {
            // oprType = 1:POST(Create), 2:GET(Read), 3:PUT(Update),4:DELETE,5:POST(Noti)
            switch (resType)
            {
                case "mefda":
                    tcmsg = "MEF Certification";
                    endoneM2MTC("tc020201", logId, resultCode, resultCodeName, string.Empty);
                    break;
                case "csr":
                    if (trgAddr == "cb-1")
                    {
                        if (oprType == "2")
                        {
                            tcmsg = "CSEBase Read";
                            endoneM2MTC("tc020401", logId, resultCode, resultCodeName, string.Empty);
                        }
                        else if (oprType == "1")
                        {
                            tcmsg = "remoteCSE Create";
                            endoneM2MTC("tc020501", logId, resultCode, resultCodeName, string.Empty);
                        }
                    }
                    else
                    {
                        if (oprType == "4")
                        {
                            tcmsg = "remoteCSE Delete";
                            endoneM2MTC("tc021204", logId, resultCode, resultCodeName, string.Empty);
                        }
                        else if (oprType == "3")
                        {
                            tcmsg = "remoteCSE Update";
                            endoneM2MTC("tc020505", logId, resultCode, resultCodeName, string.Empty);
                        }
                        else if (oprType == "2")
                        {
                            tcmsg = "remoteCSE Read";
                            endoneM2MTC("tc020301", logId, resultCode, resultCodeName, string.Empty);
                        }
                    }
                    break;
                case "cnt":
                    if (oprType == "4")
                    {
                        tcmsg = "Folder Delete";
                        endoneM2MTC("tc021203", logId, resultCode, resultCodeName, string.Empty);
                    }
                    else if (oprType == "1")
                    {
                        tcmsg = "Folder Create";
                        endoneM2MTC("tc020502", logId, resultCode, resultCodeName, string.Empty);
                    }
                    break;
                case "cin":
                    if (oprType == "2")
                    {
                        tcmsg = "Data Read(Auto)";
                        endoneM2MTC("tc020603", logId, resultCode, resultCodeName, string.Empty);
                    }
                    else if (oprType == "1")
                    {
                        tcmsg = "Data Send";
                        endoneM2MTC("tc020504", logId, resultCode, resultCodeName, string.Empty);
                    }
                    break;
                case "NOTI":
                    tcmsg = "Data Noti Event";
                    endoneM2MTC("tc020601", logId, resultCode, resultCodeName, string.Empty);
                    break;
                case "sub":
                    if (oprType == "4")
                    {
                        tcmsg = "Subscript Delete";
                        endoneM2MTC("tc021202", logId, resultCode, resultCodeName, string.Empty);
                    }
                    else if (oprType == "1")
                    {
                        tcmsg = "Subscript Create";
                        endoneM2MTC("tc020503", logId, resultCode, resultCodeName, string.Empty);
                    }
                    break;
                case "la":
                    tcmsg = "Data Read(Last)";
                    endoneM2MTC("tc020701", logId, resultCode, resultCodeName, string.Empty);
                    break;
                case "acp":
                    if (oprType == "4")
                    {
                        tcmsg = "ACP Delete";
                        endoneM2MTC("tc020904", logId, resultCode, resultCodeName, string.Empty);
                    }
                    else if (oprType == "3")
                    {
                        tcmsg = "ACP Update";
                        endoneM2MTC("tc020903", logId, resultCode, resultCodeName, string.Empty);
                    }
                    else if (oprType == "2")
                    {
                        tcmsg = "ACP Read";
                        endoneM2MTC("tc020902", logId, resultCode, resultCodeName, string.Empty);
                    }
                    else if (oprType == "1")
                    {
                        tcmsg = "ACP Create";
                        endoneM2MTC("tc020901", logId, resultCode, resultCodeName, string.Empty);
                    }
                    break;
                case "otafc":
                    getSvrDetailLog(logId, "tc021101", resultCode, resultCodeName);
                    break;
                case "otafd":
                    getSvrDetailLog(logId, "tc021103", resultCode, resultCodeName);
                    break;
                case "fwr":
                    if (trgAddr == "/mgo/fwr")
                        getSvrDetailLog(logId, "tc021002", resultCode, resultCodeName);
                    else
                        getSvrDetailLog(logId, "tc021004", resultCode, resultCodeName);
                    break;
                case "FWD":
                    string target = "/" + dev.entityId;
                    if (trgAddr.StartsWith(target))
                    {
                        if (oprType == "2")
                        {
                            tcmsg = "Status Check";
                            endoneM2MTC("tc021303", logId, resultCode, resultCodeName, string.Empty);
                        }
                        else if (oprType == "1")
                        {
                            tcmsg = "Device Control";
                            endoneM2MTC("tc021302", logId, resultCode, resultCodeName, string.Empty);
                        }
                        else if (oprType == "5")
                        {
                            tcmsg = "Data send(FWD)";
                            endoneM2MTC("tc021301", logId, resultCode, resultCodeName, string.Empty);
                        }
                    }
                    else
                    {
                        tcmsg = "Data send(FWD)";
                        endoneM2MTC("tc021301", logId, resultCode, resultCodeName, string.Empty);
                    }
                    break;
                case "MGMT":
                    if (trgAddr.EndsWith("fwr"))
                        tcmsg = "Remote FW Update";
                    else if (trgAddr.EndsWith("rbo"))
                    {
                        tcmsg = "Remote RESET";
                        endoneM2MTC("tc021401", logId, resultCode, resultCodeName, string.Empty);
                    }
                    break;
                case "nod":
                    tcmsg = "node Manage";
                    break;
                case "rbo":
                    tcmsg = "Remote Reset";
                    break;
                case "mgo":
                    tcmsg = "FW/Reset report";
                    break;
                default:
                    break;
            }
        }

        private void getSvrDetailLog(string tlogid, string kind, string tresultCode, string tresultCodeName)
        {
            label22.Text = "ID : " + tlogid + " 상세내역";

            // oneM2M log server 응답 확인 (resultcode)
            ReqHeader header = new ReqHeader();
            header.Url = logUrl + "/log?logId=" + tlogid;
            header.Method = "GET";
            header.ContentType = "application/json";
            header.X_M2M_RI = DateTime.Now.ToString("yyyyMMddHHmmss") + "LogDetail";
            header.X_M2M_Origin = svr.entityId;
            header.X_MEF_TK = svr.token;
            header.X_MEF_EKI = svr.enrmtKeyId;
            string retStr = GetHttpLog(header, string.Empty);

            listBox3.Items.Clear();
            //listBox3.Items.Add(DateTime.Now.ToString("hh:mm:ss.fff") + " : " + values[1]);

            if (retStr != string.Empty)
            {
                //LogWriteNoTime(retStr);

                try
                {
                    JArray jarr = JArray.Parse(retStr); //json 객체로

                    foreach (JObject jobj in jarr)
                    {
                        var methodName = jobj["methodName"] ?? " ";
                        var logType = jobj["logType"] ?? " ";
                        var svrType = jobj["svrType"] ?? " ";

                        string message = " \t ";

                        string logtype = logType.ToString();
                        if (logtype == "COAP")
                        {
                            var coapType = jobj["coapType"] ?? " ";
                            message = coapType.ToString() + " (";


                            var code = jobj["code"] ?? " ";
                            message += code.ToString();

                            if (kind == "tc0303")
                            {
                                string rcode = code.ToString();
                                if (rcode == "DELETE")
                                {
                                    tcmsg = "Deragistration";
                                    endLwM2MTC("tc0401", tlogid, tresultCode, tresultCodeName, string.Empty);
                                    kind = string.Empty;
                                }
                                else if (rcode == "POST")
                                {
                                    tcmsg = "Regist. Update";
                                    endLwM2MTC("tc0303", tlogid, tresultCode, tresultCodeName, string.Empty);
                                    kind = string.Empty;
                                }
                            }
                            else if (kind == "tc0502")
                            {
                                string rcode = code.ToString();
                                if (rcode == "PUT")
                                {
                                    tcmsg = "Device Control";
                                    endLwM2MTC("tc0502", tlogid, tresultCode, tresultCodeName, string.Empty);
                                    kind = string.Empty;
                                }
                                else if (rcode == "GET")
                                {
                                    tcmsg = "Status Check";
                                    endLwM2MTC("tc0503", tlogid, tresultCode, tresultCodeName, string.Empty);
                                    kind = string.Empty;
                                }
                            }

                            var uriPath = jobj["uriPath"] ?? "";
                            string path = uriPath.ToString();
                            if (path != "")
                            {
                                message += " " + path;

                                if (kind == "tc0602")
                                {
                                    if (path.StartsWith("firmware", System.StringComparison.CurrentCultureIgnoreCase))
                                    {
                                        tcmsg = "Module FW DL";
                                        endLwM2MTC("tc0602", tlogid, tresultCode, tresultCodeName, string.Empty);
                                        kind = string.Empty;
                                    }
                                }
                            }

                            message += ")\t ";

                            var coapPayload = jobj["coapPayload"] ?? "";
                            if (coapPayload.ToString() != "")
                            {
                                string coapmsg = coapPayload.ToString();
                                JArray jcoaparr = JArray.Parse(coapmsg); //json 객체로
                                //Console.WriteLine(jcoaparr);

                                foreach (JObject jcoapobj in jcoaparr)
                                {
                                    //Console.WriteLine(jcoapobj);

                                    var cppath = jcoapobj["path"] ?? " ";
                                    if (kind == "tc0602")
                                    {
                                        if (cppath.ToString() == "26241/0/1")
                                        {
                                            tcmsg = "Device FW DL";
                                            endLwM2MTC("tc0603", tlogid, tresultCode, tresultCodeName, string.Empty);
                                            kind = string.Empty;
                                        }
                                    }

                                    var type = jcoapobj["type"] ?? " ";
                                    if (type.ToString() == "OPAQUE")
                                    {
                                        var coapvalue = jcoapobj["value"] ?? " ";
                                        string hexdata = coapvalue.ToString();
                                        if (hexdata.Length > 0 && hexdata.Length % 2 == 0)
                                        {
                                            string isascii = "YES";
                                            char[] orgChars = hexdata.ToCharArray();
                                            //Console.WriteLine(hexdata);
                                            //Console.WriteLine(orgChars);

                                            for (int i = 0; i < orgChars.Length; i += 2)
                                            {
                                                // Get the integral value of the character.
                                                if (Convert.ToInt32(orgChars[i]) < 50)      // '2' = 50, 0x20=" "
                                                {
                                                    isascii = "NO";
                                                    break;
                                                }
                                            }

                                            if (isascii == "YES")
                                            {
                                                coapmsg += "\n\n(ASCII DATA : " + BcdToString(orgChars) + ")\n";
                                            }
                                        }

                                        if (kind == "tc0302")
                                        {
                                            if (code.ToString() == "NOT_FOUND")
                                            {
                                                var rdpath = jcoapobj["path"] ?? " ";

                                                tcmsg = "Registration";
                                                endLwM2MTC(kind, tlogid, "20000100", rdpath.ToString() + " " + code.ToString(), string.Empty);
                                            }
                                        }
                                    }
                                }

                                var uriQuery = jobj["uriQuery"] ?? " ";
                                if (uriQuery.ToString() == " ")
                                    message += coapmsg;
                                else
                                {
                                    if (path.StartsWith("rd/", System.StringComparison.CurrentCultureIgnoreCase))
                                    {
                                        message += coapmsg;
                                    }
                                    else
                                    {
                                        message += uriQuery.ToString() + "\n";

                                        if (uriPath.ToString() == "rd")
                                        {
                                            var others = jobj["others"] ?? "";
                                            if (others.ToString() == "")
                                            {
                                                message += "\n2048(EKI), 2049(TOKEN) 정보가 없습니다\n";
                                            }
                                        }
                                        message += "\n" + coapmsg;
                                    }
                                }
                            }
                        }
                        else if (logtype == "API_LOG")            //  서버 API LOG
                        {
                            logtype = "API";
                            var resultCode = jobj["resultCode"] ?? " ";
                            var trgAddr = jobj["trgAddr"] ?? " ";
                            var prtcType = jobj["prtcType"] ?? "";
                            //if (resultCode.ToString() != " ")
                            //    tBResultCode.Text = resultCode.ToString();
                            string protocol = prtcType.ToString();
                            if (protocol != "")
                                protocol = "(" + protocol + ")";

                            message = resultCode.ToString() + " " + protocol + "\t" + trgAddr.ToString();
                        }
                        else if (logtype == "HTTP")
                        {
                            var httpMethod = jobj["httpMethod"] ?? " ";
                            var uri = jobj["uri"] ?? " ";
                            var httpheader = jobj["header"] ?? " ";
                            var body = jobj["body"] ?? " ";
                            var responseBody = jobj["responseBody"] ?? " ";

                            string ntparam = string.Empty;
                            if (kind == "tc021101" || kind == "tc021103")
                            {
                                JObject obj = JObject.Parse(httpheader.ToString());
                                var cid = obj["X-OTA-CID"] ?? " ";
                                var nt = obj["X-OTA-NT"] ?? " ";
                                if (cid.ToString() != " " || nt.ToString() != " ")
                                    ntparam = "CID=" + cid.ToString() + "/NT=" + nt.ToString();

                                var pt = obj["X-OTA-PT"] ?? " ";
                                if (pt.ToString() == "LWM2M" && kind == "tc021101")
                                {
                                    tcmsg = "Module FW read";
                                    endoneM2MTC("tc021103", tlogid, tresultCode, tresultCodeName, ntparam);
                                }
                            }

                            if (kind == "tc021103")
                            {
                                string[] values = uri.ToString().Split('/');

                                if (values[5] == "D")
                                {
                                    tcmsg = "Device FW read";
                                    if (ntparam == string.Empty)
                                        endoneM2MTC("tc021003", tlogid, "20000100", tresultCodeName, "NO CELL info");
                                    else
                                        endoneM2MTC("tc021003", tlogid, tresultCode, tresultCodeName, ntparam);
                                }
                                else
                                {
                                    tcmsg = "Module FW read";
                                    if (ntparam == string.Empty)
                                        endoneM2MTC("tc021103", tlogid, "20000100", tresultCodeName, "NO CELL info");
                                    else
                                        endoneM2MTC("tc021103", tlogid, tresultCode, tresultCodeName, ntparam);
                                }
                            }

                            string bodymsg = ParsingReqBodyMsg(body.ToString(), kind, tlogid, tresultCode, tresultCodeName);
                            string resbodymsg = ParsingResBodyMsg(responseBody.ToString(), kind, tlogid, tresultCode, tresultCodeName, ntparam);

                            message = httpMethod.ToString() + " " + uri.ToString() + "\tREQUEST\n" + httpheader + "\n" + bodymsg + "\n\nRESPONSE\n" + responseBody + resbodymsg;

                        }
                        else if (logtype == "HTTP_CLIENT")
                        {
                            logtype = "CLIENT";
                            var responseCode = jobj["responseCode"] ?? " ";
                            string resp = responseCode.ToString();

                            var uri = jobj["uri"] ?? " ";
                            var reqheader = jobj["header"] ?? " ";
                            var responseHeader = jobj["responseHeader"] ?? " ";

                            if (responseHeader.ToString() != " ")
                            {
                                JObject obj = JObject.Parse(responseHeader.ToString());
                                var rsc = obj["X-M2M-RSC"] ?? " ";
                                resp += "/" + rsc.ToString();
                                //var resultcode = obj["X-LGU-RSC"] ?? " ";
                                //if (resultcode.ToString() != " ")
                                //    tBResultCode.Text = resultcode.ToString();
                            }

                            message = resp + " (" + uri.ToString() + ")\tREQUEST\n" + reqheader + "\n\nRESPONSE\n" + responseHeader;
                        }
                        else if (logtype == "RUNTIME_LOG")
                        {
                            logtype = "RUN";
                            var topicOrEntityId = jobj["topicOrEntityId"] ?? " ";
                            var requestEntity = jobj["requestEntity"] ?? " ";
                            var responseEntity = jobj["responseEntity"] ?? " ";

                            message = topicOrEntityId.ToString() + "\tREQUEST\n" + requestEntity + "\n\nRESPONSE\n" + responseEntity;
                        }

                        string svrtype = svrType.ToString();
                        if (svrtype == "CSE-NB01")
                            svrtype = "CSNB01";

                        string method = methodName.ToString();
                        if (method == "httpClientRuntimeLog")
                            method = "httpClientRuntime";

                        if (method.Length < 8)
                            method += "         ";

                        listBox3.Items.Add(svrtype + "\t" + logtype + "\t" + method + "\t" + message);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        private string ParsingReqBodyMsg(string body, string tckind, string tlogid, string tresultCode, string tresultCodeName)
        {
            string decode = " ";
            string bodymsg = body.Replace("\t", "");
            Console.WriteLine(bodymsg);

            if (bodymsg.StartsWith("{", System.StringComparison.CurrentCultureIgnoreCase))
            {
                try
                {
                    JObject obj = JObject.Parse(bodymsg);
                    string format = string.Empty;
                    string value = string.Empty;

                    if (obj["cnf"] != null)
                    {
                        format = obj["cnf"].ToString(); // data format
                        value = obj["con"].ToString(); // data value
                    }

                    if (value != string.Empty)
                    {
                        if (format == "application/octet-stream")
                        {
                            string hexOutput = string.Empty;
                            string ascii = "YES";
                            byte[] orgBytes = Convert.FromBase64String(value);
                            char[] orgChars = System.Text.Encoding.ASCII.GetString(orgBytes).ToCharArray();
                            foreach (char _eachChar in orgChars)
                            {
                                // Get the integral value of the character.
                                int intvalue = Convert.ToInt32(_eachChar);
                                // Convert the decimal value to a hexadecimal value in string form.
                                if (intvalue < 16)
                                {
                                    hexOutput += "0";
                                    ascii = "NO";
                                }
                                else if (intvalue < 32)
                                {
                                    ascii = "NO";
                                }
                                hexOutput += String.Format("{0:X}", intvalue);
                            }
                            //logPrintInTextBox(hexOutput, "");

                            if (hexOutput != string.Empty)
                            {
                                decode = "\n\n( HEX DATA : " + hexOutput;

                                if (ascii == "YES")
                                {
                                    string asciidata = Encoding.UTF8.GetString(orgBytes);
                                    decode += "\nASCII DATA : " + asciidata;
                                }
                                decode += ")";
                            }
                        }
                        else
                        {
                            decode = "\n\n( DATA : " + value + " )";
                        }
                    }
                    //LogWrite("decode = " + decode);

                    if (tckind == "tc021002" && obj["hwty"] != null)
                    {
                        if (obj["hwty"].ToString() == "D")
                        {
                            tcmsg = "Remote Device FW";
                            endoneM2MTC("tc021002", tlogid, tresultCode, tresultCodeName, string.Empty);
                        }
                        else
                        {
                            tcmsg = "Remote Module FW";
                            endoneM2MTC("tc021102", tlogid, tresultCode, tresultCodeName, string.Empty);
                        }
                    }

                    if (tckind == "tc0603" && obj["hwty"] != null)
                    {
                        if (obj["hwty"].ToString() == "D")
                        {
                            tcmsg = "Remote Device FW";
                            endoneM2MTC("tc0603", tlogid, tresultCode, tresultCodeName, string.Empty);
                        }
                        else
                        {
                            tcmsg = "Remote Module FW";
                            endoneM2MTC("tc0602", tlogid, tresultCode, tresultCodeName, string.Empty);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            else if (bodymsg.StartsWith("<?xml", System.StringComparison.CurrentCultureIgnoreCase))
            {
                string format = string.Empty;
                string value = string.Empty;

                //bodymsg = bodymsg.Replace("\\t", "");
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(bodymsg);
                //logPrintTC(xDoc.OuterXml.ToString());

                XmlNodeList xnList = xDoc.SelectNodes("/*"); //접근할 노드
                foreach (XmlNode xn in xnList)
                {
                    try
                    {
                        if (xn["cnf"] != null)
                            format = xn["cnf"].InnerText; // data format
                        if (xn["con"] != null)
                            value = xn["con"].InnerText; // data value

                        if (xn["nev"] != null)
                            if (xn["nev"]["rep"] != null)
                                if (xn["nev"]["rep"]["m2m:cin"] != null)
                                {
                                    if (xn["nev"]["rep"]["m2m:cin"]["cnf"] != null)
                                        format = xn["nev"]["rep"]["m2m:cin"]["cnf"].InnerText; // data format
                                    if (xn["nev"]["rep"]["m2m:cin"]["con"] != null)
                                        value = xn["nev"]["rep"]["m2m:cin"]["con"].InnerText; // data value
                                }

                        if (tckind == "tc021002" && xn["hwty"] != null)
                        {
                            if (xn["hwty"].InnerText == "D")
                            {
                                tcmsg = "Remote Device FW";
                                endoneM2MTC("tc021002", tlogid, tresultCode, tresultCodeName, string.Empty);
                            }
                            else
                            {
                                tcmsg = "Remote Module FW";
                                endoneM2MTC("tc021102", tlogid, tresultCode, tresultCodeName, string.Empty);
                            }
                        }

                        if (tckind == "tc0603" && xn["hwty"] != null)
                        {
                            if (xn["hwty"].InnerText == "D")
                            {
                                tcmsg = "Remote Device FW";
                                endoneM2MTC("tc0603", tlogid, tresultCode, tresultCodeName, string.Empty);
                            }
                            else
                            {
                                tcmsg = "Remote Module FW";
                                endoneM2MTC("tc0602", tlogid, tresultCode, tresultCodeName, string.Empty);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
                Console.WriteLine("value = " + value);
                Console.WriteLine("format = " + format);

                if (format == "application/octet-stream")
                {
                    string hexOutput = string.Empty;
                    string ascii = "YES";
                    byte[] orgBytes = Convert.FromBase64String(value);
                    char[] orgChars = System.Text.Encoding.ASCII.GetString(orgBytes).ToCharArray();
                    foreach (char _eachChar in orgChars)
                    {
                        // Get the integral value of the character.
                        int intvalue = Convert.ToInt32(_eachChar);
                        // Convert the decimal value to a hexadecimal value in string form.
                        if (intvalue < 16)
                        {
                            hexOutput += "0";
                            ascii = "NO";
                        }
                        else if (intvalue < 32)
                        {
                            ascii = "NO";
                        }
                        hexOutput += String.Format("{0:X}", intvalue);
                    }
                    //logPrintInTextBox(hexOutput, "");

                    if (hexOutput != string.Empty)
                    {
                        decode = "\n\n( HEX DATA : " + hexOutput;

                        if (ascii == "YES")
                        {
                            string asciidata = Encoding.UTF8.GetString(orgBytes);
                            decode += "\nASCII DATA : " + asciidata;
                        }
                        decode += ")";
                    }
                }
                else if (value != string.Empty)
                {
                    decode = "\n\n( DATA : " + value + " )";
                }
                //LogWrite("decode = " + decode);
            }
            else if (bodymsg.StartsWith("<m2m", System.StringComparison.CurrentCultureIgnoreCase))
            {
                string format = string.Empty;
                string value = string.Empty;

                //bodymsg = bodymsg.Replace("\\t", "");
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(bodymsg);
                //logPrintTC(xDoc.OuterXml.ToString());

                XmlNodeList xnList = xDoc.SelectNodes("/*"); //접근할 노드
                foreach (XmlNode xn in xnList)
                {
                    try
                    {
                        if (xn["cnf"] != null)
                            format = xn["cnf"].InnerText; // data format
                        if (xn["con"] != null)
                            value = xn["con"].InnerText; // data value
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
                //LogWrite("value = " + value);
                //LogWrite("format = " + format);

                if (format == "application/octet-stream")
                {
                    string hexOutput = string.Empty;
                    string ascii = "YES";
                    byte[] orgBytes = Convert.FromBase64String(value);
                    char[] orgChars = System.Text.Encoding.ASCII.GetString(orgBytes).ToCharArray();
                    foreach (char _eachChar in orgChars)
                    {
                        // Get the integral value of the character.
                        int intvalue = Convert.ToInt32(_eachChar);
                        // Convert the decimal value to a hexadecimal value in string form.
                        if (intvalue < 16)
                        {
                            hexOutput += "0";
                            ascii = "NO";
                        }
                        else if (intvalue < 32)
                        {
                            ascii = "NO";
                        }
                        hexOutput += String.Format("{0:X}", intvalue);
                    }
                    //logPrintInTextBox(hexOutput, "");

                    if (hexOutput != string.Empty)
                    {
                        decode = "\n\n( HEX DATA : " + hexOutput;

                        if (ascii == "YES")
                        {
                            string asciidata = Encoding.UTF8.GetString(orgBytes);
                            decode += "\nASCII DATA : " + asciidata;
                        }
                        decode += ")";
                    }
                }
                else if (value != string.Empty)
                {
                    decode = "\n\n( DATA : " + value + " )";
                }
                //LogWrite("decode = " + decode);
            }
            return (bodymsg + decode);
        }

        private string ParsingResBodyMsg(string body, string tckind, string tlogid, string tresultCode, string tresultCodeName, string ntparam)
        {
            string decode = " ";
            string bodymsg = body.Replace("\t", "");
            Console.WriteLine(bodymsg);

            if (bodymsg.StartsWith("{", System.StringComparison.CurrentCultureIgnoreCase))
            {
                try
                {
                    JObject obj = JObject.Parse(bodymsg);
                    string format = string.Empty;
                    string value = string.Empty;

                    if (obj["cnf"] != null)
                    {
                        format = obj["cnf"].ToString(); // data format
                        value = obj["con"].ToString(); // data value
                    }

                    if (value != string.Empty)
                    {
                        if (format == "application/octet-stream")
                        {
                            string hexOutput = string.Empty;
                            string ascii = "YES";
                            byte[] orgBytes = Convert.FromBase64String(value);
                            char[] orgChars = System.Text.Encoding.ASCII.GetString(orgBytes).ToCharArray();
                            foreach (char _eachChar in orgChars)
                            {
                                // Get the integral value of the character.
                                int intvalue = Convert.ToInt32(_eachChar);
                                // Convert the decimal value to a hexadecimal value in string form.
                                if (intvalue < 16)
                                {
                                    hexOutput += "0";
                                    ascii = "NO";
                                }
                                else if (intvalue < 32)
                                {
                                    ascii = "NO";
                                }
                                hexOutput += String.Format("{0:X}", intvalue);
                            }
                            //logPrintInTextBox(hexOutput, "");

                            if (hexOutput != string.Empty)
                            {
                                decode = "\n\n( HEX DATA : " + hexOutput;

                                if (ascii == "YES")
                                {
                                    string asciidata = Encoding.UTF8.GetString(orgBytes);
                                    decode += "\nASCII DATA : " + asciidata;
                                }
                                decode += ")";
                            }
                        }
                        else
                        {
                            decode = "\n\n( DATA : " + value + " )";
                        }
                    }
                    //LogWrite("decode = " + decode);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            else if (bodymsg.StartsWith("<?xml", System.StringComparison.CurrentCultureIgnoreCase))
            {
                string format = string.Empty;
                string value = string.Empty;

                //bodymsg = bodymsg.Replace("\\t", "");
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(bodymsg);
                //logPrintTC(xDoc.OuterXml.ToString());

                XmlNodeList xnList = xDoc.SelectNodes("/*"); //접근할 노드
                foreach (XmlNode xn in xnList)
                {
                    try
                    {
                        if (xn["cnf"] != null)
                            format = xn["cnf"].InnerText; // data format
                        if (xn["con"] != null)
                            value = xn["con"].InnerText; // data value

                        if (xn["nev"] != null)
                            if (xn["nev"]["rep"] != null)
                                if (xn["nev"]["rep"]["m2m:cin"] != null)
                                {
                                    if (xn["nev"]["rep"]["m2m:cin"]["cnf"] != null)
                                        format = xn["nev"]["rep"]["m2m:cin"]["cnf"].InnerText; // data format
                                    if (xn["nev"]["rep"]["m2m:cin"]["con"] != null)
                                        value = xn["nev"]["rep"]["m2m:cin"]["con"].InnerText; // data value
                                }
                        if (tckind == "tc021004" && xn["hwty"] != null)
                        {
                            if (xn["hwty"].InnerText == "D")
                            {
                                tcmsg = "Device FW Report";
                                endoneM2MTC("tc021004", tlogid, tresultCode, tresultCodeName, string.Empty);
                            }
                            else
                            {
                                tcmsg = "Module FW Report";
                                endoneM2MTC("tc021104", tlogid, tresultCode, tresultCodeName, string.Empty);
                            }
                        }

                        if (tckind == "tc021101")
                        {
                            if (xn["url"] != null)
                            {
                                string url = xn["url"].InnerText;
                                string[] values = url.Split('/');    // 수신한 데이터를 한 문장씩 나누어 array에 저장

                                if (values[3] == "D")
                                {
                                    tcmsg = "Device FW Noti";
                                    if (ntparam == string.Empty)
                                        endoneM2MTC("tc021001", tlogid, "20000100", tresultCodeName, "NO CELL info");
                                    else
                                        endoneM2MTC("tc021001", tlogid, tresultCode, tresultCodeName, ntparam);
                                }
                                else
                                {
                                    tcmsg = "Module FW Noti";
                                    if (ntparam == string.Empty)
                                        endoneM2MTC("tc021101", tlogid, "20000100", tresultCodeName, "NO CELL info");
                                    else
                                        endoneM2MTC("tc021101", tlogid, tresultCode, tresultCodeName, ntparam);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }

                Console.WriteLine("value = " + value);
                Console.WriteLine("format = " + format);

                if (format == "application/octet-stream")
                {
                    string hexOutput = string.Empty;
                    string ascii = "YES";
                    byte[] orgBytes = Convert.FromBase64String(value);
                    char[] orgChars = System.Text.Encoding.ASCII.GetString(orgBytes).ToCharArray();
                    foreach (char _eachChar in orgChars)
                    {
                        // Get the integral value of the character.
                        int intvalue = Convert.ToInt32(_eachChar);
                        // Convert the decimal value to a hexadecimal value in string form.
                        if (intvalue < 16)
                        {
                            hexOutput += "0";
                            ascii = "NO";
                        }
                        else if (intvalue < 32)
                        {
                            ascii = "NO";
                        }
                        hexOutput += String.Format("{0:X}", intvalue);
                    }
                    //logPrintInTextBox(hexOutput, "");

                    if (hexOutput != string.Empty)
                    {
                        decode = "\n\n( HEX DATA : " + hexOutput;

                        if (ascii == "YES")
                        {
                            string asciidata = Encoding.UTF8.GetString(orgBytes);
                            decode += "\nASCII DATA : " + asciidata;
                        }
                        decode += ")";
                    }
                }
                else if (value != string.Empty)
                {
                    decode = "\n\n( DATA : " + value + " )";
                }
                //LogWrite("decode = " + decode);
            }
            else if (bodymsg.StartsWith("<m2m", System.StringComparison.CurrentCultureIgnoreCase))
            {
                string format = string.Empty;
                string value = string.Empty;

                //bodymsg = bodymsg.Replace("\\t", "");
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(bodymsg);
                //logPrintTC(xDoc.OuterXml.ToString());

                XmlNodeList xnList = xDoc.SelectNodes("/*"); //접근할 노드
                foreach (XmlNode xn in xnList)
                {
                    try
                    {
                        if (xn["cnf"] != null)
                            format = xn["cnf"].InnerText; // data format
                        if (xn["con"] != null)
                            value = xn["con"].InnerText; // data value
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
                //LogWrite("value = " + value);
                //LogWrite("format = " + format);

                if (format == "application/octet-stream")
                {
                    string hexOutput = string.Empty;
                    string ascii = "YES";
                    byte[] orgBytes = Convert.FromBase64String(value);
                    char[] orgChars = System.Text.Encoding.ASCII.GetString(orgBytes).ToCharArray();
                    foreach (char _eachChar in orgChars)
                    {
                        // Get the integral value of the character.
                        int intvalue = Convert.ToInt32(_eachChar);
                        // Convert the decimal value to a hexadecimal value in string form.
                        if (intvalue < 16)
                        {
                            hexOutput += "0";
                            ascii = "NO";
                        }
                        else if (intvalue < 32)
                        {
                            ascii = "NO";
                        }
                        hexOutput += String.Format("{0:X}", intvalue);
                    }
                    //logPrintInTextBox(hexOutput, "");

                    if (hexOutput != string.Empty)
                    {
                        decode = "\n\n( HEX DATA : " + hexOutput;

                        if (ascii == "YES")
                        {
                            string asciidata = Encoding.UTF8.GetString(orgBytes);
                            decode += "\nASCII DATA : " + asciidata;
                        }
                        decode += ")";
                    }
                }
                else if (value != string.Empty)
                {
                    decode = "\n\n( DATA : " + value + " )";
                }
                //LogWrite("decode = " + decode);
            }
            return (bodymsg + decode);
        }

        private void LwM2MTcResultReport(string path, string logId, string resultCode, string resultCodeName, string resType)
        {
            switch (resType)
            {
                case "lbkbt":
                    tcmsg = "Bootstrap   ";
                    endLwM2MTC("tc0203", logId, resultCode, resultCodeName, string.Empty);
                    break;
                case "lbkre":
                    if (resultCode == "20000000")
                    {
                        LogWrite("registration device parameter checking");
                        getSvrDetailLog(logId, "tc0302", resultCode, resultCodeName);
                        if (tcmsg == string.Empty)
                        {
                            tcmsg = "Registration";
                            endLwM2MTC("tc0302", logId, resultCode, resultCodeName, string.Empty);
                        }
                    }
                    else
                    {
                        tcmsg = "Registration";
                        endLwM2MTC("tc0302", logId, resultCode, resultCodeName, string.Empty);
                    }
                    break;
                case "lbkru":
                    tcmsg = "Regist. Update";
                    endLwM2MTC("tc0303", logId, resultCode, resultCodeName, string.Empty);
                    break;
                case "lbkrd":
                    tcmsg = "Deragistration";
                    endLwM2MTC("tc0401", logId, resultCode, resultCodeName, string.Empty);
                    break;
                case "lbknt":
                    if (path == "10250/0/0")
                    {
                        tcmsg = "Data Send";
                        endLwM2MTC("tc0501", logId, resultCode, resultCodeName, string.Empty);
                    }
                    else if (path == "26241/0/0")
                    {
                        tcmsg = "Device FW Report";
                        endLwM2MTC("tc0601", logId, resultCode, resultCodeName, string.Empty);
                    }
                    else if (path == "5/0/3")
                        tcmsg = "Module FW Report";
                    break;
                case "lbkdc":
                    if (path == "mgo/fwr")
                    {
                        getSvrDetailLog(logId, "tc0603", resultCode, resultCodeName);
                        if (tcmsg == string.Empty)
                        {
                            tcmsg = "Remote Device FW";
                            endLwM2MTC("tc0603", logId, resultCode, resultCodeName, string.Empty);
                        }
                    }
                    else
                    {
                        LogWrite("device control checking");
                        getSvrDetailLog(logId, "tc0502", resultCode, resultCodeName);
                        if (tcmsg == string.Empty)
                        {
                            tcmsg = "Device Control";
                            endLwM2MTC("tc0502", logId, resultCode, resultCodeName, string.Empty);
                        }
                    }
                    break;
                case "lbkfd":
                    tcmsg = "Module FW DL";
                    endLwM2MTC("tc0602", logId, resultCode, resultCodeName, string.Empty);
                    break;
                case "lbkfs":
                    tcmsg = "Module FW Update";
                    endLwM2MTC("tc0602", logId, resultCode, resultCodeName, string.Empty);
                    break;
                case "lbkfu":
                    tcmsg = "Device FW Update";
                    endLwM2MTC("tc0603", logId, resultCode, resultCodeName, string.Empty);
                    break;
                default:
                    if (path.StartsWith("firmware"))
                    {
                        tcmsg = "Module FW DL";
                        endLwM2MTC("tc0602", logId, resultCode, resultCodeName, string.Empty);
                    }
                    break;
            }
        }

        private void startLwM2MTC(string tcindex)
        {
            tc.state = tcindex;
            logPrintTC(lwm2mtclist[tcindex] + " [시작]");
            lwm2mtc index = (lwm2mtc)Enum.Parse(typeof(lwm2mtc), tcindex);
            tc.lwm2m[(int)index, 0] = "TESTING";             // 시험 결과 초기 값(FAIL) 설정, 테스트 후 결과 수정
            tc.lwm2m[(int)index, 1] = string.Empty;
            tc.lwm2m[(int)index, 2] = string.Empty;
            tc.lwm2m[(int)index, 3] = string.Empty;
            tc.lwm2m[(int)index, 4] = string.Empty;
        }

        private void endLwM2MTC(string tcindex, string logId, string resultCode, string resultCodeName, string remark)
        {
            lwm2mtc index = (lwm2mtc)Enum.Parse(typeof(lwm2mtc), tcindex);

            if (resultCode == string.Empty || resultCode == "20000000")
            {
                if (logId == string.Empty)
                    logPrintTC(lwm2mtclist[tcindex] + " [성공]");
                else
                    logPrintTC(lwm2mtclist[tcindex] + " [성공] - " + logId);

                string result = tc.lwm2m[(int)index, 0];
                if (result != "FAIL")
                {
                    tc.lwm2m[(int)index, 0] = "PASS";             // 시험 결과 저장
                    tc.lwm2m[(int)index, 1] = resultCode;
                    tc.lwm2m[(int)index, 2] = logId;
                    tc.lwm2m[(int)index, 3] = resultCodeName;
                    tc.lwm2m[(int)index, 4] = remark;
                }
            }
            else
            {
                if (logId == string.Empty)
                    logPrintTC(lwm2mtclist[tcindex] + " [오류]");
                else
                    logPrintTC(lwm2mtclist[tcindex] + " [오류] - " + logId);
                tc.lwm2m[(int)index, 0] = "FAIL";             // 시험 결과 저장
                tc.lwm2m[(int)index, 1] = resultCode;
                tc.lwm2m[(int)index, 2] = logId;
                tc.lwm2m[(int)index, 3] = resultCodeName;
                tc.lwm2m[(int)index, 4] = "";
            }
            tc.state = string.Empty;
        }

        private void startoneM2MTC(string tcindex)
        {
            tc.state = tcindex;
            logPrintTC(onem2mtclist[tcindex] + " [시작]");
            onem2mtc index = (onem2mtc)Enum.Parse(typeof(onem2mtc), tcindex);
            tc.onem2m[(int)index, 0] = "TESTING";             // 시험 결과 초기 값(FAIL) 설정, 테스트 후 결과 수정
            tc.onem2m[(int)index, 1] = string.Empty;
            tc.onem2m[(int)index, 2] = string.Empty;
            tc.onem2m[(int)index, 3] = string.Empty;
            tc.onem2m[(int)index, 4] = string.Empty;
        }

        private void endoneM2MTC(string tcindex, string logId, string resultCode, string resultCodeName, string remark)
        {
            onem2mtc index = (onem2mtc)Enum.Parse(typeof(onem2mtc), tcindex);

            if (resultCode == string.Empty || resultCode == "20000000")
            {
                if (logId == string.Empty)
                    logPrintTC(onem2mtclist[tcindex] + " [성공]");
                else
                    logPrintTC(onem2mtclist[tcindex] + " [성공] - " + logId);
                string result = tc.onem2m[(int)index, 0];

                if (result != "FAIL")
                {
                    tc.onem2m[(int)index, 0] = "PASS";             // 시험 결과 저장
                    tc.onem2m[(int)index, 1] = resultCode;
                    tc.onem2m[(int)index, 2] = logId;
                    tc.onem2m[(int)index, 3] = resultCodeName;
                    tc.onem2m[(int)index, 4] = remark;
                }
            }
            else
            {
                if (logId == string.Empty)
                    logPrintTC(onem2mtclist[tcindex] + " [오류]");
                else
                    logPrintTC(onem2mtclist[tcindex] + " [오류] - " + logId);
                tc.onem2m[(int)index, 0] = "FAIL";             // 시험 결과 저장
                tc.onem2m[(int)index, 1] = resultCode;
                tc.onem2m[(int)index, 2] = logId;
                tc.onem2m[(int)index, 3] = resultCodeName;
                tc.onem2m[(int)index, 4] = "";
            }
            tc.state = string.Empty;
        }

        private void LogWrite(string data)
        {
            BeginInvoke(new Action(() =>
            {
                tbLog.AppendText(Environment.NewLine);
                tbLog.AppendText(DateTime.Now.ToString("hh:mm:ss.fff") + " (" + actionState + ") : " + data);
                tbLog.SelectionStart = tbLog.TextLength;
                tbLog.ScrollToCaret();
            }));
        }

        private void LogWriteNoTime(string data)
        {
            BeginInvoke(new Action(() =>
            {
                tbLog.AppendText(Environment.NewLine);
                data = data.Replace("><", ">" + Environment.NewLine + "<");         // xml tag 위치에 줄바꿈 삽입
                tbLog.AppendText(" " + data);
                tbLog.SelectionStart = tbLog.TextLength;
                tbLog.ScrollToCaret();
            }));
        }

        // 시험절차서 시험 결과를 tbTCResult에 표시.
        public void logPrintTC(string message)
        {
            BeginInvoke(new Action(() =>
            {
                tbTCResult.AppendText(Environment.NewLine);
                tbTCResult.AppendText(DateTime.Now.ToString("hh:mm:ss.fff") + " (" + actionState + ") : " + message);
                tbTCResult.SelectionStart = tbTCResult.TextLength;
                tbTCResult.ScrollToCaret();
            }));
        }

        public string GetHttpLog(ReqHeader header, string data)
        {
            string resResult = string.Empty;

            try
            {
                wReq = (HttpWebRequest)WebRequest.Create(header.Url);
                wReq.Method = header.Method;
                if (header.ContentType != string.Empty)
                    wReq.ContentType = header.ContentType;
                /*
                if (header.X_M2M_RI != string.Empty)
                    wReq.Headers.Add("X-M2M-RI", header.X_M2M_RI);
                if (header.X_M2M_Origin != string.Empty)
                    wReq.Headers.Add("X-M2M-Origin", header.X_M2M_Origin);
                if (header.X_MEF_TK != string.Empty)
                    wReq.Headers.Add("X-MEF-TK", header.X_MEF_TK);
                if (header.X_MEF_EKI != string.Empty)
                    wReq.Headers.Add("X-MEF-EKI", header.X_MEF_EKI);
                */

                //LogWrite(wReq.Method + " " + wReq.RequestUri + " HTTP/1.1");
                Console.WriteLine(wReq.Method + " " + wReq.RequestUri + " HTTP/1.1");
                Console.WriteLine("");
                for (int i = 0; i < wReq.Headers.Count; ++i)
                    Console.WriteLine(wReq.Headers.Keys[i] + ": " + wReq.Headers[i]);
                Console.WriteLine("");
                Console.WriteLine(data);
                Console.WriteLine("");

                wReq.Timeout = 30000;          // 서버 응답을 30초동안 기다림
                using (wRes = (HttpWebResponse)wReq.GetResponse())
                {
                    Console.WriteLine("HTTP/1.1 " + (int)wRes.StatusCode + " " + wRes.StatusCode.ToString());
                    Console.WriteLine("");
                    for (int i = 0; i < wRes.Headers.Count; ++i)
                        Console.WriteLine("[" + wRes.Headers.Keys[i] + "] " + wRes.Headers[i]);
                    Console.WriteLine("");

                    Stream respPostStream = wRes.GetResponseStream();
                    StreamReader readerPost = new StreamReader(respPostStream, Encoding.GetEncoding("UTF-8"), true);
                    resResult = readerPost.ReadToEnd();
                    Console.WriteLine(resResult);
                    Console.WriteLine("");
                }
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError && ex.Response != null)
                {
                    var resp = (HttpWebResponse)ex.Response;
                    Console.WriteLine("HTTP/1.1 " + (int)resp.StatusCode + " " + resp.StatusCode.ToString());
                    Console.WriteLine("");
                    for (int i = 0; i < resp.Headers.Count; ++i)
                        Console.WriteLine(" " + resp.Headers.Keys[i] + ": " + resp.Headers[i]);
                    Console.WriteLine("");

                    Stream respPostStream = resp.GetResponseStream();
                    StreamReader readerPost = new StreamReader(respPostStream, Encoding.GetEncoding("UTF-8"), true);
                    string resError = readerPost.ReadToEnd();
                    Console.WriteLine(resError);
                    Console.WriteLine("");
                    Console.WriteLine("[" + (int)resp.StatusCode + "] " + resp.StatusCode.ToString());
                }
                else
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            return resResult;
        }

    }

    public class TCResult
    {
        public string state { get; set; }            // 테스트 중인 항목
        public string[,] lwm2m { get; set; }           // LwM2M 항목별 시험결과
        public string[,] onem2m { get; set; }           // oneM2M 항목별 시험결과
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

    public class ServiceServer
    {
        public string svcSvrCd { get; set; }        // 서비스 서버의 시퀀스
        public string svcCd { get; set; }           // 서비스 서버의 서비스코드
        public string svcSvrNum { get; set; }       // 서비스 서버의 Num ber

        public string enrmtKey { get; set; }        // oneM2M 인증 KeyID를 생성하기 위한 Key
        public string entityId { get; set; }        // oneM2M에서 사용하는 서버 ID
        public string token { get; set; }           // 인증구간 통신을 위해 발급하는 Token

        public string enrmtKeyId { get; set; }      // MEF 인증 결과를 통해 생성하는 ID

        public string remoteCSEName { get; set; }   // RemoteCSE 리소스 이름
    }

    public class ReqHeader
    {
        public string Url { get; set; }
        public string Method { get; set; }
        public string Accept { get; set; }
        public string ContentType { get; set; }
        public string X_M2M_RI { get; set; } // Request ID(임의 값)
        public string X_M2M_Origin { get; set; } // 서비스서버의 Entity ID
        public string X_MEF_TK { get; set; } // Password : MEF 인증으로 받은 Token 값
        public string X_MEF_EKI { get; set; } // Username(EKI) : MEF 인증으로 받은 Enrollment Key 로 생성한 Enrollment Key ID
        public string X_M2M_NM { get; set; } // 리소스 이름
    }

}
