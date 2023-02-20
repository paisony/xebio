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
  /// Tj190f01RequestHelper の概要の説明です。
  /// </summary>
  public static class Tj190f01RequestHelper
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
			Tj190f01Form formVO = (Tj190f01Form)pageContext.GetFormVO();

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
			paramCol["Nyuryoku_ymd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Nyuryoku_ymd_from"]);
			paramCol["Nyuryoku_ymd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Nyuryoku_ymd_to"]);
			paramCol["Tenpo_cd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tenpo_cd_from"]);
			paramCol["Tenpo_nm_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tenpo_nm_from"]);
			paramCol["Tenpo_cd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tenpo_cd_to"]);
			paramCol["Tenpo_nm_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tenpo_nm_to"]);
			paramCol["Nyuryokutan_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Nyuryokutan_cd"]);
			paramCol["Nyuryokutan_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Nyuryokutan_nm"]);
			paramCol["Bumon_cd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_cd_from"]);
			paramCol["Bumon_nm_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_nm_from"]);
			paramCol["Hinsyu_cd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hinsyu_cd_from"]);
			paramCol["Hinsyu_ryaku_nm_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hinsyu_ryaku_nm_from"]);
			paramCol["Bumon_cd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_cd_to"]);
			paramCol["Bumon_nm_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_nm_to"]);
			paramCol["Hinsyu_cd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hinsyu_cd_to"]);
			paramCol["Hinsyu_ryaku_nm_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hinsyu_ryaku_nm_to"]);
			paramCol["Burando_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Burando_cd"]);
			paramCol["Burando_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Burando_nm"]);
			paramCol["Old_jisya_hbn"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Old_jisya_hbn"]);
			paramCol["Scan_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Scan_cd"]);
			paramCol["Loss_kanri_no"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Loss_kanri_no"]);
			paramCol["Meisai_sort"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Meisai_sort"]);
			paramCol["Searchcnt"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Searchcnt"]);
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
				paramCol["M1tenpo_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tenpo_cd"]);
				paramCol["M1tenpo_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tenpo_nm"]);
				paramCol["M1nyuryoku_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1nyuryoku_ymd"]);
				paramCol["M1rintana_kanri_no"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1rintana_kanri_no"]);
				paramCol["M1loss_kanri_no"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1loss_kanri_no"]);
				paramCol["M1hinsyu_ryaku_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hinsyu_ryaku_nm"]);
				paramCol["M1burando_nm1"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1burando_nm1"]);
				paramCol["M1burando_nm2"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1burando_nm2"]);
				paramCol["M1burando_nm3"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1burando_nm3"]);
				paramCol["M1burando_nm4"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1burando_nm4"]);
				paramCol["M1burando_nm5"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1burando_nm5"]);
				paramCol["M1burando_nm6"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1burando_nm6"]);
				paramCol["M1burando_nm7"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1burando_nm7"]);
				paramCol["M1burando_nm8"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1burando_nm8"]);
				paramCol["M1tanajityobo_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tanajityobo_su"]);
				paramCol["M1tanajisekiso_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tanajisekiso_su"]);
				paramCol["M1jitana_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1jitana_su"]);
				paramCol["M1nyuryokutan_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1nyuryokutan_nm"]);
				paramCol["M1loss_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1loss_su"]);
				paramCol["M1loss_kin"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1loss_kin"]);
				paramCol["M1losskeisan_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1losskeisan_ymd"]);
				paramCol["M1losskeisan_tm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1losskeisan_tm"]);
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
			Tj190f01Form formVO = (Tj190f01Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Modeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Modeno"].RequestValue, formInfo["Modeno"]);
			paramCol["Stkmodeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Stkmodeno"].RequestValue, formInfo["Stkmodeno"]);
			paramCol["Nyuryoku_ymd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Nyuryoku_ymd_from"].RequestValue, formInfo["Nyuryoku_ymd_from"]);
			paramCol["Nyuryoku_ymd_from"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Nyuryoku_ymd_from"].RequestValue, formInfo["Nyuryoku_ymd_from"]);
			paramCol["Nyuryoku_ymd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Nyuryoku_ymd_to"].RequestValue, formInfo["Nyuryoku_ymd_to"]);
			paramCol["Nyuryoku_ymd_to"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Nyuryoku_ymd_to"].RequestValue, formInfo["Nyuryoku_ymd_to"]);
			paramCol["Tenpo_cd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tenpo_cd_from"].RequestValue, formInfo["Tenpo_cd_from"]);
			paramCol["Tenpo_nm_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tenpo_nm_from"].RequestValue, formInfo["Tenpo_nm_from"]);
			paramCol["Tenpo_cd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tenpo_cd_to"].RequestValue, formInfo["Tenpo_cd_to"]);
			paramCol["Tenpo_nm_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tenpo_nm_to"].RequestValue, formInfo["Tenpo_nm_to"]);
			paramCol["Nyuryokutan_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Nyuryokutan_cd"].RequestValue, formInfo["Nyuryokutan_cd"]);
			paramCol["Nyuryokutan_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Nyuryokutan_nm"].RequestValue, formInfo["Nyuryokutan_nm"]);
			paramCol["Bumon_cd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_cd_from"].RequestValue, formInfo["Bumon_cd_from"]);
			paramCol["Bumon_nm_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_nm_from"].RequestValue, formInfo["Bumon_nm_from"]);
			paramCol["Hinsyu_cd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hinsyu_cd_from"].RequestValue, formInfo["Hinsyu_cd_from"]);
			paramCol["Hinsyu_ryaku_nm_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hinsyu_ryaku_nm_from"].RequestValue, formInfo["Hinsyu_ryaku_nm_from"]);
			paramCol["Bumon_cd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_cd_to"].RequestValue, formInfo["Bumon_cd_to"]);
			paramCol["Bumon_nm_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_nm_to"].RequestValue, formInfo["Bumon_nm_to"]);
			paramCol["Hinsyu_cd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hinsyu_cd_to"].RequestValue, formInfo["Hinsyu_cd_to"]);
			paramCol["Hinsyu_ryaku_nm_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hinsyu_ryaku_nm_to"].RequestValue, formInfo["Hinsyu_ryaku_nm_to"]);
			paramCol["Burando_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Burando_cd"].RequestValue, formInfo["Burando_cd"]);
			paramCol["Burando_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Burando_nm"].RequestValue, formInfo["Burando_nm"]);
			paramCol["Old_jisya_hbn"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Old_jisya_hbn"].RequestValue, formInfo["Old_jisya_hbn"]);
			paramCol["Scan_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Scan_cd"].RequestValue, formInfo["Scan_cd"]);
			paramCol["Loss_kanri_no"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Loss_kanri_no"].RequestValue, formInfo["Loss_kanri_no"]);
			paramCol["Meisai_sort"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Meisai_sort"].RequestValue, formInfo["Meisai_sort"]);
			paramCol["Searchcnt"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Searchcnt"].RequestValue, formInfo["Searchcnt"]);
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
				paramCol["M1tenpo_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tenpo_cd"][i].RequestValue, formInfo["M1tenpo_cd"]);
				paramCol["M1tenpo_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tenpo_nm"][i].RequestValue, formInfo["M1tenpo_nm"]);
				paramCol["M1nyuryoku_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1nyuryoku_ymd"][i].RequestValue, formInfo["M1nyuryoku_ymd"]);
				paramCol["M1nyuryoku_ymd"][i].DateFullValue = RequestParameterUtil.GetDateFullValue(
					paramCol["M1nyuryoku_ymd"][i].RequestValue, formInfo["M1nyuryoku_ymd"]);
				paramCol["M1rintana_kanri_no"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1rintana_kanri_no"][i].RequestValue, formInfo["M1rintana_kanri_no"]);
				paramCol["M1loss_kanri_no"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1loss_kanri_no"][i].RequestValue, formInfo["M1loss_kanri_no"]);
				paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hinsyu_ryaku_nm"][i].RequestValue, formInfo["M1hinsyu_ryaku_nm"]);
				paramCol["M1burando_nm1"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1burando_nm1"][i].RequestValue, formInfo["M1burando_nm1"]);
				paramCol["M1burando_nm2"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1burando_nm2"][i].RequestValue, formInfo["M1burando_nm2"]);
				paramCol["M1burando_nm3"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1burando_nm3"][i].RequestValue, formInfo["M1burando_nm3"]);
				paramCol["M1burando_nm4"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1burando_nm4"][i].RequestValue, formInfo["M1burando_nm4"]);
				paramCol["M1burando_nm5"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1burando_nm5"][i].RequestValue, formInfo["M1burando_nm5"]);
				paramCol["M1burando_nm6"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1burando_nm6"][i].RequestValue, formInfo["M1burando_nm6"]);
				paramCol["M1burando_nm7"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1burando_nm7"][i].RequestValue, formInfo["M1burando_nm7"]);
				paramCol["M1burando_nm8"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1burando_nm8"][i].RequestValue, formInfo["M1burando_nm8"]);
				paramCol["M1tanajityobo_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tanajityobo_su"][i].RequestValue, formInfo["M1tanajityobo_su"]);
				paramCol["M1tanajisekiso_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tanajisekiso_su"][i].RequestValue, formInfo["M1tanajisekiso_su"]);
				paramCol["M1jitana_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1jitana_su"][i].RequestValue, formInfo["M1jitana_su"]);
				paramCol["M1nyuryokutan_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1nyuryokutan_nm"][i].RequestValue, formInfo["M1nyuryokutan_nm"]);
				paramCol["M1loss_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1loss_su"][i].RequestValue, formInfo["M1loss_su"]);
				paramCol["M1loss_kin"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1loss_kin"][i].RequestValue, formInfo["M1loss_kin"]);
				paramCol["M1losskeisan_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1losskeisan_ymd"][i].RequestValue, formInfo["M1losskeisan_ymd"]);
				paramCol["M1losskeisan_ymd"][i].DateFullValue = RequestParameterUtil.GetDateFullValue(
					paramCol["M1losskeisan_ymd"][i].RequestValue, formInfo["M1losskeisan_ymd"]);
				paramCol["M1losskeisan_tm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1losskeisan_tm"][i].RequestValue, formInfo["M1losskeisan_tm"]);
				paramCol["M1losskeisan_tm"][i].DateFullValue = RequestParameterUtil.GetDateFullValue(
					paramCol["M1losskeisan_tm"][i].RequestValue, formInfo["M1losskeisan_tm"]);
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
			Tj190f01Form formVO = (Tj190f01Form)pageContext.GetFormVO();

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
			if (paramCol["Nyuryoku_ymd_from"].DateFullValue != null)
			{
				formVO.Nyuryoku_ymd_from = paramCol["Nyuryoku_ymd_from"].DateFullValue;
			}
			if (paramCol["Nyuryoku_ymd_to"].DateFullValue != null)
			{
				formVO.Nyuryoku_ymd_to = paramCol["Nyuryoku_ymd_to"].DateFullValue;
			}
			if (paramCol["Tenpo_cd_from"].UnformatValue != null)
			{
				formVO.Tenpo_cd_from = paramCol["Tenpo_cd_from"].UnformatValue;
			}
			if (paramCol["Tenpo_nm_from"].UnformatValue != null)
			{
				formVO.Tenpo_nm_from = paramCol["Tenpo_nm_from"].UnformatValue;
			}
			if (paramCol["Tenpo_cd_to"].UnformatValue != null)
			{
				formVO.Tenpo_cd_to = paramCol["Tenpo_cd_to"].UnformatValue;
			}
			if (paramCol["Tenpo_nm_to"].UnformatValue != null)
			{
				formVO.Tenpo_nm_to = paramCol["Tenpo_nm_to"].UnformatValue;
			}
			if (paramCol["Nyuryokutan_cd"].UnformatValue != null)
			{
				formVO.Nyuryokutan_cd = paramCol["Nyuryokutan_cd"].UnformatValue;
			}
			if (paramCol["Nyuryokutan_nm"].UnformatValue != null)
			{
				formVO.Nyuryokutan_nm = paramCol["Nyuryokutan_nm"].UnformatValue;
			}
			if (paramCol["Bumon_cd_from"].UnformatValue != null)
			{
				formVO.Bumon_cd_from = paramCol["Bumon_cd_from"].UnformatValue;
			}
			if (paramCol["Bumon_nm_from"].UnformatValue != null)
			{
				formVO.Bumon_nm_from = paramCol["Bumon_nm_from"].UnformatValue;
			}
			if (paramCol["Hinsyu_cd_from"].UnformatValue != null)
			{
				formVO.Hinsyu_cd_from = paramCol["Hinsyu_cd_from"].UnformatValue;
			}
			if (paramCol["Hinsyu_ryaku_nm_from"].UnformatValue != null)
			{
				formVO.Hinsyu_ryaku_nm_from = paramCol["Hinsyu_ryaku_nm_from"].UnformatValue;
			}
			if (paramCol["Bumon_cd_to"].UnformatValue != null)
			{
				formVO.Bumon_cd_to = paramCol["Bumon_cd_to"].UnformatValue;
			}
			if (paramCol["Bumon_nm_to"].UnformatValue != null)
			{
				formVO.Bumon_nm_to = paramCol["Bumon_nm_to"].UnformatValue;
			}
			if (paramCol["Hinsyu_cd_to"].UnformatValue != null)
			{
				formVO.Hinsyu_cd_to = paramCol["Hinsyu_cd_to"].UnformatValue;
			}
			if (paramCol["Hinsyu_ryaku_nm_to"].UnformatValue != null)
			{
				formVO.Hinsyu_ryaku_nm_to = paramCol["Hinsyu_ryaku_nm_to"].UnformatValue;
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
			if (paramCol["Scan_cd"].UnformatValue != null)
			{
				formVO.Scan_cd = paramCol["Scan_cd"].UnformatValue;
			}
			if (paramCol["Loss_kanri_no"].UnformatValue != null)
			{
				formVO.Loss_kanri_no = paramCol["Loss_kanri_no"].UnformatValue;
			}
			if (paramCol["Meisai_sort"].UnformatValue != null)
			{
				formVO.Meisai_sort = paramCol["Meisai_sort"].UnformatValue;
			}
			if (paramCol["Searchcnt"].UnformatValue != null)
			{
				formVO.Searchcnt = paramCol["Searchcnt"].UnformatValue;
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
				Tj190f01M1Form tj190f01M1Form = (Tj190f01M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					tj190f01M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1tenpo_cd"][i].UnformatValue != null)
				{
					tj190f01M1Form.M1tenpo_cd = paramCol["M1tenpo_cd"][i].UnformatValue;
				}
				if (paramCol["M1tenpo_nm"][i].UnformatValue != null)
				{
					tj190f01M1Form.M1tenpo_nm = paramCol["M1tenpo_nm"][i].UnformatValue;
				}
				if (paramCol["M1nyuryoku_ymd"][i].DateFullValue != null)
				{
					tj190f01M1Form.M1nyuryoku_ymd = paramCol["M1nyuryoku_ymd"][i].DateFullValue;
				}
				if (paramCol["M1rintana_kanri_no"][i].UnformatValue != null)
				{
					tj190f01M1Form.M1rintana_kanri_no = paramCol["M1rintana_kanri_no"][i].UnformatValue;
				}
				if (paramCol["M1loss_kanri_no"][i].UnformatValue != null)
				{
					tj190f01M1Form.M1loss_kanri_no = paramCol["M1loss_kanri_no"][i].UnformatValue;
				}
				if (paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue != null)
				{
					tj190f01M1Form.M1hinsyu_ryaku_nm = paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue;
				}
				if (paramCol["M1burando_nm1"][i].UnformatValue != null)
				{
					tj190f01M1Form.M1burando_nm1 = paramCol["M1burando_nm1"][i].UnformatValue;
				}
				if (paramCol["M1burando_nm2"][i].UnformatValue != null)
				{
					tj190f01M1Form.M1burando_nm2 = paramCol["M1burando_nm2"][i].UnformatValue;
				}
				if (paramCol["M1burando_nm3"][i].UnformatValue != null)
				{
					tj190f01M1Form.M1burando_nm3 = paramCol["M1burando_nm3"][i].UnformatValue;
				}
				if (paramCol["M1burando_nm4"][i].UnformatValue != null)
				{
					tj190f01M1Form.M1burando_nm4 = paramCol["M1burando_nm4"][i].UnformatValue;
				}
				if (paramCol["M1burando_nm5"][i].UnformatValue != null)
				{
					tj190f01M1Form.M1burando_nm5 = paramCol["M1burando_nm5"][i].UnformatValue;
				}
				if (paramCol["M1burando_nm6"][i].UnformatValue != null)
				{
					tj190f01M1Form.M1burando_nm6 = paramCol["M1burando_nm6"][i].UnformatValue;
				}
				if (paramCol["M1burando_nm7"][i].UnformatValue != null)
				{
					tj190f01M1Form.M1burando_nm7 = paramCol["M1burando_nm7"][i].UnformatValue;
				}
				if (paramCol["M1burando_nm8"][i].UnformatValue != null)
				{
					tj190f01M1Form.M1burando_nm8 = paramCol["M1burando_nm8"][i].UnformatValue;
				}
				if (paramCol["M1tanajityobo_su"][i].UnformatValue != null)
				{
					tj190f01M1Form.M1tanajityobo_su = paramCol["M1tanajityobo_su"][i].UnformatValue;
				}
				if (paramCol["M1tanajisekiso_su"][i].UnformatValue != null)
				{
					tj190f01M1Form.M1tanajisekiso_su = paramCol["M1tanajisekiso_su"][i].UnformatValue;
				}
				if (paramCol["M1jitana_su"][i].UnformatValue != null)
				{
					tj190f01M1Form.M1jitana_su = paramCol["M1jitana_su"][i].UnformatValue;
				}
				if (paramCol["M1nyuryokutan_nm"][i].UnformatValue != null)
				{
					tj190f01M1Form.M1nyuryokutan_nm = paramCol["M1nyuryokutan_nm"][i].UnformatValue;
				}
				if (paramCol["M1loss_su"][i].UnformatValue != null)
				{
					tj190f01M1Form.M1loss_su = paramCol["M1loss_su"][i].UnformatValue;
				}
				if (paramCol["M1loss_kin"][i].UnformatValue != null)
				{
					tj190f01M1Form.M1loss_kin = paramCol["M1loss_kin"][i].UnformatValue;
				}
				if (paramCol["M1losskeisan_ymd"][i].DateFullValue != null)
				{
					tj190f01M1Form.M1losskeisan_ymd = paramCol["M1losskeisan_ymd"][i].DateFullValue;
				}
				if (paramCol["M1losskeisan_tm"][i].DateFullValue != null)
				{
					tj190f01M1Form.M1losskeisan_tm = paramCol["M1losskeisan_tm"][i].DateFullValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					tj190f01M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					tj190f01M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					tj190f01M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Tj190f01Form formVO, StandardCheckManager checker)
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
			if (formVO.Nyuryoku_ymd_from != null)
			{
				checker.DoCheck("Nyuryoku_ymd_from", formVO.Nyuryoku_ymd_from);
			}
			if (formVO.Nyuryoku_ymd_to != null)
			{
				checker.DoCheck("Nyuryoku_ymd_to", formVO.Nyuryoku_ymd_to);
			}
			if (formVO.Tenpo_cd_from != null)
			{
				checker.DoCheck("Tenpo_cd_from", formVO.Tenpo_cd_from);
			}
			if (formVO.Tenpo_nm_from != null)
			{
				checker.DoCheck("Tenpo_nm_from", formVO.Tenpo_nm_from);
			}
			if (formVO.Tenpo_cd_to != null)
			{
				checker.DoCheck("Tenpo_cd_to", formVO.Tenpo_cd_to);
			}
			if (formVO.Tenpo_nm_to != null)
			{
				checker.DoCheck("Tenpo_nm_to", formVO.Tenpo_nm_to);
			}
			if (formVO.Nyuryokutan_cd != null)
			{
				checker.DoCheck("Nyuryokutan_cd", formVO.Nyuryokutan_cd);
			}
			if (formVO.Nyuryokutan_nm != null)
			{
				checker.DoCheck("Nyuryokutan_nm", formVO.Nyuryokutan_nm);
			}
			if (formVO.Bumon_cd_from != null)
			{
				checker.DoCheck("Bumon_cd_from", formVO.Bumon_cd_from);
			}
			if (formVO.Bumon_nm_from != null)
			{
				checker.DoCheck("Bumon_nm_from", formVO.Bumon_nm_from);
			}
			if (formVO.Hinsyu_cd_from != null)
			{
				checker.DoCheck("Hinsyu_cd_from", formVO.Hinsyu_cd_from);
			}
			if (formVO.Hinsyu_ryaku_nm_from != null)
			{
				checker.DoCheck("Hinsyu_ryaku_nm_from", formVO.Hinsyu_ryaku_nm_from);
			}
			if (formVO.Bumon_cd_to != null)
			{
				checker.DoCheck("Bumon_cd_to", formVO.Bumon_cd_to);
			}
			if (formVO.Bumon_nm_to != null)
			{
				checker.DoCheck("Bumon_nm_to", formVO.Bumon_nm_to);
			}
			if (formVO.Hinsyu_cd_to != null)
			{
				checker.DoCheck("Hinsyu_cd_to", formVO.Hinsyu_cd_to);
			}
			if (formVO.Hinsyu_ryaku_nm_to != null)
			{
				checker.DoCheck("Hinsyu_ryaku_nm_to", formVO.Hinsyu_ryaku_nm_to);
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
			if (formVO.Scan_cd != null)
			{
				checker.DoCheck("Scan_cd", formVO.Scan_cd);
			}
			if (formVO.Loss_kanri_no != null)
			{
				checker.DoCheck("Loss_kanri_no", formVO.Loss_kanri_no);
			}
			if (formVO.Meisai_sort != null)
			{
				checker.DoCheck("Meisai_sort", formVO.Meisai_sort);
			}
			if (formVO.Searchcnt != null)
			{
				checker.DoCheck("Searchcnt", formVO.Searchcnt);
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
		public static void ValidateM1InputValue(Tj190f01Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Tj190f01M1Form tj190f01M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, tj190f01M1Form, i, m1List);
				if (tj190f01M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", tj190f01M1Form.M1rowno, i, m1List);
				}
				if (tj190f01M1Form.M1tenpo_cd != null)
				{
					checker.DoCheck("M1tenpo_cd", tj190f01M1Form.M1tenpo_cd, i, m1List);
				}
				if (tj190f01M1Form.M1tenpo_nm != null)
				{
					checker.DoCheck("M1tenpo_nm", tj190f01M1Form.M1tenpo_nm, i, m1List);
				}
				if (tj190f01M1Form.M1nyuryoku_ymd != null)
				{
					checker.DoCheck("M1nyuryoku_ymd", tj190f01M1Form.M1nyuryoku_ymd, i, m1List);
				}
				if (tj190f01M1Form.M1rintana_kanri_no != null)
				{
					checker.DoCheck("M1rintana_kanri_no", tj190f01M1Form.M1rintana_kanri_no, i, m1List);
				}
				if (tj190f01M1Form.M1loss_kanri_no != null)
				{
					checker.DoCheck("M1loss_kanri_no", tj190f01M1Form.M1loss_kanri_no, i, m1List);
				}
				if (tj190f01M1Form.M1hinsyu_ryaku_nm != null)
				{
					checker.DoCheck("M1hinsyu_ryaku_nm", tj190f01M1Form.M1hinsyu_ryaku_nm, i, m1List);
				}
				if (tj190f01M1Form.M1burando_nm1 != null)
				{
					checker.DoCheck("M1burando_nm1", tj190f01M1Form.M1burando_nm1, i, m1List);
				}
				if (tj190f01M1Form.M1burando_nm2 != null)
				{
					checker.DoCheck("M1burando_nm2", tj190f01M1Form.M1burando_nm2, i, m1List);
				}
				if (tj190f01M1Form.M1burando_nm3 != null)
				{
					checker.DoCheck("M1burando_nm3", tj190f01M1Form.M1burando_nm3, i, m1List);
				}
				if (tj190f01M1Form.M1burando_nm4 != null)
				{
					checker.DoCheck("M1burando_nm4", tj190f01M1Form.M1burando_nm4, i, m1List);
				}
				if (tj190f01M1Form.M1burando_nm5 != null)
				{
					checker.DoCheck("M1burando_nm5", tj190f01M1Form.M1burando_nm5, i, m1List);
				}
				if (tj190f01M1Form.M1burando_nm6 != null)
				{
					checker.DoCheck("M1burando_nm6", tj190f01M1Form.M1burando_nm6, i, m1List);
				}
				if (tj190f01M1Form.M1burando_nm7 != null)
				{
					checker.DoCheck("M1burando_nm7", tj190f01M1Form.M1burando_nm7, i, m1List);
				}
				if (tj190f01M1Form.M1burando_nm8 != null)
				{
					checker.DoCheck("M1burando_nm8", tj190f01M1Form.M1burando_nm8, i, m1List);
				}
				if (tj190f01M1Form.M1tanajityobo_su != null)
				{
					checker.DoCheck("M1tanajityobo_su", tj190f01M1Form.M1tanajityobo_su, i, m1List);
				}
				if (tj190f01M1Form.M1tanajisekiso_su != null)
				{
					checker.DoCheck("M1tanajisekiso_su", tj190f01M1Form.M1tanajisekiso_su, i, m1List);
				}
				if (tj190f01M1Form.M1jitana_su != null)
				{
					checker.DoCheck("M1jitana_su", tj190f01M1Form.M1jitana_su, i, m1List);
				}
				if (tj190f01M1Form.M1nyuryokutan_nm != null)
				{
					checker.DoCheck("M1nyuryokutan_nm", tj190f01M1Form.M1nyuryokutan_nm, i, m1List);
				}
				if (tj190f01M1Form.M1loss_su != null)
				{
					checker.DoCheck("M1loss_su", tj190f01M1Form.M1loss_su, i, m1List);
				}
				if (tj190f01M1Form.M1loss_kin != null)
				{
					checker.DoCheck("M1loss_kin", tj190f01M1Form.M1loss_kin, i, m1List);
				}
				if (tj190f01M1Form.M1losskeisan_ymd != null)
				{
					checker.DoCheck("M1losskeisan_ymd", tj190f01M1Form.M1losskeisan_ymd, i, m1List);
				}
				if (tj190f01M1Form.M1losskeisan_tm != null)
				{
					checker.DoCheck("M1losskeisan_tm", tj190f01M1Form.M1losskeisan_tm, i, m1List);
				}
				if (tj190f01M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", tj190f01M1Form.M1selectorcheckbox, i, m1List);
				}
				if (tj190f01M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", tj190f01M1Form.M1entersyoriflg, i, m1List);
				}
				if (tj190f01M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", tj190f01M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Tj190f01Form formVO, StandardCodeCheckManager checker)
		{
			checker.DoCheck("Btnheadtenpocd", formVO);
			checker.DoCheck("Btntenpocd_from", formVO);
			checker.DoCheck("Btntenpocd_to", formVO);
			checker.DoCheck("Btntanto_cd", formVO);
			checker.DoCheck("Btnbumon_cd_from", formVO);
			checker.DoCheck("Btnhinsyu_cd_from", formVO);
			checker.DoCheck("Btnbumon_cd_to", formVO);
			checker.DoCheck("Btnhinsyu_cd_to", formVO);
			checker.DoCheck("Btnburando_cd", formVO);
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Tj190f01Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

