<%@ Page language="c#" CodeFile="ta080f01.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Ta080p01.Page.Ta080f01Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">補充・仕入稟議検索</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="ta080p01" FormId="ta080f01" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/ta080f01.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="ta080p01" FormId="ta080f01" runat="server" />
	<!-- Js業務部品のインポート --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02001.js" charset="UTF-8"></script><!-- 店舗検索 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02003.js" charset="UTF-8"></script><!-- 発注マスタ取得(自社品番) -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02004.js" charset="UTF-8"></script><!-- 発注マスタ取得(スキャンコード) -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02005.js" charset="UTF-8"></script><!-- 担当者検索 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02028.js" charset="UTF-8"></script><!-- 仕入枠グループ検索 -->

	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05001.js" charset="UTF-8"></script><!-- 自社品番丸め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05002.js" charset="UTF-8"></script><!-- スキャンコード丸め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05003.js" charset="UTF-8"></script><!-- 明細背景色変更処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script><!-- 0埋め処理 -->	
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05011.js" charset="UTF-8"></script><!-- FROM-TOコピー処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05014.js" charset="UTF-8"></script><!-- 名称取得拡張 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05015.js" charset="UTF-8"></script><!-- 項目制御処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05023.js" charset="UTF-8"></script><!-- 日付編集関数群 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05024.js" charset="UTF-8"></script><!-- 数値編集関数群 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05027.js" charset="UTF-8"></script><!-- 会社判定処理 -->

	<!-- 業務共通コントロールのインポート-->
	<%@ Register TagPrefix="uc" TagName="common" Src="~/pjcommon/businessCommon/usercontrol/boCommonControl.ascx" %>
</head>

<body>
	<form id="Ta080f01" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="ta080p01" PgName="補充・仕入稟議検索" FormId="ta080f01" FormName="補充・仕入稟議検索 一覧" ></uc:Header>

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
				<span class="icon-in"><md:MDTextBox ID="Head_tenpo_cd" CssClass="inpSerch inpHeaderTenpo" runat="server"></md:MDTextBox><input type="button" id="Btnheadtenpocd" name="Btnheadtenpocd" value="" runat="server" class="icon-search"/></span>
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
						<!--- 「モード申請ボタン」リンク --->
						<a id="Btnmodeapply" href="#tab6" class="" runat="server">申請</a>
					</li>
					<li>
						<!--- 「モード申請前修正ボタン」リンク --->
						<a id="Btnmodesinseimaesyusei" href="#tab34" class="" runat="server">申請前修正</a>
					</li>
					<li>
						<!--- 「モード申請取消ボタン」リンク --->
						<a id="Btnmodesinseizumitorikesi" href="#tab37" class="" runat="server">申請取消</a>
					</li>
					<li>
						<!--- 「モード登録履歴照会ボタン」リンク --->
						<a id="Btnmoderef_torokurireki" href="#tab38" class="" runat="server">登録履歴照会</a>
					</li>
					<li>
						<!--- 「モード稟議結果照会ボタン」リンク --->
						<a id="Btnmoderef_ringikekka" href="#tab39" class="" runat="server">稟議結果照会</a>
					</li>
				</ul>
			</div>

			<!--- 「モード申請ボタン」 --->
			<div id="tab6" class="str-tab-cont"></div>
			<!--- 「モード申請前修正ボタン」 --->
			<div id="tab34" class="str-tab-cont"></div>
			<!--- 「モード申請取消ボタン」 --->
			<div id="tab37" class="str-tab-cont"></div>
			<!--- 「モード登録履歴照会ボタン」 --->
			<div id="tab38" class="str-tab-cont"></div>
			<!--- 「モード稟議結果照会ボタン」 --->
			<div id="tab39" class="str-tab-cont"></div>

			<!-- search-list -->
			<div class="str-search-01">
		
				<!------------------------------------------
				  □検索条件領域(非表示時)
				-------------------------------------------->
				<div class="inner-01" style="display:none;">
					<table class="search-table">
						<tr>
							<td class="search-table-tdleft">
								<div class="list-search-condition">
								<!-- /list-search-condition --></div>
							</td>
							<td class="search-table-tdright">
								<div class="list-search-result">
									<!--- 「検索件数」テキストボックスリードオンリー --->
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
										<!--<p class="required">*が付いている項目は必須入力になります。</p>-->
										<table>
											<colgroup>
												<col class="w-type-01"/>
												<col class="w-type-02"/>
												<col class="w-type-01"/>
												<col class="w-type-03"/>
												<col class="w-type-01"/>
												<col class="w-type-04"/>
												<col />
											</colgroup>
											<tr>
												<!--- 「年月度ｆｒｏｍ」一行テキストボックス（セパレート日付以外） --->
												<!--- 「年月度ｔｏ」一行テキストボックス（セパレート日付以外） --->
												<th>
													<span class="tbl-hdg"><asp:Label ID="Yosan_ymd_from_lbl" runat="server">年月度</asp:Label></span>
												</th>
												<td>
													<md:MDTextBox ID="Yosan_ymd_from" CssClass="nengetsudo" runat="server"></md:MDTextBox><span class="label-fromto">～</span><md:MDTextBox ID="Yosan_ymd_to" CssClass="nengetsudo" runat="server"></md:MDTextBox>
												</td>
												<!--- 「仕入枠グループコードｆｒｏｍ」一行テキストボックス（セパレート日付以外） --->
												<!--- 「仕入枠グループコードＦＲＯＭボタン」ボタン --->
												<!--- 「仕入枠グループ名ｆｒｏｍ」テキストボックスリードオンリー --->
												<!--- 「仕入枠グループコードｔｏ」一行テキストボックス（セパレート日付以外） --->
												<!--- 「仕入枠グループコードＴＯボタン」ボタン --->
												<!--- 「仕入枠グループ名ｔｏ」テキストボックスリードオンリー --->
												<th>
													<span class="tbl-hdg"><asp:Label ID="Yosan_cd_from_lbl" runat="server">仕入枠グループコード</asp:Label></span>
												</th>
												<td colspan="3">
													<span class="icon-in"><md:MDTextBox ID="Yosan_cd_from" CssClass="inpSerch shiirewaku" runat="server"></md:MDTextBox><input type="button" id="Btnyosan_cd_from" name="Btnyosan_cd_from" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="Yosan_nm_from" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox><span class="label-fromto">～</span><span class="icon-in"><md:MDTextBox ID="Yosan_cd_to" CssClass="inpSerch shiirewaku" runat="server"></md:MDTextBox><input type="button" id="Btnyosan_cd_to" name="Btnyosan_cd_to" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="Yosan_nm_to" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<!--- 「登録日ｆｒｏｍ」一行テキストボックス（セパレート日付以外） --->
												<!--- 「登録日ｔｏ」一行テキストボックス（セパレート日付以外） --->
												<th>
													<span class="tbl-hdg"><asp:Label ID="Add_ymd_from_lbl" runat="server">登録日</asp:Label></span>
												</th>
												<td>
													<span class="icon-in"><md:MDTextBox ID="Add_ymd_from" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span><span class="label-fromto">～</span><span class="icon-in"><md:MDTextBox ID="Add_ymd_to" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span>
												</td>
												<!--- 「登録担当者コード」一行テキストボックス（セパレート日付以外） --->
												<!--- 「登録担当者コードボタン」ボタン --->
												<!--- 「登録担当者名」テキストボックスリードオンリー --->
												<th>
													<span class="tbl-hdg"><asp:Label ID="Tantosya_cd_lbl" runat="server">登録担当者</asp:Label></span>
												</th>
												<td colspan="3">
													<span class="icon-in"><md:MDTextBox ID="Tantosya_cd" CssClass="inpSerch inpTanto" runat="server"></md:MDTextBox><input type="button" id="Btntanto_cd" name="Btntanto_cd" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="Hanbaiin_nm" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<!--- 「申請日ｆｒｏｍ」一行テキストボックス（セパレート日付以外） --->
												<!--- 「申請日ｔｏ」一行テキストボックス（セパレート日付以外） --->
												<th>
													<span class="tbl-hdg"><asp:Label ID="Apply_ymd_from_lbl" runat="server">申請日</asp:Label></span>
												</th>
												<td>
													<span class="icon-in"><md:MDTextBox ID="Apply_ymd_from" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span><span class="label-fromto">～</span><span class="icon-in"><md:MDTextBox ID="Apply_ymd_to" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span>
												</td>
												<!--- 「申請種別」ドロップダウンリスト --->
												<th>
													<span class="tbl-hdg"><asp:Label ID="Sinsei_sb_lbl" runat="server">申請種別</asp:Label></span>
												</th>
												<td>
													<md:MDConditionDDList ID="Sinsei_sb" ConditionName="sinsei_sb" CssClass="slt-shinseisb" runat="server"></md:MDConditionDDList>
													<span class="select-arrow"></span>
												</td>
												<!--- 「依頼理由コード」ドロップダウンリスト --->
												<!--- 「依頼理由コード1」ドロップダウンリスト --->
												<th>
													<span class="tbl-hdg"><asp:Label ID="Irairiyu_cd_lbl" runat="server">依頼理由</asp:Label></span>
												</th>
												<td>
													<md:MDCodeCondition ID="Irairiyu_cd" FormID="Ta080f01" PgID="Ta080p01" CssClass="slt-riyu" runat="server"></md:MDCodeCondition>
													<span class="select-arrow"></span>
													<md:MDCodeCondition ID="Irairiyu_cd1" FormID="Ta080f01" PgID="Ta080p01" CssClass="slt-riyu" runat="server"></md:MDCodeCondition>
													<span class="select-arrow"></span>
												</td>
											</tr>
											<tr>
												<!--- 「状態」ドロップダウンリスト --->
												<th>
													<span class="tbl-hdg"><asp:Label ID="Jotai_kbn_lbl" runat="server">状態</asp:Label></span>
												</th>
												<td colspan="6">
													<md:MDCodeCondition ID="Jotai_kbn" FormID="Ta080f01" PgID="Ta080p01" CssClass="slt-jotai" runat="server"></md:MDCodeCondition>
													<span class="select-arrow"></span>
												</td>
											</tr>
											<tr>
												<!--- 「旧自社品番」一行テキストボックス（セパレート日付以外） --->
												<!--- 「メーカー品番」テキストボックスリードオンリー --->
												<th class="last">
													<span class="tbl-hdg"><asp:Label ID="Old_jisya_hbn_lbl" runat="server">自社品番</asp:Label></span>
												</th>
												<td class="last" colspan="3">
													<md:MDTextBox ID="Old_jisya_hbn" CssClass="inpScanHdg" runat="server"></md:MDTextBox><asp:TextBox ID="Maker_hbn" CssClass="inpReadonlyLeft inpMkhin" runat="server"></asp:TextBox>
												</td>
												<!--- 「スキャンコード」一行テキストボックス（セパレート日付以外） --->
												<th class="last">
													<span class="tbl-hdg"><asp:Label ID="Scan_cd_lbl" runat="server">ｽｷｬﾝｺｰﾄﾞ</asp:Label></span>
												</th>
												<td class="last">
													<md:MDTextBox ID="Scan_cd" CssClass="inpScanHdg" runat="server"></md:MDTextBox>
												</td>
											</tr>
										</table>
									<!-- /inner --></div>
								<!-- /str-form-02 --></div>
							</td>
							<td class="search-table-tdright">
								<div class="str-btn-search">
									<!--- 「新規作成ボタン」ボタン --->
									<input type="button" id="Btninsert" value="新規作成" onserverclick="OnBTNINSERT_FRM" runat="server" class="btn type-04"/>
									<!--- 「検索ボタン」ボタン --->
									<input type="button" id="Btnsearch" value="検索" onserverclick="OnBTNSEARCH_FRM" runat="server" class="btn type-02"/>
								<!-- /str-btn-search --></div>
							</td>
						</tr>
					</table>
				<!-- /inner-02 --></div>
			<!-- /str-search-01 --></div>

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
						<!--- 「全選択ボタン」ボタン --->
						<li><span><label><input type="button" id="Btnzenstk" value="" onserverclick="OnBTNZENSTK_FRM" runat="server" class="icon-utility-01"/>全選択</label></span></li>
						<!--- 「全解除ボタン」ボタン --->
						<li><span><label><input type="button" id="Btnzenkjo" value="" onserverclick="OnBTNZENKJO_FRM" runat="server" class="icon-utility-02"/>全解除</label></span></li>
					</ul>
					<ul>
						<!--帳票／CSV系ボタンを配置する場合はこのulタグの中-->
					</ul>
					</div>
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
								<asp:Label ID="M1yosan_ymd_lbl" runat="server">年月度</asp:Label>
							</div>
							<div class="col3">
								<asp:Label ID="M1yosan_cd_lbl" runat="server">仕入枠ｸﾞﾙｰﾌﾟ</asp:Label>
							</div>
							<div class="col4">
								<asp:Label ID="M1yosan_kin_lbl" runat="server">予算金額</asp:Label>
							</div>
							<div class="col5">
								<asp:Label ID="M1misinsei_su_lbl" runat="server">未申請数</asp:Label>
							</div>
							<div class="col6">
								<asp:Label ID="M1misinsei_kin_lbl" runat="server">未申請金額</asp:Label>
							</div>
							<div class="col7">
								<asp:Label ID="M1applygokei_su_lbl" runat="server">申請数</asp:Label>
							</div>
							<div class="col8">
								<asp:Label ID="M1applygokei_kin_lbl" runat="server">申請金額</asp:Label>
							</div>
							<div class="col9">
								<asp:Label ID="M1jissekigokei_su_lbl" runat="server">実績数</asp:Label>
							</div>
							<div class="col10">
								<asp:Label ID="M1jissekigokei_kin_lbl" runat="server">実績金額</asp:Label>
							</div>
							<div class="col11">
								<asp:Label ID="M1zan_kin_lbl" runat="server">残金額</asp:Label>
							</div>
							<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
							<div style="display:none">
								<div class="col12">
									<asp:Label ID="M1selectorcheckbox_lbl" runat="server"></asp:Label>
								</div>
								<div class="col13">
									<asp:Label ID="M1entersyoriflg_lbl" runat="server"></asp:Label>
								</div>
								<div class="col14">
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
											<!--- 「ｍ１行no」ラベル --->
											<asp:Label ID="M1rowno" CssClass="inpReadonlyRight inpRONum4" runat="server"></asp:Label>
										</div>
										<div class="col2 detail_center">
											<!--- 「ｍ１年月度」ラベル --->
											<asp:Label ID="M1yosan_ymd" CssClass="inpReadonlyCenter inpRODate" runat="server"></asp:Label>
										</div>
										<div class="col3 detail_left">
											<!--- 「Ｍ１仕入枠グループリンク」ボタン --->
											<input type="button" id="M1yosan_cd" value="仕入枠ｸﾞﾙｰﾌﾟ" onserverclick="OnM1YOSAN_CD_FRM" runat="server" class="meisaiLink"/>
										</div>
										<div class="col4 detail_right">
											<!--- 「ｍ１予算金額」ラベル --->
											<asp:Label ID="M1yosan_kin" CssClass="inpReadonlyRight inpRONumCma8" runat="server"></asp:Label>
										</div>
										<div class="col5 detail_right">
											<!--- 「ｍ１未申請数」ラベル --->
											<asp:Label ID="M1misinsei_su" CssClass="inpReadonlyRight inpRONumCma8" runat="server"></asp:Label>
										</div>
										<div class="col6 detail_right">
											<!--- 「ｍ１未申請金額」ラベル --->
											<asp:Label ID="M1misinsei_kin" CssClass="inpReadonlyRight inpRONumCma8" runat="server"></asp:Label>
										</div>
										<div class="col7 detail_right">
											<!--- 「ｍ１申請数」ラベル --->
											<asp:Label ID="M1applygokei_su" CssClass="inpReadonlyRight inpRONumCma8" runat="server"></asp:Label>
										</div>
										<div class="col8 detail_right">
											<!--- 「ｍ１申請金額」ラベル --->
											<asp:Label ID="M1applygokei_kin" CssClass="inpReadonlyRight inpRONumCma8" runat="server"></asp:Label>
										</div>
										<div class="col9 detail_right">
											<!--- 「ｍ１実績数」ラベル --->
											<asp:Label ID="M1jissekigokei_su" CssClass="inpReadonlyRight inpRONumCma8" runat="server"></asp:Label>
										</div>
										<div class="col10 detail_right">
											<!--- 「ｍ１実績金額」ラベル --->
											<asp:Label ID="M1jissekigokei_kin" CssClass="inpReadonlyRight inpRONumCma8" runat="server"></asp:Label>
										</div>
										<div class="col11 detail_right">
											<!--- 「ｍ１残金額」ラベル --->
											<asp:Label ID="M1zan_kin" CssClass="inpReadonlyRight inpRONumCma8" runat="server"></asp:Label>
										</div>
										<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
										<div style="display:none">
											<div class="col12">
												<!--- 「ｍ１選択フラグ(隠し)」チェックボックス --->
												<adv:AdvancedCheckBox ID="M1selectorcheckbox" Text="" CssClass="" runat="server"></adv:AdvancedCheckBox>
											</div>
											<div class="col13">
												<!--- 「Ｍ１確定処理フラグ(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1entersyoriflg" runat="server"></asp:hiddenfield>
											</div>
											<div class="col14">
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
							<font style="color:#000000;">※未申請数/未申請金額のみ、入力した検索条件による絞り込みが行われます。</font>
						</p>
						<p>
							<!-- ページャ下部にボタンを配置する場合はこの中 -->
							<!--- 「確定ボタン」ボタン --->
							<input type="button" id="Btnenter" value="確定" onserverclick="OnBTNENTER_DBU" runat="server" class="btn type-01"/>
						</p>
					<!-- /str-pager-01 --></div>
				<!-- /footerBtnArea --></div>
			<!-- /str-wrap-result --></div>
			<!-- 初期表示時にコメントを出力するようのフッター -->
			<div id="footerBtnArea2" class="pad0" runat="server">
				<div id="str-pager-bottom2" class="footer str-pager-01 pad0">
					<p>
						<font style="color:#000000;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;※未申請数/未申請金額のみ、入力した検索条件による絞り込みが行われます。</font>
					</p>
					<p>
					</p>
				<!-- /str-pager-01 --></div>
			<!-- /footerBtnArea2 --></div>
			<!-- 初期表示時にコメントを出力するようのフッター -->
		<!-- /wrap --></div>
		
		<!-- 画面上隠しエレメントを格納するエリア-->
		<div id="hiddenElements" style="display:none" runat="server">
			<!--- 「モードNO」隠しフィールド --->
			<asp:hiddenfield ID="Modeno" runat="server"></asp:hiddenfield>
			<!--- 「選択モードNO」隠しフィールド --->
			<asp:hiddenfield ID="Stkmodeno" runat="server"></asp:hiddenfield>
			<asp:Label ID="Head_tenpo_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Head_tenpo_cd_lbl" runat="server"></asp:Label>
			<asp:Label ID="Head_tenpo_cd_Req" runat="server" CssClass="required">*</asp:Label>
			<std:LinkCalendar ID="Yosan_ymd_fromCalendar" TargetId="Yosan_ymd_from" runat="server" />
			<std:LinkCalendar ID="Yosan_ymd_toCalendar" TargetId="Yosan_ymd_to" runat="server" />
			<asp:Label ID="Yosan_ymd_to_lbl" runat="server">年月度ＴＯ</asp:Label>
			<asp:Label ID="Yosan_nm_from_lbl" runat="server"></asp:Label>
			<asp:Label ID="Yosan_cd_to_lbl" runat="server">仕入枠グループコードＴＯ</asp:Label>
			<asp:Label ID="Yosan_nm_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Add_ymd_to_lbl" runat="server">登録日ＴＯ</asp:Label>
			<asp:Label ID="Hanbaiin_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Apply_ymd_to_lbl" runat="server">申請日ＴＯ</asp:Label>
			<asp:Label ID="Maker_hbn_lbl" runat="server"></asp:Label>
			<asp:Label ID="Searchcnt_lbl" runat="server">検索件数</asp:Label>
			<asp:Label ID="Irairiyu_cd1_lbl" runat="server">依頼理由</asp:Label>
				
		</div>
	</form>
</body>
</html>

