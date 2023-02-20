/**
 * V02025 振替申請理由から科目取得
 *   呼出し例：
 *     V02025(getAdvControlFromItemID("Sinseiriyu_kb"), getAdvControlFromItemID("Kamoku_cd"), getAdvControlFromItemID("Kamoku_nm"), null);
 * @param idCTL			{Object} - 検索条件の値を取得するコントロール(ブランドコード) Object
 * @param nameCTL1		{Object} - 科目コードを設定するコントロール(名称名) Object
 * @param nameCTL2		{Object} - 科目名を設定するコントロール(名称名) Object
 * @param errCTL		{Object} - コードが存在しない場合にエラー表示になるコントロール Object
 */
function V02025_MAIN(idCTL, nameCTL1, nameCTL2, errCTL, delFlg) {

//	// 名称コードのコントロール
	var sinseiCTL = document.createElement("input");
	sinseiCTL.value = idCTL.value;

	// JSONのキーはSQLのバインドの変数と合わせる。
	var condition;
	if (delFlg == 1) {
		condition =
		{
			"KEIHISINSEI_KB": sinseiCTL
			, "SAKUJYO_FLG1": "0"
			, "SAKUJYO_FLG2": "0"
		};
	} else {
		condition =
		{
			"KEIHISINSEI_KB": sinseiCTL
			, "SAKUJYO_FLG1": "0"
			, "SAKUJYO_FLG2": "1"
		};
	}

	// コードが存在しない場合にエラー表示を行うコントロールの配列
	var errItem = 
	[
		errCTL
	];

	// JSONのキーはSQLの選択のカラム名もしくはエイリアスと合わせる。
	var result    = 
	{
		"KAMOKU_CD": nameCTL1,
		"KAMOKU_NM": nameCTL2
	};
	var readOnly = null;
	searchCommonError(condition, errItem, result);
	V02025_INNER(condition, result, readOnly);
}
function V02025(idCTL, nameCTL1, nameCTL2, errCTL) {
	V02025_MAIN(idCTL, nameCTL1, nameCTL2, errCTL, 1);
}

function V02025_INNER(condition, result, readOnly) {
	searchCommonInner_RO(condition, result, readOnly, "V02025.aspx");
}
