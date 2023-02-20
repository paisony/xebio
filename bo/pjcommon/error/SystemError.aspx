<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SystemError.aspx.cs" Inherits="Common.Standard.Page.SystemError" %>

<%@ Register TagPrefix="uc" TagName="Footer" Src="../../pjcommon/usercontrol/FooterControl.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">
<head runat="server">
    <title id="Windowtitle" runat="server">システムエラー</title>
    <link title="default" href="../../pjcommon/boStyle/base.css" type="text/css" rel="stylesheet" charset="UTF-8" />

    <script type="text/javascript" language="javascript">
        function Close() {
            window.opener = true;
            window.close();
        }
        function checkExpand(ch) {
            var obj = document.all && document.all(ch) || document.getElementById && document.getElementById(ch);
            if (obj && obj.style) {
                obj.style.display = "none" == obj.style.display ? "" : "none";
            }
        }
    </script>

</head>
<body onerror="Page_Error">
    <form id="form1" runat="server" onprerender="RenderForm">
        <div>
            <table style="height: 100%;background:#ffffff;" width="100%" id="str-search-01" >
                <colgroup>
                    <col style="width: 20%" />
                    <col style="width: 60%" />
                    <col style="width: 20%" />
                    <col />
                </colgroup>
                <tbody>
                    <tr>
                                <tr>
                                    <td colspan="3" style="height:60px;">
                                    </td>
                                </tr>
                        <td style="height: 60%"></td>
                        <td>
                            <table style="height: 100%" width="100%" class="inner-02">
                <colgroup>
                    <col style="width: 110px" />
                    <col />
                    <col />
                </colgroup>
                <tbody>
                                <tr>
                                    <td colspan="2">
                                        <span id="error-01" style="display:block;">
                                            <asp:Label ID="ErrorMessage" runat="server">エラーが発生しました。</asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="last"><span class="tbl-hdg"><asp:Label ID="Exception" runat="server">例外</asp:Label></span></th>
                                    <td class="last">
                                        <asp:Label ID="ExceptionName" runat="server" Font-Size="Small"></asp:Label>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <th class="last"><span class="tbl-hdg">
                                            <asp:Label ID="Label1" runat="server">発生時刻</asp:Label></span></span></th>
                                    <td class="last">
                                        <asp:Label ID="OccuredTime" runat="server" Font-Size="Small"></asp:Label>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <th class="last"><span class="tbl-hdg">
                                            <asp:Label ID="Label3" runat="server">エラーコード</asp:Label></span></span></th>
                                    <td class="last">
                                        <asp:Label ID="ErrCode" runat="server" Font-Size="Small"></asp:Label>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <th class="last"><span class="tbl-hdg">
                                            <asp:Label ID="Message" runat="server">メッセージ</asp:Label></span></span></th>
                                    <td class="last">
                                        <asp:Label ID="ExceptionMessage" runat="server" Font-Size="Small"></asp:Label>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="height:20px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                <div class="str-btn-search" style="width:100%;text-align:center;">
                                    <a id="CloseBtn" class="btn type-01" onclick="return Close();">閉じる</a>
                                <!-- /str-btn-search --></div>
                                    </td>
                                </tr>
                </tbody>
                            </table>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td valign="bottom" colspan="3" style="height: 20%">
                            <uc:Footer ID="footer" runat="server"></uc:Footer>
                        </td>
                    </tr>

                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
