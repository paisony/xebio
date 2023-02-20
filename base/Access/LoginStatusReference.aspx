<%-- All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS --%>
<%-- FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL --%>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginStatusReference.aspx.cs" Inherits="Access_LoginStatusReference" %>

<%@ Register TagPrefix="uc" TagName="Footer" Src="../Common/Usercontrol/FooterControl.ascx" %>
<%@ Register TagPrefix="cc" Namespace="Com.Fujitsu.SmartBase.Library.WebControls"
    Assembly="Com.Fujitsu.SmartBase.Library.WebControls" %>
<html>
<head id="Head1" runat="server">
    <title>アクセス管理</title>
    <%-- link css --%>
    <link title="default" href="../Common/Style/default.css" type="text/css" rel="stylesheet" />
	<%-- jacascript --%>
    <!-- 2015/10/20 FSWeb)Y.Tamura デザイン変更追加対応 Start -->
    <script type="text/javascript" src="../Common/Js/jquery.min.js"></script>
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
                            <td valign="bottom" style="width: 100%; background-image: url(../Common/Images/pagetitle_4.gif)" align="right">
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
                                <cc:EncodedLabel ID="Formtitle" runat="server">ログイン状態参照</cc:EncodedLabel>
                                <img height="1" src="../Common/Images/spacer.gif" alt="spacer" width="20" />
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
                                <!-- 2015/10/20 FSWeb)Y.Tamura デザイン変更追加対応 Start -->
                                 <!-- search-list -->
                                <div class="str-search-01">
					                <div class="inner-02">
						                <div class="str-form-02">
							                <div class="inner">
								                <table>
									                <colgroup>
										                <col class="w-type-01">
										                <col class="w-type-02">
									                </colgroup>
									                <tr>
										                <th scope="col">
                                                            <span class="tbl-hdg">
												                <cc:EncodedLabel ID="UserCountLbl" runat="server" Text="現在の利用者人数"></cc:EncodedLabel>
											                </span>
										                </th>
										                <td>
                                                            &nbsp;
                                                            &nbsp;
                                                            <cc:EncodedLabel ID="CountLbl" runat="server" Font-Size="Small"></cc:EncodedLabel>
										                </td>
									                </tr>
								                </table>
							                <!-- /inner --></div>
						                <!-- /str-form-02 --></div>
                                        <div>
                                            <asp:Button ID="ReloadButton" runat="server" OnClick="ReloadButton_Click" CssClass="btn type-04" />
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
                                            <cc:Pager ID="Pager" runat="server" CurrentPageIndex="0" OnPageIndexChanged="Pager_PageIndexChanged" PageSize="20" 
                                                VirtualItemCount="0" NextText="Next >>" PrevText="<< Back" Font-Size="11pt"></cc:Pager>
					                    <!-- /str-pager-01 --></div>
					                    <!--一覧-->
                                        <div id="str-result-item-wrap" class="adjust-elem">
                                                <asp:GridView ID="LoginStatusList" runat="server" AutoGenerateColumns="False" CssClass="str-result-01 info-table"
                                                    Width="100%" OnRowDataBound="LoginStatusList_RowDataBound" PageSize="20">
                                                    <RowStyle CssClass="str-result-item-01"></RowStyle>
                                                    <HeaderStyle CssClass="str-result-hdg-01"></HeaderStyle>
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="会社">
                                                            <HeaderStyle Width="10%" Font-Bold="true"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Left" Width="25%"></ItemStyle>
                                                            <ItemTemplate>
                                                                <asp:Label ID="CompanyNAME" runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="ログインID">
                                                            <HeaderStyle Width="10%" Font-Bold="true"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Left" Width="25%"></ItemStyle>
                                                            <ItemTemplate>
                                                                <asp:Label ID="LoginID" runat="server" Text='<%# Bind("LOGIN_ID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="利用者名">
                                                            <HeaderStyle Width="25%" Font-Bold="true"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                            <ItemTemplate>
                                                                <asp:Label ID="UserNAME" runat="server" Text='<%# Bind("NAME") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="ログイン日時">
                                                            <ItemStyle HorizontalAlign="Left" Wrap="false"/>
                                                            <HeaderStyle Width="25%" Font-Bold="true" />
                                                            <ItemTemplate>
                                                                <cc:EncodedLabel ID="AccessTime" runat="server" Text='<%# Bind("LOGIN_DATETIME")%>'></cc:EncodedLabel>
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
