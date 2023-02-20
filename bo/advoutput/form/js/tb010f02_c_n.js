var ADVIT_FORMID = "TB010F02";
var ADVIT_TARGETPGID = "tb010p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tb010f02.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,17,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,34,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_BTNBACK = 0;
var ADVIT_ID_HEAD_TENPO_CD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_DENPYO_BANGO = 3;
var ADVIT_ID_MOTODENPYO_BANGO = 4;
var ADVIT_ID_SIIRESAKI_CD = 5;
var ADVIT_ID_SIIRESAKI_RYAKU_NM = 6;
var ADVIT_ID_BUMON_CD = 7;
var ADVIT_ID_BUMON_NM = 8;
var ADVIT_ID_TANTOSYA_CD = 9;
var ADVIT_ID_HANBAIIN_NM = 10;
var ADVIT_ID_NYUKAYOTEI_YMD = 11;
var ADVIT_ID_SIIRE_KAKUTEI_YMD = 12;
var ADVIT_ID_DENPYO_JYOTAINM = 13;
var ADVIT_ID_SYORINM = 14;
var ADVIT_ID_SYORIYMD = 15;
var ADVIT_ID_SYORI_TM = 16;
var ADVIT_ID_M1ROWNO = 17;
var ADVIT_ID_M1HINSYU_RYAKU_NM = 18;
var ADVIT_ID_M1BURANDO_NM = 19;
var ADVIT_ID_M1JISYA_HBN = 20;
var ADVIT_ID_M1MAKER_HBN = 21;
var ADVIT_ID_M1SYONMK = 22;
var ADVIT_ID_M1IRO_NM = 23;
var ADVIT_ID_M1SIZE_NM = 24;
var ADVIT_ID_M1SCAN_CD = 25;
var ADVIT_ID_M1NOHIN_SU = 26;
var ADVIT_ID_M1KENSU = 27;
var ADVIT_ID_M1GEN_TNK = 28;
var ADVIT_ID_M1GENKA_KIN = 29;
var ADVIT_ID_M1KYAKUCYU = 30;
var ADVIT_ID_M1NEGAKI = 31;
var ADVIT_ID_M1SELECTORCHECKBOX = 32;
var ADVIT_ID_M1ENTERSYORIFLG = 33;
var ADVIT_ID_M1DTLIROKBN = 34;
var ADVIT_ID_GOKEI_NOHIN_SU = 35;
var ADVIT_ID_GOKEI_KENSU = 36;
var ADVIT_ID_GENKA_KIN_GOKEI = 37;

var ADVIT_ID = new Array(
	"Btnback","Head_tenpo_cd","Head_tenpo_nm","Denpyo_bango","Motodenpyo_bango"
	,"Siiresaki_cd","Siiresaki_ryaku_nm","Bumon_cd","Bumon_nm","Tantosya_cd"
	,"Hanbaiin_nm","Nyukayotei_ymd","Siire_kakutei_ymd","Denpyo_jyotainm","Syorinm"
	,"Syoriymd","Syori_tm","M1rowno","M1hinsyu_ryaku_nm","M1burando_nm"
	,"M1jisya_hbn","M1maker_hbn","M1syonmk","M1iro_nm","M1size_nm"
	,"M1scan_cd","M1nohin_su","M1kensu","M1gen_tnk","M1genka_kin"
	,"M1kyakucyu","M1negaki","M1selectorcheckbox","M1entersyoriflg","M1dtlirokbn"
	,"Gokei_nohin_su","Gokei_kensu","Genka_kin_gokei"
);
var ADVIT_NAME = new Array(
	"戻るボタン","ヘッダ店舗コード","ヘッダ店舗名","伝票番号","元伝票番号"
	,"仕入先コード","仕入先略式名称","部門コード","部門名","担当者コード"
	,"担当者名","入荷予定日","仕入確定日","伝票状態名称","処理名称"
	,"処理日","処理時間","Ｍ１行NO","Ｍ１品種略名称","Ｍ１ブランド名"
	,"Ｍ１自社品番","Ｍ１メーカー品番","Ｍ１商品名(カナ)","Ｍ１色","Ｍ１サイズ"
	,"Ｍ１スキャンコード","Ｍ１納品数","Ｍ１検数","Ｍ１原単価","Ｍ１原価金額"
	,"Ｍ１客注","Ｍ１値書","Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)"
	,"合計納品数","合計検数","原価金額合計"
);
var ADVIT_ATTRIBUTE = new Array(
	"B","SG","SN4","NA","NA"
	,"SG","SN4","SG","SN4","SG"
	,"SN4","D","D","SN4","SN4"
	,"D","D","NA","SN4","SN9"
	,"SG","SN9","SN9","SN9","SN9"
	,"SG","NA","NA","NA","NA"
	,"SN4","SN4","NA","NA","NA"
	,"NA","NA","NA"
);
var ADVIT_LENGTH = new Array(
	0,4,15,6,6
	,4,20,3,15,7
	,12,0,0,7,4
	,0,0,2,15,20
	,8,30,30,10,4
	,18,7,7,7,7
	,1,1,1,1,2
	,9,9,9
);
var ADVIT_AUTOTAB = new Array(
	0,0,0,0,0
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
	,0,0,0
);
var ADVIT_REQUIREDFLG = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0
);
var ADVIT_TYPE = new Array(
	"BTS","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","CHK","HDN","HDN"
	,"TXR","TXR","TXR"
);
var ADVIT_FORMAT = new Array(
	"00","10","00","10","10"
	,"10","00","10","00","10"
	,"00","52","52","00","00"
	,"52","56","11","00","00"
	,"10","00","00","00","00"
	,"00","12","12","12","12"
	,"00","00","11","11","11"
	,"12","12","12"
);
var ADVIT_CODEID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
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
	,"CANNOTGET","CANNOTGET","CANNOTGET"
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"","",""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0
);
var ADVIT_IMEMODE = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
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
	,0,0,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
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
	,"","",""
);
var ADVIT_ACTIONID = new Array(
	"FRM","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","",""
);
var ADVIT_ACTIONFORMID = new Array(
	"TB010F01","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","",""
);
var ADVIT_ACTPARAMETER = new Array(
	"M1","","","",""
	,"","","","",""
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
	,"","",""
);
var ADVIT_CAPTION = new Array(
	"","","","伝票番号","元伝票番号"
	,"仕入先","","部門","","担当者"
	,"","入荷予定日","仕入確定日","伝票状態","処理"
	,"処理日","処理時間","No.","品種","ブランド"
	,"自社品番","メーカー品番","商品名","色","サイズ"
	,"スキャンコード","納品数","検数","原単価","原価金額"
	,"客注","値書","","",""
	,"","",""
);

