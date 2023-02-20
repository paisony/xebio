<%@ Page language="c#" CodeFile="tf070f02.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Tf070p01.Page.Tf070f02Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">盗難品登録</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="tf070p01" FormId="tf070f02" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/tf070f02.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="tf070p01" FormId="tf070f02" runat="server" />

	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05014.js" charset="UTF-8"></script><!-- 名称取得拡張 -->

	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02004.js" charset="UTF-8"></script><!-- 発注MST取得処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02005.js" charset="UTF-8"></script><!-- 担当者MST取得取得 -->

	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05003.js" charset="UTF-8"></script><!-- 明細背景色変更処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script><!-- 0埋め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05010.js" charset="UTF-8"></script><!-- カンマ編集処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05015.js" charset="UTF-8"></script><!-- 項目入力制御処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05024.js" charset="UTF-8"></script><!-- 数値編集関数群 -->

</head>

<body>
	<form id="Tf070f02" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">

			<uc:Header ID="header" runat="server" PgId="tf070p01" PgName="盗難品登録" FormId="tf070f02" FormName="盗難品登録 明細" ></uc:Header>

			<!------------------------------------------
				□ヘッダー部
			-------------------------------------------->

			<!--- 「ボタン戻る」ボタン --->
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
								<th class="last">
									<span class="tbl-hdg"><asp:Label ID="Tonanhinkanri_no_lbl" runat="server">管理番号</asp:Label></span>
								</th>
								<td class="last">
									<!--- 「盗難品管理番号」テキストボックスリードオンリー --->
									<asp:TextBox ID="Tonanhinkanri_no" CssClass="inpReadonlyRight inpRONum6" runat="server"></asp:TextBox>
								</td>
								<th class="last">
									<span class="tbl-hdg"><asp:Label ID="Jikohassei_ymd_lbl" runat="server">事故発生日</asp:Label><asp:Label ID="Jikohassei_ymd_Req" runat="server" CssClass="required">*</asp:Label></span>
								</th>
								<td class="last">
									<!--- 「事故発生日」一行テキストボックス（セパレート日付以外） --->
									<span class="icon-in"><md:MDTextBox ID="Jikohassei_ymd" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span>
								</td>
								<th class="last">
									<span class="tbl-hdg"><asp:Label ID="Hokoku_ymd_lbl" runat="server">報告日</asp:Label></span>
								</th>
								<td class="last">
									<!--- 「報告日」一行テキストボックス（セパレート日付以外） --->
									<span class="icon-in"><md:MDTextBox ID="Hokoku_ymd" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span>
								</td>
								<th class="last">
									<span class="tbl-hdg"><asp:Label ID="Hokokutan_cd_lbl" runat="server">報告者</asp:Label></span>
								</th>
								<td class="last">
									<!--- 「報告担当者コード」一行テキストボックス（セパレート日付以外） --->
									<!--- 「報告担当者コードボタン」ボタン --->
									<!--- 「報告担当者名称」テキストボックスリードオンリー --->
									<span class="icon-in"><md:MDTextBox ID="Hokokutan_cd" CssClass="inpSerch inpTanto" runat="server"></md:MDTextBox><input type="button" id="Btnhokokutanto_cd" name="Btnhokokutanto_cd" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="Hokokutan_nm" CssClass="inpReadonlyLeft inpROZenkaku10 tooltip" runat="server"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<th class="last">
									<span class="tbl-hdg"><asp:Label ID="Tentyotan_cd_lbl" runat="server">店長</asp:Label><asp:Label ID="Tentyotan_cd_Req" runat="server" CssClass="required">*</asp:Label></span>
								</th>
								<td class="last" colspan="3">
									<!--- 「店長担当者コード」一行テキストボックス（セパレート日付以外） --->
									<!--- 「店長担当者コードボタン」ボタン --->
									<!--- 「店長担当者名称」テキストボックスリードオンリー --->
									<span class="icon-in"><md:MDTextBox ID="Tentyotan_cd" CssClass="inpSerch inpTanto" runat="server"></md:MDTextBox><input type="button" id="Btntenhchotanto_cd" name="Btntenhchotanto_cd" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="Tentyotan_nm" CssClass="inpReadonlyLeft inpROZenkaku10 tooltip" runat="server"></asp:TextBox>
								</td>
								<th class="last">
									<span class="tbl-hdg"><asp:Label ID="Keisatsutodoke_ymd_lbl" runat="server">警察届出日</asp:Label></span>
								</th>
								<td class="last">
									<!--- 「警察届出日」一行テキストボックス（セパレート日付以外） --->
									<span class="icon-in"><md:MDTextBox ID="Keisatsutodoke_ymd" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span>
								</td>
								<th class="last">
									<span class="tbl-hdg"><asp:Label ID="Todokedesakikeisatsu_nm_lbl" runat="server">届出警察署</asp:Label></span>
								</th>
								<td class="last">
									<!--- 「届出先警察署名」一行テキストボックス（セパレート日付以外） --->
									<md:MDTextBox ID="Todokedesakikeisatsu_nm" CssClass="inpKeisatsu" runat="server"></md:MDTextBox>
								</td>
							</tr>
							<tr>
								<th class="last">
									<span class="tbl-hdg"><asp:Label ID="Jyuri_no_lbl" runat="server">受理番号</asp:Label></span>
								</th>
								<td class="last" colspan="5">
									<!--- 「受理番号」一行テキストボックス（セパレート日付以外） --->
									<md:MDTextBox ID="Jyuri_no" CssClass="inpJuriNo" runat="server"></md:MDTextBox>
								</td>
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
				<!-- button -->
				<div id="str-btn-area" class="str-btn-utility">
					<ul>
						<!--明細制御系ボタンを配置する場合はこのulタグの中-->
						<!--- 「行追加ボタン」ボタン --->
						<li><span id="Spanrowins" runat="server"><label><input type="button" id="Btnrowins" value="" onserverclick="OnBTNROWINS_MADD" runat="server" class="icon-utility-06"/>行追加</label></span></li>
						<!--- 「ページ追加ボタン」ボタン --->
						<li><span id="Spanpageins" runat="server"><label><input type="button" id="Btnpageins" value="" onserverclick="OnBTNPAGEINS_MINSX" runat="server" class="icon-utility-06"/>ページ追加</label></span></li>
						<!--- 「行削除ボタン」ボタン --->
						<li><span id="Spanrowdel" runat="server"><label><input type="button" id="Btnrowdel" value="" onserverclick="OnBTNROWDEL_FRM" runat="server" class="icon-utility-03"/>行削除</label></span></li>
						<!--- 「CSV取込ボタン」ボタン --->
						<li><span id="Spancsv_torikomi" runat="server"><label><input type="button" id="Btncsv_torikomi" value="" onserverclick="OnBTNCSV_TORIKOMI_FRM" runat="server" class="icon-utility-05"/>CSV取込</label></span></li>
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
						<p><adv:PageInfo ID="M1PageInfo" runat="server"></adv:PageInfo></p>
						<!--- ページャーを配置する場合はこの中 --->
						<!--- 「ページャ」カスタムページャー --->
						<cc:custompager ID="Pgr" OnPageIndexChanged="OnPGR_PGN" runat="server"></cc:custompager>
					<!-- /str-pager-01 --></div>

					<!--一覧-->
					<div class="str-result-01">
						<%-- 明細ヘッダ --%>
						<!------------------------------------------
						  □一覧ヘッダ領域
						-------------------------------------------->
						<div class="str-result-hdg-01">
							<div class="col1 col_3dan"><asp:Label ID="M1rowno_lbl" runat="server">No.</asp:Label></div>
							<div class="col2">
								<div class="col2-1 headcell"><asp:Label ID="M1hassei_tm_lbl" runat="server">時間</asp:Label></div>
								<div class="col2-2 headcell cell_line_btm_h cell_line_left_h"><asp:Label ID="M1hasseibasyo_lbl" runat="server">発生場所</asp:Label></div>
								<div class="col2-3 headcell cell_line_btm_h"><asp:Label ID="M1bumon_cd_lbl" runat="server">部門</asp:Label></div>
								<div class="col2-4 headcell "><asp:Label ID="M1hinsyu_ryaku_nm_lbl" runat="server">品種</asp:Label></div>
							</div>
							<div class="col3">
								<div class="col3-1 headcell"><asp:Label ID="M1hakkentan_cd_lbl" runat="server">発見者</asp:Label></div>
								<div class="col3-2 headcell cell_line_btm_h"><asp:Label ID="M1burando_nm_lbl" runat="server">ブランド</asp:Label></div>
								<div class="col3-3 headcell"><asp:Label ID="M1jisya_hbn_lbl" runat="server">自社品番</asp:Label></div>
							</div>
							<div class="col4">
								<div class="col4-1 headcell"><asp:Label ID="M1hakkenjyokyo_kb_lbl" runat="server">発見状況</asp:Label></div>
								<div class="col4-99 headcell">
									<div class="col4-2 cell_line_btm_h"><asp:Label ID="M1maker_hbn_lbl" runat="server">メーカー品番</asp:Label></div>
									<div class="col4-9"><asp:Label ID="M1syonmk_lbl" runat="server">商品名</asp:Label></div>
								</div>
								<div class="col4-98 cell_line_left_h headcell">
									<div class="col4-3 headcell cell_line_btm_h"><asp:Label ID="M1iro_nm_lbl" runat="server">色</asp:Label></div>
									<div class="col4-10 headcell"><asp:Label ID="M1size_nm_lbl" runat="server">サイズ</asp:Label></div>
								</div>
								<div class="col4-4 col_2dan cell_line_left_h headcell"><asp:Label ID="M1scan_cd_lbl" runat="server">スキャンコード</asp:Label></div>
								<div class="col4-5 col_2dan cell_line_left_h headcell"><asp:Label ID="M1sinsei_su_lbl" runat="server">申請数</asp:Label></div>
								<div class="col4-6 col_2dan cell_line_left_h headcell"><asp:Label ID="M1jyuri_su_lbl" runat="server">受理数</asp:Label></div>
								<div class="col4-7 col_2dan cell_line_left_h headcell"><asp:Label ID="M1baika_hon_lbl" runat="server">売価</asp:Label></div>
								<div class="col4-8 col_2dan cell_line_left_h headcell"><asp:Label ID="M1baika_kin_lbl" runat="server">売価金額</asp:Label></div>
							</div>
							<!-- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ -->
							<div style="display:none">
								<asp:Label ID="M1bumonkana_nm_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1btntanto_cd_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1hakkentan_nm_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1hakkenjyokyo_nm_lbl" runat="server">発見状況</asp:Label>
								<asp:Label ID="M1sinsei_su_hdn_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1jyuri_su_hdn_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1baika_kin_hdn_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1selectorcheckbox_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1entersyoriflg_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1dtlirokbn_lbl" runat="server"></asp:Label>
							</div>
							<!-- 隠し項目エリア↑↑↑↑↑↑↑↑↑↑↑↑↑ -->
						<!-- /str-hdg-result --></div>

						<!------------------------------------------
						  □一覧明細領域
						-------------------------------------------->
						<div id="str-result-item-wrap" class="adjust-elem">
							<asp:Repeater ID="M1" runat="server">
								<HeaderTemplate>
								</HeaderTemplate>
								<ItemTemplate>
									<div id="M1Row" class="str-result-item-01" runat="server">
										<div class="col1 col_3dan detail_right">
											<!--- 「ｍ１行no」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1rowno" CssClass="inpReadonlyRight inpRONum4 detail_right_lv1" runat="server"></asp:TextBox>
										</div>
										<div class="col2 detail_center">
											<div class="col2-1 detail_center">
												<!--- 「ｍ１発生時間」一行テキストボックス（セパレート日付以外） --->
												<md:MDTextBox ID="M1hassei_tm" CssClass="inpSu-02 detail_center_l_lv2 detail_center_r_lv1" runat="server"></md:MDTextBox>
											</div>
											<div class="col2-2 detail_center cell_line_btm cell_line_left">
												<!--- 「ｍ１発生場所」一行テキストボックス（セパレート日付以外） --->
												<md:MDTextBox ID="M1hasseibasyo" CssClass="inpHasseiBasho detail_center_l_lv1 detail_center_r_lv2" runat="server"></md:MDTextBox>
											</div>
											<div class="col2-3 detail_left cell_line_btm">
												<!--- 「ｍ１部門コード」テキストボックスリードオンリー --->
												<!--- 「ｍ１部門カナ名」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1bumon_cd" CssClass="inpReadonlyLeft inpRONum3 detail_left_lv2" runat="server"></asp:TextBox>&nbsp;<asp:TextBox ID="M1bumonkana_nm" CssClass="inpReadonlyLeft inpROHankaku12 tooltip" runat="server"></asp:TextBox>
											</div>
											<div class="col2-4 detail_left">
												<!--- 「ｍ１品種略名称」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1hinsyu_ryaku_nm" CssClass="inpReadonlyLeft tooltip detail_left_lv2" runat="server"></asp:TextBox>
											</div>
										</div>
										<div class="col3 detail_center">
											<div class="col3-1 detail_center">
												<!--- 「ｍ１発見担当者コード」一行テキストボックス（セパレート日付以外） --->
												<!--- 「Ｍ１担当者コードボタン」ボタン --->
												<!--- 「ｍ１発見担当者名称」テキストボックスリードオンリー --->
												<span class="icon-in"><md:MDTextBox ID="M1hakkentan_cd" CssClass="inpSerchDtl inpTanto detail_center_l_lv2" runat="server"></md:MDTextBox><input type="button" id="M1btntanto_cd" name="M1btntanto_cd" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="M1hakkentan_nm" CssClass="inpReadonlyLeft inpROZenkaku10 tooltip detail_center_r_lv2" runat="server"></asp:TextBox>
											</div>
											<div class="col3-2 detail_left cell_line_btm">
												<!--- 「ｍ１ブランド名」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1burando_nm" CssClass="inpReadonlyLeft inpROHankaku12 tooltip detail_left_lv2" runat="server"></asp:TextBox>
											</div>
											<div class="col3-3 detail_center cell">
												<!--- 「ｍ１自社品番」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1jisya_hbn" CssClass="inpReadonlyLeft inpRONum8 detail_center_l_lv2 detail_center_r_lv2" runat="server"></asp:TextBox>
											</div>
										</div>
										<div class="col4 detail_center">
											<div class="col4-1 detail_left">
												<!--- 「ｍ１発見状況区分」ドロップダウンリスト --->
												<md:MDConditionDDList ID="M1hakkenjyokyo_kb" ConditionName="hakkenjyokyo_kb" CssClass="slt-ddl slt-hakkenJokyo detail_left_lv2" runat="server"></md:MDConditionDDList>
												<span class="select-arrow"></span>
												<!--- 「ｍ１発見状況」一行テキストボックス（セパレート日付以外） --->
												<md:MDTextBox ID="M1hakkenjyokyo_nm" CssClass="inpHakkenJokyo" runat="server"></md:MDTextBox>
											</div>
											<div class="col4-99 detail_center">
												<div class="col4-2 cell_line_btm detail_left">
													<!--- 「ｍ１メーカー品番」テキストボックスリードオンリー --->
													<asp:TextBox ID="M1maker_hbn" CssClass="inpReadonlyLeft inpROHankaku20 tooltip detail_left_lv2" runat="server"></asp:TextBox>
												</div>
												<div class="col4-9 cell detail_left">
													<!--- 「ｍ１商品名(カナ)」テキストボックスリードオンリー --->
													<asp:TextBox ID="M1syonmk" CssClass="inpReadonlyLeft inpROHankaku20 tooltip detail_left_lv2" runat="server"></asp:TextBox>
												</div>
											</div>
											<div class="col4-98 detail_center">
												<div class="col4-3 cell_line_btm cell_line_left detail_left">
													<!--- 「ｍ１色」テキストボックスリードオンリー --->
													<asp:TextBox ID="M1iro_nm" CssClass="inpReadonlyLeft inpROHankaku6 tooltip detail_left_lv1" runat="server"></asp:TextBox>
												</div>
												<div class="col4-10 cell cell_line_left detail_left">
													<!--- 「ｍ１サイズ」テキストボックスリードオンリー --->
													<asp:TextBox ID="M1size_nm" CssClass="inpReadonlyLeft inpROHankaku4 tooltip detail_left_lv1" runat="server"></asp:TextBox>
												</div>
											</div>
											<div class="col4-97 detail_left col_2dan cell_line_left">
												<div class="col4-4 cell detail_center">
													<!--- 「ｍ１スキャンコード」一行テキストボックス（セパレート日付以外） --->
													<md:MDTextBox ID="M1scan_cd" CssClass="inpScan detail_center_l_lv1 detail_center_r_lv1 detail_middle" runat="server"></md:MDTextBox>
												</div>
											</div>
											<div class="col4-96 detail_left col_2dan cell_line_left">
												<div class="col4-5 cell detail_center">
													<!--- 「ｍ１申請数」一行テキストボックス（セパレート日付以外） --->
													<md:MDTextBox ID="M1sinsei_su" CssClass="inpSu-03 detail_center_l_lv1 detail_center_r_lv1 detail_middle" runat="server"></md:MDTextBox>
												</div>
											</div>
											<div class="col4-95 detail_left col_2dan cell_line_left">
												<div class="col4-6 cell detail_center">
													<!--- 「ｍ１受理数」一行テキストボックス（セパレート日付以外） --->
													<md:MDTextBox ID="M1jyuri_su" CssClass="inpSu-03 detail_center_l_lv1 detail_center_r_lv1 detail_middle" runat="server"></md:MDTextBox>
												</div>
											</div>
											<div class="col4-94 detail_left col_2dan cell_line_left">
												<div class="col4-7 cell detail_right">
													<!--- 「ｍ１売価（本体）」テキストボックスリードオンリー --->
													<asp:TextBox ID="M1baika_hon" CssClass="inpReadonlyRight inpRONumCma8 detail_right_lv1 detail_middle" runat="server"></asp:TextBox>
												</div>
											</div>
											<div class="col4-93 detail_left col_2dan cell_line_left">
												<div class="col4-8 detail_right">
													<!--- 「ｍ１売価金額」テキストボックスリードオンリー --->
													<asp:TextBox ID="M1baika_kin" CssClass="inpReadonlyRight inpRONumCma8 detail_right_lv2 detail_middle" runat="server"></asp:TextBox>
												</div>
											</div>
										</div>

										<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
										<div style="display: none">
											<div class="col23">
												<!--- 「Ｍ１申請数（隠し）」隠しフィールド --->
												<asp:hiddenfield ID="M1sinsei_su_hdn" runat="server"></asp:hiddenfield>
											</div>
											<div class="col24">
												<!--- 「Ｍ１受理数（隠し）」隠しフィールド --->
												<asp:hiddenfield ID="M1jyuri_su_hdn" runat="server"></asp:hiddenfield>
											</div>
											<div class="col25">
												<!--- 「Ｍ１売価金額（隠し）」隠しフィールド --->
												<asp:hiddenfield ID="M1baika_kin_hdn" runat="server"></asp:hiddenfield>
											</div>
											<div class="col26">
												<!--- 「ｍ１選択フラグ(隠し)」チェックボックス --->
												<adv:AdvancedCheckBox ID="M1selectorcheckbox" Text="" CssClass="" runat="server"></adv:AdvancedCheckBox>
											</div>
											<div class="col27">
												<!--- 「Ｍ１確定処理フラグ(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1entersyoriflg" runat="server"></asp:hiddenfield>
											</div>
											<div class="col28">
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
							<div class="col1 detail_ftr_title">&nbsp;</div>
							<div class="col2 detail_ftr_title">&nbsp;</div>
							<div class="col3 detail_ftr_title">&nbsp;</div>
							<div class="col4-2 detail_ftr_title">&nbsp;</div>
							<div class="col4-3 detail_ftr_title">&nbsp;</div>
							<div class="col4-4 detail_ftr_title">
								<asp:Label ID="Gokeisinsei_su_lbl" runat="server" CssClass="detail_right_lv1">合計</asp:Label>
							</div>
							<div class="col4-5 detail_ftr">
								<!--- 「合計申請数」テキストボックスリードオンリー --->
								<asp:TextBox ID="Gokeisinsei_su" CssClass="inpDetail inpReadonlyRight inpRONumCma4 detail_right_lv1" runat="server"></asp:TextBox>
							</div>
							<div class="col4-6 detail_ftr">
								<!--- 「合計受理数」テキストボックスリードオンリー --->
								<asp:TextBox ID="Gokeijyuri_su" CssClass="inpDetail inpReadonlyRight inpRONumCma4 detail_right_lv1" runat="server"></asp:TextBox>
							</div>
							<div class="col4-7 detail_ftr_title">&nbsp;</div>
							<div class="col4-8 detail_ftr">
								<!--- 「合計売価金額」テキストボックスリードオンリー --->
								<asp:TextBox ID="Gokeibaika_kin" CssClass="inpDetail inpReadonlyRight inpRONumCma8 detail_right_lv1" runat="server"></asp:TextBox>
							</div>
						<!-- /str-result-ftr-01 --></div>

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

			<!--- 「選択モードNO」隠しフィールド --->
			<asp:hiddenfield ID="Stkmodeno" runat="server"></asp:hiddenfield>

			<asp:Label ID="Head_tenpo_cd_lbl" runat="server"></asp:Label>
			<asp:Label ID="Head_tenpo_nm_lbl" runat="server"></asp:Label>

			<asp:Label ID="Hokokutan_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Tentyotan_nm_lbl" runat="server"></asp:Label>

			<asp:Label ID="Gokeijyuri_su_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokeibaika_kin_lbl" runat="server"></asp:Label>
		</div>
	
	</form>
</body>
</html>

