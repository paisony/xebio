$(function () {
    'use strict';

    // モーダルに必要な要素を生成
    generateObj();
    //ウィンドウリサイズ時にモーダルウィンドウの位置をセンターに調整
    $(window).resize(function () {
        adjustPosition('#modalContainer');
    });
    //背景がクリックされた時にモーダルウィンドウを閉じる
    $('#modalBackground').click(function () {
        if (buttonNoAction != '') {
            $('#hiddenButtonNo', parent.document).trigger("click");
        }
        //複数帳票出力画面の場合は背景クリック時にウィンドウを閉じない
        if (typeof dlDialogFlg == 'undefined' || !dlDialogFlg) {
            displayModal(false);
        }
    });

    //ダイアログのボタンをクリックされた場合の処理
    $('.modal-btn a').click(function () {

        var yesOrNo = $(this).attr("id");
        if (yesOrNo == 'btn-yes') {
            // ダイアログの「はい」がクリックされた場合
            $('#hiddenButtonYes', parent.document).trigger("click");
        } else {
            // ダイアログの「いいえ」がクリックされた場合
            $('#hiddenButtonNo', parent.document).trigger("click");
        }
    });

    // ダイアログの「はい」がクリックされた場合のアクション
    $('#hiddenButtonYes').click(function () {
        // 親画面の要素を選択できるようにDisabledを解除
        $('#wrap').attr('disabled', false);
        $('#wrap').removeAttr('disabled');
        buttonYesAction();
        displayModal(false);
    });

    // ダイアログの「いいえ」がクリックされた場合のアクション
    $('#hiddenButtonNo').click(function () {
        // 親画面の要素を選択できるようにDisabledを解除
        $('#wrap').attr('disabled', false);
        $('#wrap').removeAttr('disabled');
        buttonNoAction();
        displayModal(false);
    });

    // モーダル表示に必要なパーツを生成
    function generateObj() {

        // モーダル要素を包括するdivを生成
        var $modalContent = $('<div>').attr('id', 'modal');
        // スタイル定義
        $modalContent.css({
            'display': 'none',
            'position': 'fixed',
            'top': 0,
            'left': 0,
            'z-index': 2,
            'width': '100%',
            'height': '100%'
        });
        var $modalContainer = $('<div>').attr('id', 'modalContainer');
        // スタイル定義
        $modalContainer.css({
            'position': 'relative',
            'z-index': 4,
            'background-color': '#FFF',
            'height': '417px',
            'width': '706px'
        });
        // iframe生成
        var $iframeObj = $('<iframe>').attr('id', 'modalIframe');
        // スタイル定義
        $iframeObj.css({
            'width': '100%',
            'height': '100%',
            'border': 0,
            'margin': 0,
            'padding': 0
        });
        // 背景要素生成
        var $modalBg = $('<div>').attr('id', 'modalBackground');
        // スタイル定義
        $modalBg.css({
            'position': 'fixed',
            'top': 0,
            'left': 0,
            'z-index': 3,
            'width': '100%',
            'height': '100%',
            'background-color': '#000000',
            'opacity': '0.75'
        });
        // 閉じるボタン生成
        var $modalCloseBtn = $('<a>').attr('href', '#').attr('id', 'modalClose').html('<img src="../pjcommon/boImages/icon-close.png" alt="閉じる" />');
        var closeBtnMargin = -8;
        $modalCloseBtn.css({
            'position': 'absolute',
            'z-index': 5,
            'top': closeBtnMargin + 'px',
            'right': closeBtnMargin + 'px'
        });
        // コンテナにiframeと閉じるボタンを追加
        $modalContainer.append($iframeObj).append($modalCloseBtn);
        // #modalにまとめて追加
        $modalContent.append($modalBg).append($modalContainer);
        // 親htmlのbodyに追加
        $('body').append($modalContent);
    }
});

// ダイアログ表示前のフォーカス位置を記録するための変数
var activeElement = null;

// 複数帳票ダウンロード画面のフラグ
var dlDialogFlg = false;
// ダイアログを表示
function showMessageDialog(target, dlFlg) {
    dlDialogFlg = dlFlg;
    activeElement = document.activeElement;
    $('#modalIframe').attr('src', target);
    $('#modalIframe').load(function () {
        onComplete();
        adjustPosition('#modalContainer');
    });
}

// エラーダイアログの処理
function boOpenErrorDialog(message) {

    // エラーか情報かでサイズを変更する。
    $('#modalContainer').height(417);
    openErrorDialog(message);
}

var confirmFlg = false;
var buttonYesAction = '';
var buttonNoAction = '';
// 情報向けダイアログの処理
function boOpenInfoDialog(message,yesAction,noAction) {
    console.log('クライアントメッセージ表示(INFO) ：' + message);
    canOpenRedisplayDialog = false;

    // クライアントチェックエラーの場合
    var oldMessage = MdClientErrorMessage;
    var uri;
    if (message) {
        MdClientErrorMessage = message;
        uri = encodeURI('../pjcommon/aspx/MessageDialog.aspx?pgId=' + ADVIT_TARGETPGID + '&message=' + message + '&level=info');
    }
    $('#modalContainer').height(217);
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

// 複数帳票出力ダイアログの表示
function openDownloadDialog(pgId) {
    $('#modalContainer').height(230);
    uri = encodeURI('../tm810p01/tm810p01Init.aspx?pgId=' + pgId);
    $(window).load(function () {
        showMessageDialog(uri, true);
    });
}

//コンテンツの読み込み完了時にモーダルウィンドウを開く
function onComplete() {
    displayModal(true);
    if (document.getElementById('btn-no')) {
        document.getElementById('btn-no').focus();
    }
    $('#modalClose').click(function () {
        if (buttonNoAction != '') {
            $('#hiddenButtonNo', parent.document).trigger("click");
        }
        displayModal(false);
        return false;
    });
}


//モーダルウィンドウを開く
function displayModal(sign) {
    if ($('body').hasClass('not-open')) {
        return;
    }
    if (sign) {
        $('#modal').fadeIn(250);
        $('#wrap').attr('disabled', true);
    } else {
        confirmFlg = false;
        $('#modal').fadeOut(250);
        $('#wrap').attr('disabled', false);
        $('#wrap').removeAttr('disabled');
        if (activeElement && activeElement !== null) {
            activeElement.focus();
        }
    }
}

//ウィンドウの位置をセンターに調整
function adjustPosition(target) {
    var windowH = $(window).height();
    var windowW = $(window).width();
    var targetH = $(target).height();
    var targetW = $(target).width();
    var marginTop = (windowH - targetH) / 2;
    var marginLeft = (windowW - targetW) / 2;
    $(target).css({ top: marginTop + "px", left: marginLeft + "px" });

}