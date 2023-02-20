var ADVIT_FORMID = "TJ120F02";
var ADVIT_TARGETPGID = "tj120p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tj120f02.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,13,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,27,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_BTNBACK = 0;
var ADVIT_ID_HEAD_TENPO_CD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_MODENO = 3;
var ADVIT_ID_STKMODENO = 4;
var ADVIT_ID_FACE_NO = 5;
var ADVIT_ID_TANA_DAN = 6;
var ADVIT_ID_KAI_SU = 7;
var ADVIT_ID_NYURYOKUTAN_CD = 8;
var ADVIT_ID_NYURYOKUTAN_NM = 9;
var ADVIT_ID_NYURYOKU_YMD = 10;
var ADVIT_ID_BTNPRINT = 11;
var ADVIT_ID_PGR = 12;
var ADVIT_ID_M1ROWNO = 13;
var ADVIT_ID_M1BUMON_CD = 14;
var ADVIT_ID_M1BUMONKANA_NM = 15;
var ADVIT_ID_M1HINSYU_RYAKU_NM = 16;
var ADVIT_ID_M1BURANDO_NM = 17;
var ADVIT_ID_M1JISYA_HBN = 18;
var ADVIT_ID_M1MAKER_HBN = 19;
var ADVIT_ID_M1SYONMK = 20;
var ADVIT_ID_M1IRO_NM = 21;
var ADVIT_ID_M1SIZE_NM = 22;
var ADVIT_ID_M1SCAN_CD = 23;
var ADVIT_ID_M1SCAN_SU = 24;
var ADVIT_ID_M1SELECTORCHECKBOX = 25;
var ADVIT_ID_M1ENTERSYORIFLG = 26;
var ADVIT_ID_M1DTLIROKBN = 27;
var ADVIT_ID_GOKEISCAN_SU = 28;

var ADVIT_ID = new Array(
	"Btnback","Head_tenpo_cd","Head_tenpo_nm","Modeno","Stkmodeno"
	,"Face_no","Tana_dan","Kai_su","Nyuryokutan_cd","Nyuryokutan_nm"
	,"Nyuryoku_ymd","Btnprint","Pgr","M1rowno","M1bumon_cd"
	,"M1bumonkana_nm","M1hinsyu_ryaku_nm","M1burando_nm","M1jisya_hbn","M1maker_hbn"
	,"M1syonmk","M1iro_nm","M1size_nm","M1scan_cd","M1scan_su"
	,"M1selectorcheckbox","M1entersyoriflg","M1dtlirokbn","Gokeiscan_su"
);
var ADVIT_NAME = new Array(
	"戻るボタン","ヘッダ店舗コード","ヘッダ店舗名","モードNO","選択モードNO"
	,"フェイス№","棚段","回数","入力担当者コード","入力担当者名称"
	,"入力日","印刷ボタン","ページャ","Ｍ１行NO","Ｍ１部門コード"
	,"Ｍ１部門カナ名","Ｍ１品種略名称","Ｍ１ブランド名","Ｍ１自社品番","Ｍ１メーカー品番"
	,"Ｍ１商品名(カナ)","Ｍ１色","Ｍ１サイズ","Ｍ１スキャンコード","Ｍ１スキャン数量"
	,"Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)","合計スキャン数量"
);
var ADVIT_ATTRIBUTE = new Array(
	"B","SG","SN4","NA","NA"
	,"NA","NA","NA","SG","SN4"
	,"D","B","B","NA","SG"
	,"SN9","SN4","SN9","SG","SN9"
	,"SN9","SN9","SN9","SG","NA"
	,"NA","NA","NA","NA"
);
var ADVIT_LENGTH = new Array(
	0,4,15,2,2
	,5,2,2,7,12
	,0,0,0,4,3
	,30,15,20,8,30
	,30,10,4,18,4
	,1,1,2,6
);
var ADVIT_AUTOTAB = new Array(
	0,0,0,0,0
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
	,0,0,0,0
);
var ADVIT_REQUIRED = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0
);
var ADVIT_REQUIREDFLG = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0
);
var ADVIT_TYPE = new Array(
	"BTS","TXR","TXR","HDN","HDN"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","BTS","LNS","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"CHK","HDN","HDN","TXR"
);
var ADVIT_FORMAT = new Array(
	"00","10","00","11","11"
	,"10","11","11","10","00"
	,"52","00","00","11","10"
	,"00","00","00","10","00"
	,"00","00","00","00","12"
	,"11","11","11","12"
);
var ADVIT_CODEID = new Array(
	"","","","",""
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
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
	,"","","","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1",""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,1,1,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0
);
var ADVIT_IMEMODE = new Array(
	0,0,0,0,0
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
	,0,0,0,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0
);
var ADVIT_CONDID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","",""
);
var ADVIT_ACTIONID = new Array(
	"FRM","","","",""
	,"","","","",""
	,"","FRM","PGN","",""
	,"","","","",""
	,"","","","",""
	,"","","",""
);
var ADVIT_ACTIONFORMID = new Array(
	"TJ120F01","","","",""
	,"","","","",""
	,"","TJ120F02","","",""
	,"","","","",""
	,"","","","",""
	,"","","",""
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","M1","",""
	,"","","","",""
	,"","","","",""
	,"","","",""
);
var ADVIT_ACTPROGRAMID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","",""
);
var ADVIT_CAPTION = new Array(
	"","","","",""
	,"フェイスNo","棚段","回数","入力担当者",""
	,"入力日","","","No.","部門"
	,"","品種","ブランド","自社品番","メーカー品番"
	,"商品名","色","サイズ","スキャンコード","ｽｷｬﾝ数量"
	,"","","","合計"
);

