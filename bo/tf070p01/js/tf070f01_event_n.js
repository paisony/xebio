/*-----------------------------------------------------------------------------
	モジュール:tf070f01_event_n.js
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
	md_tf070f01_register();
	
	//共通ロード設定
	setCommonLoad();

	// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
	// --------------------------
	// BO初期表示共通処理
	boLoadCommon();
	// --------------------------

	// [選択モードNO]が「申請済取消」「取消」「照会」以外の場合、明細は選択不可とする。
	if (getAdvControlFromItemID(clm_StkMode).value != c_modesinseitorikesi
		&& getAdvControlFromItemID(clm_StkMode).value != c_modedel
		&& getAdvControlFromItemID(clm_StkMode).value != c_moderef) {
			selectorCheckBox = 'DISABLED';
	}

	// hrefの値が消えてしまうので毎回設定
	document.all.item("Btnmodekeihisinsei").href = "#tab24";		// 経費申請
	document.all.item("Btnmodesinseitorikesi").href = "#tab14";		// 申請済取消
	document.all.item("Btnmodeupd").href = "#tab8";					// 修正
	document.all.item("Btnmodedel").href = "#tab11";				// 取消
	document.all.item("Btnmoderef").href = "#tab16";				// 照会
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
		// 新規作成ボタン
		case "Btninsert".toUpperCase():
			if (getAdvControlFromItemID(clm_StkMode).value == c_modesinseitorikesi	// 申請済取消
				|| getAdvControlFromItemID(clm_StkMode).value == c_modedel) {		// 取消
				// 確認メッセージを表示
				var yes = function () {
					$("#Btninsert")[0].click();
				}
				var no = function () {
				}
				var msg = getMessage("W113", "新規作成");
				if (!boOpenInfoDialog(msg, yes, no)) {
					// いいえの場合、処理終了
					return false;
				}
			}
			break;

		// 検索ボタン
		case "Btnsearch".toUpperCase():
			if (getAdvControlFromItemID(clm_StkMode).value == c_modesinseitorikesi	// 申請済取消
				|| getAdvControlFromItemID(clm_StkMode).value == c_modedel) {		// 取消
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

		// 印刷ボタン
		case "Btnprint".toUpperCase():
			// 確認メッセージを表示
			var yes = function () {
				$("#Btnprint")[0].click();
			}
			var no = function () {
			}
			var msg = getMessage("I100");
			if (!boOpenInfoDialog(msg, yes, no)) {
				// いいえの場合、処理終了
				return false;
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
		case "Btnmodekeihisinsei".toUpperCase():
		case "Btnmodesinseitorikesi".toUpperCase():
		case "Btnmodeupd".toUpperCase():
		case "Btnmodedel".toUpperCase():
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
		case "Hokokutan_cd".toUpperCase():	// 報告担当者コード
			// 名称取得部品を起動
			V02005_MAIN(getAdvControlFromItemID("Hokokutan_cd"), getAdvControlFromItemID("Hokokutan_nm"), getAdvControlFromItemID("Hokokutan_cd"), 0);
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

		// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
		case "Tonanhinkanri_no_from".toUpperCase():		// 盗難品管理番号ＦＲＯＭ
			// FROMの値をTOへコピー
			fromToCopy("Tonanhinkanri_no");
			break;
		case "Jikohassei_ymd_from".toUpperCase():		// 事故発生日ＦＲＯＭ
			// FROMの値をTOへコピー
			fromToCopy("Jikohassei_ymd");
			break;
		case "Hokoku_ymd_from".toUpperCase():			// 報告日ＦＲＯＭ
			// FROMの値をTOへコピー
			fromToCopy("Hokoku_ymd");
			break;
		case "Keisatsutodoke_ymd_from".toUpperCase():	// 警察届出日ＦＲＯＭ
			// FROMの値をTOへコピー
			fromToCopy("Keisatsutodoke_ymd");
			break;
		case "Jyuri_no_from".toUpperCase():				// 受理番号ＦＲＯＭ
			// FROMの値をTOへコピー
			fromToCopy("Jyuri_no");
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

