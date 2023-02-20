var ADVIT_FORMID = "TK040F01";
var ADVIT_TARGETPGID = "tk040p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tk040f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,25,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,42,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_BUMON_CD_FROM = 3;
var ADVIT_ID_BTNBUMON_CD_FROM = 4;
var ADVIT_ID_BUMON_NM_FROM = 5;
var ADVIT_ID_BUMON_CD_TO = 6;
var ADVIT_ID_BTNBUMON_CD_TO = 7;
var ADVIT_ID_BUMON_NM_TO = 8;
var ADVIT_ID_HANBAIKANRYO_YMD_FROM = 9;
var ADVIT_ID_HANBAIKANRYO_YMD_TO = 10;
var ADVIT_ID_OLD_JISYA_HBN = 11;
var ADVIT_ID_OLD_JISYA_HBN2 = 12;
var ADVIT_ID_OLD_JISYA_HBN3 = 13;
var ADVIT_ID_OLD_JISYA_HBN4 = 14;
var ADVIT_ID_OLD_JISYA_HBN5 = 15;
var ADVIT_ID_SCAN_CD = 16;
var ADVIT_ID_SCAN_CD2 = 17;
var ADVIT_ID_SCAN_CD3 = 18;
var ADVIT_ID_SCAN_CD4 = 19;
var ADVIT_ID_SCAN_CD5 = 20;
var ADVIT_ID_SEARCHCNT = 21;
var ADVIT_ID_BTNSEARCH = 22;
var ADVIT_ID_BTNPRINT = 23;
var ADVIT_ID_PGR = 24;
var ADVIT_ID_M1ROWNO = 25;
var ADVIT_ID_M1BUMON_CD = 26;
var ADVIT_ID_M1BUMONKANA_NM = 27;
var ADVIT_ID_M1HINSYU_RYAKU_NM = 28;
var ADVIT_ID_M1BURANDO_NM = 29;
var ADVIT_ID_M1JISYA_HBN = 30;
var ADVIT_ID_M1MAKER_HBN = 31;
var ADVIT_ID_M1SYONMK = 32;
var ADVIT_ID_M1HANBAIKANRYO_YMD = 33;
var ADVIT_ID_M1IRO_NM = 34;
var ADVIT_ID_M1SIZE_NM = 35;
var ADVIT_ID_M1SCAN_CD = 36;
var ADVIT_ID_M1FACE_NO = 37;
var ADVIT_ID_M1TANA_DAN = 38;
var ADVIT_ID_M1TANAOROSI_SU = 39;
var ADVIT_ID_M1SELECTORCHECKBOX = 40;
var ADVIT_ID_M1ENTERSYORIFLG = 41;
var ADVIT_ID_M1DTLIROKBN = 42;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Bumon_cd_from","Btnbumon_cd_from"
	,"Bumon_nm_from","Bumon_cd_to","Btnbumon_cd_to","Bumon_nm_to","Hanbaikanryo_ymd_from"
	,"Hanbaikanryo_ymd_to","Old_jisya_hbn","Old_jisya_hbn2","Old_jisya_hbn3","Old_jisya_hbn4"
	,"Old_jisya_hbn5","Scan_cd","Scan_cd2","Scan_cd3","Scan_cd4"
	,"Scan_cd5","Searchcnt","Btnsearch","Btnprint","Pgr"
	,"M1rowno","M1bumon_cd","M1bumonkana_nm","M1hinsyu_ryaku_nm","M1burando_nm"
	,"M1jisya_hbn","M1maker_hbn","M1syonmk","M1hanbaikanryo_ymd","M1iro_nm"
	,"M1size_nm","M1scan_cd","M1face_no","M1tana_dan","M1tanaorosi_su"
	,"M1selectorcheckbox","M1entersyoriflg","M1dtlirokbn"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","部門コードFROM","部門コードFROMボタン"
	,"部門名FROM","部門コードTO","部門コードTOボタン","部門名TO","販売完了日FROM"
	,"販売完了日TO","旧自社品番","旧自社品番2","旧自社品番3","旧自社品番4"
	,"旧自社品番5","スキャンコード","スキャンコード2","スキャンコード3","スキャンコード4"
	,"スキャンコード5","検索件数","検索ボタン","印刷ボタン","ページャ"
	,"Ｍ１NO","Ｍ１部門コード","Ｍ１部門カナ名","Ｍ１品種略名称","Ｍ１ブランド名"
	,"Ｍ１自社品番","Ｍ１メーカー品番","Ｍ１商品名(カナ)","Ｍ１販売完了日","Ｍ１色"
	,"Ｍ１サイズ","Ｍ１スキャンコード","Ｍ１フェイス№","Ｍ１棚段","Ｍ１棚卸数量"
	,"Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","SG","B"
	,"SN4","SG","B","SN4","D"
	,"D","SG","SG","SG","SG"
	,"SG","SG","SG","SG","SG"
	,"SG","NA","B","B","B"
	,"NA","SG","SN9","SN4","SN9"
	,"SG","SN9","SN9","D","SN9"
	,"SN9","SG","NA","NA","NA"
	,"NA","NA","NA"
);
var ADVIT_LENGTH = new Array(
	4,0,15,3,0
	,15,3,0,15,0
	,0,10,10,10,10
	,10,18,18,18,18
	,18,4,0,0,0
	,4,3,30,15,20
	,8,30,30,0,10
	,4,18,5,2,4
	,1,1,2
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
	"TXT","BTN","TXR","TXT","BTN"
	,"TXR","TXT","BTN","TXR","TXT"
	,"TXT","TXT","TXT","TXT","TXT"
	,"TXT","TXT","TXT","TXT","TXT"
	,"TXT","TXR","BTS","BTS","LNS"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"CHK","HDN","HDN"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","10","00"
	,"00","10","00","00","52"
	,"52","00","00","00","00"
	,"00","00","00","00","00"
	,"00","12","00","00","00"
	,"11","10","00","00","00"
	,"10","00","00","52","00"
	,"00","00","10","11","12"
	,"11","11","11"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","","C_BUMON_CD"
	,"","","C_BUMON_CD","",""
	,"","","","",""
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
	,"CANNOTGET","CANNOTGET","CANNOTGET"
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1"
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,1,1,1
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0
);
var ADVIT_IMEMODE = new Array(
	3,0,0,3,0
	,0,3,0,0,3
	,3,3,3,3,3
	,3,3,3,3,3
	,3,0,0,0,0
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
	1,0,0,1,0
	,0,1,0,0,1
	,1,1,1,1,1
	,1,1,1,1,1
	,1,0,0,0,0
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
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","",""
);
var ADVIT_ACTIONID = new Array(
	"","COD","","","COD"
	,"","","COD","",""
	,"","","","",""
	,"","","","",""
	,"","","FRM","FRM","PGN"
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","",""
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","TK040F01","TK040F01",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","",""
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","","M1"
	,"","","","",""
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
	"店舗","","","部門FROM",""
	,"","部門TO","","","販売完了日FROM"
	,"販売完了日TO","自社品番1","自社品番2","自社品番3","自社品番4"
	,"自社品番5","ｽｷｬﾝｺｰﾄﾞ1","ｽｷｬﾝｺｰﾄﾞ2","ｽｷｬﾝｺｰﾄﾞ3","ｽｷｬﾝｺｰﾄﾞ4"
	,"ｽｷｬﾝｺｰﾄﾞ5","","検索","",""
	,"No.","部門","","品種","ブランド"
	,"自社品番","メーカー品番","商品名","販売完了日","色"
	,"サイズ","ｽｷｬﾝｺｰﾄﾞ","ﾌｪｲｽNo","棚段","数量"
	,"","",""
);

