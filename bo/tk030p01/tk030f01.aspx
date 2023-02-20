<%@ Page language="c#" CodeFile="tk030f01.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Tk030p01.Page.Tk030f01Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">評価損NB一括確定</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="tk030p01" FormId="tk030f01" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/tk030f01.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="tk030p01" FormId="tk030f01" runat="server" />

	<!-- Js業務部品のインポート --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05011.js" charset="UTF-8"></script><!-- FROM-TOコピー処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02001.js" charset="UTF-8"></script><!-- 店舗検索 -->

</head>

<body>
	<form id="Tk030f01" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="tk030p01" PgName="評価損NB一括確定" FormId="tk030f01" FormName="評価損NB一括確定" ></uc:Header>

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
														<col />
												</colgroup>
												<tr>
													<th scope="col">
														<span class="tbl-hdg">
															<asp:Label ID="Syori_ym_lbl" runat="server">処理月</asp:Label>
														</span>
													</th>
													<td>
														<span class="icon-in">
															<!--- 「処理月」ドロップダウンリスト --->
															<asp:DropDownList ID="Syori_ym" CssClass="slt-syoriYm" runat="server"></asp:DropDownList>
															<span class="select-arrow"></span>
														</span>
													</td>
													<th scope="col">
														<span class="tbl-hdg">
															<asp:Label ID="Tenpo_cd_from_lbl" runat="server">店舗</asp:Label>
														</span>
													</th>
													<td>
														<!--- 「店舗コードfrom」一行テキストボックス（セパレート日付以外） --->
														<!--- 「店舗コードFROMボタン」ボタン --->
														<!--- 「店舗名from」テキストボックスリードオンリー --->
														<span class="icon-in">
															<md:MDTextBox ID="Tenpo_cd_from" CssClass="inpSerch inpTenpo" runat="server"></md:MDTextBox>
															<input type="button" id="Btntenpocd_from" name="Btntenpocd_from" value="" runat="server" class="icon-search"/>
														</span>
														<asp:TextBox ID="Tenpo_nm_from" CssClass="inpReadonlyLeft" runat="server"></asp:TextBox>

														<span class="label-fromto">～</span>

														<!--- 「店舗コードto」一行テキストボックス（セパレート日付以外） --->
														<!--- 「店舗コードTOボタン」ボタン --->
														<!--- 「店舗名to」テキストボックスリードオンリー --->
														<span class="icon-in">
															<md:MDTextBox ID="Tenpo_cd_to" CssClass="inpSerch inpTenpo" runat="server"></md:MDTextBox>
															<input type="button" id="Btntenpocd_to" name="Btntenpocd_to" value="" runat="server" class="icon-search"/>
														</span>
														<asp:TextBox ID="Tenpo_nm_to" CssClass="inpReadonlyLeft" runat="server"></asp:TextBox>
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
								<!--- 「一括承認ボタン」ボタン --->
								<span><label><input type="button" id="Btnikkatsusyonin" value="" onserverclick="OnBTNIKKATSUSYONIN_FRM" runat="server" class="icon-utility-01"/>一括承認</label></span>
							</li>
							<li>
								<!--- 「一括却下ボタン」ボタン --->
								<span><label><input type="button" id="Btnikkatsukyakka" value="" onserverclick="OnBTNIKKATSUKYAKKA_FRM" runat="server" class="icon-utility-01"/>一括却下</label></span>
							</li>
							<li>
								<!--- 「全解除ボタン」ボタン --->
								<span><label><input type="button" id="Btnzenkjo" value="" onserverclick="OnBTNZENKJO_FRM" runat="server" class="icon-utility-02"/>全解除</label></span>
							</li>
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
							<div class="col2 col_2dan">
								<asp:Label ID="M1tenpo_cd_lbl" runat="server">店舗</asp:Label>
							</div>
							<div class="col3">
								<div><asp:Label ID="M1bumon_cd_lbl" runat="server">部門</asp:Label></div>
								<div><asp:Label ID="M1hinsyu_cd_lbl" runat="server">品種</asp:Label></div>
							</div>
							<div class="col4">
								<div><asp:Label ID="M1burando_nm_lbl" runat="server">ブランド</asp:Label></div>
								<div class="col4-1 headcell"><asp:Label ID="M1jisya_hbn_lbl" runat="server">自社品番</asp:Label></div>
								<div class="col4-2 headcell"><asp:Label ID="M1hanbaikanryo_ymd_lbl" runat="server">販完日</asp:Label></div>
							</div>
							<div class="col5">
								<div><asp:Label ID="M1maker_hbn_lbl" runat="server">メーカー品番</asp:Label></div>
								<div><asp:Label ID="M1syonmk_lbl" runat="server">商品名</asp:Label></div>
							</div>
							<div class="col6">
								<div><asp:Label ID="M1scan_cd_lbl" runat="server">スキャンコード</asp:Label></div>
								<div class="col6-1 headcell"><asp:Label ID="M1iro_nm_lbl" runat="server">色</asp:Label></div>
								<div class="col6-2 headcell"><asp:Label ID="M1size_nm_lbl" runat="server">サイズ</asp:Label></div>
							</div>
							<div class="col7">
								<div><asp:Label ID="M1genbaika_tnk_lbl" runat="server">現売価</asp:Label></div>
								<div><asp:Label ID="M1hyokason_su_lbl" runat="server">数量</asp:Label></div>
							</div>
							<div class="col8">
								<div><asp:Label ID="M1gen_tnk_lbl" runat="server">原単価</asp:Label></div>
								<div><asp:Label ID="M1haibun_kin_lbl" runat="server">原価金額</asp:Label></div>
							</div>
							<div class="col9">
								<div><asp:Label ID="M1nyuryoku_ymd_lbl" runat="server">入力日</asp:Label></div>
								<div><asp:Label ID="M1apply_ymd_lbl" runat="server">申請日</asp:Label></div>
							</div>
							<div class="col10">
								<div><asp:Label ID="M1nyuryokusha_cd_lbl" runat="server">入力者</asp:Label></div>
								<div><asp:Label ID="M1sinseisya_cd_lbl" runat="server">申請者</asp:Label></div>
							</div>
							<div class="col11">
								<div class="col11-1 headcell"><asp:Label ID="M1hyokasonsyubetsu_kb_lbl" runat="server">種別</asp:Label></div>
								<div class="col11-2 headcell"><asp:Label ID="M1hyokasonriyu_lbl" runat="server">評価損理由</asp:Label></div>
								<div class="col11 headcell"><asp:Label ID="M1kyakkariyu_kb_lbl" runat="server">却下理由</asp:Label></div>
							</div>
							<div class="col12 col_2dan">
								<asp:Label ID="M1syonin_flg_lbl" runat="server">承認</asp:Label>
							</div>
							<div class="col13 col_2dan">
								<asp:Label ID="M1kyakka_flg_lbl" runat="server">却下</asp:Label>
							</div>

						<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
						<div style="display:none">

							<div class="col24">
								<asp:Label ID="M1kyakkariyu_lbl" runat="server"></asp:Label>
							</div>
							<div class="col27">
								<asp:Label ID="M1selectorcheckbox_lbl" runat="server"></asp:Label>
							</div>
							<div class="col28">
								<asp:Label ID="M1entersyoriflg_lbl" runat="server"></asp:Label>
							</div>
							<div class="col29">
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
											<asp:TextBox ID="M1rowno" CssClass="inpReadonlyRight inpRONum4" runat="server"></asp:TextBox>
										</div>
										<div class="col2 col_2dan detail_center">
											<!--- 「ｍ１店舗コード」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1tenpo_cd" CssClass="inpReadonlyLeft inpTenpo" runat="server"></asp:TextBox>
										</div>
										<div class="col3 detail_center">
											<!--- 「ｍ１部門コード」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1bumon_cd" CssClass="inpReadonlyLeft inpBumon" runat="server"></asp:TextBox></div>
											<!--- 「ｍ１品種コード」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1hinsyu_cd" CssClass="inpReadonlyLeft inpHinshu" runat="server"></asp:TextBox></div>
										</div>
										<div class="col4 detail_left">
											<!--- 「ｍ１ブランド名」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1burando_nm" CssClass="inpReadonlyLeft inpROHankaku12 tooltip" runat="server"></asp:TextBox></div>
											<!--- 「ｍ１自社品番」テキストボックスリードオンリー --->
											<div class="col4-1 cell detail_center"><asp:TextBox ID="M1jisya_hbn" CssClass="inpReadonlyLeft inpRONum8" runat="server"></asp:TextBox></div>
											<!--- 「ｍ１販売完了日」テキストボックスリードオンリー --->
											<div class="col4-2 cell detail_center"><asp:TextBox ID="M1hanbaikanryo_ymd" CssClass="inpReadonlyLeft inpDt2" runat="server"></asp:TextBox></div>
										</div>
										<div class="col5 detail_left">
											<!--- 「ｍ１メーカー品番」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1maker_hbn" CssClass="inpReadonlyLeft inpROHankaku16 tooltip" runat="server"></asp:TextBox></div>
											<!--- 「ｍ１商品名(カナ)」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1syonmk" CssClass="inpReadonlyLeft inpROHankaku16 tooltip" runat="server"></asp:TextBox></div>
										</div>
										<div class="col6 detail_left">
											<!--- 「ｍ１スキャンコード」テキストボックスリードオンリー --->
											<div class="detail_center"><asp:TextBox ID="M1scan_cd" CssClass="inpReadonlyLeft inpRONum13" runat="server"></asp:TextBox></div>
											<!--- 「ｍ１色」テキストボックスリードオンリー --->
											<div class="col6-1 cell detail_left"><asp:TextBox ID="M1iro_nm" CssClass="inpReadonlyLeft inpROHankaku6 tooltip" runat="server"></asp:TextBox></div>
											<!--- 「ｍ１サイズ」テキストボックスリードオンリー --->
											<div class="col6-2 cell detail_left"><asp:TextBox ID="M1size_nm" CssClass="inpReadonlyLeft inpROHankaku4 tooltip" runat="server"></asp:TextBox></div>
										</div>
										<div class="col7 detail_right">
											<!--- 「ｍ１現売価」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1genbaika_tnk" CssClass="inpReadonlyRight inpRONumCma7" runat="server"></asp:TextBox></div>
											<!--- 「ｍ１数量」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1hyokason_su" CssClass="inpReadonlyRight inpRONumCmaMinus7" runat="server"></asp:TextBox></div>
										</div>
										<div class="col8 detail_right">
											<!--- 「ｍ１原単価」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1gen_tnk" CssClass="inpReadonlyRight inpRONumCma7" runat="server"></asp:TextBox></div>
											<!--- 「ｍ１原価金額」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1haibun_kin" CssClass="inpReadonlyRight inpRONumCmaMinus9" runat="server"></asp:TextBox></div>
										</div>
										<div class="col9 detail_center">
											<!--- 「ｍ１入力日」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1nyuryoku_ymd" CssClass="inpReadonlyRight inpRONum6" runat="server"></asp:TextBox></div>
											<!--- 「ｍ１申請日」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1apply_ymd" CssClass="inpReadonlyRight inpRONum6" runat="server"></asp:TextBox></div>
										</div>
										<div class="col10 detail_center">
											<!--- 「ｍ１入力者コード」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1nyuryokusha_cd" CssClass="inpReadonlyLeft inpTanto" runat="server"></asp:TextBox></div>
											<!--- 「ｍ１申請者コード」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1sinseisya_cd" CssClass="inpReadonlyLeft inpTanto" runat="server"></asp:TextBox></div>
										</div>
										<div class="col11 detail_left">
											<!--- 「ｍ１評価損種別区分」テキストボックスリードオンリー --->
											<div class="col11-1 cell detail_left"><asp:TextBox ID="M1hyokasonsyubetsu_kb" CssClass="inpReadonlyLeft hyoukasonShubetu tooltip" runat="server"></asp:TextBox></div>
											<!--- 「ｍ１評価損理由」テキストボックスリードオンリー --->
											<div class="col11-2 cell detail_left"><asp:TextBox ID="M1hyokasonriyu" CssClass="inpReadonlyLeft tooltip" runat="server"></asp:TextBox></div>
											<div class="col11 cell detail_left">
												<!--- 「ｍ１却下理由区分」ドロップダウンリスト --->
												<md:MDCodeCondition ID="M1kyakkariyu_kb" FormID="Tk030f01" PgID="Tk030p01" CssClass="slt-kyakka" runat="server"></md:MDCodeCondition>
												<span class="select-arrow"></span>
												<!--- 「ｍ１却下理由」一行テキストボックス（セパレート日付以外） --->
												<md:MDTextBox ID="M1kyakkariyu" CssClass="inp-kyakka tooltip" runat="server"></md:MDTextBox>
											</div>
										</div>
										<div class="col12 col_2dan detail_center">
											<!--- 「ｍ１承認」チェックボックス --->
											<adv:AdvancedCheckBox ID="M1syonin_flg" Text="" CssClass="" runat="server"></adv:AdvancedCheckBox>
										</div>
										<div class="col13 col_2dan detail_center">
											<!--- 「ｍ１却下」チェックボックス --->
											<adv:AdvancedCheckBox ID="M1kyakka_flg" Text="" CssClass="" runat="server"></adv:AdvancedCheckBox>
										</div>

									<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
									<div style="display:none">

										<div class="col27">
											<!--- 「ｍ１選択フラグ(隠し)」チェックボックス --->
											<adv:AdvancedCheckBox ID="M1selectorcheckbox" Text="" CssClass="" runat="server"></adv:AdvancedCheckBox>
										</div>
										<div class="col28">
											<!--- 「Ｍ１確定処理フラグ(隠し)」隠しフィールド --->
											<asp:hiddenfield ID="M1entersyoriflg" runat="server"></asp:hiddenfield>
										</div>
										<div class="col29">
											<!--- 「Ｍ１明細色区分(隠し)」隠しフィールド --->
											<asp:hiddenfield ID="M1dtlirokbn" runat="server"></asp:hiddenfield>
										</div>

									</div>
									<!--- 隠し項目エリア↑↑↑↑↑↑↑↑↑↑↑↑↑ --->

									<!-- /str-result-item-01 --></div>
								</ItemTemplate>
							</asp:Repeater>
						<!-- /str-result-item-wrap --></div>

					<span class="adjust-elem-next"></span>
					<div id="footerArea" class="str-result-ftr-01" runat="server">
						<div class="col1 detail_right">&nbsp;</div>
						<div class="col2 detail_left">&nbsp;</div>
						<div class="col3 detail_left">&nbsp;</div>
						<div class="col4 detail_left">&nbsp;</div>
						<div class="col5 detail_left">&nbsp;</div>
						<div class="col6 detail_ftr_title">
							<asp:Label ID="Gokei_suryo_lbl" runat="server">合計</asp:Label>
						</div>
						<div class="col7 detail_ftr">
							<!--- 「合計数量」テキストボックスリードオンリー --->
							<asp:TextBox ID="Gokei_suryo" CssClass="inpReadonlyRight inpRONumCma8" runat="server"></asp:TextBox>
						</div>
						<div class="col8 detail_ftr">
							<!--- 「原価金額合計」テキストボックスリードオンリー --->
							<asp:TextBox ID="Haibun_kin_gokei" CssClass="inpReadonlyRight inpRONumCma9" runat="server"></asp:TextBox>
						</div>
						<div class="col9 detail_left">&nbsp;</div>
						<div class="col10 detail_left">&nbsp;</div>
						<div class="col11 detail_left">&nbsp;</div>
						<div class="col12 detail_left">&nbsp;</div>
						<div class="col13 detail_left">&nbsp;</div>
					<!-- /footerArea --></div>


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

							<!--- 「確定ボタン」ボタン --->
							<input type="button" id="Btnenter" value="確定" onserverclick="OnBTNENTER_FRM" runat="server" class="btn type-01"/>
						</p>
					<!-- /str-pager-01 --></div>
				<!-- /footerBtnArea --></div>
			<!-- /str-wrap-result --></div>
		<!-- /wrap --></div>	
		
		<!-- 画面上隠しエレメントを格納するエリア-->
		<div id="hiddenElements" style="display:none" runat="server">
		     <asp:Label ID="Head_tenpo_cd_lbl" runat="server"></asp:Label>
			<asp:Label ID="Head_tenpo_cd_Req" runat="server" CssClass="required">*</asp:Label>
			<asp:Label ID="Head_tenpo_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Searchcnt_lbl" runat="server"></asp:Label>
			<asp:Label ID="Tenpo_nm_from_lbl" runat="server"></asp:Label>
			<asp:Label ID="Tenpo_cd_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Tenpo_nm_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Haibun_kin_gokei_lbl" runat="server"></asp:Label>
		</div>
	
	</form>
</body>
</html>

