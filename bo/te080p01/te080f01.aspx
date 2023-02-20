<%@ Page language="c#" CodeFile="te080f01.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Te080p01.Page.Te080f01Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">移動入荷一括確定</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="te080p01" FormId="te080f01" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/te080f01.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="te080p01" FormId="te080f01" runat="server" />

	<!----->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02001.js" charset="UTF-8"></script><!-- 店舗検索 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02006.js" charset="UTF-8"></script><!-- 会社検索 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02022.js" charset="UTF-8"></script><!-- 移動入荷予定(H)トラン取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02026.js" charset="UTF-8"></script><!-- 店舗(全企業)検索 -->

	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05003.js" charset="UTF-8"></script><!-- 明細背景色変更処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script><!-- 0埋め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05014.js" charset="UTF-8"></script><!-- 名称取得拡張 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05015.js" charset="UTF-8"></script><!-- 項目制御処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05019.js" charset="UTF-8"></script><!-- 情報ダイアログ表示処理(拡張版) -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05024.js" charset="UTF-8"></script><!-- 数値編集関数群 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05026.js" charset="UTF-8"></script><!-- SCMコード丸め処理 -->

</head>

<body>
	<form id="Te080f01" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="te080p01" PgName="移動入荷一括確定" FormId="te080f01" FormName="移動入荷一括確定" ></uc:Header>
			
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
						<!--- 「行削除ボタン」ボタン --->
						<li><span><label><input type="button" id="Btnrowdel" value="" onserverclick="OnBTNROWDEL_FRM" runat="server" class="icon-utility-03"/>行削除</label></span></li>
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
		
					<!-- /str-pager-01 --><!---</div>--->
					<!--一覧-->
					<div class="str-result-01">
					<%-- 明細ヘッダ --%>
						<div class="str-result-hdg-01">
							<div class="col1">
								<asp:Label ID="M1rowno_lbl" runat="server">No.</asp:Label>
							</div>
							<div class="col2">
								<asp:Label ID="M1kaisya_cd_lbl" runat="server">会社</asp:Label>
							</div>
							<div class="col3">
								<asp:Label ID="M1syukkaten_cd_lbl" runat="server">出荷店</asp:Label>
							</div>
							<div class="col4">
								<asp:Label ID="M1scmden_cd_lbl" runat="server">SCMコード/伝票番号</asp:Label>
							</div>
							<div class="col5">
								<asp:Label ID="M1scm_cd_lbl" runat="server">SCMコード</asp:Label>
							</div>
							<div class="col6">
								<asp:Label ID="M1denpyo_bango_lbl" runat="server">伝票番号</asp:Label>
							</div>
							<div class="col7">
								<asp:Label ID="M1syukka_ymd_lbl" runat="server">出荷日</asp:Label>
							</div>
							<div class="col8">
								<asp:Label ID="M1yotei_su_lbl" runat="server">予定数量</asp:Label>
							</div>
							<div class="col9">
								<asp:Label ID="M1kyakucyu_lbl" runat="server">客注</asp:Label>
							</div>
							<div class="col10">
								<asp:Label ID="M1negaki_lbl" runat="server">値書</asp:Label>
							</div>
							<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
							<div style="display:none">
								<div class="col11">
									<asp:Label ID="M1btnkaisha_cd_lbl" runat="server"></asp:Label>
								</div>
								<div class="col12">
									<asp:Label ID="M1kaisya_nm_lbl" runat="server"></asp:Label>
								</div>
								<div class="col13">
									<asp:Label ID="M1btnsyukkatencd_lbl" runat="server"></asp:Label>
								</div>
								<div class="col14">
									<asp:Label ID="M1syukkaten_nm_lbl" runat="server"></asp:Label>
								</div>
								<div class="col15">
									<asp:Label ID="M1tenpolc_kbn_hdn_lbl" runat="server"></asp:Label>
								</div>
								<div class="col16">
									<asp:Label ID="M1selectorcheckbox_lbl" runat="server"></asp:Label>
								</div>
								<div class="col17">
									<asp:Label ID="M1entersyoriflg_lbl" runat="server"></asp:Label>
								</div>
								<div class="col18">
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
										<div class="col1 detail_right">
											<!--- 「ｍ１行no」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1rowno" CssClass="inpReadonlyRight inpRONum3" runat="server"></asp:TextBox>
										</div>
										<div class="col2 detail_left">
											<!--- 「ｍ１会社コード」一行テキストボックス（セパレート日付以外） --->
											<!--- 「Ｍ１会社コードボタン」ボタン --->
											<!--- 「ｍ１会社名称」テキストボックスリードオンリー --->
											<span class="icon-in"><md:MDTextBox ID="M1kaisya_cd" CssClass="inpSerchDtl inpComp" runat="server"></md:MDTextBox><input type="button" id="M1btnkaisha_cd" name="M1btnkaisha_cd" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="M1kaisya_nm" CssClass="inpReadonlyLeft inpROZenkaku10 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col3 detail_left">
											<!--- 「ｍ１出荷店コード」一行テキストボックス（セパレート日付以外） --->
											<!--- 「Ｍ１出荷店舗コードボタン」ボタン --->
											<!--- 「ｍ１出荷店名称」テキストボックスリードオンリー --->
											<span class="icon-in"><md:MDTextBox ID="M1syukkaten_cd" CssClass="inpSerchDtl inpTenpo" runat="server"></md:MDTextBox><input type="button" id="M1btnsyukkatencd" name="M1btnsyukkatencd" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="M1syukkaten_nm" CssClass="inpReadonlyLeft inpROZenkaku10 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col4 detail_center">
											<!--- 「ｍ１scm/伝票コード」一行テキストボックス（セパレート日付以外） --->
											<md:MDTextBox ID="M1scmden_cd" CssClass="inpDetail inpSCM" runat="server"></md:MDTextBox>
										</div>
										<div class="col5 detail_center">
											<!--- 「ｍ１scmコード」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1scm_cd" CssClass="inpReadonlyCenter" runat="server"></asp:TextBox>
										</div>
										<div class="col6 detail_center">
											<!--- 「ｍ１伝票番号」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1denpyo_bango" CssClass="inpReadonlyCenter inpRONum6" runat="server"></asp:TextBox>
										</div>
										<div class="col7 detail_center">
											<!--- 「ｍ１出荷日」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1syukka_ymd" CssClass="inpReadonlyCenter inpRODate" runat="server"></asp:TextBox>
										</div>
										<div class="col8 detail_right">
											<!--- 「ｍ１予定数量」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1yotei_su" CssClass="inpReadonlyRight inpRONumCma8" runat="server"></asp:TextBox>
										</div>
										<div class="col9  detail_center">
											<!--- 「ｍ１客注」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1kyakucyu" CssClass="inpReadonlyCenter inpROZenkaku1" runat="server"></asp:TextBox>
										</div>
										<div class="col10  detail_center">
											<!--- 「ｍ１値書」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1negaki" CssClass="inpReadonlyCenter inpROZenkaku1" runat="server"></asp:TextBox>
										</div>
										<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
										<div style="display:none">
											<div class="col15">
												<!--- 「Ｍ１店舗ＬＣ区分(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1tenpolc_kbn_hdn" runat="server"></asp:hiddenfield>
											</div>
											<div class="col16">
												<!--- 「ｍ１選択フラグ(隠し)」チェックボックス --->
												<adv:AdvancedCheckBox ID="M1selectorcheckbox" Text="" CssClass="" runat="server"></adv:AdvancedCheckBox>
											</div>
											<div class="col17">
												<!--- 「Ｍ１確定処理フラグ(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1entersyoriflg" runat="server"></asp:hiddenfield>
											</div>
											<div class="col18">
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
							<div class="col4 detail_ftr_title">合計</div>
							<!--- 「SCM合計」テキストボックスリードオンリー --->
							<div class="col5 detail_ftr"><span><asp:TextBox ID="Scm_gokei" CssClass="inpReadonlyRight inpRONumCma4" runat="server"></asp:TextBox></span></div>
							<!--- 「伝票合計」テキストボックスリードオンリー --->
							<div class="col6 detail_ftr"><span><asp:TextBox ID="Denpyo_gokei" CssClass="inpReadonlyRight inpRONumCma4" runat="server"></asp:TextBox></span></div>
							<div class="col7 detail_left">&nbsp;</div>
							<div class="col8 detail_left">&nbsp;</div>
							<div class="col9 detail_left">&nbsp;</div>
							<div class="col10 detail_left">&nbsp;</div>
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
			<asp:Label ID="Head_tenpo_cd_lbl" runat="server">店舗</asp:Label>
			<asp:Label ID="Head_tenpo_cd_Req" runat="server" CssClass="required">*</asp:Label>
			<asp:Label ID="Head_tenpo_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Scm_gokei_lbl" runat="server"></asp:Label>
			<asp:Label ID="Denpyo_gokei_lbl" runat="server"></asp:Label>

			<asp:Label ID="Selectrowno_lbl" runat="server"></asp:Label>
			<!--- 「選択行行no」テキストボックスリードオンリー --->
			<asp:TextBox ID="Selectrowno" CssClass="inpReadonlyRight" runat="server"></asp:TextBox>
			<!--- 「ボタン行追加」ボタン --->
			<input type="button" id="Btnrowins" value="ボタン行追加（ダミー）" onserverclick="OnBTNROWINS_FRM" runat="server" class="btn type-01"/>
			<!--- 「ボタンクリア」ボタン --->
			<input type="button" id="Btnclear" value="ボタンクリア（ダミー）" onserverclick="OnBTNCLEAR_FRM" runat="server" class="btn type-01"/>

		</div>
	</form>
</body>
</html>

