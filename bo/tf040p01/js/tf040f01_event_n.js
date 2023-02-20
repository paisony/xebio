/*-----------------------------------------------------------------------------
	モジュール:tf040f01_event_n.js
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
	md_tf040f01_register();
	
	//共通ロード設定
	setCommonLoad();

	// --------------------------
	// BO初期表示共通処理
	boLoadCommon();
	// --------------------------
	
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

		// 検索ボタン
		case "Btnsearch".toUpperCase():

			// 明細が表示されている場合、
			// 確認メッセージを表示
			if ($('.str-wrap-result .str-result-item-01').css('display') == 'block') {
				//// 確認メッセージを表示
				var yes = function () {
					$("#Btnsearch")[0].click();
				}
				var no = function () {
				}
				var msg = getMessage("W113", "検索");
				return boOpenInfoDialog(msg, yes, no);
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
	var eventTargetName = getAdvEventTargetName(ev);

	// 明細行番号を取得する
	var lineNo = getItemMNofromCtrl(eventTarget);

	switch (eventTargetName.toUpperCase()) {
		//  ここに項目IDのcase文を追加し、固有処理を記述します。

		case "Head_tenpo_cd".toUpperCase():		// ヘッダ店舗コード
			// 名称取得部品を起動
			V02001(getAdvControlFromItemID("Head_tenpo_cd"), getAdvControlFromItemID("Head_tenpo_nm"), getAdvControlFromItemID("Head_tenpo_cd"));
			break;

		case "M1motokanri_no".toUpperCase():	// Ｍ１元管理No
			// 操作ありの背景色に変更
			commitColorSet(lineNo);
			break;

		case "M1keijo_ymd".toUpperCase():		// Ｍ１計上日付
			// 操作ありの背景色に変更
			commitColorSet(lineNo);
			break;

		case "M1kamoku_cd".toUpperCase():		// Ｍ１科目コード
			// 名称取得部品を起動
			V02021(getAdvControlFromItemID("M1kamoku_cd", lineNo), getAdvControlFromItemID("M1kamoku_nm", lineNo), getAdvControlFromItemID("M1kamoku_cd", lineNo));
			// 操作ありの背景色に変更
			commitColorSet(lineNo);
			break;

		case "M1nyukin".toUpperCase():			// Ｍ１入金
			// 合計値再計算
			calcRowNyukin(lineNo);
			// 操作ありの背景色に変更
			commitColorSet(lineNo);
			break;

		case "M1syukkin".toUpperCase():			// Ｍ１出金
			// 合計値再計算
			calcRowSyukkin(lineNo);
			// 操作ありの背景色に変更
			commitColorSet(lineNo);
			break;

		case "M1tekiyou".toUpperCase():			// Ｍ１摘要
			// 操作ありの背景色に変更
			commitColorSet(lineNo);
			break;
			
		case "M1hurikaetenpo_cd".toUpperCase():	// Ｍ１振替店舗コード
			// 名称取得部品を起動
			V02001(getAdvControlFromItemID("M1hurikaetenpo_cd", lineNo), getAdvControlFromItemID("M1hurikaetenpo_nm", lineNo), getAdvControlFromItemID("M1hurikaetenpo_cd", lineNo));
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


/*-----------------------------------------------------------------------------
ユーザ定義関数
-----------------------------------------------------------------------------*/
// 明細合計値計算関数
function calcRowNyukin(plineNo) {

	// 明細行番号を取得する
	var lineNo = plineNo;

	// 項目値取得
	var nyukin = getAdvControlFromItemID("M1nyukin", lineNo);			// Ｍ１入金
	var nyukin_hdn = getAdvControlFromItemID("M1nyukin_hdn", lineNo);	// Ｍ１入金(隠し)
	var zandaka = getAdvControlFromItemID("Gokei_zandaka");			// 合計残高
	
	// 合計残高再設定
	zandaka.value = formatComma(ToNumber(unFormatComma(zandaka.value)) + ToNumber(unFormatComma(nyukin.value)) - ToNumber(unFormatComma(nyukin_hdn.value)));
	nyukin_hdn.value = formatComma(nyukin.value);

}

function calcRowSyukkin(plineNo) {

	// 明細行番号を取得する
	var lineNo = plineNo;

	// 項目値取得
	var syukkin = getAdvControlFromItemID("M1syukkin", lineNo);			// Ｍ１出金
	var syukkin_hdn = getAdvControlFromItemID("M1syukkin_hdn", lineNo);	// Ｍ１出金（隠し）
	var zandaka = getAdvControlFromItemID("Gokei_zandaka");				// 合計残高
	
	// 合計残高再設定
	zandaka.value = formatComma(ToNumber(unFormatComma(zandaka.value)) - ToNumber(unFormatComma(syukkin.value)) + ToNumber(unFormatComma(syukkin_hdn.value)));
	syukkin_hdn.value = formatComma(syukkin.value);

}

