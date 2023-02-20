/*-----------------------------------------------------------------------------
	モジュール:tm070f01_event_n.js
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
	md_tm070f01_register();
	
	//共通ロード設定
	setCommonLoad();
	
	// --------------------------
	// BO初期表示共通処理
	boLoadCommon();
	// --------------------------

	// 元店舗From名称取得時のイベント
	$('#Moto_tenpo_nm_from').bind('mdSetAfter', function () {
		// イベント取得時の処理
		fromToCopyLbl("Moto_tenpo_cd", "Moto_tenpo_nm");
	});

	// 担当者From名称取得時のイベント
	$('#Tan_nm_from').bind('mdSetAfter', function () {
		// イベント取得時の処理
		fromToCopyLbl("Tan_cd", "Tan_nm");
	});

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
		// 新規作成ボタン
		case "Btninsert".toUpperCase():
			// [選択モードNo]が空以外の場合、メッセージを出力
			if (getAdvControlFromItemID(clm_StkMode).value != "") {

				// 確認メッセージを表示
				var yes = function () {
				$("#Btninsert")[0].click();
				}
				var no = function () {}
				var msg = getMessage("W113", "新規作成");
				return boOpenInfoDialog(msg, yes, no);
			}
			break;
		// 検索ボタン
		case "Btnsearch".toUpperCase():
			// [選択モードNo]が空以外の場合、メッセージを出力
			if (getAdvControlFromItemID(clm_StkMode).value != "") {

				// 確認メッセージを表示
				var yes = function () {
					$("#Btnsearch")[0].click();
				}
				var no = function () { }
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
		// 行削除ボタン
		case "Btnrowdel".toUpperCase():
			// 確認メッセージを表示
			var yes = function () {
				$("#Btnrowdel")[0].click();
			}
			var no = function () {
			}
			var msg = getMessage("W119");
			if (boOpenInfoDialog(msg, yes, no) == false) {
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

		case "Moto_tenpo_cd_from".toUpperCase():	// 元店舗コードＦＲＯＭ
			// 名称取得部品を起動
			V02001(getAdvControlFromItemID("Moto_tenpo_cd_from"), getAdvControlFromItemID("Moto_tenpo_nm_from"), null);
			break;

		case "Moto_tenpo_cd_to".toUpperCase():	// 元店舗コードＴＯ
			// 名称取得部品を起動
			V02001(getAdvControlFromItemID("Moto_tenpo_cd_to"), getAdvControlFromItemID("Moto_tenpo_nm_to"), null);
			break;

		case "Tan_cd_from".toUpperCase():// 担当者コードＦＲＯＭ
			// 名称取得部品を起動
			V02005(getAdvControlFromItemID("Tan_cd_from"), getAdvControlFromItemID("Tan_nm_from"), null);
			break;

		case "Tan_cd_to".toUpperCase():// 担当者コードＴＯ
			// 名称取得部品を起動
			V02005(getAdvControlFromItemID("Tan_cd_to"), getAdvControlFromItemID("Tan_nm_to"), null);
			break;

		// -------------------
		// 明細部
		// -------------------
		case "M1tan_cd".toUpperCase():	// Ｍ１担当者コード
			// 明細行番号を取得する
			var lineNo = getItemMNofromCtrl(eventTarget);
			// 操作ありの背景色に変更
			commitColorSet(lineNo);

			// 名称表示
			// 検索条件指定(Key：固定、Value：検索値)
			var condition = {
				"HANBAIIN_CD": getAdvControlFromItemID("M1tan_cd", lineNo)					// Ｍ１担当者コード
			};
			// 戻り値指定(Key：SELECT句、Value：項目名)
			var result = {
				 "HANBAIIN_NM": getAdvControlFromItemID("M1tan_nm", lineNo)					// Ｍ１担当者名称
				,"HANBAIINTENPO_CD": getAdvControlFromItemID("M1moto_tenpo_cd", lineNo)	// Ｍ１元店舗コード
				,"TENPO_NM": getAdvControlFromItemID("M1moto_tenpo_nm", lineNo)			// Ｍ１元店舗名称
				,"UPD_YMD": getAdvControlFromItemID("M1upd_ymd", lineNo)					// Ｍ１更新日(隠し)
				,"UPD_TM": getAdvControlFromItemID("M1upd_tm", lineNo)					// Ｍ１更新時間(隠し)
			};

			// 担当者マスタ・店舗マスタ取得部品を起動
			V02027(condition, result, getAdvControlFromItemID("M1tan_cd", lineNo), true, lineNo);

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
	
		case "Henko_ymd_from".toUpperCase():		// 変更日FROM
			// FROMの値をTOへコピー
			fromToCopy("Henko_ymd");
			break;
		case "Moto_tenpo_cd_from".toUpperCase():	// 元店舗コードFROM
			// FROMの値をTOへコピー
			fromToCopy("Moto_tenpo_cd");
			break;
		case "Tan_cd_from".toUpperCase():			// 担当者コードFROM
			// FROMの値をTOへコピー
			fromToCopy("Tan_cd");
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

