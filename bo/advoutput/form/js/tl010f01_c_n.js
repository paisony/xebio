var ADVIT_FORMID = "TL010F01";
var ADVIT_TARGETPGID = "tl010p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tl010f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,26,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,34,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_KAISHI_JYOTAI = 3;
var ADVIT_ID_BUMON_CD_FROM = 4;
var ADVIT_ID_BTNBUMON_CD_FROM = 5;
var ADVIT_ID_BUMON_NM_FROM = 6;
var ADVIT_ID_BUMON_CD_TO = 7;
var ADVIT_ID_BTNBUMON_CD_TO = 8;
var ADVIT_ID_BUMON_NM_TO = 9;
var ADVIT_ID_BAIHENKAISI_YMD_FROM = 10;
var ADVIT_ID_BAIHENKAISI_YMD_TO = 11;
var ADVIT_ID_OLD_JISYA_HBN = 12;
var ADVIT_ID_MAKER_HBN = 13;
var ADVIT_ID_SEARCHCNT = 14;
var ADVIT_ID_EIGYO_YMD_HDN = 15;
var ADVIT_ID_EIGYO_YMD_HDN2 = 16;
var ADVIT_ID_BTNSEARCH = 17;
var ADVIT_ID_SHUTURYOKU_SEAL = 18;
var ADVIT_ID_BTNPRINT = 19;
var ADVIT_ID_BTNSEAL = 20;
var ADVIT_ID_PGR = 21;
var ADVIT_ID_BTNLABEL_CD = 22;
var ADVIT_ID_LABEL_CD = 23;
var ADVIT_ID_LABEL_IP = 24;
var ADVIT_ID_LABEL_NM = 25;
var ADVIT_ID_M1ROWNO = 26;
var ADVIT_ID_M1BUMON_CD = 27;
var ADVIT_ID_M1BUMONKANA_NM = 28;
var ADVIT_ID_M1BAIHENKAISI_YMD = 29;
var ADVIT_ID_M1HINBAN_SU = 30;
var ADVIT_ID_M1ZAIKO_SU = 31;
var ADVIT_ID_M1SELECTORCHECKBOX = 32;
var ADVIT_ID_M1ENTERSYORIFLG = 33;
var ADVIT_ID_M1DTLIROKBN = 34;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Kaishi_jyotai","Bumon_cd_from"
	,"Btnbumon_cd_from","Bumon_nm_from","Bumon_cd_to","Btnbumon_cd_to","Bumon_nm_to"
	,"Baihenkaisi_ymd_from","Baihenkaisi_ymd_to","Old_jisya_hbn","Maker_hbn","Searchcnt"
	,"Eigyo_ymd_hdn","Eigyo_ymd_hdn2","Btnsearch","Shuturyoku_seal","Btnprint"
	,"Btnseal","Pgr","Btnlabel_cd","Label_cd","Label_ip"
	,"Label_nm","M1rowno","M1bumon_cd","M1bumonkana_nm","M1baihenkaisi_ymd"
	,"M1hinban_su","M1zaiko_su","M1selectorcheckbox","M1entersyoriflg","M1dtlirokbn"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","開始状態","部門コードFROM"
	,"部門コードFROMボタン","部門名FROM","部門コードTO","部門コードTOボタン","部門名TO"
	,"売変開始日FROM","売変開始日TO","旧自社品番","メーカー品番","検索件数"
	,"営業日（隠し）","営業日（隠し）２","検索ボタン","出力シール","印刷ボタン"
	,"シール発行ボタン","ページャ","ラベル発行機コードボタン","ラベル発行機ＩＤ","ラベル発行機ＩＰ"
	,"ラベル発行機名","Ｍ１行NO","Ｍ１部門リンク","Ｍ１部門カナ名","Ｍ１売変開始日"
	,"Ｍ１品番数","Ｍ１在庫数","Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","SN5","SG"
	,"B","SN4","SG","B","SN4"
	,"D","D","SG","SN9","NA"
	,"D","D","B","SN5","B"
	,"B","B","B","SN4","SG"
	,"SN4","NA","B","B","D"
	,"NA","NA","NA","NA","NA"
);
var ADVIT_LENGTH = new Array(
	4,0,15,1,3
	,0,15,3,0,15
	,0,0,10,30,4
	,0,0,0,1,0
	,0,0,0,7,12
	,10,3,0,0,0
	,5,6,1,1,2
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
	1,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","DRL","TXT"
	,"BTN","TXR","TXT","BTN","TXR"
	,"TXT","TXT","TXT","TXR","TXR"
	,"HDN","HDN","BTS","RDO","BTS"
	,"BTS","LNS","BTN","HDN","HDN"
	,"TXR","TXR","BTS","BTS","TXR"
	,"TXR","TXR","CHK","HDN","HDN"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","00","10"
	,"00","00","10","00","00"
	,"52","52","00","00","12"
	,"52","52","00","00","00"
	,"00","00","00","00","00"
	,"00","11","00","00","52"
	,"12","12","11","11","11"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"C_BUMON_CD","","","C_BUMON_CD",""
	,"","","","",""
	,"","","","",""
	,"","","C_LABEL_CD","",""
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
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,1,0,1
	,1,1,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
);
var ADVIT_IMEMODE = new Array(
	3,0,0,0,3
	,0,0,3,0,0
	,3,3,3,0,0
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
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,0,1
	,0,0,1,0,0
	,1,1,1,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
);
var ADVIT_CONDID = new Array(
	"","","","KAISHI_JYOTAI",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
);
var ADVIT_ACTIONID = new Array(
	"","COD","","",""
	,"COD","","","COD",""
	,"","","","",""
	,"","","FRM","","FRM"
	,"FRM","PGN","COD","",""
	,"","","FRM","FRM",""
	,"","","","",""
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","TL010F01","","TL010F01"
	,"TL010F01","","","",""
	,"","","TL010F02","TL010F02",""
	,"","","","",""
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","M1","","",""
	,"","","M1","M1",""
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
	"店舗","","","開始状態","部門ＦＲＯＭ"
	,"","","部門ＴＯ","",""
	,"開始日ＦＲＯＭ","開始日ＴＯ","自社品番","",""
	,"","","検索","出力シール",""
	,"","","","",""
	,"","No.","部門","","開始日"
	,"品番数","在庫点数","","",""
);

