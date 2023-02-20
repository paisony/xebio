<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NowLoading.aspx.cs" Inherits="Common.Standard.Page.NowLoading" %>

<%@ Register TagPrefix="adv" Namespace="Common.Advanced.Web.Control" Assembly="com.xebio.bo.Common" %>
<%@ Register TagPrefix="std" Namespace="Common.Standard.Web.Control" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title id="Windowtitle" runat="server">Now Loading... </title>
    <adv:ContentType ID="ContentType1" runat="server" />
    <style type="text/css">
        .btn { visibility:hidden; }
    </style>
</head>
<body>
    <form id="form1" runat="server" onprerender="RenderForm">
        <div class="DIV_SCROLL">
            <!--- タイトル表示 --->
            <img height="5" src="../images/spacer.gif" alt="spacer" width="1" /><br />
            <table class="TABLE_PGTITLE">
                <tr>
                    <td valign="bottom" style="background-image: url(../images/pagetitle_1.gif)">
                        <img height="1" src="../images/spacer.gif" alt="spacer" width="32px" />
                    </td>
                    <td valign="bottom" style="white-space: nowrap; background-image: url(../images/pagetitle_2.gif)">
                        <asp:Label ID="Programtitle" runat="server">待ち受け画面</asp:Label>
                    </td>
                    <td valign="bottom" style="background-image: url(../images/pagetitle_3.gif)">
                        <img height="1" src="../images/spacer.gif" alt="spacer" width="32px" />
                    </td>
                    <td valign="bottom" style="width: 100%; background-image: url(../images/pagetitle_4.gif)">
                        <img height="1" src="../images/spacer.gif" alt="spacer" />
                    </td>
                    <td valign="bottom" style="background-image: url(../images/pagetitle_5.gif)">
                        <img height="1" src="../images/spacer.gif" alt="spacer" width="95px" />
                    </td>
                    <td align="right" style="width: 75px">
                    </td>
                    <!-- 戻るボタンが必要な場合はここに設置 -->
                </tr>
            </table>
            <img height="5" src="../images/spacer.gif" alt="spacer" width="1" /><br />
            <table class="TABLE_FRMTITLE">
                <tr>
                    <td>
                        <img src="../images/point.gif" alt="point" />
                    </td>
                    <td>
                        <asp:Label ID="Pagetitle" runat="server">待ち受け画面</asp:Label>
                    </td>
                    <td>
                        <img height="1" src="../images/spacer.gif" alt="spacer" width="20" />
                    </td>
                </tr>
            </table>
            <table width="100%">
                <tr>
                    <td class="TD_FRM">
                        <!-------------------------------------------------------------------
						1.カード部
						--------------------------------------------------------------------->
                        <table class="TABLE_ARTICLE">
                            <tr class="TR_ARTICLE">
                                <td class="TD_ARTICLE_3">
                                    <center>
                                        <asp:Label ID="Label1" runat="server" Text="Now Loading..." Font-Bold="True" ForeColor="Gray"></asp:Label>
                                        <asp:Button ID="ExecuteBtn" runat="server" OnClick="ExecuteBtn_Click" Text="" CssClass="btn" />
                                        <br />
                                        <img alt="Loading" src="../images/loading.gif" />
                                    </center>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
