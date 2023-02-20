// スキャンコード丸め処理
function formatScanCd(ctl_ScanCd) {

	if (ctl_ScanCd.value != "") {
		if (ctl_ScanCd.value.length == 12) {
			// 12桁の場合、先頭に0を付与する。
			ctl_ScanCd.value = LPadZero(ctl_ScanCd.value, 13);
		}
	}
}
