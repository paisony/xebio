var ADVIT_FORMID = "TE010F02";
var ADVIT_TARGETPGID = "te010p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "te010f02.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,21,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,38,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_BTNBACK = 0;
var ADVIT_ID_HEAD_TENPO_CD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_DENPYO_BANGO = 3;
var ADVIT_ID_SIJI_BANGO = 4;
var ADVIT_ID_SCM_CD = 5;
var ADVIT_ID_SHUKKARIYU_NM = 6;
var ADVIT_ID_SYUKKATAN_CD = 7;
var ADVIT_ID_SYUKKATAN_NM = 8;
var ADVIT_ID_SYUKKA_YMD = 9;
var ADVIT_ID_KAISYA_CD = 10;
var ADVIT_ID_KAISYA_NM = 11;
var ADVIT_ID_JYURYOTEN_CD = 12;
var ADVIT_ID_JURYOTEN_NM = 13;
var ADVIT_ID_NYUKATAN_CD = 14;
var ADVIT_ID_NYUKATAN_NM = 15;
var ADVIT_ID_JYURYO_YMD = 16;
var ADVIT_ID_SYORINM = 17;
var ADVIT_ID_SYORIYMD = 18;
var ADVIT_ID_SYORI_TM = 19;
var ADVIT_ID_PGR = 20;
var ADVIT_ID_M1ROWNO = 21;
var ADVIT_ID_M1BUMON_CD = 22;
var ADVIT_ID_M1BUMONKANA_NM = 23;
var ADVIT_ID_M1HINSYU_RYAKU_NM = 24;
var ADVIT_ID_M1BURANDO_NM = 25;
var ADVIT_ID_M1JISYA_HBN = 26;
var ADVIT_ID_M1MAKER_HBN = 27;
var ADVIT_ID_M1SYONMK = 28;
var ADVIT_ID_M1IRO_NM = 29;
var ADVIT_ID_M1SIZE_NM = 30;
var ADVIT_ID_M1SCAN_CD = 31;
var ADVIT_ID_M1SYUKKA_SU = 32;
var ADVIT_ID_M1KAKUTEI_SU = 33;
var ADVIT_ID_M1GEN_TNK = 34;
var ADVIT_ID_M1GENKAKIN = 35;
var ADVIT_ID_M1SELECTORCHECKBOX = 36;
var ADVIT_ID_M1ENTERSYORIFLG = 37;
var ADVIT_ID_M1DTLIROKBN = 38;
var ADVIT_ID_SYUKKASURYO_GOKEI = 39;
var ADVIT_ID_GOKEIKAKUTEI_SU = 40;
var ADVIT_ID_GENKA_KIN_GOKEI = 41;

var ADVIT_ID = new Array(
	"Btnback","Head_tenpo_cd","Head_tenpo_nm","Denpyo_bango","Siji_bango"
	,"Scm_cd","Shukkariyu_nm","Syukkatan_cd","Syukkatan_nm","Syukka_ymd"
	,"Kaisya_cd","Kaisya_nm","Jyuryoten_cd","Juryoten_nm","Nyukatan_cd"
	,"Nyukatan_nm","Jyuryo_ymd","Syorinm","Syoriymd","Syori_tm"
	,"Pgr","M1rowno","M1bumon_cd","M1bumonkana_nm","M1hinsyu_ryaku_nm"
	,"M1burando_nm","M1jisya_hbn","M1maker_hbn","M1syonmk","M1iro_nm"
	,"M1size_nm","M1scan_cd","M1syukka_su","M1kakutei_su","M1gen_tnk"
	,"M1genkakin","M1selectorcheckbox","M1entersyoriflg","M1dtlirokbn","Syukkasuryo_gokei"
	,"Gokeikakutei_su","Genka_kin_gokei"
);
var ADVIT_NAME = new Array(
	"戻るボタン","ヘッダ店舗コード","ヘッダ店舗名","伝票番号","指示番号"
	,"SCMコード","出荷理由名称","出荷担当者コード","出荷担当者名称","出荷日"
	,"会社コード","会社名称","入荷店コード","入荷店名称","入荷担当者コード"
	,"入荷担当者名称","入荷日","処理名称","処理日","処理時間"
	,"ページャ","Ｍ１行NO","Ｍ１部門コード","Ｍ１部門カナ名","Ｍ１品種略名称"
	,"Ｍ１ブランド名","Ｍ１自社品番","Ｍ１メーカー品番","Ｍ１商品名(カナ)","Ｍ１色"
	,"Ｍ１サイズ","Ｍ１スキャンコード","Ｍ１出荷数量（梱包単位）","Ｍ１確定数量","Ｍ１原単価"
	,"Ｍ１原価金額","Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)","出荷数量合計"
	,"合計確定数量","原価金額合計"
);
var ADVIT_ATTRIBUTE = new Array(
	"B","SG","SN4","NA","NA"
	,"SG","SN4","SG","SN4","D"
	,"SG","SN4","SG","SN4","SG"
	,"SN4","D","SN4","D","D"
	,"B","NA","SG","SN9","SN4"
	,"SN9","SG","SN9","SN9","SN9"
	,"SN9","SG","NA","NA","NA"
	,"NA","NA","NA","NA","NA"
	,"NA","NA"
);
var ADVIT_LENGTH = new Array(
	0,4,15,6,10
	,20,4,7,12,0
	,2,10,4,15,7
	,12,0,4,0,0
	,0,3,3,30,15
	,20,8,30,30,10
	,4,18,6,6,7
	,9,1,1,2,8
	,8,9
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
	"BTS","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"LNS","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","CHK","HDN","HDN","TXR"
	,"TXR","TXR"
);
var ADVIT_FORMAT = new Array(
	"00","10","00","10","10"
	,"00","00","10","00","52"
	,"10","00","10","00","10"
	,"00","52","00","52","56"
	,"00","11","10","00","00"
	,"00","10","00","00","00"
	,"00","00","12","12","12"
	,"12","11","11","11","12"
	,"12","12"
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
	,"","","","",""
	,"","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1",""
	,"",""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,1,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0
);
var ADVIT_IMEMODE = new Array(
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
	,0,0,0,0,0
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
	,"","","","",""
	,"PGN","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"",""
);
var ADVIT_ACTIONFORMID = new Array(
	"TE010F01","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"",""
);
var ADVIT_ACTPARAMETER = new Array(
	"M1","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"M1","","","",""
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
	"","","","伝票番号","指示番号"
	,"SCMコード","出荷理由","出荷担当者","","出荷日"
	,"会社","","入荷店","","入荷担当者"
	,"","入荷日","処理","処理日","処理時間"
	,"","No.","部門","","品種"
	,"ブランド","自社品番","メーカー品番","商品名","色"
	,"サイズ","スキャンコード","出荷数量","確定数量","原単価"
	,"原価金額","","","","合計"
	,"",""
);

