<%@ Page language="c#" CodeFile="tj160f01.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Tj160p01.Page.Tj160f01Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">棚卸チェックリスト出力</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="tj160p01" FormId="tj160f01" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/tj160f01.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="tj160p01" FormId="tj160f01" runat="server" />
	<!-- Js業務部品のインポート --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02001.js" charset="UTF-8"></script><!-- 店舗検索 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02012.js" charset="UTF-8"></script><!-- 品種マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script><!-- 0埋め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05011.js" charset="UTF-8"></script><!-- FROM-TOコピー処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05014.js" charset="UTF-8"></script><!-- 名称取得拡張 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05015.js" charset="UTF-8"></script><!-- 項目入力制御処理 -->
</head>

<body>
	<form id="Tj160f01" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="tj160p01" PgName="棚卸チェックリスト出力(V)" FormId="tj160f01" FormName="棚卸チェックリスト出力" ></uc:Header>

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
				<table class="search-table">
					<tr>
						<td class="search-table-tdleft">
							<div class="str-form-02">
								<div class="inner">
									<!--<p class="required">*が付いている項目は必須入力になります。</p>-->
									<table>
										<colgroup>
											<col class="w-type-01"/>
											<col class="w-type-02"/>
										<col />
										</colgroup>
										<tbody>
											<tr>
												<th>
													<span class="tbl-hdg"><asp:Label ID="Face_no_from_lbl" runat="server">フェイスNo.FROM</asp:Label></span>
												</th>
												<!--- 「フェイス№from」一行テキストボックス（セパレート日付以外） ---><!--- 「フェイス№to」一行テキストボックス（セパレート日付以外） --->
												<td><md:MDTextBox ID="Face_no_from" CssClass="inpFaceNo" runat="server"></md:MDTextBox><span class="label-fromto">～</span><md:MDTextBox ID="Face_no_to" CssClass="inpFaceNo" runat="server"></md:MDTextBox></td>
											</tr>
											<tr>
												<th>
													<span class="tbl-hdg"><asp:Label ID="Nyuryoku_ymd_from_lbl" runat="server">入力日FROM</asp:Label></span>
												</th>
												<!--- 「入力日from」一行テキストボックス（セパレート日付以外） ---><!--- 「入力日to」一行テキストボックス（セパレート日付以外） --->
												<td><label><span class="icon-in"><md:MDTextBox ID="Nyuryoku_ymd_from" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span><span class="label-fromto">～</span><span class="icon-in"><md:MDTextBox ID="Nyuryoku_ymd_to" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span></label></td>
											</tr>
											<tr>
												<th class="last"><span class="tbl-hdg"><asp:Label ID="Tyohuku_umu_lbl" runat="server">重複有無</asp:Label></span></th>
												<td class="last">
													<!--- 「重複有無」ドロップダウンリスト --->
													<md:MDConditionDDList ID="Tyohuku_umu" ConditionName="umu" CssClass="slt-jufuku" runat="server"></md:MDConditionDDList>
													<span class="select-arrow"></span></td>
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
					</ul>
					<ul>
						<!--帳票／CSV系ボタンを配置する場合はこのulタグの中-->
						<!--- 「印刷ボタン」ボタン --->
						<li><span><label><input type="button" id="Btnprint" value="" onserverclick="OnBTNPRINT_FRM" runat="server" class="icon-utility-04"/>印刷</label></span><li>
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
							<div class="col1"><asp:Label ID="M1rowno_lbl" runat="server">No.</asp:Label></div>
							<div class="col2"><asp:Label ID="M1face_no_lbl" runat="server">ﾌｪｲｽNo</asp:Label></div>
							<div class="col3"><asp:Label ID="M1tana_dan_lbl" runat="server">棚段</asp:Label></div>
							<div class="col4"><asp:Label ID="M1tyohuku_lbl" runat="server">重複</asp:Label></div>
							<div class="col5"><asp:Label ID="M1tantosya_cd_lbl" runat="server">担当者</asp:Label></div>
							<div class="col6"><asp:Label ID="M1checklist_memo_lbl" runat="server">メモ</asp:Label></div>
							<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
							<div style="display:none">
								<asp:Label ID="M1hanbaiin_nm_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1selectorcheckbox_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1entersyoriflg_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1dtlirokbn_lbl" runat="server"></asp:Label>
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
								<div class="str-result-item-01">
									<div class="col1 detail_right">
										<!--- 「ｍ１行no」テキストボックスリードオンリー --->
										<asp:TextBox ID="M1rowno" CssClass="inpReadonlyRight inpRONum4" runat="server"></asp:TextBox>
									</div>
									<div class="col2 detail_center">
										<!--- 「ｍ１フェイス№」テキストボックスリードオンリー --->
										<asp:TextBox ID="M1face_no" CssClass="inpReadonlyCenter inpROHankaku5" runat="server"></asp:TextBox>
									</div>
									<div class="col3 detail_right">
										<!--- 「ｍ１棚段」テキストボックスリードオンリー --->
										<asp:TextBox ID="M1tana_dan" CssClass="inpReadonlyRight inpROHankaku2" runat="server"></asp:TextBox>
									
									</div>
									<div class="col4 detail_right">
										<!--- 「ｍ１重複」テキストボックスリードオンリー --->
										<asp:TextBox ID="M1tyohuku" CssClass="inpReadonlyRight inpRONum2" runat="server"></asp:TextBox>
									</div>
									<div class="col5 detail_left">
										<!--- 「ｍ１担当者コード」テキストボックスリードオンリー --->
										<asp:TextBox ID="M1tantosya_cd" CssClass="inpReadonlyLeft inpRONum7" runat="server"></asp:TextBox>
										<!--- 「ｍ１担当者名」テキストボックスリードオンリー --->
										<asp:TextBox ID="M1hanbaiin_nm" CssClass="inpReadonlyLeft  inpROZenkaku10 tooltip inpRORightNm" runat="server"></asp:TextBox>
									</div>
									<div class="col6 detail_left">
										<!--- 「ｍ１メモ」テキストボックスリードオンリー --->
										<asp:TextBox ID="M1checklist_memo" CssClass="inpReadonlyLeft inpROZenkaku10 tooltip" runat="server"></asp:TextBox>
									</div>
									<div style="display:none">
										<div class="col8">
											<!--- 「ｍ１選択フラグ(隠し)」チェックボックス --->
											<adv:AdvancedCheckBox ID="M1selectorcheckbox" Text="" CssClass="" runat="server"></adv:AdvancedCheckBox>
										</div>
										<div class="col9">
											<!--- 「Ｍ１確定処理フラグ(隠し)」隠しフィールド --->
											<asp:hiddenfield ID="M1entersyoriflg" runat="server"></asp:hiddenfield>
										</div>
										<div class="col10">
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
						<div id="str-pager-bottom" class="footer str-pager-01 pad0 heightZero">
							<p>
							</p>
							<p>
								<!-- ページャ下部にボタンを配置する場合はこの中 -->
							</p>
						<!-- /str-pager-01 --></div>
					<!-- /footerBtnArea --></div>
			<!-- /str-wrap-result -->
		<!-- /wrap --></div>	
		
		<!-- 画面上隠しエレメントを格納するエリア-->
		<div id="hiddenElements" style="display:none" runat="server">
			<asp:Label ID="Head_tenpo_cd_lbl" runat="server">店舗</asp:Label>
			<asp:Label ID="Head_tenpo_cd_Req" runat="server" CssClass="required">*</asp:Label>
			<asp:Label ID="Head_tenpo_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Searchcnt_lbl" runat="server">検索件数</asp:Label>
			<asp:Label ID="Face_no_to_lbl" runat="server">フェイスNo.TO</asp:Label>
			<asp:Label ID="Nyuryoku_ymd_to_lbl" runat="server">入力日TO</asp:Label>
		</div>
	
	</form>
</body>
</html>

