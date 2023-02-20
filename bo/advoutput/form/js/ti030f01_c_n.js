var ADVIT_FORMID = "TI030F01";
var ADVIT_TARGETPGID = "ti030p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "ti030f01.aspx";

var ADVIT_M_PATTERN = new Array(0,0,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,-1,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,-1,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_SYOHIZEI_RTU1 = 3;
var ADVIT_ID_SYOHIZEIKAISI_YMD1 = 4;
var ADVIT_ID_ZEISYORI_KB1 = 5;
var ADVIT_ID_SYOHIZEI_RTU2 = 6;
var ADVIT_ID_SYOHIZEIKAISI_YMD2 = 7;
var ADVIT_ID_ZEISYORI_KB2 = 8;
var ADVIT_ID_BTNENTER = 9;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Syohizei_rtu1","Syohizeikaisi_ymd1"
	,"Zeisyori_kb1","Syohizei_rtu2","Syohizeikaisi_ymd2","Zeisyori_kb2","Btnenter"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","消費税率１","消費税開始日１"
	,"税処理区分１","消費税率２","消費税開始日２","税処理区分２","確定ボタン"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","NA","D"
	,"SN5","NA","D","SN5","B"
);
var ADVIT_LENGTH = new Array(
	4,0,15,3,0
	,1,3,0,1,0
);
var ADVIT_AUTOTAB = new Array(
	0,0,0,0,0
	,0,0,0,0,0
);
var ADVIT_DECIMAL = new Array(
	0,0,0,0,0
	,0,0,0,0,0
);
var ADVIT_REQUIRED = new Array(
	0,0,0,0,0
	,0,0,0,0,0
);
var ADVIT_REQUIREDFLG = new Array(
	1,0,0,1,1
	,0,1,1,0,0
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","TXT","TXT"
	,"DRL","TXT","TXT","DRL","BTS"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","11","52"
	,"00","11","52","00","00"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"","","","",""
);
var ADVIT_CODENAME = new Array(
	"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,1
);
var ADVIT_IMEMODE = new Array(
	3,0,0,3,3
	,0,3,3,0,0
);
var ADVIT_AUTOCODECHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,1,1
	,0,1,1,0,0
);
var ADVIT_CONDID = new Array(
	"","","","",""
	,"ZEISYORI_KBN","","","ZEISYORI_KBN",""
);
var ADVIT_ACTIONID = new Array(
	"","COD","","",""
	,"","","","","DBU"
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","",""
	,"","","","","TI030F01"
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
);
var ADVIT_ACTPROGRAMID = new Array(
	"","","","",""
	,"","","","",""
);
var ADVIT_CAPTION = new Array(
	"店舗","","","消費税率１","税率１開始日"
	,"税処理区分1","消費税率２","税率２開始日","税処理区分2","確定"
);

