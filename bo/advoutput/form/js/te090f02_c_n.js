var ADVIT_FORMID = "TE090F02";
var ADVIT_TARGETPGID = "te090p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "te090f02.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,18,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,37,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_BTNBACK = 0;
var ADVIT_ID_HEAD_TENPO_CD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_STKMODENO = 3;
var ADVIT_ID_DENPYO_BANGO = 4;
var ADVIT_ID_SCM_CD = 5;
var ADVIT_ID_NYUKATAN_CD = 6;
var ADVIT_ID_NYUKATAN_NM = 7;
var ADVIT_ID_JYURYO_YMD = 8;
var ADVIT_ID_KAISYA_CD = 9;
var ADVIT_ID_KAISYA_NM = 10;
var ADVIT_ID_SYUKKATEN_CD = 11;
var ADVIT_ID_SYUKKATEN_NM = 12;
var ADVIT_ID_SYUKKATAN_CD = 13;
var ADVIT_ID_SYUKKATAN_NM = 14;
var ADVIT_ID_SYUKKA_YMD = 15;
var ADVIT_ID_DENPYO_JYOTAINM = 16;
var ADVIT_ID_PGR = 17;
var ADVIT_ID_M1ROWNO = 18;
var ADVIT_ID_M1BUMON_CD = 19;
var ADVIT_ID_M1BUMONKANA_NM = 20;
var ADVIT_ID_M1HINSYU_RYAKU_NM = 21;
var ADVIT_ID_M1BURANDO_NM = 22;
var ADVIT_ID_M1JISYA_HBN = 23;
var ADVIT_ID_M1MAKER_HBN = 24;
var ADVIT_ID_M1SYONMK = 25;
var ADVIT_ID_M1IRO_NM = 26;
var ADVIT_ID_M1SIZE_NM = 27;
var ADVIT_ID_M1SCAN_CD = 28;
var ADVIT_ID_M1YOTEI_SU = 29;
var ADVIT_ID_M1KAKUTEI_SU = 30;
var ADVIT_ID_M1GEN_TNK = 31;
var ADVIT_ID_M1GENKA_KIN = 32;
var ADVIT_ID_M1KAKUTEI_SU_HDN = 33;
var ADVIT_ID_M1GENKAKIN_HDN = 34;
var ADVIT_ID_M1SELECTORCHECKBOX = 35;
var ADVIT_ID_M1ENTERSYORIFLG = 36;
var ADVIT_ID_M1DTLIROKBN = 37;
var ADVIT_ID_GOKEIYOTEI_SU = 38;
var ADVIT_ID_GOKEIKAKUTEI_SU = 39;
var ADVIT_ID_GENKA_KIN_GOKEI = 40;
var ADVIT_ID_BTNENTER = 41;

var ADVIT_ID = new Array(
	"Btnback","Head_tenpo_cd","Head_tenpo_nm","Stkmodeno","Denpyo_bango"
	,"Scm_cd","Nyukatan_cd","Nyukatan_nm","Jyuryo_ymd","Kaisya_cd"
	,"Kaisya_nm","Syukkaten_cd","Syukkaten_nm","Syukkatan_cd","Syukkatan_nm"
	,"Syukka_ymd","Denpyo_jyotainm","Pgr","M1rowno","M1bumon_cd"
	,"M1bumonkana_nm","M1hinsyu_ryaku_nm","M1burando_nm","M1jisya_hbn","M1maker_hbn"
	,"M1syonmk","M1iro_nm","M1size_nm","M1scan_cd","M1yotei_su"
	,"M1kakutei_su","M1gen_tnk","M1genka_kin","M1kakutei_su_hdn","M1genkakin_hdn"
	,"M1selectorcheckbox","M1entersyoriflg","M1dtlirokbn","Gokeiyotei_su","Gokeikakutei_su"
	,"Genka_kin_gokei","Btnenter"
);
var ADVIT_NAME = new Array(
	"戻るボタン","ヘッダ店舗コード","ヘッダ店舗名","選択モードNO","伝票番号"
	,"SCMコード","入荷担当者コード","入荷担当者名称","入荷日","会社コード"
	,"会社名称","出荷店コード","出荷店名称","出荷担当者コード","出荷担当者名称"
	,"出荷日","伝票状態名称","ページャ","Ｍ１行NO","Ｍ１部門コード"
	,"Ｍ１部門カナ名","Ｍ１品種略名称","Ｍ１ブランド名","Ｍ１自社品番","Ｍ１メーカー品番"
	,"Ｍ１商品名(カナ)","Ｍ１色","Ｍ１サイズ","Ｍ１スキャンコード","Ｍ１予定数量"
	,"Ｍ１確定数量","Ｍ１原単価","Ｍ１原価金額","Ｍ１確定数量(隠し)","Ｍ１原価金額(隠し)"
	,"Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)","合計予定数量","合計確定数量"
	,"原価金額合計","確定ボタン"
);
var ADVIT_ATTRIBUTE = new Array(
	"B","SG","SN4","NA","NA"
	,"SG","SG","SN4","D","SG"
	,"SN4","SG","SN4","SG","SN4"
	,"D","SN4","B","NA","SG"
	,"SN4","SN4","SN9","SG","SN9"
	,"SN9","SN9","SN9","SG","NA"
	,"NA","NA","NA","NA","NA"
	,"NA","NA","NA","NA","NA"
	,"NA","B"
);
var ADVIT_LENGTH = new Array(
	0,4,15,2,6
	,20,7,12,0,2
	,10,4,15,7,12
	,0,20,0,3,3
	,30,15,20,8,30
	,30,10,4,18,6
	,6,7,9,6,9
	,1,1,2,8,8
	,9,0
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
	,0,0,0,0,0
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
	,"TXR","TXR","LNS","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXT","TXR","TXR","HDN","HDN"
	,"CHK","HDN","HDN","TXR","TXR"
	,"TXR","BTS"
);
var ADVIT_FORMAT = new Array(
	"00","10","00","11","10"
	,"00","10","00","52","10"
	,"00","10","00","10","00"
	,"52","00","00","11","10"
	,"00","00","00","10","00"
	,"00","00","00","00","12"
	,"12","12","12","12","12"
	,"11","11","11","12","12"
	,"12","00"
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
	,"","","","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","",""
	,"",""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,1,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,1
);
var ADVIT_IMEMODE = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,3,0,0,0,0
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
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,1,0,0,0,0
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
	,"","","","",""
	,"","","","",""
	,"",""
);
var ADVIT_ACTIONID = new Array(
	"FRM","","","",""
	,"","","","",""
	,"","","","",""
	,"","","PGN","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","FRM"
);
var ADVIT_ACTIONFORMID = new Array(
	"TE090F01","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","TE090F01"
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","M1","",""
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
	"","","","","伝票番号"
	,"SCMコード","入荷担当者","","入荷日","会社"
	,"","出荷店","","出荷担当者",""
	,"出荷日","伝票状態","","No.","部門"
	,"","品種","ブランド","自社品番","メーカー品番"
	,"商品名","色","サイズ","スキャンコード","予定数量"
	,"確定数量","原単価","原価金額","",""
	,"","","","合計",""
	,"","確定"
);

