<%@ Page language="c#" CodeFile="tl010f02.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Tl010p01.Page.Tl010f02Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">売変検索</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="tl010p01" FormId="tl010f02" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/tl010f02.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="tl010p01" FormId="tl010f02" runat="server" />

	<!-- Js業務部品のインポート --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05003.js" charset="UTF-8"></script><!-- 明細背景色変更処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script><!-- 0埋め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05010.js" charset="UTF-8"></script><!-- カンマ編集処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- タブ選択処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script><!-- 0埋め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05020.js" charset="UTF-8"></script><!-- シール発行処理 -->

</head>

<body>

	<!-- ラベル発行用 ActiveControl ↓↓↓↓↓ -->
	<object id="objMLWebComponent" classid="clsid:C137E319-41FE-4F0F-BD1F-190424FD7E2B" codebase="WebComponent-Installer-ja.exe" style="display:none">WebComponentが使用できません。</object>
	<object id="objFileAccessComponent" type="application/x-oleobject" classid="clsid:A3F14F83-0717-444B-9DE5-BFC3AF5C32E8" style="display:none"></object>
	<!-- ラベル発行用 ActiveControl ↑↑↑↑↑ -->

	<form id="Tl010f02" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="tl010p01" PgName="売変検索" FormId="tl010f02" FormName="売変検索 明細" ></uc:Header>

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
			<div id="tab1" class="str-tab-cont">
				<!-- search-list -->
				<div class="str-search-02">
					<div class="inner-01">
						<!--<p class="required">*が付いている項目は必須入力になります。</p>--->
						<table>
							<colgroup>
								<col class="w-type-01"/>
								<col class="w-type-02"/>
								<col class="w-type-01"/>
								<col class="w-type-02"/>
								<col class="w-type-01"/>
								<col class="w-type-01"/>
								<col class="w-type-01"/>
								<col class="w-type-03"/>
								<col />
							</colgroup>
							<tbody>
								<tr>
									<th scope="col">
										<span class="tbl-hdg">
											<asp:Label ID="Bumon_cd_bo_lbl" runat="server">部門</asp:Label>
										</span>
									</th>
									<td>
										<!--- 「部門コード」テキストボックスリードオンリー --->
										<asp:TextBox ID="Bumon_cd_bo" CssClass="inpReadonlyLeft inpBumon" runat="server"></asp:TextBox>
										<!--- 「部門名」テキストボックスリードオンリー --->
										<asp:TextBox ID="Bumon_nm" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
									</td>
									<th scope="col">
										<span class="tbl-hdg">
											<asp:Label ID="Baihenkaisi_ymd_lbl" runat="server">開始日</asp:Label>
										</span>
									</th>
									<td>
										<!--- 「売変開始日」テキストボックスリードオンリー --->
										<asp:TextBox ID="Baihenkaisi_ymd" CssClass="inpReadonlyLeft inpDt" runat="server"></asp:TextBox>
									</td>
									<th scope="col">
										<span class="tbl-hdg">
											<asp:Label ID="Kaishi_jyotai_nm_lbl" runat="server">開始状態</asp:Label>
										</span>
									</th>
									<td>
										<!--- 「開始状態名称」テキストボックスリードオンリー --->
										<asp:TextBox ID="Kaishi_jyotai_nm" CssClass="inpReadonlyLeft inpROZenkaku4" runat="server"></asp:TextBox>
									</td>
									<th scope="col">
										<span class="tbl-hdg">
											<asp:Label ID="Comment_nm_lbl" runat="server">コメント</asp:Label>
										</span>
									</th>
									<td>
										<!--- 「コメント」テキストボックスリードオンリー --->
										<asp:TextBox ID="Comment_nm" CssClass="inpReadonlyLeft inpROZenkaku20" runat="server"></asp:TextBox>
									</td>
								</tr>
							</tbody>
						</table>
					<!-- /inner-01 --></div>
				<!-- /str-search-02 --></div>
			<!-- /tab1 --></div>

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
						<!--- 「全選択ボタン」ボタン --->
						<li><span><label><input type="button" id="Btnzenstk" value="" onserverclick="OnBTNZENSTK_FRM" runat="server" class="icon-utility-01"/>全選択</label></span></li>
						<!--- 「全解除ボタン」ボタン --->
						<li><span><label><input type="button" id="Btnzenkjo" value="" onserverclick="OnBTNZENKJO_FRM" runat="server" class="icon-utility-02"/>全解除</label></span></li>
						&nbsp;&nbsp;
						<!--- 「出力シール」ラジオボタン --->
						<li><div class="str-syuturyokuseal"><span>出力シール</span></div></li>
						<li><div class="radio-syuturyokuseal">
							<asp:RadioButtonList ID="Shuturyoku_seal" RepeatDirection="Horizontal" CssClass="" runat="server"></asp:RadioButtonList>
							</div>
						</li>
					</ul>
					<ul>
						<!--帳票／CSV系ボタンを配置する場合はこのulタグの中-->
						<!--- 「シール発行ボタン」ボタン --->
						<li><span><label><input type="button" id="Btnseal" value="" onserverclick="OnBTNSEAL_FRM" runat="server" class="icon-utility-04"/>シール発行</label></span></li>
						<!--- 「ラベル発行機コードボタン」ボタン --->
						<li><span class="icon-in"><input type="button" id="Btnlabel_cd" name="Btnlabel_cd" value="" runat="server" class="icon-search"/></span></li>
						<!--- 「ラベル発行機名」テキストボックスリードオンリー --->
						<asp:TextBox ID="Label_nm" CssClass="inpReadonlyLeft inpLabelNM" runat="server"></asp:TextBox>
						<!--- 「ラベル発行機ＩＤ」隠しフィールド --->
						<asp:hiddenfield ID="Label_cd" runat="server"></asp:hiddenfield>
						<!--- 「ラベル発行機ＩＰ」隠しフィールド --->
						<asp:hiddenfield ID="Label_ip" runat="server"></asp:hiddenfield>
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
								<div><asp:Label ID="M1burando_nm_lbl" runat="server">ブランド</asp:Label></div>
								<div><asp:Label ID="M1jisya_hbn_lbl" runat="server">自社品番</asp:Label></div>
							</div>
							<div class="col3">
								<div><asp:Label ID="M1maker_hbn_lbl" runat="server">メーカー品番</asp:Label></div>
								<div><asp:Label ID="M1syonmk_lbl" runat="server">商品名</asp:Label></div>
							</div>
							<div class="col4 col_2dan">
								<asp:Label ID="M1iro_nm_lbl" runat="server">色</asp:Label>
							</div>
							<div class="col5 col_2dan">
								<asp:Label ID="M1gen_tnk_lbl" runat="server">原単価</asp:Label>
							</div>
							<div class="col6 col_2dan">
								<asp:Label ID="M1genbaika_tnm1k_lbl" runat="server">現売価</asp:Label>
							</div>
							<div class="col6 col_2dan">
								<asp:Label ID="M1mtobaika_tnk_lbl" runat="server">元売価</asp:Label>
							</div>
							<div class="col7 col_2dan">
								<asp:Label ID="M1shinbaika_tnk_lbl" runat="server">新売価</asp:Label>
							</div>
							<div class="col8">
								<div><asp:Label ID="M1neire_rtu_genko_lbl" runat="server">値入率現行</asp:Label></div>
								<div><asp:Label ID="M1neire_rtu_baihengo_lbl" runat="server">値入率売変後</asp:Label></div>
							</div>
							<div class="col9">
								<div><asp:Label ID="M1zaiko_su_lbl" runat="server">在庫点数</asp:Label></div>
								<div><asp:Label ID="M1uriage_su_lbl" runat="server">売上点数</asp:Label></div>
							</div>

							<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
							<div style="display:none">

								<div class="col15">
									<asp:Label ID="M1selectorcheckbox_lbl" runat="server"></asp:Label>
								</div>
								<div class="col16">
									<asp:Label ID="M1entersyoriflg_lbl" runat="server"></asp:Label>
								</div>
								<div class="col17">
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
											<asp:TextBox ID="M1rowno" CssClass="inpReadonlyRight inpRONum3" runat="server"></asp:TextBox>
										</div>
										<div class="col2 detail_left">
                                            <div>
												<!--- 「ｍ１ブランド名」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1burando_nm" CssClass="inpReadonlyLeft inpROHankaku12 tooltip" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="detail_center">
												<!--- 「ｍ１自社品番」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1jisya_hbn" CssClass="inpReadonlyLeft inpRONum8" runat="server"></asp:TextBox>
                                            </div>
										</div>
										<div class="col3 detail_left">
                                            <div>
												<!--- 「ｍ１メーカー品番」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1maker_hbn" CssClass="inpReadonlyLeft inpROHankaku30 tooltip" runat="server"></asp:TextBox>
                                            </div>
                                            <div>
												<!--- 「ｍ１商品名(カナ)」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1syonmk" CssClass="inpReadonlyLeft inpROHankaku20 tooltip" runat="server"></asp:TextBox>
                                            </div>
										</div>
										<div class="col4 col_2dan detail_left">
											<!--- 「ｍ１色」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1iro_nm" CssClass="inpReadonlyLeft inpROHankaku6 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col5 col_2dan detail_right">
											<!--- 「ｍ１原単価」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1gen_tnk" CssClass="inpReadonlyRight inpRONumCma7" runat="server"></asp:TextBox>
										</div>
										<div class="col6 col_2dan detail_right">
											<!--- 「ｍ１現売価」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1genbaika_tnm1k" CssClass="inpReadonlyRight inpRONumCma7" runat="server"></asp:TextBox>
										</div>
										<div class="col7 col_2dan detail_right">
											<!--- 「ｍ１元売価」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1mtobaika_tnk" CssClass="inpReadonlyRight inpRONumCma7" runat="server"></asp:TextBox>
										</div>
										<div class="col8 col_2dan detail_right">
											<!--- 「ｍ１新売価」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1shinbaika_tnk" CssClass="inpReadonlyRight inpRONumCma7" runat="server"></asp:TextBox>
										</div>
										<div class="col9 detail_right">
                                            <div>
												<!--- 「ｍ１値入率現行」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1neire_rtu_genko" CssClass="inpReadonlyRight inpRONumCma4" runat="server"></asp:TextBox>
                                            </div>
                                            <div>
												<!--- 「ｍ１値入率売変後」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1neire_rtu_baihengo" CssClass="inpReadonlyRight inpRONumCma4" runat="server"></asp:TextBox>
                                            </div>
										</div>
										<div class="col10 detail_right">
                                            <div>
												<!--- 「ｍ１在庫数」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1zaiko_su" CssClass="inpReadonlyRight inpRONumCmaMinus5" runat="server"></asp:TextBox>
                                            </div>
                                            <div>
												<!--- 「ｍ１売上数」テキストボックスリードオンリー --->
												<asp:TextBox ID="M1uriage_su" CssClass="inpReadonlyRight inpRONumCma7" runat="server"></asp:TextBox>
                                            </div>
										</div>

										<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
										<div style="display: none">

											<div class="col15">
												<!--- 「ｍ１選択フラグ(隠し)」チェックボックス --->
												<adv:AdvancedCheckBox ID="M1selectorcheckbox" Text="" CssClass="" runat="server"></adv:AdvancedCheckBox>
											</div>
											<div class="col16">
												<!--- 「Ｍ１確定処理フラグ(隠し)」隠しフィールド --->
												<asp:hiddenfield ID="M1entersyoriflg" runat="server"></asp:hiddenfield>
											</div>
											<div class="col17">
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
			<asp:Label ID="Head_tenpo_cd_lbl" runat="server"></asp:Label>

			<asp:Label ID="Bumon_nm_lbl" runat="server"></asp:Label>

			<asp:Label ID="Label_nm_lbl" runat="server"></asp:Label>
		     <span class="tbl-hdg"><asp:Label ID="Shuturyoku_seal_lbl" runat="server">出力シール</asp:Label></span>
		</div>
	
	</form>
</body>
</html>

