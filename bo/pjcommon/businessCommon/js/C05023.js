// 日付のスラッシュ変換(YYYYMMDD)
function formatYYYYMMDDSrash(str) {
	if (str == null || str == '') {
		return '';
	}
	if (str.length != 8) {
		return str;
	}

	var yyyy = str.substring(0, 4);
	var mm = str.substring(4, 6);
	var dd = str.substring(6, 8);

	return yyyy + "/" + mm + "/" + dd;

}
// 日付のスラッシュ解除
function unFormatYmdSrash(str) {
	return str.replace('/', '').replace('/', '');

}

// システム日付取得(YYYYMMDD形式)
function getSysDate(day) {
	var now = new Date();
	var y = now.getFullYear();
	var m = now.getMonth() + 1;
	var d = now.getDate() + day;

	if (m < 10) {
		m = '0' + m;
	}
	if (d < 10) {
		d = '0' + d;
	}
	return y + m + d;
}
