var ADVIT_FORMID = "TF030F02";
var ADVIT_TARGETPGID = "tf030p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tf030f02.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,21,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,32,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_BTNBACK = 0;
var ADVIT_ID_HEAD_TENPO_CD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_STKMODENO = 3;
var ADVIT_ID_ADD_YMD = 4;
var ADVIT_ID_TENPO_CD = 5;
var ADVIT_ID_BTNTENPOCD = 6;
var ADVIT_ID_TENPO_NM = 7;
var ADVIT_ID_KENPINSYA_CD = 8;
var ADVIT_ID_BTNTANTO_CD = 9;
var ADVIT_ID_KENPINSYA_NM = 10;
var ADVIT_ID_SIIRESAKI_CD = 11;
var ADVIT_ID_BTNSIIRESAKI_CD = 12;
var ADVIT_ID_SIIRESAKI_RYAKU_NM = 13;
var ADVIT_ID_DENPYO_BANGO = 14;
var ADVIT_ID_MOTODENPYO_BANGO = 15;
var ADVIT_ID_NYURYOKUTAN_CD = 16;
var ADVIT_ID_NYURYOKUTAN_NM = 17;
var ADVIT_ID_NOHIN_YMD = 18;
var ADVIT_ID_BTNROWINS = 19;
var ADVIT_ID_BTNROWDEL = 20;
var ADVIT_ID_M1ROWNO = 21;
var ADVIT_ID_M1TEKIYO_CD = 22;
var ADVIT_ID_M1BTNTEKIYO_CD = 23;
var ADVIT_ID_M1TEKIYO_NM = 24;
var ADVIT_ID_M1SURYO = 25;
var ADVIT_ID_M1TNK = 26;
var ADVIT_ID_M1KINGAKU = 27;
var ADVIT_ID_M1SURYO_HDN = 28;
var ADVIT_ID_M1KINGAKU_HDN = 29;
var ADVIT_ID_M1SELECTORCHECKBOX = 30;
var ADVIT_ID_M1ENTERSYORIFLG = 31;
var ADVIT_ID_M1DTLIROKBN = 32;
var ADVIT_ID_GOKEI_SURYO = 33;
var ADVIT_ID_GOKEI_KIN = 34;
var ADVIT_ID_BTNENTER = 35;

var ADVIT_ID = new Array(
	"Btnback","Head_tenpo_cd","Head_tenpo_nm","Stkmodeno","Add_ymd"
	,"Tenpo_cd","Btntenpocd","Tenpo_nm","Kenpinsya_cd","Btntanto_cd"
	,"Kenpinsya_nm","Siiresaki_cd","Btnsiiresaki_cd","Siiresaki_ryaku_nm","Denpyo_bango"
	,"Motodenpyo_bango","Nyuryokutan_cd","Nyuryokutan_nm","Nohin_ymd","Btnrowins"
	,"Btnrowdel","M1rowno","M1tekiyo_cd","M1btntekiyo_cd","M1tekiyo_nm"
	,"M1suryo","M1tnk","M1kingaku","M1suryo_hdn","M1kingaku_hdn"
	,"M1selectorcheckbox","M1entersyoriflg","M1dtlirokbn","Gokei_suryo","Gokei_kin"
	,"Btnenter"
);
var ADVIT_NAME = new Array(
	"戻るボタン","ヘッダ店舗コード","ヘッダ店舗名","選択モードNO","登録日"
	,"店舗コード","店舗コードボタン","店舗名","検品者コード","担当者コードボタン"
	,"検品者名称","仕入先コード","仕入先コードボタン","仕入先略式名称","伝票番号"
	,"元伝票番号","入力担当者コード","入力担当者名称","納品日","行追加ボタン"
	,"行削除ボタン","Ｍ１行NO","Ｍ１摘要コード","Ｍ１摘要コードボタン","Ｍ１摘要名"
	,"Ｍ１数量","Ｍ１単価","Ｍ１金額","Ｍ１数量(隠し)","Ｍ１金額(隠し)"
	,"Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)","合計数量","合計金額"
	,"確定ボタン"
);
var ADVIT_ATTRIBUTE = new Array(
	"B","SG","SN4","NA","D"
	,"SG","B","SN4","SG","B"
	,"SN4","SG","B","SN4","SG"
	,"SG","SG","SN4","D","B"
	,"B","NA","SG","B","SN4"
	,"NC","NC","NC","NA","NA"
	,"NA","NA","NA","NA","NA"
	,"B"
);
var ADVIT_LENGTH = new Array(
	0,4,15,2,0
	,4,0,15,7,0
	,12,4,0,20,6
	,6,7,12,0,0
	,0,2,3,0,20
	,5,10,10,5,10
	,1,1,2,6,12
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
	,0
);
var ADVIT_REQUIREDFLG = new Array(
	0,0,0,0,0
	,1,0,0,1,0
	,0,1,0,0,1
	,0,0,0,1,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0
);
var ADVIT_TYPE = new Array(
	"BTS","TXR","TXR","HDN","TXR"
	,"TXT","BTN","TXR","TXT","BTN"
	,"TXR","TXT","BTN","TXR","TXT"
	,"TXT","TXR","TXR","TXT","BTS"
	,"BTS","TXR","TXT","BTN","TXR"
	,"TXT","TXT","TXR","HDN","HDN"
	,"CHK","HDN","HDN","TXR","TXR"
	,"BTS"
);
var ADVIT_FORMAT = new Array(
	"00","10","00","11","52"
	,"10","00","00","10","00"
	,"00","10","00","00","10"
	,"10","10","00","52","00"
	,"00","11","00","00","00"
	,"12","12","12","12","12"
	,"11","11","11","12","12"
	,"00"
);
var ADVIT_CODEID = new Array(
	"","","","",""
	,"","C_TENPO_CD","","","C_TANTO_CD"
	,"","","C_SIIRESAKI_CD","",""
	,"","","","",""
	,"","","","C_TEKIYO_CD",""
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
	,"CANNOTGET"
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","",""
	,""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,1
);
var ADVIT_IMEMODE = new Array(
	0,0,0,0,0
	,3,0,0,3,0
	,0,3,0,0,3
	,3,0,0,3,0
	,0,0,3,0,0
	,3,3,0,0,0
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
	,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	0,0,0,0,0
	,1,0,0,1,0
	,0,1,0,0,1
	,1,0,0,1,0
	,0,0,1,0,0
	,1,1,0,0,0
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
	,""
);
var ADVIT_ACTIONID = new Array(
	"FRM","","","",""
	,"","COD","","","COD"
	,"","","COD","",""
	,"","","","","MADD"
	,"FRM","","","COD",""
	,"","","","",""
	,"","","","",""
	,"FRM"
);
var ADVIT_ACTIONFORMID = new Array(
	"TF030F01","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"TF030F02","","","",""
	,"","","","",""
	,"","","","",""
	,"TF030F01"
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","","M1"
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,""
);
var ADVIT_ACTPROGRAMID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,""
);
var ADVIT_CAPTION = new Array(
	"","","","","登録日"
	,"店舗","","","検品者",""
	,"","取引先","","","伝票番号"
	,"元伝票番号","入力担当者","","納品日",""
	,"","No.","摘要","",""
	,"数量","単価","金額","",""
	,"","","","",""
	,"確定"
);

