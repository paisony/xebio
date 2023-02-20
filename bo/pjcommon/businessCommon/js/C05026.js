/**
 * C05026 SCMコード丸め処理
 * @param obj {Object} - SCMコードTextBox
 */
function formatScmCd(obj) {

	var val = obj.value;

	if (val != "") {
		if (val.length == 14
			&& val.substring(0, 5) == "00918") {
			// 14桁で先頭5バイトが00918の場合、0埋め
			obj.value = LPadZero(val, 20);
		}
	}
}
