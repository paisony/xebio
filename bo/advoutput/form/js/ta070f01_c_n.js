var ADVIT_FORMID = "TA070F01";
var ADVIT_TARGETPGID = "ta070p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "ta070f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,30,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,56,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_BTNMODEREF = 3;
var ADVIT_ID_BTNMODEUPD = 4;
var ADVIT_ID_BTNMODEDEL = 5;
var ADVIT_ID_MODENO = 6;
var ADVIT_ID_STKMODENO = 7;
var ADVIT_ID_BUMON_CD = 8;
var ADVIT_ID_BTNBUMON_CD = 9;
var ADVIT_ID_BUMON_NM = 10;
var ADVIT_ID_HINSYU_CD = 11;
var ADVIT_ID_BTNHINSYU_CD = 12;
var ADVIT_ID_HINSYU_RYAKU_NM = 13;
var ADVIT_ID_BURANDO_CD = 14;
var ADVIT_ID_BTNBURANDO_CD = 15;
var ADVIT_ID_BURANDO_NM_BO1 = 16;
var ADVIT_ID_KIKAN = 17;
var ADVIT_ID_JIDO_KBN = 18;
var ADVIT_ID_SAISIN_DATA = 19;
var ADVIT_ID_OLD_JISYA_HBN = 20;
var ADVIT_ID_MAKER_HBN = 21;
var ADVIT_ID_SCAN_CD = 22;
var ADVIT_ID_SEARCHCNT = 23;
var ADVIT_ID_BTNINSERT = 24;
var ADVIT_ID_BTNSEARCH = 25;
var ADVIT_ID_BTNPAGEINS = 26;
var ADVIT_ID_BTNSIZSTK = 27;
var ADVIT_ID_BTNROWDEL = 28;
var ADVIT_ID_PGR = 29;
var ADVIT_ID_M1ROWNO = 30;
var ADVIT_ID_M1BUMON_CD = 31;
var ADVIT_ID_M1BUMONKANA_NM = 32;
var ADVIT_ID_M1HINSYU_RYAKU_NM = 33;
var ADVIT_ID_M1BURANDO_NM_BO1 = 34;
var ADVIT_ID_M1MAKER_HBN = 35;
var ADVIT_ID_M1JISYA_HBN = 36;
var ADVIT_ID_M1SYOHIN_ZOKUSEI = 37;
var ADVIT_ID_M1IRO_NM = 38;
var ADVIT_ID_M1SIZE_NM = 39;
var ADVIT_ID_M1SCAN_CD = 40;
var ADVIT_ID_M1SYONMK = 41;
var ADVIT_ID_M1KAISI_YMD = 42;
var ADVIT_ID_M1SYURYO_YMD = 43;
var ADVIT_ID_M1HATTYUPTN_KBN = 44;
var ADVIT_ID_M1JIDO_KBNNM = 45;
var ADVIT_ID_M1URIAGE_SU = 46;
var ADVIT_ID_M1GENZAISETTEI_SU = 47;
var ADVIT_ID_M1LOT_SU = 48;
var ADVIT_ID_M1IRAIRIYU_CD = 49;
var ADVIT_ID_M1HENKO_IRAI_SU = 50;
var ADVIT_ID_M1HANBAIIN_NM = 51;
var ADVIT_ID_M1ADD_YMD = 52;
var ADVIT_ID_M1HONBUTENPOKBNNM = 53;
var ADVIT_ID_M1SELECTORCHECKBOX = 54;
var ADVIT_ID_M1ENTERSYORIFLG = 55;
var ADVIT_ID_M1DTLIROKBN = 56;
var ADVIT_ID_BTNENTER = 57;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Btnmoderef","Btnmodeupd"
	,"Btnmodedel","Modeno","Stkmodeno","Bumon_cd","Btnbumon_cd"
	,"Bumon_nm","Hinsyu_cd","Btnhinsyu_cd","Hinsyu_ryaku_nm","Burando_cd"
	,"Btnburando_cd","Burando_nm_bo1","Kikan","Jido_kbn","Saisin_data"
	,"Old_jisya_hbn","Maker_hbn","Scan_cd","Searchcnt","Btninsert"
	,"Btnsearch","Btnpageins","Btnsizstk","Btnrowdel","Pgr"
	,"M1rowno","M1bumon_cd","M1bumonkana_nm","M1hinsyu_ryaku_nm","M1burando_nm_bo1"
	,"M1maker_hbn","M1jisya_hbn","M1syohin_zokusei","M1iro_nm","M1size_nm"
	,"M1scan_cd","M1syonmk","M1kaisi_ymd","M1syuryo_ymd","M1hattyuptn_kbn"
	,"M1jido_kbnnm","M1uriage_su","M1genzaisettei_su","M1lot_su","M1irairiyu_cd"
	,"M1henko_irai_su","M1hanbaiin_nm","M1add_ymd","M1honbutenpokbnnm","M1selectorcheckbox"
	,"M1entersyoriflg","M1dtlirokbn","Btnenter"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","モード照会ボタン","モード修正ボタン"
	,"モード取消ボタン","モードNO","選択モードNO","部門コード","ボタン部門コード"
	,"部門名","品種コード","品種コードボタン","品種略名称","ブランドコード"
	,"ブランドコードボタン","ブランド名＿ＢＯ１","期間","自動区分","最新データ"
	,"旧自社品番","メーカー品番","スキャンコード","検索件数","新規作成ボタン"
	,"検索ボタン","ページ追加ボタン","サイズ選択ボタン","行削除ボタン","ページャ"
	,"Ｍ１行NO","Ｍ１部門コード","Ｍ１部門カナ名","Ｍ１品種略名称","Ｍ１ブランド名＿ＢＯ１"
	,"Ｍ１メーカー品番","Ｍ１自社品番","Ｍ１商品属性","Ｍ１色","Ｍ１サイズ"
	,"Ｍ１スキャンコード","Ｍ１商品名(カナ)","Ｍ１開始日","Ｍ１終了日","Ｍ１発注パターン"
	,"Ｍ１自動区分名称","Ｍ１売上数","Ｍ１現在設定数","Ｍ１ロット数","Ｍ１依頼理由コード"
	,"Ｍ１変更依頼数量","Ｍ１担当者名","Ｍ１登録日","Ｍ１本部店舗区分名称","Ｍ１選択フラグ(隠し)"
	,"Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)","確定ボタン"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","B","B"
	,"B","NA","NA","SG","B"
	,"SN4","SG","B","SN4","SG"
	,"B","SN9","D","SN5","NA"
	,"SG","SN9","SG","NA","B"
	,"B","B","B","B","B"
	,"NA","SG","SN9","SN4","SN9"
	,"SN9","NA","SN9","SN9","SN9"
	,"SG","SN4","D","D","SN4"
	,"SN4","NA","NA","NA","SN5"
	,"NA","SN4","NA","SN4","NA"
	,"NA","NA","B"
);
var ADVIT_LENGTH = new Array(
	4,0,15,0,0
	,0,2,2,3,0
	,15,2,0,15,6
	,0,20,0,1,1
	,10,30,18,4,0
	,0,0,0,0,0
	,3,3,30,15,20
	,30,8,3,10,4
	,18,30,0,0,2
	,10,5,4,3,2
	,4,12,6,2,1
	,1,2,0
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
	,0,0,0
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
	,0,0,0
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
	,0,0,0
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
	,0,0,0
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","LNK","LNK"
	,"LNK","HDN","HDN","TXT","BTN"
	,"TXR","TXT","BTN","TXR","TXT"
	,"BTN","TXR","TXT","DRL","CHK"
	,"TXT","TXR","TXT","TXT","BTS"
	,"BTS","BTS","BTS","BTS","LNS"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXT","TXR","TXT","TXT","TXR"
	,"TXR","TXR","TXR","TXR","DRL"
	,"TXT","TXR","TXR","TXR","CHK"
	,"HDN","HDN","BTS"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","00","00"
	,"00","11","11","10","00"
	,"00","10","00","00","10"
	,"00","00","52","00","11"
	,"00","00","00","11","00"
	,"00","00","00","00","00"
	,"11","10","00","00","00"
	,"00","10","00","00","00"
	,"00","00","52","52","00"
	,"00","12","12","12","00"
	,"12","00","11","00","11"
	,"11","11","00"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"","","","","C_BUMON_CD"
	,"","","C_HINSYU_CD","",""
	,"C_BURANDO_CD","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","","C_RIYU_CD"
	,"","","","",""
	,"","",""
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
	,"CANNOTGET","CANNOTGET","CANNOTGET"
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1",""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,1
	,1,1,1,0,1
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,1
);
var ADVIT_IMEMODE = new Array(
	3,0,0,0,0
	,0,0,0,3,0
	,0,3,0,0,3
	,0,0,3,0,0
	,3,0,3,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,3,0,3,3,0
	,0,0,0,0,0
	,3,0,0,0,0
	,0,0,0
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
	,0,0,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,0,0
	,0,0,0,1,0
	,0,1,0,0,1
	,0,0,1,0,0
	,1,0,1,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,1,0,1,1,0
	,0,0,0,0,0
	,1,0,0,0,0
	,0,0,0
);
var ADVIT_CONDID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","JIDO_KBN",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","",""
);
var ADVIT_ACTIONID = new Array(
	"","COD","","SPT","SPT"
	,"SPT","","","","COD"
	,"","","COD","",""
	,"COD","","","",""
	,"","","","","FRM"
	,"FRM","MINSX","FRM","FRM","PGN"
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","","COD"
	,"","","","",""
	,"","","FRM"
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","TA070F01","TA070F01"
	,"TA070F01","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","","TA070F01"
	,"TA070F01","","TA070F01","TA070F01",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","TA070F01"
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","M1","","","M1"
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","",""
);
var ADVIT_ACTPROGRAMID = new Array(
	"","","","TA070P01","TA070P01"
	,"TA070P01","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","",""
);
var ADVIT_CAPTION = new Array(
	"店舗","","","照会","修正"
	,"取消","","","部門",""
	,"","品種","","","ブランド"
	,"","","期間","自動区分","最新データ"
	,"自社品番","","ｽｷｬﾝｺｰﾄﾞ","検索件数","新規作成"
	,"検索","","","",""
	,"No.","部門","","品種","ブランド"
	,"メーカー品番","自社品番","コア","色","サイズ"
	,"スキャンコード","商品名","開始日","終了日","発注ﾊﾟﾀｰﾝ"
	,"自動区分","売上数","現在数","ロット","依頼理由"
	,"変更依頼","担当者","登録日","区分",""
	,"","","確定"
);

