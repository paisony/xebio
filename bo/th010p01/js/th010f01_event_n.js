/*-----------------------------------------------------------------------------
	モジュール:th010f01_event_n.js
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
	md_th010f01_register();
	
	//共通ロード設定
	setCommonLoad();

	// --------------------------
	// BO初期表示共通処理
	boLoadCommon();
	// --------------------------
	
	// 品種コード表示制御
	HinsyuControl();

	/* hrefの値が消えてしまうので毎回設定 */
	document.all.item("Btnmodejishahinban").href = "#tab26";
	document.all.item("Btnmodescancd").href = "#tab25";
	document.all.item("Btnmodemakerhbn").href = "#tab27";
	document.all.item("Btnmodesonota").href = "#tab28";

	// 商品マスタ検索選択：「サイズ別／プライス」をチェック
	//getAdvControlFromItemID("syohinmst_serchstk")[2].checked = true;

	// 選択不可
	selectorCheckBox = 'disable';

	// URLパラメータを取得
	//  ※ラジオボタンを指定した場合、フォーカス設定してくれないので自力でフォーカス設定
	var urlPara = get_url_vars();
	if (urlPara["StdFocusedItemID"] == "Syohinmst_serchstk") {
		for (i = 0; i < getAdvControlFromItemID("Syohinmst_serchstk").length; i++) {
			if (getAdvControlFromItemID("Syohinmst_serchstk")[i].checked == true) {
				getAdvControlFromItemID("Syohinmst_serchstk")[i].focus();
				break;
			}
		}
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
			// -----------------------
			// モードなしの表示に戻す
			//document.all.item(clm_StkMode).value = "";
			//nonmodeDisp();
			// -----------------------
			AdvGB_LastClickItemNm = null;
			return false;
		}
	}

	// ここに業務固有チェック処理を記述します。
	switch (AdvGB_LastClickItemNm.toUpperCase()) {
		
		// CSV出力ボタン
		case "Btncsv".toUpperCase():

			// 確認メッセージを表示
			var yes = function () {
				$("#Btncsv")[0].click();
			}
			var no = function () {
			}
			var msg = getMessage("I101");
			if (boOpenInfoDialog(msg, yes, no) == false) {
				// いいえの場合、処理終了
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

		// タブ処理
		case "BTNMODEJISHAHINBAN".toUpperCase():
		case "BTNMODESCANCD".toUpperCase():
		case "BTNMODEMAKERHBN".toUpperCase():
		case "BTNMODESONOTA".toUpperCase():

			// モードボタン共通処理
			//tabClick(eventTargetName.toUpperCase());
			// 入力値クリアの確認メッセージ表示
			prvSerchInputClear(eventTargetName);
		return false;

		// -------------------
		// Ｍ１自社品番リンク
		// -------------------
		case "M1jisya_hbn".toUpperCase():
		case "M1old_jisya_hbn".toUpperCase():
			// [商品マスタ検索選択]が「在庫検索」の場合
			break;

		// -------------------
		// 部門コード
		// -------------------
		// 部門コードボタン押下時、品種コードボタンを活性化
		case "Btnbumon_cd".toUpperCase():
			itemDisabled(getAdvControlFromItemID("Btnhinsyu_cd"), false);
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

	case "Siiresaki_cd".toUpperCase():	// 仕入先コード
		// 名称取得部品を起動
		V02002_MAIN(getAdvControlFromItemID("Siiresaki_cd"), getAdvControlFromItemID("Siiresaki_ryaku_nm"), getAdvControlFromItemID("Siiresaki_cd"), 1);
		break;

	case "Scan_cd".toUpperCase():	// スキャンコード

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
		var result = null;	// 未指定

		// 名称取得部品
		V02004(condition, result, getAdvControlFromItemID("Scan_cd"), false, null);
		break;

	case "Bumon_cd".toUpperCase():		// 部門コード
		// 名称取得部品を起動
		V02010_MAIN(getAdvControlFromItemID("Bumon_cd"), getAdvControlFromItemID("Bumon_nm"), getAdvControlFromItemID("Bumon_cd"), 1);
		// 品種コードの表示制御
		HinsyuControl();
		break;

	case "Hinsyu_cd".toUpperCase():	// 品種コード
		// 名称取得部品を起動
		V02011_MAIN(getAdvControlFromItemID("Bumon_cd"), getAdvControlFromItemID("Hinsyu_cd"), getAdvControlFromItemID("Hinsyu_ryaku_nm"), getAdvControlFromItemID("Hinsyu_cd"), null, 1);
		break;

	case "Burando_cd".toUpperCase():	// ブランドコード
		// 名称取得部品を起動
		V02012_MAIN(getAdvControlFromItemID("Burando_cd"), getAdvControlFromItemID("Burando_nm"), getAdvControlFromItemID("Burando_cd"), 1);
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
		case "Bumon_cd".toUpperCase():	// 部門コードFROM
			if (ev.key == "Enter" && !ev.shiftKey) {
				// Enterキー押下時
				// 品種コード表示制御
				HinsyuControl();
				if (getAdvControlFromItemID("Bumon_cd").value == "") {
					// 部門コードが未設定の場合
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

		case "Old_jisya_hbn_from".toUpperCase():	// 旧自社品番FROM
			// フォーマット処理
			formatJisyaHbnCd(getAdvControlFromItemID("Old_jisya_hbn_from"));
			// FROMの値をTOへコピー
			fromToCopy("Old_jisya_hbn");
			break;
		case "Old_jisya_hbn_to".toUpperCase():		// 旧自社品番TO
			// フォーマット処理
			formatJisyaHbnCd(getAdvControlFromItemID("Old_jisya_hbn_to"));
			break;
		case "Bumon_cd".toUpperCase():	// 部門コード
			// 品種コード表示制御
			HinsyuControl();
			break;
		case "Genbaika_tnk_from".toUpperCase():		// 現売価FROM
			// FROMの値をTOへコピー
			fromToCopy("Genbaika_tnk");
			break;
		case "Makerkakaku_tnk_from".toUpperCase():	// メーカー価格FROM
			// FROMの値をTOへコピー
			fromToCopy("Makerkakaku_tnk");
			break;
		case "Hanbaikanryo_ymd_from".toUpperCase():	// 販売完了日FROM
			// FROMの値をTOへコピー
			fromToCopy("Hanbaikanryo_ymd");
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
// 品種コードの表示制御を行う
function HinsyuControl() {
	// 部門コードが未設定の場合
	if (getAdvControlFromItemID("Bumon_cd").value == "") {
		// 品種コードを使用不可
		getAdvControlFromItemID("Hinsyu_cd").value = "";
		getAdvControlFromItemID("Hinsyu_ryaku_nm").value = "";
		itemDisabled(getAdvControlFromItemID("Hinsyu_cd"), true);
	} else {
		// 品種コードを使用可
		itemDisabled(getAdvControlFromItemID("Hinsyu_cd"), false);
	}
}


// モード変更確認メッセージ表示時のYESアクション
function tabClick_YesAction(tabnm) {
	// 品種コードの表示制御
	HinsyuControl();
}
// モード変更確認メッセージ表示時のNOアクション
function tabClick_NoAction(tabnm) {
}
// 検索条件クリア
function prvSerchInputClear(eventTargetName) {
	// 入力値クリアの確認メッセージ表示
	if (getAdvControlFromItemID(clm_Mode).value == c_modejishahinban) {
		// 自社品番の場合
		// 入力値クリアの確認メッセージ表示
		var inputItem =
		[
			  [getAdvControlFromItemID("Old_jisya_hbn_from"), ""]
			, [getAdvControlFromItemID("Old_jisya_hbn_to"), ""]
		];
		var labelItem =
		[
		];
		searchInputClear(eventTargetName, inputItem, labelItem);
	} else if (getAdvControlFromItemID(clm_Mode).value == c_modescancd) {
		// スキャンコードの場合
		var inputItem =
		[
			  [getAdvControlFromItemID("Scan_cd"), ""]
		];
		var labelItem =
		[
		];
		searchInputClear(eventTargetName, inputItem, labelItem);
	} else if (getAdvControlFromItemID(clm_Mode).value == c_modemakerhbn) {
		// メーカー品番の場合
		var inputItem =
		[
			  [getAdvControlFromItemID("Maker_hbn"), ""]
		];
		var labelItem =
		[
		];
		searchInputClear(eventTargetName, inputItem, labelItem);
	} else if (getAdvControlFromItemID(clm_Mode).value == c_modesonota) {
		// その他の場合
		var inputItem =
		[
			  [getAdvControlFromItemID("Bumon_cd"), ""]
			, [getAdvControlFromItemID("Hinsyu_cd"), ""]
			, [getAdvControlFromItemID("Burando_cd"), ""]
			, [getAdvControlFromItemID("Siiresaki_cd"), ""]
			, [getAdvControlFromItemID("Genbaika_tnk_from"), ""]
			, [getAdvControlFromItemID("Genbaika_tnk_to"), ""]
			, [getAdvControlFromItemID("Makerkakaku_tnk_from"), ""]
			, [getAdvControlFromItemID("Makerkakaku_tnk_to"), ""]
			, [getAdvControlFromItemID("Hanbaikanryo_ymd_from"), ""]
			, [getAdvControlFromItemID("Hanbaikanryo_ymd_to"), ""]
		];
		var labelItem =
		[
			  [getAdvControlFromItemID("Bumon_nm"), ""]
			, [getAdvControlFromItemID("Hinsyu_ryaku_nm"), ""]
			, [getAdvControlFromItemID("Burando_nm"), ""]
			, [getAdvControlFromItemID("Siiresaki_ryaku_nm"), ""]
		];
		searchInputClear(eventTargetName, inputItem, labelItem);
	} else {
		vRet = tabClick(eventTargetName.toUpperCase());
	}
}
