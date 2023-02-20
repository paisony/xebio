var ADVIT_FORMID = "TJ030F01";
var ADVIT_TARGETPGID = "tj030p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tj030f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,37,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,48,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_BTNMODEREF = 3;
var ADVIT_ID_BTNMODEDEL = 4;
var ADVIT_ID_MODENO = 5;
var ADVIT_ID_STKMODENO = 6;
var ADVIT_ID_FACE_NO_FROM = 7;
var ADVIT_ID_FACE_NO_TO = 8;
var ADVIT_ID_TANA_DAN_FROM = 9;
var ADVIT_ID_TANA_DAN_TO = 10;
var ADVIT_ID_TENPO_GYOSYA_KB = 11;
var ADVIT_ID_NYURYOKU_YMD_FROM = 12;
var ADVIT_ID_NYURYOKU_YMD_TO = 13;
var ADVIT_ID_SOSIN_YMD_FROM = 14;
var ADVIT_ID_SOSIN_YMD_TO = 15;
var ADVIT_ID_NYURYOKUTAN_CD = 16;
var ADVIT_ID_BTNTANTO_CD = 17;
var ADVIT_ID_NYURYOKUTAN_NM = 18;
var ADVIT_ID_OLD_JISYA_HBN = 19;
var ADVIT_ID_OLD_JISYA_HBN2 = 20;
var ADVIT_ID_OLD_JISYA_HBN3 = 21;
var ADVIT_ID_OLD_JISYA_HBN4 = 22;
var ADVIT_ID_OLD_JISYA_HBN5 = 23;
var ADVIT_ID_SOSIN_JYOTAI = 24;
var ADVIT_ID_SCAN_CD = 25;
var ADVIT_ID_SCAN_CD2 = 26;
var ADVIT_ID_SCAN_CD3 = 27;
var ADVIT_ID_SCAN_CD4 = 28;
var ADVIT_ID_SCAN_CD5 = 29;
var ADVIT_ID_SEARCHCNT = 30;
var ADVIT_ID_BTNSEARCH = 31;
var ADVIT_ID_BTNZENSTK = 32;
var ADVIT_ID_BTNZENKJO = 33;
var ADVIT_ID_BTNPRINT = 34;
var ADVIT_ID_BTNCSV = 35;
var ADVIT_ID_PGR = 36;
var ADVIT_ID_M1ROWNO = 37;
var ADVIT_ID_M1FACE_NO = 38;
var ADVIT_ID_M1TANA_DAN = 39;
var ADVIT_ID_M1KAI_SU = 40;
var ADVIT_ID_M1SCAN_SU = 41;
var ADVIT_ID_M1NYURYOKUTAN_NM = 42;
var ADVIT_ID_M1NYURYOKU_YMD = 43;
var ADVIT_ID_M1SOSIN_YMD = 44;
var ADVIT_ID_M1GYOSYA = 45;
var ADVIT_ID_M1SELECTORCHECKBOX = 46;
var ADVIT_ID_M1ENTERSYORIFLG = 47;
var ADVIT_ID_M1DTLIROKBN = 48;
var ADVIT_ID_BTNENTER = 49;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Btnmoderef","Btnmodedel"
	,"Modeno","Stkmodeno","Face_no_from","Face_no_to","Tana_dan_from"
	,"Tana_dan_to","Tenpo_gyosya_kb","Nyuryoku_ymd_from","Nyuryoku_ymd_to","Sosin_ymd_from"
	,"Sosin_ymd_to","Nyuryokutan_cd","Btntanto_cd","Nyuryokutan_nm","Old_jisya_hbn"
	,"Old_jisya_hbn2","Old_jisya_hbn3","Old_jisya_hbn4","Old_jisya_hbn5","Sosin_jyotai"
	,"Scan_cd","Scan_cd2","Scan_cd3","Scan_cd4","Scan_cd5"
	,"Searchcnt","Btnsearch","Btnzenstk","Btnzenkjo","Btnprint"
	,"Btncsv","Pgr","M1rowno","M1face_no","M1tana_dan"
	,"M1kai_su","M1scan_su","M1nyuryokutan_nm","M1nyuryoku_ymd","M1sosin_ymd"
	,"M1gyosya","M1selectorcheckbox","M1entersyoriflg","M1dtlirokbn","Btnenter"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","モード照会ボタン","モード取消ボタン"
	,"モードNO","選択モードNO","フェイスNoFROM","フェイスNoTO","棚段FROM"
	,"棚段TO","店舗／業者区分","入力日FROM","入力日TO","送信日FROM"
	,"送信日TO","入力担当者コード","担当者コードボタン","入力担当者名称","旧自社品番"
	,"旧自社品番２","旧自社品番３","旧自社品番４","旧自社品番５","送信状態"
	,"スキャンコード","スキャンコード２","スキャンコード３","スキャンコード４","スキャンコード５"
	,"検索件数","検索ボタン","全選択ボタン","全解除ボタン","印刷ボタン"
	,"CSVボタン","ページャ","Ｍ１行NO","Ｍ１フェイスNoリンク","Ｍ１棚段"
	,"Ｍ１回数","Ｍ１スキャン数量","Ｍ１入力担当者名称","Ｍ１入力日","Ｍ１送信日"
	,"Ｍ１業者","Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)","確定ボタン"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","B","B"
	,"NA","NA","NA","NA","NA"
	,"NA","SN5","D","D","D"
	,"D","SG","B","SN4","SG"
	,"SG","SG","SG","SG","NA"
	,"SG","SG","SG","SG","SG"
	,"NA","B","B","B","B"
	,"B","B","NA","B","NA"
	,"NA","NA","SN4","D","D"
	,"SN4","NA","NA","NA","B"
);
var ADVIT_LENGTH = new Array(
	4,0,15,0,0
	,2,2,5,5,2
	,2,1,0,0,0
	,0,7,0,12,10
	,10,10,10,10,1
	,18,18,18,18,18
	,4,0,0,0,0
	,0,0,4,0,2
	,2,6,12,0,0
	,1,1,1,2,0
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
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","LNK","LNK"
	,"HDN","HDN","TXT","TXT","TXT"
	,"TXT","DRL","TXT","TXT","TXT"
	,"TXT","TXT","BTN","TXR","TXT"
	,"TXT","TXT","TXT","TXT","DRL"
	,"TXT","TXT","TXT","TXT","TXT"
	,"TXT","BTS","BTS","BTS","BTS"
	,"BTS","LNS","TXR","BTS","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","CHK","HDN","HDN","BTS"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","00","00"
	,"11","11","10","10","11"
	,"11","00","52","52","52"
	,"52","10","00","00","00"
	,"00","00","00","00","00"
	,"00","00","00","00","00"
	,"11","00","00","00","00"
	,"00","00","11","00","11"
	,"11","12","00","52","52"
	,"00","11","11","11","00"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"","","","",""
	,"","","","",""
	,"","","C_TANTO_CD","",""
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
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1",""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,1,0,0,1
	,1,1,0,0,0
	,0,0,0,0,0
	,0,0,0,0,1
);
var ADVIT_IMEMODE = new Array(
	3,0,0,0,0
	,0,0,3,3,3
	,3,0,3,3,3
	,3,3,0,0,3
	,3,3,3,3,0
	,3,3,3,3,3
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
	,0,0,0,0,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,0,0
	,0,0,1,1,1
	,1,0,1,1,1
	,1,1,0,0,1
	,1,1,1,1,0
	,1,1,1,1,1
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
);
var ADVIT_CONDID = new Array(
	"","","","",""
	,"","","","",""
	,"","TENPO_GYOSYA_KBN","","",""
	,"","","","",""
	,"","","","","SOSIN_JOTAI"
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
);
var ADVIT_ACTIONID = new Array(
	"","COD","","SPT","SPT"
	,"","","","",""
	,"","","","",""
	,"","","COD","",""
	,"","","","",""
	,"","","","",""
	,"","FRM","FRM","FRM","FRM"
	,"FRM","PGN","","FRM",""
	,"","","","",""
	,"","","","","FRM"
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","TJ030F01","TJ030F01"
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","TJ030F01","TJ030F01","TJ030F01","TJ030F01"
	,"TJ030F01","","","TJ030F02",""
	,"","","","",""
	,"","","","","TJ030F01"
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","M1","M1",""
	,"","M1","","",""
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
	,"","","","",""
);
var ADVIT_CAPTION = new Array(
	"店舗","","","照会","取消"
	,"","","フェイスNoＦＲＯＭ","フェイスNoＴＯ","棚段ＦＲＯＭ"
	,"棚段ＴＯ","店舗／業者","入力日ＦＲＯＭ","入力日ＴＯ","送信日ＦＲＯＭ"
	,"送信日ＴＯ","入力担当者","","","自社品番1"
	,"自社品番2","自社品番3","自社品番4","自社品番5","送信状態"
	,"ｽｷｬﾝｺｰﾄﾞ1","ｽｷｬﾝｺｰﾄﾞ2","ｽｷｬﾝｺｰﾄﾞ3","ｽｷｬﾝｺｰﾄﾞ4","ｽｷｬﾝｺｰﾄﾞ5"
	,"","検索","","",""
	,"","","No.","ﾌｪｲｽNo","棚段"
	,"回数","ｽｷｬﾝ数量","入力担当者","入力日","送信日"
	,"業者","","","","確定"
);

