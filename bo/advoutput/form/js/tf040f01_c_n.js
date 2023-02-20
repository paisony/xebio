var ADVIT_FORMID = "TF040F01";
var ADVIT_TARGETPGID = "tf040p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tf040f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,9,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,26,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_ZENJITU_ZANDAKA = 3;
var ADVIT_ID_ZENGETU_ZANDAKA = 4;
var ADVIT_ID_BTNSEARCH = 5;
var ADVIT_ID_BTNROWINS = 6;
var ADVIT_ID_BTNROWDEL = 7;
var ADVIT_ID_PGR = 8;
var ADVIT_ID_M1ROWNO = 9;
var ADVIT_ID_M1KANRI_NO = 10;
var ADVIT_ID_M1MOTOKANRI_NO = 11;
var ADVIT_ID_M1KEIJO_YMD = 12;
var ADVIT_ID_M1KAMOKU_CD = 13;
var ADVIT_ID_M1BTNKAMOKUCD = 14;
var ADVIT_ID_M1KAMOKU_NM = 15;
var ADVIT_ID_M1NYUKIN = 16;
var ADVIT_ID_M1NYUKIN_HDN = 17;
var ADVIT_ID_M1SYUKKIN = 18;
var ADVIT_ID_M1SYUKKIN_HDN = 19;
var ADVIT_ID_M1TEKIYOU = 20;
var ADVIT_ID_M1HURIKAETENPO_CD = 21;
var ADVIT_ID_M1BTNTENPOCD = 22;
var ADVIT_ID_M1HURIKAETENPO_NM = 23;
var ADVIT_ID_M1SELECTORCHECKBOX = 24;
var ADVIT_ID_M1ENTERSYORIFLG = 25;
var ADVIT_ID_M1DTLIROKBN = 26;
var ADVIT_ID_GOKEI_ZANDAKA = 27;
var ADVIT_ID_BTNENTER = 28;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Zenjitu_zandaka","Zengetu_zandaka"
	,"Btnsearch","Btnrowins","Btnrowdel","Pgr","M1rowno"
	,"M1kanri_no","M1motokanri_no","M1keijo_ymd","M1kamoku_cd","M1btnkamokucd"
	,"M1kamoku_nm","M1nyukin","M1nyukin_hdn","M1syukkin","M1syukkin_hdn"
	,"M1tekiyou","M1hurikaetenpo_cd","M1btntenpocd","M1hurikaetenpo_nm","M1selectorcheckbox"
	,"M1entersyoriflg","M1dtlirokbn","Gokei_zandaka","Btnenter"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","前日残高","前月残高"
	,"検索ボタン","行追加ボタン","行削除ボタン","ページャ","Ｍ１行NO"
	,"Ｍ１管理No","Ｍ１元管理No","Ｍ１計上日付","Ｍ１科目コード","Ｍ１科目コードボタン"
	,"Ｍ１科目名","Ｍ１入金","M１入金(隠し)","Ｍ１出金","M1出金(隠し)"
	,"Ｍ１摘要","Ｍ１振替店舗コード","Ｍ１店舗コードボタン","Ｍ１振替店舗名","Ｍ１選択フラグ(隠し)"
	,"Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)","合計残高","確定ボタン"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","NA","NA"
	,"B","B","B","B","NA"
	,"NA","SG","D","SG","B"
	,"SN4","NC","NA","NC","NA"
	,"SN22","SG","B","SN4","NA"
	,"NA","NA","NA","B"
);
var ADVIT_LENGTH = new Array(
	4,0,15,9,9
	,0,0,0,0,4
	,6,6,0,8,0
	,20,9,9,9,9
	,32,4,0,15,1
	,1,2,9,0
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
	1,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","TXR","TXR"
	,"BTS","BTS","BTS","LNS","TXR"
	,"TXR","TXT","TXT","TXT","BTN"
	,"TXR","TXT","HDN","TXT","HDN"
	,"TXT","TXT","BTN","TXR","CHK"
	,"HDN","HDN","TXR","BTS"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","12","12"
	,"00","00","00","00","11"
	,"10","10","52","10","00"
	,"00","12","12","12","12"
	,"00","10","00","00","11"
	,"11","11","12","00"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"","","","",""
	,"","","","","C_KAMOKU_CD"
	,"","","","",""
	,"","","C_TENPO_CD","",""
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
	,"","","","","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","",""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,1,0,0,1,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,1
);
var ADVIT_IMEMODE = new Array(
	3,0,0,0,0
	,0,0,0,0,0
	,0,3,3,3,0
	,0,3,0,3,0
	,1,3,0,0,0
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
	1,0,0,0,0
	,0,0,0,0,0
	,0,1,1,1,0
	,0,1,0,1,0
	,1,1,0,0,0
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
	"","COD","","",""
	,"FRM","MADD","FRM","PGN",""
	,"","","","","COD"
	,"","","","",""
	,"","","COD","",""
	,"","","","FRM"
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","",""
	,"TF040F01","","TF040F01","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","TF040F01"
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","M1","","M1",""
	,"","","","",""
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
	"店舗","","","前日残高","前月残高"
	,"検索","","","","No."
	,"管理No","元No","日付","科目",""
	,"","入金","","出金",""
	,"摘要","振替店舗","","",""
	,"","","残高","確定"
);

