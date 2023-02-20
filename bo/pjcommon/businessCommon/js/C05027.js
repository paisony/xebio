/**
 * C05027 会社判定処理（X）
 * 　呼出し例：isXebio(document.forms.[formタグのid].bocommon$logininfo_copcd);
 * @param obj {Object} - 会社コードコントロール
 */
function isXebio(obj) {

	var numKaisyaCd = ToNumber(obj.value);
	var numXebio = ToNumber(c_kaisya_cd_x);

	return (numKaisyaCd == numXebio);
}

/**
 * C05027 会社判定処理（V）
 * 　呼出し例：isVictoria(document.forms.[formタグのid].bocommon$logininfo_copcd);
 * @param obj {Object} - 会社コードコントロール
 */
function isVictoria(obj) {

	var numKaisyaCd = ToNumber(obj.value);
	var numVictoria = ToNumber(c_kaisya_cd_v);

	return (numKaisyaCd == numVictoria);
}
