var ADVIT_FORMID = "TL010F02";
var ADVIT_TARGETPGID = "tl010p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tl010f02.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,17,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,33,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_BTNBACK = 0;
var ADVIT_ID_HEAD_TENPO_CD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_BUMON_CD_BO = 3;
var ADVIT_ID_BUMON_NM = 4;
var ADVIT_ID_BAIHENKAISI_YMD = 5;
var ADVIT_ID_KAISHI_JYOTAI_NM = 6;
var ADVIT_ID_COMMENT_NM = 7;
var ADVIT_ID_BTNZENSTK = 8;
var ADVIT_ID_BTNZENKJO = 9;
var ADVIT_ID_SHUTURYOKU_SEAL = 10;
var ADVIT_ID_BTNSEAL = 11;
var ADVIT_ID_BTNLABEL_CD = 12;
var ADVIT_ID_LABEL_CD = 13;
var ADVIT_ID_LABEL_IP = 14;
var ADVIT_ID_LABEL_NM = 15;
var ADVIT_ID_PGR = 16;
var ADVIT_ID_M1ROWNO = 17;
var ADVIT_ID_M1BURANDO_NM = 18;
var ADVIT_ID_M1JISYA_HBN = 19;
var ADVIT_ID_M1MAKER_HBN = 20;
var ADVIT_ID_M1SYONMK = 21;
var ADVIT_ID_M1IRO_NM = 22;
var ADVIT_ID_M1GEN_TNK = 23;
var ADVIT_ID_M1GENBAIKA_TNM1K = 24;
var ADVIT_ID_M1MTOBAIKA_TNK = 25;
var ADVIT_ID_M1SHINBAIKA_TNK = 26;
var ADVIT_ID_M1NEIRE_RTU_GENKO = 27;
var ADVIT_ID_M1NEIRE_RTU_BAIHENGO = 28;
var ADVIT_ID_M1ZAIKO_SU = 29;
var ADVIT_ID_M1URIAGE_SU = 30;
var ADVIT_ID_M1SELECTORCHECKBOX = 31;
var ADVIT_ID_M1ENTERSYORIFLG = 32;
var ADVIT_ID_M1DTLIROKBN = 33;

var ADVIT_ID = new Array(
	"Btnback","Head_tenpo_cd","Head_tenpo_nm","Bumon_cd_bo","Bumon_nm"
	,"Baihenkaisi_ymd","Kaishi_jyotai_nm","Comment_nm","Btnzenstk","Btnzenkjo"
	,"Shuturyoku_seal","Btnseal","Btnlabel_cd","Label_cd","Label_ip"
	,"Label_nm","Pgr","M1rowno","M1burando_nm","M1jisya_hbn"
	,"M1maker_hbn","M1syonmk","M1iro_nm","M1gen_tnk","M1genbaika_tnm1k"
	,"M1mtobaika_tnk","M1shinbaika_tnk","M1neire_rtu_genko","M1neire_rtu_baihengo","M1zaiko_su"
	,"M1uriage_su","M1selectorcheckbox","M1entersyoriflg","M1dtlirokbn"
);
var ADVIT_NAME = new Array(
	"戻るボタン","ヘッダ店舗コード","ヘッダ店舗名","部門コード","部門名"
	,"売変開始日","開始状態名称","コメント","全選択ボタン","全解除ボタン"
	,"出力シール","シール発行ボタン","ラベル発行機コードボタン","ラベル発行機ＩＤ","ラベル発行機ＩＰ"
	,"ラベル発行機名","ページャ","Ｍ１行NO","Ｍ１ブランド名","Ｍ１自社品番"
	,"Ｍ１メーカー品番","Ｍ１商品名(カナ)","Ｍ１色","Ｍ１原単価","Ｍ１現売価"
	,"Ｍ１元売価","Ｍ１新売価","Ｍ１値入率現行","Ｍ１値入率売変後","Ｍ１在庫数"
	,"Ｍ１売上数","Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)"
);
var ADVIT_ATTRIBUTE = new Array(
	"B","SG","SN4","SG","SN4"
	,"D","SN4","SN4","B","B"
	,"SN5","B","B","SN4","SG"
	,"SN4","B","NA","SN9","SG"
	,"SN9","SN9","SN9","NA","NA"
	,"NA","NA","NB","NB","NA"
	,"NA","NA","NA","NA"
);
var ADVIT_LENGTH = new Array(
	0,4,15,3,15
	,0,3,20,0,0
	,1,0,0,7,12
	,10,0,4,20,8
	,30,30,10,7,7
	,7,7,4,4,5
	,7,1,1,2
);
var ADVIT_AUTOTAB = new Array(
	0,0,0,0,0
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
	,0,0,1,1,0
	,0,0,0,0
);
var ADVIT_REQUIRED = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0
);
var ADVIT_REQUIREDFLG = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0
);
var ADVIT_TYPE = new Array(
	"BTS","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","BTS","BTS"
	,"RDO","BTS","BTN","HDN","HDN"
	,"TXR","LNS","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","CHK","HDN","HDN"
);
var ADVIT_FORMAT = new Array(
	"00","10","00","10","00"
	,"52","00","00","00","00"
	,"00","00","00","00","00"
	,"00","00","11","00","00"
	,"00","00","00","12","12"
	,"12","12","22","22","12"
	,"12","11","11","11"
);
var ADVIT_CODEID = new Array(
	"","","","",""
	,"","","","",""
	,"","","C_LABEL_CD","",""
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
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1"
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,1,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0
);
var ADVIT_IMEMODE = new Array(
	0,0,0,0,0
	,0,0,0,0,0
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
	,0,0,0,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0
);
var ADVIT_CONDID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","",""
);
var ADVIT_ACTIONID = new Array(
	"FRM","","","",""
	,"","","","FRM","FRM"
	,"","FRM","COD","",""
	,"","PGN","","",""
	,"","","","",""
	,"","","","",""
	,"","","",""
);
var ADVIT_ACTIONFORMID = new Array(
	"TL010F01","","","",""
	,"","","","TL010F02","TL010F02"
	,"","TL010F02","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","",""
);
var ADVIT_ACTPARAMETER = new Array(
	"M1","","","",""
	,"","","","M1","M1"
	,"","","","",""
	,"","M1","","",""
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
	,"","","",""
);
var ADVIT_CAPTION = new Array(
	"","","","部門",""
	,"開始日","開始状態","コメント","",""
	,"出力シール","","","",""
	,"","","No.","ブランド","自社品番"
	,"メーカー品番","商品名","色","原単価","現売価"
	,"元売価","新売価","値入率現行","値入率売変後","在庫点数"
	,"売上点数","","",""
);

