var ADVIT_FORMID = "TK020F01";
var ADVIT_TARGETPGID = "tk020p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tk020f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,21,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,52,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_BTNMODEAPPLY = 3;
var ADVIT_ID_BTNMODEREAPPLY = 4;
var ADVIT_ID_BTNMODEUPD = 5;
var ADVIT_ID_BTNMODEKESSAIJYOKYO = 6;
var ADVIT_ID_BTNMODEREF = 7;
var ADVIT_ID_MODENO = 8;
var ADVIT_ID_STKMODENO = 9;
var ADVIT_ID_SYORI_YM = 10;
var ADVIT_ID_KYAKKA_FLG = 11;
var ADVIT_ID_MEISAI_SORT = 12;
var ADVIT_ID_SEARCHCNT = 13;
var ADVIT_ID_BTNSEARCH = 14;
var ADVIT_ID_BTNZENSTK = 15;
var ADVIT_ID_BTNZENKJO = 16;
var ADVIT_ID_BTNROWINS = 17;
var ADVIT_ID_BTNROWDEL = 18;
var ADVIT_ID_BTNPRINT = 19;
var ADVIT_ID_PGR = 20;
var ADVIT_ID_M1ROWNO = 21;
var ADVIT_ID_M1BUMON_CD = 22;
var ADVIT_ID_M1BUMON_NM_HDN = 23;
var ADVIT_ID_M1HINSYU_CD = 24;
var ADVIT_ID_M1HINSYU_RYAKU_NM_HDN = 25;
var ADVIT_ID_M1BURANDO_NM = 26;
var ADVIT_ID_M1JISYA_HBN = 27;
var ADVIT_ID_M1HANBAIKANRYO_YMD = 28;
var ADVIT_ID_M1MAKER_HBN = 29;
var ADVIT_ID_M1SYONMK = 30;
var ADVIT_ID_M1SCAN_CD = 31;
var ADVIT_ID_M1IRO_NM = 32;
var ADVIT_ID_M1SIZE_NM = 33;
var ADVIT_ID_M1GENBAIKA_TNK = 34;
var ADVIT_ID_M1HYOKASON_SU = 35;
var ADVIT_ID_M1GEN_TNK = 36;
var ADVIT_ID_M1HAIBUN_KIN = 37;
var ADVIT_ID_M1NYURYOKU_YMD = 38;
var ADVIT_ID_M1APPLY_YMD = 39;
var ADVIT_ID_M1NYURYOKUSHA_CD = 40;
var ADVIT_ID_M1SINSEISYA_CD = 41;
var ADVIT_ID_M1HYOKASONSYUBETSU_KB = 42;
var ADVIT_ID_M1HYOKASONRIYU_KB = 43;
var ADVIT_ID_M1HYOKASONRIYU = 44;
var ADVIT_ID_M1KYAKKARIYU = 45;
var ADVIT_ID_M1TYOTATSU_NM = 46;
var ADVIT_ID_M1SYONIN_NM = 47;
var ADVIT_ID_M1HYOKASON_SU_HDN = 48;
var ADVIT_ID_M1HAIBUN_KIN_HDN = 49;
var ADVIT_ID_M1SELECTORCHECKBOX = 50;
var ADVIT_ID_M1ENTERSYORIFLG = 51;
var ADVIT_ID_M1DTLIROKBN = 52;
var ADVIT_ID_GOKEI_SURYO = 53;
var ADVIT_ID_HAIBUN_KIN_GOKEI = 54;
var ADVIT_ID_BTNENTER = 55;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Btnmodeapply","Btnmodereapply"
	,"Btnmodeupd","Btnmodekessaijyokyo","Btnmoderef","Modeno","Stkmodeno"
	,"Syori_ym","Kyakka_flg","Meisai_sort","Searchcnt","Btnsearch"
	,"Btnzenstk","Btnzenkjo","Btnrowins","Btnrowdel","Btnprint"
	,"Pgr","M1rowno","M1bumon_cd","M1bumon_nm_hdn","M1hinsyu_cd"
	,"M1hinsyu_ryaku_nm_hdn","M1burando_nm","M1jisya_hbn","M1hanbaikanryo_ymd","M1maker_hbn"
	,"M1syonmk","M1scan_cd","M1iro_nm","M1size_nm","M1genbaika_tnk"
	,"M1hyokason_su","M1gen_tnk","M1haibun_kin","M1nyuryoku_ymd","M1apply_ymd"
	,"M1nyuryokusha_cd","M1sinseisya_cd","M1hyokasonsyubetsu_kb","M1hyokasonriyu_kb","M1hyokasonriyu"
	,"M1kyakkariyu","M1tyotatsu_nm","M1syonin_nm","M1hyokason_su_hdn","M1haibun_kin_hdn"
	,"M1selectorcheckbox","M1entersyoriflg","M1dtlirokbn","Gokei_suryo","Haibun_kin_gokei"
	,"Btnenter"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","モード申請ボタン","モード再申請ボタン"
	,"モード修正ボタン","モード決裁状況ボタン","モード照会ボタン","モードNO","選択モードNO"
	,"処理月","却下フラグ","明細ソート","検索件数","検索ボタン"
	,"全選択ボタン","全解除ボタン","行追加ボタン","行削除ボタン","印刷ボタン"
	,"ページャ","Ｍ１行NO","Ｍ１部門コード","M1部門名","Ｍ１品種コード"
	,"M1品種略名称","Ｍ１ブランド名","Ｍ１自社品番","Ｍ１販売完了日","Ｍ１メーカー品番"
	,"Ｍ１商品名(カナ)","Ｍ１スキャンコード","Ｍ１色","Ｍ１サイズ","Ｍ１現売価"
	,"Ｍ１数量","Ｍ１原単価","Ｍ１原価金額","Ｍ１入力日","Ｍ１申請日"
	,"Ｍ１入力者コード","Ｍ１申請者コード","Ｍ１評価損種別区分","Ｍ１評価損理由区分","Ｍ１評価損理由"
	,"Ｍ１却下理由","Ｍ１調達区分名称","Ｍ１承認状態名称","Ｍ１数量(隠し)","Ｍ１原価金額(隠し)"
	,"Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)","合計数量","原価金額合計"
	,"確定ボタン"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","B","B"
	,"B","B","B","NA","NA"
	,"SD","NA","SN5","NA","B"
	,"B","B","B","B","B"
	,"B","NA","SG","SN5","SG"
	,"SN5","SN9","SG","D","SN9"
	,"SN9","SG","SN9","SN9","NA"
	,"NC","NA","NA","NA","NA"
	,"SG","SG","SN5","SN5","SN21"
	,"SN4","SN9","SN4","NA","NA"
	,"NA","NA","NA","NA","NA"
	,"B"
);
var ADVIT_LENGTH = new Array(
	4,0,15,0,0
	,0,0,0,2,2
	,6,1,1,4,0
	,0,0,0,0,0
	,0,4,3,15,2
	,15,20,8,0,30
	,30,18,10,4,7
	,4,7,9,6,6
	,7,7,2,2,20
	,30,2,2,7,9
	,1,1,2,8,9
	,0
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
	,0
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
	,0
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
	,0
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
	,0
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","LNK","LNK"
	,"LNK","LNK","LNK","HDN","HDN"
	,"DRL","CHK","RDO","TXT","BTS"
	,"BTS","BTS","BTS","BTS","BTS"
	,"LNS","TXR","TXR","HDN","TXR"
	,"HDN","TXR","TXR","TXR","TXR"
	,"TXR","TXT","TXR","TXR","TXR"
	,"TXT","TXR","TXR","TXR","TXR"
	,"TXR","TXR","DRL","DRL","TXT"
	,"TXR","TXR","TXR","HDN","HDN"
	,"CHK","HDN","HDN","TXR","TXR"
	,"BTS"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","00","00"
	,"00","00","00","11","11"
	,"00","11","00","11","00"
	,"00","00","00","00","00"
	,"00","11","10","00","10"
	,"00","00","10","52","00"
	,"00","00","00","00","12"
	,"12","12","12","10","10"
	,"10","10","00","00","00"
	,"00","00","00","11","11"
	,"11","11","11","12","12"
	,"00"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","C_MEISYO_CD","C_MEISYO_CD",""
	,"","","","",""
	,"","","","",""
	,""
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
	,"CANNOTGET"
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","",""
	,""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,1
	,0,0,0,0,1
	,1,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,1
);
var ADVIT_IMEMODE = new Array(
	3,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,3,0,0,0
	,3,0,0,0,0
	,0,0,0,0,1
	,0,0,0,0,0
	,0,0,0,0,0
	,0
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
	,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,1,0,0,0
	,1,0,0,0,0
	,0,0,0,0,1
	,0,0,0,0,0
	,0,0,0,0,0
	,0
);
var ADVIT_CONDID = new Array(
	"","","","",""
	,"","","","",""
	,"","","MEISAI_SORT_TK020F01","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,""
);
var ADVIT_ACTIONID = new Array(
	"","COD","","SPT","SPT"
	,"SPT","SPT","SPT","",""
	,"","","","","FRM"
	,"FRM","FRM","MADD","FRM","FRM"
	,"PGN","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","COD","COD",""
	,"","","","",""
	,"","","","",""
	,"FRM"
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","TK020F01","TK020F01"
	,"TK020F01","TK020F01","TK020F01","",""
	,"","","","","TK020F01"
	,"TK020F01","TK020F01","","TK020F01","TK020F01"
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"TK020F01"
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"M1","M1","M1","",""
	,"M1","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,""
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
	,""
);
var ADVIT_CAPTION = new Array(
	"店舗","","","申請","再申請"
	,"修正","決裁状況","照会","",""
	,"処理月","却下データのみ","","","検索"
	,"","","","",""
	,"","No.","部門","","品種"
	,"","ブランド","自社品番","販完日","メーカー品番"
	,"商品名","スキャンコード","色","サイズ","現売価"
	,"数量","原単価","原価金額","入力日","申請日"
	,"入力者","申請者","種別","評価損理由","評価損理由"
	,"却下理由","調達","承認","",""
	,"","","","合計",""
	,"確定"
);

