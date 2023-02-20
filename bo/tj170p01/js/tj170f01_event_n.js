/*-----------------------------------------------------------------------------
	モジュール:tj170f01_event_n.js
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
	md_tj170f01_register();
	
	//共通ロード設定
	setCommonLoad();

	// --------------------------
	// BO初期表示共通処理
	boLoadCommon();
	// --------------------------

	// 品種コード(FROM)表示制御
	HinsyuFromControl();
	// 品種コード(TO)表示制御
	HinsyuToControl();

	/* hrefの値が消えてしまうので毎回設定 */
	document.all.item("Btnmodekonkai").href = "#tab22";
	document.all.item("Btnmodezenkai").href = "#tab23";

	V02019(getAdvControlFromItemID("Head_tenpo_cd"),
				   getAdvControlFromItemID("Head_tenpo_nm"),
				   getAdvControlFromItemID("Tanaorosijissi_ymd1"),
				   getAdvControlFromItemID("Tanaorosikikan_from1"),
				   getAdvControlFromItemID("Tanaorosikikan_to1"),
				   getAdvControlFromItemID("Tanaorosijissi_ymd11"),
				   getAdvControlFromItemID("Tanaorosikikan_from11"),
				   getAdvControlFromItemID("Tanaorosikikan_to11"),
		           getAdvControlFromItemID("Head_tenpo_cd"));
	
//	// 部門コードFROMが未入力の場合
//	if (getAdvControlFromItemID("Bumon_cd_from").value == "") {
//		// 品種コードFROM検索は非活性（部門コードFROMが入力されたら活性化）
//		itemDisabled(getAdvControlFromItemID("Btnhinsyu_cd_from"), true);
//	}
//	else {
//		itemDisabled(getAdvControlFromItemID("Btnhinsyu_cd_from"), false);
//	}
//	// 部門コードTOが未入力の場合
//	if (getAdvControlFromItemID("Bumon_cd_to").value == "") {
//		// 品種コードTO検索は非活性（部門コードTOが入力されたら活性化）
//		itemDisabled(getAdvControlFromItemID("Btnhinsyu_cd_to"), true);
//	}
//	else {
//		itemDisabled(getAdvControlFromItemID("Btnhinsyu_cd_to"), false);
//	}
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

			// ---------------------------
			// モードなしの表示に戻す。
			document.all.item(clm_StkMode).value = ""
			nonmodeDisp();
			// ---------------------------

			AdvGB_LastClickItemNm = null;
			return false;
		}
	}

	// ここに業務固有チェック処理を記述します。
	switch (AdvGB_LastClickItemNm.toUpperCase()) {

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

			// CSVボタン
		case "Btncsv".toUpperCase():

			// 確認メッセージを表示
			var yes = function () {
				$("#Btncsv")[0].click();
			}
			var no = function () {
			}
			var msg = getMessage("I101");
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
	case "BTNMODEKONKAI":
	case "BTNMODEZENKAI":
		// モードボタン共通処理
		tabClick(eventTargetName.toUpperCase());
		return false;
//	// -------------------
//	// 部門コード
//	// -------------------
//	// 部門コードボタン押下時、品種コードボタンを活性化
//		case "Btnbumon_cd_from".toUpperCase():
//			itemDisabled(getAdvControlFromItemID("Btnhinsyu_cd_from"), false);
//			break;
//		// 部門コードボタン押下時、品種コードボタンを活性化
//		case "Btnbumon_cd_to".toUpperCase():
//			itemDisabled(getAdvControlFromItemID("Btnhinsyu_cd_to"), false);
//			break;
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
		case "Head_tenpo_cd".toUpperCase():		// ヘッダ店舗コード、棚卸実施日データ
			// 取得部品を起動
			V02019(getAdvControlFromItemID("Head_tenpo_cd"),
				   getAdvControlFromItemID("Head_tenpo_nm"),
				   getAdvControlFromItemID("Tanaorosijissi_ymd1"),
				   getAdvControlFromItemID("Tanaorosikikan_from1"),
				   getAdvControlFromItemID("Tanaorosikikan_to1"),
				   getAdvControlFromItemID("Tanaorosijissi_ymd11"),
				   getAdvControlFromItemID("Tanaorosikikan_from11"),
				   getAdvControlFromItemID("Tanaorosikikan_to11"),
		           getAdvControlFromItemID("Head_tenpo_cd"));
			break;
		case "Syohingun1_cd".toUpperCase():		// 商品群１
			// 名称取得部品を起動
			V02008_MAIN(getAdvControlFromItemID("Syohingun1_cd"), getAdvControlFromItemID("Syohingun1_ryaku_nm"), getAdvControlFromItemID("Syohingun1_cd"), 0);
			break;
		case "Syohingun2_cd".toUpperCase():
			// 名称取得部品を起動
			V02009_MAIN(getAdvControlFromItemID("Syohingun2_cd"), getAdvControlFromItemID("Grpnm"), getAdvControlFromItemID("Syohingun2_cd"), 0);
			break;
		case "Bumon_cd_from".toUpperCase():		// 部門コードFROM
			// 部門コードFROMが未入力の場合、品種コードFROMボタン非活性
			if (getAdvControlFromItemID("Bumon_cd_from").value != "") {
				itemDisabled(getAdvControlFromItemID("Btnhinsyu_cd_from"), false);
			} else {
				itemDisabled(getAdvControlFromItemID("Btnhinsyu_cd_from"), true);
			}
			// 名称取得部品を起動(エラー判定なし)
			V02010_MAIN(getAdvControlFromItemID("Bumon_cd_from"), getAdvControlFromItemID("Bumon_nm_from"), null, 0);
			break;
		case "Bumon_cd_to".toUpperCase():		// 部門コードTO
			// 部門コードTOが未入力の場合、品種コードTOボタン非活性
			if (getAdvControlFromItemID("Bumon_cd_to").value != "") {
				itemDisabled(getAdvControlFromItemID("Btnhinsyu_cd_to"), false);
			} else {
				itemDisabled(getAdvControlFromItemID("Btnhinsyu_cd_to"), true);
			}
			// 名称取得部品を起動(エラー判定なし)
			V02010_MAIN(getAdvControlFromItemID("Bumon_cd_to"), getAdvControlFromItemID("Bumon_nm_to"), null, 0);
			break;
		case "Hinsyu_cd_from".toUpperCase():	// 品種コードFROM
			// 名称取得部品を起動(エラー判定なし)
			V02011_MAIN(getAdvControlFromItemID("Bumon_cd_from"), getAdvControlFromItemID("Hinsyu_cd_from"), getAdvControlFromItemID("Hinsyu_ryaku_nm_from"), null, null, 0);
			break;
		case "Hinsyu_cd_to".toUpperCase():		// 品種コードTO
			// 名称取得部品を起動(エラー判定なし)
			V02011_MAIN(getAdvControlFromItemID("Bumon_cd_to"), getAdvControlFromItemID("Hinsyu_cd_to"), getAdvControlFromItemID("Hinsyu_ryaku_nm_to"), null, null, 0);
			break;
		case "Burando_cd".toUpperCase():		// ブランドコード
			// 名称取得部品を起動
			V02012_MAIN(getAdvControlFromItemID("Burando_cd"), getAdvControlFromItemID("Burando_nm"), getAdvControlFromItemID("Burando_cd"), 0);
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
		case "Bumon_cd_from".toUpperCase():	// 部門コードFROM
			if (ev.key == "Enter" && !ev.shiftKey) {
				// Enterキー押下時
				// 品種コード表示制御
				HinsyuFromControl();
				if (getAdvControlFromItemID("Hinsyu_cd_from").value == "") {
					// 部門コード(FROM)が未設定の場合
					// 次の項目にフォーカス
					getAdvControlFromItemID("Bumon_cd_to").focus();
				}
			}
			break;
		case "Bumon_cd_to".toUpperCase():	// 部門コードTO
			if (ev.key == "Enter" && !ev.shiftKey) {
				// Enterキー押下時
				// 品種コード表示制御
				HinsyuToControl();
				if (getAdvControlFromItemID("Hinsyu_cd_to").value == "") {
					// 部門コード(FROM)が未設定の場合
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
		case "Bumon_cd_from".toUpperCase():	// 部門コード
			// 品種コード(FROM)表示制御
			HinsyuFromControl();
			// FROMの値をTOへコピー
			fromToCopy("Bumon_cd");
			// 品種コード(TO)表示制御
			HinsyuToControl();
			break;
		case "Hinsyu_cd_from".toUpperCase():// 品種コード
			// FROMの値をTOへコピー
			fromToCopy("Hinsyu_cd");

			// 部門TOがない場合、部門TOもコピー
			if (getAdvControlFromItemID("Bumon_cd_from").value != "" && getAdvControlFromItemID("Bumon_cd_to").value == "") {
				fromToCopy("Bumon_cd");
				// 品種コード(TO)表示制御
				HinsyuToControl();
			}

			// 品種TOの名称取得処理
			V02011(getAdvControlFromItemID("Bumon_cd_to"), getAdvControlFromItemID("Hinsyu_cd_to"), getAdvControlFromItemID("Hinsyu_ryaku_nm_to"));

			break;
		case "Bumon_cd_to".toUpperCase():	// 部門コード
			// 品種コード(TO)表示制御
			HinsyuToControl();
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
		case "Btnheadtenpocd":	// ヘッダ店舗コードボタン
			// 取得部品を起動
			getAdvControlFromItemID("Head_tenpo_cd").value = iDataArray[0];
			V02019(getAdvControlFromItemID("Head_tenpo_cd"),
				   getAdvControlFromItemID("Head_tenpo_nm"),
				   getAdvControlFromItemID("Tanaorosijissi_ymd1"),
				   getAdvControlFromItemID("Tanaorosikikan_from1"),
				   getAdvControlFromItemID("Tanaorosikikan_to1"),
				   getAdvControlFromItemID("Tanaorosijissi_ymd11"),
				   getAdvControlFromItemID("Tanaorosikikan_from11"),
				   getAdvControlFromItemID("Tanaorosikikan_to11"),
		           getAdvControlFromItemID("Head_tenpo_cd"));
		default:
		break;
	}
	return iDataArray;
}
// 品種コード(FROM)の表示制御を行う
function HinsyuFromControl() {
	// 部門コードが未設定の場合
	if (getAdvControlFromItemID("Bumon_cd_from").value == "") {
		// 品種コードを使用不可
		getAdvControlFromItemID("Hinsyu_cd_from").value = "";
		getAdvControlFromItemID("Hinsyu_ryaku_nm_from").value = "";
		itemDisabled(getAdvControlFromItemID("Hinsyu_cd_from"), true);
	} else {
		// 品種コードを使用可
		itemDisabled(getAdvControlFromItemID("Hinsyu_cd_from"), false);
	}
}
// 品種コード(TO)の表示制御を行う
function HinsyuToControl() {
	// 部門コードが未設定の場合
	if (getAdvControlFromItemID("Bumon_cd_to").value == "") {
		// 品種コードを使用不可
		getAdvControlFromItemID("Hinsyu_cd_to").value = "";
		getAdvControlFromItemID("Hinsyu_ryaku_nm_to").value = "";
		itemDisabled(getAdvControlFromItemID("Hinsyu_cd_to"), true);
	} else {
		// 品種コードを使用可
		itemDisabled(getAdvControlFromItemID("Hinsyu_cd_to"), false);
	}
}
