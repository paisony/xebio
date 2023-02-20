var ADVIT_FORMID = "TI040F01";
var ADVIT_TARGETPGID = "ti040p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "ti040f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,22,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,33,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_LABEL_CD_FROM = 3;
var ADVIT_ID_LABEL_CD_FROM2 = 4;
var ADVIT_ID_LABEL_CD_TO = 5;
var ADVIT_ID_LABEL_CD_TO2 = 6;
var ADVIT_ID_LABEL_IP_FROM = 7;
var ADVIT_ID_LABEL_IP_FROM2 = 8;
var ADVIT_ID_LABEL_IP_FROM3 = 9;
var ADVIT_ID_LABEL_IP_FROM4 = 10;
var ADVIT_ID_LABEL_IP_TO = 11;
var ADVIT_ID_LABEL_IP_TO2 = 12;
var ADVIT_ID_LABEL_IP_TO3 = 13;
var ADVIT_ID_LABEL_IP_TO4 = 14;
var ADVIT_ID_LABEL_NM = 15;
var ADVIT_ID_LABEL_BIKO = 16;
var ADVIT_ID_SEARCHCNT = 17;
var ADVIT_ID_BTNSEARCH = 18;
var ADVIT_ID_BTNROWINS = 19;
var ADVIT_ID_BTNROWDEL = 20;
var ADVIT_ID_PGR = 21;
var ADVIT_ID_M1ROWNO = 22;
var ADVIT_ID_M1LABEL_CD = 23;
var ADVIT_ID_M1LABEL_CD2 = 24;
var ADVIT_ID_M1LABEL_IP = 25;
var ADVIT_ID_M1LABEL_IP2 = 26;
var ADVIT_ID_M1LABEL_IP3 = 27;
var ADVIT_ID_M1LABEL_IP4 = 28;
var ADVIT_ID_M1LABEL_NM = 29;
var ADVIT_ID_M1LABEL_BIKO = 30;
var ADVIT_ID_M1SELECTORCHECKBOX = 31;
var ADVIT_ID_M1ENTERSYORIFLG = 32;
var ADVIT_ID_M1DTLIROKBN = 33;
var ADVIT_ID_BTNENTER = 34;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Label_cd_from","Label_cd_from2"
	,"Label_cd_to","Label_cd_to2","Label_ip_from","Label_ip_from2","Label_ip_from3"
	,"Label_ip_from4","Label_ip_to","Label_ip_to2","Label_ip_to3","Label_ip_to4"
	,"Label_nm","Label_biko","Searchcnt","Btnsearch","Btnrowins"
	,"Btnrowdel","Pgr","M1rowno","M1label_cd","M1label_cd2"
	,"M1label_ip","M1label_ip2","M1label_ip3","M1label_ip4","M1label_nm"
	,"M1label_biko","M1selectorcheckbox","M1entersyoriflg","M1dtlirokbn","Btnenter"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","ラベル発行機ＩＤＦＲＯＭ","ラベル発行機ＩＤＦＲＯＭ2"
	,"ラベル発行機ＩＤＴＯ","ラベル発行機ＩＤＴＯ2","ラベル発行機ＩＰＦＲＯＭ","ラベル発行機ＩＰＦＲＯＭ2","ラベル発行機ＩＰＦＲＯＭ3"
	,"ラベル発行機ＩＰＦＲＯＭ4","ラベル発行機ＩＰＴＯ","ラベル発行機ＩＰＴＯ2","ラベル発行機ＩＰＴＯ3","ラベル発行機ＩＰＴＯ4"
	,"ラベル発行機名","ラベル備考","検索件数","検索ボタン","行追加ボタン"
	,"行削除ボタン","ページャ","Ｍ１行NO","Ｍ１ラベル発行機ＩＤ","Ｍ１ラベル発行機ＩＤ2"
	,"Ｍ１ラベル発行機ＩＰ","Ｍ１ラベル発行機ＩＰ2","Ｍ１ラベル発行機ＩＰ3","Ｍ１ラベル発行機ＩＰ4","Ｍ１ラベル発行機名"
	,"Ｍ１ラベル備考","Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)","確定ボタン"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","SG","SG"
	,"SG","SG","SG","SG","SG"
	,"SG","SG","SG","SG","SG"
	,"SN4","SN4","NA","B","B"
	,"B","B","NA","SG","SG"
	,"SG","SG","SG","SG","SN4"
	,"SN4","NA","NA","NA","B"
);
var ADVIT_LENGTH = new Array(
	4,0,15,4,3
	,4,3,3,3,3
	,3,3,3,3,3
	,10,40,4,0,0
	,0,0,3,4,3
	,3,3,3,3,10
	,40,1,1,2,0
);
var ADVIT_AUTOTAB = new Array(
	0,0,0,1,0
	,1,0,1,1,1
	,0,1,1,1,0
	,0,0,0,0,0
	,0,0,0,1,0
	,1,1,1,0,0
	,0,0,0,0,0
);
var ADVIT_DECIMAL = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
);
var ADVIT_REQUIRED = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
);
var ADVIT_REQUIREDFLG = new Array(
	1,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","TXT","TXT"
	,"TXT","TXT","TXT","TXT","TXT"
	,"TXT","TXT","TXT","TXT","TXT"
	,"TXT","TXT","TXR","BTS","BTS"
	,"BTS","LNS","TXR","TXT","TXT"
	,"TXT","TXT","TXT","TXT","TXT"
	,"TXT","CHK","HDN","HDN","BTS"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","00","00"
	,"00","00","10","10","10"
	,"10","10","10","10","10"
	,"00","00","12","00","00"
	,"00","00","11","00","00"
	,"10","10","10","10","00"
	,"00","11","11","11","00"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
);
var ADVIT_CODENAME = new Array(
	"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1",""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,1,0
	,0,1,0,0,0
	,0,0,0,0,0
	,0,0,0,0,1
);
var ADVIT_IMEMODE = new Array(
	3,0,0,3,3
	,3,3,3,3,3
	,3,3,3,3,3
	,1,1,0,0,0
	,0,0,0,3,3
	,3,3,3,3,1
	,1,0,0,0,0
);
var ADVIT_AUTOCODECHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,1,1
	,1,1,1,1,1
	,1,1,1,1,1
	,1,1,0,0,0
	,0,0,0,1,1
	,1,1,1,1,1
	,1,0,0,0,0
);
var ADVIT_CONDID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
);
var ADVIT_ACTIONID = new Array(
	"","COD","","",""
	,"","","","",""
	,"","","","",""
	,"","","","FRM","MADD"
	,"FRM","PGN","","",""
	,"","","","",""
	,"","","","","FRM"
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","TI040F01",""
	,"TI040F01","","","",""
	,"","","","",""
	,"","","","","TI040F01"
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","","M1"
	,"","M1","","",""
	,"","","","",""
	,"","","","",""
);
var ADVIT_ACTPROGRAMID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
);
var ADVIT_CAPTION = new Array(
	"店舗","","","ラベル発行機ＩＤＦＲＯＭ","ラベル発行機ＩＤＦＲＯＭ"
	,"ラベル発行機ＩＤＴＯ","ラベル発行機ＩＤＴＯ","ラベル発行機ＩＰＦＲＯＭ","ラベル発行機ＩＰＦＲＯＭ","ラベル発行機ＩＰＦＲＯＭ"
	,"ラベル発行機ＩＰＦＲＯＭ","ラベル発行機ＩＰＴＯ","ラベル発行機ＩＰＴＯ","ラベル発行機ＩＰＴＯ","ラベル発行機ＩＰＴＯ"
	,"ラベル発行機名","備考","","検索",""
	,"","","No.","ラベル発行機ＩＤ","ラベル発行機ＩＤ"
	,"ラベル発行機ＩＰ","ラベル発行機ＩＰ","ラベル発行機ＩＰ","ラベル発行機ＩＰ","ラベル発行機名"
	,"備考","","","","確定"
);

