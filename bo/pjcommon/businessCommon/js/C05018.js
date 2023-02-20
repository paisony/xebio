$(function () {
	'use strict';
	// 項目転送
	$.fn.setSearchCondition = function (toElementSelector) {
		var html = '<p class="txt-01">検索条件</p><ul class="list-search-01">';

		//// --- 取漏れ　独自実装
		html += "<table><tr><td style=\"vertical-align: top;\">";
		//// --- 取漏れ　独自実装

		// タブ対応v
		var selectedTab = $('.search-tab-active');
		if (selectedTab && selectedTab.length != 0) {
			html += '<li>モード: ' + selectedTab.text();
		}

		// 検索条件
		$(this).find('.tbl-hdg,input[type=text],input:checked,select,span[class^=label-]').each(function () {
			if ($(this).height() == 0 || $(this).width() == 0) {
				return;
			}
			if (0 <= this.className.indexOf('tbl-hdg')) {
				//// --- 取漏れ　独自実装
				if (this.innerText == '取漏れ／欠番') {
					html += '<li>' + this.innerText.replace('*', '') + ':';
				}
				else if (this.innerText == 'フェイスNo') {
					html += '<li>' + this.innerText.replace('*', '') + ": </li></td><td width=\"650px;\" style=\"vertical-align: top;\">";
					// html += '<li>';
				}
				else {
					html += '<li>' + this.innerText.replace('*', '');
				}

				// ---　取漏れ　　独自実装
			} else if (this.tagName.toLowerCase() === 'input'
				&& (this.getAttribute('type').toLowerCase() === 'text'
				|| this.getAttribute('type').toLowerCase() === 'file')) {
				//html += this.value == '' ? '	' : ' ' + this.value;
				html += this.value == '' ? '	' : ' ' + this.value;
			} else if (this.tagName.toLowerCase() === 'input'
				&& (this.getAttribute('type').toLowerCase() === 'radio'
				|| this.getAttribute('type').toLowerCase() === 'checkbox')) {
				html += this.parentElement.innerText == '' ? '	' : ' ' + this.parentElement.innerText;
			} else if (this.tagName.toLowerCase() === 'select') {
				var selectedText = $(this).find('option:selected');
				html += selectedText.text() == '' ? '	' : ' ' + selectedText.text();
			} else if (0 <= this.className.indexOf('label-fromto')) {
				html += ' ' + this.innerText;
			} else if (0 <= this.className.indexOf('label-from')) {
				if (html.substr(html.length - 1, 1) != '\t') {
					html += ' ' + this.innerText;
				}
			}
		});
		html = html.split(/<li>[^:]+:+<li>/).join('<li>');
		html = html.split(/\t+ ～\t+/).join('\t') + '</ul>';
		html = html.split(/\t+ ～ +/).join(' ～') + '</ul>';
		html = html.split('<li>取漏れ／欠番:\t').join('');
		html = html.split(/<li> +\t+/).join('');
		$(toElementSelector).html(html);
	}

});
