var ADVIT_FORMID = "TA080F02";
var ADVIT_TARGETPGID = "ta080p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "ta080f02.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,15,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,44,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_BTNBACK = 0;
var ADVIT_ID_HEAD_TENPO_CD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_YOSAN_YMD = 3;
var ADVIT_ID_YOSAN_CD = 4;
var ADVIT_ID_YOSAN_NM = 5;
var ADVIT_ID_YOSAN_KIN = 6;
var ADVIT_ID_MISINSEI_SU = 7;
var ADVIT_ID_MISINSEI_KIN = 8;
var ADVIT_ID_APPLY_SU = 9;
var ADVIT_ID_APPLY_KIN = 10;
var ADVIT_ID_JISSEKI_SU_BO2 = 11;
var ADVIT_ID_JISSEKI_KIN = 12;
var ADVIT_ID_ZAN_KIN = 13;
var ADVIT_ID_PGR = 14;
var ADVIT_ID_M1ROWNO = 15;
var ADVIT_ID_M1APPLY_YMD = 16;
var ADVIT_ID_M1SINSEI_SB = 17;
var ADVIT_ID_M1HANBAIIN_CD = 18;
var ADVIT_ID_M1HANBAIIN_NM = 19;
var ADVIT_ID_M1IRAI_RIYU = 20;
var ADVIT_ID_M1BUMON_CD = 21;
var ADVIT_ID_M1BUMONKANA_NM = 22;
var ADVIT_ID_M1HINSYU_CD = 23;
var ADVIT_ID_M1HINSYU_RYAKU_NM = 24;
var ADVIT_ID_M1BURANDO_NM = 25;
var ADVIT_ID_M1JISYA_HBN = 26;
var ADVIT_ID_M1SYOHIN_ZOKUSEI = 27;
var ADVIT_ID_M1MAKER_HBN = 28;
var ADVIT_ID_M1SYONMK = 29;
var ADVIT_ID_M1IRO_NM = 30;
var ADVIT_ID_M1SIZE_NM = 31;
var ADVIT_ID_M1SCAN_CD = 32;
var ADVIT_ID_M1NYUKAYOTEI_YMD = 33;
var ADVIT_ID_M1SEASON_NM = 34;
var ADVIT_ID_M1HANBAIKANRYO_YMD = 35;
var ADVIT_ID_M1APPLY_SU = 36;
var ADVIT_ID_M1APPLY_KIN = 37;
var ADVIT_ID_M1JISSEKI_SU = 38;
var ADVIT_ID_M1JISSEKI_KIN = 39;
var ADVIT_ID_M1JOTAI_KBN_NM = 40;
var ADVIT_ID_M1COMMENT_NM = 41;
var ADVIT_ID_M1SELECTORCHECKBOX = 42;
var ADVIT_ID_M1ENTERSYORIFLG = 43;
var ADVIT_ID_M1DTLIROKBN = 44;

var ADVIT_ID = new Array(
	"Btnback","Head_tenpo_cd","Head_tenpo_nm","Yosan_ymd","Yosan_cd"
	,"Yosan_nm","Yosan_kin","Misinsei_su","Misinsei_kin","Apply_su"
	,"Apply_kin","Jisseki_su_bo2","Jisseki_kin","Zan_kin","Pgr"
	,"M1rowno","M1apply_ymd","M1sinsei_sb","M1hanbaiin_cd","M1hanbaiin_nm"
	,"M1irai_riyu","M1bumon_cd","M1bumonkana_nm","M1hinsyu_cd","M1hinsyu_ryaku_nm"
	,"M1burando_nm","M1jisya_hbn","M1syohin_zokusei","M1maker_hbn","M1syonmk"
	,"M1iro_nm","M1size_nm","M1scan_cd","M1nyukayotei_ymd","M1season_nm"
	,"M1hanbaikanryo_ymd","M1apply_su","M1apply_kin","M1jisseki_su","M1jisseki_kin"
	,"M1jotai_kbn_nm","M1comment_nm","M1selectorcheckbox","M1entersyoriflg","M1dtlirokbn"
);
var ADVIT_NAME = new Array(
	"戻るボタン","ヘッダ店舗コード","ヘッダ店舗名","年月度","仕入枠グループコード"
	,"仕入枠グループ名","予算金額","未申請数","未申請金額","申請数"
	,"申請金額","実績数","実績金額","残金額","ページャ"
	,"Ｍ１行NO","Ｍ１申請日","Ｍ１申請種別","Ｍ１登録担当者コード","Ｍ１登録担当者名"
	,"Ｍ１依頼理由","Ｍ１部門コード","Ｍ１部門カナ名","Ｍ１品種コード","Ｍ１品種略名称"
	,"Ｍ１ブランド名","Ｍ１自社品番","Ｍ１商品属性","Ｍ１メーカー品番","Ｍ１商品名(カナ)"
	,"Ｍ１色","Ｍ１サイズ","Ｍ１スキャンコード","Ｍ１入荷予定日","Ｍ１シーズン"
	,"Ｍ１販売完了日","Ｍ１申請数","Ｍ１申請金額","Ｍ１実績数","Ｍ１実績金額"
	,"Ｍ１状態","Ｍ１コメント","Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)"
);
var ADVIT_ATTRIBUTE = new Array(
	"B","SG","SN4","D","SN4"
	,"SN4","NC","NC","NC","NC"
	,"NC","NC","NC","NC","B"
	,"NA","NA","SN4","SN5","SN4"
	,"SN4","SG","SN4","SG","SN4"
	,"SN9","SG","SN9","SN9","SN9"
	,"SN9","SN9","SG","D","SN4"
	,"D","NA","NA","NA","NA"
	,"SN4","SN4","NA","NA","NA"
);
var ADVIT_LENGTH = new Array(
	0,4,15,0,6
	,8,8,8,9,8
	,9,8,9,9,0
	,4,8,4,8,12
	,10,3,15,2,15
	,20,8,3,30,30
	,10,4,18,0,2
	,0,8,9,8,9
	,20,40,1,1,2
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
);
var ADVIT_REQUIREDFLG = new Array(
	0,0,0,0,0
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
	"BTS","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","LNS"
	,"LBL","LBL","LBL","TXT","TXR"
	,"TXR","LBL","TXR","LBL","TXR"
	,"TXR","LBL","LBL","TXR","TXR"
	,"TXR","TXR","LBL","LBL","TXR"
	,"LBL","LBL","LBL","LBL","LBL"
	,"TXR","TXR","CHK","HDN","HDN"
);
var ADVIT_FORMAT = new Array(
	"00","10","00","54","00"
	,"00","12","12","12","12"
	,"12","12","12","12","00"
	,"11","11","00","00","00"
	,"00","10","00","10","00"
	,"00","10","00","00","00"
	,"00","00","00","52","00"
	,"52","12","12","12","12"
	,"00","00","11","11","11"
);
var ADVIT_CODEID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
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
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,1
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
);
var ADVIT_IMEMODE = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
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
);
var ADVIT_MAXLENGTHMODE = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
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
	,"","","","",""
);
var ADVIT_ACTIONID = new Array(
	"FRM","","","",""
	,"","","","",""
	,"","","","","PGN"
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
);
var ADVIT_ACTIONFORMID = new Array(
	"TA080F01","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
);
var ADVIT_ACTPARAMETER = new Array(
	"M1","","","",""
	,"","","","",""
	,"","","","","M1"
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
);
var ADVIT_CAPTION = new Array(
	"","","","年月度","仕入枠ｸﾞﾙｰﾌﾟ"
	,"","予算金額","未申請数","未申請金額","申請数"
	,"申請金額","実績数","実績金額","残金額",""
	,"No.","申請日","申請種別","登録担当者",""
	,"依頼理由","部門","","品種",""
	,"ブランド","自社品番","コア","メーカー品番","商品名"
	,"色","サイズ","スキャンコード","入荷予定日","シーズン"
	,"販完日","申請数","申請金額","実績数","実績金額"
	,"状態","コメント","","",""
);

