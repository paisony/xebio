var ADVIT_FORMID = "TK030F01";
var ADVIT_TARGETPGID = "tk030p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tk030f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,16,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,44,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_SYORI_YM = 3;
var ADVIT_ID_TENPO_CD_FROM = 4;
var ADVIT_ID_BTNTENPOCD_FROM = 5;
var ADVIT_ID_TENPO_NM_FROM = 6;
var ADVIT_ID_TENPO_CD_TO = 7;
var ADVIT_ID_BTNTENPOCD_TO = 8;
var ADVIT_ID_TENPO_NM_TO = 9;
var ADVIT_ID_SEARCHCNT = 10;
var ADVIT_ID_BTNSEARCH = 11;
var ADVIT_ID_BTNIKKATSUSYONIN = 12;
var ADVIT_ID_BTNIKKATSUKYAKKA = 13;
var ADVIT_ID_BTNZENKJO = 14;
var ADVIT_ID_PGR = 15;
var ADVIT_ID_M1ROWNO = 16;
var ADVIT_ID_M1TENPO_CD = 17;
var ADVIT_ID_M1BUMON_CD = 18;
var ADVIT_ID_M1HINSYU_CD = 19;
var ADVIT_ID_M1BURANDO_NM = 20;
var ADVIT_ID_M1JISYA_HBN = 21;
var ADVIT_ID_M1HANBAIKANRYO_YMD = 22;
var ADVIT_ID_M1MAKER_HBN = 23;
var ADVIT_ID_M1SYONMK = 24;
var ADVIT_ID_M1SCAN_CD = 25;
var ADVIT_ID_M1IRO_NM = 26;
var ADVIT_ID_M1SIZE_NM = 27;
var ADVIT_ID_M1GENBAIKA_TNK = 28;
var ADVIT_ID_M1HYOKASON_SU = 29;
var ADVIT_ID_M1GEN_TNK = 30;
var ADVIT_ID_M1HAIBUN_KIN = 31;
var ADVIT_ID_M1NYURYOKU_YMD = 32;
var ADVIT_ID_M1APPLY_YMD = 33;
var ADVIT_ID_M1NYURYOKUSHA_CD = 34;
var ADVIT_ID_M1SINSEISYA_CD = 35;
var ADVIT_ID_M1HYOKASONSYUBETSU_KB = 36;
var ADVIT_ID_M1HYOKASONRIYU = 37;
var ADVIT_ID_M1KYAKKARIYU_KB = 38;
var ADVIT_ID_M1KYAKKARIYU = 39;
var ADVIT_ID_M1SYONIN_FLG = 40;
var ADVIT_ID_M1KYAKKA_FLG = 41;
var ADVIT_ID_M1SELECTORCHECKBOX = 42;
var ADVIT_ID_M1ENTERSYORIFLG = 43;
var ADVIT_ID_M1DTLIROKBN = 44;
var ADVIT_ID_GOKEI_SURYO = 45;
var ADVIT_ID_HAIBUN_KIN_GOKEI = 46;
var ADVIT_ID_BTNENTER = 47;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Syori_ym","Tenpo_cd_from"
	,"Btntenpocd_from","Tenpo_nm_from","Tenpo_cd_to","Btntenpocd_to","Tenpo_nm_to"
	,"Searchcnt","Btnsearch","Btnikkatsusyonin","Btnikkatsukyakka","Btnzenkjo"
	,"Pgr","M1rowno","M1tenpo_cd","M1bumon_cd","M1hinsyu_cd"
	,"M1burando_nm","M1jisya_hbn","M1hanbaikanryo_ymd","M1maker_hbn","M1syonmk"
	,"M1scan_cd","M1iro_nm","M1size_nm","M1genbaika_tnk","M1hyokason_su"
	,"M1gen_tnk","M1haibun_kin","M1nyuryoku_ymd","M1apply_ymd","M1nyuryokusha_cd"
	,"M1sinseisya_cd","M1hyokasonsyubetsu_kb","M1hyokasonriyu","M1kyakkariyu_kb","M1kyakkariyu"
	,"M1syonin_flg","M1kyakka_flg","M1selectorcheckbox","M1entersyoriflg","M1dtlirokbn"
	,"Gokei_suryo","Haibun_kin_gokei","Btnenter"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","処理月","店舗コードFROM"
	,"店舗コードFROMボタン","店舗名FROM","店舗コードTO","店舗コードTOボタン","店舗名TO"
	,"検索件数","検索ボタン","一括承認ボタン","一括却下ボタン","全解除ボタン"
	,"ページャ","Ｍ１行NO","Ｍ１店舗コード","Ｍ１部門コード","Ｍ１品種コード"
	,"Ｍ１ブランド名","Ｍ１自社品番","Ｍ１販売完了日","Ｍ１メーカー品番","Ｍ１商品名(カナ)"
	,"Ｍ１スキャンコード","Ｍ１色","Ｍ１サイズ","Ｍ１現売価","Ｍ１数量"
	,"Ｍ１原単価","Ｍ１原価金額","Ｍ１入力日","Ｍ１申請日","Ｍ１入力者コード"
	,"Ｍ１申請者コード","Ｍ１評価損種別区分","Ｍ１評価損理由","Ｍ１却下理由区分","Ｍ１却下理由"
	,"Ｍ１承認","Ｍ１却下","Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)"
	,"合計数量","原価金額合計","確定ボタン"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","SD","SG"
	,"B","SN4","SG","B","SN4"
	,"NA","B","B","B","B"
	,"B","NA","SG","SG","SG"
	,"SN9","SG","D","SN9","SN9"
	,"SG","SN9","SN9","NA","NA"
	,"NA","NA","NA","NA","SG"
	,"SG","SN4","SN4","SN5","SN4"
	,"NA","NA","NA","NA","NA"
	,"NA","NA","B"
);
var ADVIT_LENGTH = new Array(
	4,0,15,6,4
	,0,15,4,0,15
	,4,0,0,0,0
	,0,4,4,3,2
	,20,8,0,30,30
	,18,10,4,7,7
	,7,9,6,6,7
	,7,4,20,2,10
	,1,1,1,1,2
	,8,9,0
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
	,0,0,0
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","DRL","TXT"
	,"BTN","TXR","TXT","BTN","TXR"
	,"TXR","BTS","BTS","BTS","BTS"
	,"LNS","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","DRL","TXT"
	,"CHK","CHK","CHK","HDN","HDN"
	,"TXR","TXR","BTS"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","00","10"
	,"00","00","10","00","00"
	,"12","00","00","00","00"
	,"00","11","10","10","10"
	,"00","10","52","00","00"
	,"00","00","00","12","12"
	,"12","12","10","10","10"
	,"10","00","00","00","00"
	,"11","11","11","11","11"
	,"12","12","00"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"C_TENPO_CD","","","C_TENPO_CD",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","C_MEISYO_CD",""
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
	,"CANNOTGET","CANNOTGET","CANNOTGET"
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
	,"","",""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,1,0,0,0
	,1,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,1
);
var ADVIT_IMEMODE = new Array(
	3,0,0,0,3
	,0,0,3,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,1
	,0,0,0,0,0
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
	,0,0,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,0,1
	,0,0,1,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,1
	,0,0,0,0,0
	,0,0,0
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
	,"","",""
);
var ADVIT_ACTIONID = new Array(
	"","COD","","",""
	,"COD","","","COD",""
	,"","FRM","FRM","FRM","FRM"
	,"PGN","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","COD",""
	,"","","","",""
	,"","","FRM"
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","",""
	,"","","","",""
	,"","TK030F01","TK030F01","TK030F01","TK030F01"
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","TK030F01"
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","M1","M1","M1"
	,"M1","","","",""
	,"","","","",""
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
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","",""
);
var ADVIT_CAPTION = new Array(
	"店舗","","","処理月","店舗ＦＲＯＭ"
	,"","","店舗ＴＯ","",""
	,"","検索","","",""
	,"","No.","店舗","部門","品種"
	,"ブランド","自社品番","販完日","メーカー品番","商品名"
	,"スキャンコード","色","サイズ","現売価","数量"
	,"原単価","原価金額","入力日","申請日","入力者"
	,"申請者","種別","評価損理由","却下理由","却下理由"
	,"承認","却下","","",""
	,"合計","","確定"
);

