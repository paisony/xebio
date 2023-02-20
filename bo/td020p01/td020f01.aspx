<%@ Page language="c#" CodeFile="td020f01.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Td020p01.Page.Td020f01Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">返品入力(ﾏﾆｭｱﾙ)</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="td020p01" FormId="td020f01" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/td020f01.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="td020p01" FormId="td020f01" runat="server" />

	<!-- Js業務部品のインポート --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02001.js" charset="UTF-8"></script><!-- 店舗検索 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02002.js" charset="UTF-8"></script><!-- 仕入先マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02004.js" charset="UTF-8"></script><!-- 発注マスタ取得(スキャンコード) -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02010.js" charset="UTF-8"></script><!-- 部門マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02018.js" charset="UTF-8"></script><!-- 返品指示データ取得 -->

	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05002.js" charset="UTF-8"></script><!-- スキャンコード丸め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05003.js" charset="UTF-8"></script><!-- 明細背景色変更処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script><!-- 0埋め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05009.js" charset="UTF-8"></script><!-- 指示番号丸め処理(返品用) -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05010.js" charset="UTF-8"></script><!-- カンマ編集処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05014.js" charset="UTF-8"></script><!-- 名称取得拡張 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05015.js" charset="UTF-8"></script><!-- 項目制御処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05019.js" charset="UTF-8"></script><!-- 情報ダイアログ表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05024.js" charset="UTF-8"></script><!-- 数値編集関数群 -->

	<!-- 業務共通コントロールのインポート-->
	<%@ Register TagPrefix="uc" TagName="common" Src="~/pjcommon/businessCommon/usercontrol/boCommonControl.ascx" %>
</head>

<body>
	<form id="Td020f01" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="td020p01" PgName="返品入力(ﾏﾆｭｱﾙ)" FormId="td020f01" FormName="返品入力(ﾏﾆｭｱﾙ)" ></uc:Header>
			<!------------------------------------------	
				□業務共通コントロール
			------------------------------------------->	
			<uc:common ID="bocommon" runat="server"></uc:common>	

			<!------------------------------------------
				□ヘッダー部
			-------------------------------------------->

			<!--- 「ヘッダ店舗コード」一行テキストボックス（セパレート日付以外） --->
			<!--- 「ボタンヘッダ店舗コード」ボタン --->
			<!--- 「ヘッダ店舗名」テキストボックスリードオンリー --->
			<p class="headerTenpo">
				<span class="icon-in">
					<md:MDTextBox ID="Head_tenpo_cd" CssClass="inpSerch inpHeaderTenpo" runat="server"></md:MDTextBox><input type="button" id="Btnheadtenpocd" name="Btnheadtenpocd" value="" runat="server" class="icon-search"/>
				</span>
				<asp:TextBox ID="Head_tenpo_nm" CssClass="inpReadonlyLeft inpHeaderTenpoNm" runat="server"></asp:TextBox>
			</p>
			
		<!-------------------------------------------------------------------
								1.カード部
		--------------------------------------------------------------------->
			<!-- search-list -->
			<div class="str-search-02">
				<div class="inner-01">
					<p class="required">*が付いている項目は必須入力になります。</p>
					<table>
						<colgroup>
							<col class="w-type-01"/>
							<col class="w-type-02"/>
							<col class="w-type-01"/>
							<col />
						</colgroup>
						<tr>
							<!--- 「返品理由」 --->
							<th>
								<span class="tbl-hdg"><asp:Label ID="Henpin_riyu_lbl" runat="server">返品理由</asp:Label></span>
							</th>
							<!--- 「返品理由」ドロップダウンリスト --->
							<td>
								<md:MDConditionDDList ID="Henpin_riyu" ConditionName="henpin_riyu_kbn" CssClass="slt-ddl slt-henpinriyu" runat="server"></md:MDConditionDDList>
								<span class="select-arrow"></span>
							</td>
							<!--- 「指示番号」 --->
							<th>
								<span class="tbl-hdg"><asp:Label ID="Siji_bango_lbl" runat="server">指示番号</asp:Label></span>
							</th>
							<!--- 「指示番号」一行テキストボックス（セパレート日付以外） --->
							<td>
								<md:MDTextBox ID="Siji_bango" CssClass="inpHenpinSijiNo" runat="server"></md:MDTextBox>
							</td>
						</tr>
						<tr>
							<!--- 「仕入先」 --->
							<th>
								<span class="tbl-hdg"><asp:Label ID="Siiresaki_cd_lbl" runat="server">仕入先</asp:Label></span>
							</th>
							<!--- 「仕入先コード」一行テキストボックス（セパレート日付以外） --->
							<!--- 「仕入先コードボタン」ボタン --->
							<!--- 「仕入先略式名称」テキストボックスリードオンリー --->
							<td>
								<span class="icon-in">
									<md:MDTextBox ID="Siiresaki_cd" CssClass="inpSerch inpShiire" runat="server"></md:MDTextBox>
									<input type="button" id="Btnsiiresaki_cd" name="Btnsiiresaki_cd" value="" runat="server" class="icon-search"/>
								</span>
								<asp:TextBox ID="Siiresaki_ryaku_nm" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
							</td>
							<!--- 「備考」 --->
							<th>
								<span class="tbl-hdg">
									<asp:Label ID="Biko_lbl" runat="server">備考</asp:Label>
									<asp:Label ID="Biko_Req" runat="server" CssClass="required">*</asp:Label>
								</span>
							</th>
							<!--- 「備考」一行テキストボックス（セパレート日付以外） --->
							<td>
								<md:MDTextBox ID="Biko" CssClass="inpBikou" runat="server"></md:MDTextBox>
							</td>
						</tr>
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
					<div id="meisaiBtnArea" class="inner pad0" runat="server">
					<ul>
						<!--明細制御系ボタンを配置する場合はこのulタグの中-->
						<!--- 「ページ追加ボタン」ボタン --->
						<li><span><label><input type="button" id="Btnpageins" value="" onserverclick="OnBTNPAGEINS_MINSX" runat="server" class="icon-utility-06"/>ページ追加</label></span></li>
						<!--- 「サイズ選択ボタン」ボタン --->
						<li><span><label><input type="button" id="Btnsizstk" name="Btnsizstk" value="" onserverclick="OnBTNSIZSTK_FRM" runat="server" class="icon-utility-07"/>サイズ選択</label></span></li>
						<!--- 「行削除ボタン」ボタン --->
						<li><span><label><input type="button" id="Btnrowdel" value="" onserverclick="OnBTNROWDEL_FRM" runat="server" class="icon-utility-03"/>行削除</label></span></li>
						<!--- 「CSV取込ボタン」ボタン --->
						<li><span id="Btncsv_torikomiArea" runat="server"><label><input type="button" id="Btncsv_torikomi" value="" onserverclick="OnBTNCSV_TORIKOMI_FRM" runat="server" class="icon-utility-05"/>CSV取込</label></span></li>
					</ul>
					<ul>
						<!--帳票／CSV系ボタンを配置する場合はこのulタグの中-->
					</ul>
					<!-- /meisaiBtnArea --></div>
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
							<div class="col2">
								<div><asp:Label ID="M1tenpo_cd_lbl" runat="server">店舗</asp:Label></div>
								<div><asp:Label ID="M1bumon_cd_lbl" runat="server">部門</asp:Label></div>
							</div>
							<div class="col3">
								<div><asp:Label ID="M1hinsyu_ryaku_nm_lbl" runat="server">品種</asp:Label></div>
								<div><asp:Label ID="M1burando_nm_lbl" runat="server">ブランド</asp:Label></div>
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
								<asp:Label ID="M1btntenpocd_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1tenpo_nm_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1bumonkana_nm_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1itemsu_hdn_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1genka_kin_hdn_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1selectorcheckbox_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1entersyoriflg_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1dtlirokbn_lbl" runat="server"></asp:Label>
							</div>
						<!-- /str-result-hdg-01 --></div>
						<div id="str-result-item-wrap" class="adjust-elem">
							<asp:Repeater ID="M1" runat="server">
								<HeaderTemplate>
								</HeaderTemplate>
								<ItemTemplate>
									<div id="M1Row" class="str-result-item-01" runat="server">
										<div class="col1 col_2dan detail_right">
											<!--- 「ｍ１行no」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1rowno" CssClass="inpReadonlyRight inpRONum4" runat="server"></asp:TextBox>
										</div>
										<div class="col2 detail_left">
											<!--- 「ｍ１店舗コード」一行テキストボックス（セパレート日付以外） --->
											<!--- 「Ｍ１店舗コードボタン」ボタン --->
											<!--- 「ｍ１店舗名」テキストボックスリードオンリー --->
											<div>
												<span class="icon-in">
													<md:MDTextBox ID="M1tenpo_cd" CssClass="inpSerch inpTenpo" runat="server"></md:MDTextBox>
													<input type="button" id="M1btntenpocd" name="M1btntenpocd" value="" runat="server" class="icon-search"/>
												</span><asp:TextBox ID="M1tenpo_nm" CssClass="inpReadonlyLeft inpRORightNm inpROZenkaku8 tooltip" runat="server"></asp:TextBox>
											</div>
											<!--- 「ｍ１部門コード」テキストボックスリードオンリー --->
											<!--- 「ｍ１部門カナ名」テキストボックスリードオンリー --->
											<div>
												<asp:TextBox ID="M1bumon_cd" CssClass="inpReadonlyLeft inpRONum3" runat="server"></asp:TextBox>
												<asp:TextBox ID="M1bumonkana_nm" CssClass="inpReadonlyLeft inpRORightNm inpROHankaku12 tooltip" runat="server"></asp:TextBox>
											</div>
										</div>
										<div class="col3 detail_left">
											<div>
												<!--- 「ｍ１品種略名称」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1hinsyu_ryaku_nm" CssClass="inpReadonlyLeft inpROZenkaku12 tooltip" runat="server"></asp:TextBox>
											</div>
											<div>
												<!--- 「ｍ１ブランド名」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1burando_nm" CssClass="inpReadonlyLeft inpROHankaku12 tooltip" runat="server"></asp:TextBox>
											</div>
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
										<div class="col7 col_2dan detail_center">
											<!--- 「ｍ１スキャンコード」一行テキストボックス（セパレート日付以外） --->
											<md:MDTextBox ID="M1scan_cd" CssClass="inpScan" runat="server"></md:MDTextBox>
										</div>
										<div class="col8 col_2dan detail_center">
											<!--- 「ｍ１数量」一行テキストボックス（セパレート日付以外） --->
											<md:MDTextBox ID="M1itemsu" CssClass="inpSu-07" runat="server"></md:MDTextBox>
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
										<div style="display:none">
											<!--- 「Ｍ１数量（隠し）」隠しフィールド --->
											<asp:hiddenfield ID="M1itemsu_hdn" runat="server"></asp:hiddenfield>
											<!--- 「Ｍ１原価金額（隠し）」隠しフィールド --->
											<asp:hiddenfield ID="M1genka_kin_hdn" runat="server"></asp:hiddenfield>
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
						<div class="col1 detail_right">&nbsp;</div>
						<div class="col2 detail_left">&nbsp;</div>
						<div class="col3 detail_left">&nbsp;</div>
						<div class="col4 detail_left">&nbsp;</div>
						<div class="col5 detail_left">&nbsp;</div>
						<div class="col6 detail_right">&nbsp;</div>
						<div class="col7 detail_ftr_title">合計</div>
						<div class="col8 detail_ftr">
							<!--- 「合計数量」テキストボックスリードオンリー --->
							<span><asp:TextBox ID="Gokei_suryo" CssClass="inpReadonlyRight inpRONumCma9" runat="server"></asp:TextBox></span>
						</div>
						<div class="col9 detail_left">&nbsp;</div>
						<div class="col10 detail_ftr">
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
				<div id="footerBtnArea" class="pad0" runat="server">
					<div id="str-pager-bottom" class="footer str-pager-01 pad0">
						<p>
						</p>
						<p>
							<!-- ページャ下部にボタンを配置する場合はこの中 -->
							<!--- 「ボタン確定」ボタン --->
							<input type="button" id="Btnenter" value="確定" onserverclick="OnBTNENTER_FRM" runat="server" class="btn type-01"/>
						</p>
					<!-- /str-pager-01 --></div>
				<!-- /footerBtnArea --></div>
			<!-- /str-wrap-result --></div>
		<!-- /wrap --></div>
		
		<!-- 画面上隠しエレメントを格納するエリア-->
		<div id="hiddenElements" style="display:none" runat="server">
			<asp:Label ID="Head_tenpo_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Head_tenpo_cd_lbl" runat="server">店舗</asp:Label>
			<asp:Label ID="Head_tenpo_cd_Req" runat="server" CssClass="required">*</asp:Label>
			<asp:Label ID="Siiresaki_ryaku_nm_lbl" runat="server"></asp:Label>

			<asp:Label ID="Gokei_suryo_lbl" runat="server">合計</asp:Label>
			<asp:Label ID="Gokeikakutei_su_lbl" runat="server"></asp:Label>
			<asp:Label ID="Genka_kin_gokei_lbl" runat="server"></asp:Label>
			
		</div>
	
	</form>
</body>
</html>

