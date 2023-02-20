/*-----------------------------------------------------------------------------
	モジュール:ta020f02_event_n.js
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
	md_ta020f02_register();
	
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
			// モードが「新規作成」「申請」「修正」の場合、メッセージを出力
			if (getAdvControlFromItemID(clm_StkMode).value == c_insert
			 || getAdvControlFromItemID(clm_StkMode).value == c_modeapply
			 || getAdvControlFromItemID(clm_StkMode).value == c_modeupd ) {

				// 確認メッセージを表示
				var yes = function () {
					$("#Btnback")[0].click();
				}
				var no = function () { }
				var msg = getMessage("W107");
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
			var lineNo = getItemMNofromCtrl(eventTarget);
			// 操作ありの背景色に変更
			commitColorSet(lineNo);
			// 初期化
			getAdvControlFromItemID("M1genkakin", lineNo).value = "";
			// 名称表示
			// 検索条件指定(Key：固定、Value：検索値)
			var condition = {
				 "SCAN_CD"			: getAdvControlFromItemID("M1scan_cd", lineNo)	// スキャンコード
				,"TENPO_CD"			: getAdvControlFromItemID("Head_tenpo_cd")		// 店舗コード
				,"PLUFLG"			: "0"											// 店別単価マスタ	検索フラグ 0:検索しない 1:検索する
				,"PRICEFLG"			: "0"											// 売変				検索フラグ 0:検索しない 1:検索する
				,"ZAIKOFLG"			: "1"											// 店在庫			検索フラグ 0:検索しない 1:検索する
				,"NYUKAFLG"			: "1"											// 入荷予定数		検索フラグ 0:検索しない 1:検索する
				,"URIFLG"			: "1"											// 売上実績数		検索フラグ 0:検索しない 1:検索する
				,"HOJUFLG"			: "1"											// 依頼集計数(補充)	検索フラグ 0:検索しない 1:検索する
				,"TANPINFLG"		: "0"											// 依頼集計数(単品)	検索フラグ 0:検索しない 1:検索する
				,"SIJIFLG"			: "0"											// 指示検索			検索フラグ 0:検索しない 1:出荷指示、2:返品指示
				,"SIJI_NO"			: "0"											// 指示NO（移動出荷マニュアル、返品マニュアル用）
				,"SYUKAKAISYA_CD"	: "0"											// 出荷会社コード（移動出荷マニュアル)
				,"NYUKAKAISYA_CD"	: "0"											// 入荷会社コード（移動出荷マニュアル)
				,"SYUKATENPO_CD"	: "0"											// 指示店舗コード（移動出荷マニュアル、返品マニュアル用）
			};
			// 戻り値指定(Key：SELECT句、Value：項目名)
			var result = {
				 "BUMONKANA_NM": getAdvControlFromItemID("M1bumonkana_nm", lineNo)			// 部門カナ名
				,"HYOKA_NM": getAdvControlFromItemID("M1hyoka_kb", lineNo)					// 評価区分
				,"HATYUTAISYO_NM": getAdvControlFromItemID("M1kahi_nm", lineNo)			// 可否名称
				,"REAL_SU": getAdvControlFromItemID("M1tenzaiko_su", lineNo)				// 店在庫数
				,"HINSYU_RYAKU_NM": getAdvControlFromItemID("M1hinsyu_ryaku_nm", lineNo)	// 品種略名称
				,"NYUKA_SU": getAdvControlFromItemID("M1nyukayotei_su", lineNo)			// 入荷予定数
				,"URI_SU": getAdvControlFromItemID("M1uriage_su", lineNo)					// 売上実績数
				,"BURANDO_NMK": getAdvControlFromItemID("M1burando_nm", lineNo)			// ブランド名
				,"JIDO_SU": getAdvControlFromItemID("M1jido_su", lineNo)					// 自動定数
				,"XEBIO_CD": getAdvControlFromItemID("M1jisya_hbn", lineNo)				// 自社品番
				,"SYOHIN_ZOKUSEI": getAdvControlFromItemID("M1syohin_zokusei", lineNo)		// 商品属性
				,"IRO_NM": getAdvControlFromItemID("M1iro_nm", lineNo)						// 色
				,"SIZE_NM": getAdvControlFromItemID("M1size_nm", lineNo)					// サイズ
				,"HIN_NBR": getAdvControlFromItemID("M1maker_hbn", lineNo)					// メーカー品番
				,"SYONMK": getAdvControlFromItemID("M1syonmk", lineNo)						// 商品名(カナ)
				,"GENKA": getAdvControlFromItemID("M1gen_tnk", lineNo)					// 原単価
			};

			// 名称取得部品
			V02004(condition, result, getAdvControlFromItemID("M1scan_cd", lineNo), true, lineNo);

			break;
		// -------------------
		// 依頼数量
		// -------------------
		case "M1irai_su".toUpperCase():
			// 明細行番号を取得する
			var lineNo = getItemMNofromCtrl(eventTarget);
			// 操作ありの背景色に変更
			commitColorSet(lineNo);
			// 合計値を再計算
			calcRow(lineNo);
			if (getAdvControlFromItemID("M1irai_su", lineNo).value == "") {
				getAdvControlFromItemID("M1genkakin", lineNo).value = '';			// 原価金額
			}

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
	if (getAdvControlFromItemID("M1scan_cd", lineNo).value != "") {

		// フォーマット処理
		// 店在庫数
		Obj = getAdvControlFromItemID("M1tenzaiko_su", lineNo);
		Obj.value = getAdvFormatStr("M1tenzaiko_su", Obj.value);
		// 入荷予定数
		Obj = getAdvControlFromItemID("M1nyukayotei_su", lineNo);
		Obj.value = getAdvFormatStr("M1nyukayotei_su", Obj.value);
		// 売上実績数
		Obj = getAdvControlFromItemID("M1uriage_su", lineNo);
		Obj.value = getAdvFormatStr("M1uriage_su", Obj.value);
		// 自動定数
		Obj = getAdvControlFromItemID("M1jido_su", lineNo);
		Obj.value = getAdvFormatStr("M1jido_su", Obj.value);
		//// 依頼集計
		//Obj = getAdvControlFromItemID("M1irai_syukei", lineNo);
		//Obj.value = getAdvFormatStr("M1irai_syukei", Obj.value);

		// 合計値を再計算
		calcRow(lineNo);
		if (getAdvControlFromItemID("M1gen_tnk", lineNo).value == "") {
			getAdvControlFromItemID("M1genkakin", lineNo).value = '';
		}
	} else {
		clearRow(lineNo);
	}
}
// 明細合計値計算関数
function calcRow(lineNo) {

	// Ｍ１依頼数量
	var su = getAdvControlFromItemID("M1irai_su", lineNo);
	// Ｍ１依頼数量(隠し)
	var suHid = getAdvControlFromItemID("M1irai_su_hdn", lineNo);
	// Ｍ１原単価(隠し)
	var genka = getAdvControlFromItemID("M1gen_tnk", lineNo);
	// Ｍ１原価金額
	var genkaKin = getAdvControlFromItemID("M1genkakin", lineNo);
	// Ｍ１原価金額(隠し)
	var genkaKinHid = getAdvControlFromItemID("M1genkakin_hdn", lineNo);

	// 合計依頼数量
	var sumSu = getAdvControlFromItemID("Gokei_irai_su");
	// 合計原価金額
	var sumGenkaKin = getAdvControlFromItemID("Gokei_genkakin");
	
	// Ｍ１依頼数量×Ｍ１原単価(隠し)をＭ１原価金額に設定する。
	genkaKin.value = formatComma(ToNumber(unFormatComma(su.value)) * ToNumber(unFormatComma(genka.value)));

	// 合計依頼数量の再計算を行う
	/* 
		Ｍ１依頼数量とＭ１数量(隠し)の差分を取得し、合計依頼数量に加算(減算)する。
		Ｍ１依頼数量(隠し)にＭ１依頼数量を設定する。
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

// 明細項目初期化
function clearRow(lineNo) {
	// 明細項目の初期化
	getAdvControlFromItemID("M1bumonkana_nm", lineNo).value = '';		// 部門カナ名
	getAdvControlFromItemID("M1hyoka_kb", lineNo).value = '';			// 評価区分
	getAdvControlFromItemID("M1kahi_nm", lineNo).value = '';			// 可否名称
	getAdvControlFromItemID("M1tenzaiko_su", lineNo).value = '';		// 店在庫数
	getAdvControlFromItemID("M1hinsyu_ryaku_nm", lineNo).value = '';	// 品種略名称
	getAdvControlFromItemID("M1nyukayotei_su", lineNo).value = '';		// 入荷予定数
	getAdvControlFromItemID("M1uriage_su", lineNo).value = '';			// 売上実績数
	getAdvControlFromItemID("M1burando_nm", lineNo).value = '';		// ブランド名
	getAdvControlFromItemID("M1jido_su", lineNo).value = '';			// 自動定数
	getAdvControlFromItemID("M1jisya_hbn", lineNo).value = '';			// 自社品番
	getAdvControlFromItemID("M1syohin_zokusei", lineNo).value = '';	// 商品属性
	getAdvControlFromItemID("M1iro_nm", lineNo).value = '';			// 色
	getAdvControlFromItemID("M1size_nm", lineNo).value = '';			// サイズ
	getAdvControlFromItemID("M1maker_hbn", lineNo).value = '';			// メーカー品番
	getAdvControlFromItemID("M1syonmk", lineNo).value = '';			// 商品名(カナ)
	getAdvControlFromItemID("M1hatchu_msg", lineNo).value = '';		// 発注メッセージ
	getAdvControlFromItemID("M1genkakin", lineNo).value = '';			// 原価金額
	getAdvControlFromItemID("M1gen_tnk", lineNo).value = '';			// 原単価(隠し)
	getAdvControlFromItemID("M1genkakin_hdn", lineNo).value = '';		// 原価金額〈隠し〉
}