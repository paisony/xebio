var ADVIT_FORMID = "TL020F01";
var ADVIT_TARGETPGID = "tl020p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tl020f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,35,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,49,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_KAKUTEI_JYOTAI = 3;
var ADVIT_ID_SINSEIMOTO = 4;
var ADVIT_ID_BUMON_CD_FROM = 5;
var ADVIT_ID_BTNBUMON_CD_FROM = 6;
var ADVIT_ID_BUMON_NM_FROM = 7;
var ADVIT_ID_BUMON_CD_TO = 8;
var ADVIT_ID_BTNBUMON_CD_TO = 9;
var ADVIT_ID_BUMON_NM_TO = 10;
var ADVIT_ID_BAIHEN_SHIJI_NO_FROM = 11;
var ADVIT_ID_BAIHEN_SHIJI_NO_TO = 12;
var ADVIT_ID_BAIHENSAGYOKAISI_YMD_FROM = 13;
var ADVIT_ID_BAIHENSAGYOKAISI_YMD_TO = 14;
var ADVIT_ID_BAIHENKAISI_YMD_FROM = 15;
var ADVIT_ID_BAIHENKAISI_YMD_TO = 16;
var ADVIT_ID_KAKUTEI_YMD_FROM = 17;
var ADVIT_ID_KAKUTEI_YMD_TO = 18;
var ADVIT_ID_OLD_JISYA_HBN = 19;
var ADVIT_ID_MAKER_HBN = 20;
var ADVIT_ID_TOROKUKAK_CD = 21;
var ADVIT_ID_BTNTANTO_CD = 22;
var ADVIT_ID_TOROKUKAK_NM = 23;
var ADVIT_ID_BAIHEN_RIYTU = 24;
var ADVIT_ID_SEARCHCNT = 25;
var ADVIT_ID_BTNSEARCH = 26;
var ADVIT_ID_SHUTURYOKU_SEAL = 27;
var ADVIT_ID_BTNPRINT = 28;
var ADVIT_ID_BTNSEAL = 29;
var ADVIT_ID_BTNLABEL_CD = 30;
var ADVIT_ID_LABEL_CD = 31;
var ADVIT_ID_LABEL_IP = 32;
var ADVIT_ID_LABEL_NM = 33;
var ADVIT_ID_PGR = 34;
var ADVIT_ID_M1ROWNO = 35;
var ADVIT_ID_M1SHINSEIMOTO_NM = 36;
var ADVIT_ID_M1SINSEITAN_NM = 37;
var ADVIT_ID_M1BUMON_CD = 38;
var ADVIT_ID_M1BUMONKANA_NM = 39;
var ADVIT_ID_M1BAIHEN_SHIJI_NO = 40;
var ADVIT_ID_M1BAIHENSAGYOKAISI_YMD = 41;
var ADVIT_ID_M1BAIHENKAISI_YMD = 42;
var ADVIT_ID_M1BAIHEN_RIYU_NM = 43;
var ADVIT_ID_M1HINBAN_SU = 44;
var ADVIT_ID_M1ZAIKO_SU = 45;
var ADVIT_ID_M1TOROKUKAK_NM = 46;
var ADVIT_ID_M1SELECTORCHECKBOX = 47;
var ADVIT_ID_M1ENTERSYORIFLG = 48;
var ADVIT_ID_M1DTLIROKBN = 49;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Kakutei_jyotai","Sinseimoto"
	,"Bumon_cd_from","Btnbumon_cd_from","Bumon_nm_from","Bumon_cd_to","Btnbumon_cd_to"
	,"Bumon_nm_to","Baihen_shiji_no_from","Baihen_shiji_no_to","Baihensagyokaisi_ymd_from","Baihensagyokaisi_ymd_to"
	,"Baihenkaisi_ymd_from","Baihenkaisi_ymd_to","Kakutei_ymd_from","Kakutei_ymd_to","Old_jisya_hbn"
	,"Maker_hbn","Torokukak_cd","Btntanto_cd","Torokukak_nm","Baihen_riytu"
	,"Searchcnt","Btnsearch","Shuturyoku_seal","Btnprint","Btnseal"
	,"Btnlabel_cd","Label_cd","Label_ip","Label_nm","Pgr"
	,"M1rowno","M1shinseimoto_nm","M1sinseitan_nm","M1bumon_cd","M1bumonkana_nm"
	,"M1baihen_shiji_no","M1baihensagyokaisi_ymd","M1baihenkaisi_ymd","M1baihen_riyu_nm","M1hinban_su"
	,"M1zaiko_su","M1torokukak_nm","M1selectorcheckbox","M1entersyoriflg","M1dtlirokbn"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","確定状態","申請元"
	,"部門コードFROM","部門コードFROMボタン","部門名FROM","部門コードTO","部門コードTOボタン"
	,"部門名TO","売変指示ＮｏFROM","売変指示ＮｏTO","売変作業開始日FROM","売変作業開始日TO"
	,"売変開始日FROM","売変開始日TO","確定日FROM","確定日TO","旧自社品番"
	,"メーカー品番","登録確定者コード","担当者コードボタン","登録確定者名称","売変理由"
	,"検索件数","検索ボタン","出力シール","印刷ボタン","シール発行ボタン"
	,"ラベル発行機コードボタン","ラベル発行機ＩＤ","ラベル発行機ＩＰ","ラベル発行機名","ページャ"
	,"Ｍ１行NO","Ｍ１申請元名称","Ｍ１申請担当者名称","Ｍ１部門リンク","Ｍ１部門カナ名リンク"
	,"Ｍ１売変指示Ｎｏ","Ｍ１売変作業開始日","Ｍ１売変開始日","Ｍ１売変理由名称","Ｍ１品番数"
	,"Ｍ１在庫数","Ｍ１登録確定者名称","Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","SN5","SN5"
	,"SG","B","SN4","SG","B"
	,"SN4","SG","SG","D","D"
	,"D","D","D","D","SG"
	,"SN9","SG","B","SN4","SN5"
	,"NA","B","SN5","B","B"
	,"B","SN4","SG","SN4","B"
	,"NA","SN4","SN4","B","B"
	,"SG","D","D","SN4","NA"
	,"NA","SN4","NA","NA","NA"
);
var ADVIT_LENGTH = new Array(
	4,0,15,1,1
	,3,0,15,3,0
	,15,24,24,0,0
	,0,0,0,0,10
	,30,7,0,12,1
	,4,0,1,0,0
	,0,7,12,10,0
	,3,2,12,0,0
	,10,0,0,4,5
	,6,12,1,1,2
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
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","DRL","DRL"
	,"TXT","BTN","TXR","TXT","BTN"
	,"TXR","TXT","TXT","TXT","TXT"
	,"TXT","TXT","TXT","TXT","TXT"
	,"TXR","TXT","BTN","TXR","DRL"
	,"TXR","BTS","RDO","BTS","BTS"
	,"BTN","HDN","HDN","TXR","LNS"
	,"TXR","TXR","TXR","BTS","BTS"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","CHK","HDN","HDN"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","00","00"
	,"10","00","00","10","00"
	,"00","00","00","52","52"
	,"52","52","52","52","00"
	,"00","10","00","00","00"
	,"12","00","00","00","00"
	,"00","00","00","00","00"
	,"11","00","00","00","00"
	,"10","52","52","00","12"
	,"12","00","11","11","11"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"","C_BUMON_CD","","","C_BUMON_CD"
	,"","","","",""
	,"","","","",""
	,"","","C_TANTO_CD","",""
	,"","","","",""
	,"C_LABEL_CD","","","",""
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
	,"","","","",""
	,"","","","",""
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,1,0,1,1
	,0,0,0,0,1
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
);
var ADVIT_IMEMODE = new Array(
	3,0,0,0,0
	,3,0,0,3,0
	,0,3,3,3,3
	,3,3,3,3,3
	,0,3,0,0,0
	,0,0,0,0,0
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
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,0,0
	,1,0,0,1,0
	,0,1,1,1,1
	,1,1,1,1,1
	,0,1,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
);
var ADVIT_CONDID = new Array(
	"","","","KAKUTEI_JYOTAI","SINSEIMOTO"
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","","BAIHEN_RIYTU"
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
);
var ADVIT_ACTIONID = new Array(
	"","COD","","",""
	,"","COD","","","COD"
	,"","","","",""
	,"","","","",""
	,"","","COD","",""
	,"","FRM","","FRM","FRM"
	,"COD","","","","PGN"
	,"","","","FRM","FRM"
	,"","","","",""
	,"","","","",""
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","TL020F01","","TL020F01","TL020F01"
	,"","","","",""
	,"","","","TL020F02","TL020F02"
	,"","","","",""
	,"","","","",""
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","","M1"
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
	,"","","","",""
	,"","","","",""
	,"","","","",""
);
var ADVIT_CAPTION = new Array(
	"店舗","","","確定状態","申請元"
	,"部門ＦＲＯＭ","","","部門ＴＯ",""
	,"","売変指示ＮｏＦＲＯＭ","売変指示ＮｏＴＯ","作業開始日ＦＲＯＭ","作業開始日ＴＯ"
	,"開始日ＦＲＯＭ","開始日ＴＯ","確定日ＦＲＯＭ","確定日ＴＯ","自社品番"
	,"","登録確定者","","","売変理由"
	,"","検索","出力シール","",""
	,"","","","",""
	,"No.","申請元","申請担当者","部門",""
	,"指示Ｎｏ","作業開始日","開始日","売変理由","品番数"
	,"在庫点数","登録確定者","","",""
);

