/*-----------------------------------------------------------------------------
	モジュール:tk010f02_event_n.js
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
	md_tk010f02_register();
	
	//共通ロード設定
	setCommonLoad();
	
	// --------------------------
	// BO初期表示共通処理
	boLoadCommon();
	// --------------------------
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
		// 戻るボタン
		case "Btnback".toUpperCase():

			// モードの取得
			var mode = getAdvControlFromItemID(clm_StkMode).value

			// 確定、修正モードの場合
			if (mode == c_modeupd || mode == c_modekakutei) {

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
		// -------------------
		// Ｍ１承認状態
		// -------------------
		case "M1syonin_flg".toUpperCase():

			// 明細行番号を取得する
			var lineNo = getItemMNofromCtrl(eventTarget);

			// [Ｍ１却下フラグ]が入力済みの場合、未入力にする。
			getAdvControlFromItemID("M1kyakka_flg", lineNo).checked = false;

			// 確定処理
			enterSyori(lineNo);

			break;

		// -------------------
		// Ｍ１却下フラグ
		// -------------------
		case "M1kyakka_flg".toUpperCase():

			// 明細行番号を取得する
			var lineNo = getItemMNofromCtrl(eventTarget);

			// [Ｍ１承認フラグ]が入力済みの場合、未入力にする。
			getAdvControlFromItemID("M1syonin_flg", lineNo).checked = false;

			// 確定処理
			enterSyori(lineNo);

			break;

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

			// スキャンコード丸め処理
			formatScanCd(getAdvControlFromItemID("M1scan_cd", lineNo));

			// 操作ありの背景色に変更
			commitColorSet(lineNo);

			// ツールチップ初期化
			// 部門コード tooltip設定
			getAdvControlFromItemID("M1bumon_cd", lineNo).title = "";

			// 品種コード tooltip設定
			getAdvControlFromItemID("M1hinsyu_cd", lineNo).title = "";

			// 名称表示
			// 検索条件指定(Key：固定、Value：検索値)
			var condition = {
				"SCAN_CD": getAdvControlFromItemID("M1scan_cd", lineNo)	// スキャンコード
				, "TENPO_CD": getAdvControlFromItemID("Tenpo_cd")			// 店舗コード
				, "PLUFLG": "0"												// 店別単価マスタ	検索フラグ 0:検索しない 1:検索する
				, "PRICEFLG": "0"											// 売変				検索フラグ 0:検索しない 1:検索する
				, "ZAIKOFLG": "2"											// 店在庫			検索フラグ 0:検索しない 1:検索する
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
				, "BUMONKANA_NM": getAdvControlFromItemID("M1bumon_nm", lineNo)				// 部門名カナ　ツールチップ用
				, "HINSYU_CD": getAdvControlFromItemID("M1hinsyu_cd", lineNo)					// 品種コード
				, "HINSYU_RYAKU_NM": getAdvControlFromItemID("M1hinsyu_ryaku_nm", lineNo)		// 品種名カナ 　ツールチップ用
				// , "BURANDO_CD": getAdvControlFromItemID("", lineNo)							// ブランドコード
				, "BURANDO_NMK": getAdvControlFromItemID("M1burando_nm", lineNo)				// ブランド名
				, "XEBIO_CD": getAdvControlFromItemID("M1jisya_hbn", lineNo)					// 自社品番
				, "HANBAIKANRYO_YMD": getAdvControlFromItemID("M1hanbaikanryo_ymd", lineNo)	// 販売完了日
				, "HIN_NBR": getAdvControlFromItemID("M1maker_hbn", lineNo)					// メーカー品番
				, "SYONMK": getAdvControlFromItemID("M1syonmk", lineNo)						// 商品略式名称カナ
				// ,  "MAKERCOLOR_CD": getAdvControlFromItemID("", lineNo)						// 色コード
				, "IRO_NM": getAdvControlFromItemID("M1iro_nm", lineNo)						// 色名
				//, "SIZE_CD": getAdvControlFromItemID("", lineNo)								// サイズコード
				, "SIZE_NM": getAdvControlFromItemID("M1size_nm", lineNo)						// サイズ名
				, "SLPR": getAdvControlFromItemID("M1genbaika_tnk", lineNo)					// 上代１(現売価)
				, "HYOKA_TNK": getAdvControlFromItemID("M1gen_tnk", lineNo)					// 原価
				, "TYOTATSUKB_NM": getAdvControlFromItemID("M1tyotatsu_nm", lineNo)			// 調達区分　表示しない？？
				// , "SEKISO_SU": getAdvControlFromItemID("M1tanajisekiso_su", lineNo)			// 商品コード
			};

			// 名称取得部品
			V02004(condition, result, getAdvControlFromItemID("M1scan_cd", lineNo), true, lineNo);

			break;

		// -------------------
		// Ｍ１評価損種別区分
		// -------------------
		// Ｍ１評価損種別区分：「経年品」の場合、Ｍ１評価損理由区分を入力不可にし、「経年商品」固定とする。
		// Ｍ１評価損種別区分：「販売不可」の場合、Ｍ１評価損理由区分を入力可能にし、「経年商品」以外の表示を行う。
		case "M1hyokasonsyubetsu_kb".toUpperCase():
			// 明細行番号を取得する
			var lineNo = getItemMNofromCtrl(eventTarget);

			// 販売不可の場合
			if (getAdvControlFromItemID("M1hyokasonsyubetsu_kb", lineNo).value == p_hyokasonsyubetsu_kb1) {
				getAdvControlFromItemID("M1hyokasonriyu_kb", lineNo).style.display = "";
				getAdvControlFromItemID("M1hyokasonriyu_kb_keinen", lineNo).style.display = "none";
			}
				// 経年品の場合
			else if (getAdvControlFromItemID("M1hyokasonsyubetsu_kb", lineNo).value == p_hyokasonsyubetsu_kb2) {
				getAdvControlFromItemID("M1hyokasonriyu_kb", lineNo).style.display = "none";
				getAdvControlFromItemID("M1hyokasonriyu_kb_keinen", lineNo).style.display = "";
			}

			// 確定処理
			enterSyori(lineNo);

			break;

		// -------------------
		// Ｍ１数量
		// -------------------
		case "M1suryo".toUpperCase():

			// 明細行番号を取得する
			var lineNo = getItemMNofromCtrl(eventTarget);

			// 確定処理
			enterSyori(lineNo);

			break;

		// -------------------
		// Ｍ１評価損理由区分
		// -------------------
		case "M1hyokasonriyu_kb".toUpperCase():

			// 明細行番号を取得する
			var lineNo = getItemMNofromCtrl(eventTarget);

			// 確定処理
			enterSyori(lineNo);

			break;

		// -------------------
		// Ｍ１評価損理由
		// -------------------
		case "M1hyokasonriyu".toUpperCase():

			// 明細行番号を取得する
			var lineNo = getItemMNofromCtrl(eventTarget);

			// 確定処理
			enterSyori(lineNo);

			break;

		// -------------------
		// Ｍ１却下理由区分
		// -------------------
		case "M1kyakkariyu_kb".toUpperCase():

			// 明細行番号を取得する
			var lineNo = getItemMNofromCtrl(eventTarget);

			// 確定処理
			enterSyori(lineNo);

			break;

		// -------------------
		// Ｍ１却下理由
		// -------------------
		case "M1kyakkariyu".toUpperCase():

			// 明細行番号を取得する
			var lineNo = getItemMNofromCtrl(eventTarget);

			// 確定処理
			enterSyori(lineNo);

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
		case "M1suryo".toUpperCase():	// 数量

			// 明細行番号を取得する
			var lineNo = getItemMNofromCtrl(eventTarget);

			// 再計算
			calcRow(lineNo);

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

	// 部門コード
	var bumon_cd = getAdvControlFromItemID("M1bumon_cd", lineNo);
	bumon_cd.value = getAdvFormatStr("M1bumon_cd", bumon_cd.value);

	// 品種コード
	var hinsyu_cd = getAdvControlFromItemID("M1hinsyu_cd", lineNo);
	hinsyu_cd.value = getAdvFormatStr("M1hinsyu_cd", hinsyu_cd.value);

	// 上代１(現売価)
	var genbaika_tnk = getAdvControlFromItemID("M1genbaika_tnk", lineNo);
	genbaika_tnk.value = getAdvFormatStr("M1genbaika_tnk", genbaika_tnk.value);

	// 原価
	var gen_tnk = getAdvControlFromItemID("M1gen_tnk", lineNo);
	gen_tnk.value = getAdvFormatStr("M1gen_tnk", gen_tnk.value);

	// 販売完了日
	getAdvControlFromItemID("M1hanbaikanryo_ymd", lineNo).value = getAdvControlFromItemID("M1hanbaikanryo_ymd", lineNo).value.substring(2,8);
	
	// 部門コード tooltip設定
	getAdvControlFromItemID("M1bumon_cd", lineNo).title = getAdvControlFromItemID("M1bumon_nm", lineNo).value;

	// 品種コード tooltip設定
	getAdvControlFromItemID("M1hinsyu_cd", lineNo).title = getAdvControlFromItemID("M1hinsyu_ryaku_nm", lineNo).value;

	// 再計算処理
	calcRow(lineNo);

}

// 原価金額、合計数量、合計原価金額計算
function calcRow(lineNo) {

	// M1数量×M1原単価をM1原価金額に設定する
	var newGen_tnk = 0;
	newGen_tnk = ToNumber(unFormatComma(getAdvControlFromItemID("M1suryo", lineNo).value))
				* ToNumber(unFormatComma(getAdvControlFromItemID("M1gen_tnk", lineNo).value));
	getAdvControlFromItemID("M1genkakin", lineNo).value = formatComma(newGen_tnk);

	// 合計数量の再計算を行う
	var vSuryo = 0;
	vSuryo = ToNumber(unFormatComma(getAdvControlFromItemID("M1suryo_hdn", lineNo).value))
					- ToNumber(unFormatComma(getAdvControlFromItemID("M1suryo", lineNo).value));
	getAdvControlFromItemID("Gokei_suryo").value = formatComma(ToNumber(unFormatComma(getAdvControlFromItemID("Gokei_suryo").value)) - vSuryo);

	// 数量(隠し)を最新化する
	getAdvControlFromItemID("M1suryo_hdn", lineNo).value = ToNumber(unFormatComma(getAdvControlFromItemID("M1suryo", lineNo).value));

	// 合計原価金額の再計算を行う
	var vSumKin = 0;
	vSumKin = ToNumber(unFormatComma(getAdvControlFromItemID("M1genkakin_hdn", lineNo).value))
					- ToNumber(unFormatComma(getAdvControlFromItemID("M1genkakin", lineNo).value));

	getAdvControlFromItemID("Haibun_kin_gokei").value = formatComma(ToNumber(unFormatComma(getAdvControlFromItemID("Haibun_kin_gokei").value)) - vSumKin);

	// 原価金額(隠し)を最新化する
	getAdvControlFromItemID("M1genkakin_hdn", lineNo).value = ToNumber(unFormatComma(getAdvControlFromItemID("M1genkakin", lineNo).value));

}

// 確定フラグ更新
function enterSyori(lineNo) {

	// 操作ありの背景色に変更
	commitColorSet(lineNo);

	// 確定処理フラグを1にする
	getAdvControlFromItemID("M1entersyoriflg", lineNo).value = 1;
}