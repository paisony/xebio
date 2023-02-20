<%@ Page language="c#" CodeFile="tb090f02.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Tb090p01.Page.Tb090f02Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">仕入伝票訂正</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="tb090p01" FormId="tb090f02" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/tb090f02.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="tb090p01" FormId="tb090f02" runat="server" />
	<!-- Js業務部品のインポート --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05002.js" charset="UTF-8"></script><!-- スキャンコード丸め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05003.js" charset="UTF-8"></script><!-- 明細背景色変更処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script><!-- 0埋め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05010.js" charset="UTF-8"></script><!-- カンマ編集処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05014.js" charset="UTF-8"></script><!-- 名称取得拡張 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05015.js" charset="UTF-8"></script><!-- 項目入力制御処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05019.js" charset="UTF-8"></script><!-- 情報ダイアログ表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05024.js" charset="UTF-8"></script><!-- 数値編集関数群 -->

	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02004.js" charset="UTF-8"></script><!-- 発注マスタ取得(スキャンコード) -->
</head>

<body>
	<form id="Tb090f02" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="tb090p01" PgName="仕入伝票訂正" FormId="tb090f02" FormName="仕入伝票訂正 明細" ></uc:Header>
			
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
					<p class="required">*が付いている項目は必須入力になります。</p>
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
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Denpyo_bango_lbl" runat="server">伝票番号</asp:Label></span></th>
								<!--- 「伝票番号」テキストボックスリードオンリー --->
								<td class="last"><asp:TextBox ID="Denpyo_bango" CssClass="inpReadonlyLeft inpRONum6" runat="server"></asp:TextBox></td>
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Siiresaki_cd_lbl" runat="server">仕入先</asp:Label></span></th>
								<!--- 「仕入先コード」テキストボックスリードオンリー --->
								<!--- 「仕入先略式名称」テキストボックスリードオンリー --->
								<td class="last"><asp:TextBox ID="Siiresaki_cd" CssClass="inpReadonlyLeft inpRONum4" runat="server"></asp:TextBox><asp:TextBox ID="Siiresaki_ryaku_nm" CssClass="inpReadonlyLeft inpROZenkaku10 inpRORightNm" runat="server"></asp:TextBox></td>
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Bumon_cd_lbl" runat="server">部門</asp:Label></span></th>
								<!--- 「部門コード」テキストボックスリードオンリー --->
								<!--- 「部門名」テキストボックスリードオンリー --->
								
								<td class="last"><asp:TextBox ID="Bumon_cd" CssClass="inpReadonlyLeft inpRONum3" runat="server"></asp:TextBox><asp:TextBox ID="Bumon_nm" CssClass="inpReadonlyLeft inpROZenkaku10 inpRORightNm" runat="server"></asp:TextBox></td>
								<th class="last"></th>
								<td class="last"></td>
							</tr>
							<tr>
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Kakuteitan_cd_lbl" runat="server">確定担当者</asp:Label></span></th>
								<!--- 「確定担当者コード」テキストボックスリードオンリー --->
								<!--- 「確定担当者名称」テキストボックスリードオンリー --->
								
								<td class="last"><asp:TextBox ID="Kakuteitan_cd" CssClass="inpReadonlyLeft inpRONum7" runat="server"></asp:TextBox><asp:TextBox ID="Kakuteitan_nm" CssClass="inpReadonlyLeft inpROZenkaku10 inpRORightNm" runat="server"></asp:TextBox></td>
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Nyukayotei_ymd_lbl" runat="server">入荷予定日</asp:Label></span></th>
								<!--- 「入荷予定日」テキストボックスリードオンリー --->
								<td class="last"><asp:TextBox ID="Nyukayotei_ymd" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox></td>
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Siire_kakutei_ymd_lbl" runat="server">仕入確定日</asp:Label></span></th>
								<!--- 「仕入確定日」テキストボックスリードオンリー --->
								<td class="last"><asp:TextBox ID="Siire_kakutei_ymd" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox></td>
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Kakutei_sb_nm_lbl" runat="server">確定種別</asp:Label></span></th>
								<!--- 「確定種別名称」テキストボックスリードオンリー --->
								<td class="last"><asp:TextBox ID="Kakutei_sb_nm" CssClass="inpReadonlyLeft inpROZenkaku5" runat="server"></asp:TextBox></td>
							</tr>
							<tr>
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Biko_kb_lbl" runat="server">備考</asp:Label></span><span class="required">*</span></th>
								<!--- 「備考区分」ドロップダウンリスト --->
								<td class="last">
									<md:MDConditionDDList ID="Biko_kb" ConditionName="biko_kbn" CssClass="slt-biko" runat="server"></md:MDConditionDDList>
									<span class="select-arrow"></span>
								</td>
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Biko1_lbl" runat="server">①</asp:Label><asp:Label ID="Biko1_Req" runat="server" CssClass="required">*</asp:Label></span></th>
								<!--- 「備考1」一行テキストボックス（セパレート日付以外） --->
								<td class="last" colspan="3"><md:MDTextBox ID="Biko1" CssClass="inpBikou" runat="server"></md:MDTextBox></td>
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Biko2_lbl" runat="server">②</asp:Label></span></th>
								<!--- 「備考2」一行テキストボックス（セパレート日付以外） --->
								<td class="last"><md:MDTextBox ID="Biko2" CssClass="inpBikou2" runat="server"></md:MDTextBox></td>
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
						<!--<p><adv:PageInfo ID="M1PageInfo" runat="server"></adv:PageInfo></p>--->
						<!--- ページャーを配置する場合はこの中 --->
		
					<!-- /str-pager-01 --></div>
					<!--一覧-->
					<div class="str-result-01">
					<%-- 明細ヘッダ --%>
						<div class="str-result-hdg-01">
						
						
							<div class="col1 col_2dan">
								<asp:Label ID="M1rowno_lbl" runat="server">No.</asp:Label>
							</div>
							<div class="col2">
								<div><asp:Label ID="M1hinsyu_ryaku_nm_lbl" runat="server">品種</asp:Label></div>
								<div><asp:Label ID="M1burando_nm_lbl" runat="server">ブランド</asp:Label></div>
							</div>
							<div class="col3 col_2dan"><asp:Label ID="M1jisya_hbn_lbl" runat="server">自社品番</asp:Label></div>
							<div class="col4">
								<div><asp:Label ID="M1maker_hbn_lbl" runat="server">メーカー品番</asp:Label></div>
								<div><asp:Label ID="M1syonmk_lbl" runat="server">商品名</asp:Label></div>
							</div>
							<div class="col5">
								<div><asp:Label ID="M1iro_nm_lbl" runat="server">色</asp:Label></div>
								<div><asp:Label ID="M1size_nm_lbl" runat="server">サイズ</asp:Label></div>
							</div>
							<div class="col6 col_2dan"><asp:Label ID="M1scan_cd_lbl" runat="server">スキャンコード</asp:Label></div>
							<div class="col7 col_2dan"><asp:Label ID="M1nohin_su_lbl" runat="server">納品数</asp:Label></div>
							<div class="col8 col_2dan"><asp:Label ID="M1kensu_lbl" runat="server">検数</asp:Label></div>
							<div class="col9 col_2dan"><asp:Label ID="M1teisei_suryo_lbl" runat="server">訂正数</asp:Label></div>
							<div class="col10 col_2dan"><asp:Label ID="M1gen_tnk_lbl" runat="server">原単価</asp:Label></div>
							<div class="col11 col_2dan"><asp:Label ID="M1genkakin_lbl" runat="server">原価金額</asp:Label></div>
							<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
							<div style="display:none">

								<div class="col15">
									<asp:Label ID="M1teisei_suryo_hdn_lbl" runat="server"></asp:Label>
								</div>
								<div class="col16">
									<asp:Label ID="M1genkakin_hdn_lbl" runat="server"></asp:Label>
								</div>
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
								<HeaderTemplate>
								</HeaderTemplate>
								<ItemTemplate>
									<div id="M1Row" class="str-result-item-01" runat="server">
									
										<div class="col1 col_2dan detail_right">
											<!--- 「ｍ１行no」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1rowno" CssClass="inpReadonlyRight inpRONum2" runat="server"></asp:TextBox>
										</div>
										<div class="col2 detail_left">
											<div>
												<!--- 「ｍ１品種略名称」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1hinsyu_ryaku_nm" CssClass="inpReadonlyLeft inpROZenkaku10 tooltip" runat="server"></asp:TextBox>
											</div>
											<div>
												<!--- 「ｍ１ブランド名」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1burando_nm" CssClass="inpReadonlyLeft inpROHankaku15 tooltip" runat="server"></asp:TextBox>
											</div>
										</div>
										<div class="col3 col_2dan detail_center">
											<!--- 「ｍ１自社品番」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1jisya_hbn" CssClass="inpReadonlyLeft inpRONum8" runat="server"></asp:TextBox>
										</div>
										<div class="col4 detail_left">
											<div>
												<!--- 「ｍ１メーカー品番」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1maker_hbn" CssClass="inpReadonlyLeft inpROHankaku30 tooltip" runat="server"></asp:TextBox>
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
											<!--- 「ｍ１スキャンコード」一行テキストボックス（セパレート日付以外） --->
											<md:MDTextBox ID="M1scan_cd" CssClass="inpScan" runat="server"></md:MDTextBox>
										</div>
										<div class="col7 col_2dan detail_right">
											<!--- 「ｍ１納品数」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1nohin_su" CssClass="inpReadonlyRight inpRONumCma7" runat="server"></asp:TextBox>
										</div>
										<div class="col8 col_2dan detail_right">
											<!--- 「ｍ１検数」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1kensu" CssClass="inpReadonlyRight inpRONumCma7" runat="server"></asp:TextBox>
										</div>
										<div class="col9 col_2dan detail_center">
											<!--- 「ｍ１訂正数量」一行テキストボックス（セパレート日付以外） --->
											<md:MDTextBox ID="M1teisei_suryo" CssClass="inpSu-07" runat="server"></md:MDTextBox>
										</div>
										<div class="col10 col_2dan detail_right">
											<!--- 「ｍ１原単価」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1gen_tnk" CssClass="inpReadonlyRight inpRONumCma7" runat="server"></asp:TextBox>
										</div>
										<div class="col11 col_2dan detail_right">
											<!--- 「ｍ１原価金額」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1genkakin" CssClass="inpReadonlyRight inpRONumCma7" runat="server"></asp:TextBox>
										</div>
									
										<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
										<div style="display: none">
											<div class="col15">
												<!--- 「Ｍ１訂正数量(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1teisei_suryo_hdn" runat="server"></asp:hiddenfield>
											</div>
											<div class="col16">
												<!--- 「Ｍ１原価金額(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1genkakin_hdn" runat="server"></asp:hiddenfield>
											</div>
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
							<div class="col8 detail_ftr_title">合計</div>
							<!--- 「合計訂正数量」テキストボックスリードオンリー --->
							<div class="col9 detail_ftr"><span><asp:TextBox ID="Gokei_teisei_suryo" CssClass="inpReadonlyRight inpRONumCma9" runat="server"></asp:TextBox></span></div>
							<div class="col10 detail_left">&nbsp;</div>
							<!--- 「合計原価金額」テキストボックスリードオンリー --->
							<div class="col11 detail_ftr"><span><asp:TextBox ID="Gokei_genkakin" CssClass="inpReadonlyRight inpRONumCma9" runat="server"></asp:TextBox></span></div>
						<!-- /str-result-ftr-01 --></div>
					<!-- /str-result-01 --></div>
					<!------------------------------------------
					  □ページャ下部領域
					-------------------------------------------->
					<span class="adjust-elem-next"></span>
				<!-- /inner --></div>
				<div id="footerBtnArea" class="pad0" runat="server">
					<div id="str-pager-bottom" class="str-pager-01 pad0">
						<p>
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

			<asp:Label ID="Siiresaki_ryaku_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Bumon_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Kakuteitan_nm_lbl" runat="server"></asp:Label>

			<asp:Label ID="Gokei_teisei_suryo_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokei_genkakin_lbl" runat="server"></asp:Label>

			<!--- 「選択モードNO」隠しフィールド --->
			<asp:hiddenfield ID="Stkmodeno" runat="server"></asp:hiddenfield>
		</div>
	
	</form>
</body>
</html>

