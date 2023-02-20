<%@ Page language="c#" CodeFile="tm040f02.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Tm040p01.Page.Tm040f02Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">サイズ検索</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="tm040p01" FormId="tm040f02" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/tm040f02.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="tm040p01" FormId="tm040f02" runat="server" />

   	<!-- 共通部品のインポート -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->

	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05003.js" charset="UTF-8"></script><!-- 明細背景色変更処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script><!-- 0埋め処理 -->

</head>

<body>
	<form id="Tm040f02" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="tm040p01" PgName="サイズ検索" FormId="tm040f02" FormName="サイズ検索 サイズ入力" ></uc:Header>

			<!------------------------------------------
				□ヘッダー部
			-------------------------------------------->

			<!--- 「ボタン戻る」ボタン --->
			<p class="headerBackBtn">
				<input type="button" id="Btnback" value="" onserverclick="OnBTNBACK_FRM" runat="server" class="btn type-back"/>
			</p>

			<!-------------------------------------------------------------------
									1.カード部
			--------------------------------------------------------------------->
			<!-- search-list -->
			<div class="str-search-02">
				<div class="inner-01">
					<table>
						<colgroup>
							<col class="w-type-01"/>
							<col class="w-type-02"/>
							<col class="w-type-01"/>
							<col class="w-type-03"/>
							<col />
						</colgroup>
						<tbody>
							<tr>
								<th class="last">
									<span class="tbl-hdg"><asp:Label ID="Old_jisya_hbn_lbl" runat="server">自社品番</asp:Label></span>
								</th>
								<td class="last" colspan="3">
									<!--- 「旧自社品番」テキストボックスリードオンリー --->
									<asp:TextBox ID="Old_jisya_hbn" CssClass="inpReadonlyLeft inpRONum10" runat="server"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<th class="last">
									<span class="tbl-hdg"><asp:Label ID="Bumon_nm_lbl" runat="server">部門</asp:Label></span>
								</th>
								<td class="last">
									<!--- 「部門名」テキストボックスリードオンリー --->
									<asp:TextBox ID="Bumon_nm" CssClass="inpReadonlyLeft inpROZenkaku10 tooltip" runat="server"></asp:TextBox>
								</td>
								<th class="last">
									<span class="tbl-hdg"><asp:Label ID="Hinsyu_ryaku_nm_lbl" runat="server">品種</asp:Label></span>
								</th>
								<td class="last">
									<!--- 「品種略名称」テキストボックスリードオンリー --->
									<asp:TextBox ID="Hinsyu_ryaku_nm" CssClass="inpReadonlyLeft inpROZenkaku10 tooltip" runat="server"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<th class="last">
									<span class="tbl-hdg"><asp:Label ID="Burando_nm_lbl" runat="server">ブランド</asp:Label></span>
								</th>
								<td class="last" colspan="3">
									<!--- 「ブランド名」テキストボックスリードオンリー --->
									<asp:TextBox ID="Burando_nm" CssClass="inpReadonlyLeft inpROHankaku20" runat="server"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<th class="last">
									<span class="tbl-hdg"><asp:Label ID="Maker_hbn_lbl" runat="server">メーカー品番</asp:Label></span>
								</th>
								<td class="last" colspan="3">
									<!--- 「メーカー品番」テキストボックスリードオンリー --->
									<asp:TextBox ID="Maker_hbn" CssClass="inpReadonlyLeft inpROHankaku30" runat="server"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<th class="last">
									<span class="tbl-hdg"><asp:Label ID="Syonmk_lbl" runat="server">商品名</asp:Label></span>
								</th>
								<td class="last">
									<!--- 「商品名(カナ)」テキストボックスリードオンリー --->
									<asp:TextBox ID="Syonmk" CssClass="inpReadonlyLeft inpROHankaku20 tooltip" runat="server"></asp:TextBox>
								</td>
								<th class="last">
									<span class="tbl-hdg"><asp:Label ID="Iro_nm_lbl" runat="server">色</asp:Label></span>
								</th>
								<td class="last">
									<!--- 「色」テキストボックスリードオンリー --->
									<asp:TextBox ID="Iro_nm" CssClass="inpReadonlyLeft inpROHankaku10" runat="server"></asp:TextBox>
								</td>
							</tr>
						</tbody>
					</table>
				<!-- /inner-01 --></div>
			<!-- /str-search-02 --></div>

			<!-------------------------------------------------------------------
									2.明細部
			--------------------------------------------------------------------->
			<input id="M1PageStartRow" type="hidden" runat="server"/>
			<!-- search-result -->
			<div class="str-wrap-result">
				<!-- button -->
				<div id="str-btn-area" class="str-btn-utility">
					<ul>
						<!--明細制御系ボタンを配置する場合はこのulタグの中-->
					</ul>
					<ul>
						<!--帳票／CSV系ボタンを配置する場合はこのulタグの中-->
					</ul>
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
								<asp:Label ID="M1scan_cd_lbl" runat="server">スキャンコード</asp:Label>
							</div>
							<div class="col3">
								<asp:Label ID="M1size_nm_lbl" runat="server">サイズ</asp:Label>
							</div>
							<div class="col4">
								<asp:Label ID="M1lot_su_lbl" runat="server">ロット</asp:Label>
							</div>
							<div class="col5">
								<asp:Label ID="M1haibunkano_su_lbl" runat="server">配分可能数</asp:Label>
							</div>
							<div class="col6">
								<asp:Label ID="M1itemsu_lbl" runat="server">数量</asp:Label>
							</div>

							<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
							<div style="display:none">
								<div class="col7">
									<asp:Label ID="M1selectorcheckbox_lbl" runat="server"></asp:Label>
								</div>
								<div class="col8">
									<asp:Label ID="M1entersyoriflg_lbl" runat="server"></asp:Label>
								</div>
								<div class="col9">
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
											<asp:TextBox ID="M1rowno" CssClass="inpReadonlyRight inpRONum2" runat="server"></asp:TextBox>
										</div>
										<div class="col2 detail_left">
											<!--- 「ｍ１スキャンコード」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1scan_cd" CssClass="inpReadonlyLeft inpRONum13" runat="server"></asp:TextBox>
										</div>
										<div class="col3 detail_left">
											<!--- 「ｍ１サイズ」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1size_nm" CssClass="inpReadonlyLeft inpROHankaku4" runat="server"></asp:TextBox>
										</div>
										<div class="col4 detail_right">
											<!--- 「ｍ１ロット数」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1lot_su" CssClass="inpReadonlyRight inpRONumCma5" runat="server"></asp:TextBox>
										</div>
										<div class="col5 detail_right">
											<!--- 「ｍ１配分可能数」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1haibunkano_su" CssClass="inpReadonlyRight inpRONumCma7" runat="server"></asp:TextBox>
										</div>
										<div class="col6 detail_right">
											<!--- 「ｍ１数量」一行テキストボックス（セパレート日付以外） --->
											<md:MDTextBox ID="M1itemsu" CssClass="inpSu-07" runat="server"></md:MDTextBox>
										</div>

										<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
										<div style="display: none">
											<div class="col7">
												<!--- 「ｍ１選択フラグ(隠し)」チェックボックス --->
												<adv:AdvancedCheckBox ID="M1selectorcheckbox" Text="" CssClass="" runat="server"></adv:AdvancedCheckBox>
											</div>
											<div class="col8">
												<!--- 「Ｍ１確定処理フラグ(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1entersyoriflg" runat="server"></asp:hiddenfield>
											</div>
											<div class="col9">
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
					<div id="str-pager-bottom" class="str-pager-01 pad0">
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
			<!--- 「選択モードNO」隠しフィールド --->
			<asp:hiddenfield ID="Stkmodeno" runat="server"></asp:hiddenfield>
		</div>
	
	</form>
</body>
</html>

