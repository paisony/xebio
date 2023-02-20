/*-----------------------------------------------------------------------------
	モジュール:tf021f01_event_n.js
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
	md_tf021f01_register();
	
	//共通ロード設定
	setCommonLoad();
	
// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

	// --------------------------
	// BO初期表示共通処理
	boLoadCommon();
	// --------------------------
	
	// 科目名From名称取得時のイベント
	$('#Kamoku_nm_from').bind('mdSetAfter', function () {
		// イベント取得時の処理
		fromToCopyLbl("Kamoku_cd", "Kamoku_nm");
	});

	// モードの取得
	var mode = getAdvControlFromItemID(clm_StkMode).value

	if (mode == c_modesinseimaeupd) {
		selectorCheckBox = 'disable';
	}
	// 項目制御
	itemControl_mode();
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

	// モードの取得
	var mode = getAdvControlFromItemID(clm_StkMode).value

	// ここに業務固有チェック処理を記述します。
	switch (AdvGB_LastClickItemNm.toUpperCase()) {
// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
		// 新規作成ボタン
		case "Btninsert".toUpperCase():

			//「申請前修正」「照会」以外の場合
			if (mode != "" && mode != c_modesinseimaeupd && mode != c_moderef) {

				// 確認メッセージを表示
				var yes = function () {
					$("#Btninsert")[0].click();
				}
				var no = function () {
				}

				var msg = getMessage("W113", ["新規作成"]);
				if (boOpenInfoDialog(msg, yes, no) == false) {
					return false;
				}
			}

			break;

		// 検索ボタン
		case "Btnsearch".toUpperCase():

			//「申請前修正」「照会」以外の場合
			if (mode != "" && mode != c_modesinseimaeupd && mode != c_moderef) {

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
			if (boOpenInfoDialog(msg, yes, no) == false) {
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
			if (boOpenInfoDialog(msg, yes, no) == false) {
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
		case "Btnmodeapply".toUpperCase():
		case "Btnmodesinseimaesyusei".toUpperCase():
		case "Btnmodesinseimaetorikesi".toUpperCase():
		case "Btnmodesinseigotorikesi".toUpperCase():
		case "Btnmoderef".toUpperCase():
		
			// モードボタン共通処理
			tabClick(eventTargetName.toUpperCase());
			// 項目制御
			itemControl_mode(getModeNo(eventTargetName));
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
		case "Head_tenpo_cd".toUpperCase():			// ヘッダ店舗コード
			// 名称取得部品を起動
			V02001(getAdvControlFromItemID("Head_tenpo_cd"), getAdvControlFromItemID("Head_tenpo_nm"), getAdvControlFromItemID("Head_tenpo_cd"));
			break;
		case "Kamoku_cd_from".toUpperCase():		// 科目コードFROM
			// 名称取得部品を起動
			V02021_MAIN(getAdvControlFromItemID("Kamoku_cd_from"), getAdvControlFromItemID("Kamoku_nm_from"), null, 0);
			break;
		case "Kamoku_cd_to".toUpperCase():			// 科目コードTO
			// 名称取得部品を起動
			V02021_MAIN(getAdvControlFromItemID("Kamoku_cd_to"), getAdvControlFromItemID("Kamoku_nm_to"), null, 0);
			break;
		case "Sinseitan_cd".toUpperCase():			// 申請担当者コード
			// 名称取得部品を起動
			V02005_MAIN(getAdvControlFromItemID("Sinseitan_cd"), getAdvControlFromItemID("Sinseitan_nm"), getAdvControlFromItemID("Sinseitan_cd"), 0);
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
		case "Add_ymd_from".toUpperCase():			// 登録日FROM
			// FROMの値をTOへコピー
			fromToCopy("Add_ymd");
			break;
		case "Apply_ymd_from".toUpperCase():		// 申請日FROM
			// FROMの値をTOへコピー
			fromToCopy("Apply_ymd");
			break;
		case "Kakutei_ymd_from".toUpperCase():		// 確定日FROM
			// FROMの値をTOへコピー
			fromToCopy("Kakutei_ymd");
			break;
		case "Kamoku_cd_from".toUpperCase():		// 科目コード
			// FROMの値をTOへコピー
			fromToCopy("Kamoku_cd");
			break;
		case "Denpyo_bango_from".toUpperCase():		// 伝票番号FROM
			// FROMの値をTOへコピー
			fromToCopy("Denpyo_bango");
			break;
		case "Kanri_no_from".toUpperCase():			// 管理NoFROM
			// FROMの値をTOへコピー
			fromToCopy("Kanri_no");
			break;
		case "Gyomuringi_no_from".toUpperCase():	// 業務稟議NoFROM
			// FROMの値をTOへコピー
			fromToCopy("Gyomuringi_no");
			break;
		case "Jyuri_no_from".toUpperCase():			// 受理番号
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


/*-----------------------------------------------------------------------------
ユーザ定義関数
-----------------------------------------------------------------------------*/
// モード変更確認メッセージ表示時のNOアクション
function tabClick_NoAction(tabnm) {
	// 項目制御
	itemControl_mode();
}
// モード別のコントロール制御
function itemControl_mode(pModeno) {

	var modeno = pModeno;
	if (modeno == null || modeno == "") {
		modeno = getAdvControlFromItemID(clm_Mode).value;
	}
	switch (String(modeno)) {
		case c_modeapply:			// 申請の場合
		case c_modesinseimaeupd:	// 申請前修正の場合
		case c_modesinseimaedel:	// 申請前取消の場合
			// 承認状態 使用不可
			itemDisabled(getAdvControlFromItemID("Syonin_flg"), true);
			// 申請日From 使用不可
			itemDisabled(getAdvControlFromItemID("Apply_ymd_from"), true);
			// 申請日To 使用不可
			itemDisabled(getAdvControlFromItemID("Apply_ymd_to"), true);
			// 確定日From 使用不可
			itemDisabled(getAdvControlFromItemID("Kakutei_ymd_from"), true);
			// 確定日To 使用不可
			itemDisabled(getAdvControlFromItemID("Kakutei_ymd_to"), true);
			// 伝票番号From 使用不可
			itemDisabled(getAdvControlFromItemID("Denpyo_bango_from"), true);
			// 伝票番号To 使用不可
			itemDisabled(getAdvControlFromItemID("Denpyo_bango_to"), true);
			// 申請者 使用不可
			itemDisabled(getAdvControlFromItemID("Sinseitan_cd"), true);
			break;
		case c_modesinseigodel:		// 申請後取消の場合
			// 承認状態 使用不可
			itemDisabled(getAdvControlFromItemID("Syonin_flg"), true);
			// 申請日From 使用可
			itemDisabled(getAdvControlFromItemID("Apply_ymd_from"), false);
			// 申請日To 使用可
			itemDisabled(getAdvControlFromItemID("Apply_ymd_to"), false);
			// 確定日From 使用不可
			itemDisabled(getAdvControlFromItemID("Kakutei_ymd_from"), true);
			// 確定日To 使用不可
			itemDisabled(getAdvControlFromItemID("Kakutei_ymd_to"), true);
			// 伝票番号From 使用可
			itemDisabled(getAdvControlFromItemID("Denpyo_bango_from"), false);
			// 伝票番号To 使用可
			itemDisabled(getAdvControlFromItemID("Denpyo_bango_to"), false);
			// 申請者 使用可
			itemDisabled(getAdvControlFromItemID("Sinseitan_cd"), false);
			break;
		case c_moderef:				// 照会の場合
			// 承認状態 使用可
			itemDisabled(getAdvControlFromItemID("Syonin_flg"), false);
			// 申請日From 使用可
			itemDisabled(getAdvControlFromItemID("Apply_ymd_from"), false);
			// 申請日To 使用可
			itemDisabled(getAdvControlFromItemID("Apply_ymd_to"), false);
			// 確定日From 使用可
			itemDisabled(getAdvControlFromItemID("Kakutei_ymd_from"), false);
			// 確定日To 使用可
			itemDisabled(getAdvControlFromItemID("Kakutei_ymd_to"), false);
			// 伝票番号From 使用可
			itemDisabled(getAdvControlFromItemID("Denpyo_bango_from"), false);
			// 伝票番号To 使用可
			itemDisabled(getAdvControlFromItemID("Denpyo_bango_to"), false);
			// 申請者 使用可
			itemDisabled(getAdvControlFromItemID("Sinseitan_cd"), false);
			break;

	}

}
