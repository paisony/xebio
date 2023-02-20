/*-----------------------------------------------------------------------------
	モジュール:ti040f01_event_n.js
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
	md_ti040f01_register();
	
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
	        detailHide();
			AdvGB_LastClickItemNm = null;
			return false;
		}
	}

	// ここに業務固有チェック処理を記述します。
	switch (AdvGB_LastClickItemNm.toUpperCase()) {

	    // 検索ボタン
	    case "BTNSEARCH":
	        var maxrow = getAdvMaxMRow(1);
	        //if (AdvGB_TargetForm.elements.length > 0) {
	        if (maxrow > 0) {
	            // ワーニングメッセージを表示
	            var yes = function () {
	                $("#Btnsearch")[0].click();
	            }
	            var no = function () {
	            }
	            var msg = getMessage("W113", "検索");

	            return boOpenInfoDialog(msg, yes, no);
	        }

	        break;

	    // 確定ボタン
	    case "BTNENTER":
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
	switch (eventTargetName.toUpperCase()) {
	//  ここに項目IDのcase文を追加し、固有処理を記述します。

	    case "Head_tenpo_cd".toUpperCase():	// ヘッダ店舗コード
	        // 名称取得部品を起動
	        V02001(getAdvControlFromItemID("Head_tenpo_cd"), getAdvControlFromItemID("Head_tenpo_nm"), getAdvControlFromItemID("Head_tenpo_cd"));
	        break;

	    // -------------------
	    // ｍ１ラベル発行機ｉｄ
	    // ｍ１ラベル発行機ｉｐ
	    // ｍ１ラベル発行機名
	    // ｍ１ラベル備考
	    // -------------------
	    case "M1label_cd".toUpperCase():
	    case "M1label_cd2".toUpperCase():
	    case "M1label_ip".toUpperCase():
	    case "M1label_ip2".toUpperCase():
	    case "M1label_ip3".toUpperCase():
	    case "M1label_ip4".toUpperCase():
	    case "M1label_nm".toUpperCase():
	    case "M1label_biko".toUpperCase():

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

	    case "Label_cd_from2".toUpperCase():	// ラベル発行機IDFROM2
	        // FROMの値をTOへコピー
	        var from1Obj = getAdvControlFromItemID("Label_cd_from");
	        var from2Obj = getAdvControlFromItemID("Label_cd_from2");

	        var to1Obj = getAdvControlFromItemID("Label_cd_to");
	        var to2Obj = getAdvControlFromItemID("Label_cd_to2");

	        if (to1Obj.value == "" && to2Obj.value == "") {
	            to1Obj.value = from1Obj.value;
	            to2Obj.value = from2Obj.value;

	            // TOのロストフォーカス処理を実行 ※フォーマット処理を実行する為
	            onBlur_adv(to1Obj);
	            onBlur_adv(to2Obj);
            }
	        break;
	    case "Label_ip_from4".toUpperCase():	// ラベル発行機IPFROM4
	        // FROMの値をTOへコピー
	        var from1Obj = getAdvControlFromItemID("Label_ip_from");
	        var from2Obj = getAdvControlFromItemID("Label_ip_from2");
	        var from3Obj = getAdvControlFromItemID("Label_ip_from3");
	        var from4Obj = getAdvControlFromItemID("Label_ip_from4");

	        var to1Obj = getAdvControlFromItemID("Label_ip_to");
	        var to2Obj = getAdvControlFromItemID("Label_ip_to2");
	        var to3Obj = getAdvControlFromItemID("Label_ip_to3");
	        var to4Obj = getAdvControlFromItemID("Label_ip_to4");

	        if (to1Obj.value == "" && to2Obj.value == "" && to3Obj.value == "" && to4Obj.value == "") {
	            to1Obj.value = from1Obj.value;
	            to2Obj.value = from2Obj.value;
	            to3Obj.value = from3Obj.value;
	            to4Obj.value = from4Obj.value;

	            // TOのロストフォーカス処理を実行 ※フォーマット処理を実行する為
	            onBlur_adv(to1Obj);
	            onBlur_adv(to2Obj);
	            onBlur_adv(to3Obj);
	            onBlur_adv(to4Obj);
            }
	        break;

	    //// -------------------
	    //// ｍ１ラベル発行機ｉｄ
	    //// ｍ１ラベル発行機ｉｐ
	    //// ｍ１ラベル発行機名
	    //// ｍ１ラベル備考
	    //// -------------------
	    //case "M1label_cd".toUpperCase():
	    //case "M1label_cd2".toUpperCase():
	    //case "M1label_ip".toUpperCase():
	    //case "M1label_ip2".toUpperCase():
	    //case "M1label_ip3".toUpperCase():
	    //case "M1label_ip4".toUpperCase():
	    //case "M1label_nm".toUpperCase():
	    //case "M1label_biko".toUpperCase():

	    //    // 明細行番号を取得する
	    //    var lineNo = getAdvItemMNofromCtrl(eventTarget);

	    //    // 操作ありの背景色に変更
	    //    commitColorSet(lineNo);

	    //    break;
	
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

