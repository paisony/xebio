<%@ Page language="c#" CodeFile="tj190f02.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Tj190p01.Page.Tj190f02Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">臨時棚卸検索</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="tj190p01" FormId="tj190f02" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/tj190f02.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="tj190p01" FormId="tj190f02" runat="server" />

	<!-- Js業務部品のインポート --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05002.js" charset="UTF-8"></script><!-- スキャンコード丸め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05003.js" charset="UTF-8"></script><!-- 明細背景色変更処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script><!-- 0埋め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05009.js" charset="UTF-8"></script><!-- 指示番号丸め処理(返品用) -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05010.js" charset="UTF-8"></script><!-- カンマ編集処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05014.js" charset="UTF-8"></script><!-- 名称取得拡張 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05015.js" charset="UTF-8"></script><!-- 項目入力制御処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05024.js" charset="UTF-8"></script><!-- 数値編集関数群 -->

	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02004.js" charset="UTF-8"></script><!-- スキャンコードチェック処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02011.js" charset="UTF-8"></script><!-- 品種マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02012.js" charset="UTF-8"></script><!-- ブランドマスタ取得 -->

</head>

<body>
	<form id="Tj190f02" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="tj190p01" PgName="臨時棚卸検索" FormId="tj190f02" FormName="臨時棚卸検索 明細" ></uc:Header>


			<!------------------------------------------
				□ヘッダー部
			-------------------------------------------->
			<!--- 「ボタン戻る」ボタン --->
			<p class="headerBackBtn">
				<input type="button" id="Btnback" value="" onserverclick="OnBTNBACK_FRM" runat="server" class="btn type-back"/>
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
						<col class="w-type-05"/>
						<col class="w-type-02"/>
						<col class="w-type-01"/>
						<col class="w-type-03"/>
						<col class="w-type-01"/>
						<col />
					</colgroup>
					<tbody>
						<tr>
							<th class="last"><span class="tbl-hdg"><asp:Label ID="Nyuryoku_ymd_lbl" runat="server">入力日</asp:Label></span></th>
							<td class="last">
								<!--- 「入力日」テキストボックスリードオンリー --->
								<asp:TextBox ID="Nyuryoku_ymd" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox>
							</td>
							<th class="last"><span class="tbl-hdg"><asp:Label ID="Rintana_kanri_no_lbl" runat="server">臨棚管理No</asp:Label></span></th>
							<td class="last">
								<!--- 「臨棚管理№」テキストボックスリードオンリー --->
								<asp:TextBox ID="Rintana_kanri_no" CssClass="inpReadonlyLeft inpRONum6" runat="server"></asp:TextBox>
							</td>
							<th class="last"><span class="tbl-hdg"><asp:Label ID="Loss_kanri_no_lbl" runat="server">ロス管理No</asp:Label></span></th>
							<td class="last">
								<!--- 「ロス管理№」テキストボックスリードオンリー --->
								<asp:TextBox ID="Loss_kanri_no" CssClass="inpReadonlyLeft inpRONum6" runat="server"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<th class="last"><span class="tbl-hdg"><asp:Label ID="Bumon_cd_bo_lbl" runat="server">部門</asp:Label></span></th>
							<!--- 「部門コード」テキストボックスリードオンリー --->	<!--- 「部門名」テキストボックスリードオンリー --->
							<td class="last">
								<asp:TextBox ID="Bumon_cd_bo" CssClass="inpReadonlyLeft inpRONum3" runat="server"></asp:TextBox><asp:TextBox ID="Bumon_nm" CssClass="inpReadonlyLeft inpROHankaku10 inpRORightNm" runat="server"></asp:TextBox>
							</td>
							<th class="last"><span class="tbl-hdg"><asp:Label ID="Nyuryokutan_cd_lbl" runat="server">入力担当者</asp:Label></span></th>
							<!--- 「入力担当者コード」テキストボックスリードオンリー ---><!--- 「入力担当者名称」テキストボックスリードオンリー --->
							<td class="last">
								<asp:TextBox ID="Nyuryokutan_cd" CssClass="inpReadonlyLeft inpRONum7" runat="server"></asp:TextBox><asp:TextBox ID="Nyuryokutan_nm" CssClass="inpReadonlyLeft inpROZenkaku10 inpRORightNm" runat="server"></asp:TextBox>
							</td>
							<th class="last"><span class="tbl-hdg"><asp:Label ID="Losskeisan_ymd_lbl" runat="server">ロス計算日</asp:Label></span></th>
							<!--- 「ロス計算日」テキストボックスリードオンリー ---><!--- 「ロス計算時間」テキストボックスリードオンリー --->
							<td class="last" colspan="2">
								<asp:TextBox ID="Losskeisan_ymd" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox><asp:TextBox ID="Losskeisan_tm" CssClass="inpReadonlyLeft inpROTime inpRORightNm" runat="server"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<!--- 「品種指定フラグ」ラジオボタン --->
							<td class="last" colspan="2">
								<adv:ConditionRBList ID="Hinsyu_sitei_flg" ConditionName="hinsyu_sitei_flg" RepeatDirection="Horizontal" CssClass="str-radio-table" runat="server"></adv:ConditionRBList>
							</td>
							<th class="last">
								<span class="tbl-hdg"><asp:Label ID="Hinsyu_cd_lbl" runat="server">品種</asp:Label></span>
							</th>
							<td class="last" colspan="2">
								<!--- 「品種コード」一行テキストボックス（セパレート日付以外） ---><!--- 「品種コードボタン」ボタン ---><!--- 「品種略名称」テキストボックスリードオンリー --->
								<span class="icon-in"><md:MDTextBox ID="Hinsyu_cd" CssClass="inpSerch inpHinshu" runat="server"></md:MDTextBox><input type="button" id="Btnhinsyu_cd" name="Btnhinsyu_cd" value="" runat="server" class="icon-search"/></span>
								<asp:TextBox ID="Hinsyu_ryaku_nm" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<td class="last" colspan="2">
								<adv:ConditionRBList ID="Burando_sitei_flg" ConditionName="burando_sitei_flg" RepeatDirection="Horizontal" CssClass="str-radio-table" runat="server"></adv:ConditionRBList>
							</td>
							<th class="last">
								<span class="tbl-hdg"><asp:Label ID="Burando_cd_lbl" runat="server">ブランド</asp:Label></span>
							</th>
							<td class="last" colspan="4">
								<!--- 「ブランドコード」一行テキストボックス（セパレート日付以外） ---><!--- 「ブランドコードボタン」ボタン ---><!--- 「ブランド名」テキストボックスリードオンリー --->
								<span class="icon-in"><md:MDTextBox ID="Burando_cd" CssClass="inpSerch inpBrand" runat="server"></md:MDTextBox><input type="button" id="Btnburando_cd" name="Btnburando_cd" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="Burando_nm" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
								<!--- 「ブランドコード1」一行テキストボックス（セパレート日付以外） ---><!--- 「ブランドコード1ボタン」ボタン ---><!--- 「ブランド名1」テキストボックスリードオンリー --->
								<span class="icon-in"><md:MDTextBox ID="Burando_cd1" CssClass="inpSerch inpBrand" runat="server"></md:MDTextBox><input type="button" id="Btnburando_cd1" name="Btnburando_cd1" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="Burando_nm1" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
								<!--- 「ブランドコード2」一行テキストボックス（セパレート日付以外） ---><!--- 「ブランドコード2ボタン」ボタン ---><!--- 「ブランド名2」テキストボックスリードオンリー --->
								<span class="icon-in"><md:MDTextBox ID="Burando_cd2" CssClass="inpSerch inpBrand" runat="server"></md:MDTextBox><input type="button" id="Btnburando_cd2" name="Btnburando_cd2" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="Burando_nm2" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
								<!--- 「ブランドコード3」一行テキストボックス（セパレート日付以外） ---><!--- 「ブランドコード3ボタン」ボタン ---><!--- 「ブランド名3」テキストボックスリードオンリー --->
								<span class="icon-in"><md:MDTextBox ID="Burando_cd3" CssClass="inpSerch inpBrand" runat="server"></md:MDTextBox><input type="button" id="Btnburando_cd3" name="Btnburando_cd3" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="Burando_nm3" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<td class="last" colspan="3"></td>
							<td class="last" colspan="4">
								<!--- 「ブランドコード4」一行テキストボックス（セパレート日付以外） ---><!--- 「ブランドコード4ボタン」ボタン ---><!--- 「ブランド名4」テキストボックスリードオンリー --->
								<span class="icon-in"><md:MDTextBox ID="Burando_cd4" CssClass="inpSerch inpBrand" runat="server"></md:MDTextBox><input type="button" id="Btnburando_cd4" name="Btnburando_cd4" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="Burando_nm4" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
								<!--- 「ブランドコード5」一行テキストボックス（セパレート日付以外） ---><!--- 「ブランドコード5ボタン」ボタン ---><!--- 「ブランド名5」テキストボックスリードオンリー --->
								<span class="icon-in"><md:MDTextBox ID="Burando_cd5" CssClass="inpSerch inpBrand" runat="server"></md:MDTextBox><input type="button" id="Btnburando_cd5" name="Btnburando_cd5" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="Burando_nm5" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
								<!--- 「ブランドコード6」一行テキストボックス（セパレート日付以外） ---><!--- 「ブランドコード6ボタン」ボタン ---><!--- 「ブランド名6」テキストボックスリードオンリー --->
								<span class="icon-in"><md:MDTextBox ID="Burando_cd6" CssClass="inpSerch inpBrand" runat="server"></md:MDTextBox><input type="button" id="Btnburando_cd6" name="Btnburando_cd6" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="Burando_nm6" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
								<span class="icon-in"><md:MDTextBox ID="Burando_cd7" CssClass="inpSerch inpBrand" runat="server"></md:MDTextBox><input type="button" id="Btnburando_cd7" name="Btnburando_cd7" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="Burando_nm7" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
							</td>
						</tr>
					</tbody>
				</table>
			<!-- /inner-01 --></div>
		<!-- /str-search-02 --></div>

		<div class="trigger-search-01">
			<a href="#"></a>
		<!-- /trigger-search-01 --></div>

		<!------------------------------------------
		  ■一覧領域
		-------------------------------------------->
		<input id="M1PageStartRow" type="hidden" runat="server"/>
		<div class="str-wrap-result">

			<!------------------------------------------
			  □ボタン領域
			-------------------------------------------->
			<div id="str-btn-area" class="str-btn-utility">
				<ul>
					<!--明細制御系ボタンを配置する場合はこのulタグの中-->
					<li><!--- 「行追加ボタン」ボタン --->
						<span><label><input type="button" id="Btnrowins" value="" onserverclick="OnBTNROWINS_MADD" runat="server" class="icon-utility-06"/>行追加</label></span>
					</li>
					<li><!--- 「サイズ選択ボタン」ボタン --->
						<span><label><input type="button" id="Btnsizstk" name="Btnsizstk" value="" onserverclick="OnBTNSIZSTK_FRM" runat="server" class="icon-utility-07"/>サイズ選択</label></span>
					</li>
					<li><!--- 「行削除ボタン」ボタン --->
						<span><label><input type="button" id="Btnrowdel" value="" onserverclick="OnBTNROWDEL_FRM" runat="server" class="icon-utility-03"/>行削除</label></span>
					</li>
				</ul>
				<ul>

				</ul>
			<!-- /utility --></div>

			<div class="inner">

				<!------------------------------------------
				  □ページャ上部領域
				-------------------------------------------->
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
						<div class="col1 col_2dan"><asp:Label ID="M1rowno_lbl" runat="server">No.</asp:Label></div>
						<div class="col2">
							<div><asp:Label ID="M1hinsyu_ryaku_nm_lbl" runat="server">品種</asp:Label></div>
							<div><asp:Label ID="M1burando_nm_lbl" runat="server">ブランド</asp:Label></div>
						</div>
						<div class="col3 col_2dan"><asp:Label ID="M1jisya_hbn_lbl" runat="server">自社品番</asp:Label></div>
						<div class="col4">
							<div><asp:Label ID="M1maker_hbn_lbl" runat="server">メーカー品番</asp:Label></div>
							<div><asp:Label ID="M1syonmk_lbl" runat="server">商品名</asp:Label></div>
						</div>
						<div class="col5">
							<div><asp:Label ID="M1iro_nm_lbl" runat="server">色</asp:Label></div>
							<div><asp:Label ID="M1size_nm_lbl" runat="server">サイズ</asp:Label></div>
						</div>
						<div class="col6 col_2dan"><asp:Label ID="M1scan_cd_lbl" runat="server">スキャンコード</asp:Label></div>
						<div class="col7 col_2dan"><asp:Label ID="M1hyoka_tnk_lbl" runat="server">評価単価</asp:Label></div>
						<div class="col8">
							<div><asp:Label ID="M1tanajityobo_su_lbl" runat="server">棚時帳簿数</asp:Label></div>
							<div><asp:Label ID="M1tanajisekiso_su_lbl" runat="server">棚時積送数</asp:Label></div>
						</div>
						<div class="col9 col_2dan"><asp:Label ID="M1jitana_su_lbl" runat="server">実棚数</asp:Label></div>
						<div class="col10 col_2dan"><asp:Label ID="M1loss_su_lbl" runat="server">ロス数</asp:Label></div>
						<div class="col11 col_2dan"><asp:Label ID="M1loss_kin_lbl" runat="server">ロス金額</asp:Label></div>
						<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
						<div style="display:none">
							<asp:Label ID="M1jitana_su1_hdn_lbl" runat="server"></asp:Label>
							<div class="col17">
								<asp:Label ID="M1selectorcheckbox_lbl" runat="server"></asp:Label>
							</div>
							<div class="col18">
								<asp:Label ID="M1entersyoriflg_lbl" runat="server"></asp:Label>
							</div>
							<div class="col19">
								<asp:Label ID="M1dtlirokbn_lbl" runat="server"></asp:Label>
							</div>
							<asp:Label ID="M1tanajityobo_su_hdn_lbl" runat="server"></asp:Label>
							<asp:Label ID="M1tanajisekiso_su_hdn_lbl" runat="server"></asp:Label>
						</div>
						<!--- 隠し項目エリア↑↑↑↑↑↑↑↑↑↑↑↑↑ --->
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
									<div class="col1 detail_right col_2dan">
										<!--- 「ｍ１行no」テキストボックスリードオンリー --->
										<asp:TextBox ID="M1rowno" CssClass="inpReadonlyRight inpRONum5" runat="server"></asp:TextBox>
									</div>
									<div class="col2 detail_left">
										<!--- 「ｍ１品種略名称」テキストボックスリードオンリー --->
										<div><asp:TextBox ID="M1hinsyu_ryaku_nm" CssClass="inpReadonlyLeft inpROHankaku10 tooltip" runat="server"></asp:TextBox></div>
										<!--- 「ｍ１ブランド名」テキストボックスリードオンリー --->
										<div><asp:TextBox ID="M1burando_nm" CssClass="inpReadonlyLeft inpROHankaku12 tooltip" runat="server"></asp:TextBox></div>
									</div>
									<div class="col3 detail_center col_2dan">
										<!--- 「ｍ１自社品番」テキストボックスリードオンリー --->
										<asp:TextBox ID="M1jisya_hbn" CssClass="inpReadonlyLeft inpRONum8" runat="server"></asp:TextBox>
									</div>
									<div class="col4 detail_left">
										<!--- 「ｍ１メーカー品番」テキストボックスリードオンリー --->
										<!--- 「ｍ１商品名(カナ)」テキストボックスリードオンリー --->
										<div><asp:TextBox ID="M1maker_hbn" CssClass="inpReadonlyLeft inpROHankaku30 tooltip" runat="server"></asp:TextBox></div>
										<div><asp:TextBox ID="M1syonmk" CssClass="inpReadonlyLeft inpROHankaku20 tooltip" runat="server"></asp:TextBox></div>
									</div>
									<div class="col5 detail_left">
										<!--- 「ｍ１色」テキストボックスリードオンリー --->
										<!--- 「ｍ１サイズ」テキストボックスリードオンリー --->
										<div><asp:TextBox ID="M1iro_nm" CssClass="inpReadonlyLeft inpROHankaku6 tooltip" runat="server"></asp:TextBox></div>
										<div><asp:TextBox ID="M1size_nm" CssClass="inpReadonlyLeft inpROHankaku4 tooltip" runat="server"></asp:TextBox></div>
									</div>
									<div class="col6 col_2dan detail_center">
										<!--- 「ｍ１スキャンコード」一行テキストボックス（セパレート日付以外） --->
										<md:MDTextBox ID="M1scan_cd" CssClass="inpScan" runat="server"></md:MDTextBox>
									</div>
									<div class="col7 detail_right col_2dan">
										<!--- 「ｍ１評価単価」テキストボックスリードオンリー --->
										<asp:TextBox ID="M1hyoka_tnk" CssClass="inpReadonlyRight inpRONumCma7" runat="server"></asp:TextBox>
									</div>
									<div class="col8 detail_right">
										<!--- 「ｍ１棚時帳簿数」テキストボックスリードオンリー --->
										<!--- 「ｍ１棚時積送数」テキストボックスリードオンリー --->
										<div><asp:TextBox ID="M1tanajityobo_su" CssClass="inpReadonlyRight inpRONumCmaMinus7" runat="server"></asp:TextBox></div>
										<div><asp:TextBox ID="M1tanajisekiso_su" CssClass="inpReadonlyRight inpRONumCmaMinus7" runat="server"></asp:TextBox></div>
									</div>
									<div class="col9 detail_right col_2dan">
										<!--- 「ｍ１実棚数」一行テキストボックス（セパレート日付以外） --->
										<md:MDTextBox ID="M1jitana_su" CssClass="inpSu-04" runat="server"></md:MDTextBox>
									</div>
									
									<div class="col10 detail_right col_2dan">
										<!--- 「ｍ１ロス数」テキストボックスリードオンリー --->
										<asp:TextBox ID="M1loss_su" CssClass="inpReadonlyRight inpRONumCmaMinus7" runat="server"></asp:TextBox>
									</div>
									<div class="col11 detail_right col_2dan">
										<!--- 「ｍ１ロス金額」テキストボックスリードオンリー --->
										<asp:TextBox ID="M1loss_kin" CssClass="inpReadonlyRight inpRONumCmaMinus8" runat="server"></asp:TextBox>
									</div>

									<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
									<div style="display:none">
										<!--- 「Ｍ１実棚数（隠し）」隠しフィールド --->
										<asp:hiddenfield ID="M1jitana_su1_hdn" runat="server"></asp:hiddenfield>
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
										<!--- 「Ｍ１棚時帳簿数（隠し)」隠しフィールド --->
										<asp:hiddenfield ID="M1tanajityobo_su_hdn" runat="server"></asp:hiddenfield>
										<!--- 「Ｍ１棚時積送数(隠し)」隠しフィールド --->
										<asp:hiddenfield ID="M1tanajisekiso_su_hdn" runat="server"></asp:hiddenfield>
									</div>
									<!--- 隠し項目エリア↑↑↑↑↑↑↑↑↑↑↑↑↑ --->
								<!-- /str-result-item-01 --></div>
							</ItemTemplate>
						</asp:Repeater>
					<!-- /str-result-item-wrap --></div>

					<div class="str-result-ftr-01 adjust-elem-next">
						<div class="col1 detail_left">&nbsp;</div>
						<div class="col2 detail_left">&nbsp;</div>
						<div class="col3 detail_left">&nbsp;</div>
						<div class="col4 detail_left">&nbsp;</div>
						<div class="col5 detail_left">&nbsp;</div>
						<div class="col6 detail_left">&nbsp;</div>
						<div class="col7 detail_ftr_title"><asp:Label ID="Gokeitanajityobo_su_lbl" runat="server">合計</asp:Label></div>
						<div class="col8 detail_right_ftr">
							<!--- 「合計棚時帳簿数」テキストボックスリードオンリー --->
							<div class="col8 detail_right_ftr borderleft"><asp:TextBox ID="Gokeitanajityobo_su" CssClass="inpReadonlyRight inpRONumCmaMinus8" runat="server"></asp:TextBox></div>
							<!--- 「合計棚時積送数」テキストボックスリードオンリー --->
							<div class="col8 detail_right_ftr"><asp:TextBox ID="Gokeitanajisekiso_su" CssClass="inpReadonlyRight inpRONumCmaMinus8" runat="server"></asp:TextBox></div>
						</div>
						<div class="col9 detail_right_ftr">
							<!--- 「合計実棚数」テキストボックスリードオンリー --->
							<div><asp:TextBox ID="Gokeijitana_su" CssClass="inpReadonlyRight inpRONumCmaMinus6" runat="server"></asp:TextBox></div>
							<div>&nbsp;</div>
						</div>
						<div class="col10 detail_right_ftr">
							<!--- 「合計ロス数」テキストボックスリードオンリー --->
							<div class="col10 detail_right_ftr"><asp:TextBox ID="Gokeiloss_su" CssClass="inpReadonlyRight inpRONumCmaMinus8" runat="server"></asp:TextBox></div>
							<div>&nbsp;</div>
						</div>
						<div class="col11 detail_right_ftr">
							<!--- 「合計ロス金額」テキストボックスリードオンリー --->
							<div class="col11 detail_right_ftr"><asp:TextBox ID="Gokeiloss_kin" CssClass="inpReadonlyRight inpRONumCmaMinus9" runat="server"></asp:TextBox></div>
							<div>&nbsp;</div>
						</div>
					<!-- /str-result-ftr-01 --></div>
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
			<asp:Label ID="Head_tenpo_cd_lbl" runat="server"></asp:Label>
			<asp:Label ID="Head_tenpo_nm_lbl" runat="server"></asp:Label>
			<!--- 「モードNO」隠しフィールド --->
			<asp:hiddenfield ID="Modeno" runat="server"></asp:hiddenfield>
			<!--- 「選択モードNO」隠しフィールド --->
			<asp:hiddenfield ID="Stkmodeno" runat="server"></asp:hiddenfield>
			<asp:Label ID="Bumon_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Nyuryokutan_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Losskeisan_tm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Hinsyu_sitei_flg_lbl" runat="server"></asp:Label>
			<asp:Label ID="Hinsyu_ryaku_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Burando_sitei_flg_lbl" runat="server"></asp:Label>
			<asp:Label ID="Burando_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Burando_cd1_lbl" runat="server">ブランド1</asp:Label>
			<asp:Label ID="Burando_nm1_lbl" runat="server"></asp:Label>
			<asp:Label ID="Burando_cd2_lbl" runat="server">ブランド2</asp:Label>
			<asp:Label ID="Burando_nm2_lbl" runat="server"></asp:Label>
			<asp:Label ID="Burando_cd3_lbl" runat="server">ブランド3</asp:Label>
			<asp:Label ID="Burando_nm3_lbl" runat="server"></asp:Label>
			<asp:Label ID="Burando_cd4_lbl" runat="server">ブランド4</asp:Label>
			<asp:Label ID="Burando_nm4_lbl" runat="server"></asp:Label>
			<asp:Label ID="Burando_cd5_lbl" runat="server">ブランド5</asp:Label>
			<asp:Label ID="Burando_nm5_lbl" runat="server"></asp:Label>
			<asp:Label ID="Burando_cd6_lbl" runat="server">ブランド6</asp:Label>
			<asp:Label ID="Burando_nm6_lbl" runat="server"></asp:Label>
			<asp:Label ID="Burando_cd7_lbl" runat="server">ブランド7</asp:Label>
			<asp:Label ID="Burando_nm7_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokeitanajisekiso_su_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokeijitana_su_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokeiloss_su_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokeiloss_kin_lbl" runat="server"></asp:Label>
			<!--- 「店舗コード隠し」隠しフィールド --->
			<asp:hiddenfield ID="Tenpo_cd_hdn" runat="server"></asp:hiddenfield>


		</div>
	
	</form>
</body>
</html>

