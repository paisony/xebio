<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApplicationError.aspx.cs" Inherits="Common.Standard.Page.ApplicationError" %>

<%@ Register TagPrefix="uc" TagName="Footer" Src="../../pjcommon/usercontrol/FooterControl.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title id="Windowtitle" runat="server">業務エラー</title>

    <script type="text/javascript" language="javascript">
		    function Close() {
		        window.opener = true;
		        window.close();
		    }
    </script>

</head>
<body onerror="Page_Error">
    <form id="form1" runat="server" onprerender="RenderForm">
        <div>
            <table style="height: 100%" width="100%">
                <tr>
                    <td style="height: 20%; width: 20%">
                    </td>
                    <td style="width: 60%">
                    </td>
                    <td style="width: 20%">
                    </td>
                </tr>
                <tr>
                    <td style="height: 60%">
                    </td>
                    <td>
                        <table style="height: 100%" width="100%">
                            <tr>
                                <td colspan="2">
                                    <span style="font-size: 9pt; font-weight: bold; color: Blue;"><asp:Label ID="ErrorMessage" runat="server">業務エラーが発生しました。</asp:Label></span></td>
                            </tr>
                            <tr class="TR_ARTICLE">
                                <td class="TD_ARTICLE_1" style="width: 1%">
                                    &nbsp;</td>
                                <td class="TD_ARTICLE_2" style="width: 39%">
                                    <span style="font-size: 9pt"><asp:Label ID="Message" runat="server">メッセージ</asp:Label></span></td>
                                <td class="TD_ARTICLE_3" style="width: 60%">
                                    <asp:Label ID="ExceptionMessage" runat="server" Font-Size="Small"></asp:Label>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr class="TR_ARTICLE_BTN">
                                <td class="TD_ARTICLE_BTN">
                                </td>
                                <td class="TD_ARTICLE_BTN">
                                </td>
                                <td class="TD_ARTICLE_BTN">
                                    <input id="CloseBtn" type="button" value="閉じる" onclick="return Close();" class="ITEM_BUTTON" runat="server"/>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td valign="bottom" colspan="3" style="height: 20%">
                        <uc:Footer ID="footer" runat="server"></uc:Footer>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
