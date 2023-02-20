/*-----------------------------------------------------------------------------
	モジュール:te080f01_event_n.js
--------------------------------------------------------------------------------*/
/*<title>[画面01CLイベントScript]</title>*/

/*-----------------------------------------------------------------------------
イベントキャプチャ開始処理
-----------------------------------------------------------------------------*/

// var detailcnt = 100;	// 明細最大件数
var detailcnt = 50;	// 明細最大件数
var tenpocd = '';		// 店舗コード
var tenponm = '';		// 店舗名

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
	md_te080f01_register();
	
	//共通ロード設定
	setCommonLoad();

	// --------------------------
	// BO初期表示共通処理
	boLoadCommon();
	// --------------------------

	selectorCheckBox = 'M1selectorcheckbox';

	var i = 0;
	while (!(typeof getAdvControlFromItemID("M1rowno", i) === "undefined")) {
		// 出荷店コード表示制御
		SyukkatenControl(i);
		i++;
	}

	tenpocd = getAdvControlFromItemID("Head_tenpo_cd").value;		// 店舗コード
	tenponm = getAdvControlFromItemID("Head_tenpo_nm").value;		// 店舗名
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

			detailHide();

			AdvGB_LastClickItemNm = null;
			return false;
		}
	}

	// ここに業務固有チェック処理を記述します。
	switch (AdvGB_LastClickItemNm.toUpperCase()) {

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
	var lineNo = getItemMNofromCtrl(eventTarget);

	switch (eventTargetName.toUpperCase()) {
	//  ここに項目IDのcase文を追加し、固有処理を記述します。
	
		case "Head_tenpo_cd".toUpperCase():	// ヘッダ店舗コード

			// 名称取得部品を起動
			V02001(getAdvControlFromItemID("Head_tenpo_cd"), getAdvControlFromItemID("Head_tenpo_nm"), getAdvControlFromItemID("Head_tenpo_cd"));

			// 明細部に入力がある場合、確認メッセージを表示
			var inputf = false;
			for (i = 0; i < detailcnt; i++) {
				var denno = getAdvControlFromItemID("M1scmden_cd", lineNo + 1).value;
				if (denno != "") {
					// 入力がある場合
					inputf = true;
					break;
				}
			}
			if (inputf) {
				var yes = function () {
					$("#Btnclear")[0].click();
				}
				var no = function () {
					// 店舗情報を元に戻す
					getAdvControlFromItemID("Head_tenpo_cd").value = tenpocd;
					getAdvControlFromItemID("Head_tenpo_nm").value = tenponm;
				}
				var msg = getMessage("W122");
				return boOpenInfoDialog(msg, yes, no);
			}

			break;

		case "M1kaisya_cd".toUpperCase():	// Ｍ１会社コード

			// 名称取得部品を起動
			V02006(getAdvControlFromItemID("M1kaisya_cd", lineNo), getAdvControlFromItemID("M1kaisya_nm", lineNo), getAdvControlFromItemID("M1kaisya_cd", lineNo));

			var SyukkatenCd = getAdvControlFromItemID("M1syukkaten_cd", lineNo);
			var ScmdenCd = getAdvControlFromItemID("M1scmden_cd", lineNo);
			if (SyukkatenCd.value != "" && ScmdenCd.value != "" && ScmdenCd.value.length <= 6)
			{
				// 選択行をhiddenに退避
				getAdvControlFromItemID("Selectrowno").value = lineNo;
				// ダミーの行追加ボタンを押下したことにする
				$("#Btnrowins")[0].click();
			}

			break;

		case "M1syukkaten_cd".toUpperCase():	// Ｍ１出荷店コード

			// 名称取得部品を起動
			V02026(getAdvControlFromItemID("M1kaisya_cd", lineNo), getAdvControlFromItemID("M1syukkaten_cd", lineNo), getAdvControlFromItemID("M1syukkaten_nm", lineNo), getAdvControlFromItemID("M1syukkaten_cd", lineNo));

			var KaisyaCd = getAdvControlFromItemID("M1kaisya_cd", lineNo);
			var ScmdenCd = getAdvControlFromItemID("M1scmden_cd", lineNo);
			if (KaisyaCd.value != "" && ScmdenCd.value != "" && ScmdenCd.value.length <= 6) {
				// 選択行をhiddenに退避
				getAdvControlFromItemID("Selectrowno").value = lineNo;
				// ダミーの行追加ボタンを押下したことにする
				$("#Btnrowins")[0].click();
			}

			break;

		case "M1scmden_cd".toUpperCase():	// Ｍ１SCM/伝票コード

			// 操作ありの背景色に変更
			commitColorSet(lineNo);

			// 選択行をhiddenに退避
			getAdvControlFromItemID("Selectrowno").value = lineNo;

			if (getAdvControlFromItemID("M1scmden_cd", lineNo).value != ""			// Ｍ１SCMコード/伝票番号
				|| getAdvControlFromItemID("M1scm_cd", lineNo).value != ""			// Ｍ１SCMコード
				|| getAdvControlFromItemID("M1denpyo_bango", lineNo).value != ""	// Ｍ１伝票番号
				) {
				// ダミーの行追加ボタンを押下したことにする
				$("#Btnrowins")[0].click();
			}

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
	var eventTargetName = getAdvEventTargetName(ev);
	var lineNo = getItemMNofromCtrl(eventTarget);

	switch (eventTargetName.toUpperCase()) {
		// ここに項目IDのcase文を追加し、固有処理を記述します。

		case "M1kaisya_cd".toUpperCase():	// Ｍ１会社コード
			if (ev.key == "Enter" && !ev.shiftKey) {
				// Enterキー押下時
				// 出荷店コード表示制御
				SyukkatenControl(lineNo);
				if (getAdvControlFromItemID("M1kaisya_cd", lineNo).value == "") {
					// 会社コードが未設定の場合
					// 次の項目にフォーカス
					getAdvControlFromItemID("M1scmden_cd", lineNo).focus();
				}
			}
			break;

		case "M1scmden_cd".toUpperCase():	// Ｍ１SCM/伝票コード

			if (ev.key == "Enter" && !ev.shiftKey)
			{
				if (detailcnt > lineNo + 1) {
					if (getAdvControlFromItemID("M1kaisya_cd", lineNo + 1).value == ""
						&& getAdvControlFromItemID("M1syukkaten_cd", lineNo + 1).value == "") {
						// 次行が未入力の場合
						getAdvControlFromItemID("M1kaisya_cd", lineNo + 1).value = getValue(getAdvControlFromItemID("M1kaisya_cd", lineNo));
						getAdvControlFromItemID("M1kaisya_nm", lineNo + 1).value = getValue(getAdvControlFromItemID("M1kaisya_nm", lineNo));
						getAdvControlFromItemID("M1syukkaten_cd", lineNo + 1).value = getValue(getAdvControlFromItemID("M1syukkaten_cd", lineNo));
						getAdvControlFromItemID("M1syukkaten_nm", lineNo + 1).value = getValue(getAdvControlFromItemID("M1syukkaten_nm", lineNo));

						// 出荷店コード表示制御
						SyukkatenControl(lineNo + 1);
					}
					getAdvControlFromItemID("M1scmden_cd", lineNo + 1).focus();
				}
				return true;
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
		// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
		case "Head_tenpo_cd".toUpperCase():	// ヘッダ店舗コード
			tenpocd = getAdvControlFromItemID("Head_tenpo_cd").value;
			tenponm = getAdvControlFromItemID("Head_tenpo_nm").value;
			break;
		// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
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
	var eventTargetName = getAdvEventTargetName(ev);
	var lineNo = getItemMNofromCtrl(eventTarget);

	switch (eventTargetName.toUpperCase()) {
		//  ここに項目IDのcase文を追加し、固有処理を記述します。

		case "M1kaisya_cd".toUpperCase():	// Ｍ１会社コード
			// 出荷店コード表示制御
			SyukkatenControl(lineNo);
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
		case "M1btnkaisha_cd".toUpperCase():	// 会社コード検索
		case "M1btnsyukkatencd".toUpperCase():	// 出荷店コード検索

			// 操作ありの背景色に変更
			commitColorSet(rowno);
			break;
		default:
			break;
	}
	return iDataArray;
}

/*-----------------------------------------------------------------------------
ユーザ定義関数
-----------------------------------------------------------------------------*/
/**
 * 出荷店の表示制御を行う
 * @param lineNo {Number} 行番号
 */
function SyukkatenControl(lineNo) {
	// Ｍ１会社コードが未設定の場合
	if (getAdvControlFromItemID("M1kaisya_cd", lineNo).value == "") {
		// Ｍ１出荷店コードを使用不可
		getAdvControlFromItemID("M1syukkaten_cd", lineNo).value = "";
		getAdvControlFromItemID("M1syukkaten_nm", lineNo).value = "";
		getAdvControlFromItemID("M1syukkaten_nm", lineNo).title = "";
		itemDisabled(getAdvControlFromItemID("M1syukkaten_cd", lineNo), true);
	} else {
		// Ｍ１出荷店コードを使用可
		itemDisabled(getAdvControlFromItemID("M1syukkaten_cd", lineNo), false);
	}
}
