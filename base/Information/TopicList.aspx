<%-- All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS --%>
<%-- FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
改版履歴
2015/10/20 FSWeb)Y.Tamura デザイン変更追加対応
 --%>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TopicList.aspx.cs" Inherits="Information_TopicList" %>

<%@ Register TagPrefix="uc" TagName="Footer" Src="../Common/Usercontrol/FooterControl.ascx" %>
<%@ Register TagPrefix="cc" Namespace="Com.Fujitsu.SmartBase.Library.WebControls"
    Assembly="Com.Fujitsu.SmartBase.Library.WebControls" %>
<html>
<head id="Head1" runat="server">
    <title>見出し管理</title>
    <%-- link css --%>
    <link title="default" href="../Common/Style/default.css" type="text/css" rel="stylesheet" />
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
                            <td align="right" style="width: 75px">
                                <asp:Button ID="BackBtn" runat="server" CausesValidation="False" OnClick="BackBtn_Click" />
                            </td>
                            <%-- 戻るボタンが必要な場合はここに設置 --%>
                        </tr>
                    </table>
                    <img height="10" src="../Common/Images/spacer.gif" alt="spacer" width="1" /><br />
                    <table class="TABLE_FRMTITLE">
                        <tr>
                            <td>
                                <img src="../Common/Images/point.gif" alt="point" />
                                <cc:EncodedLabel ID="Formtitle" runat="server"></cc:EncodedLabel>
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
                    <table width="100%">
                        <tr>
                            <td class="TD_FRM">
                                <%-------------------------------------------------------------------
						1.カード部
						---------------------------------------------------------------------%>
                                <!-- 2015/10/20 FSWeb)Y.Tamura デザイン変更追加対応 Start -->
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
                                                            &nbsp;
										                </th>
										                <td>
                                                            &nbsp;
										                </td>
									                </tr>
								                </table>
							                <!-- /inner --></div>
						                <!-- /str-form-02 --></div>
                                        <div>
                                            <asp:Button ID="AddBtn" runat="server" CausesValidation="False" OnClick="AddBtn_Click" CssClass="btn type-04" />
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
					                    <!-- /str-pager-01 --></div>
					                    <!--一覧-->
                                        <div id="str-result-item-wrap" class="adjust-elem">
                                                <asp:GridView ID="TopicList" runat="server" AutoGenerateColumns="False" CssClass="str-result-01 info-table"
                                                    Width="100%" OnRowCommand="topicList_RowCommand">
                                                    <RowStyle CssClass="str-result-item-01"></RowStyle>
                                                    <HeaderStyle CssClass="str-result-hdg-01"></HeaderStyle>
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="" Visible="False">
                                                            <ItemTemplate>
                                                                <cc:EncodedLabel ID="TopicID" runat="server" Text='<%# Bind("TOPIC_ID") %>'></cc:EncodedLabel>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="">
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            <HeaderStyle Font-Bold="true" Width="60%"/>
                                                            <ItemTemplate>
                                                                <cc:EncodedLabel ID="Topic" runat="server" Text='<%# Bind("TOPIC") %>'></cc:EncodedLabel>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="">
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            <HeaderStyle Font-Bold="true" Width="20%"/>
                                                            <ItemTemplate>
                                                                <cc:EncodedLabel ID="DisplayFlag" runat="server" Text='<%# Bind("DISPLAY_FLAG") %>'></cc:EncodedLabel>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="">
                                                            <ItemStyle HorizontalAlign="Right"  Width="20%"/>
                                                            <HeaderStyle Font-Bold="true" />
                                                            <ItemTemplate>
                                                                <cc:EncodedLabel ID="SortNo" runat="server" Text='<%# Bind("SORT_NO") %>'></cc:EncodedLabel>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:ButtonField HeaderText="" ButtonType="Button" CommandName="EditRow" >
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            <HeaderStyle Font-Bold="true" />
                                                        </asp:ButtonField>
                                                        <asp:ButtonField HeaderText="" ButtonType="Button" CommandName="DeleteRow" >
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
                                <!-- 2015/10/20 FSWeb)Y.Tamura デザイン変更追加対応 End -->
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
