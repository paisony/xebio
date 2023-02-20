<%@ Page language="c#" CodeFile="ta030f02.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Ta030p01.Page.Ta030f02Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">依頼検索</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="ta030p01" FormId="ta030f02" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/ta030f02.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="ta030p01" FormId="ta030f02" runat="server" />

	<!-- Js業務部品のインポート --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script><!-- 0埋め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05003.js" charset="UTF-8"></script><!-- 明細背景色変更処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05010.js" charset="UTF-8"></script><!-- カンマ編集処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
</head>

<body>
	<form id="Ta030f02" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">

						
			<uc:Header ID="header" runat="server" PgId="ta030p01" PgName="依頼検索" FormId="ta030f02" FormName="依頼検索 明細" ></uc:Header>

			<!------------------------------------------
				□ヘッダー部
			-------------------------------------------->

			<!--- 「ボタン戻る」ボタン --->
			<p class="headerBackBtn">
				<input type="button" id="Btnback" value="戻る" onserverclick="OnBTNBACK_FRM" runat="server" class="btn type-back"/>
			</p>

			<!--- 「ヘッダ店舗コード」テキストボックスリードオンリー --->
			<!--- 「ヘッダ店舗名」テキストボックスリードオンリー --->
			<p class="headerTenpo">
				<asp:TextBox ID="Head_tenpo_cd" CssClass="inpReadonlyLeft inpHeaderTenpoDisabled" runat="server"></asp:TextBox>
				<asp:TextBox ID="Head_tenpo_nm" CssClass="inpReadonlyLeft inpHeaderTenpoNm" runat="server"></asp:TextBox>
			</p>

		
		
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
					</div>
				<!-- /utility -->
				</div>

				<!------------------------------------------
					□明細部
				-------------------------------------------->

				<div class="inner">
					<div id="str-pager-top" class="str-pager-01">
		
						<!--- 件数表示部 --->
						<p><adv:PageInfo ID="M1PageInfo" runat="server"></adv:PageInfo></p>
						<!--- ページャーを配置する場合はこの中 --->
						<div>
							<!--- 「ページャ」カスタムページャー --->
							<cc:custompager ID="Pgr" OnPageIndexChanged="OnPGR_PGN" runat="server"></cc:custompager>
						</div>		
					<!-- /str-pager-01 -->
					</div>

					<!--一覧-->
					<div class="str-result-01">
					<%-- 明細ヘッダ --%>
						<div class="str-result-hdg-01">
							<div class="col1 col_2dan">
								<asp:Label ID="M1rowno_lbl" runat="server">No.</asp:Label>
							</div>
							<div class="col2">
								<div class="col2-1 headcell"><asp:Label ID="M1hojuirai_kbn_nm_lbl" runat="server">区分</asp:Label></div>
								<div class="col2-2 headcell"><asp:Label ID="M1sinsei_jotainm_lbl" runat="server">状態</asp:Label></div>
								<div class="col2 headcell"><asp:Label ID="M1bumon_cd_bo_lbl" runat="server">部門</asp:Label></div>
							</div>
							<div class="col3">
								<div><asp:Label ID="M1hinsyu_ryaku_nm_lbl" runat="server">品種</asp:Label></div>
								<div><asp:Label ID="M1burando_nm_lbl" runat="server">ブランド</asp:Label></div>
							</div>
							<div class="col4">
								<div><asp:Label ID="M1jisya_hbn_lbl" runat="server">自社品番</asp:Label></div>
								<div><asp:Label ID="M1syohin_zokusei_lbl" runat="server">コア</asp:Label></div>
							</div>
							<div class="col5">
								<div><asp:Label ID="M1maker_hbn_lbl" runat="server">メーカー品番</asp:Label></div>
								<div><asp:Label ID="M1syonmk_lbl" runat="server">商品名</asp:Label></div>
							</div>
							<div class="col6">
								<div><asp:Label ID="M1iro_nm_lbl" runat="server">色</asp:Label></div>
								<div><asp:Label ID="M1size_nm_lbl" runat="server">サイズ</asp:Label></div>
							</div>							
							<div class="col7 col_2dan">
								<asp:Label ID="M1scan_cd_lbl" runat="server">スキャンコード</asp:Label>
							</div>
							<div class="col8 col_2dan">
								<asp:Label ID="M1itemsu_lbl" runat="server">数量</asp:Label>
							</div>
							<div class="col9 col_2dan">
								<asp:Label ID="M1kingaku_lbl" runat="server">金額</asp:Label>
							</div>
							<div class="col10">
								<div><asp:Label ID="M1hattyu_ymd_lbl" runat="server">発注日</asp:Label></div>
								<div><asp:Label ID="M1hanbaiin_nm_lbl" runat="server">担当者</asp:Label></div>
							</div>
							<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
							<div style="display:none">
								<div class="col19">
									<asp:Label ID="M1selectorcheckbox_lbl" runat="server">選択フラグ(隠し)</asp:Label>
								</div>
								<div class="col20">
									<asp:Label ID="M1entersyoriflg_lbl" runat="server">確定処理フラグ(隠し)</asp:Label>
								</div>
								<div class="col21">
									<asp:Label ID="M1dtlirokbn_lbl" runat="server">明細色区分(隠し)</asp:Label>
								</div>
							</div>
						<!-- /str-result-hdg-01 --></div>
						<div id="str-result-item-wrap" class="adjust-elem">
							<asp:Repeater ID="M1" runat="server">
								<HeaderTemplate>
								</HeaderTemplate>
								<ItemTemplate>
									<div id="M1Row" class="str-result-item-01" runat="server">
										<div class="col1 col_2dan detail_right">
											<!--- 「ｍ１行no」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1rowno" CssClass="inpReadonlyRight inpRONum4" runat="server"></asp:TextBox>
										</div>
										<div class="col2 detail_left">											
												<!--- 「ｍ１補充依頼区分名称」テキストボックスリードオンリー --->
												<div class="col2-1 headcell"><asp:TextBox ID="M1hojuirai_kbn_nm" CssClass="inpReadonlyLeft inpROZenkaku7 tooltip" runat="server"></asp:TextBox></div>											
												<!--- 「ｍ１申請状態名称」テキストボックスリードオンリー --->
												<div class="col2-2 headcell"><asp:TextBox ID="M1sinsei_jotainm" CssClass="inpReadonlyLeft inpROZenkaku3 tooltip" runat="server"></asp:TextBox></div>
												<!--- 「ｍ１部門コード」テキストボックスリードオンリー ---><!--- 「ｍ１部門カナ名」テキストボックスリードオンリー --->	
												<asp:TextBox ID="M1bumon_cd_bo" CssClass="inpReadonlyRight inpRONum3" runat="server"></asp:TextBox><asp:TextBox ID="M1bumonkana_nm" CssClass="inpReadonlyLeft inpRORightNm inpROHankaku12 tooltip" runat="server"></asp:TextBox>												
										</div>
										<div class="col3 detail_left ">
											<!--- 「ｍ１品種略名称」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1hinsyu_ryaku_nm" CssClass="inpReadonlyLeft inpROZenkaku15 tooltip" runat="server"></asp:TextBox></div>
											<!--- 「ｍ１ブランド名」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1burando_nm" CssClass="inpReadonlyLeft inpROHankaku14 tooltip" runat="server"></asp:TextBox></div>
										</div>
										<div class="col4 detail_left">
											<!--- 「ｍ１自社品番」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1jisya_hbn" CssClass="inpReadonlyLeft inpRONum8" runat="server"></asp:TextBox></div>
											<!--- 「ｍ１商品属性」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1syohin_zokusei" CssClass="inpReadonlyLeft inpROHankaku3 tooltip" runat="server"></asp:TextBox></div>
										</div>
										<div class="col5 detail_left">
											<!--- 「ｍ１メーカー品番」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1maker_hbn" CssClass="inpReadonlyLeft inpROHankaku30 tooltip" runat="server"></asp:TextBox></div>
											<!--- 「ｍ１商品名(カナ)」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1syonmk" CssClass="inpReadonlyLeft inpROHankaku20 tooltip" runat="server"></asp:TextBox></div>
										</div>
										<div class="col6 detail_left">
											<!--- 「ｍ１色」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1iro_nm" CssClass="inpReadonlyLeft inpROHankaku6 tooltip" runat="server"></asp:TextBox></div>
											<!--- 「ｍ１サイズ」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1size_nm" CssClass="inpReadonlyLeft  inpROHankaku4 tooltip" runat="server"></asp:TextBox></div>
										</div>
										<div class="col7 col_2dan detail_left">
											<!--- 「ｍ１スキャンコード」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1scan_cd" CssClass="inpReadonlyLeft inpRONum18" runat="server"></asp:TextBox>
										</div>
										<div class="col8 col_2dan detail_right">
											<!--- 「ｍ１数量」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1itemsu" CssClass="inpReadonlyRight inpRONumCma9" runat="server"></asp:TextBox>
										</div>
										<div class="col9 col_2dan detail_right">
											<!--- 「ｍ１金額」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1kingaku" CssClass="inpReadonlyRight inpRONumCma9" runat="server"></asp:TextBox>
										</div>
										<div class="col10 detail_left">
											<!--- 「ｍ１発注日」テキストボックスリードオンリー --->
											<div class ="detail_center"><asp:TextBox ID="M1hattyu_ymd" CssClass="inpReadonlyCenter inpRODate" runat="server"></asp:TextBox></div>
											<!--- 「ｍ１担当者名」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1hanbaiin_nm" CssClass="inpReadonlyLeft inpROZenkaku8 tooltip" runat="server"></asp:TextBox></div>
										</div>
										<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
										<div style="display: none">
											<div class="col19">
												<!--- 「ｍ１選択フラグ(隠し)」チェックボックス --->
												<adv:AdvancedCheckBox ID="M1selectorcheckbox" Text="選択フラグ(隠し)" CssClass="" runat="server"></adv:AdvancedCheckBox>
											</div>
											<div class="col20">
												<!--- 「Ｍ１確定処理フラグ(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1entersyoriflg" runat="server"></asp:hiddenfield>
											</div>
											<div class="col21">
												<!--- 「Ｍ１明細色区分(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1dtlirokbn" runat="server"></asp:hiddenfield>
											</div>
										</div>
										<!--- 隠し項目エリア↑↑↑↑↑↑↑↑↑↑↑↑↑ --->
									<!-- /str-result-item-01 --></div>
								</ItemTemplate>
							</asp:Repeater>
					<!-- /str-result-item-wrap -->
					</div>

					<div class="str-result-ftr-01 adjust-elem-next">
						<div class="col1 detail_left">&nbsp;</div>
						<div class="col2 detail_left">&nbsp;</div>
						<div class="col3 detail_left">&nbsp;</div>
						<div class="col4 detail_left">&nbsp;</div>
						<div class="col5 detail_left">&nbsp;</div>
						<div class="col6 detail_left">&nbsp;</div>
						<div class="col7 detail_ftr_title">合計</div>
						<!--- 「合計数量」テキストボックスリードオンリー --->
						<div class="col8 detail_ftr"><asp:TextBox ID="Gokei_itemsu" CssClass="inpReadonlyRight inpRONumCma9" runat="server"></asp:TextBox></div>
						<!--- 「合計金額」テキストボックスリードオンリー --->
						<div class="col9 detail_ftr"><asp:TextBox ID="Gokei_kingaku" CssClass="inpReadonlyRight inpRONumCma9" runat="server"></asp:TextBox></div>
					<!-- /str-result-ftr-01 -->
					</div>

				<!-- /str-result-01 -->
				</div>

					<!------------------------------------------
					  □ページャ下部領域
					-------------------------------------------->
					<span class="adjust-elem-next"></span>
				<!-- /inner -->
				</div>

		<!-- /str-wrap-result -->
		</div>
		


		<!-- /wrap --></div>	
		
		<!-- 画面上隠しエレメントを格納するエリア-->
		<div id="hiddenElements" style="display:none" runat="server">
		     <asp:Label ID="Head_tenpo_cd_lbl" runat="server"></asp:Label>
			 <asp:Label ID="Head_tenpo_nm_lbl" runat="server"></asp:Label>

			<!--- 「選択モードNO」隠しフィールド --->
			<asp:hiddenfield ID="Stkmodeno" runat="server"></asp:hiddenfield>
			<asp:Label ID="M1bumonkana_nm_lbl" runat="server"></asp:Label>

			<asp:Label ID="Gokei_itemsu_lbl" runat="server">合計</asp:Label>
			<asp:Label ID="Gokei_kingaku_lbl" runat="server"></asp:Label>											

		</div>
	
	</form>
</body>
</html>

