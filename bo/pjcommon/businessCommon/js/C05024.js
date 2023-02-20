// 数値変換関数 ※数値以外の場合は0を返す
function ToNumber(str) {
	if (!isFinite(str)) {
		return 0;
	} else {
		return Number(str);
	}
}
