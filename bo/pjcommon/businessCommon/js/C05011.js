// FROM-TOコピー処理
//   呼出し例： fromToCopy("Siji_bango");
function fromToCopy(clm) {

	var fromObj = getAdvControlFromItemID(clm + "_from");
	var toObj = getAdvControlFromItemID(clm + "_to");

	if (toObj.value == "") {
		toObj.value = fromObj.value;

		// TOのロストフォーカス処理を実行 ※フォーマット処理を実行する為
		onBlur_adv(toObj);

		// 名称ラベルが存在する場合、名称もコピー
		if (clm.substr(clm.length - 2) == "cd") {
			var clm_nm = clm.substr(0, clm.length - 2) + "nm";

			var nmFromObj;
			var nmToObj;
			if (document.all.item(clm_nm + "_from") != null
				&& document.all.item(clm_nm + "_to") != null) {
				nmFromObj = getAdvControlFromItemID(clm_nm + "_from");
				nmToObj = getAdvControlFromItemID(clm_nm + "_to");

				nmToObj.value = nmFromObj.value;
				onBlur_adv(nmFromObj);
			}

		}

	}
	return;
}
// FROM-TOコピー処理(ラベル用)
//   呼出し例： fromToCopy("Siji_bango");
function fromToCopyLbl(cdclm, lblclm) {

	var cdfromObj = getAdvControlFromItemID(cdclm + "_from");
	var cdtoObj = getAdvControlFromItemID(cdclm + "_to");
	var lblfromObj = getAdvControlFromItemID(lblclm + "_from");
	var lbltoObj = getAdvControlFromItemID(lblclm + "_to");

	// TOのロストフォーカス処理を実行
	cdtoObj.value = getAdvFormat(cdtoObj);
	if (cdfromObj.value == cdtoObj.value) {
		lbltoObj.value = lblfromObj.value;
		lblfromObj.value = getAdvFormat(lblfromObj);
	}
	// フォーカス設定がToのテキストの場合、フォーカス再設定
	if (document.activeElement == cdtoObj) {
		onFocus_adv(cdtoObj);
	}
	return;
}

// FROM-TOコピー処理(変数名指定)
//   呼出し例： fromToCopyObjId("Face_no_from1","Face_no_to2" );
function fromToCopyObjId(clm_from, clm_to) {

	var fromObj = getAdvControlFromItemID(clm_from);
	var toObj = getAdvControlFromItemID(clm_to);

	if (toObj.value == "") {
		toObj.value = fromObj.value;

		// TOのロストフォーカス処理を実行 ※フォーマット処理を実行する為
		onBlur_adv(toObj);
	}
	return;
}
