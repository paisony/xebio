var ADVIT_FORMID = "TM040F01";
var ADVIT_TARGETPGID = "tm040p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tm040f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,10,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,14,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_MODENO = 0;
var ADVIT_ID_STKMODENO = 1;
var ADVIT_ID_OLD_JISYA_HBN = 2;
var ADVIT_ID_SCAN_CD = 3;
var ADVIT_ID_BUMON_NM = 4;
var ADVIT_ID_HINSYU_RYAKU_NM = 5;
var ADVIT_ID_BURANDO_NM = 6;
var ADVIT_ID_MAKER_HBN = 7;
var ADVIT_ID_SYONMK = 8;
var ADVIT_ID_BTNSEARCH = 9;
var ADVIT_ID_M1ROWNO = 10;
var ADVIT_ID_M1IRO_NM = 11;
var ADVIT_ID_M1SELECTORCHECKBOX = 12;
var ADVIT_ID_M1ENTERSYORIFLG = 13;
var ADVIT_ID_M1DTLIROKBN = 14;
var ADVIT_ID_TENPO_CD = 15;
var ADVIT_ID_PLUFLG = 16;
var ADVIT_ID_PRICEFLG = 17;
var ADVIT_ID_ZAIKOFLG = 18;
var ADVIT_ID_NYUKAFLG = 19;
var ADVIT_ID_URIFLG = 20;
var ADVIT_ID_HOJUFLG = 21;
var ADVIT_ID_TANPINFLG = 22;
var ADVIT_ID_SIJIFLG = 23;
var ADVIT_ID_SIJI_BANGO = 24;
var ADVIT_ID_SYUKKAKAISYA_CD = 25;
var ADVIT_ID_JYURYOKAISYA_CD = 26;
var ADVIT_ID_SYUKKATEN_CD = 27;

var ADVIT_ID = new Array(
	"Modeno","Stkmodeno","Old_jisya_hbn","Scan_cd","Bumon_nm"
	,"Hinsyu_ryaku_nm","Burando_nm","Maker_hbn","Syonmk","Btnsearch"
	,"M1rowno","M1iro_nm","M1selectorcheckbox","M1entersyoriflg","M1dtlirokbn"
	,"Tenpo_cd","Pluflg","Priceflg","Zaikoflg","Nyukaflg"
	,"Uriflg","Hojuflg","Tanpinflg","Sijiflg","Siji_bango"
	,"Syukkakaisya_cd","Jyuryokaisya_cd","Syukkaten_cd"
);
var ADVIT_NAME = new Array(
	"モードNO","選択モードNO","旧自社品番","スキャンコード","部門名"
	,"品種略名称","ブランド名","メーカー品番","商品名(カナ)","検索ボタン"
	,"Ｍ１行NO","Ｍ１色リンク","Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)"
	,"店舗コード","店別単価マスタ検索フラグ","売変検索フラグ","店在庫検索フラグ","入荷予定数検索フラグ"
	,"売上実績数検索フラグ","依頼集計数(補充)検索フラグ","依頼集計数(単品)検索フラグ","指示検索フラグ","指示番号"
	,"出荷会社コード","入荷会社コード","出荷店コード"
);
var ADVIT_ATTRIBUTE = new Array(
	"NA","NA","SG","SG","SN4"
	,"SN4","SN9","SN9","SN9","B"
	,"NA","B","NA","NA","NA"
	,"SG","SG","SG","SG","SG"
	,"SG","SG","SG","SG","SG"
	,"SG","SG","SG"
);
var ADVIT_LENGTH = new Array(
	2,2,10,18,15
	,15,20,30,30,0
	,2,0,1,1,2
	,4,1,1,1,1
	,1,1,1,1,24
	,2,2,4
);
var ADVIT_AUTOTAB = new Array(
	0,0,0,0,0
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
	,0,0,0
);
var ADVIT_REQUIRED = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0
);
var ADVIT_REQUIREDFLG = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0
);
var ADVIT_TYPE = new Array(
	"HDN","HDN","TXT","TXT","TXR"
	,"TXR","TXR","TXR","TXR","BTS"
	,"TXR","BTS","CHK","HDN","HDN"
	,"HDN","HDN","HDN","HDN","HDN"
	,"HDN","HDN","HDN","HDN","HDN"
	,"HDN","HDN","HDN"
);
var ADVIT_FORMAT = new Array(
	"11","11","00","00","00"
	,"00","00","00","00","00"
	,"11","00","11","11","11"
	,"10","00","00","00","00"
	,"00","00","00","00","00"
	,"10","10","10"
);
var ADVIT_CODEID = new Array(
	"","","","",""
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
	,"CANNOTGET","CANNOTGET","CANNOTGET"
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
	,"M1","M1","M1","M1","M1"
	,"","","","",""
	,"","","","",""
	,"","",""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,1
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0
);
var ADVIT_IMEMODE = new Array(
	0,0,3,3,0
	,0,0,0,0,0
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
	,0,0,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	0,0,1,1,0
	,0,0,0,0,0
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
	,"","",""
);
var ADVIT_ACTIONID = new Array(
	"","","","",""
	,"","","","","FRM"
	,"","FRM","","",""
	,"","","","",""
	,"","","","",""
	,"","",""
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","",""
	,"","","","","TM040F01"
	,"","TM040F02","","",""
	,"","","","",""
	,"","","","",""
	,"","",""
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","M1","","",""
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
	,"","",""
);
var ADVIT_CAPTION = new Array(
	"","","自社品番","ｽｷｬﾝｺｰﾄﾞ","部門"
	,"品種","ブランド","メーカー品番","商品名","検索"
	,"No.","色","","",""
	,"","","","",""
	,"","","","",""
	,"","",""
);

