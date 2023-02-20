/**
 * V02020 移動指示データ取得
 *   呼出し例： V02020(getAdvControlFromItemID("id1"), getAdvControlFromItemID("id2"), getAdvControlFromItemID("id2"), getAdvControlFromItemID("name"), getAdvControlFromItemID("errId1"), getAdvControlFromItemID("errId2"));
 * @param idCTL1 {Object} - 検索条件の値を取得するコントロール1(出荷会社コード) Object
 * @param idCTL2 {Object} - 検索条件の値を取得するコントロール2(出荷店舗コード) Object
 * @param idCTL3 {Object} - 検索条件の値を取得するコントロール3(指示番号) Object
 * @param nameCTL1 {Object} - 名称を設定するコントロール(入荷会社コード) Object
 * @param nameCTL2 {Object} - 名称を設定するコントロール(入荷会社名称) Object
 * @param nameCTL3 {Object} - 名称を設定するコントロール(入荷店舗コード) Object
 * @param nameCTL4 {Object} - 名称を設定するコントロール(入荷店舗名称) Object
 * @param errCTL1 {Object} - コードが存在しない場合にエラー表示になるコントロール1 Object
 * @param errCTL2 {Object} - コードが存在しない場合にエラー表示になるコントロール2 Object
 * @param errCTL3 {Object} - コードが存在しない場合にエラー表示になるコントロール3 Object
 */
function V02020(idCTL1, idCTL2, idCTL3, nameCTL1, nameCTL2, nameCTL3, nameCTL4, errCTL1, errCTL2, errCTL3) {

	// ロストフォーカス処理を実行 ※フォーマット処理を実行する為
//	onBlur_adv(idCTL1);
//	onBlur_adv(idCTL2);
	//	onBlur_adv(idCTL3);
	if (typeof idCTL1 == "object" && idCTL1.length != undefined) {
		idCTL1.value = getAdvFormat(idCTL1);
	}
	idCTL2.value = getAdvFormat(idCTL2);
	idCTL3.value = getAdvFormat(idCTL3);

	// 指示番号から入荷会社、店舗コードを取得
	formatSijinoIdou(idCTL3);
	var sijiNo = idCTL3.value;	// 指示番号
	var nyukakaisyacd = '';		// 入荷会社コード
	var nyukatencd = '';		// 入荷店コード
	if (sijiNo.length != 16 && sijiNo.length != 24) {
		// 指示番号が16桁か24桁以外の場合、処理終了
		var beforClass = errCTL1.className;
		if (errCTL1.className.indexOf('error-input-code') == -1) {
			errCTL1.className += " error-input-code";
		}
		if (errCTL2 != null) {
			beforClass = errCTL2.className;
			if (errCTL2.className.indexOf('error-input-code') == -1) {
				errCTL2.className += " error-input-code";
			}
		}
		if (errCTL3 != null) {
			beforClass = errCTL3.className;
			if (errCTL3.className.indexOf('error-input-code') == -1) {
				errCTL3.className += " error-input-code";
			}
		}
		return;

	} else if (sijiNo.length == 16) {
		// 指示番号が16桁の場合
		nyukakaisyacd = sijiNo.substring(0, 2);		// 入荷会社コード
		nyukatencd = sijiNo.substring(2, 6);		// 入荷店コード
	} else if (sijiNo.length == 24) {
		// 指示番号が24桁の場合
		nyukakaisyacd = sijiNo.substring(8, 10);	// 入荷会社コード
		nyukatencd = sijiNo.substring(10, 14);		// 入荷店コード
	}


	// JSONのキーはSQLのバインドの変数と合わせる。
	var condition = 
	{
		 "SYUKKAKAISYA_CD": idCTL1
		,"SYUKKATEN_CD": idCTL2
		,"JYURYOKAISYA_CD": nyukakaisyacd
		,"JYURYOTEN_CD": nyukatencd
		,"SIJI_BANGO": IdoSijiNoGetSijino(idCTL3)
	};

	// コードが存在しない場合にエラー表示を行うコントロールの配列
	var errItem = 
	[
		 errCTL1
		,errCTL2
		,errCTL3
	];

	// JSONのキーはSQLの選択のカラム名もしくはエイリアスと合わせる。
	var result    = 
	{
		 "JYURYOKAISYA_CD": nameCTL1
		,"JYURYOKAISYA_NM": nameCTL2
		,"JYURYOTEN_CD": nameCTL3
		,"JYURYOTEN_NM": nameCTL4
	};
	var readOnly = null;
	searchCommonError(condition, errItem, result);
	$(nameCTL1).bind('mdSetAfter', function () {
		// 会社コードが未設定の場合
		if (nameCTL1.value == "") {
			// 入荷店コードを使用不可
			itemDisabled(nameCTL3, true);
		} else {
			// 入荷店コードを使用可
			itemDisabled(nameCTL3, false);
		}
		// 会社コードフォーマット処理
		nameCTL1.value = getAdvFormat(nameCTL1);
	});

	$(nameCTL1).bind('mdDontSetAfter', function () {
		// 会社コードが未設定の場合
		if (nameCTL1.value == "") {
			// 入荷店コードを使用不可
			itemDisabled(nameCTL3, true);
		} else {
			// 入荷店コードを使用可
			itemDisabled(nameCTL3, false);
		}
	});

	V02020_INNER(condition, result, readOnly);
}

function V02020_INNER(condition, result, readOnly) {
	searchCommonInner_RO(condition, result, readOnly, "V02020.aspx");
}
