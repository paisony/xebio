<%@ Page language="c#" CodeFile="tb040f01.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Tb040p01.Page.Tb040f01Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">仕入一括確定</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="tb040p01" FormId="tb040f01" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/tb040f01.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="tb040p01" FormId="tb040f01" runat="server" />

	<!----->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02001.js" charset="UTF-8"></script><!-- 店舗検索 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02002.js" charset="UTF-8"></script><!-- 仕入先マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02017.js" charset="UTF-8"></script><!-- 仕入入荷予定(H)トラン取得 -->

	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05003.js" charset="UTF-8"></script><!-- 明細背景色変更処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script><!-- 0埋め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05014.js" charset="UTF-8"></script><!-- 名称取得拡張 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05017.js" charset="UTF-8"></script><!-- 伝票バーコード丸め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05019.js" charset="UTF-8"></script><!-- 情報ダイアログ表示処理(拡張版) -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05024.js" charset="UTF-8"></script><!-- 数値編集関数群 -->

</head>

<body>
	<form id="Tb040f01" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="tb040p01" PgName="仕入一括確定" FormId="tb040f01" FormName="仕入一括確定" ></uc:Header>
			
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
					<!--- <div id="str-pager-top" class="str-pager-01"> --->
		
						<!--- 件数表示部 --->
						<!--<p><adv:PageInfo ID="M1PageInfo" runat="server"></adv:PageInfo></p>-->
						<!--- ページャーを配置する場合はこの中 --->
		
					<!-- /str-pager-01 --><!--- </div> --->
					<!--一覧-->
					<div class="str-result-01">
					<%-- 明細ヘッダ --%>
						<div class="str-result-hdg-01">
							<div class="col1">
								<asp:Label ID="M1rowno_lbl" runat="server">No.</asp:Label>
							</div>
							<div class="col2">
								<asp:Label ID="M1siiresaki_cd_lbl" runat="server">仕入先</asp:Label>
							</div>
							<div class="col3">
								<asp:Label ID="M1denpyo_barcode_lbl" runat="server">伝票番号</asp:Label>
							</div>
							<div class="col4">
								<asp:Label ID="M1bumon_cd_lbl" runat="server">部門</asp:Label>
							</div>
							<div class="col5">
								<asp:Label ID="M1nyukayotei_ymd_lbl" runat="server">入荷予定日</asp:Label>
							</div>
							<div class="col6">
								<asp:Label ID="M1nohin_su_lbl" runat="server">納品数</asp:Label>
							</div>
							<div class="col7">
								<asp:Label ID="M1genka_kin_lbl" runat="server">原価金額</asp:Label>
							</div>
							<div class="col8">
								<asp:Label ID="M1kyakucyu_lbl" runat="server">客注</asp:Label>
							</div>
							<div class="col9">
								<asp:Label ID="M1negaki_lbl" runat="server">値書</asp:Label>
							</div>
							<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
							<div style="display:none">
								<div class="col10">
									<asp:Label ID="M1btnsiiresaki_cd_lbl" runat="server"></asp:Label>
								</div>
								<div class="col11">
									<asp:Label ID="M1siiresaki_ryaku_nm_lbl" runat="server"></asp:Label>
								</div>
								<div class="col12">
									<asp:Label ID="M1bumonkana_nm_lbl" runat="server"></asp:Label>
								</div>
								<div class="col13">
									<asp:Label ID="M1selectorcheckbox_lbl" runat="server"></asp:Label>
								</div>
								<div class="col14">
									<asp:Label ID="M1entersyoriflg_lbl" runat="server"></asp:Label>
								</div>
								<div class="col15">
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
											<!--- 「m１no」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1rowno" CssClass="inpReadonlyRight inpRONum3" runat="server"></asp:TextBox>
										</div>
										<div class="col2 detail_left">
											<!--- 「m１仕入先コード」一行テキストボックス（セパレート日付以外） --->
											<!--- 「Ｍ１仕入先コードボタン」ボタン --->
											<!--- 「m１仕入先名称」テキストボックスリードオンリー --->
											<span class="icon-in"><md:MDTextBox ID="M1siiresaki_cd" CssClass="inpSerchDtl inpShiire" runat="server"></md:MDTextBox><input type="button" id="M1btnsiiresaki_cd" name="M1btnsiiresaki_cd" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="M1siiresaki_ryaku_nm" CssClass="inpReadonlyLeft inpROZenkaku15 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col3 detail_center">
											<!--- 「ｍ１伝票バーコード」一行テキストボックス（セパレート日付以外） --->
											<md:MDTextBox ID="M1denpyo_barcode" CssClass="inpDenBarcode" runat="server"></md:MDTextBox>
										</div>
										<div class="col4 detail_left">
											<!--- 「m１部門コード」テキストボックスリードオンリー --->
											<!--- 「m１部門カナ名」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1bumon_cd" CssClass="inpReadonlyRight inpRONum3" runat="server"></asp:TextBox><asp:TextBox ID="M1bumonkana_nm" CssClass="inpReadonlyLeft inpRORightNm inpROHankaku10 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col5 detail_center">
											<!--- 「m１入荷予定日」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1nyukayotei_ymd" CssClass="inpReadonlyCenter inpRODate" runat="server"></asp:TextBox>
										</div>
										<div class="col6 detail_right">
											<!--- 「ｍ１納品数」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1nohin_su" CssClass="inpReadonlyRight inpRONumCma9" runat="server"></asp:TextBox>
										</div>
										<div class="col7 detail_right">
											<!--- 「ｍ１原価金額」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1genka_kin" CssClass="inpReadonlyRight inpRONumCma9" runat="server"></asp:TextBox>
										</div>
										<div class="col8 detail_center">
											<!--- 「ｍ１客注」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1kyakucyu" CssClass="inpReadonlyCenter inpROZenkaku1" runat="server"></asp:TextBox>
										</div>
										<div class="col9 detail_center">
											<!--- 「ｍ１値書」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1negaki" CssClass="inpReadonlyCenter inpROZenkaku1" runat="server"></asp:TextBox>
										</div>

										<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
										<div style="display:none">
											<div class="col13">
												<!--- 「ｍ１選択フラグ(隠し)」チェックボックス --->
												<adv:AdvancedCheckBox ID="M1selectorcheckbox" Text="" CssClass="" runat="server"></adv:AdvancedCheckBox>
											</div>
											<div class="col14">
												<!--- 「Ｍ１確定処理フラグ(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1entersyoriflg" runat="server"></asp:hiddenfield>
											</div>
											<div class="col15">
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
					<div id="str-pager-bottom" class="footer str-pager-01 pad0">
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

			<!--- 「ボタンクリア」ボタン --->
			<input type="button" id="Btnclear" value="ボタンクリア（ダミー）" onserverclick="OnBTNCLEAR_FRM" runat="server" class="btn type-01"/>

		</div>
	</form>
</body>
</html>