var ADVIT_FORMID = "TB040F01";
var ADVIT_TARGETPGID = "tb040p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tb040f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,4,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,18,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_BTNROWDEL = 3;
var ADVIT_ID_M1ROWNO = 4;
var ADVIT_ID_M1SIIRESAKI_CD = 5;
var ADVIT_ID_M1BTNSIIRESAKI_CD = 6;
var ADVIT_ID_M1SIIRESAKI_RYAKU_NM = 7;
var ADVIT_ID_M1DENPYO_BARCODE = 8;
var ADVIT_ID_M1BUMON_CD = 9;
var ADVIT_ID_M1BUMONKANA_NM = 10;
var ADVIT_ID_M1NYUKAYOTEI_YMD = 11;
var ADVIT_ID_M1NOHIN_SU = 12;
var ADVIT_ID_M1GENKA_KIN = 13;
var ADVIT_ID_M1KYAKUCYU = 14;
var ADVIT_ID_M1NEGAKI = 15;
var ADVIT_ID_M1SELECTORCHECKBOX = 16;
var ADVIT_ID_M1ENTERSYORIFLG = 17;
var ADVIT_ID_M1DTLIROKBN = 18;
var ADVIT_ID_BTNENTER = 19;
var ADVIT_ID_BTNCLEAR = 20;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Btnrowdel","M1rowno"
	,"M1siiresaki_cd","M1btnsiiresaki_cd","M1siiresaki_ryaku_nm","M1denpyo_barcode","M1bumon_cd"
	,"M1bumonkana_nm","M1nyukayotei_ymd","M1nohin_su","M1genka_kin","M1kyakucyu"
	,"M1negaki","M1selectorcheckbox","M1entersyoriflg","M1dtlirokbn","Btnenter"
	,"Btnclear"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","行削除ボタン","M１NO"
	,"M１仕入先コード","Ｍ１仕入先コードボタン","M１仕入先名称","Ｍ１伝票バーコード","M１部門コード"
	,"M１部門カナ名","M１入荷予定日","Ｍ１納品数","Ｍ１原価金額","Ｍ１客注"
	,"Ｍ１値書","Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)","確定ボタン"
	,"ボタンクリア"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","B","NA"
	,"SG","B","SN4","SG","SG"
	,"SN4","D","NA","NA","SN4"
	,"SN4","NA","NA","NA","B"
	,"B"
);
var ADVIT_LENGTH = new Array(
	4,0,15,0,4
	,4,0,20,10,3
	,30,0,9,9,1
	,1,1,1,2,0
	,0
);
var ADVIT_AUTOTAB = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0
);
var ADVIT_DECIMAL = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0
);
var ADVIT_REQUIRED = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0
);
var ADVIT_REQUIREDFLG = new Array(
	1,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","BTS","TXR"
	,"TXT","BTN","TXR","TXT","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","CHK","HDN","HDN","BTS"
	,"BTS"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","00","11"
	,"10","00","00","00","10"
	,"00","52","12","12","00"
	,"00","11","11","11","00"
	,"00"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"","C_SIIRESAKI_CD","","",""
	,"","","","",""
	,"","","","",""
	,""
);
var ADVIT_CODENAME = new Array(
	"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET"
);
var ADVIT_LEVEL = new Array(
	"","","","","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1",""
	,""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,1
	,0
);
var ADVIT_IMEMODE = new Array(
	3,0,0,0,0
	,3,0,0,3,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0
);
var ADVIT_AUTOCODECHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,0,0
	,1,0,0,1,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0
);
var ADVIT_CONDID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,""
);
var ADVIT_ACTIONID = new Array(
	"","COD","","FRM",""
	,"","COD","","",""
	,"","","","",""
	,"","","","","FRM"
	,"FRM"
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","TB040F01",""
	,"","","","",""
	,"","","","",""
	,"","","","","TB040F01"
	,"TB040F01"
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,""
);
var ADVIT_ACTPROGRAMID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,""
);
var ADVIT_CAPTION = new Array(
	"店舗","","","","No."
	,"仕入先","","","伝票番号","部門"
	,"","入荷予定日","納品数","原価金額","客注"
	,"値書","","","","確定"
	,"ボタンクリア（ダミー）"
);

