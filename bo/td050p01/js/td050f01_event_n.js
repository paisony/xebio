/*-----------------------------------------------------------------------------
	モジュール:td050f01_event_n.js
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
	md_td050f01_register();
	
	//共通ロード設定
	setCommonLoad();

    // ----------------------
    // --------------------------
    // BO初期表示共通処理
	boLoadCommon();
    // --------------------------

	// 部門名From名称取得時のイベント
	$('#Bumon_nm_from').bind('mdSetAfter',function() {
		// イベント取得時の処理
		fromToCopyLbl("Bumon_cd","Bumon_nm");
	});
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
			// エラー時の画面表示対応 --------------------------------  ADD_STR
			getAdvControlFromItemID(clm_StkMode).value = "";
			nonmodeDisp();
			// エラー時の画面表示対応 --------------------------------  ADD_END
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
		// 検索ボタン
		case "Btnsearch".toUpperCase():
			// モードが「取消」の場合、メッセージを出力
			if ( getAdvControlFromItemID(clm_StkMode).value == c_modedel) {

				// 確認メッセージを表示
				var yes = function () {
					$("#Btnsearch")[0].click();
				}
				var no = function () { }
				var msg = getMessage("W113", "検索");
				return boOpenInfoDialog(msg, yes, no);
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
	    // タブ処理
	    case "Btnmodeteisei".toUpperCase():
	    case "Btnmodedel".toUpperCase():
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
	    case "Head_tenpo_cd".toUpperCase():	// ヘッダ店舗コード
	        // 名称取得部品を起動
	        V02001(getAdvControlFromItemID("Head_tenpo_cd"), getAdvControlFromItemID("Head_tenpo_nm"), getAdvControlFromItemID("Head_tenpo_cd"));
	        break;
	    case "Siiresaki_cd".toUpperCase():	// 仕入先コード
	        // 名称取得部品を起動
	        V02002_MAIN(getAdvControlFromItemID("Siiresaki_cd"), getAdvControlFromItemID("Siiresaki_ryaku_nm"), getAdvControlFromItemID("Siiresaki_cd"), 0);
	        break;
	    case "Bumon_cd_from".toUpperCase():	// 部門コードFROM
	        // 名称取得部品を起動
	        V02010_MAIN(getAdvControlFromItemID("Bumon_cd_from"), getAdvControlFromItemID("Bumon_nm_from"), null, 0);
	        break;
	    case "Bumon_cd_to".toUpperCase():	// 部門コードTO
	        // 名称取得部品を起動
	        V02010_MAIN(getAdvControlFromItemID("Bumon_cd_to"), getAdvControlFromItemID("Bumon_nm_to"), null, 0);
	        break;
	    case "Nyuryokutan_cd".toUpperCase():	// 入力担当者コード
	        // 名称取得部品を起動
	        V02005_MAIN(getAdvControlFromItemID("Nyuryokutan_cd"), getAdvControlFromItemID("Nyuryokutan_nm"), getAdvControlFromItemID("Nyuryokutan_cd"), 0);
	        break;
	    case "Kakuteitan_cd".toUpperCase():	// 確定担当者コード
	        // 名称取得部品を起動
	        V02005_MAIN(getAdvControlFromItemID("Kakuteitan_cd"), getAdvControlFromItemID("Kakuteitan_nm"), getAdvControlFromItemID("Kakuteitan_cd"), 0);
	        break;
		case "Old_jisya_hbn".toUpperCase():	// 自社品番
			// 名称表示
			// 検索条件指定(Key：固定、Value：検索値)
			var condition = {
				"SCAN_CD":getAdvControlFromItemID("Old_jisya_hbn")			// 自社品番コード
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
				"HIN_NBR": getAdvControlFromItemID("Maker_hbn")					// メーカー品番
			};

			// 名称取得部品
			V02003(condition, result, getAdvControlFromItemID("Old_jisya_hbn"), false, null);
			break;
		case "Scan_cd".toUpperCase():	// スキャンコード
			// 名称表示
			// 検索条件指定(Key：固定、Value：検索値)
			var condition = {
				"SCAN_CD": getAdvControlFromItemID("Scan_cd")				// スキャンコード
				, "TENPO_CD": getAdvControlFromItemID("Head_tenpo_cd")		// 店舗コード
				, "PLUFLG": "0"											// 店別単価マスタ	検索フラグ 0:検索しない 1:検索する
				, "PRICEFLG": "0"											// 売変				検索フラグ 0:検索しない 1:検索する
				, "ZAIKOFLG": "0"											// 店在庫			検索フラグ 0:検索しない 1:検索する
				, "NYUKAFLG": "0"											// 入荷予定数		検索フラグ 0:検索しない 1:検索する
				, "URIFLG": "0"											// 売上実績数		検索フラグ 0:検索しない 1:検索する
				, "HOJUFLG": "0"											// 依頼集計数(補充)	検索フラグ 0:検索しない 1:検索する
				, "TANPINFLG": "0"											// 依頼集計数(単品)	検索フラグ 0:検索しない 1:検索する
				, "SIJIFLG": "0"											// 指示検索			検索フラグ 0:検索しない 1:出荷指示、2:返品指示
				, "SIJI_NO": "0"											// 指示NO（移動出荷マニュアル、返品マニュアル用）
				, "SYUKAKAISYA_CD": "0"											// 出荷会社コード（移動出荷マニュアル)
				, "NYUKAKAISYA_CD": "0"											// 入荷会社コード（移動出荷マニュアル)
				, "SYUKATENPO_CD": "0"											// 指示店舗コード（移動出荷マニュアル、返品マニュアル用）
			};
			var result = null;

			// 名称取得部品
			V02004(condition, result, getAdvControlFromItemID("Scan_cd"), false, null);
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

	    case "Siji_bango_from".toUpperCase():	// 指示番号FROM
	        //// アンフォーマットする
	        //unFormatSijinoHenpin(getAdvControlFromItemID("Siji_bango_from"));
	        break;
	    case "Siji_bango_to".toUpperCase():	// 指示番号TO
	        //// アンフォーマットする
	        //unFormatSijinoHenpin(getAdvControlFromItemID("Siji_bango_to"));
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
	    case "Denpyo_bango_from".toUpperCase():	// 伝票番号FROM
	        // FROMの値をTOへコピー
	        fromToCopy("Denpyo_bango");
	        break;
	    case "Siji_bango_from".toUpperCase():	// 指示番号FROM
	        // フォーマット処理
	        formatSijinoHenpin(getAdvControlFromItemID("Siji_bango_from"));
	        // FROMの値をTOへコピー
	        fromToCopy("Siji_bango");
	        break;
	    case "Siji_bango_to".toUpperCase():	// 指示番号TO
	        // フォーマット処理
	        formatSijinoHenpin(getAdvControlFromItemID("Siji_bango_to"));
	        break;
	    case "Bumon_cd_from".toUpperCase():	// 部門コードFROM
	        // FROMの値をTOへコピー
	        fromToCopy("Bumon_cd");
	        break;
	    case "Henpin_kakutei_ymd_from".toUpperCase():	// 返品確定日FROM
	        // FROMの値をTOへコピー
	        fromToCopy("Henpin_kakutei_ymd");
	        break;
	    case "Add_ymd_from".toUpperCase():	// 登録日FROM
	        // FROMの値をTOへコピー
	        fromToCopy("Add_ymd");
	        break;
	    case "Scan_cd".toUpperCase():	// スキャンコード
	        // スキャンコード丸め処理
	        formatScanCd(getAdvControlFromItemID("Scan_cd"));
	        break;
	    case "Old_jisya_hbn".toUpperCase(): //自社品番
	        // 自社品番丸め処理
			formatJisyaHbnCd(getAdvControlFromItemID("Old_jisya_hbn"));
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

    