<%@ Page language="c#" CodeFile="tm060f01.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Tm060p01.Page.Tm060f01Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">担当者マスタメンテナンス画面</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />
	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="tm060p01" FormId="tm060f01" runat="server" />
	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/tm060f01.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="tm060p01" FormId="tm060f01" runat="server" />
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02001.js" charset="UTF-8"></script><!-- 店舗検索 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02005.js" charset="UTF-8"></script><!-- 担当者マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05003.js" charset="UTF-8"></script><!-- 明細背景色変更処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script><!-- 0埋め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05010.js" charset="UTF-8"></script><!-- カンマ編集処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05011.js" charset="UTF-8"></script><!-- FROM-TOコピー処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
	<!-- 業務共通コントロールのインポート-->
	<%@ Register TagPrefix="uc" TagName="common" Src="~/pjcommon/businessCommon/usercontrol/boCommonControl.ascx" %>
</head>

<body>
	<form id="Tm060f01" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">			
			<uc:Header ID="header" runat="server" PgId="tm060p01" PgName="担当者マスタメンテナンス画面" FormId="tm060f01" FormName="担当者マスタメンテナンス画面" ></uc:Header>
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
					<md:MDTextBox ID="Head_tenpo_cd" CssClass="inpSerch inpHeaderTenpo" runat="server"></md:MDTextBox>
					<input type="button" id="Btnheadtenpocd" name="Btnheadtenpocd" value="" runat="server" class="icon-search"/>
				</span>
				<asp:TextBox ID="Head_tenpo_nm" CssClass="inpReadonlyLeft inpHeaderTenpoNm" runat="server"></asp:TextBox>
			</p>	
			<!-------------------------------------------------------------------
								1.カード部
			--------------------------------------------------------------------->
			<div id="tab1" class="str-tab-cont"></div>
			<!-- search-list -->
			<div class="str-search-01">
				<!------------------------------------------
					□検索条件領域(非表示時)
				-------------------------------------------->
				<div class="inner-01" style="display:none;">
					<p id="list-search"></p>
					<table class="search-table">
						<tr>
							<td class="search-table-tdleft">
								<div class="list-search-condition">
								<!-- /list-search-condition --></div>
							</td>
							<td class="search-table-tdright">
								<div class="list-search-result">
								<p class="txt-02">該当件数<span class="hit-number"><asp:TextBox ID="Searchcnt" CssClass="inpReadonlyRight inpSearchCnt" runat="server"></asp:TextBox></span><span>件</span></p>
								<!-- /list-search-result --></div>
							</td>
						</tr>
					</table>
				<!-- /inner-01 --></div>
				<!------------------------------------------
					□検索条件領域(入力時)
				-------------------------------------------->
				<div class="inner-02">
					<table class="search-table">
						<tr>
							<td class="search-table-tdleft">
								<div class="str-form-02">
									<div class="inner">
										<table>
											<colgroup>
												<col class="w-type-01"/>
												<col class="w-type-02"/>
												<col class="w-type-01"/>
												<col />
											</colgroup>
											<tr>
												<th>
													<span class="tbl-hdg"><asp:Label ID="Tantosya_cd_from_lbl" runat="server">担当者コードＦＲＯＭ</asp:Label></span>
												</th>
												<td colspan ="3">
													<span class="icon-in">
													<!--- 「担当者コードｆｒｏｍ」一行テキストボックス（セパレート日付以外） --->
													<md:MDTextBox ID="Tantosya_cd_from" CssClass="inpSerch inpTanto" runat="server"></md:MDTextBox>
													<!--- 「担当者コードＦＲＯＭボタン」ボタン --->
													<input type="button" id="Btntanto_cd_from" name="Btntanto_cd_from" value="" runat="server" class="icon-search"/></span>
													<!--- 「担当者名ｆｒｏｍ」テキストボックスリードオンリー --->
													<asp:TextBox ID="Hanbaiin_nm_from" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
													<span class="label-fromto">～</span>
													<span class="icon-in">
													<!--- 「担当者コードｔｏ」一行テキストボックス（セパレート日付以外） --->
													<md:MDTextBox ID="Tantosya_cd_to" CssClass="inpSerch inpTanto" runat="server"></md:MDTextBox>
													<!--- 「担当者コードＴＯボタン」ボタン --->
													<input type="button" id="Btntanto_cd_to" name="Btntanto_cd_to" value="" runat="server" class="icon-search"/></span>
													<!--- 「担当者名ｔｏ」テキストボックスリードオンリー --->
													<asp:TextBox ID="Hanbaiin_nm_to" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<th class ="last">
													<span class="tbl-hdg">
														<asp:Label ID="Syokusei_kb_lbl" runat="server">職制区分</asp:Label>
													</span>
												</th>
												<td  class ="last" >
													<!--- 「職制区分」ドロップダウンリスト --->
													<md:MDCodeCondition ID="Syokusei_kb" FormID="Tm060f01" PgID="Tm060p01" CssClass="slt-syokusei" runat="server"></md:MDCodeCondition>
													<span class="select-arrow"></span>
												</td>
												<th class ="last">
													<span class="tbl-hdg">
														<asp:Label ID="Kengen_kb_lbl" runat="server">権限</asp:Label>
													</span>
												</th>
												<td class ="last">
													<!--- 「権限区分」ドロップダウンリスト --->
													<md:MDConditionDDList ID="Kengen_kb" ConditionName="kengen" CssClass="slt-kengen" runat="server"></md:MDConditionDDList>
													<span class="select-arrow"></span>
												</td>
											</tr>
										</table>
									<!-- /inner --></div>
								<!-- /str-form-02 --></div>
							</td>
							<td class="search-table-tdright">
								<div class="str-btn-search">
									<!--- 「検索ボタン」ボタン --->
									<input type="button" id="Btnsearch" value="検索" onserverclick="OnBTNSEARCH_FRM" runat="server" class="btn type-02"/>
								</div>
							</td>
						</tr>
					</table>
	    		<!-- /inner-02 --></div>
	    	<!-- /str-search-01 --></div>
			<!--- アコーディオン --->
			<div class = "trigger-search-01">
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
							<div class="col1">
								<asp:Label ID="M1rowno_lbl" runat="server">No.</asp:Label>
							</div>
							<div class="col2">
								<asp:Label ID="M1tantosya_cd_lbl" runat="server">担当者</asp:Label>
							</div>
							<div class="col3">
								<asp:Label ID="M1syokusei_kb_nm_lbl" runat="server">職制</asp:Label>
							</div>
							<div class="col4">
								<asp:Label ID="M1kengen_kb_lbl" runat="server">権限</asp:Label>
							</div>
							<div class="col5">
								<asp:Label ID="M1passwardsyokika_lbl" runat="server">パスワード初期化</asp:Label>
							</div>
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
											<!--- 「ｍ１担当者コード」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1tantosya_cd" CssClass="inpReadonlyLeft inpTanto" runat="server"></asp:TextBox>
											<!--- 「ｍ１担当者名」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1hanbaiin_nm" CssClass="inpReadonlyLeft inpROZenkaku10 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col3 detail_left">
											<!--- 「ｍ１職制区分名称」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1syokusei_kb_nm" CssClass="inpReadonlyLeft inpROZenkaku5" runat="server"></asp:TextBox>
										</div>
										<div class="col4 detail_center">
											<!--- 「ｍ１権限区分」ドロップダウンリスト --->
											<md:MDConditionDDList ID="M1kengen_kb" ConditionName="kengen" CssClass="slt-kengen" runat="server"></md:MDConditionDDList>
											<span class="select-arrow"></span>
										</div>
										<div class="col5 detail_center">
											<!--- 「ｍ１パスワード初期化」チェックボックス --->
											<adv:AdvancedCheckBox ID="M1passwardsyokika" Text="チェックボックス" CssClass="padtop" runat="server"></adv:AdvancedCheckBox>
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
					<div id="str-pager-bottom" class= "footer str-pager-01 pad0">
						<div class="pager-01">
								&nbsp;
						<!-- /pager-01 --></div>
						<p>
							<!-- ページャ下部にボタンを配置する場合はこの中 -->
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
			<asp:Label ID="Hanbaiin_nm_from_lbl" runat="server"></asp:Label>
			<asp:Label ID="Tantosya_cd_to_lbl" runat="server">担当者コードＴＯ</asp:Label>
			<asp:Label ID="Hanbaiin_nm_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="M1selectorcheckbox_lbl" runat="server"></asp:Label>
			<asp:Label ID="M1entersyoriflg_lbl" runat="server"></asp:Label>
			<asp:Label ID="M1dtlirokbn_lbl" runat="server"></asp:Label>
			<asp:Label ID="M1hanbaiin_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Searchcnt_lbl" runat="server"></asp:Label>
		</div>
	</form>
</body>
</html>

