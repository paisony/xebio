var ADVIT_FORMID = "TA040F01";
var ADVIT_TARGETPGID = "ta040p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "ta040f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,15,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,24,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_HENKO_KBN = 3;
var ADVIT_ID_BUMON_CD_FROM = 4;
var ADVIT_ID_BTNBUMON_CD_FROM = 5;
var ADVIT_ID_BUMON_NM_FROM = 6;
var ADVIT_ID_BUMON_CD_TO = 7;
var ADVIT_ID_BTNBUMON_CD_TO = 8;
var ADVIT_ID_BUMON_NM_TO = 9;
var ADVIT_ID_KESSAI_YMD_FROM = 10;
var ADVIT_ID_KESSAI_YMD_TO = 11;
var ADVIT_ID_SEARCHCNT = 12;
var ADVIT_ID_BTNSEARCH = 13;
var ADVIT_ID_PGR = 14;
var ADVIT_ID_M1ROWNO = 15;
var ADVIT_ID_M1HENKO_KBN_NM = 16;
var ADVIT_ID_M1BUMON_CD = 17;
var ADVIT_ID_M1HATTYU_SU = 18;
var ADVIT_ID_M1HAIBUN_SU = 19;
var ADVIT_ID_M1GENKAKIN = 20;
var ADVIT_ID_M1KESSAI_YMD = 21;
var ADVIT_ID_M1SELECTORCHECKBOX = 22;
var ADVIT_ID_M1ENTERSYORIFLG = 23;
var ADVIT_ID_M1DTLIROKBN = 24;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Henko_kbn","Bumon_cd_from"
	,"Btnbumon_cd_from","Bumon_nm_from","Bumon_cd_to","Btnbumon_cd_to","Bumon_nm_to"
	,"Kessai_ymd_from","Kessai_ymd_to","Searchcnt","Btnsearch","Pgr"
	,"M1rowno","M1henko_kbn_nm","M1bumon_cd","M1hattyu_su","M1haibun_su"
	,"M1genkakin","M1kessai_ymd","M1selectorcheckbox","M1entersyoriflg","M1dtlirokbn"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","変更区分","部門コードFROM"
	,"部門コードFROMボタン","部門名FROM","部門コードTO","部門コードTOボタン","部門名TO"
	,"決裁日FROM","決裁日TO","検索件数","検索ボタン","ページャ"
	,"Ｍ１行NO","Ｍ１変更区分名称","Ｍ１部門リンク","Ｍ１発注数量","Ｍ１配分数量"
	,"Ｍ１原価金額","Ｍ１決裁日","Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","NA","SG"
	,"B","SN4","SG","B","SN4"
	,"D","D","NA","B","B"
	,"NA","SN4","B","NC","NC"
	,"NC","D","NA","NA","NA"
);
var ADVIT_LENGTH = new Array(
	4,0,15,1,3
	,0,15,3,0,15
	,0,0,4,0,0
	,4,6,0,9,9
	,9,0,1,1,2
);
var ADVIT_AUTOTAB = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
);
var ADVIT_DECIMAL = new Array(
	0,0,0,0,0
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
);
var ADVIT_REQUIREDFLG = new Array(
	1,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","DRL","TXT"
	,"BTN","TXR","TXT","BTN","TXR"
	,"TXT","TXT","TXR","BTS","LNS"
	,"TXR","TXR","BTS","TXR","TXR"
	,"TXR","TXR","CHK","HDN","HDN"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","11","10"
	,"00","00","10","00","00"
	,"52","52","12","00","00"
	,"11","00","00","12","12"
	,"12","52","11","11","11"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"C_BUMON_CD","","","C_BUMON_CD",""
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
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,1,1
	,0,0,0,0,0
	,0,0,0,0,0
);
var ADVIT_IMEMODE = new Array(
	3,0,0,0,3
	,0,0,3,0,0
	,3,3,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
);
var ADVIT_AUTOCODECHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,0,1
	,0,0,1,0,0
	,1,1,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
);
var ADVIT_CONDID = new Array(
	"","","","HENKO_KBN",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
);
var ADVIT_ACTIONID = new Array(
	"","COD","","",""
	,"COD","","","COD",""
	,"","","","FRM","PGN"
	,"","","FRM","",""
	,"","","","",""
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","TA040F01",""
	,"","","TA040F02","",""
	,"","","","",""
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","","M1"
	,"","","M1","",""
	,"","","","",""
);
var ADVIT_ACTPROGRAMID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
);
var ADVIT_CAPTION = new Array(
	"店舗","","","変更区分","部門ＦＲＯＭ"
	,"","","部門ＴＯ","",""
	,"決裁日ＦＲＯＭ","決裁日ＴＯ","","検索",""
	,"No.","変更区分","部門","発注数量","配分数量"
	,"原価金額","決裁日","","",""
);

