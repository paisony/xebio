<%@ Page language="c#" CodeFile="ti010f01.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Ti010p01.Page.Ti010f01Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">部門別管理表出力</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="ti010p01" FormId="ti010f01" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/ti010f01.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="ti010p01" FormId="ti010f01" runat="server" />

	<!-- Js業務部品のインポート --->
    <script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
    <script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02001.js" charset="UTF-8"></script><!-- 店舗検索 -->

</head>

<body>
	<form id="Ti010f01" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="ti010p01" PgName="部門別管理表出力" FormId="ti010f01" FormName="部門別管理表出力" ></uc:Header>

            <!-------------------------------------------
              □ヘッダー部
            -------------------------------------------->
            
			<!--- 「ヘッダ店舗コード」一行テキストボックス（セパレート日付以外） --->
			<!--- 「ヘッダ店舗コードボタン」ボタン --->
	        <!--- 「ヘッダ店舗名」テキストボックスリードオンリー --->
			<p class="headerTenpo">
				<span class="icon-in">
					<md:MDTextBox ID="Head_tenpo_cd" CssClass="inpSerch inpHeaderTenpo" runat="server"></md:MDTextBox><input type="button" id="Btnheadtenpocd" name="Btnheadtenpocd" value="" runat="server" class="icon-search"/>
				</span>
				<asp:TextBox ID="Head_tenpo_nm" CssClass="inpReadonlyLeft inpHeaderTenpoNm" runat="server"></asp:TextBox>
			</p>

		<!-------------------------------------------------------------------
								1.カード部
		--------------------------------------------------------------------->
			<!-- search-list -->
			<div class="str-search-01">
		
				<!------------------------------------------
				  □検索条件領域(入力時)
				-------------------------------------------->
				<div class="inner-02">
					<p class="required">*が付いている項目は必須入力になります。</p>
					<table class="search-table">
						<tr>
							<td class="search-table-tdleft">
								<div class="str-form-02">
									<div class="inner">
										<table>
											<colgroup>
												<col class="w-type-01">
												<col />
											</colgroup>
											<tr>
												<th>
													<span class="tbl-hdg"><asp:Label ID="Eigyo_ymd_lbl" runat="server">営業日</asp:Label><asp:Label ID="Eigyo_ymd_Req" runat="server" CssClass="required">*</asp:Label></span>
												</th>
												<td>
													<!--- 「営業日」一行テキストボックス（セパレート日付以外） --->
													<span class="icon-in">
														<md:MDTextBox ID="Eigyo_ymd" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox>
													</span>
												</td>
											</tr>
										</table>
									<!-- /inner --></div>
								<!-- /str-form-02 --></div>
							<!-- /search-table-tdleft --></td>
							<td class="search-table-tdright">
		   						<div class="str-btn-search"/>
		   					</td>
						</tr>
					<!-- /search-table --></table>
				<!-- /inner-02 --></div>
		   	<!-- /str-search-01 --></div>

      		<!-------------------------------------------------------------------
       								2.明細部
       		--------------------------------------------------------------------->
       		<input id="M1PageStartRow" type="hidden" runat="server"/>
    		<!-- search-result -->
       		<div class="str-wrap-result">
				<!------------------------------------------
					□明細ボタン部
				-------------------------------------------->
       			<div id="str-btn-area" class="str-btn-utility">
       				<div id="meisaiBtnArea" class="inner pad0" runat="server">
       				<ul>
       					<!--明細制御系ボタンを配置する場合はこのulタグの中-->
       				</ul>
       				<ul>
       					<!--帳票／CSV系ボタンを配置する場合はこのulタグの中-->
       					<!--- 「ボタン印刷」ボタン --->
       					<span><label><input type="button" id="Btnprint" value="" onserverclick="OnBTNPRINT_FRM" runat="server" class="icon-utility-04"/>印刷</label></span>
       				</ul>
       				<!-- /meisaiBtnArea --></div>
       			<!-- /str-btn-utility --></div>
			<!-- /str-wrap-result --></div>
        <!-- /wrap --></div>
            	
		    <!-- 画面上隠しエレメントを格納するエリア-->
	    	<div id="hiddenElements" style="display:none" runat="server">
	        	<asp:Label ID="Head_tenpo_cd_lbl" runat="server"></asp:Label>
	    		<asp:Label ID="Head_tenpo_cd_Req" runat="server" CssClass="required">*</asp:Label>
	    		<asp:Label ID="Head_tenpo_nm_lbl" runat="server"></asp:Label>
	    	</div>
       	</form>
    </body>
</html>

