var ADVIT_FORMID = "TE080F01";
var ADVIT_TARGETPGID = "te080p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "te080f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,4,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,21,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_BTNROWDEL = 3;
var ADVIT_ID_M1ROWNO = 4;
var ADVIT_ID_M1KAISYA_CD = 5;
var ADVIT_ID_M1BTNKAISHA_CD = 6;
var ADVIT_ID_M1KAISYA_NM = 7;
var ADVIT_ID_M1SYUKKATEN_CD = 8;
var ADVIT_ID_M1BTNSYUKKATENCD = 9;
var ADVIT_ID_M1SYUKKATEN_NM = 10;
var ADVIT_ID_M1SCMDEN_CD = 11;
var ADVIT_ID_M1SCM_CD = 12;
var ADVIT_ID_M1DENPYO_BANGO = 13;
var ADVIT_ID_M1SYUKKA_YMD = 14;
var ADVIT_ID_M1YOTEI_SU = 15;
var ADVIT_ID_M1KYAKUCYU = 16;
var ADVIT_ID_M1NEGAKI = 17;
var ADVIT_ID_M1TENPOLC_KBN_HDN = 18;
var ADVIT_ID_M1SELECTORCHECKBOX = 19;
var ADVIT_ID_M1ENTERSYORIFLG = 20;
var ADVIT_ID_M1DTLIROKBN = 21;
var ADVIT_ID_SCM_GOKEI = 22;
var ADVIT_ID_DENPYO_GOKEI = 23;
var ADVIT_ID_BTNENTER = 24;
var ADVIT_ID_SELECTROWNO = 25;
var ADVIT_ID_BTNROWINS = 26;
var ADVIT_ID_BTNCLEAR = 27;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Btnrowdel","M1rowno"
	,"M1kaisya_cd","M1btnkaisha_cd","M1kaisya_nm","M1syukkaten_cd","M1btnsyukkatencd"
	,"M1syukkaten_nm","M1scmden_cd","M1scm_cd","M1denpyo_bango","M1syukka_ymd"
	,"M1yotei_su","M1kyakucyu","M1negaki","M1tenpolc_kbn_hdn","M1selectorcheckbox"
	,"M1entersyoriflg","M1dtlirokbn","Scm_gokei","Denpyo_gokei","Btnenter"
	,"Selectrowno","Btnrowins","Btnclear"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","行削除ボタン","Ｍ１行NO"
	,"Ｍ１会社コード","Ｍ１会社コードボタン","Ｍ１会社名称","Ｍ１出荷店コード","Ｍ１出荷店舗コードボタン"
	,"Ｍ１出荷店名称","Ｍ１SCM/伝票コード","Ｍ１SCMコード","Ｍ１伝票番号","Ｍ１出荷日"
	,"Ｍ１予定数量","Ｍ１客注","Ｍ１値書","Ｍ１店舗ＬＣ区分(隠し)","Ｍ１選択フラグ(隠し)"
	,"Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)","SCM合計","伝票合計","確定ボタン"
	,"選択行行NO","ボタン行追加","ボタンクリア"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","B","NA"
	,"SG","B","SN4","SG","B"
	,"SN4","SG","SG","NA","D"
	,"NA","SN4","SN4","NA","NA"
	,"NA","NA","NA","NA","B"
	,"NA","B","B"
);
var ADVIT_LENGTH = new Array(
	4,0,15,0,3
	,2,0,10,4,0
	,15,20,20,6,0
	,8,1,1,1,1
	,1,2,4,4,0
	,3,0,0
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
	1,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","BTS","TXR"
	,"TXT","BTN","TXR","TXT","BTN"
	,"TXR","TXT","TXR","TXR","TXR"
	,"TXR","TXR","TXR","HDN","CHK"
	,"HDN","HDN","TXR","TXR","BTS"
	,"TXR","BTS","BTS"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","00","11"
	,"10","00","00","10","00"
	,"00","00","00","10","52"
	,"12","00","00","11","11"
	,"11","11","12","12","00"
	,"00","00","00"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"","C_MEISYO_CD","","","C_TENPO_ALL_CD"
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
	"","","","","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","","",""
	,"","",""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,1
	,0,0,0
);
var ADVIT_IMEMODE = new Array(
	3,0,0,0,0
	,3,0,0,3,0
	,0,3,0,0,0
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
	1,0,0,0,0
	,1,0,0,1,0
	,0,1,0,0,0
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
	"","COD","","FRM",""
	,"","COD","","","COD"
	,"","","","",""
	,"","","","",""
	,"","","","","FRM"
	,"","FRM","FRM"
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","TE080F01",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","","TE080F01"
	,"","TE080F01","TE080F01"
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
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
	"店舗","","","","No."
	,"会社","","","出荷店",""
	,"","SCMコード/伝票番号","SCMコード","伝票番号","出荷日"
	,"予定数量","客注","値書","",""
	,"","","","","確定"
	,"","ボタン行追加（ダミー）","ボタンクリア（ダミー）"
);

