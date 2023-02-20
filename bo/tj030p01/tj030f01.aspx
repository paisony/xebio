﻿<%@ Page language="c#" CodeFile="tj030f01.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Tj030p01.Page.Tj030f01Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">棚卸検索</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="tj030p01" FormId="tj030f01" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/tj030f01.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="tj030p01" FormId="tj030f01" runat="server" />

	<!-- Js業務部品のインポート --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02001.js" charset="UTF-8"></script><!-- 店舗検索 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02002.js" charset="UTF-8"></script><!-- 仕入先マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02003.js" charset="UTF-8"></script><!-- 発注マスタ取得(自社品番) -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02004.js" charset="UTF-8"></script><!-- 発注マスタ取得(スキャンコード) -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02005.js" charset="UTF-8"></script><!-- 担当者マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02010.js" charset="UTF-8"></script><!-- 部門マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02012.js" charset="UTF-8"></script><!-- 品種マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05001.js" charset="UTF-8"></script><!-- 自社品番丸め処理丸め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05002.js" charset="UTF-8"></script><!-- スキャンコード丸め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script><!-- 0埋め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05009.js" charset="UTF-8"></script><!-- 指示番号丸め処理(返品用) -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05011.js" charset="UTF-8"></script><!-- FROM-TOコピー処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05014.js" charset="UTF-8"></script><!-- 名称取得拡張 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05015.js" charset="UTF-8"></script><!-- 項目入力制御処理 -->

	<!-- 業務共通コントロールのインポート-->
	<%@ Register TagPrefix="uc" TagName="common" Src="~/pjcommon/businessCommon/usercontrol/boCommonControl.ascx" %>
</head>

<body>
	<form id="Tj030f01" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="tj030p01" PgName="棚卸検索(V)" FormId="tj030f01" FormName="棚卸検索 一覧" ></uc:Header>

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
						<!--- 「モード取消ボタン」リンク --->
						<a id="Btnmodedel" href="#tab11" class="" runat="server">取消</a>
					</li>
				</ul>
			</div>

			<div id="tab16" class="str-tab-cont"></div>
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
					<table class="search-table">
						<tr>
							<td class="search-table-tdleft">
								<div class="str-form-02">
									<div class="inner">
										<!--	<p class="required">*が付いている項目は必須入力になります。</p> -->
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
													<!--- 「フェイスnofrom」一行テキストボックス（セパレート日付以外） --->
													<!--- 「フェイスnoto」一行テキストボックス（セパレート日付以外） --->
													<th>
														<span class="tbl-hdg"><asp:Label ID="Face_no_from_lbl" runat="server">フェイスNo</asp:Label></span>
													</th>
													<td>
														<md:MDTextBox ID="Face_no_from" CssClass="inpFaceNo" runat="server"></md:MDTextBox><span class="label-fromto">～</span><md:MDTextBox ID="Face_no_to" CssClass="inpFaceNo" runat="server"></md:MDTextBox>
													</td>
													<!--- 「棚段from」一行テキストボックス（セパレート日付以外） --->
													<!--- 「棚段to」一行テキストボックス（セパレート日付以外） --->
													<th>
														<span class="tbl-hdg"><asp:Label ID="Tana_dan_from_lbl" runat="server">棚段</asp:Label></span>
													</th>
													<td>
														<md:MDTextBox ID="Tana_dan_from" CssClass="inpTanadan" runat="server"></md:MDTextBox><span class="label-fromto">～</span><md:MDTextBox ID="Tana_dan_to" CssClass="inpTanadan" runat="server"></md:MDTextBox>
													</td>
													<!--- 「店舗／業者区分」ドロップダウンリスト --->
													<th>
														<span class="tbl-hdg"><asp:Label ID="Tenpo_gyosya_kb_lbl" runat="server">店舗／業者</asp:Label></span>
													</th>
													<td>
														<md:MDConditionDDList ID="Tenpo_gyosya_kb" ConditionName="tenpo_gyosya_kbn" CssClass="slt-tengyo" runat="server"></md:MDConditionDDList>
														<span class="select-arrow"></span>
													</td>
												</tr>
												<tr>
													<!--- 「入力日from」一行テキストボックス（セパレート日付以外） --->
													<!--- 「入力日to」一行テキストボックス（セパレート日付以外） --->
													<th>
														<span class="tbl-hdg"><asp:Label ID="Nyuryoku_ymd_from_lbl" runat="server">入力日</asp:Label></span>
													</th>
													<td>
														<label><span class="icon-in"><md:MDTextBox ID="Nyuryoku_ymd_from" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span><span class="label-fromto">～</span><span class="icon-in"><md:MDTextBox ID="Nyuryoku_ymd_to" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span></label>
													</td>
													<!--- 「送信日from」一行テキストボックス（セパレート日付以外） --->
													<!--- 「送信日to」一行テキストボックス（セパレート日付以外） --->
													<th>
														<span class="tbl-hdg"><asp:Label ID="Sosin_ymd_from_lbl" runat="server">送信日</asp:Label></span>
													</th>
													<td>
														<label><span class="icon-in"><md:MDTextBox ID="Sosin_ymd_from" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span><span class="label-fromto">～</span><span class="icon-in"><md:MDTextBox ID="Sosin_ymd_to" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span></label>
													</td>
													<!--- 「入力担当者コード」一行テキストボックス（セパレート日付以外） --->
													<!--- 「担当者コードボタン」ボタン --->
													<!--- 「入力担当者名称」テキストボックスリードオンリー --->
													<th>
														<span class="tbl-hdg"><asp:Label ID="Nyuryokutan_cd_lbl" runat="server">入力担当者</asp:Label></span>
													</th>
													<td>
														<span class="icon-in"><md:MDTextBox ID="Nyuryokutan_cd" CssClass="inpSerch inpTanto" runat="server"></md:MDTextBox><input type="button" id="Btntanto_cd" name="Btntanto_cd" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="Nyuryokutan_nm" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
													</td>
												</tr>
												<tr>

													<!--- 「旧自社品番」一行テキストボックス（セパレート日付以外） --->
													<!--- 「旧自社品番２」一行テキストボックス（セパレート日付以外） --->
													<!--- 「旧自社品番３」一行テキストボックス（セパレート日付以外） --->
													<!--- 「旧自社品番４」一行テキストボックス（セパレート日付以外） --->
													<!--- 「旧自社品番５」一行テキストボックス（セパレート日付以外） --->
													<th>
														<span class="tbl-hdg"><asp:Label ID="Old_jisya_hbn_lbl" runat="server">自社品番</asp:Label></span>
													</th>
													<td colspan="3">
														<md:MDTextBox ID="Old_jisya_hbn" CssClass="inpJishahin10 multiinput" runat="server"></md:MDTextBox><md:MDTextBox ID="Old_jisya_hbn2" CssClass="inpJishahin10 multiinput" runat="server"></md:MDTextBox><md:MDTextBox ID="Old_jisya_hbn3" CssClass="inpJishahin10 multiinput" runat="server"></md:MDTextBox><md:MDTextBox ID="Old_jisya_hbn4" CssClass="inpJishahin10 multiinput" runat="server"></md:MDTextBox><md:MDTextBox ID="Old_jisya_hbn5" CssClass="inpJishahin10 multiinput" runat="server"></md:MDTextBox>
													</td>
													<!--- 「送信状態」ドロップダウンリスト --->
													<th>
														<span class="tbl-hdg"><asp:Label ID="Sosin_jyotai_lbl" runat="server">送信状態</asp:Label></span>
													</th>
													<td>
														<md:MDConditionDDList ID="Sosin_jyotai" ConditionName="sosin_jotai" CssClass="slt-sousin" runat="server"></md:MDConditionDDList>
														<span class="select-arrow"></span>
													</td>
												</tr>
												<tr>
													<!--- 「スキャンコード」一行テキストボックス（セパレート日付以外） --->
													<!--- 「スキャンコード２」一行テキストボックス（セパレート日付以外） --->
													<!--- 「スキャンコード３」一行テキストボックス（セパレート日付以外） --->
													<!--- 「スキャンコード４」一行テキストボックス（セパレート日付以外） --->
													<!--- 「スキャンコード５」一行テキストボックス（セパレート日付以外） --->
													<th class="last">
														<span class="tbl-hdg"><asp:Label ID="Scan_cd_lbl" runat="server">ｽｷｬﾝｺｰﾄﾞ</asp:Label></span>
													</th>
													<td class="last" colspan="5">
														<md:MDTextBox ID="Scan_cd" CssClass="inpScanHdg multiinput" runat="server"></md:MDTextBox><md:MDTextBox ID="Scan_cd2" CssClass="inpScanHdg multiinput" runat="server"></md:MDTextBox><md:MDTextBox ID="Scan_cd3" CssClass="inpScanHdg multiinput" runat="server"></md:MDTextBox><md:MDTextBox ID="Scan_cd4" CssClass="inpScanHdg multiinput" runat="server"></md:MDTextBox><md:MDTextBox ID="Scan_cd5" CssClass="inpScanHdg multiinput" runat="server"></md:MDTextBox>
													</td>
												</tr>
											</tbody>
										</table>
									<!-- /inner --></div>
								<!-- /str-form-02 --></div>
							</td>
							<td class="search-table-tdright">
								<div class="str-btn-search">
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
					<!--帳票／CSV系ボタンを配置する場合はこのulタグの中-->
					<ul>
						<!--- 「ボタン印刷」ボタン --->
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

					<!------------------------------------------
					  □一覧領域
					-------------------------------------------->
					<div class="str-result-01">
						<!------------------------------------------
						  □一覧ヘッダ領域
						-------------------------------------------->
						<div class="str-result-hdg-01">
							<div class="col1">
								<asp:Label ID="M1rowno_lbl" runat="server">No.</asp:Label>
							</div>
							<div class="col2">
								<asp:Label ID="M1face_no_lbl" runat="server">ﾌｪｲｽNo</asp:Label>
							</div>
							<div class="col3">
								<asp:Label ID="M1tana_dan_lbl" runat="server">棚段</asp:Label>
							</div>
							<div class="col4">
								<asp:Label ID="M1kai_su_lbl" runat="server">回数</asp:Label>
							</div>
							<div class="col5">
								<asp:Label ID="M1scan_su_lbl" runat="server">ｽｷｬﾝ数量</asp:Label>
							</div>
							<div class="col6">
								<asp:Label ID="M1nyuryokutan_nm_lbl" runat="server">入力担当者</asp:Label>
							</div>
							<div class="col7">
								<asp:Label ID="M1nyuryoku_ymd_lbl" runat="server">入力日</asp:Label>
							</div>
							<div class="col8">
								<asp:Label ID="M1sosin_ymd_lbl" runat="server">送信日</asp:Label>
							</div>
							<div class="col9">
								<asp:Label ID="M1gyosya_lbl" runat="server">業者</asp:Label>
							</div>
							<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
							<div style="display:none">
								<div class="col10">
									<asp:Label ID="M1selectorcheckbox_lbl" runat="server"></asp:Label>
								</div>
								<div class="col11">
									<asp:Label ID="M1entersyoriflg_lbl" runat="server"></asp:Label>
								</div>
								<div class="col12">
									<asp:Label ID="M1dtlirokbn_lbl" runat="server"></asp:Label>
								</div>
							</div>
						<!-- /str-hdg-result --></div>
						<!------------------------------------------
						  □一覧明細領域
						-------------------------------------------->
						<div id="str-result-item-wrap" class="adjust-elem">
							<asp:Repeater ID="M1" runat="server">
								<HeaderTemplate>
								</HeaderTemplate>
								<ItemTemplate>
									<div id="M1Row"  class="str-result-item-01" runat="server">
										<div class="col1 detail_right" >
											<!--- 「ｍ１行no」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1rowno" CssClass="inpReadonlyRight inpRONum4" runat="server"></asp:TextBox>
										</div>
										<div class="col2 detail_center">
											<!--- 「Ｍ１フェイスNOリンク」ボタン --->
											<input type="button" id="M1face_no" value="ﾌｪｲｽNo" onserverclick="OnM1FACE_NO_FRM" runat="server" class="meisaiLink"/>
										</div>
										<div class="col3 detail_right">
											<!--- 「ｍ１棚段」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1tana_dan" CssClass="inpReadonlyRight inpRONum2" runat="server"></asp:TextBox>
										</div>
										<div class="col4 detail_right">
											<!--- 「ｍ１回数」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1kai_su" CssClass="inpReadonlyRight inpRONum2" runat="server"></asp:TextBox>
										</div>
										<div class="col5 detail_right">
											<!--- 「ｍ１スキャン数量」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1scan_su" CssClass="inpReadonlyRight inpRONumCmaMinus6" runat="server"></asp:TextBox>
										</div>
										<div class="col6 detail_left">
											<!--- 「ｍ１入力担当者名称」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1nyuryokutan_nm" CssClass="inpReadonlyLeft inpROZenkaku10 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col7 detail_center">
											<!--- 「ｍ１入力日」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1nyuryoku_ymd" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox>
										</div>
										<div class="col8 detail_center">
											<!--- 「ｍ１送信日」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1sosin_ymd" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox>
										</div>
										<div class="col9 detail_center">
											<!--- 「ｍ１業者」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1gyosya" CssClass="inpReadonly inpROZenkaku1 tooltip" runat="server"></asp:TextBox>
										</div>
										<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
										<div style="display:none">
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
			<asp:Label ID="Head_tenpo_cd_Req" runat="server" CssClass="required">*</asp:Label> 
			<asp:Label ID="Head_tenpo_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Face_no_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Tana_dan_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Nyuryoku_ymd_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Sosin_ymd_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Nyuryokutan_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Old_jisya_hbn2_lbl" runat="server"></asp:Label>
			<asp:Label ID="Old_jisya_hbn3_lbl" runat="server"></asp:Label>
			<asp:Label ID="Old_jisya_hbn4_lbl" runat="server"></asp:Label>
			<asp:Label ID="Old_jisya_hbn5_lbl" runat="server"></asp:Label>
			<asp:Label ID="Scan_cd2_lbl" runat="server"></asp:Label>
			<asp:Label ID="Scan_cd3_lbl" runat="server"></asp:Label>
			<asp:Label ID="Scan_cd4_lbl" runat="server"></asp:Label>
			<asp:Label ID="Scan_cd5_lbl" runat="server"></asp:Label>
			<asp:Label ID="Searchcnt_lbl" runat="server"></asp:Label>

			<!--- 「モードNO」隠しフィールド --->
			<asp:hiddenfield ID="Modeno" runat="server"></asp:hiddenfield>
			<!--- 「選択モードNO」隠しフィールド --->
			<asp:hiddenfield ID="Stkmodeno" runat="server"></asp:hiddenfield>
		</div>
	
	</form>
</body>
</html>

