var ADVIT_FORMID = "TB010F01";
var ADVIT_TARGETPGID = "tb010p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tb010f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,30,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,48,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_DENPYO_JYOTAI = 3;
var ADVIT_ID_NYUKAYOTEI_YMD_FROM = 4;
var ADVIT_ID_NYUKAYOTEI_YMD_TO = 5;
var ADVIT_ID_SIIRE_KAKUTEI_YMD_FROM = 6;
var ADVIT_ID_SIIRE_KAKUTEI_YMD_TO = 7;
var ADVIT_ID_SIIRESAKI_CD = 8;
var ADVIT_ID_BTNSIIRESAKI_CD = 9;
var ADVIT_ID_SIIRESAKI_RYAKU_NM = 10;
var ADVIT_ID_BUMON_CD_FROM = 11;
var ADVIT_ID_BTNBUMON_CD_FROM = 12;
var ADVIT_ID_BUMON_NM_FROM = 13;
var ADVIT_ID_BUMON_CD_TO = 14;
var ADVIT_ID_BTNBUMON_CDTO = 15;
var ADVIT_ID_BUMON_NM_TO = 16;
var ADVIT_ID_DENPYO_BANGO_FROM = 17;
var ADVIT_ID_DENPYO_BANGO_TO = 18;
var ADVIT_ID_MOTODENPYO_BANGO_FROM = 19;
var ADVIT_ID_MOTODENPYO_BANGO_TO = 20;
var ADVIT_ID_OLD_JISYA_HBN = 21;
var ADVIT_ID_MAKER_HBN = 22;
var ADVIT_ID_SCAN_CD = 23;
var ADVIT_ID_SEARCHCNT = 24;
var ADVIT_ID_BTNSEARCH = 25;
var ADVIT_ID_BTNPRINT = 26;
var ADVIT_ID_BTNCSV = 27;
var ADVIT_ID_PGR = 28;
var ADVIT_ID_EIGYO_YMD_HDN = 29;
var ADVIT_ID_M1ROWNO = 30;
var ADVIT_ID_M1BUMON_CD = 31;
var ADVIT_ID_M1BUMONKANA_NM = 32;
var ADVIT_ID_M1SIIRESAKI_CD = 33;
var ADVIT_ID_M1SIIRESAKI_RYAKU_NM = 34;
var ADVIT_ID_M1NYUKAYOTEI_YMD = 35;
var ADVIT_ID_M1DENPYO_BANGO = 36;
var ADVIT_ID_M1MOTODENPYO_BANGO = 37;
var ADVIT_ID_M1NOHIN_SU = 38;
var ADVIT_ID_M1KENSU = 39;
var ADVIT_ID_M1GENKA_KIN = 40;
var ADVIT_ID_M1SIIRE_KAKUTEI_YMD = 41;
var ADVIT_ID_M1DENPYO_JYOTAINM = 42;
var ADVIT_ID_M1SYORINM = 43;
var ADVIT_ID_M1SYORIYMD = 44;
var ADVIT_ID_M1SYORI_TM = 45;
var ADVIT_ID_M1SELECTORCHECKBOX = 46;
var ADVIT_ID_M1ENTERSYORIFLG = 47;
var ADVIT_ID_M1DTLIROKBN = 48;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Denpyo_jyotai","Nyukayotei_ymd_from"
	,"Nyukayotei_ymd_to","Siire_kakutei_ymd_from","Siire_kakutei_ymd_to","Siiresaki_cd","Btnsiiresaki_cd"
	,"Siiresaki_ryaku_nm","Bumon_cd_from","Btnbumon_cd_from","Bumon_nm_from","Bumon_cd_to"
	,"Btnbumon_cdto","Bumon_nm_to","Denpyo_bango_from","Denpyo_bango_to","Motodenpyo_bango_from"
	,"Motodenpyo_bango_to","Old_jisya_hbn","Maker_hbn","Scan_cd","Searchcnt"
	,"Btnsearch","Btnprint","Btncsv","Pgr","Eigyo_ymd_hdn"
	,"M1rowno","M1bumon_cd","M1bumonkana_nm","M1siiresaki_cd","M1siiresaki_ryaku_nm"
	,"M1nyukayotei_ymd","M1denpyo_bango","M1motodenpyo_bango","M1nohin_su","M1kensu"
	,"M1genka_kin","M1siire_kakutei_ymd","M1denpyo_jyotainm","M1syorinm","M1syoriymd"
	,"M1syori_tm","M1selectorcheckbox","M1entersyoriflg","M1dtlirokbn"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","伝票状態","入荷予定日ＦＲＯＭ"
	,"入荷予定日ＴＯ","仕入確定日ＦＲＯＭ","仕入確定日ＴＯ","仕入先コード","仕入先コードボタン"
	,"仕入先名称","部門コードＦＲＯＭ","部門コードＦＲＯＭボタン","部門名ＦＲＯＭ","部門コードＴＯ"
	,"部門コードＴＯボタン","部門名ＴＯ","伝票番号ＦＲＯＭ","伝票番号ＴＯ","元伝票番号ＦＲＯＭ"
	,"元伝票番号ＴＯ","旧自社品番","メーカー品番","スキャンコード","検索件数"
	,"検索ボタン","印刷ボタン","CSVボタン","ページャ","営業日（隠し）"
	,"Ｍ１ＮＯ","Ｍ１部門コード","Ｍ１部門カナ名","Ｍ１仕入先コード","Ｍ１仕入先名称"
	,"Ｍ１入荷予定日","Ｍ１伝票番号リンク","Ｍ１元伝票番号","Ｍ１納品数","Ｍ１検数"
	,"Ｍ１原価金額","Ｍ１仕入確定日","Ｍ１伝票状態名称","Ｍ１処理名称","Ｍ１処理日"
	,"Ｍ１処理時間","Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","SN5","D"
	,"D","D","D","SG","B"
	,"SN4","SG","B","SN4","SG"
	,"B","SN4","NA","NA","NA"
	,"NA","SG","SN9","SG","NA"
	,"B","B","B","B","D"
	,"NA","SG","SN9","SG","SN4"
	,"D","B","NA","NA","NA"
	,"NA","D","SN4","SN4","D"
	,"D","NA","NA","NA"
);
var ADVIT_LENGTH = new Array(
	4,0,15,1,0
	,0,0,0,4,0
	,20,3,0,15,3
	,0,15,6,6,6
	,6,10,30,18,4
	,0,0,0,0,0
	,3,3,30,4,20
	,0,0,6,9,9
	,9,0,7,4,0
	,0,1,1,2
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
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0
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
	,0,0,0,0
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","DRL","TXT"
	,"TXT","TXT","TXT","TXT","BTN"
	,"TXR","TXT","BTN","TXR","TXT"
	,"BTN","TXR","TXT","TXT","TXT"
	,"TXT","TXT","TXR","TXT","TXR"
	,"BTS","BTS","BTS","LNS","HDN"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","BTS","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","CHK","HDN","HDN"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","00","52"
	,"52","52","52","10","00"
	,"00","10","00","00","10"
	,"00","00","10","10","10"
	,"10","00","00","00","12"
	,"00","00","00","00","52"
	,"11","10","00","10","00"
	,"52","00","10","12","12"
	,"12","52","00","00","52"
	,"56","11","11","11"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"","","","","C_SIIRESAKI_CD"
	,"","","C_BUMON_CD","",""
	,"C_BUMON_CD","","","",""
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
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1"
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,1,1,1,1,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0
);
var ADVIT_IMEMODE = new Array(
	3,0,0,0,3
	,3,3,3,3,0
	,0,3,0,0,3
	,0,0,3,3,3
	,3,3,0,3,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
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
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,0,1
	,1,1,1,1,0
	,0,1,0,0,1
	,0,0,1,1,1
	,1,1,0,1,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0
);
var ADVIT_CONDID = new Array(
	"","","","SIIIRE_DENPYO_JOTAI",""
	,"","","","",""
	,"","","","",""
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
	,"","","","","COD"
	,"","","COD","",""
	,"COD","","","",""
	,"","","","",""
	,"FRM","FRM","FRM","PGN",""
	,"","","","",""
	,"","FRM","","",""
	,"","","","",""
	,"","","",""
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"TB010F01","TB010F01","TB010F01","",""
	,"","","","",""
	,"","TB010F02","","",""
	,"","","","",""
	,"","","",""
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","M1",""
	,"","","","",""
	,"","M1","","",""
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
	,"","","","",""
	,"","","","",""
	,"","","",""
);
var ADVIT_CAPTION = new Array(
	"店舗","","","伝票状態","入荷予定日ＦＲＯＭ"
	,"入荷予定日ＴＯ","仕入確定日ＦＲＯＭ","仕入確定日ＴＯ","仕入先",""
	,"","部門ＦＲＯＭ","","","部門ＴＯ"
	,"","","伝票番号ＦＲＯＭ","伝票番号ＴＯ","元伝票番号ＦＲＯＭ"
	,"元伝票番号ＴＯ","自社品番","","ｽｷｬﾝｺｰﾄﾞ",""
	,"検索","","","",""
	,"No.","部門","","仕入先",""
	,"入荷予定日","伝票","元伝票","納品数","検数"
	,"原価金額","仕入確定日","伝票状態","処理","処理日"
	,"処理時間","","",""
);

