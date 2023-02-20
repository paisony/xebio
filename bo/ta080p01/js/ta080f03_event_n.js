/*-----------------------------------------------------------------------------
	モジュール:ta080f03_event_n.js
--------------------------------------------------------------------------------*/
/*<title>[画面03CLイベントScript]</title>*/

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
	md_ta080f03_register();
	
	//共通ロード設定
	setCommonLoad();


	// --------------------------
	// BO初期表示共通処理
	boLoadCommon();
	// --------------------------

	//	hrefの値が消えてしまうので、毎回設定
	document.all.item("Btnmodeyosanjoho").href = "#tabYosan";
	document.all.item("Btnmodesiborikomi").href = "#tabShibori";

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
		// 戻るボタン
		case "Btnback".toUpperCase():
			// モードが「新規作成」「申請」「申請前修正」「申請取消」の場合、メッセージを出力
			if (getAdvControlFromItemID(clm_StkMode).value == c_insert
			 || getAdvControlFromItemID(clm_StkMode).value == c_modeapply
			 || getAdvControlFromItemID(clm_StkMode).value == c_modesinseimaeupd
			 || getAdvControlFromItemID(clm_StkMode).value == c_modesinseizumitorikesi) {

				// 確認メッセージを表示
				var yes = function () {
					$("#Btnback")[0].click();
				}
				var no = function () { }
				var msg = getMessage("W107");
				return boOpenInfoDialog(msg, yes, no);
			}
			break;
		// 検索ボタン
		case "Btnsearch".toUpperCase():
			// モードが「申請」「申請前修正」「申請取消」の場合、メッセージを出力
			if (getAdvControlFromItemID(clm_StkMode).value == c_modesinseizumitorikesi
			 || getAdvControlFromItemID(clm_StkMode).value == c_modeapply
			 || getAdvControlFromItemID(clm_StkMode).value == c_modesinseimaeupd) {

				// 確認メッセージを表示
				var yes = function () {
					$("#Btnsearch")[0].click();
				}
				var no = function () { }
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
	case "BTNMODEYOSANJOHO":
	case "BTNMODESIBORIKOMI":
		// モードボタン共通処理
		// 明細画面のモードまで考慮されていない
		// tabClick(eventTargetName.toUpperCase()); 
		tabClickMeisai(eventTargetName.toUpperCase());
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
	switch (eventTargetName.toUpperCase()) {
	//  ここに項目IDのcase文を追加し、固有処理を記述します。
		// -------------------
		// 部門コードFROM
		// -------------------
		case "Bumon_cd_from".toUpperCase():
			// 名称取得部品を起動
			V02010_MAIN(getAdvControlFromItemID("Bumon_cd_from"), getAdvControlFromItemID("Bumon_nm_from"), null, 0);
			break;

		// -------------------
		// 部門コードTO
		// -------------------
		case "Bumon_cd_to".toUpperCase():
			// 名称取得部品を起動
			V02010_MAIN(getAdvControlFromItemID("Bumon_cd_to"), getAdvControlFromItemID("Bumon_nm_to"), null, 0);
			break;

		// -------------------
		// 品種
		// -------------------
		case "Hinsyu_cd_all".toUpperCase():
			if (eventTarget.checked)
			{
				getAdvControlFromItemID("Hinsyu_cd1").checked = 
				getAdvControlFromItemID("Hinsyu_cd2").checked = 
				getAdvControlFromItemID("Hinsyu_cd3").checked = 
				getAdvControlFromItemID("Hinsyu_cd4").checked = 
				getAdvControlFromItemID("Hinsyu_cd5").checked = 
				getAdvControlFromItemID("Hinsyu_cd6").checked = 
				getAdvControlFromItemID("Hinsyu_cd7").checked = 
				getAdvControlFromItemID("Hinsyu_cd8").checked = 
				getAdvControlFromItemID("Hinsyu_cd9").checked = true;
			}
			else {
				getAdvControlFromItemID("Hinsyu_cd1").checked = 
				getAdvControlFromItemID("Hinsyu_cd2").checked = 
				getAdvControlFromItemID("Hinsyu_cd3").checked = 
				getAdvControlFromItemID("Hinsyu_cd4").checked = 
				getAdvControlFromItemID("Hinsyu_cd5").checked = 
				getAdvControlFromItemID("Hinsyu_cd6").checked = 
				getAdvControlFromItemID("Hinsyu_cd7").checked = 
				getAdvControlFromItemID("Hinsyu_cd8").checked = 
				getAdvControlFromItemID("Hinsyu_cd9").checked = false;

			}
			break;
		case "Hinsyu_cd1".toUpperCase():
		case "Hinsyu_cd2".toUpperCase():
		case "Hinsyu_cd3".toUpperCase():
		case "Hinsyu_cd4".toUpperCase():
		case "Hinsyu_cd5".toUpperCase():
		case "Hinsyu_cd6".toUpperCase():
		case "Hinsyu_cd7".toUpperCase():
		case "Hinsyu_cd8".toUpperCase():
		case "Hinsyu_cd9".toUpperCase():

			if(getAdvControlFromItemID("Hinsyu_cd1").checked == true
			&& getAdvControlFromItemID("Hinsyu_cd2").checked == true
			&& getAdvControlFromItemID("Hinsyu_cd3").checked == true
			&& getAdvControlFromItemID("Hinsyu_cd4").checked == true
			&& getAdvControlFromItemID("Hinsyu_cd5").checked == true
			&& getAdvControlFromItemID("Hinsyu_cd6").checked == true
			&& getAdvControlFromItemID("Hinsyu_cd7").checked == true
			&& getAdvControlFromItemID("Hinsyu_cd8").checked == true
			&& getAdvControlFromItemID("Hinsyu_cd9").checked == true
				)
			{
				getAdvControlFromItemID("Hinsyu_cd_all").checked = true;
			}
			else {
				getAdvControlFromItemID("Hinsyu_cd_all").checked = false;
			}
			break;

		// -------------------
		// ブランドコード
		// -------------------
		case "Burando_cd".toUpperCase():
			// 名称取得部品を起動
			V02012_MAIN(getAdvControlFromItemID("Burando_cd"), getAdvControlFromItemID("Burando_nm"), getAdvControlFromItemID("Burando_cd"), 0);
			break;

		// -------------------
		// 自社品番
		// -------------------
		case "Old_jisya_hbn".toUpperCase():
			// 名称表示
			// 検索条件指定(Key：固定、Value：検索値)
			var condition = {
				"SCAN_CD": getAdvControlFromItemID("Old_jisya_hbn")		// 自社品番コード
				, "TENPO_CD": getAdvControlFromItemID("Head_tenpo_cd")		// 店舗コード
				, "PLUFLG"			: "0"									// 店別単価マスタ	検索フラグ 0:検索しない 1:検索する
				, "PRICEFLG"		: "0"									// 売変				検索フラグ 0:検索しない 1:検索する
				, "ZAIKOFLG"		: "0"									// 店在庫			検索フラグ 0:検索しない 1:検索する
				, "NYUKAFLG"		: "0"									// 入荷予定数		検索フラグ 0:検索しない 1:検索する
				, "URIFLG"			: "0"									// 売上実績数		検索フラグ 0:検索しない 1:検索する
				, "HOJUFLG"			: "0"									// 依頼集計数(補充)	検索フラグ 0:検索しない 1:検索する
				, "TANPINFLG"		: "0"									// 依頼集計数(単品)	検索フラグ 0:検索しない 1:検索する
				, "SIJIFLG"			: "0"									// 指示検索			検索フラグ 0:検索しない 1:出荷指示、2:返品指示
				, "SIJI_NO"			: "0"									// 指示NO（移動出荷マニュアル、返品マニュアル用）
				, "SYUKAKAISYA_CD"	: "0"									// 出荷会社コード（移動出荷マニュアル)
				, "NYUKAKAISYA_CD"	: "0"									// 入荷会社コード（移動出荷マニュアル)
				, "SYUKATENPO_CD"	: "0"									// 指示店舗コード（移動出荷マニュアル、返品マニュアル用）
			};
			// 戻り値指定(Key：SELECT句、Value：項目名)
			var result = {
				"HIN_NBR": getAdvControlFromItemID("Maker_hbn")					// メーカー品番
			};

			// 名称取得部品
			V02003(condition, result, getAdvControlFromItemID("Old_jisya_hbn"), false, null);
			break;

		// -------------------
		// スキャンコード
		// -------------------
		case "Scan_cd".toUpperCase():
			// 名称表示
			// 検索条件指定(Key：固定、Value：検索値)
			var condition = {
				 "SCAN_CD"			: getAdvControlFromItemID("Scan_cd", lineNo)	// スキャンコード
				,"TENPO_CD"			: getAdvControlFromItemID("Head_tenpo_cd")		// 店舗コード
				,"PLUFLG"			: "0"											// 店別単価マスタ	検索フラグ 0:検索しない 1:検索する
				,"PRICEFLG"			: "0"											// 売変				検索フラグ 0:検索しない 1:検索する
				,"ZAIKOFLG"			: "0"											// 店在庫			検索フラグ 0:検索しない 1:検索する
				,"NYUKAFLG"			: "0"											// 入荷予定数		検索フラグ 0:検索しない 1:検索する
				,"URIFLG"			: "0"											// 売上実績数		検索フラグ 0:検索しない 1:検索する
				,"HOJUFLG"			: "0"											// 依頼集計数(補充)	検索フラグ 0:検索しない 1:検索する
				,"TANPINFLG"		: "0"											// 依頼集計数(単品)	検索フラグ 0:検索しない 1:検索する
				,"SIJIFLG"			: "0"											// 指示検索			検索フラグ 0:検索しない 1:出荷指示、2:返品指示
				,"SIJI_NO"			: "0"											// 指示NO（移動出荷マニュアル、返品マニュアル用）
				,"SYUKAKAISYA_CD"	: "0"											// 出荷会社コード（移動出荷マニュアル)
				,"NYUKAKAISYA_CD"	: "0"											// 入荷会社コード（移動出荷マニュアル)
				,"SYUKATENPO_CD"	: "0"											// 指示店舗コード（移動出荷マニュアル、返品マニュアル用）
			};
			// 戻り値指定(Key：SELECT句、Value：項目名)
			var result = null;

			// 名称取得部品
			V02004(condition, result, getAdvControlFromItemID("Scan_cd"), false, null);
			break;

		// -------------------
		// 登録担当者コード
		// -------------------
		case "Tantosya_cd".toUpperCase():
			// 名称取得部品を起動 V02005
			V02005_MAIN(getAdvControlFromItemID("Tantosya_cd"), getAdvControlFromItemID("Hanbaiin_nm"), getAdvControlFromItemID("Tantosya_cd"), 0);
			break;

		// -------------------
		// Ｍ１スキャンコード
		// -------------------
		case "M1scan_cd".toUpperCase():
			// 明細行番号を取得する
			var lineNo = getItemMNofromCtrl(eventTarget);
			// 操作ありの背景色に変更
			commitColorSet(lineNo);
			// 初期化
			getAdvControlFromItemID("M1genkakin", lineNo).value = "";
			// 名称表示
			// 検索条件指定(Key：固定、Value：検索値)
			var condition = {
				 "SCAN_CD"			: getAdvControlFromItemID("M1scan_cd", lineNo)	// スキャンコード
				,"TENPO_CD"			: getAdvControlFromItemID("Head_tenpo_cd")		// 店舗コード
				,"PLUFLG"			: "0"											// 店別単価マスタ	検索フラグ 0:検索しない 1:検索する
				,"PRICEFLG"			: "0"											// 売変				検索フラグ 0:検索しない 1:検索する
				,"ZAIKOFLG"			: "1"											// 店在庫			検索フラグ 0:検索しない 1:検索する
				,"NYUKAFLG"			: "1"											// 入荷予定数		検索フラグ 0:検索しない 1:検索する
				,"URIFLG"			: "1"											// 売上実績数		検索フラグ 0:検索しない 1:検索する
				,"HOJUFLG"			: "1"											// 依頼集計数(補充)	検索フラグ 0:検索しない 1:検索する
				,"TANPINFLG"		: "0"											// 依頼集計数(単品)	検索フラグ 0:検索しない 1:検索する
				,"SIJIFLG"			: "0"											// 指示検索			検索フラグ 0:検索しない 1:出荷指示、2:返品指示
				,"SIJI_NO"			: "0"											// 指示NO（移動出荷マニュアル、返品マニュアル用）
				,"SYUKAKAISYA_CD"	: "0"											// 出荷会社コード（移動出荷マニュアル)
				,"NYUKAKAISYA_CD"	: "0"											// 入荷会社コード（移動出荷マニュアル)
				,"SYUKATENPO_CD"	: "0"											// 指示店舗コード（移動出荷マニュアル、返品マニュアル用）
			};
			// 戻り値指定(Key：SELECT句、Value：項目名)
			var result = {
				"BUMONKANA_NM"		: getAdvControlFromItemID("M1bumonkana_nm", lineNo)		// 部門カナ名
				, "HINSYU_RYAKU_NM"	: getAdvControlFromItemID("M1hinsyu_ryaku_nm", lineNo)		// 品種略名称
				, "BURANDO_NMK"		: getAdvControlFromItemID("M1burando_nm", lineNo)			// ブランド名
				, "XEBIO_CD"		: getAdvControlFromItemID("M1jisya_hbn", lineNo)			// 自社品番
				, "SYOHIN_ZOKUSEI"	: getAdvControlFromItemID("M1syohin_zokusei", lineNo)		// 商品属性
				, "HIN_NBR"			: getAdvControlFromItemID("M1maker_hbn", lineNo)			// メーカー品番
				, "SYONMK"			: getAdvControlFromItemID("M1syonmk", lineNo)				// 商品名(カナ)
				, "IRO_NM"			: getAdvControlFromItemID("M1iro_nm", lineNo)				// 色
				, "SIZE_NM"			: getAdvControlFromItemID("M1size_nm", lineNo)				// サイズ
				, "TEN_HYOKA"		: getAdvControlFromItemID("M1ten_hyoka_kb", lineNo)		// 店評価
				, "ALL_HYOKA"		: getAdvControlFromItemID("M1all_hyoka_kb", lineNo)		// 全評価
				, "URI_SU_TOU"		: getAdvControlFromItemID("M1tosyu_uriage_su", lineNo)		// 当週売上実績数
				, "URI_SU_1TH"		: getAdvControlFromItemID("M1zensyu_uriage_su", lineNo)	// 前週売上実績数
				, "URI_SU_2TH"		: getAdvControlFromItemID("M1zenzensyu_uriage_su", lineNo)	// 前々週売上実績数
				, "NYUKA_SU"		: getAdvControlFromItemID("M1nyukayotei_su", lineNo)		// 入荷予定数
				, "REAL_SU"			: getAdvControlFromItemID("M1tenzaiko_su", lineNo)			// 店在庫数
				, "JIDO_SU"			: getAdvControlFromItemID("M1jido_su", lineNo)				// 自動定数
				, "HAIBUNKANO_SU"	: getAdvControlFromItemID("M1haibunkano_su", lineNo)		// 配分可能数
				, "KEIKAKU_YMD"		: getAdvControlFromItemID("M1keikaku_ymd", lineNo)			// 計画期間
				, "MOTOMIYALOT_SU"	: getAdvControlFromItemID("M1lot_su", lineNo)				// ロット数
				, "GENKA"			: getAdvControlFromItemID("M1gen_tnk", lineNo)				// 原単価
				, "HANBAIKANRYO_YMD": getAdvControlFromItemID("M1hanbaikanryo_ymd", lineNo)	// 販売完了日
				, "URI_SU"			: getAdvControlFromItemID("M1uriage_su_hdn", lineNo)		// 売上4週分〈隠し〉
			};

			// 名称取得部品
			V02004(condition, result, getAdvControlFromItemID("M1scan_cd", lineNo), true, lineNo);

			break;

		// -------------------
		// Ｍ１依頼数量
		// -------------------
		case "M1irai_su".toUpperCase():
			// 明細行番号を取得する
			var lineNo = getItemMNofromCtrl(eventTarget);
			// 操作ありの背景色に変更
			commitColorSet(lineNo);
			// 
			SuryoWarningChk(lineNo);

			break;

		// -------------------
		// Ｍ１依頼理由
		// -------------------
		case "M1irairiyu_cd1".toUpperCase():
		case "M1irairiyu_cd2".toUpperCase():
			// 明細行番号を取得する
			var lineNo = getItemMNofromCtrl(eventTarget);
			// 操作ありの背景色に変更
			commitColorSet(lineNo);

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
var forceOnchangeF_Scan = false;
var forceOnchangeF_Su = false;
function onBlur(ev) {
	var eventTarget=getAdvEventTarget(ev);
	var eventTargetName=getAdvEventTargetName(ev);
	switch (eventTargetName.toUpperCase()) {
		//  ここに項目IDのcase文を追加し、固有処理を記述します。
		// -------------------
		// 部門コードFROM
		// -------------------
		case "Bumon_cd_from".toUpperCase():
			// FROMの値をTOへコピー
			fromToCopy("Bumon_cd");
			break;

		// -------------------
		// 登録日FROM
		// -------------------
		case "Add_ymd_from".toUpperCase():
			// FROMの値をTOへコピー
			fromToCopy("Add_ymd");
			break;

		// -------------------
		// 自社品番
		// -------------------
		case "Old_jisya_hbn".toUpperCase():
			formatJisyaHbnCd(getAdvControlFromItemID("Old_jisya_hbn"));
			break;

		// -------------------
		// スキャンコード
		// -------------------	
		case "Scan_cd".toUpperCase():	// スキャンコード
			// スキャンコード丸め処理
			formatScanCd(getAdvControlFromItemID("Scan_cd"));
			break;

		// -------------------
		// M1スキャンコード
		// -------------------
		case "M1scan_cd".toUpperCase():	// スキャンコード
			// 明細行番号を取得する
			var lineNo = getItemMNofromCtrl(eventTarget);
			// スキャンコード丸め処理
			formatScanCd(getAdvControlFromItemID("M1scan_cd", lineNo));
			if (forceOnchangeF_Scan) {
				// 強制的にチェンジ処理を実行
				g_onChange(getAdvControlFromItemID("M1scan_cd", lineNo));
				forceOnchangeF_Scan = false;
			}
			break;
			
		// -------------------
		// Ｍ１依頼数量
		// -------------------
		case "M1irai_su".toUpperCase():
			if (forceOnchangeF_Su) {
				// 強制的にチェンジ処理を実行
				g_onChange(getAdvControlFromItemID("M1irai_su", lineNo));
				forceOnchangeF_Su = false;
			}
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
// スキャンコード名称取得の出口ルーチン
function responseHandle_onAfter(lineNo) {
	getAdvControlFromItemID("M1hatchu_msg", lineNo).value = '';
	// 名称取得に成功した場合のみ以下のチェックを行う。
	var jisyahbn = getAdvControlFromItemID("M1jisya_hbn", lineNo);
	if (jisyahbn.value == null || jisyahbn.value == '') {
		// 合計値を再計算
		calcRow(lineNo);
		if (getAdvControlFromItemID("M1gen_tnk", lineNo).value == "") {
			getAdvControlFromItemID("M1genkakin", lineNo).value = '';
		}
		return;
	}

	// システム日付＋７取得
	var Sysdate = getSysDate(0);
	var SysdatePlus7 = getSysDate(7);
	// 販売完了日取得
	var Hankanbi = Nvl(getAdvControlFromItemID("M1hanbaikanryo_ymd", lineNo).value, "0");
	// 店舗評価取得
	var TenHyoka = Nvl(getAdvControlFromItemID("M1ten_hyoka_kb", lineNo).value, "");

	// フォーマット処理
	// 店在庫数
	Obj = getAdvControlFromItemID("M1tenzaiko_su", lineNo);
	Obj.value = getAdvFormatStr("M1tenzaiko_su", Obj.value);
	// 入荷予定数
	Obj = getAdvControlFromItemID("M1nyukayotei_su", lineNo);
	Obj.value = getAdvFormatStr("M1nyukayotei_su", Obj.value);
	// 当週売
	Obj = getAdvControlFromItemID("M1tosyu_uriage_su", lineNo);
	Obj.value = getAdvFormatStr("M1tosyu_uriage_su", Obj.value);
	// 前週売
	Obj = getAdvControlFromItemID("M1zensyu_uriage_su", lineNo);
	Obj.value = getAdvFormatStr("M1zensyu_uriage_su", Obj.value);
	// 前々週売
	Obj = getAdvControlFromItemID("M1zenzensyu_uriage_su", lineNo);
	Obj.value = getAdvFormatStr("M1zenzensyu_uriage_su", Obj.value);
	// 自動定数
	Obj = getAdvControlFromItemID("M1jido_su", lineNo);
	Obj.value = getAdvFormatStr("M1jido_su", Obj.value);
	// 配分可能数
	Obj = getAdvControlFromItemID("M1haibunkano_su", lineNo);
	Obj.value = getAdvFormatStr("M1haibunkano_su", Obj.value);
	// 販売完了日
	Obj = getAdvControlFromItemID("M1hanbaikanryo_ymd", lineNo);
	Obj.value = getAdvFormatStr("M1hanbaikanryo_ymd", Obj.value);
	if (Obj.value.length >= 8) {
		Obj.value = Obj.value.substring(2);
	}


	// ---------------------------------------------------------------------
	// 自動定数＞０の場合、警告表示(W110)する。(メッセージ：本部配分)
	// ---------------------------------------------------------------------
	if (Number(Nvl(getAdvControlFromItemID("M1jido_su", lineNo).value, "0").replace(/,/g, '')) > 0) {
		// 確認メッセージを表示
		var yes = function () {
			getAdvControlFromItemID("M1hatchu_msg", lineNo).value = '本部配分';
			// 合計値を再計算
			calcRow(lineNo);
			// 操作ありの背景色に変更
			commitColorSet(lineNo);
			// 依頼数量にフォーカス設定
			itemSetFocus(getAdvControlFromItemID("M1irai_su", lineNo));
		}
		var no = function () {
			clearRow(lineNo);
			// 合計値を再計算
			calcRow(lineNo);
			getAdvControlFromItemID("M1genkakin", lineNo).value = '';
			// スキャンコードにフォーカス設定
			//itemSetFocus(getAdvControlFromItemID("M1scan_cd", lineNo));
			setTimeout("itemSetFocus(getAdvControlFromItemID('M1scan_cd', " + lineNo + "));", 500);
			forceOnchangeF_Scan = true;
		}
		var msg = getMessage("W110");
		boOpenInfoDialog(msg, yes, no);
		if (boOpenInfoDialog(msg, yes, no) == false) {
			return false;
		}
	// ---------------------------------------------------------------------
	// 店在庫＞０かつ、売上実績数＜＝０の場合、警告表示(W111)する。(メッセージ：売上実績なし)
	// ---------------------------------------------------------------------
	} else if (Number(Nvl(getAdvControlFromItemID("M1tenzaiko_su", lineNo).value, "0").replace(/,/g, '')) > 0
		&& Number(Nvl(getAdvControlFromItemID("M1uriage_su_hdn", lineNo).value, "0").replace(/,/g, '')) <= 0) {
		// 確認メッセージを表示
		var yes = function () {
			getAdvControlFromItemID("M1hatchu_msg", lineNo).value = '売上実績なし';
			// 合計値を再計算
			calcRow(lineNo);
			// 操作ありの背景色に変更
			commitColorSet(lineNo);
			// 依頼数量にフォーカス設定
			itemSetFocus(getAdvControlFromItemID("M1irai_su", lineNo));
		}
		var no = function () {
			clearRow(lineNo);
			// 合計値を再計算
			calcRow(lineNo);
			getAdvControlFromItemID("M1genkakin", lineNo).value = '';
			// スキャンコードにフォーカス設定
			//itemSetFocus(getAdvControlFromItemID("M1scan_cd", lineNo));
			setTimeout("itemSetFocus(getAdvControlFromItemID('M1scan_cd', " + lineNo + "));", 500);
			forceOnchangeF_Scan = true;
		}
		var msg = getMessage("W111");
		boOpenInfoDialog(msg, yes, no);
		if (boOpenInfoDialog(msg, yes, no) == false) {
			return false;
		}
	// ---------------------------------------------------------------------
	// Ｍ１依頼数量＜＝（入荷予定数）の場合、警告表示(W112)する。(メッセージ：入荷予定あり)
	// ---------------------------------------------------------------------
	} else if (Nvl(getAdvControlFromItemID("M1nyukayotei_su", lineNo).value, "0").replace(/,/g, '') > 0
		&& Nvl(getAdvControlFromItemID("M1irai_su", lineNo).value, "").replace(/,/g, '') != ""
		&& Number(Nvl(getAdvControlFromItemID("M1irai_su", lineNo).value, "0").replace(/,/g, '')) <= Number(Nvl(getAdvControlFromItemID("M1nyukayotei_su", lineNo).value, "0").replace(/,/g, ''))) {
		// 確認メッセージを表示
		var yes = function () {
			getAdvControlFromItemID("M1hatchu_msg", lineNo).value = '入荷予定あり';
			// 合計値再計算
			calcRow(lineNo);
			// 操作ありの背景色に変更
			commitColorSet(lineNo);
			//// 依頼数量にフォーカス設定
			//itemSetFocus(getAdvControlFromItemID("M1irai_su", lineNo));
		}
		var no = function () {
			getAdvControlFromItemID("M1irai_su", lineNo).value = getAdvControlFromItemID("M1irai_su_hdn", lineNo).value;
			// 依頼数量にフォーカス設定
			//itemSetFocus(getAdvControlFromItemID("M1irai_su", lineNo));
			setTimeout("itemSetFocus(getAdvControlFromItemID('M1irai_su', " + lineNo + "));", 500);
			forceOnchangeF_Su = true;
		}
		var msg = getMessage("W112");
		if (boOpenInfoDialog(msg, yes, no) == false) {
			return false;
		}
	// ---------------------------------------------------------------------
	// システム日付＋7＞＝販売完了日の場合、警告表示(W125)する。(メッセージ：販売完了間近)
	// ---------------------------------------------------------------------
	} else if (Number(SysdatePlus7) >= Hankanbi && Sysdate <= Hankanbi) {
		// 確認メッセージを表示
		var yes = function () {
			getAdvControlFromItemID("M1hatchu_msg", lineNo).value = '販売完了間近';
			// 合計値を再計算
			calcRow(lineNo);
			// 操作ありの背景色に変更
			commitColorSet(lineNo);
			// 依頼数量にフォーカス設定
			itemSetFocus(getAdvControlFromItemID("M1irai_su", lineNo));
		}
		var no = function () {
			clearRow(lineNo);
			// 合計値を再計算
			calcRow(lineNo);
			getAdvControlFromItemID("M1genkakin", lineNo).value = '';
			// スキャンコードにフォーカス設定
			//itemSetFocus(getAdvControlFromItemID("M1scan_cd", lineNo));
			setTimeout("itemSetFocus(getAdvControlFromItemID('M1scan_cd', " + lineNo + "));", 500);
			forceOnchangeF_Scan = true;
		}
		var msg = getMessage("W125", [formatYYYYMMDDSrash(Hankanbi)]);
		boOpenInfoDialog(msg, yes, no);
		if (boOpenInfoDialog(msg, yes, no) == false) {
			return false;
		}
	// ---------------------------------------------------------------------
	// ④店舗評価＝"NULL"の場合、警告表示(W128)する。(メッセージ：自店舗未展開)
	// ---------------------------------------------------------------------
	} else if (TenHyoka == null || TenHyoka == "") {
		// 確認メッセージを表示
		var yes = function () {
			getAdvControlFromItemID("M1hatchu_msg", lineNo).value = '自店舗未展開';
			// 合計値を再計算
			calcRow(lineNo);
			// 操作ありの背景色に変更
			commitColorSet(lineNo);
			// 依頼数量にフォーカス設定
			itemSetFocus(getAdvControlFromItemID("M1irai_su", lineNo));
		}
		var no = function () {
			clearRow(lineNo);
			// 合計値を再計算
			calcRow(lineNo);
			getAdvControlFromItemID("M1genkakin", lineNo).value = '';
			// スキャンコードにフォーカス設定
			//itemSetFocus(getAdvControlFromItemID("M1scan_cd", lineNo));
			setTimeout("itemSetFocus(getAdvControlFromItemID('M1scan_cd', " + lineNo + "));", 500);
			forceOnchangeF_Scan = true;
		}
		var msg = getMessage("W128");
		boOpenInfoDialog(msg, yes, no);
		if (boOpenInfoDialog(msg, yes, no) == false) {
			return false;
		}

	// ---------------------------------------------------------------------
	// ⑤店舗評価＝"-"の場合、警告表示(W129)する。(メッセージ：投入直後)
	// ---------------------------------------------------------------------
	} else if (TenHyoka == "-") {
		// 確認メッセージを表示
		var yes = function () {
			getAdvControlFromItemID("M1hatchu_msg", lineNo).value = '投入直後';
			// 合計値を再計算
			calcRow(lineNo);
			// 操作ありの背景色に変更
			commitColorSet(lineNo);
			// 依頼数量にフォーカス設定
			itemSetFocus(getAdvControlFromItemID("M1irai_su", lineNo));
		}
		var no = function () {
			clearRow(lineNo);
			// 合計値を再計算
			calcRow(lineNo);
			getAdvControlFromItemID("M1genkakin", lineNo).value = '';
			// スキャンコードにフォーカス設定
			//itemSetFocus(getAdvControlFromItemID("M1scan_cd", lineNo));
			setTimeout("itemSetFocus(getAdvControlFromItemID('M1scan_cd', " + lineNo + "));", 500);
			forceOnchangeF_Scan = true;
		}
		var msg = getMessage("W129");
		boOpenInfoDialog(msg, yes, no);
		if (boOpenInfoDialog(msg, yes, no) == false) {
			return false;
		}

	} else {
		if (getAdvControlFromItemID("M1scan_cd", lineNo).value != "") {
			// 合計値を再計算
			calcRow(lineNo);
			if (getAdvControlFromItemID("M1gen_tnk", lineNo).value == "") {
				getAdvControlFromItemID("M1genkakin", lineNo).value = '';
			}
		} else {
			clearRow(lineNo);
		}
		// 操作ありの背景色に変更
		commitColorSet(lineNo);
	}

	AdvGB_SubmitFLG = false;
	return true;
}

// 数量警告チェック
function SuryoWarningChk(lineNo) {
	// 名称取得に成功した場合のみ以下のチェックを行う。
	var jisyahbn = getAdvControlFromItemID("M1jisya_hbn", lineNo);
	//if (jisyahbn.value == null || jisyahbn.value == '') {
	//	return;
	//}

	if ((jisyahbn.value != null && jisyahbn.value != '')
		&& Nvl(getAdvControlFromItemID("M1nyukayotei_su", lineNo).value, "0").replace(/,/g, '') > 0
		&& Nvl(getAdvControlFromItemID("M1irai_su", lineNo).value, "").replace(/,/g, '') != ""
		&& Number(Nvl(getAdvControlFromItemID("M1irai_su", lineNo).value, "0").replace(/,/g, '')) <= Number(Nvl(getAdvControlFromItemID("M1nyukayotei_su", lineNo).value, "0").replace(/,/g, ''))) {
		// 確認メッセージを表示
		var yes = function () {
			getAdvControlFromItemID("M1hatchu_msg", lineNo).value = '入荷予定あり';
			// 合計値再計算
			calcRow(lineNo);
			// 操作ありの背景色に変更
			commitColorSet(lineNo);
			// 依頼数量にフォーカス設定
			if (getAdvControlFromItemID("M1irairiyu_cd1", lineNo).disabled) {
				setTimeout("getAdvControlFromItemID('M1irairiyu_cd2', " + lineNo + ").focus();", 500);
			} else {
				setTimeout("getAdvControlFromItemID('M1irairiyu_cd1', " + lineNo + ").focus();", 500);
			}
		}
		var no = function () {
			getAdvControlFromItemID("M1irai_su", lineNo).value = getAdvControlFromItemID("M1irai_su_hdn", lineNo).value;
			// 依頼数量にフォーカス設定
			//itemSetFocus(getAdvControlFromItemID("M1irai_su", lineNo));
			setTimeout("itemSetFocus(getAdvControlFromItemID('M1irai_su', " + lineNo + "));", 500);
			forceOnchangeF_Su = true;
		}
		var msg = getMessage("W112");
		if (boOpenInfoDialog(msg, yes, no) == false) {
			return false;
		}
	} else {
		// 合計値を再計算
		calcRow(lineNo);
		// 操作ありの背景色に変更
		commitColorSet(lineNo);
	}

	//AdvGB_SubmitFLG = false;
	return true;
}

// 明細合計値計算関数
function calcRow(lineNo) {

	// Ｍ１依頼数量
	var su = getAdvControlFromItemID("M1irai_su", lineNo);
	// Ｍ１依頼数量(隠し)
	var suHid = getAdvControlFromItemID("M1irai_su_hdn", lineNo);
	// Ｍ１原単価
	var genka = getAdvControlFromItemID("M1gen_tnk", lineNo);
	// Ｍ１原価金額
	var genkaKin = getAdvControlFromItemID("M1genkakin", lineNo);
	// Ｍ１原価金額(隠し)
	var genkaKinHid = getAdvControlFromItemID("M1genkakin_hdn", lineNo);

	// 合計依頼数量
	var sumSu = getAdvControlFromItemID("Gokei_irai_su");
	// 合計原価金額
	var sumGenkaKin = getAdvControlFromItemID("Gokei_genkakin");

	// Ｍ１依頼数量×Ｍ１原単価(隠し)をＭ１原価金額に設定する。
	genkaKin.value = formatComma(ToNumber(unFormatComma(su.value)) * ToNumber(unFormatComma(genka.value)));

	// 合計依頼数量の再計算を行う
	/* 
		Ｍ１依頼数量とＭ１数量(隠し)の差分を取得し、合計依頼数量に加算(減算)する。
		Ｍ１依頼数量(隠し)にＭ１依頼数量を設定する。
	*/
	sumSu.value = formatComma(ToNumber(unFormatComma(sumSu.value)) - (ToNumber(unFormatComma(suHid.value)) - ToNumber(unFormatComma(su.value))));
	// 隠し項目に変更後の数量を再設定
	suHid.value = su.value;

	/*
		Ｍ１原価金額とＭ１原価金額(隠し)の差分を取得し、合計原価金額に加算(減算)する。
		Ｍ１原価金額(隠し)にＭ１原価金額を設定する。
	*/
	sumGenkaKin.value = formatComma(ToNumber(unFormatComma(sumGenkaKin.value)) - (ToNumber(unFormatComma(genkaKinHid.value)) - ToNumber(unFormatComma(genkaKin.value))));

	/*
		モードが申請、申請後取消かつ対象行が選択状態の場合、残金額を計算
	*/
	// モードを取得
	var stkModeNo = getAdvControlFromItemID(clm_StkMode).value;
	// 行の選択状態取得
	var rowselect = getAdvControlFromItemID(clm_M1SentakuFlg, lineNo).checked;
	// 合計残金額
	var sumZankin = ToNumber(unFormatComma(getAdvControlFromItemID("Footer_zan_kin").value));
	// 差分金額
	var sabun = (ToNumber(unFormatComma(genkaKinHid.value)) - ToNumber(unFormatComma(genkaKin.value)));
	// 仕入枠グループコードを取得
	var siireGp = getAdvControlFromItemID("Yosan_cd").value;

	// 申請モード
	if (rowselect && siireGp != "000000") {
		if (stkModeNo == c_modeapply) {
			// チェックされた場合、残金額を減算
			getAdvControlFromItemID("Footer_zan_kin").value = getAdvFormatStr("Footer_zan_kin", sumZankin + sabun);
			// 申請済取消	
		} else if (stkModeNo == c_modesinseizumitorikesi) {
			// チェックされた場合、残金額を加算
			getAdvControlFromItemID("Footer_zan_kin").value = getAdvFormatStr("Footer_zan_kin", sumZankin - sabun);
		}
	}

	// 隠し項目に変更後の数量を再設定
	genkaKinHid.value = genkaKin.value;

}

// 明細項目初期化
function clearRow(lineNo) {
	// 明細項目の初期化
	getAdvControlFromItemID("M1bumonkana_nm", lineNo).value = '';			// 部門カナ名
	getAdvControlFromItemID("M1ten_hyoka_kb", lineNo).value = '';			// 店舗評価区分
	getAdvControlFromItemID("M1all_hyoka_kb", lineNo).value = '';			// 全店評価区分
	getAdvControlFromItemID("M1tenzaiko_su", lineNo).value = '';			// 店在庫数
	getAdvControlFromItemID("M1tosyu_uriage_su", lineNo).value = '';		// 当週売
	getAdvControlFromItemID("M1zensyu_uriage_su", lineNo).value = '';		// 前売
	getAdvControlFromItemID("M1zenzensyu_uriage_su", lineNo).value = '';	// 前々売
	getAdvControlFromItemID("M1hinsyu_ryaku_nm", lineNo).value = '';		// 品種略名称
	getAdvControlFromItemID("M1nyukayotei_su", lineNo).value = '';			// 入荷予定数
	getAdvControlFromItemID("M1burando_nm", lineNo).value = '';			// ブランド名
	getAdvControlFromItemID("M1jido_su", lineNo).value = '';				// 自動定数
	getAdvControlFromItemID("M1keikaku_ymd", lineNo).value = '';			// 計画期間
	getAdvControlFromItemID("M1haibunkano_su", lineNo).value = '';			// 配分可能数
	getAdvControlFromItemID("M1jisya_hbn", lineNo).value = '';				// 自社品番
	getAdvControlFromItemID("M1syohin_zokusei", lineNo).value = '';		// 商品属性
	getAdvControlFromItemID("M1lot_su", lineNo).value = '';				// ロット数
	getAdvControlFromItemID("M1iro_nm", lineNo).value = '';				// 色
	getAdvControlFromItemID("M1size_nm", lineNo).value = '';				// サイズ
	getAdvControlFromItemID("M1maker_hbn", lineNo).value = '';				// メーカー品番
	getAdvControlFromItemID("M1syonmk", lineNo).value = '';				// 商品名(カナ)
	getAdvControlFromItemID("M1hatchu_msg", lineNo).value = '';			// 発注メッセージ
	getAdvControlFromItemID("M1genkakin", lineNo).value = '';				// 原価金額
	getAdvControlFromItemID("M1hanbaikanryo_ymd", lineNo).value = '';		// 販売完了日
	getAdvControlFromItemID("M1gen_tnk", lineNo).value = '';				// 原単価(隠し)
	getAdvControlFromItemID("M1genkakin_hdn", lineNo).value = '';			// 原価金額〈隠し〉
	getAdvControlFromItemID("M1uriage_su_hdn", lineNo).value = '';			// 売上4週分〈隠し〉
}

function tabClickMeisai(cItemID, initialF, textItem, labelItem) {

	var clm_Meisai_Mode = "Meisai_modeno";			// 明細モードNo項目名
	var clm_Meisai_StkMode = "Meisai_stkmodeno";	// 明細選択モードNo項目名

	// 項目名からモードNo取得
	var modeno = getModeNoMeisai(cItemID);
	// モード名を隠し項目へ設定
	getAdvControlFromItemID(clm_Meisai_Mode).value = modeno;

	// 高さ調節関数を呼び出し
	$('.common').adjustHeight();

}
function getModeNoMeisai(cItemID) {
	var modeno = "";
	// 項目名からモードNoを取得
	switch (cItemID.toUpperCase()) {
		case 'Btnmodeyosanjoho'.toUpperCase(): modeno = 'Yosan'; break;			// 新規作成
		case 'Btnmodesiborikomi'.toUpperCase(): modeno = 'Shibori'; break;		// 確定
	}
	return modeno;
}
// 行選択時のイベント
function selectRowAfter(row, check) {
	// モードを取得
	var stkModeNo = getAdvControlFromItemID(clm_StkMode).value;

	// Ｍ１原価金額
	var genkaKin = ToNumber(unFormatComma(getAdvControlFromItemID("M1genkakin", row).value));
	// 合計残金額
	var sumZankin = ToNumber(unFormatComma(getAdvControlFromItemID("Footer_zan_kin").value));

	// 仕入枠グループコードを取得
	var siireGp = getAdvControlFromItemID("Yosan_cd").value;
	if (siireGp == "000000") {
		return;
	}

	// 申請モード
	if (stkModeNo == c_modeapply) {
		if (check) {
			// チェックされた場合、残金額を減算
			getAdvControlFromItemID("Footer_zan_kin").value = getAdvFormatStr("Footer_zan_kin", sumZankin - genkaKin);
		} else {
			// チェックされた場合、残金額を加算
			getAdvControlFromItemID("Footer_zan_kin").value = getAdvFormatStr("Footer_zan_kin", sumZankin + genkaKin);
		}
	// 申請済取消	
	} else if (stkModeNo == c_modesinseizumitorikesi) {
		if (check) {
			// チェックされた場合、残金額を加算
			getAdvControlFromItemID("Footer_zan_kin").value = getAdvFormatStr("Footer_zan_kin", sumZankin + genkaKin);
		} else {
			// チェックされた場合、残金額を減算
			getAdvControlFromItemID("Footer_zan_kin").value = getAdvFormatStr("Footer_zan_kin", sumZankin - genkaKin);
		}
	}
}
