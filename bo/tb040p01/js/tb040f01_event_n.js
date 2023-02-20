/*-----------------------------------------------------------------------------
	モジュール:tb040f01_event_n.js
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
	md_tb040f01_register();
	
	//共通ロード設定
	setCommonLoad();

// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

	// --------------------------
	// BO初期表示共通処理
	boLoadCommon();
	// --------------------------

	selectorCheckBox = 'M1selectorcheckbox';

	tenpocd = getAdvControlFromItemID("Head_tenpo_cd").value;		// 店舗コード
	tenponm = getAdvControlFromItemID("Head_tenpo_nm").value;		// 店舗名
	// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

	
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
// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
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

	var tenpoCdLength = getValue(getAdvControlFromItemID("Head_tenpo_cd", lineNo)).length;
	var siiresakiLength = getValue(getAdvControlFromItemID("M1siiresaki_cd", lineNo)).length;
	var denpyoLength = getValue(getAdvControlFromItemID("M1denpyo_barcode", lineNo)).length;

	switch (eventTargetName.toUpperCase()) {
	//	ここに項目IDのcase文を追加し、固有処理を記述します。
	
		// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
		case "Head_tenpo_cd".toUpperCase():	// ヘッダ店舗コード
			// 名称取得部品を起動
			V02001(getAdvControlFromItemID("Head_tenpo_cd"), getAdvControlFromItemID("Head_tenpo_nm"), getAdvControlFromItemID("Head_tenpo_cd"));

			// 明細部に入力がある場合、確認メッセージを表示
			var inputf = false;
			for (i = 0; i < detailcnt; i++) {
				var denno = getAdvControlFromItemID("M1denpyo_barcode", lineNo + 1).value;
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
		case "M1siiresaki_cd".toUpperCase():	// M１仕入先コード

			// 操作ありの背景色に変更
			commitColorSet(lineNo);

			// 名称取得部品を起動
			V02002(getAdvControlFromItemID("M1siiresaki_cd", lineNo), getAdvControlFromItemID("M1siiresaki_ryaku_nm", lineNo), getAdvControlFromItemID("M1siiresaki_cd", lineNo));

			siiresakiLength = getValue(getAdvControlFromItemID("M1siiresaki_cd", lineNo)).length;

			// 仕入先コードが空になった場合項目をクリア
			if (siiresakiLength == 0) {
				var clearColumns = {
					  "SIIRESAKI_RYAKU_NM": getAdvControlFromItemID("M1siiresaki_ryaku_nm", lineNo)	// Ｍ１仕入先名称
					, "BUMON_CD": getAdvControlFromItemID("M1bumon_cd", lineNo)						// Ｍ１部門コード
					, "BUMONKANA_NM": getAdvControlFromItemID("M1bumonkana_nm", lineNo)				// Ｍ１部門カナ名
					, "SITEINOHIN_YMD": getAdvControlFromItemID("M1nyukayotei_ymd", lineNo)			// Ｍ１入荷予定日
					, "SIIREYOTEIGOKEI_SU": getAdvControlFromItemID("M1nohin_su", lineNo)				// Ｍ１納品数
					, "SIIREYOTEIGOKEI_KIN": getAdvControlFromItemID("M1genka_kin", lineNo)			// Ｍ１原価金額
					, "KYAKUTYU_FLG": getAdvControlFromItemID("M1kyakucyu", lineNo)					// Ｍ１客注
					, "NEGAKIHIN_FLG": getAdvControlFromItemID("M1negaki", lineNo)						// Ｍ１値書
				};

				if (AjaxModel.dataClear) {
					resetResultColumns(clearColumns);
				}
			// 店舗コードが入力済で伝票バーコードが6桁入力されている場合
			} else if (tenpoCdLength == 4 && denpyoLength == 6) {

				// 丸め処理部品を起動
				formatDenpyoBarCode(getAdvControlFromItemID("M1denpyo_barcode", lineNo));

				// 名称表示
				// 検索条件指定(Key：固定、Value：検索値)
				var condition = {
					  "SIIRESAKI_CD": getAdvControlFromItemID("M1siiresaki_cd", lineNo)		// Ｍ１仕入先コード
					, "DENPYO_BARCODE": getAdvControlFromItemID("M1denpyo_barcode", lineNo)	// Ｍ１伝票バーコード
					, "TENPO_CD": getAdvControlFromItemID("Head_tenpo_cd")						// 店舗コード
				};
				// 戻り値指定(Key：SELECT句、Value：項目名)
				var result = {
					  "SIIRESAKI_CD": getAdvControlFromItemID("M1siiresaki_cd", lineNo)				// Ｍ１仕入先コード
					, "SIIRESAKI_RYAKU_NM": getAdvControlFromItemID("M1siiresaki_ryaku_nm", lineNo)	// Ｍ１仕入先名称
					, "BUMON_CD": getAdvControlFromItemID("M1bumon_cd", lineNo)						// Ｍ１部門コード
					, "BUMONKANA_NM": getAdvControlFromItemID("M1bumonkana_nm", lineNo)				// Ｍ１部門カナ名
					, "SITEINOHIN_YMD": getAdvControlFromItemID("M1nyukayotei_ymd", lineNo)			// Ｍ１入荷予定日
					, "SIIREYOTEIGOKEI_SU": getAdvControlFromItemID("M1nohin_su", lineNo)				// Ｍ１納品数
					, "SIIREYOTEIGOKEI_KIN": getAdvControlFromItemID("M1genka_kin", lineNo)			// Ｍ１原価金額
					, "KYAKUTYU_FLG": getAdvControlFromItemID("M1kyakucyu", lineNo)					// Ｍ１客注
					, "NEGAKIHIN_FLG": getAdvControlFromItemID("M1negaki", lineNo)						// Ｍ１値書
				};

				// 入荷予定情報取得部品を起動
				V02017(condition, result, getAdvControlFromItemID("M1denpyo_barcode"), true, lineNo);
			}
			break;
		case "M1denpyo_barcode".toUpperCase():	// M１伝票バーコード

			// 操作ありの背景色に変更
			commitColorSet(lineNo);

			// 丸め処理部品を起動
			formatDenpyoBarCode(getAdvControlFromItemID("M1denpyo_barcode", lineNo));

			denpyoLength = getValue(getAdvControlFromItemID("M1denpyo_barcode", lineNo)).length;

			// 伝票バーコードが空になった場合項目をクリア
			if (denpyoLength == 0) {

				var clearColumns = {
					  "BUMON_CD": getAdvControlFromItemID("M1bumon_cd", lineNo)						// Ｍ１部門コード
					, "BUMONKANA_NM": getAdvControlFromItemID("M1bumonkana_nm", lineNo)				// Ｍ１部門カナ名
					, "SITEINOHIN_YMD": getAdvControlFromItemID("M1nyukayotei_ymd", lineNo)			// Ｍ１入荷予定日
					, "SIIREYOTEIGOKEI_SU": getAdvControlFromItemID("M1nohin_su", lineNo)				// Ｍ１納品数
					, "SIIREYOTEIGOKEI_KIN": getAdvControlFromItemID("M1genka_kin", lineNo)			// Ｍ１原価金額
					, "KYAKUTYU_FLG": getAdvControlFromItemID("M1kyakucyu", lineNo)					// Ｍ１客注
					, "NEGAKIHIN_FLG": getAdvControlFromItemID("M1negaki", lineNo)						// Ｍ１値書
				};

				if (AjaxModel.dataClear) {
					resetResultColumns(clearColumns);
				}

			// 伝票バーコードが10桁入力されている場合、伝票バーコードが6桁で仕入先コードが入力されている場合
			} else if (tenpoCdLength == 4
					&& (   denpyoLength == 10
					   || (denpyoLength == 6 && siiresakiLength == 4))) {

				// 名称表示
				// 検索条件指定(Key：固定、Value：検索値)
				var condition = {
					"SIIRESAKI_CD": getAdvControlFromItemID("M1siiresaki_cd", lineNo)					// Ｍ１仕入先コード
					, "DENPYO_BARCODE": getAdvControlFromItemID("M1denpyo_barcode", lineNo)			// Ｍ１伝票バーコード
					, "TENPO_CD": getAdvControlFromItemID("Head_tenpo_cd", lineNo)						// 店舗コード
				};
				// 戻り値指定(Key：SELECT句、Value：項目名)
				var result = {
					"SIIRESAKI_CD": getAdvControlFromItemID("M1siiresaki_cd", lineNo)					// Ｍ１仕入先コード
					, "SIIRESAKI_RYAKU_NM": getAdvControlFromItemID("M1siiresaki_ryaku_nm", lineNo)	// Ｍ１仕入先名称
					, "BUMON_CD": getAdvControlFromItemID("M1bumon_cd", lineNo)						// Ｍ１部門コード
					, "BUMONKANA_NM": getAdvControlFromItemID("M1bumonkana_nm", lineNo)				// Ｍ１部門カナ名
					, "SITEINOHIN_YMD": getAdvControlFromItemID("M1nyukayotei_ymd", lineNo)			// Ｍ１入荷予定日
					, "SIIREYOTEIGOKEI_SU": getAdvControlFromItemID("M1nohin_su", lineNo)				// Ｍ１納品数
					, "SIIREYOTEIGOKEI_KIN": getAdvControlFromItemID("M1genka_kin", lineNo)			// Ｍ１原価金額
					, "KYAKUTYU_FLG": getAdvControlFromItemID("M1kyakucyu", lineNo)					// Ｍ１客注
					, "NEGAKIHIN_FLG": getAdvControlFromItemID("M1negaki", lineNo)						// Ｍ１値書
				};

				// 入荷予定情報取得部品を起動
				V02017(condition, result, getAdvControlFromItemID("M1denpyo_barcode"), true, lineNo);
			}

			break;
		// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

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
	var lineNo = getItemMNofromCtrl(eventTarget);

	switch (eventTargetName.toUpperCase()) {
	// ここに項目IDのcase文を追加し、固有処理を記述します。
	
		// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
		case "M1denpyo_barcode".toUpperCase():	// Ｍ１伝票バーコード

			if (ev.key == "Enter" && !ev.shiftKey) {

				// 仕入先コードのコピー
				if (lineNo + 1 < detailcnt) {

					if (getAdvControlFromItemID("M1siiresaki_cd", lineNo + 1).value == "") {

						getAdvControlFromItemID("M1siiresaki_cd", lineNo + 1).value = getValue(getAdvControlFromItemID("M1siiresaki_cd", lineNo));
						getAdvControlFromItemID("M1siiresaki_ryaku_nm", lineNo + 1).value = getValue(getAdvControlFromItemID("M1siiresaki_ryaku_nm", lineNo));
					}

					getAdvControlFromItemID("M1denpyo_barcode", lineNo + 1).focus();
				} else {

					// 名称取得のためフォーカスを移動して戻す
					getAdvControlFromItemID("M1denpyo_barcode", lineNo - 1).focus();
					getAdvControlFromItemID("M1denpyo_barcode", lineNo).focus();
				}

				return true;
			}

			break;
			// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

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
	var eventTargetName=getAdvEventTargetName(ev);
	switch (eventTargetName.toUpperCase()) {
	//	ここに項目IDのcase文を追加し、固有処理を記述します。
// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
		case "M1denpyo_barcode".toUpperCase():	// M１伝票バーコード

			var lineNo = getItemMNofromCtrl(eventTarget);

			// 丸め処理部品を起動
			formatDenpyoBarCode(getAdvControlFromItemID("M1denpyo_barcode", lineNo));
			break;
// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
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
		//	ここに項目IDのcase文を追加し、固有処理を記述します。
		case "M1btnsiiresaki_cd".toUpperCase():	// 仕入先コード検索

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
//// 入荷予定情報取得の出口ルーチン
function responseHandle_onAfter(lineNo) {

	// Ｍ１入荷予定日
	var NyukaYoteiYmd = getAdvControlFromItemID("M1nyukayotei_ymd", lineNo);
	NyukaYoteiYmd.value = getAdvFormatStr("M1nyukayotei_ymd", NyukaYoteiYmd.value);

	// Ｍ１納品数
	var Nohinsu = getAdvControlFromItemID("M1nohin_su", lineNo);
	Nohinsu.value = getAdvFormatStr("M1nohin_su", Nohinsu.value);

	// Ｍ１原価金額
	var GenkaKin = getAdvControlFromItemID("M1genka_kin", lineNo);
	GenkaKin.value = getAdvFormatStr("M1genka_kin", GenkaKin.value);

}
