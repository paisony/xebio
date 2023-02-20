<%@ Page language="c#" CodeFile="tj070f01.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Tj070p01.Page.Tj070f01Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">棚卸状況確認</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="tj070p01" FormId="tj070f01" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/tj070f01.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="tj070p01" FormId="tj070f01" runat="server" />

	<!-- Js業務部品のインポート --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02001.js" charset="UTF-8"></script><!-- 店舗検索 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script><!-- 0埋め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05011.js" charset="UTF-8"></script><!-- FROM-TOコピー処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05014.js" charset="UTF-8"></script><!-- 名称取得拡張 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05015.js" charset="UTF-8"></script><!-- 項目入力制御処理 -->

</head>

<body>
	<form id="Tj070f01" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="tj070p01" PgName="棚卸状況確認" FormId="tj070f01" FormName="棚卸状況確認" ></uc:Header>

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
			<!------------------------------------------
				□モードタブ
			-------------------------------------------->
			<div class="str-tab-menu clearfix">
				<ul class="tab-list">
					<li>
						<!--- 「モード照会ボタン」リンク --->
						<a id="Btnmoderef" href="#tab16" class="" runat="server">照会</a>
					</li>
					<li>
						<!--- 「モード終了確認照会ボタン」リンク --->
						<a id="Btnmodesyuryokakuninref" href="#tab21" class="" runat="server">終了確認照会</a>
					</li>
				</ul>
			</div>

			<div id="tab16" class="str-tab-cont"></div>
			<div id="tab21" class="str-tab-cont"></div>

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
												<col class="w-type-01"/>
												<col class="w-type-03"/>
												<col class="w-type-01"/>
												<col class="w-type-04"/>
												<col class="w-type-01"/>
												<col />
											</colgroup>
											<tr>
												<th scope="col">
													<span class="tbl-hdg">
														<asp:Label ID="Tenpo_cd_from_lbl" runat="server">店舗</asp:Label>
													</span>
												</th>
												<td colspan="3">
													<!--- 「店舗コードfrom」一行テキストボックス（セパレート日付以外） --->
													<!--- 「店舗コードFROMボタン」ボタン --->
													<!--- 「店舗名from」テキストボックスリードオンリー --->
													<span class="icon-in"><md:MDTextBox ID="Tenpo_cd_from" CssClass="inpSerch inpTenpo" runat="server"></md:MDTextBox><input type="button" id="Btntenpocd_from" name="Btntenpocd_from" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="Tenpo_nm_from" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
													<span class="label-fromto">～</span>
													<!--- 「店舗コードto」一行テキストボックス（セパレート日付以外） --->
													<!--- 「店舗コードTOボタン」ボタン --->
													<!--- 「店舗名to」テキストボックスリードオンリー --->
													<span class="icon-in"><md:MDTextBox ID="Tenpo_cd_to" CssClass="inpSerch inpTenpo" runat="server"></md:MDTextBox><input type="button" id="Btntenpocd_to" name="Btntenpocd_to" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="Tenpo_nm_to" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
												</td>
												<th scope="col">
													<span class="tbl-hdg">
														<asp:Label ID="Tenpo_kakutei_jyokyo_lbl" runat="server">店舗確定状況</asp:Label>
													</span>
												</th>
												<td>
													&nbsp;&nbsp;
													<!--- 「店舗確定状況」ドロップダウンリスト --->
													<md:MDConditionDDList ID="Tenpo_kakutei_jyokyo" ConditionName="tenpo_kakutei_jokyo" CssClass="slt-kakuteijyokyo" runat="server"></md:MDConditionDDList>
													<span class="select-arrow"></span></td>
												<th scope="col">
													<span class="tbl-hdg">
														<asp:Label ID="Sosin_jyotai_lbl" runat="server">送信状態</asp:Label>
													</span>
												</th>
												<td>
													<!--- 「送信状態」ドロップダウンリスト --->
													<md:MDConditionDDList ID="Sosin_jyotai" ConditionName="sosin_jotai" CssClass="slt-sousinjyotai" runat="server"></md:MDConditionDDList>
													<span class="select-arrow"></span></td>
											</tr>
											<tr>
												<th scope="col">
													<span class="tbl-hdg">
														<asp:Label ID="Hhtjissi_ymd_from_lbl" runat="server">HHT実施日</asp:Label>
													</span>
												</th>
												<td>
													<!--- 「hht実施日from」一行テキストボックス（セパレート日付以外） --->
													<!--- 「hht実施日to」一行テキストボックス（セパレート日付以外） --->
													<span class="icon-in"><md:MDTextBox ID="Hhtjissi_ymd_from" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span><span class="label-fromto">～</span><span class="icon-in"><md:MDTextBox ID="Hhtjissi_ymd_to" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span>
												</td>
												<th scope="col">
													<span class="tbl-hdg">
														<asp:Label ID="Sosin_kak_ymd_from_lbl" runat="server">送信日</asp:Label>
													</span>
												</th>
												<td colspan="3">
													<!--- 「送信確定日from」一行テキストボックス（セパレート日付以外） --->
													<!--- 「送信確定日to」一行テキストボックス（セパレート日付以外） --->
													<span class="icon-in"><md:MDTextBox ID="Sosin_kak_ymd_from" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span><span class="label-fromto">～</span><span class="icon-in"><md:MDTextBox ID="Sosin_kak_ymd_to" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span>
												</td>
												<td>
													<!--- 「今回フラグ」チェックボックス --->
													<span class="tbl-hdg label-none" style="display:none">&nbsp</span>
													<adv:AdvancedCheckBox ID="Konkai_flg" Text="今回分のみ" CssClass="" runat="server"></adv:AdvancedCheckBox>
												</td>
											</tr>
											<tr>
												<td colspan ="5"></td>
												<td class="last" colspan="3">
													<!--- 「明細ソート」ラジオボタン --->
													<span class="tbl-hdg label-none" style="display:none">&nbsp;</span>
													<adv:ConditionRBList ID="Meisai_sort" ConditionName="meisai_sort_tj070f01" RepeatDirection="Horizontal" CssClass="str-radio-table" runat="server"></adv:ConditionRBList>
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
							<div class="col1">
								<asp:Label ID="M1rowno_lbl" runat="server">No.</asp:Label>
							</div>
							<div class="col2">
								<asp:Label ID="M1tenpo_cd_lbl" runat="server">店舗</asp:Label>
							</div>
							<div class="col3">
								<asp:Label ID="M1hhtjissi_ymd_lbl" runat="server">HHT実施日</asp:Label>
							</div>
							<div class="col4">
								<asp:Label ID="M1sosin_kak_ymd_lbl" runat="server">送信確定日</asp:Label>
							</div>
							<div class="col5">
								<asp:Label ID="M1tenpo_kakutei_jyokyo_lbl" runat="server">店舗確定状況</asp:Label>
							</div>
							<div class="col6">
								<asp:Label ID="M1md_sosin_jyokyo_lbl" runat="server">ＭＤ送信状況</asp:Label>
							</div>

							<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
							<div style="display:none">
								<div class="col3">
									<asp:Label ID="M1tenpo_nm_lbl" runat="server"></asp:Label>
								</div>
								<div class="col7">
									<asp:Label ID="M1tenpo_kakutei_jotai_nm_lbl" runat="server"></asp:Label>
								</div>
								<div class="col9">
									<asp:Label ID="M1sosin_jotai_nm_lbl" runat="server"></asp:Label>
								</div>
								<div class="col10">
									<asp:Label ID="M1entersyoriflg_lbl" runat="server"></asp:Label>
								</div>
								<div class="col11">
									<asp:Label ID="M1dtlirokbn_lbl" runat="server"></asp:Label>
								</div>
								<div class="col12">
									<asp:Label ID="M1selectorcheckbox_lbl" runat="server"></asp:Label>
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
											<asp:TextBox ID="M1rowno" CssClass="inpReadonlyRight inpRONum4" runat="server"></asp:TextBox>
										</div>
										<div class="col2 detail_left">
											<!--- 「ｍ１店舗コード」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1tenpo_cd" CssClass="inpReadonlyLeft inpTenpo" runat="server"></asp:TextBox>
											<!--- 「ｍ１店舗名」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1tenpo_nm" CssClass="inpReadonlyLeft inpROZenkaku10 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col3 detail_center">
											<!--- 「ｍ１hht実施日」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1hhtjissi_ymd" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox>
										</div>
										<div class="col4 detail_center">
											<!--- 「ｍ１送信確定日」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1sosin_kak_ymd" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox>
										</div>
										<div class="col5 detail_left">
											<!--- 「ｍ１店舗確定状況」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1tenpo_kakutei_jyokyo" CssClass="inpReadonlyRight inpRONum2" runat="server"></asp:TextBox>
											<!--- 「ｍ１店舗確定状況名称」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1tenpo_kakutei_jotai_nm" CssClass="inpReadonlyLeft inpROZenkaku6 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col6">
											<!--- 「ｍ１ｍｄ送信状況」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1md_sosin_jyokyo" CssClass="inpReadonlyRight inpRONum2" runat="server"></asp:TextBox>
											<!--- 「ｍ１送信状況名称」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1sosin_jotai_nm" CssClass="inpReadonlyLeft inpROZenkaku6 tooltip" runat="server"></asp:TextBox>
										</div>

										<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
										<div style="display: none">

											<div class="col10">
												<!--- 「Ｍ１確定処理フラグ(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1entersyoriflg" runat="server"></asp:hiddenfield>
											</div>
											<div class="col11">
												<!--- 「Ｍ１明細色区分(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1dtlirokbn" runat="server"></asp:hiddenfield>
											</div>
											<div class="col12">
												<!--- 「ｍ１選択フラグ(隠し)」チェックボックス --->
												<adv:AdvancedCheckBox ID="M1selectorcheckbox" Text="" CssClass="" runat="server"></adv:AdvancedCheckBox>
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

			<!--- 「モードNO」隠しフィールド --->
			<asp:hiddenfield ID="Modeno" runat="server"></asp:hiddenfield>
			<!--- 「選択モードNO」隠しフィールド --->
			<asp:hiddenfield ID="Stkmodeno" runat="server"></asp:hiddenfield>

			<asp:Label ID="Tenpo_nm_from_lbl" runat="server"></asp:Label>
			<asp:Label ID="Tenpo_cd_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Tenpo_nm_to_lbl" runat="server"></asp:Label>

			<asp:Label ID="Hhtjissi_ymd_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Sosin_kak_ymd_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Konkai_flg_lbl" runat="server">今回分のみ</asp:Label>
			<asp:Label ID="Meisai_sort_lbl" runat="server"></asp:Label>

			<asp:Label ID="Searchcnt_lbl" runat="server"></asp:Label>
		     
		</div>
	
	</form>
</body>
</html>

