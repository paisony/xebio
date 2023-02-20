/*-----------------------------------------------------------------------------
	モジュール:td020f01_event_n.js
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
	md_td020f01_register();
	
	//共通ロード設定
	setCommonLoad();

	// --------------------------
	// BO初期表示共通処理
	boLoadCommon();
	// --------------------------

	// 返品理由のドロップダウン表示制御
	HenpinRiyuControl();
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
		case "Head_tenpo_cd".toUpperCase():	// ヘッダ店舗コード
			// 名称取得部品を起動
			V02001(getAdvControlFromItemID("Head_tenpo_cd"), getAdvControlFromItemID("Head_tenpo_nm"), getAdvControlFromItemID("Head_tenpo_cd"));
			break;
		case "Henpin_riyu".toUpperCase():	// 返品理由
			// 返品理由のドロップダウン表示制御
			HenpinRiyuControl();
			break;
		case "Siji_bango".toUpperCase():	// 指示番号
			// 名称取得部品
			V02018(  getAdvControlFromItemID("Head_tenpo_cd")			// 店舗コード
					,getAdvControlFromItemID("Siji_bango")				// 返品指示番号
					,getAdvControlFromItemID("Siiresaki_cd")			// 仕入先コード
					,getAdvControlFromItemID("Siiresaki_ryaku_nm")		// 仕入先略式名称
					,getAdvControlFromItemID("Siji_bango")				// 返品指示番号
			);
			break;
		case "Siiresaki_cd".toUpperCase():	// 仕入先コード
			// 名称取得部品を起動
			V02002(getAdvControlFromItemID("Siiresaki_cd"), getAdvControlFromItemID("Siiresaki_ryaku_nm"), getAdvControlFromItemID("Siiresaki_cd"));
			break;
		case "M1tenpo_cd".toUpperCase():
			// 明細行番号を取得する
			var lineNo = getItemMNofromCtrl(eventTarget);
			// 操作ありの背景色に変更
			commitColorSet(lineNo);
			// 名称取得部品を起動
			V02001(getAdvControlFromItemID("M1tenpo_cd", lineNo), getAdvControlFromItemID("M1tenpo_nm", lineNo), getAdvControlFromItemID("M1tenpo_cd",lineNo));
			break;
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

			var wkSiji = "0";
			formatSijinoHenpin(getAdvControlFromItemID("Siji_bango"));
			if (getAdvControlFromItemID("Siji_bango").value != "")
			{
				wkSiji = getAdvControlFromItemID("Siji_bango").value;
			}

			// 名称表示
			// 検索条件指定(Key：固定、Value：検索値)
			var condition = {
				 "SCAN_CD"			: getAdvControlFromItemID("M1scan_cd", lineNo)		// スキャンコード
				,"TENPO_CD"			: getAdvControlFromItemID("M1tenpo_cd", lineNo)	// 店舗コード
				,"PLUFLG"			: "0"												// 店別単価マスタ	検索フラグ 0:検索しない 1:検索する
				,"PRICEFLG"			: "0"												// 売変				検索フラグ 0:検索しない 1:検索する
				,"ZAIKOFLG"			: "0"												// 店在庫			検索フラグ 0:検索しない 1:検索する
				,"NYUKAFLG"			: "0"												// 入荷予定数		検索フラグ 0:検索しない 1:検索する
				,"URIFLG"			: "0"												// 売上実績数		検索フラグ 0:検索しない 1:検索する
				,"HOJUFLG"			: "0"												// 依頼集計数(補充)	検索フラグ 0:検索しない 1:検索する
				,"TANPINFLG"		: "0"												// 依頼集計数(単品)	検索フラグ 0:検索しない 1:検索する
				,"SIJIFLG"			: GetSijiFrg()										// 指示検索			検索フラグ 0:検索しない 1:出荷指示、2:返品指示
				, "SIJI_NO"			: wkSiji											// 指示NO（移動出荷マニュアル、返品マニュアル用）
				, "SYUKAKAISYA_CD"	: "0"												// 出荷会社コード（移動出荷マニュアル)
				, "NYUKAKAISYA_CD"	: "0"												// 入荷会社コード（移動出荷マニュアル)
				, "SYUKATENPO_CD"	: getAdvControlFromItemID("Head_tenpo_cd")			// 指示店舗コード（移動出荷マニュアル、返品マニュアル用）
			};
			// 戻り値指定(Key：SELECT句、Value：項目名)
			var result = {
				 "BUMON_CD": getAdvControlFromItemID("M1bumon_cd", lineNo)					// Ｍ１部門コード
				,"BUMONKANA_NM": getAdvControlFromItemID("M1bumonkana_nm", lineNo)			// Ｍ１部門カナ名
				,"HINSYU_RYAKU_NM": getAdvControlFromItemID("M1hinsyu_ryaku_nm", lineNo)	// Ｍ１品種略名称
				,"BURANDO_NMK": getAdvControlFromItemID("M1burando_nm", lineNo)			// Ｍ１ブランド名
				,"XEBIO_CD": getAdvControlFromItemID("M1jisya_hbn", lineNo)				// Ｍ１自社品番
				,"HIN_NBR": getAdvControlFromItemID("M1maker_hbn", lineNo)					// Ｍ１メーカー品番
				,"SYONMK": getAdvControlFromItemID("M1syonmk", lineNo)						// Ｍ１商品名(カナ)
				,"IRO_NM": getAdvControlFromItemID("M1iro_nm", lineNo)						// Ｍ１色
				,"SIZE_NM": getAdvControlFromItemID("M1size_nm", lineNo)					// Ｍ１サイズ
				,"GENKA": getAdvControlFromItemID("M1gen_tnk", lineNo)					// 原単価
			};

			// 名称取得部品
			V02004(condition, result, getAdvControlFromItemID("M1scan_cd", lineNo), true, lineNo);

			break;
		// -------------------
		// 数量
		// -------------------
		case "M1itemsu".toUpperCase():
			// 明細行番号を取得する
			var lineNo = getItemMNofromCtrl(eventTarget);
			// 操作ありの背景色に変更
			commitColorSet(lineNo);
			// 合計値を再計算
			calcRow(lineNo);
			if (getAdvControlFromItemID("M1itemsu", lineNo).value == "") {
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
	var eventTargetName = getAdvEventTargetName(ev);

	// 明細行番号を取得する
	var lineNo = getItemMNofromCtrl(eventTarget);

	switch (eventTargetName.toUpperCase()) {
	// ここに項目IDのcase文を追加し、固有処理を記述します。

		case "M1itemsu".toUpperCase():	// Ｍ１検数

			if (ev.key == "Enter" && !ev.shiftKey) {

			    // 店舗コードのコピー
			    if (lineNo + 1 < 50) {

					if (getAdvControlFromItemID("M1tenpo_cd", lineNo + 1).value == "") {
						getAdvControlFromItemID("M1tenpo_cd", lineNo + 1).value = getValue(getAdvControlFromItemID("M1tenpo_cd", lineNo));
						getAdvControlFromItemID("M1tenpo_nm", lineNo + 1).value = getValue(getAdvControlFromItemID("M1tenpo_nm", lineNo));
					}

					getAdvControlFromItemID("M1scan_cd", lineNo + 1).focus();
				}

				return true;
			}

			break;
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
	case "Siji_bango".toUpperCase():	// 指示番号
		//// アンフォーマットする
		//unFormatSijinoHenpin(getAdvControlFromItemID("Siji_bango"));
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
		case "Siji_bango".toUpperCase():	// 指示番号
			// フォーマット処理
			formatSijinoHenpin(getAdvControlFromItemID("Siji_bango"));
			break;
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
function onBeforeCodeSet(iDataArray, iItemId, iCodeId) {

	// ボタンID取得
	var itemnm = iItemId;
	// $区切りで名称を分割
	var item = iItemId.split("$");
	if (item.length >= 3) {
		// 明細項目の場合、行番号、項目名を取得
		rowno = ToNumber(item[1].replace("ctl", "")) - 1;
		itemnm = item[2];
	}

	switch (itemnm.toUpperCase()) {
		//  ここに項目IDのcase文を追加し、固有処理を記述します。
		case "M1btntenpocd".toUpperCase():	// 店舗コード検索

			// 操作ありの背景色に変更
			commitColorSet(rowno);
			break;
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
		// 合計値を再計算
		calcRow(lineNo);
		if (getAdvControlFromItemID("M1gen_tnk", lineNo).value == "") {
			getAdvControlFromItemID("M1genkakin", lineNo).value = '';
		}
	} else {
		clearRow(lineNo);
		// 合計値を再計算
		calcRow(lineNo);
	}
}
// 明細合計値計算関数
function calcRow(lineNo) {

	// Ｍ１数量
	var su = getAdvControlFromItemID("M1itemsu", lineNo);
	// Ｍ１数量(隠し)
	var suHid = getAdvControlFromItemID("M1itemsu_hdn", lineNo);
	// Ｍ１原単価
	var genka = getAdvControlFromItemID("M1gen_tnk", lineNo);
	getAdvControlFromItemID("M1gen_tnk", lineNo).value = formatComma(genka.value);
	// Ｍ１原価金額
	var genkaKin = getAdvControlFromItemID("M1genkakin", lineNo);
	// Ｍ１原価金額(隠し)
	var genkaKinHid = getAdvControlFromItemID("M1genka_kin_hdn", lineNo);

	// 合計数量
	var sumSu = getAdvControlFromItemID("Gokei_suryo");
	// 合計原価金額
	var sumGenkaKin = getAdvControlFromItemID("Genka_kin_gokei");
	
	// Ｍ１数量×Ｍ１原単価をＭ１原価金額に設定する。
	genkaKin.value = formatComma(ToNumber(unFormatComma(su.value)) * ToNumber(unFormatComma(genka.value)));

	// 合計数量の再計算を行う
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

// 明細項目初期化
function clearRow(lineNo) {
	// 明細項目の初期化
	getAdvControlFromItemID("M1bumon_cd", lineNo).value = '';			// Ｍ１部門コード
	getAdvControlFromItemID("M1bumonkana_nm", lineNo).value = '';		// Ｍ１部門カナ名
	getAdvControlFromItemID("M1hinsyu_ryaku_nm", lineNo).value = '';	// Ｍ１品種略名称
	getAdvControlFromItemID("M1burando_nm", lineNo).value = '';		// Ｍ１ブランド名
	getAdvControlFromItemID("M1jisya_hbn", lineNo).value = '';			// Ｍ１自社品番
	getAdvControlFromItemID("M1maker_hbn", lineNo).value = '';			// Ｍ１メーカー品番
	getAdvControlFromItemID("M1syonmk", lineNo).value = '';			// Ｍ１商品名(カナ)
	getAdvControlFromItemID("M1iro_nm", lineNo).value = '';			// Ｍ１色
	getAdvControlFromItemID("M1size_nm", lineNo).value = '';			// Ｍ１サイズ
	getAdvControlFromItemID("M1gen_tnk", lineNo).value = '';			// 原単価
	getAdvControlFromItemID("M1genkakin", lineNo).value = '';			// 原価金額

}

// 返品理由の表示制御を行う
function HenpinRiyuControl() {

	// 本部指示の場合
	if (getAdvControlFromItemID("Henpin_riyu").value == 1) {
		// 指示番号を使用可
		itemDisabled(getAdvControlFromItemID("Siji_bango"), false);
		// 仕入先コード及び仕入先名をクリア
		getAdvControlFromItemID("Siiresaki_cd").value = "";
		getAdvControlFromItemID("Siiresaki_ryaku_nm").value = "";
		// 仕入先コードを使用不可
		itemDisabled(getAdvControlFromItemID("Siiresaki_cd"), true);
	} else {
		// 指示番号をクリア
		getAdvControlFromItemID("Siji_bango").value = "";
		// 指示番号を使用不可
		itemDisabled(getAdvControlFromItemID("Siji_bango"), true);
		// 仕入先コードを使用可
		itemDisabled(getAdvControlFromItemID("Siiresaki_cd"), false);
	}
}

// 指示検索検索フラグの取得 0:検索しない 2:返品指示
function GetSijiFrg() {
	// 本部指示の場合
	if (getAdvControlFromItemID("Henpin_riyu").value == 1
	 && getAdvControlFromItemID("Siji_bango").value != "") {
		return "2";
	} else {
		return "0";
	}
}
