var ADVIT_FORMID = "TA010F01";
var ADVIT_TARGETPGID = "ta010p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "ta010f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,24,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,36,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_BTNMODEAPPLY = 3;
var ADVIT_ID_BTNMODEREF = 4;
var ADVIT_ID_BTNMODEUPD = 5;
var ADVIT_ID_BTNMODEDEL = 6;
var ADVIT_ID_MODENO = 7;
var ADVIT_ID_STKMODENO = 8;
var ADVIT_ID_KBN_CD = 9;
var ADVIT_ID_HATTYU_YMD_FROM = 10;
var ADVIT_ID_HATTYU_YMD_TO = 11;
var ADVIT_ID_TANTOSYA_CD = 12;
var ADVIT_ID_BTNTANTO_CD = 13;
var ADVIT_ID_HANBAIIN_NM = 14;
var ADVIT_ID_IRAIRIYU_CD1 = 15;
var ADVIT_ID_IRAIRIYU_CD2 = 16;
var ADVIT_ID_SHINSEI_FLG = 17;
var ADVIT_ID_SEARCHCNT = 18;
var ADVIT_ID_BTNINSERT = 19;
var ADVIT_ID_BTNSEARCH = 20;
var ADVIT_ID_BTNZENSTK = 21;
var ADVIT_ID_BTNZENKJO = 22;
var ADVIT_ID_PGR = 23;
var ADVIT_ID_M1ROWNO = 24;
var ADVIT_ID_M1HOJUIRAI_KBN_NM = 25;
var ADVIT_ID_M1KANRI_NO = 26;
var ADVIT_ID_M1HATTYU_YMD = 27;
var ADVIT_ID_M1ITEMSU = 28;
var ADVIT_ID_M1GENKAKIN = 29;
var ADVIT_ID_M1HANBAIIN_NM = 30;
var ADVIT_ID_M1IRAI_RIYU = 31;
var ADVIT_ID_M1SINSEI_JOTAINM = 32;
var ADVIT_ID_M1APPLY_YMD = 33;
var ADVIT_ID_M1SELECTORCHECKBOX = 34;
var ADVIT_ID_M1ENTERSYORIFLG = 35;
var ADVIT_ID_M1DTLIROKBN = 36;
var ADVIT_ID_BTNENTER = 37;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Btnmodeapply","Btnmoderef"
	,"Btnmodeupd","Btnmodedel","Modeno","Stkmodeno","Kbn_cd"
	,"Hattyu_ymd_from","Hattyu_ymd_to","Tantosya_cd","Btntanto_cd","Hanbaiin_nm"
	,"Irairiyu_cd1","Irairiyu_cd2","Shinsei_flg","Searchcnt","Btninsert"
	,"Btnsearch","Btnzenstk","Btnzenkjo","Pgr","M1rowno"
	,"M1hojuirai_kbn_nm","M1kanri_no","M1hattyu_ymd","M1itemsu","M1genkakin"
	,"M1hanbaiin_nm","M1irai_riyu","M1sinsei_jotainm","M1apply_ymd","M1selectorcheckbox"
	,"M1entersyoriflg","M1dtlirokbn","Btnenter"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","モード申請ボタン","モード照会ボタン"
	,"モード修正ボタン","モード取消ボタン","モードNO","選択モードNO","区分コード"
	,"発注日FROM","発注日TO","担当者コード","担当者コードボタン","担当者名"
	,"依頼理由コード1","依頼理由コード２","申請状態","検索件数","新規作成ボタン"
	,"検索ボタン","全選択ボタン","全解除ボタン","ページャ","Ｍ１行NO"
	,"Ｍ１補充依頼区分名称","Ｍ１管理Noリンク","Ｍ１発注日","Ｍ１数量","Ｍ１原価金額"
	,"Ｍ１担当者名","Ｍ１依頼理由","Ｍ１申請状態名称","Ｍ１申請日","Ｍ１選択フラグ(隠し)"
	,"Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)","確定ボタン"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","B","B"
	,"B","B","NA","NA","SN5"
	,"D","D","SG","B","SN4"
	,"SN5","SN5","SN5","NA","B"
	,"B","B","B","B","NA"
	,"SN4","B","D","NA","NA"
	,"SN4","SN4","SN4","D","NA"
	,"NA","NA","B"
);
var ADVIT_LENGTH = new Array(
	4,0,15,0,0
	,0,0,2,2,1
	,0,0,7,0,12
	,2,2,1,4,0
	,0,0,0,0,4
	,7,0,0,9,9
	,12,10,3,0,1
	,1,2,0
);
var ADVIT_AUTOTAB = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
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
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","LNK","LNK"
	,"LNK","LNK","HDN","HDN","DRL"
	,"TXT","TXT","TXT","BTN","TXR"
	,"DRL","DRL","DRL","TXT","BTS"
	,"BTS","BTS","BTS","LNS","TXR"
	,"TXR","BTS","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","CHK"
	,"HDN","HDN","BTS"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","00","00"
	,"00","00","11","11","00"
	,"52","52","10","00","00"
	,"00","00","00","12","00"
	,"00","00","00","00","11"
	,"00","00","52","12","12"
	,"00","00","00","52","11"
	,"11","11","00"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"","","","",""
	,"","","","C_TANTO_CD",""
	,"C_RIYU_CD","C_RIYU_CD","","",""
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
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET"
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1",""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,1
	,1,0,0,1,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,1
);
var ADVIT_IMEMODE = new Array(
	3,0,0,0,0
	,0,0,0,0,0
	,3,3,3,0,0
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
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,0,0
	,0,0,0,0,0
	,1,1,1,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0
);
var ADVIT_CONDID = new Array(
	"","","","",""
	,"","","","","HOJUIRAI_KBN"
	,"","","","",""
	,"","","SINSEI_JOTAI","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","",""
);
var ADVIT_ACTIONID = new Array(
	"","COD","","SPT","SPT"
	,"SPT","SPT","","",""
	,"","","","COD",""
	,"COD","COD","","","FRM"
	,"FRM","FRM","FRM","PGN",""
	,"","FRM","","",""
	,"","","","",""
	,"","","DBU"
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","TA010F01","TA010F01"
	,"TA010F01","TA010F01","","",""
	,"","","","",""
	,"","","","","TA010F02"
	,"TA010F01","TA010F01","TA010F01","",""
	,"","TA010F02","","",""
	,"","","","",""
	,"","","TA010F01"
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","M1","M1","M1",""
	,"","M1","","",""
	,"","","","",""
	,"","",""
);
var ADVIT_ACTPROGRAMID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","",""
);
var ADVIT_CAPTION = new Array(
	"店舗","","","申請","照会"
	,"修正","取消","","","区分"
	,"発注日ＦＲＯＭ","発注日ＴＯ","担当者","",""
	,"依頼理由","依頼理由","状態","検索件数","新規作成"
	,"検索","","","","No."
	,"区分","管理No.","発注日","数量","原価金額"
	,"担当者","依頼理由","状態","申請日",""
	,"","","確定"
);

