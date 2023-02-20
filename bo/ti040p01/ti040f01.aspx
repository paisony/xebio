<%@ Page language="c#" CodeFile="ti040f01.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Ti040p01.Page.Ti040f01Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">ラベルプリンタ管理</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="ti040p01" FormId="ti040f01" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/ti040f01.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="ti040p01" FormId="ti040f01" runat="server" />

	<!-- Js業務部品のインポート --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05003.js" charset="UTF-8"></script><!-- 明細背景色変更処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script><!-- 0埋め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02001.js" charset="UTF-8"></script><!-- 店舗検索 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05011.js" charset="UTF-8"></script><!-- FROM-TOコピー処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05019.js" charset="UTF-8"></script><!-- 情報ダイアログ表示処理 -->
</head>

<body>
	<form id="Ti040f01" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="ti040p01" PgName="ラベルプリンタ管理" FormId="ti040f01" FormName="ラベルプリンタ管理" ></uc:Header>

			<p class="headerTenpo">
				<span class="icon-in">
					<!--- 「ヘッダ店舗コード」一行テキストボックス（セパレート日付以外） --->
					<md:MDTextBox ID="Head_tenpo_cd" CssClass="inpSerch inpHeaderTenpo" runat="server"></md:MDTextBox>
					<!--- 「ヘッダ店舗コードボタン」ボタン --->
					<input type="button" id="Btnheadtenpocd" name="Btnheadtenpocd" value="" runat="server" class="icon-search"/>
				</span>
			    <!--- 「ヘッダ店舗名」テキストボックスリードオンリー --->
			    <asp:Label ID="Head_tenpo_nm_lbl" runat="server"></asp:Label>
			    <asp:TextBox ID="Head_tenpo_nm" CssClass="inpReadonlyLeft inpHeaderTenpoNm" runat="server"></asp:TextBox>
			</p>

		<!-------------------------------------------------------------------
								1.カード部
		--------------------------------------------------------------------->
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
										<th scope="col" style="white-space:nowrap">
											<span class="tbl-hdg">
												<asp:Label ID="Label_cd_from_lbl" runat="server">ラベル発行機ＩＤ</asp:Label>
											</span>
										</th>
										<td style="white-space:nowrap">
											<!--- 「ラベル発行機ｉｄｆｒｏｍ」一行テキストボックス（セパレート日付以外） --->
											<!--- 「ラベル発行機ｉｄｆｒｏｍ2」一行テキストボックス（セパレート日付以外） --->
											<!--- 「ラベル発行機ｉｄｔｏ」一行テキストボックス（セパレート日付以外） --->
											<!--- 「ラベル発行機ｉｄｔｏ2」一行テキストボックス（セパレート日付以外） --->
											<md:MDTextBox ID="Label_cd_from" CssClass="inpLabelID1 margin-zero" runat="server"></md:MDTextBox><span class="label-hihun">‐</span><md:MDTextBox ID="Label_cd_from2" CssClass="inpLabelID2" runat="server"></md:MDTextBox>
                                            <span class="label-fromto">～</span>
                                            <md:MDTextBox ID="Label_cd_to" CssClass="inpLabelID1 margin-zero" runat="server"></md:MDTextBox><span class="label-hihun">‐</span><md:MDTextBox ID="Label_cd_to2" CssClass="inpLabelID2" runat="server"></md:MDTextBox>
										</td>
										<th scope="col" style="white-space:nowrap">
											<span class="tbl-hdg">
												<asp:Label ID="Label_ip_from_lbl" runat="server">ラベル発行機ＩＰ</asp:Label>
											</span>
										</th>
										<td>
											<!--- 「ラベル発行機ｉｐｆｒｏｍ」一行テキストボックス（セパレート日付以外） --->
											<md:MDTextBox ID="Label_ip_from" CssClass="inpPrinterID multiinput2" runat="server"></md:MDTextBox>
											<!--- 「ラベル発行機ｉｐｆｒｏｍ2」一行テキストボックス（セパレート日付以外） --->
											<md:MDTextBox ID="Label_ip_from2" CssClass="inpPrinterID multiinput2" runat="server"></md:MDTextBox>
											<!--- 「ラベル発行機ｉｐｆｒｏｍ3」一行テキストボックス（セパレート日付以外） --->
											<md:MDTextBox ID="Label_ip_from3" CssClass="inpPrinterID multiinput2" runat="server"></md:MDTextBox>
											<!--- 「ラベル発行機ｉｐｆｒｏｍ4」一行テキストボックス（セパレート日付以外） --->
											<md:MDTextBox ID="Label_ip_from4" CssClass="inpPrinterID multiinput2" runat="server"></md:MDTextBox>
                                            <span class="label-fromto">～</span>
											<!--- 「ラベル発行機ｉｐｔｏ」一行テキストボックス（セパレート日付以外） --->
											<md:MDTextBox ID="Label_ip_to" CssClass="inpPrinterID multiinput2" runat="server"></md:MDTextBox>
					    					<!--- 「ラベル発行機ｉｐｔｏ2」一行テキストボックス（セパレート日付以外） --->
						    				<md:MDTextBox ID="Label_ip_to2" CssClass="inpPrinterID multiinput2" runat="server"></md:MDTextBox>
									    	<!--- 「ラベル発行機ｉｐｔｏ3」一行テキストボックス（セパレート日付以外） --->
								    		<md:MDTextBox ID="Label_ip_to3" CssClass="inpPrinterID multiinput2" runat="server"></md:MDTextBox>
							    			<!--- 「ラベル発行機ｉｐｔｏ4」一行テキストボックス（セパレート日付以外） --->
								    		<md:MDTextBox ID="Label_ip_to4" CssClass="inpPrinterID multiinput2" runat="server"></md:MDTextBox>
										</td>
									</tr>
									<tr></tr>
									<tr>
										<th scope="col">
											<span class="tbl-hdg">
												<asp:Label ID="Label_nm_lbl" runat="server">ラベル発行機名</asp:Label>
											</span>
										</th>
										<td>
											<!--- 「ラベル発行機名」一行テキストボックス（セパレート日付以外） --->
											<md:MDTextBox ID="Label_nm" CssClass="inpPCID" runat="server"></md:MDTextBox>
										</td>
										<th scope="col">
											<span class="tbl-hdg">
												<asp:Label ID="Label_biko_lbl" runat="server">備考</asp:Label>
											</span>
										</th>
										<td>
											<!--- 「ラベル備考」一行テキストボックス（セパレート日付以外） --->
											<md:MDTextBox ID="Label_biko" CssClass="inpPcBiko" runat="server"></md:MDTextBox>
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
						<!-- /str-btn-search --></div>
					</td>
				</tr>
			</table>
		    <!-- /inner-02 --></div>
		<!-- /str-search-01 --></div>

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
						<!--- 「行追加ボタン」ボタン --->
						<li><span><label><input type="button" id="Btnrowins" value="" onserverclick="OnBTNROWINS_MADD" runat="server" class="icon-utility-06"/>行追加</label></span></li>
						<!--- 「行削除ボタン」ボタン --->
						<li><span><label><input type="button" id="Btnrowdel" value="" onserverclick="OnBTNROWDEL_FRM" runat="server" class="icon-utility-03"/>行削除</label></span></li>
					</ul>
					<ul>
						<!--帳票／CSV系ボタンを配置する場合はこのulタグの中-->
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
							<div class="col1">
								<asp:Label ID="M1rowno_lbl" runat="server">No.</asp:Label>
							</div>
							<div class="col2">
								<asp:Label ID="M1label_cd_lbl" runat="server">ラベル発行機ID</asp:Label>
								<asp:Label ID="M1label_cd2_lbl" runat="server"></asp:Label>
							</div>
							<div class="col3">
								<asp:Label ID="M1label_ip_lbl" runat="server">ラベル発行機IP</asp:Label>
								<asp:Label ID="M1label_ip2_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1label_ip3_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1label_ip4_lbl" runat="server"></asp:Label>
							</div>
							<div class="col4">
								<asp:Label ID="M1label_nm_lbl" runat="server">ラベル発行機名</asp:Label>
							</div>
							<div class="col5">
								<asp:Label ID="M1label_biko_lbl" runat="server">備考</asp:Label>
							</div>

							<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
							<div style="display:none">
							    <div class="col10">
								    <asp:Label ID="M1selectorcheckbox_lbl" runat="server"></asp:Label>
							    </div>
							    <div class="col11">
								    <asp:Label ID="M1entersyoriflg_lbl" runat="server"></asp:Label>
							    </div>
							    <div class="col12">
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
											<asp:TextBox ID="M1rowno" CssClass="inpReadonlyRight inpRONum4" runat="server"></asp:TextBox>
										</div>
										<div class="col2 detail_center">
											<!--- 「ｍ１ラベル発行機ｉｄ」一行テキストボックス（セパレート日付以外） --->
											<asp:TextBox ID="M1label_cd" CssClass="inpRONum4" runat="server"></asp:TextBox><span class="label-fromto">‐</span>
											<!--- 「ｍ１ラベル発行機ｉｄ2」一行テキストボックス（セパレート日付以外） --->
											<asp:TextBox ID="M1label_cd2" CssClass="inpRONum3" runat="server"></asp:TextBox>
										</div>
										<div class="col3 detail_center">
											<!--- 「ｍ１ラベル発行機ｉｐ」一行テキストボックス（セパレート日付以外） --->
											<asp:TextBox ID="M1label_ip" CssClass="inpPrinterID" runat="server"></asp:TextBox>
											<!--- 「ｍ１ラベル発行機ｉｐ2」一行テキストボックス（セパレート日付以外） --->
											<asp:TextBox ID="M1label_ip2" CssClass="inpPrinterID" runat="server"></asp:TextBox>
											<!--- 「ｍ１ラベル発行機ｉｐ3」一行テキストボックス（セパレート日付以外） --->
											<asp:TextBox ID="M1label_ip3" CssClass="inpPrinterID" runat="server"></asp:TextBox>
											<!--- 「ｍ１ラベル発行機ｉｐ4」一行テキストボックス（セパレート日付以外） --->
											<asp:TextBox ID="M1label_ip4" CssClass="inpPrinterID" runat="server"></asp:TextBox>
										</div>
										<div class="col4 detail_left">
											<!--- 「ｍ１ラベル発行機名」一行テキストボックス（セパレート日付以外） --->
											<asp:TextBox ID="M1label_nm" CssClass="inpPCID" runat="server"></asp:TextBox>
										</div>
										<div class="col5 detail_left">
											<!--- 「ｍ１ラベル備考」一行テキストボックス（セパレート日付以外） --->
											<asp:TextBox ID="M1label_biko" CssClass="inpPcBiko" runat="server"></asp:TextBox>
										</div>

							            <!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
							            <div style="display:none">
										    <div class="col10">
											    <!--- 「ｍ１選択フラグ(隠し)」チェックボックス --->
											    <adv:AdvancedCheckBox ID="M1selectorcheckbox" Text="" CssClass="" runat="server"></adv:AdvancedCheckBox>
										    </div>
										    <div class="col11">
											    <!--- 「Ｍ１確定処理フラグ(隠し)」隠しフィールド --->
											    <asp:hiddenfield ID="M1entersyoriflg" runat="server"></asp:hiddenfield>
										    </div>
										    <div class="col12">
											    <!--- 「Ｍ１明細色区分(隠し)」隠しフィールド --->
											    <asp:hiddenfield ID="M1dtlirokbn" runat="server"></asp:hiddenfield>
										    </div>
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
			<asp:Label ID="Head_tenpo_cd_Req" runat="server" CssClass="required"></asp:Label>

		    <asp:Label ID="Label_cd_from2_lbl" runat="server"></asp:Label>
            <asp:Label ID="Label_cd_to_lbl" runat="server"></asp:Label>
    		<asp:Label ID="Label_cd_to2_lbl" runat="server"></asp:Label>

    		<asp:Label ID="Label_ip_from2_lbl" runat="server"></asp:Label>
			<asp:Label ID="Label_ip_from3_lbl" runat="server"></asp:Label>
			<asp:Label ID="Label_ip_from4_lbl" runat="server"></asp:Label>
			<asp:Label ID="Label_ip_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Label_ip_to2_lbl" runat="server"></asp:Label>
			<asp:Label ID="Label_ip_to3_lbl" runat="server"></asp:Label>
			<asp:Label ID="Label_ip_to4_lbl" runat="server"></asp:Label>

            <asp:Label ID="Searchcnt_lbl" runat="server"></asp:Label>

		</div>
	
	</form>
</body>
</html>

