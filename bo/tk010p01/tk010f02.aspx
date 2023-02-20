<%@ Page language="c#" CodeFile="tk010f02.aspx.cs" AutoEventWireup="false" Inherits="com.xebio.bo.Tk010p01.Page.Tk010f02Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">

<head>
	<adv:ContentType ID="ContentType1" runat="server" />
	<meta http-equiv="Content-Style-Type" content="text/css">
	<title id="Windowtitle" runat="server">評価損確定</title>
	<!--- キャッシュの無効化設定 --->
	<adv:NoCache ID="NoCache1" runat="server" />

	<!--- スクリプトヘルパー、項目テーブル、業務スクリプトのインポート --->
	<adv:SetHeader ID="SetHeader1" PgId="tk010p01" FormId="tk010f02" runat="server" />

	<!-- link css -->
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/base.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/parts.css">
	<link rel="stylesheet" type="text/css" href="../pjcommon/boStyle/jquery-ui.css">
	<link rel="stylesheet" type="text/css" href="./css/tk010f02.css">
	<!-- スクリプトのインポート -->
	<std:SetCustomHeader ID="SetHeader2" PgId="tk010p01" FormId="tk010f02" runat="server" />

	<!-- Js業務部品のインポート --->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05002.js" charset="UTF-8"></script><!-- スキャンコード丸め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05003.js" charset="UTF-8"></script><!-- 明細背景色変更処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05004.js" charset="UTF-8"></script><!-- モード制御 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05008.js" charset="UTF-8"></script><!-- 0埋め処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05010.js" charset="UTF-8"></script><!-- カンマ編集処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05012.js" charset="UTF-8"></script><!-- BO共通初期表示処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05013.js" charset="UTF-8"></script><!-- BOJs共通定数 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05014.js" charset="UTF-8"></script><!-- 名称取得拡張 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05015.js" charset="UTF-8"></script><!-- 項目入力制御処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/C05024.js" charset="UTF-8"></script><!-- 数値編集関数群 -->

	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02004.js" charset="UTF-8"></script><!-- スキャンコードチェック処理 -->
	<script type="text/javascript" src="../pjcommon/businessCommon/js/V02015.js" charset="UTF-8"></script><!-- 名称マスタ取得 -->

</head>


<body>
	<form id="Tk010f02" method="post" runat="server" onload="Page_Load" onprerender="RenderForm" class="form-02">
		<div id="wrap">
						
			<uc:Header ID="header" runat="server" PgId="tk010p01" PgName="評価損確定" FormId="tk010f02" FormName="評価損確定 明細" ></uc:Header>


			<!------------------------------------------
				□ヘッダー部
			-------------------------------------------->
			<!--- 「ボタン戻る」ボタン --->
			<p class="headerBackBtn">
				<input type="button" id="Btnback" value="" onserverclick="OnBTNBACK_FRM" runat="server" class="btn type-back"/>
			</p>

			<!--- 「ヘッダ店舗コード」テキストボックスリードオンリー --->
			<!--- 「ヘッダ店舗名」テキストボックスリードオンリー --->
			<p class="headerTenpo">
				<asp:TextBox ID="Head_tenpo_cd" CssClass="inpReadonlyLeft inpHeaderTenpoDisabled" runat="server"></asp:TextBox>
				<asp:TextBox ID="Head_tenpo_nm" CssClass="inpReadonlyLeft inpHeaderTenpoNm" runat="server"></asp:TextBox>
			</p>

			<!------------------------------------------
			  ■検索条件領域
			-------------------------------------------->
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
							<col class="w-type-05"/>
							<col class="w-type-01"/>
							<col />
						</colgroup>
						<tbody>
							<tr>
								<th class="last">
									<span class="tbl-hdg"><asp:Label ID="Syori_ym_lbl" runat="server">処理月</asp:Label></span>
								</th>
								<td class="last">
									<!--- 「処理月」テキストボックスリードオンリー --->
									<asp:TextBox ID="Syori_ym" CssClass="inpReadonlyLeft inpRODateYM" runat="server"></asp:TextBox>
								</td>
								<th class="last">
									<span class="tbl-hdg"><asp:Label ID="Tenpo_cd_lbl" runat="server">店舗</asp:Label></span>
								</th>
								<td class="last">
									<!--- 「店舗コード」テキストボックスリードオンリー --->
									<asp:TextBox ID="Tenpo_cd" CssClass="inpReadonlyLeft inpRONum4" runat="server"></asp:TextBox>
									<!--- 「店舗名」テキストボックスリードオンリー --->
									<asp:TextBox ID="Tenpo_nm" CssClass="inpReadonlyLeft inpROZenkaku10" runat="server"></asp:TextBox>
								</td>
								<th class="last">
									<span class="tbl-hdg"><asp:Label ID="Syonin_flg_nm_lbl" runat="server">承認状態</asp:Label></span>
								</th>
								<td class="last">
									<!--- 「承認状態名称」テキストボックスリードオンリー --->
									<asp:TextBox ID="Syonin_flg_nm" CssClass="inpReadonlyLeft inpROZenkaku2" runat="server"></asp:TextBox>
								</td>
								<th class="last">
									<span class="tbl-hdg"><asp:Label ID="Kessai_flg_nm_lbl" runat="server">決裁状態</asp:Label></span>
								</th>
								<td class="last">
									<!--- 「決裁状態名称」テキストボックスリードオンリー --->
									<asp:TextBox ID="Kessai_flg_nm" CssClass="inpReadonlyLeft inpROZenkaku3" runat="server"></asp:TextBox>
								</td>
								<th class="last">
									<span class="tbl-hdg"><asp:Label ID="Apply_ymd_lbl" runat="server">申請日</asp:Label></span>
								</th>
								<td class="last">
									<!--- 「申請日」テキストボックスリードオンリー --->
									<asp:TextBox ID="Apply_ymd" CssClass="inpReadonlyLeft inpRODate" runat="server"></asp:TextBox>
								</td>
							</tr>
						</tbody>
					</table>
				<!-- /inner-01 --></div>
			<!-- /str-search-02 --></div>

			<div class="trigger-search-01">
				<a href="#"></a>
			<!-- /trigger-search-01 --></div>

			<!------------------------------------------
			  ■一覧領域
			-------------------------------------------->
			<input id="M1PageStartRow" type="hidden" runat="server"/>
			<div class="str-wrap-result">

				<!------------------------------------------
				  □ボタン領域
				-------------------------------------------->
				<div id="str-btn-area" class="str-btn-utility">
					<ul>
					<!--明細制御系ボタンを配置する場合はこのulタグの中-->
					<li><!--- 「一括承認ボタン」ボタン --->
						<span><label><input type="button" id="Btnikkatsusyonin" value="" onserverclick="OnBTNIKKATSUSYONIN_FRM" runat="server" class="icon-utility-01"/>一括承認</label></span>
					</li>
					<li><!--- 「一括却下ボタン」ボタン --->
						<span><label><input type="button" id="Btnikkatsukyakka" value="" onserverclick="OnBTNIKKATSUKYAKKA_FRM" runat="server" class="icon-utility-01"/>一括却下</label></span>
					</li>
					<li><!--- 「全解除ボタン」ボタン --->
						<span><label><input type="button" id="Btnzenkjo" value="" onserverclick="OnBTNZENKJO_FRM" runat="server" class="icon-utility-02"/>全解除</label></span>
					</li>
					<li>
						<div class="str-kyakkariyu"><span>一括却下用却下理由</span></div>
					</li>
					<li>
						<label>
							<!--- 「一括却下用却下理由区分」ドロップダウンリスト --->
							<md:MDCodeCondition ID="Ikkatsukyakka_kyakkariyu_kb" FormID="Tk010f02" PgID="Tk010p01" CssClass="slt-ikkatsuKyakkaRiyu" runat="server"></md:MDCodeCondition>
							<!--<span class="select-arrow"></span>-->
							<!--- 「一括却下用却下理由」一行テキストボックス（セパレート日付以外） --->
							<md:MDTextBox ID="Ikkatsukyakka_kyakkariyu" CssClass="inp-ikkatsuKyakkaRiyu" runat="server"></md:MDTextBox>
						</label>
					<li>
					</ul>
					<ul>
					</ul>
				<!-- /utility --></div>

				<div class="inner">

					<!------------------------------------------
					  □ページャ上部領域
					-------------------------------------------->
					<div id="str-pager-top" class="str-pager-01">
						<!--- 件数表示部 --->
						<p><adv:PageInfo ID="M1PageInfo" runat="server"></adv:PageInfo></p>
						<!--- ページャーを配置する場合はこの中 --->
						<!--- 「ページャ」カスタムページャー --->
						<cc:custompager ID="Pgr" OnPageIndexChanged="OnPGR_PGN" runat="server"></cc:custompager>
					<!-- /str-pager-01 --></div>

					<!------------------------------------------
					  □一覧領域
					-------------------------------------------->
					<div class="str-result-01">
						<!------------------------------------------
						  □一覧ヘッダ領域
						-------------------------------------------->
						<div class="str-result-hdg-01">
							<div class="col1 col_2dan"><asp:Label ID="M1rowno_lbl" runat="server">No.</asp:Label></div>
							<div class="col2">
								<div><asp:Label ID="M1bumon_cd_lbl" runat="server">部門</asp:Label></div>
								<div><asp:Label ID="M1hinsyu_cd_lbl" runat="server">品種</asp:Label></div>
							</div>
							<div class="col3">
								<div><asp:Label ID="M1burando_nm_lbl" runat="server">ブランド</asp:Label></div>
								<div class="col3-1 headcell"><asp:Label ID="M1jisya_hbn_lbl" runat="server">自社品番</asp:Label></div>
								<div class="col3-2 headcell"><asp:Label ID="M1hanbaikanryo_ymd_lbl" runat="server">販完日</asp:Label></div>
							</div>
							<div class="col4">
								<div><asp:Label ID="M1maker_hbn_lbl" runat="server">メーカー品番</asp:Label></div>
								<div><asp:Label ID="M1syonmk_lbl" runat="server">商品名</asp:Label></div>
							</div>
							<div class="col5">
								<div><asp:Label ID="M1scan_cd_lbl" runat="server">スキャンコード</asp:Label></div>
								<div class="col5-1 headcell"><asp:Label ID="M1iro_nm_lbl" runat="server">色</asp:Label></div>
								<div class="col5-2 headcell"><asp:Label ID="M1size_nm_lbl" runat="server">サイズ</asp:Label></div>
							</div>
							<div class="col6">
								<div><asp:Label ID="M1genbaika_tnk_lbl" runat="server">現売価</asp:Label></div>
								<div><asp:Label ID="M1suryo_lbl" runat="server">数量</asp:Label></div>
							</div>
							<div class="col7">
								<div><asp:Label ID="M1gen_tnk_lbl" runat="server">原単価</asp:Label></div>
								<div><asp:Label ID="M1genkakin_lbl" runat="server">原価金額</asp:Label></div>
							</div>
							<div class="col8">
								<div><asp:Label ID="M1nyuryoku_ymd_lbl" runat="server">入力日</asp:Label></div>
								<div><asp:Label ID="M1apply_ymd_lbl" runat="server">申請日</asp:Label></div>
							</div>
							<div class="col9">
								<div><asp:Label ID="M1nyuryokusha_cd_lbl" runat="server">入力者</asp:Label></div>
								<div><asp:Label ID="M1sinseisya_cd_lbl" runat="server">申請者</asp:Label></div>
							</div>
							<div class="col10">
								<div class="col10-1 headcell"><asp:Label ID="M1hyokasonsyubetsu_kb_lbl" runat="server">種別</asp:Label></div>
								<div class="col10-2 headcell"><asp:Label ID="M1hyokasonriyu_kb_lbl" runat="server">評価損理由</asp:Label></div>
								<div class="col10 headcell"><asp:Label ID="M1kyakkariyu_kb_lbl" runat="server">却下理由</asp:Label></div>
							</div>
							<div class="col11 col_2dan"><asp:Label ID="M1tyotatsu_nm_lbl" runat="server">調達</asp:Label></div>
							<div class="col12 col_2dan"><asp:Label ID="M1syonin_flg_lbl" runat="server">承認</asp:Label></div>
							<div class="col13 col_2dan"><asp:Label ID="M1kyakka_flg_lbl" runat="server">却下</asp:Label></div>
							<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
							<div style="display:none">
								<div class="col22">
									<asp:Label ID="M1hyokasonriyu_kb_keinen_lbl" runat="server"></asp:Label>
								</div>
								<div class="col29">
									<asp:Label ID="M1hinsyu_ryaku_nm_lbl" runat="server"></asp:Label>
								</div>
								<div class="col30">
									<asp:Label ID="M1bumon_nm_lbl" runat="server"></asp:Label>
								</div>
								<asp:Label ID="M1hyokasonriyu_lbl" runat="server"></asp:Label>
								<asp:Label ID="M1kyakkariyu_lbl" runat="server"></asp:Label>
								<div class="col28">
									<asp:Label ID="M1suryo_hdn_lbl" runat="server"></asp:Label>
								</div>
								<div class="col29">
									<asp:Label ID="M1genkakin_hdn_lbl" runat="server"></asp:Label>
								</div>
								<div class="col30">
									<asp:Label ID="M1selectorcheckbox_lbl" runat="server"></asp:Label>
								</div>
								<div class="col31">
									<asp:Label ID="M1entersyoriflg_lbl" runat="server"></asp:Label>
								</div>
								<div class="col32">
									<asp:Label ID="M1dtlirokbn_lbl" runat="server"></asp:Label>
								</div>
							</div>
							<!--- 隠し項目エリア↑↑↑↑↑↑↑↑↑↑↑↑↑ --->
						<!-- /str-result-hdg-01 --></div>

						<!------------------------------------------
						  □一覧明細領域
						-------------------------------------------->
						<div id="str-result-item-wrap" class="adjust-elem">
							<asp:Repeater ID="M1" runat="server">
								<HeaderTemplate>
								</HeaderTemplate>
								<ItemTemplate>
								<div id="M1Row" class="str-result-item-01" runat="server">
									<div class="col1 col_2dan detail_right">
										<!--- 「ｍ１行no」テキストボックスリードオンリー --->
										<asp:TextBox ID="M1rowno" CssClass="inpReadonlyRight inpRONum4" runat="server"></asp:TextBox>
									</div>
									<div class="col2 detail_center">
										<div>
											<!--- 「ｍ１部門コード」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1bumon_cd" CssClass="inpReadonlyLeft inpRONum3 " runat="server"></asp:TextBox>
										</div>
										<div>
											<!--- 「ｍ１品種コード」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1hinsyu_cd" CssClass="inpReadonlyLeft inpRONum2 " runat="server"></asp:TextBox>
										</div>
									</div>
									<div class="col3 detail_left">
										<div>
											<!--- 「ｍ１ブランド名」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1burando_nm" CssClass="inpReadonlyLeft inpROHankaku10 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col3-1 cell detail_center">
											<!--- 「ｍ１自社品番」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1jisya_hbn" CssClass="inpReadonlyLeft inpRONum8" runat="server"></asp:TextBox>
											</div>
										<div class="col3-2 cell detail_center">
											<!--- 「ｍ１販売完了日」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1hanbaikanryo_ymd" CssClass="inpReadonlyRight inpRONum6" runat="server"></asp:TextBox>
										</div>
									</div>
									<div class="col4 detail_left">
										<div>
											<!--- 「ｍ１メーカー品番」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1maker_hbn" CssClass="inpReadonlyLeft inpROHankaku12 tooltip" runat="server"></asp:TextBox>
										</div>
										<div>
											<!--- 「ｍ１商品名(カナ)」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1syonmk" CssClass="inpReadonlyLeft inpROHankaku12 tooltip" runat="server"></asp:TextBox>
										</div>
									</div>
									<div class="col5 detail_left">
										<div class="detail_center">
											<!--- 「ｍ１スキャンコード」一行テキストボックス（セパレート日付以外） --->
											<md:MDTextBox ID="M1scan_cd" CssClass="inpScan" runat="server"></md:MDTextBox>
										</div>
										<div class="col5-1 cell detail_left" >
											<!--- 「ｍ１色」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1iro_nm" CssClass="inpReadonlyLeft tooltip inpROHankaku6 tooltip" runat="server"></asp:TextBox>
										</div>
										<div class="col5-2 cell detail_left">
											<!--- 「ｍ１サイズ」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1size_nm" CssClass="inpReadonlyLeft inpROHankaku4 tooltip" runat="server"></asp:TextBox>
										</div>
									</div>
									<div class="col6 detail_right">
										<div>
											<!--- 「ｍ１現売価」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1genbaika_tnk" CssClass="inpReadonlyRight inpRONumCma7" runat="server"></asp:TextBox>
										</div>
										<div class="detail_center">
											<!--- 「ｍ１数量」一行テキストボックス（セパレート日付以外） --->
											<md:MDTextBox ID="M1suryo" CssClass="inpSu-07" runat="server"></md:MDTextBox>
										</div>
									</div>
									<div class="col7 detail_right">
										<div>
											<!--- 「ｍ１原単価」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1gen_tnk" CssClass="inpReadonlyRight inpRONumCma7" runat="server"></asp:TextBox>
										</div>
										<div>
											<!--- 「ｍ１原価金額」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1genkakin" CssClass="inpReadonlyRight inpRONumCmaMinus9" runat="server"></asp:TextBox>
										</div>
									</div>
									<div class="col8 detail_center">
										<div>
											<!--- 「ｍ１入力日」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1nyuryoku_ymd" CssClass="inpReadonlyCenter inpRONum6" runat="server"></asp:TextBox>
										</div>
										<div>
											<!--- 「ｍ１申請日」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1apply_ymd" CssClass="inpReadonlyCenter inpRONum6" runat="server"></asp:TextBox>
										</div>
									</div>
									<div class="col9 detail_center">
										<div>
											<!--- 「ｍ１入力者コード」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1nyuryokusha_cd" CssClass="inpReadonlyCenter inpRONum7" runat="server"></asp:TextBox>
										</div>
										<div>
											<!--- 「ｍ１申請者コード」テキストボックスリードオンリー --->
											<asp:TextBox ID="M1sinseisya_cd" CssClass="inpReadonlyCenter inpRONum7" runat="server"></asp:TextBox>
										</div>
									</div>
									<div class="col10 detail_left">
										<div class="col10-1 cell detail_left">
											<!--- 「ｍ１評価損種別区分」ドロップダウンリスト --->
											<md:MDCodeCondition ID="M1hyokasonsyubetsu_kb" FormID="Tk010f02" PgID="Tk010p01" CssClass="slt-hyoukasonShubetu" runat="server"></md:MDCodeCondition>
											<span class="select-arrow"></span>
										</div>
										<div class="col10-2 cell detail_left">
											<!--- 「ｍ１評価損理由区分」ドロップダウンリスト --->
											<md:MDCodeCondition ID="M1hyokasonriyu_kb" FormID="Tk010f02" PgID="Tk010p01" CssClass="slt-hyoukasonRiyu" runat="server"></md:MDCodeCondition>
											<!--- 「ｍ１評価損理由区分_経年商品」ドロップダウンリスト --->
											<md:MDCodeCondition ID="M1hyokasonriyu_kb_keinen" FormID="Tk010f02" PgID="Tk010p01" CssClass="slt-hyoukasonRiyu" runat="server"></md:MDCodeCondition>
											<span class="select-arrow"></span>
											<!--- 「ｍ１評価損理由」一行テキストボックス（セパレート日付以外） --->
											<md:MDTextBox ID="M1hyokasonriyu" CssClass="inp-hyoukasonRiyu" runat="server"></md:MDTextBox>
										</div>
										<div class="col10 cell detail_left kyakkariyu-pad1">
											<!--- 「ｍ１却下理由区分」ドロップダウンリスト --->
											<md:MDCodeCondition ID="M1kyakkariyu_kb" FormID="Tk010f02" PgID="Tk010p01" CssClass="slt-kyakkaRiyu" runat="server"></md:MDCodeCondition>
											<span class="select-arrow"></span>
											<!--- 「ｍ１却下理由」一行テキストボックス（セパレート日付以外） --->
											<md:MDTextBox ID="M1kyakkariyu" CssClass="inp-kyakkaRiyu" runat="server"></md:MDTextBox>
										</div>
									</div>
									<div class="col11 col_2dan detail_left">
										<!--- 「ｍ１調達区分名称」テキストボックスリードオンリー --->
										<asp:TextBox ID="M1tyotatsu_nm" CssClass="inpReadonlyLeft inpROHankaku2 tooltip" runat="server"></asp:TextBox>
									</div>
									<div class="col12 col_2dan detail_center">
											<!--- 「ｍ１承認状態」チェックボックス --->
											<adv:AdvancedCheckBox ID="M1syonin_flg" Text="承認" CssClass="" runat="server"></adv:AdvancedCheckBox>
									</div>
									<div class="col13 col_2dan detail_center">
										<!--- 「ｍ１却下フラグ」チェックボックス --->
										<adv:AdvancedCheckBox ID="M1kyakka_flg" Text="却下" CssClass="" runat="server"></adv:AdvancedCheckBox>
									</div>
									<!--- 隠し項目エリア↓↓↓↓↓↓↓↓↓↓↓↓↓ --->
									<div style="display:none">
										<div class="col28">
											<!--- 「Ｍ１数量（隠し）」隠しフィールド --->
											<asp:hiddenfield ID="M1suryo_hdn" runat="server"></asp:hiddenfield>
										</div>
										<div class="col29">
											<!--- 「Ｍ１原価金額（隠し）」隠しフィールド --->
											<asp:hiddenfield ID="M1genkakin_hdn" runat="server"></asp:hiddenfield>
										</div>
										<div class="col30">
											<!--- 「ｍ１選択フラグ(隠し)」チェックボックス --->
											<adv:AdvancedCheckBox ID="M1selectorcheckbox" Text="" CssClass="" runat="server"></adv:AdvancedCheckBox>
										</div>
										<div class="col31">
											<!--- 「Ｍ１確定処理フラグ(隠し)」隠しフィールド --->
											<asp:hiddenfield ID="M1entersyoriflg" runat="server"></asp:hiddenfield>
										</div>
										<div class="col32">
											<!--- 「Ｍ１明細色区分(隠し)」隠しフィールド --->
											<asp:hiddenfield ID="M1dtlirokbn" runat="server"></asp:hiddenfield>
										</div>
										<div class="col29">
											<!--- 「M1品種略名称（隠し）」隠しフィールド --->
											<asp:hiddenfield ID="M1hinsyu_ryaku_nm" runat="server"></asp:hiddenfield>
										</div>
										<div class="col30">
											<!--- 「M1部門名（隠し）」隠しフィールド --->
											<asp:hiddenfield ID="M1bumon_nm" runat="server"></asp:hiddenfield>
										</div>
									</div>
									<!--- 隠し項目エリア↑↑↑↑↑↑↑↑↑↑↑↑↑ --->
								<!-- /str-result-item-01 --></div>
								</ItemTemplate>
							</asp:Repeater>
						<!-- /str-result-item-wrap --></div>

						<div id="str-result-ftr" class="str-result-ftr-01 adjust-elem-next">
							<div class="col1 detail_right">&nbsp;</div>
							<div class="col2 detail_center">&nbsp;</div>
							<div class="col3 detail_left">&nbsp;</div>
							<div class="col4 detail_left">&nbsp;</div>
							<div class="col5 detail_ftr_title"><asp:Label ID="Gokei_suryo_lbl" runat="server">合計</asp:Label></div>
							<div class="col6 detail_ftr">
								<span>
									<!--- 「合計数量」テキストボックスリードオンリー --->
									<asp:TextBox ID="Gokei_suryo" CssClass="inpReadonlyRight inpRONumCma8" runat="server"></asp:TextBox>
								</span>
							</div>
							<div class="col7 detail_ftr">
								<span>
									<!--- 「原価金額合計」テキストボックスリードオンリー --->
									<asp:TextBox ID="Haibun_kin_gokei" CssClass="inpReadonlyRight inpRONumCma9" runat="server"></asp:TextBox>
								</span>
							</div>
							<div class="col8 detail_left">&nbsp;</div>
							<div class="col9 detail_left">&nbsp;</div>
							<div class="col10 detail_left">&nbsp;</div>
							<div class="col11 detail_left">&nbsp;</div>
							<div class="col12 detail_left">&nbsp;</div>
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
			<!--- 「選択モードNO」隠しフィールド --->
			<asp:hiddenfield ID="Stkmodeno" runat="server"></asp:hiddenfield>
			<asp:Label ID="Tenpo_nm_lbl" runat="server"></asp:Label>
			<asp:Label ID="Ikkatsukyakka_kyakkariyu_lbl" runat="server"></asp:Label>
			<asp:Label ID="Haibun_kin_gokei_lbl" runat="server"></asp:Label>
<asp:Label ID="Ikkatsukyakka_kyakkariyu_kb_lbl" runat="server" class="tbl-hdg"></asp:Label>
		</div>
	
	</form>
</body>
</html>

