var ADVIT_FORMID = "TJ120F01";
var ADVIT_TARGETPGID = "tj120p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tj120f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,21,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,30,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_BTNMODEUPD = 3;
var ADVIT_ID_BTNMODEDEL = 4;
var ADVIT_ID_BTNMODEREF = 5;
var ADVIT_ID_MODENO = 6;
var ADVIT_ID_STKMODENO = 7;
var ADVIT_ID_FACE_NO_FROM = 8;
var ADVIT_ID_FACE_NO_TO = 9;
var ADVIT_ID_NYURYOKUTAN_CD = 10;
var ADVIT_ID_BTNTANTO_CD = 11;
var ADVIT_ID_NYURYOKUTAN_NM = 12;
var ADVIT_ID_NYURYOKU_YMD_FROM = 13;
var ADVIT_ID_NYURYOKU_YMD_TO = 14;
var ADVIT_ID_SEARCHCNT = 15;
var ADVIT_ID_BTNSEARCH = 16;
var ADVIT_ID_BTNZENSTK = 17;
var ADVIT_ID_BTNZENKJO = 18;
var ADVIT_ID_BTNPRINT = 19;
var ADVIT_ID_PGR = 20;
var ADVIT_ID_M1ROWNO = 21;
var ADVIT_ID_M1FACE_NO = 22;
var ADVIT_ID_M1TANA_DAN = 23;
var ADVIT_ID_M1KAI_SU = 24;
var ADVIT_ID_M1SCAN_SU = 25;
var ADVIT_ID_M1NYURYOKUTAN_NM = 26;
var ADVIT_ID_M1NYURYOKU_YMD = 27;
var ADVIT_ID_M1SELECTORCHECKBOX = 28;
var ADVIT_ID_M1ENTERSYORIFLG = 29;
var ADVIT_ID_M1DTLIROKBN = 30;
var ADVIT_ID_BTNENTER = 31;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Btnmodeupd","Btnmodedel"
	,"Btnmoderef","Modeno","Stkmodeno","Face_no_from","Face_no_to"
	,"Nyuryokutan_cd","Btntanto_cd","Nyuryokutan_nm","Nyuryoku_ymd_from","Nyuryoku_ymd_to"
	,"Searchcnt","Btnsearch","Btnzenstk","Btnzenkjo","Btnprint"
	,"Pgr","M1rowno","M1face_no","M1tana_dan","M1kai_su"
	,"M1scan_su","M1nyuryokutan_nm","M1nyuryoku_ymd","M1selectorcheckbox","M1entersyoriflg"
	,"M1dtlirokbn","Btnenter"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","モード修正ボタン","モード取消ボタン"
	,"モード照会ボタン","モードNO","選択モードNO","フェイスＮｏFROM","フェイスＮｏTO"
	,"入力担当者コード","担当者コードボタン","入力担当者名称","入力日FROM","入力日TO"
	,"検索件数","検索ボタン","全選択ボタン","全解除ボタン","印刷ボタン"
	,"ページャ","Ｍ１Noリンク","Ｍ１フェイス№","Ｍ１棚段","Ｍ１回数"
	,"Ｍ１スキャン数量","Ｍ１入力担当者名称","Ｍ１入力日","Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)"
	,"Ｍ１明細色区分(隠し)","確定ボタン"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","B","B"
	,"B","NA","NA","NA","NA"
	,"SG","B","SN4","D","D"
	,"NA","B","B","B","B"
	,"B","B","SG","NA","NA"
	,"NA","SN4","D","NA","NA"
	,"NA","B"
);
var ADVIT_LENGTH = new Array(
	4,0,15,0,0
	,0,2,2,5,5
	,7,0,12,0,0
	,4,0,0,0,0
	,0,0,5,2,2
	,6,12,0,1,1
	,2,0
);
var ADVIT_AUTOTAB = new Array(
	0,0,0,0,0
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
	,0,0
);
var ADVIT_REQUIRED = new Array(
	0,0,0,0,0
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
	,0,0,1,1,0
	,0,0,0,0,0
	,0,0
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","LNK","LNK"
	,"LNK","HDN","HDN","TXT","TXT"
	,"TXT","BTN","TXR","TXT","TXT"
	,"TXR","BTS","BTS","BTS","BTS"
	,"LNS","BTS","TXT","TXT","TXR"
	,"TXR","TXR","TXR","CHK","HDN"
	,"HDN","BTS"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","00","00"
	,"00","11","11","10","10"
	,"10","00","00","52","52"
	,"12","00","00","00","00"
	,"00","00","10","11","11"
	,"12","00","52","11","11"
	,"11","00"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"","","","",""
	,"","C_TANTO_CD","","",""
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
	,"CANNOTGET","CANNOTGET"
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1",""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,1,0,0,1
	,1,0,0,0,0
	,0,0,0,0,0
	,0,1
);
var ADVIT_IMEMODE = new Array(
	3,0,0,0,0
	,0,0,0,3,3
	,3,0,0,3,3
	,0,0,0,0,0
	,0,0,3,3,0
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
	,0,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,0,0
	,0,0,0,1,1
	,1,0,0,1,1
	,0,0,0,0,0
	,0,0,1,1,0
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
	,"",""
);
var ADVIT_ACTIONID = new Array(
	"","COD","","SPT","SPT"
	,"SPT","","","",""
	,"","COD","","",""
	,"","FRM","FRM","FRM","FRM"
	,"PGN","FRM","","",""
	,"","","","",""
	,"","FRM"
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","TJ120F01","TJ120F01"
	,"TJ120F01","","","",""
	,"","","","",""
	,"","TJ120F01","TJ120F01","TJ120F01","TJ120F01"
	,"","TJ120F02","","",""
	,"","","","",""
	,"","TJ120F01"
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","M1","M1",""
	,"M1","M1","","",""
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
	,"",""
);
var ADVIT_CAPTION = new Array(
	"店舗","","","修正","取消"
	,"照会","","","フェイスＮｏＦＲＯＭ","フェイスＮｏＴＯ"
	,"入力担当者","","","入力日ＦＲＯＭ","入力日ＴＯ"
	,"検索件数","検索","","",""
	,"","No.","フェイスNo","棚段","回数"
	,"スキャン数量","入力担当者","入力日","",""
	,"","確定"
);

