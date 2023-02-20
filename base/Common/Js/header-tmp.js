function LogoutConfirm() {
	window.localStorage.setItem("clsBtn", "1");
	document.getElementById("CANCEL").value = "0";
	if (window.localStorage.getItem("LogoffFunctionID") == null || localStorage.getItem("LogoffFunctionID").length < 5) {
		var winClose = findWinClose();
		if (WinCloseCheck == "1") {
			var result = LogoutCheck("1", winClose)
			if (result) {
				document.forms[0].target = "_top";
				winStorageClear();
				return true;
			} else {
				document.getElementById("CANCEL").value = "1";
				return false;
			}
		} else {
			if (WinCloseCheck != "9") {
				var result = LogoutCheck("1", winClose)
				if (result) {
					document.forms[0].target = "_top";
					winStorageClear();
					return true;
				} else {
					return false;
				}
			} else {
				document.getElementById("END").value = "9";
			}
		}
	} else {
		// --------------- 2012/12/07 WT)K.Banno 変更管理[OM-0092] Update START ---------------
		if (WinCloseCheck != "9") {
			var url = window.localStorage.getItem("functionUrl")
				+ "?loginId=" + window.localStorage.getItem("loginId")
				+ "&comId=" + window.localStorage.getItem("comId")
				+ "&solutionId=" + window.localStorage.getItem("LoginSolutionID")
				+ "&functionId=" + window.localStorage.getItem("LogoffFunctionID")
				+ "&certId=" + window.localStorage.getItem("LogoffFunctionID");
			var returnValue = window.open(url, this, 'dialogWidth:500px;dialogHeight:180px;status:no;center:yes;edge:sunken;help:no;resizable:no;scroll:no;dependent:no');
			try {
				if (returnValue[0] != null && returnValue[0] == "ok") {
					document.forms[0].target = "_top";
					winStorageClear();
					window.localStorage.setItem("LogoffFunctionIDOK", "ok");
					window.open('../Login.html?FkeyCheck=ok', '_top', '', '');
					return true;
				}
				else {
					document.getElementById("CANCEL").value = "1";
					return false;
				}
			} catch (e) {
				document.getElementById("CANCEL").value = "1";
				return false;
			}
		}
		// --------------- 2012/12/07 WT)K.Banno 変更管理[OM-0092] Update  END  ---------------
	}
}