/*-----------------------------------------------------------------------------
	モジュール:tj190f02_event_n.js
--------------------------------------------------------------------------------*/
/*<title>[画面02CLイベントScript]</title>*/

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
	md_tj190f02_register();


	//共通ロード設定
	setCommonLoad();

	// --------------------------
	// BO初期表示共通処理
	boLoadCommon();
	// --------------------------

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

			// モードの取得
			var mode = getAdvControlFromItemID(clm_StkMode).value

			// 修正モードの場合
			if (mode == c_modeupd) {

				// 確認メッセージを表示
				var yes = function () {
					$("#Btnback")[0].click();
				}
				var no = function () {
				}
				var msg = getMessage("W107");
				if (boOpenInfoDialog(msg, yes, no) == false) {
					return false;
				}
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
		case "Hinsyu_sitei_flg".toUpperCase():// 品種指定フラグ

			var ctl_Hinsyu_cd = getAdvControlFromItemID("Hinsyu_cd");
			var ctl_Hinsyu_ryaku_nm = getAdvControlFromItemID("Hinsyu_ryaku_nm");
			var ctl_Btnhinsyu_cd = getAdvControlFromItemID("Btnhinsyu_cd");

			var radioListZenHinshu = AdvGB_TargetForm.Hinsyu_sitei_flg_0;
			var radioListHinshuSite = AdvGB_TargetForm.Hinsyu_sitei_flg_1;

			// 全品種が選択された場合、品種コード、品種コードボタンは使用不可とし、品種コード、品種略名称に空白を設定する。
			if (radioListZenHinshu.checked)
			{
				// 値クリア
				ctl_Hinsyu_cd.value = "";
				ctl_Hinsyu_ryaku_nm.value = "";
				itemDisabled(ctl_Hinsyu_cd, true);
				//ctl_Btnhinsyu_cd.setAttribute("style", "display:none");
			}
			// 品種指定が選択された場合、品種コード、品種コードボタンは使用可能とする。
			if (radioListHinshuSite.checked)
			{
				itemDisabled(ctl_Hinsyu_cd, false);
				//ctl_Btnhinsyu_cd.removeAttribute("style", "display:none");
			}

			break;
		case "Burando_sitei_flg".toUpperCase():// ブランド指定フラグ

			var ctl_Burando_cd = getAdvControlFromItemID("Burando_cd");
			var ctl_Burando_nm = getAdvControlFromItemID("Burando_nm");
			var ctl_Btnburando_cd = getAdvControlFromItemID("Btnburando_cd");

			var ctl_Burando_cd1 = getAdvControlFromItemID("Burando_cd1");
			var ctl_Burando_nm1 = getAdvControlFromItemID("Burando_nm1");
			var ctl_Btnburando_cd1 = getAdvControlFromItemID("Btnburando_cd1");

			var ctl_Burando_cd2 = getAdvControlFromItemID("Burando_cd2");
			var ctl_Burando_nm2 = getAdvControlFromItemID("Burando_nm2");
			var ctl_Btnburando_cd2 = getAdvControlFromItemID("Btnburando_cd2");

			var ctl_Burando_cd3 = getAdvControlFromItemID("Burando_cd3");
			var ctl_Burando_nm3 = getAdvControlFromItemID("Burando_nm3");
			var ctl_Btnburando_cd3 = getAdvControlFromItemID("Btnburando_cd3");

			var ctl_Burando_cd4 = getAdvControlFromItemID("Burando_cd4");
			var ctl_Burando_nm4 = getAdvControlFromItemID("Burando_nm4");
			var ctl_Btnburando_cd4 = getAdvControlFromItemID("Btnburando_cd4");

			var ctl_Burando_cd5 = getAdvControlFromItemID("Burando_cd5");
			var ctl_Burando_nm5 = getAdvControlFromItemID("Burando_nm5");
			var ctl_Btnburando_cd5 = getAdvControlFromItemID("Btnburando_cd5");

			var ctl_Burando_cd6 = getAdvControlFromItemID("Burando_cd6");
			var ctl_Burando_nm6 = getAdvControlFromItemID("Burando_nm6");
			var ctl_Btnburando_cd6 = getAdvControlFromItemID("Btnburando_cd6");

			var ctl_Burando_cd7 = getAdvControlFromItemID("Burando_cd7");
			var ctl_Burando_nm7 = getAdvControlFromItemID("Burando_nm7");
			var ctl_Btnburando_cd7 = getAdvControlFromItemID("Btnburando_cd7");


			var radioListZenBurando = AdvGB_TargetForm.Burando_sitei_flg_0;
			var radioListBurandoSite = AdvGB_TargetForm.Burando_sitei_flg_1;

			// 全ブランドが選択された場合、ブランドコード(～7)、ブランドコードボタン(～7)は使用不可とし、すべてのブランドコード、ブランド名に空白を設定する。
			if (radioListZenBurando.checked) {

				// 値クリア
				ctl_Burando_cd.value = "";
				ctl_Burando_nm.value = "";

				ctl_Burando_cd1.value = "";
				ctl_Burando_nm1.value = "";

				ctl_Burando_cd2.value = "";
				ctl_Burando_nm2.value = "";

				ctl_Burando_cd3.value = "";
				ctl_Burando_nm3.value = "";

				ctl_Burando_cd4.value = "";
				ctl_Burando_nm4.value = "";

				ctl_Burando_cd5.value = "";
				ctl_Burando_nm5.value = "";

				ctl_Burando_cd6.value = "";
				ctl_Burando_nm6.value = "";

				ctl_Burando_cd7.value = "";
				ctl_Burando_nm7.value = "";

				itemDisabled(ctl_Burando_cd, true);
				itemDisabled(ctl_Burando_cd1, true);
				itemDisabled(ctl_Burando_cd2, true);
				itemDisabled(ctl_Burando_cd3, true);
				itemDisabled(ctl_Burando_cd4, true);
				itemDisabled(ctl_Burando_cd5, true);
				itemDisabled(ctl_Burando_cd6, true);
				itemDisabled(ctl_Burando_cd7, true);

				//ctl_Btnburando_cd.setAttribute("style", "display:none");
				//ctl_Btnburando_cd1.setAttribute("style", "display:none");
				//ctl_Btnburando_cd2.setAttribute("style", "display:none");
				//ctl_Btnburando_cd3.setAttribute("style", "display:none");
				//ctl_Btnburando_cd4.setAttribute("style", "display:none");
				//ctl_Btnburando_cd5.setAttribute("style", "display:none");
				//ctl_Btnburando_cd6.setAttribute("style", "display:none");
				//ctl_Btnburando_cd7.setAttribute("style", "display:none");

			}
			// ブランド指定が選択された場合、ブランドコード(～7)、ブランドコードボタン(～7)は使用可能とする。
			if (radioListBurandoSite.checked) {
				itemDisabled(ctl_Burando_cd, false);
				itemDisabled(ctl_Burando_cd1, false);
				itemDisabled(ctl_Burando_cd2, false);
				itemDisabled(ctl_Burando_cd3, false);
				itemDisabled(ctl_Burando_cd4, false);
				itemDisabled(ctl_Burando_cd5, false);
				itemDisabled(ctl_Burando_cd6, false);
				itemDisabled(ctl_Burando_cd7, false);
				//ctl_Btnburando_cd.removeAttribute("style", "display:none");
				//ctl_Btnburando_cd1.removeAttribute("style", "display:none");
				//ctl_Btnburando_cd2.removeAttribute("style", "display:none");
				//ctl_Btnburando_cd3.removeAttribute("style", "display:none");
				//ctl_Btnburando_cd4.removeAttribute("style", "display:none");
				//ctl_Btnburando_cd5.removeAttribute("style", "display:none");
				//ctl_Btnburando_cd6.removeAttribute("style", "display:none");
				//ctl_Btnburando_cd7.removeAttribute("style", "display:none");
			}

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
		case "Hinsyu_cd".toUpperCase():// 品種コード
			// 名称取得部品を起動
			V02011(getAdvControlFromItemID("Bumon_cd_bo"), getAdvControlFromItemID("Hinsyu_cd"), getAdvControlFromItemID("Hinsyu_ryaku_nm"), getAdvControlFromItemID("Hinsyu_cd"));
			break;
		case "Burando_cd".toUpperCase():// ブランドコード
			// 名称取得部品を起動
			V02012(getAdvControlFromItemID("Burando_cd"), getAdvControlFromItemID("Burando_nm"), getAdvControlFromItemID("Burando_cd"));
			break;
		case "Burando_cd1".toUpperCase():// ブランドコード1
			// 名称取得部品を起動
			V02012(getAdvControlFromItemID("Burando_cd1"), getAdvControlFromItemID("Burando_nm1"), getAdvControlFromItemID("Burando_cd1"));
			break;
		case "Burando_cd2".toUpperCase():// ブランドコード2
			// 名称取得部品を起動
			V02012(getAdvControlFromItemID("Burando_cd2"), getAdvControlFromItemID("Burando_nm2"), getAdvControlFromItemID("Burando_cd2"));
			break;
		case "Burando_cd3".toUpperCase():// ブランドコード3
			// 名称取得部品を起動
			V02012(getAdvControlFromItemID("Burando_cd3"), getAdvControlFromItemID("Burando_nm3"), getAdvControlFromItemID("Burando_cd3"));
			break;
		case "Burando_cd4".toUpperCase():// ブランドコード4
			// 名称取得部品を起動
			V02012(getAdvControlFromItemID("Burando_cd4"), getAdvControlFromItemID("Burando_nm4"), getAdvControlFromItemID("Burando_cd4"));
			break;
		case "Burando_cd5".toUpperCase():// ブランドコード5
			// 名称取得部品を起動
			V02012(getAdvControlFromItemID("Burando_cd5"), getAdvControlFromItemID("Burando_nm5"), getAdvControlFromItemID("Burando_cd5"));
			break;
		case "Burando_cd6".toUpperCase():// ブランドコード6
			// 名称取得部品を起動
			V02012(getAdvControlFromItemID("Burando_cd6"), getAdvControlFromItemID("Burando_nm6"), getAdvControlFromItemID("Burando_cd6"));
			break;
		case "Burando_cd7".toUpperCase():// ブランドコード7
			// 名称取得部品を起動
			V02012(getAdvControlFromItemID("Burando_cd7"), getAdvControlFromItemID("Burando_nm7"), getAdvControlFromItemID("Burando_cd7"));
			break;

		// -------------------
		// スキャンコード
		// -------------------
		case "M1scan_cd".toUpperCase():
			// 明細行番号を取得する
			var lineNo = getItemMNofromCtrl(eventTarget);

			// 操作ありの背景色に変更
			commitColorSet(lineNo);

			// 名称表示
			// 検索条件指定(Key：固定、Value：検索値)
			var condition = {
				"SCAN_CD": getAdvControlFromItemID("M1scan_cd", lineNo)	// スキャンコード
				, "TENPO_CD": getAdvControlFromItemID("Tenpo_cd_hdn")		// 店舗コード
				, "PLUFLG": "0"												// 店別単価マスタ	検索フラグ 0:検索しない 1:検索する
				, "PRICEFLG": "0"											// 売変				検索フラグ 0:検索しない 1:検索する
				, "ZAIKOFLG": "2"											// 店在庫			検索フラグ 0:検索しない 1:検索する
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
				"HINSYU_RYAKU_NM": getAdvControlFromItemID("M1hinsyu_ryaku_nm", lineNo)	// 品種
				, "BURANDO_NMK": getAdvControlFromItemID("M1burando_nm", lineNo)			// ブランド
				, "XEBIO_CD": getAdvControlFromItemID("M1jisya_hbn", lineNo)				// 自社品番
				, "HIN_NBR": getAdvControlFromItemID("M1maker_hbn", lineNo)				// メーカー品番
				, "SYONMK": getAdvControlFromItemID("M1syonmk", lineNo)					// 商品名
				, "IRO_NM": getAdvControlFromItemID("M1iro_nm", lineNo)					// 色
				, "SIZE_NM": getAdvControlFromItemID("M1size_nm", lineNo)					// サイズ
				, "HYOKA_TNK": getAdvControlFromItemID("M1hyoka_tnk", lineNo)				// 評価単価
				, "TYOBOZAIKO_SU": getAdvControlFromItemID("M1tanajityobo_su", lineNo)		// 帳簿在庫
				, "SEKISO_SU": getAdvControlFromItemID("M1tanajisekiso_su", lineNo)		// 積送在庫
			};

			// 名称取得部品
			V02004(condition, result, getAdvControlFromItemID("M1scan_cd", lineNo), true, lineNo);

			break;

		// -------------------
		// 実棚数
		// -------------------
		case "M1jitana_su".toUpperCase():

			// 明細行番号を取得する
			var lineNo = getItemMNofromCtrl(eventTarget);
			// 合計値再計算
			calcRowM1jitana_su(lineNo, getAdvControlFromItemID("M1loss_su", lineNo).value, getAdvControlFromItemID("M1loss_kin", lineNo).value);

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
function onBlur(ev) {
	var eventTarget=getAdvEventTarget(ev);
	var eventTargetName=getAdvEventTargetName(ev);
	switch (eventTargetName.toUpperCase()) {
	//  ここに項目IDのcase文を追加し、固有処理を記述します。
		case "M1scan_cd".toUpperCase():	// スキャンコード

			// 明細行番号を取得する
			var lineNo = getItemMNofromCtrl(eventTarget);

			// スキャンコード丸め処理
			formatScanCd(getAdvControlFromItemID("M1scan_cd", lineNo));

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

	// フォーマット処理を実行する為、フォーカス処理を実行
	var shyoka_tnk = getAdvControlFromItemID("M1hyoka_tnk", lineNo);
	shyoka_tnk.value = getAdvFormatStr("M1hyoka_tnk", shyoka_tnk.value);

	var stanajityobo_su = getAdvControlFromItemID("M1tanajityobo_su", lineNo);
	stanajityobo_su.value = getAdvFormatStr("M1tanajityobo_su", stanajityobo_su.value);

	var stanajisekiso_su = getAdvControlFromItemID("M1tanajisekiso_su", lineNo);
	stanajisekiso_su.value = getAdvFormatStr("M1tanajisekiso_su", stanajisekiso_su.value);

	// ロス数、ロス金額を退避しておく
	var loss_su = getAdvControlFromItemID("M1loss_su", lineNo).value;
	var loss_kin = getAdvControlFromItemID("M1loss_kin", lineNo).value;

	// 項目を初期化する
	// 実棚数
	//getAdvControlFromItemID("M1jitana_su", lineNo).value = "0";
	// ロス数
	getAdvControlFromItemID("M1loss_su", lineNo).value = "0";
	// ロス金額
	getAdvControlFromItemID("M1loss_kin", lineNo).value = "0";

	// 合計計算処理を行う
	// 合計棚時帳簿数
	var vGokeitanajityobo_su = getAdvControlFromItemID("Gokeitanajityobo_su");

	// 合計棚時積送数
	var vGokeitanajisekiso_su = getAdvControlFromItemID("Gokeitanajisekiso_su");

	// 合計棚時帳簿数の再計算を行う
	// Ｍ１棚時帳簿数と棚時帳簿数(隠し)の差分を取得し、合計棚時帳簿数に加算(減算)する。
	vGokeitanajityobo_su.value =
		formatComma(ToNumber(unFormatComma(vGokeitanajityobo_su.value))
		+ (ToNumber(unFormatComma(stanajityobo_su.value))
		- ToNumber(unFormatComma(getAdvControlFromItemID("M1tanajityobo_su_hdn", lineNo).value))));

	// 合計棚時積送数の再計算を行う
	// Ｍ１棚時積送数と取得した棚時積送数(隠し)の差分を取得し、合計棚時積送数に加算(減算)する。
	vGokeitanajisekiso_su.value =
		formatComma(ToNumber(unFormatComma(vGokeitanajisekiso_su.value))
		+ (ToNumber(unFormatComma(stanajisekiso_su.value))
		- ToNumber(unFormatComma(getAdvControlFromItemID("M1tanajisekiso_su_hdn", lineNo).value))));
	
	getAdvControlFromItemID("M1tanajityobo_su_hdn", lineNo).value = ToNumber(unFormatComma(stanajityobo_su.value));
	getAdvControlFromItemID("M1tanajisekiso_su_hdn", lineNo).value = ToNumber(unFormatComma(stanajisekiso_su.value));

	// 実棚数のロストフォーカス時計算処理起動
	calcRowM1jitana_su(lineNo, loss_su, loss_kin);

}

// 明細合計値計算関数 実棚数
function calcRowM1jitana_su(lineNo, loss_suTaihi, losskinTaihi) {

	// Ｍ１ロス数(退避)
	var losssu = loss_suTaihi;

	// Ｍ１ロス金額(退避)
	var losskin = losskinTaihi;

	// Ｍ１評価単価
	var hyoka_tanka = getAdvControlFromItemID("M1hyoka_tnk", lineNo);

	// Ｍ１棚時帳簿数
	var tanajityobo_su = getAdvControlFromItemID("M1tanajityobo_su", lineNo);

	// Ｍ１棚時積送数
	var tanajisekiso_su = getAdvControlFromItemID("M1tanajisekiso_su", lineNo);

	// Ｍ１実棚数
	var jitana_su = getAdvControlFromItemID("M1jitana_su", lineNo);

	// Ｍ１実棚数（隠し）
	var jitana_su_hdn = getAdvControlFromItemID("M1jitana_su1_hdn", lineNo);

	// 合計ロス数
	var Gokeiloss_su = getAdvControlFromItemID("Gokeiloss_su");

	// 合計ロス金額
	var Gokeiloss_kin = getAdvControlFromItemID("Gokeiloss_kin");

	// 合計実棚数
	var Gokeijitana_su = getAdvControlFromItemID("Gokeijitana_su");

	// Ｍ１ロス数、Ｍ１ロス金額を計算する。
	// Ｍ１ロス数 = Ｍ１棚時帳簿数 - Ｍ１棚時積送数 - Ｍ１実棚数
	// Ｍ１ロス金額 = Ｍ１ロス数 * Ｍ１評価単価
	getAdvControlFromItemID("M1loss_su", lineNo).value = formatComma(ToNumber(unFormatComma(tanajityobo_su.value)) - ToNumber(unFormatComma(tanajisekiso_su.value)) - ToNumber(unFormatComma(jitana_su.value)));
	getAdvControlFromItemID("M1loss_kin", lineNo).value = formatComma(ToNumber(unFormatComma(getAdvControlFromItemID("M1loss_su", lineNo).value)) * ToNumber(unFormatComma(hyoka_tanka.value)));
	//getAdvControlFromItemID("M1loss_kin", lineNo).value = getAdvControlFromItemID("M1loss_su", lineNo).value * 0;

	// 退避したロス数と再計算したロス数の差分を取得し、合計ロス数に加算(減算)する。
	Gokeiloss_su.value = formatComma(ToNumber(unFormatComma(Gokeiloss_su.value)) + (ToNumber(unFormatComma(getAdvControlFromItemID("M1loss_su", lineNo).value)) - ToNumber(unFormatComma(losssu))));

	// 退避したロス金額と再計算したロス金額の差分を取得し、合計ロス数に加算(減算)する。
	Gokeiloss_kin.value = formatComma(ToNumber(unFormatComma(Gokeiloss_kin.value)) + (ToNumber(unFormatComma(getAdvControlFromItemID("M1loss_kin", lineNo).value)) - ToNumber(unFormatComma(losskin))));

	// Ｍ１実棚数とＭ１実棚数（隠し）の差分を取得し、合計実棚数に加算(減算)する。
	Gokeijitana_su.value = formatComma(ToNumber(unFormatComma(Gokeijitana_su.value)) + (ToNumber(unFormatComma(jitana_su.value)) - ToNumber(unFormatComma(jitana_su_hdn.value))));
	jitana_su_hdn.value = formatComma(jitana_su.value);
}
