<%@ Page language="c#" CodeFile="tj050f01.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Tj050p01.Page.Tj050f01Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">棚卸報告書再出力</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="tj050p01" FormId="tj050f01" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/tj050f01.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="tj050p01" FormId="tj050f01" runat="server" />

	<!-- Js業務部品のインポート --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02019.js" charset="UTF-8"></script><!-- 店舗、棚卸実施日検索 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
</head>

<body>
	<form id="Tj050f01" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
			<uc:Header ID="header" runat="server" PgId="tj050p01" PgName="棚卸報告書再出力(V)" FormId="tj050f01" FormName="棚卸報告書再出力" ></uc:Header>
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
						<!--- 「モード今回ボタン」リンク --->
						<a id="Btnmodekonkai" href="#tab22" class="" runat="server">今回</a>
					</li>
					<li>
						<!--- 「モード前回ボタン」リンク --->
						<a id="Btnmodezenkai" href="#tab23" class="" runat="server">前回</a>
					</li>
				</ul>
			</div>
			<!-- search-list -->
			<div class="str-search-01">
				<!------------------------------------------
					□検索条件領域(非表示時)
				-------------------------------------------->
					<!-- なし -->						
				
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
										<!-- 今回 -->
										<div id="tab22" class="str-tab-cont">
											<table>
												<colgroup>
													<col class="w-type-01"/>
													<col class="w-type-02"/>
													<col class="w-type-03"/>
													<col class="w-type-04"/>
													<col class="w-type-03"/>
													<col class="w-type-05"/>
													<col class="w-type-03"/>
													<col />
												</colgroup>
												<tbody>
													<tr>
														<th colspan ="2">
															<span class="tbl-hdg">
																<asp:Label ID="Tanaorosijissi_ymd_lbl" runat="server">棚卸実施日</asp:Label>
															</span>
														</th>
														<td>
															<!--- 「今回棚卸実施日」テキストボックスリードオンリー --->
															<asp:TextBox ID="Tanaorosijissi_ymd" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox>
														</td>
														<th>
															<span class="tbl-hdg">
																<asp:Label ID="Tanaorosikikan_from_lbl" runat="server">棚卸期間</asp:Label>
															</span>
														</th>
														<td>
															<!--- 「今回棚卸期間from」テキストボックスリードオンリー --->
															<asp:TextBox ID="Tanaorosikikan_from" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox>
														</td>
														<td>～</td>
														<td>
															<!--- 「今回棚卸期間to」テキストボックスリードオンリー --->
															<asp:TextBox ID="Tanaorosikikan_to" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox>
														</td>
													</tr>
												</tbody>
											</table>
										<!-- 今回 --></div>
										<!-- 前回 -->											
										<div id="tab23" class="str-tab-cont">
											<table>
												<colgroup>
													<col class="w-type-01"/>
													<col class="w-type-02"/>
													<col class="w-type-03"/>
													<col class="w-type-04"/>
													<col class="w-type-03"/>
													<col class="w-type-05"/>
													<col class="w-type-03"/>
													<col />
												</colgroup>
												<tbody>
													<tr>
 														<th colspan ="2">
															<span class="tbl-hdg">
																<asp:Label ID="Tanaorosijissi_ymd1_lbl" runat="server">棚卸実施日</asp:Label>
															</span>
														</th>
														<td>
															<!--- 「前回棚卸実施日」テキストボックスリードオンリー --->
															<asp:TextBox ID="Tanaorosijissi_ymd1" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox>
														</td>
														<th>
															<span class="tbl-hdg">
																<asp:Label ID="Tanaorosikikan_from1_lbl" runat="server">棚卸期間</asp:Label>
															</span>
														</th>
														<td>
															<!--- 「前回棚卸期間from」テキストボックスリードオンリー --->
															<asp:TextBox ID="Tanaorosikikan_from1" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox>
														</td>
														<td>～</td>
														<td>
															<!--- 「前回棚卸期間to」テキストボックスリードオンリー --->
															<asp:TextBox ID="Tanaorosikikan_to1" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox>
														</td>
													</tr>
												</tbody>
											</table>
										<!-- 前回 --></div>
										<!-- ラジオボタン -->
										<table>
											<colgroup>
												<col class="w-type-01"/>
												<col class="w-type-02"/>
												<col class="w-type-03"/>
												<col class="w-type-04"/>
												<col class="w-type-03"/>
												<col class="w-type-05"/>
												<col class="w-type-03"/>
												<col />
											</colgroup>
											<tr>
												<th/>
												<td>
													<!--- 「棚卸報告書区分」ラジオボタン --->
													<adv:ConditionRBList ID="Tanaorosi_hokokusyo_kb" ConditionName="tanaorosi_hokokusyo_v" RepeatDirection="Vertical" CssClass="h-type-01" runat="server"></adv:ConditionRBList>
												</td>
											</tr>
										</table>	
									<!-- /inner --></div>
								<!-- /str-form-02 --></div>
							<!-- /search-table-tdleft --></td>
							<td class="search-table-tdright">
								<div class="str-btn-search"></div>
							</td>
						</tr>
				    <!-- /search-table --></table>
    			<!-- /inner-02 --></div>
    		<!-- /str-search-01 --></div>
      		<!-------------------------------------------------------------------
       								2.明細部
       		--------------------------------------------------------------------->
       		<input id="M1PageStartRow" type="hidden" runat="server"/>
    		<!-- search-result -->
       		<div class="str-wrap-result">
				<!------------------------------------------
					□明細ボタン部
				-------------------------------------------->
       			<div id="str-btn-area" class="str-btn-utility">
       				<div id="meisaiBtnArea" class="inner pad0" runat="server">
       				<ul>
       					<!--明細制御系ボタンを配置する場合はこのulタグの中-->
       				</ul>
       				<ul>
       					<!--帳票／CSV系ボタンを配置する場合はこのulタグの中-->
						<!--- 「印刷ボタン」ボタン --->
       					<span><label><input type="button" id="Btnprint" value="" onserverclick="OnBTNPRINT_FRM" runat="server" class="icon-utility-04"/>印刷</label></span>
       				</ul>
       				<!-- /meisaiBtnArea --></div>
       			<!-- /str-btn-utility --></div>
			<!-- /str-wrap-result --></div>
        <!-- /wrap --></div>

		
		<!-- 画面上隠しエレメントを格納するエリア-->
		<div id="hiddenElements" style="display:none" runat="server">
			<asp:Label ID="Head_tenpo_cd_lbl" runat="server">店舗</asp:Label>
			<asp:Label ID="Head_tenpo_cd_Req" runat="server" CssClass="required">*</asp:Label>
 		    <asp:Label ID="Head_tenpo_nm_lbl" runat="server"></asp:Label>
			<asp:hiddenfield ID="Modeno" runat="server"></asp:hiddenfield>
			<asp:hiddenfield ID="Stkmodeno" runat="server"></asp:hiddenfield>
			<asp:hiddenfield ID="Tanaorosikijun_ymd" runat="server"></asp:hiddenfield>
			<asp:hiddenfield ID="Tanaorosikijun_ymd1" runat="server"></asp:hiddenfield>
			<asp:Label ID="Tanaorosi_hokokusyo_kb_lbl" runat="server"></asp:Label>
			<asp:Label ID="Tanaorosikikan_to_lbl" runat="server"></asp:Label>
			<asp:Label ID="Tanaorosikikan_to1_lbl" runat="server"></asp:Label>
		</div>
	
	</form>
</body>
</html>

