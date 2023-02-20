/*-----------------------------------------------------------------------------
	モジュール:tl030f02_event_n.js
--------------------------------------------------------------------------------*/
/*<title>[画面02CLイベントScript]</title>*/

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
	md_tl030f02_register();
	
	//共通ロード設定
	setCommonLoad();
	
	// --------------------------
	// BO初期表示共通処理
	boLoadCommon();
	// --------------------------
	selectorCheckBox = 'DISABLED';
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
		// 戻るボタン
		case "Btnback".toUpperCase():

			// 確定ボタンが有効
			if (!getAdvControlFromItemID("Btnenter").disabled)
			{
				// 確認メッセージを表示
				var yes = function () {
					$("#Btnback")[0].click();
				}
				var no = function () {
				}
				var msg = getMessage("W107");
				if (boOpenInfoDialog(msg, yes, no) == false) {
					return false;
				}
			}

			break;
		// 確定ボタン
		case "Btnenter".toUpperCase():

			// 確認メッセージを表示
			var yes = function () {
				$("#Btnenter")[0].click();
			}
			var no = function () {
			}
			var msg = getMessage("I102");
			return boOpenInfoDialog(msg, yes, no);
			break;
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
		case "M1syonin_flg".toUpperCase():// ｍ１承認状態

			// 明細行番号を取得する
			var lineNo = getItemMNofromCtrl(eventTarget);

			// 操作ありの背景色に変更
			commitColorSet(lineNo);

			// [Ｍ１確定フラグ(隠し)]に"1"を設定する。
			if (getAdvControlFromItemID("M1syonin_flg", lineNo).checked)
			{
				getAdvControlFromItemID("M1entersyoriflg", lineNo).value = 1;
			}
			else
			{
				getAdvControlFromItemID("M1entersyoriflg", lineNo).value = 0;
			}

			// [Ｍ１却下フラグ]が入力済みの場合、未入力にする。
			getAdvControlFromItemID("M1kyakka_flg", lineNo).checked = false;

			break;

		case "M1kyakka_flg".toUpperCase():// Ｍ１却下フラグ

			// 明細行番号を取得する
			var lineNo = getItemMNofromCtrl(eventTarget);

			// 操作ありの背景色に変更
			commitColorSet(lineNo);

			// [Ｍ１確定フラグ(隠し)]に"1"を設定する。
			if (getAdvControlFromItemID("M1kyakka_flg", lineNo).checked) {
				getAdvControlFromItemID("M1entersyoriflg", lineNo).value = 1;
			}
			else {
				getAdvControlFromItemID("M1entersyoriflg", lineNo).value = 0;
			}

			// [Ｍ１却下フラグ]が入力済みの場合、未入力にする。
			getAdvControlFromItemID("M1syonin_flg", lineNo).checked = false;

			break;

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

		// -------------------
		// 確定売価
		// -------------------
		case "M1kakuteibaika_tnk".toUpperCase():

			// 明細行番号を取得する
			var lineNo = getItemMNofromCtrl(eventTarget);

			// 確定売価
			var kakuteBaika = getAdvControlFromItemID("M1kakuteibaika_tnk", lineNo);
			// 値入率売変後
			var neire_rtu_baihengo = getAdvControlFromItemID("M1neire_rtu_baihengo", lineNo);
			// 原単価
			var gen_tnk = getAdvControlFromItemID("M1gen_tnk", lineNo);

			// 0だったら値入率売変後に0を設定する
			if (ToNumber(unFormatComma(kakuteBaika.value)) == 0)
			{
				neire_rtu_baihengo.value = 0.0;
			}
			else
			{
				// 値入率売変後の再計算を行う
				// 値入率売変後＝（[M1確定売価] － [M1原単価]）／[M1確定売価]
				neire_rtu_baihengo.value = (ToNumber(unFormatComma(kakuteBaika.value)) - ToNumber(unFormatComma(gen_tnk.value))) / ToNumber(unFormatComma(kakuteBaika.value)) * 100;
			}

			// フォーマット処理
			neire_rtu_baihengo.value = getAdvFormatStr("M1neire_rtu_baihengo", neire_rtu_baihengo.value);
			break;
	
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

	default:
		break;
	}
	return iDataArray;
}

