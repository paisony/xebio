//メッセージインデックス設定
var ADVMS_ID_S001=0;
var ADVMS_ID_S002=1;
var ADVMS_ID_S003=2;
var ADVMS_ID_S004=3;
var ADVMS_ID_S005=4;
var ADVMS_ID_S006=5;
var ADVMS_ID_S007=6;
var ADVMS_ID_S008=7;
var ADVMS_ID_S101=8;
var ADVMS_ID_S102=9;
var ADVMS_ID_S103=10;
var ADVMS_ID_S104=11;
var ADVMS_ID_S105=12;
var ADVMS_ID_S106=13;
var ADVMS_ID_S107=14;
var ADVMS_ID_S108=15;
var ADVMS_ID_S109=16;
var ADVMS_ID_S110=17;
var ADVMS_ID_S111=18;
var ADVMS_ID_S112=19;
var ADVMS_ID_S113=20;
var ADVMS_ID_S114=21;
var ADVMS_ID_S115=22;
var ADVMS_ID_S116=23;
var ADVMS_ID_S117=24;
var ADVMS_ID_S118=25;
var ADVMS_ID_S119=26;
var ADVMS_ID_S120=27;
var ADVMS_ID_S121=28;
var ADVMS_ID_S122=29;
var ADVMS_ID_S123=30;
var ADVMS_ID_S124=31;
var ADVMS_ID_S125=32;
var ADVMS_ID_S900=33;

//メッセージＩＤ
var ADVMS_ID  = new Array("S001","S002","S003","S004","S005","S006","S007","S008","S101","S102","S103","S104","S105","S106","S107","S108","S109","S110","S111","S112","S113","S114","S115","S116","S117","S118","S119","S120","S121","S122","S123","S124","S125","S900");

//メッセージ文字列
var ADVMS_STR  = new Array(34);
ADVMS_STR[0]="エラー個所があります。確認してください。";
ADVMS_STR[1]="無効なファンクションキーが押されました。";
ADVMS_STR[2]="前ページがありません。";
ADVMS_STR[3]="次ページがありません。";
ADVMS_STR[4]="しばらくお待ちください。";
ADVMS_STR[5]="該当コードはマスタに登録されていません。";
ADVMS_STR[6]="入力内容に誤りがあります。";
ADVMS_STR[7]="コード変換出来ない文字が含まれています。";
ADVMS_STR[8]="「%IT_CAPTION%」は%IT_LENGTH%桁以下で入力してください。";
ADVMS_STR[9]="「%IT_CAPTION%」は小数部%IT_DECIMAL%桁以下で入力してください。";
ADVMS_STR[10]="「%IT_CAPTION%」は必ず入力してください。";
ADVMS_STR[11]="「%IT_CAPTION%」は必ず入力してください。（%IT_REQUIRED%桁以上）";
ADVMS_STR[12]="「%IT_CAPTION%」は%AT_NAME%を入力してください。";
ADVMS_STR[13]="「%IT_CAPTION%」は%AT_NAME%を入力してください。（%AT_BIKO%）";
ADVMS_STR[14]="「%IT_CAPTION%」に入力したコード [%VALUE%] は見つかりませんでした。";
ADVMS_STR[15]="「%IT_CAPTION%」は日付として認識できません。";
ADVMS_STR[16]="「%IT_CAPTION%」は数値として認識できません。";
ADVMS_STR[17]="「%IT_CAPTION%」は整数部%IT_INTEGER%桁以下で入力してください。";
ADVMS_STR[18]="「%IT_CAPTION%」は%IT_REQUIRED%桁以上で入力してください。";
ADVMS_STR[19]="ログオンされていません。ログオンページにてログオンを行ってください。";
ADVMS_STR[20]="正しい画面遷移ではありません。（「お気に入り」等から直接起動されました。）";
ADVMS_STR[21]="「%IT_CAPTION%」は%IT_MAX_VAL%より小さくなければなりません。";
ADVMS_STR[22]="「%IT_CAPTION%」は%IT_MAX_VAL%以下でなければなりません。";
ADVMS_STR[23]="「%IT_CAPTION%」は%IT_MIN_VAL%より大きくなければなりません。";
ADVMS_STR[24]="「%IT_CAPTION%」は%IT_MIN_VAL%以上でなければなりません。";
ADVMS_STR[25]="「%IT_CAPTION%」は%IT_MIN_VAL%より大きく、%IT_MAX_VAL%より小さくなければなりません。";
ADVMS_STR[26]="「%IT_CAPTION%」は%IT_MIN_VAL%以上、%IT_MAX_VAL%より小さくなければなりません。";
ADVMS_STR[27]="「%IT_CAPTION%」は%IT_MIN_VAL%より大きく、%IT_MAX_VAL%以下でなければなりません。";
ADVMS_STR[28]="「%IT_CAPTION%」は%IT_MIN_VAL%以上、%IT_MAX_VAL%以下でなければなりません。";
ADVMS_STR[29]="「%IT_CAPTION%」に使用できない文字が含まれています。『%1』";
ADVMS_STR[30]="「%IT_CAPTION%」は時間として認識できません。";
ADVMS_STR[31]="「%IT_CAPTION%」に使用できない文字が含まれています。";
ADVMS_STR[32]="「%IT_CAPTION%」は%IT_MIN_VAL%以上、%IT_MAX_VAL%以下でなければなりません。";
ADVMS_STR[33]="%1";

//属性インデックス設定
var ADVAT_ID_NA=0;
var ADVAT_ID_NB=1;
var ADVAT_ID_NC=2;
var ADVAT_ID_SA=3;
var ADVAT_ID_SA1=4;
var ADVAT_ID_SA2=5;
var ADVAT_ID_SB=6;
var ADVAT_ID_SB1=7;
var ADVAT_ID_SB2=8;
var ADVAT_ID_SC=9;
var ADVAT_ID_SD=10;
var ADVAT_ID_SG=11;
var ADVAT_ID_SN1=12;
var ADVAT_ID_SN2=13;
var ADVAT_ID_SN3=14;
var ADVAT_ID_SN4=15;
var ADVAT_ID_SN5=16;
var ADVAT_ID_SP1=17;
var ADVAT_ID_SP2=18;
var ADVAT_ID_SN21=19;
var ADVAT_ID_SN22=20;
var ADVAT_ID_SN6=21;
var ADVAT_ID_SN7=22;
var ADVAT_ID_SN8=23;
var ADVAT_ID_SUTEL=24;
var ADVAT_ID_SN9=25;
var ADVAT_ID_ND=26;
var ADVAT_ID_SH=27;
var ADVAT_ID_SN10=28;

//属性ＩＤ
var ADVAT_ID  = new Array("NA","NB","NC","SA","SA1","SA2","SB","SB1","SB2","SC","SD","SG","SN1","SN2","SN3","SN4","SN5","SP1","SP2","SN21","SN22","SN6","SN7","SN8","SUTEL","SN9","ND","SH","SN10");

//属性名
var ADVAT_NAME  = new Array(29);
ADVAT_NAME[0]="数字のみ";
ADVAT_NAME[1]="数字と小数点";
ADVAT_NAME[2]="数字とマイナス記号と小数点";
ADVAT_NAME[3]="英字のみ";
ADVAT_NAME[4]="英字（大文字）のみ";
ADVAT_NAME[5]="英字（小文字）のみ";
ADVAT_NAME[6]="英数字のみ";
ADVAT_NAME[7]="英数字（大文字）のみ";
ADVAT_NAME[8]="英数字（小文字）のみ";
ADVAT_NAME[9]="英数字記号（\",%()*?_|￥'タブ以外）のみ";
ADVAT_NAME[10]="英数字記号（\",%()*?_|￥'タブ以外）のみ";
ADVAT_NAME[11]="0～9のみ";
ADVAT_NAME[12]="ひらがなのみ";
ADVAT_NAME[13]="カタカナのみ";
ADVAT_NAME[14]="全角のみ";
ADVAT_NAME[15]="\",%()*?_|￥'タブ以外";
ADVAT_NAME[16]="\",%()*?_|￥'タブ以外";
ADVAT_NAME[17]="E-mailアドレス";
ADVAT_NAME[18]="郵便番号";
ADVAT_NAME[19]="全半角混合（\",%()*?_|\\'タブ以外）";
ADVAT_NAME[20]="全半角混合（\"%?|タブ以外）";
ADVAT_NAME[21]="全角のみ";
ADVAT_NAME[22]="半角英数字カタカナのみ";
ADVAT_NAME[23]="半角カタカナのみ";
ADVAT_NAME[24]="0～9と-のみ";
ADVAT_NAME[25]="半角（'\",%()*?_|￥タブ以外）";
ADVAT_NAME[26]="数字のみ";
ADVAT_NAME[27]="ALL９NG文字列";
ADVAT_NAME[28]="ファイル名";

//正規表現文字列
var ADVAT_REGSTR  = new Array(29);
ADVAT_REGSTR[0]="^[0-9]*$";
ADVAT_REGSTR[1]="^[0-9]*[\\.]?[0-9]+$";
ADVAT_REGSTR[2]="^[\\+|\\-]?[0-9]*[\\.]?[0-9]+$";
ADVAT_REGSTR[3]="^[A-Za-z]*$";
ADVAT_REGSTR[4]="^[A-Za-z]*$";
ADVAT_REGSTR[5]="^[A-Za-z]*$";
ADVAT_REGSTR[6]="^[A-Za-z0-9]*$";
ADVAT_REGSTR[7]="^[A-Za-z0-9]*$";
ADVAT_REGSTR[8]="^[A-Za-z0-9]*$";
ADVAT_REGSTR[9]="^[A-Za-z0-9 !-/:-@\\[-`\\{-~]*$";
ADVAT_REGSTR[10]="^[A-Za-z0-9 !-/:-@\\[-`\\{-~]*$";
ADVAT_REGSTR[11]="^[0-9]*$";
ADVAT_REGSTR[12]="";
ADVAT_REGSTR[13]="";
ADVAT_REGSTR[14]="";
ADVAT_REGSTR[15]="";
ADVAT_REGSTR[16]="";
ADVAT_REGSTR[17]="^([a-zA-Z0-9])+([a-zA-Z0-9\\._-])*@([a-zA-Z0-9_-])+([a-zA-Z0-9\\._-]+)+$";
ADVAT_REGSTR[18]="^[0-9]{3}-[0-9]{4}$";
ADVAT_REGSTR[19]="";
ADVAT_REGSTR[20]="";
ADVAT_REGSTR[21]="";
ADVAT_REGSTR[22]="";
ADVAT_REGSTR[23]="";
ADVAT_REGSTR[24]="^[0-9\\-]*$";
ADVAT_REGSTR[25]="";
ADVAT_REGSTR[26]="^[0-9]*$";
ADVAT_REGSTR[27]="^[0-9]*$";
ADVAT_REGSTR[28]="";

//属性チェック文字列
var ADVAT_CHKSTR  = new Array(29);
ADVAT_CHKSTR[0]="";
ADVAT_CHKSTR[1]="";
ADVAT_CHKSTR[2]="";
ADVAT_CHKSTR[3]="";
ADVAT_CHKSTR[4]="";
ADVAT_CHKSTR[5]="";
ADVAT_CHKSTR[6]="";
ADVAT_CHKSTR[7]="";
ADVAT_CHKSTR[8]="";
ADVAT_CHKSTR[9]="\",%()*?_\t|\\\\'";
ADVAT_CHKSTR[10]="\",%()*?_\t|\\\\'";
ADVAT_CHKSTR[11]="";
ADVAT_CHKSTR[12]="　ぁあぃいぅうぇえぉおかがきぎくぐけげこごさざしじすずせぜそぞただちぢっつづてでとどなにぬねのはばぱひびぴふぶぷへべぺほぼぽまみむめもゃやゅゆょよらりるれろゎわゐゑをんー";
ADVAT_CHKSTR[13]="　ァアィイゥウェエォオカガキギクグケゲコゴサザシジスズセゼソゾタダチヂッツヅテデトドナニヌネノハバパヒビピフブプヘベペホボポマミムメモャヤュユョヨラリルレロヮワヰヱヲンヴヵヶー";
ADVAT_CHKSTR[14]=" !\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~｡｢｣､･ｦｧｨｩｪｫｬｭｮｯｰｱｲｳｴｵｶｷｸｹｺｻｼｽｾｿﾀﾁﾂﾃﾄﾅﾆﾇﾈﾉﾊﾋﾌﾍﾎﾏﾐﾑﾒﾓﾔﾕﾖﾗﾘﾙﾚﾛﾜﾝﾞﾟ";
ADVAT_CHKSTR[15]="\",%()*?_|\\'\t";
ADVAT_CHKSTR[16]="\",%()*?_|\\'\t";
ADVAT_CHKSTR[17]="";
ADVAT_CHKSTR[18]="";
ADVAT_CHKSTR[19]="\",%()*?_|\\'\t";
ADVAT_CHKSTR[20]="\"%?|\t";
ADVAT_CHKSTR[21]=" |\\!\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ^_\\`abcdefghijklmnopqrstuvwxyz\t{|}~｡｢｣､･ｦｧｨｩｪｫｬｭｮｯｰｱｲｳｴｵｶｷｸｹｺｻｼｽｾｿﾀﾁﾂﾃﾄﾅﾆﾇﾈﾉﾊﾋﾌﾍﾎﾏﾐﾑﾒﾓﾔﾕﾖﾗﾘﾙﾚﾛﾜﾝﾞﾟ[]";
ADVAT_CHKSTR[22]="0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzｦｧｨｩｪｫｬｭｮｯｰ ｱｲｳｴｵｶｷｸｹｺｻｼｽｾｿﾀﾁﾂﾃﾄﾅﾆﾇﾈﾉﾊﾋﾌﾍﾎﾏﾐﾑﾒﾓﾔﾕﾖﾗﾘﾙﾚﾛﾜﾝﾞﾟ";
ADVAT_CHKSTR[23]="ｦｧｨｩｪｫｬｭｮｯｰｱｲｳｴｵｶｷｸｹｺｻｼｽｾｿﾀﾁﾂﾃﾄﾅﾆﾇﾈﾉﾊﾋﾌﾍﾎﾏﾐﾑﾒﾓﾔﾕﾖﾗﾘﾙﾚﾛﾜﾝﾞﾟ";
ADVAT_CHKSTR[24]="";
ADVAT_CHKSTR[25]="!#$&+-./0123456789:;<=>@ABCDEFGHIJKLMNOPQRSTUVWXYZ^`abcdefghijklmnopqrstuvwxyz{}~｡｢｣､･ｦｧｨｩｪｫｬｭｮｯｰ ｱｲｳｴｵｶｷｸｹｺｻｼｽｾｿﾀﾁﾂﾃﾄﾅﾆﾇﾈﾉﾊﾋﾌﾍﾎﾏﾐﾑﾒﾓﾔﾕﾖﾗﾘﾙﾚﾛﾜﾝﾞﾟ””[]";
ADVAT_CHKSTR[26]="";
ADVAT_CHKSTR[27]="";
ADVAT_CHKSTR[28]="\\/:*?\"<>|',";

//チェック文字列方式
var ADVAT_CHKFLG  = new Array(0,0,0,0,0,0,0,0,0,2,2,0,1,1,2,2,2,0,0,2,2,2,1,1,0,1,0,0,2);

//アルファベット変換
var ADVAT_ULFLG  = new Array(0,0,0,0,1,2,0,1,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0);

//全角半角変換
var ADVAT_AHFLG  = new Array(0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0);

//備考
var ADVAT_BIKO  = new Array(29);
ADVAT_BIKO[0]="";
ADVAT_BIKO[1]="";
ADVAT_BIKO[2]="";
ADVAT_BIKO[3]="";
ADVAT_BIKO[4]="";
ADVAT_BIKO[5]="";
ADVAT_BIKO[6]="";
ADVAT_BIKO[7]="";
ADVAT_BIKO[8]="";
ADVAT_BIKO[9]="";
ADVAT_BIKO[10]="";
ADVAT_BIKO[11]="";
ADVAT_BIKO[12]="";
ADVAT_BIKO[13]="";
ADVAT_BIKO[14]="";
ADVAT_BIKO[15]="";
ADVAT_BIKO[16]="";
ADVAT_BIKO[17]="xxx@xxx.xx";
ADVAT_BIKO[18]="999-9999";
ADVAT_BIKO[19]="";
ADVAT_BIKO[20]="";
ADVAT_BIKO[21]="";
ADVAT_BIKO[22]="";
ADVAT_BIKO[23]="";
ADVAT_BIKO[24]="";
ADVAT_BIKO[25]="";
ADVAT_BIKO[26]="";
ADVAT_BIKO[27]="";
ADVAT_BIKO[28]="";

//桁チェック設定
var ADVAT_BYTEFLG  = new Array(0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0);


