// タブ選択処理
// ※「initialF, textItem, labelItem」は検索条件を初期化する場合のみ指定
function tabClick(cItemID, initialF, textItem, labelItem) {

	// 項目名からモードNo取得
	var modeno = getModeNo(cItemID);

	// 高さ調節関数を呼び出し
	$('.common').adjustHeight();

	// 選択モードNoが設定されている場合かつモードNoと選択モードNoが同一でない場合
	var stkModeNo = getAdvControlFromItemID(clm_StkMode).value;
	if (stkModeNo != null && stkModeNo != "" && modeno != stkModeNo) {
		// 確認メッセージを表示
		var yes = function () {
			// モードNoを隠し項目へ設定
			getAdvControlFromItemID(clm_Mode).value = modeno;
			// 選択モードNoを空白に設定する。
			getAdvControlFromItemID(clm_StkMode).value = "";
			// 検索条件初期化
			if (initialF) {
				// 入力項目処理化
				for (i = 0; i < textItem.length; i++) {
					inputInitialSet(textItem[i][0], textItem[i][1]);
				}
				// ラベル項目初期化
				for (i = 0; i < labelItem.length; i++) {
					labelItem[i][0].value = labelItem[i][1];
				}
				// ユーザ定義関数を起動
				if (typeof tabClick_YesAction == "function") {
					tabClick_YesAction(getTabNm(getAdvControlFromItemID(clm_Mode).value));
				}
			}
			// モードなし時の表示制御
			nonmodeDisp();
		}

		var no = function () {
			if (getAdvControlFromItemID(clm_StkMode).value != "" && getTabNm(getAdvControlFromItemID(clm_StkMode).value) != "") {

				var itemnm = "";

				if (getAdvControlFromItemID(clm_StkMode).value == c_insert) {
					// 新規作成モードの場合、左端のモードをアクティブにする
					var tagList = $(".str-tab-menu ul li a");
					if (tagList.length != 0) {
						itemnm = '#' + getTabNm(String(getModeNo(tagList[0].id)));
					}
				} else {
					itemnm = '#' + getTabNm(getAdvControlFromItemID(clm_StkMode).value);
				}

				$(".str-tab-cont").hide();
				$($(itemnm).attr("href")).toggle();
				// タブのアクティブクラスを初期化
				$(".str-tab-menu ul li a").removeClass("search-tab-active");
				// 元のタブをアクティブに設定
				$(itemnm).toggleClass("search-tab-active");
				// 各画面にてNoアクションが定義されている場合、実行する。
				if (typeof tabClick_NoAction == "function") {
					tabClick_NoAction(getTabNm(getAdvControlFromItemID(clm_StkMode).value));
				}
			}
		}
		var msg = getMessage("I109");

		return boOpenInfoDialog(msg, yes, no);

	} else {
		// モードNoを隠し項目へ設定
		getAdvControlFromItemID(clm_Mode).value = modeno;
	}

}

// タブ項目名取得処理
function getModeNo(cItemID) {
	var modeno = "";
	// 項目名からモードNoを取得
	switch (cItemID.toUpperCase()) {
		case 'BTNINSERT': modeno = Number(c_insert); break;								// 新規作成
		case 'BTNMODEKAKUTEI': modeno = Number(c_modekakutei); break;					// 確定
		case 'BTNMODENYUKAKAKUTEI': modeno = Number(c_modenyukakakutei); break;			// 入荷確定
		case 'BTNMODESIIREKAKUTEI': modeno = Number(c_modesiirekakutei); break;			// 仕入確定
		case 'BTNMODEHENPINKAKUTEI': modeno = Number(c_modehenpinkakutei); break;		// 返品確定
		case 'BTNMODEAPPLY': modeno = Number(c_modeapply); break;						// 申請
		case 'BTNMODEREAPPLY': modeno = Number(c_modereapply); break;					// 再申請
		case 'BTNMODEUPD': modeno = Number(c_modeupd); break;							// 修正
		case 'BTNMODEKAKUTEIMAEUPD': modeno = Number(c_modekakuteimaeupd); break;		// 確定前修正
		case 'BTNMODEKAKUTEIGOUPD': modeno = Number(c_modekakuteigoupd); break;			// 確定後修正
		case 'BTNMODEDEL': modeno = Number(c_modedel); break;							// 取消
		case 'BTNMODEKAKUTEIMAEDEL': modeno = Number(c_modekakuteimaedel); break;		// 確定前取消
		case 'BTNMODEKAKUTEIGODEL': modeno = Number(c_modekakuteigodel); break;			// 確定後取消
		case 'BTNMODESINSEITORIKESI': modeno = Number(c_modesinseitorikesi); break;		// 申請済取消
		case 'BTNMODETEISEI': modeno = Number(c_modeteisei); break;						// 訂正
		case 'BTNMODEREF': modeno = Number(c_moderef); break;							// 照会
		case 'BTNMODELOSSKEISAN': modeno = Number(c_modelosskeisan); break;				// ロス計算
		case 'BTNMODELOSSDEL': modeno = Number(c_modelossdel); break;					// ロス取消
		case 'BTNMODELOSSREF': modeno = Number(c_modelossref); break;					// ロス照会
		case 'BTNMODEKESSAIJYOKYO': modeno = Number(c_modekessaijyokyo); break;			// 決裁状況
		case 'BTNMODESYURYOKAKUNINREF': modeno = Number(c_modesyuryokakuninref); break;	// 終了確認照会
		case 'BTNMODEKONKAI': modeno = Number(c_modekonkai); break;						// 今回
		case 'BTNMODEZENKAI': modeno = Number(c_modezenkai); break;						// 前回
		case 'BTNMODEKEIHISINSEI': modeno = Number(c_modekeihisinsei); break;			// 経費申請
		case 'BTNMODESCANCD': modeno = Number(c_modescancd); break;						// スキャンコード
		case 'BTNMODEJISHAHINBAN': modeno = Number(c_modejishahinban); break;			// 自社品番
		case 'BTNMODEMAKERHBN': modeno = Number(c_modemakerhbn); break;					// メーカー品番
		case 'BTNMODESONOTA': modeno = Number(c_modesonota); break;						// その他
		case 'BTNMODEREF_TANPIN': modeno = Number(c_moderef_tanpin); break;				// 照会単品別
		case 'BTNMODEREF_BUMON': modeno = Number(c_moderef_bumon); break;				// 照会部門別
		case 'BTNMODEPERCENTOFF': modeno = Number(c_modepercentoff); break;				// ％OFF
		case 'BTNMODEYENHIKI': modeno = Number(c_modeyenhiki); break;					// 円引き
		case 'BTNMODESINSEIMAESYUSEI': modeno = Number(c_modesinseimaeupd); break;		// 申請前修正
		case 'BTNMODESINSEIMAETORIKESI': modeno = Number(c_modesinseimaedel); break;	// 申請前取消
		case 'BTNMODESINSEIGOTORIKESI': modeno = Number(c_modesinseigodel); break;		// 申請後取消
		case 'BTNMODEJISHAHINBAN2': modeno = Number(c_modejisyahbnfukusu); break;		// 自社品番(複数)
		case 'BTNMODESINSEIZUMITORIKESI' : modeno = Number(c_modesinseizumitorikesi); break;	// 申請取消
		case 'BTNMODEREF_TOROKURIREKI' : modeno = Number(c_moderef_torokurireki); break;		// 登録履歴照会
		case 'BTNMODEREF_RINGIKEKKA' : modeno = Number(c_moderef_ringikekka); break;			// 稟議結果照会
	}
	return modeno;
}
// タブ項目名取得処理
function getTabNm(mode) {
	var itemNm = "";
	switch (mode) {
		case c_insert: itemNm = 'Btninsert'; break;								// 新規作成
		case c_modekakutei: itemNm = 'Btnmodekakutei'; break;					// 確定
		case c_modenyukakakutei: itemNm = 'Btnmodenyukakakutei'; break;			// 入荷確定
		case c_modesiirekakutei: itemNm = 'Btnmodesiirekakutei'; break;			// 仕入確定
		case c_modehenpinkakutei: itemNm = 'Btnmodehenpinkakutei'; break;		// 返品確定
		case c_modeapply: itemNm = 'Btnmodeapply'; break;						// 申請
		case c_modereapply: itemNm = 'Btnmodereapply'; break;					// 再申請
		case c_modeupd: itemNm = 'Btnmodeupd'; break;							// 修正
		case c_modekakuteimaeupd: itemNm = 'Btnmodekakuteimaeupd'; break;		// 確定前修正
		case c_modekakuteigoupd: itemNm = 'Btnmodekakuteigoupd'; break;			// 確定後修正
		case c_modedel: itemNm = 'Btnmodedel'; break;							// 取消
		case c_modekakuteimaedel: itemNm = 'Btnmodekakuteimaedel'; break;		// 確定前取消
		case c_modekakuteigodel: itemNm = 'Btnmodekakuteigodel'; break;			// 確定後取消
		case c_modesinseitorikesi: itemNm = 'Btnmodesinseitorikesi'; break;		// 申請済取消
		case c_modeteisei: itemNm = 'Btnmodeteisei'; break;						// 訂正
		case c_moderef: itemNm = 'Btnmoderef'; break;							// 照会
		case c_modelosskeisan: itemNm = 'Btnmodelosskeisan'; break;				// ロス計算
		case c_modelossdel: itemNm = 'Btnmodelossdel'; break;					// ロス取消
		case c_modelossref: itemNm = 'Btnmodelossref'; break;					// ロス照会
		case c_modekessaijyokyo: itemNm = 'Btnmodekessaijyokyo'; break;			// 決裁状況
		case c_modesyuryokakuninref: itemNm = 'Btnmodesyuryokakuninref'; break;	// 終了確認照会
		case c_modekonkai: itemNm = 'Btnmodekonkai'; break;						// 今回
		case c_modezenkai: itemNm = 'Btnmodezenkai'; break;						// 前回
		case c_modekeihisinsei: itemNm = 'Btnmodekeihisinsei'; break;			// 経費申請
		case c_modescancd: itemNm = 'Btnmodescancd'; break;						// スキャンコード
		case c_modejishahinban: itemNm = 'Btnmodejishahinban'; break;			// 自社品番
		case c_modemakerhbn: itemNm = 'Btnmodemakerhbn'; break;					// メーカー品番
		case c_modesonota: itemNm = 'Btnmodesonota'; break;						// その他
		case c_moderef_tanpin: itemNm = 'Btnmoderef_tanpin'; break;				// 照会単品別
		case c_moderef_bumon: itemNm = 'Btnmoderef_bumon'; break;				// 照会部門別
		case c_modepercentoff: itemNm = 'Btnmodepercentoff'; break;				// ％OFF
		case c_modeyenhiki: itemNm = 'Btnmodeyenhiki'; break;					// 円引き
		case c_modesinseimaeupd: itemNm = 'Btnmodesinseimaesyusei'; break;		// 申請前修正
		case c_modesinseimaedel: itemNm = 'Btnmodesinseimaetorikesi'; break;	// 申請前取消
		case c_modesinseigodel: itemNm = 'Btnmodesinseigotorikesi'; break;		// 申請後取消
		case c_modejisyahbnfukusu: itemNm = 'Btnmodejishahinban2'; break;		// 自社品番(複数)
		case c_modesinseizumitorikesi : itemNm = 'Btnmodesinseizumitorikesi'; break;	// 申請取消
		case c_moderef_torokurireki : itemNm = 'Btnmoderef_torokurireki'; break;		// 登録履歴照会
		case c_moderef_ringikekka : itemNm = 'Btnmoderef_ringikekka'; break;			// 稟議結果照会
	}
	return itemNm;
}

// モードなしの場合の制御
function nonmodeDisp() {

	var modeno = document.all.item(clm_StkMode);
	if (modeno) {
		if (modeno.value == null || modeno.value == "") {
			document.all.item("modeCaption").innerText = "";
			document.all.item("modeText").innerText = "";
			// 明細を隠す
			detailHide();
		}
	} else {
		// ↓モードがない画面のページャ非表示対応
		var m1srtRow = document.all.item("M1PageStartRow");
		if (m1srtRow != null) {
			if (m1srtRow.value == "0") {
				// 明細を隠す
				detailHide();
			}
		}
	}
}

// タブクリック時、検索条件クリア確認処理
/*
【呼び出し例】

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

*/
function searchInputClear(eventTargetName, textItem, labelItem) {
	
	// 項目名からモードNo取得
	var clickModeno = getModeNo(eventTargetName.toUpperCase());
	// モードNoを隠し項目へ設定
	var nowModeno = getAdvControlFromItemID(clm_Mode).value;
	
	var stkModeNo = getAdvControlFromItemID(clm_StkMode).value;
	if (stkModeNo != null && stkModeNo != "" && clickModeno != stkModeNo) {
		// 選択モードNoが設定されている場合かつモードNoと選択モードNoが同一でない場合

		// モードボタン共通処理
		tabClick(eventTargetName.toUpperCase(), true, textItem, labelItem);
	} else {
		// 値クリア処理
		if (clickModeno != nowModeno) {

			// 入力値がある場合
			var inputF = false;
			for (i = 0; i < textItem.length; i++) {
				if (textItem[i][0].type == "select-one") {
					// ドロップダウンリストの場合
					if (textItem[i][0].selectedIndex != textItem[i][1]) {
						inputF = true;
						break;
					}
				} else {
					if (textItem[i][0].value != textItem[i][1]) {
						inputF = true;
						break;
					}
				}
			}

			if (inputF) {
				// 入力値が存在する場合

				// 確認メッセージを表示
				var yes = function () {
					// 入力項目処理化
					for (i = 0; i < textItem.length; i++) {
						inputInitialSet(textItem[i][0], textItem[i][1]);
					}
					// ラベル項目初期化
					for (i = 0; i < labelItem.length; i++) {
						labelItem[i][0].value = labelItem[i][1];
					}
					// ユーザ定義関数を起動
					if (typeof tabClick_YesAction == "function") {
						tabClick_YesAction(getTabNm(getAdvControlFromItemID(clm_Mode).value));
					}
					// モードボタン共通処理
					tabClick(eventTargetName.toUpperCase());
				}

				var no = function () {
					// 処理なし
					var itemnm = '#' + getTabNm(getAdvControlFromItemID(clm_Mode).value);
					$(".str-tab-cont").hide();
					$($(itemnm).attr("href")).toggle();
					// タブのアクティブクラスを初期化
					$(".str-tab-menu ul li a").removeClass("search-tab-active");
					// 元のタブをアクティブに設定
					$(itemnm).toggleClass("search-tab-active");
					// 各画面にてNoアクションが定義されている場合、実行する。
					if (typeof tabClick_NoAction == "function") {
						tabClick_NoAction(getTabNm(getAdvControlFromItemID(clm_Mode).value));
					}
				}
				var msg = getMessage("W123");

				boOpenInfoDialog(msg, yes, no);
			} else {
				// モードボタン共通処理
				tabClick(eventTargetName.toUpperCase());
			}
		}
	}
}

// 明細隠す処理 
function detailHide() {

	var $openBtn = $('.trigger-search-01');							// アコーディオンボタン
	var $pager = $('.str-wrap-result .inner .str-pager-01');		// ページャ
	var $detail = $('.str-wrap-result .str-result-item-01');		// 明細部
	var $detailBtn = $('.str-wrap-result .str-btn-utility .inner');	// 明細ボタン部
	var $footerBtn = $('.str-wrap-result .footer');					// フッターボタン部
	var $footerArea = $('.str-wrap-result .str-result-ftr-01');		// 明細合計部
	var $footerArea2 = $('.footerBtnArea2');		// コメント部
	$footerArea2.show();

	$openBtn.hide();	// アコーディオンボタン
	$pager.hide();		// ページャ
	$detail.hide();		// 明細部
	$detailBtn.hide();	// 明細ボタン部
	$footerBtn.hide();	// フッターボタン部
	$footerArea.hide();	// 明細合計部

	// 高さ調節関数を呼び出し
	$('.common').adjustHeight();

}