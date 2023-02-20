<%@ Page language="c#" CodeFile="tf060f01.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Tf060p01.Page.Tf060f01Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">予算登録</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="tf060p01" FormId="tf060f01" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/tf060f01.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="tf060p01" FormId="tf060f01" runat="server" />

	<!-- Js業務部品のインポート --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02001.js" charset="UTF-8"></script><!-- 店舗検索 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05010.js" charset="UTF-8"></script><!-- カンマ編集処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05024.js" charset="UTF-8"></script><!-- 数値編集関数群 -->

</head>

<body>
	<form id="Tf060f01" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="tf060p01" PgName="予算登録" FormId="tf060f01" FormName="予算登録" ></uc:Header>

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
			<!-- search-list -->
			<div class="str-search-01">

				<!------------------------------------------
				  □検索条件領域(非表示時)
				-------------------------------------------->
				<div class="inner-01" style="display:none;">
					<table class="search-table">
						<tr>
							<td class="search-table-tdleft">
								<div class="list-search-condition">
								<!-- /list-search-condition --></div>
							</td>
							<td class="search-table-tdright">
								<div class="list-search-result">
								<!-- /list-search-result --></div>
							</td>
						</tr>
					</table>
				<!-- /inner-01 --></div>

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
												<col class="w-type-01"/>
												<col />
											</colgroup>
											<tr>
												<th scope="col">
													<span class="tbl-hdg">
														<asp:Label ID="Getudo_lbl" runat="server">月度</asp:Label>
														<asp:Label ID="Getudo_Req" runat="server" CssClass="required">*</asp:Label>
													</span>
												</th>
												<td>
													<!--- 「月度」一行テキストボックス（セパレート日付以外） --->
													<md:MDTextBox ID="Getudo" CssClass="inpGetsudo" runat="server"></md:MDTextBox>
												</td>
											</tr>
										</table>
									<!-- /inner --></div>
								<!-- /str-form-02 --></div>
							</td>
							<td class="search-table-tdright">
								<div class="str-btn-search">
									<!--- 「ボタン検索」ボタン --->
									<input type="button" id="Btnsearch" value="検索" onserverclick="OnBTNSEARCH_FRM" runat="server" class="btn type-02"/>
								<!-- /str-btn-search --></div>
							</td>
						</tr>
					</table>

				<!-- /inner-02 --></div>
			<!-- /str-search-01 --></div>

			<!--- アコーディオン --->
			<div class="trigger-search-01">
				<a href="#"></a>
			<!-- /trigger-search-01 --></div>

		<!-------------------------------------------------------------------
								2.明細部
		--------------------------------------------------------------------->
		<input id="M1PageStartRow" type="hidden" runat="server"/>
			<!-- search-result -->
			<div class="str-wrap-result">
				<!------------------------------------------
					□明細ボタン部
				-------------------------------------------->
				<!-- button -->
				<div id="str-btn-area" class="str-btn-utility">
					<div id="meisaiBtnArea" class="inner pad0" runat="server">
					<ul>
						<!--明細制御系ボタンを配置する場合はこのulタグの中-->
						<!--- 「CSV取込ボタン」ボタン --->
						<li><span><label><input type="button" id="Btncsv_torikomi" value="" onserverclick="OnBTNCSV_TORIKOMI_FRM" runat="server" class="icon-utility-05"/>CSV取込</label></span><li>
					</ul>
					<ul>
						<!--帳票／CSV系ボタンを配置する場合はこのulタグの中-->
					</ul>
					<!-- /meisaiBtnArea --></div>
				<!-- /utility --></div>

				<!------------------------------------------
					□明細部
				-------------------------------------------->
				<div class="inner">
					<div id="str-pager-top" class="str-pager-tani">
						<!--<p><adv:PageInfo ID="M1PageInfo" runat="server"></adv:PageInfo></p>-->
						<span>単位：千円</span>
					<!-- /str-pager-tani --></div>

					<!--一覧-->
					<div class="str-result-01">
					<%-- 明細ヘッダ --%>
						<div class="str-result-hdg-01">
							<div class="col1">
								<asp:Label ID="M1getunai_hiduke_lbl" runat="server">日</asp:Label>
							</div>
							<div class="col2">
								<asp:Label ID="M1yobi_lbl" runat="server">曜日</asp:Label>
							</div>
							<div class="col3">
								<asp:Label ID="M1bumon1_yosan_kin_lbl" runat="server">部門１</asp:Label>
							</div>
							<div class="col4">
								<asp:Label ID="M1bumon2_yosan_kin_lbl" runat="server">部門２</asp:Label>
							</div>
							<div class="col5">
								<asp:Label ID="M1bumon3_yosan_kin_lbl" runat="server">部門３</asp:Label>
							</div>
							<div class="col6">
								<asp:Label ID="M1bumon4_yosan_kin_lbl" runat="server">部門４</asp:Label>
							</div>
							<div class="col7">
								<asp:Label ID="M1bumon5_yosan_kin_lbl" runat="server">部門５</asp:Label>
							</div>
							<div class="col8">
								<asp:Label ID="M1hibetu_yosan_kin_lbl" runat="server">合計</asp:Label>
							</div>
							<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
							<div style="display:none">
								<asp:Label ID="M1bumon1_yosan_kin_hdn_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1bumon2_yosan_kin_hdn_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1bumon3_yosan_kin_hdn_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1bumon4_yosan_kin_hdn_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1bumon5_yosan_kin_hdn_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1selectorcheckbox_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1entersyoriflg_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1dtlirokbn_lbl" runat="server"></asp:Label>
							</div>
							<!--- 隠し項目エリア↑↑↑↑↑↑↑↑↑↑↑↑↑ --->
						<!-- /str-result-hdg-01 --></div>

						<div id="bumongokeiArea" class="str-result-item-01" runat="server">
							<div class="col0 detail_center">
								<asp:Label ID="Tukibetu_bumon1_yosan_kin_lbl" runat="server">月別部門合計</asp:Label>
							</div>
							<div class="col3 detail_right">
								<!--- 「月別部門１予算額」一行テキストボックス（セパレート日付以外） --->
								<md:MDTextBox ID="Tukibetu_bumon1_yosan_kin" CssClass="inpSu-06" runat="server"></md:MDTextBox>
							</div>
							<div class="col4 detail_right">
								<!--- 「月別部門２予算額」一行テキストボックス（セパレート日付以外） --->
								<md:MDTextBox ID="Tukibetu_bumon2_yosan_kin" CssClass="inpSu-06" runat="server"></md:MDTextBox>
							</div>
							<div class="col5 detail_right">
								<!--- 「月別部門３予算額」一行テキストボックス（セパレート日付以外） --->
								<md:MDTextBox ID="Tukibetu_bumon3_yosan_kin" CssClass="inpSu-06" runat="server"></md:MDTextBox>
							</div>
							<div class="col6 detail_right">
								<!--- 「月別部門４予算額」一行テキストボックス（セパレート日付以外） --->
								<md:MDTextBox ID="Tukibetu_bumon4_yosan_kin" CssClass="inpSu-06" runat="server"></md:MDTextBox>
							</div>
							<div class="col7 detail_right">
								<!--- 「月別部門５予算額」一行テキストボックス（セパレート日付以外） --->
								<md:MDTextBox ID="Tukibetu_bumon5_yosan_kin" CssClass="inpSu-06" runat="server"></md:MDTextBox>
							</div>
							<div class="col8 detail_right">
								<!--- 「月別予算額合計」テキストボックスリードオンリー --->
								<asp:TextBox ID="Tukibetu_yosan_kin_gokei" CssClass="inpReadonlyRight inpRONumCma8" runat="server"></asp:TextBox>
							</div>
						<!-- /str-result-hdg-01 --></div>

						<div id="str-result-item-wrap" class="adjust-elem">
							<asp:Repeater ID="M1" runat="server">
								<HeaderTemplate>
								</HeaderTemplate>
								<ItemTemplate>
									<div id="M1Row" class="str-result-item-01" runat="server">
										<div class="col1 detail_right">
											<!--- 「ｍ１月内日付」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1getunai_hiduke" CssClass="inpReadonlyRight inpRONum2" runat="server"></asp:TextBox>
										</div>
										<div class="col2 detail_center">
											<!--- 「ｍ１曜日」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1yobi" CssClass="inpReadonlyCenter inpROZenkaku1" runat="server"></asp:TextBox>
										</div>
										<div class="col3 detail_right">
											<!--- 「ｍ１部門１予算額」一行テキストボックス（セパレート日付以外） --->
											<md:MDTextBox ID="M1bumon1_yosan_kin" CssClass="inpSu-06" runat="server"></md:MDTextBox>
										</div>
										<div class="col4 detail_right">
											<!--- 「ｍ１部門２予算額」一行テキストボックス（セパレート日付以外） --->
											<md:MDTextBox ID="M1bumon2_yosan_kin" CssClass="inpSu-06" runat="server"></md:MDTextBox>
										</div>
										<div class="col5 detail_right">
											<!--- 「ｍ１部門３予算額」一行テキストボックス（セパレート日付以外） --->
											<md:MDTextBox ID="M1bumon3_yosan_kin" CssClass="inpSu-06" runat="server"></md:MDTextBox>
										</div>
										<div class="col6 detail_right">
											<!--- 「ｍ１部門４予算額」一行テキストボックス（セパレート日付以外） --->
											<md:MDTextBox ID="M1bumon4_yosan_kin" CssClass="inpSu-06" runat="server"></md:MDTextBox>
										</div>
										<div class="col7 detail_right">
											<!--- 「ｍ１部門５予算額」一行テキストボックス（セパレート日付以外） --->
											<md:MDTextBox ID="M1bumon5_yosan_kin" CssClass="inpSu-06" runat="server"></md:MDTextBox>
										</div>
										<div class="col8 detail_right">
											<!--- 「ｍ１日別予算額」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1hibetu_yosan_kin" CssClass="inpReadonlyRight inpRONumCma8" runat="server"></asp:TextBox>
										</div>

										<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
										<div style="display:none">
											<!--- 「Ｍ１部門１予算額(隠し)」隠しフィールド --->
											<asp:hiddenfield ID="M1bumon1_yosan_kin_hdn" runat="server"></asp:hiddenfield>
											<!--- 「Ｍ１部門２予算額(隠し)」隠しフィールド --->
											<asp:hiddenfield ID="M1bumon2_yosan_kin_hdn" runat="server"></asp:hiddenfield>
											<!--- 「Ｍ１部門３予算額(隠し)」隠しフィールド --->
											<asp:hiddenfield ID="M1bumon3_yosan_kin_hdn" runat="server"></asp:hiddenfield>
											<!--- 「Ｍ１部門４予算額(隠し)」隠しフィールド --->
											<asp:hiddenfield ID="M1bumon4_yosan_kin_hdn" runat="server"></asp:hiddenfield>
											<!--- 「Ｍ１部門５予算額(隠し)」隠しフィールド --->
											<asp:hiddenfield ID="M1bumon5_yosan_kin_hdn" runat="server"></asp:hiddenfield>
											<!--- 「ｍ１選択フラグ(隠し)」チェックボックス --->
											<adv:AdvancedCheckBox ID="M1selectorcheckbox" Text="" CssClass="" runat="server"></adv:AdvancedCheckBox>
											<!--- 「Ｍ１確定処理フラグ(隠し)」隠しフィールド --->
											<asp:hiddenfield ID="M1entersyoriflg" runat="server"></asp:hiddenfield>
											<!--- 「Ｍ１明細色区分(隠し)」隠しフィールド --->
											<asp:hiddenfield ID="M1dtlirokbn" runat="server"></asp:hiddenfield>
										</div>
										<!--- 隠し項目エリア↑↑↑↑↑↑↑↑↑↑↑↑↑ --->
									<!-- /str-result-item-01 --></div>
								</ItemTemplate>
							</asp:Repeater>
						<!-- /str-result-item-wrap --></div>
						<span class="adjust-elem-next"></span>
						<div id="footerArea" class="str-result-ftr-01" runat="server">
							<div class="col1 detail_left">&nbsp;</div>
							<div class="col2 detail_ftr_title"><asp:Label ID="Bumon1_yosangokei_kin_lbl" runat="server">合計</asp:Label></div>
							<!--- 「部門１予算額合計」テキストボックスリードオンリー --->
							<div class="col3 detail_ftr"><span><asp:TextBox ID="Bumon1_yosangokei_kin" CssClass="inpReadonlyRight inpRONumCma8" runat="server"></asp:TextBox></span></div>
							<!--- 「部門２予算額合計」テキストボックスリードオンリー --->
							<div class="col4 detail_ftr"><span><asp:TextBox ID="Bumon2_yosangokei_kin" CssClass="inpReadonlyRight inpRONumCma8" runat="server"></asp:TextBox></span></div>
							<!--- 「部門３予算額合計」テキストボックスリードオンリー --->
							<div class="col5 detail_ftr"><span><asp:TextBox ID="Bumon3_yosangokei_kin" CssClass="inpReadonlyRight inpRONumCma8" runat="server"></asp:TextBox></span></div>
							<!--- 「部門４予算額合計」テキストボックスリードオンリー --->
							<div class="col6 detail_ftr"><span><asp:TextBox ID="Bumon4_yosangokei_kin" CssClass="inpReadonlyRight inpRONumCma8" runat="server"></asp:TextBox></span></div>
							<!--- 「部門５予算額合計」テキストボックスリードオンリー --->
							<div class="col7 detail_ftr"><span><asp:TextBox ID="Bumon5_yosangokei_kin" CssClass="inpReadonlyRight inpRONumCma8" runat="server"></asp:TextBox></span></div>
							<!--- 「予算額合計」テキストボックスリードオンリー --->
							<div class="col8 detail_ftr"><span><asp:TextBox ID="Yosangokei_kin" CssClass="inpReadonlyRight inpRONumCma8" runat="server"></asp:TextBox></span></div>
						<!-- /str-result-ftr-01 --></div>

					<!-- /str-result-01 --></div>
					<!------------------------------------------
					  □ページャ下部領域
					-------------------------------------------->
				<!-- /inner --></div>
				<div id="footerBtnArea" class="pad0" runat="server">
					<div id="str-pager-bottom" class="footer str-pager-01 pad0">
						<p>
						</p>
						<p>
							<!-- ページャ下部にボタンを配置する場合はこの中 -->
							<!--- 「確定ボタン」ボタン --->
							<input type="button" id="Btnenter" value="確定" onserverclick="OnBTNENTER_FRM" runat="server" class="btn type-01"/>
						</p>
					<!-- /str-pager-01 --></div>
				<!-- /footerBtnArea --></div>
			<!-- /str-wrap-result --></div>
		<!-- /wrap --></div>

		<!-- 画面上隠しエレメントを格納するエリア-->
		<div id="hiddenElements" style="display:none" runat="server">
			<asp:Label ID="Head_tenpo_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Head_tenpo_cd_lbl" runat="server"></asp:Label>
			<asp:Label ID="Head_tenpo_cd_Req" runat="server" CssClass="required">*</asp:Label>

			<asp:Label ID="Tukibetu_bumon2_yosan_kin_lbl" runat="server"></asp:Label>
			<asp:Label ID="Tukibetu_bumon3_yosan_kin_lbl" runat="server"></asp:Label>
			<asp:Label ID="Tukibetu_bumon4_yosan_kin_lbl" runat="server"></asp:Label>
			<asp:Label ID="Tukibetu_bumon5_yosan_kin_lbl" runat="server"></asp:Label>
			<asp:Label ID="Tukibetu_yosan_kin_gokei_lbl" runat="server"></asp:Label>

			<asp:Label ID="Bumon2_yosangokei_kin_lbl" runat="server"></asp:Label>
			<asp:Label ID="Bumon3_yosangokei_kin_lbl" runat="server"></asp:Label>
			<asp:Label ID="Bumon4_yosangokei_kin_lbl" runat="server"></asp:Label>
			<asp:Label ID="Bumon5_yosangokei_kin_lbl" runat="server"></asp:Label>
			<asp:Label ID="Yosangokei_kin_lbl" runat="server"></asp:Label>
		</div>

	</form>
</body>
</html>

