window.onload = g_onLoad;
window.onunload=g_onUnLoad;
var userClick = false;

//ロード処理
function g_onLoad() {
	//onLoadの共通事前処理
	g_onLoad_Before();

	$('.common').adjustHeight();

	//実装者のOnLoad処理
	onLoad();
	selectorCheckInit();

	try {
		//フォームはキャンセルさせない。
		document.forms[0].onreset = function(){;return false;};
	} catch (e) {
	}

    	$.extend(
    		window,
    		{
    		    getItemMNofromCtrl: function () { return getAdvItemMNofromCtrl(arguments[0]) - 1; }
    		}
    	);

	//	クライアントエラーメッセージの置き換え処理
	function ws3ClientMesssage(message) {
		openErrorDialog(message);
	}
	//window.alert = ws3ClientMesssage;

	//実行エラー（機能排他）
	try {
		if ($("#header_EXECERROR").get(0).value.length > 0)
		{
			if ($("#header_EXECERROR").get(0).value == "1") {
				alert(getMessage("E415",$("#header_EXECERRORID").get(0).value));
				EndProgramWindowClose($("#header_PGMID").get(0).value);
				//alert('39'); 
				window.close();
			}
		}
		if ($("#header_LOGINID").get(0).value.length > 1 && $("#header_TTSCD").get(0).value == "0")
		{
			alert(getMessage("E416") + "(ID:" + $("#header_LOGINID").get(0).value + ")");
			//alert('40'); 
			window.close();
		}
	} catch (e) {
	} 

    //Threadを使用した非同期処理の場合ポーリングさせる
    if(WaitingFlg === 'true'){
        sendRequest(ThreadId);
        //後続の処理はポーリング後のコールバックで実行させるのでここではリターン
        return;
    }else{
    	//更新件数確認画面を立ち上げる。
	    if(UpdateConfirmFlg === 'true'){
		    OpenUpdateConfirm();
	    }
    	//画面の有効化
	    showDisp();
    }

    $(".pager-01").show();
    $("#HIDE_PANEL").hide();
}

//共通の前処理
function g_onLoad_Before() {    

}


//アンロード処理
function g_onUnLoad() {

	//「Ｘ」終了処理
	if(document.body.clientWidth > 1000)
	{
		if (userClick != true)
		{
			if(event.clientX > 600 && event.clientY < 400) 
			{
				try {
					//終了ログ
					EndProgramWindowClose($("#header_PGMID").get(0).value);
				} catch (e) {
					EndProgramWindowClose("");
				} 
			}
		}
	}
	
	//実装者のOnUnload処理
	if (typeof onUnLoad == "function") {
		if (!onUnLoad()) {
			return false;
		}
	}
	
	return true;

	//onUnloadの共通後処理
	//return g_onUnLoad_After();
}

//サブミット処理
function g_onSubmit() {

	//Submit事前処理
	//if (!g_onSubmit_Before())
	//{
	//	return false;
    //}

	if (document.activeElement != undefined && document.activeElement.type == 'text') {
		//blur処理を行う
		onBlur_adv(document.activeElement);
	}
	
	//実装者のSubmit処理
	if (!onSubmit()) {
		return false;
	}
	
	//Ｘマーク用フラグ
	userClick = true;
	
	//ダイアログを出力するか、ＵＩブロックを出力するか判断する。    
	if(waitStatus.show()==1){
		screenLock();
	}else if(waitStatus.show()==2){
		createLoadingElement("loading");
	}else if(waitStatus.show()==3){
		screenLockOnly();
	}

	//ファイルアップロードが存在する場合、
	//すべてのボタンのリクエストでファイルがアップロードされないよう
	//ファイルのアップロードコントロールを無効化にする。
	//ファイルアップロードが存在するフォームにのみ設定する。
	try {
		if($(":file").length > 0){
			if(!$("#"+event.srcElement.id).hasClass("cmFup")){
				$(":file").attr("disabled","disabled").css("backgroundcolor","white");
			}
		}
	} catch (e) {
	    //idが取得できない場合、disabledにする。
	    try{
	        $(":file").attr("disabled","disabled").css("backgroundcolor","white");
	    }catch(e){
	    }
	} 

	StoreRequestAccordionStatus();
	
	RequestScrollPosition();
	
	return true;

	//Submit事後処理
	//return g_onSubmit_After();
}

//クリック処理 リンク・ボタン・Submit・ラジオボタン・チェックボックスなど
function g_onClick(ev) {
	//クリック事前処理
	//if (!g_onClick_Before(ev)) {
	//	return false;
	//}

	try {
			//ロード中の場合は、以降の処理を行わない。
	    if (!loaded) {
			return false ;
		}
		
		//クリックユーザー処理
		if (!onClick(ev)) {
			return false;
		}
	} catch (e) {
		//ファイルアップロードでセキュリティエラーが出た場合
		if (e.number=="-2147024891") {
			//"有効なファイルパスを指定して下さい。"
			alert(getMessage("E420"));

			//サブミットフラグ解除
			AdvGB_SubmitFLG=false;
		} else {
			throw e;
		}
		return false;
	}
	
	return true;

	//クリック事後処理
	//return g_onClick_After(ev);
}

//チェンジ処理 ドロップダウンリストなど
function g_onChange(ev) {

	//チェンジ事前処理
	//if (!g_onChange_Before(ev)) {
	//	return false;
	//}

	//チェンジユーザー処理
	if (!onChange(ev)) {
		return false;
	}

	return true;

	//チェンジ事後処理
	//return g_onChange_After(ev);
}

//キープレス処理

var listBoxFlg = false;

function g_onKeyPress(ev){

	//キープレス事前処理
	//if (!g_onKeyPress_Before(ev)) {
	//	return false;
	//}

	if(listBoxFlg){
		listBoxFlg = false;
		return false;
	}

	var isEndItem
			= (
				event.keyCode != undefined &&  event.keyCode == 13 && event.shiftKey == false && 
				document.activeElement != undefined && document.activeElement.type == 'text' &&
				document.activeElement == getAdvNextCtrl(document.activeElement)
			);

	$('#header #Tenpo_cd').attr('readonly', true);
	//キープレスユーザー処理
	if (!onKeyPress(ev)) {
		
		// 最終項目での処理
		if (isEndItem)
		{
			g_onFocus(document.activeElement);
			
			//document.activeElement.focus();
			
			return true;
		}
		
		return false;
	}
	$('#header #Tenpo_cd').attr('readonly', false);
	
	return true;

}

//フォーカス処理
function g_onFocus(ev) {

	var name = getAdvEventTarget(ev).id;
	if(name){
		var cs = $("#"+name).attr('class')
		if(cs){
			var reg = "txtDisabled|inpReadonlyLeft|inpReadonlyRight|inpReadonlyCenter";
			if(cs.match(reg)){
				window.focus();
				return false;
			}
		}
	}

	//フォーカスユーザー処理
	if (!onFocus(ev)) {
		return false;
	}

	return true;

	//フォーカス事後処理
	//return g_onFocus_After(ev);

}

//ブラー処理
function g_onBlur(ev) {


    var name = getAdvEventTarget(ev).id;
    if(name){
        if($("#"+name).hasClass("txtDisabled")||
            $("#"+name).hasClass("inpReadonlyLeft")||
            $("#"+name).hasClass("inpReadonlyRight")||
            $("#"+name).hasClass("inpReadonlyCenter")){
            return false;
        }
    }

	//ブラーユーザー処理
	if (!onBlur(ev)) {
		return false;
	}
	
	return true;

}

//コード参照親ウィンドウ時の値反映時のイベント
function g_onBeforeCodeSet(iDataArray,iItemId,iCodeId) {

	//コード参照親ウィンドウ反映事前処理
	//g_onBeforeCodeSet_Before(iDataArray,iItemId,iCodeId);

	//コード参照ウィンドウ反映ユーザー処理
	onBeforeCodeSet(iDataArray,iItemId,iCodeId);

	//コード参照ウィンドウ反映事後処理
	//g_onBeforeCodeSet_After(iDataArray,iItemId,iCodeId);

	return iDataArray;
}
