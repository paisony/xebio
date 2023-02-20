<%@ Page language="c#" CodeFile="aa010f01.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Aa010p01.Page.Aa010f01Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">■印刷テスト</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="aa010p01" FormId="aa010f01" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/aa010f01.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="aa010p01" FormId="aa010f01" runat="server" />
</head>

<body>
	<form id="Aa010f01" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="aa010p01" PgName="■印刷テスト" FormId="aa010f01" FormName="■印刷テスト" ></uc:Header>
			
			<!------------------------------------------
				□ヘッダー部
			-------------------------------------------->
			
			<!------------------------------------------
				□ヘッダー部
			-------------------------------------------->

			<!--- 「ヘッダ店舗コード」一行テキストボックス（セパレート日付以外） --->
			<!--- 「ボタンヘッダ店舗コード」ボタン --->
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
			<div id="tab1" class="str-tab-cont">
				<!-- search-list -->
				<div class="str-search-01">
		
					<!------------------------------------------
					  □検索条件領域(非表示時)
					-------------------------------------------->
					<div class="inner-01" style="display:none;">
						<p id="list-search"></p>
						<p class="txt-02">該当件数<span class="hit-number"></span><span>件</span></p>
					<!-- /inner-01 --></div>
		
					<!------------------------------------------
					  □検索条件領域(入力時)
					-------------------------------------------->
					<div class="inner-02">
						<p class="required">*が付いている項目は必須入力になります。</p>
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
												<asp:Label ID="Report_dl_lbl" runat="server">■帳票選択</asp:Label>
											</span>
										</th>
										<td>
											<!--- 「帳票選択」ドロップダウンリスト --->
											<asp:DropDownList ID="Report_dl" CssClass="slt-ddl slt_Reportdl" runat="server"></asp:DropDownList>
											<span class="select-arrow"></span></td>
									</tr>
									<tr>
										<th scope="col">
										</th>
										<td>
											<!--- 「印刷ボタン」ボタン --->
											印刷⇒<input type="button" id="Btnprint" value="" onserverclick="OnBTNPRINT_FRM" runat="server" class="btn type-01"/>
										</td>
									</tr>
								</table>
							<!-- /inner --></div>
						<!-- /str-form-02 --></div>
		    		<!-- /inner-02 --></div>
		    	<!-- /str-search-01 --></div>
			<!-- /tab1 --></div>
		





		<!-- /wrap --></div>	
		
		<!-- 画面上隠しエレメントを格納するエリア-->
		<div id="hiddenElements" style="display:none" runat="server">
		     
			<asp:Label ID="Head_tenpo_nm_lbl" runat="server"></asp:Label>

			<asp:Label ID="Head_tenpo_cd_lbl" runat="server"></asp:Label>
		</div>
	
	</form>
</body>
</html>

