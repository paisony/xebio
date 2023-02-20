var ADVIT_FORMID = "TE050F01";
var ADVIT_TARGETPGID = "te050p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "te050f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,22,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,38,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_BTNMODEJISHAHINBAN = 3;
var ADVIT_ID_BTNMODESONOTA = 4;
var ADVIT_ID_MODENO = 5;
var ADVIT_ID_STKMODENO = 6;
var ADVIT_ID_SIIRESAKI_CD = 7;
var ADVIT_ID_BTNSIIRESAKI_CD = 8;
var ADVIT_ID_SIIRESAKI_RYAKU_NM = 9;
var ADVIT_ID_BUMON_CD = 10;
var ADVIT_ID_BTNBUMON_CD = 11;
var ADVIT_ID_BUMON_NM = 12;
var ADVIT_ID_BURANDO_CD = 13;
var ADVIT_ID_BTNBURANDO_CD = 14;
var ADVIT_ID_BURANDO_NM = 15;
var ADVIT_ID_BTNINSERT = 16;
var ADVIT_ID_SEARCHCNT = 17;
var ADVIT_ID_BTNSEARCH = 18;
var ADVIT_ID_BTNPAGEINS = 19;
var ADVIT_ID_BTNROWDEL = 20;
var ADVIT_ID_PGR = 21;
var ADVIT_ID_M1ROWNO = 22;
var ADVIT_ID_M1BUMON_CD = 23;
var ADVIT_ID_M1BUMONKANA_NM = 24;
var ADVIT_ID_M1HINSYU_RYAKU_NM = 25;
var ADVIT_ID_M1BURANDO_NM = 26;
var ADVIT_ID_M1JISYA_HBN = 27;
var ADVIT_ID_M1MAKER_HBN = 28;
var ADVIT_ID_M1SYONMK = 29;
var ADVIT_ID_M1IRO_CD = 30;
var ADVIT_ID_M1BTNIROCD = 31;
var ADVIT_ID_M1IRO_NM = 32;
var ADVIT_ID_M1STOP_YMD = 33;
var ADVIT_ID_M1ADD_YMD = 34;
var ADVIT_ID_M1HONBUTENPOKBNNM = 35;
var ADVIT_ID_M1SELECTORCHECKBOX = 36;
var ADVIT_ID_M1ENTERSYORIFLG = 37;
var ADVIT_ID_M1DTLIROKBN = 38;
var ADVIT_ID_BTNENTER = 39;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Btnmodejishahinban","Btnmodesonota"
	,"Modeno","Stkmodeno","Siiresaki_cd","Btnsiiresaki_cd","Siiresaki_ryaku_nm"
	,"Bumon_cd","Btnbumon_cd","Bumon_nm","Burando_cd","Btnburando_cd"
	,"Burando_nm","Btninsert","Searchcnt","Btnsearch","Btnpageins"
	,"Btnrowdel","Pgr","M1rowno","M1bumon_cd","M1bumonkana_nm"
	,"M1hinsyu_ryaku_nm","M1burando_nm","M1jisya_hbn","M1maker_hbn","M1syonmk"
	,"M1iro_cd","M1btnirocd","M1iro_nm","M1stop_ymd","M1add_ymd"
	,"M1honbutenpokbnnm","M1selectorcheckbox","M1entersyoriflg","M1dtlirokbn","Btnenter"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","モード自社品番ボタン","モードその他ボタン"
	,"モードNO","選択モードNO","仕入先コード","仕入先コードボタン","仕入先名称"
	,"部門コード","部門コードボタン","部門名","ブランドコード","ブランドコードボタン"
	,"ブランド名","新規作成ボタン","検索件数","検索ボタン","ページ追加ボタン"
	,"行削除ボタン","ページャ","Ｍ１行NO","Ｍ１部門コード","Ｍ１部門カナ名"
	,"Ｍ１品種略名称","Ｍ１ブランド名","Ｍ１自社品番","Ｍ１メーカー品番","Ｍ１商品名(カナ)"
	,"Ｍ１色コード","Ｍ１色コードボタン","Ｍ１色","Ｍ１防止期限","Ｍ１登録日"
	,"Ｍ１本部店舗区分名称","Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)","確定ボタン"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","B","B"
	,"NA","NA","SG","B","SN4"
	,"SG","B","SN4","SG","B"
	,"SN9","B","NA","B","B"
	,"B","B","NA","SG","SN9"
	,"SN4","SN9","SG","SN9","SN9"
	,"SG","B","SN9","D","D"
	,"SN4","NA","NA","NA","B"
);
var ADVIT_LENGTH = new Array(
	4,0,15,0,0
	,2,2,4,0,20
	,3,0,15,6,0
	,20,0,4,0,0
	,0,0,4,3,30
	,15,20,10,30,30
	,3,0,10,0,0
	,2,1,1,2,0
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
	"TXT","BTN","TXR","LNK","LNK"
	,"HDN","HDN","TXT","BTN","TXR"
	,"TXT","BTN","TXR","TXT","BTN"
	,"TXR","BTS","TXT","BTS","BTS"
	,"BTS","LNS","TXR","TXR","TXR"
	,"TXR","TXR","TXT","TXR","TXR"
	,"TXT","BTN","TXR","TXT","TXR"
	,"TXR","CHK","HDN","HDN","BTS"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","00","00"
	,"11","11","10","00","00"
	,"10","00","00","10","00"
	,"00","00","11","00","00"
	,"00","00","11","10","00"
	,"00","00","00","00","00"
	,"10","00","00","52","52"
	,"00","11","11","11","00"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"","","","C_SIIRESAKI_CD",""
	,"","C_BUMON_CD","","","C_BURANDO_CD"
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","C_IRO_CD","","",""
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
	,"","","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1",""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,1,0,1,0
	,0,1,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,1
);
var ADVIT_IMEMODE = new Array(
	3,0,0,0,0
	,0,0,3,0,0
	,3,0,0,3,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,3,0,0
	,3,0,0,3,0
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
	1,0,0,0,0
	,0,0,1,0,0
	,1,0,0,1,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,1,0,0
	,1,0,0,1,0
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
	"","COD","","SPT","SPT"
	,"","","","COD",""
	,"","COD","","","COD"
	,"","FRM","","FRM","MINSX"
	,"FRM","PGN","","",""
	,"","","","",""
	,"","COD","","",""
	,"","","","","FRM"
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","TE050F01","TE050F01"
	,"","","","",""
	,"","","","",""
	,"","TE050F01","","TE050F01",""
	,"TE050F01","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","","TE050F01"
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","","M1"
	,"","M1","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
);
var ADVIT_ACTPROGRAMID = new Array(
	"","","","TE050P01","TE050P01"
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
);
var ADVIT_CAPTION = new Array(
	"店舗","","","自社品番","その他"
	,"","","仕入先","",""
	,"部門","","","ブランド",""
	,"","新規作成","検索件数","検索",""
	,"","","No.","部門",""
	,"品種","ブランド","自社品番","メーカー品番","商品名"
	,"色","","","防止期限","登録日付"
	,"登録区分","","","","確定"
);

