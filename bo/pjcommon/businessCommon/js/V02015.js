/**
 * V02015 名称マスタ取得
 *   呼出し例：
 *     // 名称コード項目に対し、必要に応じてフォーマット処理を実施
 *     var meisyoCd = xxxxFormat(getAdvControlFromItemID("id1").value);
 *     V02015("XXXX", meisyoCd, "MEISYO_NM", getAdvControlFromItemID("nameId"), getAdvControlFromItemID("errId1"));
 * @param sikibetsuCd	{string} - 識別コード
 * @param meisyoCd		{string} - 名称コード
 * @param column		{string} - 取得する名称項目のカラム名
 * @param nameCTL		{Object} - 名称を設定するコントロール(名称名) Object
 * @param errCTL1		{Object} - コードが存在しない場合にエラー表示になるコントロール1 Object
 */
function V02015_MAIN(sikibetsuCd, meisyoCd, column, nameCTL, errCTL1, delFlg) {

	// 識別コードのコントロール
	var sikibetsuCTL = document.createElement("input");
	sikibetsuCTL.value = sikibetsuCd;

	// 名称コードのコントロール
	var meisyoCTL = document.createElement("input");
	meisyoCTL.value = meisyoCd;

	// JSONのキーはSQLのバインドの変数と合わせる。
	var condition;
	if (delFlg == 1) {
		condition =
		{
			"SIKIBETSU_CD": sikibetsuCTL
			, "MEISYO_CD": meisyoCTL
			, "SAKUJYO_FLG1": "0"
			, "SAKUJYO_FLG2": "0"
		};
	} else {
		condition =
		{
			"SIKIBETSU_CD": sikibetsuCTL
			, "MEISYO_CD": meisyoCTL
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
	var result = {};
	result[column] = nameCTL;

	var readOnly = null;
	searchCommonError(condition, errItem, result);
	V02015_INNER(condition, result, readOnly);
}
function V02015(sikibetsuCd, meisyoCd, column, nameCTL, errCTL1) {
	V02015_MAIN(sikibetsuCd, meisyoCd, column, nameCTL, errCTL1, 1);
}

function V02015_INNER(condition, result, readOnly) {
	searchCommonInner_RO(condition, result, readOnly, "V02015.aspx");
}
