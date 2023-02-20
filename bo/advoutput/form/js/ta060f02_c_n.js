var ADVIT_FORMID = "TA060F02";
var ADVIT_TARGETPGID = "ta060p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "ta060f02.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,8,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,24,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_BTNBACK = 0;
var ADVIT_ID_HEAD_TENPO_CD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_HENKO_KBN_NM = 3;
var ADVIT_ID_BUMON_CD = 4;
var ADVIT_ID_BUMON_NM = 5;
var ADVIT_ID_KESSAI_YMD = 6;
var ADVIT_ID_PGR = 7;
var ADVIT_ID_M1ROWNO = 8;
var ADVIT_ID_M1HINSYU_RYAKU_NM = 9;
var ADVIT_ID_M1BURANDO_NM = 10;
var ADVIT_ID_M1JISYA_HBN = 11;
var ADVIT_ID_M1SYOHIN_ZOKUSEI = 12;
var ADVIT_ID_M1MAKER_HBN = 13;
var ADVIT_ID_M1SYONMK = 14;
var ADVIT_ID_M1IRO_NM = 15;
var ADVIT_ID_M1SIZE_NM = 16;
var ADVIT_ID_M1SCAN_CD = 17;
var ADVIT_ID_M1IRAI_SU = 18;
var ADVIT_ID_M1GENKAKIN = 19;
var ADVIT_ID_M1COMMENT_NM = 20;
var ADVIT_ID_M1COMMENT_NM2 = 21;
var ADVIT_ID_M1SELECTORCHECKBOX = 22;
var ADVIT_ID_M1ENTERSYORIFLG = 23;
var ADVIT_ID_M1DTLIROKBN = 24;
var ADVIT_ID_GOKEI_IRAI_SU = 25;
var ADVIT_ID_GOKEI_GENKAKIN = 26;

var ADVIT_ID = new Array(
	"Btnback","Head_tenpo_cd","Head_tenpo_nm","Henko_kbn_nm","Bumon_cd"
	,"Bumon_nm","Kessai_ymd","Pgr","M1rowno","M1hinsyu_ryaku_nm"
	,"M1burando_nm","M1jisya_hbn","M1syohin_zokusei","M1maker_hbn","M1syonmk"
	,"M1iro_nm","M1size_nm","M1scan_cd","M1irai_su","M1genkakin"
	,"M1comment_nm","M1comment_nm2","M1selectorcheckbox","M1entersyoriflg","M1dtlirokbn"
	,"Gokei_irai_su","Gokei_genkakin"
);
var ADVIT_NAME = new Array(
	"戻るボタン","ヘッダ店舗コード","ヘッダ店舗名","変更区分名称","部門コード"
	,"部門名","決裁日","ページャ","Ｍ１行NO","Ｍ１品種略名称"
	,"Ｍ１ブランド名","Ｍ１自社品番","Ｍ１商品属性","Ｍ１メーカー品番","Ｍ１商品名(カナ)"
	,"Ｍ１色","Ｍ１サイズ","Ｍ１スキャンコード","Ｍ１依頼数量","Ｍ１原価金額"
	,"Ｍ１コメント","Ｍ１コメント２","Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)"
	,"合計依頼数量","合計原価金額"
);
var ADVIT_ATTRIBUTE = new Array(
	"B","SG","SN4","SN4","SG"
	,"SN4","D","B","NA","SN4"
	,"SN9","SG","SN9","SN9","SN9"
	,"SN9","SN9","SG","NC","NC"
	,"SN4","SN4","NA","NA","NA"
	,"NC","NC"
);
var ADVIT_LENGTH = new Array(
	0,4,15,6,3
	,15,0,0,4,15
	,20,8,3,30,30
	,10,4,18,7,7
	,20,20,1,1,2
	,9,9
);
var ADVIT_AUTOTAB = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0
);
var ADVIT_DECIMAL = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0
);
var ADVIT_REQUIRED = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0
);
var ADVIT_REQUIREDFLG = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0
);
var ADVIT_TYPE = new Array(
	"BTS","TXR","TXR","TXR","TXR"
	,"TXR","TXR","LNS","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","CHK","HDN","HDN"
	,"TXR","TXR"
);
var ADVIT_FORMAT = new Array(
	"00","10","00","00","10"
	,"00","52","00","11","00"
	,"00","10","00","00","00"
	,"00","00","00","12","12"
	,"00","00","11","11","11"
	,"12","12"
);
var ADVIT_CODEID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"",""
);
var ADVIT_CODENAME = new Array(
	"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET"
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"",""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,1,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0
);
var ADVIT_IMEMODE = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0
);
var ADVIT_AUTOCODECHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0
);
var ADVIT_CONDID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"",""
);
var ADVIT_ACTIONID = new Array(
	"FRM","","","",""
	,"","","PGN","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"",""
);
var ADVIT_ACTIONFORMID = new Array(
	"TA060F01","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"",""
);
var ADVIT_ACTPARAMETER = new Array(
	"M1","","","",""
	,"","","M1","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"",""
);
var ADVIT_ACTPROGRAMID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"",""
);
var ADVIT_CAPTION = new Array(
	"","","","変更区分","部門"
	,"","決裁日","","No.","品種"
	,"ブランド","自社品番","コア","メーカー品番","商品名"
	,"色","サイズ","スキャンコード","依頼数量","原価金額"
	,"コメント","","","",""
	,"",""
);

