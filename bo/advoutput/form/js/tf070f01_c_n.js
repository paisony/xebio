var ADVIT_FORMID = "TF070F01";
var ADVIT_TARGETPGID = "tf070p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tf070f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,28,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,39,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_BTNMODEKEIHISINSEI = 3;
var ADVIT_ID_BTNMODESINSEITORIKESI = 4;
var ADVIT_ID_BTNMODEUPD = 5;
var ADVIT_ID_BTNMODEDEL = 6;
var ADVIT_ID_BTNMODEREF = 7;
var ADVIT_ID_MODENO = 8;
var ADVIT_ID_STKMODENO = 9;
var ADVIT_ID_TONANHINKANRI_NO_FROM = 10;
var ADVIT_ID_TONANHINKANRI_NO_TO = 11;
var ADVIT_ID_JIKOHASSEI_YMD_FROM = 12;
var ADVIT_ID_JIKOHASSEI_YMD_TO = 13;
var ADVIT_ID_HOKOKU_YMD_FROM = 14;
var ADVIT_ID_HOKOKU_YMD_TO = 15;
var ADVIT_ID_HOKOKUTAN_CD = 16;
var ADVIT_ID_BTNTANTO_CD = 17;
var ADVIT_ID_HOKOKUTAN_NM = 18;
var ADVIT_ID_KEISATSUTODOKE_YMD_FROM = 19;
var ADVIT_ID_KEISATSUTODOKE_YMD_TO = 20;
var ADVIT_ID_JYURI_NO_FROM = 21;
var ADVIT_ID_JYURI_NO_TO = 22;
var ADVIT_ID_SEARCHCNT = 23;
var ADVIT_ID_BTNINSERT = 24;
var ADVIT_ID_BTNSEARCH = 25;
var ADVIT_ID_BTNPRINT = 26;
var ADVIT_ID_PGR = 27;
var ADVIT_ID_M1ROWNO = 28;
var ADVIT_ID_M1TONANHINKANRI_NO = 29;
var ADVIT_ID_M1JIKOHASSEI_YMD = 30;
var ADVIT_ID_M1HOKOKU_YMD = 31;
var ADVIT_ID_M1HOKOKUTAN_NM = 32;
var ADVIT_ID_M1TENTYOTAN_NM = 33;
var ADVIT_ID_M1KEISATSUTODOKE_YMD = 34;
var ADVIT_ID_M1TODOKEDESAKIKEISATSU_NM = 35;
var ADVIT_ID_M1JYURI_NO = 36;
var ADVIT_ID_M1SELECTORCHECKBOX = 37;
var ADVIT_ID_M1ENTERSYORIFLG = 38;
var ADVIT_ID_M1DTLIROKBN = 39;
var ADVIT_ID_BTNENTER = 40;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Btnmodekeihisinsei","Btnmodesinseitorikesi"
	,"Btnmodeupd","Btnmodedel","Btnmoderef","Modeno","Stkmodeno"
	,"Tonanhinkanri_no_from","Tonanhinkanri_no_to","Jikohassei_ymd_from","Jikohassei_ymd_to","Hokoku_ymd_from"
	,"Hokoku_ymd_to","Hokokutan_cd","Btntanto_cd","Hokokutan_nm","Keisatsutodoke_ymd_from"
	,"Keisatsutodoke_ymd_to","Jyuri_no_from","Jyuri_no_to","Searchcnt","Btninsert"
	,"Btnsearch","Btnprint","Pgr","M1rowno","M1tonanhinkanri_no"
	,"M1jikohassei_ymd","M1hokoku_ymd","M1hokokutan_nm","M1tentyotan_nm","M1keisatsutodoke_ymd"
	,"M1todokedesakikeisatsu_nm","M1jyuri_no","M1selectorcheckbox","M1entersyoriflg","M1dtlirokbn"
	,"Btnenter"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","モード経費申請ボタン","モード申請済取消ボタン"
	,"モード修正ボタン","モード取消ボタン","モード照会ボタン","モードNO","選択モードNO"
	,"盗難品管理番号ＦＲＯＭ","盗難品管理番号ＴＯ","事故発生日ＦＲＯＭ","事故発生日ＴＯ","報告日ＦＲＯＭ"
	,"報告日ＴＯ","報告担当者コード","担当者コードボタン","報告担当者名称","警察届出日ＦＲＯＭ"
	,"警察届出日ＴＯ","受理番号ＦＲＯＭ","受理番号ＴＯ","検索件数","新規作成ボタン"
	,"検索ボタン","印刷ボタン","ページャ","Ｍ１ＮＯ","Ｍ１管理番号リンク"
	,"Ｍ１事故発生日","Ｍ１報告日","Ｍ１報告担当者名称","Ｍ１店長担当者名称","Ｍ１警察届出日"
	,"Ｍ１届出先警察署名","Ｍ１受理番号","Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)"
	,"確定ボタン"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","B","B"
	,"B","B","B","NA","NA"
	,"NA","NA","D","D","D"
	,"D","SG","B","SN4","D"
	,"D","SB","SB","NA","B"
	,"B","B","B","NA","B"
	,"D","D","SN4","SN4","D"
	,"SN4","SB","NA","NA","NA"
	,"B"
);
var ADVIT_LENGTH = new Array(
	4,0,15,0,0
	,0,0,0,2,2
	,6,6,0,0,0
	,0,7,0,12,0
	,0,10,10,4,0
	,0,0,0,3,0
	,0,0,12,12,0
	,20,10,1,1,2
	,0
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
	,0
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
	,0
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
	,0
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
	,0
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","LNK","LNK"
	,"LNK","LNK","LNK","HDN","HDN"
	,"TXT","TXT","TXT","TXT","TXT"
	,"TXT","TXT","BTN","TXR","TXT"
	,"TXT","TXT","TXT","TXR","BTS"
	,"BTS","BTS","LNS","TXR","BTS"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","CHK","HDN","HDN"
	,"BTS"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","00","00"
	,"00","00","00","11","11"
	,"10","10","52","52","52"
	,"52","10","00","00","52"
	,"52","00","00","12","00"
	,"00","00","00","11","00"
	,"52","52","00","00","52"
	,"00","00","11","11","11"
	,"00"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"","","","",""
	,"","","","",""
	,"","","C_TANTO_CD","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,""
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
	,"CANNOTGET"
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,1
	,1,1,1,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,1
);
var ADVIT_IMEMODE = new Array(
	3,0,0,0,0
	,0,0,0,0,0
	,3,3,3,3,3
	,3,3,0,0,3
	,3,3,3,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0
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
	,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,0,0
	,0,0,0,0,0
	,1,1,1,1,1
	,1,1,0,0,1
	,1,1,1,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0
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
	,""
);
var ADVIT_ACTIONID = new Array(
	"","COD","","SPT","SPT"
	,"SPT","SPT","SPT","",""
	,"","","","",""
	,"","","COD","",""
	,"","","","","FRM"
	,"FRM","FRM","PGN","","FRM"
	,"","","","",""
	,"","","","",""
	,"FRM"
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","TF070F01","TF070F01"
	,"TF070F01","TF070F01","TF070F01","",""
	,"","","","",""
	,"","","","",""
	,"","","","","TF070F02"
	,"TF070F01","TF070F01","","","TF070F02"
	,"","","","",""
	,"","","","",""
	,"TF070F01"
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","M1","",""
	,"","","","",""
	,"","","","",""
	,""
);
var ADVIT_ACTPROGRAMID = new Array(
	"","","","TF070P01","TF070P01"
	,"TF070P01","TF070P01","TF070P01","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,""
);
var ADVIT_CAPTION = new Array(
	"店舗","","","経費申請","申請済取消"
	,"修正","取消","照会","",""
	,"管理番号ＦＲＯＭ","管理番号ＴＯ","事故発生日ＦＲＯＭ","事故発生日ＴＯ","報告日ＦＲＯＭ"
	,"報告日ＴＯ","報告者","","","警察届出日ＦＲＯＭ"
	,"警察届出日ＴＯ","受理番号ＦＲＯＭ","受理番号ＴＯ","","新規作成"
	,"検索","","","No.","管理番号"
	,"事故発生日","報告日","報告者名","店長名","警察届出日"
	,"届出警察署","受理番号","","",""
	,"確定"
);

