/*-----------------------------------------------------------------------------
	モジュール:tm040f01_event_n.js
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
	md_tm040f01_register();
	
	//共通ロード設定
	setCommonLoad();

	// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
	// --------------------------
	// BO初期表示共通処理
	boLoadCommon();
	// --------------------------

	// 行選択を無効
	selectorCheckBox = 'DISABLED';
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

			// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
			// モードなしの表示に戻す
			document.all.item(clm_StkMode).value = "";
			nonmodeDisp();
			// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

			AdvGB_LastClickItemNm = null;
			return false;
		}
	}

	// ここに業務固有チェック処理を記述します。
	switch (AdvGB_LastClickItemNm.toUpperCase()) {
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

		// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
		// -------------------
		// 旧自社品番
		// -------------------
		case "Old_jisya_hbn".toUpperCase():

			// 自社品番丸め処理
			formatJisyaHbnCd(getAdvControlFromItemID("Old_jisya_hbn"));

			// 検索条件指定(Key：固定、Value：検索値)
			var condition = {
				"SCAN_CD": getAdvControlFromItemID("Old_jisya_hbn")			// 自社品番
				,"TENPO_CD": getAdvControlFromItemID("Tenpo_cd")				// 店舗コード
				, "PLUFLG": getAdvControlFromItemID("Pluflg")					// 店別単価マスタ検索フラグ
				, "PRICEFLG": getAdvControlFromItemID("Priceflg")				// 売変検索フラグ
				, "ZAIKOFLG": getAdvControlFromItemID("Zaikoflg")				// 店在庫検索フラグ
				, "NYUKAFLG": getAdvControlFromItemID("Nyukaflg")				// 入荷予定数検索フラグ
				, "URIFLG": getAdvControlFromItemID("Uriflg")					// 売上実績数検索フラグ
				, "HOJUFLG": getAdvControlFromItemID("Hojuflg")				// 依頼集計数(補充)検索フラグ
				, "TANPINFLG": getAdvControlFromItemID("Tanpinflg")			// 依頼集計数(単品)検索フラグ
				, "SIJIFLG": getAdvControlFromItemID("Sijiflg")				// 指示検索フラグ
				, "SIJI_NO": getAdvControlFromItemID("Siji_bango")				// 指示番号
				, "SYUKAKAISYA_CD": getAdvControlFromItemID("Syukkakaisya_cd")	// 出荷会社コード
				, "NYUKAKAISYA_CD": getAdvControlFromItemID("Jyuryokaisya_cd")	// 入荷会社コード
				, "SYUKATENPO_CD": getAdvControlFromItemID("Syukkaten_cd")		// 出荷店コード
			};
			// 戻り値指定(Key：SELECT句、Value：項目名)
			var result = {
				"BUMON_NM": getAdvControlFromItemID("Bumon_nm")					// 部門名
				, "HINSYU_RYAKU_NM": getAdvControlFromItemID("Hinsyu_ryaku_nm")	// 品種略名称
				, "BURANDO_NMK": getAdvControlFromItemID("Burando_nm")				// ブランド名
				, "HIN_NBR": getAdvControlFromItemID("Maker_hbn")					// メーカー品番
				, "SYONMK": getAdvControlFromItemID("Syonmk")						// 商品名(カナ)
			};

			// 名称取得部品
			V02003(condition, result, getAdvControlFromItemID("Old_jisya_hbn"), false, null);

			break;

		// -------------------
		// スキャンコード
		// -------------------
		case "Scan_cd".toUpperCase():

			// スキャンコード丸め処理
			formatScanCd(getAdvControlFromItemID("Scan_cd"))

			// 名称表示
			// 検索条件指定(Key：固定、Value：検索値)
			var condition = {
				"SCAN_CD": getAdvControlFromItemID("Scan_cd")					// スキャンコード
				, "TENPO_CD": getAdvControlFromItemID("Tenpo_cd")				// 店舗コード
				, "PLUFLG": getAdvControlFromItemID("Pluflg")					// 店別単価マスタ検索フラグ
				, "PRICEFLG": getAdvControlFromItemID("Priceflg")				// 売変検索フラグ
				, "ZAIKOFLG": getAdvControlFromItemID("Zaikoflg")				// 店在庫検索フラグ
				, "NYUKAFLG": getAdvControlFromItemID("Nyukaflg")				// 入荷予定数検索フラグ
				, "URIFLG": getAdvControlFromItemID("Uriflg")					// 売上実績数検索フラグ
				, "HOJUFLG": getAdvControlFromItemID("Hojuflg")				// 依頼集計数(補充)検索フラグ
				, "TANPINFLG": getAdvControlFromItemID("Tanpinflg")			// 依頼集計数(単品)検索フラグ
				, "SIJIFLG": getAdvControlFromItemID("Sijiflg")				// 指示検索フラグ
				, "SIJI_NO": getAdvControlFromItemID("Siji_bango")				// 指示番号
				, "SYUKAKAISYA_CD": getAdvControlFromItemID("Syukkakaisya_cd")	// 出荷会社コード
				, "NYUKAKAISYA_CD": getAdvControlFromItemID("Jyuryokaisya_cd")	// 入荷会社コード
				, "SYUKATENPO_CD": getAdvControlFromItemID("Syukkaten_cd")		// 出荷店コード
			};
			// 戻り値指定(Key：SELECT句、Value：項目名)
			var result = {
				"BUMON_NM": getAdvControlFromItemID("Bumon_nm")					// 部門名
				, "HINSYU_RYAKU_NM": getAdvControlFromItemID("Hinsyu_ryaku_nm")	// 品種略名称
				, "BURANDO_NMK": getAdvControlFromItemID("Burando_nm")				// ブランド名
				, "HIN_NBR": getAdvControlFromItemID("Maker_hbn")					// メーカー品番
				, "SYONMK": getAdvControlFromItemID("Syonmk")						// 商品名(カナ)
			};

			// 名称取得部品
			V02004(condition, result, getAdvControlFromItemID("Scan_cd"), false, null);

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
		// -------------------
		// 旧自社品番
		// -------------------
		case "Old_jisya_hbn".toUpperCase():
			// 自社品番丸め処理
			formatJisyaHbnCd(getAdvControlFromItemID("Old_jisya_hbn"));
			break;

			// -------------------
			// スキャンコード
			// -------------------
		case "Scan_cd".toUpperCase():
			// スキャンコード丸め処理
			formatScanCd(getAdvControlFromItemID("Scan_cd"))
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

