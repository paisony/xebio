// カンマ編集処理
function formatComma(val) {

	var rtn = val;
	if (isFinite(val)) {
		rtn = String(rtn).replace(/(\d)(?=(\d\d\d)+(?!\d))/g, '$1,');
	}
	return rtn;

}

// カンマ編集解除処理
function unFormatComma(val) {

	var rtn = val.replace(/,/g, "");
	return rtn;

}
