//カレンダー表示(リンクカレンダコントロール用)
function openCal(ctrlid)
{
	var targetId = ctrlid.toUpperCase();
	var formatId = ADVIT_FORMAT[getAdvControlIdxFromName(targetId)];
	var mId = ADVIT_LEVEL[getAdvControlIdxFromName(targetId)];
	var attId = ADVIT_ATTRIBUTE[getAdvControlIdxFromName(targetId)];
	
	if (mId != "") {
		var eventTarget = getAdvEventTarget();
		
		if (eventTarget.tagName == "IMG")
		{
			eventTarget = getAdvEventTarget().parentElement;
		}
		
		var mno = getAdvItemMNofromCtrl(eventTarget);
		var targetelement = null;
		
		if (attId == "D") {
			targetelement = getAdvControlFromItemID(ctrlid, mno);
			ctrlid = targetelement.id;
		}
	}
	
	var dleft = window.event.clientX + 10;
	var dtop = window.event.clientY + 30;
	var rtn;
	
	switch (formatId) {
		case "52" :
			//IE7
			if(typeof document.body.style.maxHeight != "undefined")
			{
				rtn = showModalDialog('../pjcommon/calendar_dialog.html',window,'scroll:off;resizable:off;status:off;help:no;dialogWidth:250px;dialogHeight:251px;dialogTop:' + dtop + ';dialogLeft:' + dleft);	    
			}
			//IE6以下のバージョン
			else
			{
				rtn = showModalDialog('../pjcommon/calendar_dialog.html',window,'scroll:off;resizable:off;status:off;help:no;dialogWidth:255px;dialogHeight:295px;dialogTop:' + dtop + ';dialogLeft:' + dleft);	    
			}
			break;
		case "54" :
			//IE7
			if(typeof document.body.style.maxHeight != "undefined")
			{
				rtn = showModalDialog('../pjcommon/calendar_month_dialog.html',window,'scroll:off;resizable:off;status:off;help:no;dialogWidth:250px;dialogHeight:251px;dialogTop:' + dtop + ';dialogLeft:' + dleft);
			}
			//IE6以下のバージョン
			else
			{
				rtn = showModalDialog('../pjcommon/calendar_month_dialog.html',window,'scroll:off;resizable:off;status:off;help:no;dialogWidth:255px;dialogHeight:295px;dialogTop:' + dtop + ';dialogLeft:' + dleft);	    
			}
			break;
	}
	
	if (rtn != null) {
		switch (attId) {
			case "D" :
				document.getElementById(ctrlid).value = rtn;
				break;
			case "DX" :
				var separeteDate = rtn.split('/');
				getAdvControlFromItemID(ctrlid + "_dx1", mno).value = separeteDate[0];
				getAdvControlFromItemID(ctrlid + "_dx2", mno).value = separeteDate[1];
				if (formatId == "52") {
					getAdvControlFromItemID(ctrlid + "_dx3", mno).value = separeteDate[2];
				}
				break;
		}
	}
}
//カレンダー表示
function openCalendar(ctrlid)
{
	var dleft = window.event.clientX+10;
	var dtop = window.event.clientY+30;
	var rtn;
	
	//IE7
	if(typeof document.body.style.maxHeight != "undefined")
	{
		rtn = showModalDialog('../pjcommon/calendar_dialog.html',window,'scroll:off;resizable:off;status:off;help:no;dialogWidth:250px;dialogHeight:251px;dialogTop:' + dtop + ';dialogLeft:' + dleft);
	}
	//IE6以下のバージョン
	else
	{
		rtn = showModalDialog('../pjcommon/calendar_dialog.html',window,'scroll:off;resizable:off;status:off;help:no;dialogWidth:255px;dialogHeight:295px;dialogTop:' + dtop + ';dialogLeft:' + dleft);
	}
	
	if (rtn != null)
	{
		document.getElementById(ctrlid).value = rtn;
	}
}
//カレンダー表示(明細部用)
function openCalendarYMD(ctrlid)
{
	var dleft = window.event.clientX + 10;
	var dtop = window.event.clientY + 30;
	var rtn;
	
	//IE7
	if(typeof document.body.style.maxHeight != "undefined")
	{
		rtn = showModalDialog('../pjcommon/calendar_dialog.html',window,'scroll:off;resizable:off;status:off;help:no;dialogWidth:250px;dialogHeight:251px;dialogTop:' + dtop + ';dialogLeft:' + dleft);
	}
	//IE6以下のバージョン
	else
	{
		rtn = showModalDialog('../pjcommon/calendar_dialog.html',window,'scroll:off;resizable:off;status:off;help:no;dialogWidth:255px;dialogHeight:295px;dialogTop:' + dtop + ';dialogLeft:' + dleft);
	}
	
	if (rtn != null)
	{
		document.getElementById(ctrlid).value = rtn;
	}
}
//カレンダー表示(セパレート日付用)
function openCalendarSeparate(ctrlid){
	var dleft = window.event.clientX + 10;
	var dtop = window.event.clientY + 30;

	if (dtop > window.screen.availheight) {
		dtop = window.screen.availheight;
	}

	var rtn;
	
	//IE7
	if(typeof document.body.style.maxHeight != "undefined")
	{
		rtn = showModalDialog('../pjcommon/calendar_dialog.html',window,'scroll:off;resizable:off;status:off;help:no;dialogWidth:250px;dialogHeight:251px;dialogTop:' + dtop + ';dialogLeft:' + dleft);
	}
	//IE6以下のバージョン
	else
	{
		rtn = showModalDialog('../pjcommon/calendar_dialog.html',window,'scroll:off;resizable:off;status:off;help:no;dialogWidth:255px;dialogHeight:295px;dialogTop:' + dtop + ';dialogLeft:' + dleft);
	}
	
	if (rtn != null)
	{
        var separeteDate = rtn.split('/');
		document.getElementById(ctrlid + "_dx1").value = separeteDate[0];
		document.getElementById(ctrlid + "_dx2").value = separeteDate[1];
		document.getElementById(ctrlid + "_dx3").value = separeteDate[2];
	}
}
//カレンダー表示(月次)
function openCalendarMonth(ctrlid)
{
	var dleft = window.event.clientX+10;
	var dtop = window.event.clientY+30;
	var rtn;
	
	//IE7
	if(typeof document.body.style.maxHeight != "undefined")
	{
		rtn = showModalDialog('../pjcommon/calendar_month_dialog.html',window,'scroll:off;resizable:off;status:off;help:no;dialogWidth:250px;dialogHeight:251px;dialogTop:' + dtop + ';dialogLeft:' + dleft);
	}
	//IE6以下のバージョン
	else
	{
		rtn = showModalDialog('../pjcommon/calendar_month_dialog.html',window,'scroll:off;resizable:off;status:off;help:no;dialogWidth:255px;dialogHeight:295px;dialogTop:' + dtop + ';dialogLeft:' + dleft);
	}
	
	if (rtn != null)
	{
		document.getElementById(ctrlid).value = rtn;
	}
}
//カレンダー表示(月次)
function openCalendarMonthSeparate(ctrlid)
{
	var dleft = window.event.clientX+10;
	var dtop = window.event.clientY+30;
	var rtn;
	
	//IE7
	if(typeof document.body.style.maxHeight != "undefined")
	{
		rtn = showModalDialog('../pjcommon/calendar_month_dialog.html',window,'scroll:off;resizable:off;status:off;help:no;dialogWidth:250px;dialogHeight:251px;dialogTop:' + dtop + ';dialogLeft:' + dleft);
	}
	//IE6以下のバージョン
	else
	{
		rtn = showModalDialog('../pjcommon/calendar_month_dialog.html',window,'scroll:off;resizable:off;status:off;help:no;dialogWidth:255px;dialogHeight:295px;dialogTop:' + dtop + ';dialogLeft:' + dleft);
	}
	
	if (rtn != null)
	{
		var separeteDate = rtn.split('/');
		document.getElementById(ctrlid + "_dx1").value = separeteDate[0];
		document.getElementById(ctrlid + "_dx2").value = separeteDate[1];
	}
}
var loaded = false;
//共通ロード設定
function setCommonLoad() {
	//親フレームにタイトルを設定
	//top.document.title = document.title;

	//ページャ対応
	for (i = 0; i < ADVIT_ID.length; i++) {
		if (ADVIT_ACTIONID[i] == "PGN") {
			if (document.getElementById(ADVIT_ID[i]) != null) {
				document.getElementById(ADVIT_ID[i]).onclick = g_onClick;
				ADVIT_TYPE[i] = "LNK";
			}
		}
	}

	//Focus処理
	setFocus();
	
	//右クリックメニュー用イベント割り当て
	//document.oncontextmenu=OnRightButton;
	//document.onclick= OnLeftButton;
	
	//download処理
	var pgid = getQuery("downloadFlag=");
	var formid = getQuery("formId=");
	var flag = document.getElementById("header_downloadFlag");
	if (getQuery("downloadFlag=") != "" && flag.value == "1") {
		var width = getBrowserWidth();
		var height = getBrowserHeight();
		var Positioning = GetCookie("LoginPositioning");
		var TopPosition = GetCookie("LoginTopPositionAdjustment");
		var Top =GetCookie("LoginPositionTop");
		var Left =GetCookie("LoginPositionLeft");
		var Toolbar = "no";
		var Location = "no";
		var Directories = "no";
		var Menubar = "no";
		var Scrollbars = "no";
		var Status = "yes";
		var Resizable = "yes";
		var WindowStyle = "";
		if (Positioning != null &&  Positioning == "true")
		{
			if (TopPosition != null)
			{
				Top = (screen.height - height - TopPosition) / 2;
				if (Top < 0)
				{
					Top = 0;
				}
				Left = (screen.width - width) / 2;
				WindowStyle = ",width=" + width + ",height=" + height + ",top=" + Top + ",left="+ Left
							+ ",toolbar=" + Toolbar + ",location="   + Location   + ",directories=" + Directories
							+ ",menubar=" + Menubar + ",scrollbars=" + Scrollbars + ",status="      + Status + ",resizable="+ Resizable;
			}
			else
			{
				if (Top != null)
				{
					WindowStyle = ",width=" + width + ",height=" + height + ",top=" + Top + ",left="+ Left
								+ ",toolbar=" + Toolbar + ",location="   + Location   + ",directories=" + Directories
								+ ",menubar=" + Menubar + ",scrollbars=" + Scrollbars + ",status="      + Status + ",resizable="+ Resizable;
				}
				else
				{
					WindowStyle = ",width=" + width + ",height=" + height
								+ ",toolbar=" + Toolbar + ",location="   + Location   + ",directories=" + Directories
								+ ",menubar=" + Menubar + ",scrollbars=" + Scrollbars + ",status="      + Status + ",resizable="+ Resizable;
				}
			}
		}
		else
		{
					WindowStyle = ",width=" + width + ",height=" + height
								+ ",toolbar=" + Toolbar + ",location="   + Location   + ",directories=" + Directories
								+ ",menubar=" + Menubar + ",scrollbars=" + Scrollbars + ",status="      + Status + ",resizable="+ Resizable;
		}
		window.open("../pjcommon/aspx/FileDownloader.aspx?pgid=" + pgid + "&formid=" + formid ,"previewOWF", WindowStyle);
		//location.href = "../pjcommon/aspx/FileDownloader.aspx?pgid="+pgid+"&formid="+formid;
		flag.value = "0";
	}
	loaded = true;
}
//ダウンロードフラグ
//var downloadflag = 0;

//フォーカスを当てる処理
function setFocus(){

	// 機能間連携場合が、画面リロード後、子画面にフォーカス遷移する
	if(window.PG_SYN != null)
	{
		window.PG_SYN.window.focus();
		return;
	}


    // エラー時に既にフォーカスがセットされている場合、フォーカス位置を変更させない。
    try{
        if(ErrItemFocusedFlg === 'true'){
            ErrItemFocusedFlg = 'false';
            return;
        }
    }catch(ex){
        //項目が取得できない。そのまま処理を続行する。
    }

    $('#header #Tenpo_cd').attr('readonly', true);
	var wFocusTarget = getAdvFirstCtrl(AdvGB_TargetForm.elements[0]);
    $('#header #Tenpo_cd').attr('readonly', false);
	
	var flag = document.getElementById("header_focusFlag");
	
	if (flag.value == "1") {
		try{
			//指定されている場合は変更
			if(getFocusItemID() != ""){
				if(getFocusMcount() != ""){
					//明細
					wFocusTarget = getAdvControlFromItemID(getFocusItemID(), getFocusMcount() - 0);
				}else{
					wFocusTarget = getAdvControlFromItemID(getFocusItemID());
				}
			}	
		}catch(ex){//存在しない項目を指定した
		}
	
		flag.value = "0";
	}
	
	if (wFocusTarget != null){
		try{
			wFocusTarget.focus();
		}
		catch(e){
			return;
		}
	}

}
//クエリ取得
//フォーカスを当てる項目IDの取得
function getFocusItemID(){
    return getQuery("StdFocusedItemID=");
}
//フォーカスを当てる明細行数の取得(1行目が0)
function getFocusMcount(){
    return getQuery("StdFocusedMcount=");
}
//URLクエリの取得。引数には"="までつけること
function getQuery(queryKEY){
    querystr = window.location.search;
    ret = "";
    if(querystr.indexOf(queryKEY) != -1){
		if(querystr.indexOf('&',querystr.indexOf(queryKEY)) != -1){
			ret =querystr.substring(querystr.indexOf(queryKEY) + queryKEY.length ,
				querystr.indexOf('&',querystr.indexOf(queryKEY)));
		} else {
			ret =querystr.substring(querystr.indexOf(queryKEY) + queryKEY.length);
		}
    }
    return ret;
}
//サブウィンドウがあるかどうかを判断する処理
function FindWin(target, style) {

	if (target == "" || target == "_blank") {
		return null;
	}
	
	var win1;
	
	try {
		win1 = window.open('', target, style);

		if (win1.location.href == "about:blank") {
			return null;
		} else {
			return win1;
		}
	} catch(e) {
		return null;
	}
}
//共通クリック設定
function setCommonOnClick(target, targetName) {

	if (ADVIT_ACTIONID[getAdvControlIdxFromName(target.id)] == "COD") {
		var style = "scrollbars=0,toolbar=0,location=0,directories=0,menubar=0,resizable=1,top=" + (screen.height-80)/2 + ",left=" + (screen.width-270)/2 + ",width=450,height=50";
		AdvGB_CodeWindowOpen = FindWin("AdvCodeWin01", style);
		if (AdvGB_CodeWindowOpen != null) {
			closeAdvCodeWindow();
		}
	}

	if (targetName == "") {
	    if (ADVIT_ACTIONID[getAdvControlIdxFromName(target.parentElement.parentElement.parentElement.parentElement.id)] == "PGN") {
			if (AdvGB_SubmitFLG) {
				return false;
			}
			AdvGB_LastClickItemNm = target.parentElement.parentElement.parentElement.parentElement.id;
		}
	}
	if (targetName.toUpperCase() == "BTNSRY") {
//		if (!confirm(getMessage("I423"))) {
//			return false;
//		} else{
//			return true;
//		}
	}
	
	return true;
}
//ポップアップウィンドウエラー表示
function openErrorWindow() {
    $('#modalContainer').height(417);
    buttonNoAction = '';
    showMessageDialog('../pjcommon/aspx/MessageDialog.aspx?pgId=' + ADVIT_TARGETPGID +  '&level=error');
}

//ポップアップダイアログエラー表示
var Md_ErrorWindowOpen;
var MdClientErrorMessage;

function openErrorDialog(message)
{
	canOpenRedisplayDialog = false;

	// クライアントチェックエラーの場合
	var oldMessage = MdClientErrorMessage;
	var uri;
	$('#modalContainer').height(417);
	if (message) {
		MdClientErrorMessage = message;
		uri = encodeURI('../pjcommon/aspx/MessageDialog.aspx?pgId=' + ADVIT_TARGETPGID + '&message=' + message);
		RedisplayMethodFlag = ADVIT_TARGETPGID.toLowerCase();
	    RedisplayWarningField();
	}
	// 業務エラーの場合（サーバー側処理）
	else {
		uri = "../pjcommon/aspx/MessageDialog.aspx?pgId=" + ADVIT_TARGETPGID;
		// クライアントエラーのメッセージを削除
		MdClientErrorMessage = null;
	}

	Md_ErrorWindowOpen = showMessageDialog(uri);
}

//画面を閉じます。
function closeWindow() {
	window.close();
}
//共通サブミット設定
function setCommonOnSubmit(targetName) {
	
	//Submit時チェックがOFFの場合、処理は行わない。
	if (ADVIT_HLCHK[getAdvControlIdxFromName(targetName)] == 0) {
		return true;
	}
	
	//クライアントチェックフラグがfalseの場合はクライアントチェックを行わない
	if(!AdvGB_ClientChk){
		return true;
	}

	//文字コードチェック設定を有効としている場合のみ文字コードチェックを行う
    if(QPGB_CharacterCodeCheck){
	    if (!pextCheckAllItemCharCode()) {
		    return false;
		}    
	}
	
	return true;
}
//共通チェック判定
function isCommonCheck(itemName) {
	if (ADVIT_HLCHK[getAdvControlIdxFromName(itemName)] == 1) {
		return true;
	} else {
		return false;
	}
}
//クライアントサブミットチェック
function onSubmit_std(btnItemID){
    //グループ制御を無効としている場合は共通のサブミットチェックを行う
	if(!QPGB_GroupControl) {    
    try{   
	        if (!onSubmit_adv()) {
                return false;
            }
        }catch(e){
            if(e.number == -2146826178 && e.name == "Error")
		    {
		        return false;
		    }
		    throw e;
        }
        return true;

    }
    	
    //クライアントチェックフラグがfalseの場合はクライアントチェックを行わない
	if(!AdvGB_ClientChk){
		return true;
	}
	
    //グループ制御用チェック
	if (ADVIT_ACTPARAMETER[getAdvControlIdxFromName(AdvGB_LastClickItemNm.toUpperCase())].substring(0,1) == "M")
	{
	    //ボタンの対象明細が設定されている場合は対象明細のみチェックを行う
		return mCommonCheck(btnItemID, ADVIT_ACTPARAMETER[getAdvControlIdxFromName(AdvGB_LastClickItemNm.toUpperCase())])
	}
	
	for (i = 0; i < ADVIT_ID.length; i++) {
		if ((QPIT_GROUP[i] == QPIT_GROUP[getAdvControlIdxFromName(btnItemID)]) && (IsControl(ADVIT_ID[i]))) {		    
			if (ADVIT_LEVEL[i] == "") {
			    if(!checkRdo_std(i)) {
			        return false;
			    }				
				if (!checkAdvItem(getAdvControlFromItemID(ADVIT_ID[i]))) {
					return false;
				}		
			} else {
				for (j = 0; j < getAdvMaxMRow(ADVIT_LEVEL[i].substring(1,2)); j++) {
			        if(!checkRdo_std(i)) {
			            return false;
			        }					    
					if (!checkAdvItem(getAdvControlFromItemID(ADVIT_ID[i], j+1))) {
						return false;
					}
				}
			}
		}
	}
	
	return true;
}

//明細部共通チェック
function mCommonCheck(btnItemID, mId) {
	for (i = 0; i < ADVIT_ID.length; i++) {
		if (QPIT_GROUP[i] == QPIT_GROUP[getAdvControlIdxFromName(btnItemID)]) {
			if (ADVIT_LEVEL[i] == mId) {
				for (j = 0; j < getAdvMaxMRow(mId.substring(1,2)); j++) {
					if (IsControl(ADVIT_ID[i])) {
			            if(!checkRdo_std(i)) {
			               return false;
			            }							    
						if (!checkAdvItem(getAdvControlFromItemID(ADVIT_ID[i], j+1))) {
							return false;
						}
					}
				}
			}
		}
	}
	return true;
}

//コントロール存在チェック
function IsControl(controlId) {
	if (getAdvControlFromItemID(controlId) == null) {
		return false;
	}
	return true;
}
//コントロール存在チェック(明細用)
function IsControl(controlId, index) {
	if (getAdvControlFromItemID(controlId, index) == null) {
		return false;
	}
	return true;
}

//ラジオボタンの必須チェック（グループ制御用）
function checkRdo_std(idx){
	if((ADVIT_REQUIREDFLG[idx]==1)&&(ADVIT_TYPE[idx]=="RDO")){
		for(RC_i = 0; RC_i < getAdvControlFromItemID(ADVIT_ID[idx]).length; RC_i++){
			if(getAdvControlFromItemID(ADVIT_ID[idx])[RC_i].checked){
				return true;
			}
		}
		alert(getAdvAssembleMsg(ADVMS_STR[ADVMS_ID_S103],idx,""));
		getAdvControlFromItemID(ADVIT_ID[idx])[0].focus();
		return false;
	}
	return true;
}

//クライアントメッセージを取得します。
function getMessage(messageId,params){
    var message = CLMS[messageId];
    return replaceMessage(message , params);
}

//クライアントメッセージを取得します。
function getMessage(messageId) {
	var message = CLMS[messageId];
	return replaceMessage(message, arguments);
}

//クライアントメッセージを取得します。
function getStandardMessage(messageId) {
	var message = QP_CLMS[messageId];
	return replaceMessage(message, arguments);
}

//メッセージをパラメータで置換します。
function replaceMessage(message, params) {
	switch(params.length){
		case 10:
			message = message.replace("%9",params[9])
		case 9:
			message = message.replace("%8",params[8])
		case 8:
			message = message.replace("%7",params[7])
		case 7:
			message = message.replace("%6",params[6])
		case 6:
			message = message.replace("%5",params[5])
		case 5:
			message = message.replace("%4",params[4])
		case 4:
			message = message.replace("%3",params[3])
		case 3:
			message = message.replace("%2",params[2])
		case 2:
			message = message.replace("%1",params[1])
		case 1:
			break;
	}
	return message;
}/**
*ブラウザの幅を取得する
*
*/
function getBrowserWidth() {
		if ( window.innerWidth ) {
				return window.innerWidth;
		}
		else if ( document.documentElement && document.documentElement.clientWidth != 0 ) {
				return document.documentElement.clientWidth;
		}
		else if ( document.body ) {
				return document.body.clientWidth;
		}
		return 0;
}

/**
*ブラウザの高さを取得する
*
*/
function getBrowserHeight() {
		if ( window.innerHeight ) {
				return window.innerHeight;
		}
		else if ( document.documentElement && document.documentElement.clientHeight != 0 ) {
				return document.documentElement.clientHeight;
		}
		else if ( document.body ) {
				return document.body.clientHeight;
		}
		return 0;
}
// クッキー取得ルーチン
function GetCookie ( name )
{
	var arg = name + "=";
	var alen = arg.length;
	var clen = document.cookie.length;
	var i = 0;
	while ( i < clen )
	{
		var j = i + alen;
		if ( document.cookie.substring( i, j ) == arg )
		{
			return GetCookieVal( j ) ;
		}
		i = document.cookie.indexOf(" ", i ) + 1;
		if( i == 0 )
		{
			break;
		}
	}
	return null;
}
// クッキー取得のサブルーチン
function GetCookieVal( offset ) 
{
	var endstr = document.cookie.indexOf( ";", offset);
	if ( endstr == -1 )
	{
		endstr = document.cookie.length;
	}
	return unescape( document.cookie.substring( offset, endstr ));
}
// スリープ処理（ミリ秒）
function JSSleep(sec) {
	var start = new Date;
	while (1) {
		var cur = new Date;
		if (sec <= cur.getTime() - start.getTime()) {
			break;
		}
	}
}
