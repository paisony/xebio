/*-----------------------------------------------------------------------------
	モジュール:te070f01_event_n.js
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
	md_te070f01_register();
	
	//共通ロード設定
	setCommonLoad();
	
    // --------------------------
    // BO初期表示共通処理
	boLoadCommon();
    // --------------------------

    // 出荷店の表示制御
	SyukkatenControl();

	switch (getAdvControlFromItemID("Denpyo_jyotai").value) {
	    case p_idonyuka_denpyo_jotai2:

	        itemDisabled(getAdvControlFromItemID("Jyuryo_ymd_from"), true);
	        itemDisabled(getAdvControlFromItemID("Jyuryo_ymd_to"), true);
	        break;
	        //伝票状態が「未処理」以外の場合、入荷日FROM、入荷日TOにシステム日付を設定し、入力可能にする。
	    default:
	        itemDisabled(getAdvControlFromItemID("Jyuryo_ymd_from"), false);
	        itemDisabled(getAdvControlFromItemID("Jyuryo_ymd_to"), false);
	        break;

	}

	// 行選択可否制御
	if (getAdvControlFromItemID("Btnprint").disabled) {
		// 印刷ボタンが使用不可の場合
		selectorCheckBox = "DISABLED";	// 行選択不可
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
	        detailHide();
			AdvGB_LastClickItemNm = null;
			return false;
		}
	}

	// ここに業務固有チェック処理を記述します。
	switch (AdvGB_LastClickItemNm.toUpperCase()) {

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
	    case "M1syonin_flg".toUpperCase():// ｍ１承認状態

	        // 明細行番号を取得する
	        var lineNo = getItemMNofromCtrl(eventTarget);

	        // 操作ありの背景色に変更
	        commitColorSet(lineNo);

	        // [Ｍ１確定フラグ(隠し)]に"1"を設定する。
	        if (getAdvControlFromItemID("M1syonin_flg", lineNo).checked) {
	            getAdvControlFromItemID("M1entersyoriflg", lineNo).value = 1;
	        }
	        else {
	            getAdvControlFromItemID("M1entersyoriflg", lineNo).value = 0;
	        }

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
	    case "Kaisya_cd".toUpperCase():	// 会社コード
	        // 名称取得部品を起動
	        V02006_MAIN(getAdvControlFromItemID("Kaisya_cd"), getAdvControlFromItemID("Kaisya_nm"), getAdvControlFromItemID("Kaisya_cd"), 0);
	        break;
	    case "Syukkaten_cd".toUpperCase():	// 出荷店
	        // 名称取得部品を起動
	        V02026_MAIN(getAdvControlFromItemID("Kaisya_cd"), getAdvControlFromItemID("Syukkaten_cd"), getAdvControlFromItemID("Syukkaten_nm"), getAdvControlFromItemID("Syukkaten_cd"), null,  0);
	        break;
	    case "Old_jisya_hbn".toUpperCase():	// 旧自社品番
	        // 丸め処理部品を起動
	        formatJisyaHbnCd(getAdvControlFromItemID("Old_jisya_hbn"));
	        // 名称表示
	        // 検索条件指定(Key：固定、Value：検索値)
	        var condition = {
	            "SCAN_CD": getAdvControlFromItemID("Old_jisya_hbn")		// スキャンコード
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
	            "HIN_NBR": getAdvControlFromItemID("Maker_hbn")			// メーカー品番
	        };

	        // 名称取得部品を起動
	        V02003(condition, result, getAdvControlFromItemID("Old_jisya_hbn"), false, null);

	        break;
	    case "Scan_cd".toUpperCase():	// スキャンコード
	        // 丸め処理部品を起動
	        formatScanCd(getAdvControlFromItemID("Scan_cd"));
	        // 名称表示
	        // 検索条件指定(Key：固定、Value：検索値)
	        var condition = {
	            "SCAN_CD": getAdvControlFromItemID("Scan_cd")				// スキャンコード
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
	        var result = null;

	        // 名称取得部品
	        V02004(condition, result, getAdvControlFromItemID("Scan_cd"), false, null);
	        break;


	    case "Denpyo_jyotai".toUpperCase():		// 伝票状態
			// 伝票状態が「未処理」の場合、入荷日FROM、入荷日TOをクリアし入力不可にする。
	        switch (getAdvControlFromItemID("Denpyo_jyotai").value) 
	        {
	            case p_idonyuka_denpyo_jotai2:

	                getAdvControlFromItemID("Jyuryo_ymd_from").value = "";
	                getAdvControlFromItemID("Jyuryo_ymd_to").value = "";
	                itemDisabled(getAdvControlFromItemID("Jyuryo_ymd_from"), true);
	                itemDisabled(getAdvControlFromItemID("Jyuryo_ymd_to"), true);
	                break;
	            // 伝票状態が「未処理」以外の場合、入荷日FROM、入荷日TOにシステム日付を設定し、入力可能にする。
	            default:
	                var eigyo_ymd = getAdvControlFromItemID("Eigyo_ymd_hdn").value;

	                getAdvControlFromItemID("Jyuryo_ymd_from").value = eigyo_ymd;
	                getAdvControlFromItemID("Jyuryo_ymd_to").value = eigyo_ymd;
	                itemDisabled(getAdvControlFromItemID("Jyuryo_ymd_from"), false);
	                itemDisabled(getAdvControlFromItemID("Jyuryo_ymd_to"), false);
	                break;

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

		case "Kaisya_cd".toUpperCase():
			if (ev.key == "Enter" && !ev.shiftKey) {
				// Enterキー押下時
				// 出荷店コード表示制御
				SyukkatenControl();
				if (getAdvControlFromItemID("Kaisya_cd").value == "") {
					// 会社コードが未設定の場合
					// 次の項目にフォーカス
					getAdvControlFromItemID("Denpyo_bango_from").focus();
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

	    case "Syukka_ymd_from".toUpperCase():	//出荷日FROM
	        // FROMの値をTOへコピー
	        fromToCopy("Syukka_ymd");
	        break;
	    case "Jyuryo_ymd_from".toUpperCase():	//入荷日FROM
	        // FROMの値をTOへコピー
	        fromToCopy("Jyuryo_ymd");
	        break;
	    case "Denpyo_bango_from".toUpperCase():	//伝票番号FROM
	        // FROMの値をTOへコピー
	        fromToCopy("Denpyo_bango");
	        break;
		case "Scm_cd".toUpperCase():			// SCMコード
			// SCMコード丸め処理
			formatScmCd(getAdvControlFromItemID("Scm_cd"));
			break;
		case "Old_jisya_hbn".toUpperCase():	// 旧自社品番
			// 旧自社品番丸め処理
			formatJisyaHbnCd(getAdvControlFromItemID("Old_jisya_hbn"));
			break;
		case "Scan_cd".toUpperCase():	// スキャンコード
			// スキャンコード丸め処理
			formatScanCd(getAdvControlFromItemID("Scan_cd"));
			break;	
	case "Kaisya_cd".toUpperCase():	// 会社コード
			// 出荷店コード表示制御
			SyukkatenControl();
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
// 出荷店の表示制御を行う
function SyukkatenControl() {
    // 会社コードが未設定の場合
    if (getAdvControlFromItemID("Kaisya_cd").value == "") {
    	// 出荷店コードを使用不可
    	getAdvControlFromItemID("Syukkaten_cd").value = "";
    	getAdvControlFromItemID("Syukkaten_nm").value = "";
    	itemDisabled(getAdvControlFromItemID("Syukkaten_cd"), true);

    } else {
    	// 出荷店コードを使用可
        itemDisabled(getAdvControlFromItemID("Syukkaten_cd"), false);
    }
}