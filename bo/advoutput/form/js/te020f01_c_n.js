var ADVIT_FORMID = "TE020F01";
var ADVIT_TARGETPGID = "te020p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "te020f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,17,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,35,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_SHUKKARIYU_KBN = 3;
var ADVIT_ID_SIJI_BANGO = 4;
var ADVIT_ID_KAISYA_CD = 5;
var ADVIT_ID_BTNKAISHA_CD = 6;
var ADVIT_ID_KAISYA_NM = 7;
var ADVIT_ID_JYURYOTEN_CD = 8;
var ADVIT_ID_BTNTENPOCD = 9;
var ADVIT_ID_JURYOTEN_NM = 10;
var ADVIT_ID_SYUKKA_YMD = 11;
var ADVIT_ID_BTNPAGEINS = 12;
var ADVIT_ID_BTNSIZSTK = 13;
var ADVIT_ID_BTNROWDEL = 14;
var ADVIT_ID_BTNCSV_TORIKOMI = 15;
var ADVIT_ID_PGR = 16;
var ADVIT_ID_M1ROWNO = 17;
var ADVIT_ID_M1BUMON_CD = 18;
var ADVIT_ID_M1BUMONKANA_NM = 19;
var ADVIT_ID_M1HINSYU_RYAKU_NM = 20;
var ADVIT_ID_M1BURANDO_NM = 21;
var ADVIT_ID_M1JISYA_HBN = 22;
var ADVIT_ID_M1MAKER_HBN = 23;
var ADVIT_ID_M1SYONMK = 24;
var ADVIT_ID_M1IRO_NM = 25;
var ADVIT_ID_M1SIZE_NM = 26;
var ADVIT_ID_M1SCAN_CD = 27;
var ADVIT_ID_M1SYUKKA_SU = 28;
var ADVIT_ID_M1GEN_TNK = 29;
var ADVIT_ID_M1GENKA_KIN = 30;
var ADVIT_ID_M1SYUKKA_SU_HDN = 31;
var ADVIT_ID_M1GENKA_KIN_HDN = 32;
var ADVIT_ID_M1SELECTORCHECKBOX = 33;
var ADVIT_ID_M1ENTERSYORIFLG = 34;
var ADVIT_ID_M1DTLIROKBN = 35;
var ADVIT_ID_SYUKKASURYO_GOKEI = 36;
var ADVIT_ID_GENKA_KIN_GOKEI = 37;
var ADVIT_ID_BTNENTER = 38;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Shukkariyu_kbn","Siji_bango"
	,"Kaisya_cd","Btnkaisha_cd","Kaisya_nm","Jyuryoten_cd","Btntenpocd"
	,"Juryoten_nm","Syukka_ymd","Btnpageins","Btnsizstk","Btnrowdel"
	,"Btncsv_torikomi","Pgr","M1rowno","M1bumon_cd","M1bumonkana_nm"
	,"M1hinsyu_ryaku_nm","M1burando_nm","M1jisya_hbn","M1maker_hbn","M1syonmk"
	,"M1iro_nm","M1size_nm","M1scan_cd","M1syukka_su","M1gen_tnk"
	,"M1genka_kin","M1syukka_su_hdn","M1genka_kin_hdn","M1selectorcheckbox","M1entersyoriflg"
	,"M1dtlirokbn","Syukkasuryo_gokei","Genka_kin_gokei","Btnenter"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","出荷理由","指示番号"
	,"会社コード","会社コードボタン","会社名称","入荷店コード","店舗コードボタン"
	,"入荷店名称","出荷日","ページ追加ボタン","サイズ選択ボタン","行削除ボタン"
	,"CSV取込ボタン","ページャ","Ｍ１行NO","Ｍ１部門コード","Ｍ１部門カナ名"
	,"Ｍ１品種略名称","Ｍ１ブランド名","Ｍ１自社品番","Ｍ１メーカー品番","Ｍ１商品名(カナ)"
	,"Ｍ１色","Ｍ１サイズ","Ｍ１スキャンコード","Ｍ１出荷数量","Ｍ１原単価"
	,"Ｍ１原価金額","Ｍ１出荷数量(隠し)","Ｍ１原価金額(隠し)","Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)"
	,"Ｍ１明細色区分(隠し)","出荷数量合計","原価金額合計","確定ボタン"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","SN5","SG"
	,"SG","B","SN4","SG","B"
	,"SN4","D","B","B","B"
	,"B","B","NA","SG","SN9"
	,"SN4","SN9","SG","SN9","SN9"
	,"SN9","SN9","SG","NA","NA"
	,"NA","NA","NA","NA","NA"
	,"NA","NA","NA","B"
);
var ADVIT_LENGTH = new Array(
	4,0,15,1,24
	,2,0,10,4,0
	,15,0,0,0,0
	,0,0,4,3,30
	,15,20,8,30,30
	,10,4,18,6,7
	,9,6,9,1,1
	,2,9,9,0
);
var ADVIT_AUTOTAB = new Array(
	0,0,0,0,0
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
	,0,0,0,0
);
var ADVIT_REQUIREDFLG = new Array(
	1,0,0,0,0
	,1,0,0,1,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","DRL","TXT"
	,"TXT","BTN","TXR","TXT","BTN"
	,"TXR","TXR","BTS","BTS","BTS"
	,"BTS","LNS","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXT","TXT","TXR"
	,"TXR","HDN","HDN","CHK","HDN"
	,"HDN","TXR","TXR","BTS"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","00","00"
	,"10","00","00","10","00"
	,"00","52","00","00","00"
	,"00","00","11","10","00"
	,"00","00","10","00","00"
	,"00","00","00","12","12"
	,"12","12","12","11","11"
	,"11","12","12","00"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"","C_MEISYO_CD","","","C_TENPO_ALL_CD"
	,"","","","",""
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
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","","",""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,1,0
	,1,1,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,1
);
var ADVIT_IMEMODE = new Array(
	3,0,0,0,3
	,3,0,0,3,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,3,3,0
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
	,0,0,0,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,0,1
	,1,0,0,1,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,1,1,0
	,0,0,0,0,0
	,0,0,0,0
);
var ADVIT_CONDID = new Array(
	"","","","SHUKKARIYU_KBN",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","",""
);
var ADVIT_ACTIONID = new Array(
	"","COD","","",""
	,"","COD","","","COD"
	,"","","MINSX","FRM","FRM"
	,"FRM","PGN","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","FRM"
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","TE020F01","TE020F01"
	,"TE020F01","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","TE020F01"
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","M1","",""
	,"","M1","","",""
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
	,"","","",""
);
var ADVIT_CAPTION = new Array(
	"店舗","","","出荷理由","指示番号"
	,"会社","","","入荷店",""
	,"","出荷日","","",""
	,"","","No.","部門",""
	,"品種","ブランド","自社品番","メーカー品番","商品名"
	,"色","サイズ","スキャンコード","出荷数量","原単価"
	,"原価金額","","","",""
	,"","","","確定"
);

