/*-----------------------------------------------------------------------------
	モジュール:tl020f01_event_n.js
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
	md_tl020f01_register();
	
	//共通ロード設定
	setCommonLoad();

	// --------------------------
	// BO初期表示共通処理
	boLoadCommon();
	// --------------------------

	// URLパラメータを取得
	//  ※ラジオボタンを指定した場合、フォーカス設定してくれないので自力でフォーカス設定
	var urlPara = get_url_vars();

	// 出力シール
	if (urlPara["StdFocusedItemID"] == "M1bumonkana_nm") {
		if (getAdvControlFromItemID("Shuturyoku_seal")[0].checked == false ||
			getAdvControlFromItemID("Shuturyoku_seal")[1].checked == false) {
			// 出力シール：８％をチェック
			//getAdvControlFromItemID("Shuturyoku_seal")[0].checked = true;
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
			AdvGB_LastClickItemNm = null;
			return false;
		}
	}

	// ここに業務固有チェック処理を記述します。
	switch (AdvGB_LastClickItemNm.toUpperCase()) {

		// シール発行ボタン
		case "Btnseal".toUpperCase():

			// 確認メッセージを表示
			var yes = function () {
				$("#Btnseal")[0].click();
			}
			var no = function () {
			}
			var msg = getMessage("I103");
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
			// 名称取得部品を起動(存在チェック)
			V02001(getAdvControlFromItemID("Head_tenpo_cd"), getAdvControlFromItemID("Head_tenpo_nm"), getAdvControlFromItemID("Head_tenpo_cd"));
			break;
		case "Bumon_cd_from".toUpperCase():	// 部門コードfrom
			// 名称取得部品を起動(存在チェック)
			V02010_MAIN(getAdvControlFromItemID("Bumon_cd_from"), getAdvControlFromItemID("Bumon_nm_from"), null, 0);
			break;
		case "Bumon_cd_to".toUpperCase():	// 部門コードto
			// 名称取得部品を起動(存在チェック)
			V02010_MAIN(getAdvControlFromItemID("Bumon_cd_to"), getAdvControlFromItemID("Bumon_nm_to"), null, 0);
			break;
		case "Torokukak_cd".toUpperCase():	// 確定者コード
			// 名称取得部品を起動
			V02005_MAIN(getAdvControlFromItemID("Torokukak_cd"), getAdvControlFromItemID("Torokukak_nm"), getAdvControlFromItemID("Torokukak_cd"), 0);
			break;
		case "Old_jisya_hbn".toUpperCase():	// 旧自社品番
			// 名称取得部品を起動(存在チェック)
			RunV2003("Old_jisya_hbn", getAdvControlFromItemID("Maker_hbn"));
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
		case "Baihen_shiji_no_from".toUpperCase():	// 指示番号FROM
			//// アンフォーマットする
			//unformatSijinobaihen(getAdvControlFromItemID("Baihen_shiji_no_from"));
			break;
		case "Baihen_shiji_no_to".toUpperCase():	// 指示番号TO
			//// アンフォーマットする
			//unformatSijinobaihen(getAdvControlFromItemID("Baihen_shiji_no_to"));
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

		case "Bumon_cd_from".toUpperCase():	// 部門コードFROM
			// FROMの値をTOへコピー
			fromToCopy("Bumon_cd");
			break;
		case "Baihen_shiji_no_from".toUpperCase():	// 売変指示ＮｏFROM
			// FROMの値をTOへコピー
			// フォーマット処理
			formatSijinobaihen(getAdvControlFromItemID("Baihen_shiji_no_from"));
			fromToCopy("Baihen_shiji_no");
			break;
		case "Baihen_shiji_no_to".toUpperCase():	// 売変指示No
			// フォーマット処理
			formatSijinobaihen(getAdvControlFromItemID("Baihen_shiji_no_to"));
			break;
		case "Baihensagyokaisi_ymd_from".toUpperCase():	// 売変作業開始日FROM
			// FROMの値をTOへコピー
			fromToCopy("Baihensagyokaisi_ymd");
			break;
		case "Baihenkaisi_ymd_from".toUpperCase():	// 売変開始日FROM
			// FROMの値をTOへコピー
			fromToCopy("Baihenkaisi_ymd");
			break;
		case "Kakutei_ymd_from".toUpperCase():	// 確定日FROM
			// FROMの値をTOへコピー
			fromToCopy("Kakutei_ymd");
			break;
		case "Old_jisya_hbn".toUpperCase():	// 旧自社品番
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

/*-----------------------------------------------------------------------------
発注マスタ取得(自社品番)呼び出し
 * @param CTLname {Object} - スキャンコード
-----------------------------------------------------------------------------*/
function RunV2003(CTLname) {

	// 検索条件指定(Key：固定、Value：検索値)
	var condition = {
		  "SCAN_CD"			: getAdvControlFromItemID(CTLname)
		, "TENPO_CD"		: getAdvControlFromItemID("Head_tenpo_cd")
		, "PLUFLG"			: "0"
		, "PRICEFLG"		: "0"
		, "ZAIKOFLG"		: "0"
		, "NYUKAFLG"		: "0"
		, "URIFLG"			: "0"
		, "HOJUFLG"			: "0"
		, "TANPINFLG"		: "0"
		, "SIJIFLG"			: "0"
		, "SIJI_NO"			: "0"
		, "SYUKAKAISYA_CD"	: "0"
		, "NYUKAKAISYA_CD"	: "0"
		, "SYUKATENPO_CD"	: "0"
	};
	// 戻り値指定(Key：SELECT句、Value：項目名)
	var result = {
		"HIN_NBR": getAdvControlFromItemID("Maker_hbn")		// メーカー品番
	};

	// 名称取得部品
	V02003(condition, result, getAdvControlFromItemID(CTLname), true, 0);
}
