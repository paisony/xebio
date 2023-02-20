<%@ Page language="c#" CodeFile="tf040f01.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Tf040p01.Page.Tf040f01Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">小口現金登録</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="tf040p01" FormId="tf040f01" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/tf040f01.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="tf040p01" FormId="tf040f01" runat="server" />
	<!-- Js業務部品のインポート --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02001.js" charset="UTF-8"></script><!-- 店舗検索 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02021.js" charset="UTF-8"></script><!-- 科目コード検索 -->

	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05003.js" charset="UTF-8"></script><!-- 明細背景色変更処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script><!-- 0埋め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05010.js" charset="UTF-8"></script><!-- カンマ編集処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05024.js" charset="UTF-8"></script><!-- 数値編集関数群 -->

</head>

<body>
	<form id="Tf040f01" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="tf040p01" PgName="小口現金登録" FormId="tf040f01" FormName="小口現金登録" ></uc:Header>
			

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
					<%--
					<div class="inner-01" style="display:none;">
						<p id="list-search"></p>
						<p class="txt-02">該当件数<span class="hit-number"></span><span>件</span></p>
					<!-- /inner-01 --></div>
					--%>
		
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
												<col />
											</colgroup>
											<tr>
												<th scope="col">
													<span class="tbl-hdg">
														<asp:Label ID="Zenjitu_zandaka_lbl" runat="server">前日残高</asp:Label>
													</span>
												</th>
												<td>
													<!--- 「前日残高」テキストボックスリードオンリー --->
													<asp:TextBox ID="Zenjitu_zandaka" CssClass="inpReadonlyRight inpRONumCmaMinus9" runat="server"></asp:TextBox>
												</td>
												<th scope="col">
													<span class="tbl-hdg">
														<asp:Label ID="Zengetu_zandaka_lbl" runat="server">前月残高</asp:Label>
													</span>
												</th>
												<td>
													<!--- 「前月残高」テキストボックスリードオンリー --->
													<asp:TextBox ID="Zengetu_zandaka" CssClass="inpReadonlyRight inpRONumCmaMinus9" runat="server"></asp:TextBox>
												</td>
											</tr>
										</table>
									<!-- /inner --></div>
								<!-- /str-form-02 --></div>
							</td>

							<td class="search-table-tdright">
								<div class="str-btn-search">
									<!--- 「検索ボタン」ボタン --->
									<input type="button" id="Btnsearch" value="検索" onserverclick="OnBTNSEARCH_FRM" runat="server" class="btn type-02"/>
								<!-- /str-btn-search --></div>
							</td>
						</tr>
					</table>

		    		<!-- /inner-02 --></div>
		    	<!-- /str-search-01 --></div>
			<!-- /tab1 --></div>

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
				<!-- button -->
				<div id="str-btn-area" class="str-btn-utility">
					<div id="meisaiBtnArea" class="inner pad0" runat="server">
					<ul>
						<!--明細制御系ボタンを配置する場合はこのulタグの中-->
						<li>
							<!--- 「行追加ボタン」ボタン --->
							<span><label><input type="button" id="Btnrowins" value="" onserverclick="OnBTNROWINS_MADD" runat="server" class="icon-utility-06"/>行追加</label></span>
						</li>
						<li>
							<!--- 「行削除ボタン」ボタン --->
							<span><label><input type="button" id="Btnrowdel" value="" onserverclick="OnBTNROWDEL_FRM" runat="server" class="icon-utility-03"/>行削除</label></span>
						</li>

					</ul>
					<ul>
						<!--帳票／CSV系ボタンを配置する場合はこのulタグの中-->
					</ul>
					<!-- /meisaiBtnArea --></div>
				<!-- /utility --></div>
				<div class="inner">
					<div id="str-pager-top" class="str-pager-01">
		
						<!--- 件数表示部 --->
						<p><adv:PageInfo ID="M1PageInfo" runat="server"></adv:PageInfo></p>
						<!--- ページャーを配置する場合はこの中 --->

						<!--- 「ページャ」カスタムページャー --->
						<cc:custompager ID="Pgr" OnPageIndexChanged="OnPGR_PGN" runat="server"></cc:custompager>

		
					<!-- /str-pager-01 --></div>
					<!--一覧-->
					<div class="str-result-01">
					<%-- 明細ヘッダ --%>
						<div class="str-result-hdg-01">
							<div class="col1">
								<asp:Label ID="M1rowno_lbl" runat="server">No.</asp:Label>
							</div>
							<div class="col2">
								<asp:Label ID="M1kanri_no_lbl" runat="server">管理No</asp:Label>
							</div>
							<div class="col3">
								<asp:Label ID="M1motokanri_no_lbl" runat="server">元No</asp:Label>
							</div>
							<div class="col4">
								<asp:Label ID="M1keijo_ymd_lbl" runat="server">日付</asp:Label>
							</div>
							<div class="col5">
								<asp:Label ID="M1kamoku_cd_lbl" runat="server">科目</asp:Label>
							</div>
							<div class="col6">
								<asp:Label ID="M1nyukin_lbl" runat="server">入金</asp:Label>
							</div>
							<div class="col7">
								<asp:Label ID="M1syukkin_lbl" runat="server">出金</asp:Label>
							</div>
							<div class="col8">
								<asp:Label ID="M1tekiyou_lbl" runat="server">摘要</asp:Label>
							</div>
							<div class="col9">
								<asp:Label ID="M1hurikaetenpo_cd_lbl" runat="server">振替店舗</asp:Label>
							</div>

							<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
							<div style="display: none">

								<asp:Label ID="M1nyukin_hdn_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1syukkin_hdn_lbl" runat="server"></asp:Label>

								<div class="col6">
									<asp:Label ID="M1btnkamokucd_lbl" runat="server"></asp:Label>
								</div>
								<div class="col7">
									<asp:Label ID="M1kamoku_nm_lbl" runat="server"></asp:Label>
								</div>
								<div class="col12">
									<asp:Label ID="M1btntenpocd_lbl" runat="server"></asp:Label>
								</div>
								<div class="col13">
									<asp:Label ID="M1hurikaetenpo_nm_lbl" runat="server"></asp:Label>
								</div>
								<div class="col14">
									<asp:Label ID="M1selectorcheckbox_lbl" runat="server"></asp:Label>
								</div>
								<div class="col15">
									<asp:Label ID="M1entersyoriflg_lbl" runat="server"></asp:Label>
								</div>
								<div class="col16">
									<asp:Label ID="M1dtlirokbn_lbl" runat="server"></asp:Label>
								</div>
							</div>
							<!--- 隠し項目エリア↑↑↑↑↑↑↑↑↑↑↑↑↑ --->

						<!-- /str-result-hdg-01 --></div>
						<div id="str-result-item-wrap" class="adjust-elem">
							<asp:Repeater ID="M1" runat="server">
								<HeaderTemplate>
								</HeaderTemplate>
								<ItemTemplate>
									<div id="M1Row" class="str-result-item-01" runat="server">
										<div class="col1 detail_right">
											<!--- 「ｍ１行no」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1rowno" CssClass="inpReadonlyRight inpRONum3" runat="server"></asp:TextBox>
										</div>
										<div class="col2 detail_left">
											<!--- 「ｍ１管理no」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1kanri_no" CssClass="inpReadonlyLeft inpRONum6" runat="server"></asp:TextBox>
										</div>
										<div class="col3 detail_left">
											<!--- 「ｍ１元管理no」一行テキストボックス（セパレート日付以外） --->
											<md:MDTextBox ID="M1motokanri_no" CssClass="inpDenpyo" runat="server"></md:MDTextBox>
										</div>
										<div class="col4 detail_center">
											<!--- 「ｍ１計上日付」一行テキストボックス（セパレート日付以外） --->
											<span class="icon-in">
												<span class="icon-in"><md:MDTextBox ID="M1keijo_ymd" CssClass="inpSerch inpDt2 datepicker" runat="server"></md:MDTextBox></span>
											</span>
										</div>
										<div class="col5 detail_left">
											<!--- 「ｍ１科目コード」一行テキストボックス（セパレート日付以外） --->
											<!--- 「Ｍ１科目コードボタン」ボタン --->
											<!--- 「ｍ１科目名」テキストボックスリードオンリー --->
											<span class="icon-in">
												<md:MDTextBox ID="M1kamoku_cd" CssClass="inpSerch inpKamoku" runat="server"></md:MDTextBox>
												<input type="button" id="M1btnkamokucd" name="M1btnkamokucd" value="" runat="server" class="icon-search"/>
											</span><asp:TextBox ID="M1kamoku_nm" CssClass="inpReadonlyLeft inpROZenkaku20 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col6 detail_center">
											<!--- 「ｍ１入金」一行テキストボックス（セパレート日付以外） --->
											<md:MDTextBox ID="M1nyukin" CssClass="inpSu-09" runat="server"></md:MDTextBox>
										</div>
										<div class="col7 detail_center">
											<!--- 「ｍ１出金」一行テキストボックス（セパレート日付以外） --->
											<md:MDTextBox ID="M1syukkin" CssClass="inpSu-09" runat="server"></md:MDTextBox>
										</div>
										<div class="col8 detail_left">
											<!--- 「ｍ１摘要」一行テキストボックス（セパレート日付以外） --->
											<md:MDTextBox ID="M1tekiyou" CssClass="inpTekiyo" runat="server"></md:MDTextBox>
										</div>
										<div class="col9 detail_left">
											<!--- 「ｍ１振替店舗コード」一行テキストボックス（セパレート日付以外） --->
											<!--- 「Ｍ１店舗コードボタン」ボタン --->
											<!--- 「ｍ１振替店舗名」テキストボックスリードオンリー --->
											<span class="icon-in">
												<md:MDTextBox ID="M1hurikaetenpo_cd" CssClass="inpSerch inpTenpo" runat="server"></md:MDTextBox>
												<input type="button" id="M1btntenpocd" name="M1btntenpocd" value="" runat="server" class="icon-search"/>
											</span><asp:TextBox ID="M1hurikaetenpo_nm" CssClass="inpReadonlyLeft tooltip" runat="server"></asp:TextBox>
										</div>

										<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
										<div style="display: none">

											<!--- 「M１入金(隠し)」隠しフィールド --->
											<asp:hiddenfield ID="M1nyukin_hdn" runat="server"></asp:hiddenfield>

											<!--- 「M1出金(隠し)」隠しフィールド --->
											<asp:hiddenfield ID="M1syukkin_hdn" runat="server"></asp:hiddenfield>

											<div class="col14">
												<!--- 「ｍ１選択フラグ(隠し)」チェックボックス --->
												<adv:AdvancedCheckBox ID="M1selectorcheckbox" Text="" CssClass="" runat="server"></adv:AdvancedCheckBox>
											</div>
											<div class="col15">
												<!--- 「Ｍ１確定処理フラグ(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1entersyoriflg" runat="server"></asp:hiddenfield>
											</div>
											<div class="col16">
												<!--- 「Ｍ１明細色区分(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1dtlirokbn" runat="server"></asp:hiddenfield>
											</div>
										</div>
										<!--- 隠し項目エリア↑↑↑↑↑↑↑↑↑↑↑↑↑ --->

									<!-- /str-result-item-01 --></div>
								</ItemTemplate>
							</asp:Repeater>
						<!-- /str-result-item-wrap --></div>
						<span class="adjust-elem-next"></span>

						<div id="footerArea" class="str-result-ftr-01" runat="server">
							<div class="col1 detail_left">&nbsp;</div>
							<div class="col2 detail_left">&nbsp;</div>
							<div class="col3 detail_left">&nbsp;</div>
							<div class="col4 detail_left">&nbsp;</div>
							<div class="col5 detail_left">&nbsp;</div>
							<div class="col6 detail_ftr_title">
								<span class="tbl-hdg"><asp:Label ID="Gokei_zandaka_lbl" runat="server">残高</asp:Label></span>
							</div>
							<div class="col7 detail_ftr">
								<span>
									<!--- 「合計残高」一行テキストボックス（セパレート日付以外） --->
									<md:MDTextBox ID="Gokei_zandaka" CssClass="inpReadonlyRight inpRONumCmaMinus9" runat="server"></md:MDTextBox>
								</span>
							</div>
							<div class="col8 detail_left">&nbsp;</div>
							<div class="col9 detail_left">&nbsp;</div>
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
			<asp:Label ID="Head_tenpo_cd_lbl" runat="server"></asp:Label>
			<asp:Label ID="Head_tenpo_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Head_tenpo_cd_Req" runat="server" CssClass="required">*</asp:Label>

		     
		</div>
	
	</form>
</body>
</html>

