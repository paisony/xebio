var ADVIT_FORMID = "TC010F01";
var ADVIT_TARGETPGID = "tc010p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tc010f01.aspx";

var ADVIT_M_PATTERN = new Array(0,0,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,-1,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,-1,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_DENPYO_JYOTAI = 3;
var ADVIT_ID_NYUKAYOTEI_YMD_FROM = 4;
var ADVIT_ID_NYUKAYOTEI_YMD_TO = 5;
var ADVIT_ID_SIIRE_KAKUTEI_YMD_FROM = 6;
var ADVIT_ID_SIIRE_KAKUTEI_YMD_TO = 7;
var ADVIT_ID_BTNPRINT = 8;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Denpyo_jyotai","Nyukayotei_ymd_from"
	,"Nyukayotei_ymd_to","Siire_kakutei_ymd_from","Siire_kakutei_ymd_to","Btnprint"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","伝票状態","入荷予定日ＦＲＯＭ"
	,"入荷予定日ＴＯ","仕入確定日ＦＲＯＭ","仕入確定日ＴＯ","印刷ボタン"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","SN5","D"
	,"D","D","D","B"
);
var ADVIT_LENGTH = new Array(
	4,0,15,1,0
	,0,0,0,0
);
var ADVIT_AUTOTAB = new Array(
	0,0,0,0,0
	,0,0,0,0
);
var ADVIT_DECIMAL = new Array(
	0,0,0,0,0
	,0,0,0,0
);
var ADVIT_REQUIRED = new Array(
	0,0,0,0,0
	,0,0,0,0
);
var ADVIT_REQUIREDFLG = new Array(
	1,0,0,0,0
	,0,0,0,0
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","DRL","TXT"
	,"TXT","TXT","TXT","BTS"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","00","52"
	,"52","52","52","00"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"","","",""
);
var ADVIT_CODENAME = new Array(
	"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","",""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,1
);
var ADVIT_IMEMODE = new Array(
	3,0,0,0,3
	,3,3,3,0
);
var ADVIT_AUTOCODECHK = new Array(
	0,0,0,0,0
	,0,0,0,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,0,1
	,1,1,1,0
);
var ADVIT_CONDID = new Array(
	"","","","KYAKUCHU_DENPYO_JOTAI",""
	,"","","",""
);
var ADVIT_ACTIONID = new Array(
	"","COD","","",""
	,"","","","FRM"
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","",""
	,"","","","TC010F01"
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","",""
);
var ADVIT_ACTPROGRAMID = new Array(
	"","","","",""
	,"","","",""
);
var ADVIT_CAPTION = new Array(
	"店舗","","","伝票状態","入荷予定日ＦＲＯＭ"
	,"入荷予定日ＴＯ","仕入確定日ＦＲＯＭ","仕入確定日ＴＯ",""
);

