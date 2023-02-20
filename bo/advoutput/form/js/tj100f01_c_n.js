var ADVIT_FORMID = "TJ100F01";
var ADVIT_TARGETPGID = "tj100p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tj100f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,30,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,71,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_TORIMORE_KETSUBAN = 3;
var ADVIT_ID_FACE_NO_FROM = 4;
var ADVIT_ID_FACE_NO_TO = 5;
var ADVIT_ID_FACE_NO_FROM1 = 6;
var ADVIT_ID_FACE_NO_TO1 = 7;
var ADVIT_ID_FACE_NO_FROM2 = 8;
var ADVIT_ID_FACE_NO_TO2 = 9;
var ADVIT_ID_FACE_NO_FROM3 = 10;
var ADVIT_ID_FACE_NO_TO3 = 11;
var ADVIT_ID_FACE_NO_FROM4 = 12;
var ADVIT_ID_FACE_NO_TO4 = 13;
var ADVIT_ID_FACE_NO_FROM5 = 14;
var ADVIT_ID_FACE_NO_TO5 = 15;
var ADVIT_ID_FACE_NO_FROM6 = 16;
var ADVIT_ID_FACE_NO_TO6 = 17;
var ADVIT_ID_FACE_NO_FROM7 = 18;
var ADVIT_ID_FACE_NO_TO7 = 19;
var ADVIT_ID_FACE_NO_FROM8 = 20;
var ADVIT_ID_FACE_NO_TO8 = 21;
var ADVIT_ID_FACE_NO_FROM9 = 22;
var ADVIT_ID_FACE_NO_TO9 = 23;
var ADVIT_ID_SEARCHCNT = 24;
var ADVIT_ID_BTNSEARCH = 25;
var ADVIT_ID_BTNZENSTK = 26;
var ADVIT_ID_BTNZENKJO = 27;
var ADVIT_ID_BTNPRINT = 28;
var ADVIT_ID_PGR = 29;
var ADVIT_ID_M1ROWNO = 30;
var ADVIT_ID_M1FACE_NO = 31;
var ADVIT_ID_M1TANA_DAN = 32;
var ADVIT_ID_M1SELECTORCHECKBOX = 33;
var ADVIT_ID_M1ENTERSYORIFLG = 34;
var ADVIT_ID_M1DTLIROKBN = 35;
var ADVIT_ID_M1ROWNO2 = 36;
var ADVIT_ID_M1FACE_NO2 = 37;
var ADVIT_ID_M1TANA_DAN2 = 38;
var ADVIT_ID_M1SELECTORCHECKBOX2 = 39;
var ADVIT_ID_M1ENTERSYORIFLG2 = 40;
var ADVIT_ID_M1DTLIROKBN2 = 41;
var ADVIT_ID_M1ROWNO3 = 42;
var ADVIT_ID_M1FACE_NO3 = 43;
var ADVIT_ID_M1TANA_DAN3 = 44;
var ADVIT_ID_M1SELECTORCHECKBOX3 = 45;
var ADVIT_ID_M1ENTERSYORIFLG3 = 46;
var ADVIT_ID_M1DTLIROKBN3 = 47;
var ADVIT_ID_M1ROWNO4 = 48;
var ADVIT_ID_M1FACE_NO4 = 49;
var ADVIT_ID_M1TANA_DAN4 = 50;
var ADVIT_ID_M1SELECTORCHECKBOX4 = 51;
var ADVIT_ID_M1ENTERSYORIFLG4 = 52;
var ADVIT_ID_M1DTLIROKBN4 = 53;
var ADVIT_ID_M1ROWNO5 = 54;
var ADVIT_ID_M1FACE_NO5 = 55;
var ADVIT_ID_M1TANA_DAN5 = 56;
var ADVIT_ID_M1SELECTORCHECKBOX5 = 57;
var ADVIT_ID_M1ENTERSYORIFLG5 = 58;
var ADVIT_ID_M1DTLIROKBN5 = 59;
var ADVIT_ID_M1ROWNO6 = 60;
var ADVIT_ID_M1FACE_NO6 = 61;
var ADVIT_ID_M1TANA_DAN6 = 62;
var ADVIT_ID_M1SELECTORCHECKBOX6 = 63;
var ADVIT_ID_M1ENTERSYORIFLG6 = 64;
var ADVIT_ID_M1DTLIROKBN6 = 65;
var ADVIT_ID_M1ROWNO7 = 66;
var ADVIT_ID_M1FACE_NO7 = 67;
var ADVIT_ID_M1TANA_DAN7 = 68;
var ADVIT_ID_M1SELECTORCHECKBOX7 = 69;
var ADVIT_ID_M1ENTERSYORIFLG7 = 70;
var ADVIT_ID_M1DTLIROKBN7 = 71;
var ADVIT_ID_BTNENTER = 72;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Torimore_ketsuban","Face_no_from"
	,"Face_no_to","Face_no_from1","Face_no_to1","Face_no_from2","Face_no_to2"
	,"Face_no_from3","Face_no_to3","Face_no_from4","Face_no_to4","Face_no_from5"
	,"Face_no_to5","Face_no_from6","Face_no_to6","Face_no_from7","Face_no_to7"
	,"Face_no_from8","Face_no_to8","Face_no_from9","Face_no_to9","Searchcnt"
	,"Btnsearch","Btnzenstk","Btnzenkjo","Btnprint","Pgr"
	,"M1rowno","M1face_no","M1tana_dan","M1selectorcheckbox","M1entersyoriflg"
	,"M1dtlirokbn","M1rowno2","M1face_no2","M1tana_dan2","M1selectorcheckbox2"
	,"M1entersyoriflg2","M1dtlirokbn2","M1rowno3","M1face_no3","M1tana_dan3"
	,"M1selectorcheckbox3","M1entersyoriflg3","M1dtlirokbn3","M1rowno4","M1face_no4"
	,"M1tana_dan4","M1selectorcheckbox4","M1entersyoriflg4","M1dtlirokbn4","M1rowno5"
	,"M1face_no5","M1tana_dan5","M1selectorcheckbox5","M1entersyoriflg5","M1dtlirokbn5"
	,"M1rowno6","M1face_no6","M1tana_dan6","M1selectorcheckbox6","M1entersyoriflg6"
	,"M1dtlirokbn6","M1rowno7","M1face_no7","M1tana_dan7","M1selectorcheckbox7"
	,"M1entersyoriflg7","M1dtlirokbn7","Btnenter"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","取漏れ／欠番","フェイス№FROM"
	,"フェイス№TO","フェイス№FROM1","フェイス№TO1","フェイス№FROM2","フェイス№TO2"
	,"フェイス№FROM3","フェイス№TO3","フェイス№FROM4","フェイス№TO4","フェイス№FROM5"
	,"フェイス№TO5","フェイス№FROM6","フェイス№TO6","フェイス№FROM7","フェイス№TO7"
	,"フェイス№FROM8","フェイス№TO8","フェイス№FROM9","フェイス№TO9","検索件数"
	,"検索ボタン","全選択ボタン","全解除ボタン","印刷ボタン","ページャ"
	,"Ｍ１行NO","Ｍ１フェイス№","Ｍ１棚段","Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)"
	,"Ｍ１明細色区分(隠し)","Ｍ１行NO２","Ｍ１フェイス№２","Ｍ１棚段２","Ｍ１選択フラグ(隠し)２"
	,"Ｍ１確定処理フラグ(隠し)２","Ｍ１明細色区分(隠し)２","Ｍ１行NO３","Ｍ１フェイス№３","Ｍ１棚段３"
	,"Ｍ１選択フラグ(隠し)３","Ｍ１確定処理フラグ(隠し)３","Ｍ１明細色区分(隠し)３","Ｍ１行NO４","Ｍ１フェイス№４"
	,"Ｍ１棚段４","Ｍ１選択フラグ(隠し)４","Ｍ１確定処理フラグ(隠し)４","Ｍ１明細色区分(隠し)４","Ｍ１行NO５"
	,"Ｍ１フェイス№５","Ｍ１棚段５","Ｍ１選択フラグ(隠し)５","Ｍ１確定処理フラグ(隠し)５","Ｍ１明細色区分(隠し)５"
	,"Ｍ１行NO６","Ｍ１フェイス№６","Ｍ１棚段６","Ｍ１選択フラグ(隠し)６","Ｍ１確定処理フラグ(隠し)６"
	,"Ｍ１明細色区分(隠し)６","Ｍ１行NO７","Ｍ１フェイス№７","Ｍ１棚段７","Ｍ１選択フラグ(隠し)７"
	,"Ｍ１確定処理フラグ(隠し)７","Ｍ１明細色区分(隠し)７","確定ボタン"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","SN5","NA"
	,"NA","NA","NA","NA","NA"
	,"NA","NA","NA","NA","NA"
	,"NA","NA","NA","NA","NA"
	,"NA","NA","NA","NA","NA"
	,"B","B","B","B","B"
	,"NA","NA","NA","NA","NA"
	,"NA","NA","NA","NA","NA"
	,"NA","NA","NA","NA","NA"
	,"NA","NA","NA","NA","NA"
	,"NA","NA","NA","NA","NA"
	,"NA","NA","NA","NA","NA"
	,"NA","NA","NA","NA","NA"
	,"NA","NA","NA","NA","NA"
	,"NA","NA","B"
);
var ADVIT_LENGTH = new Array(
	4,0,15,1,5
	,5,5,5,5,5
	,5,5,5,5,5
	,5,5,5,5,5
	,5,5,5,5,4
	,0,0,0,0,0
	,4,5,2,1,1
	,2,4,5,2,1
	,1,2,4,5,2
	,1,1,2,4,5
	,2,1,1,2,4
	,5,2,1,1,2
	,4,5,2,1,1
	,2,4,5,2,1
	,1,2,0
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
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
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
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
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
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","DRL","TXT"
	,"TXT","TXT","TXT","TXT","TXT"
	,"TXT","TXT","TXT","TXT","TXT"
	,"TXT","TXT","TXT","TXT","TXT"
	,"TXT","TXT","TXT","TXT","TXR"
	,"BTS","BTS","BTS","BTS","LNS"
	,"TXR","TXR","TXR","CHK","HDN"
	,"HDN","TXR","TXR","TXR","CHK"
	,"HDN","HDN","TXR","TXR","TXR"
	,"CHK","HDN","HDN","TXR","TXR"
	,"TXR","CHK","HDN","HDN","TXR"
	,"TXR","TXR","CHK","HDN","HDN"
	,"TXR","TXR","TXR","CHK","HDN"
	,"HDN","TXR","TXR","TXR","CHK"
	,"HDN","HDN","BTS"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","00","10"
	,"10","10","10","10","10"
	,"10","10","10","10","10"
	,"10","10","10","10","10"
	,"10","10","10","10","12"
	,"00","00","00","00","00"
	,"11","10","11","11","11"
	,"11","11","10","11","11"
	,"11","11","11","10","11"
	,"11","11","11","11","10"
	,"11","11","11","11","11"
	,"10","11","11","11","11"
	,"11","10","11","11","11"
	,"11","11","10","11","11"
	,"11","11","00"
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
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
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
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1",""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,1,0,0,1,1
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,1
);
var ADVIT_IMEMODE = new Array(
	3,0,0,0,3
	,3,3,3,3,3
	,3,3,3,3,3
	,3,3,3,3,3
	,3,3,3,3,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
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
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,0,1
	,1,1,1,1,1
	,1,1,1,1,1
	,1,1,1,1,1
	,1,1,1,1,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0
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
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","",""
);
var ADVIT_ACTIONID = new Array(
	"","COD","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"FRM","FRM","FRM","FRM","PGN"
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","FRM"
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"TJ100F01","TJ100F01","TJ100F01","TJ100F01",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","TJ100F01"
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","M1","M1","","M1"
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","M1"
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
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","",""
);
var ADVIT_CAPTION = new Array(
	"店舗","","","取漏れ／欠番","フェイスNoＦＲＯＭ1"
	,"フェイスNoＴＯ1","フェイスNoＦＲＯＭ2","フェイスNoＴＯ2","フェイスNoＦＲＯＭ3","フェイスNoＴＯ3"
	,"フェイスNoＦＲＯＭ4","フェイスNoＴＯ4","フェイスNoＦＲＯＭ5","フェイスNoＴＯ5","フェイスNoＦＲＯＭ6"
	,"フェイスNoＴＯ6","フェイスNoＦＲＯＭ7","フェイスNoＴＯ7","フェイスNoＦＲＯＭ8","フェイスNoＴＯ8"
	,"フェイスNoＦＲＯＭ9","フェイスNoＴＯ9","フェイスNoＦＲＯＭ10","フェイスNoＴＯ10",""
	,"検索","","","",""
	,"No.","フェイスNo","棚段","",""
	,"","No.","フェイスNo","棚段",""
	,"","","No.","フェイスNo","棚段"
	,"","","","No.","フェイスNo"
	,"棚段","","","","No."
	,"フェイスNo","棚段","","",""
	,"No.","フェイスNo","棚段","",""
	,"","No.","フェイスNo","棚段",""
	,"","","確定"
);

