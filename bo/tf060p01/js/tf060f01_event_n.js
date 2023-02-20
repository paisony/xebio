/*-----------------------------------------------------------------------------
	モジュール:tf060f01_event_n.js
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
	md_tf060f01_register();
	
	//共通ロード設定
	setCommonLoad();

	// --------------------------
	// BO初期表示共通処理
	boLoadCommon();
	// --------------------------

	// 行選択不可
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
			detailHide();
			AdvGB_LastClickItemNm = null;
			return false;
		}
	}

	// ここに業務固有チェック処理を記述します。
	switch (AdvGB_LastClickItemNm.toUpperCase()) {

		// 検索ボタン
		case "Btnsearch".toUpperCase():

			// 明細が表示されている場合
			if (getAdvControlFromItemID("Yosangokei_kin").value != "") {

				// 確認メッセージを表示
				var yes = function () {
					$("#Btnsearch")[0].click();
				}
				var no = function () {
				}

				var msg = getMessage("W113", ["検索"]);
				if (boOpenInfoDialog(msg, yes, no) == false) {
					return false;
				}

				// 月別部門１～５予算額をクリアする
				getAdvControlFromItemID("Tukibetu_bumon1_yosan_kin").value = "";
				getAdvControlFromItemID("Tukibetu_bumon2_yosan_kin").value = "";
				getAdvControlFromItemID("Tukibetu_bumon3_yosan_kin").value = "";
				getAdvControlFromItemID("Tukibetu_bumon4_yosan_kin").value = "";
				getAdvControlFromItemID("Tukibetu_bumon5_yosan_kin").value = "";
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

		case "Head_tenpo_cd".toUpperCase():	// ヘッダ店舗コード
			// 名称取得部品を起動
			V02001(getAdvControlFromItemID("Head_tenpo_cd"), getAdvControlFromItemID("Head_tenpo_nm"), getAdvControlFromItemID("Head_tenpo_cd"));
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

		case "Tukibetu_bumon1_yosan_kin".toUpperCase():	// 月別部門１予算額
		case "Tukibetu_bumon2_yosan_kin".toUpperCase():	// 月別部門２予算額
		case "Tukibetu_bumon3_yosan_kin".toUpperCase():	// 月別部門３予算額
		case "Tukibetu_bumon4_yosan_kin".toUpperCase():	// 月別部門４予算額
		case "Tukibetu_bumon5_yosan_kin".toUpperCase():	// 月別部門５予算額
			// 月別合計再計算
			calcTukibetu();
			break;

		case "M1bumon1_yosan_kin".toUpperCase():		// Ｍ１部門１予算額
		case "M1bumon2_yosan_kin".toUpperCase():		// Ｍ１部門２予算額
		case "M1bumon3_yosan_kin".toUpperCase():		// Ｍ１部門３予算額
		case "M1bumon4_yosan_kin".toUpperCase():		// Ｍ１部門４予算額
		case "M1bumon5_yosan_kin".toUpperCase():		// Ｍ１部門５予算額
			// 明細行番号を取得する
			var lineNo = getItemMNofromCtrl(eventTarget);
			// 予算合計再計算
			calcRow(lineNo, eventTargetName);
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
// 月別合計再計算
function calcTukibetu() {

	// 月別部門１予算額
	var tukibetu1 = 0;
	if (getAdvControlFromItemID("Tukibetu_bumon1_yosan_kin").value != null && getAdvControlFromItemID("Tukibetu_bumon1_yosan_kin").value != "") {
		tukibetu1 = ToNumber(unFormatComma(getAdvControlFromItemID("Tukibetu_bumon1_yosan_kin").value));
	}

	// 月別部門２予算額
	var tukibetu2 = 0;
	if (getAdvControlFromItemID("Tukibetu_bumon2_yosan_kin").value != null && getAdvControlFromItemID("Tukibetu_bumon2_yosan_kin").value != "") {
		tukibetu2 = ToNumber(unFormatComma(getAdvControlFromItemID("Tukibetu_bumon2_yosan_kin").value));
	}

	// 月別部門３予算額
	var tukibetu3 = 0;
	if (getAdvControlFromItemID("Tukibetu_bumon3_yosan_kin").value != null && getAdvControlFromItemID("Tukibetu_bumon3_yosan_kin").value != "") {
		tukibetu3 = ToNumber(unFormatComma(getAdvControlFromItemID("Tukibetu_bumon3_yosan_kin").value));
	}

	// 月別部門４予算額
	var tukibetu4 = 0;
	if (getAdvControlFromItemID("Tukibetu_bumon4_yosan_kin").value != null && getAdvControlFromItemID("Tukibetu_bumon4_yosan_kin").value != "") {
		tukibetu4 = ToNumber(unFormatComma(getAdvControlFromItemID("Tukibetu_bumon4_yosan_kin").value));
	}

	// 月別部門５予算額
	var tukibetu5 = 0;
	if (getAdvControlFromItemID("Tukibetu_bumon5_yosan_kin").value != null && getAdvControlFromItemID("Tukibetu_bumon5_yosan_kin").value != "") {
		tukibetu5 = ToNumber(unFormatComma(getAdvControlFromItemID("Tukibetu_bumon5_yosan_kin").value));
	}

	// 月別予算額合計
	var tukibetu_gokei = getAdvControlFromItemID("Tukibetu_yosan_kin_gokei");


	// 月別予算額合計に月別部門(１～５)予算額を全て加算する。
	tukibetu_gokei.value = formatComma(tukibetu1 + tukibetu2 + tukibetu3 + tukibetu4 + tukibetu5);

}

// 予算合計再計算
function calcRow(lineNo, eventTargetName) {

	var bumon_yosan;
	var bumon_yosan_hdn;
	var bumon_gokei;

	switch (eventTargetName.toUpperCase()) {

		case "M1bumon1_yosan_kin".toUpperCase():		// Ｍ１部門１予算額
			bumon_yosan = getAdvControlFromItemID("M1bumon1_yosan_kin", lineNo);
			bumon_yosan_hdn = getAdvControlFromItemID("M1bumon1_yosan_kin_hdn", lineNo);
			bumon_gokei = getAdvControlFromItemID("Bumon1_yosangokei_kin");
			break;
		case "M1bumon2_yosan_kin".toUpperCase():		// Ｍ１部門２予算額
			bumon_yosan = getAdvControlFromItemID("M1bumon2_yosan_kin", lineNo);
			bumon_yosan_hdn = getAdvControlFromItemID("M1bumon2_yosan_kin_hdn", lineNo);
			bumon_gokei = getAdvControlFromItemID("Bumon2_yosangokei_kin");
			break;
		case "M1bumon3_yosan_kin".toUpperCase():		// Ｍ１部門３予算額
			bumon_yosan = getAdvControlFromItemID("M1bumon3_yosan_kin", lineNo);
			bumon_yosan_hdn = getAdvControlFromItemID("M1bumon3_yosan_kin_hdn", lineNo);
			bumon_gokei = getAdvControlFromItemID("Bumon3_yosangokei_kin");
			break;
		case "M1bumon4_yosan_kin".toUpperCase():		// Ｍ１部門４予算額
			bumon_yosan = getAdvControlFromItemID("M1bumon4_yosan_kin", lineNo);
			bumon_yosan_hdn = getAdvControlFromItemID("M1bumon4_yosan_kin_hdn", lineNo);
			bumon_gokei = getAdvControlFromItemID("Bumon4_yosangokei_kin");
			break;
		case "M1bumon5_yosan_kin".toUpperCase():		// Ｍ１部門５予算額
			bumon_yosan = getAdvControlFromItemID("M1bumon5_yosan_kin", lineNo);
			bumon_yosan_hdn = getAdvControlFromItemID("M1bumon5_yosan_kin_hdn", lineNo);
			bumon_gokei = getAdvControlFromItemID("Bumon5_yosangokei_kin");
			break;

		default:
			break;
	}

	// Ｍ１日別予算額
	var hibetu_gokei = getAdvControlFromItemID("M1hibetu_yosan_kin", lineNo);

	// 予算額合計
	var yosan_gokei = getAdvControlFromItemID("Yosangokei_kin");

	var yosan_kin = 0;
	if (bumon_yosan.value != null && bumon_yosan.value != "") {
		yosan_kin = ToNumber(unFormatComma(bumon_yosan.value));
	}

	var yosan_kin_hdn = 0;
	if (bumon_yosan_hdn.value != null && bumon_yosan_hdn.value != "") {
		yosan_kin_hdn = ToNumber(unFormatComma(bumon_yosan_hdn.value));
	}

	// Ｍ１部門(１～５)予算額とＭ１部門(１～５)予算額(隠し)の差分を取得し、Ｍ１日別予算額に加算(減算)する。
	hibetu_gokei.value = formatComma(ToNumber(unFormatComma(hibetu_gokei.value)) - (yosan_kin_hdn - yosan_kin));

	// Ｍ１部門(１～５)予算額とＭ１部門(１～５)予算額(隠し)の差分を取得し、部門(１～５)予算額合計に加算(減算)する。
	bumon_gokei.value = formatComma(ToNumber(unFormatComma(bumon_gokei.value)) - (yosan_kin_hdn - yosan_kin));

	// Ｍ１部門(１～５)予算額とＭ１部門(１～５)予算額(隠し)の差分を取得し、予算額合計に加算(減算)する。
	yosan_gokei.value = formatComma(ToNumber(unFormatComma(yosan_gokei.value)) - (yosan_kin_hdn - yosan_kin));

	// Ｍ１部門(１～５)予算額(隠し)にＭ１部門(１～５)予算額を設定する。
	bumon_yosan_hdn.value = yosan_kin;

}

