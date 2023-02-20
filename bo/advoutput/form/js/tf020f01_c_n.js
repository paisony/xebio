var ADVIT_FORMID = "TF020F01";
var ADVIT_TARGETPGID = "tf020p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tf020f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,31,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,47,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_BTNMODEUPD = 3;
var ADVIT_ID_BTNMODEDEL = 4;
var ADVIT_ID_BTNMODEREF = 5;
var ADVIT_ID_MODENO = 6;
var ADVIT_ID_STKMODENO = 7;
var ADVIT_ID_SYONIN_FLG = 8;
var ADVIT_ID_APPLY_YMD_FROM = 9;
var ADVIT_ID_APPLY_YMD_TO = 10;
var ADVIT_ID_KAKUTEI_YMD_FROM = 11;
var ADVIT_ID_KAKUTEI_YMD_TO = 12;
var ADVIT_ID_DENPYO_BANGO_FROM = 13;
var ADVIT_ID_DENPYO_BANGO_TO = 14;
var ADVIT_ID_KAMOKU_CD_FROM = 15;
var ADVIT_ID_BTNKAMOKUCD_FROM = 16;
var ADVIT_ID_KAMOKU_NM_FROM = 17;
var ADVIT_ID_KAMOKU_CD_TO = 18;
var ADVIT_ID_BTNKAMOKUCD_TO = 19;
var ADVIT_ID_KAMOKU_NM_TO = 20;
var ADVIT_ID_SINSEITAN_CD = 21;
var ADVIT_ID_BTNTANTO_CD = 22;
var ADVIT_ID_SINSEITAN_NM = 23;
var ADVIT_ID_JYURI_NO_FROM = 24;
var ADVIT_ID_JYURI_NO_TO = 25;
var ADVIT_ID_SEARCHCNT = 26;
var ADVIT_ID_BTNINSERT = 27;
var ADVIT_ID_BTNSEARCH = 28;
var ADVIT_ID_BTNPRINT = 29;
var ADVIT_ID_PGR = 30;
var ADVIT_ID_M1ROWNO = 31;
var ADVIT_ID_M1APPLY_YMD = 32;
var ADVIT_ID_M1KAKUTEI_YMD = 33;
var ADVIT_ID_M1DENPYO_BANGO = 34;
var ADVIT_ID_M1KAMOKU_CD = 35;
var ADVIT_ID_M1KAMOKU_NM = 36;
var ADVIT_ID_M1ITEMSU = 37;
var ADVIT_ID_M1GENKAKIN = 38;
var ADVIT_ID_M1BAIKA_TNK = 39;
var ADVIT_ID_M1SINSEITAN_NM = 40;
var ADVIT_ID_M1JYURI_NO = 41;
var ADVIT_ID_M1SYONIN_FLG_NM = 42;
var ADVIT_ID_M1SINSEIRIYU = 43;
var ADVIT_ID_M1KYAKKARIYU = 44;
var ADVIT_ID_M1SELECTORCHECKBOX = 45;
var ADVIT_ID_M1ENTERSYORIFLG = 46;
var ADVIT_ID_M1DTLIROKBN = 47;
var ADVIT_ID_BTNENTER = 48;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Btnmodeupd","Btnmodedel"
	,"Btnmoderef","Modeno","Stkmodeno","Syonin_flg","Apply_ymd_from"
	,"Apply_ymd_to","Kakutei_ymd_from","Kakutei_ymd_to","Denpyo_bango_from","Denpyo_bango_to"
	,"Kamoku_cd_from","Btnkamokucd_from","Kamoku_nm_from","Kamoku_cd_to","Btnkamokucd_to"
	,"Kamoku_nm_to","Sinseitan_cd","Btntanto_cd","Sinseitan_nm","Jyuri_no_from"
	,"Jyuri_no_to","Searchcnt","Btninsert","Btnsearch","Btnprint"
	,"Pgr","M1rowno","M1apply_ymd","M1kakutei_ymd","M1denpyo_bango"
	,"M1kamoku_cd","M1kamoku_nm","M1itemsu","M1genkakin","M1baika_tnk"
	,"M1sinseitan_nm","M1jyuri_no","M1syonin_flg_nm","M1sinseiriyu","M1kyakkariyu"
	,"M1selectorcheckbox","M1entersyoriflg","M1dtlirokbn","Btnenter"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","モード修正ボタン","モード取消ボタン"
	,"モード照会ボタン","モードNO","選択モードNO","承認状態","申請日ＦＲＯＭ"
	,"申請日ＴＯ","確定日ＦＲＯＭ","確定日ＴＯ","伝票番号ＦＲＯＭ","伝票番号ＴＯ"
	,"科目コードＦＲＯＭ","科目コードＦＲＯＭボタン","科目名ＦＲＯＭ","科目コードＴＯ","科目コードＴＯボタン"
	,"科目名ＴＯ","申請担当者コード","担当者コードボタン","申請担当者名称","受理番号ＦＲＯＭ"
	,"受理番号ＴＯ","検索件数","新規作成ボタン","検索ボタン","印刷ボタン"
	,"ページャ","Ｍ１行NO","Ｍ１申請日","Ｍ１確定日","Ｍ１伝票番号リンク"
	,"Ｍ１科目コード","Ｍ１科目名","Ｍ１数量","Ｍ１原価金額","Ｍ１売価"
	,"Ｍ１申請担当者名称","Ｍ１受理番号","Ｍ１承認状態名称","Ｍ１申請理由","Ｍ１却下理由"
	,"Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)","確定ボタン"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","B","B"
	,"B","NA","NA","SN5","D"
	,"D","D","D","NA","NA"
	,"SG","B","SN5","SG","B"
	,"SN5","SG","B","SN4","SB"
	,"SB","NA","B","B","B"
	,"B","NA","D","D","B"
	,"SG","SN5","NA","NA","NA"
	,"SN5","SB","SN5","SN5","SN5"
	,"NA","NA","NA","B"
);
var ADVIT_LENGTH = new Array(
	4,0,15,0,0
	,0,2,2,1,0
	,0,0,0,6,6
	,8,0,20,8,0
	,20,7,0,12,10
	,10,4,0,0,0
	,0,4,0,0,0
	,8,20,4,12,12
	,12,10,3,30,30
	,1,1,2,0
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
	,0,0,0,0
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
	,0,0,0,0
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
	,0,0,0,0
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
	,0,0,0,0
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","LNK","LNK"
	,"LNK","HDN","HDN","DRL","TXT"
	,"TXT","TXT","TXT","TXT","TXT"
	,"TXT","BTN","TXR","TXT","BTN"
	,"TXR","TXT","BTN","TXR","TXT"
	,"TXT","TXR","BTS","BTS","BTS"
	,"LNS","TXR","TXR","TXR","BTS"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"CHK","HDN","HDN","BTS"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","00","00"
	,"00","11","11","00","52"
	,"52","52","52","10","10"
	,"10","00","00","10","00"
	,"00","10","00","00","00"
	,"00","12","00","00","00"
	,"00","11","53","53","00"
	,"10","00","12","12","12"
	,"00","00","00","00","00"
	,"11","11","11","00"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"","","","",""
	,"","","","",""
	,"","C_KAMOKU_CD","","","C_KAMOKU_CD"
	,"","","C_TANTO_CD","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","",""
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
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1",""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,1,1,1
	,1,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,1
);
var ADVIT_IMEMODE = new Array(
	3,0,0,0,0
	,0,0,0,0,3
	,3,3,3,3,3
	,3,0,0,3,0
	,0,3,0,0,3
	,3,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0
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
	,0,0,0,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,0,0
	,0,0,0,0,1
	,1,1,1,1,1
	,1,0,0,1,0
	,0,1,0,0,1
	,1,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0
);
var ADVIT_CONDID = new Array(
	"","","","",""
	,"","","","SYONIN_JOTAI",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","",""
);
var ADVIT_ACTIONID = new Array(
	"","COD","","SPT","SPT"
	,"SPT","","","",""
	,"","","","",""
	,"","COD","","","COD"
	,"","","COD","",""
	,"","","FRM","FRM","FRM"
	,"PGN","","","","FRM"
	,"","","","",""
	,"","","","",""
	,"","","","FRM"
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","TF020F01","TF020F01"
	,"TF020F01","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","TF020F02","TF020F01","TF020F01"
	,"","","","","TF020F02"
	,"","","","",""
	,"","","","",""
	,"","","","TF020F01"
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"M1","","","",""
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
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","",""
);
var ADVIT_CAPTION = new Array(
	"店舗","","","修正","取消"
	,"照会","","","承認状態","申請日ＦＲＯＭ"
	,"申請日ＴＯ","確定日ＦＲＯＭ","確定日ＴＯ","伝票番号ＦＲＯＭ","伝票番号ＴＯ"
	,"科目ＦＲＯＭ","","","科目ＴＯ",""
	,"","申請者","","","受理番号ＦＲＯＭ"
	,"受理番号ＴＯ","","新規作成","検索",""
	,"","No.","申請日","確定日","伝票番号"
	,"科目","","数量","原価金額","売価金額"
	,"申請担当者","受理番号","承認状態","申請理由","却下理由"
	,"","","","確定"
);

