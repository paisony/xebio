// 空白文字変換
function Nvl(str, changestr) {
	if (str == null || str == '') {
		if (changestr != null) {
			return changestr;
		} else {
			return '';
		}
	} else {
		return str;
	}
}