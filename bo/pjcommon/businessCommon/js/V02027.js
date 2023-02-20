/**
 * V02027 担当者マスタ・店舗マスタ取得
 *	 呼出し例： 
 *			// 検索条件指定(Key：固定、Value：検索値)
 *			var condition = {
 *				  "HANBAIIN_CD": getAdvControlFromItemID("M1tan_cd")				// Ｍ１担当者コード
 *			};
 *			// 戻り値指定(Key：SELECT句、Value：項目名)
 *			var result = {
 *				  "HANBAIIN_CD": getAdvControlFromItemID("M1tan_cd")				// Ｍ１担当者コード
 *				, "HANBAIIN_NM": getAdvControlFromItemID("M1tan_nm")				// Ｍ１担当者名称
 *				, "HANBAIINTENPO_CD": getAdvControlFromItemID("M1moto_tenpo_cd")	// Ｍ１元店舗コード
 *				, "TENPO_NM": getAdvControlFromItemID("M1moto_tenpo_nm")			// Ｍ１元店舗名称
 *				, "UPD_YMD": getAdvControlFromItemID("M1upd_ymd")					// Ｍ１更新日(隠し)
 *				, "UPD_TM": getAdvControlFromItemID("M1upd_tm")					// Ｍ１更新時間(隠し)
 *			};
 *	
 *			// 名称取得部品
 *			V02027(condition, result, getAdvControlFromItemID("M1tan_cd", lineNo), true, lineNo);
 * 
 * @param condition {Object} - 検索条件
 * @param nameCTL {Object} - 名称を設定するコントロール(商品情報) Object
 * @param errCTL1 {Object} - コードが存在しない場合にエラー表示になるコントロール1 Object
 */
function V02027(condition
				, result
				, errCTL1
				, calcF
				, row
				) {

	if (condition["HANBAIIN_CD"].value == "") {
		// 未入力の場合

		// 名称項目クリア
		resetResultColumns(result);

		// [onAfter]がある、かつcalcFがtrueの場合、後処理を実行する。
		if (typeof responseHandle_onAfter == "function"
			&& calcF) {
			// スキャンコード名称取得の出口ルーチン呼出
			responseHandle_onAfter(row);
		}

		return;
	}

	if (result == null) {
		// 取得結果の設定情報が指定されなかった場合
		result = {
			"HANBAIIN_CD": document.getElementById(clm_ScanSearchDummyId)	// ダミーID
		}
	}

	// コードが存在しない場合にエラー表示を行うコントロールの配列
	var errItem = 
	[
		errCTL1
	];

	searchCommonError(condition, errItem, result);
	V02027_INNER(condition, result, calcF, row);

}

function V02027_INNER(condition, result, calcF, row) {
	searchCommonInner_RO_BO(condition, result, calcF, row, "V02027.aspx");
}
