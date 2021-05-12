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
using System.Threading;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private Thread rTh;

        private enum states
        {
            closed,
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
            setfotaserverinfo,
            getserverinfo,
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
            sendonemsgstrchk,
            sendonemsgsvr,
            responemsgsvr,
            sendonedevstr,
            sendonedevdb,
            sendonedevdb2,

            getonem2mmode,
            setonem2mmode,
            setmefauthnt,
            setmefauth,
            fotamefauthnt,
            mfotamefauth,
            getCSEbase,
            getremoteCSE,
            setremoteCSE,
            updateremoteCSE,
            delremoteCSE,
            setcontainer,
            settxcontainer,
            delcontainer,
            delcontainer2,
            setsubscript,
            delsubscript,
            getonem2mdata,
            getACP,
            setACP,
            updateACP,
            delACP,
            setrcvauto,
            setrcvmanu,
            resetreceived,
            resetboot,
            resetmodechk,
            resetmodechked,
            resetmodeset,
            resetmodeseted,
            resetmefauth,
            resetreport,

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
            modemFWUPreport,
            modemFWUPfinishLTE,
            modemFWUPstart,
            modemFWUPfinish,
            modemFWUPboot,
            modemFWUPmodechk,
            modemFWUPmodechked,
            modemFWUPmodeset,

            getdeviceSvrVer,
            setdeviceSvrVer,
            deviceFWUPfinish,
            deviceFWUPstart,
            deviceFWDownload,
            deviceFWDownloading,
            deviceFWDLfinsh,

            deviceFWList,
            deviceFWOpen,
            deviceFWRead,
            deviceFWClose,

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

            lwm2mtc02011,            //"2.1 LWM2M 단말 초기 설정 동작 확인 시험");
            lwm2mtc02012,
            lwm2mtc02021,           //"2.2 Bootstrap 절차 및 AT command 확인 시험");
            lwm2mtc02022,
            lwm2mtc02023,
            lwm2mtc02024,
            lwm2mtc02025,
            lwm2mtc02026,
            lwm2mtc02027,
            lwm2mtc02028,
            lwm2mtc02029,
            lwm2mtc0203,            //"2.3 Bootstrap 상세 동작 확인 시험");

            lwm2mtc03011,           //"3.1 Register 절차 및 AT command 확인 시험");
            lwm2mtc03012,
            lwm2mtc03013,
            lwm2mtc0302,            //"3.2 Register 상세 동작 확인 시험");
            lwm2mtc0303,            //"3.3 Register Update 확인 시험");

            lwm2mtc0401,            //"4.1 De-Register 절차 및 AT command 확인 시험");

            lwm2mtc0501,            //"5.1 Data 송신 (Data Notification)");
            lwm2mtc0502,            //"5.2 Data 수신 (Device Control)");
            lwm2mtc0503,            //"5.3 Device Staus Check");

            lwm2mtc0601,            //"6.1 펌웨어 체크 동작 확인");
            lwm2mtc0602,            //"6.2 모듈 펌웨어 업그레이드 시험");
            lwm2mtc06031,           //"6.3 단말 펌웨어 업그레이드 시험");
            lwm2mtc06032,
            lwm2mtc06033,
            lwm2mtc06034,

            onem2mtc0201011,        // MEF server 설정
            onem2mtc0201012,        // BRK server 설정
            onem2mtc0201013,        // FOTA server 설정
            onem2mtc0201014,        // server 설정 값 확인
            onem2mtc0201021,        // 플랫폼 Agent 동작 확인
            onem2mtc0201022,        // 플랫폼 Agent  동작 설정
            onem2mtc0201023,        // 플랫폼 Agent 설정 결과 확인
            onem2mtc0201024,        // 플랫폼 Agent 설정 완료

            onem2mtc0202011,         // MEF 인증 요청
            onem2mtc0202012,         // MEF 인증 요청

            onem2mtc020301,         // remoteCSE 조회 결과에 따라 remoteCSE 신규생성/업데이트 분기 

            onem2mtc020401,         // CSEBase  조회

            onem2mtc0205011,        // remoteCSE 조회-업데이트
            onem2mtc0205012,        // remoteCSE 신규 생성
            onem2mtc0205021,        // 수신 폴더 생성
            onem2mtc0205022,        // 송신 폴더 생성 - 구독 설정 시험 진행
            onem2mtc0205031,        // 구독 1회 신청 - 성공시 데이터 전송/오류시 구독 삭제 요청
            onem2mtc0205032,        // 구독 재 생성 - 데이터 전송
            onem2mtc0205041,         // 서버 동작시 송신 폴더에 데이터 생성
            onem2mtc0205042,
            onem2mtc0205043,         // 단말 단독 실행시 수신 폴더에 데이터 생성
            onem2mtc020505,        // remote 업데이트 - 데이터 송신

            onem2mtc0206011,         // data noti 이벤트 (서버에서 수신)
            onem2mtc0206012,         // data noti 이벤트 (단말 self)
            onem2mtc020602,         // data 수신 모드 설정 (자동)
            onem2mtc0206031,         // 자동수신 (서버에서 수신)
            onem2mtc0206032,         // 자동수신 (단말 self)
            onem2mtc0206041,         // 구독신청 - data 수신
            onem2mtc0206042,         // 자동수신 - 수동설정 - data 수신

            onem2mtc0207011,        // 서버에서 수신
            onem2mtc0207012,        // 단말에서 self 송수신

            onem2mtc0208011,        // 모듈 OFF
            onem2mtc0208012,        // 모듈 ON - POA 업데이트 이벤트 대기

            onem2mtc0209011,        // ACP 1회 생성
            onem2mtc0209012,        // ACP 생성 오류(존재)/삭제후 생성
            onem2mtc0209013,        // ACP 조회오류(미존재)/생성
            onem2mtc020902,         // ACP 조회
            onem2mtc020903,
            onem2mtc0209041,
            onem2mtc0209042,

            onem2mtc021001,
            onem2mtc021002,         // push test는 별도 수동 진행
            onem2mtc0210031,
            onem2mtc0210032,        // DEVICE FW DATA 수신중
            onem2mtc0210033,        // DEVICE FW DATA 수신 완료

            onem2mtc0210034,        // deviceFWUPstart,
            onem2mtc0210035,        // deviceFWDLfinsh,
            onem2mtc0210036,        // deviceFWList,
            onem2mtc0210037,        // deviceFWOpen,
            onem2mtc0210038,        // deviceFWRead,
            onem2mtc0210039,        // deviceFWClose,

            onem2mtc0210041,
            onem2mtc0210042,        // DEVICE version report 준비

            onem2mtc021101,
            onem2mtc021102,         //  push test는 별도 수동 진행
            onem2mtc0211031,
            onem2mtc0211032,        // EC21/EC25 upgrade 이후 oneM2M 모드 설정
            onem2mtc0211033,
            onem2mtc0211034,
            onem2mtc0211035,
            onem2mtc0211040,        // module reset 이후 oneM2M 모드 요청
            onem2mtc0211041,        // module version finsh를 위해 MEF인증 요청
            onem2mtc0211042,        // module version report 요청
            onem2mtc0211043,        // module version 완료
            onem2mtc0211044,        // 결과 확인을 위해 module version read

            //onem2mtc021201,         // 데이터 삭제 시험 불필요
            onem2mtc0212021,         // 구독 등록 존재하여 삭제 후 생성 요청
            onem2mtc0212022,         // 구독 삭제 - 폴더 삭제 시험
            onem2mtc0212031,        // StoD폴더 삭제 - DtoS 폴더삭제
            onem2mtc0212032,        // 폴더 삭제 - remoteCSE 삭제 시험
            onem2mtc0212041,        // remoteCSE 존재하여 삭제 후 생성 요청
            onem2mtc0212042,        // remoteCSE 삭제 (TC 마지막)

            onem2mtc021301,         // 디바이스 데이터 forwarding
            onem2mtc021302,         // Device control data
            onem2mtc0213031,         // Waiting Device Status Check
            onem2mtc0213032,         // Response Device Status Check

            onem2mtc0214011,         // 원격 재부팅 수신
            onem2mtc0214012,         // oneM2M Client 구동 요청
            onem2mtc0214013,         // MEF 인증 요청
            onem2mtc0214014,         // MEF 인증 요청

            onem2mset01,            // remoteCSE 생성
            onem2mset02,            // DtoS 폴더 생성
            onem2mset03,            // StoD 폴더 생성
            onem2mset04,            // StoD 구독 신청
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
        string nextcmdexts = string.Empty;
        string nextresponse = string.Empty;   //응답에 prefix가 존재하는 경우
        string commmode = "catm1";
        string imsmode = "no";
        ServiceServer svr = new ServiceServer();
        Device dev = new Device();
        TCResult tc = new TCResult();

        string device_fota_index = "0";
        string device_total_index = "0";
        string device_fota_checksum = "";
        UInt32 oneM2Mtotalsize = 0;
        UInt32 oneM2Mrcvsize = 0;
        string filecode = string.Empty;

        string oneM2MMEFIP = "106.103.234.198";
        string oneM2MMEFPort = "80";
        string oneM2MBRKIP = "106.103.234.117";
        string oneM2MBRKPort = "80";
        string oneM2MFOTAIP = "106.103.228.97";
        string oneM2MFOTAPort = "80";

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

        DateTime tcStartTime = DateTime.Now.AddHours(-1);
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
            commands.Add("sendonemsgsvr", "AT$OM_C_RCIN_REQ=");
            commands.Add("responemsgsvr", "AT$OM_S_RCIN_REQ=");

            commands.Add("getonem2mmode", "AT$LGTMPF?");
            commands.Add("setonem2mmode", "AT$LGTMPF=5");
            commands.Add("setmefauth", "AT$OM_AUTH_REQ=");
            commands.Add("setmefauthnt", "AT$OM_AUTH_REQ=");
            commands.Add("fotamefauthnt", "AT$OM_AUTH_REQ=");
            commands.Add("mfotamefauth", "AT$OM_AUTH_REQ=");
            commands.Add("getCSEbase", "AT$OM_B_CSE_REQ");
            commands.Add("getremoteCSE", "AT$OM_R_CSE_REQ");
            commands.Add("setremoteCSE", "AT$OM_C_CSE_REQ");
            commands.Add("updateremoteCSE", "AT$OM_U_CSE_REQ");
            commands.Add("delremoteCSE", "AT$OM_D_CSE_REQ");
            commands.Add("setcontainer", "AT$OM_C_CON_REQ=DtoS");
            commands.Add("settxcontainer", "AT$OM_C_CON_REQ=StoD");
            commands.Add("delcontainer", "AT$OM_D_CON_REQ=");
            commands.Add("setsubscript", "AT$OM_C_SUB_REQ=");
            commands.Add("delsubscript", "AT$OM_D_SUB_REQ=");
            commands.Add("getonem2mdata", "AT$OM_R_INS_REQ=");
            commands.Add("getACP", "AT$OM_R_ACP_REQ");
            commands.Add("setACP", "AT$OM_C_ACP_REQ=63,*");
            commands.Add("updateACP", "AT$OM_U_ACP_REQ=47,*");
            commands.Add("delACP", "AT$OM_D_ACP_REQ");
            commands.Add("setrcvauto", "AT$OM_MODE=ON");
            commands.Add("setrcvmanu", "AT$OM_MODE=OFF");
            commands.Add("resetreport", "AT$OM_RESET_FINISH");
            commands.Add("resetmefauth", "AT$OM_AUTH_REQ=");

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
            commands.Add("setfotaserverinfo", "AT$OM_SVR_INFO=3,");
            commands.Add("getserverinfo", "AT$OM_SVR_INFO?");

            commands.Add("getmodemSvrVer", "AT$OM_MODEM_FWUP_REQ");
            commands.Add("setmodemver", "AT$OM_C_MODEM_FWUP_REQ");
            commands.Add("modemFWUPreport", "AT$OM_MODEM_FWUP_FINISH");
            commands.Add("modemFWUPfinishLTE", "AT$OM_MOD_FWUP_FINISH");
            commands.Add("modemFWUPstart", "AT$OM_MODEM_FWUP_START");

            commands.Add("getdeviceSvrVer", "AT$OM_DEV_FWUP_REQ");
            commands.Add("setdeviceSrvver", "AT$OM_C_DEV_FWUP_REQ");
            commands.Add("deviceFWUPfinish", "AT$OM_DEV_FWUP_FINISH");
            commands.Add("deviceFWUPstart", "AT$OM_DEV_FWUP_START");
            commands.Add("deviceFWList", "AT+QFLST=\"*\"");
            commands.Add("deviceFWOpen", "AT+QFOPEN=");
            commands.Add("deviceFWRead", "AT+QFREAD=");
            commands.Add("deviceFWClose", "AT+QFCLOSE=");

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
            dev.uuid = string.Empty;
            dev.type = "onem2m";
            dev.model = string.Empty;

            /////   서버 초기값 설정
            svr.enrmtKeyId = string.Empty;
            svr.entityId = string.Empty;

            lbActionState.Text = "idle";

            commmode = "catm1";
            button31.BackColor = SystemColors.Control;
            button33.BackColor = SystemColors.ButtonHighlight;
            button32.BackColor = SystemColors.Control;
            button68.Enabled = true;

            groupBox2.Enabled = false;
            groupBox6.Enabled = false;
            groupBox5.Enabled = false;

            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.CheckBoxes = false;

            listView1.Columns.Add("시험 항목", 300, HorizontalAlignment.Center);
            listView1.Columns.Add("결과", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("resultCode", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("logId", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("설명", 200, HorizontalAlignment.Center);
            listView1.Columns.Add("비고", 200, HorizontalAlignment.Center);

            foreach (string tcindex in Enum.GetNames(typeof(onem2mtc)))
            {
                ListViewItem newitem = new ListViewItem(new string[] { onem2mtclist[tcindex], "Not TEST", string.Empty, string.Empty, string.Empty, string.Empty });
                listView1.Items.Add(newitem);
            }

            listView2.View = View.Details;
            listView2.GridLines = true;
            listView2.FullRowSelect = true;
            listView2.CheckBoxes = false;

            listView2.Columns.Add("시험 항목", 300, HorizontalAlignment.Center);
            listView2.Columns.Add("결과", 100, HorizontalAlignment.Center);
            listView2.Columns.Add("resultCode", 100, HorizontalAlignment.Center);
            listView2.Columns.Add("logId", 100, HorizontalAlignment.Center);
            listView2.Columns.Add("설명", 200, HorizontalAlignment.Center);
            listView2.Columns.Add("비고", 200, HorizontalAlignment.Center);

            foreach (string tcindex in Enum.GetNames(typeof(lwm2mtc)))
            {
                ListViewItem newitem = new ListViewItem(new string[] { lwm2mtclist[tcindex], "Not TEST", string.Empty, string.Empty, string.Empty, string.Empty });
                listView2.Items.Add(newitem);
            }

            listView3.View = View.Details;
            listView3.GridLines = true;
            listView3.FullRowSelect = true;
            listView3.CheckBoxes = false;

            listView3.Columns.Add("시간", 60, HorizontalAlignment.Center);
            listView3.Columns.Add("state", 120, HorizontalAlignment.Left);
            listView3.Columns.Add("  ", 30, HorizontalAlignment.Center);
            listView3.Columns.Add("  AT COMMAND", 1000, HorizontalAlignment.Left);

            listView4.View = View.Details;
            listView4.GridLines = true;
            listView4.FullRowSelect = true;
            listView4.CheckBoxes = false;

            listView4.Columns.Add("시간", 60, HorizontalAlignment.Center);
            listView4.Columns.Add("state", 120, HorizontalAlignment.Left);
            listView4.Columns.Add("  ", 30, HorizontalAlignment.Center);
            listView4.Columns.Add("  AT COMMAND", 1000, HorizontalAlignment.Left);

            listView5.View = View.Details;
            listView5.GridLines = true;
            listView5.FullRowSelect = true;
            listView5.CheckBoxes = false;

            listView5.Columns.Add("시간", 60, HorizontalAlignment.Center);
            listView5.Columns.Add("state", 120, HorizontalAlignment.Left);
            listView5.Columns.Add("  ", 30, HorizontalAlignment.Center);
            listView5.Columns.Add("  AT COMMAND", 1000, HorizontalAlignment.Left);

            listView6.View = View.Details;
            listView6.GridLines = true;
            listView6.FullRowSelect = true;
            listView6.CheckBoxes = false;

            listView6.Columns.Add("시간", 60, HorizontalAlignment.Center);
            listView6.Columns.Add("state", 80, HorizontalAlignment.Left);
            listView6.Columns.Add("항목", 280, HorizontalAlignment.Left);
            listView6.Columns.Add("결과", 40, HorizontalAlignment.Center);
            listView6.Columns.Add("LogID", 80, HorizontalAlignment.Center);

            listView7.View = View.Details;
            listView7.GridLines = true;
            listView7.FullRowSelect = true;
            listView7.CheckBoxes = false;

            listView7.Columns.Add("시간", 60, HorizontalAlignment.Center);
            listView7.Columns.Add("state", 120, HorizontalAlignment.Left);
            listView7.Columns.Add("", 30, HorizontalAlignment.Center);
            listView7.Columns.Add(" 전송 내용", 1000, HorizontalAlignment.Left);

            listView8.View = View.Details;
            listView8.GridLines = true;
            listView8.FullRowSelect = true;
            listView8.CheckBoxes = false;

            listView8.Columns.Add("시간", 55, HorizontalAlignment.Center);
            listView8.Columns.Add("ID", 70, HorizontalAlignment.Center);
            listView8.Columns.Add("이벤트", 120, HorizontalAlignment.Left);
            listView8.Columns.Add("rsltCode", 60, HorizontalAlignment.Center);
            listView8.Columns.Add(" 비고", 800, HorizontalAlignment.Left);

            listView9.View = View.Details;
            listView9.GridLines = true;
            listView9.FullRowSelect = true;
            listView9.CheckBoxes = false;

            listView9.Columns.Add("시간", 55, HorizontalAlignment.Center);
            listView9.Columns.Add("ID", 70, HorizontalAlignment.Center);
            listView9.Columns.Add("이벤트", 120, HorizontalAlignment.Left);
            listView9.Columns.Add("rsltCode", 60, HorizontalAlignment.Center);
            listView9.Columns.Add(" 비고", 800, HorizontalAlignment.Left);

            listView10.View = View.Details;
            listView10.GridLines = true;
            listView10.FullRowSelect = true;
            listView10.CheckBoxes = false;

            listView10.Columns.Add("서버", 60, HorizontalAlignment.Center);
            listView10.Columns.Add("TYPE", 70, HorizontalAlignment.Center);
            listView10.Columns.Add("Method", 100, HorizontalAlignment.Center);
            listView10.Columns.Add(" 상세 내용", 200, HorizontalAlignment.Left);
            listView10.Columns.Add(" 상세 전문", 800, HorizontalAlignment.Left);

            tcStartTime = DateTime.Now.AddHours(-2);
            dateTimePicker1.Value = tcStartTime;
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
                    serialPort1.DtrEnable = true;
                    serialPort1.RtsEnable = false;
                    serialPort1.ReadTimeout = (int)500;
                    serialPort1.WriteTimeout = (int)500;

                    serialPort1.Open();

                    if (lbActionState.Text == states.closed.ToString())
                        lbActionState.Text = states.idle.ToString();
                    
                    if (dev.entityId == string.Empty)
                        progressBar1.Value = 50;
                    else
                        progressBar1.Value = 100;
                    timer1.Start();
                    logPrintInTextBox("COM PORT가 연결 되었습니다.", "");
                }
                catch (Exception err)
                {
                    logPrintInTextBox(err.Message, "");
                }
            }

        }

        private void doCloseComPort()
        {
            progressBar1.Value = 0;
            serialPort1.Close();
            if (lbActionState.Text == states.idle.ToString())
                lbActionState.Text = states.closed.ToString();
            timer1.Stop();
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

                    nextcommand = string.Empty;
                    nextresponse = string.Empty;
                }
                else
                {
                    progressBar1.Value = 0;
                    MessageBox.Show("COM 포트가 오픈되어 있지 않습니다.");
                    this.doOpenComPort();     // Serial port가 끊어진 것으로 판단, 포트 재오픈
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                progressBar1.Value = 0;
            }
        }

        // 송수신 명령/응답 값과 동작 설명을 textbox에 삽입하고 앱 종료시 로그파일로 저장한다.
        public void logPrintInTextBox(string message, string kind)
        {
            if (message != "\r" && message != "\r\r")
            {
                if (kind == "tx")
                    kind = "T";
                else if (kind == "rx")
                {
                    kind = "R";

                    /* Debug를 위해 Hex로 문자열 표시*/
/*
                    char[] charValues = message.ToCharArray();
                    string hexOutput = "";
                    foreach (char _eachChar in charValues)
                    {
                        int value = Convert.ToInt32(_eachChar);
                        if (value < 16)
                            hexOutput += "0";
                        hexOutput += String.Format("{0:X}", value);
                    }
                    message = hexOutput;
*/                  
                }
                else
                    kind = " ";

                SetTextBox(listView3, kind + message);
            }
        }

        private void SetTextBox(Control ctr, string message)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (ctr.InvokeRequired)
            {
                Ctr_Involk CI = new Ctr_Involk(SetTextBox);
                ctr.Invoke(CI, ctr, message);
            }
            else
            {
                string kind = message.Substring(0, 1);
                string msg = message.Substring(1, message.Length - 1);
                string time = DateTime.Now.ToString("hh:mm:ss");

                ListViewItem newitem3;
                ListViewItem newitem4;
                ListViewItem newitem5;
                if (kind == " ")
                {
                    newitem3 = new ListViewItem(new string[] { string.Empty, string.Empty, string.Empty, msg });
                    newitem4 = new ListViewItem(new string[] { string.Empty, string.Empty, string.Empty, msg });
                    newitem5 = new ListViewItem(new string[] { string.Empty, string.Empty, string.Empty, msg });
                }
                else
                {
                    newitem3 = new ListViewItem(new string[] { time, lbActionState.Text, kind, msg });
                    newitem4 = new ListViewItem(new string[] { time, lbActionState.Text, kind, msg });
                    newitem5 = new ListViewItem(new string[] { time, lbActionState.Text, kind, msg });
                }
                listView3.Items.Add(newitem3);
                listView4.Items.Add(newitem4);
                listView5.Items.Add(newitem5);
                if (kind == "T")
                {
                    listView3.Items[listView3.Items.Count - 1].BackColor = Color.LightBlue;
                    listView4.Items[listView4.Items.Count - 1].BackColor = Color.LightBlue;
                    listView5.Items[listView5.Items.Count - 1].BackColor = Color.LightBlue;
                }

                if (listView3.Items.Count > 35)
                {
                    listView3.TopItem = listView3.Items[listView3.Items.Count - 1];
                    listView4.TopItem = listView4.Items[listView4.Items.Count - 1];
                    listView5.TopItem = listView5.Items[listView5.Items.Count - 1];
                }
            }
        }

        // serial port에서 data 수신이 될 때, 발생하는 이벤트 함수
        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                SerialPort rcvPort = (SerialPort)sender;
                dataIN += rcvPort.ReadExisting();               // 수신한 버퍼에 있는 데이터 모두 받음
                this.Invoke(new EventHandler(ShowData));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            logPrintInTextBox(rxMsg,"rx");          // 수신한 데이터 한줄을 표시

            if ((rxMsg != "\r") && (rxMsg != "\n"))
            {
                if (rxMsg == "OK")
                {
                    if (lbActionState.Text == states.testatcmd.ToString())
                    {
                        MessageBox.Show("OK 응답을 받았습니다.");
                        lbActionState.Text = states.idle.ToString();
                    }
                    else
                        OKReceived();
                }
                else if (rxMsg == "ERROR")
                {
                    if (lbActionState.Text == states.testatcmd.ToString())
                    {
                        MessageBox.Show("ERROR 응답을 받았습니다.");
                        lbActionState.Text = states.idle.ToString();
                        nextcommand = "";
                    }
                    else if (lbActionState.Text == states.modemFWUPboot.ToString())
                    {
                        // 디바이스 펌웨어 버전 등록을 위해 플랫폼 서버 MEF AUTH 요청
                        this.sendDataOut(commands["setmefauth"] + tbSvcCd.Text + "," + tBoxDeviceModel.Text + "," + tBoxDeviceVer.Text + "," + tBoxDeviceSN.Text);
                        lbActionState.Text = states.mfotamefauth.ToString();
                        nextresponse = "$OM_AUTH_RSP=";
                    }
                    else if (lbActionState.Text == states.onem2mtc0211040.ToString() || lbActionState.Text == states.onem2mtc0211041.ToString())
                    {
                        // 디바이스 펌웨어 버전 등록을 위해 플랫폼 서버 MEF AUTH 요청
                        this.sendDataOut(commands["setmefauth"] + tbSvcCd.Text + "," + tBoxDeviceModel.Text + "," + tBoxDeviceVer.Text + "," + tBoxDeviceSN.Text);
                        lbActionState.Text = states.onem2mtc0211042.ToString();
                        nextresponse = "$OM_AUTH_RSP=";
                    }
                    /*
                    else if (lbActionState.Text == states.onem2mtc0201022.ToString())
                    {
                        this.sendDataOut(commands["getonem2mmode"]);
                        lbActionState.Text = states.onem2mtc0201023.ToString();
                        nextresponse = "$LGTMPF=";
                    }
                    */
                    else if (lbActionState.Text == states.resetmodechk.ToString())
                    {
                        this.sendDataOut(commands["getonem2mmode"]);
                        lbActionState.Text = states.resetmodechk.ToString();
                        nextresponse = "$LGTMPF=";
                    }
                    else
                    {
                        lbActionState.Text = states.idle.ToString();
                        nextcommand = string.Empty;
                        nextresponse = string.Empty;
                    }
                }
                else if (rxMsg.StartsWith("$OM_N_INS_RSP=", System.StringComparison.CurrentCultureIgnoreCase))
                {
                    // oneM2M subscription 설정에 의한 data 수신 이벤트
                    endoneM2MTC("tc020603", string.Empty, string.Empty, string.Empty, string.Empty);

                    if (lbActionState.Text == states.onem2mtc0205043.ToString()
                        || lbActionState.Text == states.onem2mtc0206011.ToString()
                        || lbActionState.Text == states.onem2mtc0206012.ToString())
                    {
                        startoneM2MTC("tc020604");
                        this.sendDataOut(commands["setrcvmanu"]);
                        lbActionState.Text = states.onem2mtc0206041.ToString();
                    }
                    else
                    {
                        // 타겟으로 하는 문자열(s, 고정 값)과 이후 문자열(str2, 변하는 값)을 구분함.
                        string cmd = "$OM_N_INS_RSP=";
                        int first = rxMsg.IndexOf(cmd) + cmd.Length;
                        string str2 = rxMsg.Substring(first, rxMsg.Length - first);
                        string[] rcvdatas = str2.Split(',');    // 수신한 데이터를 한 문장씩 나누어 array에 저장
                        int rxdatasize = Convert.ToInt32(rcvdatas[1]);
                        if (rxdatasize == rcvdatas[2].Length)
                        {
                            lboneM2MRcvData.Text = rcvdatas[2];
                            if (lbActionState.Text == states.onem2mtc0206032.ToString())
                            {
                                if (lboneM2MRcvData.Text == lbSendedData.Text)
                                    endoneM2MTC("tc021302", string.Empty, string.Empty, string.Empty, string.Empty);
                                else
                                    endoneM2MTC("tc021302", string.Empty, "20000100", lboneM2MRcvData.Text, lbSendedData.Text);
                            }
                            else
                            {
                                if (lboneM2MRcvData.Text == label9.Text)
                                    endoneM2MTC("tc021302", string.Empty, string.Empty, string.Empty, string.Empty);
                                else
                                    endoneM2MTC("tc021302", string.Empty, "20000100", lboneM2MRcvData.Text, label9.Text);
                            }
                            logPrintInTextBox(rcvdatas[0] + "폴더에 " + rcvdatas[2] + "를 수신하였습니다.", "");
                        }
                        else
                            MessageBox.Show("수신한 데이터 사이즈를 확인하세요", "");

                        if (lbActionState.Text == states.onem2mtc0206032.ToString() || lbActionState.Text == states.onem2mtc0206031.ToString())
                        {
                            startoneM2MTC("tc020604");
                            this.sendDataOut(commands["setrcvmanu"]);
                            lbActionState.Text = states.onem2mtc0206042.ToString();
                        }
                        else
                        {
                            lbActionState.Text = states.idle.ToString();
                            nextcommand = string.Empty;
                        }
                    }
                }
                else if (rxMsg.StartsWith("$OM_NOTI_IND=", System.StringComparison.CurrentCultureIgnoreCase))
                {
                    // oneM2M subscription 설정에 의한 data 수신 이벤트
                    endoneM2MTC("tc020601", string.Empty, string.Empty, string.Empty, string.Empty);

                    // 타겟으로 하는 문자열(s, 고정 값)과 이후 문자열(str2, 변하는 값)을 구분함.
                    string cmd = "$OM_NOTI_IND=";
                    int first = rxMsg.IndexOf(cmd) + cmd.Length;
                    string str2 = rxMsg.Substring(first, rxMsg.Length - first);

                    if (lbActionState.Text == states.onem2mtc0205043.ToString() 
                        || lbActionState.Text == states.onem2mtc0206011.ToString()
                        || lbActionState.Text == states.onem2mtc0206012.ToString())
                    {
                        endoneM2MTC("tc020504", string.Empty, string.Empty, string.Empty, string.Empty);
                        this.sendDataOut(commands["getonem2mdata"] + str2);
                        if (lbActionState.Text == states.onem2mtc0206012.ToString())
                            lbActionState.Text = states.onem2mtc0207012.ToString();
                        else
                            lbActionState.Text = states.onem2mtc0207011.ToString();
                        nextresponse = "$OM_R_INS_RSP=";
                    }
                    else
                    {
                        this.sendDataOut(commands["getonem2mdata"] + str2);
                        if (lbActionState.Text == states.sendonedevdb.ToString())
                            lbActionState.Text = states.sendonedevdb2.ToString();
                        else
                            lbActionState.Text = states.getonem2mdata.ToString();
                        nextresponse = "$OM_R_INS_RSP=";
                    }
                }
                else if (rxMsg.StartsWith("$OM_DEV_FWDL_FAIL=", System.StringComparison.CurrentCultureIgnoreCase))
                {
                    endoneM2MTC("tc021001", string.Empty, "20000100", string.Empty, rxMsg);
                    lbActionState.Text = states.idle.ToString();
                    nextcommand = string.Empty;
                    nextresponse = string.Empty;
                }
                else if (rxMsg.StartsWith("$OM_DEV_FWUP_RSP=", System.StringComparison.CurrentCultureIgnoreCase))
                {
                    // 타겟으로 하는 문자열(s, 고정 값)과 이후 문자열(str2, 변하는 값)을 구분함.
                    string cmd = "$OM_DEV_FWUP_RSP =";
                    int first = rxMsg.IndexOf(cmd) + cmd.Length;
                    string str2 = rxMsg.Substring(first, rxMsg.Length - first);

                    string[] deviceverinfos = str2.Split(',');    // 수신한 데이터를 한 문장씩 나누어 array에 저장
                    if (lbActionState.Text == states.idle.ToString())
                    {
                        tBoxDeviceVer.Text = deviceverinfos[1];
                        logPrintInTextBox("수신한 DEVICE의 버전은 " + deviceverinfos[1] + "입니다. 업데이트를 시도합니다.", "");
                        endoneM2MTC("tc021002", string.Empty, string.Empty, string.Empty, str2);
                        this.sendDataOut(commands["deviceFWUPstart"]);
                        if (dev.model == "EC25" || dev.model == "EC21")               //쿼텔/oneM2M 모듈
                            lbActionState.Text = states.deviceFWUPstart.ToString();
                        else
                            lbActionState.Text = states.deviceFWDownload.ToString();
                        nextresponse = "$OM_DEV_FWDL_START=";

                        oneM2Mrcvsize = 0;
                        oneM2Mtotalsize = 0;
                    }
                    else
                    {
                        if (deviceverinfos[0] == "2000")
                        {
                            endoneM2MTC("tc021001", string.Empty, string.Empty, string.Empty, str2);

                            tBoxDeviceVer.Text = deviceverinfos[1];
                            logPrintInTextBox("수신한 DEVICE의 버전은 " + deviceverinfos[1] + "입니다. 업데이트를 시도합니다.", "");

                            this.sendDataOut(commands["deviceFWUPstart"]);
                            nextresponse = "$OM_DEV_FWDL_START=";

                            oneM2Mrcvsize = 0;
                            oneM2Mtotalsize = 0;
                            if (lbActionState.Text == states.getdeviceSvrVer.ToString())
                            {
                                if (dev.model == "EC25" || dev.model == "EC21")               //쿼텔/oneM2M 모듈
                                    lbActionState.Text = states.deviceFWUPstart.ToString();
                                else
                                    lbActionState.Text = states.deviceFWDownload.ToString();
                            }
                            else
                            {
                                if (dev.model == "EC25" || dev.model == "EC21")               //쿼텔/oneM2M 모듈
                                    lbActionState.Text = states.onem2mtc0210034.ToString();
                                else
                                    lbActionState.Text = states.onem2mtc0210031.ToString();
                            }
                        }
                        else if (deviceverinfos[0] == "9001")
                        {
                            endoneM2MTC("tc021001", string.Empty, string.Empty, string.Empty, deviceverinfos[0]);

                            if (lbActionState.Text == states.getdeviceSvrVer.ToString())
                            {
                                MessageBox.Show("현재 DEVICE 버전이 최신버전입니다.", "");
                                lbActionState.Text = states.idle.ToString();
                            }
                            else
                            {
                                startoneM2MTC("tc021101");
                                this.sendDataOut(commands["getmodemSvrVer"]);
                                lbActionState.Text = states.onem2mtc021101.ToString();
                                nextresponse = "$OM_MODEM_FWUP_RSP=";
                            }
                        }
                        else
                        {
                            endoneM2MTC("tc021001", string.Empty, "20000100", string.Empty, deviceverinfos[0]);

                            if (lbActionState.Text == states.getdeviceSvrVer.ToString())
                                lbActionState.Text = states.idle.ToString();
                            else
                            {
                                startoneM2MTC("tc021101");
                                this.sendDataOut(commands["getmodemSvrVer"]);
                                lbActionState.Text = states.onem2mtc021101.ToString();
                                nextresponse = "$OM_MODEM_FWUP_RSP=";
                            }
                        }
                    }
                }
                else if (rxMsg.StartsWith("$OM_MODEM_FWUP_RSP=", System.StringComparison.CurrentCultureIgnoreCase))
                {
                    // 타겟으로 하는 문자열(s, 고정 값)과 이후 문자열(str2, 변하는 값)을 구분함.
                    string cmd = "$OM_MODEM_FWUP_RSP=";
                    int first = rxMsg.IndexOf(cmd) + cmd.Length;
                    string str2 = rxMsg.Substring(first, rxMsg.Length - first);

                    string[] modemverinfos = str2.Split(',');    // 수신한 데이터를 한 문장씩 나누어 array에 저장
                    if (lbActionState.Text == states.idle.ToString())
                    {
                        endoneM2MTC("tc021102", string.Empty, string.Empty, string.Empty, str2);        // oneM2M Module FOTA start 수신 이벤트

                        logPrintInTextBox("수신한 MODEM의 버전은 " + modemverinfos[1] + "입니다. 업데이트를 시도합니다.", "");

                        this.sendDataOut(commands["modemFWUPstart"]);
                        lbActionState.Text = states.modemFWUPstart.ToString();
                        nextresponse = "$OM_MODEM_FWDL_FINISH";
                    }
                    else
                    {
                        if (modemverinfos[0] == "2000")
                        {
                            endoneM2MTC("tc021101", string.Empty, string.Empty, string.Empty, str2);
                            logPrintInTextBox("수신한 MODEM의 버전은 " + modemverinfos[1] + "입니다. 업데이트를 시도합니다.", "");

                            this.sendDataOut(commands["modemFWUPstart"]);
                            if (lbActionState.Text == states.getmodemSvrVer.ToString())
                                lbActionState.Text = states.modemFWUPstart.ToString();
                            else
                                lbActionState.Text = states.onem2mtc0211031.ToString();
                            nextresponse = "$OM_MODEM_FWDL_FINISH";
                        }
                        else if (modemverinfos[0] == "9001")
                        {
                            endoneM2MTC("tc021101", string.Empty, string.Empty, string.Empty, str2);
                            if (lbActionState.Text == states.getmodemSvrVer.ToString())
                            {
                                MessageBox.Show("현재 MODEM 버전이 최신버전입니다.", "");
                                lbActionState.Text = states.idle.ToString();
                            }
                            else
                            {
                                startoneM2MTC("tc021202");
                                this.sendDataOut(commands["delsubscript"] + "StoD");
                                lbActionState.Text = states.onem2mtc0212022.ToString();
                                nextresponse = "$OM_D_SUB_RSP=";
                            }
                        }
                        else
                        {
                            endoneM2MTC("tc021101", string.Empty, "20000100", string.Empty, str2);
                            if (lbActionState.Text == states.getmodemSvrVer.ToString())
                                lbActionState.Text = states.idle.ToString();
                            else
                            {
                                startoneM2MTC("tc021202");
                                this.sendDataOut(commands["delsubscript"] + "StoD");
                                lbActionState.Text = states.onem2mtc0212022.ToString();
                                nextresponse = "$OM_D_SUB_RSP=";
                            }
                        }
                    }
                }
                else if (rxMsg == "$OM_RESET")
                {
                    logPrintInTextBox("플렛폼으로부터 원격재부팅 명령을 수신하였습니다.", "");

                    lbActionState.Text = states.resetreceived.ToString();
                    nextresponse = textBox72.Text;
                }
                else if (rxMsg.StartsWith("$OM_POA_NOTI=", System.StringComparison.CurrentCultureIgnoreCase))
                {
                    // 타겟으로 하는 문자열(s, 고정 값)과 이후 문자열(str2, 변하는 값)을 구분함.
                    string cmd = "$OM_POA_NOTI=";
                    int first = rxMsg.IndexOf(cmd) + cmd.Length;
                    string str2 = rxMsg.Substring(first, rxMsg.Length - first);
                    endoneM2MTC("tc020801", string.Empty, string.Empty, string.Empty, str2);

                    if (lbActionState.Text ==states.onem2mtc0208012.ToString())
                    {
                        if (checkBox4.Checked == true)                          //쿼텔/oneM2M 모듈
                        {
                            if (svr.entityId != string.Empty)
                            {
                                startoneM2MTC("tc021301");
                                // Data send to SERVER (string original)
                                //AT$OM_C_INS_REQ=<server id>,<object>,<length>,<data>
                                string txData = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") + " oneM2M device";
                                this.sendDataOut(commands["sendonemsgsvr"] + svr.entityId + "," + "TEST" + "," + txData.Length + "," + txData);
                                lbActionState.Text = states.onem2mtc021301.ToString();
                                nextresponse = "$OM_C_RCIN_RSP=";
                                lbSendedData.Text = txData;
                            }
                            else
                            {
                                startoneM2MTC("tc020901");
                                this.sendDataOut(commands["setACP"]);
                                lbActionState.Text = states.onem2mtc0209011.ToString();
                                nextresponse = "$OM_C_ACP_RSP=";
                            }
                        }
                        else
                        {
                            startoneM2MTC("tc020901");
                            this.sendDataOut(commands["setACP"]);
                            lbActionState.Text = states.onem2mtc0209011.ToString();
                            nextresponse = "$OM_C_ACP_RSP=";
                        }
                    }
                }
                else if (rxMsg.StartsWith("$OM_S_RCIN_RSP=", System.StringComparison.CurrentCultureIgnoreCase))
                {
                    // 타겟으로 하는 문자열(s, 고정 값)과 이후 문자열(str2, 변하는 값)을 구분함.
                    string cmd = "$OM_S_RCIN_RSP=";
                    int first = rxMsg.IndexOf(cmd) + cmd.Length;
                    string str2 = rxMsg.Substring(first, rxMsg.Length - first);

                    // 플랫폼 서버에 device status check 수신
                    logPrintInTextBox("TOPIC = " + str2 + "에 대해 상태 요청을 수신하였습니다.", "");
                    endoneM2MTC("tc021303", string.Empty, string.Empty, string.Empty, string.Empty);

                    string txData2 = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") + " response";
                    lbSendedData.Text = txData2;
                    this.sendDataOut(commands["responemsgsvr"] + str2 + "," + txData2.Length + "," + txData2);
                    if (lbActionState.Text == states.onem2mtc0213031.ToString())
                        lbActionState.Text = states.onem2mtc0213032.ToString();
                    else
                    lbActionState.Text = states.responemsgsvr.ToString();
                }
                else if (rxMsg.StartsWith("$OM_R_RCIN_RSP=", System.StringComparison.CurrentCultureIgnoreCase))
                {
                    // 타겟으로 하는 문자열(s, 고정 값)과 이후 문자열(str2, 변하는 값)을 구분함.
                    string cmd = "$OM_S_RCIN_RSP=";
                    int first = rxMsg.IndexOf(cmd) + cmd.Length;
                    string str2 = rxMsg.Substring(first, rxMsg.Length - first);

                    // oneM2M 서비스 서버 데이터 수신
                    string[] rx_svrdatas = str2.Split(',');    // 수신한 데이터를 한 문장씩 나누어 array에 저장

                    // 수신한 데이터 사이즈 확이
                    int rxsvrsize = Convert.ToInt32(rx_svrdatas[1]);
                    if (rxsvrsize == rx_svrdatas[2].Length)
                    {
                        lboneM2MRcvData.Text = rx_svrdatas[2];
                        if (lboneM2MRcvData.Text == label2.Text)
                            endoneM2MTC("tc021302", string.Empty, string.Empty, string.Empty, string.Empty);
                        logPrintInTextBox("TOPIC = " + rx_svrdatas[0] + "으로 " + rx_svrdatas[2] + "를 수신하였습니다.", "");
                    }
                    else
                    {
                        logPrintInTextBox("수신한 데이터 사이즈를 확인하세요", "");
                    }
                    if (lbActionState.Text == states.onem2mtc021302.ToString())
                    {
                        startoneM2MTC("tc021303");
                        lbActionState.Text = states.onem2mtc0213031.ToString();

                        string[] param = { "onem2m" };
                        rTh = new Thread(new ParameterizedThreadStart(RetriveDataToDevice));
                        rTh.Start(param);
                    }
                }
                else if (rxMsg.StartsWith(textBox69.Text, System.StringComparison.CurrentCultureIgnoreCase))
                {
                    // 타겟으로 하는 문자열(s, 고정 값)과 이후 문자열(str2, 변하는 값)을 구분함.
                    string cmd = textBox69.Text;
                    int first = rxMsg.IndexOf(cmd) + cmd.Length;
                    string str2 = rxMsg.Substring(first, rxMsg.Length - first);

                    // oneM2M 서비스 서버 데이터 수신
                    string[] rx_svrdatas = str2.Replace("\"",string.Empty).Split(',');    // 수신한 데이터를 한 문장씩 나누어 array에 저장
                                                                                          // 26241 FOTA DATA object RECEIVED!!!
                    receiveFotaData(rx_svrdatas[0], rx_svrdatas[1]);
                }
                else if (rxMsg.StartsWith(textBox68.Text, System.StringComparison.CurrentCultureIgnoreCase))
                {
                    // 타겟으로 하는 문자열(s, 고정 값)과 이후 문자열(str2, 변하는 값)을 구분함.
                    string cmd = textBox68.Text;
                    int first = rxMsg.IndexOf(cmd) + cmd.Length;
                    string str2 = rxMsg.Substring(first, rxMsg.Length - first).Replace("\"",string.Empty);

                    // oneM2M 서비스 서버 데이터 수신
                    string[] rx_svrdatas = str2.Split(',');    // 수신한 데이터를 한 문장씩 나누어 array에 저장
                                                               // 10250 DATA object RECEIVED!!!
                    if (Convert.ToInt32(rx_svrdatas[0]) == rx_svrdatas[1].Length / 2)    // data size 비교
                    {
                        //received hex data make to ascii code
                        lbLwM2MRcvData.Text = BcdToString(rx_svrdatas[1].ToCharArray());
                        if (lbLwM2MRcvData.Text == label40.Text)
                            endLwM2MTC("tc0502", string.Empty, string.Empty, string.Empty, string.Empty);
                        else
                            endLwM2MTC("tc0502", string.Empty, "20000100", lbLwM2MRcvData.Text, string.Empty);
                        logPrintInTextBox("\"" + lbLwM2MRcvData.Text + "\"를 수신하였습니다.", "");

                        if (lbActionState.Text == states.lwm2mtc0502.ToString())
                        {
                            if (svr.enrmtKeyId != string.Empty)
                            {
                                startLwM2MTC("tc0503", string.Empty, string.Empty, string.Empty, string.Empty);
                                lbActionState.Text = states.lwm2mtc0503.ToString();

                                rTh = new Thread(new ThreadStart(RetriveDataLwM2M));
                                rTh.Start();
                            }
                            else
                            {
                                this.sendDataOut(textBox52.Text);
                                startLwM2MTC("tc0401", string.Empty, string.Empty, string.Empty, textBox52.Text);
                                lbActionState.Text = states.lwm2mtc0401.ToString();
                            }
                        }
                    }
                    else
                    {
                        logPrintInTextBox("data size가 맞지 않습니다.", "");
                    }
                }
                else if (rxMsg.StartsWith(textBox70.Text))           // Module FOTA 이벤트
                {
                    // 모듈이 LWM2M서버 연동 상태 이벤트,
                    // OK 응답 발생하지 않음
                    // AT+MLWEVTIND=<type>
                    string cmd = textBox70.Text;
                    int first = rxMsg.IndexOf(cmd) + cmd.Length;
                    string str2 = rxMsg.Substring(first, rxMsg.Length - first);

                    if (dev.model.StartsWith("BG95"))
                    {
                        string[] state = str2.Replace("\"",string.Empty).Split(',');
                        if (state[0] == "event")
                        {
                            switch (state[2])
                            {
                                case "2":
                                    logPrintInTextBox("registration completed", "");
                                    break;
                                case "9":
                                    logPrintInTextBox("Bootstrap finished", "");
                                    endLwM2MTC("tc0202", string.Empty, string.Empty, string.Empty, string.Empty);

                                    if (lbActionState.Text == states.lwm2mtc02011.ToString() || lbActionState.Text == states.lwm2mtc02012.ToString())
                                    {
                                        timer2.Stop();
                                        lbActionState.Text = states.lwm2mtc0203.ToString();
                                    }
                                    else if (lbActionState.Text == states.lwm2mtc02029.ToString())
                                    {
                                        timer2.Stop();
                                        lbActionState.Text = states.lwm2mtc03012.ToString();
                                    }
                                    break;
                            }
                        }
                        else if (state[0] == "observe")
                        {
                            if (state[2] == "/26241/0/0")
                            {
                                logPrintInTextBox("26241 object subscription completed", "");
                                endLwM2MTC("tc0301", string.Empty, string.Empty, string.Empty, string.Empty);

                                if (lbActionState.Text == states.lwm2mtc03011.ToString() || lbActionState.Text == states.lwm2mtc03012.ToString()
                                    || lbActionState.Text == states.lwm2mtc0203.ToString())
                                {
                                    lbActionState.Text = states.lwm2mtc03013.ToString();
                                    timer2.Interval = 10000;
                                    timer2.Start();
                                }
                                else if (lbActionState.Text == states.lwm2mtc0602.ToString())
                                {
                                    endLwM2MTC("tc0602", string.Empty, string.Empty, string.Empty, string.Empty);

                                    lbActionState.Text = states.lwm2mtc03013.ToString();
                                    timer2.Interval = 10000;
                                    timer2.Start();
                                }
                                sendDataOut("AT+QLWCFG=\"session\",86400,86400");
                            }
                        }
                        else if (state[0] == "recv")
                        {
                            if (state[1] == "/26241/0/1")
                            {
                                // 26241 FOTA DATA object RECEIVED!!!
                                receiveFotaData(state[3], state[4]);
                            }
                        }
                    }
                    else
                    {
                        switch (str2)
                        {
                            case "0":
                                logPrintInTextBox("registration completed", "");
                                break;
                            case "1":
                                endLwM2MTC("tc0401", string.Empty, string.Empty, string.Empty, string.Empty);
                                logPrintInTextBox("deregistration completed", "");

                                if (lbActionState.Text == states.lwm2mtc0401.ToString())
                                {
                                    this.sendDataOut(textBox54.Text);       // fota push test를 위해 register 요청

                                    Thread.Sleep(10000);
                                    GetPlatformFWVer("NO");

                                    string kind = "type=lwm2m&ctn=" + tbDeviceCTN.Text;
                                    kind += "&from=" + tcStartTime.ToString("yyyyMMddHHmmss");

                                    getSvrLoglists(kind, "auto");
                                    logPrintInTextBox("전체 시험 완료.", "");
                                }
                                else
                                    lbActionState.Text = states.idle.ToString();
                                break;
                            case "2":
                                logPrintInTextBox("registration update completed", "");
                                break;
                            case "3":
                                logPrintInTextBox("10250 object subscription completed", "");
                                break;
                            case "4":
                                logPrintInTextBox("Bootstrap finished", "");
                                endLwM2MTC("tc0202", string.Empty, string.Empty, string.Empty, string.Empty);

                                if (lbActionState.Text == states.lwm2mtc02011.ToString() || lbActionState.Text == states.lwm2mtc02012.ToString())
                                {
                                    timer2.Stop();
                                    lbActionState.Text = states.lwm2mtc0203.ToString();
                                }
                                else if (lbActionState.Text == states.lwm2mtc02029.ToString())
                                {
                                    if (checkBox5.Checked == true)
                                    {
                                        this.sendDataOut(textBox54.Text);
                                        startLwM2MTC("tc0301", string.Empty, string.Empty, string.Empty, textBox54.Text);
                                        lbActionState.Text = states.lwm2mtc03011.ToString();
                                    }
                                    else
                                    {
                                        timer2.Stop();
                                        lbActionState.Text = states.lwm2mtc03012.ToString();
                                    }
                                }
                                break;
                            case "5":
                                logPrintInTextBox("5/0/3 object subscription completed", " ");
                                timer2.Stop();
                                startLwM2MTC("tc0602", string.Empty, string.Empty, string.Empty, string.Empty);
                                if (lbActionState.Text == states.lwm2mtc03013.ToString())
                                {
                                    lbActionState.Text = states.lwm2mtc0602.ToString();
                                }
                                break;
                            case "6":
                                logPrintInTextBox("fota downloading request", "");
                                break;
                            case "7":
                                logPrintInTextBox("fota update request", "");
                                break;
                            case "8":
                                logPrintInTextBox("26241 object subscription completed", "");
                                endLwM2MTC("tc0301", string.Empty, string.Empty, string.Empty, string.Empty);

                                if (lbActionState.Text == states.lwm2mtc03011.ToString() || lbActionState.Text == states.lwm2mtc03012.ToString()
                                    || lbActionState.Text == states.lwm2mtc0203.ToString())
                                {
                                    lbActionState.Text = states.lwm2mtc03013.ToString();
                                    timer2.Interval = 10000;
                                    timer2.Start();
                                }
                                else if (lbActionState.Text == states.lwm2mtc0602.ToString())
                                {
                                    endLwM2MTC("tc0602", string.Empty, string.Empty, string.Empty, string.Empty);

                                    lbActionState.Text = states.lwm2mtc03013.ToString();
                                    timer2.Interval = 10000;
                                    timer2.Start();
                                }
                                break;
                        }
                    }
                }
                else if (nextresponse != string.Empty)
                {
                    if (rxMsg.StartsWith(nextresponse, System.StringComparison.CurrentCultureIgnoreCase))
                    {
                        // 타겟으로 하는 문자열(s, 고정 값)과 이후 문자열(str2, 변하는 값)을 구분함.
                        int first = rxMsg.IndexOf(nextresponse) + nextresponse.Length;
                        string str2 = "";
                        str2 = rxMsg.Substring(first, rxMsg.Length - first);

                        this.parseNextReceiveData(str2);
                    }
                }
                else if (rxMsg.StartsWith("AT") == false)
                    this.parseNoPrefixData(rxMsg);
            }
        }

        private void parseNextReceiveData(string str2)
        {
            string[] rcvdatas = {string.Empty, string.Empty};    // 수신한 데이터를 한 문장씩 나누어 array에 저장
            string txData = string.Empty;

            states state = (states)Enum.Parse(typeof(states), lbActionState.Text);
            switch (state)
            {
                case states.getimei:
                    textBox89.Text = tbIMEI.Text = dev.imei = str2.Replace("\"","");
                    logPrintInTextBox("IMEI를 " + dev.imei + "로 저장하였습니다.", "");
                    lbActionState.Text = states.idle.ToString();
                    break;
                case states.autogetimei:
                    // 단말 정보 자동 갱신 순서
                    // autogetmanufac - autogetmodel - (autogetimei) - (autogetmodemver)
                    textBox89.Text = tbIMEI.Text = dev.imei = str2.Replace("\"", "");
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
                        lbIccid.Text = dev.iccid = str2.Substring(str2.Length - 20, 19);
                    else
                        lbIccid.Text = dev.iccid = str2;

                    logPrintInTextBox("ICCID가 " + dev.iccid + "로 저장되었습니다.", "");

                    setDeviceEntityID();

                    lbActionState.Text = states.idle.ToString();
                    break;
                case states.getonem2mmode:
                case states.onem2mtc0201021:
                case states.onem2mtc0201023:
                    if (str2 == "5")
                    {
                        endoneM2MTC("tc020102", string.Empty, string.Empty, string.Empty, string.Empty);
                        if (lbActionState.Text == states.getonem2mmode.ToString())
                            lbActionState.Text = states.idle.ToString();
                        else
                            nextcommand = states.onem2mtc0202011.ToString();
                    }
                    else
                    {
                        if (lbActionState.Text == states.getonem2mmode.ToString())
                            lbActionState.Text = states.idle.ToString();
                        else
                            nextcommand = states.onem2mtc0201022.ToString();
                    }
                    break;
                case states.modemFWUPmodechk:
                    if (str2 == "5")
                        nextcommand = states.modemFWUPmodeset.ToString();
                    else
                        nextcommand = states.modemFWUPboot.ToString();
                    lbActionState.Text = states.modemFWUPmodechked.ToString();
                    break;
                case states.onem2mtc0211034:
                    if (str2 == "5")
                        nextcommand = states.onem2mtc0211041.ToString();
                    else
                        nextcommand = states.onem2mtc0211040.ToString();
                    lbActionState.Text = states.onem2mtc0211035.ToString();
                    break;
                case states.resetmodechk:
                    if (str2 == "5")
                        nextcommand = states.resetmefauth.ToString();
                    else
                        nextcommand = states.resetmodeset.ToString();
                    lbActionState.Text = states.resetmodechked.ToString();
                    break;
                case states.getserverinfo:
                case states.onem2mtc0201014:
                    // oneM2M server 정보 확인
                    string[] servers = str2.Split(',');    // 수신한 데이터를 한 문장씩 나누어 array에 저장

                    if (servers[0] != oneM2MMEFIP)
                        endoneM2MTC("tc020101", "oneM2MMEFIP", "20000100", servers[0], oneM2MMEFIP);
                    else if (servers[1] != oneM2MMEFPort)
                        endoneM2MTC("tc020101", "oneM2MMEFPort", "20000100", servers[1], oneM2MMEFPort);
                    else if (servers[2] != oneM2MBRKIP)
                        endoneM2MTC("tc020101", "oneM2MBRKIP", "20000100", servers[2], oneM2MBRKIP);
                    else if (servers[3] != oneM2MBRKPort)
                        endoneM2MTC("tc020101", "oneM2MBRKIP", "20000100", servers[3], oneM2MBRKPort);
                    else
                    {
                        if (checkBox1.Checked == true)
                        {
                            if (servers.Length > 4)
                            {
                                if (servers[4] != oneM2MFOTAIP)
                                    endoneM2MTC("tc020101", "oneM2MFOTAIP", "20000100", servers[4], oneM2MFOTAIP);
                                else if (servers[5] != oneM2MFOTAPort)
                                    endoneM2MTC("tc020101", "oneM2MFOTAPort", "20000100", servers[5], oneM2MFOTAPort);
                                else
                                    endoneM2MTC("tc020101", string.Empty, string.Empty, string.Empty, string.Empty);
                            }
                            else
                                endoneM2MTC("tc020101", string.Empty, string.Empty, string.Empty, "NO FOTA info");
                        }
                        else
                            endoneM2MTC("tc020101", string.Empty, string.Empty, string.Empty, string.Empty);
                    }

                    if (lbActionState.Text == states.getserverinfo.ToString())
                        lbActionState.Text = states.idle.ToString();
                    else
                    {
                        this.sendDataOut(commands["getonem2mmode"]);
                        lbActionState.Text = states.onem2mtc0201021.ToString();
                        nextresponse = "$LGTMPF=";
                    }
                    break;
                case states.setmefauth:
                case states.onem2mtc0202012:
                    // oneM2M 인증 결과
                    if (str2 == "2000")
                    {
                        endoneM2MTC("tc020201", string.Empty, string.Empty, string.Empty, string.Empty);

                        if (lbActionState.Text == states.setmefauth.ToString())
                            lbActionState.Text = states.idle.ToString();
                        else
                        {
                            if (checkBox3.Checked == true)
                            {
                                startoneM2MTC("tc020401");
                                this.sendDataOut(commands["getCSEbase"]);
                                lbActionState.Text = states.onem2mtc020401.ToString();
                                nextresponse = "$OM_B_CSE_RSP=";
                            }
                            else
                            {
                                endoneM2MTC("tc020401", string.Empty, "20000200", string.Empty, string.Empty);

                                startoneM2MTC("tc020301");
                                this.sendDataOut(commands["getremoteCSE"]);
                                lbActionState.Text = states.onem2mtc020301.ToString();
                                nextresponse = "$OM_R_CSE_RSP=";
                            }
                        }
                    }
                    else
                    {
                        endoneM2MTC("tc020201", string.Empty, "20000100", string.Empty, str2);
                        lbActionState.Text = states.idle.ToString();
                    }
                    break;
                case states.fotamefauthnt:
                    // oneM2M 인증 결과
                    if (str2 == "2000")
                    {
                        this.sendDataOut(commands["deviceFWUPfinish"]);
                        lbActionState.Text = states.deviceFWUPfinish.ToString();
                        nextresponse = "$OM_DEV_FWUP_FINISH=";
                    }
                    else
                        lbActionState.Text = states.idle.ToString();
                    break;
                case states.onem2mtc0210041:
                    // oneM2M 인증 결과
                    if (str2 == "2000")
                    {
                        this.sendDataOut(commands["deviceFWUPfinish"]);
                        nextresponse = "$OM_DEV_FWUP_FINISH=";
                        lbActionState.Text = states.onem2mtc0210042.ToString();
                    }
                    else
                    {
                        endoneM2MTC("tc020201", string.Empty, "20000100", string.Empty, str2);
                        lbActionState.Text = states.idle.ToString();
                    }
                    break;
                case states.onem2mtc0210042:
                    if (str2 == "2004" || str2 == "2000")
                    {
                        if (svr.enrmtKeyId != string.Empty)
                        {
                            RetriveDverToPlatform();
                            if (tBoxDeviceVer.Text != lbdevicever.Text)
                                endoneM2MTC("tc021004", string.Empty, "20000100", tBoxDeviceVer.Text, lbdevicever.Text);
                            else
                                endoneM2MTC("tc021004", string.Empty, string.Empty, string.Empty, str2);
                        }
                        else
                            endoneM2MTC("tc021004", string.Empty, string.Empty, string.Empty, str2);
                    }
                    else
                    {
                        endoneM2MTC("tc021004", string.Empty, "20000100", string.Empty, str2);
                    }

                    startoneM2MTC("tc021101");
                    this.sendDataOut(commands["getmodemSvrVer"]);
                    lbActionState.Text = states.onem2mtc021101.ToString();
                    nextresponse = "$OM_MODEM_FWUP_RSP=";
                    break;
                case states.deviceFWUPfinish:
                    endoneM2MTC("tc021004", string.Empty, string.Empty, string.Empty, str2);
                    lbActionState.Text = states.idle.ToString();
                    break;
                case states.mfotamefauth:
                    // oneM2M 인증 결과
                    if (str2 == "2000")
                    {
                        this.sendDataOut(textBox73.Text);
                        lbActionState.Text = states.modemFWUPreport.ToString();
                        nextresponse = textBox73.Text.Substring(2, textBox73.Text.Length - 2) + "=";
                    }
                    else
                        lbActionState.Text = states.idle.ToString();
                    break;
                case states.onem2mtc0211042:
                    // oneM2M 인증 결과
                    if (str2 == "2000")
                    {
                        this.sendDataOut(textBox73.Text);
                        lbActionState.Text = states.onem2mtc0211043.ToString();
                        nextresponse = textBox73.Text.Substring(2, textBox73.Text.Length - 2) + "=";
                    }
                    else
                    {
                        endoneM2MTC("tc020201", string.Empty, "20000100", string.Empty, str2);

                        startoneM2MTC("tc021202");
                        this.sendDataOut(commands["delsubscript"] + "StoD");
                        lbActionState.Text = states.onem2mtc0212022.ToString();
                        nextresponse = "$OM_D_SUB_RSP=";
                    }
                    break;
                case states.modemFWUPreport:
                case states.onem2mtc0211043:
                    if (str2 == "2004" || str2 == "2000")
                        endoneM2MTC("tc021104", string.Empty, string.Empty, string.Empty, string.Empty);
                    else
                        endoneM2MTC("tc021104", string.Empty, "20000100", string.Empty, str2);

                    if (lbActionState.Text == states.modemFWUPreport.ToString())
                        lbActionState.Text = states.idle.ToString();
                    else
                    {
                        startoneM2MTC("tc021202");
                        this.sendDataOut(commands["delsubscript"] + "StoD");
                        lbActionState.Text = states.onem2mtc0212022.ToString();
                        nextresponse = "$OM_D_SUB_RSP=";
                    }
                    break;
                case states.getCSEbase:
                case states.onem2mtc020401:
                    // oneM2M CSEBase 조회 결과
                    if (str2 == "2000")
                        endoneM2MTC("tc020401", string.Empty, string.Empty, string.Empty, string.Empty);
                    else
                        endoneM2MTC("tc020401", string.Empty, "20000100", string.Empty, str2);
                    if (lbActionState.Text == states.getCSEbase.ToString())
                        lbActionState.Text = states.idle.ToString();
                    else
                    {
                        startoneM2MTC("tc020301");
                        this.sendDataOut(commands["getremoteCSE"]);
                        lbActionState.Text = states.onem2mtc020301.ToString();
                        nextresponse = "$OM_R_CSE_RSP=";
                    }
                    break;
                case states.getremoteCSE:
                case states.onem2mtc020301:
                    // oneM2M remoteCSE 조회 결과, 4004이면 생성/2000 또는 2004이면 container 확인
                    if (str2 == "4004")
                    {
                        endoneM2MTC("tc020301", string.Empty, string.Empty, string.Empty, string.Empty);
                        if (lbActionState.Text == states.getremoteCSE.ToString())
                        {
                            MessageBox.Show("remote CSE가 존재하지 않습니다.");
                            lbActionState.Text = states.idle.ToString();
                        }
                        else
                        {
                            this.sendDataOut(commands["setremoteCSE"]);
                            lbActionState.Text = states.onem2mtc0205012.ToString();     // 신규 삭제
                            nextresponse = "$OM_C_CSE_RSP=";
                        }
                    }
                    else if (str2 == "2000")
                    {
                        endoneM2MTC("tc020301", string.Empty, string.Empty, string.Empty, string.Empty);

                        if (lbActionState.Text == states.getremoteCSE.ToString())
                            lbActionState.Text = states.idle.ToString();
                        else
                        {
                            this.sendDataOut(commands["updateremoteCSE"]);
                            lbActionState.Text = states.onem2mtc020505.ToString();
                            nextresponse = "$OM_U_CSE_RSP=";
                        }
                    }
                    else
                    {
                        endoneM2MTC("tc020301", string.Empty, "20000100", string.Empty, str2);
                    }
                    break;
                case states.setremoteCSE:
                case states.onem2mtc0205012:
                    // oneM2M remoteCSE 생성 결과, 2001이면 container 생성 요청
                    endoneM2MTC("tc020501", string.Empty, string.Empty, string.Empty, str2);
                    if (lbActionState.Text == states.setremoteCSE.ToString())
                        lbActionState.Text = states.idle.ToString();
                    else
                    {
                        startoneM2MTC("tc020502");
                        this.sendDataOut(commands["setcontainer"]);
                        lbActionState.Text = states.onem2mtc0205021.ToString();
                        nextresponse = "$OM_C_CON_RSP=";
                    }
                    break;
                case states.onem2mset01:
                    // oneM2M remoteCSE 생성 결과, 2001이면 container 생성 요청
                    endoneM2MTC("tc020501", string.Empty, string.Empty, string.Empty, str2);
                    startoneM2MTC("tc020502");
                    this.sendDataOut(commands["setcontainer"]);
                    lbActionState.Text = states.onem2mset02.ToString();
                    nextresponse = "$OM_C_CON_RSP=";
                    break;
                case states.updateremoteCSE:
                case states.onem2mtc020505:
                    // oneM2M remoteCSE 업데이트 결과, 2004이면 remoteCSE (poa) 업데이트 성공
                    if (str2 == "2004" || str2 == "2000")
                        endoneM2MTC("tc020505", string.Empty, string.Empty, string.Empty, str2);
                    else
                        endoneM2MTC("tc020505", string.Empty, "20000100", string.Empty, str2);

                    if (lbActionState.Text == states.updateremoteCSE.ToString())
                        lbActionState.Text = states.idle.ToString();
                    else
                    {
                        startoneM2MTC("tc020504");
                        // Data send to SERVER (string original)
                        //AT$OM_C_INS_REQ=<object>,<length>,<data>
                        txData = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") + " oneM2M device";
                        if (svr.enrmtKeyId != string.Empty)
                        {
                            lbActionState.Text = states.onem2mtc0205041.ToString();
                            this.sendDataOut(commands["sendonemsgstr"] + "DtoS" + "," + txData.Length + "," + txData);
                        }
                        else
                        {
                            lbActionState.Text = states.onem2mtc0205043.ToString();
                            this.sendDataOut(commands["sendonemsgstr"] + "StoD" + "," + txData.Length + "," + txData);
                        }
                        nextresponse = "$OM_C_INS_RSP=";
                        lbSendedData.Text = txData;
                    }
                    break;
                case states.delremoteCSE:
                case states.onem2mtc0212042:
                    // oneM2M remoteCSE 삭제 결과, 2002이면 성공
                    endoneM2MTC("tc021204", string.Empty, string.Empty, string.Empty, str2);
                    if (lbActionState.Text == states.delremoteCSE.ToString())
                        lbActionState.Text = states.idle.ToString();
                    else
                    {
                        startoneM2MTC("tc020501");
                        this.sendDataOut(commands["setremoteCSE"]);
                        lbActionState.Text = states.onem2mset01.ToString();
                        nextresponse = "$OM_C_CSE_RSP=";
                    }
                    break;
                case states.setcontainer:
                case states.onem2mtc0205021:
                    // oneM2M container 생성 결과, 2001이면 성공
                    if (str2 == "2001")
                    {
                        endoneM2MTC("tc020502", string.Empty, string.Empty, string.Empty, str2);

                        this.sendDataOut(commands["settxcontainer"]);
                        nextresponse = "$OM_C_CON_RSP=";
                        if (lbActionState.Text == states.setcontainer.ToString())
                            lbActionState.Text = states.settxcontainer.ToString();
                        else
                            lbActionState.Text = states.onem2mtc0205022.ToString();
                    }
                    else if (str2 == "4105")
                    {
                        endoneM2MTC("tc020502", string.Empty, string.Empty, string.Empty, str2);
                        if (lbActionState.Text == states.setcontainer.ToString())
                        {
                            MessageBox.Show("동일한 폴더 이름이 있습니다.");
                            this.sendDataOut(commands["settxcontainer"]);
                            lbActionState.Text = states.settxcontainer.ToString();
                            nextresponse = "$OM_C_CON_RSP=";
                        }
                        else
                        {
                            this.sendDataOut(commands["settxcontainer"]);
                            nextresponse = "$OM_C_CON_RSP=";
                            lbActionState.Text = states.onem2mtc0205022.ToString();
                        }
                    }
                    else
                    {
                        endoneM2MTC("tc020502", string.Empty, "20000100", string.Empty, str2);

                        this.sendDataOut(commands["settxcontainer"]);
                        nextresponse = "$OM_C_CON_RSP=";
                        if (lbActionState.Text == states.onem2mtc0205021.ToString())
                            lbActionState.Text = states.onem2mtc0205022.ToString();
                    }
                    break;
                case states.onem2mset02:
                    // oneM2M container 생성 결과, 2001이면 성공
                    endoneM2MTC("tc020502", string.Empty, string.Empty, string.Empty, str2);

                    this.sendDataOut(commands["settxcontainer"]);
                    nextresponse = "$OM_C_CON_RSP=";
                    lbActionState.Text = states.onem2mset03.ToString();
                    break;
                case states.settxcontainer:
                case states.onem2mtc0205022:
                    if (lbActionState.Text == states.settxcontainer.ToString())
                        lbActionState.Text = states.idle.ToString();
                    else
                    {
                        startoneM2MTC("tc020503");
                        this.sendDataOut(commands["setsubscript"] + "StoD");
                        lbActionState.Text = states.onem2mtc0205031.ToString();
                        nextresponse = "$OM_C_SUB_RSP=";
                    }
                    break;
                case states.onem2mset03:
                    startoneM2MTC("tc020503");
                    this.sendDataOut(commands["setsubscript"] + "StoD");
                    lbActionState.Text = states.onem2mset04.ToString();
                    nextresponse = "$OM_C_SUB_RSP=";
                    break;
                case states.delcontainer:
                case states.onem2mtc0212031:
                    // oneM2M container 삭제 결과, 2002이면 성공
                    endoneM2MTC("tc021203", string.Empty, string.Empty, string.Empty, str2);
                    this.sendDataOut(commands["delcontainer"] + "DtoS");
                    if (lbActionState.Text == states.delcontainer.ToString())
                        lbActionState.Text = states.delcontainer2.ToString();
                    else
                        lbActionState.Text = states.onem2mtc0212032.ToString();
                    nextresponse = "$OM_D_CON_RSP=";
                    break;
                case states.delcontainer2:
                    lbActionState.Text = states.idle.ToString();
                    break;
                case states.onem2mtc0212032:
                    startoneM2MTC("tc021204");
                    this.sendDataOut(commands["delremoteCSE"]);
                    lbActionState.Text = states.onem2mtc0212042.ToString();
                    nextresponse = "$OM_D_CSE_RSP=";
                    break;
                case states.setsubscript:
                case states.onem2mtc0205031:
                case states.onem2mtc0205032:
                    // oneM2M subscription 신청 결과
                    if (str2 == "2001")
                        endoneM2MTC("tc020503", string.Empty, string.Empty, string.Empty, str2);
                    else if (str2 == "4105")
                    {
                        endoneM2MTC("tc020503", string.Empty, string.Empty, string.Empty, str2);
                        if (lbActionState.Text == states.setsubscript.ToString())
                            MessageBox.Show("이미 구독 신청이 되어 있습니다.");
                    }
                    else
                        endoneM2MTC("tc020503", string.Empty, "20000100", string.Empty, str2);

                    if (lbActionState.Text == states.setsubscript.ToString())
                        lbActionState.Text = states.idle.ToString();
                    else
                    {
                        this.sendDataOut(commands["updateremoteCSE"]);
                        lbActionState.Text = states.onem2mtc020505.ToString();
                        nextresponse = "$OM_U_CSE_RSP=";
                    }
                    break;
                case states.onem2mset04:
                    // oneM2M subscription 신청 결과
                    endoneM2MTC("tc020503", string.Empty, string.Empty, string.Empty, str2);

                    string kind = "type=onem2m";
                    kind += "&ctn=" + tbDeviceCTN.Text;
                    kind += "&from=" + tcStartTime.ToString("yyyyMMddHHmmss");
                    getSvrLoglists(kind, "auto");

                    lbActionState.Text = states.idle.ToString();
                    break;
                case states.delsubscript:
                case states.onem2mtc0212021:
                    endoneM2MTC("tc021202", string.Empty, string.Empty, string.Empty, str2);
                    if (lbActionState.Text == states.delsubscript.ToString())
                        lbActionState.Text = states.idle.ToString();
                    else
                    {
                        startoneM2MTC("tc020503");
                        this.sendDataOut(commands["setsubscript"] + "StoD");
                        lbActionState.Text = states.onem2mtc0205032.ToString();
                        nextresponse = "$OM_C_SUB_RSP=";
                    }
                    break;
                case states.onem2mtc0212022:
                    endoneM2MTC("tc021202", string.Empty, string.Empty, string.Empty, str2);
                    startoneM2MTC("tc021203");
                    this.sendDataOut(commands["delcontainer"] + "StoD");
                    lbActionState.Text = states.onem2mtc0212031.ToString();
                    nextresponse = "$OM_D_CON_RSP=";
                    break;
                case states.sendonemsgstr:
                    // 플랫폼 서버에 data 송신
                    rcvdatas = str2.Split(',');    // 수신한 데이터를 한 문장씩 나누어 array에 저장
                    if (rcvdatas[0] == "2001")
                    {
                        if (svr.enrmtKeyId != string.Empty)
                        {
                            lbActionState.Text = states.sendonemsgstrchk.ToString();
                            RetriveDataToPlatform();
                        }
                        else
                        {
                            endoneM2MTC("tc020504", string.Empty, string.Empty, string.Empty, string.Empty);
                            lbActionState.Text = states.idle.ToString();
                        }
                    }
                    else
                        lbActionState.Text = states.idle.ToString();
                    break;
                case states.onem2mtc0205041:
                    // 플랫폼 서버에 data 송신
                    rcvdatas = str2.Split(',');    // 수신한 데이터를 한 문장씩 나누어 array에 저장
                    if (rcvdatas[0] == "2001")
                    {
                        lbActionState.Text = states.onem2mtc0205042.ToString();
                        RetriveDataToPlatform();
                    }
                    else if (rcvdatas[0] == "4004")
                    {
                        this.sendDataOut(commands["setcontainer"]);
                        lbActionState.Text = states.onem2mtc0205021.ToString();
                        nextresponse = "$OM_C_CON_RSP=";
                    }
                    else
                    {
                        lbActionState.Text = states.onem2mtc0206011.ToString();
                        SendDataToPlatform();
                    }
                    break;
                case states.onem2mtc0205043:
                    // data 수신 시험을 위해 StoD 폴더에 송신
                    rcvdatas = str2.Split(',');    // 수신한 데이터를 한 문장씩 나누어 array에 저장
                    if (rcvdatas[0] == "4004")
                    {
                        this.sendDataOut(commands["setcontainer"]);
                        lbActionState.Text = states.onem2mtc0205021.ToString();
                        nextresponse = "$OM_C_CON_RSP=";
                    }
                    else
                    {
                        if (rcvdatas[0] == "2001")
                            endoneM2MTC("tc020504", string.Empty, string.Empty, string.Empty, string.Empty);
                        else
                            endoneM2MTC("tc020504", string.Empty, "20000100", string.Empty, str2);
                        lbActionState.Text = states.onem2mtc0206012.ToString();
                    }
                    break;
                case states.getonem2mdata:
                case states.sendonedevdb2:
                    // 플랫폼 서버에 data 수신
                    rcvdatas = str2.Split(',');    // 수신한 데이터를 한 문장씩 나누어 array에 저장
                    if (rcvdatas[0] == "2000")
                    {
                        // 수신한 데이터 사이즈 확이
                        int rxdatasize = Convert.ToInt32(rcvdatas[1]);
                        if (rxdatasize == rcvdatas[2].Length)
                        {
                            lboneM2MRcvData.Text = rcvdatas[2];
                            logPrintInTextBox(rcvdatas[2] + "를 수신하였습니다.", "");
                            if (lbActionState.Text == states.getonem2mdata.ToString())
                                endoneM2MTC("tc020701", string.Empty, string.Empty, string.Empty, string.Empty);
                            else if (lboneM2MRcvData.Text == label19.Text)
                                endoneM2MTC("tc020701", string.Empty, string.Empty, string.Empty, string.Empty);
                        }
                        else
                            MessageBox.Show("수신한 데이터 사이즈를 확인하세요", "");
                    }
                    lbActionState.Text = states.idle.ToString();
                    break;
                case states.onem2mtc0207011:
                case states.onem2mtc0207012:
                    rcvdatas = str2.Split(',');    // 수신한 데이터를 한 문장씩 나누어 array에 저장
                    if (rcvdatas[0] == "2000")
                    {
                        // 수신한 데이터 사이즈 확이
                        int rxdatasize = Convert.ToInt32(rcvdatas[1]);
                        if (rxdatasize == rcvdatas[2].Length)
                        {
                            lboneM2MRcvData.Text = rcvdatas[2];
                            logPrintInTextBox(rcvdatas[2] + "를 수신하였습니다.", "");
                            if (lbActionState.Text == states.onem2mtc0207012.ToString())
                                endoneM2MTC("tc020701", string.Empty, string.Empty, string.Empty, string.Empty);
                            else
                            {
                                if (lboneM2MRcvData.Text == label9.Text)
                                    endoneM2MTC("tc020701", string.Empty, string.Empty, string.Empty, string.Empty);
                                else
                                    endoneM2MTC("tc020701", string.Empty, "20000100", lboneM2MRcvData.Text, label9.Text);
                            }
                        }
                        else
                        {
                            endoneM2MTC("tc020701", string.Empty, "20000100", string.Empty, str2);
                        }
                    }
                    else
                        endoneM2MTC("tc020701", string.Empty, "20000100", string.Empty, str2);

                    if (checkBox4.Checked == true)
                    {
                        startoneM2MTC("tc020602");
                        // 플랫폼 서버에 data 수신 요청
                        this.sendDataOut(commands["setrcvauto"]);
                        lbActionState.Text = states.onem2mtc020602.ToString();
                    }
                    else
                    {
                        endoneM2MTC("tc020602", string.Empty, "20000200", string.Empty, string.Empty);
                        endoneM2MTC("tc020603", string.Empty, "20000200", string.Empty, string.Empty);
                        endoneM2MTC("tc020604", string.Empty, "20000200", string.Empty, string.Empty);
                        endoneM2MTC("tc021301", string.Empty, "20000200", string.Empty, string.Empty);
                        endoneM2MTC("tc021302", string.Empty, "20000200", string.Empty, string.Empty);
                        endoneM2MTC("tc021303", string.Empty, "20000200", string.Empty, string.Empty);
                        endoneM2MTC("tc021401", string.Empty, "20000200", string.Empty, string.Empty);

                        startoneM2MTC("tc020801");
                        this.sendDataOut(textBox60.Text);
                        lbActionState.Text = states.onem2mtc0208011.ToString();
                    }
                    break;
                case states.sendonemsgsvr:
                case states.onem2mtc021301:
                    // oneM2M data forwarding 요청 결과, 2001이면 
                    if (str2 == "2001")
                        endoneM2MTC("tc021301", string.Empty, string.Empty, string.Empty, string.Empty);
                    if (lbActionState.Text == states.sendonemsgsvr.ToString())
                        lbActionState.Text = states.idle.ToString();
                    else
                    {
                        startoneM2MTC("tc021302");
                        lbActionState.Text = states.onem2mtc021302.ToString();

                        rTh = new Thread(new ThreadStart(SendDataToOneM2M));
                        rTh.Start();
                    }
                    break;
                case states.deviceFWUPstart:
                case states.onem2mtc0210034:
                    oneM2Mtotalsize = Convert.ToUInt32(str2);
                    logPrintInTextBox("FOTA 이미지 크기는 " + str2 + "입니다.", "");
                    if (lbActionState.Text == states.deviceFWUPstart.ToString())
                        lbActionState.Text = states.deviceFWDLfinsh.ToString();
                    else
                        lbActionState.Text = states.onem2mtc0210035.ToString();
                    nextresponse = "$OM_DEV_FWDL_FINISH";
                    break;
                case states.deviceFWDownload:
                case states.onem2mtc0210031:
                    oneM2Mtotalsize = Convert.ToUInt32(str2);
                    logPrintInTextBox("FOTA 이미지 크기는 " + str2 + "입니다.", "");
                    if (lbActionState.Text == states.deviceFWDownload.ToString())
                        lbActionState.Text = states.deviceFWDownloading.ToString();
                    else
                        lbActionState.Text = states.onem2mtc0210032.ToString();
                    nextresponse = textBox76.Text;
                    break;
                case states.deviceFWDownloading:
                case states.onem2mtc0210032:
                    rcvdatas = str2.Split(',');    // 수신한 데이터를 한 문장씩 나누어 array에 저장
                    oneM2Mrcvsize += Convert.ToUInt32(rcvdatas[0]);
                    logPrintInTextBox("index= " + oneM2Mrcvsize + "/" + oneM2Mtotalsize + "를 수신하였습니다.", "");
                    if (rcvdatas[0] != "512" || oneM2Mrcvsize >= oneM2Mtotalsize)
                    {
                        if (oneM2Mrcvsize == oneM2Mtotalsize)
                            endoneM2MTC("tc021003", string.Empty, string.Empty, string.Empty, string.Empty);
                        else
                            endoneM2MTC("tc021003", string.Empty, "20000100", oneM2Mrcvsize.ToString(), oneM2Mtotalsize.ToString());

                        if (lbActionState.Text == states.deviceFWDownloading.ToString())
                            lbActionState.Text = states.deviceFWDLfinsh.ToString();
                        else
                            lbActionState.Text = states.onem2mtc0210033.ToString();
                        nextresponse = "$OM_DEV_FWDL_FINISH";
                    }
                    else
                    {
                        nextresponse = textBox76.Text;
                    }
                    break;
                case states.deviceFWDLfinsh:
                    if (dev.model == "EC25" || dev.model == "EC21")               //쿼텔/oneM2M 모듈
                    {
                        logPrintInTextBox("수신한 데이터를 읽기 시작합다.", "");

                        this.sendDataOut(commands["deviceFWList"]);
                        lbActionState.Text = states.deviceFWList.ToString();
                        nextresponse = "+QFLST: ";
                    }
                    else
                    {
                        if (oneM2Mrcvsize == oneM2Mtotalsize)
                            endoneM2MTC("tc021003", string.Empty, string.Empty, string.Empty, string.Empty);
                        else
                            endoneM2MTC("tc021003", string.Empty, "20000100", oneM2Mrcvsize.ToString(), oneM2Mtotalsize.ToString());

                        startoneM2MTC("tc021004");
                        // 디바이스 펌웨어 버전 등록을 위해 플랫폼 서버 MEF AUTH 요청
                        this.sendDataOut(commands["setmefauth"] + tbSvcCd.Text + "," + tBoxDeviceModel.Text + "," + tBoxDeviceVer.Text + "," + tBoxDeviceSN.Text);
                        lbActionState.Text = states.fotamefauthnt.ToString();
                        nextresponse = "$OM_AUTH_RSP=";
                    }
                    break;
                case states.onem2mtc0210035:
                    logPrintInTextBox("수신한 데이터를 읽기 시작합다.", "");

                    this.sendDataOut(commands["deviceFWList"]);
                    lbActionState.Text = states.onem2mtc0210036.ToString();
                    nextresponse = "+QFLST: ";
                    break;
                case states.onem2mtc0210033:
                    startoneM2MTC("tc021004");
                    // 디바이스 펌웨어 버전 등록을 위해 플랫폼 서버 MEF AUTH 요청
                    this.sendDataOut(commands["setmefauth"] + tbSvcCd.Text + "," + tBoxDeviceModel.Text + "," + tBoxDeviceVer.Text + "," + tBoxDeviceSN.Text);
                    lbActionState.Text = states.onem2mtc0210041.ToString();
                    nextresponse = "$OM_AUTH_RSP=";
                    break;
                case states.deviceFWList:
                case states.onem2mtc0210036:
                    rcvdatas = str2.Split(',');    // 수신한 데이터를 한 문장씩 나누어 array에 저장

                    if (oneM2Mtotalsize == Convert.ToUInt32(rcvdatas[1]))
                    {
                        nextcmdexts = rcvdatas[0];
                        if (lbActionState.Text == states.deviceFWList.ToString())
                            nextcommand = states.deviceFWOpen.ToString();
                        else
                            nextcommand = states.onem2mtc0210037.ToString();
                    }
                    break;
                case states.deviceFWOpen:
                case states.onem2mtc0210037:
                    filecode = str2;
                    nextcmdexts = filecode + ",512";
                    if (lbActionState.Text == states.deviceFWOpen.ToString())
                        nextcommand = states.deviceFWRead.ToString();
                    else
                        nextcommand = states.onem2mtc0210038.ToString();
                    break;
                case states.deviceFWRead:
                case states.onem2mtc0210038:
                    oneM2Mrcvsize += Convert.ToUInt32(str2);
                    logPrintInTextBox("index= " + oneM2Mrcvsize + "/" + oneM2Mtotalsize + "를 수신하였습니다.", "");
                    if (str2 != "512" || oneM2Mrcvsize >= oneM2Mtotalsize)
                    {
                        if (oneM2Mrcvsize == oneM2Mtotalsize)
                            endoneM2MTC("tc021003", string.Empty, string.Empty, string.Empty, string.Empty);
                        else
                            endoneM2MTC("tc021003", string.Empty, "20000100", oneM2Mrcvsize.ToString(), oneM2Mtotalsize.ToString());

                        nextcmdexts = filecode;
                        if (lbActionState.Text == states.deviceFWRead.ToString())
                            nextcommand = states.deviceFWClose.ToString();
                        else
                            nextcommand = states.onem2mtc0210039.ToString();
                    }
                    else
                    {
                        nextcmdexts = filecode + ",512";
                        if (lbActionState.Text == states.deviceFWRead.ToString())
                            nextcommand = states.deviceFWRead.ToString();
                        else
                            nextcommand = states.onem2mtc0210038.ToString();
                    }
                    break;
                case states.modemFWUPstart:
                case states.onem2mtc0211031:
                    startoneM2MTC("tc021103");
                    logPrintInTextBox("MODEM FOTA 다운로드 완료되었습니다.", "");
                    if (lbActionState.Text == states.modemFWUPstart.ToString())
                        lbActionState.Text = states.modemFWUPfinish.ToString();
                    else
                        lbActionState.Text = states.onem2mtc0211032.ToString();
                    nextresponse = textBox72.Text;
                    break;
                case states.modemFWUPfinish:
                case states.onem2mtc0211032:
                    endoneM2MTC("tc021103", string.Empty, string.Empty, string.Empty, string.Empty);

                    //doCloseComPort();
                    //doOpenComPort();

                    logPrintInTextBox("MODEM 업데이트가 완료되었습니다.", "");
                    if (lbActionState.Text == states.modemFWUPfinish.ToString())
                    {
                        this.sendDataOut(commands["getonem2mmode"]);
                        lbActionState.Text = states.modemFWUPmodechk.ToString();
                        nextresponse = "$LGTMPF=";
                    }
                    else
                    {
                        lbActionState.Text = states.onem2mtc0211033.ToString();
                        timer2.Interval = 10000;
                        timer2.Start();
                    }
                    break;
                case states.setACP:
                case states.onem2mtc0209011:
                    if (str2 == "2001")
                    {
                        endoneM2MTC("tc020901", string.Empty, string.Empty, string.Empty, string.Empty);
                        if (lbActionState.Text == states.setACP.ToString())
                            lbActionState.Text = states.idle.ToString();
                        else
                        {
                            startoneM2MTC("tc020902");
                            this.sendDataOut(commands["getACP"]);
                            lbActionState.Text = states.onem2mtc020902.ToString();
                            nextresponse = "$OM_R_ACP_RSP=";
                        }
                    }
                    else if (str2 == "4105")
                    {
                        if (lbActionState.Text == states.setACP.ToString())
                        {
                            MessageBox.Show("ACP가 설정되어 있습니다.");
                            lbActionState.Text = states.idle.ToString();
                        }
                        else
                        {
                            startoneM2MTC("tc020904");
                            this.sendDataOut(commands["delACP"]);
                            lbActionState.Text = states.onem2mtc0209041.ToString();
                            nextresponse = "$OM_D_ACP_RSP=";
                        }
                    }
                    break;
                case states.getACP:
                case states.onem2mtc020902:
                    rcvdatas = str2.Split(',');    // 수신한 데이터를 한 문장씩 나누어 array에 저장
                    if (rcvdatas[0] == "2000")
                    {
                        endoneM2MTC("tc020902", string.Empty, string.Empty, string.Empty, string.Empty);
                        if (lbActionState.Text == states.getACP.ToString())
                            lbActionState.Text = states.idle.ToString();
                        else
                        {
                            startoneM2MTC("tc020903");
                            this.sendDataOut(commands["updateACP"]);
                            lbActionState.Text = states.onem2mtc020903.ToString();
                            nextresponse = "$OM_U_ACP_RSP=";
                        }
                    }
                    else if (rcvdatas[0] == "4004")     
                    {
                        if (lbActionState.Text == states.getACP.ToString())
                        {
                            MessageBox.Show("ACP가 설정되어 있지 않습니다.");
                            lbActionState.Text = states.idle.ToString();
                        }
                        else
                        {
                            startoneM2MTC("tc020901");
                            this.sendDataOut(commands["setACP"]);
                            lbActionState.Text = states.onem2mtc0209011.ToString();
                            nextresponse = "$OM_C_ACP_RSP=";
                        }
                    }
                    break;
                case states.updateACP:
                case states.onem2mtc020903:
                    if (str2 == "2004" || str2 == "2000")
                        endoneM2MTC("tc020903", string.Empty, string.Empty, string.Empty, str2);
                    else
                        endoneM2MTC("tc020903", string.Empty, "20000100", string.Empty, str2);
                    if (lbActionState.Text == states.updateACP.ToString())
                        lbActionState.Text = states.idle.ToString();
                    else
                    {
                        startoneM2MTC("tc020904");
                        this.sendDataOut(commands["delACP"]);
                        lbActionState.Text = states.onem2mtc0209042.ToString();
                        nextresponse = "$OM_D_ACP_RSP=";
                    }
                    break;
                case states.delACP:
                case states.onem2mtc0209042:
                    if (str2 == "2002" || str2 == "2000")
                        endoneM2MTC("tc020904", string.Empty, string.Empty, string.Empty, str2);
                    else
                        endoneM2MTC("tc020904", string.Empty, "20000100", string.Empty, str2);
                    if (lbActionState.Text == states.delACP.ToString())
                        lbActionState.Text = states.idle.ToString();
                    else
                    {
                        startoneM2MTC("tc021001");
                        this.sendDataOut(commands["getdeviceSvrVer"]);
                        lbActionState.Text = states.onem2mtc021001.ToString();
                        nextresponse = "$OM_DEV_FWUP_RSP=";
                    }
                    break;
                case states.onem2mtc0209041:
                    startoneM2MTC("tc020901");
                    this.sendDataOut(commands["setACP"]);
                    lbActionState.Text = states.onem2mtc0209011.ToString();
                    nextresponse = "$OM_C_ACP_RSP=";
                    break;
                case states.resetmefauth:
                    // oneM2M 인증 결과
                    if (str2 == "2000")
                    {
                        this.sendDataOut(commands["resetreport"]);
                        lbActionState.Text = states.resetreport.ToString();
                        nextresponse = "$OM_RESET_FINISH=";
                    }
                    else
                        lbActionState.Text = states.idle.ToString();
                    break;
                case states.resetreport:
                    if (str2 == "2004" || str2 == "2000")
                        endoneM2MTC("tc021401", string.Empty, string.Empty, string.Empty, string.Empty);
                    else
                        endoneM2MTC("tc021401", string.Empty, "20000100", string.Empty, str2);
                    lbActionState.Text = states.idle.ToString();
                    break;
                case states.resetreceived:
                    startoneM2MTC("tc021401");
                    logPrintInTextBox("MODEM 재부팅이 완료되었습니다.", "");
                    lbActionState.Text = states.resetboot.ToString();
                    timer2.Interval = 10000;
                    timer2.Start();
                    break;
                case states.onem2mtc0208012:
                    if (checkBox4.Checked == true)                          //쿼텔/oneM2M 모듈
                    {
                        startoneM2MTC("tc021301");
                        // Data send to SERVER (string original)
                        //AT$OM_C_INS_REQ=<server id>,<object>,<length>,<data>
                        txData = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") + " oneM2M device";
                        this.sendDataOut(commands["sendonemsgsvr"] + svr.entityId + "," + "TEST" + "," + txData.Length + "," + txData);
                        lbSendedData.Text = txData;
                        lbActionState.Text = states.onem2mtc021301.ToString();
                    }
                    else
                    {
                        startoneM2MTC("tc020901");
                        this.sendDataOut(commands["setACP"]);
                        lbActionState.Text = states.onem2mtc0209011.ToString();
                        nextresponse = "$OM_C_ACP_RSP=";
                    }
                    break;
                case states.lwm2mtc02011:
                    logPrintInTextBox("boot complete.", "");
                    if (lbActionState.Text == states.lwm2mtc02011.ToString())
                    {
                        lbActionState.Text = states.lwm2mtc02012.ToString();

                        timer2.Interval = 10000;
                        timer2.Start();
                    }
                    break;
                case states.deregistertpb23:
                case states.lwm2mtc0401:
                    endLwM2MTC("tc0401", string.Empty, string.Empty, string.Empty, string.Empty);
                    logPrintInTextBox("deregistration completed", " ");

                    if (lbActionState.Text == states.lwm2mtc0401.ToString())
                    {
                        this.sendDataOut(textBox54.Text);       // fota push test를 위해 register 요청

                        Thread.Sleep(10000);
                        GetPlatformFWVer("NO");

                        string logkind = "type=lwm2m&ctn=" + tbDeviceCTN.Text;
                        logkind += "&from=" + tcStartTime.ToString("yyyyMMddHHmmss");

                        getSvrLoglists(logkind, "auto");
                        logPrintInTextBox("전체 시험 완료.", "");
                    }
                    else
                        lbActionState.Text = states.idle.ToString();
                    break;
                case states.lwm2mtc06034:
                    txData = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") + " LwM2M device";
                    lbDevLwM2MData.Text = txData;

                    if (checkBox8.Checked == true)
                    {
                        string hexOutput = StringToBCD(txData.ToCharArray());

                        this.sendDataOut(textBox53.Text + hexOutput.Length / 2 + "," + hexOutput);
                    }
                    else
                        this.sendDataOut(textBox53.Text + txData.Length + "," + txData);
                    startLwM2MTC("tc0501", string.Empty, string.Empty, string.Empty, textBox53.Text);
                    lbActionState.Text = states.lwm2mtc06034.ToString();
                    nextcommand = states.lwm2mtc0501.ToString();
                    break;
                default:
                    lbActionState.Text = states.idle.ToString();
                    break;
            }

            if (lbActionState.Text == states.idle.ToString())
                nextresponse = string.Empty;
        }

        private void OKReceived()
        {
            string txData = string.Empty;

            states state = (states)Enum.Parse(typeof(states), lbActionState.Text);
            switch (state)
            {
                case states.deviceFWClose:
                case states.onem2mtc0210039:
                    startoneM2MTC("tc021004");
                    // 디바이스 펌웨어 버전 등록을 위해 플랫폼 서버 MEF AUTH 요청
                    this.sendDataOut(commands["setmefauth"] + tbSvcCd.Text + "," + tBoxDeviceModel.Text + "," + tBoxDeviceVer.Text + "," + tBoxDeviceSN.Text);
                    if (lbActionState.Text == states.deviceFWClose.ToString())
                        lbActionState.Text = states.fotamefauthnt.ToString();
                    else
                        lbActionState.Text = states.onem2mtc0210041.ToString();
                    nextresponse = "$OM_AUTH_RSP=";
                    break;
                case states.modemFWUPboot:
                case states.modemFWUPmodechk:               // $$LGTMPF= 응답 없이 OK가 응답된 경우 예외처리를 위해
                    this.sendDataOut(commands["getonem2mmode"]);
                    lbActionState.Text = states.modemFWUPmodechk.ToString();
                    nextresponse = "$LGTMPF=";
                    break;
                case states.onem2mtc0211040:
                    this.sendDataOut(commands["getonem2mmode"]);
                    lbActionState.Text = states.onem2mtc0211034.ToString();
                    nextresponse = "$LGTMPF=";
                    break;
                case states.resetmodechk:
                    this.sendDataOut(commands["getonem2mmode"]);
                    lbActionState.Text = states.resetmodechk.ToString();
                    nextresponse = "$LGTMPF=";
                    break;
                case states.onem2mtc0211034:
                    this.sendDataOut(commands["getonem2mmode"]);
                    lbActionState.Text = states.onem2mtc0211034.ToString();
                    nextresponse = "$LGTMPF=";
                    break;
                case states.setrcvauto:
                case states.onem2mtc020602:
                    endoneM2MTC("tc020602", string.Empty, string.Empty, string.Empty, string.Empty);

                    if (lbActionState.Text == states.setrcvauto.ToString())
                        lbActionState.Text = states.idle.ToString();
                    else
                    {
                        startoneM2MTC("tc020603");

                        if (svr.enrmtKeyId != string.Empty)
                        {
                            lbActionState.Text = states.onem2mtc0206031.ToString();
                            SendDataToPlatform();
                            nextcommand = string.Empty;
                        }
                        else
                        {
                            lbActionState.Text = states.onem2mtc0206032.ToString();
                            txData = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") + " oneM2M device";
                            this.sendDataOut(commands["sendonemsgstr"] + "StoD" + "," + txData.Length + "," + txData);
                            lbSendedData.Text = txData;
                        }
                    }
                    break;
                case states.setrcvmanu:
                    endoneM2MTC("tc020604", string.Empty, string.Empty, string.Empty, string.Empty);
                    nextcommand = string.Empty;
                    break;
                case states.onem2mtc0206041:        // 자동수신 이벤트를 먼저받아서 수동 수신 모드로 설정 송신 시험부터 재시험
                    endoneM2MTC("tc020604", string.Empty, string.Empty, string.Empty, string.Empty);

                    startoneM2MTC("tc020504");
                    // Data send to SERVER (string original)
                    //AT$OM_C_INS_REQ=<object>,<length>,<data>
                    txData = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") + " oneM2M device";
                    if (svr.enrmtKeyId != string.Empty)
                    {
                        lbActionState.Text = states.onem2mtc0205041.ToString();
                        this.sendDataOut(commands["sendonemsgstr"] + "DtoS" + "," + txData.Length + "," + txData);
                    }
                    else
                    {
                        lbActionState.Text = states.onem2mtc0205043.ToString();
                        this.sendDataOut(commands["sendonemsgstr"] + "StoD" + "," + txData.Length + "," + txData);
                    }
                    nextresponse = "$OM_C_INS_RSP=";
                    lbSendedData.Text = txData;
                    break;
                case states.onem2mtc0206042:        // 수동 수신 모드 설정 후 데이터 수신 시험 진행
                    endoneM2MTC("tc020604", string.Empty, string.Empty, string.Empty, string.Empty);

                    startoneM2MTC("tc020801");
                    this.sendDataOut(textBox60.Text);
                    lbActionState.Text = states.onem2mtc0208011.ToString();
                    break;
                case states.onem2mtc0201011:
                    //AT$OM_SVR_INFO=<svr>,<ip>,<port>
                    this.sendDataOut(commands["sethttpserverinfo"] + oneM2MBRKIP + "," + oneM2MBRKPort);
                    lbActionState.Text = states.onem2mtc0201012.ToString();
                    break;
                case states.onem2mtc0201012:
                    if (checkBox1.Checked == true)
                    {
                        //AT$OM_SVR_INFO=<svr>,<ip>,<port>
                        this.sendDataOut(commands["setfotaserverinfo"] + oneM2MFOTAIP + "," + oneM2MFOTAPort);
                        lbActionState.Text = states.onem2mtc0201013.ToString();
                    }
                    else
                    {
                        this.sendDataOut(commands["getserverinfo"]);
                        lbActionState.Text = states.onem2mtc0201014.ToString();
                        nextresponse = "$OM_SVR_INFO=";
                    }
                    break;
                case states.onem2mtc0201013:
                    this.sendDataOut(commands["getserverinfo"]);
                    lbActionState.Text = states.onem2mtc0201014.ToString();
                    nextresponse = "$OM_SVR_INFO=";
                    break;
                case states.onem2mtc0201022:
                    this.sendDataOut(commands["getonem2mmode"]);
                    lbActionState.Text = states.onem2mtc0201023.ToString();
                    nextresponse = "$LGTMPF=";
                    break;
                case states.onem2mtc0208011:
                    this.sendDataOut(textBox59.Text);
                    lbActionState.Text = states.onem2mtc0208012.ToString();
                    nextresponse = "$OM_POA_NOTI=";
                    break;
                case states.setncdp:
                    if (textBox75.Text != string.Empty)
                    {
                        this.sendDataOut(textBox75.Text);
                        lbActionState.Text = states.autosetsvripbc95.ToString();
                    }
                    else
                        lbActionState.Text = states.idle.ToString();
                    break;
                case states.autosetsvripbc95:
                    lbActionState.Text = states.idle.ToString();
                    break;
                case states.lwm2mtc02023:
                    if (textBox75.Text != string.Empty)
                    {
                        this.sendDataOut(textBox75.Text);
                        lbActionState.Text = states.lwm2mtc02024.ToString();
                    }
                    else
                    {
                        // LWM2M bootstrap 자동 요청 순서 (V150)
                        // (setncdp) - (setepnstpb23) - setmbspstpb23 - bootstrapmodetpb23 - bootstraptpb23
                        // End Point Name Parameter 설정
                        //AT+MLWEPNS="LWM2M 서버 entityID"
                        setDeviceEntityID();
                        if (checkBox6.Checked == true)
                        {
                            if (checkBox7.Checked == true)
                            {
                                if (checkBox2.Checked == false)
                                    this.sendDataOut(textBox50.Text + "\"" + dev.entityId + "\"" + ",\"" + dev.entityId + "\"");
                                else
                                    this.sendDataOut(textBox50.Text + "\"" + tbSvcCd.Text + "\"" + ",\"" + tbSvcCd.Text + "\"");
                            }
                            else
                            {
                                if (checkBox2.Checked == false)
                                    this.sendDataOut(textBox50.Text + "\"" + dev.entityId + "\"");
                                else
                                    this.sendDataOut(textBox50.Text + "\"" + tbSvcCd.Text + "\"");
                            }
                        }
                        else
                        {
                            if (checkBox2.Checked == false)
                                this.sendDataOut(textBox50.Text + dev.entityId);
                            else
                                this.sendDataOut(textBox50.Text + tbSvcCd.Text);
                        }
                        startLwM2MTC("tc0202", string.Empty, string.Empty, string.Empty, textBox50.Text);
                        lbActionState.Text = states.lwm2mtc02025.ToString();
                    }
                    break;
                case states.lwm2mtc02024:
                    setDeviceEntityID();
                    if (checkBox6.Checked == true)
                    {
                        if (checkBox7.Checked == true)
                        {
                            if (checkBox2.Checked == false)
                                this.sendDataOut(textBox50.Text + "\"" + dev.entityId + "\"" + ",\"" + dev.entityId + "\"");
                            else
                                this.sendDataOut(textBox50.Text + "\"" + tbSvcCd.Text + "\"" + ",\"" + tbSvcCd.Text + "\"");
                        }
                        else
                        {
                            if (checkBox2.Checked == false)
                                this.sendDataOut(textBox50.Text + "\"" + dev.entityId + "\"");
                            else
                                this.sendDataOut(textBox50.Text + "\"" + tbSvcCd.Text + "\"");
                        }
                    }
                    else
                    {
                        if (checkBox2.Checked == false)
                            this.sendDataOut(textBox50.Text + dev.entityId);
                        else
                            this.sendDataOut(textBox50.Text + tbSvcCd.Text);
                    }
                    startLwM2MTC("tc0202", string.Empty, string.Empty, string.Empty, textBox50.Text);
                    lbActionState.Text = states.lwm2mtc02025.ToString();
                    break;
                case states.setepnstpb23:
                    lbActionState.Text = states.idle.ToString();
                    break;
                case states.lwm2mtc02025:
                    string epncmd = string.Empty;
                    string epniccid = dev.iccid;

                    if (comboBox4.SelectedIndex == 0)
                    {
                        //AT+MLWMBSPS="serviceCode=GAMR|deviceSerialNo=1234567|ctn=01022335078 | iccId = 127313 | deviceModel = Summer | mac = "
                        epncmd = "serviceCode=" + tbSvcCd.Text + "|deviceSerialNo=";
                        epncmd += tBoxDeviceSN.Text + "|ctn=";
                        epncmd += dev.imsi + "|iccId=";

                        string iccid = dev.iccid;
                        epncmd += epniccid.Substring(epniccid.Length - 6, 6) + "|deviceModel=";
                        epncmd += tBoxDeviceModel.Text + "|mac=";
                    }
                    else
                    {
                        //AT+QLWMBSPS=<service code>,<sn>,<ctn>,<iccid>,<device model>
                        epncmd = "\"" + tbSvcCd.Text + "\",\"";
                        epncmd += tBoxDeviceSN.Text + "\",\"";
                        epncmd += dev.imsi + "\",\"";

                        epncmd += epniccid.Substring(epniccid.Length - 6, 6) + "\",\"";
                        epncmd += tBoxDeviceModel.Text + "\"";
                    }

                    this.sendDataOut(textBox55.Text + epncmd);
                    startLwM2MTC("tc0202", string.Empty, string.Empty, string.Empty, textBox55.Text);
                    lbActionState.Text = states.lwm2mtc02026.ToString();
                    break;
                case states.setmbspstpb23:
                    lbActionState.Text = states.idle.ToString();
                    break;
                case states.lwm2mtc02026:
                    if (textBox66.Text != string.Empty)
                    {
                        // LWM2M bootstrap 자동 요청 순서 (V150)
                        // setncdp - setepnstpb23 - (setmbspstpb23) - (bootstrapmodetpb23) - bootstraptpb23
                        // LWM2M 서버 설정
                        // BOOTSTARP MODE 설정
                        //AT+MBOOTSTRAPMODE=1
                        this.sendDataOut(textBox66.Text);
                        startLwM2MTC("tc0202", string.Empty, string.Empty, string.Empty, textBox66.Text);
                        lbActionState.Text = states.lwm2mtc02027.ToString();
                    }
                    else
                    {
                        // LWM2M bootstrap 자동 요청 순서 (V150)
                        // setncdp - setepnstpb23 - setmbspstpb23 - (bootstrapmodetpb23) - (bootstraptpb23)
                        // LWM2M서버에 Bootstarp 요청
                        //  AT+MLWGOBOOTSTRAP=1
                        this.sendDataOut(textBox67.Text);
                        startLwM2MTC("tc0202", string.Empty, string.Empty, string.Empty, textBox67.Text);
                        lbActionState.Text = states.lwm2mtc02029.ToString();
                    }
                    break;
                case states.bootstrapmodetpb23:
                    if (textBox77.Text != string.Empty)
                    {
                        this.sendDataOut(textBox77.Text);
                        lbActionState.Text = states.bootstrapbc95.ToString();
                    }
                    else
                        lbActionState.Text = states.idle.ToString();
                    break;
                case states.lwm2mtc02027:
                    if (textBox77.Text != string.Empty)
                    {
                        this.sendDataOut(textBox77.Text);
                        lbActionState.Text = states.lwm2mtc02028.ToString();
                    }
                    else
                    {
                        // LWM2M bootstrap 자동 요청 순서 (V150)
                        // setncdp - setepnstpb23 - setmbspstpb23 - (bootstrapmodetpb23) - (bootstraptpb23)
                        // LWM2M서버에 Bootstarp 요청
                        //  AT+MLWGOBOOTSTRAP=1
                        this.sendDataOut(textBox67.Text);
                        startLwM2MTC("tc0202", string.Empty, string.Empty, string.Empty, textBox67.Text);
                        lbActionState.Text = states.lwm2mtc02029.ToString();
                    }
                    break;
                case states.bootstrapbc95:
                    lbActionState.Text = states.idle.ToString();
                    break;
                case states.lwm2mtc02028:
                    // LWM2M bootstrap 자동 요청 순서 (V150)
                    // setncdp - setepnstpb23 - setmbspstpb23 - (bootstrapmodetpb23) - (bootstraptpb23)
                    // LWM2M서버에 Bootstarp 요청
                    //  AT+MLWGOBOOTSTRAP=1
                    this.sendDataOut(textBox67.Text);
                    startLwM2MTC("tc0202", string.Empty, string.Empty, string.Empty, textBox67.Text);
                    lbActionState.Text = states.lwm2mtc02029.ToString();
                    break;
                case states.sendmsghex:
                    endLwM2MTC("tc0501", string.Empty, string.Empty, string.Empty, string.Empty);
                    lbActionState.Text = states.idle.ToString();
                    break;
                case states.lwm2mtc06031:
                    lbActionState.Text = states.lwm2mtc06032.ToString();
                    timer2.Interval = 10000;
                    timer2.Start();
                    break;
                case states.resetmodeseted:
                    this.sendDataOut(commands["getonem2mmode"]);
                    lbActionState.Text = states.resetmodechk.ToString();
                    nextresponse = "$LGTMPF=";
                    break;
                case states.lwm2mresetbc95:
                    if (textBox74.Text != string.Empty)
                    {
                        this.sendDataOut(textBox74.Text);
                        lbActionState.Text = states.holdoffbc95.ToString();
                    }
                    else
                        lbActionState.Text = states.idle.ToString();
                    break;
                case states.lwm2mtc02021:
                    if (textBox74.Text != string.Empty)
                    {
                        this.sendDataOut(textBox74.Text);
                        lbActionState.Text = states.lwm2mtc02022.ToString();
                    }
                    else
                    {
                        this.sendDataOut(textBox56.Text);
                        lbActionState.Text = states.lwm2mtc02023.ToString();
                    }
                    break;
                case states.lwm2mtc02022:
                    this.sendDataOut(textBox56.Text);
                    lbActionState.Text = states.lwm2mtc02023.ToString();
                    break;
                case states.holdoffbc95:
                    lbActionState.Text = states.idle.ToString();
                    break;
                default:
                    break;
            }

            // 마지막 응답(OK)을 받은 후에 후속 작업이 필요한지 확인한다.
            if (nextcommand != string.Empty)
            {
                states nextstate = (states)Enum.Parse(typeof(states), nextcommand);
                switch (nextstate)
                {
                    // 단말 정보 자동 갱신 순서
                    // autogetmanufac - (autogetmodel) - autogetimei - autogetmodemver
                    case states.autogetmodel:
                        this.sendDataOut(textBox47.Text);
                        lbActionState.Text = states.autogetmodel.ToString();
                        break;
                    // 단말 정보 자동 갱신 순서
                    // autogetmanufac - autogetmodel - (autogetimei) - autogetmodemver
                    case states.autogetimei:
                        this.sendDataOut(textBox49.Text);
                        nextresponse = textBox40.Text;
                        lbActionState.Text = states.autogetimei.ToString();
                        break;
                    // 단말 정보 자동 갱신 순서
                    // autogetmanufac - autogetmodel - autogetimei - (autogetmodemver)
                    case states.autogetmodemver:
                        this.sendDataOut(textBox44.Text);
                        nextresponse = textBox57.Text;
                        lbActionState.Text = states.autogetmodemver.ToString();
                        break;
                    // 단말 정보 자동 갱신 순서
                    // autogetmanufac - autogetmodel - autogetimei - autogetmodemver - (autoimsi)
                    case states.autogetimsi:

                        this.sendDataOut(textBox46.Text);
                        nextresponse = textBox33.Text;
                        lbActionState.Text = states.autogetimsi.ToString();
                        break;
                    case states.autogeticcid:
                        this.sendDataOut(textBox45.Text);
                        nextresponse = textBox38.Text;
                        lbActionState.Text = states.autogeticcid.ToString();
                        break;
                    case states.lwm2mtc02025:
                        // LWM2M bootstrap 자동 요청 순서 (V150)
                        // (setncdp) - (setepnstpb23) - setmbspstpb23 - bootstrapmodetpb23 - bootstraptpb23
                        // End Point Name Parameter 설정
                        //AT+MLWEPNS="LWM2M 서버 entityID"
                        setDeviceEntityID();
                        string atcmd = textBox50.Text;
                        if (checkBox2.Checked == false)
                            atcmd += dev.entityId;
                        else
                            atcmd += tbSvcCd.Text;
                        this.sendDataOut(atcmd);
                        lbActionState.Text = states.lwm2mtc02026.ToString();
                        break;
                    case states.deviceFWOpen:
                    case states.onem2mtc0210037:
                        this.sendDataOut(commands["deviceFWOpen"] + nextcmdexts);
                        if (nextstate == states.deviceFWOpen)
                            lbActionState.Text = states.deviceFWOpen.ToString();
                        else
                            lbActionState.Text = states.onem2mtc0210037.ToString();
                        nextresponse = "+QFOPEN: ";
                        nextcmdexts = string.Empty;
                        break;
                    case states.deviceFWRead:
                    case states.onem2mtc0210038:
                        this.sendDataOut(commands["deviceFWRead"] + nextcmdexts);
                        if (nextstate == states.deviceFWRead)
                            lbActionState.Text = states.deviceFWRead.ToString();
                        else
                            lbActionState.Text = states.onem2mtc0210038.ToString();
                        nextresponse = "CONNECT ";
                        nextcmdexts = string.Empty;
                        break;
                    case states.deviceFWClose:
                    case states.onem2mtc0210039:
                        this.sendDataOut(commands["deviceFWClose"] + nextcmdexts);
                        if (nextstate == states.deviceFWClose)
                            lbActionState.Text = states.deviceFWClose.ToString();
                        else
                            lbActionState.Text = states.onem2mtc0210039.ToString();
                        nextcmdexts = string.Empty;
                        break;
                    case states.modemFWUPboot:
                    case states.onem2mtc0211040:
                        this.sendDataOut(commands["setonem2mmode"]);
                        if (nextstate == states.modemFWUPboot)
                            lbActionState.Text = states.modemFWUPboot.ToString();
                        else
                            lbActionState.Text = states.onem2mtc0211040.ToString();
                        nextresponse = "$LGTMPF=";
                        break;
                    case states.modemFWUPmodeset:
                    case states.onem2mtc0211041:
                        // 디바이스 펌웨어 버전 등록을 위해 플랫폼 서버 MEF AUTH 요청
                        this.sendDataOut(commands["setmefauth"] + tbSvcCd.Text + "," + tBoxDeviceModel.Text + "," + tBoxDeviceVer.Text + "," + tBoxDeviceSN.Text);
                        if (nextstate == states.modemFWUPmodeset)
                            lbActionState.Text = states.mfotamefauth.ToString();
                        else
                            lbActionState.Text = states.onem2mtc0211042.ToString();
                        nextresponse = "$OM_AUTH_RSP=";
                        break;
                    case states.onem2mtc0201022:
                        startoneM2MTC("tc020102");
                        this.sendDataOut(commands["setonem2mmode"]);
                        lbActionState.Text = states.onem2mtc0201022.ToString();
                        break;
                    case states.onem2mtc0202011:
                        startoneM2MTC("tc020201");
                        this.sendDataOut(commands["setmefauth"] + tbSvcCd.Text + "," + tBoxDeviceModel.Text + "," + tBoxDeviceVer.Text + "," + tBoxDeviceSN.Text);
                        lbActionState.Text = states.onem2mtc0202012.ToString();
                        nextresponse = "$OM_AUTH_RSP=";
                        break;
                    case states.lwm2mtc0501:
                        endLwM2MTC("tc0501", string.Empty, string.Empty, string.Empty, string.Empty);

                        if (svr.enrmtKeyId != string.Empty)
                        {
                            startLwM2MTC("tc0502", string.Empty, string.Empty, string.Empty, string.Empty);
                            lbActionState.Text = states.lwm2mtc0502.ToString();
                            string[] param = { "lwm2m", "tc0502" };
                            rTh = new Thread(new ParameterizedThreadStart(SendDataToLwM2M));
                            rTh.Start(param);
                        }
                        else
                        {       // Service server 설정이 안되어 있으면 deregister  송신
                            this.sendDataOut(textBox52.Text);
                            startLwM2MTC("tc0401", string.Empty, string.Empty, string.Empty, textBox52.Text);
                            lbActionState.Text = states.lwm2mtc0401.ToString();
                            if (dev.model.StartsWith("BG95"))
                                nextresponse = "+QLWDEREG: 0";
                        }
                        break;
                    case states.resetmodeset:
                        this.sendDataOut(commands["setonem2mmode"]);
                        lbActionState.Text = states.resetmodeseted.ToString();
                        break;
                    case states.resetmefauth:

                        // RESET 상태 등록을 위해 플랫폼 서버 MEF AUTH 요청
                        this.sendDataOut(commands["setmefauth"] + tbSvcCd.Text + "," + tBoxDeviceModel.Text + "," + tBoxDeviceVer.Text + "," + tBoxDeviceSN.Text);
                        lbActionState.Text = states.resetmefauth.ToString();
                        nextresponse = "$OM_AUTH_RSP=";
                        break;
                    default:
                        break;
                }
                nextcommand = string.Empty;
            }
        }

        private void parseNoPrefixData(string str1)
        {
            states state = (states)Enum.Parse(typeof(states), lbActionState.Text);
            switch (state)
            {
                case states.getmanufac:
                    textBox85.Text = dev.maker = str1;
                    lbActionState.Text = states.idle.ToString();
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
                    tbDeviceName.Text = textBox86.Text = dev.model = str1;
                    this.logPrintInTextBox("모델값이 " + dev.model + "로 저장되었습니다.", "");
                    break;
                // 단말 정보 자동 갱신 순서
                // autogetmanufac - (autogetmodel) - (autogetimei) - autogetmodemver
                case states.autogetmodel:
                    tbDeviceName.Text = textBox86.Text = dev.model = str1;
                    progressBar1.Value = 70;
                    this.logPrintInTextBox("모델값이 " + dev.model + "로 저장되었습니다.", "");

                    setModelConfig(str1);
                    nextcommand = states.autogetimei.ToString();
                    break;
                case states.getimei:
                    textBox89.Text = tbIMEI.Text = dev.imei = str1.Replace("\"", "");
                    logPrintInTextBox("IMEI를 " + dev.imei + "로 저장하였습니다.", "");

                    lbActionState.Text = states.idle.ToString();
                    break;
                case states.autogetimei:
                    // 단말 정보 자동 갱신 순서
                    // autogetmanufac - autogetmodel - (autogetimei) - (autogetmodemver)
                    textBox89.Text = tbIMEI.Text = dev.imei = str1.Replace("\"", "");
                    logPrintInTextBox("IMEI를 " + dev.imei + "로 저장하였습니다.", "");
                    progressBar1.Value = 90;

                    nextcommand = states.autogetmodemver.ToString();       // 모듈 정보를 모두 읽고 모뎀 버전 정보 조회
                    break;
                case states.getimsi:
                    textBox87.Text = str1;
                    if (str1.StartsWith("45006"))
                    {
                        string ctn = "0" + str1.Substring(5, str1.Length - 5);

                        tbDeviceCTN.Text = tBProxy304.Text = dev.imsi = ctn;
                        this.logPrintInTextBox("IMSI값이 " + dev.imsi + "로 저장되었습니다.", "");
                    }
                    else
                        this.logPrintInTextBox("USIM 상태 확인이 필요합니다.", "");

                    lbActionState.Text = states.idle.ToString();
                    break;
                case states.autogetimsi:
                    textBox87.Text = str1;
                    if (str1.StartsWith("45006"))
                    {
                        string ctn = "0" + str1.Substring(5, str1.Length - 5);

                        tbDeviceCTN.Text = tBProxy304.Text = dev.imsi = ctn;
                        this.logPrintInTextBox("IMSI값이 " + dev.imsi + "로 저장되었습니다.", "");
                    }
                    else
                        this.logPrintInTextBox("USIM 상태 확인이 필요합니다.", "");

                    nextcommand = states.autogeticcid.ToString();
                    break;
                case states.getmodemver:
                    tbDeviceVer.Text = lbModemVer.Text = dev.version = str1;
                    lbActionState.Text = states.idle.ToString();
                    this.logPrintInTextBox("모뎀버전이 " + dev.version + "로 저장되었습니다.", "");

                    break;
                case states.autogetmodemver:
                    tbDeviceVer.Text = lbModemVer.Text = dev.version = str1;
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
            lbActionState.Text = states.autogetmanufac.ToString();
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
            if (checkBox1.Checked == true)
                checkBox1.Text = "지원";
            else
                checkBox1.Text = "미지원";
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
                checkBox3.Text = "지원";
            else
                checkBox3.Text = "미지원";
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
                checkBox4.Text = "지원";
            else
                checkBox4.Text = "미지원";
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
                checkBox6.Text = "\"";
            else
                checkBox6.Text = "없음";
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
            string pathname = Application.StartupPath + @"/";
            string filename = "Sample_" + tbDeviceName.Text + ".ini";

            try
            {
                // Create a file to write to.
                FileStream fs = new FileStream(pathname + filename, FileMode.Create, FileAccess.Write);
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
                if (checkBox9.Checked == true)
                    sw.WriteLine("Auto_SMS_Read = true");
                else
                    sw.WriteLine("Auto_SMS_Read = false");
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
            ofd.DefaultExt = "ini";
            ofd.Filter = "setting files (*.ini)|*.ini";
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
                        if (rddata.EndsWith("true"))
                            checkBox9.Checked = true;
                        else
                            checkBox9.Checked = false;

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
            string pathname = Application.StartupPath + @"/";
            string filename = "LGU+_" + tbDeviceName.Text + "_proxy.xml";

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
                xApps.Add(xApp);

                xApp = new XElement("Application",
                    new XAttribute("name", "MUX_MMI"),
                    new XAttribute("id", "3"),
                    new XElement("AutoConfirmationEnabled", "yes"),
                    new XComment(" Raise the MMI prompt or send auto reply. Values: yes or no ")
                 );

                int comment_index = 1;
                XComment xcomment = new XComment(" "+ comment_index.ToString() +" ");
                xApp.Add(xcomment);
                XElement xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", btProxy301.Text),
                      new XElement("To", 
                        new XAttribute("closePort", "yes"),
                        tBProxy301.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                comment_index++;
                xcomment = new XComment(" " + comment_index.ToString() + " ");
                xApp.Add(xcomment);
                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", btProxy302.Text),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        tBProxy302.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                comment_index++;
                xcomment = new XComment(" " + comment_index.ToString() + " ");
                xApp.Add(xcomment);
                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", btProxy303.Text),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        tBProxy303.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                comment_index++;
                xcomment = new XComment(" " + comment_index.ToString() + " ");
                xApp.Add(xcomment);
                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", btProxy304.Text),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        tBProxy304.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                comment_index++;
                xcomment = new XComment(" " + comment_index.ToString() + " ");
                xApp.Add(xcomment);
                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", btProxy305.Text),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        tBProxy305.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                comment_index++;
                xcomment = new XComment(" " + comment_index.ToString() + " ");
                xApp.Add(xcomment);
                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", btProxy306.Text),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        tBProxy306.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                comment_index++;
                xcomment = new XComment(" " + comment_index.ToString() + " ");
                xApp.Add(xcomment);
                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", btProxy307.Text),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        tBProxy307.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                comment_index++;
                xcomment = new XComment(" " + comment_index.ToString() + " ");
                xApp.Add(xcomment);
                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", btProxy308.Text),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        tBProxy308.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                comment_index++;
                xcomment = new XComment(" " + comment_index.ToString() + " ");
                xApp.Add(xcomment);
                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", btProxy309.Text),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        tBProxy309.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                comment_index++;
                xcomment = new XComment(" " + comment_index.ToString() + " ");
                xApp.Add(xcomment);
                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", btProxy310.Text),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        tBProxy310.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                comment_index++;
                xcomment = new XComment(" " + comment_index.ToString() + " ");
                xApp.Add(xcomment);
                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", btProxy311.Text),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        tBProxy311.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                comment_index++;
                xcomment = new XComment(" " + comment_index.ToString() + " ");
                xApp.Add(xcomment);
                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", btProxy312.Text),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        tBProxy312.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                comment_index++;
                xcomment = new XComment(" " + comment_index.ToString() + " ");
                xApp.Add(xcomment);
                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", btProxy313.Text),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        tBProxy313.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                comment_index++;
                xcomment = new XComment(" " + comment_index.ToString() + " ");
                xApp.Add(xcomment);
                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", btProxy314.Text),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        tBProxy314.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                comment_index++;
                xcomment = new XComment(" " + comment_index.ToString() + " ");
                xApp.Add(xcomment);
                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", btProxy315.Text),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        tBProxy315.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                comment_index++;
                xcomment = new XComment(" " + comment_index.ToString() + " ");
                xApp.Add(xcomment);
                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", btProxy316.Text),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        tBProxy316.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                comment_index++;
                xcomment = new XComment(" " + comment_index.ToString() + " ");
                xApp.Add(xcomment);
                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", btProxy317.Text),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        tBProxy317.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                comment_index++;
                xcomment = new XComment(" " + comment_index.ToString() + " ");
                xApp.Add(xcomment);
                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", btProxy318.Text),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        tBProxy318.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                comment_index++;
                xcomment = new XComment(" " + comment_index.ToString() + " ");
                xApp.Add(xcomment);
                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", btProxy319.Text),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        tBProxy319.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                comment_index++;
                xcomment = new XComment(" " + comment_index.ToString() + " ");
                xApp.Add(xcomment);
                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", btProxy320.Text),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        tBProxy320.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                comment_index++;
                xcomment = new XComment(" " + comment_index.ToString() + " ");
                xApp.Add(xcomment);
                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", btProxy321.Text),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        tBProxy321.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                comment_index++;
                xcomment = new XComment(" " + comment_index.ToString() + " ");
                xApp.Add(xcomment);
                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", btProxy322.Text),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        tBProxy322.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                comment_index++;
                xcomment = new XComment(" " + comment_index.ToString() + " ");
                xApp.Add(xcomment);
                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", btProxy323.Text),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        tBProxy323.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                comment_index++;
                xcomment = new XComment(" " + comment_index.ToString() + " ");
                xApp.Add(xcomment);
                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", btProxy324.Text),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        tBProxy324.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                comment_index++;
                xcomment = new XComment(" " + comment_index.ToString() + " ");
                xApp.Add(xcomment);
                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", btProxy325.Text),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        tBProxy325.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                comment_index++;
                xcomment = new XComment(" " + comment_index.ToString() + " ");
                xApp.Add(xcomment);
                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", btProxy326.Text),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        tBProxy326.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                comment_index++;
                xcomment = new XComment(" " + comment_index.ToString() + " ");
                xApp.Add(xcomment);
                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", btProxy327.Text),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        tBProxy327.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                comment_index++;
                xcomment = new XComment(" " + comment_index.ToString() + " ");
                xApp.Add(xcomment);
                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", btProxy328.Text),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        tBProxy328.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                comment_index++;
                xcomment = new XComment(" " + comment_index.ToString() + " ");
                xApp.Add(xcomment);
                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", btProxy329.Text),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        tBProxy329.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                comment_index = 32;
                xcomment = new XComment(" " + comment_index.ToString() + " ");
                xApp.Add(xcomment);
                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", btProxy332.Text),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        tBProxy332.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                comment_index++;
                xcomment = new XComment(" " + comment_index.ToString() + " ");
                xApp.Add(xcomment);
                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", btProxy333.Text),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        tBProxy333.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                comment_index++;
                xcomment = new XComment(" " + comment_index.ToString() + " ");
                xApp.Add(xcomment);
                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", btProxy334.Text),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        tBProxy334.Text
                      )
                    )
                  );
                xApp.Add(xOption);
                xApps.Add(xApp);

                xApp = new XElement("Application",
                    new XAttribute("name", "MUX_AT"),
                    new XAttribute("id", "4"),
                    new XElement("AutoConfirmationEnabled", "yes"),
                    new XComment(" Raise the MMI prompt or send auto reply. Values: yes or no ")
                 );

                XElement xOptions = new XElement("Options");

                comment_index = 30;
                xcomment = new XComment(" " + comment_index.ToString() + " ");
                xApp.Add(xcomment);
                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", btProxy430.Text),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        tBProxy430.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                comment_index++;
                xcomment = new XComment(" " + comment_index.ToString() + " ");
                xApp.Add(xcomment);
                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", btProxy431.Text),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        tBProxy431.Text
                      )
                    )
                  );
                xApp.Add(xOption);
                xOption = new XElement("ClientReceiveRemap",
                      new XElement("From", btProxy431.Text),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        tBProxy431.Text
                    )
                  );
                xOptions.Add(xOption);

                comment_index = 35;
                xcomment = new XComment(" " + comment_index.ToString() + " ");
                xApp.Add(xcomment);
                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", btProxy435.Text),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        tBProxy435.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                comment_index++;
                xcomment = new XComment(" " + comment_index.ToString() + " ");
                xApp.Add(xcomment);
                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", btProxy436.Text),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        tBProxy436.Text
                      )
                    )
                  );
                xApp.Add(xOption);

                comment_index++;
                xcomment = new XComment(" " + comment_index.ToString() + " ");
                xApp.Add(xcomment);
                xOption = new XElement("Options",
                    new XElement("ClientReceiveRemap",
                      new XElement("From", btProxy437.Text),
                      new XElement("To",
                        new XAttribute("closePort", "yes"),
                        tBProxy437.Text
                      )
                    )
                  );
                xApp.Add(xOption);
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
            ofd.DefaultExt = "xml";
            ofd.Filter = "xml files (*.xml)|*.xml";
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
                                    if (app.Attribute("id").Value == "3")
                                    {
                                        IEnumerable<XElement> options = app.Elements();
                                        foreach (var option in options)
                                        {
                                            if(option.Name == "Options")
                                            {
                                                string msg = option.Element("ClientReceiveRemap").Element("To").Value;
                                                string opt = option.Element("ClientReceiveRemap").Element("From").Value;
                                                if (opt == btProxy301.Text)
                                                    tBProxy301.Text = msg;
                                                else if (opt == btProxy302.Text)
                                                    tBProxy302.Text = msg;
                                                else if (opt == btProxy303.Text)
                                                    tBProxy303.Text = msg;
                                                else if (opt == btProxy304.Text)
                                                    tBProxy304.Text = msg;
                                                else if (opt == btProxy305.Text)
                                                    tBProxy305.Text = msg;
                                                else if (opt == btProxy306.Text)
                                                    tBProxy306.Text = msg;
                                                else if (opt == btProxy307.Text)
                                                    tBProxy307.Text = msg;
                                                else if (opt == btProxy308.Text)
                                                    tBProxy308.Text = msg;
                                                else if (opt == btProxy309.Text)
                                                    tBProxy309.Text = msg;
                                                else if (opt == btProxy310.Text)
                                                    tBProxy310.Text = msg;
                                                else if (opt == btProxy311.Text)
                                                    tBProxy311.Text = msg;
                                                else if (opt == btProxy312.Text)
                                                    tBProxy312.Text = msg;
                                                else if (opt == btProxy313.Text)
                                                    tBProxy313.Text = msg;
                                                else if (opt == btProxy314.Text)
                                                    tBProxy314.Text = msg;
                                                else if (opt == btProxy315.Text)
                                                    tBProxy315.Text = msg;
                                                else if (opt == btProxy316.Text)
                                                    tBProxy316.Text = msg;
                                                else if (opt == btProxy317.Text)
                                                    tBProxy317.Text = msg;
                                                else if (opt == btProxy318.Text)
                                                    tBProxy318.Text = msg;
                                                else if (opt == btProxy319.Text)
                                                    tBProxy319.Text = msg;
                                                else if (opt == btProxy320.Text)
                                                    tBProxy320.Text = msg;
                                                else if (opt == btProxy321.Text)
                                                    tBProxy321.Text = msg;
                                                else if (opt == btProxy322.Text)
                                                    tBProxy322.Text = msg;
                                                else if (opt == btProxy323.Text)
                                                    tBProxy323.Text = msg;
                                                else if (opt == btProxy324.Text)
                                                    tBProxy324.Text = msg;
                                                else if (opt == btProxy325.Text)
                                                    tBProxy325.Text = msg;
                                                else if (opt == btProxy326.Text)
                                                    tBProxy326.Text = msg;
                                                else if (opt == btProxy327.Text)
                                                    tBProxy327.Text = msg;
                                                else if (opt == btProxy328.Text)
                                                    tBProxy328.Text = msg;
                                                else if (opt == btProxy329.Text)
                                                    tBProxy329.Text = msg;
                                                else if (opt == btProxy332.Text)
                                                    tBProxy332.Text = msg;
                                                else if (opt == btProxy333.Text)
                                                    tBProxy333.Text = msg;
                                                else if (opt == btProxy334.Text)
                                                    tBProxy334.Text = msg;

                                            }
                                        }
                                    }
                                    else if (app.Attribute("id").Value == "4")
                                    {
                                        IEnumerable<XElement> options = app.Elements();
                                        foreach (var option in options)
                                        {
                                            if (option.Name == "Options")
                                            {
                                                string msg = option.Element("ClientReceiveRemap").Element("To").Value;
                                                string opt = option.Element("ClientReceiveRemap").Element("From").Value;
                                                if (opt == btProxy430.Text)
                                                    tBProxy430.Text = msg;
                                                else if (opt == btProxy431.Text)
                                                    tBProxy431.Text = msg;
                                                else if (opt == btProxy435.Text)
                                                    tBProxy435.Text = msg;
                                                else if (opt == btProxy436.Text)
                                                    tBProxy436.Text = msg;
                                                else if (opt == btProxy437.Text)
                                                    tBProxy437.Text = msg;
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
                i++;
                worksheet.Cells[i, 0] = new Cell("BAUDRATE");
                worksheet.Cells[i, 1] = new Cell(cBoxBaudRate.Text);

                worksheet.Cells.ColumnWidth[0, 2] = 7000;
                workbook.Worksheets.Add(worksheet);

                i = 0;
                worksheet = new Worksheet("atcommand_ID3");
                worksheet.Cells[i, 0] = new Cell(btProxy301.Text);
                worksheet.Cells[i, 1] = new Cell(tBProxy301.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(btProxy302.Text);
                worksheet.Cells[i, 1] = new Cell(tBProxy302.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(btProxy303.Text);
                worksheet.Cells[i, 1] = new Cell(tBProxy303.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(btProxy304.Text);
                worksheet.Cells[i, 1] = new Cell(tBProxy304.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(btProxy305.Text);
                worksheet.Cells[i, 1] = new Cell(tBProxy305.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(btProxy306.Text);
                worksheet.Cells[i, 1] = new Cell(tBProxy306.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(btProxy307.Text);
                worksheet.Cells[i, 1] = new Cell(tBProxy307.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(btProxy308.Text);
                worksheet.Cells[i, 1] = new Cell(tBProxy308.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(btProxy309.Text);
                worksheet.Cells[i, 1] = new Cell(tBProxy309.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(btProxy310.Text);
                worksheet.Cells[i, 1] = new Cell(tBProxy310.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(btProxy311.Text);
                worksheet.Cells[i, 1] = new Cell(tBProxy311.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(btProxy312.Text);
                worksheet.Cells[i, 1] = new Cell(tBProxy312.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(btProxy313.Text);
                worksheet.Cells[i, 1] = new Cell(tBProxy313.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(btProxy314.Text);
                worksheet.Cells[i, 1] = new Cell(tBProxy314.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(btProxy315.Text);
                worksheet.Cells[i, 1] = new Cell(tBProxy315.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(btProxy316.Text);
                worksheet.Cells[i, 1] = new Cell(tBProxy316.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(btProxy317.Text);
                worksheet.Cells[i, 1] = new Cell(tBProxy317.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(btProxy318.Text);
                worksheet.Cells[i, 1] = new Cell(tBProxy318.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(btProxy319.Text);
                worksheet.Cells[i, 1] = new Cell(tBProxy319.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(btProxy320.Text);
                worksheet.Cells[i, 1] = new Cell(tBProxy320.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(btProxy321.Text);
                worksheet.Cells[i, 1] = new Cell(tBProxy321.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(btProxy322.Text);
                worksheet.Cells[i, 1] = new Cell(tBProxy322.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(btProxy323.Text);
                worksheet.Cells[i, 1] = new Cell(tBProxy323.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(btProxy324.Text);
                worksheet.Cells[i, 1] = new Cell(tBProxy324.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(btProxy325.Text);
                worksheet.Cells[i, 1] = new Cell(tBProxy325.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(btProxy326.Text);
                worksheet.Cells[i, 1] = new Cell(tBProxy326.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(btProxy327.Text);
                worksheet.Cells[i, 1] = new Cell(tBProxy327.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(btProxy328.Text);
                worksheet.Cells[i, 1] = new Cell(tBProxy328.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(btProxy329.Text);
                worksheet.Cells[i, 1] = new Cell(tBProxy329.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(btProxy332.Text);
                worksheet.Cells[i, 1] = new Cell(tBProxy332.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(btProxy333.Text);
                worksheet.Cells[i, 1] = new Cell(tBProxy333.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(btProxy334.Text);
                worksheet.Cells[i, 1] = new Cell(tBProxy334.Text);

                worksheet.Cells.ColumnWidth[0, 2] = 10000;
                workbook.Worksheets.Add(worksheet);

                i = 0;
                worksheet = new Worksheet("atcommand_ID4");
                worksheet.Cells[i, 0] = new Cell(btProxy430.Text);
                worksheet.Cells[i, 1] = new Cell(tBProxy430.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(btProxy431.Text);
                worksheet.Cells[i, 1] = new Cell(tBProxy431.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(btProxy435.Text);
                worksheet.Cells[i, 1] = new Cell(tBProxy435.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(btProxy436.Text);
                worksheet.Cells[i, 1] = new Cell(tBProxy436.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(btProxy437.Text);
                worksheet.Cells[i, 1] = new Cell(tBProxy437.Text);

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
                i++;
                worksheet.Cells[i, 0] = new Cell(button119.Text);
                worksheet.Cells[i, 1] = new Cell("");
                worksheet.Cells[i, 2] = new Cell(textBox78.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button63.Text);
                worksheet.Cells[i, 1] = new Cell("");
                worksheet.Cells[i, 2] = new Cell(textBox64.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button120.Text);
                worksheet.Cells[i, 1] = new Cell("");
                worksheet.Cells[i, 2] = new Cell(textBox79.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button121.Text);
                worksheet.Cells[i, 1] = new Cell("");
                worksheet.Cells[i, 2] = new Cell(textBox80.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button128.Text);
                worksheet.Cells[i, 1] = new Cell("");
                worksheet.Cells[i, 2] = new Cell(textBox81.Text);

                worksheet.Cells.ColumnWidth[0, 3] = 5000;
                workbook.Worksheets.Add(worksheet);


                i = 0;
                worksheet = new Worksheet("lwm2matcmd");
                worksheet.Cells[i, 0] = new Cell(label31.Text);
                worksheet.Cells[i, 1] = new Cell(tbSvcCd.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(label34.Text);
                worksheet.Cells[i, 1] = new Cell(tBoxDeviceModel.Text);
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
                i++;
                worksheet.Cells[i, 0] = new Cell(label43.Text);
                worksheet.Cells[i, 1] = new Cell("");
                worksheet.Cells[i, 2] = new Cell(checkBox2.Text);
                worksheet.Cells[i, 3] = new Cell(checkBox6.Text);
                worksheet.Cells[i, 4] = new Cell(checkBox7.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button97.Text);
                worksheet.Cells[i, 1] = new Cell("setmbsps");
                worksheet.Cells[i, 2] = new Cell(textBox55.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button105.Text);
                worksheet.Cells[i, 1] = new Cell("bootstrapmode");
                worksheet.Cells[i, 2] = new Cell(textBox66.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(btnBootstrap.Text);
                worksheet.Cells[i, 1] = new Cell("bootstrap");
                worksheet.Cells[i, 2] = new Cell(textBox67.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(btnRegister.Text);
                worksheet.Cells[i, 1] = new Cell("register");
                worksheet.Cells[i, 2] = new Cell(textBox54.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button95.Text);
                worksheet.Cells[i, 1] = new Cell("sendmsghex");
                worksheet.Cells[i, 2] = new Cell(textBox53.Text);
                worksheet.Cells[i, 3] = new Cell(checkBox8.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button107.Text);
                worksheet.Cells[i, 1] = new Cell("recvmsghex");
                worksheet.Cells[i, 2] = new Cell(textBox68.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(btnDeregister.Text);
                worksheet.Cells[i, 1] = new Cell("deregister");
                worksheet.Cells[i, 2] = new Cell(textBox52.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(btnDeviceVerLwM2M.Text);
                worksheet.Cells[i, 1] = new Cell("sendmsgver");
                worksheet.Cells[i, 2] = new Cell(textBox51.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button108.Text);
                worksheet.Cells[i, 1] = new Cell("recvfota");
                worksheet.Cells[i, 2] = new Cell(textBox69.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(label3.Text);
                worksheet.Cells[i, 1] = new Cell("");
                worksheet.Cells[i, 2] = new Cell(textBox65.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(label39.Text);
                worksheet.Cells[i, 1] = new Cell("");
                worksheet.Cells[i, 2] = new Cell(textBox70.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell("");
                worksheet.Cells[i, 1] = new Cell("");
                worksheet.Cells[i, 2] = new Cell(checkBox5.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button118.Text);
                worksheet.Cells[i, 1] = new Cell("");
                worksheet.Cells[i, 2] = new Cell(textBox63.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(label41.Text);
                worksheet.Cells[i, 1] = new Cell("");
                worksheet.Cells[i, 2] = new Cell(textBox74.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(label42.Text);
                worksheet.Cells[i, 1] = new Cell("");
                worksheet.Cells[i, 2] = new Cell(textBox75.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(label52.Text);
                worksheet.Cells[i, 1] = new Cell("");
                worksheet.Cells[i, 2] = new Cell(textBox77.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(label51.Text);
                worksheet.Cells[i, 1] = new Cell("");
                worksheet.Cells[i, 2] = new Cell(comboBox4.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button35.Text);
                worksheet.Cells[i, 1] = new Cell("");
                worksheet.Cells[i, 2] = new Cell(textBox71.Text);

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
                i++;
                worksheet.Cells[i, 0] = new Cell(button129.Text);
                worksheet.Cells[i, 1] = new Cell(checkBox9.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell("[NBIoT]");
                i++;
                worksheet.Cells[i, 0] = new Cell(button36.Text);
                worksheet.Cells[i, 1] = new Cell(cbNBIPVer.Text);

                worksheet.Cells.ColumnWidth[0] = 5000;
                workbook.Worksheets.Add(worksheet);

                i = 0;
                worksheet = new Worksheet("onem2matcmd");
                worksheet.Cells[i, 0] = new Cell(label34.Text);
                worksheet.Cells[i, 1] = new Cell(tBoxDeviceModel.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(label32.Text);
                worksheet.Cells[i, 1] = new Cell(tBoxDeviceSN.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(btnoneM2MModuleVer.Text);
                worksheet.Cells[i, 1] = new Cell(textBox73.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(label13.Text);
                worksheet.Cells[i, 1] = new Cell(comboBox2.Text);
                worksheet.Cells.ColumnWidth[0] = 5000;
                i++;
                worksheet.Cells[i, 0] = new Cell(label38.Text);
                worksheet.Cells[i, 1] = new Cell(textBox72.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button114.Text);
                worksheet.Cells[i, 1] = new Cell(checkBox1.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(btnGetCSED.Text);
                worksheet.Cells[i, 1] = new Cell(checkBox3.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(button115.Text);
                worksheet.Cells[i, 1] = new Cell(checkBox4.Text);
                i++;
                worksheet.Cells[i, 0] = new Cell(label50.Text);
                worksheet.Cells[i, 1] = new Cell(textBox76.Text);
                workbook.Worksheets.Add(worksheet);

                workbook.Save(Application.StartupPath + @"/" + tbDeviceName.Text + "_config.xls");
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
            ofd.InitialDirectory = Application.StartupPath;
            ofd.Filter = "text files (*.xls)|*.xls";
            ofd.Title = "테스트 모델 정보 선택";
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
                        string comport = worksheet.Cells[i, 1].ToString();
                        if (cBoxCOMPORT.Items.Contains(comport))
                            cBoxCOMPORT.SelectedItem = comport;
                        else
                            cBoxCOMPORT.SelectedIndex = 0;
                        i++;
                        cBoxBaudRate.Text = worksheet.Cells[i, 1].ToString();

                        ///////////////////////////////////////////////////////////////// PCT 장비 AT command 매핑 1
                        worksheet = workbook.Worksheets[1];
                        i = 0;
                        tBProxy301.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        tBProxy302.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        tBProxy303.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        tBProxy304.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        tBProxy305.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        tBProxy306.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        tBProxy307.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        tBProxy308.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        tBProxy309.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        tBProxy310.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        tBProxy311.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        tBProxy312.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        tBProxy313.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        tBProxy314.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        tBProxy315.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        tBProxy316.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        tBProxy317.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        tBProxy318.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        tBProxy319.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        tBProxy320.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        tBProxy321.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        tBProxy322.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        tBProxy323.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        tBProxy324.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        tBProxy325.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        tBProxy326.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        tBProxy327.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        tBProxy328.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        tBProxy329.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        tBProxy332.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        tBProxy333.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        tBProxy334.Text = worksheet.Cells[i, 1].ToString();

                        //////////////////////////////////////////////// PCT 장비 AT command 매핑 2
                        i = 0;
                        worksheet = workbook.Worksheets[2];
                        tBProxy430.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        tBProxy431.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        tBProxy435.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        tBProxy436.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        tBProxy437.Text = worksheet.Cells[i, 1].ToString();

                        /////////////////////////////////////////////// 플랫폼 검증 앱 공통 AT command
                        i = 0;
                        worksheet = workbook.Worksheets[3];
                        comboBox1.Text = worksheet.Cells[i, 1].ToString();
                        if (comboBox1.SelectedIndex == 1)
                            dev.type = "lwm2m";
                        else
                            dev.type = "onem2m";
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
                        i++;
                        textBox78.Text = worksheet.Cells[i, 2].ToString();
                        i++;
                        textBox64.Text = worksheet.Cells[i, 2].ToString();
                        i++;
                        textBox79.Text = worksheet.Cells[i, 2].ToString();
                        i++;
                        textBox80.Text = worksheet.Cells[i, 2].ToString();
                        i++;
                        textBox81.Text = worksheet.Cells[i, 2].ToString();

                        /////////////////////////////////////////////// 플랫폼 검증 앱 LwM2M AT command
                        i = 0;
                        worksheet = workbook.Worksheets[4];
                        tbSvcCd.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        tBoxDeviceModel.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        tbSvcSvrCd.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        tbSvcSvrNum.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        textBox56.Text = worksheet.Cells[i, 2].ToString();
                        i++;
                        textBox50.Text = worksheet.Cells[i, 2].ToString();
                        i++;
                        checkBox2.Text = worksheet.Cells[i, 2].ToString();
                        if (checkBox2.Text == "수동")
                            checkBox2.Checked = false;
                        else
                        {
                            checkBox2.Checked = true;
                            checkBox2.Text = "자동";
                        }
                        checkBox6.Text = worksheet.Cells[i, 3].ToString();
                        if (checkBox6.Text == "\"")
                            checkBox6.Checked = true;
                        else
                        {
                            checkBox6.Checked = false;
                            checkBox6.Text = "없음";
                        }

                        checkBox7.Text = worksheet.Cells[i, 4].ToString();
                        if (checkBox7.Text == "2회")
                            checkBox7.Checked = true;
                        else
                        {
                            checkBox7.Checked = false;
                            checkBox7.Text = "1회";
                        }
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
                        checkBox8.Text = worksheet.Cells[i, 3].ToString();
                        if (checkBox8.Text == "STRING")
                            checkBox8.Checked = false;
                        else
                        {
                            checkBox8.Checked = true;
                            checkBox8.Text = "HEX";
                        }
                        i++;
                        textBox68.Text = worksheet.Cells[i, 2].ToString();
                        i++;
                        textBox52.Text = worksheet.Cells[i, 2].ToString();
                        i++;
                        textBox51.Text = worksheet.Cells[i, 2].ToString();
                        i++;
                        textBox69.Text = worksheet.Cells[i, 2].ToString();
                        i++;
                        textBox65.Text = worksheet.Cells[i, 2].ToString();
                        i++;
                        textBox70.Text = worksheet.Cells[i, 2].ToString();
                        i++;
                        checkBox5.Text = worksheet.Cells[i, 2].ToString();
                        if (checkBox5.Text == "Bootstrap/Register 명령 구분")
                            checkBox5.Checked = true;
                        else
                            checkBox5.Checked = false;
                        i++;
                        textBox63.Text = worksheet.Cells[i, 2].ToString();
                        i++;
                        textBox74.Text = worksheet.Cells[i, 2].ToString();
                        i++;
                        textBox75.Text = worksheet.Cells[i, 2].ToString();
                        i++;
                        textBox77.Text = worksheet.Cells[i, 2].ToString();
                        i++;
                        comboBox4.Text = worksheet.Cells[i, 2].ToString();
                        i++;
                        textBox71.Text = worksheet.Cells[i, 2].ToString();

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
                        tbDeviceVer.Text = dev.version = worksheet.Cells[i, 1].ToString();
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
                        i++;
                        checkBox9.Text = worksheet.Cells[i, 1].ToString();
                        if (checkBox9.Text == "지원")
                            checkBox9.Checked = true;
                        else
                            checkBox9.Checked = false;
                        i += 2;
                        cbNBIPVer.Text = worksheet.Cells[i, 1].ToString();

                        //////////////////////////////////////////////////////////////// oneM2M AT command 옵션 설정
                        i = 0;
                        worksheet = workbook.Worksheets[6];
                        tBoxDeviceModel.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        tBoxDeviceSN.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        textBox73.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        comboBox2.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        textBox72.Text = worksheet.Cells[i, 1].ToString();
                        i++;
                        checkBox1.Text = worksheet.Cells[i, 1].ToString();
                        if (checkBox1.Text == "지원")
                            checkBox1.Checked = true;
                        else
                        {
                            checkBox1.Checked = false;
                            checkBox1.Text = "미지원";
                        }
                        i++;
                        checkBox3.Text = worksheet.Cells[i, 1].ToString();
                        if (checkBox3.Text == "지원")
                            checkBox3.Checked = true;
                        else
                        {
                            checkBox3.Checked = false;
                            checkBox3.Text = "미지원";
                        }
                        i++;
                        checkBox4.Text = worksheet.Cells[i, 1].ToString();
                        if (checkBox4.Text == "지원")
                            checkBox4.Checked = true;
                        else
                        {
                            checkBox4.Checked = false;
                            checkBox4.Text = "미지원";
                        }
                        i++;
                        textBox76.Text = worksheet.Cells[i, 1].ToString();
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
            this.sendDataOut(tBProxy430.Text);
            lbActionState.Text = states.testatcmd.ToString();
        }

        private void button75_Click(object sender, EventArgs e)
        {
            this.sendDataOut(tBProxy431.Text);
            lbActionState.Text = states.testatcmd.ToString();
        }

        private void button67_Click(object sender, EventArgs e)
        {
            this.sendDataOut(tBProxy435.Text);
            lbActionState.Text = states.testatcmd.ToString();
        }

        private void button66_Click(object sender, EventArgs e)
        {
            this.sendDataOut(tBProxy436.Text);
            lbActionState.Text = states.testatcmd.ToString();
        }

        private void button65_Click(object sender, EventArgs e)
        {
            this.sendDataOut(tBProxy437.Text);
            lbActionState.Text = states.testatcmd.ToString();
        }

        private void button84_Click(object sender, EventArgs e)
        {
            this.sendDataOut(tBProxy323.Text);
            lbActionState.Text = states.testatcmd.ToString();
        }

        private void button69_Click(object sender, EventArgs e)
        {
            this.sendDataOut(tBProxy324.Text);
            lbActionState.Text = states.testatcmd.ToString();
        }

        private void button82_Click(object sender, EventArgs e)
        {
            this.sendDataOut(tBProxy325.Text);
            lbActionState.Text = states.testatcmd.ToString();
        }

        private void button79_Click(object sender, EventArgs e)
        {
            this.sendDataOut(tBProxy326.Text);
            lbActionState.Text = states.testatcmd.ToString();
        }

        private void button78_Click(object sender, EventArgs e)
        {
            this.sendDataOut(tBProxy327.Text);
            lbActionState.Text = states.testatcmd.ToString();
        }

        private void button77_Click(object sender, EventArgs e)
        {
            this.sendDataOut(tBProxy328.Text);
            lbActionState.Text = states.testatcmd.ToString();
        }

        private void button76_Click(object sender, EventArgs e)
        {
            this.sendDataOut(tBProxy329.Text);
            lbActionState.Text = states.testatcmd.ToString();
        }

        private void button60_Click(object sender, EventArgs e)
        {
            this.sendDataOut(tBProxy322.Text);
            lbActionState.Text = states.testatcmd.ToString();
        }

        private void button85_Click(object sender, EventArgs e)
        {
            this.sendDataOut(tBProxy321.Text);
            lbActionState.Text = states.testatcmd.ToString();
        }

        private void button59_Click(object sender, EventArgs e)
        {
            this.sendDataOut(tBProxy320.Text);
            lbActionState.Text = states.testatcmd.ToString();
        }

        private void button58_Click(object sender, EventArgs e)
        {
            this.sendDataOut(tBProxy319.Text);
            lbActionState.Text = states.testatcmd.ToString();
        }

        private void button57_Click(object sender, EventArgs e)
        {
            this.sendDataOut(tBProxy318.Text);
            lbActionState.Text = states.testatcmd.ToString();
        }

        private void button56_Click(object sender, EventArgs e)
        {
            this.sendDataOut(tBProxy317.Text);
            lbActionState.Text = states.testatcmd.ToString();
        }

        private void button55_Click(object sender, EventArgs e)
        {
            this.sendDataOut(tBProxy316.Text);
            lbActionState.Text = states.testatcmd.ToString();
        }

        private void button43_Click(object sender, EventArgs e)
        {
            this.sendDataOut(tBProxy315.Text);
            lbActionState.Text = states.testatcmd.ToString();
        }

        private void button54_Click(object sender, EventArgs e)
        {
            this.sendDataOut(tBProxy314.Text);
            lbActionState.Text = states.testatcmd.ToString();
        }

        private void button53_Click(object sender, EventArgs e)
        {
            this.sendDataOut(tBProxy313.Text);
            lbActionState.Text = states.testatcmd.ToString();
        }

        private void button52_Click(object sender, EventArgs e)
        {
            this.sendDataOut(tBProxy312.Text);
            lbActionState.Text = states.testatcmd.ToString();
        }

        private void button51_Click(object sender, EventArgs e)
        {
            this.sendDataOut(tBProxy311.Text);
            lbActionState.Text = states.testatcmd.ToString();
        }

        private void button50_Click(object sender, EventArgs e)
        {
            this.sendDataOut(tBProxy310.Text);
            lbActionState.Text = states.testatcmd.ToString();
        }

        private void button49_Click(object sender, EventArgs e)
        {
            this.sendDataOut(tBProxy309.Text);
            lbActionState.Text = states.testatcmd.ToString();
        }

        private void button48_Click(object sender, EventArgs e)
        {
            this.sendDataOut(tBProxy308.Text);
            lbActionState.Text = states.testatcmd.ToString();
        }

        private void button47_Click(object sender, EventArgs e)
        {
            this.sendDataOut(tBProxy307.Text);
            lbActionState.Text = states.testatcmd.ToString();
        }

        private void button46_Click(object sender, EventArgs e)
        {
            this.sendDataOut(tBProxy306.Text);
            lbActionState.Text = states.testatcmd.ToString();
        }

        private void button45_Click(object sender, EventArgs e)
        {
            this.sendDataOut(tBProxy305.Text);
            lbActionState.Text = states.testatcmd.ToString();
        }

        private void button37_Click(object sender, EventArgs e)
        {
            this.sendDataOut(tBProxy304.Text);
            lbActionState.Text = states.testatcmd.ToString();
        }

        private void button38_Click(object sender, EventArgs e)
        {
            this.sendDataOut(tBProxy303.Text);
            lbActionState.Text = states.testatcmd.ToString();
        }

        private void button39_Click(object sender, EventArgs e)
        {
            this.sendDataOut(tBProxy302.Text);
            lbActionState.Text = states.testatcmd.ToString();
        }

        private void button42_Click(object sender, EventArgs e)
        {
            this.sendDataOut(tBProxy301.Text);
            lbActionState.Text = states.testatcmd.ToString();
        }

        private void button83_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox48.Text);
            lbActionState.Text = states.getmanufac.ToString();
        }

        private void button91_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox47.Text);
            lbActionState.Text = states.getmodel.ToString();
        }

        private void button89_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox49.Text);
            nextresponse = textBox40.Text;
            lbActionState.Text = states.getimei.ToString();
        }

        private void button88_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox44.Text);
            nextresponse = textBox57.Text;
            lbActionState.Text = states.getmodemver.ToString();
        }

        private void button90_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox46.Text);
            nextresponse = textBox33.Text;
            lbActionState.Text = states.getimsi.ToString();
        }

        private void button71_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox45.Text);
            nextresponse = textBox38.Text;
            lbActionState.Text = states.geticcid.ToString();
        }

        private void button86_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox24.Text);
            lbActionState.Text = states.rfreset.ToString();
        }

        private void button87_Click(object sender, EventArgs e)
        {
            nextcommand = string.Empty;
            nextresponse = string.Empty;
            getDeviveInfo();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 1)
                dev.type = "lwm2m";
            else
                dev.type = "onem2m";
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
            string kind = "type=onem2m";
            if (comboBox1.SelectedIndex == 1)
                kind = "type=lwm2m";
            if (tbDeviceCTN.Text != string.Empty)
                kind += "&ctn=" + tbDeviceCTN.Text;
            kind += "&from=" + tcStartTime.ToString("yyyyMMddHHmmss");
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

                    listView8.Items.Clear();
                    listView9.Items.Clear();
                    listView10.Items.Clear();
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
                        OneM2MTcResultReport(path, jobj["logId"].ToString(), jobj["resultCode"].ToString(), jobj["resultCodeName"].ToString(), resType.ToString(), trgAddr.ToString(), oprType.ToString());

                        ListViewItem newitem = new ListViewItem(new string[] { logtime, jobj["logId"].ToString(), tcmsg, jobj["resultCode"].ToString(), jobj["resultCodeName"].ToString() + " (" + path + ")" });
                        listView8.Items.Add(newitem);
                    }

                    if (listView8.Items.Count > 0)
                    {
                        listView8.Items[0].Focused = true;
                        listView8.Items[0].Selected = true;
                    }
                    else if (mode == "man")
                        MessageBox.Show("플랫폼 로그가 존재하지 않습니다.\nCTN을 확인하세요", tBProxy304.Text + " DEVICE 상태 정보");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            else if (mode == "man")
                MessageBox.Show("플랫폼 로그가 존재하지 않습니다.\nCTN을 확인하세요", tBProxy304.Text + " DEVICE 상태 정보");
        }

        private void OneM2MTcResultReport(string path, string logId, string resultCode, string resultCodeName, string resType, string trgAddr, string oprType)
        {
            // oprType = 1:POST(Create), 2:GET(Read), 3:PUT(Update),4:DELETE,5:POST(Noti)
            switch (resType)
            {
                case "mefda":
                    tcmsg = "Device MEF Certi.";
                    endoneM2MTC("tc020201", logId, resultCode, resultCodeName, string.Empty);
                    break;
                case "mefsa":
                    tcmsg = "Server MEF Certi.";
                    endoneM2MTC("tc020201", logId, resultCode, resultCodeName, string.Empty);
                    break;
                case "cb":
                    tcmsg = "CSEBase Read";
                    endoneM2MTC("tc020401", logId, resultCode, resultCodeName, string.Empty);
                    break;
                case "csr":
                    if (oprType == "4")
                    {
                        tcmsg = "remoteCSE Delete";
                        endoneM2MTC("tc021204", logId, resultCode, resultCodeName, string.Empty);
                    }
                    else if (oprType == "3")
                    {
                        tcmsg = "remoteCSE Update";
                        if (resultCode == "40041001")
                            endoneM2MTC("tc020505", logId, "20000000", resultCodeName, "40041001");
                        else
                            endoneM2MTC("tc020505", logId, resultCode, resultCodeName, string.Empty);
                    }
                    else if (oprType == "2")
                    {
                        tcmsg = "remoteCSE Read";
                        if (resultCode == "40041001")
                            endoneM2MTC("tc020301", logId, "20000000", resultCodeName, "40041001");
                        else
                            endoneM2MTC("tc020301", logId, resultCode, resultCodeName, string.Empty);
                    }
                    else
                    {
                        tcmsg = "remoteCSE Create";
                        if (resultCode == "41051001")
                            endoneM2MTC("tc020501", logId, "20000000", resultCodeName, resultCode);
                        else
                            endoneM2MTC("tc020501", logId, resultCode, resultCodeName, string.Empty);
                    }
                    break;
                case "cnt":
                    if (oprType == "4")
                    {
                        tcmsg = "Folder Delete";
                        endoneM2MTC("tc021203", logId, resultCode, resultCodeName, string.Empty);
                    }
                    else
                    {
                        tcmsg = "Folder Create";
                        if (resultCode == "41051001")
                            endoneM2MTC("tc020502", logId, "20000000", resultCodeName, resultCode);
                        else
                            endoneM2MTC("tc020502", logId, resultCode, resultCodeName, string.Empty);
                    }
                    break;
                case "cin":
                    if (oprType == "2")
                    {
                        tcmsg = "Data Read(Auto)";
                        endoneM2MTC("tc020603", logId, resultCode, resultCodeName, string.Empty);
                    }
                    else
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
                    else
                    {
                        tcmsg = "Subscript Create";
                        if (resultCode == "41051001")
                            endoneM2MTC("tc020503", logId, "20000000", resultCodeName, resultCode);
                        else
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
                    else
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
                    if (tcmsg == string.Empty)
                        tcmsg = "Module FW Read";
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
                        else
                        {
                            tcmsg = "Device Control";
                            endoneM2MTC("tc021302", logId, resultCode, resultCodeName, string.Empty);
                        }
                    }
                    else
                    {
                        tcmsg = "Data send(FWD)";
                        getSvrDetailLog(logId, "tc021301", resultCode, resultCodeName);
                        //endoneM2MTC("tc021301", logId, resultCode, resultCodeName, string.Empty);
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
                    else
                        tcmsg = "Remote Unknown CMD";
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
                case "":
                    tcmsg = "Service Server";
                    break;
                case "lbkbt":
                    tcmsg = "Bootstrap   ";
                    endLwM2MTC("tc0203", logId, resultCode, resultCodeName, string.Empty);
                    break;
                case "lbkre":
                    if (resultCode == "20000000")
                    {
                        Console.WriteLine("registration device parameter checking");
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
                        getSvrDetailLog(logId, "tc0501", resultCode, resultCodeName);
                        //endLwM2MTC("tc0501", logId, resultCode, resultCodeName, string.Empty);
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
                        Console.WriteLine("device control checking");
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
                case "UNKNOWN":
                    tcmsg = "UNKNOWN";
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

            listView10.Items.Clear();
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

                        string message = string.Empty;
                        string msgbody = string.Empty;

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

                            message += ")";

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

                                                if (kind == "tc0501")
                                                    endLwM2MTC("tc0501", tlogid, tresultCode, tresultCodeName, BcdToString(orgChars));
                                            }
                                            else
                                            {
                                                if (kind == "tc0501")
                                                    endLwM2MTC("tc0501", tlogid, tresultCode, tresultCodeName, hexdata);
                                            }
                                        }

                                        if (kind == "tc0302")
                                        {
                                            if (code.ToString() == "NOT_FOUND")
                                            {
                                                var rdpath = jcoapobj["path"] ?? " ";

                                                tcmsg = "Registration";
                                                endLwM2MTC("tc0302", tlogid, "20000100", rdpath.ToString(), code.ToString());
                                            }
                                        }
                                    }
                                }

                                var uriQuery = jobj["uriQuery"] ?? " ";
                                if (uriQuery.ToString() == " ")
                                    msgbody = coapmsg;
                                else
                                {
                                    if (path.StartsWith("rd/", System.StringComparison.CurrentCultureIgnoreCase))
                                    {
                                        msgbody = coapmsg;
                                    }
                                    else
                                    {
                                        msgbody = uriQuery.ToString() + "\n";

                                        if (uriPath.ToString() == "rd")
                                        {
                                            var others = jobj["others"] ?? "";
                                            if (others.ToString() == "")
                                            {
                                                msgbody += "\n2048(EKI), 2049(TOKEN) 정보가 없습니다\n";
                                            }
                                        }
                                        msgbody += "\n" + coapmsg;
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

                            message = resultCode.ToString() + " " + protocol;
                            msgbody = trgAddr.ToString();
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
                                if (kind == "tc021101")
                                {
                                    tcmsg = "Module FW read";
                                    if (ntparam == string.Empty)
                                        endoneM2MTC("tc021101", tlogid, "20000100", tresultCodeName, "NO CELL info");
                                    else
                                        endoneM2MTC("tc021101", tlogid, tresultCode, tresultCodeName, ntparam);
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
                            }
                            else if (kind == "tc021301")
                            {
                                if (body.ToString() == " " || body.ToString() == string.Empty)
                                    endoneM2MTC("tc021301", tlogid, "20000100", tresultCodeName, "None body DATA");
                                else
                                    endoneM2MTC("tc021301", tlogid, tresultCode, tresultCodeName, body.ToString());
                            }

                            string bodymsg = ParsingReqBodyMsg(body.ToString(), kind, tlogid, tresultCode, tresultCodeName);
                            string resbodymsg = ParsingResBodyMsg(responseBody.ToString(), kind, tlogid, tresultCode, tresultCodeName, ntparam);

                            message = httpMethod.ToString() + " " + uri.ToString();
                            msgbody = "REQUEST\n" + httpheader + "\n" + bodymsg + "\n\nRESPONSE\n" + responseBody + resbodymsg;

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

                            message = resp + " (" + uri.ToString() + ")";
                            msgbody = "REQUEST\n" + reqheader + "\n\nRESPONSE\n" + responseHeader;
                        }
                        else if (logtype == "RUNTIME_LOG")
                        {
                            logtype = "RUN";
                            var topicOrEntityId = jobj["topicOrEntityId"] ?? " ";
                            var requestEntity = jobj["requestEntity"] ?? " ";
                            var responseEntity = jobj["responseEntity"] ?? " ";

                            message = topicOrEntityId.ToString();
                            msgbody = "REQUEST\n" + requestEntity + "\n\nRESPONSE\n" + responseEntity;
                        }

                        string svrtype = svrType.ToString();
                        if (svrtype == "CSE-NB01")
                            svrtype = "CSNB01";

                        string method = methodName.ToString();
                        if (method == "httpClientRuntimeLog")
                            method = "httpClientRuntime";

                        if (method.Length < 8)
                            method += "         ";

                        ListViewItem newitem = new ListViewItem(new string[] { svrtype, logtype, method, message, msgbody});
                        listView10.Items.Add(newitem);
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
                        if (tckind == "tc021004")
                        {
                            if (xn["hwty"] != null)
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
                            else
                            {
                                tcmsg = "Device FW Report";
                                endoneM2MTC("tc021004", tlogid, tresultCode, tresultCodeName, string.Empty);
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
                                    tcmsg = "Device FW Check";
                                    if (ntparam == string.Empty)
                                        endoneM2MTC("tc021001", tlogid, "20000100", tresultCodeName, "NO CELL info");
                                    else
                                        endoneM2MTC("tc021001", tlogid, tresultCode, tresultCodeName, ntparam);
                                }
                                else
                                {
                                    tcmsg = "Module FW Check";
                                    if (ntparam == string.Empty)
                                        endoneM2MTC("tc021101", tlogid, "20000100", tresultCodeName, "NO CELL info");
                                    else
                                        endoneM2MTC("tc021101", tlogid, tresultCode, tresultCodeName, ntparam);
                                }
                            }
                            else
                            {
                                tcmsg = "Device FW Check";
                                endoneM2MTC("tc021001", tlogid, tresultCode, tresultCodeName, string.Empty);
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

        private void startLwM2MTC(string tcindex, string logId, string resultCode, string resultCodeName, string remark)
        {
            logPrintTC(lwm2mtclist[tcindex],"시작",string.Empty);
            lwm2mtc index = (lwm2mtc)Enum.Parse(typeof(lwm2mtc), tcindex);
            int idx = (int)index;
            if (listView2.Items[idx].SubItems[0].Text != "FAIL")
                SetTextlist2(listView2, idx.ToString() + "," + "START" + "," + resultCode + "," + logId + "," + resultCodeName + "," + remark + "," + "0");
        }

        private void endLwM2MTC(string tcindex, string logId, string resultCode, string resultCodeName, string remark)
        {
            lwm2mtc index = (lwm2mtc)Enum.Parse(typeof(lwm2mtc), tcindex);
            int idx = (int)index;

            if (resultCode == string.Empty || resultCode == "20000000")
            {
                if (logId == string.Empty)
                    logPrintTC(lwm2mtclist[tcindex],"성공", string.Empty);
                else
                    logPrintTC(lwm2mtclist[tcindex],"성공",logId);

                if (listView2.Items[idx].SubItems[0].Text != "FAIL")
                    SetTextlist2(listView2, idx.ToString() + "," + "PASS" + "," + resultCode + "," + logId + "," + resultCodeName + "," + remark + "," + "1");
            }
            else
            {
                if (logId == string.Empty)
                    logPrintTC(lwm2mtclist[tcindex],"실패", string.Empty);
                else
                    logPrintTC(lwm2mtclist[tcindex],"실패", logId);

                SetTextlist2(listView2, idx.ToString() + "," + "FAIL" + "," + resultCode + "," + logId + "," + resultCodeName + "," + remark + "," + "2");
            }
        }

        private void SetTextlist2(Control ctr, string txtValue)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (ctr.InvokeRequired)
            {
                Ctr_Involk CI = new Ctr_Involk(SetTextlist2);
                ctr.Invoke(CI, ctr, txtValue);
            }
            else
            {
                string[] str = txtValue.Split(',');
                int idx1 = Convert.ToInt32(str[0]);
                listView2.Items[idx1].SubItems[1].Text = str[1];
                listView2.Items[idx1].SubItems[2].Text = str[2];
                listView2.Items[idx1].SubItems[3].Text = str[3];
                listView2.Items[idx1].SubItems[4].Text = str[4];
                listView2.Items[idx1].SubItems[5].Text = str[5];

                if (str[6] == "1")
                    listView2.Items[idx1].BackColor = Color.LightBlue;
                else if (str[6] == "2")
                    listView2.Items[idx1].BackColor = Color.OrangeRed;
                else
                    listView2.Items[idx1].BackColor = Color.White;
            }
        }

        private void startoneM2MTC(string tcindex)
        {
            logPrintTC(onem2mtclist[tcindex],"시작", string.Empty);
            onem2mtc index = (onem2mtc)Enum.Parse(typeof(onem2mtc), tcindex);
            int idx = (int)index;
            if (listView1.Items[idx].SubItems[0].Text != "FAIL")
                SetTextlist1(listView1, idx.ToString() + "," +"START" + "," + string.Empty + "," + string.Empty + "," + string.Empty + "," + string.Empty + "," + "0");
        }

        private void endoneM2MTC(string tcindex, string logId, string resultCode, string resultCodeName, string remark)
        {
            onem2mtc index = (onem2mtc)Enum.Parse(typeof(onem2mtc), tcindex);
            int idx = (int)index;

            if (resultCode == string.Empty || resultCode == "20000000")
            {
                if (logId == string.Empty)
                    logPrintTC(onem2mtclist[tcindex],"성공", string.Empty);
                else
                    logPrintTC(onem2mtclist[tcindex],"성공",logId);

                if (listView1.Items[idx].SubItems[0].Text != "FAIL")
                    SetTextlist1(listView1, idx.ToString() + "," + "PASS" + "," + resultCode + "," + logId + "," + resultCodeName + "," + remark + "," + "1");
            }
            else if (resultCode == "20000200")
            {
                SetTextlist1(listView1, idx.ToString() + "," + "N/A" + "," + resultCode + "," + logId + "," + resultCodeName + "," + remark + "," + "3");
            }
            else
            {
                if (logId == string.Empty)
                    logPrintTC(onem2mtclist[tcindex],"실패", string.Empty);
                else
                    logPrintTC(onem2mtclist[tcindex],"실패",logId);

                SetTextlist1(listView1, idx.ToString() + "," + "FAIL" + "," + resultCode + "," + logId + "," + resultCodeName + "," + remark + "," + "2");
            }
        }

        private void SetTextlist1(Control ctr, string txtValue)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (ctr.InvokeRequired)
            {
                Ctr_Involk CI = new Ctr_Involk(SetTextlist1);
                ctr.Invoke(CI, ctr, txtValue);
            }
            else
            {
                string[] str = txtValue.Split(',');
                int idx1 = Convert.ToInt32(str[0]);
                listView1.Items[idx1].SubItems[1].Text = str[1];
                listView1.Items[idx1].SubItems[2].Text = str[2];
                listView1.Items[idx1].SubItems[3].Text = str[3];
                listView1.Items[idx1].SubItems[4].Text = str[4];
                listView1.Items[idx1].SubItems[5].Text = str[5];

                if (str[6] == "1")
                    listView1.Items[idx1].BackColor = Color.LightBlue;
                else if (str[6] == "2")
                    listView1.Items[idx1].BackColor = Color.OrangeRed;
                else if (str[6] == "3")
                {
                    listView1.Items[idx1].BackColor = Color.White;
                    listView1.Items[idx1].ForeColor = Color.Gray;
                }
                else
                    listView1.Items[idx1].BackColor = Color.White;
            }
        }

        // 시험절차서 시험 결과를 tbTCResult에 표시.
        public void logPrintTC(string message, string result, string logID)
        {
            BeginInvoke(new Action(() =>
            {
                string time = DateTime.Now.ToString("hh:mm:ss");

                ListViewItem newitem = new ListViewItem(new string[] { time, lbActionState.Text, message, result, logID});
                listView6.Items.Add(newitem);
                if (result == "실패")
                    listView6.Items[listView6.Items.Count - 1].BackColor = Color.Orange;
                if (listView6.Items.Count > 20)
                    listView6.TopItem = listView6.Items[listView6.Items.Count - 1];
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

                LogWrite(wReq.Method + " " + wReq.RequestUri,"T");
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
                    LogWrite((int)wRes.StatusCode + " " + wRes.StatusCode.ToString(), "R");
                    Console.WriteLine("HTTP/1.1 " + (int)wRes.StatusCode + " " + wRes.StatusCode.ToString());
                    Console.WriteLine("");
                    for (int i = 0; i < wRes.Headers.Count; ++i)
                        Console.WriteLine("[" + wRes.Headers.Keys[i] + "] " + wRes.Headers[i]);
                    Console.WriteLine("");

                    Stream respPostStream = wRes.GetResponseStream();
                    StreamReader readerPost = new StreamReader(respPostStream, Encoding.GetEncoding("UTF-8"), true);
                    resResult = readerPost.ReadToEnd();
                    if (resResult.StartsWith("[") || resResult.StartsWith("{"))
                    {
                        string beautifiedJson = JValue.Parse(resResult).ToString((Newtonsoft.Json.Formatting)Formatting.Indented);
                        Console.WriteLine(beautifiedJson);
                    }
                    else
                        Console.WriteLine(resResult);
                    Console.WriteLine("");
                }
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError && ex.Response != null)
                {
                    var resp = (HttpWebResponse)ex.Response;
                    LogWrite((int)resp.StatusCode + " " + resp.StatusCode.ToString(), "R");
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

        private void getSvrEventLog(string tlogid, string tresultCode, string tresultCodeName)
        {
            label21.Text = "서버로그 ID : " + tlogid + " 상세내역";

            // oneM2M log server 응답 확인 (resultcode)
            ReqHeader header = new ReqHeader();
            header.Url = logUrl + "/apilog?logId=" + tlogid;
            //header.Url = logUrl + "/apilog?Id=61";
            header.Method = "GET";
            header.ContentType = "application/json";
            header.X_M2M_RI = DateTime.Now.ToString("yyyyMMddHHmmss") + "LogDetail";
            header.X_M2M_Origin = svr.entityId;
            header.X_MEF_TK = svr.token;
            header.X_MEF_EKI = svr.enrmtKeyId;
            string retStr = GetHttpLog(header, string.Empty);

            listView9.Items.Clear();
            listView10.Items.Clear();

            if (retStr != string.Empty)
            {
                //LogWriteNoTime(retStr);
                try
                {
                    JArray jarr = JArray.Parse(retStr); //json 객체로

                    foreach (JObject jobj in jarr)
                    {
                        string time = jobj["logTime"].ToString();
                        string logtime = time.Substring(8, 2) + ":" + time.Substring(10, 2) + ":" + time.Substring(12, 2);
                        var pathInfo = jobj["pathInfo"] ?? " ";
                        var resType = jobj["resType"] ?? " ";
                        var trgAddr = jobj["trgAddr"] ?? " ";
                        var logType = jobj["logType"] ?? " ";
                        var logId = jobj["logId"] ?? " ";
                        var resultCode = jobj["resultCode"] ?? " ";
                        var resultCodeName = jobj["resultCodeName"] ?? " ";
                        var oprType = jobj["oprType"] ?? " ";

                        string path = pathInfo.ToString();
                        if (path == " ")
                            path = jobj["resType"].ToString() + " : " + trgAddr.ToString();

                        tcmsg = string.Empty;
                        OneM2MTcResultReport(path, jobj["logId"].ToString(), jobj["resultCode"].ToString(), jobj["resultCodeName"].ToString(), resType.ToString(), trgAddr.ToString(), oprType.ToString());

                        ListViewItem newitem = new ListViewItem(new string[] { logtime, logId.ToString(), tcmsg, resultCode.ToString(), resultCodeName.ToString() + " (" + logType.ToString() + " => " + path + ")" });
                        listView9.Items.Add(newitem);
                    }

                    if (listView9.Items.Count > 0)
                    {
                        listView9.Items[0].Focused = true;
                        listView9.Items[0].Selected = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        private void btnMEFAuth_Click(object sender, EventArgs e)
        {
            svr.svcSvrCd = tbSvcSvrCd.Text; // 서비스 서버의 시퀀스
            svr.svcCd = tbSvcCd.Text; // 서비스 서버의 서비스코드
            svr.svcSvrNum = tbSvcSvrNum.Text; // 서비스 서버의 Number
            RequestMEF();
        }

        // 1. MEF 인증
        private void RequestMEF()
        {
            ReqHeader header = new ReqHeader();
            header.Url = mefUrl + "/mef/server";
            header.Method = "POST";
            header.ContentType = "application/xml";
            header.X_M2M_RI = string.Empty;
            header.X_M2M_Origin = string.Empty;
            header.X_MEF_TK = string.Empty;
            header.X_MEF_EKI = string.Empty;
            header.X_M2M_NM = string.Empty;

            XDocument xdoc = new XDocument(new XDeclaration("1.0", "UTF-8", null));
            XElement xroot = new XElement("auth");
            xdoc.Add(xroot);

            XElement xparams = new XElement("svcSvrCd", svr.svcSvrCd);
            xroot.Add(xparams);
            xparams = new XElement("svcCd", svr.svcCd);
            xroot.Add(xparams);
            xparams = new XElement("svcSvrNum", svr.svcSvrNum);
            xroot.Add(xparams);
            /*
            string packetStr = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
            packetStr += "<auth>";
            packetStr += "<svcSvrCd>" + svr.svcSvrCd + "</svcSvrCd>";
            packetStr += "<svcCd>" + svr.svcCd + "</svcCd>";
            packetStr += "<svcSvrNum>" + svr.svcSvrNum + "</svcSvrNum>";
            packetStr += "</auth>";
            */

            string retStr = SendHttpRequest(header, xdoc.ToString()); // xml
            if (retStr != string.Empty)
            {
                ParsingXml(retStr);

                string nameCSR = svr.entityId.Replace("-", "");
                svr.remoteCSEName = "csr-" + nameCSR;
                //LogWrite("svr.remoteCSEName = " + svr.remoteCSEName);
            }
        }

        private void ParsingXml(string xml)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(xml);
            //LogWrite(xDoc.OuterXml.ToString());

            XmlNodeList xnList = xDoc.SelectNodes("/authdata/http"); //접근할 노드
            foreach (XmlNode xn in xnList)
            {
                svr.enrmtKey = xn["enrmtKey"].InnerText; // oneM2M 인증 KeyID를 생성하기 위한 Key
                svr.entityId = xn["entityId"].InnerText; // oneM2M에서 사용하는 단말 ID
                svr.token = xn["token"].InnerText; // 인증구간 통신을 위해 발급하는 Token
            }
            Console.WriteLine("svr enrmtKey = " + svr.enrmtKey);
            Console.WriteLine("svr entityId = " + svr.entityId);
            Console.WriteLine("svr token = " + svr.token);

            label23.Text = svr.entityId;

            // EKI값 계산하기
            // short uuid구하기
            string suuid = svr.entityId.Substring(10, 10);
            //LogWrite("suuid = " + suuid);

            // KeyData Base64URL Decoding
            string output = svr.enrmtKey;
            output = output.Replace('-', '+'); // 62nd char of encoding
            output = output.Replace('_', '/'); // 63rd char of encoding

            switch (output.Length % 4) // Pad with trailing '='s
            {
                case 0:
                    break; // No pad chars in this case
                case 2:
                    output += "==";
                    break; // Two pad chars
                case 3:
                    output += "=";
                    break; // One pad char
                default:
                    throw new ArgumentOutOfRangeException(
                        nameof(svr.enrmtKey), "Illegal base64url string!");
            }

            var converted = Convert.FromBase64String(output); // Standard base64 decoder

            // keyData로 AES 128비트 비밀키 생성
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
            AesManaged tdes = new AesManaged();
            tdes.Key = converted;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform crypt = tdes.CreateEncryptor();
            byte[] plain = Encoding.UTF8.GetBytes(suuid);
            byte[] cipher = crypt.TransformFinalBlock(plain, 0, plain.Length);
            String enrmtKeyId = Convert.ToBase64String(cipher);

            enrmtKeyId = enrmtKeyId.Split('=')[0]; // Remove any trailing '='s
            enrmtKeyId = enrmtKeyId.Replace('+', '-'); // 62nd char of encoding
            enrmtKeyId = enrmtKeyId.Replace('/', '_'); // 63rd char of encoding

            svr.enrmtKeyId = enrmtKeyId;
            //LogWrite("svr.enrmtKeyId = " + svr.enrmtKeyId);
        }

        delegate void Ctr_Involk(Control ctr, string text);

        private void SetText(Control ctr, string txtValue)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (ctr.InvokeRequired)
            {
                Ctr_Involk CI = new Ctr_Involk(SetText);
                ctr.Invoke(CI, ctr, txtValue);
            }
            else
            {
                ctr.Text = txtValue;
            }
        }

        public string SendHttpRequest(ReqHeader header, string data)
        {
            string resResult = string.Empty;

            try
            {
                wReq = (HttpWebRequest)WebRequest.Create(header.Url);
                wReq.Method = header.Method;
                if (header.Accept != string.Empty)
                    wReq.Accept = header.Accept;
                if (header.ContentType != string.Empty)
                    wReq.ContentType = header.ContentType;
                if (header.X_M2M_RI != string.Empty)
                    wReq.Headers.Add("X-M2M-RI", header.X_M2M_RI);
                if (header.X_M2M_Origin != string.Empty)
                    wReq.Headers.Add("X-M2M-Origin", header.X_M2M_Origin);
                if (header.X_M2M_NM != string.Empty)
                    wReq.Headers.Add("X-M2M-NM", header.X_M2M_NM);
                if (header.X_MEF_TK != string.Empty)
                    wReq.Headers.Add("X-MEF-TK", header.X_MEF_TK);
                if (header.X_MEF_EKI != string.Empty)
                    wReq.Headers.Add("X-MEF-EKI", header.X_MEF_EKI);

                LogWrite(wReq.Method + " " + wReq.RequestUri,"T");
                Console.WriteLine(wReq.Method + " " + wReq.RequestUri + " HTTP/1.1");
                Console.WriteLine("");
                for (int i = 0; i < wReq.Headers.Count; ++i)
                    Console.WriteLine(wReq.Headers.Keys[i] + ": " + wReq.Headers[i]);
                Console.WriteLine("");
                Console.WriteLine(data);
                Console.WriteLine("");

                // POST 전송일 경우      
                if (header.Method == "POST")
                {
                    byte[] byteArray = Encoding.UTF8.GetBytes(data);
                    Stream dataStream = wReq.GetRequestStream();
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    dataStream.Close();
                }

                wReq.Timeout = 20000;          // 서버 응답을 20초동안 기다림
                using (wRes = (HttpWebResponse)wReq.GetResponse())
                {
                    LogWrite((int)wRes.StatusCode + " " + wRes.StatusCode.ToString(),"R");
                    Console.WriteLine("HTTP/1.1 " + (int)wRes.StatusCode + " " + wRes.StatusCode.ToString());
                    Console.WriteLine("");
                    for (int i = 0; i < wRes.Headers.Count; ++i)
                        Console.WriteLine("[" + wRes.Headers.Keys[i] + "] " + wRes.Headers[i]);
                    Console.WriteLine("");

                    Stream respPostStream = wRes.GetResponseStream();
                    StreamReader readerPost = new StreamReader(respPostStream, Encoding.GetEncoding("UTF-8"), true);
                    resResult = readerPost.ReadToEnd();
                    if (resResult.StartsWith("<?xml"))
                    {
                        XmlDocument xDoc = new XmlDocument();
                        xDoc.LoadXml(resResult);
                        StringWriter writer = new StringWriter();
                        xDoc.Save(writer);
                        Console.WriteLine(writer.ToString());
                    }
                    else if (resResult.StartsWith("{") || resResult.StartsWith("["))
                    {
                        string beautifiedJson = JValue.Parse(resResult).ToString((Newtonsoft.Json.Formatting)Formatting.Indented);
                        Console.WriteLine(beautifiedJson);
                    }
                    else
                        Console.WriteLine(resResult);
                    Console.WriteLine("");
                }
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError && ex.Response != null)
                {
                    var resp = (HttpWebResponse)ex.Response;
                    LogWrite((int)resp.StatusCode + " " + resp.StatusCode.ToString(),"R");
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
                    //Console.WriteLine("[" + (int)resp.StatusCode + "] " + resp.StatusCode.ToString());
                }
                else
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            return resResult;
        }

        private void LogWrite(string data, string dir)
        {
            BeginInvoke(new Action(() =>
            {
                string time = DateTime.Now.ToString("hh:mm:ss");

                ListViewItem newitem = new ListViewItem(new string[] { time, lbActionState.Text, dir, data });
                listView7.Items.Add(newitem);
                if (listView7.Items.Count > 35)
                    listView7.TopItem = listView7.Items[listView7.Items.Count - 1];
            }));
        }

        private void LogWriteNoTime(string data)
        {
            BeginInvoke(new Action(() =>
            {
                /*
                tbLog.AppendText(Environment.NewLine);
                if (data.StartsWith("<?xml"))
                {
                    XmlDocument xDoc = new XmlDocument();
                    xDoc.LoadXml(data);
                    StringWriter writer = new StringWriter();
                    xDoc.Save(writer);
                    tbLog.AppendText(writer.ToString());
                }
                else
                    tbLog.AppendText(" " + data);
                tbLog.SelectionStart = tbLog.TextLength;
                tbLog.ScrollToCaret();
                */

                ListViewItem newitem = new ListViewItem(new string[] { string.Empty, string.Empty, string.Empty, data });
                listView7.Items.Add(newitem);
                if (listView7.Items.Count > 35)
                    listView7.TopItem = listView7.Items[listView7.Items.Count - 1];
            }));
        }

        private void button127_Click(object sender, EventArgs e)
        {
            if (svr.entityId != string.Empty)
                getSvrLoglists("entityId=" + svr.entityId, "man");
            else
                MessageBox.Show("서비스서버 MEF인증 후 사용이 가능합니다");
        }

        private void button126_Click(object sender, EventArgs e)
        {
            ReqHeader header = new ReqHeader();
            header.Url = logUrl + "/resultCode?value=" + tBResultCode.Text;
            header.Method = "GET";
            header.ContentType = "application/json";
            header.X_M2M_RI = DateTime.Now.ToString("yyyyMMddHHmmss") + "ResultCode";
            header.X_M2M_Origin = svr.entityId;
            header.X_MEF_TK = svr.token;
            header.X_MEF_EKI = svr.enrmtKeyId;
            string retStr = GetHttpLog(header, string.Empty);
            if (retStr != string.Empty)
            {
                //LogWriteNoTime(retStr);
                try
                {
                    JObject obj = JObject.Parse(retStr);

                    var resultCode = obj["resultCode"] ?? tBResultCode.Text;
                    var codeName = obj["codeName"] ?? "NULL";
                    var desc = obj["desc"] ?? "NULL";

                    MessageBox.Show("message = " + codeName.ToString() + "\ndescription = " + desc.ToString(), "Resultcode=" + resultCode.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            else
                MessageBox.Show("message = " + "Unknown" + "\ndescription = " + "Resultcode 값이 존재하지 않습니다.", "Resultcode=" + tBResultCode.Text);
        }

        private void button124_Click(object sender, EventArgs e)
        {
                if (tbDeviceCTN.Text != string.Empty)
                {
                    ReqHeader header = new ReqHeader();
                    header.Url = logUrl + "/device?ctn=" + tbDeviceCTN.Text;
                    //header.Url = logUrl + "/device?ctn=99977665825";
                    header.Method = "GET";
                    header.ContentType = "application/json";
                    header.X_M2M_RI = DateTime.Now.ToString("yyyyMMddHHmmss") + "DeviceGet";
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

                            JObject obj = JObject.Parse(jarr[0].ToString());

                            var ctn = obj["ctn"] ?? tbDeviceCTN.Text;
                            var deviceModel = obj["deviceModel"] ?? " ";
                            var modemModel = obj["modemModel"] ?? " ";
                            var serviceCode = obj["serviceCode"] ?? " ";
                            var deviceSerialNo = obj["deviceSerialNo"] ?? " ";
                            var iccId = obj["iccId"] ?? " ";
                            var m2mmType = obj["m2mmType"] ?? " ";

                        if (serialPort1.IsOpen == false)
                        {
                            if (iccId.ToString() != " ")
                            {
                                tBoxDeviceModel.Text = deviceModel.ToString();
                                tbDeviceName.Text = textBox86.Text = dev.model = modemModel.ToString();
                                tbSvcCd.Text = serviceCode.ToString();
                                tBoxDeviceSN.Text = deviceSerialNo.ToString();

                                if (m2mmType.ToString().StartsWith("ONEM2M"))
                                {
                                    comboBox1.SelectedIndex = 0;

                                    listView1.Items.Clear();
                                    foreach (string tcindex in Enum.GetNames(typeof(onem2mtc)))
                                    {
                                        ListViewItem newitem = new ListViewItem(new string[] { onem2mtclist[tcindex], "Not TEST", string.Empty, string.Empty, string.Empty, string.Empty });
                                        listView1.Items.Add(newitem);
                                    }
                                }
                                else
                                {
                                    comboBox1.SelectedIndex = 1;

                                    listView2.Items.Clear();
                                    foreach (string tcindex in Enum.GetNames(typeof(lwm2mtc)))
                                    {
                                        ListViewItem newitem = new ListViewItem(new string[] { lwm2mtclist[tcindex], "Not TEST", string.Empty, string.Empty, string.Empty, string.Empty });
                                        listView2.Items.Add(newitem);
                                    }
                                }

                                tbDeviceCTN.Text = tBProxy304.Text = dev.imsi = ctn.ToString();
                                lbIccid.Text = dev.iccid = iccId.ToString();
                                setDeviceEntityID();

                                MessageBox.Show("디바이스 모델명 : " + deviceModel.ToString() + "\n모듈 모델명 : " + modemModel.ToString() + "\n서비스코드 : "
                                    + serviceCode.ToString() + "\n디바이스 일련번호 : " + deviceSerialNo.ToString() + "\nICCID : " + iccId.ToString() + "\nTYPE : " + m2mmType.ToString(),
                                    ctn.ToString() + " DEVICE 상태 정보");
                            }
                            else
                                MessageBox.Show("디바이스 정보가 없습니다.\nhttps://testadm.onem2m.uplus.co.kr:8443 에서 확인바랍니다.", ctn.ToString() + " DEVICE 상태 정보");
                        }
                        else
                            MessageBox.Show("모듈이 연결된 상태에서는 동작하지 않습니다.");


                        GetPlatformFWVer("NO");
                    }
                    catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                            MessageBox.Show("DEVICE 정보가 존재하지 않습니다.\nhttps://testadm.onem2m.uplus.co.kr:8443 에서 확인바랍니다.", tBProxy304.Text + " DEVICE 상태 정보");
                        }
                    }
                    else
                        MessageBox.Show("DEVICE 정보가 존재하지 않습니다.\nhttps://testadm.onem2m.uplus.co.kr:8443 에서 확인바랍니다.", tBProxy304.Text + " DEVICE 상태 정보");
                }
                else
                    MessageBox.Show("CTN 정보가 없습니다.\nCTN을 확인하세요");
        }

        private void setDeviceEntityID()
        {
            if (dev.imsi != null && dev.imsi.Length == 11)
            {
                String md5value = getMd5Hash(dev.imsi + dev.iccid);
                //logPrintInTextBox(md5value, "");
                dev.uuid = md5value;

                string epn = md5value.Substring(0, 5) + md5value.Substring(md5value.Length - 5, 5);
                string entityid = "ASN_CSE-D-" + epn + "-" + tbSvcCd.Text;

                if (dev.entityId != entityid)
                {
                    dev.entityId = entityid;
                    SetText(lbDevEntityId, dev.entityId);
                    logPrintInTextBox("Device EntityID가 " + dev.entityId + "수정되었습니다.", "");
                }

                endLwM2MTC("tc0201", string.Empty, string.Empty, string.Empty, string.Empty);
            }
            else
                MessageBox.Show("CTN이 등록되어 있지 않습니다. 확인이 필요합니다.");
        }

        // Hash an input string and return the hash as
        // a 32 character hexadecimal string.
        static string getMd5Hash(string input)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5 md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        private void GetPlatformFWVer(string mode)
        {
            ReqHeader header = new ReqHeader();
            header.Url = logUrl + "/Firmware?entityId=" + dev.entityId;
            //header.Url = logUrl + "/Firmware?entityId=ASN_CSE-D-71221153fb-T001";
            header.Method = "GET";
            header.ContentType = "application/json";
            header.X_M2M_RI = DateTime.Now.ToString("yyyyMMddHHmmss") + "FWVerGet";
            header.X_M2M_Origin = svr.entityId;
            header.X_MEF_TK = svr.token;
            header.X_MEF_EKI = svr.enrmtKeyId;
            string retStr = GetHttpLog(header, string.Empty);

            if (retStr != string.Empty)
            {
                //LogWriteNoTime(retStr);

                try
                {
                    JObject obj = JObject.Parse(retStr);
                    if (mode == "YES")
                    {

                        var deviceVer = obj["deviceVersion"] ?? "unknown";
                        label10.Text = deviceVer.ToString();

                        var modemVer = obj["modemVersion"] ?? "unknown";
                        label8.Text = modemVer.ToString();

                        string state = "대기중";
                        var inProgress = obj["inProgress"] ?? "unknown";
                        if (inProgress.ToString() == "true")
                            state = "진행 중";
                        var deviceModel = obj["deviceModel"] ?? "unknown";
                        var lastCheckTime = obj["lastCheckTime"] ?? "unknown";
                        var lastDeviceCheckTime = obj["lastDeviceCheckTime"] ?? "unknown";
                        var lastUpdateTime = obj["lastUpdateTime"] ?? "unknown";

                        MessageBox.Show("디바이스 모델명 : " + deviceModel.ToString() + "\n진행상태 : " + state + "\n\n디바이스 버전 : " + deviceVer.ToString()
                            + "\n디바이스 체크시간 : " + lastDeviceCheckTime.ToString() + "\n\n모듈 버전 : " + modemVer.ToString()
                            + "\n모듈 체크시간 : " + lastCheckTime.ToString() + "\n\n업데이트 시간 : " + lastUpdateTime.ToString(), "펌웨어 업데이트 진행 상태");
                    }

                    var cellId = obj["cellId"] ?? "none";
                    var networkType = obj["networkType"] ?? "none";
                    label49.Text = cellId.ToString() + "/" + networkType.ToString();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        private void button123_Click(object sender, EventArgs e)
        {
            getSvrEventLog(textBox95.Text, string.Empty, string.Empty);
        }

        private void button122_Click(object sender, EventArgs e)
        {
            getSvrDetailLog(textBox94.Text, string.Empty, string.Empty, string.Empty);
        }

        private void btnDeviceCheck_Click(object sender, EventArgs e)
        {
            if (svr.enrmtKeyId != string.Empty)
            {
                if (lbDevEntityId.Text != ".")
                {
                    RetriveDverToPlatform();
                    RetriveMverToPlatform();
                }
                else
                    MessageBox.Show("CTN이 등록되어 있지 않습니다.확인이 필요합니다.");
            }
            else
                MessageBox.Show("서버인증파라미터 세팅하세요");
        }

        private void RetriveDverToPlatform()
        {
            ReqHeader header = new ReqHeader();
            //header.Url = brkUrl + "/IN_CSE-BASE-1/cb-1/csr-m2m_01222990847";
            if (comboBox2.SelectedIndex == 1)
                header.Url = brkUrl + "/IN_CSE-BASE-1/cb-1/csr-m2m_" + dev.imsi + "/nod-m2m_" + dev.imsi + "/fwr-m2m_D" + dev.imsi;
            else
                header.Url = brkUrl + "/IN_CSE-BASE-1/cb-1/csr-m2m_" + dev.imsi + "/nod-m2m_" + dev.imsi + "/fwr-m2m_D_" + dev.imsi;
            header.Method = "GET";
            header.X_M2M_Origin = svr.entityId;
            header.X_M2M_RI = DateTime.Now.ToString("yyyyMMddHHmmss") + "device_CSR_retrive";
            header.X_MEF_TK = svr.token;
            header.X_MEF_EKI = svr.enrmtKeyId;
            header.X_M2M_NM = string.Empty;
            header.Accept = "application/xml";
            header.ContentType = string.Empty;

            string retStr = SendHttpRequest(header, string.Empty);
            if (retStr != string.Empty)
            {
                string value = string.Empty;

                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(retStr);
                //LogWrite(xDoc.OuterXml.ToString());

                XmlNodeList xnList = xDoc.SelectNodes("/*"); //접근할 노드
                foreach (XmlNode xn in xnList)
                {
                    value = xn["vr"].InnerText; // data value
                }
                lbdevicever.Text = value;
            }
        }

        private void RetriveMverToPlatform()
        {
            ReqHeader header = new ReqHeader();
            //header.Url = brkUrl + "/IN_CSE-BASE-1/cb-1/csr-m2m_01222990847";
            if (comboBox2.SelectedIndex == 0)
                header.Url = brkUrl + "/IN_CSE-BASE-1/cb-1/csr-m2m_" + dev.imsi + "/nod-m2m_" + dev.imsi + "/fwr-m2m_" + dev.imsi;
            else if (comboBox2.SelectedIndex == 1)
                header.Url = brkUrl + "/IN_CSE-BASE-1/cb-1/csr-m2m_" + dev.imsi + "/nod-m2m_" + dev.imsi + "/fwr-m2m_M" + dev.imsi;
            else
                header.Url = brkUrl + "/IN_CSE-BASE-1/cb-1/csr-m2m_" + dev.imsi + "/nod-m2m_" + dev.imsi + "/fwr-m2m_M_" + dev.imsi;
            header.Method = "GET";
            header.X_M2M_Origin = svr.entityId;
            header.X_M2M_RI = DateTime.Now.ToString("yyyyMMddHHmmss") + "device_CSR_retrive";
            header.X_MEF_TK = svr.token;
            header.X_MEF_EKI = svr.enrmtKeyId;
            header.X_M2M_NM = string.Empty;
            header.Accept = "application/xml";
            header.ContentType = string.Empty;

            string retStr = SendHttpRequest(header, string.Empty);
            if (retStr != string.Empty)
            {
                string value = string.Empty;

                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(retStr);
                //LogWrite(xDoc.OuterXml.ToString());

                XmlNodeList xnList = xDoc.SelectNodes("/*"); //접근할 노드
                foreach (XmlNode xn in xnList)
                {
                    value = xn["vr"].InnerText; // data value
                }
                lbmodemfwrver.Text = value;
            }
        }

        private void tbSvcCd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dev.entityId != string.Empty)
                    setDeviceEntityID();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox54.Text);
            startLwM2MTC("tc0301", string.Empty, string.Empty, string.Empty, textBox54.Text);
            lbActionState.Text = states.registertpb23.ToString();
        }

        private void button125_Click(object sender, EventArgs e)
        {
            firmwareInitial("man");
        }

        private void firmwareInitial(string mode)
        {
            if (dev.entityId != string.Empty)
            {
                ReqHeader header = new ReqHeader();
                header.Url = logUrl + "/initFirmware?entityId=" + dev.entityId;
                //header.Url = logUrl + "/initFirmware?entityId=ASN_CSE-D-71221153fb-T001";
                header.Method = "GET";
                header.ContentType = "application/json";
                header.X_M2M_RI = DateTime.Now.ToString("yyyyMMddHHmmss") + "FWVerInit";
                header.X_M2M_Origin = svr.entityId;
                header.X_MEF_TK = svr.token;
                header.X_MEF_EKI = svr.enrmtKeyId;
                string retStr = GetHttpLog(header, string.Empty);

                if (retStr != string.Empty && mode == "man")
                {
                    //LogWriteNoTime(retStr);

                    try
                    {
                        string state = "대기중";
                        JObject obj = JObject.Parse(retStr);

                        var deviceVer = obj["deviceVersion"] ?? "unknown";
                        lbdevicever.Text = deviceVer.ToString();

                        var modemVer = obj["modemVersion"] ?? "unknown";
                        lbmodemfwrver.Text = modemVer.ToString();

                        var inProgress = obj["inProgress"] ?? "unknown";
                        if (inProgress.ToString() == "true")
                            state = "진행 중";
                        var deviceModel = obj["deviceModel"] ?? "unknown";
                        var lastCheckTime = obj["lastCheckTime"] ?? "unknown";
                        var lastDeviceCheckTime = obj["lastDeviceCheckTime"] ?? "unknown";
                        var lastUpdateTime = obj["lastUpdateTime"] ?? "unknown";

                        MessageBox.Show("디바이스 모델명 : " + deviceModel.ToString() + "\n진행상태 : " + state + "\n\n디바이스 버전 : " + deviceVer.ToString()
                            + "\n디바이스 체크시간 : " + lastDeviceCheckTime.ToString() + "\n\n모듈 버전 : " + modemVer.ToString()
                            + "\n모듈 체크시간 : " + lastCheckTime.ToString() + "\n\n업데이트 시간 : " + lastUpdateTime.ToString(), "펌웨어 업데이트 진행 상태");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
            else
                MessageBox.Show("모듈 정보가 없습니다.\n모듈 EntityID를 확인하세요.");
        }

        private void btnBootstrap_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox67.Text);
            startLwM2MTC("tc0202", string.Empty, string.Empty, string.Empty, textBox67.Text);
            lbActionState.Text = states.bootstrap.ToString();
        }

        private void button113_Click(object sender, EventArgs e)
        {
            svr.svcSvrCd = tbSvcSvrCd.Text; // 서비스 서버의 시퀀스
            svr.svcCd = tbSvcCd.Text; // 서비스 서버의 서비스코드
            svr.svcSvrNum = tbSvcSvrNum.Text; // 서비스 서버의 Number
            RequestMEF();

            firmwareInitial("auto");

            tcStartTime = DateTime.Now.AddMinutes(-1);
            dateTimePicker1.Value = tcStartTime;

            listView2.Items.Clear();
            foreach (string tcindex in Enum.GetNames(typeof(lwm2mtc)))
            {
                ListViewItem newitem = new ListViewItem(new string[] { lwm2mtclist[tcindex], "Not TEST", string.Empty, string.Empty, string.Empty, string.Empty });
                listView2.Items.Add(newitem);
            }

            this.sendDataOut(textBox71.Text);
            lbActionState.Text = states.lwm2mtc02011.ToString();
            nextresponse = textBox65.Text;
            nextcommand = string.Empty;
        }

        private void button98_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox56.Text);
            lbActionState.Text = states.setncdp.ToString();
        }

        private void button92_Click(object sender, EventArgs e)
        {
            setDeviceEntityID();
            string atcmd = textBox50.Text;
            if (checkBox6.Checked == true)
                atcmd += "\"";
            if (checkBox2.Checked == false)
                atcmd += dev.entityId;
            else
                atcmd += tbSvcCd.Text;
            if (checkBox6.Checked == true)
                atcmd += "\"";
            if (checkBox7.Checked == true)
            {
                if (checkBox6.Checked == true)
                    atcmd += ",\"";
                if (checkBox2.Checked == false)
                    atcmd += dev.entityId;
                else
                    atcmd += tbSvcCd.Text;
                if (checkBox6.Checked == true)
                    atcmd += "\"";
            }
            this.sendDataOut(atcmd);
            lbActionState.Text = states.setepnstpb23.ToString();
        }

        private void button97_Click(object sender, EventArgs e)
        {
            string epncmd = string.Empty;
            string epniccid = dev.iccid;

            if (comboBox4.SelectedIndex == 0)
            {
                //AT+MLWMBSPS="serviceCode=GAMR|deviceSerialNo=1234567|ctn=01022335078 | iccId = 127313 | deviceModel = Summer | mac = "
                epncmd = "serviceCode=" + tbSvcCd.Text + "|deviceSerialNo=";
                epncmd += tBoxDeviceSN.Text + "|ctn=";
                epncmd += dev.imsi + "|iccId=";

                string iccid = dev.iccid;
                epncmd += epniccid.Substring(epniccid.Length - 6, 6) + "|deviceModel=";
                epncmd += tBoxDeviceModel.Text + "|mac=";
            }
            else
            {
                //AT+QLWMBSPS=<service code>,<sn>,<ctn>,<iccid>,<device model>
                epncmd = "\"" + tbSvcCd.Text + "\",\"";
                epncmd += tBoxDeviceSN.Text + "\",\"";
                epncmd += dev.imsi + "\",\"";

                epncmd += epniccid.Substring(epniccid.Length - 6, 6) + "\",\"";
                epncmd += tBoxDeviceModel.Text + "\"";
            }

            this.sendDataOut(textBox55.Text + epncmd);
            lbActionState.Text = states.setmbspstpb23.ToString();
        }

        private void button105_Click(object sender, EventArgs e)
        {
            if (textBox66.Text != string.Empty)
            {
                this.sendDataOut(textBox66.Text);
                lbActionState.Text = states.bootstrapmodetpb23.ToString();
            }
        }

        private void button95_Click(object sender, EventArgs e)
        {
            string txData = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") + " LwM2M device";
            lbDevLwM2MData.Text = txData;

            if (checkBox8.Checked == true)
            {
                string hexOutput = StringToBCD(txData.ToCharArray());

                this.sendDataOut(textBox53.Text + hexOutput.Length / 2 + "," + hexOutput);
            }
            else
                this.sendDataOut(textBox53.Text + txData.Length + "," + txData);
            startLwM2MTC("tc0501", string.Empty, string.Empty, string.Empty, textBox53.Text);
            lbActionState.Text = states.sendmsghex.ToString();
        }

        private void btnDeregister_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox52.Text);
            startLwM2MTC("tc0401", string.Empty, string.Empty, string.Empty, textBox52.Text);
            lbActionState.Text = states.deregistertpb23.ToString();
            if (dev.model.StartsWith("BG95"))
                nextresponse = "+QLWDEREG: 0";
        }

        private void btnDeviceVerLwM2M_Click(object sender, EventArgs e)
        {
            DeviceFWVerSend();
            lbActionState.Text = states.sendmsgvertpb23.ToString();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox71.Text);
            lbActionState.Text = states.rfreset.ToString();
        }

        private void btnGetRemoteCSE_Click(object sender, EventArgs e)
        {
            if (svr.enrmtKeyId != string.Empty)
                ReqRemoteCSEGet();
            else
                MessageBox.Show("서버인증파라미터 세팅하세요");
        }

        private void ReqRemoteCSEGet()
        {
            ReqHeader header = new ReqHeader();
            header.Url = brkUrl + "/IN_CSE-BASE-1/cb-1/" + svr.remoteCSEName;
            header.Method = "GET";
            header.Accept = "application/vnd.onem2m-res+xml";
            header.X_M2M_RI = DateTime.Now.ToString("yyyyMMddHHmmss") + "RemoteCSE_Retrieve";
            header.X_M2M_Origin = svr.entityId;
            header.X_MEF_TK = svr.token;
            header.X_MEF_EKI = svr.enrmtKeyId;
            header.X_M2M_NM = string.Empty;
            string retStr = SendHttpRequest(header, string.Empty);
            if (retStr != string.Empty)
                LogWriteNoTime(retStr);
        }

        private void btnSetRemoteCSE_Click(object sender, EventArgs e)
        {
            if (svr.enrmtKeyId != string.Empty)
                ReqRemoteCSECreate();
            else
                MessageBox.Show("서버인증파라미터 세팅하세요");
        }

        // 3. RemoteCSE-Create
        private void ReqRemoteCSECreate()
        {
            ReqHeader header = new ReqHeader();
            header.Url = brkUrl + "/IN_CSE-BASE-1/cb-1";
            header.Method = "POST";
            header.Accept = "application/vnd.onem2m-res+xml";
            header.ContentType = "application/vnd.onem2m-res+xml;ty=16";
            header.X_M2M_RI = DateTime.Now.ToString("yyyyMMddHHmmss") + "RemoteCSE_Create";
            header.X_M2M_Origin = svr.entityId;
            header.X_MEF_TK = svr.token;
            header.X_MEF_EKI = svr.enrmtKeyId;
            header.X_M2M_NM = svr.remoteCSEName;

            string packetStr = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
            packetStr += "<m2m:csr xmlns:m2m=\"http://www.onem2m.org/xml/protocols\">";
            packetStr += "<cst>3</cst>";
            packetStr += "<csi>/" + svr.entityId + "</csi>";
            packetStr += "<cb>/" + svr.entityId + "/cb-1</cb>";
            packetStr += "<rr>true</rr>";
            packetStr += "<poa>" + tbSeverIP.Text + ":" + tbSeverPort.Text + "</poa>";
            packetStr += "</m2m:csr>";

            string retStr = SendHttpRequest(header, packetStr);
            //if (retStr != string.Empty)
            //    LogWrite(retStr);
        }

        private void btnDelRemoteCSE_Click(object sender, EventArgs e)
        {
            if (svr.enrmtKeyId != string.Empty)
                ReqRemoteCSEDEL();
            else
                MessageBox.Show("서버인증파라미터 세팅하세요");
        }

        // 3. RemoteCSE-Delete
        private void ReqRemoteCSEDEL()
        {
            ReqHeader header = new ReqHeader();
            header.Url = brkUrl + "/IN_CSE-BASE-1/cb-1/" + svr.remoteCSEName;
            header.Method = "DELETE";
            header.Accept = "application/vnd.onem2m-res+xml";
            header.X_M2M_RI = DateTime.Now.ToString("yyyyMMddHHmmss") + "RemoteCSE_Delete";
            header.X_M2M_Origin = svr.entityId;
            header.X_MEF_TK = svr.token;
            header.X_MEF_EKI = svr.enrmtKeyId;
            header.X_M2M_NM = string.Empty;
            string retStr = SendHttpRequest(header, string.Empty);
            //if (retStr != string.Empty)
            //    LogWrite(retStr);
        }

        private void btnDataRetrive_Click(object sender, EventArgs e)
        {
            if (svr.enrmtKeyId != string.Empty)
            {
                lbActionState.Text = states.sendonedevstr.ToString();
                RetriveDataToPlatform();
            }
            else
                MessageBox.Show("서버인증파라미터 세팅하세요");
        }

        private void RetriveDataToPlatform()
        {
            ReqHeader header = new ReqHeader();
            //header.Url = brkUrl + "/IN_CSE-BASE-1/cb-1/csr-m2m_01222990847/cnt-TEMP/la";
            header.Url = brkUrl + "/IN_CSE-BASE-1/cb-1/csr-m2m_" + tbDeviceCTN.Text + "/cnt-DtoS/la";
            header.Method = "GET";
            header.X_M2M_Origin = svr.entityId;
            header.X_M2M_RI = DateTime.Now.ToString("yyyyMMddHHmmss") + "data_retrive";
            header.X_MEF_TK = svr.token;
            header.X_MEF_EKI = svr.enrmtKeyId;
            header.X_M2M_NM = string.Empty;
            header.Accept = "application/xml";
            header.ContentType = string.Empty;

            string retStr = SendHttpRequest(header, string.Empty);
            if (retStr != string.Empty)
            {
                string format = string.Empty;
                string value = string.Empty;

                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(retStr);
                //LogWrite(xDoc.OuterXml.ToString());

                XmlNodeList xnList = xDoc.SelectNodes("/*"); //접근할 노드
                foreach (XmlNode xn in xnList)
                {
                    format = xn["cnf"].InnerText; // data format
                    value = xn["con"].InnerText; // data value
                }
                //LogWrite("value = " + value);
                //LogWrite("format = " + format);

                if (format == "application/octet-stream")
                    lboneM2MRxData.Text = Encoding.UTF8.GetString(Convert.FromBase64String(value));
                else
                    lboneM2MRxData.Text = value;

                if (lbActionState.Text == states.sendonemsgstrchk.ToString())
                {
                    if (lboneM2MRxData.Text == lbSendedData.Text)
                        endoneM2MTC("tc020504", string.Empty, string.Empty, string.Empty, string.Empty);
                    else
                        endoneM2MTC("tc020504", string.Empty, "20000100", lboneM2MRxData.Text, lbSendedData.Text);
                    lbActionState.Text = states.idle.ToString();
                }
                else if (lbActionState.Text == states.onem2mtc0205042.ToString())
                {
                    if (lboneM2MRxData.Text == lbSendedData.Text)
                        endoneM2MTC("tc020504", string.Empty, string.Empty, string.Empty, string.Empty);
                    else
                        endoneM2MTC("tc020504", string.Empty, "20000100", lbActionState.Text, lbSendedData.Text);

                    lbActionState.Text = states.onem2mtc0206011.ToString();
                    SendDataToPlatform();
                }
            }
        }

        private void btnSendData_Click(object sender, EventArgs e)
        {
            if (svr.enrmtKeyId != string.Empty)
            {
                lbActionState.Text = states.sendonedevdb.ToString();
                SendDataToPlatform();
            }
            else
                MessageBox.Show("서버인증파라미터 세팅하세요");
        }

        private void SendDataToPlatform()
        {
            ReqHeader header = new ReqHeader();

            header.Url = brkUrl + "/IN_CSE-BASE-1/cb-1/csr-m2m_" + tbDeviceCTN.Text + "/cnt-StoD";
            header.Method = "POST";
            header.X_M2M_Origin = svr.entityId;
            header.X_M2M_RI = DateTime.Now.ToString("yyyyMMddHHmmss") + "data_send";
            header.X_MEF_TK = svr.token;
            header.X_MEF_EKI = svr.enrmtKeyId;
            header.X_M2M_NM = string.Empty;
            header.Accept = "application/vnd.onem2m-res+xml";
            header.ContentType = "application/vnd.onem2m-res+xml;ty=4";

            string packetStr = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
            packetStr += "<m2m:cin xmlns:m2m=\"http://www.onem2m.org/xml/protocols\">";
            packetStr += "<cnf>text/plain</cnf>";

            string txData = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") + " server";
            packetStr += "<con>" + txData + "</con>";
            packetStr += "</m2m:cin>";

            SetText(label9, txData);
            string retStr = SendHttpRequest(header, packetStr);
            //if (retStr != string.Empty)
            //    LogWrite(retStr);
        }

        private void btnLwM2MData_Click(object sender, EventArgs e)
        {
            if (svr.enrmtKeyId != string.Empty)
            {
                if (lbDevEntityId.Text != ".")
                {
                    string[] param = { "lwm2m", "tc0502" };
                    rTh = new Thread(new ParameterizedThreadStart(SendDataToLwM2M));
                    rTh.Start(param);
                }
                else
                    MessageBox.Show("CTN이 등록되어 있지 않습니다.확인이 필요합니다.");
            }
            else
                MessageBox.Show("서버인증파라미터 세팅하세요");
        }

        private void SendDataToLwM2M(object param)
        {
            string[] data = param as string[];

            ReqHeader header = new ReqHeader();
            setDeviceEntityID();
            header.Url = brkUrlL + "/" + dev.entityId + "/10250/0/1";
            //header.Url = brkUrlL + "/IN_CSE-BASE-1/cb-1/" + deviceEntityId + "/10250/0/1";

            header.Method = "POST";
            header.X_M2M_Origin = svr.entityId;
            header.X_M2M_RI = DateTime.Now.ToString("yyyyMMddHHmmss") + "data_send";
            header.X_MEF_TK = svr.token;
            header.X_MEF_EKI = svr.enrmtKeyId;
            header.X_M2M_NM = string.Empty;
            header.Accept = "application/vnd.onem2m-res+xml";
            header.ContentType = "application/vnd.onem2m-res+xml;ty=4";

            string packetStr = "<m2m:cin xmlns:m2m=\"http://www.onem2m.org/xml/protocols\">";
            packetStr += "<cnf>text/plain</cnf>";
            string txData = string.Empty;
            txData = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") + " server";
            packetStr += "<con>" + txData + "</con>";
            packetStr += "</m2m:cin>";

            SetText(label40, txData);

            string retStr = SendHttpRequest(header, packetStr);
            //if (retStr != string.Empty)
            //    LogWrite(retStr);
        }

    private void btnDeviceStatusCheck_Click(object sender, EventArgs e)
        {
            if (svr.enrmtKeyId != string.Empty)
            {
                if (lbDevEntityId.Text != ".")
                {
                    string[] param = { "lwm2m" };
                    rTh = new Thread(new ParameterizedThreadStart(RetriveDataToLwM2M));
                    rTh.Start(param);
                }
                else
                    MessageBox.Show("CTN이 등록되어 있지 않습니다.확인이 필요합니다.");
            }
            else
                MessageBox.Show("서버인증파라미터 세팅하세요");
        }

        private void RetriveDataToLwM2M(object param)
        {
            string[] data = param as string[];

            ReqHeader header = new ReqHeader();
            setDeviceEntityID();
            header.Url = brkUrlL + "/" + dev.entityId + "/10250/0/0";

            header.Method = "GET";
            header.X_M2M_Origin = svr.entityId;
            header.X_M2M_RI = DateTime.Now.ToString("yyyyMMddHHmmss") + "data_retrive";
            header.X_MEF_TK = svr.token;
            header.X_MEF_EKI = svr.enrmtKeyId;
            header.X_M2M_NM = string.Empty;
            header.Accept = "application/xml";
            header.ContentType = string.Empty;

            string retStr = SendHttpRequest(header, string.Empty);
            if (retStr != string.Empty)
            {
                string format = string.Empty;
                string value = string.Empty;

                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(retStr);
                //LogWrite(xDoc.OuterXml.ToString());

                XmlNodeList xnList = xDoc.SelectNodes("/*"); //접근할 노드
                foreach (XmlNode xn in xnList)
                {
                    format = xn["cnf"].InnerText; // data format
                    value = xn["con"].InnerText; // data value
                }
                //LogWrite("value = " + value);
                //LogWrite("format = " + format);

                if (format == "application/octet-stream")
                {
                    if (value.Length % 4 == 1)
                    {
                        value += "===";
                    }
                    else if (value.Length % 4 == 2)
                    {
                        value += "==";
                    }
                    else if (value.Length % 4 == 3)
                    {
                        value += "=";
                    }
                    //LogWrite("value = " + value);
                    SetText(lbDirectRxData, Encoding.UTF8.GetString(Convert.FromBase64String(value)));
                }
                else
                    SetText(lbDirectRxData, value);

                if (lbDirectRxData.Text == lbSendedData.Text)
                {
                    endLwM2MTC("tc0503", string.Empty, string.Empty, string.Empty, string.Empty);
                }
                else
                {
                    endLwM2MTC("tc0503", string.Empty, "20000100", lbDirectRxData.Text, lbSendedData.Text);
                }

                if (lbActionState.Text == states.lwm2mtc0503.ToString())
                {
                    this.sendDataOut(textBox52.Text);
                    startLwM2MTC("tc0401", string.Empty, string.Empty, string.Empty, textBox52.Text);
                }
            }
            else
            {
                endLwM2MTC("tc0503", string.Empty, "20000100", string.Empty, "BAD RESPONSE");

                if (lbActionState.Text == states.lwm2mtc0503.ToString())
                {
                    this.sendDataOut(textBox52.Text);
                    startLwM2MTC("tc0401", string.Empty, string.Empty, string.Empty, textBox52.Text);
                }
            }
        }

        private void button93_Click(object sender, EventArgs e)
        {
            if (lbDevEntityId.Text == ".")
                MessageBox.Show("Device 정보가 없습니다.");
            else
                GetPlatformFWVer("YES");
        }

        private void button96_Click(object sender, EventArgs e)
        {
            if (svr.enrmtKeyId != string.Empty)
            {
                if (lbDevEntityId.Text != ".")
                {
                    string[] param = { "onem2m" };
                    rTh = new Thread(new ParameterizedThreadStart(RetriveDataToDevice));
                    rTh.Start(param);
                }
                else
                    MessageBox.Show("CTN이 등록되어 있지 않습니다.확인이 필요합니다.");
            }
            else
                MessageBox.Show("서버인증파라미터 세팅하세요");
        }

        private void RetriveDataToDevice(object param)
        {
            string[] data = param as string[];

            ReqHeader header = new ReqHeader();
            setDeviceEntityID();
            header.Url = brkUrl + "/" + dev.entityId + "/TEST";

            header.Method = "GET";
            header.X_M2M_Origin = svr.entityId;
            header.X_M2M_RI = DateTime.Now.ToString("yyyyMMddHHmmss") + "data_retrive";
            header.X_MEF_TK = svr.token;
            header.X_MEF_EKI = svr.enrmtKeyId;
            header.X_M2M_NM = string.Empty;
            header.Accept = "application/xml";
            header.ContentType = string.Empty;

            string retStr = SendHttpRequest(header, string.Empty);
            if (retStr != string.Empty)
            {
                string format = string.Empty;
                string value = string.Empty;

                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(retStr);
                //LogWrite(xDoc.OuterXml.ToString());

                XmlNodeList xnList = xDoc.SelectNodes("/*"); //접근할 노드
                foreach (XmlNode xn in xnList)
                {
                    format = xn["cnf"].InnerText; // data format
                    value = xn["con"].InnerText; // data value
                }
                //LogWrite("value = " + value);
                //LogWrite("format = " + format);

                if (format == "application/octet-stream")
                {
                    if (value.Length % 4 == 1)
                    {
                        value += "===";
                    }
                    else if (value.Length % 4 == 2)
                    {
                        value += "==";
                    }
                    else if (value.Length % 4 == 3)
                    {
                        value += "=";
                    }
                    //LogWrite("value = " + value);
                    SetText(label29, Encoding.UTF8.GetString(Convert.FromBase64String(value)));
                }
                else
                    SetText(label29, value);

                if (label29.Text == lbSendedData.Text)
                    endoneM2MTC("tc021303", string.Empty, string.Empty, string.Empty, string.Empty);
                else
                    endoneM2MTC("tc021303", string.Empty, "20000100", lbDirectRxData.Text, label29.Text);

                if (lbActionState.Text == states.onem2mtc0213032.ToString())
                {
                    startoneM2MTC("tc020901");
                    this.sendDataOut(commands["setACP"]);
                    SetText(lbActionState, states.onem2mtc0209011.ToString());
                    nextresponse = "$OM_C_ACP_RSP=";
                }
            }
            else
            {
                endoneM2MTC("tc021303", string.Empty, "20000100", "BAD RESPONSE", string.Empty);

                if (lbActionState.Text == states.onem2mtc0213032.ToString())
                {
                    startoneM2MTC("tc020901");
                    this.sendDataOut(commands["setACP"]);
                    SetText(lbActionState, states.onem2mtc0209011.ToString());
                    nextresponse = "$OM_C_ACP_RSP=";
                }
            }
        }

        private void button94_Click(object sender, EventArgs e)
        {
            if (svr.enrmtKeyId != string.Empty)
            {
                if (lbDevEntityId.Text != ".")
                {
                    rTh = new Thread(new ThreadStart(SendDataToOneM2M));
                    rTh.Start();
                }
                else
                    MessageBox.Show("CTN이 등록되어 있지 않습니다.확인이 필요합니다.");
            }
            else
                MessageBox.Show("서버인증파라미터 세팅하세요");
        }

        private void SendDataToOneM2M()
        {
            ReqHeader header = new ReqHeader();
            setDeviceEntityID();
            header.Url = brkUrl + "/" + dev.entityId + "/TEST";

            header.Method = "POST";
            header.X_M2M_Origin = svr.entityId;
            header.X_M2M_RI = DateTime.Now.ToString("yyyyMMddHHmmss") + "data_send";
            header.X_MEF_TK = svr.token;
            header.X_MEF_EKI = svr.enrmtKeyId;
            header.X_M2M_NM = string.Empty;
            header.Accept = "application/vnd.onem2m-res+xml";
            header.ContentType = "application/vnd.onem2m-res+xml;ty=4";

            string packetStr = "<m2m:cin xmlns:m2m=\"http://www.onem2m.org/xml/protocols\">";
            packetStr += "<cnf>text/plain</cnf>";
            string txData = string.Empty;
            txData = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") + " server";
            packetStr += "<con>" + txData + "</con>";
            packetStr += "</m2m:cin>";

            SetText(label2, txData);

            string retStr = SendHttpRequest(header, packetStr);
            //if (retStr != string.Empty)
            //    LogWrite(retStr);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection itemColl = listView1.SelectedItems;
            foreach (ListViewItem item in itemColl)
            {
                if (item.SubItems[3].Text != string.Empty)
                {
                    textBox95.Text = item.SubItems[3].Text;
                    tBResultCode.Text = item.SubItems[2].Text;

                    getSvrEventLog(item.SubItems[3].Text, item.SubItems[2].Text, item.SubItems[4].Text);

                    tabControl1.SelectedTab = tabLOG;
                }
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection itemColl = listView2.SelectedItems;
            foreach (ListViewItem item in itemColl)
            {
                if (item.SubItems[3].Text != string.Empty)
                {
                    textBox95.Text = item.SubItems[3].Text;
                    tBResultCode.Text = item.SubItems[2].Text;

                    getSvrEventLog(item.SubItems[3].Text, item.SubItems[2].Text, item.SubItems[4].Text);

                    tabControl1.SelectedTab = tabLOG;
                }
            }
        }

        private void button62_Click_1(object sender, EventArgs e)
        {
            this.sendDataOut(textBox61.Text);
            lbActionState.Text = states.getcereg.ToString();
        }

        private void button99_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox58.Text);
            lbActionState.Text = states.setcereg.ToString();
        }

        private void button100_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox59.Text);
        }

        private void button101_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox60.Text);
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            Console.WriteLine(webBrowser1.Url.ToString());
            try
            {
                if (webBrowser1.Url.ToString() == "https://testadm.onem2m.uplus.co.kr:8443/login")
                {
                    webBrowser1.Document.Focusing += new HtmlElementEventHandler(Document_Click);

                    string filePath = Application.StartupPath + @"\configure.txt";
                    if (File.Exists(filePath))
                    {
                        FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                        // Open a file to read to.
                        StreamReader sr = new StreamReader(fs);

                        string rddata = sr.ReadLine();
                        webBrowser1.Document.GetElementById("txtId").SetAttribute("value", rddata);

                        rddata = sr.ReadLine();
                        byte[] rdbyte = Convert.FromBase64String(rddata);
                        webBrowser1.Document.GetElementById("txtPassword").SetAttribute("value", Encoding.UTF8.GetString(rdbyte));

                        sr.Close();
                        fs.Close();

                        webBrowser1.Document.GetElementById("btnLogin").InvokeMember("Click");
/*
                        HtmlElementCollection searchBox = webBrowser1.Document.GetElementsByTagName("BUTTON");
                        foreach (HtmlElement el in searchBox)
                        {
                            if (el.GetAttribute("type").Equals("submit"))
                            {
                                el.InvokeMember("Click");
                            }
                        }
  */
                        }
                }
                else if (webBrowser1.Url.ToString() == "https://testadm.onem2m.uplus.co.kr:8443/login/twofactor")
                {
                    webBrowser1.Document.GetElementById("smsNum").SetAttribute("value", "1234");

                    webBrowser1.Document.GetElementById("btnConfSms").InvokeMember("Click");
/*
                    HtmlElementCollection searchBox = webBrowser1.Document.GetElementsByTagName("BUTTON");
                    foreach (HtmlElement el in searchBox)
                    {
                        if (el.GetAttribute("type").Equals("submit"))
                        {
                            el.InvokeMember("Click");
                        }
                    }
*/
                }
                else if (webBrowser1.Url.ToString() == "https://testadm.onem2m.uplus.co.kr:8443/logging/realtime")
                {
                    webBrowser1.Navigate("https://testadm.onem2m.uplus.co.kr:8443/terminal");
                }
                else if (webBrowser1.Url.ToString() == "https://testadm.onem2m.uplus.co.kr:8443/terminal")
                {
                    if (dev.uuid != string.Empty)
                    {
                        webBrowser1.Document.GetElementById("txtEsn").SetAttribute("value", dev.imsi);
/*
                        HtmlElementCollection searchBox = webBrowser1.Document.GetElementById("selCommonKey").GetElementsByTagName("SELECT");
                        foreach (HtmlElement el in searchBox)
                        {
                            if (el.GetAttribute("value").Equals("50"))
                            {
                                el.InvokeMember("Selected");
                            }
                        }
*/
                        webBrowser1.Document.GetElementById("btnSearch").InvokeMember("Click");
                    }
                }
                else if (webBrowser1.Url.ToString() == "https://testadm.onem2m.uplus.co.kr:8443/deviceMgmt")
                {
                    webBrowser1.Document.GetElementById("txtEntId").SetAttribute("value", dev.entityId);
                    webBrowser1.Document.GetElementById("btnSearch").InvokeMember("Click");
                }
                else if (webBrowser1.Url.ToString() == "https://testadm.onem2m.uplus.co.kr:8443/firmware")
                {
                    webBrowser1.Document.GetElementById("btnSearch").InvokeMember("Click");
                }
                else if (webBrowser1.Url.ToString() == "https://testadm.onem2m.uplus.co.kr:8443/firmware/modem")
                {
                    webBrowser1.Document.GetElementById("btnSearch").InvokeMember("Click");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Document_Click(object sender, HtmlElementEventArgs e)
        {
            if (webBrowser1.Document.ActiveElement.TagName == "BUTTON")
            {
                if(webBrowser1.Document.GetElementById("txtId") != null)
                {
                    dynamic ee = webBrowser1.Document.GetElementById("txtId").DomElement;
                    dynamic dd = webBrowser1.Document.GetElementById("txtPassword").DomElement;
                    
                    try
                    {
                        FileStream fs = new FileStream(Application.StartupPath + @"\configure.txt", FileMode.Create, FileAccess.Write);
                        // Create a file to write to.
                        StreamWriter sw = new StreamWriter(fs);

                        sw.WriteLine(ee.value);
                        byte[] ddbyte = System.Text.Encoding.UTF8.GetBytes(dd.value);
                        sw.WriteLine(Convert.ToBase64String(ddbyte));

                        sw.Close();
                        fs.Close();
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnoneM2MFullTest_Click(object sender, EventArgs e)
        {
            tcStartTime = DateTime.Now.AddMinutes(-1);
            dateTimePicker1.Value = tcStartTime;

            listView1.Items.Clear();
            foreach (string tcindex in Enum.GetNames(typeof(onem2mtc)))
            {
                ListViewItem newitem = new ListViewItem(new string[] { onem2mtclist[tcindex], "Not TEST", string.Empty, string.Empty, string.Empty, string.Empty });
                listView1.Items.Add(newitem);
            }

            svr.svcSvrCd = tbSvcSvrCd.Text; // 서비스 서버의 시퀀스
            svr.svcCd = tbSvcCd.Text; // 서비스 서버의 서비스코드
            svr.svcSvrNum = tbSvcSvrNum.Text; // 서비스 서버의 Number
            RequestMEF();

            startoneM2MTC("tc020101");
            //AT$OM_SVR_INFO=<svr>,<ip>,<port>
            this.sendDataOut(commands["setmefserverinfo"] + oneM2MMEFIP + "," + oneM2MMEFPort);
            lbActionState.Text = states.onem2mtc0201011.ToString();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            tcStartTime = dateTimePicker1.Value;
        }

        private void button106_Click(object sender, EventArgs e)
        {
            this.sendDataOut(commands["getonem2mmode"]);
            lbActionState.Text = states.getonem2mmode.ToString();
            nextresponse = "$LGTMPF=";
        }

        private void button109_Click(object sender, EventArgs e)
        {
            startoneM2MTC("tc020102");
            this.sendDataOut(commands["setonem2mmode"]);
            lbActionState.Text = states.setonem2mmode.ToString();
        }

        private void button110_Click(object sender, EventArgs e)
        {
            this.sendDataOut(commands["getserverinfo"]);
            lbActionState.Text = states.getserverinfo.ToString();
            nextresponse = "$OM_SVR_INFO=";
        }

        private void button111_Click(object sender, EventArgs e)
        {
            startoneM2MTC("tc020101");
            this.sendDataOut(commands["sethttpserverinfo"] + oneM2MBRKIP + "," + oneM2MBRKPort);
            lbActionState.Text = states.sethttpserverinfo.ToString();
        }

        private void button112_Click(object sender, EventArgs e)
        {
            startoneM2MTC("tc020101");
            this.sendDataOut(commands["setmefserverinfo"] + oneM2MMEFIP + "," + oneM2MMEFPort);
            lbActionState.Text = states.setmefserverinfo.ToString();
        }

        private void button114_Click(object sender, EventArgs e)
        {
            startoneM2MTC("tc020101");
            this.sendDataOut(commands["setfotaserverinfo"] + oneM2MFOTAIP + "," + oneM2MFOTAPort);
            lbActionState.Text = states.setfotaserverinfo.ToString();
        }

        private void btnMEFAuthD_Click(object sender, EventArgs e)
        {
            startoneM2MTC("tc021104");
            // 디바이스 펌웨어 버전 등록을 위해 플랫폼 서버 MEF AUTH 요청
            this.sendDataOut(commands["setmefauth"] + tbSvcCd.Text + "," + tBoxDeviceModel.Text + "," + tBoxDeviceVer.Text + "," + tBoxDeviceSN.Text);
            lbActionState.Text = states.setmefauth.ToString();
            nextresponse = "$OM_AUTH_RSP=";
        }

        private void btnGetCSED_Click(object sender, EventArgs e)
        {
            startoneM2MTC("tc020401");
            this.sendDataOut(commands["getCSEbase"]);
            lbActionState.Text = states.getCSEbase.ToString();
            nextresponse = "$OM_B_CSE_RSP=";
        }

        private void btnGetDeviceCSR_Click(object sender, EventArgs e)
        {
            startoneM2MTC("tc020301");
            this.sendDataOut(commands["getremoteCSE"]);
            lbActionState.Text = states.getremoteCSE.ToString();
            nextresponse = "$OM_R_CSE_RSP=";
        }

        private void btnCreateDeviceCSR_Click(object sender, EventArgs e)
        {
            startoneM2MTC("tc020501");
            this.sendDataOut(commands["setremoteCSE"]);
            lbActionState.Text = states.setremoteCSE.ToString();
            nextresponse = "$OM_C_CSE_RSP=";
        }

        private void btnDeviceUpdateCSR_Click(object sender, EventArgs e)
        {
            //startoneM2MTC("tc020501");
            this.sendDataOut(commands["updateremoteCSE"]);
            lbActionState.Text = states.updateremoteCSE.ToString();
            nextresponse = "$OM_U_CSE_RSP=";
        }

        private void btnDelDeviceCSR_Click(object sender, EventArgs e)
        {
            startoneM2MTC("tc021204");
            this.sendDataOut(commands["delremoteCSE"]);
            lbActionState.Text = states.delremoteCSE.ToString();
            nextresponse = "$OM_D_CSE_RSP=";
        }

        private void btnSetRxContainer_Click(object sender, EventArgs e)
        {
            startoneM2MTC("tc020502");
            this.sendDataOut(commands["setcontainer"]);
            lbActionState.Text = states.setcontainer.ToString();
            nextresponse = "$OM_C_CON_RSP=";
        }

        private void btnDelRxContainer_Click(object sender, EventArgs e)
        {
            startoneM2MTC("tc021203");
            this.sendDataOut(commands["delcontainer"] + "StoD");
            lbActionState.Text = states.delcontainer.ToString();
            nextresponse = "$OM_D_CON_RSP=";
        }

        private void btnSetSubscript_Click(object sender, EventArgs e)
        {
            startoneM2MTC("tc020503");
            this.sendDataOut(commands["setsubscript"] + "StoD");
            lbActionState.Text = states.setsubscript.ToString();
            nextresponse = "$OM_C_SUB_RSP=";
        }

        private void btnDelSubscript_Click(object sender, EventArgs e)
        {
            startoneM2MTC("tc021202");
            this.sendDataOut(commands["delsubscript"] + "StoD");
            lbActionState.Text = states.delsubscript.ToString();
            nextresponse = "$OM_D_SUB_RSP=";
        }

        private void btnRcvDataOneM2M_Click(object sender, EventArgs e)
        {
            startoneM2MTC("tc020701");
            // 플랫폼 서버에 data 수신 요청
            this.sendDataOut(commands["getonem2mdata"] + "StoD");
            lbActionState.Text = states.getonem2mdata.ToString();
            nextresponse = "$OM_R_INS_RSP=";
        }

        private void btnSendDataOneM2M_Click(object sender, EventArgs e)
        {
            startoneM2MTC("tc020504");
            // Data send to SERVER (string original)
            //AT$OM_C_INS_REQ=<object>,<length>,<data>
            string txData = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") + " oneM2M device";
            this.sendDataOut(commands["sendonemsgstr"] + "DtoS" + "," + txData.Length + "," + txData);

            lbActionState.Text = states.sendonemsgstr.ToString();
            lbSendedData.Text = txData;
            nextresponse = "$OM_C_INS_RSP=";
        }

        private void button104_Click(object sender, EventArgs e)
        {
            startoneM2MTC("tc021004");
            // 디바이스 펌웨어 버전 등록을 위해 플랫폼 서버 MEF AUTH 요청
            this.sendDataOut(commands["setmefauth"] + tbSvcCd.Text + "," + tBoxDeviceModel.Text + "," + tBoxDeviceVer.Text + "," + tBoxDeviceSN.Text);
            lbActionState.Text = states.fotamefauthnt.ToString();
            nextresponse = "$OM_AUTH_RSP=";
        }

        private void btnDeviceFOTA_Click(object sender, EventArgs e)
        {
            startoneM2MTC("tc021001");
            this.sendDataOut(commands["getdeviceSvrVer"]);
            lbActionState.Text = states.getdeviceSvrVer.ToString();
            nextresponse = "$OM_DEV_FWUP_RSP=";
        }

        private void btnoneM2MModuleVer_Click(object sender, EventArgs e)
        {
            if (lbActionState.Text == states.modemFWUPfinish.ToString() || lbActionState.Text == states.modemFWUPmodechk.ToString() || lbActionState.Text == states.modemFWUPmodechked.ToString())
            {
                this.sendDataOut(commands["getonem2mmode"]);
                lbActionState.Text = states.modemFWUPmodechk.ToString();
                nextresponse = "$LGTMPF=";
            }
            else if (lbActionState.Text == states.onem2mtc0211034.ToString() || lbActionState.Text == states.onem2mtc0211035.ToString())
            {
                this.sendDataOut(commands["getonem2mmode"]);
                lbActionState.Text = states.onem2mtc0211034.ToString();
                nextresponse = "$LGTMPF=";
            }
            else
            {
                startoneM2MTC("tc021104");
                // 디바이스 펌웨어 버전 등록을 위해 플랫폼 서버 MEF AUTH 요청
                this.sendDataOut(commands["setmefauth"] + tbSvcCd.Text + "," + tBoxDeviceModel.Text + "," + tBoxDeviceVer.Text + "," + tBoxDeviceSN.Text);
                lbActionState.Text = states.mfotamefauth.ToString();
                nextresponse = "$OM_AUTH_RSP=";
            }
        }

        private void btnModemFOTA_Click(object sender, EventArgs e)
        {
            startoneM2MTC("tc021101");
            this.sendDataOut(commands["getmodemSvrVer"]);
            lbActionState.Text = states.getmodemSvrVer.ToString();
            nextresponse = "$OM_MODEM_FWUP_RSP=";
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            // RESET 상태 등록을 위해 플랫폼 서버 MEF AUTH 요청
            if (lbActionState.Text == states.resetreceived.ToString() || lbActionState.Text == states.resetmodechk.ToString() || lbActionState.Text == states.resetmodechked.ToString())
            {
                this.sendDataOut(commands["getonem2mmode"]);
                lbActionState.Text = states.resetmodechk.ToString();
                nextresponse = "$LGTMPF=";
            }
            else
            {
                this.sendDataOut(commands["setmefauth"] + tbSvcCd.Text + "," + tBoxDeviceModel.Text + "," + tBoxDeviceVer.Text + "," + tBoxDeviceSN.Text);
                lbActionState.Text = states.resetmefauth.ToString();
                nextresponse = "$OM_AUTH_RSP=";
            }
        }

        private void button103_Click(object sender, EventArgs e)
        {
            startoneM2MTC("tc020902");
            this.sendDataOut(commands["getACP"]);
            lbActionState.Text = states.getACP.ToString();
            nextresponse = "$OM_R_ACP_RSP=";
        }

        private void button70_Click(object sender, EventArgs e)
        {
            startoneM2MTC("tc020901");
            this.sendDataOut(commands["setACP"]);
            lbActionState.Text = states.setACP.ToString();
            nextresponse = "$OM_C_ACP_RSP=";
        }

        private void button80_Click(object sender, EventArgs e)
        {
            startoneM2MTC("tc020903");
            this.sendDataOut(commands["updateACP"]);
            lbActionState.Text = states.updateACP.ToString();
            nextresponse = "$OM_U_ACP_RSP=";
        }

        private void button102_Click(object sender, EventArgs e)
        {
            startoneM2MTC("tc020904");
            this.sendDataOut(commands["delACP"]);
            lbActionState.Text = states.delACP.ToString();
            nextresponse = "$OM_D_ACP_RSP=";
        }

        private void button34_Click(object sender, EventArgs e)
        {
            if (svr.entityId != string.Empty)
            {
                startoneM2MTC("tc021301");
                // Data send to SERVER (string original)
                //AT$OM_C_INS_REQ=<server id>,<object>,<length>,<data>
                string txData = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") + " oneM2M device";
                this.sendDataOut(commands["sendonemsgsvr"] + svr.entityId + "," + "TEST" + "," + txData.Length + "," + txData);
                lbActionState.Text = states.sendonemsgsvr.ToString();
                nextresponse = "$OM_C_RCIN_RSP=";
                lbSendedData.Text = txData;
            }
            else
                MessageBox.Show("서비스서버 정보가 없습니다.");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                progressBar1.Value = 0;

                if (lbActionState.Text != states.idle.ToString())
                    doOpenComPort();
                else if (progressBar1.Value != 0)
                {
                    logPrintInTextBox("잠시 후 COM 포트 재오픈이 필요합니다.", "");

                    lbActionState.Text = states.closed.ToString();
                    timer1.Stop();
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name == "webpage")
            {
                if (webBrowser1.Url.ToString() == "about:blank")
                    webBrowser1.Navigate("https://testadm.onem2m.uplus.co.kr:8443");
            }
            else if (tabControl1.SelectedTab.Name == "tabCOM")
            {
                if (listView3.Items.Count > 35)
                    listView3.TopItem = listView3.Items[listView3.Items.Count - 1];
            }
            else if (tabControl1.SelectedTab.Name == "tabOneM2M")
            {
                if (listView4.Items.Count > 35)
                    listView4.TopItem = listView4.Items[listView4.Items.Count - 1];
            }
            else if (tabControl1.SelectedTab.Name == "tabLwM2M")
            {
                if (listView5.Items.Count > 35)
                    listView5.TopItem = listView5.Items[listView5.Items.Count - 1];
            }
            else if (tabControl1.SelectedTab.Name == "tabServer")
            {
                if (listView7.Items.Count > 35)
                    listView7.TopItem = listView7.Items[listView7.Items.Count - 1];
            }
        }

        private void button115_Click(object sender, EventArgs e)
        {
            startoneM2MTC("tc020602");
            this.sendDataOut(commands["setrcvauto"]);
            lbActionState.Text = states.setrcvauto.ToString();
        }

        private void button116_Click(object sender, EventArgs e)
        {
            startoneM2MTC("tc020604");
            this.sendDataOut(commands["setrcvmanu"]);
            lbActionState.Text = states.setrcvmanu.ToString();
        }

        private void button117_Click(object sender, EventArgs e)
        {
            startoneM2MTC("tc020501");
            this.sendDataOut(commands["setremoteCSE"]);
            lbActionState.Text = states.onem2mset01.ToString();
            nextresponse = "$OM_C_CSE_RSP=";
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (lbActionState.Text == states.lwm2mtc02012.ToString())
            {
                if (textBox63.Text != string.Empty)
                {
                    this.sendDataOut(textBox63.Text);
                    lbActionState.Text = states.lwm2mtc02021.ToString();
                }
                else
                {
                    this.sendDataOut(textBox56.Text);
                    lbActionState.Text = states.lwm2mtc02023.ToString();
                }
                startLwM2MTC("tc0202", string.Empty, string.Empty, string.Empty, textBox56.Text);
            }
            else if (lbActionState.Text == states.lwm2mtc03013.ToString())
            {
                DeviceFWVerSend();

                lbActionState.Text = states.lwm2mtc06031.ToString();
            }
            else if (lbActionState.Text == states.lwm2mtc06032.ToString())
            {
                string txData = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") + " LwM2M device";
                lbDevLwM2MData.Text = txData;


                if (checkBox8.Checked == true)
                {
                    string hexOutput = StringToBCD(txData.ToCharArray());

                    this.sendDataOut(textBox53.Text + hexOutput.Length / 2 + "," + hexOutput);
                }
                else
                    this.sendDataOut(textBox53.Text + txData.Length + "," + txData);
                startLwM2MTC("tc0501", string.Empty, string.Empty, string.Empty, textBox53.Text);
                nextcommand = states.lwm2mtc0501.ToString();
            }
            else if (lbActionState.Text == states.onem2mtc0211033.ToString())
            {
                this.sendDataOut(commands["getonem2mmode"]);
                lbActionState.Text = states.onem2mtc0211034.ToString();
                nextresponse = "$LGTMPF=";
            }
            else if (lbActionState.Text == states.resetboot.ToString())
            {
                this.sendDataOut(commands["getonem2mmode"]);
                lbActionState.Text = states.resetmodechk.ToString();
                nextresponse = "$LGTMPF=";
            }

            timer2.Stop();
        }

        private void receiveFotaData(string size, string rcvData)
        {
            timer2.Stop();

            int dataSize = rcvData.Length / 2;
            if (Convert.ToInt32(size) == dataSize)    // data size 비교
            {
                // Firmware File Information Block Checking
                if ((device_total_index == "0") && (dataSize == 8))
                {
                    if (rcvData.Substring(0, 4) == "0000")
                    {
                        device_total_index = rcvData.Substring(4, 4);
                        device_fota_checksum = rcvData.Substring(8, 8);
                        logPrintInTextBox("total Index= " + device_total_index + ", checksum = " + device_fota_checksum + "를 수신하였습니다.", "");
                        if(lbActionState.Text == states.lwm2mtc06032.ToString())
                            lbActionState.Text = states.lwm2mtc06033.ToString();
                    }
                }
                // Firmware File Data Block Checking
                else
                {
                    device_fota_index = rcvData.Substring(0, 4);
                    //tBoxFOTAIndex.Text = device_fota_index;
                    string checksum = rcvData.Substring(4, 8);
                    logPrintInTextBox("index= " + device_fota_index + "/" + device_total_index + ", checksum= " + checksum + "를 수신하였습니다.", "");

                    if (device_total_index == device_fota_index)
                    {
                        endLwM2MTC("tc0603", string.Empty, string.Empty, string.Empty, string.Empty);

                        device_total_index = "0";
                        device_fota_index = "0";

                        DeviceFWVerSend();

                        if (lbActionState.Text == states.lwm2mtc06032.ToString() || lbActionState.Text == states.lwm2mtc06033.ToString())
                            nextcommand = states.lwm2mtc06034.ToString();
                    }
                }
            }
            else
            {
                endLwM2MTC("tc0603", string.Empty, "20000100", size, Convert.ToString(dataSize));
                logPrintInTextBox("data size="+ Convert.ToString(dataSize)+"/"+ size + "로 잘 못 되었습니다.", "");
            }
        }

        private void DeviceFWVerSend()
        {
            // Device firmware 버전 등록 전문 예 : fwVr=1.0|fwSt=1|fwRt=0
            // fwVr ={ VERSION}| fwSt ={ STATUS}| fwRt ={ RESULT_CODE}(|fwIn={index})(|szx={buffersize})
            // fwVr: 현재 Device Firmware 버전
            // fwSt: Firmware Status
            //      1: Success
            //      2: Progress
            //      3: Failure
            // fwRt : Firmware Update 결과(OMA Spec 과 같은 값 사용)
            //      0: Initial value.
            //      1: Firmware updated successfully
            //      2: Not enough flash memory
            //      3: Out of RAM during downloading process.
            //      4: Connection lost during downloading process.
            //      5: Integrity check failure
            //      6: Unsupported package type.
            //      8: Firmware update failed
            //  fwIn : 단말에서 문제가 발생 하여 특정 Index부터 다시 받고 싶을 때 사용
            //      만약 fwSt 가 2(Progress)이면서 fwIn 에 특정 Index 를 보내면
            //      기존에 upload Process 는 중지 하고 해당 Index 부터 다시 Upload 시작 함
            //      fwSt 가 2 가 아닐 경우, fwIn 값이 없거나 0 보다 작을 경우 이어 받기 동작하지 않음
            //      fwIn 의 값이 전체 Index 보다 클 경우 이전 내려받기는 취소 되고 에러 처리 됨
            // szx : FOTA buffer size (1:32, 2:64, 3:128, 4:256, 5:512(default), 6:1024 

            string text = "fwVr=" + tBoxDeviceVer.Text + "|fwSt=1|fwRt=0";

            if (dev.model != "TPB23" && !dev.model.StartsWith("BC95") && !dev.model.StartsWith("BG95"))
            {
                text += "|szx=6";       // FOTA buffer size set 1024bytes.
            }

            if (checkBox8.Checked == true)
            {
                string hexOutput = StringToBCD(text.ToCharArray());

                this.sendDataOut(textBox51.Text + hexOutput.Length / 2 + "," + hexOutput);
            }
            else
                this.sendDataOut(textBox51.Text + text.Length + "," + text);
            startLwM2MTC("tc0603", string.Empty, string.Empty, string.Empty, textBox51.Text);
        }

        private void RetriveDataLwM2M()
        {
            ReqHeader header = new ReqHeader();
            setDeviceEntityID();
            header.Url = brkUrlL + "/" + dev.entityId + "/10250/0/0";
            header.Method = "GET";
            header.X_M2M_Origin = svr.entityId;
            header.X_M2M_RI = DateTime.Now.ToString("yyyyMMddHHmmss") + "data_retrive";
            header.X_MEF_TK = svr.token;
            header.X_MEF_EKI = svr.enrmtKeyId;
            header.X_M2M_NM = string.Empty;
            header.Accept = "application/xml";
            header.ContentType = string.Empty;

            string retStr = SendHttpRequest(header, string.Empty);
            if (retStr != string.Empty)
            {
                string format = string.Empty;
                string value = string.Empty;

                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(retStr);
                //LogWrite(xDoc.OuterXml.ToString());

                XmlNodeList xnList = xDoc.SelectNodes("/*"); //접근할 노드
                foreach (XmlNode xn in xnList)
                {
                    format = xn["cnf"].InnerText; // data format
                    value = xn["con"].InnerText; // data value
                }
                //LogWrite("value = " + value);
                //LogWrite("format = " + format);

                if (format == "application/octet-stream")
                {
                    if (value.Length % 4 == 1)
                    {
                        value += "===";
                    }
                    else if (value.Length % 4 == 2)
                    {
                        value += "==";
                    }
                    else if (value.Length % 4 == 3)
                    {
                        value += "=";
                    }
                    //LogWrite("value = " + value);
                    SetText(lbDirectRxData, Encoding.UTF8.GetString(Convert.FromBase64String(value)));
                }
                else
                    SetText(lbDirectRxData, value);

                if (lbDirectRxData.Text == lbDevLwM2MData.Text)
                    endLwM2MTC("tc0503", string.Empty, string.Empty, string.Empty, string.Empty);
                else
                    endLwM2MTC("tc0503", string.Empty, "20000100", lbDirectRxData.Text, lbDevLwM2MData.Text);
            }
            else
                endLwM2MTC("tc0503", string.Empty, "20000100", "BAD RESPONSE", string.Empty);

            if (lbActionState.Text == states.lwm2mtc0503.ToString())
            {
                this.sendDataOut(textBox52.Text);
                startLwM2MTC("tc0401", string.Empty, string.Empty, string.Empty, textBox52.Text);
                SetText(lbActionState, states.lwm2mtc0401.ToString());
                if (dev.model.StartsWith("BG95"))
                    nextresponse = "+QLWDEREG: 0";
            }
        }

        private void checkBox5_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
                checkBox5.Text = "Bootstrap/Register 명령 구분";
            else
                checkBox5.Text = "Register 명령 포함";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string pathname = Application.StartupPath + @"/TestResult/";
            DateTime currenttime = DateTime.Now;
            string filename = null;

            Directory.CreateDirectory(pathname);
            pathname += tBoxDeviceModel.Text + "_" + tbDeviceName.Text + "_";

            filename = "TestResult_" + currenttime.ToString("MMdd_hhmmss") + ".xls";
            resultFileWrite(pathname, filename);
        }

        private void resultFileWrite(string pathname, string filename)
        {
            try
            {
                Workbook workbook = new Workbook();
                Worksheet worksheet = new Worksheet("information");

                worksheet.Cells[0, 0] = new Cell("모델명");
                worksheet.Cells[0, 1] = new Cell(dev.model);
                worksheet.Cells[1, 0] = new Cell("제조사");
                worksheet.Cells[1, 1] = new Cell(dev.maker);
                worksheet.Cells[2, 0] = new Cell("버전");
                worksheet.Cells[2, 1] = new Cell(dev.version);
                worksheet.Cells[3, 0] = new Cell("시험일");
                worksheet.Cells[3, 1] = new Cell(DateTime.Now.ToString("MM/dd hh:mm"));
                worksheet.Cells[4, 0] = new Cell("EntityID");
                worksheet.Cells[4, 1] = new Cell(dev.entityId);
                worksheet.Cells[5, 0] = new Cell("CellID");
                worksheet.Cells[5, 1] = new Cell(label49.Text);
                worksheet.Cells.ColumnWidth[0] = 3000;
                worksheet.Cells.ColumnWidth[1] = 10000;
                workbook.Worksheets.Add(worksheet);

                worksheet = new Worksheet("onem2m");
                worksheet.Cells[0, 0] = new Cell("시험 항목");
                worksheet.Cells[0, 1] = new Cell("결과");
                worksheet.Cells[0, 2] = new Cell("resultCode");
                worksheet.Cells[0, 3] = new Cell("logId");
                worksheet.Cells[0, 4] = new Cell("설명");
                worksheet.Cells[0, 5] = new Cell("비고");

                int i = 1;
                foreach (string tcindex in Enum.GetNames(typeof(onem2mtc)))
                {
                    onem2mtc index = (onem2mtc)Enum.Parse(typeof(onem2mtc), tcindex);
                    worksheet.Cells[i, 0] = new Cell(listView1.Items[(int)index].SubItems[0].Text);
                    worksheet.Cells[i, 1] = new Cell(listView1.Items[(int)index].SubItems[1].Text);
                    worksheet.Cells[i, 2] = new Cell(listView1.Items[(int)index].SubItems[2].Text);
                    worksheet.Cells[i, 3] = new Cell(listView1.Items[(int)index].SubItems[3].Text);
                    worksheet.Cells[i, 4] = new Cell(listView1.Items[(int)index].SubItems[4].Text);
                    worksheet.Cells[i, 5] = new Cell(listView1.Items[(int)index].SubItems[5].Text);
                    i++;
                }

                worksheet.Cells.ColumnWidth[0] = 11000;
                worksheet.Cells.ColumnWidth[1, 3] = 3000;
                worksheet.Cells.ColumnWidth[4, 5] = 10000;
                workbook.Worksheets.Add(worksheet);

                worksheet = new Worksheet("lwm2m");
                worksheet.Cells[0, 0] = new Cell("시험 항목");
                worksheet.Cells[0, 1] = new Cell("결과");
                worksheet.Cells[0, 2] = new Cell("resultCode");
                worksheet.Cells[0, 3] = new Cell("logId");
                worksheet.Cells[0, 4] = new Cell("설명");
                worksheet.Cells[0, 5] = new Cell("비고");

                i = 1;
                foreach (string tcindex in Enum.GetNames(typeof(lwm2mtc)))
                {
                    lwm2mtc indexl = (lwm2mtc)Enum.Parse(typeof(lwm2mtc), tcindex);
                    worksheet.Cells[i, 0] = new Cell(listView2.Items[(int)indexl].SubItems[0].Text);
                    worksheet.Cells[i, 1] = new Cell(listView2.Items[(int)indexl].SubItems[1].Text);
                    worksheet.Cells[i, 2] = new Cell(listView2.Items[(int)indexl].SubItems[2].Text);
                    worksheet.Cells[i, 3] = new Cell(listView2.Items[(int)indexl].SubItems[3].Text);
                    worksheet.Cells[i, 4] = new Cell(listView2.Items[(int)indexl].SubItems[4].Text);
                    worksheet.Cells[i, 5] = new Cell(listView2.Items[(int)indexl].SubItems[5].Text);
                    i++;
                }

                worksheet.Cells.ColumnWidth[0] = 11000;
                worksheet.Cells.ColumnWidth[1, 3] = 3000;
                worksheet.Cells.ColumnWidth[4, 5] = 10000;
                workbook.Worksheets.Add(worksheet);

                worksheet = new Worksheet("atcommand");
                worksheet.Cells[0, 0] = new Cell("시간");
                worksheet.Cells[0, 1] = new Cell("state");
                worksheet.Cells[0, 2] = new Cell(" ");
                worksheet.Cells[0, 3] = new Cell("내용");

                for (i=0;i<listView3.Items.Count;i++)
                {
                    worksheet.Cells[i+1, 0] = new Cell(listView3.Items[i].SubItems[0].Text);
                    worksheet.Cells[i+1, 1] = new Cell(listView3.Items[i].SubItems[1].Text);
                    worksheet.Cells[i+1, 2] = new Cell(listView3.Items[i].SubItems[2].Text);
                    worksheet.Cells[i+1, 3] = new Cell(listView3.Items[i].SubItems[3].Text);
                }

                worksheet.Cells.ColumnWidth[0] = 2500;
                worksheet.Cells.ColumnWidth[1] = 5000;
                worksheet.Cells.ColumnWidth[2] = 700;
                worksheet.Cells.ColumnWidth[3] = 30000;
                workbook.Worksheets.Add(worksheet);

                worksheet = new Worksheet("server");
                worksheet.Cells[0, 0] = new Cell("시간");
                worksheet.Cells[0, 1] = new Cell("state");
                worksheet.Cells[0, 2] = new Cell(" ");
                worksheet.Cells[0, 3] = new Cell("내용");

                for (i = 0; i < listView7.Items.Count; i++)
                {
                    worksheet.Cells[i + 1, 0] = new Cell(listView7.Items[i].SubItems[0].Text);
                    worksheet.Cells[i + 1, 1] = new Cell(listView7.Items[i].SubItems[1].Text);
                    worksheet.Cells[i + 1, 2] = new Cell(listView7.Items[i].SubItems[2].Text);
                    worksheet.Cells[i + 1, 3] = new Cell(listView7.Items[i].SubItems[3].Text);
                }

                worksheet.Cells.ColumnWidth[0] = 2500;
                worksheet.Cells.ColumnWidth[1] = 5000;
                worksheet.Cells.ColumnWidth[2] = 700;
                worksheet.Cells.ColumnWidth[3] = 30000;
/*
                i = 1;
                // convert string to stream
                byte[] byteArray = Encoding.UTF8.GetBytes(tbLog.Text);
                MemoryStream stream = new MemoryStream(byteArray);

                // convert stream to string
                StreamReader reader = new StreamReader(stream);
                string line = string.Empty;
                while ((line = reader.ReadLine()) != null)
                {
                    worksheet.Cells[i, 0] = new Cell(line);
                    i++;
                }

                worksheet.Cells.ColumnWidth[0] = 11000;
*/
                workbook.Worksheets.Add(worksheet);

                worksheet = new Worksheet("platform");
                worksheet.Cells[0, 0] = new Cell("시간");
                worksheet.Cells[0, 1] = new Cell("ID");
                worksheet.Cells[0, 2] = new Cell("이벤트");
                worksheet.Cells[0, 3] = new Cell("resultCode");
                worksheet.Cells[0, 4] = new Cell("비고");

                for (i = 0; i < listView8.Items.Count; i++)
                {
                    worksheet.Cells[i + 1, 0] = new Cell(listView8.Items[i].SubItems[0].Text);
                    worksheet.Cells[i + 1, 1] = new Cell(listView8.Items[i].SubItems[1].Text);
                    worksheet.Cells[i + 1, 2] = new Cell(listView8.Items[i].SubItems[2].Text);
                    worksheet.Cells[i + 1, 3] = new Cell(listView8.Items[i].SubItems[3].Text);
                    worksheet.Cells[i + 1, 4] = new Cell(listView8.Items[i].SubItems[4].Text);
                }

                worksheet.Cells.ColumnWidth[0] = 2500;
                worksheet.Cells.ColumnWidth[1] = 3000;
                worksheet.Cells.ColumnWidth[2] = 6000;
                worksheet.Cells.ColumnWidth[3] = 3000;
                worksheet.Cells.ColumnWidth[4] = 20000;
                workbook.Worksheets.Add(worksheet);

                worksheet = new Worksheet("testcase");
                worksheet.Cells[0, 0] = new Cell("시간");
                worksheet.Cells[0, 1] = new Cell("state");
                worksheet.Cells[0, 2] = new Cell("시험항목");
                worksheet.Cells[0, 3] = new Cell("결과");
                worksheet.Cells[0, 4] = new Cell("LogID");

                for (i = 0; i < listView6.Items.Count; i++)
                {
                    worksheet.Cells[i + 1, 0] = new Cell(listView6.Items[i].SubItems[0].Text);
                    worksheet.Cells[i + 1, 1] = new Cell(listView6.Items[i].SubItems[1].Text);
                    worksheet.Cells[i + 1, 2] = new Cell(listView6.Items[i].SubItems[2].Text);
                    worksheet.Cells[i + 1, 3] = new Cell(listView6.Items[i].SubItems[3].Text);
                    worksheet.Cells[i + 1, 4] = new Cell(listView6.Items[i].SubItems[4].Text);
                }

                worksheet.Cells.ColumnWidth[0] = 2500;
                worksheet.Cells.ColumnWidth[1] = 4000;
                worksheet.Cells.ColumnWidth[2] = 15000;
                worksheet.Cells.ColumnWidth[3] = 1500;
                worksheet.Cells.ColumnWidth[4] = 2500;

                workbook.Worksheets.Add(worksheet);

                workbook.Save(pathname + filename);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbMultiPDN_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMultiPDN.Checked == true)
                cbMultiPDN.Text = "지원";
            else
                cbMultiPDN.Text = "미지원";
        }

        private void cbAuto2ndPDN_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAuto2ndPDN.Checked == true)
                cbAuto2ndPDN.Text = "올림";
            else
                cbAuto2ndPDN.Text = "안올림";
        }

        private void cbEMC_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEMC.Checked == true)
                cbEMC.Text = "지원";
            else
                cbEMC.Text = "미지원";
        }

        private void cbCA_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCA.Checked == true)
                cbCA.Text = "지원";
            else
                cbCA.Text = "미지원";
        }

        private void cbIPSec_CheckedChanged(object sender, EventArgs e)
        {
            if (cbIPSec.Checked == true)
                cbIPSec.Text = "지원";
            else
                cbIPSec.Text = "미지원";
        }

        private void cbSMS_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSMS.Checked == true)
                cbSMS.Text = "지원";
            else
                cbSMS.Text = "미지원";
        }

        private void cbVoice_CheckedChanged(object sender, EventArgs e)
        {
            if (cbVoice.Checked == true)
                cbVoice.Text = "지원";
            else
                cbVoice.Text = "미지원";
        }

        private void cbVideo_CheckedChanged(object sender, EventArgs e)
        {
            if (cbVideo.Checked == true)
                cbVideo.Text = "지원";
            else
                cbVideo.Text = "미지원";
        }

        private void cbBand1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBand1.Checked == true)
                cbBand1.Text = "지원";
            else
                cbBand1.Text = "미지원";
        }

        private void cbBand5_CheckedChanged(object sender, EventArgs e)
        {
            if(cbBand5.Checked == true)
                cbBand5.Text = "지원";
            else
                cbBand5.Text = "미지원";
        }

        private void cbBand7_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBand7.Checked == true)
                cbBand7.Text = "지원";
            else
                cbBand7.Text = "미지원";
        }

        private void button118_Click(object sender, EventArgs e)
        {
            if (textBox63.Text != string.Empty)
            {
                lbActionState.Text = states.lwm2mresetbc95.ToString();
                this.sendDataOut(textBox63.Text);
            }
            else
                MessageBox.Show("LwM2M Disable 명령이 없습니다.");
        }

        private void button119_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox78.Text);
        }

        private void button120_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox79.Text);
        }

        private void button121_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox80.Text);
        }

        private void button128_Click(object sender, EventArgs e)
        {
            this.sendDataOut(textBox81.Text);
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true)
                checkBox7.Text = "2회";
            else
                checkBox7.Text = "1회";
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked == true)
                checkBox8.Text = "HEX";
            else
                checkBox8.Text = "STRING";
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked == true)
                checkBox9.Text = "지원";
            else
                checkBox9.Text = "미지원";
        }

        private void button131_Click(object sender, EventArgs e)
        {
            this.sendDataOut(tBProxy332.Text);
            lbActionState.Text = states.testatcmd.ToString();
        }

        private void button130_Click(object sender, EventArgs e)
        {
            this.sendDataOut(tBProxy333.Text);
            lbActionState.Text = states.testatcmd.ToString();
        }

        private void button44_Click(object sender, EventArgs e)
        {
            this.sendDataOut(tBProxy334.Text);
            lbActionState.Text = states.testatcmd.ToString();
        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection itemColl = listView3.SelectedItems;
            foreach (ListViewItem item in itemColl)
            {
                textBox1.Text = item.SubItems[3].Text;
                textBox2.Text = item.SubItems[1].Text;
            }
        }

        private void listView6_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection itemColl = listView6.SelectedItems;
            foreach (ListViewItem item in itemColl)
            {
                if (item.SubItems[4].Text != string.Empty)
                {
                    textBox95.Text = item.SubItems[4].Text;
                    getSvrEventLog(textBox95.Text, string.Empty, string.Empty);
                    tabControl1.SelectedTab = tabLOG;
                }
            }
        }

        private void listView8_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection itemColl = listView8.SelectedItems;
            foreach (ListViewItem item in itemColl)
            {
                textBox95.Text = item.SubItems[1].Text;
                tBResultCode.Text = item.SubItems[2].Text;

                getSvrEventLog(item.SubItems[1].Text, item.SubItems[2].Text, item.SubItems[3].Text);
            }
        }

        private void listView9_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection itemColl = listView9.SelectedItems;
            foreach (ListViewItem item in itemColl)
            {
                textBox94.Text = item.SubItems[1].Text;
                tBResultCode.Text = item.SubItems[3].Text;

                getSvrDetailLog(item.SubItems[1].Text, string.Empty, item.SubItems[3].Text, item.SubItems[4].Text);
            }
        }

        private void listView10_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection itemColl = listView10.SelectedItems;
            foreach (ListViewItem item in itemColl)
            {
                if (item.SubItems[4].Text != " ")
                    MessageBox.Show(item.SubItems[3].Text + "\n\n" + item.SubItems[4].Text, "상세내역");
            }
        }

        private void listView7_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection itemColl = listView7.SelectedItems;
            foreach (ListViewItem item in itemColl)
            {
                string data = item.SubItems[3].Text;
                if (data.StartsWith("<?xml"))
                {
                    XmlDocument xDoc = new XmlDocument();
                    xDoc.LoadXml(data);
                    StringWriter writer = new StringWriter();
                    xDoc.Save(writer);
                    MessageBox.Show(writer.ToString(), "상세 내용");
                }
                else if (data.StartsWith("{") || data.StartsWith("["))
                {
                    string beautifiedJson = JValue.Parse(data).ToString((Newtonsoft.Json.Formatting)Formatting.Indented);
                    MessageBox.Show(beautifiedJson, "상세 내용");
                }
            }
        }

        private void button44_Click_1(object sender, EventArgs e)
        {
            oneM2MMefAuth(tbSvcCd.Text, tBoxDeviceModel.Text, tBoxDeviceVer.Text, tBoxDeviceSN.Text);
        }

        private void oneM2MMefAuth(string svcCode, string model, string version, string serialNo)
        {

            ReqHeader header = new ReqHeader();
            header.Url = "http://" + oneM2MMEFIP + ":" + oneM2MMEFPort + "/mef";
            header.Method = "POST";
            header.ContentType = "application/xml";
            header.X_M2M_RI = string.Empty;
            header.X_M2M_Origin = string.Empty;
            header.X_MEF_TK = string.Empty;
            header.X_MEF_EKI = string.Empty;
            header.X_M2M_NM = string.Empty;

            string bodymsg = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><auth><deviceModel>";
            bodymsg += model;
            bodymsg += "</deviceModel><deviceSerialNo>";
            bodymsg += serialNo;
            bodymsg += "</deviceSerialNo><serviceCode>";
            bodymsg += svcCode;
            bodymsg += "</serviceCode><deviceType>asn</deviceType><ctn>";
            bodymsg += tbDeviceCTN.Text;
            bodymsg += "</ctn><mac></mac><iccId>";
            string iccid = lbIccid.Text;
            if (iccid.Length > 6)
                bodymsg += iccid.Substring(iccid.Length - 6, 6);
            else
                bodymsg += "000000";
            bodymsg += "</iccId></auth>";
            /*
                        XDocument xdoc = new XDocument(new XDeclaration("1.0", "UTF-8", null));
                        XElement xroot = new XElement("auth");
                        xdoc.Add(xroot);

                        XElement xparams = new XElement("deviceModel", model);
                        xroot.Add(xparams);
                        xparams = new XElement("deviceSerialNo", serialNo);
                        xroot.Add(xparams);
                        xparams = new XElement("serviceCode", svcCode);
                        xroot.Add(xparams);
                        xparams = new XElement("deviceType", "apn");
                        xroot.Add(xparams);
                        xparams = new XElement("mac", string.Empty);
                        xroot.Add(xparams);
                        xparams = new XElement("ctn", tbDeviceCTN.Text);
                        xroot.Add(xparams);
                        string iccid = lbIccid.Text;
                        if (iccid.Length > 6)
                            xparams = new XElement("iccid", iccid.Substring(iccid.Length - 6, 6));
                        else
                            xparams = new XElement("iccid", "000000");
                        xroot.Add(xparams);
                        xparams = new XElement("useLongUuid", "false");
                        xroot.Add(xparams);

                        StringWriter writer = new StringWriter();
                        Console.WriteLine(xdoc.Declaration.Encoding);
                        xdoc.Save(writer);
                        Console.WriteLine(writer.ToString());

                        string retStr = DeviceHttpRequest(header, writer.ToString()); // xml
            */
            string retStr = DeviceHttpRequest(header, bodymsg);
            if (retStr != string.Empty)
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(retStr);
                //LogWrite(xDoc.OuterXml.ToString());

                XmlNodeList xnList = xDoc.SelectNodes("/authdata/http"); //접근할 노드
                foreach (XmlNode xn in xnList)
                {
                    dev.enrmtKey = xn["enrmtKey"].InnerText; // oneM2M 인증 KeyID를 생성하기 위한 Key
                    dev.entityId = xn["entityId"].InnerText; // oneM2M에서 사용하는 단말 ID
                    dev.token = xn["token"].InnerText; // 인증구간 통신을 위해 발급하는 Token
                }

                // EKI값 계산하기
                // short uuid구하기
                string suuid = dev.entityId.Substring(10, 10);
                //LogWrite("suuid = " + suuid);

                // KeyData Base64URL Decoding
                string output = dev.enrmtKey;
                output = output.Replace('-', '+'); // 62nd char of encoding
                output = output.Replace('_', '/'); // 63rd char of encoding

                switch (output.Length % 4) // Pad with trailing '='s
                {
                    case 0:
                        break; // No pad chars in this case
                    case 2:
                        output += "==";
                        break; // Two pad chars
                    case 3:
                        output += "=";
                        break; // One pad char
                    default:
                        throw new ArgumentOutOfRangeException(
                            nameof(dev.enrmtKey), "Illegal base64url string!");
                }

                var converted = Convert.FromBase64String(output); // Standard base64 decoder

                // keyData로 AES 128비트 비밀키 생성
                System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
                AesManaged tdes = new AesManaged();
                tdes.Key = converted;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;
                ICryptoTransform crypt = tdes.CreateEncryptor();
                byte[] plain = Encoding.UTF8.GetBytes(suuid);
                byte[] cipher = crypt.TransformFinalBlock(plain, 0, plain.Length);
                String enrmtKeyId = Convert.ToBase64String(cipher);

                enrmtKeyId = enrmtKeyId.Split('=')[0]; // Remove any trailing '='s
                enrmtKeyId = enrmtKeyId.Replace('+', '-'); // 62nd char of encoding
                enrmtKeyId = enrmtKeyId.Replace('/', '_'); // 63rd char of encoding

                dev.enrmtKeyId = enrmtKeyId;
                Console.WriteLine("dev.enrmtKeyId = " + dev.enrmtKeyId);
                dev.remoteCSEName = "csr-m2m_" + tbDeviceCTN.Text;
            }
        }

        public string DeviceHttpRequest(ReqHeader header, string data)
        {
            string resResult = string.Empty;

            try
            {
                wReq = (HttpWebRequest)WebRequest.Create(header.Url);
                wReq.Method = header.Method;
                if (header.Accept != string.Empty)
                    wReq.Accept = header.Accept;
                if (header.ContentType != string.Empty)
                    wReq.ContentType = header.ContentType;
                if (header.X_M2M_RI != string.Empty)
                    wReq.Headers.Add("X-M2M-RI", header.X_M2M_RI);
                if (header.X_M2M_Origin != string.Empty)
                    wReq.Headers.Add("X-M2M-Origin", header.X_M2M_Origin);
                if (header.X_M2M_NM != string.Empty)
                    wReq.Headers.Add("X-M2M-NM", header.X_M2M_NM);
                if (header.X_MEF_TK != string.Empty)
                    wReq.Headers.Add("X-MEF-TK", header.X_MEF_TK);
                if (header.X_MEF_EKI != string.Empty)
                    wReq.Headers.Add("X-MEF-EKI", header.X_MEF_EKI);
                wReq.Headers.Add("X-LGU-DM", tBoxDeviceModel.Text);
                wReq.Headers.Add("X-LGU-NI", "20");

                DevLogWrite(wReq.Method + " " + wReq.RequestUri, "T");
                Console.WriteLine(wReq.Method + " " + wReq.RequestUri + " HTTP/1.1");
                Console.WriteLine("");
                for (int i = 0; i < wReq.Headers.Count; ++i)
                    Console.WriteLine(wReq.Headers.Keys[i] + ": " + wReq.Headers[i]);
                Console.WriteLine("");
                Console.WriteLine(data);
                Console.WriteLine("");

                // POST 전송일 경우      
                if (header.Method == "POST")
                {
                    byte[] byteArray = Encoding.UTF8.GetBytes(data);
                    Stream dataStream = wReq.GetRequestStream();
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    dataStream.Close();
                }

                wReq.Timeout = 20000;          // 서버 응답을 20초동안 기다림
                using (wRes = (HttpWebResponse)wReq.GetResponse())
                {
                    DevLogWrite((int)wRes.StatusCode + " " + wRes.StatusCode.ToString(), "R");
                    Console.WriteLine("HTTP/1.1 " + (int)wRes.StatusCode + " " + wRes.StatusCode.ToString());
                    Console.WriteLine("");
                    for (int i = 0; i < wRes.Headers.Count; ++i)
                        Console.WriteLine("[" + wRes.Headers.Keys[i] + "] " + wRes.Headers[i]);
                    Console.WriteLine("");

                    Stream respPostStream = wRes.GetResponseStream();
                    StreamReader readerPost = new StreamReader(respPostStream, Encoding.GetEncoding("UTF-8"), true);
                    resResult = readerPost.ReadToEnd();
                    if (resResult.StartsWith("<?xml"))
                    {
                        XmlDocument xDoc = new XmlDocument();
                        xDoc.LoadXml(resResult);
                        StringWriter writer = new StringWriter();
                        xDoc.Save(writer);
                        Console.WriteLine(writer.ToString());
                    }
                    else if (resResult.StartsWith("{") || resResult.StartsWith("["))
                    {
                        string beautifiedJson = JValue.Parse(resResult).ToString((Newtonsoft.Json.Formatting)Formatting.Indented);
                        Console.WriteLine(beautifiedJson);
                    }
                    else
                        Console.WriteLine(resResult);
                    Console.WriteLine("");
                }
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError && ex.Response != null)
                {
                    var resp = (HttpWebResponse)ex.Response;
                    DevLogWrite((int)resp.StatusCode + " " + resp.StatusCode.ToString(), "R");
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
                    //Console.WriteLine("[" + (int)resp.StatusCode + "] " + resp.StatusCode.ToString());
                }
                else
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            return resResult;
        }

        private void DevLogWrite(string data, string dir)
        {
            BeginInvoke(new Action(() =>
            {
                string time = DateTime.Now.ToString("hh:mm:ss");

                ListViewItem newitem = new ListViewItem(new string[] { time, lbActionState.Text, dir, data });
                listView7.Items.Add(newitem);
                if (listView7.Items.Count > 35)
                    listView7.TopItem = listView7.Items[listView7.Items.Count - 1];
            }));
        }

        private void DevLogWriteNoTime(string data)
        {
            BeginInvoke(new Action(() =>
            {
                ListViewItem newitem = new ListViewItem(new string[] { string.Empty, string.Empty, string.Empty, data });
                listView7.Items.Add(newitem);
                if (listView7.Items.Count > 35)
                    listView7.TopItem = listView7.Items[listView7.Items.Count - 1];
            }));
        }

        private void button45_Click_1(object sender, EventArgs e)
        {
            if (dev.enrmtKeyId != string.Empty)
                DevCSEBaseGet();
            else
                MessageBox.Show("단말인증파라미터 세팅하세요");
        }

        private void DevCSEBaseGet()
        {
            ReqHeader header = new ReqHeader();
            header.Url = "http://" + oneM2MBRKIP + ":" + oneM2MBRKPort + "/IN_CSE-BASE-1/cb-1";
            header.Method = "GET";
            header.Accept = "application/xml";
            header.X_M2M_RI = DateTime.Now.ToString("yyyyMMddHHmmss") + "CSEBase_Retrieve";
            header.X_M2M_Origin = dev.entityId;
            header.X_MEF_TK = dev.token;
            header.X_MEF_EKI = dev.enrmtKeyId;
            header.X_M2M_NM = string.Empty;
            string retStr = DeviceHttpRequest(header, string.Empty);
            if (retStr != string.Empty)
                DevLogWriteNoTime(retStr);
        }

        private void button46_Click_1(object sender, EventArgs e)
        {
            if (dev.enrmtKeyId != string.Empty)
                DevRemoteCSEGet();
            else
                MessageBox.Show("단말인증파라미터 세팅하세요");
        }

        private void DevRemoteCSEGet()
        {
            ReqHeader header = new ReqHeader();
            header.Url = "http://" + oneM2MBRKIP + ":" + oneM2MBRKPort + "/IN_CSE-BASE-1/cb-1/" + dev.remoteCSEName;
            header.Method = "GET";
            header.Accept = "application/xml";
            header.X_M2M_RI = DateTime.Now.ToString("yyyyMMddHHmmss") + "RemoteCSE_Retrieve";
            header.X_M2M_Origin = dev.entityId;
            header.X_MEF_TK = dev.token;
            header.X_MEF_EKI = dev.enrmtKeyId;
            header.X_M2M_NM = string.Empty;
            string retStr = DeviceHttpRequest(header, string.Empty);
            if (retStr != string.Empty)
                DevLogWriteNoTime(retStr);
        }

        private void button47_Click_1(object sender, EventArgs e)
        {
            if (dev.enrmtKeyId != string.Empty)
                DevRemoteCSECreate();
            else
                MessageBox.Show("단말인증파라미터 세팅하세요");
        }

        // 3. RemoteCSE-Create
        private void DevRemoteCSECreate()
        {
            ReqHeader header = new ReqHeader();
            header.Url = "http://" + oneM2MBRKIP + ":" + oneM2MBRKPort + "/IN_CSE-BASE-1/cb-1";
            header.Method = "POST";
            header.Accept = "application/vnd.onem2m-res+xml";
            header.ContentType = "application/vnd.onem2m-res+xml;ty=16";
            header.X_M2M_RI = DateTime.Now.ToString("yyyyMMddHHmmss") + "RemoteCSE_Create";
            header.X_M2M_Origin = dev.entityId;
            header.X_MEF_TK = dev.token;
            header.X_MEF_EKI = dev.enrmtKeyId;
            header.X_M2M_NM = dev.remoteCSEName;

            string packetStr = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
            packetStr += "<m2m:csr xmlns:m2m=\"http://www.onem2m.org/xml/protocols\">";
            packetStr += "<cst>3</cst>";
            packetStr += "<csi>/" + dev.entityId + "</csi>";
            packetStr += "<cb>/" + dev.entityId + "/cb-1</cb>";
            packetStr += "<acpi>cb-1/" + dev.remoteCSEName + "/acp-m2m_" + tbDeviceCTN.Text + "</acpi>";
            packetStr += "<rr>true</rr>";
            packetStr += "<poa>http://" + "10.215.253.225" + ":" + "9901" + "</poa>";
            packetStr += "</m2m:csr>";
            string retStr = DeviceHttpRequest(header, packetStr);
            //if (retStr != string.Empty)
            //    LogWrite(retStr);
        }

        private void button49_Click_1(object sender, EventArgs e)
        {
            if (dev.enrmtKeyId != string.Empty)
                DevRemoteCSEUpdate();
            else
                MessageBox.Show("단말인증파라미터 세팅하세요");
        }

        private void DevRemoteCSEUpdate()
        {
            ReqHeader header = new ReqHeader();
            header.Url = "http://" + oneM2MBRKIP + ":" + oneM2MBRKPort + "/IN_CSE-BASE-1/cb-1/"+ dev.remoteCSEName;
            header.Method = "PUT";
            header.Accept = "application/vnd.onem2m-res+xml";
            header.ContentType = "application/vnd.onem2m-res+xml";
            header.X_M2M_RI = DateTime.Now.ToString("yyyyMMddHHmmss") + "RemoteCSE_Update";
            header.X_M2M_Origin = dev.entityId;
            header.X_MEF_TK = dev.token;
            header.X_MEF_EKI = dev.enrmtKeyId;

            string packetStr = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
            packetStr += "<m2m:csr xmlns:m2m=\"http://www.onem2m.org/xml/protocols\">";
            packetStr += "<cst>3</cst>";
            packetStr += "<csi>/" + dev.entityId + "</csi>";
            packetStr += "<cb>/" + dev.entityId + "/cb-1</cb>";
            packetStr += "<acpi>cb-1/" + dev.remoteCSEName + "/acp-m2m_" + tbDeviceCTN.Text + "</acpi>";
            packetStr += "<rr>true</rr>";
            packetStr += "<poa>http://" + "10.215.253.225" + ":" + "9901" + "</poa>";
            packetStr += "</m2m:csr>";
            string retStr = DeviceHttpRequest(header, packetStr);
            //if (retStr != string.Empty)
            //    LogWrite(retStr);
        }
    }

    public class TCResult
    {
        public string[,] lwm2m { get; set; }           // LwM2M 항목별 시험결과
        public string[,] onem2m { get; set; }           // oneM2M 항목별 시험결과
    }

    public class Device
    {
        public string imsi { get; set; }            // 디바이스 전화번호
        public string imei { get; set; }            // 디바이스 IMEI
        public string iccid { get; set; }           // 디바이스 ICCID
        public string entityId { get; set; }        // oneM2M 디바이스 EntityID
        public string uuid { get; set; }            // oneM2M 디바이스 UUID

        public string maker { get; set; }           // 모듈 제조사
        public string model { get; set; }           // 모듈 모델명
        public string version { get; set; }         // 모듈 펌웨어 버전

        public string type { get; set; }            // 플랫폼 연동 방식 (None/oneM2M/LwM2M)

        public string enrmtKey { get; set; }        // oneM2M 인증 KeyID를 생성하기 위한 Key
        public string token { get; set; }           // 인증구간 통신을 위해 발급하는 Token
        public string enrmtKeyId { get; set; }      // MEF 인증 결과를 통해 생성하는 ID
        public string remoteCSEName { get; set; }   // RemoteCSE 리소스 이름
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
