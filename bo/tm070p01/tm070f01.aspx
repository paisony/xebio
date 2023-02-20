<%@ Page language="c#" CodeFile="tm070f01.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Tm070p01.Page.Tm070f01Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">緊急担当者所属店変更</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="tm070p01" FormId="tm070f01" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/tm070f01.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="tm070p01" FormId="tm070f01" runat="server" />

	<!-- Js業務部品のインポート --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02001.js" charset="UTF-8"></script><!-- 店舗検索 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02005.js" charset="UTF-8"></script><!-- 担当者マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02027.js" charset="UTF-8"></script><!-- 担当者マスタ・店舗マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05003.js" charset="UTF-8"></script><!-- 明細背景色変更処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script><!-- 0埋め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05011.js" charset="UTF-8"></script><!-- FROM-TOコピー処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05014.js" charset="UTF-8"></script><!-- 名称取得拡張 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05015.js" charset="UTF-8"></script><!-- 項目制御処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05019.js" charset="UTF-8"></script><!-- 情報ダイアログ表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05023.js" charset="UTF-8"></script><!-- 日付編集関数群 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05024.js" charset="UTF-8"></script><!-- 数値編集関数群 -->

	<!-- 業務共通コントロールのインポート-->
	<%@ Register TagPrefix="uc" TagName="common" Src="~/pjcommon/businessCommon/usercontrol/boCommonControl.ascx" %>
</head>

<body>
	<form id="Tm070f01" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
			<uc:Header ID="header" runat="server" PgId="tm070p01" PgName="緊急担当者所属店変更" FormId="tm070f01" FormName="緊急担当者所属店変更" ></uc:Header>

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
					<!-- <p class="required">*が付いている項目は必須入力になります。</p>-->
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
													<th scope="col">
														<span class="tbl-hdg"><asp:Label ID="Henko_ymd_from_lbl" runat="server">変更日ＦＲＯＭ</asp:Label></span>
													</th>
													<td>
														<!--- 「変更日ｆｒｏｍ」一行テキストボックス（セパレート日付以外） --->
														<!--- 「変更日ｔｏ」一行テキストボックス（セパレート日付以外） --->
														<label><span class="icon-in"><md:MDTextBox ID="Henko_ymd_from" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span><span class="label-fromto">～</span><span class="icon-in"><md:MDTextBox ID="Henko_ymd_to" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span></label>
													</td>
													<th scope="col">
														<span class="tbl-hdg"><asp:Label ID="Moto_tenpo_cd_from_lbl" runat="server">元店舗ＦＲＯＭ</asp:Label></span>
													</th>
													<td>
														<!--- 「元店舗コードｆｒｏｍ」一行テキストボックス（セパレート日付以外） --->
														<!--- 「元店舗コードＦＲＯＭボタン」ボタン --->
														<!--- 「元店舗名称ｆｒｏｍ」テキストボックスリードオンリー --->
														<!--- 「元店舗コードｔｏ」一行テキストボックス（セパレート日付以外） --->
														<!--- 「元店舗コードＴＯボタン」ボタン --->
														<!--- 「元店舗名称ｔｏ」テキストボックスリードオンリー --->
														<span class="icon-in"><md:MDTextBox ID="Moto_tenpo_cd_from" CssClass="inpSerch inpTenpo" runat="server"></md:MDTextBox><input type="button" id="Btnmototenpocd_from" name="Btnmototenpocd_from" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="Moto_tenpo_nm_from" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
														<span class="label-fromto">～</span>
														<span class="icon-in"><md:MDTextBox ID="Moto_tenpo_cd_to" CssClass="inpSerch inpTenpo" runat="server"></md:MDTextBox><input type="button" id="Btnmototenpocd_to" name="Btnmototenpocd_to" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="Moto_tenpo_nm_to" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
													</td>
												</tr>
												<tr>
													<th class ="last">
														<span class="tbl-hdg"><asp:Label ID="Tan_cd_from_lbl" runat="server">担当者ＦＲＯＭ</asp:Label></span>
													</th>
													<td colspan="3" class ="last">
														<!--- 「担当者コードｆｒｏｍ」一行テキストボックス（セパレート日付以外） --->
														<!--- 「担当者コードＦＲＯＭボタン」ボタン --->
														<!--- 「担当者名称ｆｒｏｍ」テキストボックスリードオンリー --->
														<!--- 「担当者コードｔｏ」一行テキストボックス（セパレート日付以外） --->
														<!--- 「担当者コードＴＯボタン」ボタン --->
														<!--- 「担当者名称ｔｏ」テキストボックスリードオンリー --->
														<span class="icon-in"><md:MDTextBox ID="Tan_cd_from" CssClass="inpSerch inpTanto" runat="server"></md:MDTextBox><input type="button" id="Btntancd_from" name="Btntancd_from" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="Tan_nm_from" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
														<span class="label-fromto">～</span>
														<span class="icon-in"><md:MDTextBox ID="Tan_cd_to" CssClass="inpSerch inpTanto" runat="server"></md:MDTextBox><input type="button" id="Btntancd_to" name="Btntancd_to" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="Tan_nm_to" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
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
				<!------------------------------------------
					□明細ボタン部
				-------------------------------------------->
				<div id="str-btn-area" class="str-btn-utility">
					<div id="meisaiBtnArea" class="inner pad0" runat="server">
					<ul>
						<!--明細制御系ボタンを配置する場合はこのulタグの中-->
						<!--- 「ページ追加ボタン」ボタン --->
						<li><span><label><input type="button" id="Btnpageins" value="" onserverclick="OnBTNPAGEINS_MINSX" runat="server" class="icon-utility-06"/>ページ追加</label></span></li>
						<!--- 「行削除ボタン」ボタン --->
						<li><span><label><input type="button" id="Btnrowdel" value="" onserverclick="OnBTNROWDEL_FRM" runat="server" class="icon-utility-03"/>行削除</label></span></li>
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
							<div class="col1">
								<asp:Label ID="M1rowno_lbl" runat="server">No.</asp:Label>
							</div>
							<div class="col2">
								<asp:Label ID="M1tan_cd_lbl" runat="server">担当者</asp:Label>
							</div>
							<div class="col3">
								<asp:Label ID="M1moto_tenpo_cd_lbl" runat="server">元店舗</asp:Label>
							</div>
							<div class="col4">
								<asp:Label ID="M1henko_tenpo_cd_lbl" runat="server">変更店舗</asp:Label>
							</div>
							<div class="col5">
								<asp:Label ID="M1henko_ymd_lbl" runat="server">変更日</asp:Label>
							</div>
							<div class="col6">
								<asp:Label ID="M1shozokuten_shokika_check_lbl" runat="server">所属店初期化</asp:Label>
							</div>
							<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
							<div style="display:none">
								<div class="col7">
									<asp:Label ID="M1tan_nm_lbl" runat="server"></asp:Label>
								</div>
								<div class="col8">
									<asp:Label ID="M1moto_tenpo_nm_lbl" runat="server"></asp:Label>
								</div>
								<div class="col9">
									<asp:Label ID="M1henko_tenpo_nm_lbl" runat="server"></asp:Label>
								</div>
								<div class="col10">
									<asp:Label ID="M1henko_tm_lbl" runat="server"></asp:Label>
								</div>
								<div class="col11">
									<asp:Label ID="M1upd_ymd_lbl" runat="server"></asp:Label>
								</div>
								<div class="col12">
									<asp:Label ID="M1upd_tm_lbl" runat="server"></asp:Label>
								</div>
								<div class="col13">
									<asp:Label ID="M1selectorcheckbox_lbl" runat="server"></asp:Label>
								</div>
								<div class="col14">
									<asp:Label ID="M1entersyoriflg_lbl" runat="server"></asp:Label>
								</div>
								<div class="col15">
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
											<!--- 「ｍ１行no」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1rowno" CssClass="inpReadonlyRight inpRONum4" runat="server"></asp:TextBox>
										</div>
										<div class="col2 detail_left">
											<!--- 「ｍ１担当者コード」一行テキストボックス（セパレート日付以外） --->
											<!--- 「ｍ１担当者名称」テキストボックスリードオンリー --->
											<md:MDTextBox ID="M1tan_cd" CssClass="inpTanto" runat="server"></md:MDTextBox><asp:TextBox ID="M1tan_nm" CssClass="inpReadonlyLeft inpRORightNm inpROZenkaku10 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col3 detail_left">
											<!--- 「ｍ１元店舗コード」テキストボックスリードオンリー --->
											<!--- 「ｍ１元店舗名称」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1moto_tenpo_cd" CssClass="inpReadonlyRight inpRONum4" runat="server"></asp:TextBox><asp:TextBox ID="M1moto_tenpo_nm" CssClass="inpReadonlyLeft inpRORightNm inpROZenkaku10 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col4 detail_left">
											<!--- 「ｍ１変更店舗コード」テキストボックスリードオンリー --->
											<!--- 「ｍ１変更店舗名称」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1henko_tenpo_cd" CssClass="inpReadonlyRight inpRONum4" runat="server"></asp:TextBox><asp:TextBox ID="M1henko_tenpo_nm" CssClass="inpReadonlyLeft inpRORightNm inpROZenkaku10 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col5 detail_center">
											<!--- 「ｍ１変更日」テキストボックスリードオンリー --->
											<!--- 「ｍ１変更時間」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1henko_ymd" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox> <asp:TextBox ID="M1henko_tm" CssClass="inpReadonlyLeft inpROTime" runat="server"></asp:TextBox>
										</div>
										<div class="col6 detail_center">
											<!--- 「ｍ１所属店初期化チェック」チェックボックス --->
											<adv:AdvancedCheckBox ID="M1shozokuten_shokika_check" Text="所属店初期化" CssClass="padtop" runat="server"></adv:AdvancedCheckBox>
										</div>
										<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
										<div style="display:none">
											<div class="col11">
												<!--- 「Ｍ１更新日(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1upd_ymd" runat="server"></asp:hiddenfield>
											</div>
											<div class="col12">
												<!--- 「Ｍ１更新時間(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1upd_tm" runat="server"></asp:hiddenfield>
											</div>
											<div class="col13">
												<!--- 「ｍ１選択フラグ(隠し)」チェックボックス --->
												<adv:AdvancedCheckBox ID="M1selectorcheckbox" Text="" CssClass="" runat="server"></adv:AdvancedCheckBox>
											</div>
											<div class="col14">
												<!--- 「Ｍ１確定処理フラグ(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1entersyoriflg" runat="server"></asp:hiddenfield>
											</div>
											<div class="col15">
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
					<!-- /str-pager-bottom --></div>
				<!-- /footerBtnArea --></div>
			<!-- /str-wrap-result --></div>
		<!-- /wrap --></div>

		<!-- 画面上隠しエレメントを格納するエリア-->
		<div id="hiddenElements" style="display:none" runat="server">
			<asp:Label ID="Head_tenpo_cd_lbl" runat="server">店舗</asp:Label>
			<asp:Label ID="Head_tenpo_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Henko_ymd_to_lbl" runat="server">変更日ＴＯ</asp:Label>
			<asp:Label ID="Moto_tenpo_nm_from_lbl" runat="server"></asp:Label>
			<asp:Label ID="Moto_tenpo_cd_to_lbl" runat="server">元店舗ＴＯ</asp:Label>
			<asp:Label ID="Moto_tenpo_nm_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Tan_nm_from_lbl" runat="server"></asp:Label>
			<asp:Label ID="Tan_cd_to_lbl" runat="server">担当者ＴＯ</asp:Label>
			<asp:Label ID="Tan_nm_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Searchcnt_lbl" runat="server"></asp:Label>
			<!--- 「選択モードNO」隠しフィールド --->
			<asp:hiddenfield ID="Stkmodeno" runat="server"></asp:hiddenfield>
		</div>
	</form>
</body>
</html>

