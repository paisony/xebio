<%@ Page language="c#" CodeFile="ta030f01.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Ta030p01.Page.Ta030f01Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">依頼検索</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="ta030p01" FormId="ta030f01" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/ta030f01.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="ta030p01" FormId="ta030f01" runat="server" />

	<!-- JS業務部品のインポート --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02001.js" charset="UTF-8"></script><!-- 店舗検索 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02002.js" charset="UTF-8"></script><!-- 仕入先マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02005.js" charset="UTF-8"></script><!-- 担当者マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02003.js" charset="UTF-8"></script><!-- 発注マスタ取得(自社品番) -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02004.js" charset="UTF-8"></script><!-- 発注マスタ取得(スキャンコード) -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02010.js" charset="UTF-8"></script><!-- 部門マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02012.js" charset="UTF-8"></script><!-- ブランドマスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05001.js" charset="UTF-8"></script><!-- 自社品番丸め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05002.js" charset="UTF-8"></script><!-- スキャンコード丸め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script><!-- 0埋め処理 -->	
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05011.js" charset="UTF-8"></script><!-- FROM-TOコピー処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05014.js" charset="UTF-8"></script><!-- 名称取得拡張 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05015.js" charset="UTF-8"></script><!-- 項目制御処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05016.js" charset="UTF-8"></script><!-- コード参照出口ルーチン共通処理 -->

	<!-- 業務共通コントロールのインポート-->
	<%@ Register TagPrefix="uc" TagName="common" Src="~/pjcommon/businessCommon/usercontrol/boCommonControl.ascx" %>
		
</head>

<body>
	<form id="Ta030f01" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
            <uc:Header ID="header" runat="server" PgId="ta030p01" PgName="依頼検索" FormId="ta030f01" FormName="依頼検索 一覧" ></uc:Header>


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
					<md:MDTextBox ID="Head_tenpo_cd" CssClass="inpSerch" runat="server"></md:MDTextBox><input type="button" id="Btnheadtenpocd" name="Btnheadtenpocd" value="" runat="server" class="icon-search"/>
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
						<!--- 「モード照会部門別ボタン」リンク --->
						<a id="Btnmoderef_bumon" href="#tab30" class="" runat="server">照会（部門別）</a>
					</li>
					<li>
						<!--- 「モード照会単品別ボタン」リンク --->
						<a id="Btnmoderef_tanpin" href="#tab29" class="" runat="server">照会（単品別）</a>
					</li>

				</ul>
			</div>

			<div id="tab30" class="str-tab-cont"></div>
            <div id="tab29" class="str-tab-cont"></div>
				  
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
									        <th scope="col">
										        <span class="tbl-hdg">
											        <asp:Label ID="Kbn_cd_lbl" runat="server">区分</asp:Label>
										        </span>
									        </th>
									        <td>
										        <!--- 「区分コード」ドロップダウンリスト --->
										        <md:MDConditionDDList ID="Kbn_cd" ConditionName="hojuirai_kbn2" CssClass="ddl-kubun" runat="server"></md:MDConditionDDList>
										        <span class="select-arrow"></span>

									        </td>
									        <th scope="col">
										        <span class="tbl-hdg">
											        <asp:Label ID="Shinsei_flg_lbl" runat="server">状態</asp:Label>
										        </span>
									        </th>
									        <td>
										        <!--- 「申請状態」ドロップダウンリスト --->
										        <md:MDConditionDDList ID="Shinsei_flg" ConditionName="sinsei_jotai" CssClass="ddl-jyoutai" runat="server"></md:MDConditionDDList>
										        <span class="select-arrow"></span>

									        </td>
									        <th scope="col">
										        <span class="tbl-hdg">
											        <asp:Label ID="Siiresaki_cd_lbl" runat="server">仕入先</asp:Label>
										        </span>
									        </th>
									        <td>
												<span class="icon-in">
													<md:MDTextBox ID="Siiresaki_cd" CssClass="inpSerch inpShiire" runat="server"></md:MDTextBox>
														<input type="button" id="Btnsiiresaki_cd" name="Btnsiiresaki_cd" value="" runat="server" class="icon-search"/>
												</span>

										        <!--- 「仕入先略式名称」テキストボックスリードオンリー --->
										        <asp:TextBox ID="Siiresaki_ryaku_nm" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
                                            </td>
								        </tr>
								        <tr>
									        <th scope="col">
										        <span class="tbl-hdg">
											        <asp:Label ID="Bumon_cd_lbl" runat="server">部門</asp:Label>
										        </span>
									        </th>
									        <td>
                                                <span class="icon-in">
										            <!--- 「部門コード」一行テキストボックス（セパレート日付以外） --->
										            <md:MDTextBox ID="Bumon_cd" CssClass="inpSerch inpBumon" runat="server"></md:MDTextBox>
										            <!--- 「部門コードボタン」ボタン --->
										            <input type="button" id="Btnbumon_cd" name="Btnbumon_cd" value="" runat="server" class="icon-search"/>
                                                </span>
                                                <!--- 「部門名」テキストボックスリードオンリー --->
										        <asp:TextBox ID="Bumon_nm" CssClass="inpReadonlyLeft  inpROZenkaku10" runat="server"></asp:TextBox>
                                            </td>
									        <th scope="col">
										        <span class="tbl-hdg">
											        <asp:Label ID="Burando_cd_lbl" runat="server">ブランド</asp:Label>
										        </span>
									        </th>
									        <td colspan="3">
                                                <span class="icon-in">
										            <!--- 「ブランドコード」一行テキストボックス（セパレート日付以外） --->
										            <md:MDTextBox ID="Burando_cd" CssClass="inpSerch inpBrand" runat="server"></md:MDTextBox>
                                                    <!--- 「ブランドコードボタン」ボタン --->
										            <input type="button" id="Btnburando_cd" name="Btnburando_cd" value="" runat="server" class="icon-search"/>
                                                </span>
                                                <!--- 「ブランド名」テキストボックスリードオンリー --->
										        <asp:TextBox ID="Burando_nm" CssClass="inpReadonlyLeft inpROHankaku20" runat="server"></asp:TextBox>
									        </td>
								        </tr>
								        <tr>
									        <th scope="col">
										        <span class="tbl-hdg">
											        <asp:Label ID="Hattyu_ymd_from_lbl" runat="server">発注日</asp:Label>
										        </span>
									        </th>
									        <td colspan="5">
										        <!--- 「発注日from」一行テキストボックス（セパレート日付以外） --->
										        <span class="icon-in">
											        <md:MDTextBox ID="Hattyu_ymd_from" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox>
                                                </span>
                                                    <span class="label-fromto">～</span>
                                                <!--- 「発注日to」一行テキストボックス（セパレート日付以外） --->
                                                <span class="icon-in">
                                                    <md:MDTextBox ID="Hattyu_ymd_to" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox>
										        </span>
									        </td>
								        </tr>
										<tr>
											<th class="last">
												<span class="tbl-hdg"><asp:Label ID="Old_jisya_hbn_lbl" runat="server">自社品番</asp:Label></span>
											</th>
											<!--- 「旧自社品番」一行テキストボックス（セパレート日付以外） --->
											<!--- 「メーカー品番」テキストボックスリードオンリー --->
											<td class="last" colspan="3">
												<md:MDTextBox ID="Old_jisya_hbn" CssClass="inpJishahin10" runat="server"></md:MDTextBox><asp:TextBox ID="Maker_hbn" CssClass="inpReadonlyLeft inpMkhin" runat="server"></asp:TextBox>
											</td>
											<th class="last">
												<span class="tbl-hdg"><asp:Label ID="Scan_cd_lbl" runat="server">ｽｷｬﾝｺｰﾄﾞ</asp:Label></span>
											</th>
											<!--- 「スキャンコード」一行テキストボックス（セパレート日付以外） --->
											<td class="last">
												<md:MDTextBox ID="Scan_cd" CssClass="inpScan" runat="server"></md:MDTextBox>
											</td>
										</tr>
                                    </table>
								<!-- /inner --></div>
							    <!-- /str-form-02 --></div>
						</td>
                    	<td class="search-table-tdright">
							<div class="str-btn-search">
									        
								<!--- 「検索ボタン」ボタン --->
								<input type="button" id="Btnsearch" value="検索" onserverclick="OnBTNSEARCH_FRM" runat="server" class="btn type-02"/>
							</div>
                        </td>
                    </tr>
				</table>
				 <!-- /inner-02 -->
				</div>
			<!-- /str-search-01 -->
			</div>

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
					</ul>
                    <!-- /meisaiBtnArea -->
                    </div>
				<!-- /utility -->
				</div>

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
					<!-- /str-pager-01 -->
					</div>
					<!--一覧-->
					<div class="str-result-01">
					<%-- 明細ヘッダ --%>
						<div class="str-result-hdg-01">
							<div class="col1" >
								<asp:Label ID="M1rowno_lbl" runat="server">No.</asp:Label>
							</div>
							<div class="col2">
								<asp:Label ID="M1hojuirai_kbn_nm_lbl" runat="server">区分</asp:Label>
							</div>
							<div class="col3">
								<asp:Label ID="M1sinsei_jotainm_lbl" runat="server">状態</asp:Label>
							</div>
							<div class="col4">
								<asp:Label ID="M1bumon_cd_bo_lbl" runat="server">部門</asp:Label>
							</div>
							<div class="col5">
								<asp:Label ID="M1itemsu_lbl" runat="server">数量</asp:Label>
							</div>
							<div class="col6">
								<asp:Label ID="M1kingaku_lbl" runat="server">金額</asp:Label>
							</div>
							<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
							<div style="display:none">
							    <div class="col7">
								    <asp:Label ID="M1selectorcheckbox_lbl" runat="server">選択フラグ(隠し)</asp:Label>
							    </div>
							    <div class="col8">
								    <asp:Label ID="M1entersyoriflg_lbl" runat="server">確定処理フラグ(隠し)</asp:Label>
							    </div>
							    <div class="col9">
								    <asp:Label ID="M1dtlirokbn_lbl" runat="server">明細色区分(隠し)</asp:Label>
							    </div>
                            </div>
							<!--- 隠し項目エリア↑↑↑↑↑↑↑↑↑↑↑↑↑ --->
						<!-- /str-result-hdg-01 -->
						</div>
						<div id="str-result-item-wrap" class="adjust-elem">
							<asp:Repeater ID="M1" runat="server">
								<HeaderTemplate>
								</HeaderTemplate>
								<ItemTemplate>
									<div class="str-result-item-01">
										<div class="col1 detail_right">
											<!--- 「ｍ１行no」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1rowno" CssClass="inpReadonlyRight inpRONum3" runat="server"></asp:TextBox>
										</div>
										<div class="col2 detail_left">
											<!--- 「ｍ１補充依頼区分名称」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1hojuirai_kbn_nm" CssClass="inpReadonlyLeft inpROZenkaku7 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col3 detail_left">
											<!--- 「ｍ１申請状態名称」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1sinsei_jotainm" CssClass="inpReadonlyLeft inpROZenkaku4 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col4 detail_left">
											<!--- 「Ｍ１部門リンク」ボタン --->
											<input type="button" id="M1bumon_cd_bo" value="部門" onserverclick="OnM1BUMON_CD_BO_FRM" runat="server" class="meisaiLink"/>
										</div>
										<div class="col5 detail_right">
											<!--- 「ｍ１数量」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1itemsu" CssClass="inpReadonlyRight inpRONumCma9" runat="server"></asp:TextBox>
										</div>
										<div class="col6 detail_right">
											<!--- 「ｍ１金額」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1kingaku" CssClass="inpReadonlyRight inpRONumCma9" runat="server"></asp:TextBox>
										</div>

										<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
										<div style="display:none">

										    <div class="col7">
											    <!--- 「ｍ１選択フラグ(隠し)」チェックボックス --->
											    <adv:AdvancedCheckBox ID="M1selectorcheckbox" Text="" CssClass="" runat="server"></adv:AdvancedCheckBox>
										    </div>
										    <div class="col8">
											    <!--- 「Ｍ１確定処理フラグ(隠し)」隠しフィールド --->
											    <asp:hiddenfield ID="M1entersyoriflg" runat="server"></asp:hiddenfield>
										    </div>
										    <div class="col9">
											    <!--- 「Ｍ１明細色区分(隠し)」隠しフィールド --->
											    <asp:hiddenfield ID="M1dtlirokbn" runat="server"></asp:hiddenfield>
										    </div>
											<div>
												<asp:TextBox ID="M1bumonkana_nm" CssClass="inpReadonlyLeft inpRORightNm inpROHankaku10 " runat="server"></asp:TextBox>
											</div>
                                        </div>
										<!--- 隠し項目エリア↑↑↑↑↑↑↑↑↑↑↑↑↑ --->
									<!-- /str-result-item-01 --></div>
								</ItemTemplate>
							</asp:Repeater>
						<!-- /str-result-item-wrap -->
						</div>
						<span class="adjust-elem-next"></span>
						<div class="str-result-ftr-01">
							<div class="col1 detail_left">&nbsp;</div>
							<div class="col2 detail_left">&nbsp;</div>
							<div class="col3 detail_left">&nbsp;</div>
							<div class="col4 detail_ftr_title">合計</div>
							<!--- 「合計数量」テキストボックスリードオンリー --->
							<div class="col5 detail_ftr"><asp:TextBox ID="Gokei_itemsu" CssClass="inpReadonlyRight inpRONumCma9" runat="server"></asp:TextBox></div>												
							<!--- 「合計金額」テキストボックスリードオンリー --->
							<div class="col6 detail_ftr"><asp:TextBox ID="Gokei_kingaku" CssClass="inpReadonlyRight inpRONumCma9" runat="server"></asp:TextBox></div>
						<!-- /str-result-ftr-01 -->
						</div>
					<!-- /str-result-01 -->
					</div>

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
						</p>
					<!-- /str-pager-01 --></div>
				<!-- /footerBtnArea --></div>
			<!-- /str-wrap-result --></div>
		<!-- /wrap --></div>	
		
		<!-- 画面上隠しエレメントを格納するエリア-->
		<div id="hiddenElements" style="display:none" runat="server">

		
			<asp:Label ID="Head_tenpo_cd_lbl" runat="server"></asp:Label>
			<asp:Label ID="Head_tenpo_cd_Req" runat="server" CssClass="required">*</asp:Label>
            <asp:Label ID="Head_tenpo_nm_lbl" runat="server"></asp:Label>

			<asp:Label ID="Label1" runat="server"></asp:Label>
			<asp:Label ID="Label2" runat="server" CssClass="required">*</asp:Label>
			<asp:Label ID="Label3" runat="server"></asp:Label>
			
			<asp:Label ID="Nyukayotei_ymd_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Siire_kakutei_ymd_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Label4" runat="server"></asp:Label>
			<asp:Label ID="Bumon_nm_from_lbl" runat="server"></asp:Label>
			<asp:Label ID="Bumon_cd_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Bumon_nm_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Denpyo_bango_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Motodenpyo_bango_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Label5" runat="server"></asp:Label>
			<asp:Label ID="Searchcnt_lbl" runat="server"></asp:Label>

			<!--- 「営業日（隠し）」隠しフィールド --->
			<asp:hiddenfield ID="Eigyo_ymd_hdn" runat="server"></asp:hiddenfield>

            <!--- 「モードNO」隠しフィールド --->
			<asp:hiddenfield ID="Modeno" runat="server"></asp:hiddenfield>
			<!--- 「選択モードNO」隠しフィールド --->
			<asp:hiddenfield ID="Stkmodeno" runat="server"></asp:hiddenfield>

            <!--- 「仕入先略式名称」隠しフィールド --->
            <asp:Label ID="Siiresaki_ryaku_nm_lbl" runat="server"></asp:Label>
		    <!--- 「部門名」隠しフィールド --->
            <asp:Label ID="Bumon_nm_lbl" runat="server"></asp:Label>
            <!--- 「ブランド名」隠しフィールド --->
            <asp:Label ID="Burando_nm_lbl" runat="server"></asp:Label>
            <!--- 「発注日TO」隠しフィールド --->
            <asp:Label ID="Hattyu_ymd_to_lbl" runat="server"></asp:Label>
            <!--- 「自社品番(メーカ品番)」隠しフィールド --->
            <asp:Label ID="Maker_hbn_lbl" runat="server"></asp:Label>
            <!--- 「合計数量ラベル)」隠しフィールド --->
            <asp:Label ID="Gokei_itemsu_lbl" runat="server">合計</asp:Label>
            <asp:Label ID="Gokei_kingaku_lbl" runat="server"></asp:Label>

		</div>
	
	</form>
</body>
</html>

