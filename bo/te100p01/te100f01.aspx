﻿<%@ Page Language="c#" CodeFile="te100f01.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Te100p01.Page.Te100f01Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
    <adv:ContentType ID="ContentType1" runat="server" />
    <meta http-equiv="Content-Style-Type" content="text/css">
    <title id="Windowtitle" runat="server">移動入荷予定未存在リスト出力</title>
    <!--- キャッシュの無効化設定 --->
    <adv:NoCache ID="NoCache1" runat="server" />

    <!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
    <adv:SetHeader ID="SetHeader1" PgId="te100p01" FormId="te100f01" runat="server" />

    <!-- link css -->
    <link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
    <link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
    <link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
    <link rel="stylesheet" type="text/css" href="./css/te100f01.css">
    <!-- スクリプトのインポート -->
    <std:SetCustomHeader ID="SetHeader2" PgId="te100p01" FormId="te100f01" runat="server" />

    <!-- Js業務部品のインポート --->
    <script type="text/javascript" src="../pjcommon/businessCommon/js/V02001.js" charset="UTF-8"></script>
    <!-- 店舗検索 -->
    <script type="text/javascript" src="../pjcommon/businessCommon/js/V02002.js" charset="UTF-8"></script>
    <!-- 仕入先マスタ取得 -->
    <script type="text/javascript" src="../pjcommon/businessCommon/js/V02005.js" charset="UTF-8"></script>
    <!-- 担当者マスタ取得 -->
    <script type="text/javascript" src="../pjcommon/businessCommon/js/V02010.js" charset="UTF-8"></script>
    <!-- 部門マスタ取得 -->
    <script type="text/javascript" src="../pjcommon/businessCommon/js/V02012.js" charset="UTF-8"></script>
    <!-- 品種マスタ取得 -->
    <script type="text/javascript" src="../pjcommon/businessCommon/js/C05002.js" charset="UTF-8"></script>
    <!-- スキャンコード丸め処理 -->
    <script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script>
    <!-- モード制御 -->
    <script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script>
    <!-- 0埋め処理 -->
    <script type="text/javascript" src="../pjcommon/businessCommon/js/C05009.js" charset="UTF-8"></script>
    <!-- 指示番号丸め処理(返品用) -->
    <script type="text/javascript" src="../pjcommon/businessCommon/js/C05011.js" charset="UTF-8"></script>
    <!-- FROM-TOコピー処理 -->
    <script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script>
    <!-- BO共通初期表示処理 -->
    <script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script>
    <!-- BOJs共通定数 -->

</head>

<body>
    <form id="Te100f01" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
        <div id="wrap">

            <uc:Header ID="header" runat="server" PgId="te100p01" PgName="移動入荷予定未存在リスト出力" FormId="te100f01" FormName="移動入荷予定未存在リスト出力"></uc:Header>

            <!------------------------------------------
				□ヘッダー部
			-------------------------------------------->

            <!--- 「ヘッダ店舗コード」一行テキストボックス（セパレート日付以外） --->
            <!--- 「ボタンヘッダ店舗コード」ボタン --->
            <!--- 「ヘッダ店舗名」テキストボックスリードオンリー --->

            <p class="headerTenpo">
                <span class="icon-in">
                    <md:MDTextBox ID="Head_tenpo_cd" CssClass="inpSerch inpHeaderTenpo" runat="server"></md:MDTextBox>
                    <input type="button" id="Btnheadtenpocd" name="Btnheadtenpocd" value="" runat="server" class="icon-search" />
                </span>
                <asp:TextBox ID="Head_tenpo_nm" CssClass="inpReadonlyLeft inpHeaderTenpoNm" runat="server"></asp:TextBox>
            </p>
            <!-------------------------------------------------------------------
								1.カード部
		--------------------------------------------------------------------->
                <div class="str-search-01">

                    <!------------------------------------------
					  □検索条件領域(非表示時)
					-------------------------------------------->
                    <div class="inner-01" style="display: none;">
                        <p id="list-search"></p>
                        <!-- /inner-01 -->
                    </div>

                    <!------------------------------------------
					  □検索条件領域(入力時)
					-------------------------------------------->
                    <div class="inner-02">
                        <!---<p class="required">*が付いている項目は必須入力になります。</p>--->
                            <table>
                                <colgroup>
                                    <col class="w-type-01">
                                    <col class="w-type-02">
                                    <col />
                                </colgroup>
                                <tbody>
                                    <tr>
                                        <th scope="col">
                                            <span class="tbl-hdg">
                                            <asp:Label ID="Add_ymd_from_lbl" runat="server">登録日</asp:Label>
                                            </span>
                                        </th>
                                        <td>
                                            <label>
                                                <!--- 「登録日ｆｒｏｍ」一行テキストボックス（セパレート日付以外） --->
                                                <!--- 「登録日ｔｏ」一行テキストボックス（セパレート日付以外） --->
                                                <span class="icon-in9">
                                                    <md:MDTextBox ID="Add_ymd_from" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox><span class="label-fromto">～</span><md:MDTextBox ID="Add_ymd_to" CssClass="inpSerch inpDt datepicker" runat="server"></md:MDTextBox>
                                                </span>
                                            </label>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        <!--/inner-02--></div>
                    <!--/str-search-01--></div>

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
                            <!--帳票／CSV系ボタンを配置する場合は
						<!--- 「印刷ボタン」ボタン --->
                            <span><label><input type="button" id="Btnprint" value="" onserverclick="OnBTNPRINT_FRM" runat="server" class="icon-utility-04" />印刷</label></span>
                            <li></li>
                        </ul>
                        <!-- /utility --></div>

                    <!-- /str-wrap-result --></div>

            <!-- /wrap -->
        </div>

        <!-- 画面上隠しエレメントを格納するエリア-->
        <div id="hiddenElements" style="display: none" runat="server">

            <asp:Label ID="Head_tenpo_cd_lbl" runat="server">店舗</asp:Label>
            <asp:Label ID="Head_tenpo_cd_Req" runat="server" CssClass="required">*</asp:Label>

            <asp:Label ID="Head_tenpo_nm_lbl" runat="server"></asp:Label>

            <asp:Label ID="Add_ymd_to_lbl" runat="server">登録日ＴＯ</asp:Label>

        </div>

    </form>
</body>
</html>

