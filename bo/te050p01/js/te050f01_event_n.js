/*-----------------------------------------------------------------------------
	モジュール:te050f01_event_n.js
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
	md_te050f01_register();
	
	//共通ロード設定
	setCommonLoad();
	
    // ----------------------
    // --------------------------
    // BO初期表示共通処理
	boLoadCommon();
	// --------------------------
	// href再設定対応（hrefが消える) --------------------------------  ADD_STR
	document.all.item("Btnmodejishahinban").href = "#tab26";
	document.all.item("Btnmodesonota").href = "#tab28";
	// href再設定対応（hrefが消える) --------------------------------  ADD_END
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
			// エラー時の画面表示対応 --------------------------------  ADD_STR
			getAdvControlFromItemID(clm_StkMode).value = "";
			nonmodeDisp();
			// エラー時の画面表示対応 --------------------------------  ADD_END
			AdvGB_LastClickItemNm = null;
			return false;
		}
	}

	// ここに業務固有チェック処理を記述します。
	switch (AdvGB_LastClickItemNm.toUpperCase()) {
		// 新規作成ボタン
		case "Btninsert".toUpperCase():
			// モードが「自社品番」の場合、メッセージを出力
			if (getAdvControlFromItemID(clm_StkMode).value == c_modejishahinban) {

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
			// モードが「その他」の場合、メッセージを出力
			if (getAdvControlFromItemID(clm_StkMode).value == c_modesonota) {

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
		// タブ処理
		case "BTNMODEJISHAHINBAN":	// 自社品番
			// 入力値クリアの確認メッセージ表示
			var inputItem =
			[
				  [getAdvControlFromItemID("Siiresaki_cd"), ""]
				, [getAdvControlFromItemID("Bumon_cd"), ""]
				, [getAdvControlFromItemID("Burando_cd"), ""]
			];
			var labelItem =
			[
				  [getAdvControlFromItemID("Siiresaki_ryaku_nm"), ""]
				, [getAdvControlFromItemID("Bumon_nm"), ""]
				, [getAdvControlFromItemID("Burando_nm"), ""]
			];
			searchInputClear(eventTargetName, inputItem, labelItem);
			return false;
		case "BTNMODESONOTA":		// その他
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
		case "Siiresaki_cd".toUpperCase():		// 仕入先コード
			// 名称取得部品を起動
			V02002_MAIN(getAdvControlFromItemID("Siiresaki_cd"), getAdvControlFromItemID("Siiresaki_ryaku_nm"), getAdvControlFromItemID("Siiresaki_cd"), 1);
			break;
		case "Bumon_cd".toUpperCase():			// 部門コード
			// 名称取得部品を起動
			V02010_MAIN(getAdvControlFromItemID("Bumon_cd"), getAdvControlFromItemID("Bumon_nm"), getAdvControlFromItemID("Bumon_cd"), 1);
			break;
		case "Burando_cd".toUpperCase():		// ブランドコード
			// 名称取得部品を起動
			V02012_MAIN(getAdvControlFromItemID("Burando_cd"), getAdvControlFromItemID("Burando_nm"), getAdvControlFromItemID("Burando_cd"), 1);
			break;
		case "M1jisya_hbn".toUpperCase():			// 自社品番

			// 明細行番号を取得する
			var lineNo = getItemMNofromCtrl(eventTarget);
			// 操作ありの背景色に変更
			commitColorSet(lineNo);
			// 名称表示
			// 検索条件指定(Key：固定、Value：検索値)
			var condition = {
				"SCAN_CD": getAdvControlFromItemID("M1jisya_hbn", lineNo)	// 自社品番
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
				"HINSYU_RYAKU_NM": getAdvControlFromItemID("M1hinsyu_ryaku_nm", lineNo)		// 品種
				, "HIN_NBR": getAdvControlFromItemID("M1maker_hbn", lineNo)					// メーカー品番
				, "SYONMK": getAdvControlFromItemID("M1syonmk", lineNo)						// 商品名
				, "BUMON_CD": getAdvControlFromItemID("M1bumon_cd", lineNo)					// 部門コード
				, "BURANDO_NMK": formatComma(getAdvControlFromItemID("M1burando_nm", lineNo))	// ブランド名カナ
			};

			// 名称取得部品
			V02003(condition, result, getAdvControlFromItemID("M1jisya_hbn", lineNo), true, lineNo);
			break;
		case "M1iro_cd".toUpperCase():		// 色コード
			// 明細行番号を取得する
			var lineNo = getItemMNofromCtrl(eventTarget);
			// 操作ありの背景色に変更
			commitColorSet(lineNo);
			// 名称取得部品を起動
			V02013(getAdvControlFromItemID("M1iro_cd", lineNo), getAdvControlFromItemID("M1iro_nm", lineNo), getAdvControlFromItemID("M1iro_cd", lineNo));
			break;
		case "M1stop_ymd".toUpperCase():	// 防止期限
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
var bosikigen = "";		// 防止期限退避
var focusLineno = -1;	// フォーカスインした行
function onFocus(ev) {
	var eventTarget=getAdvEventTarget(ev);
	var eventTargetName=getAdvEventTargetName(ev);
	switch (eventTargetName.toUpperCase()) {
		// ここに項目IDのcase文を追加し、固有処理を記述します。
		case "M1stop_ymd".toUpperCase():	// 防止期限
			// 明細行番号を取得する
			var lineNo = getItemMNofromCtrl(eventTarget);
			if (focusLineno != lineNo) {
				// 他の行からフォーカスインした場合

				// フォーカス行を退避
				focusLineno = lineNo;
				// 入力値を退避
				bosikigen = unFormatYmdSrash(getAdvControlFromItemID("M1stop_ymd", lineNo).value);
			} else {
				// 自行からフォーカスインした場合(カレンダーからの設定を想定)
				if (bosikigen != unFormatYmdSrash(getAdvControlFromItemID("M1stop_ymd", lineNo).value)) {
					// 入力値に変更があった場合、操作ありの背景色に変更
					commitColorSet(lineNo);
					// 退避変数初期化
					bosikigen = "";
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
		case "M1jisya_hbn".toUpperCase(): //自社品番
			// 明細行番号を取得する
			var lineNo = getItemMNofromCtrl(eventTarget);
			// 自社品番丸め処理
			formatJisyaHbnCd(getAdvControlFromItemID("M1jisya_hbn", lineNo));
			break;

	default:
		break;
	}
	return onBlur_adv(eventTarget);	//デフォルト処理
}

/*-----------------------------------------------------------------------------
コード参照データセット出口ルーチン処理
-----------------------------------------------------------------------------*/
function onBeforeCodeSet(iDataArray, iItemId, iCodeId) {

	// ボタンID取得
	var itemnm = iItemId;
	// $区切りで名称を分割
	var item = iItemId.split("$");
	if (item.length >= 3) {
		// 明細項目の場合、行番号、項目名を取得
		rowno = ToNumber(item[1].replace("ctl", "")) - 1;
		itemnm = item[2];
	}

	switch (itemnm.toUpperCase()) {
	//  ここに項目IDのcase文を追加し、固有処理を記述します。
		case "M1btnirocd".toUpperCase():	// 色コード検索

			// 操作ありの背景色に変更
			commitColorSet(rowno);
			break;
	default:
		break;
	}
	return iDataArray;
}

