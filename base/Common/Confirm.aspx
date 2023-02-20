<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Confirm.aspx.cs" Inherits="Common_Confirm" %>

<%--
	改版履歴
	2012/03/16 WT)Banno OT障害対応[OT0-0002]
    2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更
--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title id="Windowtitle" runat="server"></title>
    <style type="text/css">
        div#nestedblock {
            width: 80%;
            display: block;
            margin: auto;
        }

            div#nestedblock p {
                display: block;
                width: 90%;
                margin: auto
            }
    </style>
    <!-- link css -->
    <script type="text/javascript" language="javascript">
        function OK() {
            endProgramIdReturn = "<%# pgId %>";
            var arge = new Array();
            arge[0] = "<%# pgId %>";
            window.returnValue = arge;
            window.close();
            return false;
        }
        function CANCEL() {
            var arge = new Array();
            window.returnValue = arge;
            window.close();
            return false;
        }
    </script>
</head>
<body style="width: 99%; height: 99%;" bgcolor="linen">
    <form id="form1" runat="server" onprerender="RenderForm">
        <div id="confirm" style="width: 350px; height: 80px;">
            <table cellspacing="0" cellpadding="0" width="350px" border="0">
                <tr>
                    <td valign="middle" align="left" style="height: 50px">
                        <asp:Image ID="markimage" runat="server" ImageAlign="left" Style="width: 30px" Height="30px"></asp:Image>
                    </td>
                    <td valign="middle" align="left" style="font-size: smaller">
                        <asp:Literal ID="message" runat="server" />
                    </td>
                </tr>
                <tr style="height: 20px">
                </tr>
            </table>
            <%-- ボタン --%>
            <%-- --------------- 2012/03/16 WT)Banno OT障害対応[OT0-0002] Add Start --------------- --%>
            <!-- 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 Start -->
            <div style="text-align: center;">
                <!-- 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 End -->
                <table cellspacing="0" cellpadding="0" width="350px" border="0">
                    <tr>
                        <td>
                            <input name="Input" type="button" style="font-size: smaller; padding: 1px 10px; text-align: center; width: 90px" id="button1" onclick="OK();" runat="server" />
                            <input name="Input" type="button" style="font-size: smaller; padding: 1px 10px; text-align: center; width: 90px" id="button2" onclick="CANCEL();" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <%-- --------------- 2012/03/16 WT)Banno OT障害対応[OT0-0002] Add  End ---------------- --%>
    </form>
</body>
</html>
