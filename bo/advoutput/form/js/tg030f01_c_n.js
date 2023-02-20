var ADVIT_FORMID = "TG030F01";
var ADVIT_TARGETPGID = "tg030p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tg030f01.aspx";

var ADVIT_M_PATTERN = new Array(0,0,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,-1,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,-1,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_MAISU = 3;
var ADVIT_ID_TANTOSYA_CD = 4;
var ADVIT_ID_BTNTANTO_CD = 5;
var ADVIT_ID_HANBAIIN_NM = 6;
var ADVIT_ID_TANTOSYA_CD2 = 7;
var ADVIT_ID_BTNSEAL = 8;
var ADVIT_ID_BTNLABEL_CD = 9;
var ADVIT_ID_LABEL_CD = 10;
var ADVIT_ID_LABEL_IP = 11;
var ADVIT_ID_LABEL_NM = 12;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Maisu","Tantosya_cd"
	,"Btntanto_cd","Hanbaiin_nm","Tantosya_cd2","Btnseal","Btnlabel_cd"
	,"Label_cd","Label_ip","Label_nm"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","枚数","担当者コード"
	,"担当者コードボタン","担当者名","担当者コード２","シール発行ボタン","ラベル発行機コードボタン"
	,"ラベル発行機ＩＤ","ラベル発行機ＩＰ","ラベル発行機名"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","NA","SG"
	,"B","SN4","SG","B","B"
	,"SN4","SG","SN4"
);
var ADVIT_LENGTH = new Array(
	4,0,15,2,7
	,0,12,7,0,0
	,7,12,10
);
var ADVIT_AUTOTAB = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0
);
var ADVIT_DECIMAL = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0
);
var ADVIT_REQUIRED = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0
);
var ADVIT_REQUIREDFLG = new Array(
	1,0,0,1,1
	,0,0,1,0,0
	,0,0,0
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","TXT","TXT"
	,"BTN","TXR","TXT","BTS","BTN"
	,"HDN","HDN","TXR"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","11","10"
	,"00","00","10","00","00"
	,"00","00","00"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"C_TANTO_CD","","","","C_LABEL_CD"
	,"","",""
);
var ADVIT_CODENAME = new Array(
	"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET"
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
	,"","",""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,1,0
	,0,0,0
);
var ADVIT_IMEMODE = new Array(
	3,0,0,3,3
	,0,0,3,0,0
	,0,0,0
);
var ADVIT_AUTOCODECHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,1,1
	,0,0,1,0,0
	,0,0,0
);
var ADVIT_CONDID = new Array(
	"","","","",""
	,"","","","",""
	,"","",""
);
var ADVIT_ACTIONID = new Array(
	"","COD","","",""
	,"COD","","","FRM","COD"
	,"","",""
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","",""
	,"","","","TG030F01",""
	,"","",""
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","",""
);
var ADVIT_ACTPROGRAMID = new Array(
	"","","","",""
	,"","","","",""
	,"","",""
);
var ADVIT_CAPTION = new Array(
	"店舗","","","発行枚数","社員コード"
	,"","","社員コード(確認用)","",""
	,"","",""
);

