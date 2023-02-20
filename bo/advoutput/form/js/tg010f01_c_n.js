var ADVIT_FORMID = "TG010F01";
var ADVIT_TARGETPGID = "tg010p01";
var ADVIT_FORMACTION = new Array(1);
ADVIT_FORMACTION[0] = "tg010f01.aspx";

var ADVIT_M_PATTERN = new Array(0,2,0,0,0,0,0,0,0,0);
var ADVIT_M_STARTIDX = new Array(-1,35,-1,-1,-1,-1,-1,-1,-1,-1);
var ADVIT_M_LASTIDX = new Array(-1,62,-1,-1,-1,-1,-1,-1,-1,-1);

var ADVIT_ID_HEAD_TENPO_CD = 0;
var ADVIT_ID_BTNHEADTENPOCD = 1;
var ADVIT_ID_HEAD_TENPO_NM = 2;
var ADVIT_ID_BTNMODESCANCD = 3;
var ADVIT_ID_BTNMODEJISHAHINBAN = 4;
var ADVIT_ID_BTNMODESONOTA = 5;
var ADVIT_ID_MODENO = 6;
var ADVIT_ID_STKMODENO = 7;
var ADVIT_ID_OLD_JISYA_HBN = 8;
var ADVIT_ID_OLD_JISYA_HBN2 = 9;
var ADVIT_ID_OLD_JISYA_HBN3 = 10;
var ADVIT_ID_OLD_JISYA_HBN4 = 11;
var ADVIT_ID_OLD_JISYA_HBN5 = 12;
var ADVIT_ID_BUMON_CD = 13;
var ADVIT_ID_BTNBUMON_CD = 14;
var ADVIT_ID_BUMON_NM = 15;
var ADVIT_ID_HINSYU_CD = 16;
var ADVIT_ID_BTNHINSYU_CD = 17;
var ADVIT_ID_HINSYU_RYAKU_NM = 18;
var ADVIT_ID_BURANDO_CD = 19;
var ADVIT_ID_BTNBURANDO_CD = 20;
var ADVIT_ID_BURANDO_NM = 21;
var ADVIT_ID_BTNINSERT = 22;
var ADVIT_ID_SEARCHCNT = 23;
var ADVIT_ID_BTNSEARCH = 24;
var ADVIT_ID_BTNPAGEINS = 25;
var ADVIT_ID_BTNSIZSTK = 26;
var ADVIT_ID_BTNROWDEL = 27;
var ADVIT_ID_SYUTSURYOKU_SEAL = 28;
var ADVIT_ID_BTNSEAL = 29;
var ADVIT_ID_BTNLABEL_CD = 30;
var ADVIT_ID_LABEL_CD = 31;
var ADVIT_ID_LABEL_IP = 32;
var ADVIT_ID_LABEL_NM = 33;
var ADVIT_ID_PGR = 34;
var ADVIT_ID_M1ROWNO = 35;
var ADVIT_ID_M1BUMON_CD = 36;
var ADVIT_ID_M1BUMONKANA_NM = 37;
var ADVIT_ID_M1HINSYU_CD = 38;
var ADVIT_ID_M1HINSYU_RYAKU_NM = 39;
var ADVIT_ID_M1BURANDO_NM = 40;
var ADVIT_ID_M1JISYA_HBN = 41;
var ADVIT_ID_M1MAKER_HBN = 42;
var ADVIT_ID_M1SYONMK = 43;
var ADVIT_ID_M1IRO_NM = 44;
var ADVIT_ID_M1SIZE_NM = 45;
var ADVIT_ID_M1HANBAIKANRYO_YMD = 46;
var ADVIT_ID_M1SCAN_CD = 47;
var ADVIT_ID_M1BAIHENKAISI_YMD = 48;
var ADVIT_ID_M1SIJIBAIKA_TNK = 49;
var ADVIT_ID_M1SAISINBAIKA_TNK = 50;
var ADVIT_ID_M1MAISU = 51;
var ADVIT_ID_M1ITEMKBN = 52;
var ADVIT_ID_M1SIIRE_KB = 53;
var ADVIT_ID_M1TYOTATSU_KB = 54;
var ADVIT_ID_M1MAKERKAKAKU_TNK = 55;
var ADVIT_ID_M1BAIKA_ZEI = 56;
var ADVIT_ID_M1BURANDO_CD = 57;
var ADVIT_ID_M1BUMON_NM = 58;
var ADVIT_ID_M1SIIRESAKI_CD_BO1 = 59;
var ADVIT_ID_M1SELECTORCHECKBOX = 60;
var ADVIT_ID_M1ENTERSYORIFLG = 61;
var ADVIT_ID_M1DTLIROKBN = 62;

var ADVIT_ID = new Array(
	"Head_tenpo_cd","Btnheadtenpocd","Head_tenpo_nm","Btnmodescancd","Btnmodejishahinban"
	,"Btnmodesonota","Modeno","Stkmodeno","Old_jisya_hbn","Old_jisya_hbn2"
	,"Old_jisya_hbn3","Old_jisya_hbn4","Old_jisya_hbn5","Bumon_cd","Btnbumon_cd"
	,"Bumon_nm","Hinsyu_cd","Btnhinsyu_cd","Hinsyu_ryaku_nm","Burando_cd"
	,"Btnburando_cd","Burando_nm","Btninsert","Searchcnt","Btnsearch"
	,"Btnpageins","Btnsizstk","Btnrowdel","Syutsuryoku_seal","Btnseal"
	,"Btnlabel_cd","Label_cd","Label_ip","Label_nm","Pgr"
	,"M1rowno","M1bumon_cd","M1bumonkana_nm","M1hinsyu_cd","M1hinsyu_ryaku_nm"
	,"M1burando_nm","M1jisya_hbn","M1maker_hbn","M1syonmk","M1iro_nm"
	,"M1size_nm","M1hanbaikanryo_ymd","M1scan_cd","M1baihenkaisi_ymd","M1sijibaika_tnk"
	,"M1saisinbaika_tnk","M1maisu","M1itemkbn","M1siire_kb","M1tyotatsu_kb"
	,"M1makerkakaku_tnk","M1baika_zei","M1burando_cd","M1bumon_nm","M1siiresaki_cd_bo1"
	,"M1selectorcheckbox","M1entersyoriflg","M1dtlirokbn"
);
var ADVIT_NAME = new Array(
	"ヘッダ店舗コード","ヘッダ店舗コードボタン","ヘッダ店舗名","モードスキャンコードボタン","モード自社品番ボタン"
	,"モードその他ボタン","モードNO","選択モードNO","旧自社品番","旧自社品番２"
	,"旧自社品番３","旧自社品番４","旧自社品番５","部門コード","部門コードボタン"
	,"部門名","品種コード","品種コードボタン","品種略名称","ブランドコード"
	,"ブランドコードボタン","ブランド名","新規作成ボタン","検索件数","検索ボタン"
	,"ページ追加ボタン","サイズ選択ボタン","行削除ボタン","出力シール","シール発行ボタン"
	,"ラベル発行機コードボタン","ラベル発行機ＩＤ","ラベル発行機ＩＰ","ラベル発行機名","ページャ"
	,"Ｍ１行NO","Ｍ１部門コード","Ｍ１部門カナ名","Ｍ１品種コード","Ｍ１品種略名称"
	,"Ｍ１ブランド名","Ｍ１自社品番","Ｍ１メーカー品番","Ｍ１商品名(カナ)","Ｍ１色"
	,"Ｍ１サイズ","Ｍ１販売完了日","Ｍ１スキャンコード","Ｍ１売変開始日","Ｍ１指示売価"
	,"Ｍ１最新売価","Ｍ１枚数","Ｍ１商品区分(隠し)","Ｍ１仕入区分(隠し)","Ｍ１調達区分(隠し)"
	,"Ｍ１メーカー希望小売価格（隠し）","Ｍ１税込価格（隠し）","Ｍ１ブランドコード（隠し）","Ｍ１部門名全角（隠し）","Ｍ１仕入先コード（隠し）"
	,"Ｍ１選択フラグ(隠し)","Ｍ１確定処理フラグ(隠し)","Ｍ１明細色区分(隠し)"
);
var ADVIT_ATTRIBUTE = new Array(
	"SG","B","SN4","B","B"
	,"B","NA","NA","SG","SG"
	,"SG","SG","SG","SG","B"
	,"SN4","SG","B","SN4","SG"
	,"B","SN9","B","NA","B"
	,"B","B","B","SN5","B"
	,"B","SN4","SG","SN4","B"
	,"NA","SG","SN9","SG","SN4"
	,"SN9","SG","SN9","SN9","SN9"
	,"SN9","D","SG","D","NA"
	,"NA","NA","NA","NA","NA"
	,"NA","NA","NA","SN4","NA"
	,"NA","NA","NA"
);
var ADVIT_LENGTH = new Array(
	4,0,15,0,0
	,0,2,2,10,10
	,10,10,10,3,0
	,15,2,0,15,6
	,0,20,0,4,0
	,0,0,0,1,0
	,0,7,12,10,0
	,4,3,30,2,15
	,20,8,30,30,10
	,4,0,18,0,7
	,7,3,1,1,2
	,8,8,6,15,4
	,1,1,2
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
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0
);
var ADVIT_TYPE = new Array(
	"TXT","BTN","TXR","LNK","LNK"
	,"LNK","HDN","HDN","TXT","TXT"
	,"TXT","TXT","TXT","TXT","BTN"
	,"TXR","TXT","BTN","TXR","TXT"
	,"BTN","TXR","BTS","TXR","BTS"
	,"BTS","BTS","BTS","RDO","BTS"
	,"BTN","HDN","HDN","TXR","LNS"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXR","TXR","TXR"
	,"TXR","TXR","TXT","TXR","TXR"
	,"TXR","TXT","HDN","HDN","HDN"
	,"HDN","HDN","HDN","HDN","HDN"
	,"CHK","HDN","HDN"
);
var ADVIT_FORMAT = new Array(
	"10","00","00","00","00"
	,"00","11","11","00","00"
	,"00","00","00","10","00"
	,"00","10","00","00","10"
	,"00","00","00","12","00"
	,"00","00","00","00","00"
	,"00","00","00","00","00"
	,"11","10","00","10","00"
	,"00","10","00","00","00"
	,"00","52","00","52","12"
	,"12","12","10","10","10"
	,"11","11","10","00","10"
	,"11","11","11"
);
var ADVIT_CODEID = new Array(
	"","C_TENPO_CD","","",""
	,"","","","",""
	,"","","","","C_BUMON_CD"
	,"","","C_HINSYU_CD","",""
	,"C_BURANDO_CD","","","",""
	,"","","","",""
	,"C_LABEL_CD","","","",""
	,"","","","",""
	,"","","","",""
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
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1","M1","M1"
	,"M1","M1","M1"
);
var ADVIT_HLCHK = new Array(
	0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,1,0,1
	,0,1,0,0,1
	,0,0,0,0,1
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0
);
var ADVIT_IMEMODE = new Array(
	3,0,0,0,0
	,0,0,0,3,3
	,3,3,3,3,0
	,0,3,0,0,3
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,3,0,0
	,0,3,0,0,0
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
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0
);
var ADVIT_MAXLENGTHMODE = new Array(
	1,0,0,0,0
	,0,0,0,1,1
	,1,1,1,1,0
	,0,1,0,0,1
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,0,0,0
	,0,0,1,0,0
	,0,1,0,0,0
	,0,0,0,0,0
	,0,0,0
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
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","",""
);
var ADVIT_ACTIONID = new Array(
	"","COD","","SPT","SPT"
	,"SPT","","","",""
	,"","","","","COD"
	,"","","COD","",""
	,"COD","","FRM","","FRM"
	,"MINSX","FRM","FRM","","FRM"
	,"COD","","","","PGN"
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","",""
);
var ADVIT_ACTIONFORMID = new Array(
	"","","","TG010F01","TG010F01"
	,"TG010F01","","","",""
	,"","","","",""
	,"","","","",""
	,"","","TG010F01","","TG010F01"
	,"","TG010F01","TG010F01","","TG010F01"
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","",""
);
var ADVIT_ACTPARAMETER = new Array(
	"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"M1","","","",""
	,"","","","","M1"
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
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
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","","","",""
	,"","",""
);
var ADVIT_CAPTION = new Array(
	"店舗","","","スキャンコード","自社品番"
	,"その他","","","自社品番",""
	,"","","","部門",""
	,"","品種","","","ブランド"
	,"","ブランド","新規作成","","検索"
	,"","","","出力シール",""
	,"","","","",""
	,"No.","部門","部門","品種",""
	,"ブランド","自社品番","メーカー品番","商品名","色"
	,"サイズ","販売完了日","スキャンコード","売変開始日","指示売価"
	,"最新売価","枚数","","",""
	,"","","","",""
	,"","",""
);

