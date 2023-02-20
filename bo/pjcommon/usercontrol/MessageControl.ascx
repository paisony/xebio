<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MessageControl.ascx.cs" Inherits="Common.Standard.Page.MessageControl" %>
<%@ Register TagPrefix="adv" Namespace="Common.Advanced.Web.Control" assembly="com.xebio.bo.Common"%>
<%@ Import Namespace="Common.Standard.Message" %>
<script type="text/javascript">
<%# clientScript %>
</script>
<asp:BulletedList ID="MessageList" Visible="false" runat="server"></asp:BulletedList>
<asp:Image ID="Image1" runat="server" Height="15px" ImageUrl="../images/u009ani.gif" Visible="false" Width="15px" />
<asp:Label ID="MessageLbl" Visible="false" runat="server"></asp:Label>
<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../images/Warning.gif" OnClientClick="openErrorDialog(); return false;" Visible="false" />
<div id="MessageListDiv" visible="false" runat="server" class="ERR_MSG">
<asp:TextBox ID="MessageTextBox" Visible="false" runat="server"></asp:TextBox>
<asp:ListBox ID="MessageListBox" Visible="false" runat="server" Rows="3"></asp:ListBox>
</div>
<table id="MessageTable" visible="false" runat="server" cellspacing="0" border="1" class="MSG_TBL_1"><tr><td>
	<div id="MessageDiv" runat="server" class="MSG_DIV">
		<table cellspacing="0" border="0" class="MSG_TBL_2">
			<tr>
				<td style="white-space: nowrap;">
					<asp:Repeater ID="Repeater1" runat="server" OnItemCreated="Repeater1_ItemCreated">
						<ItemTemplate>
							<asp:Label ID="Message" runat="server" Text="<%# Server.HtmlEncode(((MessageInfoVO)Container.DataItem).Message) %>"></asp:Label></br>
						</ItemTemplate>
					</asp:Repeater>
				</td>
			</tr>
		</table>
	</div>
</td></tr></table>
<%--Web ページ上にあるすべての検証コントロールから得られたエラー メッセージをまとめて表示できます--%>
<asp:ValidationSummary ID="ValidationSummary1" Visible="False" runat="server"></asp:ValidationSummary>
<%--Web ページ上の検証コントロール--%>
<adv:AdvancedValidator id="Validator" enableclientscript="False" display="None" runat="server"></adv:AdvancedValidator>