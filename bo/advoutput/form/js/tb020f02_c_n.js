var ADVIT_FORMID = "TB020F02";
var ADVIT_TARGETPGID = "tb020p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tb020f02.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,10,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,28,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_BTNBACK = 0;
var ADVIT_ID_HEAD_TENPO_CD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_SCM_CD = 3;
var ADVIT_ID_SIIRESAKI_CD = 4;
var ADVIT_ID_SIIRESAKI_RYAKU_NM = 5;
var ADVIT_ID_NYUKAYOTEI_YMD = 6;
var ADVIT_ID_SIIRE_KAKUTEI_YMD = 7;
var ADVIT_ID_SCM_JOTAINM = 8;
var ADVIT_ID_PGR = 9;
var ADVIT_ID_M1ROWNO = 10;
var ADVIT_ID_M1DENPYO_BANGO = 11;
var ADVIT_ID_M1DENPYOGYO_NO = 12;
var ADVIT_ID_M1BUMON_CD = 13;
var ADVIT_ID_M1BUMONKANA_NM = 14;
var ADVIT_ID_M1HINSYU_RYAKU_NM = 15;
var ADVIT_ID_M1BURANDO_NM = 16;
var ADVIT_ID_M1JISYA_HBN = 17;
var ADVIT_ID_M1MAKER_HBN = 18;
var ADVIT_ID_M1SYONMK = 19;
var ADVIT_ID_M1IRO_NM = 20;
var ADVIT_ID_M1SIZE_NM = 21;
var ADVIT_ID_M1SCAN_CD = 22;
var ADVIT_ID_M1ITEMSU = 23;
var ADVIT_ID_M1GEN_TNK = 24;
var ADVIT_ID_M1GENKA_KIN = 25;
var ADVIT_ID_M1SELECTORCHECKBOX = 26;
var ADVIT_ID_M1ENTERSYORIFLG = 27;
var ADVIT_ID_M1DTLIROKBN = 28;
var ADVIT_ID_GOKEI_SURYO = 29;
var ADVIT_ID_GENKA_KIN_GOKEI = 30;

var ADVIT_ID = new Array(
	"Btnback","Head_tenpo_cd","Head_tenpo_nm","Scm_cd","Siiresaki_cd"
	,"Siiresaki_ryaku_nm","Nyukayotei_ymd","Siire_kakutei_ymd","Scm_jotainm","Pgr"
	,"M1rowno","M1denpyo_bango","M1denpyogyo_no","M1bumon_cd","M1bumonkana_nm"
	,"M1hinsyu_ryaku_nm","M1burando_nm","M1jisya_hbn","M1maker_hbn","M1syonmk"
	,"M1iro_nm","M1size_nm","M1scan_cd","M1itemsu","M1gen_tnk"
	,"M1genka_kin","M1selectorcheckbox","M1entersyoriflg","M1dtlirokbn","Gokei_suryo"
	,"Genka_kin_gokei"
);
var ADVIT_NAME = new Array(
	"戻るボタン","ヘッダ店舗コード","ヘッダ店舗名","SCMコード","仕入先コード"
	,"仕入先略式名称","入荷予定日","仕入確定日","SCM状態名称","ページャ"
	,"Ｍ１行NO","Ｍ１伝票番号","Ｍ１伝票行№","Ｍ１部門コード","Ｍ１部門カナ名"
	,"Ｍ１品種略名称","Ｍ１ブランド名","Ｍ１自社品番","Ｍ１メーカー品番","Ｍ１商品名(カナ)"
	,"Ｍ１色","Ｍ１サイズ","Ｍ１スキャンコード","Ｍ１数量","Ｍ１原単価"
	,"Ｍ１原価金額","Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)","合計数量"
	,"原価金額合計"
);
var ADVIT_ATTRIBUTE = new Array(
	"B","SG","SN4","SG","SG"
	,"SN4","D","D","SN4","B"
	,"NA","NA","NA","SG","SN9"
	,"SN4","SN9","SG","SN9","SN9"
	,"SN9","SN9","SG","NA","NA"
	,"NA","NA","NA","NA","NA"
	,"NA"
);
var ADVIT_LENGTH = new Array(
	0,4,15,20,4
	,20,0,0,3,0
	,4,6,2,3,30
	,15,20,8,30,30
	,10,4,18,7,7
	,7,1,1,2,9
	,9
);
var ADVIT_AUTOTAB = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
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
	,0,0,0,0,0
	,0,0,0,0,0
	,0
);
var ADVIT_REQUIRED = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0
);
var ADVIT_REQUIREDFLG = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0
);
var ADVIT_TYPE = new Array(
	"BTS","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","LNS"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","CHK","HDN","HDN","TXR"
	,"TXR"
);
var ADVIT_FORMAT = new Array(
	"00","10","00","00","10"
	,"00","52","52","00","00"
	,"11","10","11","10","00"
	,"00","00","10","00","00"
	,"00","00","00","12","12"
	,"12","11","11","11","12"
	,"12"
);
var ADVIT_CODEID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,""
);
var ADVIT_CODENAME = new Array(
	"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET"
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1",""
	,""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,1
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0
);
var ADVIT_IMEMODE = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0
);
var ADVIT_AUTOCODECHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0
);
var ADVIT_CONDID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,""
);
var ADVIT_ACTIONID = new Array(
	"FRM","","","",""
	,"","","","","PGN"
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,""
);
var ADVIT_ACTIONFORMID = new Array(
	"TB020F01","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,""
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","","M1"
	,"","","","",""
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
	,"","","","",""
	,"","","","",""
	,""
);
var ADVIT_CAPTION = new Array(
	"","","","SCMコード","仕入先"
	,"","入荷予定日","仕入確定日","SCM状態",""
	,"No.","伝票","行","部門","部門"
	,"品種","ブランド","自社品番","メーカー品番","商品名"
	,"色","サイズ","スキャンコード","数量","原単価"
	,"原価金額","","","",""
	,""
);

