<%@ Page language="c#" CodeFile="tg090f01.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Tg090p01.Page.Tg090f01Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">不良品一覧出力</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="tg090p01" FormId="tg090f01" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/tg090f01.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="tg090p01" FormId="tg090f01" runat="server" />
	<!-- Js業務部品のインポート --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02001.js" charset="UTF-8"></script><!-- 店舗検索 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02005.js" charset="UTF-8"></script><!-- 担当者検索 -->

	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script><!-- 0埋め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05011.js" charset="UTF-8"></script><!-- FROM-TOコピー処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05014.js" charset="UTF-8"></script><!-- 名称取得拡張 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05015.js" charset="UTF-8"></script><!-- 項目入力制御処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05021.js" charset="UTF-8"></script><!-- パラメータ取得部品 -->

    <!-- 業務共通コントロールのインポート-->
	<%@ Register TagPrefix="uc" TagName="common" Src="~/pjcommon/businessCommon/usercontrol/boCommonControl.ascx" %>

</head>

<body>
	<form id="Tg090f01" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="tg090p01" PgName="不良品一覧出力" FormId="tg090f01" FormName="不良品一覧出力" ></uc:Header>
			

			<!------------------------------------------	
				□業務共通コントロール
			------------------------------------------->	
			<uc:common ID="bocommon" runat="server"></uc:common>

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
			<div id="tab1" class="str-tab-cont">
				<!-- search-list -->
				<div class="str-search-01">
		
					<!------------------------------------------
					  □検索条件領域(非表示時)
					-------------------------------------------->
					<div class="inner-01" style="display:none;">
						<p id="list-search"></p>
					<!-- /inner-01 --></div>
		
					<!------------------------------------------
					  □検索条件領域(入力時)
					-------------------------------------------->
					<div class="inner-02">
						<div class="str-form-02">
							<div class="inner">
								<table>
									<colgroup>
							            <col class="w-type-01"/>
							            <col class="w-type-02"/>
										<col class="w-type-01"/>
										<col class="w-type-03"/>
							            <col class="w-type-05"/>
							            <col class="w-type-04"/>
									</colgroup>
									<tr>
										<!--- 「日付」 --->
										<th scope="col">
											<span class="tbl-hdg"><asp:Label ID="Ymd_from_lbl" runat="server">日付</asp:Label></span>
										</th>
										<!--- 「日付ｆｒｏｍ」一行テキストボックス（セパレート日付以外） --->
										<!--- 「日付ｔｏ」一行テキストボックス（セパレート日付以外） --->
										<td>
											<span class="icon-in"><md:MDTextBox ID="Ymd_from" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span>
											<span class="label-fromto">～</span>
											<span class="icon-in"><md:MDTextBox ID="Ymd_to" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span>
										</td>
										<!--- 「担当者コード」 --->
										<th scope="col">
											<span class="tbl-hdg"><asp:Label ID="Tantosya_cd_lbl" runat="server">担当者</asp:Label></span>
										</th>
										<!--- 「担当者コード」一行テキストボックス（セパレート日付以外） --->
										<!--- 「ボタン担当者コード」ボタン --->
										<!--- 「担当者名」テキストボックスリードオンリー --->
                                        <td style="white-space:nowrap;">
											<span class="icon-in">
												<md:MDTextBox ID="Tantosya_cd" CssClass="inpSerch inpTanto" runat="server"></md:MDTextBox>
												<input type="button" id="Btntanto_cd" name="Btntanto_cd" value="" runat="server" class="icon-search"/>
											</span>
											<asp:TextBox ID="Hanbaiin_nm" CssClass="inpReadonlyLeft" runat="server"></asp:TextBox>
                                        </td>
										<!--- 「調達区分」 --->
										<th scope="col">
											<span class="tbl-hdg"><asp:Label ID="Tyotatsu_kb_lbl" runat="server">PB(SMU含む)/NB</asp:Label></span>
										</th>
                                        <td class="last" style="white-space:nowrap;">
										<!--- 「調達区分」ラジオボタン --->
										<adv:ConditionRBList ID="Tyotatsu_kb" ConditionName="tyotatsu_joken" RepeatDirection="Horizontal" CssClass="str-radio-table" runat="server"></adv:ConditionRBList>
										</td>
									</tr>
								</table>
							<!-- /inner --></div>
						<!-- /str-form-02 --></div>
		    		<!-- /inner-02 --></div>
					<p class="required">　※７カ月以内に登録した不良品一覧の印刷が可能です。</p>
		    	<!-- /str-search-01 --></div>
			<!-- /tab1 --></div>
		

			<!-- /str-search-01 --></div>
	<!-------------------------------------------------------------------
								2.明細部
		--------------------------------------------------------------------->
			<!-- search-result -->
			<div class="str-wrap-result">
				<!------------------------------------------
					□明細ボタン部
				-------------------------------------------->
				<div id="str-btn-area" class="str-btn-utility">
					<ul>
						<!--明細制御系ボタンを配置する場合はこのulタグの中-->
						<li></li>
						<li></li>
						<li></li>
					</ul>
					<ul>
						<!--帳票／CSV系ボタンを配置する場合はこのulタグの中-->
						<!--- 「CSVボタン」ボタン --->
						<li><span><label><input type="button" id="Btncsv" value="" onserverclick="OnBTNCSV_FRM" runat="server" class="icon-utility-05"/>CSV出力</label></span></li>
						<li></li>
					</ul>
				<%--<!-- /utility --></div>--%>
	
			<!-- /str-btn-utility --></div>



		<!-- /wrap --></div>	
		
		<!-- 画面上隠しエレメントを格納するエリア-->
		<div id="hiddenElements" style="display:none" runat="server">
					<asp:Label ID="Head_tenpo_cd_lbl" runat="server">店舗</asp:Label>
					<asp:Label ID="Head_tenpo_cd_Req" runat="server" CssClass="required">*</asp:Label>
					<asp:Label ID="Head_tenpo_nm_lbl" runat="server"></asp:Label>
					<asp:Label ID="Ymd_to_lbl" runat="server">日付ＴＯ</asp:Label>
					<asp:Label ID="Hanbaiin_nm_lbl" runat="server"></asp:Label>
					<p class="txt-02">該当件数<span class="hit-number"></span><span>件</span></p>
		</div>
	
	</form>
</body>
</html>

