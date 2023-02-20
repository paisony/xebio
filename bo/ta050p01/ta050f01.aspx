<%@ Page language="c#" CodeFile="ta050f01.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Ta050p01.Page.Ta050f01Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">単品レポート状況照会</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="ta050p01" FormId="ta050f01" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/ta050f01.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="ta050p01" FormId="ta050f01" runat="server" />

	<!-- Js業務部品のインポート --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02001.js" charset="UTF-8"></script><!-- 店舗検索 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02002.js" charset="UTF-8"></script><!-- 仕入先マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02005.js" charset="UTF-8"></script><!-- 担当者マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02010.js" charset="UTF-8"></script><!-- 部門マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02012.js" charset="UTF-8"></script><!-- 品種マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05002.js" charset="UTF-8"></script><!-- スキャンコード丸め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script><!-- 0埋め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05009.js" charset="UTF-8"></script><!-- 指示番号丸め処理(返品用) -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05011.js" charset="UTF-8"></script><!-- FROM-TOコピー処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
</head>

<body>
	<form id="Ta050f01" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">				
			<uc:Header ID="header" runat="server" PgId="ta050p01" PgName="単品レポート状況照会" FormId="ta050f01" FormName="単品レポート状況照会 一覧" ></uc:Header>
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
									<!--- 「検索件数」テキストボックスリードオンリー --->
									<p class="txt-02">該当件数<span class="hit-number"><asp:TextBox ID="Searchcnt" CssClass="inpReadonlyRight inpSearchCnt" runat="server"></asp:TextBox></span><span>件</span></p>
								<!-- /list-search-result --></div>
							</td>
						</tr>
					</table>
				<!-- /inner-01 --></div>
		
				<!------------------------------------------
				  □検索条件領域(入力時)
				-------------------------------------------->
				<div class="inner-02">
					<!--- <p class="required">*が付いている項目は必須入力になります。</p>--->
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
												<col class="w-type-03"/>
												<col />
											</colgroup>
											<tbody>
												<tr>
													<th scope="col">
														<span class="tbl-hdg"><asp:Label ID="Henko_kbn_lbl" runat="server">変更区分</asp:Label></span>
													</th>
													<td>
														<!--- 「変更区分」ドロップダウンリスト --->
														<md:MDConditionDDList ID="Henko_kbn" ConditionName="henko_kbn2" CssClass="slt-kbn" runat="server"></md:MDConditionDDList>
														<span class="select-arrow"></span>
													</td>
													<th scope="col"><span class="tbl-hdg"><asp:Label ID="Bumon_cd_from_lbl" runat="server">部門FROM</asp:Label></span></th>
													<td>
														<!--- 「部門コードfrom」一行テキストボックス（セパレート日付以外） --->
														<!--- 「部門コードFROMボタン」ボタン --->
														<!--- 「部門名from」テキストボックスリードオンリー --->
														<!--- 「部門コードto」一行テキストボックス（セパレート日付以外） --->
														<!--- 「部門コードTOボタン」ボタン --->
														<!--- 「部門名to」テキストボックスリードオンリー --->
														<span class="icon-in"><md:MDTextBox ID="Bumon_cd_from" CssClass="inpSerch inpBumon" runat="server"></md:MDTextBox><input type="button" id="Btnbumon_cd_from" name="Btnbumon_cd_from" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="Bumon_nm_from" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
														<span class="label-fromto">～</span>
														<span class="icon-in"><md:MDTextBox ID="Bumon_cd_to" CssClass="inpSerch inpBumon" runat="server"></md:MDTextBox><input type="button" id="Btnbumon_cd_to" name="Btnbumon_cd_to" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="Bumon_nm_to" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
													</td>
												</tr>
												<tr>
													<th class="last">
														<span class="tbl-hdg"><asp:Label ID="Kessai_ymd_from_lbl" runat="server">決裁日FROM</asp:Label></span>
													</th>
													<td class ="last">
														<!--- 「決裁日from」一行テキストボックス（セパレート日付以外） --->
														<!--- 「決裁日to」一行テキストボックス（セパレート日付以外） --->
														<label><span class="icon-in"><md:MDTextBox ID="Kessai_ymd_from" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span><span class="label-fromto">～</span><span class="icon-in"><md:MDTextBox ID="Kessai_ymd_to" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span></label>
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
								<div class="col1 detail_right">
									<asp:Label ID="M1rowno_lbl" runat="server">No.</asp:Label>
								</div>
								<div class="col2 detail_left">
									<asp:Label ID="M1henko_kbn_nm_lbl" runat="server">変更区分</asp:Label>
								</div>
								<div class="col3 detail_left">
									<asp:Label ID="M1bumon_cd_lbl" runat="server">部門</asp:Label>
								</div>
								<div class="col4 detail_center">
									<asp:Label ID="M1irai_su_lbl" runat="server">依頼数量</asp:Label>
								</div>
								<div class="col5 detail_right">
									<asp:Label ID="M1genkakin_lbl" runat="server">原価金額</asp:Label>
								</div>
								<div class="col6 detail_right">
									<asp:Label ID="M1kessai_ymd_lbl" runat="server">決裁日</asp:Label>
								</div>
								<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
								<div style="display:none">
									<div class="col7">
										<asp:Label ID="M1selectorcheckbox_lbl" runat="server"></asp:Label>
									</div>
									<div class="col8">
										<asp:Label ID="M1entersyoriflg_lbl" runat="server"></asp:Label>
									</div>
									<div class="col9">
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
										<div class="str-result-item-01">
											<div class="col1 detail_right">
												<!--- 「ｍ１行no」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1rowno" CssClass="inpReadonlyRight inpRONum3" runat="server"></asp:TextBox>
											</div>
											<div class="col2 detail_left">
												<!--- 「ｍ１変更区分名称」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1henko_kbn_nm" CssClass="inpReadonlyLeft inpROZenkaku6 tooltip" runat="server"></asp:TextBox>
											</div>
											<div class="col3 detail_left">
												<!--- 「Ｍ１部門リンク」ボタン --->
												<input type="button" id="M1bumon_cd" value="部門" onserverclick="OnM1BUMON_CD_FRM" runat="server" class="meisaiLink"/>
											</div>
											<div class="col4 detail_right">
												<!--- 「ｍ１依頼数量」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1irai_su" CssClass="inpReadonlyRight inpRONumCma9" runat="server"></asp:TextBox>
											</div>
											<div class="col5 detail_right">
												<!--- 「ｍ１原価金額」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1genkakin" CssClass="inpReadonlyRight inpRONumCma9" runat="server"></asp:TextBox>
											</div>
											<div class="col6 detail_center">
												<!--- 「ｍ１決裁日」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1kessai_ymd" CssClass="inpReadonlyCenter inpRODate" runat="server"></asp:TextBox>
											</div>
											<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
                                        	<div style="display:none">
												<div class="col7">
													<!--- 「ｍ１選択フラグ(隠し)」チェックボックス --->
													<adv:AdvancedCheckBox ID="M1selectorcheckbox" Text="" CssClass="" runat="server"></adv:AdvancedCheckBox>
												</div>
												<div class="col8">
													<!--- 「Ｍ１確定処理フラグ(隠し)」隠しフィールド --->
													<asp:hiddenfield ID="M1entersyoriflg" runat="server"></asp:hiddenfield>
												</div>
												<div class="col9">
													<!--- 「Ｍ１明細色区分(隠し)」隠しフィールド --->
													<asp:hiddenfield ID="M1dtlirokbn" runat="server"></asp:hiddenfield>
												</div>
											</div>
											<!--- 隠し項目エリア↑↑↑↑↑↑↑↑↑↑↑↑↑ --->
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
								<!-- ページャ下部にボタンを配置する場合はこの中 -->
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
			<asp:Label ID="Bumon_cd_to_lbl" runat="server">部門TO</asp:Label>
			<asp:Label ID="Bumon_nm_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Bumon_nm_from_lbl" runat="server"></asp:Label>
			<asp:Label ID="Kessai_ymd_to_lbl" runat="server">決裁日TO</asp:Label>
			<asp:Label ID="Searchcnt_lbl" runat="server"></asp:Label>
		</div>
	</form>
</body>
</html>

