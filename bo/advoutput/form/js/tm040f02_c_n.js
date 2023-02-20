var ADVIT_FORMID = "TM040F02";
var ADVIT_TARGETPGID = "tm040p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tm040f02.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,9,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,17,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_BTNBACK = 0;
var ADVIT_ID_STKMODENO = 1;
var ADVIT_ID_OLD_JISYA_HBN = 2;
var ADVIT_ID_BUMON_NM = 3;
var ADVIT_ID_HINSYU_RYAKU_NM = 4;
var ADVIT_ID_BURANDO_NM = 5;
var ADVIT_ID_MAKER_HBN = 6;
var ADVIT_ID_SYONMK = 7;
var ADVIT_ID_IRO_NM = 8;
var ADVIT_ID_M1ROWNO = 9;
var ADVIT_ID_M1SCAN_CD = 10;
var ADVIT_ID_M1SIZE_NM = 11;
var ADVIT_ID_M1LOT_SU = 12;
var ADVIT_ID_M1HAIBUNKANO_SU = 13;
var ADVIT_ID_M1ITEMSU = 14;
var ADVIT_ID_M1SELECTORCHECKBOX = 15;
var ADVIT_ID_M1ENTERSYORIFLG = 16;
var ADVIT_ID_M1DTLIROKBN = 17;
var ADVIT_ID_BTNENTER = 18;

var ADVIT_ID = new Array(
	"Btnback","Stkmodeno","Old_jisya_hbn","Bumon_nm","Hinsyu_ryaku_nm"
	,"Burando_nm","Maker_hbn","Syonmk","Iro_nm","M1rowno"
	,"M1scan_cd","M1size_nm","M1lot_su","M1haibunkano_su","M1itemsu"
	,"M1selectorcheckbox","M1entersyoriflg","M1dtlirokbn","Btnenter"
);
var ADVIT_NAME = new Array(
	"戻るボタン","選択モードNO","旧自社品番","部門名","品種略名称"
	,"ブランド名","メーカー品番","商品名(カナ)","色","Ｍ１行NO"
	,"Ｍ１スキャンコード","Ｍ１サイズ","Ｍ１ロット数","Ｍ１配分可能数","Ｍ１数量"
	,"Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)","確定ボタン"
);
var ADVIT_ATTRIBUTE = new Array(
	"B","NA","SG","SN4","SN4"
	,"SN9","SN9","SN9","SN9","NA"
	,"SG","SN9","NA","NA","NA"
	,"NA","NA","NA","B"
);
var ADVIT_LENGTH = new Array(
	0,2,10,15,15
	,20,30,30,10,2
	,18,4,5,7,7
	,1,1,2,0
);
var ADVIT_AUTOTAB = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0
);
var ADVIT_DECIMAL = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0
);
var ADVIT_REQUIRED = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0
);
var ADVIT_REQUIREDFLG = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0
);
var ADVIT_TYPE = new Array(
	"BTS","HDN","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXT"
	,"CHK","HDN","HDN","BTS"
);
var ADVIT_FORMAT = new Array(
	"00","11","00","00","00"
	,"00","00","00","00","11"
	,"00","00","12","12","12"
	,"11","11","11","00"
);
var ADVIT_CODEID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","",""
);
var ADVIT_CODENAME = new Array(
	"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1",""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,1
);
var ADVIT_IMEMODE = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,3
	,0,0,0,0
);
var ADVIT_AUTOCODECHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,1
	,0,0,0,0
);
var ADVIT_CONDID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","",""
);
var ADVIT_ACTIONID = new Array(
	"FRM","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","FRM"
);
var ADVIT_ACTIONFORMID = new Array(
	"TM040F01","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","TM040F02"
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","",""
);
var ADVIT_ACTPROGRAMID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","",""
);
var ADVIT_CAPTION = new Array(
	"","","自社品番","部門","品種"
	,"ブランド","メーカー品番","商品名","色","No."
	,"スキャンコード","サイズ","ロット","配分可能数","数量"
	,"","","","確定"
);

