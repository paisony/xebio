var ADVIT_FORMID = "TH010F02";
var ADVIT_TARGETPGID = "th010p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "th010f02.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,20,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,41,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_BTNBACK = 0;
var ADVIT_ID_HEAD_TENPO_CD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_SIIRESAKI_CD = 3;
var ADVIT_ID_SIIRESAKI_RYAKU_NM = 4;
var ADVIT_ID_BURANDO_CD = 5;
var ADVIT_ID_BURANDO_NM = 6;
var ADVIT_ID_MAKER_HBN = 7;
var ADVIT_ID_GENKA_FLG = 8;
var ADVIT_ID_GENKA = 9;
var ADVIT_ID_GENBAIKA_FLG = 10;
var ADVIT_ID_GENBAIKA_TNK = 11;
var ADVIT_ID_MAKERKAKAKU_FLG = 12;
var ADVIT_ID_MAKERKAKAKU_TNK = 13;
var ADVIT_ID_SEARCHCNT = 14;
var ADVIT_ID_BTNSEARCH = 15;
var ADVIT_ID_SYOHINMST_SERCHSTK = 16;
var ADVIT_ID_STKMODENO = 17;
var ADVIT_ID_BTNCSV = 18;
var ADVIT_ID_PGR = 19;
var ADVIT_ID_M1ROWNO = 20;
var ADVIT_ID_M1SIIRESAKI_CD = 21;
var ADVIT_ID_M1SIIRESAKI_RYAKU_NM = 22;
var ADVIT_ID_M1BUMON_CD = 23;
var ADVIT_ID_M1BUMONKANA_NM = 24;
var ADVIT_ID_M1HINSYU_CD = 25;
var ADVIT_ID_M1HINSYU_RYAKU_NM = 26;
var ADVIT_ID_M1BURANDO_NM = 27;
var ADVIT_ID_M1JISYA_HBN = 28;
var ADVIT_ID_M1OLD_JISYA_HBN = 29;
var ADVIT_ID_M1SYOHIN_ZOKUSEI = 30;
var ADVIT_ID_M1MAKER_HBN = 31;
var ADVIT_ID_M1SYONMK = 32;
var ADVIT_ID_M1IRO_NM = 33;
var ADVIT_ID_M1HANBAIKANRYO_YMD = 34;
var ADVIT_ID_M1SAISINBAIKA_TNK = 35;
var ADVIT_ID_M1GENKA = 36;
var ADVIT_ID_M1GENBAIKA_TNK = 37;
var ADVIT_ID_M1SELECTORCHECKBOX = 38;
var ADVIT_ID_M1ENTERSYORIFLG = 39;
var ADVIT_ID_M1DTLIROKBN = 40;
var ADVIT_ID_M1MAKERKAKAKU_TNK = 41;

var ADVIT_ID = new Array(
	"Btnback","Head_tenpo_cd","Head_tenpo_nm","Siiresaki_cd","Siiresaki_ryaku_nm"
	,"Burando_cd","Burando_nm","Maker_hbn","Genka_flg","Genka"
	,"Genbaika_flg","Genbaika_tnk","Makerkakaku_flg","Makerkakaku_tnk","Searchcnt"
	,"Btnsearch","Syohinmst_serchstk","Stkmodeno","Btncsv","Pgr"
	,"M1rowno","M1siiresaki_cd","M1siiresaki_ryaku_nm","M1bumon_cd","M1bumonkana_nm"
	,"M1hinsyu_cd","M1hinsyu_ryaku_nm","M1burando_nm","M1jisya_hbn","M1old_jisya_hbn"
	,"M1syohin_zokusei","M1maker_hbn","M1syonmk","M1iro_nm","M1hanbaikanryo_ymd"
	,"M1saisinbaika_tnk","M1genka","M1genbaika_tnk","M1selectorcheckbox","M1entersyoriflg"
	,"M1dtlirokbn","M1makerkakaku_tnk"
);
var ADVIT_NAME = new Array(
	"戻るボタン","ヘッダ店舗コード","ヘッダ店舗名","仕入先コード","仕入先略式名称"
	,"ブランドコード","ブランド名","メーカー品番","原価フラグ","原価"
	,"現売価フラグ","現売価","メーカー価格フラグ","メーカー価格","検索件数"
	,"検索ボタン","商品マスタ検索選択","選択モードNO","CSV出力ボタン","ページャ"
	,"Ｍ１行NO","Ｍ１仕入先コード","Ｍ１仕入先名称","Ｍ１部門コード","Ｍ１部門カナ名"
	,"Ｍ１品種コード","Ｍ１品種略名称","Ｍ１ブランド名","Ｍ１自社品番リンク","Ｍ１旧自社品番リンク"
	,"Ｍ１商品属性","Ｍ１メーカー品番","Ｍ１商品名(カナ)","Ｍ１色","Ｍ１販売完了日"
	,"Ｍ１最新売価","Ｍ１原価","Ｍ１現売価","Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)"
	,"Ｍ１明細色区分(隠し)","Ｍ１メーカー価格"
);
var ADVIT_ATTRIBUTE = new Array(
	"B","SG","SN4","SG","SN4"
	,"SG","SN9","SN21","NA","NC"
	,"NA","NA","NA","NA","NA"
	,"B","NA","NA","B","B"
	,"NA","SG","SN4","SG","SN9"
	,"SG","SN4","SN9","B","B"
	,"SN9","SN9","SN9","SN9","D"
	,"NA","NC","NA","NA","NA"
	,"NA","NA"
);
var ADVIT_LENGTH = new Array(
	0,4,15,4,20
	,6,20,30,1,8
	,1,8,1,8,4
	,0,1,2,0,0
	,4,4,20,3,15
	,2,15,20,0,0
	,3,30,30,10,0
	,7,8,8,1,1
	,2,8
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
	,0,0,0,0,0
	,0,0
);
var ADVIT_REQUIREDFLG = new Array(
	0,0,0,0,0
	,0,0,1,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0
);
var ADVIT_TYPE = new Array(
	"BTS","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXT","CHK","TXR"
	,"CHK","TXR","CHK","TXR","TXR"
	,"BTS","RDO","HDN","BTS","LNS"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","BTS","BTS"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","CHK","HDN"
	,"HDN","TXR"
);
var ADVIT_FORMAT = new Array(
	"00","10","00","10","00"
	,"10","00","00","11","12"
	,"11","12","11","12","12"
	,"00","11","11","00","00"
	,"11","10","00","10","00"
	,"10","00","00","00","00"
	,"00","00","00","00","52"
	,"12","12","12","11","11"
	,"11","12"
);
var ADVIT_CODEID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
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
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET"
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1"
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,1,0,0,1,1
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0
);
var ADVIT_IMEMODE = new Array(
	0,0,0,0,0
	,0,0,2,0,0
	,0,0,0,0,0
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
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	0,0,0,0,0
	,0,0,1,0,0
	,0,0,0,0,0
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
	,"","SYOHINMST_SERCHSTK2","","",""
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
	,"FRM","","","FRM","PGN"
	,"","","","",""
	,"","","","FRM","FRM"
	,"","","","",""
	,"","","","",""
	,"",""
);
var ADVIT_ACTIONFORMID = new Array(
	"TH010F01","","","",""
	,"","","","",""
	,"","","","",""
	,"TH010F02","","","TH010F02",""
	,"","","","",""
	,"","","","TH010F03","TH010F03"
	,"","","","",""
	,"","","","",""
	,"",""
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","","M1"
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
	,"","","","",""
	,"",""
);
var ADVIT_CAPTION = new Array(
	"","","","仕入先",""
	,"ブランド","","メーカー品番","原価",""
	,"現売価","","ﾒｰｶｰ価格","",""
	,"検索","商品マスタ検索選択","","",""
	,"No.","仕入先","","部門",""
	,"品種","","ブランド","自社品番",""
	,"コア","メーカー品番","商品名","色","販売完了日"
	,"最新売価","原価","現売価","",""
	,"","ﾒｰｶｰ価格"
);

