var ADVIT_FORMID = "TA080F01";
var ADVIT_TARGETPGID = "ta080p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "ta080f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,38,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,51,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_BTNMODEAPPLY = 3;
var ADVIT_ID_BTNMODESINSEIMAESYUSEI = 4;
var ADVIT_ID_BTNMODESINSEIZUMITORIKESI = 5;
var ADVIT_ID_BTNMODEREF_TOROKURIREKI = 6;
var ADVIT_ID_BTNMODEREF_RINGIKEKKA = 7;
var ADVIT_ID_MODENO = 8;
var ADVIT_ID_STKMODENO = 9;
var ADVIT_ID_YOSAN_YMD_FROM = 10;
var ADVIT_ID_YOSAN_YMD_TO = 11;
var ADVIT_ID_YOSAN_CD_FROM = 12;
var ADVIT_ID_BTNYOSAN_CD_FROM = 13;
var ADVIT_ID_YOSAN_NM_FROM = 14;
var ADVIT_ID_YOSAN_CD_TO = 15;
var ADVIT_ID_BTNYOSAN_CD_TO = 16;
var ADVIT_ID_YOSAN_NM_TO = 17;
var ADVIT_ID_ADD_YMD_FROM = 18;
var ADVIT_ID_ADD_YMD_TO = 19;
var ADVIT_ID_TANTOSYA_CD = 20;
var ADVIT_ID_BTNTANTO_CD = 21;
var ADVIT_ID_HANBAIIN_NM = 22;
var ADVIT_ID_APPLY_YMD_FROM = 23;
var ADVIT_ID_APPLY_YMD_TO = 24;
var ADVIT_ID_SINSEI_SB = 25;
var ADVIT_ID_IRAIRIYU_CD = 26;
var ADVIT_ID_IRAIRIYU_CD1 = 27;
var ADVIT_ID_JOTAI_KBN = 28;
var ADVIT_ID_OLD_JISYA_HBN = 29;
var ADVIT_ID_MAKER_HBN = 30;
var ADVIT_ID_SCAN_CD = 31;
var ADVIT_ID_SEARCHCNT = 32;
var ADVIT_ID_BTNINSERT = 33;
var ADVIT_ID_BTNSEARCH = 34;
var ADVIT_ID_BTNZENSTK = 35;
var ADVIT_ID_BTNZENKJO = 36;
var ADVIT_ID_PGR = 37;
var ADVIT_ID_M1ROWNO = 38;
var ADVIT_ID_M1YOSAN_YMD = 39;
var ADVIT_ID_M1YOSAN_CD = 40;
var ADVIT_ID_M1YOSAN_KIN = 41;
var ADVIT_ID_M1MISINSEI_SU = 42;
var ADVIT_ID_M1MISINSEI_KIN = 43;
var ADVIT_ID_M1APPLYGOKEI_SU = 44;
var ADVIT_ID_M1APPLYGOKEI_KIN = 45;
var ADVIT_ID_M1JISSEKIGOKEI_SU = 46;
var ADVIT_ID_M1JISSEKIGOKEI_KIN = 47;
var ADVIT_ID_M1ZAN_KIN = 48;
var ADVIT_ID_M1SELECTORCHECKBOX = 49;
var ADVIT_ID_M1ENTERSYORIFLG = 50;
var ADVIT_ID_M1DTLIROKBN = 51;
var ADVIT_ID_BTNENTER = 52;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Btnmodeapply","Btnmodesinseimaesyusei"
	,"Btnmodesinseizumitorikesi","Btnmoderef_torokurireki","Btnmoderef_ringikekka","Modeno","Stkmodeno"
	,"Yosan_ymd_from","Yosan_ymd_to","Yosan_cd_from","Btnyosan_cd_from","Yosan_nm_from"
	,"Yosan_cd_to","Btnyosan_cd_to","Yosan_nm_to","Add_ymd_from","Add_ymd_to"
	,"Tantosya_cd","Btntanto_cd","Hanbaiin_nm","Apply_ymd_from","Apply_ymd_to"
	,"Sinsei_sb","Irairiyu_cd","Irairiyu_cd1","Jotai_kbn","Old_jisya_hbn"
	,"Maker_hbn","Scan_cd","Searchcnt","Btninsert","Btnsearch"
	,"Btnzenstk","Btnzenkjo","Pgr","M1rowno","M1yosan_ymd"
	,"M1yosan_cd","M1yosan_kin","M1misinsei_su","M1misinsei_kin","M1applygokei_su"
	,"M1applygokei_kin","M1jissekigokei_su","M1jissekigokei_kin","M1zan_kin","M1selectorcheckbox"
	,"M1entersyoriflg","M1dtlirokbn","Btnenter"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","モード申請ボタン","モード申請前修正ボタン"
	,"モード申請取消ボタン","モード登録履歴照会ボタン","モード稟議結果照会ボタン","モードNO","選択モードNO"
	,"年月度ＦＲＯＭ","年月度ＴＯ","仕入枠グループコードＦＲＯＭ","仕入枠グループコードＦＲＯＭボタン","仕入枠グループ名ＦＲＯＭ"
	,"仕入枠グループコードＴＯ","仕入枠グループコードＴＯボタン","仕入枠グループ名ＴＯ","登録日ＦＲＯＭ","登録日ＴＯ"
	,"登録担当者コード","登録担当者コードボタン","登録担当者名","申請日ＦＲＯＭ","申請日ＴＯ"
	,"申請種別","依頼理由コード","依頼理由コード1","状態","旧自社品番"
	,"メーカー品番","スキャンコード","検索件数","新規作成ボタン","検索ボタン"
	,"全選択ボタン","全解除ボタン","ページャ","Ｍ１行NO","Ｍ１年月度"
	,"Ｍ１仕入枠グループリンク","Ｍ１予算金額","Ｍ１未申請数","Ｍ１未申請金額","Ｍ１申請数"
	,"Ｍ１申請金額","Ｍ１実績数","Ｍ１実績金額","Ｍ１残金額","Ｍ１選択フラグ(隠し)"
	,"Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)","確定ボタン"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","B","B"
	,"B","B","B","NA","NA"
	,"D","D","SB","B","SN4"
	,"SB","B","SN4","D","D"
	,"SG","B","SN4","D","D"
	,"SN5","SN5","SN5","SN5","SG"
	,"SN9","SG","NA","B","B"
	,"B","B","B","NA","D"
	,"B","NA","NA","NA","NA"
	,"NA","NA","NA","NA","NA"
	,"NA","NA","B"
);
var ADVIT_LENGTH = new Array(
	4,0,15,0,0
	,0,0,0,2,2
	,0,0,6,0,8
	,6,0,8,0,0
	,7,0,12,0,0
	,1,2,2,2,10
	,30,18,4,0,0
	,0,0,0,4,0
	,0,8,8,9,8
	,9,8,9,9,1
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
	,0,0,0
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","LNK","LNK"
	,"LNK","LNK","LNK","HDN","HDN"
	,"TXT","TXT","TXT","BTN","TXR"
	,"TXT","BTN","TXR","TXT","TXT"
	,"TXT","BTN","TXR","TXT","TXT"
	,"DRL","DRL","DRL","DRL","TXT"
	,"TXR","TXT","TXT","BTS","BTS"
	,"BTS","BTS","LNS","LBL","LBL"
	,"BTS","LBL","LBL","LBL","LBL"
	,"LBL","LBL","LBL","LBL","CHK"
	,"HDN","HDN","BTS"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","00","00"
	,"00","00","00","11","11"
	,"54","54","00","00","00"
	,"00","00","00","52","52"
	,"10","00","00","52","52"
	,"00","00","00","00","00"
	,"00","00","12","00","00"
	,"00","00","00","11","54"
	,"00","12","12","12","12"
	,"12","12","12","12","11"
	,"11","11","00"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"","","","",""
	,"","","","C_YOSAN_CD",""
	,"","C_YOSAN_CD","","",""
	,"","C_TANTO_CD","","",""
	,"","C_RIYU_CD","C_RIYU_CD","C_MEISYO_CD",""
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
	,"M1","M1",""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,1,1
	,0,0,1,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,1
);
var ADVIT_IMEMODE = new Array(
	3,0,0,0,0
	,0,0,0,0,0
	,3,3,3,0,0
	,3,0,0,3,3
	,3,0,0,3,3
	,0,0,0,0,3
	,0,3,0,0,0
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
	,0,0,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,0,0
	,0,0,0,0,0
	,1,1,1,0,0
	,1,0,0,1,1
	,1,0,0,1,1
	,0,0,0,0,1
	,0,1,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0
);
var ADVIT_CONDID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"SINSEI_SB","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","",""
);
var ADVIT_ACTIONID = new Array(
	"","COD","","SPT","SPT"
	,"SPT","SPT","SPT","",""
	,"","","","COD",""
	,"","COD","","",""
	,"","COD","","",""
	,"","COD","COD","COD",""
	,"","","","FRM","FRM"
	,"FRM","FRM","PGN","",""
	,"FRM","","","",""
	,"","","","",""
	,"","","DBU"
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","TA080F01","TA080F01"
	,"TA080F01","TA080F01","TA080F01","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","TA080F03","TA080F01"
	,"TA080F01","TA080F01","","",""
	,"TA080F03","","","",""
	,"","","","",""
	,"","","TA080F01"
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"M1","M1","M1","",""
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
	,"","",""
);
var ADVIT_CAPTION = new Array(
	"店舗","","","申請","申請前修正"
	,"申請取消","登録履歴照会","稟議結果照会","",""
	,"年月度ＦＲＯＭ","年月度ＴＯ","仕入枠グループコードＦＲＯＭ","",""
	,"仕入枠グループコードＴＯ","","","登録日ＦＲＯＭ","登録日ＴＯ"
	,"登録担当者","","","申請日ＦＲＯＭ","申請日ＴＯ"
	,"申請種別","依頼理由","依頼理由","状態","自社品番"
	,"","ｽｷｬﾝｺｰﾄﾞ","検索件数","新規作成","検索"
	,"","","","No.","年月度"
	,"仕入枠ｸﾞﾙｰﾌﾟ","予算金額","未申請数","未申請金額","申請数"
	,"申請金額","実績数","実績金額","残金額",""
	,"","","確定"
);

