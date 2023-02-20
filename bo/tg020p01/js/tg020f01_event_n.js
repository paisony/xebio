/*-----------------------------------------------------------------------------
	モジュール:tg020f01_event_n.js
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
	md_tg020f01_register();
	
	//共通ロード設定
	setCommonLoad();

	// --------------------------
	// BO初期表示共通処理
	boLoadCommon();
	// --------------------------
	// href再設定対応（hrefが消える) --------------------------------  ADD_STR
	document.all.item("Btnmodepercentoff").href = "#tab31";
	document.all.item("Btnmodeyenhiki").href = "#tab32";
	// href再設定対応（hrefが消える) --------------------------------  ADD_END

	
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
			//// エラー時の画面表示対応 --------------------------------  ADD_STR
			//getAdvControlFromItemID(clm_StkMode).value = "";
			//nonmodeDisp();
			//// エラー時の画面表示対応 --------------------------------  ADD_END
			//AdvGB_LastClickItemNm = null;
			//return false;

			document.all.item(clm_StkMode).value = ""
			nonmodeDisp();
			// ---------------------------
			AdvGB_LastClickItemNm = null;
			return false;
		}
	}

	////クライアント共通チェック
	//if (isCommonCheck(AdvGB_LastClickItemNm.toUpperCase())) {
	//	if (!onSubmit_std(AdvGB_LastClickItemNm.toUpperCase())) {
	//		AdvGB_LastClickItemNm = null;
	//		return false;
	//	}
	//}

	// ここに業務固有チェック処理を記述します。
	switch (AdvGB_LastClickItemNm.toUpperCase()) {
		
		
		// シール発行ボタン
		case "Btnseal".toUpperCase():

			// 確認メッセージを表示
			var yes = function () {
				$("#Btnseal")[0].click();
			}
			var no = function () {
			}
			var msg = getMessage("I103");
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

		// タブ処理
	case "BTNMODEPERCENTOFF":
	case "BTNMODEYENHIKI":
		// モードボタン共通処理
		//tabClick(eventTargetName.toUpperCase());
		// 入力値クリアの確認メッセージ表示
		prvSerchInputClear(eventTargetName);
		return false;

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
		//  ここに項目IDのcase文を追加し、固有処理を記述します。
		case "Head_tenpo_cd".toUpperCase():	// ヘッダ店舗コード
			// 名称取得部品を起動
			V02001(getAdvControlFromItemID("Head_tenpo_cd"), getAdvControlFromItemID("Head_tenpo_nm"), getAdvControlFromItemID("Head_tenpo_cd"));
			break;
		case "Inji_comment".toUpperCase():	// 印字コメント
			controlInjiComment(1);
			break;
		case "Inji_comment2".toUpperCase():	// 印字コメント2
			//「その他」が選択された場合、印字コメント名称２を編集可能
			controlInjiComment(2);
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
// 印字コメント制御関数
function controlInjiComment(mode) {
	if (mode == 1) {
		if (getAdvControlFromItemID("INJI_COMMENT").value == "3") {
			itemDisabled(getAdvControlFromItemID("Inji_comment_nm"), false);
		} else {
			itemDisabled(getAdvControlFromItemID("Inji_comment_nm"), true);
		}
	} else {
		if (getAdvControlFromItemID("INJI_COMMENT2").value == "3") {
			itemDisabled(getAdvControlFromItemID("Inji_comment_nm2"), false);
		} else {
			itemDisabled(getAdvControlFromItemID("Inji_comment_nm2"), true);
		}
	}
}
// モード変更確認メッセージ表示時のYESアクション
function tabClick_YesAction(tabnm) {
	// 印字コメント制御
	controlInjiComment(1);
	controlInjiComment(2);
}
// モード変更確認メッセージ表示時のNOアクション
function tabClick_NoAction(tabnm) {
}
// 検索条件クリア
function prvSerchInputClear(eventTargetName) {
	// 入力値クリアの確認メッセージ表示
	if (getAdvControlFromItemID(clm_Mode).value == c_modepercentoff) {
		// ％OFFの場合
		// 入力値クリアの確認メッセージ表示
		var inputItem =
		[
			  [getAdvControlFromItemID("Waririt"), ""]
			, [getAdvControlFromItemID("Maisu"), ""]
			, [getAdvControlFromItemID("Inji_comment"), 0]
			, [getAdvControlFromItemID("Inji_comment_nm"), ""]
		];
		var labelItem =
		[
		];
		searchInputClear(eventTargetName, inputItem, labelItem);
	} else if (getAdvControlFromItemID(clm_Mode).value == c_modeyenhiki) {
		// 円引きの場合
		var inputItem =
		[
			  [getAdvControlFromItemID("Warigak"), ""]
			, [getAdvControlFromItemID("Maisu2"), ""]
			, [getAdvControlFromItemID("Inji_comment2"), 0]
			, [getAdvControlFromItemID("Inji_comment_nm2"), ""]
		];
		var labelItem =
		[
		];
		searchInputClear(eventTargetName, inputItem, labelItem);
	} else {
		vRet = tabClick(eventTargetName.toUpperCase());
	}
}
