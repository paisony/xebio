<%@ Page language="c#" CodeFile="td030f01.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Td030p01.Page.Td030f01Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">返品検索</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="td030p01" FormId="td030f01" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/td030f01.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="td030p01" FormId="td030f01" runat="server" />

	<!-- Js業務部品のインポート --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02001.js" charset="UTF-8"></script><!-- 店舗検索 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02002.js" charset="UTF-8"></script><!-- 仕入先マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02003.js" charset="UTF-8"></script><!-- 発注マスタ取得(自社品番) -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02004.js" charset="UTF-8"></script><!-- 発注マスタ取得(スキャンコード) -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02005.js" charset="UTF-8"></script><!-- 担当者マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02010.js" charset="UTF-8"></script><!-- 部門マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05001.js" charset="UTF-8"></script><!-- 自社品番丸め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05002.js" charset="UTF-8"></script><!-- スキャンコード丸め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script><!-- 0埋め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05009.js" charset="UTF-8"></script><!-- 指示番号丸め処理(返品用) -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05011.js" charset="UTF-8"></script><!-- FROM-TOコピー処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05014.js" charset="UTF-8"></script><!-- 名称取得拡張 -->

	<!-- 業務共通コントロールのインポート-->
	<%@ Register TagPrefix="uc" TagName="common" Src="~/pjcommon/businessCommon/usercontrol/boCommonControl.ascx" %>
</head>

<body>
	<form id="Td030f01" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="td030p01" PgName="返品検索" FormId="td030f01" FormName="返品検索 一覧" ></uc:Header>
			
			<!------------------------------------------
				□業務共通コントロール
			------------------------------------------->
			<uc:common ID="bocommon" runat="server"></uc:common>

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
					<!--<p class="required">*が付いている項目は必須入力になります。</p>-->
					<p class="required2">*付いている項目はいずれか一つの項目が必須入力になります。</p>
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
												<col />
											</colgroup>
											<tr>
												<th>
													<span class="tbl-hdg"><asp:Label ID="Denpyo_jyotai_lbl" runat="server">伝票状態</asp:Label></span><span class="required2">*</span>
												</th>
												<!--- 「伝票状態」ドロップダウンリスト --->
												<td>
													<md:MDConditionDDList ID="Denpyo_jyotai" ConditionName="henpin_denpyo_jotai" CssClass="slt-ddl slt-denpyoujotai" runat="server"></md:MDConditionDDList>
													<span class="select-arrow"></span>
												</td>
												<th>
													<span class="tbl-hdg"><asp:Label ID="Denpyo_bango_from_lbl" runat="server">伝票番号</asp:Label></span>
												</th>
												<!--- 「伝票番号ｆｒｏｍ」一行テキストボックス（セパレート日付以外） --->
												<!--- 「伝票番号ｔｏ」一行テキストボックス（セパレート日付以外） --->
												<td>
													<md:MDTextBox ID="Denpyo_bango_from" CssClass="inpDenpyo" runat="server"></md:MDTextBox><span class="label-fromto">～</span><md:MDTextBox ID="Denpyo_bango_to" CssClass="inpDenpyo" runat="server"></md:MDTextBox>
												</td>
												<th>
													<span class="tbl-hdg"><asp:Label ID="Motodenpyo_bango_from_lbl" runat="server">元伝票番号</asp:Label></span>
												</th>
												<!--- 「元伝票番号ｆｒｏｍ」一行テキストボックス（セパレート日付以外） --->
												<!--- 「元伝票番号ｔｏ」一行テキストボックス（セパレート日付以外） --->
												<td>
													<md:MDTextBox ID="Motodenpyo_bango_from" CssClass="inpDenpyo" runat="server"></md:MDTextBox><span class="label-fromto">～</span><md:MDTextBox ID="Motodenpyo_bango_to" CssClass="inpDenpyo" runat="server"></md:MDTextBox>
												</td>
											</tr>
											<tr>
												<th>
													<span class="tbl-hdg"><asp:Label ID="Siji_bango_from_lbl" runat="server">指示番号</asp:Label></span>
												</th>
												<!--- 「指示番号ｆｒｏｍ」一行テキストボックス（セパレート日付以外） --->
												<!--- 「指示番号ｔｏ」一行テキストボックス（セパレート日付以外） --->
												<td colspan="3">
													<md:MDTextBox ID="Siji_bango_from" CssClass="inpHenpinSijiNo" runat="server"></md:MDTextBox><span class="label-fromto">～</span><md:MDTextBox ID="Siji_bango_to" CssClass="inpHenpinSijiNo" runat="server"></md:MDTextBox>
												</td>
												<th>
													<span class="tbl-hdg"><asp:Label ID="Siiresaki_cd_lbl" runat="server">仕入先</asp:Label></span><span class="required2">*</span>
												</th>
												<!--- 「仕入先コード」一行テキストボックス（セパレート日付以外） --->
												<!--- 「仕入先コードボタン」ボタン --->
												<!--- 「仕入先略式名称」テキストボックスリードオンリー --->
												<td>
													<span class="icon-in">
														<md:MDTextBox ID="Siiresaki_cd" CssClass="inpSerch inpShiire" runat="server"></md:MDTextBox>
														<input type="button" id="Btnsiiresaki_cd" name="Btnsiiresaki_cd" value="" runat="server" class="icon-search"/>
													</span><asp:TextBox ID="Siiresaki_ryaku_nm" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<th>
													<span class="tbl-hdg"><asp:Label ID="Bumon_cd_from_lbl" runat="server">部門</asp:Label></span>
												</th>
												<!--- 「部門コードfrom」一行テキストボックス（セパレート日付以外） --->
												<!--- 「部門コードFROMボタン」ボタン --->
												<!--- 「部門名from」テキストボックスリードオンリー --->
												<!--- 「部門コードto」一行テキストボックス（セパレート日付以外） --->
												<!--- 「部門コードTOボタン」ボタン --->
												<!--- 「部門名to」テキストボックスリードオンリー --->
												<td colspan="3">
													<span class="icon-in"><md:MDTextBox ID="Bumon_cd_from" CssClass="inpSerch inpBumon" runat="server"></md:MDTextBox><input type="button" id="Btnbumon_cd_from" name="Btnbumon_cd_from" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="Bumon_nm_from" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
													<span class="label-fromto">～</span>
													<span class="icon-in"><md:MDTextBox ID="Bumon_cd_to" CssClass="inpSerch inpBumon" runat="server"></md:MDTextBox><input type="button" id="Btnbumon_cd_to" name="Btnbumon_cd_to" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="Bumon_nm_to" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
												</td>
												<th>
													<span class="tbl-hdg"><asp:Label ID="Henpin_kakutei_ymd_from_lbl" runat="server">返品確定日</asp:Label></span>
												</th>
												<!--- 「返品確定日from」一行テキストボックス（セパレート日付以外） --->
												<!--- 「返品確定日to」一行テキストボックス（セパレート日付以外） --->
												<td>
													<span class="icon-in"><md:MDTextBox ID="Henpin_kakutei_ymd_from" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span><span class="label-fromto">～</span><span class="icon-in"><md:MDTextBox ID="Henpin_kakutei_ymd_to" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span>
												</td>
											</tr>
											<tr>
												<th>
													<span class="tbl-hdg"><asp:Label ID="Add_ymd_from_lbl" runat="server">登録日</asp:Label></span>
												</th>
												<!--- 「登録日from」一行テキストボックス（セパレート日付以外） --->
												<!--- 「登録日to」一行テキストボックス（セパレート日付以外） --->
												<td>
													<span class="icon-in"><md:MDTextBox ID="Add_ymd_from" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span><span class="label-fromto">～</span><span class="icon-in"><md:MDTextBox ID="Add_ymd_to" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span>
												</td>
												<th>
													<span class="tbl-hdg"><asp:Label ID="Nyuryokutan_cd_lbl" runat="server">入力担当者</asp:Label></span>
												</th>
												<!--- 「入力担当者コード」一行テキストボックス（セパレート日付以外） --->
												<!--- 「入力担当者コードボタン」ボタン --->
												<!--- 「入力担当者名称」テキストボックスリードオンリー --->
												<td>
													<span class="icon-in">
														<md:MDTextBox ID="Nyuryokutan_cd" CssClass="inpSerch inpTanto" runat="server"></md:MDTextBox>
														<input type="button" id="Btnnyuryokutanto_cd" name="Btnnyuryokutanto_cd" value="" runat="server" class="icon-search"/>
													</span><asp:TextBox ID="Nyuryokutan_nm" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
												</td>
												<th>
													<span class="tbl-hdg"><asp:Label ID="Kakuteitan_cd_lbl" runat="server">確定担当者</asp:Label></span>
												</th>
												<!--- 「確定担当者コード」一行テキストボックス（セパレート日付以外） --->
												<!--- 「確定担当者コードボタン」ボタン --->
												<!--- 「確定担当者名称」テキストボックスリードオンリー --->
												<td>
													<span class="icon-in">
														<md:MDTextBox ID="Kakuteitan_cd" CssClass="inpSerch inpTanto" runat="server"></md:MDTextBox>
														<input type="button" id="Btnkakuteitanto_cd" name="Btnkakuteitanto_cd" value="" runat="server" class="icon-search"/>
													</span><asp:TextBox ID="Kakuteitan_nm" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<th>
													<span class="tbl-hdg"><asp:Label ID="Henpin_riyu_lbl" runat="server">返品理由</asp:Label></span>
												</th>
												<td>
													<!--- 「返品理由」ドロップダウンリスト --->
													<md:MDConditionDDList ID="Henpin_riyu" ConditionName="henpin_riyu_kbn" CssClass="slt-ddl slt-henpinriyu" runat="server"></md:MDConditionDDList>
													<span class="select-arrow"></span>
												</td>
												<th>
													<span class="tbl-hdg"><asp:Label ID="Old_jisya_hbn_lbl" runat="server">自社品番</asp:Label></span>
												</th>
												<!--- 「旧自社品番」一行テキストボックス（セパレート日付以外） --->
												<!--- 「メーカー品番」テキストボックスリードオンリー --->
												<td colspan="3">
													<md:MDTextBox ID="Old_jisya_hbn" CssClass="inpJishahin10" runat="server"></md:MDTextBox>
													<asp:TextBox ID="Maker_hbn" CssClass="inpReadonlyLeft inpMkhin" runat="server"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<th class="last">
													<span class="tbl-hdg"><asp:Label ID="Scan_cd_lbl" runat="server">ｽｷｬﾝｺｰﾄﾞ</asp:Label></span>
												</th>
												<!--- 「スキャンコード」一行テキストボックス（セパレート日付以外） --->
												<td class="last" colspan="5">
													<md:MDTextBox ID="Scan_cd" CssClass="inpScanHdg" runat="server"></md:MDTextBox>
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
				<!------------------------------------------
					□明細ボタン部
				-------------------------------------------->
				<!-- button -->
				<div id="str-btn-area" class="str-btn-utility">
					<div id="meisaiBtnArea" class="inner pad0" runat="server">
					<ul>
						<!--明細制御系ボタンを配置する場合はこのulタグの中-->
					</ul>
					<ul>
						<!--帳票／CSV系ボタンを配置する場合はこのulタグの中-->
						<!--- 「ボタン印刷」ボタン --->
						<li><span><label><input type="button" id="Btnprint" value="" onserverclick="OnBTNPRINT_FRM" runat="server" class="icon-utility-04"/>印刷</label></span><li>
					</ul>
					<!-- /meisaiBtnArea --></div>
				<!-- /utility --></div>

				<!------------------------------------------
					□明細部
				-------------------------------------------->

				<div class="inner">
					<!---<div id="str-pager-top" class="str-pager-01">--->
		
						<!--- 件数表示部 --->
						<!--<p><adv:PageInfo ID="M1PageInfo" runat="server"></adv:PageInfo></p>-->
						<!--- ページャーを配置する場合はこの中 --->
		
					<!-- /str-pager-01 --><!---</div>--->
					<!--一覧-->
					<div class="str-result-01">
					<%-- 明細ヘッダ --%>
						<div class="str-result-hdg-01">
							<div class="col1 col_2dan">
								<asp:Label ID="M1rowno_lbl" runat="server">No.</asp:Label>
							</div>
							<div class="col2">
								<div><asp:Label ID="M1bumon_cd_bo1_lbl" runat="server">部門</asp:Label></div>
								<div><asp:Label ID="M1siiresaki_cd_lbl" runat="server">仕入先</asp:Label></div>
							</div>
							<div class="col3 col_2dan">
								<asp:Label ID="M1burando_nm_lbl" runat="server">ブランド</asp:Label>
							</div>
							<div class="col4">
								<div><asp:Label ID="M1henpin_kakutei_ymd_lbl" runat="server">返品確定日</asp:Label></div>
								<div><asp:Label ID="M1add_ymd_lbl" runat="server">登録日</asp:Label></div>
							</div>
							<div class="col5">
								<div><asp:Label ID="M1denpyo_bango_lbl" runat="server">伝票番号</asp:Label></div>
								<div><asp:Label ID="M1kanri_no_lbl" runat="server">管理番号</asp:Label></div>
							</div>
							<div class="col6">
								<div><asp:Label ID="M1siji_bango_lbl" runat="server">指示番号</asp:Label></div>
								<div><asp:Label ID="M1motodenpyo_bango_lbl" runat="server">元伝票番号</asp:Label></div>
							</div>
							<div class="col7">
								<div><asp:Label ID="M1itemsu_lbl" runat="server">数量</asp:Label></div>
								<div><asp:Label ID="M1genkakin_lbl" runat="server">原価金額</asp:Label></div>
							</div>
							<div class="col8">
								<div><asp:Label ID="M1nyuryokutan_nm_lbl" runat="server">入力担当者</asp:Label></div>
								<div><asp:Label ID="M1kakuteitan_nm_lbl" runat="server">確定担当者</asp:Label></div>
							</div>
							<div class="col9">
								<div><asp:Label ID="M1henpin_riyu_nm_lbl" runat="server">返品理由</asp:Label></div>
								<div><asp:Label ID="M1denpyo_jyotainm_lbl" runat="server">伝票状態</asp:Label></div>
							</div>
							<div class="col10 col_2dan">
								<asp:Label ID="M1syorinm_lbl" runat="server">処理</asp:Label>
							</div>
							<div class="col11 col_2dan">
								<asp:Label ID="M1syoriymd_lbl" runat="server">処理日</asp:Label>
							</div>
							<div class="col12 col_2dan">
								<asp:Label ID="M1syori_tm_lbl" runat="server">処理時間</asp:Label>
							</div>
							<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
							<div style="display:none">
								<asp:Label ID="M1bumonkana_nm_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1siiresaki_ryaku_nm_lbl" runat="server"></asp:Label>
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
											<asp:TextBox ID="M1rowno" CssClass="inpReadonlyRight inpRONum3" runat="server"></asp:TextBox>
										</div>
										<div class="col2 detail_left">
											<div>
												<!--- 「ｍ１部門コード」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1bumon_cd_bo1" CssClass="inpReadonlyLeft inpRONum3" runat="server"></asp:TextBox>
												<!--- 「ｍ１部門カナ名」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1bumonkana_nm" CssClass="inpReadonlyLeft inpRORightNm inpROHankaku12 tooltip" runat="server"></asp:TextBox>
											</div>
											<div>
												<!--- 「ｍ１仕入先コード」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1siiresaki_cd" CssClass="inpReadonlyLeft inpRONum4" runat="server"></asp:TextBox>
												<!--- 「ｍ１仕入先略式名称」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1siiresaki_ryaku_nm" CssClass="inpReadonlyLeft inpRORightNm inpROZenkaku10 tooltip" runat="server"></asp:TextBox>
											</div>
										</div>
										<div class="col3 col_2dan detail_left">
											<!--- 「ｍ１ブランド名」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1burando_nm" CssClass="inpReadonlyLeft inpROHankaku12 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col4 detail_center">
											<div>
												<!--- 「ｍ１返品確定日」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1henpin_kakutei_ymd" CssClass="inpReadonlyCenter inpRODate" runat="server"></asp:TextBox>
											</div>
											<div>
												<!--- 「ｍ１登録日」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1add_ymd" CssClass="inpReadonlyCenter inpRODate" runat="server"></asp:TextBox>
											</div>
										</div>
										<div class="col5 detail_center">
											<div>
												<!--- 「Ｍ１伝票番号リンク」ボタン --->
												<input type="button" id="M1denpyo_bango" value="伝票番号" onserverclick="OnM1DENPYO_BANGO_FRM" runat="server" class="meisaiLink"/>
											</div>
											<div>
												<!--- 「Ｍ１管理番号リンク」ボタン --->
												<input type="button" id="M1kanri_no" value="管理番号" onserverclick="OnM1KANRI_NO_FRM" runat="server" class="meisaiLink"/>
											</div>
										</div>
										<div class="col6 detail_center">
											<div>
												<!--- 「ｍ１指示番号」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1siji_bango" CssClass="inpReadonlyCenter inpRONum10" runat="server"></asp:TextBox>
											</div>
											<div>
												<!--- 「ｍ１元伝票番号」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1motodenpyo_bango" CssClass="inpReadonlyCenter inpRONum6" runat="server"></asp:TextBox>
											</div>
										</div>
										<div class="col7 detail_right">
											<div>
												<!--- 「ｍ１数量」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1itemsu" CssClass="inpReadonlyRight inpRONumCma8" runat="server"></asp:TextBox>
											</div>
											<div>
												<!--- 「ｍ１原価金額」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1genkakin" CssClass="inpReadonlyRight inpRONumCma9" runat="server"></asp:TextBox>
											</div>
										</div>
										<div class="col8 detail_left">
											<div>
												<!--- 「ｍ１入力担当者名称」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1nyuryokutan_nm" CssClass="inpReadonlyLeft inpROZenkaku10 tooltip" runat="server"></asp:TextBox>
											</div>
											<div>
												<!--- 「ｍ１確定担当者名称」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1kakuteitan_nm" CssClass="inpReadonlyLeft inpROZenkaku10 tooltip" runat="server"></asp:TextBox>
											</div>
										</div>
										<div class="col9 detail_left">
											<div>
												<!--- 「ｍ１返品理由名称」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1henpin_riyu_nm" CssClass="inpReadonlyLeft inpROZenkaku4 tooltip" runat="server"></asp:TextBox>
											</div>
											<div>
												<!--- 「ｍ１伝票状態名称」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1denpyo_jyotainm" CssClass="inpReadonlyLeft inpROZenkaku6 tooltip" runat="server"></asp:TextBox>
											</div>
										</div>
										<div class="col10 col_2dan detail_left">
											<!--- 「ｍ１処理名称」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1syorinm" CssClass="inpReadonlyLeft inpROZenkaku4" runat="server"></asp:TextBox>
										</div>
										<div class="col11 col_2dan detail_center">
											<!--- 「ｍ１処理日」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1syoriymd" CssClass="inpReadonlyCenter inpRODate" runat="server"></asp:TextBox>
										</div>
										<div class="col12 col_2dan detail_center">
											<!--- 「ｍ１処理時間」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1syori_tm" CssClass="inpReadonlyCenter inpROTime" runat="server"></asp:TextBox>
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
					<div id="str-pager-bottom" class="str-pager-01 pad0 heightZero">
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
			<asp:Label ID="Head_tenpo_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Head_tenpo_cd_lbl" runat="server"></asp:Label>
			<asp:Label ID="Head_tenpo_cd_Req" runat="server" CssClass="required">*</asp:Label>

			<asp:Label ID="Denpyo_bango_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Motodenpyo_bango_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Siji_bango_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Siiresaki_ryaku_nm_lbl" runat="server"></asp:Label>

			<asp:Label ID="Bumon_nm_from_lbl" runat="server"></asp:Label>
			<asp:Label ID="Bumon_cd_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Bumon_nm_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Henpin_kakutei_ymd_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Add_ymd_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Nyuryokutan_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Kakuteitan_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Maker_hbn_lbl" runat="server"></asp:Label>
			<asp:Label ID="Searchcnt_lbl" runat="server"></asp:Label>
		</div>
	
	</form>
</body>
</html>

