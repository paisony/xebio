/*-----------------------------------------------------------------------------
	モジュール:tf010f01_event_n.js
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
	md_tf010f01_register();
	
	//共通ロード設定
	setCommonLoad();
	
// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

	// --------------------------
	// BO初期表示共通処理
	boLoadCommon();
	// --------------------------
	
	// 申請店舗名From名称取得時のイベント
	$('#Shinsei_tenpo_nm_from').bind('mdSetAfter', function () {
		// イベント取得時の処理
		fromToCopyLbl("Shinsei_tenpo_cd", "Shinsei_tenpo_nm");
	});

	// 科目名From名称取得時のイベント
	$('#Kamoku_nm_from').bind('mdSetAfter', function () {
		// イベント取得時の処理
		fromToCopyLbl("Kamoku_cd", "Kamoku_nm");
	});

	// モードの取得
	var mode = getAdvControlFromItemID(clm_StkMode).value

	if (mode != c_moderef && mode != c_modedel) {
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

	var mode = getAdvControlFromItemID(clm_StkMode).value

	// ここに業務固有チェック処理を記述します。
	switch (AdvGB_LastClickItemNm.toUpperCase()) {
// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
		// 検索ボタン
		case "Btnsearch".toUpperCase():

			// モードの取得
			var mode = getAdvControlFromItemID(clm_StkMode).value

			//「照会」以外の場合
			if (mode != "" && mode != c_moderef) {

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

		// CSV出力ボタン
		case "Btncsv".toUpperCase():

			// 確認メッセージを表示
			var yes = function () {
				$("#Btncsv")[0].click();
			}
			var no = function () {
			}

			var msg = getMessage("I101");
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
		case "Btnmodekakutei".toUpperCase():
		case "Btnmodeupd".toUpperCase():
		case "Btnmodedel".toUpperCase():
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
	// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
	// 明細行番号を取得する
	var lineNo = getItemMNofromCtrl(eventTarget);
	// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
	switch (eventTargetName.toUpperCase()) {
	//  ここに項目IDのcase文を追加し、固有処理を記述します。
// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
		case "Head_tenpo_cd".toUpperCase():	// ヘッダ店舗コード
			// 名称取得部品を起動
			V02001(getAdvControlFromItemID("Head_tenpo_cd"), getAdvControlFromItemID("Head_tenpo_nm"), getAdvControlFromItemID("Head_tenpo_cd"));
			break;
		case "Shinsei_tenpo_cd_from".toUpperCase():	// 申請店舗コードFROM
			// 名称取得部品を起動
			V02001_MAIN(getAdvControlFromItemID("Shinsei_tenpo_cd_from"), getAdvControlFromItemID("Shinsei_tenpo_nm_from"), null, 0);
			break;
		case "Shinsei_tenpo_cd_to".toUpperCase():	// 申請店舗コードTO
			// 名称取得部品を起動
			V02001_MAIN(getAdvControlFromItemID("Shinsei_tenpo_cd_to"), getAdvControlFromItemID("Shinsei_tenpo_nm_to"), null, 0);
			break;
		case "Kamoku_cd_from".toUpperCase():		// 科目コードFROM
			// 名称取得部品を起動
			V02021_MAIN(getAdvControlFromItemID("Kamoku_cd_from"), getAdvControlFromItemID("Kamoku_nm_from"), null, 0);
			break;
		case "Kamoku_cd_to".toUpperCase():	// 科目コードTO
			// 名称取得部品を起動
			V02021_MAIN(getAdvControlFromItemID("Kamoku_cd_to"), getAdvControlFromItemID("Kamoku_nm_to"), null, 0);
			break;
		case "M1syonin_flg".toUpperCase():			// 承認フラグ
			if (getAdvControlFromItemID("M1kyakka_flg", lineNo).checked) {
				getAdvControlFromItemID("M1kyakka_flg", lineNo).checked = false;
			}

			commitColorSet(lineNo);

			break;
		case "M1kyakka_flg".toUpperCase():			// 却下フラグ
			if (getAdvControlFromItemID("M1syonin_flg", lineNo).checked) {
				getAdvControlFromItemID("M1syonin_flg", lineNo).checked = false;
			}

			commitColorSet(lineNo);

			break;
		case "M1kyakkariyu".toUpperCase():			// 却下理由
			// 操作ありの背景色に変更
			commitColorSet(lineNo);
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
		case "Apply_ymd_from".toUpperCase():	// 申請日FROM
			// FROMの値をTOへコピー
			fromToCopy("Apply_ymd");
			break;
		case "Kakutei_ymd_from".toUpperCase():	// 確定日FROM
			// FROMの値をTOへコピー
			fromToCopy("Kakutei_ymd");
			break;
		case "Shinsei_tenpo_cd_from".toUpperCase():	// 申請店舗コードFROM
			// FROMの値をTOへコピー
			fromToCopy("Shinsei_tenpo_cd");
			break;
		case "Gyomuringi_no_from".toUpperCase():	// 業務稟議NoFROM
			// FROMの値をTOへコピー
			fromToCopy("Gyomuringi_no");
			break;
		case "Denpyo_bango_from".toUpperCase():	// 伝票番号FROM
			// FROMの値をTOへコピー
			fromToCopy("Denpyo_bango");
			break;
		case "Kamoku_cd_from".toUpperCase():	//受理番号FROM
			// FROMの値をTOへコピー
			fromToCopy("Kamoku_cd");
			break;
		case "Jyuri_no_from".toUpperCase():	//科目コードFROM
			// FROMの値をTOへコピー
			fromToCopy("Jyuri_no");
			break;
		case "Old_jisya_hbn".toUpperCase():	// 旧自社品番
			// 旧自社品番丸め処理
			formatJisyaHbnCd(getAdvControlFromItemID("Old_jisya_hbn"));
			break;
		case "Scan_cd".toUpperCase():	// スキャンコード
			// スキャンコード丸め処理
			formatScanCd(getAdvControlFromItemID("Scan_cd"));
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
		case c_modekakutei:	// 確定の場合
			// 承認状態 使用不可
			itemDisabled(getAdvControlFromItemID("Syonin_flg"), true);
			// 確定日From 使用不可
			itemDisabled(getAdvControlFromItemID("Kakutei_ymd_from"), true);
			// 確定日To 使用不可
			itemDisabled(getAdvControlFromItemID("Kakutei_ymd_to"), true);
			break;
		case c_modeupd:		// 修正の場合
		case c_modedel:		// 取消の場合
		case c_moderef:		// 照会の場合
			// 承認状態 使用可
			itemDisabled(getAdvControlFromItemID("Syonin_flg"), false);
			// 確定日From 使用可
			itemDisabled(getAdvControlFromItemID("Kakutei_ymd_from"), false);
			// 確定日To 使用可
			itemDisabled(getAdvControlFromItemID("Kakutei_ymd_to"), false);
			break;

	}

}