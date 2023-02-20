<%@ Page language="c#" CodeFile="th010f02.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Th010p01.Page.Th010f02Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">商品マスタ検索</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="th010p01" FormId="th010f02" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/th010f02.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="th010p01" FormId="th010f02" runat="server" />

	<!-- Js業務部品のインポート --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05021.js" charset="UTF-8"></script><!-- パラメータ取得部品 -->
</head>

<body>
	<form id="Th010f02" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="th010p01" PgName="商品マスタ検索" FormId="th010f02" FormName="商品マスタ検索（メーカー品番）" ></uc:Header>
			
		<!------------------------------------------
			□ヘッダー部
		-------------------------------------------->
		<!--- 「戻るボタン」ボタン --->
		<p class="headerBackBtn">
			<input type="button" id="Btnback" value="" onserverclick="OnBTNBACK_FRM" runat="server" class="btn type-back"/>
		</p>

		<!--- 「ヘッダ店舗コード」テキストボックスリードオンリー --->
		<!--- 「ヘッダ店舗名」テキストボックスリードオンリー --->
		<p class="headerTenpo">
			<asp:TextBox ID="Head_tenpo_cd" CssClass="inpReadonlyLeft inpHeaderTenpoDisabled" runat="server"></asp:TextBox>
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
						<table class="search-table">
							<tr>
								<td class="search-table-tdleft">
									<div class="list-search-condition">
									<!-- /list-search-condition --></div>
								</td>
								<td class="search-table-tdright">
								<p id="list-search">
									<!--- 「検索件数」テキストボックスリードオンリー --->
									<p class="txt-02">該当件数<span class="hit-number"><asp:TextBox ID="Searchcnt" CssClass="inpReadonlyRight inpSearchCnt" runat="server"></asp:TextBox></span><span>件</span>
									</p>
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
											<col class="w-type-02"/>
											<col class="w-type-01"/>
											<col class="w-type-02"/>
											<col class="w-type-01"/>
											<col />
										</colgroup>
											<tr>
												<th scope="col">
													<span class="tbl-hdg">
														<asp:Label ID="Siiresaki_cd_lbl" runat="server">仕入先</asp:Label>
													</span>
												</th>
												<td>
													<!--- 「仕入先コード」テキストボックスリードオンリー --->
													<!--- 「仕入先略式名称」テキストボックスリードオンリー --->
													<span><asp:TextBox ID="Siiresaki_cd" CssClass="inpReadonlyLeft inpShiire" runat="server"></asp:TextBox></span>
													<asp:TextBox ID="Siiresaki_ryaku_nm" CssClass="inpReadonlyLeft " runat="server"></asp:TextBox>
												</td>
												<th scope="col">
													<span class="tbl-hdg">
														<asp:Label ID="Burando_cd_lbl" runat="server">ブランド</asp:Label>
													</span>
												</th>
												<td colspan="2">
													<!--- 「ブランドコード」テキストボックスリードオンリー --->
													<!--- 「ブランド名」テキストボックスリードオンリー --->
													<asp:TextBox ID="Burando_cd" CssClass="inpReadonlyLeft inpBrand" runat="server"></asp:TextBox>
													<asp:TextBox ID="Burando_nm" CssClass="inpReadonlyLeft inpROHankaku20" runat="server"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<th scope="col">
													<span class="tbl-hdg">
														<asp:Label ID="Maker_hbn_lbl" runat="server">メーカー品番</asp:Label><asp:Label ID="Maker_hbn_Req" runat="server" CssClass="required">*</asp:Label>
													</span>
												</th>
												<td colspan="5">
													<!--- 「メーカー品番」一行テキストボックス（セパレート日付以外） --->
													<md:MDTextBox ID="Maker_hbn" CssClass="inpMkhin" runat="server"></md:MDTextBox>
												</td>
											</tr>
											<tr>
												<th scope="col">
													<span class="tbl-hdg">
														<asp:Label ID="Genka_flg_lbl" runat="server">原価</asp:Label>
													</span>
												</th>
												<td>
													<!--- 「原価フラグ」チェックボックス --->
													<!--- 「原価」テキストボックスリードオンリー --->
													<adv:AdvancedCheckBox ID="Genka_flg" Text="" CssClass="" runat="server"></adv:AdvancedCheckBox>
													<asp:TextBox ID="Genka" CssClass="inpReadonlyLeft inpRONumCma8 noSet" runat="server"></asp:TextBox>
												</td>
												<th scope="col">
													<span class="tbl-hdg">
														<asp:Label ID="Genbaika_flg_lbl" runat="server">現売価</asp:Label>
													</span>
												</th>
												<td>
													<!--- 「現売価フラグ」チェックボックス --->
													<!--- 「現売価」テキストボックスリードオンリー --->
													<adv:AdvancedCheckBox ID="Genbaika_flg" Text="" CssClass="" runat="server"></adv:AdvancedCheckBox>
													<asp:TextBox ID="Genbaika_tnk" CssClass="inpReadonlyLeft inpRONumCma8 noSet" runat="server"></asp:TextBox>
												</td>
												<th scope="col">
													<span class="tbl-hdg">
														<asp:Label ID="Makerkakaku_flg_lbl" runat="server">ﾒｰｶｰ価格</asp:Label>
													</span>
												</th>
												<td>
													<!--- 「メーカー価格フラグ」チェックボックス --->
													<!--- 「メーカー価格」テキストボックスリードオンリー --->
													<adv:AdvancedCheckBox ID="Makerkakaku_flg" Text="" CssClass="" runat="server"></adv:AdvancedCheckBox>
													<asp:TextBox ID="Makerkakaku_tnk" CssClass="inpReadonlyLeft inpRONumCma8 noSet" runat="server"></asp:TextBox>
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
							<!--- 「商品マスタ検索選択」ラジオボタン --->
							<adv:ConditionRBList ID="Syohinmst_serchstk" ConditionName="syohinmst_serchstk2" RepeatDirection="Horizontal" CssClass="str-radio-table" runat="server" ForeColor="Black"></adv:ConditionRBList>
						</li>
					</ul>
					<ul>
						<!--帳票／CSV系ボタンを配置する場合はこのulタグの中-->
						<li>
							<!--- 「CSV出力ボタン」ボタン --->
							<span><label><input type="button" id="Btncsv" value="" onserverclick="OnBTNCSV_FRM" runat="server" class="icon-utility-05"/>CSV出力</label></span>
						</li>
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
							<div class="col2 col_2dan">
								<asp:Label ID="M1siiresaki_cd_lbl" runat="server">仕入先</asp:Label>
							</div>
							<div class="col3">
								<div><asp:Label ID="M1bumon_cd_lbl" runat="server">部門</asp:Label></div>
								<div><asp:Label ID="M1hinsyu_cd_lbl" runat="server">品種</asp:Label></div>
							</div>
							<div class="col4">
								<div><asp:Label ID="M1burando_nm_lbl" runat="server">ブランド</asp:Label></div>
								<div><asp:Label ID="M1jisya_hbn_lbl" runat="server">自社品番</asp:Label></div>
							</div>
							<div class="col5 col_2dan">
								<asp:Label ID="M1syohin_zokusei_lbl" runat="server">コア</asp:Label>
							</div>
							<div class="col6">
								<div><asp:Label ID="M1maker_hbn_lbl" runat="server">メーカー品番</asp:Label></div>
								<div><asp:Label ID="M1syonmk_lbl" runat="server">商品名</asp:Label></div>
							</div>
							<div class="col7 col_2dan">
								<asp:Label ID="Label1" runat="server">色</asp:Label>
							</div>
							<div class="col8 col_2dan">
								<asp:Label ID="M1hanbaikanryo_ymd_lbl" runat="server">販売完了日</asp:Label>
							</div>
							<div class="col9">
								<div><asp:Label ID="M1saisinbaika_tnk_lbl" runat="server">最新売価</asp:Label></div>
								<div><asp:Label ID="M1genka_lbl" runat="server">原価</asp:Label></div>
							</div>
							<div class="col10">
								<div><asp:Label ID="M1genbaika_tnk_lbl" runat="server">現売価</asp:Label></div>
								<div><asp:Label ID="M1makerkakaku_tnk_lbl" runat="server">ﾒｰｶｰ価格</asp:Label></div>
							</div>

							<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
							<div style="display: none">
								<div class="col19">
									<asp:Label ID="M1selectorcheckbox_lbl" runat="server"></asp:Label>
								</div>
								<div class="col20">
									<asp:Label ID="M1entersyoriflg_lbl" runat="server"></asp:Label>
								</div>
								<div class="col21">
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
										<div class="col1 col_2dan detail_right">
											<!--- 「ｍ１行no」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1rowno" CssClass="inpReadonlyRight inpRONum3" runat="server"></asp:TextBox>
										</div>
										<div class="col2 col_2dan detail_left" style="line-height:inherit">
											<!--- 「ｍ１仕入先コード」テキストボックスリードオンリー --->
											<!--- 「ｍ１仕入先名称」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1siiresaki_cd" CssClass="inpReadonlyLeft inpRONum4" runat="server"></asp:TextBox>
											<asp:TextBox ID="M1siiresaki_ryaku_nm" CssClass="inpReadonlyLeft inpRORightNm inpROZenkaku8 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col3 detail_left">
											<!--- 「ｍ１部門コード」テキストボックスリードオンリー --->
											<!--- 「ｍ１部門カナ名」テキストボックスリードオンリー --->
											<div>
												<asp:TextBox ID="M1bumon_cd" CssClass="inpReadonlyLeft inpRONum3" runat="server"></asp:TextBox>
												<asp:TextBox ID="M1bumonkana_nm" CssClass="inpReadonlyLeft inpRORightNm inpROHankaku12 tooltip" runat="server"></asp:TextBox>
											</div>
											<!--- 「ｍ１品種コード」テキストボックスリードオンリー --->
											<!--- 「ｍ１品種略名称」テキストボックスリードオンリー --->
											<div>
												<asp:TextBox ID="M1hinsyu_cd" CssClass="inpReadonlyLeft inpRONum2" runat="server"></asp:TextBox>
												<asp:TextBox ID="M1hinsyu_ryaku_nm" CssClass="inpReadonlyLeft inpRORightNm inpROZenkaku10 tooltip" runat="server"></asp:TextBox>
											</div>
										</div>
										<div class="col4 detail_left">
											<!--- 「ｍ１ブランド名」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1burando_nm" CssClass="inpReadonlyLeft inpROHankaku14 tooltip" runat="server"></asp:TextBox></div>
											<!--- 「Ｍ１自社品番リンク」ボタン --->
											<!--- 「Ｍ１旧自社品番リンク」ボタン --->
											<div>
												<input type="button" id="M1jisya_hbn" value="自社品番" onserverclick="OnM1JISYA_HBN_FRM" runat="server" class="meisaiLink"/><input type="button" id="M1old_jisya_hbn" value="" onserverclick="OnM1OLD_JISYA_HBN_FRM" runat="server" class="meisaiLink"/>
											</div>
										</div>
										<div class="col5 col_2dan detail_left">
											<!--- 「ｍ１商品属性」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1syohin_zokusei" CssClass="inpReadonlyLeft inpROHankaku3 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col6 detail_left">
											<!--- 「ｍ１メーカー品番」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1maker_hbn" CssClass="inpReadonlyLeft inpROHankaku30 tooltip" runat="server"></asp:TextBox></div>
											<!--- 「ｍ１商品名(カナ)」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1syonmk" CssClass="inpReadonlyLeft inpROHankaku20 tooltip" runat="server"></asp:TextBox></div>
										</div>
										<div class="col7 col_2dan detail_left">
											<!--- 「ｍ１色」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1iro_nm" CssClass="inpReadonlyLeft inpROHankaku6 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col8 col_2dan detail_center">
											<!--- 「ｍ１販売完了日」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1hanbaikanryo_ymd" CssClass="inpReadonlyCenter inpDt" runat="server"></asp:TextBox>
										</div>
										<div class="col9 detail_right">
											<!--- 「ｍ１最新売価」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1saisinbaika_tnk" CssClass="inpReadonlyRight inpRONumCma8" runat="server"></asp:TextBox></div>
											<!--- 「ｍ１原価」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1genka" CssClass="inpReadonlyRight inpRONumCma8" runat="server"></asp:TextBox></div>
										</div>
										<div class="col10 detail_right">
											<!--- 「ｍ１現売価」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1genbaika_tnk" CssClass="inpReadonlyRight inpRONumCma8" runat="server"></asp:TextBox></div>
											<!--- 「ｍ１メーカー価格」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1makerkakaku_tnk" CssClass="inpReadonlyRight inpRONumCma8" runat="server"></asp:TextBox></div>
										</div>
										
										<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
										<div style="display: none">
											<div class="col19">
												<!--- 「ｍ１選択フラグ(隠し)」チェックボックス --->
												<adv:AdvancedCheckBox ID="M1selectorcheckbox" Text="" CssClass="" runat="server"></adv:AdvancedCheckBox>
											</div>
											<div class="col20">
												<!--- 「Ｍ１確定処理フラグ(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1entersyoriflg" runat="server"></asp:hiddenfield>
											</div>
											<div class="col21">
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
			<asp:Label ID="Head_tenpo_cd_lbl" runat="server"></asp:Label>
			<asp:Label ID="Head_tenpo_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Siiresaki_ryaku_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Burando_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Genka_lbl" runat="server"></asp:Label>
			<asp:Label ID="Genbaika_tnk_lbl" runat="server"></asp:Label>
			<asp:Label ID="Makerkakaku_tnk_lbl" runat="server"></asp:Label>
			<asp:Label ID="M1siiresaki_ryaku_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="M1bumonkana_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="M1hinsyu_ryaku_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="M1old_jisya_hbn_lbl" runat="server"></asp:Label>
			<asp:Label ID="Searchcnt_lbl" runat="server"></asp:Label>
			
			<!--- 「選択モードNO」隠しフィールド --->
			<asp:hiddenfield ID="Stkmodeno" runat="server"></asp:hiddenfield>
			<asp:Label ID="Syohinmst_serchstk_lbl" runat="server">商品マスタ検索選択</asp:Label>
		</div>
	
	</form>
</body>
</html>

