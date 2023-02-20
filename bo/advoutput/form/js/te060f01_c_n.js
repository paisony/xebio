var ADVIT_FORMID = "TE060F01";
var ADVIT_TARGETPGID = "te060p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "te060f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,28,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,42,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_BTNMODEREF = 3;
var ADVIT_ID_BTNMODEUPD = 4;
var ADVIT_ID_BTNMODEDEL = 5;
var ADVIT_ID_MODENO = 6;
var ADVIT_ID_STKMODENO = 7;
var ADVIT_ID_SYOHINGUN1_CD = 8;
var ADVIT_ID_BTNSYOHINGUN1_CD = 9;
var ADVIT_ID_SYOHINGUN1_RYAKU_NM = 10;
var ADVIT_ID_SIIRESAKI_CD = 11;
var ADVIT_ID_BTNSIIRESAKI_CD = 12;
var ADVIT_ID_SIIRESAKI_RYAKU_NM = 13;
var ADVIT_ID_BUMON_CD = 14;
var ADVIT_ID_BTNBUMON_CD = 15;
var ADVIT_ID_BUMON_NM = 16;
var ADVIT_ID_SAKUJO_KBN = 17;
var ADVIT_ID_HANBAIKANRYO_YMD = 18;
var ADVIT_ID_ADD_YMD_FROM = 19;
var ADVIT_ID_ADD_YMD_TO = 20;
var ADVIT_ID_SORT_JUN = 21;
var ADVIT_ID_SEARCHCNT = 22;
var ADVIT_ID_BTNSEARCH = 23;
var ADVIT_ID_BTNZENSTK = 24;
var ADVIT_ID_BTNZENKJO = 25;
var ADVIT_ID_STOP_YMD = 26;
var ADVIT_ID_PGR = 27;
var ADVIT_ID_M1ROWNO = 28;
var ADVIT_ID_M1BUMON_CD = 29;
var ADVIT_ID_M1BUMONKANA_NM = 30;
var ADVIT_ID_M1HINSYU_RYAKU_NM = 31;
var ADVIT_ID_M1BURANDO_NM = 32;
var ADVIT_ID_M1JISYA_HBN1 = 33;
var ADVIT_ID_M1MAKER_HBN = 34;
var ADVIT_ID_M1SYONMK = 35;
var ADVIT_ID_M1IRO_NM = 36;
var ADVIT_ID_M1STOP_YMD = 37;
var ADVIT_ID_M1ADD_YMD = 38;
var ADVIT_ID_M1HONBUTENPOKBNNM = 39;
var ADVIT_ID_M1SELECTORCHECKBOX = 40;
var ADVIT_ID_M1ENTERSYORIFLG = 41;
var ADVIT_ID_M1DTLIROKBN = 42;
var ADVIT_ID_BTNENTER = 43;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Btnmoderef","Btnmodeupd"
	,"Btnmodedel","Modeno","Stkmodeno","Syohingun1_cd","Btnsyohingun1_cd"
	,"Syohingun1_ryaku_nm","Siiresaki_cd","Btnsiiresaki_cd","Siiresaki_ryaku_nm","Bumon_cd"
	,"Btnbumon_cd","Bumon_nm","Sakujo_kbn","Hanbaikanryo_ymd","Add_ymd_from"
	,"Add_ymd_to","Sort_jun","Searchcnt","Btnsearch","Btnzenstk"
	,"Btnzenkjo","Stop_ymd","Pgr","M1rowno","M1bumon_cd"
	,"M1bumonkana_nm","M1hinsyu_ryaku_nm","M1burando_nm","M1jisya_hbn1","M1maker_hbn"
	,"M1syonmk","M1iro_nm","M1stop_ymd","M1add_ymd","M1honbutenpokbnnm"
	,"M1selectorcheckbox","M1entersyoriflg","M1dtlirokbn","Btnenter"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","モード照会ボタン","モード修正ボタン"
	,"モード取消ボタン","モードNO","選択モードNO","商品群１コード","商品群１コードボタン"
	,"商品群１略式名称","仕入先コード","仕入先コードボタン","仕入先名称","部門コード"
	,"部門コードボタン","部門名","削除区分","販売完了日","登録日ＦＲＯＭ"
	,"登録日ＴＯ","ソート順","検索件数","検索ボタン","全選択ボタン"
	,"全解除ボタン","防止期限","ページャ","Ｍ１行NO","Ｍ１部門コード"
	,"Ｍ１部門カナ名","Ｍ１品種略名称","Ｍ１ブランド名","Ｍ１自社品番","Ｍ１メーカー品番"
	,"Ｍ１商品名(カナ)","Ｍ１色","Ｍ１防止期限","Ｍ１登録日","Ｍ１本部店舗区分名称"
	,"Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)","確定ボタン"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","B","B"
	,"B","NA","NA","SG","B"
	,"SN4","SG","B","SN4","SG"
	,"B","SN4","SN5","D","D"
	,"D","SN5","NA","B","B"
	,"B","D","B","NA","SG"
	,"SN9","SN4","SN9","SG","SN9"
	,"SN9","SN9","D","D","SN4"
	,"NA","NA","NA","B"
);
var ADVIT_LENGTH = new Array(
	4,0,15,0,0
	,0,2,2,4,0
	,10,4,0,20,3
	,0,15,1,0,0
	,0,1,4,0,0
	,0,0,0,3,3
	,30,15,20,8,30
	,30,10,0,0,2
	,1,1,2,0
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
	,0,0,0,0
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
	,0,0,0,0
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
	,0,0,0,0
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
	,0,0,0,0
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","LNK","LNK"
	,"LNK","HDN","HDN","TXT","BTN"
	,"TXR","TXT","BTN","TXR","TXT"
	,"BTN","TXR","DRL","TXT","TXT"
	,"TXT","RDO","TXR","BTS","BTS"
	,"BTS","TXT","LNS","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"CHK","HDN","HDN","BTS"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","00","00"
	,"00","11","11","10","00"
	,"00","10","00","00","10"
	,"00","00","00","52","52"
	,"52","00","12","00","00"
	,"00","52","00","11","10"
	,"00","00","00","10","00"
	,"00","00","52","52","00"
	,"11","11","11","00"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"","","","","C_SHOHINGUN1_CD"
	,"","","C_SIIRESAKI_CD","",""
	,"C_BUMON_CD","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","",""
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
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1",""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,1,0
	,0,0,1,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,1
);
var ADVIT_IMEMODE = new Array(
	3,0,0,0,0
	,0,0,0,3,0
	,0,3,0,0,3
	,0,0,0,3,3
	,3,0,0,0,0
	,0,3,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0
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
	,0,0,0,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,0,0
	,0,0,0,1,0
	,0,1,0,0,1
	,0,0,0,1,1
	,1,0,0,0,0
	,0,1,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0
);
var ADVIT_CONDID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","SAKUJO_KBN","",""
	,"","SAINYUKABOSI_JUN","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","",""
);
var ADVIT_ACTIONID = new Array(
	"","COD","","SPT","SPT"
	,"SPT","","","","COD"
	,"","","COD","",""
	,"COD","","","",""
	,"","","","FRM","FRM"
	,"FRM","","PGN","",""
	,"","","","",""
	,"","","","",""
	,"","","","FRM"
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","TE060F01","TE060F01"
	,"TE060F01","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","TE060F01","TE060F01"
	,"TE060F01","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","TE060F01"
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","","M1"
	,"M1","","M1","",""
	,"","","","",""
	,"","","","",""
	,"","","",""
);
var ADVIT_ACTPROGRAMID = new Array(
	"","","","TE060P01","TE060P01"
	,"TE060P01","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","",""
);
var ADVIT_CAPTION = new Array(
	"店舗","","","照会","修正"
	,"取消","","","商品群１",""
	,"","仕入先","","","部門"
	,"","","削除区分","販売完了日","登録日ＦＲＯＭ"
	,"登録日ＴＯ","","","検索",""
	,"","防止期限","","No.","部門"
	,"","品種","ブランド","自社品番","メーカー品番"
	,"商品名","色","防止期限","登録日付","登録区分"
	,"","","","確定"
);

