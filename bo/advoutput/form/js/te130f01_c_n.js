var ADVIT_FORMID = "TE130F01";
var ADVIT_TARGETPGID = "te130p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "te130f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,33,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,53,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_DENPYO_JYOTAI = 3;
var ADVIT_ID_DENPYO_BANGO_FROM = 4;
var ADVIT_ID_DENPYO_BANGO_TO = 5;
var ADVIT_ID_IDODENPYO_BANGO_FROM = 6;
var ADVIT_ID_IDODENPYO_BANGO_TO = 7;
var ADVIT_ID_SIJI_BANGO_FROM = 8;
var ADVIT_ID_SIJI_BANGO_TO = 9;
var ADVIT_ID_JYURYOKAISYA_CD = 10;
var ADVIT_ID_NYUKAKAISYA_NM = 11;
var ADVIT_ID_JYURYOTEN_CD = 12;
var ADVIT_ID_BTNTENPOCD = 13;
var ADVIT_ID_JURYOTEN_NM = 14;
var ADVIT_ID_JYURYO_YMD_FROM = 15;
var ADVIT_ID_JYURYO_YMD_TO = 16;
var ADVIT_ID_SYUKKAKAISYA_CD = 17;
var ADVIT_ID_BTNKAISHA_CD = 18;
var ADVIT_ID_SYUKKAKAISYA_NM = 19;
var ADVIT_ID_SYUKKATEN_CD = 20;
var ADVIT_ID_BTNSYUKKATENCD = 21;
var ADVIT_ID_SYUKKATENPO_NM = 22;
var ADVIT_ID_SYUKKA_YMD_FROM = 23;
var ADVIT_ID_SYUKKA_YMD_TO = 24;
var ADVIT_ID_OLD_JISYA_HBN = 25;
var ADVIT_ID_MAKER_HBN = 26;
var ADVIT_ID_SCAN_CD = 27;
var ADVIT_ID_SEARCHCNT = 28;
var ADVIT_ID_BTNSEARCH = 29;
var ADVIT_ID_BTNPRINT = 30;
var ADVIT_ID_BTNCSV = 31;
var ADVIT_ID_PGR = 32;
var ADVIT_ID_M1ROWNO = 33;
var ADVIT_ID_M1SYUKKAKAISYA_CD = 34;
var ADVIT_ID_M1SYUKKATEN_CD = 35;
var ADVIT_ID_M1SYUKKATENPO_NM = 36;
var ADVIT_ID_M1JYURYOKAISYA_CD = 37;
var ADVIT_ID_M1JYURYOTEN_CD = 38;
var ADVIT_ID_M1JURYOTEN_NM = 39;
var ADVIT_ID_M1DENPYO_BANGO = 40;
var ADVIT_ID_M1IDODENPYO_BANGO = 41;
var ADVIT_ID_M1SIJI_BANGO = 42;
var ADVIT_ID_M1SYUKKA_YMD = 43;
var ADVIT_ID_M1JYURYO_YMD = 44;
var ADVIT_ID_M1NYUKAYOTEI_SU = 45;
var ADVIT_ID_M1NYUKAJISSEKI_SU = 46;
var ADVIT_ID_M1KYAKUCYU = 47;
var ADVIT_ID_M1SYORINM = 48;
var ADVIT_ID_M1SYORI_YMD = 49;
var ADVIT_ID_M1SYORI_TM = 50;
var ADVIT_ID_M1SELECTORCHECKBOX = 51;
var ADVIT_ID_M1ENTERSYORIFLG = 52;
var ADVIT_ID_M1DTLIROKBN = 53;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Denpyo_jyotai","Denpyo_bango_from"
	,"Denpyo_bango_to","Idodenpyo_bango_from","Idodenpyo_bango_to","Siji_bango_from","Siji_bango_to"
	,"Jyuryokaisya_cd","Nyukakaisya_nm","Jyuryoten_cd","Btntenpocd","Juryoten_nm"
	,"Jyuryo_ymd_from","Jyuryo_ymd_to","Syukkakaisya_cd","Btnkaisha_cd","Syukkakaisya_nm"
	,"Syukkaten_cd","Btnsyukkatencd","Syukkatenpo_nm","Syukka_ymd_from","Syukka_ymd_to"
	,"Old_jisya_hbn","Maker_hbn","Scan_cd","Searchcnt","Btnsearch"
	,"Btnprint","Btncsv","Pgr","M1rowno","M1syukkakaisya_cd"
	,"M1syukkaten_cd","M1syukkatenpo_nm","M1jyuryokaisya_cd","M1jyuryoten_cd","M1juryoten_nm"
	,"M1denpyo_bango","M1idodenpyo_bango","M1siji_bango","M1syukka_ymd","M1jyuryo_ymd"
	,"M1nyukayotei_su","M1nyukajisseki_su","M1kyakucyu","M1syorinm","M1syori_ymd"
	,"M1syori_tm","M1selectorcheckbox","M1entersyoriflg","M1dtlirokbn"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","伝票状態","伝票番号ＦＲＯＭ"
	,"伝票番号ＴＯ","移動伝票番号ＦＲＯＭ","移動伝票番号ＴＯ","指示番号ＦＲＯＭ","指示番号ＴＯ"
	,"入荷会社コード","入荷会社名称","入荷店コード","店舗コードボタン","入荷店名称"
	,"入荷日ＦＲＯＭ","入荷日ＴＯ","出荷会社コード","会社コードボタン","出荷会社名称"
	,"出荷店コード","出荷店舗コードボタン","出荷店舗名","出荷日ＦＲＯＭ","出荷日ＴＯ"
	,"旧自社品番","メーカー品番","スキャンコード","検索件数","検索ボタン"
	,"印刷ボタン","CSVボタン","ページャ","Ｍ１行ＮＯ","Ｍ１出荷会社コード"
	,"Ｍ１出荷店コード","Ｍ１出荷店舗名","Ｍ１入荷会社コード","Ｍ１入荷店コード","Ｍ１入荷店名称"
	,"Ｍ１伝票番号リンク","Ｍ１移動伝票番号","Ｍ１指示番号","Ｍ１出荷日","Ｍ１入荷日"
	,"Ｍ１入荷予定数","Ｍ１入荷実績数","Ｍ１客注","Ｍ１処理名称","Ｍ１処理日付"
	,"Ｍ１処理時間","Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","SN5","NA"
	,"NA","NA","NA","SG","SG"
	,"SG","SN4","SG","B","SN4"
	,"D","D","SG","B","SN4"
	,"SG","B","SN4","D","D"
	,"SG","SN9","SG","NA","B"
	,"B","B","B","NA","SN9"
	,"NA","SN4","SG","SN9","SN4"
	,"B","NA","NA","D","D"
	,"NA","NA","SN4","SN4","D"
	,"D","NA","NA","NA"
);
var ADVIT_LENGTH = new Array(
	4,0,15,1,6
	,6,6,6,24,24
	,2,10,4,0,15
	,0,0,2,0,10
	,4,0,15,0,0
	,10,30,18,4,0
	,0,0,0,3,2
	,4,15,2,4,15
	,0,6,10,0,0
	,6,6,1,8,0
	,0,1,1,2
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
	,0,0,0,0
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","DRL","TXT"
	,"TXT","TXT","TXT","TXT","TXT"
	,"TXR","TXR","TXT","BTN","TXR"
	,"TXT","TXT","TXT","BTN","TXR"
	,"TXT","BTN","TXR","TXT","TXT"
	,"TXT","TXR","TXT","TXR","BTS"
	,"BTS","BTS","LNS","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"BTS","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","CHK","HDN","HDN"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","00","10"
	,"10","10","10","00","00"
	,"10","00","10","00","00"
	,"52","52","10","00","00"
	,"10","00","00","52","52"
	,"00","00","00","12","00"
	,"00","00","00","11","00"
	,"10","00","10","00","00"
	,"00","10","10","52","52"
	,"12","12","00","00","52"
	,"56","11","11","11"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"","","","",""
	,"","","","C_TENPO_ALL_CD",""
	,"","","","C_MEISYO_CD",""
	,"","C_TENPO_ALL_CD","","",""
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
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1"
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,1
	,1,1,1,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0
);
var ADVIT_IMEMODE = new Array(
	3,0,0,0,3
	,3,3,3,3,3
	,0,0,3,0,0
	,3,3,3,0,0
	,3,0,0,3,3
	,3,0,3,0,0
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
	,0,0,0,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,0,1
	,1,1,1,1,1
	,0,0,1,0,0
	,1,1,1,0,0
	,1,0,0,1,1
	,1,0,1,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0
);
var ADVIT_CONDID = new Array(
	"","","","KIGYOKAN_DENPYO_JOTAI",""
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
var ADVIT_ACTIONID = new Array(
	"","COD","","",""
	,"","","","",""
	,"","","","COD",""
	,"","","","COD",""
	,"","COD","","",""
	,"","","","","FRM"
	,"FRM","FRM","PGN","",""
	,"","","","",""
	,"FRM","","","",""
	,"","","","",""
	,"","","",""
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","","TE130F01"
	,"TE130F01","TE130F01","","",""
	,"","","","",""
	,"TE130F02","","","",""
	,"","","","",""
	,"","","",""
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","M1","",""
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
	,"","","",""
);
var ADVIT_CAPTION = new Array(
	"店舗","","ヘッダ店舗名","伝票状態","伝票番号ＦＲＯＭ"
	,"伝票番号ＴＯ","移動伝票番号ＦＲＯＭ","移動伝票番号ＴＯ","指示番号ＦＲＯＭ","指示番号ＴＯ"
	,"入荷会社","入荷会社","入荷店","",""
	,"入荷日ＦＲＯＭ","入荷日ＴＯ","出荷会社","",""
	,"出荷店","","","出荷日ＦＲＯＭ","出荷日ＴＯ"
	,"自社品番","","スキャンコード","","検索"
	,"","","","No.","会社"
	,"出荷店","","会社","入荷店",""
	,"伝票番号","移動伝票","指示番号","出荷日","入荷日"
	,"予定数量","確定数量","客注","処理","処理日"
	,"処理時間","","",""
);

