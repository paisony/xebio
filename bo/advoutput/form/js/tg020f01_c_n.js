var ADVIT_FORMID = "TG020F01";
var ADVIT_TARGETPGID = "tg020p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tg020f01.aspx";

var ADVIT_M_PATTERN = new Array(0,0,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,-1,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,-1,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_BTNMODEPERCENTOFF = 3;
var ADVIT_ID_BTNMODEYENHIKI = 4;
var ADVIT_ID_WARIRIT = 5;
var ADVIT_ID_MAISU = 6;
var ADVIT_ID_INJI_COMMENT = 7;
var ADVIT_ID_INJI_COMMENT_NM = 8;
var ADVIT_ID_WARIGAK = 9;
var ADVIT_ID_MAISU2 = 10;
var ADVIT_ID_INJI_COMMENT2 = 11;
var ADVIT_ID_INJI_COMMENT_NM2 = 12;
var ADVIT_ID_BTNSEAL = 13;
var ADVIT_ID_BTNLABEL_CD = 14;
var ADVIT_ID_LABEL_CD = 15;
var ADVIT_ID_LABEL_IP = 16;
var ADVIT_ID_LABEL_NM = 17;
var ADVIT_ID_MODENO = 18;
var ADVIT_ID_STKMODENO = 19;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Btnmodepercentoff","Btnmodeyenhiki"
	,"Waririt","Maisu","Inji_comment","Inji_comment_nm","Warigak"
	,"Maisu2","Inji_comment2","Inji_comment_nm2","Btnseal","Btnlabel_cd"
	,"Label_cd","Label_ip","Label_nm","Modeno","Stkmodeno"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","モード％OFFボタン","モード円引きボタン"
	,"割引率","枚数","印字コメント","印字コメント名称","割引額"
	,"枚数２","印字コメント２","印字コメント名称２","シール発行ボタン","ラベル発行機コードボタン"
	,"ラベル発行機ＩＤ","ラベル発行機ＩＰ","ラベル発行機名","モードNO","選択モードNO"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","B","B"
	,"NA","NA","NA","SN4","NA"
	,"NA","NA","SN4","B","B"
	,"SN4","SG","SN4","NA","NA"
);
var ADVIT_LENGTH = new Array(
	4,0,15,0,0
	,2,3,1,8,5
	,3,1,8,0,0
	,7,12,10,2,2
);
var ADVIT_AUTOTAB = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
);
var ADVIT_DECIMAL = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
);
var ADVIT_REQUIRED = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
);
var ADVIT_REQUIREDFLG = new Array(
	1,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","LNK","LNK"
	,"TXT","TXT","DRL","TXT","TXT"
	,"TXT","DRL","TXT","BTS","BTN"
	,"HDN","HDN","TXR","HDN","HDN"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","00","00"
	,"12","12","10","00","12"
	,"12","10","00","00","00"
	,"00","00","00","11","11"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"","","","",""
	,"","","","","C_LABEL_CD"
	,"","","","",""
);
var ADVIT_CODENAME = new Array(
	"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,1,0
	,0,0,0,0,0
);
var ADVIT_IMEMODE = new Array(
	3,0,0,0,0
	,3,3,0,1,3
	,3,0,1,0,0
	,0,0,0,0,0
);
var ADVIT_AUTOCODECHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,0,0
	,1,1,0,1,1
	,1,0,1,0,0
	,0,0,0,0,0
);
var ADVIT_CONDID = new Array(
	"","","","",""
	,"","","INJI_COMMENT","",""
	,"","INJI_COMMENT","","",""
	,"","","","",""
);
var ADVIT_ACTIONID = new Array(
	"","COD","","SPT","SPT"
	,"","","","",""
	,"","","","FRM","COD"
	,"","","","",""
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","TG020F01","TG020F01"
	,"","","","",""
	,"","","","TG020F01",""
	,"","","","",""
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
);
var ADVIT_ACTPROGRAMID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
);
var ADVIT_CAPTION = new Array(
	"店舗","","","％OFF","円引き"
	,"割引率","発行枚数","印字コメント","","割引額"
	,"発行枚数","印字コメント","","",""
	,"","","","",""
);

