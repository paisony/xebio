var ADVIT_FORMID = "TJ190F01";
var ADVIT_TARGETPGID = "tj190p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tj190f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,46,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,72,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_BTNMODEUPD = 3;
var ADVIT_ID_BTNMODEDEL = 4;
var ADVIT_ID_BTNMODEREF = 5;
var ADVIT_ID_BTNMODELOSSKEISAN = 6;
var ADVIT_ID_BTNMODELOSSDEL = 7;
var ADVIT_ID_BTNMODELOSSREF = 8;
var ADVIT_ID_MODENO = 9;
var ADVIT_ID_STKMODENO = 10;
var ADVIT_ID_NYURYOKU_YMD_FROM = 11;
var ADVIT_ID_NYURYOKU_YMD_TO = 12;
var ADVIT_ID_TENPO_CD_FROM = 13;
var ADVIT_ID_BTNTENPOCD_FROM = 14;
var ADVIT_ID_TENPO_NM_FROM = 15;
var ADVIT_ID_TENPO_CD_TO = 16;
var ADVIT_ID_BTNTENPOCD_TO = 17;
var ADVIT_ID_TENPO_NM_TO = 18;
var ADVIT_ID_NYURYOKUTAN_CD = 19;
var ADVIT_ID_BTNTANTO_CD = 20;
var ADVIT_ID_NYURYOKUTAN_NM = 21;
var ADVIT_ID_BUMON_CD_FROM = 22;
var ADVIT_ID_BTNBUMON_CD_FROM = 23;
var ADVIT_ID_BUMON_NM_FROM = 24;
var ADVIT_ID_HINSYU_CD_FROM = 25;
var ADVIT_ID_BTNHINSYU_CD_FROM = 26;
var ADVIT_ID_HINSYU_RYAKU_NM_FROM = 27;
var ADVIT_ID_BUMON_CD_TO = 28;
var ADVIT_ID_BTNBUMON_CD_TO = 29;
var ADVIT_ID_BUMON_NM_TO = 30;
var ADVIT_ID_HINSYU_CD_TO = 31;
var ADVIT_ID_BTNHINSYU_CD_TO = 32;
var ADVIT_ID_HINSYU_RYAKU_NM_TO = 33;
var ADVIT_ID_BURANDO_CD = 34;
var ADVIT_ID_BTNBURANDO_CD = 35;
var ADVIT_ID_BURANDO_NM = 36;
var ADVIT_ID_OLD_JISYA_HBN = 37;
var ADVIT_ID_SCAN_CD = 38;
var ADVIT_ID_LOSS_KANRI_NO = 39;
var ADVIT_ID_MEISAI_SORT = 40;
var ADVIT_ID_SEARCHCNT = 41;
var ADVIT_ID_BTNSEARCH = 42;
var ADVIT_ID_BTNPRINT = 43;
var ADVIT_ID_BTNCSV = 44;
var ADVIT_ID_PGR = 45;
var ADVIT_ID_M1ROWNO = 46;
var ADVIT_ID_M1TENPO_CD = 47;
var ADVIT_ID_M1TENPO_NM = 48;
var ADVIT_ID_M1NYURYOKU_YMD = 49;
var ADVIT_ID_M1RINTANA_KANRI_NO = 50;
var ADVIT_ID_M1LOSS_KANRI_NO = 51;
var ADVIT_ID_M1BUMON_CD = 52;
var ADVIT_ID_M1HINSYU_RYAKU_NM = 53;
var ADVIT_ID_M1BURANDO_NM1 = 54;
var ADVIT_ID_M1BURANDO_NM2 = 55;
var ADVIT_ID_M1BURANDO_NM3 = 56;
var ADVIT_ID_M1BURANDO_NM4 = 57;
var ADVIT_ID_M1BURANDO_NM5 = 58;
var ADVIT_ID_M1BURANDO_NM6 = 59;
var ADVIT_ID_M1BURANDO_NM7 = 60;
var ADVIT_ID_M1BURANDO_NM8 = 61;
var ADVIT_ID_M1TANAJITYOBO_SU = 62;
var ADVIT_ID_M1TANAJISEKISO_SU = 63;
var ADVIT_ID_M1JITANA_SU = 64;
var ADVIT_ID_M1NYURYOKUTAN_NM = 65;
var ADVIT_ID_M1LOSS_SU = 66;
var ADVIT_ID_M1LOSS_KIN = 67;
var ADVIT_ID_M1LOSSKEISAN_YMD = 68;
var ADVIT_ID_M1LOSSKEISAN_TM = 69;
var ADVIT_ID_M1SELECTORCHECKBOX = 70;
var ADVIT_ID_M1ENTERSYORIFLG = 71;
var ADVIT_ID_M1DTLIROKBN = 72;
var ADVIT_ID_GOKEITANAJITYOBO_SU = 73;
var ADVIT_ID_GOKEITANAJISEKISO_SU = 74;
var ADVIT_ID_GOKEIJITANA_SU = 75;
var ADVIT_ID_GOKEILOSS_SU = 76;
var ADVIT_ID_GOKEILOSS_KIN = 77;
var ADVIT_ID_BTNENTER = 78;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Btnmodeupd","Btnmodedel"
	,"Btnmoderef","Btnmodelosskeisan","Btnmodelossdel","Btnmodelossref","Modeno"
	,"Stkmodeno","Nyuryoku_ymd_from","Nyuryoku_ymd_to","Tenpo_cd_from","Btntenpocd_from"
	,"Tenpo_nm_from","Tenpo_cd_to","Btntenpocd_to","Tenpo_nm_to","Nyuryokutan_cd"
	,"Btntanto_cd","Nyuryokutan_nm","Bumon_cd_from","Btnbumon_cd_from","Bumon_nm_from"
	,"Hinsyu_cd_from","Btnhinsyu_cd_from","Hinsyu_ryaku_nm_from","Bumon_cd_to","Btnbumon_cd_to"
	,"Bumon_nm_to","Hinsyu_cd_to","Btnhinsyu_cd_to","Hinsyu_ryaku_nm_to","Burando_cd"
	,"Btnburando_cd","Burando_nm","Old_jisya_hbn","Scan_cd","Loss_kanri_no"
	,"Meisai_sort","Searchcnt","Btnsearch","Btnprint","Btncsv"
	,"Pgr","M1rowno","M1tenpo_cd","M1tenpo_nm","M1nyuryoku_ymd"
	,"M1rintana_kanri_no","M1loss_kanri_no","M1bumon_cd","M1hinsyu_ryaku_nm","M1burando_nm1"
	,"M1burando_nm2","M1burando_nm3","M1burando_nm4","M1burando_nm5","M1burando_nm6"
	,"M1burando_nm7","M1burando_nm8","M1tanajityobo_su","M1tanajisekiso_su","M1jitana_su"
	,"M1nyuryokutan_nm","M1loss_su","M1loss_kin","M1losskeisan_ymd","M1losskeisan_tm"
	,"M1selectorcheckbox","M1entersyoriflg","M1dtlirokbn","Gokeitanajityobo_su","Gokeitanajisekiso_su"
	,"Gokeijitana_su","Gokeiloss_su","Gokeiloss_kin","Btnenter"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","モード修正ボタン","モード取消ボタン"
	,"モード照会ボタン","モードロス計算ボタン","モードロス取消ボタン","モードロス照会ボタン","モードNO"
	,"選択モードNO","入力日FROM","入力日TO","店舗コードFROM","店舗コードFROMボタン"
	,"店舗名FROM","店舗コードTO","店舗コードTOボタン","店舗名TO","入力担当者コード"
	,"担当者コードボタン","入力担当者名称","部門コードFROM","部門コードFROMボタン","部門名FROM"
	,"品種コードFROM","品種コードFROMボタン","品種略名称FROM","部門コードTO","部門コードTOボタン"
	,"部門名TO","品種コードTO","品種コードTOボタン","品種略名称TO","ブランドコード"
	,"ブランドコードボタン","ブランド名","旧自社品番","スキャンコード","ロス管理№"
	,"明細ソート","検索件数","検索ボタン","印刷ボタン","CSVボタン"
	,"ページャ","Ｍ１行NO","Ｍ１店舗コード","Ｍ１店舗名","Ｍ１入力日"
	,"Ｍ１臨棚管理№","Ｍ１ロス管理№","Ｍ１部門リンク","Ｍ１品種略名称","Ｍ１ブランド名1"
	,"Ｍ１ブランド名2","Ｍ１ブランド名3","Ｍ１ブランド名4","Ｍ１ブランド名5","Ｍ１ブランド名6"
	,"Ｍ１ブランド名7","Ｍ１ブランド名8","Ｍ１棚時帳簿数","Ｍ１棚時積送数","Ｍ１実棚数"
	,"Ｍ１入力担当者名称","Ｍ１ロス数","Ｍ１ロス金額","Ｍ１ロス計算日","Ｍ１ロス計算時間"
	,"Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)","合計棚時帳簿数","合計棚時積送数"
	,"合計実棚数","合計ロス数","合計ロス金額","確定ボタン"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","B","B"
	,"B","B","B","B","NA"
	,"NA","D","D","SG","B"
	,"SN4","SG","B","SN4","SG"
	,"B","SN4","SG","B","SN4"
	,"SG","B","SN4","SG","B"
	,"SN4","SG","B","SN4","SG"
	,"B","SN9","SG","SG","NA"
	,"SN5","NA","B","B","B"
	,"B","NA","SG","SN4","D"
	,"NA","NA","B","SN4","SN9"
	,"SN9","SN9","SN9","SN9","SN9"
	,"SN9","SN9","NC","NC","NC"
	,"SN4","NC","NC","D","D"
	,"NA","NA","NA","NC","NC"
	,"NC","NC","NC","B"
);
var ADVIT_LENGTH = new Array(
	4,0,15,0,0
	,0,0,0,0,2
	,2,0,0,4,0
	,15,4,0,15,7
	,0,12,3,0,15
	,2,0,15,3,0
	,15,2,0,15,6
	,0,20,10,18,6
	,1,4,0,0,0
	,0,4,4,15,0
	,6,6,0,15,20
	,20,20,20,20,20
	,20,20,8,8,8
	,12,8,9,0,0
	,1,1,2,9,9
	,9,9,11,0
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
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","LNK","LNK"
	,"LNK","LNK","LNK","LNK","HDN"
	,"HDN","TXT","TXT","TXT","BTN"
	,"TXR","TXT","BTN","TXR","TXT"
	,"BTN","TXR","TXT","BTN","TXR"
	,"TXT","BTN","TXR","TXT","BTN"
	,"TXR","TXT","BTN","TXR","TXT"
	,"BTN","TXR","TXT","TXT","TXT"
	,"RDO","TXR","BTS","BTS","BTS"
	,"LNS","TXR","TXR","TXR","TXR"
	,"TXR","TXR","BTS","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"CHK","HDN","HDN","TXR","TXR"
	,"TXR","TXR","TXR","BTS"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","00","00"
	,"00","00","00","00","11"
	,"11","52","52","10","00"
	,"00","10","00","00","10"
	,"00","00","10","00","00"
	,"10","00","00","10","00"
	,"00","10","00","00","10"
	,"00","00","00","00","10"
	,"00","11","00","00","00"
	,"00","11","10","00","52"
	,"10","10","00","00","00"
	,"00","00","00","00","00"
	,"00","00","12","12","12"
	,"00","12","12","52","56"
	,"11","11","11","12","12"
	,"12","12","12","00"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"","","","",""
	,"","","","","C_TENPO_CD"
	,"","","C_TENPO_CD","",""
	,"C_TANTO_CD","","","C_BUMON_CD",""
	,"","C_HINSYU_CD","","","C_BUMON_CD"
	,"","","C_HINSYU_CD","",""
	,"C_BURANDO_CD","","","",""
	,"","","","",""
	,"","","","",""
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
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","",""
	,"","","",""
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
	,0,0,1,1,1
	,1,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,1
);
var ADVIT_IMEMODE = new Array(
	3,0,0,0,0
	,0,0,0,0,0
	,0,3,3,3,0
	,0,3,0,0,3
	,0,0,3,0,0
	,3,0,0,3,0
	,0,3,0,0,3
	,0,0,3,3,3
	,0,0,0,0,0
	,0,0,0,0,0
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
	1,0,0,0,0
	,0,0,0,0,0
	,0,1,1,1,0
	,0,1,0,0,1
	,0,0,1,0,0
	,1,0,0,1,0
	,0,1,0,0,1
	,0,0,1,1,1
	,0,0,0,0,0
	,0,0,0,0,0
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
	,"","","","",""
	,"","","","",""
	,"MEISAI_SORT_TJ190F01","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","",""
);
var ADVIT_ACTIONID = new Array(
	"","COD","","SPT","SPT"
	,"SPT","SPT","SPT","SPT",""
	,"","","","","COD"
	,"","","COD","",""
	,"COD","","","COD",""
	,"","COD","","","COD"
	,"","","COD","",""
	,"COD","","","",""
	,"","","FRM","FRM","FRM"
	,"PGN","","","",""
	,"","","FRM","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","FRM"
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","TJ190F01","TJ190F01"
	,"TJ190F01","TJ190F01","TJ190F01","TJ190F01",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","TJ190F01","TJ190F01","TJ190F01"
	,"","","","",""
	,"","","TJ190F02","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","TJ190F01"
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
	,"","","","",""
	,"M1","","","",""
	,"","","M1","",""
	,"","","","",""
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
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","",""
);
var ADVIT_CAPTION = new Array(
	"店舗","","","修正","取消"
	,"照会","ロス計算","ロス取消","ロス照会",""
	,"","入力日ＦＲＯＭ","入力日ＴＯ","店舗ＦＲＯＭ",""
	,"","店舗ＴＯ","","","入力担当者"
	,"","","部門ＦＲＯＭ","",""
	,"品種ＦＲＯＭ","","","部門ＴＯ",""
	,"","品種ＴＯ","","","ブランド"
	,"","","自社品番","ｽｷｬﾝｺｰﾄﾞ","ロス管理No"
	,"","","検索","",""
	,"","No.","店舗","","入力日"
	,"臨棚管理No","ロス管理No","部門","品種","ブランド1"
	,"ブランド2","ブランド3","ブランド4","ブランド5","ブランド6"
	,"ブランド7","ブランド8","棚時帳簿数","棚時積送数","実棚数"
	,"入力担当者","ロス数","ロス金額","ロス計算日",""
	,"","","","合計",""
	,"","","","確定"
);

