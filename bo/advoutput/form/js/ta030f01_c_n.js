var ADVIT_FORMID = "TA030F01";
var ADVIT_TARGETPGID = "ta030p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "ta030f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,25,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,33,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_BTNMODEREF_BUMON = 3;
var ADVIT_ID_BTNMODEREF_TANPIN = 4;
var ADVIT_ID_MODENO = 5;
var ADVIT_ID_STKMODENO = 6;
var ADVIT_ID_KBN_CD = 7;
var ADVIT_ID_SHINSEI_FLG = 8;
var ADVIT_ID_SIIRESAKI_CD = 9;
var ADVIT_ID_BTNSIIRESAKI_CD = 10;
var ADVIT_ID_SIIRESAKI_RYAKU_NM = 11;
var ADVIT_ID_BUMON_CD = 12;
var ADVIT_ID_BTNBUMON_CD = 13;
var ADVIT_ID_BUMON_NM = 14;
var ADVIT_ID_BURANDO_CD = 15;
var ADVIT_ID_BTNBURANDO_CD = 16;
var ADVIT_ID_BURANDO_NM = 17;
var ADVIT_ID_HATTYU_YMD_FROM = 18;
var ADVIT_ID_HATTYU_YMD_TO = 19;
var ADVIT_ID_OLD_JISYA_HBN = 20;
var ADVIT_ID_MAKER_HBN = 21;
var ADVIT_ID_SCAN_CD = 22;
var ADVIT_ID_BTNSEARCH = 23;
var ADVIT_ID_PGR = 24;
var ADVIT_ID_M1ROWNO = 25;
var ADVIT_ID_M1HOJUIRAI_KBN_NM = 26;
var ADVIT_ID_M1SINSEI_JOTAINM = 27;
var ADVIT_ID_M1BUMON_CD_BO = 28;
var ADVIT_ID_M1ITEMSU = 29;
var ADVIT_ID_M1KINGAKU = 30;
var ADVIT_ID_M1SELECTORCHECKBOX = 31;
var ADVIT_ID_M1ENTERSYORIFLG = 32;
var ADVIT_ID_M1DTLIROKBN = 33;
var ADVIT_ID_GOKEI_ITEMSU = 34;
var ADVIT_ID_GOKEI_KINGAKU = 35;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Btnmoderef_bumon","Btnmoderef_tanpin"
	,"Modeno","Stkmodeno","Kbn_cd","Shinsei_flg","Siiresaki_cd"
	,"Btnsiiresaki_cd","Siiresaki_ryaku_nm","Bumon_cd","Btnbumon_cd","Bumon_nm"
	,"Burando_cd","Btnburando_cd","Burando_nm","Hattyu_ymd_from","Hattyu_ymd_to"
	,"Old_jisya_hbn","Maker_hbn","Scan_cd","Btnsearch","Pgr"
	,"M1rowno","M1hojuirai_kbn_nm","M1sinsei_jotainm","M1bumon_cd_bo","M1itemsu"
	,"M1kingaku","M1selectorcheckbox","M1entersyoriflg","M1dtlirokbn","Gokei_itemsu"
	,"Gokei_kingaku"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","モード照会部門別ボタン","モード照会単品別ボタン"
	,"モードNO","選択モードNO","区分コード","申請状態","仕入先コード"
	,"仕入先コードボタン","仕入先略式名称","部門コード","部門コードボタン","部門名"
	,"ブランドコード","ブランドコードボタン","ブランド名","発注日FROM","発注日TO"
	,"旧自社品番","メーカー品番","スキャンコード","検索ボタン","ページャ"
	,"Ｍ１行NO","Ｍ１補充依頼区分名称","Ｍ１申請状態名称","Ｍ１部門リンク","Ｍ１数量"
	,"Ｍ１金額","Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)","合計数量"
	,"合計金額"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","B","B"
	,"NA","NA","SN5","SN5","SG"
	,"B","SN4","SG","B","SN4"
	,"SG","B","SN9","D","D"
	,"SG","SN9","SG","B","B"
	,"NA","SN4","SN4","B","NC"
	,"NC","NA","NA","NA","NC"
	,"NC"
);
var ADVIT_LENGTH = new Array(
	4,0,15,0,0
	,2,2,1,1,4
	,0,20,3,0,15
	,6,0,20,0,0
	,10,30,18,0,0
	,3,7,3,0,9
	,9,1,1,2,9
	,9
);
var ADVIT_AUTOTAB = new Array(
	0,0,0,0,0
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
	,0
);
var ADVIT_REQUIREDFLG = new Array(
	1,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","LNK","LNK"
	,"HDN","HDN","DRL","DRL","TXT"
	,"BTN","TXR","TXT","BTN","TXR"
	,"TXT","BTN","TXR","TXT","TXT"
	,"TXT","TXR","TXT","BTS","LNS"
	,"TXR","TXR","TXR","BTS","TXR"
	,"TXR","CHK","HDN","HDN","TXR"
	,"TXR"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","00","00"
	,"11","11","00","00","10"
	,"00","00","10","00","00"
	,"10","00","00","52","52"
	,"00","00","00","00","00"
	,"11","00","00","00","12"
	,"12","11","11","11","12"
	,"12"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"","","","",""
	,"C_SIIRESAKI_CD","","","C_BUMON_CD",""
	,"","C_BURANDO_CD","","",""
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
	,"CANNOTGET"
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1",""
	,""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,1,1
	,0,0,0,0,0
	,0,0,0,0,0
	,0
);
var ADVIT_IMEMODE = new Array(
	3,0,0,0,0
	,0,0,0,0,3
	,0,0,3,0,0
	,3,0,0,3,3
	,3,0,3,0,0
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
	,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,0,0
	,0,0,0,0,1
	,0,0,1,0,0
	,1,0,0,1,1
	,1,0,1,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0
);
var ADVIT_CONDID = new Array(
	"","","","",""
	,"","","HOJUIRAI_KBN2","SINSEI_JOTAI",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,""
);
var ADVIT_ACTIONID = new Array(
	"","COD","","SPT","SPT"
	,"","","","",""
	,"COD","","","COD",""
	,"","COD","","",""
	,"","","","FRM","PGN"
	,"","","","FRM",""
	,"","","","",""
	,""
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","TA030F01","TA030F01"
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","TA030F01",""
	,"","","","TA030F02",""
	,"","","","",""
	,""
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","","M1"
	,"","","","M1",""
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
	,""
);
var ADVIT_CAPTION = new Array(
	"店舗","","","照会（部門別）","照会（単品別）"
	,"モードNO","選択モードNO","区分","状態","仕入先"
	,"","","部門","",""
	,"ブランド","","","発注日ＦＲＯＭ","発注日ＴＯ"
	,"自社品番","","ｽｷｬﾝｺｰﾄﾞ","検索",""
	,"No.","区分","状態","部門","数量"
	,"金額","選択フラグ(隠し)","確定処理フラグ(隠し)","明細色区分(隠し)","合計"
	,""
);

