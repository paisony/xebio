var ADVIT_FORMID = "TD010F02";
var ADVIT_TARGETPGID = "td010p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "td010f02.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,20,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,35,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_BTNBACK = 0;
var ADVIT_ID_HEAD_TENPO_CD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_STKMODENO = 3;
var ADVIT_ID_SIJI_BANGO = 4;
var ADVIT_ID_KANRI_NO = 5;
var ADVIT_ID_DENPYO_BANGO = 6;
var ADVIT_ID_SIIRESAKI_CD = 7;
var ADVIT_ID_SIIRESAKI_RYAKU_NM = 8;
var ADVIT_ID_NYURYOKUTAN_CD = 9;
var ADVIT_ID_NYURYOKUTAN_NM = 10;
var ADVIT_ID_BUMON_CD = 11;
var ADVIT_ID_BUMON_NM = 12;
var ADVIT_ID_BURANDO_CD = 13;
var ADVIT_ID_BURANDO_NM = 14;
var ADVIT_ID_HENPIN_RIYU_NM = 15;
var ADVIT_ID_HENPIN_KAKUTEI_YMD = 16;
var ADVIT_ID_ADD_YMD = 17;
var ADVIT_ID_BTNROWINS = 18;
var ADVIT_ID_BTNROWDEL = 19;
var ADVIT_ID_M1ROWNO = 20;
var ADVIT_ID_M1HINSYU_RYAKU_NM = 21;
var ADVIT_ID_M1JISYA_HBN = 22;
var ADVIT_ID_M1MAKER_HBN = 23;
var ADVIT_ID_M1SYONMK = 24;
var ADVIT_ID_M1IRO_NM = 25;
var ADVIT_ID_M1SIZE_NM = 26;
var ADVIT_ID_M1SCAN_CD = 27;
var ADVIT_ID_M1SURYO = 28;
var ADVIT_ID_M1GEN_TNK = 29;
var ADVIT_ID_M1GENKAKIN = 30;
var ADVIT_ID_M1SURYO_HDN = 31;
var ADVIT_ID_M1GENKAKIN_HDN = 32;
var ADVIT_ID_M1SELECTORCHECKBOX = 33;
var ADVIT_ID_M1ENTERSYORIFLG = 34;
var ADVIT_ID_M1DTLIROKBN = 35;
var ADVIT_ID_GOKEI_SURYO = 36;
var ADVIT_ID_GENKA_KIN_GOKEI = 37;
var ADVIT_ID_BTNENTER = 38;

var ADVIT_ID = new Array(
	"Btnback","Head_tenpo_cd","Head_tenpo_nm","Stkmodeno","Siji_bango"
	,"Kanri_no","Denpyo_bango","Siiresaki_cd","Siiresaki_ryaku_nm","Nyuryokutan_cd"
	,"Nyuryokutan_nm","Bumon_cd","Bumon_nm","Burando_cd","Burando_nm"
	,"Henpin_riyu_nm","Henpin_kakutei_ymd","Add_ymd","Btnrowins","Btnrowdel"
	,"M1rowno","M1hinsyu_ryaku_nm","M1jisya_hbn","M1maker_hbn","M1syonmk"
	,"M1iro_nm","M1size_nm","M1scan_cd","M1suryo","M1gen_tnk"
	,"M1genkakin","M1suryo_hdn","M1genkakin_hdn","M1selectorcheckbox","M1entersyoriflg"
	,"M1dtlirokbn","Gokei_suryo","Genka_kin_gokei","Btnenter"
);
var ADVIT_NAME = new Array(
	"戻るボタン","ヘッダ店舗コード","ヘッダ店舗名","選択モードNO","指示番号"
	,"管理No","伝票番号","仕入先コード","仕入先略式名称","入力担当者コード"
	,"入力担当者名称","部門コード","部門名","ブランドコード","ブランド名"
	,"返品理由名称","返品確定日","登録日","行追加ボタン","行削除ボタン"
	,"Ｍ１行NO","Ｍ１品種略名称","Ｍ１自社品番","Ｍ１メーカー品番","Ｍ１商品名(カナ)"
	,"Ｍ１色","Ｍ１サイズ","Ｍ１スキャンコード","Ｍ１数量","Ｍ１原単価"
	,"Ｍ１原価金額","Ｍ１数量(隠し)","Ｍ１原価金額(隠し)","Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)"
	,"Ｍ１明細色区分(隠し)","合計数量","原価金額合計","確定ボタン"
);
var ADVIT_ATTRIBUTE = new Array(
	"B","SG","SN4","NA","SG"
	,"SG","SG","SG","SN4","SG"
	,"SN4","SG","SN4","SG","SN9"
	,"SN4","D","D","B","B"
	,"NA","SN4","SG","SN9","SN9"
	,"SN9","SN9","SG","NA","NA"
	,"NA","NA","NA","NA","NA"
	,"NA","NA","NA","B"
);
var ADVIT_LENGTH = new Array(
	0,4,15,2,10
	,6,6,4,20,7
	,12,3,15,6,20
	,4,0,0,0,0
	,2,15,8,30,30
	,10,4,18,7,7
	,9,7,9,1,1
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
	0,0,0,0,0
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
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","BTS","BTS"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXT","TXT","TXR"
	,"TXR","HDN","HDN","CHK","HDN"
	,"HDN","TXR","TXR","BTS"
);
var ADVIT_FORMAT = new Array(
	"00","10","00","11","10"
	,"10","10","10","00","10"
	,"00","10","00","10","00"
	,"00","52","52","00","00"
	,"11","00","10","00","00"
	,"00","00","00","12","12"
	,"12","12","12","11","11"
	,"11","12","12","00"
);
var ADVIT_CODEID = new Array(
	"","","","",""
	,"","","","",""
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
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,1
);
var ADVIT_IMEMODE = new Array(
	0,0,0,0,0
	,0,0,0,0,0
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
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,1,1,0
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
	,"","","",""
);
var ADVIT_ACTIONID = new Array(
	"FRM","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","MADD","FRM"
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","FRM"
);
var ADVIT_ACTIONFORMID = new Array(
	"TD010F01","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","","TD010F02"
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","TD010F01"
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","M1",""
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
	"","","","","指示番号"
	,"管理番号","伝票番号","仕入先","","入力担当者"
	,"","部門","","ブランド",""
	,"返品理由","返品確定日","登録日","",""
	,"No.","品種","自社品番","メーカー品番","商品名"
	,"色","サイズ","スキャンコード","数量","原単価"
	,"原価金額","","","",""
	,"","","","確定"
);

