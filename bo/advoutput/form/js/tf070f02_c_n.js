var ADVIT_FORMID = "TF070F02";
var ADVIT_TARGETPGID = "tf070p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tf070f02.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,21,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,48,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_BTNBACK = 0;
var ADVIT_ID_HEAD_TENPO_CD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_STKMODENO = 3;
var ADVIT_ID_TONANHINKANRI_NO = 4;
var ADVIT_ID_JIKOHASSEI_YMD = 5;
var ADVIT_ID_HOKOKU_YMD = 6;
var ADVIT_ID_HOKOKUTAN_CD = 7;
var ADVIT_ID_BTNHOKOKUTANTO_CD = 8;
var ADVIT_ID_HOKOKUTAN_NM = 9;
var ADVIT_ID_TENTYOTAN_CD = 10;
var ADVIT_ID_BTNTENHCHOTANTO_CD = 11;
var ADVIT_ID_TENTYOTAN_NM = 12;
var ADVIT_ID_KEISATSUTODOKE_YMD = 13;
var ADVIT_ID_TODOKEDESAKIKEISATSU_NM = 14;
var ADVIT_ID_JYURI_NO = 15;
var ADVIT_ID_BTNROWINS = 16;
var ADVIT_ID_BTNPAGEINS = 17;
var ADVIT_ID_BTNROWDEL = 18;
var ADVIT_ID_BTNCSV_TORIKOMI = 19;
var ADVIT_ID_PGR = 20;
var ADVIT_ID_M1ROWNO = 21;
var ADVIT_ID_M1HASSEI_TM = 22;
var ADVIT_ID_M1HASSEIBASYO = 23;
var ADVIT_ID_M1BUMON_CD = 24;
var ADVIT_ID_M1BUMONKANA_NM = 25;
var ADVIT_ID_M1HINSYU_RYAKU_NM = 26;
var ADVIT_ID_M1HAKKENTAN_CD = 27;
var ADVIT_ID_M1BTNTANTO_CD = 28;
var ADVIT_ID_M1HAKKENTAN_NM = 29;
var ADVIT_ID_M1BURANDO_NM = 30;
var ADVIT_ID_M1JISYA_HBN = 31;
var ADVIT_ID_M1HAKKENJYOKYO_KB = 32;
var ADVIT_ID_M1HAKKENJYOKYO_NM = 33;
var ADVIT_ID_M1MAKER_HBN = 34;
var ADVIT_ID_M1SYONMK = 35;
var ADVIT_ID_M1IRO_NM = 36;
var ADVIT_ID_M1SIZE_NM = 37;
var ADVIT_ID_M1SCAN_CD = 38;
var ADVIT_ID_M1SINSEI_SU = 39;
var ADVIT_ID_M1JYURI_SU = 40;
var ADVIT_ID_M1BAIKA_HON = 41;
var ADVIT_ID_M1BAIKA_KIN = 42;
var ADVIT_ID_M1SINSEI_SU_HDN = 43;
var ADVIT_ID_M1JYURI_SU_HDN = 44;
var ADVIT_ID_M1BAIKA_KIN_HDN = 45;
var ADVIT_ID_M1SELECTORCHECKBOX = 46;
var ADVIT_ID_M1ENTERSYORIFLG = 47;
var ADVIT_ID_M1DTLIROKBN = 48;
var ADVIT_ID_GOKEISINSEI_SU = 49;
var ADVIT_ID_GOKEIJYURI_SU = 50;
var ADVIT_ID_GOKEIBAIKA_KIN = 51;
var ADVIT_ID_BTNENTER = 52;

var ADVIT_ID = new Array(
	"Btnback","Head_tenpo_cd","Head_tenpo_nm","Stkmodeno","Tonanhinkanri_no"
	,"Jikohassei_ymd","Hokoku_ymd","Hokokutan_cd","Btnhokokutanto_cd","Hokokutan_nm"
	,"Tentyotan_cd","Btntenhchotanto_cd","Tentyotan_nm","Keisatsutodoke_ymd","Todokedesakikeisatsu_nm"
	,"Jyuri_no","Btnrowins","Btnpageins","Btnrowdel","Btncsv_torikomi"
	,"Pgr","M1rowno","M1hassei_tm","M1hasseibasyo","M1bumon_cd"
	,"M1bumonkana_nm","M1hinsyu_ryaku_nm","M1hakkentan_cd","M1btntanto_cd","M1hakkentan_nm"
	,"M1burando_nm","M1jisya_hbn","M1hakkenjyokyo_kb","M1hakkenjyokyo_nm","M1maker_hbn"
	,"M1syonmk","M1iro_nm","M1size_nm","M1scan_cd","M1sinsei_su"
	,"M1jyuri_su","M1baika_hon","M1baika_kin","M1sinsei_su_hdn","M1jyuri_su_hdn"
	,"M1baika_kin_hdn","M1selectorcheckbox","M1entersyoriflg","M1dtlirokbn","Gokeisinsei_su"
	,"Gokeijyuri_su","Gokeibaika_kin","Btnenter"
);
var ADVIT_NAME = new Array(
	"戻るボタン","ヘッダ店舗コード","ヘッダ店舗名","選択モードNO","盗難品管理番号"
	,"事故発生日","報告日","報告担当者コード","報告担当者コードボタン","報告担当者名称"
	,"店長担当者コード","店長担当者コードボタン","店長担当者名称","警察届出日","届出先警察署名"
	,"受理番号","行追加ボタン","ページ追加ボタン","行削除ボタン","CSV取込ボタン"
	,"ページャ","Ｍ１行NO","Ｍ１発生時間","Ｍ１発生場所","Ｍ１部門コード"
	,"Ｍ１部門カナ名","Ｍ１品種略名称","Ｍ１発見担当者コード","Ｍ１担当者コードボタン","Ｍ１発見担当者名称"
	,"Ｍ１ブランド名","Ｍ１自社品番","Ｍ１発見状況区分","Ｍ１発見状況","Ｍ１メーカー品番"
	,"Ｍ１商品名(カナ)","Ｍ１色","Ｍ１サイズ","Ｍ１スキャンコード","Ｍ１申請数"
	,"Ｍ１受理数","Ｍ１売価（本体）","Ｍ１売価金額","Ｍ１申請数（隠し）","Ｍ１受理数（隠し）"
	,"Ｍ１売価金額（隠し）","Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)","合計申請数"
	,"合計受理数","合計売価金額","確定ボタン"
);
var ADVIT_ATTRIBUTE = new Array(
	"B","SG","SN4","NA","NA"
	,"D","D","SG","B","SN4"
	,"SG","B","SN4","D","SN22"
	,"SB1","B","B","B","B"
	,"B","NA","NA","SN21","SG"
	,"SN9","SN4","SG","B","SN4"
	,"SN9","SG","SN5","SN21","SN9"
	,"SN4","SN9","SN9","SG","NA"
	,"NA","NA","NA","NA","NA"
	,"NA","NA","NA","NA","NA"
	,"NA","NA","B"
);
var ADVIT_LENGTH = new Array(
	0,4,15,2,6
	,0,0,7,0,12
	,7,0,12,0,40
	,10,0,0,0,0
	,0,4,2,20,3
	,30,15,7,0,12
	,20,8,1,80,30
	,30,10,4,18,3
	,3,8,8,3,3
	,8,1,1,2,4
	,4,8,0
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
	0,0,0,0,0
	,1,0,0,0,0
	,1,0,0,0,0
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
	"BTS","TXR","TXR","HDN","TXR"
	,"TXT","TXT","TXT","BTN","TXR"
	,"TXT","BTN","TXR","TXT","TXT"
	,"TXT","BTS","BTS","BTS","BTS"
	,"LNS","TXR","TXT","TXT","TXR"
	,"TXR","TXR","TXT","BTN","TXR"
	,"TXR","TXR","DRL","TXT","TXR"
	,"TXR","TXR","TXR","TXT","TXT"
	,"TXT","TXR","TXR","HDN","HDN"
	,"HDN","CHK","HDN","HDN","TXR"
	,"TXR","TXR","BTS"
);
var ADVIT_FORMAT = new Array(
	"00","10","00","11","10"
	,"52","52","10","00","00"
	,"10","00","00","52","00"
	,"00","00","00","00","00"
	,"00","11","10","00","10"
	,"00","00","10","00","00"
	,"00","10","00","00","00"
	,"00","00","00","00","12"
	,"12","12","12","11","11"
	,"11","11","11","11","12"
	,"12","12","00"
);
var ADVIT_CODEID = new Array(
	"","","","",""
	,"","","","C_TANTO_CD",""
	,"","C_TANTO_CD","","",""
	,"","","","",""
	,"","","","",""
	,"","","","C_TANTO_CD",""
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
	,"","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1",""
	,"","",""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,1,0,1
	,1,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,1
);
var ADVIT_IMEMODE = new Array(
	0,0,0,0,0
	,3,3,3,0,0
	,3,0,0,3,1
	,3,0,0,0,0
	,0,0,3,1,0
	,0,0,3,0,0
	,0,0,0,1,0
	,0,0,0,3,3
	,3,0,0,0,0
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
	0,0,0,0,0
	,1,1,1,0,0
	,1,0,0,1,1
	,1,0,0,0,0
	,0,0,1,1,0
	,0,0,1,0,0
	,0,0,0,1,0
	,0,0,0,1,1
	,1,0,0,0,0
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
	,"","","HAKKENJYOKYO_KB","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","",""
);
var ADVIT_ACTIONID = new Array(
	"FRM","","","",""
	,"","","","COD",""
	,"","COD","","",""
	,"","MADD","MINSX","FRM","FRM"
	,"PGN","","","",""
	,"","","","COD",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","FRM"
);
var ADVIT_ACTIONFORMID = new Array(
	"TF070F01","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","TF070F02","TF070F02"
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","TF070F01"
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","M1","M1","","M1"
	,"M1","","","",""
	,"","","","",""
	,"","","","",""
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
	,"","","","",""
	,"","","","",""
	,"","",""
);
var ADVIT_CAPTION = new Array(
	"","","","","管理番号"
	,"事故発生日","報告日","報告者","",""
	,"店長","","","警察届出日","届出警察署"
	,"受理番号","","","",""
	,"","No.","時間","発生場所","部門"
	,"","品種","発見者","",""
	,"ブランド","自社品番","発見状況","発見状況","メーカー品番"
	,"商品名","色","サイズ","スキャンコード","申請数"
	,"受理数","売価","売価金額","",""
	,"","","","","合計"
	,"","","確定"
);

