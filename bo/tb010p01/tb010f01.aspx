<%@ Page language="c#" CodeFile="tb010f01.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Tb010p01.Page.Tb010f01Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">仕入入荷検索</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="tb010p01" FormId="tb010f01" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/tb010f01.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="tb010p01" FormId="tb010f01" runat="server" />
	
	<!----->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02001.js" charset="UTF-8"></script><!-- 店舗検索 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02002.js" charset="UTF-8"></script><!-- 仕入先マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02003.js" charset="UTF-8"></script><!-- 発注マスタ取得(自社品番) -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02004.js" charset="UTF-8"></script><!-- 発注マスタ取得(スキャンコード) -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02010.js" charset="UTF-8"></script><!-- 部門マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05001.js" charset="UTF-8"></script><!-- 自社品番丸め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05002.js" charset="UTF-8"></script><!-- スキャンコード丸め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05011.js" charset="UTF-8"></script><!-- FROM-TOコピー処理 -->

	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script><!-- 0埋め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05014.js" charset="UTF-8"></script><!-- 名称取得拡張 -->

	<!-- 業務共通コントロールのインポート-->
	<%@ Register TagPrefix="uc" TagName="common" Src="~/pjcommon/businessCommon/usercontrol/boCommonControl.ascx" %>
</head>

<body>
	<form id="Tb010f01" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="tb010p01" PgName="仕入入荷検索" FormId="tb010f01" FormName="仕入入荷検索 一覧" ></uc:Header>
			
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
			<div id="tab1" class="str-tab-cont"></div>
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
											<tbody>
												<tr>
													<th><span class="tbl-hdg"><asp:Label ID="Denpyo_jyotai_lbl" runat="server">伝票状態</asp:Label><span class="required2">*</span></span></th>
													<!--- 「伝票状態」ドロップダウンリスト --->
													<td>
														<md:MDConditionDDList ID="Denpyo_jyotai" ConditionName="siiire_denpyo_jotai" CssClass="slt-kakutei" runat="server"></md:MDConditionDDList>
														<span class="select-arrow"></span>
													</td>
													<th>
														<span class="tbl-hdg"><asp:Label ID="Nyukayotei_ymd_from_lbl" runat="server">入荷予定日</asp:Label></span>
													</th>
													<!--- 「入荷予定日ｆｒｏｍ」一行テキストボックス（セパレート日付以外） --->
													<!--- 「入荷予定日ｔｏ」一行テキストボックス（セパレート日付以外） --->
													<td>
														<span class="icon-in"><md:MDTextBox ID="Nyukayotei_ymd_from" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span>
														<span class="label-fromto">～</span>
														<span class="icon-in"><md:MDTextBox ID="Nyukayotei_ymd_to" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span>
													</td>
													<th>
														<span class="tbl-hdg"><asp:Label ID="Siire_kakutei_ymd_from_lbl" runat="server">仕入確定日</asp:Label></span>
													</th>
													<!--- 「仕入確定日ｆｒｏｍ」一行テキストボックス（セパレート日付以外） --->
													<!--- 「仕入確定日ｔｏ」一行テキストボックス（セパレート日付以外） --->
													<td>
														<span class="icon-in"><md:MDTextBox ID="Siire_kakutei_ymd_from" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span>
														<span class="label-fromto">～</span>
														<span class="icon-in"><md:MDTextBox ID="Siire_kakutei_ymd_to" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span>
													</td>
												</tr>
												<tr>
													<th>
														<span class="tbl-hdg"><asp:Label ID="Siiresaki_cd_lbl" runat="server">仕入先</asp:Label><span class="required2">*</span></span>
													</th>
													<!--- 「仕入先コード」一行テキストボックス（セパレート日付以外） --->
													<!--- 「仕入先コードボタン」ボタン --->
													<!--- 「仕入先名称」テキストボックスリードオンリー --->
													<td>
														<span class="icon-in"><md:MDTextBox ID="Siiresaki_cd" CssClass="inpSerch inpShiire" runat="server"></md:MDTextBox><input type="button" id="Btnsiiresaki_cd" name="Btnsiiresaki_cd" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="Siiresaki_ryaku_nm" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
													</td>
													<th>
														<span class="tbl-hdg"><asp:Label ID="Bumon_cd_from_lbl" runat="server">部門</asp:Label></span>
													</th>
													<!--- 「部門コードｆｒｏｍ」一行テキストボックス（セパレート日付以外） --->
													<!--- 「部門コードＦＲＯＭボタン」ボタン --->
													<!--- 「部門名ｆｒｏｍ」テキストボックスリードオンリー --->
													<!--- 「部門コードｔｏ」一行テキストボックス（セパレート日付以外） --->
													<!--- 「部門コードＴＯボタン」ボタン --->
													<!--- 「部門名ｔｏ」テキストボックスリードオンリー --->
													<td colspan="3">
														<span class="icon-in"><md:MDTextBox ID="Bumon_cd_from" CssClass="inpSerch inpBumon" runat="server"></md:MDTextBox><input type="button" id="Btnbumon_cd_from" name="Btnbumon_cd_from" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="Bumon_nm_from" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
														<span class="label-fromto">～</span>
														<span class="icon-in"><md:MDTextBox ID="Bumon_cd_to" CssClass="inpSerch inpBumon" runat="server"></md:MDTextBox><input type="button" id="Btnbumon_cdto" name="Btnbumon_cdto" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="Bumon_nm_to" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
													</td>
												</tr>
												<tr>
													<th>
														<span class="tbl-hdg"><asp:Label ID="Denpyo_bango_from_lbl" runat="server">伝票番号</asp:Label></span>
													</th>
													<!--- 「伝票番号ｆｒｏｍ」一行テキストボックス（セパレート日付以外） --->
													<!--- 「伝票番号ｔｏ」一行テキストボックス（セパレート日付以外） --->
													<td>
														<md:MDTextBox ID="Denpyo_bango_from" CssClass="inpDenpyo" runat="server"></md:MDTextBox>
														<span class="label-fromto">～</span>
														<md:MDTextBox ID="Denpyo_bango_to" CssClass="inpDenpyo" runat="server"></md:MDTextBox>
													</td>
													<th>
														<span class="tbl-hdg"><asp:Label ID="Motodenpyo_bango_from_lbl" runat="server">元伝票番号</asp:Label></span>
													</th>
													<!--- 「元伝票番号ｆｒｏｍ」一行テキストボックス（セパレート日付以外） --->
													<!--- 「元伝票番号ｔｏ」一行テキストボックス（セパレート日付以外） --->
													<td colspan="3">
														<md:MDTextBox ID="Motodenpyo_bango_from" CssClass="inpDenpyo" runat="server"></md:MDTextBox>
														<span class="label-fromto">～</span>
														<md:MDTextBox ID="Motodenpyo_bango_to" CssClass="inpDenpyo" runat="server"></md:MDTextBox>
													</td>
												</tr>
												<tr>
													<th class="last">
														<span class="tbl-hdg"><asp:Label ID="Old_jisya_hbn_lbl" runat="server">自社品番</asp:Label></span>
													</th>
													<!--- 「旧自社品番」一行テキストボックス（セパレート日付以外） --->
													<!--- 「メーカー品番」テキストボックスリードオンリー --->
													<td class="last" colspan="3">
														<md:MDTextBox ID="Old_jisya_hbn" CssClass="inpJishahin10" runat="server"></md:MDTextBox><asp:TextBox ID="Maker_hbn" CssClass="inpReadonlyLeft inpMkhin" runat="server"></asp:TextBox>
													</td>
													<th class="last">
														<span class="tbl-hdg"><asp:Label ID="Scan_cd_lbl" runat="server">ｽｷｬﾝｺｰﾄﾞ</asp:Label></span>
													</th>
													<!--- 「スキャンコード」一行テキストボックス（セパレート日付以外） --->
													<td class="last">
														<md:MDTextBox ID="Scan_cd" CssClass="inpScan" runat="server"></md:MDTextBox>
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
							<!--- 「CSVボタン」ボタン --->
							<li><span><label><input type="button" id="Btncsv" value="" onserverclick="OnBTNCSV_FRM" runat="server" class="icon-utility-05"/>CSV出力</label></span></li>
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
								<asp:Label ID="M1bumon_cd_lbl" runat="server">部門</asp:Label>
								</div>
							<div class="col3">
								<asp:Label ID="M1siiresaki_cd_lbl" runat="server">仕入先</asp:Label>
							</div>
							<div class="col4">
								<asp:Label ID="M1nyukayotei_ymd_lbl" runat="server">入荷予定日</asp:Label>
							</div>
							<div class="col5">
								<asp:Label ID="M1denpyo_bango_lbl" runat="server">伝票</asp:Label>
							</div>
							<div class="col6">
								<asp:Label ID="M1motodenpyo_bango_lbl" runat="server">元伝票</asp:Label>
							</div>
							<div class="col7">
								<asp:Label ID="M1nohin_su_lbl" runat="server">納品数</asp:Label>
							</div>
							<div class="col8">
								<asp:Label ID="M1kensu_lbl" runat="server">検数</asp:Label>
							</div>
							<div class="col9">
								<asp:Label ID="M1genka_kin_lbl" runat="server">原価金額</asp:Label>
							</div>
							<div class="col10">
								<asp:Label ID="M1siire_kakutei_ymd_lbl" runat="server">仕入確定日</asp:Label>
							</div>
							<div class="col11">
								<asp:Label ID="M1denpyo_jyotainm_lbl" runat="server">伝票状態</asp:Label>
							</div>
							<div class="col12">
								<asp:Label ID="M1syorinm_lbl" runat="server">処理</asp:Label>
							</div>
							<div class="col13">
								<asp:Label ID="M1syoriymd_lbl" runat="server">処理日</asp:Label>
							</div>
							<div class="col14">
								<asp:Label ID="M1syori_tm_lbl" runat="server">処理時間</asp:Label>
							</div>
							
							<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
							<div style="display:none">
								<div class="col3">
									<asp:Label ID="M1bumonkana_nm_lbl" runat="server"></asp:Label>
								</div>
								<div class="col5">
									<asp:Label ID="M1siiresaki_ryaku_nm_lbl" runat="server"></asp:Label>
								</div>
								<div class="col17">
									<asp:Label ID="M1selectorcheckbox_lbl" runat="server"></asp:Label>
								</div>
								<div class="col18">
									<asp:Label ID="M1entersyoriflg_lbl" runat="server"></asp:Label>
								</div>
								<div class="col19">
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
										<div class="col1 detail_right">
											<!--- 「ｍ１ｎｏ」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1rowno" CssClass="inpReadonlyRight inpRONum3" runat="server"></asp:TextBox>
										</div>
										<div class="col2 detail_left">
											<!--- 「ｍ１部門コード」テキストボックスリードオンリー --->
											<!--- 「ｍ１部門カナ名」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1bumon_cd" CssClass="inpReadonlyRight inpRONum3" runat="server"></asp:TextBox><asp:TextBox ID="M1bumonkana_nm" CssClass="inpReadonlyLeft inpRORightNm inpROHankaku12 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col3 detail_left">
											<!--- 「ｍ１仕入先コード」テキストボックスリードオンリー --->
											<!--- 「ｍ１仕入先名称」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1siiresaki_cd" CssClass="inpReadonlyRight inpRONum4" runat="server"></asp:TextBox><asp:TextBox ID="M1siiresaki_ryaku_nm" CssClass="inpReadonlyLeft inpRORightNm inpROZenkaku10 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col4 detail_center">
											<!--- 「ｍ１入荷予定日」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1nyukayotei_ymd" CssClass="inpReadonlyCenter inpRODate" runat="server"></asp:TextBox>
										</div>
										<div class="col5 detail_center">
											<!--- 「Ｍ１伝票番号リンク」ボタン --->
											<input type="button" id="M1denpyo_bango" value="伝票" onserverclick="OnM1DENPYO_BANGO_FRM" runat="server" class="meisaiLink"/>
										</div>
										<div class="col6 detail_center">
											<!--- 「ｍ１元伝票番号」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1motodenpyo_bango" CssClass="inpReadonlyCenter inpRONum6" runat="server"></asp:TextBox>
										</div>
										<div class="col7 detail_right">
											<!--- 「ｍ１納品数」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1nohin_su" CssClass="inpReadonlyRight inpRONumCma9" runat="server"></asp:TextBox>
										</div>
										<div class="col8 detail_right">
											<!--- 「ｍ１検数」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1kensu" CssClass="inpReadonlyRight inpRONumCma9" runat="server"></asp:TextBox>
										</div>
										<div class="col9 detail_right">
											<!--- 「ｍ１原価金額」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1genka_kin" CssClass="inpReadonlyRight inpRONumCma9" runat="server"></asp:TextBox>
										</div>
										<div class="col10 detail_center">
											<!--- 「ｍ１仕入確定日」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1siire_kakutei_ymd" CssClass="inpReadonlyCenter inpRODate" runat="server"></asp:TextBox>
										</div>
										<div class="col11 detail_left">
											<!--- 「ｍ１伝票状態名称」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1denpyo_jyotainm" CssClass="inpReadonlyLeft inpROZenkaku5" runat="server"></asp:TextBox>
										</div>
										<div class="col12 detail_left">
											<!--- 「ｍ１処理名称」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1syorinm" CssClass="inpReadonlyLeft inpROZenkaku4" runat="server"></asp:TextBox>
										</div>
										<div class="col13 detail_center">
											<!--- 「ｍ１処理日」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1syoriymd" CssClass="inpReadonlyCenter inpRODate" runat="server"></asp:TextBox>
										</div>
										<div class="col14 detail_center">
											<!--- 「ｍ１処理時間」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1syori_tm" CssClass="inpReadonlyCenter inpROTime" runat="server"></asp:TextBox>
										</div>
										
										<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
										<div style="display:none">
											<div class="col17">
												<!--- 「ｍ１選択フラグ(隠し)」チェックボックス --->
												<adv:AdvancedCheckBox ID="M1selectorcheckbox" Text="" CssClass="" runat="server"></adv:AdvancedCheckBox>
											</div>
											<div class="col18">
												<!--- 「Ｍ１確定処理フラグ(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1entersyoriflg" runat="server"></asp:hiddenfield>
											</div>
											<div class="col19">
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
			<asp:Label ID="Head_tenpo_cd_Req" runat="server" CssClass="required">*</asp:Label>
			<asp:Label ID="Head_tenpo_nm_lbl" runat="server"></asp:Label>
			
			<asp:Label ID="Nyukayotei_ymd_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Siire_kakutei_ymd_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Siiresaki_ryaku_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Bumon_nm_from_lbl" runat="server"></asp:Label>
			<asp:Label ID="Bumon_cd_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Bumon_nm_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Denpyo_bango_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Motodenpyo_bango_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Maker_hbn_lbl" runat="server"></asp:Label>
			<asp:Label ID="Searchcnt_lbl" runat="server"></asp:Label>

			<!--- 「営業日（隠し）」隠しフィールド --->
			<asp:hiddenfield ID="Eigyo_ymd_hdn" runat="server"></asp:hiddenfield>
		</div>
	
	</form>
</body>
</html>

