using com.xebio.bo.Tj190p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Tj190p01.Request
{
  /// <summary>
  /// Tj190f02RequestHelper の概要の説明です。
  /// </summary>
  public static class Tj190f02RequestHelper
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
			Tj190f02Form formVO = (Tj190f02Form)pageContext.GetFormVO();

			//カード部を初期化する
			paramCol.InitCardItems(formInfo.GetCardItems());
			//明細「M1」部を初期化する
			paramCol.InitListItems(formInfo.GetListItems("M1"), formVO.GetList("M1").CurrentCount);
			//カード項目の入力値を取得する
			paramCol["Head_tenpo_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_nm"]);
			paramCol["Modeno"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Modeno"]);
			paramCol["Stkmodeno"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Stkmodeno"]);
			paramCol["Tenpo_cd_hdn"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tenpo_cd_hdn"]);
			paramCol["Nyuryoku_ymd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Nyuryoku_ymd"]);
			paramCol["Rintana_kanri_no"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Rintana_kanri_no"]);
			paramCol["Loss_kanri_no"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Loss_kanri_no"]);
			paramCol["Bumon_cd_bo"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_cd_bo"]);
			paramCol["Bumon_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_nm"]);
			paramCol["Nyuryokutan_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Nyuryokutan_cd"]);
			paramCol["Nyuryokutan_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Nyuryokutan_nm"]);
			paramCol["Losskeisan_ymd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Losskeisan_ymd"]);
			paramCol["Losskeisan_tm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Losskeisan_tm"]);
			paramCol["Hinsyu_sitei_flg"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hinsyu_sitei_flg"]);
			paramCol["Hinsyu_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hinsyu_cd"]);
			paramCol["Hinsyu_ryaku_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hinsyu_ryaku_nm"]);
			paramCol["Burando_sitei_flg"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Burando_sitei_flg"]);
			paramCol["Burando_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Burando_cd"]);
			paramCol["Burando_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Burando_nm"]);
			paramCol["Burando_cd1"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Burando_cd1"]);
			paramCol["Burando_nm1"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Burando_nm1"]);
			paramCol["Burando_cd2"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Burando_cd2"]);
			paramCol["Burando_nm2"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Burando_nm2"]);
			paramCol["Burando_cd3"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Burando_cd3"]);
			paramCol["Burando_nm3"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Burando_nm3"]);
			paramCol["Burando_cd4"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Burando_cd4"]);
			paramCol["Burando_nm4"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Burando_nm4"]);
			paramCol["Burando_cd5"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Burando_cd5"]);
			paramCol["Burando_nm5"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Burando_nm5"]);
			paramCol["Burando_cd6"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Burando_cd6"]);
			paramCol["Burando_nm6"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Burando_nm6"]);
			paramCol["Burando_cd7"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Burando_cd7"]);
			paramCol["Burando_nm7"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Burando_nm7"]);
			paramCol["Gokeitanajityobo_su"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokeitanajityobo_su"]);
			paramCol["Gokeitanajisekiso_su"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokeitanajisekiso_su"]);
			paramCol["Gokeijitana_su"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokeijitana_su"]);
			paramCol["Gokeiloss_su"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokeiloss_su"]);
			paramCol["Gokeiloss_kin"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokeiloss_kin"]);
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
				paramCol["M1hinsyu_ryaku_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hinsyu_ryaku_nm"]);
				paramCol["M1burando_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1burando_nm"]);
				paramCol["M1jisya_hbn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1jisya_hbn"]);
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
				paramCol["M1hyoka_tnk"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hyoka_tnk"]);
				paramCol["M1tanajityobo_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tanajityobo_su"]);
				paramCol["M1tanajityobo_su_hdn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tanajityobo_su_hdn"]);
				paramCol["M1tanajisekiso_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tanajisekiso_su"]);
				paramCol["M1tanajisekiso_su_hdn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tanajisekiso_su_hdn"]);
				paramCol["M1jitana_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1jitana_su"]);
				paramCol["M1jitana_su1_hdn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1jitana_su1_hdn"]);
				paramCol["M1loss_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1loss_su"]);
				paramCol["M1loss_kin"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1loss_kin"]);
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
			Tj190f02Form formVO = (Tj190f02Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Modeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Modeno"].RequestValue, formInfo["Modeno"]);
			paramCol["Stkmodeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Stkmodeno"].RequestValue, formInfo["Stkmodeno"]);
			paramCol["Tenpo_cd_hdn"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tenpo_cd_hdn"].RequestValue, formInfo["Tenpo_cd_hdn"]);
			paramCol["Nyuryoku_ymd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Nyuryoku_ymd"].RequestValue, formInfo["Nyuryoku_ymd"]);
			paramCol["Nyuryoku_ymd"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Nyuryoku_ymd"].RequestValue, formInfo["Nyuryoku_ymd"]);
			paramCol["Rintana_kanri_no"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Rintana_kanri_no"].RequestValue, formInfo["Rintana_kanri_no"]);
			paramCol["Loss_kanri_no"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Loss_kanri_no"].RequestValue, formInfo["Loss_kanri_no"]);
			paramCol["Bumon_cd_bo"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_cd_bo"].RequestValue, formInfo["Bumon_cd_bo"]);
			paramCol["Bumon_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_nm"].RequestValue, formInfo["Bumon_nm"]);
			paramCol["Nyuryokutan_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Nyuryokutan_cd"].RequestValue, formInfo["Nyuryokutan_cd"]);
			paramCol["Nyuryokutan_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Nyuryokutan_nm"].RequestValue, formInfo["Nyuryokutan_nm"]);
			paramCol["Losskeisan_ymd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Losskeisan_ymd"].RequestValue, formInfo["Losskeisan_ymd"]);
			paramCol["Losskeisan_ymd"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Losskeisan_ymd"].RequestValue, formInfo["Losskeisan_ymd"]);
			paramCol["Losskeisan_tm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Losskeisan_tm"].RequestValue, formInfo["Losskeisan_tm"]);
			paramCol["Losskeisan_tm"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Losskeisan_tm"].RequestValue, formInfo["Losskeisan_tm"]);
			paramCol["Hinsyu_sitei_flg"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hinsyu_sitei_flg"].RequestValue, formInfo["Hinsyu_sitei_flg"]);
			paramCol["Hinsyu_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hinsyu_cd"].RequestValue, formInfo["Hinsyu_cd"]);
			paramCol["Hinsyu_ryaku_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hinsyu_ryaku_nm"].RequestValue, formInfo["Hinsyu_ryaku_nm"]);
			paramCol["Burando_sitei_flg"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Burando_sitei_flg"].RequestValue, formInfo["Burando_sitei_flg"]);
			paramCol["Burando_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Burando_cd"].RequestValue, formInfo["Burando_cd"]);
			paramCol["Burando_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Burando_nm"].RequestValue, formInfo["Burando_nm"]);
			paramCol["Burando_cd1"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Burando_cd1"].RequestValue, formInfo["Burando_cd1"]);
			paramCol["Burando_nm1"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Burando_nm1"].RequestValue, formInfo["Burando_nm1"]);
			paramCol["Burando_cd2"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Burando_cd2"].RequestValue, formInfo["Burando_cd2"]);
			paramCol["Burando_nm2"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Burando_nm2"].RequestValue, formInfo["Burando_nm2"]);
			paramCol["Burando_cd3"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Burando_cd3"].RequestValue, formInfo["Burando_cd3"]);
			paramCol["Burando_nm3"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Burando_nm3"].RequestValue, formInfo["Burando_nm3"]);
			paramCol["Burando_cd4"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Burando_cd4"].RequestValue, formInfo["Burando_cd4"]);
			paramCol["Burando_nm4"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Burando_nm4"].RequestValue, formInfo["Burando_nm4"]);
			paramCol["Burando_cd5"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Burando_cd5"].RequestValue, formInfo["Burando_cd5"]);
			paramCol["Burando_nm5"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Burando_nm5"].RequestValue, formInfo["Burando_nm5"]);
			paramCol["Burando_cd6"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Burando_cd6"].RequestValue, formInfo["Burando_cd6"]);
			paramCol["Burando_nm6"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Burando_nm6"].RequestValue, formInfo["Burando_nm6"]);
			paramCol["Burando_cd7"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Burando_cd7"].RequestValue, formInfo["Burando_cd7"]);
			paramCol["Burando_nm7"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Burando_nm7"].RequestValue, formInfo["Burando_nm7"]);
			paramCol["Gokeitanajityobo_su"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokeitanajityobo_su"].RequestValue, formInfo["Gokeitanajityobo_su"]);
			paramCol["Gokeitanajisekiso_su"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokeitanajisekiso_su"].RequestValue, formInfo["Gokeitanajisekiso_su"]);
			paramCol["Gokeijitana_su"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokeijitana_su"].RequestValue, formInfo["Gokeijitana_su"]);
			paramCol["Gokeiloss_su"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokeiloss_su"].RequestValue, formInfo["Gokeiloss_su"]);
			paramCol["Gokeiloss_kin"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokeiloss_kin"].RequestValue, formInfo["Gokeiloss_kin"]);
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
				paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hinsyu_ryaku_nm"][i].RequestValue, formInfo["M1hinsyu_ryaku_nm"]);
				paramCol["M1burando_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1burando_nm"][i].RequestValue, formInfo["M1burando_nm"]);
				paramCol["M1jisya_hbn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1jisya_hbn"][i].RequestValue, formInfo["M1jisya_hbn"]);
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
				paramCol["M1hyoka_tnk"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hyoka_tnk"][i].RequestValue, formInfo["M1hyoka_tnk"]);
				paramCol["M1tanajityobo_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tanajityobo_su"][i].RequestValue, formInfo["M1tanajityobo_su"]);
				paramCol["M1tanajityobo_su_hdn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tanajityobo_su_hdn"][i].RequestValue, formInfo["M1tanajityobo_su_hdn"]);
				paramCol["M1tanajisekiso_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tanajisekiso_su"][i].RequestValue, formInfo["M1tanajisekiso_su"]);
				paramCol["M1tanajisekiso_su_hdn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tanajisekiso_su_hdn"][i].RequestValue, formInfo["M1tanajisekiso_su_hdn"]);
				paramCol["M1jitana_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1jitana_su"][i].RequestValue, formInfo["M1jitana_su"]);
				paramCol["M1jitana_su1_hdn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1jitana_su1_hdn"][i].RequestValue, formInfo["M1jitana_su1_hdn"]);
				paramCol["M1loss_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1loss_su"][i].RequestValue, formInfo["M1loss_su"]);
				paramCol["M1loss_kin"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1loss_kin"][i].RequestValue, formInfo["M1loss_kin"]);
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
			Tj190f02Form formVO = (Tj190f02Form)pageContext.GetFormVO();

			//カード項目の入力値をFormVOにコピーする
			if (paramCol["Head_tenpo_cd"].UnformatValue != null)
			{
				formVO.Head_tenpo_cd = paramCol["Head_tenpo_cd"].UnformatValue;
			}
			if (paramCol["Head_tenpo_nm"].UnformatValue != null)
			{
				formVO.Head_tenpo_nm = paramCol["Head_tenpo_nm"].UnformatValue;
			}
			if (paramCol["Modeno"].UnformatValue != null)
			{
				formVO.Modeno = paramCol["Modeno"].UnformatValue;
			}
			if (paramCol["Stkmodeno"].UnformatValue != null)
			{
				formVO.Stkmodeno = paramCol["Stkmodeno"].UnformatValue;
			}
			if (paramCol["Tenpo_cd_hdn"].UnformatValue != null)
			{
				formVO.Tenpo_cd_hdn = paramCol["Tenpo_cd_hdn"].UnformatValue;
			}
			if (paramCol["Nyuryoku_ymd"].DateFullValue != null)
			{
				formVO.Nyuryoku_ymd = paramCol["Nyuryoku_ymd"].DateFullValue;
			}
			if (paramCol["Rintana_kanri_no"].UnformatValue != null)
			{
				formVO.Rintana_kanri_no = paramCol["Rintana_kanri_no"].UnformatValue;
			}
			if (paramCol["Loss_kanri_no"].UnformatValue != null)
			{
				formVO.Loss_kanri_no = paramCol["Loss_kanri_no"].UnformatValue;
			}
			if (paramCol["Bumon_cd_bo"].UnformatValue != null)
			{
				formVO.Bumon_cd_bo = paramCol["Bumon_cd_bo"].UnformatValue;
			}
			if (paramCol["Bumon_nm"].UnformatValue != null)
			{
				formVO.Bumon_nm = paramCol["Bumon_nm"].UnformatValue;
			}
			if (paramCol["Nyuryokutan_cd"].UnformatValue != null)
			{
				formVO.Nyuryokutan_cd = paramCol["Nyuryokutan_cd"].UnformatValue;
			}
			if (paramCol["Nyuryokutan_nm"].UnformatValue != null)
			{
				formVO.Nyuryokutan_nm = paramCol["Nyuryokutan_nm"].UnformatValue;
			}
			if (paramCol["Losskeisan_ymd"].DateFullValue != null)
			{
				formVO.Losskeisan_ymd = paramCol["Losskeisan_ymd"].DateFullValue;
			}
			if (paramCol["Losskeisan_tm"].DateFullValue != null)
			{
				formVO.Losskeisan_tm = paramCol["Losskeisan_tm"].DateFullValue;
			}
			if (paramCol["Hinsyu_sitei_flg"].UnformatValue != null)
			{
				formVO.Hinsyu_sitei_flg = paramCol["Hinsyu_sitei_flg"].UnformatValue;
			}
			if (paramCol["Hinsyu_cd"].UnformatValue != null)
			{
				formVO.Hinsyu_cd = paramCol["Hinsyu_cd"].UnformatValue;
			}
			if (paramCol["Hinsyu_ryaku_nm"].UnformatValue != null)
			{
				formVO.Hinsyu_ryaku_nm = paramCol["Hinsyu_ryaku_nm"].UnformatValue;
			}
			if (paramCol["Burando_sitei_flg"].UnformatValue != null)
			{
				formVO.Burando_sitei_flg = paramCol["Burando_sitei_flg"].UnformatValue;
			}
			if (paramCol["Burando_cd"].UnformatValue != null)
			{
				formVO.Burando_cd = paramCol["Burando_cd"].UnformatValue;
			}
			if (paramCol["Burando_nm"].UnformatValue != null)
			{
				formVO.Burando_nm = paramCol["Burando_nm"].UnformatValue;
			}
			if (paramCol["Burando_cd1"].UnformatValue != null)
			{
				formVO.Burando_cd1 = paramCol["Burando_cd1"].UnformatValue;
			}
			if (paramCol["Burando_nm1"].UnformatValue != null)
			{
				formVO.Burando_nm1 = paramCol["Burando_nm1"].UnformatValue;
			}
			if (paramCol["Burando_cd2"].UnformatValue != null)
			{
				formVO.Burando_cd2 = paramCol["Burando_cd2"].UnformatValue;
			}
			if (paramCol["Burando_nm2"].UnformatValue != null)
			{
				formVO.Burando_nm2 = paramCol["Burando_nm2"].UnformatValue;
			}
			if (paramCol["Burando_cd3"].UnformatValue != null)
			{
				formVO.Burando_cd3 = paramCol["Burando_cd3"].UnformatValue;
			}
			if (paramCol["Burando_nm3"].UnformatValue != null)
			{
				formVO.Burando_nm3 = paramCol["Burando_nm3"].UnformatValue;
			}
			if (paramCol["Burando_cd4"].UnformatValue != null)
			{
				formVO.Burando_cd4 = paramCol["Burando_cd4"].UnformatValue;
			}
			if (paramCol["Burando_nm4"].UnformatValue != null)
			{
				formVO.Burando_nm4 = paramCol["Burando_nm4"].UnformatValue;
			}
			if (paramCol["Burando_cd5"].UnformatValue != null)
			{
				formVO.Burando_cd5 = paramCol["Burando_cd5"].UnformatValue;
			}
			if (paramCol["Burando_nm5"].UnformatValue != null)
			{
				formVO.Burando_nm5 = paramCol["Burando_nm5"].UnformatValue;
			}
			if (paramCol["Burando_cd6"].UnformatValue != null)
			{
				formVO.Burando_cd6 = paramCol["Burando_cd6"].UnformatValue;
			}
			if (paramCol["Burando_nm6"].UnformatValue != null)
			{
				formVO.Burando_nm6 = paramCol["Burando_nm6"].UnformatValue;
			}
			if (paramCol["Burando_cd7"].UnformatValue != null)
			{
				formVO.Burando_cd7 = paramCol["Burando_cd7"].UnformatValue;
			}
			if (paramCol["Burando_nm7"].UnformatValue != null)
			{
				formVO.Burando_nm7 = paramCol["Burando_nm7"].UnformatValue;
			}
			if (paramCol["Gokeitanajityobo_su"].UnformatValue != null)
			{
				formVO.Gokeitanajityobo_su = paramCol["Gokeitanajityobo_su"].UnformatValue;
			}
			if (paramCol["Gokeitanajisekiso_su"].UnformatValue != null)
			{
				formVO.Gokeitanajisekiso_su = paramCol["Gokeitanajisekiso_su"].UnformatValue;
			}
			if (paramCol["Gokeijitana_su"].UnformatValue != null)
			{
				formVO.Gokeijitana_su = paramCol["Gokeijitana_su"].UnformatValue;
			}
			if (paramCol["Gokeiloss_su"].UnformatValue != null)
			{
				formVO.Gokeiloss_su = paramCol["Gokeiloss_su"].UnformatValue;
			}
			if (paramCol["Gokeiloss_kin"].UnformatValue != null)
			{
				formVO.Gokeiloss_kin = paramCol["Gokeiloss_kin"].UnformatValue;
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
				Tj190f02M1Form tj190f02M1Form = (Tj190f02M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					tj190f02M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue != null)
				{
					tj190f02M1Form.M1hinsyu_ryaku_nm = paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue;
				}
				if (paramCol["M1burando_nm"][i].UnformatValue != null)
				{
					tj190f02M1Form.M1burando_nm = paramCol["M1burando_nm"][i].UnformatValue;
				}
				if (paramCol["M1jisya_hbn"][i].UnformatValue != null)
				{
					tj190f02M1Form.M1jisya_hbn = paramCol["M1jisya_hbn"][i].UnformatValue;
				}
				if (paramCol["M1maker_hbn"][i].UnformatValue != null)
				{
					tj190f02M1Form.M1maker_hbn = paramCol["M1maker_hbn"][i].UnformatValue;
				}
				if (paramCol["M1syonmk"][i].UnformatValue != null)
				{
					tj190f02M1Form.M1syonmk = paramCol["M1syonmk"][i].UnformatValue;
				}
				if (paramCol["M1iro_nm"][i].UnformatValue != null)
				{
					tj190f02M1Form.M1iro_nm = paramCol["M1iro_nm"][i].UnformatValue;
				}
				if (paramCol["M1size_nm"][i].UnformatValue != null)
				{
					tj190f02M1Form.M1size_nm = paramCol["M1size_nm"][i].UnformatValue;
				}
				if (paramCol["M1scan_cd"][i].UnformatValue != null)
				{
					tj190f02M1Form.M1scan_cd = paramCol["M1scan_cd"][i].UnformatValue;
				}
				if (paramCol["M1hyoka_tnk"][i].UnformatValue != null)
				{
					tj190f02M1Form.M1hyoka_tnk = paramCol["M1hyoka_tnk"][i].UnformatValue;
				}
				if (paramCol["M1tanajityobo_su"][i].UnformatValue != null)
				{
					tj190f02M1Form.M1tanajityobo_su = paramCol["M1tanajityobo_su"][i].UnformatValue;
				}
				if (paramCol["M1tanajityobo_su_hdn"][i].UnformatValue != null)
				{
					tj190f02M1Form.M1tanajityobo_su_hdn = paramCol["M1tanajityobo_su_hdn"][i].UnformatValue;
				}
				if (paramCol["M1tanajisekiso_su"][i].UnformatValue != null)
				{
					tj190f02M1Form.M1tanajisekiso_su = paramCol["M1tanajisekiso_su"][i].UnformatValue;
				}
				if (paramCol["M1tanajisekiso_su_hdn"][i].UnformatValue != null)
				{
					tj190f02M1Form.M1tanajisekiso_su_hdn = paramCol["M1tanajisekiso_su_hdn"][i].UnformatValue;
				}
				if (paramCol["M1jitana_su"][i].UnformatValue != null)
				{
					tj190f02M1Form.M1jitana_su = paramCol["M1jitana_su"][i].UnformatValue;
				}
				if (paramCol["M1jitana_su1_hdn"][i].UnformatValue != null)
				{
					tj190f02M1Form.M1jitana_su1_hdn = paramCol["M1jitana_su1_hdn"][i].UnformatValue;
				}
				if (paramCol["M1loss_su"][i].UnformatValue != null)
				{
					tj190f02M1Form.M1loss_su = paramCol["M1loss_su"][i].UnformatValue;
				}
				if (paramCol["M1loss_kin"][i].UnformatValue != null)
				{
					tj190f02M1Form.M1loss_kin = paramCol["M1loss_kin"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					tj190f02M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					tj190f02M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					tj190f02M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Tj190f02Form formVO, StandardCheckManager checker)
		{
			if (formVO.Head_tenpo_cd != null)
			{
				checker.DoCheck("Head_tenpo_cd", formVO.Head_tenpo_cd);
			}
			if (formVO.Head_tenpo_nm != null)
			{
				checker.DoCheck("Head_tenpo_nm", formVO.Head_tenpo_nm);
			}
			if (formVO.Modeno != null)
			{
				checker.DoCheck("Modeno", formVO.Modeno);
			}
			if (formVO.Stkmodeno != null)
			{
				checker.DoCheck("Stkmodeno", formVO.Stkmodeno);
			}
			if (formVO.Tenpo_cd_hdn != null)
			{
				checker.DoCheck("Tenpo_cd_hdn", formVO.Tenpo_cd_hdn);
			}
			if (formVO.Nyuryoku_ymd != null)
			{
				checker.DoCheck("Nyuryoku_ymd", formVO.Nyuryoku_ymd);
			}
			if (formVO.Rintana_kanri_no != null)
			{
				checker.DoCheck("Rintana_kanri_no", formVO.Rintana_kanri_no);
			}
			if (formVO.Loss_kanri_no != null)
			{
				checker.DoCheck("Loss_kanri_no", formVO.Loss_kanri_no);
			}
			if (formVO.Bumon_cd_bo != null)
			{
				checker.DoCheck("Bumon_cd_bo", formVO.Bumon_cd_bo);
			}
			if (formVO.Bumon_nm != null)
			{
				checker.DoCheck("Bumon_nm", formVO.Bumon_nm);
			}
			if (formVO.Nyuryokutan_cd != null)
			{
				checker.DoCheck("Nyuryokutan_cd", formVO.Nyuryokutan_cd);
			}
			if (formVO.Nyuryokutan_nm != null)
			{
				checker.DoCheck("Nyuryokutan_nm", formVO.Nyuryokutan_nm);
			}
			if (formVO.Losskeisan_ymd != null)
			{
				checker.DoCheck("Losskeisan_ymd", formVO.Losskeisan_ymd);
			}
			if (formVO.Losskeisan_tm != null)
			{
				checker.DoCheck("Losskeisan_tm", formVO.Losskeisan_tm);
			}
			if (formVO.Hinsyu_sitei_flg != null)
			{
				checker.DoCheck("Hinsyu_sitei_flg", formVO.Hinsyu_sitei_flg);
			}
			if (formVO.Hinsyu_cd != null)
			{
				checker.DoCheck("Hinsyu_cd", formVO.Hinsyu_cd);
			}
			if (formVO.Hinsyu_ryaku_nm != null)
			{
				checker.DoCheck("Hinsyu_ryaku_nm", formVO.Hinsyu_ryaku_nm);
			}
			if (formVO.Burando_sitei_flg != null)
			{
				checker.DoCheck("Burando_sitei_flg", formVO.Burando_sitei_flg);
			}
			if (formVO.Burando_cd != null)
			{
				checker.DoCheck("Burando_cd", formVO.Burando_cd);
			}
			if (formVO.Burando_nm != null)
			{
				checker.DoCheck("Burando_nm", formVO.Burando_nm);
			}
			if (formVO.Burando_cd1 != null)
			{
				checker.DoCheck("Burando_cd1", formVO.Burando_cd1);
			}
			if (formVO.Burando_nm1 != null)
			{
				checker.DoCheck("Burando_nm1", formVO.Burando_nm1);
			}
			if (formVO.Burando_cd2 != null)
			{
				checker.DoCheck("Burando_cd2", formVO.Burando_cd2);
			}
			if (formVO.Burando_nm2 != null)
			{
				checker.DoCheck("Burando_nm2", formVO.Burando_nm2);
			}
			if (formVO.Burando_cd3 != null)
			{
				checker.DoCheck("Burando_cd3", formVO.Burando_cd3);
			}
			if (formVO.Burando_nm3 != null)
			{
				checker.DoCheck("Burando_nm3", formVO.Burando_nm3);
			}
			if (formVO.Burando_cd4 != null)
			{
				checker.DoCheck("Burando_cd4", formVO.Burando_cd4);
			}
			if (formVO.Burando_nm4 != null)
			{
				checker.DoCheck("Burando_nm4", formVO.Burando_nm4);
			}
			if (formVO.Burando_cd5 != null)
			{
				checker.DoCheck("Burando_cd5", formVO.Burando_cd5);
			}
			if (formVO.Burando_nm5 != null)
			{
				checker.DoCheck("Burando_nm5", formVO.Burando_nm5);
			}
			if (formVO.Burando_cd6 != null)
			{
				checker.DoCheck("Burando_cd6", formVO.Burando_cd6);
			}
			if (formVO.Burando_nm6 != null)
			{
				checker.DoCheck("Burando_nm6", formVO.Burando_nm6);
			}
			if (formVO.Burando_cd7 != null)
			{
				checker.DoCheck("Burando_cd7", formVO.Burando_cd7);
			}
			if (formVO.Burando_nm7 != null)
			{
				checker.DoCheck("Burando_nm7", formVO.Burando_nm7);
			}
			if (formVO.Gokeitanajityobo_su != null)
			{
				checker.DoCheck("Gokeitanajityobo_su", formVO.Gokeitanajityobo_su);
			}
			if (formVO.Gokeitanajisekiso_su != null)
			{
				checker.DoCheck("Gokeitanajisekiso_su", formVO.Gokeitanajisekiso_su);
			}
			if (formVO.Gokeijitana_su != null)
			{
				checker.DoCheck("Gokeijitana_su", formVO.Gokeijitana_su);
			}
			if (formVO.Gokeiloss_su != null)
			{
				checker.DoCheck("Gokeiloss_su", formVO.Gokeiloss_su);
			}
			if (formVO.Gokeiloss_kin != null)
			{
				checker.DoCheck("Gokeiloss_kin", formVO.Gokeiloss_kin);
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
		public static void ValidateM1InputValue(Tj190f02Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Tj190f02M1Form tj190f02M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, tj190f02M1Form, i, m1List);
				if (tj190f02M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", tj190f02M1Form.M1rowno, i, m1List);
				}
				if (tj190f02M1Form.M1hinsyu_ryaku_nm != null)
				{
					checker.DoCheck("M1hinsyu_ryaku_nm", tj190f02M1Form.M1hinsyu_ryaku_nm, i, m1List);
				}
				if (tj190f02M1Form.M1burando_nm != null)
				{
					checker.DoCheck("M1burando_nm", tj190f02M1Form.M1burando_nm, i, m1List);
				}
				if (tj190f02M1Form.M1jisya_hbn != null)
				{
					checker.DoCheck("M1jisya_hbn", tj190f02M1Form.M1jisya_hbn, i, m1List);
				}
				if (tj190f02M1Form.M1maker_hbn != null)
				{
					checker.DoCheck("M1maker_hbn", tj190f02M1Form.M1maker_hbn, i, m1List);
				}
				if (tj190f02M1Form.M1syonmk != null)
				{
					checker.DoCheck("M1syonmk", tj190f02M1Form.M1syonmk, i, m1List);
				}
				if (tj190f02M1Form.M1iro_nm != null)
				{
					checker.DoCheck("M1iro_nm", tj190f02M1Form.M1iro_nm, i, m1List);
				}
				if (tj190f02M1Form.M1size_nm != null)
				{
					checker.DoCheck("M1size_nm", tj190f02M1Form.M1size_nm, i, m1List);
				}
				if (tj190f02M1Form.M1scan_cd != null)
				{
					checker.DoCheck("M1scan_cd", tj190f02M1Form.M1scan_cd, i, m1List);
				}
				if (tj190f02M1Form.M1hyoka_tnk != null)
				{
					checker.DoCheck("M1hyoka_tnk", tj190f02M1Form.M1hyoka_tnk, i, m1List);
				}
				if (tj190f02M1Form.M1tanajityobo_su != null)
				{
					checker.DoCheck("M1tanajityobo_su", tj190f02M1Form.M1tanajityobo_su, i, m1List);
				}
				if (tj190f02M1Form.M1tanajityobo_su_hdn != null)
				{
					checker.DoCheck("M1tanajityobo_su_hdn", tj190f02M1Form.M1tanajityobo_su_hdn, i, m1List);
				}
				if (tj190f02M1Form.M1tanajisekiso_su != null)
				{
					checker.DoCheck("M1tanajisekiso_su", tj190f02M1Form.M1tanajisekiso_su, i, m1List);
				}
				if (tj190f02M1Form.M1tanajisekiso_su_hdn != null)
				{
					checker.DoCheck("M1tanajisekiso_su_hdn", tj190f02M1Form.M1tanajisekiso_su_hdn, i, m1List);
				}
				if (tj190f02M1Form.M1jitana_su != null)
				{
					checker.DoCheck("M1jitana_su", tj190f02M1Form.M1jitana_su, i, m1List);
				}
				if (tj190f02M1Form.M1jitana_su1_hdn != null)
				{
					checker.DoCheck("M1jitana_su1_hdn", tj190f02M1Form.M1jitana_su1_hdn, i, m1List);
				}
				if (tj190f02M1Form.M1loss_su != null)
				{
					checker.DoCheck("M1loss_su", tj190f02M1Form.M1loss_su, i, m1List);
				}
				if (tj190f02M1Form.M1loss_kin != null)
				{
					checker.DoCheck("M1loss_kin", tj190f02M1Form.M1loss_kin, i, m1List);
				}
				if (tj190f02M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", tj190f02M1Form.M1selectorcheckbox, i, m1List);
				}
				if (tj190f02M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", tj190f02M1Form.M1entersyoriflg, i, m1List);
				}
				if (tj190f02M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", tj190f02M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Tj190f02Form formVO, StandardCodeCheckManager checker)
		{
			checker.DoCheck("Btnhinsyu_cd", formVO);
			checker.DoCheck("Btnburando_cd", formVO);
			checker.DoCheck("Btnburando_cd1", formVO);
			checker.DoCheck("Btnburando_cd2", formVO);
			checker.DoCheck("Btnburando_cd3", formVO);
			checker.DoCheck("Btnburando_cd4", formVO);
			checker.DoCheck("Btnburando_cd5", formVO);
			checker.DoCheck("Btnburando_cd6", formVO);
			checker.DoCheck("Btnburando_cd7", formVO);
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Tj190f02Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

