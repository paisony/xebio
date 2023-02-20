<%@ Page language="c#" CodeFile="ta020f01.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Ta020p01.Page.Ta020f01Page" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">出荷要望入力</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="ta020p01" FormId="ta020f01" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/ta020f01.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="ta020p01" FormId="ta020f01" runat="server" />

	<!-- Js業務部品のインポート --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02001.js" charset="UTF-8"></script><!-- 店舗検索 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02005.js" charset="UTF-8"></script><!-- 担当者検索 -->

	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05003.js" charset="UTF-8"></script><!-- 明細背景色変更処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05011.js" charset="UTF-8"></script><!-- FROM-TOコピー処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05014.js" charset="UTF-8"></script><!-- 名称取得拡張 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05015.js" charset="UTF-8"></script><!-- 項目制御処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05024.js" charset="UTF-8"></script><!-- 数値編集関数群 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05027.js" charset="UTF-8"></script><!-- 会社判定処理 -->

	<!-- 業務共通コントロールのインポート-->
	<%@ Register TagPrefix="uc" TagName="common" Src="~/pjcommon/businessCommon/usercontrol/boCommonControl.ascx" %>
</head>

<body>
	<form id="Ta020f01" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="ta020p01" PgName="出荷要望入力" FormId="ta020f01" FormName="出荷要望入力 一覧" ></uc:Header>
			
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
						<!--- 「モード照会ボタン」リンク --->
						<a id="Btnmoderef" href="#tab16" class="" runat="server">照会</a>
					</li>
					<li>
						<!--- 「モード修正ボタン」リンク --->
						<a id="Btnmodeupd" href="#tab8" class="" runat="server">修正</a>
					</li>
					<li>
						<!--- 「モード取消ボタン」リンク --->
						<a id="Btnmodedel" href="#tab11" class="" runat="server">取消</a>
					</li>
				</ul>
			</div>

			<!--- 「モード申請ボタン」 --->
			<div id="tab6" class="str-tab-cont"></div>
			<!--- 「モード照会ボタン」 --->
			<div id="tab16" class="str-tab-cont"></div>
			<!--- 「モード修正ボタン」 --->
			<div id="tab8" class="str-tab-cont"></div>
			<!--- 「モード取消ボタン」 --->
			<div id="tab11" class="str-tab-cont"></div>

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
												<col class="w-type-01" />
												<col class="w-type-02" />
												<col class="w-type-01" />
												<col class="w-type-03" />
												<col class="w-type-01" />
												<col />
											</colgroup>
											<tr>
												<!--- 「依頼日」 --->
												<th>
													<span class="tbl-hdg"><asp:Label ID="Irai_ymd_from_lbl" runat="server">依頼日</asp:Label></span>
												</th>
												<!--- 「依頼日from」一行テキストボックス（セパレート日付以外） --->
												<!--- 「依頼日to」一行テキストボックス（セパレート日付以外） --->
												<td>
													<span class="icon-in"><md:MDTextBox ID="Irai_ymd_from" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span>
													<span class="label-fromto">～</span>
													<span class="icon-in"><md:MDTextBox ID="Irai_ymd_to" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span>
												</td>
												<!--- 「担当者コード」 --->
												<th>
													<span class="tbl-hdg"><asp:Label ID="Tantosya_cd_lbl" runat="server">担当者</asp:Label></span>
												</th>
												<!--- 「担当者コード」一行テキストボックス（セパレート日付以外） --->
												<!--- 「担当者コードボタン」ボタン --->
												<!--- 「担当者名」テキストボックスリードオンリー --->
												<td>
													<span class="icon-in">
														<md:MDTextBox ID="Tantosya_cd" CssClass="inpSerch inpTanto" runat="server"></md:MDTextBox>
														<input type="button" id="Btntanto_cd" name="Btntanto_cd" value="" runat="server" class="icon-search"/>
													</span>
													<asp:TextBox ID="Hanbaiin_nm" CssClass="inpReadonlyLeft" runat="server"></asp:TextBox>
												</td>
												<!--- 「依頼理由」 --->
												<th>
													<span class="tbl-hdg"><asp:Label ID="Irairiyu_cd_lbl" runat="server">依頼理由</asp:Label></span>
												</th>
												<!--- 「依頼理由コード」ドロップダウンリスト --->
												<td>
													<md:MDCodeCondition ID="Irairiyu_cd" FormID="Ta020f01" PgID="Ta020p01" CssClass="slt-ddl slt-riyu" runat="server"></md:MDCodeCondition>
													<span class="select-arrow"></span>
												</td>
											</tr>
											<tr>
												<!--- 「申請状態」 --->
												<th>
													<span class="tbl-hdg"><asp:Label ID="Shinsei_flg_lbl" runat="server">状態</asp:Label></span>
												</th>
												<td>
													<!--- 「申請状態」ドロップダウンリスト --->
													<md:MDConditionDDList ID="Shinsei_flg" ConditionName="sinsei_jotai" CssClass="slt-ddl slt-jotai" runat="server"></md:MDConditionDDList>
													<span class="select-arrow"></span>
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
								<asp:Label ID="M1kanri_no_lbl" runat="server">管理No.</asp:Label>
							</div>
							<div class="col3">
								<asp:Label ID="M1hattyu_ymd_lbl" runat="server">発注日</asp:Label>
							</div>
							<div class="col4">
								<asp:Label ID="M1itemsu_lbl" runat="server">数量</asp:Label>
							</div>
							<div class="col5">
								<asp:Label ID="M1genkakin_lbl" runat="server">原価金額</asp:Label>
							</div>
							<div class="col6">
								<asp:Label ID="M1hanbaiin_nm_lbl" runat="server">担当者</asp:Label>
							</div>
							<div class="col7">
								<asp:Label ID="M1irai_riyu_lbl" runat="server">依頼理由</asp:Label>
							</div>
							<div class="col8">
								<asp:Label ID="M1sinsei_jotainm_lbl" runat="server">状態</asp:Label>
							</div>
							<div class="col9">
								<asp:Label ID="M1apply_ymd_lbl" runat="server">申請日</asp:Label>
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
											<asp:TextBox ID="M1rowno" CssClass="inpReadonlyRight inpRONum4" runat="server"></asp:TextBox>
										</div>
										<div class="col2 detail_center">
											<!--- 「Ｍ１管理NOリンク」ボタン --->
											<input type="button" id="M1kanri_no" value="管理No." onserverclick="OnM1KANRI_NO_FRM" runat="server" class="meisaiLink"/>
										</div>
										<div class="col3 detail_center">
											<!--- 「ｍ１発注日」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1hattyu_ymd" CssClass="inpReadonlyCenter inpRODate" runat="server"></asp:TextBox>
										</div>
										<div class="col4 detail_right">
											<!--- 「ｍ１数量」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1itemsu" CssClass="inpReadonlyRight inpRONumCma9" runat="server"></asp:TextBox>
										</div>
										<div class="col5 detail_right">
											<!--- 「ｍ１原価金額」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1genkakin" CssClass="inpReadonlyRight inpRONumCma9" runat="server"></asp:TextBox>
										</div>
										<div class="col6 detail_left">
											<!--- 「ｍ１担当者名」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1hanbaiin_nm" CssClass="inpReadonlyLeft inpROZenkaku10 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col7 detail_left">
											<!--- 「ｍ１依頼理由」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1irai_riyu" CssClass="inpReadonlyLeft inpROZenkaku10 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col8 detail_left">
											<!--- 「ｍ１申請状態名称」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1sinsei_jotainm" CssClass="inpReadonlyLeft inpROZenkaku3 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col9 detail_center">
											<!--- 「ｍ１申請日」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1apply_ymd" CssClass="inpReadonlyCenter inpRODate" runat="server"></asp:TextBox>
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
			
			<asp:Label ID="Irai_ymd_to_lbl" runat="server"></asp:Label>

			<asp:Label ID="Hanbaiin_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Searchcnt_lbl" runat="server"></asp:Label>

			<!--- 「モードNO」隠しフィールド --->
			<asp:hiddenfield ID="Modeno" runat="server"></asp:hiddenfield>
			<!--- 「選択モードNO」隠しフィールド --->
			<asp:hiddenfield ID="Stkmodeno" runat="server"></asp:hiddenfield>
		</div>
	
	</form>
</body>
</html>

