/*-----------------------------------------------------------------------------
	モジュール:tf030f02_event_n.js
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
	md_tf030f02_register();
	
	//共通ロード設定
	setCommonLoad();

	// --------------------------
	// BO初期表示共通処理
	boLoadCommon();
	// --------------------------

	// モードが「新規作成」「修正」以外の場合、明細を選択不可とする。
	if (getAdvControlFromItemID(clm_StkMode).value == c_insert
		|| getAdvControlFromItemID(clm_StkMode).value == c_modeupd) {
		selectorCheckBox = '';
	} else {
		selectorCheckBox = 'DISABLED';
	}
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

			// モードの取得
			var mode = getAdvControlFromItemID(clm_StkMode).value

			// 「新規作成」「修正」モードの場合
			if (mode == c_insert || mode == c_modeupd) {

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
			if (boOpenInfoDialog(msg, yes, no) == false) {
				return false;
			}
			break;

		// 行削除ボタン
		case "Btnrowdel".toUpperCase():
			// 確認メッセージを表示
			var yes = function () {
				$("#Btnrowdel")[0].click();
			}
			var no = function () {
			}
			var msg = getMessage("W119");
			if (boOpenInfoDialog(msg, yes, no) == false) {
				return false;
			}
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

		case "Tenpo_cd".toUpperCase():	// 店舗コード
			// 名称取得部品を起動
			V02001(getAdvControlFromItemID("Tenpo_cd"), getAdvControlFromItemID("Tenpo_nm"), getAdvControlFromItemID("Tenpo_cd"));
			break;

		case "Kenpinsya_cd".toUpperCase():// 検品者コード
			// 名称取得部品を起動
			V02005(getAdvControlFromItemID("Kenpinsya_cd"), getAdvControlFromItemID("Kenpinsya_nm"), getAdvControlFromItemID("Kenpinsya_cd"));
			break;

		case "Siiresaki_cd".toUpperCase():	// 仕入先コード
			// 名称取得部品を起動
			V02002(getAdvControlFromItemID("Siiresaki_cd"), getAdvControlFromItemID("Siiresaki_ryaku_nm"), getAdvControlFromItemID("Siiresaki_cd"));
			break;

		case "M1tekiyo_cd".toUpperCase():	// 摘要コード
			// 明細行番号を取得する
			var lineNo = getItemMNofromCtrl(eventTarget);
			// 名称取得部品を起動
			V02023(getAdvControlFromItemID("M1tekiyo_cd", lineNo), getAdvControlFromItemID("M1tekiyo_nm", lineNo), getAdvControlFromItemID("M1tekiyo_cd", lineNo));
			// 操作ありの背景色に変更
			commitColorSet(lineNo);
			break;

		case "M1suryo".toUpperCase():		// 数量
		case "M1tnk".toUpperCase():			// 単価
			// 明細行番号を取得する
			var lineNo = getItemMNofromCtrl(eventTarget);
			// 操作ありの背景色に変更
			commitColorSet(lineNo);
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

		case "M1suryo".toUpperCase():		// 数量
		case "M1tnk".toUpperCase():			// 単価
			// 明細行番号を取得する
			var lineNo = getItemMNofromCtrl(eventTarget);
			// 合計値再計算
			calcRow(lineNo);
			break;

	default:
		break;
	}
	return onBlur_adv(eventTarget);	//デフォルト処理
}

/*-----------------------------------------------------------------------------
コード参照データセット出口ルーチン処理
-----------------------------------------------------------------------------*/
function onBeforeCodeSet(iDataArray,iItemId,iCodeId) {

	// ボタンID取得
	var itemnm = iItemId;
	// $区切りで名称を分割
	var item = iItemId.split("$");
	if (item.length >= 3) {
		// 明細項目の場合、行番号、項目名を取得
		rowno = ToNumber(item[1].replace("ctl", "")) - 1;
		itemnm = item[2];
	}

	switch (itemnm.toUpperCase()) {
		//  ここに項目IDのcase文を追加し、固有処理を記述します。
		case "M1btntekiyo_cd".toUpperCase():	// 摘要コード検索

			// 操作ありの背景色に変更
			commitColorSet(rowno);
			break;
		default:
			break;
	}
	return iDataArray;
}

/*-----------------------------------------------------------------------------
ユーザ定義関数
-----------------------------------------------------------------------------*/
// 明細合計値計算関数
function calcRow(lineNo) {

	// Ｍ１数量
	var suryo = getAdvControlFromItemID("M1suryo", lineNo);
	// Ｍ１単価
	var tanka = getAdvControlFromItemID("M1tnk", lineNo);
	// Ｍ１金額
	var kingaku = getAdvControlFromItemID("M1kingaku", lineNo);
	// Ｍ１数量(隠し)
	var suryo_hdn = getAdvControlFromItemID("M1suryo_hdn", lineNo);
	// Ｍ１金額(隠し)
	var kingaku_hdn = getAdvControlFromItemID("M1kingaku_hdn", lineNo);
	// 合計数量
	var gokei_suryo = getAdvControlFromItemID("Gokei_suryo");
	// 合計金額
	var gokei_kin = getAdvControlFromItemID("Gokei_kin");

	var su = 0;
	if (suryo.value != null && suryo.value != "") {
		su = ToNumber(unFormatComma(suryo.value));
	}

	var tn = 0;
	if (tanka.value != null && tanka.value != "") {
		tn = ToNumber(unFormatComma(tanka.value));
	}

	// Ｍ１数量×Ｍ１単価をＭ１金額に設定する。
	kingaku.value = formatComma(su * tn);

	// Ｍ１数量とＭ１数量(隠し)の差分を取得し、合計数量に加算(減算)する。
	gokei_suryo.value = formatComma(ToNumber(unFormatComma(gokei_suryo.value)) - (ToNumber(unFormatComma(suryo_hdn.value)) - su));

	// Ｍ１数量(隠し)にＭ１数量を設定する。
	suryo_hdn.value = su;

	// Ｍ１原価金額とＭ１原価金額(隠し)の差分を取得し、合計原価金額に加算(減算)する。
	gokei_kin.value = formatComma(ToNumber(unFormatComma(gokei_kin.value)) - (ToNumber(unFormatComma(kingaku_hdn.value)) - ToNumber(unFormatComma(kingaku.value))));

	// Ｍ１原価金額(隠し)にＭ１原価金額を設定する。
	kingaku_hdn.value = kingaku.value;

	// Ｍ１数量、またはＭ１単価が空白の場合、Ｍ１原価金額を空白にする。
	if (suryo.value == "" || tanka.value == "") {
		kingaku.value = "";
	}

}

