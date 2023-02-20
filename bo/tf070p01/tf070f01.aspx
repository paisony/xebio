<%@ Page language="c#" CodeFile="tf070f01.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Tf070p01.Page.Tf070f01Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">盗難品登録</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="tf070p01" FormId="tf070f01" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/tf070f01.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="tf070p01" FormId="tf070f01" runat="server" />

	<!-- 共通部品のインポート -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->

	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script><!-- 0埋め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05011.js" charset="UTF-8"></script><!-- FROM-TOコピー処理 -->

	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02001.js" charset="UTF-8"></script><!-- 店舗検索 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02005.js" charset="UTF-8"></script><!-- 担当者マスタ取得 -->

</head>

<body>
	<form id="Tf070f01" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="tf070p01" PgName="盗難品登録" FormId="tf070f01" FormName="盗難品登録 一覧" ></uc:Header>

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
			<div class="str-tab-menu clearfix">
				<ul class="tab-list">
					<li>
						<!--- 「モード経費申請ボタン」リンク --->
						<a id="Btnmodekeihisinsei" href="#tab24" class="" runat="server">経費申請</a>
					</li>
					<li>
						<!--- 「モード申請済取消ボタン」リンク --->
						<a id="Btnmodesinseitorikesi" href="#tab14" class="" runat="server">申請済取消</a>
					</li>
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
				</ul>
			</div>
			<div id="tab24" class="str-tab-cont"></div>
			<div id="tab14" class="str-tab-cont"></div>
			<div id="tab8" class="str-tab-cont"></div>
			<div id="tab11" class="str-tab-cont"></div>
			<div id="tab16" class="str-tab-cont"></div>

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
					<!-- <p class="required">*が付いている項目は必須入力になります。</p> -->
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
											<tbody>
												<tr>
													<th>
														<span class="tbl-hdg"><asp:Label ID="Tonanhinkanri_no_from_lbl" runat="server">管理番号ＦＲＯＭ</asp:Label></span>
													</th>
													<td>
														<!--- 「盗難品管理番号ｆｒｏｍ」一行テキストボックス（セパレート日付以外） --->
														<md:MDTextBox ID="Tonanhinkanri_no_from" CssClass="inpKanriNo" runat="server"></md:MDTextBox>
														<span class="label-fromto">～</span>
														<!--- 「盗難品管理番号ｔｏ」一行テキストボックス（セパレート日付以外） --->
														<md:MDTextBox ID="Tonanhinkanri_no_to" CssClass="inpKanriNo" runat="server"></md:MDTextBox>
													</td>
													<th>
														<span class="tbl-hdg"><asp:Label ID="Jikohassei_ymd_from_lbl" runat="server">事故発生日ＦＲＯＭ</asp:Label></span>
													</th>
													<td>
														<!--- 「事故発生日ｆｒｏｍ」一行テキストボックス（セパレート日付以外） --->
														<span class="icon-in"><md:MDTextBox ID="Jikohassei_ymd_from" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span>
														<span class="label-fromto">～</span>
														<!--- 「事故発生日ｔｏ」一行テキストボックス（セパレート日付以外） --->
														<span class="icon-in"><md:MDTextBox ID="Jikohassei_ymd_to" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span>
													</td>
												</tr>
												<tr>
													<th>
														<span class="tbl-hdg"><asp:Label ID="Hokoku_ymd_from_lbl" runat="server">報告日ＦＲＯＭ</asp:Label></span>
													</th>
													<td>
														<!--- 「報告日ｆｒｏｍ」一行テキストボックス（セパレート日付以外） --->
														<span class="icon-in"><md:MDTextBox ID="Hokoku_ymd_from" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span>
														<span class="label-fromto">～</span>
														<!--- 「報告日ｔｏ」一行テキストボックス（セパレート日付以外） --->
														<span class="icon-in"><md:MDTextBox ID="Hokoku_ymd_to" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span>
													</td>
													<th>
														<span class="tbl-hdg"><asp:Label ID="Hokokutan_cd_lbl" runat="server">報告者</asp:Label></span>
													</th>
													<td>
														<span class="icon-in">
															<!--- 「報告担当者コード」一行テキストボックス（セパレート日付以外） --->
															<md:MDTextBox ID="Hokokutan_cd" CssClass="inpSerch inpTanto" runat="server"></md:MDTextBox>
															<!--- 「担当者コードボタン」ボタン --->
															<input type="button" id="Btntanto_cd" name="Btntanto_cd" value="" runat="server" class="icon-search"/>
														</span>
														<!--- 「報告担当者名称」テキストボックスリードオンリー --->
														<asp:TextBox ID="Hokokutan_nm" CssClass="inpReadonlyLeft inpROZenkaku10 inpRORightNm" runat="server"></asp:TextBox>
													</td>
												</tr>
												<tr>
													<th class="last">
														<span class="tbl-hdg"><asp:Label ID="Keisatsutodoke_ymd_from_lbl" runat="server">警察届出日ＦＲＯＭ</asp:Label></span>
													</th>
													<td class="last">
														<!--- 「警察届出日ｆｒｏｍ」一行テキストボックス（セパレート日付以外） --->
														<span class="icon-in"><md:MDTextBox ID="Keisatsutodoke_ymd_from" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span>
														<span class="label-fromto">～</span>
														<!--- 「警察届出日ｔｏ」一行テキストボックス（セパレート日付以外） --->
														<span class="icon-in"><md:MDTextBox ID="Keisatsutodoke_ymd_to" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span>
													</td>
													<th class="last">
														<span class="tbl-hdg"><asp:Label ID="Jyuri_no_from_lbl" runat="server">受理番号ＦＲＯＭ</asp:Label></span>
													</th>
													<td class="last">
														<!--- 「受理番号ｆｒｏｍ」一行テキストボックス（セパレート日付以外） --->
														<md:MDTextBox ID="Jyuri_no_from" CssClass="inpJuriNo" runat="server"></md:MDTextBox>
														<span class="label-fromto">～</span>
														<!--- 「受理番号ｔｏ」一行テキストボックス（セパレート日付以外） --->
														<md:MDTextBox ID="Jyuri_no_to" CssClass="inpJuriNo" runat="server"></md:MDTextBox>
													</td>
												</tr>
											</tbody>
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
							<!--- 「印刷ボタン」ボタン --->
							<span><label><input type="button" id="Btnprint" value="" onserverclick="OnBTNPRINT_FRM" runat="server" class="icon-utility-04"/>印刷</label></span>
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
							<div class="col1"><asp:Label ID="M1rowno_lbl" runat="server">No.</asp:Label></div>
							<div class="col2"><asp:Label ID="M1tonanhinkanri_no_lbl" runat="server">管理番号</asp:Label></div>
							<div class="col3"><asp:Label ID="M1jikohassei_ymd_lbl" runat="server">事故発生日</asp:Label></div>
							<div class="col4"><asp:Label ID="M1hokoku_ymd_lbl" runat="server">報告日</asp:Label></div>
							<div class="col5"><asp:Label ID="M1hokokutan_nm_lbl" runat="server">報告者名</asp:Label></div>
							<div class="col6"><asp:Label ID="M1tentyotan_nm_lbl" runat="server">店長名</asp:Label></div>
							<div class="col7"><asp:Label ID="M1keisatsutodoke_ymd_lbl" runat="server">警察届出日</asp:Label></div>
							<div class="col8"><asp:Label ID="M1todokedesakikeisatsu_nm_lbl" runat="server">届出警察署</asp:Label></div>
							<div class="col9"><asp:Label ID="M1jyuri_no_lbl" runat="server">受理番号</asp:Label></div>

							<%-- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --%>
							<div style="display:none;">
								<div class="col10"><asp:Label ID="M1selectorcheckbox_lbl" runat="server"></asp:Label></div>
								<div class="col11"><asp:Label ID="M1entersyoriflg_lbl" runat="server"></asp:Label></div>
								<div class="col12"><asp:Label ID="M1dtlirokbn_lbl" runat="server"></asp:Label></div>
							</div>
							<%-- 隠し項目エリア↑↑↑↑↑↑↑↑↑↑↑↑↑ --%>
						<!-- /str-result-hdg-01 --></div>
						<div id="str-result-item-wrap" class="adjust-elem">
							<asp:Repeater ID="M1" runat="server">
								<HeaderTemplate>
								</HeaderTemplate>
								<ItemTemplate>
									<!--<div class="str-result-item-01">-->
									<div id="M1Row" class="str-result-item-01" runat="server">
										<div class="col1 detail_right">
											<!--- 「ｍ１ｎｏ」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1rowno" CssClass="inpReadonlyRight inpRONum3" runat="server"></asp:TextBox>
										</div>
										<div class="col2 detail_center">
											<!--- 「Ｍ１管理番号リンク」ボタン --->
											<input type="button" id="M1tonanhinkanri_no" value="管理番号" onserverclick="OnM1TONANHINKANRI_NO_FRM" runat="server" class="meisaiLink"/>
										</div>
										<div class="col3 detail_center">
											<!--- 「ｍ１事故発生日」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1jikohassei_ymd" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox>
										</div>
										<div class="col4 detail_center">
											<!--- 「ｍ１報告日」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1hokoku_ymd" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox>
										</div>
										<div class="col5 detail_left">
											<!--- 「ｍ１報告担当者名称」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1hokokutan_nm" CssClass="inpReadonlyLeft inpROZenkaku10 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col6 detail_left">
											<!--- 「ｍ１店長担当者名称」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1tentyotan_nm" CssClass="inpReadonlyLeft inpROZenkaku10 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col7 detail_center">
											<!--- 「ｍ１警察届出日」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1keisatsutodoke_ymd" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox>
										</div>
										<div class="col8 detail_left">
											<!--- 「ｍ１届出先警察署名」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1todokedesakikeisatsu_nm" CssClass="inpReadonlyLeft inpROZenkaku20 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col9 detail_left">
											<!--- 「ｍ１受理番号」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1jyuri_no" CssClass="inpReadonlyLeft inpROHankaku10" runat="server"></asp:TextBox>
										</div>

										<%-- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --%>
										<div style="display:none;">
											<div class="col10">
												<!--- 「ｍ１選択フラグ(隠し)」チェックボックス --->
												<adv:AdvancedCheckBox ID="M1selectorcheckbox" Text="" CssClass="" runat="server"></adv:AdvancedCheckBox>
											</div>
											<div class="col11">
												<!--- 「Ｍ１確定処理フラグ(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1entersyoriflg" runat="server"></asp:hiddenfield>
											</div>
											<div class="col12">
												<!--- 「Ｍ１明細色区分(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1dtlirokbn" runat="server"></asp:hiddenfield>
											</div>
										</div>
										<%-- 隠し項目エリア↑↑↑↑↑↑↑↑↑↑↑↑↑ --%>
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
			<%-- ヘッダ部項目 --%>
			<asp:Label ID="Head_tenpo_cd_lbl" runat="server">店舗</asp:Label>
			<asp:Label ID="Head_tenpo_cd_Req" runat="server" CssClass="required">*</asp:Label>
			<asp:Label ID="Head_tenpo_nm_lbl" runat="server"></asp:Label>

			<%-- カード部項目 --%>
			<!--- 「モードNO」隠しフィールド --->
			<asp:HiddenField ID="Modeno" runat="server"></asp:HiddenField>
			<!--- 「選択モードNO」隠しフィールド --->
			<asp:HiddenField ID="Stkmodeno" runat="server"></asp:HiddenField>

			<asp:Label ID="Tonanhinkanri_no_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Jikohassei_ymd_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Hokoku_ymd_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Hokokutan_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Keisatsutodoke_ymd_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Jyuri_no_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Searchcnt_lbl" runat="server"></asp:Label>
		</div>
	</form>
</body>
</html>

