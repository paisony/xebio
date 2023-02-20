var ADVIT_FORMID = "TF021F02";
var ADVIT_TARGETPGID = "tf021p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tf021f02.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,22,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,42,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_BTNBACK = 0;
var ADVIT_ID_HEAD_TENPO_CD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_STKMODENO = 3;
var ADVIT_ID_ADD_YMD = 4;
var ADVIT_ID_APPLY_YMD = 5;
var ADVIT_ID_SINSEIRIYU_KB = 6;
var ADVIT_ID_SINSEIRIYU = 7;
var ADVIT_ID_DENPYO_BANGO = 8;
var ADVIT_ID_KANRI_NO = 9;
var ADVIT_ID_KAMOKU_CD = 10;
var ADVIT_ID_BTNKAMOKUCD = 11;
var ADVIT_ID_KAMOKU_NM = 12;
var ADVIT_ID_KYAKKARIYU = 13;
var ADVIT_ID_GYOMURINGI_NO = 14;
var ADVIT_ID_JYURI_NO = 15;
var ADVIT_ID_SYONIN_FLG_NM = 16;
var ADVIT_ID_BTNROWINS = 17;
var ADVIT_ID_BTNPAGEINS = 18;
var ADVIT_ID_BTNROWDEL = 19;
var ADVIT_ID_BTNCSV_TORIKOMI = 20;
var ADVIT_ID_PGR = 21;
var ADVIT_ID_M1ROWNO = 22;
var ADVIT_ID_M1BUMON_CD = 23;
var ADVIT_ID_M1BUMONKANA_NM = 24;
var ADVIT_ID_M1BURANDO_NM = 25;
var ADVIT_ID_M1MAKER_HBN = 26;
var ADVIT_ID_M1IRO_NM = 27;
var ADVIT_ID_M1SCAN_CD = 28;
var ADVIT_ID_M1SURYO = 29;
var ADVIT_ID_M1GEN_TNK = 30;
var ADVIT_ID_M1GENKA_KIN = 31;
var ADVIT_ID_M1HINSYU_RYAKU_NM = 32;
var ADVIT_ID_M1JISYA_HBN = 33;
var ADVIT_ID_M1SYONMK = 34;
var ADVIT_ID_M1SIZE_NM = 35;
var ADVIT_ID_M1GENBAIKA_TNK = 36;
var ADVIT_ID_M1GOKEIBAIKA_KIN = 37;
var ADVIT_ID_M1SURYO_HDN = 38;
var ADVIT_ID_M1GENKA_KIN_HDN = 39;
var ADVIT_ID_M1SELECTORCHECKBOX = 40;
var ADVIT_ID_M1ENTERSYORIFLG = 41;
var ADVIT_ID_M1DTLIROKBN = 42;
var ADVIT_ID_GOKEI_SURYO = 43;
var ADVIT_ID_GENKA_KIN_GOKEI = 44;
var ADVIT_ID_BTNENTER = 45;

var ADVIT_ID = new Array(
	"Btnback","Head_tenpo_cd","Head_tenpo_nm","Stkmodeno","Add_ymd"
	,"Apply_ymd","Sinseiriyu_kb","Sinseiriyu","Denpyo_bango","Kanri_no"
	,"Kamoku_cd","Btnkamokucd","Kamoku_nm","Kyakkariyu","Gyomuringi_no"
	,"Jyuri_no","Syonin_flg_nm","Btnrowins","Btnpageins","Btnrowdel"
	,"Btncsv_torikomi","Pgr","M1rowno","M1bumon_cd","M1bumonkana_nm"
	,"M1burando_nm","M1maker_hbn","M1iro_nm","M1scan_cd","M1suryo"
	,"M1gen_tnk","M1genka_kin","M1hinsyu_ryaku_nm","M1jisya_hbn","M1syonmk"
	,"M1size_nm","M1genbaika_tnk","M1gokeibaika_kin","M1suryo_hdn","M1genka_kin_hdn"
	,"M1selectorcheckbox","M1entersyoriflg","M1dtlirokbn","Gokei_suryo","Genka_kin_gokei"
	,"Btnenter"
);
var ADVIT_NAME = new Array(
	"戻るボタン","ヘッダ店舗コード","ヘッダ店舗名","選択モードNO","登録日"
	,"申請日","申請理由区分","申請理由","伝票番号","管理No"
	,"科目コード","科目コードボタン","科目名","却下理由","業務稟議No"
	,"受理番号","承認状態名称","行追加ボタン","ページ追加ボタン","行削除ボタン"
	,"CSV取込ボタン","ページャ","Ｍ１行NO","Ｍ１部門コード","Ｍ１部門カナ名"
	,"Ｍ１ブランド名","Ｍ１メーカー品番","Ｍ１色","Ｍ１スキャンコード","Ｍ１数量"
	,"Ｍ１原単価","Ｍ１原価金額","Ｍ１品種略名称","Ｍ１自社品番","Ｍ１商品名(カナ)"
	,"Ｍ１サイズ","Ｍ１現売価","Ｍ１合計売価金額","Ｍ１数量（隠し）","Ｍ１原価金額(隠し)"
	,"Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)","合計数量","合計原価金額"
	,"確定ボタン"
);
var ADVIT_ATTRIBUTE = new Array(
	"B","SG","SN4","NA","D"
	,"D","SN5","SN22","NA","NA"
	,"SG","B","SN4","SN4","SG"
	,"SB","SN4","B","B","B"
	,"B","B","NA","SG","SN9"
	,"SN9","SN9","SN9","SG","NC"
	,"NA","NA","SN4","SG","SN9"
	,"SN9","NA","NA","NA","NA"
	,"NA","NA","NA","NA","NA"
	,"B"
);
var ADVIT_LENGTH = new Array(
	0,4,15,2,0
	,0,2,30,6,6
	,8,0,20,30,4
	,10,3,0,0,0
	,0,0,3,3,30
	,20,30,10,18,3
	,8,12,15,8,30
	,4,8,12,3,12
	,1,1,2,4,12
	,0
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
	,0
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
	,0
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
	,0
);
var ADVIT_REQUIREDFLG = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,1,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0
);
var ADVIT_TYPE = new Array(
	"BTS","TXR","TXR","HDN","TXR"
	,"TXR","DRL","TXT","TXR","TXR"
	,"TXT","BTN","TXR","TXR","TXT"
	,"TXR","TXR","BTS","BTS","BTS"
	,"BTS","LNS","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXT","TXT"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","HDN","HDN"
	,"CHK","HDN","HDN","TXR","TXR"
	,"BTS"
);
var ADVIT_FORMAT = new Array(
	"00","10","00","11","52"
	,"52","00","00","10","10"
	,"10","00","00","00","10"
	,"00","00","00","00","00"
	,"00","00","11","10","00"
	,"00","00","00","00","12"
	,"12","12","00","10","00"
	,"00","12","12","12","12"
	,"11","11","11","12","12"
	,"00"
);
var ADVIT_CODEID = new Array(
	"","","","",""
	,"","C_MEISYO_CD","","",""
	,"","C_KAMOKU_CD","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,""
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
	,"CANNOTGET"
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","",""
	,""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,1,0
	,1,1,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,1
);
var ADVIT_IMEMODE = new Array(
	0,0,0,0,0
	,0,0,1,0,0
	,3,0,0,0,3
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,3,3
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0
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
	,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	0,0,0,0,0
	,0,0,1,0,0
	,1,0,0,0,1
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,1,1
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0
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
	,""
);
var ADVIT_ACTIONID = new Array(
	"FRM","","","",""
	,"","COD","","",""
	,"","COD","","",""
	,"","","MADD","MINSX","FRM"
	,"FRM","PGN","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"FRM"
);
var ADVIT_ACTIONFORMID = new Array(
	"TF021F01","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","","TF021F02"
	,"TF021F02","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"TF021F01"
);
var ADVIT_ACTPARAMETER = new Array(
	"M1","","","",""
	,"","","","",""
	,"","","","",""
	,"","","M1","M1",""
	,"","M1","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,""
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
	,""
);
var ADVIT_CAPTION = new Array(
	"","","","","登録日"
	,"申請日","申請理由","申請理由","伝票番号","管理No"
	,"科目","","","却下理由","業務稟議No"
	,"受理番号","承認状態","","",""
	,"","","No.","部門","部門"
	,"ブランド","メーカー品番","色","スキャンコード","数量"
	,"原単価","原価金額","品種","自社品番","商品名"
	,"サイズ","現売価","売価金額","",""
	,"","","","合計","原価合計"
	,"確定"
);

