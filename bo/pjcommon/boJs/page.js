// selectorの定義
var selectorRadioButton = 0;
var selectorCheckBox = 0;

// 検索画面のメニュー開閉ボタン
$(function(){
    var over_flg;
	$("#menu-btn p a").click(function(){
	    var menuFrame = $('#menu-frame');
	    var appUrl = window.location.href;
	    if (!menuFrame.attr('src') || menuFrame.attr('src') == '') {
	        if (appUrl.indexOf('/bo_v/') != -1) {
	            menuFrame.attr('src', '/base_v/Common/BoMenu.aspx');
	        } else if (appUrl.indexOf('/bo_FEv/') != -1) {
	            menuFrame.attr('src', '/base_FEv/Common/BoMenu.aspx');
	        } else if (appUrl.indexOf('/bo_DEVv/') != -1) {
	            menuFrame.attr('src', '/base_DEVv/Common/BoMenu.aspx');
	        } else if (appUrl.indexOf('/bo_FEx/') != -1) {
	            menuFrame.attr('src', '/base_FEx/Common/BoMenu.aspx');
	        } else if (appUrl.indexOf('/bo_DEVx/') != -1) {
	            menuFrame.attr('src', '/base_DEVx/Common/BoMenu.aspx');
	        } else {
	            menuFrame.attr('src', '/base_x/Common/BoMenu.aspx');
	        }
	        menuFrame.show();
	    } else {
	        if (appUrl.indexOf('/bo_v/')) {
	            menuFrame.location = '/base_v/Common/BoMenu.aspx';
	            menuFrame.removeAttr('src', '/base_v/Common/BoMenu.aspx');
	        } else if (appUrl.indexOf('/bo_FEv/') != -1) {
	            menuFrame.location = '/base_FEv/Common/BoMenu.aspx';
	            menuFrame.removeAttr('src', '/base_FEv/Common/BoMenu.aspx');
	        } else if (appUrl.indexOf('/bo_DEVv/') != -1) {
	            menuFrame.location = '/base_DEVv/Common/BoMenu.aspx';
	            menuFrame.removeAttr('src', '/base_DEVv/Common/BoMenu.aspx');
	        } else if (appUrl.indexOf('/bo_FEx/') != -1) {
	            menuFrame.location = '/base_FEx/Common/BoMenu.aspx';
	            menuFrame.removeAttr('src', '/base_FEx/Common/BoMenu.aspx');
	        } else if (appUrl.indexOf('/bo_DEVx/') != -1) {
	            menuFrame.location = '/base_DEVx/Common/BoMenu.aspx';
	            menuFrame.removeAttr('src', '/base_DEVx/Common/BoMenu.aspx');
	        } else {
	            menuFrame.location = '/base_x/Common/BoMenu.aspx';
	            menuFrame.removeAttr('src', '/base_x/Common/BoMenu.aspx');
	        }
	        menuFrame.hide();
	    }
	    
	});
	// マウスカーソルがメニュー上/メニュー外
	$("#menu-btn, #menu-frame").hover(function () {
      over_flg = true;
    }, function(){
      over_flg = false;
    });
    // メニュー領域外をクリックしたらメニューを閉じる
    $('body').click(function() {
	    if (over_flg == false) {
		    var appUrl = window.location.href;
	        if (appUrl.indexOf('/bo_v/') != -1) {
	            $("#menu-frame").location = '/base_v/Common/BoMenu.aspx';
	            $("#menu-frame").removeAttr('src', '/base_v/Common/BoMenu.aspx');
	        } else if (appUrl.indexOf('/bo_FEv/') != -1) {
	            $("#menu-frame").location = '/base_FEv/Common/BoMenu.aspx';
	            $("#menu-frame").removeAttr('src', '/base_FEv/Common/BoMenu.aspx');
	        } else if (appUrl.indexOf('/bo_DEVv/') != -1) {
	            $("#menu-frame").location = '/base_DEVv/Common/BoMenu.aspx';
	            $("#menu-frame").removeAttr('src', '/base_DEVv/Common/BoMenu.aspx');
	        } else if (appUrl.indexOf('/bo_FEx/') != -1) {
	            $("#menu-frame").location = '/base_FEx/Common/BoMenu.aspx';
	            $("#menu-frame").removeAttr('src', '/base_FEx/Common/BoMenu.aspx');
	        } else if (appUrl.indexOf('/bo_DEVx/') != -1) {
	            $("#menu-frame").location = '/base_DEVx/Common/BoMenu.aspx';
	            $("#menu-frame").removeAttr('src', '/base_DEVx/Common/BoMenu.aspx');
	        } else {
	            $("#menu-frame").location = '/base_x/Common/BoMenu.aspx';
	            $("#menu-frame").removeAttr('src', '/base_x/Common/BoMenu.aspx');
	        }
		    $("#menu-frame").hide();
		}
    });

});

//画像切替
$(function(){
	$("img,input[type='image']").hover(function(){
		if ($(this).attr("src")){
			$(this).attr("src",$(this).attr("src").replace("_off.", "_on."));
		}
	},function(){
		$(this).attr("src",$(this).attr("src").replace("_on.", "_off."));
	});
});

$(function() {
	'use strict';

/*
	トグルイベント
*/
	var $openBtn = $('.trigger-search-01');
	var $openBtnTrigger = $('.trigger-search-01 a');
	var $searchContent = $('.str-search-01 .inner-02, .str-tab-menu');
	var $searchResult = $('.str-search-01 .inner-01');
	// 明細画面のヘッダ部
	var $searchContent2 = $('.str-search-02 .inner-01');
	$searchResult.hide();
	$openBtn.hide();

	$openBtnTrigger.click(function() {
		toggleEvent();
        // アコーディオン切り替え時に行う業務処理の存在チェック
	    if (typeof bizToggleEvent == "function") {
	        // 開閉状態を引数として渡し、業務処理を行う
	        var accordionStatus = $openBtn.hasClass('js-on');
	        bizToggleEvent(accordionStatus);
	    }
		return false;
	});

	// コンテンツとトリガーのクラス切り替えイベント
	function toggleEvent() {
		var judge = $openBtn.hasClass('js-on');
		if (judge === true) {
			$searchContent.show();

			$searchContent2.show();
			$searchResult.hide();
		} else {
			$searchContent.hide();
			$searchContent2.hide();
			$searchResult.show();
		}
		$openBtn.toggleClass('js-on');
		// 高さ調節関数を呼び出し
		$('.common').adjustHeight();
	}

/*
	一覧のホバー・アクティブ制御
*/
    // ホバー処理
    var $resultItem = $('.str-result-item-01');
    $resultItem.hover(function() {
        $(this).addClass('js-hover');
    }, function() {
        $(this).removeClass('js-hover');
    });

    // 選択処理
    $resultItem.click(function() {
        // チェックボックス（複数選択可能な場合）
        var checkbox = $(this).find('input[type=checkbox]');
        var selectorCheck = $(this).find('input[id$=' + selectorCheckBox + ']');
        var target = $(event.target);
        //targetが定義されていない場合はreturn
        if (target.length == 0) {
            return;
        }
        if (target.attr('type') == 'checkbox' || target.attr('type') == 'radio' ||
                target.attr('type') == 'button' || target[0].tagName == 'A' ||
                    (target.attr('type') == 'text' && target.attr('readOnly') == false) ||
                        target[0].tagName == 'SELECT' || target[0].tagName == 'OPTION') {
            return;
        }
        if (checkbox && checkbox.length != 0) {
            // 対象のチェックボックスがない場合、選択しない。
            if ((selectorCheck && selectorCheck.length == 0 && selectorCheckBox != '')) {
                return;
            }
            var checked = checkbox.filter(':checked');
            var selectorChecked = selectorCheck.filter(':checked');
            if (selectorCheck && selectorCheck.length != 0 && selectorCheckBox != 0) {
            	var chk = true;
                if (selectorChecked && selectorChecked.length != 0) {
                    $(this).removeClass('js-active');
                    selectorCheck.removeAttr('checked');
                    chk = false;
                } else {
                    $(this).addClass('js-active');
                    selectorCheck.attr('checked', 'checked');
                    chk = true;
                }
            	// [onAfter]がある、かつcalcFがtrueの場合、後処理を実行する。
                if (typeof selectRowAfter == "function") {
                	// 行選択の出口ルーチン呼出
                	var rowno = Number(selectorCheck.attr('name').substring(6, 8)) - 1;
                	selectRowAfter(rowno, chk);
                }
                return;
            } else {
                if (checked && checked.length != 0) {
                    $(this).removeClass('js-active');
                    checkbox.removeAttr('checked');
                } else {
                    $(this).addClass('js-active');
                    checkbox.attr('checked', 'checked');
                }
                return;
            }
        }
        // ラジオボタン（複数選択不可の場合）
        var radiobutton = $(this).find('input[type=radio]');
        if (radiobutton && radiobutton.length != 0) {
            var target = this;
            var selectorRadio = $(this).find('input[id$=' + selectorRadioButton + ']');

            // 対象のチェックボックスがない場合、選択しない。
            if ((selectorRadio && selectorRadio.length == 0 && selectorRadioButton != '')) {
                return;
            }

            if (selectorRadioButton != 0 && selectorRadio && selectorRadio.length != 0) {
                $('#str-result-item-wrap .str-result-item-01').each(function () {
                    if (this != target) {
                        $(this).removeClass('js-active');
                        $(this).find('input[id$=' + selectorRadioButton + ']').removeAttr('checked');
                    } else {
                        $(this).addClass('js-active');
                        selectorRadio.attr('checked', 'checked');
                    }
                });
                return;
            } else {
                $('#str-result-item-wrap .str-result-item-01').each(function () {
                    if (this != target) {
                        $(this).removeClass('js-active');
                        $(this).find('input[type=radio]').removeAttr('checked');
                    } else {
                        $(this).addClass('js-active');
                        $(this).find('input[type=radio]').attr('checked', 'checked');
                    }
                });
                return;
            }
        }       
    });


/*
	並び順切り替えスイッチ（並び替え自体は未実装）
*/

	var $btmOrder = $('.btn-order');
	$btmOrder.hover(function() {
		$(this).css('background-color', '#1CB4E0');
	}, function() {
		$(this).css('background-color', '#1CA7E0');
	});
	$btmOrder.click(function() {
		$(this).toggleClass('js-on');
	});


    /*
        共通イベント処理
    */
	$(window).load(function () {
            // 店舗情報をヘッダーに移動
    	    $('.tenpo-info').html($('#tenpo'));
	        $searchContent2.show();
	    	// 高さ調節関数を呼び出し
	        $('.common').adjustHeight();
	        if ($('.str-form-02').length != 0) {
	        $('.str-form-02').setSearchCondition('.inner-01 .search-table-tdleft .list-search-condition');
	    }
	    // アコーディオンの状態による処理
	    if (accordionKbn == '1') {
            // アコーディオン開状態
	        $openBtnTrigger.show();
	        $openBtn.show();
	        $searchResult.hide();
	        $searchContent.show();
	        $searchContent2.show();
	    	// 高さ調節関数を呼び出し
	        $('.common').adjustHeight();
	    } else if (accordionKbn == '0') {
	        // アコーディオン閉状態
	        $openBtnTrigger.show();
	        $openBtn.show();
	        $openBtn.addClass('js-on');
	        $searchResult.show();
	        $searchContent.hide();
	        $searchContent2.hide();
	    	// 高さ調節関数を呼び出し
	        $('.common').adjustHeight();
	    } else {
	        // アコーディオンなし
	        $openBtnTrigger.hide();
	        $openBtn.hide();
	        $searchResult.hide();
	        $searchContent.show();
	        $searchContent2.show();
	    }

		// 明細部のボタンラベルのフォントカラー設定
	    var buttonElement = $('[class^="icon-utility-"]:disabled,[class*=" icon-utility-"]:disabled').parent();
	    if (buttonElement.length != 0 && (buttonElement[0].tagName === 'SPAN' || buttonElement[0].tagName === 'LABEL')
            && !buttonElement.hasClass('icon-utility-disabled-text') && !buttonElement.hasClass('icon-utility-abled-text')) {
	        buttonElement.addClass('icon-utility-disabled-text');
	    }
	});
	$(window).resize(function () {
	    $('.common').adjustHeight();
	});
});

// onLoad()の後に呼び出すためにfunction化
// 選択の初期化処理
function selectorCheckInit() {
    $('#str-result-item-wrap .str-result-item-01').each(function () {
        var checked = $(this).find('input[id$=' + selectorCheckBox + ']').filter(':checked');
        // 明細中にチェックされているチェックボックスがあれば、該当行を選択状態表示とする。
        if (checked && checked.length != 0) {
            $(this).addClass('js-active');
        }
    });
}
