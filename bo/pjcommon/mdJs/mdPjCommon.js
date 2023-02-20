var mdWaitMessageID = "", mdYesbtnid = "", mdNobtnid = "", mdDefaultFocusid = "", mdAsynchronousCancel = "", 
mdFunctionClickF12 = "", mdKeySafe = "", startingflg = 0, finishflg = 0, downloadflg = 0;
function DynamicClock(showDateElementID, showClockElementID) 
{
    var mdDynDateClock = null, mdDynTimeClock = null, mdTimerID = null;
    if (!showDateElementID) {
        showDateElementID = "clockdate";
    }
    if (!showClockElementID) {
        showClockElementID = "clocktime";
    }
    var now = new Date, year = now.getFullYear(), month = now.getMonth() + 1, day = now.getDate(), hours = now.getHours(), 
    minutes = now.getMinutes(), seconds = now.getSeconds();
    if (month < 10) {
        month = "0" + month;
    }
    if (day < 10) {
        day = "0" + day;
    }
    if (hours < 10) {
        hours = "0" + hours;
    }
    if (minutes < 10) {
        minutes = "0" + minutes;
    }
    if (seconds < 10) {
        seconds = "0" + seconds;
    }
    mdDynDateClock = year + "/" + month + "/" + day;
    mdDynTimeClock = hours + ":" + minutes + ":" + seconds;
    var ClockDate = document.getElementById(showDateElementID);
    ClockDate.innerHTML = mdDynDateClock;
    var ClockTime = document.getElementById(showClockElementID);
    ClockTime.innerHTML = mdDynTimeClock;
    mdTimerID = setTimeout("DynamicClock('" + showDateElementID + "' , '" + showClockElementID + "')", 
    960)
}
var effectAreaElementIdMap = new Map, disabledMap = new Map, notOpenAreaMap = new Map;
function Accordion(eventElementId, effectAreaElementId, detailsId, beforeClickCallback, afterClickCallback) 
{
    var mapItem = effectAreaElementIdMap.get(effectAreaElementId);
    if (!mapItem) {
        mapItem = [];
        effectAreaElementIdMap.put(effectAreaElementId, mapItem) 
    }
    var relationArray = [];
    relationArray[0] = eventElementId;
    relationArray[1] = detailsId;
    mapItem.push(relationArray);
    var eventElement = $("#" + eventElementId);
    eventElement.click(function () 
    {
        if ($(":animated").length > 0) {
            return;
        }
        beforeClickCallback != undefined && beforeClickCallback.apply(this);
        var acdElt = $("#" + effectAreaElementId);
        if (acdElt.css("display") == "none") 
        {
            acdElt.slideDown("slow");
            eventElement.removeClass("accordionClosed");
            AccordionCallback(true, effectAreaElementId, "block") 
        }
        else 
        {
            acdElt.slideUp("slow");
            eventElement.addClass("accordionClosed");
            AccordionCallback(false, effectAreaElementId, "none") 
        }
        afterClickCallback != undefined && afterClickCallback.apply(this) 
    }).mouseover(function () 
    {
        eventElement.addClass("accordionOver") 
    }).mouseout(function () 
    {
        eventElement.removeClass("accordionOver") 
    })
}
function notOpenAreaRegist(registArea) 
{
    notOpenAreaMap.get(registArea) == null && notOpenAreaMap.put(registArea, "")
}
function StoreRequestAccordionStatus() 
{
    if (effectAreaElementIdMap.size == 0) {
        return;
    }
    var form = document.getElementById(ADVIT_FORMID), keysArray = effectAreaElementIdMap.keys;
    for (i = 0; i < keysArray.length; i++) 
    {
        var elt = $("#" + keysArray[i]), eltDisplayValue = elt.css("display"), objElt = $("#" + elt[0].id + "-requeststore")[0];
        objElt != null && form.removeChild(objElt);
        var accordionStatusTag = document.createElement("input");
        accordionStatusTag.type = "hidden";
        accordionStatusTag.id = elt[0].id + "-requeststore";
        accordionStatusTag.name = elt[0].id + "-requeststore";
        accordionStatusTag.value = eltDisplayValue;
        accordionStatusTag.setAttribute("runat", "server");
        form.appendChild(accordionStatusTag) 
    }
}
function AccordionAllOpen() 
{
    StoreRequestAccordionStatus();
    for (i = 0; i < disabledMap.keys.length; i++) 
    {
        var elt = $("#" + disabledMap.keys[i]);
        if (notOpenAreaMap.contains(disabledMap.keys[i])) {
            continue;
        }
        if (elt.css("display") == "none") 
        {
            var mapItem = effectAreaElementIdMap.get(elt.get(0).id);
            for (j = 0; j < mapItem.length; j++) {
                $("#" + mapItem[j][0]).click() ;
            }
        }
    }
    return
}
function AccordionExclusiveOpen() 
{
    for (i = 0; i < notOpenAreaMap.keys.length; i++) 
    {
        var elt = $("#" + notOpenAreaMap.keys[i]);
        if (elt.css("display") == "none") {
            continue;
        }
        var mapItem = effectAreaElementIdMap.get(elt.get(0).id);
        for (j = 0; j < mapItem.length; j++) {
            $("#" + mapItem[j][0]).click() ;
        }
    }
    return
}
function Map() 
{
    this.keys = [];
    this.data = {};
    this.put = function (key, value) 
    {
        this.data[key] == null && this.keys.push(key);
        this.data[key] = value ;
    };
    this.get = function (key) 
    {
        return this.data[key] ;
    };
    this.remove = function (key) 
    {
        for (i = 0; i < this.keys.length; i++) {
            this.keys[i] == key && this.keys.splice(i, 1);
        }
        this.data[key] = null ;
    };
    this.each = function (fn) 
    {
        if (typeof fn != "function")
        {
            return;
        }
        for (var len = this.keys.length, i = 0; i < len; i++) {
            var k = this.keys[i];
            fn(k, this.data[k], i) 
        }
    };
    this.entrys = function () 
    {
        for (var len = this.keys.length, entrys = new Array(len), i = 0; i < len; i++) {
            entrys[i] = {
                key : this.keys[i], value : this.data[i] 
            };
        }
        return entrys ;
    };
    this.isEmpty = function () 
    {
        return this.keys.length == 0 ;
    };
    this.size = function () 
    {
        return this.keys.length ;
    };
    this.toString = function () 
    {
        for (var s = "{", i = 0; i < this.keys.length; i++, s += ",") {
            var k = this.keys[i];
            s += k + "=" + this.data[k] 
        }
        s += "}";
        return s ;
    };
    this.contains = function (value) 
    {
        for (var i in this.keys) {
            if (this.keys.hasOwnProperty(i) && this.keys[i] === value) {
                return true;
            }
            return false ;
        }
    }
}
function confirmF12Dialog(mess, ProgramId, proc) 
{
    var returnValue = showModalDialog("../pjcommon/mdAspx/Confirm.aspx?pgId=" + ProgramId + "&mess=" + mess + "&proc=" + proc, 
    this, "dialogWidth:280px;dialogHeight:80px;status:no;center:yes;edge:sunken;help:no;resizable:no;scroll:no;dependent:no");
    try 
    {
        if (returnValue[0] != null && returnValue[0].length > 0) {
            EndProgramWindowClose(ProgramId);
            //alert('42'); 
        	window.close() 
        }
        else {
            return false ;
        }
    }
    catch (e) {
        return false ;
    }
}
var blockUIbtn = "";
function confirmPanel(event, panelCss, mess) 
{
    MD_SRC_EVENT_ID = event.srcElement.id;
    if (!MD_CONFIRM_FLAG)
    {
        switch (panelCss.toUpperCase()) 
        {
            case CMSLTNOWLOADING:
                return createLoadingElement("loading");
                break;
            case CMINSCONFIRM:
                return createYNConfirmElement("confirmins", getMessage("I415"), getMessage("I409"), mess, 
                "yesins", getMessage("I412"), "noins", getMessage("I413"), "yesins");
                break;
            case CMDELCONFIRM:
                return createYNConfirmElement("confirmdel", getMessage("I410"), getMessage("I409"), mess, 
                "yesdel", getMessage("I412"), "nodel", getMessage("I413"), "nodel");
                break;
            case CMUPDCONFIRM:
                return createYNConfirmElement("confirmupd", getMessage("I415"), getMessage("I409"), mess, 
                "yesupd", getMessage("I412"), "noupd", getMessage("I413"), "yesupd");
                break;
            default:
                break 
        }
    }
    else {
        AdvGB_SubmitFLG = true;
        return true ;
    }
}
function createLoadingElement(loadingElementid) 
{
    createLoadingPanel(loadingElementid);
    $.blockUI({
        message : $("#" + loadingElementid), opacity : .5, cursor : "default" 
    });
    return true
}
function createLoadingPanel(loadingElementid) 
{
    var tmp = $("#" + loadingElementid);
    if (!tmp.get(0)) 
    {
        var loadDiv = "";
        loadDiv += '<div id="' + loadingElementid + '" style="border:0px solid #555; width:100%; height:100%; display:none">';
        loadDiv += "<center>";
        loadDiv += "<table>";
        loadDiv += "    <tr>";
        loadDiv += '        <td><img src="../pjcommon/images/busy.gif"/></td>';
        loadDiv += "        <td>&nbsp;</td>";
        loadDiv += '        <td style="vertical-align:middle ; font-size : 30px ; font-weight : bold">Nowloading</td>';
        loadDiv += "    </tr>";
        loadDiv += "</table>";
        loadDiv += "</center>";
        loadDiv += "</div>";
        $("body").append(loadDiv) 
    }
}
function createBlockPanel(confirmid, borderstyle, yesbtnid, nobtnid, defaultFocusid) 
{
    if (nowBlocking) {
        return;
    }
    $.blockUI(
    {
        message : $("#" + confirmid), css : {
            width : "420px", height : "100px", left : "30%", border : borderstyle, cursor : "default" 
        },
        overlayCSS : {
            backgroundColor : "#FFFFEC", cursor : "default" 
        },
        focusInput : false, fadeIn : 200, opacity : .5 
    });
    mdYesbtnid = yesbtnid;
    mdNobtnid = nobtnid;
    mdDefaultFocusid = defaultFocusid;
    if (yesbtnid == defaultFocusid) {
        $("#" + yesbtnid).focus().click(yesbtnfn);
    }
    else {
        $("#" + yesbtnid).click(yesbtnfn);
    }
    if (nobtnid)
    {
        if (nobtnid == defaultFocusid) {
            $("#" + nobtnid).focus().click(nobtnfn);
        }
        else {
            $("#" + nobtnid).click(nobtnfn);
        }
        nowBlocking = true;
    }
}
function yesbtnfn() 
{
    MD_CONFIRM_FLAG = true;
    blockUIbtn = "yes";
    $("#" + MD_SRC_EVENT_ID).get(0).click();
    $.unblockUI();
    nowBlocking = false;
    blockUIbtn = ""
}
function nobtnfn() 
{
    blockUIbtn = "no";
    if (mdYesbtnid == mdDefaultFocusid) {
        $("#" + mdYesbtnid).focus().click(yesbtnfn);
    }
    else {
        $("#" + mdNobtnid).focus().click(nobtnfn);
    }
    $.unblockUI();
    nowBlocking = false;
    blockUIbtn = ""
}
function createYNConfirmElement(confirmid, mode, title, message, yesbtnid, yesMessage, nobtnid, noMessage, 
defaultFocusid) 
{
    MD_SRC_EVENT_ID = event.srcElement.id;
    if (!MD_CONFIRM_FLAG) 
    {
        var tmp = $("#" + confirmid);
        switch (mode) 
        {
            case getMessage("I409"):
            case getMessage("I415"):
                bgcolor = InfoConfirmBgColor;
                color = InfoConfirmColor;
                break;
            case getMessage("I411"):
                bgcolor = WarnConfirmBgColor;
                color = WarnConfirmColor;
                break;
            case getMessage("I410"):
                bgcolor = ErrorConfirmBgColor;
                color = ErrorConfirmColor;
                break 
        }
        if (!tmp.get(0)) 
        {
            var confirmDiv = "";
            confirmDiv += '<div id="' + confirmid + '" style="border:0px solid #555; width:100%; height:100%; display:none">';
            confirmDiv += "<center>";
            confirmDiv += '<table style="width:95%; height:90%; margin-left: auto;margin-right: auto;text-align: center; margin: 2% 2% 1% 2%;">';
            confirmDiv += '<tr bgcolor="' + bgcolor + '" style="height:10%">';
            confirmDiv += '\t<th colspan="4" style="text-align:center;COLOR : ' + color + '">' + title + "</th>";
            confirmDiv += "</tr>";
            confirmDiv += '<tr style="height:50%">';
            confirmDiv += '\t<td colspan="4"><span id="m' + confirmid + '">' + message + "</span></td>";
            confirmDiv += "</tr>";
            confirmDiv += '<tr style="height:10%">';
            confirmDiv += '<td width="56%"></td>';
            confirmDiv += '<td width="20%"><input type="button" id="' + yesbtnid + '" style="width:95%;border:1px solid #555;" value="' + yesMessage + '"/></td>';
            confirmDiv += '<td width="6%"></td>';
            confirmDiv += '<td width="20%"><input type="button" id="' + nobtnid + '" style="width:95%;border:1px solid #555;" value="' + noMessage + '"/></td>';
            confirmDiv += "</tr>";
            confirmDiv += "</table>";
            confirmDiv += "</center>";
            confirmDiv += "</div>";
            $("body").prepend(confirmDiv) 
        }
        else {
            $("#m" + confirmid).text("");
            $("#m" + confirmid).append(message) 
        }
        createBlockPanel(confirmid, bgcolor + " 1px solid", yesbtnid, nobtnid, defaultFocusid);
        return false 
    }
    else {
        AdvGB_SubmitFLG = true;
        return true ;
    }
}
function createConfirmElement(confirmid, mode, title, message, okbtnid, okbtnMessage, defaultFocusid) 
{
    if (event.srcElement != null) {
        MD_SRC_EVENT_ID = event.srcElement.id;
    }
    if (!MD_CONFIRM_FLAG) 
    {
        var tmp = $("#" + confirmid);
        if (!tmp.get(0)) 
        {
            switch (mode) 
            {
                case getMessage("I409"):
                case getMessage("I415"):
                    bgcolor = InfoConfirmBgColor;
                    color = InfoConfirmColor;
                    break;
                case getMessage("I411"):
                    bgcolor = WarnConfirmBgColor;
                    color = WarnConfirmColor;
                    break;
                case getMessage("I410"):
                    bgcolor = ErrorConfirmBgColor;
                    color = ErrorConfirmColor;
                    break 
            }
            var confirmDiv = "";
            confirmDiv += '<div id="' + confirmid + '" style="border:0px solid #555; width:100%; height:100%; display:none">';
            confirmDiv += "<center>";
            confirmDiv += '<table style="width:95%; height:90%; margin-left: auto;margin-right: auto;text-align: center; margin: 2% 2% 1% 2%;">';
            confirmDiv += '<tr bgcolor="' + bgcolor + '" style="height:10%">';
            confirmDiv += '\t<th colspan="4" style="text-align:center;COLOR : ' + color + '">' + title + "</th>";
            confirmDiv += "</tr>";
            confirmDiv += '<tr style="height:50%">';
            confirmDiv += '\t<td colspan="4">' + message + "</td>";
            confirmDiv += "</tr>";
            confirmDiv += '<tr style="height:10%">';
            confirmDiv += '<td width="20%"><input type="button" id="' + okbtnid + '" style="width:15%" value="' + okbtnMessage + '"/></td>';
            confirmDiv += "</tr>";
            confirmDiv += "</table>";
            confirmDiv += "</center>";
            confirmDiv += "</div>";
            $("body").append(confirmDiv) 
        }
        createBlockPanel(confirmid, bgcolor + " 1px solid", null, okbtnid, defaultFocusid);
        return false 
    }
    else {
        AdvGB_SubmitFLG = true;
        return true ;
    }
}
function createXmlObject(conditionColumns, resultColumns, readOnlyColumns) 
{
    if (conditionColumns == null || resultColumns == null) {
        return null;
    }
    var xmlDoc = '<?xml version="1.0" encoding="utf-8"?>', root = document.createElement("request"), tmp;
    for (var c in conditionColumns) 
    {
        tmp = conditionColumns[c];
        if (!tmp) {
            return null;
        }
        tmp = getValue(tmp);
        if (!tmp || tmp == "") {
            return null;
        }
        if (typeof conditionColumns[c] == "object" && conditionColumns[c].length != undefined) 
        {
            var elt = document.createElement("replace");
            elt.setAttribute("column", c);
            elt.setAttribute("value", tmp);
            root.appendChild(elt) 
        }
        else 
        {
            var elt = document.createElement("condition");
            elt.setAttribute("column", c);
            elt.setAttribute("value", tmp);
            root.appendChild(elt) 
        }
    }
    for (var r in resultColumns) 
    {
        tmp = resultColumns[r];
        if (!tmp) {
            continue;
        }
        if (typeof tmp == "object" && tmp.length != undefined && tmp.nodeName != "SELECT")
        {
            for (var q = 0; q < tmp.length; q++) 
            {
                var elt = document.createElement("result");
                elt.setAttribute("column", r);
                elt.setAttribute("bind_id", tmp[q].id);
                root.appendChild(elt) 
            }
        }
        else 
        {
            var elt = document.createElement("result");
            elt.setAttribute("column", r);
            elt.setAttribute("bind_id", tmp.id);
            elt.setAttribute("is_list", $(tmp).hasClass(CM_LIST_BOX));
            root.appendChild(elt) 
        }
    }
    for (var r in readOnlyColumns) 
    {
        tmp = readOnlyColumns[r];
        if (!tmp) {
            continue;
        }
        if (typeof tmp == "object" && tmp.length != undefined)
        {
            for (var q = 0; q < tmp.length; q++) 
            {
                var elt = document.createElement("readOn");
                elt.setAttribute("Ro_column", r);
                elt.setAttribute("Ro_bind_id", tmp[q].id);
                root.appendChild(elt) 
            }
        }
        else 
        {
            var elt = document.createElement("readOn");
            elt.setAttribute("Ro_column", r);
            elt.setAttribute("Ro_bind_id", tmp.id);
            root.appendChild(elt) 
        }
    }
    xmlDoc += root.outerHTML;
    return xmlDoc
}
function resetResultColumns(resultColumns) 
{
    if (resultColumns == null) {
        return;
    }
    for (var r in resultColumns) 
    {
        tmp = resultColumns[r];
        if (!tmp) {
            continue;
        }
        if (typeof tmp == "object" && tmp.length != undefined)
        {
            for (var q = 0; q < tmp.length; q++)
            {
                switch (tmp[q].tagName.toUpperCase()) {
                    case "INPUT":
                        $(tmp[q]).attr("value", "");
                        break;
                    default:
                        break;
                }
            }
        }
        else
        {
            switch (tmp.tagName.toUpperCase()) 
            {
                case "INPUT":
                    $(tmp).hasClass(CM_LIST_BOX) && SetDataToStore(tmp.id, "");
                    $(tmp).attr("value", "");
                    break;
                default:
                    break;
            }
        }
        if (tmp.tagName.toUpperCase() === "SELECT") {
            $(tmp).children().get(0).selected = "selected" ;
        }
    }

    /*
		ツールチップ用文字列の作成
	*/
    $('.tooltip').each(function (i) {
        if (this.tagName == "INPUT") {
            this.setAttribute('title', this.value);
        } else {
            this.setAttribute('title', this.innerText);
        }
    });
}
function getValue(element) 
{
    if (!element) {
        return null;
    }
    if (typeof element == "object" && element.length != undefined) 
    {
        for (var elementGroup = "", q = 0; q < element.length; q++) 
        {
            (typeof element[q] == "string" || typeof element[q] == "number") && element[q].toString();
            if (q == 0) 
            {
                elementGroup = elementGroup.concat("'");
                elementGroup = elementGroup.concat(element[q]);
                elementGroup = elementGroup.concat("'") 
            }
            else 
            {
                elementGroup = elementGroup.concat(",");
                elementGroup = elementGroup.concat("'");
                elementGroup = elementGroup.concat(element[q]);
                elementGroup = elementGroup.concat("'") ;
            }
        }
        return elementGroup 
    }
    if (typeof element == "string" || typeof element == "number") {
        return element.toString();
    }
    switch (element.tagName.toUpperCase()) {
        case "INPUT":
            return element.value;
        default:
            return null ;
    }
}
function send(xmlObject, requestUrl) 
{
    ajaxRequest = $.ajax(
    {
        async : AjaxModel.asyncMode, type : AjaxModel.type, cache : AjaxModel.cache, processData : AjaxModel.processData, 
        url : requestUrl, data : xmlObject, dataType : AjaxModel.dataType, success : responseHandle, error : AjaxModel.responseHandle 
    })
}
function responseHandle(data, status) 
{
    var bindid, value, islist;
    readOnlist = [];
    $(data).find("readOn").each(function () 
    {
        readOnlist[$(this).attr("Ro_bind_id")] = $(this).attr("Ro_value");
        Robindvalue = $(this).attr("Ro_value");
        var el = $("#" + Robindvalue);
        for (i = 0, n = readOnlist.length; i < n; i++) {
            el.removeAttr("readOnly", "readOnly") ;
        }
    });
    var innerResultMap = new Map;

    var find_flg = false;   // 検索のヒットを判断するフラグ

    $(data).find("result_map").each(function () 
    {
        $(this).find("result").each(function () 
        {
            bindid = $(this).attr("bind_id");
            value = $(this).attr("value");
            islist = $(this).attr("is_list");
            if (islist) {
                SetDataToStore(bindid, value);
            }
            else 
            {
                if (AjaxModel.returnValueAttribute == "list") {
                    var tmp = innerResultMap.get(bindid);
                    if (tmp != undefined) {
                        value = value + "," + tmp ;
                    }
                }
                innerResultMap.put(bindid, value) 
            }
        }) 
    });
    innerResultMap.each(function (elementName, value, index) 
    {
        var elt = $("#" + elementName);
        switch (elt.get(0).tagName.toUpperCase()) 
        {
            case "INPUT":
                if (mdAsynchronousCancel != "1")
                {
                    if (value != null && value != "") 
                    {
                        elt.attr(AjaxModel.returnValueAttribute, value);

                        find_flg = true;

                        elt.trigger("mdSetAfter", innerResultMap) 
                    }
                    else {
                        elt.attr("value", "");
                    }
                }
                    break;
                    case "SELECT":
                    mdAsynchronousCancel != "1" && elt.children().each(function () 
                    {
                        if (this.value === value) {
                            this.selected = "selected" ;
                        }
                    });
                break;
            default:
                break ;
        }
    })

    // 検索がヒットしなかった時の処理
    if (!find_flg) {
        $(data).find("terget_items").each(function () {
            $(this).find("item").each(function () {
                var elementName = $(this).attr("bind_id");
                var elt = $("#" + elementName);
                elt.trigger("mdDontSetAfter");
            })
        });
    }

	/*
		ツールチップ用文字列の作成
	*/
    $('.tooltip').each(function (i) {
    	if (this.tagName == "INPUT") {
    		this.setAttribute('title', this.value);
    	} else {
    		this.setAttribute('title', this.innerText);
    	}
    });

	// [onAfter]がある場合、後処理を実行する。
    $(data).find("onafter").each(function () {
    	var recalcrow = $(this).attr("recalcrow");
    	if (typeof responseHandle_onAfter == "function") {
    		responseHandle_onAfter(recalcrow);
    	}
    });
}
function inputCheckHandle(data, status) 
{
    Result.M_ITEM.COPCD = 1;
    return 1
}
function requestErrHandle(XMLHttpRequest, status, errorThrown) 
{
    confirm("\u30a8\u30e9\u30fc\u304c\u767a\u751f\u3057\u307e\u3057\u305f\u3002" + status)
}
var nowBlocking = false, nowFnKeyDoing = false;
function FunctionKeys() 
{
    $.extend($.fn, 
    {
        FunctionKeys : function (o) 
        {
            var d = document;
            if (d.all) {
                window.onhelp = function () 
                {
                    return false ;
                };
            }
            $(this).keydown(function (e) 
            {
                var keyCode = e.keyCode, altKey = e.altKey, shiftKey = e.shiftKey, ctrlKey = e.ctrlKey, 
                target = e.target, targetID = e.target.id, srcTagName = window.event.srcElement.tagName;
                if (srcTagName) {
                    srcTagName = srcTagName.toUpperCase();
                }
                var srcType = window.event.srcElement.type;
                if (srcType) {
                    srcType = srcType.toUpperCase();
                }
                if (keyCode >= 112 && keyCode <= 123) 
                {
                    if (!nowBlocking)
                    {
                        if (o.F1 && keyCode == 112) {
                            o.F1(target, shiftKey, ctrlKey, altKey);
                        }
                        else if (o.F2 && keyCode == 113) {
                            o.F2(target, shiftKey, ctrlKey, altKey);
                        }
                        else if (o.F3 && keyCode == 114) {
                            o.F3(target, shiftKey, ctrlKey, altKey);
                        }
                        else if (o.F4 && keyCode == 115) {
                            o.F4(target, shiftKey, ctrlKey, altKey);
                        }
                        else if (o.F5 && keyCode == 116) {
                            o.F5(target, shiftKey, ctrlKey, altKey);
                        }
                        else if (o.F6 && keyCode == 117) {
                            o.F6(target, shiftKey, ctrlKey, altKey);
                        }
                        else if (o.F7 && keyCode == 118) {
                            o.F7(target, shiftKey, ctrlKey, altKey);
                        }
                        else if (o.F8 && keyCode == 119) {
                            o.F8(target, shiftKey, ctrlKey, altKey);
                        }
                        else if (o.F9 && keyCode == 120) {
                            o.F9(target, shiftKey, ctrlKey, altKey);
                        }
                        else if (o.F10 && keyCode == 121) {
                            o.F10(target, shiftKey, ctrlKey, altKey);
                        }
                        else if (o.F11 && keyCode == 122) 
                        {
                            o.F11(target, shiftKey, ctrlKey, altKey);
                            try 
                            {
                                if (srcTagName == "INPUT" && srcType == "FILE") if (document.documentElement.clientWidth < 1024 && document.documentElement.clientHeight < 714) 
                                {
                                    getAdvControlFromItemID(targetID).focus();
                                    var wsh = new ActiveXObject("WScript.Shell");
                                    wsh.SendKeys("{F11}");
                                    JSSleep(500);
                                    wsh = null ;
                                }
                            }
                            catch (e) { }
                        }
                        else if (o.F12 && keyCode == 123)
                        {
                            if (mdFunctionClickF12 == "1" || mdKeySafe == "") {
                                mdFunctionClickF12 = "";
                                o.F12(target, shiftKey, ctrlKey, altKey) 
                            }
                            if (getBrowserWidth() < 1090) {
                                if (d.all && !(srcTagName == "INPUT" && srcType == "FILE")) {
                                    window.event.keyCode = 0 ;
                                }
                            }
                            else if (!(o.F11 && keyCode == 122)) {
                                window.event.keyCode = 0;
                            }
                            return false ;;
                        }
                    }
                }
            }) 
        }
    });
    $(function () 
    {
        $(document).FunctionKeys(
        {
            F1 : function (obj, s, c, a) 
            {
                if (nowFnKeyDoing) {
                    return;
                }
                if ($("#cmWrapperGuard:visible").length > 0) {
                    return;
                }
                if (isAccordionAnimated()) {
                    return;
                }
                try {
                    nowFnKeyDoing = true;
                    runKeyF1(obj, s, c, a);
                    nowFnKeyDoing = false 
                }
                catch (e) { }
            },
            F2 : function (obj, s, c, a) 
            {
                if (nowFnKeyDoing) {
                    return;
                }
                if ($("#cmWrapperGuard:visible").length > 0) {
                    return;
                }
                if (isAccordionAnimated()) {
                    return;
                }
                try {
                    nowFnKeyDoing = true;
                    runKeyF2(obj, s, c, a);
                    nowFnKeyDoing = false 
                }
                catch (e) { }
            },
            F3 : function (obj, s, c, a) 
            {
                if (nowFnKeyDoing) {
                    return;
                }
                if ($("#cmWrapperGuard:visible").length > 0) {
                    return;
                }
                if (isAccordionAnimated()) {
                    return;
                }
                try {
                    nowFnKeyDoing = true;
                    runKeyF3(obj, s, c, a);
                    nowFnKeyDoing = false 
                }
                catch (e) { }
            },
            F4 : function (obj, s, c, a) 
            {
                if (nowFnKeyDoing) {
                    return;
                }
                if ($("#cmWrapperGuard:visible").length > 0) {
                    return;
                }
                if (isAccordionAnimated()) {
                    return;
                }
                try {
                    nowFnKeyDoing = true;
                    runKeyF4(obj, s, c, a);
                    nowFnKeyDoing = false 
                }
                catch (e) { }
            },
            F5 : function (obj, s, c, a) 
            {
                if (nowFnKeyDoing) {
                    return;
                }
                if ($("#cmWrapperGuard:visible").length > 0) {
                    return;
                }
                if (isAccordionAnimated()) {
                    return;
                }
                try {
                    nowFnKeyDoing = true;
                    runKeyF5(obj, s, c, a);
                    nowFnKeyDoing = false 
                }
                catch (e) { }
            },
            F6 : function (obj, s, c, a) 
            {
                if (nowFnKeyDoing) {
                    return;
                }
                if ($("#cmWrapperGuard:visible").length > 0) {
                    return;
                }
                if (isAccordionAnimated()) {
                    return;
                }
                try {
                    nowFnKeyDoing = true;
                    runKeyF6(obj, s, c, a);
                    nowFnKeyDoing = false 
                }
                catch (e) { }
            },
            F7 : function (obj, s, c, a) 
            {
                if (nowFnKeyDoing) {
                    return;
                }
                if ($("#cmWrapperGuard:visible").length > 0) {
                    return;
                }
                if (isAccordionAnimated()) {
                    return;
                }
                try {
                    nowFnKeyDoing = true;
                    runKeyF7(obj, s, c, a);
                    nowFnKeyDoing = false 
                }
                catch (e) { }
            },
            F8 : function (obj, s, c, a) 
            {
                if (nowFnKeyDoing) {
                    return;
                }
                if ($("#cmWrapperGuard:visible").length > 0) {
                    return;
                }
                if (isAccordionAnimated()) {
                    return;
                }
                try {
                    nowFnKeyDoing = true;
                    runKeyF8(obj, s, c, a);
                    nowFnKeyDoing = false 
                }
                catch (e) { }
            },
            F9 : function (obj, s, c, a) 
            {
                if (nowFnKeyDoing) {
                    return;
                }
                if ($("#cmWrapperGuard:visible").length > 0) {
                    return;
                }
                if (isAccordionAnimated()) {
                    return;
                }
                try {
                    nowFnKeyDoing = true;
                    runKeyF9(obj, s, c, a);
                    nowFnKeyDoing = false 
                }
                catch (e) { }
            },
            F10 : function (obj, s, c, a) 
            {
                if (nowFnKeyDoing) {
                    return;
                }
                if ($("#cmWrapperGuard:visible").length > 0) {
                    return;
                }
                if (isAccordionAnimated()) {
                    return;
                }
                try {
                    nowFnKeyDoing = true;
                    runKeyF10(obj, s, c, a);
                    nowFnKeyDoing = false 
                }
                catch (e) { }
            },
            F11 : function (obj, s, c, a) 
            {
                if (nowFnKeyDoing) {
                    return;
                }
                if ($("#cmWrapperGuard:visible").length > 0) {
                    return;
                }
                if (isAccordionAnimated()) {
                    return;
                }
                try {
                    nowFnKeyDoing = true;
                    runKeyF11(obj, s, c, a);
                    nowFnKeyDoing = false 
                }
                catch (e) { }
            },
            F12 : function (obj, s, c, a) 
            {
                if (nowFnKeyDoing) {
                    return;
                }
                if ($("#cmWrapperGuard:visible").length > 0) {
                    return;
                }
                if (isAccordionAnimated()) {
                    return;
                }
                try 
                {
                    nowFnKeyDoing = true;
                    if (getAdvControlFromItemID("Btnsry").disabled == true) {
                        getAdvControlFromItemID("Btnsry").disabled = false;
                    }
                    runKeyF12(obj, s, c, a);
                    nowFnKeyDoing = false 
                }
                catch (e) { }
            }
        }) 
    })
}
function isAccordionAnimated() 
{
    if ($(":animated").length > 0)
    {
        for (var aniEle = $(":animated"), i = 0; i < aniEle.length; i++) {
            if (effectAreaElementIdMap.contains(aniEle.get(0).id)) {
                return true;
            };
        }
    }
    return false
}
function cooperate() 
{
    if (arguments.length == 0) {
        return;
    }
    var detail = arguments;
    if (detail < 2) {
        return;
    }
    for (var count = 1, mouseroverColor = detail[0], detailSrcColor, detailSrcFontColor, i = 1; i < detail.length; i++)
    {
        $(".cmDetailHighLightTarget").each(function () 
        {
            $(this).mouseover(function () 
            {
                if (count == 1) 
                {
                    detailSrcColor = $(this).css("backgroundColor");
                    detailSrcFontColor = $(this).css("color");
                    count++ 
                }
                for (var index = $(this).get(0).rowIndex, x = 1; x < detail.length; x++) 
                {
                    var synRow = $("#" + detail[x]).get(0).rows[index];
                    synRow.style.backgroundColor = mouseroverColor;
                    synRow.style.color = MouseOverFontColor 
                }
                count = 1 ;
            });
            $(this).mouseout(function () 
            {
                for (var index = $(this).get(0).rowIndex, x = 1; x < detail.length; x++) 
                {
                    var synRow = $("#" + detail[x]).get(0).rows[index];
                    synRow.style.backgroundColor = detailSrcColor;
                    synRow.style.color = detailSrcFontColor ;
                }
            });
            count = 1 ;
        });
    }
}
function CaseOfRedisplayWarningField(elementid) 
{
    RedisplayMethodFlag == ADVIT_TARGETPGID.toLowerCase() && openErrorDialog()
}
function RedisplayWarningField(elementid) 
{
	if (RedisplayMethodFlag == ADVIT_TARGETPGID.toLowerCase()) 
	{
		if (!elementid) {
			elementid = "error-01";
		}
		$("#" + elementid).css("display") !== "block" && $("#" + elementid).css("display", "block").click(function () {
			canOpenRedisplayDialog == true && openErrorDialog()
		});
		$('#wrap').adjustHeight();
	}
	else if (RedisplayMethodFlag == ADVIT_TARGETPGID.toLowerCase() + "INFO") {
		boOpenInfoDialogEx(_msg, _buttonYesAction, _buttonNoAction, 'info');
	} else if (RedisplayMethodFlag == ADVIT_TARGETPGID.toLowerCase() + "WARN") {
		boOpenInfoDialogEx(_msg, _buttonYesAction, _buttonNoAction, 'warn');
	} else if (RedisplayMethodFlag == ADVIT_TARGETPGID.toLowerCase() + "WARNMULTI") {
		boOpenInfoDialogEx(_msg, _buttonYesAction, _buttonNoAction, 'warnmulti');
	}
}
var AjaxCalendar = 
{
    Enabled : function (elementId) 
    {
        var ele, className, classValue;
        ele = $("#" + elementId);
        className = ele.attr("class");
        classValue = className.replace("FROZEN_CALENDAR", "datepicker").replace("NONE_CALENDAR", "datepicker");
        ele.removeAttr("class");
        ele.attr("class", classValue);
        CalendarChange(ele) 
    },
    Disabled : function (elementId) 
    {
        var ele, className, classValue;
        ele = $("#" + elementId);
        className = ele.attr("class");
        classValue = className.replace(/^datepicker/, "FROZEN_CALENDAR").replace(/ datepicker/, " FROZEN_CALENDAR").replace("NONE_CALENDAR",
        " FROZEN_CALENDAR");
        ele.removeAttr("class");
        ele.attr("class", classValue);
        CalendarChange(ele) 
    },
    None : function (elementId) 
    {
        var ele, className, classValue;
        ele = $("#" + elementId);
        className = ele.attr("class");
        classValue = className.replace("FROZEN_CALENDAR", "NONE_CALENDAR").replace(/^datepicker/, "NONE_CALENDAR").replace(/ datepicker/,
        " NONE_CALENDAR");
        ele.removeAttr("class");
        ele.attr("class", classValue);
        CalendarChange(ele) 
    }
},
IfmCalendar = 
{
    init : function (elementId, value) 
    {
        $("#" + elementId).removeAttr("onclick");
        $("#" + elementId).bind("click", function () 
        {
            openCal(value);
            return false ;
        }) 
    },
    Enabled : function (elementId, value) 
    {
        if ($("#" + elementId).css("visibility") === "hidden") {
            $("#" + elementId).css("visibility", "visible");
        }
        else 
        {
            $("#" + elementId).unbind("click");
            $("#" + elementId).bind("click", function () 
            {
                openCal(value);
                return false ;
            });
            $("#" + elementId).removeAttr("disabled") 
        }
    },
    Disabled : function (elementId) 
    {
        $("#" + elementId).unbind("click");
        $("#" + elementId).attr("disabled", "disabled") 
    },
    None : function (elementId) 
    {
        $("#" + elementId).css("visibility", "hidden") 
    }
};
function CalendarChange(ele) 
{
    var cls = ele.attr("class");
    if (cls.match(/^datepicker| datepicker/))
    {
        if (ele.datepicker("option", "disable") == undefined)
        {
            ele.datepicker( 
            {
                showOn : "button", buttonImage : "../pjcommon/images/btn_calendar.gif", buttonImageOnly : true, 
                buttonText : "\u30ab\u30ec\u30f3\u30c0\u30fc", disable : false, enable : true 
            });
        }
        else 
        {
            ele.datepicker({
                disable : false, enable : true 
            }).datepicker("enable");
            ele.unbind("focus");
            g_onFocus != undefined && ele.bind("focus", g_onFocus) 
        }
    }
    else if (cls.match("datepicker"))
    {
        if (ele.datepicker("option", "disable") == undefined)
        {
            ele.datepicker( 
            {
                showOn : "button", buttonImage : "../pjcommon/images/btn_calendar.gif", buttonImageOnly : true, 
                buttonText : "\u30ab\u30ec\u30f3\u30c0\u30fc", disable : true, enable : false 
            }).datepicker("disable");
        }
        else 
        {
            ele.datepicker({
                disable : true, enable : false 
            }).datepicker("disable");
            ele.unbind("focus");
            g_onFocus != undefined && ele.bind("focus", g_onFocus) 
        }
    }
    else {
        cls.match("NONE_CALENDAR") && ele.datepicker("destroy") ;
    }
}
function Calendar(elementCalendarCss, elementCalendarDisableCss) 
{
    if (!elementCalendarCss) {
        elementCalendarCss = "CALENDAR";
    }
    var eltsE = $("." + elementCalendarCss);
    if (eltsE != undefined && eltsE.length > 0)
    {
        for (i = 0; i < eltsE.length; i++) 
        {
            var eltE = eltsE.eq(i);
            if (eltE.datepicker("option", "disable") == undefined)
            {
                eltE.datepicker( 
                {
                    showOn : "button", buttonImage : "../pjcommon/images/btn_calendar.gif", buttonImageOnly : true, 
                    buttonText : "\u30ab\u30ec\u30f3\u30c0\u30fc", disable : false, enable : true 
                });
            }
            else if (eltE.datepicker("option", "disable")) 
            {
                eltE.datepicker({
                    disable : false, enable : true 
                }).datepicker("enable");
                eltE.unbind("focus");
                g_onFocus != undefined && eltE.bind("focus", g_onFocus) 
            }
        }
        if (!elementCalendarDisableCss) {
            elementCalendarDisableCss = "FROZEN_CALENDAR";
        }
    }
    var eltsD = $("." + elementCalendarDisableCss);
    if (eltsD != undefined && eltsD.length > 0) for (i = 0;
    i < eltsD.length;
    i++) 
        {
        var eltD = eltsD.eq(i);
        if (eltD.datepicker("option", "disable") == undefined)
        {
            eltD.datepicker( 
            {
                showOn : "button", buttonImage : "../pjcommon/images/btn_calendar.gif", buttonImageOnly : true, 
                buttonText : "\u30ab\u30ec\u30f3\u30c0\u30fc", disable : true, enable : false 
            }).datepicker("disable");
        }
        else if (!eltD.datepicker("option", "disable")) 
        {
            eltD.datepicker({
                disable : true, enable : false 
            }).datepicker("disable");
            eltD.unbind("focus");
            g_onFocus != undefined && eltD.bind("focus", g_onFocus) 
        }
    }
}
function ResetAjaxModel() 
{
    AjaxModel.asyncMode = true;
    AjaxModel.type = "POST";
    AjaxModel.cache = false;
    AjaxModel.processData = false;
    AjaxModel.dataType = "xml";
    AjaxModel.returnValueAttribute = "value" 
}
function GetLoginInfo(isElement) 
{
    var loginVO = {};
    if (isElement == null || isElement == false) 
    {
        loginVO.loginid = $("#header_LOGINID").get(0);
        loginVO.copcd = $("#header_COPCD").get(0);
        loginVO.ttscd = $("#header_TTSCD").get(0);
        loginVO.tnpcd = $("#header_TNPCD").get(0) 
    }
    else 
    {
        loginVO.loginid = $("#header_LOGINID").get(0).value;
        loginVO.copcd = $("#header_COPCD").get(0).value;
        loginVO.ttscd = $("#header_TTSCD").get(0).value;
        loginVO.tnpcd = $("#header_TNPCD").get(0).value 
    }
    return loginVO 
}
function DisableTXRFocus() 
{
    var detail;
    if (arguments == null || arguments.length == 0) 
    {
        detail = [];
        detail[0] = "inpReadonlyLeft";
        detail[1] = "inpReadonlyRight";
        detail[2] = "inpReadonlyCenter" 
        detail[3] = "inpReadonly" 
    }
    else {
        detail = arguments;
    }
    for (var i = 0; i < detail.length; i++) {
        $("." + detail[i]).each(function () 
        {
            $(this).get(0).tabIndex = - 1 
        });
    }
}
function openPrinterSetting(form_id, printer_id) 
{
    return showModalDialog("../pjcommon/mdAspx/PrintSettingDialog.aspx?FORM_ID=" + form_id + "&PRINTER_ID=" + printer_id, 
    window, "scroll:off;resizable:off;status:off;help:no;dialogWidth:270px;dialogHeight:180px;center:yes;")
}
function showHelp(program_id, form_id) 
{
    return 
}
function sortTrigger(sortBtnId) 
{
    $("#" + sortBtnId).get(0).click() 
}
function imageTooltip() 
{
    var tooltipNode = $("#divTooltip");
    if (!tooltipNode.get(0)) {
        var tooltipNode = $("<div>");
        $("body").append(tooltipNode) 
    }
    tooltipNode.css("border", "1px solid black").css("position", "absolute").css("z-index", "99");
    tooltipNode.hide();
    var imgs = $(".imgTooltip");
    imgs.mouseover(function (event) 
    {
        var imgNode = $(this), imgSrc = imgNode.attr("src");
        if (!imgSrc) {
            return;
        }
        var imgSize = getSize(TOOLTIPS);
        if (!imgSize) {
            return;
        }
        var flag = showdiv(tooltipNode, imgSrc, imgSize);
        if (!flag) {
            return;
        }
        var offset = imgNode.offset();
        tooltipNode.css("left", offset.left + "px").css("top", offset.top + imgNode.height() + "px");
        var myEvent = event || window.event;
        tooltipNode.css("left", myEvent.clientX + 5 + "px").css("top", myEvent.clientY + 5 + "px");
        tooltipNode.show("fast");
        imgs.mouseout(function () 
        {
            tooltipNode.hide() 
        }) 
    }) 
}
function showdiv(Element, path, imgSize) 
{
    Element.empty();
    var src = getImgSrc(path, imgSize);
    if (!src) {
        return false;
    }
    var imgNode = $("<img>");
    imgNode.attr("src", src);
    imgNode.attr("width", imgSize.width);
    imgNode.attr("height", imgSize.height);
    imgNode.attr("alt", "\u62e1\u5927\u753b\u50cf");
    Element.append(imgNode);
    return true 
}
function getSize(TOOLTIPS) 
{
    var size = {}, tmp;
    switch (TOOLTIPS.toUpperCase()) 
    {
        case "MAIN.L":
            tmp = MAIN_L.split(",");
            break;
        case "MAIN.M":
            tmp = MAIN_M.split(",");
            break;
        case "MAIN.S":
            tmp = MAIN_S.split(",");
            break;
        case "MAIN.D":
            tmp = MAIN_D.split(",");
            break;
        case "MAIN.IM":
            tmp = MAIN_IM.split(",");
            break;
        case "MAIN.MR":
            tmp = MAIN_MR.split(",");
            break;
        case "MAIN.SUB":
            tmp = SUB.split(",");
            break;
        default:
            return null 
    }
    size.name = TOOLTIPS;
    size.width = tmp[0];
    size.height = tmp[1];
    return size 
}
function getImgSrc(path, imgSize) 
{
    var urlResult = "", NoImageFle = isNoImage(path);
    if (NoImageFle == true) {
        return null;
    }
    for (var tmp = path.split("_"), type = tmp[tmp.length - 1], name = type.split("."), i = 0; i < tmp.length - 1; i++) {
        urlResult += tmp[i] + "_";
    }
    urlResult += imgSize.name;
    urlResult += "." + name[name.length - 1];
    return urlResult 
}
function isNoImage(path) 
{
    var noImageFlag = path.split("&");
    if (noImageFlag[noImageFlag.length - 1] == "NOIMAGE=TRUE") {
        return true;
    }
    return false 
}
function mdScrollArea(scrollArea, scrollSize) 
{
    $("#" + scrollArea).scrollTop($("#" + scrollArea).scrollTop() + - (event.wheelDelta  / 120 * scrollSize)) 
}
var detailScrollPosition = [];
function ResetScrollPositionToDetail() 
{
    if (arguments.length == 0) {
        return;
    }
    detailScrollPosition = arguments;
    for (var i = 0; i < detailScrollPosition.length; i++) 
    {
        var detail = $("#" + detailScrollPosition[i]), sTop = detail.attr("sTop"), sLeft = detail.attr("sLeft");
        sTop != null && detail.scrollTop(sTop);
        sLeft != null && detail.scrollLeft(sLeft) 
    }
}
function RequestScrollPosition() 
{
    if (detailScrollPosition.length == 0) {
        return;
    }
    for (var form = document.getElementById(ADVIT_FORMID), i = 0; i < detailScrollPosition.length; i++) 
    {
        var detail = $("#" + detailScrollPosition[i]), oldElt = $("#" + detailScrollPosition[i] + "-scrollstore")[0];
        oldElt != null && form.removeChild(oldElt);
        var accordionStatusTag = document.createElement("input");
        accordionStatusTag.type = "hidden";
        accordionStatusTag.id = detailScrollPosition[i] + "-scrollstore";
        accordionStatusTag.name = detailScrollPosition[i] + "-scrollstore";
        accordionStatusTag.value = detail.scrollTop() + "," + detail.scrollLeft();
        accordionStatusTag.setAttribute("runat", "server");
        form.appendChild(accordionStatusTag) 
    }
}
function ShowUpdateCountPanel() 
{
    var p = $("form"), value = p.attr("updateCount");
    if (value != null && value != "") 
    {
        p.removeAttr("updateCount");
        createConfirmElement("updateCountPanel", getMessage("I409"), "\u66f4\u65b0\u4ef6\u6570", value + "\u4ef6\u3092\u66f4\u65b0\u3057\u307e\u3057\u305f\u3002", 
        "okbtn", "\u78ba\u5b9a", "okbtn") 
    }
}
var waitCond = {};
function ShowBatchLoadingPage(url, flg, jobId, programId) 
{
    if (url) 
    {
        waitCond.url = url;
        waitCond.flg = flg;
        waitCond.jobId = jobId;
        waitCond.programId = programId 
    }
    else 
    {
        url = waitCond.url;
        flg = waitCond.flg;
        jobId = waitCond.jobId;
        programId = waitCond.programId 
    }
    if ($("#screen").length == 0) 
    {
        var blocker = "<div id='screen' style='position:absolute;z-index:1;width:1016px;height:700px;filter: alpha(opacity=10);background-color:silver;top:0px;left:0px;'></div>";
        $("body").append(blocker) 
    }
    var sub = showModalDialog(url, window, "status:no;dialogWidth:280px;dialogHeight:130px;center:yes;edge:sunken;help:no;resizable:no;scroll:no;dependent:no"), 
    childMonitor = function (sub, fl) 
    {
        var cnt = 0, monitoring = function () 
        {
            if (startingflg == 1) 
            {
                if (flg == "True" && finishflg == 1) {
                    send();
                }
                else if (finishflg == 1 && downloadflg == 1)
                {
                    window.open("../pjcommon/mdAspx/DownLoadRun.aspx?pgId=" + programId, "download", "dependent=yes,alwaysLowered=yes,width=1,height=1,left=2000,top=2000");
                }
                else if (finishflg == 0) {
                    ShowBatchLoadingPage();
                    return 
                }
                endMonitor();
                return ;
            }
        };
        monitoring() 
    },
    endMonitor = function () 
    {
        updateConfirmDisplay.flg && updateConfirmDisplay.cnt === 1 && OpenUpdateConfirm();
        $("#screen").remove();
        return ;
    },
    send = function () 
    {
        var parameter = 
        {
            async : "true", type : "GET", url : "../pjcommon/mdAspx/AsynchronousBatchMonitor.aspx", data : "jobId=" + jobId, 
            success : handleResponse, datatype : "xml" 
        };
        $.ajax(parameter) 
    };
    childMonitor(sub, flg) 
}
var updateConfirmDisplay = {
    cnt : 0, flg : false,
    on : function () 
    {
        this.cnt += 1;
        this.flg = true ;
    }
};
function CreateRequestFrame() 
{
    $("body").append("<iframe id='RequestFrame' src='../pjcommon/html/Request.html' style='height:0px;width:0px'></script></iflame>") 
}
function sendRequest(threadId) 
{
    var dg, lctimer, xmlObj, stop, ti = threadId;
    function lock() 
    {
        if (typeof dg === "undefined" || dg.closed) {
            dg = screenLock(true);
        }
        lctimer = setTimeout(lock, 100);
        return function () 
        {
            clearTimeout(lctimer);
            (typeof dg !== "undefined" || !dg.closed) && dg.close() 
        }
    }
    function createXml() 
    {
        var xmlDoc, root;
        xmlDoc = '<?xml version="1.0" encoding="utf-8"?>';
        root = document.createElement("threadId");
        root.innerHTML = ti;
        xmlDoc += root.outerHTML;
        return xmlDoc 
    }
    function send() 
    {
        var parameter = 
        {
            async : "true", type : "POST", url : "../pjcommon/mdAspx/Asynchronous/AsyncRequest.aspx", 
            data : xmlObj, success : handleSuccess, error : handleError, datatype : "xml" 
        };
        $.ajax(parameter) 
    }
    function handleError(XMLHttpRequest, textStatus, errorThrown) 
    {
        alert("\u901a\u4fe1\u30a8\u30e9\u30fc\u304c\u767a\u751f\u3057\u307e\u3057\u305f\u3002") 
    }
    function handleSuccess(data, dataType) 
    {
        var xmlDoc, id, state, errLevel, reloadParam, callback, btn;
        xmlDoc = new ActiveXObject("microsoft.XMLDOM");
        xmlDoc.load(data);
        id = xmlDoc.childNodes[1].childNodes[0].getAttribute("id");
        state = xmlDoc.childNodes[1].childNodes[0].text;
        errLevel = xmlDoc.childNodes[1].childNodes[1].text;
        btn = xmlDoc.childNodes[1].childNodes[2].text;
        if (state !== "dealing") {
            callback = reloadAfter(btn);
        }
        switch (state) 
        {
            case "dealing":
                setTimeout(function () 
                {
                    send() 
                }, 3e3);
                break;
            case "normal":
                stop();
                showDisp(callback);
                break;
            case "updateConfirm":
                stop();
                window.focus();
                OpenUpdateConfirm();
                showDisp(callback);
                break;
            case "errorDialog":
                stop();
                RedisplayMethodFlag = errLevel;
                RedisplayWarningField();
                window.focus();
                CaseOfRedisplayWarningField();
                showDisp(callback);
                break;
            case "abend":
                stop();
                window.focus();
                OpenUpdateConfirm();
                showDisp();
                break 
        }
    }
    function reloadAfter(ele) 
    {
        if (ele !== "") {
            return function () 
            {
                $("#" + ele).get(0).click() 
            };
        }
        else {
            return ;
        }
    }
    stop = lock();
    xmlObj = createXml();
    setTimeout(send, 500) 
}
function handleResponse(data, dataType) 
{
    var xmlDoc = new ActiveXObject("microsoft.XMLDOM");
    xmlDoc.load(data);
    var ret = xmlDoc.getElementsByTagName("response")[0].getAttribute("ret"), files = xmlDoc.getElementsByTagName("file"), 
    i;
    if (files != null) 
    {
        var xmlObj = {};
        for (i = 0; i < files.length; i++) 
        {
            var deObj = {}, id = files[i].getAttribute("id"), edb = files[i].childNodes.item(0).text, 
            status = files[i].childNodes.item(1).text, errFilename = files[i].childNodes.item(2).text;
            deObj["id"] = id, deObj["edb"] = edb, deObj["status"] = status;
            deObj["errFilename"] = errFilename;
            xmlObj["file" + i] = deObj 
        }
        var filecallback = function (key, obj) 
        {
            if ("1" == obj["status"]) 
            {
                document.getElementById("Batfilkkk" + obj["edb"]).value = "1";
                $("#Btntrkerr" + obj["edb"]).css("visibility", "visible").css("color", "black");
                $("#Btntrkerr" + obj["edb"]).replaceWith($("<span>").text(getMessage("I425"))) 
            }
            else if ("2" == obj["status"]) 
            {
                document.getElementById("Errordata_file_name" + obj["edb"]).value = obj["errFilename"];
                document.getElementById("Btntrkerr" + obj["edb"]).value = getMessage("I426");
                document.getElementById("Batfilkkk" + obj["edb"]).value = "2";
                $("#Btntrkerr" + obj["edb"]).css("text-decoration", "underline").css("visibility", "visible") 
            }
            else if ("3" == obj["status"]) 
            {
                document.getElementById("Errordata_file_name" + obj["edb"]).value = obj["errFilename"];
                document.getElementById("Btntrkerr" + obj["edb"]).value = getMessage("I427");
                document.getElementById("Batfilkkk" + obj["edb"]).value = "3";
                $("#Btntrkerr" + obj["edb"]).css("text-decoration", "underline").css("visibility", "visible") 
            }
        };
        $.each(xmlObj, filecallback) 
    }
    return 
}
function importStatusChange(statusId, btnId) 
{
    if ($("#" + statusId).attr("value") === "1") 
    {
        if ($("#" + btnId).css("visibility") != null) 
        {
            $("#" + btnId).css("visibility", "visible").css("color", "black");
            $("#" + btnId).replaceWith($("<span>").text(getMessage("I425"))) 
        }
    }
    else if ($("#" + statusId).attr("value") === "2") 
    {
        if ($("#" + btnId).css("visibility") != null) 
        {
            document.getElementById(btnId).value = getMessage("I426");
            $("#" + btnId).css("text-decoration", "underline").css("visibility", "visible") 
        }
    }
    else if ($("#" + statusId).attr("value") === "3") if ($("#" + btnId).css("visibility") != null) 
    {
        document.getElementById(btnId).value = getMessage("I427");
        $("#" + btnId).css("text-decoration", "underline").css("visibility", "visible") 
    }
}
function ShowInputToolTips() 
{
    var tooltipNode = $("#divTooltip");
    if (!tooltipNode.get(0)) 
    {
        var tooltipNode = $("<div style='background-color:White'>");
        $("body").append(tooltipNode) 
    }
    tooltipNode.css("border", "1px solid black").css("position", "absolute").css("z-index", "99");
    tooltipNode.hide();
    $(".CM_INPUT_TOOLTIPS").each(function () 
    {
        $(this).mouseover(function (event) 
        {
            var value = $(this).attr("value");
            if (typeof value == "undefined") {
                value = $(this).text();
                if (value == "") {
                    return ;
                }
            }
            else if (value == "") {
                return;
            }
            tooltipNode.text(value);
            var offset = tooltipNode.offset();
            tooltipNode.css("left", offset.left + "px").css("top", offset.top + tooltipNode.height() + "px");
            var myEvent = event || window.event;
            tooltipNode.css("left", myEvent.clientX + 5 + "px").css("top", myEvent.clientY + 5 + "px");
            tooltipNode.show("fast") 
        });
        $(this).mouseout(function () 
        {
            tooltipNode.empty();
            tooltipNode.hide() 
        }) 
    }) 
}
var mdListboxMap = new Map;
function mdListBox() 
{
    var target = $("." + CM_LIST_BOX);
    target.attr("tabindex", "-1");
    for (var i = 0; i < target.length; i++) {
        mdListBoxBinder(target[i]);
    }
    mdListPanelHidden() 
}
var listcondition = {
    height : 70, upside : false, addEmpty : true 
};
function mdListBoxBinder(elt) 
{
    var target = $(elt);
    target.focus(function () 
    {
        var storeValue = target.attr("value"), listBoxPanel = mdListboxMap.get(target[0].id);
        listBoxPanel != null && listBoxPanel.hide();
        var offset = $(this).offset(), width = $(this).width();
        listBoxPanel = CreateMdListboxPanel(target, offset, width);
        $("body").append(listBoxPanel);
        listBoxPanel.show();
        var liList = listBoxPanel.children().children("li");
        listBoxPanel.focus();
        var position = {};
        position.max = liList.length;
        position.current = - 1;
        listBoxPanel.keydown(function (event) 
        {
            switch (event.keyCode) 
            {
                case 38:
                    position.current = position.current - 1;
                    if (position.current <= - 1) {
                        position.current = 0;
                    }
                    break;
                case 40:
                    position.current = position.current + 1;
                    if (position.current >= position.max) {
                        position.current = position.max - 1;
                        return 
                    }
                    break;
                case 13:
                    target.attr("value", position.value);
                    listBoxPanel.hide();
                    AdvGB_ActiveControl = target[0];
                    listBoxFlg = true;
                    position.value !== storeValue && $(target[0]).change();
                    break;
                case 9:
                    return false;
                default:
                    return false 
            }
            liList.each(function () 
            {
                $(this).css("backgroundColor", "white") 
            });
            var currentElement = liList.eq(position.current);
            currentElement.css("backgroundColor", "#C0C0C0");
            if (position.current !== - 1) {
                position.value = currentElement.text();
                target.attr("value", position.value) 
            }
        });
        mdListboxMap.put(target[0].id, listBoxPanel) 
    }) 
}
function CreateMdListboxPanel(target, offset, width) 
{
    var topPosition = offset.top + 22;
    if (listcondition.upside) {
        topPosition = offset.top - listcondition.height;
    }
    if (topPosition + listcondition.height > document.body.clientHeight) {
        topPosition = offset.top - listcondition.height - 2;
    }
    else if (topPosition < 0) {
        listcondition.upside = false;
        topPosition = offset.top + 22 
    }
    var listBoxPanel = $("<div style='background-color:White' runat='server'>");
    listBoxPanel.css(
    {
        position : "absolute", top : topPosition, left : offset.left, width : width + 20, border : "1px solid #aaaaaa", 
        fontSize : "12px", textIndent : "4px", cursor : "default", "text-align" : "left", overflow : "auto", 
        height : listcondition.height 
    });
    CreateListItem(target, listBoxPanel);
    return listBoxPanel 
}
function CreateListItem(target, listBoxPanel) 
{
    var ul = $("<ul>"), result = GetDataStore2(target[0].id).attr("list");
    if (result == null || result == "") {
        return;
    }
    result = result.split(",");
    listcondition.addEmpty && ul.append($("<li>").text(""));
    for (var i = 0; i < result.length; i++) 
    {
        var li = $("<li>").text(result[i].toString());
        mdListItemSelectBinder(target, li, listBoxPanel);
        mdListItemMouseOverBinder(li);
        ul.append(li) 
    }
    listBoxPanel.append(ul);
    return ul 
}
function GetDataStore2(targetid) 
{
    var listBoxSotrePanel = $("#" + targetid);
    return listBoxSotrePanel 
}
function mdListItemSelectBinder(target, item, listBoxPanel) 
{
    item.click(function () 
    {
        listBoxPanel.hide();
        if (item.text() !== target.attr("value")) {
            target.attr("value", item.text());
            target.change() 
        }
        else {
            target.attr("value", item.text()) ;
        }
    }) 
}
function mdListItemMouseOverBinder(item) 
{
    var backgroundColor;
    item.mouseover(function () 
    {
        backgroundColor = $(this).css("backgroundColor");
        $(this).css("backgroundColor", "#C0C0C0") 
    });
    item.mouseout(function () 
    {
        $(this).css("backgroundColor", backgroundColor) 
    }) 
}
function mdListPanelHidden() 
{
    $("body").click(function () 
    {
        var eventEltId = event.srcElement.id, keysArray = mdListboxMap.keys;
        for (i = 0; i < keysArray.length; i++) 
        {
            var listBoxPanel = mdListboxMap.get(keysArray[i]);
            eventEltId != keysArray[i] && listBoxPanel.hide() 
        }
    }) 
}
function SetDataToStore(targetid, data) 
{
    var elt = GetDataStore2(targetid);
    elt.attr("list", data) 
}
function fireFather(formId, reloadButtonId) 
{
    if (reloadButtonId == null || reloadButtonId == "" || formId == null || formId == "") {
        return;
    }
    var p = $("form"), flag = p.attr("PG_SYN");
    if (flag != null && flag != "") 
    {
        p.attr("PG_SYN", "");
        if (opener.closed == true) {
            return;
        }
        try {
            opener.document.forms[formId].elements[reloadButtonId].fireEvent("onclick") 
        }
        catch (e) {
            return ;
        }
    }
}
function OpenSynPG(param, pgid) 
{
    if (param == null || param == "") {
        return;
    }
    var width = getBrowserWidth(), height = getBrowserHeight();
    OpenPG(param, pgid, width, height, true) 
}
function OpenPG(param, pgid, width, height, syn) 
{
    try 
    {
        win1 = window.open("", pgid, "top=4000,left=4000,width=1px,height=1px");
    	
    	//開いた子画面もメニュー終了時の閉じる対象とする
    	var targetNo = "0";
		if (window.localStorage.getItem("webserver.targetNo") != null){
			targetNo = window.localStorage.getItem("webserver.targetNo");
		}
		window.localStorage.setItem("tname" + targetNo, pgid);
		window.localStorage.setItem("webserver.targetNo", parseInt(targetNo) + 1);
    	
        if (win1.location.href != "about:blank") 
        {
            var returnValue = showModalDialog("../pjcommon/mdAspx/Confirm.aspx?pgId=&mess=&proc=proc1", 
            this, "dialogWidth:350px;dialogHeight:80px;status:no;center:yes;edge:sunken;help:no;resizable:no;scroll:no;dependent:no");
            try {
                if (returnValue[0] != null && returnValue[0].length > 0) {
                    return;
                }
                else {
                    return ;
                }
            }
            catch (e) {
                return 
            }
            return 
        }
        win1.close();
        var Positioning = GetCookie("LoginPositioning"), TopPosition = GetCookie("LoginTopPositionAdjustment"), 
        Top = GetCookie("LoginPositionTop"), Left = GetCookie("LoginPositionLeft"), Toolbar = "no", Location = "no", 
        Directories = "no", Menubar = "no", Scrollbars = "no", Status = "yes", Resizable = "no", WindowStyle = "";
        if (Positioning != null && Positioning == "true")
        {
            if (TopPosition != null) 
            {
                Top = (screen.height - height - TopPosition)  / 2;
                if (Top < 0) {
                    Top = 0;
                }
                Left = (screen.width - width)  / 2;
                WindowStyle = ",width=" + width + ",height=" + height + ",top=" + Top + ",left=" + Left + ",toolbar=" + Toolbar + ",location=" + Location + ",directories=" + Directories + ",menubar=" + Menubar + ",scrollbars=" + Scrollbars + ",status=" + Status + ",resizable=" + Resizable 
            }
            else if (Top != null)
            {
                WindowStyle = ",width=" + width + ",height=" + height + ",top=" + Top + ",left=" + Left + ",toolbar=" + Toolbar + ",location=" + Location + ",directories=" + Directories + ",menubar=" + Menubar + ",scrollbars=" + Scrollbars + ",status=" + Status + ",resizable=" + Resizable;
            }
            else
            {
                WindowStyle = ",width=" + width + ",height=" + height + ",toolbar=" + Toolbar + ",location=" + Location + ",directories=" + Directories + ",menubar=" + Menubar + ",scrollbars=" + Scrollbars + ",status=" + Status + ",resizable=" + Resizable;
            }
        }
        else
        {
            WindowStyle = ",width=" + width + ",height=" + height + ",toolbar=" + Toolbar + ",location=" + Location + ",directories=" + Directories + ",menubar=" + Menubar + ",scrollbars=" + Scrollbars + ",status=" + Status + ",resizable=" + Resizable;
        }
        var baseWebName = "Base";
        try {
            baseWebName = $("#header_BASEWEBNAME").get(0).value 
        }
        catch (e) { }
        var url = "../../" + baseWebName + "/Common/PageTransfer.aspx?" + param;
        if (syn) {
            window.PG_SYN = open(url, pgid, WindowStyle);
            window.opener.winobj[targetNo] = window.PG_SYN;
			// 0.1秒毎2秒間オープンした画面にフォーカスを設定する。
			var count = 0;
			var id = setInterval(function(){
				count = count + 1;
				window.PG_SYN.focus();
				if (count > 20){
					clearInterval(id);	//idをclearIntervalで指定している
				}
			}, 100);
            return window.PG_SYN 
        }
        else {
            var newwinobj = open(url, pgid, WindowStyle) ;
            window.opener.winobj[targetNo] = newwinobj;
			// 0.1秒毎2秒間オープンした画面にフォーカスを設定する。
			var count = 0;
			var id = setInterval(function(){
				count = count + 1;
				newwinobj.focus();
				if (count > 20){
					clearInterval(id);	//idをclearIntervalで指定している
				}
			}, 100);
            return newwinobj;
        }
    }
    catch (e) { }
}
function OpenUpdateConfirm() 
{
    showModalDialog("../pjcommon/mdAspx/UpdateConfirm.aspx?pgId=" + ADVIT_TARGETPGID, this, "status:no;dialogWidth:600px;dialogHeight:350px;center:yes;edge:sunken;help:no;resizable:no;scroll:no;dependent:no") 
}
function getBrowserWidth() 
{
    if (window.innerWidth) {
        return window.innerWidth;
    }
    else if (document.documentElement && document.documentElement.clientWidth != 0) {
        return document.documentElement.clientWidth;
    }
    else if (document.body) {
        return document.body.clientWidth;
    }
    return 0 
}
function getBrowserHeight() 
{
    if (window.innerHeight) {
        return window.innerHeight;
    }
    else if (document.documentElement && document.documentElement.clientHeight != 0) {
        return document.documentElement.clientHeight;
    }
    else if (document.body) {
        return document.body.clientHeight;
    }
    return 0 
}
function GetCookie(name) 
{
    var arg = name + "=", alen = arg.length, clen = document.cookie.length, i = 0;
    while (i < clen) 
    {
        var j = i + alen;
        if (document.cookie.substring(i, j) == arg) {
            return GetCookieVal(j);
        }
        i = document.cookie.indexOf(" ", i) + 1;
        if (i == 0) {
            break ;
        }
    }
    return null 
}
function GetCookieVal(offset) 
{
    var endstr = document.cookie.indexOf(";", offset);
    if (endstr == - 1) {
        endstr = document.cookie.length;
    }
    return unescape(document.cookie.substring(offset, endstr)) 
}
function EndProgramWindowClose(pgid) 
{
    userClick = true;
    endProgram(pgid) 
}
function screenLock(blocker) 
{
    var b = blocker || false;
    shoriStatus.onDealing();
    if (!b) 
    {
        blocker = "<div id='screen' style='position:absolute;z-index:1;width:100%;height:100%;filter: alpha(opacity=15);opacity: 0.15;background-color:silver;top:0px;left:0px;'></div>";
        $("body").append(blocker) 
    }
    feature = "dialogWidth:280px;dialogHeight:130px;status:no;center:yes;edge:sunken;help:no;resizable:no;scroll:no;dependent:no;unadorned:no;edge:sunken ";
    // TODO yusy 一旦修正showModelessDialog⇒window.open
    var dialog = window.open("../pjcommon/html/Wait.html?mdWaitMessageID=" + mdWaitMessageID, window, feature);
    mdWaitMessageID = "";
    return dialog 
}
function screenLockOnly() 
{
    blocker = "<div id='screen' style='position:absolute;z-index:1;width:100%;height:100%;filter: alpha(opacity=15);opacity: 0.15;background-color:silver;top:0px;left:0px;'></div>";
    $("body").append(blocker) 
}
var waitStatus = 
{
    flg : 1,
    UIBlock : function () 
    {
        waitStatus["flg"] = 2 ;
    },
    none : function () 
    {
        waitStatus["flg"] = 3 ;
    },
    show : function () 
    {
        return waitStatus["flg"] ;
    }
},
shoriStatus = 
{
    dealing : false,
    onDealing : function () 
    {
        shoriStatus["dealing"] = true ;
    },
    stop : function () 
    {
        shoriStatus["dealing"] = false ;
    },
    show : function () 
    {
        return shoriStatus["dealing"] ;
    }
};
function showRunDownload() 
{
    showModalDialog("../pjcommon/mdAspx/UpdateConfirm.aspx?pgId=" + ADVIT_TARGETPGID, this, "status:no;dialogWidth:400px;dialogHeight:250px;center:yes;edge:sunken;help:no;resizable:no;scroll:no;dependent:no") 
}
var warning = 
{
    btnId : "", status : "", errBtnId : "",
    go : function () 
    {
        $("#" + warning.btnId).get(0).click() 
    },
    importStatusChange : function () 
    {
        importStatusChange(warning.status, warning.errBtnId) 
    },
    dialog : function (value, status, errBtn, flg) 
    {
        var f;
        if (value == null) {
            return;
        }
        if (flg === true) {
            f = "YES";
        }
        warning.btnId = value;
        warning.status = status;
        warning.errBtnId = errBtn;
        // TODO yusy 一旦修正showModelessDialog⇒window.open
        window.open("../pjcommon/mdAspx/WarnConfirm.aspx?pgid=" + ADVIT_TARGETPGID + "&flg=" + f,
        window, "status:no;dialogwidth:600px;dialogheight:350px;center:yes;edge:sunken;help:no;resizable:no;scroll:no;dependent:no") 
    }
};
function showDisp(callback) 
{
    if (typeof callback === "function")
    {
        $("#cmWrapperGuard").fadeOut(100, callback);
    }
    else {
        $("#cmWrapperGuard").fadeOut(100) ;
    }
}
function XN541P01(date, kbn) 
{
    date = replaceAll(date, "/", "");
    var d = new Date(date.substring(0, 4), date.substring(4, 6) - 1, date.substring(6, 8));
    switch (kbn) 
    {
        case "1":
        case 1:
            var w = ["\u65e5", "\u6708", "\u706b", "\u6c34", "\u6728", "\u91d1", "\u571f"];
            return w[d.getDay()];
        default:
            return null 
    }
    return null 
}
function radioButtonDisabled(id, value) 
{
    var cntl = getCTL(id);
    if (cntl == null) {
        return;
    }
    if ("length" in cntl)
    {
        for (var i = 0; i < cntl.length; i++) if (value) {
            if (!cntl[i].checked) {
                cntl[i].disabled = value ;
            }
        }
    }
    else {
        cntl[i].disabled = value ;
    }
}
function replaceAll(expression, org, dest) 
{
    return expression.split(org).join(dest) 
}
/*-----------------------------------------------------------------------------
　画面サイズ調整用の共通関数　ここから
-----------------------------------------------------------------------------*/
/*-----------------------------------------------------------------------------
true:標準サイズ false:最大サイズ
-----------------------------------------------------------------------------*/
var common_gamenFlg = true;
/*-----------------------------------------------------------------------------
画面サイズ調整用の定数
-----------------------------------------------------------------------------*/
var CONST_TATE_AJDUST = 90;
//リサイズ時の縦幅の調整(初期値)
var CONST_YOKO_AJDUST = 20;
//リサイズ時の横幅の調整(初期値)
var CONST_MOVE_TOP_AJDUST = 8;
//移動時の横位置の調整(初期値)
var CONST_HEIGHT = 678;
//最少化時の縦サイズ
var CONST_WIDTH = 1016;
//横サイズ
var CONST_HEIGHT_STD_MAX = 710;
//標準サイズの上限(標準か最大化の判定に使用)
/*-----------------------------------------------------------------------------
IEバージョンに合わせた定数の設定
-----------------------------------------------------------------------------*/
function setConstByIEVersion() 
{
    var appVersion = window.navigator.appVersion.toLowerCase();
    if (appVersion.indexOf("msie 7.") != - 1) {
        //IE7
        CONST_TATE_AJDUST = 90;
        CONST_YOKO_AJDUST = 20;
        CONST_MOVE_TOP_AJDUST = 3;
    }
    if (appVersion.indexOf("msie 8.") != - 1) {
        //IE8
        CONST_TATE_AJDUST = 90;
        CONST_YOKO_AJDUST = 10;
        CONST_MOVE_TOP_AJDUST = 3;
    }
    if (appVersion.indexOf("msie 9.") != - 1) {
        //IE9
        CONST_TATE_AJDUST = 90;
        CONST_YOKO_AJDUST = 20;
        CONST_MOVE_TOP_AJDUST = 8;
    }
}
/*-----------------------------------------------------------------------------
リサイズ処理(初期ロード時)
-----------------------------------------------------------------------------*/
function adjustToWindowSize() 
{
    setConstByIEVersion();
    //調整サイズの設定
    tate = document.documentElement.clientHeight;
    //ウィンドウ 縦　標準:672
    if (tate > CONST_HEIGHT_STD_MAX) 
    {
        //標準より大きい場合は最大とする
        common_gamenFlg = false;
        adjustToWindowSize(tate - CONST_HEIGHT);
    }
}
/*-----------------------------------------------------------------------------
リサイズ処理(Shift+F9押下時)
-----------------------------------------------------------------------------*/
function resizeWindow() 
{
    //リサイズ対応がされていない画面は関数がないため処理終了
    if (typeof adjustToWindowSize != "function") 
    {
        return false;
    }
    //Windowを最上部に移動
    moveTo(window.screenLeft - CONST_MOVE_TOP_AJDUST, 0);
    //現在のWindowサイズ
    tate = document.documentElement.clientHeight;
    //縦幅
    //yoko = document.documentElement.clientWidth; //横幅
    yoko = CONST_WIDTH;
    //画面縦サイズの設定
    if (!common_gamenFlg) {
        //標準サイズに戻す
        tate = CONST_HEIGHT;
        common_gamenFlg = true;
    }
    else 
    {
        //縦に長くする
        //ありえないサイズに大きくして最大Windows縦サイズを取得
        resizeTo(yoko + CONST_YOKO_AJDUST, 3000);
        tate = document.documentElement.clientHeight;
        //縦幅
        if (tate < CONST_HEIGHT_STD_MAX) {
            //最大化しても大きくならない場合は標準サイズのまま
            tate = CONST_HEIGHT;
            common_gamenFlg = true;
        }
        else {
            common_gamenFlg = false;
        }
    }
    //Windowのリサイズ
    resizeTo(yoko + CONST_YOKO_AJDUST, tate + CONST_TATE_AJDUST);
    //各画面の調整関数の呼び出し
    adjustToWindowSize(tate - CONST_HEIGHT);
    return false;
}
/*-----------------------------------------------------------------------------
スタイルシートの高さ(height)の再設定
name: 変更スタイル名
height: 変更後の高さ(height属性)
-----------------------------------------------------------------------------*/
function setStyleHeight(name, height) 
{
    sheets = document.styleSheets;
    for (var i = 0; i < sheets.length; i++) 
    {
        sheet = sheets[i];
        rules = sheet.rules;
        for (var j = 0; j < rules.length; j++) 
        {
            rule = rules[j];
            selectorText = rule.selectorText;
            index = selectorText.indexOf(name);
            if (index != - 1) 
            {
                if (selectorText.substr(index, name.length) == name) {
                    rule.style.height = height;
                    break;
                }
            }
        }
    }
}
/*-----------------------------------------------------------------------------
スタイルシートを設定。既に設定がされている場合は行わない。
name: 変更するdiv名(id属性)
cssname: スタイルシート名(class属性)
-----------------------------------------------------------------------------*/
function setClass(name, cssname) 
{
    cname = $(name)[0].className;
    if (cname === undefined || cname == "") {
        $(name)[0].className = cssname;
    }
}
/*-----------------------------------------------------------------------------
　画面サイズ調整用の共通関数　ここまで
-----------------------------------------------------------------------------*/
