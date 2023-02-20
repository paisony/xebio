<%@ Page language="c#" CodeFile="tf010f02.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Tf010p01.Page.Tf010f02Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">商品経費振替確定</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="tf010p01" FormId="tf010f02" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/tf010f02.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="tf010p01" FormId="tf010f02" runat="server" />

	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02004.js" charset="UTF-8"></script><!-- 発注マスタ取得(スキャンコード) -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02021.js" charset="UTF-8"></script><!-- 科目マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02025.js" charset="UTF-8"></script><!-- 振替申請理由から科目取得 -->

	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05002.js" charset="UTF-8"></script><!-- スキャンコード丸め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05003.js" charset="UTF-8"></script><!-- 明細背景色変更処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05010.js" charset="UTF-8"></script><!-- カンマ編集処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script><!-- 0埋め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05010.js" charset="UTF-8"></script><!--カンマ編集処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05014.js" charset="UTF-8"></script><!-- 名称取得拡張 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05024.js" charset="UTF-8"></script><!-- 数値編集関数群 -->
</head>

<body>
	<form id="Tf010f02" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="tf010p01" PgName="商品経費振替確定" FormId="tf010f02" FormName="商品経費振替確定 明細" ></uc:Header>
			
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
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Apply_ymd_lbl" runat="server">申請日</asp:Label></span></th>
								<!--- 「申請日」テキストボックスリードオンリー --->
								<td class="last"><asp:TextBox ID="Apply_ymd" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox></td>
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Shinsei_tenpo_cd_lbl" runat="server">申請店舗</asp:Label></span></th>
								<!--- 「申請店舗コード」テキストボックスリードオンリー --->
								<!--- 「申請店舗名」テキストボックスリードオンリー --->
								<td class="last"><asp:TextBox ID="Shinsei_tenpo_cd" CssClass="inpReadonlyLeft inpRONum4" runat="server"></asp:TextBox><asp:TextBox ID="Shinsei_tenpo_nm" CssClass="inpReadonlyLeft inpROZenkaku10 inpRORightNm" runat="server"></asp:TextBox></td>
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Sinseitan_cd_lbl" runat="server">申請担当者</asp:Label></span></th>
								<!--- 「申請担当者コード」テキストボックスリードオンリー --->
								<!--- 「申請担当者名称」テキストボックスリードオンリー --->
								<td class="last"><asp:TextBox ID="Sinseitan_cd" CssClass="inpReadonlyLeft inpRONum7" runat="server"></asp:TextBox><asp:TextBox ID="Sinseitan_nm" CssClass="inpReadonlyLeft inpROZenkaku10 inpRORightNm" runat="server"></asp:TextBox></td>
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Denpyo_bango_lbl" runat="server">伝票番号</asp:Label></span></th>
								<!--- 「伝票番号」テキストボックスリードオンリー --->
								<td class="last"><asp:TextBox ID="Denpyo_bango" CssClass="inpReadonlyLeft inpRONum6" runat="server"></asp:TextBox></td>
							</tr>
							<tr>
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Sinseiriyu_kb_lbl" runat="server">申請理由</asp:Label></span></th>
								<!--- 「申請理由区分」ドロップダウンリスト --->
								<!--- 「申請理由」一行テキストボックス（セパレート日付以外） --->
								<td class="last" colspan="3" style="white-space:nowrap;">
									<md:MDCodeCondition ID="Sinseiriyu_kb" FormID="Tf010f02" PgID="Tf010p01" CssClass="slt-sinseiRiyu" runat="server"></md:MDCodeCondition>
									<span class="select-arrow"></span>
									<md:MDTextBox ID="Sinseiriyu" CssClass="inpRiyu" runat="server"></md:MDTextBox>
								</td>
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Kakuteitan_cd_lbl" runat="server">確定担当者</asp:Label></span></th>
								<!--- 「確定担当者コード」テキストボックスリードオンリー --->
								<!--- 「確定担当者名称」テキストボックスリードオンリー --->
								<td class="last"><asp:TextBox ID="Kakuteitan_cd" CssClass="inpReadonlyLeft inpRONum7" runat="server"></asp:TextBox><asp:TextBox ID="Kakuteitan_nm" CssClass="inpReadonlyLeft inpROZenkaku10 inpRORightNm" runat="server"></asp:TextBox></td>
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Kakutei_ymd_lbl" runat="server">確定日</asp:Label></span></th>
								<!--- 「確定日」テキストボックスリードオンリー --->
								<td class="last"><asp:TextBox ID="Kakutei_ymd" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox></td>
							</tr>
							<tr>
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Kamoku_cd_lbl" runat="server">科目</asp:Label><asp:Label ID="Kamoku_cd_Req" runat="server" CssClass="required">*</asp:Label></span></th>
								<!--- 「科目コード」一行テキストボックス（セパレート日付以外） --->
								<!--- 「科目コードボタン」ボタン --->
								<!--- 「科目名」テキストボックスリードオンリー --->
								<td class="last" colspan="3"><span class="icon-in"><md:MDTextBox ID="Kamoku_cd" CssClass="inpSerch inpKamoku" runat="server"></md:MDTextBox><input type="button" id="Btnkamokucd" name="Btnkamokucd" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="Kamoku_nm" CssClass="inpReadonlyLeft inpROZenkaku20" runat="server"></asp:TextBox></td>
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Kyakkariyu_lbl" runat="server">却下理由</asp:Label></span></th>
								<!--- 「却下理由」一行テキストボックス（セパレート日付以外） --->
								<td class="last"><md:MDTextBox ID="Kyakkariyu" CssClass="inpRiyu" runat="server"></md:MDTextBox></td>
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Gyomuringi_no_lbl" runat="server">業務稟議No</asp:Label></span></th>
								<!--- 「業務稟議no」一行テキストボックス（セパレート日付以外） --->
								<td class="last"><md:MDTextBox ID="Gyomuringi_no" CssClass="inpRingiNo" runat="server"></md:MDTextBox></td>
							</tr>
							<tr>
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Jyuri_no_lbl" runat="server">受理番号</asp:Label></span></th>
								<!--- 「受理番号」テキストボックスリードオンリー --->
								<td class="last"><asp:TextBox ID="Jyuri_no" CssClass="inpReadonlyLeft inpROHankaku10" runat="server"></asp:TextBox></td>
								<th class="last"><span class="tbl-hdg"><asp:Label ID="Syonin_flg_nm_lbl" runat="server">承認状態</asp:Label></span></th>
								<!--- 「承認状態名称」テキストボックスリードオンリー --->
								<td class="last" colspan="7"><asp:TextBox ID="Syonin_flg_nm" CssClass="inpReadonlyLeft inpROZenkaku3" runat="server"></asp:TextBox></td>
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
						<li><span><label><input type="button" id="Btnrowins" value="" onserverclick="OnBTNROWINS_MADD" runat="server" class="icon-utility-06"/>行追加</label></span></li>
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
						<!-- <p><adv:PageInfo ID="M1PageInfo" runat="server"></adv:PageInfo></p> --->
						<!--- ページャーを配置する場合はこの中 --->
		
					<!-- /str-pager-01 --></div>

					<!------------------------------------------
					  □一覧領域
					-------------------------------------------->
					<div class="str-result-01">
						<!------------------------------------------
						  □一覧ヘッダ領域
						-------------------------------------------->
						<div class="str-result-hdg-01">
							<div class="col1 col_2dan"><asp:Label ID="M1rowno_lbl" runat="server">No.</asp:Label></div>
							<div class="col2">
								<div><asp:Label ID="M1bumon_cd_lbl" runat="server">部門</asp:Label></div>
								<div><asp:Label ID="M1hinsyu_ryaku_nm_lbl" runat="server">品種</asp:Label></div>
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
								<div><asp:Label ID="M1iro_nm_lbl" runat="server">色</asp:Label></div>
								<div><asp:Label ID="M1size_nm_lbl" runat="server">サイズ</asp:Label></div>
							</div>
							<div class="col6 col_2dan"><asp:Label ID="M1scan_cd_lbl" runat="server">スキャンコード</asp:Label></div>
							<div class="col7 col_2dan"><asp:Label ID="M1suryo_lbl" runat="server">数量</asp:Label></div>
							<div class="col8">
								<div><asp:Label ID="M1gen_tnk_lbl" runat="server">原単価</asp:Label></div>
								<div><asp:Label ID="M1genbaika_tnk_lbl" runat="server">現売価</asp:Label></div>
							</div>
							<div class="col9">
								<div><asp:Label ID="M1genka_kin_lbl" runat="server">原価金額</asp:Label></div>
								<div><asp:Label ID="M1baika_kin_lbl" runat="server">売価金額</asp:Label></div>
							</div>
							<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
							<div style="display:none">
								<div class="col3">
									<asp:Label ID="M1bumonkana_nm_lbl" runat="server"></asp:Label>
								</div>
								<div class="col17">
									<asp:Label ID="M1suryo_hdn_lbl" runat="server"></asp:Label>
								</div>
								<div class="col18">
									<asp:Label ID="M1genka_kin_hdn_lbl" runat="server"></asp:Label>
								</div>
								<div class="col19">
									<asp:Label ID="M1baika_kin_hdn_lbl" runat="server"></asp:Label>
								</div>
								<div class="col20">
									<asp:Label ID="M1selectorcheckbox_lbl" runat="server"></asp:Label>
								</div>
								<div class="col21">
									<asp:Label ID="M1entersyoriflg_lbl" runat="server"></asp:Label>
								</div>
								<div class="col22">
									<asp:Label ID="M1dtlirokbn_lbl" runat="server"></asp:Label>
								</div>
							</div>
							<!--- 隠し項目エリア↑↑↑↑↑↑↑↑↑↑↑↑↑ --->
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
										<!--- 「ｍ１行no」テキストボックスリードオンリー --->
										<div class="col1 col_2dan detail_right"><asp:TextBox ID="M1rowno" CssClass="inpReadonlyRight inpRONum2" runat="server"></asp:TextBox></div>
										<!--- 「ｍ１部門コード」テキストボックスリードオンリー --->
										<!--- 「ｍ１部門カナ名」テキストボックスリードオンリー --->
										<!--- 「ｍ１品種略名称」テキストボックスリードオンリー --->
										<div class="col2 detail_left">
											<div><asp:TextBox ID="M1bumon_cd" CssClass="inpReadonlyRight inpRONum3" runat="server"></asp:TextBox><asp:TextBox ID="M1bumonkana_nm" CssClass="inpReadonlyLeft inpRORightNm inpROHankaku12 tooltip" runat="server"></asp:TextBox></div>
											<div><asp:TextBox ID="M1hinsyu_ryaku_nm" CssClass="inpReadonlyLeft inpROZenkaku10 tooltip" runat="server"></asp:TextBox></div>
										</div>
										<!--- 「ｍ１ブランド名」テキストボックスリードオンリー --->
										<!--- 「ｍ１自社品番」テキストボックスリードオンリー --->
										<div class="col3 detail_left">
											<div><asp:TextBox ID="M1burando_nm" CssClass="inpReadonlyLeft inpROHankaku16 tooltip" runat="server"></asp:TextBox></div>
											<div class="detail_center"><asp:TextBox ID="M1jisya_hbn" CssClass="inpReadonlyRight inpRONum8" runat="server"></asp:TextBox></div>
										</div>
										<!--- 「ｍ１メーカー品番」テキストボックスリードオンリー --->
										<!--- 「ｍ１商品名(カナ)」テキストボックスリードオンリー --->
										<div class="col4 detail_left">
											<div><asp:TextBox ID="M1maker_hbn" CssClass="inpReadonlyLeft inpROHankaku30 tooltip" runat="server"></asp:TextBox></div>
											<div><asp:TextBox ID="M1syonmk" CssClass="inpReadonlyLeft inpROHankaku20 tooltip" runat="server"></asp:TextBox></div>
										</div>
										<!--- 「ｍ１色」テキストボックスリードオンリー --->
										<!--- 「ｍ１サイズ」テキストボックスリードオンリー --->
										<div class="col5 detail_left">
											<div><asp:TextBox ID="M1iro_nm" CssClass="inpReadonlyLeft inpROHankaku6 tooltip" runat="server"></asp:TextBox></div>
											<div><asp:TextBox ID="M1size_nm" CssClass="inpReadonlyLeft inpROHankaku4 tooltip" runat="server"></asp:TextBox></div>
										</div>
										<!--- 「ｍ１スキャンコード」一行テキストボックス（セパレート日付以外） --->
										<div class="col6 col_2dan detail_center"><md:MDTextBox ID="M1scan_cd" CssClass="inpScan" runat="server"></md:MDTextBox></div>
										<!--- 「ｍ１数量」一行テキストボックス（セパレート日付以外） --->
										<div class="col7 col_2dan detail_center"><md:MDTextBox ID="M1suryo" CssClass="inpSu-03" runat="server"></md:MDTextBox></div>
										<!--- 「ｍ１原単価」テキストボックスリードオンリー --->
										<!--- 「ｍ１現売価」テキストボックスリードオンリー --->
										<div class="col8 detail_right">
											<div><asp:TextBox ID="M1gen_tnk" CssClass="inpReadonlyRight inpRONumCma9" runat="server"></asp:TextBox></div>
											<div><asp:TextBox ID="M1genbaika_tnk" CssClass="inpReadonlyRight inpRONumCma9" runat="server"></asp:TextBox></div>
										</div>
										<!--- 「ｍ１原価金額」テキストボックスリードオンリー --->
										<!--- 「ｍ１売価金額」テキストボックスリードオンリー --->
										<div class="col9 detail_right">
											<div><asp:TextBox ID="M1genka_kin" CssClass="inpReadonlyRight inpRONumCmaMinus12" runat="server"></asp:TextBox></div>
											<div><asp:TextBox ID="M1baika_kin" CssClass="inpReadonlyRight inpRONumCmaMinus12" runat="server"></asp:TextBox></div>
										</div>
										<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
										<div style="display: none">
											<div class="col17">
												<!--- 「Ｍ１数量（隠し）」隠しフィールド --->
												<asp:hiddenfield ID="M1suryo_hdn" runat="server"></asp:hiddenfield>
											</div>
											<div class="col18">
												<!--- 「Ｍ１原価金額（隠し）」隠しフィールド --->
												<asp:hiddenfield ID="M1genka_kin_hdn" runat="server"></asp:hiddenfield>
											</div>
											<div class="col19">
												<!--- 「Ｍ１売価金額（隠し）」隠しフィールド --->
												<asp:hiddenfield ID="M1baika_kin_hdn" runat="server"></asp:hiddenfield>
											</div>
											<div class="col20">
												<!--- 「ｍ１選択フラグ(隠し)」チェックボックス --->
												<adv:AdvancedCheckBox ID="M1selectorcheckbox" Text="" CssClass="" runat="server"></adv:AdvancedCheckBox>
											</div>
											<div class="col21">
												<!--- 「Ｍ１確定処理フラグ(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1entersyoriflg" runat="server"></asp:hiddenfield>
											</div>
											<div class="col22">
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
							<div class="col4 detail_left">&nbsp;</div>
							<div class="col5 detail_left">&nbsp;</div>
							<div class="col6 detail_ftr_title"><asp:Label ID="Gokei_suryo_lbl" runat="server">合計</asp:Label></div>
							<!--- 「合計数量」テキストボックスリードオンリー --->
							<div class="col7 detail_ftr"><span><asp:TextBox ID="Gokei_suryo" CssClass="inpReadonlyRight inpRONumCma4" runat="server"></asp:TextBox></span></div>
							<div class="col8 detail_ftr_title"><asp:Label ID="Genka_kin_gokei1_lbl" runat="server">原価合計</asp:Label></div>
							<!--- 「合計原価金額」テキストボックスリードオンリー --->
							<div class="col9 detail_ftr"><span><asp:TextBox ID="Genka_kin_gokei1" CssClass="inpReadonlyRight inpRONumCmaMinus12" runat="server"></asp:TextBox></span></div>
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
			<asp:Label ID="Head_tenpo_cd_lbl" runat="server"></asp:Label>
			<asp:Label ID="Head_tenpo_nm_lbl" runat="server"></asp:Label>
			
			<!--- 「選択モードNO」隠しフィールド --->
			<asp:hiddenfield ID="Stkmodeno" runat="server"></asp:hiddenfield>
				
			<asp:Label ID="Shinsei_tenpo_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Sinseitan_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Sinseiriyu_lbl" runat="server">申請理由</asp:Label>
			<asp:Label ID="Kakuteitan_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Kamoku_nm_lbl" runat="server"></asp:Label>
		</div>
	</form>
</body>
</html>

