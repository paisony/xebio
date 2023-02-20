// 明細背景色変更処理
function detailColorSet(iRowNo) {

	// 対象行
	//var ctlRow = getAdvControlFromItemID("M1rowno", iRowNo);
	var rowNo = iRowNo + 1;
	if (rowNo < 10) {
		rowNo = LPadZero(rowNo, 2);
	}
	var ctlRow = document.all.item("M1_ctl" + rowNo + "_M1Row");
	// 確定操作あり
	var ctlKakuteiKbn = getAdvControlFromItemID(clm_M1KakuteiFlg, iRowNo);
	// 明細色区分
	var ctlColorKbn = getAdvControlFromItemID(clm_M1ColorFlg, iRowNo);

	if (ctlKakuteiKbn.value == "1") {
		// 確定操作あり
		//ctlRow.className = "str-result-item-01 js-commited";
		$(ctlRow).addClass('js-commited');
	} else {
		if (ctlColorKbn.value == "0") {
			// 未選択
			ctlRow.className = "str-result-item-01";
		} else if (ctlColorKbn.value == "1") {
			// 送信済み
			//ctlRow.className = "str-result-item-01 js-sent";
			$(ctlRow).addClass('js-sent');
		} else if (ctlColorKbn.value == "2") {
			// 商品指定
			//ctlRow.className = "str-result-item-01 js-search";
			$(ctlRow).addClass('js-search');
		} else if (ctlColorKbn.value == "3") {
			// N列(未実装)
			ctlRow.className = "str-result-item-01";
		} else {
			// その他
			ctlRow.className = "str-result-item-01";
		}
	}
}

// 確定操作あり用背景色変更処理
function commitColorSet(iRowNo) {

	// 確定操作あり
	var ctlKakuteiKbn = getAdvControlFromItemID(clm_M1KakuteiFlg, iRowNo);
	if (ctlKakuteiKbn) {
		ctlKakuteiKbn.value = "1";
		// 背景色変更
		detailColorSet(iRowNo);
	}

}

// 明細項目編集時の行選択処理
function rowEditSelect(lineNo) {

	var ctlSelectcheck = getAdvControlFromItemID(clm_M1SentakuFlg, lineNo);
	if (ctlSelectcheck) {
		// 選択フラグにチェックする
		getAdvControlFromItemID(clm_M1SentakuFlg, lineNo).checked = true;

		// 対象行を選択状態にする
		var rowNo = lineNo + 1;
		if (rowNo < 10) {
			rowNo = LPadZero(rowNo, 2);
		}
		var ctlRow = document.all.item("M1_ctl" + rowNo + "_M1Row");
		$(ctlRow).addClass('js-active');
	}
}
