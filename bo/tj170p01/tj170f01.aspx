<%@ Page language="c#" CodeFile="tj170f01.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Tj170p01.Page.Tj170f01Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">棚卸ロスリスト出力</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="tj170p01" FormId="tj170f01" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/tj170f01.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="tj170p01" FormId="tj170f01" runat="server" />

	<!-- Js業務部品のインポート --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05003.js" charset="UTF-8"></script><!-- 明細背景色変更処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script><!-- 0埋め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05011.js" charset="UTF-8"></script><!-- FROM-TOコピー処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05015.js" charset="UTF-8"></script><!-- 項目制御処理 -->	
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05019.js" charset="UTF-8"></script><!-- 情報ダイアログ表示処理(拡張版) -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02005.js" charset="UTF-8"></script><!-- 担当者マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02008.js" charset="UTF-8"></script><!-- 商品群１マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02009.js" charset="UTF-8"></script><!-- 商品群２マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02010.js" charset="UTF-8"></script><!-- 部門マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02011.js" charset="UTF-8"></script><!-- 品種マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02012.js" charset="UTF-8"></script><!-- ブランドマスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02019.js" charset="UTF-8"></script><!-- 店舗、棚卸実施日検索 -->
	
</head>

<body>
	<form id="Tj170f01" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="tj170p01" PgName="棚卸ロスリスト出力" FormId="tj170f01" FormName="棚卸ロスリスト出力 一覧" ></uc:Header>

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
						<!--- 「モード今回ボタン」リンク --->
						<a id="Btnmodekonkai" href="#tab22" class="" runat="server">今回</a>
					</li>
					<li>
						<!--- 「モード前回ボタン」リンク --->
						<a id="Btnmodezenkai" href="#tab23" class="" runat="server">前回</a>
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
					<table class="search-table">
						<tr>
							<td class="search-table-tdleft">
								<div class="str-form-02">
									<div class="inner">

										<div id="tab22" class="str-tab-cont">
											<table>
												<colgroup>
													<col class="w-type-01"/>
													<col class="w-type-03"/>
													<col class="w-type-02"/>
													<col class="w-type-04"/>
												<col />
												</colgroup>
												<tbody>
													<!-- 1行目1 -->
													<tr>
														<th>	
															<span class="tbl-hdg"><asp:Label ID="Tanaorosijissi_ymd1_lbl" runat="server">棚卸実施日</asp:Label></span>
														</th>
														<td>
															<!--- 「今回棚卸実施日」テキストボックスリードオンリー --->
															<asp:TextBox ID="Tanaorosijissi_ymd1" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox>
														</td>
														<th>
															<span class="tbl-hdg"><asp:Label ID="Tanaorosikikan_from1_lbl" runat="server">棚卸期間FROM</asp:Label></span>
														</th>
														<td>
															<!--- 「今回棚卸期間from」テキストボックスリードオンリー --->
															<!--- 「～」 --->
															<!--- 「今回棚卸期間to」テキストボックスリードオンリー --->
															<asp:TextBox ID="Tanaorosikikan_from1" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox>
															<span class="label-fromto">～</span>
															<asp:TextBox ID="Tanaorosikikan_to1" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox>
														</td>
													</tr>
												</tbody>
											</table>
										</div>
										<div id="tab23" class="str-tab-cont">
											<table>
												<colgroup>
													<col class="w-type-01"/>
													<col class="w-type-03"/>
													<col class="w-type-02"/>
													<col class="w-type-04"/>
												<col />
												</colgroup>
												<tbody>
													<!-- 1行目2 -->
													<tr>
														<th>	
															<span class="tbl-hdg"><asp:Label ID="Tanaorosijissi_ymd11_lbl" runat="server">棚卸実施日</asp:Label></span>
														</th>
														<td>
															<!--- 「前回棚卸実施日」テキストボックスリードオンリー --->
															<asp:TextBox ID="Tanaorosijissi_ymd11" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox>
														</td>
														<th>
															<span class="tbl-hdg"><asp:Label ID="Tanaorosikikan_from11_lbl" runat="server">棚卸期間FROM</asp:Label></span>
														</th>
														<td>
															<!--- 「前回棚卸期間from」テキストボックスリードオンリー --->
															<!--- 「～」 --->
															<!--- 「前回棚卸期間to」テキストボックスリードオンリー --->
															<asp:TextBox ID="Tanaorosikikan_from11" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox>
															<span class="label-fromto">～</span>
															<asp:TextBox ID="Tanaorosikikan_to11" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox>
														</td>
													</tr>
												</tbody>
											</table>
										</div>

										<table>
											<colgroup>
												<col class="w-type-01"/>
												<col class="w-type-03"/>
												<col class="w-type-02"/>
												<col class="w-type-04"/>
											<col />
											</colgroup>
											<tbody>
												<!-- 2行目 -->
												<tr>
													<th>
														<span class="tbl-hdg"><asp:Label ID="Syohingun1_cd_lbl" runat="server">商品群1</asp:Label></span>
													</th>
													<td>
														<!--- 「商品群1コード」一行テキストボックス（セパレート日付以外） --->
														<!--- 「商品群1コードボタン」ボタン --->
														<!--- 「商品群1略式名称」テキストボックスリードオンリー --->
														<span class="icon-in ">
															<md:MDTextBox ID="Syohingun1_cd" CssClass="inpSerch inpSyohingun1" runat="server">
															</md:MDTextBox><input type="button" id="Btnsyohingun1_cd" name="Btnsyohingun1_cd" value="" runat="server" class="icon-search"/>
														</span>
														<asp:TextBox ID="Syohingun1_ryaku_nm" CssClass="inpReadonlyLeft inpRoZenkaku10" runat="server"></asp:TextBox>
													</td>
													<th>
														<span class="tbl-hdg"><asp:Label ID="Syohingun2_cd_lbl" runat="server">商品群2</asp:Label></span>
													</th>
													<td>
														<!--- 「商品群2コード」一行テキストボックス（セパレート日付以外） --->
														<!--- 「商品群2コードボタン」ボタン --->
														<!--- 「商品群2名称」テキストボックスリードオンリー --->
														<span class="icon-in">
															<md:MDTextBox ID="Syohingun2_cd" CssClass="inpSerch inpSyohingun2" runat="server"></md:MDTextBox>
															<input type="button" id="Btnsyohingun2_cd" name="Btnsyohingun2_cd" value="" runat="server" class="icon-search"/>
														</span>
														<asp:TextBox ID="Grpnm" CssClass="inpReadonlyLeft inpRoZenkaku10" runat="server"></asp:TextBox>
													</td>
												</tr>
												<!-- 3行目 -->
												<tr>
													<th>
														<span class="tbl-hdg"><asp:Label ID="Bumon_cd_from_lbl" runat="server"></asp:Label></span>
													</th>
													<td colspan="3">
													<!--- 「部門コードfrom」一行テキストボックス（セパレート日付以外） ---><!--- 「部門コードFROMボタン」ボタン ---><!--- 「部門名from」テキストボックスリードオンリー --->
													<!--- 「品種コードfrom」一行テキストボックス（セパレート日付以外） ---><!--- 「品種コードFROMボタン」ボタン ---><!--- 「品種略名称from」テキストボックスリードオンリー --->
													<!--- 「部門コードto」一行テキストボックス（セパレート日付以外） ---><!--- 「部門コードTOボタン」ボタン ---><!--- 「部門名to」テキストボックスリードオンリー --->
													<!--- 「品種コードto」一行テキストボックス（セパレート日付以外） ---><!--- 「品種コードTOボタン」ボタン ---><!--- 「品種略名称to」テキストボックスリードオンリー --->
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
												<!-- 4行目 -->
												<tr>
													<th>
														<span class="tbl-hdg"><asp:Label ID="Burando_cd_lbl" runat="server">ブランド</asp:Label></span>
													</th>
													<td>
														<!--- 「ブランドコード」一行テキストボックス（セパレート日付以外） --->
														<!--- 「ブランドコードボタン」ボタン --->
														<!--- 「ブランド名」テキストボックスリードオンリー --->
														<span class="icon-in"><md:MDTextBox ID="Burando_cd" CssClass="inpSerch inpBrand" runat="server"></md:MDTextBox><input type="button" id="Btnburando_cd" name="Btnburando_cd" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="Burando_nm" CssClass="inpReadonlyLeft inpROHankaku20" runat="server"></asp:TextBox>
													</td>
													<th>
														<span class="tbl-hdg"><asp:Label ID="Loss_tensu_lbl" runat="server">ロス点数</asp:Label></span>
													</th>
													<td>
														<!--- 「ロス点数」一行テキストボックス（セパレート日付以外） --->
														<!--- 「ロス有フラグ」チェックボックス --->
														<md:MDTextBox ID="Loss_tensu" CssClass="inpSu-07" runat="server"></md:MDTextBox>
														<span class="tbl-hdg label-none" style="display:none" id="Loss_ari_flg_Label" runat="server">&nbsp</span>
														<label><adv:AdvancedCheckBox ID="Loss_ari_flg" Text="ロス有のみ" CssClass="" runat="server"></adv:AdvancedCheckBox></label>
													</td>
												</tr>
												<!-- 5行目 -->
												<tr>
													<th>
														<span class="tbl-hdg"><asp:Label ID="Shuturyoku_tani_lbl" runat="server">出力単位</asp:Label></span>
													</th>
													<td class="last">
														<!--- 「出力単位」ラジオボタン --->
														<adv:ConditionRBList ID="Shuturyoku_tani" ConditionName="shuturyoku_tani" RepeatDirection="Horizontal" CssClass="" runat="server"></adv:ConditionRBList>
														</td>
													<th>
														<span class="tbl-hdg"><asp:Label ID="Sort_jun_lbl" runat="server">ソート順</asp:Label></span>
													</th>
													<td class="last">
														<!--- 「ソート順」ラジオボタン --->
														<adv:ConditionRBList ID="Sort_jun" ConditionName="meisai_sort_tj170f01" RepeatDirection="Horizontal" CssClass="" runat="server"></adv:ConditionRBList>
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
						<!--- 「全選択ボタン」ボタン --->
						<li><span><label><input type="button" id="Btnzenstk" value="" onserverclick="OnBTNZENSTK_FRM" runat="server" class="icon-utility-01"/>全選択</label></span></li>
						<!--- 「全解除ボタン」ボタン --->
						<li><span><label><input type="button" id="Btnzenkjo" value="" onserverclick="OnBTNZENKJO_FRM" runat="server" class="icon-utility-02"/>全解除</label></span></li>
					</ul>
					<ul>
						<!--帳票／CSV系ボタンを配置する場合はこのulタグの中-->
						<li><div class="str-outrep"><span>出力帳票：</span></div></li>
						<li>
							<!--- 「出力帳票」ラジオボタン --->
							<div class="str-outrep2">
								<span><adv:ConditionRBList ID="Shuturyoku_print" ConditionName="shuturyoku_print" RepeatDirection="Horizontal" CssClass="" runat="server"></adv:ConditionRBList></span>
							</div>
						</li>


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
							<div class="col1">
								<asp:Label ID="M1rowno_lbl" runat="server">No.</asp:Label>
							</div>
							<div class="col2">
								<asp:Label ID="M1syohingun1_cd_lbl" runat="server">商品群1</asp:Label>
							</div>
							<div class="col3">
								<asp:Label ID="M1syohingun2_cd_lbl" runat="server">商品群2</asp:Label>
							</div>
							<div class="col4">
								<asp:Label ID="M1bumon_cd_lbl" runat="server">部門</asp:Label>
							</div>
							<div class="col5">
								<asp:Label ID="M1tanajityobo_su_lbl" runat="server">棚時帳簿数</asp:Label>
							</div>
							<div class="col6">
								<asp:Label ID="M1tanajisekiso_su_lbl" runat="server">棚時積送数</asp:Label>
							</div>
							<div class="col7">
								<asp:Label ID="M1jitana_su_lbl" runat="server">実棚数</asp:Label>
							</div>
							<div class="col8">
								<asp:Label ID="M1ikoukebarai_su_lbl" runat="server">以降受払数</asp:Label>
							</div>
							<div class="col9">
								<asp:Label ID="M1rironzaiko_su_lbl" runat="server">理論在庫数</asp:Label>
							</div>
							<div class="col10">
								<asp:Label ID="M1rirontanaorosi_su_lbl" runat="server">理論棚卸数</asp:Label>
							</div>
							<div class="col11">
								<asp:Label ID="M1loss_su_lbl" runat="server">ロス数</asp:Label>
							</div>
							<div class="col12">
								<asp:Label ID="M1loss_kin_lbl" runat="server">ロス金額</asp:Label>
							</div>
							<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
							<div style="display:none">
								<asp:Label ID="M1syohingun1_ryaku_nm_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1bumonkana_nm_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1grpnm_lbl" runat="server"></asp:Label>
							</div>
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
											<!--- 「Ｍ１商品群1リンク」ボタン --->
											<input type="button" id="M1syohingun1_cd" value="" onserverclick="OnM1SYOHINGUN1_CD_FRM" runat="server" class="meisaiLink"/>
										</div>
										<div class="col3 detail_left">
											<!--- 「ｍ１商品群2コード」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1syohingun2_cd" CssClass="inpReadonlyLeft inpRONum5" runat="server"></asp:TextBox>
											<!--- 「ｍ１商品群2名称」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1grpnm" CssClass="inpReadonlyLeft inpROZenkaku10 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col4 detail_left">
											<!--- 「ｍ１部門コード」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1bumon_cd" CssClass="inpReadonlyLeft inpRONum3" runat="server"></asp:TextBox>
											<!--- 「ｍ１部門カナ名」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1bumonkana_nm" CssClass="inpReadonlyLeft inpROHankaku12 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col5 cell detail_right">
											<!--- 「ｍ１棚時帳簿数」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1tanajityobo_su" CssClass="inpReadonlyRight inpRONumCmaMinus7" runat="server"></asp:TextBox>
										</div>
										<div class="col6 cell detail_right">
											<!--- 「ｍ１棚時積送数」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1tanajisekiso_su" CssClass="inpReadonlyRight inpRONumCmaMinus7" runat="server"></asp:TextBox>
										</div>
										<div class="col7 cell detail_right">
											<!--- 「ｍ１実棚数」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1jitana_su" CssClass="inpReadonlyRight inpRONumCmaMinus7" runat="server"></asp:TextBox>
										</div>
										<div class="col8 cell detail_right">
											<!--- 「ｍ１以降受払数」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1ikoukebarai_su" CssClass="inpReadonlyRight inpRONumCmaMinus7" runat="server"></asp:TextBox>
										</div>
										<div class="col9 cell detail_right">
											<!--- 「ｍ１理論在庫数」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1rironzaiko_su" CssClass="inpReadonlyRight inpRONumCmaMinus7" runat="server"></asp:TextBox>
										</div>
										<div class="col10 cell detail_right">
											<!--- 「ｍ１理論棚卸数」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1rirontanaorosi_su" CssClass="inpReadonlyRight inpRONumCmaMinus7" runat="server"></asp:TextBox>
										</div>
										<div class="col11 cell detail_right">
											<!--- 「ｍ１ロス数」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1loss_su" CssClass="inpReadonlyRight inpRONumCmaMinus7" runat="server"></asp:TextBox>
										</div>
										<div class="col12 cell detail_right">
											<!--- 「ｍ１ロス金額」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1loss_kin" CssClass="inpReadonlyRight inpRONumCmaMinus7" runat="server"></asp:TextBox>
										</div>
										
										<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
										<div style="display:none">
											<!--- 「ｍ１選択フラグ(隠し)」チェックボックス --->
											<adv:AdvancedCheckBox ID="M1selectorcheckbox" Text="" CssClass="" runat="server"></adv:AdvancedCheckBox>
											<!--- 「Ｍ１確定処理フラグ(隠し)」隠しフィールド --->
											<asp:hiddenfield ID="M1entersyoriflg" runat="server"></asp:hiddenfield>
											<!--- 「Ｍ１明細色区分(隠し)」隠しフィールド --->
											<asp:hiddenfield ID="M1dtlirokbn" runat="server"></asp:hiddenfield>
											<!--- 「Ｍ１商品群1略式名称リンク」ボタン --->
											<input type="button" id="M1syohingun1_ryaku_nm" value="" onserverclick="OnM1SYOHINGUN1_RYAKU_NM_FRM" runat="server" class="meisaiLink"/>
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
							<!-- ページャ下部にボタンを配置する場合はこの中 -->
						</p>
					<!-- /str-pager-01 --></div>
				<!-- /footerBtnArea --></div>
		
		<!-- /wrap --></div>	
		
		<!-- 画面上隠しエレメントを格納するエリア-->
		<div id="hiddenElements" style="display:none" runat="server">
			<asp:Label ID="Head_tenpo_cd_lbl" runat="server">店舗</asp:Label>
			<asp:Label ID="Head_tenpo_cd_Req" runat="server" CssClass="required">*</asp:Label>
			<asp:Label ID="Head_tenpo_nm_lbl" runat="server"></asp:Label>
			<asp:hiddenfield ID="Modeno" runat="server"></asp:hiddenfield>
			<asp:hiddenfield ID="Stkmodeno" runat="server"></asp:hiddenfield>
			<asp:hiddenfield ID="Tanaorosikijun_ymd" runat="server"></asp:hiddenfield>
			<asp:hiddenfield ID="Tanaorosikijun_ymd1" runat="server"></asp:hiddenfield>
			<asp:Label ID="Searchcnt_lbl" runat="server"></asp:Label>
			<asp:Label ID="Tanaorosikikan_to11_lbl" runat="server">棚卸期間TO</asp:Label>
			<asp:Label ID="Tanaorosikikan_to1_lbl" runat="server">棚卸期間TO</asp:Label>
			<asp:Label ID="Syohingun1_ryaku_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Grpnm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Bumon_nm_from_lbl" runat="server"></asp:Label>
			<asp:Label ID="Hinsyu_cd_from_lbl" runat="server">品種FROM</asp:Label>
			<asp:Label ID="Hinsyu_ryaku_nm_from_lbl" runat="server"></asp:Label>
			<asp:Label ID="Bumon_cd_to_lbl" runat="server">部門TO</asp:Label>
			<asp:Label ID="Bumon_nm_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Hinsyu_cd_to_lbl" runat="server">品種TO</asp:Label>
			<asp:Label ID="Hinsyu_ryaku_nm_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Burando_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Loss_ari_flg_lbl" runat="server">ロス有のみ</asp:Label>
			<asp:Label ID="Shuturyoku_print_lbl" runat="server">出力帳票</asp:Label>
		</div>
	
	</form>
</body>
</html>

