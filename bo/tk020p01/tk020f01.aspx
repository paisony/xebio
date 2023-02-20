<%@ Page language="c#" CodeFile="tk020f01.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Tk020p01.Page.Tk020f01Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">評価損処理</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="tk020p01" FormId="tk020f01" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/tk020f01.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="tk020p01" FormId="tk020f01" runat="server" />

	<!-- Js業務部品のインポート --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05002.js" charset="UTF-8"></script><!-- スキャンコード丸め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05003.js" charset="UTF-8"></script><!-- 明細背景色変更処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script><!-- 0埋め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05010.js" charset="UTF-8"></script><!-- カンマ編集処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05014.js" charset="UTF-8"></script><!-- 名称取得拡張 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05015.js" charset="UTF-8"></script><!-- 項目制御処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05019.js" charset="UTF-8"></script><!-- 情報ダイアログ表示処理(拡張版) -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05024.js" charset="UTF-8"></script><!-- 数値編集関数群 -->

	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02001.js" charset="UTF-8"></script><!-- 店舗検索 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02004.js" charset="UTF-8"></script><!-- 発注マスタ取得(スキャンコード) -->

</head>

<body>
	<form id="Tk020f01" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="tk020p01" PgName="評価損処理" FormId="tk020f01" FormName="評価損処理" ></uc:Header>

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
						<!--- 「モード申請ボタン」リンク --->
						<a id="Btnmodeapply" href="#tab6" class="" runat="server">申請</a>
					</li>
					<li>
						<!--- 「モード再申請ボタン」リンク --->
						<a id="Btnmodereapply" href="#tab7" class="" runat="server">再申請</a>
					</li>
					<li>
						<!--- 「モード修正ボタン」リンク --->
						<a id="Btnmodeupd" href="#tab8" class="" runat="server">修正</a>
					</li>
					<li id="modeV" runat="server">
						<!--- 「モード照会ボタン」リンク --->
						<a id="Btnmoderef" href="#tab16" class="" runat="server">照会</a>
					</li>
					<li id="modeX" runat="server">
						<!--- 「モード決裁状況ボタン」リンク --->
						<a id="Btnmodekessaijyokyo" href="#tab20" class="" runat="server">決裁状況</a>
					</li>
				</ul>
			</div>

			<div id="tab6" class="str-tab-cont"></div>
			<div id="tab7" class="str-tab-cont"></div>
			<div id="tab8" class="str-tab-cont"></div>
			<div id="tab16" class="str-tab-cont"></div>
			<div id="tab20" class="str-tab-cont"></div>
			
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
									<div id="list-search-result">
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
													<col class="w-type-03"/>
												</colgroup>
												<tr>
													<th scope="col">
														<span class="tbl-hdg">
															<asp:Label ID="Syori_ym_lbl" runat="server">処理月</asp:Label>
														</span>
													</th>
													<td>
														<!--- 「処理月」ドロップダウンリスト --->
														<asp:DropDownList ID="Syori_ym" CssClass="slt-syoriYm" runat="server"></asp:DropDownList>
														<span class="select-arrow"></span>
													</td>
													<td>
														<!--- 「却下フラグ」チェックボックス --->
														<span class="tbl-hdg label-none" style="display:none">&nbsp;</span>
														<adv:AdvancedCheckBox ID="Kyakka_flg" Text="却下データのみ" CssClass="" runat="server"></adv:AdvancedCheckBox>
													</td>
													<td>
														<!--- 「明細ソート」ラジオボタン --->
														<span class="tbl-hdg label-none" style="display:none">&nbsp;</span>
														<adv:ConditionRBList ID="Meisai_sort" ConditionName="meisai_sort_tk020f01" RepeatDirection="Horizontal" CssClass="rdo-MeisaiSort" runat="server"></adv:ConditionRBList>
													</td>
												</tr>
												<tr>
													<td class="last" colspan="4">
															<span>※申請処理は1日に1回のみ可能です。</span>
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
							<!--- 「全選択ボタン」ボタン --->
							<li><span><label><input type="button" id="Btnzenstk" value="" onserverclick="OnBTNZENSTK_FRM" runat="server" class="icon-utility-01"/>全選択</label></span></li>
							<!--- 「全解除ボタン」ボタン --->
							<li><span><label><input type="button" id="Btnzenkjo" value="" onserverclick="OnBTNZENKJO_FRM" runat="server" class="icon-utility-02"/>全解除</label></span></li>
							<!--- 「行追加ボタン」ボタン --->
							<li><span><label><input type="button" id="Btnrowins" value="" onserverclick="OnBTNROWINS_MADD" runat="server" class="icon-utility-06"/>行追加</label></span></li>
							<!--- 「行削除ボタン」ボタン --->
							<li><span><label><input type="button" id="Btnrowdel" value="" onserverclick="OnBTNROWDEL_FRM" runat="server" class="icon-utility-03"/>行削除</label></span></li>
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
								<div><asp:Label ID="M1hinsyu_cd_lbl" runat="server">品種</asp:Label></div>
							</div>
							<div class="col3">
								<div><asp:Label ID="M1burando_nm_lbl" runat="server">ブランド</asp:Label></div>
								<div class="col3-1 headcell"><asp:Label ID="M1jisya_hbn_lbl" runat="server">自社品番</asp:Label></div>
								<div class="col3-2 headcell"><asp:Label ID="M1hanbaikanryo_ymd_lbl" runat="server">販完日</asp:Label></div>
							</div>
							<div class="col4">
								<div><asp:Label ID="M1maker_hbn_lbl" runat="server">メーカー品番</asp:Label></div>
								<div><asp:Label ID="M1syonmk_lbl" runat="server">商品名</asp:Label></div>
							</div>
							<div class="col5">
								<div><asp:Label ID="M1scan_cd_lbl" runat="server">スキャンコード</asp:Label></div>
								<div class="col5-1 headcell"><asp:Label ID="M1iro_nm_lbl" runat="server">色</asp:Label></div>
								<div class="col5-2 headcell"><asp:Label ID="M1size_nm_lbl" runat="server">サイズ</asp:Label></div>
							</div>
							<div class="col6">
								<div><asp:Label ID="M1genbaika_tnk_lbl" runat="server">現売価</asp:Label></div>
								<div><asp:Label ID="M1hyokason_su_lbl" runat="server">数量</asp:Label></div>
							</div>
							<div class="col7">
								<div><asp:Label ID="M1gen_tnk_lbl" runat="server">原単価</asp:Label></div>
								<div><asp:Label ID="M1haibun_kin_lbl" runat="server">原価金額</asp:Label></div>
							</div>
							<div class="col8">
								<div><asp:Label ID="M1nyuryoku_ymd_lbl" runat="server">入力日</asp:Label></div>
								<div><asp:Label ID="M1apply_ymd_lbl" runat="server">申請日</asp:Label></div>
							</div>
							<div class="col9">
								<div><asp:Label ID="M1nyuryokusha_cd_lbl" runat="server">入力者</asp:Label></div>
								<div><asp:Label ID="M1sinseisya_cd_lbl" runat="server">申請者</asp:Label></div>
							</div>
							<div class="col10">
								<div class="col10-1 headcell"><asp:Label ID="M1hyokasonsyubetsu_kb_lbl" runat="server">種別</asp:Label></div>
								<div class="col10-2 headcell"><asp:Label ID="M1hyokasonriyu_kb_lbl" runat="server">評価損理由</asp:Label></div>
								<div class="col10 headcell"><asp:Label ID="M1kyakkariyu_lbl" runat="server">却下理由</asp:Label></div>
							</div>
							<div class="col11 col_2dan">
								<asp:Label ID="M1tyotatsu_nm_lbl" runat="server">調達</asp:Label>
							</div>
							<div class="col12 col_2dan">
								<asp:Label ID="Label2" runat="server">承認</asp:Label>
							</div>

							<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
							<div style="display:none">

								<asp:Label ID="M1bumon_nm_hdn_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1hinsyu_ryaku_nm_hdn_lbl" runat="server"></asp:Label>

								<div class="col22">
									<asp:Label ID="M1hyokasonriyu_lbl" runat="server"></asp:Label>
								</div>
								<div class="col26">
									<asp:Label ID="M1hyokason_su_hdn_lbl" runat="server"></asp:Label>
								</div>
								<div class="col27">
									<asp:Label ID="M1haibun_kin_hdn_lbl" runat="server"></asp:Label>
								</div>
								<div class="col28">
									<asp:Label ID="M1selectorcheckbox_lbl" runat="server"></asp:Label>
								</div>
								<div class="col29">
									<asp:Label ID="M1entersyoriflg_lbl" runat="server"></asp:Label>
								</div>
								<div class="col30">
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
											<!--- 「ｍ１行no」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1rowno" CssClass="inpReadonlyRight inpRONum4" runat="server"></asp:TextBox>
										</div>
										<div class="col2 detail_center">
											<!--- 「ｍ１部門コード」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1bumon_cd" CssClass="inpReadonlyLeft inpBumon" runat="server"></asp:TextBox></div>
											<!--- 「ｍ１品種コード」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1hinsyu_cd" CssClass="inpReadonlyLeft inpHinshu" runat="server"></asp:TextBox></div>
										</div>
										<div class="col3 detail_left">
											<!--- 「ｍ１ブランド名」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1burando_nm" CssClass="inpReadonlyLeft inpROHankaku12 tooltip" runat="server"></asp:TextBox></div>
											<!--- 「ｍ１自社品番」テキストボックスリードオンリー --->
											<div class="col3-1 cell detail_center"><asp:TextBox ID="M1jisya_hbn" CssClass="inpReadonlyLeft inpRONum8" runat="server"></asp:TextBox></div>
											<!--- 「ｍ１販売完了日」テキストボックスリードオンリー --->
											<div class="col3-2 cell detail_center"><asp:TextBox ID="M1hanbaikanryo_ymd" CssClass="inpReadonlyLeft inpDt2" runat="server"></asp:TextBox></div>
										</div>
										<div class="col4 detail_left">
											<!--- 「ｍ１メーカー品番」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1maker_hbn" CssClass="inpReadonlyLeft inpROHankaku14 tooltip" runat="server"></asp:TextBox></div>
											<!--- 「ｍ１商品名(カナ)」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1syonmk" CssClass="inpReadonlyLeft inpROHankaku14 tooltip" runat="server"></asp:TextBox></div>
										</div>
										<div class="col5 detail_left">
											<!--- 「ｍ１スキャンコード」一行テキストボックス（セパレート日付以外） --->
											<div><md:MDTextBox ID="M1scan_cd" CssClass="inpScan" runat="server"></md:MDTextBox></div>
											<!--- 「ｍ１色」テキストボックスリードオンリー --->
											<div class="col5-1 cell detail_left"><asp:TextBox ID="M1iro_nm" CssClass="inpReadonlyLeft inpROHankaku6 tooltip" runat="server"></asp:TextBox></div>
											<!--- 「ｍ１サイズ」テキストボックスリードオンリー --->
											<div class="col5-2 cell detail_left"><asp:TextBox ID="M1size_nm" CssClass="inpReadonlyLeft inpROHankaku4 tooltip" runat="server"></asp:TextBox></div>
										</div>
										<div class="col6 detail_right">
											<!--- 「ｍ１現売価」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1genbaika_tnk" CssClass="inpReadonlyRight inpRONumCma7" runat="server"></asp:TextBox></div>
											<!--- 「ｍ１数量」一行テキストボックス（セパレート日付以外） --->
											<div class="detail_center"><md:MDTextBox ID="M1hyokason_su" CssClass="inpSu-07" runat="server"></md:MDTextBox></div>
										</div>
										<div class="col7 detail_right">
											<!--- 「ｍ１原単価」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1gen_tnk" CssClass="inpReadonlyRight inpRONumCma7" runat="server"></asp:TextBox></div>
											<!--- 「ｍ１原価金額」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1haibun_kin" CssClass="inpReadonlyRight inpRONumCmaMinus9" runat="server"></asp:TextBox></div>
										</div>
										<div class="col8 detail_center">
											<!--- 「ｍ１入力日」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1nyuryoku_ymd" CssClass="inpReadonlyRight inpRONum6" runat="server"></asp:TextBox></div>
											<!--- 「ｍ１申請日」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1apply_ymd" CssClass="inpReadonlyRight inpRONum6" runat="server"></asp:TextBox></div>
										</div>
										<div class="col9 detail_center">
											<!--- 「ｍ１入力者コード」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1nyuryokusha_cd" CssClass="inpReadonlyLeft inpTanto" runat="server"></asp:TextBox></div>
											<!--- 「ｍ１申請者コード」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1sinseisya_cd" CssClass="inpReadonlyLeft inpTanto" runat="server"></asp:TextBox></div>
										</div>
										<div class="col10 detail_left">
											<div class="col10-1 cell detail_left">
												<!--- 「ｍ１評価損種別区分」ドロップダウンリスト --->
												<md:MDCodeCondition ID="M1hyokasonsyubetsu_kb" FormID="Tk020f01" PgID="Tk020p01" CssClass="slt-hyoukasonShubetu" runat="server"></md:MDCodeCondition>
												<span class="select-arrow"></span>
											</div>
											<div class="col10-2 cell detail_left">
												<!--- 「ｍ１評価損理由区分」ドロップダウンリスト --->
												<md:MDCodeCondition ID="M1hyokasonriyu_kb" FormID="Tk020f01" PgID="Tk020p01" CssClass="slt-hyoukasonRiyu" runat="server"></md:MDCodeCondition>
												<span class="select-arrow"></span>
												<!--- 「ｍ１評価損理由」一行テキストボックス（セパレート日付以外） --->
												<md:MDTextBox ID="M1hyokasonriyu" CssClass="inp-hyoukasonRiyu tooltip" runat="server"></md:MDTextBox>
											</div>
											<div class="col10 cell detail_left">
												<!--- 「ｍ１却下理由」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1kyakkariyu" CssClass="inpReadonlyLeft inp-kyakka tooltip" runat="server"></asp:TextBox>
											</div>
										</div>
										<div class="col11 col_2dan detail_left">
											<!--- 「ｍ１調達区分名称」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1tyotatsu_nm" CssClass="inpReadonlyLeft" runat="server" width="26px"></asp:TextBox>
										</div>
										<div class="col12 col_2dan detail_left">
											<!--- 「ｍ１承認状態名称」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1syonin_nm" CssClass="inpReadonlyLeft" runat="server" width="26px"></asp:TextBox>
										</div>

										<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
										<div style="display:none">
											<!--- 「M1部門名」隠しフィールド --->
												<asp:hiddenfield ID="M1bumon_nm_hdn" runat="server"></asp:hiddenfield>
											<!--- 「M1品種略名称」隠しフィールド --->
												<asp:hiddenfield ID="M1hinsyu_ryaku_nm_hdn" runat="server"></asp:hiddenfield>
											<div class="col26">
												<!--- 「Ｍ１数量(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1hyokason_su_hdn" runat="server"></asp:hiddenfield>
											</div>
											<div class="col27">
												<!--- 「Ｍ１原価金額(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1haibun_kin_hdn" runat="server"></asp:hiddenfield>
											</div>
											<div class="col28">
												<!--- 「ｍ１選択フラグ(隠し)」チェックボックス --->
												<adv:AdvancedCheckBox ID="M1selectorcheckbox" Text="" CssClass="" runat="server"></adv:AdvancedCheckBox>
											</div>
											<div class="col29">
												<!--- 「Ｍ１確定処理フラグ(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1entersyoriflg" runat="server"></asp:hiddenfield>
											</div>
											<div class="col30">
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
							<div class="col1 detail_left">&nbsp;</div>
							<div class="col2 detail_left">&nbsp;</div>
							<div class="col3 detail_left">&nbsp;</div>
							<div class="col4 detail_left">&nbsp;</div>
							<div class="col5 detail_ftr_title">
								<asp:Label ID="Gokei_suryo_lbl" runat="server">合計</asp:Label>
							</div>
							<div class="col6 detail_ftr">
								<!--- 「合計数量」テキストボックスリードオンリー --->
								<asp:TextBox ID="Gokei_suryo" CssClass="inpReadonlyRight inpRONumCma8" runat="server"></asp:TextBox>
							</div>
							<div class="col7 detail_ftr">
								<!--- 「原価金額合計」テキストボックスリードオンリー --->
								<asp:TextBox ID="Haibun_kin_gokei" CssClass="inpReadonlyRight inpRONumCma9" runat="server"></asp:TextBox>
							</div>
							<div class="col8 detail_left">&nbsp;</div>
							<div class="col9 detail_left">&nbsp;</div>
							<div class="col10 detail_left">&nbsp;</div>
							<div class="col11 detail_left">&nbsp;</div>
							<div class="col12 detail_left">&nbsp;</div>
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
			<asp:Label ID="Head_tenpo_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Head_tenpo_cd_lbl" runat="server"></asp:Label>
			<asp:Label ID="Head_tenpo_cd_Req" runat="server" CssClass="required">*</asp:Label>
			<asp:Label ID="Searchcnt_lbl" runat="server"></asp:Label>
			<asp:Label ID="Kyakka_flg_lbl" runat="server">却下データのみ</asp:Label>
			<asp:Label ID="Meisai_sort_lbl" runat="server"></asp:Label>
			<asp:Label ID="Haibun_kin_gokei_lbl" runat="server"></asp:Label>

			<!--- 「モードNO」隠しフィールド --->
			<asp:hiddenfield ID="Modeno" runat="server"></asp:hiddenfield>
			<!--- 「選択モードNO」隠しフィールド --->
			<asp:hiddenfield ID="Stkmodeno" runat="server"></asp:hiddenfield>
		</div>
	</form>
</body>
</html>

