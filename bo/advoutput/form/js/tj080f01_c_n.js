var ADVIT_FORMID = "TJ080F01";
var ADVIT_TARGETPGID = "tj080p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tj080f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,22,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,32,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_BTNMODEREF = 3;
var ADVIT_ID_BTNMODESYURYOKAKUNINREF = 4;
var ADVIT_ID_MODENO = 5;
var ADVIT_ID_STKMODENO = 6;
var ADVIT_ID_TENPO_CD_FROM = 7;
var ADVIT_ID_BTNTENPOCD_FROM = 8;
var ADVIT_ID_TENPO_NM_FROM = 9;
var ADVIT_ID_TENPO_CD_TO = 10;
var ADVIT_ID_BTNTENPOCD_TO = 11;
var ADVIT_ID_TENPO_NM_TO = 12;
var ADVIT_ID_TENPO_KAKUTEI_JYOKYO = 13;
var ADVIT_ID_SOSIN_JYOTAI = 14;
var ADVIT_ID_SOSIN_YMD_FROM = 15;
var ADVIT_ID_SOSIN_YMD_TO = 16;
var ADVIT_ID_KONKAI_FLG = 17;
var ADVIT_ID_SEARCHCNT = 18;
var ADVIT_ID_BTNSEARCH = 19;
var ADVIT_ID_BTNPRINT = 20;
var ADVIT_ID_PGR = 21;
var ADVIT_ID_M1ROWNO = 22;
var ADVIT_ID_M1TENPO_CD = 23;
var ADVIT_ID_M1TENPO_NM = 24;
var ADVIT_ID_M1SOSIN_KAK_YMD = 25;
var ADVIT_ID_M1TENPO_KAKUTEI_JYOKYO = 26;
var ADVIT_ID_M1TENPO_KAKUTEI_JYOKYO_NM = 27;
var ADVIT_ID_M1MD_SOSIN_JYOKYO = 28;
var ADVIT_ID_M1MD_SOSIN_JYOKYO_NM = 29;
var ADVIT_ID_M1SELECTORCHECKBOX = 30;
var ADVIT_ID_M1ENTERSYORIFLG = 31;
var ADVIT_ID_M1DTLIROKBN = 32;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Btnmoderef","Btnmodesyuryokakuninref"
	,"Modeno","Stkmodeno","Tenpo_cd_from","Btntenpocd_from","Tenpo_nm_from"
	,"Tenpo_cd_to","Btntenpocd_to","Tenpo_nm_to","Tenpo_kakutei_jyokyo","Sosin_jyotai"
	,"Sosin_ymd_from","Sosin_ymd_to","Konkai_flg","Searchcnt","Btnsearch"
	,"Btnprint","Pgr","M1rowno","M1tenpo_cd","M1tenpo_nm"
	,"M1sosin_kak_ymd","M1tenpo_kakutei_jyokyo","M1tenpo_kakutei_jyokyo_nm","M1md_sosin_jyokyo","M1md_sosin_jyokyo_nm"
	,"M1selectorcheckbox","M1entersyoriflg","M1dtlirokbn"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","モード照会ボタン","モード終了確認照会ボタン"
	,"モードNO","選択モードNO","店舗コードFROM","店舗コードFROMボタン","店舗名FROM"
	,"店舗コードTO","店舗コードTOボタン","店舗名TO","店舗確定状況","送信状態"
	,"送信日FROM","送信日TO","今回フラグ","検索件数","検索ボタン"
	,"ボタン印刷","ページャ","Ｍ１行NO","Ｍ１店舗コード","Ｍ１店舗名"
	,"Ｍ１送信確定日","Ｍ１店舗確定状況","Ｍ１店舗確定状況名称","Ｍ１ＭＤ送信状況","Ｍ１ＭＤ送信状況名称"
	,"Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","B","B"
	,"NA","NA","SG","B","SN4"
	,"SG","B","SN4","SB","SB"
	,"D","D","NA","NA","B"
	,"B","B","NA","SG","SN4"
	,"D","NA","SN4","NA","SN4"
	,"NA","NA","NA"
);
var ADVIT_LENGTH = new Array(
	4,0,15,0,0
	,2,2,4,0,15
	,4,0,15,1,1
	,0,0,1,4,0
	,0,0,4,4,15
	,0,1,6,1,5
	,1,1,2
);
var ADVIT_AUTOTAB = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0
);
var ADVIT_DECIMAL = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0
);
var ADVIT_REQUIRED = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0
);
var ADVIT_REQUIREDFLG = new Array(
	1,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","LNK","LNK"
	,"HDN","HDN","TXT","BTN","TXR"
	,"TXT","BTN","TXR","DRL","DRL"
	,"TXT","TXT","CHK","TXR","BTS"
	,"BTS","LNS","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"CHK","HDN","HDN"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","00","00"
	,"11","11","10","00","00"
	,"10","00","00","00","00"
	,"52","52","11","12","00"
	,"00","00","11","10","00"
	,"52","11","00","11","00"
	,"11","11","11"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"","","","C_TENPO_CD",""
	,"","C_TENPO_CD","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","",""
);
var ADVIT_CODENAME = new Array(
	"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET"
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1"
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,1
	,1,1,0,0,0
	,0,0,0,0,0
	,0,0,0
);
var ADVIT_IMEMODE = new Array(
	3,0,0,0,0
	,0,0,3,0,0
	,3,0,0,0,0
	,3,3,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0
);
var ADVIT_AUTOCODECHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,0,0
	,0,0,1,0,0
	,1,0,0,0,0
	,1,1,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0
);
var ADVIT_CONDID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","TENPO_KAKUTEI_JOKYO","SOSIN_JOTAI"
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","",""
);
var ADVIT_ACTIONID = new Array(
	"","COD","","SPT","SPT"
	,"","","","COD",""
	,"","COD","","",""
	,"","","","","FRM"
	,"FRM","PGN","","",""
	,"","","","",""
	,"","",""
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","TJ080F01","TJ080F01"
	,"","","","",""
	,"","","","",""
	,"","","","","TJ080F01"
	,"TJ080F01","","","",""
	,"","","","",""
	,"","",""
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","M1","","",""
	,"","","","",""
	,"","",""
);
var ADVIT_ACTPROGRAMID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","",""
);
var ADVIT_CAPTION = new Array(
	"店舗","","","照会","終了確認照会"
	,"","","店舗","",""
	,"","","","店舗確定状況","送信状態"
	,"送信日ＦＲＯＭ","送信日ＴＯ","今回分のみ","","検索"
	,"","","No.","店舗",""
	,"送信確定日","店舗確定状況","","ＭＤ送信状況",""
	,"","",""
);

