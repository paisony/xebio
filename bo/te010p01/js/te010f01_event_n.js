/*-----------------------------------------------------------------------------
	モジュール:te010f01_event_n.js
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
	md_te010f01_register();
	
	//共通ロード設定
	setCommonLoad();
	
	// --------------------------
	// BO初期表示共通処理
	boLoadCommon();
	// --------------------------
	
	// 部門名From名称取得時のイベント
	$('#Bumon_nm_from').bind('mdSetAfter', function () {
		// イベント取得時の処理
		fromToCopyLbl("Bumon_cd", "Bumon_nm");
	});

	// [選択モードNo]が「取消」の場合
	if (getAdvControlFromItemID("Modeno").value == c_modedel
	 && getAdvControlFromItemID("Modeno").value != "") {
		itemDisabled(getAdvControlFromItemID("Denpyo_jyotai"), true);
	} else {
		itemDisabled(getAdvControlFromItemID("Denpyo_jyotai"), false);
	}

	// 入荷店の表示制御
	JyuryotenControl();

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
			// [選択モードNo]が「取消」の場合、メッセージを出力
			if (getAdvControlFromItemID(clm_StkMode).value == c_modedel) {

				// 確認メッセージを表示
				var yes = function () {
					$("#Btnsearch")[0].click();
				}
				var no = function () { }
				var msg = getMessage("W113", "検索");
				return boOpenInfoDialog(msg, yes, no);
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
	case "BTNMODEREF":
	case "BTNMODEDEL":
		// モードボタン共通処理
		vRet = tabClick(eventTargetName.toUpperCase());
		// 項目制御
		itemControl_mode(getModeNo(eventTargetName));
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
		case "Jyuryoten_cd".toUpperCase():	// 入荷店コード
			// 名称取得部品を起動
			V02026_MAIN(getAdvControlFromItemID("Kaisya_cd"), getAdvControlFromItemID("Jyuryoten_cd"), getAdvControlFromItemID("Juryoten_nm"), getAdvControlFromItemID("Jyuryoten_cd"), null, 0);
			break;
		case "Nyuryokutan_cd".toUpperCase():	// 入力担当者コード
			// 名称取得部品を起動
			V02005_MAIN(getAdvControlFromItemID("Nyuryokutan_cd"), getAdvControlFromItemID("Nyuryokutan_nm"), getAdvControlFromItemID("Nyuryokutan_cd"), 0);
			break;
		case "Bumon_cd_from".toUpperCase():	// 部門コードFROM
			// 名称取得部品を起動
			V02010_MAIN(getAdvControlFromItemID("Bumon_cd_from"), getAdvControlFromItemID("Bumon_nm_from"), null, 0);
			break;
		case "Bumon_cd_to".toUpperCase():	// 部門コードTO
			// 名称取得部品を起動
			V02010_MAIN(getAdvControlFromItemID("Bumon_cd_to"), getAdvControlFromItemID("Bumon_nm_to"), null, 0);
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
		// --------------------------------------------
		// スキャンコード
		// --------------------------------------------
		case "Scan_cd".toUpperCase():
			// 名称表示
			// 検索条件指定(Key：固定、Value：検索値)
			var condition = {
				"SCAN_CD": getAdvControlFromItemID("Scan_cd")			// スキャンコード
				, "TENPO_CD": getAdvControlFromItemID("Head_tenpo_cd")	// 店舗コード
				, "PLUFLG": "0"											// 店別単価マスタ	検索フラグ 0:検索しない 1:検索する
				, "PRICEFLG": "0"										// 売変				検索フラグ 0:検索しない 1:検索する
				, "ZAIKOFLG": "0"										// 店在庫			検索フラグ 0:検索しない 1:検索する
				, "NYUKAFLG": "0"										// 入荷予定数		検索フラグ 0:検索しない 1:検索する
				, "URIFLG": "0"											// 売上実績数		検索フラグ 0:検索しない 1:検索する
				, "HOJUFLG": "0"										// 依頼集計数(補充)	検索フラグ 0:検索しない 1:検索する
				, "TANPINFLG": "0"										// 依頼集計数(単品)	検索フラグ 0:検索しない 1:検索する
				, "SIJIFLG": "0"										// 指示検索			検索フラグ 0:検索しない 1:出荷指示、2:返品指示
				, "SIJI_NO": "0"										// 指示NO（移動出荷マニュアル、返品マニュアル用）
				, "SYUKAKAISYA_CD": "0"									// 出荷会社コード（移動出荷マニュアル)
				, "NYUKAKAISYA_CD": "0"									// 入荷会社コード（移動出荷マニュアル)
				, "SYUKATENPO_CD": "0"									// 指示店舗コード（移動出荷マニュアル、返品マニュアル用）
			};
			// 戻り値指定(Key：SELECT句、Value：項目名)
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

		case "Kaisya_cd".toUpperCase():	// 入荷会社コード
			if (ev.key == "Enter" && !ev.shiftKey) {
				// Enterキー押下時
				// 入荷店コード表示制御
				JyuryotenControl();
				if (getAdvControlFromItemID("Jyuryoten_cd").value == "") {
					// 会社コードが未設定の場合
					// 次の項目にフォーカス
					getAdvControlFromItemID("Nyuryokutan_cd").focus();
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
	case "Siji_bango_from".toUpperCase():	// 指示番号FROM
		//// アンフォーマットする
		//unFormatSijinoIdou(getAdvControlFromItemID("Siji_bango_from"));
		break;
	case "Siji_bango_to".toUpperCase():	// 指示番号TO
		//// アンフォーマットする
		//unFormatSijinoIdou(getAdvControlFromItemID("Siji_bango_to"));
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
		formatSijinoIdou(getAdvControlFromItemID("Siji_bango_from"));
		// FROMの値をTOへコピー
		fromToCopy("Siji_bango");
		break;
	case "Siji_bango_to".toUpperCase():	// 指示番号TO
		// フォーマット処理
		formatSijinoIdou(getAdvControlFromItemID("Siji_bango_to"));
		break;
	case "Syukka_ymd_from".toUpperCase():	// 出荷日
		// FROMの値をTOへコピー
		fromToCopy("Syukka_ymd");
		break;
	case "Bumon_cd_from".toUpperCase():	// 部門コードFROM
		// FROMの値をTOへコピー
		fromToCopy("Bumon_cd");
		break;
	case "Scan_cd".toUpperCase():	// スキャンコード
		// スキャンコード丸め処理
		formatScanCd(getAdvControlFromItemID("Scan_cd"));
		break;
	case "Old_jisya_hbn".toUpperCase(): //自社品番
		// 自社品番丸め処理
		formatJisyaHbnCd(getAdvControlFromItemID("Old_jisya_hbn"));
		break;
	case "Kaisya_cd".toUpperCase():	// 会社コード
		// 入荷店コード表示制御
//		getAdvControlFromItemID("Jyuryoten_cd").value = "";
//		getAdvControlFromItemID("Juryoten_nm").value = "";
		JyuryotenControl();
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
// 入荷店の表示制御を行う
function JyuryotenControl() {
	// 会社コードが未設定の場合
	if (getAdvControlFromItemID("Kaisya_cd").value == "") {
		// 入荷店コードを使用不可
		getAdvControlFromItemID("Jyuryoten_cd").value = "";
		getAdvControlFromItemID("Juryoten_nm").value = "";
		itemDisabled(getAdvControlFromItemID("Jyuryoten_cd"), true);
	} else {
		// 入荷店コードを使用可
		itemDisabled(getAdvControlFromItemID("Jyuryoten_cd"), false);
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
		case c_modedel:	// 取消の場合
			// 伝票状態 使用不可
			itemDisabled(getAdvControlFromItemID("Denpyo_jyotai"), true);
			break;
		case c_moderef:		// 照会の場合
			// 伝票状態 使用可
			itemDisabled(getAdvControlFromItemID("Denpyo_jyotai"), false);
			break;

	}

}