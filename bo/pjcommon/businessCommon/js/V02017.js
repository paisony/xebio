/**
 * V02017 仕入入荷予定(H)トラン取得
 *	 呼出し例： 
 *			// 検索条件指定(Key：固定、Value：検索値)
 *			var condition = {
 *				  "SIIRESAKI_CD": getAdvControlFromItemID("M1siiresaki_cd")		// Ｍ１仕入先コード
 *				, "DENPYO_BARCODE": getAdvControlFromItemID("M1denpyo_barcode")	// Ｍ１伝票バーコード
 *				, "TENPO_CD": getAdvControlFromItemID("Head_tenpo_cd")				// 店舗コード
 *			};
 *			// 戻り値指定(Key：SELECT句、Value：項目名)
 *			var result = {
 *				  "SIIRESAKI_CD": getAdvControlFromItemID("M1siiresaki_cd")				// Ｍ１仕入先コード
 *				, "SIIRESAKI_RYAKU_NM": getAdvControlFromItemID("M1siiresaki_ryaku_nm")	// Ｍ１仕入先名称
 *				, "BUMON_CD": getAdvControlFromItemID("M1bumon_cd")						// Ｍ１部門コード
 *				, "BUMONKANA_NM": getAdvControlFromItemID("M1bumonkana_nm")				// Ｍ１部門カナ名
 *				, "SITEINOHIN_YMD": getAdvControlFromItemID("M1nyukayotei_ymd")			// Ｍ１入荷予定日
 *				, "SIIREYOTEIGOKEI_SU": getAdvControlFromItemID("M1nohin_su")				// Ｍ１納品数
 *				, "SIIREYOTEIGOKEI_KIN": getAdvControlFromItemID("M1genka_kin")			// Ｍ１原価金額
 *				, "KYAKUTYU_FLG": getAdvControlFromItemID("M1kyakucyu")					// Ｍ１客注
 *				, "NEGAKIHIN_FLG": getAdvControlFromItemID("M1negaki")						// Ｍ１値書
 *			};
 *	
 *			// 名称取得部品
 *			V02017(condition, result, getAdvControlFromItemID("M1scan_cd", lineNo), true, lineNo);
 * 
 * @param condition {Object} - 検索条件
 * @param nameCTL {Object} - 名称を設定するコントロール(商品情報) Object
 * @param errCTL1 {Object} - コードが存在しない場合にエラー表示になるコントロール1 Object
 */
function V02017(condition
				, result
				, errCTL1
				, calcF
				, row
				) {

	// コードが存在しない場合にエラー表示を行うコントロールの配列
	var errItem;
	if(errCTL1.length <= 1) {
		errItem =
		[
			errCTL1
		];
	} else {
		errItem =	errCTL1
	}

	var bksiireSakiCd = getAdvControlFromItemID("M1siiresaki_cd", row).value;
	var bksiireSakiNm = getAdvControlFromItemID("M1siiresaki_ryaku_nm", row).value;

	searchCommonError(condition, errItem, result);

	V02017_INNER(condition, result, calcF, row);

	getAdvControlFromItemID("M1siiresaki_cd", row).value = bksiireSakiCd;
	getAdvControlFromItemID("M1siiresaki_ryaku_nm", row).value = bksiireSakiNm;

}

function V02017_INNER(condition, result, calcF, row) {
	searchCommonInner_RO_BO(condition, result, calcF, row, "V02017.aspx");
}
