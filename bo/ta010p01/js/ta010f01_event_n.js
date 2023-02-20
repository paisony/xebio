/*-----------------------------------------------------------------------------
	モジュール:ta010f01_event_n.js
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
	md_ta010f01_register();
	
	//共通ロード設定
	setCommonLoad();
	
	// ----------------------
	// --------------------------
	// BO初期表示共通処理
	boLoadCommon();
	// --------------------------

	// 依頼理由のドロップダウン表示制御
	IraiRiyuControl();
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
			// エラー時の画面表示対応 --------------------------------  ADD_STR
			getAdvControlFromItemID(clm_StkMode).value = "";
			nonmodeDisp();
			// エラー時の画面表示対応 --------------------------------  ADD_END
			return false;
		}
	}

	// ここに業務固有チェック処理を記述します。
	switch (AdvGB_LastClickItemNm.toUpperCase()) {
		// 新規作成ボタン
		case "Btninsert".toUpperCase():
			// [選択モードNo]が「申請」「取消」の場合、メッセージを出力
			if (getAdvControlFromItemID(clm_StkMode).value == c_modeapply
			 || getAdvControlFromItemID(clm_StkMode).value == c_modedel) {

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
			// [選択モードNo]が「申請」「取消」の場合、メッセージを出力
			if (getAdvControlFromItemID(clm_StkMode).value == c_modeapply
			 || getAdvControlFromItemID(clm_StkMode).value == c_modedel) {

				// 確認メッセージを表示
				var yes = function () {
					// 検索条件の有効化
					divDisabled(".str-search-01", false);
					$("#Btnsearch")[0].click();
				}
				var no = function () { }
				var msg = getMessage("W113", "検索");
				return boOpenInfoDialog(msg, yes, no);
			} else {
				// 検索条件の有効化
				divDisabled(".str-search-01", false);
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
	var vRet = false;
	
	//共通クリック設定
	if (!setCommonOnClick(eventTarget, eventTargetName)) {
		return false;
	}
	
	switch (eventTargetName.toUpperCase()) {
	// ここに項目IDのcase文を追加し、固有処理を記述します。
		case "BTNMODEAPPLY":
		case "BTNMODEUPD":
		case "BTNMODEDEL":
			// モードボタン共通処理
			vRet = tabClick(eventTargetName.toUpperCase());
			if (isXebio(document.forms.Ta010f01.bocommon$logininfo_copcd)) {
				// Xの場合、制御を行う
				// 申請状態使用不可
				//getAdvControlFromItemID("Shinsei_flg").disabled = true;
				itemDisabled(getAdvControlFromItemID("Shinsei_flg"), true);
			}
			return false;
			break;
		case "BTNMODEREF":
			// モードボタン共通処理
			vRet = tabClick(eventTargetName.toUpperCase());
			if (isXebio(document.forms.Ta010f01.bocommon$logininfo_copcd)) {
				// Xの場合、制御を行う
				// 申請状態使用可
				//getAdvControlFromItemID("Shinsei_flg").disabled = false;
				itemDisabled(getAdvControlFromItemID("Shinsei_flg"), false);
			}
			return false;
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
		case "Tantosya_cd".toUpperCase():	// 担当者コード
			// 名称取得部品を起動
			V02005_MAIN(getAdvControlFromItemID("Tantosya_cd"), getAdvControlFromItemID("Hanbaiin_nm"), getAdvControlFromItemID("Tantosya_cd"), 0);
			break;

		case "Kbn_cd".toUpperCase():	// 区分コード
			// 依頼理由のドロップダウン表示制御
			IraiRiyuControl();
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
		case "Hattyu_ymd_from".toUpperCase():	// 発注日FROM
			// FROMの値をTOへコピー
			fromToCopy("Hattyu_ymd");
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
		case "BTNMODEAPPLY":
		case "BTNMODEUPD":
		case "BTNMODEDEL":
			if (isXebio(document.forms.Ta010f01.bocommon$logininfo_copcd)) {
				// Xの場合、制御を行う
				// 申請状態使用不可
				//getAdvControlFromItemID("Shinsei_flg").disabled = true;
				itemDisabled(getAdvControlFromItemID("Shinsei_flg"), true);
			}
			return false;
			break;
		case "BTNMODEREF":
			if (isXebio(document.forms.Ta010f01.bocommon$logininfo_copcd)) {
				// Xの場合、制御を行う
				// 申請状態使用可
				//getAdvControlFromItemID("Shinsei_flg").disabled = false;
				itemDisabled(getAdvControlFromItemID("Shinsei_flg"), false);
			}
			return false;
			break;
		default:
			break;
	}

}
// 依頼理由の表示制御を行う
function IraiRiyuControl() {

	if (getAdvControlFromItemID("Kbn_cd").value == 1) {
		// 補充依頼の場合
		itemVisible(getAdvControlFromItemID("Irairiyu_cd1"), true);
		itemVisible(getAdvControlFromItemID("Irairiyu_cd2"), false);
		$(getAdvControlFromItemID("Irairiyu_cd1")).width(140);
		$(getAdvControlFromItemID("Irairiyu_cd1")).height(26);
		$(getAdvControlFromItemID("Irairiyu_cd2")).width(0);
		$(getAdvControlFromItemID("Irairiyu_cd2")).height(0);
	} else if (getAdvControlFromItemID("Kbn_cd").value == 2) {
		// 単品レポートの場合
		itemVisible(getAdvControlFromItemID("Irairiyu_cd1"), false);
		itemVisible(getAdvControlFromItemID("Irairiyu_cd2"), true);
		$(getAdvControlFromItemID("Irairiyu_cd1")).width(0);
		$(getAdvControlFromItemID("Irairiyu_cd1")).height(0);
		$(getAdvControlFromItemID("Irairiyu_cd2")).width(140);
		$(getAdvControlFromItemID("Irairiyu_cd2")).height(26);
	} else {
		// その他の場合
		itemVisible(getAdvControlFromItemID("Irairiyu_cd1"), false);
		itemVisible(getAdvControlFromItemID("Irairiyu_cd2"), false);
		getAdvControlFromItemID("Irairiyu_cd1").selectedIndex = 0;
		getAdvControlFromItemID("Irairiyu_cd2").selectedIndex = 0;
	}
}