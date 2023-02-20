/*-----------------------------------------------------------------------------
	モジュール:tf070f02_event_n.js
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
	md_tf070f02_register();
	
	//共通ロード設定
	setCommonLoad();

	// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
	// --------------------------
	// BO初期表示共通処理
	boLoadCommon();
	// --------------------------

	if (	(
				getAdvControlFromItemID(clm_StkMode).value != c_insert
			&&	getAdvControlFromItemID(clm_StkMode).value != c_modekeihisinsei
			&&	getAdvControlFromItemID(clm_StkMode).value != c_modeupd
			)
		||	getAdvControlFromItemID("Btnenter").disabled
		) {
		// モードが「新規作成」「経費申請」「修正」以外の場合、行選択不可
		selectorCheckBox = 'DISABLED';
	}
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
			if (	getAdvControlFromItemID(clm_StkMode).value == c_insert					// 新規作成
				||	(
						getAdvControlFromItemID(clm_StkMode).value == c_modekeihisinsei	// 経費申請
					&&	!getAdvControlFromItemID("Btnenter").disabled						// 確定ボタン有効
					)
				||	getAdvControlFromItemID(clm_StkMode).value == c_modeupd				// 修正
				) {
				// 確認メッセージを表示
				var yes = function () {
					$("#Btnback")[0].click();
				}
				var no = function () {
				}
				var msg = getMessage("W107");
				if (!boOpenInfoDialog(msg, yes, no)) {
					// いいえの場合、処理終了
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
			if (!boOpenInfoDialog(msg, yes, no)) {
				// いいえの場合、処理終了
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
	switch (eventTargetName.toUpperCase()) {
	//  ここに項目IDのcase文を追加し、固有処理を記述します。

		// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
		// -------------------
		// カード部
		// -------------------
		// 報告担当者コード
		case "Hokokutan_cd".toUpperCase():
			// 名称取得部品を起動
			V02005(getAdvControlFromItemID("Hokokutan_cd"), getAdvControlFromItemID("Hokokutan_nm"), getAdvControlFromItemID("Hokokutan_cd"));
			break;

		// 店長担当者コード
		case "Tentyotan_cd".toUpperCase():
			// 名称取得部品を起動
			V02005(getAdvControlFromItemID("Tentyotan_cd"), getAdvControlFromItemID("Tentyotan_nm"), getAdvControlFromItemID("Tentyotan_cd"));
			break;

		// -------------------
		// 明細部
		// -------------------
		// Ｍ１発生時間
		case "M1hassei_tm".toUpperCase():

			// 明細行番号を取得する
			var lineNo = getItemMNofromCtrl(eventTarget);
			// 操作ありの背景色に変更
			commitColorSet(lineNo);

			break;

		// Ｍ１発生場所
		case "M1hasseibasyo".toUpperCase():

			// 明細行番号を取得する
			var lineNo = getItemMNofromCtrl(eventTarget);
			// 操作ありの背景色に変更
			commitColorSet(lineNo);

			break;

		// Ｍ１発見担当者コード
		case "M1hakkentan_cd".toUpperCase():
			// 明細行番号を取得する
			var lineNo = getItemMNofromCtrl(eventTarget);
			// 操作ありの背景色に変更
			commitColorSet(lineNo);
			// 名称取得部品を起動
			V02005(getAdvControlFromItemID("M1hakkentan_cd", lineNo), getAdvControlFromItemID("M1hakkentan_nm", lineNo), getAdvControlFromItemID("M1hakkentan_cd", lineNo));
			break;

		// Ｍ１発見状況区分
		case "M1hakkenjyokyo_kb".toUpperCase():
			// 明細行番号を取得する
			var lineNo = getItemMNofromCtrl(eventTarget);
			// 操作ありの背景色に変更
			commitColorSet(lineNo);

			if (getAdvControlFromItemID("M1hakkenjyokyo_kb", lineNo).value == "9") {
				// その他の場合
				// Ｍ１発見状況　使用可
				itemDisabled(getAdvControlFromItemID("M1hakkenjyokyo_nm", lineNo), false);
			} else {
				// その他以外の場合
				// Ｍ１発見状況　使用不可
				getAdvControlFromItemID("M1hakkenjyokyo_nm", lineNo).value = "";
				itemDisabled(getAdvControlFromItemID("M1hakkenjyokyo_nm", lineNo), true);
			}
			break;

		// Ｍ１発見状況
		case "M1hakkenjyokyo_nm".toUpperCase():
			// 明細行番号を取得する
			var lineNo = getItemMNofromCtrl(eventTarget);
			// 操作ありの背景色に変更
			commitColorSet(lineNo);
			break;


		// Ｍ１スキャンコード
		case "M1scan_cd".toUpperCase():
			// 明細行番号を取得する
			var lineNo = getItemMNofromCtrl(eventTarget);
			// 操作ありの背景色に変更
			commitColorSet(lineNo);
			// 名称表示
			// 検索条件指定(Key：固定、Value：検索値)
			var condition = {
				"SCAN_CD": getAdvControlFromItemID("M1scan_cd", lineNo)	// スキャンコード
				, "TENPO_CD": getAdvControlFromItemID("Head_tenpo_cd")		// 店舗コード
				, "PLUFLG": "1"				// 店別単価マスタ検索フラグ		1:検索する
				, "PRICEFLG": "0"			// 売変検索フラグ				0:検索しない
				, "ZAIKOFLG": "0"			// 店在庫検索フラグ				0:検索しない
				, "NYUKAFLG": "0"			// 入荷予定数検索フラグ			0:検索しない
				, "URIFLG": "0"				// 売上実績数検索フラグ			0:検索しない
				, "HOJUFLG": "0"			// 依頼集計数(補充)検索フラグ	0:検索しない
				, "TANPINFLG": "0"			// 依頼集計数(単品)検索フラグ	0:検索しない
				, "SIJIFLG": "0"			// 指示検索検索フラグ			0:検索しない
				, "SIJI_NO": "0"			// 指示NO（移動出荷マニュアル、返品マニュアル用）
				, "SYUKAKAISYA_CD": "0"		// 出荷会社コード（移動出荷マニュアル)
				, "NYUKAKAISYA_CD": "0"		// 入荷会社コード（移動出荷マニュアル)
				, "SYUKATENPO_CD": "0"		// 指示店舗コード（移動出荷マニュアル、返品マニュアル用）
			};
			// 戻り値指定(Key：SELECT句、Value：項目名)
			var result = {
				"BUMON_CD": getAdvControlFromItemID("M1bumon_cd", lineNo)					// Ｍ１部門コード
				, "BUMONKANA_NM": getAdvControlFromItemID("M1bumonkana_nm", lineNo)		// Ｍ１部門カナ名
				, "HINSYU_RYAKU_NM": getAdvControlFromItemID("M1hinsyu_ryaku_nm", lineNo)	// Ｍ１品種略名称
				, "BURANDO_NMK": getAdvControlFromItemID("M1burando_nm", lineNo)			// Ｍ１ブランド名
				, "XEBIO_CD": getAdvControlFromItemID("M1jisya_hbn", lineNo)				// Ｍ１自社品番
				, "HIN_NBR": getAdvControlFromItemID("M1maker_hbn", lineNo)				// Ｍ１メーカー品番
				, "SYONMK": getAdvControlFromItemID("M1syonmk", lineNo)					// Ｍ１商品名(カナ)
				, "IRO_NM": getAdvControlFromItemID("M1iro_nm", lineNo)					// Ｍ１色
				, "SIZE_NM": getAdvControlFromItemID("M1size_nm", lineNo)					// Ｍ１サイズ
				, "BAIKA": getAdvControlFromItemID("M1baika_hon", lineNo)					// Ｍ１売価（本体）
			};
			// 名称取得部品
			V02004(condition, result, getAdvControlFromItemID("M1scan_cd", lineNo), true, lineNo);

			break;

		// Ｍ１申請数
		case "M1sinsei_su".toUpperCase():

			// 明細行番号を取得する
			var lineNo = getItemMNofromCtrl(eventTarget);
			// 合計値再計算
			calcRow(lineNo);

			// 操作ありの背景色に変更
			commitColorSet(lineNo);

			break;

		// Ｍ１受理数
		case "M1jyuri_su".toUpperCase():

			// 明細行番号を取得する
			var lineNo = getItemMNofromCtrl(eventTarget);
			// 合計値再計算
			calcRow(lineNo);

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
		case "Jyuri_no".toUpperCase():	// 受理番号
			// 大文字変換
			eventTarget.value = eventTarget.value.toUpperCase();
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
function onBeforeCodeSet(iDataArray, iItemId, iCodeId) {

	// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
	var rowNo = 0;
	var idArray = iItemId.split("$");
	if (idArray.length > 1) {
		// 明細項目の場合
		rowNo = Number(idArray[1].replace("ctl", ""));
		iItemId = idArray[2];
	}
	// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

	switch (iItemId) {
	//  ここに項目IDのcase文を追加し、固有処理を記述します。

		// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
		case "M1btntanto_cd":	// Ｍ１担当者コードボタン

			// 操作ありの背景色に変更
			commitColorSet(rowNo - 1);

			break;
		// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

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
	var baika = getAdvControlFromItemID("M1baika_hon", lineNo);
	baika.value = getAdvFormatStr("M1baika_hon", baika.value);

	// 合計値を再計算
	calcRow(lineNo);

}
// 明細合計値計算関数
function calcRow(lineNo) {

	// Ｍ１申請数
	var sinsu = getAdvControlFromItemID("M1sinsei_su", lineNo);
	// Ｍ１申請数(隠し)
	var sinsuHid = getAdvControlFromItemID("M1sinsei_su_hdn", lineNo);

	// Ｍ１受理量
	var jursu = getAdvControlFromItemID("M1jyuri_su", lineNo);
	// Ｍ１受理量(隠し)
	var jursuHid = getAdvControlFromItemID("M1jyuri_su_hdn", lineNo);

	// Ｍ１売価（本体）
	var baika = getAdvControlFromItemID("M1baika_hon", lineNo);

	// Ｍ１売価金額
	var baikaKin = getAdvControlFromItemID("M1baika_kin", lineNo);
	// Ｍ１売価金額(隠し)
	var baikaKinHid = getAdvControlFromItemID("M1baika_kin_hdn", lineNo);

	// 合計申請量
	var sumSinsu = getAdvControlFromItemID("Gokeisinsei_su");
	// 合計受理量
	var sumJursu = getAdvControlFromItemID("Gokeijyuri_su");
	// 合計売価金額
	var sumBaikaKin = getAdvControlFromItemID("Gokeibaika_kin");

	// 選択モードNo
	var mode = getAdvControlFromItemID(clm_StkMode).value;

	// ■Ｍ１売価金額の算出
	if (mode == c_insert || mode == c_modeupd) {
		// [選択モードNO]が「新規作成」、「修正」のいずれかの場合
		// [Ｍ１売価（本体）]×[Ｍ１申請数]
		baikaKin.value = formatComma(ToNumber(unFormatComma(baika.value)) * ToNumber(unFormatComma(sinsu.value)));
	} else {
		// [選択モードNO]が「経費申請」の場合
		// [Ｍ１売価（本体）]×[Ｍ１受理数]
		baikaKin.value = formatComma(ToNumber(unFormatComma(baika.value)) * ToNumber(unFormatComma(jursu.value)));
	}

	/*
		■合計申請数の算出
		[Ｍ１申請数]と[Ｍ１申請数(隠し)]の差分を取得し、[合計申請数]に加算(減算)する。
		[Ｍ１申請数(隠し)]に[Ｍ１申請数]を設定する。
	*/
	sumSinsu.value = formatComma(ToNumber(unFormatComma(sumSinsu.value)) + (ToNumber(unFormatComma(sinsu.value)) - ToNumber(unFormatComma(sinsuHid.value))));
	if (isNaN(Number(unFormatComma(sinsu.value)))) {
		// 数値でない場合
		sinsuHid.value = "0";
	} else {
		sinsuHid.value = sinsu.value;
	}

	/*
		■合計受理数の算出
		[Ｍ１受理数]と[Ｍ１受理数(隠し)]の差分を取得し、[合計受理数]に加算(減算)する。
		[Ｍ１受理数(隠し)]に[Ｍ１受理数]を設定する。
	*/
	sumJursu.value = formatComma(ToNumber(unFormatComma(sumJursu.value)) + (ToNumber(unFormatComma(jursu.value)) - ToNumber(unFormatComma(jursuHid.value))));
	if (isNaN(ToNumber(unFormatComma(jursu.value)))) {
		// 数値でない場合
		jursuHid.value = "0";
	} else {
		jursuHid.value = jursu.value;
	}

	/*
		■合計売価金額の算出
		[Ｍ１売価金額]と[Ｍ１売価金額(隠し)]の差分を取得し、[合計売価金額]に加算(減算)する。
		[Ｍ１売価金額(隠し)]に[Ｍ１売価金額]を設定する。
	*/
	sumBaikaKin.value = formatComma(ToNumber(unFormatComma(sumBaikaKin.value)) + (ToNumber(unFormatComma(baikaKin.value)) - ToNumber(unFormatComma(baikaKinHid.value))));
	baikaKinHid.value = baikaKin.value;
}

/**
 * 数値変換処理
 * @param {String} val 数値文字列 
 * @return {Number} 変換した値、変換に失敗した場合、0
 */
/*
function toNumber(val) {
	var convVal = Number(val);
	if (isNaN(convVal)) {
		// 数値でない場合
		convVal = 0;
	}
	return convVal;
}
*/