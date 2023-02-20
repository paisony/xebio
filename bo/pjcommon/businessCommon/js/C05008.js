// 0埋め処理
function LPadZero(val, keta) {

	var zero = "";
	var rtn = "";
	for (i = 0; i < keta; i++) {
		zero = zero + "0";
	}
	rtn = (zero + val).substr((zero + val).length - keta, keta);
	return rtn;

}

// 0埋め処理
function LDelZero(val) {

	var rep = new RegExp("^0+0?");
	return val.replace(rep, "");

}
