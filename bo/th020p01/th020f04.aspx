<%@ Page language="c#" CodeFile="th020f04.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Th020p01.Page.Th020f04Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">在庫検索</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="th020p01" FormId="th020f04" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/th020f04.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="th020p01" FormId="th020f04" runat="server" />

	<!-- Js業務部品のインポート --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05003.js" charset="UTF-8"></script><!-- 明細背景色変更処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script><!-- 0埋め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05010.js" charset="UTF-8"></script><!-- カンマ編集処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script><!-- 0埋め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->

	<!-- 業務共通コントロールのインポート-->
	<%@ Register TagPrefix="uc" TagName="common" Src="~/pjcommon/businessCommon/usercontrol/boCommonControl.ascx" %>

</head>

<body>
	<form id="Th020f04" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="th020p01" PgName="在庫検索" FormId="th020f04" FormName="在庫検索 明細（消化率）" ></uc:Header>

			<!------------------------------------------
				□業務共通コントロール
			------------------------------------------->
			<uc:common ID="bocommon" runat="server"></uc:common>

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

			<!------------------------------------------
			  ■検索条件領域
			-------------------------------------------->
			<div class="str-search-02">
				<div class="inner-01">
					<table>
						<colgroup>
							<col class="w-type-01"/>
							<col class="w-type-02"/>
							<col class="w-type-01"/>
							<col class="w-type-03"/>
							<col class="w-type-01"/>
							<col class="w-type-04"/>
							<col class="w-type-01"/>
							<col />
						</colgroup>
						<tbody>
							<tr>
								<th class="last">
									<span class="tbl-hdg">
										<asp:Label ID="Kaisya_cd_lbl" runat="server">会社</asp:Label>
									</span>
								</th>
								<td class="last">
									<!--- 「会社コード」テキストボックスリードオンリー --->
									<asp:TextBox ID="Kaisya_cd" CssClass="inpReadonlyLeft inpRONum2" runat="server"></asp:TextBox>
									<!--- 「会社名称」テキストボックスリードオンリー --->
									<asp:TextBox ID="Kaisya_nm" CssClass="inpReadonlyLeft inpROZenkaku10 inpRORightNm" runat="server"></asp:TextBox>
								</td>
								<th class="last">
									<span class="tbl-hdg">
										<asp:Label ID="Bumon_cd_lbl" runat="server">部門</asp:Label>
									</span>
								</th>
								<td class="last" colspan="3">
									<!--- 「部門コード」テキストボックスリードオンリー --->
									<asp:TextBox ID="Bumon_cd" CssClass="inpReadonlyLeft inpRONum4" runat="server"></asp:TextBox>
									<!--- 「部門名」テキストボックスリードオンリー --->
									<asp:TextBox ID="Bumon_nm" CssClass="inpReadonlyLeft inpROZenkaku10 inpRORightNm" runat="server"></asp:TextBox>
								</td>
								<th class="last">
									<span class="tbl-hdg">
										<asp:Label ID="Hinsyu_ryaku_nm_lbl" runat="server">品種</asp:Label>
									</span>
								</th>
								<td class="last">
									<!--- 「品種略名称」テキストボックスリードオンリー --->
									<asp:TextBox ID="Hinsyu_ryaku_nm" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<th class="last">
									<span class="tbl-hdg">
										<asp:Label ID="Burando_cd_lbl" runat="server">ブランド</asp:Label>
									</span>
								</th>
								<td class="last">
									<!--- 「ブランドコード」テキストボックスリードオンリー --->
									<asp:TextBox ID="Burando_cd" CssClass="inpReadonlyLeft inpRONum6" runat="server"></asp:TextBox>
									<!--- 「ブランド名」テキストボックスリードオンリー --->
									<asp:TextBox ID="Burando_nm" CssClass="inpReadonlyLeft inpROHankaku20 inpRORightNm" runat="server"></asp:TextBox>
								</td>
								<th class="last">
									<span class="tbl-hdg">
										<asp:Label ID="Jisya_hbn_lbl" runat="server">自社品番</asp:Label>
									</span>
								</th>
								<td class="last" colspan="3">
									<!--- 「自社品番」テキストボックスリードオンリー --->
									<asp:TextBox ID="Jisya_hbn" CssClass="inpReadonlyLeft inpRONum8" runat="server"></asp:TextBox>
									<!--- 「メーカー品番」テキストボックスリードオンリー --->
									<asp:TextBox ID="Maker_hbn" CssClass="inpReadonlyLeft inpROHankaku30 inpRORightNm" runat="server"></asp:TextBox>
								</td>
								<th class="last">
									<span class="tbl-hdg">
										<asp:Label ID="Syohin_zokusei_lbl" runat="server">コア属性</asp:Label>
									</span>
								</th>
								<td class="last">
									<!--- 「商品属性」テキストボックスリードオンリー --->
									<asp:TextBox ID="Syohin_zokusei" CssClass="inpReadonlyLeft inpROHankaku3" runat="server"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<th class="last">
									<span class="tbl-hdg">
										<asp:Label ID="Syonmk_lbl" runat="server">商品名</asp:Label>
									</span>
								</th>
								<td class="last">
									<!--- 「商品名(カナ)」テキストボックスリードオンリー --->
									<asp:TextBox ID="Syonmk" CssClass="inpReadonlyLeft inpROHankaku20" runat="server"></asp:TextBox>
								</td>
								<th class="last">
									<span class="tbl-hdg">
										<asp:Label ID="Iro_nm_lbl" runat="server">色</asp:Label>
									</span>
								</th>
								<td class="last">
									<!--- 「色」テキストボックスリードオンリー --->
									<asp:TextBox ID="Iro_nm" CssClass="inpReadonlyLeft inpROHankaku10" runat="server"></asp:TextBox>
								</td>
								<th class="last">
									<span class="tbl-hdg">
												<asp:Label ID="Size_nm_lbl" runat="server">サイズ</asp:Label>
									</span>
								</th>
								<td class="last">
									<!--- 「サイズ」テキストボックスリードオンリー --->
									<asp:TextBox ID="Size_nm" CssClass="inpReadonlyLeft inpROHankaku4" runat="server"></asp:TextBox>
								</td>
								<th class="last">
									<span class="tbl-hdg">
										<asp:Label ID="Scan_cd_lbl" runat="server">ｽｷｬﾝｺｰﾄﾞ</asp:Label>
									</span>
								</th>
								<td class="last">
									<!--- 「スキャンコード」テキストボックスリードオンリー --->
									<asp:TextBox ID="Scan_cd" CssClass="inpReadonlyLeft inpRONum13" runat="server"></asp:TextBox>
								</td>
							</tr>
						</tbody>
					</table>
				<!-- /inner-01 --></div>
			<!-- /str-search-02 --></div>

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
					<!-- /utility --></div>
					<div class="inner">
						<div id="str-pager-top" class="str-pager-01 height0 pad0">
			
							<!--- 件数表示部 --->
							<!--<p><adv:PageInfo ID="M1PageInfo" runat="server"></adv:PageInfo></p>-->
							<!--- ページャーを配置する場合はこの中 --->
		
						<!-- /str-pager-01 --></div>

					<!------------------------------------------
					  □一覧領域
					-------------------------------------------->
					<div class="str-result-01">
						<!------------------------------------------
						  □一覧ヘッダ領域
						-------------------------------------------->
						<div class="str-result-hdg-01">
							<div class="col1 col_2dan">
								<asp:Label ID="M1rowno_lbl" runat="server">No.</asp:Label>
							</div>
							<div class="col2 col_2dan">
								<asp:Label ID="M1tenpo_cd_lbl" runat="server">店舗</asp:Label>
							</div>
							<div class="col3 col_2dan">
								<asp:Label ID="M1uriage_su_lbl" runat="server">売上数</asp:Label>
							</div>
							<div class="col4 col_2dan">
								<asp:Label ID="M1freezaiko_su_lbl" runat="server">販売可能在庫</asp:Label>
							</div>
							<div class="col5 col_2dan">
								<asp:Label ID="M1syoka_rtu_lbl" runat="server">消化率</asp:Label>
							</div>
							<div class="col6 col_2dan">
								<asp:Label ID="M1tyobozaiko_su_lbl" runat="server">帳簿在庫数</asp:Label>
							</div>
							<div class="col7">
								<div>引当済み在庫</div>
								<div class="col7-1 headcell">
									<asp:Label ID="M1azukariyoyaku_su_lbl" runat="server">預り予約数</asp:Label>
								</div>
								<div class="col7-2 headcell">
									<asp:Label ID="M1sekiso_su_lbl" runat="server">積送中</asp:Label>
								</div>
								<div class="col7-3 headcell">
									<asp:Label ID="M1tonan_su_lbl" runat="server">盗難品</asp:Label>
								</div>
								<div class="col7-4 headcell">
									<asp:Label ID="M1hyokasonsinsei_su_lbl" runat="server">評価損申請</asp:Label>
								</div>
							</div>
							<div style="display:none">
								<asp:Label ID="M1tenpo_nm_lbl" runat="server"></asp:Label>
								<div class="col12">
									<asp:Label ID="M1selectorcheckbox_lbl" runat="server"></asp:Label>
								</div>
								<div class="col13">
									<asp:Label ID="M1entersyoriflg_lbl" runat="server"></asp:Label>
								</div>
								<div class="col14">
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
									<div id="M1Row" class="str-result-item-01" runat="server">
										<div class="col1 detail_right">
											<!--- 「ｍ１行no」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1rowno" CssClass="inpReadonlyRight inpRONum3" runat="server"></asp:TextBox>
										</div>
										<div class="col2 detail_left">
											<!--- 「ｍ１店舗コード」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1tenpo_cd" CssClass="inpReadonlyLeft inpRONum4" runat="server"></asp:TextBox>
											<!--- 「ｍ１店舗名」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1tenpo_nm" CssClass="inpReadonlyLeft inpROZenkaku10 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col3 detail_right">
											<!--- 「ｍ１売上数」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1uriage_su" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
										</div>
										<div class="col4 detail_right detail_color1">
											<!--- 「ｍ１販売可能在庫数」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1freezaiko_su" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
										</div>
										<div class="col5 detail_right">
											<!--- 「ｍ１消化率」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1syoka_rtu" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
										</div>
										<div class="col6 detail_right">
											<!--- 「ｍ１帳簿在庫数」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1tyobozaiko_su" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
										</div>
										<div class="col7a detail_right">
											<!--- 「ｍ１預り予約数」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1azukariyoyaku_su" CssClass="inpReadonlyRight inpRONumCmaMinus5	" runat="server"></asp:TextBox>
										</div>
										<div class="col7a detail_right">
											<!--- 「ｍ１積送数」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1sekiso_su" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
										</div>
										<div class="col7a detail_right">
											<!--- 「ｍ１盗難品数」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1tonan_su" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
										</div>
										<div class="col7a detail_right">
											<!--- 「ｍ１評価損申請数」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1hyokasonsinsei_su" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
										</div>

										<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
										<div style="display:none">
											<div class="col12">
												<!--- 「ｍ１選択フラグ(隠し)」チェックボックス --->
												<adv:AdvancedCheckBox ID="M1selectorcheckbox" Text="" CssClass="" runat="server"></adv:AdvancedCheckBox>
											</div>
											<div class="col13">
												<!--- 「Ｍ１確定処理フラグ(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1entersyoriflg" runat="server"></asp:hiddenfield>
											</div>
											<div class="col14">
												<!--- 「Ｍ１明細色区分(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1dtlirokbn" runat="server"></asp:hiddenfield>
											</div>
										</div>
										<!--- 隠し項目エリア↑↑↑↑↑↑↑↑↑↑↑↑↑ --->
									<!-- /str-result-item-01 --></div>
								</ItemTemplate>
							</asp:Repeater>
						<!-- /str-result-item-wrap --></div>
						<div class="str-result-ftr-01 adjust-elem-next">
						<!-- /str-result-ftr-01 --></div>
					<!-- /str-result-01 --></div>
				<!-- /inner --></div>
				<div id="footerBtnArea" class="pad0" runat="server">
					<div id="str-pager-bottom" class= "footer str-pager-01 pad0" >
						<!-- ページャ下部にボタンを配置する場合はこの中 -->
						<p><font color="black">販売可能在庫＝帳簿在庫数－引当済み在庫（預り予約数＋積送中＋盗難品＋評価損申請）</font></p>	
					<!-- /str-pager-01 --></div>
				<!-- /str-wrap-result --></div>
			<!-- /str-wrap-result --></div>
		<!-- /wrap --></div>
		
		<!-- 画面上隠しエレメントを格納するエリア-->
		<div id="hiddenElements" style="display:none" runat="server">
			<asp:Label ID="Head_tenpo_cd_lbl" runat="server"></asp:Label>
			<asp:Label ID="Head_tenpo_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Kaisya_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Bumon_nm_lbl" runat="server"></asp:Label>
			<!--- 「品種コード」隠しフィールド --->
			<asp:hiddenfield ID="Hinsyu_cd" runat="server"></asp:hiddenfield>
			<asp:Label ID="Burando_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Maker_hbn_lbl" runat="server"></asp:Label>
		</div>
	
	</form>
</body>
</html>

