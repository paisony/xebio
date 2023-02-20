var ADVIT_FORMID = "TD040F01";
var ADVIT_TARGETPGID = "td040p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "td040f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,33,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,58,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_DENPYO_BANGO_FROM = 3;
var ADVIT_ID_DENPYO_BANGO_TO = 4;
var ADVIT_ID_BUMON_CD_FROM = 5;
var ADVIT_ID_BTNBUMON_CD_FROM = 6;
var ADVIT_ID_BUMON_NM_FROM = 7;
var ADVIT_ID_BUMON_CD_TO = 8;
var ADVIT_ID_BTNBUMON_CD_TO = 9;
var ADVIT_ID_BUMON_NM_TO = 10;
var ADVIT_ID_SIIRESAKI_CD = 11;
var ADVIT_ID_BTNSIIRESAKI_CD = 12;
var ADVIT_ID_SIIRESAKI_RYAKU_NM = 13;
var ADVIT_ID_BURANDO_CD = 14;
var ADVIT_ID_BTNBURANDO_CD = 15;
var ADVIT_ID_BURANDO_NM = 16;
var ADVIT_ID_NYURYOKUTAN_CD = 17;
var ADVIT_ID_BTNTANTO_CD = 18;
var ADVIT_ID_NYURYOKUTAN_NM = 19;
var ADVIT_ID_HENPIN_KAKUTEI_YMD_FROM = 20;
var ADVIT_ID_HENPIN_KAKUTEI_YMD_TO = 21;
var ADVIT_ID_ADD_YMD_FROM = 22;
var ADVIT_ID_ADD_YMD_TO = 23;
var ADVIT_ID_KAI_SU = 24;
var ADVIT_ID_HENPIN_RIYU = 25;
var ADVIT_ID_OLD_JISYA_HBN = 26;
var ADVIT_ID_MAKER_HBN = 27;
var ADVIT_ID_SCAN_CD = 28;
var ADVIT_ID_SEARCHCNT = 29;
var ADVIT_ID_BTNSEARCH = 30;
var ADVIT_ID_BTNPRINT = 31;
var ADVIT_ID_PGR = 32;
var ADVIT_ID_M1ROWNO = 33;
var ADVIT_ID_M1BUMON_CD = 34;
var ADVIT_ID_M1BUMONKANA_NM = 35;
var ADVIT_ID_M1SIIRESAKI_CD = 36;
var ADVIT_ID_M1SIIRESAKI_RYAKU_NM = 37;
var ADVIT_ID_M1KAKUTEI_YMD = 38;
var ADVIT_ID_M1ADD_YMD = 39;
var ADVIT_ID_M1DENPYO_BANGO = 40;
var ADVIT_ID_M1KANRI_NO = 41;
var ADVIT_ID_M1SIJI_BANGO = 42;
var ADVIT_ID_M1HINSYU_RYAKU_NM = 43;
var ADVIT_ID_M1NYURYOKUTAN_NM = 44;
var ADVIT_ID_M1BURANDO_NM = 45;
var ADVIT_ID_M1HENPIN_RIYU_NM = 46;
var ADVIT_ID_M1JISYA_HBN = 47;
var ADVIT_ID_M1MAKER_HBN = 48;
var ADVIT_ID_M1SYONMK = 49;
var ADVIT_ID_M1IRO_NM = 50;
var ADVIT_ID_M1SIZE_NM = 51;
var ADVIT_ID_M1SCAN_CD = 52;
var ADVIT_ID_M1ITEMSU = 53;
var ADVIT_ID_M1KAKUTEI_TM = 54;
var ADVIT_ID_M1KAI_SU = 55;
var ADVIT_ID_M1SELECTORCHECKBOX = 56;
var ADVIT_ID_M1ENTERSYORIFLG = 57;
var ADVIT_ID_M1DTLIROKBN = 58;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Denpyo_bango_from","Denpyo_bango_to"
	,"Bumon_cd_from","Btnbumon_cd_from","Bumon_nm_from","Bumon_cd_to","Btnbumon_cd_to"
	,"Bumon_nm_to","Siiresaki_cd","Btnsiiresaki_cd","Siiresaki_ryaku_nm","Burando_cd"
	,"Btnburando_cd","Burando_nm","Nyuryokutan_cd","Btntanto_cd","Nyuryokutan_nm"
	,"Henpin_kakutei_ymd_from","Henpin_kakutei_ymd_to","Add_ymd_from","Add_ymd_to","Kai_su"
	,"Henpin_riyu","Old_jisya_hbn","Maker_hbn","Scan_cd","Searchcnt"
	,"Btnsearch","Btnprint","Pgr","M1rowno","M1bumon_cd"
	,"M1bumonkana_nm","M1siiresaki_cd","M1siiresaki_ryaku_nm","M1kakutei_ymd","M1add_ymd"
	,"M1denpyo_bango","M1kanri_no","M1siji_bango","M1hinsyu_ryaku_nm","M1nyuryokutan_nm"
	,"M1burando_nm","M1henpin_riyu_nm","M1jisya_hbn","M1maker_hbn","M1syonmk"
	,"M1iro_nm","M1size_nm","M1scan_cd","M1itemsu","M1kakutei_tm"
	,"M1kai_su","M1selectorcheckbox","M1entersyoriflg","M1dtlirokbn"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","伝票番号FROM","伝票番号TO"
	,"部門コードFROM","部門コードFROMボタン","部門名FROM","部門コードTO","部門コードTOボタン"
	,"部門名TO","仕入先コード","仕入先コードボタン","仕入先略式名称","ブランドコード"
	,"ブランドコードボタン","ブランド名","入力担当者コード","担当者コードボタン","入力担当者名称"
	,"返品確定日FROM","返品確定日TO","登録日FROM","登録日TO","回数"
	,"返品理由","旧自社品番","メーカー品番","スキャンコード","検索件数"
	,"検索ボタン","印刷ボタン","ページャ","Ｍ１行NO","Ｍ１部門コード"
	,"Ｍ１部門カナ名","Ｍ１仕入先コード","Ｍ１仕入先略式名称","Ｍ１確定日","Ｍ１登録日"
	,"Ｍ１伝票番号","Ｍ１管理番号","Ｍ１指示番号","Ｍ１品種略名称","Ｍ１入力担当者名称"
	,"Ｍ１ブランド名","Ｍ１返品理由名称","Ｍ１自社品番","Ｍ１メーカー品番","Ｍ１商品名(カナ)"
	,"Ｍ１色","Ｍ１サイズ","Ｍ１スキャンコード","Ｍ１数量","Ｍ１確定時間"
	,"Ｍ１回数","Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","NA","NA"
	,"SG","B","SN4","SG","B"
	,"SN4","SG","B","SN4","SG"
	,"B","SN9","SG","B","SN4"
	,"D","D","D","D","NA"
	,"SN5","SG","SN9","SG","NA"
	,"B","B","B","NA","SG"
	,"SN9","SG","SN4","NA","NA"
	,"NA","NA","NA","SN4","SN4"
	,"SN9","SN4","SG","SN9","SN9"
	,"SN9","SN9","SG","NA","D"
	,"NA","NA","NA","NA"
);
var ADVIT_LENGTH = new Array(
	4,0,15,6,6
	,3,0,15,3,0
	,15,4,0,20,6
	,0,20,7,0,12
	,0,0,0,0,3
	,1,10,30,18,4
	,0,0,0,4,3
	,30,4,20,6,6
	,6,6,10,15,12
	,20,4,8,30,30
	,10,4,18,8,0
	,3,1,1,2
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
	"TXT","BTN","TXR","TXT","TXT"
	,"TXT","BTN","TXR","TXT","BTN"
	,"TXR","TXT","BTN","TXR","TXT"
	,"BTN","TXR","TXT","BTN","TXR"
	,"TXT","TXT","TXT","TXT","TXT"
	,"DRL","TXT","TXR","TXT","TXR"
	,"BTS","BTS","LNS","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","CHK","HDN","HDN"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","10","10"
	,"10","00","00","10","00"
	,"00","10","00","00","10"
	,"00","00","10","00","00"
	,"52","52","52","52","11"
	,"00","00","00","00","12"
	,"00","00","00","11","10"
	,"00","10","00","11","11"
	,"10","10","10","00","00"
	,"00","00","10","00","00"
	,"00","00","00","12","56"
	,"11","11","11","11"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"","C_BUMON_CD","","","C_BUMON_CD"
	,"","","C_SIIRESAKI_CD","",""
	,"C_BURANDO_CD","","","C_TANTO_CD",""
	,"","","","",""
	,"","","","",""
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
	,"","","","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1"
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,1,1,1,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0
);
var ADVIT_IMEMODE = new Array(
	3,0,0,3,3
	,3,0,0,3,0
	,0,3,0,0,3
	,0,0,3,0,0
	,3,3,3,3,3
	,0,3,0,3,0
	,0,0,0,0,0
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
	1,0,0,1,1
	,1,0,0,1,0
	,0,1,0,0,1
	,0,0,1,0,0
	,1,1,1,1,1
	,0,1,0,1,0
	,0,0,0,0,0
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
	,"HENPIN_RIYU_KBN","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","",""
);
var ADVIT_ACTIONID = new Array(
	"","COD","","",""
	,"","COD","","","COD"
	,"","","COD","",""
	,"COD","","","COD",""
	,"","","","",""
	,"","","","",""
	,"FRM","FRM","PGN","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","",""
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"TD040F01","TD040F01","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","",""
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","M1","",""
	,"","","","",""
	,"","","","",""
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
	,"","","","",""
	,"","","","",""
	,"","","",""
);
var ADVIT_CAPTION = new Array(
	"店舗","","","伝票番号ＦＲＯＭ","伝票番号ＴＯ"
	,"部門ＦＲＯＭ","","","部門ＴＯ",""
	,"","仕入先","","","ブランド"
	,"","","入力担当者","",""
	,"返品確定日ＦＲＯＭ","返品確定日ＴＯ","登録日ＦＲＯＭ","登録日ＴＯ","回数"
	,"返品理由","自社品番","","ｽｷｬﾝｺｰﾄﾞ",""
	,"検索","","","No.","部門"
	,"","仕入先","","確定日","登録日"
	,"伝票番号","管理番号","指示番号","品種","入力担当者"
	,"ブランド","返品理由","自社品番","メーカー品番","商品名"
	,"色","サイズ","スキャンコード","数量","確定時間"
	,"回数","","",""
);

