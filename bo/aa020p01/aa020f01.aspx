<%@ Page language="c#" CodeFile="aa020f01.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Aa020p01.Page.Aa020f01Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">■シール発行テスト</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="aa020p01" FormId="aa020f01" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/aa020f01.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="aa020p01" FormId="aa020f01" runat="server" />
	
	<!-- Js業務部品のインポート --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02001.js" charset="UTF-8"></script><!-- 店舗検索 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02002.js" charset="UTF-8"></script><!-- 仕入先マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02005.js" charset="UTF-8"></script><!-- 担当者マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02010.js" charset="UTF-8"></script><!-- 部門マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02012.js" charset="UTF-8"></script><!-- 品種マスタ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05002.js" charset="UTF-8"></script><!-- スキャンコード丸め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script><!-- 0埋め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05009.js" charset="UTF-8"></script><!-- 指示番号丸め処理(返品用) -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05011.js" charset="UTF-8"></script><!-- FROM-TOコピー処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05014.js" charset="UTF-8"></script><!-- 名称取得拡張 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05015.js" charset="UTF-8"></script><!-- 項目制御処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05019.js" charset="UTF-8"></script><!-- 情報ダイアログ表示処理(拡張版) -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05020.js" charset="UTF-8"></script><!-- SATOラベルプリンタ発行処理 -->

</head>

<body>
	<!-- ラベル発行用 ActiveControl ↓↓↓↓↓ -->
	<object id="objMLWebComponent" classid="clsid:C137E319-41FE-4F0F-BD1F-190424FD7E2B" codebase="WebComponent-Installer-ja.exe" style="display:none">WebComponentが使用できません。</object>
	<object id="objFileAccessComponent" type="application/x-oleobject" classid="clsid:A3F14F83-0717-444B-9DE5-BFC3AF5C32E8" style="display:none"></object>
	<!-- ラベル発行用 ActiveControl ↑↑↑↑↑ -->

	<form id="Aa020f01" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="aa020p01" PgName="■シール発行テスト" FormId="aa020f01" FormName="■シール発行テスト" ></uc:Header>
			
		<!-------------------------------------------------------------------
								1.カード部
		--------------------------------------------------------------------->
			<div id="tab1" class="str-tab-cont">
				<!-- search-list -->
				<div class="str-search-01">
		
					<!------------------------------------------
					  □検索条件領域(非表示時)
					-------------------------------------------->
					<div class="inner-01" style="display:none;">
						<p id="list-search"></p>
						<p class="txt-02">該当件数<span class="hit-number"></span><span>件</span></p>
					<!-- /inner-01 --></div>
		
					<!------------------------------------------
					  □検索条件領域(入力時)
					-------------------------------------------->
					<div class="inner-02">
						<p class="required">*が付いている項目は必須入力になります。</p>
						<div class="str-form-02">
							<div class="inner">
								<table>
									<colgroup>
										<col class="w-type-01">
										<col class="w-type-02">
									</colgroup> 
									<tr>
										<th scope="col">
											<span class="tbl-hdg">
												<asp:Label ID="Head_tenpo_cd_lbl" runat="server">ヘッダ店舗コード</asp:Label>
											</span>
										</th>
										<td>
											<!--- 「ヘッダ店舗コード」一行テキストボックス（セパレート日付以外） --->
											<md:MDTextBox ID="Head_tenpo_cd" CssClass="inpSerch" runat="server"></md:MDTextBox>
										</td>
									</tr>
									<tr>
										<th scope="col">
										</th>
										<td>
											<!--- 「ヘッダ店舗コードボタン」ボタン --->
											<input type="button" id="Btnheadtenpocd" name="Btnheadtenpocd" value="ヘッダ店舗コードボタン" runat="server" class="icon-search"/>
										</td>
									</tr>
									<tr>
										<th scope="col">
											<span class="tbl-hdg">
												<asp:Label ID="Head_tenpo_nm_lbl" runat="server">ヘッダ店舗名</asp:Label>
											</span>
										</th>
										<td>
											<!--- 「ヘッダ店舗名」テキストボックスリードオンリー --->
											<asp:TextBox ID="Head_tenpo_nm" CssClass="inpReadonlyLeft" runat="server"></asp:TextBox>
										</td>
									</tr>
									<tr>
										<th scope="col">
										</th>
										<td>
											<!--- 「シール発行ボタン」ボタン --->
											<input type="button" id="Btnseal" value="シール発行" onserverclick="OnBTNSEAL_FRM" runat="server" class="btn type-01"/>
										</td>
									</tr>
									<tr>
										<th scope="col">
										</th>
										<td>
											<!--- 「ラベル発行機コードボタン」ボタン --->
											<input type="button" id="Btnlabel_cd" name="Btnlabel_cd" value="ラベル発行機コードボタン" runat="server" class="icon-search"/>
										</td>
									</tr>
											<!--- 「ラベル発行機ＩＤ」隠しフィールド --->
											<asp:hiddenfield ID="Label_cd" runat="server"></asp:hiddenfield>
											<!--- 「ラベル発行機ＩＰ」隠しフィールド --->
											<asp:hiddenfield ID="Label_ip" runat="server"></asp:hiddenfield>
									<tr>
										<th scope="col">
											<span class="tbl-hdg">
												<asp:Label ID="Label_nm_lbl" runat="server">ラベル発行機名</asp:Label>
											</span>
										</th>
										<td>
											<!--- 「ラベル発行機名」テキストボックスリードオンリー --->
											<asp:TextBox ID="Label_nm" CssClass="inpReadonlyLeft" runat="server"></asp:TextBox>
										</td>
									</tr>
											<!--- 「モードNO」隠しフィールド --->
											<asp:hiddenfield ID="Modeno" runat="server"></asp:hiddenfield>
											<!--- 「選択モードNO」隠しフィールド --->
											<asp:hiddenfield ID="Stkmodeno" runat="server"></asp:hiddenfield>
								</table>
							<!-- /inner --></div>
						<!-- /str-form-02 --></div>
		    		<!-- /inner-02 --></div>
		    	<!-- /str-search-01 --></div>
			<!-- /tab1 --></div>

		<!-- /wrap --></div>	
		
		<!-- 画面上隠しエレメントを格納するエリア-->
		<div id="hiddenElements" style="display:none" runat="server">
		     
		</div>
	<script type="text/javascript" language=JavaScript></script>
	</form>
</body>
</html>

