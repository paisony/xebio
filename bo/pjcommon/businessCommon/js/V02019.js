/**
 * V02001 店舗マスタ、棚卸実施日データ取得

 *   呼出し例： V02001(getAdvControlFromItemID("id1"), getAdvControlFromItemID("name"), getAdvControlFromItemID("errId1"));
 * @param idCTL1 {Object} - 検索条件の値を取得するコントロール1(店舗コード) Object
 * @param nameCTL1 {Object} - 名称を設定するコントロール(店舗名称) Object
 * @param nameCTL2 {Object} - 日付を設定するコントロール() Object
 * @param nameCTL3 {Object} - 日付を設定するコントロール() Object
 * @param nameCTL4 {Object} - 日付を設定するコントロール() Object
 * @param nameCTL5 {Object} - 日付を設定するコントロール() Object
 * @param nameCTL6 {Object} - 日付を設定するコントロール() Object
 * @param nameCTL7 {Object} - 日付を設定するコントロール() Object
 * @param errCTL1 {Object} - コードが存在しない場合にエラー表示になるコントロール1 Object

 */
function V02019(idCTL1, nameCTL1, nameCTL2, nameCTL3, nameCTL4, nameCTL5, nameCTL6, nameCTL7, errCTL1) {

	// ロストフォーカス処理を実行 ※フォーマット処理を実行する為
//	onBlur_adv(idCTL1);
	idCTL1.value = getAdvFormat(idCTL1);

	// JSONのキーはSQLのバインドの変数と合わせる。
	var condition = 
	{
		"TENPO_CD": idCTL1

	};

	// コードが存在しない場合にエラー表示を行うコントロールの配列
	var errItem = 
	[
		errCTL1
	];

	// JSONのキーはSQLの選択のカラム名もしくはエイリアスと合わせる。
	var result    = 
	{
		"TANAOROSIJISSI_YMD_KONKAI": nameCTL2			,
		"TANAOROSIKIKAN_FROM_KONKAI": nameCTL3			,
		"TANAOROSIKIKAN_TO_KONAKI": nameCTL4			,
		"TANAOROSIJISSI_YMD_ZENKAI": nameCTL5			,
		"TANAOROSIKIKAN_FROM_ZENKAI": nameCTL6			,
		"TANAOROSIKIKAN_TO_ZENKAI": nameCTL7			,
		"TENPO_NM": nameCTL1							

	};
	var readOnly = null;
	searchCommonError(condition, errItem, result);

	// 部門名From名称取得時のイベント
	$(nameCTL1).bind('mdSetAfter', function () {
		// 棚卸実施日(今回)
		nameCTL2.value = getAdvFormat(nameCTL2);
		// イベント取得時の処理
		nameCTL3.value = getAdvFormat(nameCTL3);
		// イベント取得時の処理
		nameCTL4.value = getAdvFormat(nameCTL4);
		// イベント取得時の処理
		nameCTL5.value = getAdvFormat(nameCTL5);
		// イベント取得時の処理
		nameCTL6.value = getAdvFormat(nameCTL6);
		// イベント取得時の処理
		nameCTL7.value = getAdvFormat(nameCTL7);
	});

	V02019_INNER(condition, result, readOnly);
}

function V02019_INNER(condition, result, readOnly) {
	searchCommonInner_RO(condition, result, readOnly, "V02019.aspx");
}
