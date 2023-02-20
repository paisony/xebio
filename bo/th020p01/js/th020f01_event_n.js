/*-----------------------------------------------------------------------------
	モジュール:th020f01_event_n.js
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
	md_th020f01_register();
	
	//共通ロード設定
	setCommonLoad();

	// --------------------------
	// BO初期表示共通処理
	boLoadCommon();
	// --------------------------

	/* hrefの値が消えてしまうので毎回設定 */
	document.all.item("Btnmodejishahinban").href = "#tab26";
	document.all.item("Btnmodejishahinban2").href = "#tab33";
	document.all.item("Btnmodescancd").href = "#tab25";
	document.all.item("Btnmodemakerhbn").href = "#tab27";

	// 行選択不可
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
		case "BTNMODEJISHAHINBAN2".toUpperCase():
		case "BTNMODESCANCD".toUpperCase():
		case "BTNMODEMAKERHBN".toUpperCase():

			// モードボタン共通処理
			//tabClick(eventTargetName.toUpperCase());
			// 入力値クリアの確認メッセージ表示
			prvSerchInputClear(eventTargetName);
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
		case "Kaisya_cd".toUpperCase():			// 会社コード
			// 名称取得部品を起動
			V02006_MAIN(getAdvControlFromItemID("Kaisya_cd"), getAdvControlFromItemID("Kaisya_nm"), getAdvControlFromItemID("Kaisya_cd"), 1);
			break;
		case "Kaisya_cd2".toUpperCase():		// 会社コード2
			// 名称取得部品を起動
			V02006_MAIN(getAdvControlFromItemID("Kaisya_cd2"), getAdvControlFromItemID("Kaisya_nm2"), getAdvControlFromItemID("Kaisya_cd2"), 1);
			break;
		case "Kaisya_cd3".toUpperCase():		// 会社コード3
			// 名称取得部品を起動
			V02006_MAIN(getAdvControlFromItemID("Kaisya_cd3"), getAdvControlFromItemID("Kaisya_nm3"), getAdvControlFromItemID("Kaisya_cd3"), 1);
			break;
		case "Kaisya_cd4".toUpperCase():		// 会社コード4
			// 名称取得部品を起動
			V02006_MAIN(getAdvControlFromItemID("Kaisya_cd4"), getAdvControlFromItemID("Kaisya_nm4"), getAdvControlFromItemID("Kaisya_cd4"), 1);
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
		case "Old_jisya_hbn_from".toUpperCase():	// 旧自社品番FROM
			// 自社品番丸め処理
			formatJisyaHbnCd(getAdvControlFromItemID("Old_jisya_hbn_from"));
			// FROMの値をTOへコピー
			fromToCopy("Old_jisya_hbn");
			break;
		case "Old_jisya_hbn_to".toUpperCase():		// 旧自社品番TO
			// 自社品番丸め処理
			formatJisyaHbnCd(getAdvControlFromItemID("Old_jisya_hbn_to"));
			break;

		case "Old_jisya_hbn".toUpperCase():			// 旧自社品番
			// 自社品番丸め処理
			formatJisyaHbnCd(getAdvControlFromItemID("Old_jisya_hbn"));
			break;
		case "Old_jisya_hbn2".toUpperCase():		// 旧自社品番2
			// 自社品番丸め処理
			formatJisyaHbnCd(getAdvControlFromItemID("Old_jisya_hbn2"));
			break;
		case "Old_jisya_hbn3".toUpperCase():		// 旧自社品番3
			// 自社品番丸め処理
			formatJisyaHbnCd(getAdvControlFromItemID("Old_jisya_hbn3"));
			break;
		case "Old_jisya_hbn4".toUpperCase():		// 旧自社品番4
			// 自社品番丸め処理
			formatJisyaHbnCd(getAdvControlFromItemID("Old_jisya_hbn4"));
			break;
		case "Old_jisya_hbn5".toUpperCase():		// 旧自社品番5
			// 自社品番丸め処理
			formatJisyaHbnCd(getAdvControlFromItemID("Old_jisya_hbn5"));
			break;

		case "Scan_cd_from".toUpperCase():			// スキャンコードFROM
			// スキャンコード丸め処理
			formatScanCd(getAdvControlFromItemID("Scan_cd_from"));
			// FROMの値をTOへコピー
			fromToCopy("Scan_cd");
			break;
		case "Scan_cd_to".toUpperCase():			// スキャンコードTO
			// スキャンコード丸め処理
			formatScanCd(getAdvControlFromItemID("Scan_cd_to"));
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
	var result = null;

	// 名称取得部品
	V02003(condition, result, getAdvControlFromItemID(CTLname), false, 0);
}


// モード変更確認メッセージ表示時のYESアクション
function tabClick_YesAction(tabnm) {
	if (getModeNo(tabnm) == c_modejishahinban) {
		// 自社品番
		// 名称取得部品を起動
		V02006(getAdvControlFromItemID("Kaisya_cd"), getAdvControlFromItemID("Kaisya_nm"), getAdvControlFromItemID("Kaisya_cd"));
	} else if (getModeNo(tabnm) == c_modejisyahbnfukusu) {
		// 自社品番(複数)
		// 名称取得部品を起動
		V02006(getAdvControlFromItemID("Kaisya_cd2"), getAdvControlFromItemID("Kaisya_nm2"), getAdvControlFromItemID("Kaisya_cd2"));
	} else if (getModeNo(tabnm) == c_modescancd) {
		// スキャンコード
		// 名称取得部品を起動
		V02006(getAdvControlFromItemID("Kaisya_cd3"), getAdvControlFromItemID("Kaisya_nm3"), getAdvControlFromItemID("Kaisya_cd3"));
	} else if (getModeNo(tabnm) == c_modemakerhbn) {
		// メーカー品番
		// 名称取得部品を起動
		V02006(getAdvControlFromItemID("Kaisya_cd4"), getAdvControlFromItemID("Kaisya_nm4"), getAdvControlFromItemID("Kaisya_cd4"));
	}
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
			, [getAdvControlFromItemID("Kaisya_cd"), LPadZero(document.forms.Th020f01.bocommon$logininfo_copcd.value, 2)]
		];
		var labelItem =
		[
			  [getAdvControlFromItemID("Kaisya_nm"), ""]
		];
		searchInputClear(eventTargetName, inputItem, labelItem);
	} else if (getAdvControlFromItemID(clm_Mode).value == c_modejisyahbnfukusu) {
		// 自社品番(複数)の場合
		var inputItem =
		[
			  [getAdvControlFromItemID("Old_jisya_hbn"), ""]
			, [getAdvControlFromItemID("Old_jisya_hbn2"), ""]
			, [getAdvControlFromItemID("Old_jisya_hbn3"), ""]
			, [getAdvControlFromItemID("Old_jisya_hbn4"), ""]
			, [getAdvControlFromItemID("Old_jisya_hbn5"), ""]
			, [getAdvControlFromItemID("Kaisya_cd2"), LPadZero(document.forms.Th020f01.bocommon$logininfo_copcd.value, 2)]
		];
		var labelItem =
		[
			  [getAdvControlFromItemID("Kaisya_nm2"), ""]
		];
		searchInputClear(eventTargetName, inputItem, labelItem);
	} else if (getAdvControlFromItemID(clm_Mode).value == c_modescancd) {
		// スキャンコードの場合
		var inputItem =
		[
			  [getAdvControlFromItemID("Scan_cd_from"), ""]
			, [getAdvControlFromItemID("Scan_cd_to"), ""]
			, [getAdvControlFromItemID("Kaisya_cd3"), LPadZero(document.forms.Th020f01.bocommon$logininfo_copcd.value, 2)]
		];
		var labelItem =
		[
			  [getAdvControlFromItemID("Kaisya_nm3"), ""]
		];
		searchInputClear(eventTargetName, inputItem, labelItem);
	} else if (getAdvControlFromItemID(clm_Mode).value == c_modemakerhbn) {
		// メーカー品番の場合
		var inputItem =
		[
			  [getAdvControlFromItemID("Maker_hbn"), ""]
			, [getAdvControlFromItemID("Kaisya_cd4"), LPadZero(document.forms.Th020f01.bocommon$logininfo_copcd.value, 2)]
		];
		var labelItem =
		[
			  [getAdvControlFromItemID("Kaisya_nm4"), ""]
		];
		searchInputClear(eventTargetName, inputItem, labelItem);
	} else {
		vRet = tabClick(eventTargetName.toUpperCase());
	}
}
