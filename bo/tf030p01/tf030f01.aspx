<%@ Page language="c#" CodeFile="tf030f01.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Tf030p01.Page.Tf030f01Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">経費未払登録</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="tf030p01" FormId="tf030f01" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/tf030f01.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="tf030p01" FormId="tf030f01" runat="server" />

	<!-- Js業務部品のインポート --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02001.js" charset="UTF-8"></script><!-- 店舗検索 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02002.js" charset="UTF-8"></script><!-- 仕入先マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script><!-- 0埋め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05011.js" charset="UTF-8"></script><!-- FROM-TOコピー処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05014.js" charset="UTF-8"></script><!-- 名称取得拡張 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05015.js" charset="UTF-8"></script><!-- 項目制御処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05016.js" charset="UTF-8"></script><!-- コード参照出口ルーチン共通処理 -->

</head>

<body>
	<form id="Tf030f01" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="tf030p01" PgName="経費未払登録" FormId="tf030f01" FormName="経費未払登録 一覧" ></uc:Header>

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

			<div id="tab16" class="str-tab-cont"></div>
			<div id="tab8" class="str-tab-cont"></div>
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
				<!-- <p class="required">*が付いている項目は必須入力になります。</p> -->
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
										<tr>
											<th>
												<span class="tbl-hdg"><asp:Label ID="Add_ymd_from_lbl" runat="server">登録日</asp:Label></span>
											</th>
											<!--- 「登録日ｆｒｏｍ」一行テキストボックス（セパレート日付以外） --->
											<!--- 「登録日ｔｏ」一行テキストボックス（セパレート日付以外） --->
											<td>
												<span class="icon-in"><md:MDTextBox ID="Add_ymd_from" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span>
												<span class="label-fromto">～</span>
												<span class="icon-in"><md:MDTextBox ID="Add_ymd_to" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span>
											</td>
											<th>
												<span class="tbl-hdg"><asp:Label ID="Tenpo_cd_from_lbl" runat="server">店舗</asp:Label></span>
											</th>
											<!--- 「店舗コードｆｒｏｍ」一行テキストボックス（セパレート日付以外） --->
											<!--- 「店舗コードＦＲＯＭボタン」ボタン --->
											<!--- 「店舗名ｆｒｏｍ」テキストボックスリードオンリー --->
											<!--- 「店舗コードｔｏ」一行テキストボックス（セパレート日付以外） --->
											<!--- 「店舗コードＴＯボタン」ボタン --->
											<!--- 「店舗名ｔｏ」テキストボックスリードオンリー --->
											<td colspan="3">
												<span class="icon-in"><md:MDTextBox ID="Tenpo_cd_from" CssClass="inpSerch inpTenpo" runat="server"></md:MDTextBox><input type="button" id="Btntenpocd_from" name="Btntenpocd_from" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="Tenpo_nm_from" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
												<span class="label-fromto">～</span>
												<span class="icon-in"><md:MDTextBox ID="Tenpo_cd_to" CssClass="inpSerch inpTenpo" runat="server"></md:MDTextBox><input type="button" id="Btntenpocd_to" name="Btntenpocd_to" value="" runat="server" class="icon-search"/></span><asp:TextBox ID="Tenpo_nm_to" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
											</td>
										</tr>
										<tr>
											<th class="last">
												<span class="tbl-hdg"><asp:Label ID="Siiresaki_cd_lbl" runat="server">取引先</asp:Label></span>
											</th>
											<!--- 「仕入先コード」一行テキストボックス（セパレート日付以外） --->
											<!--- 「仕入先コードボタン」ボタン --->
											<!--- 「仕入先略式名称」テキストボックスリードオンリー --->
											<td class="last">
												<span class="icon-in">
													<md:MDTextBox ID="Siiresaki_cd" CssClass="inpSerch inpShiire" runat="server"></md:MDTextBox>
													<input type="button" id="Btnsiiresaki_cd" name="Btnsiiresaki_cd" value="" runat="server" class="icon-search"/>
												</span>
												<asp:TextBox ID="Siiresaki_ryaku_nm" CssClass="inpReadonlyLeft" runat="server"></asp:TextBox>
											</td>
											<th class="last">
												<span class="tbl-hdg"><asp:Label ID="Denpyo_bango_from_lbl" runat="server">伝票番号</asp:Label></span>
											</th>
											<!--- 「伝票番号ｆｒｏｍ」一行テキストボックス（セパレート日付以外） --->
											<!--- 「伝票番号ｔｏ」一行テキストボックス（セパレート日付以外） --->
											<td class="last">
												<md:MDTextBox ID="Denpyo_bango_from" CssClass="inpDenpyo" runat="server"></md:MDTextBox>
												<span class="label-fromto">～</span>
												<md:MDTextBox ID="Denpyo_bango_to" CssClass="inpDenpyo" runat="server"></md:MDTextBox>
											</td>
											<th class="last">
												<span class="tbl-hdg"><asp:Label ID="Motodenpyo_bango_from_lbl" runat="server">元伝票番号</asp:Label></span>
											</th>
											<!--- 「元伝票番号ｆｒｏｍ」一行テキストボックス（セパレート日付以外） --->
											<!--- 「元伝票番号ｔｏ」一行テキストボックス（セパレート日付以外） --->
											<td class="last">
												<md:MDTextBox ID="Motodenpyo_bango_from" CssClass="inpDenpyo" runat="server"></md:MDTextBox>
												<span class="label-fromto">～</span>
												<md:MDTextBox ID="Motodenpyo_bango_to" CssClass="inpDenpyo" runat="server"></md:MDTextBox>
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
								<!--- 「ボタン検索」ボタン --->
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
						<!--- 「ボタン印刷」ボタン --->
						<li><span><label><input type="button" id="Btnprint" value="" onserverclick="OnBTNPRINT_FRM" runat="server" class="icon-utility-04"/>印刷</label></span></li>
					</ul>
					<!-- /meisaiBtnArea --></div>
				<!-- /utility --></div>

				<!------------------------------------------
					□明細部
				-------------------------------------------->
				<div class="inner">
					<!---<div id="str-pager-top" class="str-pager-01">--->
		
						<!--- 件数表示部 --->
						<!--<p><adv:PageInfo ID="M1PageInfo" runat="server"></adv:PageInfo></p>-->
						<!--- ページャーを配置する場合はこの中 --->
		
					<!-- /str-pager-01 --><!---</div>--->
					<!--一覧-->
					<div class="str-result-01">
					<%-- 明細ヘッダ --%>
						<div class="str-result-hdg-01">
							<div class="col1">
								<asp:Label ID="M1rowno_lbl" runat="server">No.</asp:Label>
							</div>
							<div class="col2">
								<asp:Label ID="M1add_ymd_lbl" runat="server">登録日</asp:Label>
							</div>
							<div class="col3">
								<asp:Label ID="M1tenpo_cd_lbl" runat="server">店舗</asp:Label>
							</div>
							<div class="col4">
								<asp:Label ID="M1siiresaki_cd_lbl" runat="server">取引先</asp:Label>
							</div>
							<div class="col5">
								<asp:Label ID="M1denpyo_bango_lbl" runat="server">伝票番号</asp:Label>
							</div>
							<div class="col6">
								<asp:Label ID="M1motodenpyo_bango_lbl" runat="server">元伝票番号</asp:Label>
							</div>
							<div class="col7">
								<asp:Label ID="M1nohin_ymd_lbl" runat="server">納品日</asp:Label>
							</div>
							<div class="col8">
								<asp:Label ID="M1nyuryokutan_nm_lbl" runat="server">入力担当者</asp:Label>
							</div>
							<div class="col9">
								<asp:Label ID="M1itemsu_lbl" runat="server">数量</asp:Label>
							</div>
							<div class="col10">
								<asp:Label ID="M1kingaku_lbl" runat="server">金額</asp:Label>
							</div>

							<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
							<div style="display:none">
								<div class="col4">
									<asp:Label ID="M1tenpo_nm_lbl" runat="server"></asp:Label>
								</div>
								<div class="col6">
									<asp:Label ID="M1siiresaki_ryaku_nm_lbl" runat="server"></asp:Label>
								</div>
								<div class="col13">
									<asp:Label ID="M1selectorcheckbox_lbl" runat="server"></asp:Label>
								</div>
								<div class="col14">
									<asp:Label ID="M1entersyoriflg_lbl" runat="server"></asp:Label>
								</div>
								<div class="col15">
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
											<!--- 「ｍ１行no」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1rowno" CssClass="inpReadonlyRight inpRONum3" runat="server"></asp:TextBox>
										</div>
										<div class="col2 detail_center">
											<!--- 「ｍ１登録日」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1add_ymd" CssClass="inpReadonlyCenter inpRODate" runat="server"></asp:TextBox>
										</div>
										<div class="col3 detail_left">
											<!--- 「ｍ１店舗コード」テキストボックスリードオンリー --->
											<!--- 「ｍ１店舗名」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1tenpo_cd" CssClass="inpReadonlyRight inpRONum4" runat="server"></asp:TextBox><asp:TextBox ID="M1tenpo_nm" CssClass="inpReadonlyLeft inpRORightNm inpROZenkaku10 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col4 detail_left">
											<!--- 「ｍ１仕入先コード」テキストボックスリードオンリー --->
											<!--- 「ｍ１仕入先略式名称」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1siiresaki_cd" CssClass="inpReadonlyRight inpRONum4" runat="server"></asp:TextBox><asp:TextBox ID="M1siiresaki_ryaku_nm" CssClass="inpReadonlyLeft inpRORightNm inpROZenkaku10 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col5 detail_center">
											<!--- 「Ｍ１伝票番号リンク」ボタン --->
											<input type="button" id="M1denpyo_bango" value="伝票番号" onserverclick="OnM1DENPYO_BANGO_FRM" runat="server" class="meisaiLink"/>
										</div>
										<div class="col6 detail_center">
											<!--- 「ｍ１元伝票番号」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1motodenpyo_bango" CssClass="inpReadonlyCenter inpRONum6" runat="server"></asp:TextBox>
										</div>
										<div class="col7 detail_center">
											<!--- 「ｍ１納品日」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1nohin_ymd" CssClass="inpReadonlyCenter inpRODate" runat="server"></asp:TextBox>
										</div>
										<div class="col8 detail_left">
											<!--- 「ｍ１入力担当者名称」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1nyuryokutan_nm" CssClass="inpReadonlyLeft inpROZenkaku10 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col9 detail_right">
											<!--- 「ｍ１数量」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1itemsu" CssClass="inpReadonlyRight inpRONumCmaMinus6" runat="server"></asp:TextBox>
										</div>
										<div class="col10 detail_right">
											<!--- 「ｍ１金額」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1kingaku" CssClass="inpReadonlyRight inpRONumCmaMinus12" runat="server"></asp:TextBox>
										</div>

										<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
										<div style="display:none">
											<div class="col16">
												<!--- 「ｍ１選択フラグ(隠し)」チェックボックス --->
												<adv:AdvancedCheckBox ID="M1selectorcheckbox" Text="" CssClass="" runat="server"></adv:AdvancedCheckBox>
											</div>
											<div class="">
												<!--- 「Ｍ１確定処理フラグ(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1entersyoriflg" runat="server"></asp:hiddenfield>
											</div>
											<div class="">
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
						</p>
						<p>
							<!-- ページャ下部にボタンを配置する場合はこの中 -->
							<!--- 「ボタン確定」ボタン --->
							<input type="button" id="Btnenter" value="確定" onserverclick="OnBTNENTER_FRM" runat="server" class="btn type-01"/>
						</p>
					<!-- /str-pager-01 --></div>
				<!-- /footerBtnArea --></div>
			<!-- /str-wrap-result --></div>
		<!-- /wrap --></div>	
		
		<!-- 画面上隠しエレメントを格納するエリア-->
		<div id="hiddenElements" style="display: none" runat="server">

			<asp:Label ID="Head_tenpo_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Head_tenpo_cd_lbl" runat="server"></asp:Label>
			<asp:Label ID="Head_tenpo_cd_Req" runat="server" CssClass="required">*</asp:Label>

			<asp:Label ID="Add_ymd_to_lbl" runat="server">登録日ＴＯ</asp:Label>
			<asp:Label ID="Tenpo_nm_from_lbl" runat="server"></asp:Label>
			<asp:Label ID="Tenpo_cd_to_lbl" runat="server">店舗ＴＯ</asp:Label>
			<asp:Label ID="Tenpo_nm_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Siiresaki_ryaku_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Denpyo_bango_to_lbl" runat="server">伝票番号ＴＯ</asp:Label>
			<asp:Label ID="Motodenpyo_bango_to_lbl" runat="server">元伝票番号ＴＯ</asp:Label>

			<asp:Label ID="Searchcnt_lbl" runat="server"></asp:Label>
			<!--- 「モードNO」隠しフィールド --->
			<asp:HiddenField ID="Modeno" runat="server"></asp:HiddenField>
			<!--- 「選択モードNO」隠しフィールド --->
			<asp:HiddenField ID="Stkmodeno" runat="server"></asp:HiddenField>

		</div>

	</form>
</body>
</html>

