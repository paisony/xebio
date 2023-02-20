/**
 * V02018 返品指示データ取得
 *   呼出し例： V02018(getAdvControlFromItemID("id1"), getAdvControlFromItemID("id2"), getAdvControlFromItemID("name1"), getAdvControlFromItemID("name2"), getAdvControlFromItemID("errId1"));
 * @param idCTL1 {Object} - 検索条件の値を取得するコントロール1(店舗コード) Object
 * @param idCTL2 {Object} - 検索条件の値を取得するコントロール2(指示番号) Object
 * @param nameCTL1 {Object} - 名称を設定するコントロール(仕入先コード) Object
 * @param nameCTL2 {Object} - 名称を設定するコントロール(仕入先名称) Object
 * @param errCTL1 {Object} - コードが存在しない場合にエラー表示になるコントロール1 Object
 */
function V02018(idCTL1, idCTL2, nameCTL1, nameCTL2, errCTL1) {

	// ロストフォーカス処理を実行 ※フォーマット処理を実行する為
	idCTL1.value = getAdvFormat(idCTL1);
	idCTL2.value = getAdvFormat(idCTL2);

	// JSONのキーはSQLのバインドの変数と合わせる。
	var condition =
	{
		 "TENPO_CD": idCTL1
		,"SIJI_BANGO": idCTL2
	};

	// コードが存在しない場合にエラー表示を行うコントロールの配列
	var errItem =
	[
		 errCTL1
	];

	// JSONのキーはSQLの選択のカラム名もしくはエイリアスと合わせる。
	var result =
	{
		 "SIIRESAKI_CD": nameCTL1
		,"SIIRESAKI_RYAKU_NM": nameCTL2
	};
	var readOnly = null;
	searchCommonError(condition, errItem, result);
	$(nameCTL1).bind('mdSetAfter', function () {
		//
	});

	V02018_INNER(condition, result, readOnly);
}

function V02018_INNER(condition, result, readOnly) {
	searchCommonInner_RO(condition, result, readOnly, "V02018.aspx");
}
