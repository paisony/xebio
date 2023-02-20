var ADVIT_FORMID = "TJ090F01";
var ADVIT_TARGETPGID = "tj090p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tj090f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,22,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,38,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_BTNMODEREF = 3;
var ADVIT_ID_BTNMODEDEL = 4;
var ADVIT_ID_MODENO = 5;
var ADVIT_ID_STKMODENO = 6;
var ADVIT_ID_FACE_NO_FROM = 7;
var ADVIT_ID_FACE_NO_TO = 8;
var ADVIT_ID_TANA_DAN_FROM = 9;
var ADVIT_ID_TANA_DAN_TO = 10;
var ADVIT_ID_NYURYOKUTAN_CD = 11;
var ADVIT_ID_BTNTANTO_CD = 12;
var ADVIT_ID_NYURYOKUTAN_NM = 13;
var ADVIT_ID_NYURYOKU_YMD_FROM = 14;
var ADVIT_ID_NYURYOKU_YMD_TO = 15;
var ADVIT_ID_SEARCHCNT = 16;
var ADVIT_ID_BTNSEARCH = 17;
var ADVIT_ID_BTNZENSTK = 18;
var ADVIT_ID_BTNZENKJO = 19;
var ADVIT_ID_BTNPRINT = 20;
var ADVIT_ID_PGR = 21;
var ADVIT_ID_M1ROWNO = 22;
var ADVIT_ID_M1FACE_NO = 23;
var ADVIT_ID_M1TANA_DAN = 24;
var ADVIT_ID_M1KAI_SU = 25;
var ADVIT_ID_M1TENSUTANAOROSINYURYOKU_SU = 26;
var ADVIT_ID_M1TENSUTANAOROSITEISEI_SU = 27;
var ADVIT_ID_M1TENSUTANAOROSITEISEI_SU_HDN = 28;
var ADVIT_ID_M1TENSUTANAOROSIGOKEI_SU = 29;
var ADVIT_ID_M1SCAN_SU = 30;
var ADVIT_ID_M1TEISEI_SURYO = 31;
var ADVIT_ID_M1GOKEI_SURYO = 32;
var ADVIT_ID_M1NYURYOKUTAN_NM = 33;
var ADVIT_ID_M1RIYUCOMMENT_NM = 34;
var ADVIT_ID_M1NYURYOKU_YMD = 35;
var ADVIT_ID_M1SELECTORCHECKBOX = 36;
var ADVIT_ID_M1ENTERSYORIFLG = 37;
var ADVIT_ID_M1DTLIROKBN = 38;
var ADVIT_ID_BTNENTER = 39;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Btnmoderef","Btnmodedel"
	,"Modeno","Stkmodeno","Face_no_from","Face_no_to","Tana_dan_from"
	,"Tana_dan_to","Nyuryokutan_cd","Btntanto_cd","Nyuryokutan_nm","Nyuryoku_ymd_from"
	,"Nyuryoku_ymd_to","Searchcnt","Btnsearch","Btnzenstk","Btnzenkjo"
	,"Btnprint","Pgr","M1rowno","M1face_no","M1tana_dan"
	,"M1kai_su","M1tensutanaorosinyuryoku_su","M1tensutanaorositeisei_su","M1tensutanaorositeisei_su_hdn","M1tensutanaorosigokei_su"
	,"M1scan_su","M1teisei_suryo","M1gokei_suryo","M1nyuryokutan_nm","M1riyucomment_nm"
	,"M1nyuryoku_ymd","M1selectorcheckbox","M1entersyoriflg","M1dtlirokbn","Btnenter"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","ボタンモード照会","ボタンモード取消"
	,"モードNO","選択モードNO","フェイスNoＦＲＯＭ","フェイスNoＴＯ","棚段ＦＲＯＭ"
	,"棚段ＴＯ","入力担当者コード","担当者コードボタン","入力担当者名称","入力日ＦＲＯＭ"
	,"入力日ＴＯ","検索件数","検索ボタン","全選択ボタン","全解除ボタン"
	,"印刷ボタン","ページャ","Ｍ１Ｎｏリンク","Ｍ１フェイスＮｏ","Ｍ１棚段"
	,"Ｍ１回数","Ｍ１点数棚卸入力数","Ｍ１点数棚卸訂正数","Ｍ１点数棚卸訂正数(隠し)","Ｍ１点数棚卸合計数"
	,"Ｍ１スキャン数量","Ｍ１訂正数量","Ｍ１合計数量","Ｍ１入力担当者名称","Ｍ１理由コメント情報"
	,"Ｍ１入力日","Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)","確定ボタン"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","B","B"
	,"NA","NA","NA","NA","NA"
	,"NA","SG","B","SN4","D"
	,"D","NA","B","B","B"
	,"B","B","B","SG","NA"
	,"NA","NA","NC","NA","NA"
	,"NA","NA","NA","SN4","SN4"
	,"D","NA","NA","NA","B"
);
var ADVIT_LENGTH = new Array(
	4,0,15,0,0
	,2,2,5,5,2
	,2,7,0,12,0
	,0,4,0,0,0
	,0,0,0,5,2
	,2,6,6,6,6
	,6,6,6,12,100
	,0,1,1,2,0
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
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","LNK","LNK"
	,"HDN","HDN","TXT","TXT","TXT"
	,"TXT","TXT","BTN","TXR","TXT"
	,"TXT","TXR","BTS","BTS","BTS"
	,"BTS","LNS","BTS","TXT","TXT"
	,"TXR","TXR","TXT","HDN","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","CHK","HDN","HDN","BTS"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","00","00"
	,"11","11","10","10","11"
	,"11","10","00","00","52"
	,"52","12","00","00","00"
	,"00","00","00","10","11"
	,"11","12","12","12","12"
	,"12","12","12","00","00"
	,"52","11","11","11","00"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"","","","",""
	,"","","C_TANTO_CD","",""
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
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1",""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,1,0,0
	,1,1,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,1
);
var ADVIT_IMEMODE = new Array(
	3,0,0,0,0
	,0,0,3,3,3
	,3,3,0,0,3
	,3,0,0,0,0
	,0,0,0,3,3
	,0,0,3,0,0
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
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,0,0
	,0,0,1,1,1
	,1,1,0,0,1
	,1,0,0,0,0
	,0,0,0,1,1
	,0,0,1,0,0
	,0,0,0,0,0
	,0,0,0,0,0
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
);
var ADVIT_ACTIONID = new Array(
	"","COD","","SPT","SPT"
	,"","","","",""
	,"","","COD","",""
	,"","","FRM","FRM","FRM"
	,"FRM","PGN","FRM","",""
	,"","","","",""
	,"","","","",""
	,"","","","","FRM"
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","TJ090F01","TJ090F01"
	,"","","","",""
	,"","","","",""
	,"","","TJ090F01","TJ090F01","TJ090F01"
	,"TJ090F01","","TJ090F02","",""
	,"","","","",""
	,"","","","",""
	,"","","","","TJ090F01"
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","M1","M1"
	,"","M1","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
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
);
var ADVIT_CAPTION = new Array(
	"店舗","","","照会","取消"
	,"","","フェイスNoＦＲＯＭ","フェイスNoＴＯ","棚段ＦＲＯＭ"
	,"棚段ＴＯ","入力担当者","","","入力日ＦＲＯＭ"
	,"入力日ＴＯ","","検索","",""
	,"","","No.","ﾌｪｲｽNo","棚段"
	,"回数","入力数量","訂正数量","","合計数量"
	,"ｽｷｬﾝ数量","訂正数量","合計数量","入力担当者","棚卸理由"
	,"入力日","","","","確定"
);

