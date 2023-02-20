/*-----------------------------------------------------------------------------
	モジュール:ta080f01_event_n.js
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
	// 依頼理由制御
	iraiRiyuControl();

	//md共通処理ロード処理
	md_ta080f01_register();
	
	//共通ロード設定
	setCommonLoad();

	// BO初期表示共通処理
	boLoadCommon();
	
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
			// [選択モードNo]が「申請」「申請取消」の場合、ダイヤログ表示を行う。
			if (getAdvControlFromItemID(clm_StkMode).value == c_modeapply
			 || getAdvControlFromItemID(clm_StkMode).value == c_modesinseizumitorikesi) {

				// 確認メッセージを表示
				var yes = function () {
					$("#Btninsert")[0].click();
				}
				var no = function () { }
				var msg = getMessage("W113", "新規作成");
				return boOpenInfoDialog(msg, yes, no);
			}

			break;
		// 検索ボタン
		case "Btnsearch".toUpperCase():
			// [選択モードNo]が「申請」「取消」の場合、ダイヤログ表示を行う。
			if (getAdvControlFromItemID(clm_StkMode).value == c_modeapply
			 || getAdvControlFromItemID(clm_StkMode).value == c_modesinseizumitorikesi) {

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
		case "BTNMODEAPPLY":
		case "BTNMODESINSEIMAESYUSEI":
		case "BTNMODESINSEIZUMITORIKESI":
		case "BTNMODEREF_TOROKURIREKI":
		case "BTNMODEREF_RINGIKEKKA":
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

		// -------------------
		// ヘッダ店舗コード
		// -------------------
		case "Head_tenpo_cd".toUpperCase():
			// 名称取得部品を起動 V02001			
			V02001(getAdvControlFromItemID("Head_tenpo_cd"), getAdvControlFromItemID("Head_tenpo_nm"), getAdvControlFromItemID("Head_tenpo_cd"));
			break;

		// -------------------
		// 仕入枠グループコードFROM
		// -------------------
		case "Yosan_cd_from".toUpperCase():	
			// 名称取得部品を起動 V02028
			V02028(getAdvControlFromItemID("Yosan_cd_from"), getAdvControlFromItemID("Yosan_nm_from"), null, 0);
			break;

		// -------------------
		// 仕入枠グループコードTO
		// -------------------
		case "Yosan_cd_to".toUpperCase():	 	
			// 名称取得部品を起動 V02028
			V02028(getAdvControlFromItemID("Yosan_cd_to"), getAdvControlFromItemID("Yosan_nm_to"), null, 0);
			break;

		// -------------------
		// 登録担当者コード
		// -------------------
		case "Tantosya_cd".toUpperCase():
			// 名称取得部品を起動 V02005
			V02005_MAIN(getAdvControlFromItemID("Tantosya_cd"), getAdvControlFromItemID("Hanbaiin_nm"), getAdvControlFromItemID("Tantosya_cd"), 0);
			break;

		// -------------------
		// 申請種別
		// -------------------
		case "Sinsei_sb".toUpperCase():
			iraiRiyuControl();
				
			break;

		// -------------------
		// 自社品番
		// -------------------
		case "Old_jisya_hbn".toUpperCase():
			// 名称表示
			// 検索条件指定(Key：固定、Value：検索値)
			var condition = {
				"SCAN_CD": getAdvControlFromItemID("Old_jisya_hbn")			// 自社品番コード
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

		// -------------------
		// スキャンコード
		// -------------------
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
		case "Yosan_ymd_from".toUpperCase():		 // 年月度FROM
			// 年月度TOが空白の場合、年月度FROM内容をコピー
			fromToCopy("Yosan_ymd");
			break;
		case "Yosan_cd_from".toUpperCase():	 		// 仕入枠グループコードFROM
			// 仕入枠グループTOが空白の場合、仕入枠グループコードFROM内容をコピー
			fromToCopy("Yosan_cd");
			break;
		case "Add_ymd_from".toUpperCase():		 	// 登録日FROM
			// 登録日TOが空白の場合、登録日FROM内容をコピー
			fromToCopy("Add_ymd");
			break;
		case "Apply_ymd_from".toUpperCase():	 	// 申請日FROM
			fromToCopy("Apply_ymd");
			break;
		case "Old_jisya_hbn".toUpperCase():			// 自社品番
			formatJisyaHbnCd(getAdvControlFromItemID("Old_jisya_hbn"));
			break;
		case "Scan_cd".toUpperCase():				// スキャンコード
			// スキャンコード丸め処理
			formatScanCd(getAdvControlFromItemID("Scan_cd"));
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


/*----------

----------*/
function iraiRiyuControl() {
	// 申請種別が空白、仕入稟議の場合、依頼理由コードはDisabled。
	// -1:空白／11:店舗補充／20:単品レポート／02:仕入稟議
	switch (getAdvControlFromItemID("Sinsei_sb").value) {
		case "-1":// 空白
		case "02":// 仕入稟議
			// 依頼理由		：   表示 非活性 空白設定
			itemDisabled(getAdvControlFromItemID("Irairiyu_cd"), false);
			itemVisible(getAdvControlFromItemID("Irairiyu_cd"), true);
			$(getAdvControlFromItemID("Irairiyu_cd")).width(140);
			$(getAdvControlFromItemID("Irairiyu_cd")).height(26);
			getAdvControlFromItemID("Irairiyu_cd").value = '-1'
			// 依頼理由1	： 非表示   －   空白設定
			itemDisabled(getAdvControlFromItemID("Irairiyu_cd"), true);
			itemVisible(getAdvControlFromItemID("Irairiyu_cd1"), false);
			$(getAdvControlFromItemID("Irairiyu_cd1")).width(0);
			$(getAdvControlFromItemID("Irairiyu_cd1")).height(0);
			getAdvControlFromItemID("Irairiyu_cd1").value = '-1'
			break;
		case "11":// 店舗補充
			// 依頼理由		：   表示   活性   －
			itemVisible(getAdvControlFromItemID("Irairiyu_cd"), true);
			itemDisabled(getAdvControlFromItemID("Irairiyu_cd"), false);
			$(getAdvControlFromItemID("Irairiyu_cd")).width(140);
			$(getAdvControlFromItemID("Irairiyu_cd")).height(26);
			// 依頼理由1	： 非表示   －   空白設定
			itemVisible(getAdvControlFromItemID("Irairiyu_cd1"), false);
			$(getAdvControlFromItemID("Irairiyu_cd1")).width(0);
			$(getAdvControlFromItemID("Irairiyu_cd1")).height(0);
			getAdvControlFromItemID("Irairiyu_cd1").value = '-1'
			break;
		case "20":// 単品レポート
			// 依頼理由		： 非表示   －   空白設定
			itemVisible(getAdvControlFromItemID("Irairiyu_cd"), false);
			//itemDisabled(getAdvControlFromItemID("Irairiyu_cd"), true);
			$(getAdvControlFromItemID("Irairiyu_cd")).width(0);
			$(getAdvControlFromItemID("Irairiyu_cd")).height(0);
			getAdvControlFromItemID("Irairiyu_cd").value = '-1'
			// 依頼理由1	：   表示   活性   －
			itemVisible(getAdvControlFromItemID("Irairiyu_cd1"), true);
			itemDisabled(getAdvControlFromItemID("Irairiyu_cd1"), false);
			$(getAdvControlFromItemID("Irairiyu_cd1")).width(140);
			$(getAdvControlFromItemID("Irairiyu_cd1")).height(26);
//			getAdvControlFromItemID("Irairiyu_cd1").value = '-1'

			break;
		default:
			break;

	}
}

