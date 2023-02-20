﻿/*-----------------------------------------------------------------------------
	モジュール:md_tf030f02_register.js
--------------------------------------------------------------------------------*/
/*<title>[画面02CLイベントScript]</title>*/


function md_tf030f02_register(){

	/****無効にするのは禁止（START）**********************************/
	
    //表題時間表示
    DynamicClock();
    
    //カレンダー登録
    Calendar();
    
    //エラーメッセージダイアログ再表示
    RedisplayWarningField();
    
    //ReadonlyのTextBoxフォーカス制御を無効に処理です
    DisableTXRFocus();
    
    /****無効にするのは禁止（END）***********************************/
    
    
    
    /*アコーディオン処理
    * 詳細は実装方式を参照してください。
    *   引数："アコーディオンイベントエレメントID" , "アコーディオン効果エリアエレメントID" , "連動している明細部ID"
    */
    //Accordion("accodEventId", "condtionTbl", "M1");
    
    /**スクロール位置制御処理
    *（スクロール表示位置を保持したい場合、コメントアウトをはずしてください）
    * (引数について、カンマ区切りで明細部枠のパネルIDを記述してください。)
    * (例：resetScrollPositionToDetail("M1Body" , "M2Body" , …… ,……)
    */
    //ResetScrollPositionToDetail();
    
    /**MDリストボックス
    *1.機能有効にしたい場合、コメントアウトをはずしてください
    *2.ListBoxが対象となる項目のCssClassに【cmListBox】を追加してください。
    */
    //mdListBox();
    
    /**項目ToolTips表示
    *項目のToolTipsを表示したい場合、コメントアウトをはずしてください
    *対象となる対象となる項目のCssClassに【cmInputToolTips】を追加してください。
    */
    //ShowInputToolTips();
    
    /**
    *機能間関連(子画面機能で実装)
    *子画面は親画面に自分自身のハンドルを通知し、最新化イベントを実行する
    *親フォームＩＤ　最新化ボタンID
    *機能を有効したい場合、コメントアウトを外し、パラメータを設定してください。
    */
    //fireFather(親フォームＩＤ,最新化ボタンID);
    
}
