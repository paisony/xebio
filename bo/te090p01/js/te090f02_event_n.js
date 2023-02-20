/*-----------------------------------------------------------------------------
	モジュール:te090f02_event_n.js
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
	md_te090f02_register();
	
	//共通ロード設定
	setCommonLoad();

	// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
	// --------------------------
	// BO初期表示共通処理
	boLoadCommon();
	// --------------------------

	// 行選択不可
	selectorCheckBox = 'DISABLED';
	// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
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
		// 戻るボタン
		case "Btnback".toUpperCase():
			if (	(
						getAdvControlFromItemID(clm_StkMode).value == c_modenyukakakutei	// 入荷確定
					&& !getAdvControlFromItemID("Btnenter").disabled						// 確定ボタン有効
					)
				|| getAdvControlFromItemID(clm_StkMode).value == c_modekakuteigoupd		// 確定後修正
				) {
				// 確認メッセージを表示
				var yes = function () {
					$("#Btnback")[0].click();
				}
				var no = function () {
				}
				var msg = getMessage("W107");
				if (!boOpenInfoDialog(msg, yes, no)) {
					// いいえの場合、処理終了
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
			if (!boOpenInfoDialog(msg, yes, no)) {
				// いいえの場合、処理終了
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
		// Ｍ１確定数
		case "M1kakutei_su".toUpperCase():

			// 明細行番号を取得する
			var lineNo = getItemMNofromCtrl(eventTarget);

			// 予定数量と確定数量が異なる場合は文字色を赤色に変更
			if (getAdvControlFromItemID("M1yotei_su", lineNo).value == getAdvControlFromItemID("M1kakutei_su", lineNo).value
				|| getAdvControlFromItemID("M1kakutei_su", lineNo).value == "") {
				getAdvControlFromItemID("M1kakutei_su", lineNo).style.color = "black";
			} else {
				getAdvControlFromItemID("M1kakutei_su", lineNo).style.color = "red";
			}

			// 合計値再計算
			calcRow(lineNo);

			// 操作ありの背景色に変更
			commitColorSet(lineNo);

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

	default:
		break;
	}
	return iDataArray;
}

// 明細合計値計算関数
function calcRow(lineNo) {

	// Ｍ１予定数量
	var yoteisu = getAdvControlFromItemID("M1yotei_su", lineNo);

	// Ｍ１確定数量
	var kakuteisu = getAdvControlFromItemID("M1kakutei_su", lineNo);
	// Ｍ１確定数量(隠し)
	var kakuteisuHid = getAdvControlFromItemID("M1kakutei_su_hdn", lineNo);

	// Ｍ１原単価
	var genka = getAdvControlFromItemID("M1gen_tnk", lineNo);

	// Ｍ１原価金額
	var genkaKin = getAdvControlFromItemID("M1genka_kin", lineNo);
	// Ｍ１原価金額(隠し)
	var genkaKinHid = getAdvControlFromItemID("M1genkakin_hdn", lineNo);

	// 合計確定数量
	var sumKakusu = getAdvControlFromItemID("Gokeikakutei_su");
	// 原価金額合計
	var sumGenkaKin = getAdvControlFromItemID("Genka_kin_gokei");

	// 選択モードNo
	var mode = getAdvControlFromItemID(clm_StkMode).value;

	// ■計算用数量の設定
	var suryo = 0;
	if (kakuteisu.value == "") {
		// 未入力の場合
		suryo = ToNumber(unFormatComma(yoteisu.value));
	} else {
		suryo = ToNumber(unFormatComma(kakuteisu.value));
	}

	/*
		■Ｍ１原価金額の算出
		[Ｍ１原単価]×[計算用数量]
	*/
	genkaKin.value = formatComma(ToNumber(unFormatComma(genka.value)) * suryo);

	/*
		■合計確定数量の算出
		[計算用数量]と[Ｍ１確定数量(隠し)]の差分を取得し、[合計確定数量]に加算(減算)する。
		[Ｍ１確定数量(隠し)]に[計算用数量]を設定する。
	*/
	sumKakusu.value = formatComma(ToNumber(unFormatComma(sumKakusu.value)) + (suryo - ToNumber(unFormatComma(kakuteisuHid.value))));
	kakuteisuHid.value = formatComma(suryo);

	/*
		■原価金額合計の算出
		[Ｍ１原価金額]と[Ｍ１原価金額(隠し)]の差分を取得し、[原価金額合計]に加算(減算)する。
		[Ｍ１原価金額(隠し)]に[Ｍ１原価金額]を設定する。
	*/
	sumGenkaKin.value = formatComma(ToNumber(unFormatComma(sumGenkaKin.value)) + (ToNumber(unFormatComma(genkaKin.value)) - ToNumber(unFormatComma(genkaKinHid.value))));
	genkaKinHid.value = genkaKin.value;
}
