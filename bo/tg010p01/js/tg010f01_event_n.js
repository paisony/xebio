/*-----------------------------------------------------------------------------
	モジュール:tg010f01_event_n.js
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
	md_tg010f01_register();
	
	//共通ロード設定
	setCommonLoad();

	// --------------------------
	// BO初期表示共通処理
	boLoadCommon();
	// --------------------------

	// 品種コード表示制御
	HinsyuControl();


	/* hrefの値が消えてしまうので毎回設定 */
	document.all.item("Btnmodescancd").href = "#tab25";
	document.all.item("Btnmodejishahinban").href = "#tab26";
	document.all.item("Btnmodesonota").href = "#tab28";

	// 部門コードが未入力の場合
	if (getAdvControlFromItemID("Bumon_cd").value == "") {
		// 品種コード検索は非活性（部門コードが入力されたら活性化）
		itemDisabled(getAdvControlFromItemID("Btnhinsyu_cd"), true);
	}
	else {
		itemDisabled(getAdvControlFromItemID("Btnhinsyu_cd"), false);
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
		// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
		// 新規作成ボタン
		case "Btninsert".toUpperCase():

			// 明細が表示されている場合、
			// 確認メッセージを表示
			if ($('.str-wrap-result .str-result-item-01').css('display') == 'block') {
				//// 確認メッセージを表示
				var yes = function () {
					$("#Btninsert")[0].click();
				}
				var no = function () {
				}
				var msg = getMessage("W113", "新規作成");
				return boOpenInfoDialog(msg, yes, no);
			}
			break;
		// 検索ボタン
		case "Btnsearch".toUpperCase():

			// 明細が表示されている場合、
			// 確認メッセージを表示
			if ($('.str-wrap-result .str-result-item-01').css('display') == 'block') {
				//// 確認メッセージを表示
				var yes = function () {
					$("#Btnsearch")[0].click();
				}
				var no = function () {
				}
				var msg = getMessage("W113", "検索");
				return boOpenInfoDialog(msg, yes, no);
			}
			break;

		// シール発行ボタン I103		
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
		// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

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
		case "BTNMODESCANCD":	// スキャンコード
			// モードボタン共通処理
			//vRet = tabClick(eventTargetName.toUpperCase());
			// 入力値クリアの確認メッセージ表示
			prvSerchInputClear(eventTargetName);
			// 新規作成ボタン、検索ボタンの表示非表示
			itemVisible(getAdvControlFromItemID("Btninsert"), true);
			itemVisible(getAdvControlFromItemID("Btnsearch"), false);
			itemVisible(document.getElementById("req1"), true);
			itemVisible(document.getElementById("req2"), false);
			return false;
		case "BTNMODEJISHAHINBAN":	// 自社品番
			// モードボタン共通処理
			//vRet = tabClick(eventTargetName.toUpperCase());
			// 入力値クリアの確認メッセージ表示
			prvSerchInputClear(eventTargetName);
			// 新規作成ボタン、検索ボタンの表示非表示
			itemVisible(getAdvControlFromItemID("Btninsert"), false);
			itemVisible(getAdvControlFromItemID("Btnsearch"), true);
			itemVisible(document.getElementById("req1"), true);
			itemVisible(document.getElementById("req2"), false);
			return false;
		case "BTNMODESONOTA":	// その他
			// モードボタン共通処理
			//vRet = tabClick(eventTargetName.toUpperCase());
			// 入力値クリアの確認メッセージ表示
			prvSerchInputClear(eventTargetName);
			// 新規作成ボタン、検索ボタンの表示非表示
			itemVisible(getAdvControlFromItemID("Btninsert"), false);
			itemVisible(getAdvControlFromItemID("Btnsearch"), true);
			itemVisible(document.getElementById("req1"), false);
			itemVisible(document.getElementById("req2"), true);
			return false;

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
		case "Bumon_cd".toUpperCase():	// 部門コード
			// 名称取得部品を起動
			// 部門コードが未入力の場合、品種コードボタン非活性
			if (getAdvControlFromItemID("Bumon_cd").value != "") {
				itemDisabled(getAdvControlFromItemID("Btnhinsyu_cd"), false);
			} else {
				itemDisabled(getAdvControlFromItemID("Btnhinsyu_cd"), true);
			}
			V02010_MAIN(getAdvControlFromItemID("Bumon_cd"), getAdvControlFromItemID("Bumon_nm"), getAdvControlFromItemID("Bumon_cd"), 1);
			break;
		case "Hinsyu_cd".toUpperCase():	// 品種コード
			// 名称取得部品を起動
			V02011_MAIN(getAdvControlFromItemID("Bumon_cd"), getAdvControlFromItemID("Hinsyu_cd"), getAdvControlFromItemID("Hinsyu_ryaku_nm"), getAdvControlFromItemID("Hinsyu_cd"), null, 1);
			break;
		case "Burando_cd".toUpperCase():		// ブランドコード
			// 名称取得部品を起動
			V02012_MAIN(getAdvControlFromItemID("Burando_cd"), getAdvControlFromItemID("Burando_nm"), getAdvControlFromItemID("Burando_cd"), 1);
			break;
		case "Old_jisya_hbn".toUpperCase():	// 自社品番
			// 検索条件指定(Key：固定、Value：検索値)
			var condition = {
				"SCAN_CD": getAdvControlFromItemID("Old_jisya_hbn")		// 自社品番コード
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
			var result = null;
			// 名称取得部品を起動
			V02003(condition, result, getAdvControlFromItemID("Old_jisya_hbn"), false, null);
			break;
		case "Old_jisya_hbn2".toUpperCase():	// 自社品番2
			// 検索条件指定(Key：固定、Value：検索値)
			var condition = {
				"SCAN_CD": getAdvControlFromItemID("Old_jisya_hbn2")		// 自社品番コード
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
			// 名称取得部品を起動
			V02003(condition, null, getAdvControlFromItemID("Old_jisya_hbn2"), false, null);
			break;
		case "Old_jisya_hbn3".toUpperCase():	// 自社品番3
			// 検索条件指定(Key：固定、Value：検索値)
			var condition = {
				"SCAN_CD": getAdvControlFromItemID("Old_jisya_hbn3")		// 自社品番コード
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
			// 名称取得部品を起動
			V02003(condition, null, getAdvControlFromItemID("Old_jisya_hbn3"), false, null);
			break;
		case "Old_jisya_hbn4".toUpperCase():	// 自社品番4
			// 検索条件指定(Key：固定、Value：検索値)
			var condition = {
				"SCAN_CD": getAdvControlFromItemID("Old_jisya_hbn4")		// 自社品番コード
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
			// 名称取得部品を起動
			V02003(condition, null, getAdvControlFromItemID("Old_jisya_hbn4"), false, null);
			break;
		case "Old_jisya_hbn5".toUpperCase():	// 自社品番5
			// 検索条件指定(Key：固定、Value：検索値)
			var condition = {
				"SCAN_CD": getAdvControlFromItemID("Old_jisya_hbn5")		// 自社品番コード
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
			// 名称取得部品を起動
			V02003(condition, null, getAdvControlFromItemID("Old_jisya_hbn5"), false, null);
			break;
		case "M1scan_cd".toUpperCase():
			// 明細行番号を取得する
			var lineNo = getItemMNofromCtrl(eventTarget);
			// スキャンコード丸め処理
			formatScanCd(getAdvControlFromItemID("M1scan_cd", lineNo));
			// 操作ありの背景色に変更
			commitColorSet(lineNo);
			// 名称表示
			// 検索条件指定(Key：固定、Value：検索値)
			var condition = {
				"SCAN_CD": getAdvControlFromItemID("M1scan_cd", lineNo)	// スキャンコード
				, "TENPO_CD": getAdvControlFromItemID("Head_tenpo_cd")		// 店舗コード
				, "PLUFLG": "1"												// 店別単価マスタ	検索フラグ 0:検索しない 1:検索する
				, "PRICEFLG": "1"											// 売変				検索フラグ 0:検索しない 1:検索する
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
				"BUMON_CD": getAdvControlFromItemID("M1bumon_cd", lineNo)						// Ｍ１部門コード
				, "BUMONKANA_NM": getAdvControlFromItemID("M1bumonkana_nm", lineNo)			// Ｍ１部門カナ名
				, "HINSYU_CD": getAdvControlFromItemID("M1hinsyu_cd", lineNo)					// Ｍ１品種コード
				, "HINSYU_RYAKU_NM": getAdvControlFromItemID("M1hinsyu_ryaku_nm", lineNo)		// Ｍ１品種略名称
				, "BURANDO_NMK": getAdvControlFromItemID("M1burando_nm", lineNo)				// Ｍ１ブランド名
				, "XEBIO_CD": getAdvControlFromItemID("M1jisya_hbn", lineNo)					// Ｍ１自社品番
				, "HIN_NBR": getAdvControlFromItemID("M1maker_hbn", lineNo)					// Ｍ１メーカー品番
				, "SYONMK": getAdvControlFromItemID("M1syonmk", lineNo)						// Ｍ１商品名(カナ)
				, "IRO_NM": getAdvControlFromItemID("M1iro_nm", lineNo)						// Ｍ１色
				, "SIZE_NM": getAdvControlFromItemID("M1size_nm", lineNo)						// Ｍ１サイズ
				, "HANBAIKANRYO_YMD": getAdvControlFromItemID("M1hanbaikanryo_ymd", lineNo)	// Ｍ１販売完了日
				, "BAIHENKAISI_YMD": getAdvControlFromItemID("M1baihenkaisi_ymd", lineNo)		// Ｍ１売変開始日
				, "SIJIBAIKA_TNK": getAdvControlFromItemID("M1sijibaika_tnk", lineNo)			// Ｍ１指示売価
				, "BAIKA": getAdvControlFromItemID("M1saisinbaika_tnk", lineNo)					// Ｍ１最新売価
				, "ITEMKBN": getAdvControlFromItemID("M1itemkbn", lineNo)						// Ｍ１商品区分(隠し)
				, "SIIRE_KB": getAdvControlFromItemID("M1siire_kb", lineNo)					// Ｍ１仕入区分(隠し)
				, "TYOTATSU_KB": getAdvControlFromItemID("M1tyotatsu_kb", lineNo)				// Ｍ１調達区分(隠し)
				, "JODAI2_TNK": getAdvControlFromItemID("M1makerkakaku_tnk", lineNo)			// Ｍ１メーカー希望小売価格（隠し）
				, "": getAdvControlFromItemID("M1baika_zei", lineNo)							// Ｍ１税込価格（隠し）
				, "BURANDO_CD": getAdvControlFromItemID("M1burando_cd", lineNo)				// Ｍ１ブランドコード（隠し）
				, "BUMON_NM": getAdvControlFromItemID("M1bumon_nm", lineNo)					// Ｍ１部門名全角（隠し）
				, "SIIRESAKI_CD": getAdvControlFromItemID("M1siiresaki_cd_bo1", lineNo)		// Ｍ１仕入先コード（隠し）
			};

			// 名称取得部品
			V02004(condition, result, getAdvControlFromItemID("M1scan_cd", lineNo), true, lineNo);

			// M1枚数が未入力の場合、1を設定
			if (getAdvControlFromItemID("M1maisu", lineNo).value == "")
			{
				getAdvControlFromItemID("M1maisu", lineNo).value = 1;
			}
			break;
		case "M1maisu".toUpperCase():
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
		case "Old_jisya_hbn".toUpperCase(): //自社品番
			// 自社品番丸め処理
			formatJisyaHbnCd(getAdvControlFromItemID("Old_jisya_hbn"));
			break;
		case "Old_jisya_hbn2".toUpperCase(): //自社品番
			// 自社品番丸め処理
			formatJisyaHbnCd(getAdvControlFromItemID("Old_jisya_hbn2"));
			break;
		case "Old_jisya_hbn3".toUpperCase(): //自社品番
			// 自社品番丸め処理
			formatJisyaHbnCd(getAdvControlFromItemID("Old_jisya_hbn3"));
			break;
		case "Old_jisya_hbn4".toUpperCase(): //自社品番
			// 自社品番丸め処理
			formatJisyaHbnCd(getAdvControlFromItemID("Old_jisya_hbn4"));
			break;
		case "Old_jisya_hbn5".toUpperCase(): //自社品番
			// 自社品番丸め処理
			formatJisyaHbnCd(getAdvControlFromItemID("Old_jisya_hbn5"));
			break;
		case "M1scan_cd".toUpperCase():	// Ｍ１スキャンコード
			// 明細行番号を取得する
			var lineNo = getItemMNofromCtrl(eventTarget);
			// スキャンコード丸め処理
			formatScanCd(getAdvControlFromItemID("M1scan_cd", lineNo));
			break;
		case "Bumon_cd".toUpperCase():	// 部門コード
			// 品種コード表示制御
			HinsyuControl();
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
// モード変更確認メッセージ表示時のNOアクション
function tabClick_NoAction(tabnm) {
	switch (tabnm.toUpperCase()) {
		// ここに項目IDのcase文を追加し、固有処理を記述します。
		case "BTNMODESCANCD":
	
			itemVisible(getAdvControlFromItemID("Btninsert"), true);
			itemVisible(getAdvControlFromItemID("Btnsearch"), false);
			itemVisible(document.getElementById("req1"), true);
			itemVisible(document.getElementById("req2"), false);
			return false;
		case "BTNMODEJISHAHINBAN":
			itemVisible(getAdvControlFromItemID("Btninsert"), false);
			itemVisible(getAdvControlFromItemID("Btnsearch"), true);
			itemVisible(document.getElementById("req1"), true);
			itemVisible(document.getElementById("req2"), false);
			return false;
		case "BTNMODESONOTA":
			// 新規作成ボタン、検索ボタンの表示非表示
			itemVisible(getAdvControlFromItemID("Btninsert"), false);
			itemVisible(getAdvControlFromItemID("Btnsearch"), true);
			itemVisible(document.getElementById("req1"), false);
			itemVisible(document.getElementById("req2"), true);
			return false;
		default:
			break;
	}

}

// スキャンコード名称取得の出口ルーチン
function responseHandle_onAfter(lineNo) {

	// フォーマット処理

	// 部門コード
	var bumon_cd = getAdvControlFromItemID("M1bumon_cd", lineNo);
	bumon_cd.value = getAdvFormatStr("M1bumon_cd", bumon_cd.value);

	// 品種コード
	var hinsyu_cd = getAdvControlFromItemID("M1hinsyu_cd", lineNo);
	hinsyu_cd.value = getAdvFormatStr("M1hinsyu_cd", hinsyu_cd.value);

	// 販売完了日
	var hanbaikanryo_ymd  = getAdvControlFromItemID("M1hanbaikanryo_ymd", lineNo);
	hanbaikanryo_ymd.value = getAdvFormatStr("M1hanbaikanryo_ymd", hanbaikanryo_ymd.value);

	// 売変完了日
	var baihenkaisi_ymd = getAdvControlFromItemID("M1baihenkaisi_ymd", lineNo);
	baihenkaisi_ymd.value = getAdvFormatStr("M1baihenkaisi_ymd", baihenkaisi_ymd.value);

	// 指示売価
	var sijibaika_tnk = getAdvControlFromItemID("M1sijibaika_tnk", lineNo);
	sijibaika_tnk.value = getAdvFormatStr("M1sijibaika_tnk", sijibaika_tnk.value);

	// 最新売価
	var saisinbaika_tnk = getAdvControlFromItemID("M1saisinbaika_tnk", lineNo);
	saisinbaika_tnk.value = getAdvFormatStr("M1saisinbaika_tnk", saisinbaika_tnk.value);

}

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

// 検索条件クリア
function prvSerchInputClear(eventTargetName) {
	// 入力値クリアの確認メッセージ表示
	if (getAdvControlFromItemID(clm_Mode).value == c_modejishahinban) {
		// 入力値クリアの確認メッセージ表示
		var inputItem =
		[
			  [getAdvControlFromItemID("Old_jisya_hbn"), ""]
			, [getAdvControlFromItemID("Old_jisya_hbn2"), ""]
			, [getAdvControlFromItemID("Old_jisya_hbn3"), ""]
			, [getAdvControlFromItemID("Old_jisya_hbn4"), ""]
			, [getAdvControlFromItemID("Old_jisya_hbn5"), ""]
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
		];
		var labelItem =
		[
			  [getAdvControlFromItemID("Bumon_nm"), ""]
			, [getAdvControlFromItemID("Hinsyu_ryaku_nm"), ""]
			, [getAdvControlFromItemID("Burando_nm"), ""]
		];
		searchInputClear(eventTargetName, inputItem, labelItem);
	} else {
		vRet = tabClick(eventTargetName.toUpperCase());
	}
}
