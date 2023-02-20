// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
// 改版履歴
// 2012/03/16 WT)Banno OT障害対応[OT0-0002]
// 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更
winobj = new Array(500);
// クッキー削除 
function RemoveCookie(name) {
    var exp = new Date();
    exp.setTime(exp.getTime() - 1);
    var cval = GetCookie(name);
    document.cookie = name + "=" + cval + "; expires=" + exp.toGMTString();
}
// クッキー取得ルーチン
function GetCookie(name) {
    var arg = name + "=";
    var alen = arg.length;
    var clen = document.cookie.length;
    var i = 0;
    while (i < clen) {
        var j = i + alen;
        if (document.cookie.substring(i, j) == arg) {
            return GetCookieVal(j);
        }
        i = document.cookie.indexOf(" ", i) + 1;
        if (i == 0) {
            break;
        }
    }
    return null;
}
// クッキー取得のサブルーチン
function GetCookieVal(offset) {
    var endstr = document.cookie.indexOf(";", offset);
    if (endstr == -1) {
        endstr = document.cookie.length;
    }
    return unescape(document.cookie.substring(offset, endstr));
}
//クッキーの設定
function SetCookie(name, value) {
    var argv = SetCookie.arguments;
    var argc = SetCookie.arguments.length;
    document.cookie = name + "=" + escape(value);
}
/*----------------------------------------------------------------------------------------------------------------------------*/
/*----------------------------------------------------------------------------------------------------------------------------*/
//機能を別画面で開く
function winOpen(solutionId, subSystemId, functionId, winName, winStyle) {
    if (solutionId == null || solutionId.length == 0 || functionId == null || functionId.length == 0) {
        return;
    }
    var windowname = getOpenWindowName(winName);
    var url = "PageTransfer.aspx?solutionId=" + solutionId + "&subSystemId=" + subSystemId + "&functionId=" + functionId;
    if (findWin(windowname)) {
        //画面表示(winName=mainの場合は別画面表示無効)
        window.open(url, windowname, winStyle);
    }
}
//ポップアップブロック対応----------------------------------------------------------
//機能を起動する。
function openFunction(solutionId, functionId, winName, winStyle, winMoveFlag, moveParam) {
    if (solutionId == null || solutionId.length == 0 || functionId == null || functionId.length == 0) {
        return;
    }
    var Width = GetCookie("LoginWidthSize");
    var Height = GetCookie("LoginHeightSize");
    var Positioning = GetCookie("LoginPositioning");
    var TopPosition = GetCookie("LoginTopPositionAdjustment");
    var Top = GetCookie("LoginPositionTop");
    var Left = GetCookie("LoginPositionLeft");
    var Toolbar = "no";
    var Location = "no";
    var Directories = "no";
    var Menubar = "no";
    // 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 Start
    //var Scrollbars = "no";
    var Scrollbars = "yes";
    // 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 End
    var Status = "yes";
    // 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 Start
    //var Resizable = "no";
    var Resizable = "yes";
    // 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 End
    var WindowStyle = "";
    if (Positioning != null && Positioning == "true") {
        if (TopPosition != null && TopPosition != "null") {
            Top = (screen.height - Height - TopPosition) / 2;
            if (Top < 0) {
                Top = 0;
            }
            Left = (screen.width - Width) / 2;
            WindowStyle = ",width=" + Width + ",height=" + Height + ",top=" + Top + ",left=" + Left + ",toolbar=" + Toolbar + ",location=" + Location + ",directories=" + Directories + ",menubar=" + Menubar + ",scrollbars=" + Scrollbars + ",status=" + Status + ",resizable=" + Resizable;
        } else {
            if (Top != null) {
                WindowStyle = ",width=" + Width + ",height=" + Height + ",top=" + Top + ",left=" + Left + ",toolbar=" + Toolbar + ",location=" + Location + ",directories=" + Directories + ",menubar=" + Menubar + ",scrollbars=" + Scrollbars + ",status=" + Status + ",resizable=" + Resizable;
            } else {
                WindowStyle = ",width=" + Width + ",height=" + Height + ",toolbar=" + Toolbar + ",location=" + Location + ",directories=" + Directories + ",menubar=" + Menubar + ",scrollbars=" + Scrollbars + ",status=" + Status + ",resizable=" + Resizable;
            }
        }
    } else {
        WindowStyle = ",width=" + Width + ",height=" + Height + ",toolbar=" + Toolbar + ",location=" + Location + ",directories=" + Directories + ",menubar=" + Menubar + ",scrollbars=" + Scrollbars + ",status=" + Status + ",resizable=" + Resizable;
    }
    //moveParam:メニューバー格納・展開時に使用
    if (winMoveFlag == 0) {
        //別画面表示フラグが0ならメニューグループを閉じる
        menuClose();
    } else {
        //メニューの移動
        move(moveParam);
    }
    var windowname = getOpenWindowName(winName);
    var url = "PageTransfer.aspx?solutionId=" + solutionId + "&functionId=" + functionId;
    //	updateWin(url, windowname, winStyle);
    updateWin(url, windowname, WindowStyle);
}

function openFunction2(solutionId, functionId, winName, winStyle, winMoveFlag, moveParam, htmlurl) {
    if (solutionId == null || solutionId.length == 0 || functionId == null || functionId.length == 0) {
        return;
    }
    var Width = GetCookie("LoginWidthSize");
    var Height = GetCookie("LoginHeightSize");
    var Positioning = GetCookie("LoginPositioning");
    var TopPosition = GetCookie("LoginTopPositionAdjustment");
    var Top = GetCookie("LoginPositionTop");
    var Left = GetCookie("LoginPositionLeft");
    var Toolbar = "no";
    var Location = "no";
    var Directories = "no";
    var Menubar = "no";
    var Scrollbars = "no";
    var Status = "yes";
    var Resizable = "no";
    var WindowStyle = "";
    if (Positioning != null && Positioning == "true") {
        if (TopPosition != null) {
            Top = (screen.height - Height - TopPosition) / 2;
            if (Top < 0) {
                Top = 0;
            }
            Left = (screen.width - Width) / 2;
            WindowStyle = ",width=" + Width + ",height=" + Height + ",top=" + Top + ",left=" + Left + ",toolbar=" + Toolbar + ",location=" + Location + ",directories=" + Directories + ",menubar=" + Menubar + ",scrollbars=" + Scrollbars + ",status=" + Status + ",resizable=" + Resizable;
        } else {
            if (Top != null) {
                WindowStyle = ",width=" + Width + ",height=" + Height + ",top=" + Top + ",left=" + Left + ",toolbar=" + Toolbar + ",location=" + Location + ",directories=" + Directories + ",menubar=" + Menubar + ",scrollbars=" + Scrollbars + ",status=" + Status + ",resizable=" + Resizable;
            } else {
                WindowStyle = ",width=" + Width + ",height=" + Height + ",toolbar=" + Toolbar + ",location=" + Location + ",directories=" + Directories + ",menubar=" + Menubar + ",scrollbars=" + Scrollbars + ",status=" + Status + ",resizable=" + Resizable;
            }
        }
    } else {
        WindowStyle = ",width=" + Width + ",height=" + Height + ",toolbar=" + Toolbar + ",location=" + Location + ",directories=" + Directories + ",menubar=" + Menubar + ",scrollbars=" + Scrollbars + ",status=" + Status + ",resizable=" + Resizable;
    }
    //moveParam:メニューバー格納・展開時に使用
    if (winMoveFlag == 0) {
        //別画面表示フラグが0ならメニューグループを閉じる
        menuClose();
    } else {
        //メニューの移動
        move(moveParam);
    }
    var windowname = winName;
    var url = htmlurl;
    //	updateWin(url, windowname, winStyle);
    updateWin(url, windowname, WindowStyle);
}

function openFunctionPDF(solutionId, functionId, winName) {
    if (solutionId == null || solutionId.length == 0 || functionId == null || functionId.length == 0) {
        return;
    }
    var Width = GetCookie("LoginWidthSize");
    var Height = GetCookie("LoginHeightSize");
    var Positioning = GetCookie("LoginPositioning");
    var TopPosition = GetCookie("LoginTopPositionAdjustment");
    var Top = GetCookie("LoginPositionTop");
    var Left = GetCookie("LoginPositionLeft");
    var Toolbar = "no";
    var Location = "no";
    var Directories = "no";
    var Menubar = "no";
    var Scrollbars = "no";
    var Status = "no";
    var Resizable = "no";
    var WindowStyle = "";
    if (Positioning != null && Positioning == "true") {
        if (TopPosition != null) {
            Top = (screen.height - Height - TopPosition) / 2;
            if (Top < 0) {
                Top = 0;
            }
            Left = (screen.width - Width) / 2;
            WindowStyle = ",width=" + Width + ",height=" + Height + ",top=" + Top + ",left=" + Left + ",toolbar=" + Toolbar + ",location=" + Location + ",directories=" + Directories + ",menubar=" + Menubar + ",scrollbars=" + Scrollbars + ",status=" + Status + ",resizable=" + Resizable;
        } else {
            if (Top != null) {
                WindowStyle = ",width=" + Width + ",height=" + Height + ",top=" + Top + ",left=" + Left + ",toolbar=" + Toolbar + ",location=" + Location + ",directories=" + Directories + ",menubar=" + Menubar + ",scrollbars=" + Scrollbars + ",status=" + Status + ",resizable=" + Resizable;
            } else {
                WindowStyle = ",width=" + Width + ",height=" + Height + ",toolbar=" + Toolbar + ",location=" + Location + ",directories=" + Directories + ",menubar=" + Menubar + ",scrollbars=" + Scrollbars + ",status=" + Status + ",resizable=" + Resizable;
            }
        }
    } else {
        WindowStyle = ",width=" + Width + ",height=" + Height + ",toolbar=" + Toolbar + ",location=" + Location + ",directories=" + Directories + ",menubar=" + Menubar + ",scrollbars=" + Scrollbars + ",status=" + Status + ",resizable=" + Resizable;
    }
    var windowname = getOpenWindowName(winName);
    var url = "FileDownloader.aspx?solutionId=" + solutionId + "&functionId=" + functionId;
    updateWinPDF(url, windowname, WindowStyle);
}
//機能を起動する。
function openSSOFunction(solutionId, functionId, eventParams, winName, winStyle, winMoveFlag, moveParam) {
    if (solutionId == null || solutionId.length == 0 || functionId == null || functionId.length == 0) {
        return;
    }
    //moveParam:メニューバー格納・展開時に使用
    if (winMoveFlag == 0) {
        //別画面表示フラグが0ならメニューグループを閉じる
        menuClose();
    } else {
        //メニューの移動
        move(moveParam);
    }
    var windowname = getOpenWindowName(winName);
    var url = "PageTransfer.aspx?solutionId=" + solutionId + "&functionId=" + functionId + "&eventParams=" + eventParams;
    updateWin(url, windowname, winStyle);
}

function updateWin(url, name, style) {
    var w;
    var flag;
    if (url == null || url.length == 0) {
        return;
    }
    //画面表示(winName=mainの場合は別画面表示無効)
    w = window.open('', name, style);
    if (GetCookie("LogoffWindowCheck") == "true") {
        try {
            //ヘッダーにウィンドウオブジェクトを格納
            // ログアウト・×ボタン対応 Start
            var openerWindow = window;
            //ヘッダーにwindowNameSetが見つかるまでループ
            while (typeof openerWindow.parent.header.windowNameSet != "function") {
                openerWindow = openerWindow.parent.opener;
            }
            openerWindow.parent.header.windowNameSet(name, w);
            // ログアウト・×ボタン対応 End
        } catch (e) { }
    }
    try {
        //HOSTが異なる場合ここでエラーが発生するためtryで囲う
        flag = w.location.href == "about:blank";
    } catch (e) {
        //例外が発生した場合既にウィンドウが開いていると判断する
        flag = false;
    }
    if (flag) {
        w.location.href = url;
    } else {
        if (name != '_self' && name != '_top') {
            w.focus();
            return;
        } else {
            w.location.href = url;
        }
    }
    try {
        //ＵＲＬが設定されているか再確認
        if (w.location.href == "about:blank") {
            w.location.href = url;
        }
    } catch (e) { }
}

function updateWinPDF(url, name, style) {
    if (url == null || url.length == 0) {
        return;
    }
    if (name == '_blank' || name == 'main') {
        if (style.length == 0) {
            //画面表示(winName=mainの場合は別画面表示無効)
            window.open(url, name);
        } else {
            //画面表示(winName=mainの場合は別画面表示無効)
            window.open(url, name, style);
        }
        return;
    }
}
//ポップアップブロック対応----------------------------------------------------------
//業務メニューを起動する。
function openBizMenu(solutionId, functionViewId, winMoveFlag, moveParam) {
    //moveParam:メニューバー格納・展開時に使用
    if (winMoveFlag == 0) {
        //別画面表示フラグが0ならメニューグループを閉じる
        menuClose();
    } else {
        //メニューの移動
        move(moveParam);
    }
    var url = "BizMenu.aspx?solutionId=" + solutionId + "&functionViewId=" + functionViewId;
    //業務メニュー画面表示
    window.open(url, 'main');
}
//ウィンドウ名を取得する
function getOpenWindowName(winName) {
    if (winName.length == 0 || winName == '_blank') {
        return '_blank';
    } else if (winName == 'main' || winName == '_self' || winName == '_top') {
        return winName;
    } else {
        return winName;
        //return window.parent.name + winName;
    }
}
//メニューバーの移動
function move(para) {
    var menuCount = getMenuGroupNum();
    var m = 1;
    for (i = 0; i < menuCount; ++i) {
        if (parseInt(para) == i) {
            document.getElementById(para).style.top = 0;
        } else {
            document.getElementById(String(i)).style.top = m * 35;
            ++m;
        }
        document.body.scrollTop = 0;
        menuClose();
    }
}
//メニューの初期化
function init() {
    var menuCount = getMenuGroupNum();
    for (i = 0; i < menuCount; ++i) {
        document.getElementById(String(i)).style.top = i * 35;
        document.getElementById(String(i)).style.left = 0;
        document.getElementById(String(i)).style.position = 'absolute';
    }
    if (menuCount != 0) {
        parent.initClose((menuCount) * 35);
    }
}
//メニューの開閉
function menuOpenClose() {
    var menuCount = getMenuGroupNum();
    if (menuCount > 1) {
        if (parent.flag == 0) {
            //開く
            document.getElementById('btn').src = 'Images/Menu/menu_end2.jpg';
            parent.iFrameOpen((menuCount) * 35);
        } else {
            //閉じる
            document.getElementById('btn').src = 'Images/Menu/menu_end.jpg';
            parent.iFrameClose((menuCount) * 35);
        }
    }
}
//メニューの開閉
function menuClose() {
    var menuCount = getMenuGroupNum();
    if (menuCount > 1) {
        if (parent.flag != 0) {
            if (document.getElementById('btn')) {
                //閉じる
                document.getElementById('btn').src = 'Images/Menu/menu_end.jpg';
                parent.iFrameClose((menuCount) * 35);
            }
        }
    }
}

function getMenuGroupNum() {
    if (!parent.iframe) {
        return 0;
    }
    // TODO yusy chrome対応
    //var num = parent.iframe.document.getElementById('groupNum').value;
    var num = parent[1].document.getElementById('groupNum').value;
    return num;
}

function g_onUnLoad() {
    var clsBtn = window.localStorage.getItem("clsBtn");
    if (self.closed || (event.clientX <= 100 || event.clientY <= 100)) {
        //Ｘ処理
        try {
            if (clsBtn != "1") {
                //ウインドウ閉じる処理
                g_canWindow();
            }
            parent.header.winCloseBtn("9");
            winStorageClear();
        } catch (e) { }
    }
}
//ローカルストレージ初期化
function winStorageClear() {
    try {
        window.localStorage.setItem("webservesmart.targetNo", 0);
    } catch (e) { }
}
//ウインドウオブジェクトを格納
function windowNameSet(tname, w) {
    try {
        var targetNo = "0";
        if (window.localStorage.getItem("webservesmart.targetNo") != null) {
            targetNo = window.localStorage.getItem("webservesmart.targetNo");
        }
        window.localStorage.setItem("tname" + targetNo, tname);
        winobj[targetNo] = w;
        window.localStorage.setItem("webservesmart.targetNo", parseInt(targetNo) + 1);
    } catch (e) { }
}
// ウインドウの閉じる処理
function g_canWindow() {
    try {
        var nextNo = window.localStorage.getItem("webservesmart.targetNo");
        if (nextNo != null) {
            for (i = 0; i <= nextNo; i++) {
                target = window.localStorage.getItem("tname" + i);
                if (target != null && target.length > 0) {
                    winc = window.open('', target, 'top=3000,left=3000,width=5px,height=5px,alwaysRaised=1');
                    winc.focus();
                    winc.close();
                }
            }
            window.localStorage.setItem("webservesmart.targetNo", 0);
        }
        if (window.localStorage) {
            //お知らせ画面(LoginFunctionID)を閉じる
            var SolutionID = window.localStorage.getItem("LoginSolutionID");
            var FunctionID = window.localStorage.getItem("LoginFunctionID");
            if (SolutionID && FunctionID) {
                var _target = SolutionID + '_' + FunctionID;
                winc = window.open('', _target, 'top=3000,left=3000,width=5px,height=5px,alwaysRaised=1');
                winc.focus();
                winc.close();
            }
            //2016-10-17 FE)Y.Kawabuchi Add Start
            //強制クローズ対象画面を閉じる
            var ClosingFunctionIDs = window.localStorage.getItem("LogoffClosingFunctionIDs");
            if (SolutionID && ClosingFunctionIDs) {
                var ClosingFunctionIDList = ClosingFunctionIDs.split(",");
                ClosingFunctionIDList.forEach(function (element, key, array) {
                    var target2 = SolutionID + '_' + element;
                    winc = window.open('', target2, 'top=3000,left=3000,width=5px,height=5px,alwaysRaised=1');
                    winc.focus();
                    winc.close();
                })
            }
            //2016-10-17 FE)Y.Kawabuchi Add End
        }
    } catch (e) { }
}
// サブウィンドウがあるかどうかを判断する処理
function findWinClose() {
    try {
        var nextNo = window.localStorage.getItem("webservesmart.targetNo");
        if (nextNo != null) {
            for (i = 0; i <= nextNo; i++) {
                target = window.localStorage.getItem("tname" + i);
                var win;
                if (target != null && target.length > 0) {
                    win = winobj[i];
                    if (!win) {
                        win = window.open("", target);
                        if (win.location.href === 'about:blank') {
                            win.close();
                        }
                    }
                }
                if (!win || win.closed) { } else {
                    //存在する
                    return false;
                }
                //20160909 FE)Y.Kawabuchi Update Start
                //var win = winobj[i];
                //if( !win || win.closed ) {
                //} else {
                //	//存在する
                //	return false;
                //}
                //20160909 FE)Y.Kawabuchi Update End
            }
        }
    } catch (e) { }
    return true;
}
/* ログオフチェック処理 */
function LogoutCheck(endProcess, winClose) {
    if (endProcess == "1") {
        var windowCheck = window.localStorage.getItem("LogoffWindowCheck");
        if (windowCheck == "true") {
            if (!winClose) {
                var forceQuit = window.localStorage.getItem("LogoffForceQuit");
                if (forceQuit == "true") {
                    //"他にウインドウが立ち上がっています。ＯＫなら強制終了します。"
                    var returnValue = showModalDialog('Confirm.aspx?pgId=' + 'Err1', this, 'dialogWidth:350px;dialogHeight:80px;status:no;center:yes;edge:sunken;help:no;resizable:no;scroll:no;dependent:no');
                    try {
                        if (returnValue[0] != null && returnValue[0].length > 0) {
                            //ウインドウ閉じる処理
                            g_canWindow();
                            return true;
                        } else {
                            return false;
                        }
                    } catch (e) {
                        return false;
                    }
                } else {
                    //"他にウインドウが立ち上がっています。直ちに終了して下さい"
                    window.localStorage.setItem("clsBtn", "0");
                    var returnValue = showModalDialog('Confirm.aspx?pgId=' + 'Err2', this, 'dialogWidth:350px;dialogHeight:80px;status:no;center:yes;edge:sunken;help:no;resizable:no;scroll:no;dependent:no');
                    try {
                        if (returnValue[0] != null && returnValue[0].length > 0) {
                            return false;
                        } else {
                            return false;
                        }
                    } catch (e) {
                        return false;
                    }
                    return false;
                }
            } else {
                // --------------- 2012/03/16 WT)Banno OT障害対応[OT0-0002] Add Start ---------------
                //"ログアウトします。よろしいですか？"
                var returnValue = showModalDialog('Confirm.aspx?pgId=' + 'Menu', this, 'dialogWidth:350px;dialogHeight:80px;status:no;center:yes;edge:sunken;help:no;resizable:no;scroll:no;dependent:no');
                // --------------- 2012/03/16 WT)Banno OT障害対応[OT0-0002] Add  END ---------------
                try {
                    if (returnValue[0] != null && returnValue[0].length > 0) {
                        return true;
                    } else {
                        return false;
                    }
                } catch (e) {
                    return false;
                }
            }
        } else {
            // --------------- 2012/03/16 WT)Banno OT障害対応[OT0-0002] Add Start ---------------
            //"ログアウトします。よろしいですか？"
            var returnValue = showModalDialog('Confirm.aspx?pgId=' + 'Menu', this, 'dialogWidth:350px;dialogHeight:80px;status:no;center:yes;edge:sunken;help:no;resizable:no;scroll:no;dependent:no');
            // --------------- 2012/03/16 WT)Banno OT障害対応[OT0-0002] Add  END ---------------
            try {
                if (returnValue[0] != null && returnValue[0].length > 0) {
                    return true;
                } else {
                    return false;
                }
            } catch (e) {
                return false;
            }
            return false;
        }
    } else {
        if (endProcess == "9") {
            // --------------- 2012/03/16 WT)Banno OT障害対応[OT0-0002] Add Start ---------------
            //"終了します。よろしいですか？"
            var returnValue = showModalDialog('Confirm.aspx?pgId=' + 'Login', this, 'dialogWidth:350px;dialogHeight:80px;status:no;center:yes;edge:sunken;help:no;resizable:no;scroll:no;dependent:no');
            // --------------- 2012/03/16 WT)Banno OT障害対応[OT0-0002] Add  END ---------------
            try {
                if (returnValue[0] != null && returnValue[0].length > 0) {
                    return true;
                } else {
                    return false;
                }
            } catch (e) {
                return false;
            }
        }
    }
}

function test() {
    alert('テストです');
}