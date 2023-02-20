<%@ Page language="c#" CodeFile="tm040f01.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Tm040p01.Page.Tm040f01Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">サイズ検索</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="tm040p01" FormId="tm040f01" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/tm040f01.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="tm040p01" FormId="tm040f01" runat="server" />

	<!-- 共通部品のインポート -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->

	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05001.js" charset="UTF-8"></script><!-- 自社品番丸め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05002.js" charset="UTF-8"></script><!-- スキャンコード丸め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script><!-- 0埋め処理 -->

	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05014.js" charset="UTF-8"></script><!-- 名称取得拡張 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02003.js" charset="UTF-8"></script><!-- 発注マスタ取得(自社品番) -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02004.js" charset="UTF-8"></script><!-- 発注マスタ取得(スキャンコード) -->

</head>

<body>
	<form id="Tm040f01" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="tm040p01" PgName="サイズ検索" FormId="tm040f01" FormName="サイズ検索 色選択" ></uc:Header>

			<!-------------------------------------------------------------------
									1.カード部
			--------------------------------------------------------------------->
			<!-- search-list -->
			<div class="str-search-01">
	
				<!------------------------------------------
				  □検索条件領域(非表示時)
				-------------------------------------------->
				<div class="inner-01" style="display:none;">
					<p id="list-search"></p>
					<p class="txt-02">該当件数<span class="hit-number"></span><span>件</span></p>
				<!-- /inner-01 --></div>
	
				<!------------------------------------------
				  □検索条件領域(入力時)
				-------------------------------------------->
				<div class="inner-02">
<%--					<p class="required">*が付いている項目は必須入力になります。</p>--%>
					<p class="required2">*が付いている項目はいずれか一つの項目が必須入力になります。</p>
					<table class="search-table">
						<tr>
							<td class="search-table-tdleft">
								<div class="str-form-02">
									<div class="inner">
										<table>
											<colgroup>
												<col class="w-type-01">
												<col class="w-type-02">
												<col class="w-type-01">
												<col class="w-type-03">
												<col />
											</colgroup>
											<tbody>
												<tr>
													<th scope="col">
														<span class="tbl-hdg">
															<asp:Label ID="Old_jisya_hbn_lbl" runat="server">自社品番</asp:Label><span class="required2">*</span>
														</span>
													</th>
													<td>
														<!--- 「旧自社品番」一行テキストボックス（セパレート日付以外） --->
														<md:MDTextBox ID="Old_jisya_hbn" CssClass="inpJishahin10" runat="server"></md:MDTextBox>
													</td>
													<th scope="col">
														<span class="tbl-hdg">
															<asp:Label ID="Scan_cd_lbl" runat="server">ｽｷｬﾝｺｰﾄﾞ</asp:Label><span class="required2">*</span>
														</span>
													</th>
													<td>
														<!--- 「スキャンコード」一行テキストボックス（セパレート日付以外） --->
														<md:MDTextBox ID="Scan_cd" CssClass="inpScanHdg" runat="server"></md:MDTextBox>
													</td>
												</tr>
												<tr>
													<th scope="col">
														<span class="tbl-hdg">
															<asp:Label ID="Bumon_nm_lbl" runat="server">部門</asp:Label>
														</span>
													</th>
													<td>
														<!--- 「部門名」テキストボックスリードオンリー --->
														<asp:TextBox ID="Bumon_nm" CssClass="inpReadonlyLeft inpROZenkaku10 tooltip" runat="server"></asp:TextBox>
													</td>
													<th scope="col">
														<span class="tbl-hdg">
															<asp:Label ID="Hinsyu_ryaku_nm_lbl" runat="server">品種</asp:Label>
														</span>
													</th>
													<td>
														<!--- 「品種略名称」テキストボックスリードオンリー --->
														<asp:TextBox ID="Hinsyu_ryaku_nm" CssClass="inpReadonlyLeft inpROZenkaku10 tooltip" runat="server"></asp:TextBox>
													</td>
												</tr>
												<tr>
													<th scope="col">
														<span class="tbl-hdg">
															<asp:Label ID="Burando_nm_lbl" runat="server">ブランド</asp:Label>
														</span>
													</th>
													<td colspan="3">
														<!--- 「ブランド名」テキストボックスリードオンリー --->
														<asp:TextBox ID="Burando_nm" CssClass="inpReadonlyLeft inpROHankaku20" runat="server"></asp:TextBox>
													</td>
												</tr>
												<tr>
													<th scope="col">
														<span class="tbl-hdg">
															<asp:Label ID="Maker_hbn_lbl" runat="server">メーカー品番</asp:Label>
														</span>
													</th>
													<td colspan="3">
														<!--- 「メーカー品番」テキストボックスリードオンリー --->
														<asp:TextBox ID="Maker_hbn" CssClass="inpReadonlyLeft inpROHankaku30" runat="server"></asp:TextBox>
													</td>
												</tr>
												<tr>
													<th scope="col">
														<span class="tbl-hdg">
															<asp:Label ID="Syonmk_lbl" runat="server">商品名</asp:Label>
														</span>
													</th>
													<td colspan="3">
														<!--- 「商品名(カナ)」テキストボックスリードオンリー --->
														<asp:TextBox ID="Syonmk" CssClass="inpReadonlyLeft inpROHankaku20 tooltip" runat="server"></asp:TextBox>
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
						</ul>
					<!-- /meisaiBtnArea --></div>
				<!-- /utility --></div>

				<!------------------------------------------
					□明細部
				-------------------------------------------->
				<div class="inner">
					<div id="str-pager-top" class="str-pager-01" style="display: none;">

						<!--- 件数表示部 --->
						<p><adv:PageInfo ID="M1PageInfo" runat="server"></adv:PageInfo></p>
						<!--- ページャーを配置する場合はこの中 --->
		
					<!-- /str-pager-01 --></div>
					<!--一覧-->
					<div class="str-result-01">
						<%-- 明細ヘッダ --%>
						<div class="str-result-hdg-01">
							<div class="col1">
								<asp:Label ID="M1rowno_lbl" runat="server">No.</asp:Label>
							</div>
							<div class="col2">
								<asp:Label ID="M1iro_nm_lbl" runat="server">色</asp:Label>
							</div>

							<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
							<div style="display:none">
								<div class="col3">
									<asp:Label ID="M1selectorcheckbox_lbl" runat="server"></asp:Label>
								</div>
								<div class="col4">
									<asp:Label ID="M1entersyoriflg_lbl" runat="server"></asp:Label>
								</div>
								<div class="col5">
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
										<div class="col1 detail_right">
											<!--- 「ｍ１行no」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1rowno" CssClass="inpReadonlyRight inpRONum2" runat="server"></asp:TextBox>
										</div>
										<div class="col2 detail_left">
											<!--- 「Ｍ１色リンク」ボタン --->
											<input type="button" id="M1iro_nm" value="色" onserverclick="OnM1IRO_NM_FRM" runat="server" class="meisaiLink"/>
										</div>

										<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
										<div style="display:none">
											<div class="col3">
												<!--- 「ｍ１選択フラグ(隠し)」チェックボックス --->
												<adv:AdvancedCheckBox ID="M1selectorcheckbox" Text="" CssClass="" runat="server"></adv:AdvancedCheckBox>
											</div>
											<div class="col4">
												<!--- 「Ｍ１確定処理フラグ(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1entersyoriflg" runat="server"></asp:hiddenfield>
											</div>
											<div class="col5">
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
					<div id="str-pager-bottom" class="str-pager-01">
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
			<!--- 「モードNO」隠しフィールド --->
			<asp:hiddenfield ID="Modeno" runat="server"></asp:hiddenfield>
			<!--- 「選択モードNO」隠しフィールド --->
			<asp:hiddenfield ID="Stkmodeno" runat="server"></asp:hiddenfield>
			<!--- 「店舗コード」隠しフィールド --->
			<asp:hiddenfield ID="Tenpo_cd" runat="server"></asp:hiddenfield>
			<!--- 「店別単価マスタ検索フラグ」隠しフィールド --->
			<asp:hiddenfield ID="Pluflg" runat="server"></asp:hiddenfield>
			<!--- 「売変検索フラグ」隠しフィールド --->
			<asp:hiddenfield ID="Priceflg" runat="server"></asp:hiddenfield>
			<!--- 「店在庫検索フラグ」隠しフィールド --->
			<asp:hiddenfield ID="Zaikoflg" runat="server"></asp:hiddenfield>
			<!--- 「入荷予定数検索フラグ」隠しフィールド --->
			<asp:hiddenfield ID="Nyukaflg" runat="server"></asp:hiddenfield>
			<!--- 「売上実績数検索フラグ」隠しフィールド --->
			<asp:hiddenfield ID="Uriflg" runat="server"></asp:hiddenfield>
			<!--- 「依頼集計数(補充)検索フラグ」隠しフィールド --->
			<asp:hiddenfield ID="Hojuflg" runat="server"></asp:hiddenfield>
			<!--- 「依頼集計数(単品)検索フラグ」隠しフィールド --->
			<asp:hiddenfield ID="Tanpinflg" runat="server"></asp:hiddenfield>
			<!--- 「指示検索フラグ」隠しフィールド --->
			<asp:hiddenfield ID="Sijiflg" runat="server"></asp:hiddenfield>
			<!--- 「指示番号」隠しフィールド --->
			<asp:hiddenfield ID="Siji_bango" runat="server"></asp:hiddenfield>
			<!--- 「出荷会社コード」隠しフィールド --->
			<asp:hiddenfield ID="Syukkakaisya_cd" runat="server"></asp:hiddenfield>
			<!--- 「入荷会社コード」隠しフィールド --->
			<asp:hiddenfield ID="Jyuryokaisya_cd" runat="server"></asp:hiddenfield>
			<!--- 「出荷店コード」隠しフィールド --->
			<asp:hiddenfield ID="Syukkaten_cd" runat="server"></asp:hiddenfield>
		</div>

	</form>
</body>
</html>

