using com.xebio.bo.Ta080p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Ta080p01.Request
{
  /// <summary>
  /// Ta080f03RequestHelper の概要の説明です。
  /// </summary>
  public static class Ta080f03RequestHelper
	{
		/// <summary>
		/// 入力値を取得します。
		/// </summary>
		/// <param name="pageContext">ページコンテキスト</param>
		public static void GetRequestValue(IPageContext pageContext)
		{
			#region 実装不可コメント
			//
			// 原則として、このクラスは修正しないで下さい。
			//
			#endregion
			
			RequestParameterCollection paramCol = new RequestParameterCollection();

			//ページコントロールを取得する
			System.Web.UI.Page page = (System.Web.UI.Page)pageContext.Context.Handler;
			//画面情報を取得する
			IFormInfo formInfo = pageContext.FormInfo;
			//FormVOを取得する
			Ta080f03Form formVO = (Ta080f03Form)pageContext.GetFormVO();

			//カード部を初期化する
			paramCol.InitCardItems(formInfo.GetCardItems());
			//明細「M1」部を初期化する
			paramCol.InitListItems(formInfo.GetListItems("M1"), formVO.GetList("M1").CurrentCount);
			//カード項目の入力値を取得する
			paramCol["Head_tenpo_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_nm"]);
			paramCol["Stkmodeno"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Stkmodeno"]);
			paramCol["Meisai_modeno"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Meisai_modeno"]);
			paramCol["Meisai_stkmodeno"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Meisai_stkmodeno"]);
			paramCol["Yosan_ymd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Yosan_ymd"]);
			paramCol["Yosan_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Yosan_cd"]);
			paramCol["Yosan_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Yosan_nm"]);
			paramCol["Yosan_kin"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Yosan_kin"]);
			paramCol["Misinsei_su"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Misinsei_su"]);
			paramCol["Misinsei_kin"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Misinsei_kin"]);
			paramCol["Apply_su"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Apply_su"]);
			paramCol["Apply_kin"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Apply_kin"]);
			paramCol["Jisseki_su"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Jisseki_su"]);
			paramCol["Jisseki_kin"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Jisseki_kin"]);
			paramCol["Zan_kin"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Zan_kin"]);
			paramCol["Yosan_ymd1"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Yosan_ymd1"]);
			paramCol["Yosan_cd1"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Yosan_cd1"]);
			paramCol["Yosan_nm1"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Yosan_nm1"]);
			paramCol["Bumon_cd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_cd_from"]);
			paramCol["Bumon_nm_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_nm_from"]);
			paramCol["Bumon_cd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_cd_to"]);
			paramCol["Bumon_nm_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_nm_to"]);
			paramCol["Hinsyu_cd_all"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hinsyu_cd_all"]);
			paramCol["Hinsyu_cd1"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hinsyu_cd1"]);
			paramCol["Hinsyu_cd2"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hinsyu_cd2"]);
			paramCol["Hinsyu_cd3"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hinsyu_cd3"]);
			paramCol["Hinsyu_cd4"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hinsyu_cd4"]);
			paramCol["Hinsyu_cd5"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hinsyu_cd5"]);
			paramCol["Hinsyu_cd6"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hinsyu_cd6"]);
			paramCol["Hinsyu_cd7"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hinsyu_cd7"]);
			paramCol["Hinsyu_cd8"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hinsyu_cd8"]);
			paramCol["Hinsyu_cd9"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hinsyu_cd9"]);
			paramCol["Burando_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Burando_cd"]);
			paramCol["Burando_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Burando_nm"]);
			paramCol["Old_jisya_hbn"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Old_jisya_hbn"]);
			paramCol["Maker_hbn"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Maker_hbn"]);
			paramCol["Scan_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Scan_cd"]);
			paramCol["Add_ymd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Add_ymd_from"]);
			paramCol["Add_ymd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Add_ymd_to"]);
			paramCol["Tantosya_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tantosya_cd"]);
			paramCol["Hanbaiin_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hanbaiin_nm"]);
			paramCol["Irairiyu_cd1"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Irairiyu_cd1"]);
			paramCol["Irairiyu_cd2"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Irairiyu_cd2"]);
			paramCol["Hyoka_kb_mise"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hyoka_kb_mise"]);
			paramCol["Hyoka_kb_all"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hyoka_kb_all"]);
			paramCol["Sortkb1"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Sortkb1"]);
			paramCol["Sortoptionkb1"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Sortoptionkb1"]);
			paramCol["Sortkb2"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Sortkb2"]);
			paramCol["Sortoptionkb2"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Sortoptionkb2"]);
			paramCol["Sortkb3"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Sortkb3"]);
			paramCol["Sortoptionkb3"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Sortoptionkb3"]);
			paramCol["Gokei_irai_su"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokei_irai_su"]);
			paramCol["Gokei_genkakin"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokei_genkakin"]);
			paramCol["Footer_zan_kin"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Footer_zan_kin"]);
			SCSubBasePage scPage = (SCSubBasePage)page;
			if(StandardBaseCheckManager.CheckUseSelfCustomize()){
				// カード部カスタム項目の値を取得する
				scPage.GetCardRequestValue(paramCol);
			}

			//明細「M1」項目の入力値を取得する
			Repeater M1 = (Repeater)page.FindControl("M1");
			for (int i = 0; i < formVO.GetList("M1").CurrentCount; i++)
			{
				paramCol["M1rowno"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1rowno"]);
				paramCol["M1bumonkana_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1bumonkana_nm"]);
				paramCol["M1ten_hyoka_kb"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1ten_hyoka_kb"]);
				paramCol["M1all_hyoka_kb"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1all_hyoka_kb"]);
				paramCol["M1tosyu_uriage_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tosyu_uriage_su"]);
				paramCol["M1hinsyu_ryaku_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hinsyu_ryaku_nm"]);
				paramCol["M1zensyu_uriage_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1zensyu_uriage_su"]);
				paramCol["M1zenzensyu_uriage_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1zenzensyu_uriage_su"]);
				paramCol["M1burando_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1burando_nm"]);
				paramCol["M1nyukayotei_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1nyukayotei_su"]);
				paramCol["M1tenzaiko_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tenzaiko_su"]);
				paramCol["M1jido_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1jido_su"]);
				paramCol["M1haibunkano_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1haibunkano_su"]);
				paramCol["M1jisya_hbn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1jisya_hbn"]);
				paramCol["M1keikaku_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1keikaku_ymd"]);
				paramCol["M1syohin_zokusei"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1syohin_zokusei"]);
				paramCol["M1lot_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1lot_su"]);
				paramCol["M1maker_hbn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1maker_hbn"]);
				paramCol["M1syonmk"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1syonmk"]);
				paramCol["M1iro_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1iro_nm"]);
				paramCol["M1size_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1size_nm"]);
				paramCol["M1scan_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1scan_cd"]);
				paramCol["M1irai_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1irai_su"]);
				paramCol["M1hatchu_msg"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hatchu_msg"]);
				paramCol["M1genkakin"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1genkakin"]);
				paramCol["M1hanbaiin_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hanbaiin_nm"]);
				paramCol["M1irairiyu_cd1"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1irairiyu_cd1"]);
				paramCol["M1irairiyu_cd2"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1irairiyu_cd2"]);
				paramCol["M1add_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1add_ymd"]);
				paramCol["M1hanbaikanryo_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hanbaikanryo_ymd"]);
				paramCol["M1uriage_su_hdn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1uriage_su_hdn"]);
				paramCol["M1irai_su_hdn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1irai_su_hdn"]);
				paramCol["M1irairiyu_cd_hdn1"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1irairiyu_cd_hdn1"]);
				paramCol["M1irairiyu_cd_hdn2"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1irairiyu_cd_hdn2"]);
				paramCol["M1gen_tnk"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1gen_tnk"]);
				paramCol["M1genkakin_hdn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1genkakin_hdn"]);
				paramCol["M1selectorcheckbox"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1selectorcheckbox"]);
				paramCol["M1entersyoriflg"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1entersyoriflg"]);
				paramCol["M1dtlirokbn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1dtlirokbn"]);
			}
			pageContext.ParamCollection = paramCol;
		}
		
		/// <summary>
		/// 継承ファイルを拡張します。
		/// </summary>
		/// <param name="pageContext">ページコンテキスト</param>
		public static void ExtItemInfo(IPageContext pageContext)
		{
			RequestParameterCollection paramCol = pageContext.ParamCollection;
			
			//
			// 継承ファイル拡張 ロジックをここに追加してください。
			//

		}

		/// <summary>
		/// 入力値をアンフォーマットします。
		/// </summary>
		/// <param name="pageContext">ページコンテキスト</param>
		public static void Unformat(IPageContext pageContext)
		{
			RequestParameterCollection paramCol = pageContext.ParamCollection;

			//画面情報を取得する
			IFormInfo formInfo = pageContext.FormInfo;
			//FormVOを取得する
			Ta080f03Form formVO = (Ta080f03Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Stkmodeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Stkmodeno"].RequestValue, formInfo["Stkmodeno"]);
			paramCol["Meisai_modeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Meisai_modeno"].RequestValue, formInfo["Meisai_modeno"]);
			paramCol["Meisai_stkmodeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Meisai_stkmodeno"].RequestValue, formInfo["Meisai_stkmodeno"]);
			paramCol["Yosan_ymd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Yosan_ymd"].RequestValue, formInfo["Yosan_ymd"]);
			paramCol["Yosan_ymd"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Yosan_ymd"].RequestValue, formInfo["Yosan_ymd"]);
			paramCol["Yosan_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Yosan_cd"].RequestValue, formInfo["Yosan_cd"]);
			paramCol["Yosan_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Yosan_nm"].RequestValue, formInfo["Yosan_nm"]);
			paramCol["Yosan_kin"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Yosan_kin"].RequestValue, formInfo["Yosan_kin"]);
			paramCol["Misinsei_su"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Misinsei_su"].RequestValue, formInfo["Misinsei_su"]);
			paramCol["Misinsei_kin"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Misinsei_kin"].RequestValue, formInfo["Misinsei_kin"]);
			paramCol["Apply_su"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Apply_su"].RequestValue, formInfo["Apply_su"]);
			paramCol["Apply_kin"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Apply_kin"].RequestValue, formInfo["Apply_kin"]);
			paramCol["Jisseki_su"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Jisseki_su"].RequestValue, formInfo["Jisseki_su"]);
			paramCol["Jisseki_kin"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Jisseki_kin"].RequestValue, formInfo["Jisseki_kin"]);
			paramCol["Zan_kin"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Zan_kin"].RequestValue, formInfo["Zan_kin"]);
			paramCol["Yosan_ymd1"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Yosan_ymd1"].RequestValue, formInfo["Yosan_ymd1"]);
			paramCol["Yosan_ymd1"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Yosan_ymd1"].RequestValue, formInfo["Yosan_ymd1"]);
			paramCol["Yosan_cd1"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Yosan_cd1"].RequestValue, formInfo["Yosan_cd1"]);
			paramCol["Yosan_nm1"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Yosan_nm1"].RequestValue, formInfo["Yosan_nm1"]);
			paramCol["Bumon_cd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_cd_from"].RequestValue, formInfo["Bumon_cd_from"]);
			paramCol["Bumon_nm_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_nm_from"].RequestValue, formInfo["Bumon_nm_from"]);
			paramCol["Bumon_cd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_cd_to"].RequestValue, formInfo["Bumon_cd_to"]);
			paramCol["Bumon_nm_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_nm_to"].RequestValue, formInfo["Bumon_nm_to"]);
			paramCol["Hinsyu_cd_all"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hinsyu_cd_all"].RequestValue, formInfo["Hinsyu_cd_all"]);
			paramCol["Hinsyu_cd1"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hinsyu_cd1"].RequestValue, formInfo["Hinsyu_cd1"]);
			paramCol["Hinsyu_cd2"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hinsyu_cd2"].RequestValue, formInfo["Hinsyu_cd2"]);
			paramCol["Hinsyu_cd3"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hinsyu_cd3"].RequestValue, formInfo["Hinsyu_cd3"]);
			paramCol["Hinsyu_cd4"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hinsyu_cd4"].RequestValue, formInfo["Hinsyu_cd4"]);
			paramCol["Hinsyu_cd5"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hinsyu_cd5"].RequestValue, formInfo["Hinsyu_cd5"]);
			paramCol["Hinsyu_cd6"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hinsyu_cd6"].RequestValue, formInfo["Hinsyu_cd6"]);
			paramCol["Hinsyu_cd7"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hinsyu_cd7"].RequestValue, formInfo["Hinsyu_cd7"]);
			paramCol["Hinsyu_cd8"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hinsyu_cd8"].RequestValue, formInfo["Hinsyu_cd8"]);
			paramCol["Hinsyu_cd9"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hinsyu_cd9"].RequestValue, formInfo["Hinsyu_cd9"]);
			paramCol["Burando_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Burando_cd"].RequestValue, formInfo["Burando_cd"]);
			paramCol["Burando_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Burando_nm"].RequestValue, formInfo["Burando_nm"]);
			paramCol["Old_jisya_hbn"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Old_jisya_hbn"].RequestValue, formInfo["Old_jisya_hbn"]);
			paramCol["Maker_hbn"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Maker_hbn"].RequestValue, formInfo["Maker_hbn"]);
			paramCol["Scan_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Scan_cd"].RequestValue, formInfo["Scan_cd"]);
			paramCol["Add_ymd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Add_ymd_from"].RequestValue, formInfo["Add_ymd_from"]);
			paramCol["Add_ymd_from"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Add_ymd_from"].RequestValue, formInfo["Add_ymd_from"]);
			paramCol["Add_ymd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Add_ymd_to"].RequestValue, formInfo["Add_ymd_to"]);
			paramCol["Add_ymd_to"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Add_ymd_to"].RequestValue, formInfo["Add_ymd_to"]);
			paramCol["Tantosya_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tantosya_cd"].RequestValue, formInfo["Tantosya_cd"]);
			paramCol["Hanbaiin_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hanbaiin_nm"].RequestValue, formInfo["Hanbaiin_nm"]);
			paramCol["Irairiyu_cd1"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Irairiyu_cd1"].RequestValue, formInfo["Irairiyu_cd1"]);
			paramCol["Irairiyu_cd2"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Irairiyu_cd2"].RequestValue, formInfo["Irairiyu_cd2"]);
			paramCol["Hyoka_kb_mise"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hyoka_kb_mise"].RequestValue, formInfo["Hyoka_kb_mise"]);
			paramCol["Hyoka_kb_all"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hyoka_kb_all"].RequestValue, formInfo["Hyoka_kb_all"]);
			paramCol["Sortkb1"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Sortkb1"].RequestValue, formInfo["Sortkb1"]);
			paramCol["Sortoptionkb1"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Sortoptionkb1"].RequestValue, formInfo["Sortoptionkb1"]);
			paramCol["Sortkb2"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Sortkb2"].RequestValue, formInfo["Sortkb2"]);
			paramCol["Sortoptionkb2"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Sortoptionkb2"].RequestValue, formInfo["Sortoptionkb2"]);
			paramCol["Sortkb3"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Sortkb3"].RequestValue, formInfo["Sortkb3"]);
			paramCol["Sortoptionkb3"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Sortoptionkb3"].RequestValue, formInfo["Sortoptionkb3"]);
			paramCol["Gokei_irai_su"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokei_irai_su"].RequestValue, formInfo["Gokei_irai_su"]);
			paramCol["Gokei_genkakin"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokei_genkakin"].RequestValue, formInfo["Gokei_genkakin"]);
			paramCol["Footer_zan_kin"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Footer_zan_kin"].RequestValue, formInfo["Footer_zan_kin"]);
			SCSubBasePage page = (SCSubBasePage)HttpContext.Current.Handler;
			if(StandardBaseCheckManager.CheckUseSelfCustomize()){
				// カード部カスタム項目のアンフォーマット値を取得する
				page.UnformatCard(paramCol);
			}

			//明細「M1」項目のアンフォーマット値を取得する
			for (int i = 0; i < formVO.GetList("M1").CurrentCount; i++)
			{
				paramCol["M1rowno"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1rowno"][i].RequestValue, formInfo["M1rowno"]);
				paramCol["M1bumonkana_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1bumonkana_nm"][i].RequestValue, formInfo["M1bumonkana_nm"]);
				paramCol["M1ten_hyoka_kb"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1ten_hyoka_kb"][i].RequestValue, formInfo["M1ten_hyoka_kb"]);
				paramCol["M1all_hyoka_kb"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1all_hyoka_kb"][i].RequestValue, formInfo["M1all_hyoka_kb"]);
				paramCol["M1tosyu_uriage_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tosyu_uriage_su"][i].RequestValue, formInfo["M1tosyu_uriage_su"]);
				paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hinsyu_ryaku_nm"][i].RequestValue, formInfo["M1hinsyu_ryaku_nm"]);
				paramCol["M1zensyu_uriage_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1zensyu_uriage_su"][i].RequestValue, formInfo["M1zensyu_uriage_su"]);
				paramCol["M1zenzensyu_uriage_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1zenzensyu_uriage_su"][i].RequestValue, formInfo["M1zenzensyu_uriage_su"]);
				paramCol["M1burando_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1burando_nm"][i].RequestValue, formInfo["M1burando_nm"]);
				paramCol["M1nyukayotei_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1nyukayotei_su"][i].RequestValue, formInfo["M1nyukayotei_su"]);
				paramCol["M1tenzaiko_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tenzaiko_su"][i].RequestValue, formInfo["M1tenzaiko_su"]);
				paramCol["M1jido_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1jido_su"][i].RequestValue, formInfo["M1jido_su"]);
				paramCol["M1haibunkano_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1haibunkano_su"][i].RequestValue, formInfo["M1haibunkano_su"]);
				paramCol["M1jisya_hbn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1jisya_hbn"][i].RequestValue, formInfo["M1jisya_hbn"]);
				paramCol["M1keikaku_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1keikaku_ymd"][i].RequestValue, formInfo["M1keikaku_ymd"]);
				paramCol["M1syohin_zokusei"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1syohin_zokusei"][i].RequestValue, formInfo["M1syohin_zokusei"]);
				paramCol["M1lot_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1lot_su"][i].RequestValue, formInfo["M1lot_su"]);
				paramCol["M1maker_hbn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1maker_hbn"][i].RequestValue, formInfo["M1maker_hbn"]);
				paramCol["M1syonmk"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1syonmk"][i].RequestValue, formInfo["M1syonmk"]);
				paramCol["M1iro_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1iro_nm"][i].RequestValue, formInfo["M1iro_nm"]);
				paramCol["M1size_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1size_nm"][i].RequestValue, formInfo["M1size_nm"]);
				paramCol["M1scan_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1scan_cd"][i].RequestValue, formInfo["M1scan_cd"]);
				paramCol["M1irai_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1irai_su"][i].RequestValue, formInfo["M1irai_su"]);
				paramCol["M1hatchu_msg"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hatchu_msg"][i].RequestValue, formInfo["M1hatchu_msg"]);
				paramCol["M1genkakin"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1genkakin"][i].RequestValue, formInfo["M1genkakin"]);
				paramCol["M1hanbaiin_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hanbaiin_nm"][i].RequestValue, formInfo["M1hanbaiin_nm"]);
				paramCol["M1irairiyu_cd1"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1irairiyu_cd1"][i].RequestValue, formInfo["M1irairiyu_cd1"]);
				paramCol["M1irairiyu_cd2"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1irairiyu_cd2"][i].RequestValue, formInfo["M1irairiyu_cd2"]);
				paramCol["M1add_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1add_ymd"][i].RequestValue, formInfo["M1add_ymd"]);
				paramCol["M1hanbaikanryo_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hanbaikanryo_ymd"][i].RequestValue, formInfo["M1hanbaikanryo_ymd"]);
				paramCol["M1uriage_su_hdn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1uriage_su_hdn"][i].RequestValue, formInfo["M1uriage_su_hdn"]);
				paramCol["M1irai_su_hdn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1irai_su_hdn"][i].RequestValue, formInfo["M1irai_su_hdn"]);
				paramCol["M1irairiyu_cd_hdn1"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1irairiyu_cd_hdn1"][i].RequestValue, formInfo["M1irairiyu_cd_hdn1"]);
				paramCol["M1irairiyu_cd_hdn2"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1irairiyu_cd_hdn2"][i].RequestValue, formInfo["M1irairiyu_cd_hdn2"]);
				paramCol["M1gen_tnk"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1gen_tnk"][i].RequestValue, formInfo["M1gen_tnk"]);
				paramCol["M1genkakin_hdn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1genkakin_hdn"][i].RequestValue, formInfo["M1genkakin_hdn"]);
				paramCol["M1selectorcheckbox"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1selectorcheckbox"][i].RequestValue, formInfo["M1selectorcheckbox"]);
				paramCol["M1entersyoriflg"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1entersyoriflg"][i].RequestValue, formInfo["M1entersyoriflg"]);
				paramCol["M1dtlirokbn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1dtlirokbn"][i].RequestValue, formInfo["M1dtlirokbn"]);
			}

		}

		/// <summary>
		/// フォームVOに入力値を設定します。
		/// </summary>
		/// <param name="pageContext">ページコンテキスト</param>
		public static void CopyForm(IPageContext pageContext)
		{
			RequestParameterCollection paramCol = pageContext.ParamCollection;

			//画面情報を取得する
			IFormInfo formInfo = pageContext.FormInfo;
			//FormVOを取得する
			Ta080f03Form formVO = (Ta080f03Form)pageContext.GetFormVO();

			//カード項目の入力値をFormVOにコピーする
			if (paramCol["Head_tenpo_cd"].UnformatValue != null)
			{
				formVO.Head_tenpo_cd = paramCol["Head_tenpo_cd"].UnformatValue;
			}
			if (paramCol["Head_tenpo_nm"].UnformatValue != null)
			{
				formVO.Head_tenpo_nm = paramCol["Head_tenpo_nm"].UnformatValue;
			}
			if (paramCol["Stkmodeno"].UnformatValue != null)
			{
				formVO.Stkmodeno = paramCol["Stkmodeno"].UnformatValue;
			}
			if (paramCol["Meisai_modeno"].UnformatValue != null)
			{
				formVO.Meisai_modeno = paramCol["Meisai_modeno"].UnformatValue;
			}
			if (paramCol["Meisai_stkmodeno"].UnformatValue != null)
			{
				formVO.Meisai_stkmodeno = paramCol["Meisai_stkmodeno"].UnformatValue;
			}
			if (paramCol["Yosan_ymd"].DateFullValue != null)
			{
				formVO.Yosan_ymd = paramCol["Yosan_ymd"].DateFullValue;
			}
			if (paramCol["Yosan_cd"].UnformatValue != null)
			{
				formVO.Yosan_cd = paramCol["Yosan_cd"].UnformatValue;
			}
			if (paramCol["Yosan_nm"].UnformatValue != null)
			{
				formVO.Yosan_nm = paramCol["Yosan_nm"].UnformatValue;
			}
			if (paramCol["Yosan_kin"].UnformatValue != null)
			{
				formVO.Yosan_kin = paramCol["Yosan_kin"].UnformatValue;
			}
			if (paramCol["Misinsei_su"].UnformatValue != null)
			{
				formVO.Misinsei_su = paramCol["Misinsei_su"].UnformatValue;
			}
			if (paramCol["Misinsei_kin"].UnformatValue != null)
			{
				formVO.Misinsei_kin = paramCol["Misinsei_kin"].UnformatValue;
			}
			if (paramCol["Apply_su"].UnformatValue != null)
			{
				formVO.Apply_su = paramCol["Apply_su"].UnformatValue;
			}
			if (paramCol["Apply_kin"].UnformatValue != null)
			{
				formVO.Apply_kin = paramCol["Apply_kin"].UnformatValue;
			}
			if (paramCol["Jisseki_su"].UnformatValue != null)
			{
				formVO.Jisseki_su = paramCol["Jisseki_su"].UnformatValue;
			}
			if (paramCol["Jisseki_kin"].UnformatValue != null)
			{
				formVO.Jisseki_kin = paramCol["Jisseki_kin"].UnformatValue;
			}
			if (paramCol["Zan_kin"].UnformatValue != null)
			{
				formVO.Zan_kin = paramCol["Zan_kin"].UnformatValue;
			}
			if (paramCol["Yosan_ymd1"].DateFullValue != null)
			{
				formVO.Yosan_ymd1 = paramCol["Yosan_ymd1"].DateFullValue;
			}
			if (paramCol["Yosan_cd1"].UnformatValue != null)
			{
				formVO.Yosan_cd1 = paramCol["Yosan_cd1"].UnformatValue;
			}
			if (paramCol["Yosan_nm1"].UnformatValue != null)
			{
				formVO.Yosan_nm1 = paramCol["Yosan_nm1"].UnformatValue;
			}
			if (paramCol["Bumon_cd_from"].UnformatValue != null)
			{
				formVO.Bumon_cd_from = paramCol["Bumon_cd_from"].UnformatValue;
			}
			if (paramCol["Bumon_nm_from"].UnformatValue != null)
			{
				formVO.Bumon_nm_from = paramCol["Bumon_nm_from"].UnformatValue;
			}
			if (paramCol["Bumon_cd_to"].UnformatValue != null)
			{
				formVO.Bumon_cd_to = paramCol["Bumon_cd_to"].UnformatValue;
			}
			if (paramCol["Bumon_nm_to"].UnformatValue != null)
			{
				formVO.Bumon_nm_to = paramCol["Bumon_nm_to"].UnformatValue;
			}
			if (paramCol["Hinsyu_cd_all"].UnformatValue != null)
			{
				formVO.Hinsyu_cd_all = paramCol["Hinsyu_cd_all"].UnformatValue;
			}
			if (paramCol["Hinsyu_cd1"].UnformatValue != null)
			{
				formVO.Hinsyu_cd1 = paramCol["Hinsyu_cd1"].UnformatValue;
			}
			if (paramCol["Hinsyu_cd2"].UnformatValue != null)
			{
				formVO.Hinsyu_cd2 = paramCol["Hinsyu_cd2"].UnformatValue;
			}
			if (paramCol["Hinsyu_cd3"].UnformatValue != null)
			{
				formVO.Hinsyu_cd3 = paramCol["Hinsyu_cd3"].UnformatValue;
			}
			if (paramCol["Hinsyu_cd4"].UnformatValue != null)
			{
				formVO.Hinsyu_cd4 = paramCol["Hinsyu_cd4"].UnformatValue;
			}
			if (paramCol["Hinsyu_cd5"].UnformatValue != null)
			{
				formVO.Hinsyu_cd5 = paramCol["Hinsyu_cd5"].UnformatValue;
			}
			if (paramCol["Hinsyu_cd6"].UnformatValue != null)
			{
				formVO.Hinsyu_cd6 = paramCol["Hinsyu_cd6"].UnformatValue;
			}
			if (paramCol["Hinsyu_cd7"].UnformatValue != null)
			{
				formVO.Hinsyu_cd7 = paramCol["Hinsyu_cd7"].UnformatValue;
			}
			if (paramCol["Hinsyu_cd8"].UnformatValue != null)
			{
				formVO.Hinsyu_cd8 = paramCol["Hinsyu_cd8"].UnformatValue;
			}
			if (paramCol["Hinsyu_cd9"].UnformatValue != null)
			{
				formVO.Hinsyu_cd9 = paramCol["Hinsyu_cd9"].UnformatValue;
			}
			if (paramCol["Burando_cd"].UnformatValue != null)
			{
				formVO.Burando_cd = paramCol["Burando_cd"].UnformatValue;
			}
			if (paramCol["Burando_nm"].UnformatValue != null)
			{
				formVO.Burando_nm = paramCol["Burando_nm"].UnformatValue;
			}
			if (paramCol["Old_jisya_hbn"].UnformatValue != null)
			{
				formVO.Old_jisya_hbn = paramCol["Old_jisya_hbn"].UnformatValue;
			}
			if (paramCol["Maker_hbn"].UnformatValue != null)
			{
				formVO.Maker_hbn = paramCol["Maker_hbn"].UnformatValue;
			}
			if (paramCol["Scan_cd"].UnformatValue != null)
			{
				formVO.Scan_cd = paramCol["Scan_cd"].UnformatValue;
			}
			if (paramCol["Add_ymd_from"].DateFullValue != null)
			{
				formVO.Add_ymd_from = paramCol["Add_ymd_from"].DateFullValue;
			}
			if (paramCol["Add_ymd_to"].DateFullValue != null)
			{
				formVO.Add_ymd_to = paramCol["Add_ymd_to"].DateFullValue;
			}
			if (paramCol["Tantosya_cd"].UnformatValue != null)
			{
				formVO.Tantosya_cd = paramCol["Tantosya_cd"].UnformatValue;
			}
			if (paramCol["Hanbaiin_nm"].UnformatValue != null)
			{
				formVO.Hanbaiin_nm = paramCol["Hanbaiin_nm"].UnformatValue;
			}
			if (paramCol["Irairiyu_cd1"].UnformatValue != null)
			{
				formVO.Irairiyu_cd1 = paramCol["Irairiyu_cd1"].UnformatValue;
			}
			if (paramCol["Irairiyu_cd2"].UnformatValue != null)
			{
				formVO.Irairiyu_cd2 = paramCol["Irairiyu_cd2"].UnformatValue;
			}
			if (paramCol["Hyoka_kb_mise"].UnformatValue != null)
			{
				formVO.Hyoka_kb_mise = paramCol["Hyoka_kb_mise"].UnformatValue;
			}
			if (paramCol["Hyoka_kb_all"].UnformatValue != null)
			{
				formVO.Hyoka_kb_all = paramCol["Hyoka_kb_all"].UnformatValue;
			}
			if (paramCol["Sortkb1"].UnformatValue != null)
			{
				formVO.Sortkb1 = paramCol["Sortkb1"].UnformatValue;
			}
			if (paramCol["Sortoptionkb1"].UnformatValue != null)
			{
				formVO.Sortoptionkb1 = paramCol["Sortoptionkb1"].UnformatValue;
			}
			if (paramCol["Sortkb2"].UnformatValue != null)
			{
				formVO.Sortkb2 = paramCol["Sortkb2"].UnformatValue;
			}
			if (paramCol["Sortoptionkb2"].UnformatValue != null)
			{
				formVO.Sortoptionkb2 = paramCol["Sortoptionkb2"].UnformatValue;
			}
			if (paramCol["Sortkb3"].UnformatValue != null)
			{
				formVO.Sortkb3 = paramCol["Sortkb3"].UnformatValue;
			}
			if (paramCol["Sortoptionkb3"].UnformatValue != null)
			{
				formVO.Sortoptionkb3 = paramCol["Sortoptionkb3"].UnformatValue;
			}
			if (paramCol["Gokei_irai_su"].UnformatValue != null)
			{
				formVO.Gokei_irai_su = paramCol["Gokei_irai_su"].UnformatValue;
			}
			if (paramCol["Gokei_genkakin"].UnformatValue != null)
			{
				formVO.Gokei_genkakin = paramCol["Gokei_genkakin"].UnformatValue;
			}
			if (paramCol["Footer_zan_kin"].UnformatValue != null)
			{
				formVO.Footer_zan_kin = paramCol["Footer_zan_kin"].UnformatValue;
			}
			if(StandardBaseCheckManager.CheckUseSelfCustomize()){
				// カード部カスタム項目の入力値をFormVOにコピーする
				SCSubBasePage page = (SCSubBasePage)HttpContext.Current.Handler;
				page.CopyCardForm(paramCol, formVO);
			}

			//明細「M1」項目の入力値をFormVOにコピーする
			IDataList m1List = formVO.GetList("M1");
			for (int i = 0; i < m1List.CurrentCount; i++)
			{
				Ta080f03M1Form ta080f03M1Form = (Ta080f03M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					ta080f03M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1bumonkana_nm"][i].UnformatValue != null)
				{
					ta080f03M1Form.M1bumonkana_nm = paramCol["M1bumonkana_nm"][i].UnformatValue;
				}
				if (paramCol["M1ten_hyoka_kb"][i].UnformatValue != null)
				{
					ta080f03M1Form.M1ten_hyoka_kb = paramCol["M1ten_hyoka_kb"][i].UnformatValue;
				}
				if (paramCol["M1all_hyoka_kb"][i].UnformatValue != null)
				{
					ta080f03M1Form.M1all_hyoka_kb = paramCol["M1all_hyoka_kb"][i].UnformatValue;
				}
				if (paramCol["M1tosyu_uriage_su"][i].UnformatValue != null)
				{
					ta080f03M1Form.M1tosyu_uriage_su = paramCol["M1tosyu_uriage_su"][i].UnformatValue;
				}
				if (paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue != null)
				{
					ta080f03M1Form.M1hinsyu_ryaku_nm = paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue;
				}
				if (paramCol["M1zensyu_uriage_su"][i].UnformatValue != null)
				{
					ta080f03M1Form.M1zensyu_uriage_su = paramCol["M1zensyu_uriage_su"][i].UnformatValue;
				}
				if (paramCol["M1zenzensyu_uriage_su"][i].UnformatValue != null)
				{
					ta080f03M1Form.M1zenzensyu_uriage_su = paramCol["M1zenzensyu_uriage_su"][i].UnformatValue;
				}
				if (paramCol["M1burando_nm"][i].UnformatValue != null)
				{
					ta080f03M1Form.M1burando_nm = paramCol["M1burando_nm"][i].UnformatValue;
				}
				if (paramCol["M1nyukayotei_su"][i].UnformatValue != null)
				{
					ta080f03M1Form.M1nyukayotei_su = paramCol["M1nyukayotei_su"][i].UnformatValue;
				}
				if (paramCol["M1tenzaiko_su"][i].UnformatValue != null)
				{
					ta080f03M1Form.M1tenzaiko_su = paramCol["M1tenzaiko_su"][i].UnformatValue;
				}
				if (paramCol["M1jido_su"][i].UnformatValue != null)
				{
					ta080f03M1Form.M1jido_su = paramCol["M1jido_su"][i].UnformatValue;
				}
				if (paramCol["M1haibunkano_su"][i].UnformatValue != null)
				{
					ta080f03M1Form.M1haibunkano_su = paramCol["M1haibunkano_su"][i].UnformatValue;
				}
				if (paramCol["M1jisya_hbn"][i].UnformatValue != null)
				{
					ta080f03M1Form.M1jisya_hbn = paramCol["M1jisya_hbn"][i].UnformatValue;
				}
				if (paramCol["M1keikaku_ymd"][i].UnformatValue != null)
				{
					ta080f03M1Form.M1keikaku_ymd = paramCol["M1keikaku_ymd"][i].UnformatValue;
				}
				if (paramCol["M1syohin_zokusei"][i].UnformatValue != null)
				{
					ta080f03M1Form.M1syohin_zokusei = paramCol["M1syohin_zokusei"][i].UnformatValue;
				}
				if (paramCol["M1lot_su"][i].UnformatValue != null)
				{
					ta080f03M1Form.M1lot_su = paramCol["M1lot_su"][i].UnformatValue;
				}
				if (paramCol["M1maker_hbn"][i].UnformatValue != null)
				{
					ta080f03M1Form.M1maker_hbn = paramCol["M1maker_hbn"][i].UnformatValue;
				}
				if (paramCol["M1syonmk"][i].UnformatValue != null)
				{
					ta080f03M1Form.M1syonmk = paramCol["M1syonmk"][i].UnformatValue;
				}
				if (paramCol["M1iro_nm"][i].UnformatValue != null)
				{
					ta080f03M1Form.M1iro_nm = paramCol["M1iro_nm"][i].UnformatValue;
				}
				if (paramCol["M1size_nm"][i].UnformatValue != null)
				{
					ta080f03M1Form.M1size_nm = paramCol["M1size_nm"][i].UnformatValue;
				}
				if (paramCol["M1scan_cd"][i].UnformatValue != null)
				{
					ta080f03M1Form.M1scan_cd = paramCol["M1scan_cd"][i].UnformatValue;
				}
				if (paramCol["M1irai_su"][i].UnformatValue != null)
				{
					ta080f03M1Form.M1irai_su = paramCol["M1irai_su"][i].UnformatValue;
				}
				if (paramCol["M1hatchu_msg"][i].UnformatValue != null)
				{
					ta080f03M1Form.M1hatchu_msg = paramCol["M1hatchu_msg"][i].UnformatValue;
				}
				if (paramCol["M1genkakin"][i].UnformatValue != null)
				{
					ta080f03M1Form.M1genkakin = paramCol["M1genkakin"][i].UnformatValue;
				}
				if (paramCol["M1hanbaiin_nm"][i].UnformatValue != null)
				{
					ta080f03M1Form.M1hanbaiin_nm = paramCol["M1hanbaiin_nm"][i].UnformatValue;
				}
				if (paramCol["M1irairiyu_cd1"][i].UnformatValue != null)
				{
					ta080f03M1Form.M1irairiyu_cd1 = paramCol["M1irairiyu_cd1"][i].UnformatValue;
				}
				if (paramCol["M1irairiyu_cd2"][i].UnformatValue != null)
				{
					ta080f03M1Form.M1irairiyu_cd2 = paramCol["M1irairiyu_cd2"][i].UnformatValue;
				}
				if (paramCol["M1add_ymd"][i].UnformatValue != null)
				{
					ta080f03M1Form.M1add_ymd = paramCol["M1add_ymd"][i].UnformatValue;
				}
				if (paramCol["M1hanbaikanryo_ymd"][i].UnformatValue != null)
				{
					ta080f03M1Form.M1hanbaikanryo_ymd = paramCol["M1hanbaikanryo_ymd"][i].UnformatValue;
				}
				if (paramCol["M1uriage_su_hdn"][i].UnformatValue != null)
				{
					ta080f03M1Form.M1uriage_su_hdn = paramCol["M1uriage_su_hdn"][i].UnformatValue;
				}
				if (paramCol["M1irai_su_hdn"][i].UnformatValue != null)
				{
					ta080f03M1Form.M1irai_su_hdn = paramCol["M1irai_su_hdn"][i].UnformatValue;
				}
				if (paramCol["M1irairiyu_cd_hdn1"][i].UnformatValue != null)
				{
					ta080f03M1Form.M1irairiyu_cd_hdn1 = paramCol["M1irairiyu_cd_hdn1"][i].UnformatValue;
				}
				if (paramCol["M1irairiyu_cd_hdn2"][i].UnformatValue != null)
				{
					ta080f03M1Form.M1irairiyu_cd_hdn2 = paramCol["M1irairiyu_cd_hdn2"][i].UnformatValue;
				}
				if (paramCol["M1gen_tnk"][i].UnformatValue != null)
				{
					ta080f03M1Form.M1gen_tnk = paramCol["M1gen_tnk"][i].UnformatValue;
				}
				if (paramCol["M1genkakin_hdn"][i].UnformatValue != null)
				{
					ta080f03M1Form.M1genkakin_hdn = paramCol["M1genkakin_hdn"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					ta080f03M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					ta080f03M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					ta080f03M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
				}
			}
			if(StandardBaseCheckManager.CheckUseSelfCustomize()){
				// カード部カスタム項目の入力値をFormVOにコピーする
				SCSubBasePage page = (SCSubBasePage)HttpContext.Current.Handler;
				// 明細「M1」のカスタム項目の入力値をFormVOにコピーする
				page.CopyListForm("M1", paramCol, formVO);
			}
		}

		/// <summary>
		/// カード項目の入力値チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardInputValue(Ta080f03Form formVO, StandardCheckManager checker)
		{
			if (formVO.Head_tenpo_cd != null)
			{
				checker.DoCheck("Head_tenpo_cd", formVO.Head_tenpo_cd);
			}
			if (formVO.Head_tenpo_nm != null)
			{
				checker.DoCheck("Head_tenpo_nm", formVO.Head_tenpo_nm);
			}
			if (formVO.Stkmodeno != null)
			{
				checker.DoCheck("Stkmodeno", formVO.Stkmodeno);
			}
			if (formVO.Meisai_modeno != null)
			{
				checker.DoCheck("Meisai_modeno", formVO.Meisai_modeno);
			}
			if (formVO.Meisai_stkmodeno != null)
			{
				checker.DoCheck("Meisai_stkmodeno", formVO.Meisai_stkmodeno);
			}
			if (formVO.Yosan_ymd != null)
			{
				checker.DoCheck("Yosan_ymd", formVO.Yosan_ymd);
			}
			if (formVO.Yosan_cd != null)
			{
				checker.DoCheck("Yosan_cd", formVO.Yosan_cd);
			}
			if (formVO.Yosan_nm != null)
			{
				checker.DoCheck("Yosan_nm", formVO.Yosan_nm);
			}
			if (formVO.Yosan_kin != null)
			{
				checker.DoCheck("Yosan_kin", formVO.Yosan_kin);
			}
			if (formVO.Misinsei_su != null)
			{
				checker.DoCheck("Misinsei_su", formVO.Misinsei_su);
			}
			if (formVO.Misinsei_kin != null)
			{
				checker.DoCheck("Misinsei_kin", formVO.Misinsei_kin);
			}
			if (formVO.Apply_su != null)
			{
				checker.DoCheck("Apply_su", formVO.Apply_su);
			}
			if (formVO.Apply_kin != null)
			{
				checker.DoCheck("Apply_kin", formVO.Apply_kin);
			}
			if (formVO.Jisseki_su != null)
			{
				checker.DoCheck("Jisseki_su", formVO.Jisseki_su);
			}
			if (formVO.Jisseki_kin != null)
			{
				checker.DoCheck("Jisseki_kin", formVO.Jisseki_kin);
			}
			if (formVO.Zan_kin != null)
			{
				checker.DoCheck("Zan_kin", formVO.Zan_kin);
			}
			if (formVO.Yosan_ymd1 != null)
			{
				checker.DoCheck("Yosan_ymd1", formVO.Yosan_ymd1);
			}
			if (formVO.Yosan_cd1 != null)
			{
				checker.DoCheck("Yosan_cd1", formVO.Yosan_cd1);
			}
			if (formVO.Yosan_nm1 != null)
			{
				checker.DoCheck("Yosan_nm1", formVO.Yosan_nm1);
			}
			if (formVO.Bumon_cd_from != null)
			{
				checker.DoCheck("Bumon_cd_from", formVO.Bumon_cd_from);
			}
			if (formVO.Bumon_nm_from != null)
			{
				checker.DoCheck("Bumon_nm_from", formVO.Bumon_nm_from);
			}
			if (formVO.Bumon_cd_to != null)
			{
				checker.DoCheck("Bumon_cd_to", formVO.Bumon_cd_to);
			}
			if (formVO.Bumon_nm_to != null)
			{
				checker.DoCheck("Bumon_nm_to", formVO.Bumon_nm_to);
			}
			if (formVO.Hinsyu_cd_all != null)
			{
				checker.DoCheck("Hinsyu_cd_all", formVO.Hinsyu_cd_all);
			}
			if (formVO.Hinsyu_cd1 != null)
			{
				checker.DoCheck("Hinsyu_cd1", formVO.Hinsyu_cd1);
			}
			if (formVO.Hinsyu_cd2 != null)
			{
				checker.DoCheck("Hinsyu_cd2", formVO.Hinsyu_cd2);
			}
			if (formVO.Hinsyu_cd3 != null)
			{
				checker.DoCheck("Hinsyu_cd3", formVO.Hinsyu_cd3);
			}
			if (formVO.Hinsyu_cd4 != null)
			{
				checker.DoCheck("Hinsyu_cd4", formVO.Hinsyu_cd4);
			}
			if (formVO.Hinsyu_cd5 != null)
			{
				checker.DoCheck("Hinsyu_cd5", formVO.Hinsyu_cd5);
			}
			if (formVO.Hinsyu_cd6 != null)
			{
				checker.DoCheck("Hinsyu_cd6", formVO.Hinsyu_cd6);
			}
			if (formVO.Hinsyu_cd7 != null)
			{
				checker.DoCheck("Hinsyu_cd7", formVO.Hinsyu_cd7);
			}
			if (formVO.Hinsyu_cd8 != null)
			{
				checker.DoCheck("Hinsyu_cd8", formVO.Hinsyu_cd8);
			}
			if (formVO.Hinsyu_cd9 != null)
			{
				checker.DoCheck("Hinsyu_cd9", formVO.Hinsyu_cd9);
			}
			if (formVO.Burando_cd != null)
			{
				checker.DoCheck("Burando_cd", formVO.Burando_cd);
			}
			if (formVO.Burando_nm != null)
			{
				checker.DoCheck("Burando_nm", formVO.Burando_nm);
			}
			if (formVO.Old_jisya_hbn != null)
			{
				checker.DoCheck("Old_jisya_hbn", formVO.Old_jisya_hbn);
			}
			if (formVO.Maker_hbn != null)
			{
				checker.DoCheck("Maker_hbn", formVO.Maker_hbn);
			}
			if (formVO.Scan_cd != null)
			{
				checker.DoCheck("Scan_cd", formVO.Scan_cd);
			}
			if (formVO.Add_ymd_from != null)
			{
				checker.DoCheck("Add_ymd_from", formVO.Add_ymd_from);
			}
			if (formVO.Add_ymd_to != null)
			{
				checker.DoCheck("Add_ymd_to", formVO.Add_ymd_to);
			}
			if (formVO.Tantosya_cd != null)
			{
				checker.DoCheck("Tantosya_cd", formVO.Tantosya_cd);
			}
			if (formVO.Hanbaiin_nm != null)
			{
				checker.DoCheck("Hanbaiin_nm", formVO.Hanbaiin_nm);
			}
			if (formVO.Irairiyu_cd1 != null)
			{
				checker.DoCheck("Irairiyu_cd1", formVO.Irairiyu_cd1);
			}
			if (formVO.Irairiyu_cd2 != null)
			{
				checker.DoCheck("Irairiyu_cd2", formVO.Irairiyu_cd2);
			}
			if (formVO.Hyoka_kb_mise != null)
			{
				checker.DoCheck("Hyoka_kb_mise", formVO.Hyoka_kb_mise);
			}
			if (formVO.Hyoka_kb_all != null)
			{
				checker.DoCheck("Hyoka_kb_all", formVO.Hyoka_kb_all);
			}
			if (formVO.Sortkb1 != null)
			{
				checker.DoCheck("Sortkb1", formVO.Sortkb1);
			}
			if (formVO.Sortoptionkb1 != null)
			{
				checker.DoCheck("Sortoptionkb1", formVO.Sortoptionkb1);
			}
			if (formVO.Sortkb2 != null)
			{
				checker.DoCheck("Sortkb2", formVO.Sortkb2);
			}
			if (formVO.Sortoptionkb2 != null)
			{
				checker.DoCheck("Sortoptionkb2", formVO.Sortoptionkb2);
			}
			if (formVO.Sortkb3 != null)
			{
				checker.DoCheck("Sortkb3", formVO.Sortkb3);
			}
			if (formVO.Sortoptionkb3 != null)
			{
				checker.DoCheck("Sortoptionkb3", formVO.Sortoptionkb3);
			}
			if (formVO.Gokei_irai_su != null)
			{
				checker.DoCheck("Gokei_irai_su", formVO.Gokei_irai_su);
			}
			if (formVO.Gokei_genkakin != null)
			{
				checker.DoCheck("Gokei_genkakin", formVO.Gokei_genkakin);
			}
			if (formVO.Footer_zan_kin != null)
			{
				checker.DoCheck("Footer_zan_kin", formVO.Footer_zan_kin);
			}
			if(StandardBaseCheckManager.CheckUseSelfCustomize()){
				// カード部カスタム項目の入力チェックを実行
				((SCSubBasePage)HttpContext.Current.Handler).CheckCardItems(checker, formVO);
			}
		}

		/// <summary>
		/// 明細「M1」項目の入力値チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1InputValue(Ta080f03Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Ta080f03M1Form ta080f03M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, ta080f03M1Form, i, m1List);
				if (ta080f03M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", ta080f03M1Form.M1rowno, i, m1List);
				}
				if (ta080f03M1Form.M1bumonkana_nm != null)
				{
					checker.DoCheck("M1bumonkana_nm", ta080f03M1Form.M1bumonkana_nm, i, m1List);
				}
				if (ta080f03M1Form.M1ten_hyoka_kb != null)
				{
					checker.DoCheck("M1ten_hyoka_kb", ta080f03M1Form.M1ten_hyoka_kb, i, m1List);
				}
				if (ta080f03M1Form.M1all_hyoka_kb != null)
				{
					checker.DoCheck("M1all_hyoka_kb", ta080f03M1Form.M1all_hyoka_kb, i, m1List);
				}
				if (ta080f03M1Form.M1tosyu_uriage_su != null)
				{
					checker.DoCheck("M1tosyu_uriage_su", ta080f03M1Form.M1tosyu_uriage_su, i, m1List);
				}
				if (ta080f03M1Form.M1hinsyu_ryaku_nm != null)
				{
					checker.DoCheck("M1hinsyu_ryaku_nm", ta080f03M1Form.M1hinsyu_ryaku_nm, i, m1List);
				}
				if (ta080f03M1Form.M1zensyu_uriage_su != null)
				{
					checker.DoCheck("M1zensyu_uriage_su", ta080f03M1Form.M1zensyu_uriage_su, i, m1List);
				}
				if (ta080f03M1Form.M1zenzensyu_uriage_su != null)
				{
					checker.DoCheck("M1zenzensyu_uriage_su", ta080f03M1Form.M1zenzensyu_uriage_su, i, m1List);
				}
				if (ta080f03M1Form.M1burando_nm != null)
				{
					checker.DoCheck("M1burando_nm", ta080f03M1Form.M1burando_nm, i, m1List);
				}
				if (ta080f03M1Form.M1nyukayotei_su != null)
				{
					checker.DoCheck("M1nyukayotei_su", ta080f03M1Form.M1nyukayotei_su, i, m1List);
				}
				if (ta080f03M1Form.M1tenzaiko_su != null)
				{
					checker.DoCheck("M1tenzaiko_su", ta080f03M1Form.M1tenzaiko_su, i, m1List);
				}
				if (ta080f03M1Form.M1jido_su != null)
				{
					checker.DoCheck("M1jido_su", ta080f03M1Form.M1jido_su, i, m1List);
				}
				if (ta080f03M1Form.M1haibunkano_su != null)
				{
					checker.DoCheck("M1haibunkano_su", ta080f03M1Form.M1haibunkano_su, i, m1List);
				}
				if (ta080f03M1Form.M1jisya_hbn != null)
				{
					checker.DoCheck("M1jisya_hbn", ta080f03M1Form.M1jisya_hbn, i, m1List);
				}
				if (ta080f03M1Form.M1keikaku_ymd != null)
				{
					checker.DoCheck("M1keikaku_ymd", ta080f03M1Form.M1keikaku_ymd, i, m1List);
				}
				if (ta080f03M1Form.M1syohin_zokusei != null)
				{
					checker.DoCheck("M1syohin_zokusei", ta080f03M1Form.M1syohin_zokusei, i, m1List);
				}
				if (ta080f03M1Form.M1lot_su != null)
				{
					checker.DoCheck("M1lot_su", ta080f03M1Form.M1lot_su, i, m1List);
				}
				if (ta080f03M1Form.M1maker_hbn != null)
				{
					checker.DoCheck("M1maker_hbn", ta080f03M1Form.M1maker_hbn, i, m1List);
				}
				if (ta080f03M1Form.M1syonmk != null)
				{
					checker.DoCheck("M1syonmk", ta080f03M1Form.M1syonmk, i, m1List);
				}
				if (ta080f03M1Form.M1iro_nm != null)
				{
					checker.DoCheck("M1iro_nm", ta080f03M1Form.M1iro_nm, i, m1List);
				}
				if (ta080f03M1Form.M1size_nm != null)
				{
					checker.DoCheck("M1size_nm", ta080f03M1Form.M1size_nm, i, m1List);
				}
				if (ta080f03M1Form.M1scan_cd != null)
				{
					checker.DoCheck("M1scan_cd", ta080f03M1Form.M1scan_cd, i, m1List);
				}
				if (ta080f03M1Form.M1irai_su != null)
				{
					checker.DoCheck("M1irai_su", ta080f03M1Form.M1irai_su, i, m1List);
				}
				if (ta080f03M1Form.M1hatchu_msg != null)
				{
					checker.DoCheck("M1hatchu_msg", ta080f03M1Form.M1hatchu_msg, i, m1List);
				}
				if (ta080f03M1Form.M1genkakin != null)
				{
					checker.DoCheck("M1genkakin", ta080f03M1Form.M1genkakin, i, m1List);
				}
				if (ta080f03M1Form.M1hanbaiin_nm != null)
				{
					checker.DoCheck("M1hanbaiin_nm", ta080f03M1Form.M1hanbaiin_nm, i, m1List);
				}
				if (ta080f03M1Form.M1irairiyu_cd1 != null)
				{
					checker.DoCheck("M1irairiyu_cd1", ta080f03M1Form.M1irairiyu_cd1, i, m1List);
				}
				if (ta080f03M1Form.M1irairiyu_cd2 != null)
				{
					checker.DoCheck("M1irairiyu_cd2", ta080f03M1Form.M1irairiyu_cd2, i, m1List);
				}
				if (ta080f03M1Form.M1add_ymd != null)
				{
					checker.DoCheck("M1add_ymd", ta080f03M1Form.M1add_ymd, i, m1List);
				}
				if (ta080f03M1Form.M1hanbaikanryo_ymd != null)
				{
					checker.DoCheck("M1hanbaikanryo_ymd", ta080f03M1Form.M1hanbaikanryo_ymd, i, m1List);
				}
				if (ta080f03M1Form.M1uriage_su_hdn != null)
				{
					checker.DoCheck("M1uriage_su_hdn", ta080f03M1Form.M1uriage_su_hdn, i, m1List);
				}
				if (ta080f03M1Form.M1irai_su_hdn != null)
				{
					checker.DoCheck("M1irai_su_hdn", ta080f03M1Form.M1irai_su_hdn, i, m1List);
				}
				if (ta080f03M1Form.M1irairiyu_cd_hdn1 != null)
				{
					checker.DoCheck("M1irairiyu_cd_hdn1", ta080f03M1Form.M1irairiyu_cd_hdn1, i, m1List);
				}
				if (ta080f03M1Form.M1irairiyu_cd_hdn2 != null)
				{
					checker.DoCheck("M1irairiyu_cd_hdn2", ta080f03M1Form.M1irairiyu_cd_hdn2, i, m1List);
				}
				if (ta080f03M1Form.M1gen_tnk != null)
				{
					checker.DoCheck("M1gen_tnk", ta080f03M1Form.M1gen_tnk, i, m1List);
				}
				if (ta080f03M1Form.M1genkakin_hdn != null)
				{
					checker.DoCheck("M1genkakin_hdn", ta080f03M1Form.M1genkakin_hdn, i, m1List);
				}
				if (ta080f03M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", ta080f03M1Form.M1selectorcheckbox, i, m1List);
				}
				if (ta080f03M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", ta080f03M1Form.M1entersyoriflg, i, m1List);
				}
				if (ta080f03M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", ta080f03M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Ta080f03Form formVO, StandardCodeCheckManager checker)
		{
			checker.DoCheck("Btnbumon_cd_from", formVO);
			checker.DoCheck("Btnbumon_cdto", formVO);
			checker.DoCheck("Btnburando_cd", formVO);
			checker.DoCheck("Btntanto_cd", formVO);
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Ta080f03Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

