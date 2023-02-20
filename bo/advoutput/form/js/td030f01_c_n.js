var ADVIT_FORMID = "TD030F01";
var ADVIT_TARGETPGID = "td030p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "td030f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,36,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,59,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_DENPYO_JYOTAI = 3;
var ADVIT_ID_DENPYO_BANGO_FROM = 4;
var ADVIT_ID_DENPYO_BANGO_TO = 5;
var ADVIT_ID_MOTODENPYO_BANGO_FROM = 6;
var ADVIT_ID_MOTODENPYO_BANGO_TO = 7;
var ADVIT_ID_SIJI_BANGO_FROM = 8;
var ADVIT_ID_SIJI_BANGO_TO = 9;
var ADVIT_ID_SIIRESAKI_CD = 10;
var ADVIT_ID_BTNSIIRESAKI_CD = 11;
var ADVIT_ID_SIIRESAKI_RYAKU_NM = 12;
var ADVIT_ID_BUMON_CD_FROM = 13;
var ADVIT_ID_BTNBUMON_CD_FROM = 14;
var ADVIT_ID_BUMON_NM_FROM = 15;
var ADVIT_ID_BUMON_CD_TO = 16;
var ADVIT_ID_BTNBUMON_CD_TO = 17;
var ADVIT_ID_BUMON_NM_TO = 18;
var ADVIT_ID_HENPIN_KAKUTEI_YMD_FROM = 19;
var ADVIT_ID_HENPIN_KAKUTEI_YMD_TO = 20;
var ADVIT_ID_ADD_YMD_FROM = 21;
var ADVIT_ID_ADD_YMD_TO = 22;
var ADVIT_ID_NYURYOKUTAN_CD = 23;
var ADVIT_ID_BTNNYURYOKUTANTO_CD = 24;
var ADVIT_ID_NYURYOKUTAN_NM = 25;
var ADVIT_ID_KAKUTEITAN_CD = 26;
var ADVIT_ID_BTNKAKUTEITANTO_CD = 27;
var ADVIT_ID_KAKUTEITAN_NM = 28;
var ADVIT_ID_HENPIN_RIYU = 29;
var ADVIT_ID_OLD_JISYA_HBN = 30;
var ADVIT_ID_MAKER_HBN = 31;
var ADVIT_ID_SCAN_CD = 32;
var ADVIT_ID_SEARCHCNT = 33;
var ADVIT_ID_BTNSEARCH = 34;
var ADVIT_ID_BTNPRINT = 35;
var ADVIT_ID_M1ROWNO = 36;
var ADVIT_ID_M1BUMON_CD_BO1 = 37;
var ADVIT_ID_M1BUMONKANA_NM = 38;
var ADVIT_ID_M1SIIRESAKI_CD = 39;
var ADVIT_ID_M1SIIRESAKI_RYAKU_NM = 40;
var ADVIT_ID_M1BURANDO_NM = 41;
var ADVIT_ID_M1HENPIN_KAKUTEI_YMD = 42;
var ADVIT_ID_M1ADD_YMD = 43;
var ADVIT_ID_M1DENPYO_BANGO = 44;
var ADVIT_ID_M1KANRI_NO = 45;
var ADVIT_ID_M1SIJI_BANGO = 46;
var ADVIT_ID_M1MOTODENPYO_BANGO = 47;
var ADVIT_ID_M1ITEMSU = 48;
var ADVIT_ID_M1GENKAKIN = 49;
var ADVIT_ID_M1NYURYOKUTAN_NM = 50;
var ADVIT_ID_M1KAKUTEITAN_NM = 51;
var ADVIT_ID_M1HENPIN_RIYU_NM = 52;
var ADVIT_ID_M1DENPYO_JYOTAINM = 53;
var ADVIT_ID_M1SYORINM = 54;
var ADVIT_ID_M1SYORIYMD = 55;
var ADVIT_ID_M1SYORI_TM = 56;
var ADVIT_ID_M1SELECTORCHECKBOX = 57;
var ADVIT_ID_M1ENTERSYORIFLG = 58;
var ADVIT_ID_M1DTLIROKBN = 59;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Denpyo_jyotai","Denpyo_bango_from"
	,"Denpyo_bango_to","Motodenpyo_bango_from","Motodenpyo_bango_to","Siji_bango_from","Siji_bango_to"
	,"Siiresaki_cd","Btnsiiresaki_cd","Siiresaki_ryaku_nm","Bumon_cd_from","Btnbumon_cd_from"
	,"Bumon_nm_from","Bumon_cd_to","Btnbumon_cd_to","Bumon_nm_to","Henpin_kakutei_ymd_from"
	,"Henpin_kakutei_ymd_to","Add_ymd_from","Add_ymd_to","Nyuryokutan_cd","Btnnyuryokutanto_cd"
	,"Nyuryokutan_nm","Kakuteitan_cd","Btnkakuteitanto_cd","Kakuteitan_nm","Henpin_riyu"
	,"Old_jisya_hbn","Maker_hbn","Scan_cd","Searchcnt","Btnsearch"
	,"Btnprint","M1rowno","M1bumon_cd_bo1","M1bumonkana_nm","M1siiresaki_cd"
	,"M1siiresaki_ryaku_nm","M1burando_nm","M1henpin_kakutei_ymd","M1add_ymd","M1denpyo_bango"
	,"M1kanri_no","M1siji_bango","M1motodenpyo_bango","M1itemsu","M1genkakin"
	,"M1nyuryokutan_nm","M1kakuteitan_nm","M1henpin_riyu_nm","M1denpyo_jyotainm","M1syorinm"
	,"M1syoriymd","M1syori_tm","M1selectorcheckbox","M1entersyoriflg","M1dtlirokbn"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","伝票状態","伝票番号ＦＲＯＭ"
	,"伝票番号ＴＯ","元伝票番号ＦＲＯＭ","元伝票番号ＴＯ","指示番号ＦＲＯＭ","指示番号ＴＯ"
	,"仕入先コード","仕入先コードボタン","仕入先略式名称","部門コードＦＲＯＭ","部門コードＦＲＯＭボタン"
	,"部門名ＦＲＯＭ","部門コードＴＯ","部門コードＴＯボタン","部門名ＴＯ","返品確定日ＦＲＯＭ"
	,"返品確定日ＴＯ","登録日ＦＲＯＭ","登録日ＴＯ","入力担当者コード","入力担当者コードボタン"
	,"入力担当者名称","確定担当者コード","確定担当者コードボタン","確定担当者名称","返品理由"
	,"旧自社品番","メーカー品番","スキャンコード","検索件数","検索ボタン"
	,"印刷ボタン","Ｍ１行NO","Ｍ１部門コード","Ｍ１部門カナ名","Ｍ１仕入先コード"
	,"Ｍ１仕入先略式名称","Ｍ１ブランド名","Ｍ１返品確定日","Ｍ１登録日","Ｍ１伝票番号リンク"
	,"Ｍ１管理番号リンク","Ｍ１指示番号","Ｍ１元伝票番号","Ｍ１数量","Ｍ１原価金額"
	,"Ｍ１入力担当者名称","Ｍ１確定担当者名称","Ｍ１返品理由名称","Ｍ１伝票状態名称","Ｍ１処理名称"
	,"Ｍ１処理日","Ｍ１処理時間","Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","SN5","NA"
	,"NA","NA","NA","SG","SG"
	,"SG","B","SN4","SG","B"
	,"SN4","SG","B","SN4","D"
	,"D","D","D","SG","B"
	,"SN4","SG","B","SN4","SN5"
	,"SG","SN9","SG","NA","B"
	,"B","NA","SG","SN9","SG"
	,"SN4","SN9","D","D","B"
	,"B","NA","NA","NA","NA"
	,"SN4","SN4","SN4","SN4","SN4"
	,"D","D","NA","NA","NA"
);
var ADVIT_LENGTH = new Array(
	4,0,15,1,6
	,6,6,6,24,24
	,4,0,20,3,0
	,15,3,0,15,0
	,0,0,0,7,0
	,12,7,0,12,1
	,10,30,18,4,0
	,0,3,3,30,4
	,20,20,0,0,0
	,0,10,6,8,9
	,12,12,4,7,4
	,0,0,1,1,2
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
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","DRL","TXT"
	,"TXT","TXT","TXT","TXT","TXT"
	,"TXT","BTN","TXR","TXT","BTN"
	,"TXR","TXT","BTN","TXR","TXT"
	,"TXT","TXT","TXT","TXT","BTN"
	,"TXR","TXT","BTN","TXR","DRL"
	,"TXT","TXR","TXT","TXR","BTS"
	,"BTS","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","BTS"
	,"BTS","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","CHK","HDN","HDN"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","00","10"
	,"10","10","10","00","00"
	,"10","00","00","10","00"
	,"00","10","00","00","52"
	,"52","52","52","10","00"
	,"00","10","00","00","00"
	,"00","00","00","12","00"
	,"00","11","10","00","10"
	,"00","00","52","52","00"
	,"00","10","10","12","12"
	,"00","00","00","00","00"
	,"52","56","11","11","11"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"","","","",""
	,"","C_SIIRESAKI_CD","","","C_BUMON_CD"
	,"","","C_BUMON_CD","",""
	,"","","","","C_TANTO_CD"
	,"","","C_TANTO_CD","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
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
	,"","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
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
	,0,0,0,0,0
	,0,0,0,0,1
	,1,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
);
var ADVIT_IMEMODE = new Array(
	3,0,0,0,3
	,3,3,3,3,3
	,3,0,0,3,0
	,0,3,0,0,3
	,3,3,3,3,0
	,0,3,0,0,0
	,3,0,3,0,0
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
	,0,0,0,0,0
	,0,0,0,0,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,0,1
	,1,1,1,1,1
	,1,0,0,1,0
	,0,1,0,0,1
	,1,1,1,1,0
	,0,1,0,0,0
	,1,0,1,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
);
var ADVIT_CONDID = new Array(
	"","","","HENPIN_DENPYO_JOTAI",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","","HENPIN_RIYU_KBN"
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
);
var ADVIT_ACTIONID = new Array(
	"","COD","","",""
	,"","","","",""
	,"","COD","","","COD"
	,"","","COD","",""
	,"","","","","COD"
	,"","","COD","",""
	,"","","","","FRM"
	,"FRM","","","",""
	,"","","","","FRM"
	,"FRM","","","",""
	,"","","","",""
	,"","","","",""
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","","TD030F01"
	,"TD030F01","","","",""
	,"","","","","TD030F02"
	,"TD030F02","","","",""
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
	,"","","","",""
	,"","","","",""
	,"","","","",""
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
	,"","","","",""
	,"","","","",""
);
var ADVIT_CAPTION = new Array(
	"店舗","","","伝票状態","伝票番号ＦＲＯＭ"
	,"伝票番号ＴＯ","元伝票番号ＦＲＯＭ","元伝票番号ＴＯ","指示番号ＦＲＯＭ","指示番号ＴＯ"
	,"仕入先","","","部門ＦＲＯＭ",""
	,"","部門ＴＯ","","","返品確定日ＦＲＯＭ"
	,"返品確定日ＴＯ","登録日ＦＲＯＭ","登録日ＴＯ","入力担当者",""
	,"","確定担当者","","","返品理由"
	,"自社品番","","ｽｷｬﾝｺｰﾄﾞ","","検索"
	,"","No.","部門","","仕入先"
	,"","ブランド","返品確定日","登録日","伝票番号"
	,"管理番号","指示番号","元伝票番号","数量","原価金額"
	,"入力担当者","確定担当者","返品理由","伝票状態","処理"
	,"処理日","処理時間","","",""
);

