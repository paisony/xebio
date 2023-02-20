<%@ Page language="c#" CodeFile="tm810f01.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Tm810p01.Page.Tm810f01Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">複数帳票出力</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="tm810p01" FormId="tm810f01" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/tm810f01.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="tm810p01" FormId="tm810f01" runat="server" />
</head>

<body>
	<form id="Tm810f01" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap-modal" >
			<div style="display:none">
			    <uc:Header ID="header" runat="server" PgId="tm810p01" PgName="複数帳票出力" FormId="tm810f01" FormName="複数帳票出力画面" ></uc:Header>
			</div>
            <h1 class="modal-ttl" >
                以下のリンクをクリックし、ダウンロードしてください。
            </h1>
		<!-------------------------------------------------------------------
								1.明細部
		--------------------------------------------------------------------->
		<input id="M1PageStartRow" type="hidden" runat="server"/>
			<!-- search-result -->
			<div class="str-wrap-result" style="height:140px;">
				<div class="modal-cont">
					<div id="str-pager-top" class="str-pager-01" style="display:none">
		
						<!--- 件数表示部 --->
						<p><adv:PageInfo ID="M1PageInfo" runat="server"></adv:PageInfo></p>
						<!--- ページャーを配置する場合はこの中 --->
		
					<!-- /str-pager-01 --></div>
					<!--一覧-->
					<div class="str-result-01">
					<%-- 明細ヘッダ --%>
						<div class="str-result-hdg-01" style="display:none">
							<div class="col1">
								<asp:Label ID="M1download_file_name_lbl" runat="server">ダウンロードファイル名</asp:Label>
							</div>
						<!-- /str-result-hdg-01 --></div>
						<div id="str-result-item-wrap" style="height:140px;overflow:auto;">
							<asp:Repeater ID="M1" runat="server">
								<HeaderTemplate>
								</HeaderTemplate>
								<ItemTemplate>
									<div class="str-result-item-02" style="white-space:nowrap ">
										<div class="col1" style="">
                                            <a id="M1download_file_name" href="#" class="" runat="server" style="">ダウンロードファイル名</a>
										</div>
									<!-- /str-result-item-01 --></div>
								</ItemTemplate>
							</asp:Repeater>
						<!-- /str-result-item-wrap --></div>
					<!-- /str-result-01 --></div>
					<!------------------------------------------
					  □ページャ下部領域
					-------------------------------------------->
				<!-- /inner --></div>
			<!-- /str-wrap-result --></div>
		<!-- /wrap --></div>	
		
		<!-- 画面上隠しエレメントを格納するエリア-->
		<div id="hiddenElements" style="display:none" runat="server">
		     
		</div>
	
	</form>
</body>
</html>

