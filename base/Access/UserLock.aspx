<%-- All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS --%>
<%-- FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
改版履歴
2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更
 --%>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserLock.aspx.cs" Inherits="Access_UserLock" %>

<%@ Register TagPrefix="uc" TagName="Footer" Src="../Common/Usercontrol/FooterControl.ascx" %>
<%@ Register TagPrefix="cc" Namespace="Com.Fujitsu.SmartBase.Library.WebControls"
    Assembly="Com.Fujitsu.SmartBase.Library.WebControls" %>
<html>
<head id="Head1" runat="server">
    <title>アクセス管理</title>
    <%-- link css --%>
    <link title="default" href="../Common/Style/default.css" type="text/css" rel="stylesheet" />
	<script type="text/javascript" src="../Common/Js/common.js"></script>
	<script type="text/javascript" src="../Common/Js/KeySafe.js"></script>
</head>
<body>
    <form id="Lock" runat="server" onprerender="RenderForm">
        <table width="100%">
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
                                <cc:EncodedLabel ID="Programtitle" runat="server">アクセス管理</cc:EncodedLabel>
                            </td>
                            <td valign="bottom" style="background-image: url(../Common/Images/pagetitle_3.gif)">
                                <img height="1" src="../Common/Images/spacer.gif" alt="spacer" width="32px" />
                            </td>
                            <td valign="bottom" style="width: 100%; background-image: url(../Common/Images/pagetitle_4.gif)" align="right">
                                <img height="1" src="../Common/Images/spacer.gif" alt="spacer" />
                            </td>
                            <td style="width: 75px;text-align:right;">
                                <asp:Button ID="BackBtn" runat="server" OnClick="BackBtn_Click" CausesValidation="False" />
                            </td>
                            <%-- 戻るボタンが必要な場合はここに設置 --%>
                        </tr>
                    </table>
                    <img height="10" src="../Common/Images/spacer.gif" alt="spacer" width="1" /><br />
                    <table class="TABLE_FRMTITLE">
                        <tr>
                            <td>
                                <img src="../Common/Images/point.gif" alt="point" />
                                <cc:EncodedLabel ID="Formtitle" runat="server">利用者ロック状態管理</cc:EncodedLabel>
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
                <td valign="top">
                    <table width="100%">
                        <tr>
                            <td class="TD_FRM" valign="top">
                                <%-------------------------------------------------------------------
										    1.カード部
										    ---------------------------------------------------------------------%>
                                <!-- 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 Start -->
                                <div class="str-search-01">
					                <div class="inner-02">
						                <div class="str-form-02">
							                <div class="inner">
								                <table width="100%">
									                <colgroup>
										                <col class="w-type-01">
										                <col class="w-type-02">
									                </colgroup>
									                <tr>
										                <th scope="col" width="10%">
											                <span class="tbl-hdg">
												                <cc:EncodedLabel ID="LoginIdLbl" runat="server">ログインID</cc:EncodedLabel>
											                </span>
										                </th>
										                <td>
											                <asp:TextBox ID="LoginIdBox" Columns="18" CssClass="inpSerch" runat="server" MaxLength="10" Height="100%"></asp:TextBox>
											                <asp:Label ID="LoginIdInvalidCharValid" runat="server" Text=''></asp:Label>
										                </td>
									                </tr>
									                <tr>
										                <th scope="col">
                                                            <span class="tbl-hdg">
                                                                <cc:EncodedLabel ID="UsernameLbl" runat="server">利用者名</cc:EncodedLabel>
                                                            </span>
										                </th>
										                <td>
											                <asp:TextBox ID="UsernameBox" Columns="18" CssClass="inpSerch" runat="server" Font-Italic="False" MaxLength="20" Height="100%"></asp:TextBox>
											                <asp:Label ID="UserNameInvalidCharValid" runat="server" Text=''></asp:Label>
										                </td>
									                </tr>
									                <tr>
										                <th scope="col">
											                <span class="tbl-hdg">
												                <cc:EncodedLabel ID="CompanyLbl" runat="server">会社</cc:EncodedLabel>
											                </span>
										                </th>
										                <td>
											                <asp:DropDownList ID="CompanyDrop" runat="server" Width="100px"></asp:DropDownList>
										                </td>
									                </tr>
									                <tr>
										                <th scope="col">
											                <span class="tbl-hdg">
												                <cc:EncodedLabel ID="LockLbl" runat="server">ロック状態</cc:EncodedLabel>
											                </span>
										                </th>
										                <td>
											                <asp:RadioButtonList ID="RadioListLock" runat="server" Font-Size="X-Small" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:RadioButtonList>
										                </td>
									                </tr>
								                </table>
							                <!-- /inner --></div>
						                <!-- /str-form-02 --></div>
                                        <table>
                                            <tr>
								                <td>
									                <asp:Button ID="SearchBtn" runat="server" OnClick="SearchBtn_Click" Text="検索" CssClass="btn type-02" />
								                </td>
							                </tr>
                                        </table>
		    		                <!-- /inner-02 --></div>
		    	                <!-- /str-search-01 --></div>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <%-------------------------------------------------------------------
                                    2.明細部
                                ---------------------------------------------------------------------%>
			                        <!-- search-result -->
			                        <div class="str-wrap-result">
				                        <!-- button -->
				                        <div id="str-btn-area" class="str-btn-utility">
					                        <ul>
						                        <!--明細制御系ボタンを配置する場合はこのulタグの中-->
					                        </ul>
					                        <ul>
						                        <!--帳票／CSV系ボタンを配置する場合はこのulタグの中-->
					                        </ul>
				                        <!-- /utility --></div>
				                        <div class="inner">
					                        <div id="str-pager-top" class="str-pager-01">
						                        <!--- 件数表示部 --->
                                                <%--- 「ページャー」カスタムページャー ---%>
                                                <cc:Pager ID="Pager" runat="server" CurrentPageIndex="0" PageSize="20" Font-Size="11pt"
                                                    NextText="Next >>" OnPageIndexChanged="Pager_PageIndexChanged" PrevText="<< Back"
                                                    VirtualItemCount="0"></cc:Pager>
					                        <!-- /str-pager-01 --></div>
					                        <!--一覧-->
                                            <div id="str-result-item-wrap" class="adjust-elem">
                                                    <asp:GridView ID="M1" runat="server" AutoGenerateColumns="False" CssClass="str-result-01"
                                                        Width="100%" OnRowCommand="M1_RowCommand" OnRowDataBound="M1_RowDataBound">
                                                        <RowStyle CssClass="str-result-item-01"></RowStyle>
                                                        <HeaderStyle CssClass="str-result-hdg-01"></HeaderStyle>
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="会社">
                                                                <HeaderStyle Width="30%" Font-Size="X-Small" Font-Bold="true"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                                                <ItemTemplate>
                                                                    <%--- 「会社」一行テキストボックス（セパレート日付以外） ---%>
                                                                    &nbsp;<cc:EncodedLabel ID="GridCompanyLbl" runat="server"></cc:EncodedLabel>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="ログインID">
                                                                <HeaderStyle Width="30%" Font-Size="X-Small" Font-Bold="true"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                                                <ItemTemplate>
                                                                    <%--- 「ログインid」ラベル ---%>
                                                                    &nbsp;<cc:EncodedLabel ID="GridLoginIDLbl" runat="server" Text='<%# Bind("LOGIN_ID") %>'></cc:EncodedLabel>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="利用者名">
                                                                <HeaderStyle Width="40%" Font-Size="X-Small" Font-Bold="true"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Left" Width="40%"></ItemStyle>
                                                                <ItemTemplate>
                                                                    <%--- 「利用者名」一行テキストボックス（セパレート日付以外） ---%>
                                                                    &nbsp;<cc:EncodedLabel ID="GridUsernameLbl" runat="server" Text='<%# Bind("NAME") %>'></cc:EncodedLabel>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                               
                                                            <asp:TemplateField HeaderText="ロックフラグ" Visible="False">
                                                                <HeaderStyle></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                                <ItemTemplate>
                                                                    <%--- 「利用者名」一行テキストボックス（セパレート日付以外） ---%>
                                                                    &nbsp;<cc:EncodedLabel ID="GridLockFlagLbl" runat="server" Text='<%# Bind("LOCK_FLAG") %>'></cc:EncodedLabel>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                               
                                                            <asp:ButtonField ButtonType="Button" HeaderText="状態変更" DataTextField = "LOCK_FLAG" CommandName="LockRow">
                                                                <HeaderStyle Font-Size="X-Small" Font-Bold="true"/>
                                                                <ItemStyle HorizontalAlign="Center"/>
                                                            </asp:ButtonField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
					                        <!------------------------------------------
					                          □ページャ下部領域
					                        -------------------------------------------->
					                        <span class="adjust-elem-next"></span>
				                        <!-- /inner --></div>
				                        <div id="str-pager-bottom" class="str-pager-01">
					                        <div class="pager-01">
						                        &nbsp;
					                        <!-- /pager-01 --></div>
					                        <p>
						                        <!-- ページャ下部にボタンを配置する場合はこの中 -->
					                        </p>
				                        <!-- /str-pager-01 --></div>
			                        <!-- /str-wrap-result --></div>
                                <!-- 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 End -->
                            </td>
                        </tr>
                        <tr>
                            <td valign="bottom" style="height: 18px">
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
