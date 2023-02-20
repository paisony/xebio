var ADVIT_FORMID = "TJ110F01";
var ADVIT_TARGETPGID = "tj110p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tj110f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,12,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,53,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_TORIMORE_KETSUBAN = 3;
var ADVIT_ID_FACE_NO_FROM = 4;
var ADVIT_ID_FACE_NO_TO = 5;
var ADVIT_ID_SEARCHCNT = 6;
var ADVIT_ID_BTNSEARCH = 7;
var ADVIT_ID_BTNZENSTK = 8;
var ADVIT_ID_BTNZENKJO = 9;
var ADVIT_ID_BTNPRINT = 10;
var ADVIT_ID_PGR = 11;
var ADVIT_ID_M1ROWNO = 12;
var ADVIT_ID_M1FACE_NO = 13;
var ADVIT_ID_M1TANA_DAN = 14;
var ADVIT_ID_M1SELECTORCHECKBOX = 15;
var ADVIT_ID_M1ENTERSYORIFLG = 16;
var ADVIT_ID_M1DTLIROKBN = 17;
var ADVIT_ID_M1ROWNO2 = 18;
var ADVIT_ID_M1FACE_NO2 = 19;
var ADVIT_ID_M1TANA_DAN2 = 20;
var ADVIT_ID_M1SELECTORCHECKBOX2 = 21;
var ADVIT_ID_M1ENTERSYORIFLG2 = 22;
var ADVIT_ID_M1DTLIROKBN2 = 23;
var ADVIT_ID_M1ROWNO3 = 24;
var ADVIT_ID_M1FACE_NO3 = 25;
var ADVIT_ID_M1TANA_DAN3 = 26;
var ADVIT_ID_M1SELECTORCHECKBOX3 = 27;
var ADVIT_ID_M1ENTERSYORIFLG3 = 28;
var ADVIT_ID_M1DTLIROKBN3 = 29;
var ADVIT_ID_M1ROWNO4 = 30;
var ADVIT_ID_M1FACE_NO4 = 31;
var ADVIT_ID_M1TANA_DAN4 = 32;
var ADVIT_ID_M1SELECTORCHECKBOX4 = 33;
var ADVIT_ID_M1ENTERSYORIFLG4 = 34;
var ADVIT_ID_M1DTLIROKBN4 = 35;
var ADVIT_ID_M1ROWNO5 = 36;
var ADVIT_ID_M1FACE_NO5 = 37;
var ADVIT_ID_M1TANA_DAN5 = 38;
var ADVIT_ID_M1SELECTORCHECKBOX5 = 39;
var ADVIT_ID_M1ENTERSYORIFLG5 = 40;
var ADVIT_ID_M1DTLIROKBN5 = 41;
var ADVIT_ID_M1ROWNO6 = 42;
var ADVIT_ID_M1FACE_NO6 = 43;
var ADVIT_ID_M1TANA_DAN6 = 44;
var ADVIT_ID_M1SELECTORCHECKBOX6 = 45;
var ADVIT_ID_M1ENTERSYORIFLG6 = 46;
var ADVIT_ID_M1DTLIROKBN6 = 47;
var ADVIT_ID_M1ROWNO7 = 48;
var ADVIT_ID_M1FACE_NO7 = 49;
var ADVIT_ID_M1TANA_DAN7 = 50;
var ADVIT_ID_M1SELECTORCHECKBOX7 = 51;
var ADVIT_ID_M1ENTERSYORIFLG7 = 52;
var ADVIT_ID_M1DTLIROKBN7 = 53;
var ADVIT_ID_BTNENTER = 54;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Torimore_ketsuban","Face_no_from"
	,"Face_no_to","Searchcnt","Btnsearch","Btnzenstk","Btnzenkjo"
	,"Btnprint","Pgr","M1rowno","M1face_no","M1tana_dan"
	,"M1selectorcheckbox","M1entersyoriflg","M1dtlirokbn","M1rowno2","M1face_no2"
	,"M1tana_dan2","M1selectorcheckbox2","M1entersyoriflg2","M1dtlirokbn2","M1rowno3"
	,"M1face_no3","M1tana_dan3","M1selectorcheckbox3","M1entersyoriflg3","M1dtlirokbn3"
	,"M1rowno4","M1face_no4","M1tana_dan4","M1selectorcheckbox4","M1entersyoriflg4"
	,"M1dtlirokbn4","M1rowno5","M1face_no5","M1tana_dan5","M1selectorcheckbox5"
	,"M1entersyoriflg5","M1dtlirokbn5","M1rowno6","M1face_no6","M1tana_dan6"
	,"M1selectorcheckbox6","M1entersyoriflg6","M1dtlirokbn6","M1rowno7","M1face_no7"
	,"M1tana_dan7","M1selectorcheckbox7","M1entersyoriflg7","M1dtlirokbn7","Btnenter"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","取漏れ／欠番","フェイス№FROM"
	,"フェイス№TO","検索件数","検索ボタン","全選択ボタン","全解除ボタン"
	,"印刷ボタン","ページャ","Ｍ１行NO","Ｍ１フェイス№","Ｍ１棚段"
	,"Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)","Ｍ１行NO２","Ｍ１フェイス№２"
	,"Ｍ１棚段２","Ｍ１選択フラグ(隠し)２","Ｍ１確定処理フラグ(隠し)２","Ｍ１明細色区分(隠し)２","Ｍ１行NO３"
	,"Ｍ１フェイス№３","Ｍ１棚段３","Ｍ１選択フラグ(隠し)３","Ｍ１確定処理フラグ(隠し)３","Ｍ１明細色区分(隠し)３"
	,"Ｍ１行NO４","Ｍ１フェイス№４","Ｍ１棚段４","Ｍ１選択フラグ(隠し)４","Ｍ１確定処理フラグ(隠し)４"
	,"Ｍ１明細色区分(隠し)４","Ｍ１行NO５","Ｍ１フェイス№５","Ｍ１棚段５","Ｍ１選択フラグ(隠し)５"
	,"Ｍ１確定処理フラグ(隠し)５","Ｍ１明細色区分(隠し)５","Ｍ１行NO６","Ｍ１フェイス№６","Ｍ１棚段６"
	,"Ｍ１選択フラグ(隠し)６","Ｍ１確定処理フラグ(隠し)６","Ｍ１明細色区分(隠し)６","Ｍ１行NO７","Ｍ１フェイス№７"
	,"Ｍ１棚段７","Ｍ１選択フラグ(隠し)７","Ｍ１確定処理フラグ(隠し)７","Ｍ１明細色区分(隠し)７","確定ボタン"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","SN5","NA"
	,"NA","NA","B","B","B"
	,"B","B","NA","NA","NA"
	,"NA","NA","NA","NA","NA"
	,"NA","NA","NA","NA","NA"
	,"NA","NA","NA","NA","NA"
	,"NA","NA","NA","NA","NA"
	,"NA","NA","NA","NA","NA"
	,"NA","NA","NA","NA","NA"
	,"NA","NA","NA","NA","NA"
	,"NA","NA","NA","NA","B"
);
var ADVIT_LENGTH = new Array(
	4,0,15,1,5
	,5,4,0,0,0
	,0,0,4,5,2
	,1,1,2,4,5
	,2,1,1,2,4
	,5,2,1,1,2
	,4,5,2,1,1
	,2,4,5,2,1
	,1,2,4,5,2
	,1,1,2,4,5
	,2,1,1,2,0
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
	,0,0,0,0,0
);
var ADVIT_REQUIREDFLG = new Array(
	1,0,0,0,1
	,1,0,0,0,0
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
	"TXT","BTN","TXR","DRL","TXT"
	,"TXT","TXR","BTS","BTS","BTS"
	,"BTS","LNS","TXR","TXR","TXR"
	,"CHK","HDN","HDN","TXR","TXR"
	,"TXR","CHK","HDN","HDN","TXR"
	,"TXR","TXR","CHK","HDN","HDN"
	,"TXR","TXR","TXR","CHK","HDN"
	,"HDN","TXR","TXR","TXR","CHK"
	,"HDN","HDN","TXR","TXR","TXR"
	,"CHK","HDN","HDN","TXR","TXR"
	,"TXR","CHK","HDN","HDN","BTS"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","00","10"
	,"10","12","00","00","00"
	,"00","00","11","10","11"
	,"11","11","11","11","10"
	,"11","11","11","11","11"
	,"10","11","11","11","11"
	,"11","10","11","11","11"
	,"11","11","10","11","11"
	,"11","11","11","10","11"
	,"11","11","11","11","10"
	,"11","11","11","11","00"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"","","","",""
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
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
	,"","","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1",""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,1,0,0
	,1,1,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,1
);
var ADVIT_IMEMODE = new Array(
	3,0,0,0,3
	,3,0,0,0,0
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
	,0,0,0,0,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,0,1
	,1,0,0,0,0
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
var ADVIT_CONDID = new Array(
	"","","","TORIMORE_KETSUBAN_KBN",""
	,"","","","",""
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
var ADVIT_ACTIONID = new Array(
	"","COD","","",""
	,"","","FRM","FRM","FRM"
	,"FRM","PGN","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","","FRM"
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","",""
	,"","","TJ110F01","TJ110F01","TJ110F01"
	,"TJ110F01","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","","TJ110F01"
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","M1","M1"
	,"","M1","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
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
	,"","","","",""
	,"","","","",""
	,"","","","",""
);
var ADVIT_CAPTION = new Array(
	"店舗","","","取漏れ／欠番","フェイスNoＦＲＯＭ"
	,"フェイスNoＴＯ","","検索","",""
	,"","","No.","フェイスNo","棚段"
	,"","","","No.","フェイスNo"
	,"棚段","","","","No."
	,"フェイスNo","棚段","","",""
	,"No.","フェイスNo","棚段","",""
	,"","No.","フェイスNo","棚段",""
	,"","","No.","フェイスNo","棚段"
	,"","","","No.","フェイスNo"
	,"棚段","","","","確定"
);

