var ADVIT_FORMID = "TJ160F01";
var ADVIT_TARGETPGID = "tj160p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tj160f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,12,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,21,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_FACE_NO_FROM = 3;
var ADVIT_ID_FACE_NO_TO = 4;
var ADVIT_ID_NYURYOKU_YMD_FROM = 5;
var ADVIT_ID_NYURYOKU_YMD_TO = 6;
var ADVIT_ID_TYOHUKU_UMU = 7;
var ADVIT_ID_SEARCHCNT = 8;
var ADVIT_ID_BTNSEARCH = 9;
var ADVIT_ID_BTNPRINT = 10;
var ADVIT_ID_PGR = 11;
var ADVIT_ID_M1ROWNO = 12;
var ADVIT_ID_M1FACE_NO = 13;
var ADVIT_ID_M1TANA_DAN = 14;
var ADVIT_ID_M1TYOHUKU = 15;
var ADVIT_ID_M1TANTOSYA_CD = 16;
var ADVIT_ID_M1HANBAIIN_NM = 17;
var ADVIT_ID_M1CHECKLIST_MEMO = 18;
var ADVIT_ID_M1SELECTORCHECKBOX = 19;
var ADVIT_ID_M1ENTERSYORIFLG = 20;
var ADVIT_ID_M1DTLIROKBN = 21;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Face_no_from","Face_no_to"
	,"Nyuryoku_ymd_from","Nyuryoku_ymd_to","Tyohuku_umu","Searchcnt","Btnsearch"
	,"Btnprint","Pgr","M1rowno","M1face_no","M1tana_dan"
	,"M1tyohuku","M1tantosya_cd","M1hanbaiin_nm","M1checklist_memo","M1selectorcheckbox"
	,"M1entersyoriflg","M1dtlirokbn"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","フェイス№FROM","フェイス№TO"
	,"入力日FROM","入力日TO","重複有無","検索件数","検索ボタン"
	,"印刷ボタン","ページャ","Ｍ１行NO","Ｍ１フェイス№","Ｍ１棚段"
	,"Ｍ１重複","Ｍ１担当者コード","Ｍ１担当者名","Ｍ１メモ","Ｍ１選択フラグ(隠し)"
	,"Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","NA","NA"
	,"D","D","SN5","NA","B"
	,"B","B","NA","SN5","SN5"
	,"NA","SG","SN4","SN4","NA"
	,"NA","NA"
);
var ADVIT_LENGTH = new Array(
	4,0,15,5,5
	,0,0,1,4,0
	,0,0,4,5,2
	,2,7,12,10,1
	,1,2
);
var ADVIT_AUTOTAB = new Array(
	0,0,0,0,0
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
	,0,0
);
var ADVIT_REQUIRED = new Array(
	0,0,0,0,0
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
	,0,0
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","TXT","TXT"
	,"TXT","TXT","DRL","TXR","BTS"
	,"BTS","LNS","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","CHK"
	,"HDN","HDN"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","10","10"
	,"52","52","00","11","00"
	,"00","00","11","00","00"
	,"11","10","00","00","11"
	,"11","11"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
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
	,"CANNOTGET","CANNOTGET"
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
	,"","","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1"
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,1
	,1,1,0,0,0
	,0,0,0,0,0
	,0,0
);
var ADVIT_IMEMODE = new Array(
	3,0,0,3,3
	,3,3,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0
);
var ADVIT_AUTOCODECHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,1,1
	,1,1,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0
);
var ADVIT_CONDID = new Array(
	"","","","",""
	,"","","UMU","",""
	,"","","","",""
	,"","","","",""
	,"",""
);
var ADVIT_ACTIONID = new Array(
	"","COD","","",""
	,"","","","","FRM"
	,"FRM","PGN","","",""
	,"","","","",""
	,"",""
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","",""
	,"","","","","TJ160F01"
	,"TJ160F01","","","",""
	,"","","","",""
	,"",""
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","M1","","",""
	,"","","","",""
	,"",""
);
var ADVIT_ACTPROGRAMID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"",""
);
var ADVIT_CAPTION = new Array(
	"店舗","","","フェイスNoＦＲＯＭ","フェイスNoＴＯ"
	,"入力日ＦＲＯＭ","入力日ＴＯ","重複有無","","検索"
	,"","","No.","ﾌｪｲｽNo","棚段"
	,"重複","担当者","","メモ",""
	,"",""
);

