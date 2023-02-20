// 項目入力制御処理
//   呼出し例： itemDisabled(Siji_bango,"true");
function itemDisabled(item, boo) {

	if (item.type == "button") {
		// ボタン系処理
		item.disabled = boo;
	} else if (item.type == "text" || item.type == "hidden") {
		// テキスト系処理
		// item.disabled = boo;
		item.readOnly = boo;
		// 使用不可制御
		if (item.id.indexOf("M1") < 0) {
			//	カード部の場合
			if (boo) {
				$("#" + item.id).addClass("txtDisabled");
				$("#" + item.id).addClass("txtReadonly");
				item.setAttribute("tabindex", "-1");
				item.style.background = "";

				// 次の項目がカレンダーボタンの場合、非表示
				var $nextelm = $("#" + item.id).next();
				if ($nextelm.attr("class") == "ui-datepicker-trigger") {
					$nextelm.hide();
				} else if ($nextelm.attr("class") == "icon-search") {
					// 次の項目が虫眼鏡の場合
					$nextelm.attr('disabled', boo);
				}

			} else {
				$("#" + item.id).removeClass("txtDisabled");
				$("#" + item.id).removeClass("txtReadonly");
				item.removeAttribute("tabindex");

				var $nextelm = $("#" + item.id).next();
				if ($nextelm.attr("class") == "ui-datepicker-trigger") {
					// 次の項目がカレンダーボタンの場合、表示
					$nextelm.show();
				} else if ($nextelm.attr("class") == "icon-search") {
					// 次の項目が虫眼鏡の場合
					$nextelm.attr('disabled', boo);
				}
			}
		} else {
			// 明細部の場合
			var ReadCssNm = "";
			if ($("#" + item.id).attr("class").indexOf("inpSerch") < 0) {
				// 虫眼鏡なしのテキストの場合
				ReadCssNm = "inpReadonlyNoAlign";
			} else {
				// 虫眼鏡付きのテキストの場合
				ReadCssNm = "inpReadonlyNoAlign_Seach";
			}

			if (boo) {
				$("#" + item.id).addClass("txtDisabled");
				$("#" + item.id).addClass(ReadCssNm);
				item.setAttribute("tabindex", "-1");
				item.style.background = "";

				// 次の項目がカレンダーボタンの場合、非表示
				var $nextelm = $("#" + item.id).next();
				if ($nextelm.attr("class") == "ui-datepicker-trigger") {
					$nextelm.hide();
				} else if ($nextelm.attr("class") == "icon-search") {
					// 次の項目が虫眼鏡の場合
					$nextelm.attr('disabled', boo);
				}

			} else {
				$("#" + item.id).removeClass("txtDisabled");
				$("#" + item.id).removeClass(ReadCssNm);
				item.removeAttribute("tabindex");

				// 次の項目がカレンダーボタンの場合、表示
				var $nextelm = $("#" + item.id).next();
				if ($nextelm.attr("class") == "ui-datepicker-trigger") {
					$nextelm.show();
				} else if ($nextelm.attr("class") == "icon-search") {
					// 次の項目が虫眼鏡の場合
					$nextelm.attr('disabled', boo);
				}
			}
		}

	} else if (item.type == "select-one") {
		// ドロップダウンリストの場合
		item.disabled = boo;
		$(item).removeClass("dropDownListDisable");
		if (boo) {
			$(item).addClass("dropDownListDisable");
		}
	} else {
		// その他
		item.disabled = boo;
	}
	
}
// 項目入力制御処理（div単位）
//   呼出し例： divDisabled(".str-search-01", false);
function divDisabled(div, boo) {
	// 指定した要素内の項目に対して処理
	$(div).find("input[type=checkbox],input[type=radio],select").each(function () {
		// 項目制御
		itemDisabled(this, boo);
	});
}

// 項目表示制御処理
//   呼出し例： itemVisible(Siji_bango, true);
function itemVisible(item, boo) {

	if (boo) {
		$(item).show();
	} else {
		$(item).hide();
	}

}
// フォーカス設定処理
//   呼出し例： setFocus(Siji_bango);
function itemSetFocus(item) {
	//item.focus();
	item.select();
}

// 入力項目の背景色初期化処理
//   呼出し例： txtInitialSet(Siji_bango);
function inputInitialSet(item, val) {
	
	if (item.type == "select-one") {
		// ドロップダウンリストの場合、1行目を選択させる
		item.selectedIndex = val;
	} else {
		item.value = val;
		$(item).removeClass("error-input-code");
		var style = $(item).attr("style");
		if (typeof style !== "undefined") {
			$(item).attr("style", style.replace("background-color:#FDE0E0;", ""));
        }
	}
}


