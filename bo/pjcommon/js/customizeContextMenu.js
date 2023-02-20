// CustomizeContextMenu.js
// 使用方法
// 1) 組み込みたいhtmlファイルで本JSファイルを呼び出す。
// 2) Bodyタグ内の任意の場所に｢<div id="CustomizeContextMenu"></div>｣を記述する。
//	 （右クリックメニュー表示のために必要）
// 3) oncontextmenu イベントにOnRightButton()メソッド、
// 	  onclick イベントにOnLeftButton()メソッドを割り当てる。

var g_srcElement;
var g_selectTextBox;
var g_iStartPosition;
var g_iSelectLength;
var g_selectStr;

//---------------------------------------------------------------------
// 右クリック時に呼び出す関数。
// 位置情報の保存とカスタマイズメニューの表示を行う。
// BodyタグまたはJavascriptでロード時にイベントを割付けること。
//---------------------------------------------------------------------
function OnRightButton() {

	// 位置情報を保存する。
	storeCaret(event.srcElement);
	g_srcElement = event.srcElement;

	// 右クリック時の座標を取得し、カスタマイズメニューの始点に設定する。
	// カスタマイズメニューの大きさがウィンドウの右端または下端をはみ出す場合、
	// ウィンドウ内にカスタマイズメニューを表示する
	w_dif = document.body.clientWidth - 120;
	h_dif = document.body.clientHeight - 50;

	if(event.y >= h_dif){
		CustomizeContextMenu.style.top = document.body.scrollTop + event.y - 50;
	}else{
		CustomizeContextMenu.style.top = document.body.scrollTop + event.y;
	}
	if(event.x >= w_dif){
		CustomizeContextMenu.style.left = document.body.scrollLeft + event.x - 130;
	}else{
		CustomizeContextMenu.style.left = document.body.scrollLeft + event.x;
	}

	// カスタマイズメニューを表示する。
	CustomizeContextMenu.innerHTML =
		"<div><input type=button value='コピー' onClick='CopyClip()' style='width:100px;height:20px;border:0px;background-Color:Silver' onMouseOver='fnOnMouseOver(this)' onMouseOut='fnOnMouseOut(this)'></div>"
	  + "<div><input type=button value='貼り付け' onClick='insertAtCaret(g_srcElement)' style='width:100px;height:20px;border:0px;background-Color:Silver' onMouseOver='fnOnMouseOver(this)' onMouseOut='fnOnMouseOut(this)'></div>"
	  // 印刷を使用したい場合、下記記述をコメントインする。
	  //+ "<div><input type=button value='印刷' onClick='print()' style='width:100px;height:20px;border:0px;background-Color:Silver' onMouseOver='fnOnMouseOver(this)' onMouseOut='fnOnMouseOut(this)'></div>"
	if (CustomizeContextMenu.style.width < 100)
	{
		CustomizeContextMenu.style.width = 100;
	}
	// 印刷を追加する場合、下記サイズを40⇒60に変更する。
	if (CustomizeContextMenu.style.height < 40)
	{
		CustomizeContextMenu.style.height = 40;
	}
	CustomizeContextMenu.style.visibility = "visible";

	return false;
}

// メニューボタン上にマウスが置かれた場合に色を変更
function fnOnMouseOver(objButton)
{
	objButton.style.backgroundColor='navy';
	objButton.style.color="white";
}

// ボタン上からマウスが外れた場合に色を変更
function fnOnMouseOut(objButton)
{
	objButton.style.backgroundColor='Silver';
	objButton.style.color="black";
}


//---------------------------------------------------------------------
// 左クリック時に呼び出す関数。
// カスタマイズメニューを非表示にする。
// BodyタグまたはJavascriptでロード時にイベントを割付けること。
//---------------------------------------------------------------------
function OnLeftButton() {
	// カスタマイズメニューを非表示にする。
	CustomizeContextMenu.style.visibility = "hidden";
	CustomizeContextMenu.innerHTML = "";

	//return true;
}

//---------------------------------------------------------------------
// クリップボードにコピー
//---------------------------------------------------------------------
function CopyClip() {

	// テキストボックス、テキストエリアの場合、右クリックメニュー表示時の値を設定
	if (g_selectStr!=null && g_selectStr != "")
	{
		window.clipboardData.setData("Text", g_selectStr.valueOf());
	}
	else // HTMLを選択した場合、現在の選択状態を設定する。
	{
		// 現在の選択状態を取得
		strSelectText=document.selection.createRange().text;
		if (strSelectText!=null && strSelectText!="")
		{
			window.clipboardData.setData("Text", strSelectText);
		}
	}
}

//---------------------------------------------------------------------
// Caret（カーソル位置）情報を保存する。
// この関数をTextArea、またはInputbox<text>オブジェクトの
// Onclick、Onselect、及びOnkeyupイベント発生時に呼び出すこと。
// また、ダブルクリック時の単語選択にも対応する場合は
// Ondoubleclickイベント時にも同様に呼び出すこと。
//
// @param	[in] textEl	選択中のテキストエリア
//---------------------------------------------------------------------
function storeCaret (textEl) {

	// 変数の初期化
	tempTextBoxValue="";
	lastCaretPos =null;

	// テキストボックスオブジェクトの作成に成功したか？
	if (textEl.createTextRange	&& textEl.value != null) {

		// 選択しているテキスト範囲を取得
		lastCaretPos = document.selection.createRange().duplicate();

		//////////////////////////////////
		// コピー用処理
		g_selectStr = new String(lastCaretPos.text);
		//////////////////////////////////
		// 貼り付け用処理

		// 選択されている文字数を取得
		g_iSelectLength=lastCaretPos.text.length;



		if(textEl.tagName == "TEXTAREA")
		{
			textBody = document.body.createTextRange();
			textBody.moveToElementText(textEl);

			// テキストエリアの開始位置～カーソル位置までを選択状態にする。
			textBody.setEndPoint("EndToStart",lastCaretPos);
			//選択状態の文字列長を現在位置とする。
			g_iStartPosition = textBody.text.length;

			g_selectTextBox = textEl;
		}
		else
		{
			// 選択されている文字数を取得
			g_iSelectLength=lastCaretPos.text.length;

			// 選択位置を取得する為に選択を文字列最後まで選択
			lastCaretPos.moveEnd("textedit");
			g_iStartPosition=textEl.value.length - lastCaretPos.text.length;

			g_selectTextBox = textEl;

		}
	}

	// テキストボックス上で右クリックされていなかった場合は
	// 以前の選択状態をクリアする。
	else
	{
		g_selectStr = null;
	}

}

//---------------------------------------------------------------------
// Caret位置にクリップボードの内容を貼り付ける。
//---------------------------------------------------------------------
function insertAtCaret (src)
{

	clipBoardText="";	// クリップボードデータ保持変数

	// 選択されたオブジェクトがテキストボックスの場合のみ実行。
	if(src.tagName == "TEXTAREA" || (src.tagName == "INPUT" && ( src.type == "text" || src.type == "password" ) ) )
	{
		// テキストボックスがReadOnlyまたはDisabledの場合は処理しない。
		if(src.readOnly == true || src.disabled == true)
		{
			return;
		}

		document.selection.empty();

		clipBoardText = window.clipboardData.getData("Text");

		// クリップボードがセットされていない、または画像などが格納されている場合はリターン。
		if(clipBoardText == null)
		{
			return;
		}

		// 選択されている文字列をクリップボードの文字列に置き換える。
		// 文字列から直接部分削除ができないため、一度分解して再構成している。
		strStart = g_selectTextBox.value.substring(0,g_iStartPosition);
		strEnd = g_selectTextBox.value.substring(g_iStartPosition + g_iSelectLength, g_selectTextBox.value.length)

		g_selectTextBox.value = strStart + clipBoardText + strEnd;
		g_selectTextBox.focus();
	}
}

