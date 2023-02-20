<%@ Page language="c#" CodeFile="th020f01.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Th020p01.Page.Th020f01Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">在庫検索</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="th020p01" FormId="th020f01" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/th020f01.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="th020p01" FormId="th020f01" runat="server" />

	<!-- Js業務部品のインポート --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02001.js" charset="UTF-8"></script><!-- 店舗検索 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02006.js" charset="UTF-8"></script><!-- 会社情報取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02003.js" charset="UTF-8"></script><!-- 発注マスタ取得(自社品番) -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05001.js" charset="UTF-8"></script><!-- 自社品番丸め処理丸め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05002.js" charset="UTF-8"></script><!-- スキャンコード丸め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script><!-- 0埋め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05011.js" charset="UTF-8"></script><!-- FROM-TOコピー処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05014.js" charset="UTF-8"></script><!-- 名称取得拡張 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05015.js" charset="UTF-8"></script><!-- 項目制御処理 -->

	<!-- 業務共通コントロールのインポート-->
	<%@ Register TagPrefix="uc" TagName="common" Src="~/pjcommon/businessCommon/usercontrol/boCommonControl.ascx" %>
</head>

<body>
	<form id="Th020f01" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="th020p01" PgName="在庫検索" FormId="th020f01" FormName="在庫検索 一覧" ></uc:Header>

			<!------------------------------------------
				□業務共通コントロール
			------------------------------------------->
			<uc:common ID="bocommon" runat="server"></uc:common>

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
			<!------------------------------------------
				□モードタブ
			-------------------------------------------->
			<div class="str-tab-menu clearfix">
				<ul class="tab-list">
					<li>
						<!--- 「モード自社品番ボタン」リンク --->
						<a id="Btnmodejishahinban" href="#tab26" class="" runat="server">自社品番</a>
					</li>
					<li>
						<!--- 「モード自社品番２ボタン」リンク --->
						<a id="Btnmodejishahinban2" href="#tab33" class="" runat="server">自社品番（複数）</a>
					</li>
					<li>
						<!--- 「モードスキャンコードボタン」リンク --->
						<a id="Btnmodescancd" href="#tab25" class="" runat="server">スキャンコード</a>
					</li>
					<li>
						<!--- 「モードメーカー品番ボタン」リンク --->
						<a id="Btnmodemakerhbn" href="#tab27" class="" runat="server">メーカー品番</a>
					</li>
				</ul>
			</div>

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
									<!--- 「検索件数」一行テキストボックス（セパレート日付以外） --->
									<p class="txt-02">該当件数<span class="hit-number"><md:MDTextBox ID="Searchcnt" CssClass="inpReadonlyRight inpSearchCnt" runat="server"></md:MDTextBox></span><span>件</span></p>
								<!-- /list-search-result --></div>
							</td>
						</tr>
					</table>
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

								<!-- モード自社品番ボタン 検索条件 -->
								<div id="tab26" class="str-tab-cont">
									<table>
										<colgroup>
											<col class="w-type-01"/>
											<col class="w-type-02"/>
										</colgroup>
										<tbody>
											<tr><td colspan ="2"><div class="required">*が付いている項目は必須入力になります。</div><td></tr>
											<tr>
												<th>
													<span class="tbl-hdg"><asp:Label ID="Old_jisya_hbn_from_lbl" runat="server">自社品番FROM</asp:Label></span>
												</th>
												<td>
													<!--- 「旧自社品番from」一行テキストボックス（セパレート日付以外） --->
													<md:MDTextBox ID="Old_jisya_hbn_from" CssClass="inpJishahin10" runat="server"></md:MDTextBox>
													<span class="label-fromto">～</span>
													<!--- 「旧自社品番to」一行テキストボックス（セパレート日付以外） --->
													<md:MDTextBox ID="Old_jisya_hbn_to" CssClass="inpJishahin10" runat="server"></md:MDTextBox>
												</td>
											</tr>
											<tr>
												<th class="last">
													<span class="tbl-hdg">
														<asp:Label ID="Kaisya_cd_lbl" runat="server">会社</asp:Label><span class="required"><asp:Label ID="Kaisya_cd_Req" runat="server" CssClass="required">*</asp:Label></span>
													</span>
												</th>
												<td class="last">
													<span class="icon-in">
														<!--- 「会社コード」一行テキストボックス（セパレート日付以外） --->
														<md:MDTextBox ID="Kaisya_cd" CssClass="inpSerch inpComp" runat="server"></md:MDTextBox>
														<!--- 「会社コードボタン」ボタン --->
														<input type="button" id="Btnkaisha_cd" name="Btnkaisha_cd" value="" runat="server" class="icon-search"/>
													</span>	<!--- 「会社名称」テキストボックスリードオンリー --->
													<asp:TextBox ID="Kaisya_nm" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
												</td>
											</tr>
										</tbody>
									</table>
								</div>

								<!-- モード自社品番２ボタン 検索条件 -->
								<div id="tab33" class="str-tab-cont">
									<table>
										<colgroup>
											<col class="w-type-01"/>
											<col class="w-type-02"/>
										</colgroup>
										<tbody>
											<tr><td colspan ="2"><div class="required">*が付いている項目は必須入力になります。</div><td></tr>
											<tr>
												<th>
													<span class="tbl-hdg"><asp:Label ID="Old_jisya_hbn_lbl" runat="server">自社品番（複数）</asp:Label></span>
												</th>
												<td>
													<!--- 「旧自社品番」一行テキストボックス（セパレート日付以外） --->
													<md:MDTextBox ID="Old_jisya_hbn" CssClass="inpJishahin10 multiinput" runat="server"></md:MDTextBox>
													<!--- 「旧自社品番２」一行テキストボックス（セパレート日付以外） --->
													<md:MDTextBox ID="Old_jisya_hbn2" CssClass="inpJishahin10 multiinput" runat="server"></md:MDTextBox>
													<!--- 「旧自社品番３」一行テキストボックス（セパレート日付以外） --->
													<md:MDTextBox ID="Old_jisya_hbn3" CssClass="inpJishahin10 multiinput" runat="server"></md:MDTextBox>
													<!--- 「旧自社品番４」一行テキストボックス（セパレート日付以外） --->
													<md:MDTextBox ID="Old_jisya_hbn4" CssClass="inpJishahin10 multiinput" runat="server"></md:MDTextBox>
													<!--- 「旧自社品番５」一行テキストボックス（セパレート日付以外） --->
													<md:MDTextBox ID="Old_jisya_hbn5" CssClass="inpJishahin10 multiinput" runat="server"></md:MDTextBox>
												</td>
											</tr>
											<tr>
												<th class="last">
													<span class="tbl-hdg">
														<asp:Label ID="Kaisya_cd2_lbl" runat="server">会社</asp:Label><span class="required"><asp:Label ID="Kaisya_cd2_Req" runat="server" CssClass="required">*</asp:Label></span>
													</span>
												</th>
												<td class="last">
													<span class="icon-in">
														<!--- 「会社コード２」一行テキストボックス（セパレート日付以外） --->
														<md:MDTextBox ID="Kaisya_cd2" CssClass="inpSerch inpComp" runat="server"></md:MDTextBox>
														<!--- 「会社コード２ボタン」ボタン --->
														<input type="button" id="Btnkaisha_cd2" name="Btnkaisha_cd2" value="" runat="server" class="icon-search"/>
													</span>	<!--- 「会社名称２」テキストボックスリードオンリー --->
													<asp:TextBox ID="Kaisya_nm2" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
												</td>
											</tr>
										</tbody>
									</table>
								</div>

								<!-- モードスキャンコードボタン 検索条件 -->
								<div id="tab25" class="str-tab-cont">
									<table>
										<colgroup>
											<col class="w-type-01"/>
											<col class="w-type-02"/>
										</colgroup>
										<tbody>
											<tr><td colspan ="2"><div class="required">*が付いている項目は必須入力になります。</div><td></tr>
											<tr>
												<th>
													<span class="tbl-hdg"><asp:Label ID="Scan_cd_from_lbl" runat="server">スキャンコードFROM</asp:Label></span>
												</th>
												<td>
													<!--- 「スキャンコードfrom」一行テキストボックス（セパレート日付以外） --->
													<md:MDTextBox ID="Scan_cd_from" CssClass="inpScanHdg" runat="server"></md:MDTextBox>
													<span class="label-fromto">～</span>
													<!--- 「スキャンコードto」一行テキストボックス（セパレート日付以外） --->
													<md:MDTextBox ID="Scan_cd_to" CssClass="inpScanHdg" runat="server"></md:MDTextBox>
												</td>
											</tr>

											<tr>
												<th class="last">
													<span class="tbl-hdg">
														<asp:Label ID="Kaisya_cd3_lbl" runat="server">会社</asp:Label><span class="required"><asp:Label ID="Kaisya_cd3_Req" runat="server" CssClass="required">*</asp:Label></span>
													</span>
												</th>
												<td class="last">
													<span class="icon-in">
														<!--- 「会社コード３」一行テキストボックス（セパレート日付以外） --->
														<md:MDTextBox ID="Kaisya_cd3" CssClass="inpSerch inpComp" runat="server"></md:MDTextBox>
														<!--- 「会社コード３ボタン」ボタン --->
														<input type="button" id="Btnkaisha_cd3" name="Btnkaisha_cd3" value="" runat="server" class="icon-search"/>
													</span>	<!--- 「会社名称３」テキストボックスリードオンリー --->
													<asp:TextBox ID="Kaisya_nm3" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
												</td>
											</tr>
										</tbody>
									</table>
								</div>

								<!-- モードメーカー品番ボタン 検索条件 -->
								<div id="tab27" class="str-tab-cont">
									<table>
										<colgroup>
											<col class="w-type-01"/>
											<col class="w-type-02"/>
										</colgroup>
										<tbody>
											<tr><td colspan ="2"><div class="required">*が付いている項目は必須入力になります。</div><td></tr>
											<tr>
												<th>
													<span class="tbl-hdg"><asp:Label ID="Maker_hbn_lbl" runat="server">メーカー品番</asp:Label></span>
												</th>
												<td>
													<span class="icon-in">
														<!--- 「メーカー品番」一行テキストボックス（セパレート日付以外） --->
														<md:MDTextBox ID="Maker_hbn" CssClass="inpSerch inpMkhin" runat="server"></md:MDTextBox>
														<!--- 「メーカー品番ボタン」ボタン --->
														<input type="button" id="Btnmaker_hbn" name="Btnmaker_hbn" value="" runat="server" class="icon-search"/>
													</span>
												</td>
											</tr>

											<tr>
												<th class="last">
													<span class="tbl-hdg">
														<asp:Label ID="Kaisya_cd4_lbl" runat="server">会社</asp:Label><span class="required"><asp:Label ID="Kaisya_cd4_Req" runat="server" CssClass="required">*</asp:Label></span>
													</span>
												</th>
												<td class="last">
													<span class="icon-in">
														<!--- 「会社コード４」一行テキストボックス（セパレート日付以外） --->
														<md:MDTextBox ID="Kaisya_cd4" CssClass="inpSerch inpComp" runat="server"></md:MDTextBox>
														<!--- 「会社コード４ボタン」ボタン --->
														<input type="button" id="Btnkaisha_cd4" name="Btnkaisha_cd4" value="" runat="server" class="icon-search"/>
													</span>	<!--- 「会社名称４」テキストボックスリードオンリー --->
															<asp:TextBox ID="Kaisya_nm4" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
												</td>
											</tr>
										</tbody>
									</table>
								</div>
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

			<!--- アコーディオン --->
			<div class="trigger-search-01">
			<a href="#"></a>
			<!-- /trigger-search-01 --></div>

			<!-------------------------------------------------------------------
									2.明細部
			--------------------------------------------------------------------->
			<input id="M1PageStartRow" type="hidden" runat="server"/>
			<div class="str-wrap-result">

				<!------------------------------------------
				  □ボタン領域
				-------------------------------------------->
				<div id="str-btn-area" class="str-btn-utility">
					<div id="meisaiBtnArea" class="inner pad0" runat="server">

					<ul>
						<li>
							<!--- 「在庫検索選択」ラジオボタン --->
							<adv:ConditionRBList ID="Zaiko_serchstk" ConditionName="zaiko_serchstk" RepeatDirection="Horizontal" CssClass="str-radio-table" runat="server"></adv:ConditionRBList>
						</li>
					</ul>
					<ui>
					</ui>
					</div>
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
						<!------------------------------------------
						  □一覧ヘッダ領域
						-------------------------------------------->
						<div class="str-result-hdg-01">
							<div class="col1 col_2dan">
								<asp:Label ID="M1rowno_lbl" runat="server">No.</asp:Label>
							</div>
							<div class="col2">
								<div><asp:Label ID="M1bumon_cd_lbl" runat="server">部門</asp:Label></div>
								<div><asp:Label ID="M1hinsyu_ryaku_nm_lbl" runat="server">品種</asp:Label></div>
							</div>
							<div class="col3 col_2dan">
								<asp:Label ID="M1burando_nm_lbl" runat="server">ブランド</asp:Label>
							</div>
							<div class="col4 col_2dan">
								<asp:Label ID="M1jisya_hbn_lbl" runat="server">自社品番</asp:Label>
							</div>
							<div class="col5 col_2dan">
								<asp:Label ID="M1syohin_zokusei_lbl" runat="server">コア</asp:Label>
							</div>
							<div class="col6">
								<div><asp:Label ID="M1maker_hbn_lbl" runat="server">メーカー品番</asp:Label></div>
								<div><asp:Label ID="M1syonmk_lbl" runat="server">商品名</asp:Label></div>
							</div>
							<div class="col7 col_2dan">
								<asp:Label ID="M1iro_nm_lbl" runat="server">色</asp:Label>
							</div>
							<div class="col8 col_2dan">
								<asp:Label ID="M1tenzaiko_su_lbl" runat="server">自店在庫数</asp:Label>
							</div>
							<div class="col9 col_2dan">
								<asp:Label ID="M1zentenzaiko_su_lbl" runat="server">全店在庫数</asp:Label>
							</div>
							<div class="col10 col_2dan">
								<asp:Label ID="M1syoka_rtu_lbl" runat="server">消化率</asp:Label>
							</div>
							<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
							<div style="display: none">
								<div class="col3">
									<asp:Label ID="M1bumonkana_nm_lbl" runat="server"></asp:Label>
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
						<!-- /str-hdg-result --></div>


						<!------------------------------------------
						  □一覧明細領域
						-------------------------------------------->
						<div id="str-result-item-wrap" class="adjust-elem">
							<asp:Repeater ID="M1" runat="server">
								<HeaderTemplate>
								</HeaderTemplate>
								<ItemTemplate>
									<div class="str-result-item-01">
										<div class="col1 col_2dan  detail_right">
											<!--- 「ｍ１行no」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1rowno" CssClass="inpReadonlyRight inpRONum4" runat="server"></asp:TextBox>
										</div>

										<div class="col2 detail_left">
											<!--- 「ｍ１部門コード」テキストボックスリードオンリー ---><!--- 「ｍ１部門カナ名」テキストボックスリードオンリー --->
											<div class="col2"><asp:TextBox ID="M1bumon_cd" CssClass="inpReadonlyLeft inpRONum3" runat="server"></asp:TextBox> <asp:TextBox ID="M1bumonkana_nm" CssClass="inpReadonlyLeft inpROHankaku12 tooltip" runat="server"></asp:TextBox></div>
											<!--- 「ｍ１品種略名称」テキストボックスリードオンリー --->
											<div class="col2"><asp:TextBox ID="M1hinsyu_ryaku_nm" CssClass="inpReadonlyLeft inpROHankaku12 tooltip" runat="server"></asp:TextBox></div>
										</div>

										<div class="col3 col_2dan detail_left">
											<!--- 「ｍ１ブランド名」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1burando_nm" CssClass="inpReadonlyLeft inpROHankaku17 tooltip" runat="server"></asp:TextBox>
										</div>

										<div class="col4 col_2dan detail_center">
											<!--- 「Ｍ１自社品番リンク」ボタン --->
											<input type="button" id="M1jisya_hbn" value="自社品番" onserverclick="OnM1JISYA_HBN_FRM" runat="server" class="meisaiLink"/>
										</div>

										<div class="col5 col_2dan  detail_left">
											<!--- 「ｍ１商品属性」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1syohin_zokusei" CssClass="inpReadonlyLeft inpROHankaku3 tooltip" runat="server"></asp:TextBox>
										</div>

										<div class="col6 detail_left">
											<!--- 「ｍ１メーカー品番」テキストボックスリードオンリー --->
											<div class="col6"><asp:TextBox ID="M1maker_hbn" CssClass="inpReadonlyLeft inpROHankaku30 tooltip" runat="server"></asp:TextBox></div>
											<!--- 「ｍ１商品名(カナ)」テキストボックスリードオンリー --->
											<div class="col6"><asp:TextBox ID="M1syonmk" CssClass="inpReadonlyLeft inpROHankaku20 tooltip" runat="server"></asp:TextBox></div>
										</div>

										<div class="col7 col_2dan detail_left">
											<!--- 「ｍ１色」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1iro_nm" CssClass="inpReadonlyLeft inpROHankaku10 tooltip" runat="server"></asp:TextBox>
										</div>

										<div class="col8 col_2dan detail_right">
											<!--- 「ｍ１店在庫数」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1tenzaiko_su" CssClass="inpReadonlyRight inpRONumCmaMinus8" runat="server"></asp:TextBox>
										</div>

										<div class="col9 col_2dan detail_right">
											<!--- 「ｍ１全店在庫数」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1zentenzaiko_su" CssClass="inpReadonlyRight inpRONumCmaMinus8" runat="server"></asp:TextBox>
										</div>

										<div class="col10 col_2dan detail_right">
											<!--- 「ｍ１消化率」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1syoka_rtu" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
										</div>

										<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
										<div style="display:none">
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
					<div id="str-pager-bottom" class="footer str-pager-01 pad0 heightZero">
						<p>
						</p>
						<p>
						</p>
					<!-- /str-pager-01 --></div>
				<!-- /footerBtnArea --></div>
			<!-- /str-wrap-result --></div>

		<!-- /wrap --></div>

		<!-- 画面上隠しエレメントを格納するエリア-->
		<div id="hiddenElements" style="display:none" runat="server">
			<asp:Label ID="Head_tenpo_cd_lbl" runat="server">店舗</asp:Label>
			<asp:Label ID="Head_tenpo_cd_Req" runat="server" CssClass="required">*</asp:Label>
			<asp:Label ID="Head_tenpo_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Searchcnt_lbl" runat="server"></asp:Label>
			<!--- 「モードNO」隠しフィールド --->
			<asp:hiddenfield ID="Modeno" runat="server"></asp:hiddenfield>
			<!--- 「選択モードNO」隠しフィールド --->
			<asp:hiddenfield ID="Stkmodeno" runat="server"></asp:hiddenfield>
			<asp:Label ID="Old_jisya_hbn_to_lbl" runat="server">自社品番TO</asp:Label>
			<asp:Label ID="Kaisya_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Old_jisya_hbn2_lbl" runat="server">自社品番</asp:Label>
			<asp:Label ID="Old_jisya_hbn3_lbl" runat="server">自社品番</asp:Label>
			<asp:Label ID="Old_jisya_hbn4_lbl" runat="server">自社品番</asp:Label>
			<asp:Label ID="Old_jisya_hbn5_lbl" runat="server">自社品番</asp:Label>
			<asp:Label ID="Kaisya_nm2_lbl" runat="server"></asp:Label>
			<asp:Label ID="Scan_cd_to_lbl" runat="server">スキャンコードTO</asp:Label>
			<asp:Label ID="Kaisya_nm3_lbl" runat="server"></asp:Label>
			<asp:Label ID="Kaisya_nm4_lbl" runat="server"></asp:Label>
			<asp:Label ID="Zaiko_serchstk_lbl" runat="server"></asp:Label>
		</div>
	
	</form>
</body>
</html>

