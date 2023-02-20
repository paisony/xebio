<%@ Page Language="c#" Inherits="Pjcommon.Code.CodeCODPage" CodeFile="CodeCOD.aspx.cs" %>

<%@ Register Assembly="com.xebio.bo.Common" Namespace="Common.Advanced.Web.Control" TagPrefix="adv" %>
<%@ Import Namespace="Common.Advanced.Codecondition.Code.Util" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta http-equiv="Content-Style-Type" content="text/css">
    <title>
        <%# WindowTitle %>
    </title>
    <adv:ContentType ID="ContentType1" runat="server" />
    <meta http-equiv="Cache-Control" content="no-cache" />
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Expires" content="-1" />
    <!-- IE7互換性META -->
    <meta http-equiv="X-UA-Compatible" content="IE=emulateIE7" />
    <link title="default" href="../boStyle/base.css" type="text/css" rel="stylesheet"
        charset="UTF-8" />
    <link title="default" href="../boStyle/code.css" type="text/css" rel="stylesheet"
        charset="UTF-8" />
    <script type="text/javascript" src="../boJs/jquery.min.js" charset="UTF-8"></script>
    <script type="text/javascript" src="Code.js" charset="UTF-8"></script>
    <script type="text/javascript" src="../js/KeySafe.js" charset="UTF-8"></script>
    <%# CheckJSInclude %>
    <script type="text/javascript">
	<!--
		// 検索結果の出力
		<%# ResultJS %>
		<%# MappingJS %>
		var lang = '<%# Language %>';
		var alertMsg = '';
        meisainumber="<%# codeContext.Command.MNo %>";
        levelid="<%# codeContext.Command.MID %>"
        codeId="<%# codeContext.CodeID %>";
        ItemId="<%# codeContext.Command.ItemID %>"
        mStartIdx="<%# codeContext.Command.MStartIndex %>";
        		
        $(function() {
            $('table.nametable tr td').hover(
                function(){
                    var colIndex = $(this).parent('tr').children('td').index(this) + 1;
                    $(this).parent('tr').addClass('rowHighlight');
                },
                function() {
                    $('table.nametable tr').removeClass('rowHighlight');
                }
            );
        });

		function SubmitCheck(){
			// チェック用メソッドがあったらメソッド実行
			try {
				alertMsg = '<%# AlertMessage %>';
				var checkResult = DoCheck();
				if (!checkResult) {
					return false;
				}
			} catch(e) {
				//alert("DoCheck関数の実行に失敗しました。");
			}
			return true;
		}
		
		function SetTextFocus(){
			try{
				if (document.getElementById("CodeCOD")!=null){
					if (GetFirstControl()!=null) {
						GetFirstControl().focus();
					}
				}
			}
			catch(e){
			//Do nothing
			}
		}
		
		function GetFirstControl() {
			return document.getElementById(GetMeisaiItemName("inputControls","KeyItemsList",-1)).children[0];
		}
		
		function GetSearchControl(id) {
			var index = 0;
			var searchItemID = "";
			while (index >= 0) {
				if (document.getElementById(GetMeisaiItemName("ItemID","KeyItemsList",index-1)) == null) {
					index = -1;
					return null;
				}
				else {
					searchItemID = document.getElementById(GetMeisaiItemName("ItemID","KeyItemsList",index-1)).value;
					if (searchItemID == id) {
						break;
					}
					else {
						index++;
					}
				}
			}
			var itemType = document.getElementById(GetMeisaiItemName("ItemType","KeyItemsList",index-1));
			if ((itemType.value == "CBLItem") || (itemType.value == "RadioItem")) {
				var ret = new Array();
				var cblIndex = 0;
				while (cblIndex >= 0) {
					var cblCtrl = document.getElementById(GetMeisaiItemName(itemType.value+"_"+cblIndex,"KeyItemsList",index-1));
					if (cblCtrl == null) {
						cblIndex = -1;
					}
					else {
						ret[cblIndex] = cblCtrl;
						cblIndex++;
					}
				}
				return ret;
			}
			else {
				return document.getElementsByName(GetMeisaiItemName(itemType.value,"KeyItemsList",index-1));
			}
		}
		
		var submitFlg = false;
		function ExecSubmit(id, doCheck) {
		    if (doCheck) {
    			var checkRes = SubmitCheck();
	    		if (!checkRes) {
	    		    alert(alertMsg);
		    		return false;
			    }
			}
			
			var form = document.getElementById("CodeCOD");
			if(form.__EVENTTARGET!=null)
			{
				form.__EVENTTARGET.value = id;
				form.__EVENTARGUMENT.value = '';
			}
			else
			{
				form.innerHTML=form.innerHTML+
					"<input type='hidden' name='__EVENTTARGET' value='' />"+
					"<input type='hidden' name='__EVENTARGUMENT' value='' />";
				form.elements("__EVENTTARGET").value = id;
				form.elements("__EVENTARGUMENT").value = '';
			}
			if (!submitFlg) {
				submitFlg = true;
				form.submit();
			}
			return false;
		}
		
		function PageInit() {
		    
		
		
			var firsttimeflag=<%# codeContext.Form.IsFirstTime.ToString().ToLower() %>;
			if (firsttimeflag) {				
			    function resizing(){
			        try{
				        var windowWidth=<%# codeContext.Window.Width %>;
				        var windowHeight=<%# codeContext.Window.Height %>;
				        var v1=parseInt(windowWidth);
				        var v2=parseInt(windowHeight)+70;
				        	        
				        window.resizeTo(v1,v2);
				        window.moveTo((screen.width-windowWidth)/2, (screen.height-windowHeight)/2);
				        window.focus();
				        
				        
				        
				        return true;
				    }catch(e){
				        return false;
				    }
				};
								
				for(i=0; i<10; i++){
				    if(resizing()){
				        break;
				    }
				}
			}
			SetTextFocus();
            
    // ホバー処理
    var $resultItem = $('.str-result-item-01');
    $resultItem.hover(function() {
        $(this).addClass('js-hover');
    }, function() {
        $(this).removeClass('js-hover');
    });
    function adjustHeight(){

        // 指定のウィンドウの高さを格納
        // ※「$(window).height()」だと正しく取れない事があるので
        //   取れない場合は「window.innerHeight」を使用
        //        var winHeight = $(window).height();
        var winHeight = window.innerHeight ? window.innerHeight : $(window).height();
        if (winHeight < 160) {
            winHeight = 160;
        }
        // ※スクロールバーが出てしまう画面があるので調整
        winHeight = winHeight - 1;
        // 高さを調節する要素
        var adjustElem = $('#CodeGridViewDiv');
        // 高さを調節する要素のウィンドウ上からの距離を取得
        var adjustElemPosition = adjustElem.offset();
        // 初期検索無しの場合エラーが発生するのでnullチェックを行う。
        if(adjustElemPosition != null){
            // 調節する要素に当てはめる高さを計算
            var adjustedHeight = winHeight - adjustElemPosition.top;
            adjustElem.css('height', adjustedHeight + 'px');
        }
    }

    adjustHeight();
    $(window).resize(function () {
        adjustHeight();
    });

			
		}
		
		function GetResultSet(index) {
			return(resultValues[index]);
		}

		//[ENTER]キー対応
		function NextItem(nextid) {
			//Enter
			if (event.keyCode==13){
				//document.getElementById(nextid).focus();
				//event.keyCode=9;
			}
		}
	-->
    </script>
</head>
<body onload="javascript:PageInit();">
    <form id="CodeCOD" method="post" onsubmit="return ExecSubmit('SearchBtn',true);"
    runat="server" onprerender="CodeCOD_PreRender" class="form">
    <div id="header" runat="server">
        <div class="inner" style="width: 100%;padding-left:0;padding-right:0;">
            <div class="header-utility-01" style="padding-left:20px;">
                <!---------------------------------------▼▼▼ 編集対象箇所 START ▼▼▼--------------------------------------->
                <h1 class="hdg-lv1-01">
                    <%# WindowTitle %></h1>
                <!----------------------------------------▲▲▲ 編集対象箇所 END ▲▲▲---------------------------------------->
                <!-- /header-utility-01 -->
            </div>
            <div class="header-utility-02" style="padding-right:20px;">
                <p class="btn-logout" onclick="window.close()" style="height:26px;overflow:hidden;padding-top:5px; ">
                    <img src="../boImages/icon-logout.png" height="37" width="40" alt=""></p>
                <!-- /header-utility-02 -->
            </div>
            <!-- /inner -->
        </div>
        <!-- /header -->
    </div>
    <table class="table_main" id="MainTable" width="100%" runat="server">
        <tr id="SearchFormRow">
            <td align="center" style="width: 100%">
            <div id="str-search-01">
                <div class="inner-02">
                <table class="search-table" style="width:100%;box-sizing: border-box;">
                    <tr>
                        <td class="search-table-tdleft">
                            <div class="str-form-02" style="width:100%;box-sizing: border-box;">
                                <div class="inner" style="width:99%;box-sizing: border-box;">
                                    <table style="width:99%;box-sizing: border-box;">
                                        <asp:Repeater ID="KeyItemsList" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <th class="last" style="padding-right:15px;">
                                                        <asp:Label ID="SearchItemCaption" runat="server" CssClass="tbl-hdg">
																	    <%# DataBinder.Eval(Container.DataItem, "Caption") %>
                                                        </asp:Label>
                                                    </th>
                                                    <td runat="server" id="inputControls" class="last">
                                                        <asp:DropDownList ID="DDLItem" runat="server">
                                                        </asp:DropDownList>
                                                        <asp:RadioButtonList ID="RadioItem" runat="server">
                                                        </asp:RadioButtonList>
                                                        <asp:TextBox ID="InputItem" runat="server"></asp:TextBox>
                                                        <asp:ListBox ID="ListItem" runat="server"></asp:ListBox>
                                                        <asp:CheckBoxList ID="CBLItem" runat="server">
                                                        </asp:CheckBoxList>
                                                        <input id="ItemID" type="hidden" value='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                                            name="ItemID" runat="server" />
                                                        <input id="ItemType" type="hidden" name="ItemType" runat="server" />
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </table>
                                <!-- /inner --></div>
                            <!-- /str-form-02 --></div>
                        </td>
                        <td class="search-table-tdright" style="width:130px;">
                            <div class="str-btn-search">
                                <asp:Button ID="SearchBtn" runat="server" Text="" class="btn type-02" Style="border: 0;margin-left:0 !important;width:120px;"
                                    UseSubmitBehavior="false"></asp:Button>
                                <!-- /str-btn-search -->
                            </div>
                        </td>
                    </tr>
                </table>
                <!-- /inner-02 --></div>
            <!-- /str-search-01 --></div>
    <asp:Label ID="InputRequiredMessage" runat="server" Font-Bold="True" Font-Size="X-Small"
        ForeColor="Red" Text="検索条件を入力してください。" Visible="False" CssClass="normal"></asp:Label>
    </td> </tr>
    <tr id="DispResultRow">
        <td>
                <div id="str-pager-top" class="str-pager-01">
                    <p style="text-align:left;left:0;">
                        <adv:PageInfo ID="ResultInfo" runat="server" Font-Bold="False" /><asp:Label ID="StartRow"
                            runat="server" Text="Label" Visible="False"></asp:Label>
                    </p>
                    <div class="pager-01" style="width:180px;">
                        <ul>
                        <li style="width:80px;"><asp:LinkButton ID="PrevPage" runat="server" Width="80px"></asp:LinkButton>
                        <li style="width:80px;"><asp:LinkButton ID="NextPage" runat="server" Width="80px"></asp:LinkButton>
                        </ul>
                    <!-- /pager-01 --></div>
                <!-- /str-pager-01 --></div>
        </td>
    </tr>
    <tr id="PageChangeRow">
        <td>
            <table>
                <tr>
                </tr>
            </table>
        </td>
    </tr>
    <tr id="DispDataRow">
        <td valign="top" colspan="2">
            <div id="CodeGridViewDiv" runat="server">
                <asp:GridView ID="CodeGridView" PagerSettings-Visible="false" runat="server" style="width:auto;"
                    AutoGenerateColumns="False" CssClass="nametable str-result-01" AllowPaging="True"
                    GridLines="None">
                    <RowStyle CssClass="str-result-item-01"></RowStyle>
                    <AlternatingRowStyle CssClass="str-result-item-01" />
                    <HeaderStyle CssClass="str-result-hdg-01"></HeaderStyle>
                    <PagerSettings Visible="False" />
                </asp:GridView>
            </div>
        </td>
    </tr>
    <tr id="SearchDemandRow">
        <td valign="top" style="height: 60%">
            <asp:Label ID="ReqSearchItemMessage" runat="server" Font-Bold="True" ForeColor="Navy">検索文字列を入力してください。</asp:Label>
        </td>
    </tr>
    </tbody> </table>
    </form>
</body>
</html>
