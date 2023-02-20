<%@ Page language="c#" CodeFile="tf020f01.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Tf020p01.Page.Tf020f01Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">商品経費振替申請</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="tf020p01" FormId="tf020f01" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/tf020f01.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="tf020p01" FormId="tf020f01" runat="server" />

	<!----->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02001.js" charset="UTF-8"></script><!-- 店舗検索 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02005.js" charset="UTF-8"></script><!-- 担当者マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02021.js" charset="UTF-8"></script><!-- 科目検索 -->

	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05003.js" charset="UTF-8"></script><!-- 明細背景色変更処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script><!-- 0埋め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05011.js" charset="UTF-8"></script><!-- FROM-TOコピー処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05015.js" charset="UTF-8"></script><!-- 項目制御処理 -->

	<!-- 業務共通コントロールのインポート-->
	<%@ Register TagPrefix="uc" TagName="common" Src="~/pjcommon/businessCommon/usercontrol/boCommonControl.ascx" %>
</head>

<body>
	<form id="Tf020f01" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="tf020p01" PgName="商品経費振替申請" FormId="tf020f01" FormName="商品経費振替申請 一覧" ></uc:Header>
			
			<!------------------------------------------
				□業務共通コントロール
			------------------------------------------->
			<uc:common ID="bocommon" runat="server"></uc:common>

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
														<span class="tbl-hdg"><asp:Label ID="Syonin_flg_lbl" runat="server">承認状態</asp:Label></span>
													</th>
													<td>
														<!--- 「承認状態」ドロップダウンリスト --->
														<md:MDConditionDDList ID="Syonin_flg" ConditionName="syonin_jotai" CssClass="slt-syonin" runat="server"></md:MDConditionDDList>
														<span class="select-arrow"></span>
													</td>
													<th>
														<span class="tbl-hdg"><asp:Label ID="Apply_ymd_from_lbl" runat="server">申請日</asp:Label></span>
													</th>
													<td>
														<!--- 「申請日ｆｒｏｍ」一行テキストボックス（セパレート日付以外） --->
														<!--- 「申請日ｔｏ」一行テキストボックス（セパレート日付以外） --->
														<span class="icon-in"><md:MDTextBox ID="Apply_ymd_from" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span>
														<span class="label-fromto">～</span>
														<span class="icon-in"><md:MDTextBox ID="Apply_ymd_to" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span>
													</td>
												</tr>
												<tr>
													<th>
														<span class="tbl-hdg"><asp:Label ID="Kakutei_ymd_from_lbl" runat="server">確定日</asp:Label></span>
													</th>
													<td>
														<!--- 「確定日ｆｒｏｍ」一行テキストボックス（セパレート日付以外） --->
														<!--- 「確定日ｔｏ」一行テキストボックス（セパレート日付以外） --->
														<span class="icon-in"><md:MDTextBox ID="Kakutei_ymd_from" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span>
														<span class="label-fromto">～</span>
														<span class="icon-in"><md:MDTextBox ID="Kakutei_ymd_to" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span>
													</td>
													<th>
														<span class="tbl-hdg"><asp:Label ID="Denpyo_bango_from_lbl" runat="server">伝票番号</asp:Label></span>
													</th>
													<td>
														<!--- 「伝票番号ｆｒｏｍ」一行テキストボックス（セパレート日付以外） --->
														<!--- 「伝票番号ｔｏ」一行テキストボックス（セパレート日付以外） --->
														<md:MDTextBox ID="Denpyo_bango_from" CssClass="inpDenpyo" runat="server"></md:MDTextBox>
														<span class="label-fromto">～</span>
														<md:MDTextBox ID="Denpyo_bango_to" CssClass="inpDenpyo" runat="server"></md:MDTextBox>
													</td>
												</tr>
												<tr>
													<th>
														<span class="tbl-hdg"><asp:Label ID="Kamoku_cd_from_lbl" runat="server">科目</asp:Label></span>
													</th>
													<td colspan="3">
														<!--- 「科目コードｆｒｏｍ」一行テキストボックス（セパレート日付以外） --->
														<!--- 「科目コードＦＲＯＭボタン」ボタン --->
														<!--- 「科目名ｆｒｏｍ」テキストボックスリードオンリー --->
														<!--- 「科目コードｔｏ」一行テキストボックス（セパレート日付以外） --->
														<!--- 「科目コードＴＯボタン」ボタン --->
														<!--- 「科目名ｔｏ」テキストボックスリードオンリー --->
														<span class="icon-in"><md:MDTextBox ID="Kamoku_cd_from" CssClass="inpSerch inpKamoku" runat="server"></md:MDTextBox><input type="button" id="Btnkamokucd_from" name="Btnkamokucd_from" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="Kamoku_nm_from" CssClass="inpReadonlyLeft inpROZenkaku20" runat="server"></asp:TextBox>
														<span class="label-fromto">～</span>
														<span class="icon-in"><md:MDTextBox ID="Kamoku_cd_to" CssClass="inpSerch inpKamoku" runat="server"></md:MDTextBox><input type="button" id="Btnkamokucd_to" name="Btnkamokucd_to" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="Kamoku_nm_to" CssClass="inpReadonlyLeft inpROZenkaku20" runat="server"></asp:TextBox>
													</td>
												</tr>
												<tr>
													<th class="last">
														<span class="tbl-hdg"><asp:Label ID="Sinseitan_cd_lbl" runat="server">申請者</asp:Label></span>
													</th>
													<td class="last">
														<!--- 「申請担当者コード」一行テキストボックス（セパレート日付以外） --->
														<!--- 「担当者コードボタン」ボタン --->
														<!--- 「申請担当者名称」テキストボックスリードオンリー --->
														<span class="icon-in"><md:MDTextBox ID="Sinseitan_cd" CssClass="inpSerch inpTanto" runat="server"></md:MDTextBox><input type="button" id="Btntanto_cd" name="Btntanto_cd" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="Sinseitan_nm" CssClass="inpReadonlyLeft" runat="server"></asp:TextBox>
													</td>
													<th class="last">
														<span class="tbl-hdg"><asp:Label ID="Jyuri_no_from_lbl" runat="server">受理番号</asp:Label></span>
													</th>
													<td class="last">
														<!--- 「受理番号ｆｒｏｍ」一行テキストボックス（セパレート日付以外） --->
														<!--- 「受理番号ｔｏ」一行テキストボックス（セパレート日付以外） --->
														<md:MDTextBox ID="Jyuri_no_from" CssClass="inpJuriNo" runat="server"></md:MDTextBox>
														<span class="label-fromto">～</span>
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
							<div class="col1 col_2dan"><asp:Label ID="M1rowno_lbl" runat="server">No.</asp:Label></div>
							<div class="col2 col_2dan"><asp:Label ID="M1apply_ymd_lbl" runat="server">申請日</asp:Label></div>
							<div class="col3 col_2dan"><asp:Label ID="M1kakutei_ymd_lbl" runat="server">確定日</asp:Label></div>
							<div class="col4 col_2dan"><asp:Label ID="M1denpyo_bango_lbl" runat="server">伝票番号</asp:Label></div>
							<div class="col5 col_2dan"><asp:Label ID="M1kamoku_cd_lbl" runat="server">科目</asp:Label></div>
							<div class="col6 col_2dan"><asp:Label ID="M1itemsu_lbl" runat="server">数量</asp:Label></div>
							<div class="col7">
								<div><asp:Label ID="M1genkakin_lbl" runat="server">原価金額</asp:Label></div>
								<div><asp:Label ID="M1baika_tnk_lbl" runat="server">売価金額</asp:Label></div>
							</div>
							<div class="col8 col_2dan"><asp:Label ID="M1sinseitan_nm_lbl" runat="server">申請担当者</asp:Label></div>
							<div class="col9 col_2dan"><asp:Label ID="M1jyuri_no_lbl" runat="server">受理番号</asp:Label></div>
							<div class="col10 col_2dan"><asp:Label ID="M1syonin_flg_nm_lbl" runat="server">承認状態</asp:Label></div>
							<div class="col11">
								<div><asp:Label ID="M1sinseiriyu_lbl" runat="server">申請理由</asp:Label></div>
								<div><asp:Label ID="M1kyakkariyu_lbl" runat="server">却下理由</asp:Label></div>
							</div>
							<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
							<div style="display:none">
								<div class="col6">
									<asp:Label ID="M1kamoku_nm_lbl" runat="server"></asp:Label>
								</div>
								<div class="col15">
									<asp:Label ID="M1selectorcheckbox_lbl" runat="server"></asp:Label>
								</div>
								<div class="col16">
									<asp:Label ID="M1entersyoriflg_lbl" runat="server"></asp:Label>
								</div>
								<div class="col17">
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
										<!--- 「ｍ１行no」テキストボックスリードオンリー --->
										<div class="col1 col_2dan detail_right"><asp:TextBox ID="M1rowno" CssClass="inpReadonlyRight inpRONum4" runat="server"></asp:TextBox></div>
										<!--- 「ｍ１申請日」テキストボックスリードオンリー --->
										<div class="col2 col_2dan detail_center"><asp:TextBox ID="M1apply_ymd" CssClass="inpReadonlyCenter inpRODate" runat="server"></asp:TextBox></div>
										<!--- 「ｍ１確定日」テキストボックスリードオンリー --->
										<div class="col3 col_2dan detail_center"><asp:TextBox ID="M1kakutei_ymd" CssClass="inpReadonlyCenter inpRODate" runat="server"></asp:TextBox></div>
										<!--- 「Ｍ１伝票番号リンク」ボタン --->
										<div class="col4 col_2dan detail_center"><input type="button" id="M1denpyo_bango" value="伝票番号" onserverclick="OnM1DENPYO_BANGO_FRM" runat="server" class="meisaiLink"/></div>
										<div class="col5 detail_left">
											<!--- 「ｍ１科目コード」テキストボックスリードオンリー --->
											<!--- 「ｍ１科目名」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1kamoku_cd" CssClass="inpReadonlyLeft inpRONum8" runat="server"></asp:TextBox></div>
											<div><asp:TextBox ID="M1kamoku_nm" CssClass="inpReadonlyLeft inpROZenkaku20 tooltip" runat="server"></asp:TextBox></div>
										</div>
										<!--- 「ｍ１数量」テキストボックスリードオンリー --->
										<div class="col6 col_2dan detail_right"><asp:TextBox ID="M1itemsu" CssClass="inpReadonlyRight inpRONumCma4" runat="server"></asp:TextBox></div>
										<div class="col7 detail_right">
											<!--- 「ｍ１原価金額」テキストボックスリードオンリー --->
											<!--- 「ｍ１売価」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1genkakin" CssClass="inpReadonlyRight inpRONumCmaMinus12" runat="server"></asp:TextBox></div>
											<div><asp:TextBox ID="M1baika_tnk" CssClass="inpReadonlyRight inpRONumCmaMinus12" runat="server"></asp:TextBox></div>
										</div>
										<!--- 「ｍ１申請担当者名称」テキストボックスリードオンリー --->
										<div class="col8 col_2dan detail_left"><asp:TextBox ID="M1sinseitan_nm" CssClass="inpReadonlyLeft inpROZenkaku10 tooltip" runat="server"></asp:TextBox></div>
										<!--- 「ｍ１受理番号」テキストボックスリードオンリー --->
										<div class="col9 col_2dan detail_left"><asp:TextBox ID="M1jyuri_no" CssClass="inpReadonlyLeft inpROHankaku10" runat="server"></asp:TextBox></div>
										<!--- 「ｍ１承認状態名称」テキストボックスリードオンリー --->
										<div class="col10 col_2dan detail_left"><asp:TextBox ID="M1syonin_flg_nm" CssClass="inpReadonlyLeft inpROZenkaku3 tooltip" runat="server"></asp:TextBox></div>
										<div class="col11 detail_left">
											<!--- 「ｍ１申請理由」テキストボックスリードオンリー --->
											<!--- 「ｍ１却下理由」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1sinseiriyu" CssClass="inpReadonlyLeft inpROZenkaku15 tooltip" runat="server"></asp:TextBox></div>
											<div><asp:TextBox ID="M1kyakkariyu" CssClass="inpReadonlyLeft inpROZenkaku15 tooltip" runat="server"></asp:TextBox></div>
										</div>
										<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
										<div style="display:none">
											<div class="col15">
												<!--- 「ｍ１選択フラグ(隠し)」チェックボックス --->
												<adv:AdvancedCheckBox ID="M1selectorcheckbox" Text="" CssClass="" runat="server"></adv:AdvancedCheckBox>
											</div>
											<div class="col16">
												<!--- 「Ｍ１確定処理フラグ(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1entersyoriflg" runat="server"></asp:hiddenfield>
											</div>
											<div class="col17">
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
			<asp:Label ID="Head_tenpo_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Head_tenpo_cd_Req" runat="server" CssClass="required">*</asp:Label>
			<asp:Label ID="Apply_ymd_to_lbl" runat="server">申請日ＴＯ</asp:Label>
			<asp:Label ID="Kakutei_ymd_to_lbl" runat="server">確定日ＴＯ</asp:Label>
			<asp:Label ID="Denpyo_bango_to_lbl" runat="server">伝票番号ＴＯ</asp:Label>
			<asp:Label ID="Kamoku_nm_from_lbl" runat="server"></asp:Label>
			<asp:Label ID="Kamoku_cd_to_lbl" runat="server">科目ＴＯ</asp:Label>
			<asp:Label ID="Kamoku_nm_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Sinseitan_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Jyuri_no_to_lbl" runat="server">受理番号ＴＯ</asp:Label>
			<asp:Label ID="Searchcnt_lbl" runat="server"></asp:Label>

			<!--- 「モードNO」隠しフィールド --->
			<asp:hiddenfield ID="Modeno" runat="server"></asp:hiddenfield>
			<!--- 「選択モードNO」隠しフィールド --->
			<asp:hiddenfield ID="Stkmodeno" runat="server"></asp:hiddenfield>
		</div>
	</form>
</body>
</html>

