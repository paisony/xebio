var ADVIT_FORMID = "TD030F02";
var ADVIT_TARGETPGID = "td030p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "td030f02.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,24,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,37,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_BTNBACK = 0;
var ADVIT_ID_HEAD_TENPO_CD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_KANRI_NO = 3;
var ADVIT_ID_DENPYO_BANGO = 4;
var ADVIT_ID_NYURYOKUTAN_CD = 5;
var ADVIT_ID_NYURYOKUTAN_NM = 6;
var ADVIT_ID_KAKUTEITAN_CD = 7;
var ADVIT_ID_KAKUTEITAN_NM = 8;
var ADVIT_ID_HENPIN_RIYU_NM = 9;
var ADVIT_ID_SIIRESAKI_CD = 10;
var ADVIT_ID_SIIRESAKI_RYAKU_NM = 11;
var ADVIT_ID_BUMON_CD = 12;
var ADVIT_ID_BUMON_NM = 13;
var ADVIT_ID_BURANDO_CD = 14;
var ADVIT_ID_BURANDO_NM = 15;
var ADVIT_ID_SIJI_BANGO = 16;
var ADVIT_ID_HENPIN_KAKUTEI_YMD = 17;
var ADVIT_ID_ADD_YMD = 18;
var ADVIT_ID_DENPYO_JYOTAINM = 19;
var ADVIT_ID_MOTODENPYO_BANGO = 20;
var ADVIT_ID_SYORINM = 21;
var ADVIT_ID_SYORIYMD = 22;
var ADVIT_ID_SYORI_TM = 23;
var ADVIT_ID_M1ROWNO = 24;
var ADVIT_ID_M1HINSYU_RYAKU_NM = 25;
var ADVIT_ID_M1JISYA_HBN = 26;
var ADVIT_ID_M1MAKER_HBN = 27;
var ADVIT_ID_M1SYONMK = 28;
var ADVIT_ID_M1IRO_NM = 29;
var ADVIT_ID_M1SIZE_NM = 30;
var ADVIT_ID_M1SCAN_CD = 31;
var ADVIT_ID_M1ITEMSU = 32;
var ADVIT_ID_M1GEN_TNK = 33;
var ADVIT_ID_M1GENKAKIN = 34;
var ADVIT_ID_M1SELECTORCHECKBOX = 35;
var ADVIT_ID_M1ENTERSYORIFLG = 36;
var ADVIT_ID_M1DTLIROKBN = 37;
var ADVIT_ID_GOKEI_SURYO = 38;
var ADVIT_ID_GENKA_KIN_GOKEI = 39;

var ADVIT_ID = new Array(
	"Btnback","Head_tenpo_cd","Head_tenpo_nm","Kanri_no","Denpyo_bango"
	,"Nyuryokutan_cd","Nyuryokutan_nm","Kakuteitan_cd","Kakuteitan_nm","Henpin_riyu_nm"
	,"Siiresaki_cd","Siiresaki_ryaku_nm","Bumon_cd","Bumon_nm","Burando_cd"
	,"Burando_nm","Siji_bango","Henpin_kakutei_ymd","Add_ymd","Denpyo_jyotainm"
	,"Motodenpyo_bango","Syorinm","Syoriymd","Syori_tm","M1rowno"
	,"M1hinsyu_ryaku_nm","M1jisya_hbn","M1maker_hbn","M1syonmk","M1iro_nm"
	,"M1size_nm","M1scan_cd","M1itemsu","M1gen_tnk","M1genkakin"
	,"M1selectorcheckbox","M1entersyoriflg","M1dtlirokbn","Gokei_suryo","Genka_kin_gokei"
);
var ADVIT_NAME = new Array(
	"戻るボタン","ヘッダ店舗コード","ヘッダ店舗名","管理No","伝票番号"
	,"入力担当者コード","入力担当者名称","確定担当者コード","確定担当者名称","返品理由名称"
	,"仕入先コード","仕入先略式名称","部門コード","部門名","ブランドコード"
	,"ブランド名","指示番号","返品確定日","登録日","伝票状態名称"
	,"元伝票番号","処理名称","処理日","処理時間","Ｍ１行NO"
	,"Ｍ１品種略名称","Ｍ１自社品番","Ｍ１メーカー品番","Ｍ１商品名(カナ)","Ｍ１色"
	,"Ｍ１サイズ","Ｍ１スキャンコード","Ｍ１数量","Ｍ１原単価","Ｍ１原価金額"
	,"Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)","合計数量","原価金額合計"
);
var ADVIT_ATTRIBUTE = new Array(
	"B","SG","SN4","NA","NA"
	,"SG","SN4","SG","SN4","SN4"
	,"SG","SN4","SG","SN4","SG"
	,"SN9","NA","D","D","SN4"
	,"NA","SN4","D","D","NA"
	,"SN4","NA","SN9","SN9","SN9"
	,"SN9","SG","NA","NA","NA"
	,"NA","NA","NA","NA","NA"
);
var ADVIT_LENGTH = new Array(
	0,4,15,6,6
	,7,12,7,12,4
	,4,20,3,15,6
	,20,10,0,0,7
	,6,4,0,0,2
	,15,8,30,30,10
	,4,18,7,7,9
	,1,1,2,9,9
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
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
);
var ADVIT_TYPE = new Array(
	"BTS","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"CHK","HDN","HDN","TXR","TXR"
);
var ADVIT_FORMAT = new Array(
	"00","10","00","10","10"
	,"10","00","10","00","00"
	,"10","00","10","00","10"
	,"00","10","52","52","00"
	,"10","00","52","56","11"
	,"00","10","00","00","00"
	,"00","00","12","12","12"
	,"11","11","11","12","12"
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
	,"","","","","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","",""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
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
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
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
	"FRM","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
);
var ADVIT_ACTIONFORMID = new Array(
	"TD030F01","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
);
var ADVIT_ACTPARAMETER = new Array(
	"M1","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
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
);
var ADVIT_CAPTION = new Array(
	"","","","管理番号","伝票番号"
	,"入力担当者","","確定担当者","","返品理由"
	,"仕入先","","部門","","ブランド"
	,"","指示番号","返品確定日","登録日","伝票状態"
	,"元伝票番号","処理","処理日","処理時間","No."
	,"品種","自社品番","メーカー品番","商品名","色"
	,"サイズ","スキャンコード","数量","原単価","原価金額"
	,"","","","",""
);

