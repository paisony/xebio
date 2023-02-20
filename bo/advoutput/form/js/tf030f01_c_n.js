var ADVIT_FORMID = "TF030F01";
var ADVIT_TARGETPGID = "tf030p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tf030f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,27,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,41,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_BTNMODEREF = 3;
var ADVIT_ID_BTNMODEUPD = 4;
var ADVIT_ID_BTNMODEDEL = 5;
var ADVIT_ID_MODENO = 6;
var ADVIT_ID_STKMODENO = 7;
var ADVIT_ID_ADD_YMD_FROM = 8;
var ADVIT_ID_ADD_YMD_TO = 9;
var ADVIT_ID_TENPO_CD_FROM = 10;
var ADVIT_ID_BTNTENPOCD_FROM = 11;
var ADVIT_ID_TENPO_NM_FROM = 12;
var ADVIT_ID_TENPO_CD_TO = 13;
var ADVIT_ID_BTNTENPOCD_TO = 14;
var ADVIT_ID_TENPO_NM_TO = 15;
var ADVIT_ID_SIIRESAKI_CD = 16;
var ADVIT_ID_BTNSIIRESAKI_CD = 17;
var ADVIT_ID_SIIRESAKI_RYAKU_NM = 18;
var ADVIT_ID_DENPYO_BANGO_FROM = 19;
var ADVIT_ID_DENPYO_BANGO_TO = 20;
var ADVIT_ID_MOTODENPYO_BANGO_FROM = 21;
var ADVIT_ID_MOTODENPYO_BANGO_TO = 22;
var ADVIT_ID_BTNINSERT = 23;
var ADVIT_ID_SEARCHCNT = 24;
var ADVIT_ID_BTNSEARCH = 25;
var ADVIT_ID_BTNPRINT = 26;
var ADVIT_ID_M1ROWNO = 27;
var ADVIT_ID_M1ADD_YMD = 28;
var ADVIT_ID_M1TENPO_CD = 29;
var ADVIT_ID_M1TENPO_NM = 30;
var ADVIT_ID_M1SIIRESAKI_CD = 31;
var ADVIT_ID_M1SIIRESAKI_RYAKU_NM = 32;
var ADVIT_ID_M1DENPYO_BANGO = 33;
var ADVIT_ID_M1MOTODENPYO_BANGO = 34;
var ADVIT_ID_M1NOHIN_YMD = 35;
var ADVIT_ID_M1NYURYOKUTAN_NM = 36;
var ADVIT_ID_M1ITEMSU = 37;
var ADVIT_ID_M1KINGAKU = 38;
var ADVIT_ID_M1SELECTORCHECKBOX = 39;
var ADVIT_ID_M1ENTERSYORIFLG = 40;
var ADVIT_ID_M1DTLIROKBN = 41;
var ADVIT_ID_BTNENTER = 42;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Btnmoderef","Btnmodeupd"
	,"Btnmodedel","Modeno","Stkmodeno","Add_ymd_from","Add_ymd_to"
	,"Tenpo_cd_from","Btntenpocd_from","Tenpo_nm_from","Tenpo_cd_to","Btntenpocd_to"
	,"Tenpo_nm_to","Siiresaki_cd","Btnsiiresaki_cd","Siiresaki_ryaku_nm","Denpyo_bango_from"
	,"Denpyo_bango_to","Motodenpyo_bango_from","Motodenpyo_bango_to","Btninsert","Searchcnt"
	,"Btnsearch","Btnprint","M1rowno","M1add_ymd","M1tenpo_cd"
	,"M1tenpo_nm","M1siiresaki_cd","M1siiresaki_ryaku_nm","M1denpyo_bango","M1motodenpyo_bango"
	,"M1nohin_ymd","M1nyuryokutan_nm","M1itemsu","M1kingaku","M1selectorcheckbox"
	,"M1entersyoriflg","M1dtlirokbn","Btnenter"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","モード照会ボタン","モード修正ボタン"
	,"モード取消ボタン","モードNO","選択モードNO","登録日ＦＲＯＭ","登録日ＴＯ"
	,"店舗コードＦＲＯＭ","店舗コードＦＲＯＭボタン","店舗名ＦＲＯＭ","店舗コードＴＯ","店舗コードＴＯボタン"
	,"店舗名ＴＯ","仕入先コード","仕入先コードボタン","仕入先略式名称","伝票番号ＦＲＯＭ"
	,"伝票番号ＴＯ","元伝票番号ＦＲＯＭ","元伝票番号ＴＯ","新規作成ボタン","検索件数"
	,"検索ボタン","印刷ボタン","Ｍ１行NO","Ｍ１登録日","Ｍ１店舗コード"
	,"Ｍ１店舗名","Ｍ１仕入先コード","Ｍ１仕入先略式名称","Ｍ１伝票番号リンク","Ｍ１元伝票番号"
	,"Ｍ１納品日","Ｍ１入力担当者名称","Ｍ１数量","Ｍ１金額","Ｍ１選択フラグ(隠し)"
	,"Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)","確定ボタン"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","B","B"
	,"B","NA","NA","D","D"
	,"SG","B","SN4","SG","B"
	,"SN4","SG","B","SN4","NA"
	,"NA","NA","NA","B","NA"
	,"B","B","NA","D","SG"
	,"SN4","SG","SN4","B","NA"
	,"D","SN4","NA","NA","NA"
	,"NA","NA","B"
);
var ADVIT_LENGTH = new Array(
	4,0,15,0,0
	,0,2,2,0,0
	,4,0,15,4,0
	,15,4,0,20,6
	,6,6,6,0,4
	,0,0,3,0,4
	,15,4,20,0,6
	,0,12,5,12,1
	,1,2,0
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
	,0,0,0
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
	,0,0,0
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
	,0,0,0
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
	,0,0,0
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","LNK","LNK"
	,"LNK","HDN","HDN","TXT","TXT"
	,"TXT","BTN","TXR","TXT","BTN"
	,"TXR","TXT","BTN","TXR","TXT"
	,"TXT","TXT","TXT","BTS","TXR"
	,"BTS","BTS","TXR","TXR","TXR"
	,"TXR","TXR","TXR","BTS","TXR"
	,"TXR","TXR","TXR","TXR","CHK"
	,"HDN","HDN","BTS"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","00","00"
	,"00","11","11","52","52"
	,"10","00","00","10","00"
	,"00","10","00","00","10"
	,"10","10","10","00","12"
	,"00","00","11","52","10"
	,"00","10","00","00","10"
	,"52","00","12","12","11"
	,"11","11","00"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"","","","",""
	,"","C_TENPO_CD","","","C_TENPO_CD"
	,"","","C_SIIRESAKI_CD","",""
	,"","","","",""
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
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET"
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1",""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,1,0
	,1,1,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,1
);
var ADVIT_IMEMODE = new Array(
	3,0,0,0,0
	,0,0,0,3,3
	,3,0,0,3,0
	,0,3,0,0,3
	,3,3,3,0,0
	,0,0,0,0,0
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
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,0,0
	,0,0,0,1,1
	,1,0,0,1,0
	,0,1,0,0,1
	,1,1,1,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0
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
	,"","",""
);
var ADVIT_ACTIONID = new Array(
	"","COD","","SPT","SPT"
	,"SPT","","","",""
	,"","COD","","","COD"
	,"","","COD","",""
	,"","","","FRM",""
	,"FRM","FRM","","",""
	,"","","","FRM",""
	,"","","","",""
	,"","","FRM"
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","TF030F01","TF030F01"
	,"TF030F01","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","TF030F02",""
	,"TF030F01","TF030F01","","",""
	,"","","","TF030F02",""
	,"","","","",""
	,"","","TF030F01"
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
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
	,"","","","",""
	,"","","","",""
	,"","",""
);
var ADVIT_CAPTION = new Array(
	"店舗","","","照会","修正"
	,"取消","","","登録日ＦＲＯＭ","登録日ＴＯ"
	,"店舗ＦＲＯＭ","","","店舗ＴＯ",""
	,"","取引先","","","伝票番号ＦＲＯＭ"
	,"伝票番号ＴＯ","元伝票番号ＦＲＯＭ","元伝票番号ＴＯ","新規作成",""
	,"検索","","No.","登録日","店舗"
	,"","取引先","","伝票番号","元伝票番号"
	,"納品日","入力担当者","数量","金額",""
	,"","","確定"
);

