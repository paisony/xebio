function fnKeySafe(){
	var keyCode=event.keyCode,tagName="",tagtype="";
	if(event.srcElement.tagName!=null)tagName=event.srcElement.tagName.toUpperCase();
	if(event.srcElement.type!=null)tagtype=event.srcElement.type.toUpperCase();

	if (event.shiftKey&&keyCode==120) {
		resizeWindow();
		return false;
	}

	if(event.keyCode==8&&!(tagName=="TEXTAREA"&&!event.srcElement.readOnly||tagName=="INPUT"&&(tagtype=="TEXT"&&!event.srcElement.readOnly||tagtype=="FILE"||tagtype=="PASSWORD"))){
		if(tagtype!="FILE")event.keyCode=0;
		return false
	}
	if (112 <= keyCode && keyCode <= 123) {
	    event.returnValue = false;
	    event.cancelBubble = true;
	    // アクションタイプがFUPの際はKeyCodeを上書きできない。
	    if (tagtype == "FILE") {
	        return false;
	    }
	    // 画面を終了するショートカットの抑制でCtrl+F4は抑制されているため、
	    // Ctrl+F4以外の場合のみfunctionキーを無効化する。
	    if (!(event.ctrlKey && event.keyCode == 115)) {
	        event.keyCode = 0;
	    }
	    return false;
	}
	if(event.ctrlKey&&(keyCode>=65&&keyCode<=90))if(keyCode!=67&&keyCode!=86&&keyCode!=88){
		event.keyCode=0;
		event.returnValue=false;
		return false
	}
	if(event.altKey&&(keyCode==37||keyCode==39||keyCode==36)){
		if(keyCode==36) alert("このショートカット操作は無効です");
		event.keyCode=0;
		event.returnValue=false;
		return false
	}
	if(event.ctrlKey&&(keyCode==187||keyCode==189)){
		event.keyCode=0;
		event.returnValue=false;
		return false
	}
	if(event.ctrlKey&&keyCode==13){
		event.keyCode=0;
		event.returnValue=false;
		return false
	}
	if(event.altKey&&keyCode==13){
		event.keyCode=37;
		event.returnValue=false;
		return false
	}
	try{
		if(keyCode==123){
			mdKeySafe="1";
			if(mdFunctionClickF12!="1"){
				JSSleep(500);
				mdFunctionClickF12="1"
			}
			else{
				mdFunctionClickF12="";
				event.keyCode=0;
				event.returnValue=false;
				return false
			}
		}
	}catch(e){
	}

	// CTRL+R キャンセル
	if (event.ctrlKey && keyCode==82)
	{
		//alert("ブラウザの機能による画面遷移や再読み込みは利用できません。");
		return false;
	}
	// CTRL+N 新規画面（同一セッションID）
	if (event.ctrlKey && keyCode==78)
	{
		//alert("ブラウザの機能による画面遷移や再読み込みは利用できません。");
		return false;
	}
	// ALT+→ ALT+← ALT+HOME キャンセル
	if (event.altKey && (keyCode==37 || keyCode==39 || keyCode==36))	
	{
		//alert("ブラウザの機能による画面遷移や再読み込みは利用できません。");
		return false;
	}
	// CTRL+'+' CTRL+"-" キャンセル
	if (event.ctrlKey && (keyCode==187 || keyCode==189))
	{
		//alert("ブラウザの機能による画面拡大・縮小は禁止です。");
		return false;
	}
	// CTRL+Enter キャンセル
	if (event.ctrlKey && (keyCode==13))
	{
		//alert("ブラウザの機能による最大化は禁止です。");
		return false;
	}
	// BACKSPACE キャンセル
	if ($("input:focus,textarea:focus").length == 0 && keyCode==8)
	{
		return false;
	}

}

document.onkeydown=fnKeySafe;
function fnFalse(){return false}
document.oncontextmenu=fnFalse;
document.ondragstart=fnFalse
window.onhelp = fnFalse;

