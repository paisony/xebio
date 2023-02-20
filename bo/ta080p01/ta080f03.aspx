<%@ Page language="c#" CodeFile="ta080f03.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Ta080p01.Page.Ta080f03Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">補充・仕入稟議検索</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="ta080p01" FormId="ta080f03" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/ta080f03.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="ta080p01" FormId="ta080f03" runat="server" />
	<!-- Js業務部品のインポート --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02004.js" charset="UTF-8"></script><!-- スキャンコードチェック処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02003.js" charset="UTF-8"></script><!-- 発注マスタ取得(自社品番) -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02010.js" charset="UTF-8"></script><!-- 部門マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02012.js" charset="UTF-8"></script><!-- 品種マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02005.js" charset="UTF-8"></script><!-- 担当者マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05001.js" charset="UTF-8"></script><!-- 自社品番丸め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05002.js" charset="UTF-8"></script><!-- スキャンコード丸め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05003.js" charset="UTF-8"></script><!-- 明細背景色変更処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script><!-- 0埋め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05010.js" charset="UTF-8"></script><!-- カンマ編集処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05011.js" charset="UTF-8"></script><!-- FROM-TOコピー処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05014.js" charset="UTF-8"></script><!-- 名称取得拡張 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05015.js" charset="UTF-8"></script><!-- 項目制御処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05019.js" charset="UTF-8"></script><!-- 情報ダイアログ表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05022.js" charset="UTF-8"></script><!-- 文字列編集汎用関数群 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05023.js" charset="UTF-8"></script><!-- 日付編集関数群 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05024.js" charset="UTF-8"></script><!-- 数値編集関数群 -->

	<!-- 業務共通コントロールのインポート-->
	<%@ Register TagPrefix="uc" TagName="common" Src="~/pjcommon/businessCommon/usercontrol/boCommonControl.ascx" %>
</head>

<body>
	<form id="Ta080f03" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="ta080p01" PgName="補充・仕入稟議検索" FormId="ta080f03" FormName="補充・仕入稟議検索 明細" ></uc:Header>

			<!------------------------------------------	
				□業務共通コントロール
			------------------------------------------->	
			<uc:common ID="bocommon" runat="server"></uc:common>

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
			<!------------------------------------------
				□モードタブ
			-------------------------------------------->
			<div class="str-tab-menu clearfix">
				<ul class="tab-list">
					<li>
						<!--- 「モード予算情報ボタン」リンク --->
						<a id="Btnmodeyosanjoho" href="#tabYosan" class="" runat="server">予算情報</a>
					</li>
					<li>
						<!--- 「モード絞込みボタン」リンク --->
						<a id="Btnmodesiborikomi" href="#tabShibori" class="" runat="server">絞込み</a>
					</li>
				</ul>
			</div>
			<!--- 「モード予算情報ボタン」 --->
			<dIv id="tabYosan" class="str-tab-cont">
				<!-- search-list -->
				<div class="str-search-02">
					<!------------------------------------------
						□検索条件領域(入力時)
					-------------------------------------------->
					<div class="inner-01">
						<table >
							<colgroup>
								<col class="w-type-01"/>
								<col class="w-type-02"/>
								<col class="w-type-01"/>
								<col class="w-type-03"/>
								<col class="w-type-01"/>
								<col class="w-type-04"/>
								<col class="w-type-01"/>
								<col class="w-type-05"/>
								<col class="w-type-01"/>
								<col />
							</colgroup>
							<tr>
								<!--- 「年月度」テキストボックスリードオンリー --->
								<th>
									<span class="tbl-hdg"><asp:Label ID="Yosan_ymd_lbl" runat="server">年月度</asp:Label></span>
								</th>
								<td>
									<asp:TextBox ID="Yosan_ymd" CssClass="inpReadonlyLeft inpRODateYM" runat="server"></asp:TextBox>
								</td>
								<!--- 「仕入枠グループコード」テキストボックスリードオンリー --->
								<!--- 「仕入枠グループ名」テキストボックスリードオンリー --->
								<th>
									<span class="tbl-hdg"><asp:Label ID="Yosan_cd_lbl" runat="server">仕入枠ｸﾞﾙｰﾌﾟ</asp:Label></span>
								</th>
								<td>
									<asp:TextBox ID="Yosan_cd" CssClass="inpReadonlyLeft inpROHankaku6" runat="server"></asp:TextBox><asp:TextBox ID="Yosan_nm" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
								</td>
								<!--- 「予算金額」テキストボックスリードオンリー --->
								<th>
									<span class="tbl-hdg"><asp:Label ID="Yosan_kin_lbl" runat="server">予算金額</asp:Label></span>
								</th>
								<td>
									<asp:TextBox ID="Yosan_kin" CssClass="inpReadonlyLeft inpRONumCma8" runat="server"></asp:TextBox>
								</td>
								<!--- 「未申請数」テキストボックスリードオンリー --->
								<th>
									<span class="tbl-hdg"><asp:Label ID="Misinsei_su_lbl" runat="server">未申請数</asp:Label></span>
								</th>
								<td>
									<asp:TextBox ID="Misinsei_su" CssClass="inpReadonlyLeft inpRONumCma8" runat="server"></asp:TextBox>
								</td>
								<!--- 「未申請金額」テキストボックスリードオンリー --->
								<th>
									<span class="tbl-hdg"><asp:Label ID="Misinsei_kin_lbl" runat="server">未申請金額</asp:Label></span>
								</th>
								<td>
									<asp:TextBox ID="Misinsei_kin" CssClass="inpReadonlyLeft inpRONumCma8" runat="server"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<!--- 「申請数」テキストボックスリードオンリー --->
								<th>
									<span class="tbl-hdg"><asp:Label ID="Apply_su_lbl" runat="server">申請数</asp:Label></span>
								</th>
								<td>
									<asp:TextBox ID="Apply_su" CssClass="inpReadonlyLeft inpRONumCma8" runat="server"></asp:TextBox>
								</td>
								<!--- 「申請金額」テキストボックスリードオンリー --->
								<th>
									<span class="tbl-hdg"><asp:Label ID="Apply_kin_lbl" runat="server">申請金額</asp:Label></span>
								</th>
								<td>
									<asp:TextBox ID="Apply_kin" CssClass="inpReadonlyLeft inpRONumCma8" runat="server"></asp:TextBox>
								</td>
								<!--- 「実績数」テキストボックスリードオンリー --->
								<th>
									<span class="tbl-hdg"><asp:Label ID="Jisseki_su_lbl" runat="server">実績数</asp:Label></span>
								</th>
								<td>
									<asp:TextBox ID="Jisseki_su" CssClass="inpReadonlyLeft inpRONumCma8" runat="server"></asp:TextBox>
								</td>
								<!--- 「実績金額」テキストボックスリードオンリー --->
								<th>
									<span class="tbl-hdg"><asp:Label ID="Jisseki_kin_lbl" runat="server">実績金額</asp:Label></span>
								</th>
								<td>
									<asp:TextBox ID="Jisseki_kin" CssClass="inpReadonlyLeft inpRONumCma8" runat="server"></asp:TextBox>
								</td>
								<!--- 「残金額」テキストボックスリードオンリー --->
								<th>
									<span class="tbl-hdg"><asp:Label ID="Zan_kin_lbl" runat="server">残金額</asp:Label></span>
								</th>
								<td>
									<asp:TextBox ID="Zan_kin" CssClass="inpReadonlyLeft inpRONumCma8" runat="server"></asp:TextBox>
								</td>
							</tr>		
						</table>
					<!-- /inner-01 --></dIv>
				<!-- /str-search-02 --></div>
			<!--- 「モード予算情報ボタン」 ---></div>
			<!--- 「モード絞込みボタン」 --->
			<div id="tabShibori" class="str-tab-cont">
				<!-- search-list -->
				<div class="str-search-01">
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
													<col class="w-type-01-2"/>
													<col class="w-type-02-2"/>
													<col class="w-type-01-2-2"/>
													<col class="w-type-03-2"/>
													<col class="w-type-01-2"/>
													<col class="w-type-04-2"/>
													<col class="w-type-01-2"/>
													<col />
												</colgroup>
												<tr>
													<!--- 「年月度1」テキストボックスリードオンリー --->
													<th>
														<span class="tbl-hdg"><asp:Label ID="Yosan_ymd1_lbl" runat="server">年月度</asp:Label></span>
													</th>
													<td>
														<asp:TextBox ID="Yosan_ymd1" CssClass="inpReadonlyLeft inpRODateYM" runat="server"></asp:TextBox>
													</td>
													<!--- 「仕入枠グループコード1」テキストボックスリードオンリー --->
													<!--- 「仕入枠グループ名1」テキストボックスリードオンリー --->
													<th>
														<span class="tbl-hdg"><asp:Label ID="Yosan_cd1_lbl" runat="server">仕入枠ｸﾞﾙｰﾌﾟ</asp:Label></span>
													</th>
													<td  colspan="5">
														<asp:TextBox ID="Yosan_cd1" CssClass="inpReadonlyLeft inpROHankaku6" runat="server"></asp:TextBox><asp:TextBox ID="Yosan_nm1" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
													</td>
												</tr>
												<tr>
													<!--- 「部門コードｆｒｏｍ」一行テキストボックス（セパレート日付以外） --->
													<!--- 「部門コードＦＲＯＭボタン」ボタン --->
													<!--- 「部門名ｆｒｏｍ」テキストボックスリードオンリー --->
													<!--- 「部門コードｔｏ」一行テキストボックス（セパレート日付以外） --->
													<!--- 「部門コードＴＯボタン」ボタン --->
													<!--- 「部門名ｔｏ」テキストボックスリードオンリー --->
													<th>
														<span class="tbl-hdg"><asp:Label ID="Bumon_cd_from_lbl" runat="server">部門</asp:Label></span>
													</th>
													<td colspan="4">
														<span class="icon-in"><md:MDTextBox ID="Bumon_cd_from" CssClass="inpSerch inpBumon" runat="server"></md:MDTextBox><input type="button" id="Btnbumon_cd_from" name="Btnbumon_cd_from" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="Bumon_nm_from" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
														<span class="label-fromto">～</span>
														<span class="icon-in"><md:MDTextBox ID="Bumon_cd_to" CssClass="inpSerch inpBumon" runat="server"></md:MDTextBox><input type="button" id="Btnbumon_cdto" name="Btnbumon_cdto" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="Bumon_nm_to" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
													</td>
													<!--- 「品種-all」チェックボックス --->
													<!--- 「品種-1」チェックボックス --->
													<!--- 「品種-2」チェックボックス --->
													<!--- 「品種-3」チェックボックス --->
													<!--- 「品種-4」チェックボックス --->
													<!--- 「品種-5」チェックボックス --->
													<!--- 「品種-6」チェックボックス --->
													<!--- 「品種-7」チェックボックス --->
													<!--- 「品種-8」チェックボックス --->
													<!--- 「品種-9」チェックボックス --->
													<th>
														<span class="tbl-hdg"><asp:Label ID="Hinsyu_cd_all_lbl" runat="server">品種</asp:Label></span>
														<adv:AdvancedCheckBox ID="Hinsyu_cd_all" Text="All" CssClass="" runat="server"></adv:AdvancedCheckBox>
													</th>
													<td colspan="2">
														<adv:AdvancedCheckBox ID="Hinsyu_cd1" Text="1" CssClass="" runat="server"></adv:AdvancedCheckBox>
														<adv:AdvancedCheckBox ID="Hinsyu_cd2" Text="2" CssClass="" runat="server"></adv:AdvancedCheckBox>
														<adv:AdvancedCheckBox ID="Hinsyu_cd3" Text="3" CssClass="" runat="server"></adv:AdvancedCheckBox>
														<adv:AdvancedCheckBox ID="Hinsyu_cd4" Text="4" CssClass="" runat="server"></adv:AdvancedCheckBox>
														<adv:AdvancedCheckBox ID="Hinsyu_cd5" Text="5" CssClass="" runat="server"></adv:AdvancedCheckBox>
														<adv:AdvancedCheckBox ID="Hinsyu_cd6" Text="6" CssClass="" runat="server"></adv:AdvancedCheckBox>
														<adv:AdvancedCheckBox ID="Hinsyu_cd7" Text="7" CssClass="" runat="server"></adv:AdvancedCheckBox>
														<adv:AdvancedCheckBox ID="Hinsyu_cd8" Text="8" CssClass="" runat="server"></adv:AdvancedCheckBox>
														<adv:AdvancedCheckBox ID="Hinsyu_cd9" Text="9" CssClass="" runat="server"></adv:AdvancedCheckBox>
													</td>
												</tr>
												<tr>
													<!--- 「ブランドコード」一行テキストボックス（セパレート日付以外） --->
													<!--- 「ブランドコードボタン」ボタン --->
													<!--- 「ブランド名」テキストボックスリードオンリー --->
													<th>
														<span class="tbl-hdg"><asp:Label ID="Burando_cd_lbl" runat="server">ブランド</asp:Label></span>
													</th>
													<td colspan="3">
														<span class="icon-in"><md:MDTextBox ID="Burando_cd" CssClass="inpSerch inpBrand" runat="server"></md:MDTextBox><input type="button" id="Btnburando_cd" name="Btnburando_cd" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="Burando_nm" CssClass="inpReadonlyLeft inpROHankaku20" runat="server"></asp:TextBox>
													</td>
													<!--- 「旧自社品番」一行テキストボックス（セパレート日付以外） --->
													<!--- 「メーカー品番」テキストボックスリードオンリー --->
													<th>
														<span class="tbl-hdg"><asp:Label ID="Old_jisya_hbn_lbl" runat="server">自社品番</asp:Label></span>
													</th>
													<td colspan="3">
														<md:MDTextBox ID="Old_jisya_hbn" CssClass="inpJishahin10" runat="server"></md:MDTextBox><asp:TextBox ID="Maker_hbn" CssClass="inpReadonlyLeft inpMkhin" runat="server"></asp:TextBox>
													</td>
												</tr>
												<tr>
													<!--- 「スキャンコード」一行テキストボックス（セパレート日付以外） --->
													<th>
														<span class="tbl-hdg"><asp:Label ID="Scan_cd_lbl" runat="server">ｽｷｬﾝｺｰﾄﾞ</asp:Label></span>
													</th>
													<td>
														<md:MDTextBox ID="Scan_cd" CssClass="inpScanHdg" runat="server"></md:MDTextBox>
													</td>
													<!--- 「登録日ｆｒｏｍ」一行テキストボックス（セパレート日付以外） --->
													<!--- 「登録日ｔｏ」一行テキストボックス（セパレート日付以外） --->
													<th>
														<span class="tbl-hdg"><asp:Label ID="Add_ymd_from_lbl" runat="server">登録日</asp:Label></span>
													</th>
													<td colspan="3">
														<span class="icon-in"><md:MDTextBox ID="Add_ymd_from" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span>
														<span class="label-fromto">～</span>
														<span class="icon-in"><md:MDTextBox ID="Add_ymd_to" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span>
													</td>
													<!--- 「登録担当者コード」一行テキストボックス（セパレート日付以外） --->
													<!--- 「登録担当者コードボタン」ボタン --->
													<!--- 「登録担当者名」テキストボックスリードオンリー --->
													<th>
														<span class="tbl-hdg"><asp:Label ID="Tantosya_cd_lbl" runat="server">登録担当者</asp:Label></span>
													</th>
													<td>
														<span class="icon-in"><md:MDTextBox ID="Tantosya_cd" CssClass="inpSerch inpTanto" runat="server"></md:MDTextBox><input type="button" id="Btntanto_cd" name="Btntanto_cd" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="Hanbaiin_nm" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
													</td>
												</tr>
												<tr>
													<!--- 「依頼理由コード1」ドロップダウンリスト --->
													<!--- 「依頼理由コード２」ドロップダウンリスト --->
													<th>
														<span class="tbl-hdg"><asp:Label ID="Irairiyu_cd1_lbl" runat="server">依頼理由</asp:Label></span>
													</th>
													<td>
														<div>
														<md:MDCodeCondition ID="Irairiyu_cd1" FormID="Ta080f03" PgID="Ta080p01" CssClass="slt-riyu" runat="server"></md:MDCodeCondition>
														<span class="select-arrow"></span>
														</div>
														<div>
														<md:MDCodeCondition ID="Irairiyu_cd2" FormID="Ta080f03" PgID="Ta080p01" CssClass="slt-riyu" runat="server"></md:MDCodeCondition>
														<span class="select-arrow"></span>
														</div>
													</td>
													<!--- 「店評価」ドロップダウンリスト --->
													<!--- 「全評価」ドロップダウンリスト --->
													<th>
														<span class="tbl-hdg"><asp:Label ID="Hyoka_kb_mise_lbl" runat="server">評価</asp:Label></span>
													</th>
													<td>
														<md:MDConditionDDList ID="Hyoka_kb_mise" ConditionName="hyoka_kbn" CssClass="slt-hyoka" runat="server"></md:MDConditionDDList>
														<span class="select-arrow"></span>
														<md:MDConditionDDList ID="Hyoka_kb_all" ConditionName="hyoka_kbn" CssClass="slt-hyoka" runat="server"></md:MDConditionDDList>
														<span class="select-arrow"></span>
													</td>
													<!--- 「並び順１」ドロップダウンリスト --->
													<!--- 「並び順１昇降」ドロップダウンリスト --->
													<!--- 「並び順２」ドロップダウンリスト --->
													<!--- 「並び順２昇降」ドロップダウンリスト --->
													<!--- 「並び順３」ドロップダウンリスト --->
													<!--- 「並び順３昇降」ドロップダウンリスト --->
													<th>
														<span class="tbl-hdg"><asp:Label ID="Sortkb1_lbl" runat="server">並び順</asp:Label></span>
													</th>
													<td colspan="3">
														<md:MDCodeCondition ID="Sortkb1" FormID="Ta080f03" PgID="Ta080p01" CssClass="slt-sort" runat="server"></md:MDCodeCondition>
														<span class="select-arrow"></span>
														<md:MDConditionDDList ID="Sortoptionkb1" ConditionName="sortoption" CssClass="slt-sortopt" runat="server"></md:MDConditionDDList>
														<span class="select-arrow"></span>
														<md:MDCodeCondition ID="Sortkb2" FormID="Ta080f03" PgID="Ta080p01" CssClass="slt-sort" runat="server"></md:MDCodeCondition>
														<span class="select-arrow"></span>
														<md:MDConditionDDList ID="Sortoptionkb2" ConditionName="sortoption" CssClass="slt-sortopt" runat="server"></md:MDConditionDDList>
														<span class="select-arrow"></span>
														<md:MDCodeCondition ID="Sortkb3" FormID="Ta080f03" PgID="Ta080p01" CssClass="slt-sort" runat="server"></md:MDCodeCondition>
														<span class="select-arrow"></span>
														<md:MDConditionDDList ID="Sortoptionkb3" ConditionName="sortoption" CssClass="slt-sortopt" runat="server"></md:MDConditionDDList>
														<span class="select-arrow"></span>
													</td>
												</tr>
											</table>
										</div>
									</div>
								<td class="search-table-tdright">
									<div class="str-btn-search">
											<!--- 「検索ボタン」ボタン --->
											<input type="button" id="Btnsearch" value="検索" onserverclick="OnBTNSEARCH_FRM" runat="server" class="btn type-02"/>
									<!-- /str-btn-search --></div>
								</td>
							</tr>
						</table>
					<!-- /inner-02 --></div>
				<!-- /str-search-01 --></div>
			<!--- 「モード絞込みボタン」 ---></div>
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
						<!--- 「全選択ボタン」ボタン --->
						<li><span><label><input type="button" id="Btnzenstk" value="" onserverclick="OnBTNZENSTK_FRM" runat="server" class="icon-utility-01"/>全選択</label></span></li>
						<!--- 「全解除ボタン」ボタン --->
						<li><span><label><input type="button" id="Btnzenkjo" value="" onserverclick="OnBTNZENKJO_FRM" runat="server" class="icon-utility-02"/>全解除</label></span></li>
						<!--- 「行追加ボタン」ボタン --->
						<!--- 「ページ追加ボタン」ボタン --->
						<li><span id="Spanrowins" runat="server"><label><input type="button" id="Btnrowins" value="" onserverclick="OnBTNROWINS_MADD" runat="server" class="icon-utility-06"/>行追加</label></span><span id="Spanpageins" runat="server"><label><input type="button" id="Btnpageins" value="" onserverclick="OnBTNPAGEINS_MINSX" runat="server" class="icon-utility-06"/>ページ追加</label></span></li>
						<!--- 「サイズ選択ボタン」ボタン --->
						<li><span><label><input type="button" id="Btnsizstk" name="Btnsizstk" value="" onserverclick="OnBTNSIZSTK_FRM" runat="server" class="icon-utility-07"/>サイズ選択</label></span></li>
						<!--- 「行削除ボタン」ボタン --->
						<li><span><label><input type="button" id="Btnrowdel" value="" onserverclick="OnBTNROWDEL_FRM" runat="server" class="icon-utility-03"/>行削除</label></span></li>
					</ul>
					<ul>
						<!--帳票／CSV系ボタンを配置する場合はこのulタグの中-->
					</ul>
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
							<div class="col3">
								<div><asp:Label ID="M1bumonkana_nm_lbl" runat="server">部門</asp:Label></div>
								<div class="col3-1 headcell"><asp:Label ID="M1ten_hyoka_kb_lbl" runat="server">店評価</asp:Label></div>
								<div class="col3-2 headcell"><asp:Label ID="M1all_hyoka_kb_lbl" runat="server">全評価</asp:Label></div>
								<div class="col3-3 headcell"><asp:Label ID="M1tosyu_uriage_su_lbl" runat="server">当週売</asp:Label></div>
							</div>
							<div class="col4">
								<div><asp:Label ID="M1hinsyu_ryaku_nm_lbl" runat="server">品種</asp:Label></div>
								<div class="col4-1 headcell"><asp:Label ID="M1zensyu_uriage_su_lbl" runat="server">前売</asp:Label></div>
								<div class="col4-2 headcell"><asp:Label ID="M1zenzensyu_uriage_su_lbl" runat="server">前々売</asp:Label></div>
							</div>
							<div class="col5">
							<div><asp:Label ID="M1burando_nm_lbl" runat="server">ブランド</asp:Label></div>
								<div class="col5-1 headcell"><asp:Label ID="M1nyukayotei_su_lbl" runat="server">入荷</asp:Label></div>
								<div class="col5-2 headcell"><asp:Label ID="M1tenzaiko_su_lbl" runat="server">在庫</asp:Label></div>
								<div class="col5-3 headcell"><asp:Label ID="M1jido_su_lbl" runat="server">定数</asp:Label></div>
								<div class="col5-4 headcell"><asp:Label ID="M1haibunkano_su_lbl" runat="server">配可数</asp:Label></div>
							</div>
							<div class="col6">
								<div><asp:Label ID="M1jisya_hbn_lbl" runat="server">自社品番</asp:Label></div>
								<div><asp:Label ID="M1keikaku_ymd_lbl" runat="server">計画期間</asp:Label></div>
							</div>
							<div class="col7">
								<div><asp:Label ID="M1syohin_zokusei_lbl" runat="server">コア</asp:Label></div>
								<div><asp:Label ID="M1lot_su_lbl" runat="server">ﾛｯﾄ</asp:Label></div>
							</div>
							<div class="col8">
								<div><asp:Label ID="M1maker_hbn_lbl" runat="server">メーカー品番</asp:Label></div>
								<div><asp:Label ID="M1syonmk_lbl" runat="server">商品名</asp:Label></div>
							</div>
							<div class="col9">
								<div><asp:Label ID="M1iro_nm_lbl" runat="server">色</asp:Label></div>
								<div><asp:Label ID="M1size_nm_lbl" runat="server">サイズ</asp:Label></div>
							</div>
							<div class="col10">
								<div><asp:Label ID="M1scan_cd_lbl" runat="server">スキャンコード</asp:Label></div>
								<div><asp:Label ID="M1irai_su_lbl" runat="server">依頼数</asp:Label></div>
							</div>
							<div class="col11">
								<div><asp:Label ID="M1hatchu_msg_lbl" runat="server">メッセージ</asp:Label></div>
								<div><asp:Label ID="M1genkakin_lbl" runat="server">原価金額</asp:Label></div>
							</div>
							<div class="col2">
								<div><asp:Label ID="M1hanbaiin_nm_lbl" runat="server">登録担当者</asp:Label></div>
								<div>
									<asp:Label ID="M1irairiyu_cd1_lbl" runat="server">依頼理由</asp:Label>
									<asp:Label ID="M1irairiyu_cd2_lbl" runat="server"></asp:Label>
								</div>
							</div>
							<div class="col13">
								<div><asp:Label ID="M1add_ymd_lbl" runat="server">登録日</asp:Label></div>
								<div><asp:Label ID="M1hanbaikanryo_ymd_lbl" runat="server">販完日</asp:Label></div>
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
										<div class="col3 detail_left">
											<div>
												<!--- 「ｍ１部門カナ名」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1bumonkana_nm" CssClass="inpReadonlyLeft inpRORightNm inpROHankaku12 tooltip " runat="server"></asp:TextBox>
											</div>
											<div class="col3-1 cell detail_left">
												<!--- 「ｍ１店評価」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1ten_hyoka_kb" CssClass="inpReadonlyLeft inpROZenkaku1 tooltip" runat="server"></asp:TextBox>
											</div>
											<div class="col3-2 cell detail_left">
												<!--- 「ｍ１全評価」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1all_hyoka_kb" CssClass="inpReadonlyLeft inpROZenkaku1 tooltip" runat="server"></asp:TextBox>
											</div>
											<div class="col3-3 cell detail_right">
											<!--- 「ｍ１当週売」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1tosyu_uriage_su" CssClass="inpReadonlyRight inpRONumCma5" runat="server"></asp:TextBox>
											</div>
										</div>
										<div class="col4 detail_left">
											<div >
												<!--- 「ｍ１品種略名称」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1hinsyu_ryaku_nm" CssClass="inpReadonlyLeft inpROZenkaku8 tooltip" runat="server"></asp:TextBox>
											</div>
											<div class="col4-1 cell detail_right">
												<!--- 「ｍ１前売」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1zensyu_uriage_su" CssClass="inpReadonlyRight inpRONumCma5" runat="server"></asp:TextBox>
											</div>
											<div class="col4-2 cell detail_right">
												<!--- 「ｍ１前々売」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1zenzensyu_uriage_su" CssClass="inpReadonlyRight inpRONumCma5" runat="server"></asp:TextBox>
											</div>
										</div>
										<div class="col5 detail_left">
											<div>
												<!--- 「ｍ１ブランド名」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1burando_nm" CssClass="inpReadonlyLeft inpROHankaku16 tooltip" runat="server"></asp:TextBox>
											</div>
											<div class="col5-1 cell detail_right">
												<!--- 「ｍ１入荷」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1nyukayotei_su" CssClass="inpReadonlyRight inpRONumCma5" runat="server"></asp:TextBox>
											</div>
											<div class="col5-2 cell detail_right">
												<!--- 「ｍ１在庫」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1tenzaiko_su" CssClass="inpReadonlyRight inpRONumCma5" runat="server"></asp:TextBox>
											</div>
											<div class="col5-3 cell detail_right">
												<!--- 「ｍ１自動定数」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1jido_su" CssClass="inpReadonlyRight inpRONumCma5" runat="server"></asp:TextBox>
											</div>
											<div class="col5-4 cell detail_right">
												<!--- 「ｍ１配分可能数」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1haibunkano_su" CssClass="inpReadonlyRight inpRONumCma5" runat="server"></asp:TextBox>
											</div>
										</div>
										<div class="col6 detail_center">
											<div>
												<!--- 「ｍ１自社品番」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1jisya_hbn" CssClass="inpReadonlyLeft inpRONum8" runat="server"></asp:TextBox>
											</div>
											<div class="detail_center">
												<!--- 「ｍ１計画期間」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1keikaku_ymd" CssClass="inpReadonlyCenter inpRODateYM" runat="server"></asp:TextBox>
											</div>
										</div>
										<div class="col7 detail_center">
											<div>
												<!--- 「ｍ１商品属性」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1syohin_zokusei" CssClass="inpReadonlyLeft inpROHankaku3 tooltip" runat="server"></asp:TextBox>
											</div>
											<div class="detail_right">
												<!--- 「ｍ１ロット数」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1lot_su" CssClass="inpReadonlyRight inpRONum3" runat="server"></asp:TextBox>
											</div>
										</div>
										<div class="col8 detail_left">
											<div>
												<!--- 「ｍ１メーカー品番」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1maker_hbn" CssClass="inpReadonlyLeft inpROHankaku12 tooltip" runat="server"></asp:TextBox>
											</div>
											<div>
												<!--- 「ｍ１商品名(カナ)」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1syonmk" CssClass="inpReadonlyLeft inpROHankaku12 tooltip" runat="server"></asp:TextBox>
											</div>
										</div>
										<div class="col9 detail_left">
											<div>
												<!--- 「ｍ１色」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1iro_nm" CssClass="inpReadonlyLeft inpROHankaku6 tooltip" runat="server"></asp:TextBox>
											</div>
											<div>
												<!--- 「ｍ１サイズ」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1size_nm" CssClass="inpReadonlyLeft inpROHankaku4 tooltip" runat="server"></asp:TextBox>
											</div>
										</div>
										<div class="col10 detail_left">
											<div class="col10-1">
												<!--- 「ｍ１スキャンコード」一行テキストボックス（セパレート日付以外） --->
												<md:MDTextBox ID="M1scan_cd" CssClass="inpScan" runat="server"></md:MDTextBox>
											</div>
											<div class="detail_right">
												<!--- 「ｍ１依頼数量」一行テキストボックス（セパレート日付以外） --->
												<md:MDTextBox ID="M1irai_su" CssClass="inpSu-07" runat="server"></md:MDTextBox>
											</div>
										</div>
										<div class="col11 detail_left">
											<div>
												<!--- 「ｍ１発注メッセージ」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1hatchu_msg" CssClass="inpReadonlyLeft inpROZenkaku6 font-red tooltip" runat="server"></asp:TextBox>
											</div>
											<div class="detail_right">
												<!--- 「ｍ１原価金額」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1genkakin" CssClass="inpReadonlyRight inpRONumCma9" runat="server"></asp:TextBox>
											</div>
										</div>
										<div class="col2 detail_left">
											<div>
												<!--- 「ｍ１登録担当者名」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1hanbaiin_nm" CssClass="inpReadonlyLeft inpROZenkaku10 tooltip" runat="server"></asp:TextBox>
											</div>
											<div>
												<!--- 「ｍ１依頼理由コード1」ドロップダウンリスト --->
												<md:MDCodeCondition ID="M1irairiyu_cd1" FormID="Ta080f03" PgID="Ta080p01" CssClass="slt-riyu-m" runat="server"></md:MDCodeCondition>
												<span class="select-arrow"></span>
												<!--- 「ｍ１依頼理由コード２」ドロップダウンリスト --->
												<md:MDCodeCondition ID="M1irairiyu_cd2" FormID="Ta080f03" PgID="Ta080p01" CssClass="slt-riyu-m" runat="server"></md:MDCodeCondition>
												<span class="select-arrow"></span>
											</div>
										</div>
										<div class="col13 detail_center">
											<div>
												<!--- 「ｍ１登録日」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1add_ymd" CssClass="inpReadonlyCenter inpRONum6" runat="server"></asp:TextBox>
											</div>
											<div>
												<!--- 「ｍ１販売完了日」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1hanbaikanryo_ymd" CssClass="inpReadonlyCenter inpRONum6" runat="server"></asp:TextBox>
											</div>
										</div>

										<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
										<div style="display:none">
											<div class="col31">
												<asp:Label ID="M1uriage_su_hdn_lbl" runat="server"></asp:Label>
											</div>
											<div class="col31">
												<asp:Label ID="M1irai_su_hdn_lbl" runat="server"></asp:Label>
											</div>
											<div class="col32">
												<asp:Label ID="M1irairiyu_cd_hdn1_lbl" runat="server"></asp:Label>
											</div>
											<div class="col33">
												<asp:Label ID="M1irairiyu_cd_hdn2_lbl" runat="server"></asp:Label>
											</div>
											<div class="col34">
												<asp:Label ID="M1gen_tnk_lbl" runat="server"></asp:Label>
											</div>
											<div class="col35">
												<asp:Label ID="M1genkakin_hdn_lbl" runat="server"></asp:Label>
											</div>
											<div class="col36">
												<asp:Label ID="M1selectorcheckbox_lbl" runat="server"></asp:Label>
											</div>
											<div class="col37">
												<asp:Label ID="M1entersyoriflg_lbl" runat="server"></asp:Label>
											</div>
											<div class="col38">
												<asp:Label ID="M1dtlirokbn_lbl" runat="server"></asp:Label>
											</div>
											<div class="col31">
												<!--- 「Ｍ１売上実績数(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1uriage_su_hdn" runat="server"></asp:hiddenfield>
											</div>
											<div class="col31">
												<!--- 「Ｍ１依頼数量(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1irai_su_hdn" runat="server"></asp:hiddenfield>
											</div>
											<div class="col32">
												<!--- 「Ｍ１依頼理由コード１（隠し）」隠しフィールド --->
												<asp:hiddenfield ID="M1irairiyu_cd_hdn1" runat="server"></asp:hiddenfield>
											</div>
											<div class="col33">
												<!--- 「Ｍ１依頼理由コード２（隠し）」隠しフィールド --->
												<asp:hiddenfield ID="M1irairiyu_cd_hdn2" runat="server"></asp:hiddenfield>
											</div>
											<div class="col34">
												<!--- 「Ｍ１原単価(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1gen_tnk" runat="server"></asp:hiddenfield>
											</div>
											<div class="col35">
												<!--- 「Ｍ１原価金額(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1genkakin_hdn" runat="server"></asp:hiddenfield>
											</div>
											<div class="col36">
												<!--- 「ｍ１選択フラグ(隠し)」チェックボックス --->
												<adv:AdvancedCheckBox ID="M1selectorcheckbox" Text="" CssClass="" runat="server"></adv:AdvancedCheckBox>
											</div>
											<div class="col37">
												<!--- 「Ｍ１確定処理フラグ(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1entersyoriflg" runat="server"></asp:hiddenfield>
											</div>
											<div class="col38">
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
							<div class="col3 detail_right">&nbsp;</div>
							<div class="col4 detail_right">&nbsp;</div>
							<div class="col5 detail_right">&nbsp;</div>
							<div class="col6 detail_right">&nbsp;</div>
							<div class="col7 detail_right">&nbsp;</div>
							<div class="col8 detail_right">&nbsp;</div>
							<div class="col9 detail_ftr_title">
								<asp:Label ID="Gokei_irai_su_lbl" runat="server">合計</asp:Label>
							</div>
							<div class="col10 detail_ftr">
								<!--- 「合計依頼数量」テキストボックスリードオンリー --->
								<asp:TextBox ID="Gokei_irai_su" CssClass="inpReadonlyRight inpRONumCma9" runat="server"></asp:TextBox>
							</div>
							<div class="col11 detail_ftr">
								<!--- 「合計原価金額」テキストボックスリードオンリー --->
								<asp:TextBox ID="Gokei_genkakin" CssClass="inpReadonlyRight inpRONumCma9" runat="server"></asp:TextBox>
							</div>
							<div class="col2-1 detail_ftr_title">
								<asp:Label ID="Footer_zan_kin_lbl" runat="server">残</asp:Label>
							</div>
							<div class="col2-2 detail_ftr">
								<!--- 「残金額１」一行テキストボックス（セパレート日付以外） --->
								<md:MDTextBox ID="Footer_zan_kin" CssClass="inpReadonlyRight inpRONumCma9" runat="server"></md:MDTextBox>
							</div>
							<div class="col13">&nbsp;</div>
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
			<!--- 「選択モードNO」隠しフィールド --->
			<asp:hiddenfield ID="Stkmodeno" runat="server"></asp:hiddenfield>
			<!--- 「明細モードNO」隠しフィールド --->
			<asp:hiddenfield ID="Meisai_modeno" runat="server"></asp:hiddenfield>
			<!--- 「明細選択モードNO」隠しフィールド --->
			<asp:hiddenfield ID="Meisai_stkmodeno" runat="server"></asp:hiddenfield>
   			<asp:Label ID="Head_tenpo_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Head_tenpo_cd_lbl" runat="server"></asp:Label>
			<asp:Label ID="Head_tenpo_cd_Req" runat="server" CssClass="required">*</asp:Label>
			<asp:Label ID="Yosan_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Yosan_nm1_lbl" runat="server"></asp:Label>
			<asp:Label ID="Bumon_nm_from_lbl" runat="server"></asp:Label>
			<asp:Label ID="Bumon_cd_to_lbl" runat="server">部門ＴＯ</asp:Label>
			<asp:Label ID="Bumon_nm_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Hinsyu_cd1_lbl" runat="server">1</asp:Label>
			<asp:Label ID="Hinsyu_cd2_lbl" runat="server">2</asp:Label>
			<asp:Label ID="Hinsyu_cd3_lbl" runat="server">3</asp:Label>
			<asp:Label ID="Hinsyu_cd4_lbl" runat="server">4</asp:Label>
			<asp:Label ID="Hinsyu_cd5_lbl" runat="server">5</asp:Label>
			<asp:Label ID="Hinsyu_cd6_lbl" runat="server">6</asp:Label>
			<asp:Label ID="Hinsyu_cd7_lbl" runat="server">7</asp:Label>
			<asp:Label ID="Hinsyu_cd8_lbl" runat="server">8</asp:Label>
			<asp:Label ID="Hinsyu_cd9_lbl" runat="server">9</asp:Label>
			<asp:Label ID="Burando_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Maker_hbn_lbl" runat="server"></asp:Label>
			<asp:Label ID="Add_ymd_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Hanbaiin_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Irairiyu_cd2_lbl" runat="server">依頼理由</asp:Label>
			<asp:Label ID="Hyoka_kb_all_lbl" runat="server"></asp:Label>
			<asp:Label ID="Sortoptionkb1_lbl" runat="server"></asp:Label>
			<asp:Label ID="Sortkb2_lbl" runat="server"></asp:Label>
			<asp:Label ID="Sortoptionkb2_lbl" runat="server"></asp:Label>
			<asp:Label ID="Sortkb3_lbl" runat="server"></asp:Label>
			<asp:Label ID="Sortoptionkb3_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokei_genkakin_lbl" runat="server"></asp:Label>
		</div>
	</form>
</body>
</html>

