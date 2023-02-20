var ADVIT_FORMID = "TJ040F02";
var ADVIT_TARGETPGID = "tj040p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tj040f02.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,23,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,41,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_BTNBACK = 0;
var ADVIT_ID_HEAD_TENPO_CD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_MODENO = 3;
var ADVIT_ID_STKMODENO = 4;
var ADVIT_ID_FACE_NO = 5;
var ADVIT_ID_TANA_DAN = 6;
var ADVIT_ID_KAI_SU = 7;
var ADVIT_ID_TENSUTANAOROSI_SU = 8;
var ADVIT_ID_TEISEI_SURYO = 9;
var ADVIT_ID_TEISEI_SURYO_HDN = 10;
var ADVIT_ID_GOKEI_SURYO = 11;
var ADVIT_ID_TENPO_GYOSYA_KB = 12;
var ADVIT_ID_TENPO_GYOSYA_NM = 13;
var ADVIT_ID_NYURYOKUTAN_CD = 14;
var ADVIT_ID_NYURYOKUTAN_NM = 15;
var ADVIT_ID_TEISEITAN_CD = 16;
var ADVIT_ID_TEISEITAN_NM = 17;
var ADVIT_ID_NYURYOKU_YMD = 18;
var ADVIT_ID_SOSIN_YMD = 19;
var ADVIT_ID_RIYU_CD = 20;
var ADVIT_ID_BTNPRINT = 21;
var ADVIT_ID_PGR = 22;
var ADVIT_ID_M1ROWNO = 23;
var ADVIT_ID_M1BUMON_CD = 24;
var ADVIT_ID_M1BUMONKANA_NM = 25;
var ADVIT_ID_M1HINSYU_RYAKU_NM = 26;
var ADVIT_ID_M1BURANDO_NM = 27;
var ADVIT_ID_M1JISYA_HBN = 28;
var ADVIT_ID_M1MAKER_HBN = 29;
var ADVIT_ID_M1SYONMK = 30;
var ADVIT_ID_M1IRO_NM = 31;
var ADVIT_ID_M1SIZE_NM = 32;
var ADVIT_ID_M1SCAN_CD = 33;
var ADVIT_ID_M1HYOJI_SYOHIN_CD = 34;
var ADVIT_ID_M1SCAN_SU = 35;
var ADVIT_ID_M1TEISEI_SURYO = 36;
var ADVIT_ID_M1TEISEI_SURYO_HDN = 37;
var ADVIT_ID_M1GOKEI_SURYO = 38;
var ADVIT_ID_M1SELECTORCHECKBOX = 39;
var ADVIT_ID_M1ENTERSYORIFLG = 40;
var ADVIT_ID_M1DTLIROKBN = 41;
var ADVIT_ID_GOKEISCAN_SU = 42;
var ADVIT_ID_GOKEITEISEI_SURYO = 43;
var ADVIT_ID_ALL_GOKEI_SURYO = 44;
var ADVIT_ID_BTNENTER = 45;

var ADVIT_ID = new Array(
	"Btnback","Head_tenpo_cd","Head_tenpo_nm","Modeno","Stkmodeno"
	,"Face_no","Tana_dan","Kai_su","Tensutanaorosi_su","Teisei_suryo"
	,"Teisei_suryo_hdn","Gokei_suryo","Tenpo_gyosya_kb","Tenpo_gyosya_nm","Nyuryokutan_cd"
	,"Nyuryokutan_nm","Teiseitan_cd","Teiseitan_nm","Nyuryoku_ymd","Sosin_ymd"
	,"Riyu_cd","Btnprint","Pgr","M1rowno","M1bumon_cd"
	,"M1bumonkana_nm","M1hinsyu_ryaku_nm","M1burando_nm","M1jisya_hbn","M1maker_hbn"
	,"M1syonmk","M1iro_nm","M1size_nm","M1scan_cd","M1hyoji_syohin_cd"
	,"M1scan_su","M1teisei_suryo","M1teisei_suryo_hdn","M1gokei_suryo","M1selectorcheckbox"
	,"M1entersyoriflg","M1dtlirokbn","Gokeiscan_su","Gokeiteisei_suryo","All_gokei_suryo"
	,"Btnenter"
);
var ADVIT_NAME = new Array(
	"戻るボタン","ヘッダ店舗コード","ヘッダ店舗名","モードNO","選択モードNO"
	,"フェイス№","棚段","回数","点数棚卸数量","訂正数量"
	,"訂正数量(隠し)","合計数量","店舗／業者区分","店舗／業者名","入力担当者コード"
	,"入力担当者名称","訂正担当者コード","訂正担当者名称","入力日","送信日"
	,"理由コード","印刷ボタン","ページャ","Ｍ１行NO","Ｍ１部門コード"
	,"Ｍ１部門カナ名","Ｍ１品種略名称","Ｍ１ブランド名","Ｍ１自社品番","Ｍ１メーカー品番"
	,"Ｍ１商品名(カナ)","Ｍ１色","Ｍ１サイズ","Ｍ１スキャンコード","Ｍ１表示用商品コード"
	,"Ｍ１スキャン数量","Ｍ１訂正数量","Ｍ１訂正数量(隠し)","Ｍ１合計数量","Ｍ１選択フラグ(隠し)"
	,"Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)","合計スキャン数量","合計訂正数量","総合計数量"
	,"確定ボタン"
);
var ADVIT_ATTRIBUTE = new Array(
	"B","SG","SN4","NA","NA"
	,"SG","NA","NA","NA","NC"
	,"NA","NA","NA","SN4","SG"
	,"SN4","SG","SN4","D","D"
	,"SN5","B","B","NA","SG"
	,"SN9","SN4","SN9","SG","SN9"
	,"SN9","SN9","SN9","SG","SN9"
	,"NA","NC","NA","NA","NA"
	,"NA","NA","NA","NA","NA"
	,"B"
);
var ADVIT_LENGTH = new Array(
	0,4,15,2,2
	,5,2,2,6,6
	,6,6,1,2,7
	,12,7,12,0,0
	,3,0,0,4,3
	,30,15,20,8,30
	,30,10,4,18,21
	,6,4,4,6,1
	,1,2,6,6,6
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
	,0
);
var ADVIT_REQUIREDFLG = new Array(
	0,0,0,0,0
	,1,1,0,0,0
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
	"BTS","TXR","TXR","HDN","HDN"
	,"TXT","TXT","TXR","TXR","TXT"
	,"HDN","TXR","HDN","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"DRL","BTS","LNS","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXT","TXR"
	,"TXR","TXT","HDN","TXR","CHK"
	,"HDN","HDN","TXR","TXR","TXR"
	,"BTS"
);
var ADVIT_FORMAT = new Array(
	"00","10","00","11","11"
	,"10","11","11","12","12"
	,"12","12","11","00","10"
	,"00","10","00","52","52"
	,"00","00","00","11","10"
	,"00","00","00","10","00"
	,"00","00","00","00","00"
	,"12","12","12","12","11"
	,"11","11","12","12","12"
	,"00"
);
var ADVIT_CODEID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"C_RIYU_CD","","","",""
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
	,"CANNOTGET"
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","","",""
	,""
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,1,1,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,1
);
var ADVIT_IMEMODE = new Array(
	0,0,0,0,0
	,3,3,0,0,3
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,3,0
	,0,3,0,0,0
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
	,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	0,0,0,0,0
	,1,1,0,0,1
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,1,0
	,0,1,0,0,0
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
	,"","","","",""
	,"","","","",""
	,""
);
var ADVIT_ACTIONID = new Array(
	"FRM","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"COD","FRM","PGN","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"FRM"
);
var ADVIT_ACTIONFORMID = new Array(
	"TJ040F01","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","TJ040F02","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"TJ040F01"
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","M1","",""
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
	,""
);
var ADVIT_CAPTION = new Array(
	"","","","",""
	,"フェイスNo","棚段","回数","点数棚卸数量","訂正数量"
	,"","合計数量","","店舗／業者","入力担当者"
	,"","訂正担当者","","入力日","送信日"
	,"棚卸理由","","","No.","部門"
	,"","品種","ブランド","自社品番","メーカー品番"
	,"商品名","色","サイズ","スキャンコード","商品コード"
	,"ｽｷｬﾝ数量","訂正数量","","合計数量",""
	,"","","合計","",""
	,"確定"
);

