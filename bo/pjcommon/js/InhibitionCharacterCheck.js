//InhibitionCharacterCheckクラス定義
function InhibitionCharacterCheck() {
	this.contains = containsForInhibitionCharacterCheck;
	this.check = checkForInhibitionCharacterCheck;
	this.checkAll = checkAllForInhibitionCharacterCheck;
	this.surrogateCheck = surrogateCheckForInhibitionCharacterCheck;
}

//containsメソッド定義
//InhibitionCharacterCheckクラスのメソッドとして定義します。
//[実行結果]
//true-禁止文字が含まれる場合 false-禁止文字が含まれない場合
function containsForInhibitionCharacterCheck(str) {
	if(str == null) {
		return null;
	}
	var strlength = str.length;
	for(var i = 0; i < strlength; i++) {
		var code = str.charCodeAt(i);
		if(this.surrogateCheck(code)) {
			return true;
		}
	}
	return false;
}

//checkメソッド定義
//該当する文字が存在する場合はその最初の文字を結果として返します。
//該当する文字が存在しない場合は実行結果がnullになります。
function checkForInhibitionCharacterCheck(str) {
	if(str == null) {
		return null;
	}
	var strlength = str.length;
	for(var i = 0; i < strlength; i++) {
		var code = str.charCodeAt(i);
		if(this.surrogateCheck(code)) {
			return str.charAt(i);
		}
	}
	return null;
}

//checkAllメソッド定義
//該当する文字が存在する場合はその結果を文字配列として返します。
//チェック対象文字列がnullの場合のみ返り値はnullになります。
//チェック対象文字列がnullでない場合かつ該当文字が存在しない場合は
//実行結果は配列長0の配列になります。
function checkAllForInhibitionCharacterCheck(str) {
	if(str == null) {
		return null;
	}
	var checkArray = new Array();
	var num = 0;

	var strlength = str.length;
	for(var i = 0; i < strlength; i++) {
		var code = str.charCodeAt(i);
		if(this.surrogateCheck(code)) {
			checkArray[num++]  = str.charAt(i);
		}
	}
	return checkArray;
}

//サロゲートペアチェックの文字チェック
//文字のコードからサロゲートペア文字に該当するかどうかをチェックします。
//[実行結果]
//true-サロゲートペア文字の場合 false-サロゲートペア文字ではない場合
function surrogateCheckForInhibitionCharacterCheck(c) {
	var SURROGATE_CHECK_FILTER = 63488;
	var SURROGATE_CHECK_CODE = 55296;
	return ((c & SURROGATE_CHECK_FILTER) == SURROGATE_CHECK_CODE);
}