﻿/*-----------------------------------------------------------------------------
	モジュール:tb090f02_event_n.js
--------------------------------------------------------------------------------*/
/*<title>[画面02CLイベントScript]</title>*/

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
	md_tb090f02_register();
	
	//共通ロード設定
	setCommonLoad();
	
	// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

	// --------------------------
	// BO初期表示共通処理
	boLoadCommon();
	// --------------------------

	selectorCheckBox = 'disable';
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
		// 戻るボタン
		case "Btnback".toUpperCase():

			// モードの取得
			var mode = getAdvControlFromItemID(clm_StkMode).value

			// 訂正モードで確定ボタンが表示されている場合
			if (mode == c_modeteisei && !getAdvControlFromItemID("Btnenter").disabled) {

				// 確認メッセージを表示
				var yes = function () {
					$("#Btnback")[0].click();
				}
				var no = function () {
				}
				var msg = getMessage("W107");
				if (boOpenInfoDialog(msg, yes, no) == false) {
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
		case "Biko_kb".toUpperCase():		// 備考区分

			switch (getAdvControlFromItemID("Biko_kb").value) {
				// 伝票No①の訂正　取引先承認者②様の場合
				case "2":
					// 備考２を使用可
					itemDisabled(getAdvControlFromItemID("Biko2"), false);
					break;
				default:
					// 備考２をクリアし、使用不可
					getAdvControlFromItemID("Biko2").value = "";
					itemDisabled(getAdvControlFromItemID("Biko2"), true);

					break;
			}

			break;

		case "M1teisei_suryo".toUpperCase():	// 訂正数量

			// 操作ありの背景色に変更
			commitColorSet(lineNo);

			// 合計値再計算
			calcRow(lineNo);

			break;

		case "M1scan_cd".toUpperCase():		// Ｍ１スキャンコード

			// 操作ありの背景色に変更
			commitColorSet(lineNo);

			// 丸め処理部品を起動
			formatScanCd(getAdvControlFromItemID("M1scan_cd", lineNo));
			// 検索条件指定(Key：固定、Value：検索値)
			var condition = {
			  		"SCAN_CD"			: getAdvControlFromItemID("M1scan_cd", lineNo)
			  	,"TENPO_CD"			: getAdvControlFromItemID("Head_tenpo_cd")
			  	,"PLUFLG"			: "0"
			  	,"PRICEFLG"			: "0"
			  	,"ZAIKOFLG"			: "0"
			  	,"NYUKAFLG"			: "0"
			  	,"URIFLG"			: "0"
			  	,"HOJUFLG"			: "0"
			  	,"TANPINFLG"		: "0"
			  	,"SIJIFLG"			: "0"
			  	,"SIJI_NO"			: "0"
			  	,"SYUKAKAISYA_CD"	: "0"
			  	,"NYUKAKAISYA_CD"	: "0"
			  	,"SYUKATENPO_CD"	: "0"
			};
			// 戻り値指定(Key：SELECT句、Value：項目名)
			var result = {
				  "HINSYU_RYAKU_NM": getAdvControlFromItemID("M1hinsyu_ryaku_nm", lineNo)	// 品種
			  	, "BURANDO_NMK": getAdvControlFromItemID("M1burando_nm", lineNo)			// ブランド名
			  	, "XEBIO_CD": getAdvControlFromItemID("M1jisya_hbn", lineNo)				// 自社品番
			  	, "HIN_NBR": getAdvControlFromItemID("M1maker_hbn", lineNo)				// メーカー品番
			  	, "SYONMK": getAdvControlFromItemID("M1syonmk", lineNo)					// 商品名
			  	, "IRO_NM": getAdvControlFromItemID("M1iro_nm", lineNo)					// 色
			  	, "SIZE_NM": getAdvControlFromItemID("M1size_nm", lineNo)					// サイズ
			  	, "GENKA": getAdvControlFromItemID("M1gen_tnk", lineNo)					// 原価
			};
			  
			// 名称取得部品
			V02004(condition, result, getAdvControlFromItemID("M1scan_cd", lineNo), true, lineNo);

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

		case "Biko1".toUpperCase():		// 備考１
			if (getAdvControlFromItemID("Biko1").value == "") {
				// 入力されている場合
				if (getAdvControlFromItemID("Biko_kb").value == "2") {
					// 伝票No①の訂正　取引先承認者②様の場合、①を0埋めする
					getAdvControlFromItemID("Biko1").value = LPadZero(getValue(getAdvControlFromItemID("Biko1")), 6);
				}
			}
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

/*-----------------------------------------------------------------------------
ユーザ定義関数
-----------------------------------------------------------------------------*/
// スキャンコード名称取得の出口ルーチン
function responseHandle_onAfter(lineNo) {

	// 合計値再計算
	calcRow(lineNo);

	getAdvControlFromItemID("M1gen_tnk", lineNo).value = formatComma(getAdvControlFromItemID("M1gen_tnk", lineNo).value);
}

// 明細合計値計算関数
function calcRow(lineNo) {

	// Ｍ１検数
	var kensu = getAdvControlFromItemID("M1kensu", lineNo);
	// Ｍ１訂正数量
	var teiseisu = getAdvControlFromItemID("M1teisei_suryo", lineNo);
	// Ｍ１訂正数量(隠し)
	var teiseisuHid = getAdvControlFromItemID("M1teisei_suryo_hdn", lineNo);

	// Ｍ１原単価
	var genka = getAdvControlFromItemID("M1gen_tnk", lineNo);
	// Ｍ１原価金額
	var genkaKin = getAdvControlFromItemID("M1genkakin", lineNo);
	// Ｍ１原価金額(隠し)
	var genkaKinHid = getAdvControlFromItemID("M1genkakin_hdn", lineNo);

	// 合計訂正数量
	var sumSu = getAdvControlFromItemID("Gokei_teisei_suryo");
	// 合計金額
	var sumGenkaKin = getAdvControlFromItemID("Gokei_genkakin");

	var suryo = 0;
	// 合計依頼数量の再計算を行う
	if (teiseisu.value == null || teiseisu.value == "") {
		suryo = kensu.value;
	} else {
		suryo = teiseisu.value;
	}

	// Ｍ１数量×Ｍ１原単価をＭ１原価金額に設定する。
	genkaKin.value = formatComma(ToNumber(suryo) * ToNumber(unFormatComma(genka.value)));

	/*
		Ｍ１数量とＭ１数量(隠し)の差分を取得し、合計数量に加算(減算)する。
		Ｍ１数量(隠し)にＭ１数量を設定する。
	*/
	sumSu.value = formatComma(ToNumber(unFormatComma(sumSu.value)) - (ToNumber(unFormatComma(teiseisuHid.value)) - ToNumber(suryo)));
	// 隠し項目に変更後の数量を再設定
	teiseisuHid.value = suryo;

	/*
		Ｍ１原価金額とＭ１原価金額(隠し)の差分を取得し、合計原価金額に加算(減算)する。
		Ｍ１原価金額(隠し)にＭ１原価金額を設定する。
	*/
	sumGenkaKin.value = formatComma(ToNumber(unFormatComma(sumGenkaKin.value)) - (ToNumber(unFormatComma(genkaKinHid.value)) - ToNumber(unFormatComma(genkaKin.value))));
	// 隠し項目に変更後の数量を再設定
	genkaKinHid.value = genkaKin.value;
}

