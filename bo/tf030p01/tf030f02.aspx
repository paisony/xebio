<%@ Page language="c#" CodeFile="tf030f02.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Tf030p01.Page.Tf030f02Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">経費未払登録</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="tf030p01" FormId="tf030f02" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/tf030f02.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="tf030p01" FormId="tf030f02" runat="server" />

	<!-- Js業務部品のインポート --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05003.js" charset="UTF-8"></script><!-- 明細背景色変更処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script><!-- 0埋め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05010.js" charset="UTF-8"></script><!-- カンマ編集処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02001.js" charset="UTF-8"></script><!-- 店舗検索 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02002.js" charset="UTF-8"></script><!-- 仕入先マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02005.js" charset="UTF-8"></script><!-- 担当者マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02023.js" charset="UTF-8"></script><!-- 摘要マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05024.js" charset="UTF-8"></script><!-- 数値編集関数群 -->

</head>

<body>
	<form id="Tf030f02" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="tf030p01" PgName="経費未払登録" FormId="tf030f02" FormName="経費未払登録 明細" ></uc:Header>
			
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
								<th class=""><span class="tbl-hdg"><asp:Label ID="Add_ymd_lbl" runat="server">登録日</asp:Label></span></th>
								<!--- 「登録日」テキストボックスリードオンリー --->
								<td class=""><asp:TextBox ID="Add_ymd" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox></td>
								<th class=""><span class="tbl-hdg"><asp:Label ID="Tenpo_cd_lbl" runat="server">店舗</asp:Label><asp:Label ID="Tenpo_cd_Req" runat="server" CssClass="required">*</asp:Label></span></th>
								<!--- 「店舗コード」一行テキストボックス（セパレート日付以外） --->
								<!--- 「店舗コードボタン」ボタン --->
								<!--- 「店舗名」テキストボックスリードオンリー --->
								<td class=""><span class="icon-in"><md:MDTextBox ID="Tenpo_cd" CssClass="inpSerch inpTenpo" runat="server"></md:MDTextBox><input type="button" id="Btntenpocd" name="Btntenpocd" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="Tenpo_nm" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox></td>
								<th class=""><span class="tbl-hdg"><asp:Label ID="Kenpinsya_cd_lbl" runat="server">検品者</asp:Label><asp:Label ID="Kenpinsya_cd_Req" runat="server" CssClass="required">*</asp:Label></span></th>
								<!--- 「検品者コード」一行テキストボックス（セパレート日付以外） --->
								<!--- 「担当者コードボタン」ボタン --->
								<!--- 「検品者名称」テキストボックスリードオンリー --->
								<td class=""><span class="icon-in"><md:MDTextBox ID="Kenpinsya_cd" CssClass="inpSerch inpTanto" runat="server"></md:MDTextBox><input type="button" id="Btntanto_cd" name="Btntanto_cd" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="Kenpinsya_nm" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox></td>
								<th class=""><span class="tbl-hdg"><asp:Label ID="Siiresaki_cd_lbl" runat="server">取引先</asp:Label><asp:Label ID="Siiresaki_cd_Req" runat="server" CssClass="required">*</asp:Label></span></th>
								<!--- 「仕入先コード」一行テキストボックス（セパレート日付以外） --->
								<!--- 「仕入先コードボタン」ボタン --->
								<!--- 「仕入先略式名称」テキストボックスリードオンリー --->
								<td class=""><span class="icon-in"><md:MDTextBox ID="Siiresaki_cd" CssClass="inpSerch inpShiire" runat="server"></md:MDTextBox><input type="button" id="Btnsiiresaki_cd" name="Btnsiiresaki_cd" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="Siiresaki_ryaku_nm" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox></td>
							</tr>
							<tr>
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Denpyo_bango_lbl" runat="server">伝票番号</asp:Label><asp:Label ID="Denpyo_bango_Req" runat="server" CssClass="required">*</asp:Label></span></th>
								<!--- 「伝票番号」一行テキストボックス（セパレート日付以外） --->
								<td class="last"><md:MDTextBox ID="Denpyo_bango" CssClass="inpDenpyo" runat="server"></md:MDTextBox></td>
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Motodenpyo_bango_lbl" runat="server">元伝票番号</asp:Label></span></th>
								<!--- 「元伝票番号」一行テキストボックス（セパレート日付以外） --->
								<td class="last"><md:MDTextBox ID="Motodenpyo_bango" CssClass="inpDenpyo" runat="server"></md:MDTextBox></td>
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Nyuryokutan_cd_lbl" runat="server">入力担当者</asp:Label></span></th>
								<!--- 「入力担当者コード」テキストボックスリードオンリー --->
								<!--- 「入力担当者名称」テキストボックスリードオンリー --->
								<td class="last"><asp:TextBox ID="Nyuryokutan_cd" CssClass="inpReadonlyLeft inpRONum7" style="padding-left:9px;" runat="server"></asp:TextBox><asp:TextBox ID="Nyuryokutan_nm" CssClass="inpReadonlyLeft inpROZenkaku10 inpRORightNm" runat="server"></asp:TextBox></td>
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Nohin_ymd_lbl" runat="server">納品日</asp:Label><asp:Label ID="Nohin_ymd_Req" runat="server" CssClass="required">*</asp:Label></span></th>
								<!--- 「納品日」一行テキストボックス（セパレート日付以外） --->
								<td class="last"><span class="icon-in"><md:MDTextBox ID="Nohin_ymd" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span></td>
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
						<!--- 「ボタン行追加」ボタン --->
						<li><span id="Spanrowins" runat="server"><label><input type="button" id="Btnrowins" value="行追加" onserverclick="OnBTNROWINS_MADD" runat="server" class="icon-utility-06"/>行追加</label></span></li>
						<!--- 「ボタン行削除」ボタン --->
						<li><span><label><input type="button" id="Btnrowdel" value="行削除" onserverclick="OnBTNROWDEL_FRM" runat="server" class="icon-utility-03"/>行削除</label></span></li>
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
							<div class="col1">
								<asp:Label ID="M1rowno_lbl" runat="server">No.</asp:Label>
							</div>
							<div class="col2">
								<asp:Label ID="M1tekiyo_cd_lbl" runat="server">摘要</asp:Label>
							</div>
							<div class="col3">
								<asp:Label ID="M1suryo_lbl" runat="server">数量</asp:Label>
							</div>
							<div class="col4">
								<asp:Label ID="M1tnk_lbl" runat="server">単価</asp:Label>
							</div>
							<div class="col5">
								<asp:Label ID="M1kingaku_lbl" runat="server">金額</asp:Label>
							</div>

							<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
							<div style="display:none">
								<asp:Label ID="M1btntekiyo_cd_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1tekiyo_nm_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1suryo_hdn_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1kingaku_hdn_lbl" runat="server"></asp:Label>
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
										<div class="col1 detail_right">
											<!--- 「ｍ１行no」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1rowno" CssClass="inpReadonlyRight inpRONum3" runat="server"></asp:TextBox>
										</div>
										<div class="col2 detail_left">
											<!--- 「ｍ１摘要コード」一行テキストボックス（セパレート日付以外） --->
											<!--- 「Ｍ１摘要コードボタン」ボタン --->
											<!--- 「ｍ１摘要名」テキストボックスリードオンリー --->
											<span class="icon-in"><md:MDTextBox ID="M1tekiyo_cd" CssClass="inpSerchDtl inpTekiyo" runat="server"></md:MDTextBox><input type="button" id="M1btntekiyo_cd" name="M1btntekiyo_cd" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="M1tekiyo_nm" CssClass="inpReadonlyLeft inpROZenkaku20 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col3 detail_right">
											<!--- 「ｍ１数量」一行テキストボックス（セパレート日付以外） --->
											<md:MDTextBox ID="M1suryo" CssClass="inpSu-05" runat="server"></md:MDTextBox>
										</div>
										<div class="col4 detail_right">
											<!--- 「ｍ１単価」一行テキストボックス（セパレート日付以外） --->
											<md:MDTextBox ID="M1tnk" CssClass="inpSu-10" runat="server"></md:MDTextBox>
										</div>
										<div class="col5 detail_right">
											<!--- 「ｍ１金額」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1kingaku" CssClass="inpReadonlyRight inpRONumCmaMinus15" runat="server"></asp:TextBox>
										</div>

										<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
										<div style="display: none">
											<!--- 「Ｍ１数量(隠し)」隠しフィールド --->
											<asp:hiddenfield ID="M1suryo_hdn" runat="server"></asp:hiddenfield>
											<!--- 「Ｍ１金額(隠し)」隠しフィールド --->
											<asp:hiddenfield ID="M1kingaku_hdn" runat="server"></asp:hiddenfield>
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
							<div class="col2 detail_ftr_title">合計</div>
							<!--- 「合計数量」テキストボックスリードオンリー --->
							<div class="col3 detail_ftr"><span><asp:TextBox ID="Gokei_suryo" CssClass="inpReadonlyRight inpRONumCmaMinus7" runat="server"></asp:TextBox></span></div>
							<div class="col4 detail_left">&nbsp;</div>
							<!--- 「原価金額合計」テキストボックスリードオンリー --->
							<div class="col5 detail_ftr"><span><asp:TextBox ID="Gokei_kin" CssClass="inpReadonlyRight inpRONumCmaMinus15" runat="server"></asp:TextBox></span></div>
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
			<asp:Label ID="Tenpo_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Kenpinsya_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Siiresaki_ryaku_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Nyuryokutan_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokei_suryo_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokei_kin_lbl" runat="server"></asp:Label>
			<!--- 「選択モードNO」隠しフィールド --->
			<asp:hiddenfield ID="Stkmodeno" runat="server"></asp:hiddenfield>
		</div>
	
	</form>
</body>
</html>

