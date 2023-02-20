<%@ Page language="c#" CodeFile="tl030f02.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Tl030p01.Page.Tl030f02Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">売変確定</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="tl030p01" FormId="tl030f02" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/tl030f02.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="tl030p01" FormId="tl030f02" runat="server" />

	<!-- Js業務部品のインポート --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05003.js" charset="UTF-8"></script><!-- 明細背景色変更処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script><!-- 0埋め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05010.js" charset="UTF-8"></script><!-- カンマ編集処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05014.js" charset="UTF-8"></script><!-- 名称取得拡張 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05015.js" charset="UTF-8"></script><!-- 項目入力制御処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05019.js" charset="UTF-8"></script><!-- 情報ダイアログ表示処理(拡張版) -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05024.js" charset="UTF-8"></script><!-- 数値編集関数群 -->

	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02004.js" charset="UTF-8"></script><!-- スキャンコードチェック処理 -->
</head>

<body>
	<form id="Tl030f02" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="tl030p01" PgName="売変確定(X)" FormId="tl030f02" FormName="売変確定 明細" ></uc:Header>

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
							<col class="w-type-02"/>
							<col class="w-type-01"/>
							<col class="w-type-02"/>
							<col class="w-type-01"/>
							<col />
						</colgroup>
						<tbody>
							<tr>
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Shinseimoto_nm_lbl" runat="server">申請元</asp:Label></span></th>
								<!--- 「申請元名称」テキストボックスリードオンリー --->
								<td class="last"><asp:TextBox ID="Shinseimoto_nm" CssClass="inpReadonlyLeft inpROZenkaku2" runat="server"></asp:TextBox></td>
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Sinseitan_cd_lbl" runat="server">申請担当者</asp:Label></span></th>
								<!--- 「申請担当者コード」テキストボックスリードオンリー ---><!--- 「申請担当者名称」テキストボックスリードオンリー --->
								<td class="last"><asp:TextBox ID="Sinseitan_cd" CssClass="inpReadonlyLeft inpRONum7" runat="server"></asp:TextBox><asp:TextBox ID="Sinseitan_nm" CssClass="inpReadonlyLeft inpROZenkaku10 inpRORightNm" runat="server"></asp:TextBox></td>
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Bumon_cd_lbl" runat="server">部門</asp:Label></span></th>
								<!--- 「部門コード」テキストボックスリードオンリー ---><!--- 「部門名」テキストボックスリードオンリー --->
								<td class="last"><asp:TextBox ID="Bumon_cd" CssClass="inpReadonlyLeft inpRONum3" runat="server"></asp:TextBox> <asp:TextBox ID="Bumon_nm" CssClass="inpReadonlyLeft inpROHankaku10" runat="server"></asp:TextBox></td>
								<!--- 「売変指示no」テキストボックスリードオンリー --->
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Baihen_shiji_no_lbl" runat="server">売変指示No</asp:Label></span></th>
								<td class="last"><asp:TextBox ID="Baihen_shiji_no" CssClass="inpReadonlyLeft inpRONum10" runat="server"></asp:TextBox></td>
							</tr>
							<tr>
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Baihen_riyu_nm_lbl" runat="server">売変理由</asp:Label></span></th>
								<!--- 「売変理由名称」テキストボックスリードオンリー --->
								<td class="last"><asp:TextBox ID="Baihen_riyu_nm" CssClass="inpReadonlyLeft inpROZenkaku4" runat="server"></asp:TextBox></td>
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Aihensagyokaisi_ymd_lbl" runat="server">作業開始日</asp:Label></span></th>
								<!--- 「売変作業開始日」テキストボックスリードオンリー --->
								<td class="last"><asp:TextBox ID="Aihensagyokaisi_ymd" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox></td>
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Baihenkaisi_ymd_lbl" runat="server">開始日</asp:Label></span></th>
								<!--- 「売変開始日」テキストボックスリードオンリー --->
								<td class="last" colspan="3"><asp:TextBox ID="Baihenkaisi_ymd" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox></td>
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

					<ul id="MeisaiBtnBaihenEntyo" runat="server">
						<!--明細制御系ボタンを配置する場合はこのulタグの中-->
						<li><!--- 「全売変ボタン」ボタン --->
							<span><label><input type="button" id="Btnzenbaihen" value="" onserverclick="OnBTNZENBAIHEN_FRM" runat="server" class="icon-utility-01"/>全売変</label></span>
						</li>
						<li><!--- 「全延長ボタン」ボタン --->
							<span><label><input type="button" id="Btnzenentyo" value="" onserverclick="OnBTNZENENTYO_FRM" runat="server" class="icon-utility-02"/>全延長</label></span>
						</li>
					</ul>
					<ul id="MeisaiBtnSyoninKyakka" runat="server">
						<!--明細制御系ボタンを配置する場合はこのulタグの中-->
						<li><!--- 「全承認ボタン」ボタン --->
							<span><label><input type="button" id="Btnzensyonin" value="" onserverclick="OnBTNZENSYONIN_FRM" runat="server" class="icon-utility-01"/>全承認</label></span>
						</li>
						<li><!--- 「全却下ボタン」ボタン --->
							<span><label><input type="button" id="Btnzenkyakka" value="" onserverclick="OnBTNZENKYAKKA_FRM" runat="server" class="icon-utility-02"/>全却下</label></span>
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
					<%-- 明細ヘッダ --%>
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
							<div class="col4 headcell">
								<div><asp:Label ID="M1maker_hbn_lbl" runat="server">メーカー品番</asp:Label></div>
								<div><asp:Label ID="M1syonmk_lbl" runat="server">商品名</asp:Label></div>
							</div>
							<div class="col5">
								<div><asp:Label ID="M1iro_nm_lbl" runat="server">色</asp:Label></div>
								<div><asp:Label ID="M1season_kb_lbl" runat="server">シーズン</asp:Label></div>
							</div>
							<div class="col6 col_2dan"><asp:Label ID="M1hanbaikanryo_ymd_lbl" runat="server">販売完了日</asp:Label></div>
							<div class="col7">
								<div><asp:Label ID="M1mtobaika_tnk_lbl" runat="server">元売価</asp:Label></div>
								<div><asp:Label ID="M1gen_tnk_lbl" runat="server">原単価</asp:Label></div>
							</div>
							<div class="col8">
								<div><asp:Label ID="M1yobobaika_tnk_lbl" runat="server">要望売価</asp:Label></div>
								<div><asp:Label ID="M1kakuteibaika_tnk_lbl" runat="server">確定売価</asp:Label></div>
							</div>
							<div class="col9">
								<div><asp:Label ID="M1neire_rtu_genko_lbl" runat="server">値入率現行</asp:Label></div>
								<div><asp:Label ID="M1neire_rtu_baihengo_lbl" runat="server">値入率売変後</asp:Label></div>
							</div>
							<div class="col10">
								<div><asp:Label ID="M1zaiko_su_lbl" runat="server">在庫点数</asp:Label></div>
								<div><asp:Label ID="M1uriage_su_lbl" runat="server">売上点数</asp:Label></div>
							</div>
							<div class="col11 col_2dan"><asp:Label ID="M1syonin_flg_lbl" runat="server">承認</asp:Label></div>
							<div class="col12 col_2dan"><asp:Label ID="M1kyakka_flg_lbl" runat="server">却下</asp:Label></div>
							<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
							<div style="display:none">
								<div class="col20">
									<asp:Label ID="M1selectorcheckbox_lbl" runat="server">選択フラグ(隠し)</asp:Label>
								</div>
								<div class="col21">
									<asp:Label ID="M1entersyoriflg_lbl" runat="server">確定処理フラグ(隠し)</asp:Label>
								</div>
								<div class="col22">
									<asp:Label ID="M1dtlirokbn_lbl" runat="server">明細色区分(隠し)</asp:Label>
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
										<!--- 「ｍ１行no」テキストボックスリードオンリー --->	
										<div class="col1 detail_right col_2dan"><asp:TextBox ID="M1rowno" CssClass="inpReadonlyRight inpRONum3" runat="server"></asp:TextBox></div>
										<div class="col2 detail_left">
											<!--- 「ｍ１品種略名称」テキストボックスリードオンリー --->
											<div class="detail_left"><asp:TextBox ID="M1hinsyu_ryaku_nm" CssClass="inpReadonlyLeft inpROZenkaku10 tooltip" runat="server"></asp:TextBox></div>
											<!--- 「ｍ１ブランド名」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1burando_nm" CssClass="inpReadonlyLeft inpROHankaku12 tooltip" runat="server"></asp:TextBox></div>
										</div>
										<!--- 「ｍ１自社品番」テキストボックスリードオンリー --->
										<div class="col3 col_2dan detail_center"><asp:TextBox ID="M1jisya_hbn" CssClass="inpReadonlyLeft inpRONum8" runat="server"></asp:TextBox></div>
										<div class="col4 detail_left">
											<!--- 「ｍ１メーカー品番」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1maker_hbn" CssClass="inpReadonlyLeft inpROHankaku30 tooltip" runat="server"></asp:TextBox></div>
											<!--- 「ｍ１商品名(カナ)」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1syonmk" CssClass="inpReadonlyLeft inpROHankaku20 tooltip" runat="server"></asp:TextBox></div>
										</div>
										<div class="col5 detail_left">
											<!--- 「ｍ１色」テキストボックスリードオンリー --->
											<div class="detail_left"><asp:TextBox ID="M1iro_nm" CssClass="inpReadonlyLeft inpROHankaku6 tooltip" runat="server"></asp:TextBox></div>
											<!--- 「ｍ１シーズン」テキストボックスリードオンリー --->
											<div class="detail_center"><asp:TextBox ID="M1season_kb" CssClass="inpReadonlyCenter inpSu-01 tooltip" runat="server"></asp:TextBox></div>
										</div>
										<!--- 「ｍ１販売完了日」テキストボックスリードオンリー --->
										<div class="col6 col_2dan detail_center"><asp:TextBox ID="M1hanbaikanryo_ymd" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox></div>
										<div class="col7 detail_right">
											<!--- 「ｍ１元売価」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1mtobaika_tnk" CssClass="inpReadonlyRight inpRONumCma7" runat="server"></asp:TextBox></div>
											<!--- 「ｍ１原単価」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1gen_tnk" CssClass="inpReadonlyRight inpRONumCma7" runat="server"></asp:TextBox></div>
										</div>
										<div class="col8 detail_right">
											<!--- 「ｍ１要望売価」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1yobobaika_tnk" CssClass="inpReadonlyRight inpRONumCma7" runat="server"></asp:TextBox></div>
											<!--- 「ｍ１確定売価」一行テキストボックス（セパレート日付以外） --->
											<div class="col8 detail_right"><md:MDTextBox ID="M1kakuteibaika_tnk" CssClass="inpSu-07 str-result-input" runat="server"></md:MDTextBox></div>
										</div>
										<div class="col9 detail_right">
											<!--- 「ｍ１値入率現行」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1neire_rtu_genko" CssClass="inpReadonlyRight inpRONumCma4" runat="server"></asp:TextBox></div>
											<!--- 「ｍ１値入率売変後」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1neire_rtu_baihengo" CssClass="inpReadonlyRight inpRONumCma4" runat="server"></asp:TextBox></div>
										</div>
										<div class="col10 detail_right">
											<!--- 「ｍ１在庫数」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1zaiko_su" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox></div>
											<!--- 「ｍ１売上数」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1uriage_su" CssClass="inpReadonlyRight inpRONumCma7" runat="server"></asp:TextBox></div>
										</div>
										<!--- 「ｍ１承認状態」チェックボックス --->
										<div class="col11 col_2dan detail_center"><adv:AdvancedCheckBox ID="M1syonin_flg" Text="" CssClass="" runat="server"></adv:AdvancedCheckBox></div>
										<!--- 「ｍ１却下フラグ」チェックボックス --->
										<div class="col12 col_2dan detail_center"><adv:AdvancedCheckBox ID="M1kyakka_flg" Text="" CssClass="" runat="server"></adv:AdvancedCheckBox></div>
										<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
										<div style="display:none">
											<div class="col20">
												<!--- 「ｍ１選択フラグ(隠し)」チェックボックス --->
												<adv:AdvancedCheckBox ID="M1selectorcheckbox" Text="選択フラグ(隠し)" CssClass="" runat="server"></adv:AdvancedCheckBox>
											</div>
											<div class="col21">
												<!--- 「Ｍ１確定処理フラグ(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1entersyoriflg" runat="server"></asp:hiddenfield>
											</div>
											<div class="col22">
												<!--- 「Ｍ１明細色区分(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1dtlirokbn" runat="server"></asp:hiddenfield>
											</div>
										</div>
										<!--- 隠し項目エリア↑↑↑↑↑↑↑↑↑↑↑↑↑ --->
									<!-- /str-result-item-01 --></div>
								</ItemTemplate>
							</asp:Repeater>
						<!-- /str-result-item-wrap --></div>
					<!-- /str-result-01 --></div>
					<!------------------------------------------
					  □ページャ下部領域
					-------------------------------------------->
					<span class="adjust-elem-next"></span>
					<!-- /inner --></div>
					<div id="footerBtnArea" class="pad0" runat="server">
						<div id="str-pager-bottom" class="str-pager-01 pad0">
							<p class="ftr-note">
								<font>※売上点数は前日までの値です。※赤表示の商品はカラー別売変不可商品です。確定後、全カラーの売価が変更されます。</font>
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
			<asp:Label ID="Sinseitan_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Bumon_nm_lbl" runat="server"></asp:Label>
		</div>
	
	</form>
</body>
</html>

