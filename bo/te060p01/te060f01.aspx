<%@ Page language="c#" CodeFile="te060f01.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Te060p01.Page.Te060f01Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">再入荷防止検索</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="te060p01" FormId="te060f01" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/te060f01.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="te060p01" FormId="te060f01" runat="server" />

	<!-- Js業務部品のインポート --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02001.js" charset="UTF-8"></script><!-- 店舗検索 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02002.js" charset="UTF-8"></script><!-- 仕入先マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02008.js" charset="UTF-8"></script><!-- 商品群１マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02010.js" charset="UTF-8"></script><!-- 部門マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05003.js" charset="UTF-8"></script><!-- 明細背景色変更処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script><!-- 0埋め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05009.js" charset="UTF-8"></script><!-- 指示番号丸め処理(返品用) -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05011.js" charset="UTF-8"></script><!-- FROM-TOコピー処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
</head>

<body>
	<form id="Te060f01" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="te060p01" PgName="再入荷防止検索" FormId="te060f01" FormName="再入荷防止検索" ></uc:Header>
			
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
						<!--- 「モード照会ボタン」リンク --->
						<a id="Btnmoderef" href="#tab16" class="" runat="server">照会</a>
					</li>
					<li>
						<!--- 「モード訂正ボタン」リンク --->
						<a id="Btnmodeupd" href="#tab8" class="" runat="server">修正</a>
					</li>
					<li>
						<!--- 「モード取消ボタン」リンク --->
						<a id="Btnmodedel" href="#tab11" class="" runat="server">取消</a>
					</li>
				</ul>
			</div>

			<div id="tab16" class="str-tab-cont"></div>
			<div id="tab8" class="str-tab-cont"></div>
			<div id="tab11" class="str-tab-cont"></div>

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
					<table class="search-table">
						<tr>
							<td class="search-table-tdleft">
								<div class="str-form-02">
									<div class="inner">
										<!--<p class="required">*が付いている項目は必須入力になります。</p>-->
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
												<!--- 「商品群１」 --->
												<th>
													<span class="tbl-hdg"><asp:Label ID="Syohingun1_cd_lbl" runat="server">商品群１</asp:Label></span>
												</th>
												<!--- 「商品群１コード」一行テキストボックス（セパレート日付以外） --->
												<!--- 「商品群１コードボタン」ボタン --->
												<!--- 「商品群１略式名称」テキストボックスリードオンリー --->
												<td>
													<span class="icon-in">
														<md:MDTextBox ID="Syohingun1_cd" CssClass="inpSerch inpShohingun" runat="server"></md:MDTextBox>
														<input type="button" id="Btnsyohingun1_cd" name="Btnsyohingun1_cd" value="" runat="server" class="icon-search"/>
													</span>
													<asp:TextBox ID="Syohingun1_ryaku_nm" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
												</td>
												<!--- 「仕入先」 --->
												<th>
													<span class="tbl-hdg"><asp:Label ID="Siiresaki_cd_lbl" runat="server">仕入先</asp:Label></span>
												</th>
												<!--- 「仕入先コード」一行テキストボックス（セパレート日付以外） --->
												<!--- 「ボタン仕入先コード」ボタン --->
												<!--- 「仕入先略式名称」テキストボックスリードオンリー --->
												<td>
													<span class="icon-in">
														<md:MDTextBox ID="Siiresaki_cd" CssClass="inpSerch inpShiire" runat="server"></md:MDTextBox>
														<input type="button" id="Btnsiiresaki_cd" name="Btnsiiresaki_cd" value="" runat="server" class="icon-search"/>
													</span>
													<asp:TextBox ID="Siiresaki_ryaku_nm" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
												</td>
												<!--- 「部門」 --->
												<th>
													<span class="tbl-hdg"><asp:Label ID="Bumon_cd_lbl" runat="server">部門</asp:Label></span>
												</th>
												<!--- 「部門コード」一行テキストボックス（セパレート日付以外） --->
												<!--- 「部門コードボタン」ボタン --->
												<!--- 「部門名」テキストボックスリードオンリー --->
												<td class="last">
													<span class="icon-in">
														<md:MDTextBox ID="Bumon_cd" CssClass="inpSerch inpBumon" runat="server"></md:MDTextBox>
														<input type="button" id="Btnbumon_cd" name="Btnbumon_cd" value="" runat="server" class="icon-search"/>
													</span>
													<asp:TextBox ID="Bumon_nm" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<!--- 「削除区分」 --->
												<th>
													<span class="tbl-hdg"><asp:Label ID="Sakujo_kbn_lbl" runat="server">削除区分</asp:Label></span>
												</th>
												<!--- 「削除区分」ドロップダウンリスト --->
												<td>
													<md:MDConditionDDList ID="Sakujo_kbn" ConditionName="sakujo_kbn" CssClass="slt-ddl slt-skjkbn" runat="server"></md:MDConditionDDList>
													<span class="select-arrow"></span>
												</td>
												<!--- 「販売完了日」 --->
												<th>
													<span class="tbl-hdg"><asp:Label ID="Hanbaikanryo_ymd_lbl" runat="server">販売完了日</asp:Label></span>
												</th>
												<!--- 「販売完了日」一行テキストボックス（セパレート日付以外） --->
												<td>
													<span class="icon-in">
														<md:MDTextBox ID="Hanbaikanryo_ymd" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox>
													</span>
													<span class="label-from">～</span>
												</td>
												<!--- 「登録日」 --->
												<th>
													<span class="tbl-hdg"><asp:Label ID="Add_ymd_from_lbl" runat="server">登録日</asp:Label></span>
												</th>
												<!--- 「登録日ｆｒｏｍ」一行テキストボックス（セパレート日付以外） --->
												<!--- 「登録日ｔｏ」一行テキストボックス（セパレート日付以外） --->
												<td colspan="3">
													<span class="icon-in">
													<md:MDTextBox ID="Add_ymd_from" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox>
													</span>
													<span class="label-fromto">～</span>
													<span class="icon-in">
													<md:MDTextBox ID="Add_ymd_to" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox>
													</span>
												</td>
											</tr>
											<tr>
												<td class="last" colspan="5"></td>
												<td class="last">
													<!--- 「ソート順」ラジオボタン --->
													<span class="tbl-hdg label-none" style="display:none">&nbsp;</span>
													<adv:ConditionRBList ID="Sort_jun" ConditionName="sainyukabosi_jun" RepeatDirection="Horizontal" CssClass="sainyukabosi_jun" runat="server"></adv:ConditionRBList>
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
				<!-- button -->
				<div id="str-btn-area" class="str-btn-utility">
					<div id="meisaiBtnArea" class="inner pad0" runat="server">
					<ul>
						<!--明細制御系ボタンを配置する場合はこのulタグの中-->
						<!--- 「全選択ボタン」ボタン --->
						<li><span><label><input type="button" id="Btnzenstk" value="" onserverclick="OnBTNZENSTK_FRM" runat="server" class="icon-utility-01"/>全選択</label></span></li>
						<!--- 「全解除ボタン」ボタン --->
						<li><span><label><input type="button" id="Btnzenkjo" value="" onserverclick="OnBTNZENKJO_FRM" runat="server" class="icon-utility-02"/>全解除</label></span></li>
						<!--- 「防止期限」一行テキストボックス（セパレート日付以外） --->
						<li><div class="str-boushi"><span>防止期限</span></div></li>
						<li><md:MDTextBox ID="Stop_ymd" CssClass="inpSerch datepicker inpBoushiKigen" runat="server"></md:MDTextBox></li>
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
								<asp:Label ID="M1jisya_hbn1_lbl" runat="server">自社品番</asp:Label>
							</div>
							<div class="col5">
								<div><asp:Label ID="M1maker_hbn_lbl" runat="server">メーカー品番</asp:Label></div>
								<div><asp:Label ID="M1syonmk_lbl" runat="server">商品名</asp:Label></div>
							</div>
							<div class="col6 col_2dan">
								<asp:Label ID="M1iro_nm_lbl" runat="server">色</asp:Label>
							</div>
							<div class="col7 col_2dan">
								<asp:Label ID="M1stop_ymd_lbl" runat="server">防止期限</asp:Label>
							</div>
							<div class="col8 col_2dan">
								<asp:Label ID="M1add_ymd_lbl" runat="server">登録日付</asp:Label>
							</div>
							<div class="col9 col_2dan">
								<asp:Label ID="M1honbutenpokbnnm_lbl" runat="server">登録区分</asp:Label>
							</div>
							<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
							<div style="display:none">
								<asp:Label ID="M1bumonkana_nm_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1selectorcheckbox_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1entersyoriflg_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1dtlirokbn_lbl" runat="server"></asp:Label>
							</div>

						<!-- /str-result-hdg-01 --></div>
						<div id="str-result-item-wrap" class="adjust-elem">
							<asp:Repeater ID="M1" runat="server">
								<HeaderTemplate>
								</HeaderTemplate>
								<ItemTemplate>
									<div id="M1Row" class="str-result-item-01" runat="server">
										<div class="col1 col_2dan detail_right">
											<!--- 「ｍ１行no」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1rowno" CssClass="inpReadonlyRight inpRONum3" runat="server"></asp:TextBox>
										</div>
										<div class="col2 detail_left">
											<!--- 「ｍ１部門コード」テキストボックスリードオンリー --->
											<!--- 「ｍ１部門カナ名」テキストボックスリードオンリー --->
											<div>
												<asp:TextBox ID="M1bumon_cd" CssClass="inpReadonlyLeft inpRONum3" runat="server"></asp:TextBox>
												<asp:TextBox ID="M1bumonkana_nm" CssClass="inpReadonlyLeft inpRORightNm inpROHankaku12 tooltip" runat="server"></asp:TextBox>
											</div>
											<div>
												<!--- 「ｍ１品種略名称」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1hinsyu_ryaku_nm" CssClass="inpReadonlyLeft inpROZenkaku10 tooltip" runat="server"></asp:TextBox>
											</div>
										</div>
										<div class="col3 col_2dan detail_left">
											<!--- 「ｍ１ブランド名」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1burando_nm" CssClass="inpReadonlyLeft inpROHankaku20 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col4 col_2dan detail_center">
											<!--- 「ｍ１自社品番」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1jisya_hbn1" CssClass="inpReadonlyCenter inpRONum8" runat="server"></asp:TextBox>
										</div>
										<div class="col5 detail_left">
											<!--- 「ｍ１メーカー品番」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1maker_hbn" CssClass="inpReadonlyLeft inpROHankaku30 tooltip" runat="server"></asp:TextBox></div>
											<!--- 「ｍ１商品名(カナ)」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1syonmk" CssClass="inpReadonlyLeft inpROHankaku20 tooltip" runat="server"></asp:TextBox></div>
										</div>
										<div class="col6 col_2dan detail_left">
											<!--- 「ｍ１色」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1iro_nm" CssClass="inpReadonlyLeft inpROHankaku6 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col7 col_2dan detail_center">
											<!--- 「ｍ１防止期限」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1stop_ymd" CssClass="inpReadonlyCenter inpRODate" runat="server"></asp:TextBox>
										</div>
										<div class="col8 col_2dan detail_center">
											<!--- 「ｍ１登録日」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1add_ymd" CssClass="inpReadonlyCenter inpRODate" runat="server"></asp:TextBox>
										</div>
										<div class="col9 col_2dan detail_left">
											<!--- 「ｍ１本部店舗区分名称」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1honbutenpokbnnm" CssClass="inpReadonlyLeft inpROZenkaku2 tooltip" runat="server"></asp:TextBox>
										</div>
										<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
										<div style="display:none">
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
			<asp:Label ID="Syohingun1_ryaku_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Siiresaki_ryaku_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Bumon_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Add_ymd_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Sort_jun_lbl" runat="server"></asp:Label>
			<asp:Label ID="Searchcnt_lbl" runat="server"></asp:Label>
			<asp:Label ID="Stop_ymd_lbl" runat="server"></asp:Label>
			<asp:Label ID="Label1" runat="server"></asp:Label>
			<!--- 「モードNO」隠しフィールド --->
			<asp:hiddenfield ID="Modeno" runat="server"></asp:hiddenfield>
			<!--- 「選択モードNO」隠しフィールド --->
			<asp:hiddenfield ID="Stkmodeno" runat="server"></asp:hiddenfield>
		</div>
	
	</form>
</body>
</html>

