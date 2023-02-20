var ADVIT_FORMID = "TF060F01";
var ADVIT_TARGETPGID = "tf060p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tf060f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,12,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,27,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_GETUDO = 3;
var ADVIT_ID_BTNSEARCH = 4;
var ADVIT_ID_BTNCSV_TORIKOMI = 5;
var ADVIT_ID_TUKIBETU_BUMON1_YOSAN_KIN = 6;
var ADVIT_ID_TUKIBETU_BUMON2_YOSAN_KIN = 7;
var ADVIT_ID_TUKIBETU_BUMON3_YOSAN_KIN = 8;
var ADVIT_ID_TUKIBETU_BUMON4_YOSAN_KIN = 9;
var ADVIT_ID_TUKIBETU_BUMON5_YOSAN_KIN = 10;
var ADVIT_ID_TUKIBETU_YOSAN_KIN_GOKEI = 11;
var ADVIT_ID_M1GETUNAI_HIDUKE = 12;
var ADVIT_ID_M1YOBI = 13;
var ADVIT_ID_M1BUMON1_YOSAN_KIN = 14;
var ADVIT_ID_M1BUMON2_YOSAN_KIN = 15;
var ADVIT_ID_M1BUMON3_YOSAN_KIN = 16;
var ADVIT_ID_M1BUMON4_YOSAN_KIN = 17;
var ADVIT_ID_M1BUMON5_YOSAN_KIN = 18;
var ADVIT_ID_M1HIBETU_YOSAN_KIN = 19;
var ADVIT_ID_M1BUMON1_YOSAN_KIN_HDN = 20;
var ADVIT_ID_M1BUMON2_YOSAN_KIN_HDN = 21;
var ADVIT_ID_M1BUMON3_YOSAN_KIN_HDN = 22;
var ADVIT_ID_M1BUMON4_YOSAN_KIN_HDN = 23;
var ADVIT_ID_M1BUMON5_YOSAN_KIN_HDN = 24;
var ADVIT_ID_M1SELECTORCHECKBOX = 25;
var ADVIT_ID_M1ENTERSYORIFLG = 26;
var ADVIT_ID_M1DTLIROKBN = 27;
var ADVIT_ID_BUMON1_YOSANGOKEI_KIN = 28;
var ADVIT_ID_BUMON2_YOSANGOKEI_KIN = 29;
var ADVIT_ID_BUMON3_YOSANGOKEI_KIN = 30;
var ADVIT_ID_BUMON4_YOSANGOKEI_KIN = 31;
var ADVIT_ID_BUMON5_YOSANGOKEI_KIN = 32;
var ADVIT_ID_YOSANGOKEI_KIN = 33;
var ADVIT_ID_BTNENTER = 34;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Getudo","Btnsearch"
	,"Btncsv_torikomi","Tukibetu_bumon1_yosan_kin","Tukibetu_bumon2_yosan_kin","Tukibetu_bumon3_yosan_kin","Tukibetu_bumon4_yosan_kin"
	,"Tukibetu_bumon5_yosan_kin","Tukibetu_yosan_kin_gokei","M1getunai_hiduke","M1yobi","M1bumon1_yosan_kin"
	,"M1bumon2_yosan_kin","M1bumon3_yosan_kin","M1bumon4_yosan_kin","M1bumon5_yosan_kin","M1hibetu_yosan_kin"
	,"M1bumon1_yosan_kin_hdn","M1bumon2_yosan_kin_hdn","M1bumon3_yosan_kin_hdn","M1bumon4_yosan_kin_hdn","M1bumon5_yosan_kin_hdn"
	,"M1selectorcheckbox","M1entersyoriflg","M1dtlirokbn","Bumon1_yosangokei_kin","Bumon2_yosangokei_kin"
	,"Bumon3_yosangokei_kin","Bumon4_yosangokei_kin","Bumon5_yosangokei_kin","Yosangokei_kin","Btnenter"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","月度","検索ボタン"
	,"CSV取込ボタン","月別部門１予算額","月別部門２予算額","月別部門３予算額","月別部門４予算額"
	,"月別部門５予算額","月別予算額合計","Ｍ１月内日付","Ｍ１曜日","Ｍ１部門１予算額"
	,"Ｍ１部門２予算額","Ｍ１部門３予算額","Ｍ１部門４予算額","Ｍ１部門５予算額","Ｍ１日別予算額"
	,"Ｍ１部門１予算額(隠し)","Ｍ１部門２予算額(隠し)","Ｍ１部門３予算額(隠し)","Ｍ１部門４予算額(隠し)","Ｍ１部門５予算額(隠し)"
	,"Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)","部門１予算額合計","部門２予算額合計"
	,"部門３予算額合計","部門４予算額合計","部門５予算額合計","予算額合計","確定ボタン"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","NA","B"
	,"B","NA","NA","NA","NA"
	,"NA","NA","NA","SN4","NA"
	,"NA","NA","NA","NA","NA"
	,"NA","NA","NA","NA","NA"
	,"NA","NA","NA","NA","NA"
	,"NA","NA","NA","NA","B"
);
var ADVIT_LENGTH = new Array(
	4,0,15,2,0
	,0,6,6,6,6
	,6,6,2,1,6
	,6,6,6,6,6
	,6,6,6,6,6
	,1,1,2,6,6
	,6,6,6,6,0
);
var ADVIT_AUTOTAB = new Array(
	0,0,0,0,0
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
);
var ADVIT_REQUIRED = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
);
var ADVIT_REQUIREDFLG = new Array(
	1,0,0,1,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","TXT","BTS"
	,"BTS","TXT","TXT","TXT","TXT"
	,"TXT","TXR","TXR","TXR","TXT"
	,"TXT","TXT","TXT","TXT","TXR"
	,"HDN","HDN","HDN","HDN","HDN"
	,"CHK","HDN","HDN","TXR","TXR"
	,"TXR","TXR","TXR","TXR","BTS"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","10","00"
	,"00","12","12","12","12"
	,"12","12","11","00","12"
	,"12","12","12","12","12"
	,"12","12","12","12","12"
	,"11","11","11","12","12"
	,"12","12","12","12","00"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
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
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
	,"","","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","",""
	,"","","","",""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,1
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,1
);
var ADVIT_IMEMODE = new Array(
	3,0,0,3,0
	,0,3,3,3,3
	,3,0,0,0,3
	,3,3,3,3,0
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
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,1,0
	,0,1,1,1,1
	,1,0,0,0,1
	,1,1,1,1,0
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
	,"","","","",""
	,"","","","",""
);
var ADVIT_ACTIONID = new Array(
	"","COD","","","FRM"
	,"FRM","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","","FRM"
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","","TF060F01"
	,"TF060F01","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","","TF060F01"
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
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
);
var ADVIT_CAPTION = new Array(
	"店舗","","","月度","検索"
	,"","部門１","部門２","部門３","部門４"
	,"部門５","","日","曜日","部門１"
	,"部門２","部門３","部門４","部門５","合計"
	,"","","","",""
	,"","","","合計",""
	,"","","","","確定"
);

