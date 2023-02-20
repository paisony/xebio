// 非同期通信
function searchCommonInner_RO_BO(conditionColumns, resultColumns, onAfterFlg, row, aspxName) {

	mdAsynchronousCancel = "";

	var requestUrl = MD_ASYNCHRONOUS_ROOT_PATH + aspxName;
	var xmlObject = createXmlObject_BO(conditionColumns, resultColumns, onAfterFlg, row);

	if (AjaxModel.dataClear) {
		resetResultColumns(resultColumns);
	}

	if (!xmlObject) {
		return;
	}

	send(xmlObject, requestUrl);
}
// 要求XMLの作成
function createXmlObject_BO(conditionColumns, resultColumns, onAfterFlg, row) {
	if (conditionColumns == null || resultColumns == null) {
		return null;
	}
	var xmlDoc = '<?xml version="1.0" encoding="utf-8"?>', root = document.createElement("request"), tmp;
	var inputF = 0;
	for (var c in conditionColumns) {
		tmp = conditionColumns[c];
		if (!tmp) {
			return null;
		}
		tmp = getValue(tmp);
		if (tmp != "") {
			// 入力値がある場合、フラグを立てる
			inputF = 1;
		}
		if (typeof conditionColumns[c] == "object" && conditionColumns[c].length != undefined) {
			var elt = document.createElement("replace");
			elt.setAttribute("column", c);
			elt.setAttribute("value", tmp);
			root.appendChild(elt)
		}
		else {
			var elt = document.createElement("condition");
			elt.setAttribute("column", c);
			elt.setAttribute("value", tmp);
			root.appendChild(elt)
		}
	}
	// 入力値が存在しない場合、処理を終了
	if (inputF == 0) {
		return null;
	}
	for (var r in resultColumns) {
		tmp = resultColumns[r];
		if (!tmp) {
			continue;
		}
		if (typeof tmp == "object" && tmp.length != undefined && tmp.nodeName != "SELECT") {
			for (var q = 0; q < tmp.length; q++) {
				var elt = document.createElement("result");
				elt.setAttribute("column", r);
				elt.setAttribute("bind_id", tmp[q].id);
				root.appendChild(elt)
			}
		}
		else {
			var elt = document.createElement("result");
			elt.setAttribute("column", r);
			elt.setAttribute("bind_id", tmp.id);
			elt.setAttribute("is_list", $(tmp).hasClass(CM_LIST_BOX));
			root.appendChild(elt)
		}
	}
	// 通信後のイベント有無フラグ有りの場合
	if (onAfterFlg == true) {
		var elt = document.createElement("onafter");
		// 再計算を行う場合の行数を属性に設定
		elt.setAttribute("recalcrow", row);
		root.appendChild(elt)

	}
	/*
	for (var r in readOnlyColumns) {
		tmp = readOnlyColumns[r];
		if (!tmp) {
			continue;
		}
		if (typeof tmp == "object" && tmp.length != undefined) {
			for (var q = 0; q < tmp.length; q++) {
				var elt = document.createElement("readOn");
				elt.setAttribute("Ro_column", r);
				elt.setAttribute("Ro_bind_id", tmp[q].id);
				root.appendChild(elt)
			}
		}
		else {
			var elt = document.createElement("readOn");
			elt.setAttribute("Ro_column", r);
			elt.setAttribute("Ro_bind_id", tmp.id);
			root.appendChild(elt)
		}
	}
	*/
	xmlDoc += root.outerHTML;
	return xmlDoc
}