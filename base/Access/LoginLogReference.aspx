<%-- All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS --%>
<%-- FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
改版履歴
2015/10/20 FSWeb)Y.Tamura デザイン変更追加対応
 --%>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginLogReference.aspx.cs"
	Inherits="Access_LoginLogReference" %>

<%@ Register TagPrefix="uc" TagName="Footer" Src="../Common/Usercontrol/FooterControl.ascx" %>
<%@ Register TagPrefix="cc" Namespace="Com.Fujitsu.SmartBase.Library.WebControls"
	Assembly="Com.Fujitsu.SmartBase.Library.WebControls" %>
<html>
<head id="Head1" runat="server">
	<title>アクセス管理</title>
	<%-- link css --%>
	<link title="default" href="../Common/Style/default.css" type="text/css" rel="stylesheet" />
    <!-- 2015/10/20 FSWeb)Y.Tamura デザイン変更追加対応 Start -->
    <link rel="stylesheet" type="text/css" href="../Common/Style/jquery-ui.css">
    <!-- 2015/10/20 FSWeb)Y.Tamura デザイン変更追加対応 End -->
	<%-- jacascript --%>
    <!-- 2015/10/20 FSWeb)Y.Tamura デザイン変更追加対応 Start -->
    <script type="text/javascript" src="../Common/Js/jquery.min.js"></script>
    <script type="text/javascript" src="../Common/Js/jquery-ui.min.js"></script>
    <script type="text/javascript" src="../Common/Js/datepicker-ja.js"></script>
    <!-- 2015/10/20 FSWeb)Y.Tamura デザイン変更追加対応 End -->
	<script type="text/javascript" src="../Common/Js/calendar.js"></script>
	<script type="text/javascript" src="../Common/Js/common.js"></script>
	<script type="text/javascript" src="../Common/Js/KeySafe.js"></script>
</head>
<body>
	<form id="form" runat="server" onprerender="RenderForm">
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
						<td valign="bottom" style="width: 100%; background-image: url(../Common/Images/pagetitle_4.gif)"
							align="right">
							<img height="1" src="../Common/Images/spacer.gif" alt="spacer" />
						</td>
						<td align="right" style="width: 75px">
                            <asp:Button ID="BackBtn" runat="server" OnClick="BackBtn_Click" CausesValidation="False" />
						</td>
						<%-- 戻るボタンが必要な場合はここに設置 --%>
					</tr>
				</table>
				<img height="10" src="../Common/Images/spacer.gif" alt="spacer" width="1" /><br />
				<table class="TABLE_FRMTITLE" width="100%">
					<tr>
						<td>
							<img src="../Common/Images/point.gif" alt="point" />
							<cc:EncodedLabel ID="Formtitle" runat="server">ログイン履歴参照</cc:EncodedLabel>
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
		</tr>
		<tr>
			<td valign="top">
				<table width="100%">
					<tr>
						<td class="TD_FRM">
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
										            <th scope="col">
											            <span class="tbl-hdg">
												            <cc:EncodedLabel ID="LoginIdLbl" runat="server"></cc:EncodedLabel><span class="required">*</span>
											            </span>
										            </th>
										            <td>
                                                        &nbsp;
                                                        &nbsp;
											            <asp:TextBox ID="LoginIdBox" Columns="18" CssClass="TEXT_L" runat="server" MaxLength="10" Width="20%" Height="100%"></asp:TextBox>
										                <asp:Label ID="LoginIdInvalidCharValid" runat="server" Text=''></asp:Label>
										            </td>
									            </tr>
									            <tr>
										            <th scope="col">
                                                        <span class="tbl-hdg">
                                                            <cc:EncodedLabel ID="LoginStatusLbl" runat="server"></cc:EncodedLabel><span class="required">*</span>
                                                        </span>
										            </th>
										            <td>
                                                        &nbsp;
                                                        &nbsp;
											            <asp:CheckBox ID="LogStatus0" CssClass="TEXT_L" Text="ログイン" runat="server" Width="15%"/>
										                <asp:CheckBox ID="LogStatus1" CssClass="TEXT_L" Text="ログアウト" runat="server" Width="15%"/>
										                <asp:CheckBox ID="LogStatus2" CssClass="TEXT_L" Text="強制ログイン" runat="server" Width="15%"/>
										                <asp:CheckBox ID="LogStatus3" CssClass="TEXT_L" Text="強制ログアウト" runat="server" Width="15%"/>
										                <asp:CheckBox ID="LogStatus4" CssClass="TEXT_L" Text="タイムアウト" runat="server" Width="15%"/>
										                <asp:CheckBox ID="LogStatus5" CssClass="TEXT_L" Text="パスワードミス" runat="server" Width="15%"/>
                                                            
										            </td>
									            </tr>
                                                <tr>
                                                    <th>&nbsp;</th>
                                                    <td>
                                                        &nbsp;
                                                        &nbsp;
										                <asp:CheckBox ID="LogStatus6" CssClass="TEXT_L" Text="ユーザロック" runat="server" Width="15%"/>
										                <asp:CheckBox ID="LogStatus7" CssClass="TEXT_L" Text="運用時間外" runat="server" Width="15%"/>
										                <asp:CheckBox ID="LogStatus8" CssClass="TEXT_L" Text="機能の実行" runat="server" Width="15%"/>
										                <asp:CheckBox ID="LogStatus9" CssClass="TEXT_L" Text="機能の終了" runat="server" Width="15%"/>
                                                    </td>
                                                </tr>
									            <tr>
										            <th scope="col">
											            <span class="tbl-hdg">
												            <cc:EncodedLabel ID="LoginDateLbl" runat="server"></cc:EncodedLabel>
											            </span>
										            </th>
										            <td>
                                                        &nbsp;
                                                        &nbsp;
											            <cc:EncodedLabel ID="FromLbl" runat="server" Font-Size="Small"></cc:EncodedLabel>
                                                        <span class="icon-in">
										                    <asp:TextBox ID="FromDateBox" runat="server" Columns="8" MaxLength="10" Height="100%" CssClass="inpSerch inpDt datepicker"></asp:TextBox>
                                                        </span>
										                ～
										                <cc:EncodedLabel ID="ToLbl" runat="server" Font-Size="Small"></cc:EncodedLabel>
                                                        <span class="icon-in">
										                    <asp:TextBox ID="ToDateBox" runat="server" Columns="8" MaxLength="10" Height="100%" CssClass="inpSerch inpDt datepicker"></asp:TextBox>
                                                        </span>
										                <cc:EncodedLabel ID="DateCutline" runat="server" CssClass="CUTLINE" Escape="True" URLConvert="False"></cc:EncodedLabel>
										                <asp:CustomValidator ID="DateValid" runat="server" OnServerValidate="DateValid_ServerValidate" Display="None"></asp:CustomValidator>
										                <asp:Label ID="FromDateInvalidCharValid" runat="server" Text=''></asp:Label>
										                <asp:Label ID="ToDateInvalidCharValid" runat="server" Text=''></asp:Label>
										            </td>
									            </tr>
								            </table>
							            <!-- /inner --></div>
						            <!-- /str-form-02 --></div>
                                    <div>
                                        <asp:Button ID="SearchButton" runat="server" OnClick="SearchButton_Click" CssClass="btn type-02"/>
                                    <!-- /str-btn-search --></div>
		    		            <!-- /inner-02 --></div>
		    	            <!-- /str-search-01 --></div>
						</td>
					</tr>
					<tr>
						<td height="100%" valign="top">
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
                                        <cc:Pager ID="Pager" runat="server" CurrentPageIndex="0"
								            OnPageIndexChanged="Pager_PageIndexChanged" PageSize="20" VirtualItemCount="0"
								            NextText="Next >>" PrevText="<< Back" Font-Size="11pt"></cc:Pager>
					                <!-- /str-pager-01 --></div>
					                <!--一覧-->
                                    <div id="str-result-item-wrap" class="adjust-elem">
                                            <asp:GridView ID="LoginLogList" runat="server" AutoGenerateColumns="False" CssClass="str-result-01 info-table"
                                                Width="100%" OnRowDataBound="LoginLogList_RowDataBound">
                                                <RowStyle CssClass="str-result-item-01"></RowStyle>
                                                <HeaderStyle CssClass="str-result-hdg-01"></HeaderStyle>
                                                <Columns>
                                                    <asp:TemplateField HeaderText="会社">
                                                        <HeaderStyle Width="10%" Font-Bold="true"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                                                        <ItemTemplate>
                                                            <asp:Label ID="CompanyNAME" runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="ログインID">
                                                        <HeaderStyle Width="10%" Font-Bold="true"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                                                        <ItemTemplate>
                                                            <asp:Label ID="LoginID" runat="server" Text='<%# Bind("LOGIN_ID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="利用者名">
                                                        <HeaderStyle Width="15%" Font-Bold="true"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                        <ItemTemplate>
                                                            <asp:Label ID="UserNAME" runat="server" Text='<%# Bind("NAME") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="アクセス種別">
                                                        <HeaderStyle Width="15%" Font-Bold="true" ></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                        <ItemTemplate>
                                                            <asp:Label ID="AccessTYPE" runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="アクセス日時">
                                                        <ItemStyle HorizontalAlign="Left"/>
                                                        <HeaderStyle Width="15%" Font-Bold="true" />
                                                        <ItemTemplate>
                                                            <cc:EncodedLabel ID="AccessTime" runat="server" Text='<%# Bind("LOG_DATETIME")%>'></cc:EncodedLabel>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="機能ＩＤ">
                                                        <ItemStyle HorizontalAlign="Left"/>
                                                        <HeaderStyle Width="10%" Font-Bold="true" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="FunctionID" runat="server" Text='<%# Bind("FUNCTION_ID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="機能名">
                                                        <ItemStyle HorizontalAlign="Left"/>
                                                        <HeaderStyle Width="25%" Font-Bold="true" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="FunctionName" runat="server" Text='<%# Bind("FUNCTION_NAME") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
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
                            <!-- 2015/09/16 2015/10/20 FSWeb)Y.Tamura デザイン変更追加対応 End -->
						</td>
					</tr>
				</table>
			</td>
		</tr>
		<tr>
			<td valign="bottom">
				<uc:Footer ID="footer" runat="server"></uc:Footer>
			</td>
		</tr>
	</table>
	</form>
</body>
</html>
