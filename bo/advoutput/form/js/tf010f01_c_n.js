var ADVIT_FORMID = "TF010F01";
var ADVIT_TARGETPGID = "tf010p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tf010f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,39,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,60,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_BTNMODEKAKUTEI = 3;
var ADVIT_ID_BTNMODEUPD = 4;
var ADVIT_ID_BTNMODEDEL = 5;
var ADVIT_ID_BTNMODEREF = 6;
var ADVIT_ID_MODENO = 7;
var ADVIT_ID_STKMODENO = 8;
var ADVIT_ID_SYONIN_FLG = 9;
var ADVIT_ID_APPLY_YMD_FROM = 10;
var ADVIT_ID_APPLY_YMD_TO = 11;
var ADVIT_ID_KAKUTEI_YMD_FROM = 12;
var ADVIT_ID_KAKUTEI_YMD_TO = 13;
var ADVIT_ID_SHINSEI_TENPO_CD_FROM = 14;
var ADVIT_ID_BTNSHINSEITENPOCD_FROM = 15;
var ADVIT_ID_SHINSEI_TENPO_NM_FROM = 16;
var ADVIT_ID_SHINSEI_TENPO_CD_TO = 17;
var ADVIT_ID_BTNSHINSEITENPOCD_TO = 18;
var ADVIT_ID_SHINSEI_TENPO_NM_TO = 19;
var ADVIT_ID_GYOMURINGI_NO_FROM = 20;
var ADVIT_ID_GYOMURINGI_NO_TO = 21;
var ADVIT_ID_DENPYO_BANGO_FROM = 22;
var ADVIT_ID_DENPYO_BANGO_TO = 23;
var ADVIT_ID_JYURI_NO_FROM = 24;
var ADVIT_ID_JYURI_NO_TO = 25;
var ADVIT_ID_KAMOKU_CD_FROM = 26;
var ADVIT_ID_BTNKAMOKUCD_FROM = 27;
var ADVIT_ID_KAMOKU_NM_FROM = 28;
var ADVIT_ID_KAMOKU_CD_TO = 29;
var ADVIT_ID_BTNKAMOKUCD_TO = 30;
var ADVIT_ID_KAMOKU_NM_TO = 31;
var ADVIT_ID_SINSEIRIYU_KB = 32;
var ADVIT_ID_MEISAI_SORT = 33;
var ADVIT_ID_SEARCHCNT = 34;
var ADVIT_ID_BTNSEARCH = 35;
var ADVIT_ID_BTNPRINT = 36;
var ADVIT_ID_BTNCSV = 37;
var ADVIT_ID_PGR = 38;
var ADVIT_ID_M1ROWNO = 39;
var ADVIT_ID_M1APPLY_YMD = 40;
var ADVIT_ID_M1SHINSEI_TENPO_CD = 41;
var ADVIT_ID_M1SHINSEI_TENPO_NM = 42;
var ADVIT_ID_M1DENPYO_BANGO = 43;
var ADVIT_ID_M1GYOMURINGI_NO = 44;
var ADVIT_ID_M1JYURI_NO = 45;
var ADVIT_ID_M1SURYO = 46;
var ADVIT_ID_M1GENKA_KIN = 47;
var ADVIT_ID_M1SINSEITAN_NM = 48;
var ADVIT_ID_M1SINSEIRIYU = 49;
var ADVIT_ID_M1KYAKKARIYU = 50;
var ADVIT_ID_M1SYONIN_FLG = 51;
var ADVIT_ID_M1KYAKKA_FLG = 52;
var ADVIT_ID_M1KAKUTEI_YMD = 53;
var ADVIT_ID_M1KAMOKU_CD = 54;
var ADVIT_ID_M1KAMOKU_NM = 55;
var ADVIT_ID_M1BAIKA_KIN = 56;
var ADVIT_ID_M1KAKUTEITAN_NM = 57;
var ADVIT_ID_M1SELECTORCHECKBOX = 58;
var ADVIT_ID_M1ENTERSYORIFLG = 59;
var ADVIT_ID_M1DTLIROKBN = 60;
var ADVIT_ID_BTNENTER = 61;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Btnmodekakutei","Btnmodeupd"
	,"Btnmodedel","Btnmoderef","Modeno","Stkmodeno","Syonin_flg"
	,"Apply_ymd_from","Apply_ymd_to","Kakutei_ymd_from","Kakutei_ymd_to","Shinsei_tenpo_cd_from"
	,"Btnshinseitenpocd_from","Shinsei_tenpo_nm_from","Shinsei_tenpo_cd_to","Btnshinseitenpocd_to","Shinsei_tenpo_nm_to"
	,"Gyomuringi_no_from","Gyomuringi_no_to","Denpyo_bango_from","Denpyo_bango_to","Jyuri_no_from"
	,"Jyuri_no_to","Kamoku_cd_from","Btnkamokucd_from","Kamoku_nm_from","Kamoku_cd_to"
	,"Btnkamokucd_to","Kamoku_nm_to","Sinseiriyu_kb","Meisai_sort","Searchcnt"
	,"Btnsearch","Btnprint","Btncsv","Pgr","M1rowno"
	,"M1apply_ymd","M1shinsei_tenpo_cd","M1shinsei_tenpo_nm","M1denpyo_bango","M1gyomuringi_no"
	,"M1jyuri_no","M1suryo","M1genka_kin","M1sinseitan_nm","M1sinseiriyu"
	,"M1kyakkariyu","M1syonin_flg","M1kyakka_flg","M1kakutei_ymd","M1kamoku_cd"
	,"M1kamoku_nm","M1baika_kin","M1kakuteitan_nm","M1selectorcheckbox","M1entersyoriflg"
	,"M1dtlirokbn","Btnenter"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","モード確定ボタン","モード修正ボタン"
	,"モード取消ボタン","モード照会ボタン","モードNO","選択モードNO","承認状態"
	,"申請日ＦＲＯＭ","申請日ＴＯ","確定日ＦＲＯＭ","確定日ＴＯ","申請店舗コードＦＲＯＭ"
	,"申請店舗コードＦＲＯＭボタン","申請店舗名ＦＲＯＭ","申請店舗コードＴＯ","申請店舗コードＴＯボタン","申請店舗名ＴＯ"
	,"業務稟議NoＦＲＯＭ","業務稟議NoＴＯ","伝票番号ＦＲＯＭ","伝票番号ＴＯ","受理番号ＦＲＯＭ"
	,"受理番号ＴＯ","科目コードＦＲＯＭ","科目コードＦＲＯＭボタン","科目名ＦＲＯＭ","科目コードＴＯ"
	,"科目コードＴＯボタン","科目名ＴＯ","申請理由区分","明細ソート","検索件数"
	,"検索ボタン","印刷ボタン","CSVボタン","ページャ","Ｍ１行NO"
	,"Ｍ１申請日","Ｍ１申請店舗コード","Ｍ１申請店舗名","Ｍ１伝票番号リンク","Ｍ１業務稟議No"
	,"Ｍ１受理番号","Ｍ１数量","Ｍ１原価金額","Ｍ１申請担当者名称","Ｍ１申請理由"
	,"Ｍ１却下理由","Ｍ１承認状態","Ｍ１却下フラグ","Ｍ１確定日","Ｍ１科目コード"
	,"Ｍ１科目名","Ｍ１売価金額","Ｍ１確定担当者名称","Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)"
	,"Ｍ１明細色区分(隠し)","確定ボタン"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","B","B"
	,"B","B","NA","NA","NA"
	,"D","D","D","D","SG"
	,"B","SN4","SG","B","SN4"
	,"NA","NA","NA","NA","SB"
	,"SB","SG","B","SN4","SG"
	,"B","SN4","SN5","NA","NA"
	,"B","B","B","B","NA"
	,"D","SG","SN4","B","NA"
	,"SB","NA","NA","SN4","SN4"
	,"SN21","NA","NA","D","SG"
	,"SN4","NA","SN4","NA","NA"
	,"NA","B"
);
var ADVIT_LENGTH = new Array(
	4,0,15,0,0
	,0,0,2,2,1
	,0,0,0,0,4
	,0,15,4,0,15
	,4,4,6,6,10
	,10,8,0,20,8
	,0,20,2,1,4
	,0,0,0,0,4
	,0,4,15,0,4
	,10,4,12,12,30
	,30,1,1,0,8
	,20,12,12,1,1
	,2,0
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
	,0,0,0,0,0
	,0,0
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
	,0,0,0,0,0
	,0,0
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
	,0,0,0,0,0
	,0,0
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
	,0,0,0,0,0
	,0,0
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","LNK","LNK"
	,"LNK","LNK","HDN","HDN","DRL"
	,"TXT","TXT","TXT","TXT","TXT"
	,"BTN","TXR","TXT","BTN","TXR"
	,"TXT","TXT","TXT","TXT","TXT"
	,"TXT","TXT","BTN","TXR","TXT"
	,"BTN","TXR","DRL","RDO","TXR"
	,"BTS","BTS","BTS","LNS","TXR"
	,"TXR","TXR","TXR","BTS","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXT","CHK","CHK","TXR","TXR"
	,"TXR","TXR","TXR","CHK","HDN"
	,"HDN","BTS"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","00","00"
	,"00","00","11","11","10"
	,"52","52","52","52","10"
	,"00","00","10","00","00"
	,"10","10","10","10","00"
	,"00","10","00","00","10"
	,"00","00","00","11","12"
	,"00","00","00","00","11"
	,"52","10","00","00","10"
	,"00","12","12","00","00"
	,"00","11","11","52","10"
	,"00","12","00","11","11"
	,"11","00"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"","","","",""
	,"","","","",""
	,"C_TENPO_CD","","","C_TENPO_CD",""
	,"","","","",""
	,"","","C_KAMOKU_CD","",""
	,"C_KAMOKU_CD","","C_MEISYO_CD","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"",""
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
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET"
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1",""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,1,1,1,1,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,1
);
var ADVIT_IMEMODE = new Array(
	3,0,0,0,0
	,0,0,0,0,0
	,3,3,3,3,3
	,0,0,3,0,0
	,3,3,3,3,3
	,3,3,0,0,3
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,1,0,0,0,0
	,0,0,0,0,0
	,0,0
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
	,0,0,0,0,0
	,0,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,0,0
	,0,0,0,0,0
	,1,1,1,1,1
	,0,0,1,0,0
	,1,1,1,1,1
	,1,1,0,0,1
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,1,0,0,0,0
	,0,0,0,0,0
	,0,0
);
var ADVIT_CONDID = new Array(
	"","","","",""
	,"","","","","SYONIN_JOTAI"
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","MEISAI_SORT_TF010F01",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"",""
);
var ADVIT_ACTIONID = new Array(
	"","COD","","SPT","SPT"
	,"SPT","SPT","","",""
	,"","","","",""
	,"COD","","","COD",""
	,"","","","",""
	,"","","COD","",""
	,"COD","","COD","",""
	,"FRM","FRM","FRM","PGN",""
	,"","","","FRM",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","FRM"
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","TF010F01","TF010F01"
	,"TF010F01","TF010F01","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"TF010F01","TF010F01","TF010F01","",""
	,"","","","TF010F02",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","TF010F01"
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","M1",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"",""
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
	,"","","","",""
	,"",""
);
var ADVIT_CAPTION = new Array(
	"店舗","","","確定","修正"
	,"取消","照会","","","承認状態"
	,"申請日ＦＲＯＭ","申請日ＴＯ","確定日ＦＲＯＭ","確定日ＴＯ","申請店舗ＦＲＯＭ"
	,"","","申請店舗ＴＯ","",""
	,"業務稟議NoＦＲＯＭ","業務稟議NoＴＯ","伝票番号ＦＲＯＭ","伝票番号ＴＯ","受理番号ＦＲＯＭ"
	,"受理番号ＴＯ","科目ＦＲＯＭ","","","科目ＴＯ"
	,"","","申請理由","",""
	,"検索","","","","No."
	,"申請日","申請店舗","","伝票番号","業務稟議No"
	,"受理番号","数量","原価金額","申請担当者","申請理由"
	,"却下理由","承認","却下","確定日","科目"
	,"","売価金額","確定担当者","",""
	,"","確定"
);

