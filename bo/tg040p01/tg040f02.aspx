<%@ Page language="c#" CodeFile="tg040f02.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Tg040p01.Page.Tg040f02Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">商品ｽﾄｯｸ明細書発行</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="tg040p01" FormId="tg040f02" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/tg040f02.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="tg040p01" FormId="tg040f02" runat="server" />

	<!-- Js業務部品のインポート --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05002.js" charset="UTF-8"></script><!-- スキャンコード丸め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05003.js" charset="UTF-8"></script><!-- 明細背景色変更処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script><!-- 0埋め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05010.js" charset="UTF-8"></script><!-- カンマ編集処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05014.js" charset="UTF-8"></script><!-- 名称取得拡張 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05024.js" charset="UTF-8"></script><!-- 数値編集関数群 -->

	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02004.js" charset="UTF-8"></script><!-- 発注マスタ取得(スキャンコード) -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05020.js" charset="UTF-8"></script><!-- SATOラベルプリンタ発行処理 -->

</head>

<body>
	<!-- ラベル発行用 ActiveControl ↓↓↓↓↓ -->
	<object id="objMLWebComponent" classid="clsid:C137E319-41FE-4F0F-BD1F-190424FD7E2B" codebase="WebComponent-Installer-ja.exe" style="display:none">WebComponentが使用できません。</object>
	<object id="objFileAccessComponent" type="application/x-oleobject" classid="clsid:A3F14F83-0717-444B-9DE5-BFC3AF5C32E8" style="display:none"></object>
	<!-- ラベル発行用 ActiveControl ↑↑↑↑↑ -->

	<form id="Tg040f02" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="tg040p01" PgName="商品ｽﾄｯｸ明細書発行" FormId="tg040f02" FormName="商品ｽﾄｯｸ明細書発行 明細" ></uc:Header>

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
								<th scope="col">
									<span class="tbl-hdg">
										<asp:Label ID="Stock_no_lbl" runat="server">ストックNo.</asp:Label>
									</span>
								</th>
								<td>
									<!--- 「ストック№」テキストボックスリードオンリー --->
									<asp:TextBox ID="Stock_no" CssClass="inpReadonlyLeft inpStockNo" runat="server"></asp:TextBox>
								</td>
								<th scope="col">
									<span class="tbl-hdg">
										<asp:Label ID="Ymd_lbl" runat="server">日付</asp:Label>
									</span>
								</th>
								<td>
									<!--- 「日付」テキストボックスリードオンリー --->
									<asp:TextBox ID="Ymd" CssClass="inpReadonlyLeft" runat="server"></asp:TextBox>
								</td>
								<th scope="col">
									<span class="tbl-hdg">
										<asp:Label ID="Tm_lbl" runat="server">時間</asp:Label>
									</span>
								</th>
								<td>
									<!--- 「時間」テキストボックスリードオンリー --->
									<asp:TextBox ID="Tm" CssClass="inpReadonlyLeft" runat="server"></asp:TextBox>
								</td>
								<th scope="col">
									<span class="tbl-hdg">
										<asp:Label ID="Nyuryokutan_cd_lbl" runat="server">入力担当者</asp:Label>
									</span>
								</th>
								<td>
									<!--- 「入力担当者コード」テキストボックスリードオンリー --->
									<asp:TextBox ID="Nyuryokutan_cd" CssClass="inpReadonlyLeft inpTanto" runat="server"></asp:TextBox>
									<!--- 「入力担当者名称」テキストボックスリードオンリー --->
									<asp:TextBox ID="Nyuryokutan_nm" CssClass="inpReadonlyLeft inpRORightNm" runat="server"></asp:TextBox>
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
							<!--- 「全選択ボタン」ボタン --->
							<span><label><input type="button" id="Btnzenstk" value="" onserverclick="OnBTNZENSTK_FRM" runat="server" class="icon-utility-01"/>全選択</label></span>
						</li>
						<li>
							<!--- 「全解除ボタン」ボタン --->
							<span><label><input type="button" id="Btnzenkjo" value="" onserverclick="OnBTNZENKJO_FRM" runat="server" class="icon-utility-02"/>全解除</label></span>
						</li>
						<li id="BtnrowinsArea" runat="server">
							<!--- 「行追加ボタン」ボタン --->
							<span><label><input type="button" id="Btnrowins" value="" onserverclick="OnBTNROWINS_MADD" runat="server" class="icon-utility-06"/>行追加</label></span>
						</li>
						<li id="BtnpageinsArea" runat="server">
							<!--- 「ページ追加ボタン」ボタン --->
							<span><label><input type="button" id="Btnpageins" value="" onserverclick="OnBTNPAGEINS_MINSX" runat="server" class="icon-utility-06"/>ページ追加</label></span>
						</li>
						<li>
							<!--- 「サイズ選択ボタン」ボタン --->
							<span><label><input type="button" id="Btnsizstk" value="" onserverclick="OnBTNSIZSTK_FRM" runat="server" class="icon-utility-07"/>サイズ選択</label></span>
						</li>
						<li>
							<!--- 「行削除ボタン」ボタン --->
							<span><label><input type="button" id="Btnrowdel" value="" onserverclick="OnBTNROWDEL_FRM" runat="server" class="icon-utility-03"/>行削除</label></span>
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
							<span class="icon-in"><input type="button" id="Btnlabel_cd" name="Btnlabel_cd" value="" runat="server" class="icon-search"/></span>
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
							<div class="col6 col_2dan">
								<asp:Label ID="M1hanbaikanryo_ymd_lbl" runat="server">販売完了日</asp:Label>
							</div>
							<div class="col7">
								<div><asp:Label ID="M1iro_nm_lbl" runat="server">色</asp:Label></div>
								<div><asp:Label ID="M1size_nm_lbl" runat="server">サイズ</asp:Label></div>
							</div>
							<div class="col8 col_2dan">
								<asp:Label ID="M1scan_cd_lbl" runat="server">スキャンコード</asp:Label>
							</div>
							<div class="col9 col_2dan">
								<asp:Label ID="M1suryo_lbl" runat="server">数量</asp:Label>
							</div>

						<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
						<div style="display:none">
							<div class="col14">
								<asp:Label ID="M1suryo_hdn_lbl" runat="server">数量</asp:Label>
							</div>
							<div class="col15">
								<asp:Label ID="M1hinsyu_cd_lbl" runat="server"></asp:Label>
							</div>
							<div class="col16">
								<asp:Label ID="M1selectorcheckbox_lbl" runat="server"></asp:Label>
							</div>
							<div class="col17">
								<asp:Label ID="M1entersyoriflg_lbl" runat="server"></asp:Label>
							</div>
							<div class="col18">
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
											<!--- 「ｍ１部門コード」テキストボックスリードオンリー --->
											<!--- 「ｍ１部門カナ名」テキストボックスリードオンリー --->
											<div>
												<asp:TextBox ID="M1bumon_cd" CssClass="inpReadonlyLeft inpRONum3 inpBumon" runat="server"></asp:TextBox>
												<asp:TextBox ID="M1bumonkana_nm" CssClass="inpReadonlyLeft inpRORightNm inpROHankaku10 tooltip" runat="server"></asp:TextBox>
											</div>
											<!--- 「ｍ１品種略名称」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1hinsyu_ryaku_nm" CssClass="inpReadonlyLeft inpROZenkaku10 tooltip" runat="server"></asp:TextBox></div>
										</div>
										<div class="col3 col_2dan detail_left">
											<!--- 「ｍ１ブランド名」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1burando_nm" CssClass="inpReadonlyLeft inpROHankaku12 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col4 col_2dan detail_center">
											<!--- 「ｍ１自社品番」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1jisya_hbn" CssClass="inpReadonlyCenter inpJishahin10" runat="server"></asp:TextBox>
										</div>
										<div class="col5 detail_left">
											<!--- 「ｍ１メーカー品番」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1maker_hbn" CssClass="inpReadonlyLeft inpROHankaku30 tooltip" runat="server"></asp:TextBox></div>
											<!--- 「ｍ１商品名(カナ)」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1syonmk" CssClass="inpReadonlyLeft inpROHankaku20 tooltip" runat="server"></asp:TextBox></div>
										</div>
										<div class="col6 col_2dan detail_center">
											<!--- 「ｍ１販売完了日」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1hanbaikanryo_ymd" CssClass="inpReadonlyLeft inpDt" runat="server"></asp:TextBox>
										</div>
										<div class="col7 detail_left">
											<!--- 「ｍ１色」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1iro_nm" CssClass="inpReadonlyLeft inpROHankaku6 tooltip" runat="server"></asp:TextBox></div>
											<!--- 「ｍ１サイズ」テキストボックスリードオンリー --->
											<div><asp:TextBox ID="M1size_nm" CssClass="inpReadonlyLeft inpROHankaku4 tooltip" runat="server"></asp:TextBox></div>
										</div>
										<div class="col8 col_2dan detail_center">
											<!--- 「ｍ１スキャンコード」一行テキストボックス（セパレート日付以外） --->
											<md:MDTextBox ID="M1scan_cd" CssClass="inpScan" runat="server"></md:MDTextBox>
										</div>
										<div class="col9 col_2dan detail_center">
											<!--- 「ｍ１数量」一行テキストボックス（セパレート日付以外） --->
											<md:MDTextBox ID="M1suryo" CssClass="inpSu-05" runat="server"></md:MDTextBox>
										</div>

									<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
									<div style="display:none">
										<div class="col14">
											<!--- 「Ｍ１数量_隠し」隠しフィールド --->
											<asp:hiddenfield ID="M1suryo_hdn" runat="server"></asp:hiddenfield>
										</div>
										<div class="col15">
											<!--- 「Ｍ１品種コード」隠しフィールド --->
											<asp:hiddenfield ID="M1hinsyu_cd" runat="server"></asp:hiddenfield>
										</div>
										<div class="col16">
											<!--- 「ｍ１選択フラグ(隠し)」チェックボックス --->
											<adv:AdvancedCheckBox ID="M1selectorcheckbox" Text="" CssClass="" runat="server"></adv:AdvancedCheckBox>
										</div>
										<div class="col17">
											<!--- 「Ｍ１確定処理フラグ(隠し)」隠しフィールド --->
											<asp:hiddenfield ID="M1entersyoriflg" runat="server"></asp:hiddenfield>
										</div>
										<div class="col18">
											<!--- 「Ｍ１明細色区分(隠し)」隠しフィールド --->
											<asp:hiddenfield ID="M1dtlirokbn" runat="server"></asp:hiddenfield>
										</div>
									</div>
									<!--- 隠し項目エリア↑↑↑↑↑↑↑↑↑↑↑↑↑ --->

									<!-- /str-result-item-01 --></div>
								</ItemTemplate>
							</asp:Repeater>
						<!-- /str-result-item-wrap --></div>

						<div id="footerArea" class="str-result-ftr-01 adjust-elem-next">
							<div class="col1 detail_left">&nbsp;</div>
							<div class="col2 detail_left">&nbsp;</div>
							<div class="col3 detail_left">&nbsp;</div>
							<div class="col4 detail_left">&nbsp;</div>
							<div class="col5 detail_left">&nbsp;</div>
							<div class="col6 detail_left">&nbsp;</div>
							<div class="col6 detail_left">&nbsp;</div>
							<div class="col8 detail_ftr_title">
								<span class="tbl-hdg">
									<asp:Label ID="Gokei_suryo_lbl" runat="server">合計</asp:Label>
								</span>
							</div>
							<div class="col9 detail_ftr">
								<!--- 「合計数量」テキストボックスリードオンリー --->
								<asp:TextBox ID="Gokei_suryo" CssClass="inpReadonlyRight inpRONum6" runat="server"></asp:TextBox>
							</div>
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
			<asp:Label ID="Label_nm_lbl" runat="server"></asp:Label>
			<!--- 「ラベル発行機ＩＤ」隠しフィールド --->
			<asp:hiddenfield ID="Label_cd" runat="server"></asp:hiddenfield>
			<!--- 「ラベル発行機ＩＰ」隠しフィールド --->
			<asp:hiddenfield ID="Label_ip" runat="server"></asp:hiddenfield>
			<asp:Label ID="M1bumonkana_nm_lbl" runat="server">部門</asp:Label>
			<!--- 「選択モードNO」隠しフィールド --->
			<asp:hiddenfield ID="Stkmodeno" runat="server"></asp:hiddenfield>
		     
		</div>
	</form>
</body>
</html>

