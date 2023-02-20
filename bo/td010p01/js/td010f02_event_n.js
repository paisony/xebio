/*-----------------------------------------------------------------------------
	モジュール:td010f02_event_n.js
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
	md_td010f02_register();
	
	//共通ロード設定
	setCommonLoad();

	// --------------------------
	// BO初期表示共通処理
	boLoadCommon();
	// --------------------------

	// モードが「確定前修正」の場合、明細は選択可とする。
	if (getAdvControlFromItemID(clm_StkMode).value == c_modekakuteimaeupd) {
		selectorCheckBox = '';
	} else {
		selectorCheckBox = 'DISABLED';
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
	
		// -------------------
		// スキャンコード
		// -------------------
		case "M1scan_cd".toUpperCase():
			// 明細行番号を取得する
			//var lineNo = getAdvItemMNofromCtrl(eventTarget) - 1;
			var lineNo = getItemMNofromCtrl(eventTarget);
			// 操作ありの背景色に変更
			commitColorSet(lineNo);
			// 名称表示
			// 検索条件指定(Key：固定、Value：検索値)
			var condition = {
				 "SCAN_CD"			: getAdvControlFromItemID("M1scan_cd", lineNo)	// スキャンコード
				,"TENPO_CD"			: getAdvControlFromItemID("Head_tenpo_cd")		// 店舗コード
				,"PLUFLG"			: "0"											// 店別単価マスタ	検索フラグ 0:検索しない 1:検索する
				,"PRICEFLG"			: "0"											// 売変				検索フラグ 0:検索しない 1:検索する
				,"ZAIKOFLG"			: "0"											// 店在庫			検索フラグ 0:検索しない 1:検索する
				,"NYUKAFLG"			: "0"											// 入荷予定数		検索フラグ 0:検索しない 1:検索する
				,"URIFLG"			: "0"											// 売上実績数		検索フラグ 0:検索しない 1:検索する
				,"HOJUFLG"			: "0"											// 依頼集計数(補充)	検索フラグ 0:検索しない 1:検索する
				,"TANPINFLG"		: "0"											// 依頼集計数(単品)	検索フラグ 0:検索しない 1:検索する
				,"SIJIFLG"			: "0"											// 指示検索			検索フラグ 0:検索しない 1:出荷指示、2:返品指示
				,"SIJI_NO"			: "0"											// 指示NO（移動出荷マニュアル、返品マニュアル用）
				,"SYUKAKAISYA_CD"	: "0"											// 出荷会社コード（移動出荷マニュアル)
				,"NYUKAKAISYA_CD"	: "0"											// 入荷会社コード（移動出荷マニュアル)
				,"SYUKATENPO_CD"	: "0"											// 指示店舗コード（移動出荷マニュアル、返品マニュアル用）
			};
			// 戻り値指定(Key：SELECT句、Value：項目名)
			var result = {
				 "HINSYU_RYAKU_NM": getAdvControlFromItemID("M1hinsyu_ryaku_nm", lineNo)	// 品種
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

		// -------------------
		// 数量
		// -------------------
		case "M1suryo".toUpperCase():

			// 明細行番号を取得する
			//var lineNo = getAdvItemMNofromCtrl(eventTarget);
			var lineNo = getItemMNofromCtrl(eventTarget);
			// 合計値再計算
			calcRow(lineNo);

			// 操作ありの背景色に変更
			commitColorSet(lineNo);

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
// 名称取得の出口ルーチン
function mdSetAfter(aa) {
	return "";
}
// スキャンコード名称取得の出口ルーチン
function responseHandle_onAfter(lineNo) {

	// フォーマット処理を実行する為、フォーカス処理を実行
	var Genaka = getAdvControlFromItemID("M1gen_tnk", lineNo);
	Genaka.value = getAdvFormatStr("M1gen_tnk", Genaka.value);

	// 合計値を再計算
	calcRow(lineNo);

}
// 明細合計値計算関数
function calcRow(plineNo) {

	var lineNo = plineNo;

	// Ｍ１数量
	var su = getAdvControlFromItemID("M1suryo", lineNo);
	// Ｍ１数量(隠し)
	var suHid = getAdvControlFromItemID("M1suryo_hdn", lineNo);

	// Ｍ１原単価
	var genka = getAdvControlFromItemID("M1gen_tnk", lineNo);

	// Ｍ１原価金額
	var genkaKin = getAdvControlFromItemID("M1genkakin", lineNo);
	// Ｍ１原価金額(隠し)
	var genkaKinHid = getAdvControlFromItemID("M1genkakin_hdn", lineNo);

	// 合計数量
	var sumSu = getAdvControlFromItemID("Gokei_suryo");
	// 合計金額
	var sumGenkaKin = getAdvControlFromItemID("Genka_kin_gokei");

	// Ｍ１数量×Ｍ１原単価をＭ１原価金額に設定する。
	genkaKin.value = formatComma(ToNumber(unFormatComma(su.value)) * ToNumber(unFormatComma(genka.value)));

	// 合計依頼数量の再計算を行う
	/*
		Ｍ１数量とＭ１数量(隠し)の差分を取得し、合計数量に加算(減算)する。
		Ｍ１数量(隠し)にＭ１数量を設定する。
	*/
	sumSu.value = formatComma(ToNumber(unFormatComma(sumSu.value)) - (ToNumber(unFormatComma(suHid.value)) - ToNumber(unFormatComma(su.value))));
	// 隠し項目に変更後の数量を再設定
	suHid.value = su.value;

	/*
		Ｍ１原価金額とＭ１原価金額(隠し)の差分を取得し、合計原価金額に加算(減算)する。
		Ｍ１原価金額(隠し)にＭ１原価金額を設定する。
	*/
	sumGenkaKin.value = formatComma(ToNumber(unFormatComma(sumGenkaKin.value)) - (ToNumber(unFormatComma(genkaKinHid.value)) - ToNumber(unFormatComma(genkaKin.value))));
	// 隠し項目に変更後の数量を再設定
	genkaKinHid.value = genkaKin.value;
}
