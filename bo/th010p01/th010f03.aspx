<%@ Page language="c#" CodeFile="th010f03.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Th010p01.Page.Th010f03Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">商品マスタ検索</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="th010p01" FormId="th010f03" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/th010f03.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="th010p01" FormId="th010f03" runat="server" />

	<!-- Js業務部品のインポート --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05003.js" charset="UTF-8"></script><!-- 明細背景色変更処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script><!-- 0埋め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05021.js" charset="UTF-8"></script><!-- パラメータ取得部品 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05020.js" charset="UTF-8"></script><!-- SATOラベルプリンタ発行処理 -->
</head>

<body>
	<!-- ラベル発行用 ActiveControl ↓↓↓↓↓ -->
	<object id="objMLWebComponent" classid="clsid:C137E319-41FE-4F0F-BD1F-190424FD7E2B" codebase="WebComponent-Installer-ja.exe" style="display:none">WebComponentが使用できません。</object>
	<object id="objFileAccessComponent" type="application/x-oleobject" classid="clsid:A3F14F83-0717-444B-9DE5-BFC3AF5C32E8" style="display:none"></object>
	<!-- ラベル発行用 ActiveControl ↑↑↑↑↑ -->

	<form id="Th010f03" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="th010p01" PgName="商品マスタ検索" FormId="th010f03" FormName="商品マスタ検索（サイズ別／プライス）" ></uc:Header>

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
						<col />
					</colgroup>
					<tr>
						<th scope="col" class="last">
							<span class="tbl-hdg"><asp:Label ID="Siiresaki_cd_lbl" runat="server">仕入先</asp:Label></span>
						</th>
						<td colspan="3" class="last">
							<!--- 「仕入先コード」テキストボックスリードオンリー --->
							<!--- 「仕入先略式名称」テキストボックスリードオンリー --->
							<asp:TextBox ID="Siiresaki_cd" CssClass="inpReadonlyLeft inpShiire" runat="server"></asp:TextBox>
							<asp:TextBox ID="Siiresaki_ryaku_nm" CssClass="inpReadonlyLeft inpROZenkaku20" runat="server"></asp:TextBox>
						</td>
						<th scope="col" class="last">
							<span class="tbl-hdg"><asp:Label ID="Bumon_cd_lbl" runat="server">部門</asp:Label></span>
						</th>
						<td class="last">
							<!--- 「部門コード」テキストボックスリードオンリー --->
							<!--- 「部門名」テキストボックスリードオンリー --->
							<asp:TextBox ID="Bumon_cd" CssClass="inpReadonlyLeft inpBumon" runat="server"></asp:TextBox>
							<asp:TextBox ID="Bumon_nm" CssClass="inpReadonlyLeft" runat="server"></asp:TextBox>
						</td>
						<th scope="col" class="last">
							<span class="tbl-hdg"><asp:Label ID="Hinsyu_cd_lbl" runat="server">品種</asp:Label></span>
						</th>
						<td class="last">
							<!--- 「品種コード」テキストボックスリードオンリー --->
							<!--- 「品種略名称」テキストボックスリードオンリー --->
							<asp:TextBox ID="Hinsyu_cd" CssClass="inpReadonlyLeft inpShiire" runat="server"></asp:TextBox>
							<asp:TextBox ID="Hinsyu_ryaku_nm" CssClass="inpReadonlyLeft" runat="server"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<th scope="col" class="last">
							<span class="tbl-hdg"><asp:Label ID="Burando_cd_lbl" runat="server">ブランド</asp:Label></span>
						</th>
						<td colspan="3" class="last">
							<!--- 「ブランドコード」テキストボックスリードオンリー --->
							<!--- 「ブランド名」テキストボックスリードオンリー --->
							<asp:TextBox ID="Burando_cd" CssClass="inpReadonlyLeft inpBrand" runat="server"></asp:TextBox>
							<asp:TextBox ID="Burando_nm" CssClass="inpReadonlyLeft inpROHankaku20" runat="server"></asp:TextBox>
						</td>
						<th scope="col" class="last">
							<span class="tbl-hdg"><asp:Label ID="Jisya_hbn_lbl" runat="server">自社品番</asp:Label></span>
						</th>
						<td colspan="3" class="last">
							<!--- 「自社品番」テキストボックスリードオンリー --->
							<!--- 「旧自社品番」テキストボックスリードオンリー --->
							<!--- 「メーカー品番」テキストボックスリードオンリー --->
							<div>
								<asp:TextBox ID="Jisya_hbn" CssClass="inpReadonlyRight inpCd-08" runat="server"></asp:TextBox>
								<span style="">
									<span id ="KakkoStr" runat="server">(</span>
									<asp:TextBox ID="Old_jisya_hbn" CssClass="inpReadonlyCenter inpRONum10" runat="server"></asp:TextBox>
									<span id ="KakkoEnd" runat="server">)</span>
								</span><asp:TextBox ID="Maker_hbn" CssClass="inpReadonlyLeft inpRORightNm inpMkhin" runat="server"></asp:TextBox>
							</div>
						</td>
					</tr>
					<tr>
						<th scope="col" class="last">
							<span class="tbl-hdg"><asp:Label ID="Syonmk_lbl" runat="server">商品名</asp:Label></span>
						</th>
						<td colspan="3" class="last">
							<!--- 「商品名(カナ)」テキストボックスリードオンリー --->
							<asp:TextBox ID="Syonmk" CssClass="inpReadonlyLeft inpROHankaku20  " runat="server"></asp:TextBox>
						</td>
						<th scope="col" class="last">
							<span class="tbl-hdg"><asp:Label ID="Syohin_zokusei_lbl" runat="server">コア属性</asp:Label></span>
						</th>
						<td class="last">
							<!--- 「商品属性」テキストボックスリードオンリー --->
							<asp:TextBox ID="Syohin_zokusei" CssClass="inpReadonlyLeft inpROHankaku3" runat="server"></asp:TextBox>
						</td>
						<th scope="col" class="last">
							<span class="tbl-hdg"><asp:Label ID="Hanbaikanryo_ymd_lbl" runat="server">販売完了日</asp:Label></span>
						</th>
						<td class="last">
							<!--- 「販売完了日」テキストボックスリードオンリー --->
							<asp:TextBox ID="Hanbaikanryo_ymd" CssClass="inpReadonlyLeft inpDt" runat="server"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<th scope="col" class="last">
							<span class="tbl-hdg"><asp:Label ID="Saisinbaika_tnk_lbl" runat="server">最新売価</asp:Label></span>
						</th>
						<td class="last">
							<!--- 「最新売価」テキストボックスリードオンリー --->
							<asp:TextBox ID="Saisinbaika_tnk" CssClass="inpReadonlyRight inpRONumCma8" runat="server"></asp:TextBox>
						</td>
						<th scope="col" class="last">
							<span class="tbl-hdg"><asp:Label ID="Genka_lbl" runat="server">原価</asp:Label></span>
						</th>
						<td class="last">
							<!--- 「原価」テキストボックスリードオンリー --->
							<asp:TextBox ID="Genka" CssClass="inpReadonlyRight inpRONumCma8" runat="server"></asp:TextBox>
						</td>
						<th scope="col" class="last">
							<span class="tbl-hdg"><asp:Label ID="Genbaika_tnk_lbl" runat="server">現売価</asp:Label></span>
						</th>
						<td class="last">
							<!--- 「現売価」テキストボックスリードオンリー --->
							<asp:TextBox ID="Genbaika_tnk" CssClass="inpReadonlyRight inpRONumCma8" runat="server"></asp:TextBox>
						</td>
						<th scope="col" class="last">
							<span class="tbl-hdg"><asp:Label ID="Makerkakaku_tnk_lbl" runat="server">ﾒｰｶｰ価格</asp:Label></span>
						</th>
						<td  class="last">
							<!--- 「メーカー価格」テキストボックスリードオンリー --->
							<asp:TextBox ID="Makerkakaku_tnk" CssClass="inpReadonlyRight inpRONumCma8" runat="server"></asp:TextBox>
						</td>
					</tr>
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
						<li>
							<span class="tbl-hdg">
								<asp:Label ID="Syutsuryoku_seal_lbl" runat="server" ForeColor="Black">出力シール</asp:Label>
							</span>
						</li>
						<li>
							<!--- 「出力シール」ラジオボタン --->
							<asp:RadioButtonList ID="Syutsuryoku_seal" RepeatDirection="Horizontal" CssClass="str-radio-table" runat="server"></asp:RadioButtonList>
						</li>
						<li></li>
						<li>
							<span class="tbl-hdg">
								<asp:Label ID="Layout_lbl" runat="server" ForeColor="Black">レイアウト</asp:Label>
							</span>
						</li>
						<li>
							<!--- 「レイアウト」ラジオボタン --->
							<adv:ConditionRBList ID="Layout" ConditionName="layout" RepeatDirection="Horizontal" CssClass="str-radio-table" runat="server"></adv:ConditionRBList>
						</li>
					</ul>
					<ul>
						<!--帳票／CSV系ボタンを配置する場合はこのulタグの中-->
						<li>
							<!--- 「シール発行ボタン」ボタン --->
							<span><label><input type="button" id="Btnseal" value="" onserverclick="OnBTNSEAL_FRM" runat="server" class="icon-utility-04"/>シール発行</label></span>
						</li>
						<li>
							<!--- 「ラベル発行機コードボタン」ボタン --->
							<span class="icon-in">
								<input type="button" id="Btnlabel_cd" name="Btnlabel_cd" value="" runat="server" class="icon-search "/>
							</span>
						</li>
						<li>	
							<!--- 「ラベル発行機名」テキストボックスリードオンリー --->
							<asp:TextBox ID="Label_nm" CssClass="inpReadonlyLeft" runat="server"></asp:TextBox>
						</li>
					</ul>
				<!-- /utility --></div>
				<div class="inner">
					<div id="str-pager-top" class="str-pager-01">
		
						<!--- 件数表示部 --->
						<p><adv:PageInfo ID="M1PageInfo" runat="server"></adv:PageInfo></p>
						<!--- ページャーを配置する場合はこの中 --->
		
					<!-- /str-pager-01 --></div>
					<!--一覧-->
					<div class="str-result-01">
					<%-- 明細ヘッダ --%>
						<div class="str-result-hdg-01">
							<div class="col1">
								<asp:Label ID="M1rowno_lbl" runat="server">No.</asp:Label>
							</div>
							<div class="col2">
								<asp:Label ID="M1iro_nm_lbl" runat="server">色</asp:Label>
							</div>
							<div class="col3">
								<asp:Label ID="M1size_nm_lbl" runat="server">サイズ</asp:Label>
							</div>
							<div class="col4">
								<asp:Label ID="M1scan_cd_lbl" runat="server">スキャンコード</asp:Label>
							</div>
							<div class="col5">
								<asp:Label ID="M1maisu_lbl" runat="server">枚数</asp:Label>
							</div>

							<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
							<div style="display: none">
								<div class="col6">
									<asp:Label ID="M1selectorcheckbox_lbl" runat="server"></asp:Label>
								</div>
								<div class="col7">
									<asp:Label ID="M1entersyoriflg_lbl" runat="server"></asp:Label>
								</div>
								<div class="col8">
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
										<div class="col2 detail_left">
											<!--- 「ｍ１色」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1iro_nm" CssClass="inpReadonlyLeft tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col3 detail_left">
											<!--- 「ｍ１サイズ」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1size_nm" CssClass="inpReadonlyLeft tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col4 detail_center">
											<!--- 「ｍ１スキャンコード」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1scan_cd" CssClass="inpReadonlyCenter" runat="server"></asp:TextBox>
										</div>
										<div class="col5 detail_center">
											<!--- 「ｍ１枚数」一行テキストボックス（セパレート日付以外） --->
											<md:MDTextBox ID="M1maisu" CssClass="inpSu-03" runat="server" ></md:MDTextBox>
										</div>

										<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
										<div style="display: none">
											<div class="col6">
												<!--- 「ｍ１選択フラグ(隠し)」チェックボックス --->
												<adv:AdvancedCheckBox ID="M1selectorcheckbox" Text="" CssClass="" runat="server"></adv:AdvancedCheckBox>
											</div>
											<div class="col7">
												<!--- 「Ｍ１確定処理フラグ(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1entersyoriflg" runat="server"></asp:hiddenfield>
											</div>
											<div class="col8">
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
			<asp:Label ID="Head_tenpo_cd_lbl" runat="server"></asp:Label>
			<asp:Label ID="Head_tenpo_nm_lbl" runat="server"></asp:Label>

			<!--- 「選択モードNO」隠しフィールド --->
			<asp:hiddenfield ID="Stkmodeno" runat="server"></asp:hiddenfield>

			<asp:Label ID="Siiresaki_ryaku_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Bumon_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Hinsyu_ryaku_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Burando_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Old_jisya_hbn_lbl" runat="server"></asp:Label>
			<asp:Label ID="Maker_hbn_lbl" runat="server"></asp:Label>

			<!--- 「ラベル発行機ＩＤ」隠しフィールド --->
			<asp:hiddenfield ID="Label_cd" runat="server"></asp:hiddenfield>
			<!--- 「ラベル発行機ＩＰ」隠しフィールド --->
			<asp:hiddenfield ID="Label_ip" runat="server"></asp:hiddenfield>

			<asp:Label ID="Label_nm_lbl" runat="server"></asp:Label>
		     
		</div>
	
	</form>
</body>
</html>

