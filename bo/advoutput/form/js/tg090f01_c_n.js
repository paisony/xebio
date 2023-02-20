var ADVIT_FORMID = "TG090F01";
var ADVIT_TARGETPGID = "tg090p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tg090f01.aspx";

var ADVIT_M_PATTERN = new Array(0,0,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,-1,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,-1,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_YMD_FROM = 3;
var ADVIT_ID_YMD_TO = 4;
var ADVIT_ID_TANTOSYA_CD = 5;
var ADVIT_ID_BTNTANTO_CD = 6;
var ADVIT_ID_HANBAIIN_NM = 7;
var ADVIT_ID_TYOTATSU_KB = 8;
var ADVIT_ID_BTNCSV = 9;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Ymd_from","Ymd_to"
	,"Tantosya_cd","Btntanto_cd","Hanbaiin_nm","Tyotatsu_kb","Btncsv"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","日付ＦＲＯＭ","日付ＴＯ"
	,"担当者コード","ボタン担当者コード","担当者名","調達区分","CSVボタン"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","D","D"
	,"SG","B","SN4","SN5","B"
);
var ADVIT_LENGTH = new Array(
	4,0,15,0,0
	,7,0,12,1,0
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
	1,0,0,0,0
	,0,0,0,0,0
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","TXT","TXT"
	,"TXT","BTN","TXR","RDO","BTS"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","52","52"
	,"10","00","00","00","00"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"","C_TANTO_CD","","",""
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
	,3,0,0,0,0
);
var ADVIT_AUTOCODECHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,1,1
	,1,0,0,0,0
);
var ADVIT_CONDID = new Array(
	"","","","",""
	,"","","","TYOTATSU_JOKEN",""
);
var ADVIT_ACTIONID = new Array(
	"","COD","","",""
	,"","COD","","","FRM"
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","",""
	,"","","","","TG090F01"
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
	"店舗","","","日付ＦＲＯＭ","日付ＴＯ"
	,"担当者","","","PB(SMU含む)/NB",""
);

