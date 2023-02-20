<%@ Page language="c#" CodeFile="tb020f02.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Tb020p01.Page.Tb020f02Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">SCM仕入入荷検索</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="tb020p01" FormId="tb020f02" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/tb020f02.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="tb020p01" FormId="tb020f02" runat="server" />

	<!-- Js業務部品のインポート --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05003.js" charset="UTF-8"></script><!-- 明細背景色変更処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->

</head>

<body>
	<form id="Tb020f02" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="tb020p01" PgName="SCM仕入入荷検索" FormId="tb020f02" FormName="SCM仕入入荷検索 明細" ></uc:Header>
			
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
						<col class="w-type-06"/>
						<col class="w-type-03"/>
						<col class="w-type-01"/>
						<col class="w-type-04"/>
						<col class="w-type-01"/>
						<col class="w-type-05"/>
						<col class="w-type-01"/>
						<col />
					</colgroup>
					<tr>
						<th>
							<span class="tbl-hdg">
								<asp:Label ID="Scm_cd_lbl" runat="server">SCMコード</asp:Label>
							</span>
						</th>
						<td>
							<!--- 「scmコード」テキストボックスリードオンリー --->
							<asp:TextBox ID="Scm_cd" CssClass="inpReadonlyLeft inpSCM" runat="server">
							</asp:TextBox>
						</td>
						<th>
							<span class="tbl-hdg">
								<asp:Label ID="Siiresaki_cd_lbl" runat="server">仕入先</asp:Label>
							</span>
						</th>
						<td>
							<!--- 「仕入先コード」テキストボックスリードオンリー --->
							<!--- 「仕入先略式名称」テキストボックスリードオンリー --->
							<asp:TextBox ID="Siiresaki_cd" CssClass="inpReadonlyLeft inpShiire" runat="server"></asp:TextBox>
							<asp:TextBox ID="Siiresaki_ryaku_nm" CssClass="inpReadonlyLeft inpRORightNm inpROZenkaku10 tooltip" runat="server"></asp:TextBox>
						</td>
						<th>
							<span class="tbl-hdg">
								<asp:Label ID="Nyukayotei_ymd_lbl" runat="server">入荷予定日</asp:Label>
							</span>
						</th>
						<td>
							<!--- 「入荷予定日」テキストボックスリードオンリー --->
							<asp:TextBox ID="Nyukayotei_ymd" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox>
						</td>
						<th>
							<span class="tbl-hdg">
								<asp:Label ID="Siire_kakutei_ymd_lbl" runat="server">仕入確定日</asp:Label>
							</span>
						</th>
						<td>
							<!--- 「仕入確定日」テキストボックスリードオンリー --->
							<asp:TextBox ID="Siire_kakutei_ymd" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox>
						</td>
						<th>
							<span class="tbl-hdg">
								<asp:Label ID="Scm_jotainm_lbl" runat="server">SCM状態</asp:Label>
							</span>
						</th>
						<td>
							<!--- 「scm状態名称」テキストボックスリードオンリー --->
							<asp:TextBox ID="Scm_jotainm" CssClass="inpReadonlyLeft inpz" runat="server"></asp:TextBox>
						</td>
					</tr>
				</table>
			<!-- /inner-02 --></div>
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
				<!-- button -->
				<div id="str-btn-area" class="str-btn-utility">
					<ul>
						<!--明細制御系ボタンを配置する場合はこのulタグの中-->
					</ul>
					<ul>
						<!--帳票／CSV系ボタンを配置する場合はこのulタグの中-->
					</ul>
				<!-- /utility --></div>
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
							<div class="col2 col_2dan">
								<asp:Label ID="M1denpyo_bango_lbl" runat="server">伝票</asp:Label>
							</div>
							<div class="col3 col_2dan">
								<asp:Label ID="M1denpyogyo_no_lbl" runat="server">行</asp:Label>
							</div>
							<div class="col4 col">
								<div><asp:Label ID="M1bumon_cd_lbl" runat="server">部門</asp:Label></div>
								<div><asp:Label ID="M1hinsyu_ryaku_nm_lbl" runat="server">品種</asp:Label></div>
							</div>
							<div class="col5 col_2dan">
								<asp:Label ID="M1burando_nm_lbl" runat="server">ブランド</asp:Label>
							</div>
							<div class="col6 col_2dan">
								<asp:Label ID="M1jisya_hbn_lbl" runat="server">自社品番</asp:Label>
							</div>
							<div class="col7">
								<div><asp:Label ID="M1maker_hbn_lbl" runat="server">メーカー品番</asp:Label></div>
								<div><asp:Label ID="M1syonmk_lbl" runat="server">商品名</asp:Label></div>
							</div>
							<div class="col8">
								<div><asp:Label ID="M1iro_nm_lbl" runat="server">色</asp:Label></div>
								<asp:Label ID="M1size_nm_lbl" runat="server">サイズ</asp:Label>
							</div>
							<div class="col9 col_2dan">
								<asp:Label ID="M1scan_cd_lbl" runat="server">スキャンコード</asp:Label>
							</div>
							<div class="col10">
								<div><asp:Label ID="M1itemsu_lbl" runat="server">数量</asp:Label></div>
								<div><asp:Label ID="M1gen_tnk_lbl" runat="server">原単価</asp:Label></div>
							</div>
							<div class="col11 col_2dan">
								<asp:Label ID="M1genka_kin_lbl" runat="server">原価金額</asp:Label>
							</div>
						<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
						<div style="display:none">
							<div class="col17">
								<asp:Label ID="M1selectorcheckbox_lbl" runat="server"></asp:Label>
							</div>
							<div class="col18">
								<asp:Label ID="M1entersyoriflg_lbl" runat="server"></asp:Label>
							</div>
							<div class="col19">
								<asp:Label ID="M1dtlirokbn_lbl" runat="server"></asp:Label>
							</div>
						</div>
						<!--- 隠し項目エリア↑↑↑↑↑↑↑↑↑↑↑↑↑ --->
						<!-- /str-result-hdg-01 --></div>
						<div id="str-result-item-wrap" class="adjust-elem">
							<asp:Repeater ID="M1" runat="server">
								<ItemTemplate>
									<div class="str-result-item-01">
										<div class="col1 col_2dan detail_right">
											<!--- 「ｍ１行no」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1rowno" CssClass="inpReadonlyRight inpRONum4" runat="server"></asp:TextBox>
										</div>
										<div class="col2 col_2dan detail_right">
											<!--- 「ｍ１伝票番号」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1denpyo_bango" CssClass="inpReadonlyLeft inpDenpyo" runat="server"></asp:TextBox>
										</div>
										<div class="col3 col_2dan detail_right">
											<!--- 「ｍ１伝票行№」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1denpyogyo_no" CssClass="inpReadonlyRight inpRONum3" runat="server"></asp:TextBox>
										</div>
										<div class="col4 detail_left">
										<div>
											<!--- 「ｍ１部門コード」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1bumon_cd" CssClass="inpReadonlyLeft inpBumon" runat="server"></asp:TextBox>
											<!--- 「ｍ１部門カナ名」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1bumonkana_nm" CssClass="inpReadonlyLeft inpBumonNm9" runat="server"></asp:TextBox>
										</div>
										<!--- 「ｍ１品種略名称」テキストボックスリードオンリー --->
										<div><asp:TextBox ID="M1hinsyu_ryaku_nm" CssClass="inpReadonlyLeft inpROZenkaku10 tooltip" runat="server"></asp:TextBox></div>
										</div>
										<div class="col5 col_2dan detail_left">
											<!--- 「ｍ１ブランド名」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1burando_nm" CssClass="inpReadonlyLeft inpROHankaku12 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col6 col_2dan detail_right">
											<!--- 「ｍ１自社品番」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1jisya_hbn" CssClass="inpReadonlyLeft inpRONum8" runat="server"></asp:TextBox>
										</div>
										<div class="col7 detail_left">
											<!--- 「ｍ１メーカー品番」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1maker_hbn" CssClass="inpReadonlyLeft inpROHankaku30 tooltip" runat="server"></asp:TextBox></div>
											<!--- 「ｍ１商品名(カナ)」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1syonmk" CssClass="inpReadonlyLeft inpROHankaku20 tooltip" runat="server"></asp:TextBox></div>
										</div>
										<div class="col8 detail_left">
											<!--- 「ｍ１色」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1iro_nm" CssClass="inpReadonlyLeft inpROHankaku6 tooltip" runat="server"></asp:TextBox></div>
											<!--- 「ｍ１サイズ」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1size_nm" CssClass="inpReadonlyLeft inpROHankaku4 tooltip" runat="server"></asp:TextBox></div>
										</div>
										<div class="col9 col_2dan detail_center">
											<!--- 「ｍ１スキャンコード」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1scan_cd" CssClass="inpReadonlyLeft inpROHankaku13 inpScan" runat="server"></asp:TextBox>
										</div>
										<div class="col10 detail_right">
											<!--- 「ｍ１数量」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1itemsu" CssClass="inpReadonlyRight inpSu-07" runat="server"></asp:TextBox></div>
											<!--- 「ｍ１原単価」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1gen_tnk" CssClass="inpReadonlyRight inpRONumCma7" runat="server"></asp:TextBox></div>
										</div>
										<div class="col11 col_2dan detail_right">
											<!--- 「ｍ１原価金額」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1genka_kin" CssClass="inpReadonlyRight inpRONumCma7" runat="server"></asp:TextBox>
										</div>
										<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
										<div style="display:none">
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
							<div class="col7 detail_left">&nbsp;</div>
							<div class="col8 detail_left">&nbsp;</div>
							<div class="col9 detail_ftr_title">合計</div>
							<!--- 「合計数量」テキストボックスリードオンリー --->
							<div class="col10 detail_ftr"><span><asp:TextBox ID="Gokei_suryo" CssClass="inpReadonlyRight inpRONumCma9" runat="server"></asp:TextBox></span></div>
							<!--- 「原価金額合計」テキストボックスリードオンリー --->
							<div class="col11 detail_ftr"><span><asp:TextBox ID="Genka_kin_gokei" CssClass="inpReadonlyRight inpRONumCma9" runat="server"></asp:TextBox></span></div>
						<!-- /str-result-ftr-01 --></div>

					<!-- /str-result-01 --></div>
					<!------------------------------------------
					  □ページャ下部領域
					-------------------------------------------->
					<span class="adjust-elem-next"></span>
				<!-- /inner --></div>
				<div id="footerBtnArea" class="pad0" runat="server">
					<div id="str-pager-bottom" class="str-pager-01 pad0 heightZero">
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
			<asp:Label ID="Head_tenpo_cd_lbl" runat="server"></asp:Label>
			<asp:Label ID="Head_tenpo_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="M1bumonkana_nm_lbl" runat="server">部門</asp:Label>
			<asp:Label ID="Siiresaki_ryaku_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokei_suryo_lbl" runat="server"></asp:Label>
			<asp:Label ID="Genka_kin_gokei_lbl" runat="server"></asp:Label>
		</div>
	
	</form>
</body>
</html>

