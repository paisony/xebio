<%@ Page language="c#" CodeFile="ta020f02.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Ta020p01.Page.Ta020f02Page" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">出荷要望入力</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="ta020p01" FormId="ta020f02" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/ta020f02.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="ta020p01" FormId="ta020f02" runat="server" />

	<!-- Js業務部品のインポート --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02004.js" charset="UTF-8"></script><!-- スキャンコードチェック処理 -->

	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05002.js" charset="UTF-8"></script><!-- スキャンコード丸め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05003.js" charset="UTF-8"></script><!-- 明細背景色変更処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script><!-- 0埋め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05010.js" charset="UTF-8"></script><!-- カンマ編集処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05014.js" charset="UTF-8"></script><!-- 名称取得拡張 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05019.js" charset="UTF-8"></script><!-- 情報ダイアログ表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05024.js" charset="UTF-8"></script><!-- 数値編集関数群 -->

	<!-- 業務共通コントロールのインポート-->
	<%@ Register TagPrefix="uc" TagName="common" Src="~/pjcommon/businessCommon/usercontrol/boCommonControl.ascx" %>
</head>

<body>
	<form id="Ta020f02" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="ta020p01" PgName="出荷要望入力" FormId="ta020f02" FormName="出荷要望入力 明細" ></uc:Header>

			
			<!------------------------------------------	
				□業務共通コントロール
			------------------------------------------->	
			<uc:common ID="bocommon" runat="server"></uc:common>	

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
								<!--- 「依頼日」 --->
								<!--- 「依頼日」テキストボックスリードオンリー --->
								<th><span class="tbl-hdg"><asp:Label ID="Irai_ymd_lbl" runat="server">依頼日</asp:Label></span></th>
								<td>
									<asp:TextBox ID="Irai_ymd" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox>
								</td>
								<!--- 「担当者」 --->
								<!--- 「担当者コード」テキストボックスリードオンリー --->
								<!--- 「担当者名」テキストボックスリードオンリー --->
								<th><span class="tbl-hdg"><asp:Label ID="Tantosya_cd_lbl" runat="server">担当者</asp:Label></span></th>
								<td>
									<asp:TextBox ID="Tantosya_cd" CssClass="inpReadonlyLeft inpRONum7" runat="server"></asp:TextBox>
									<asp:TextBox ID="Hanbaiin_nm" CssClass="inpReadonlyLeft inpROZenkaku10 inpRORightNm" runat="server"></asp:TextBox>
								</td>
								<!--- 「依頼理由コード」 --->
											<!--- 「依頼理由コード」ドロップダウンリスト --->
								<th><span class="tbl-hdg"><asp:Label ID="Irairiyu_cd_lbl" runat="server">依頼理由</asp:Label></span></th>
								<td>
									<md:MDCodeCondition ID="Irairiyu_cd" FormID="Ta020f02" PgID="Ta020p01" CssClass="slt-ddl slt-riyu" runat="server"></md:MDCodeCondition>
									<span class="select-arrow"></span>
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
				<!------------------------------------------
					□明細ボタン部
				-------------------------------------------->
				<!-- button -->
				<div id="str-btn-area" class="str-btn-utility">
					<ul>
						<!--明細制御系ボタンを配置する場合はこのulタグの中-->
						<!--- 「全選択ボタン」ボタン --->
						<li><span><label><input type="button" id="Btnzenstk" value="" onserverclick="OnBTNZENSTK_FRM" runat="server" class="icon-utility-01"/>全選択</label></span></li>
						<!--- 「全解除ボタン」ボタン --->
						<li><span><label><input type="button" id="Btnzenkjo" value="" onserverclick="OnBTNZENKJO_FRM" runat="server" class="icon-utility-02"/>全解除</label></span></li>
						<!--- 「行追加ボタン」ボタン --->
						<li><span id="Spanrowins" runat="server"><label><input type="button" id="Btnrowins" value="" onserverclick="OnBTNROWINS_MADD" runat="server" class="icon-utility-06"/>行追加</label></span></li>
						<!--- 「ページ追加ボタン」ボタン --->
						<li><span id="Spanpageins" runat="server"><label><input type="button" id="Btnpageins" value="" onserverclick="OnBTNPAGEINS_MINSX" runat="server" class="icon-utility-06"/>ページ追加</label></span></li>
						<!--- 「サイズ選択ボタン」ボタン --->
						<li><span><label><input type="button" id="Btnsizstk" name="Btnsizstk" value="" onserverclick="OnBTNSIZSTK_FRM" runat="server" class="icon-utility-07"/>サイズ選択</label></span></li>
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
								<div><asp:Label ID="M1bumonkana_nm_lbl" runat="server">部門</asp:Label></div>
								<div class="col2-1 headcell"><asp:Label ID="M1hyoka_kb_lbl" runat="server">評価</asp:Label></div>
								<div class="col2-2 headcell"><asp:Label ID="M1kahi_nm_lbl" runat="server">補充</asp:Label></div>
								<div class="col2-3 headcell"><asp:Label ID="M1tenzaiko_su_lbl" runat="server">在庫</asp:Label></div>
							</div>
							<div class="col3">
								<div><asp:Label ID="M1hinsyu_ryaku_nm_lbl" runat="server">品種</asp:Label></div>
								<div class="col3-1 headcell"><asp:Label ID="M1nyukayotei_su_lbl" runat="server">入荷</asp:Label></div>
								<div class="col3-2 headcell"><asp:Label ID="M1uriage_su_lbl" runat="server">売上</asp:Label></div>
							</div>
							<div class="col4">
								<div><asp:Label ID="M1burando_nm_lbl" runat="server">ブランド</asp:Label></div>
								<div><asp:Label ID="M1jido_su_lbl" runat="server">自動定数</asp:Label></div>
							</div>
							<div class="col5">
								<div><asp:Label ID="M1jisya_hbn_lbl" runat="server">自社品番</asp:Label></div>
								<div><asp:Label ID="M1syohin_zokusei_lbl" runat="server">コア</asp:Label></div>
							</div>
							<div class="col6">
								<div><asp:Label ID="M1iro_nm_lbl" runat="server">色</asp:Label></div>
								<div><asp:Label ID="M1size_nm_lbl" runat="server">サイズ</asp:Label></div>
							</div>
							<div class="col7">
								<div><asp:Label ID="M1maker_hbn_lbl" runat="server">メーカー品番</asp:Label></div>
								<div><asp:Label ID="M1syonmk_lbl" runat="server">商品名</asp:Label></div>
							</div>
							<div class="col8">
								<div><asp:Label ID="M1hatchu_msg_lbl" runat="server">メッセージ</asp:Label></div>
								<div><asp:Label ID="M1irai_su_lbl" runat="server">依頼数</asp:Label></div>
							</div>
							<div class="col9">
								<div><asp:Label ID="M1scan_cd_lbl" runat="server">スキャンコード</asp:Label></div>
								<div><asp:Label ID="M1genkakin_lbl" runat="server">原価金額</asp:Label></div>
							</div>
							<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
							<div style="display:none">
								<div class="col11">
									<asp:Label ID="M1irai_su_hdn_lbl" runat="server"></asp:Label>
									<asp:Label ID="M1gen_tnk_lbl" runat="server"></asp:Label>
									<asp:Label ID="M1genkakin_hdn_lbl" runat="server"></asp:Label>
									<asp:Label ID="M1selectorcheckbox_lbl" runat="server"></asp:Label>
									<asp:Label ID="M1entersyoriflg_lbl" runat="server"></asp:Label>
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
										<div class="col1 col_2dan detail_right">
											<!--- 「ｍ１行no」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1rowno" CssClass="inpReadonlyRight inpRONum4" runat="server"></asp:TextBox>
										</div>
										<div class="col2 detail_left">
											<!--- 「ｍ１部門カナ名」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1bumonkana_nm" CssClass="inpReadonlyLeft inpRORightNm inpROHankaku12 tooltip" runat="server"></asp:TextBox></div>
											<div class="col2-1 cell detail_left">
												<!--- 「ｍ１評価区分」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1hyoka_kb" CssClass="inpReadonlyLeft inpROZenkaku1 tooltip" runat="server"></asp:TextBox>
											</div>
											<div class="col2-2 cell detail_left">
												<!--- 「ｍ１可否名称」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1kahi_nm" CssClass="inpReadonlyLeft inpROZenkaku2 tooltip" runat="server"></asp:TextBox>
											</div>
											<div class="col2-3 cell detail_right">
												<!--- 「ｍ１店在庫数」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1tenzaiko_su" CssClass="inpReadonlyRight inpRONumCma5" runat="server"></asp:TextBox>
											</div>
										</div>
										<div class="col3 detail_left">
											<!--- 「ｍ１品種略名称」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1hinsyu_ryaku_nm" CssClass="inpReadonlyLeft inpROZenkaku8 tooltip" runat="server"></asp:TextBox></div>
											<div class="col3-1 cell detail_right">
												<!--- 「ｍ１入荷予定数」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1nyukayotei_su" CssClass="inpReadonlyRight inpRONumCma5" runat="server"></asp:TextBox>
											</div>
											<div class="col3-2 cell detail_right">
												<!--- 「ｍ１売上実績数」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1uriage_su" CssClass="inpReadonlyRight inpRONumCma5" runat="server"></asp:TextBox>
											</div>
										</div>
										<div class="col4 detail_left">
											<!--- 「ｍ１ブランド名」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1burando_nm" CssClass="inpReadonlyLeft inpROHankaku12 tooltip" runat="server"></asp:TextBox></div>
											<!--- 「ｍ１自動定数」テキストボックスリードオンリー --->
											<div class="detail_right"><asp:TextBox ID="M1jido_su" CssClass="inpReadonlyRight inpRONumCma5" runat="server"></asp:TextBox></div>
										</div>
										<div class="col5 detail_left">
											<!--- 「ｍ１自社品番」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1jisya_hbn" CssClass="inpReadonlyLeft inpRONum8" runat="server"></asp:TextBox></div>
											<!--- 「ｍ１商品属性」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1syohin_zokusei" CssClass="inpReadonlyLeft inpROHankaku3 tooltip" runat="server"></asp:TextBox></div>
										</div>
										<div class="col6 detail_left">
											<!--- 「ｍ１色」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1iro_nm" CssClass="inpReadonlyLeft inpROHankaku6 tooltip" runat="server"></asp:TextBox></div>
											<!--- 「ｍ１サイズ」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1size_nm" CssClass="inpReadonlyLeft inpROHankaku4 tooltip" runat="server"></asp:TextBox></div>
										</div>
										<div class="col7 detail_left">
											<!--- 「ｍ１メーカー品番」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1maker_hbn" CssClass="inpReadonlyLeft inpROHankaku30 tooltip" runat="server"></asp:TextBox></div>
											<!--- 「ｍ１商品名(カナ)」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1syonmk" CssClass="inpReadonlyLeft inpROHankaku20 tooltip" runat="server"></asp:TextBox></div>
										</div>
										<div class="col8 detail_left">
											<!--- 「ｍ１発注メッセージ」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1hatchu_msg" CssClass="inpReadonlyLeft inpROZenkaku6 font-red tooltip" runat="server"></asp:TextBox></div>
											<!--- 「ｍ１依頼数量」一行テキストボックス（セパレート日付以外） --->
											<div class="detail_center"><md:MDTextBox ID="M1irai_su" CssClass="inpSu-07" runat="server"></md:MDTextBox></div>
										</div>
										<div class="col9 detail_left">
											<!--- 「ｍ１スキャンコード」一行テキストボックス（セパレート日付以外） --->
											<div class="detail_center"><md:MDTextBox ID="M1scan_cd" CssClass="inpScan" runat="server"></md:MDTextBox></div>
											<!--- 「ｍ１原価金額」テキストボックスリードオンリー --->
											<div class="detail_right"><asp:TextBox ID="M1genkakin" CssClass="inpReadonlyRight inpRONumCma9" runat="server"></asp:TextBox></div>
										</div>
										<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
										<div style="display: none">
											<div class="col24">
												<!--- 「Ｍ１依頼数量(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1irai_su_hdn" runat="server"></asp:hiddenfield>
											</div>
											<div class="col25">
												<!--- 「Ｍ１原単価(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1gen_tnk" runat="server"></asp:hiddenfield>
											</div>
											<div class="col26">
												<!--- 「Ｍ１原価金額(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1genkakin_hdn" runat="server"></asp:hiddenfield>
											</div>
											<div class="col27">
												<!--- 「ｍ１選択フラグ(隠し)」チェックボックス --->
												<adv:AdvancedCheckBox ID="M1selectorcheckbox" Text="" CssClass="" runat="server"></adv:AdvancedCheckBox>
											</div>
											<div class="col28">
												<!--- 「Ｍ１確定処理フラグ(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1entersyoriflg" runat="server"></asp:hiddenfield>
											</div>
											<div class="col29">
												<!--- 「Ｍ１明細色区分(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1dtlirokbn" runat="server"></asp:hiddenfield>
											</div>
										</div>
									<!-- /str-result-item-01 --></div>
								</ItemTemplate>
							</asp:Repeater>
						<!-- /str-result-item-wrap --></div>

						<div class="str-result-ftr-01 adjust-elem-next">
							<div class="col1 col_2dan detail_right">&nbsp;</div>
							<div class="col2 detail_left">&nbsp;</div>
							<div class="col3 detail_left">&nbsp;</div>
							<div class="col4 detail_left">&nbsp;</div>
							<div class="col5 detail_left">&nbsp;</div>
							<div class="col6 detail_left">&nbsp;</div>
							<div class="col7 detail_ftr_title">合計</div>
							<!--- 「合計依頼数量」テキストボックスリードオンリー --->
							<div class="col8 detail_ftr"><span><asp:TextBox ID="Gokei_irai_su" CssClass="inpReadonlyRight inpRONumCma9" runat="server"></asp:TextBox></span></div>
							<!--- 「合計原価金額」テキストボックスリードオンリー --->
							<div class="col9 detail_ftr"><span><asp:TextBox ID="Gokei_genkakin" CssClass="inpReadonlyRight inpRONumCma9" runat="server"></asp:TextBox></span></div>
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
							<input type="button" id="Btnenter" value="確定" onserverclick="OnBTNENTER_DBU" runat="server" class="btn type-01"/>
						</p>
					<!-- /str-pager-01 --></div>
				<!-- /footerBtnArea --></div>
			<!-- /str-wrap-result --></div>
		<!-- /wrap --></div>	
		
		<!-- 画面上隠しエレメントを格納するエリア-->
		<div id="hiddenElements" style="display:none" runat="server">
			<asp:Label ID="Head_tenpo_cd_lbl" runat="server"></asp:Label>
			<asp:Label ID="Head_tenpo_nm_lbl" runat="server"></asp:Label>

			<asp:Label ID="Hanbaiin_nm_lbl" runat="server"></asp:Label>

			<asp:Label ID="Gokei_irai_su_lbl" runat="server">合計</asp:Label>
			<asp:Label ID="Gokei_genkakin_lbl" runat="server"></asp:Label>

			<!--- 「選択モードNO」隠しフィールド --->
			<asp:hiddenfield ID="Stkmodeno" runat="server"></asp:hiddenfield>
		</div>
	
	</form>
</body>
</html>

