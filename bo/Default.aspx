<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="advoutput_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>ダミーメニュー</title>
            <script language="JavaScript">
                function windowOpen(id, param2) {
                    //画面起動
                    window.open('./' + id + '/' + id + 'Init.aspx', id, 'left=0, top=0, width=1264, height=660, directiories=no, location=no, menubar=no, scrollbars=yes, status=yes, toolbar=no, resizable=yes');
                }
                setTimeout("location.reload()", 60000);
        </script>
</head>
<body>
    <form id="form1" runat="server">
        <table border=1>
            <colgroup>
                <col width="500px" style="vertical-align:top;" />
                <col width="500px"  />
            </colgroup>
            <tr><td style="vertical-align:top;">
				<input type="text" id="kengen" value="1" runat="server" /> 権限(1:本部、2:店長、3:一般、4:アルバイト)
            </td></tr>
            <tr><td style="vertical-align:top;">
            
                <table>
                    <asp:Repeater ID="RepeaterInfo" runat="server">
                        <ItemTemplate>
                    <tr><td>
                        <a href="javascript:void(windowOpen('<%# Server.HtmlEncode(((MenuVo)Container.DataItem).PgId) %>'));"><%# Server.HtmlEncode(((MenuVo)Container.DataItem).PgId) %>　<%# Server.HtmlEncode(((MenuVo)Container.DataItem).PgName) %></a></td></tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </td></tr>
        </table>
    </form>
</body>
</html>
