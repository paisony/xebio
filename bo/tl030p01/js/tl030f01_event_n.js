/*-----------------------------------------------------------------------------
	モジュール:tl030f01_event_n.js
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
	md_tl030f01_register();
	
	//共通ロード設定
	setCommonLoad();

	// --------------------------
	// BO初期表示共通処理
	boLoadCommon();
	// --------------------------
	selectorCheckBox = 'M1selectorcheckbox';

	// 明細が非表示の場合、初期制御
	if ($('.str-wrap-result .str-result-item-01').css('display') != 'block') {
		detailHide();
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
		case "Head_tenpo_cd".toUpperCase():		// ヘッダ店舗コード
			// 名称取得部品を起動
			V02001(getAdvControlFromItemID("Head_tenpo_cd"), getAdvControlFromItemID("Head_tenpo_nm"), getAdvControlFromItemID("Head_tenpo_cd"));
			break;
		case "Bumon_cd_from".toUpperCase():	// 部門コードFROM
			// 名称取得部品を起動(エラー判定なし)
			V02010_MAIN(getAdvControlFromItemID("Bumon_cd_from"), getAdvControlFromItemID("Bumon_nm_from"), null, 0);
			break;
		case "Bumon_cd_to".toUpperCase():	// 部門コードTO
			// 名称取得部品を起動(エラー判定なし)
			V02010_MAIN(getAdvControlFromItemID("Bumon_cd_to"), getAdvControlFromItemID("Bumon_nm_to"), null, 0);
			break;
		case "Sinseitan_cd".toUpperCase():	// 入力担当者コード
			// 名称取得部品を起動
			V02005_MAIN(getAdvControlFromItemID("Sinseitan_cd"), getAdvControlFromItemID("Sinseitan_nm"), getAdvControlFromItemID("Sinseitan_cd"), 0);
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
		case "Baihen_shiji_no_from".toUpperCase():	// 指示番号FROM
			//// アンフォーマットする
			//unformatSijinobaihen(getAdvControlFromItemID("Baihen_shiji_no_from"));
			break;
		case "Baihen_shiji_no_to".toUpperCase():	// 指示番号TO
			//// アンフォーマットする
			//unformatSijinobaihen(getAdvControlFromItemID("Baihen_shiji_no_to"));
			break;

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
		case "Bumon_cd_from".toUpperCase():	// 部門コード
			// FROMの値をTOへコピー
			fromToCopy("Bumon_cd");
			break;
		case "Baihen_shiji_no_from".toUpperCase():	// 売変指示No
			// フォーマット処理
			formatSijinobaihen(getAdvControlFromItemID("Baihen_shiji_no_from"));
			// FROMの値をTOへコピー
			fromToCopy("Baihen_shiji_no");
			break;
		case "Baihen_shiji_no_to".toUpperCase():	// 売変指示No
			// フォーマット処理
			formatSijinobaihen(getAdvControlFromItemID("Baihen_shiji_no_to"));
			break;

		case "Baihensagyokaisi_ymd_from".toUpperCase():	// 売変作業開始日FROM
			// FROMの値をTOへコピー
			fromToCopy("Baihensagyokaisi_ymd");
			break;
		case "Baihenkaisi_ymd_from".toUpperCase():	// 売変開始日FROM
			// FROMの値をTOへコピー
			fromToCopy("Baihenkaisi_ymd");
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

