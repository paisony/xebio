var ADVIT_FORMID = "TH010F03";
var ADVIT_TARGETPGID = "th010p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "th010f03.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,29,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,36,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_BTNBACK = 0;
var ADVIT_ID_HEAD_TENPO_CD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_STKMODENO = 3;
var ADVIT_ID_SIIRESAKI_CD = 4;
var ADVIT_ID_SIIRESAKI_RYAKU_NM = 5;
var ADVIT_ID_BUMON_CD = 6;
var ADVIT_ID_BUMON_NM = 7;
var ADVIT_ID_HINSYU_CD = 8;
var ADVIT_ID_HINSYU_RYAKU_NM = 9;
var ADVIT_ID_BURANDO_CD = 10;
var ADVIT_ID_BURANDO_NM = 11;
var ADVIT_ID_JISYA_HBN = 12;
var ADVIT_ID_OLD_JISYA_HBN = 13;
var ADVIT_ID_MAKER_HBN = 14;
var ADVIT_ID_SYONMK = 15;
var ADVIT_ID_SYOHIN_ZOKUSEI = 16;
var ADVIT_ID_HANBAIKANRYO_YMD = 17;
var ADVIT_ID_SAISINBAIKA_TNK = 18;
var ADVIT_ID_GENKA = 19;
var ADVIT_ID_GENBAIKA_TNK = 20;
var ADVIT_ID_MAKERKAKAKU_TNK = 21;
var ADVIT_ID_SYUTSURYOKU_SEAL = 22;
var ADVIT_ID_LAYOUT = 23;
var ADVIT_ID_BTNSEAL = 24;
var ADVIT_ID_BTNLABEL_CD = 25;
var ADVIT_ID_LABEL_CD = 26;
var ADVIT_ID_LABEL_IP = 27;
var ADVIT_ID_LABEL_NM = 28;
var ADVIT_ID_M1ROWNO = 29;
var ADVIT_ID_M1IRO_NM = 30;
var ADVIT_ID_M1SIZE_NM = 31;
var ADVIT_ID_M1SCAN_CD = 32;
var ADVIT_ID_M1MAISU = 33;
var ADVIT_ID_M1SELECTORCHECKBOX = 34;
var ADVIT_ID_M1ENTERSYORIFLG = 35;
var ADVIT_ID_M1DTLIROKBN = 36;

var ADVIT_ID = new Array(
	"Btnback","Head_tenpo_cd","Head_tenpo_nm","Stkmodeno","Siiresaki_cd"
	,"Siiresaki_ryaku_nm","Bumon_cd","Bumon_nm","Hinsyu_cd","Hinsyu_ryaku_nm"
	,"Burando_cd","Burando_nm","Jisya_hbn","Old_jisya_hbn","Maker_hbn"
	,"Syonmk","Syohin_zokusei","Hanbaikanryo_ymd","Saisinbaika_tnk","Genka"
	,"Genbaika_tnk","Makerkakaku_tnk","Syutsuryoku_seal","Layout","Btnseal"
	,"Btnlabel_cd","Label_cd","Label_ip","Label_nm","M1rowno"
	,"M1iro_nm","M1size_nm","M1scan_cd","M1maisu","M1selectorcheckbox"
	,"M1entersyoriflg","M1dtlirokbn"
);
var ADVIT_NAME = new Array(
	"戻るボタン","ヘッダ店舗コード","ヘッダ店舗名","選択モードNO","仕入先コード"
	,"仕入先略式名称","部門コード","部門名","品種コード","品種略名称"
	,"ブランドコード","ブランド名","自社品番","旧自社品番","メーカー品番"
	,"商品名(カナ)","商品属性","販売完了日","最新売価","原価"
	,"現売価","メーカー価格","出力シール","レイアウト","シール発行ボタン"
	,"ラベル発行機コードボタン","ラベル発行機ＩＤ","ラベル発行機ＩＰ","ラベル発行機名","Ｍ１行NO"
	,"Ｍ１色","Ｍ１サイズ","Ｍ１スキャンコード","Ｍ１枚数","Ｍ１選択フラグ(隠し)"
	,"Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)"
);
var ADVIT_ATTRIBUTE = new Array(
	"B","SG","SN4","NA","SG"
	,"SN4","SG","SN4","SG","SN4"
	,"SG","SN9","SG","SG","SN9"
	,"SN9","SN9","D","NA","NC"
	,"NA","NA","SN5","SN5","B"
	,"B","SN4","SG","SN4","NA"
	,"SN9","SN9","SG","NA","NA"
	,"NA","NA"
);
var ADVIT_LENGTH = new Array(
	0,4,15,2,4
	,20,3,15,2,15
	,6,20,8,10,30
	,30,3,0,7,8
	,8,8,1,1,0
	,0,7,12,10,4
	,10,4,18,3,1
	,1,2
);
var ADVIT_AUTOTAB = new Array(
	0,0,0,0,0
	,0,0,0,0,0
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
	,0,0,0,0,0
	,0,0
);
var ADVIT_TYPE = new Array(
	"BTS","TXR","TXR","HDN","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","RDO","RDO","BTS"
	,"BTN","HDN","HDN","TXR","TXR"
	,"TXR","TXR","TXR","TXT","CHK"
	,"HDN","HDN"
);
var ADVIT_FORMAT = new Array(
	"00","10","00","11","10"
	,"00","10","00","10","00"
	,"10","00","10","10","00"
	,"00","00","52","12","12"
	,"12","12","00","00","00"
	,"00","00","00","00","11"
	,"00","00","00","12","11"
	,"11","11"
);
var ADVIT_CODEID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"C_LABEL_CD","","","",""
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
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET"
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1"
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,1
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
	,0,0,0,3,0
	,0,0
);
var ADVIT_AUTOCODECHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
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
	,0,0,0,1,0
	,0,0
);
var ADVIT_CONDID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","LAYOUT",""
	,"","","","",""
	,"","","","",""
	,"",""
);
var ADVIT_ACTIONID = new Array(
	"FRM","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","","FRM"
	,"COD","","","",""
	,"","","","",""
	,"",""
);
var ADVIT_ACTIONFORMID = new Array(
	"TH010F01","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","","TH010F03"
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
	,"","","","",""
	,"",""
);
var ADVIT_CAPTION = new Array(
	"","","","","仕入先"
	,"","部門","","品種",""
	,"ブランド","","自社品番","",""
	,"商品名","コア属性","販売完了日","最新売価","原価"
	,"現売価","ﾒｰｶｰ価格","出力シール","レイアウト",""
	,"","","","","No."
	,"色","サイズ","スキャンコード","枚数",""
	,"",""
);

