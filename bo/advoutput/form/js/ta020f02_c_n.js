var ADVIT_FORMID = "TA020F02";
var ADVIT_TARGETPGID = "ta020p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "ta020f02.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,15,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,40,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_BTNBACK = 0;
var ADVIT_ID_HEAD_TENPO_CD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_STKMODENO = 3;
var ADVIT_ID_IRAI_YMD = 4;
var ADVIT_ID_TANTOSYA_CD = 5;
var ADVIT_ID_HANBAIIN_NM = 6;
var ADVIT_ID_IRAIRIYU_CD = 7;
var ADVIT_ID_BTNZENSTK = 8;
var ADVIT_ID_BTNZENKJO = 9;
var ADVIT_ID_BTNROWINS = 10;
var ADVIT_ID_BTNPAGEINS = 11;
var ADVIT_ID_BTNSIZSTK = 12;
var ADVIT_ID_BTNROWDEL = 13;
var ADVIT_ID_PGR = 14;
var ADVIT_ID_M1ROWNO = 15;
var ADVIT_ID_M1BUMONKANA_NM = 16;
var ADVIT_ID_M1HYOKA_KB = 17;
var ADVIT_ID_M1KAHI_NM = 18;
var ADVIT_ID_M1TENZAIKO_SU = 19;
var ADVIT_ID_M1HINSYU_RYAKU_NM = 20;
var ADVIT_ID_M1NYUKAYOTEI_SU = 21;
var ADVIT_ID_M1URIAGE_SU = 22;
var ADVIT_ID_M1BURANDO_NM = 23;
var ADVIT_ID_M1JIDO_SU = 24;
var ADVIT_ID_M1JISYA_HBN = 25;
var ADVIT_ID_M1SYOHIN_ZOKUSEI = 26;
var ADVIT_ID_M1IRO_NM = 27;
var ADVIT_ID_M1SIZE_NM = 28;
var ADVIT_ID_M1MAKER_HBN = 29;
var ADVIT_ID_M1SYONMK = 30;
var ADVIT_ID_M1HATCHU_MSG = 31;
var ADVIT_ID_M1SCAN_CD = 32;
var ADVIT_ID_M1IRAI_SU = 33;
var ADVIT_ID_M1GENKAKIN = 34;
var ADVIT_ID_M1IRAI_SU_HDN = 35;
var ADVIT_ID_M1GEN_TNK = 36;
var ADVIT_ID_M1GENKAKIN_HDN = 37;
var ADVIT_ID_M1SELECTORCHECKBOX = 38;
var ADVIT_ID_M1ENTERSYORIFLG = 39;
var ADVIT_ID_M1DTLIROKBN = 40;
var ADVIT_ID_GOKEI_IRAI_SU = 41;
var ADVIT_ID_GOKEI_GENKAKIN = 42;
var ADVIT_ID_BTNENTER = 43;

var ADVIT_ID = new Array(
	"Btnback","Head_tenpo_cd","Head_tenpo_nm","Stkmodeno","Irai_ymd"
	,"Tantosya_cd","Hanbaiin_nm","Irairiyu_cd","Btnzenstk","Btnzenkjo"
	,"Btnrowins","Btnpageins","Btnsizstk","Btnrowdel","Pgr"
	,"M1rowno","M1bumonkana_nm","M1hyoka_kb","M1kahi_nm","M1tenzaiko_su"
	,"M1hinsyu_ryaku_nm","M1nyukayotei_su","M1uriage_su","M1burando_nm","M1jido_su"
	,"M1jisya_hbn","M1syohin_zokusei","M1iro_nm","M1size_nm","M1maker_hbn"
	,"M1syonmk","M1hatchu_msg","M1scan_cd","M1irai_su","M1genkakin"
	,"M1irai_su_hdn","M1gen_tnk","M1genkakin_hdn","M1selectorcheckbox","M1entersyoriflg"
	,"M1dtlirokbn","Gokei_irai_su","Gokei_genkakin","Btnenter"
);
var ADVIT_NAME = new Array(
	"戻るボタン","ヘッダ店舗コード","ヘッダ店舗名","選択モードNO","依頼日"
	,"担当者コード","担当者名","依頼理由コード","全選択ボタン","全解除ボタン"
	,"行追加ボタン","ページ追加ボタン","サイズ選択ボタン","行削除ボタン","ページャ"
	,"Ｍ１行NO","Ｍ１部門カナ名","Ｍ１評価区分","Ｍ１可否名称","Ｍ１店在庫数"
	,"Ｍ１品種略名称","Ｍ１入荷予定数","Ｍ１売上実績数","Ｍ１ブランド名","Ｍ１自動定数"
	,"Ｍ１自社品番","Ｍ１商品属性","Ｍ１色","Ｍ１サイズ","Ｍ１メーカー品番"
	,"Ｍ１商品名(カナ)","Ｍ１発注メッセージ","Ｍ１スキャンコード","Ｍ１依頼数量","Ｍ１原価金額"
	,"Ｍ１依頼数量(隠し)","Ｍ１原単価(隠し)","Ｍ１原価金額(隠し)","Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)"
	,"Ｍ１明細色区分(隠し)","合計依頼数量","合計原価金額","確定ボタン"
);
var ADVIT_ATTRIBUTE = new Array(
	"B","SG","SN4","NA","D"
	,"SG","SN4","SN5","B","B"
	,"B","B","B","B","B"
	,"NA","SN9","SN4","SN4","NA"
	,"SN4","NA","NA","SN9","NA"
	,"SG","SN9","SN9","SN9","SN9"
	,"SN9","SN4","SG","NA","NA"
	,"NA","NA","NA","NA","NA"
	,"NA","NA","NA","B"
);
var ADVIT_LENGTH = new Array(
	0,4,15,2,0
	,7,12,2,0,0
	,0,0,0,0,0
	,4,30,1,2,5
	,15,5,5,20,5
	,8,3,10,4,30
	,30,6,18,7,7
	,7,7,7,1,1
	,2,9,9,0
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
	,0,0,0,0
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
	,0,0,0,0
);
var ADVIT_TYPE = new Array(
	"BTS","TXR","TXR","HDN","TXR"
	,"TXR","TXR","DRL","BTS","BTS"
	,"BTS","BTS","BTS","BTS","LNS"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXT","TXT","TXR"
	,"HDN","HDN","HDN","CHK","HDN"
	,"HDN","TXR","TXR","BTS"
);
var ADVIT_FORMAT = new Array(
	"00","10","00","11","52"
	,"10","00","00","00","00"
	,"00","00","00","00","00"
	,"11","00","00","00","12"
	,"00","12","12","00","12"
	,"10","00","00","00","00"
	,"00","00","00","12","12"
	,"12","12","12","11","11"
	,"11","12","12","00"
);
var ADVIT_CODEID = new Array(
	"","","","",""
	,"","","C_RIYU_CD","",""
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
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
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
	,"M1","","",""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,1,0,1
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,1
);
var ADVIT_IMEMODE = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,3,3,0
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
	,0,0,0,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,1,1,0
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
	,"","","","",""
	,"","","","",""
	,"","","",""
);
var ADVIT_ACTIONID = new Array(
	"FRM","","","",""
	,"","","COD","FRM","FRM"
	,"MADD","MINSX","FRM","FRM","PGN"
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","DBU"
);
var ADVIT_ACTIONFORMID = new Array(
	"TA020F01","","","",""
	,"","","","TA020F02","TA020F02"
	,"","","TA020F02","TA020F02",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","TA020F01"
);
var ADVIT_ACTPARAMETER = new Array(
	"M1","","","",""
	,"","","","",""
	,"M1","M1","","","M1"
	,"","","","",""
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
	,"","","",""
);
var ADVIT_CAPTION = new Array(
	"","","","","依頼日"
	,"担当者","","依頼理由","",""
	,"","","","",""
	,"No.","部門","評価","補充","在庫"
	,"品種","入荷","売上","ブランド","自動定数"
	,"自社品番","コア","色","サイズ","メーカー品番"
	,"商品名","メッセージ","スキャンコード","依頼数","原価金額"
	,"","","","",""
	,"","","","確定"
);

