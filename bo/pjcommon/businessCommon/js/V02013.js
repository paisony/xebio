/**
 * V02013 色マスタ取得取得
 *   呼出し例： V02013(getAdvControlFromItemID("id1"), getAdvControlFromItemID("name"), getAdvControlFromItemID("errId1"));
 * @param idCTL1 {Object} - 検索条件の値を取得するコントロール1(ブランドコード) Object
 * @param nameCTL {Object} - 名称を設定するコントロール(ブランド名) Object
 * @param errCTL1 {Object} - コードが存在しない場合にエラー表示になるコントロール1 Object
 */
function V02013_MAIN(idCTL1, nameCTL, errCTL1, delFlg) {

	// ロストフォーカス処理を実行 ※フォーマット処理を実行する為
//	onBlur_adv(idCTL1);
	idCTL1.value = getAdvFormat(idCTL1);

	// JSONのキーはSQLのバインドの変数と合わせる。
	var condition;
	if (delFlg == 1) {
		condition =
		{
			"IRO_CD": idCTL1
			, "SAKUJYO_FLG1": "0"
			, "SAKUJYO_FLG2": "0"
		};
	} else {
		condition =
		{
			"IRO_CD": idCTL1
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
		"IRO_NM": nameCTL
	};
	var readOnly = null;
	searchCommonError(condition, errItem, result);
	V02013_INNER(condition, result, readOnly);
}
function V02013(idCTL1, nameCTL, errCTL1) {
	V02013_MAIN(idCTL1, nameCTL, errCTL1, 1);
}

function V02013_INNER(condition, result, readOnly) {
	searchCommonInner_RO(condition, result, readOnly, "V02013.aspx");
}
