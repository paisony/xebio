<%@ Page language="c#" CodeFile="ta040f02.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Ta040p01.Page.Ta040f02Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">補充依頼状況照会</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="ta040p01" FormId="ta040f02" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/ta040f02.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="ta040p01" FormId="ta040f02" runat="server" />
	
	<!-- Js業務部品のインポート --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05003.js" charset="UTF-8"></script><!-- 明細背景色変更処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
</head>

<body>
	<form id="Ta040f02" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="ta040p01" PgName="補充依頼状況照会" FormId="ta040f02" FormName="補充依頼状況照会 明細" ></uc:Header>
			<!------------------------------------------
				□ヘッダー部
			-------------------------------------------->

			<!--- 「戻るボタン」ボタン --->
			<p class="headerBackBtn">
				<input type="button" id="Btnback" value="" onserverclick="OnBTNBACK_FRM" runat="server" class="btn type-back"/>
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
				<!--- <p class="required">*が付いている項目は必須入力になります。</p> --->
					<div class="inner-01">
						<table>
							<colgroup>
								<col class="w-type-01"/>
								<col class="w-type-03"/>
								<col class="w-type-01"/>
								<col class="w-type-03"/>
								<col class="w-type-01"/>
								<col class="w-type-03"/>
								<col class="w-type-01"/>
								<col />
							</colgroup>
							<tbody>
								<tr>
									<th class="last">
										<span class="tbl-hdg"><asp:Label ID="Henko_kbn_nm_lbl" runat="server">変更区分</asp:Label></span>
									</th>
									<td class ="last">
										<!--- 「変更区分名称」テキストボックスリードオンリー --->
										<asp:TextBox ID="Henko_kbn_nm" CssClass="inpReadonlyLeft inpROZenkaku6" runat="server"></asp:TextBox>
									</td>
									<th class="last">
										<span class="tbl-hdg"><asp:Label ID="Bumon_cd_lbl" runat="server">部門</asp:Label></span>
									</th>
									<td class ="last">
    									<!--- 「部門コード」テキストボックスリードオンリー --->
	    								<!--- 「部門名」テキストボックスリードオンリー --->
										<asp:TextBox ID="Bumon_cd" CssClass="inpReadonlyLeft inpRONum3" runat="server"></asp:TextBox><asp:TextBox ID="Bumon_nm" CssClass="inpReadonlyLeft inpROZenkaku10 inpRORightNm" runat="server"></asp:TextBox>
									</td>
									<th class ="last">
										<span class="tbl-hdg"><asp:Label ID="Kessai_ymd_lbl" runat="server">決裁日</asp:Label></span>
									</th>
									<td class ="last">
    									<!--- 「決裁日」テキストボックスリードオンリー --->
										<asp:TextBox ID="Kessai_ymd" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox>
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
							<div class="col1 col_2dan detail_right">
								<asp:Label ID="M1rowno_lbl" runat="server">No.</asp:Label>
							</div>
							<div class="col2  detail_left">
								<div><asp:Label ID="M1hinsyu_ryaku_nm_lbl" runat="server">品種</asp:Label></div>
								<div><asp:Label ID="M1burando_nm_lbl" runat="server">ブランド</asp:Label></div>
							</div>
							<div class="col3 detail_center">
								<div><asp:Label ID="M1jisya_hbn_lbl" runat="server">自社品番</asp:Label></div>
								<div><asp:Label ID="M1syohin_zokusei_lbl" runat="server">コア</asp:Label></div>
							</div>
							<div class="col4 col_2dan detail_center">
								<asp:Label ID="M1scan_cd_lbl" runat="server">スキャンコード</asp:Label>
							</div>
							<div class="col5 detail_left">
								<div><asp:Label ID="M1maker_hbn_lbl" runat="server">メーカー品番</asp:Label></div>
								<div><asp:Label ID="M1syonmk_lbl" runat="server">商品名</asp:Label></div>
							</div>
							<div class="col6 detail_left">
								<div><asp:Label ID="M1iro_nm_lbl" runat="server">色</asp:Label></div>
								<div><asp:Label ID="M1size_nm_lbl" runat="server">サイズ</asp:Label></div>
							</div>
							<div class="col7 detail_left">
								<div><asp:Label ID="M1season_nm_lbl" runat="server">シーズン</asp:Label></div>
								<div><asp:Label ID="M1hanbaikanryo_ymd_lbl" runat="server">販完日</asp:Label></div>
							</div>
							<div class="col8">
								<div class="col8-1 cell headcell"><asp:Label ID="M1hattyu_su_lbl" runat="server">発注数量</asp:Label></div>
								<div class="col8-2 cell headcell"><asp:Label ID="M1haibun_su_lbl" runat="server">配分数量</asp:Label></div>
								<div class="col8-3 cell headcell"><asp:Label ID="M1genkakin_lbl" runat="server">原価金額</asp:Label></div>
								<div class="col8 headcell"><asp:Label ID="M1comment_nm_lbl" runat="server">コメント</asp:Label></div>
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
                        <!-- /str-result-hdg-01 --></div>
						<div id="str-result-item-wrap" class="adjust-elem">
							<asp:Repeater ID="M1" runat="server">
								<HeaderTemplate>
								</HeaderTemplate>
								<ItemTemplate>
									<div class="str-result-item-01">
										<div class="col1 col_2dan detail_right">
											<!--- 「ｍ１行no」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1rowno" CssClass="inpReadonlyRight inpRONum4" runat="server"></asp:TextBox>
										</div>
										<div class="col2 detail_left">
											<!--- 「ｍ１品種略名称」テキストボックスリードオンリー --->
											<div>
												<asp:TextBox ID="M1hinsyu_ryaku_nm" CssClass="inpReadonlyLeft inpROZenkaku15 tooltip" runat="server"></asp:TextBox>
											</div>
											<!--- 「ｍ１ブランド名」テキストボックスリードオンリー --->
											<div>
												<asp:TextBox ID="M1burando_nm" CssClass="inpReadonlyLeft inpROHankaku16 tooltip" runat="server"></asp:TextBox>
											</div>
										</div>
										<div class="col3 detail_center">
											<div>
												<!--- 「ｍ１自社品番」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1jisya_hbn" CssClass="inpReadonlyCenter inpRONum8" runat="server"></asp:TextBox>
											</div>
											<div class="detail_left">
												<!--- 「ｍ１商品属性」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1syohin_zokusei" CssClass="inpReadonlyCenter inpROHankaku3 tooltip" runat="server"></asp:TextBox>
											</div>
										</div>
										<div class="col4 col_2dan detail_center">
											<!--- 「ｍ１スキャンコード」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1scan_cd" CssClass="inpReadonlyLeft inpRONum13" runat="server"></asp:TextBox>
										</div>
										<div class="col5 detail_left">
											<div>
												<!--- 「ｍ１メーカー品番」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1maker_hbn" CssClass="inpReadonlyLeft inpROHankaku30 tooltip" runat="server"></asp:TextBox>
											</div>
											<div>
												<!--- 「ｍ１商品名(カナ)」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1syonmk" CssClass="inpReadonlyLeft inpROHankaku20 tooltip" runat="server"></asp:TextBox>
											</div>
										</div>
										<div class="col6 detail_left">
											<div>
												<!--- 「ｍ１色」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1iro_nm" CssClass="inpReadonlyLeft inpROHankaku10 tooltip" runat="server"></asp:TextBox>
											</div>
											<div>
												<!--- 「ｍ１サイズ」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1size_nm" CssClass="inpReadonlyLeft inpROHankaku4 tooltip" runat="server"></asp:TextBox>
											</div>
										</div>
										<div class="col7 detail_left">
											<div>
												<!--- 「ｍ１シーズン名称」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1season_nm" CssClass="inpReadonlyLeft inpROZenkaku2 tooltip" runat="server"></asp:TextBox>
											</div>
											<div class="detail_center">
												<!--- 「ｍ１販売完了日」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1hanbaikanryo_ymd" CssClass="inpReadonlyCenter inpRODate" runat="server"></asp:TextBox>
											</div>
										</div>
										<div class="col8">
											<div class="col8-1 cell detail_right">
												<!--- 「ｍ１発注数量」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1hattyu_su" CssClass="inpReadonlyRight inpRONumCma7" runat="server"></asp:TextBox>
											</div>
											<div class="col8-2 cell detail_right">
												<!--- 「ｍ１配分数量」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1haibun_su" CssClass="inpReadonlyRight inpRONumCma7" runat="server"></asp:TextBox>
											</div>
											<div class="col8-3 cell detail_right">
												<!--- 「ｍ１原価金額」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1genkakin" CssClass="inpReadonlyRight inpRONumCma7" runat="server"></asp:TextBox>
											</div>
											<div class="col8 cell detail_left">
												<!--- 「ｍ１コメント」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1comment_nm" CssClass="inpReadonlyLeft inpROZenkaku20" runat="server"></asp:TextBox>
											</div>
										</div>
										<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
										<div style="display: none">
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
							<div class="col1 detail_right">&nbsp;</div>
							<div class="col2 detail_left">&nbsp;</div>
							<div class="col3 detail_left">&nbsp;</div>
							<div class="col4 detail_left">&nbsp;</div>
							<div class="col5 detail_left">&nbsp;</div>
							<div class="col6 detail_left">&nbsp;</div>
							<div class="col7 detail_left">&nbsp;</div>
							<div class="col8">
								<div class="col8-1 cell detail_ftr_title">
									<span>合計</span>
								</div>
								<div class="col8-2 cell detail_ftr">
									<!--- 「合計配分数量」テキストボックスリードオンリー --->
									<span><asp:TextBox ID="Gokei_haibun_su" CssClass="inpReadonlyRight inpRONumCma9" runat="server"></asp:TextBox></span>
								</div>
								<div class="col8-3 cell detail_ftr">
									<!--- 「合計原価金額」テキストボックスリードオンリー --->
									<span><asp:TextBox ID="Gokei_genkakin" CssClass="inpReadonlyRight inpRONumCma9" runat="server"></asp:TextBox></span>
								</div>
							</div>
							<!-- /str-result-ftr-01 --></div>
					<!-- /str-result-01 --></div>		

					<!------------------------------------------
					  □ページャ下部領域
					-------------------------------------------->
					<span class="adjust-elem-next"></span>
			    	<!-- /inner --></div>
			    <!-- /str-wrap-result --></div>
		<!-- /str-search-02 --></div>	
		<!-- /wrap --></div>	
		
		<!-- 画面上隠しエレメントを格納するエリア-->
		<div id="hiddenElements" style="display:none" runat="server">
			<asp:Label ID="Head_tenpo_cd_lbl" runat="server"></asp:Label>
			<asp:Label ID="Head_tenpo_nm_lbl" runat="server"></asp:Label>

			<asp:Label ID="Bumon_nm_lbl" runat="server"></asp:Label></span>

			<asp:Label ID="Gokei_genkakin_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokei_haibun_su_lbl" runat="server"></asp:Label>
		     
		</div>
	
	</form>
</body>
</html>

