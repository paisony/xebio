var ADVIT_FORMID = "TJ170F01";
var ADVIT_TARGETPGID = "tj170p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tj170f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,48,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,65,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_BTNMODEKONKAI = 3;
var ADVIT_ID_BTNMODEZENKAI = 4;
var ADVIT_ID_MODENO = 5;
var ADVIT_ID_STKMODENO = 6;
var ADVIT_ID_TANAOROSIKIJUN_YMD = 7;
var ADVIT_ID_TANAOROSIJISSI_YMD1 = 8;
var ADVIT_ID_TANAOROSIKIKAN_FROM1 = 9;
var ADVIT_ID_TANAOROSIKIKAN_TO1 = 10;
var ADVIT_ID_TANAOROSIKIJUN_YMD1 = 11;
var ADVIT_ID_TANAOROSIJISSI_YMD11 = 12;
var ADVIT_ID_TANAOROSIKIKAN_FROM11 = 13;
var ADVIT_ID_TANAOROSIKIKAN_TO11 = 14;
var ADVIT_ID_SYOHINGUN1_CD = 15;
var ADVIT_ID_BTNSYOHINGUN1_CD = 16;
var ADVIT_ID_SYOHINGUN1_RYAKU_NM = 17;
var ADVIT_ID_SYOHINGUN2_CD = 18;
var ADVIT_ID_BTNSYOHINGUN2_CD = 19;
var ADVIT_ID_GRPNM = 20;
var ADVIT_ID_BUMON_CD_FROM = 21;
var ADVIT_ID_BTNBUMON_CD_FROM = 22;
var ADVIT_ID_BUMON_NM_FROM = 23;
var ADVIT_ID_HINSYU_CD_FROM = 24;
var ADVIT_ID_BTNHINSYU_CD_FROM = 25;
var ADVIT_ID_HINSYU_RYAKU_NM_FROM = 26;
var ADVIT_ID_BUMON_CD_TO = 27;
var ADVIT_ID_BTNBUMON_CD_TO = 28;
var ADVIT_ID_BUMON_NM_TO = 29;
var ADVIT_ID_HINSYU_CD_TO = 30;
var ADVIT_ID_BTNHINSYU_CD_TO = 31;
var ADVIT_ID_HINSYU_RYAKU_NM_TO = 32;
var ADVIT_ID_BURANDO_CD = 33;
var ADVIT_ID_BTNBURANDO_CD = 34;
var ADVIT_ID_BURANDO_NM = 35;
var ADVIT_ID_LOSS_TENSU = 36;
var ADVIT_ID_LOSS_ARI_FLG = 37;
var ADVIT_ID_SHUTURYOKU_TANI = 38;
var ADVIT_ID_SORT_JUN = 39;
var ADVIT_ID_SEARCHCNT = 40;
var ADVIT_ID_BTNSEARCH = 41;
var ADVIT_ID_BTNZENSTK = 42;
var ADVIT_ID_BTNZENKJO = 43;
var ADVIT_ID_SHUTURYOKU_PRINT = 44;
var ADVIT_ID_BTNPRINT = 45;
var ADVIT_ID_BTNCSV = 46;
var ADVIT_ID_PGR = 47;
var ADVIT_ID_M1ROWNO = 48;
var ADVIT_ID_M1SYOHINGUN1_CD = 49;
var ADVIT_ID_M1SYOHINGUN1_RYAKU_NM = 50;
var ADVIT_ID_M1SYOHINGUN2_CD = 51;
var ADVIT_ID_M1GRPNM = 52;
var ADVIT_ID_M1BUMON_CD = 53;
var ADVIT_ID_M1BUMONKANA_NM = 54;
var ADVIT_ID_M1TANAJITYOBO_SU = 55;
var ADVIT_ID_M1TANAJISEKISO_SU = 56;
var ADVIT_ID_M1JITANA_SU = 57;
var ADVIT_ID_M1IKOUKEBARAI_SU = 58;
var ADVIT_ID_M1RIRONZAIKO_SU = 59;
var ADVIT_ID_M1RIRONTANAOROSI_SU = 60;
var ADVIT_ID_M1LOSS_SU = 61;
var ADVIT_ID_M1LOSS_KIN = 62;
var ADVIT_ID_M1SELECTORCHECKBOX = 63;
var ADVIT_ID_M1ENTERSYORIFLG = 64;
var ADVIT_ID_M1DTLIROKBN = 65;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Btnmodekonkai","Btnmodezenkai"
	,"Modeno","Stkmodeno","Tanaorosikijun_ymd","Tanaorosijissi_ymd1","Tanaorosikikan_from1"
	,"Tanaorosikikan_to1","Tanaorosikijun_ymd1","Tanaorosijissi_ymd11","Tanaorosikikan_from11","Tanaorosikikan_to11"
	,"Syohingun1_cd","Btnsyohingun1_cd","Syohingun1_ryaku_nm","Syohingun2_cd","Btnsyohingun2_cd"
	,"Grpnm","Bumon_cd_from","Btnbumon_cd_from","Bumon_nm_from","Hinsyu_cd_from"
	,"Btnhinsyu_cd_from","Hinsyu_ryaku_nm_from","Bumon_cd_to","Btnbumon_cd_to","Bumon_nm_to"
	,"Hinsyu_cd_to","Btnhinsyu_cd_to","Hinsyu_ryaku_nm_to","Burando_cd","Btnburando_cd"
	,"Burando_nm","Loss_tensu","Loss_ari_flg","Shuturyoku_tani","Sort_jun"
	,"Searchcnt","Btnsearch","Btnzenstk","Btnzenkjo","Shuturyoku_print"
	,"Btnprint","Btncsv","Pgr","M1rowno","M1syohingun1_cd"
	,"M1syohingun1_ryaku_nm","M1syohingun2_cd","M1grpnm","M1bumon_cd","M1bumonkana_nm"
	,"M1tanajityobo_su","M1tanajisekiso_su","M1jitana_su","M1ikoukebarai_su","M1rironzaiko_su"
	,"M1rirontanaorosi_su","M1loss_su","M1loss_kin","M1selectorcheckbox","M1entersyoriflg"
	,"M1dtlirokbn"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","モード今回ボタン","モード前回ボタン"
	,"モードNO","選択モードNO","今回棚卸基準日(隠し)","今回棚卸実施日","今回棚卸期間FROM"
	,"今回棚卸期間TO","前回棚卸基準日(隠し)","前回棚卸実施日","前回棚卸期間FROM","前回棚卸期間TO"
	,"商品群1コード","商品群1コードボタン","商品群1略式名称","商品群2コード","商品群2コードボタン"
	,"商品群2名称","部門コードFROM","部門コードFROMボタン","部門名FROM","品種コードFROM"
	,"品種コードFROMボタン","品種略名称FROM","部門コードTO","部門コードTOボタン","部門名TO"
	,"品種コードTO","品種コードTOボタン","品種略名称TO","ブランドコード","ブランドコードボタン"
	,"ブランド名","ロス点数","ロス有フラグ","出力単位","ソート順"
	,"検索件数","検索ボタン","全選択ボタン","全解除ボタン","出力帳票"
	,"印刷ボタン","CSVボタン","ページャ","Ｍ１行NO","Ｍ１商品群1リンク"
	,"Ｍ１商品群1略式名称リンク","Ｍ１商品群2コード","Ｍ１商品群2名称","Ｍ１部門コード","Ｍ１部門カナ名"
	,"Ｍ１棚時帳簿数","Ｍ１棚時積送数","Ｍ１実棚数","Ｍ１以降受払数","Ｍ１理論在庫数"
	,"Ｍ１理論棚卸数","Ｍ１ロス数","Ｍ１ロス金額","Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)"
	,"Ｍ１明細色区分(隠し)"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","B","B"
	,"NA","NA","D","D","D"
	,"D","D","D","D","D"
	,"SG","B","SN4","SG","B"
	,"SN4","SG","B","SN4","SG"
	,"B","SN4","SG","B","SN4"
	,"SG","B","SN4","SG","B"
	,"SN9","NA","NA","SN5","SN5"
	,"NA","B","B","B","SN5"
	,"B","B","B","NA","B"
	,"B","SG","SN4","SG","SN9"
	,"NC","NC","NC","NC","NC"
	,"NC","NC","NC","NA","NA"
	,"NA"
);
var ADVIT_LENGTH = new Array(
	4,0,15,0,0
	,2,2,0,0,0
	,0,0,0,0,0
	,4,0,10,5,0
	,15,3,0,15,2
	,0,15,3,0,15
	,2,0,15,6,0
	,20,7,1,1,1
	,4,0,0,0,1
	,0,0,0,4,0
	,0,5,15,3,30
	,7,7,7,7,7
	,7,7,9,1,1
	,2
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
	,0,0,0,0,0
	,0,0,0,0,0
	,0
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","LNK","LNK"
	,"HDN","HDN","HDN","TXR","TXR"
	,"TXR","HDN","TXR","TXR","TXR"
	,"TXT","BTN","TXR","TXT","BTN"
	,"TXR","TXT","BTN","TXR","TXT"
	,"BTN","TXR","TXT","BTN","TXR"
	,"TXT","BTN","TXR","TXT","BTN"
	,"TXR","TXT","CHK","RDO","RDO"
	,"TXR","BTS","BTS","BTS","RDO"
	,"BTS","BTS","LNS","TXR","BTS"
	,"BTS","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","CHK","HDN"
	,"HDN"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","00","00"
	,"11","11","52","52","52"
	,"52","52","52","52","52"
	,"10","00","00","10","00"
	,"00","10","00","00","10"
	,"00","00","10","00","00"
	,"10","00","00","10","00"
	,"00","12","11","00","00"
	,"12","00","00","00","00"
	,"00","00","00","11","00"
	,"00","10","00","10","00"
	,"12","12","12","12","12"
	,"12","12","12","11","11"
	,"11"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"","","","",""
	,"","","","",""
	,"","C_SHOHINGUN1_CD","","","C_SHOHINGUN2_CD"
	,"","","C_BUMON_CD","",""
	,"C_HINSYU_CD","","","C_BUMON_CD",""
	,"","C_HINSYU_CD","","","C_BURANDO_CD"
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
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
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET","CANNOTGET"
	,"CANNOTGET"
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1"
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,1,0,0,0
	,1,1,1,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0
);
var ADVIT_IMEMODE = new Array(
	3,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,3,0,0,3,0
	,0,3,0,0,3
	,0,0,3,0,0
	,3,0,0,3,0
	,0,3,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
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
	,0,0,0,0,0
	,0,0,0,0,0
	,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,1,0,0,1,0
	,0,1,0,0,1
	,0,0,1,0,0
	,1,0,0,1,0
	,0,1,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0
);
var ADVIT_CONDID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","SHUTURYOKU_TANI","MEISAI_SORT_TJ170F01"
	,"","","","","SHUTURYOKU_PRINT"
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,""
);
var ADVIT_ACTIONID = new Array(
	"","COD","","SPT","SPT"
	,"","","","",""
	,"","","","",""
	,"","COD","","","COD"
	,"","","COD","",""
	,"COD","","","COD",""
	,"","COD","","","COD"
	,"","","","",""
	,"","FRM","FRM","FRM",""
	,"FRM","FRM","PGN","","FRM"
	,"FRM","","","",""
	,"","","","",""
	,"","","","",""
	,""
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","TJ170F01","TJ170F01"
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","TJ170F01","TJ170F01","TJ170F01",""
	,"TJ170F01","TJ170F01","","","TJ170F02"
	,"TJ170F02","","","",""
	,"","","","",""
	,"","","","",""
	,""
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","M1","M1",""
	,"","","M1","",""
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
	,"","","","",""
	,"","","","",""
	,""
);
var ADVIT_CAPTION = new Array(
	"店舗","","","今回","前回"
	,"","","","棚卸実施日","棚卸期間ＦＲＯＭ"
	,"棚卸期間ＴＯ","","棚卸実施日","棚卸期間ＦＲＯＭ","棚卸期間ＴＯ"
	,"商品群1","","","商品群2",""
	,"","部門ＦＲＯＭ","","","品種ＦＲＯＭ"
	,"","","部門ＴＯ","",""
	,"品種ＴＯ","","","ブランド",""
	,"","ロス点数","ロス有のみ","出力単位","ソート順"
	,"","検索","","","出力帳票"
	,"","","","No.","商品群1"
	,"","商品群2","","部門",""
	,"棚時帳簿数","棚時積送数","実棚数","以降受払数","理論在庫数"
	,"理論棚卸数","ロス数","ロス金額","",""
	,""
);

