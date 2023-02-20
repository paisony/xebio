<%@ Page language="c#" CodeFile="tj180f01.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Tj180p01.Page.Tj180f01Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">棚卸進捗確認</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="tj180p01" FormId="tj180f01" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/tj180f01.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="tj180p01" FormId="tj180f01" runat="server" />

	<!-- JS --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->

	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02001.js" charset="UTF-8"></script><!-- 店舗検索 -->
</head>

<body>
	<form id="Tj180f01" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="tj180p01" PgName="棚卸進捗確認" FormId="tj180f01" FormName="棚卸進捗確認" ></uc:Header>
			
			<!------------------------------------------
				□ヘッダー部
			-------------------------------------------->

			<!--- 「ヘッダ店舗コード」一行テキストボックス（セパレート日付以外） --->
			<!--- 「ヘッダ店舗コードボタン」ボタン --->
			<!--- 「ヘッダ店舗名」テキストボックスリードオンリー --->
			<p class="headerTenpo">
				<span class="icon-in">
				<md:MDTextBox ID="Head_tenpo_cd" CssClass="inpSerch inpHeaderTenpo" runat="server"></md:MDTextBox>
					<input type="button" id="Btnheadtenpocd" name="Btnheadtenpocd" value="" runat="server" class="icon-search"/>
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
					<%--<p class="required">*が付いている項目は必須入力になります。</p>--%>
					
					<table class="search-table">
					<tr>
						<td class="search-table-tdleft">
						<div class="str-form-02">
							<div class="inner">
								<table>
									<colgroup>
										<col class="w-type-01"/>
										<col class="w-type-02"/>
										<col class="w-type-01"/>
										<col class="w-type-02"/>
										<col />
									</colgroup>
									<tr>
										<th>
											<span class="tbl-hdg">
												<asp:Label ID="Kijunbi_zen_tyobozaiko_su_lbl" runat="server">基準日前日帳簿在庫数</asp:Label>
											</span>
										</th>
										<td>
											<!--- 「基準日前日帳簿在庫数」テキストボックスリードオンリー --->
											<asp:TextBox ID="Kijunbi_zen_tyobozaiko_su" CssClass="inpReadonlyRight inpRONumCmaMinus8" runat="server"></asp:TextBox>
										</td>
									</tr>
									<tr>
										<th>
											<span class="tbl-hdg">
												<asp:Label ID="Tojitsuuri_su_lbl" runat="server">当日売上数</asp:Label>
											</span>
										</th>
										<td>
											<!--- 「当日売上数」テキストボックスリードオンリー --->
											<asp:TextBox ID="Tojitsuuri_su" CssClass="inpReadonlyRight inpRONumCmaMinus8" runat="server"></asp:TextBox>
										</td>
									</tr>
									<tr>
										<th>
											<span class="tbl-hdg">
												<asp:Label ID="Tojitsunyusyukka_su_lbl" runat="server">当日入出荷数</asp:Label>
											</span>
										</th>
										<td>
											<!--- 「当日入出荷数」テキストボックスリードオンリー --->
											<asp:TextBox ID="Tojitsunyusyukka_su" CssClass="inpReadonlyRight inpRONumCmaMinus8" runat="server"></asp:TextBox>
										</td>
									</tr>
									<tr>
										<th>
											<span class="tbl-hdg">
												<asp:Label ID="Tojitsuyosokuzai_su_lbl" runat="server">当日予測在庫数</asp:Label>
											</span>
										</th>
										<td>
											<!--- 「当日予測在庫数」テキストボックスリードオンリー --->
											<asp:TextBox ID="Tojitsuyosokuzai_su" CssClass="inpReadonlyRight inpRONumCmaMinus8" runat="server"></asp:TextBox>
										</td>
									</tr>
									<tr>
										<th>
											<span class="tbl-hdg">
												<asp:Label ID="Tenpotanaorosi_su_lbl" runat="server">店舗棚卸数</asp:Label>
											</span>
										</th>
										<td>
											<!--- 「店舗棚卸数」テキストボックスリードオンリー --->
											<asp:TextBox ID="Tenpotanaorosi_su" CssClass="inpReadonlyRight inpRONumCmaMinus8" runat="server"></asp:TextBox>
										</td>
									</tr>
									<tr>
										<th>
											<span class="tbl-hdg">
												<asp:Label ID="Gyosyatanaorosi_su_lbl" runat="server">業者棚卸数</asp:Label>
											</span>
										</th>
										<td>
											<!--- 「業者棚卸数」テキストボックスリードオンリー --->
											<asp:TextBox ID="Gyosyatanaorosi_su" CssClass="inpReadonlyRight inpRONumCmaMinus8" runat="server"></asp:TextBox>
										</td>
										<th>
											<span class="tbl-hdg">
												<asp:Label ID="Sai_su_lbl" runat="server">差異数</asp:Label>
											</span>
										</th>
										<td>
											<!--- 「差異数」テキストボックスリードオンリー --->
											<asp:TextBox ID="Sai_su" CssClass="inpReadonlyRight inpRONumCmaMinus8" runat="server"></asp:TextBox>
										</td>
									</tr>
								</table>
							<!-- /inner --></div>
						<!-- /str-form-02 --></div>

						<td class="search-table-tdright">
							<div class="str-btn-search">
								<!--- 「検索ボタン」ボタン --->
								<input type="button" id="Btnsearch" value="検索" onserverclick="OnBTNSEARCH_FRM" runat="server" class="btn type-02"/>
							</div>
						</td>
					</tr>
					</table>

					<!-- /inner-02 --></div>
				<!-- /str-search-01 --></div>
			<!-- /tab1 --></div>
		<!-- /wrap --></div>	
		
		<!-- 画面上隠しエレメントを格納するエリア-->
		<div id="hiddenElements" style="display:none" runat="server">
			<asp:Label ID="Head_tenpo_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Head_tenpo_cd_lbl" runat="server"></asp:Label>
			<asp:Label ID="Head_tenpo_cd_Req" runat="server" CssClass="required">*</asp:Label>
		</div>
	
	</form>
</body>
</html>

