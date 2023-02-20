<%-- All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS --%>
<%-- FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL --%>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MenuSetting.aspx.cs" Inherits="role_MenuSetting" %>

<%@ Register TagPrefix="uc" TagName="Footer" Src="../Common/Usercontrol/FooterControl.ascx" %>
<%@ Register TagPrefix="cc" Namespace="Com.Fujitsu.SmartBase.Library.WebControls"
    Assembly="Com.Fujitsu.SmartBase.Library.WebControls" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>業務メニュー表示制御</title>
    <%-- link css --%>
    <link title="default" href="../Common/Style/default.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
     .tdtree {
        padding: 0px;
        border-width: 0px;
        border-color: red;
        border-collapse: collapse;
        border-spacing: 0px;
        font-size:12px;
        padding: 3px;
     }
     .trtree {
        border-collapse: collapse;
        border: 1px solid gray;        
        border-collapse: collapse;
        border-spacing: 0px;
     }
     .tabletree {        
        border: 1px solid gray;
        border-collapse: collapse;
        border-spacing: 0px;
        padding: 2px;
     }
     .dispbtn {
        border-width: 0px;
     }
    </style>

    <script type="text/javascript">
    <!--
    function displayDitail(id)
    {
        var img = window.event.srcElement;
        var ele = document.getElementById(id);
	    if (ele.style.display == "none")
	    {
		    ele.style.display = "block";
		    img.src = "../Common/Images/tree_open.gif";
	    }
	    else
	    {
		    ele.style.display = "none";
		    img.src = "../Common/Images/tree_close.gif";
	    }
    }
    
    function checkAllowBox(value)
    {
        var ele = document.getElementsByTagName('input');
        for (i = 0; i < ele.length; i++)
        {
            var type = ele[i].getAttributeNode("type").value;
            if (type == "checkbox")
            {
                ele[i].setAttribute("checked", value);
            }
        }
    }
    // -->
    </script>

    <script type="text/javascript" src="../Common/Js/common.js"></script>
</head>
<body>
    <form id="form1" runat="server" onprerender="RenderForm">
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
                                <cc:EncodedLabel ID="Programtitle" runat="server">ロール管理</cc:EncodedLabel>
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
                    <table class="TABLE_FRMTITLE" width="100%">
                        <tr>
                            <td>
                                <img src="../Common/Images/point.gif" alt="point" />
                                <cc:EncodedLabel ID="Formtitle" runat="server">メニュー設定</cc:EncodedLabel>
                                <img height="1" src="../Common/Images/spacer.gif" alt="spacer" width="20" />
                            </td>
                            <td align="right">
                                <input id="AllCheck" type="button" runat="server" value="すべてチェック" onclick="checkAllowBox(true);" />
                                <input id="AllUndo" type="button" runat="server" value="すべてはずす" onclick="checkAllowBox(false);" /></td>
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
                <td height="100%">
                    <table width="100%" height="100%">
                        <tr>
                            <td class="TD_FRM" height="100%">
                                <table id="Table2" cellspacing="0" cellpadding="0" height="100%" border="0">
                                    <tr>
                                        <td height="100%" valign="top">
                                            <div id="scroll" style="border: solid 1px #7e8b94; height: 100%; overflow: auto;">
                                                <asp:GridView ID="MenuList1" runat="server" CssClass="tabletree" AutoGenerateColumns="False"
                                                    OnRowDataBound="MenuList1_RowDataBound" ShowHeader="false" BackColor="white">
                                                    <RowStyle CssClass="trtree" />
                                                    <Columns>
                                                        <asp:TemplateField Visible="False">
                                                            <ItemTemplate>
                                                                <cc:EncodedLabel ID="SolutionId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SolutionId") %>'></cc:EncodedLabel>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField Visible="False">
                                                            <ItemTemplate>
                                                                <cc:EncodedLabel ID="FunctionViewId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FunctionViewId") %>'></cc:EncodedLabel>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="top" CssClass="tdtree" Width="20px" />
                                                            <ItemTemplate>
                                                                <a id="DisplayBtn" class="dispbtn" href="#" runat="server">
                                                                    <img style="border-width: 0px;" src="../Common/Images/tree_open.gif" /></a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemStyle VerticalAlign="top" Width="150px" CssClass="tdtree" />
                                                            <ItemTemplate>
                                                                <cc:EncodedLabel ID="Name" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>'></cc:EncodedLabel>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemStyle HorizontalAlign="left" VerticalAlign="top" CssClass="tdtree" />
                                                            <ItemTemplate>
                                                                <div id="display1" runat="server">
                                                                    <asp:GridView ID="MenuList2" runat="server" CssClass="tabletree" AutoGenerateColumns="False"
                                                                        ShowHeader="False" OnRowDataBound="MenuList2_RowDataBound" BackColor="#f3f3f3">
                                                                        <RowStyle CssClass="trtree" />
                                                                        <Columns>
                                                                            <asp:TemplateField Visible="False">
                                                                                <ItemTemplate>
                                                                                    <cc:EncodedLabel ID="SolutionId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SolutionId") %>'></cc:EncodedLabel>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField Visible="False">
                                                                                <ItemTemplate>
                                                                                    <cc:EncodedLabel ID="FunctionViewId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FunctionViewId") %>'></cc:EncodedLabel>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField Visible="False">
                                                                                <ItemTemplate>
                                                                                    <cc:EncodedLabel ID="FunctionID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FunctionID") %>'></cc:EncodedLabel>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField>
                                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="top" CssClass="tdtree" Width="20px" />
                                                                                <ItemTemplate>
                                                                                    <a id="DisplayBtn" class="dispbtn" href="#" runat="server">
                                                                                        <img style="border-width: 0px;" src="../Common/Images/tree_open.gif" /></a>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField>
                                                                                <ItemStyle VerticalAlign="top" Width="150px" CssClass="tdtree" />
                                                                                <ItemTemplate>
                                                                                    <cc:EncodedLabel ID="Name" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>'></cc:EncodedLabel>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField>
                                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" CssClass="tdtree" />
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="AllowCheckBox" runat="server" Visible="false" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField>
                                                                                <ItemStyle HorizontalAlign="left" VerticalAlign="top" CssClass="tdtree" />
                                                                                <ItemTemplate>
                                                                                    <div id="display2" runat="server">
                                                                                        <asp:GridView ID="MenuList3" runat="server" CssClass="tabletree" AutoGenerateColumns="False"
                                                                                            ShowHeader="False" OnRowDataBound="MenuList3_RowDataBound" BackColor="white">
                                                                                            <RowStyle CssClass="trtree" />
                                                                                            <Columns>
                                                                                                <asp:TemplateField Visible="False">
                                                                                                    <ItemTemplate>
                                                                                                        <cc:EncodedLabel ID="SolutionId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SolutionId") %>'></cc:EncodedLabel>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField Visible="False">
                                                                                                    <ItemTemplate>
                                                                                                        <cc:EncodedLabel ID="FunctionViewId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FunctionViewId") %>'></cc:EncodedLabel>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField>
                                                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="top" CssClass="tdtree" Width="20px" />
                                                                                                    <ItemTemplate>
                                                                                                        <a id="DisplayBtn" class="dispbtn" href="#" runat="server">
                                                                                                            <img style="border-width: 0px;" src="../Common/Images/tree_open.gif" /></a>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField>
                                                                                                    <ItemStyle VerticalAlign="top" Width="150px" CssClass="tdtree" />
                                                                                                    <ItemTemplate>
                                                                                                        <cc:EncodedLabel ID="Name" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>'></cc:EncodedLabel>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField>
                                                                                                    <ItemStyle HorizontalAlign="left" VerticalAlign="top" CssClass="tdtree" />
                                                                                                    <ItemTemplate>
                                                                                                        <div id="display3" runat="server">
                                                                                                            <asp:GridView ID="MenuList4" runat="server" CssClass="tabletree" AutoGenerateColumns="False"
                                                                                                                ShowHeader="False" OnRowDataBound="MenuList4_RowDataBound" BackColor="#f3f3f3">
                                                                                                                <RowStyle CssClass="trtree" />
                                                                                                                <Columns>
                                                                                                                    <asp:TemplateField Visible="False">
                                                                                                                        <ItemTemplate>
                                                                                                                            <cc:EncodedLabel ID="SolutionId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SolutionId") %>'></cc:EncodedLabel>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField Visible="False">
                                                                                                                        <ItemTemplate>
                                                                                                                            <cc:EncodedLabel ID="FunctionViewId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FunctionViewId") %>'></cc:EncodedLabel>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField>
                                                                                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="top" CssClass="tdtree" Width="20px" />
                                                                                                                        <ItemTemplate>
                                                                                                                            <a id="DisplayBtn" class="dispbtn" href="#" runat="server">
                                                                                                                                <img style="border-width: 0px;" src="../Common/Images/tree_open.gif" /></a>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField>
                                                                                                                        <ItemStyle VerticalAlign="top" Width="150px" CssClass="tdtree" />
                                                                                                                        <ItemTemplate>
                                                                                                                            <cc:EncodedLabel ID="Name" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>'></cc:EncodedLabel>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField>
                                                                                                                        <ItemStyle HorizontalAlign="left" VerticalAlign="top" CssClass="tdtree" />
                                                                                                                        <ItemTemplate>
                                                                                                                            <div id="display4" runat="server">
                                                                                                                                <asp:GridView ID="MenuList5" runat="server" CssClass="tabletree" AutoGenerateColumns="False"
                                                                                                                                    ShowHeader="False" OnRowDataBound="MenuList5_RowDataBound" BackColor="white">
                                                                                                                                    <RowStyle CssClass="trtree" />
                                                                                                                                    <Columns>
                                                                                                                                        <asp:TemplateField Visible="False">
                                                                                                                                            <ItemTemplate>
                                                                                                                                                <cc:EncodedLabel ID="SolutionId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SolutionId") %>'></cc:EncodedLabel>
                                                                                                                                            </ItemTemplate>
                                                                                                                                        </asp:TemplateField>
                                                                                                                                        <asp:TemplateField Visible="False">
                                                                                                                                            <ItemTemplate>
                                                                                                                                                <cc:EncodedLabel ID="FunctionViewId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FunctionViewId") %>'></cc:EncodedLabel>
                                                                                                                                            </ItemTemplate>
                                                                                                                                        </asp:TemplateField>
                                                                                                                                        <asp:TemplateField Visible="False">
                                                                                                                                            <ItemTemplate>
                                                                                                                                                <cc:EncodedLabel ID="FunctionID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FunctionID") %>'></cc:EncodedLabel>
                                                                                                                                            </ItemTemplate>
                                                                                                                                        </asp:TemplateField>
                                                                                                                                         <asp:TemplateField>
                                                                                                                                            <ItemStyle VerticalAlign="top" Width="150px" CssClass="tdtree" />
                                                                                                                                            <ItemTemplate>
                                                                                                                                                <cc:EncodedLabel ID="Name" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>'></cc:EncodedLabel>
                                                                                                                                            </ItemTemplate>
                                                                                                                                        </asp:TemplateField>
                                                                                                                                        <asp:TemplateField>
                                                                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="tdtree" />
                                                                                                                                            <ItemTemplate>
                                                                                                                                                <asp:CheckBox ID="AllowCheckBox" runat="server" />
                                                                                                                                            </ItemTemplate>
                                                                                                                                        </asp:TemplateField>
                                                                                                                                    </Columns>
                                                                                                                                </asp:GridView>
                                                                                                                            </div>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                </Columns>
                                                                                                            </asp:GridView>
                                                                                                        </div>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                            </Columns>
                                                                                        </asp:GridView>
                                                                                    </div>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                                &nbsp;</div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 21px">
                                            <asp:Button ID="OKBtn" runat="server" Text="確定" OnClick="OKBtn_Click" />
                                            <asp:Button ID="CancelBtn" runat="server" Text="取消" OnClick="CancelBtn_Click" />
                                            </td>
                                    </tr>
                                </table>
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
