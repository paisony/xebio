// 指示番号丸め処理(移動用)
function formatSijinoIdou(obj) {
	// アンフォーマット
//	unFormatSijinoHenpin(obj);
	var val = obj.value;

	if (val != "") {
		if (val.length <= 10) {
			obj.value = LPadZero(val, 10);
		} else if (val.length >= 11 && val.length <= 16) {
			obj.value = LPadZero(val, 16);
		} else {
			obj.value = LPadZero(val, 24);
		}
	}


}
function unFormatSijinoIdou(obj) {
	// 前ゼロ削除
	obj.value = LDelZero(obj.value);

}

function IdoSijiNoGetSijino(obj)
{
	var rtn = "0";
	formatSijinoIdou(obj);
	var val = obj.value;

	if (val.length == 10)
	{
		rtn = val;
	}
	else if (val.length == 16)
	{
		rtn = val.substring(6);		// 下10桁
	}
	else if (val.length == 24)
	{
		rtn = val.substring(14);	// 下10桁
	}

	return rtn;
}
