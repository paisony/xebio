var ADVIT_FORMID = "TB030F01";
var ADVIT_TARGETPGID = "tb030p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tb030f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,32,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,50,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_BTNMODESIIREKAKUTEI = 3;
var ADVIT_ID_BTNMODEDEL = 4;
var ADVIT_ID_BTNMODEREF = 5;
var ADVIT_ID_MODENO = 6;
var ADVIT_ID_STKMODENO = 7;
var ADVIT_ID_NYUKAYOTEI_YMD_FROM = 8;
var ADVIT_ID_NYUKAYOTEI_YMD_TO = 9;
var ADVIT_ID_SIIRE_KAKUTEI_YMD_FROM = 10;
var ADVIT_ID_SIIRE_KAKUTEI_YMD_TO = 11;
var ADVIT_ID_DENPYO_BANGO_FROM = 12;
var ADVIT_ID_DENPYO_BANGO_TO = 13;
var ADVIT_ID_SIIRESAKI_CD = 14;
var ADVIT_ID_BTNSIIRESAKI_CD = 15;
var ADVIT_ID_SIIRESAKI_RYAKU_NM = 16;
var ADVIT_ID_BUMON_CD_FROM = 17;
var ADVIT_ID_BTNBUMON_CD_FROM = 18;
var ADVIT_ID_BUMON_NM_FROM = 19;
var ADVIT_ID_BUMON_CD_TO = 20;
var ADVIT_ID_BTNBUMON_CD_TO = 21;
var ADVIT_ID_BUMON_NM_TO = 22;
var ADVIT_ID_OLD_JISYA_HBN = 23;
var ADVIT_ID_MAKER_HBN = 24;
var ADVIT_ID_SCAN_CD = 25;
var ADVIT_ID_KAKUTEI_JYOTAI = 26;
var ADVIT_ID_SCM_CD = 27;
var ADVIT_ID_SEARCHCNT = 28;
var ADVIT_ID_BTNSEARCH = 29;
var ADVIT_ID_BTNPRINT = 30;
var ADVIT_ID_PGR = 31;
var ADVIT_ID_M1ROWNO = 32;
var ADVIT_ID_M1BUMON_CD = 33;
var ADVIT_ID_M1BUMONKANA_NM = 34;
var ADVIT_ID_M1SIIRESAKI_CD = 35;
var ADVIT_ID_M1SIIRESAKI_RYAKU_NM = 36;
var ADVIT_ID_M1NYUKAYOTEI_YMD = 37;
var ADVIT_ID_M1DENPYO_BANGO = 38;
var ADVIT_ID_M1ITEMSU = 39;
var ADVIT_ID_M1GENKA_KIN = 40;
var ADVIT_ID_M1SIIRE_KAKUTEI_YMD = 41;
var ADVIT_ID_M1KAKUTEITAN_NM = 42;
var ADVIT_ID_M1DENPYO_JYOTAINM = 43;
var ADVIT_ID_M1KYAKUCYU = 44;
var ADVIT_ID_M1NEGAKI = 45;
var ADVIT_ID_M1NYUKA_KAKUTEI_CHECK = 46;
var ADVIT_ID_M1CHECK_TANNM = 47;
var ADVIT_ID_M1SELECTORCHECKBOX = 48;
var ADVIT_ID_M1ENTERSYORIFLG = 49;
var ADVIT_ID_M1DTLIROKBN = 50;
var ADVIT_ID_BTNENTER = 51;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Btnmodesiirekakutei","Btnmodedel"
	,"Btnmoderef","Modeno","Stkmodeno","Nyukayotei_ymd_from","Nyukayotei_ymd_to"
	,"Siire_kakutei_ymd_from","Siire_kakutei_ymd_to","Denpyo_bango_from","Denpyo_bango_to","Siiresaki_cd"
	,"Btnsiiresaki_cd","Siiresaki_ryaku_nm","Bumon_cd_from","Btnbumon_cd_from","Bumon_nm_from"
	,"Bumon_cd_to","Btnbumon_cd_to","Bumon_nm_to","Old_jisya_hbn","Maker_hbn"
	,"Scan_cd","Kakutei_jyotai","Scm_cd","Searchcnt","Btnsearch"
	,"Btnprint","Pgr","M1rowno","M1bumon_cd","M1bumonkana_nm"
	,"M1siiresaki_cd","M1siiresaki_ryaku_nm","M1nyukayotei_ymd","M1denpyo_bango","M1itemsu"
	,"M1genka_kin","M1siire_kakutei_ymd","M1kakuteitan_nm","M1denpyo_jyotainm","M1kyakucyu"
	,"M1negaki","M1nyuka_kakutei_check","M1check_tannm","M1selectorcheckbox","M1entersyoriflg"
	,"M1dtlirokbn","Btnenter"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","モード仕入確定ボタン","モード取消ボタン"
	,"モード照会ボタン","モードNO","選択モードNO","入荷予定日ＦＲＯＭ","入荷予定日ＴＯ"
	,"仕入確定日ＦＲＯＭ","仕入確定日ＴＯ","伝票番号ＦＲＯＭ","伝票番号ＴＯ","仕入先コード"
	,"仕入先コードボタン","仕入先名称","部門コードＦＲＯＭ","部門コードＦＲＯＭボタン","部門名ＦＲＯＭ"
	,"部門コードＴＯ","部門コードＴＯボタン","部門名ＴＯ","旧自社品番","メーカー品番"
	,"スキャンコード","確定状態","SCMコード","検索件数","検索ボタン"
	,"印刷ボタン","ページャ","Ｍ１NO","Ｍ１部門コード","Ｍ１部門カナ名"
	,"Ｍ１仕入先コード","Ｍ１仕入先名称","Ｍ１入荷予定日","Ｍ１伝票番号リンク","Ｍ１数量"
	,"Ｍ１原価金額","Ｍ１仕入確定日","Ｍ１確定担当者名称","Ｍ１伝票状態名称","Ｍ１客注"
	,"Ｍ１値書","Ｍ１入荷確定チェック","Ｍ１チェック担当者名称","Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)"
	,"Ｍ１明細色区分(隠し)","確定ボタン"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","B","B"
	,"B","NA","NA","D","D"
	,"D","D","NA","NA","SG"
	,"B","SN4","SG","B","SN4"
	,"SG","B","SN4","SG","SN9"
	,"SG","SN5","SG","NA","B"
	,"B","B","NA","SG","SN9"
	,"SG","SN4","D","B","NA"
	,"NA","D","SN4","SN4","SN4"
	,"SN4","NA","SN4","NA","NA"
	,"NA","B"
);
var ADVIT_LENGTH = new Array(
	4,0,15,0,0
	,0,2,2,0,0
	,0,0,6,6,4
	,0,20,3,0,15
	,3,0,15,10,30
	,18,1,20,4,0
	,0,0,3,3,30
	,4,20,0,0,9
	,9,0,12,7,1
	,1,1,12,1,1
	,2,0
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
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0
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
	,0,0,0,0,0
	,0,0
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","LNK","LNK"
	,"LNK","HDN","HDN","TXT","TXT"
	,"TXT","TXT","TXT","TXT","TXT"
	,"BTN","TXR","TXT","BTN","TXR"
	,"TXT","BTN","TXR","TXT","TXR"
	,"TXT","DRL","TXT","TXR","BTS"
	,"BTS","LNS","TXR","TXR","TXR"
	,"TXR","TXR","TXR","BTS","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","CHK","TXR","CHK","HDN"
	,"HDN","BTS"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","00","00"
	,"00","11","11","52","52"
	,"52","52","10","10","10"
	,"00","00","10","00","00"
	,"10","00","00","00","00"
	,"00","00","00","12","00"
	,"00","00","11","10","00"
	,"10","00","52","00","12"
	,"12","52","00","00","00"
	,"00","11","00","11","11"
	,"11","00"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"","","","",""
	,"","","","",""
	,"C_SIIRESAKI_CD","","","C_BUMON_CD",""
	,"","C_BUMON_CD","","",""
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
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET"
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1",""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,1
	,1,1,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,1
);
var ADVIT_IMEMODE = new Array(
	3,0,0,0,0
	,0,0,0,3,3
	,3,3,3,3,3
	,0,0,3,0,0
	,3,0,0,3,0
	,3,0,3,0,0
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
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,0,0
	,0,0,0,1,1
	,1,1,1,1,1
	,0,0,1,0,0
	,1,0,0,1,0
	,1,0,1,0,0
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
	,"","SIIRE_KAKUTEI_JOTAI","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"",""
);
var ADVIT_ACTIONID = new Array(
	"","COD","","SPT","SPT"
	,"SPT","","","",""
	,"","","","",""
	,"COD","","","COD",""
	,"","COD","","",""
	,"","","","","FRM"
	,"FRM","PGN","","",""
	,"","","","FRM",""
	,"","","","",""
	,"","","","",""
	,"","FRM"
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","TB030F01","TB030F01"
	,"TB030F01","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","","TB030F01"
	,"TB030F01","","","",""
	,"","","","TB030F02",""
	,"","","","",""
	,"","","","",""
	,"","TB030F01"
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","M1","","",""
	,"","","","M1",""
	,"","","","",""
	,"","","","",""
	,"",""
);
var ADVIT_ACTPROGRAMID = new Array(
	"","","","TB030P01","TB030P01"
	,"TB030P01","","","",""
	,"","","","",""
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
	"店舗","","","仕入確定","取消"
	,"照会","","","入荷予定日ＦＲＯＭ","入荷予定日ＴＯ"
	,"仕入確定日ＦＲＯＭ","仕入確定日ＴＯ","伝票番号ＦＲＯＭ","伝票番号ＴＯ","仕入先"
	,"","","部門ＦＲＯＭ","",""
	,"部門ＴＯ","","","自社品番",""
	,"ｽｷｬﾝｺｰﾄﾞ","確定状態","SCMコード","","検索"
	,"","","No.","部門",""
	,"仕入先","","入荷予定日","伝票番号","数量"
	,"原価金額","仕入確定日","確定担当者","伝票状態","客注"
	,"値書","ﾁｪｯｸ","ﾁｪｯｸ担当者","",""
	,"","確定"
);

