/*-----------------------------------------------------------------------------
	モジュール:tj190f01_event_n.js
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
	md_tj190f01_register();
	
	//共通ロード設定
	setCommonLoad();
	
	// --------------------------
	// BO初期表示共通処理
	boLoadCommon();
	// --------------------------

	// 品種コード(FROM)表示制御
	HinsyuFromControl();
	// 品種コード(TO)表示制御
	HinsyuToControl();

	// モードが「修正、照会」の場合、明細は選択不可とする。
	if (getAdvControlFromItemID(clm_StkMode).value == c_modeupd
		|| getAdvControlFromItemID(clm_StkMode).value == c_moderef) {
		selectorCheckBox = 'DISABLED';
//	} else {
//		selectorCheckBox = '';
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

			// ---------------------------
			// モードなしの表示に戻す。
			document.all.item(clm_StkMode).value = ""
			nonmodeDisp();
			// ---------------------------

			AdvGB_LastClickItemNm = null;
			return false;
		}
	}

	// ここに業務固有チェック処理を記述します。
	switch (AdvGB_LastClickItemNm.toUpperCase()) {


		// 検索ボタン
		case "Btnsearch".toUpperCase():
			// [選択モードNo]が「取消」、「ロス計算」、「ロス取消」の場合、ダイヤログ表示を行う。
			if (getAdvControlFromItemID(clm_StkMode).value == c_modedel
				|| getAdvControlFromItemID(clm_StkMode).value == c_modelosskeisan
				|| getAdvControlFromItemID(clm_StkMode).value == c_modelossdel) {

				//// 確認メッセージを表示
				var yes = function () {
					$("#Btnsearch")[0].click();
				}
				var no = function () {
				}
				var msg = getMessage("W113", "検索");
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
			return boOpenInfoDialog(msg, yes, no);
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
			return boOpenInfoDialog(msg, yes, no);
			break;

		// CSVボタン
		case "Btncsv".toUpperCase():

			// 確認メッセージを表示
			var yes = function () {
				$("#Btncsv")[0].click();
			}
			var no = function () {
			}
			var msg = getMessage("I101");
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
		// タブ処理
		case "Btnmodeupd".toUpperCase():
		case "Btnmodedel".toUpperCase():
		case "Btnmoderef".toUpperCase():
		case "Btnmodelosskeisan".toUpperCase():
		case "Btnmodelossdel".toUpperCase():
		case "Btnmodelossref".toUpperCase():

			// モードボタン共通処理
			tabClick(eventTargetName.toUpperCase());
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
	var eventTargetName=getAdvEventTargetName(ev);
	switch (eventTargetName.toUpperCase()) {
		//  ここに項目IDのcase文を追加し、固有処理を記述します。
		case "Head_tenpo_cd".toUpperCase():		// ヘッダ店舗コード
			// 名称取得部品を起動
			V02001(getAdvControlFromItemID("Head_tenpo_cd"), getAdvControlFromItemID("Head_tenpo_nm"), getAdvControlFromItemID("Head_tenpo_cd"));
			break;
		case "Nyuryokutan_cd".toUpperCase():	// 入力担当者コード
			// 名称取得部品を起動
			V02005_MAIN(getAdvControlFromItemID("Nyuryokutan_cd"), getAdvControlFromItemID("Nyuryokutan_nm"), getAdvControlFromItemID("Nyuryokutan_cd"), 0);
			break;
		case "Burando_cd".toUpperCase():		// ブランドコード
			// 名称取得部品を起動
			V02012_MAIN(getAdvControlFromItemID("Burando_cd"), getAdvControlFromItemID("Burando_nm"), getAdvControlFromItemID("Burando_cd"), 0);
			break;
		case "Old_jisya_hbn".toUpperCase():	// 旧自社品番
			// 名称取得部品を起動(存在チェック)
			RunV2003("Old_jisya_hbn");
			break;
		case "Scan_cd".toUpperCase():	// スキャンコード
			// 名称取得部品を起動(存在チェック)
			RunV2004("Scan_cd");
			break;
		case "Tenpo_cd_from".toUpperCase():	// 店舗コードFROM
			// 名称取得部品を起動(エラー判定なし)
			V02001_MAIN(getAdvControlFromItemID("Tenpo_cd_from"), getAdvControlFromItemID("Tenpo_nm_from"), null, 0);
			break;
		case "Tenpo_cd_to".toUpperCase():	// 店舗コードFROM
			// 名称取得部品を起動(エラー判定なし)
			V02001_MAIN(getAdvControlFromItemID("Tenpo_cd_to"), getAdvControlFromItemID("Tenpo_nm_to"), null, 0);
			break;
		case "Bumon_cd_from".toUpperCase():	// 部門コードFROM
			// 名称取得部品を起動(エラー判定なし)
			V02010_MAIN(getAdvControlFromItemID("Bumon_cd_from"), getAdvControlFromItemID("Bumon_nm_from"), null, 0);
			break;
		case "Bumon_cd_to".toUpperCase():	// 部門コードTO
			// 名称取得部品を起動(エラー判定なし)
			V02010_MAIN(getAdvControlFromItemID("Bumon_cd_to"), getAdvControlFromItemID("Bumon_nm_to"), null, 0);
			break;
		case "Hinsyu_cd_from".toUpperCase():// 品種コードFROM
			// 名称取得部品を起動(エラー判定なし)
			V02011_MAIN(getAdvControlFromItemID("Bumon_cd_from"), getAdvControlFromItemID("Hinsyu_cd_from"), getAdvControlFromItemID("Hinsyu_ryaku_nm_from"), null, null, 0);
			break;
		case "Hinsyu_cd_to".toUpperCase():// 品種コードTO
			// 名称取得部品を起動(エラー判定なし)
			V02011_MAIN(getAdvControlFromItemID("Bumon_cd_to"), getAdvControlFromItemID("Hinsyu_cd_to"), getAdvControlFromItemID("Hinsyu_ryaku_nm_to"), null, null, 0);
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
		case "Bumon_cd_from".toUpperCase():	// 部門コードFROM
			if (ev.key == "Enter" && !ev.shiftKey) {
				// Enterキー押下時
				// 品種コード表示制御
				HinsyuFromControl();
				if (getAdvControlFromItemID("Hinsyu_cd_from").value == "") {
					// 部門コード(FROM)が未設定の場合
					// 次の項目にフォーカス
					getAdvControlFromItemID("Bumon_cd_to").focus();
				}
			}
			break;
		case "Bumon_cd_to".toUpperCase():	// 部門コードTO
			if (ev.key == "Enter" && !ev.shiftKey) {
				// Enterキー押下時
				// 品種コード表示制御
				HinsyuToControl();
				if (getAdvControlFromItemID("Hinsyu_cd_to").value == "") {
					// 部門コード(FROM)が未設定の場合
					// 次の項目にフォーカス
					getAdvControlFromItemID("Burando_cd").focus();
				}
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
		case "Nyuryoku_ymd_from".toUpperCase():	// 入力日from
			// FROMの値をTOへコピー
			fromToCopy("Nyuryoku_ymd");
			break;
		case "Tenpo_cd_from".toUpperCase():	// 店舗コード
			// FROMの値をTOへコピー
			fromToCopy("Tenpo_cd");
			break;
		case "Bumon_cd_from".toUpperCase():	// 部門コード
			// 品種コード(FROM)表示制御
			HinsyuFromControl();
			// FROMの値をTOへコピー
			fromToCopy("Bumon_cd");
			// 品種コード(TO)表示制御
			HinsyuToControl();
			break;
		case "Hinsyu_cd_from".toUpperCase():// 品種コード
			// FROMの値をTOへコピー
			fromToCopy("Hinsyu_cd");

			// 部門TOがない場合、部門TOもコピー
			if (getAdvControlFromItemID("Bumon_cd_from").value != "" && getAdvControlFromItemID("Bumon_cd_to").value == "") {
				fromToCopy("Bumon_cd");
				// 品種コード(TO)表示制御
				HinsyuToControl();
			}

			// 品種TOの名称取得処理
			V02011(getAdvControlFromItemID("Bumon_cd_to"), getAdvControlFromItemID("Hinsyu_cd_to"), getAdvControlFromItemID("Hinsyu_ryaku_nm_to"));

			break;
		case "Old_jisya_hbn".toUpperCase():	// 旧自社品番
			// 自社品番丸め処理
			formatJisyaHbnCd(getAdvControlFromItemID("Old_jisya_hbn"));
			break;
		case "Scan_cd".toUpperCase():	// スキャンコード２
			// スキャンコード丸め処理
			formatScanCd(getAdvControlFromItemID("Scan_cd"));
			break;

		case "Bumon_cd_to".toUpperCase():	// 部門コード
			// 品種コード(TO)表示制御
			HinsyuToControl();
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
発注マスタ取得(自社品番)呼び出し
 * @param CTLname {Object} - スキャンコード
-----------------------------------------------------------------------------*/
function RunV2003(CTLname) {

	// 対象項目が空白の場合、部品を呼ばない
	if (getAdvControlFromItemID(CTLname).value == "")
	{
		return;
	}
	// 検索条件指定(Key：固定、Value：検索値)
	var condition = {
		"SCAN_CD": getAdvControlFromItemID(CTLname)
		, "TENPO_CD": getAdvControlFromItemID("Head_tenpo_cd")
		, "PLUFLG": "0"
		, "PRICEFLG": "0"
		, "ZAIKOFLG": "0"
		, "NYUKAFLG": "0"
		, "URIFLG": "0"
		, "HOJUFLG": "0"
		, "TANPINFLG": "0"
		, "SIJIFLG": "0"
		, "SIJI_NO": "0"
		, "SYUKAKAISYA_CD": "0"
		, "NYUKAKAISYA_CD": "0"
		, "SYUKATENPO_CD": "0"
	};
	// 戻り値指定(Key：SELECT句、Value：項目名)
	var result = null;	// 未指定

	// 名称取得部品
	V02003(condition, result, getAdvControlFromItemID(CTLname), false, null);
}

/*-----------------------------------------------------------------------------
発注マスタ取得(スキャンコード)呼び出し
 * @param CTLname {Object} - スキャンコード
-----------------------------------------------------------------------------*/
function RunV2004(CTLname) {
	// 対象項目が空白の場合、部品を呼ばない
	if (getAdvControlFromItemID(CTLname).value == "") {
		return;
	}
	// 検索条件指定(Key：固定、Value：検索値)
	var condition = {
		"SCAN_CD": getAdvControlFromItemID(CTLname)
		, "TENPO_CD": getAdvControlFromItemID("Head_tenpo_cd")
		, "PLUFLG": "0"
		, "PRICEFLG": "0"
		, "ZAIKOFLG": "0"
		, "NYUKAFLG": "0"
		, "URIFLG": "0"
		, "HOJUFLG": "0"
		, "TANPINFLG": "0"
		, "SIJIFLG": "0"
		, "SIJI_NO": "0"
		, "SYUKAKAISYA_CD": "0"
		, "NYUKAKAISYA_CD": "0"
		, "SYUKATENPO_CD": "0"
	};
	// 戻り値指定(Key：SELECT句、Value：項目名)
	var result = null;	// 未指定

	// 名称取得部品
	V02004(condition, result, getAdvControlFromItemID(CTLname), true, 0);
}

// 品種コード(FROM)の表示制御を行う
function HinsyuFromControl() {
	// 部門コードが未設定の場合
	if (getAdvControlFromItemID("Bumon_cd_from").value == "") {
		// 品種コードを使用不可
		getAdvControlFromItemID("Hinsyu_cd_from").value = "";
		getAdvControlFromItemID("Hinsyu_ryaku_nm_from").value = "";
		itemDisabled(getAdvControlFromItemID("Hinsyu_cd_from"), true);
	} else {
		// 品種コードを使用可
		itemDisabled(getAdvControlFromItemID("Hinsyu_cd_from"), false);
	}
}
// 品種コード(TO)の表示制御を行う
function HinsyuToControl() {
	// 部門コードが未設定の場合
	if (getAdvControlFromItemID("Bumon_cd_to").value == "") {
		// 品種コードを使用不可
		getAdvControlFromItemID("Hinsyu_cd_to").value = "";
		getAdvControlFromItemID("Hinsyu_ryaku_nm_to").value = "";
		itemDisabled(getAdvControlFromItemID("Hinsyu_cd_to"), true);
	} else {
		// 品種コードを使用可
		itemDisabled(getAdvControlFromItemID("Hinsyu_cd_to"), false);
	}
}
