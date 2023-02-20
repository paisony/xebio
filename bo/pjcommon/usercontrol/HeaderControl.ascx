<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HeaderControl.ascx.cs" Inherits="Common.Standard.Page.HeaderControl" %>
<%@ Register TagPrefix="uc" TagName="Message" Src="~/pjcommon/usercontrol/MessageControl.ascx" %>
<script type="text/javascript" language="javascript">

    function endProcess() {
        var openWindow;
        lock_screen();

        if ($("#header_CLSMSGFLAG").get(0).value != "1") {
            urlmess = "<%# mess %>";
            //画面中央に配置するために余白を求める
            var w = (screen.width - 280) / 2;
            var h = (screen.height - 80) / 2;
            var option = "top=" + h + ", left=" + w + ", height=" + 80 + ", width=" + 280 + ", menubar=no" + ", toolbar=no" + ", location=no" + ", status=no" + ", resizable=no" + ", scrollbars=no" + ", directories=no";

            try {
                window[$("#header_PGMID").get(0).value] = function (returnValue) {
                    if (returnValue[0] != null && returnValue[0].length > 0) {
                        EndProgramWindowClose($("#header_PGMID").get(0).value);
                        window.close();
                    }
                    else {
                        // ロックするdivを削除
                        delete_dom_obj('screenLock');
                        return false;
                    }
                }

                openWindow =  window.open('../pjcommon/mdAspx/Confirm.aspx?pgId=' + $("#header_PGMID").get(0).value + '&mess=' + urlmess
                    , '_blank', option);

            } catch (e) {
                return false;
            }
        } else {
            window.close();
        }

        // 子画面が開いている場合、子画面にフォーカスする
        var interval = setInterval(function ()
        {
            if (!openWindow || openWindow.closed) {
                clearInterval(interval);
            }
            else
            {
                if (!openWindow.document.hasFocus())
                {
                    openWindow.focus();
                }
            }

        }, 500);
    }

    // 画面ロック
    function lock_screen() {
        //　自画面をロックするdivを生成
        var element = document.createElement('div');
        element.id = 'screenLock';
        element.style.height = '100%';
        element.style.left = '0px';
        element.style.position = 'fixed';
        element.style.top = '0px';
        element.style.width = '100%';
        element.style.zIndex = '9999';
        element.style.opacity = '0';
        var objBody = document.getElementsByTagName("body").item(0);
        objBody.appendChild(element);
    }

    // div削除
    function delete_dom_obj(id_name) {
        var dom_obj = document.getElementById(id_name);
        var dom_obj_parent = dom_obj.parentNode;
        dom_obj_parent.removeChild(dom_obj);
    }
    if (window.onhelp !== undefined) window.onhelp = function () { return false; }

</script>
<div id="HIDE_PANEL" style="width:100%; height:649px; position:fixed; top:0px; left:0px; background-color:transparent; z-index:999;">
</div>
<div id="header" style="background-color:#1ca7e0;">
    <p class="logo" style="width:109px;">
        <asp:Image ID="PIC" runat="server" ImageUrl="~/pjcommon/boImages/logo.png" AlternateText="XEBIO" Style="width: 109px; height: 36px;" />
        <asp:Literal ID="DBUser" runat="server" Visible="false" />
    </p>
    <div id="menu-btn">
        <p>
            <a href="javascript:void(0);">
                <img src="../pjcommon/boImages/short_cut_menu_off.png" width="36" height="36" alt="メニュー開閉ボタン"></a>
        </p>
    </div>
    <div id="menu-btn2">
    </div>
    <div class="inner">
        <div class="header-utility-01">
            <h1 class="hdg-lv1-01">
                <asp:Literal ID="FormNameLiteral" runat="server" />
                <asp:Panel ID="Mode" runat="server">
                    <span id="modeCaption"><asp:Literal ID="ModeCaption" runat="server" Text="モード：" /></span>
                    <span id="modeText"><asp:Literal ID="ModeText" runat="server" /></span>
                </asp:Panel>
            </h1>
        </div>
        <div class="header-utility-02">
            <p class="tenpo-keitai">
                <asp:Literal ID="Tenpokeitai_kb" runat="server" />
            </p>
            <p class="admin-name">
                <asp:Literal ID="LoginTanCd" runat="server" />
                <asp:Literal ID="LoginUserNameLiteral" runat="server" />
            </p>
            <p class="time">
                <span style="font-size: 12px;" id="clockdate"></span>
                <span style="font-size: 12px;" id="clocktime"></span>
            </p>
            <p class="btn-logout">
                <asp:Button ID="Button1" runat="server" CssClass="btn"
                    Style="background: #ffffff url(../pjcommon/boImages/icon-logout.png) no-repeat 0 0;background-size:contain;margin: 0 !important; width: 32px; height: 30px;"
                        UseSubmitBehavior="false" OnClientClick="endProcess();return false;"></asp:Button>
            </p>
            <input id="hiddenButtonYes" type="button" style="display:none"/>
            <input id="hiddenButtonNo" type="button" style="display:none"/>
            <!-- /header-utility-02 -->
        </div>
        <!-- /inner -->
    </div>
</div>
<!-- /header -->
<asp:HiddenField ID="COPCD" runat="server" />
<asp:HiddenField ID="TTSCD" runat="server" />
<asp:HiddenField ID="TNPCD" runat="server" />
<asp:HiddenField ID="LOGINID" runat="server" />
<asp:HiddenField ID="PGMID" runat="server" />
<asp:HiddenField ID="EXECERROR" runat="server" />
<asp:HiddenField ID="EXECERRORID" runat="server" />
<asp:HiddenField ID="BASEWEBNAME" runat="server" />
<asp:HiddenField ID="CLSMSGFLAG" runat="server" />

<!--- メッセージ表示 --->
<uc:Message ID="message1" runat="server"></uc:Message>
<asp:HiddenField ID="downloadFlag" Value="1" runat="server" />
<asp:HiddenField ID="focusFlag" Value="1" runat="server" />
<!--- 検索条件の保存用に追加 --->
<asp:HiddenField ID="searchContent" Value="" runat="server" />
<asp:HiddenField ID="searchContentResetFlg" Value="" runat="server" />
<div id="CustomizeContextMenu"></div>
<iframe id="menu-frame"></iframe>
<p id="error-01" style="display: none;" onclick="openErrorWindow()">エラーがあります。</p>
