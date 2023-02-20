/*-----------------------------------------------------------------------------
	モジュール:te060f01_event_n.js
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
	md_te060f01_register();
	
	//共通ロード設定
	setCommonLoad();
	
    // ----------------------
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

		// 検索ボタン
        case "Btnsearch".toUpperCase():
            // モードが「修正」及び「取消」の場合、メッセージを出力
            if (getAdvControlFromItemID(clm_StkMode).value == c_modeupd
            || getAdvControlFromItemID(clm_StkMode).value == c_modedel) {

                // 確認メッセージを表示
                var yes = function () {
                    $("#Btnsearch")[0].click();
                }
                var no = function () {}
                var msg = getMessage("W113", "検索");

                //return boOpenInfoDialog(msg, yes, no);
                if (boOpenInfoDialog(msg, yes, no) == false) {
            		return false;
            	}
            }
        	// 防止期限をクリアする
            getAdvControlFromItemID("Stop_ymd").value = "";

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
		case "BTNMODEREF":
		case "BTNMODEUPD":
		case "BTNMODEDEL":
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
		case "Head_tenpo_cd".toUpperCase():	// ヘッダ店舗コード
			// 名称取得部品を起動
			V02001(getAdvControlFromItemID("Head_tenpo_cd"), getAdvControlFromItemID("Head_tenpo_nm"), getAdvControlFromItemID("Head_tenpo_cd"));
			break;
		case "Syohingun1_cd".toUpperCase():	// 商品群１
			// 名称取得部品を起動
			V02008_MAIN(getAdvControlFromItemID("Syohingun1_cd"), getAdvControlFromItemID("Syohingun1_ryaku_nm"), getAdvControlFromItemID("Syohingun1_cd"), 0);
			break;
		case "Siiresaki_cd".toUpperCase():	// 仕入先コード
			// 名称取得部品を起動
			V02002_MAIN(getAdvControlFromItemID("Siiresaki_cd"), getAdvControlFromItemID("Siiresaki_ryaku_nm"), getAdvControlFromItemID("Siiresaki_cd"), 0);
			break;
		case "Bumon_cd".toUpperCase():	// 部門コード
			// 名称取得部品を起動
			V02010_MAIN(getAdvControlFromItemID("Bumon_cd"), getAdvControlFromItemID("Bumon_nm"), getAdvControlFromItemID("Bumon_cd"), 0);
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
	case "Add_ymd_from".toUpperCase():	// 登録日FROM
		// FROMの値をTOへコピー
		fromToCopy("Add_ymd");
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

