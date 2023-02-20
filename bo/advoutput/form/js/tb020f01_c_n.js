var ADVIT_FORMID = "TB020F01";
var ADVIT_TARGETPGID = "tb020p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tb020f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,17,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,27,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_SCM_JOTAI = 3;
var ADVIT_ID_NYUKAYOTEI_YMD_FROM = 4;
var ADVIT_ID_NYUKAYOTEI_YMD_TO = 5;
var ADVIT_ID_SIIRESAKI_CD = 6;
var ADVIT_ID_BTNSIIRESAKI_CD = 7;
var ADVIT_ID_SIIRESAKI_RYAKU_NM = 8;
var ADVIT_ID_SIIRE_KAKUTEI_YMD_FROM = 9;
var ADVIT_ID_SIIRE_KAKUTEI_YMD_TO = 10;
var ADVIT_ID_BTNSEARCH = 11;
var ADVIT_ID_SEARCHCNT = 12;
var ADVIT_ID_NYUKAYOTEI_KOGUTI_SU = 13;
var ADVIT_ID_BTNPRINT = 14;
var ADVIT_ID_PGR = 15;
var ADVIT_ID_EIGYO_YMD_HDN = 16;
var ADVIT_ID_M1ROWNO = 17;
var ADVIT_ID_M1SIIRESAKI_CD = 18;
var ADVIT_ID_M1SIIRESAKI_RYAKU_NM = 19;
var ADVIT_ID_M1NYUKAYOTEI_YMD = 20;
var ADVIT_ID_M1SIIRE_KAKUTEI_YMD = 21;
var ADVIT_ID_M1SCM_CD = 22;
var ADVIT_ID_M1GOKEI_SURYO = 23;
var ADVIT_ID_M1GENKA_KIN = 24;
var ADVIT_ID_M1SELECTORCHECKBOX = 25;
var ADVIT_ID_M1ENTERSYORIFLG = 26;
var ADVIT_ID_M1DTLIROKBN = 27;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Scm_jotai","Nyukayotei_ymd_from"
	,"Nyukayotei_ymd_to","Siiresaki_cd","Btnsiiresaki_cd","Siiresaki_ryaku_nm","Siire_kakutei_ymd_from"
	,"Siire_kakutei_ymd_to","Btnsearch","Searchcnt","Nyukayotei_koguti_su","Btnprint"
	,"Pgr","Eigyo_ymd_hdn","M1rowno","M1siiresaki_cd","M1siiresaki_ryaku_nm"
	,"M1nyukayotei_ymd","M1siire_kakutei_ymd","M1scm_cd","M1gokei_suryo","M1genka_kin"
	,"M1selectorcheckbox","M1entersyoriflg","M1dtlirokbn"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","SCM状態","入荷予定日ＦＲＯＭ"
	,"入荷予定日ＴＯ","仕入先コード","仕入先コードボタン","仕入先名称","仕入確定日ＦＲＯＭ"
	,"仕入確定日ＴＯ","検索ボタン","検索件数","入荷予定小口数","印刷ボタン"
	,"ページャ","営業日(隠し)","Ｍ１ＮＯ","Ｍ１仕入先コード","Ｍ１仕入先名称"
	,"Ｍ１入荷予定日","Ｍ１仕入確定日","Ｍ１SCMコードリンク","Ｍ１合計数量","Ｍ１原価金額"
	,"Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","SN5","D"
	,"D","SG","B","SN4","D"
	,"D","B","NA","NA","B"
	,"B","D","NA","SG","SN4"
	,"D","D","B","NA","NA"
	,"NA","NA","NA"
);
var ADVIT_LENGTH = new Array(
	4,0,15,1,0
	,0,4,0,20,0
	,0,0,4,4,0
	,0,0,4,4,20
	,0,0,0,9,9
	,1,1,2
);
var ADVIT_AUTOTAB = new Array(
	0,0,0,0,0
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
	,0,0,0
);
var ADVIT_REQUIRED = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0
);
var ADVIT_REQUIREDFLG = new Array(
	1,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","DRL","TXT"
	,"TXT","TXT","BTN","TXR","TXT"
	,"TXT","BTS","TXT","TXR","BTS"
	,"LNS","HDN","TXR","TXR","TXR"
	,"TXR","TXR","BTS","TXR","TXR"
	,"CHK","HDN","HDN"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","00","52"
	,"52","10","00","00","52"
	,"52","00","12","12","00"
	,"00","52","11","10","00"
	,"52","52","00","12","12"
	,"11","11","11"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"","","C_SIIRESAKI_CD","",""
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
	,"CANNOTGET","CANNOTGET","CANNOTGET"
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1"
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,1,0,0,1
	,1,0,0,0,0
	,0,0,0,0,0
	,0,0,0
);
var ADVIT_IMEMODE = new Array(
	3,0,0,0,3
	,3,3,0,0,3
	,3,0,0,0,0
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
	,0,0,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,0,1
	,1,1,0,0,1
	,1,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0
);
var ADVIT_CONDID = new Array(
	"","","","SCM_JOTAI",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","",""
);
var ADVIT_ACTIONID = new Array(
	"","COD","","",""
	,"","","COD","",""
	,"","FRM","","","FRM"
	,"PGN","","","",""
	,"","","FRM","",""
	,"","",""
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","",""
	,"","","","",""
	,"","TB020F01","","","TB020F01"
	,"","","","",""
	,"","","TB020F02","",""
	,"","",""
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"M1","","","",""
	,"","","M1","",""
	,"","",""
);
var ADVIT_ACTPROGRAMID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","",""
);
var ADVIT_CAPTION = new Array(
	"店舗","","","SCM状態","入荷予定日ＦＲＯＭ"
	,"入荷予定日ＴＯ","仕入先","","","仕入確定日ＦＲＯＭ"
	,"仕入確定日ＴＯ","検索","","SCM仕入入荷予定小口数",""
	,"","","No.","仕入先",""
	,"入荷予定日","仕入確定日","SCMコード","数量","原価金額"
	,"","",""
);

