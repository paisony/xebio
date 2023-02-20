<%@ Page language="c#" CodeFile="tg040f01.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Tg040p01.Page.Tg040f01Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">商品ｽﾄｯｸ明細書発行</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="tg040p01" FormId="tg040f01" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/tg040f01.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="tg040p01" FormId="tg040f01" runat="server" />

	<!-- Js業務部品のインポート --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05001.js" charset="UTF-8"></script><!-- 自社品番丸め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script><!-- 0埋め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05011.js" charset="UTF-8"></script><!-- FROM-TOコピー処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05014.js" charset="UTF-8"></script><!-- 名称取得拡張 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05015.js" charset="UTF-8"></script><!-- 項目制御処理 -->

	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02001.js" charset="UTF-8"></script><!-- 店舗検索 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02003.js" charset="UTF-8"></script><!-- 発注マスタ取得(自社品番) -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02005.js" charset="UTF-8"></script><!-- 担当者マスタ取得 -->

</head>

<body>
	<form id="Tg040f01" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="tg040p01" PgName="商品ｽﾄｯｸ明細書発行" FormId="tg040f01" FormName="商品ｽﾄｯｸ明細書発行 一覧" ></uc:Header>

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
							<!--- 「モード修正ボタン」リンク --->
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
									<table>
										<colgroup>
											<col class="w-type-01"/>
											<col class="w-type-02"/>
											<col class="w-type-01"/>
											<col class="w-type-03"/>
											<col class="w-type-04"/>
											<col />
										</colgroup>
										<tr>
											<th scope="col">
												<span class="tbl-hdg">
													<asp:Label ID="Ymd_from_lbl" runat="server">日付</asp:Label>
												</span>
											</th>
											<td>
												<!--- 「日付ｆｒｏｍ」一行テキストボックス（セパレート日付以外） --->
												<!--- 「日付ｔｏ」一行テキストボックス（セパレート日付以外） --->
												<span class="icon-in"><md:MDTextBox ID="Ymd_from" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span>
												<span class="label-fromto">～</span>
												<span class="icon-in"><md:MDTextBox ID="Ymd_to" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span>
											</td>
											<th scope="col">
												<span class="tbl-hdg">
													<asp:Label ID="Stock_no_lbl" runat="server">ストックNo</asp:Label>
												</span>
											</th>
											<td>
												<!--- 「ストック№」一行テキストボックス（セパレート日付以外） --->
												<md:MDTextBox ID="Stock_no" CssClass="inpStockNo" runat="server"></md:MDTextBox>
											</td>
											<th scope="col">
												<span class="tbl-hdg">
													<asp:Label ID="Tan_cd_lbl" runat="server">担当者</asp:Label>
												</span>
											</th>
											<td colspan="3">
												<!--- 「担当者コード」一行テキストボックス（セパレート日付以外） --->
												<!--- 「担当者コードボタン」ボタン --->
												<!--- 「担当者名」テキストボックスリードオンリー --->
												<span class="icon-in">
													<md:MDTextBox ID="Tan_cd" CssClass="inpSerch inpTanto" runat="server"></md:MDTextBox>
													<input type="button" id="Btntanto_cd" name="Btntanto_cd" value="" runat="server" class="icon-search"/>
												</span>
												<asp:TextBox ID="Hanbaiin_nm" CssClass="inpReadonlyLeft" runat="server"></asp:TextBox>
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
												<md:MDTextBox ID="Old_jisya_hbn" CssClass="inpJishahin10" runat="server"></md:MDTextBox>
												<!--- 「メーカー品番」テキストボックスリードオンリー --->
												<asp:TextBox ID="Maker_hbn" CssClass="inpReadonlyLeft inpMkhin" runat="server"></asp:TextBox>
											</td>
											<th scope="col">
												<span class="tbl-hdg">
													<asp:Label ID="Scan_cd_lbl" runat="server">ｽｷｬﾝｺｰﾄﾞ</asp:Label>
												</span>
											</th>
											<td>
												<!--- 「スキャンコード」一行テキストボックス（セパレート日付以外） --->
												<md:MDTextBox ID="Scan_cd" CssClass="inpScanHdg" runat="server"></md:MDTextBox>
											</td>
										</tr>
										<tr>
											<th scope="col">
												<span class="tbl-hdg">
													<asp:Label ID="Hanbaikanryo_ymd_from_lbl" runat="server">販売完了日</asp:Label>
												</span>
											</th>
											<td>
												<!--- 「販売完了日from」一行テキストボックス（セパレート日付以外） --->
												<!--- 「販売完了日to」一行テキストボックス（セパレート日付以外） --->
												<span class="icon-in"><md:MDTextBox ID="Hanbaikanryo_ymd_from" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span>
												<span class="label-fromto">～</span>
												<span class="icon-in"><md:MDTextBox ID="Hanbaikanryo_ymd_to" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span>
											</td>
										</tr>
									</table>
									<!-- /inner --></div>
								<!-- /str-form-02 --></div>
							</td>
							<td class="search-table-tdright">
								<div class="str-btn-search">
									<!--- 「新規作成ボタン」ボタン --->
									<input type="button" id="Btninsert" value="新規作成" onserverclick="OnBTNINSERT_FRM" runat="server" class="btn type-04"/>

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
						<li>
							<!--- 「印刷ボタン」ボタン --->
							<span><label><input type="button" id="Btnprint" value="" onserverclick="OnBTNPRINT_FRM" runat="server" class="icon-utility-04"/>印刷</label></span>
						</li>
						<li>
							<!--- 「CSVボタン」ボタン --->
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
							<div class="col1">
								<asp:Label ID="M1rowno_lbl" runat="server">No.</asp:Label>
							</div>
							<div class="col2">
								<asp:Label ID="M1ymd_lbl" runat="server">日付</asp:Label>
							</div>
							<div class="col3">
								<asp:Label ID="M1tm_lbl" runat="server">時間</asp:Label>
							</div>
							<div class="col4">
								<asp:Label ID="M1hanbaiin_nm_lbl" runat="server">担当者</asp:Label>
							</div>
							<div class="col5">
								<asp:Label ID="M1stock_no_lbl" runat="server">ストックNo</asp:Label>
							</div>
							<div class="col6">
								<asp:Label ID="M1suryo_lbl" runat="server">数量</asp:Label>
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
										<div class="col2 detail_center">
											<!--- 「Ｍ１日付リンク」ボタン --->
											<input type="button" id="M1ymd" value="日付" onserverclick="OnM1YMD_FRM" runat="server" class="meisaiLink"/>
										</div>
										<div class="col3 detail_center">
											<!--- 「ｍ１時間」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1tm" CssClass="inpReadonlyCenter inpROTime" runat="server"></asp:TextBox>
										</div>
										<div class="col4 detail_left">
											<!--- 「ｍ１担当者名」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1hanbaiin_nm" CssClass="inpReadonlyLeft inpROZenkaku10 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col5 detail_left">
											<!--- 「ｍ１ストック№」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1stock_no" CssClass="inpReadonlyLeft inpROHankaku10" runat="server"></asp:TextBox>
										</div>
										<div class="col6 detail_right">
											<!--- 「ｍ１数量」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1suryo" CssClass="inpReadonlyRight inpRONumCma6" runat="server"></asp:TextBox>
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
			<asp:Label ID="Head_tenpo_cd_lbl" runat="server">店舗</asp:Label>
			<asp:Label ID="Head_tenpo_cd_Req" runat="server" CssClass="required">*</asp:Label>
			<asp:Label ID="Head_tenpo_nm_lbl" runat="server"></asp:Label>

			<asp:Label ID="Ymd_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Hanbaiin_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Maker_hbn_lbl" runat="server"></asp:Label>
			<asp:Label ID="Hanbaikanryo_ymd_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Searchcnt_lbl" runat="server"></asp:Label>

			<!--- 「モードNO」隠しフィールド --->
			<asp:hiddenfield ID="Modeno" runat="server"></asp:hiddenfield>
			<!--- 「選択モードNO」隠しフィールド --->
			<asp:hiddenfield ID="Stkmodeno" runat="server"></asp:hiddenfield>

		</div>
	</form>
</body>
</html>

