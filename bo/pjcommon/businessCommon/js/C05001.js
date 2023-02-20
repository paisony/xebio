// 自社品番丸め処理
function formatJisyaHbnCd(ctl_JisyaHbnCd) {

	if (ctl_JisyaHbnCd.value != "") {
		if (ctl_JisyaHbnCd.value.length <= 8) {
			// 8桁以内の場合、8桁まで0埋め
			ctl_JisyaHbnCd.value = LPadZero(ctl_JisyaHbnCd.value, 8);
		} else if (ctl_JisyaHbnCd.value.length == 9) {
			// 9桁の場合、10桁まで0埋め
			ctl_JisyaHbnCd.value = LPadZero(ctl_JisyaHbnCd.value, 10);
		}
	}
}
