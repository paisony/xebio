$(function () {
    'use strict';
    $.fn.adjustHeight = function(){

        // 指定のウィンドウの高さを格納
        // ※「$(window).height()」だと正しく取れない事があるので
        //   取れない場合は「window.innerHeight」を使用
//        var winHeight = $(window).height();
        var winHeight = window.innerHeight ? window.innerHeight : $(window).height();
        if (winHeight < 680) {
            winHeight = 680;
        }
        // ※スクロールバーが出てしまう画面があるので調整
        winHeight = winHeight - 1;
        // 高さを調節する要素
        var $adjustElem = $('.adjust-elem');
        // 高さを調節する要素のウィンドウ上からの距離を取得
        var adjustElemPosition = $adjustElem.offset();
        // 高さを調節する要素より下にある要素の高さを取得
        // 高さを調節する要素のすぐ下の要素位置
        var bottomElemPosition = $('.adjust-elem-next').offset();
        if (!bottomElemPosition) {
            return;
        }
        var bottomElemHeightTop = bottomElemPosition.top;
        var bodyHeight = $('body').height()+30;
        var bottomAllElemHeight = bodyHeight - bottomElemHeightTop;
        // 調節する要素に当てはめる高さを計算
        var adjustedHeight = winHeight - adjustElemPosition.top - bottomAllElemHeight;
        $adjustElem.css('height', adjustedHeight + 'px');
    }

/*
    ツールチップ用文字列の作成
*/
    $('.tooltip').each(function (i) {
        if (this.tagName == "INPUT") {
            this.setAttribute('title', this.value);
        } else {
            this.setAttribute('title', this.innerText);
        }
    });


/*
    検索条件非入力部への値の転記
*/

    $.fn.setSearchCondition = function(toElementSelector){
        if ($("#header_searchContentResetFlg").val() == "1" && $("#error-01").css("display") == "none") {
            var html = '<p class="txt-01">検索条件</p><ul class="list-search-01">';

            var empStr = '\t\t\t\t\t\t\t\t';
            var tab1Flg = 0;

            // 検索条件
            $(this).find('.tbl-hdg,input[type=text],input[type=checkbox],input[type=radio],select,span[class^=label-]').each(function () {
                if ($(this).height() == 0 || $(this).width() == 0) {
                    return;
                }
                if (0 > this.className.indexOf('noSet')) {
					if (0 <= this.className.indexOf('tbl-hdg')) {
						if (0 <= this.className.indexOf('label-none')) {
							html += '<li>:';
						} else {
							html += '<li>' + this.innerText.replace('*', '') + ':';
						}
					} else if (this.tagName.toLowerCase() === 'input' 
						&& (this.getAttribute('type').toLowerCase() === 'text'
						|| this.getAttribute('type').toLowerCase() === 'file')) {
                		if (this.className.indexOf("multiinput2") >= 0) {
                			html += this.value == '' ? '\t\t' : ' ' + this.value;
                			tab1Flg = 1;
                		} else if (this.className.indexOf("multiinput") >= 0) {
                			html += this.value == '' ? '\t' : ' ' + this.value;
                			tab1Flg = 1;
                		} else {
                			html += this.value == '' ? empStr : ' ' + this.value;
                		}
					} else if (this.tagName.toLowerCase() === 'input' 
						&& (this.getAttribute('type').toLowerCase() === 'radio')) {
						var checked = $(this).filter(':checked');
						if (checked && checked.length != 0) {
                    		html += this.parentElement.innerText == '' ? empStr : ' ' + this.parentElement.innerText;
						}
					} else if (this.tagName.toLowerCase() === 'input' 
						&& (this.getAttribute('type').toLowerCase() === 'checkbox')) {
						var checked = $(this).filter(':checked');
						if (checked && checked.length != 0) {
							if ($(this.parentElement).next().attr('class') != null) {
								if (0 <= $(this.parentElement).next().attr('class').indexOf('noSet')) {
									html += $(this.parentElement).next().val() == '' ? "〆" : ' ' + $(this.parentElement).next().val();
								} else {
									html += this.parentElement.innerText == '' ? "〆" : ' ' + this.parentElement.innerText;
								}
							} else {
								html += this.parentElement.innerText == '' ? "〆" : ' ' + this.parentElement.innerText;
							}
						}
						else {
                    		html += empStr;
						}
					} else if (this.tagName.toLowerCase() === 'select') {
                		var selectedText = $(this).find('option:selected');
                		html += selectedText.text() == '' ? empStr : ' ' + selectedText.text();
					} else if (0 <= this.className.indexOf('label-fromto')) {
                		html += ' ' + this.innerText;
					} else if (0 <= this.className.indexOf('label-from') || 0 <= this.className.indexOf('label-hihun')) {
						if (html.length > empStr.length) {
							if (html.substr(html.length - empStr.length, empStr.length) != empStr) {
								html += ' ' + this.innerText;
							}
						}
					}
                }
            });

            var regexp = new RegExp(empStr + ' ‐' + empStr, 'g');
            html = html.split(regexp).join(empStr);

            regexp = new RegExp(':' + empStr + '+ ～' + empStr, 'g');
            html = html.split(regexp).join(':' + empStr) + '</ul>';
        	regexp = new RegExp(':' + empStr + '+ ～ ', 'g');
            html = html.split(regexp).join(': ～') + '</ul>';
            regexp = new RegExp('<li>[^:]+:' + empStr, 'g');
            html = html.split(regexp).join('');
            regexp = new RegExp('<li>+:+', 'g');
            html = html.split(regexp).join('<li>');
            regexp = new RegExp('<li>+' + empStr, 'g');
            html = html.split(regexp).join('');

            if (tab1Flg == 1) {
            	html = html.split(/\t/).join('');
            	html = html.split(/<li>[^:]+:+<li>/).join('<li>');
            	regexp = new RegExp('<li>[^:]+:+</ul>', 'g');
            	html = html.split(regexp).join('</ul>');
            }

            $(toElementSelector).html(html);
            $("#header_searchContent").val(html);
        } else {
            $(toElementSelector).html($("#header_searchContent").val());
        }
    }



/*
    カレンダー表示
*/
    var calendarInput = $(".datepicker");
    if (calendarInput && calendarInput.length != 0) {
        calendarInput.datepicker({
            showOn: "button",
            buttonImage: "../pjcommon/boImages/icon-cal.png",
            changeYear: true,
            changeMonth: true,
            firstDay: 1,
            buttonImageOnly: true,
            showAnim: 'fadeIn',
            beforeShow: function (input, inst) {
                var elm = document.getElementById(inst.id);
                var bounds = elm.getBoundingClientRect();
                if (window.innerWidth - bounds.left < 332) {
                    inst.dpDiv.css({ marginTop: -27 + 'px', marginLeft: -214 + 'px' });
                } else {
                    inst.dpDiv.css({ marginTop: -27 + 'px', marginLeft: 107 + 'px' });
                }
            },
            onSelect: function (input, inst) {
                document.all.item(inst.id).focus();
                document.all.item(inst.id).select();
                if (typeof calenderSelectEvent == "function") {
                    calenderSelectEvent();
                }
            }
        });
    }

});
