<%@ Page language="c#" CodeFile="th020f02.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Th020p01.Page.Th020f02Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">在庫検索</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="th020p01" FormId="th020f02" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/th020f02.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="th020p01" FormId="th020f02" runat="server" />

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
	<form id="Th020f02" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="th020p01" PgName="在庫検索" FormId="th020f02" FormName="在庫検索 明細（店舗別）" ></uc:Header>


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


						<!--- 件数表示部 --->
<!--						<p><adv:PageInfo ID="M1PageInfo" runat="server"></adv:PageInfo></p>-->
						<!--- ページャーを配置する場合はこの中 --->


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

									<asp:TextBox ID="Zentenzaiko_su" CssClass="inpReadonlyLeft inpRONumCmaMinus8" runat="server"></asp:TextBox>
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
								<li><!--- 「エリアへリンク」ボタン --->
									<input type="button" id="Btnarea" value="エリアへ" onserverclick="OnBTNAREA_FRM" runat="server" class="meisaiLink"/>
								</li>
								<li class="prev"><!--- 「前へリンク」ボタン --->
									<input type="button" id="Btnprev" value="前へ" onserverclick="OnBTNPREV_FRM" runat="server" class="meisaiLink"/>
								</li>
								<li><span>&nbsp</span></li>
								<li><!--- 「次へリンク」ボタン --->
									<input type="button" id="Btnnext" value="次へ" onserverclick="OnBTNNEXT_FRM" runat="server" class="meisaiLink"/>
								</li>
							</ul>
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
							<div class="col2"><asp:Label ID="M1tenpo_nm_lbl" runat="server">店舗</asp:Label></div>
							<div class="col3"><asp:Label ID="M1gokei_suryo_lbl" runat="server">合計</asp:Label></div>
							<div class="col4"><asp:Label ID="M1syoka_rtu_lbl" runat="server">消化率</asp:Label></div>
							<div class="col5 col5-title">
								<!--- 「明細ヘッダ色１」ボタン --->
								<input type="button" id="Meisaihead_iro_nm1" value="" onserverclick="OnMEISAIHEAD_IRO_NM1_FRM" runat="server" class="meisaiLink size-link size-link-space"/>
							</div>
							<div class="col5 col5-title">
								<!--- 「明細ヘッダ色２」ボタン --->
								<input type="button" id="Meisaihead_iro_nm2" value="" onserverclick="OnMEISAIHEAD_IRO_NM2_FRM" runat="server" class="meisaiLink size-link size-link-space"/>
							</div>
							<div class="col5 col5-title">
								<!--- 「明細ヘッダ色３」ボタン --->
								<input type="button" id="Meisaihead_iro_nm3" value="" onserverclick="OnMEISAIHEAD_IRO_NM3_FRM" runat="server" class="meisaiLink size-link size-link-space"/>
							</div>
							<div class="col5 col5-title">
								<!--- 「明細ヘッダ色４」ボタン --->
								<input type="button" id="Meisaihead_iro_nm4" value="" onserverclick="OnMEISAIHEAD_IRO_NM4_FRM" runat="server" class="meisaiLink size-link size-link-space"/>
							</div>
							<div class="col5 col5-title">
								<!--- 「明細ヘッダ色５」ボタン --->
								<input type="button" id="Meisaihead_iro_nm5" value="" onserverclick="OnMEISAIHEAD_IRO_NM5_FRM" runat="server" class="meisaiLink size-link size-link-space"/>
							</div>
							<div class="col5 col5-title">
								<!--- 「明細ヘッダ色６」ボタン --->
								<input type="button" id="Meisaihead_iro_nm6" value="" onserverclick="OnMEISAIHEAD_IRO_NM6_FRM" runat="server" class="meisaiLink size-link size-link-space"/>
							</div>
							<div class="col5 col5-title">
								<!--- 「明細ヘッダ色７」ボタン --->
								<input type="button" id="Meisaihead_iro_nm7" value="" onserverclick="OnMEISAIHEAD_IRO_NM7_FRM" runat="server" class="meisaiLink size-link size-link-space"/>
							</div>
							<div class="col5 col5-title">
								<!--- 「明細ヘッダ色８」ボタン --->
								<input type="button" id="Meisaihead_iro_nm8" value="" onserverclick="OnMEISAIHEAD_IRO_NM8_FRM" runat="server" class="meisaiLink size-link size-link-space"/>
							</div>
							<div class="col5 col5-title">
								<!--- 「明細ヘッダ色９」ボタン --->
								<input type="button" id="Meisaihead_iro_nm9" value="" onserverclick="OnMEISAIHEAD_IRO_NM9_FRM" runat="server" class="meisaiLink size-link size-link-space"/>
							</div>
							<div class="col5 col5-title">
								<!--- 「明細ヘッダ色１０」ボタン --->
								<input type="button" id="Meisaihead_iro_nm10" value="" onserverclick="OnMEISAIHEAD_IRO_NM10_FRM" runat="server" class="meisaiLink size-link size-link-space"/>
							</div>
							<div class="col5 col5-title">
								<!--- 「明細ヘッダ色１１」ボタン --->
								<input type="button" id="Meisaihead_iro_nm11" value="" onserverclick="OnMEISAIHEAD_IRO_NM11_FRM" runat="server" class="meisaiLink size-link size-link-space"/>
							</div>
							<div class="col5 col5-title">
								<!--- 「明細ヘッダ色１２」ボタン --->
								<input type="button" id="Meisaihead_iro_nm12" value="" onserverclick="OnMEISAIHEAD_IRO_NM12_FRM" runat="server" class="meisaiLink size-link size-link-space"/>
							</div>
							<div class="col5 col5-title">
								<!--- 「明細ヘッダ色１３」ボタン --->
								<input type="button" id="Meisaihead_iro_nm13" value="" onserverclick="OnMEISAIHEAD_IRO_NM13_FRM" runat="server" class="meisaiLink size-link size-link-space"/>
							</div>
							<div class="col5 col5-title">
								<!--- 「明細ヘッダ色１４」ボタン --->
								<input type="button" id="Meisaihead_iro_nm14" value="" onserverclick="OnMEISAIHEAD_IRO_NM14_FRM" runat="server" class="meisaiLink size-link size-link-space"/>
							</div>
							<div class="col5 col5-title">
								<!--- 「明細ヘッダ色１５」ボタン --->
								<input type="button" id="Meisaihead_iro_nm15" value="" onserverclick="OnMEISAIHEAD_IRO_NM15_FRM" runat="server" class="meisaiLink size-link size-link-space"/>
							</div>

							<div class="col5 col5-title">
								<!--- 「明細ヘッダ色１６」ボタン --->
								<input type="button" id="Meisaihead_iro_nm16" value="" onserverclick="OnMEISAIHEAD_IRO_NM16_FRM" runat="server" class="meisaiLink size-link size-link-space"/>
							</div>
							<div class="col5 col5-title">
								<!--- 「明細ヘッダ色１７」ボタン --->
								<input type="button" id="Meisaihead_iro_nm17" value="" onserverclick="OnMEISAIHEAD_IRO_NM17_FRM" runat="server" class="meisaiLink size-link size-link-space"/>
							</div>
							<div class="col5 col5-title">
								<!--- 「明細ヘッダ色１８」ボタン --->
								<input type="button" id="Meisaihead_iro_nm18" value="" onserverclick="OnMEISAIHEAD_IRO_NM18_FRM" runat="server" class="meisaiLink size-link size-link-space"/>
							</div>
							<div class="col5 col5-title">
								<!--- 「明細ヘッダ色１９」ボタン --->
								<input type="button" id="Meisaihead_iro_nm19" value="" onserverclick="OnMEISAIHEAD_IRO_NM19_FRM" runat="server" class="meisaiLink size-link size-link-space"/>
							</div>
							<div class="col5 col5-title">
								<!--- 「明細ヘッダ色２０」ボタン --->
								<input type="button" id="Meisaihead_iro_nm20" value="" onserverclick="OnMEISAIHEAD_IRO_NM20_FRM" runat="server" class="meisaiLink size-link size-link-space"/>
							</div>
							<div class="col5 col5-title">
								<!--- 「明細ヘッダ色２１」ボタン --->
								<input type="button" id="Meisaihead_iro_nm21" value="" onserverclick="OnMEISAIHEAD_IRO_NM21_FRM" runat="server" class="meisaiLink size-link size-link-space"/>
							</div>
							<div class="col5 col5-title">
								<!--- 「明細ヘッダ色２２」ボタン --->
								<input type="button" id="Meisaihead_iro_nm22" value="" onserverclick="OnMEISAIHEAD_IRO_NM22_FRM" runat="server" class="meisaiLink size-link size-link-space"/>
							</div>
							<div class="col5 col5-title">
								<!--- 「明細ヘッダ色２３」ボタン --->
								<input type="button" id="Meisaihead_iro_nm23" value="" onserverclick="OnMEISAIHEAD_IRO_NM23_FRM" runat="server" class="meisaiLink size-link size-link-space"/>
							</div>
							<div class="col5 col5-title">
								<!--- 「明細ヘッダ色２４」ボタン --->
								<input type="button" id="Meisaihead_iro_nm24" value="" onserverclick="OnMEISAIHEAD_IRO_NM24_FRM" runat="server" class="meisaiLink size-link size-link-space"/>
							</div>
							<div class="col5 col5-title">
								<!--- 「明細ヘッダ色２５」ボタン --->
								<input type="button" id="Meisaihead_iro_nm25" value="" onserverclick="OnMEISAIHEAD_IRO_NM25_FRM" runat="server" class="meisaiLink size-link size-link-space"/>
							</div>
							<div class="col5 col5-title">
								<!--- 「明細ヘッダ色２６」ボタン --->
								<input type="button" id="Meisaihead_iro_nm26" value="" onserverclick="OnMEISAIHEAD_IRO_NM26_FRM" runat="server" class="meisaiLink size-link size-link-space"/>
							</div>
							<div class="col5 col5-title">
								<!--- 「明細ヘッダ色２７」ボタン --->
								<input type="button" id="Meisaihead_iro_nm27" value="" onserverclick="OnMEISAIHEAD_IRO_NM27_FRM" runat="server" class="meisaiLink size-link size-link-space"/>
							</div>
							<div class="col5 col5-title">
								<!--- 「明細ヘッダ色２８」ボタン --->
								<input type="button" id="Meisaihead_iro_nm28" value="" onserverclick="OnMEISAIHEAD_IRO_NM28_FRM" runat="server" class="meisaiLink size-link size-link-space"/>
							</div>
							<div class="col5 col5-title">
								<!--- 「明細ヘッダ色２９」ボタン --->
								<input type="button" id="Meisaihead_iro_nm29" value="" onserverclick="OnMEISAIHEAD_IRO_NM29_FRM" runat="server" class="meisaiLink size-link size-link-space"/>
							</div>
							<div class="col5 col5-title">
								<!--- 「明細ヘッダ色３０」ボタン --->
								<input type="button" id="Meisaihead_iro_nm30" value="" onserverclick="OnMEISAIHEAD_IRO_NM30_FRM" runat="server" class="meisaiLink size-link size-link-space"/>
							</div>
							<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
							<div style="display:none">
								<asp:Label ID="M1tenpo_cd_lbl" runat="server"></asp:Label>
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
											<!--- 「ｍ１店舗コード」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1tenpo_cd" CssClass="inpReadonlyLeft inpRONum4" runat="server"></asp:TextBox>
											<!--- 「ｍ１店舗名」テキストボックスリードオンリー --->

											<asp:TextBox ID="M1tenpo_nm" CssClass="inpReadonlyLeft inpROZenkaku6_2 tooltip" runat="server"></asp:TextBox>
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

											<asp:TextBox ID="M1suryo1" CssClass="inpReadonlyRight inpRONumCmaMinus4"  runat="server"></asp:TextBox>
											<!--- 「ｍ１数量１６」テキストボックスリードオンリー --->

											<asp:TextBox ID="M1suryo16" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
										</div>
										<div class="col5 detail_right">
											<!--- 「ｍ１数量２」テキストボックスリードオンリー --->

											<asp:TextBox ID="M1suryo2" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
											<!--- 「ｍ１数量１７」テキストボックスリードオンリー --->

											<asp:TextBox ID="M1suryo17" CssClass="inpReadonlyRight inpRONumCmaMinus4"  runat="server"></asp:TextBox>
										</div>
										<div class="col5 detail_right">
											<!--- 「ｍ１数量３」テキストボックスリードオンリー --->

											<asp:TextBox ID="M1suryo3" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
											<!--- 「ｍ１数量１８」テキストボックスリードオンリー --->

											<asp:TextBox ID="M1suryo18" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
										</div>
										<div class="col5 detail_right">
											<!--- 「ｍ１数量４」テキストボックスリードオンリー --->

											<asp:TextBox ID="M1suryo4" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
											<!--- 「ｍ１数量１９」テキストボックスリードオンリー --->

											<asp:TextBox ID="M1suryo19" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
										</div>
										<div class="col5 detail_right">
											<!--- 「ｍ１数量５」テキストボックスリードオンリー --->

											<asp:TextBox ID="M1suryo5" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
											<!--- 「ｍ１数量２０」テキストボックスリードオンリー --->

											<asp:TextBox ID="M1suryo20" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
										</div>
										<div class="col5 detail_right">
											<!--- 「ｍ１数量６」テキストボックスリードオンリー --->

											<asp:TextBox ID="M1suryo6" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
											<!--- 「ｍ１数量２１」テキストボックスリードオンリー --->

											<asp:TextBox ID="M1suryo21" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
										</div>
										<div class="col5 detail_right">
											<!--- 「ｍ１数量７」テキストボックスリードオンリー --->

											<asp:TextBox ID="M1suryo7" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
											<!--- 「ｍ１数量２２」テキストボックスリードオンリー --->

											<asp:TextBox ID="M1suryo22" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
										</div>
										<div class="col5 detail_right">
											<!--- 「ｍ１数量８」テキストボックスリードオンリー --->

											<asp:TextBox ID="M1suryo8" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
											<!--- 「ｍ１数量２３」テキストボックスリードオンリー --->

											<asp:TextBox ID="M1suryo23" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
										</div>
										<div class="col5 detail_right">
												<!--- 「ｍ１数量９」テキストボックスリードオンリー --->

											<asp:TextBox ID="M1suryo9" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
											<!--- 「ｍ１数量２４」テキストボックスリードオンリー --->

											<asp:TextBox ID="M1suryo24" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
										</div>
										<div class="col5 detail_right">
											<!--- 「ｍ１数量１０」テキストボックスリードオンリー --->

											<asp:TextBox ID="M1suryo10" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
											<!--- 「ｍ１数量２５」テキストボックスリードオンリー --->

											<asp:TextBox ID="M1suryo25" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
										</div>
										<div class="col5 detail_right">
											<!--- 「ｍ１数量１１」テキストボックスリードオンリー --->

											<asp:TextBox ID="M1suryo11" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
											<!--- 「ｍ１数量２６」テキストボックスリードオンリー --->

											<asp:TextBox ID="M1suryo26" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
										</div>
										<div class="col5 detail_right">
											<!--- 「ｍ１数量１２」テキストボックスリードオンリー --->

											<asp:TextBox ID="M1suryo12" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
											<!--- 「ｍ１数量２７」テキストボックスリードオンリー --->

											<asp:TextBox ID="M1suryo27" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
										</div>
										<div class="col5 detail_right">
											<!--- 「ｍ１数量１３」テキストボックスリードオンリー --->

											<asp:TextBox ID="M1suryo13" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
											<!--- 「ｍ１数量２８」テキストボックスリードオンリー --->

											<asp:TextBox ID="M1suryo28" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
										</div>
										<div class="col5 detail_right">
											<!--- 「ｍ１数量１４」テキストボックスリードオンリー --->

											<asp:TextBox ID="M1suryo14" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
											<!--- 「ｍ１数量２９」テキストボックスリードオンリー --->

											<asp:TextBox ID="M1suryo29" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
										</div>
										<div class="col5 detail_right">
											<!--- 「ｍ１数量１５」テキストボックスリードオンリー --->

											<asp:TextBox ID="M1suryo15" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
											<!--- 「ｍ１数量３０」テキストボックスリードオンリー --->

											<asp:TextBox ID="M1suryo30" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
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
								<asp:TextBox ID="Tenpo_nm" CssClass="inpReadonlyLeft inpROZenkaku8 size-link" runat="server"></asp:TextBox>
							</div>
							<div class="col3 detail_ftr">
								<!--- 「総合計数量」テキストボックスリードオンリー --->

								<asp:TextBox ID="All_gokei_suryo" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
							</div>
							<div class="col4 detail_left">&nbsp;</div>
							<div class="col5 detail_ftr">
								<!--- 「数量１」テキストボックスリードオンリー --->

								<asp:TextBox ID="Suryo1" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「数量２」テキストボックスリードオンリー --->

								<asp:TextBox ID="Suryo2" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「数量３」テキストボックスリードオンリー --->

								<asp:TextBox ID="Suryo3" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「数量４」テキストボックスリードオンリー --->

								<asp:TextBox ID="Suryo4" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「数量５」テキストボックスリードオンリー --->

								<asp:TextBox ID="Suryo5" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「数量６」テキストボックスリードオンリー --->

								<asp:TextBox ID="Suryo6" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「数量７」テキストボックスリードオンリー --->

								<asp:TextBox ID="Suryo7" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「数量８」テキストボックスリードオンリー --->

								<asp:TextBox ID="Suryo8" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「数量９」テキストボックスリードオンリー --->

								<asp:TextBox ID="Suryo9" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「数量１０」テキストボックスリードオンリー --->

								<asp:TextBox ID="Suryo10" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「数量１１」テキストボックスリードオンリー --->

								<asp:TextBox ID="Suryo11" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「数量１２」テキストボックスリードオンリー --->

								<asp:TextBox ID="Suryo12" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「数量１３」テキストボックスリードオンリー --->

								<asp:TextBox ID="Suryo13" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「数量１４」テキストボックスリードオンリー --->

								<asp:TextBox ID="Suryo14" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「数量１５」テキストボックスリードオンリー --->

								<asp:TextBox ID="Suryo15" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「数量１６」テキストボックスリードオンリー --->

								<asp:TextBox ID="Suryo16" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「数量１７」テキストボックスリードオンリー --->

								<asp:TextBox ID="Suryo17" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「数量１８」テキストボックスリードオンリー --->

								<asp:TextBox ID="Suryo18" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「数量１９」テキストボックスリードオンリー --->

								<asp:TextBox ID="Suryo19" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「数量２０」テキストボックスリードオンリー --->

								<asp:TextBox ID="Suryo20" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「数量２１」テキストボックスリードオンリー --->

								<asp:TextBox ID="Suryo21" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「数量２２」テキストボックスリードオンリー --->
								<asp:TextBox ID="Suryo22" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「数量２３」テキストボックスリードオンリー --->
								<asp:TextBox ID="Suryo23" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「数量２４」テキストボックスリードオンリー --->
								<asp:TextBox ID="Suryo24" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「数量２５」テキストボックスリードオンリー --->
								<asp:TextBox ID="Suryo25" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「数量２６」テキストボックスリードオンリー --->

								<asp:TextBox ID="Suryo26" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「数量２７」テキストボックスリードオンリー --->
								<asp:TextBox ID="Suryo27" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「数量２８」テキストボックスリードオンリー --->

								<asp:TextBox ID="Suryo28" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「数量２９」テキストボックスリードオンリー --->

								<asp:TextBox ID="Suryo29" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
							</div>
							<div class="col5 detail_ftr">
								<!--- 「数量３０」テキストボックスリードオンリー --->
								<asp:TextBox ID="Suryo30" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
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
			<asp:Label ID="Tenpo_nm_lbl" runat="server"></asp:Label>
			<!--- 「店舗コード」隠しフィールド --->
			<asp:hiddenfield ID="Tenpo_cd" runat="server"></asp:hiddenfield>
			<asp:Label ID="All_gokei_suryo_lbl" runat="server"></asp:Label>
			<asp:Label ID="Suryo1_lbl" runat="server"></asp:Label>
			<asp:Label ID="Suryo2_lbl" runat="server"></asp:Label>
			<asp:Label ID="Suryo3_lbl" runat="server"></asp:Label>
			<asp:Label ID="Suryo4_lbl" runat="server"></asp:Label>
			<asp:Label ID="Suryo5_lbl" runat="server"></asp:Label>
			<asp:Label ID="Suryo6_lbl" runat="server"></asp:Label>
			<asp:Label ID="Suryo7_lbl" runat="server"></asp:Label>
			<asp:Label ID="Suryo8_lbl" runat="server"></asp:Label>
			<asp:Label ID="Suryo9_lbl" runat="server"></asp:Label>
			<asp:Label ID="Suryo10_lbl" runat="server"></asp:Label>
			<asp:Label ID="Suryo11_lbl" runat="server"></asp:Label>
			<asp:Label ID="Suryo12_lbl" runat="server"></asp:Label>
			<asp:Label ID="Suryo13_lbl" runat="server"></asp:Label>
			<asp:Label ID="Suryo14_lbl" runat="server"></asp:Label>
			<asp:Label ID="Suryo15_lbl" runat="server"></asp:Label>
			<asp:Label ID="Suryo16_lbl" runat="server"></asp:Label>
			<asp:Label ID="Suryo17_lbl" runat="server"></asp:Label>
			<asp:Label ID="Suryo18_lbl" runat="server"></asp:Label>
			<asp:Label ID="Suryo19_lbl" runat="server"></asp:Label>
			<asp:Label ID="Suryo20_lbl" runat="server"></asp:Label>
			<asp:Label ID="Suryo21_lbl" runat="server"></asp:Label>
			<asp:Label ID="Suryo22_lbl" runat="server"></asp:Label>
			<asp:Label ID="Suryo23_lbl" runat="server"></asp:Label>
			<asp:Label ID="Suryo24_lbl" runat="server"></asp:Label>
			<asp:Label ID="Suryo25_lbl" runat="server"></asp:Label>
			<asp:Label ID="Suryo26_lbl" runat="server"></asp:Label>
			<asp:Label ID="Suryo27_lbl" runat="server"></asp:Label>
			<asp:Label ID="Suryo28_lbl" runat="server"></asp:Label>
			<asp:Label ID="Suryo29_lbl" runat="server"></asp:Label>
			<asp:Label ID="Suryo30_lbl" runat="server"></asp:Label>
		</div>
	
	</form>

</body>
</html>

