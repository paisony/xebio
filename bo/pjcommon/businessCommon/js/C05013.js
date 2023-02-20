// BOJS共通定数
// ------------------------------------------------------------
// 共通項目名
// ------------------------------------------------------------
var clm_Mode = "Modeno";						// モードNo項目名
var clm_StkMode = "Stkmodeno";					// 選択モードNo項目名

var clm_M1SentakuFlg = "M1selectorcheckbox";	// ｍ１選択フラグ(隠し)
var clm_M1KakuteiFlg = "M1entersyoriflg";		// Ｍ１確定処理フラグ(隠し)
var clm_M1ColorFlg = "M1dtlirokbn";				// Ｍ１明細色区分(隠し)

var clm_ScanSearchDummyId = "scansearchdummyId";	// スキャンコード検索時のダミー項目


// ------------------------------------------------------------
// モードNo
// ------------------------------------------------------------
var c_insert = '1';						// 新規作成
var c_modekakutei = '2';				// 確定
var c_modenyukakakutei = '3';			// 入荷確定
var c_modesiirekakutei = '4';			// 仕入確定
var c_modehenpinkakutei = '5';			// 返品確定
var c_modeapply = '6';					// 申請
var c_modereapply = '7';				// 再申請
var c_modeupd = '8';					// 修正
var c_modekakuteimaeupd = '9';			// 確定前修正
var c_modekakuteigoupd = '10';			// 確定後修正
var c_modedel = '11';					// 取消
var c_modekakuteimaedel = '12';			// 確定前取消
var c_modekakuteigodel = '13';			// 確定後取消
var c_modesinseitorikesi = '14';		// 申請済取消
var c_modeteisei = '15';				// 訂正
var c_moderef = '16';					// 照会
var c_modelosskeisan = '17';			// ロス計算
var c_modelossdel = '18';				// ロス取消
var c_modelossref = '19';				// ロス照会
var c_modekessaijyokyo = '20';			// 決裁状況
var c_modesyuryokakuninref = '21';		// 終了確認照会
var c_modekonkai = '22';				// 今回
var c_modezenkai = '23';				// 前回
var c_modekeihisinsei = '24';			// 経費申請
var c_modescancd = '25';				// スキャンコード
var c_modejishahinban = '26';			// 自社品番
var c_modemakerhbn = '27';				// メーカー品番
var c_modesonota = '28';				// その他
var c_moderef_tanpin = '29';			// 照会単品別
var c_moderef_bumon = '30';				// 照会部門別
var c_modepercentoff = '31';			// ％OFF
var c_modeyenhiki = '32';				// 円引き
var c_modejisyahbnfukusu = '33';		// 自社品番(複数)
var c_modesinseimaeupd = '34';			// 申請前修正
var c_modesinseimaedel = '35';			// 申請前取消
var c_modesinseigodel = '36';			// 申請後取消
var c_modesinseizumitorikesi = '37'		// 申請取消
var c_moderef_torokurireki = '38'		// 登録履歴照会
var c_moderef_ringikekka = '39'			// 稟議結果照会

// ------------------------------------------------------------
// 伝票状態(仕入)
// ------------------------------------------------------------
var p_siire_denpyo_jotai1 = '1'			// 確定
var p_siire_denpyo_jotai2 = '2'			// 仕掛中
var p_siire_denpyo_jotai3 = '3'			// 未処理
var p_siire_denpyo_jotai4 = '4'			// ﾏﾆｭｱﾙ仕入
var p_siire_denpyo_jotai5 = '5'			// 差異あり
var p_siire_denpyo_jotai6 = '6'			// 登録履歴
var p_siire_denpyo_jotai7 = '7'			// 取消履歴

// ------------------------------------------------------------
// 開始状態(売変)
// ------------------------------------------------------------
var p_kaishi_jyotai1 = '1'				// 開始済
var p_kaishi_jyotai2 = '2'				// 開始予定

// ------------------------------------------------------------
// 移動入荷伝票状態(移動)
// ------------------------------------------------------------
var p_idonyuka_denpyo_jotai1 = '1'			// 確定
var p_idonyuka_denpyo_jotai2 = '2'			// 未処理
var p_idonyuka_denpyo_jotai3 = '3'			// 差異あり
var p_idonyuka_denpyo_jotai4 = '4'			// 登録履歴
var p_idonyuka_denpyo_jotai5 = '5'			// 取消履歴

// ------------------------------------------------------------
// 評価損種別区分
// ------------------------------------------------------------
var p_hyokasonsyubetsu_kb1 = '1'			// 経年品
var p_hyokasonsyubetsu_kb2 = '2'			// 販売不可

// ------------------------------------------------------------
// 会社コード
// ------------------------------------------------------------
var c_kaisya_cd_x = '1'					// X
var c_kaisya_cd_v = '2'					// V
