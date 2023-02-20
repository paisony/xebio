var ADVIT_FORMID = "TD010F01";
var ADVIT_TARGETPGID = "td010p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "td010f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,38,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,55,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_BTNMODEHENPINKAKUTEI = 3;
var ADVIT_ID_BTNMODEKAKUTEIMAEUPD = 4;
var ADVIT_ID_BTNMODEKAKUTEIMAEDEL = 5;
var ADVIT_ID_BTNMODEKAKUTEIGODEL = 6;
var ADVIT_ID_BTNMODEREF = 7;
var ADVIT_ID_MODENO = 8;
var ADVIT_ID_STKMODENO = 9;
var ADVIT_ID_SIJI_BANGO_FROM = 10;
var ADVIT_ID_SIJI_BANGO_TO = 11;
var ADVIT_ID_DENPYO_BANGO_FROM = 12;
var ADVIT_ID_DENPYO_BANGO_TO = 13;
var ADVIT_ID_SIIRESAKI_CD = 14;
var ADVIT_ID_BTNSIIRESAKI_CD = 15;
var ADVIT_ID_SIIRESAKI_RYAKU_NM = 16;
var ADVIT_ID_BUMON_CD_FROM = 17;
var ADVIT_ID_BTNBUMON_CD_FROM = 18;
var ADVIT_ID_BUMON_NM_FROM = 19;
var ADVIT_ID_BUMON_CD_TO = 20;
var ADVIT_ID_BTNBUMON_CD_TO = 21;
var ADVIT_ID_BUMON_NM_TO = 22;
var ADVIT_ID_BURANDO_CD = 23;
var ADVIT_ID_BTNBURANDO_CD = 24;
var ADVIT_ID_BURANDO_NM = 25;
var ADVIT_ID_HENPIN_KAKUTEI_YMD_FROM = 26;
var ADVIT_ID_HENPIN_KAKUTEI_YMD_TO = 27;
var ADVIT_ID_NYURYOKUTAN_CD = 28;
var ADVIT_ID_BTNTANTO_CD = 29;
var ADVIT_ID_NYURYOKUTAN_NM = 30;
var ADVIT_ID_ADD_YMD_FROM = 31;
var ADVIT_ID_ADD_YMD_TO = 32;
var ADVIT_ID_HENPIN_RIYU = 33;
var ADVIT_ID_SCAN_CD = 34;
var ADVIT_ID_SEARCHCNT = 35;
var ADVIT_ID_BTNSEARCH = 36;
var ADVIT_ID_BTNPRINT = 37;
var ADVIT_ID_M1ROWNO = 38;
var ADVIT_ID_M1SIJI_BANGO = 39;
var ADVIT_ID_M1BUMON_CD = 40;
var ADVIT_ID_M1BUMONKANA_NM = 41;
var ADVIT_ID_M1BURANDO_NM = 42;
var ADVIT_ID_M1SIIRESAKI_CD = 43;
var ADVIT_ID_M1SIIRESAKI_RYAKU_NM = 44;
var ADVIT_ID_M1HENPIN_KAKUTEI_YMD = 45;
var ADVIT_ID_M1DENPYO_BANGO = 46;
var ADVIT_ID_M1ADD_YMD = 47;
var ADVIT_ID_M1KANRI_NO = 48;
var ADVIT_ID_M1SURYO = 49;
var ADVIT_ID_M1GENKAKIN = 50;
var ADVIT_ID_M1NYURYOKUTAN_NM = 51;
var ADVIT_ID_M1HENPIN_RIYU_NM = 52;
var ADVIT_ID_M1SELECTORCHECKBOX = 53;
var ADVIT_ID_M1ENTERSYORIFLG = 54;
var ADVIT_ID_M1DTLIROKBN = 55;
var ADVIT_ID_BTNENTER = 56;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Btnmodehenpinkakutei","Btnmodekakuteimaeupd"
	,"Btnmodekakuteimaedel","Btnmodekakuteigodel","Btnmoderef","Modeno","Stkmodeno"
	,"Siji_bango_from","Siji_bango_to","Denpyo_bango_from","Denpyo_bango_to","Siiresaki_cd"
	,"Btnsiiresaki_cd","Siiresaki_ryaku_nm","Bumon_cd_from","Btnbumon_cd_from","Bumon_nm_from"
	,"Bumon_cd_to","Btnbumon_cd_to","Bumon_nm_to","Burando_cd","Btnburando_cd"
	,"Burando_nm","Henpin_kakutei_ymd_from","Henpin_kakutei_ymd_to","Nyuryokutan_cd","Btntanto_cd"
	,"Nyuryokutan_nm","Add_ymd_from","Add_ymd_to","Henpin_riyu","Scan_cd"
	,"Searchcnt","Btnsearch","Btnprint","M1rowno","M1siji_bango"
	,"M1bumon_cd","M1bumonkana_nm","M1burando_nm","M1siiresaki_cd","M1siiresaki_ryaku_nm"
	,"M1henpin_kakutei_ymd","M1denpyo_bango","M1add_ymd","M1kanri_no","M1suryo"
	,"M1genkakin","M1nyuryokutan_nm","M1henpin_riyu_nm","M1selectorcheckbox","M1entersyoriflg"
	,"M1dtlirokbn","Btnenter"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","モード返品確定ボタン","モード確定前修正ボタン"
	,"モード確定前取消ボタン","モード確定後取消ボタン","モード照会ボタン","モードNO","選択モードNO"
	,"指示番号ＦＲＯＭ","指示番号ＴＯ","伝票番号ＦＲＯＭ","伝票番号ＴＯ","仕入先コード"
	,"仕入先コードボタン","仕入先略式名称","部門コードＦＲＯＭ","部門コードＦＲＯＭボタン","部門名ＦＲＯＭ"
	,"部門コードＴＯ","部門コードＴＯボタン","部門名ＴＯ","ブランドコード","ブランドコードボタン"
	,"ブランド名","返品確定日ＦＲＯＭ","返品確定日ＴＯ","入力担当者コード","担当者コードボタン"
	,"入力担当者名称","登録日ＦＲＯＭ","登録日ＴＯ","返品理由","スキャンコード"
	,"検索件数","検索ボタン","印刷ボタン","Ｍ１行NO","Ｍ１指示番号"
	,"Ｍ１部門コード","Ｍ１部門カナ名","Ｍ１ブランド名","Ｍ１仕入先コード","Ｍ１仕入先略式名称"
	,"Ｍ１返品確定日","Ｍ１伝票番号リンク","Ｍ１登録日","Ｍ１管理番号リンク","Ｍ１数量"
	,"Ｍ１原価金額","Ｍ１入力担当者名称","Ｍ１返品理由名称","Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)"
	,"Ｍ１明細色区分(隠し)","確定ボタン"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","B","B"
	,"B","B","B","NA","NA"
	,"SG","SG","NA","NA","SG"
	,"B","SN4","SG","B","SN4"
	,"SG","B","SN4","SG","B"
	,"SN9","D","D","SG","B"
	,"SN4","D","D","SN5","SG"
	,"NA","B","B","NA","SG"
	,"SG","SN9","SN9","SG","SN4"
	,"D","B","D","B","NA"
	,"NA","SN4","SN4","NA","NA"
	,"NA","B"
);
var ADVIT_LENGTH = new Array(
	4,0,15,0,0
	,0,0,0,2,2
	,24,24,6,6,4
	,0,20,3,0,15
	,3,0,15,6,0
	,20,0,0,7,0
	,12,0,0,1,18
	,4,0,0,3,10
	,3,15,20,4,20
	,0,0,0,0,8
	,9,10,4,1,1
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
	,0,0
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","LNK","LNK"
	,"LNK","LNK","LNK","HDN","HDN"
	,"TXT","TXT","TXT","TXT","TXT"
	,"BTN","TXR","TXT","BTN","TXR"
	,"TXT","BTN","TXR","TXT","BTN"
	,"TXR","TXT","TXT","TXT","BTN"
	,"TXR","TXT","TXT","DRL","TXT"
	,"TXR","BTS","BTS","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","BTS","TXR","BTS","TXR"
	,"TXR","TXR","TXR","CHK","HDN"
	,"HDN","BTS"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","00","00"
	,"00","00","00","11","11"
	,"00","00","10","10","10"
	,"00","00","10","00","00"
	,"10","00","00","10","00"
	,"00","52","52","10","00"
	,"00","52","52","00","00"
	,"12","00","00","11","10"
	,"10","00","00","10","00"
	,"52","00","52","00","12"
	,"12","00","00","00","11"
	,"11","00"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"","","","",""
	,"","","","",""
	,"C_SIIRESAKI_CD","","","C_BUMON_CD",""
	,"","C_BUMON_CD","","","C_BURANDO_CD"
	,"","","","","C_TANTO_CD"
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
	,"","","","M1","M1"
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
	,0,1,1,0,0
	,0,0,0,0,0
	,0,1,0,1,0
	,0,0,0,0,0
	,0,1
);
var ADVIT_IMEMODE = new Array(
	3,0,0,0,0
	,0,0,0,0,0
	,3,3,3,3,3
	,0,0,3,0,0
	,3,0,0,3,0
	,0,3,3,3,0
	,0,3,3,0,3
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
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
	,0,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,0,0
	,0,0,0,0,0
	,1,1,1,1,1
	,0,0,1,0,0
	,1,0,0,1,0
	,0,1,1,1,0
	,0,1,1,0,1
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0
);
var ADVIT_CONDID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","HENPIN_RIYU_KBN",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"",""
);
var ADVIT_ACTIONID = new Array(
	"","COD","","SPT","SPT"
	,"SPT","SPT","SPT","",""
	,"","","","",""
	,"COD","","","COD",""
	,"","COD","","","COD"
	,"","","","","COD"
	,"","","","",""
	,"","FRM","FRM","",""
	,"","","","",""
	,"","FRM","","FRM",""
	,"","","","",""
	,"","FRM"
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","TD010F01","TD010F01","",""
	,"","","","",""
	,"","TD010F02","","TD010F02",""
	,"","","","",""
	,"","TD010F01"
);
var ADVIT_ACTPARAMETER = new Array(
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
	,"",""
);
var ADVIT_CAPTION = new Array(
	"店舗","","","返品確定","確定前修正"
	,"確定前取消","確定後取消","照会","",""
	,"指示番号ＦＲＯＭ","指示番号ＴＯ","伝票番号ＦＲＯＭ","伝票番号ＴＯ","仕入先"
	,"","","部門ＦＲＯＭ","",""
	,"部門ＴＯ","","","ブランド",""
	,"","返品確定日ＦＲＯＭ","返品確定日ＴＯ","入力担当者",""
	,"","登録日ＦＲＯＭ","登録日ＴＯ","返品理由","ｽｷｬﾝｺｰﾄﾞ"
	,"","検索","","No.","指示番号"
	,"部門","","ブランド","仕入先",""
	,"返品確定日","伝票番号","登録日","管理番号","数量"
	,"原価金額","入力担当者","返品理由","",""
	,"","確定"
);

