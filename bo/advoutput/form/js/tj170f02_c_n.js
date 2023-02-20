var ADVIT_FORMID = "TJ170F02";
var ADVIT_TARGETPGID = "tj170p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tj170f02.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,9,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,31,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_BTNBACK = 0;
var ADVIT_ID_HEAD_TENPO_CD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_STKMODENO = 3;
var ADVIT_ID_SYOHINGUN1_CD = 4;
var ADVIT_ID_SYOHINGUN1_RYAKU_NM = 5;
var ADVIT_ID_SYOHINGUN2_CD = 6;
var ADVIT_ID_GRPNM = 7;
var ADVIT_ID_PGR = 8;
var ADVIT_ID_M1ROWNO = 9;
var ADVIT_ID_M1BUMON_CD = 10;
var ADVIT_ID_M1BUMONKANA_NM = 11;
var ADVIT_ID_M1HINSYU_RYAKU_NM = 12;
var ADVIT_ID_M1BURANDO_NM = 13;
var ADVIT_ID_M1JISYA_HBN = 14;
var ADVIT_ID_M1MAKER_HBN = 15;
var ADVIT_ID_M1SYONMK = 16;
var ADVIT_ID_M1IRO_NM = 17;
var ADVIT_ID_M1SIZE_NM = 18;
var ADVIT_ID_M1SCAN_CD = 19;
var ADVIT_ID_M1GENBAIKA_TNK = 20;
var ADVIT_ID_M1HYOKA_TNK = 21;
var ADVIT_ID_M1TANAJITYOBO_SU = 22;
var ADVIT_ID_M1TANAJISEKISO_SU = 23;
var ADVIT_ID_M1JITANA_SU = 24;
var ADVIT_ID_M1IKOUKEBARAI_SU = 25;
var ADVIT_ID_M1RIRONZAIKO_SU = 26;
var ADVIT_ID_M1RIRONTANAOROSI_SU = 27;
var ADVIT_ID_M1LOSS_SU = 28;
var ADVIT_ID_M1LOSS_KIN = 29;
var ADVIT_ID_M1FACE_NO = 30;
var ADVIT_ID_M1TANA_DAN = 31;
var ADVIT_ID_GOKEITANAJITYOBO_SU = 32;
var ADVIT_ID_GOKEITANAJISEKISO_SU = 33;
var ADVIT_ID_GOKEIJITANA_SU = 34;
var ADVIT_ID_GOKEIIKOUKEBARAI_SU = 35;
var ADVIT_ID_GOKEIRIRONZAIKO_SU = 36;
var ADVIT_ID_GOKEIRIRONTANAOROSI_SU = 37;
var ADVIT_ID_GOKEILOSS_SU = 38;
var ADVIT_ID_GOKEILOSS_KIN = 39;

var ADVIT_ID = new Array(
	"Btnback","Head_tenpo_cd","Head_tenpo_nm","Stkmodeno","Syohingun1_cd"
	,"Syohingun1_ryaku_nm","Syohingun2_cd","Grpnm","Pgr","M1rowno"
	,"M1bumon_cd","M1bumonkana_nm","M1hinsyu_ryaku_nm","M1burando_nm","M1jisya_hbn"
	,"M1maker_hbn","M1syonmk","M1iro_nm","M1size_nm","M1scan_cd"
	,"M1genbaika_tnk","M1hyoka_tnk","M1tanajityobo_su","M1tanajisekiso_su","M1jitana_su"
	,"M1ikoukebarai_su","M1rironzaiko_su","M1rirontanaorosi_su","M1loss_su","M1loss_kin"
	,"M1face_no","M1tana_dan","Gokeitanajityobo_su","Gokeitanajisekiso_su","Gokeijitana_su"
	,"Gokeiikoukebarai_su","Gokeirironzaiko_su","Gokeirirontanaorosi_su","Gokeiloss_su","Gokeiloss_kin"
);
var ADVIT_NAME = new Array(
	"戻るボタン","ヘッダ店舗コード","ヘッダ店舗名","選択モードNO","商品群1コード"
	,"商品群1略式名称","商品群2コード","商品群2名称","ページャ","Ｍ１行NO"
	,"Ｍ１部門コード","Ｍ１部門カナ名","Ｍ１品種略名称","Ｍ１ブランド名","Ｍ１自社品番"
	,"Ｍ１メーカー品番","Ｍ１商品名(カナ)","Ｍ１色","Ｍ１サイズ","Ｍ１スキャンコード"
	,"Ｍ１現売価","Ｍ１評価単価","Ｍ１棚時帳簿数","Ｍ１棚時積送数","Ｍ１実棚数"
	,"Ｍ１以降受払数","Ｍ１理論在庫数","Ｍ１理論棚卸数","Ｍ１ロス数","Ｍ１ロス金額"
	,"Ｍ１フェイス№","Ｍ１棚段","合計棚時帳簿数","合計棚時積送数","合計実棚数"
	,"合計以降受払数","合計理論在庫数","合計理論棚卸数","合計ロス数","合計ロス金額"
);
var ADVIT_ATTRIBUTE = new Array(
	"B","SG","SN4","NA","SG"
	,"SN4","SG","SN4","B","NA"
	,"SG","SN9","SN4","SN9","SG"
	,"SN9","SN9","SN9","SN9","SG"
	,"NA","NC","NC","NC","NC"
	,"NC","NC","NC","NC","NC"
	,"NA","NA","NC","NC","NC"
	,"NC","NC","NC","NC","NC"
);
var ADVIT_LENGTH = new Array(
	0,4,15,2,4
	,10,5,15,0,4
	,3,30,15,20,8
	,30,30,10,4,18
	,8,8,7,7,7
	,7,7,7,7,8
	,5,2,9,9,9
	,9,9,9,9,9
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
	,0,2,0,0,0
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
	"BTS","TXR","TXR","HDN","TXR"
	,"TXR","TXR","TXR","LNS","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
);
var ADVIT_FORMAT = new Array(
	"00","10","00","11","10"
	,"00","10","00","00","11"
	,"10","00","00","00","10"
	,"00","00","00","00","00"
	,"12","12","12","12","12"
	,"12","12","12","12","12"
	,"10","11","12","12","12"
	,"12","12","12","12","12"
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
	,"","","","","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","","",""
	,"","","","",""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,1,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
);
var ADVIT_IMEMODE = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
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
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
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
	"FRM","","","",""
	,"","","","PGN",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
);
var ADVIT_ACTIONFORMID = new Array(
	"TJ170F01","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","M1",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
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
);
var ADVIT_CAPTION = new Array(
	"","","","","商品群1"
	,"","商品群2","","","No."
	,"部門","","品種","ブランド","自社品番"
	,"メーカー品番","商品名","色","サイズ","スキャンコード"
	,"現売価","評価単価","棚時帳簿数","棚時積送数","実棚数"
	,"以降受払数","理論在庫数","理論棚卸数","ロス数","ロス金額"
	,"ﾌｪｲｽNo","棚段","合計","",""
	,"","","","",""
);

