var mStartIdx;
var meisainumber;
var levelid;
var codeId;
var ItemId;

function PadGridIndex(i) {
    if (i.toString().length == 1) {
        return "0"+i;
    } else {
        return i;
    }
}

function AdjustMeisaiNumber(number) {
    return parseInt(number)+parseInt(mStartIdx)-1;
}
		
function GetMeisaiItemName(itemname,levelno,number){
	var i=AdjustMeisaiNumber(number);
	return levelno+"_ctl"+PadGridIndex(i)+"_"+itemname;
}

function GetMeisaiItemId(itemname,levelno,number){
	var i=AdjustMeisaiNumber(number);
	return levelno+"$ctl"+PadGridIndex(i)+"$"+itemname;
}

function SetValue(iTarget,iValue){
	if(iTarget==null) return false;
	if(iTarget.type==null&&iTarget[0].type=="radio"){
		for (var i=0;i<iTarget.length;i++){
			if(iTarget[i].value==iValue)
			iTarget[i].checked=true;
		}
	}else{

		switch(iTarget.type.toLowerCase()){
		case"select-one":case"select-multiple":
			for (var i=0;i<iTarget.options.length;i++){
				if(iTarget.options[i].value==iValue)
					iTarget.options[i].selected=true;
			}
			break;
		case"checkbox":
			iTarget.checked=(iValue!=0);
			break;
		default:
			iTarget.value=iValue;
		}
	}
}

function GetMeisaiTarget(number,levelid,itemname){
	lastItemName = GetMeisaiItemName(itemname,levelid,number);
	try{
		return eval("window.opener.document.forms[0]."+lastItemName);
	}catch(e){
		alert("Err: When to set value for \""+lastItemName+"\"");
	}
	return null;
}

function GetMappingIDSet() {
	idList = new Array(mapping.length);
	for(var i=0; i<mapping.length; i++) {
		idList[i] = mapping[i][1];
	}
	return(idList);
}
	
function SetParentWin(sepData){
	var indexID = GetMappingIDSet();
	var target;

    try {
	    //For 出口ルーチン呼び出し
	    var MItemId=GetMeisaiItemId(ItemId,levelid,meisainumber);

	    //_event.js出口ルーチン呼び出し
	    if(window.opener.g_onBeforeCodeSet!=null){
		    if(parseInt(meisainumber)!=0){
			    sepData=window.opener.g_onBeforeCodeSet(sepData,MItemId,codeId);
		    }
		    else{
			    sepData=window.opener.g_onBeforeCodeSet(sepData,ItemId,codeId);
		    }
		    if(!sepData){
			    window.close();
			    return;
		    }
	    }
	    var focusFlg = false;
	    var elem = '';
	    for(var i=0; i<indexID.length; i++){
		    if(parseInt(meisainumber)!=0){
			    if(isNaN(indexID[i])){
				    SetValue(GetMeisaiTarget(meisainumber,levelid.toUpperCase(),indexID[i]), sepData[i]);
		            var meisainame = GetMeisaiItemName(indexID[i],levelid.toUpperCase(),meisainumber);
			        //コード設計情報の表示順の最初の項目にフォーカスを当てる
		            if (!focusFlg) {
		                elem = window.opener.document.all.item(meisainame);
		                focusFlg = true;
                    }
			    }
		    }
		    else{
			    if(isNaN(indexID[i])){
				    try{
					    var param_name = indexID[i].replace(indexID[i].substr(0,1),indexID[i].substr(0,1).toUpperCase());
					    SetValue(eval("window.opener.document.forms[0]."+param_name+""), sepData[i]);
                        //コード設計情報の表示順の最初の項目にフォーカスを当てる
					    if (!focusFlg) {
					        elem = window.opener.document.all.item(param_name);
					        focusFlg = true;
                        }
				    }catch(e){
					    alert("Err: when set value to "+indexID[i]);
				    }
			    }
		    }
	    }
        elem.focus();
        elem.select();
        if (elem.className.indexOf('error-input-code') != -1) {
            elem.className = elem.className.replace(" error-input-code", "");
        }
	} catch (e) {
	    //親画面がなくなっている可能性があるため、例外をキャッチしたら何もせずに画面を閉じる
	}
	window.close();
}
