var ADVIT_FORMID = "TL030F02";
var ADVIT_TARGETPGID = "tl030p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tl030f02.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,17,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,38,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_BTNBACK = 0;
var ADVIT_ID_HEAD_TENPO_CD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_SHINSEIMOTO_NM = 3;
var ADVIT_ID_SINSEITAN_CD = 4;
var ADVIT_ID_SINSEITAN_NM = 5;
var ADVIT_ID_BUMON_CD = 6;
var ADVIT_ID_BUMON_NM = 7;
var ADVIT_ID_BAIHEN_SHIJI_NO = 8;
var ADVIT_ID_BAIHEN_RIYU_NM = 9;
var ADVIT_ID_AIHENSAGYOKAISI_YMD = 10;
var ADVIT_ID_BAIHENKAISI_YMD = 11;
var ADVIT_ID_BTNZENSYONIN = 12;
var ADVIT_ID_BTNZENKYAKKA = 13;
var ADVIT_ID_BTNZENBAIHEN = 14;
var ADVIT_ID_BTNZENENTYO = 15;
var ADVIT_ID_PGR = 16;
var ADVIT_ID_M1ROWNO = 17;
var ADVIT_ID_M1HINSYU_RYAKU_NM = 18;
var ADVIT_ID_M1BURANDO_NM = 19;
var ADVIT_ID_M1JISYA_HBN = 20;
var ADVIT_ID_M1MAKER_HBN = 21;
var ADVIT_ID_M1SYONMK = 22;
var ADVIT_ID_M1IRO_NM = 23;
var ADVIT_ID_M1SEASON_KB = 24;
var ADVIT_ID_M1HANBAIKANRYO_YMD = 25;
var ADVIT_ID_M1MTOBAIKA_TNK = 26;
var ADVIT_ID_M1GEN_TNK = 27;
var ADVIT_ID_M1YOBOBAIKA_TNK = 28;
var ADVIT_ID_M1KAKUTEIBAIKA_TNK = 29;
var ADVIT_ID_M1NEIRE_RTU_GENKO = 30;
var ADVIT_ID_M1NEIRE_RTU_BAIHENGO = 31;
var ADVIT_ID_M1ZAIKO_SU = 32;
var ADVIT_ID_M1URIAGE_SU = 33;
var ADVIT_ID_M1SYONIN_FLG = 34;
var ADVIT_ID_M1KYAKKA_FLG = 35;
var ADVIT_ID_M1SELECTORCHECKBOX = 36;
var ADVIT_ID_M1ENTERSYORIFLG = 37;
var ADVIT_ID_M1DTLIROKBN = 38;
var ADVIT_ID_BTNENTER = 39;

var ADVIT_ID = new Array(
	"Btnback","Head_tenpo_cd","Head_tenpo_nm","Shinseimoto_nm","Sinseitan_cd"
	,"Sinseitan_nm","Bumon_cd","Bumon_nm","Baihen_shiji_no","Baihen_riyu_nm"
	,"Aihensagyokaisi_ymd","Baihenkaisi_ymd","Btnzensyonin","Btnzenkyakka","Btnzenbaihen"
	,"Btnzenentyo","Pgr","M1rowno","M1hinsyu_ryaku_nm","M1burando_nm"
	,"M1jisya_hbn","M1maker_hbn","M1syonmk","M1iro_nm","M1season_kb"
	,"M1hanbaikanryo_ymd","M1mtobaika_tnk","M1gen_tnk","M1yobobaika_tnk","M1kakuteibaika_tnk"
	,"M1neire_rtu_genko","M1neire_rtu_baihengo","M1zaiko_su","M1uriage_su","M1syonin_flg"
	,"M1kyakka_flg","M1selectorcheckbox","M1entersyoriflg","M1dtlirokbn","Btnenter"
);
var ADVIT_NAME = new Array(
	"戻るボタン","ヘッダ店舗コード","ヘッダ店舗名","申請元名称","申請担当者コード"
	,"申請担当者名称","部門コード","部門名","売変指示No","売変理由名称"
	,"売変作業開始日","売変開始日","全承認ボタン","全却下ボタン","全売変ボタン"
	,"全延長ボタン","ページャ","Ｍ１行NO","Ｍ１品種略名称","Ｍ１ブランド名"
	,"Ｍ１自社品番","Ｍ１メーカー品番","Ｍ１商品名(カナ)","Ｍ１色","Ｍ１シーズン"
	,"Ｍ１販売完了日","Ｍ１元売価","Ｍ１原単価","Ｍ１要望売価","Ｍ１確定売価"
	,"Ｍ１値入率現行","Ｍ１値入率売変後","Ｍ１在庫数","Ｍ１売上数","Ｍ１承認状態"
	,"Ｍ１却下フラグ","Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)","確定ボタン"
);
var ADVIT_ATTRIBUTE = new Array(
	"B","SG","SN4","SN4","SG"
	,"SN4","SG","SN4","SG","SN4"
	,"D","D","B","B","B"
	,"B","B","NA","SN4","SN9"
	,"SG","SN9","SN9","SN9","NA"
	,"D","NA","NA","NA","NA"
	,"NB","NB","NA","NA","NA"
	,"NA","NA","NA","NA","B"
);
var ADVIT_LENGTH = new Array(
	0,4,15,2,7
	,12,3,15,10,4
	,0,0,0,0,0
	,0,0,4,15,20
	,8,30,30,10,1
	,0,7,7,7,7
	,4,4,7,7,1
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
);
var ADVIT_DECIMAL = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,1,1,0,0,0
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
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
);
var ADVIT_TYPE = new Array(
	"BTS","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","BTS","BTS","BTS"
	,"BTS","LNS","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXT"
	,"TXR","TXR","TXR","TXR","CHK"
	,"CHK","CHK","HDN","HDN","BTS"
);
var ADVIT_FORMAT = new Array(
	"00","10","00","00","10"
	,"00","10","00","10","00"
	,"52","52","00","00","00"
	,"00","00","11","00","00"
	,"10","00","00","00","11"
	,"52","12","12","12","12"
	,"19","19","12","12","11"
	,"11","11","11","11","00"
);
var ADVIT_CODEID = new Array(
	"","","","",""
	,"","","","",""
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
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1",""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,1,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,1
);
var ADVIT_IMEMODE = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,3
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
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,1
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
	"FRM","","","",""
	,"","","","",""
	,"","","FRM","FRM","FRM"
	,"FRM","PGN","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","","FRM"
);
var ADVIT_ACTIONFORMID = new Array(
	"TL030F01","","","",""
	,"","","","",""
	,"","","TL030F02","TL030F02","TL030F02"
	,"TL030F02","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","","TL030F01"
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","M1","M1","M1"
	,"M1","M1","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","","M1"
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
);
var ADVIT_CAPTION = new Array(
	"","","","申請元","申請担当者"
	,"","部門","","売変指示No","売変理由"
	,"作業開始日","開始日","","",""
	,"","ページャ","No.","品種","ブランド"
	,"自社品番","メーカー品番","商品名","色","シーズン"
	,"販売完了日","元売価","原単価","要望売価","確定売価"
	,"値入率現行","値入率売変後","在庫点数","売上点数",""
	,"","選択フラグ(隠し)","確定処理フラグ(隠し)","明細色区分(隠し)","確定"
);

