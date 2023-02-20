var ADVIT_FORMID = "TD020F01";
var ADVIT_TARGETPGID = "td020p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "td020f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,14,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,35,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_HENPIN_RIYU = 3;
var ADVIT_ID_SIJI_BANGO = 4;
var ADVIT_ID_SIIRESAKI_CD = 5;
var ADVIT_ID_BTNSIIRESAKI_CD = 6;
var ADVIT_ID_SIIRESAKI_RYAKU_NM = 7;
var ADVIT_ID_BIKO = 8;
var ADVIT_ID_BTNPAGEINS = 9;
var ADVIT_ID_BTNSIZSTK = 10;
var ADVIT_ID_BTNROWDEL = 11;
var ADVIT_ID_BTNCSV_TORIKOMI = 12;
var ADVIT_ID_PGR = 13;
var ADVIT_ID_M1ROWNO = 14;
var ADVIT_ID_M1TENPO_CD = 15;
var ADVIT_ID_M1BTNTENPOCD = 16;
var ADVIT_ID_M1TENPO_NM = 17;
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
var ADVIT_ID_M1ITEMSU = 28;
var ADVIT_ID_M1GEN_TNK = 29;
var ADVIT_ID_M1GENKAKIN = 30;
var ADVIT_ID_M1ITEMSU_HDN = 31;
var ADVIT_ID_M1GENKA_KIN_HDN = 32;
var ADVIT_ID_M1SELECTORCHECKBOX = 33;
var ADVIT_ID_M1ENTERSYORIFLG = 34;
var ADVIT_ID_M1DTLIROKBN = 35;
var ADVIT_ID_GOKEI_SURYO = 36;
var ADVIT_ID_GENKA_KIN_GOKEI = 37;
var ADVIT_ID_BTNENTER = 38;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Henpin_riyu","Siji_bango"
	,"Siiresaki_cd","Btnsiiresaki_cd","Siiresaki_ryaku_nm","Biko","Btnpageins"
	,"Btnsizstk","Btnrowdel","Btncsv_torikomi","Pgr","M1rowno"
	,"M1tenpo_cd","M1btntenpocd","M1tenpo_nm","M1bumon_cd","M1bumonkana_nm"
	,"M1hinsyu_ryaku_nm","M1burando_nm","M1jisya_hbn","M1maker_hbn","M1syonmk"
	,"M1iro_nm","M1size_nm","M1scan_cd","M1itemsu","M1gen_tnk"
	,"M1genkakin","M1itemsu_hdn","M1genka_kin_hdn","M1selectorcheckbox","M1entersyoriflg"
	,"M1dtlirokbn","Gokei_suryo","Genka_kin_gokei","Btnenter"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","返品理由","指示番号"
	,"仕入先コード","仕入先コードボタン","仕入先略式名称","備考","ページ追加ボタン"
	,"サイズ選択ボタン","行削除ボタン","CSV取込ボタン","ページャ","Ｍ１行NO"
	,"Ｍ１店舗コード","Ｍ１店舗コードボタン","Ｍ１店舗名","Ｍ１部門コード","Ｍ１部門カナ名"
	,"Ｍ１品種略名称","Ｍ１ブランド名","Ｍ１自社品番","Ｍ１メーカー品番","Ｍ１商品名(カナ)"
	,"Ｍ１色","Ｍ１サイズ","Ｍ１スキャンコード","Ｍ１数量","Ｍ１原単価"
	,"Ｍ１原価金額","Ｍ１数量（隠し）","Ｍ１原価金額（隠し）","Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)"
	,"Ｍ１明細色区分(隠し)","合計数量","原価金額合計","確定ボタン"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","SN5","SG"
	,"SG","B","SN4","SN22","B"
	,"B","B","B","B","NA"
	,"SG","B","SN4","SG","SN9"
	,"SN4","SN9","SG","SN9","SN9"
	,"SN9","SN9","SG","NA","NA"
	,"NA","NA","NA","NA","NA"
	,"NA","NA","NA","B"
);
var ADVIT_LENGTH = new Array(
	4,0,15,1,24
	,4,0,20,60,0
	,0,0,0,0,4
	,4,0,15,3,30
	,15,20,8,30,30
	,10,4,18,7,7
	,9,7,9,1,1
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
	,0,0,0,1,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","DRL","TXT"
	,"TXT","BTN","TXR","TXT","BTS"
	,"BTS","BTS","BTS","LNS","TXR"
	,"TXT","BTN","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXT","TXT","TXR"
	,"TXR","HDN","HDN","CHK","HDN"
	,"HDN","TXR","TXR","BTS"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","00","00"
	,"10","00","00","00","00"
	,"00","00","00","00","11"
	,"10","00","00","10","00"
	,"00","00","10","00","00"
	,"00","00","00","12","12"
	,"12","11","11","11","11"
	,"11","12","12","00"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"","C_SIIRESAKI_CD","","",""
	,"","","","",""
	,"","C_TENPO_CD","","",""
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
	,"","","","","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","","",""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,1,1,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,1
);
var ADVIT_IMEMODE = new Array(
	3,0,0,0,3
	,3,0,0,1,0
	,0,0,0,0,0
	,3,0,0,0,0
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
	,1,0,0,0,0
	,0,0,0,0,0
	,0,0,1,1,0
	,0,0,0,0,0
	,0,0,0,0
);
var ADVIT_CONDID = new Array(
	"","","","HENPIN_RIYU_KBN",""
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
	,"","COD","","","MINSX"
	,"FRM","FRM","FRM","PGN",""
	,"","COD","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","FRM"
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","",""
	,"","","","",""
	,"TD020F01","TD020F01","TD020F01","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","TD020F01"
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","","M1"
	,"","","","M1",""
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
	,"","","",""
);
var ADVIT_CAPTION = new Array(
	"店舗","","","返品理由","指示番号"
	,"仕入先","","","備考",""
	,"","","","","No."
	,"店舗","","","部門",""
	,"品種","ブランド","自社品番","メーカー品番","商品名"
	,"色","サイズ","スキャンコード","数量","原単価"
	,"原価金額","","","",""
	,"","合計","","確定"
);

