<%-- All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS --%>
<%-- FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
改版履歴
2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更
 --%>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MessageList.aspx.cs" Inherits="Information_MessageList" %>

<%@ Register TagPrefix="uc" TagName="Footer" Src="../Common/Usercontrol/FooterControl.ascx" %>
<%@ Register TagPrefix="cc" Namespace="Com.Fujitsu.SmartBase.Library.WebControls"
    Assembly="Com.Fujitsu.SmartBase.Library.WebControls" %>
<html>
<head id="Head1" runat="server">
    <title>メッセージ管理</title>
    <%-- link css --%>
    <link title="default" href="../Common/Style/default.css" type="text/css" rel="stylesheet" />
    <!-- 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 Start -->
    <link rel="stylesheet" type="text/css" href="../Common/Style/jquery-ui.css">
    <!-- 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 End -->
	<%-- jacascript --%>
    <!-- 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 Start -->
    <script type="text/javascript" src="../Common/Js/jquery.min.js"></script>
    <script type="text/javascript" src="../Common/Js/jquery-ui.min.js"></script>
    <script type="text/javascript" src="../Common/Js/datepicker-ja.js"></script>
    <!-- 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 End -->
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
                                <cc:EncodedLabel ID="Programtitle" runat="server"></cc:EncodedLabel>
                            </td>
                            <td valign="bottom" style="background-image: url(../Common/Images/pagetitle_3.gif)">
                                <img height="1" src="../Common/Images/spacer.gif" alt="spacer" width="32px" />
                            </td>
                            <td valign="bottom" style="width: 100%; background-image: url(../Common/Images/pagetitle_4.gif)" align="right">
                                <img height="1" src="../Common/Images/spacer.gif" alt="spacer" />
                            </td>
                            <!-- 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 Start -->
                            <td style="width: 75px;text-align:right;">
                                <asp:Button ID="BackBtn" runat="server" OnClick="BackBtn_Click" CausesValidation="False" />
                            </td>
                            <!-- 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 End -->
                            <%-- 戻るボタンが必要な場合はここに設置 --%>
                        </tr>
                    </table>
                    <img height="10" src="../Common/Images/spacer.gif" alt="spacer" width="1" /><br />
                    <table class="TABLE_FRMTITLE" width="100%">
                        <tr>
                            <td>
                                <img src="../Common/Images/point.gif" alt="point" />
                                <cc:EncodedLabel ID="Formtitle" runat="server"></cc:EncodedLabel>
                                <img height="1" src="../Common/Images/spacer.gif" alt="spacer" width="20" />
                            </td>
                            <td style="text-align:right;">
                                <input id="PreviewBtn" type="button" runat="server" OnClick="javaScript:window.open('../Common/MessagePreview.aspx','_blank','toolbar=no,statusbar=no,scrollbars=yes,menubar=no,resizable=yes,width=800,height=600px');" onserverclick="PreviewBtn_ServerClick" />
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
                <cc:EncodedLabel ID="NoExistTopicLbl" runat="server" ForeColor="Red" Escape="True" Font-Size="X-Small" URLConvert="False"></cc:EncodedLabel></td>
            </tr>
            <tr>
                <td height="100%" valign="top">
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
												                <cc:EncodedLabel ID="TopicLbl" runat="server"></cc:EncodedLabel>
											                </span>
										                </th>
										                <td>
											                <asp:DropDownList ID="TopicDDL" runat="server" OnSelectedIndexChanged="TopicDDL_SelectedIndexChanged" Width="100px">
                                                                <asp:ListItem></asp:ListItem>
                                                            </asp:DropDownList>
										                </td>
									                </tr>
									                <tr>
										                <th scope="col">
                                                            <span class="tbl-hdg">
                                                                <cc:EncodedLabel ID="CreateDateLbl" runat="server"></cc:EncodedLabel>
                                                            </span>
										                </th>
										                <td>
											                <cc:EncodedLabel ID="FromLbl" runat="server" Font-Size="Small"></cc:EncodedLabel>
                                                            <span class="icon-in">
                                                                <asp:TextBox ID="FromDateBox" runat="server" Columns="8" MaxLength="10" CssClass="inpSerch inpDt datepicker" Height="100%"></asp:TextBox>
											                </span>
                                                             ～
                                                            <cc:EncodedLabel ID="ToLbl" runat="server" Font-Size="Small"></cc:EncodedLabel>
                                                            <span class="icon-in">
                                                                <asp:TextBox ID="ToDateBox" runat="server" Columns="8" MaxLength="10" CssClass="inpSerch inpDt datepicker" Height="100%"></asp:TextBox>
											                </span>
                                                            <cc:EncodedLabel ID="DateCutline" runat="server" CssClass="CUTLINE" Escape="True"
                                                                URLConvert="False"></cc:EncodedLabel>
                                                            <asp:CustomValidator ID="DateValid" runat="server" OnServerValidate="DateValid_ServerValidate" Display="None"></asp:CustomValidator>
										                </td>
									                </tr>
									                <tr>
										                <th scope="col">
											                <span class="tbl-hdg">
												                <cc:EncodedLabel ID="DisplayLbl" runat="server"></cc:EncodedLabel>
											                </span>
										                </th>
										                <td>
											                <asp:RadioButtonList ID="RadioListDisplay" runat="server" Font-Size="X-Small" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                            </asp:RadioButtonList>
										                </td>
									                </tr>
								                </table>
							                <!-- /inner --></div>
						                <!-- /str-form-02 --></div>
                                        <div>
                                            <asp:Button ID="CreateBtn" runat="server" OnClick="CreateBtn_Click" CausesValidation="False" CssClass="btn type-04" />
                                            <asp:Button ID="SearchButton" runat="server" OnClick="SearchButton_Click" Text="検索" CssClass="btn type-02" />
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
                                                <cc:Pager ID="Pager1" runat="server" CurrentPageIndex="0" OnPageIndexChanged="Pager_PageIndexChanged" PageSize="20" 
                                                    VirtualItemCount="0" NextText="Next >>" PrevText="<< Back" Font-Size="11pt"></cc:Pager>
					                        <!-- /str-pager-01 --></div>
					                        <!--一覧-->
                                            <div id="str-result-item-wrap" class="adjust-elem">
                                                    <asp:GridView ID="MessageList" runat="server" AutoGenerateColumns="False" CssClass="str-result-01 info-table"
                                                        Width="100%" OnRowCommand="MessageList_RowCommand">
                                                        <RowStyle CssClass="str-result-item-01"></RowStyle>
                                                        <HeaderStyle CssClass="str-result-hdg-01"></HeaderStyle>
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="メッセージID" Visible="False">
                                                                <HeaderStyle Width="30%" Font-Bold="true"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                                                <ItemTemplate>
                                                                    <cc:EncodedLabel ID="MessageID" runat="server" Text='<%# Bind("MESSAGE_ID") %>'></cc:EncodedLabel>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="トピックID" Visible="False">
                                                                <HeaderStyle Width="30%" Font-Bold="true"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                                                <ItemTemplate>
                                                                    <cc:EncodedLabel ID="TopicID" runat="server" Text='<%# Bind("TOPIC_ID") %>'></cc:EncodedLabel>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="メッセージ">
                                                                <HeaderStyle Width="70%" Font-Bold="true"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Message" runat="server" Text='<%# Bind("MESSAGE") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="表示">
                                                                <HeaderStyle Width="15%" Font-Bold="true" ></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                                <ItemTemplate>
                                                                    <cc:EncodedLabel ID="DisplayFlag" runat="server" Text='<%# Bind("DISPLAY_FLAG") %>'></cc:EncodedLabel>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="作成日">
                                                                <ItemStyle HorizontalAlign="Left"/>
                                                                <HeaderStyle Width="15%" Font-Bold="true" />
                                                                <ItemTemplate>
                                                                    <cc:EncodedLabel ID="CreateDateTime" runat="server" Text='<%#  ((DateTime)DataBinder.Eval(Container.DataItem, "CREATE_DATETIME")).ToString("yyyy/MM/dd") %>'></cc:EncodedLabel>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:ButtonField HeaderText="編集" ButtonType="Button" CommandName="EditRow" Text="編集">
                                                                <ItemStyle HorizontalAlign="Center"/>
                                                                <HeaderStyle Font-Bold="true"/>
                                                            </asp:ButtonField>
                                                            <asp:ButtonField HeaderText="削除" ButtonType="Button" CommandName="DeleteRow" Text="削除">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                <HeaderStyle Font-Bold="true" />
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
                        <tr class="TR_ARTICLE_BTN">
                            <td class="TD_ARTICLE_BTN" align="right">
                                    <%--- 「ページャー」カスタムページャー ---%><cc:Pager ID="Pager" runat="server" CurrentPageIndex="0" OnPageIndexChanged="Pager_PageIndexChanged" PageSize="20" 
                                        VirtualItemCount="0" NextText="Next >>" PrevText="<< Back" Font-Size="11pt"></cc:Pager>
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
