var ADVIT_FORMID = "TE090F01";
var ADVIT_TARGETPGID = "te090p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "te090f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,23,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,38,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_BTNMODENYUKAKAKUTEI = 3;
var ADVIT_ID_BTNMODEKAKUTEIGOUPD = 4;
var ADVIT_ID_BTNMODEKAKUTEIGODEL = 5;
var ADVIT_ID_BTNMODEREF = 6;
var ADVIT_ID_MODENO = 7;
var ADVIT_ID_STKMODENO = 8;
var ADVIT_ID_KAISYA_CD = 9;
var ADVIT_ID_BTNKAISHA_CD = 10;
var ADVIT_ID_KAISYA_NM = 11;
var ADVIT_ID_SYUKKATEN_CD = 12;
var ADVIT_ID_BTNSYUKKATENCD = 13;
var ADVIT_ID_SYUKKATEN_NM = 14;
var ADVIT_ID_DENPYO_BANGO_FROM = 15;
var ADVIT_ID_DENPYO_BANGO_TO = 16;
var ADVIT_ID_SCM_CD = 17;
var ADVIT_ID_SYUKKA_YMD_FROM = 18;
var ADVIT_ID_SYUKKA_YMD_TO = 19;
var ADVIT_ID_SEARCHCNT = 20;
var ADVIT_ID_BTNSEARCH = 21;
var ADVIT_ID_PGR = 22;
var ADVIT_ID_M1ROWNO = 23;
var ADVIT_ID_M1KAISYAKANA_NM = 24;
var ADVIT_ID_M1SYUKKATEN_CD = 25;
var ADVIT_ID_M1SYUKKATEN_NM = 26;
var ADVIT_ID_M1SCM_CD = 27;
var ADVIT_ID_M1DENPYO_BANGO = 28;
var ADVIT_ID_M1SYUKKA_YMD = 29;
var ADVIT_ID_M1JYURYO_YMD = 30;
var ADVIT_ID_M1YOTEI_SU = 31;
var ADVIT_ID_M1KAKUTEI_SU = 32;
var ADVIT_ID_M1KYAKUCYU = 33;
var ADVIT_ID_M1NEGAKI = 34;
var ADVIT_ID_M1DENPYO_JYOTAINM = 35;
var ADVIT_ID_M1SELECTORCHECKBOX = 36;
var ADVIT_ID_M1ENTERSYORIFLG = 37;
var ADVIT_ID_M1DTLIROKBN = 38;
var ADVIT_ID_BTNENTER = 39;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Btnmodenyukakakutei","Btnmodekakuteigoupd"
	,"Btnmodekakuteigodel","Btnmoderef","Modeno","Stkmodeno","Kaisya_cd"
	,"Btnkaisha_cd","Kaisya_nm","Syukkaten_cd","Btnsyukkatencd","Syukkaten_nm"
	,"Denpyo_bango_from","Denpyo_bango_to","Scm_cd","Syukka_ymd_from","Syukka_ymd_to"
	,"Searchcnt","Btnsearch","Pgr","M1rowno","M1kaisyakana_nm"
	,"M1syukkaten_cd","M1syukkaten_nm","M1scm_cd","M1denpyo_bango","M1syukka_ymd"
	,"M1jyuryo_ymd","M1yotei_su","M1kakutei_su","M1kyakucyu","M1negaki"
	,"M1denpyo_jyotainm","M1selectorcheckbox","M1entersyoriflg","M1dtlirokbn","Btnenter"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","モード入荷確定ボタン","モード確定後修正ボタン"
	,"モード確定後取消ボタン","モード照会ボタン","モードNO","選択モードNO","会社コード"
	,"会社コードボタン","会社名称","出荷店コード","出荷店舗コードボタン","出荷店名称"
	,"伝票番号FROM","伝票番号TO","SCMコード","出荷日ＦＲＯＭ","出荷日ＴＯ"
	,"検索件数","検索ボタン","ページャ","Ｍ１行ＮＯ","Ｍ１会社カナ名"
	,"Ｍ１出荷店コード","Ｍ１出荷店名称","Ｍ１SCMコード","Ｍ１伝票番号リンク","Ｍ１出荷日"
	,"Ｍ１入荷日","Ｍ１予定数量","Ｍ１確定数量","Ｍ１客注","Ｍ１値書"
	,"Ｍ１伝票状態名称","Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)","確定ボタン"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","B","B"
	,"B","B","NA","NA","SG"
	,"B","SN4","SG","B","SN4"
	,"NA","NA","SG","D","D"
	,"NA","B","B","NA","SN9"
	,"SG","SN4","SG","B","D"
	,"D","NA","NA","SN4","SN4"
	,"SN4","NA","NA","NA","B"
);
var ADVIT_LENGTH = new Array(
	4,0,15,0,0
	,0,0,2,2,2
	,0,10,4,0,15
	,6,6,20,0,0
	,4,0,0,3,2
	,4,15,20,0,0
	,0,6,6,1,1
	,20,1,1,2,0
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
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","LNK","LNK"
	,"LNK","LNK","HDN","HDN","TXT"
	,"BTN","TXR","TXT","BTN","TXR"
	,"TXT","TXT","TXT","TXT","TXT"
	,"TXR","BTS","LNS","TXR","TXR"
	,"TXR","TXR","TXR","BTS","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","CHK","HDN","HDN","BTS"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","00","00"
	,"00","00","11","11","10"
	,"00","00","10","00","00"
	,"10","10","00","52","52"
	,"11","00","00","11","00"
	,"10","00","00","00","52"
	,"52","12","12","00","00"
	,"00","11","11","11","00"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"","","","",""
	,"C_MEISYO_CD","","","C_TENPO_ALL_CD",""
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
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1",""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,1,1,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,1
);
var ADVIT_IMEMODE = new Array(
	3,0,0,0,0
	,0,0,0,0,3
	,0,0,3,0,0
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
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,0,0
	,0,0,0,0,1
	,0,0,1,0,0
	,1,1,1,1,1
	,0,0,0,0,0
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
	,"","","","",""
);
var ADVIT_ACTIONID = new Array(
	"","COD","","SPT","SPT"
	,"SPT","SPT","","",""
	,"COD","","","COD",""
	,"","","","",""
	,"","FRM","PGN","",""
	,"","","","FRM",""
	,"","","","",""
	,"","","","","FRM"
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","TE090F01","TE090F01"
	,"TE090F01","TE090F01","","",""
	,"","","","",""
	,"","","","",""
	,"","TE090F01","","",""
	,"","","","TE090F02",""
	,"","","","",""
	,"","","","","TE090F01"
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","M1","",""
	,"","","","M1",""
	,"","","","",""
	,"","","","",""
);
var ADVIT_ACTPROGRAMID = new Array(
	"","","","TE090P01","TE090P01"
	,"TE090P01","TE090P01","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
);
var ADVIT_CAPTION = new Array(
	"店舗","","","入荷確定","確定後修正"
	,"確定後取消","照会","","","会社"
	,"","","出荷店","",""
	,"伝票番号ＦＲＯＭ","伝票番号ＴＯ","SCMコード","出荷日ＦＲＯＭ","出荷日ＴＯ"
	,"","検索","","No.","会社"
	,"出荷店","","SCMコード","伝票番号","出荷日"
	,"入荷日","予定数量","確定数量","客注","値書"
	,"伝票状態","","","","確定"
);

