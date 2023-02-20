// コード参照出口ルーチン共通処理
//   呼出し例： boCommonCodeRef(iItemId);
function boCommonCodeRef(item) {

	if (item == 'Btnheadtenpocd') {
		// 項目名の5文字名以降を取り出す
		itemSetFocus(getAdvControlFromItemID('Head_tenpo_cd'));
	} else {
		// 項目名の4文字名以降を取り出す
		var itemnm = item.substr(3);
		itemnm = itemnm.substr(0, 1).toUpperCase() + itemnm.substr(1);
		if (getAdvControlFromItemID(itemnm)) {
			itemSetFocus(getAdvControlFromItemID(itemnm));
		}
	}
}
