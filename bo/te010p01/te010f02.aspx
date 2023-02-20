<%@ Page language="c#" CodeFile="te010f02.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Te010p01.Page.Te010f02Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">移動出荷検索</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="te010p01" FormId="te010f02" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/te010f02.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="te010p01" FormId="te010f02" runat="server" />

	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->

	<!-- 業務共通コントロールのインポート-->
	<%@ Register TagPrefix="uc" TagName="common" Src="~/pjcommon/businessCommon/usercontrol/boCommonControl.ascx" %>
</head>

<body>
	<form id="Te010f02" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="te010p01" PgName="移動出荷検索" FormId="te010f02" FormName="移動出荷検索 明細" ></uc:Header>
			
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
							<col />
						</colgroup>
						<tbody>
							<tr>
								<!--- 「伝票番号」 --->
								<!--- 「伝票番号」テキストボックスリードオンリー --->
								<th class ="last"><span class="tbl-hdg"><asp:Label ID="Denpyo_bango_lbl" runat="server">伝票番号</asp:Label></span></th>
								<td class ="last">
									<asp:TextBox ID="Denpyo_bango" CssClass="inpReadonlyLeft inpRONum6" runat="server"></asp:TextBox>
								</td>
								<!--- 「指示番号」 --->
								<!--- 「指示番号」テキストボックスリードオンリー --->
								<th class ="last"><span class="tbl-hdg"><asp:Label ID="Siji_bango_lbl" runat="server">指示番号</asp:Label></span></th>
								<td colspan="5" class ="last">
									<asp:TextBox ID="Siji_bango" CssClass="inpReadonlyLeft inpRONum10" runat="server"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<!--- 「SCMコード」 --->
								<!--- 「scmコード」テキストボックスリードオンリー --->
								<th class ="last"><span class="tbl-hdg"><asp:Label ID="Scm_cd_lbl" runat="server">SCMコード</asp:Label></span></th>
								<td class ="last">
									<asp:TextBox ID="Scm_cd" CssClass="inpReadonlyLeft inpRONum20" runat="server"></asp:TextBox>
								</td>
								<!--- 「出荷理由」 --->
								<!--- 「出荷理由名称」テキストボックスリードオンリー --->
								<th class ="last"><span class="tbl-hdg"><asp:Label ID="Shukkariyu_nm_lbl" runat="server">出荷理由</asp:Label></span></th>
								<td class ="last">
									<asp:TextBox ID="Shukkariyu_nm" CssClass="inpReadonlyLeft inpROZenkaku4" runat="server"></asp:TextBox>
								</td>
								<!--- 「出荷担当者」 --->
								<!--- 「出荷担当者コード」テキストボックスリードオンリー --->
								<!--- 「出荷担当者名称」テキストボックスリードオンリー --->
								<th class ="last"><span class="tbl-hdg"><asp:Label ID="Syukkatan_cd_lbl" runat="server">出荷担当者</asp:Label></span></th>
								<td class ="last">
									<asp:TextBox ID="Syukkatan_cd" CssClass="inpReadonlyLeft inpRONum7" runat="server"></asp:TextBox>
									<asp:TextBox ID="Syukkatan_nm" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
								</td>
								<!--- 「出荷日」 --->
								<!--- 「出荷日」テキストボックスリードオンリー --->
								<th class ="last"><span class="tbl-hdg"><asp:Label ID="Syukka_ymd_lbl" runat="server">出荷日</asp:Label></span></th>
								<td class ="last">
									<asp:TextBox ID="Syukka_ymd" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<!--- 「会社」 --->
								<!--- 「会社コード」テキストボックスリードオンリー --->
								<!--- 「会社名称」テキストボックスリードオンリー --->
								<th class ="last"><span class="tbl-hdg"><asp:Label ID="Kaisya_cd_lbl" runat="server">会社</asp:Label></span></th>
								<td class ="last">
									<asp:TextBox ID="Kaisya_cd" CssClass="inpReadonlyLeft inpRONum2" runat="server"></asp:TextBox>
									<asp:TextBox ID="Kaisya_nm" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
								</td>
								<!--- 「入荷店」 --->
								<!--- 「入荷店コード」テキストボックスリードオンリー --->
								<!--- 「入荷店名称」テキストボックスリードオンリー --->
								<th class ="last"><span class="tbl-hdg"><asp:Label ID="Jyuryoten_cd_lbl" runat="server">入荷店</asp:Label></span></th>
								<td class ="last">
									<asp:TextBox ID="Jyuryoten_cd" CssClass="inpReadonlyLeft inpRONum4" runat="server"></asp:TextBox>
									<asp:TextBox ID="Juryoten_nm" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
								</td>
								<!--- 「入荷担当者」 --->
								<!--- 「入荷担当者コード」テキストボックスリードオンリー --->
								<!--- 「入荷担当者名称」テキストボックスリードオンリー --->
								<th class ="last"><span class="tbl-hdg"><asp:Label ID="Nyukatan_cd_lbl" runat="server">入荷担当者</asp:Label></span></th>
								<td class ="last">
									<asp:TextBox ID="Nyukatan_cd" CssClass="inpReadonlyLeft inpRONum7" runat="server"></asp:TextBox>
									<asp:TextBox ID="Nyukatan_nm" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
								</td>
								<!--- 「入荷日」 --->
								<!--- 「入荷日」テキストボックスリードオンリー --->
								<th class ="last"><span class="tbl-hdg"><asp:Label ID="Jyuryo_ymd_lbl" runat="server">入荷日</asp:Label></span></th>
								<td class ="last">
									<asp:TextBox ID="Jyuryo_ymd" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<!--- 「処理」 --->
								<!--- 「処理名称」テキストボックスリードオンリー --->
								<th class ="last"><span class="tbl-hdg"><asp:Label ID="Syorinm_lbl" runat="server">処理</asp:Label></span></th>
								<td class ="last">
									<asp:TextBox ID="Syorinm" CssClass="inpReadonlyLeft inpROZenkaku4" runat="server"></asp:TextBox>
								</td>
								<!--- 「処理日」 --->
								<!--- 「処理日」テキストボックスリードオンリー --->
								<th class ="last"><span class="tbl-hdg"><asp:Label ID="Syoriymd_lbl" runat="server">処理日</asp:Label></span></th>
								<td class ="last">
									<asp:TextBox ID="Syoriymd" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox>
								</td>
								<!--- 「処理時間」 --->
								<!--- 「処理時間」テキストボックスリードオンリー --->
								<th class ="last"><span class="tbl-hdg"><asp:Label ID="Syori_tm_lbl" runat="server">処理時間</asp:Label></span></th>
								<td colspan="3" class ="last">
									<asp:TextBox ID="Syori_tm" CssClass="inpReadonlyLeft inpROTime" runat="server"></asp:TextBox>
								</td>
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
							<div class="col1 col_2dan">
								<asp:Label ID="M1rowno_lbl" runat="server">No.</asp:Label>
							</div>
							<div class="col2">
								<div><asp:Label ID="M1bumon_cd_lbl" runat="server">部門</asp:Label></div>
								<div><asp:Label ID="M1hinsyu_ryaku_nm_lbl" runat="server">品種</asp:Label></div>
							</div>
							<div class="col3 col_2dan">
								<asp:Label ID="M1burando_nm_lbl" runat="server">ブランド</asp:Label>
							</div>
							<div class="col4 col_2dan">
								<asp:Label ID="M1jisya_hbn_lbl" runat="server">自社品番</asp:Label>
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
								<asp:Label ID="M1syukka_su_lbl" runat="server">出荷数量</asp:Label>
							</div>
							<div class="col9 col_2dan">
								<asp:Label ID="M1kakutei_su_lbl" runat="server">確定数量</asp:Label>
							</div>
							<div class="col10 col_2dan">
								<asp:Label ID="M1gen_tnk_lbl" runat="server">原単価</asp:Label>
							</div>
							<div class="col11 col_2dan">
								<asp:Label ID="M1genkakin_lbl" runat="server">原価金額</asp:Label>
							</div>
							<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
							<div style="display:none">
								<div class="col11">
								<asp:Label ID="M1bumonkana_nm_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1selectorcheckbox_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1entersyoriflg_lbl" runat="server"></asp:Label>
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
										<div class="col1 col_2dan detail_right">
											<!--- 「ｍ１行no」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1rowno" CssClass="inpReadonlyRight inpRONum3" runat="server"></asp:TextBox>
										</div>
										<div class="col2 detail_left">
											<!--- 「ｍ１部門コード」テキストボックスリードオンリー --->
											<!--- 「ｍ１部門カナ名」テキストボックスリードオンリー --->
											<div>
												<asp:TextBox ID="M1bumon_cd" CssClass="inpReadonlyLeft inpRONum3" runat="server"></asp:TextBox>
												<asp:TextBox ID="M1bumonkana_nm" CssClass="inpReadonlyLeft inpRORightNm inpROHankaku10 tooltip" runat="server"></asp:TextBox>
											</div>
											<div>
												<!--- 「ｍ１品種略名称」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1hinsyu_ryaku_nm" CssClass="inpReadonlyLeft inpROZenkaku10 tooltip" runat="server"></asp:TextBox>
											</div>
										</div>
										<div class="col3 col_2dan detail_left">
											<!--- 「ｍ１ブランド名」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1burando_nm" CssClass="inpReadonlyLeft inpROHankaku10 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col4 col_2dan detail_center">
											<!--- 「ｍ１自社品番」一行テキストボックス（セパレート日付以外） --->
											<asp:TextBox ID="M1jisya_hbn" CssClass="inpReadonlyLeft inpRONum8" runat="server"></asp:TextBox>
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
											<div><asp:TextBox ID="M1size_nm" CssClass="inpReadonlyLeft inpROHankaku4 tooltip" runat="server"></asp:TextBox></div>
										</div>
										<div class="col7 col_2dan detail_center">
											<!--- 「ｍ１スキャンコード」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1scan_cd" CssClass="inpReadonlyLeft inpScan" runat="server"></asp:TextBox>
										</div>
										<div class="col8 col_2dan detail_right">
											<!--- 「ｍ１出荷数量（梱包単位）」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1syukka_su" CssClass="inpReadonlyRight inpRONumCma6" runat="server"></asp:TextBox>
										</div>
										<div class="col9 col_2dan detail_right">
											<!--- 「ｍ１確定数量」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1kakutei_su" CssClass="inpReadonlyRight inpRONumCma6" runat="server"></asp:TextBox>
										</div>
										<div class="col10 col_2dan detail_right">
											<!--- 「ｍ１原単価」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1gen_tnk" CssClass="inpReadonlyRight inpRONumCma7" runat="server"></asp:TextBox>
										</div>
										<div class="col11 col_2dan detail_right">
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
									<!-- /str-result-item-01 --></div>
								</ItemTemplate>
							</asp:Repeater>
						<!-- /str-result-item-wrap --></div>

						<div class="str-result-ftr-01 adjust-elem-next">
						<div class="col1 detail_left">&nbsp;</div>
						<div class="col2 detail_left">&nbsp;</div>
						<div class="col3 detail_left">&nbsp;</div>
						<div class="col4 detail_center">&nbsp;</div>
						<div class="col5 detail_left">&nbsp;</div>
						<div class="col6 detail_left">&nbsp;</div>
						<div class="col7 detail_ftr_title">合計</div>
						<div class="col8 detail_ftr">
							<!--- 「出荷数量合計」テキストボックスリードオンリー --->
							<span><asp:TextBox ID="Syukkasuryo_gokei" CssClass="inpReadonlyRight inpRONumCma8" runat="server"></asp:TextBox></span>
						</div>
						<div class="col9 detail_ftr">
							<!--- 「合計確定数量」テキストボックスリードオンリー --->
							<span><asp:TextBox ID="Gokeikakutei_su" CssClass="inpReadonlyRight inpRONumCma8" runat="server"></asp:TextBox></span>
						</div>
						<div class="col10 detail_left">&nbsp;</div>
						<div class="col11 detail_ftr">
							<!--- 「原価金額合計」テキストボックスリードオンリー --->
							<span><asp:TextBox ID="Genka_kin_gokei" CssClass="inpReadonlyRight inpRONumCma9" runat="server"></asp:TextBox></span>
						</div>
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

			<asp:Label ID="Syukkatan_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Kaisya_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Juryoten_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Nyukatan_nm_lbl" runat="server"></asp:Label>
			
			<asp:Label ID="Syukkasuryo_gokei_lbl" runat="server">合計</asp:Label>
			<asp:Label ID="Gokeikakutei_su_lbl" runat="server"></asp:Label>
			<asp:Label ID="Genka_kin_gokei_lbl" runat="server"></asp:Label>
		</div>
	
	</form>
</body>
</html>

