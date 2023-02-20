var ADVIT_FORMID = "TE070F01";
var ADVIT_TARGETPGID = "te070p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "te070f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,26,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,44,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_DENPYO_JYOTAI = 3;
var ADVIT_ID_SYUKKA_YMD_FROM = 4;
var ADVIT_ID_SYUKKA_YMD_TO = 5;
var ADVIT_ID_JYURYO_YMD_FROM = 6;
var ADVIT_ID_JYURYO_YMD_TO = 7;
var ADVIT_ID_KAISYA_CD = 8;
var ADVIT_ID_BTNKAISHA_CD = 9;
var ADVIT_ID_KAISYA_NM = 10;
var ADVIT_ID_SYUKKATEN_CD = 11;
var ADVIT_ID_BTNSYUKKATENCD = 12;
var ADVIT_ID_SYUKKATEN_NM = 13;
var ADVIT_ID_DENPYO_BANGO_FROM = 14;
var ADVIT_ID_DENPYO_BANGO_TO = 15;
var ADVIT_ID_SCM_CD = 16;
var ADVIT_ID_OLD_JISYA_HBN = 17;
var ADVIT_ID_MAKER_HBN = 18;
var ADVIT_ID_SCAN_CD = 19;
var ADVIT_ID_OFFLINE_NO = 20;
var ADVIT_ID_SEARCHCNT = 21;
var ADVIT_ID_BTNSEARCH = 22;
var ADVIT_ID_BTNPRINT = 23;
var ADVIT_ID_PGR = 24;
var ADVIT_ID_EIGYO_YMD_HDN = 25;
var ADVIT_ID_M1ROWNO = 26;
var ADVIT_ID_M1KAISYA_CD = 27;
var ADVIT_ID_M1SYUKKATEN_CD = 28;
var ADVIT_ID_M1SYUKKATEN_NM = 29;
var ADVIT_ID_M1SCM_CD = 30;
var ADVIT_ID_M1DENPYO_BANGO = 31;
var ADVIT_ID_M1SYUKKA_YMD = 32;
var ADVIT_ID_M1JYURYO_YMD = 33;
var ADVIT_ID_M1YOTEI_SU = 34;
var ADVIT_ID_M1KAKUTEI_SU = 35;
var ADVIT_ID_M1KYAKUCYU = 36;
var ADVIT_ID_M1NEGAKI = 37;
var ADVIT_ID_M1DENPYO_JYOTAINM = 38;
var ADVIT_ID_M1SYORINM = 39;
var ADVIT_ID_M1SYORIYMD = 40;
var ADVIT_ID_M1SYORI_TM = 41;
var ADVIT_ID_M1SELECTORCHECKBOX = 42;
var ADVIT_ID_M1ENTERSYORIFLG = 43;
var ADVIT_ID_M1DTLIROKBN = 44;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Denpyo_jyotai","Syukka_ymd_from"
	,"Syukka_ymd_to","Jyuryo_ymd_from","Jyuryo_ymd_to","Kaisya_cd","Btnkaisha_cd"
	,"Kaisya_nm","Syukkaten_cd","Btnsyukkatencd","Syukkaten_nm","Denpyo_bango_from"
	,"Denpyo_bango_to","Scm_cd","Old_jisya_hbn","Maker_hbn","Scan_cd"
	,"Offline_no","Searchcnt","Btnsearch","Btnprint","Pgr"
	,"Eigyo_ymd_hdn","M1rowno","M1kaisya_cd","M1syukkaten_cd","M1syukkaten_nm"
	,"M1scm_cd","M1denpyo_bango","M1syukka_ymd","M1jyuryo_ymd","M1yotei_su"
	,"M1kakutei_su","M1kyakucyu","M1negaki","M1denpyo_jyotainm","M1syorinm"
	,"M1syoriymd","M1syori_tm","M1selectorcheckbox","M1entersyoriflg","M1dtlirokbn"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","伝票状態","出荷日ＦＲＯＭ"
	,"出荷日ＴＯ","入荷日ＦＲＯＭ","入荷日ＴＯ","会社コード","会社コードボタン"
	,"会社名称","出荷店コード","出荷店舗コードボタン","出荷店名称","伝票番号FROM"
	,"伝票番号TO","SCMコード","旧自社品番","メーカー品番","スキャンコード"
	,"オフライン伝票No","検索件数","検索ボタン","印刷ボタン","ページャ"
	,"営業日(隠し)","Ｍ１行ＮＯ","Ｍ１会社コード","Ｍ１出荷店コード","Ｍ１出荷店名称"
	,"Ｍ１SCMコード","Ｍ１伝票番号リンク","Ｍ１出荷日","Ｍ１入荷日","Ｍ１予定数量"
	,"Ｍ１確定数量","Ｍ１客注","Ｍ１値書","Ｍ１伝票状態名称","Ｍ１処理名称"
	,"Ｍ１処理日","Ｍ１処理時間","Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","SN5","D"
	,"D","D","D","SG","B"
	,"SN4","SG","B","SN4","NA"
	,"NA","SG","SG","SN9","SG"
	,"SG","NA","B","B","B"
	,"D","NA","SN9","SG","SN4"
	,"SG","B","D","D","NA"
	,"NA","SN4","SN4","SN4","SN4"
	,"D","D","NA","NA","NA"
);
var ADVIT_LENGTH = new Array(
	4,0,15,1,0
	,0,0,0,2,0
	,10,4,0,15,6
	,6,20,10,30,18
	,20,4,0,0,0
	,0,4,2,4,15
	,20,0,0,0,6
	,6,1,1,20,8
	,0,0,1,1,2
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
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","DRL","TXT"
	,"TXT","TXT","TXT","TXT","BTN"
	,"TXR","TXT","BTN","TXR","TXT"
	,"TXT","TXT","TXT","TXR","TXT"
	,"TXT","TXR","BTS","BTS","LNS"
	,"HDN","TXR","TXR","TXR","TXR"
	,"TXR","BTS","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","CHK","HDN","HDN"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","00","52"
	,"52","52","52","10","00"
	,"00","10","00","00","10"
	,"10","00","00","00","00"
	,"00","12","00","00","00"
	,"52","11","00","10","00"
	,"00","00","52","52","12"
	,"12","00","00","00","00"
	,"52","56","11","11","11"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"","","","","C_MEISYO_CD"
	,"","","C_TENPO_ALL_CD","",""
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
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,1,1,1
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
);
var ADVIT_IMEMODE = new Array(
	3,0,0,0,3
	,3,3,3,3,0
	,0,3,0,0,3
	,3,3,3,0,3
	,3,0,0,0,0
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
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,0,1
	,1,1,1,1,0
	,0,1,0,0,1
	,1,1,1,0,1
	,1,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
);
var ADVIT_CONDID = new Array(
	"","","","IDONYUKA_DENPYO_JOTAI",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
);
var ADVIT_ACTIONID = new Array(
	"","COD","","",""
	,"","","","","COD"
	,"","","COD","",""
	,"","","","",""
	,"","","FRM","FRM","PGN"
	,"","","","",""
	,"","FRM","","",""
	,"","","","",""
	,"","","","",""
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","TE070F01","TE070F01",""
	,"","","","",""
	,"","TE070F02","","",""
	,"","","","",""
	,"","","","",""
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","","M1"
	,"","","","",""
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
);
var ADVIT_CAPTION = new Array(
	"店舗","","","伝票状態","出荷日ＦＲＯＭ"
	,"出荷日ＴＯ","入荷日ＦＲＯＭ","入荷日ＴＯ","会社",""
	,"","出荷店","","","伝票番号ＦＲＯＭ"
	,"伝票番号ＴＯ","SCMコード","自社品番","","ｽｷｬﾝｺｰﾄﾞ"
	,"ｵﾌﾗｲﾝ伝票No","","検索","",""
	,"","No.","会社","出荷店",""
	,"SCMコード","伝票番号","出荷日","入荷日","予定数量"
	,"確定数量","客注","値書","伝票状態","処理"
	,"処理日","処理時間","","",""
);

