var ADVIT_FORMID = "TB090F02";
var ADVIT_TARGETPGID = "tb090p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tb090f02.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,17,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,35,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_BTNBACK = 0;
var ADVIT_ID_HEAD_TENPO_CD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_STKMODENO = 3;
var ADVIT_ID_DENPYO_BANGO = 4;
var ADVIT_ID_SIIRESAKI_CD = 5;
var ADVIT_ID_SIIRESAKI_RYAKU_NM = 6;
var ADVIT_ID_BUMON_CD = 7;
var ADVIT_ID_BUMON_NM = 8;
var ADVIT_ID_KAKUTEITAN_CD = 9;
var ADVIT_ID_KAKUTEITAN_NM = 10;
var ADVIT_ID_NYUKAYOTEI_YMD = 11;
var ADVIT_ID_SIIRE_KAKUTEI_YMD = 12;
var ADVIT_ID_KAKUTEI_SB_NM = 13;
var ADVIT_ID_BIKO_KB = 14;
var ADVIT_ID_BIKO1 = 15;
var ADVIT_ID_BIKO2 = 16;
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
var ADVIT_ID_M1TEISEI_SURYO = 28;
var ADVIT_ID_M1GEN_TNK = 29;
var ADVIT_ID_M1GENKAKIN = 30;
var ADVIT_ID_M1TEISEI_SURYO_HDN = 31;
var ADVIT_ID_M1GENKAKIN_HDN = 32;
var ADVIT_ID_M1SELECTORCHECKBOX = 33;
var ADVIT_ID_M1ENTERSYORIFLG = 34;
var ADVIT_ID_M1DTLIROKBN = 35;
var ADVIT_ID_GOKEI_TEISEI_SURYO = 36;
var ADVIT_ID_GOKEI_GENKAKIN = 37;
var ADVIT_ID_BTNENTER = 38;

var ADVIT_ID = new Array(
	"Btnback","Head_tenpo_cd","Head_tenpo_nm","Stkmodeno","Denpyo_bango"
	,"Siiresaki_cd","Siiresaki_ryaku_nm","Bumon_cd","Bumon_nm","Kakuteitan_cd"
	,"Kakuteitan_nm","Nyukayotei_ymd","Siire_kakutei_ymd","Kakutei_sb_nm","Biko_kb"
	,"Biko1","Biko2","M1rowno","M1hinsyu_ryaku_nm","M1burando_nm"
	,"M1jisya_hbn","M1maker_hbn","M1syonmk","M1iro_nm","M1size_nm"
	,"M1scan_cd","M1nohin_su","M1kensu","M1teisei_suryo","M1gen_tnk"
	,"M1genkakin","M1teisei_suryo_hdn","M1genkakin_hdn","M1selectorcheckbox","M1entersyoriflg"
	,"M1dtlirokbn","Gokei_teisei_suryo","Gokei_genkakin","Btnenter"
);
var ADVIT_NAME = new Array(
	"戻るボタン","ヘッダ店舗コード","ヘッダ店舗名","選択モードNO","伝票番号"
	,"仕入先コード","仕入先略式名称","部門コード","部門名","確定担当者コード"
	,"確定担当者名称","入荷予定日","仕入確定日","確定種別名称","備考区分"
	,"備考1","備考2","Ｍ１行NO","Ｍ１品種略名称","Ｍ１ブランド名"
	,"Ｍ１自社品番","Ｍ１メーカー品番","Ｍ１商品名(カナ)","Ｍ１色","Ｍ１サイズ"
	,"Ｍ１スキャンコード","Ｍ１納品数","Ｍ１検数","Ｍ１訂正数量","Ｍ１原単価"
	,"Ｍ１原価金額","Ｍ１訂正数量(隠し)","Ｍ１原価金額(隠し)","Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)"
	,"Ｍ１明細色区分(隠し)","合計訂正数量","合計原価金額","確定ボタン"
);
var ADVIT_ATTRIBUTE = new Array(
	"B","SG","SN4","NA","NA"
	,"SG","SN4","SG","SN4","SG"
	,"SN4","D","D","SN4","SN5"
	,"SN22","SN21","NA","SN4","SN9"
	,"SG","SN9","SN9","SN9","SN9"
	,"SG","NA","NA","NA","NA"
	,"NA","NA","NA","NA","NA"
	,"NA","NA","NA","B"
);
var ADVIT_LENGTH = new Array(
	0,4,15,2,6
	,4,20,3,15,7
	,12,0,0,7,1
	,60,20,2,15,20
	,8,30,30,10,4
	,18,7,7,7,7
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
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,1,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0
);
var ADVIT_TYPE = new Array(
	"BTS","TXR","TXR","HDN","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","DRL"
	,"TXT","TXT","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXT","TXR","TXR","TXT","TXR"
	,"TXR","HDN","HDN","CHK","HDN"
	,"HDN","TXR","TXR","BTS"
);
var ADVIT_FORMAT = new Array(
	"00","10","00","11","10"
	,"10","00","10","00","10"
	,"00","52","52","00","00"
	,"00","00","11","00","00"
	,"10","00","00","00","00"
	,"00","12","12","12","12"
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
	,"","","M1","M1","M1"
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
	,1,1,0,0,0
	,0,0,0,0,0
	,3,0,0,3,0
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
	,1,1,0,0,0
	,0,0,0,0,0
	,1,0,0,1,0
	,0,0,0,0,0
	,0,0,0,0
);
var ADVIT_CONDID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","","BIKO_KBN"
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
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","FRM"
);
var ADVIT_ACTIONFORMID = new Array(
	"TB090F01","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","TB090F01"
);
var ADVIT_ACTPARAMETER = new Array(
	"M1","","","",""
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
	,"","","",""
);
var ADVIT_CAPTION = new Array(
	"","","","","伝票番号"
	,"仕入先","","部門","","確定担当者"
	,"","入荷予定日","仕入確定日","確定種別","備考"
	,"①","②","No.","品種","ブランド"
	,"自社品番","メーカー品番","商品名","色","サイズ"
	,"スキャンコード","納品数","検数","訂正数","原単価"
	,"原価金額","","","",""
	,"","","","確定"
);

