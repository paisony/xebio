//false-禁止文字が含まれる場合 true-禁止文字が含まれない場合
function pextCheckAllItemCharCode(){
	var checkItem = new InhibitionCharacterCheck();

	var elemCount = AdvGB_TargetForm.elements.length;
	var elems = AdvGB_TargetForm.elements;
	for(var i=0;i<elemCount;i++){
		if(!pextCheckItemCharCode(elems[i], checkItem)) {
			return false;
		}
	}
	return true;
}

function pextCheckItemCharCode(iCtrl, checkItem){
	var iCix;
	var checkArray = new Array();
	var errString="";
	
	//コントロールのnameがブランクの場合はチェックしない。
	if(iCtrl.name==null){
		return true;
	}
	//定義されていない項目の場合はチェックしない。
	iCix=getAdvControlIdxFromName(iCtrl.name);
	if(iCix<0){
		return true;
	}
	
	//TXT,PWD,TX2,TXRのみチェック対象とする。
	switch(ADVIT_TYPE[iCix]){
	case"TXT":case"PWD":case"TX2":case"TXR":case"FUP":
		//TXRチェックフラグの判断
		if(ADVIT_TYPE[iCix]=="TXR"&&!AdvGB_TXR_CHK){
			return true;
		}
		//checkAll関数の呼び出し
		checkArray=checkItem.checkAll(iCtrl.value);
		//エラーの場合
		if (checkArray.length>0){
			for (var i=0;i<checkArray.length;i++) {
				// 新しいエラー文字だったらエラー文字列に追加
				if ( errString.indexOf(checkArray[i]) == -1){
					errString+=checkArray[i];
				}
			}
			alert(getStandardMessage("L999", ADVIT_CAPTION[iCix], errString));
			if(iCtrl!=null) {
				iCtrl.focus();
			}
			return false;
		}
		break;
	}
	return true;
}
