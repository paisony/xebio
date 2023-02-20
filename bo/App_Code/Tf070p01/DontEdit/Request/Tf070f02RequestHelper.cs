using com.xebio.bo.Tf070p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Tf070p01.Request
{
  /// <summary>
  /// Tf070f02RequestHelper の概要の説明です。
  /// </summary>
  public static class Tf070f02RequestHelper
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
			Tf070f02Form formVO = (Tf070f02Form)pageContext.GetFormVO();

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
			paramCol["Tonanhinkanri_no"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tonanhinkanri_no"]);
			paramCol["Jikohassei_ymd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Jikohassei_ymd"]);
			paramCol["Hokoku_ymd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hokoku_ymd"]);
			paramCol["Hokokutan_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hokokutan_cd"]);
			paramCol["Hokokutan_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hokokutan_nm"]);
			paramCol["Tentyotan_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tentyotan_cd"]);
			paramCol["Tentyotan_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tentyotan_nm"]);
			paramCol["Keisatsutodoke_ymd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Keisatsutodoke_ymd"]);
			paramCol["Todokedesakikeisatsu_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Todokedesakikeisatsu_nm"]);
			paramCol["Jyuri_no"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Jyuri_no"]);
			paramCol["Gokeisinsei_su"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokeisinsei_su"]);
			paramCol["Gokeijyuri_su"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokeijyuri_su"]);
			paramCol["Gokeibaika_kin"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokeibaika_kin"]);
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
				paramCol["M1hassei_tm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hassei_tm"]);
				paramCol["M1hasseibasyo"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hasseibasyo"]);
				paramCol["M1bumon_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1bumon_cd"]);
				paramCol["M1bumonkana_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1bumonkana_nm"]);
				paramCol["M1hinsyu_ryaku_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hinsyu_ryaku_nm"]);
				paramCol["M1hakkentan_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hakkentan_cd"]);
				paramCol["M1hakkentan_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hakkentan_nm"]);
				paramCol["M1burando_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1burando_nm"]);
				paramCol["M1jisya_hbn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1jisya_hbn"]);
				paramCol["M1hakkenjyokyo_kb"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hakkenjyokyo_kb"]);
				paramCol["M1hakkenjyokyo_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hakkenjyokyo_nm"]);
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
				paramCol["M1sinsei_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1sinsei_su"]);
				paramCol["M1jyuri_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1jyuri_su"]);
				paramCol["M1baika_hon"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1baika_hon"]);
				paramCol["M1baika_kin"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1baika_kin"]);
				paramCol["M1sinsei_su_hdn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1sinsei_su_hdn"]);
				paramCol["M1jyuri_su_hdn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1jyuri_su_hdn"]);
				paramCol["M1baika_kin_hdn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1baika_kin_hdn"]);
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
			Tf070f02Form formVO = (Tf070f02Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Stkmodeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Stkmodeno"].RequestValue, formInfo["Stkmodeno"]);
			paramCol["Tonanhinkanri_no"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tonanhinkanri_no"].RequestValue, formInfo["Tonanhinkanri_no"]);
			paramCol["Jikohassei_ymd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Jikohassei_ymd"].RequestValue, formInfo["Jikohassei_ymd"]);
			paramCol["Jikohassei_ymd"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Jikohassei_ymd"].RequestValue, formInfo["Jikohassei_ymd"]);
			paramCol["Hokoku_ymd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hokoku_ymd"].RequestValue, formInfo["Hokoku_ymd"]);
			paramCol["Hokoku_ymd"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Hokoku_ymd"].RequestValue, formInfo["Hokoku_ymd"]);
			paramCol["Hokokutan_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hokokutan_cd"].RequestValue, formInfo["Hokokutan_cd"]);
			paramCol["Hokokutan_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hokokutan_nm"].RequestValue, formInfo["Hokokutan_nm"]);
			paramCol["Tentyotan_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tentyotan_cd"].RequestValue, formInfo["Tentyotan_cd"]);
			paramCol["Tentyotan_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tentyotan_nm"].RequestValue, formInfo["Tentyotan_nm"]);
			paramCol["Keisatsutodoke_ymd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Keisatsutodoke_ymd"].RequestValue, formInfo["Keisatsutodoke_ymd"]);
			paramCol["Keisatsutodoke_ymd"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Keisatsutodoke_ymd"].RequestValue, formInfo["Keisatsutodoke_ymd"]);
			paramCol["Todokedesakikeisatsu_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Todokedesakikeisatsu_nm"].RequestValue, formInfo["Todokedesakikeisatsu_nm"]);
			paramCol["Jyuri_no"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Jyuri_no"].RequestValue, formInfo["Jyuri_no"]);
			paramCol["Gokeisinsei_su"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokeisinsei_su"].RequestValue, formInfo["Gokeisinsei_su"]);
			paramCol["Gokeijyuri_su"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokeijyuri_su"].RequestValue, formInfo["Gokeijyuri_su"]);
			paramCol["Gokeibaika_kin"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokeibaika_kin"].RequestValue, formInfo["Gokeibaika_kin"]);
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
				paramCol["M1hassei_tm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hassei_tm"][i].RequestValue, formInfo["M1hassei_tm"]);
				paramCol["M1hasseibasyo"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hasseibasyo"][i].RequestValue, formInfo["M1hasseibasyo"]);
				paramCol["M1bumon_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1bumon_cd"][i].RequestValue, formInfo["M1bumon_cd"]);
				paramCol["M1bumonkana_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1bumonkana_nm"][i].RequestValue, formInfo["M1bumonkana_nm"]);
				paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hinsyu_ryaku_nm"][i].RequestValue, formInfo["M1hinsyu_ryaku_nm"]);
				paramCol["M1hakkentan_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hakkentan_cd"][i].RequestValue, formInfo["M1hakkentan_cd"]);
				paramCol["M1hakkentan_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hakkentan_nm"][i].RequestValue, formInfo["M1hakkentan_nm"]);
				paramCol["M1burando_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1burando_nm"][i].RequestValue, formInfo["M1burando_nm"]);
				paramCol["M1jisya_hbn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1jisya_hbn"][i].RequestValue, formInfo["M1jisya_hbn"]);
				paramCol["M1hakkenjyokyo_kb"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hakkenjyokyo_kb"][i].RequestValue, formInfo["M1hakkenjyokyo_kb"]);
				paramCol["M1hakkenjyokyo_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hakkenjyokyo_nm"][i].RequestValue, formInfo["M1hakkenjyokyo_nm"]);
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
				paramCol["M1sinsei_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1sinsei_su"][i].RequestValue, formInfo["M1sinsei_su"]);
				paramCol["M1jyuri_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1jyuri_su"][i].RequestValue, formInfo["M1jyuri_su"]);
				paramCol["M1baika_hon"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1baika_hon"][i].RequestValue, formInfo["M1baika_hon"]);
				paramCol["M1baika_kin"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1baika_kin"][i].RequestValue, formInfo["M1baika_kin"]);
				paramCol["M1sinsei_su_hdn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1sinsei_su_hdn"][i].RequestValue, formInfo["M1sinsei_su_hdn"]);
				paramCol["M1jyuri_su_hdn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1jyuri_su_hdn"][i].RequestValue, formInfo["M1jyuri_su_hdn"]);
				paramCol["M1baika_kin_hdn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1baika_kin_hdn"][i].RequestValue, formInfo["M1baika_kin_hdn"]);
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
			Tf070f02Form formVO = (Tf070f02Form)pageContext.GetFormVO();

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
			if (paramCol["Tonanhinkanri_no"].UnformatValue != null)
			{
				formVO.Tonanhinkanri_no = paramCol["Tonanhinkanri_no"].UnformatValue;
			}
			if (paramCol["Jikohassei_ymd"].DateFullValue != null)
			{
				formVO.Jikohassei_ymd = paramCol["Jikohassei_ymd"].DateFullValue;
			}
			if (paramCol["Hokoku_ymd"].DateFullValue != null)
			{
				formVO.Hokoku_ymd = paramCol["Hokoku_ymd"].DateFullValue;
			}
			if (paramCol["Hokokutan_cd"].UnformatValue != null)
			{
				formVO.Hokokutan_cd = paramCol["Hokokutan_cd"].UnformatValue;
			}
			if (paramCol["Hokokutan_nm"].UnformatValue != null)
			{
				formVO.Hokokutan_nm = paramCol["Hokokutan_nm"].UnformatValue;
			}
			if (paramCol["Tentyotan_cd"].UnformatValue != null)
			{
				formVO.Tentyotan_cd = paramCol["Tentyotan_cd"].UnformatValue;
			}
			if (paramCol["Tentyotan_nm"].UnformatValue != null)
			{
				formVO.Tentyotan_nm = paramCol["Tentyotan_nm"].UnformatValue;
			}
			if (paramCol["Keisatsutodoke_ymd"].DateFullValue != null)
			{
				formVO.Keisatsutodoke_ymd = paramCol["Keisatsutodoke_ymd"].DateFullValue;
			}
			if (paramCol["Todokedesakikeisatsu_nm"].UnformatValue != null)
			{
				formVO.Todokedesakikeisatsu_nm = paramCol["Todokedesakikeisatsu_nm"].UnformatValue;
			}
			if (paramCol["Jyuri_no"].UnformatValue != null)
			{
				formVO.Jyuri_no = paramCol["Jyuri_no"].UnformatValue;
			}
			if (paramCol["Gokeisinsei_su"].UnformatValue != null)
			{
				formVO.Gokeisinsei_su = paramCol["Gokeisinsei_su"].UnformatValue;
			}
			if (paramCol["Gokeijyuri_su"].UnformatValue != null)
			{
				formVO.Gokeijyuri_su = paramCol["Gokeijyuri_su"].UnformatValue;
			}
			if (paramCol["Gokeibaika_kin"].UnformatValue != null)
			{
				formVO.Gokeibaika_kin = paramCol["Gokeibaika_kin"].UnformatValue;
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
				Tf070f02M1Form tf070f02M1Form = (Tf070f02M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					tf070f02M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1hassei_tm"][i].UnformatValue != null)
				{
					tf070f02M1Form.M1hassei_tm = paramCol["M1hassei_tm"][i].UnformatValue;
				}
				if (paramCol["M1hasseibasyo"][i].UnformatValue != null)
				{
					tf070f02M1Form.M1hasseibasyo = paramCol["M1hasseibasyo"][i].UnformatValue;
				}
				if (paramCol["M1bumon_cd"][i].UnformatValue != null)
				{
					tf070f02M1Form.M1bumon_cd = paramCol["M1bumon_cd"][i].UnformatValue;
				}
				if (paramCol["M1bumonkana_nm"][i].UnformatValue != null)
				{
					tf070f02M1Form.M1bumonkana_nm = paramCol["M1bumonkana_nm"][i].UnformatValue;
				}
				if (paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue != null)
				{
					tf070f02M1Form.M1hinsyu_ryaku_nm = paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue;
				}
				if (paramCol["M1hakkentan_cd"][i].UnformatValue != null)
				{
					tf070f02M1Form.M1hakkentan_cd = paramCol["M1hakkentan_cd"][i].UnformatValue;
				}
				if (paramCol["M1hakkentan_nm"][i].UnformatValue != null)
				{
					tf070f02M1Form.M1hakkentan_nm = paramCol["M1hakkentan_nm"][i].UnformatValue;
				}
				if (paramCol["M1burando_nm"][i].UnformatValue != null)
				{
					tf070f02M1Form.M1burando_nm = paramCol["M1burando_nm"][i].UnformatValue;
				}
				if (paramCol["M1jisya_hbn"][i].UnformatValue != null)
				{
					tf070f02M1Form.M1jisya_hbn = paramCol["M1jisya_hbn"][i].UnformatValue;
				}
				if (paramCol["M1hakkenjyokyo_kb"][i].UnformatValue != null)
				{
					tf070f02M1Form.M1hakkenjyokyo_kb = paramCol["M1hakkenjyokyo_kb"][i].UnformatValue;
				}
				if (paramCol["M1hakkenjyokyo_nm"][i].UnformatValue != null)
				{
					tf070f02M1Form.M1hakkenjyokyo_nm = paramCol["M1hakkenjyokyo_nm"][i].UnformatValue;
				}
				if (paramCol["M1maker_hbn"][i].UnformatValue != null)
				{
					tf070f02M1Form.M1maker_hbn = paramCol["M1maker_hbn"][i].UnformatValue;
				}
				if (paramCol["M1syonmk"][i].UnformatValue != null)
				{
					tf070f02M1Form.M1syonmk = paramCol["M1syonmk"][i].UnformatValue;
				}
				if (paramCol["M1iro_nm"][i].UnformatValue != null)
				{
					tf070f02M1Form.M1iro_nm = paramCol["M1iro_nm"][i].UnformatValue;
				}
				if (paramCol["M1size_nm"][i].UnformatValue != null)
				{
					tf070f02M1Form.M1size_nm = paramCol["M1size_nm"][i].UnformatValue;
				}
				if (paramCol["M1scan_cd"][i].UnformatValue != null)
				{
					tf070f02M1Form.M1scan_cd = paramCol["M1scan_cd"][i].UnformatValue;
				}
				if (paramCol["M1sinsei_su"][i].UnformatValue != null)
				{
					tf070f02M1Form.M1sinsei_su = paramCol["M1sinsei_su"][i].UnformatValue;
				}
				if (paramCol["M1jyuri_su"][i].UnformatValue != null)
				{
					tf070f02M1Form.M1jyuri_su = paramCol["M1jyuri_su"][i].UnformatValue;
				}
				if (paramCol["M1baika_hon"][i].UnformatValue != null)
				{
					tf070f02M1Form.M1baika_hon = paramCol["M1baika_hon"][i].UnformatValue;
				}
				if (paramCol["M1baika_kin"][i].UnformatValue != null)
				{
					tf070f02M1Form.M1baika_kin = paramCol["M1baika_kin"][i].UnformatValue;
				}
				if (paramCol["M1sinsei_su_hdn"][i].UnformatValue != null)
				{
					tf070f02M1Form.M1sinsei_su_hdn = paramCol["M1sinsei_su_hdn"][i].UnformatValue;
				}
				if (paramCol["M1jyuri_su_hdn"][i].UnformatValue != null)
				{
					tf070f02M1Form.M1jyuri_su_hdn = paramCol["M1jyuri_su_hdn"][i].UnformatValue;
				}
				if (paramCol["M1baika_kin_hdn"][i].UnformatValue != null)
				{
					tf070f02M1Form.M1baika_kin_hdn = paramCol["M1baika_kin_hdn"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					tf070f02M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					tf070f02M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					tf070f02M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Tf070f02Form formVO, StandardCheckManager checker)
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
			if (formVO.Tonanhinkanri_no != null)
			{
				checker.DoCheck("Tonanhinkanri_no", formVO.Tonanhinkanri_no);
			}
			if (formVO.Jikohassei_ymd != null)
			{
				checker.DoCheck("Jikohassei_ymd", formVO.Jikohassei_ymd);
			}
			if (formVO.Hokoku_ymd != null)
			{
				checker.DoCheck("Hokoku_ymd", formVO.Hokoku_ymd);
			}
			if (formVO.Hokokutan_cd != null)
			{
				checker.DoCheck("Hokokutan_cd", formVO.Hokokutan_cd);
			}
			if (formVO.Hokokutan_nm != null)
			{
				checker.DoCheck("Hokokutan_nm", formVO.Hokokutan_nm);
			}
			if (formVO.Tentyotan_cd != null)
			{
				checker.DoCheck("Tentyotan_cd", formVO.Tentyotan_cd);
			}
			if (formVO.Tentyotan_nm != null)
			{
				checker.DoCheck("Tentyotan_nm", formVO.Tentyotan_nm);
			}
			if (formVO.Keisatsutodoke_ymd != null)
			{
				checker.DoCheck("Keisatsutodoke_ymd", formVO.Keisatsutodoke_ymd);
			}
			if (formVO.Todokedesakikeisatsu_nm != null)
			{
				checker.DoCheck("Todokedesakikeisatsu_nm", formVO.Todokedesakikeisatsu_nm);
			}
			if (formVO.Jyuri_no != null)
			{
				checker.DoCheck("Jyuri_no", formVO.Jyuri_no);
			}
			if (formVO.Gokeisinsei_su != null)
			{
				checker.DoCheck("Gokeisinsei_su", formVO.Gokeisinsei_su);
			}
			if (formVO.Gokeijyuri_su != null)
			{
				checker.DoCheck("Gokeijyuri_su", formVO.Gokeijyuri_su);
			}
			if (formVO.Gokeibaika_kin != null)
			{
				checker.DoCheck("Gokeibaika_kin", formVO.Gokeibaika_kin);
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
		public static void ValidateM1InputValue(Tf070f02Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Tf070f02M1Form tf070f02M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, tf070f02M1Form, i, m1List);
				if (tf070f02M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", tf070f02M1Form.M1rowno, i, m1List);
				}
				if (tf070f02M1Form.M1hassei_tm != null)
				{
					checker.DoCheck("M1hassei_tm", tf070f02M1Form.M1hassei_tm, i, m1List);
				}
				if (tf070f02M1Form.M1hasseibasyo != null)
				{
					checker.DoCheck("M1hasseibasyo", tf070f02M1Form.M1hasseibasyo, i, m1List);
				}
				if (tf070f02M1Form.M1bumon_cd != null)
				{
					checker.DoCheck("M1bumon_cd", tf070f02M1Form.M1bumon_cd, i, m1List);
				}
				if (tf070f02M1Form.M1bumonkana_nm != null)
				{
					checker.DoCheck("M1bumonkana_nm", tf070f02M1Form.M1bumonkana_nm, i, m1List);
				}
				if (tf070f02M1Form.M1hinsyu_ryaku_nm != null)
				{
					checker.DoCheck("M1hinsyu_ryaku_nm", tf070f02M1Form.M1hinsyu_ryaku_nm, i, m1List);
				}
				if (tf070f02M1Form.M1hakkentan_cd != null)
				{
					checker.DoCheck("M1hakkentan_cd", tf070f02M1Form.M1hakkentan_cd, i, m1List);
				}
				if (tf070f02M1Form.M1hakkentan_nm != null)
				{
					checker.DoCheck("M1hakkentan_nm", tf070f02M1Form.M1hakkentan_nm, i, m1List);
				}
				if (tf070f02M1Form.M1burando_nm != null)
				{
					checker.DoCheck("M1burando_nm", tf070f02M1Form.M1burando_nm, i, m1List);
				}
				if (tf070f02M1Form.M1jisya_hbn != null)
				{
					checker.DoCheck("M1jisya_hbn", tf070f02M1Form.M1jisya_hbn, i, m1List);
				}
				if (tf070f02M1Form.M1hakkenjyokyo_kb != null)
				{
					checker.DoCheck("M1hakkenjyokyo_kb", tf070f02M1Form.M1hakkenjyokyo_kb, i, m1List);
				}
				if (tf070f02M1Form.M1hakkenjyokyo_nm != null)
				{
					checker.DoCheck("M1hakkenjyokyo_nm", tf070f02M1Form.M1hakkenjyokyo_nm, i, m1List);
				}
				if (tf070f02M1Form.M1maker_hbn != null)
				{
					checker.DoCheck("M1maker_hbn", tf070f02M1Form.M1maker_hbn, i, m1List);
				}
				if (tf070f02M1Form.M1syonmk != null)
				{
					checker.DoCheck("M1syonmk", tf070f02M1Form.M1syonmk, i, m1List);
				}
				if (tf070f02M1Form.M1iro_nm != null)
				{
					checker.DoCheck("M1iro_nm", tf070f02M1Form.M1iro_nm, i, m1List);
				}
				if (tf070f02M1Form.M1size_nm != null)
				{
					checker.DoCheck("M1size_nm", tf070f02M1Form.M1size_nm, i, m1List);
				}
				if (tf070f02M1Form.M1scan_cd != null)
				{
					checker.DoCheck("M1scan_cd", tf070f02M1Form.M1scan_cd, i, m1List);
				}
				if (tf070f02M1Form.M1sinsei_su != null)
				{
					checker.DoCheck("M1sinsei_su", tf070f02M1Form.M1sinsei_su, i, m1List);
				}
				if (tf070f02M1Form.M1jyuri_su != null)
				{
					checker.DoCheck("M1jyuri_su", tf070f02M1Form.M1jyuri_su, i, m1List);
				}
				if (tf070f02M1Form.M1baika_hon != null)
				{
					checker.DoCheck("M1baika_hon", tf070f02M1Form.M1baika_hon, i, m1List);
				}
				if (tf070f02M1Form.M1baika_kin != null)
				{
					checker.DoCheck("M1baika_kin", tf070f02M1Form.M1baika_kin, i, m1List);
				}
				if (tf070f02M1Form.M1sinsei_su_hdn != null)
				{
					checker.DoCheck("M1sinsei_su_hdn", tf070f02M1Form.M1sinsei_su_hdn, i, m1List);
				}
				if (tf070f02M1Form.M1jyuri_su_hdn != null)
				{
					checker.DoCheck("M1jyuri_su_hdn", tf070f02M1Form.M1jyuri_su_hdn, i, m1List);
				}
				if (tf070f02M1Form.M1baika_kin_hdn != null)
				{
					checker.DoCheck("M1baika_kin_hdn", tf070f02M1Form.M1baika_kin_hdn, i, m1List);
				}
				if (tf070f02M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", tf070f02M1Form.M1selectorcheckbox, i, m1List);
				}
				if (tf070f02M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", tf070f02M1Form.M1entersyoriflg, i, m1List);
				}
				if (tf070f02M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", tf070f02M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Tf070f02Form formVO, StandardCodeCheckManager checker)
		{
			checker.DoCheck("Btnhokokutanto_cd", formVO);
			checker.DoCheck("Btntenhchotanto_cd", formVO);
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Tf070f02Form formVO, StandardCodeCheckManager checker)
		{
			checker.DoCheck("M1btntanto_cd", formVO);
		}
	}
}

