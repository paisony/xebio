<%@ Page language="c#" CodeFile="te090f01.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Te090p01.Page.Te090f01Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">移動入荷確定</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="te090p01" FormId="te090f01" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/te090f01.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="te090p01" FormId="te090f01" runat="server" />

	<!-- Js業務部品のインポート --->
	<!-- 共通系 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<!-- コード取得系 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02001.js" charset="UTF-8"></script><!-- 店舗情報取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02006.js" charset="UTF-8"></script><!-- 会社情報取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02026.js" charset="UTF-8"></script><!-- 店舗（全企業）情報取得 -->
	<!-- その他 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script><!-- 0埋め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05011.js" charset="UTF-8"></script><!-- FROM-TOコピー処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05015.js" charset="UTF-8"></script><!-- 項目制御処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05026.js" charset="UTF-8"></script><!-- SCMコード丸め処理 -->

</head>

<body>
	<form id="Te090f01" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">

			<uc:Header ID="header" runat="server" PgId="te090p01" PgName="移動入荷確定" FormId="te090f01" FormName="移動入荷確定 一覧" ></uc:Header>

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
						<!--- 「モード入荷確定ボタン」リンク --->
						<a id="Btnmodenyukakakutei" href="#tab3" class="" runat="server">入荷確定</a>
					</li>
					<li>
						<!--- 「モード確定後修正ボタン」リンク --->
						<a id="Btnmodekakuteigoupd" href="#tab10" class="" runat="server">確定後修正</a>
					</li>
					<li>
						<!--- 「モード確定後取消ボタン」リンク --->
						<a id="Btnmodekakuteigodel" href="#tab13" class="" runat="server">確定後取消</a>
					</li>
					<li>
						<!--- 「モード照会ボタン」リンク --->
						<a id="Btnmoderef" href="#tab16" class="" runat="server">照会</a>
					</li>
				</ul>
			</div>

			<div id="tab3" class="str-tab-cont"></div>
			<div id="tab10" class="str-tab-cont"></div>
			<div id="tab13" class="str-tab-cont"></div>
			<div id="tab16" class="str-tab-cont"></div>

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
					<!--<p class="required">*が付いている項目は必須入力になります。</p>-->
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
												<col class="w-type-03"/>
												<col class="w-type-01"/>
												<col />
											</colgroup>
											<tbody>
												<tr>
													<th>
														<span class="tbl-hdg"><asp:Label ID="Kaisya_cd_lbl" runat="server">会社</asp:Label></span>
													</th>
													<td>
														<!--- 「会社コード」一行テキストボックス（セパレート日付以外） ---><!--- 「会社コードボタン」ボタン ---><!--- 「会社名称」テキストボックスリードオンリー --->
														<span class="icon-in"><md:MDTextBox ID="Kaisya_cd" CssClass="inpSerch inpComp" runat="server"></md:MDTextBox><input type="button" id="Btnkaisha_cd" name="Btnkaisha_cd" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="Kaisya_nm" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
													</td>
													<th>
														<span class="tbl-hdg"><asp:Label ID="Syukkaten_cd_lbl" runat="server">出荷店</asp:Label></span>
													</th>
													<td>
														<!--- 「出荷店コード」一行テキストボックス（セパレート日付以外） ---><!--- 「出荷店舗コードボタン」ボタン ---><!--- 「出荷店名称」テキストボックスリードオンリー --->
														<span class="icon-in"><md:MDTextBox ID="Syukkaten_cd" CssClass="inpSerch inpTenpo" runat="server"></md:MDTextBox><input type="button" id="Btnsyukkatencd" name="Btnsyukkatencd" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="Syukkaten_nm" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
													</td>
													<th>
														<span class="tbl-hdg"><asp:Label ID="Denpyo_bango_from_lbl" runat="server">伝票番号ＦＲＯＭ</asp:Label></span>
													</th>
													<td>
														<!--- 「伝票番号from」一行テキストボックス（セパレート日付以外） --->
														<!--- 「伝票番号to」一行テキストボックス（セパレート日付以外） --->
														<md:MDTextBox ID="Denpyo_bango_from" CssClass="inpDenpyo" runat="server"></md:MDTextBox>
														<span class="label-fromto">～</span>
														<md:MDTextBox ID="Denpyo_bango_to" CssClass="inpDenpyo" runat="server"></md:MDTextBox>
													</td>
												</tr>
												<tr>
													<th class="last">
														<span class="tbl-hdg"><asp:Label ID="Scm_cd_lbl" runat="server">SCMコード</asp:Label></span>
													</th>
													<td class="last">
														<!--- 「scmコード」一行テキストボックス（セパレート日付以外） --->
														<md:MDTextBox ID="Scm_cd" CssClass="inpSCM" runat="server"></md:MDTextBox>
													</td>
													<th class="last">
														<span class="tbl-hdg"><asp:Label ID="Syukka_ymd_from_lbl" runat="server">出荷日ＦＲＯＭ</asp:Label></span>
													</th>
													<td class="last" colspan="3">
														<!--- 「出荷日ｆｒｏｍ」一行テキストボックス（セパレート日付以外） --->
														<!--- 「出荷日ｔｏ」一行テキストボックス（セパレート日付以外） --->
														<span class="icon-in"><md:MDTextBox ID="Syukka_ymd_from" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span>
														<span class="label-fromto">～</span>
														<span class="icon-in"><md:MDTextBox ID="Syukka_ymd_to" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span>
													</td>
												</tr>
											</tbody>
										</table>
									<!-- /inner --></div>
								<!-- /str-form-02 --></div>
							</td>
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
					<div id="meisaiBtnArea" class="inner pad0" runat="server">
						<ul>
							<!--明細制御系ボタンを配置する場合はこのulタグの中-->
						</ul>
						<ul>
							<!--帳票／CSV系ボタンを配置する場合はこのulタグの中-->
						</ul>
					<!-- /meisaiBtnArea --></div>
				<!-- /utility --></div>

				<!------------------------------------------
					□明細部
				-------------------------------------------->
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
							<div class="col1"><asp:Label ID="M1rowno_lbl" runat="server">No.</asp:Label></div>
							<div class="col2"><asp:Label ID="M1kaisyakana_nm_lbl" runat="server">会社</asp:Label></div>
							<div class="col3"><asp:Label ID="M1syukkaten_cd_lbl" runat="server">出荷店</asp:Label></div>
							<div class="col4"><asp:Label ID="M1scm_cd_lbl" runat="server">SCMコード</asp:Label></div>
							<div class="col5"><asp:Label ID="M1denpyo_bango_lbl" runat="server">伝票番号</asp:Label></div>
							<div class="col6"><asp:Label ID="M1syukka_ymd_lbl" runat="server">出荷日</asp:Label></div>
							<div class="col7"><asp:Label ID="M1jyuryo_ymd_lbl" runat="server">入荷日</asp:Label></div>
							<div class="col8"><asp:Label ID="M1yotei_su_lbl" runat="server">予定数量</asp:Label></div>
							<div class="col9"><asp:Label ID="M1kakutei_su_lbl" runat="server">確定数量</asp:Label></div>
							<div class="col10"><asp:Label ID="M1kyakucyu_lbl" runat="server">客注</asp:Label></div>
							<div class="col11"><asp:Label ID="M1negaki_lbl" runat="server">値書</asp:Label></div>
							<div class="col12"><asp:Label ID="M1denpyo_jyotainm_lbl" runat="server">伝票状態</asp:Label></div>
							<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
							<div style="display:none">
								<asp:Label ID="M1syukkaten_nm_lbl" runat="server"></asp:Label>
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
											<!--- 「ｍ１行ｎｏ」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1rowno" CssClass="inpReadonlyRight inpRONum3" runat="server"></asp:TextBox>
										</div>
										<div class="col2 detail_left">
											<!--- 「ｍ１会社カナ名」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1kaisyakana_nm" CssClass="inpReadonlyLeft inpROHankaku2" runat="server"></asp:TextBox>
										</div>
										<div class="col3 detail_left">
											<!--- 「ｍ１出荷店コード」テキストボックスリードオンリー --->
											<!--- 「ｍ１出荷店名称」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1syukkaten_cd" CssClass="inpReadonlyLeft inpRONum4" runat="server"></asp:TextBox><asp:TextBox ID="M1syukkaten_nm" CssClass="inpReadonlyLeft inpRORightNm inpROZenkaku10 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col4 detail_center">
											<!--- 「ｍ１scmコード」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1scm_cd" CssClass="inpReadonlyLeft inpRONum20" runat="server"></asp:TextBox>
										</div>
										<div class="col5 detail_center">
											<!--- 「Ｍ１伝票番号リンク」ボタン --->
											<input type="button" id="M1denpyo_bango" value="伝票番号" onserverclick="OnM1DENPYO_BANGO_FRM" runat="server" class="meisaiLink"/>
										</div>
										<div class="col6 detail_center">
											<!--- 「ｍ１出荷日」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1syukka_ymd" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox>
										</div>
										<div class="col7 detail_center">
											<!--- 「ｍ１入荷日」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1jyuryo_ymd" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox>
										</div>
										<div class="col8 detail_right">
											<!--- 「ｍ１予定数量」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1yotei_su" CssClass="inpReadonlyRight inpRONumCma6" runat="server"></asp:TextBox>
										</div>
										<div class="col9 detail_right">
											<!--- 「ｍ１確定数量」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1kakutei_su" CssClass="inpReadonlyRight inpRONumCma6" runat="server"></asp:TextBox>
										</div>
										<div class="col10 detail_center">
											<!--- 「ｍ１客注」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1kyakucyu" CssClass="inpReadonlyLeft inpROZenkaku1" runat="server"></asp:TextBox>
										</div>
										<div class="col11 detail_center">
											<!--- 「ｍ１値書」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1negaki" CssClass="inpReadonlyLeft inpROZenkaku1" runat="server"></asp:TextBox>
										</div>
										<div class="col12 detail_left">
											<!--- 「ｍ１伝票状態名称」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1denpyo_jyotainm" CssClass="inpReadonlyLeft inpROZenkaku3 tooltip" runat="server"></asp:TextBox>
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

			<!--- 「モードNO」隠しフィールド --->
			<asp:hiddenfield ID="Modeno" runat="server"></asp:hiddenfield>
			<!--- 「選択モードNO」隠しフィールド --->
			<asp:hiddenfield ID="Stkmodeno" runat="server"></asp:hiddenfield>

			<asp:Label ID="Kaisya_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Syukkaten_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Denpyo_bango_to_lbl" runat="server">伝票番号ＴＯ</asp:Label>
			<asp:Label ID="Syukka_ymd_to_lbl" runat="server">出荷日ＴＯ</asp:Label>
			<asp:Label ID="Searchcnt_lbl" runat="server"></asp:Label>
		</div>
	
	</form>
</body>
</html>

