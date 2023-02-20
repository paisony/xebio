/*-----------------------------------------------------------------------------
	モジュール:ta070f01_event_n.js
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
	md_ta070f01_register();
	
	//共通ロード設定
	setCommonLoad();
	
	// ----------------------
	// --------------------------
	// BO初期表示共通処理
	boLoadCommon();
	// --------------------------

	// 品種コード表示制御
	HinsyuControl();

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
		// 新規作成ボタン
		case "Btninsert".toUpperCase():
			// [選択モードNo]が「照会」以外の場合、メッセージを出力
			if (getAdvControlFromItemID(clm_StkMode).value != c_moderef
			 && getAdvControlFromItemID(clm_StkMode).value != "") {

				// 確認メッセージを表示
				var yes = function () {
				$("#Btninsert")[0].click();
				}
				var no = function () {}
				var msg = getMessage("W113", "新規作成");
				return boOpenInfoDialog(msg, yes, no);
			}
			break;
		// 検索ボタン
		case "Btnsearch".toUpperCase():
			// [選択モードNo]が「照会」以外の場合、メッセージを出力
			if (getAdvControlFromItemID(clm_StkMode).value != c_moderef
			 && getAdvControlFromItemID(clm_StkMode).value != "") {

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
			return boOpenInfoDialog(msg, yes, no);
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
		case "BTNMODEREF":
		case "BTNMODEUPD":
		case "BTNMODEDEL":
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
		case "Bumon_cd".toUpperCase():	// 部門コード
			// 名称取得部品を起動
			V02010_MAIN(getAdvControlFromItemID("Bumon_cd"), getAdvControlFromItemID("Bumon_nm"), getAdvControlFromItemID("Bumon_cd"), 0);

			break;
		case "Hinsyu_cd".toUpperCase():	// 品種コード
			// 名称取得部品を起動
			V02011_MAIN(getAdvControlFromItemID("Bumon_cd"), getAdvControlFromItemID("Hinsyu_cd"), getAdvControlFromItemID("Hinsyu_ryaku_nm"), getAdvControlFromItemID("Hinsyu_cd"), null, 0);
			break;
		case "Burando_cd".toUpperCase():		// ブランドコード
			// 名称取得部品を起動
			V02012_MAIN(getAdvControlFromItemID("Burando_cd"), getAdvControlFromItemID("Burando_nm_bo1"), getAdvControlFromItemID("Burando_cd"), 0);
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

		// --------------------------------------------
		// Ｍ１スキャンコード
		// --------------------------------------------
		case "M1scan_cd".toUpperCase():
			// 明細行番号を取得する
			var lineNo = getItemMNofromCtrl(eventTarget);
			// 操作ありの背景色に変更
			commitColorSet(lineNo);
			// 名称表示
			// 検索条件指定(Key：固定、Value：検索値)
			var condition = {
				 "SCAN_CD"			: getAdvControlFromItemID("M1scan_cd", lineNo)	// スキャンコード
				,"TENPO_CD"			: getAdvControlFromItemID("Head_tenpo_cd")		// 店舗コード
				,"PLUFLG"			: "0"											// 店別単価マスタ	検索フラグ 0:検索しない 1:検索する
				,"PRICEFLG"			: "0"											// 売変				検索フラグ 0:検索しない 1:検索する
				,"ZAIKOFLG"			: "0"											// 店在庫			検索フラグ 0:検索しない 1:検索する
				,"NYUKAFLG"			: "0"											// 入荷予定数		検索フラグ 0:検索しない 1:検索する
				,"URIFLG"			: "1"											// 売上実績数		検索フラグ 0:検索しない 1:検索する
				,"HOJUFLG"			: "0"											// 依頼集計数(補充)	検索フラグ 0:検索しない 1:検索する
				,"TANPINFLG"		: "0"											// 依頼集計数(単品)	検索フラグ 0:検索しない 1:検索する
				,"SIJIFLG"			: "0"											// 指示検索			検索フラグ 0:検索しない 1:出荷指示、2:返品指示
				,"SIJI_NO"			: "0"											// 指示NO（移動出荷マニュアル、返品マニュアル用）
				,"SYUKAKAISYA_CD"	: "0"											// 出荷会社コード（移動出荷マニュアル)
				,"NYUKAKAISYA_CD"	: "0"											// 入荷会社コード（移動出荷マニュアル)
				,"SYUKATENPO_CD"	: "0"											// 指示店舗コード（移動出荷マニュアル、返品マニュアル用）
			};
			// 戻り値指定(Key：SELECT句、Value：項目名)
			var result = {
				 "BUMON_CD": getAdvControlFromItemID("M1bumon_cd", lineNo)							// Ｍ１部門コード
				,"BUMONKANA_NM": getAdvControlFromItemID("M1bumonkana_nm", lineNo)					// Ｍ１部門カナ名
				,"HINSYU_RYAKU_NM": getAdvControlFromItemID("M1hinsyu_ryaku_nm", lineNo)			// Ｍ１品種略名称
				,"BURANDO_NMK": getAdvControlFromItemID("M1burando_nm_bo1", lineNo)				// Ｍ１ブランド名＿ＢＯ１
				,"HIN_NBR": getAdvControlFromItemID("M1maker_hbn", lineNo)							// Ｍ１メーカー品番
				,"XEBIO_CD": getAdvControlFromItemID("M1jisya_hbn", lineNo)						// Ｍ１自社品番
				,"SYOHIN_ZOKUSEI": getAdvControlFromItemID("M1syohin_zokusei", lineNo)				// Ｍ１商品属性
				,"IRO_NM": getAdvControlFromItemID("M1iro_nm", lineNo)								// Ｍ１色
				,"SIZE_NM": getAdvControlFromItemID("M1size_nm", lineNo)							// Ｍ１サイズ
				,"SYONMK": getAdvControlFromItemID("M1syonmk", lineNo)								// Ｍ１商品名(カナ)
				,"JIDOTESU_KAISI_YMD": getAdvControlFromItemID("M1kaisi_ymd", lineNo)				// Ｍ１開始日
				,"JIDOTESU_SYURYO_YMD": getAdvControlFromItemID("M1syuryo_ymd", lineNo)			// Ｍ１終了日
				,"HATTYUPTN_NM": getAdvControlFromItemID("M1hattyuptn_kbn", lineNo)				// Ｍ１発注パターン区分名
				,"JIDO_KBN_NM": getAdvControlFromItemID("M1jido_kbnnm", lineNo)					// Ｍ１自動区分名称
				,"URI_SU": getAdvControlFromItemID("M1uriage_su", lineNo)							// Ｍ１売上数	←　売上実績数
				,"JIDO_SU": getAdvControlFromItemID("M1genzaisettei_su", lineNo)					// Ｍ１現在設定数	←　自動定数
				,"LOT_SU": getAdvControlFromItemID("M1lot_su", lineNo)								// Ｍ１ロット数
				,"JIDOTESU_UPD_TANNM": getAdvControlFromItemID("M1hanbaiin_nm", lineNo)			// Ｍ１担当者名
				,"JIDOTESU_UPD_YMD": getAdvControlFromItemID("M1add_ymd", lineNo)	// Ｍ１登録日	←　自動定数マスタ 更新日
				,"JIDOTESU_ADD_NM": getAdvControlFromItemID("M1honbutenpokbnnm", lineNo)			// Ｍ１本部店舗区分名称		← 登録区分名
			};

			// 名称取得部品
			V02004(condition, result, getAdvControlFromItemID("M1scan_cd", lineNo), true, lineNo);

			break;
		case "M1kaisi_ymd".toUpperCase():			// Ｍ１開始日
		case "M1syuryo_ymd".toUpperCase():			// Ｍ１終了日
		case "M1henko_irai_su".toUpperCase():		// Ｍ１変更依頼数量
		case "M1irairiyu_cd".toUpperCase():			// Ｍ１依頼理由コード
		
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
		case "Bumon_cd".toUpperCase():	// 部門コード
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
var kaishiymd = "";		// 開始日
var syuryoymd = "";		// 終了日
var focusLineno = -1;	// フォーカスインした行
function onFocus(ev) {
	var eventTarget=getAdvEventTarget(ev);
	var eventTargetName=getAdvEventTargetName(ev);
	switch (eventTargetName.toUpperCase()) {
		// ここに項目IDのcase文を追加し、固有処理を記述します。
		case "M1kaisi_ymd".toUpperCase():	// 開始日
			// 明細行番号を取得する
			var lineNo = getItemMNofromCtrl(eventTarget);
			if (focusLineno != lineNo) {
				// 他の行からフォーカスインした場合

				// フォーカス行を退避
				focusLineno = lineNo;
				// 入力値を退避
				kaishiymd = unFormatYmdSrash(getAdvControlFromItemID(eventTargetName, lineNo).value);
			} else {
				// 自行からフォーカスインした場合(カレンダーからの設定を想定)
				if (kaishiymd != unFormatYmdSrash(getAdvControlFromItemID(eventTargetName, lineNo).value)) {
					// 入力値に変更があった場合、操作ありの背景色に変更
					commitColorSet(lineNo);
					// 退避変数初期化
					kaishiymd = "";
					focusLineno = -1;
				}
			}
			break;
		case "M1syuryo_ymd".toUpperCase():	// 終了日
			// 明細行番号を取得する
			var lineNo = getItemMNofromCtrl(eventTarget);
			if (focusLineno != lineNo) {
				// 他の行からフォーカスインした場合

				// フォーカス行を退避
				focusLineno = lineNo;
				// 入力値を退避
				syuryoymd = unFormatYmdSrash(getAdvControlFromItemID(eventTargetName, lineNo).value);
			} else {
				// 自行からフォーカスインした場合(カレンダーからの設定を想定)
				if (syuryoymd != unFormatYmdSrash(getAdvControlFromItemID(eventTargetName, lineNo).value)) {
					// 入力値に変更があった場合、操作ありの背景色に変更
					commitColorSet(lineNo);
					// 退避変数初期化
					syuryoymd = "";
					focusLineno = -1;
				}
			}
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
		case "Scan_cd".toUpperCase():	// スキャンコード
			// スキャンコード丸め処理
			formatScanCd(getAdvControlFromItemID("Scan_cd"));
			break;
		case "Old_jisya_hbn".toUpperCase(): //自社品番
			// 自社品番丸め処理
			formatJisyaHbnCd(getAdvControlFromItemID("Old_jisya_hbn"));
			break;
		case "M1scan_cd".toUpperCase():	// Ｍ１スキャンコード
			// 明細行番号を取得する
			var lineNo = getItemMNofromCtrl(eventTarget);
			// スキャンコード丸め処理
			formatScanCd(getAdvControlFromItemID("M1scan_cd", lineNo));
			break;
		case "Bumon_cd".toUpperCase():	// 部門コード
			// 品種コード表示制御
			getAdvControlFromItemID("Hinsyu_cd").value = "";
			getAdvControlFromItemID("Hinsyu_ryaku_nm").value = "";
			HinsyuControl();
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

	// フォーマット処理
	// 売上実績数
	Obj = getAdvControlFromItemID("M1uriage_su", lineNo);
	Obj.value = getAdvFormatStr("M1uriage_su", Obj.value);
	// 現在設定数
	Obj = getAdvControlFromItemID("M1genzaisettei_su", lineNo);
	Obj.value = getAdvFormatStr("M1genzaisettei_su", Obj.value);
	// 変更依頼数量
	Obj = getAdvControlFromItemID("M1henko_irai_su", lineNo);
	Obj.value = getAdvFormatStr("M1henko_irai_su", Obj.value);

	// Ｍ１開始日
	var StartYmd = getAdvControlFromItemID("M1kaisi_ymd", lineNo);
	StartYmd.value = getAdvFormatStr("M1kaisi_ymd", StartYmd.value);
	// Ｍ１終了日
	var EndYmd = getAdvControlFromItemID("M1syuryo_ymd", lineNo);
	EndYmd.value = getAdvFormatStr("M1syuryo_ymd", EndYmd.value);
	// Ｍ１登録日
	var addYmd = getAdvControlFromItemID("M1add_ymd", lineNo);
	addYmd.value = uFormatAddymd(addYmd.value);

}
function uFormatAddymd(val) {
	var rtn = val;

	if (rtn != "") {
		if (rtn.length == 8) {
			rtn = val.substr(2, 6);
		}
	}
	return rtn
}
// 品種コードの表示制御を行う
function HinsyuControl() {
	// 部門コードが未設定の場合
	if (getAdvControlFromItemID("Bumon_cd").value == "") {
		// 品種コードを使用不可
		itemDisabled(getAdvControlFromItemID("Hinsyu_cd"), true);
	} else {
		// 品種コードを使用可
		itemDisabled(getAdvControlFromItemID("Hinsyu_cd"), false);
	}
}
