var ADVIT_FORMID = "TJ190F02";
var ADVIT_TARGETPGID = "tj190p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tj190f02.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,48,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,68,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_BTNBACK = 0;
var ADVIT_ID_HEAD_TENPO_CD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_MODENO = 3;
var ADVIT_ID_STKMODENO = 4;
var ADVIT_ID_TENPO_CD_HDN = 5;
var ADVIT_ID_NYURYOKU_YMD = 6;
var ADVIT_ID_RINTANA_KANRI_NO = 7;
var ADVIT_ID_LOSS_KANRI_NO = 8;
var ADVIT_ID_BUMON_CD_BO = 9;
var ADVIT_ID_BUMON_NM = 10;
var ADVIT_ID_NYURYOKUTAN_CD = 11;
var ADVIT_ID_NYURYOKUTAN_NM = 12;
var ADVIT_ID_LOSSKEISAN_YMD = 13;
var ADVIT_ID_LOSSKEISAN_TM = 14;
var ADVIT_ID_HINSYU_SITEI_FLG = 15;
var ADVIT_ID_HINSYU_CD = 16;
var ADVIT_ID_BTNHINSYU_CD = 17;
var ADVIT_ID_HINSYU_RYAKU_NM = 18;
var ADVIT_ID_BURANDO_SITEI_FLG = 19;
var ADVIT_ID_BURANDO_CD = 20;
var ADVIT_ID_BTNBURANDO_CD = 21;
var ADVIT_ID_BURANDO_NM = 22;
var ADVIT_ID_BURANDO_CD1 = 23;
var ADVIT_ID_BTNBURANDO_CD1 = 24;
var ADVIT_ID_BURANDO_NM1 = 25;
var ADVIT_ID_BURANDO_CD2 = 26;
var ADVIT_ID_BTNBURANDO_CD2 = 27;
var ADVIT_ID_BURANDO_NM2 = 28;
var ADVIT_ID_BURANDO_CD3 = 29;
var ADVIT_ID_BTNBURANDO_CD3 = 30;
var ADVIT_ID_BURANDO_NM3 = 31;
var ADVIT_ID_BURANDO_CD4 = 32;
var ADVIT_ID_BTNBURANDO_CD4 = 33;
var ADVIT_ID_BURANDO_NM4 = 34;
var ADVIT_ID_BURANDO_CD5 = 35;
var ADVIT_ID_BTNBURANDO_CD5 = 36;
var ADVIT_ID_BURANDO_NM5 = 37;
var ADVIT_ID_BURANDO_CD6 = 38;
var ADVIT_ID_BTNBURANDO_CD6 = 39;
var ADVIT_ID_BURANDO_NM6 = 40;
var ADVIT_ID_BURANDO_CD7 = 41;
var ADVIT_ID_BTNBURANDO_CD7 = 42;
var ADVIT_ID_BURANDO_NM7 = 43;
var ADVIT_ID_BTNROWINS = 44;
var ADVIT_ID_BTNSIZSTK = 45;
var ADVIT_ID_BTNROWDEL = 46;
var ADVIT_ID_PGR = 47;
var ADVIT_ID_M1ROWNO = 48;
var ADVIT_ID_M1HINSYU_RYAKU_NM = 49;
var ADVIT_ID_M1BURANDO_NM = 50;
var ADVIT_ID_M1JISYA_HBN = 51;
var ADVIT_ID_M1MAKER_HBN = 52;
var ADVIT_ID_M1SYONMK = 53;
var ADVIT_ID_M1IRO_NM = 54;
var ADVIT_ID_M1SIZE_NM = 55;
var ADVIT_ID_M1SCAN_CD = 56;
var ADVIT_ID_M1HYOKA_TNK = 57;
var ADVIT_ID_M1TANAJITYOBO_SU = 58;
var ADVIT_ID_M1TANAJITYOBO_SU_HDN = 59;
var ADVIT_ID_M1TANAJISEKISO_SU = 60;
var ADVIT_ID_M1TANAJISEKISO_SU_HDN = 61;
var ADVIT_ID_M1JITANA_SU = 62;
var ADVIT_ID_M1JITANA_SU1_HDN = 63;
var ADVIT_ID_M1LOSS_SU = 64;
var ADVIT_ID_M1LOSS_KIN = 65;
var ADVIT_ID_M1SELECTORCHECKBOX = 66;
var ADVIT_ID_M1ENTERSYORIFLG = 67;
var ADVIT_ID_M1DTLIROKBN = 68;
var ADVIT_ID_GOKEITANAJITYOBO_SU = 69;
var ADVIT_ID_GOKEITANAJISEKISO_SU = 70;
var ADVIT_ID_GOKEIJITANA_SU = 71;
var ADVIT_ID_GOKEILOSS_SU = 72;
var ADVIT_ID_GOKEILOSS_KIN = 73;
var ADVIT_ID_BTNENTER = 74;

var ADVIT_ID = new Array(
	"Btnback","Head_tenpo_cd","Head_tenpo_nm","Modeno","Stkmodeno"
	,"Tenpo_cd_hdn","Nyuryoku_ymd","Rintana_kanri_no","Loss_kanri_no","Bumon_cd_bo"
	,"Bumon_nm","Nyuryokutan_cd","Nyuryokutan_nm","Losskeisan_ymd","Losskeisan_tm"
	,"Hinsyu_sitei_flg","Hinsyu_cd","Btnhinsyu_cd","Hinsyu_ryaku_nm","Burando_sitei_flg"
	,"Burando_cd","Btnburando_cd","Burando_nm","Burando_cd1","Btnburando_cd1"
	,"Burando_nm1","Burando_cd2","Btnburando_cd2","Burando_nm2","Burando_cd3"
	,"Btnburando_cd3","Burando_nm3","Burando_cd4","Btnburando_cd4","Burando_nm4"
	,"Burando_cd5","Btnburando_cd5","Burando_nm5","Burando_cd6","Btnburando_cd6"
	,"Burando_nm6","Burando_cd7","Btnburando_cd7","Burando_nm7","Btnrowins"
	,"Btnsizstk","Btnrowdel","Pgr","M1rowno","M1hinsyu_ryaku_nm"
	,"M1burando_nm","M1jisya_hbn","M1maker_hbn","M1syonmk","M1iro_nm"
	,"M1size_nm","M1scan_cd","M1hyoka_tnk","M1tanajityobo_su","M1tanajityobo_su_hdn"
	,"M1tanajisekiso_su","M1tanajisekiso_su_hdn","M1jitana_su","M1jitana_su1_hdn","M1loss_su"
	,"M1loss_kin","M1selectorcheckbox","M1entersyoriflg","M1dtlirokbn","Gokeitanajityobo_su"
	,"Gokeitanajisekiso_su","Gokeijitana_su","Gokeiloss_su","Gokeiloss_kin","Btnenter"
);
var ADVIT_NAME = new Array(
	"戻るボタン","ヘッダ店舗コード","ヘッダ店舗名","モードNO","選択モードNO"
	,"店舗コード隠し","入力日","臨棚管理№","ロス管理№","部門コード"
	,"部門名","入力担当者コード","入力担当者名称","ロス計算日","ロス計算時間"
	,"品種指定フラグ","品種コード","品種コードボタン","品種略名称","ブランド指定フラグ"
	,"ブランドコード","ブランドコードボタン","ブランド名","ブランドコード1","ブランドコード1ボタン"
	,"ブランド名1","ブランドコード2","ブランドコード2ボタン","ブランド名2","ブランドコード3"
	,"ブランドコード3ボタン","ブランド名3","ブランドコード4","ブランドコード4ボタン","ブランド名4"
	,"ブランドコード5","ブランドコード5ボタン","ブランド名5","ブランドコード6","ブランドコード6ボタン"
	,"ブランド名6","ブランドコード7","ブランドコード7ボタン","ブランド名7","行追加ボタン"
	,"サイズ選択ボタン","行削除ボタン","ページャ","Ｍ１行NO","Ｍ１品種略名称"
	,"Ｍ１ブランド名","Ｍ１自社品番","Ｍ１メーカー品番","Ｍ１商品名(カナ)","Ｍ１色"
	,"Ｍ１サイズ","Ｍ１スキャンコード","Ｍ１評価単価","Ｍ１棚時帳簿数","Ｍ１棚時帳簿数（隠し)"
	,"Ｍ１棚時積送数","Ｍ１棚時積送数(隠し)","Ｍ１実棚数","Ｍ１実棚数（隠し）","Ｍ１ロス数"
	,"Ｍ１ロス金額","Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)","合計棚時帳簿数"
	,"合計棚時積送数","合計実棚数","合計ロス数","合計ロス金額","確定ボタン"
);
var ADVIT_ATTRIBUTE = new Array(
	"B","SG","SN4","NA","NA"
	,"SG","D","NA","NA","SG"
	,"SN4","SG","SN4","D","D"
	,"SN5","SG","B","SN4","SN5"
	,"SG","B","SN9","SG","B"
	,"SN9","SG","B","SN9","SG"
	,"B","SN9","SG","B","SN9"
	,"SG","B","SN9","SG","B"
	,"SN9","SG","B","SN9","B"
	,"B","B","B","NA","SN4"
	,"SN9","SG","SN9","SN9","SN9"
	,"SN9","SG","NC","NC","NC"
	,"NC","NC","NA","NC","NC"
	,"NC","NA","NA","NA","NC"
	,"NC","NC","NC","NC","B"
);
var ADVIT_LENGTH = new Array(
	0,4,15,2,2
	,4,0,6,6,3
	,15,7,12,0,0
	,1,2,0,15,1
	,6,0,20,6,0
	,20,6,0,20,6
	,0,20,6,0,20
	,6,0,20,6,0
	,20,6,0,20,0
	,0,0,0,4,15
	,20,8,30,30,10
	,4,18,7,7,7
	,7,7,4,4,7
	,9,1,1,2,9
	,9,9,9,11,0
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
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
);
var ADVIT_TYPE = new Array(
	"BTS","TXR","TXR","HDN","HDN"
	,"HDN","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"RDO","TXT","BTN","TXR","RDO"
	,"TXT","BTN","TXR","TXT","BTN"
	,"TXR","TXT","BTN","TXR","TXT"
	,"BTN","TXR","TXT","BTN","TXR"
	,"TXT","BTN","TXR","TXT","BTN"
	,"TXR","TXT","BTN","TXR","BTS"
	,"BTS","BTS","LNS","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXT","TXR","TXR","HDN"
	,"TXR","HDN","TXT","HDN","TXR"
	,"TXR","CHK","HDN","HDN","TXR"
	,"TXR","TXR","TXR","TXR","BTS"
);
var ADVIT_FORMAT = new Array(
	"00","10","00","11","11"
	,"10","52","10","10","10"
	,"00","10","00","52","56"
	,"00","10","00","00","00"
	,"10","00","00","10","00"
	,"00","10","00","00","10"
	,"00","00","10","00","00"
	,"10","00","00","10","00"
	,"00","10","00","00","00"
	,"00","00","00","11","00"
	,"00","10","00","00","00"
	,"00","00","12","12","12"
	,"12","12","12","12","12"
	,"12","11","11","11","12"
	,"12","12","12","12","00"
);
var ADVIT_CODEID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","C_HINSYU_CD","",""
	,"","C_BURANDO_CD","","","C_BURANDO_CD"
	,"","","C_BURANDO_CD","",""
	,"C_BURANDO_CD","","","C_BURANDO_CD",""
	,"","C_BURANDO_CD","","","C_BURANDO_CD"
	,"","","C_BURANDO_CD","",""
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
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1",""
	,"","","","",""
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
	,0,0,0,0,0
	,0,0,1,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,1
);
var ADVIT_IMEMODE = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,3,0,0,0
	,3,0,0,3,0
	,0,3,0,0,3
	,0,0,3,0,0
	,3,0,0,3,0
	,0,3,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,3,0,0,0
	,0,0,3,0,0
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
	,0,1,0,0,0
	,1,0,0,1,0
	,0,1,0,0,1
	,0,0,1,0,0
	,1,0,0,1,0
	,0,1,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,1,0,0,0
	,0,0,1,0,0
	,0,0,0,0,0
	,0,0,0,0,0
);
var ADVIT_CONDID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"HINSYU_SITEI_FLG","","","","BURANDO_SITEI_FLG"
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
);
var ADVIT_ACTIONID = new Array(
	"FRM","","","",""
	,"","","","",""
	,"","","","",""
	,"","","COD","",""
	,"","COD","","","COD"
	,"","","COD","",""
	,"COD","","","COD",""
	,"","COD","","","COD"
	,"","","COD","","MADD"
	,"FRM","FRM","PGN","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","","FRM"
);
var ADVIT_ACTIONFORMID = new Array(
	"TJ190F01","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"TJ190F02","TJ190F02","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","","TJ190F01"
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
	,"","","","","M1"
	,"","","M1","",""
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
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
);
var ADVIT_CAPTION = new Array(
	"","","","",""
	,"","入力日","臨棚管理No","ロス管理No","部門"
	,"","入力担当者","","ロス計算日",""
	,"","品種","","",""
	,"ブランド1","","","ブランド2",""
	,"","ブランド3","","","ブランド4"
	,"","","ブランド5","",""
	,"ブランド6","","","ブランド7",""
	,"","ブランド8","","",""
	,"","","","No.","品種"
	,"ブランド","自社品番","メーカー品番","商品名","色"
	,"サイズ","スキャンコード","評価単価","棚時帳簿数",""
	,"棚時積送数","","実棚数","","ロス数"
	,"ロス金額","","","","合計"
	,"","","","","確定"
);

