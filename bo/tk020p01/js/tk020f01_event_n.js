/*-----------------------------------------------------------------------------
	モジュール:tk020f01_event_n.js
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
	md_tk020f01_register();
	
	//共通ロード設定
	setCommonLoad();

	// --------------------------
	// BO初期表示共通処理
	boLoadCommon();
	// --------------------------

	// Ｍ１評価損理由区分
	for (i = 0; ; i++)
	{
		// 項目がない場合、for文を抜ける
		if (typeof getAdvControlFromItemID("M1rowno", i) === "undefined")
		{ break; }

		// 「販売不可」の場合、Ｍ１評価損理由区分を入力可能にし、「経年商品」以外の表示を行う。
		if (getAdvControlFromItemID("M1hyokasonsyubetsu_kb", i).value != p_hyokasonsyubetsu_kb2)
		{
			// 非表示：「経年商品」
			dlVisible("M1hyokasonsyubetsu_kb".toUpperCase(), i, false);

			// 行追加の場合
			if (getAdvControlFromItemID("M1haibun_kin", i).value == "") {
				// 空白を設定
				getAdvControlFromItemID("M1hyokasonsyubetsu_kb", i).value = -1;		// Ｍ１評価損理由区分

				// Ｍ１評価損理由
				itemDisabled(getAdvControlFromItemID("M1hyokasonriyu_kb", i), true);	// 非活性
				getAdvControlFromItemID("M1hyokasonriyu_kb", i).value = -1;			// 空白設定
			}
		} else {
			itemDisabled(getAdvControlFromItemID("M1hyokasonriyu_kb", i), true);	// Ｍ１評価損理由区分を入力不可
			dlVisible("M1hyokasonsyubetsu_kb".toUpperCase(), i, true);				//「経年商品」を表示
			getAdvControlFromItemID("M1hyokasonriyu_kb", i).value = 24;			//「経年商品」を選択
		}
	}

	// [選択モードNo]が「照会」「決裁状況」の場合
	if (getAdvControlFromItemID("Modeno").value == c_moderef
	 || getAdvControlFromItemID("Modeno").value == c_modekessaijyokyo) {
		selectorCheckBox = 'Disabled';
	} else {
		selectorCheckBox = 'M1selectorcheckbox';
	}

	// 項目制御
	itemControl_mode();
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

		// 検索ボタン
		case "Btnsearch".toUpperCase():

			// [選択モードNo]が「申請」「修正」「再申請」の場合、ダイヤログ表示を行う。
			if (   getAdvControlFromItemID("Stkmodeno").value == 6
				|| getAdvControlFromItemID("Stkmodeno").value == 8
				|| getAdvControlFromItemID("Stkmodeno").value == 7 )
			{
					// 確認メッセージを表示
				var yes = function () {
					$("#Btnsearch")[0].click();
				}
				var no = function () {
				}

				var msg = getMessage("W113", "検索");
				if (boOpenInfoDialog(msg, yes, no) == false) {
					return false;
				}
			}

			break;


		// 印刷ボタン
		case "Btnprint".toUpperCase():

			// 確認メッセージを表示
			var yes = function () {
				$("#Btnprint")[0].click();
			}
			var no = function () {
			}

			var msg = getMessage("I100");
			if (boOpenInfoDialog(msg, yes, no) == false) {
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

		// Ｆ２　削除
		//case "BTNSKJ":
		//	// ＵＩＢＬＯＣＫにてメッセージＩ４０３：削除しますが、よろしいですか？
		//	return confirmPanel(event , "cmDelConfirm", getMessage("I403"));
		// Ｆ４　更新
		//case "BTNKSN":
		//	// ＵＩＢＬＯＣＫにてメッセージＩ４０２：更新しますが、よろしいですか？
		//	//	return confirmPanel(event , "cmInsConfirm", getMessage("I402"));

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

		// タブ処理
		case "Btnmodeapply".toUpperCase():
		case "Btnmodereapply".toUpperCase():
		case "Btnmodeupd".toUpperCase():
		case "Btnmodekessaijyokyo".toUpperCase():
		case "Btnmoderef".toUpperCase():

			// モードボタン共通処理
			tabClick(eventTargetName.toUpperCase());
			// 項目制御
			itemControl_mode(getModeNo(eventTargetName));
			return false;

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

			// ツールチップ初期化
			getAdvControlFromItemID("M1bumon_cd", lineNo).title = "";	// 部門コード tooltip設定
			getAdvControlFromItemID("M1hinsyu_cd", lineNo).title = "";	// 品種コード tooltip設定

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
				"BUMON_CD": getAdvControlFromItemID("M1bumon_cd", lineNo)										// 部門コード
				, "BUMONKANA_NM": getAdvControlFromItemID("M1bumon_nm_hdn", lineNo)							// 部門名カナ　ツールチップ用
				, "HINSYU_CD": getAdvControlFromItemID("M1hinsyu_cd", lineNo)									// 品種コード
				, "HINSYU_RYAKU_NM": getAdvControlFromItemID("M1hinsyu_ryaku_nm_hdn", lineNo)					// 品種名カナ 　ツールチップ用
				, "BURANDO_NMK": getAdvControlFromItemID("M1burando_nm", lineNo)								// ブランド名
				, "XEBIO_CD": formatComma(getAdvControlFromItemID("M1jisya_hbn", lineNo))						// 自社品番
				, "HANBAIKANRYO_YMD": formatComma(getAdvControlFromItemID("M1hanbaikanryo_ymd", lineNo))		// 販売完了日
				, "HIN_NBR": formatComma(getAdvControlFromItemID("M1maker_hbn", lineNo))						// メーカー品番
				, "SYONMK": formatComma(getAdvControlFromItemID("M1syonmk", lineNo))							// 商品略式名称カナ
				, "IRO_NM": formatComma(getAdvControlFromItemID("M1iro_nm", lineNo))							// 色名
				, "SIZE_NM": formatComma(getAdvControlFromItemID("M1size_nm", lineNo))							// サイズコード
				, "SLPR": formatComma(getAdvControlFromItemID("M1genbaika_tnk", lineNo))						// 上代１(現売価)
				, "GENKA": formatComma(getAdvControlFromItemID("M1gen_tnk", lineNo))							// 原価
				, "TYOTATSUKB_NM": getAdvControlFromItemID("M1tyotatsu_nm", lineNo)							// 調達区分
			};
			
			// 名称取得部品
			V02004(condition, result, getAdvControlFromItemID("M1scan_cd", lineNo), true, lineNo);

			// 操作ありの背景色に変更
			commitColorSet(lineNo);

			// 選択フラグをセット
			rowEditSelect(lineNo);

			break;

		case "M1hyokason_su".toUpperCase():	// 数量
			// 合計値再計算
			calcRow(lineNo);
			// 操作ありの背景色に変更
			commitColorSet(lineNo);

			// 選択フラグをセット
			rowEditSelect(lineNo);

			break;

		case "Head_tenpo_cd".toUpperCase():	// ヘッダ店舗コード
			// 名称取得部品を起動
			V02001(getAdvControlFromItemID("Head_tenpo_cd"), getAdvControlFromItemID("Head_tenpo_nm"), getAdvControlFromItemID("Head_tenpo_cd"));
			break;

		case "M1hyokasonsyubetsu_kb".toUpperCase():	// Ｍ１評価損種別区分
			// 「経年品」の場合、Ｍ１評価損理由区分を入力不可にし、「経年商品」固定とする。
			if (getAdvControlFromItemID("M1hyokasonsyubetsu_kb", lineNo).value == p_hyokasonsyubetsu_kb2) {
				// Ｍ１評価損理由区分を入力不可
				itemDisabled(getAdvControlFromItemID("M1hyokasonriyu_kb", lineNo), true);	
				dlVisible("M1hyokasonsyubetsu_kb".toUpperCase(), lineNo, true);				//「経年商品」を表示
				getAdvControlFromItemID("M1hyokasonriyu_kb", lineNo).value = 24;			//「経年商品」を選択

			} else if (getAdvControlFromItemID("M1hyokasonsyubetsu_kb", lineNo).value == p_hyokasonsyubetsu_kb1) {
				// 「販売不可」の場合、Ｍ１評価損理由区分を入力可能にし、「経年商品」以外の表示を行う。
				itemDisabled(getAdvControlFromItemID("M1hyokasonriyu_kb", lineNo), false);	// 活性化
				dlVisible("M1hyokasonsyubetsu_kb".toUpperCase(), lineNo, false);			// 経年商品を非表示

				// 値設定
				for (iRow = 0; ; iRow++) {
					// 選択値が存在しない場合(コメントアウトしている)
					if (getAdvControlFromItemID("M1hyokasonriyu_kb", lineNo).length == iRow) {
						break;
					}

					// 選択値に設定
					if (getAdvControlFromItemID("M1hyokasonriyu_kb", lineNo)[iRow].outerHTML.indexOf('selected') != -1) {
						getAdvControlFromItemID("M1hyokasonriyu_kb", lineNo).value
							= getAdvControlFromItemID("M1hyokasonriyu_kb", lineNo)[iRow].value;
						break;
					}
				}

			} else {	// 空白時
				// Ｍ１評価損理由
				itemDisabled(getAdvControlFromItemID("M1hyokasonriyu_kb", lineNo), true);	// 非活性
				getAdvControlFromItemID("M1hyokasonriyu_kb", lineNo).value = -1;			// 空白設定
			}

			// 操作ありの背景色に変更
			commitColorSet(lineNo);

			// 選択フラグをセット
			rowEditSelect(lineNo);

			break;

		case "M1hyokasonriyu_kb".toUpperCase():		// 評価損理由区分
		case "M1hyokasonriyu".toUpperCase():		// 評価損理由
			// 操作ありの背景色に変更
			commitColorSet(lineNo);

			// 選択フラグをセット
			rowEditSelect(lineNo);

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

	// 部門コード
	var bumon_cd = getAdvControlFromItemID("M1bumon_cd", lineNo);
	bumon_cd.value = getAdvFormatStr("M1bumon_cd", bumon_cd.value);

	// 品種コード
	var hinsyu_cd = getAdvControlFromItemID("M1hinsyu_cd", lineNo);
	hinsyu_cd.value = getAdvFormatStr("M1hinsyu_cd", hinsyu_cd.value);

	// 販売完了日
	var hanbaikanryo_ymd = getAdvControlFromItemID("M1hanbaikanryo_ymd", lineNo);
	hanbaikanryo_ymd.value = getAdvFormatStr("M1hanbaikanryo_ymd", hanbaikanryo_ymd.value);

	// 上代１(現売価)
	var genbaika_tnk = getAdvControlFromItemID("M1genbaika_tnk", lineNo);
	genbaika_tnk.value = getAdvFormatStr("M1genbaika_tnk", genbaika_tnk.value);

	// 原価
	var gen_tnk = getAdvControlFromItemID("M1gen_tnk", lineNo);
	gen_tnk.value = getAdvFormatStr("M1gen_tnk", gen_tnk.value);

	// 部門コード tooltip設定
	getAdvControlFromItemID("M1bumon_cd", lineNo).title = getAdvControlFromItemID("M1bumon_nm_hdn", lineNo).value;

	// 品種コード tooltip設定
	getAdvControlFromItemID("M1hinsyu_cd", lineNo).title = getAdvControlFromItemID("M1hinsyu_ryaku_nm_hdn", lineNo).value;

	// 合計値再計算
	calcRow(lineNo);

}

// 明細合計値計算関数
function calcRow(plineNo) {

	// 明細行番号を取得する
	var lineNo = plineNo;

	// 項目値取得
	var m1GenTnk = getAdvControlFromItemID("M1gen_tnk", lineNo);			// 原価金額

	var m1Su = getAdvControlFromItemID("M1hyokason_su", lineNo);			// 数量
	var m1Su_hdn = getAdvControlFromItemID("M1hyokason_su_hdn", lineNo);	// 数量(隠し)

	var m1GenKin = getAdvControlFromItemID("M1haibun_kin", lineNo);			// 原価金額
	var m1GenKin_hdn = getAdvControlFromItemID("M1haibun_kin_hdn", lineNo);	// 原価金額(隠し)

	var sumSu = getAdvControlFromItemID("Gokei_suryo");		// 合計数量
	var sumKin = getAdvControlFromItemID("Haibun_kin_gokei");	// 合計原価金額


	// M1原価金額に設定
	// M1数量×M1原単価をM1原価金額に設定する。
	m1GenKin.value = formatComma(ToNumber(unFormatComma(m1Su.value)) * ToNumber(unFormatComma(m1GenTnk.value)));


	// 合計数量の再計算
	// Ｍ１数量とＭ１数量(隠し)の差分を取得し、合計数量に加算(減算)する。
	sumSu.value = formatComma(ToNumber(unFormatComma(sumSu.value)) + ToNumber(unFormatComma(m1Su.value)) - ToNumber(unFormatComma(m1Su_hdn.value)));

	// Ｍ１数量(隠し)にＭ１数量を設定する。
	m1Su_hdn.value = formatComma(m1Su.value);

	// 合計原価金額の再計算
	// M1原価金額とM1原価金額(隠し)の差分を取得し、合計原価金額に加算(減算)する。
	sumKin.value = formatComma(ToNumber(unFormatComma(sumKin.value)) + ToNumber(unFormatComma(m1GenKin.value)) - ToNumber(unFormatComma(m1GenKin_hdn.value)));

	// M1原価金額(隠し)にM1原価金額を設定する。
	m1GenKin_hdn.value = formatComma(m1GenKin.value);

}

// ドロップダウン項目非表示
function dlVisible(iItemId, i, ON) {

	// 固定値設定(マスタ変更時、修正)
	var itemNm = '経年商品';
	var itemVa = '24';

	// HTML文取得
	var HTMLwk;
	var Indexwk;

	for (iRow = 0; ; iRow++)
	{
		// 経年品が存在しない場合(コメントアウトしている)
		if (getAdvControlFromItemID("M1hyokasonriyu_kb", i).length == iRow) {
			break;
		}

		// 経年品のドロップダウンHTML文取得
		if (getAdvControlFromItemID("M1hyokasonriyu_kb", i)[iRow].outerHTML.indexOf(itemNm) != -1)
		{
			HTMLwk = getAdvControlFromItemID("M1hyokasonriyu_kb", i)[iRow].outerHTML;
			Indexwk = iRow;
			break;
		}
	}

	if (ON)
	{// 表示
		if (getAdvControlFromItemID("M1hyokasonriyu_kb", i).innerHTML.indexOf('<!--') != -1)
		{
			// 経年商品をコメントアウト解除
			getAdvControlFromItemID("M1hyokasonriyu_kb", i).innerHTML
				= getAdvControlFromItemID("M1hyokasonriyu_kb", i).innerHTML.replace('<!--<option', '<option');
			getAdvControlFromItemID("M1hyokasonriyu_kb", i).innerHTML
				= getAdvControlFromItemID("M1hyokasonriyu_kb", i).innerHTML.replace('--&gt;', '');
		}
	}
	else
	{// 非表示
		if (typeof HTMLwk !== "undefined")
		{
			// 経年商品をコメントアウト
			getAdvControlFromItemID("M1hyokasonriyu_kb", i)[Indexwk].outerHTML
				= HTMLwk.replace('<option', '<!--<option');
		}
	}
}

// モード変更確認メッセージ表示時のNOアクション
function tabClick_NoAction(tabnm) {
	// 項目制御
	itemControl_mode();
}
// モード別のコントロール制御
function itemControl_mode(pModeno) {

	var modeno = pModeno;
	if (modeno == null || modeno == "") {
		modeno = getAdvControlFromItemID(clm_Mode).value;
	}
	switch (String(modeno)) {
		case c_modeapply:	// 申請の場合
		case c_modereapply:	// 再申請の場合
		case c_modeupd:		// 修正の場合
			// 却下データのみ 使用不可
			itemDisabled(getAdvControlFromItemID("Kyakka_flg"), true);
			break;
		case c_modekessaijyokyo:	// 決済状況の場合
			// 却下データのみ 使用可
			itemDisabled(getAdvControlFromItemID("Kyakka_flg"), false);
			break;
	}

}
