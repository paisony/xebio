var ADVIT_FORMID = "TG040F01";
var ADVIT_TARGETPGID = "tg040p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tg040f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,23,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,31,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_BTNMODEUPD = 3;
var ADVIT_ID_BTNMODEDEL = 4;
var ADVIT_ID_BTNMODEREF = 5;
var ADVIT_ID_YMD_FROM = 6;
var ADVIT_ID_YMD_TO = 7;
var ADVIT_ID_STOCK_NO = 8;
var ADVIT_ID_TAN_CD = 9;
var ADVIT_ID_BTNTANTO_CD = 10;
var ADVIT_ID_HANBAIIN_NM = 11;
var ADVIT_ID_OLD_JISYA_HBN = 12;
var ADVIT_ID_MAKER_HBN = 13;
var ADVIT_ID_SCAN_CD = 14;
var ADVIT_ID_HANBAIKANRYO_YMD_FROM = 15;
var ADVIT_ID_HANBAIKANRYO_YMD_TO = 16;
var ADVIT_ID_BTNINSERT = 17;
var ADVIT_ID_SEARCHCNT = 18;
var ADVIT_ID_BTNSEARCH = 19;
var ADVIT_ID_BTNPRINT = 20;
var ADVIT_ID_BTNCSV = 21;
var ADVIT_ID_PGR = 22;
var ADVIT_ID_M1ROWNO = 23;
var ADVIT_ID_M1YMD = 24;
var ADVIT_ID_M1TM = 25;
var ADVIT_ID_M1HANBAIIN_NM = 26;
var ADVIT_ID_M1STOCK_NO = 27;
var ADVIT_ID_M1SURYO = 28;
var ADVIT_ID_M1SELECTORCHECKBOX = 29;
var ADVIT_ID_M1ENTERSYORIFLG = 30;
var ADVIT_ID_M1DTLIROKBN = 31;
var ADVIT_ID_BTNENTER = 32;
var ADVIT_ID_MODENO = 33;
var ADVIT_ID_STKMODENO = 34;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Btnmodeupd","Btnmodedel"
	,"Btnmoderef","Ymd_from","Ymd_to","Stock_no","Tan_cd"
	,"Btntanto_cd","Hanbaiin_nm","Old_jisya_hbn","Maker_hbn","Scan_cd"
	,"Hanbaikanryo_ymd_from","Hanbaikanryo_ymd_to","Btninsert","Searchcnt","Btnsearch"
	,"Btnprint","Btncsv","Pgr","M1rowno","M1ymd"
	,"M1tm","M1hanbaiin_nm","M1stock_no","M1suryo","M1selectorcheckbox"
	,"M1entersyoriflg","M1dtlirokbn","Btnenter","Modeno","Stkmodeno"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","モード修正ボタン","モード取消ボタン"
	,"モード照会ボタン","日付ＦＲＯＭ","日付ＴＯ","ストック№","担当者コード"
	,"担当者コードボタン","担当者名","旧自社品番","メーカー品番","スキャンコード"
	,"販売完了日FROM","販売完了日TO","新規作成ボタン","検索件数","検索ボタン"
	,"印刷ボタン","CSVボタン","ページャ","Ｍ１行NO","Ｍ１日付リンク"
	,"Ｍ１時間","Ｍ１担当者名","Ｍ１ストック№","Ｍ１数量","Ｍ１選択フラグ(隠し)"
	,"Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)","確定ボタン","モードNO","選択モードNO"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","B","B"
	,"B","D","D","NA","SG"
	,"B","SN4","SG","SN9","SG"
	,"D","D","B","NA","B"
	,"B","B","B","NA","B"
	,"D","SN4","NA","NA","NA"
	,"NA","NA","B","NA","NA"
);
var ADVIT_LENGTH = new Array(
	4,0,15,0,0
	,0,0,0,10,7
	,0,12,10,30,18
	,0,0,0,4,0
	,0,0,0,3,0
	,0,12,10,6,1
	,1,2,0,2,2
);
var ADVIT_AUTOTAB = new Array(
	0,0,0,0,0
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
);
var ADVIT_REQUIRED = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
);
var ADVIT_REQUIREDFLG = new Array(
	1,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","LNK","LNK"
	,"LNK","TXT","TXT","TXT","TXT"
	,"BTN","TXR","TXT","TXR","TXT"
	,"TXT","TXT","BTS","TXT","BTS"
	,"BTS","BTS","LNS","TXR","BTS"
	,"TXR","TXR","TXR","TXR","CHK"
	,"HDN","HDN","BTS","HDN","HDN"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","00","00"
	,"00","52","52","10","10"
	,"00","00","00","00","00"
	,"52","52","00","11","00"
	,"00","00","00","11","00"
	,"56","00","10","12","11"
	,"11","11","00","11","11"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"","","","",""
	,"C_TANTO_CD","","","",""
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
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","","",""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,1,0,1
	,1,1,1,0,0
	,0,0,0,0,0
	,0,0,1,0,0
);
var ADVIT_IMEMODE = new Array(
	3,0,0,0,0
	,0,3,3,3,3
	,0,0,3,0,3
	,3,3,0,0,0
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
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,0,0
	,0,1,1,1,1
	,0,0,1,0,1
	,1,1,0,0,0
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
);
var ADVIT_ACTIONID = new Array(
	"","COD","","SPT","SPT"
	,"SPT","","","",""
	,"COD","","","",""
	,"","","FRM","","FRM"
	,"FRM","FRM","PGN","","FRM"
	,"","","","",""
	,"","","FRM","",""
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","TG040F01","TG040F01"
	,"TG040F01","","","",""
	,"","","","",""
	,"","","TG040F02","","TG040F01"
	,"TG040F01","TG040F01","","","TG040F02"
	,"","","","",""
	,"","","TG040F01","",""
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","M1","","M1"
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
);
var ADVIT_CAPTION = new Array(
	"店舗","","","修正","取消"
	,"照会","日付ＦＲＯＭ","日付ＴＯ","ストックNo","担当者"
	,"","","自社品番","","ｽｷｬﾝｺｰﾄﾞ"
	,"販売完了日ＦＲＯＭ","販売完了日ＴＯ","新規作成","","検索"
	,"","","","No.","日付"
	,"時間","担当者","ストックNo","数量",""
	,"","","確定","",""
);

