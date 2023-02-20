﻿<%@ Page language="c#" CodeFile="tl030f01.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Tl030p01.Page.Tl030f01Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">売変確定</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="tl030p01" FormId="tl030f01" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/tl030f01.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="tl030p01" FormId="tl030f01" runat="server" />

	<!-- Js業務部品のインポート --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02001.js" charset="UTF-8"></script><!-- 店舗検索 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02005.js" charset="UTF-8"></script><!-- 担当者マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02010.js" charset="UTF-8"></script><!-- 部門マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script><!-- 0埋め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05011.js" charset="UTF-8"></script><!-- FROM-TOコピー処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05014.js" charset="UTF-8"></script><!-- 名称取得拡張 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05019.js" charset="UTF-8"></script><!-- 情報ダイアログ表示処理(拡張版) -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05020.js" charset="UTF-8"></script><!-- SATOラベルプリンタ発行処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05025.js" charset="UTF-8"></script><!-- 指示番号丸め処理(売変用) -->


	<!-- 業務共通コントロールのインポート-->
	<%@ Register TagPrefix="uc" TagName="common" Src="~/pjcommon/businessCommon/usercontrol/boCommonControl.ascx" %>
</head>

<body>

	<!-- ラベル発行用 ActiveControl ↓↓↓↓↓ -->
	<object id="objMLWebComponent" classid="clsid:C137E319-41FE-4F0F-BD1F-190424FD7E2B" codebase="WebComponent-Installer-ja.exe" style="display:none">WebComponentが使用できません。</object>
	<object id="objFileAccessComponent" type="application/x-oleobject" classid="clsid:A3F14F83-0717-444B-9DE5-BFC3AF5C32E8" style="display:none"></object>
	<!-- ラベル発行用 ActiveControl ↑↑↑↑↑ -->

	<form id="Tl030f01" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="tl030p01" PgName="売変確定(X)" FormId="tl030f01" FormName="売変確定 一覧" ></uc:Header>

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
			<!------------------------------------------
			  ■検索条件領域
			-------------------------------------------->

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
<!--									<p class="required">*が付いている項目は必須入力になります。</p>	-->
										<table>
											<colgroup>
												<col class="w-type-01"/>
												<col class="w-type-02"/>
												<col class="w-type-01"/>
												<col class="w-type-03"/>
											</colgroup>
											<tbody>
												<tr>
													<th><span class="tbl-hdg"><asp:Label ID="Sinseimoto_lbl" runat="server">申請元</asp:Label></span></th>
													<td>
														<!--- 「申請元」ドロップダウンリスト --->
														<md:MDConditionDDList ID="Sinseimoto" ConditionName="sinseimoto" CssClass="slt-sinseimoto" runat="server"></md:MDConditionDDList><span class="select-arrow"></span>
													</td>
													<th>
														<span class="tbl-hdg"><asp:Label ID="Bumon_cd_from_lbl" runat="server">部門FROM</asp:Label></span>
													</th>
													<td colspan="3">
														<!--- 「部門コードfrom」一行テキストボックス（セパレート日付以外） ---><!--- 「部門コードFROMボタン」ボタン ---><!--- 「部門名from」テキストボックスリードオンリー --->
														<!--- 「部門コードto」一行テキストボックス（セパレート日付以外） ---><!--- 「部門コードTOボタン」ボタン ---><!--- 「部門名to」テキストボックスリードオンリー --->
														<span class="icon-in"><md:MDTextBox ID="Bumon_cd_from" CssClass="inpSerch inpBumon" runat="server"></md:MDTextBox><input type="button" id="Btnbumon_cd_from" name="Btnbumon_cd_from" value="" runat="server" class="icon-search"/></span>
														<asp:TextBox ID="Bumon_nm_from" CssClass="inpReadonlyLeft" runat="server"></asp:TextBox>
														<span class="label-fromto">～</span>
														<span class="icon-in"><md:MDTextBox ID="Bumon_cd_to" CssClass="inpSerch inpBumon" runat="server"></md:MDTextBox><input type="button" id="Btnbumon_cd_to" name="Btnbumon_cd_to" value="" runat="server" class="icon-search"/></span>
														<asp:TextBox ID="Bumon_nm_to" CssClass="inpReadonlyLeft" runat="server"></asp:TextBox>
													</td>
												</tr>
												<tr>
													<th><span class="tbl-hdg"><asp:Label ID="Sinseitan_cd_lbl" runat="server">申請担当者</asp:Label></span></th>
													<td>
														<!--- 「申請担当者コード」一行テキストボックス（セパレート日付以外） ---><!--- 「担当者コードボタン」ボタン ---><!--- 「申請担当者名称」テキストボックスリードオンリー --->
														<span class="icon-in"><md:MDTextBox ID="Sinseitan_cd" CssClass="inpSerch inpTanto" runat="server"></md:MDTextBox><input type="button" id="Btntanto_cd" name="Btntanto_cd" value="" runat="server" class="icon-search"/></span>
														<asp:TextBox ID="Sinseitan_nm" CssClass="inpReadonlyLeft" runat="server"></asp:TextBox>
													</td>
													<th>
														<span class="tbl-hdg"><asp:Label ID="Baihen_shiji_no_from_lbl" runat="server">売変指示NoFROM</asp:Label></span>
													</th>
													<!--- 「売変指示nofrom」一行テキストボックス（セパレート日付以外） ---><!--- 「売変指示noto」一行テキストボックス（セパレート日付以外） --->
													<td colspan="3">
														<md:MDTextBox ID="Baihen_shiji_no_from" CssClass="inpBaihenSijiNo" runat="server"></md:MDTextBox>
														<span class="label-fromto">～</span>
														<md:MDTextBox ID="Baihen_shiji_no_to" CssClass="inpBaihenSijiNo" runat="server"></md:MDTextBox>
													</td>
												</tr>
												<tr>
													<th class="last">
														<span class="tbl-hdg"><asp:Label ID="Baihensagyokaisi_ymd_from_lbl" runat="server">作業開始日FROM</asp:Label></span>
													</th>
													<!--- 「売変作業開始日from」一行テキストボックス（セパレート日付以外） ---><!--- 「売変作業開始日to」一行テキストボックス（セパレート日付以外） --->
													<td class="last"><label><span class="icon-in"><md:MDTextBox ID="Baihensagyokaisi_ymd_from" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span>
													<span class="label-fromto">～</span><span class="icon-in"><md:MDTextBox ID="Baihensagyokaisi_ymd_to" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span></label></td>
													<th class="last">
														<span class="tbl-hdg"><asp:Label ID="Baihenkaisi_ymd_from_lbl" runat="server">開始日FROM</asp:Label></span>
													</th>
													<!--- 「売変開始日from」一行テキストボックス（セパレート日付以外） ---><!--- 「売変開始日to」一行テキストボックス（セパレート日付以外） --->
													<td class="last" colspan="3"><label><span class="icon-in"><md:MDTextBox ID="Baihenkaisi_ymd_from" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span>
													<span class="label-fromto">～</span><span class="icon-in"><md:MDTextBox ID="Baihenkaisi_ymd_to" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span></label>
													<!--- 「現売価＝指示売価のみフラグ」チェックボックス --->
													<span class="tbl-hdg label-none" style="display:none" id="Genbaika_shijibaika_flg_Label" runat="server">&nbsp</span>
													<label><adv:AdvancedCheckBox ID="Genbaika_shijibaika_flg" Text="現売価＝指示売価のみ" CssClass="" runat="server"></adv:AdvancedCheckBox></label>
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
							<!--明細制御系ボタンを配置する場合はこのulタグの中 -->
							<!--- 「全選択ボタン」ボタン --->
							<li><span><label><input type="button" id="Btnzenstk" value="" onserverclick="OnBTNZENSTK_FRM" runat="server" class="icon-utility-01"/>全選択</label></span></li>
							<!--- 「全解除ボタン」ボタン --->
							<li><span><label><input type="button" id="Btnzenkjo" value="" onserverclick="OnBTNZENKJO_FRM" runat="server" class="icon-utility-02"/>全解除</label></span></li>
						</ul>
						<ul>
							<!--帳票／CSV系ボタンを配置する場合はこのulタグの中-->
							<li></li>
							<!--- 「ラベル発行機コードボタン」ボタン ---><!--- 「ラベル発行機名」テキストボックスリードオンリー --->
							<li><span class="icon-in"><input type="button" id="Btnlabel_cd" name="Btnlabel_cd" value="" runat="server" class="icon-search"/></span></li>
							<asp:TextBox ID="Label_nm" CssClass="inpReadonlyLeft inpLabelNM" runat="server"></asp:TextBox>
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
									<asp:Label ID="M1shinseimoto_nm_lbl" runat="server">申請元</asp:Label>
								</div>
								<div class="col3">
									<asp:Label ID="M1sinseitan_nm_lbl" runat="server">申請担当者</asp:Label>
								</div>
								<div class="col4">
									<asp:Label ID="M1baihen_shiji_no_lbl" runat="server">指示No</asp:Label>
								</div>
								<div class="col5">
									<asp:Label ID="M1bumon_cd_lbl" runat="server">部門</asp:Label>
								</div>
								<div class="col6">
									<asp:Label ID="M1baihensagyokaisi_ymd_lbl" runat="server">作業開始日</asp:Label>
								</div>
								<div class="col7">
									<asp:Label ID="M1baihenkaisi_ymd_lbl" runat="server">開始日</asp:Label>
								</div>
								<div class="col8">
									<asp:Label ID="M1baihen_riyu_nm_lbl" runat="server">売変理由</asp:Label>
								</div>
								<div class="col9">
									<asp:Label ID="M1hinban_su_lbl" runat="server">品番数</asp:Label>
								</div>
								<div class="col10">
									<asp:Label ID="M1zaiko_su_lbl" runat="server">在庫点数</asp:Label>
								</div>
								<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
								<div style="display:none">
									<div class="col11">
										<asp:Label ID="M1selectorcheckbox_lbl" runat="server">選択フラグ(隠し)</asp:Label>
									</div>
									<div class="col12">
										<asp:Label ID="M1entersyoriflg_lbl" runat="server">確定処理フラグ(隠し)</asp:Label>
									</div>
									<div class="col13">
										<asp:Label ID="M1dtlirokbn_lbl" runat="server">明細色区分(隠し)</asp:Label>
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
												<!--- 「ｍ１行no」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1rowno" CssClass="inpReadonlyRight inpRONum3" runat="server"></asp:TextBox>
											</div>
											<div class="col2 detail_left">
												<!--- 「ｍ１申請元名称」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1shinseimoto_nm" CssClass="inpReadonlyLeft inpROZenkaku2 tooltip" runat="server"></asp:TextBox>
											</div>
											<div class="col3 detail_left">
												<!--- 「ｍ１申請担当者名称」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1sinseitan_nm" CssClass="inpReadonlyLeft inpROZenkaku10 tooltip" runat="server"></asp:TextBox>
											</div>
											<div class="col4 detail_center">
												<!--- 「ｍ１売変指示no」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1baihen_shiji_no" CssClass="inpReadonlyLeft inpRONum10" runat="server"></asp:TextBox>
											</div>
											<div class="col5 detail_left">
												<!--- 「Ｍ１部門リンク」ボタン  --->
												<input type="button" id="M1bumon_cd" value="部門" onserverclick="OnM1BUMON_CD_FRM" runat="server" class="meisaiLink"/>
											</div>
											<div class="col6 detail_center">
												<!--- 「ｍ１売変作業開始日」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1baihensagyokaisi_ymd" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox>
											</div>
											<div class="col7 detail_center">
												<!--- 「ｍ１売変開始日」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1baihenkaisi_ymd" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox>
											</div>
											<div class="col8 detail_left">
												<!--- 「ｍ１売変理由名称」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1baihen_riyu_nm" CssClass="inpReadonlyLeft inpROZenkaku4 tooltip" runat="server"></asp:TextBox>
											</div>
											<div class="col9 detail_right">
												<!--- 「ｍ１品番数」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1hinban_su" CssClass="inpReadonlyRight inpRONumCma5" runat="server"></asp:TextBox>
											</div>
											<div class="col10 detail_right">
												<!--- 「ｍ１在庫数」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1zaiko_su" CssClass="inpReadonlyRight inpRONumCmaMinus6" runat="server"></asp:TextBox>
											</div>
											<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
											<div style="display:none">
												<div class="col11">
													<!--- 「ｍ１選択フラグ(隠し)」チェックボックス --->
													<adv:AdvancedCheckBox ID="M1selectorcheckbox" Text="選択フラグ(隠し)" CssClass="" runat="server"></adv:AdvancedCheckBox>
												</div>
												<div class="col12">
													<!--- 「Ｍ１確定処理フラグ(隠し)」隠しフィールド --->
													<asp:hiddenfield ID="M1entersyoriflg" runat="server"></asp:hiddenfield>
												</div>
												<div class="col13">
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
								<!--- 「ボタン確定」ボタン --->
								<input type="button" id="Btnenter" value="確定" onserverclick="OnBTNENTER_FRM" runat="server" class="btn type-01"/>
							</p>
						<!-- /str-pager-01 --></div>
					<!-- /footerBtnArea --></div>
			<!-- /str-wrap-result --></div>
		<!-- /wrap --></div>

		<!-- 画面上隠しエレメントを格納するエリア-->
		<div id="hiddenElements" style="display:none" runat="server">
			<asp:Label ID="Head_tenpo_cd_lbl" runat="server">店舗</asp:Label>
			<asp:Label ID="Head_tenpo_cd_Req" runat="server" CssClass="required">*</asp:Label>
			<asp:Label ID="Head_tenpo_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Searchcnt_lbl" runat="server"></asp:Label>
			<asp:Label ID="Bumon_nm_from_lbl" runat="server"></asp:Label>
			<asp:Label ID="Bumon_cd_to_lbl" runat="server">部門TO</asp:Label>
			<asp:Label ID="Bumon_nm_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Sinseitan_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Baihen_shiji_no_to_lbl" runat="server">売変指示NoTO</asp:Label>
			<asp:Label ID="Baihensagyokaisi_ymd_to_lbl" runat="server">作業開始日TO</asp:Label>
			<asp:Label ID="Baihenkaisi_ymd_to_lbl" runat="server">開始日TO</asp:Label>
			<asp:Label ID="Genbaika_shijibaika_flg_lbl" runat="server">現売価＝指示売価のみ</asp:Label>
			<!--- 「ラベル発行機ＩＤ」隠しフィールド --->
			<asp:hiddenfield ID="Label_cd" runat="server"></asp:hiddenfield>
			<!--- 「ラベル発行機ＩＰ」隠しフィールド --->
			<asp:hiddenfield ID="Label_ip" runat="server"></asp:hiddenfield>
			<asp:Label ID="Label_nm_lbl" runat="server"></asp:Label>
		</div>
	</form>
</body>
</html>

