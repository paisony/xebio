/*-----------------------------------------------------------------------------
	モジュール:tj090f02_event_n.js
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
	md_tj090f02_register();
	
	//共通ロード設定
	setCommonLoad();

	// --------------------------
	// BO初期表示共通処理
	boLoadCommon();
	// --------------------------

	// 明細選択は使用不可
	selectorCheckBox = 'DISABLED';

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

		// 印刷ボタン
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
	    	var lineNo = getItemMNofromCtrl(eventTarget);
	        // 操作ありの背景色に変更
	        commitColorSet(lineNo);
	        // 名称表示
	        // 検索条件指定(Key：固定、Value：検索値)
	        var condition = {
	              "SCAN_CD"			: getAdvControlFromItemID("M1scan_cd", lineNo)	// スキャンコード
				, "TENPO_CD"		: getAdvControlFromItemID("Head_tenpo_cd")		// 店舗コード
				, "PLUFLG"			: "0"										    // 店別単価マスタ	検索フラグ 0:検索しない 1:検索する
				, "PRICEFLG"		: "0"											// 売変				検索フラグ 0:検索しない 1:検索する
				, "ZAIKOFLG"		: "0"											// 店在庫			検索フラグ 0:検索しない 1:検索する
				, "NYUKAFLG"		: "0"											// 入荷予定数		検索フラグ 0:検索しない 1:検索する
				, "URIFLG"			: "0"									    	// 売上実績数		検索フラグ 0:検索しない 1:検索する
				, "HOJUFLG"			: "0"											// 依頼集計数(補充)	検索フラグ 0:検索しない 1:検索する
				, "TANPINFLG"		: "0"											// 依頼集計数(単品)	検索フラグ 0:検索しない 1:検索する
				, "SIJIFLG"			: "0"											// 指示検索			検索フラグ 0:検索しない 1:出荷指示、2:返品指示
				, "SIJI_NO"			: "0"											// 指示NO（移動出荷マニュアル、返品マニュアル用）
				, "SYUKAKAISYA_CD"	: "0"											// 出荷会社コード（移動出荷マニュアル)
				, "NYUKAKAISYA_CD"	: "0"								    		// 入荷会社コード（移動出荷マニュアル)
				, "SYUKATENPO_CD"	: "0"											// 指示店舗コード（移動出荷マニュアル、返品マニュアル用）
	        };
	        // 戻り値指定(Key：SELECT句、Value：項目名)
	        var result = {
	        	  "BUMON_CD": getAdvControlFromItemID("M1bumon_cd", lineNo)				// 部門コード
	        	, "BUMONKANA_NM": getAdvControlFromItemID("M1bumonkana_nm", lineNo)		// 部門
	            , "HINSYU_RYAKU_NM": getAdvControlFromItemID("M1hinsyu_ryaku_nm", lineNo)	// 品種
	            , "BURANDO_NMK": getAdvControlFromItemID("M1burando_nm", lineNo)			// ブランド
				, "XEBIO_CD": getAdvControlFromItemID("M1jisya_hbn", lineNo)				// 自社品番
				, "HIN_NBR": getAdvControlFromItemID("M1maker_hbn", lineNo)				// メーカー品番
				, "SYONMK": getAdvControlFromItemID("M1syonmk", lineNo)					// 商品名
				, "SYOHIN_CD": getAdvControlFromItemID("M1hyoji_syohin_cd", lineNo)		// 商品コード
				, "IRO_NM": getAdvControlFromItemID("M1iro_nm", lineNo)					// 色
				, "SIZE_NM": getAdvControlFromItemID("M1size_nm", lineNo)					// サイズ
	        };

	        // 名称取得部品
	        V02004(condition, result, getAdvControlFromItemID("M1scan_cd", lineNo), true, lineNo);

	        break;

	    // -------------------
	    // 訂正数量
	    // -------------------
	    case "M1teisei_suryo".toUpperCase():

	        // 明細行番号を取得する
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

		case "M1scan_cd".toUpperCase():	// スキャンコード
			// 明細行番号を取得する
			var lineNo = getItemMNofromCtrl(eventTarget);

	        // スキャンコード丸め処理
			formatScanCd(getAdvControlFromItemID("M1scan_cd", lineNo));
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

	// フォーマット処理を実行する為、フォーカス処理を実行
	var syohin_cd = getAdvControlFromItemID("M1hyoji_syohin_cd", lineNo);

	if (syohin_cd.value.length == 18) {
		syohin_cd.value = syohin_cd.value.substr(0, 3) + '-' + syohin_cd.value.substr(3, 10) + '-' + syohin_cd.value.substr(13, 2) + '-' + syohin_cd.value.substr(15, 3);
	}

	if (syohin_cd.value == '0') {
		syohin_cd.value = "";
	}

}
// 明細合計値計算関数
function calcRow(lineNo) {

    // Ｍ１訂正数量
    var su = getAdvControlFromItemID("M1teisei_suryo", lineNo);
    // Ｍ１訂正数量(隠し)
    var suHid = getAdvControlFromItemID("M1teisei_suryo_hdn", lineNo);

    // Ｍ１スキャン数量
    var scan_su = getAdvControlFromItemID("M1scan_su", lineNo);
    // Ｍ１合計数量
    var gokei_su = getAdvControlFromItemID("M1gokei_suryo", lineNo);

    // 合計訂正数量
    var sumSu = getAdvControlFromItemID("Gokeiteisei_suryo");
    // 総合計数量
    var sumGokeiSu = getAdvControlFromItemID("All_gokei_suryo");

    // Ｍ１スキャン数量＋Ｍ１訂正数量をＭ１合計数量に設定する。
    gokei_su.value = formatComma(ToNumber(unFormatComma(scan_su.value)) + ToNumber(unFormatComma(su.value)));

    // 合計訂正数量の再計算を行う
    /*
		Ｍ１訂正数量とＭ１訂正数量(隠し)の差分を取得し、合計数量に加算(減算)する。
		Ｍ１数量(隠し)にＭ１数量を設定する。
	*/
    sumSu.value = formatComma(ToNumber(unFormatComma(sumSu.value)) - (ToNumber(unFormatComma(suHid.value)) - ToNumber(unFormatComma(su.value))));

    // 総合計数量の再計算を行う
    /*
		Ｍ１訂正数量とＭ１訂正数量(隠し)の差分を取得し、合計数量に加算(減算)する。
		Ｍ１数量(隠し)にＭ１数量を設定する。
	*/
    sumGokeiSu.value = formatComma(ToNumber(unFormatComma(sumGokeiSu.value)) - (ToNumber(unFormatComma(suHid.value)) - ToNumber(unFormatComma(su.value))));

    // 隠し項目に変更後の数量を再設定
    suHid.value = su.value;

}



