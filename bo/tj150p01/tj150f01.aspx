<%@ Page language="c#" CodeFile="tj150f01.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Tj150p01.Page.Tj150f01Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">棚卸終了処理</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="tj150p01" FormId="tj150f01" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/tj150f01.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="tj150p01" FormId="tj150f01" runat="server" />
	<!-- Js業務部品のインポート --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02001.js" charset="UTF-8"></script><!-- 店舗検索 -->
    <script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
    <script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05019.js" charset="UTF-8"></script><!-- 情報ダイアログ表示処理(拡張版) -->

</head>

<body>
	<form id="Tj150f01" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="tj150p01" PgName="棚卸終了処理(X)" FormId="tj150f01" FormName="棚卸終了処理" ></uc:Header>
			
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
				  □検索条件領域(入力時)
				-------------------------------------------->
				<div class="inner-02">
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
												<col class="w-type-02"/>
												<col class="w-type-03"/>
												<col />
											</colgroup>
											<tr>
												<td colspan ="5">
													<font size="5">確定ボタン押下後、棚卸の終了処理を行います。</font>
												</td>										
											</tr>
											<tr>
												<th></th>
												<td>
													<!--- 「棚卸終了区分」ラジオボタン --->
													<adv:ConditionRBList ID="Tanaorosisyuryo_kb" ConditionName="tanaorosi_syuryo_kbn" RepeatDirection="Vertical" CssClass="h-type-01" runat="server"></adv:ConditionRBList>
												</td>
												<td></td><td></td><td></td>
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
		    <!------------------------------------------
		      ■一覧領域
		    -------------------------------------------->
		    <div class="str-wrap-result">
			    <!------------------------------------------
			      □ボタン領域
			    -------------------------------------------->
			    <div id="str-btn-area" class="str-btn-utility">
				    <ul>
				    <li></li>
				    <li></li>
				    <li></li>
				    </ul>
				    <ul>
				    </ul>
			    <!-- /utility --></div>
			    <div>

				    <!------------------------------------------
				      □ページャ上部領域
				    -------------------------------------------->
				    <div id="str-pager-top" class="str-pager-01">
				    <!-- /str-pager-01 --></div>

				    <!------------------------------------------
				      □一覧領域
				    -------------------------------------------->
				    <div class="str-result-01">
					    <!------------------------------------------
					      □一覧ヘッダ領域
					    -------------------------------------------->
					    <div class="str-result-hdg-01">
					    <!-- /str-hdg-result --></div>

					    <!------------------------------------------
					      □一覧明細領域
					    -------------------------------------------->
					    <div id="str-result-item-wrap" class="adjust-elem">

					    <!-- /str-result-item-wrap --></div>

				    <!-- /str-result-01 --></div>

				    <!------------------------------------------
				      □ページャ下部領域
				    -------------------------------------------->
			    <span class="adjust-elem-next"></span>
			    <!-- /inner --></div>

				<div id="str-pager-bottom" class="footer str-pager-01 pad0">
				    <p>
				    </p>
				    <p><!--- 「確定ボタン」ボタン --->
						<input type="button" id="Btnenter" value="確定" onserverclick="OnBTNENTER_FRM" runat="server" class="btn type-01"/>
				    </p>
			    <!-- /str-pager-01 --></div>
	        <!-- /str-wrap-result --></div>



		<!-- /wrap --></div>	
		
		<!-- 画面上隠しエレメントを格納するエリア-->
		<div id="hiddenElements" style="display:none" runat="server">
			<asp:Label ID="Head_tenpo_cd_lbl" runat="server"></asp:Label>
			<asp:Label ID="Head_tenpo_cd_Req" runat="server" CssClass="required">*</asp:Label>
			<asp:Label ID="Head_tenpo_nm_lbl" runat="server"></asp:Label>
     		<asp:Label ID="Tanaorosisyuryo_kb_lbl" runat="server"></asp:Label>
		</div>
	</form>
</body>
</html>


