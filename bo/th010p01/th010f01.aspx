<%@ Page language="c#" CodeFile="th010f01.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Th010p01.Page.Th010f01Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">商品マスタ検索</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="th010p01" FormId="th010f01" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/th010f01.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="th010p01" FormId="th010f01" runat="server" />

	<!-- Js業務部品のインポート --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05001.js" charset="UTF-8"></script><!-- 自社品番丸め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05002.js" charset="UTF-8"></script><!-- スキャンコード丸め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script><!-- 0埋め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05011.js" charset="UTF-8"></script><!-- FROM-TOコピー処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05014.js" charset="UTF-8"></script><!-- 名称取得拡張 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05015.js" charset="UTF-8"></script><!-- 項目制御処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05021.js" charset="UTF-8"></script><!-- パラメータ取得部品 -->

	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02001.js" charset="UTF-8"></script><!-- 店舗検索 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02002.js" charset="UTF-8"></script><!-- 仕入先マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02004.js" charset="UTF-8"></script><!-- 発注マスタ取得(スキャンコード) -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02010.js" charset="UTF-8"></script><!-- 部門マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02011.js" charset="UTF-8"></script><!-- 品種マスタ取得取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02012.js" charset="UTF-8"></script><!-- ブランドマスタ取得 -->

	<!-- 業務共通コントロールのインポート-->
	<%@ Register TagPrefix="uc" TagName="common" Src="~/pjcommon/businessCommon/usercontrol/boCommonControl.ascx" %>
</head>

<body>
	<form id="Th010f01" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="th010p01" PgName="商品マスタ検索" FormId="th010f01" FormName="商品マスタ検索 一覧" ></uc:Header>

			<!------------------------------------------
				□業務共通コントロール
			------------------------------------------->
			<uc:common ID="bocommon" runat="server"></uc:common>
		

			<!------------------------------------------
				□ヘッダー部
			-------------------------------------------->
			<!--- 「ヘッダ店舗コード」一行テキストボックス（セパレート日付以外） --->
			<!--- 「ヘッダ店舗コードボタン」ボタン --->
			<!--- 「ヘッダ店舗名」テキストボックスリードオンリー --->
			<p class="headerTenpo">
					<span class="icon-in">
						<md:MDTextBox ID="Head_tenpo_cd" CssClass="inpSerch inpHeaderTenpo" runat="server"></md:MDTextBox>
							<input type="button" id="Btnheadtenpocd" name="Btnheadtenpocd" value="" runat="server" class="icon-search"/>
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
						<!--- 「モード自社品番ボタン」リンク --->
						<a id="Btnmodejishahinban" href="#tab26" class="" runat="server">自社品番</a>
					</li>
					<li>
						<!--- 「モードスキャンコードボタン」リンク --->
						<a id="Btnmodescancd" href="#tab25" class="" runat="server">スキャンコード</a>
					</li>
					<li>
						<!--- 「モードメーカー品番ボタン」リンク --->
						<a id="Btnmodemakerhbn" href="#tab27" class="" runat="server">メーカー品番</a>
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
								<p id="list-search">
									<!--- 「検索件数」テキストボックスリードオンリー --->
									<p class="txt-02">該当件数<span class="hit-number"><asp:TextBox ID="Searchcnt" CssClass="inpReadonlyRight inpSearchCnt" runat="server"></asp:TextBox></span><span>件</span>
								</p>
							</td>
							</tr>
						</table>
											
					<!-- /inner-01 --></div>
		
					<!------------------------------------------
					  □検索条件領域(入力時)
					-------------------------------------------->
					<div class="inner-02">
						<%--<p class="required">*が付いている項目は必須入力になります。</p>--%>
						<table class="search-table">
						<tr>
						<td class="search-table-tdleft">
						<div class="str-form-02">
							<div class="inner">
								<!--- 「モード自社品番ボタン」--->
								<div id="tab26" class="str-tab-cont">
								<table>
								<col class="w-type-05"/>
								<col />
									<tr>
										<th>
											<span class="tbl-hdg">
												<asp:Label ID="Old_jisya_hbn_from_lbl" runat="server">自社品番</asp:Label>
											</span>
										</th>
										<td>
											<!--- 「旧自社品番from」一行テキストボックス（セパレート日付以外） --->
											<!--- 「旧自社品番to」一行テキストボックス（セパレート日付以外） --->
											<md:MDTextBox ID="Old_jisya_hbn_from" CssClass="inpJishahin10" runat="server"></md:MDTextBox>
											<span class="label-fromto">～</span>
											<md:MDTextBox ID="Old_jisya_hbn_to" CssClass="inpJishahin10" runat="server"></md:MDTextBox>
										</td>
									</tr>
								</table>
								</div>
								<!--- 「モードスキャンコードボタン」--->
								<div id="tab25" class="str-tab-cont">
								<table>
								<col class="w-type-01"/>
								<col />
									<tr><td colspan ="2"><div class="required">*が付いている項目は必須入力になります。</div><td></tr>
									<tr>
										<th>
											<span class="tbl-hdg">
												<asp:Label ID="Scan_cd_lbl" runat="server">スキャンコード</asp:Label><asp:Label ID="Scan_cd_Req" runat="server" CssClass="required">*</asp:Label>
											</span>
											
										</th>
										<td>
											<!--- 「スキャンコード」一行テキストボックス（セパレート日付以外） --->
											<md:MDTextBox ID="Scan_cd" CssClass="inpScanHdg" runat="server"></md:MDTextBox>
										</td>
									</tr>
								</table>
								</div>
								<!--- 「モードメーカー品番ボタン」--->
								<div id="tab27" class="str-tab-cont">
								<table>
								<col class="w-type-01"/>
								<col />
								<tr><td colspan ="2"><div class="required">*が付いている項目は必須入力になります。</div><td></tr>
									<tr>
										<th>
											<span class="tbl-hdg">
												<asp:Label ID="Maker_hbn_lbl" runat="server">メーカー品番</asp:Label><asp:Label ID="Maker_hbn_Req" runat="server" CssClass="required">*</asp:Label>
											</span>
											
										</th>
										<td>
										<!--- 「メーカー品番」一行テキストボックス（セパレート日付以外） --->
										<!--- 「メーカー品番ボタン」ボタン --->
										<span class="icon-in">
											<md:MDTextBox ID="Maker_hbn" CssClass="inpSerch inpMkhin" runat="server"></md:MDTextBox>
											<input type="button" id="Btnmaker_hbn" name="Btnmaker_hbn" value="" runat="server" class="icon-search"/>
										</span>
										</td>
									</tr>
								</table>
								</div>
								<!--- 「モードその他ボタン」--->
								<div  id="tab28" class="str-tab-cont">
								<table>
								<colgroup>
									<col class="w-type-03"/>
									<col class="w-type-02"/>
									<col class="w-type-04"/>
									<col class="w-type-02"/>
									<col class="w-type-05"/>
									<col />
								</colgroup>
								<tr><td colspan="2"><div class="required">*が付いている項目は必須入力になります。</div><td></tr>
									<tr >
										<th>
											<span class="tbl-hdg">
												<asp:Label ID="Bumon_cd_lbl" runat="server">部門</asp:Label><asp:Label ID="Bumon_cd_Req" runat="server" CssClass="required">*</asp:Label>
											</span>
											
										</th>
										<td>
											<!--- 「部門コード」一行テキストボックス（セパレート日付以外） --->
											<!--- 「部門コードボタン」ボタン --->
											<!--- 「部門名」テキストボックスリードオンリー --->
											<span class="icon-in">
											<md:MDTextBox ID="Bumon_cd" CssClass="inpSerch inpBumon" runat="server"></md:MDTextBox>
											<input type="button" id="Btnbumon_cd" name="Btnbumon_cd" value="" runat="server" class="icon-search"/>
											</span>
											<asp:TextBox ID="Bumon_nm" CssClass="inpReadonlyLeft inpROZenkaku10 tooltip" runat="server"></asp:TextBox>
										</td>
										<th>
											<span class="tbl-hdg">
												<asp:Label ID="Hinsyu_cd_lbl" runat="server">品種</asp:Label>
											</span>
										</th>
										<td>
											<!--- 「品種コード」一行テキストボックス（セパレート日付以外） --->
											<!--- 「品種コードボタン」ボタン --->
											<!--- 「品種略名称」テキストボックスリードオンリー --->
											<span class="icon-in">
											<md:MDTextBox ID="Hinsyu_cd" CssClass="inpSerch inpHinshu" runat="server"></md:MDTextBox>
											<input type="button" id="Btnhinsyu_cd" name="Btnhinsyu_cd" value="" runat="server" class="icon-search"/>
											</span>
											<asp:TextBox ID="Hinsyu_ryaku_nm" CssClass="inpReadonlyLeft inpROZenkaku10 tooltip" runat="server"></asp:TextBox>
										</td>
									</tr>
									<tr>
										<th>
											<span class="tbl-hdg">
												<asp:Label ID="Burando_cd_lbl" runat="server">ブランド</asp:Label>
											</span>
										</th>
										<td colspan ="3">
											<!--- 「ブランドコード」一行テキストボックス（セパレート日付以外） --->
											<!--- 「ブランドコードボタン」ボタン --->
											<!--- 「ブランド名」テキストボックスリードオンリー --->
											<span class="icon-in">
											<md:MDTextBox ID="Burando_cd" CssClass="inpSerch inpBrand" runat="server"></md:MDTextBox>
											<input type="button" id="Btnburando_cd" name="Btnburando_cd" value="" runat="server" class="icon-search"/>
											</span>
											<asp:TextBox ID="Burando_nm" CssClass="inpReadonlyLeft inpROHankaku20 tooltip" runat="server"></asp:TextBox>
										</td>
										<th>
											<span class="tbl-hdg">
												<asp:Label ID="Siiresaki_cd_lbl" runat="server">仕入先</asp:Label>
											</span>
										</th>
										<td>
											<!--- 「仕入先コード」一行テキストボックス（セパレート日付以外） --->
											<!--- 「仕入先コードボタン」ボタン --->
											<!--- 「仕入先名称」テキストボックスリードオンリー --->
											<span class="icon-in">
											<md:MDTextBox ID="Siiresaki_cd" CssClass="inpSerch inpShiire" runat="server"></md:MDTextBox>
											<input type="button" id="Btnsiiresaki_cd" name="Btnsiiresaki_cd" value="" runat="server" class="icon-search"/>
											</span>
											<asp:TextBox ID="Siiresaki_ryaku_nm" CssClass="inpReadonlyLeft tooltip" runat="server"></asp:TextBox>
										</td>
									</tr>
									<tr>
										<th>
											<span class="tbl-hdg">
												<asp:Label ID="Genbaika_tnk_from_lbl" runat="server">現売価</asp:Label>
											</span>
										</th>
										<td>
											<!--- 「現売価from」一行テキストボックス（セパレート日付以外） --->
											<!--- 「現売価to」一行テキストボックス（セパレート日付以外） --->
											<md:MDTextBox ID="Genbaika_tnk_from" CssClass="inpSu-08" runat="server"></md:MDTextBox>
											<span class="label-fromto">～</span>
											<md:MDTextBox ID="Genbaika_tnk_to" CssClass="inpSu-08" runat="server"></md:MDTextBox>
										</td>
										<th>
											<span class="tbl-hdg">
												<asp:Label ID="Makerkakaku_tnk_from_lbl" runat="server">ﾒｰｶｰ価格</asp:Label>
											</span>
										</th>
										<td>
											<!--- 「メーカー価格from」一行テキストボックス（セパレート日付以外） --->
											<!--- 「メーカー価格to」一行テキストボックス（セパレート日付以外） --->
											<md:MDTextBox ID="Makerkakaku_tnk_from" CssClass="inpSu-08" runat="server"></md:MDTextBox>
											<span class="label-fromto">～</span>
											<md:MDTextBox ID="Makerkakaku_tnk_to" CssClass="inpSu-08" runat="server"></md:MDTextBox>
										</td>
										<th>
											<span class="tbl-hdg">
												<asp:Label ID="Hanbaikanryo_ymd_from_lbl" runat="server">販売完了日</asp:Label>
											</span>
										</th>
										<td>
											<!--- 「販売完了日from」一行テキストボックス（セパレート日付以外） --->
											<!--- 「販売完了日to」一行テキストボックス（セパレート日付以外） --->
											<span class="icon-in"><md:MDTextBox ID="Hanbaikanryo_ymd_from" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span>
											<span class="label-fromto">～</span>
											<span class="icon-in"><md:MDTextBox ID="Hanbaikanryo_ymd_to" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span>
										</td>
									</tr>
								</table>
								</div>
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
			<%--<!-- /tab1 --></div>--%>

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
					<div id="meisaiBtnArea" class="inner pad0" runat="server">
					<ul>
						<!--明細制御系ボタンを配置する場合はこのulタグの中-->
						<li>
							<!--- 「商品マスタ検索選択」ラジオボタン --->
							<adv:ConditionRBList ID="Syohinmst_serchstk" ConditionName="syohinmst_serchstk1" RepeatDirection="Horizontal" CssClass="str-radio-table" runat="server" ForeColor="Black"></adv:ConditionRBList>
						</li>
					</ul>
					<ul>
						<!--帳票／CSV系ボタンを配置する場合はこのulタグの中-->
						<li>
							<!--- 「CSV出力ボタン」ボタン --->
							<span><label><input type="button" id="Btncsv" value="" onserverclick="OnBTNCSV_FRM" runat="server" class="icon-utility-05" />CSV出力</label></span>
						</li>
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
							<div class="col2 col_2dan">
								<asp:Label ID="M1siiresaki_cd_lbl" runat="server">仕入先</asp:Label>
							</div>
							<div class="col3">
								<div><asp:Label ID="M1bumon_cd_lbl" runat="server">部門</asp:Label></div>
								<div><asp:Label ID="M1hinsyu_cd_lbl" runat="server">品種</asp:Label></div>
							</div>
							<div class="col4">
								<div><asp:Label ID="M1burando_nm_lbl" runat="server">ブランド</asp:Label></div>
								<div><asp:Label ID="M1jisya_hbn_lbl" runat="server">自社品番</asp:Label></div>
							</div>
							<div class="col5 col_2dan">
								<asp:Label ID="M1syohin_zokusei_lbl" runat="server">コア</asp:Label>
							</div>
							<div class="col6">
								<div><asp:Label ID="M1maker_hbn_lbl" runat="server">メーカー品番</asp:Label></div>
								<div><asp:Label ID="M1syonmk_lbl" runat="server">商品名</asp:Label></div>
							</div>
							<div class="col7 col_2dan">
								<asp:Label ID="M1iro_nm_lbl" runat="server">色</asp:Label>
							</div>
							<div class="col8">
								<div><asp:Label ID="M1hanbaikanryo_ymd_lbl" runat="server">販売完了日</asp:Label></div>
								<div><asp:Label ID="M1zeiritsu_lbl" runat="server">税率</asp:Label></div>
							</div>
							<div class="col9">
								<div><asp:Label ID="M1saisinbaika_tnk_lbl" runat="server">最新売価</asp:Label></div>
								<div><asp:Label ID="M1genka_lbl" runat="server">原価</asp:Label></div>
							</div>
							<div class="col10">
								<div><asp:Label ID="M1genbaika_tnk_lbl" runat="server">現売価</asp:Label></div>
								<div><asp:Label ID="M1makerkakaku_tnk_lbl" runat="server">ﾒｰｶｰ価格</asp:Label></div>
							</div>


							<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
							<div style="display: none">
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

						<!-- /str-result-hdg-01 --></div>
						<div id="str-result-item-wrap" class="adjust-elem">
							<asp:Repeater ID="M1" runat="server">
								<HeaderTemplate>
								</HeaderTemplate>
								<ItemTemplate>
									<div class="str-result-item-01">
										<div class="col1 col_2dan detail_right">
											<!--- 「ｍ１行no」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1rowno" CssClass="inpReadonlyRight inpRONum3" runat="server"></asp:TextBox>
										</div>
										<div class="col2 col_2dan detail_left" style="line-height:inherit">
											<!--- 「ｍ１仕入先コード」テキストボックスリードオンリー --->
											<!--- 「ｍ１仕入先名称」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1siiresaki_cd" CssClass="inpReadonlyLeft inpRONum4" runat="server"></asp:TextBox>
											<asp:TextBox ID="M1siiresaki_ryaku_nm" CssClass="inpReadonlyLeft inpRORightNm inpROZenkaku8 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col3 detail_left">
											<!--- 「ｍ１部門コード」テキストボックスリードオンリー --->
											<!--- 「ｍ１部門カナ名」テキストボックスリードオンリー --->
											<!--- 「ｍ１品種コード」テキストボックスリードオンリー --->
											<!--- 「ｍ１品種略名称」テキストボックスリードオンリー --->
											<div>
												<asp:TextBox ID="M1bumon_cd" CssClass="inpReadonlyLeft inpRONum3" runat="server"></asp:TextBox>
												<asp:TextBox ID="M1bumonkana_nm" CssClass="inpReadonlyLeft inpRORightNm inpROHankaku12 tooltip" runat="server"></asp:TextBox>
											</div>
											<div>
												<asp:TextBox ID="M1hinsyu_cd" CssClass="inpReadonlyLeft inpRONum2" runat="server"></asp:TextBox>
												<asp:TextBox ID="M1hinsyu_ryaku_nm" CssClass="inpReadonlyLeft inpRORightNm inpROZenkaku10 tooltip" runat="server"></asp:TextBox>
											</div>
										</div>
										<div class="col4 detail_left">
											<!--- 「ｍ１ブランド名」テキストボックスリードオンリー --->
											<!--- 「Ｍ１自社品番リンク」ボタン --->
											<!--- 「Ｍ１旧自社品番リンク」ボタン --->
											<div><asp:TextBox ID="M1burando_nm" CssClass="inpReadonlyLeft inpROHankaku14 tooltip" runat="server"></asp:TextBox></div>
											<div>
												<input type="button" id="M1jisya_hbn" value="自社品番" onserverclick="OnM1JISYA_HBN_FRM" runat="server" class="meisaiLink"/><input type="button" id="M1old_jisya_hbn" value="" onserverclick="OnM1OLD_JISYA_HBN_FRM" runat="server" class="meisaiLink"/>
											</div>
										</div>
										<div class="col5 col_2dan detail_left">
											<!--- 「ｍ１商品属性」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1syohin_zokusei" CssClass="inpReadonlyLeft inpROHankaku3 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col6 detail_left">
											<!--- 「ｍ１メーカー品番」テキストボックスリードオンリー --->
											<!--- 「ｍ１商品名(カナ)」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1maker_hbn" CssClass="inpReadonlyLeft inpROHankaku30 tooltip" runat="server"></asp:TextBox></div>
											<div><asp:TextBox ID="M1syonmk" CssClass="inpReadonlyLeft inpROHankaku20 tooltip" runat="server"></asp:TextBox></div>
										</div>
										<div class="col7 col_2dan detail_left">
											<!--- 「ｍ１色」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1iro_nm" CssClass="inpReadonlyLeft inpROHankaku6 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col8 detail_center">
											<!--- 「ｍ１販売完了日」テキストボックスリードオンリー --->
											<!--- 「ｍ1税率」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1hanbaikanryo_ymd" CssClass="inpReadonlyCenter inpDt" runat="server"></asp:TextBox></div>
											<div><asp:TextBox ID="M1zeiritsu" CssClass="inpReadonlyRight inpRONumCma8" runat="server"></asp:TextBox></div>
										</div>
										<div class="col9 detail_right">
											<!--- 「ｍ１最新売価」テキストボックスリードオンリー --->
											<!--- 「ｍ１原価」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1saisinbaika_tnk" CssClass="inpReadonlyRight inpRONumCma8" runat="server"></asp:TextBox></div>
											<div><asp:TextBox ID="M1genka" CssClass="inpReadonlyRight inpRONumCma8" runat="server"></asp:TextBox></div>
										</div>
										<div class="col10 detail_right">
											<!--- 「ｍ１現売価」テキストボックスリードオンリー --->
											<!--- 「ｍ１メーカー価格」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1genbaika_tnk" CssClass="inpReadonlyRight inpRONumCma8" runat="server"></asp:TextBox></div>
											<div><asp:TextBox ID="M1makerkakaku_tnk" CssClass="inpReadonlyRight inpRONumCma8" runat="server"></asp:TextBox></div>
										</div>
										<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
										<div style="display: none">
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
						</p>
					<!-- /str-pager-01 --></div>
				<!-- /footerBtnArea --></div>
			<!-- /str-wrap-result --></div>
		<!-- /wrap --></div>	
		
		<!-- 画面上隠しエレメントを格納するエリア-->
		<div id="hiddenElements" style="display:none" runat="server">
			<asp:Label ID="Head_tenpo_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Head_tenpo_cd_lbl" runat="server">店舗</asp:Label>
			<asp:Label ID="Head_tenpo_cd_Req" runat="server" CssClass="required">*</asp:Label>
			<asp:Label ID="Old_jisya_hbn_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Bumon_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Hinsyu_ryaku_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Burando_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Siiresaki_ryaku_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Genbaika_tnk_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Makerkakaku_tnk_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Hanbaikanryo_ymd_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="M1siiresaki_ryaku_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="M1bumonkana_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="M1hinsyu_ryaku_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="M1old_jisya_hbn_lbl" runat="server"></asp:Label>
			<!--- 「モードNO」隠しフィールド --->
			<asp:hiddenfield ID="Modeno" runat="server"></asp:hiddenfield>
			<!--- 「選択モードNO」隠しフィールド --->
			<asp:hiddenfield ID="Stkmodeno" runat="server"></asp:hiddenfield>
			<asp:Label ID="Searchcnt_lbl" runat="server"></asp:Label>
			<asp:Label ID="Syohinmst_serchstk_lbl" runat="server">商品マスタ検索選択</asp:Label>
		</div>
	
	</form>
</body>
</html>

