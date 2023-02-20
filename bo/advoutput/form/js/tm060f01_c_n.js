var ADVIT_FORMID = "TM060F01";
var ADVIT_TARGETPGID = "tm060p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tm060f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,14,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,22,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_TANTOSYA_CD_FROM = 3;
var ADVIT_ID_BTNTANTO_CD_FROM = 4;
var ADVIT_ID_HANBAIIN_NM_FROM = 5;
var ADVIT_ID_TANTOSYA_CD_TO = 6;
var ADVIT_ID_BTNTANTO_CD_TO = 7;
var ADVIT_ID_HANBAIIN_NM_TO = 8;
var ADVIT_ID_SYOKUSEI_KB = 9;
var ADVIT_ID_SEARCHCNT = 10;
var ADVIT_ID_KENGEN_KB = 11;
var ADVIT_ID_BTNSEARCH = 12;
var ADVIT_ID_PGR = 13;
var ADVIT_ID_M1ROWNO = 14;
var ADVIT_ID_M1TANTOSYA_CD = 15;
var ADVIT_ID_M1HANBAIIN_NM = 16;
var ADVIT_ID_M1SYOKUSEI_KB_NM = 17;
var ADVIT_ID_M1KENGEN_KB = 18;
var ADVIT_ID_M1PASSWARDSYOKIKA = 19;
var ADVIT_ID_M1SELECTORCHECKBOX = 20;
var ADVIT_ID_M1ENTERSYORIFLG = 21;
var ADVIT_ID_M1DTLIROKBN = 22;
var ADVIT_ID_BTNENTER = 23;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Tantosya_cd_from","Btntanto_cd_from"
	,"Hanbaiin_nm_from","Tantosya_cd_to","Btntanto_cd_to","Hanbaiin_nm_to","Syokusei_kb"
	,"Searchcnt","Kengen_kb","Btnsearch","Pgr","M1rowno"
	,"M1tantosya_cd","M1hanbaiin_nm","M1syokusei_kb_nm","M1kengen_kb","M1passwardsyokika"
	,"M1selectorcheckbox","M1entersyoriflg","M1dtlirokbn","Btnenter"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","担当者コードＦＲＯＭ","担当者コードＦＲＯＭボタン"
	,"担当者名ＦＲＯＭ","担当者コードＴＯ","担当者コードＴＯボタン","担当者名ＴＯ","職制区分"
	,"検索件数","権限区分","検索ボタン","ページャ","Ｍ１行NO"
	,"Ｍ１担当者コード","Ｍ１担当者名","Ｍ１職制区分名称","Ｍ１権限区分","Ｍ１パスワード初期化"
	,"Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)","確定ボタン"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","SG","B"
	,"SN4","SG","B","SN4","SN5"
	,"NA","SN5","B","B","NA"
	,"SG","SN4","SN4","SN5","NA"
	,"NA","NA","NA","B"
);
var ADVIT_LENGTH = new Array(
	4,0,15,7,0
	,12,7,0,12,4
	,4,2,0,0,4
	,7,12,5,2,1
	,1,1,2,0
);
var ADVIT_AUTOTAB = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0
);
var ADVIT_DECIMAL = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0
);
var ADVIT_REQUIRED = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0
);
var ADVIT_REQUIREDFLG = new Array(
	1,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","TXT","BTN"
	,"TXR","TXT","BTN","TXR","DRL"
	,"TXR","DRL","BTS","LNS","TXR"
	,"TXR","TXR","TXR","DRL","CHK"
	,"CHK","HDN","HDN","BTS"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","10","00"
	,"00","10","00","00","00"
	,"12","00","00","00","11"
	,"10","00","00","00","11"
	,"11","11","11","00"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","","C_TANTO_CD"
	,"","","C_TANTO_CD","","C_MEISYO_CD"
	,"","","","",""
	,"","","","",""
	,"","","",""
);
var ADVIT_CODENAME = new Array(
	"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
	,"","","","","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1",""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,1,1,0
	,0,0,0,0,0
	,0,0,0,1
);
var ADVIT_IMEMODE = new Array(
	3,0,0,3,0
	,0,3,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0
);
var ADVIT_AUTOCODECHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,1,0
	,0,1,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0
);
var ADVIT_CONDID = new Array(
	"","","","",""
	,"","","","",""
	,"","KENGEN","","",""
	,"","","","KENGEN",""
	,"","","",""
);
var ADVIT_ACTIONID = new Array(
	"","COD","","","COD"
	,"","","COD","","COD"
	,"","","FRM","PGN",""
	,"","","","",""
	,"","","","FRM"
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","",""
	,"","","","",""
	,"","","TM060F01","",""
	,"","","","",""
	,"","","","TM060F01"
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","M1",""
	,"","","","",""
	,"","","",""
);
var ADVIT_ACTPROGRAMID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","",""
);
var ADVIT_CAPTION = new Array(
	"店舗","","","担当者コードＦＲＯＭ",""
	,"","担当者コードＴＯ","","","職制区分"
	,"","権限","検索","","No."
	,"担当者","","職制","権限","パスワード初期化"
	,"","","","確定"
);

