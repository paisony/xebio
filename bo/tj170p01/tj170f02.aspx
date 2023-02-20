<%@ Page language="c#" CodeFile="tj170f02.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Tj170p01.Page.Tj170f02Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">棚卸ロスリスト出力</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="tj170p01" FormId="tj170f02" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/tj170f02.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="tj170p01" FormId="tj170f02" runat="server" />
</head>

<body>
	<form id="Tj170f02" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="tj170p01" PgName="棚卸ロスリスト出力" FormId="tj170f02" FormName="棚卸ロスリスト出力 明細" ></uc:Header>

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
						<col class="w-type-01"/>
						<col class="w-type-02"/>
						<col class="w-type-03"/>
						<col class="w-type-04"/>
						<col />
					</colgroup>
					<tbody>
						<tr>
							<th>
								<span class="tbl-hdg"><asp:Label ID="Syohingun1_cd_lbl" runat="server">商品群1</asp:Label></span>
							</th>
							<td>
								<!--- 「商品群1コード」テキストボックスリードオンリー --->
								<!--- 「商品群1略式名称」テキストボックスリードオンリー --->
								<asp:TextBox ID="Syohingun1_cd" CssClass="inpReadonlyLeft inpRONum4" runat="server"></asp:TextBox>								
								<asp:TextBox ID="Syohingun1_ryaku_nm" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
							</td>
							<th>
								<span class="tbl-hdg"><asp:Label ID="Syohingun2_cd_lbl" runat="server">商品群2</asp:Label></span>
							</th>
							<td>
								<!--- 「商品群2コード」テキストボックスリードオンリー --->
								<!--- 「商品群2名称」テキストボックスリードオンリー --->
								<asp:TextBox ID="Syohingun2_cd" CssClass="inpReadonlyLeft inpRONum5" runat="server"></asp:TextBox>
								<asp:TextBox ID="Grpnm" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
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
					<li>
					</li>
					<li>
					</li>
					<li>
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
						<div class="col1 col_2dan">
							<asp:Label ID="M1rowno_lbl" runat="server">No.</asp:Label>
						</div>
						<div class="col2">
							<div>
								<asp:Label ID="M1bumon_cd_lbl" runat="server">部門</asp:Label>
							</div>
							<div>
								<asp:Label ID="M1hinsyu_ryaku_nm_lbl" runat="server">品種</asp:Label>
							</div>
						</div>
						<div class="col3">
							<div>
								<asp:Label ID="M1burando_nm_lbl" runat="server">ブランド</asp:Label>
							</div>
							<div>
								<asp:Label ID="M1jisya_hbn_lbl" runat="server">自社品番</asp:Label>
							</div>
						</div>
						<div class="col4">
							<div>
								<asp:Label ID="M1maker_hbn_lbl" runat="server">メーカー品番</asp:Label>
							</div>
							<div>
								<asp:Label ID="M1syonmk_lbl" runat="server">商品名</asp:Label>
							</div>
						</div>
						<div class="col5">
							<div>
								<asp:Label ID="M1iro_nm_lbl" runat="server">色</asp:Label>
							</div>
							<div>
								<asp:Label ID="M1size_nm_lbl" runat="server">サイズ</asp:Label>
							</div>
						</div>
						<div class="col6 col_2dan">
							<asp:Label ID="M1scan_cd_lbl" runat="server">スキャンコード</asp:Label>
						</div>
						<div class="col7">
							<div>
								<asp:Label ID="M1genbaika_tnk_lbl" runat="server">現売価</asp:Label>
							</div>
							<div>
								<asp:Label ID="M1hyoka_tnk_lbl" runat="server">評価単価</asp:Label>
							</div>
						</div>
						<div class="col8">
							<div>
								<asp:Label ID="M1tanajityobo_su_lbl" runat="server">棚時帳簿数</asp:Label>
							</div>
							<div>
								<asp:Label ID="M1tanajisekiso_su_lbl" runat="server">棚時積送数</asp:Label>
							</div>
						</div>
						<div class="col9">
							<div>
								<asp:Label ID="M1jitana_su_lbl" runat="server">実棚数</asp:Label>	
							</div>
							<div>
								<asp:Label ID="M1ikoukebarai_su_lbl" runat="server">以降受払数</asp:Label>
							</div>
						</div>
						<div class="col10">
							<div>
								<asp:Label ID="M1rironzaiko_su_lbl" runat="server">理論在庫数</asp:Label>
							</div>
							<div>
								<asp:Label ID="M1rirontanaorosi_su_lbl" runat="server">理論棚卸数</asp:Label>
							</div>
						</div>
						<div class="col11">
							<div>
								<asp:Label ID="M1loss_su_lbl" runat="server">ロス数</asp:Label>
							</div>
							<div>
								<asp:Label ID="M1loss_kin_lbl" runat="server">ロス金額</asp:Label>
							</div>
						</div>
						<div class="col12">
							<div>
								<asp:Label ID="M1face_no_lbl" runat="server">ﾌｪｲｽNo</asp:Label>
							</div>
							<div>
								<asp:Label ID="M1tana_dan_lbl" runat="server">棚段</asp:Label>
							</div>
						</div>
						<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
						<div style="display:none">
							<asp:Label ID="M1bumonkana_nm_lbl" runat="server"></asp:Label>
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
										<asp:TextBox ID="M1rowno" CssClass="inpReadonlyRight inpRONum4" runat="server"></asp:TextBox>
									</div>
									<div class="col2 detail_left">
										<div>
											<!--- 「ｍ１部門コード」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1bumon_cd" CssClass="inpReadonlyLeft inpRONum3" runat="server"></asp:TextBox>
											<!--- 「ｍ１部門カナ名」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1bumonkana_nm" CssClass="inpReadonlyLeft inpROHankaku8 tooltip" runat="server"></asp:TextBox>
										</div>
										<div>
											<!--- 「ｍ１品種略名称」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1hinsyu_ryaku_nm" CssClass="inpReadonlyLeft inpROZenkaku8 tooltip" runat="server"></asp:TextBox>
										</div>
									</div>
									<div class="col3 detail_left">
										<div>
											<!--- 「ｍ１ブランド名」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1burando_nm" CssClass="inpReadonlyLeft inpROHankaku10 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="detail_center">
											<!--- 「ｍ１自社品番」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1jisya_hbn" CssClass="inpReadonlyLeft inpRONum8" runat="server"></asp:TextBox>
										</div>
									</div>
									<div class="col4 detail_left">
										<div>
											<!--- 「ｍ１メーカー品番」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1maker_hbn" CssClass="inpReadonlyLeft inpROHankaku20 tooltip" runat="server"></asp:TextBox>
										</div>
										<div>
											<!--- 「ｍ１商品名(カナ)」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1syonmk" CssClass="inpReadonlyLeft inpROHankaku20 tooltip" runat="server"></asp:TextBox>
										</div>
									</div>
									<div class="col5 detail_left">
										<div>
											<!--- 「ｍ１色」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1iro_nm" CssClass="inpReadonlyLeft inpROHankaku6 tooltip" runat="server"></asp:TextBox>
										</div>
										<div>
											<!--- 「ｍ１サイズ」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1size_nm" CssClass="inpReadonlyLeft inpROHankaku4 tooltip" runat="server"></asp:TextBox>
										</div>
									</div>
									<div class="col6 col_2dan detail_center">
											<!--- 「ｍ１スキャンコード」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1scan_cd" CssClass="inpReadonlyLeft inpRONum13" runat="server"></asp:TextBox>
									</div>
									<div class="col7 detail_right">
										<div>
											<!--- 「ｍ１現売価」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1genbaika_tnk" CssClass="inpReadonlyRight inpRONumCmaMinus8" runat="server"></asp:TextBox>
										</div>
										<div>
											<!--- 「ｍ１評価単価」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1hyoka_tnk" CssClass="inpReadonlyRight inpRONumCmaMinus8" runat="server"></asp:TextBox>
										</div>
									</div>
									<div class="col8 detail_right">
										<div>
											<!--- 「ｍ１棚時帳簿数」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1tanajityobo_su" CssClass="inpReadonlyRight inpRONumCmaMinus7" runat="server"></asp:TextBox>
										</div>
										<div>
											<!--- 「ｍ１棚時積送数」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1tanajisekiso_su" CssClass="inpReadonlyRight inpRONumCmaMinus7" runat="server"></asp:TextBox>
										</div>
									</div>
									<div class="col9 detail_right">
										<div>
											<!--- 「ｍ１実棚数」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1jitana_su" CssClass="inpReadonlyRight inpRONumCmaMinus7" runat="server"></asp:TextBox>
										</div>
										<div>
											<!--- 「ｍ１以降受払数」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1ikoukebarai_su" CssClass="inpReadonlyRight inpRONumCmaMinus7" runat="server"></asp:TextBox>
										</div>
									</div>
									<div class="col10 detail_right">
										<div>
											<!--- 「ｍ１理論在庫数」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1rironzaiko_su" CssClass="inpReadonlyRight inpRONumCmaMinus7" runat="server"></asp:TextBox>
										</div>
										<div>
											<!--- 「ｍ１理論棚卸数」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1rirontanaorosi_su" CssClass="inpReadonlyRight inpRONumCmaMinus7" runat="server"></asp:TextBox>
										</div>
									</div>
									<div class="col11 detail_right">
										<div>
											<!--- 「ｍ１ロス数」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1loss_su" CssClass="inpReadonlyRight inpRONumCmaMinus7" runat="server"></asp:TextBox>
										</div>
										<div>
											<!--- 「ｍ１ロス金額」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1loss_kin" CssClass="inpReadonlyRight inpRONumCmaMinus8" runat="server"></asp:TextBox>
										</div>
									</div>
									<div class="col12 detail_center">
										<div>
											<!--- 「ｍ１フェイス№」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1face_no" CssClass="inpReadonlyRight inpRONum5" runat="server"></asp:TextBox>
										</div>
										<div class="detail_right">
											<!--- 「ｍ１棚段」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1tana_dan" CssClass="inpReadonlyRight inpRONum2" runat="server"></asp:TextBox>
										</div>
									</div>
									<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
									<div style="display:none">
									
									</div>
									<!--- 隠し項目エリア↑↑↑↑↑↑↑↑↑↑↑↑↑ --->
								<!-- /str-result-item-01 --></div>
							</ItemTemplate>
						</asp:Repeater>
					<!-- /str-result-item-wrap --></div>

					<div class="str-result-ftr-01 adjust-elem-next">
						<div class="col1 detail_left col_2dan">&nbsp;</div>
						<div class="col2 detail_left col_2dan">&nbsp;</div>
						<div class="col3 detail_left col_2dan">&nbsp;</div>
						<div class="col4 detail_left col_2dan">&nbsp;</div>
						<div class="col5 detail_left col_2dan">&nbsp;</div>
						<div class="col6 detail_left col_2dan">&nbsp;</div>
						<div class="col7 detail_ftr_title col_2dan">
								<asp:Label ID="Gokeitanajityobo_su_lbl" runat="server">合計</asp:Label>
						</div>
						<div class="col8 detail_right_ftr">
							<div class="col8 detail_right_ftr">
								<!--- 「合計棚時帳簿数」テキストボックスリードオンリー --->
								<span><asp:TextBox ID="Gokeitanajityobo_su" CssClass="inpReadonlyRight inpRONumCmaMinus9" runat="server"></asp:TextBox></span>
							</div>
							<div class="col8 detail_right_ftr">
								<!--- 「合計棚時積送数」テキストボックスリードオンリー --->
								<span><asp:TextBox ID="Gokeitanajisekiso_su" CssClass="inpReadonlyRight inpRONumCmaMinus9" runat="server"></asp:TextBox></span>
							</div>
						</div>
						<div class="col9 detail_right_ftr">
							<div>
								<!--- 「合計実棚数」テキストボックスリードオンリー --->
								<asp:TextBox ID="Gokeijitana_su" CssClass="inpReadonlyRight inpRONumCmaMinus9" runat="server"></asp:TextBox>
							</div>
							<div>											
								<!--- 「合計以降受払数」テキストボックスリードオンリー --->
								<asp:TextBox ID="Gokeiikoukebarai_su" CssClass="inpReadonlyRight inpRONumCmaMinus9" runat="server"></asp:TextBox>
							</div>
						</div>
						<div class="col10 detail_ftr">
							<div>
								<!--- 「合計理論在庫数」テキストボックスリードオンリー --->
								<asp:TextBox ID="Gokeirironzaiko_su" CssClass="inpReadonlyRight inpRONumCmaMinus9" runat="server"></asp:TextBox>
							</div>
							<div>
								<!--- 「合計理論棚卸数」テキストボックスリードオンリー --->
								<asp:TextBox ID="Gokeirirontanaorosi_su" CssClass="inpReadonlyRight inpRONumCmaMinus9" runat="server"></asp:TextBox>
							</div>
						</div>
						<div class="col11 detail_right_ftr">
							<div>
								<!--- 「合計ロス数」テキストボックスリードオンリー --->
								<span><asp:TextBox ID="Gokeiloss_su" CssClass="inpReadonlyRight inpRONumCmaMinus9" runat="server"></asp:TextBox></span>
							</div>
							<div>											
								<!--- 「合計ロス金額」テキストボックスリードオンリー --->
								<span><asp:TextBox ID="Gokeiloss_kin" CssClass="inpReadonlyRight inpRONumCmaMinus9" runat="server"></asp:TextBox></span>
							</div>
						</div>
						<div class="col12 col_2dan detail_left">&nbsp;</div>
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
		    <asp:Label ID="Syohingun1_ryaku_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Grpnm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Head_tenpo_cd_lbl" runat="server"></asp:Label>
			<asp:Label ID="Head_tenpo_nm_lbl" runat="server"></asp:Label>
			<asp:hiddenfield ID="Modeno" runat="server"></asp:hiddenfield>
			<asp:hiddenfield ID="Stkmodeno" runat="server"></asp:hiddenfield>
			<asp:Label ID="Gokeitanajisekiso_su_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokeijitana_su_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokeiikoukebarai_su_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokeirironzaiko_su_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokeirirontanaorosi_su_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokeiloss_su_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokeiloss_kin_lbl" runat="server"></asp:Label>
		</div>
	</form>
</body>
</html>

