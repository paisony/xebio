/*-----------------------------------------------------------------------------
	モジュール:mdPjCommonVariable.js
--------------------------------------------------------------------------------*/

//確認ダイアログ制御フラグ
var MD_CONFIRM_FLAG = false;

//確認ダイアログ制御アクションID
var MD_SRC_EVENT_ID;

//非同期マスタ参照ルートパス
var MD_ASYNCHRONOUS_ROOT_PATH = "../pjcommon/businessCommon/aspx/";

//エラーポップアップ再表示制御フラッグ
var canOpenRedisplayDialog = true;

//確認ダイアログスタイル（情報モード）
var InfoConfirmBgColor = "#cccccc";
var InfoConfirmColor = "black";

//確認ダイアログスタイル（警告モード）
var WarnConfirmBgColor = "#ffcc33";
var WarnConfirmColor = "black";

//確認ダイアログスタイル（エラーモード）
var ErrorConfirmBgColor = "red";
var ErrorConfirmColor = "white";

//明細行マウスオーバー時のハイライト色
var MouseOverBgColor = "#0082DA";

//明細行マウスオーバー時対象となるCSSクラス定義
var DETAIL_HIGHT_LIGHT_TARGET = "cmDetailHighLightTarget";

/**Ajax通信モデル
グローバルインスタンス
*/
var AjaxModel = new Object();
    AjaxModel.asyncMode = true;
    AjaxModel.type = "POST";
    AjaxModel.cache = false;
    AjaxModel.processData = false;
    AjaxModel.dataType = "xml";
    AjaxModel.returnValueAttribute = "value";
    AjaxModel.dataClear = true;
    
    
//リストボックスCssクラス名   
var CM_LIST_BOX = "cmListBox";

//ToolTips項目Cssクラス名
var CM_INPUT_TOOLTIPS = "cmInputToolTips"

//NowloadingのCss名
var CMSLTNOWLOADING = "CMSLTNOWLOADING";

//挿入確認のCss名
var CMINSCONFIRM = "CMINSCONFIRM";

//削除確認のCss名
var CMDELCONFIRM = "CMDELCONFIRM";

//更新確認のCss名
var CMUPDCONFIRM = "CMUPDCONFIRM";

//機能間連携子画面ハンドル変数
var PG_SYN = null;


