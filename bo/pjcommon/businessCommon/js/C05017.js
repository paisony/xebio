// 伝票バーコード丸め処理
function formatDenpyoBarCode(ctl_DenpyBarCd) {

	if (ctl_DenpyBarCd.value != "") {
		// 6桁未満の場合、先頭にゼロ詰めして6桁にする。
		if (ctl_DenpyBarCd.value.length < 6) {
			ctl_DenpyBarCd.value = LPadZero(ctl_DenpyBarCd.value, 6);

			// 7桁以上10桁未満の場合、先頭にゼロ詰めして10桁にする。
		} else if (ctl_DenpyBarCd.value.length >= 7 && ctl_DenpyBarCd.value.length < 10) {
			ctl_DenpyBarCd.value = LPadZero(ctl_DenpyBarCd.value, 10);
		}
	}
}

