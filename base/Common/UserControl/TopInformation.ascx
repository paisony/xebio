<%-- All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS --%>
<%-- FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
改版履歴
2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更
 --%>
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TopInformation.ascx.cs" Inherits="TopInformation" %>
<%-- 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 Start --%>
<asp:DataGrid ID="InfoList" runat="server" AutoGenerateColumns="False" ShowHeader="False" GridLines="None" BorderWidth="0px" OnItemDataBound="InfoList_ItemDataBound" CssClass="info-table">
<%-- 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 Start --%>
    <Columns>
        <asp:BoundColumn Visible="False" DataField="TOPIC_ID"></asp:BoundColumn>
        <asp:BoundColumn Visible="False" DataField="DATE_FORMAT"></asp:BoundColumn>
        <asp:BoundColumn Visible="False" DataField="NEW_DISPLAY_PERIOD"></asp:BoundColumn>
        <asp:BoundColumn Visible="False" DataField="DISPLAY_NUMBER"></asp:BoundColumn>
        <asp:BoundColumn Visible="False" DataField="DATE_DISPLAY_FLAG"></asp:BoundColumn>
        <asp:BoundColumn Visible="False" DataField="TOPIC"></asp:BoundColumn>
        <asp:BoundColumn Visible="False" DataField="DISPLAY_PERIOD"></asp:BoundColumn>
        <asp:TemplateColumn>
            <ItemTemplate>
                <asp:DataGrid ID="MessageGrid" BorderWidth="0px" GridLines="None" AutoGenerateColumns="False"
                    runat="server">
                    <Columns>
                        <%-- 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 Start --%>
                        <asp:BoundColumn Visible="False" DataField="CREATE_DATETIME"></asp:BoundColumn>
                        <asp:BoundColumn DataField="MESSAGEDATE" ItemStyle-Width="22%" ItemStyle-Font-Size="Medium"></asp:BoundColumn>
                        <asp:BoundColumn DataField="MESSAGE" ItemStyle-Font-Size="Medium"></asp:BoundColumn>
                        <%-- 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 End --%>
                    </Columns>
                </asp:DataGrid>
            </ItemTemplate>
        </asp:TemplateColumn>
    </Columns>
</asp:DataGrid>
