var ADVIT_FORMID = "TA030F02";
var ADVIT_TARGETPGID = "ta030p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "ta030f02.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,5,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,25,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_BTNBACK = 0;
var ADVIT_ID_HEAD_TENPO_CD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_STKMODENO = 3;
var ADVIT_ID_PGR = 4;
var ADVIT_ID_M1ROWNO = 5;
var ADVIT_ID_M1HOJUIRAI_KBN_NM = 6;
var ADVIT_ID_M1SINSEI_JOTAINM = 7;
var ADVIT_ID_M1BUMON_CD_BO = 8;
var ADVIT_ID_M1BUMONKANA_NM = 9;
var ADVIT_ID_M1HINSYU_RYAKU_NM = 10;
var ADVIT_ID_M1BURANDO_NM = 11;
var ADVIT_ID_M1JISYA_HBN = 12;
var ADVIT_ID_M1SYOHIN_ZOKUSEI = 13;
var ADVIT_ID_M1MAKER_HBN = 14;
var ADVIT_ID_M1SYONMK = 15;
var ADVIT_ID_M1IRO_NM = 16;
var ADVIT_ID_M1SIZE_NM = 17;
var ADVIT_ID_M1SCAN_CD = 18;
var ADVIT_ID_M1ITEMSU = 19;
var ADVIT_ID_M1KINGAKU = 20;
var ADVIT_ID_M1HATTYU_YMD = 21;
var ADVIT_ID_M1HANBAIIN_NM = 22;
var ADVIT_ID_M1SELECTORCHECKBOX = 23;
var ADVIT_ID_M1ENTERSYORIFLG = 24;
var ADVIT_ID_M1DTLIROKBN = 25;
var ADVIT_ID_GOKEI_ITEMSU = 26;
var ADVIT_ID_GOKEI_KINGAKU = 27;

var ADVIT_ID = new Array(
	"Btnback","Head_tenpo_cd","Head_tenpo_nm","Stkmodeno","Pgr"
	,"M1rowno","M1hojuirai_kbn_nm","M1sinsei_jotainm","M1bumon_cd_bo","M1bumonkana_nm"
	,"M1hinsyu_ryaku_nm","M1burando_nm","M1jisya_hbn","M1syohin_zokusei","M1maker_hbn"
	,"M1syonmk","M1iro_nm","M1size_nm","M1scan_cd","M1itemsu"
	,"M1kingaku","M1hattyu_ymd","M1hanbaiin_nm","M1selectorcheckbox","M1entersyoriflg"
	,"M1dtlirokbn","Gokei_itemsu","Gokei_kingaku"
);
var ADVIT_NAME = new Array(
	"戻るボタン","ヘッダ店舗コード","ヘッダ店舗名","選択モードNO","ページャ"
	,"Ｍ１行NO","Ｍ１補充依頼区分名称","Ｍ１申請状態名称","Ｍ１部門コード","Ｍ１部門カナ名"
	,"Ｍ１品種略名称","Ｍ１ブランド名","Ｍ１自社品番","Ｍ１商品属性","Ｍ１メーカー品番"
	,"Ｍ１商品名(カナ)","Ｍ１色","Ｍ１サイズ","Ｍ１スキャンコード","Ｍ１数量"
	,"Ｍ１金額","Ｍ１発注日","Ｍ１担当者名","Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)"
	,"Ｍ１明細色区分(隠し)","合計数量","合計金額"
);
var ADVIT_ATTRIBUTE = new Array(
	"B","SG","SN4","NA","B"
	,"NA","SN4","SN4","SG","SN9"
	,"SN4","SN9","SG","SN9","SN9"
	,"SN9","SN9","SN9","SG","NC"
	,"NC","D","SN4","NA","NA"
	,"NA","NC","NC"
);
var ADVIT_LENGTH = new Array(
	0,4,15,2,0
	,4,7,3,3,30
	,15,20,8,3,30
	,30,10,4,18,7
	,7,0,12,1,1
	,2,9,9
);
var ADVIT_AUTOTAB = new Array(
	0,0,0,0,0
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
	,0,0,0
);
var ADVIT_REQUIRED = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0
);
var ADVIT_REQUIREDFLG = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0
);
var ADVIT_TYPE = new Array(
	"BTS","TXR","TXR","HDN","LNS"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","CHK","HDN"
	,"HDN","TXR","TXR"
);
var ADVIT_FORMAT = new Array(
	"00","10","00","11","00"
	,"11","00","00","10","00"
	,"00","00","10","00","00"
	,"00","00","00","00","12"
	,"12","52","00","11","11"
	,"11","12","12"
);
var ADVIT_CODEID = new Array(
	"","","","",""
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
	,"CANNOTGET","CANNOTGET","CANNOTGET"
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","",""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,1
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0
);
var ADVIT_IMEMODE = new Array(
	0,0,0,0,0
	,0,0,0,0,0
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
	,0,0,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	0,0,0,0,0
	,0,0,0,0,0
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
	,"","",""
);
var ADVIT_ACTIONID = new Array(
	"FRM","","","","PGN"
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","",""
);
var ADVIT_ACTIONFORMID = new Array(
	"TA030F01","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","",""
);
var ADVIT_ACTPARAMETER = new Array(
	"M1","","","","M1"
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
	,"","",""
);
var ADVIT_CAPTION = new Array(
	"","","","",""
	,"No.","区分","状態","部門",""
	,"品種","ブランド","自社品番","コア","メーカー品番"
	,"商品名","色","サイズ","スキャンコード","数量"
	,"金額","発注日","担当者","選択フラグ(隠し)","確定処理フラグ(隠し)"
	,"明細色区分(隠し)","合計",""
);

