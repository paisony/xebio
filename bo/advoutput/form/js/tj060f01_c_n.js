var ADVIT_FORMID = "TJ060F01";
var ADVIT_TARGETPGID = "tj060p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tj060f01.aspx";

var ADVIT_M_PATTERN = new Array(0,0,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,-1,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,-1,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_BTNMODEKONKAI = 3;
var ADVIT_ID_BTNMODEZENKAI = 4;
var ADVIT_ID_MODENO = 5;
var ADVIT_ID_STKMODENO = 6;
var ADVIT_ID_TANAOROSIKIJUN_YMD = 7;
var ADVIT_ID_TANAOROSIJISSI_YMD = 8;
var ADVIT_ID_TANAOROSIKIKAN_FROM = 9;
var ADVIT_ID_TANAOROSIKIKAN_TO = 10;
var ADVIT_ID_TANAOROSIKIJUN_YMD1 = 11;
var ADVIT_ID_TANAOROSIJISSI_YMD1 = 12;
var ADVIT_ID_TANAOROSIKIKAN_FROM1 = 13;
var ADVIT_ID_TANAOROSIKIKAN_TO1 = 14;
var ADVIT_ID_TANAOROSI_HOKOKUSYO_KB = 15;
var ADVIT_ID_BTNPRINT = 16;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Btnmodekonkai","Btnmodezenkai"
	,"Modeno","Stkmodeno","Tanaorosikijun_ymd","Tanaorosijissi_ymd","Tanaorosikikan_from"
	,"Tanaorosikikan_to","Tanaorosikijun_ymd1","Tanaorosijissi_ymd1","Tanaorosikikan_from1","Tanaorosikikan_to1"
	,"Tanaorosi_hokokusyo_kb","Btnprint"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","モード今回ボタン","モード前回ボタン"
	,"モードNO","選択モードNO","今回棚卸基準日(隠し)","今回棚卸実施日","今回棚卸期間FROM"
	,"今回棚卸期間TO","前回棚卸基準日(隠し)","前回棚卸実施日","前回棚卸期間FROM","前回棚卸期間TO"
	,"棚卸報告書区分","印刷ボタン"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","B","B"
	,"NA","NA","D","D","D"
	,"D","D","D","D","D"
	,"SN5","B"
);
var ADVIT_LENGTH = new Array(
	4,0,15,0,0
	,2,2,0,0,0
	,0,0,0,0,0
	,1,0
);
var ADVIT_AUTOTAB = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0
);
var ADVIT_DECIMAL = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0
);
var ADVIT_REQUIRED = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0
);
var ADVIT_REQUIREDFLG = new Array(
	1,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","LNK","LNK"
	,"HDN","HDN","HDN","TXR","TXR"
	,"TXR","HDN","TXR","TXR","TXR"
	,"RDO","BTS"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","00","00"
	,"11","11","52","52","52"
	,"52","52","52","52","52"
	,"00","00"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"","","","",""
	,"","","","",""
	,"",""
);
var ADVIT_CODENAME = new Array(
	"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET"
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"",""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,1
);
var ADVIT_IMEMODE = new Array(
	3,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0
);
var ADVIT_AUTOCODECHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0
);
var ADVIT_CONDID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"TANAOROSI_HOKOKUSYO_X",""
);
var ADVIT_ACTIONID = new Array(
	"","COD","","SPT","SPT"
	,"","","","",""
	,"","","","",""
	,"","FRM"
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","TJ060F01","TJ060F01"
	,"","","","",""
	,"","","","",""
	,"","TJ060F01"
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"",""
);
var ADVIT_ACTPROGRAMID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"",""
);
var ADVIT_CAPTION = new Array(
	"店舗","","","今回","前回"
	,"","","","棚卸実施日","棚卸期間"
	,"","","棚卸実施日","棚卸期間",""
	,"",""
);

