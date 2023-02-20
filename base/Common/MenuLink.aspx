<%-- All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS --%>
<%-- FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
改版履歴
2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更
 --%>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MenuLink.aspx.cs" Inherits="Common_MenuLink" %>
<%@ Register TagPrefix="uc" TagName="Footer" Src="../Common/Usercontrol/FooterControl.ascx" %>
<%@ Register TagPrefix="cc" Namespace="Com.Fujitsu.SmartBase.Library.WebControls"
    Assembly="Com.Fujitsu.SmartBase.Library.WebControls" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>メニュー選択</title>
    <%-- link css --%>
    <link title="default" href="../Common/Style/default.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="Js/menu.js"></script>
    <script type="text/javascript" src="../Common/Js/common.js"></script>
	<script type="text/javascript" src="../Common/Js/KeySafe.js"></script>
</head>
<body>
    <form id="form1" runat="server" onprerender="RenderForm">
        <div class="DIV_SCROLL">
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
                                    <cc:EncodedLabel ID="Programtitle" runat="server">メニュー選択</cc:EncodedLabel>
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
                                    <cc:EncodedLabel ID="MenuGroupNameLbl" runat="server"></cc:EncodedLabel>
                                    <img height="1" src="../Common/Images/spacer.gif" alt="spacer" width="20" />
                                </td>
                            </tr>
                        </table>
                        <!-- 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 Start -->
                        <%-------------------------------------------------------------------
						1.カード部
						---------------------------------------------------------------------%>
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
                                            <asp:Repeater ID="MenuRepeater" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <th scope="col">
                                                            <span class="tbl-hdg">
                                                                <a href="<%# DataBinder.Eval(Container.DataItem, "Url") %>">
                                                                    <%# DataBinder.Eval(Container.DataItem, "MenuName") %>
                                                                </a>
                                                            </span>
                                                        </th>
                                                        <td width="65%">
                                                            &nbsp;
                                                            &nbsp;
                                                            <%# DataBinder.Eval(Container.DataItem, "MenuNote") %>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </table>
							        <!-- /inner --></div>
						        <!-- /str-form-02 --></div>
		    		        <!-- /inner-02 --></div>
		    	        <!-- /str-search-01 --></div>
                        <!-- 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 End -->
                    </td>
                </tr>
                <tr>
                    <td valign="bottom">
                        <uc:Footer ID="footer" runat="server"></uc:Footer>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
