﻿/*-----------------------------------------------------------------------------
	モジュール:tc010f01_event_n.js
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

		// 出力区分が「入荷済」の場合、仕入予定日をクリアし入力不可にする。
		if (getAdvControlFromItemID("Denpyo_jyotai").value == "1") {
			//テキストの削除
			getAdvControlFromItemID("Nyukayotei_ymd_from").value = "";
			getAdvControlFromItemID("Nyukayotei_ymd_to").value = "";
			//仕入予定日をdisable
			itemDisabled(getAdvControlFromItemID("Nyukayotei_ymd_from"), true);
			itemDisabled(getAdvControlFromItemID("Nyukayotei_ymd_to"), true);
			//仕入確定日をable
			itemDisabled(getAdvControlFromItemID("Siire_kakutei_ymd_from"), false);
			itemDisabled(getAdvControlFromItemID("Siire_kakutei_ymd_to"), false);
		}
			// 出力区分が「未入荷」の場合、仕入確定日をクリアし入力不可にする。
		else if (getAdvControlFromItemID("Denpyo_jyotai").value == "2") {

			getAdvControlFromItemID("Siire_kakutei_ymd_from").value = "";
			getAdvControlFromItemID("Siire_kakutei_ymd_to").value = "";

			itemDisabled(getAdvControlFromItemID("Siire_kakutei_ymd_from"), true);
			itemDisabled(getAdvControlFromItemID("Siire_kakutei_ymd_to"), true);

			itemDisabled(getAdvControlFromItemID("Nyukayotei_ymd_from"), false);
			itemDisabled(getAdvControlFromItemID("Nyukayotei_ymd_to"), false);

		}
		else {
			itemDisabled(getAdvControlFromItemID("Nyukayotei_ymd_from"), false);
			itemDisabled(getAdvControlFromItemID("Nyukayotei_ymd_to"), false);
			itemDisabled(getAdvControlFromItemID("Siire_kakutei_ymd_from"), false);
			itemDisabled(getAdvControlFromItemID("Siire_kakutei_ymd_to"), false);
		}

	}

	// ここにロード時の追加固有処理を記述します。
	
	
	//md共通処理ロード処理
	md_tc010f01_register();
	
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
	//	// Ｆ２　削除
	//	case "BTNSKJ":
	//		// ＵＩＢＬＯＣＫにてメッセージＩ４０３：削除しますが、よろしいですか？
	//		return confirmPanel(event , "cmDelConfirm", getMessage("I403"));
	//	// Ｆ４　更新
	//	case "BTNKSN":
	//		// ＵＩＢＬＯＣＫにてメッセージＩ４０２：更新しますが、よろしいですか？
	//		return confirmPanel(event , "cmInsConfirm", getMessage("I402"));
	//	default:
	//		break;

		// 印刷ボタン
		case "Btnprint".toUpperCase():

			// 確認メッセージを表示
			var yes = function () {
				$("#Btnprint")[0].click();
			}
			var no = function () {
			}
			var msg = getMessage("I100");
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
	var eventTargetName = getAdvEventTargetName(ev);

	switch (eventTargetName.toUpperCase()) {

		case "Head_tenpo_cd".toUpperCase():	// ヘッダ店舗コード
			// 名称取得部品を起動
			V02001(getAdvControlFromItemID("Head_tenpo_cd"), getAdvControlFromItemID("Head_tenpo_nm"), getAdvControlFromItemID("Head_tenpo_cd"));
			break;
		//	default:
		//  ここに項目IDのcase文を追加し、固有処理を記述します。
		case "Denpyo_jyotai".toUpperCase():
			// 出力区分が「入荷済」の場合、仕入予定日をクリアし入力不可にする。
			if (getAdvControlFromItemID("Denpyo_jyotai").value == "1") {
				//テキストの削除
				getAdvControlFromItemID("Nyukayotei_ymd_from").value = "";
				getAdvControlFromItemID("Nyukayotei_ymd_to").value = "";
				//仕入予定日をdisable
				itemDisabled(getAdvControlFromItemID("Nyukayotei_ymd_from"), true);
				itemDisabled(getAdvControlFromItemID("Nyukayotei_ymd_to"), true);
				//仕入確定日をable
				itemDisabled(getAdvControlFromItemID("Siire_kakutei_ymd_from"), false);
				itemDisabled(getAdvControlFromItemID("Siire_kakutei_ymd_to"), false);
			}
				// 出力区分が「未入荷」の場合、仕入確定日をクリアし入力不可にする。
			else if (getAdvControlFromItemID("Denpyo_jyotai").value == "2") {

				getAdvControlFromItemID("Siire_kakutei_ymd_from").value = "";
				getAdvControlFromItemID("Siire_kakutei_ymd_to").value = "";

				itemDisabled(getAdvControlFromItemID("Siire_kakutei_ymd_from"), true);
				itemDisabled(getAdvControlFromItemID("Siire_kakutei_ymd_to"), true);

				itemDisabled(getAdvControlFromItemID("Nyukayotei_ymd_from"), false);
				itemDisabled(getAdvControlFromItemID("Nyukayotei_ymd_to"), false);

			}
			else
			{
				itemDisabled(getAdvControlFromItemID("Nyukayotei_ymd_from"), false);
				itemDisabled(getAdvControlFromItemID("Nyukayotei_ymd_to"), false);
				itemDisabled(getAdvControlFromItemID("Siire_kakutei_ymd_from"), false);
				itemDisabled(getAdvControlFromItemID("Siire_kakutei_ymd_to"), false);
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
	
		case "Nyukayotei_ymd_from".toUpperCase():	// 変更日FROM
			// FROMの値をTOへコピー
			fromToCopy("Nyukayotei_ymd");
			break;
		case "Siire_kakutei_ymd_from".toUpperCase():	// 変更日FROM
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

