<%-- All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS --%>
<%-- FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL --%>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginUser01.aspx.cs" Inherits="UserMst_UserMst" %>

<%@ Register TagPrefix="uc" TagName="Footer" Src="../Common/Usercontrol/FooterControl.ascx" %>
<%@ Register TagPrefix="cc" Namespace="Com.Fujitsu.SmartBase.Library.WebControls"
	Assembly="Com.Fujitsu.SmartBase.Library.WebControls" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<title>���p�ҊǗ�</title>
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
				<%--- �^�C�g���\�� ---%>
				<img height="5" src="../Common/Images/spacer.gif" alt="spacer" width="1" /><br />
				<table class="TABLE_PGTITLE">
					<tr>
						<td valign="bottom" style="background-image: url(../Common/Images/pagetitle_1.gif)">
							<img height="1" src="../Common/Images/spacer.gif" alt="spacer" width="32px" />
						</td>
						<td valign="bottom" style="white-space: nowrap; background-image: url(../Common/Images/pagetitle_2.gif)">
							<cc:EncodedLabel ID="Programtitle" runat="server">���p�ҊǗ�</cc:EncodedLabel>
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
						<%-- �߂�{�^�����K�v�ȏꍇ�͂����ɐݒu --%>
					</tr>
				</table>
				<img height="10" src="../Common/Images/spacer.gif" alt="spacer" width="1" /><br />
				<table class="TABLE_FRMTITLE">
					<tr>
						<td>
							<img src="../Common/Images/point.gif" alt="point" />
							<cc:EncodedLabel ID="Formtitle" runat="server">���p�ҏ��ꗗ</cc:EncodedLabel>
							<img height="1" src="../Common/Images/spacer.gif" alt="spacer" width="20" />
						</td>
					</tr>
				</table>
				<table width="100%">
					<tr>
						<td class="TD_FRM">
							<%--- Web �y�[�W��ɂ��邷�ׂĂ̌��؃R���g���[�����瓾��ꂽ�G���[ ���b�Z�[�W���܂Ƃ߂ĕ\���ł��܂� ---%>
							<asp:ValidationSummary ID="ValidationSummary1" runat="server"></asp:ValidationSummary>
							<cc:EncodedLabel ID="BusinessErrorMessage" runat="server" Visible="False" ForeColor="Red"></cc:EncodedLabel>
							<%--- Web �y�[�W��̌��؃R���g���[�� ---%>
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
										    1.�J�[�h��
										    ---------------------------------------------------------------------%>
							<table class="TABLE_ARTICLE">
								<tr class="TR_ARTICLE">
									<td class="TD_ARTICLE_1">
										&nbsp;
									</td>
									<td class="TD_ARTICLE_2" width="30%">
										<cc:EncodedLabel ID="LoginIdLbl" runat="server">���O�C��ID</cc:EncodedLabel><span class="MUST_MERK"></span>
									</td>
									<td class="TD_ARTICLE_3" width="70%">
										<%--- �u���O�C��id1�v��s�e�L�X�g�{�b�N�X�i�Z�p���[�g���t�ȊO�j ---%>
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
										<cc:EncodedLabel ID="UsernameLbl" runat="server">���p�Җ�</cc:EncodedLabel><span class="MUST_MERK"></span>
									</td>
									<td class="TD_ARTICLE_3">
										<%--- �u���O�v��s�e�L�X�g�{�b�N�X�i�Z�p���[�g���t�ȊO�j ---%>
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
										<cc:EncodedLabel ID="CompanyLbl" runat="server">���</cc:EncodedLabel><span class="MUST_MERK"></span>
									</td>
									<td class="TD_ARTICLE_3">
										<%--- �u��Ёv��s�e�L�X�g�{�b�N�X�i�Z�p���[�g���t�ȊO�j ---%>
										<asp:DropDownList ID="CompanyDrop" runat="server">
										</asp:DropDownList>
									</td>
								</tr>
							</table>
							<table class="TABLE_ARTICLE" width="100%">
								<tr class="TR_ARTICLE_BTN">
									<td class="TD_ARTICLE_BTN" width="30%">
										<asp:Button ID="AddBtn" runat="server" Text="�V�K�o�^" CausesValidation="False" OnClick="AddBtn_Click" />
									</td>
									<td class="TD_ARTICLE_BTN">
										&nbsp;
									</td>
									<td class="TD_ARTICLE_BTN" style="width: 57%">
										<%--- �u�{�^�������v�{�^�� ---%>
										<asp:Button ID="SearchBtn" runat="server" OnClick="SearchBtn_Click" Text="����" />
									</td>
									<td class="TD_ARTICLE_BTN" width="13%">
										<%--- �u�{�^�������v�{�^�� ---%>
										<asp:Button ID="UploadBtn" runat="server" OnClick="UploadBtn_Click" Text="�ꊇ�A�b�v���[�h" />
									</td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td height="100%" valign="top">
							<%-------------------------------------------------------------------
										    2.���ו�
										    ---------------------------------------------------------------------%>
							<div id="Div1" class="LAYER" style="border: solid 1px #7e8b94; height: 100%; overflow: auto;">
								<asp:GridView ID="M1" runat="server" AutoGenerateColumns="False" CssClass="TABLE_DG"
									Width="100%" OnRowCommand="M1_RowCommand" OnRowDataBound="M1_RowDataBound">
									<RowStyle CssClass="TR_ITEM_DG"></RowStyle>
									<AlternatingRowStyle CssClass="TR_ALITEM_DG" />
									<HeaderStyle CssClass="TR_ITEM_HEADER_DG"></HeaderStyle>
									<Columns>
										<asp:TemplateField HeaderText="���">
											<HeaderStyle CssClass="TD_ITEM_HEADER_DG" Width="30%"></HeaderStyle>
											<ItemStyle CssClass="TD_ITEM_DG" HorizontalAlign="Left"></ItemStyle>
											<ItemTemplate>
												<%--- �u��Ёv��s�e�L�X�g�{�b�N�X�i�Z�p���[�g���t�ȊO�j ---%>
												&nbsp;<cc:EncodedLabel ID="GridCompanyLbl" runat="server"></cc:EncodedLabel>
											</ItemTemplate>
										</asp:TemplateField>
										<asp:TemplateField HeaderText="���O�C��ID">
											<HeaderStyle CssClass="TD_ITEM_HEADER_DG" Width="30%"></HeaderStyle>
											<ItemStyle CssClass="TD_ITEM_DG" HorizontalAlign="Left"></ItemStyle>
											<ItemTemplate>
												<%--- �u���O�C��id�v���x�� ---%>
												&nbsp;<cc:EncodedLabel ID="GridLoginIDLbl" runat="server" Text='<%# Bind("LOGIN_ID") %>'></cc:EncodedLabel>
											</ItemTemplate>
										</asp:TemplateField>
										<asp:TemplateField HeaderText="���p�Җ�">
											<HeaderStyle CssClass="TD_ITEM_HEADER_DG" Width="40%"></HeaderStyle>
											<ItemStyle CssClass="TD_ITEM_DG" HorizontalAlign="Left"></ItemStyle>
											<ItemTemplate>
												<%--- �u���p�Җ��v��s�e�L�X�g�{�b�N�X�i�Z�p���[�g���t�ȊO�j ---%>
												&nbsp;<cc:EncodedLabel ID="GridUsernameLbl" runat="server" Text='<%# Bind("NAME") %>'></cc:EncodedLabel>
											</ItemTemplate>
										</asp:TemplateField>
										<asp:ButtonField ButtonType="Button" HeaderText="�ҏW" Text="�ҏW" CommandName="EditRow">
											<ItemStyle CssClass="TD_ITEM_DG" HorizontalAlign="Center" />
											<HeaderStyle CssClass="TD_ITEM_HEADER_DG" />
										</asp:ButtonField>
										<asp:ButtonField ButtonType="Button" HeaderText="�폜" Text="�폜" CommandName="DeleteRow">
											<ItemStyle CssClass="TD_ITEM_DG" HorizontalAlign="Center" />
											<HeaderStyle CssClass="TD_ITEM_HEADER_DG" />
										</asp:ButtonField>
										<asp:ButtonField ButtonType="Button" HeaderText="���[��" Text="�ݒ�" CommandName="RoleRow">
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
							<%--- �u�y�[�W���[�v�J�X�^���y�[�W���[ ---%>
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
