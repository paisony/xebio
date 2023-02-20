<%@ Page language="c#" CodeFile="te130f01.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Te130p01.Page.Te130f01Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">企業間仕入照会</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="te130p01" FormId="te130f01" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/te130f01.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="te130p01" FormId="te130f01" runat="server" />

	<!-- Js業務部品のインポート --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02001.js" charset="UTF-8"></script><!-- 店舗検索 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02002.js" charset="UTF-8"></script><!-- 仕入先マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02003.js" charset="UTF-8"></script><!-- 発注マスタ取得(自社品番) -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02004.js" charset="UTF-8"></script><!-- 発注マスタ取得(スキャンコード) -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02005.js" charset="UTF-8"></script><!-- 担当者マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02006.js" charset="UTF-8"></script><!-- 会社検索 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02010.js" charset="UTF-8"></script><!-- 部門マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02026.js" charset="UTF-8"></script><!-- 店舗検索(全企業) -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05001.js" charset="UTF-8"></script><!-- 自社品番丸め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05002.js" charset="UTF-8"></script><!-- スキャンコード丸め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script><!-- 0埋め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05009.js" charset="UTF-8"></script><!-- 指示番号丸め処理(返品用) -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05011.js" charset="UTF-8"></script><!-- FROM-TOコピー処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05014.js" charset="UTF-8"></script><!-- 名称取得拡張 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05015.js" charset="UTF-8"></script><!-- 項目制御処理 -->

	<!-- 業務共通コントロールのインポート-->
	<%@ Register TagPrefix="uc" TagName="common" Src="~/pjcommon/businessCommon/usercontrol/boCommonControl.ascx" %>
</head>

<body>
	<form id="Te130f01" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">				
			<uc:Header ID="header" runat="server" PgId="te130p01" PgName="企業間仕入照会" FormId="te130f01" FormName="企業間仕入照会 一覧" ></uc:Header>
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
					<md:MDTextBox ID="Head_tenpo_cd" CssClass="inpSerch inpHeaderTenpo" runat="server"></md:MDTextBox>
					<input type="button" id="Btnheadtenpocd" name="Btnheadtenpocd" value="" runat="server" class="icon-search"/>
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
					<p id="list-search"></p>
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
													<span class="tbl-hdg">
														<asp:Label ID="Denpyo_jyotai_lbl" runat="server">伝票状態</asp:Label>
													</span>
												</th>
												<td>
													<!--- 「伝票状態」ドロップダウンリスト --->
													<md:MDConditionDDList ID="Denpyo_jyotai" ConditionName="kigyokan_denpyo_jotai" CssClass="slt-denpyo" runat="server"></md:MDConditionDDList>
													<span class="select-arrow"></span>
												</td>
												<th >
													<span class="tbl-hdg">
														<asp:Label ID="Denpyo_bango_from_lbl" runat="server">伝票番号</asp:Label>
													</span>
												</th>
												<td>
													<!--- 「伝票番号ｆｒｏｍ」一行テキストボックス（セパレート日付以外） --->
													<md:MDTextBox ID="Denpyo_bango_from" CssClass="inpDenpyo" runat="server"></md:MDTextBox>
														<span class="label-fromto">～</span>
													<md:MDTextBox ID="Denpyo_bango_to" CssClass="inpDenpyo" runat="server"></md:MDTextBox>
												</td>
												<th >
													<span class="tbl-hdg">
														<asp:Label ID="Idodenpyo_bango_from_lbl" runat="server">移動伝票番号ＦＲＯＭ</asp:Label>
													</span>
												</th>
												<td>
												<!--- 「移動伝票番号ｆｒｏｍ」一行テキストボックス（セパレート日付以外） --->
													<md:MDTextBox ID="Idodenpyo_bango_from" CssClass="inpDenpyo" runat="server"></md:MDTextBox>
														<span class="label-fromto">～</span>
													<md:MDTextBox ID="Idodenpyo_bango_to" CssClass="inpDenpyo" runat="server"></md:MDTextBox>
												</td>
											</tr>
											<tr>
												<th >
													<span class="tbl-hdg">
														<asp:Label ID="Siji_bango_from_lbl" runat="server">指示番号ＦＲＯＭ</asp:Label>
													</span>
												</th>
												<td colspan="5">
													<label>
													<!--- 「指示番号ｆｒｏｍ」一行テキストボックス（セパレート日付以外） --->
														<md:MDTextBox ID="Siji_bango_from" CssClass="inpIdoSijiNo" runat="server"></md:MDTextBox>
															<span class="label-fromto">～</span>
														<md:MDTextBox ID="Siji_bango_to" CssClass="inpIdoSijiNo" runat="server"></md:MDTextBox>
													</label>
												</td>
											</tr>
											<tr>
												<th>
													<span class="tbl-hdg">
														<asp:Label ID="Jyuryokaisya_cd_lbl" runat="server">入荷会社</asp:Label>
													</span>
												</th>
												<td>
													<!--- 「入荷会社コード」テキストボックスリードオンリー --->
													<asp:TextBox ID="Jyuryokaisya_cd" CssClass="inpReadonlyLeft inpROHankaku2" runat="server"></asp:TextBox>
													<!--- 「入荷会社名称」テキストボックスリードオンリー --->
													<asp:TextBox ID="Nyukakaisya_nm" CssClass="inpReadonlyLeft" runat="server"></asp:TextBox>
												</td>
												<th >
													<span  class="tbl-hdg">
														<asp:Label ID="Jyuryoten_cd_lbl" runat="server">入荷店</asp:Label>
													</span>
												</th>
												<td>
													<!--- 「入荷店コード」一行テキストボックス（セパレート日付以外） --->
													<span class="icon-in"><md:MDTextBox ID="Jyuryoten_cd" CssClass="inpSerch inpTenpo" runat="server"></md:MDTextBox><input type="button" id="Btntenpocd" name="Btntenpocd" value="" runat="server" class="icon-search"/></span>
													<!--- 「入荷店名称」テキストボックスリードオンリー --->
													<asp:TextBox ID="Juryoten_nm" CssClass="inpReadonlyLeft" runat="server"></asp:TextBox>
												</td>
												<th>
													<span class="tbl-hdg">
														<asp:Label ID="Jyuryo_ymd_from_lbl" runat="server">入荷日ＦＲＯＭ</asp:Label>
													</span>
												</th>
												<td>
													<!--- 「入荷日ｆｒｏｍ」一行テキストボックス（セパレート日付以外） --->
													<label>
														<span class="icon-in">
															<md:MDTextBox ID="Jyuryo_ymd_from" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox><span class="label-fromto">～</span><md:MDTextBox ID="Jyuryo_ymd_to" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox>
														</span>
													</label>
												</td>
											</tr>
											<tr>
												<th>
													<span class="tbl-hdg">
														<asp:Label ID="Syukkakaisya_cd_lbl" runat="server">出荷会社</asp:Label>
													</span>
												</th>
												<td>
													<!--- 「出荷会社コード」一行テキストボックス（セパレート日付以外） --->
													<span class="icon-in"><md:MDTextBox ID="Syukkakaisya_cd" CssClass="inpSerch inpComp" runat="server"></md:MDTextBox><input type="button" id="Btnkaisha_cd" name="Btnkaisha_cd" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="Syukkakaisya_nm" CssClass="inpReadonlyLeft" runat="server"></asp:TextBox>
												</td>
												<th>
													<span class="tbl-hdg">
														<asp:Label ID="Syukkaten_cd_lbl" runat="server">出荷店</asp:Label>
													</span>
												</th>
												<td>
													<!--- 「出荷店コード」一行テキストボックス（セパレート日付以外） --->
													<span class="icon-in"><md:MDTextBox ID="Syukkaten_cd" CssClass="inpSerch inpTenpo" runat="server"></md:MDTextBox><input type="button" id="Btnsyukkatencd" name="Btnsyukkatencd" value="" runat="server" class="icon-search"/></span>
													<asp:TextBox ID="Syukkatenpo_nm" CssClass="inpReadonlyLeft" runat="server"></asp:TextBox>
												</td>
												<th>
													<span class="tbl-hdg">
														<asp:Label ID="Syukka_ymd_from_lbl" runat="server">出荷日ＦＲＯＭ</asp:Label>
													</span>
												</th>
												<td>
													<!--- 「出荷日ｆｒｏｍ」一行テキストボックス（セパレート日付以外） --->
													<label>
														<span class="icon-in">
															<md:MDTextBox ID="Syukka_ymd_from" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox><span class="label-fromto">～</span><md:MDTextBox ID="Syukka_ymd_to" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox>
														</span>
													</label>
												</td>
											</tr>
											<tr>
												<th  class ="last">
													<span class="tbl-hdg">
														<asp:Label ID="Old_jisya_hbn_lbl" runat="server">自社品番</asp:Label>
													</span>
												</th>
												<td colspan="3"  class ="last">
													<!--- 「旧自社品番」一行テキストボックス（セパレート日付以外） --->
													<md:MDTextBox ID="Old_jisya_hbn" CssClass="inpJishahin10" runat="server"></md:MDTextBox>
													<!--- 「メーカー品番」テキストボックスリードオンリー --->
													<asp:TextBox ID="Maker_hbn" CssClass="inpReadonlyLeft inpMkhin" runat="server"></asp:TextBox>
												</td>
												<th  class ="last">
													<span class="tbl-hdg">
														<asp:Label ID="Scan_cd_lbl" runat="server">スキャンコード</asp:Label>
													</span>
												</th>
												<td  class ="last">
													<!--- 「スキャンコード」一行テキストボックス（セパレート日付以外） --->
													<md:MDTextBox ID="Scan_cd" CssClass="inpScanHdg" runat="server"></md:MDTextBox>
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
								</div>
							</td>
						</tr>
					</table>
				<!-- /inner-02 --></div>
			<!-- /str-search-01 --></div>
			<!--- アコーディオン --->
			<div class = "trigger-search-01">
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
							<li><span id ="Btnprint_label"  runat="server"><label><input type="button" id="Btnprint" value="" onserverclick="OnBTNPRINT_FRM" runat="server" class="icon-utility-04"/>印刷</label></span></li>
							<!--- 「CSVボタン」ボタン --->
							<li><span  id ="Csvprint_label"  runat="server"><label><input type="button" id="Btncsv" value="CSV出力" onserverclick="OnBTNCSV_FRM" runat="server" class="icon-utility-05"/>CSV出力</label></span></li>
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
								<asp:Label ID="M1syukkakaisya_cd_lbl" runat="server">会社</asp:Label>
							</div>
							<div class="col3">
								<asp:Label ID="M1syukkaten_cd_lbl" runat="server">出荷店</asp:Label>
							</div>
							<div class="col4">
								<asp:Label ID="M1jyuryokaisya_cd_lbl" runat="server">会社</asp:Label>
							</div>
							<div class="col5">
								<asp:Label ID="M1jyuryoten_cd_lbl" runat="server">入荷店</asp:Label>
							</div>
							<div class="col6">
								<asp:Label ID="M1denpyo_bango_lbl" runat="server">伝票番号</asp:Label>
							</div>
							<div class="col7">
								<asp:Label ID="M1idodenpyo_bango_lbl" runat="server">移動伝票</asp:Label>
							</div>
							<div class="col8">
								<asp:Label ID="M1siji_bango_lbl" runat="server">指示番号</asp:Label>
							</div>
							<div class="col9">
								<asp:Label ID="M1syukka_ymd_lbl" runat="server">出荷日</asp:Label>
							</div>
							<div class="col10">
								<asp:Label ID="M1jyuryo_ymd_lbl" runat="server">入荷日</asp:Label>
							</div>
							<div class="col11">
								<asp:Label ID="M1nyukayotei_su_lbl" runat="server">予定数量</asp:Label>
							</div>
							<div class="col12">
								<asp:Label ID="M1nyukajisseki_su_lbl" runat="server">確定数量</asp:Label>
							</div>
							<div class="col13">
								<asp:Label ID="M1kyakucyu_lbl" runat="server">客注</asp:Label>
							</div>
							<div class="col14">
								<asp:Label ID="M1syorinm_lbl" runat="server">処理</asp:Label>
							</div>
							<div class="col15">
								<asp:Label ID="M1syori_ymd_lbl" runat="server">処理日</asp:Label>
							</div>
							<div class="col16">
								<asp:Label ID="M1syori_tm_lbl" runat="server">処理時間</asp:Label>
							</div>	
							<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
							<div style="display:none">
								<asp:Label ID="M1syukkatenpo_nm_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1juryoten_nm_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1selectorcheckbox_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1entersyoriflg_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1dtlirokbn_lbl" runat="server"></asp:Label>
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
											<!--- 「ｍ１行ｎｏ」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1rowno" CssClass="inpReadonlyRight inpRONum3" runat="server"></asp:TextBox>
										</div>
												<div class="col2 detail_center">
											<!--- 「ｍ１出荷会社コード」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1syukkakaisya_cd" CssClass="inpReadonlyCenter inpROHankaku2" runat="server"></asp:TextBox>
										</div>
												<div class="col3 detail_left">
											<!--- 「ｍ１出荷店コード」テキストボックスリードオンリー --->
											<!--- 「ｍ１出荷店舗名」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1syukkaten_cd" CssClass="inpReadonlyLeft inpRONum4" runat="server"></asp:TextBox><asp:TextBox ID="M1syukkatenpo_nm" CssClass="inpReadonlyLeft inpRORightNm inpROZenkaku10 tooltip" runat="server"></asp:TextBox>
										</div>
												<div class="col4 detail_center">
											<!--- 「ｍ１入荷会社コード」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1jyuryokaisya_cd" CssClass="inpReadonlyCenter inpROHankaku2" runat="server"></asp:TextBox>
										</div>
												<div class="col5 detail_left">
											<!--- 「ｍ１入荷店コード」テキストボックスリードオンリー --->
											<!--- 「ｍ１入荷店名称」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1jyuryoten_cd" CssClass="inpReadonlyLeft inpRONum4" runat="server"></asp:TextBox><asp:TextBox ID="M1juryoten_nm" CssClass="inpReadonlyLeft inpRORightNm inpROZenkaku10 tooltip" runat="server"></asp:TextBox>
										</div>
												<div class="col6 detail_center">
											<!--- 「Ｍ１伝票番号リンク」ボタン --->
											<input type="button" id="M1denpyo_bango" value="伝票番号" onserverclick="OnM1DENPYO_BANGO_FRM" runat="server" class="meisaiLink"/>
										</div>
												<div class="col7 detail_center">
											<!--- 「ｍ１移動伝票番号」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1idodenpyo_bango" CssClass="inpReadonly inpRONum6" runat="server"></asp:TextBox>
										</div>
												<div class="col8 detail_center">
											<!--- 「ｍ１指示番号」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1siji_bango" CssClass="inpReadonlyLeft inpRONum10" runat="server"></asp:TextBox>
										</div>
												<div class="col9 detail_center">
											<!--- 「ｍ１出荷日」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1syukka_ymd" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox>
										</div>
												<div class="col10 detail_center">
											<!--- 「ｍ１入荷日」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1jyuryo_ymd" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox>
										</div>
												<div class="col11 detail_right">
											<!--- 「ｍ１入荷予定数」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1nyukayotei_su" CssClass="inpReadonlyRight inpRONumCma6" runat="server"></asp:TextBox>
										</div>
												<div class="col12 detail_right">
											<!--- 「ｍ１入荷実績数」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1nyukajisseki_su" CssClass="inpReadonlyRight inpRONumCma6" runat="server"></asp:TextBox>
										</div>
												<div class="col13 detail_center">
											<!--- 「ｍ１客注」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1kyakucyu" CssClass="inpReadonlyLeft inpROZenkaku1" runat="server"></asp:TextBox>
										</div>
												<div class="col14 detail_left">
											<!--- 「ｍ１処理名称」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1syorinm" CssClass="inpReadonlyLeft inpROZenkaku4 tooltip" runat="server"></asp:TextBox>
										</div>
												<div class="col15 detail_center">
											<!--- 「ｍ１処理日付」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1syori_ymd" CssClass="inpReadonlyCenter inpRODate" runat="server"></asp:TextBox>
										</div>
												<div class="col16 detail_center">
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
					<div id="str-pager-bottom" class= "footer str-pager-01 pad0" >
						<!-- ページャ下部にボタンを配置する場合はこの中 -->
						<p><font color="black">※処理・処理日・処理時間は履歴選択時のみ表示</font></p>	
					<!-- /str-pager-01 --></div>
				<!-- /str-wrap-result --></div>
			<!-- /str-wrap-result --></div>	
		
			<!-- 画面上隠しエレメントを格納するエリア-->
			<div id="hiddenElements" style="display:none" runat="server">
				<asp:Label ID="Head_tenpo_cd_lbl" runat="server">店舗</asp:Label>
				<asp:Label ID="Head_tenpo_cd_Req" runat="server" CssClass="required">*</asp:Label>
				<asp:Label ID="Head_tenpo_nm_lbl" runat="server">ヘッダ店舗名</asp:Label>
				<asp:Label ID="Denpyo_bango_to_lbl" runat="server">伝票番号ＴＯ</asp:Label>
				<asp:Label ID="Idodenpyo_bango_to_lbl" runat="server">移動伝票番号ＴＯ</asp:Label>
				<asp:Label ID="Siji_bango_to_lbl" runat="server">指示番号ＴＯ</asp:Label>
				<asp:Label ID="Nyukakaisya_nm_lbl" runat="server">入荷会社</asp:Label>
				<asp:Label ID="Juryoten_nm_lbl" runat="server"></asp:Label>
				<asp:Label ID="Jyuryo_ymd_to_lbl" runat="server">入荷日ＴＯ</asp:Label>
				<asp:Label ID="Syukkakaisya_nm_lbl" runat="server"></asp:Label>
				<asp:Label ID="Syukkatenpo_nm_lbl" runat="server"></asp:Label>
				<asp:Label ID="Syukka_ymd_to_lbl" runat="server">出荷日ＴＯ</asp:Label>
				<asp:Label ID="Maker_hbn_lbl" runat="server"></asp:Label>
				<asp:Label ID="Searchcnt_lbl" runat="server"></asp:Label>
			</div>
		<!-- search-result --></div>
	</form>
</body>
</html>

