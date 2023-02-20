var ADVIT_FORMID = "TK010F01";
var ADVIT_TARGETPGID = "tk010p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tk010f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,25,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,40,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_BTNMODEKAKUTEI = 3;
var ADVIT_ID_BTNMODEUPD = 4;
var ADVIT_ID_BTNMODEREF = 5;
var ADVIT_ID_MODENO = 6;
var ADVIT_ID_STKMODENO = 7;
var ADVIT_ID_HYOKASONSYUBETSU_KB = 8;
var ADVIT_ID_SYONIN_FLG = 9;
var ADVIT_ID_KESSAI_FLG = 10;
var ADVIT_ID_SINSEI_KB = 11;
var ADVIT_ID_TENPO_CD_FROM = 12;
var ADVIT_ID_BTNTENPOCD_FROM = 13;
var ADVIT_ID_TENPO_NM_FROM = 14;
var ADVIT_ID_TENPO_CD_TO = 15;
var ADVIT_ID_BTNTENPOCD_TO = 16;
var ADVIT_ID_TENPO_NM_TO = 17;
var ADVIT_ID_SYORI_YM = 18;
var ADVIT_ID_SEARCHCNT = 19;
var ADVIT_ID_BTNSEARCH = 20;
var ADVIT_ID_BTNZENSTK = 21;
var ADVIT_ID_BTNZENKJO = 22;
var ADVIT_ID_BTNPRINT = 23;
var ADVIT_ID_PGR = 24;
var ADVIT_ID_M1ROWNO = 25;
var ADVIT_ID_M1TENPO_CD = 26;
var ADVIT_ID_M1TENPO_NM = 27;
var ADVIT_ID_M1APPLY_YMD = 28;
var ADVIT_ID_M1SINSEI_KB_NM = 29;
var ADVIT_ID_M1SYONIN_FLG_NM = 30;
var ADVIT_ID_M1KESSAI_FLG_NM = 31;
var ADVIT_ID_M1NOTNB_SURYO = 32;
var ADVIT_ID_M1NOTNB_GENKA_KIN = 33;
var ADVIT_ID_M1NB_SURYO = 34;
var ADVIT_ID_M1NB_GENKA_KIN = 35;
var ADVIT_ID_M1TENPOGOKEI_SU = 36;
var ADVIT_ID_M1TENPOGOKEI_GENKA_KIN = 37;
var ADVIT_ID_M1SELECTORCHECKBOX = 38;
var ADVIT_ID_M1ENTERSYORIFLG = 39;
var ADVIT_ID_M1DTLIROKBN = 40;
var ADVIT_ID_GOKEI_SURYO = 41;
var ADVIT_ID_GENKA_KIN_GOKEI = 42;
var ADVIT_ID_BTNENTER = 43;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Btnmodekakutei","Btnmodeupd"
	,"Btnmoderef","Modeno","Stkmodeno","Hyokasonsyubetsu_kb","Syonin_flg"
	,"Kessai_flg","Sinsei_kb","Tenpo_cd_from","Btntenpocd_from","Tenpo_nm_from"
	,"Tenpo_cd_to","Btntenpocd_to","Tenpo_nm_to","Syori_ym","Searchcnt"
	,"Btnsearch","Btnzenstk","Btnzenkjo","Btnprint","Pgr"
	,"M1rowno","M1tenpo_cd","M1tenpo_nm","M1apply_ymd","M1sinsei_kb_nm"
	,"M1syonin_flg_nm","M1kessai_flg_nm","M1notnb_suryo","M1notnb_genka_kin","M1nb_suryo"
	,"M1nb_genka_kin","M1tenpogokei_su","M1tenpogokei_genka_kin","M1selectorcheckbox","M1entersyoriflg"
	,"M1dtlirokbn","Gokei_suryo","Genka_kin_gokei","Btnenter"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","モード確定ボタン","モード修正ボタン"
	,"モード照会ボタン","モードNO","選択モードNO","評価損種別区分","承認状態"
	,"決裁状態","申請区分","店舗コードFROM","店舗コードFROMボタン","店舗名FROM"
	,"店舗コードTO","店舗コードTOボタン","店舗名TO","処理月","検索件数"
	,"検索ボタン","全選択ボタン","全解除ボタン","印刷ボタン","ページャ"
	,"Ｍ１行NO","Ｍ１店舗リンク","Ｍ１店舗名リンク","Ｍ１申請日","Ｍ１申請区分名称"
	,"Ｍ１承認状態名称","Ｍ１決裁状態名称","Ｍ１ＮＢ以外数量","Ｍ１ＮＢ以外原価金額","Ｍ１ＮＢ数量"
	,"Ｍ１ＮＢ原価金額","Ｍ１店舗合計数量","Ｍ１店舗合計原価金額","Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)"
	,"Ｍ１明細色区分(隠し)","合計数量","原価金額合計","確定ボタン"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","B","B"
	,"B","NA","NA","SN5","SN5"
	,"SN5","SN5","SG","B","SN4"
	,"SG","B","SN4","SD","NA"
	,"B","B","B","B","B"
	,"NA","B","B","D","SN4"
	,"SN4","SN4","NA","NA","NA"
	,"NA","NA","NA","NA","NA"
	,"NA","NA","NA","B"
);
var ADVIT_LENGTH = new Array(
	4,0,15,0,0
	,0,2,2,2,1
	,1,1,4,0,15
	,4,0,15,6,4
	,0,0,0,0,0
	,4,0,0,0,3
	,2,3,8,9,8
	,9,8,9,1,1
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
	,"LNK","HDN","HDN","DRL","DRL"
	,"DRL","DRL","TXT","BTN","TXR"
	,"TXT","BTN","TXR","DRL","TXT"
	,"BTS","BTS","BTS","BTS","LNS"
	,"TXR","BTS","BTS","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","CHK","HDN"
	,"HDN","TXR","TXR","BTS"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","00","00"
	,"00","11","11","00","00"
	,"00","00","10","00","00"
	,"10","00","00","00","11"
	,"00","00","00","00","00"
	,"11","00","00","52","00"
	,"00","00","12","12","12"
	,"12","12","12","11","11"
	,"11","12","12","00"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"","","","C_MEISYO_CD",""
	,"","","","C_TENPO_CD",""
	,"","C_TENPO_CD","","",""
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
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","","",""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,1,0,0,1,1
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,1
);
var ADVIT_IMEMODE = new Array(
	3,0,0,0,0
	,0,0,0,0,0
	,0,0,3,0,0
	,3,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
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
	,0,0,0,0,0
	,0,0,1,0,0
	,1,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0
);
var ADVIT_CONDID = new Array(
	"","","","",""
	,"","","","","SYONIN_JOTAI2"
	,"KESSAI_JOTAI","SINSEI_KBN","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","",""
);
var ADVIT_ACTIONID = new Array(
	"","COD","","SPT","SPT"
	,"SPT","","","COD",""
	,"","","","COD",""
	,"","COD","","",""
	,"FRM","FRM","FRM","FRM","PGN"
	,"","FRM","FRM","",""
	,"","","","",""
	,"","","","",""
	,"","","","DBU"
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","TK010F01","TK010F01"
	,"TK010F01","","","",""
	,"","","","",""
	,"","","","",""
	,"TK010F01","TK010F01","TK010F01","TK010F01",""
	,"","TK010F02","TK010F02","",""
	,"","","","",""
	,"","","","",""
	,"","","","TK010F01"
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","M1","M1","","M1"
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
	,"","","",""
);
var ADVIT_CAPTION = new Array(
	"店舗","","","確定","修正"
	,"照会","","","評価損種別","承認状態"
	,"決裁状態","申請区分","店舗ＦＲＯＭ","",""
	,"店舗ＴＯ","","","処理月",""
	,"検索","","","",""
	,"No.","店舗","","申請日","再申請"
	,"承認","決裁","数量","原価金額","数量"
	,"原価金額","数量","原価金額","",""
	,"","合計","","確定"
);

