<%@ Page language="c#" CodeFile="tj040f02.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Tj040p01.Page.Tj040f02Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">棚卸検索</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="tj040p01" FormId="tj040f02" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/tj040f02.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="tj040p01" FormId="tj040f02" runat="server" />
	
	<!-- Js業務部品のインポート --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02004.js" charset="UTF-8"></script><!-- スキャンコードチェック処理 -->

	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05002.js" charset="UTF-8"></script><!-- スキャンコード丸め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05003.js" charset="UTF-8"></script><!-- 明細背景色変更処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script><!-- 0埋め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05010.js" charset="UTF-8"></script><!-- カンマ編集処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05011.js" charset="UTF-8"></script><!-- FROM-TOコピー処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05014.js" charset="UTF-8"></script><!-- 名称取得拡張 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05019.js" charset="UTF-8"></script><!-- 情報ダイアログ表示処理(拡張版) -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05024.js" charset="UTF-8"></script><!-- 数値編集関数群 -->

</head>

<body>
	<form id="Tj040f02" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="tj040p01" PgName="棚卸検索" FormId="tj040f02" FormName="棚卸検索 明細" ></uc:Header>

			<!------------------------------------------
				□ヘッダー部
			-------------------------------------------->
			<p class="headerBackBtn">
				<!--- 「戻るボタン」ボタン --->
				<input type="button" id="Btnback" value="戻る" onserverclick="OnBTNBACK_FRM" runat="server" class="btn type-back"/>
			</p>

			<p class="headerTenpo">
				<!--- 「ヘッダ店舗コード」テキストボックスリードオンリー --->
				<asp:TextBox ID="Head_tenpo_cd" CssClass="inpReadonlyLeft inpHeaderTenpoDisabled" runat="server"></asp:TextBox>
				<!--- 「ヘッダ店舗名」テキストボックスリードオンリー --->
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
						    <col />
						</colgroup>
						<tbody>
							<tr>
							    <th scope="col" class="last">
								    <span class="tbl-hdg">
									    <asp:Label ID="Face_no_lbl" runat="server">フェイスNo</asp:Label>
									    <asp:Label ID="Face_no_Req" runat="server" CssClass="required">*</asp:Label>
								    </span>
							    </th>
								<td class="last">
									<!--- 「フェイス№」一行テキストボックス（セパレート日付以外） --->
									<md:MDTextBox ID="Face_no" CssClass="inpFaceNo" runat="server"></md:MDTextBox>
								</td>
								<th scope="col" class="last">
									<span class="tbl-hdg">
										<asp:Label ID="Tana_dan_lbl" runat="server">棚段</asp:Label>
										<asp:Label ID="Tana_dan_Req" runat="server" CssClass="required">*</asp:Label>
									</span>
								</th>
								<td class="last">
									<!--- 「棚段」一行テキストボックス（セパレート日付以外） --->
									<md:MDTextBox ID="Tana_dan" CssClass="inpTanadan" runat="server"></md:MDTextBox>
								</td>
								<th scope="col" class="last">
									<span class="tbl-hdg">
										<asp:Label ID="Kai_su_lbl" runat="server">回数</asp:Label>
									</span>
								</th>
								<td class="last">
									<!--- 「回数」テキストボックスリードオンリー --->
									<asp:TextBox ID="Kai_su" CssClass="inpReadonlyRight inpRONum2" runat="server"></asp:TextBox>
								</td>
							</tr>
							<tr class="last">
								<th scope="col" class="last">
									<span class="tbl-hdg">
										<asp:Label ID="Tensutanaorosi_su_lbl" runat="server">点数棚卸数量</asp:Label>
									</span>
								</th>
								<td class="last">
									<!--- 「点数棚卸数量」テキストボックスリードオンリー --->
									<asp:TextBox ID="Tensutanaorosi_su" CssClass="inpReadonlyRight inpRONumCmaMinus6" runat="server"></asp:TextBox>
								</td>
								<th scope="col" class="last">
									<span class="tbl-hdg">
										<asp:Label ID="Teisei_suryo_lbl" runat="server">訂正数量</asp:Label>
									</span>
								</th>
								<td class="last">
									<!--- 「訂正数量」一行テキストボックス（セパレート日付以外） --->
									<md:MDTextBox ID="Teisei_suryo" CssClass="inpTeiseiSu" runat="server"></md:MDTextBox>
								</td>
								<th scope="col" class="last">
									<span class="tbl-hdg">
										<asp:Label ID="Gokei_suryo_lbl" runat="server">合計数量</asp:Label>
									</span>
								</th>
								<td class="last">
									<!--- 「合計数量」テキストボックスリードオンリー --->
									<asp:TextBox ID="Gokei_suryo" CssClass="inpReadonlyRight inpRONumCmaMinus6" runat="server"></asp:TextBox>
								</td>
							</tr>
							<tr class="last">
								<th scope="col" class="last">
									<span class="tbl-hdg">
										<asp:Label ID="Tenpo_gyosya_nm_lbl" runat="server">店舗／業者</asp:Label>
									</span>
								</th>
								<td class="last">
									<!--- 「店舗／業者名」テキストボックスリードオンリー --->
									<asp:TextBox ID="Tenpo_gyosya_nm" CssClass="inpReadonlyLeft inpROZenkaku2" runat="server"></asp:TextBox>
								</td>
								<th scope="col" class="last">
									<span class="tbl-hdg">
										<asp:Label ID="Nyuryokutan_cd_lbl" runat="server">入力担当者</asp:Label>
									</span>
								</th>
								<td class="last">
									<!--- 「入力担当者コード」テキストボックスリードオンリー --->
									<asp:TextBox ID="Nyuryokutan_cd" CssClass="inpReadonlyLeft inpRONum7" runat="server"></asp:TextBox>
									<!--- 「入力担当者名称」テキストボックスリードオンリー --->
									<asp:TextBox ID="Nyuryokutan_nm" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
								</td>
								<th scope="col" class="last">
									<span class="tbl-hdg">
										<asp:Label ID="Teiseitan_cd_lbl" runat="server">訂正担当者</asp:Label>
									</span>
								</th>
								<td class="last">
									<!--- 「訂正担当者コード」テキストボックスリードオンリー --->
									<asp:TextBox ID="Teiseitan_cd" CssClass="inpReadonlyLeft inpRONum7" runat="server"></asp:TextBox>
									<!--- 「訂正担当者名称」テキストボックスリードオンリー --->
									<asp:TextBox ID="Teiseitan_nm" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<th scope="col" class="last">
									<span class="tbl-hdg">
										<asp:Label ID="Nyuryoku_ymd_lbl" runat="server">入力日</asp:Label>
									</span>
								</th>
								<td class="last">
									<!--- 「入力日」テキストボックスリードオンリー --->
									<asp:TextBox ID="Nyuryoku_ymd" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox>
								</td>
								<th scope="col" class="last">
									<span class="tbl-hdg">
										<asp:Label ID="Sosin_ymd_lbl" runat="server">送信日</asp:Label>
									</span>
								</th>
								<td class="last">
									<!--- 「送信日」テキストボックスリードオンリー --->
									<asp:TextBox ID="Sosin_ymd" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox>
								</td>
								<th scope="col" class="last">
									<span class="tbl-hdg">
										<asp:Label ID="Riyu_cd_lbl" runat="server">棚卸理由</asp:Label>
									</span>
								</th>
								<td class="last">
									<!--- 「理由コード」ドロップダウンリスト --->
									<md:MDCodeCondition ID="Riyu_cd" FormID="Tj040f02" PgID="Tj040p01" CssClass="slt-ddl slt-riyu" runat="server"></md:MDCodeCondition>
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
				<!-- button -->
				<div id="str-btn-area" class="str-btn-utility">
					<ul>
						<!--明細制御系ボタンを配置する場合はこのulタグの中-->
					</ul>
					<ul>
						<!--帳票／CSV系ボタンを配置する場合はこのulタグの中-->
						<!--- 「印刷ボタン」ボタン --->
						<li><span><label><input type="button" id="Btnprint" value="" onserverclick="OnBTNPRINT_FRM" runat="server" class="icon-utility-04"/>印刷</label></span></li>
					</ul>
				<!-- /utility --></div>

				<div class="inner">
					<div id="str-pager-top" class="str-pager-01">
		
						<!--- 件数表示部 --->
						<!--<p><adv:PageInfo ID="M1PageInfo" runat="server"></adv:PageInfo></p>--->
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
								<div><asp:Label ID="M1hinsyu_ryaku_nm_lbl" runat="server">品種</asp:Label></div>
							</div>
							<div class="col3 col_2dan">
								<asp:Label ID="M1burando_nm_lbl" runat="server">ブランド</asp:Label>
							</div>
							<div class="col4 col_2dan">
								<asp:Label ID="M1jisya_hbn_lbl" runat="server">自社品番</asp:Label>
							</div>
							<div class="col5">
								<div><asp:Label ID="M1maker_hbn_lbl" runat="server">メーカー品番</asp:Label></div>
								<div><asp:Label ID="M1syonmk_lbl" runat="server">商品名</asp:Label></div>
							</div>
							<div class="col6">
								<div><asp:Label ID="M1iro_nm_lbl" runat="server">色</asp:Label></div>
								<div><asp:Label ID="M1size_nm_lbl" runat="server">サイズ</asp:Label></div>
							</div>
							<div class="col7">
								<div><asp:Label ID="M1scan_cd_lbl" runat="server">スキャンコード</asp:Label></div>
								<div><asp:Label ID="M1hyoji_syohin_cd_lbl" runat="server">商品コード</asp:Label></div>
							</div>
							<div class="col8 col_2dan">
								<asp:Label ID="M1scan_su_lbl" runat="server">ｽｷｬﾝ数量</asp:Label>
							</div>
							<div class="col9 col_2dan">
								<asp:Label ID="M1teisei_suryo_lbl" runat="server">訂正数量</asp:Label>
							</div>
							<div class="col10 col_2dan">
								<asp:Label ID="M1gokei_suryo_lbl" runat="server">合計数量</asp:Label>
							</div>

							<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
							<div style="display:none">
							    <div class="col3">
								    <asp:Label ID="M1bumonkana_nm_lbl" runat="server"></asp:Label>
							    </div>

							    <div class="col15">
								    <asp:Label ID="M1teisei_suryo_hdn_lbl" runat="server"></asp:Label>
							    </div>
							    <div class="col17">
								    <asp:Label ID="M1selectorcheckbox_lbl" runat="server"></asp:Label>
							    </div>
							    <div class="col18">
								    <asp:Label ID="M1entersyoriflg_lbl" runat="server"></asp:Label>
							    </div>
							    <div class="col19">
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
                                            <div>
											    <!--- 「ｍ１部門コード」テキストボックスリードオンリー --->
											    <asp:TextBox ID="M1bumon_cd" CssClass="inpReadonlyLeft inpRONum3" runat="server"></asp:TextBox>
											    <!--- 「ｍ１部門カナ名」テキストボックスリードオンリー --->
											    <asp:TextBox ID="M1bumonkana_nm" CssClass="inpReadonlyLeft inpROHankaku12 tooltip" runat="server"></asp:TextBox>
    										</div>
                                            <div>
											    <!--- 「ｍ１品種略名称」テキストボックスリードオンリー --->
											    <asp:TextBox ID="M1hinsyu_ryaku_nm" CssClass="inpReadonlyLeft inpROZenkaku10 tooltip" runat="server"></asp:TextBox>
    										</div>
										</div>
										<div class="col3 col_2dan detail_left">
											<!--- 「ｍ１ブランド名」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1burando_nm" CssClass="inpReadonlyLeft inpROHankaku12 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col4 col_2dan detail_left">
											<!--- 「ｍ１自社品番」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1jisya_hbn" CssClass="inpReadonlyLeft inpRONum8" runat="server"></asp:TextBox>
										</div>
										<div class="col5 detail_left">
                                            <div>
											    <!--- 「ｍ１メーカー品番」テキストボックスリードオンリー --->
											    <asp:TextBox ID="M1maker_hbn" CssClass="inpReadonlyLeft inpROHankaku30 tooltip" runat="server"></asp:TextBox>
                                            </div>
                                            <div>
											    <!--- 「ｍ１商品名(カナ)」テキストボックスリードオンリー --->
											    <asp:TextBox ID="M1syonmk" CssClass="inpReadonlyLeft inpROHankaku20 tooltip" runat="server"></asp:TextBox>
                                            </div>
										</div>
										<div class="col6 detail_left">
                                           <div>
											    <!--- 「ｍ１色」テキストボックスリードオンリー --->
											    <asp:TextBox ID="M1iro_nm" CssClass="inpReadonlyLeft inpROHankaku6 tooltip" runat="server"></asp:TextBox>
                                           </div>
                                           <div>
											    <!--- 「ｍ１サイズ」テキストボックスリードオンリー --->
											    <asp:TextBox ID="M1size_nm" CssClass="inpReadonlyLeft inpROHankaku4 tooltip" runat="server"></asp:TextBox>
                                           </div>
										</div>
										<div class="col7 detail_center">
                                           <div>
											    <!--- 「ｍ１スキャンコード」一行テキストボックス（セパレート日付以外） --->
											    <md:MDTextBox ID="M1scan_cd" CssClass="inpScan" runat="server"></md:MDTextBox>
                                           </div>
                                           <div>
											    <!--- 「ｍ１表示用商品コード」テキストボックスリードオンリー --->
											    <asp:TextBox ID="M1hyoji_syohin_cd" CssClass="inpReadonlyCenter inpROSyohinCd" runat="server"></asp:TextBox>
                                           </div>
										</div>
										<div class="col8 col_2dan detail_right">
											<!--- 「ｍ１スキャン数量」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1scan_su" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
										</div>
										<div class="col9 col_2dan detail_center">
											<!--- 「ｍ１訂正数量」一行テキストボックス（セパレート日付以外） --->
											<md:MDTextBox ID="M1teisei_suryo" CssClass="inpSu-04" runat="server"></md:MDTextBox>
										</div>
										<div class="col10 col_2dan detail_right">
											<!--- 「ｍ１合計数量」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1gokei_suryo" CssClass="inpReadonlyRight inpRONumCmaMinus4" runat="server"></asp:TextBox>
										</div>


										<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
										<div style="display: none">

										    <div class="col10">
											    <!--- 「Ｍ１訂正数量(隠し)」隠しフィールド --->
											    <asp:hiddenfield ID="Hiddenfield1" runat="server"></asp:hiddenfield>
										    </div>
										    <div class="col11">
											    <!--- 「Ｍ１訂正数量(隠し)」隠しフィールド --->
											    <asp:hiddenfield ID="M1teisei_suryo_hdn" runat="server"></asp:hiddenfield>
										    </div>

										    <div class="col17">
											    <!--- 「ｍ１選択フラグ(隠し)」チェックボックス --->
											    <adv:AdvancedCheckBox ID="M1selectorcheckbox" Text="" CssClass="" runat="server"></adv:AdvancedCheckBox>
										    </div>
										    <div class="col18">
											    <!--- 「Ｍ１確定処理フラグ(隠し)」隠しフィールド --->
											    <asp:hiddenfield ID="M1entersyoriflg" runat="server"></asp:hiddenfield>
										    </div>
										    <div class="col19">
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
							<div class="col3 detail_center">&nbsp;</div>
							<div class="col4 detail_left">&nbsp;</div>
							<div class="col5 detail_left">&nbsp;</div>
							<div class="col6 detail_left">&nbsp;</div>
							<div class="col7 detail_ftr_title">合計</div>
							<!--- 「合計スキャン数量」テキストボックスリードオンリー --->
							<div class="col8 detail_ftr"><asp:TextBox ID="Gokeiscan_su" CssClass="inpReadonlyRight inpRONumCmaMinus6" runat="server"></asp:TextBox></div>
							<!--- 「合計訂正数量」テキストボックスリードオンリー --->
							<div class="col9 detail_ftr"><asp:TextBox ID="Gokeiteisei_suryo" CssClass="inpReadonlyRight inpRONumCmaMinus6" runat="server"></asp:TextBox></div>
							<!--- 「総合計数量」テキストボックスリードオンリー --->
							<div class="col10 detail_ftr"><asp:TextBox ID="All_gokei_suryo" CssClass="inpReadonlyRight inpRONumCmaMinus6" runat="server"></asp:TextBox></div>
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

			<asp:Label ID="Nyuryokutan_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Teiseitan_nm_lbl" runat="server"></asp:Label>

			<!--- 「訂正数量(隠し)」隠しフィールド --->
			<asp:hiddenfield ID="Teisei_suryo_hdn" runat="server"></asp:hiddenfield>
			<!--- 「店舗／業者区分」隠しフィールド --->
			<asp:hiddenfield ID="Tenpo_gyosya_kb" runat="server"></asp:hiddenfield>

			<!--- 「モードNO」隠しフィールド --->
			<asp:hiddenfield ID="Modeno" runat="server"></asp:hiddenfield>
			<!--- 「選択モードNO」隠しフィールド --->
			<asp:hiddenfield ID="Stkmodeno" runat="server"></asp:hiddenfield>

			<asp:Label ID="Gokeiscan_su_lbl" runat="server"></asp:Label>
			<asp:Label ID="Gokeiteisei_suryo_lbl" runat="server"></asp:Label>
			<asp:Label ID="All_gokei_suryo_lbl" runat="server"></asp:Label>
		     
		</div>
	
	</form>
</body>
</html>

