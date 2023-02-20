<%@ Page language="c#" CodeFile="ti030f01.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Ti030p01.Page.Ti030f01Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">運用管理マスタメンテナンス</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="ti030p01" FormId="ti030f01" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/ti030f01.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="ti030p01" FormId="ti030f01" runat="server" />

    <!-- JS-->
    <script type="text/javascript" src="../pjcommon/businessCommon/js/V02001.js" charset="UTF-8"></script><!-- 店舗検索 -->
    <script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
    <script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05015.js" charset="UTF-8"></script><!-- 項目制御処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05016.js" charset="UTF-8"></script><!-- コード参照出口ルーチン共通処理 -->
</head>

<body>
	<form id="Ti030f01" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="ti030p01" PgName="運用管理マスタメンテナンス" FormId="ti030f01" FormName="運用管理マスタメンテナンス" ></uc:Header>

			<!--- 「ヘッダ店舗コード」一行テキストボックス（セパレート日付以外） --->
			<!--- 「ボタンヘッダ店舗コード」ボタン --->
			<!--- 「ヘッダ店舗名」テキストボックスリードオンリー --->
			<p class="headerTenpo">
				<span class="icon-in">
					<md:MDTextBox ID="Head_tenpo_cd" CssClass="inpSerch inpHeaderTenpo" runat="server"></md:MDTextBox><input type="button" id="Btnheadtenpocd" name="Btnheadtenpocd" value="" runat="server" class="icon-search"/>
				</span>
				<asp:TextBox ID="Head_tenpo_nm" CssClass="inpReadonlyLeft inpHeaderTenpoNm" runat="server"></asp:TextBox>
			</p>

		    <!------------------------------------------
		      ■検索条件領域
		    -------------------------------------------->
		    <div class="str-search-01">
			    <!------------------------------------------
			      □検索条件領域(入力時)
			    -------------------------------------------->
			    <div class="inner-02">
                    <p class="required">*が付いている項目は必須入力になります。</p>
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
										    <tbody>
											    <tr>
                                                    <!--- 「消費税率１」一行テキストボックス（セパレート日付以外） --->
												    <th>
													    <span class="tbl-hdg"><asp:Label ID="Syohizei_rtu1_lbl" runat="server">消費税率１</asp:Label><span class="required">*</span></span>
												    </th>
												    <td>
													    <md:MDTextBox ID="Syohizei_rtu1" CssClass="inpSu-03" runat="server"></md:MDTextBox>%
												    </td>
                                                    <!--- 「消費税開始日１」一行テキストボックス（セパレート日付以外） --->
												    <th>
													    <span class="tbl-hdg"><asp:Label ID="Syohizeikaisi_ymd1_lbl" runat="server">税率１開始日</asp:Label><span class="required">*</span></span>
												    </th>
												    <td>
													    <span class="icon-in"><md:MDTextBox ID="Syohizeikaisi_ymd1" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span>
												    </td>
                                                    <!--- 「税処理区分１」ドロップダウンリスト --->
												    <th>
													    <span class="tbl-hdg"><asp:Label ID="Zeisyori_kb1_lbl" runat="server">税処理区分1</asp:Label></span>
												    </th>
												    <td>
													    <md:MDConditionDDList ID="Zeisyori_kb1" ConditionName="zeisyori_kbn" CssClass="slt-kbn" runat="server"></md:MDConditionDDList>
													    <span class="select-arrow"></span>
												    </td>
											    </tr>
											    <tr>
                                                    <!--- 「消費税率２」一行テキストボックス（セパレート日付以外） --->
												    <th>
													    <span class="tbl-hdg"><asp:Label ID="Syohizei_rtu2_lbl" runat="server">消費税率２</asp:Label><span class="required">*</span></span>
												    </th>
												    <td>
                                                        <md:MDTextBox ID="Syohizei_rtu2" CssClass="inpSu-03" runat="server"></md:MDTextBox>%
												    </td>
                                                    <!--- 「消費税開始日２」一行テキストボックス（セパレート日付以外） --->
												    <th>
													    <span class="tbl-hdg"><asp:Label ID="Syohizeikaisi_ymd2_lbl" runat="server">税率２開始日</asp:Label><span class="required">*</span></span>
												    </th>
												    <td>
													    <span class="icon-in"><md:MDTextBox ID="Syohizeikaisi_ymd2" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox></span>
												    </td>
												    <th>
													    <span class="tbl-hdg"><asp:Label ID="Zeisyori_kb2_lbl" runat="server">税処理区分2</asp:Label></span>
												    </th>
												    <td>
													    <md:MDConditionDDList ID="Zeisyori_kb2" ConditionName="zeisyori_kbn" CssClass="slt-kbn" runat="server"></md:MDConditionDDList>
													    <span class="select-arrow"></span>
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

				<div id="footerBtnArea" class="pad0" runat="server">
					<div id="str-pager-bottom" class="str-pager-01 pad0">
						<p>
						</p>
						<p><!--- 「確定ボタン」ボタン --->
							<input type="button" id="Btnenter" value="確定" onserverclick="OnBTNENTER_DBU" runat="server" class="btn type-01"/>
						</p>
					<!-- /str-pager-01 --></div>
				<!-- /footerBtnArea --></div>
	        <!-- /str-wrap-result --></div>
	    <!-- /wrap --></div>


	    <!-- 画面上隠しエレメントを格納するエリア-->
	    <div id="hiddenElements" style="display:none" runat="server">
		    <asp:Label ID="Head_tenpo_cd_lbl" runat="server">店舗</asp:Label>
		    <asp:Label ID="Head_tenpo_cd_Req" runat="server" CssClass="required">*</asp:Label>
            <asp:Label ID="Head_tenpo_nm_lbl" runat="server"></asp:Label>

			<asp:Label ID="Syohizei_rtu1_Req" runat="server" CssClass="required">*</asp:Label>
			<asp:Label ID="Syohizeikaisi_ymd1_Req" runat="server" CssClass="required">*</asp:Label>
			<asp:Label ID="Syohizei_rtu2_Req" runat="server" CssClass="required">*</asp:Label>
			<asp:Label ID="Syohizeikaisi_ymd2_Req" runat="server" CssClass="required">*</asp:Label>

	    </div>
	
	</form>
</body>
</html>

