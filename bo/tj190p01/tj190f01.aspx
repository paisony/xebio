<%@ Page language="c#" CodeFile="tj190f01.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Tj190p01.Page.Tj190f01Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">臨時棚卸検索</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="tj190p01" FormId="tj190f01" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/tj190f01.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="tj190p01" FormId="tj190f01" runat="server" />
	<!-- Js業務部品のインポート --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02001.js" charset="UTF-8"></script><!-- 店舗検索 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02002.js" charset="UTF-8"></script><!-- 仕入先マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02003.js" charset="UTF-8"></script><!-- 発注マスタ取得(自社品番)  -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02004.js" charset="UTF-8"></script><!-- 発注マスタ取得(スキャンコード) -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02005.js" charset="UTF-8"></script><!-- 担当者マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02010.js" charset="UTF-8"></script><!-- 部門マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02011.js" charset="UTF-8"></script><!-- 品種マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02012.js" charset="UTF-8"></script><!-- ブランドマスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05001.js" charset="UTF-8"></script><!-- 自社品番丸め処理丸め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05002.js" charset="UTF-8"></script><!-- スキャンコード丸め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script><!-- 0埋め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05009.js" charset="UTF-8"></script><!-- 指示番号丸め処理(返品用) -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05011.js" charset="UTF-8"></script><!-- FROM-TOコピー処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05014.js" charset="UTF-8"></script><!-- 名称取得拡張 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05015.js" charset="UTF-8"></script><!-- 項目入力制御処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05019.js" charset="UTF-8"></script><!-- 情報ダイアログ表示処理(拡張版) -->

	<!-- 業務共通コントロールのインポート-->
	<%@ Register TagPrefix="uc" TagName="common" Src="~/pjcommon/businessCommon/usercontrol/boCommonControl.ascx" %>

</head>

<body>
	<form id="Tj190f01" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="tj190p01" PgName="臨時棚卸検索" FormId="tj190f01" FormName="臨時棚卸検索 一覧" ></uc:Header>

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
						<!--- 「モード修正ボタン」リンク --->
						<a id="Btnmodeupd" href="#tab8" class="" runat="server">修正</a>
					</li>
					<li>
						<!--- 「モード取消ボタン」リンク --->
						<a id="Btnmodedel" href="#tab11" class="" runat="server">取消</a>
					</li>
					<li>
						<!--- 「モード照会ボタン」リンク --->
						<a id="Btnmoderef" href="#tab16" class="" runat="server">照会</a>
					</li>
					<li>
						<!--- 「モードロス計算ボタン」リンク --->
						<a id="Btnmodelosskeisan" href="#tab17" class="" runat="server">ロス計算</a>
					</li>
					<li>
						<!--- 「モードロス取消ボタン」リンク --->
						<a id="Btnmodelossdel" href="#tab18" class="" runat="server">ロス取消</a>
					</li>
					<li>
						<!--- 「モードロス照会ボタン」リンク --->
						<a id="Btnmodelossref" href="#tab19" class="" runat="server">ロス照会</a>
					</li>
				</ul>
			</div>

			<div id="tab8" class="str-tab-cont"></div>
			<div id="tab11" class="str-tab-cont"></div>
			<div id="tab16" class="str-tab-cont"></div>
			<div id="tab17" class="str-tab-cont"></div>
			<div id="tab18" class="str-tab-cont"></div>
			<div id="tab19" class="str-tab-cont"></div>

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
					<table class="search-table">
						<tr>
							<td class="search-table-tdleft">
								<div class="str-form-02">
									<div class="inner">
<!--										<p class="required">*が付いている項目は必須入力になります。</p>	-->
										<table>
											<colgroup>
												<col class="w-type-01"/>
												<col class="w-type-03"/>
												<col class="w-type-02"/>
												<col class="w-type-04"/>
												<col class="w-type-02"/>
												<col class="w-type-05"/>
												<col class="w-type-06"/>
												<col class="w-type-07"/>
											<col />
											</colgroup>
											<tbody>
												<tr>
													<th>
														<span class="tbl-hdg"><asp:Label ID="Nyuryoku_ymd_from_lbl" runat="server">入力日FROM</asp:Label></span>
													</th>
													<!--- 「入力日from」一行テキストボックス（セパレート日付以外） --->
													<!--- 「入力日to」一行テキストボックス（セパレート日付以外） --->
													<td>
														<label><span class="icon-in"><md:MDTextBox ID="Nyuryoku_ymd_from" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span><span class="label-fromto">～</span><span class="icon-in"><md:MDTextBox ID="Nyuryoku_ymd_to" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span></label>
													</td>
													<th>
														<span class="tbl-hdg"><asp:Label ID="Tenpo_cd_from_lbl" runat="server">店舗FROM</asp:Label></span>
													</th>
													<!--- 「店舗コードfrom」一行テキストボックス（セパレート日付以外） --->
													<!--- 「店舗コードFROMボタン」ボタン --->
													<!--- 「店舗名from」テキストボックスリードオンリー --->
													<!--- 「店舗コードto」一行テキストボックス（セパレート日付以外） --->
													<!--- 「店舗コードTOボタン」ボタン --->
													<!--- 「店舗名to」テキストボックスリードオンリー --->
													<td colspan="5">
														<span class="icon-in"><md:MDTextBox ID="Tenpo_cd_from" CssClass="inpSerch inpTenpo" runat="server"></md:MDTextBox><input type="button" id="Btntenpocd_from" name="Btntenpocd_from" value="" runat="server" class="icon-search"/></span>
														<asp:TextBox ID="Tenpo_nm_from" CssClass="inpReadonlyLeft inpROZenkaku12" runat="server"></asp:TextBox>
														<span class="label-fromto">～</span>
														<span class="icon-in"><md:MDTextBox ID="Tenpo_cd_to" CssClass="inpSerch inpTenpo" runat="server"></md:MDTextBox><input type="button" id="Btntenpocd_to" name="Btntenpocd_to" value="" runat="server" class="icon-search"/></span>
														<asp:TextBox ID="Tenpo_nm_to" CssClass="inpReadonlyLeft inpROZenkaku12" runat="server"></asp:TextBox>
													</td>
												</tr>
												<tr>
													<th>
														<span class="tbl-hdg"><asp:Label ID="Nyuryokutan_cd_lbl" runat="server">入力担当者</asp:Label></span>
													</th>
													<!--- 「入力担当者コード」一行テキストボックス（セパレート日付以外） --->
													<!--- 「担当者コードボタン」ボタン --->
													<!--- 「入力担当者名称」テキストボックスリードオンリー --->
													<td>
														<span class="icon-in"><md:MDTextBox ID="Nyuryokutan_cd" CssClass="inpSerch inpTanto" runat="server"></md:MDTextBox><input type="button" id="Btntanto_cd" name="Btntanto_cd" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="Nyuryokutan_nm" CssClass="inpReadonlyLeft inpROZenkaku12" runat="server"></asp:TextBox>
													</td>
												</tr>
												<tr>
													<th>
														<span class="tbl-hdg"><asp:Label ID="Bumon_cd_from_lbl" runat="server">部門FROM</asp:Label></span>
													</th>
													<!--- 「部門コードfrom」一行テキストボックス（セパレート日付以外） ---><!--- 「部門コードFROMボタン」ボタン ---><!--- 「部門名from」テキストボックスリードオンリー --->
													<!--- 「品種コードfrom」一行テキストボックス（セパレート日付以外） ---><!--- 「品種コードFROMボタン」ボタン ---><!--- 「品種略名称from」テキストボックスリードオンリー --->
													<!--- 「部門コードto」一行テキストボックス（セパレート日付以外） ---><!--- 「部門コードTOボタン」ボタン ---><!--- 「部門名to」テキストボックスリードオンリー --->
													<!--- 「品種コードto」一行テキストボックス（セパレート日付以外） ---><!--- 「品種コードTOボタン」ボタン ---><!--- 「品種略名称to」テキストボックスリードオンリー --->
													<td colspan="7">
														<span class="icon-in"><md:MDTextBox ID="Bumon_cd_from" CssClass="inpSerch inpBumon" runat="server"></md:MDTextBox><input type="button" id="Btnbumon_cd_from" name="Btnbumon_cd_from" value="" runat="server" class="icon-search"/></span>
														<asp:TextBox ID="Bumon_nm_from" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
														<span class="icon-in"><md:MDTextBox ID="Hinsyu_cd_from" CssClass="inpSerch inpHinshu" runat="server"></md:MDTextBox><input type="button" id="Btnhinsyu_cd_from" name="Btnhinsyu_cd_from" value="" runat="server" class="icon-search"/></span>
														<asp:TextBox ID="Hinsyu_ryaku_nm_from" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
														<span class="label-fromto">～</span>
														<span class="icon-in"><md:MDTextBox ID="Bumon_cd_to" CssClass="inpSerch inpBumon" runat="server"></md:MDTextBox><input type="button" id="Btnbumon_cd_to" name="Btnbumon_cd_to" value="" runat="server" class="icon-search"/></span>
														<asp:TextBox ID="Bumon_nm_to" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
														<span class="icon-in"><md:MDTextBox ID="Hinsyu_cd_to" CssClass="inpSerch inpHinshu" runat="server"></md:MDTextBox><input type="button" id="Btnhinsyu_cd_to" name="Btnhinsyu_cd_to" value="" runat="server" class="icon-search"/></span>
														<asp:TextBox ID="Hinsyu_ryaku_nm_to" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
													</td>
												</tr>
												<tr>
													<th>
														<span class="tbl-hdg"><asp:Label ID="Burando_cd_lbl" runat="server">ブランド</asp:Label></span>
													</th>
													<!--- 「ブランドコード」一行テキストボックス（セパレート日付以外） ---><!--- 「ブランドコードボタン」ボタン ---><!--- 「ブランド名」テキストボックスリードオンリー --->
													<td>
														<span class="icon-in"><md:MDTextBox ID="Burando_cd" CssClass="inpSerch inpBrand" runat="server"></md:MDTextBox><input type="button" id="Btnburando_cd" name="Btnburando_cd" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="Burando_nm" CssClass="inpReadonlyLeft inpROZenkaku20" runat="server"></asp:TextBox>
													</td>
													<th>
														<span class="tbl-hdg"><asp:Label ID="Old_jisya_hbn_lbl" runat="server">自社品番</asp:Label></span>
													</th>
													<!--- 「旧自社品番」一行テキストボックス（セパレート日付以外） --->
													<td>
														<md:MDTextBox ID="Old_jisya_hbn" CssClass="inpJishahin10" runat="server"></md:MDTextBox>
													</td>
													<th>
														<span class="tbl-hdg"><asp:Label ID="Scan_cd_lbl" runat="server">ｽｷｬﾝｺｰﾄﾞ</asp:Label></span>
													</th>
													<!--- 「スキャンコード」一行テキストボックス（セパレート日付以外） --->
													<td>
														<md:MDTextBox ID="Scan_cd" CssClass="inpScanHdg" runat="server"></md:MDTextBox>
													</td>
													<th>
														<span class="tbl-hdg"><asp:Label ID="Loss_kanri_no_lbl" runat="server">ロス管理No</asp:Label></span>
													</th>
													<!--- 「ロス管理№」一行テキストボックス（セパレート日付以外） --->
													<td>
														<md:MDTextBox ID="Loss_kanri_no" CssClass="inpKanriNo" runat="server"></md:MDTextBox>
													</td>
												</tr>
												<tr>
													<!--- 「明細ソート」ラジオボタン--->
													<td class="last" colspan="5">
														<span class="tbl-hdg label-none" style="display:none">&nbsp;</span>
														<adv:ConditionRBList ID="Meisai_sort" ConditionName="meisai_sort_tj190f01" RepeatDirection="Horizontal" CssClass="str-radio-table" runat="server"></adv:ConditionRBList>
													</td>
												</tr>
											</tbody>
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
					</ul>
					<ul>
						<!--帳票／CSV系ボタンを配置する場合はこのulタグの中-->
						<!--- 「印刷ボタン」ボタン --->
						<li><span><label><input type="button" id="Btnprint" value="" onserverclick="OnBTNPRINT_FRM" runat="server" class="icon-utility-04"/>印刷</label></span></li>
						<!--- 「CSVボタン」ボタン --->
						<li><span><label><input type="button" id="Btncsv" value="" onserverclick="OnBTNCSV_FRM" runat="server" class="icon-utility-05"/>CSV出力</label></span></li>
					</ul>
					<!-- /meisaiBtnArea --></div>
				<!-- /utility --></div>

				<!------------------------------------------
					□明細部
				-------------------------------------------->
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
							<div class="col1 col_2dan"><asp:Label ID="M1rowno_lbl" runat="server">No.</asp:Label></div>
							<div class="col2">
								<div><asp:Label ID="M1tenpo_cd_lbl" runat="server">店舗</asp:Label></div>
								<div><asp:Label ID="M1nyuryoku_ymd_lbl" runat="server">入力日</asp:Label></div>
							</div>
							<div class="col3">
								<div><asp:Label ID="M1rintana_kanri_no_lbl" runat="server">臨棚管理No</asp:Label></div>
								<div><asp:Label ID="M1loss_kanri_no_lbl" runat="server">ロス管理No</asp:Label></div>
							</div>
							<div class="col4">
								<div><asp:Label ID="M1bumon_cd_lbl" runat="server">部門</asp:Label></div>
								<div><asp:Label ID="M1hinsyu_ryaku_nm_lbl" runat="server">品種</asp:Label></div>
							</div>
							<div class="col5">
								<div><asp:Label ID="M1burando_nm1_lbl" runat="server">ブランド1</asp:Label></div>
								<div><asp:Label ID="M1burando_nm5_lbl" runat="server">ブランド5</asp:Label></div>
							</div>
							<div class="col6">
								<div><asp:Label ID="M1burando_nm2_lbl" runat="server">ブランド2</asp:Label></div>
								<div><asp:Label ID="M1burando_nm6_lbl" runat="server">ブランド6</asp:Label></div>
							</div>
							<div class="col7">
								<div><asp:Label ID="M1burando_nm3_lbl" runat="server">ブランド3</asp:Label></div>
								<div><asp:Label ID="M1burando_nm7_lbl" runat="server">ブランド7</asp:Label></div>
							</div>
							<div class="col8">
								<div><asp:Label ID="M1burando_nm4_lbl" runat="server">ブランド4</asp:Label></div>
								<div><asp:Label ID="M1burando_nm8_lbl" runat="server">ブランド8</asp:Label></div>
							</div>
							<div class="col9">
								<div class="col9-1 headcell"><asp:Label ID="M1tanajityobo_su_lbl" runat="server">棚時帳簿数</asp:Label></div>
								<div class="col9-2 bborderleft headcell"><asp:Label ID="M1tanajisekiso_su_lbl" runat="server">棚時積送数</asp:Label></div>
								<div class="col9-3 bborderleft headcell"><asp:Label ID="M1jitana_su_lbl" runat="server">実棚数</asp:Label></div>
								<div class="col9"><asp:Label ID="M1nyuryokutan_nm_lbl" runat="server">入力担当者</asp:Label></div>
							</div>
							<div class="col10">
								<div class="col10-1 headcell"><asp:Label ID="M1loss_su_lbl" runat="server">ロス数</asp:Label></div>
								<div class="col10-2 bborderleft headcell"><asp:Label ID="M1loss_kin_lbl" runat="server">ロス金額</asp:Label></div>
								<div class="col10"><asp:Label ID="M1losskeisan_ymd_lbl" runat="server">ロス計算日</asp:Label></div>
							</div>

							<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
							<div style="display:none">
								<div class="col3">
									<asp:Label ID="M1tenpo_nm_lbl" runat="server"></asp:Label>
								</div>
								<div class="col8">
								</div>
								<div class="col25">
									<asp:Label ID="M1losskeisan_tm_lbl" runat="server"></asp:Label>
								</div>
								<div class="col26">
									<asp:Label ID="M1selectorcheckbox_lbl" runat="server"></asp:Label>
								</div>
								<div class="col27">
									<asp:Label ID="M1entersyoriflg_lbl" runat="server"></asp:Label>
								</div>
								<div class="col28">
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
										<!--- 「ｍ１行no」テキストボックスリードオンリー --->
										<div class="col1 col_2dan detail_right"><asp:TextBox ID="M1rowno" CssClass="inpReadonlyRight inpRONum3" runat="server"></asp:TextBox></div>

										<!--- 「ｍ１店舗コード」テキストボックスリードオンリー ---><!--- 「ｍ１店舗名」テキストボックスリードオンリー --->
										<!--- 「ｍ１入力日」テキストボックスリードオンリー --->
										<div class="col2 detail_left">
											<div class="col2-1"><asp:TextBox ID="M1tenpo_cd" CssClass="inpReadonlyLeft inpRONum4" runat="server"></asp:TextBox><asp:TextBox ID="M1tenpo_nm" CssClass="inpReadonlyLeft inpROZenkaku10 inpRORightNm tooltip" runat="server"></asp:TextBox></div>
											<div class="col2-2 detail_center"><asp:TextBox ID="M1nyuryoku_ymd" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox></div>
										</div>

										<!--- 「ｍ１臨棚管理№」テキストボックスリードオンリー --->
										<!--- 「ｍ１ロス管理№」テキストボックスリードオンリー --->
										<div class="col3 detail_center">
											<div class="col3-1"><asp:TextBox ID="M1rintana_kanri_no" CssClass="inpReadonlyRight inpRONum6" runat="server"></asp:TextBox></div>
											<div class="col3-2"><asp:TextBox ID="M1loss_kanri_no" CssClass="inpReadonlyRight inpRONum6" runat="server"></asp:TextBox></div>
										</div>

										<!--- 「Ｍ１部門リンク」ボタン ---><!--- 「Ｍ１部門カナ名リンク」ボタン --->
										<!--- 「ｍ１品種略名称」テキストボックスリードオンリー --->
										<div class="col4 detail_left">
											<div><input type="button" id="M1bumon_cd" value="部門" onserverclick="OnM1BUMON_CD_FRM" runat="server" class="meisaiLink"/></div>
											<div><asp:TextBox ID="M1hinsyu_ryaku_nm" CssClass="inpReadonlyLeft inpROZenkaku10 tooltip" runat="server"></asp:TextBox></div>
										</div>

										<!--- 「ｍ１ブランド名1」テキストボックスリードオンリー --->
										<!--- 「ｍ１ブランド名5」テキストボックスリードオンリー --->
										<div class="col5 detail_left">
											<div ><asp:TextBox ID="M1burando_nm1" CssClass="inpReadonlyLeft inpROHankaku8 tooltip" runat="server"></asp:TextBox></div>
											<div ><asp:TextBox ID="M1burando_nm5" CssClass="inpReadonlyLeft inpROHankaku8 tooltip" runat="server"></asp:TextBox></div>
										</div>

										<!--- 「ｍ１ブランド名2」テキストボックスリードオンリー --->
										<!--- 「ｍ１ブランド名6」テキストボックスリードオンリー --->
										<div class="col6 detail_left">
											<div><asp:TextBox ID="M1burando_nm2" CssClass="inpReadonlyLeft inpROHankaku8 tooltip" runat="server"></asp:TextBox></div>
											<div><asp:TextBox ID="M1burando_nm6" CssClass="inpReadonlyLeft inpROHankaku8 tooltip" runat="server"></asp:TextBox></div>
										</div>

										<!--- 「ｍ１ブランド名3」テキストボックスリードオンリー --->
										<!--- 「ｍ１ブランド名7」テキストボックスリードオンリー --->
										<div class="col7 detail_left">
											<div><asp:TextBox ID="M1burando_nm3" CssClass="inpReadonlyLeft inpROHankaku8 tooltip" runat="server"></asp:TextBox></div>
											<div><asp:TextBox ID="M1burando_nm7" CssClass="inpReadonlyLeft inpROHankaku8 tooltip" runat="server"></asp:TextBox></div>
										</div>

										<!--- 「ｍ１ブランド名4」テキストボックスリードオンリー --->
										<!--- 「ｍ１ブランド名8」テキストボックスリードオンリー --->
										<div class="col8 detail_left">
											<div><asp:TextBox ID="M1burando_nm4" CssClass="inpReadonlyLeft inpROHankaku8 tooltip" runat="server"></asp:TextBox></div>
											<div><asp:TextBox ID="M1burando_nm8" CssClass="inpReadonlyLeft inpROHankaku8 tooltip" runat="server"></asp:TextBox></div>
										</div>

										<!--- 「ｍ１棚時帳簿数」テキストボックスリードオンリー --->
										<!--- 「ｍ１棚時積送数」テキストボックスリードオンリー --->
										<!--- 「ｍ１実棚数」テキストボックスリードオンリー --->
										<!--- 「ｍ１入力担当者名称」テキストボックスリードオンリー --->
										<div class="col9 detail_right">
											<div class="col9-1 cell detail_center"><asp:TextBox ID="M1tanajityobo_su" CssClass="inpReadonlyRight inpRONumCmaMinus8" runat="server"></asp:TextBox></div>
											<div class="col9-2 cell detail_right bborderleft"><asp:TextBox ID="M1tanajisekiso_su" CssClass="inpReadonlyRight inpRONumCmaMinus8" runat="server"></asp:TextBox></div>
											<div class="col9-3 cell detail_right bborderleft"><asp:TextBox ID="M1jitana_su" CssClass="inpReadonlyRight inpRONumCmaMinus8" runat="server"></asp:TextBox></div>
											<div class="col9  cell detail_left"><asp:TextBox ID="M1nyuryokutan_nm" CssClass="inpReadonlyLeft inpROZenkaku10 tooltip" runat="server"></asp:TextBox></div>
										</div>


										<!--- 「ｍ１ロス数」テキストボックスリードオンリー --->
										<!--- 「ｍ１ロス金額」テキストボックスリードオンリー --->
										<!--- 「ｍ１ロス計算日」テキストボックスリードオンリー --->
										<!--- 「ｍ１ロス計算時間」テキストボックスリードオンリー --->
										<div class="col10">
											<div class="col10-1 cell detail_center"><asp:TextBox ID="M1loss_su" CssClass="inpReadonlyRight inpRONumCmaMinus8" runat="server"></asp:TextBox></div>
											<div class="col10-2 cell detail_right bborderleft"><asp:TextBox ID="M1loss_kin" CssClass="inpReadonlyRight inpRONumCmaMinus9" runat="server"></asp:TextBox></div>
											<div class="col10 cell detail_center"><asp:TextBox ID="M1losskeisan_ymd" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox> <asp:TextBox ID="M1losskeisan_tm" CssClass="inpReadonlyLeft inpROTime" runat="server"></asp:TextBox></div>
										</div>

										<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
										<div style="display:none">
											<div class="col26">
												<!--- 「ｍ１選択フラグ(隠し)」チェックボックス --->
												<adv:AdvancedCheckBox ID="M1selectorcheckbox" Text="" CssClass="" runat="server"></adv:AdvancedCheckBox>
											</div>
											<div class="col27">
												<!--- 「Ｍ１確定処理フラグ(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1entersyoriflg" runat="server"></asp:hiddenfield>
											</div>
											<div class="col28">
												<!--- 「Ｍ１明細色区分(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1dtlirokbn" runat="server"></asp:hiddenfield>
											</div>
										</div>
									<!-- /str-result-item-01 --></div>
								</ItemTemplate>
							</asp:Repeater>
						<!-- /str-result-item-wrap --></div>

						<span class="adjust-elem-next"></span>
<%-- 合計欄表示制御--%>
<div id="meisaiSumArea" runat="server">
						<div id="str-ftr-area" class="str-result-ftr-01">
							<div class="col1 detail_left">&nbsp;</div>
							<div class="col2 detail_left">&nbsp;</div>
							<div class="col3 detail_left">&nbsp;</div>
							<div class="col4 detail_left">&nbsp;</div>
							<div class="col5 detail_left">&nbsp;</div>
							<div class="col6 detail_left">&nbsp;</div>
							<div class="col7 detail_left">&nbsp;</div>
							<div class="col8 detail_ftr_title"><asp:Label ID="Gokeitanajityobo_su_lbl" runat="server">合計</asp:Label></div>
							<!--- 「合計棚時帳簿数」テキストボックスリードオンリー --->
							<div class="col9-1-f cell detail_ftr"><span><asp:TextBox ID="Gokeitanajityobo_su" CssClass="inpReadonlyRight inpRONumCmaMinus8" runat="server"></asp:TextBox></span></div>
							<!--- 「合計棚時積送数」テキストボックスリードオンリー --->
							<div class="col9-2-f cell detail_ftr"><span><asp:TextBox ID="Gokeitanajisekiso_su" CssClass="inpReadonlyRight inpRONumCmaMinus8" runat="server"></asp:TextBox></span></div>
							<!--- 「合計実棚数」テキストボックスリードオンリー --->
							<div class="col9-3-f cell detail_ftr"><span><asp:TextBox ID="Gokeijitana_su" CssClass="inpReadonlyRight inpRONumCmaMinus8" runat="server"></asp:TextBox></span></div>
							<!--- 「合計ロス数」テキストボックスリードオンリー --->
							<div class="col10-1-f cell detail_ftr"><span><asp:TextBox ID="Gokeiloss_su" CssClass="inpReadonlyRight inpRONumCmaMinus8" runat="server"></asp:TextBox></span></div>
							<!--- 「合計ロス金額」テキストボックスリードオンリー --->
							<div class="col10-2-f cell detail_ftr"><span><asp:TextBox ID="Gokeiloss_kin" CssClass="inpReadonlyRight inpRONumCmaMinus9" runat="server"></asp:TextBox></span></div>
						<!-- /str-result-ftr-01 --></div>
</div>
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
							<!--- 「ボタン確定」ボタン --->
							<input type="button" id="Btnenter" value="確定" onserverclick="OnBTNENTER_FRM" runat="server" class="btn type-01"/>
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
			<!--- 「モードNO」隠しフィールド --->
			<asp:hiddenfield ID="Modeno" runat="server"></asp:hiddenfield>
			<!--- 「選択モードNO」隠しフィールド --->
			<asp:hiddenfield ID="Stkmodeno" runat="server"></asp:hiddenfield>
			<asp:Label ID="Searchcnt_lbl" runat="server"></asp:Label>
			<asp:Label ID="Nyuryoku_ymd_to_lbl" runat="server">入力日TO</asp:Label>
			<asp:Label ID="Tenpo_nm_from_lbl" runat="server"></asp:Label>
			<asp:Label ID="Tenpo_cd_to_lbl" runat="server">店舗TO</asp:Label>
			<asp:Label ID="Tenpo_nm_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Nyuryokutan_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Bumon_nm_from_lbl" runat="server"></asp:Label>
			<asp:Label ID="Hinsyu_cd_from_lbl" runat="server">品種FROM</asp:Label>
			<asp:Label ID="Hinsyu_ryaku_nm_from_lbl" runat="server"></asp:Label>
			<asp:Label ID="Bumon_cd_to_lbl" runat="server">部門TO</asp:Label>
			<asp:Label ID="Bumon_nm_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Hinsyu_cd_to_lbl" runat="server">品種TO</asp:Label>
			<asp:Label ID="Hinsyu_ryaku_nm_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Burando_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Meisai_sort_lbl" runat="server"></asp:Label>
			
			<asp:Label ID="Gokeitanajisekiso_su_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokeijitana_su_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokeiloss_su_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokeiloss_kin_lbl" runat="server"></asp:Label>
		</div>
	
	</form>
</body>
</html>

