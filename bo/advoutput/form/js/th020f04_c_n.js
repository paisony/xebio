var ADVIT_FORMID = "TH020F04";
var ADVIT_TARGETPGID = "th020p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "th020f04.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,18,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,31,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_BTNBACK = 0;
var ADVIT_ID_HEAD_TENPO_CD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_KAISYA_CD = 3;
var ADVIT_ID_KAISYA_NM = 4;
var ADVIT_ID_BUMON_CD = 5;
var ADVIT_ID_BUMON_NM = 6;
var ADVIT_ID_HINSYU_RYAKU_NM = 7;
var ADVIT_ID_HINSYU_CD = 8;
var ADVIT_ID_BURANDO_CD = 9;
var ADVIT_ID_BURANDO_NM = 10;
var ADVIT_ID_JISYA_HBN = 11;
var ADVIT_ID_MAKER_HBN = 12;
var ADVIT_ID_SYOHIN_ZOKUSEI = 13;
var ADVIT_ID_SYONMK = 14;
var ADVIT_ID_IRO_NM = 15;
var ADVIT_ID_SIZE_NM = 16;
var ADVIT_ID_SCAN_CD = 17;
var ADVIT_ID_M1ROWNO = 18;
var ADVIT_ID_M1TENPO_CD = 19;
var ADVIT_ID_M1TENPO_NM = 20;
var ADVIT_ID_M1URIAGE_SU = 21;
var ADVIT_ID_M1FREEZAIKO_SU = 22;
var ADVIT_ID_M1SYOKA_RTU = 23;
var ADVIT_ID_M1TYOBOZAIKO_SU = 24;
var ADVIT_ID_M1AZUKARIYOYAKU_SU = 25;
var ADVIT_ID_M1SEKISO_SU = 26;
var ADVIT_ID_M1TONAN_SU = 27;
var ADVIT_ID_M1HYOKASONSINSEI_SU = 28;
var ADVIT_ID_M1SELECTORCHECKBOX = 29;
var ADVIT_ID_M1ENTERSYORIFLG = 30;
var ADVIT_ID_M1DTLIROKBN = 31;

var ADVIT_ID = new Array(
	"Btnback","Head_tenpo_cd","Head_tenpo_nm","Kaisya_cd","Kaisya_nm"
	,"Bumon_cd","Bumon_nm","Hinsyu_ryaku_nm","Hinsyu_cd","Burando_cd"
	,"Burando_nm","Jisya_hbn","Maker_hbn","Syohin_zokusei","Syonmk"
	,"Iro_nm","Size_nm","Scan_cd","M1rowno","M1tenpo_cd"
	,"M1tenpo_nm","M1uriage_su","M1freezaiko_su","M1syoka_rtu","M1tyobozaiko_su"
	,"M1azukariyoyaku_su","M1sekiso_su","M1tonan_su","M1hyokasonsinsei_su","M1selectorcheckbox"
	,"M1entersyoriflg","M1dtlirokbn"
);
var ADVIT_NAME = new Array(
	"戻るボタン","ヘッダ店舗コード","ヘッダ店舗名","会社コード","会社名称"
	,"部門コード","部門名","品種略名称","品種コード","ブランドコード"
	,"ブランド名","自社品番","メーカー品番","商品属性","商品名(カナ)"
	,"色","サイズ","スキャンコード","Ｍ１行NO","Ｍ１店舗コード"
	,"Ｍ１店舗名","Ｍ１売上数","Ｍ１販売可能在庫数","Ｍ１消化率","Ｍ１帳簿在庫数"
	,"Ｍ１預り予約数","Ｍ１積送数","Ｍ１盗難品数","Ｍ１評価損申請数","Ｍ１選択フラグ(隠し)"
	,"Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)"
);
var ADVIT_ATTRIBUTE = new Array(
	"B","SG","SN4","SG","SN4"
	,"SG","SN4","SN4","SG","SG"
	,"SN9","SG","SN9","SN9","SN9"
	,"SN9","SN9","SG","NA","SG"
	,"SN4","NC","NC","NC","NC"
	,"NC","NC","NC","NC","NA"
	,"NA","NA"
);
var ADVIT_LENGTH = new Array(
	0,4,15,2,10
	,3,15,15,2,6
	,20,8,30,3,30
	,10,4,18,4,4
	,15,5,5,4,5
	,5,5,5,5,1
	,1,2
);
var ADVIT_AUTOTAB = new Array(
	0,0,0,0,0
	,0,0,0,0,0
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
	,0,0,0,1,0
	,0,0,0,0,0
	,0,0
);
var ADVIT_REQUIRED = new Array(
	0,0,0,0,0
	,0,0,0,0,0
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
	,0,0,0,0,0
	,0,0
);
var ADVIT_TYPE = new Array(
	"BTS","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","HDN","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","CHK"
	,"HDN","HDN"
);
var ADVIT_FORMAT = new Array(
	"00","10","00","10","00"
	,"10","00","00","10","10"
	,"00","10","00","00","00"
	,"00","00","00","11","10"
	,"00","12","12","19","12"
	,"12","12","12","12","11"
	,"11","11"
);
var ADVIT_CODEID = new Array(
	"","","","",""
	,"","","","",""
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
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET"
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1"
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
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
	,0,0,0,0,0
	,0,0
);
var ADVIT_AUTOCODECHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
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
	,0,0,0,0,0
	,0,0
);
var ADVIT_CONDID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"",""
);
var ADVIT_ACTIONID = new Array(
	"FRM","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"",""
);
var ADVIT_ACTIONFORMID = new Array(
	"TH020F02","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"",""
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
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
	,"","","","",""
	,"",""
);
var ADVIT_CAPTION = new Array(
	"","","","会社",""
	,"部門","","品種","","ブランド"
	,"","自社品番","","コア属性","商品名"
	,"色","サイズ","ｽｷｬﾝｺｰﾄﾞ","No.","店舗"
	,"","売上数","販売可能在庫","消化率","帳簿在庫数"
	,"預り予約数","積送中","盗難品","評価損申請",""
	,"",""
);

