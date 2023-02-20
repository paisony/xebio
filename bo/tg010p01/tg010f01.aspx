<%@ Page language="c#" CodeFile="tg010f01.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Tg010p01.Page.Tg010f01Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">プライスシール発行</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="tg010p01" FormId="tg010f01" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/tg010f01.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="tg010p01" FormId="tg010f01" runat="server" />

	<!-- Js業務部品のインポート --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05001.js" charset="UTF-8"></script><!-- 自社品番丸め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05002.js" charset="UTF-8"></script><!-- スキャンコード丸め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05003.js" charset="UTF-8"></script><!-- 明細背景色変更処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script><!-- 0埋め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05010.js" charset="UTF-8"></script><!-- カンマ編集処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05014.js" charset="UTF-8"></script><!-- 名称取得拡張 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05015.js" charset="UTF-8"></script><!-- 項目制御処理 -->	
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05019.js" charset="UTF-8"></script><!-- 情報ダイアログ表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05022.js" charset="UTF-8"></script><!-- 文字列編集汎用関数群 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02001.js" charset="UTF-8"></script><!-- 店舗検索 -->

	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02003.js" charset="UTF-8"></script><!-- 発注マスタ取得(自社品番) -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02004.js" charset="UTF-8"></script><!-- 発注マスタ取得(スキャンコード) -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02010.js" charset="UTF-8"></script><!-- 部門マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02011.js" charset="UTF-8"></script><!-- 品種マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02012.js" charset="UTF-8"></script><!-- ブランドマスタ取得 -->
	
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05020.js" charset="UTF-8"></script><!-- SATOラベルプリンタ発行処理 -->

		<!-- 業務共通コントロールのインポート-->
	<%@ Register TagPrefix="uc" TagName="common" Src="~/pjcommon/businessCommon/usercontrol/boCommonControl.ascx" %>

</head>

<body>
	<!-- ラベル発行用 ActiveControl ↓↓↓↓↓ -->
	<object id="objMLWebComponent" classid="clsid:C137E319-41FE-4F0F-BD1F-190424FD7E2B" codebase="WebComponent-Installer-ja.exe" style="display:none">WebComponentが使用できません。</object>
	<object id="objFileAccessComponent" type="application/x-oleobject" classid="clsid:A3F14F83-0717-444B-9DE5-BFC3AF5C32E8" style="display:none"></object>
	<!-- ラベル発行用 ActiveControl ↑↑↑↑↑ -->

	<form id="Tg010f01" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
			<uc:Header ID="header" runat="server" PgId="tg010p01" PgName="プライスシール発行" FormId="tg010f01" FormName="プライスシール発行" ></uc:Header>
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
						<!--- 「モードスキャンコードボタン」リンク --->
						<a id="Btnmodescancd" href="#tab25" class="" runat="server">スキャンコード</a>
					</li>
					<li>
						<!--- 「モード自社品番ボタン」リンク --->
						<a id="Btnmodejishahinban" href="#tab26" class="" runat="server">自社品番</a>
					</li>
					<li>
						<!--- 「モードその他ボタン」リンク --->
						<a id="Btnmodesonota" href="#tab28" class="" runat="server">その他</a>
					</li>
				</ul>
			</div>
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
									<p class="txt-02">該当件数<span class="hit-number"><md:MDTextBox ID="Searchcnt" CssClass="inpReadonlyRight inpSearchCnt" runat="server"></md:MDTextBox></span><span>件</span></p>
								<!-- /list-search-result --></div>
							</td>
						</tr>
					</table>
					
				<!-- /inner-01 --></div>		
				<!------------------------------------------
				  □検索条件領域(入力時)
				-------------------------------------------->
				<div class="inner-02">
					<p class="required" id="req1" runat="server">&nbsp</p>
					<p class="required" id="req2" runat="server">*が付いている項目は必須入力になります。</p>
					<table class="search-table">
						<tr>
							<td class="search-table-tdleft">
								<div class="str-form-02">
									<div class="inner">
										<!-- モードスキャンコード -->
										<div id="tab25" class="str-tab-cont">
											<table>
												<tbody>
													<tr><th ></th></tr>
												</tbody>
											</table>

										<!-- モードスキャンコード --></div>
										<!-- モード自社品番 -->
										<div id="tab26" class="str-tab-cont">
											<table>
												<colgroup>
													<col class="w-type-01"/>
													<col />
												</colgroup>
												<tbody>
													<tr>
														<!--- 「旧自社品番」一行テキストボックス（セパレート日付以外） --->
														<th><span class="tbl-hdg"><asp:Label ID="Old_jisya_hbn_lbl" runat="server">自社品番</asp:Label></span></th>
														<td><md:MDTextBox ID="Old_jisya_hbn"  CssClass="inpJishahin10" runat="server"></md:MDTextBox></td>
														<!--- 「旧自社品番２」一行テキストボックス（セパレート日付以外） --->
														<td><md:MDTextBox ID="Old_jisya_hbn2" CssClass="inpJishahin10" runat="server"></md:MDTextBox></td>
														<!--- 「旧自社品番３」一行テキストボックス（セパレート日付以外） --->
														<td><md:MDTextBox ID="Old_jisya_hbn3" CssClass="inpJishahin10" runat="server"></md:MDTextBox></td>
														<!--- 「旧自社品番４」一行テキストボックス（セパレート日付以外） --->
														<td><md:MDTextBox ID="Old_jisya_hbn4" CssClass="inpJishahin10" runat="server"></md:MDTextBox></td>
														<!--- 「旧自社品番５」一行テキストボックス（セパレート日付以外） --->
														<td><md:MDTextBox ID="Old_jisya_hbn5" CssClass="inpJishahin10" runat="server"></md:MDTextBox></td>
													</tr>
												</tbody>
											</table>
										<!-- モード自社品番 --></div>
										<!-- モードその他 -->
										<div id="tab28" class="str-tab-cont">
											<table>
												<colgroup>
													<col class="w-type-01"/>
													<col class="w-type-02"/>
													<col class="w-type-01"/>
													<col class="w-type-02"/>
													<col class="w-type-01"/>
													<col />
												</colgroup>
												<tbody>
													<tr>
														<!-- 部門 -->
														<th>
															<span class="tbl-hdg"><asp:Label ID="Bumon_cd_lbl" runat="server">部門</asp:Label></span><asp:Label ID="Bumon_cd__Req" runat="server" CssClass="required">*</asp:Label>
														</th>
														<!--- 「部門コード」一行テキストボックス（セパレート日付以外） --->
														<!--- 「部門コードボタン」ボタン --->
														<!--- 「部門名」テキストボックスリードオンリー --->
														<td>
															<span class="icon-in"><md:MDTextBox ID="Bumon_cd" CssClass="inpSerch inpBumon" runat="server"></md:MDTextBox><input type="button" id="Btnbumon_cd" name="Btnbumon_cd" value="" runat="server" class="icon-search"/></span>
															<asp:TextBox ID="Bumon_nm" CssClass="inpReadonlyLeft  inpROZenkaku10" runat="server"></asp:TextBox>
														</td>
														<!--- 「品種」 --->
														<th>
															<span class="tbl-hdg"><asp:Label ID="Hinsyu_cd_lbl" runat="server">品種</asp:Label></span>
														</th>
														<!--- 「品種コード」一行テキストボックス（セパレート日付以外） --->
														<!--- 「品種コードボタン」ボタン --->
														<!--- 「品種名」テキストボックスリードオンリー --->
														<td>
															<span class="icon-in"><md:MDTextBox ID="Hinsyu_cd" CssClass="inpSerch inpHinshu" runat="server"></md:MDTextBox><input type="button" id="Btnhinsyu_cd" name="Btnhinsyu_cd" value="" runat="server" class="icon-search"/></span>
															<asp:TextBox ID="Hinsyu_ryaku_nm" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
														</td>
														<!-- ブランド -->
														<th>
															<span class="tbl-hdg"><asp:Label ID="Burando_cd_lbl" runat="server">ブランド</asp:Label></span>
														</th>																
														<!--- 「ブランドコード」一行テキストボックス（セパレート日付以外） --->
														<!--- 「ブランドコードボタン」ボタン --->
														<!--- 「ブランド名」テキストボックスリードオンリー --->
														<td>
															<span class="icon-in"><md:MDTextBox ID="Burando_cd" CssClass="inpSerch inpBrand" runat="server"></md:MDTextBox><input type="button" id="Btnburando_cd" name="Btnburando_cd" value="" runat="server" class="icon-search"/></span>
															<asp:TextBox ID="Burando_nm" CssClass="inpReadonlyLeft inpROHankaku20" runat="server"></asp:TextBox>
														</td>
													</tr>
												</tbody>
											</table>
										<!-- モードその他 --></div>
									<!-- /inner --></div>
								<!-- /str-form-02 --></div>
							<!-- /search-table-tdleft --></td>
							<td class="search-table-tdright">
								<div class="str-btn-search">
									<!--- 「新規作成ボタン」ボタン --->
									<input type="button" id="Btninsert" value="新規作成" onserverclick="OnBTNINSERT_FRM" runat="server" class="btn type-04-2"/>
									<!--- 「検索ボタン」ボタン --->
									<input type="button" id="Btnsearch" value="検索" onserverclick="OnBTNSEARCH_FRM" runat="server" class="btn type-02"/>
								</div>
							</td>
						</tr>
				    <!-- /search-table --></table>
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
				<!------------------------------------------
					□明細ボタン部
				-------------------------------------------->
				<!-- button -->
				<div id="str-btn-area" class="str-btn-utility">
					<div id="meisaiBtnArea" class="inner pad0" runat="server">
						<ul>
							<!--明細制御系ボタンを配置する場合はこのulタグの中-->
							<!--- 「ページ追加ボタン」ボタン --->
							<li><span id="Spanpageins" runat="server"><label><input type="button" id="Btnpageins" value="" onserverclick="OnBTNPAGEINS_MINSX" runat="server" class="icon-utility-06"/>ページ追加</label></span></li>
							<!--- 「サイズ選択ボタン」ボタン --->
							<li><span id="Spansizstk" runat="server"><label><input type="button" id="Btnsizstk" value="" onserverclick="OnBTNSIZSTK_FRM" runat="server" class="icon-utility-07"/>サイズ選択</label></span></li>
							<!--- 「行削除ボタン」ボタン --->
							<li><span id="Spanrowdel" runat="server"><label><input type="button" id="Btnrowdel" value="" onserverclick="OnBTNROWDEL_FRM" runat="server" class="icon-utility-03"/>行削除</span></span></li>
							&nbsp;&nbsp;
							<!--- 「出力シール」ラジオボタン --->
							<li><div class="str-syuturyokuseal"><span>出力シール</span></div></li>
							<li><div class="radio-syuturyokuseal"><asp:RadioButtonList ID="Syutsuryoku_seal" RepeatDirection="Horizontal" CssClass="str-radio-table" runat="server"></asp:RadioButtonList></div></li>
						</ul>
						<ul>
							<!--帳票／CSV系ボタンを配置する場合はこのulタグの中-->
							<!--- 「シール発行ボタン」ボタン --->
							<li><span><label><input type="button" id="Btnseal" value="" onserverclick="OnBTNSEAL_FRM" runat="server" class="icon-utility-04"/>シール発行</label></span></li>
							<!--- 「ラベル発行機コードボタン」ボタン ---><!--- 「ラベル発行機名」テキストボックスリードオンリー --->
							<li><span class="icon-in"><input type="button" id="Btnlabel_cd" name="Btnlabel_cd" value="" runat="server" class="icon-search"/></span></li>
							<asp:TextBox ID="Label_nm" CssClass="inpReadonlyLeft" runat="server"></asp:TextBox>
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
								<div><asp:Label ID="M1bumon_cd_lbl" runat="server">部門</asp:Label></div>
								<div><asp:Label ID="M1hinsyu_cd_lbl" runat="server">品種</asp:Label></div>
							
									<asp:Label ID="M1hinsyu_ryaku_nm_lbl" runat="server"></asp:Label>
							</div>
							<div class="col3">
								<div><asp:Label ID="M1burando_nm_lbl" runat="server">ブランド</asp:Label></div>
								<div><asp:Label ID="M1jisya_hbn_lbl" runat="server">自社品番</asp:Label></div>
							</div>
							<div class="col4">
								<div><asp:Label ID="M1maker_hbn_lbl" runat="server">メーカー品番</asp:Label></div>
								<div><asp:Label ID="M1syonmk_lbl" runat="server">商品名</asp:Label></div>
							</div>
							<div class="col5">
								<div class ="col5-1 headcell"><asp:Label ID="M1iro_nm_lbl" runat="server">色</asp:Label></div>
								<div class ="col5-2 headcell"><asp:Label ID="M1size_nm_lbl" runat="server">サイズ</asp:Label></div>
								<div class ="col5 headcell"><asp:Label ID="M1hanbaikanryo_ymd_lbl" runat="server">販売完了日</asp:Label></div>
							</div>
							<div class="col6 col_2dan">
								<asp:Label ID="M1scan_cd_lbl" runat="server">スキャンコード</asp:Label>
							</div>
							<div class="col7 col_2dan">
								<asp:Label ID="M1baihenkaisi_ymd_lbl" runat="server">売変開始日</asp:Label>
							</div>
							<div class="col8 col_2dan">
								<asp:Label ID="M1sijibaika_tnk_lbl" runat="server">指示売価</asp:Label>
							</div>
							<div class="col9 col_2dan">
								<asp:Label ID="M1saisinbaika_tnk_lbl" runat="server">最新売価</asp:Label>
							</div>
							<div class="col10 col_2dan">
								<asp:Label ID="M1maisu_lbl" runat="server">枚数</asp:Label>
							</div>
								<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
							<div style="display:none">
								<asp:Label ID="M1itemkbn_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1siire_kb_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1tyotatsu_kb_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1makerkakaku_tnk_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1baika_zei_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1burando_cd_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1bumon_nm_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1siiresaki_cd_bo1_lbl" runat="server"></asp:Label>
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
										<div class="col1 detail_right col_2dan">
											<!--- 「ｍ１行no」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1rowno" CssClass="inpReadonlyRight inpRONum4" runat="server"></asp:TextBox>
										</div>
										<div class="col2 detail_left">
											<div>
												<!--- 「ｍ１部門コード」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1bumon_cd" CssClass="inpReadonlyLeft inpRONum3" runat="server"></asp:TextBox>
												<!--- 「ｍ１部門カナ名」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1bumonkana_nm" CssClass="inpReadonlyLeft inpROHankaku10 tooltip" runat="server"></asp:TextBox>
											</div><div>
												<!--- 「ｍ１品種コード」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1hinsyu_cd" CssClass="inpReadonlyLeft  inpRONum2" runat="server"></asp:TextBox>
												<!--- 「ｍ１品種略名称」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1hinsyu_ryaku_nm" CssClass="inpReadonlyLeft inpROZenkaku10 tooltip" runat="server"></asp:TextBox>
											</div>
										</div>
										<div class="col3 detail_left">
											<div>
												<!--- 「ｍ１ブランド名」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1burando_nm" CssClass="inpReadonlyLeft inpROHankaku12 tooltip" runat="server"></asp:TextBox>
											</div><div class="detail_center">
												<!--- 「ｍ１自社品番」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1jisya_hbn" CssClass="inpReadonlyRight inpRONum8" runat="server"></asp:TextBox>
											</div>
										</div>
										<div class="col4 detail_left">
											<div>
												<!--- 「ｍ１メーカー品番」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1maker_hbn" CssClass="inpReadonlyLeft inpROHankaku30 tooltip" runat="server"></asp:TextBox>
											</div><div>
												<!--- 「ｍ１商品名(カナ)」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1syonmk" CssClass="inpReadonlyLeft inpROHankaku20 tooltip" runat="server"></asp:TextBox>
											</div>
										</div>
										<div class="col5 detail_center">
											<div class="col5-1 cell detail_left">
												<!--- 「ｍ１色」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1iro_nm" CssClass="inpReadonlyLeft inpROHankaku6 tooltip" runat="server"></asp:TextBox>
											</div><div class="col5-2 cell detail_left ">
												<!--- 「ｍ１サイズ」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1size_nm" CssClass="inpReadonlyLeft inpROHankaku4 tooltip" runat="server"></asp:TextBox>
											</div><div class="col5 cell detail_center">
												<!--- 「ｍ１販売完了日」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1hanbaikanryo_ymd" CssClass="inpReadonlyCenter inpRODate" runat="server"></asp:TextBox>
											</div>
										</div>
										<div class="col6 col_2dan detail_center">
											<!--- 「ｍ１スキャンコード」一行テキストボックス（セパレート日付以外） --->
											<md:MDTextBox ID="M1scan_cd" CssClass="inpScan" runat="server"></md:MDTextBox>
										</div>
										<div class="col7 col_2dan detail_center">
											<!--- 「ｍ１売変開始日」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1baihenkaisi_ymd" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox>
										</div>
										<div class="col8 col_2dan detail_right">
											<!--- 「ｍ１指示売価」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1sijibaika_tnk" CssClass="inpReadonlyRight inpRONumCma7" runat="server"></asp:TextBox>
										</div>
										<div class="col9 col_2dan detail_right">
											<!--- 「ｍ１最新売価」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1saisinbaika_tnk" CssClass="inpReadonlyRight inpRONumCma7" runat="server"></asp:TextBox>
										</div>
										<div class="col10 col_2dan detail_center">
											<!--- 「ｍ１枚数」一行テキストボックス（セパレート日付以外） --->
											<md:MDTextBox ID="M1maisu" CssClass="inpSu-03" runat="server"></md:MDTextBox>
										</div>
										<div style="display:none">
											<!--- 「Ｍ１商品区分(隠し)」隠しフィールド --->
											<asp:hiddenfield ID="M1itemkbn" runat="server"></asp:hiddenfield>
											<!--- 「Ｍ１仕入区分(隠し)」隠しフィールド --->
											<asp:hiddenfield ID="M1siire_kb" runat="server"></asp:hiddenfield>
											<!--- 「Ｍ１調達区分(隠し)」隠しフィールド --->
											<asp:hiddenfield ID="M1tyotatsu_kb" runat="server"></asp:hiddenfield>
											<!--- 「Ｍ１メーカー希望小売価格（隠し）」隠しフィールド --->
											<asp:hiddenfield ID="M1makerkakaku_tnk" runat="server"></asp:hiddenfield>
											<!--- 「Ｍ１税込価格（隠し）」隠しフィールド --->
											<asp:hiddenfield ID="M1baika_zei" runat="server"></asp:hiddenfield>
											<!--- 「Ｍ１ブランドコード（隠し）」隠しフィールド --->
											<asp:hiddenfield ID="M1burando_cd" runat="server"></asp:hiddenfield>
											<!--- 「Ｍ１部門名全角（隠し）」隠しフィールド --->
											<asp:hiddenfield ID="M1bumon_nm" runat="server"></asp:hiddenfield>
											<!--- 「Ｍ１仕入先コード（隠し）」隠しフィールド --->
											<asp:hiddenfield ID="M1siiresaki_cd_bo1" runat="server"></asp:hiddenfield>
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
					<div id="str-pager-bottom" class="footer str-pager-01 pad0 heightZero">
						<p>
						</p>
						<p>
							<!-- ページャ下部にボタンを配置する場合はこの中 -->
							<!--- 「ボタン確定」ボタン --->
						</p>
					<!-- /str-pager-01 --></div>
				<!-- /footerBtnArea --></div>
			<!-- /str-wrap-result --></div>
		<!-- /wrap --></div>	

		
		<!-- 画面上隠しエレメントを格納するエリア-->
		<div id="hiddenElements" style="display:none" runat="server">
			<asp:hiddenfield ID="Modeno" runat="server"></asp:hiddenfield>
			<asp:hiddenfield ID="Stkmodeno" runat="server"></asp:hiddenfield>
			<asp:hiddenfield ID="Label_cd" runat="server"></asp:hiddenfield>
			<asp:hiddenfield ID="Label_ip" runat="server"></asp:hiddenfield>
			<asp:Label ID="Head_tenpo_cd_lbl" runat="server"></asp:Label>
			<asp:Label ID="Head_tenpo_cd_Req" runat="server" CssClass="required">*</asp:Label>
			<asp:Label ID="Head_tenpo_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Old_jisya_hbn2_lbl" runat="server"></asp:Label>
			<asp:Label ID="Old_jisya_hbn3_lbl" runat="server"></asp:Label>
			<asp:Label ID="Old_jisya_hbn4_lbl" runat="server"></asp:Label>
			<asp:Label ID="Old_jisya_hbn5_lbl" runat="server"></asp:Label>
			<asp:Label ID="Searchcnt_lbl" runat="server"></asp:Label>
			<asp:Label ID="Label_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Burando_nm_lbl" runat="server"></asp:Label>					
			<asp:Label ID="Hinsyu_ryaku_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Bumon_nm_lbl" runat="server"></asp:Label>

			<span class="tbl-hdg"><asp:Label ID="Syutsuryoku_seal_lbl" runat="server">出力シール</asp:Label></span>
		
		</div>
	
	</form>
</body>
</html>

