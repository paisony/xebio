<%-- All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS --%>
<%-- FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL --%>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SynchroStatus.aspx.cs" Inherits="System_SynchroStatus" %>

<%@ Register TagPrefix="uc" TagName="Footer" Src="../Common/Usercontrol/FooterControl.ascx" %>
<%@ Register TagPrefix="cc" Namespace="Com.Fujitsu.SmartBase.Library.WebControls"
    Assembly="Com.Fujitsu.SmartBase.Library.WebControls" %>
<html>
<head id="Head1" runat="server">
    <title>SSO設定</title>
    <%-- link css --%>
    <link title="default" href="../Common/Style/default.css" type="text/css" rel="stylesheet" />
	<script type="text/javascript" src="../Common/Js/common.js"></script>
	<script type="text/javascript" src="../Common/Js/KeySafe.js"></script>
</head>
<body>
    <form id="SolutionSetting" runat="server" onprerender="RenderForm">
        <table width="100%" height="100%">
            <tr>
                <td valign="top">
                    <%--- タイトル表示 ---%>
                    <img height="5" src="../Common/Images/spacer.gif" alt="spacer" width="1" /><br />
                    <table class="TABLE_PGTITLE">
                        <tr>
                            <td valign="bottom" style="background-image: url(../Common/Images/pagetitle_1.gif)">
                                <img height="1" src="../Common/Images/spacer.gif" alt="spacer" width="32px" />
                            </td>
                            <td valign="bottom" style="white-space: nowrap; background-image: url(../Common/Images/pagetitle_2.gif)">
                                <cc:EncodedLabel ID="Programtitle" runat="server">連携状態</cc:EncodedLabel>
                            </td>
                            <td valign="bottom" style="background-image: url(../Common/Images/pagetitle_3.gif)">
                                <img height="1" src="../Common/Images/spacer.gif" alt="spacer" width="32px" />
                            </td>
                            <td valign="bottom" style="width: 100%; background-image: url(../Common/Images/pagetitle_4.gif)">
                                <img height="1" src="../Common/Images/spacer.gif" alt="spacer" />
                            </td>
                            <td valign="bottom" style="background-image: url(../Common/Images/pagetitle_5.gif)">
                                <img height="1" src="../Common/Images/spacer.gif" alt="spacer" width="95px" />
                            </td>
                            <td align="right" style="width: 75px">
                            </td>
                            <%-- 戻るボタンが必要な場合はここに設置 --%>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td valign="top" height="100%">
                    <table width="100%" height="100%">
                        <tr>
                            <td valign="top">
                                <img height="10" src="../Common/Images/spacer.gif" alt="spacer" width="1" /><br />
                                <table class="TABLE_FRMTITLE">
                                    <tr>
                                        <td>
                                            <img src="../Common/Images/point.gif" alt="point" />
                                            <cc:EncodedLabel ID="Formtitle1" runat="server">バッチ実行状態</cc:EncodedLabel>
                                            <img height="1" src="../Common/Images/spacer.gif" alt="spacer" width="20" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" height="50%">
                               <asp:GridView ID="BatList" runat="server" AutoGenerateColumns="False" CssClass="TABLE_DG"
                                        Width="100%" OnRowDataBound="BatList_RowDataBound">
                                        <RowStyle CssClass="TR_ITEM_DG"></RowStyle>
                                        <AlternatingRowStyle CssClass="TR_ALITEM_DG" />
                                        <HeaderStyle CssClass="TR_ITEM_HEADER_DG"></HeaderStyle>
                                        <Columns>
                                            
                                            <asp:TemplateField HeaderText="前回実行日時">
                                                <ItemStyle CssClass="TD_ITEM_DG" Width="50%" />
                                                <HeaderStyle CssClass="TD_ITEM_HEADER_DG" Width="50%" />
                                                <ItemTemplate>
                                                   <cc:EncodedLabel ID="LastBatDateTime" runat="server" Text='<%# Bind("LAST_BAT_DATETIME") %>'></cc:EncodedLabel>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="実行結果">
                                                <ItemStyle CssClass="TD_ITEM_DG" Width="50%" />
                                                <HeaderStyle CssClass="TD_ITEM_HEADER_DG" Width="50%" />
                                                <ItemTemplate>
                                                   <cc:EncodedLabel ID="LastBatExitCode" runat="server" Text='<%# Bind("LAST_BAT_EXITCODE") %>'></cc:EncodedLabel>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                        </Columns>
                                    </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <img height="10" src="../Common/Images/spacer.gif" alt="spacer" width="1" /><br />
                                <table class="TABLE_FRMTITLE">
                                    <tr>
                                        <td>
                                            <img src="../Common/Images/point.gif" alt="point" />
                                            <cc:EncodedLabel ID="Formtitle2" runat="server">バッチ実行状態</cc:EncodedLabel>
                                            <img height="1" src="../Common/Images/spacer.gif" alt="spacer" width="20" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" height="50%">
                                <asp:GridView ID="SynchroList" runat="server" AutoGenerateColumns="False" CssClass="TABLE_DG"
                                        Width="100%" OnRowDataBound="SynchroList_RowDataBound">
                                        <RowStyle CssClass="TR_ITEM_DG"></RowStyle>
                                        <AlternatingRowStyle CssClass="TR_ALITEM_DG" />
                                        <HeaderStyle CssClass="TR_ITEM_HEADER_DG"></HeaderStyle>
                                        <Columns>
                                            
                                            <asp:TemplateField HeaderText="データ種別">
                                                <ItemStyle CssClass="TD_ITEM_DG" Width="50%" />
                                                <HeaderStyle CssClass="TD_ITEM_HEADER_DG" Width="50%" />
                                                <ItemTemplate>
                                                   <cc:EncodedLabel ID="DataType" runat="server" Text='<%# Bind("DATA_TYPE") %>'></cc:EncodedLabel>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField HeaderText="同期日時">
                                                <ItemStyle CssClass="TD_ITEM_DG" Width="50%" />
                                                <HeaderStyle CssClass="TD_ITEM_HEADER_DG" Width="50%" />
                                                <ItemTemplate>
                                                   <cc:EncodedLabel ID="SynchroDateTime" runat="server" Text='<%# Bind("SYNCHRO_DATETIME") %>'></cc:EncodedLabel>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                        </Columns>
                                    </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td valign="bottom">
                    <uc:Footer ID="footer2" runat="server"></uc:Footer>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
