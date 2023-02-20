﻿/*-----------------------------------------------------------------------------
	モジュール:te030f01_event_n.js
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
    if (getAdvControlFromItemID("Shuturyoku_kbn")[0].checked == true) {
        getAdvControlFromItemID("Jyuryo_ymd_from").value = "";
        getAdvControlFromItemID("Jyuryo_ymd_to").value = "";
        itemDisabled(getAdvControlFromItemID("Jyuryo_ymd_from"), true);
        itemDisabled(getAdvControlFromItemID("Jyuryo_ymd_to"), true);
	}
	// 出力区分が「日付指定」の場合、変更日に前日を設定し入力可能にする。
	else if (getAdvControlFromItemID("Shuturyoku_kbn")[1].checked == true) {

	    //if (getAdvControlFromItemID("Jyuryo_ymd_from").value.length == 0 && getAdvControlFromItemID("Jyuryo_ymd_to").value.length == 0)
		//{	
		//	//営業日-1の値を設定する。	
	    //    getAdvControlFromItemID("Jyuryo_ymd_from").value = getAdvControlFromItemID("Jyuryo_ymd_hdn").value;
	    //    getAdvControlFromItemID("Jyuryo_ymd_to").value = getAdvControlFromItemID("Jyuryo_ymd_hdn").value;
		//}
	    itemDisabled(getAdvControlFromItemID("Jyuryo_ymd_from"), false);
	    itemDisabled(getAdvControlFromItemID("Jyuryo_ymd_to"), false);
	}
	
	//md共通処理ロード処理
	md_te030f01_register();
	
	//共通ロード設定
	setCommonLoad();
	
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
	
		//印刷ボタン
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

	    // 出力区分変更
	    case "Shuturyoku_kbn".toUpperCase():

	        // 出力区分が「未印刷分」の場合、変更日をクリアし入力不可にする。
	        if (getAdvControlFromItemID("Shuturyoku_kbn")[0].checked == true) {
	            getAdvControlFromItemID("Jyuryo_ymd_from").value = "";
	            getAdvControlFromItemID("Jyuryo_ymd_to").value = "";
	            itemDisabled(getAdvControlFromItemID("Jyuryo_ymd_from"), true);
	            itemDisabled(getAdvControlFromItemID("Jyuryo_ymd_to"), true);
	        }
	        // 出力区分が「日付指定」の場合、変更日に前日を設定し入力可能にする。
	        else if (getAdvControlFromItemID("Shuturyoku_kbn")[1].checked == true) {
	            getAdvControlFromItemID("Jyuryo_ymd_from").value = getAdvControlFromItemID("Jyuryo_ymd_hdn").value;
	            getAdvControlFromItemID("Jyuryo_ymd_to").value = getAdvControlFromItemID("Jyuryo_ymd_hdn").value;
	            itemDisabled(getAdvControlFromItemID("Jyuryo_ymd_from"), false);
	            itemDisabled(getAdvControlFromItemID("Jyuryo_ymd_to"), false);
	        }

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

	    case "Jyuryo_ymd_from".toUpperCase():	// 入荷日FROM
	        // FROMの値をTOへコピー
	        fromToCopy("Jyuryo_ymd");
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