// KeySafe.js
// キーでの再更新・戻るなどを防ぐ 、右クリックメニューを表示させない。
// (includeするだけでOK)
// All Rights Reserved, Copyright (c) FUJITSU SYSTEM SOLUTIONS LIMITED 2006-
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
// 改版履歴
// 2004/07/02  Fsol  新規作成
// 2004/09/30  Fsol  INPUT FILEに対処
// 2005/08/19  Fsol  ReadOnlyテキストボックスのBSキーに対応(disabledの場合は条件を追加しなくてもBSが効かないことを確認)
// 2005/09/14  Fsol  includeするだけで機能が働くように変更
// 2007/12/05  Fsol  ReadOnlyテキストエリアのBSキーに対応
// 2009/10/01  Fsol  他国語対応
// 2009/10/19  Fsol  連絡票対応(DW5-000018)：クライアントメッセージを取得するメソッドを変更

//ショートカットキーの入力を無効にする
function fnKeySafe() { 

	var keyCode=event.keyCode;	// キーコードを取得
	var tagName="";
	var tagtype="";
	
	// BackSpace対応でTEXTAREAとTEXTを使えるようタイプを取得
	if (event.srcElement.tagName!=null)
	{
		tagName=event.srcElement.tagName.toUpperCase();
	}
	if (event.srcElement.type!=null)
	{
		tagtype=event.srcElement.type.toUpperCase();
	}
	
	
	if(112<=keyCode && keyCode<=123	||		// functionキー全てをキャンセルする(F1は有効)
		//BackSpaceをキャンセル
		(event.keyCode == 8 && 
			!((tagName=='TEXTAREA' && (!event.srcElement.readOnly)) ||
				(tagName == "INPUT" && 
				 ((tagtype == 'TEXT' && (!event.srcElement.readOnly))	|| tagtype == 'FILE' || tagtype == 'PASSWORD')))))
	{
		if (tagtype == 'FILE')
		{
			//alert("ブラウザの機能による画面遷移や再読み込みは利用できません。");
			//alert(getQuiQplusMessage("L995"));
		}
		else
		{
			event.keyCode = 0;
		}
		return false;
	}
	
	// CTRL+R キャンセル
	if (event.ctrlKey && keyCode==82)
	{
		//alert("ブラウザの機能による画面遷移や再読み込みは利用できません。");
		//alert(getQuiQplusMessage("L995"));
		return false;
	}
	// CTRL+N 新規画面（同一セッションID）
	if (event.ctrlKey && keyCode==78)
	{
		//alert("ブラウザの機能による画面遷移や再読み込みは利用できません。");
		//alert(getQuiQplusMessage("L995"));
		return false;
	}
	// ALT+→ ALT+← ALT+HOME キャンセル
	if (event.altKey && (keyCode==37 || keyCode==39 || keyCode==36))	
	{
		if(keyCode==36) alert("このショートカット操作は無効です");
		//alert("ブラウザの機能による画面遷移や再読み込みは利用できません。");
		//alert(getQuiQplusMessage("L995"));
		return false;
	}
	// CTRL+'+' CTRL+"-" キャンセル
	if (event.ctrlKey && (keyCode==187 || keyCode==189))
	{
		//alert("ブラウザの機能による画面拡大・縮小は禁止です。");
		//alert(getQuiQplusMessage("L996"));
		return false;
	}
	// CTRL+Enter キャンセル
	if (event.ctrlKey && (keyCode==13))
	{
		//alert("ブラウザの機能による最大化は禁止です。");
		//alert(getQuiQplusMessage("L994"));
		return false;
	}
	// 20161028 望月修正 テキスト内でも効かなくなってしまう ----- START
	// BACKSPACE キャンセル
	//if (keyCode==8)
	//{
	//	return false;
	//}
	// 20161028 望月修正 テキスト内でも効かなくなってしまう ----- END
}

//falseを返す
//2005/09/14追加
function fnFalse(){
	return false;
}
//onkeydownイベントに処理を割り付ける
//2005/09/14追加
document.onkeydown=fnKeySafe;
//コンテキストメニューの表示を防止する
//2005/09/14追加
document.oncontextmenu=fnFalse;
window.onhelp = fnFalse;
