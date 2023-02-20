var ADVIT_FORMID = "TM070F01";
var ADVIT_TARGETPGID = "tm070p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tm070f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,24,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,38,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_HENKO_YMD_FROM = 3;
var ADVIT_ID_HENKO_YMD_TO = 4;
var ADVIT_ID_MOTO_TENPO_CD_FROM = 5;
var ADVIT_ID_BTNMOTOTENPOCD_FROM = 6;
var ADVIT_ID_MOTO_TENPO_NM_FROM = 7;
var ADVIT_ID_MOTO_TENPO_CD_TO = 8;
var ADVIT_ID_BTNMOTOTENPOCD_TO = 9;
var ADVIT_ID_MOTO_TENPO_NM_TO = 10;
var ADVIT_ID_TAN_CD_FROM = 11;
var ADVIT_ID_BTNTANCD_FROM = 12;
var ADVIT_ID_TAN_NM_FROM = 13;
var ADVIT_ID_TAN_CD_TO = 14;
var ADVIT_ID_BTNTANCD_TO = 15;
var ADVIT_ID_TAN_NM_TO = 16;
var ADVIT_ID_STKMODENO = 17;
var ADVIT_ID_SEARCHCNT = 18;
var ADVIT_ID_BTNINSERT = 19;
var ADVIT_ID_BTNSEARCH = 20;
var ADVIT_ID_BTNPAGEINS = 21;
var ADVIT_ID_BTNROWDEL = 22;
var ADVIT_ID_PGR = 23;
var ADVIT_ID_M1ROWNO = 24;
var ADVIT_ID_M1TAN_CD = 25;
var ADVIT_ID_M1TAN_NM = 26;
var ADVIT_ID_M1MOTO_TENPO_CD = 27;
var ADVIT_ID_M1MOTO_TENPO_NM = 28;
var ADVIT_ID_M1HENKO_TENPO_CD = 29;
var ADVIT_ID_M1HENKO_TENPO_NM = 30;
var ADVIT_ID_M1HENKO_YMD = 31;
var ADVIT_ID_M1HENKO_TM = 32;
var ADVIT_ID_M1SHOZOKUTEN_SHOKIKA_CHECK = 33;
var ADVIT_ID_M1UPD_YMD = 34;
var ADVIT_ID_M1UPD_TM = 35;
var ADVIT_ID_M1SELECTORCHECKBOX = 36;
var ADVIT_ID_M1ENTERSYORIFLG = 37;
var ADVIT_ID_M1DTLIROKBN = 38;
var ADVIT_ID_BTNENTER = 39;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Henko_ymd_from","Henko_ymd_to"
	,"Moto_tenpo_cd_from","Btnmototenpocd_from","Moto_tenpo_nm_from","Moto_tenpo_cd_to","Btnmototenpocd_to"
	,"Moto_tenpo_nm_to","Tan_cd_from","Btntancd_from","Tan_nm_from","Tan_cd_to"
	,"Btntancd_to","Tan_nm_to","Stkmodeno","Searchcnt","Btninsert"
	,"Btnsearch","Btnpageins","Btnrowdel","Pgr","M1rowno"
	,"M1tan_cd","M1tan_nm","M1moto_tenpo_cd","M1moto_tenpo_nm","M1henko_tenpo_cd"
	,"M1henko_tenpo_nm","M1henko_ymd","M1henko_tm","M1shozokuten_shokika_check","M1upd_ymd"
	,"M1upd_tm","M1selectorcheckbox","M1entersyoriflg","M1dtlirokbn","Btnenter"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","変更日ＦＲＯＭ","変更日ＴＯ"
	,"元店舗コードＦＲＯＭ","元店舗コードＦＲＯＭボタン","元店舗名称ＦＲＯＭ","元店舗コードＴＯ","元店舗コードＴＯボタン"
	,"元店舗名称ＴＯ","担当者コードＦＲＯＭ","担当者コードＦＲＯＭボタン","担当者名称ＦＲＯＭ","担当者コードＴＯ"
	,"担当者コードＴＯボタン","担当者名称ＴＯ","選択モードNO","検索件数","新規作成ボタン"
	,"検索ボタン","ページ追加ボタン","行削除ボタン","ページャ","Ｍ１行NO"
	,"Ｍ１担当者コード","Ｍ１担当者名称","Ｍ１元店舗コード","Ｍ１元店舗名称","Ｍ１変更店舗コード"
	,"Ｍ１変更店舗名称","Ｍ１変更日","Ｍ１変更時間","Ｍ１所属店初期化チェック","Ｍ１更新日(隠し)"
	,"Ｍ１更新時間(隠し)","Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)","確定ボタン"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","D","D"
	,"SG","B","SN4","SG","B"
	,"SN4","SG","B","SN4","SG"
	,"B","SN4","NA","NA","B"
	,"B","B","B","B","NA"
	,"SG","SN4","SG","SN4","SG"
	,"SN4","D","D","NA","SG"
	,"SG","NA","NA","NA","B"
);
var ADVIT_LENGTH = new Array(
	4,0,15,0,0
	,4,0,15,4,0
	,15,7,0,12,7
	,0,12,2,4,0
	,0,0,0,0,4
	,7,12,4,15,4
	,15,0,0,1,8
	,9,1,1,2,0
);
var ADVIT_AUTOTAB = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
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
	,0,0,0,0,0
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","TXT","TXT"
	,"TXT","BTN","TXR","TXT","BTN"
	,"TXR","TXT","BTN","TXR","TXT"
	,"BTN","TXR","HDN","TXT","BTS"
	,"BTS","BTS","BTS","LNS","TXR"
	,"TXT","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","CHK","HDN"
	,"HDN","CHK","HDN","HDN","BTS"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","52","52"
	,"10","00","00","10","00"
	,"00","10","00","00","10"
	,"00","00","11","11","00"
	,"00","00","00","00","11"
	,"10","00","10","00","10"
	,"00","52","56","11","00"
	,"00","11","11","11","00"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"","C_TENPO_CD","","","C_TENPO_CD"
	,"","","C_TANTO_CD","",""
	,"C_TANTO_CD","","","",""
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
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1",""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,1
	,1,1,0,1,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,1
);
var ADVIT_IMEMODE = new Array(
	3,0,0,3,3
	,3,0,0,3,0
	,0,3,0,0,3
	,0,0,0,0,0
	,0,0,0,0,0
	,3,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
);
var ADVIT_AUTOCODECHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,1,1
	,1,0,0,1,0
	,0,1,0,0,1
	,0,0,0,0,0
	,0,0,0,0,0
	,1,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
);
var ADVIT_CONDID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
);
var ADVIT_ACTIONID = new Array(
	"","COD","","",""
	,"","COD","","","COD"
	,"","","COD","",""
	,"COD","","","","FRM"
	,"FRM","MINSX","FRM","PGN",""
	,"","","","",""
	,"","","","",""
	,"","","","","FRM"
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","","TM070F01"
	,"TM070F01","","TM070F01","",""
	,"","","","",""
	,"","","","",""
	,"","","","","TM070F01"
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","M1","","M1",""
	,"","","","",""
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
	,"","","","",""
);
var ADVIT_CAPTION = new Array(
	"店舗","","","変更日ＦＲＯＭ","変更日ＴＯ"
	,"元店舗ＦＲＯＭ","","","元店舗ＴＯ",""
	,"","担当者ＦＲＯＭ","","","担当者ＴＯ"
	,"","","","","新規作成"
	,"検索","","","","No."
	,"担当者","","元店舗","","変更店舗"
	,"","変更日","","所属店初期化",""
	,"","","","","確定"
);

