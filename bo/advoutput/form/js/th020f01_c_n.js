var ADVIT_FORMID = "TH020F01";
var ADVIT_TARGETPGID = "th020p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "th020f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,36,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,51,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_BTNMODEJISHAHINBAN = 3;
var ADVIT_ID_BTNMODEJISHAHINBAN2 = 4;
var ADVIT_ID_BTNMODESCANCD = 5;
var ADVIT_ID_BTNMODEMAKERHBN = 6;
var ADVIT_ID_MODENO = 7;
var ADVIT_ID_STKMODENO = 8;
var ADVIT_ID_OLD_JISYA_HBN_FROM = 9;
var ADVIT_ID_OLD_JISYA_HBN_TO = 10;
var ADVIT_ID_KAISYA_CD = 11;
var ADVIT_ID_BTNKAISHA_CD = 12;
var ADVIT_ID_KAISYA_NM = 13;
var ADVIT_ID_OLD_JISYA_HBN = 14;
var ADVIT_ID_OLD_JISYA_HBN2 = 15;
var ADVIT_ID_OLD_JISYA_HBN3 = 16;
var ADVIT_ID_OLD_JISYA_HBN4 = 17;
var ADVIT_ID_OLD_JISYA_HBN5 = 18;
var ADVIT_ID_KAISYA_CD2 = 19;
var ADVIT_ID_BTNKAISHA_CD2 = 20;
var ADVIT_ID_KAISYA_NM2 = 21;
var ADVIT_ID_SCAN_CD_FROM = 22;
var ADVIT_ID_SCAN_CD_TO = 23;
var ADVIT_ID_KAISYA_CD3 = 24;
var ADVIT_ID_BTNKAISHA_CD3 = 25;
var ADVIT_ID_KAISYA_NM3 = 26;
var ADVIT_ID_MAKER_HBN = 27;
var ADVIT_ID_BTNMAKER_HBN = 28;
var ADVIT_ID_KAISYA_CD4 = 29;
var ADVIT_ID_BTNKAISHA_CD4 = 30;
var ADVIT_ID_KAISYA_NM4 = 31;
var ADVIT_ID_SEARCHCNT = 32;
var ADVIT_ID_BTNSEARCH = 33;
var ADVIT_ID_ZAIKO_SERCHSTK = 34;
var ADVIT_ID_PGR = 35;
var ADVIT_ID_M1ROWNO = 36;
var ADVIT_ID_M1BUMON_CD = 37;
var ADVIT_ID_M1BUMONKANA_NM = 38;
var ADVIT_ID_M1HINSYU_RYAKU_NM = 39;
var ADVIT_ID_M1BURANDO_NM = 40;
var ADVIT_ID_M1JISYA_HBN = 41;
var ADVIT_ID_M1SYOHIN_ZOKUSEI = 42;
var ADVIT_ID_M1MAKER_HBN = 43;
var ADVIT_ID_M1SYONMK = 44;
var ADVIT_ID_M1IRO_NM = 45;
var ADVIT_ID_M1TENZAIKO_SU = 46;
var ADVIT_ID_M1ZENTENZAIKO_SU = 47;
var ADVIT_ID_M1SYOKA_RTU = 48;
var ADVIT_ID_M1SELECTORCHECKBOX = 49;
var ADVIT_ID_M1ENTERSYORIFLG = 50;
var ADVIT_ID_M1DTLIROKBN = 51;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Btnmodejishahinban","Btnmodejishahinban2"
	,"Btnmodescancd","Btnmodemakerhbn","Modeno","Stkmodeno","Old_jisya_hbn_from"
	,"Old_jisya_hbn_to","Kaisya_cd","Btnkaisha_cd","Kaisya_nm","Old_jisya_hbn"
	,"Old_jisya_hbn2","Old_jisya_hbn3","Old_jisya_hbn4","Old_jisya_hbn5","Kaisya_cd2"
	,"Btnkaisha_cd2","Kaisya_nm2","Scan_cd_from","Scan_cd_to","Kaisya_cd3"
	,"Btnkaisha_cd3","Kaisya_nm3","Maker_hbn","Btnmaker_hbn","Kaisya_cd4"
	,"Btnkaisha_cd4","Kaisya_nm4","Searchcnt","Btnsearch","Zaiko_serchstk"
	,"Pgr","M1rowno","M1bumon_cd","M1bumonkana_nm","M1hinsyu_ryaku_nm"
	,"M1burando_nm","M1jisya_hbn","M1syohin_zokusei","M1maker_hbn","M1syonmk"
	,"M1iro_nm","M1tenzaiko_su","M1zentenzaiko_su","M1syoka_rtu","M1selectorcheckbox"
	,"M1entersyoriflg","M1dtlirokbn"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","モード自社品番ボタン","モード自社品番２ボタン"
	,"モードスキャンコードボタン","モードメーカー品番ボタン","モードNO","選択モードNO","旧自社品番FROM"
	,"旧自社品番TO","会社コード","会社コードボタン","会社名称","旧自社品番"
	,"旧自社品番２","旧自社品番３","旧自社品番４","旧自社品番５","会社コード２"
	,"会社コード２ボタン","会社名称２","スキャンコードFROM","スキャンコードTO","会社コード３"
	,"会社コード３ボタン","会社名称３","メーカー品番","メーカー品番ボタン","会社コード４"
	,"会社コード４ボタン","会社名称４","検索件数","検索ボタン","在庫検索選択"
	,"ページャ","Ｍ１行NO","Ｍ１部門コード","Ｍ１部門カナ名","Ｍ１品種略名称"
	,"Ｍ１ブランド名","Ｍ１自社品番リンク","Ｍ１商品属性","Ｍ１メーカー品番","Ｍ１商品名(カナ)"
	,"Ｍ１色","Ｍ１店在庫数","Ｍ１全店在庫数","Ｍ１消化率","Ｍ１選択フラグ(隠し)"
	,"Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","B","B"
	,"B","B","NA","NA","SG"
	,"SG","SG","B","SN4","SG"
	,"SG","SG","SG","SG","SG"
	,"B","SN4","SG","SG","SG"
	,"B","SN4","SN21","B","SG"
	,"B","SN4","NA","B","NA"
	,"B","NA","SG","SN9","SN4"
	,"SN9","B","SN9","SN9","SN9"
	,"SN9","NC","NC","NC","NA"
	,"NA","NA"
);
var ADVIT_LENGTH = new Array(
	4,0,15,0,0
	,0,0,2,2,10
	,10,2,0,10,10
	,10,10,10,10,2
	,0,10,18,18,2
	,0,10,30,0,2
	,0,10,4,0,1
	,0,4,3,30,15
	,20,0,3,30,30
	,10,8,8,4,1
	,1,2
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
	,0,0,0,1,0
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
	,0,0
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","LNK","LNK"
	,"LNK","LNK","HDN","HDN","TXT"
	,"TXT","TXT","BTN","TXR","TXT"
	,"TXT","TXT","TXT","TXT","TXT"
	,"BTN","TXR","TXT","TXT","TXT"
	,"BTN","TXR","TXT","BTN","TXT"
	,"BTN","TXR","TXT","BTS","RDO"
	,"LNS","TXR","TXR","TXR","TXR"
	,"TXR","BTS","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","CHK"
	,"HDN","HDN"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","00","00"
	,"00","00","11","11","00"
	,"00","10","00","00","00"
	,"00","00","00","00","10"
	,"00","00","00","00","10"
	,"00","00","00","00","10"
	,"00","00","11","00","11"
	,"00","11","10","00","00"
	,"00","00","00","00","00"
	,"00","12","12","19","11"
	,"11","11"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"","","","",""
	,"","","C_MEISYO_CD","",""
	,"","","","",""
	,"C_MEISYO_CD","","","",""
	,"C_MEISYO_CD","","","C_MAKERHBN",""
	,"C_MEISYO_CD","","","",""
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
	,"","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1"
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,1,0
	,1,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0
);
var ADVIT_IMEMODE = new Array(
	3,0,0,0,0
	,0,0,0,0,3
	,3,3,0,0,3
	,3,3,3,3,3
	,0,0,3,3,3
	,0,0,2,0,3
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
	,0,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,0,0
	,0,0,0,0,1
	,1,1,0,0,1
	,1,1,1,1,1
	,0,0,1,1,1
	,0,0,1,0,1
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
	,"","","","","ZAIKO_SERCHSTK"
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"",""
);
var ADVIT_ACTIONID = new Array(
	"","COD","","SPT","SPT"
	,"SPT","SPT","","",""
	,"","","COD","",""
	,"","","","",""
	,"COD","","","",""
	,"COD","","","COD",""
	,"COD","","","FRM",""
	,"PGN","","","",""
	,"","FRM","","",""
	,"","","","",""
	,"",""
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","TH020F01","TH020F01"
	,"TH020F01","TH020F01","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","TH020F01",""
	,"","","","",""
	,"","TH020F03","","",""
	,"","","","",""
	,"",""
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"M1","","","",""
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
	,"",""
);
var ADVIT_CAPTION = new Array(
	"店舗","","","自社品番","自社品番（複数）"
	,"スキャンコード","メーカー品番","","","自社品番ＦＲＯＭ"
	,"自社品番ＴＯ","会社","","","自社品番1"
	,"自社品番2","自社品番3","自社品番4","自社品番5","会社"
	,"","","スキャンコードＦＲＯＭ","スキャンコードＴＯ","会社"
	,"","","メーカー品番","","会社"
	,"","","","検索",""
	,"","No.","部門","","品種"
	,"ブランド","自社品番","コア","メーカー品番","商品名"
	,"色","自店在庫数","全店在庫数","消化率",""
	,"",""
);

