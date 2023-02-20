<%@ Page language="c#" CodeFile="tk040f01.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Tk040p01.Page.Tk040f01Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">ロケーション検索</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="tk040p01" FormId="tk040f01" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/tk040f01.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="tk040p01" FormId="tk040f01" runat="server" />

	<!-- Js業務部品のインポート --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05003.js" charset="UTF-8"></script><!-- 明細背景色変更処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02001.js" charset="UTF-8"></script><!-- 店舗検索 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02003.js" charset="UTF-8"></script><!-- 名称検索 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02004.js" charset="UTF-8"></script><!-- 名称検索 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02005.js" charset="UTF-8"></script><!-- 名称取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02010.js" charset="UTF-8"></script><!-- 部門マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05001.js" charset="UTF-8"></script><!-- 自社品番丸め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05002.js" charset="UTF-8"></script><!-- スキャンコード丸め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script><!-- 0埋め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05011.js" charset="UTF-8"></script><!-- FROM-TOコピー処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05014.js" charset="UTF-8"></script><!-- 名称取得拡張 -->

	<!-- 業務共通コントロールのインポート-->
	<%@ Register TagPrefix="uc" TagName="common" Src="~/pjcommon/businessCommon/usercontrol/boCommonControl.ascx" %>

</head>

<body>
	<form id="Tk040f01" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="tk040p01" PgName="ロケーション検索" FormId="tk040f01" FormName="ロケーション検索" ></uc:Header>

			<!------------------------------------------	
				□業務共通コントロール
			------------------------------------------->	
			<uc:common ID="bocommon" runat="server"></uc:common>	

			<p class="headerTenpo">
				<span class="icon-in">
					<!--- 「ヘッダ店舗コード」一行テキストボックス（セパレート日付以外） --->
					<md:MDTextBox ID="Head_tenpo_cd" CssClass="inpSerch inpHeaderTenpo" runat="server"></md:MDTextBox>
					<!--- 「ヘッダ店舗コードボタン」ボタン --->
					<input type="button" id="Btnheadtenpocd" name="Btnheadtenpocd" value="" runat="server" class="icon-search"/>
				</span>
				<!--- 「ヘッダ店舗名」テキストボックスリードオンリー --->
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
					<!--<p class="required">*が付いている項目は必須入力になります。</p>-->
					<table class="search-table">
						<tr>
							<td class="search-table-tdleft">
								<div class="str-form-02">
									<div class="inner">
										<table>
											<colgroup>
												<col class="w-type-01"/>
												<col class="w-type-02"/>
												<col class="w-type-03"/>
												<col />
											</colgroup>
											<tr>
												<th scope="col">
													<span class="tbl-hdg">
														<asp:Label ID="Bumon_cd_from_lbl" runat="server">部門</asp:Label>
													</span>
												</th>
												<td>
													<!--- 「部門コードfrom」一行テキストボックス（セパレート日付以外） --->
													<!--- 「部門コードFROMボタン」ボタン --->
													<!--- 「部門名from」テキストボックスリードオンリー --->
													<span class="icon-in"><md:MDTextBox ID="Bumon_cd_from" CssClass="inpSerch inpBumon" runat="server"></md:MDTextBox><input type="button" id="Btnbumon_cd_from" name="Btnbumon_cd_from" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="Bumon_nm_from"  CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
													<span class="label-fromto">～</span>
													<!--- 「部門コードto」一行テキストボックス（セパレート日付以外） --->
													<!--- 「部門コードTOボタン」ボタン --->
													<!--- 「部門名to」テキストボックスリードオンリー --->
													<span class="icon-in"><md:MDTextBox ID="Bumon_cd_to" CssClass="inpSerch inpBumon" runat="server"></md:MDTextBox><input type="button" id="Btnbumon_cd_to" name="Btnbumon_cd_to" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="Bumon_nm_to"  CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
												</td>
												<th scope="col">
													<span class="tbl-hdg">
														<asp:Label ID="Hanbaikanryo_ymd_from_lbl" runat="server">販売完了日</asp:Label>
													</span>
												</th>
												<td>
													<!--- 「販売完了日from」一行テキストボックス（セパレート日付以外） --->
													<!--- 「販売完了日to」一行テキストボックス（セパレート日付以外） --->
													<span class="icon-in"><md:MDTextBox ID="Hanbaikanryo_ymd_from" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span><span class="label-fromto">～</span><span class="icon-in"><md:MDTextBox ID="Hanbaikanryo_ymd_to" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span>
												</td>
											</tr>
											<tr>
												<th scope="col">
													<span class="tbl-hdg">
														<asp:Label ID="Old_jisya_hbn_lbl" runat="server">自社品番</asp:Label>
													</span>
												</th>
												<td colspan="3">
													<!--- 「旧自社品番」一行テキストボックス（セパレート日付以外） --->
													<md:MDTextBox ID="Old_jisya_hbn" CssClass="inpJishahin10 multiinput" runat="server"></md:MDTextBox>
													<!--- 「旧自社品番2」一行テキストボックス（セパレート日付以外） --->
													<md:MDTextBox ID="Old_jisya_hbn2" CssClass="inpJishahin10 multiinput" runat="server"></md:MDTextBox>
													<!--- 「旧自社品番3」一行テキストボックス（セパレート日付以外） --->
													<md:MDTextBox ID="Old_jisya_hbn3" CssClass="inpJishahin10 multiinput" runat="server"></md:MDTextBox>
													<!--- 「旧自社品番4」一行テキストボックス（セパレート日付以外） --->
													<md:MDTextBox ID="Old_jisya_hbn4" CssClass="inpJishahin10 multiinput" runat="server"></md:MDTextBox>
													<!--- 「旧自社品番5」一行テキストボックス（セパレート日付以外） --->
													<md:MDTextBox ID="Old_jisya_hbn5" CssClass="inpJishahin10 multiinput" runat="server"></md:MDTextBox>
												</td>
											</tr>
											<tr>
												<th scope="col">
													<span class="tbl-hdg">
														<asp:Label ID="Scan_cd_lbl" runat="server">ｽｷｬﾝｺｰﾄﾞ</asp:Label>
													</span>
												</th>
												<td colspan="3">
													<!--- 「スキャンコード」一行テキストボックス（セパレート日付以外） --->
													<md:MDTextBox ID="Scan_cd" CssClass="inpScanHdg multiinput" runat="server"></md:MDTextBox>
													<!--- 「スキャンコード2」一行テキストボックス（セパレート日付以外） --->
													<md:MDTextBox ID="Scan_cd2" CssClass="inpScanHdg multiinput" runat="server"></md:MDTextBox>
													<!--- 「スキャンコード3」一行テキストボックス（セパレート日付以外） --->
													<md:MDTextBox ID="Scan_cd3" CssClass="inpScanHdg multiinput" runat="server"></md:MDTextBox>
													<!--- 「スキャンコード4」一行テキストボックス（セパレート日付以外） --->
													<md:MDTextBox ID="Scan_cd4" CssClass="inpScanHdg multiinput" runat="server"></md:MDTextBox>
													<!--- 「スキャンコード5」一行テキストボックス（セパレート日付以外） --->
													<md:MDTextBox ID="Scan_cd5" CssClass="inpScanHdg multiinput" runat="server"></md:MDTextBox>
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
					</ul>
					<ul>
						<!--帳票／CSV系ボタンを配置する場合はこのulタグの中-->
						<!--- 「印刷ボタン」ボタン --->
						<li><span><label><input type="button" id="Btnprint" value="" onserverclick="OnBTNPRINT_FRM" runat="server" class="icon-utility-04"/>印刷</label></span></li>
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
							<div class="col5">
								<div><asp:Label ID="M1maker_hbn_lbl" runat="server">メーカー品番</asp:Label></div>
								<div><asp:Label ID="M1syonmk_lbl" runat="server">商品名</asp:Label></div>
							</div>
							<div class="col6 col_2dan">
								<asp:Label ID="M1hanbaikanryo_ymd_lbl" runat="server">販売完了日</asp:Label>
							</div>
							<div class="col7">
								<div><asp:Label ID="M1iro_nm_lbl" runat="server">色</asp:Label></div>
								<div><asp:Label ID="M1size_nm_lbl" runat="server">サイズ</asp:Label></div>
							</div>
							<div class="col8 col_2dan">
								<asp:Label ID="M1scan_cd_lbl" runat="server">ｽｷｬﾝｺｰﾄﾞ</asp:Label>
							</div>
							<div class="col9 col_2dan">
								<asp:Label ID="M1face_no_lbl" runat="server">ﾌｪｲｽNo.</asp:Label>
							</div>
							<div class="col10 col_2dan">
								<asp:Label ID="M1tana_dan_lbl" runat="server">棚段</asp:Label>
							</div>
							<div class="col11 col_2dan">
								<asp:Label ID="M1tanaorosi_su_lbl" runat="server">数量</asp:Label>
							</div>

							<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
							<div style="display:none">

								<div class="col3">
									<asp:Label ID="M1bumonkana_nm_lbl" runat="server"></asp:Label>
								</div>

								<div class="col16">
									<asp:Label ID="M1selectorcheckbox_lbl" runat="server"></asp:Label>
								</div>
								<div class="col17">
									<asp:Label ID="M1entersyoriflg_lbl" runat="server"></asp:Label>
								</div>
								<div class="col18">
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
										<div class="col1 col_2dan detail_right">
											<!--- 「ｍ１no」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1rowno" CssClass="inpReadonlyRight inpRONum4" runat="server"></asp:TextBox>
										</div>
										<div class="col2 detail_left">
                                            <div>
												<!--- 「ｍ１部門コード」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1bumon_cd" CssClass="inpReadonlyLeft inpBumon" runat="server"></asp:TextBox>
												<!--- 「ｍ１部門カナ名」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1bumonkana_nm" CssClass="inpReadonlyLeft inpROHankaku12 tooltip" runat="server"></asp:TextBox>
    										</div>
                                            <div>
												<!--- 「ｍ１品種略名称」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1hinsyu_ryaku_nm" CssClass="inpReadonlyLeft inpROZenkaku10 tooltip" runat="server"></asp:TextBox>
    										</div>
										</div>
										<div class="col3 col_2dan detail_left">
											<!--- 「ｍ１ブランド名」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1burando_nm" CssClass="inpReadonlyLeft inpROHankaku16 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col4 col_2dan detail_left">
											<!--- 「ｍ１自社品番」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1jisya_hbn" CssClass="inpReadonlyLeft inpRONum8" runat="server"></asp:TextBox>
										</div>
										<div class="col5 detail_left">
                                            <div>
												<!--- 「ｍ１メーカー品番」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1maker_hbn" CssClass="inpReadonlyLeft inpROHankaku30 tooltip" runat="server"></asp:TextBox>
                                            </div>
                                            <div>
												<!--- 「ｍ１商品名(カナ)」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1syonmk" CssClass="inpReadonlyLeft inpROHankaku20 tooltip" runat="server"></asp:TextBox>
                                            </div>
										</div>
										<div class="col6 col_2dan detail_center">
											<!--- 「ｍ１販売完了日」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1hanbaikanryo_ymd" CssClass="inpReadonlyCenter inpRODate" runat="server"></asp:TextBox>
										</div>
										<div class="col7 detail_left">
                                           <div>
												<!--- 「ｍ１色」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1iro_nm" CssClass="inpReadonlyLeft inpROHankaku6 tooltip" runat="server"></asp:TextBox>
                                           </div>
                                           <div>
												<!--- 「ｍ１サイズ」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1size_nm" CssClass="inpReadonlyLeft inpROHankaku4 tooltip" runat="server"></asp:TextBox>
                                           </div>
										</div>
										<div class="col8 col_2dan detail_center">
											<!--- 「ｍ１スキャンコード」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1scan_cd" CssClass="inpReadonlyLeft inpRONum13" runat="server"></asp:TextBox>
										</div>
										<div class="col9 col_2dan detail_center">
											<!--- 「ｍ１フェイス№」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1face_no" CssClass="inpReadonlyCenter inpRONum5" runat="server"></asp:TextBox>
										</div>
										<div class="col10 col_2dan detail_right">
											<!--- 「ｍ１棚段」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1tana_dan" CssClass="inpReadonlyRight inpRONum2" runat="server"></asp:TextBox>
										</div>
										<div class="col11 col_2dan detail_right">
											<!--- 「ｍ１棚卸数量」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1tanaorosi_su" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
										</div>


										<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
										<div style="display: none">

											<div class="col16">
												<!--- 「ｍ１選択フラグ(隠し)」チェックボックス --->
												<adv:AdvancedCheckBox ID="M1selectorcheckbox" Text="" CssClass="" runat="server"></adv:AdvancedCheckBox>
											</div>
											<div class="col17">
												<!--- 「Ｍ１確定処理フラグ(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1entersyoriflg" runat="server"></asp:hiddenfield>
											</div>
											<div class="col18">
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
						</p>
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

			<asp:Label ID="Bumon_nm_from_lbl" runat="server"></asp:Label>
			<asp:Label ID="Bumon_cd_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Bumon_nm_to_lbl" runat="server"></asp:Label>

			<asp:Label ID="Hanbaikanryo_ymd_to_lbl" runat="server"></asp:Label>

			<asp:Label ID="Old_jisya_hbn2_lbl" runat="server">自社品番</asp:Label>
			<asp:Label ID="Old_jisya_hbn3_lbl" runat="server">自社品番</asp:Label>
			<asp:Label ID="Old_jisya_hbn4_lbl" runat="server">自社品番</asp:Label>
			<asp:Label ID="Old_jisya_hbn5_lbl" runat="server">自社品番</asp:Label>

			<asp:Label ID="Scan_cd2_lbl" runat="server">ｽｷｬﾝｺｰﾄﾞ</asp:Label>
			<asp:Label ID="Scan_cd3_lbl" runat="server">ｽｷｬﾝｺｰﾄﾞ</asp:Label>
			<asp:Label ID="Scan_cd4_lbl" runat="server">ｽｷｬﾝｺｰﾄﾞ</asp:Label>
			<asp:Label ID="Scan_cd5_lbl" runat="server">ｽｷｬﾝｺｰﾄﾞ</asp:Label>

			<asp:Label ID="Searchcnt_lbl" runat="server"></asp:Label>

		</div>
	
	</form>
</body>
</html>

