var ADVIT_FORMID = "TG040F02";
var ADVIT_TARGETPGID = "tg040p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tg040f02.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,20,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,37,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_BTNBACK = 0;
var ADVIT_ID_HEAD_TENPO_CD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_STOCK_NO = 3;
var ADVIT_ID_YMD = 4;
var ADVIT_ID_TM = 5;
var ADVIT_ID_NYURYOKUTAN_CD = 6;
var ADVIT_ID_NYURYOKUTAN_NM = 7;
var ADVIT_ID_BTNZENSTK = 8;
var ADVIT_ID_BTNZENKJO = 9;
var ADVIT_ID_BTNROWINS = 10;
var ADVIT_ID_BTNPAGEINS = 11;
var ADVIT_ID_BTNSIZSTK = 12;
var ADVIT_ID_BTNROWDEL = 13;
var ADVIT_ID_BTNSEAL = 14;
var ADVIT_ID_BTNLABEL_CD = 15;
var ADVIT_ID_LABEL_CD = 16;
var ADVIT_ID_LABEL_IP = 17;
var ADVIT_ID_LABEL_NM = 18;
var ADVIT_ID_PGR = 19;
var ADVIT_ID_M1ROWNO = 20;
var ADVIT_ID_M1BUMON_CD = 21;
var ADVIT_ID_M1BUMONKANA_NM = 22;
var ADVIT_ID_M1HINSYU_RYAKU_NM = 23;
var ADVIT_ID_M1BURANDO_NM = 24;
var ADVIT_ID_M1JISYA_HBN = 25;
var ADVIT_ID_M1MAKER_HBN = 26;
var ADVIT_ID_M1SYONMK = 27;
var ADVIT_ID_M1SCAN_CD = 28;
var ADVIT_ID_M1HANBAIKANRYO_YMD = 29;
var ADVIT_ID_M1IRO_NM = 30;
var ADVIT_ID_M1SIZE_NM = 31;
var ADVIT_ID_M1SURYO = 32;
var ADVIT_ID_M1SURYO_HDN = 33;
var ADVIT_ID_M1HINSYU_CD = 34;
var ADVIT_ID_M1SELECTORCHECKBOX = 35;
var ADVIT_ID_M1ENTERSYORIFLG = 36;
var ADVIT_ID_M1DTLIROKBN = 37;
var ADVIT_ID_STKMODENO = 38;
var ADVIT_ID_GOKEI_SURYO = 39;
var ADVIT_ID_BTNENTER = 40;

var ADVIT_ID = new Array(
	"Btnback","Head_tenpo_cd","Head_tenpo_nm","Stock_no","Ymd"
	,"Tm","Nyuryokutan_cd","Nyuryokutan_nm","Btnzenstk","Btnzenkjo"
	,"Btnrowins","Btnpageins","Btnsizstk","Btnrowdel","Btnseal"
	,"Btnlabel_cd","Label_cd","Label_ip","Label_nm","Pgr"
	,"M1rowno","M1bumon_cd","M1bumonkana_nm","M1hinsyu_ryaku_nm","M1burando_nm"
	,"M1jisya_hbn","M1maker_hbn","M1syonmk","M1scan_cd","M1hanbaikanryo_ymd"
	,"M1iro_nm","M1size_nm","M1suryo","M1suryo_hdn","M1hinsyu_cd"
	,"M1selectorcheckbox","M1entersyoriflg","M1dtlirokbn","Stkmodeno","Gokei_suryo"
	,"Btnenter"
);
var ADVIT_NAME = new Array(
	"戻るボタン","ヘッダ店舗コード","ヘッダ店舗名","ストック№","日付"
	,"時間","入力担当者コード","入力担当者名称","全選択ボタン","全解除ボタン"
	,"行追加ボタン","ページ追加ボタン","サイズ選択ボタン","行削除ボタン","シール発行ボタン"
	,"ラベル発行機コードボタン","ラベル発行機ＩＤ","ラベル発行機ＩＰ","ラベル発行機名","ページャ"
	,"Ｍ１行NO","Ｍ１部門コード","Ｍ１部門カナ名","Ｍ１品種略名称","Ｍ１ブランド名"
	,"Ｍ１自社品番","Ｍ１メーカー品番","Ｍ１商品名(カナ)","Ｍ１スキャンコード","Ｍ１販売完了日"
	,"Ｍ１色","Ｍ１サイズ","Ｍ１数量","Ｍ１数量_隠し","Ｍ１品種コード"
	,"Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)","選択モードNO","合計数量"
	,"確定ボタン"
);
var ADVIT_ATTRIBUTE = new Array(
	"B","SG","SN4","NA","D"
	,"D","SG","SN5","B","B"
	,"B","B","B","B","B"
	,"B","SN4","SG","SN4","B"
	,"NA","SG","SN9","SN4","SN9"
	,"SG","SN9","SN9","SG","D"
	,"SN9","SN9","NA","NA","NA"
	,"NA","NA","NA","NA","NA"
	,"B"
);
var ADVIT_LENGTH = new Array(
	0,4,15,10,0
	,0,7,12,0,0
	,0,0,0,0,0
	,0,7,12,10,0
	,4,3,30,15,20
	,8,30,30,18,0
	,10,4,4,4,2
	,1,1,2,2,6
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
	,0
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
	,0
);
var ADVIT_TYPE = new Array(
	"BTS","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","BTS","BTS"
	,"BTS","BTS","BTS","BTS","BTS"
	,"BTN","HDN","HDN","TXR","LNS"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXT","TXR"
	,"TXR","TXR","TXT","HDN","HDN"
	,"CHK","HDN","HDN","HDN","TXR"
	,"BTS"
);
var ADVIT_FORMAT = new Array(
	"00","10","00","10","52"
	,"56","10","00","00","00"
	,"00","00","00","00","00"
	,"00","00","00","00","00"
	,"11","10","00","00","00"
	,"10","00","00","00","52"
	,"00","00","12","12","10"
	,"11","11","11","11","12"
	,"00"
);
var ADVIT_CODEID = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"C_LABEL_CD","","","",""
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
	,"CANNOTGET"
);
var ADVIT_LEVEL = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
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
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,1
);
var ADVIT_IMEMODE = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,3,0
	,0,0,3,0,0
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
	,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,1,0
	,0,0,1,0,0
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
	,""
);
var ADVIT_ACTIONID = new Array(
	"FRM","","","",""
	,"","","","FRM","FRM"
	,"MADD","MINSX","FRM","FRM","FRM"
	,"COD","","","","PGN"
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"FRM"
);
var ADVIT_ACTIONFORMID = new Array(
	"TG040F01","","","",""
	,"","","","TG040F02","TG040F02"
	,"","","TG040F02","TG040F02","TG040F02"
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"TG040F01"
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","M1","M1"
	,"M1","M1","","",""
	,"","","","","M1"
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
	,""
);
var ADVIT_CAPTION = new Array(
	"","","","ストックNo","日付"
	,"時間","入力担当者","","",""
	,"","","","",""
	,"","","","",""
	,"No.","部門","部門","品種","ブランド"
	,"自社品番","メーカー品番","商品名","スキャンコード","販売完了日"
	,"色","サイズ","数量","数量",""
	,"","","","","合計"
	,"確定"
);

