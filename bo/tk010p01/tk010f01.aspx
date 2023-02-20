<%@ Page language="c#" CodeFile="tk010f01.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Tk010p01.Page.Tk010f01Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">評価損確定</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="tk010p01" FormId="tk010f01" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/tk010f01.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="tk010p01" FormId="tk010f01" runat="server" />

	<!-- Js業務部品のインポート --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02001.js" charset="UTF-8"></script><!-- 店舗検索 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05011.js" charset="UTF-8"></script><!-- FROM-TOコピー処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05014.js" charset="UTF-8"></script><!-- 名称取得拡張 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05015.js" charset="UTF-8"></script><!-- 項目入力制御処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05019.js" charset="UTF-8"></script><!-- 情報ダイアログ表示処理(拡張版) -->


	<!-- 業務共通コントロールのインポート-->
	<%@ Register TagPrefix="uc" TagName="common" Src="~/pjcommon/businessCommon/usercontrol/boCommonControl.ascx" %>

</head>

<body>
	<form id="Tk010f01" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="tk010p01" PgName="評価損確定" FormId="tk010f01" FormName="評価損確定 一覧" ></uc:Header>

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
						<!--- 「モード確定ボタン」リンク --->
						<a id="Btnmodekakutei" href="#tab2" class="" runat="server">確定</a>
					</li>
					<li>
						<!--- 「モード修正ボタン」リンク --->
						<a id="Btnmodeupd" href="#tab8" class="" runat="server">修正</a>
					</li>
					<li>
						<!--- 「モード照会ボタン」リンク --->
						<a id="Btnmoderef" href="#tab16" class="" runat="server">照会</a>
					</li>
				</ul>
			</div>

			<div id="tab2" class="str-tab-cont"></div>
			<div id="tab8" class="str-tab-cont"></div>
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
									<!--- 「検索件数」一行テキストボックス（セパレート日付以外） --->
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
												<col class="w-type-04"/>
												<col class="w-type-01"/>
												<col />
											</colgroup>
											<tbody>
												<tr><td colspan ="2"><div class="required">*が付いている項目は必須入力になります。</div><td></tr>
												<tr>
													<th>
														<span class="tbl-hdg">
															<asp:Label ID="Hyokasonsyubetsu_kb_lbl" runat="server">評価損種別</asp:Label>
														</span>
													</th>
													<td>
														<!--- 「評価損種別区分」ドロップダウンリスト --->
														<md:MDCodeCondition ID="Hyokasonsyubetsu_kb" FormID="Tk010f01" PgID="Tk010p01" CssClass="slt-hyokason" runat="server"></md:MDCodeCondition>
														<span class="select-arrow"></span>
													</td>
													<th>
														<span class="tbl-hdg">
															<asp:Label ID="Syonin_flg_lbl" runat="server">承認状態</asp:Label>
														</span>
													</th>
													<td>
														<!--- 「承認状態」ドロップダウンリスト --->
														<md:MDConditionDDList ID="Syonin_flg" ConditionName="syonin_jotai2" CssClass="slt-syonin" runat="server"></md:MDConditionDDList>
														<span class="select-arrow"></span>
													</td>
													<th>
														<span class="tbl-hdg">
															<asp:Label ID="Kessai_flg_lbl" runat="server">決裁状態</asp:Label>
														</span>
													</th>
													<td>
														<!--- 「決裁状態」ドロップダウンリスト --->
														<md:MDConditionDDList ID="Kessai_flg" ConditionName="kessai_jotai" CssClass="slt-kessai" runat="server"></md:MDConditionDDList>
														<span class="select-arrow"></span>
													</td>
													<th>
														<span class="tbl-hdg">
															<asp:Label ID="Sinsei_kb_lbl" runat="server">申請区分</asp:Label>
														</span>
													</th>
													<td>
														<!--- 「申請区分」ドロップダウンリスト --->
														<md:MDConditionDDList ID="Sinsei_kb" ConditionName="sinsei_kbn" CssClass="slt-shinsei" runat="server"></md:MDConditionDDList>
														<span class="select-arrow"></span>
													</td>
												</tr>
												<tr>
													<th class="last">
														<span class="tbl-hdg">
															<asp:Label ID="Tenpo_cd_from_lbl" runat="server">店舗FROM</asp:Label>
														</span>
													</th>
													<td class="last" colspan="3">
														<span class="icon-in">
															<!--- 「店舗コードfrom」一行テキストボックス（セパレート日付以外） --->
															<md:MDTextBox ID="Tenpo_cd_from" CssClass="inpSerch inpTenpo" runat="server"></md:MDTextBox>
															<!--- 「店舗コードFROMボタン」ボタン --->
															<input type="button" id="Btntenpocd_from" name="Btntenpocd_from" value="" runat="server" class="icon-search"/>
														</span>
														<!--- 「店舗名from」テキストボックスリードオンリー --->
														<asp:TextBox ID="Tenpo_nm_from" CssClass="inpReadonlyLeft9" runat="server"></asp:TextBox>
														<span class="label-fromto">～</span>
														<span class="icon-in">
															<!--- 「店舗コードto」一行テキストボックス（セパレート日付以外） --->
															<md:MDTextBox ID="Tenpo_cd_to" CssClass="inpSerch inpTenpo" runat="server"></md:MDTextBox>
															<!--- 「店舗コードTOボタン」ボタン --->
															<input type="button" id="Btntenpocd_to" name="Btntenpocd_to" value="" runat="server" class="icon-search"/>
														</span>
														<!--- 「店舗名to」テキストボックスリードオンリー --->
														<asp:TextBox ID="Tenpo_nm_to" CssClass="inpReadonlyLeft9" runat="server"></asp:TextBox>
													</td>

													<th class="last">
														<span class="tbl-hdg">
															<asp:Label ID="Syori_ym_lbl" runat="server">処理月</asp:Label><asp:Label ID="Syori_ym_Req" runat="server" CssClass="required">*</asp:Label>
														</span>
													</th>
													<td class="last" colspan="3">
														<label>
															<span>
																<%--
																	<!--- 「処理月」一行テキストボックス（セパレート日付以外） --->
																	<md:MDTextBox ID="Syori_ym" CssClass="inpYmNotCalendar" runat="server"></md:MDTextBox>
																	<%--  <std:LinkCalendar ID="Syori_ymCalendar" TargetId="Syori_ym" runat="server" />--%>
																<!--- 「処理月」ドロップダウンリスト --->
																<asp:DropDownList ID="Syori_ym" CssClass="slt-syoriYm" runat="server"></asp:DropDownList>
																<span class="select-arrow"></span>
															</span>
														</label>
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
						<!--- 「全選択ボタン」ボタン --->
						<li><span><label><input type="button" id="Btnzenstk" value="" onserverclick="OnBTNZENSTK_FRM" runat="server" class="icon-utility-01"/>全選択</label></span></li>
						<!--- 「全解除ボタン」ボタン --->
						<li><span><label><input type="button" id="Btnzenkjo" value="" onserverclick="OnBTNZENKJO_FRM" runat="server" class="icon-utility-02"/>全解除</label></span></li>
					</ul>
					<ul>
						<!--帳票／CSV系ボタンを配置する場合はこのulタグの中-->
						<!--- 「印刷ボタン」ボタン --->
						<li><span><label><input type="button" id="Btnprint" value="" onserverclick="OnBTNPRINT_FRM" runat="server" class="icon-utility-04"/>印刷</label></span></li>
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
							<div class="col1 col_2dan">
								<asp:Label ID="M1rowno_lbl" runat="server">No.</asp:Label>
							</div>
							<div class="col2 col_2dan">
								<asp:Label ID="M1tenpo_cd_lbl" runat="server">店舗</asp:Label>
							</div>
							<div class="col3 col_2dan">
								<asp:Label ID="M1apply_ymd_lbl" runat="server">申請日</asp:Label>
							</div>
							<div class="col4 col_2dan">
								<asp:Label ID="M1sinsei_kb_nm_lbl" runat="server">再申請</asp:Label>
							</div>
							<div class="col5 col_2dan">
								<asp:Label ID="M1syonin_flg_nm_lbl" runat="server">承認</asp:Label>
							</div>
							<div class="col6 col_2dan">
								<asp:Label ID="M1kessai_flg_nm_lbl" runat="server">決裁</asp:Label>
							</div>
							<div class="col7">
								<div>NB以外</div>
								<div class="col7-1 headcell">
									<asp:Label ID="M1notnb_suryo_lbl" runat="server">数量</asp:Label>
								</div>
								<div class="col7-2 headcell">
									<asp:Label ID="M1notnb_genka_kin_lbl" runat="server">原価金額</asp:Label>
								</div>
							</div>
							<div class="col8">
								<div>NB</div>
								<div class="col8-1 headcell">
									<asp:Label ID="M1nb_suryo_lbl" runat="server">数量</asp:Label>
								</div>
								<div class="col8-2 headcell">
									<asp:Label ID="M1nb_genka_kin_lbl" runat="server">原価金額</asp:Label>
								</div>
							</div>
							<div class="col9">
								<div>店舗合計</div>
								<div class="col9-1 headcell">
									<asp:Label ID="M1tenpogokei_su_lbl" runat="server">数量</asp:Label>
								</div>
								<div class="col9-2 headcell">
									<asp:Label ID="M1tenpogokei_genka_kin_lbl" runat="server">原価金額</asp:Label>
								</div>
							</div>
							<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
							<div style="display:none">
								<asp:Label ID="M1tenpo_nm_lbl" runat="server"></asp:Label>
								<div class="col14">
									<asp:Label ID="M1selectorcheckbox_lbl" runat="server"></asp:Label>
								</div>
								<div class="col15">
									<asp:Label ID="M1entersyoriflg_lbl" runat="server"></asp:Label>
								</div>
								<div class="col16">
									<asp:Label ID="M1dtlirokbn_lbl" runat="server"></asp:Label>
								</div>
							</div>
							<!--- 隠し項目エリア↑↑↑↑↑↑↑↑↑↑↑↑↑ --->
						<!-- /str-result-hdg-01 --></div>

						<!------------------------------------------
						  □一覧明細領域
						-------------------------------------------->
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
										<div class="col2 detail_left">
											<!--- 「Ｍ１店舗リンク」ボタン --->
											<input type="button" id="M1tenpo_cd" value="店舗" onserverclick="OnM1TENPO_CD_FRM" runat="server" class="meisaiLink"/>
										</div>
										<div class="col3 detail_center">
											<!--- 「ｍ１申請日」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1apply_ymd" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox>
										</div>
										<div class="col4 detail_center">
											<!--- 「ｍ１申請区分名称」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1sinsei_kb_nm" CssClass="inpReadonlyCenter inpROZenkaku2" runat="server"></asp:TextBox>
										</div>
										<div class="col5 detail_left">
											<!--- 「ｍ１承認状態名称」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1syonin_flg_nm" CssClass="inpReadonlyLeft inpROZenkaku2" runat="server"></asp:TextBox>
										</div>
										<div class="col6 detail_left">
											<!--- 「ｍ１決裁状態名称」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1kessai_flg_nm" CssClass="inpReadonlyLeft inpROZenkaku3 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col7s detail_right">
											<!--- 「ｍ１ｎｂ以外数量」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1notnb_suryo" CssClass="inpReadonlyRight inpRONumCmaMinus8" runat="server"></asp:TextBox>
										</div>
										<div class="col7k detail_right">
											<!--- 「ｍ１ｎｂ以外原価金額」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1notnb_genka_kin" CssClass="inpReadonlyRight inpRONumCmaMinus9" runat="server"></asp:TextBox>
										</div>
										<div class="col8s detail_right">
											<!--- 「ｍ１ｎｂ数量」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1nb_suryo" CssClass="inpReadonlyRight inpRONumCmaMinus8" runat="server"></asp:TextBox>
										</div>
										<div class="col8k detail_right">
											<!--- 「ｍ１ｎｂ原価金額」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1nb_genka_kin" CssClass="inpReadonlyRight inpRONumCmaMinus9" runat="server"></asp:TextBox>
										</div>
										<div class="col9s detail_right">
											<!--- 「ｍ１店舗合計数量」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1tenpogokei_su" CssClass="inpReadonlyRight inpRONumCmaMinus8" runat="server"></asp:TextBox>
										</div>
										<div class="col9k detail_right">
											<!--- 「ｍ１店舗合計原価金額」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1tenpogokei_genka_kin" CssClass="inpReadonlyRight inpRONumCmaMinus9" runat="server"></asp:TextBox>
										</div>

										<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
										<div style="display:none">
												<!--- 「Ｍ１店舗名リンク」ボタン --->
												<input type="button" id="M1tenpo_nm" value="" onserverclick="OnM1TENPO_NM_FRM" runat="server" class="btn type-01"/>
											<div class="col14">
												<!--- 「ｍ１選択フラグ(隠し)」チェックボックス --->
												<adv:AdvancedCheckBox ID="M1selectorcheckbox" Text="" CssClass="" runat="server"></adv:AdvancedCheckBox>
											</div>
											<div class="col15">
												<!--- 「Ｍ１確定処理フラグ(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1entersyoriflg" runat="server"></asp:hiddenfield>
											</div>
											<div class="col16">
												<!--- 「Ｍ１明細色区分(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1dtlirokbn" runat="server"></asp:hiddenfield>
											</div>
										</div>
										<!--- 隠し項目エリア↑↑↑↑↑↑↑↑↑↑↑↑↑ --->
									<!-- /str-result-item-01 --></div>
								</ItemTemplate>
							</asp:Repeater>
						<!-- /str-result-item-wrap --></div>
						<span class="adjust-elem-next"></span>
						<div id="str-ftr-area" class="str-result-ftr-01">
							<div class="col1 detail_left">&nbsp;</div>
							<div class="col2 detail_left">&nbsp;</div>
							<div class="col3 detail_left">&nbsp;</div>
							<div class="col4 detail_left">&nbsp;</div>
							<div class="col5 detail_left">&nbsp;</div>
							<div class="col6 detail_left">&nbsp;</div>
							<div class="col7 detail_left">&nbsp;</div>
							<div class="col8 detail_ftr_title"><asp:Label ID="Gokei_suryo_lbl" runat="server">合計</asp:Label></div>
							<div class="col9s detail_ftr">
								<span>
									<!--- 「合計数量」テキストボックスリードオンリー --->
									<asp:TextBox ID="Gokei_suryo" CssClass="inpReadonlyRight inpRONumCmaMinus8" runat="server"></asp:TextBox>
								</span>
							</div>
							<div class="col9k detail_ftr">
								<span>
									<!--- 「原価金額合計」テキストボックスリードオンリー --->
									<asp:TextBox ID="Genka_kin_gokei" CssClass="inpReadonlyRight inpRONumCmaMinus9" runat="server"></asp:TextBox>
								</span>
							</div>
						<!-- /str-result-ftr-01 --></div>
					<!-- /str-result-01 --></div>
				<!-- /inner --></div>
					<!------------------------------------------
					  □ページャ下部領域
					-------------------------------------------->
				<div id="footerBtnArea" class="pad0" runat="server">
					<div id="str-pager-bottom" class="footer str-pager-01 pad0">
						<p>
						</p>
						<p>
							<!-- ページャ下部にボタンを配置する場合はこの中 -->
							<!--- 「確定ボタン」ボタン --->
							<input type="button" id="Btnenter" value="確定" onserverclick="OnBTNENTER_DBU" runat="server" class="btn type-01"/>
						</p>
					<!-- /str-pager-01 --></div>
				<!-- /footerBtnArea --></div>
			<!-- /str-wrap-result -->
		<!-- /wrap --></div>

		<!-- 画面上隠しエレメントを格納するエリア-->
		<div id="hiddenElements" style="display:none" runat="server">
			<asp:Label ID="Head_tenpo_cd_lbl" runat="server">店舗</asp:Label>
			<asp:Label ID="Head_tenpo_cd_Req" runat="server" CssClass="required">*</asp:Label>
			<asp:Label ID="Head_tenpo_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Searchcnt_lbl" runat="server"></asp:Label>
			<!--- 「モードNO」隠しフィールド --->
			<asp:hiddenfield ID="Modeno" runat="server"></asp:hiddenfield>
			<!--- 「選択モードNO」隠しフィールド --->
			<asp:hiddenfield ID="Stkmodeno" runat="server"></asp:hiddenfield>
			<asp:Label ID="Tenpo_nm_from_lbl" runat="server"></asp:Label>
			<asp:Label ID="Tenpo_cd_to_lbl" runat="server">店舗TO</asp:Label>
			<asp:Label ID="Tenpo_nm_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Genka_kin_gokei_lbl" runat="server"></asp:Label>
		</div>
	
	</form>
</body>
</html>

