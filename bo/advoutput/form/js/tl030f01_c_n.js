var ADVIT_FORMID = "TL030F01";
var ADVIT_TARGETPGID = "tl030p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tl030f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,29,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,41,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_SINSEIMOTO = 3;
var ADVIT_ID_BUMON_CD_FROM = 4;
var ADVIT_ID_BTNBUMON_CD_FROM = 5;
var ADVIT_ID_BUMON_NM_FROM = 6;
var ADVIT_ID_BUMON_CD_TO = 7;
var ADVIT_ID_BTNBUMON_CD_TO = 8;
var ADVIT_ID_BUMON_NM_TO = 9;
var ADVIT_ID_SINSEITAN_CD = 10;
var ADVIT_ID_BTNTANTO_CD = 11;
var ADVIT_ID_SINSEITAN_NM = 12;
var ADVIT_ID_BAIHEN_SHIJI_NO_FROM = 13;
var ADVIT_ID_BAIHEN_SHIJI_NO_TO = 14;
var ADVIT_ID_BAIHENSAGYOKAISI_YMD_FROM = 15;
var ADVIT_ID_BAIHENSAGYOKAISI_YMD_TO = 16;
var ADVIT_ID_BAIHENKAISI_YMD_FROM = 17;
var ADVIT_ID_BAIHENKAISI_YMD_TO = 18;
var ADVIT_ID_GENBAIKA_SHIJIBAIKA_FLG = 19;
var ADVIT_ID_SEARCHCNT = 20;
var ADVIT_ID_BTNSEARCH = 21;
var ADVIT_ID_BTNZENSTK = 22;
var ADVIT_ID_BTNZENKJO = 23;
var ADVIT_ID_BTNLABEL_CD = 24;
var ADVIT_ID_LABEL_CD = 25;
var ADVIT_ID_LABEL_IP = 26;
var ADVIT_ID_LABEL_NM = 27;
var ADVIT_ID_PGR = 28;
var ADVIT_ID_M1ROWNO = 29;
var ADVIT_ID_M1SHINSEIMOTO_NM = 30;
var ADVIT_ID_M1SINSEITAN_NM = 31;
var ADVIT_ID_M1BAIHEN_SHIJI_NO = 32;
var ADVIT_ID_M1BUMON_CD = 33;
var ADVIT_ID_M1BAIHENSAGYOKAISI_YMD = 34;
var ADVIT_ID_M1BAIHENKAISI_YMD = 35;
var ADVIT_ID_M1BAIHEN_RIYU_NM = 36;
var ADVIT_ID_M1HINBAN_SU = 37;
var ADVIT_ID_M1ZAIKO_SU = 38;
var ADVIT_ID_M1SELECTORCHECKBOX = 39;
var ADVIT_ID_M1ENTERSYORIFLG = 40;
var ADVIT_ID_M1DTLIROKBN = 41;
var ADVIT_ID_BTNENTER = 42;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Sinseimoto","Bumon_cd_from"
	,"Btnbumon_cd_from","Bumon_nm_from","Bumon_cd_to","Btnbumon_cd_to","Bumon_nm_to"
	,"Sinseitan_cd","Btntanto_cd","Sinseitan_nm","Baihen_shiji_no_from","Baihen_shiji_no_to"
	,"Baihensagyokaisi_ymd_from","Baihensagyokaisi_ymd_to","Baihenkaisi_ymd_from","Baihenkaisi_ymd_to","Genbaika_shijibaika_flg"
	,"Searchcnt","Btnsearch","Btnzenstk","Btnzenkjo","Btnlabel_cd"
	,"Label_cd","Label_ip","Label_nm","Pgr","M1rowno"
	,"M1shinseimoto_nm","M1sinseitan_nm","M1baihen_shiji_no","M1bumon_cd","M1baihensagyokaisi_ymd"
	,"M1baihenkaisi_ymd","M1baihen_riyu_nm","M1hinban_su","M1zaiko_su","M1selectorcheckbox"
	,"M1entersyoriflg","M1dtlirokbn","Btnenter"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","申請元","部門コードFROM"
	,"部門コードFROMボタン","部門名FROM","部門コードTO","部門コードTOボタン","部門名TO"
	,"申請担当者コード","担当者コードボタン","申請担当者名称","売変指示NoFROM","売変指示NoTO"
	,"売変作業開始日FROM","売変作業開始日TO","売変開始日FROM","売変開始日TO","現売価＝指示売価のみフラグ"
	,"検索件数","検索ボタン","全選択ボタン","全解除ボタン","ラベル発行機コードボタン"
	,"ラベル発行機ＩＤ","ラベル発行機ＩＰ","ラベル発行機名","ページャ","Ｍ１行NO"
	,"Ｍ１申請元名称","Ｍ１申請担当者名称","Ｍ１売変指示No","Ｍ１部門リンク","Ｍ１売変作業開始日"
	,"Ｍ１売変開始日","Ｍ１売変理由名称","Ｍ１品番数","Ｍ１在庫数","Ｍ１選択フラグ(隠し)"
	,"Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)","確定ボタン"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","SN5","SG"
	,"B","SN4","SG","B","SN4"
	,"SG","B","SN4","SG","SG"
	,"D","D","D","D","NA"
	,"NA","B","B","B","B"
	,"SN4","SG","SN4","B","NA"
	,"SN4","SN4","SG","B","D"
	,"D","SN4","NA","NA","NA"
	,"NA","NA","B"
);
var ADVIT_LENGTH = new Array(
	4,0,15,1,3
	,0,15,3,0,15
	,7,0,12,24,24
	,0,0,0,0,1
	,4,0,0,0,0
	,7,12,10,0,3
	,2,12,10,0,0
	,0,4,5,6,1
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
	,0,0,0
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","DRL","TXT"
	,"BTN","TXR","TXT","BTN","TXR"
	,"TXT","BTN","TXR","TXT","TXT"
	,"TXT","TXT","TXT","TXT","CHK"
	,"TXT","BTS","BTS","BTS","BTN"
	,"HDN","HDN","TXR","LNS","TXR"
	,"TXR","TXR","TXR","BTS","TXR"
	,"TXR","TXR","TXR","TXR","CHK"
	,"HDN","HDN","BTS"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","00","10"
	,"00","00","10","00","00"
	,"10","00","00","00","00"
	,"52","52","52","52","11"
	,"11","00","00","00","00"
	,"00","00","00","00","11"
	,"00","00","10","00","52"
	,"52","00","12","12","11"
	,"11","11","00"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"C_BUMON_CD","","","C_BUMON_CD",""
	,"","C_TANTO_CD","","",""
	,"","","","",""
	,"","","","","C_LABEL_CD"
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
	,"CANNOTGET","CANNOTGET","CANNOTGET"
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1",""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,1,0,0,0
	,0,0,0,1,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,1
);
var ADVIT_IMEMODE = new Array(
	3,0,0,0,3
	,0,0,3,0,0
	,3,0,0,3,3
	,3,3,3,3,0
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
	,0,0,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,0,1
	,0,0,1,0,0
	,1,0,0,1,1
	,1,1,1,1,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0
);
var ADVIT_CONDID = new Array(
	"","","","SINSEIMOTO",""
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
	,"COD","","","COD",""
	,"","COD","","",""
	,"","","","",""
	,"","FRM","FRM","FRM","COD"
	,"","","","PGN",""
	,"","","","FRM",""
	,"","","","",""
	,"","","FRM"
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","TL030F01","TL030F01","TL030F01",""
	,"","","","",""
	,"","","","TL030F02",""
	,"","","","",""
	,"","","TL030F01"
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","M1","M1",""
	,"","","","M1",""
	,"","","","",""
	,"","","","",""
	,"","",""
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
	,"","",""
);
var ADVIT_CAPTION = new Array(
	"店舗","","","申請元","部門ＦＲＯＭ"
	,"","","部門ＴＯ","",""
	,"申請担当者","","","売変指示NoＦＲＯＭ","売変指示NoＴＯ"
	,"作業開始日ＦＲＯＭ","作業開始日ＴＯ","開始日ＦＲＯＭ","開始日ＴＯ","現売価＝指示売価のみ"
	,"","検索","","",""
	,"","","","","No."
	,"申請元","申請担当者","指示No","部門","作業開始日"
	,"開始日","売変理由","品番数","在庫点数","選択フラグ(隠し)"
	,"確定処理フラグ(隠し)","明細色区分(隠し)","確定"
);

