var ADVIT_FORMID = "TK010F02";
var ADVIT_TARGETPGID = "tk010p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tk010f02.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,16,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,50,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_BTNBACK = 0;
var ADVIT_ID_HEAD_TENPO_CD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_STKMODENO = 3;
var ADVIT_ID_SYORI_YM = 4;
var ADVIT_ID_TENPO_CD = 5;
var ADVIT_ID_TENPO_NM = 6;
var ADVIT_ID_SYONIN_FLG_NM = 7;
var ADVIT_ID_KESSAI_FLG_NM = 8;
var ADVIT_ID_APPLY_YMD = 9;
var ADVIT_ID_BTNIKKATSUSYONIN = 10;
var ADVIT_ID_BTNIKKATSUKYAKKA = 11;
var ADVIT_ID_BTNZENKJO = 12;
var ADVIT_ID_IKKATSUKYAKKA_KYAKKARIYU_KB = 13;
var ADVIT_ID_IKKATSUKYAKKA_KYAKKARIYU = 14;
var ADVIT_ID_PGR = 15;
var ADVIT_ID_M1ROWNO = 16;
var ADVIT_ID_M1BUMON_CD = 17;
var ADVIT_ID_M1HINSYU_CD = 18;
var ADVIT_ID_M1BURANDO_NM = 19;
var ADVIT_ID_M1JISYA_HBN = 20;
var ADVIT_ID_M1HANBAIKANRYO_YMD = 21;
var ADVIT_ID_M1MAKER_HBN = 22;
var ADVIT_ID_M1SYONMK = 23;
var ADVIT_ID_M1SCAN_CD = 24;
var ADVIT_ID_M1IRO_NM = 25;
var ADVIT_ID_M1SIZE_NM = 26;
var ADVIT_ID_M1GENBAIKA_TNK = 27;
var ADVIT_ID_M1SURYO = 28;
var ADVIT_ID_M1GEN_TNK = 29;
var ADVIT_ID_M1GENKAKIN = 30;
var ADVIT_ID_M1NYURYOKU_YMD = 31;
var ADVIT_ID_M1APPLY_YMD = 32;
var ADVIT_ID_M1NYURYOKUSHA_CD = 33;
var ADVIT_ID_M1SINSEISYA_CD = 34;
var ADVIT_ID_M1HYOKASONSYUBETSU_KB = 35;
var ADVIT_ID_M1HYOKASONRIYU_KB = 36;
var ADVIT_ID_M1HYOKASONRIYU_KB_KEINEN = 37;
var ADVIT_ID_M1HYOKASONRIYU = 38;
var ADVIT_ID_M1KYAKKARIYU_KB = 39;
var ADVIT_ID_M1KYAKKARIYU = 40;
var ADVIT_ID_M1TYOTATSU_NM = 41;
var ADVIT_ID_M1SYONIN_FLG = 42;
var ADVIT_ID_M1KYAKKA_FLG = 43;
var ADVIT_ID_M1HINSYU_RYAKU_NM = 44;
var ADVIT_ID_M1BUMON_NM = 45;
var ADVIT_ID_M1SURYO_HDN = 46;
var ADVIT_ID_M1GENKAKIN_HDN = 47;
var ADVIT_ID_M1SELECTORCHECKBOX = 48;
var ADVIT_ID_M1ENTERSYORIFLG = 49;
var ADVIT_ID_M1DTLIROKBN = 50;
var ADVIT_ID_GOKEI_SURYO = 51;
var ADVIT_ID_HAIBUN_KIN_GOKEI = 52;
var ADVIT_ID_BTNENTER = 53;

var ADVIT_ID = new Array(
	"Btnback","Head_tenpo_cd","Head_tenpo_nm","Stkmodeno","Syori_ym"
	,"Tenpo_cd","Tenpo_nm","Syonin_flg_nm","Kessai_flg_nm","Apply_ymd"
	,"Btnikkatsusyonin","Btnikkatsukyakka","Btnzenkjo","Ikkatsukyakka_kyakkariyu_kb","Ikkatsukyakka_kyakkariyu"
	,"Pgr","M1rowno","M1bumon_cd","M1hinsyu_cd","M1burando_nm"
	,"M1jisya_hbn","M1hanbaikanryo_ymd","M1maker_hbn","M1syonmk","M1scan_cd"
	,"M1iro_nm","M1size_nm","M1genbaika_tnk","M1suryo","M1gen_tnk"
	,"M1genkakin","M1nyuryoku_ymd","M1apply_ymd","M1nyuryokusha_cd","M1sinseisya_cd"
	,"M1hyokasonsyubetsu_kb","M1hyokasonriyu_kb","M1hyokasonriyu_kb_keinen","M1hyokasonriyu","M1kyakkariyu_kb"
	,"M1kyakkariyu","M1tyotatsu_nm","M1syonin_flg","M1kyakka_flg","M1hinsyu_ryaku_nm"
	,"M1bumon_nm","M1suryo_hdn","M1genkakin_hdn","M1selectorcheckbox","M1entersyoriflg"
	,"M1dtlirokbn","Gokei_suryo","Haibun_kin_gokei","Btnenter"
);
var ADVIT_NAME = new Array(
	"戻るボタン","ヘッダ店舗コード","ヘッダ店舗名","選択モードNO","処理月"
	,"店舗コード","店舗名","承認状態名称","決裁状態名称","申請日"
	,"一括承認ボタン","一括却下ボタン","全解除ボタン","一括却下用却下理由区分","一括却下用却下理由"
	,"ページャ","Ｍ１行NO","Ｍ１部門コード","Ｍ１品種コード","Ｍ１ブランド名"
	,"Ｍ１自社品番","Ｍ１販売完了日","Ｍ１メーカー品番","Ｍ１商品名(カナ)","Ｍ１スキャンコード"
	,"Ｍ１色","Ｍ１サイズ","Ｍ１現売価","Ｍ１数量","Ｍ１原単価"
	,"Ｍ１原価金額","Ｍ１入力日","Ｍ１申請日","Ｍ１入力者コード","Ｍ１申請者コード"
	,"Ｍ１評価損種別区分","Ｍ１評価損理由区分","Ｍ１評価損理由区分_経年商品","Ｍ１評価損理由","Ｍ１却下理由区分"
	,"Ｍ１却下理由","Ｍ１調達区分名称","Ｍ１承認状態","Ｍ１却下フラグ","M1品種略名称（隠し）"
	,"M1部門名（隠し）","Ｍ１数量（隠し）","Ｍ１原価金額（隠し）","Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)"
	,"Ｍ１明細色区分(隠し)","合計数量","原価金額合計","確定ボタン"
);
var ADVIT_ATTRIBUTE = new Array(
	"B","SG","SN4","NA","D"
	,"SG","SN4","SN4","SN4","D"
	,"B","B","B","SN5","SN21"
	,"B","NA","SG","SG","SN9"
	,"SG","NA","SN9","SN9","SG"
	,"SN9","SN9","NA","NC","NA"
	,"NA","NA","NA","SG","NA"
	,"SN5","SN5","SN5","SN21","SN5"
	,"SN21","SN4","NA","NA","SN5"
	,"SN5","NA","NA","NA","NA"
	,"NA","NA","NA","B"
);
var ADVIT_LENGTH = new Array(
	0,4,15,2,0
	,4,15,2,3,0
	,0,0,0,2,20
	,0,4,3,2,20
	,8,6,30,30,18
	,10,4,7,4,7
	,9,6,6,7,7
	,2,2,2,20,2
	,20,2,1,1,15
	,15,7,9,1,1
	,2,8,9,0
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
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0
);
var ADVIT_REQUIREDFLG = new Array(
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
	,0,0,0,0
);
var ADVIT_TYPE = new Array(
	"BTS","TXR","TXR","HDN","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"BTS","BTS","BTS","DRL","TXT"
	,"LNS","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXT"
	,"TXR","TXR","TXR","TXT","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"DRL","DRL","DRL","TXT","DRL"
	,"TXT","TXR","CHK","CHK","HDN"
	,"HDN","HDN","HDN","CHK","HDN"
	,"HDN","TXR","TXR","BTS"
);
var ADVIT_FORMAT = new Array(
	"00","10","00","11","54"
	,"10","00","00","00","52"
	,"00","00","00","00","00"
	,"00","11","10","10","00"
	,"10","10","00","00","00"
	,"00","00","12","12","12"
	,"12","10","10","10","10"
	,"00","00","00","00","00"
	,"00","00","11","11","00"
	,"00","11","11","11","11"
	,"11","12","12","00"
);
var ADVIT_CODEID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","C_MEISYO_CD",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"C_MEISYO_CD","C_MEISYO_CD","C_MEISYO_CD","","C_MEISYO_CD"
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
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","","",""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,1,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,1
);
var ADVIT_IMEMODE = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,1
	,0,0,0,0,0
	,0,0,0,0,3
	,0,0,0,3,0
	,0,0,0,0,0
	,0,0,0,1,0
	,1,0,0,0,0
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
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,1
	,0,0,0,0,0
	,0,0,0,0,1
	,0,0,0,1,0
	,0,0,0,0,0
	,0,0,0,1,0
	,1,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0
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
	,"","","","",""
	,"","","","",""
	,"","","",""
);
var ADVIT_ACTIONID = new Array(
	"FRM","","","",""
	,"","","","",""
	,"FRM","FRM","FRM","COD",""
	,"PGN","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"COD","COD","COD","","COD"
	,"","","","",""
	,"","","","",""
	,"","","","FRM"
);
var ADVIT_ACTIONFORMID = new Array(
	"TK010F01","","","",""
	,"","","","",""
	,"TK010F02","TK010F02","TK010F02","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","TK010F01"
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","M1","",""
	,"M1","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","",""
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
	,"","","",""
);
var ADVIT_CAPTION = new Array(
	"","","","","処理月"
	,"店舗","","承認状態","決裁状態","申請日"
	,"","","","一括却下用却下理由",""
	,"","No.","部門","品種","ブランド"
	,"自社品番","販完日","メーカー品番","商品名","スキャンコード"
	,"色","サイズ","現売価","数量","原単価"
	,"原価金額","入力日","申請日","入力者","申請者"
	,"種別","評価損理由","","評価損理由","却下理由"
	,"却下理由","調達","","",""
	,"","","","",""
	,"","合計","","確定"
);

