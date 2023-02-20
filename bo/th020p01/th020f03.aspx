<%@ Page language="c#" CodeFile="th020f03.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Th020p01.Page.Th020f03Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">在庫検索</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="th020p01" FormId="th020f03" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/th020f03.css">

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

	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="th020p01" FormId="th020f03" runat="server" />
</head>

<body>
	<form id="Th020f03" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="th020p01" PgName="在庫検索" FormId="th020f03" FormName="在庫検索 明細（エリア別）" ></uc:Header>

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
										<asp:Label ID="Zentenzaiko_su_lbl" runat="server">全店在庫数</asp:Label>
									</span>
								</th>
								<td class="last">
									<!--- 「全店在庫数」テキストボックスリードオンリー --->
									<asp:TextBox ID="Zentenzaiko_su" CssClass="inpReadonlyLeft inpRONumCmaMinusMinus8" runat="server"></asp:TextBox>
								</td>
								<th class="last">
									<span class="tbl-hdg">
										<asp:Label ID="Zentensyoka_rtu_lbl" runat="server">全店消化率</asp:Label>
									</span>
								</th>
								<td class="last">
									<!--- 「全店消化率」テキストボックスリードオンリー --->
									<asp:TextBox ID="Zentensyoka_rtu" CssClass="inpReadonlyLeft inpRONumCmaMinus4" runat="server"></asp:TextBox>
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
				<!-- /utility --></div>

				<div class="inner">
					<!------------------------------------------
					  □ページャ上部領域
					-------------------------------------------->
					<div class="str-pager-02">
						<div class="pager-02">
							<ul>
								<!--明細制御系ボタンを配置する場合はこのulタグの中-->
								<li></li>
								<li class="prev"><!--- 「前へリンク」ボタン --->
									<input type="button" id="Btnprev" value="前へ" onserverclick="OnBTNPREV_FRM" runat="server" class="meisaiLink"/>
								</li>
								<li><span>&nbsp</span></li>
								<li><!--- 「次へリンク」ボタン --->
									<input type="button" id="Btnnext" value="次へ" onserverclick="OnBTNNEXT_FRM" runat="server" class="meisaiLink"/>
								</li>
							</ul>
						<!--- 件数表示部 --->
						<!---<p><adv:PageInfo ID="M1PageInfo" runat="server"></adv:PageInfo></p>--->
						<!--- ページャーを配置する場合はこの中 --->
						<!-- /pager-02 --></div>
					<!-- /str-pager-02 --></div>

					<!------------------------------------------
					  □一覧領域
					-------------------------------------------->
					<div class="str-result-01">
						<!------------------------------------------
						  □一覧ヘッダ領域
						-------------------------------------------->
						<div class="str-result-hdg-01">
							<div class="col1"><asp:Label ID="M1rowno_lbl" runat="server">No.</asp:Label></div>
							<div class="col2"><asp:Label ID="M1area_ryaku_nm_lbl" runat="server">エリア</asp:Label></div>
							<div class="col3"><asp:Label ID="M1gokei_suryo_lbl" runat="server">合計</asp:Label></div>
							<div class="col4"><asp:Label ID="M1syoka_rtu_lbl" runat="server">消化率</asp:Label></div>
							<div class="col5 col5-title">
								<!--- 「明細ヘッダ色１」テキストボックスリードオンリー --->
								<asp:TextBox ID="Meisaihead_iro_nm1" CssClass="inpReadonlyCenter size-link" runat="server"></asp:TextBox>
								<!--- 「明細ヘッダ色１６」テキストボックスリードオンリー --->
								<asp:TextBox ID="Meisaihead_iro_nm16" CssClass="inpReadonlyCenter size-link" runat="server"></asp:TextBox>
							</div>
							<div class="col5 col5-title">
								<!--- 「明細ヘッダ色２」テキストボックスリードオンリー --->
								<asp:TextBox ID="Meisaihead_iro_nm2" CssClass="inpReadonlyCenter size-link" runat="server"></asp:TextBox>
								<!--- 「明細ヘッダ色１７」テキストボックスリードオンリー --->
								<asp:TextBox ID="Meisaihead_iro_nm17" CssClass="inpReadonlyCenter size-link" runat="server"></asp:TextBox>
							</div>
							<div class="col5 col5-title">
								<!--- 「明細ヘッダ色３」テキストボックスリードオンリー --->
								<asp:TextBox ID="Meisaihead_iro_nm3" CssClass="inpReadonlyCenter size-link" runat="server"></asp:TextBox>
								<!--- 「明細ヘッダ色１８」テキストボックスリードオンリー --->
								<asp:TextBox ID="Meisaihead_iro_nm18" CssClass="inpReadonlyCenter size-link" runat="server"></asp:TextBox>
							</div>
							<div class="col5 col5-title">
								<!--- 「明細ヘッダ色４」テキストボックスリードオンリー --->
								<asp:TextBox ID="Meisaihead_iro_nm4" CssClass="inpReadonlyCenter size-link" runat="server"></asp:TextBox>
								<!--- 「明細ヘッダ色１９」テキストボックスリードオンリー --->
								<asp:TextBox ID="Meisaihead_iro_nm19" CssClass="inpReadonlyCenter size-link" runat="server"></asp:TextBox>
							</div>
							<div class="col5 col5-title">
								<!--- 「明細ヘッダ色５」テキストボックスリードオンリー --->
								<asp:TextBox ID="Meisaihead_iro_nm5" CssClass="inpReadonlyCenter size-link" runat="server"></asp:TextBox>
								<!--- 「明細ヘッダ色２０」テキストボックスリードオンリー --->
								<asp:TextBox ID="Meisaihead_iro_nm20" CssClass="inpReadonlyCenter size-link" runat="server"></asp:TextBox>
							</div>
							<div class="col5 col5-title">
								<!--- 「明細ヘッダ色６」テキストボックスリードオンリー --->
								<asp:TextBox ID="Meisaihead_iro_nm6" CssClass="inpReadonlyCenter size-link" runat="server"></asp:TextBox>
								<!--- 「明細ヘッダ色２１」テキストボックスリードオンリー --->
								<asp:TextBox ID="Meisaihead_iro_nm21" CssClass="inpReadonlyCenter size-link" runat="server"></asp:TextBox>
							</div>
							<div class="col5 col5-title">
								<!--- 「明細ヘッダ色７」テキストボックスリードオンリー --->
								<asp:TextBox ID="Meisaihead_iro_nm7" CssClass="inpReadonlyCenter size-link" runat="server"></asp:TextBox>
								<!--- 「明細ヘッダ色２２」テキストボックスリードオンリー --->
								<asp:TextBox ID="Meisaihead_iro_nm22" CssClass="inpReadonlyCenter size-link" runat="server"></asp:TextBox>
							</div>
							<div class="col5 col5-title">
								<!--- 「明細ヘッダ色８」テキストボックスリードオンリー --->
								<asp:TextBox ID="Meisaihead_iro_nm8" CssClass="inpReadonlyCenter size-link" runat="server"></asp:TextBox>
								<!--- 「明細ヘッダ色２３」テキストボックスリードオンリー --->
								<asp:TextBox ID="Meisaihead_iro_nm23" CssClass="inpReadonlyCenter size-link" runat="server"></asp:TextBox>
							</div>
							<div class="col5 col5-title">
								<!--- 「明細ヘッダ色９」テキストボックスリードオンリー --->
								<asp:TextBox ID="Meisaihead_iro_nm9" CssClass="inpReadonlyCenter size-link" runat="server"></asp:TextBox>
								<!--- 「明細ヘッダ色２４」テキストボックスリードオンリー --->
								<asp:TextBox ID="Meisaihead_iro_nm24" CssClass="inpReadonlyCenter size-link" runat="server"></asp:TextBox>
							</div>
							<div class="col5 col5-title">
								<!--- 「明細ヘッダ色１０」テキストボックスリードオンリー --->
								<asp:TextBox ID="Meisaihead_iro_nm10" CssClass="inpReadonlyCenter size-link" runat="server"></asp:TextBox>
								<!--- 「明細ヘッダ色２５」テキストボックスリードオンリー --->
								<asp:TextBox ID="Meisaihead_iro_nm25" CssClass="inpReadonlyCenter size-link" runat="server"></asp:TextBox>
							</div>
							<div class="col5 col5-title">
								<!--- 「明細ヘッダ色１１」テキストボックスリードオンリー --->
								<asp:TextBox ID="Meisaihead_iro_nm11" CssClass="inpReadonlyCenter size-link" runat="server"></asp:TextBox>
								<!--- 「明細ヘッダ色２６」テキストボックスリードオンリー --->
								<asp:TextBox ID="Meisaihead_iro_nm26" CssClass="inpReadonlyCenter size-link" runat="server"></asp:TextBox>
							</div>
							<div class="col5 col5-title">
								<!--- 「明細ヘッダ色１２」テキストボックスリードオンリー --->
								<asp:TextBox ID="Meisaihead_iro_nm12" CssClass="inpReadonlyCenter size-link" runat="server"></asp:TextBox>
								<!--- 「明細ヘッダ色２７」テキストボックスリードオンリー --->
								<asp:TextBox ID="Meisaihead_iro_nm27" CssClass="inpReadonlyCenter size-link" runat="server"></asp:TextBox>
							</div>
							<div class="col5 col5-title">
								<!--- 「明細ヘッダ色１３」テキストボックスリードオンリー --->
								<asp:TextBox ID="Meisaihead_iro_nm13" CssClass="inpReadonlyCenter size-link" runat="server"></asp:TextBox>
								<!--- 「明細ヘッダ色２８」テキストボックスリードオンリー --->
								<asp:TextBox ID="Meisaihead_iro_nm28" CssClass="inpReadonlyCenter size-link" runat="server"></asp:TextBox>
							</div>
							<div class="col5 col5-title">
								<!--- 「明細ヘッダ色１４」テキストボックスリードオンリー --->
								<asp:TextBox ID="Meisaihead_iro_nm14" CssClass="inpReadonlyCenter size-link" runat="server"></asp:TextBox>
								<!--- 「明細ヘッダ色２９」テキストボックスリードオンリー --->
								<asp:TextBox ID="Meisaihead_iro_nm29" CssClass="inpReadonlyCenter size-link" runat="server"></asp:TextBox>
							</div>
							<div class="col5 col5-title pad-4">
								<!--- 「明細ヘッダ色１５」テキストボックスリードオンリー --->
								<asp:TextBox ID="Meisaihead_iro_nm15" CssClass="inpReadonlyCenter size-link" runat="server"></asp:TextBox>
								<!--- 「明細ヘッダ色３０」テキストボックスリードオンリー --->
								<asp:TextBox ID="Meisaihead_iro_nm30" CssClass="inpReadonlyCenter size-link" runat="server"></asp:TextBox>
							</div>
							<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
							<div style="display:none">
								<div class="col3">
									<asp:Label ID="M1area_cd_lbl" runat="server"></asp:Label>
								</div>
								<div class="col6">
									<asp:Label ID="M1suryo1_lbl" runat="server"></asp:Label>
								</div>
								<div class="col7">
									<asp:Label ID="M1suryo2_lbl" runat="server"></asp:Label>
								</div>
								<div class="col8">
									<asp:Label ID="M1suryo3_lbl" runat="server"></asp:Label>
								</div>
								<div class="col9">
									<asp:Label ID="M1suryo4_lbl" runat="server"></asp:Label>
								</div>
								<div class="col10">
									<asp:Label ID="M1suryo5_lbl" runat="server"></asp:Label>
								</div>
								<div class="col11">
									<asp:Label ID="M1suryo6_lbl" runat="server"></asp:Label>
								</div>
								<div class="col12">
									<asp:Label ID="M1suryo7_lbl" runat="server"></asp:Label>
								</div>
								<div class="col13">
									<asp:Label ID="M1suryo8_lbl" runat="server"></asp:Label>
								</div>
								<div class="col14">
									<asp:Label ID="M1suryo9_lbl" runat="server"></asp:Label>
								</div>
								<div class="col15">
									<asp:Label ID="M1suryo10_lbl" runat="server"></asp:Label>
								</div>
								<div class="col16">
									<asp:Label ID="M1suryo11_lbl" runat="server"></asp:Label>
								</div>
								<div class="col17">
									<asp:Label ID="M1suryo12_lbl" runat="server"></asp:Label>
								</div>
								<div class="col18">
									<asp:Label ID="M1suryo13_lbl" runat="server"></asp:Label>
								</div>
								<div class="col19">
									<asp:Label ID="M1suryo14_lbl" runat="server"></asp:Label>
								</div>
								<div class="col20">
									<asp:Label ID="M1suryo15_lbl" runat="server"></asp:Label>
								</div>
								<div class="col21">
									<asp:Label ID="M1suryo16_lbl" runat="server"></asp:Label>
								</div>
								<div class="col22">
									<asp:Label ID="M1suryo17_lbl" runat="server"></asp:Label>
								</div>
								<div class="col23">
									<asp:Label ID="M1suryo18_lbl" runat="server"></asp:Label>
								</div>
								<div class="col24">
									<asp:Label ID="M1suryo19_lbl" runat="server"></asp:Label>
								</div>
								<div class="col25">
									<asp:Label ID="M1suryo20_lbl" runat="server"></asp:Label>
								</div>
								<div class="col26">
									<asp:Label ID="M1suryo21_lbl" runat="server"></asp:Label>
								</div>
								<div class="col27">
									<asp:Label ID="M1suryo22_lbl" runat="server"></asp:Label>
								</div>
								<div class="col28">
									<asp:Label ID="M1suryo23_lbl" runat="server"></asp:Label>
								</div>
								<div class="col29">
									<asp:Label ID="M1suryo24_lbl" runat="server"></asp:Label>
								</div>
								<div class="col30">
									<asp:Label ID="M1suryo25_lbl" runat="server"></asp:Label>
								</div>
								<div class="col31">
									<asp:Label ID="M1suryo26_lbl" runat="server"></asp:Label>
								</div>
								<div class="col32">
									<asp:Label ID="M1suryo27_lbl" runat="server"></asp:Label>
								</div>
								<div class="col33">
									<asp:Label ID="M1suryo28_lbl" runat="server"></asp:Label>
								</div>
								<div class="col34">
									<asp:Label ID="M1suryo29_lbl" runat="server"></asp:Label>
								</div>
								<div class="col35">
									<asp:Label ID="M1suryo30_lbl" runat="server"></asp:Label>
								</div>
								<div class="col36">
									<asp:Label ID="M1selectorcheckbox_lbl" runat="server"></asp:Label>
								</div>
								<div class="col37">
									<asp:Label ID="M1entersyoriflg_lbl" runat="server"></asp:Label>
								</div>
								<div class="col38">
									<asp:Label ID="M1dtlirokbn_lbl" runat="server"></asp:Label>
								</div>
							</div>
							<!--- 隠し項目エリア↑↑↑↑↑↑↑↑↑↑↑↑↑ --->
						<!-- /str-hdg-result --></div>
						<div id="str-result-item-wrap" class="adjust-elem">
							<asp:Repeater ID="M1" runat="server">
								<HeaderTemplate>
								</HeaderTemplate>
								<ItemTemplate>
									<div  id="M1Row" class="str-result-item-01" runat="server">
										<div class="col1 detail_right">
											<!--- 「ｍ１行no」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1rowno" CssClass="inpReadonlyRight inpRONum3" runat="server"></asp:TextBox>
										</div>
										<div class="col2 detail_left">
											<!--- 「Ｍ１エリアリンク」ボタン --->
											<input type="button" id="M1area_ryaku_nm" value="エリア" onserverclick="OnM1AREA_RYAKU_NM_FRM" runat="server" class="meisaiLink"/>
										</div>
										<div class="col3 detail_right">
											<!--- 「ｍ１合計数量」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1gokei_suryo" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
										</div>
										<div class="col4 detail_right">
											<!--- 「ｍ１消化率」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1syoka_rtu" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
										</div>
										<div class="col5 detail_right">
											<!--- 「ｍ１数量１」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1suryo1" CssClass="inpReadonlyRight inpRONumCmaMinus5"  runat="server"></asp:TextBox>
											<!--- 「ｍ１数量１６」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1suryo16" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
										</div>
										<div class="col5 detail_right">
											<!--- 「ｍ１数量２」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1suryo2" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
											<!--- 「ｍ１数量１７」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1suryo17" CssClass="inpReadonlyRight inpRONumCmaMinus5"  runat="server"></asp:TextBox>
										</div>
										<div class="col5 detail_right">
											<!--- 「ｍ１数量３」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1suryo3" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
											<!--- 「ｍ１数量１８」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1suryo18" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
										</div>
										<div class="col5 detail_right">
											<!--- 「ｍ１数量４」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1suryo4" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
											<!--- 「ｍ１数量１９」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1suryo19" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
										</div>
										<div class="col5 detail_right">
											<!--- 「ｍ１数量５」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1suryo5" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
											<!--- 「ｍ１数量２０」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1suryo20" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
										</div>
										<div class="col5 detail_right">
											<!--- 「ｍ１数量６」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1suryo6" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
											<!--- 「ｍ１数量２１」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1suryo21" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
										</div>
										<div class="col5 detail_right">
											<!--- 「ｍ１数量７」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1suryo7" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
											<!--- 「ｍ１数量２２」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1suryo22" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
										</div>
										<div class="col5 detail_right">
											<!--- 「ｍ１数量８」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1suryo8" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
											<!--- 「ｍ１数量２３」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1suryo23" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
										</div>
										<div class="col5 detail_right">
												<!--- 「ｍ１数量９」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1suryo9" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
											<!--- 「ｍ１数量２４」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1suryo24" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
										</div>
										<div class="col5 detail_right">
											<!--- 「ｍ１数量１０」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1suryo10" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
											<!--- 「ｍ１数量２５」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1suryo25" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
										</div>
										<div class="col5 detail_right">
											<!--- 「ｍ１数量１１」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1suryo11" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
											<!--- 「ｍ１数量２６」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1suryo26" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
										</div>
										<div class="col5 detail_right">
											<!--- 「ｍ１数量１２」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1suryo12" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
											<!--- 「ｍ１数量２７」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1suryo27" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
										</div>
										<div class="col5 detail_right">
											<!--- 「ｍ１数量１３」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1suryo13" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
											<!--- 「ｍ１数量２８」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1suryo28" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
										</div>
										<div class="col5 detail_right">
											<!--- 「ｍ１数量１４」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1suryo14" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
											<!--- 「ｍ１数量２９」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1suryo29" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
										</div>
										<div class="col5 detail_right">
											<!--- 「ｍ１数量１５」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1suryo15" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
											<!--- 「ｍ１数量３０」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1suryo30" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
										</div>
										<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
										<div style="display:none">
											<div class="col36">
												<!--- 「ｍ１選択フラグ(隠し)」チェックボックス --->
												<adv:AdvancedCheckBox ID="M1selectorcheckbox" Text="" CssClass="" runat="server"></adv:AdvancedCheckBox>
											</div>
											<div class="col37">
												<!--- 「Ｍ１確定処理フラグ(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1entersyoriflg" runat="server"></asp:hiddenfield>
											</div>
											<div class="col38">
												<!--- 「Ｍ１明細色区分(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1dtlirokbn" runat="server"></asp:hiddenfield>
											</div>
											<!--- 「Ｍ１エリアコード」隠しフィールド --->
											<asp:hiddenfield ID="M1area_cd" runat="server"></asp:hiddenfield>
										</div>
									<!-- /str-result-item-01 --></div>
								</ItemTemplate>
							</asp:Repeater>
						<!-- /str-result-item-wrap --></div>
						<span class="adjust-elem-next"></span>
						<div id="str-ftr-area" class="str-result-ftr-01">
							<div class="col1 detail_left">&nbsp;</div>
							<div class="col2 detail_left pad-1">
								<!--- 「店舗名」テキストボックスリードオンリー --->
								<asp:TextBox ID="Tenpo_nm" CssClass="inpReadonlyLeft inpROZenkaku8 foot-size-link" runat="server"></asp:TextBox>
							</div>
							<div class="col3 detail_ftr">
								<!--- 「総合計数量」テキストボックスリードオンリー --->
								<asp:TextBox ID="All_gokei_suryo" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
							</div>
							<div class="col4 detail_left">&nbsp;</div>
							<div class="col5 detail_ftr">
								<!--- 「合計数量１」テキストボックスリードオンリー --->
								<asp:TextBox ID="Gokei_suryo1" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「合計数量２」テキストボックスリードオンリー --->
								<asp:TextBox ID="Gokei_suryo2" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「合計数量３」テキストボックスリードオンリー --->
								<asp:TextBox ID="Gokei_suryo3" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「合計数量４」テキストボックスリードオンリー --->
								<asp:TextBox ID="Gokei_suryo4" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「合計数量５」テキストボックスリードオンリー --->
								<asp:TextBox ID="Gokei_suryo5" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「合計数量６」テキストボックスリードオンリー --->
								<asp:TextBox ID="Gokei_suryo6" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「合計数量７」テキストボックスリードオンリー --->
								<asp:TextBox ID="Gokei_suryo7" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「合計数量８」テキストボックスリードオンリー --->
								<asp:TextBox ID="Gokei_suryo8" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「合計数量９」テキストボックスリードオンリー --->
								<asp:TextBox ID="Gokei_suryo9" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「合計数量１０」テキストボックスリードオンリー --->
								<asp:TextBox ID="Gokei_suryo10" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「合計数量１１」テキストボックスリードオンリー --->
								<asp:TextBox ID="Gokei_suryo11" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「合計数量１２」テキストボックスリードオンリー --->
								<asp:TextBox ID="Gokei_suryo12" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「合計数量１３」テキストボックスリードオンリー --->
								<asp:TextBox ID="Gokei_suryo13" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「合計数量１４」テキストボックスリードオンリー --->
								<asp:TextBox ID="Gokei_suryo14" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「合計数量１５」テキストボックスリードオンリー --->
								<asp:TextBox ID="Gokei_suryo15" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「合計数量１６」テキストボックスリードオンリー --->
								<asp:TextBox ID="Gokei_suryo16" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「合計数量１７」テキストボックスリードオンリー --->
								<asp:TextBox ID="Gokei_suryo17" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「合計数量１８」テキストボックスリードオンリー --->
								<asp:TextBox ID="Gokei_suryo18" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「合計数量１９」テキストボックスリードオンリー --->
								<asp:TextBox ID="Gokei_suryo19" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「合計数量２０」テキストボックスリードオンリー --->
								<asp:TextBox ID="Gokei_suryo20" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「合計数量２１」テキストボックスリードオンリー --->
								<asp:TextBox ID="Gokei_suryo21" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「合計数量２２」テキストボックスリードオンリー --->
								<asp:TextBox ID="Gokei_suryo22" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「合計数量２３」テキストボックスリードオンリー --->
								<asp:TextBox ID="Gokei_suryo23" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「合計数量２４」テキストボックスリードオンリー --->
								<asp:TextBox ID="Gokei_suryo24" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「合計数量２５」テキストボックスリードオンリー --->
								<asp:TextBox ID="Gokei_suryo25" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「合計数量２６」テキストボックスリードオンリー --->
								<asp:TextBox ID="Gokei_suryo26" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「合計数量２７」テキストボックスリードオンリー --->
								<asp:TextBox ID="Gokei_suryo27" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「合計数量２８」テキストボックスリードオンリー --->
								<asp:TextBox ID="Gokei_suryo28" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「合計数量２９」テキストボックスリードオンリー --->
								<asp:TextBox ID="Gokei_suryo29" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「合計数量３０」テキストボックスリードオンリー --->
								<asp:TextBox ID="Gokei_suryo30" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
							</div>
						<!-- /str-result-ftr-01 --></div>
					<!-- /str-result-01 --></div>
				<!-- /inner-02 --></div>
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
			<asp:Label ID="Meisaihead_iro_nm1_lbl" runat="server"></asp:Label>
			<asp:Label ID="Meisaihead_iro_nm2_lbl" runat="server"></asp:Label>
			<asp:Label ID="Meisaihead_iro_nm3_lbl" runat="server"></asp:Label>
			<asp:Label ID="Meisaihead_iro_nm4_lbl" runat="server"></asp:Label>
			<asp:Label ID="Meisaihead_iro_nm5_lbl" runat="server"></asp:Label>
			<asp:Label ID="Meisaihead_iro_nm6_lbl" runat="server"></asp:Label>
			<asp:Label ID="Meisaihead_iro_nm7_lbl" runat="server"></asp:Label>
			<asp:Label ID="Meisaihead_iro_nm8_lbl" runat="server"></asp:Label>
			<asp:Label ID="Meisaihead_iro_nm9_lbl" runat="server"></asp:Label>
			<asp:Label ID="Meisaihead_iro_nm10_lbl" runat="server"></asp:Label>
			<asp:Label ID="Meisaihead_iro_nm11_lbl" runat="server"></asp:Label>
			<asp:Label ID="Meisaihead_iro_nm12_lbl" runat="server"></asp:Label>
			<asp:Label ID="Meisaihead_iro_nm13_lbl" runat="server"></asp:Label>
			<asp:Label ID="Meisaihead_iro_nm14_lbl" runat="server"></asp:Label>
			<asp:Label ID="Meisaihead_iro_nm15_lbl" runat="server"></asp:Label>
			<asp:Label ID="Meisaihead_iro_nm16_lbl" runat="server"></asp:Label>
			<asp:Label ID="Meisaihead_iro_nm17_lbl" runat="server"></asp:Label>
			<asp:Label ID="Meisaihead_iro_nm18_lbl" runat="server"></asp:Label>
			<asp:Label ID="Meisaihead_iro_nm19_lbl" runat="server"></asp:Label>
			<asp:Label ID="Meisaihead_iro_nm20_lbl" runat="server"></asp:Label>
			<asp:Label ID="Meisaihead_iro_nm21_lbl" runat="server"></asp:Label>
			<asp:Label ID="Meisaihead_iro_nm22_lbl" runat="server"></asp:Label>
			<asp:Label ID="Meisaihead_iro_nm23_lbl" runat="server"></asp:Label>
			<asp:Label ID="Meisaihead_iro_nm24_lbl" runat="server"></asp:Label>
			<asp:Label ID="Meisaihead_iro_nm25_lbl" runat="server"></asp:Label>
			<asp:Label ID="Meisaihead_iro_nm26_lbl" runat="server"></asp:Label>
			<asp:Label ID="Meisaihead_iro_nm27_lbl" runat="server"></asp:Label>
			<asp:Label ID="Meisaihead_iro_nm28_lbl" runat="server"></asp:Label>
			<asp:Label ID="Meisaihead_iro_nm29_lbl" runat="server"></asp:Label>
			<asp:Label ID="Meisaihead_iro_nm30_lbl" runat="server"></asp:Label>
			<asp:Label ID="Tenpo_nm_lbl" runat="server"></asp:Label>
			<!--- 「店舗コード」隠しフィールド --->
			<asp:hiddenfield ID="Tenpo_cd" runat="server"></asp:hiddenfield>
			<asp:Label ID="All_gokei_suryo_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokei_suryo1_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokei_suryo2_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokei_suryo3_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokei_suryo4_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokei_suryo5_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokei_suryo6_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokei_suryo7_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokei_suryo8_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokei_suryo9_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokei_suryo10_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokei_suryo11_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokei_suryo12_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokei_suryo13_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokei_suryo14_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokei_suryo15_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokei_suryo16_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokei_suryo17_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokei_suryo18_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokei_suryo19_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokei_suryo20_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokei_suryo21_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokei_suryo22_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokei_suryo23_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokei_suryo24_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokei_suryo25_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokei_suryo26_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokei_suryo27_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokei_suryo28_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokei_suryo29_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokei_suryo30_lbl" runat="server"></asp:Label>
		</div>
	
	</form>
</body>
</html>

