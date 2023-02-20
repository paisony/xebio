var ADVIT_FORMID = "TE030F01";
var ADVIT_TARGETPGID = "te030p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "te030f01.aspx";

var ADVIT_M_PATTERN = new Array(0,0,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,-1,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,-1,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_SHUTURYOKU_KBN = 3;
var ADVIT_ID_JYURYO_YMD_FROM = 4;
var ADVIT_ID_JYURYO_YMD_TO = 5;
var ADVIT_ID_BTNPRINT = 6;
var ADVIT_ID_JYURYO_YMD_HDN = 7;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Shuturyoku_kbn","Jyuryo_ymd_from"
	,"Jyuryo_ymd_to","Btnprint","Jyuryo_ymd_hdn"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","出力区分","入荷日FROM"
	,"入荷日TO","印刷ボタン","入荷日(隠し)"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","SN5","D"
	,"D","B","D"
);
var ADVIT_LENGTH = new Array(
	4,0,15,1,0
	,0,0,0
);
var ADVIT_AUTOTAB = new Array(
	0,0,0,0,0
	,0,0,0
);
var ADVIT_DECIMAL = new Array(
	0,0,0,0,0
	,0,0,0
);
var ADVIT_REQUIRED = new Array(
	0,0,0,0,0
	,0,0,0
);
var ADVIT_REQUIREDFLG = new Array(
	1,0,0,0,0
	,0,0,0
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","RDO","TXT"
	,"TXT","BTS","HDN"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","00","52"
	,"52","00","52"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"","",""
);
var ADVIT_CODENAME = new Array(
	"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET"
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","",""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,1,0
);
var ADVIT_IMEMODE = new Array(
	3,0,0,0,3
	,3,0,0
);
var ADVIT_AUTOCODECHK = new Array(
	0,0,0,0,0
	,0,0,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,0,1
	,1,0,0
);
var ADVIT_CONDID = new Array(
	"","","","SHUTURYOKU_KBN",""
	,"","",""
);
var ADVIT_ACTIONID = new Array(
	"","COD","","",""
	,"","FRM",""
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","",""
	,"","TE030F01",""
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","",""
);
var ADVIT_ACTPROGRAMID = new Array(
	"","","","",""
	,"","",""
);
var ADVIT_CAPTION = new Array(
	"店舗","","","出力区分","入荷日ＦＲＯＭ"
	,"入荷日ＴＯ","",""
);

