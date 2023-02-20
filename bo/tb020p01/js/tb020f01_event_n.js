/*-----------------------------------------------------------------------------
	モジュール:tb020f01_event_n.js
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
	md_tb020f01_register();
	
	//共通ロード設定
	setCommonLoad();

    // --------------------------
    // BO初期表示共通処理
	boLoadCommon();
    // --------------------------
	
	if (getAdvControlFromItemID("Scm_jotai").value == "0") {

		itemDisabled(getAdvControlFromItemID("Siire_kakutei_ymd_from"), true);
		itemDisabled(getAdvControlFromItemID("Siire_kakutei_ymd_to"), true);
	} else {

		itemDisabled(getAdvControlFromItemID("Siire_kakutei_ymd_from"), false);
		itemDisabled(getAdvControlFromItemID("Siire_kakutei_ymd_to"), false);
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
			// -----------------------
			// モードなしの表示に戻す
			document.all.item(clm_StkMode).value = "";
			nonmodeDisp();
			// -----------------------
			AdvGB_LastClickItemNm = null;
			return false;
		}
	}

	// ここに業務固有チェック処理を記述します。
	switch (AdvGB_LastClickItemNm.toUpperCase()) {

		// 印刷ボタン
		case "Btnprint".toUpperCase():

			// 確認メッセージを表示
			var yes = function () {
				$("#Btnprint")[0].click();
			}
			var no = function () {
			}
			var msg = getMessage("I100");
			if (boOpenInfoDialog(msg, yes, no) == false) {
				// いいえの場合、処理終了
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

	case "Head_tenpo_cd".toUpperCase():	// ヘッダ店舗コード
		// 名称取得部品を起動
		V02001(getAdvControlFromItemID("Head_tenpo_cd"), getAdvControlFromItemID("Head_tenpo_nm"), getAdvControlFromItemID("Head_tenpo_cd"));
		break;
	case "Siiresaki_cd".toUpperCase():	// 仕入先コード
		// 名称取得部品を起動
		V02002_MAIN(getAdvControlFromItemID("Siiresaki_cd"), getAdvControlFromItemID("Siiresaki_ryaku_nm"), getAdvControlFromItemID("Siiresaki_cd"), 0);
		break;
	
	// SCM状態
	case "Scm_jotai".toUpperCase():
		if (getAdvControlFromItemID("Scm_jotai").value == "0")
		{
			//→ 未処理に変更した場合・・・仕入確定日FROM、仕入確定日TOを空白にする。
			getAdvControlFromItemID("Siire_kakutei_ymd_from").value = "";
			getAdvControlFromItemID("Siire_kakutei_ymd_to").value = "";

			itemDisabled(getAdvControlFromItemID("Siire_kakutei_ymd_from"), true);
			itemDisabled(getAdvControlFromItemID("Siire_kakutei_ymd_to"), true);
		} else {
			var eigyo_ymd = getAdvControlFromItemID("Eigyo_ymd_hdn").value;

			getAdvControlFromItemID("Siire_kakutei_ymd_from").value = eigyo_ymd;
			getAdvControlFromItemID("Siire_kakutei_ymd_to").value = eigyo_ymd;

			itemDisabled(getAdvControlFromItemID("Siire_kakutei_ymd_from"), false);
			itemDisabled(getAdvControlFromItemID("Siire_kakutei_ymd_to"), false);

			getAdvControlFromItemID("Scm_jotai").focus();
		}
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

		case "Nyukayotei_ymd_from".toUpperCase():		// 入荷予定日
		// FROMの値をTOへコピー
			fromToCopy("Nyukayotei_ymd");
		break;
		case "Siire_kakutei_ymd_from".toUpperCase():	// 仕入確定日
		// FROMの値をTOへコピー
			fromToCopy("Siire_kakutei_ymd");
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

