<%-- All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS --%>
<%-- FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL --%>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginUser01.aspx.cs" Inherits="UserMst_UserMst" %>

<%@ Register TagPrefix="uc" TagName="Footer" Src="../Common/Usercontrol/FooterControl.ascx" %>
<%@ Register TagPrefix="cc" Namespace="Com.Fujitsu.SmartBase.Library.WebControls"
	Assembly="Com.Fujitsu.SmartBase.Library.WebControls" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<title>利用者管理</title>
	<%-- link css --%>
	<link title="default" href="../Common/Style/default.css" type="text/css" rel="stylesheet" />
	<script type="text/javascript" src="../Common/Js/common.js"></script>
	<script type="text/javascript" src="../Common/Js/KeySafe.js"></script>
</head>
<body>
	<form id="LoginUser01" runat="server" onprerender="RenderForm">
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
							<cc:EncodedLabel ID="Programtitle" runat="server">利用者管理</cc:EncodedLabel>
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
				<img height="10" src="../Common/Images/spacer.gif" alt="spacer" width="1" /><br />
				<table class="TABLE_FRMTITLE">
					<tr>
						<td>
							<img src="../Common/Images/point.gif" alt="point" />
							<cc:EncodedLabel ID="Formtitle" runat="server">利用者情報一覧</cc:EncodedLabel>
							<img height="1" src="../Common/Images/spacer.gif" alt="spacer" width="20" />
						</td>
					</tr>
				</table>
				<table width="100%">
					<tr>
						<td class="TD_FRM">
							<%--- Web ページ上にあるすべての検証コントロールから得られたエラー メッセージをまとめて表示できます ---%>
							<asp:ValidationSummary ID="ValidationSummary1" runat="server"></asp:ValidationSummary>
							<cc:EncodedLabel ID="BusinessErrorMessage" runat="server" Visible="False" ForeColor="Red"></cc:EncodedLabel>
							<%--- Web ページ上の検証コントロール ---%>
						</td>
					</tr>
				</table>
			</td>
		</tr>
		<tr>
			<td height="100%" valign="top">
				<table width="100%" height="100%">
					<tr>
						<td class="TD_FRM" valign="top">
							<%-------------------------------------------------------------------
										    1.カード部
										    ---------------------------------------------------------------------%>
							<table class="TABLE_ARTICLE">
								<tr class="TR_ARTICLE">
									<td class="TD_ARTICLE_1">
										&nbsp;
									</td>
									<td class="TD_ARTICLE_2" width="30%">
										<cc:EncodedLabel ID="LoginIdLbl" runat="server">ログインID</cc:EncodedLabel><span class="MUST_MERK"></span>
									</td>
									<td class="TD_ARTICLE_3" width="70%">
										<%--- 「ログインid1」一行テキストボックス（セパレート日付以外） ---%>
										<asp:TextBox ID="LoginIdBox" Columns="20" CssClass="TEXT_L" runat="server" MaxLength="20"></asp:TextBox>
										<asp:Label ID="LoginIdInvalidCharValid" runat="server" Text=''></asp:Label>
										&nbsp; &nbsp;
									</td>
								</tr>
								<tr class="TR_ARTICLE">
									<td class="TD_ARTICLE_1">
										&nbsp;
									</td>
									<td class="TD_ARTICLE_2">
										<cc:EncodedLabel ID="UsernameLbl" runat="server">利用者名</cc:EncodedLabel><span class="MUST_MERK"></span>
									</td>
									<td class="TD_ARTICLE_3">
										<%--- 「名前」一行テキストボックス（セパレート日付以外） ---%>
										<asp:TextBox ID="UsernameBox" Columns="40" CssClass="TEXT_L" runat="server" Font-Italic="False"
											MaxLength="20"></asp:TextBox>
										<asp:Label ID="UserNameInvalidCharValid" runat="server" Text=''></asp:Label>
										&nbsp; &nbsp; &nbsp;&nbsp;
									</td>
								</tr>
								<tr class="TR_ARTICLE">
									<td class="TD_ARTICLE_1">
										&nbsp;
									</td>
									<td class="TD_ARTICLE_2">
										<cc:EncodedLabel ID="CompanyLbl" runat="server">会社</cc:EncodedLabel><span class="MUST_MERK"></span>
									</td>
									<td class="TD_ARTICLE_3">
										<%--- 「会社」一行テキストボックス（セパレート日付以外） ---%>
										<asp:DropDownList ID="CompanyDrop" runat="server">
										</asp:DropDownList>
									</td>
								</tr>
							</table>
							<table class="TABLE_ARTICLE" width="100%">
								<tr class="TR_ARTICLE_BTN">
									<td class="TD_ARTICLE_BTN" width="30%">
										<asp:Button ID="AddBtn" runat="server" Text="新規登録" CausesValidation="False" OnClick="AddBtn_Click" />
									</td>
									<td class="TD_ARTICLE_BTN">
										&nbsp;
									</td>
									<td class="TD_ARTICLE_BTN" style="width: 57%">
										<%--- 「ボタン検索」ボタン ---%>
										<asp:Button ID="SearchBtn" runat="server" OnClick="SearchBtn_Click" Text="検索" />
									</td>
									<td class="TD_ARTICLE_BTN" width="13%">
										<%--- 「ボタン検索」ボタン ---%>
										<asp:Button ID="UploadBtn" runat="server" OnClick="UploadBtn_Click" Text="一括アップロード" />
									</td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td height="100%" valign="top">
							<%-------------------------------------------------------------------
										    2.明細部
										    ---------------------------------------------------------------------%>
							<div id="Div1" class="LAYER" style="border: solid 1px #7e8b94; height: 100%; overflow: auto;">
								<asp:GridView ID="M1" runat="server" AutoGenerateColumns="False" CssClass="TABLE_DG"
									Width="100%" OnRowCommand="M1_RowCommand" OnRowDataBound="M1_RowDataBound">
									<RowStyle CssClass="TR_ITEM_DG"></RowStyle>
									<AlternatingRowStyle CssClass="TR_ALITEM_DG" />
									<HeaderStyle CssClass="TR_ITEM_HEADER_DG"></HeaderStyle>
									<Columns>
										<asp:TemplateField HeaderText="会社">
											<HeaderStyle CssClass="TD_ITEM_HEADER_DG" Width="30%"></HeaderStyle>
											<ItemStyle CssClass="TD_ITEM_DG" HorizontalAlign="Left"></ItemStyle>
											<ItemTemplate>
												<%--- 「会社」一行テキストボックス（セパレート日付以外） ---%>
												&nbsp;<cc:EncodedLabel ID="GridCompanyLbl" runat="server"></cc:EncodedLabel>
											</ItemTemplate>
										</asp:TemplateField>
										<asp:TemplateField HeaderText="ログインID">
											<HeaderStyle CssClass="TD_ITEM_HEADER_DG" Width="30%"></HeaderStyle>
											<ItemStyle CssClass="TD_ITEM_DG" HorizontalAlign="Left"></ItemStyle>
											<ItemTemplate>
												<%--- 「ログインid」ラベル ---%>
												&nbsp;<cc:EncodedLabel ID="GridLoginIDLbl" runat="server" Text='<%# Bind("LOGIN_ID") %>'></cc:EncodedLabel>
											</ItemTemplate>
										</asp:TemplateField>
										<asp:TemplateField HeaderText="利用者名">
											<HeaderStyle CssClass="TD_ITEM_HEADER_DG" Width="40%"></HeaderStyle>
											<ItemStyle CssClass="TD_ITEM_DG" HorizontalAlign="Left"></ItemStyle>
											<ItemTemplate>
												<%--- 「利用者名」一行テキストボックス（セパレート日付以外） ---%>
												&nbsp;<cc:EncodedLabel ID="GridUsernameLbl" runat="server" Text='<%# Bind("NAME") %>'></cc:EncodedLabel>
											</ItemTemplate>
										</asp:TemplateField>
										<asp:ButtonField ButtonType="Button" HeaderText="編集" Text="編集" CommandName="EditRow">
											<ItemStyle CssClass="TD_ITEM_DG" HorizontalAlign="Center" />
											<HeaderStyle CssClass="TD_ITEM_HEADER_DG" />
										</asp:ButtonField>
										<asp:ButtonField ButtonType="Button" HeaderText="削除" Text="削除" CommandName="DeleteRow">
											<ItemStyle CssClass="TD_ITEM_DG" HorizontalAlign="Center" />
											<HeaderStyle CssClass="TD_ITEM_HEADER_DG" />
										</asp:ButtonField>
										<asp:ButtonField ButtonType="Button" HeaderText="ロール" Text="設定" CommandName="RoleRow">
											<ItemStyle CssClass="TD_ITEM_DG" HorizontalAlign="Center" />
											<HeaderStyle CssClass="TD_ITEM_HEADER_DG" />
										</asp:ButtonField>
									</Columns>
								</asp:GridView>
							</div>
						</td>
					</tr>
					<tr>
						<td align="right">
							<%--- 「ページャー」カスタムページャー ---%>
							<cc:Pager ID="Pager" runat="server" CurrentPageIndex="0" PageSize="20" Font-Size="11pt"
								NextText="Next >>" OnPageIndexChanged="Pager_PageIndexChanged" PrevText="<< Back"
								VirtualItemCount="0"></cc:Pager>
						</td>
					</tr>
					<tr>
						<td valign="bottom">
							<uc:Footer ID="footer" runat="server"></uc:Footer>
						</td>
					</tr>
				</table>
			</td>
		</tr>
	</table>
	</form>
</body>
</html>
