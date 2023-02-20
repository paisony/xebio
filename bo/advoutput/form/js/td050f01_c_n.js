var ADVIT_FORMID = "TD050F01";
var ADVIT_TARGETPGID = "td050p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "td050f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,37,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,57,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_BTNMODETEISEI = 3;
var ADVIT_ID_BTNMODEDEL = 4;
var ADVIT_ID_MODENO = 5;
var ADVIT_ID_STKMODENO = 6;
var ADVIT_ID_DENPYO_BANGO_FROM = 7;
var ADVIT_ID_DENPYO_BANGO_TO = 8;
var ADVIT_ID_SIJI_BANGO_FROM = 9;
var ADVIT_ID_SIJI_BANGO_TO = 10;
var ADVIT_ID_SIIRESAKI_CD = 11;
var ADVIT_ID_BTNSIIRESAKI_CD = 12;
var ADVIT_ID_SIIRESAKI_RYAKU_NM = 13;
var ADVIT_ID_BUMON_CD_FROM = 14;
var ADVIT_ID_BTNBUMON_CD_FROM = 15;
var ADVIT_ID_BUMON_NM_FROM = 16;
var ADVIT_ID_BUMON_CD_TO = 17;
var ADVIT_ID_BTNBUMON_CD_TO = 18;
var ADVIT_ID_BUMON_NM_TO = 19;
var ADVIT_ID_HENPIN_KAKUTEI_YMD_FROM = 20;
var ADVIT_ID_HENPIN_KAKUTEI_YMD_TO = 21;
var ADVIT_ID_ADD_YMD_FROM = 22;
var ADVIT_ID_ADD_YMD_TO = 23;
var ADVIT_ID_NYURYOKUTAN_CD = 24;
var ADVIT_ID_BTNNYURYOKUTANTO_CD = 25;
var ADVIT_ID_NYURYOKUTAN_NM = 26;
var ADVIT_ID_KAKUTEITAN_CD = 27;
var ADVIT_ID_BTNKAKUTEITANTO_CD = 28;
var ADVIT_ID_KAKUTEITAN_NM = 29;
var ADVIT_ID_HENPIN_RIYU = 30;
var ADVIT_ID_OLD_JISYA_HBN = 31;
var ADVIT_ID_MAKER_HBN = 32;
var ADVIT_ID_SCAN_CD = 33;
var ADVIT_ID_SEARCHCNT = 34;
var ADVIT_ID_BTNSEARCH = 35;
var ADVIT_ID_PGR = 36;
var ADVIT_ID_M1ROWNO = 37;
var ADVIT_ID_M1BUMON_CD_BO1 = 38;
var ADVIT_ID_M1BUMONKANA_NM = 39;
var ADVIT_ID_M1SIIRESAKI_CD = 40;
var ADVIT_ID_M1SIIRESAKI_RYAKU_NM = 41;
var ADVIT_ID_M1BURANDO_NM = 42;
var ADVIT_ID_M1HENPIN_KAKUTEI_YMD = 43;
var ADVIT_ID_M1ADD_YMD = 44;
var ADVIT_ID_M1MOTODENPYO_BANGO = 45;
var ADVIT_ID_M1AKA_DENPYO_BANGO = 46;
var ADVIT_ID_M1KURO_DENPYO_BANGO = 47;
var ADVIT_ID_M1ITEMSU = 48;
var ADVIT_ID_M1TEISEI_SURYO = 49;
var ADVIT_ID_M1GENKAKIN = 50;
var ADVIT_ID_M1NYURYOKUTAN_NM = 51;
var ADVIT_ID_M1KAKUTEITAN_NM = 52;
var ADVIT_ID_M1HENPIN_RIYU_NM = 53;
var ADVIT_ID_M1SIJI_BANGO = 54;
var ADVIT_ID_M1SELECTORCHECKBOX = 55;
var ADVIT_ID_M1ENTERSYORIFLG = 56;
var ADVIT_ID_M1DTLIROKBN = 57;
var ADVIT_ID_BTNENTER = 58;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Btnmodeteisei","Btnmodedel"
	,"Modeno","Stkmodeno","Denpyo_bango_from","Denpyo_bango_to","Siji_bango_from"
	,"Siji_bango_to","Siiresaki_cd","Btnsiiresaki_cd","Siiresaki_ryaku_nm","Bumon_cd_from"
	,"Btnbumon_cd_from","Bumon_nm_from","Bumon_cd_to","Btnbumon_cd_to","Bumon_nm_to"
	,"Henpin_kakutei_ymd_from","Henpin_kakutei_ymd_to","Add_ymd_from","Add_ymd_to","Nyuryokutan_cd"
	,"Btnnyuryokutanto_cd","Nyuryokutan_nm","Kakuteitan_cd","Btnkakuteitanto_cd","Kakuteitan_nm"
	,"Henpin_riyu","Old_jisya_hbn","Maker_hbn","Scan_cd","Searchcnt"
	,"Btnsearch","Pgr","M1rowno","M1bumon_cd_bo1","M1bumonkana_nm"
	,"M1siiresaki_cd","M1siiresaki_ryaku_nm","M1burando_nm","M1henpin_kakutei_ymd","M1add_ymd"
	,"M1motodenpyo_bango","M1aka_denpyo_bango","M1kuro_denpyo_bango","M1itemsu","M1teisei_suryo"
	,"M1genkakin","M1nyuryokutan_nm","M1kakuteitan_nm","M1henpin_riyu_nm","M1siji_bango"
	,"M1selectorcheckbox","M1entersyoriflg","M1dtlirokbn","Btnenter"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","モード訂正ボタン","モード取消ボタン"
	,"モードNO","選択モードNO","伝票番号FROM","伝票番号TO","指示番号FROM"
	,"指示番号TO","仕入先コード","仕入先コードボタン","仕入先略式名称","部門コードFROM"
	,"部門コードFROMボタン","部門名FROM","部門コードTO","部門コードTOボタン","部門名TO"
	,"返品確定日FROM","返品確定日TO","登録日FROM","登録日TO","入力担当者コード"
	,"入力担当者コードボタン","入力担当者名称","確定担当者コード","確定担当者コードボタン","確定担当者名称"
	,"返品理由","旧自社品番","メーカー品番","スキャンコード","検索件数"
	,"検索ボタン","ページャ","Ｍ１行NO","Ｍ１部門コード","Ｍ１部門カナ名"
	,"Ｍ１仕入先コード","Ｍ１仕入先略式名称","Ｍ１ブランド名","Ｍ１返品確定日","Ｍ１登録日"
	,"Ｍ１元伝リンク","Ｍ１赤伝票番号","Ｍ１黒伝票番号","Ｍ１数量","Ｍ１訂正数量"
	,"Ｍ１原価金額","Ｍ１入力担当者名称","Ｍ１確定担当者名称","Ｍ１返品理由名称","Ｍ１指示番号"
	,"Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)","確定ボタン"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","B","B"
	,"NA","NA","NA","NA","SG"
	,"SG","SG","B","SN4","SG"
	,"B","SN4","SG","B","SN4"
	,"D","D","D","D","SG"
	,"B","SN4","SG","B","SN4"
	,"SN5","SG","SN9","SG","NA"
	,"B","B","NA","SG","SN9"
	,"SG","SN4","SN9","D","D"
	,"B","NA","NA","NA","NA"
	,"NA","SN4","SN4","SN4","SG"
	,"NA","NA","NA","B"
);
var ADVIT_LENGTH = new Array(
	4,0,15,0,0
	,2,2,6,6,24
	,24,4,0,20,3
	,0,15,3,0,15
	,0,0,0,0,7
	,0,12,7,0,12
	,1,10,30,18,4
	,0,0,3,3,30
	,4,20,20,0,0
	,0,6,6,9,9
	,9,12,12,4,10
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
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","LNK","LNK"
	,"HDN","HDN","TXT","TXT","TXT"
	,"TXT","TXT","BTN","TXR","TXT"
	,"BTN","TXR","TXT","BTN","TXR"
	,"TXT","TXT","TXT","TXT","TXT"
	,"BTN","TXR","TXT","BTN","TXR"
	,"DRL","TXT","TXR","TXT","TXR"
	,"BTS","LNS","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"BTS","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"CHK","HDN","HDN","BTS"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","00","00"
	,"11","11","10","10","00"
	,"00","10","00","00","10"
	,"00","00","10","00","00"
	,"52","52","52","52","10"
	,"00","00","10","00","00"
	,"00","00","00","00","12"
	,"00","00","11","10","00"
	,"10","00","00","52","52"
	,"00","10","10","12","12"
	,"12","00","00","00","10"
	,"11","11","11","00"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"","","","",""
	,"","","C_SIIRESAKI_CD","",""
	,"C_BUMON_CD","","","C_BUMON_CD",""
	,"","","","",""
	,"C_TANTO_CD","","","C_TANTO_CD",""
	,"","","","",""
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
	,"","","","",""
	,"","","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
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
	,0,0,0,0,0
	,0,0,0,0,0
	,1,1,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,1
);
var ADVIT_IMEMODE = new Array(
	3,0,0,0,0
	,0,0,3,3,3
	,3,3,0,0,3
	,0,0,3,0,0
	,3,3,3,3,3
	,0,0,3,0,0
	,0,3,0,3,0
	,0,0,0,0,0
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
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,0,0
	,0,0,1,1,1
	,1,1,0,0,1
	,0,0,1,0,0
	,1,0,1,1,1
	,0,0,1,0,0
	,0,1,0,1,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0
);
var ADVIT_CONDID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"HENPIN_RIYU_KBN","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","",""
);
var ADVIT_ACTIONID = new Array(
	"","COD","","SPT","SPT"
	,"","","","",""
	,"","","COD","",""
	,"COD","","","COD",""
	,"","","","",""
	,"COD","","","COD",""
	,"","","","",""
	,"FRM","PGN","","",""
	,"","","","",""
	,"FRM","","","",""
	,"","","","",""
	,"","","","FRM"
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","TD050F01","TD050F01"
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"TD050F01","","","",""
	,"","","","",""
	,"TD050F02","","","",""
	,"","","","",""
	,"","","","TD050F01"
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","M1","","",""
	,"","","","",""
	,"M1","","","",""
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
	,"","","","",""
	,"","","","",""
	,"","","",""
);
var ADVIT_CAPTION = new Array(
	"店舗","","","訂正","取消"
	,"","","伝票番号ＦＲＯＭ","伝票番号ＴＯ","指示番号ＦＲＯＭ"
	,"指示番号ＴＯ","仕入先","","","部門コードＦＲＯＭ"
	,"","","部門コードＴＯ","",""
	,"返品確定日ＦＲＯＭ","返品確定日ＴＯ","登録日ＦＲＯＭ","登録日ＴＯ","入力担当者"
	,"","","確定担当者","",""
	,"返品理由","自社品番","","ｽｷｬﾝｺｰﾄﾞ",""
	,"検索","","No.","部門",""
	,"仕入先","","ブランド","返品確定日","登録日"
	,"元伝","赤伝","黒伝","数量","訂正数"
	,"原価金額","入力担当者","確定担当者","返品理由","指示番号"
	,"","","","確定"
);

