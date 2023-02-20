<%-- All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS --%>
<%-- FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
改版履歴
2015/10/20 FSWeb)Y.Tamura デザイン変更追加対応
 --%>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TopicConfirm.aspx.cs" Inherits="Information_TopicConfirm" %>

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
    <form id="form1" runat="server" onprerender="RenderForm">
        <table height="100%" width="100%">
            <tr>
                <td height="100%" width="100%">
                    <div style="height: 100%; overflow: auto; width: 100%;">
                        <table width="100%">
                            <tr>
                                <td valign="top" style="height: 368px">
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
								                                <table class="info-table">
									                                <colgroup>
										                                <col class="w-type-01">
										                                <col class="w-type-02">
									                                </colgroup>
												                    <tr>
													                    <th scope="col" width="15%">
                                                                            <span class="tbl-hdg">
														                        <cc:EncodedLabel ID="TopicNameLbl" runat="server"></cc:EncodedLabel>
													                        </span>
                                                                        </th>
													                    <td>
                                                                            &nbsp;
                                                                            &nbsp;
                                                                            <cc:EncodedLabel ID="TopicNameConfirmLbl" runat="server" Text="Label"></cc:EncodedLabel>
													                    </td>
												                    </tr>
												                    <tr>
													                    <th scope="col">
                                                                            <span class="tbl-hdg">
														                        <cc:EncodedLabel ID="DisplayLbl" runat="server"></cc:EncodedLabel>
													                        </span>
                                                                       </th>
													                    <td>
                                                                            &nbsp;
                                                                            &nbsp;
                                                                            <cc:EncodedLabel ID="DisplayTopicConfirmLbl" runat="server" Text="Label"></cc:EncodedLabel>
													                    </td>
												                    </tr>
												                    <tr>
													                    <th scope="col">
                                                                            <span class="tbl-hdg">
														                        <cc:EncodedLabel ID="NewDisplayPeriodLbl" runat="server"></cc:EncodedLabel>
													                        </span>
                                                                        </th>
													                    <td>
                                                                            &nbsp;
                                                                            &nbsp;
                                                                            <cc:EncodedLabel ID="NewDisplayPeriodConfirmLbl" runat="server" Text="Label"></cc:EncodedLabel>
                                                                            <cc:EncodedLabel ID="UnitDayLbl2" runat="server"></cc:EncodedLabel>
													                    </td>
												                    </tr>
												                    <tr>
													                    <th scope="col">
                                                                            <span class="tbl-hdg">
														                        <cc:EncodedLabel ID="DateDisplayFlagLbl" runat="server"></cc:EncodedLabel>
													                        </span>
                                                                        </th>
													                    <td>
                                                                            &nbsp;
                                                                            &nbsp;
                                                                            <cc:EncodedLabel ID="DisplayDateConfirmLbl" runat="server" Text="Label"></cc:EncodedLabel>
                                                                            <cc:EncodedLabel ID="DateFormatConfirmLbl" runat="server" Text="Label"></cc:EncodedLabel>
													                    </td>
												                    </tr>
												                    <tr>
													                    <th scope="col">
                                                                            <span class="tbl-hdg">
														                        <cc:EncodedLabel ID="DisplayNumberLbl" runat="server"></cc:EncodedLabel>
													                        </span>
                                                                        </th>
													                    <td>
                                                                            &nbsp;
                                                                            &nbsp;
                                                                            <cc:EncodedLabel ID="DisplayNumberConfirmLbl" runat="server" Text="Label"></cc:EncodedLabel>
                                                                            <cc:EncodedLabel ID="UnitAffarLbl" runat="server"></cc:EncodedLabel>
													                    </td>
												                    </tr>
												                    <tr>
													                    <th scope="col">
                                                                            <span class="tbl-hdg">
														                        <cc:EncodedLabel ID="DisplayPeriodLbl" runat="server"></cc:EncodedLabel>
													                        </span>
                                                                        </th>
													                    <td>
                                                                            &nbsp;
                                                                            &nbsp;
                                                                            <cc:EncodedLabel ID="DisplayPeriodCOnfirmLbl" runat="server" Text="Label"></cc:EncodedLabel>
                                                                            <cc:EncodedLabel ID="UnitDayLbl1" runat="server"></cc:EncodedLabel>
													                    </td>
												                    </tr>
												                    <tr>
													                    <th scope="col">
                                                                            <span class="tbl-hdg">
														                        <cc:EncodedLabel ID="SortNo" runat="server"></cc:EncodedLabel>
													                        </span>
                                                                        </th>
													                    <td>
                                                                            &nbsp;
                                                                            &nbsp;
                                                                            <cc:EncodedLabel ID="SortNoConfirmLbl" runat="server" Text="Label"></cc:EncodedLabel>
													                    </td>
												                    </tr>
                                                                    <tr>
													                    <td>
                                                                             &nbsp;
                                                                        </td>
													                    <td>
                                                                            &nbsp;
                                                                            &nbsp;
                                                                            <asp:Button ID="ConfirmBtn" runat="server" OnClick="CreateBtn_Click" CausesValidation="False" />
                                                                            <asp:Button ID="BackBtn" runat="server" OnClick="BackBtn_Click" CausesValidation="False" />
													                    </td>
												                    </tr>
								                                </table>
							                                <!-- /inner --></div>
						                                <!-- /str-form-02 --></div>
		    		                                <!-- /inner-02 --></div>
		    	                                <!-- /str-search-01 --></div>
                                                <!-- 2015/10/20 FSWeb)Y.Tamura デザイン変更追加対応 End -->
                                            </td>
                                        </tr>
                                    </table>
                                    <%-------------------------------------------------------------------
										2.明細部
										---------------------------------------------------------------------%>

                                    </td>
                            </tr>
                            <tr>
                                <td valign="bottom">
                                    <uc:Footer ID="footer" runat="server"></uc:Footer>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
