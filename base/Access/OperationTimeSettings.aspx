<%-- All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS --%>
<%-- FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
改版履歴
2015/10/20 FSWeb)Y.Tamura デザイン変更追加対応
 --%>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OperationTimeSettings.aspx.cs" Inherits="Access_OperationTimeSettings" %>

<%@ Register TagPrefix="uc" TagName="Footer" Src="../Common/Usercontrol/FooterControl.ascx" %>
<%@ Register TagPrefix="cc" Namespace="Com.Fujitsu.SmartBase.Library.WebControls"
    Assembly="Com.Fujitsu.SmartBase.Library.WebControls" %>
<html>
<head id="Head1" runat="server">
    <title>アクセス管理</title>
    <%-- link css --%>
    <link title="default" href="../Common/Style/default.css" type="text/css" rel="stylesheet" />
	<%-- jacascript --%>
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
                                <cc:EncodedLabel ID="Formtitle" runat="server">システム運用時間設定</cc:EncodedLabel>
                                <img height="1" src="../Common/Images/spacer.gif" alt="spacer" width="20" />
                            </td>
                        </tr>
                    </table>
                    <table width="100%">
                        <tr>
                            <td class="TD_FRM">
                                <%--- Web ページ上にあるすべての検証コントロールから得られたエラー メッセージをまとめて表示できます ---%>
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server"></asp:ValidationSummary>
                                <cc:EncodedLabel ID="BusinessMessage" runat="server" Visible="False" ForeColor="Blue"></cc:EncodedLabel>
                                <%--- Web ページ上の検証コントロール ---%>
                            </td>
                        </tr>
                    </table>
            </tr>
            <tr>
                <td valign="top">
                    <table width="100%" >
                        <tr>
                            <td valign="top">
                            <%-------------------------------------------------------------------
						    1.明細部
						    ---------------------------------------------------------------------%>
                                <!-- 2015/10/20 FSWeb)Y.Tamura デザイン変更追加対応 Start -->
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
                                                <asp:GridView ID="OperationTimeList" runat="server" AutoGenerateColumns="False" CssClass="str-result-01 info-table"
                                                    Width="100%" OnRowDataBound="OperationTimeList_RowDataBound" PageSize="20">
                                                    <RowStyle CssClass="str-result-item-01"></RowStyle>
                                                    <HeaderStyle CssClass="str-result-hdg-01"></HeaderStyle>
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="曜日ID" Visible=false>
                                                            <ItemTemplate>
                                                                <asp:Label ID="DayTYPEID" runat="server" Text='<%# Bind("DAY_TYPE") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="曜日">
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            <HeaderStyle Font-Bold="true" Width="20%"/>
                                                            <ItemTemplate>
                                                                <asp:Label ID="DayTYPE" runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="運用開始時間">
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            <HeaderStyle Font-Bold="true" Width="40%"/>
                                                            <ItemTemplate>
                                                                <asp:Panel ID="StartTime" runat="server">
                                                                    <asp:DropDownList ID="StartTimeHourDDL" runat="server" Width="50px">
                                                                    <asp:ListItem></asp:ListItem>
                                                                    <asp:ListItem>00</asp:ListItem><asp:ListItem>01</asp:ListItem><asp:ListItem>02</asp:ListItem>
                                                                    <asp:ListItem>03</asp:ListItem><asp:ListItem>04</asp:ListItem><asp:ListItem>05</asp:ListItem>
                                                                    <asp:ListItem>06</asp:ListItem><asp:ListItem>07</asp:ListItem><asp:ListItem>08</asp:ListItem>
                                                                    <asp:ListItem>09</asp:ListItem><asp:ListItem>10</asp:ListItem><asp:ListItem>11</asp:ListItem>
                                                                    <asp:ListItem>12</asp:ListItem><asp:ListItem>13</asp:ListItem><asp:ListItem>14</asp:ListItem>
                                                                    <asp:ListItem>15</asp:ListItem><asp:ListItem>16</asp:ListItem><asp:ListItem>17</asp:ListItem>
                                                                    <asp:ListItem>18</asp:ListItem><asp:ListItem>19</asp:ListItem><asp:ListItem>20</asp:ListItem>
                                                                    <asp:ListItem>21</asp:ListItem><asp:ListItem>22</asp:ListItem><asp:ListItem>23</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:Label ID="StartHour" runat="server" Text=""></asp:Label>
                                                                    <asp:DropDownList ID="StartTimeMinuteDDL" runat="server" Width="50px">
                                                                    <asp:ListItem></asp:ListItem>
                                                                    <asp:ListItem>00</asp:ListItem><asp:ListItem>10</asp:ListItem><asp:ListItem>20</asp:ListItem>
                                                                    <asp:ListItem>30</asp:ListItem><asp:ListItem>40</asp:ListItem><asp:ListItem>50</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:Label ID="StartMinute" runat="server" Text=""></asp:Label>
                                                                </asp:Panel>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="運用終了時間">
                                                            <ItemStyle HorizontalAlign="Left" Width="40%"/>
                                                            <HeaderStyle Font-Bold="true" />
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="StopTimeHourDDL" runat="server" Width="50px">
                                                                <asp:ListItem></asp:ListItem>
                                                                <asp:ListItem>00</asp:ListItem><asp:ListItem>01</asp:ListItem><asp:ListItem>02</asp:ListItem>
                                                                <asp:ListItem>03</asp:ListItem><asp:ListItem>04</asp:ListItem><asp:ListItem>05</asp:ListItem>
                                                                <asp:ListItem>06</asp:ListItem><asp:ListItem>07</asp:ListItem><asp:ListItem>08</asp:ListItem>
                                                                <asp:ListItem>09</asp:ListItem><asp:ListItem>10</asp:ListItem><asp:ListItem>11</asp:ListItem>
                                                                <asp:ListItem>12</asp:ListItem><asp:ListItem>13</asp:ListItem><asp:ListItem>14</asp:ListItem>
                                                                <asp:ListItem>15</asp:ListItem><asp:ListItem>16</asp:ListItem><asp:ListItem>17</asp:ListItem>
                                                                <asp:ListItem>18</asp:ListItem><asp:ListItem>19</asp:ListItem><asp:ListItem>20</asp:ListItem>
                                                                <asp:ListItem>21</asp:ListItem><asp:ListItem>22</asp:ListItem><asp:ListItem>23</asp:ListItem>
                                                                <asp:ListItem>24</asp:ListItem><asp:ListItem>25</asp:ListItem><asp:ListItem>26</asp:ListItem>
                                                                <asp:ListItem>27</asp:ListItem><asp:ListItem>28</asp:ListItem><asp:ListItem>29</asp:ListItem>
                                                                <asp:ListItem>30</asp:ListItem><asp:ListItem>31</asp:ListItem><asp:ListItem>32</asp:ListItem>
                                                                <asp:ListItem>33</asp:ListItem><asp:ListItem>34</asp:ListItem><asp:ListItem>35</asp:ListItem>
                                                                <asp:ListItem>36</asp:ListItem><asp:ListItem>37</asp:ListItem><asp:ListItem>38</asp:ListItem>
                                                                <asp:ListItem>39</asp:ListItem><asp:ListItem>40</asp:ListItem><asp:ListItem>41</asp:ListItem>
                                                                <asp:ListItem>42</asp:ListItem><asp:ListItem>43</asp:ListItem><asp:ListItem>44</asp:ListItem>
                                                                <asp:ListItem>45</asp:ListItem><asp:ListItem>46</asp:ListItem><asp:ListItem>47</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:Label ID="StopHour" runat="server" Text=""></asp:Label>
                                                                <asp:DropDownList ID="StopTimeMinuteDDL" runat="server" Width="50px">
                                                                <asp:ListItem></asp:ListItem>
                                                                <asp:ListItem>00</asp:ListItem><asp:ListItem>10</asp:ListItem><asp:ListItem>20</asp:ListItem>
                                                                <asp:ListItem>30</asp:ListItem><asp:ListItem>40</asp:ListItem><asp:ListItem>50</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:Label ID="StopMinute" runat="server" Text=""></asp:Label>
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
                                             <asp:Button ID="ConfirmBtn" runat="server" Text="確定" OnClick="ConfirmBtn_Click" CssClass="btn type-01"/>
					                    </p>
				                    <!-- /str-pager-01 --></div>
			                    <!-- /str-wrap-result --></div>
                                <!-- 2015/10/20 FSWeb)Y.Tamura デザイン変更追加対応 End -->
                            </td>
                        </tr>
                    </table>
                    
                    </td>
                </tr>
                <tr class="TR_ARTICLE_BTN">
                            <td class="TD_ARTICLE_BTN">
                               
                                <asp:CustomValidator ID="StartEndValid" runat="server" Display="None" EnableClientScript="False"
                                    ErrorMessage="入力された運用時間は不正です。正しく入力してください。" OnServerValidate="StartEndValid_ServerValidate"></asp:CustomValidator></td>
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
