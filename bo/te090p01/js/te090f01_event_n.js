/*-----------------------------------------------------------------------------
	モジュール:te090f01_event_n.js
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
	md_te090f01_register();
	
	//共通ロード設定
	setCommonLoad();

	// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
	// --------------------------
	// BO初期表示共通処理
	boLoadCommon();
	// --------------------------

	// 出荷店コード表示制御
	SyukkatenControl();

	// [選択モードNO]が「入荷確定」「確定後取消」以外の場合、明細は選択不可とする。
	if (getAdvControlFromItemID(clm_StkMode).value != c_modenyukakakutei
		&& getAdvControlFromItemID(clm_StkMode).value != c_modekakuteigodel) {
		selectorCheckBox = 'DISABLED';
	}

	// hrefの値が消えてしまうので毎回設定
	document.all.item("Btnmodenyukakakutei").href = "#tab3";	// 入荷確定
	document.all.item("Btnmodekakuteigoupd").href = "#tab10";	// 確定後修正
	document.all.item("Btnmodekakuteigodel").href = "#tab13";	// 確定後取消
	document.all.item("Btnmoderef").href = "#tab16";			// 照会
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
		// 検索ボタン
		case "Btnsearch".toUpperCase():
			if (getAdvControlFromItemID(clm_StkMode).value == c_modenyukakakutei		// 入荷確定
				|| getAdvControlFromItemID(clm_StkMode).value == c_modekakuteigodel) {	// 確定後取消
				// 確認メッセージを表示
				var yes = function () {
					$("#Btnsearch")[0].click();
				}
				var no = function () {
				}
				var msg = getMessage("W113", "検索");
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

		// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
		// タブ処理
		case "Btnmodenyukakakutei".toUpperCase():
		case "Btnmodekakuteigoupd".toUpperCase():
		case "Btnmodekakuteigodel".toUpperCase():
		case "Btnmoderef".toUpperCase():
			// モードボタン共通処理
			tabClick(eventTargetName.toUpperCase());
			return false;
		// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

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
		case "Head_tenpo_cd".toUpperCase():	// ヘッダ店舗コード
			// 名称取得部品を起動
			V02001(getAdvControlFromItemID("Head_tenpo_cd"), getAdvControlFromItemID("Head_tenpo_nm"), getAdvControlFromItemID("Head_tenpo_cd"));
			break;
		case "Kaisya_cd".toUpperCase():		// 会社コード
			// 名称取得部品を起動
			V02006_MAIN(getAdvControlFromItemID("Kaisya_cd"), getAdvControlFromItemID("Kaisya_nm"), getAdvControlFromItemID("Kaisya_cd"), 0);
			break;
		case "Syukkaten_cd".toUpperCase():	// 出荷店コード
			// 名称取得部品を起動
			V02026_MAIN(getAdvControlFromItemID("Kaisya_cd"), getAdvControlFromItemID("Syukkaten_cd"), getAdvControlFromItemID("Syukkaten_nm"), getAdvControlFromItemID("Syukkaten_cd"), null, 0);
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
	
	case "Kaisya_cd".toUpperCase():
		if (ev.key == "Enter" && !ev.shiftKey) {
			// Enterキー押下時
			// 出荷店コード表示制御
			SyukkatenControl();
			if (getAdvControlFromItemID("Kaisya_cd").value == "") {
				// 会社コードが未設定の場合
				// 次の項目にフォーカス
				getAdvControlFromItemID("Denpyo_bango_from").focus();
			}
		}
		break;

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

		// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
		case "Kaisya_cd".toUpperCase():				// 会社コード
			// 出荷店コード表示制御
			SyukkatenControl();
			break;
		case "Denpyo_bango_from".toUpperCase():		// 伝票番号ＦＲＯＭ
			// FROMの値をTOへコピー
			fromToCopy("Denpyo_bango");
			break;
		case "Scm_cd".toUpperCase():				// SCMコード
			// SCMコード丸め処理
			formatScmCd(getAdvControlFromItemID("Scm_cd"));
			break;
		case "Syukka_ymd_from".toUpperCase():		// 出荷日ＦＲＯＭ
			// FROMの値をTOへコピー
			fromToCopy("Syukka_ymd");
			break;
		// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

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
/**
 * 出荷店の表示制御を行う
 */
function SyukkatenControl() {
	// 会社コードが未設定の場合
	if (getAdvControlFromItemID("Kaisya_cd").value == "") {
		// 出荷店コードを使用不可
		getAdvControlFromItemID("Syukkaten_cd").value = "";
		getAdvControlFromItemID("Syukkaten_nm").value = "";
		itemDisabled(getAdvControlFromItemID("Syukkaten_cd"), true);
	} else {
		// 出荷店コードを使用可
		itemDisabled(getAdvControlFromItemID("Syukkaten_cd"), false);
	}
}
