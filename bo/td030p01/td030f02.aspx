<%@ Page language="c#" CodeFile="td030f02.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Td030p01.Page.Td030f02Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">返品検索</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="td030p01" FormId="td030f02" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/td030f02.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="td030p01" FormId="td030f02" runat="server" />

	<!-- Js業務部品のインポート --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->

</head>

<body>
	<form id="Td030f02" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="td030p01" PgName="返品検索" FormId="td030f02" FormName="返品検索 明細" ></uc:Header>
			
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
							<col class="w-type-01"/>
							<col class="w-type-04"/>
							<col class="w-type-01"/>
							<col class="w-type-05"/>
							<col class="w-type-01"/>
							<col class="w-type-06"/>
							<col class="w-type-01"/>
							<col />
						</colgroup>
						<tbody>
							<tr>
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Kanri_no_lbl" runat="server">管理番号</asp:Label></span></th>
								<!--- 「管理no」テキストボックスリードオンリー --->
								<td class="last"><asp:TextBox ID="Kanri_no" CssClass="inpReadonlyLeft inpRONum6" runat="server"></asp:TextBox></td>
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Denpyo_bango_lbl" runat="server">伝票番号</asp:Label></span></th>
								<!--- 「伝票番号」テキストボックスリードオンリー --->
								<td class="last"><asp:TextBox ID="Denpyo_bango" CssClass="inpReadonlyLeft inpRONum6" runat="server"></asp:TextBox></td>
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Nyuryokutan_cd_lbl" runat="server">入力担当者</asp:Label></span></th>
								<!--- 「入力担当者コード」テキストボックスリードオンリー --->
								<!--- 「入力担当者名称」テキストボックスリードオンリー --->
								<td class="last"><asp:TextBox ID="Nyuryokutan_cd" CssClass="inpReadonlyLeft inpRONum7" runat="server"></asp:TextBox><asp:TextBox ID="Nyuryokutan_nm" CssClass="inpReadonlyLeft inpROZenkaku10 inpRORightNm" runat="server"></asp:TextBox></td>
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Kakuteitan_cd_lbl" runat="server">確定担当者</asp:Label></span></th>
								<!--- 「確定担当者コード」テキストボックスリードオンリー --->
								<!--- 「確定担当者名称」テキストボックスリードオンリー --->
								<td class="last"><asp:TextBox ID="Kakuteitan_cd" CssClass="inpReadonlyLeft inpRONum7" runat="server"></asp:TextBox><asp:TextBox ID="Kakuteitan_nm" CssClass="inpReadonlyLeft inpROZenkaku10 inpRORightNm" runat="server"></asp:TextBox></td>
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Henpin_riyu_nm_lbl" runat="server">返品理由</asp:Label></span></th>
								<!--- 「返品理由名称」テキストボックスリードオンリー --->
								<td class="last"><asp:TextBox ID="Henpin_riyu_nm" CssClass="inpReadonlyLeft inpROZenkaku4" runat="server"></asp:TextBox></td>
							</tr>
							<tr>
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Siiresaki_cd_lbl" runat="server">仕入先</asp:Label></span></th>
								<!--- 「仕入先コード」テキストボックスリードオンリー --->
								<!--- 「仕入先略式名称」テキストボックスリードオンリー --->
								<td class="last" colspan="3"><asp:TextBox ID="Siiresaki_cd" CssClass="inpReadonlyLeft inpRONum4" runat="server"></asp:TextBox><asp:TextBox ID="Siiresaki_ryaku_nm" CssClass="inpReadonlyLeft inpROZenkaku10 inpRORightNm" runat="server"></asp:TextBox></td>
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Bumon_cd_lbl" runat="server">部門</asp:Label></span></th>
								<!--- 「部門コード」テキストボックスリードオンリー --->
								<!--- 「部門名」テキストボックスリードオンリー --->
								<td class="last"><asp:TextBox ID="Bumon_cd" CssClass="inpReadonlyLeft inpRONum3" runat="server"></asp:TextBox><asp:TextBox ID="Bumon_nm" CssClass="inpReadonlyLeft inpROZenkaku10 inpRORightNm" runat="server"></asp:TextBox></td>
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Burando_cd_lbl" runat="server">ブランド</asp:Label></span></th>
								<!--- 「ブランドコード」テキストボックスリードオンリー --->
								<!--- 「ブランド名」テキストボックスリードオンリー --->
								<td class="last"><asp:TextBox ID="Burando_cd" CssClass="inpReadonlyLeft inpRONum6" runat="server"></asp:TextBox><asp:TextBox ID="Burando_nm" CssClass="inpReadonlyLeft inpROHankaku20 inpRORightNm" runat="server"></asp:TextBox></td>
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Siji_bango_lbl" runat="server">指示番号</asp:Label></span></th>
								<!--- 「指示番号」テキストボックスリードオンリー --->
								<td class="last"><asp:TextBox ID="Siji_bango" CssClass="inpReadonlyRight inpRONum10" runat="server"></asp:TextBox></td>
							</tr>
							<tr>
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Henpin_kakutei_ymd_lbl" runat="server">返品確定日</asp:Label></span></th>
								<!--- 「返品確定日」テキストボックスリードオンリー --->
								<td class="last"><asp:TextBox ID="Henpin_kakutei_ymd" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox></td>
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Add_ymd_lbl" runat="server">登録日</asp:Label></span></th>
								<!--- 「登録日」テキストボックスリードオンリー --->
								<td class="last"><asp:TextBox ID="Add_ymd" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox></td>
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Denpyo_jyotainm_lbl" runat="server">伝票状態</asp:Label></span></th>
								<!--- 「伝票状態名称」テキストボックスリードオンリー --->
								<td class="last"><asp:TextBox ID="Denpyo_jyotainm" CssClass="inpReadonlyLeft inpROZenkaku5" runat="server"></asp:TextBox></td>
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Motodenpyo_bango_lbl" runat="server">元伝票番号</asp:Label></span></th>
								<!--- 「元伝票番号」テキストボックスリードオンリー --->
								<td class="last" colspan="3"><asp:TextBox ID="Motodenpyo_bango" CssClass="inpReadonlyRight inpRONum6" runat="server"></asp:TextBox></td>
							</tr>
							<tr>
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Syorinm_lbl" runat="server">処理</asp:Label></span></th>
								<!--- 「処理名称」テキストボックスリードオンリー --->
								<td class="last"><asp:TextBox ID="Syorinm" CssClass="inpReadonlyLeft inpROZenkaku4" runat="server"></asp:TextBox></td>
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Syoriymd_lbl" runat="server">処理日</asp:Label></span></th>
								<!--- 「処理日」テキストボックスリードオンリー --->
								<td class="last"><asp:TextBox ID="Syoriymd" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox></td>
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Syori_tm_lbl" runat="server">処理時間</asp:Label></span></th>
								<!--- 「処理時間」テキストボックスリードオンリー --->
								<td class="last" colspan="5"><asp:TextBox ID="Syori_tm" CssClass="inpReadonlyLeft inpROTime" runat="server"></asp:TextBox></td>
							</tr>
						</tbody>
					</table>
				<!-- /inner-01 --></div>
		    <!-- /str-search-02 --></div>
		
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
					<!---<div id="str-pager-top" class="str-pager-01">--->
		
						<!--- 件数表示部 --->
						<!--<p><adv:PageInfo ID="M1PageInfo" runat="server"></adv:PageInfo></p>-->
						<!--- ページャーを配置する場合はこの中 --->
		
					<!-- /str-pager-01 --><!---</div>-->
					<!--一覧-->
					<div class="str-result-01">
					<%-- 明細ヘッダ --%>
						<div class="str-result-hdg-01">
							<div class="col1 col_2dan">
								<asp:Label ID="M1rowno_lbl" runat="server">No.</asp:Label>
							</div>
							<div class="col2 col_2dan">
								<asp:Label ID="M1hinsyu_ryaku_nm_lbl" runat="server">品種</asp:Label>
							</div>
							<div class="col3 col_2dan">
								<asp:Label ID="M1jisya_hbn_lbl" runat="server">自社品番</asp:Label>
							</div>
							<div class="col4">
								<div><asp:Label ID="M1maker_hbn_lbl" runat="server">メーカー品番</asp:Label></div>
								<div><asp:Label ID="M1syonmk_lbl" runat="server">商品名</asp:Label></div>
							</div>
							<div class="col5 col_2dan">
								<asp:Label ID="M1iro_nm_lbl" runat="server">色</asp:Label>
							</div>
							<div class="col6 col_2dan">
								<asp:Label ID="M1size_nm_lbl" runat="server">サイズ</asp:Label>
							</div>
							<div class="col7 col_2dan">
								<asp:Label ID="M1scan_cd_lbl" runat="server">スキャンコード</asp:Label>
							</div>
							<div class="col8 col_2dan">
								<asp:Label ID="M1itemsu_lbl" runat="server">数量</asp:Label>
							</div>
							<div class="col9 col_2dan">
								<asp:Label ID="M1gen_tnk_lbl" runat="server">原単価</asp:Label>
							</div>
							<div class="col10 col_2dan">
								<asp:Label ID="M1genkakin_lbl" runat="server">原価金額</asp:Label>
							</div>

							<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
							<div style="display:none">
								<asp:Label ID="M1selectorcheckbox_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1entersyoriflg_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1dtlirokbn_lbl" runat="server"></asp:Label>
							</div>
							<!--- 隠し項目エリア↑↑↑↑↑↑↑↑↑↑↑↑↑ --->

						<!-- /str-result-hdg-01 --></div>
						<div id="str-result-item-wrap" class="adjust-elem">
							<asp:Repeater ID="M1" runat="server">
								<HeaderTemplate>
								</HeaderTemplate>
								<ItemTemplate>
									<div id="M1Row" class="str-result-item-01" runat="server">
										<div class="col1 col_2dan detail_right">
											<!--- 「ｍ１行no」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1rowno" CssClass="inpReadonlyRight inpRONum3" runat="server"></asp:TextBox>
										</div>
										<div class="col2 col_2dan detail_left">
											<!--- 「ｍ１品種略名称」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1hinsyu_ryaku_nm" CssClass="inpReadonlyLeft inpROZenkaku11 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col3 col_2dan detail_center">
											<!--- 「ｍ１自社品番」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1jisya_hbn" CssClass="inpReadonlyLeft inpRONum8" runat="server"></asp:TextBox>
										</div>
										<div class="col4 detail_left">
											<!--- 「ｍ１メーカー品番」テキストボックスリードオンリー --->
											<div>
												<asp:TextBox ID="M1maker_hbn" CssClass="inpReadonlyLeft inpROHankaku30 tooltip" runat="server"></asp:TextBox>
											</div>
											<!--- 「ｍ１商品名(カナ)」テキストボックスリードオンリー --->
											<div>
												<asp:TextBox ID="M1syonmk" CssClass="inpReadonlyLeft inpROHankaku20 tooltip" runat="server"></asp:TextBox>
											</div>
										</div>
										<div class="col5 col_2dan detail_left">
											<!--- 「ｍ１色」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1iro_nm" CssClass="inpReadonlyLeft inpROHankaku6 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col6 col_2dan detail_left">
											<!--- 「ｍ１サイズ」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1size_nm" CssClass="inpReadonlyLeft inpROHankaku4 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col7 col_2dan detail_center">
											<!--- 「ｍ１スキャンコード」一行テキストボックス（セパレート日付以外） --->
											<asp:TextBox ID="M1scan_cd" CssClass="inpReadonlyLeft inpScan" runat="server"></asp:TextBox>
										</div>
										<div class="col8 col_2dan detail_right">
											<!--- 「ｍ１数量」一行テキストボックス（セパレート日付以外） --->
											<asp:TextBox ID="M1itemsu" CssClass="inpReadonlyRight inpRONumCma7" runat="server"></asp:TextBox>
										</div>
										<div class="col9 col_2dan detail_right">
											<!--- 「ｍ１原単価」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1gen_tnk" CssClass="inpReadonlyRight inpRONumCma7" runat="server"></asp:TextBox>
										</div>
										<div class="col10 col_2dan detail_right">
											<!--- 「ｍ１原価金額」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1genkakin" CssClass="inpReadonlyRight inpRONumCma9" runat="server"></asp:TextBox>
										</div>

										<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
										<div style="display: none">
											<!--- 「ｍ１選択フラグ(隠し)」チェックボックス --->
											<adv:AdvancedCheckBox ID="M1selectorcheckbox" Text="" CssClass="" runat="server"></adv:AdvancedCheckBox>
											<!--- 「Ｍ１確定処理フラグ(隠し)」隠しフィールド --->
											<asp:hiddenfield ID="M1entersyoriflg" runat="server"></asp:hiddenfield>
											<!--- 「Ｍ１明細色区分(隠し)」隠しフィールド --->
											<asp:hiddenfield ID="M1dtlirokbn" runat="server"></asp:hiddenfield>
										</div>
										<!--- 隠し項目エリア↑↑↑↑↑↑↑↑↑↑↑↑↑ --->
									<!-- /str-result-item-01 --></div>
								</ItemTemplate>
							</asp:Repeater>
						<!-- /str-result-item-wrap --></div>

						<div class="str-result-ftr-01 adjust-elem-next">
							<div class="col1 detail_left">&nbsp;</div>
							<div class="col2 detail_left">&nbsp;</div>
							<div class="col3 detail_center">&nbsp;</div>
							<div class="col4 detail_left">&nbsp;</div>
							<div class="col5 detail_left">&nbsp;</div>
							<div class="col6 detail_left">&nbsp;</div>
							<div class="col7 detail_ftr_title">合計</div>
							<!--- 「合計数量」テキストボックスリードオンリー --->
							<div class="col8 detail_ftr"><span><asp:TextBox ID="Gokei_suryo" CssClass="inpReadonlyRight inpRONumCma9" runat="server"></asp:TextBox></span></div>
							<div class="col9 detail_left">&nbsp;</div>
							<!--- 「原価金額合計」テキストボックスリードオンリー --->
							<div class="col10 detail_ftr"><span><asp:TextBox ID="Genka_kin_gokei" CssClass="inpReadonlyRight inpRONumCma9" runat="server"></asp:TextBox></span></div>
						<!-- /str-result-ftr-01 --></div>

					<!-- /str-result-01 --></div>
					<!------------------------------------------
					  □ページャ下部領域
					-------------------------------------------->
					<span class="adjust-elem-next"></span>
				<!-- /inner --></div>
			<!-- /str-wrap-result --></div>
		<!-- /wrap --></div>	
		
		<!-- 画面上隠しエレメントを格納するエリア-->
		<div id="hiddenElements" style="display:none" runat="server">
			<asp:Label ID="Head_tenpo_cd_lbl" runat="server"></asp:Label>
			<asp:Label ID="Head_tenpo_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Nyuryokutan_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Kakuteitan_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Siiresaki_ryaku_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Bumon_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Burando_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokei_suryo_lbl" runat="server"></asp:Label>
			<asp:Label ID="Genka_kin_gokei_lbl" runat="server"></asp:Label>
		</div>
	
	</form>
</body>
</html>

