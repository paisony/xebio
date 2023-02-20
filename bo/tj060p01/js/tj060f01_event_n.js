/*-----------------------------------------------------------------------------
	モジュール:tj060f01_event_n.js
--------------------------------------------------------------------------------*/
/*<title>[画面01CLイベントScript]</title>*/

/*-----------------------------------------------------------------------------
イベントキャプチャ開始処理
-----------------------------------------------------------------------------*/

/*-----------------------------------------------------------------------------
ロード処理
-----------------------------------------------------------------------------*/
function onLoad() {
	// formの初期化処理
	onLoadFormSet_adv();
	//明細のインデックスを調整する
	AdvGB_MCtrlStartIdx = 1;

	// Linkの初期化処理
	var linkCount = document.links.length;
	var docLink = document.links;
	for (var i=0;i<linkCount;i++){
		onLoadLinkSet_adv(docLink[i]);
	}

	// element毎の初期化処理
	var elemCount = AdvGB_TargetForm.elements.length;
	var elems = AdvGB_TargetForm.elements;
	for (var i=0; i<elemCount; i++){
		onLoadCtrlSet_adv(elems[i]);
	}

	// ここにロード時の追加固有処理を記述します。
	
	
	//md共通処理ロード処理
	md_tj060f01_register();
	
	//共通ロード設定
	setCommonLoad();

	/* hrefの値が消えてしまうため毎回設定 */
	document.all.item("Btnmodekonkai").href = "#tab22";
	document.all.item("Btnmodezenkai").href = "#tab23";

}

/*-----------------------------------------------------------------------------
アンロード処理
-----------------------------------------------------------------------------*/
function onUnLoad() {
	// ここにアンロード時の追加固有処理を記述します。
	
	return onUnLoad_adv();	//デフォルト処理
}

/*-----------------------------------------------------------------------------
サブミット処理
-----------------------------------------------------------------------------*/
function onSubmit() {
	//多重Submitの抑制
	if(AdvGB_SubmitFLG){
		return false;
	}
	
	//共通サブミット設定
	if (!setCommonOnSubmit(AdvGB_LastClickItemNm)) {
		return false;
	}
	
	//クライアント共通チェック
	if (isCommonCheck(AdvGB_LastClickItemNm.toUpperCase())) {
		if (!onSubmit_std(AdvGB_LastClickItemNm.toUpperCase())) {
			AdvGB_LastClickItemNm = null;
			return false;
		}
	}

	// ここに業務固有チェック処理を記述します。
	switch (AdvGB_LastClickItemNm.toUpperCase()) {
		// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
		case "Btnprint".toUpperCase():
			var yes = function () {
				$("#Btnprint")[0].click();
			}
			var no = function () {
			}
			var msg = getMessage("I100");

			if (boOpenInfoDialog(msg, yes, no) == false) {
				return false;
			}
			break;

			// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

		default:
			break;
	}

	AdvGB_SubmitFLG=true;
	return true;
}

/*-----------------------------------------------------------------------------
クリック処理
リンク・ボタン・Submit・ラジオボタン・チェックボックスなど
-----------------------------------------------------------------------------*/
function onClick(ev) {
	var eventTarget=getAdvEventTarget(ev);
	var eventTargetName=getAdvEventTargetName(ev);
	
	//共通クリック設定
	if (!setCommonOnClick(eventTarget, eventTargetName)) {
		return false;
	}
	
	switch (eventTargetName.toUpperCase()) {
		// ここに項目IDのcase文を追加し、固有処理を記述します。
		case "BTNMODEKONKAI":
		case "BTNMODEZENKAI":
		case "Btnmoderef".toUpperCase():
			// モードボタン共通処理
			tabClick(eventTargetName.toUpperCase());
			return false;

	default:
		break;
	}
	return onClick_adv(eventTarget);	//デフォルト処理
}

/*-----------------------------------------------------------------------------
チェンジ処理
ドロップダウンリストなど
-----------------------------------------------------------------------------*/
function onChange(ev) {
	var eventTarget=getAdvEventTarget(ev);
	var eventTargetName=getAdvEventTargetName(ev);
	switch (eventTargetName.toUpperCase()) {
	//  ここに項目IDのcase文を追加し、固有処理を記述します。
		// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

		case "Head_tenpo_cd".toUpperCase():	// ヘッダ店舗コード、棚卸実施日データ
			// 取得部品を起動
			V02019(getAdvControlFromItemID("Head_tenpo_cd"),
				   getAdvControlFromItemID("Head_tenpo_nm"),
				   getAdvControlFromItemID("Tanaorosijissi_ymd"),
				   getAdvControlFromItemID("Tanaorosikikan_from"),
				   getAdvControlFromItemID("Tanaorosikikan_to"),
				   getAdvControlFromItemID("Tanaorosijissi_ymd1"),
				   getAdvControlFromItemID("Tanaorosikikan_from1"),
				   getAdvControlFromItemID("Tanaorosikikan_to1"),
		           getAdvControlFromItemID("Head_tenpo_cd"));
			break;
			// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

	default:
		break;
	}
	return onChange_adv(eventTarget);	//デフォルト処理
}

/*-----------------------------------------------------------------------------
キープレス処理
-----------------------------------------------------------------------------*/
function onKeyPress(ev){
	var eventTarget=getAdvEventTarget(ev);
	var eventTargetName=getAdvEventTargetName(ev);
	switch (eventTargetName.toUpperCase()) {
	// ここに項目IDのcase文を追加し、固有処理を記述します。
	
	default:
		break;
	}
	return onKeyPress_adv(ev);	//デフォルト処理
}

/*-----------------------------------------------------------------------------
フォーカス処理
-----------------------------------------------------------------------------*/
function onFocus(ev) {
	var eventTarget=getAdvEventTarget(ev);
	var eventTargetName=getAdvEventTargetName(ev);
	switch (eventTargetName.toUpperCase()) {
	// ここに項目IDのcase文を追加し、固有処理を記述します。
	
	default:
		break;
	}
	return onFocus_adv(eventTarget);	//デフォルト処理
}

/*-----------------------------------------------------------------------------
ブラー処理
-----------------------------------------------------------------------------*/
function onBlur(ev) {
	var eventTarget=getAdvEventTarget(ev);
	var eventTargetName=getAdvEventTargetName(ev);
	switch (eventTargetName.toUpperCase()) {
	//  ここに項目IDのcase文を追加し、固有処理を記述します。
	
	default:
		break;
	}
	return onBlur_adv(eventTarget);	//デフォルト処理
}

/*-----------------------------------------------------------------------------
コード参照データセット出口ルーチン処理
-----------------------------------------------------------------------------*/
function onBeforeCodeSet(iDataArray,iItemId,iCodeId) {
	switch (iItemId) {
	//  ここに項目IDのcase文を追加し、固有処理を記述します。

		case "Btnheadtenpocd":	// ヘッダ店舗コードボタン
			// 取得部品を起動
			getAdvControlFromItemID("Head_tenpo_cd").value = iDataArray[0];
			V02019(getAdvControlFromItemID("Head_tenpo_cd"),
				   getAdvControlFromItemID("Head_tenpo_nm"),
				   getAdvControlFromItemID("Tanaorosijissi_ymd"),
				   getAdvControlFromItemID("Tanaorosikikan_from"),
				   getAdvControlFromItemID("Tanaorosikikan_to"),
				   getAdvControlFromItemID("Tanaorosijissi_ymd1"),
				   getAdvControlFromItemID("Tanaorosikikan_from1"),
				   getAdvControlFromItemID("Tanaorosikikan_to1"),
		           getAdvControlFromItemID("Head_tenpo_cd"));

	default:
		break;
	}
	return iDataArray;
}

