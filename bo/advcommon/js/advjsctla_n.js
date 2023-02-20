var AdvGB_TargetForm = null;
var AdvGB_ActiveControl;
var AdvGB_LastClickItem;
var AdvGB_LastClickItemNm;
var AdvGB_LastClickItemMNo;
var AdvGB_FirstFindSubmit;
var AdvGB_CodeWindowOpen = null;
var AdvGB_SubmitFLG = false;
var AdvGB_MRowCnt;
var AdvGB_ID_STRING;
var AdvGB_M_SNO_EXT = "PageStartRow";
var AdvGB_M_ID_MEDFIX = "_ctl[0-9]{1,5}_";
var AdvGB_M_NAME_MEDFIX = /\$ctl[0-9]{1,5}\$/;
var AdvGB_TrimMode = true;
var Std_NavNm;
var Std_NavIE = false;
var AdvGB_MCtrlStartIdx = 2;
var AdvGB_CHK_SpcMove = true;
if (AdvGB_Compatible === undefined) {
  var AdvGB_Compatible = true;
}
Std_NavNm = getAdvNavigatorName();
if (Std_NavNm == "IE") {
  Std_NavIE = true;
}
function trimStd(iStr) {
  return iStr.replace(/^[ ]+|[ ]+$/g, '');
}
function onLoadFormSet_adv() {
  if (document.forms.length == 0) {
    return false;
  }
  if (document.forms[0].name.toUpperCase() == ADVIT_FORMID.toUpperCase()) {
    AdvGB_TargetForm = document.forms[0];
  }
  if (AdvGB_TargetForm == null) {
    AdvGB_TargetForm = document.forms[0];
  }
  AdvGB_TargetForm.onsubmit = onSubmitPrev_std;
  document.onkeypress = g_onKeyPress;
  AdvGB_MRowCnt = new Array(9);
  for (i = 0;
    i < 10;
    i++) {
    AdvGB_MRowCnt[i] = 0;
  }
  if (!Std_NavIE) {
    AdvGB_ID_STRING = "," + ADVIT_ID.toString() + ",";
  }
  clearAdvEventTarget();
}
function onLoadLinkSet_adv(iLink) {
  var ADVIT_ID2 = getAdvItemIDfromCtrl(iLink);
  var cmnCIdx = getAdvControlIdxFromName(ADVIT_ID2);
  if (cmnCIdx < 0) {
    return;
  }
  if (AdvGB_Debug) {
    if (ADVIT_TYPE[cmnCIdx] != "LNK" && ADVIT_TYPE[cmnCIdx] != "LNS") {
      alert("リンク<a name=\"" + iLink.name + "\"> は、入出力情報上「" + ADVIT_TYPE[cmnCIdx] + "」として定義されています。");
      return;
    }
  }
  iLink.href = '';
  iLink.onclick = g_onClick;
}
function onLoadCtrlSet_adv(iCtrl) {
  var cmnCIdx;
  if (iCtrl.name == null) {
    return false;
  }
  cmnCIdx = getAdvControlIdxFromName(iCtrl.name);
  if (cmnCIdx < 0) {
    return;
  }
  if (AdvGB_Debug) {
    if (!checkIoCtl_std(iCtrl, cmnCIdx)) {
      return false;
    }
  }
  switch (ADVIT_TYPE[cmnCIdx]) {
    case "TXR": iCtrl.readOnly = true;
    case "PWD": case "TX2": case "TXT": case "FUP": iCtrl.onfocus = g_onFocus;
      iCtrl.onblur = g_onBlur;
      iCtrl.onchange = g_onChange;
      if (ADVIT_MAXLENGTHMODE[cmnCIdx] == 1) {
        iCtrl.maxLength = getAdvMaxLength(cmnCIdx, true);
      }
      if (Std_NavIE) {
        switch (parseFloat(ADVIT_IMEMODE[cmnCIdx])) {
          case 1: case 4: case 5: case 6: case 7: case 8: iCtrl.style.imeMode = "active";
            break;
          case 2: iCtrl.style.imeMode = "inactive";
            break;
          case 3: iCtrl.style.imeMode = "disabled";
            break;
        }
      }
      break;
    case "SUB": if (AdvGB_FirstFindSubmit == null) {
      AdvGB_FirstFindSubmit = iCtrl;
      AdvGB_LastClickItem = iCtrl;
    }
    case "CLR": case "BTN": case "BTS": iCtrl.onfocus = g_onFocus;
      iCtrl.onblur = g_onBlur;
      iCtrl.onclick = g_onClick;
      break;
    case "CHK": case "RDO": iCtrl.onclick = g_onClick;
    case "DRL": iCtrl.onfocus = g_onFocus;
      iCtrl.onblur = g_onBlur;
      iCtrl.onchange = g_onChange;
      break;
  }if (ADVIT_LEVEL[cmnCIdx] != "" && iCtrl.name.toLowerCase().match(AdvGB_M_NAME_MEDFIX) != null) {
    var i = ADVIT_LEVEL[cmnCIdx].substr(1, 1);
    if (AdvGB_MRowCnt[i] < getAdvItemMNofromCtrl(iCtrl)) {
      AdvGB_MRowCnt[i] = getAdvItemMNofromCtrl(iCtrl);
    }
  }
}
function checkIoCtl_std(iCtrl, iCIdx) {
  var cmnErrMsg = "";
  if (iCtrl.type != null) {
    switch (iCtrl.type.toLowerCase()) {
      case "text": if (ADVIT_TYPE[iCIdx] != "TXT" && ADVIT_TYPE[iCIdx] != "TXR") {
        cmnErrMsg = "テキストフィールド<input type=\"text\"";
      }
        break;
      case "textarea": if (ADVIT_TYPE[iCIdx] != "TX2") {
        cmnErrMsg = "テキストエリア<textarea";
      }
        break;
      case "password": if (ADVIT_TYPE[iCIdx] != "PWD") {
        cmnErrMsg = "パスワードフィールド<input type=\"password\"";
      }
        break;
      case "select-one": case "select-multiple": if (ADVIT_TYPE[iCIdx] != "DRL") {
        cmnErrMsg = "ドロップダウンリスト<select";
      }
        break;
      case "checkbox": if (ADVIT_TYPE[iCIdx] != "CHK") {
        cmnErrMsg = "チェックボックス<input type=\"checkbox\"";
      }
        break;
      case "radio": if (ADVIT_TYPE[iCIdx] != "RDO") {
        cmnErrMsg = "ラジオボタン<input type=\"radio\"";
      }
        break;
      case "button": if (ADVIT_TYPE[iCIdx] != "BTN" && ADVIT_TYPE[iCIdx] != "BTS") {
        cmnErrMsg = "ボタン<input type=\"button\"";
      }
        break;
      case "submit": if (ADVIT_TYPE[iCIdx] != "SUB") {
        cmnErrMsg = "サブミットボタン<input type=\"submit\"";
      }
        break;
      case "reset": if (ADVIT_TYPE[iCIdx] != "CLR") {
        cmnErrMsg = "リセット<input type=\"reset\"";
      }
        break;
      case "file": if (ADVIT_TYPE[iCIdx] != "FUP") {
        cmnErrMsg = "ファイルアップデート<input type=\"file\"";
      }
        break;
      case "hidden": if (ADVIT_TYPE[iCIdx] != "HDN") {
        cmnErrMsg = "隠しフィールド<input type=\"hidden\"";
      }
        break;
    }
  }
  if (cmnErrMsg.length > 0) {
    alert(cmnErrMsg + " name=\"" + iCtrl.name + "\"> は、入出力情報上「" + ADVIT_TYPE[iCIdx] + "」として定義されています。");
    return false;
  }
  else {
    return true;
  }
}
function onUnLoad_adv() {
  if (Std_NavIE) {
    closeAdvCodeWindow();
  }
  return true;
}
function closeAdvCodeWindow() {
  try {
    AdvGB_CodeWindowOpen.close();
  }
  catch (e) {
    return true;
  }
  return;
}
function onFocus_adv(iCtrl) {
  var advVal;
  var cmnName;
  switch (iCtrl.type.toLowerCase()) {
    case "text": case "textarea": case "password": cmnName = getAdvItemIDfromCtrl(iCtrl);
      if (ADVIT_TYPE[eval("ADVIT_ID_" + cmnName.toUpperCase())] == "TXR") {
        if (Std_NavNm == "NN") {
          iCtrl.blur();
        }
        return;
      }
      if (AdvGB_AutoFormat) {
        advVal = getAdvUnFormat(iCtrl);
        if (iCtrl.value.toLowerCase() != advVal.toLowerCase()) {
          iCtrl.value = advVal;
        }
      }
      if (iCtrl.type.toLowerCase() != "textarea") {
        iCtrl.select();
      }
  }AdvGB_ActiveControl = iCtrl;
}
function onBlur_adv(iCtrl) {
  var advVal;
  var cmnName;
  switch (iCtrl.type.toLowerCase()) {
    case "text": case "textarea": case "password": cmnName = getAdvItemIDfromCtrl(iCtrl);
      if (ADVIT_TYPE[eval("ADVIT_ID_" + cmnName.toUpperCase())] == "TXR") {
        return;
      }
      advVal = iCtrl.value;
      if ((AdvGB_AutoFormat) && (ADVIT_ATTRIBUTE[eval("ADVIT_ID_" + cmnName.toUpperCase())] != "DX")) {
        advVal = getAdvFormat(iCtrl);
      }
      if (advVal == 0 && (advVal.length == null || ADVIT_ATTRIBUTE[eval("ADVIT_ID_" + cmnName.toUpperCase())] == "D")) {
        advVal = iCtrl.value;
      }
      iCtrl.value = advVal;
  }AdvGB_ActiveControl = null;
}
function onSubmit_adv() {
  var cmnChkGroup = "";
  if (!AdvGB_ClientChk) {
    return true;
  }
  AdvGB_SepDateItN = "";
  AdvGB_SepDateIDX = -1;
  AdvGB_RdoIdArray = new Array(32);
  AdvGB_RdoMNoArray = new Array(32);
  AdvGB_RdoCheckedArray = new Array(32);
  AdvGB_RdoCtrlArray = new Array(32);
  AdvGB_RdoCIdxArray = new Array(32);
  for (var i = 0;
    i < AdvGB_RdoCheckedArray.length;
    i++) {
    AdvGB_RdoCheckedArray[i] = false;
  }
  if (AdvGB_LastClickItemNm != null) {
    cmnChkGroup = ADVIT_ACTPARAMETER[getAdvControlIdxFromName(AdvGB_LastClickItemNm)];
    if (cmnChkGroup.match("^[Mm][0-9]$") == null) {
      cmnChkGroup = "";
    }
  }
  var cmnElemCount = AdvGB_TargetForm.elements.length;
  var cmnElem = AdvGB_TargetForm.elements;
  for (var i = 0;
    i < cmnElemCount;
    i++) {
    if (cmnChkGroup == "") {
      if (!checkAdvItem(cmnElem[i], null)) {
        return false;
      }
    }
    else {
      if (!checkAdvItem(cmnElem[i], cmnChkGroup)) {
        return false;
      }
    }
  }
  if (AdvGB_SepDateIDX >= 0) {
    if (!EndDX_std()) {
      if (AdvGB_SepDateMNo == -1) {
        var cmnCtrl = null;
        var count = 1;
        while (count < 4) {
          cmnCtrl = getAdvControlFromIdx(AdvGB_SepDateIDX + count);
          if (cmnCtrl != null) {
            break;
          }
          ++count;
        }
      }
      else {
        var cmnCtrl = null;
        var count = 1;
        while (count < 4) {
          cmnCtrl = getAdvControlFromIdx(AdvGB_SepDateIDX + count, AdvGB_SepDateMNo);
          if (cmnCtrl != null) {
            break;
          }
          ++count;
        }
      }
      if (cmnCtrl != null) {
        cmnCtrl.focus();
      }
      return false;
    }
  }
  for (var i = 0;
    i < AdvGB_RdoIdArray.length;
    i++) {
    if (AdvGB_RdoIdArray[i] == null) {
      break;
    }
    var cmnIDisabled_Buff = false;
    if (Std_NavIE) {
      if (AdvGB_RdoCtrlArray[i].disabled == true) {
        cmnIDisabled_Buff = true;
      }
    }
    if (AdvGB_RdoCheckedArray[i] == false && cmnIDisabled_Buff == false) {
      alert(getAdvAssembleMsg(ADVMS_STR[ADVMS_ID_S103], AdvGB_RdoCIdxArray[i], ""));
      AdvGB_RdoCtrlArray[i].focus();
      return false;
    }
  }
  return true;
}
function onClick_adv(iCtrl) {
  var cmnCodType;
  var cmnLevelId;
  var cmnCName = getAdvItemIDfromCtrl(iCtrl);
  var cmnCMNo = getAdvItemMNofromCtrl(iCtrl);
  var cmnCIdx = getAdvControlIdxFromName(cmnCName);
  var cmnACTPARAMETER;
  var cmnACTIONID;
  if (cmnCIdx >= 0) {
    cmnLevelId = ADVIT_LEVEL[cmnCIdx].toLowerCase();
    cmnACTPARAMETER = ADVIT_ACTPARAMETER[cmnCIdx].toUpperCase();
    cmnACTIONID = ADVIT_ACTIONID[cmnCIdx];
    AdvGB_LastClickItem = iCtrl;
    AdvGB_LastClickItemNm = cmnCName;
    AdvGB_LastClickItemMNo = cmnCMNo;
    if ((ADVIT_CODEID[cmnCIdx] != "") && ((ADVIT_ACTIONID[cmnCIdx] == "COD") || (ADVIT_ACTIONID[cmnCIdx] == "COG"))) {
      if (ADVIT_ACTIONID[cmnCIdx] == "COD") {
        cmnCodType = "COD";
        showAdvCodeWindow(cmnCName, cmnCMNo, cmnCodType, cmnLevelId, ADVIT_CODEID[cmnCIdx]);
      }
      if (ADVIT_ACTIONID[cmnCIdx] == "COG") {
        cmnCodType = "COG";
        showAdvCodeWindow(cmnCName, cmnCMNo, cmnCodType, cmnLevelId, ADVIT_CODEID[cmnCIdx]);
      }
      return false;
    }
    switch (ADVIT_TYPE[cmnCIdx]) {
      case "SUB": clearAdvEventTarget();
        return true;
      case "BTS": case "LNS": setAdvEventTarget(iCtrl);
        return execAdvSubmit2(iCtrl, AdvGB_TargetForm.action);
      case "BTN": case "LNK": return false;
    }
  }
  return true;
}
function setAdvEventTarget(iCtrl) {
  if (AdvGB_TargetForm.__EVENTTARGET != null) {
    AdvGB_TargetForm.__EVENTTARGET.value = getStdADVIDfromCtrl(iCtrl);
    AdvGB_TargetForm.__EVENTARGUMENT.value = '';
  }
  else {
    var evtTarget = document.createElement("input");
    evtTarget.id = "__EVENTTARGET";
    evtTarget.name = "__EVENTTARGET";
    evtTarget.type = "hidden";
    evtTarget.value = "";
    var evtArg = document.createElement("input");
    evtArg.id = "__EVENTARGUMENT";
    evtArg.name = "__EVENTARGUMENT";
    evtArg.type = "hidden";
    evtArg.value = "";
    AdvGB_TargetForm.appendChild(evtTarget);
    AdvGB_TargetForm.appendChild(evtArg);
    AdvGB_TargetForm.elements("__EVENTTARGET").value = getStdADVIDfromCtrl(iCtrl);
    AdvGB_TargetForm.elements("__EVENTARGUMENT").value = '';
  }
}
function clearAdvEventTarget() {
  if (AdvGB_TargetForm.__EVENTTARGET != null) {
    AdvGB_TargetForm.__EVENTTARGET.value = '';
    AdvGB_TargetForm.__EVENTARGUMENT.value = '';
  }
}
function onChange_adv(iCtrl) {
  return true;
}
function onKeyPress_adv(ev) {
  var cmnKeyAsc;
  var cmnKeySft, cmnKeyCtr, cmnKeyAlt;
    var v_e = ev || window.event;
  // TODO yusy IE判定は一旦コメントアウト
  //if (Std_NavIE) {
    cmnKeyAsc = event.keyCode;
    cmnKeySft = event.shiftKey;
    cmnKeyCtr = event.ctrlKey;
    cmnKeyAlt = event.altKey;
  //}
  //else if (document.getElementById) {
  //  cmnKeyAsc = ev.charCode;
  //  cmnKeyAsc = ev.keyCode;
  //  cmnKeySft = ev.shiftKey;
  //  cmnKeyCtr = ev.ctrlKey;
  //  cmnKeyAlt = ev.altKey;
  //  ev.charCode = 0;
  //  ev.keyCode = 0;
  //  return true;
  //}
  if (AdvGB_ActiveControl == null) {
    return true;
  }
  if (cmnKeyAsc == 13 || cmnKeyAsc == 10) {
    if (AdvGB_TabOnEnter) {
      return KeyPressEnter_std(cmnKeyCtr, cmnKeySft, cmnKeyAlt);
    }
    else {
      return execAdvSubmit();
    }
  }
  switch (AdvGB_ActiveControl.type.toLowerCase()) {
    case "text": case "textarea": case "password": if (Std_NavIE) {
      if (AdvGB_ActiveControl.readOnly == true) {
        return true;
      }
    }
  }if (cmnKeyAsc == 32 && (cmnKeyCtr || cmnKeySft)) {
    if (AdvGB_TabOnEnter) {
      return KeyPressSpace_std(cmnKeyCtr, cmnKeySft, cmnKeyAlt);
    }
  }
  switch (AdvGB_ActiveControl.type.toLowerCase()) {
    case "text": case "textarea": case "password": var cmnCIdx = getAdvControlIdxFromName(AdvGB_ActiveControl.name);
      if (AdvGB_KeyFilter) {
        if (AdvGB_Compatible) {
          if (!KeyFiltering_std(cmnKeyAsc, cmnCIdx)) {
            return false;
          }
        }
        else {
          if (!inputFilter_std.apply(v_e.target || v_e.srcElement, [v_e])) {
            return false;
          }
        }
      }
      if (Std_NavIE) {
        if (event.keyCode != 0 && ADVIT_AUTOTAB[cmnCIdx] == 1) {
          var cmnSelectCtrlText;
          var cmnValue = AdvGB_ActiveControl.value;
          if (document.selection) {
            cmnSelectCtrlText = document.selection.createRange().text;
          }
          else {
            cmnSelectCtrlText = cmnValue.substring(AdvGB_ActiveControl.selectionStart, AdvGB_ActiveControl.selectionEnd);
          }
          switch (ADVIT_ATTRIBUTE[cmnCIdx].substr(0, 1)) {
            case "N": var cmnItemLength;
              switch (ADVIT_FORMAT[cmnCIdx]) {
                case "00": case "10": case "11": case "12": case "14": case "15": case "18": case "19": case "21": case "22": case "31": case "32": case "34": case "35": case "37": case "38": cmnItemLength = ADVIT_LENGTH[cmnCIdx];
                  break;
                default: var lengthMethod = window["quiqCustomFormatLength" + ADVIT_FORMAT[cmnCIdx]];
                  if (lengthMethod == undefined) {
                    alert("Not found the unformat method \"quiqCustomFormatLength" + ADVIT_FORMAT[cmnCIdx] + "\".");
                    cmnItemLength = ADVIT_LENGTH[cmnCIdx];
                  }
                  else {
                    cmnItemLength = lengthMethod(ADVIT_ID[cmnCIdx], false);
                  }
                  break;
              }if (cmnValue.substr(0, 1) == "+" || cmnValue.substr(0, 1) == "-") {
                cmnValue = cmnValue.substring(1, cmnValue.length);
              }
              if (cmnItemLength > 0) {
                if (ADVIT_DECIMAL[cmnCIdx] > 0) {
                  if (cmnSelectCtrlText.length > 0) {
                    break;
                  }
                  if (cmnValue.indexOf(AdvGB_DecimalStr) >= 0) {
                    if (ADVIT_DECIMAL[cmnCIdx] != cmnValue.substring(cmnValue.indexOf(AdvGB_DecimalStr) + 1, cmnValue.length).length + 1) {
                      break;
                    }
                  }
                  else {
                    break;
                  }
                }
                else {
                  if (cmnItemLength != cmnValue.length - cmnSelectCtrlText.length + 1) {
                    break;
                  }
                }
                if (document.selection) {
                  document.selection.createRange().text = "";
                  document.selection.createRange().text = String.fromCharCode(event.keyCode);
                }
                else {
                  AdvGB_ActiveControl.value = AdvGB_ActiveControl.value.substring(0, AdvGB_ActiveControl.selectionStart) + String.fromCharCode(event.keyCode) + AdvGB_ActiveControl.value.substr(AdvGB_ActiveControl.selectionEnd);
                }
                getAdvNextCtrl(AdvGB_ActiveControl).focus();
                event.returnValue = false;
                return false;
              }
              break;
            default: if (cmnValue.length - cmnSelectCtrlText.length + 1 == getAdvMaxLength(getAdvControlIdxFromName(AdvGB_ActiveControl.name), false)) {
              if (document.selection) {
                document.selection.createRange().text = "";
                document.selection.createRange().text = String.fromCharCode(event.keyCode);
              }
              else {
                AdvGB_ActiveControl.value = AdvGB_ActiveControl.value.substring(0, AdvGB_ActiveControl.selectionStart) + String.fromCharCode(event.keyCode) + AdvGB_ActiveControl.value.substr(AdvGB_ActiveControl.selectionEnd);
              }
              getAdvNextCtrl(AdvGB_ActiveControl).focus();
              event.returnValue = false;
              return false;
            }
          }
        }
      }
      return true;
  }
}
var AdvGB_SepDateIDX = -1;
var AdvGB_SepDateItN = "";
var AdvGB_SepDateMNo = -1;
var AdvGB_SepD_Y = "";
var AdvGB_SepD_M = "";
var AdvGB_SepD_D = "";
var AdvGB_SepD_H = "";
var AdvGB_SepD_N = "";
var AdvGB_SepD_S = "";
var AdvGB_RdoIdArray;
var AdvGB_RdoCheckedArray;
var AdvGB_RdoCtrlArray;
var AdvGB_RdoCIdxArray;
function getAdvByte(iValue) {
  var iKanaBuff = "｡｢｣､･ｦｧｨｩｪｫｬｭｮｯｰｱｲｳｴｵｶｷｸｹｺｻｼｽｾｿﾀﾁﾂﾃﾄﾅﾆﾇﾈﾉﾊﾋﾌﾍﾎﾏﾐﾑﾒﾓﾔﾕﾖﾗﾘﾙﾚﾛﾜﾝﾞﾟ";
  var n;
  var c;
  var cmnCnt = 0;
  for (n = 0;
    n < iValue.length;
    n++) {
    c = iValue.substring(n, n + 1);
    if (c >= " " && c <= "~") {
      cmnCnt++;
    }
    else if (c == "\b" || c == "\t" || c == "\n" || c == "\f" || c == "\r") {
      cmnCnt++;
    }
    else if (iKanaBuff.indexOf(c) >= 0) {
      cmnCnt++;
    }
    else {
      cmnCnt += 2;
    }
  }
  return cmnCnt;
}
function checkAdvItem(iCtrl, iChkGroup) {
  var cmnOrgVal;
  var cmnUnFmtVal;
  var cmnUnFmtVal2;
  var cmnChkVal;
  var cmnCIdx;
  var cmnAttIdx;
  var cmnValLen;
  var iSepDateMNoTemp = -1;
  if (iCtrl.name == null) {
    return true;
  }
  cmnCIdx = getAdvControlIdxFromName(iCtrl.name);
  if (cmnCIdx < 0) {
    return true;
  }
  if (iChkGroup != null) {
    if (ADVIT_LEVEL[cmnCIdx] != iChkGroup.toUpperCase()) {
      return true;
    }
  }
  if (AdvGB_SepDateIDX >= 0) {
    var subName;
    if (iCtrl.name.match(AdvGB_M_NAME_MEDFIX) != null) {
      subName = iCtrl.name.search(AdvGB_M_NAME_MEDFIX) + iCtrl.name.match(AdvGB_M_NAME_MEDFIX)[0].length;
      subName = iCtrl.name.substring(subName, iCtrl.name.length - 4);
    }
    else {
      subName = iCtrl.name.substring(0, iCtrl.name.length - 4);
    }
    if (iCtrl.name.toLowerCase().match(AdvGB_M_NAME_MEDFIX) != null) {
      iSepDateMNoTemp = getAdvItemMNofromCtrl(iCtrl);
    }
    else {
      iSepDateMNoTemp = -1;
    }
    if (subName.toLowerCase() != AdvGB_SepDateItN.toLowerCase() || ((subName.toLowerCase() == AdvGB_SepDateItN.toLowerCase()) && (AdvGB_SepDateMNo != iSepDateMNoTemp))) {
      if (!EndDX_std()) {
        if (AdvGB_SepDateMNo == -1) {
          var cmnCtrl = null;
          var count = 1;
          while (count < 4) {
            cmnCtrl = getAdvControlFromIdx(AdvGB_SepDateIDX + count);
            if (cmnCtrl != null) {
              break;
            }
            ++count;
          }
        }
        else {
          var cmnCtrl = null;
          var count = 1;
          while (count < 4) {
            cmnCtrl = getAdvControlFromIdx(AdvGB_SepDateIDX + count, AdvGB_SepDateMNo);
            if (cmnCtrl != null) {
              break;
            }
            ++count;
          }
        }
        if (cmnCtrl != null) {
          cmnCtrl.focus();
        }
        return false;
      }
      AdvGB_SepDateItN = "";
      AdvGB_SepDateIDX = -1;
      AdvGB_SepDateMNo = -1;
    }
  }
  switch (ADVIT_TYPE[cmnCIdx]) {
    case "TXT": case "PWD": case "TX2": case "TXR": if (ADVIT_TYPE[cmnCIdx] == "TXR" && !AdvGB_TXR_CHK) {
      break;
    }
      cmnOrgVal = iCtrl.value;
      if (AdvGB_TrimMode) {
        cmnOrgVal = trimStd(cmnOrgVal);
      }
      switch (ADVIT_FORMAT[cmnCIdx]) {
        case "00": cmnUnFmtVal = cmnOrgVal;
          break;
        default: if (ADVIT_ATTRIBUTE[cmnCIdx] == "D") {
          cmnUnFmtVal = cmnOrgVal;
        }
        else {
          cmnUnFmtVal = getAdvUnFormatStr(iCtrl.name, cmnOrgVal);
        }
          break;
      }cmnUnFmtVal2 = getStdSignRemove(cmnUnFmtVal);
      switch (ADVIT_ATTRIBUTE[cmnCIdx].substr(0, 1)) {
        case "D": cmnChkVal = cmnUnFmtVal;
          break;
        case "N": cmnChkVal = getStdDecimalPointRemove(cmnUnFmtVal2);
          break;
        default: cmnChkVal = cmnUnFmtVal;
          break;
      }if (cmnChkVal == "") {
        if (ADVIT_REQUIREDFLG[cmnCIdx] == 1) {
          if (ADVIT_REQUIRED[cmnCIdx] > 1 && ADVIT_ATTRIBUTE[cmnCIdx] != "D" && ADVIT_ATTRIBUTE[cmnCIdx] != "DX") {
            alert(getAdvAssembleMsg(ADVMS_STR[ADVMS_ID_S104], cmnCIdx, ""));
          }
          else {
            alert(getAdvAssembleMsg(ADVMS_STR[ADVMS_ID_S103], cmnCIdx, ""));
          }
          iCtrl.focus();
          return false;
        }
        if (cmnUnFmtVal == "") {
          return true;
        }
      }
      if (ADVIT_ATTRIBUTE[cmnCIdx] == "DX") {
        AdvGB_SepDateItN = ADVIT_ID[cmnCIdx].substr(0, ADVIT_ID[cmnCIdx].length - 4).toLowerCase();
        AdvGB_SepDateIDX = getAdvControlIdxFromName(AdvGB_SepDateItN);
        if (iCtrl.name.toLowerCase().match(AdvGB_M_NAME_MEDFIX) != null) {
          AdvGB_SepDateMNo = getAdvItemMNofromCtrl(iCtrl);
        }
        else {
          AdvGB_SepDateMNo = -1;
        }
        switch (iCtrl.name.substr(iCtrl.name.length - 4, 4).toUpperCase()) {
          case "_DX1": if (ADVIT_FORMAT[cmnCIdx] == "56" || ADVIT_FORMAT[cmnCIdx] == "57") {
            AdvGB_SepD_H = cmnOrgVal;
          }
          else {
            AdvGB_SepD_Y = cmnOrgVal;
          }
            break;
          case "_DX2": if (ADVIT_FORMAT[cmnCIdx] == "56" || ADVIT_FORMAT[cmnCIdx] == "57") {
            AdvGB_SepD_N = cmnOrgVal;
          }
          else {
            AdvGB_SepD_M = cmnOrgVal;
          }
            break;
          case "_DX3": if (ADVIT_FORMAT[cmnCIdx] == "56" || ADVIT_FORMAT[cmnCIdx] == "57") {
            AdvGB_SepD_S = cmnOrgVal;
          }
          else {
            AdvGB_SepD_D = cmnOrgVal;
          }
            break;
        }return true;
      }
      else {
        AdvGB_SepDateItN = "";
        AdvGB_SepDateIDX = -1;
        AdvGB_SepDateMNo = -1;
      }
      if (ADVIT_ATTRIBUTE[cmnCIdx] == "D") {
        switch (ADVIT_FORMAT[cmnCIdx]) {
          case "52": case "53": case "54": case "55": case "56": case "57": case "59": case "60": case "61": case "62": case "63": case "64": case "65": case "66": if (getAdvDateFormat(cmnOrgVal, ADVIT_FORMAT[cmnCIdx]) == false) {
            alert(getAdvAssembleMsg(ADVMS_STR[ADVMS_ID_S108], cmnCIdx, ""));
            iCtrl.focus();
            return false;
          }
            return true;
            break;
          default: var validationMethod = window["quiqCustomDateValidation" + ADVIT_FORMAT[cmnCIdx]];
            if (validationMethod == undefined) {
              alert("Not found the unformat method \"quiqCustomDateValidation" + ADVIT_FORMAT[cmnCIdx] + "\".");
            }
            else {
              if (validationMethod(cmnOrgVal, ADVIT_ID[cmnCIdx]) == false) {
                alert(getAdvAssembleMsg(ADVMS_STR[ADVMS_ID_S108], cmnCIdx, ""));
                iCtrl.focus();
                return false;
              }
              else {
                return true;
              }
            }
            break;
        }
      }
      else {
        cmnChkVal = cmnUnFmtVal;
        switch (ADVIT_ATTRIBUTE[cmnCIdx].substr(0, 1)) {
          case "N": case "S": cmnAttIdx = eval("ADVAT_ID_" + ADVIT_ATTRIBUTE[cmnCIdx].toUpperCase());
            if (ADVAT_REGSTR[cmnAttIdx].length > 0) {
              if (cmnChkVal.match(ADVAT_REGSTR[cmnAttIdx]) == null) {
                if (ADVAT_BIKO[cmnAttIdx].length == 0) {
                  alert(getAdvAssembleMsg(ADVMS_STR[ADVMS_ID_S105], cmnCIdx, ""));
                }
                else {
                  alert(getAdvAssembleMsg(ADVMS_STR[ADVMS_ID_S106], cmnCIdx, ""));
                }
                iCtrl.focus();
                return false;
              }
            }
            if (ADVAT_CHKSTR[cmnAttIdx].length > 0) {
              if (!checkAdvFormAndStr(cmnChkVal, cmnAttIdx)) {
                if (ADVAT_BIKO[cmnAttIdx].length == 0) {
                  alert(getAdvAssembleMsg(ADVMS_STR[ADVMS_ID_S105], cmnCIdx, ""));
                }
                else {
                  alert(getAdvAssembleMsg(ADVMS_STR[ADVMS_ID_S106], cmnCIdx, ""));
                }
                iCtrl.focus();
                return false;
              }
            }
            break;
        }
      }
      if (ADVIT_LENGTH[cmnCIdx] > 0) {
        cmnAttByteChk = 0;
        cmnValLen = 0;
        switch (ADVIT_ATTRIBUTE[cmnCIdx].substr(0, 1)) {
          case "N": if (ADVIT_DECIMAL[cmnCIdx] > 0) {
            if (cmnUnFmtVal2.indexOf(AdvGB_DecimalStr) >= 0) {
              if ((ADVIT_LENGTH[cmnCIdx] - ADVIT_DECIMAL[cmnCIdx]) < cmnUnFmtVal2.substring(0, cmnUnFmtVal2.indexOf(AdvGB_DecimalStr)).length) {
                alert(getAdvAssembleMsg(ADVMS_STR[ADVMS_ID_S110], cmnCIdx, ""));
                iCtrl.focus();
                return false;
              }
              if (ADVIT_DECIMAL[cmnCIdx] < cmnUnFmtVal2.substring(cmnUnFmtVal2.indexOf(AdvGB_DecimalStr) + 1, cmnUnFmtVal2.length).length) {
                alert(getAdvAssembleMsg(ADVMS_STR[ADVMS_ID_S102], cmnCIdx, ""));
                iCtrl.focus();
                return false;
              }
            }
            else {
              if ((ADVIT_LENGTH[cmnCIdx] - ADVIT_DECIMAL[cmnCIdx]) < cmnUnFmtVal2.length) {
                alert(getAdvAssembleMsg(ADVMS_STR[ADVMS_ID_S110], cmnCIdx, ""));
                iCtrl.focus();
                return false;
              }
            }
          }
          else {
            if (cmnUnFmtVal2.indexOf(AdvGB_DecimalStr) >= 0) {
              alert(getAdvAssembleMsg(ADVMS_STR[ADVMS_ID_S102], cmnCIdx, ""));
              iCtrl.focus();
              return false;
            }
            if (ADVIT_LENGTH[cmnCIdx] < cmnUnFmtVal2.length) {
              alert(getAdvAssembleMsg(ADVMS_STR[ADVMS_ID_S101], cmnCIdx, ""));
              iCtrl.focus();
              return false;
            }
          }
            if (ADVIT_REQUIRED[cmnCIdx] > getStdDecimalPointRemove(cmnUnFmtVal2).length && ADVIT_REQUIRED[cmnCIdx] > 0) {
              alert(getAdvAssembleMsg(ADVMS_STR[ADVMS_ID_S111], cmnCIdx, ""));
              iCtrl.focus();
              return false;
            }
            break;
          case "S": if (ADVIT_DECIMAL[cmnCIdx] < 1) {
            cmnAttIdx = eval("ADVAT_ID_" + ADVIT_ATTRIBUTE[cmnCIdx].toUpperCase());
            cmnAttByteChk = ADVAT_BYTEFLG[cmnAttIdx];
          }
            if (cmnAttByteChk == 0) {
              cmnValLen = cmnUnFmtVal.length;
            }
            else {
              cmnValLen = getAdvByte(cmnUnFmtVal);
            }
            if (ADVIT_LENGTH[cmnCIdx] < cmnValLen) {
              alert(getAdvAssembleMsg(ADVMS_STR[ADVMS_ID_S101], cmnCIdx, ""));
              iCtrl.focus();
              return false;
            }
            if (ADVIT_REQUIRED[cmnCIdx] > cmnValLen && ADVIT_REQUIRED[cmnCIdx] > 0) {
              alert(getAdvAssembleMsg(ADVMS_STR[ADVMS_ID_S111], cmnCIdx, ""));
              iCtrl.focus();
              return false;
            }
            break;
        }
      }
      break;
    case "RDO": if (ADVIT_REQUIREDFLG[cmnCIdx] == 1) {
      for (var i = 0;
        i < AdvGB_RdoIdArray.length;
        i++) {
        if (AdvGB_RdoIdArray[i] == null) {
          AdvGB_RdoIdArray[i] = ADVIT_ID[cmnCIdx];
          AdvGB_RdoMNoArray[i] = getAdvItemMNofromCtrl(iCtrl);
          AdvGB_RdoCtrlArray[i] = iCtrl;
          AdvGB_RdoCIdxArray[i] = cmnCIdx;
          AdvGB_RdoCheckedArray[i] = false;
          break;
        }
        if (AdvGB_RdoIdArray[i] == ADVIT_ID[cmnCIdx]) {
          break;
        }
      }
      if (AdvGB_RdoMNoArray[i] == getAdvItemMNofromCtrl(iCtrl)) {
        if (AdvGB_RdoCheckedArray[i] == false && iCtrl.checked) {
          AdvGB_RdoCheckedArray[i] = true;
        }
      }
      else {
        if (AdvGB_RdoCheckedArray[i] == true) {
          AdvGB_RdoCheckedArray[i] = false;
          AdvGB_RdoMNoArray[i] = getAdvItemMNofromCtrl(iCtrl);
          AdvGB_RdoCtrlArray[i] = iCtrl;
          if (iCtrl.checked) {
            AdvGB_RdoCheckedArray[i] = true;
          }
        }
      }
    }
      break;
    default: AdvGB_SepD_Y = "";
      AdvGB_SepD_M = "";
      AdvGB_SepD_D = "";
      AdvGB_SepD_H = "";
      AdvGB_SepD_N = "";
      AdvGB_SepD_S = "";
      break;
  }return true;
}
function EndDX_std() {
  var cmnReturn = true;
  var cmnMsgId = -1;
  switch (checkAdvFormDate(AdvGB_SepDateIDX, AdvGB_SepD_Y, AdvGB_SepD_M, AdvGB_SepD_D, AdvGB_SepD_H, AdvGB_SepD_N, AdvGB_SepD_S)) {
    case 1: cmnMsgId = ADVMS_ID_S103;
      break;
    case 2: cmnMsgId = ADVMS_ID_S108;
      break;
  }AdvGB_SepD_Y = "";
  AdvGB_SepD_M = "";
  AdvGB_SepD_D = "";
  AdvGB_SepD_H = "";
  AdvGB_SepD_N = "";
  AdvGB_SepD_S = "";
  if (cmnMsgId >= 0) {
    alert(getAdvAssembleMsg(ADVMS_STR[cmnMsgId], AdvGB_SepDateIDX, ""));
    return false;
  }
  return true;
}
function checkAdvFormDate(iIDX, iDate_Y, iDate_M, iDate_D, iDate_H, iDate_N, iDate_S) {
  if (iDate_Y == "" && iDate_M == "" && iDate_D == "" && iDate_H == "" && iDate_N == "" && iDate_S == "") {
    if (ADVIT_REQUIREDFLG[iIDX] == 1) {
      return 1;
    }
    else {
      return 0;
    }
  }
  switch (ADVIT_FORMAT[iIDX]) {
    case "52": case "53": case "54": case "55": case "59": case "60": case "61": case "62": case "63": case "64": case "65": case "66": switch (ADVIT_FORMAT[iIDX]) {
      case "52": case "60": case "65": iDate_M = (iDate_M.length == 1) ? "0" + iDate_M : iDate_M;
        iDate_D = (iDate_D.length == 1) ? "0" + iDate_D : iDate_D;
        break;
      case "55": case "64": iDate_Y = getStdFullYear(iDate_Y);
        iDate_M = (iDate_M.length == 1) ? "0" + iDate_M : iDate_M;
        iDate_D = "01";
        break;
      case "53": case "63": case "66": iDate_Y = getStdFullYear(iDate_Y);
        iDate_M = (iDate_M.length == 1) ? "0" + iDate_M : iDate_M;
        iDate_D = (iDate_D.length == 1) ? "0" + iDate_D : iDate_D;
        break;
      case "54": case "61": iDate_M = (iDate_M.length == 1) ? "0" + iDate_M : iDate_M;
        iDate_D = "01";
        break;
      case "59": case "62": iDate_Y = "2000";
        iDate_M = (iDate_M.length == 1) ? "0" + iDate_M : iDate_M;
        iDate_D = (iDate_D.length == 1) ? "0" + iDate_D : iDate_D;
        break;
    }if (!checkAdvDate(iDate_Y, iDate_M, iDate_D)) {
      return 2;
    }
      break;
    case "56": case "57": case "58": iDate_H = (iDate_H.length == 1) ? "0" + iDate_H : iDate_H;
      iDate_N = (iDate_N.length == 1) ? "0" + iDate_N : iDate_N;
      iDate_S = (iDate_S.length == 1) ? "0" + iDate_S : iDate_S;
      if (ADVIT_FORMAT[iIDX] != 56) {
        iDate_S = "00";
      }
      if (iDate_H.match(/^[0-9]{2,2}$/) == null) {
        return 2;
      }
      if (iDate_N.match(/^[0-9]{2,2}$/) == null) {
        return 2;
      }
      if (iDate_S.match(/^[0-9]{2,2}$/) == null) {
        return 2;
      }
      switch (ADVIT_FORMAT[iIDX]) {
        case "56": case "57": if (parseFloat(iDate_H) > 23 || parseFloat(iDate_N) > 59 || parseFloat(iDate_S) > 59) {
          return 2;
        }
          break;
        case "58": if (parseFloat(iDate_H) > 99 || parseFloat(iDate_N) > 59 || parseFloat(iDate_S) > 59) {
          return 2;
        }
          break;
      }
  }return -1;
}
function checkAdvFormAndStr(iValue, iAttIdx) {
  if (ADVAT_CHKFLG[iAttIdx] == 1) {
    for (var i = 0;
      i < iValue.length;
      i++) {
      if (ADVAT_CHKSTR[iAttIdx].indexOf(iValue.charAt(i)) == -1) {
        return false;
      }
    }
  }
  else {
    for (var i = 0;
      i < ADVAT_CHKSTR[iAttIdx].length;
      i++) {
      if (iValue.indexOf(ADVAT_CHKSTR[iAttIdx].charAt(i)) >= 0) {
        return false;
      }
    }
  }
  return true;
}
function getAdvFormat(iControl) {
  return getAdvFormatStr(iControl.name, iControl.value, 3);
}
function getAdvFormatStr(iItemId, iStr, iCutMode) {
  var cmnCtrlIdx = getAdvControlIdxFromName(iItemId);
  var cmnYear = "";
  var cmnMonth = "";
  var cmnDay = "";
  var cmnHour = "";
  var cmnMin = "";
  var cmnSec = "";
  var advVal = "";
  var cmnDecIdx = -1;
  var cmnSybS = "";
  var cmnIntS = "";
  var cmnDecS = "";
  var cmnWStr = new String(iStr);
  if (cmnWStr.length == 0) {
    return "";
  }
  switch (ADVIT_FORMAT[cmnCtrlIdx]) {
    case "00": return cmnWStr + "";
    case "10": if (cmnWStr.match("^[\\+\\-]?([0-9,\\\\$]+|[0-9,\\\\$]*[\\.]{1}[0-9,\\\\$]*)$") == null) {
      return 0;
    }
      advVal = getAdvUnFormatStr(iItemId, cmnWStr);
      if (isNaN(advVal)) {
        return 0;
      }
      advVal = getAdvDecimalCut(advVal, ADVIT_DECIMAL[cmnCtrlIdx], iCutMode);
      cmnDecIdx = advVal.indexOf(".");
      if (cmnDecIdx >= 0) {
        cmnDecS = advVal.substr(cmnDecIdx, advVal.length - cmnDecIdx);
        cmnIntS = advVal.substr(0, cmnDecIdx);
      }
      else {
        cmnIntS = advVal;
      }
      if (cmnIntS.substr(0, 1) == "+" || cmnIntS.substr(0, 1) == "-") {
        cmnSybS = cmnIntS.substr(0, 1);
        cmnIntS = cmnIntS.substr(1, cmnIntS.length - 1);
      }
      while (cmnIntS.length < (ADVIT_LENGTH[cmnCtrlIdx] - ADVIT_DECIMAL[cmnCtrlIdx])) {
        cmnIntS = "0" + cmnIntS;
      }
      return cmnSybS + cmnIntS + cmnDecS + "";
    case "11": case "14": case "18": case "21": case "12": case "15": case "19": case "22": if (cmnWStr.match("^[\\+|\\-]?([0-9,\\\\$]+|[0-9,\\\\$]*[\\.]{1}[0-9,\\\\$]*)$") == null) {
      return 0;
    }
      advVal = getAdvUnFormatStr(iItemId, cmnWStr);
      if (isNaN(advVal)) {
        return 0;
      }
      if (ADVIT_FORMAT[cmnCtrlIdx] == "15" || ADVIT_FORMAT[cmnCtrlIdx] == "21" || ADVIT_FORMAT[cmnCtrlIdx] == "22") {
        if (advVal == "") {
          return "";
        }
      }
      advVal = getAdvDecimalCut(advVal, ADVIT_DECIMAL[cmnCtrlIdx], iCutMode);
      if (advVal == "0" && (ADVIT_FORMAT[cmnCtrlIdx] == "14" || ADVIT_FORMAT[cmnCtrlIdx] == "15" || ADVIT_FORMAT[cmnCtrlIdx] == "21" || ADVIT_FORMAT[cmnCtrlIdx] == "22")) {
        return "";
      }
      switch (ADVIT_FORMAT[cmnCtrlIdx]) {
        case "11": case "14": return advVal + "";
        case "12": case "15": return getAdvCommaFormat(advVal) + "";
        case "18": case "21": return getAdvDecimalZero(advVal, ADVIT_DECIMAL[cmnCtrlIdx]) + "";
        case "19": case "22": return getAdvDecimalZero(getAdvCommaFormat(advVal), ADVIT_DECIMAL[cmnCtrlIdx]) + "";
      }case "31": case "32": case "34": case "35": if (cmnWStr.match("^[\\+|\\-]?([0-9,\\\\$]+|[0-9,\\\\$]*[\\.]{1}[0-9,\\\\$]*)$") == null) {
        return 0;
      }
      advVal = getAdvUnFormatStr(iItemId, cmnWStr);
      if (isNaN(advVal)) {
        return 0;
      }
      if (ADVIT_FORMAT[cmnCtrlIdx] == "34" || ADVIT_FORMAT[cmnCtrlIdx] == "35") {
        if (advVal == "") {
          return "";
        }
      }
      advVal = getAdvDecimalCut(advVal, ADVIT_DECIMAL[cmnCtrlIdx], iCutMode);
      if (advVal == "0") {
        if (ADVIT_FORMAT[cmnCtrlIdx] == "34" || ADVIT_FORMAT[cmnCtrlIdx] == "35") {
          return "";
        }
        else {
          return (ADVIT_FORMAT[cmnCtrlIdx] == "31") ? "\\0" : "$0";
        }
      }
      if (ADVIT_FORMAT[cmnCtrlIdx] == "31" || ADVIT_FORMAT[cmnCtrlIdx] == "34") {
        return getAdvYenFormat(getAdvCommaFormat(advVal), 1) + "";
      }
      else {
        return getAdvYenFormat(getAdvCommaFormat(advVal), 2) + "";
      }
    case "37": case "38": if (cmnWStr.match("^[\\+|\\-]?([0-9,\\\\$]+|[0-9,\\\\$]*[\\.]{1}[0-9,\\\\$]*)$") == null) {
      return 0;
    }
      advVal = getAdvUnFormatStr(iItemId, cmnWStr);
      if (isNaN(advVal)) {
        return 0;
      }
      advVal = getAdvDecimalCut(advVal, ADVIT_DECIMAL[cmnCtrlIdx], iCutMode);
      if (advVal == "0") {
        return ((ADVIT_FORMAT[cmnCtrlIdx] == "37") ? "\\" : "$") + getAdvDecimalZero("0", ADVIT_DECIMAL[cmnCtrlIdx]) + "";
      }
      if (ADVIT_FORMAT[cmnCtrlIdx] == "37") {
        return getAdvYenFormat(getAdvDecimalZero(getAdvCommaFormat(advVal), ADVIT_DECIMAL[cmnCtrlIdx]), 1) + "";
      }
      else {
        return getAdvYenFormat(getAdvDecimalZero(getAdvCommaFormat(advVal), ADVIT_DECIMAL[cmnCtrlIdx]), 2) + "";
      }
    case "52": case "53": case "54": case "55": case "56": case "57": case "58": case "59": case "60": case "61": case "62": case "63": case "64": case "65": case "66": return getAdvDateFormat(cmnWStr, ADVIT_FORMAT[cmnCtrlIdx]) + "";
    default: var retval = "";
      var formatMethod = window["quiqCustomFormat" + ADVIT_FORMAT[cmnCtrlIdx]];
      if (formatMethod == undefined) {
        alert("Not found the format method \"quiqCustomFormat" + ADVIT_FORMAT[cmnCtrlIdx] + "\".");
        retval = 0;
      }
      else {
        retval = formatMethod(iStr, iItemId);
        retval = "" + retval;
      }
      return retval;
  }return 0;
}
function getAdvCommaFormat(iStr) {
  var cmnSybS = "";
  var cmnIntS = "";
  var cmnDecS = "";
  var cmnDecIdx = -1;
  var cmnFmtS = "";
  cmnDecIdx = iStr.indexOf(".");
  if (iStr.match("^[\\.]{1}") != null) {
    cmnDecS = iStr;
    cmnIntS = "0";
  }
  else if (iStr.match("^[\\+|\\-]?[\\.]{1}") != null) {
    cmnDecS = iStr.substr(1, iStr.length - 1);
    cmnIntS = iStr.substr(0, 1) + "0";
  }
  else if (cmnDecIdx >= 1) {
    cmnDecS = iStr.substr(cmnDecIdx, iStr.length - cmnDecIdx);
    cmnIntS = iStr.substr(0, cmnDecIdx);
  }
  else {
    cmnIntS = iStr;
  }
  if (cmnIntS.substr(0, 1) == "+" || cmnIntS.substr(0, 1) == "-") {
    cmnSybS = cmnIntS.substr(0, 1);
    cmnIntS = cmnIntS.substr(1, cmnIntS.length - 1);
  }
  if (cmnIntS.length > 3) {
    switch (cmnIntS.length % 3) {
      case 0: cmnFmtS = cmnFmtS + cmnIntS.substr(0, 3);
        cmnIntS = cmnIntS.substr(3, cmnIntS.length - 3);
        break;
      case 1: cmnFmtS = cmnFmtS + cmnIntS.substr(0, 1);
        cmnIntS = cmnIntS.substr(1, cmnIntS.length - 1);
        break;
      case 2: cmnFmtS = cmnFmtS + cmnIntS.substr(0, 2);
        cmnIntS = cmnIntS.substr(2, cmnIntS.length - 2);
        break;
    }
    while (cmnIntS.length > 3) {
      cmnFmtS = cmnFmtS + "," + cmnIntS.substr(0, 3);
      cmnIntS = cmnIntS.substr(3, cmnIntS.length - 3);
    }
    return cmnSybS + cmnFmtS + "," + cmnIntS + cmnDecS;
  }
  else {
    return cmnSybS + cmnIntS + cmnDecS;
  }
}
function getAdvYenFormat(iStr, iMode) {
  var cmnYenS = "";
  switch (iMode) {
    case 1: cmnYenS = "\\";
      break;
    case 2: cmnYenS = "$";
      break;
  }if (iStr.substr(0, 1) == "+" || iStr.substr(0, 1) == "-") {
    return iStr.substr(0, 1) + cmnYenS + iStr.substr(1, iStr.length - 1);
  }
  else {
    return cmnYenS + iStr;
  }
}
function getAdvDecimalZero(iStr, iDeciNum) {
  var cmnIntS = "";
  var cmnDecS = "";
  var cmnDecIdx = -1;
  cmnDecIdx = iStr.indexOf(".");
  if (iStr.match("^[\\.]{1}") != null) {
    cmnDecS = iStr.substr(1, iStr.length - 1);
    cmnIntS = "0";
  }
  else if (iStr.match("^[\\+|\\-]{1}[\\.]{1}") != null) {
    cmnDecS = iStr.substr(cmnDecIdx + 1, iStr.length - cmnDecIdx - 1);
    cmnIntS = iStr.substr(0, 1) + "0";
  }
  else if (cmnDecIdx >= 1) {
    cmnDecS = iStr.substr(cmnDecIdx + 1, iStr.length - cmnDecIdx - 1);
    cmnIntS = iStr.substr(0, cmnDecIdx);
  }
  else {
    cmnIntS = iStr;
  }
  while (cmnDecS.length < iDeciNum) {
    cmnDecS = cmnDecS + "0";
  }
  if (cmnDecS.length == 0) {
    return cmnIntS;
  }
  else {
    if (cmnIntS == "") {
      cmnIntS = "0";
    }
    return cmnIntS + "." + cmnDecS;
  }
}
function getAdvDecimalCut(iStr, iDeciNum, iCutMode) {
  var cmnIntS = "";
  var cmnDecS = "";
  var cmnDecIdx = -1;
  var cmn4s5sS = "";
  if (iCutMode == 3) {
    return iStr;
  }
  cmnDecIdx = iStr.indexOf(".");
  if (iStr.match("^[\\.]{1}") != null) {
    cmnDecS = iStr.substr(1, iStr.length - 1);
    cmnIntS = "0";
  }
  else if (iStr.match("^[\\+|\\-]{1}[\\.]{1}") != null) {
    cmnDecS = iStr.substr(cmnDecIdx + 1, iStr.length - cmnDecIdx - 1);
    cmnIntS = iStr.substr(0, 1) + "0";
  }
  else if (cmnDecIdx >= 1) {
    cmnDecS = iStr.substr(cmnDecIdx + 1, iStr.length - cmnDecIdx - 1);
    cmnIntS = iStr.substr(0, cmnDecIdx);
  }
  else {
    return iStr;
  }
  if (cmnDecS.length <= iDeciNum) {
    return iStr;
  }
  cmn4s5sS = cmnDecS.substr(iDeciNum, 1);
  if ((cmn4s5sS < 5) && (iCutMode == 0 || iCutMode == null) || iCutMode == 1) {
    cmnDecS = cmnDecS.substr(0, iDeciNum);
  }
  else {
    if (iDeciNum == 0) {
      cmnIntS = cmnIntS - 1 + 2;
      cmnDecS = "";
    }
    else {
      cmnDecS = cmnDecS.substr(0, iDeciNum);
      cmnDecS = (cmnDecS - 1 + 2).toString();
      while (cmnDecS.length < iDeciNum) {
        cmnDecS = "0" + cmnDecS;
      }
      if (cmnDecS.length > iDeciNum) {
        cmnDecS = cmnDecS.substr(1, iDeciNum);
        cmnIntS = cmnIntS - 1 + 2;
      }
    }
  }
  while (cmnDecS != "") {
    if (cmnDecS.lastIndexOf("0") == cmnDecS.length - 1) {
      cmnDecS = cmnDecS.substr(0, cmnDecS.length - 1);
    }
    else {
      break;
    }
  }
  if (cmnDecS.length == 0 || cmnDecS == 0) {
    return cmnIntS.toString();
  }
  else {
    return cmnIntS + "." + cmnDecS;
  }
}
function getAdvUnFormat(iControl) { return getAdvUnFormatStr(iControl.name, iControl.value) }
function getAdvUnFormatStr(iItemID, iStr) {
  var advVal = new String(iStr);
  var i_FmtID = ADVIT_FORMAT[getAdvControlIdxFromName(iItemID)];
  switch (i_FmtID) {
    case "52": case "53": case "54": case "55": case "59": case "60": case "61": case "62": case "63": case "64": case "65": case "66": advVal = replaceAdv(advVal, "/", "");
      return advVal + "";
    case "56": case "57": case "58": advVal = replaceAdv(advVal, ":", "");
      return advVal + "";
  }if (i_FmtID != "00" && i_FmtID != "10" && i_FmtID != "11" && i_FmtID != "12" && i_FmtID != "14" && i_FmtID != "15" && i_FmtID != "18" && i_FmtID != "19" && i_FmtID != "21" && i_FmtID != "22" && i_FmtID != "31" && i_FmtID != "32" && i_FmtID != "34" && i_FmtID != "35" && i_FmtID != "37" && i_FmtID != "38") {
    var itemIdx = getAdvControlIdxFromName(iItemID);
    var unformatMethod = window["quiqCustomUnformat" + ADVIT_FORMAT[itemIdx]];
    if (unformatMethod == undefined) {
      alert("Not found the unformat method \"quiqCustomUnformat" + ADVIT_FORMAT[itemIdx] + "\".");
    }
    else {
      advVal = unformatMethod(advVal, iItemID);
    }
    return "" + advVal;
  }
  switch (i_FmtID) {
    case "31": case "34": case "37": if (!checkStdFirstYenSign(advVal)) {
      return iStr;
    }
      break;
    case "32": case "35": case "38": if (!checkStdFirstDollarSign(advVal)) {
      return iStr;
    }
      break;
  }switch (i_FmtID) {
    case "31": case "34": case "37": advVal = getStdFirstYenRemove(advVal);
      break;
  }switch (i_FmtID) {
    case "32": case "35": case "38": advVal = getStdFirstDollarRemove(advVal);
      break;
  }switch (i_FmtID) {
    case "12": case "15": case "19": case "22": case "31": case "32": case "34": case "35": case "37": case "38": advVal = getStdCommaRemove(advVal);
      break;
  }switch (i_FmtID) {
    case "10": case "11": case "12": case "14": case "15": case "18": case "19": case "21": case "22": case "31": case "32": case "34": case "35": case "37": case "38": if (isNaN(advVal)) {
      return iStr;
    }
      if (advVal.match("[ 　\\t]") != null) {
        return iStr;
      }
      if (replaceAdv(advVal, " ", "").length == 0) {
        return advVal + "";
      }
      if (advVal.length != 0) {
        advVal = parseFloat(advVal).toString();
      }
      break;
  }switch (i_FmtID) {
    case "14": case "15": case "21": case "22": case "34": case "35": advVal = getStdZeroClear(advVal);
      break;
  }return advVal;
}
function checkStdFirstYenSign(iStrPara) {
  var iStr = new String(iStrPara);
  if (iStr.substr(0, 2) == "\\+") {
    return false;
  }
  if (iStr.substr(0, 2) == "\\-") {
    return false;
  }
  return true
}
function checkStdFirstDollarSign(iStrPara) {
  var iStr = new String(iStrPara);
  if (iStr.substr(0, 2) == "$+") {
    return false;
  }
  if (iStr.substr(0, 2) == "$-") {
    return false;
  }
  return true
}
function getStdFirstZeroRemove(iStrPara) {
  var iStr = new String(iStrPara);
  var i_FC;
  if (iStr == "") {
    return "";
  }
  i_FC = iStr.search(/[^0]/);
  if (i_FC == -1) {
    return "0";
  }
  if (iStr.substr(i_FC, 1) == ".") {
    i_FC = i_FC - 1;
  }
  return iStr.substr(i_FC);
}
function getStdFirstYenRemove(iStrPara) {
  var iStr = new String(iStrPara);
  iStr = getStdFirstFindStrRemove(iStr, "\\");
  return iStr;
}
function getStdFirstDollarRemove(iStrPara) {
  var iStr = new String(iStrPara);
  iStr = getStdFirstFindStrRemove(iStr, "$");
  return iStr;
}
function getStdCommaRemove(iStrPara) {
  var iStr = new String(iStrPara);
  var i_RetStr = iStr;
  var i_DecSBuf = "";
  var i_DecCnt = iStr.indexOf(".");
  if (i_DecCnt > -1) {
    i_RetStr = iStr.substring(0, i_DecCnt);
    i_DecSBuf = iStr.substr(i_DecCnt);
  }
  i_RetStr = replaceAdv(i_RetStr, ",", "");
  return i_RetStr + i_DecSBuf;
}
function getStdZeroClear(iStrPara) {
  var iStr = new String(iStrPara);
  if (iStr == "0") {
    return "";
  }
  if (iStr == "+0") {
    return "";
  }
  if (iStr == "-0") {
    return "";
  }
  return iStr;
}
function getStdSignRemove(iStrPara) {
  var iStr = new String(iStrPara);
  if (iStr.substr(0, 1) == "+") {
    return iStr.substr(1);
  }
  if (iStr.substr(0, 1) == "-") {
    return iStr.substr(1);
  }
  return iStr;
}
function getStdDecimalPointRemove(iStrPara) {
  var iStr = new String(iStrPara);
  iStr = getStdFirstFindStrRemove(iStr, AdvGB_DecimalStr);
  return iStr;
}
function getStdFirstFindStrRemove(iStrPara, iTarget) {
  var iStr = new String(iStrPara);
  var i_FC;
  i_FC = iStr.indexOf(iTarget);
  if (i_FC > -1) {
    iStr = iStr.substring(0, i_FC) + iStr.substr(i_FC + 1);
  }
  return iStr;
}
function getStdFullYear(iYear) {
  var iStr = new String(iYear);
  var iYearBuff = new String();
  if (iStr.length = 0) {
    return "2000";
  }
  if (iStr.length > 2) {
    return iStr;
  }
  iYearBuff = (iStr.length == 1) ? "0" + iStr : iStr;
  if (AdvGB_BORDER_YEAR > parseFloat(iYear)) {
    iStr = "20" + iYearBuff;
  }
  else {
    iStr = "19" + iYearBuff;
  }
  return iStr;
}
function getAdvDateFormat(iValue, iFormat) {
  var cmnSplit;
  switch (iFormat) {
    case "52": if (iValue.match(/^[0-9]{1,4}\/[0-9]{1,2}\/[0-9]{1,2}$/) != null) {
      cmnSplit = iValue.split("/");
      cmnYear = "0000" + cmnSplit[0];
      cmnYear = cmnYear.substr(cmnYear.length - 4);
      cmnMonth = (cmnSplit[1].length == 1) ? "0" + cmnSplit[1] : cmnSplit[1];
      cmnDay = (cmnSplit[2].length == 1) ? "0" + cmnSplit[2] : cmnSplit[2];
    }
    else if (iValue.match(/^[0-9]{8}$/) != null) {
      cmnYear = iValue.substr(0, 4);
      cmnMonth = iValue.substr(4, 2);
      cmnDay = iValue.substr(6, 2);
    }
    else {
      return 0;
    }
      if (!checkAdvDate(cmnYear, cmnMonth, cmnDay)) {
        return 0;
      }
      return cmnYear + "/" + cmnMonth + "/" + cmnDay;
    case "53": case "63": case "66": if (iValue.match(/^[0-9]{1,2}\/[0-9]{1,2}\/[0-9]{1,2}$/) != null) {
      cmnSplit = iValue.split("/");
      cmnYear = (cmnSplit[0].length == 1) ? "0" + cmnSplit[0] : cmnSplit[0];
      cmnMonth = (cmnSplit[1].length == 1) ? "0" + cmnSplit[1] : cmnSplit[1];
      cmnDay = (cmnSplit[2].length == 1) ? "0" + cmnSplit[2] : cmnSplit[2];
    }
    else if (iValue.match(/^[0-9]{6}$/) != null) {
      cmnYear = iValue.substr(0, 2);
      cmnMonth = iValue.substr(2, 2);
      cmnDay = iValue.substr(4, 2);
    }
    else {
      return 0;
    }
      if (iFormat == "53") {
        if (!checkAdvDate(getStdFullYear(cmnYear), cmnMonth, cmnDay)) {
          return 0;
        }
      }
      if (iFormat == "63") {
        if (!checkAdvDate(getStdFullYear(cmnDay), cmnMonth, cmnYear)) {
          return 0;
        }
      }
      if (iFormat == "66") {
        if (!checkAdvDate(getStdFullYear(cmnDay), cmnYear, cmnMonth)) {
          return 0;
        }
      }
      return cmnYear + "/" + cmnMonth + "/" + cmnDay;
    case "54": if (iValue.match(/^[0-9]{1,4}\/[0-9]{1,2}$/) != null) {
      cmnSplit = iValue.split("/");
      cmnYear = "0000" + cmnSplit[0];
      cmnYear = cmnYear.substr(cmnYear.length - 4);
      cmnMonth = (cmnSplit[1].length == 1) ? "0" + cmnSplit[1] : cmnSplit[1];
    }
    else if (iValue.match(/^[0-9]{6}$/) != null) {
      cmnYear = iValue.substr(0, 4);
      cmnMonth = iValue.substr(4, 2);
    }
    else {
      return 0;
    }
      if (!checkAdvDate(cmnYear, cmnMonth, "01")) {
        return 0;
      }
      return cmnYear + "/" + cmnMonth;
    case "55": case "64": if (iValue.match(/^[0-9]{1,2}\/[0-9]{1,2}$/) != null) {
      cmnSplit = iValue.split("/");
      cmnYear = (cmnSplit[0].length == 1) ? "0" + cmnSplit[0] : cmnSplit[0];
      cmnMonth = (cmnSplit[1].length == 1) ? "0" + cmnSplit[1] : cmnSplit[1];
    }
    else if (iValue.match(/^[0-9]{4}$/) != null) {
      cmnYear = iValue.substr(0, 2);
      cmnMonth = iValue.substr(2, 2);
    }
    else {
      return 0;
    }
      if (iFormat == "55") {
        if (!checkAdvDate(getStdFullYear(cmnYear), cmnMonth, "01")) {
          return 0;
        }
      }
      if (iFormat == "64") {
        if (!checkAdvDate(getStdFullYear(cmnMonth), cmnYear, "01")) {
          return 0;
        }
      }
      return cmnYear + "/" + cmnMonth;
    case "59": case "62": if (iValue.match(/^[0-9]{1,2}\/[0-9]{1,2}$/) != null) {
      cmnSplit = iValue.split("/");
      cmnMonth = (cmnSplit[0].length == 1) ? "0" + cmnSplit[0] : cmnSplit[0];
      cmnDay = (cmnSplit[1].length == 1) ? "0" + cmnSplit[1] : cmnSplit[1];
    }
    else if (iValue.match(/^[0-9]{4}$/) != null) {
      cmnMonth = iValue.substr(0, 2);
      cmnDay = iValue.substr(2, 2);
    }
    else {
      return 0;
    }
      if (iFormat == "59") {
        if (!checkAdvDate("2000", cmnMonth, cmnDay)) {
          return 0;
        }
      }
      if (iFormat == "62") {
        if (!checkAdvDate("2000", cmnDay, cmnMonth)) {
          return 0;
        }
      }
      return cmnMonth + "/" + cmnDay;
    case "60": if (iValue.match(/^[0-9]{1,2}\/[0-9]{1,2}\/[0-9]{1,4}$/) != null) {
      cmnSplit = iValue.split("/");
      cmnYear = "0000" + cmnSplit[2];
      cmnYear = cmnYear.substr(cmnYear.length - 4);
      cmnMonth = (cmnSplit[1].length == 1) ? "0" + cmnSplit[1] : cmnSplit[1];
      cmnDay = (cmnSplit[0].length == 1) ? "0" + cmnSplit[0] : cmnSplit[0];
    }
    else if (iValue.match(/^[0-9]{8}$/) != null) {
      cmnDay = iValue.substr(0, 2);
      cmnMonth = iValue.substr(2, 2);
      cmnYear = iValue.substr(4, 4);
    }
    else {
      return 0;
    }
      if (!checkAdvDate(cmnYear, cmnMonth, cmnDay)) {
        return 0;
      }
      return cmnDay + "/" + cmnMonth + "/" + cmnYear;
    case "61": if (iValue.match(/^[0-9]{1,2}\/[0-9]{1,4}$/) != null) {
      cmnSplit = iValue.split("/");
      cmnYear = "0000" + cmnSplit[1];
      cmnYear = cmnYear.substr(cmnYear.length - 4);
      cmnMonth = (cmnSplit[0].length == 1) ? "0" + cmnSplit[0] : cmnSplit[0];
    }
    else if (iValue.match(/^[0-9]{6}$/) != null) {
      cmnMonth = iValue.substr(0, 2);
      cmnYear = iValue.substr(2, 4);
    }
    else {
      return 0;
    }
      if (!checkAdvDate(cmnYear, cmnMonth, "01")) {
        return 0;
      }
      return cmnMonth + "/" + cmnYear;
    case "65": if (iValue.match(/^[0-9]{1,2}\/[0-9]{1,2}\/[0-9]{1,4}$/) != null) {
      cmnSplit = iValue.split("/");
      cmnYear = "0000" + cmnSplit[2];
      cmnYear = cmnYear.substr(cmnYear.length - 4);
      cmnMonth = (cmnSplit[0].length == 1) ? "0" + cmnSplit[0] : cmnSplit[0];
      cmnDay = (cmnSplit[1].length == 1) ? "0" + cmnSplit[1] : cmnSplit[1];
    }
    else if (iValue.match(/^[0-9]{8}$/) != null) {
      cmnMonth = iValue.substr(0, 2);
      cmnDay = iValue.substr(2, 2);
      cmnYear = iValue.substr(4, 4);
    }
    else {
      return 0;
    }
      if (!checkAdvDate(cmnYear, cmnMonth, cmnDay)) {
        return 0;
      }
      return cmnMonth + "/" + cmnDay + "/" + cmnYear;
    case "56": if (iValue.match(/^[0-9]{1,2}\:[0-9]{1,2}\:[0-9]{1,2}$/) != null) {
      cmnSplit = iValue.split(":");
      cmnHour = (cmnSplit[0].length == 1) ? "0" + cmnSplit[0] : cmnSplit[0];
      cmnMin = (cmnSplit[1].length == 1) ? "0" + cmnSplit[1] : cmnSplit[1];
      cmnSec = (cmnSplit[2].length == 1) ? "0" + cmnSplit[2] : cmnSplit[2];
    }
    else if (iValue.match(/^[0-9]{6}$/) != null) {
      cmnHour = iValue.substr(0, 2);
      cmnMin = iValue.substr(2, 2);
      cmnSec = iValue.substr(4, 2);
    }
    else {
      return 0;
    }
      if (parseFloat(cmnHour) < 24 && parseFloat(cmnMin) < 60 && parseFloat(cmnSec) < 60) {
        return cmnHour + ":" + cmnMin + ":" + cmnSec;
      }
      else {
        return 0;
      }
    case "57": case "58": if (iValue.match(/^[0-9]{1,2}\:[0-9]{1,2}$/) != null) {
      cmnSplit = iValue.split(":");
      cmnHour = (cmnSplit[0].length == 1) ? "0" + cmnSplit[0] : cmnSplit[0];
      cmnMin = (cmnSplit[1].length == 1) ? "0" + cmnSplit[1] : cmnSplit[1];
    }
    else if (iValue.match(/^[0-9]{4}$/) != null) {
      cmnHour = iValue.substr(0, 2);
      cmnMin = iValue.substr(2, 2);
    }
    else {
      return 0;
    }
      if (iFormat == "57") {
        if (parseFloat(cmnHour) < 24 && parseFloat(cmnMin) < 60) {
          return cmnHour + ":" + cmnMin;
        }
      }
      else {
        if (parseFloat(cmnHour) < 100 && parseFloat(cmnMin) < 60) {
          return cmnHour + ":" + cmnMin;
        }
      }
      return 0;
    default: return 0;
  }
}
function checkAdvDate(iYear, iMonth, iDay) {
  var iYearBuff;
  var iMonthBuff;
  var iDayBuff;
  var i_maxDayOfMonthBuff = Array(31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31);
  if (iYear.match(/^[0-9]{1,4}$/) == null) {
    return false;
  }
  if (iMonth.match(/^[0-9]{1,2}$/) == null) {
    return false;
  }
  if (iDay.match(/^[0-9]{1,2}$/) == null) {
    return false;
  }
  iYearBuff = parseFloat(iYear);
  iMonthBuff = parseFloat(iMonth);
  iDayBuff = parseFloat(iDay);
  if (iYearBuff < 1) {
    return false;
  }
  if ((iMonthBuff < 1) || (iMonthBuff > 12)) {
    return false;
  }
  if ((iDayBuff < 1) || (iDayBuff > i_maxDayOfMonthBuff[iMonthBuff - 1])) {
    return false;
  }
  if (iMonthBuff != 2) {
    return true;
  }
  if (iDayBuff < 29) {
    return true;
  }
  if (((iYearBuff % 4) == 0) && ((iYearBuff % 100) != 0)) {
    return true;
  }
  if ((iYearBuff % 400) == 0) {
    return true;
  }
  return false;
}
function KeyPressEnter_std(iKeyCtrl, iKeyShift, iKeyAlt) {
  switch (AdvGB_ActiveControl.type.toLowerCase()) {
    case "text": case "password": case "select-one": case "select-multiple": case "checkbox": case "radio": case "file": if (iKeyCtrl) {
      return execAdvSubmit();
    }
    else {
      if (iKeyShift) {
        getAdvBeforeCtrl(AdvGB_ActiveControl).focus();
      }
      else {
        getAdvNextCtrl(AdvGB_ActiveControl).focus();
      }
    }
      return false;
    case "textarea": if (!iKeyCtrl) {
      return true;
    }
      getAdvNextCtrl(AdvGB_ActiveControl).focus();
      return false;
    case "button": case "submit": return true;
  }
}
function KeyPressSpace_std(iKeyCtrl, iKeyShift, iKeyAlt) {
  var iCanMove = false;
  switch (AdvGB_ActiveControl.type.toLowerCase()) {
    case "text": case "textarea": case "password": case "select-one": case "select-multiple": case "file": iCanMove = true;
      break;
    case "checkbox": case "radio": if (AdvGB_CHK_SpcMove) {
      iCanMove = true;
    }
  }if (iCanMove) {
    if (iKeyCtrl) {
      getAdvDownCtrl(AdvGB_ActiveControl).focus();
    }
    if (iKeyShift) {
      getAdvUpCtrl(AdvGB_ActiveControl).focus();
    }
    return false;
  }
  else {
    return true;
  }
}
function KeyFiltering_std(iKeyAscii, iCIdx) {
  var cmnInvalidKey = false;
  if (iKeyAscii == 8) {
    return true;
  }
  switch (ADVIT_ATTRIBUTE[iCIdx]) {
    case "D": if (iKeyAscii < 47 || iKeyAscii > 58) {
      cmnInvalidKey = true;
    }
      break;
    case "DX": if (iKeyAscii < 48 || iKeyAscii > 57) {
      cmnInvalidKey = true;
    }
      break;
  }switch (ADVIT_ATTRIBUTE[iCIdx].substr(0, 1)) {
    case "N": if (!((iKeyAscii >= 48 && iKeyAscii <= 57) || iKeyAscii == 36 || (iKeyAscii >= 43 && iKeyAscii <= 46) || iKeyAscii == 92)) {
      cmnInvalidKey = true;
    }
      break;
    case "S": if (iKeyAscii == 8) {
      cmnInvalidKey = true;
    }
      break;
  }if (cmnInvalidKey) {
    if (Std_NavIE) {
      event.keyCode = 0;
    }
    return false;
  }
  return true;
}/*** 正規表現特殊文字をエスケープした文字を取得します。* @private* @param {String} 
a_str 対象文字列* @return {String} 
エスケープ済みの文字列*/function escapeStdRegExpString(a_str) {
  var v_requiredEscapeString = { '^': '\\^', '$': '\\$', '.': '\\.', '*': '\\*', '+': '\\+', '?': '\\?', '=': '\\=', '!': '\\!', ':': '\\:', '|': '\\|', '\\': '\\\\', '/': '\\/', '(': '\\(', ')': '\\)', '[': '\\]', ']': '\\]', '{': '\\{', '}': '\\}' };
  return v_requiredEscapeString[a_str] ? v_requiredEscapeString[a_str] : a_str;
}/*** 入力値がstring型かどうか判断します。* @private* @param {Object} 
a_obj 入力値。* @return {Boolean} 
string型である場合true、それ以外の型の場合false。*/function isStdTypeOfString(a_obj) {
  return Object.prototype.toString.call(a_obj) === '[object String]';
}/*** 入力値がNumber型かどうか判断します。* @private* @param {Object} 
a_obj 入力値。* @return {Boolean} 
Number型である場合true、それ以外の型の場合false。*/function isStdTypeOfNumber(a_obj) {
  return Object.prototype.toString.call(a_obj) === '[object Number]';
}/*** 指定した引数が配列かどうか判断します。* @private* @param {Object} 
a_obj 対象オブジェクト。* @return {Boolean} 
配列であればtrue、それ以外はfalseを返却します。*/function isStdArray(a_obj) {
  return Object.prototype.toString.call(a_obj) === '[object Array]';
}/*** 対象文字列内のパラメータ(\\{0\\},\\{1\\},\\{2\\},\\{3\\},..)を指定した配列要素で置換します。* パラメータ{n}は配列のn+1番目の要素で置換されます。また、同じパラメータ名は対応する配列の要素で全て置換されます。* @private* @param {String} 
a_str 対象文字列。* @param {Array} 
a_params 置き換える文字列配列。* @return {String} 
置換済みの文字列。*/function replaceStdParams(a_str, a_params) {
  var v_i;
  if (isStdTypeOfString(a_str) && a_params && isStdArray(a_params) && a_params.length > 0) {
    for (v_i = 0;
      v_i < a_params.length;
      v_i += 1) {
      a_str = a_str.replace(new RegExp('\\\\{' + v_i + '\\\\}', 'g'), escapeStdRegExpString(a_params[v_i].toString()));
    }
    return a_str;
  }
  else {
    return a_str;
  }
}/*** 指定した文字が有効な数字文字列であるか判断します。有効桁のチェックは行いません。* @private* @param {String} 
a_str 対象文字列。* @return {Boolean} 
有効な場合、trueを返します。無効な場合、falseを返します。*/function isStdNumeric(a_str) {
  if (isStdTypeOfString(a_str)) {
    return a_str.match(new RegExp(replaceStdParams('^(?:[\\-])?(?:(?:[1-9]\\d*(?:\\{0\\}(?:\\d+)?)?)?|(?:0(?:\\{0\\}(?:\\d+)?)?)?)$', [escapeStdRegExpString(AdvGB_DecimalStr)]))) !== null;
  }
  else {
    return false;
  }
}/*** 指定した文字が有効な整数文字列であるか判断します。有効桁のチェックは行いません。* @private* @param {String} 
a_str 対象文字列。* @return {Boolean} 
整数の場合、trueを返します。それ以外の場合、falseを返します。*/function isStdInteger(a_str) {
  if (isStdTypeOfString(a_str)) {
    return a_str.match(/^[\-]?([1-9]\d*|0)?$/) !== null;
  }
  else {
    return false;
  }
}/*** 指定した文字が有効な数字文字列で項目の有効桁数であるか判断します。* @private* @param {String} 
a_str 対象文字列。* @param {String} 
a_entireDigits 全体桁数。* @param {String} 
a_decimalDigits 小数桁数。* @return {Boolean} 
有効な場合、trueを返します。無効な場合、falseを返します。*/function isStdNumericWithDigitsCheck(a_str, a_entireDigits, a_decimalDigits) {
  if (isStdTypeOfString(a_str) && isStdTypeOfNumber(a_entireDigits) && isStdTypeOfNumber(a_decimalDigits) && a_entireDigits > a_decimalDigits) {
    if (a_decimalDigits > 0) {
      return a_str.match(new RegExp(replaceStdParams('^[\\-]?(([1-9]\\d{0,\\{0\\}}(\\{1\\}\\d{0,\\{2\\}})?)|(0(\\{1\\}\\d{0,\\{2\\}})?))?$', [a_entireDigits - a_decimalDigits - 1, escapeStdRegExpString(AdvGB_DecimalStr), a_decimalDigits]))) !== null;
    }
    else {
      return a_str.match(new RegExp(replaceStdParams('^[\\-]?([1-9]\\d{0,\\{0\\}}|0)?$', [a_entireDigits - 1]))) !== null;
    }
  }
  else {
    return false;
  }
}/*** 指定した文字が有効な数字文字列で有効桁数内であるか判断します。* @private* @param {String} 
a_str 対象文字列。* @param {String} 
entireDigits 全体桁数。* @return {Boolean} 
有効な場合、trueを返します。無効な場合、falseを返します。*/function isStdDateWithDigitsCheck(a_str, a_digits) {
  if (isStdTypeOfString(a_str) && isStdTypeOfNumber(a_digits)) {
    return a_str.match(new RegExp(replaceStdParams('^(\\d{0,\\{0\\}})$', [a_digits]))) !== null;
  }
  else {
    return false;
  }
}/*** 日時かどうかチェックします。* @private* @param {String} 
日時。* @return {Boolean} 
日時の場合はtrueを返します。それ以外はfalseを返します。*/function isStdDateTime(a_str) {
  if (isStdTypeOfString(a_str)) {
    return a_str.match(/^\d*$/) !== null;
  }
  else {
    return false;
  }
}/*** 入力フィルタリングをします。* @private* @param {Object} 
a_event イベント情報。* @return {Boolean} 
true:処理を続行させる false:処理を停止させる*/function inputFilter_std(a_event) {
  var v_e, v_targetElement, v_itemInfo, v_attributeId, v_attributeCategoryId, v_code, v_newValue, v_ctrlIdx, v_documentRange, v_rangeToStart, v_rangeToEnd, v_start, v_end, v_result = false, v_c;
  v_e = a_event;
  v_targetElement = this;
  if (!v_targetElement) {
    return false;
  }
  v_ctrlIdx = getAdvControlIdxFromName(AdvGB_ActiveControl.name);
  v_attributeId = ADVIT_ATTRIBUTE[v_ctrlIdx];
  v_attributeCategoryId = v_attributeId.substr(0, 1);
  if (v_attributeCategoryId === 'S') {
    return true;
  }
  v_code = v_e.charCode || v_e.keyCode;
  if (v_e.charCode === 0) {
    return true;
  }
  if (v_e.ctrlKey || v_e.altKey) {
    return true;
  }
  if (v_code < 32) {
    return true;
  }
  v_c = String.fromCharCode(v_code);
  if (this.selectionStart !== undefined && this.selectionEnd !== undefined) {
    v_newValue = this.value.substring(0, this.selectionStart) + v_c + this.value.substr(this.selectionEnd);
  }
  else if (document.selection) {
    v_documentRange = document.selection.createRange();
    v_rangeToStart = v_targetElement.createTextRange();
    v_rangeToStart.setEndPoint('EndToStart', v_documentRange);
    v_start = v_rangeToStart.text.length;
    v_rangeToEnd = v_targetElement.createTextRange();
    v_rangeToEnd.setEndPoint('EndToEnd', v_documentRange);
    v_end = v_rangeToEnd.text.length;
    v_newValue = this.value.substr(0, v_start) + v_c + this.value.substr(v_end);
  }
  else {
    return false;
  }
  if (v_attributeCategoryId === 'N') {
    if (ADVIT_MAXLENGTHMODE[v_ctrlIdx] === 1) {
      v_result = isStdNumericWithDigitsCheck(v_newValue, ADVIT_LENGTH[v_ctrlIdx], ADVIT_DECIMAL[v_ctrlIdx]);
    }
    else {
      if (ADVIT_DECIMAL[v_ctrlIdx] > 0) {
        v_result = isStdNumeric(v_newValue);
      }
      else {
        v_result = isStdInteger(v_newValue);
      }
    }
  }
  else if (v_attributeCategoryId === "D") {
    v_result = ADVIT_MAXLENGTHMODE[v_ctrlIdx] === 1 ? isStdDateWithDigitsCheck(v_newValue, getAdvMaxLength(v_ctrlIdx, false)) : isStdDateTime(v_newValue);
  }
  if (v_result) {
    return true;
  }
  else {
    if (v_e.cancelable) {
      v_e.preventDefault();
    }
    if (v_e.returnValue) {
      v_e.returnValue = false;
    }
    return false;
  }
}
function showAdvCodeWindow(iItemId, iMNo, iCodType, iLevelNo, iCodeId) {
  var cmnPara2 = "scrollbars=0,toolbar=0,location=0,directories=0,menubar=0,resizable=1,top=" + (screen.height - 80) / 2 + ",left=" + (screen.width - 270) / 2 + ",width=450,height=50";
  var cmnPara1 = location.href;
  if (iCodType == "COD") {
    cmnPara1 = "../pjcommon/code/CodeCODInit.aspx?advit_id=" + iItemId + "&advit_mno=" + iMNo + "&advit_mstartidx=" + AdvGB_MCtrlStartIdx + "&levelno=" + iLevelNo + "&isInit=true&advit_code_id=" + iCodeId + "&adv_location=" + cmnPara1;
  }
  else if (iCodType == "COG") {
    cmnPara1 = "../pjcommon/code/CodeCOG.aspx?advit_id=" + iItemId + "&advit_mno=" + iMNo + "&advit_mstartidx=" + AdvGB_MCtrlStartIdx + "&levelno=" + iLevelNo + "&advit_code_id=" + iCodeId + "&adv_location=" + cmnPara1;
  }
  AdvGB_CodeWindowOpen = window.open(cmnPara1, "AdvCodeWin01", cmnPara2);
  AdvGB_CodeWindowOpen.opener = this.window;
}
function execAdvSubmit() {
  if (AdvGB_FirstFindSubmit != null) {
    AdvGB_LastClickItem = AdvGB_FirstFindSubmit;
    AdvGB_LastClickItemNm = getAdvItemIDfromCtrl(AdvGB_FirstFindSubmit);
    AdvGB_LastClickItemMNo = getAdvItemMNofromCtrl(AdvGB_FirstFindSubmit);
    if (g_onSubmit()) {
      setAdvEventTarget(AdvGB_LastClickItem);
      AdvGB_TargetForm.submit();
    }
    return false;
  }
}
function execAdvSubmit2(iTarget, iString) {
  AdvGB_LastClickItem = iTarget;
  AdvGB_LastClickItemNm = getAdvItemIDfromCtrl(iTarget);
  AdvGB_LastClickItemMNo = getAdvItemMNofromCtrl(iTarget);
  if (g_onSubmit()) {
    AdvGB_TargetForm.action = iString;
    AdvGB_TargetForm.submit();
  }
  return false;
}
function getAdvMaxLength(iCIdx, iFormat) {
  var cmnRetLen;
  if (ADVIT_ATTRIBUTE[iCIdx] == "D") {
    switch (ADVIT_FORMAT[iCIdx]) {
      case "52": case "60": case "65": return (iFormat) ? 10 : 8;
      case "53": case "56": case "63": case "66": return (iFormat) ? 8 : 6;
      case "54": case "61": return (iFormat) ? 7 : 6;
      case "55": case "57": case "58": case "59": case "62": case "64": return (iFormat) ? 5 : 4;
      default: var lengthMethod = window["quiqCustomFormatLength" + ADVIT_FORMAT[iCIdx]];
        if (lengthMethod == undefined) {
          alert("Not found the unformat method \"quiqCustomFormatLength" + ADVIT_FORMAT[iCIdx] + "\".");
          return ADVIT_LENGTH[iCIdx];
        }
        else {
          return lengthMethod(ADVIT_ID[iCIdx], iFormat);
        }
    }
  }
  else if (ADVIT_ATTRIBUTE[iCIdx] == "DX") {
    switch (ADVIT_ID[iCIdx].substr(ADVIT_ID[iCIdx].length - 2).toUpperCase()) {
      case "_Y": switch (ADVIT_FORMAT[iCIdx]) {
        case "52": case "54": case "60": case "61": case "65": return 4;
        case "53": case "55": case "63": case "64": case "66": return 2;
        default: return ADVIT_LENGTH[iCIdx];
      }case "_M": case "_D": case "_H": case "_N": case "_S": return 2;
      default: return ADVIT_LENGTH[iCIdx];
    }
  }
  else {
    cmnRetLen = ADVIT_LENGTH[iCIdx];
    switch (ADVIT_FORMAT[iCIdx]) {
      case "00": case "10": case "11": case "12": case "14": case "15": case "18": case "19": case "21": case "22": case "31": case "32": case "34": case "35": case "37": case "38": if (ADVIT_ATTRIBUTE[iCIdx].substr(0, 1) == "N") {
        if (ADVIT_ATTRIBUTE[iCIdx] != "NA" && ADVIT_ATTRIBUTE[iCIdx] != "NB") {
          cmnRetLen = cmnRetLen + 1;
        }
      }
        if (ADVIT_DECIMAL[iCIdx] > 0) {
          cmnRetLen = cmnRetLen + 1;
        }
        if (iFormat) {
          switch (ADVIT_FORMAT[iCIdx]) {
            case "31": case "32": case "34": case "35": case "37": case "38": cmnRetLen = cmnRetLen + 1;
            case "12": case "15": case "19": case "22": var cmnIntKeta = ADVIT_LENGTH[iCIdx] - ADVIT_DECIMAL[iCIdx];
              cmnRetLen = cmnRetLen + Math.floor((cmnIntKeta - 1) / 3);
          }
        }
        break;
      default: var lengthMethod = window["quiqCustomFormatLength" + ADVIT_FORMAT[iCIdx]];
        if (lengthMethod == undefined) {
          alert("Not found the unformat method \"quiqCustomFormatLength" + ADVIT_FORMAT[iCIdx] + "\".");
          cmnRetLen = ADVIT_LENGTH[iCIdx];
        }
        else {
          cmnRetLen = lengthMethod(ADVIT_ID[iCIdx], iFormat);
        }
        break;
    }return cmnRetLen;
  }
}
function getAdvFirstCtrl(iControl) {
  var cmnTarget;
  var cmnMNo;
  for (var i = 0;
    i < ADVIT_ID.length;
    i++) {
    if (ADVIT_LEVEL[i] == "") {
      cmnTarget = getStdCanMoveCtl(i);
      if (cmnTarget != null) {
        return cmnTarget;
      }
    }
    else {
      cmnMNo = ADVIT_LEVEL[i].substr(1, 1);
      for (var j = 1;
        j <= AdvGB_MRowCnt[cmnMNo];
        j++) {
        for (var k = i;
          k <= ADVIT_M_LASTIDX[cmnMNo];
          k++) {
          cmnTarget = getStdCanMoveCtl(k, j);
          if (cmnTarget != null) {
            return cmnTarget;
          }
        }
      }
      i = ADVIT_M_LASTIDX[cmnMNo];
    }
  }
  return null;
}
function getAdvNextCtrl(iCtrl) {
  var cmnTarget, cmnMNo, cmnMStart;
  var cmnITIdx = getAdvControlIdxFromName(iCtrl.name);
  var cmnMRow = getAdvItemMNofromCtrl(iCtrl);
  for (var i = cmnITIdx;
    i < ADVIT_ID.length;
    i++) {
    if (i == ADVIT_ID.length - 1 && ADVIT_LEVEL[i] == "") {
      break;
    }
    if (ADVIT_LEVEL[i + 1] == "" && ADVIT_LEVEL[i] == "") {
      cmnTarget = getStdCanMoveCtl(i + 1);
      if (cmnTarget != null) {
        return cmnTarget;
      }
    }
    else if (ADVIT_LEVEL[i + 1] == "" && ADVIT_LEVEL[i] != "" && AdvGB_MRowCnt[ADVIT_LEVEL[i].substr(1, 1)] == cmnMRow) {
      cmnTarget = getStdCanMoveCtl(i + 1);
      if (cmnTarget != null) {
        return cmnTarget;
      }
    }
    else {
      if (i == ADVIT_ID.length - 1) {
        cmnMNo = ADVIT_LEVEL[i].substr(1, 1);
        cmnMStart = i + 1;
        if (AdvGB_MRowCnt[cmnMNo] == cmnMRow) {
          break;
        }
      }
      else {
        if (ADVIT_LEVEL[i] == "" && ADVIT_LEVEL[i + 1] != "") {
          cmnMNo = ADVIT_LEVEL[i + 1].substr(1, 1);
          cmnMStart = ADVIT_M_STARTIDX[cmnMNo];
          cmnMRow = 1;
        }
        else if (ADVIT_LEVEL[i] != "" && ADVIT_LEVEL[i + 1] != "") {
          cmnMNo = ADVIT_LEVEL[i].substr(1, 1);
          cmnMStart = i + 1;
          if (ADVIT_LEVEL[i].toLowerCase() != ADVIT_LEVEL[i + 1].toLowerCase() && AdvGB_MRowCnt[cmnMNo] == cmnMRow) {
            cmnMNo = ADVIT_LEVEL[i + 1].substr(1, 1);
            cmnMStart = ADVIT_M_STARTIDX[cmnMNo];
            cmnMRow = 1;
          }
        }
        else if (ADVIT_LEVEL[i] != "" && ADVIT_LEVEL[i + 1] == "") {
          cmnMNo = ADVIT_LEVEL[i].substr(1, 1);
          cmnMStart = ADVIT_M_STARTIDX[cmnMNo];
          cmnMRow = cmnMRow + 1;
        }
      }
      for (var j = cmnMRow;
        j <= AdvGB_MRowCnt[cmnMNo];
        j++) {
        for (var k = cmnMStart;
          k <= ADVIT_M_LASTIDX[cmnMNo];
          k++) {
          cmnTarget = getStdCanMoveCtl(k, j);
          if (cmnTarget != null) {
            return cmnTarget;
          }
        }
        cmnMStart = ADVIT_M_STARTIDX[cmnMNo];
      }
      cmnMRow = AdvGB_MRowCnt[cmnMNo];
      i = ADVIT_M_LASTIDX[cmnMNo] - 1;
    }
  }
  return iCtrl;
}
(function () {
  var findMCtrl = function (mNo, row, itemIdx) {
    var left = ADVIT_M_STARTIDX[mNo];
    var right = itemIdx - 1;
    for (var i = row;
      i > 0;
      i--) {
      for (var j = right;
        j >= left;
        j--) {
        var fctrl = getStdCanMoveCtl(j, i);
        if (fctrl != null) {
          return fctrl;
        }
      }
      right = ADVIT_M_LASTIDX[mNo];
    }
    return null;
  };
  var findLastMCtrl = function (mNo) {
    var row = AdvGB_MRowCnt[mNo];
    var left = ADVIT_M_STARTIDX[mNo];
    var right = ADVIT_M_LASTIDX[mNo];
    for (var i = row;
      i > 0;
      i--) {
      for (var j = right;
        j >= left;
        j--) {
        var fctrl = getStdCanMoveCtl(j, i);
        if (fctrl != null) {
          return fctrl;
        }
      }
    }
    return null;
  };
  var getAdvBeforeCtrlInternal = function (iCtrl) {
    try {
      var ret, mNo, e;
      var cmnITIdx = getAdvControlIdxFromName(iCtrl.name);
      var mId = ADVIT_LEVEL[cmnITIdx];
      if (mId != "") {
        var row = getAdvItemMNofromCtrl(iCtrl);
        mNo = mId.substr(1, 1);
        ret = findMCtrl(mNo, row, cmnITIdx);
        if (ret) {
          return ret;
        }
        cmnITIdx = ADVIT_M_STARTIDX[mNo];
      }
      for (var i = cmnITIdx - 1;
        i >= 0;
        i--) {
        mId = ADVIT_LEVEL[i];
        if (mId == "") {
          ret = getStdCanMoveCtl(i);
          if (ret) {
            return ret;
          }
        }
        else {
          mNo = mId.substr(1, 1);
          ret = findLastMCtrl(mNo);
          if (ret) {
            return ret;
          }
          i = ADVIT_M_STARTIDX[mNo];
        }
      }
    }
    catch (e) { }
    return iCtrl;
  };
  window.getAdvBeforeCtrl = getAdvBeforeCtrlInternal;
})();
function getAdvBeforeCtrlV13(iCtrl) {
  var cmnTarget, cmnMNo, cmnMStart;
  var cmnITIdx = getAdvControlIdxFromName(iCtrl.name);
  var cmnMRow = getAdvItemMNofromCtrl(iCtrl);
  for (var i = cmnITIdx;
    i >= 0;
    i--) {
    if (i == 0 && ADVIT_LEVEL[i] == "") {
      break;
    }
    if (ADVIT_LEVEL[i - 1] == "" && ADVIT_LEVEL[i] == "") {
      cmnTarget = getStdCanMoveCtl(i - 1);
      if (cmnTarget != null) {
        return cmnTarget;
      }
    }
    else if (ADVIT_LEVEL[i - 1] == "" && ADVIT_LEVEL[i] != "" && cmnMRow == 1) {
      cmnTarget = getStdCanMoveCtl(i - 1);
      if (cmnTarget != null) {
        return cmnTarget;
      }
    }
    else {
      if (i == 0) {
        cmnMNo = ADVIT_LEVEL[i].substr(1, 1);
        cmnMStart = i - 1;
        if (cmnMRow == 1) {
          break;
        }
      }
      else {
        if (ADVIT_LEVEL[i] == "" && ADVIT_LEVEL[i - 1] != "") {
          cmnMNo = ADVIT_LEVEL[i - 1].substr(1, 1);
          cmnMStart = ADVIT_M_LASTIDX[cmnMNo];
          cmnMRow = AdvGB_MRowCnt[cmnMNo];
        }
        else if (ADVIT_LEVEL[i] != "" && ADVIT_LEVEL[i - 1] != "") {
          cmnMNo = ADVIT_LEVEL[i].substr(1, 1);
          cmnMStart = i - 1;
          if (ADVIT_LEVEL[i].toLowerCase() != ADVIT_LEVEL[i - 1].toLowerCase() && cmnMRow == 1) {
            cmnMNo = ADVIT_LEVEL[i - 1].substr(1, 1);
            cmnMStart = ADVIT_M_LASTIDX[cmnMNo];
            cmnMRow = AdvGB_MRowCnt[cmnMNo];
          }
        }
        else if (ADVIT_LEVEL[i] != "" && ADVIT_LEVEL[i - 1] == "") {
          cmnMNo = ADVIT_LEVEL[i].substr(1, 1);
          cmnMStart = ADVIT_M_LASTIDX[cmnMNo];
          cmnMRow = cmnMRow - 1;
        }
      }
      for (var j = cmnMRow;
        j > 0;
        --j) {
        for (var k = cmnMStart;
          k >= ADVIT_M_STARTIDX[cmnMNo];
          k--) {
          cmnTarget = getStdCanMoveCtl(k, j);
          if (cmnTarget != null) {
            return cmnTarget;
          }
        }
        cmnMStart = ADVIT_M_LASTIDX[cmnMNo];
      }
      if (cmnMRow > 1) {
        cmnMRow = AdvGB_MRowCnt[cmnMNo];
        i = ADVIT_M_STARTIDX[cmnMNo] + 1;
      }
    }
  }
  return iCtrl;
}
function getAdvElementIndex(item) {
  var indexInHTML = -1;
  for (var i = 0;
    i < AdvGB_TargetForm.elements.length;
    ++i) {
    if (AdvGB_TargetForm.elements[i] == item) {
      indexInHTML = i;
      break;
    }
  }
  return indexInHTML;
}
function getAdvUpCtrl(iCtrl) {
  var cmnTarget;
  var cmnCtrlIdx = getAdvControlIdxFromName(iCtrl.name);
  if (iCtrl.name.toLowerCase().match(AdvGB_M_NAME_MEDFIX) != null) {
    var cmnMRow = getAdvItemMNofromCtrl(iCtrl);
    for (var j = cmnMRow - 1;
      j > 0;
      j--) {
      cmnTarget = getStdCanMoveCtl(cmnCtrlIdx, j);
      if (cmnTarget != null) {
        return cmnTarget;
      }
    }
  }
  return iCtrl;
}
function getAdvDownCtrl(iCtrl) {
  var cmnTarget;
  var cmnCtrlIdx = getAdvControlIdxFromName(iCtrl.name);
  if (iCtrl.name.toLowerCase().match(AdvGB_M_NAME_MEDFIX) != null) {
    var cmnMNo = ADVIT_LEVEL[cmnCtrlIdx].substr(1, 1);
    var cmnMRow = getAdvItemMNofromCtrl(iCtrl);
    for (var j = cmnMRow + 1;
      j <= AdvGB_MRowCnt[cmnMNo];
      j++) {
      cmnTarget = getStdCanMoveCtl(cmnCtrlIdx, j);
      if (cmnTarget != null) {
        return cmnTarget;
      }
    }
  }
  return iCtrl;
}
function isStdNullOrEmptyOrUndefined(iCtrl) {
  return iCtrl !== "0" ? (!iCtrl ? true : false) : false;
}
function canStdFocus(iCtrl) {
  var v_result = true, v_visibility, v_display, v_targetObj, v_doc = document;
  if ((iCtrl && !iCtrl.readOnly && !iCtrl.disabled && iCtrl.type !== "hidden" && iCtrl.style.visibility !== "hidden")) {
    if (v_doc.defaultView) {
      v_visibility = v_doc.defaultView.getComputedStyle(iCtrl, null).visibility;
      v_display = v_doc.defaultView.getComputedStyle(iCtrl, null).display;
      if (v_visibility === "hidden" || v_visibility === "collapse" || v_display === "none") {
        v_result = false;
      }
      else {
        v_targetObj = iCtrl.parentNode;
        while (v_targetObj && v_targetObj !== v_doc) {
          v_display = v_doc.defaultView.getComputedStyle(v_targetObj, null).display;
          if (v_display === "none") {
            v_result = false;
            break;
          }
          v_targetObj = v_targetObj.parentNode;
        }
      }
    }
    else {
      v_targetObj = iCtrl;
      while (v_targetObj && v_targetObj !== v_doc) {
        v_visibility = v_targetObj.style.visibility;
        v_display = v_targetObj.style.display;
        v_display_css = null;
        if (!isStdNullOrEmptyOrUndefined(v_targetObj.currentStyle)) {
          v_display_css = v_targetObj.currentStyle.display;
        }
        if (v_visibility === "hidden" || v_visibility === "collapse" || v_display === "none" || v_display_css === "none") {
          v_result = false;
          break;
        }
        v_targetObj = v_targetObj.parentNode;
      }
    }
  }
  else {
    v_result = false;
  }
  return v_result;
}
function getStdCanMoveCtl(iControlIdx, iMeiNo) {
  switch (ADVIT_TYPE[iControlIdx]) {
    case "TXT": case "TX2": case "PWD": case "DRL": case "CHK": case "RDO": case "SUB": case "RDO": case "FUP": var cmnTarget = getAdvControlFromIdx(iControlIdx, iMeiNo);
      if (cmnTarget != null && cmnTarget.type.toLowerCase() != "hidden") {
          // TODO yusy IE判定は一旦コメントアウト
          //if (Std_NavIE) {
          if (canStdFocus(cmnTarget)) {
            return cmnTarget;
          }
        //}
        //else {
        //  return cmnTarget;
        //}
      }
  }return null;
}
function getItemInfo_std(iCix, iInfoName) {
  if (iCix == -1) {
    return "";
  }
  return eval(iInfoName + "[" + iCix + "]");
}
function getAdvControlIdxFromName(iControlName) {
  var cmnName = iControlName.toLowerCase();
  if (cmnName.length == 0) {
    return -1;
  }
  if (cmnName.toLowerCase().match(AdvGB_M_NAME_MEDFIX) != null) {
    var position = cmnName.search(AdvGB_M_NAME_MEDFIX);
    var name_t = cmnName.match(AdvGB_M_NAME_MEDFIX)[0];
    position += name_t.length;
    cmnName = cmnName.substring(position, cmnName.length);
  }
  if (Std_NavIE) {
    return getAdvControlIdxFromNameA(cmnName);
  }
  var cmnPos = AdvGB_ID_STRING.toLowerCase().indexOf(("," + cmnName + ",").toLowerCase());
  if (cmnPos == -1) {
    return -1;
  }
  var cmnWkStr = AdvGB_ID_STRING.substr(0, cmnPos);
  var cmnArrayStr = cmnWkStr.split(",");
  return cmnArrayStr.length - 1;
}
function getAdvControlIdxFromNameA(iControlName) {
  try {
    return eval("ADVIT_ID_" + iControlName.toUpperCase());
  }
  catch (e) {
    return -1;
  }
  return;
}
function getStdMNoPrefix(iMeiNo) {
  if (iMeiNo < 10) {
    return "$ctl0" + iMeiNo + "$";
  }
  else {
    return "$ctl" + iMeiNo + "$";
  }
}
function getAdvControlFromIdx(iControlIdx, iMeiNo) {
  var cmnName;
  if (iMeiNo == null) {
    cmnName = ADVIT_ID[iControlIdx];
  }
  else {
    iMeiNo = parseInt(iMeiNo) + AdvGB_MCtrlStartIdx - 1;
    cmnName = ADVIT_LEVEL[iControlIdx].toUpperCase() + getStdMNoPrefix(iMeiNo) + ADVIT_ID[iControlIdx];
  }
  if (Std_NavIE) {
    var cmnCtrl = AdvGB_TargetForm.elements(cmnName);
    if (cmnCtrl == null) {
      return null;
    }
    if (cmnCtrl.type == null && cmnCtrl[0].type.toLowerCase() == "radio") {
      for (var i = 0;
        i < cmnCtrl.length;
        i++) {
        if (cmnCtrl[i].checked == true) {
          return cmnCtrl[i];
        }
      }
    }
    if (cmnCtrl.type == null && cmnCtrl[0] != null) {
      return cmnCtrl[0];
    }
    return cmnCtrl;
  }
  else {
    for (var i = 0;
      i < AdvGB_TargetForm.elements.length;
      i++) {
      if (AdvGB_TargetForm.elements[i].name != null) {
        if (cmnName.toUpperCase() == AdvGB_TargetForm.elements[i].name.toUpperCase()) {
          if (AdvGB_TargetForm.elements[i].type.toLowerCase() == "radio") {
            if (AdvGB_TargetForm.elements[i].checked == true) {
              return AdvGB_TargetForm.elements[i];
            }
          }
          else {
            return AdvGB_TargetForm.elements[i];
          }
        }
      }
    }
    return null;
  }
}
function getAdvControlFromItemID(iItemID, iMeiNo) {
  return eval("AdvGB_TargetForm." + getAdvControlNameFromItemID(iItemID, iMeiNo));
}
function getAdvControlNameFromItemID(iItemID, iMeiNo) {
  if (iMeiNo != null) {
    iMeiNo = parseInt(iMeiNo) + 1;
  }
  var wItemIdx = getAdvControlIdxFromName(iItemID);
  if (wItemIdx > -1) {
    iItemID = ADVIT_ID[wItemIdx];
  }
  if (iMeiNo != null) {
    if (iMeiNo > 0) {
      if (ADVIT_LEVEL[wItemIdx] == "") {
        return iItemID;
      }
      else {
        return ADVIT_LEVEL[wItemIdx].toUpperCase() + getStdMNoPrefix(iMeiNo) + iItemID;
      }
    }
  }
  if (ADVIT_LEVEL[wItemIdx] == "") {
    return iItemID;
  }
  else {
    return ADVIT_LEVEL[wItemIdx].toUpperCase() + getStdMNoPrefix(2) + iItemID;
  }
}
function getAdvEventTarget(ev) {
  //if (Std_NavIE) {
    return window.event.srcElement;
  //}
  if (document.layers) {
    return ev.target;
  }
  if (document.getElementById) {
    return ev.currentTarget;
  }
}
function getAdvEventTargetName(ev) {
  return getAdvItemIDfromCtrl(getAdvEventTarget(ev));
}
function getAdvItemIDfromCtrl(iCtrl) {
  return getAdvItemID(getStdADVIDfromCtrl(iCtrl));
}
function getAdvItemID(iName) {
  if (iName.toLowerCase().match(AdvGB_M_NAME_MEDFIX) != null) {
    var position = iName.search(AdvGB_M_NAME_MEDFIX);
    var name_t = iName.match(AdvGB_M_NAME_MEDFIX)[0];
    position += name_t.length;
    iName = iName.substring(position, iName.length);
  }
  return iName;
}
function getAdvItemMNofromCtrl(iCtrl) {
  return getAdvItemMNo(getStdADVIDfromCtrl(iCtrl));
}
function getAdvItemMNo(iName) {
  if (iName.toLowerCase().match(AdvGB_M_NAME_MEDFIX) != null) {
    var temp = iName.match(AdvGB_M_NAME_MEDFIX)[0];
    temp = temp.substring(4, temp.length - 1);
    return parseFloat(temp) - AdvGB_MCtrlStartIdx + 1;
  }
  else {
    return 0;
  }
}
function getAdvItemSNoFromLevelID(iLevelID) {
  if (AdvGB_TargetForm.elements(iLevelID + AdvGB_M_SNO_EXT) != null) {
    return AdvGB_TargetForm.elements(iLevelID + AdvGB_M_SNO_EXT).value;
  }
  else {
    return 0;
  }
}
function getStdADVIDfromCtrl(iCtrl) {
  if (iCtrl.name != null && iCtrl.name.length != 0) {
    return iCtrl.name;
  }
  else if (iCtrl.id != null) {
    var ret;
    if (iCtrl.id.toLowerCase().match(AdvGB_M_ID_MEDFIX) != null) {
      var temp = iCtrl.id.split("_");
      if (temp.length >= 3) {
        ret = temp[0] + "$" + temp[1] + "$";
        for (var i = 2;
          i < temp.length;
          i++) {
          ret = ret + temp[i];
          if (i < temp.length - 1) {
            ret = ret + "_";
          }
        }
      }
    }
    else {
      ret = iCtrl.id;
    }
    return ret;
  }
  else {
    return "";
  }
}
function getAdvMaxMRow(iMNo) {
  return AdvGB_MRowCnt[iMNo];
}
function getAdvAssembleMsg(iMsgStr, iCix, iValue) {
  var cmnStr = iMsgStr;
  switch (ADVIT_ATTRIBUTE[iCix]) {
    case "B": case "D": case "DX": break;
    default: if (ADVIT_ATTRIBUTE[iCix].length > 0) {
      var cmnAttIdx = eval("ADVAT_ID_" + ADVIT_ATTRIBUTE[iCix].toUpperCase());
      cmnStr = replaceAdv(cmnStr, "%AT_BIKO%", ADVAT_BIKO[cmnAttIdx]);
      cmnStr = replaceAdv(cmnStr, "%AT_NAME%", ADVAT_NAME[cmnAttIdx]);
      cmnStr = replaceAdv(cmnStr, "%AT_ULFLG%", ADVAT_ULFLG[cmnAttIdx]);
      cmnStr = replaceAdv(cmnStr, "%AT_AHFLG%", ADVAT_AHFLG[cmnAttIdx]);
      cmnStr = replaceAdv(cmnStr, "%AT_REGSTR%", ADVAT_REGSTR[cmnAttIdx]);
      cmnStr = replaceAdv(cmnStr, "%AT_CHKSTR%", ADVAT_CHKSTR[cmnAttIdx]);
      cmnStr = replaceAdv(cmnStr, "%AT_CHKFLG%", ADVAT_CHKFLG[cmnAttIdx]);
    }
  }cmnStr = replaceAdv(cmnStr, "%VALUE%", iValue);
  cmnStr = replaceAdv(cmnStr, "%IT_ID%", ADVIT_ID[iCix]);
  cmnStr = replaceAdv(cmnStr, "%IT_NAME%", ADVIT_NAME[iCix]);
  cmnStr = replaceAdv(cmnStr, "%IT_ATTRIBUTE%", ADVIT_ATTRIBUTE[iCix]);
  cmnStr = replaceAdv(cmnStr, "%IT_LENGTH%", ADVIT_LENGTH[iCix]);
  cmnStr = replaceAdv(cmnStr, "%IT_AUTOTAB%", ADVIT_AUTOTAB[iCix]);
  cmnStr = replaceAdv(cmnStr, "%IT_DECIMAL%", ADVIT_DECIMAL[iCix]);
  cmnStr = replaceAdv(cmnStr, "%IT_REQUIRED%", ADVIT_REQUIRED[iCix]);
  cmnStr = replaceAdv(cmnStr, "%IT_TYPE%", ADVIT_TYPE[iCix]);
  cmnStr = replaceAdv(cmnStr, "%IT_FORMAT%", ADVIT_FORMAT[iCix]);
  cmnStr = replaceAdv(cmnStr, "%IT_CODEID%", ADVIT_CODEID[iCix]);
  cmnStr = replaceAdv(cmnStr, "%IT_CODENAME%", ADVIT_CODENAME[iCix]);
  cmnStr = replaceAdv(cmnStr, "%IT_LEVEL%", ADVIT_LEVEL[iCix]);
  cmnStr = replaceAdv(cmnStr, "%IT_HLCHK%", ADVIT_HLCHK[iCix]);
  cmnStr = replaceAdv(cmnStr, "%IT_IMEMODE%", ADVIT_IMEMODE[iCix]);
  cmnStr = replaceAdv(cmnStr, "%IT_AUTOCODECHK%", ADVIT_AUTOCODECHK[iCix]);
  cmnStr = replaceAdv(cmnStr, "%IT_MAXLENGTHMODE%", ADVIT_MAXLENGTHMODE[iCix]);
  cmnStr = replaceAdv(cmnStr, "%IT_CONDID%", ADVIT_CONDID[iCix]);
  cmnStr = replaceAdv(cmnStr, "%IT_ACTIONID%", ADVIT_ACTIONID[iCix]);
  cmnStr = replaceAdv(cmnStr, "%IT_CAPTION%", ADVIT_CAPTION[iCix]);
  cmnStr = replaceAdv(cmnStr, "%IT_INTEGER%", ADVIT_LENGTH[iCix] - ADVIT_DECIMAL[iCix]);
  return cmnStr;
}
function setAdvCtrlProtect(iCName, iMode) {
  var cmnCtrl = AdvGB_TargetForm.elements(iCName);
  if (cmnCtrl.type != null) {
    switch (cmnCtrl.type.toLowerCase()) {
      case "text": case "textarea": case "password": if (Std_NavIE) {
        cmnCtrl.readOnly = iMode;
      }
        cmnCtrl.style.backgroundColor = iMode ? "#D0D0D0" : "";
        break;
      case "select-one": case "select-multiple": if (Std_NavIE) {
        cmnCtrl.disabled = iMode;
      }
        cmnCtrl.style.backgroundColor = iMode ? "#D0D0D0" : "";
        break;
      case "radio": case "checkbox": case "button": case "submit": case "reset": if (Std_NavIE) {
        cmnCtrl.disabled = iMode;
      }
        break;
      default: break;
    }
  }
  if (cmnCtrl.type == null && cmnCtrl[0].type.toLowerCase() == "radio") {
    for (var i = 0;
      i < cmnCtrl.length;
      i++) {
      if (Std_NavIE) {
        cmnCtrl[i].disabled = iMode;
      }
    }
  }
}
function replaceAdv(iTargetStr, iOutStr, iInStr) {
  var cmnSplit = iTargetStr.split(iOutStr);
  var cmnStr = cmnSplit[0];
  for (var i = 0;
    i < cmnSplit.length - 1;
    i++) {
    cmnStr = cmnStr + iInStr + cmnSplit[i + 1];
  }
  return cmnStr;
}
function getAdvNavigatorName() {
  if (navigator.userAgent.match(/.*Trident.*rv:1[0-9]{1}.*/)) {
    return "IE";
  }
  if (navigator.appName.charAt(0).toUpperCase() == "N") {
    return "NN";
  }
  if (navigator.appName.charAt(0).toUpperCase() == "M") {
    return "IE";
  }
  return null;
}
function onSubmitPrev_std() {
  if (AdvGB_LastClickItemNm == null) {
    return true;
  }
  return g_onSubmit();
}