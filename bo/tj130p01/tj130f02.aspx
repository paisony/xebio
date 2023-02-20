<%@ Page language="c#" CodeFile="tj130f02.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Tj130p01.Page.Tj130f02Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">棚卸重複検索</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="tj130p01" FormId="tj130f02" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/tj130f02.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="tj130p01" FormId="tj130f02" runat="server" />

	<!-- Js業務部品のインポート --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
</head>

<body>
	<form id="Tj130f02" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="tj130p01" PgName="棚卸重複検索(X)" FormId="tj130f02" FormName="棚卸重複検索 明細" ></uc:Header>
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
						<col class="w-type-01"/>
						<col class="w-type-03"/>
						<col class="w-type-01"/>
						<col class="w-type-04"/>
						<col class="w-type-01"/>
						<col />
					</colgroup>
						<tbody>
							<tr>
								<!--- 「フェイスno」テキストボックスリードオンリー --->
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Face_no_lbl" runat="server">フェイスNo</asp:Label></span></th>
								<td class="last">
									<asp:TextBox ID="Face_no" CssClass="inpReadonlyLeft inpRONum5" runat="server"></asp:TextBox>
								</td>
								<!--- 「棚段」テキストボックスリードオンリー --->
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Tana_dan_lbl" runat="server">棚段</asp:Label></span></th>
								<td class="last">
									<asp:TextBox ID="Tana_dan" CssClass="inpReadonlyLeft inpRONum2" runat="server"></asp:TextBox>
								</td>
								<!--- 「回数」テキストボックスリードオンリー --->
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Kai_su_lbl" runat="server">回数</asp:Label></span></th>
								<td class="last">
									<asp:TextBox ID="Kai_su" CssClass="inpReadonlyLeft inpRONum2" runat="server"></asp:TextBox>
								</td>
								<!--- 「点数棚卸数量」テキストボックスリードオンリー --->
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Tensutanaorosi_su_lbl" runat="server">点数棚卸数量</asp:Label></span></th>
								<td class="last">
									<asp:TextBox ID="Tensutanaorosi_su" CssClass="inpReadonlyLeft inpRONumCmaMinus6" runat="server"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<!--- 「入力担当者コード」テキストボックスリードオンリー ---><!--- 「入力担当者名称」テキストボックスリードオンリー --->
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Nyuryokutan_cd_lbl" runat="server">入力担当者</asp:Label></span></th>
								<td class="last">
									<asp:TextBox ID="Nyuryokutan_cd" CssClass="inpReadonlyLeft inpRONum7" runat="server"></asp:TextBox>
									<asp:TextBox ID="Nyuryokutan_nm" CssClass="inpReadonlyLeft inpROZenkaku10 inpRORightNm" runat="server"></asp:TextBox>
								</td>
								<!--- 「入力日」テキストボックスリードオンリー --->
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Nyuryoku_ymd_lbl" runat="server">入力日</asp:Label></span></th>
								<td class="last">
									<asp:TextBox ID="Nyuryoku_ymd" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox>
								</td>
								<!--- 「理由コメント情報」テキストボックスリードオンリー --->
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Riyucomment_nm_lbl" runat="server">棚卸理由</asp:Label></span></th>
								<td class="last">
									<asp:TextBox ID="Riyucomment_nm" CssClass="inpReadonlyLeft inpROZenkaku8 " runat="server"></asp:TextBox>
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
					</ul>
					<ul>
						<li>
							<!--帳票／CSV系ボタンを配置する場合はこのulタグの中-->
							<!--- 「印刷ボタン」ボタン --->
							<span><label><input type="button" id="Btnprint" value="" onserverclick="OnBTNPRINT_FRM" runat="server" class="icon-utility-04"/>印刷</label></span>
						</li>
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
					<%-- 明細ヘッダ --%>
						<div class="str-result-hdg-01">
							<div class="col1 col_2dan"><asp:Label ID="M1rowno_lbl" runat="server">No.</asp:Label></div>
							<div class="col2">
								<div><asp:Label ID="M1bumon_cd_lbl" runat="server">部門</asp:Label></div>
								<div><asp:Label ID="M1hinsyu_ryaku_nm_lbl" runat="server">品種</asp:Label></div>
							</div>
							<div class="col3 col_2dan"><asp:Label ID="M1burando_nm_lbl" runat="server">ブランド</asp:Label></div>
							<div class="col4 col_2dan"><asp:Label ID="M1jisya_hbn_lbl" runat="server">自社品番</asp:Label></div>
							<div class="col5">
								<div><asp:Label ID="M1maker_hbn_lbl" runat="server">メーカー品番</asp:Label></div>
								<div><asp:Label ID="M1syonmk_lbl" runat="server">商品名</asp:Label></div>
							</div>
							<div class="col6">
								<div><asp:Label ID="M1iro_nm_lbl" runat="server">色</asp:Label></div>
								<div><asp:Label ID="M1size_nm_lbl" runat="server">サイズ</asp:Label></div>
							</div>
							<div class="col7">
								<div><asp:Label ID="M1scan_cd_lbl" runat="server">スキャンコード</asp:Label></div>
								<div><asp:Label ID="M1hyoji_syohin_cd_lbl" runat="server">商品コード</asp:Label></div>
							</div>
							<div class="col8 col_2dan"><asp:Label ID="Label1" runat="server">ｽｷｬﾝ数量</asp:Label></div>
							<div class="col9 col_2dan"><asp:Label ID="M1teisei_suryo_lbl" runat="server">訂正数量</asp:Label></div>
							<div class="col10 col_2dan"><asp:Label ID="M1gokei_suryo_lbl" runat="server">合計数量</asp:Label></div>
							<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
							<div style="display:none">
								<asp:Label ID="M1selectorcheckbox_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1entersyoriflg_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1dtlirokbn_lbl" runat="server"></asp:Label>
							</div>
							<!--- 隠し項目エリア↑↑↑↑↑↑↑↑↑↑↑↑↑ --->
						<!-- /str-result-hdg-01 --></div>

					<!------------------------------------------
					  □一覧明細領域
					-------------------------------------------->
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
											<!--- 「ｍ１部門コード」テキストボックスリードオンリー ---><!--- 「ｍ１部門カナ名」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1bumon_cd" CssClass="inpReadonlyLeft inpRONum3" runat="server"></asp:TextBox><asp:TextBox ID="M1bumonkana_nm" CssClass="inpReadonlyLeft inpRORightNm tooltip" runat="server"></asp:TextBox></div>
											<!--- 「ｍ１品種略名称」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1hinsyu_ryaku_nm" CssClass="inpReadonlyLeft inpROZenkaku10 tooltip" runat="server"></asp:TextBox></div>
										</div>
										<div class="col3 col_2dan detail_left">
											<!--- 「ｍ１ブランド名」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1burando_nm" CssClass="inpReadonlyLeft inpROHankaku12 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col4 col_2dan detail_center">
											<!--- 「ｍ１自社品番」テキストボックスリードオンリー --->
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
										<div class="col7 detail_center">
											<!--- 「ｍ１スキャンコード」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1scan_cd" CssClass="inpReadonlyLeft inpRONum13" runat="server"></asp:TextBox></div>
											<!--- 「ｍ１表示用商品コード」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1hyoji_syohin_cd" CssClass="inpReadonlyLeft inpROSyohinCd" runat="server"></asp:TextBox></div>
										</div>
										<div class="col8 col_2dan detail_right">
											<!--- 「ｍ１スキャン数量」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1scan_su" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
										</div>
										<div class="col9 col_2dan detail_right">
											<!--- 「ｍ１訂正数量」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1teisei_suryo" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
										</div>
										<div class="col10 col_2dan detail_right">
											<!--- 「ｍ１合計数量」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1gokei_suryo" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
										</div>
										<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
										<div style="display:none">
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
						<div class="col3 detail_left">&nbsp;</div>
						<div class="col4 detail_center">&nbsp;</div>
						<div class="col5 detail_left">&nbsp;</div>
						<div class="col6 detail_left">&nbsp;</div>
						<div class="col7 detail_ftr_title">合計</div>
						<!--- 「合計スキャン数量」テキストボックスリードオンリー --->
						<div class="col8 detail_ftr"><asp:TextBox ID="Gokeiscan_su" CssClass="inpReadonlyRight inpRONumCma6" runat="server"></asp:TextBox></div>
						<!--- 「合計訂正数量」テキストボックスリードオンリー --->
						<div class="col9 detail_ftr"><asp:TextBox ID="Gokeiteisei_suryo" CssClass="inpReadonlyRight inpRONumCmaMinus6" runat="server"></asp:TextBox></div>
						<!--- 「総合計数量」テキストボックスリードオンリー --->
						<div class="col10 detail_ftr"><asp:TextBox ID="All_gokei_suryo" CssClass="inpReadonlyRight inpRONumCma6" runat="server"></asp:TextBox></div>
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
			<asp:Label ID="M1bumonkana_nm_lbl" runat="server"></asp:Label>
			<!--- 「モードNO」隠しフィールド --->
			<asp:hiddenfield ID="Modeno" runat="server"></asp:hiddenfield>
			<!--- 「選択モードNO」隠しフィールド --->
			<asp:hiddenfield ID="Stkmodeno" runat="server"></asp:hiddenfield>
			<asp:Label ID="Nyuryokutan_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokeiscan_su_lbl" runat="server"></asp:Label>
			<!--- 「理由コード」隠しフィールド --->
			<asp:hiddenfield ID="Riyu_cd" runat="server"></asp:hiddenfield>
			<asp:Label ID="Gokeiteisei_suryo_lbl" runat="server"></asp:Label>
			<asp:Label ID="All_gokei_suryo_lbl" runat="server"></asp:Label>
		</div>
	</form>
</body>
</html>


