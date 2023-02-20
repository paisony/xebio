var ADVIT_FORMID = "TH010F01";
var ADVIT_TARGETPGID = "th010p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "th010f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,37,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,59,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_BTNMODEJISHAHINBAN = 3;
var ADVIT_ID_BTNMODESCANCD = 4;
var ADVIT_ID_BTNMODEMAKERHBN = 5;
var ADVIT_ID_BTNMODESONOTA = 6;
var ADVIT_ID_OLD_JISYA_HBN_FROM = 7;
var ADVIT_ID_OLD_JISYA_HBN_TO = 8;
var ADVIT_ID_SCAN_CD = 9;
var ADVIT_ID_MAKER_HBN = 10;
var ADVIT_ID_BTNMAKER_HBN = 11;
var ADVIT_ID_BUMON_CD = 12;
var ADVIT_ID_BTNBUMON_CD = 13;
var ADVIT_ID_BUMON_NM = 14;
var ADVIT_ID_HINSYU_CD = 15;
var ADVIT_ID_BTNHINSYU_CD = 16;
var ADVIT_ID_HINSYU_RYAKU_NM = 17;
var ADVIT_ID_BURANDO_CD = 18;
var ADVIT_ID_BTNBURANDO_CD = 19;
var ADVIT_ID_BURANDO_NM = 20;
var ADVIT_ID_SIIRESAKI_CD = 21;
var ADVIT_ID_BTNSIIRESAKI_CD = 22;
var ADVIT_ID_SIIRESAKI_RYAKU_NM = 23;
var ADVIT_ID_GENBAIKA_TNK_FROM = 24;
var ADVIT_ID_GENBAIKA_TNK_TO = 25;
var ADVIT_ID_MAKERKAKAKU_TNK_FROM = 26;
var ADVIT_ID_MAKERKAKAKU_TNK_TO = 27;
var ADVIT_ID_HANBAIKANRYO_YMD_FROM = 28;
var ADVIT_ID_HANBAIKANRYO_YMD_TO = 29;
var ADVIT_ID_SEARCHCNT = 30;
var ADVIT_ID_BTNSEARCH = 31;
var ADVIT_ID_SYOHINMST_SERCHSTK = 32;
var ADVIT_ID_MODENO = 33;
var ADVIT_ID_STKMODENO = 34;
var ADVIT_ID_BTNCSV = 35;
var ADVIT_ID_PGR = 36;
var ADVIT_ID_M1ROWNO = 37;
var ADVIT_ID_M1SIIRESAKI_CD = 38;
var ADVIT_ID_M1SIIRESAKI_RYAKU_NM = 39;
var ADVIT_ID_M1BUMON_CD = 40;
var ADVIT_ID_M1BUMONKANA_NM = 41;
var ADVIT_ID_M1HINSYU_CD = 42;
var ADVIT_ID_M1HINSYU_RYAKU_NM = 43;
var ADVIT_ID_M1BURANDO_NM = 44;
var ADVIT_ID_M1JISYA_HBN = 45;
var ADVIT_ID_M1OLD_JISYA_HBN = 46;
var ADVIT_ID_M1SYOHIN_ZOKUSEI = 47;
var ADVIT_ID_M1MAKER_HBN = 48;
var ADVIT_ID_M1SYONMK = 49;
var ADVIT_ID_M1IRO_NM = 50;
var ADVIT_ID_M1HANBAIKANRYO_YMD = 51;
var ADVIT_ID_M1ZEIRITSU = 52;
var ADVIT_ID_M1SAISINBAIKA_TNK = 53;
var ADVIT_ID_M1GENKA = 54;
var ADVIT_ID_M1GENBAIKA_TNK = 55;
var ADVIT_ID_M1MAKERKAKAKU_TNK = 56;
var ADVIT_ID_M1SELECTORCHECKBOX = 57;
var ADVIT_ID_M1ENTERSYORIFLG = 58;
var ADVIT_ID_M1DTLIROKBN = 59;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Btnmodejishahinban","Btnmodescancd"
	,"Btnmodemakerhbn","Btnmodesonota","Old_jisya_hbn_from","Old_jisya_hbn_to","Scan_cd"
	,"Maker_hbn","Btnmaker_hbn","Bumon_cd","Btnbumon_cd","Bumon_nm"
	,"Hinsyu_cd","Btnhinsyu_cd","Hinsyu_ryaku_nm","Burando_cd","Btnburando_cd"
	,"Burando_nm","Siiresaki_cd","Btnsiiresaki_cd","Siiresaki_ryaku_nm","Genbaika_tnk_from"
	,"Genbaika_tnk_to","Makerkakaku_tnk_from","Makerkakaku_tnk_to","Hanbaikanryo_ymd_from","Hanbaikanryo_ymd_to"
	,"Searchcnt","Btnsearch","Syohinmst_serchstk","Modeno","Stkmodeno"
	,"Btncsv","Pgr","M1rowno","M1siiresaki_cd","M1siiresaki_ryaku_nm"
	,"M1bumon_cd","M1bumonkana_nm","M1hinsyu_cd","M1hinsyu_ryaku_nm","M1burando_nm"
	,"M1jisya_hbn","M1old_jisya_hbn","M1syohin_zokusei","M1maker_hbn","M1syonmk"
	,"M1iro_nm","M1hanbaikanryo_ymd","M1zeiritsu","M1saisinbaika_tnk","M1genka"
	,"M1genbaika_tnk","M1makerkakaku_tnk","M1selectorcheckbox","M1entersyoriflg","M1dtlirokbn"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","モード自社品番ボタン","モードスキャンコードボタン"
	,"モードメーカー品番ボタン","モードその他ボタン","旧自社品番FROM","旧自社品番TO","スキャンコード"
	,"メーカー品番","メーカー品番ボタン","部門コード","部門コードボタン","部門名"
	,"品種コード","品種コードボタン","品種略名称","ブランドコード","ブランドコードボタン"
	,"ブランド名","仕入先コード","仕入先コードボタン","仕入先名称","現売価FROM"
	,"現売価TO","メーカー価格FROM","メーカー価格TO","販売完了日FROM","販売完了日TO"
	,"検索件数","検索ボタン","商品マスタ検索選択","モードNO","選択モードNO"
	,"CSV出力ボタン","ページャ","Ｍ１行NO","Ｍ１仕入先コード","Ｍ１仕入先名称"
	,"Ｍ１部門コード","Ｍ１部門カナ名","Ｍ１品種コード","Ｍ１品種略名称","Ｍ１ブランド名"
	,"Ｍ１自社品番リンク","Ｍ１旧自社品番リンク","Ｍ１商品属性","Ｍ１メーカー品番","Ｍ１商品名(カナ)"
	,"Ｍ１色","Ｍ１販売完了日","Ｍ1税率","Ｍ１最新売価","Ｍ１原価"
	,"Ｍ１現売価","Ｍ１メーカー価格","Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","B","B"
	,"B","B","SG","SG","SG"
	,"SN21","B","SG","B","SN4"
	,"SG","B","SN4","SG","B"
	,"SN9","SG","B","SN4","NA"
	,"NA","NA","NA","D","D"
	,"NA","B","NA","NA","NA"
	,"B","B","NA","SG","SN4"
	,"SG","SN9","SG","SN4","SN9"
	,"B","B","SN9","SN9","SN9"
	,"SN9","D","NA","NA","NC"
	,"NA","NA","NA","NA","NA"
);
var ADVIT_LENGTH = new Array(
	4,0,15,0,0
	,0,0,10,10,18
	,30,0,3,0,15
	,2,0,15,6,0
	,20,4,0,20,8
	,8,8,8,0,0
	,4,0,1,2,2
	,0,0,3,4,20
	,3,15,2,15,20
	,0,0,3,30,30
	,10,0,2,7,8
	,8,8,1,1,2
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
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","LNK","LNK"
	,"LNK","LNK","TXT","TXT","TXT"
	,"TXT","BTN","TXT","BTN","TXR"
	,"TXT","BTN","TXR","TXT","BTN"
	,"TXR","TXT","BTN","TXR","TXT"
	,"TXT","TXT","TXT","TXT","TXT"
	,"TXR","BTS","RDO","HDN","HDN"
	,"BTS","LNS","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"BTS","BTS","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","CHK","HDN","HDN"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","00","00"
	,"00","00","00","00","00"
	,"00","00","10","00","00"
	,"10","00","00","10","00"
	,"00","10","00","00","12"
	,"12","12","12","52","52"
	,"12","00","11","11","11"
	,"00","00","11","10","00"
	,"10","00","10","00","00"
	,"00","00","00","00","00"
	,"00","52","11","12","12"
	,"12","12","11","11","11"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"","","","",""
	,"","C_MAKERHBN","","C_BUMON_CD",""
	,"","C_HINSYU_CD","","","C_BURANDO_CD"
	,"","","C_SIIRESAKI_CD","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
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
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,1,0,0,0
	,1,1,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
);
var ADVIT_IMEMODE = new Array(
	3,0,0,0,0
	,0,0,3,3,3
	,2,0,3,0,0
	,3,0,0,3,0
	,0,3,0,0,3
	,3,3,3,3,3
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
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
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,0,0
	,0,0,1,1,1
	,1,0,1,0,0
	,1,0,0,1,0
	,0,1,0,0,1
	,1,1,1,1,1
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
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
	,"","","SYOHINMST_SERCHSTK1","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
);
var ADVIT_ACTIONID = new Array(
	"","COD","","SPT","SPT"
	,"SPT","SPT","","",""
	,"","COD","","COD",""
	,"","COD","","","COD"
	,"","","COD","",""
	,"","","","",""
	,"","FRM","","",""
	,"FRM","PGN","","",""
	,"","","","",""
	,"FRM","FRM","","",""
	,"","","","",""
	,"","","","",""
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","TH010F01","","",""
	,"TH010F01","","","",""
	,"","","","",""
	,"TH010F02","TH010F02","","",""
	,"","","","",""
	,"","","","",""
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","M1","","",""
	,"","","","",""
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
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
);
var ADVIT_CAPTION = new Array(
	"店舗","","","自社品番","スキャンコード"
	,"メーカー品番","その他","旧自社品番ＦＲＯＭ","旧自社品番ＴＯ","スキャンコード"
	,"メーカー品番","","部門","",""
	,"品種","","","ブランド",""
	,"","仕入先","","","現売価ＦＲＯＭ"
	,"現売価ＴＯ","メーカー価格ＦＲＯＭ","メーカー価格ＴＯ","販売完了日ＦＲＯＭ","販売完了日ＴＯ"
	,"","検索","商品マスタ検索選択","",""
	,"","","No.","仕入先",""
	,"部門","","品種","","ブランド"
	,"自社品番","","コア","メーカー品番","商品名"
	,"色","販売完了日","税率","最新売価","原価"
	,"現売価","ﾒｰｶｰ価格","","",""
);

