var ADVIT_FORMID = "TJ040F01";
var ADVIT_TARGETPGID = "tj040p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tj040f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,39,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,57,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_BTNMODEREF = 3;
var ADVIT_ID_BTNMODEUPD = 4;
var ADVIT_ID_BTNMODEDEL = 5;
var ADVIT_ID_MODENO = 6;
var ADVIT_ID_STKMODENO = 7;
var ADVIT_ID_FACE_NO_FROM = 8;
var ADVIT_ID_FACE_NO_TO = 9;
var ADVIT_ID_TANA_DAN_FROM = 10;
var ADVIT_ID_TANA_DAN_TO = 11;
var ADVIT_ID_TENPO_GYOSYA_KB = 12;
var ADVIT_ID_NYURYOKU_YMD_FROM = 13;
var ADVIT_ID_NYURYOKU_YMD_TO = 14;
var ADVIT_ID_SOSIN_YMD_FROM = 15;
var ADVIT_ID_SOSIN_YMD_TO = 16;
var ADVIT_ID_NYURYOKUTAN_CD = 17;
var ADVIT_ID_BTNTANTO_CD = 18;
var ADVIT_ID_NYURYOKUTAN_NM = 19;
var ADVIT_ID_OLD_JISYA_HBN = 20;
var ADVIT_ID_OLD_JISYA_HBN2 = 21;
var ADVIT_ID_OLD_JISYA_HBN3 = 22;
var ADVIT_ID_OLD_JISYA_HBN4 = 23;
var ADVIT_ID_OLD_JISYA_HBN5 = 24;
var ADVIT_ID_SOSIN_JYOTAI = 25;
var ADVIT_ID_TEISEI_FLG = 26;
var ADVIT_ID_SCAN_CD = 27;
var ADVIT_ID_SCAN_CD2 = 28;
var ADVIT_ID_SCAN_CD3 = 29;
var ADVIT_ID_SCAN_CD4 = 30;
var ADVIT_ID_SCAN_CD5 = 31;
var ADVIT_ID_SEARCHCNT = 32;
var ADVIT_ID_BTNSEARCH = 33;
var ADVIT_ID_BTNZENSTK = 34;
var ADVIT_ID_BTNZENKJO = 35;
var ADVIT_ID_BTNPRINT = 36;
var ADVIT_ID_BTNCSV = 37;
var ADVIT_ID_PGR = 38;
var ADVIT_ID_M1ROWNO = 39;
var ADVIT_ID_M1FACE_NO = 40;
var ADVIT_ID_M1TANA_DAN = 41;
var ADVIT_ID_M1KAI_SU = 42;
var ADVIT_ID_M1TENSUTANAOROSINYURYOKU_SU = 43;
var ADVIT_ID_M1TENSUTANAOROSITEISEI_SU = 44;
var ADVIT_ID_M1TENSUTANAOROSIGOKEI_SU = 45;
var ADVIT_ID_M1SCAN_SU = 46;
var ADVIT_ID_M1TEISEI_SURYO = 47;
var ADVIT_ID_M1GOKEI_SURYO = 48;
var ADVIT_ID_M1NYURYOKUTAN_NM = 49;
var ADVIT_ID_M1TEISEITAN_NM = 50;
var ADVIT_ID_M1RIYUCOMMENT_NM = 51;
var ADVIT_ID_M1NYURYOKU_YMD = 52;
var ADVIT_ID_M1SOSIN_YMD = 53;
var ADVIT_ID_M1GYOSYA = 54;
var ADVIT_ID_M1SELECTORCHECKBOX = 55;
var ADVIT_ID_M1ENTERSYORIFLG = 56;
var ADVIT_ID_M1DTLIROKBN = 57;
var ADVIT_ID_BTNENTER = 58;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Btnmoderef","Btnmodeupd"
	,"Btnmodedel","Modeno","Stkmodeno","Face_no_from","Face_no_to"
	,"Tana_dan_from","Tana_dan_to","Tenpo_gyosya_kb","Nyuryoku_ymd_from","Nyuryoku_ymd_to"
	,"Sosin_ymd_from","Sosin_ymd_to","Nyuryokutan_cd","Btntanto_cd","Nyuryokutan_nm"
	,"Old_jisya_hbn","Old_jisya_hbn2","Old_jisya_hbn3","Old_jisya_hbn4","Old_jisya_hbn5"
	,"Sosin_jyotai","Teisei_flg","Scan_cd","Scan_cd2","Scan_cd3"
	,"Scan_cd4","Scan_cd5","Searchcnt","Btnsearch","Btnzenstk"
	,"Btnzenkjo","Btnprint","Btncsv","Pgr","M1rowno"
	,"M1face_no","M1tana_dan","M1kai_su","M1tensutanaorosinyuryoku_su","M1tensutanaorositeisei_su"
	,"M1tensutanaorosigokei_su","M1scan_su","M1teisei_suryo","M1gokei_suryo","M1nyuryokutan_nm"
	,"M1teiseitan_nm","M1riyucomment_nm","M1nyuryoku_ymd","M1sosin_ymd","M1gyosya"
	,"M1selectorcheckbox","M1entersyoriflg","M1dtlirokbn","Btnenter"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","モード照会ボタン","モード修正ボタン"
	,"モード取消ボタン","モードNO","選択モードNO","フェイスＮｏFROM","フェイスＮｏTO"
	,"棚段FROM","棚段TO","店舗／業者区分","入力日FROM","入力日TO"
	,"送信日FROM","送信日TO","入力担当者コード","担当者コードボタン","入力担当者名称"
	,"旧自社品番","旧自社品番２","旧自社品番３","旧自社品番４","旧自社品番５"
	,"送信状態","訂正フラグ","スキャンコード","スキャンコード２","スキャンコード３"
	,"スキャンコード４","スキャンコード５","検索件数","検索ボタン","全選択ボタン"
	,"全解除ボタン","印刷ボタン","CSVボタン","ページャ","Ｍ１行NO"
	,"Ｍ１フェイスＮｏリンク","Ｍ１棚段","Ｍ１回数","Ｍ１点数棚卸入力数","Ｍ１点数棚卸訂正数"
	,"Ｍ１点数棚卸合計数","Ｍ１スキャン数量","Ｍ１訂正数量","Ｍ１合計数量","Ｍ１入力担当者名称"
	,"Ｍ１訂正担当者名称","Ｍ１理由コメント情報","Ｍ１入力日","Ｍ１送信日","Ｍ１業者"
	,"Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)","確定ボタン"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","B","B"
	,"B","NA","NA","NA","NA"
	,"NA","NA","SN5","D","D"
	,"D","D","SG","B","SN4"
	,"SG","SG","SG","SG","SG"
	,"SN5","NA","SG","SG","SG"
	,"SG","SG","NA","B","B"
	,"B","B","B","B","NA"
	,"B","NA","NA","NA","NA"
	,"NA","NA","NA","NA","SN4"
	,"SN4","SN4","D","D","SN4"
	,"NA","NA","NA","B"
);
var ADVIT_LENGTH = new Array(
	4,0,15,0,0
	,0,2,2,5,5
	,2,2,1,0,0
	,0,0,7,0,12
	,10,10,10,10,10
	,1,1,18,18,18
	,18,18,4,0,0
	,0,0,0,0,4
	,0,2,2,6,6
	,6,6,6,6,12
	,12,100,0,0,1
	,1,1,2,0
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
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0
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
	,0,0,0,0,0
	,0,0,0,0
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","LNK","LNK"
	,"LNK","HDN","HDN","TXT","TXT"
	,"TXT","TXT","DRL","TXT","TXT"
	,"TXT","TXT","TXT","BTN","TXR"
	,"TXT","TXT","TXT","TXT","TXT"
	,"DRL","CHK","TXT","TXT","TXT"
	,"TXT","TXT","TXR","BTS","BTS"
	,"BTS","BTS","BTS","LNS","TXR"
	,"BTS","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"CHK","HDN","HDN","BTS"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","00","00"
	,"00","11","11","10","10"
	,"11","11","00","52","52"
	,"52","52","10","00","00"
	,"00","00","00","00","00"
	,"00","11","00","00","00"
	,"00","00","12","00","00"
	,"00","00","00","00","11"
	,"00","11","11","12","12"
	,"12","12","12","12","00"
	,"00","00","52","52","00"
	,"11","11","11","00"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"","","","",""
	,"","","","",""
	,"","","","C_TANTO_CD",""
	,"","","","",""
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
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1",""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,1,0
	,0,1,1,1,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,1
);
var ADVIT_IMEMODE = new Array(
	3,0,0,0,0
	,0,0,0,3,3
	,3,3,0,3,3
	,3,3,3,0,0
	,3,3,3,3,3
	,0,0,3,3,3
	,3,3,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
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
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,0,0
	,0,0,0,1,1
	,1,1,0,1,1
	,1,1,1,0,0
	,1,1,1,1,1
	,0,0,1,1,1
	,1,1,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0
);
var ADVIT_CONDID = new Array(
	"","","","",""
	,"","","","",""
	,"","","TENPO_GYOSYA_KBN","",""
	,"","","","",""
	,"","","","",""
	,"SOSIN_JOTAI","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","",""
);
var ADVIT_ACTIONID = new Array(
	"","COD","","SPT","SPT"
	,"SPT","","","",""
	,"","","","",""
	,"","","","COD",""
	,"","","","",""
	,"","","","",""
	,"","","","FRM","FRM"
	,"FRM","FRM","FRM","PGN",""
	,"FRM","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","FRM"
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","TJ040F01","TJ040F01"
	,"TJ040F01","TJ040F01","TJ040F01","",""
	,"TJ040F02","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","TJ040F01"
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","","M1"
	,"M1","","","M1",""
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
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","",""
);
var ADVIT_CAPTION = new Array(
	"店舗","","","照会","修正"
	,"取消","","","フェイスNoＦＲＯＭ","フェイスNoＴＯ"
	,"棚段ＦＲＯＭ","棚段ＴＯ","店舗／業者","入力日ＦＲＯＭ","入力日ＴＯ"
	,"送信日ＦＲＯＭ","送信日ＴＯ","入力担当者","",""
	,"自社品番1","自社品番2","自社品番3","自社品番4","自社品番5"
	,"送信状態","","ｽｷｬﾝｺｰﾄﾞ1","ｽｷｬﾝｺｰﾄﾞ2","ｽｷｬﾝｺｰﾄﾞ3"
	,"ｽｷｬﾝｺｰﾄﾞ4","ｽｷｬﾝｺｰﾄﾞ5","","検索",""
	,"","","","","No."
	,"ﾌｪｲｽNo","棚段","回数","入力数量","訂正数量"
	,"合計数量","ｽｷｬﾝ数量","訂正数量","合計数量","入力担当者"
	,"訂正担当者","棚卸理由","入力日","送信日","業者"
	,"","","","確定"
);

