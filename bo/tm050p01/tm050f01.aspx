<%@ Page language="c#" CodeFile="tm050f01.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Tm050p01.Page.Tm050f01Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">CSV取込画面</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="tm050p01" FormId="tm050f01" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/tm050f01.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="tm050p01" FormId="tm050f01" runat="server" />

	<!-- 共通部品のインポート -->
    <script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
    <script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->

</head>

<body>
	<form id="Tm050f01" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">

			<uc:Header ID="header" runat="server" PgId="tm050p01" PgName="CSV取込画面" FormId="tm050f01" FormName="CSV取込画面" ></uc:Header>

			<!-------------------------------------------------------------------
									1.カード部
			--------------------------------------------------------------------->
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
<%--						<p class="required">*が付いている項目は必須入力になります。</p>--%>
					<div class="str-form-02">
						<div class="inner">
							<table>
								<colgroup>
									<col class="w-type-01">
									<col class="w-type-02">
									<col />
								</colgroup>
								<tbody>
									<tr>
									    <th></th>
										<td>
											<!--- 「csv名称」テキストボックスリードオンリー --->
											<asp:TextBox ID="Csv_nm" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
										</td>
										<td>
											<div>
												<!--- 「CSV参照」ファイルアップロード --->
												<asp:FileUpload ID="Csv_sansyo" CssClass="fileup1" runat="server" />
											</div>
										</td>
									</tr>
								</tbody>
							</table>
						<!-- /inner --></div>
					<!-- /str-form-02 --></div>
				<!-- /inner-02 --></div>
			<!-- /str-search-01 --></div>

			<!-------------------------------------------------------------------
									2.明細部
			--------------------------------------------------------------------->
			<input id="M1PageStartRow" type="hidden" runat="server"/>
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
					<div id="str-pager-top" class="str-pager-01" style="display: none;">
						<!--- 件数表示部 --->
						<p><adv:PageInfo ID="M1PageInfo" runat="server"></adv:PageInfo></p>
						<!--- ページャーを配置する場合はこの中 --->
						<!-- /str-pager-01 --></div>
					<!--一覧-->
					<div class="str-result-01">
						<%-- 明細ヘッダ --%>
						<div class="str-result-hdg-01">
							<div class="col1">
								<asp:Label ID="M1rowno_lbl" runat="server">No.</asp:Label>
							</div>
							<div class="col2">
								<asp:Label ID="M1err_nm_lbl" runat="server">エラー内容</asp:Label>
							</div>
						<!-- /str-result-hdg-01 --></div>
						<div id="str-result-item-wrap" class="adjust-elem">
							<asp:Repeater ID="M1" runat="server">
								<HeaderTemplate>
								</HeaderTemplate>
								<ItemTemplate>
									<div class="str-result-item-01">
										<div class="col1 detail_right">
											<!--- 「ｍ１行no」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1rowno" CssClass="inpReadonlyRight inpRONum4" runat="server"></asp:TextBox>
										</div>
										<div class="col2 detail_left">
											<!--- 「ｍ１エラー内容」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1err_nm" CssClass="inpReadonlyLeft inpROHankaku60 tooltip" runat="server"></asp:TextBox>
										</div>
									<!-- /str-result-item-01 --></div>
								</ItemTemplate>
							</asp:Repeater>
						<!-- /str-result-item-wrap --></div>
					<!-- /str-result-01 --></div>
					<!------------------------------------------
					  □ページャ下部領域
					-------------------------------------------->
					<span class="adjust-elem-next"></span>
				<!-- /inner --></div>
				<div id="footerBtnArea" class="pad0" runat="server">
					<div id="str-pager-bottom" class="footer str-pager-01 pad0">
						<p>
						</p>
						<p>
							<!-- ページャ下部にボタンを配置する場合はこの中 -->
							<!--- 「確定ボタン」ボタン --->
							<input type="button" id="Btnenter" value="確定" onserverclick="OnBTNENTER_FRM" runat="server" class="btn type-01 cmFup"/>
						</p>
					<!-- /str-pager-01 --></div>
				<!-- /footerBtnArea --></div>
			<!-- /str-wrap-result --></div>
		<!-- /wrap --></div>	

		<!-- 画面上隠しエレメントを格納するエリア-->
		<div id="hiddenElements" style="display:none" runat="server">
			<!--- 「csv名称」標題 --->
			<asp:Label ID="Csv_nm_lbl" runat="server"></asp:Label>
			<!--- 「csv参照」標題 --->
			<asp:Label ID="Csv_sansyo_lbl" runat="server"></asp:Label>
		</div>

	</form>
</body>
</html>

