// BO初期表示共通処理
//   呼出し例： boLoadCommon();
function boLoadCommon() {

	// モードなしの場合の表示制御(モード制御用)
	nonmodeDisp();

	// カレンダーボタン表示制御
	calenderToggleEvent();

	// 選択チェックボックスの定義
	selectorCheckBox = "M1selectorcheckbox";

	return;
}


// カレンダーボタン表示制御
function calenderToggleEvent() {
	if ($('.datepicker') && $('.datepicker').length != 0) {
		$('.datepicker').each(function (i, elem) {
			//該当テキストボックスの次の要素を取得
			var $nextelm = $(elem).next();
			//次要素がカレンダーボタンかどうかの判断
			if ($nextelm.hasClass('ui-datepicker-trigger')) {
				if ($(elem).disabled || $(elem).hasClass('txtDisabled')) {
					//カレンダーボタンを非表示
					$nextelm.hide();
				} else {
					//カレンダーボタンを表示
					$nextelm.show();
				}
			}
		});
	}
};
