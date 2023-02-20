/**
 * V02004 発注マスタ取得(スキャンコード)
 *   呼出し例： 
 *  		// 検索条件指定(Key：固定、Value：検索値)
 *  		var condition = {
 *  			 "SCAN_CD"			: getAdvControlFromItemID("M1scan_cd", lineNo)
 *  			,"TENPO_CD"			: getAdvControlFromItemID("Head_tenpo_cd")
 *  			,"PLUFLG"			: "0"
 *  			,"PRICEFLG"			: "0"
 *  			,"ZAIKOFLG"			: "0"
 *  			,"NYUKAFLG"			: "0"
 *  			,"URIFLG"			: "0"
 *  			,"HOJUFLG"			: "0"
 *  			,"TANPINFLG"		: "0"
 *  			,"SIJIFLG"			: "0"
 *  			,"SIJI_NO"			: "0"
 *  			,"SYUKAKAISYA_CD"	: "0"
 *  			,"NYUKAKAISYA_CD"	: "0"
 *  			,"SYUKATENPO_CD"	: "0"
 *  		};
 *  		// 戻り値指定(Key：SELECT句、Value：項目名)
 *  		var result = {
 *  			 "HINSYU_RYAKU_NM": getAdvControlFromItemID("M1hinsyu_ryaku_nm", lineNo)	// 品種
 *  			, "XEBIO_CD": getAdvControlFromItemID("M1jisya_hbn", lineNo)				// 自社品番
 *  			, "HIN_NBR": getAdvControlFromItemID("M1maker_hbn", lineNo)				// メーカー品番
 *  			, "SYONMK": getAdvControlFromItemID("M1syonmk", lineNo)					// 商品名
 *  			, "IRO_NM": getAdvControlFromItemID("M1iro_nm", lineNo)					// 色
 *  			, "SIZE_NM": getAdvControlFromItemID("M1size_nm", lineNo)					// サイズ
 *  			, "GENKA": getAdvControlFromItemID("M1gen_tnk", lineNo)					// 原価
 *  		};
 *  
 *  		// 名称取得部品
 *  		V02004(condition, result, getAdvControlFromItemID("M1scan_cd", lineNo), true, lineNo);
 * 
 * @param condition {Object} - 検索条件
 * @param nameCTL {Object} - 名称を設定するコントロール(商品情報) Object
 * @param errCTL1 {Object} - コードが存在しない場合にエラー表示になるコントロール1 Object
 */
function V02004(condition
				, result
				, errCTL1
				, calcF
				, row
				) {

	if (condition["SCAN_CD"].value == "") {
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
			"JAN_CD": document.getElementById(clm_ScanSearchDummyId)	// ダミーID
		}
	}

	// コードが存在しない場合にエラー表示を行うコントロールの配列
	var errItem = 
	[
		errCTL1
	];

	searchCommonError(condition, errItem, result);
	V02004_INNER(condition, result, calcF, row);

}

function V02004_INNER(condition, result, calcF, row) {
	searchCommonInner_RO_BO(condition, result, calcF, row, "V02004.aspx");
}
