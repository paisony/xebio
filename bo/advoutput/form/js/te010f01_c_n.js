var ADVIT_FORMID = "TE010F01";
var ADVIT_TARGETPGID = "te010p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "te010f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,38,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,56,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_BTNMODEREF = 3;
var ADVIT_ID_BTNMODEDEL = 4;
var ADVIT_ID_MODENO = 5;
var ADVIT_ID_STKMODENO = 6;
var ADVIT_ID_DENPYO_JYOTAI = 7;
var ADVIT_ID_DENPYO_BANGO_FROM = 8;
var ADVIT_ID_DENPYO_BANGO_TO = 9;
var ADVIT_ID_SIJI_BANGO_FROM = 10;
var ADVIT_ID_SIJI_BANGO_TO = 11;
var ADVIT_ID_SYUKKA_YMD_FROM = 12;
var ADVIT_ID_SYUKKA_YMD_TO = 13;
var ADVIT_ID_KAISYA_CD = 14;
var ADVIT_ID_BTNKAISHA_CD = 15;
var ADVIT_ID_KAISYA_NM = 16;
var ADVIT_ID_JYURYOTEN_CD = 17;
var ADVIT_ID_BTNTENPOCD = 18;
var ADVIT_ID_JURYOTEN_NM = 19;
var ADVIT_ID_NYURYOKUTAN_CD = 20;
var ADVIT_ID_BTNNYURYOKUTANTO_CD = 21;
var ADVIT_ID_NYURYOKUTAN_NM = 22;
var ADVIT_ID_BUMON_CD_FROM = 23;
var ADVIT_ID_BTNBUMON_CD_FROM = 24;
var ADVIT_ID_BUMON_NM_FROM = 25;
var ADVIT_ID_BUMON_CD_TO = 26;
var ADVIT_ID_BTNBUMON_CD_TO = 27;
var ADVIT_ID_BUMON_NM_TO = 28;
var ADVIT_ID_SHUKKARIYU_KBN = 29;
var ADVIT_ID_OLD_JISYA_HBN = 30;
var ADVIT_ID_MAKER_HBN = 31;
var ADVIT_ID_SCAN_CD = 32;
var ADVIT_ID_OFFLINE_NO = 33;
var ADVIT_ID_SEARCHCNT = 34;
var ADVIT_ID_BTNSEARCH = 35;
var ADVIT_ID_BTNPRINT = 36;
var ADVIT_ID_PGR = 37;
var ADVIT_ID_M1ROWNO = 38;
var ADVIT_ID_M1KAISYAKANA_NM = 39;
var ADVIT_ID_M1JYURYOTEN_CD = 40;
var ADVIT_ID_M1JURYOTEN_NM = 41;
var ADVIT_ID_M1SCM_CD = 42;
var ADVIT_ID_M1DENPYO_BANGO = 43;
var ADVIT_ID_M1SIJI_BANGO = 44;
var ADVIT_ID_M1SYUKKA_YMD = 45;
var ADVIT_ID_M1JYURYO_YMD = 46;
var ADVIT_ID_M1SYUKKA_SU = 47;
var ADVIT_ID_M1KAKUTEI_SU = 48;
var ADVIT_ID_M1NYURYOKUTAN_NM = 49;
var ADVIT_ID_M1SHUKKARIYU_NM = 50;
var ADVIT_ID_M1SYORINM = 51;
var ADVIT_ID_M1SYORIYMD = 52;
var ADVIT_ID_M1SYORI_TM = 53;
var ADVIT_ID_M1SELECTORCHECKBOX = 54;
var ADVIT_ID_M1ENTERSYORIFLG = 55;
var ADVIT_ID_M1DTLIROKBN = 56;
var ADVIT_ID_BTNENTER = 57;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Btnmoderef","Btnmodedel"
	,"Modeno","Stkmodeno","Denpyo_jyotai","Denpyo_bango_from","Denpyo_bango_to"
	,"Siji_bango_from","Siji_bango_to","Syukka_ymd_from","Syukka_ymd_to","Kaisya_cd"
	,"Btnkaisha_cd","Kaisya_nm","Jyuryoten_cd","Btntenpocd","Juryoten_nm"
	,"Nyuryokutan_cd","Btnnyuryokutanto_cd","Nyuryokutan_nm","Bumon_cd_from","Btnbumon_cd_from"
	,"Bumon_nm_from","Bumon_cd_to","Btnbumon_cd_to","Bumon_nm_to","Shukkariyu_kbn"
	,"Old_jisya_hbn","Maker_hbn","Scan_cd","Offline_no","Searchcnt"
	,"Btnsearch","Btnprint","Pgr","M1rowno","M1kaisyakana_nm"
	,"M1jyuryoten_cd","M1juryoten_nm","M1scm_cd","M1denpyo_bango","M1siji_bango"
	,"M1syukka_ymd","M1jyuryo_ymd","M1syukka_su","M1kakutei_su","M1nyuryokutan_nm"
	,"M1shukkariyu_nm","M1syorinm","M1syoriymd","M1syori_tm","M1selectorcheckbox"
	,"M1entersyoriflg","M1dtlirokbn","Btnenter"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","モード照会ボタン","モード取消ボタン"
	,"モードNO","選択モードNO","伝票状態","伝票番号FROM","伝票番号TO"
	,"指示番号FROM","指示番号TO","出荷日FROM","出荷日TO","会社コード"
	,"会社コードボタン","会社名称","入荷店コード","店舗コードボタン","入荷店名称"
	,"入力担当者コード","入力担当者コードボタン","入力担当者名称","部門コードFROM","部門コードFROMボタン"
	,"部門名FROM","部門コードTO","部門コードTOボタン","部門名TO","出荷理由"
	,"旧自社品番","メーカー品番","スキャンコード","オフライン伝票No","検索件数"
	,"検索ボタン","印刷ボタン","ページャ","Ｍ１行NO","Ｍ１会社カナ名"
	,"Ｍ１入荷店コード","Ｍ１入荷店名称","Ｍ１SCMコード","Ｍ１伝票番号リンク","Ｍ１指示番号"
	,"Ｍ１出荷日","Ｍ１入荷日","Ｍ１出荷数量（梱包単位）","Ｍ１確定数量","Ｍ１入力担当者名称"
	,"Ｍ１出荷理由名称","Ｍ１処理名称","Ｍ１処理日","Ｍ１処理時間","Ｍ１選択フラグ(隠し)"
	,"Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)","確定ボタン"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","B","B"
	,"NA","NA","SN5","NA","NA"
	,"SG","SG","D","D","SG"
	,"B","SN4","SG","B","SN4"
	,"SG","B","SN4","SG","B"
	,"SN4","SG","B","SN4","SN5"
	,"SG","SN9","SG","SG","NA"
	,"B","B","B","NA","SN9"
	,"SG","SN4","SG","B","SG"
	,"D","D","NA","NA","SN4"
	,"SN4","SN4","D","D","NA"
	,"NA","NA","B"
);
var ADVIT_LENGTH = new Array(
	4,0,15,0,0
	,2,2,1,6,6
	,24,24,0,0,2
	,0,10,4,0,15
	,7,0,12,3,0
	,15,3,0,15,1
	,10,30,18,20,4
	,0,0,0,3,2
	,4,15,20,0,10
	,0,0,6,6,12
	,4,4,0,0,1
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
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","LNK","LNK"
	,"HDN","HDN","DRL","TXT","TXT"
	,"TXT","TXT","TXT","TXT","TXT"
	,"BTN","TXR","TXT","BTN","TXR"
	,"TXT","BTN","TXR","TXT","BTN"
	,"TXR","TXT","BTN","TXR","DRL"
	,"TXT","TXR","TXT","TXT","TXT"
	,"BTS","BTS","LNS","TXR","TXR"
	,"TXR","TXR","TXR","BTS","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","CHK"
	,"HDN","HDN","BTS"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","00","00"
	,"11","11","00","10","10"
	,"00","00","52","52","10"
	,"00","00","10","00","00"
	,"10","00","00","10","00"
	,"00","10","00","00","00"
	,"00","00","00","00","11"
	,"00","00","00","11","00"
	,"10","00","00","00","10"
	,"53","53","12","12","00"
	,"00","00","53","56","11"
	,"11","11","00"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"","","","",""
	,"","","","",""
	,"C_MEISYO_CD","","","C_TENPO_ALL_CD",""
	,"","C_TANTO_CD","","","C_BUMON_CD"
	,"","","C_BUMON_CD","",""
	,"","","","",""
	,"","","","",""
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
	,"","","","",""
	,"","","","",""
	,"","","","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1",""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,1,1,1,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,1
);
var ADVIT_IMEMODE = new Array(
	3,0,0,0,0
	,0,0,0,3,3
	,3,3,3,3,3
	,0,0,3,0,0
	,3,0,0,3,0
	,0,3,0,0,0
	,3,0,3,3,0
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
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,0,0
	,0,0,0,1,1
	,1,1,1,1,1
	,0,0,1,0,0
	,1,0,0,1,0
	,0,1,0,0,0
	,1,0,1,1,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0
);
var ADVIT_CONDID = new Array(
	"","","","",""
	,"","","IDOSHUKKA_DENPYO_JOTAI","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","","SHUKKARIYU_KBN"
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","",""
);
var ADVIT_ACTIONID = new Array(
	"","COD","","SPT","SPT"
	,"","","","",""
	,"","","","",""
	,"COD","","","COD",""
	,"","COD","","","COD"
	,"","","COD","",""
	,"","","","",""
	,"FRM","FRM","PGN","",""
	,"","","","FRM",""
	,"","","","",""
	,"","","","",""
	,"","","FRM"
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","TE010F01","TE010F01"
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"TE010F01","TE010F01","","",""
	,"","","","TE010F02",""
	,"","","","",""
	,"","","","",""
	,"","","TE010F01"
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","M1","",""
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
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","",""
);
var ADVIT_CAPTION = new Array(
	"店舗","","","照会","取消"
	,"","","伝票状態","伝票番号ＦＲＯＭ","伝票番号ＴＯ"
	,"指示番号ＦＲＯＭ","指示番号ＴＯ","出荷日ＦＲＯＭ","出荷日ＴＯ","会社"
	,"","","入荷店","",""
	,"入力担当者","","","部門コードＦＲＯＭ",""
	,"","部門コードＴＯ","","","出荷理由"
	,"自社品番","","ｽｷｬﾝｺｰﾄﾞ","ｵﾌﾗｲﾝ伝票No","検索件数"
	,"検索","","","No.","会社"
	,"入荷店","","SCMコード","伝票番号","指示番号"
	,"出荷日","入荷日","出荷数量","確定数量","入力担当者"
	,"出荷理由","処理","処理日","処理時間",""
	,"","","確定"
);

