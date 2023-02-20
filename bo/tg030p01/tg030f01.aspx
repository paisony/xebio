<%@ Page language="c#" CodeFile="tg030f01.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Tg030p01.Page.Tg030f01Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">社員バーコード発行</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="tg030p01" FormId="tg030f01" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/tg030f01.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="tg030p01" FormId="tg030f01" runat="server" />

	<!-- Js業務部品のインポート --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02001.js" charset="UTF-8"></script><!-- 店舗検索 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02005.js" charset="UTF-8"></script><!-- 担当者検索 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05019.js" charset="UTF-8"></script><!-- 店舗マスタ、棚卸実施日データ取得 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05020.js" charset="UTF-8"></script><!-- SATOラベルプリンタ発行処理 -->
</head>

<body>
	<!-- ラベル発行用 ActiveControl ↓↓↓↓↓ -->
	<object id="objMLWebComponent" classid="clsid:C137E319-41FE-4F0F-BD1F-190424FD7E2B" codebase="WebComponent-Installer-ja.exe" style="display:none">WebComponentが使用できません。</object>
	<object id="objFileAccessComponent" type="application/x-oleobject" classid="clsid:A3F14F83-0717-444B-9DE5-BFC3AF5C32E8" style="display:none"></object>
	<!-- ラベル発行用 ActiveControl ↑↑↑↑↑ -->


	<form id="Tg030f01" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="tg030p01" PgName="社員バーコード発行" FormId="tg030f01" FormName="社員バーコード発行" ></uc:Header>
		
			
			<!-------------------------------------------
                       □ヘッダー部
			-------------------------------------------->

			<!--- 「ヘッダ店舗コード」一行テキストボックス（セパレート日付以外） --->
			<!--- 「ヘッダ店舗コードボタン」ボタン --->
			<!--- 「ヘッダ店舗名」テキストボックスリードオンリー --->
			<p class="headerTenpo">
				<span class="icon-in">
					<md:MDTextBox ID="Head_tenpo_cd" CssClass="inpSerch inpHeaderTenpo" runat="server"></md:MDTextBox><input type="button" id="Btnheadtenpocd" name="Btnheadtenpocd" value="" runat="server" class="icon-search" />
				</span>
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
						<p id="list-search"></p>
						<p class="txt-02">該当件数<span class="hit-number"></span><span>件</span></p>
					<!-- /inner-01 --></div>
						

					<!------------------------------------------
					  □検索条件領域(入力時)
					-------------------------------------------->
					<div class="inner-02">
					<%--	<p class="required">*が付いている項目は必須入力になります。</p> --%>
						<table class="search-table">
							<tr>
								<td class="search-table-tdleft">
									<div class="str-form-02">
										<div class="inner">
									
									<table>
									<colgroup>
											<col class="w-type-01"/>
											<col class="w-type-03"/>
											<col class="w-type-01"/>
											<col class="w-type-03"/>
											<col class="w-type-01"/>
											<col class="w-type-01"/>
											<col />
									</colgroup>
									
									<tbody>
									<tr><td colspan ="2"><div class="required">*が付いている項目は必須入力になります。</div><td></tr>
									<tr>
										<th>
											<span class="tbl-hdg" style="white-space:nowrap;">
												<asp:Label ID="Maisu_lbl" runat="server" >発行枚数</asp:Label>(最大99枚)&nbsp;<asp:Label ID="Maisu_Req" runat="server" CssClass="required">*&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:Label>
											</span>
										</th>

										<td>
											<!--- 「枚数」一行テキストボックス（セパレート日付以外） --->
											<md:MDTextBox ID="Maisu" CssClass="inpSu-02" runat="server" value="1" ></md:MDTextBox>
										</td>
										<th>
											<span class="tbl-hdg">
												<asp:Label ID="Tantosya_cd_lbl" runat="server" >社員コード</asp:Label><asp:Label ID="Tantosya_cd_Req" runat="server" CssClass="required">*</asp:Label>
												
											</span>
										</th>
										<td>
											<!--- 「担当者コード」一行テキストボックス（セパレート日付以外） --->
											<%--<md:MDTextBox ID="Tantosya_cd" CssClass="inpSerch" runat="server"></md:MDTextBox>--%>
											<span class="icon-in"><md:MDTextBox ID="Tantosya_cd" CssClass="inpSerch inpTanto" runat="server"></md:MDTextBox><input type="button" id="Btntanto_cd" name="Btntanto_cd" value="" runat="server" class="icon-search"/></span>
									<asp:Label ID="Hanbaiin_nm_lbl" runat="server"></asp:Label>
										</td>
										<td>
											<!--- 「担当者名」テキストボックスリードオンリー --->
											<asp:TextBox ID="Hanbaiin_nm" CssClass="inpReadonlyLeft" runat="server"></asp:TextBox>
										</td>

										<th>
											<span class="tbl-hdg">
												<asp:Label ID="Tantosya_cd2_lbl" runat="server" >社員コード(確認用)</asp:Label><asp:Label ID="Tantosya_cd2_Req" runat="server" CssClass="required">*</asp:Label>
											</span>
										</th>
										<td>
											<!--- 「担当者コード２」一行テキストボックス（セパレート日付以外） --->
											<md:MDTextBox ID="Tantosya_cd2" CssClass="inpTanto" runat="server"></md:MDTextBox>
										</td>
									</tr>
								</tbody>
								</table>
							<!-- /inner --></div>
						<!-- /str-form-02 --></div>
						</td>
						<td class="search-table-tdright">

							<div class="str-btn-search">
							<!-- /str-btn-search --></div>

						</td>
					</tr>
				</table>
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
       					<!--- 「シール発行ボタン」ボタン --->
       					<li><span><label><input type="button" id="Btnseal" value="" onserverclick="OnBTNSEAL_FRM" runat="server" class="icon-utility-04"/>シール発行</label></span></li>
						<!--- 「ラベル発行機コードボタン」ボタン --->
						<!--- 「ラベル発行機名」テキストボックスリードオンリー --->
						<li><span class="icon-in"><input type="button" id="Btnlabel_cd" name="Btnlabel_cd" value="" runat="server" class="icon-search"/></span></li>
						<asp:TextBox ID="Label_nm" CssClass="inpReadonlyLeft" runat="server"></asp:TextBox>
       				</ul>
       				<!-- /meisaiBtnArea --></div>
       			<!-- /str-btn-utility --></div>
			<!-- /str-wrap-result --></div>		
		<!-- /wrap --></div>	
		
		<!-- 画面上隠しエレメントを格納するエリア-->
		<div id="hiddenElements" style="display:none" runat="server">
			<asp:Label ID="Head_tenpo_cd_lbl" runat="server"></asp:Label>
			<asp:Label ID="Head_tenpo_nm_lbl" runat="server"></asp:Label>
		    <!--- 「ラベル発行機ＩＤ」隠しフィールド --->
			<asp:hiddenfield ID="Label_cd" runat="server"></asp:hiddenfield>
			<!--- 「ラベル発行機ＩＰ」隠しフィールド --->
			<asp:hiddenfield ID="Label_ip" runat="server"></asp:hiddenfield>
			<asp:Label ID="Label_nm_lbl" runat="server"></asp:Label>										
		</div>
	
	</form>
</body>
</html>




