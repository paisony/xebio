var msgLevel_info = 'info';
var msgLevel_warn = 'warn';
var msgLevel_warnmulti = 'warnmulti';

var confirmFlg = false;
var buttonYesAction = '';
var buttonNoAction = '';

// 情報向けダイアログの処理
function boOpenInfoDialogEx(message, yesAction, noAction, level) {
    console.log('クライアントメッセージ表示(INFO) ：' + message);
    canOpenRedisplayDialog = false;

    // クライアントチェックエラーの場合
    var oldMessage = MdClientErrorMessage;
    var uri;
    //if (message) {
    MdClientErrorMessage = message;
    uri = encodeURI('../pjcommon/businessCommon/aspx/BoMessageDialog.aspx?pgId=' + ADVIT_TARGETPGID + '&message=' + message + '&level=' + level);
    //}
	// ダイアログ高さ調整
    if (level == msgLevel_warnmulti) {
    	$('#modalContainer').height(417);
    } else if (level == msgLevel_info) {
    	$('#modalContainer').height(257);
    } else {
		$('#modalContainer').height(217);
	}
    buttonYesAction = yesAction;
    buttonNoAction = noAction;

    if (confirmFlg) {
        displayModal(false);
        AdvGB_SubmitFLG = true;
        return true;
    }
    showMessageDialog(uri);
    confirmFlg = true;

    return false;
}
