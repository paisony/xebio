<%@ Page language="c#" CodeFile="tj110f01.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Tj110p01.Page.Tj110f01Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">棚卸取漏れ欠番検索</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="tj110p01" FormId="tj110f01" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/tj110f01.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="tj110p01" FormId="tj110f01" runat="server" />
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
	<form id="Tj110f01" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="tj110p01" PgName="棚卸取漏れ欠番検索(X)" FormId="tj110f01" FormName="棚卸取漏れ欠番検索" ></uc:Header>
			
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
											<col />
											</colgroup>
											<tbody>
												<tr>
													<th><span class="tbl-hdg"><asp:Label ID="Torimore_ketsuban_lbl" runat="server">取漏れ／欠番</asp:Label></span></th>
													<td >
														<!--- 「取漏れ／欠番」ドロップダウンリスト --->
														<md:MDConditionDDList ID="Torimore_ketsuban" ConditionName="torimore_ketsuban_kbn" CssClass="slt-torimore" runat="server"></md:MDConditionDDList>
														<span class="select-arrow"></span>
													</td>
													<th>
														<span class="tbl-hdg"><asp:Label ID="Face_no_from_lbl" runat="server">フェイスNo</asp:Label><span Class="required">*</span></span>
													</th>
													<!--- 「フェイス№from」一行テキストボックス（セパレート日付以外） ---><!--- 「フェイス№to」一行テキストボックス（セパレート日付以外） --->
													<td><md:MDTextBox ID="Face_no_from" CssClass="inpFaceNo" runat="server"></md:MDTextBox><span class="label-fromto">～</span><md:MDTextBox ID="Face_no_to" CssClass="inpFaceNo" runat="server"></md:MDTextBox></td>
												</tr>
											</tbody>
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
				<!------------------------------------------
					□明細ボタン部
				-------------------------------------------->
				<!-- button -->
				<div id="str-btn-area" class="str-btn-utility">
					<div id="meisaiBtnArea" class="inner pad0" runat="server">
					<ul>
						<!--明細制御系ボタンを配置する場合はこのulタグの中-->
						<!--- 「全選択ボタン」ボタン --->
						<li><span><label><input type="button" id="Btnzenstk" value="" onserverclick="OnBTNZENSTK_FRM" runat="server" class="icon-utility-01"/>全選択</label></span></li>
						<!--- 「全解除ボタン」ボタン --->
						<li><span><label><input type="button" id="Btnzenkjo" value="" onserverclick="OnBTNZENKJO_FRM" runat="server" class="icon-utility-02"/>全解除</label></span></li>
					</ul>
					<ul>
						<!--帳票／CSV系ボタンを配置する場合はこのulタグの中-->
						<!--- 「印刷ボタン」ボタン --->
						<li><span><label><input type="button" id="Btnprint" value="" onserverclick="OnBTNPRINT_FRM" runat="server" class="icon-utility-04"/>印刷</label></span></li>
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

					<!------------------------------------------
					  □一覧領域
					-------------------------------------------->
					<div class="str-result-01">
						<!------------------------------------------
						  □一覧ヘッダ領域
						-------------------------------------------->
						<div class="str-result-hdg-01">
							<div class="col1"><asp:Label ID="M1rowno_lbl" runat="server">No.</asp:Label></div>
							<div class="col2"><asp:Label ID="M1face_no_lbl" runat="server">フェイスNo</asp:Label></div>
							<div class="col3"><asp:Label ID="M1tana_dan_lbl" runat="server">棚段</asp:Label></div>
							<div class="col1"><asp:Label ID="M1rowno2_lbl" runat="server">No.</asp:Label></div>
							<div class="col2"><asp:Label ID="M1face_no2_lbl" runat="server">フェイスNo</asp:Label></div>
							<div class="col3"><asp:Label ID="M1tana_dan2_lbl" runat="server">棚段</asp:Label></div>
							<div class="col1"><asp:Label ID="M1rowno3_lbl" runat="server">No.</asp:Label></div>
							<div class="col2"><asp:Label ID="M1face_no3_lbl" runat="server">フェイスNo</asp:Label></div>
							<div class="col3"><asp:Label ID="M1tana_dan3_lbl" runat="server">棚段</asp:Label></div>
							<div class="col1"><asp:Label ID="M1rowno4_lbl" runat="server">No.</asp:Label></div>
							<div class="col2"><asp:Label ID="M1face_no4_lbl" runat="server">フェイスNo</asp:Label></div>
							<div class="col3"><asp:Label ID="M1tana_dan4_lbl" runat="server">棚段</asp:Label></div>
							<div class="col1"><asp:Label ID="M1rowno5_lbl" runat="server">No.</asp:Label></div>
							<div class="col2"><asp:Label ID="M1face_no5_lbl" runat="server">フェイスNo</asp:Label></div>
							<div class="col3"><asp:Label ID="M1tana_dan5_lbl" runat="server">棚段</asp:Label></div>
							<div class="col1"><asp:Label ID="M1rowno6_lbl" runat="server">No.</asp:Label></div>
							<div class="col2"><asp:Label ID="M1face_no6_lbl" runat="server">フェイスNo</asp:Label></div>
							<div class="col3"><asp:Label ID="M1tana_dan6_lbl" runat="server">棚段</asp:Label></div>
							<div class="col1"><asp:Label ID="M1rowno7_lbl" runat="server">No.</asp:Label></div>
							<div class="col2"><asp:Label ID="M1face_no7_lbl" runat="server">フェイスNo</asp:Label></div>
							<div class="col3"><asp:Label ID="M1tana_dan7_lbl" runat="server">棚段</asp:Label></div>

							<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
							<div style="display:none">
								<asp:Label ID="M1selectorcheckbox_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1entersyoriflg_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1dtlirokbn_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1selectorcheckbox2_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1entersyoriflg2_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1dtlirokbn2_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1selectorcheckbox3_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1entersyoriflg3_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1dtlirokbn3_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1selectorcheckbox4_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1entersyoriflg4_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1dtlirokbn4_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1selectorcheckbox5_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1entersyoriflg5_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1dtlirokbn5_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1selectorcheckbox6_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1entersyoriflg6_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1dtlirokbn6_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1selectorcheckbox7_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1entersyoriflg7_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1dtlirokbn7_lbl" runat="server"></asp:Label>
							</div>
							<!--- 隠し項目エリア↑↑↑↑↑↑↑↑↑↑↑↑↑ --->

						<!-- /str-result-hdg-01 --></div>
						<div id="str-result-item-wrap" class="adjust-elem">
							<asp:Repeater ID="M1" runat="server">
								<HeaderTemplate>
								</HeaderTemplate>
								<ItemTemplate>
									<div class="str-result-item-01 str-result-item-01_ketsuban" style="float:left;width:auto;">
										<div class="col1 detail_right detail_color1">
											<!--- 「ｍ１行no」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1rowno" CssClass="inpReadonlyRight inpRONum4" runat="server"></asp:TextBox>
										</div>
										<div class="col2 detail_center">
											<!--- 「ｍ１フェイス№」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1face_no" CssClass="inpReadonlyRight inpRONum5" runat="server"></asp:TextBox>
										</div>
										<div class="col3 detail_right">
											<!--- 「ｍ１棚段」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1tana_dan" CssClass="inpReadonlyRight inpRONum2" runat="server"></asp:TextBox>
										</div>
                                        <div style="display:none">
											<div class="col4">
												<!--- 「ｍ１選択フラグ(隠し)」チェックボックス --->
												<adv:AdvancedCheckBox ID="M1selectorcheckbox" Text="" CssClass="" runat="server"></adv:AdvancedCheckBox>
											</div>
											<div class="col5">
												<!--- 「Ｍ１確定処理フラグ(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1entersyoriflg" runat="server"></asp:hiddenfield>
											</div>
											<div class="col6">
												<!--- 「Ｍ１明細色区分(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1dtlirokbn" runat="server"></asp:hiddenfield>
											</div>
                                        </div>
                                    </div>
                                    <div class="str-result-item-01 str-result-item-01_ketsuban" style="float:left;width:auto;">
										<div class="col1 detail_right detail_color1">
											<!--- 「ｍ１行no２」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1rowno2" CssClass="inpReadonlyRight inpRONum4" runat="server"></asp:TextBox>
										</div>
										<div class="col2 detail_center">
											<!--- 「ｍ１フェイス№２」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1face_no2" CssClass="inpReadonlyRight inpRONum5" runat="server"></asp:TextBox>
										</div>
										<div class="col3 detail_right">
											<!--- 「ｍ１棚段２」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1tana_dan2" CssClass="inpReadonlyRight inpRONum2" runat="server"></asp:TextBox>
										</div>
                                        <div style="display:none;">
											<div class="col10">
												<!--- 「ｍ１選択フラグ(隠し)２」チェックボックス --->
												<adv:AdvancedCheckBox ID="M1selectorcheckbox2" Text="" CssClass="" runat="server"></adv:AdvancedCheckBox>
											</div>
											<div class="col11">
												<!--- 「Ｍ１確定処理フラグ(隠し)２」隠しフィールド --->
												<asp:hiddenfield ID="M1entersyoriflg2" runat="server"></asp:hiddenfield>
											</div>
											<div class="col12">
												<!--- 「Ｍ１明細色区分(隠し)２」隠しフィールド --->
												<asp:hiddenfield ID="M1dtlirokbn2" runat="server"></asp:hiddenfield>
											</div>
                                        </div>
                                    </div>
                                    <div class="str-result-item-01 str-result-item-01_ketsuban" style="float:left;width:auto;">
										<div class="col1 detail_right detail_color1">
											<!--- 「ｍ１行no３」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1rowno3" CssClass="inpReadonlyRight inpRONum4" runat="server"></asp:TextBox>
										</div>
										<div class="col2 detail_center">
											<!--- 「ｍ１フェイス№３」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1face_no3" CssClass="inpReadonlyRight inpRONum5" runat="server"></asp:TextBox>
										</div>
										<div class="col3 detail_right">
											<!--- 「ｍ１棚段３」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1tana_dan3" CssClass="inpReadonlyRight inpRONum2" runat="server"></asp:TextBox>
										</div>
                                        <div style="display:none;">
											<div class="col16">
												<!--- 「ｍ１選択フラグ(隠し)３」チェックボックス --->
												<adv:AdvancedCheckBox ID="M1selectorcheckbox3" Text="" CssClass="" runat="server"></adv:AdvancedCheckBox>
											</div>
											<div class="col17">
												<!--- 「Ｍ１確定処理フラグ(隠し)３」隠しフィールド --->
												<asp:hiddenfield ID="M1entersyoriflg3" runat="server"></asp:hiddenfield>
											</div>
											<div class="col18">
												<!--- 「Ｍ１明細色区分(隠し)３」隠しフィールド --->
												<asp:hiddenfield ID="M1dtlirokbn3" runat="server"></asp:hiddenfield>
											</div>
                                        </div>
                                    </div>
                                    <div class="str-result-item-01 str-result-item-01_ketsuban" style="float:left;width:auto;">
										<div class="col1 detail_right detail_color1">
											<!--- 「ｍ１行no４」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1rowno4" CssClass="inpReadonlyRight inpRONum4" runat="server"></asp:TextBox>
										</div>
										<div class="col2 detail_center">
											<!--- 「ｍ１フェイス№４」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1face_no4" CssClass="inpReadonlyRight inpRONum5" runat="server"></asp:TextBox>
										</div>
										<div class="col3 detail_right">
											<!--- 「ｍ１棚段４」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1tana_dan4" CssClass="inpReadonlyRight inpRONum2" runat="server"></asp:TextBox>
										</div>
                                        <div style="display:none;">
											<div class="col22">
												<!--- 「ｍ１選択フラグ(隠し)４」チェックボックス --->
												<adv:AdvancedCheckBox ID="M1selectorcheckbox4" Text="" CssClass="" runat="server"></adv:AdvancedCheckBox>
											</div>
											<div class="col23">
												<!--- 「Ｍ１確定処理フラグ(隠し)４」隠しフィールド --->
												<asp:hiddenfield ID="M1entersyoriflg4" runat="server"></asp:hiddenfield>
											</div>
											<div class="col24">
												<!--- 「Ｍ１明細色区分(隠し)４」隠しフィールド --->
												<asp:hiddenfield ID="M1dtlirokbn4" runat="server"></asp:hiddenfield>
											</div>
                                        </div>
                                    </div>
                                    <div class="str-result-item-01 str-result-item-01_ketsuban" style="float:left;width:auto;">
										<div class="col1 detail_right detail_color1">
											<!--- 「ｍ１行no５」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1rowno5" CssClass="inpReadonlyRight inpRONum4" runat="server"></asp:TextBox>
										</div>
										<div class="col2 detail_center">
											<!--- 「ｍ１フェイス№５」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1face_no5" CssClass="inpReadonlyRight inpRONum5" runat="server"></asp:TextBox>
										</div>
										<div class="col3 detail_right">
											<!--- 「ｍ１棚段５」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1tana_dan5" CssClass="inpReadonlyRight inpRONum2" runat="server"></asp:TextBox>
										</div>
                                        <div style="display:none;">
											<div class="col28">
												<!--- 「ｍ１選択フラグ(隠し)５」チェックボックス --->
												<adv:AdvancedCheckBox ID="M1selectorcheckbox5" Text="" CssClass="" runat="server"></adv:AdvancedCheckBox>
											</div>
											<div class="col29">
												<!--- 「Ｍ１確定処理フラグ(隠し)５」隠しフィールド --->
												<asp:hiddenfield ID="M1entersyoriflg5" runat="server"></asp:hiddenfield>
											</div>
											<div class="col30">
												<!--- 「Ｍ１明細色区分(隠し)５」隠しフィールド --->
												<asp:hiddenfield ID="M1dtlirokbn5" runat="server"></asp:hiddenfield>
											</div>
                                        </div>
                                    </div>
                                    <div class="str-result-item-01 str-result-item-01_ketsuban" style="float:left;width:auto;">
										<div class="col1 detail_right detail_color1">
											<!--- 「ｍ１行no６」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1rowno6" CssClass="inpReadonlyRight inpRONum4" runat="server"></asp:TextBox>
										</div>
										<div class="col2 detail_center">
											<!--- 「ｍ１フェイス№６」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1face_no6" CssClass="inpReadonlyRight inpRONum5" runat="server"></asp:TextBox>
										</div>
										<div class="col3 detail_right">
											<!--- 「ｍ１棚段６」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1tana_dan6" CssClass="inpReadonlyRight inpRONum2" runat="server"></asp:TextBox>
										</div>
                                        <div style="display:none;">
											<div class="col34">
												<!--- 「ｍ１選択フラグ(隠し)６」チェックボックス --->
												<adv:AdvancedCheckBox ID="M1selectorcheckbox6" Text="" CssClass="" runat="server"></adv:AdvancedCheckBox>
											</div>
											<div class="col35">
												<!--- 「Ｍ１確定処理フラグ(隠し)６」隠しフィールド --->
												<asp:hiddenfield ID="M1entersyoriflg6" runat="server"></asp:hiddenfield>
											</div>
											<div class="col36">
												<!--- 「Ｍ１明細色区分(隠し)６」隠しフィールド --->
												<asp:hiddenfield ID="M1dtlirokbn6" runat="server"></asp:hiddenfield>
											</div>
                                        </div>
                                    </div>
                                    <div class="str-result-item-01" style="float:left;width:auto;">
										<div class="col1 detail_right detail_color1">
											<!--- 「ｍ１行no７」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1rowno7" CssClass="inpReadonlyRight inpRONum4" runat="server"></asp:TextBox>
										</div>
										<div class="col2 detail_center">
											<!--- 「ｍ１フェイス№７」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1face_no7" CssClass="inpReadonlyRight inpRONum5" runat="server"></asp:TextBox>
										</div>
										<div class="col3 detail_right">
											<!--- 「ｍ１棚段７」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1tana_dan7" CssClass="inpReadonlyRight inpRONum2" runat="server"></asp:TextBox>
										</div>
                                        <div style="display:none;">
											<div class="col40">
												<!--- 「ｍ１選択フラグ(隠し)７」チェックボックス --->
												<adv:AdvancedCheckBox ID="M1selectorcheckbox7" Text="" CssClass="" runat="server"></adv:AdvancedCheckBox>
											</div>
											<div class="col41">
												<!--- 「Ｍ１確定処理フラグ(隠し)７」隠しフィールド --->
												<asp:hiddenfield ID="M1entersyoriflg7" runat="server"></asp:hiddenfield>
											</div>
											<div class="col42">
												<!--- 「Ｍ１明細色区分(隠し)７」隠しフィールド --->
												<asp:hiddenfield ID="M1dtlirokbn7" runat="server"></asp:hiddenfield>
											</div>
										</div>
                                    </div>
										<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->    
										<!--- 隠し項目エリア↑↑↑↑↑↑↑↑↑↑↑↑↑ --->
									<%--<!-- /str-result-item-01 --></div>--%>
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
							<!--- 「ボタン確定」ボタン --->
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
			<asp:Label ID="Face_no_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Searchcnt_lbl" runat="server"></asp:Label>
		</div>
	
	</form>
</body>
</html>

