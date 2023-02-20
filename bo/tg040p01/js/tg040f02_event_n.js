/*-----------------------------------------------------------------------------
	モジュール:tg040f02_event_n.js
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
	md_tg040f02_register();
	
	//共通ロード設定
	setCommonLoad();

	// --------------------------
	// BO初期表示共通処理
	boLoadCommon();
	// --------------------------
	
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

		// 戻るボタン
		case "Btnback".toUpperCase():

			// [選択モードNo]が「修正」の場合または新規作成ボタンクリックで遷移してきた場合
			if (getAdvControlFromItemID("Stkmodeno").value == 8 || checkBtninsert()) {
				// 確認メッセージを表示
				var yes = function () {
					$("#Btnback")[0].click();
				}
				var no = function () {
				}
				var msg = getMessage("W107");
				if (boOpenInfoDialog(msg, yes, no) == false) {
					// いいえの場合、処理終了
					return false;
				}
			}
			break;

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

		//// Ｆ２　削除
		//case "BTNSKJ":
		//	// ＵＩＢＬＯＣＫにてメッセージＩ４０３：削除しますが、よろしいですか？
		//	return confirmPanel(event , "cmDelConfirm", getMessage("I403"));
		//// Ｆ４　更新
		//case "BTNKSN":
		//	// ＵＩＢＬＯＣＫにてメッセージＩ４０２：更新しますが、よろしいですか？
		//	return confirmPanel(event , "cmInsConfirm", getMessage("I402"));

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
	var eventTargetName = getAdvEventTargetName(ev);

	// 明細行番号を取得する
	var lineNo = getItemMNofromCtrl(eventTarget);

	switch (eventTargetName.toUpperCase()) {
		//  ここに項目IDのcase文を追加し、固有処理を記述します。

		case "M1scan_cd".toUpperCase():		// Ｍ１スキャンコード
			// 丸め処理部品を起動
			formatScanCd(getAdvControlFromItemID("M1scan_cd", lineNo));
			// 名称表示
			// 検索条件指定(Key：固定、Value：検索値)
			var condition = {
				"SCAN_CD": getAdvControlFromItemID("M1scan_cd", lineNo)	// スキャンコード
				, "TENPO_CD": getAdvControlFromItemID("Head_tenpo_cd")		// 店舗コード
				, "PLUFLG": "0"												// 店別単価マスタ	検索フラグ 0:検索しない 1:検索する
				, "PRICEFLG": "0"											// 売変				検索フラグ 0:検索しない 1:検索する
				, "ZAIKOFLG": "0"											// 店在庫			検索フラグ 0:検索しない 1:検索する
				, "NYUKAFLG": "0"											// 入荷予定数		検索フラグ 0:検索しない 1:検索する
				, "URIFLG": "0"												// 売上実績数		検索フラグ 0:検索しない 1:検索する
				, "HOJUFLG": "0"											// 依頼集計数(補充)	検索フラグ 0:検索しない 1:検索する
				, "TANPINFLG": "0"											// 依頼集計数(単品)	検索フラグ 0:検索しない 1:検索する
				, "SIJIFLG": "0"											// 指示検索			検索フラグ 0:検索しない 1:出荷指示、2:返品指示
				, "SIJI_NO": "0"											// 指示NO（移動出荷マニュアル、返品マニュアル用）
				, "SYUKAKAISYA_CD": "0"										// 出荷会社コード（移動出荷マニュアル)
				, "NYUKAKAISYA_CD": "0"										// 入荷会社コード（移動出荷マニュアル)
				, "SYUKATENPO_CD": "0"										// 指示店舗コード（移動出荷マニュアル、返品マニュアル用）
			};
			// 戻り値指定(Key：SELECT句、Value：項目名)
			var result = {
				"BUMON_CD": getAdvControlFromItemID("M1bumon_cd", lineNo)						// 部門コード
				, "BUMONKANA_NM": getAdvControlFromItemID("M1bumonkana_nm", lineNo)			// 部門名カナ
				, "HINSYU_RYAKU_NM": getAdvControlFromItemID("M1hinsyu_ryaku_nm", lineNo)		// 品種名カナ
				, "BURANDO_NMK": getAdvControlFromItemID("M1burando_nm", lineNo)				// ブランド名
				, "XEBIO_CD": getAdvControlFromItemID("M1jisya_hbn", lineNo)					// 自社品番
				, "HANBAIKANRYO_YMD": getAdvControlFromItemID("M1hanbaikanryo_ymd", lineNo)	// 販売完了日
				, "HIN_NBR": getAdvControlFromItemID("M1maker_hbn", lineNo)					// メーカー品番
				, "SYONMK": getAdvControlFromItemID("M1syonmk", lineNo)						// 商品略式名称カナ
				, "IRO_NM": getAdvControlFromItemID("M1iro_nm", lineNo)						// 色名
				, "SIZE_NM": getAdvControlFromItemID("M1size_nm", lineNo)						// サイズ名
			};
			// 名称取得部品
			V02004(condition, result, getAdvControlFromItemID("M1scan_cd", lineNo), true, lineNo);

			// 操作ありの背景色に変更
			commitColorSet(lineNo);
			break;

		case "M1suryo".toUpperCase():	// 数量
			// 合計値再計算
			calcRowSuryo(lineNo);
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
// スキャンコード名称取得の出口ルーチン
function responseHandle_onAfter(lineNo) {
	// フォーマット処理を実行する為、フォーカス処理を実行
	// 販売完了日
	var hanbaikanryo_ymd = getAdvControlFromItemID("M1hanbaikanryo_ymd", lineNo);
	hanbaikanryo_ymd.value = getAdvFormatStr("M1hanbaikanryo_ymd", hanbaikanryo_ymd.value);
	// 数量
	var suryo = getAdvControlFromItemID("M1suryo", lineNo);
	suryo.value = getAdvFormatStr("M1suryo", suryo.value);
	// 合計値再計算
	calcRowSuryo(lineNo);
}

// 合計数量計算
function calcRowSuryo(plineNo) {
	// 明細行番号を取得する
	var lineNo = plineNo;

	// 項目値取得
	var suryo = getAdvControlFromItemID("M1suryo", lineNo);			// Ｍ１数量
	var suryo_hdn = getAdvControlFromItemID("M1suryo_hdn", lineNo);	// Ｍ１数量（隠し）
	var sum_suryo = getAdvControlFromItemID("Gokei_suryo");			// 合計数量

	// 合計残高再設定
	sum_suryo.value = formatComma(ToNumber(unFormatComma(sum_suryo.value)) + ToNumber(unFormatComma(suryo.value)) - ToNumber(unFormatComma(suryo_hdn.value)));
	suryo_hdn.value = formatComma(suryo.value);
}

// 「新規作成」チェック
function checkBtninsert() {

	if (getAdvControlFromItemID("Stock_no").value == ""
		&& getAdvControlFromItemID("Ymd").value == ""
		&& getAdvControlFromItemID("Tm").value == ""
		&& getAdvControlFromItemID("Nyuryokutan_cd").value == ""
		&& getAdvControlFromItemID("Nyuryokutan_nm").value == "")
	{
		return true;
	}

	return false;
}