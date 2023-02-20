<%@ Page language="c#" CodeFile="ta080f02.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Ta080p01.Page.Ta080f02Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">補充・仕入稟議検索</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="ta080p01" FormId="ta080f02" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/ta080f02.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="ta080p01" FormId="ta080f02" runat="server" />
	<!-- Js業務部品のインポート --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05003.js" charset="UTF-8"></script><!-- 明細背景色変更処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
</head>

<body>
	<form id="Ta080f02" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="ta080p01" PgName="補充・仕入稟議検索" FormId="ta080f02" FormName="補充・仕入稟議検索 実績明細" ></uc:Header>
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
				<!-- search-list -->
				<div class="str-search-02">
				<!--- <p class="required">*が付いている項目は必須入力になります。</p> --->
					<div class="inner-01">
						<table>
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
							<tbody>
								<tr>
									<th >
										<span class="tbl-hdg">
											<asp:Label ID="Yosan_ymd_lbl" runat="server">年月度</asp:Label>
										</span>
									</th>
									<td>
										<!--- 「年月度」テキストボックスリードオンリー --->
										<asp:TextBox ID="Yosan_ymd" CssClass="inpReadonlyLeft inpRODateYM" runat="server"></asp:TextBox>
									</td>
									<th>
										<span class="tbl-hdg">
											<asp:Label ID="Yosan_cd_lbl" runat="server">仕入枠ｸﾞﾙｰﾌﾟ</asp:Label>
										</span>
									</th>
									<td>
										<!--- 「仕入枠グループコード」テキストボックスリードオンリー --->
										<!--- 「仕入枠グループ名」テキストボックスリードオンリー --->
										<asp:TextBox ID="Yosan_cd" CssClass="inpReadonlyLeft inpROHankaku6" runat="server"></asp:TextBox><asp:TextBox ID="Yosan_nm" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
									</td>
									<th >
										<span class="tbl-hdg">
											<asp:Label ID="Yosan_kin_lbl" runat="server">予算金額</asp:Label>
										</span>
									</th>
									<td>
										<!--- 「予算金額」テキストボックスリードオンリー --->
										<asp:TextBox ID="Yosan_kin" CssClass="inpReadonlyLeft inpRONumCma8" runat="server"></asp:TextBox>
									</td>
									<th >
										<span class="tbl-hdg">
											<asp:Label ID="Misinsei_su_lbl" runat="server">未申請数</asp:Label>
										</span>
									</th>
									<td>
										<!--- 「未申請数」テキストボックスリードオンリー --->
										<asp:TextBox ID="Misinsei_su" CssClass="inpReadonlyLeft inpRONumCma8" runat="server"></asp:TextBox>
									</td>
									<th >
										<span class="tbl-hdg">
											<asp:Label ID="Misinsei_kin_lbl" runat="server">未申請金額</asp:Label>
										</span>
									</th>
									<td>
										<!--- 「未申請金額」テキストボックスリードオンリー --->
										<asp:TextBox ID="Misinsei_kin" CssClass="inpReadonlyLeft inpRONumCma8" runat="server"></asp:TextBox>
									</td>
								</tr>
								<tr>
									<th  class ="last">
										<span class="tbl-hdg">
											<asp:Label ID="Apply_su_lbl" runat="server">申請数</asp:Label>
										</span>
									</th>
									<td  class ="last">
										<!--- 「申請数」テキストボックスリードオンリー --->
										<asp:TextBox ID="Apply_su" CssClass="inpReadonlyLeft inpRONumCma8" runat="server"></asp:TextBox>
									</td>
									<th  class ="last">
										<span class="tbl-hdg">
											<asp:Label ID="Apply_kin_lbl" runat="server">申請金額</asp:Label>
										</span>
									</th>
									<td  class ="last">
										<!--- 「申請金額」テキストボックスリードオンリー --->
											<asp:TextBox ID="Apply_kin" CssClass="inpReadonlyLeft inpRONumCma8" runat="server"></asp:TextBox>
									</td>
									<th  class ="last">
										<span class="tbl-hdg">
											<asp:Label ID="Jisseki_su_bo2_lbl" runat="server">実績数</asp:Label>
										</span>
									</th>
									<td  class ="last">
										<!--- 「実績数」テキストボックスリードオンリー --->
											<asp:TextBox ID="Jisseki_su_bo2" CssClass="inpReadonlyLeft inpRONumCma8" runat="server"></asp:TextBox>
									</td>
									<th  class ="last">
										<span class="tbl-hdg">
											<asp:Label ID="Jisseki_kin_lbl" runat="server">実績金額</asp:Label>
										</span>
									</th>
									<td  class ="last">
										<!--- 「実績金額」テキストボックスリードオンリー --->
											<asp:TextBox ID="Jisseki_kin" CssClass="inpReadonlyLeft inpRONumCma8" runat="server"></asp:TextBox>
									</td>
									<th  class ="last">
										<span class="tbl-hdg">
											<asp:Label ID="Zan_kin_lbl" runat="server">残金額</asp:Label>
										</span>
									</th>
									<td  class ="last">
										<!--- 「残金額」テキストボックスリードオンリー --->
										<asp:TextBox ID="Zan_kin" CssClass="inpReadonlyLeft inpRONumCma8" runat="server"></asp:TextBox>
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
							<div class="col2">
								<div>
									<asp:Label ID="M1apply_ymd_lbl" runat="server">申請日</asp:Label>
								</div>
								<div>
									<asp:Label ID="M1sinsei_sb_lbl" runat="server">申請種別</asp:Label>
								</div>
							</div>
							<div class="col3">
								<div>
									<asp:Label ID="M1hanbaiin_cd_lbl" runat="server">登録担当者</asp:Label>
								</div>
								<div>
									<asp:Label ID="M1irai_riyu_lbl" runat="server">依頼理由</asp:Label>
								</div>
							</div>
							<div class="col13 col_2dan">
								<asp:Label ID="M1bumon_cd_lbl" runat="server">部門</asp:Label>
							</div>
							<div class="col4">
								<div>
									<asp:Label ID="M1hinsyu_cd_lbl" runat="server">品種</asp:Label>
								</div>
								<div>
									<asp:Label ID="M1burando_nm_lbl" runat="server">ブランド</asp:Label>
								</div>
							</div>
							<div class="col5">
								<div>
									<asp:Label ID="M1jisya_hbn_lbl" runat="server">自社品番</asp:Label>
								</div>
								<div>
									<asp:Label ID="M1syohin_zokusei_lbl" runat="server">コア</asp:Label>
								</div>
							</div>
							<div class="col7">
								<div>
									<asp:Label ID="M1maker_hbn_lbl" runat="server">メーカー品番</asp:Label>
								</div>
								<div>
									<asp:Label ID="M1syonmk_lbl" runat="server">商品名</asp:Label>
								</div>
							</div>
							<div class="col8">
								<div>
									<asp:Label ID="M1iro_nm_lbl" runat="server">色</asp:Label>
								</div>
								<div>
									<asp:Label ID="M1size_nm_lbl" runat="server">サイズ</asp:Label>
								</div>
							</div>
							<div class="col6">
								<div>
									<asp:Label ID="M1scan_cd_lbl" runat="server">スキャンコード</asp:Label>
								</div>
								<div>
									<asp:Label ID="M1nyukayotei_ymd_lbl" runat="server">入荷予定日</asp:Label>
								</div>
							</div>
							<div class="col9">
								<div>
									<asp:Label ID="M1season_nm_lbl" runat="server">シーズン</asp:Label>
								</div>
								<div>
									<asp:Label ID="M1hanbaikanryo_ymd_lbl" runat="server">販完日</asp:Label>
								</div>
							</div>
							<div class="col10">
								<div>
									<asp:Label ID="M1apply_su_lbl" runat="server">申請数</asp:Label>
								</div>
								<div>
									<asp:Label ID="M1apply_kin_lbl" runat="server">申請金額</asp:Label>
								</div>
							</div>
							<div class="col11">
								<div>
									<asp:Label ID="M1jisseki_su_lbl" runat="server">実績数</asp:Label>
								</div>
								<div>
									<asp:Label ID="M1jisseki_kin_lbl" runat="server">実績金額</asp:Label>
								</div>
							</div>
							<div class="col12">
								<div>
									<asp:Label ID="M1jotai_kbn_nm_lbl" runat="server">状態</asp:Label>
								</div>
								<div>
									<asp:Label ID="M1comment_nm_lbl" runat="server">コメント</asp:Label>
								</div>
							</div>
							<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
							<div style="display:none">
								<asp:Label ID="M1hanbaiin_nm_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1bumonkana_nm_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1hinsyu_ryaku_nm_lbl" runat="server"></asp:Label>
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
									<div class="str-result-item-01">
										<div class="col1 col_2dan detail_right">
											<!--- 「ｍ１行no」ラベル --->
											<asp:Label ID="M1rowno" CssClass="inpReadonlyRight inpRONum4" style="line-height: 34px;" runat="server"></asp:Label>
										</div>
										<div class="col2 detail_left">
											<div>
												<!--- 「ｍ１申請日」ラベル --->
												<asp:Label ID="M1apply_ymd" CssClass="inpReadonlyCenter inpRONum6" runat="server"></asp:Label>
											</div>
											<div>
												<!--- 「ｍ１申請種別」ラベル --->
												<asp:Label ID="M1sinsei_sb" CssClass="inpReadonlyCenter inpROZenkaku4 tooltip" runat="server"></asp:Label>
											</div>
										</div>
										<div class="col3 detail_left">
											<div>
												<!--- 「ｍ１登録担当者コード」一行テキストボックス（セパレート日付以外） --->
												<!--- 「ｍ１登録担当者名」テキストボックスリードオンリー --->
												<md:MDTextBox ID="M1hanbaiin_cd" CssClass="inpReadonlyLeft inpRONum7" runat="server"></md:MDTextBox><asp:TextBox ID="M1hanbaiin_nm" CssClass="inpReadonlyLeft inpROZenkaku6 tooltip" runat="server"></asp:TextBox>
											</div>
											<div>
												<!--- 「ｍ１依頼理由」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1irai_riyu" CssClass="inpReadonlyLeft inpROZenkaku10 tooltip" runat="server"></asp:TextBox>
											</div>
										</div>
										<div class="col13 detail_left">
											<div>
												<!--- 「ｍ１部門コード」ラベル --->
												<asp:Label ID="M1bumon_cd" CssClass="inpReadonlyLeft inpRONum3" runat="server"></asp:Label>
											</div>
											<div>
												<!--- 「ｍ１部門カナ名」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1bumonkana_nm" CssClass="inpReadonlyLeft inpROHankaku10 tooltip" runat="server"></asp:TextBox>
											</div>
										</div>
										<div class="col4 detail_left">
											<div>
												<!--- 「ｍ１品種コード」ラベル --->
												<!--- 「ｍ１品種略名称」テキストボックスリードオンリー --->
												<asp:Label ID="M1hinsyu_cd" CssClass="inpReadonlyLeft inpRONum2" runat="server"></asp:Label><asp:TextBox ID="M1hinsyu_ryaku_nm" CssClass="inpReadonlyLeft inpROZenkaku10 tooltip" runat="server"></asp:TextBox>
											</div>
											<div>
												<!--- 「ｍ１ブランド名」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1burando_nm" CssClass="inpReadonlyLeft inpROHankaku12 tooltip" runat="server"></asp:TextBox>
											</div>
										</div>
										<div class="col5 detail_left">
											<div>
												<!--- 「ｍ１自社品番」ラベル --->
												<asp:Label ID="M1jisya_hbn" CssClass="inpReadonlyCenter inpRONum8" runat="server"></asp:Label>
											</div>
											<div>
												<!--- 「ｍ１商品属性」ラベル --->
												<asp:Label ID="M1syohin_zokusei" CssClass="inpReadonlyLeft inpROHankaku3 tooltip" runat="server"></asp:Label>
											</div>
										</div>
										<div class="col7 detail_left">
											<div>
												<!--- 「ｍ１メーカー品番」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1maker_hbn" CssClass="inpReadonlyLeft inpROHankaku12 tooltip" runat="server"></asp:TextBox>
											</div>
											<div>
												<!--- 「ｍ１商品名(カナ)」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1syonmk" CssClass="inpReadonlyLeft inpROHankaku12 tooltip" runat="server"></asp:TextBox>
											</div>
										</div>
										<div class="col8 detail_left">
											<div>
												<!--- 「ｍ１色」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1iro_nm" CssClass="inpReadonlyLeft inpROHankaku6 tooltip" runat="server"></asp:TextBox>
											</div>
											<div>
												<!--- 「ｍ１サイズ」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1size_nm" CssClass="inpReadonlyLeft inpROHankaku4 tooltip" runat="server"></asp:TextBox>
											</div>
										</div>
										<div class="col6 detail_center">
											<div class="detail_left">
												<!--- 「ｍ１スキャンコード」ラベル --->
												<asp:Label ID="M1scan_cd" CssClass="inpReadonlyCenter inpRONum13" runat="server"></asp:Label>
											</div>
											<div class="detail_center">
												<!--- 「ｍ１入荷予定日」ラベル --->
												<asp:Label ID="M1nyukayotei_ymd" CssClass="inpReadonlyCenter inpRODate" runat="server"></asp:Label>
											</div>
										</div>
										<div class="col9 detail_left">
											<div>
												<!--- 「ｍ１シーズン」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1season_nm" CssClass="inpReadonlyLeft inpROZenkaku2 tooltip" runat="server"></asp:TextBox>
											</div>
											<div>
												<!--- 「ｍ１販売完了日」ラベル --->
												<asp:Label ID="M1hanbaikanryo_ymd" CssClass="inpReadonlyCenter inpRONum6" runat="server"></asp:Label>
											</div>
										</div>
										<div class="col10 detail_right">
											<div>
												<!--- 「ｍ１申請数」ラベル --->
												<asp:Label ID="M1apply_su" CssClass="inpReadonlyRight inpRONumCma8" runat="server"></asp:Label>
											</div>
											<div>
												<!--- 「ｍ１申請金額」ラベル --->
												<asp:Label ID="M1apply_kin" CssClass="inpReadonlyRight inpRONumCma8" runat="server"></asp:Label>
											</div>
										</div>
										<div class="col11 detail_right">
											<div>
												<!--- 「ｍ１実績数」ラベル --->
												<asp:Label ID="M1jisseki_su" CssClass="inpReadonlyRight inpRONumCma8" runat="server"></asp:Label>
											</div>
											<div>
												<!--- 「ｍ１実績金額」ラベル --->
												<asp:Label ID="M1jisseki_kin" CssClass="inpReadonlyRight inpRONumCma8" runat="server"></asp:Label>
											</div>
										</div>
										<div class="col12 detail_left">
											<div>
												<!--- 「ｍ１状態」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1jotai_kbn_nm" CssClass="inpReadonlyLeft inpROZenkaku10 tooltip" runat="server"></asp:TextBox>
											</div>
											<div>
												<!--- 「ｍ１コメント」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1comment_nm" CssClass="inpReadonlyLeft inpROZenkaku10 tooltip" runat="server"></asp:TextBox>
											</div>
										</div>
										<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
										<div style="display: none">
											<div class="col28">
												<!--- 「ｍ１選択フラグ(隠し)」チェックボックス --->
												<adv:AdvancedCheckBox ID="M1selectorcheckbox" Text="" CssClass="" runat="server"></adv:AdvancedCheckBox>
											</div>
											<div class="col29">
												<!--- 「Ｍ１確定処理フラグ(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1entersyoriflg" runat="server"></asp:hiddenfield>
											</div>
											<div class="col30">
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
			    <!-- /str-wrap-result --></div>
		<!-- /str-search-02 --></div>	
		<!-- /wrap --></div>	
		
		<!-- 画面上隠しエレメントを格納するエリア-->
		<div id="hiddenElements" style="display:none" runat="server">
		     				<asp:Label ID="Head_tenpo_cd_lbl" runat="server"></asp:Label>
				<asp:Label ID="Head_tenpo_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Yosan_nm_lbl" runat="server"></asp:Label>

		</div>
	
	</form>
</body>
</html>

