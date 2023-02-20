/*-----------------------------------------------------------------------------
	モジュール:tj040f01_event_n.js
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
	md_tj040f01_register();
	
	//共通ロード設定
	setCommonLoad();

	// --------------------------
	// BO初期表示共通処理
	boLoadCommon();
	// --------------------------

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
		    // -----------------------
		    // モードなしの表示に戻す
		    document.all.item(clm_StkMode).value = "";
		    nonmodeDisp();
		    AdvGB_LastClickItemNm = null;
			return false;
		}
	}

	// ここに業務固有チェック処理を記述します。
	switch (AdvGB_LastClickItemNm.toUpperCase()) {

		//// 検索ボタン
		//case "Btnsearch".toUpperCase():
		//	var maxrow = getAdvMaxMRow(1);
		//	if (maxrow > 0) {
		//		// ワーニングメッセージを表示
		//		var yes = function () {
		//			$("#Btnsearch")[0].click();
		//		}
		//		var no = function () {
		//		}
		//		var msg = getMessage("W113", "検索");

		//		return boOpenInfoDialog(msg, yes, no);
		//	}
		//	break;

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

	    // CSV出力ボタン
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
		case "Btnmoderef".toUpperCase():
		case "Btnmodeupd".toUpperCase():
		case "Btnmodedel".toUpperCase():
			// モードボタン共通処理
			tabClick(eventTargetName.toUpperCase());
			// 項目制御
			itemControl_mode(getModeNo(eventTargetName));
			return false;
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

	    case "Head_tenpo_cd".toUpperCase():	// ヘッダ店舗コード
	        // 名称取得部品を起動
	        V02001(getAdvControlFromItemID("Head_tenpo_cd"), getAdvControlFromItemID("Head_tenpo_nm"), getAdvControlFromItemID("Head_tenpo_cd"));
	        break;
	    case "Nyuryokutan_cd".toUpperCase():	// 入力担当者コード
	        // 名称取得部品を起動
	        V02005_MAIN(getAdvControlFromItemID("Nyuryokutan_cd"), getAdvControlFromItemID("Nyuryokutan_nm"), getAdvControlFromItemID("Nyuryokutan_cd"), 0);
	        break;
	    case "Old_jisya_hbn".toUpperCase():	// 旧自社品番
	        // 名称取得部品を起動(存在チェック)
	    	RunV2003("Old_jisya_hbn");
	        break;
	    case "Old_jisya_hbn2".toUpperCase():	// 旧自社品番２
	        // 名称取得部品を起動(存在チェック)
	    	RunV2003("Old_jisya_hbn2");
	        break;
	    case "Old_jisya_hbn3".toUpperCase():	// 旧自社品番３
	        // 名称取得部品を起動(存在チェック)
	    	RunV2003("Old_jisya_hbn3");
	        break;
	    case "Old_jisya_hbn4".toUpperCase():	// 旧自社品番４
	        // 名称取得部品を起動(存在チェック)
	    	RunV2003("Old_jisya_hbn4");
	        break;
	    case "Old_jisya_hbn5".toUpperCase():	// 旧自社品番５
	        // 名称取得部品を起動(存在チェック)
	    	RunV2003("Old_jisya_hbn5");
	        break;
	    case "Scan_cd".toUpperCase():	// スキャンコード
	        // 名称取得部品を起動(存在チェック)
	        RunV2004("Scan_cd");
	        break;
	    case "Scan_cd2".toUpperCase():	// スキャンコード２
	        // 名称取得部品を起動(存在チェック)
	        RunV2004("Scan_cd2");
	        break;
	    case "Scan_cd3".toUpperCase():	// スキャンコード３
	        // 名称取得部品を起動(存在チェック)
	        RunV2004("Scan_cd3");
	        break;
	    case "Scan_cd4".toUpperCase():	// スキャンコード４
	        // 名称取得部品を起動(存在チェック)
	        RunV2004("Scan_cd4");
	        break;
	    case "Scan_cd5".toUpperCase():	// スキャンコード５
	        // 名称取得部品を起動(存在チェック)
	        RunV2004("Scan_cd5");
	        break;

		case "Sosin_jyotai".toUpperCase():	// 送信状態
			// 「未送信」が選ばれた場合、[送信日FROM]、[送信日TO]に空白を設定しDisabledとする。
			var ctl_Sosin_ymd_from = getAdvControlFromItemID("Sosin_ymd_from");
			var ctl_Sosin_ymd_to   = getAdvControlFromItemID("Sosin_ymd_to");

			if (getAdvControlFromItemID("Sosin_jyotai").value == "1") {
				ctl_Sosin_ymd_from.value = "";
				ctl_Sosin_ymd_to.value   = "";
				itemDisabled(ctl_Sosin_ymd_from, true);
				itemDisabled(ctl_Sosin_ymd_to, true);

			} else {
				itemDisabled(ctl_Sosin_ymd_from, false);
				itemDisabled(ctl_Sosin_ymd_to, false);
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

	    case "Face_no_from".toUpperCase():	// フェイスNoFROM
	        // FROMの値をTOへコピー
	        fromToCopy("Face_no");
	        break;
	    case "Tana_dan_from".toUpperCase():	// 棚段FROM
	        // FROMの値をTOへコピー
	        fromToCopy("Tana_dan");
	        break;
	    case "Nyuryoku_ymd_from".toUpperCase():	// 入力日FROM
	        // FROMの値をTOへコピー
	        fromToCopy("Nyuryoku_ymd");
	        break;
	    case "Sosin_ymd_from".toUpperCase():	// 送信日FROM
	        // FROMの値をTOへコピー
	        fromToCopy("Sosin_ymd");
	        break;

	    case "Old_jisya_hbn".toUpperCase():	// 旧自社品番
	        // 自社品番丸め処理
	        formatJisyaHbnCd(getAdvControlFromItemID("Old_jisya_hbn"));
	        break;
	    case "Old_jisya_hbn2".toUpperCase():	// 旧自社品番２
	        // 自社品番丸め処理
	        formatJisyaHbnCd(getAdvControlFromItemID("Old_jisya_hbn2"));
	        break;
	    case "Old_jisya_hbn3".toUpperCase():	// 旧自社品番３
	        // 自社品番丸め処理
	        formatJisyaHbnCd(getAdvControlFromItemID("Old_jisya_hbn3"));
	        break;
	    case "Old_jisya_hbn4".toUpperCase():	// 旧自社品番４
	        // 自社品番丸め処理
	        formatJisyaHbnCd(getAdvControlFromItemID("Old_jisya_hbn4"));
	        break;
	    case "Old_jisya_hbn5".toUpperCase():	// 旧自社品番５
	        // 自社品番丸め処理
	        formatJisyaHbnCd(getAdvControlFromItemID("Old_jisya_hbn5"));
	        break;
	    case "Scan_cd".toUpperCase():	// スキャンコード
	        // スキャンコード丸め処理
	        formatScanCd(getAdvControlFromItemID("Scan_cd"));
	        break;
	    case "Scan_cd2".toUpperCase():	// スキャンコード２
	        // スキャンコード丸め処理
	        formatScanCd(getAdvControlFromItemID("Scan_cd2"));
	        break;
	    case "Scan_cd3".toUpperCase():	// スキャンコード３
	        // スキャンコード丸め処理
	        formatScanCd(getAdvControlFromItemID("Scan_cd3"));
	        break;
	    case "Scan_cd4".toUpperCase():	// スキャンコード４
	        // スキャンコード丸め処理
	        formatScanCd(getAdvControlFromItemID("Scan_cd4"));
	        break;
	    case "Scan_cd5".toUpperCase():	// スキャンコード５
	        // スキャンコード丸め処理
	        formatScanCd(getAdvControlFromItemID("Scan_cd5"));
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
	    case "Btntanto_cd":
	        onBlur_adv(getAdvControlFromItemID("Nyuryokutan_cd"));
	        break;
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
    V02003(condition, result, getAdvControlFromItemID(CTLname), true, 0);
}

/*-----------------------------------------------------------------------------
発注マスタ取得(スキャンコード)呼び出し
 * @param CTLname {Object} - スキャンコード
-----------------------------------------------------------------------------*/
function RunV2004(CTLname) {

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

// モード変更確認メッセージ表示時のNOアクション
function tabClick_NoAction(tabnm) {
	// 項目制御
	itemControl_mode();
}
// モード別のコントロール制御
function itemControl_mode(pModeno) {

	if (getAdvControlFromItemID("Sosin_jyotai").value == "1") {
		getAdvControlFromItemID("Sosin_ymd_from").value = "";
		getAdvControlFromItemID("Sosin_ymd_to").value = "";
		itemDisabled(getAdvControlFromItemID("Sosin_ymd_from"), true);
		itemDisabled(getAdvControlFromItemID("Sosin_ymd_to"), true);

	} else {
		itemDisabled(getAdvControlFromItemID("Sosin_ymd_from"), false);
		itemDisabled(getAdvControlFromItemID("Sosin_ymd_to"), false);
	}

	var modeno = pModeno;
	if (modeno == null || modeno == "") {
		modeno = getAdvControlFromItemID(clm_Mode).value;
	}
	switch (String(modeno)) {
		case c_modedel:		// 取消の場合
		case c_modeupd:		// 修正の場合
			// 店舗／業者 使用不可
			itemDisabled(getAdvControlFromItemID("Tenpo_gyosya_kb"), true);
			// 送信日From 使用不可
			itemDisabled(getAdvControlFromItemID("Sosin_ymd_from"), true);
			// 送信日To 使用不可
			itemDisabled(getAdvControlFromItemID("Sosin_ymd_to"), true);
			// 送信状態 使用不可
			itemDisabled(getAdvControlFromItemID("Sosin_jyotai"), true);
			break;
		case c_moderef:		// 照会の場合
			// 店舗／業者 使用可
			itemDisabled(getAdvControlFromItemID("Tenpo_gyosya_kb"), false);
			//// 送信日From 使用可
			//itemDisabled(getAdvControlFromItemID("Sosin_ymd_from"), false);
			//// 送信日To 使用可
			//itemDisabled(getAdvControlFromItemID("Sosin_ymd_to"), false);
			// 送信状態 使用可
			itemDisabled(getAdvControlFromItemID("Sosin_jyotai"), false);
			break;

	}
}
