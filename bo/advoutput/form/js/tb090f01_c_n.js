var ADVIT_FORMID = "TB090F01";
var ADVIT_TARGETPGID = "tb090p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tb090f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,29,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,48,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_BTNMODETEISEI = 3;
var ADVIT_ID_BTNMODEDEL = 4;
var ADVIT_ID_MODENO = 5;
var ADVIT_ID_STKMODENO = 6;
var ADVIT_ID_MOTODENPYO_BANGO_FROM = 7;
var ADVIT_ID_MOTODENPYO_BANGO_TO = 8;
var ADVIT_ID_NYUKAYOTEI_YMD_FROM = 9;
var ADVIT_ID_NYUKAYOTEI_YMD_TO = 10;
var ADVIT_ID_SIIRE_KAKUTEI_YMD_FROM = 11;
var ADVIT_ID_SIIRE_KAKUTEI_YMD_TO = 12;
var ADVIT_ID_SIIRESAKI_CD = 13;
var ADVIT_ID_BTNSIIRESAKI_CD = 14;
var ADVIT_ID_SIIRESAKI_RYAKU_NM = 15;
var ADVIT_ID_BUMON_CD_FROM = 16;
var ADVIT_ID_BTNBUMON_CD_FROM = 17;
var ADVIT_ID_BUMON_NM_FROM = 18;
var ADVIT_ID_BUMON_CD_TO = 19;
var ADVIT_ID_BTNBUMON_CD_TO = 20;
var ADVIT_ID_BUMON_NM_TO = 21;
var ADVIT_ID_OLD_JISYA_HBN = 22;
var ADVIT_ID_MAKER_HBN = 23;
var ADVIT_ID_SCAN_CD = 24;
var ADVIT_ID_KAKUTEI_SB = 25;
var ADVIT_ID_SEARCHCNT = 26;
var ADVIT_ID_BTNSEARCH = 27;
var ADVIT_ID_PGR = 28;
var ADVIT_ID_M1ROWNO = 29;
var ADVIT_ID_M1BUMON_CD_BO = 30;
var ADVIT_ID_M1BUMONKANA_NM = 31;
var ADVIT_ID_M1SIIRESAKI_CD = 32;
var ADVIT_ID_M1SIIRESAKI_RYAKU_NM = 33;
var ADVIT_ID_M1NYUKAYOTEI_YMD = 34;
var ADVIT_ID_M1MOTODENPYO_BANGO = 35;
var ADVIT_ID_M1AKA_DENPYO_BANGO = 36;
var ADVIT_ID_M1KURO_DENPYO_BANGO = 37;
var ADVIT_ID_M1KENSU = 38;
var ADVIT_ID_M1TEISEI_SURYO = 39;
var ADVIT_ID_M1GENKAKIN = 40;
var ADVIT_ID_M1SIIRE_KAKUTEI_YMD = 41;
var ADVIT_ID_M1KAKUTEITAN_NM = 42;
var ADVIT_ID_M1KAKUTEI_SB_NM = 43;
var ADVIT_ID_M1KYAKUCYU = 44;
var ADVIT_ID_M1NEGAKI = 45;
var ADVIT_ID_M1SELECTORCHECKBOX = 46;
var ADVIT_ID_M1ENTERSYORIFLG = 47;
var ADVIT_ID_M1DTLIROKBN = 48;
var ADVIT_ID_BTNENTER = 49;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Btnmodeteisei","Btnmodedel"
	,"Modeno","Stkmodeno","Motodenpyo_bango_from","Motodenpyo_bango_to","Nyukayotei_ymd_from"
	,"Nyukayotei_ymd_to","Siire_kakutei_ymd_from","Siire_kakutei_ymd_to","Siiresaki_cd","Btnsiiresaki_cd"
	,"Siiresaki_ryaku_nm","Bumon_cd_from","Btnbumon_cd_from","Bumon_nm_from","Bumon_cd_to"
	,"Btnbumon_cd_to","Bumon_nm_to","Old_jisya_hbn","Maker_hbn","Scan_cd"
	,"Kakutei_sb","Searchcnt","Btnsearch","Pgr","M1rowno"
	,"M1bumon_cd_bo","M1bumonkana_nm","M1siiresaki_cd","M1siiresaki_ryaku_nm","M1nyukayotei_ymd"
	,"M1motodenpyo_bango","M1aka_denpyo_bango","M1kuro_denpyo_bango","M1kensu","M1teisei_suryo"
	,"M1genkakin","M1siire_kakutei_ymd","M1kakuteitan_nm","M1kakutei_sb_nm","M1kyakucyu"
	,"M1negaki","M1selectorcheckbox","M1entersyoriflg","M1dtlirokbn","Btnenter"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","モード訂正ボタン","モード取消ボタン"
	,"モードNO","選択モードNO","元伝票番号ＦＲＯＭ","元伝票番号ＴＯ","入荷予定日ＦＲＯＭ"
	,"入荷予定日ＴＯ","仕入確定日ＦＲＯＭ","仕入確定日ＴＯ","仕入先コード","仕入先コードボタン"
	,"仕入先略式名称","部門コードＦＲＯＭ","部門コードＦＲＯＭボタン","部門名ＦＲＯＭ","部門コードＴＯ"
	,"部門コードＴＯボタン","部門名ＴＯ","旧自社品番","メーカー品番","スキャンコード"
	,"確定種別","検索件数","検索ボタン","ページャ","Ｍ１行NO"
	,"Ｍ１部門コード","Ｍ１部門カナ名","Ｍ１仕入先コード","Ｍ１仕入先略式名称","Ｍ１入荷予定日"
	,"Ｍ１元伝リンク","Ｍ１赤伝票番号","Ｍ１黒伝票番号","Ｍ１検数","Ｍ１訂正数量"
	,"Ｍ１原価金額","Ｍ１仕入確定日","Ｍ１確定担当者名称","Ｍ１確定種別名称","Ｍ１客注"
	,"Ｍ１値書","Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)","確定ボタン"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","B","B"
	,"NA","NA","NA","NA","D"
	,"D","D","D","SG","B"
	,"SN4","SG","B","SN4","SG"
	,"B","SN4","SG","SN9","SG"
	,"SN5","NA","B","B","NA"
	,"SG","SN9","SG","SN4","D"
	,"B","NA","NA","NA","NA"
	,"NA","D","SN4","SN4","SN4"
	,"SN4","NA","NA","NA","B"
);
var ADVIT_LENGTH = new Array(
	4,0,15,0,0
	,2,2,6,6,0
	,0,0,0,4,0
	,20,3,0,15,3
	,0,15,10,30,18
	,1,4,0,0,3
	,3,30,4,20,0
	,0,6,6,9,9
	,9,0,12,7,1
	,1,1,1,2,0
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
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","LNK","LNK"
	,"HDN","HDN","TXT","TXT","TXT"
	,"TXT","TXT","TXT","TXT","BTN"
	,"TXR","TXT","BTN","TXR","TXT"
	,"BTN","TXR","TXT","TXR","TXT"
	,"DRL","TXR","BTS","LNS","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"BTS","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","CHK","HDN","HDN","BTS"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","00","00"
	,"11","11","10","10","52"
	,"52","52","52","10","00"
	,"00","10","00","00","10"
	,"00","00","00","00","00"
	,"00","12","00","00","11"
	,"10","00","10","00","52"
	,"00","10","10","12","12"
	,"12","52","00","00","00"
	,"00","11","11","11","00"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"","","","",""
	,"","","","","C_SIIRESAKI_CD"
	,"","","C_BUMON_CD","",""
	,"C_BUMON_CD","","","",""
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
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1",""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,1,1,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,1
);
var ADVIT_IMEMODE = new Array(
	3,0,0,0,0
	,0,0,3,3,3
	,3,3,3,3,0
	,0,3,0,0,3
	,0,0,3,0,3
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
	,0,0,0,0,0
	,0,0,0,0,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,0,0
	,0,0,1,1,1
	,1,1,1,1,0
	,0,1,0,0,1
	,0,0,1,0,1
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
	,"SIIRE_KAKUTEI_JOTAI","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
);
var ADVIT_ACTIONID = new Array(
	"","COD","","SPT","SPT"
	,"","","","",""
	,"","","","","COD"
	,"","","COD","",""
	,"COD","","","",""
	,"","","FRM","PGN",""
	,"","","","",""
	,"FRM","","","",""
	,"","","","",""
	,"","","","","FRM"
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","TB090F01","TB090F01"
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","TB090F01","",""
	,"","","","",""
	,"TB090F02","","","",""
	,"","","","",""
	,"","","","","TB090F01"
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","M1",""
	,"","","","",""
	,"M1","","","",""
	,"","","","",""
	,"","","","",""
);
var ADVIT_ACTPROGRAMID = new Array(
	"","","","TB090P01","TB090P01"
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
);
var ADVIT_CAPTION = new Array(
	"店舗","","","訂正","取消"
	,"","","元伝票番号ＦＲＯＭ","元伝票番号ＴＯ","入荷予定日ＦＲＯＭ"
	,"入荷予定日ＴＯ","仕入確定日ＦＲＯＭ","仕入確定日ＴＯ","仕入先",""
	,"","部門ＦＲＯＭ","","","部門ＴＯ"
	,"","","自社品番","","ｽｷｬﾝｺｰﾄﾞ"
	,"確定種別","","検索","","No."
	,"部門","","仕入先","","入荷予定日"
	,"元伝","赤伝","黒伝","検数","訂正数"
	,"原価金額","仕入確定日","確定担当者","確定種別","客注"
	,"値書","","","","確定"
);

