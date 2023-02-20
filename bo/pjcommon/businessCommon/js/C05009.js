// 指示番号丸め処理(返品用)
function formatSijinoHenpin(obj) {
	// アンフォーマット
//	unFormatSijinoHenpin(obj);
	var val = obj.value;

	if (val != "") {
		if (val.length <= 10) {
			obj.value = LPadZero(val, 10);
		} else {
			obj.value = LPadZero(val, 24);
		}
	}


}
function unFormatSijinoHenpin(obj) {
	// 前ゼロ削除
	obj.value = LDelZero(obj.value);

}
