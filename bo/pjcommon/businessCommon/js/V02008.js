/**
 * V02008 商品群１マスタ取得取得
 *   呼出し例： V02005(getAdvControlFromItemID("id1"), getAdvControlFromItemID("name"), getAdvControlFromItemID("errId1"));
 * @param idCTL1 {Object} - 検索条件の値を取得するコントロール1(商品群１コード) Object
 * @param nameCTL {Object} - 名称を設定するコントロール(商品群１名) Object
 * @param errCTL1 {Object} - コードが存在しない場合にエラー表示になるコントロール1 Object
 */
function V02008_MAIN(idCTL1, nameCTL, errCTL1, delFlg) {

	// ロストフォーカス処理を実行 ※フォーマット処理を実行する為
//	onBlur_adv(idCTL1);
	idCTL1.value = getAdvFormat(idCTL1);

	// JSONのキーはSQLのバインドの変数と合わせる。
	var condition;
	if (delFlg == 1) {
		condition =
		{
			"SYOHINGUN1_CD": idCTL1
			, "SAKUJYO_FLG1": "0"
			, "SAKUJYO_FLG2": "0"
		};
	} else {
		condition =
		{
			"SYOHINGUN1_CD": idCTL1
			, "SAKUJYO_FLG1": "0"
			, "SAKUJYO_FLG2": "1"
		};
	}

	// コードが存在しない場合にエラー表示を行うコントロールの配列
	var errItem = 
	[
		errCTL1
	];

	// JSONのキーはSQLの選択のカラム名もしくはエイリアスと合わせる。
	var result    = 
	{
		"SYOHINGUN1_RYAKU_NM": nameCTL
	};
	var readOnly = null;
	searchCommonError(condition, errItem, result);
	$(nameCTL).bind('mdSetAfter', function () {
		// from-to項目の場合、名称コピー処理実行
		var id_last4 = nameCTL.id.substr(nameCTL.id.length - 4, 4);
		if (id_last4 == "from") {
			// イベント取得時の処理
			fromToCopyLbl(idCTL1.id.substr(0, idCTL1.id.length - 5), nameCTL.id.substr(0, nameCTL.id.length - 5));
		}
		nameCTL.value = getAdvFormat(nameCTL);
	});
	V02008_INNER(condition, result, readOnly);
}
function V02008(idCTL1, nameCTL, errCTL1) {
	V02008_MAIN(idCTL1, nameCTL, errCTL1, 1);
}

function V02008_INNER(condition, result, readOnly) {
	searchCommonInner_RO(condition, result, readOnly, "V02008.aspx");
}
