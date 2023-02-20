using com.xebio.bo.Te060p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Te060p01.Request
{
  /// <summary>
  /// Te060f01RequestHelper の概要の説明です。
  /// </summary>
  public static class Te060f01RequestHelper
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
			Te060f01Form formVO = (Te060f01Form)pageContext.GetFormVO();

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
			paramCol["Syohingun1_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Syohingun1_cd"]);
			paramCol["Syohingun1_ryaku_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Syohingun1_ryaku_nm"]);
			paramCol["Siiresaki_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Siiresaki_cd"]);
			paramCol["Siiresaki_ryaku_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Siiresaki_ryaku_nm"]);
			paramCol["Bumon_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_cd"]);
			paramCol["Bumon_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_nm"]);
			paramCol["Sakujo_kbn"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Sakujo_kbn"]);
			paramCol["Hanbaikanryo_ymd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hanbaikanryo_ymd"]);
			paramCol["Add_ymd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Add_ymd_from"]);
			paramCol["Add_ymd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Add_ymd_to"]);
			paramCol["Sort_jun"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Sort_jun"]);
			paramCol["Searchcnt"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Searchcnt"]);
			paramCol["Stop_ymd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Stop_ymd"]);
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
				paramCol["M1bumon_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1bumon_cd"]);
				paramCol["M1bumonkana_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1bumonkana_nm"]);
				paramCol["M1hinsyu_ryaku_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hinsyu_ryaku_nm"]);
				paramCol["M1burando_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1burando_nm"]);
				paramCol["M1jisya_hbn1"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1jisya_hbn1"]);
				paramCol["M1maker_hbn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1maker_hbn"]);
				paramCol["M1syonmk"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1syonmk"]);
				paramCol["M1iro_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1iro_nm"]);
				paramCol["M1stop_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1stop_ymd"]);
				paramCol["M1add_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1add_ymd"]);
				paramCol["M1honbutenpokbnnm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1honbutenpokbnnm"]);
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
			Te060f01Form formVO = (Te060f01Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Modeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Modeno"].RequestValue, formInfo["Modeno"]);
			paramCol["Stkmodeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Stkmodeno"].RequestValue, formInfo["Stkmodeno"]);
			paramCol["Syohingun1_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Syohingun1_cd"].RequestValue, formInfo["Syohingun1_cd"]);
			paramCol["Syohingun1_ryaku_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Syohingun1_ryaku_nm"].RequestValue, formInfo["Syohingun1_ryaku_nm"]);
			paramCol["Siiresaki_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Siiresaki_cd"].RequestValue, formInfo["Siiresaki_cd"]);
			paramCol["Siiresaki_ryaku_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Siiresaki_ryaku_nm"].RequestValue, formInfo["Siiresaki_ryaku_nm"]);
			paramCol["Bumon_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_cd"].RequestValue, formInfo["Bumon_cd"]);
			paramCol["Bumon_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_nm"].RequestValue, formInfo["Bumon_nm"]);
			paramCol["Sakujo_kbn"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Sakujo_kbn"].RequestValue, formInfo["Sakujo_kbn"]);
			paramCol["Hanbaikanryo_ymd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hanbaikanryo_ymd"].RequestValue, formInfo["Hanbaikanryo_ymd"]);
			paramCol["Hanbaikanryo_ymd"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Hanbaikanryo_ymd"].RequestValue, formInfo["Hanbaikanryo_ymd"]);
			paramCol["Add_ymd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Add_ymd_from"].RequestValue, formInfo["Add_ymd_from"]);
			paramCol["Add_ymd_from"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Add_ymd_from"].RequestValue, formInfo["Add_ymd_from"]);
			paramCol["Add_ymd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Add_ymd_to"].RequestValue, formInfo["Add_ymd_to"]);
			paramCol["Add_ymd_to"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Add_ymd_to"].RequestValue, formInfo["Add_ymd_to"]);
			paramCol["Sort_jun"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Sort_jun"].RequestValue, formInfo["Sort_jun"]);
			paramCol["Searchcnt"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Searchcnt"].RequestValue, formInfo["Searchcnt"]);
			paramCol["Stop_ymd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Stop_ymd"].RequestValue, formInfo["Stop_ymd"]);
			paramCol["Stop_ymd"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Stop_ymd"].RequestValue, formInfo["Stop_ymd"]);
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
				paramCol["M1bumon_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1bumon_cd"][i].RequestValue, formInfo["M1bumon_cd"]);
				paramCol["M1bumonkana_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1bumonkana_nm"][i].RequestValue, formInfo["M1bumonkana_nm"]);
				paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hinsyu_ryaku_nm"][i].RequestValue, formInfo["M1hinsyu_ryaku_nm"]);
				paramCol["M1burando_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1burando_nm"][i].RequestValue, formInfo["M1burando_nm"]);
				paramCol["M1jisya_hbn1"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1jisya_hbn1"][i].RequestValue, formInfo["M1jisya_hbn1"]);
				paramCol["M1maker_hbn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1maker_hbn"][i].RequestValue, formInfo["M1maker_hbn"]);
				paramCol["M1syonmk"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1syonmk"][i].RequestValue, formInfo["M1syonmk"]);
				paramCol["M1iro_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1iro_nm"][i].RequestValue, formInfo["M1iro_nm"]);
				paramCol["M1stop_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1stop_ymd"][i].RequestValue, formInfo["M1stop_ymd"]);
				paramCol["M1stop_ymd"][i].DateFullValue = RequestParameterUtil.GetDateFullValue(
					paramCol["M1stop_ymd"][i].RequestValue, formInfo["M1stop_ymd"]);
				paramCol["M1add_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1add_ymd"][i].RequestValue, formInfo["M1add_ymd"]);
				paramCol["M1add_ymd"][i].DateFullValue = RequestParameterUtil.GetDateFullValue(
					paramCol["M1add_ymd"][i].RequestValue, formInfo["M1add_ymd"]);
				paramCol["M1honbutenpokbnnm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1honbutenpokbnnm"][i].RequestValue, formInfo["M1honbutenpokbnnm"]);
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
			Te060f01Form formVO = (Te060f01Form)pageContext.GetFormVO();

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
			if (paramCol["Syohingun1_cd"].UnformatValue != null)
			{
				formVO.Syohingun1_cd = paramCol["Syohingun1_cd"].UnformatValue;
			}
			if (paramCol["Syohingun1_ryaku_nm"].UnformatValue != null)
			{
				formVO.Syohingun1_ryaku_nm = paramCol["Syohingun1_ryaku_nm"].UnformatValue;
			}
			if (paramCol["Siiresaki_cd"].UnformatValue != null)
			{
				formVO.Siiresaki_cd = paramCol["Siiresaki_cd"].UnformatValue;
			}
			if (paramCol["Siiresaki_ryaku_nm"].UnformatValue != null)
			{
				formVO.Siiresaki_ryaku_nm = paramCol["Siiresaki_ryaku_nm"].UnformatValue;
			}
			if (paramCol["Bumon_cd"].UnformatValue != null)
			{
				formVO.Bumon_cd = paramCol["Bumon_cd"].UnformatValue;
			}
			if (paramCol["Bumon_nm"].UnformatValue != null)
			{
				formVO.Bumon_nm = paramCol["Bumon_nm"].UnformatValue;
			}
			if (paramCol["Sakujo_kbn"].UnformatValue != null)
			{
				formVO.Sakujo_kbn = paramCol["Sakujo_kbn"].UnformatValue;
			}
			if (paramCol["Hanbaikanryo_ymd"].DateFullValue != null)
			{
				formVO.Hanbaikanryo_ymd = paramCol["Hanbaikanryo_ymd"].DateFullValue;
			}
			if (paramCol["Add_ymd_from"].DateFullValue != null)
			{
				formVO.Add_ymd_from = paramCol["Add_ymd_from"].DateFullValue;
			}
			if (paramCol["Add_ymd_to"].DateFullValue != null)
			{
				formVO.Add_ymd_to = paramCol["Add_ymd_to"].DateFullValue;
			}
			if (paramCol["Sort_jun"].UnformatValue != null)
			{
				formVO.Sort_jun = paramCol["Sort_jun"].UnformatValue;
			}
			if (paramCol["Searchcnt"].UnformatValue != null)
			{
				formVO.Searchcnt = paramCol["Searchcnt"].UnformatValue;
			}
			if (paramCol["Stop_ymd"].DateFullValue != null)
			{
				formVO.Stop_ymd = paramCol["Stop_ymd"].DateFullValue;
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
				Te060f01M1Form te060f01M1Form = (Te060f01M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					te060f01M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1bumon_cd"][i].UnformatValue != null)
				{
					te060f01M1Form.M1bumon_cd = paramCol["M1bumon_cd"][i].UnformatValue;
				}
				if (paramCol["M1bumonkana_nm"][i].UnformatValue != null)
				{
					te060f01M1Form.M1bumonkana_nm = paramCol["M1bumonkana_nm"][i].UnformatValue;
				}
				if (paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue != null)
				{
					te060f01M1Form.M1hinsyu_ryaku_nm = paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue;
				}
				if (paramCol["M1burando_nm"][i].UnformatValue != null)
				{
					te060f01M1Form.M1burando_nm = paramCol["M1burando_nm"][i].UnformatValue;
				}
				if (paramCol["M1jisya_hbn1"][i].UnformatValue != null)
				{
					te060f01M1Form.M1jisya_hbn1 = paramCol["M1jisya_hbn1"][i].UnformatValue;
				}
				if (paramCol["M1maker_hbn"][i].UnformatValue != null)
				{
					te060f01M1Form.M1maker_hbn = paramCol["M1maker_hbn"][i].UnformatValue;
				}
				if (paramCol["M1syonmk"][i].UnformatValue != null)
				{
					te060f01M1Form.M1syonmk = paramCol["M1syonmk"][i].UnformatValue;
				}
				if (paramCol["M1iro_nm"][i].UnformatValue != null)
				{
					te060f01M1Form.M1iro_nm = paramCol["M1iro_nm"][i].UnformatValue;
				}
				if (paramCol["M1stop_ymd"][i].DateFullValue != null)
				{
					te060f01M1Form.M1stop_ymd = paramCol["M1stop_ymd"][i].DateFullValue;
				}
				if (paramCol["M1add_ymd"][i].DateFullValue != null)
				{
					te060f01M1Form.M1add_ymd = paramCol["M1add_ymd"][i].DateFullValue;
				}
				if (paramCol["M1honbutenpokbnnm"][i].UnformatValue != null)
				{
					te060f01M1Form.M1honbutenpokbnnm = paramCol["M1honbutenpokbnnm"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					te060f01M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					te060f01M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					te060f01M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Te060f01Form formVO, StandardCheckManager checker)
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
			if (formVO.Syohingun1_cd != null)
			{
				checker.DoCheck("Syohingun1_cd", formVO.Syohingun1_cd);
			}
			if (formVO.Syohingun1_ryaku_nm != null)
			{
				checker.DoCheck("Syohingun1_ryaku_nm", formVO.Syohingun1_ryaku_nm);
			}
			if (formVO.Siiresaki_cd != null)
			{
				checker.DoCheck("Siiresaki_cd", formVO.Siiresaki_cd);
			}
			if (formVO.Siiresaki_ryaku_nm != null)
			{
				checker.DoCheck("Siiresaki_ryaku_nm", formVO.Siiresaki_ryaku_nm);
			}
			if (formVO.Bumon_cd != null)
			{
				checker.DoCheck("Bumon_cd", formVO.Bumon_cd);
			}
			if (formVO.Bumon_nm != null)
			{
				checker.DoCheck("Bumon_nm", formVO.Bumon_nm);
			}
			if (formVO.Sakujo_kbn != null)
			{
				checker.DoCheck("Sakujo_kbn", formVO.Sakujo_kbn);
			}
			if (formVO.Hanbaikanryo_ymd != null)
			{
				checker.DoCheck("Hanbaikanryo_ymd", formVO.Hanbaikanryo_ymd);
			}
			if (formVO.Add_ymd_from != null)
			{
				checker.DoCheck("Add_ymd_from", formVO.Add_ymd_from);
			}
			if (formVO.Add_ymd_to != null)
			{
				checker.DoCheck("Add_ymd_to", formVO.Add_ymd_to);
			}
			if (formVO.Sort_jun != null)
			{
				checker.DoCheck("Sort_jun", formVO.Sort_jun);
			}
			if (formVO.Searchcnt != null)
			{
				checker.DoCheck("Searchcnt", formVO.Searchcnt);
			}
			if (formVO.Stop_ymd != null)
			{
				checker.DoCheck("Stop_ymd", formVO.Stop_ymd);
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
		public static void ValidateM1InputValue(Te060f01Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Te060f01M1Form te060f01M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, te060f01M1Form, i, m1List);
				if (te060f01M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", te060f01M1Form.M1rowno, i, m1List);
				}
				if (te060f01M1Form.M1bumon_cd != null)
				{
					checker.DoCheck("M1bumon_cd", te060f01M1Form.M1bumon_cd, i, m1List);
				}
				if (te060f01M1Form.M1bumonkana_nm != null)
				{
					checker.DoCheck("M1bumonkana_nm", te060f01M1Form.M1bumonkana_nm, i, m1List);
				}
				if (te060f01M1Form.M1hinsyu_ryaku_nm != null)
				{
					checker.DoCheck("M1hinsyu_ryaku_nm", te060f01M1Form.M1hinsyu_ryaku_nm, i, m1List);
				}
				if (te060f01M1Form.M1burando_nm != null)
				{
					checker.DoCheck("M1burando_nm", te060f01M1Form.M1burando_nm, i, m1List);
				}
				if (te060f01M1Form.M1jisya_hbn1 != null)
				{
					checker.DoCheck("M1jisya_hbn1", te060f01M1Form.M1jisya_hbn1, i, m1List);
				}
				if (te060f01M1Form.M1maker_hbn != null)
				{
					checker.DoCheck("M1maker_hbn", te060f01M1Form.M1maker_hbn, i, m1List);
				}
				if (te060f01M1Form.M1syonmk != null)
				{
					checker.DoCheck("M1syonmk", te060f01M1Form.M1syonmk, i, m1List);
				}
				if (te060f01M1Form.M1iro_nm != null)
				{
					checker.DoCheck("M1iro_nm", te060f01M1Form.M1iro_nm, i, m1List);
				}
				if (te060f01M1Form.M1stop_ymd != null)
				{
					checker.DoCheck("M1stop_ymd", te060f01M1Form.M1stop_ymd, i, m1List);
				}
				if (te060f01M1Form.M1add_ymd != null)
				{
					checker.DoCheck("M1add_ymd", te060f01M1Form.M1add_ymd, i, m1List);
				}
				if (te060f01M1Form.M1honbutenpokbnnm != null)
				{
					checker.DoCheck("M1honbutenpokbnnm", te060f01M1Form.M1honbutenpokbnnm, i, m1List);
				}
				if (te060f01M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", te060f01M1Form.M1selectorcheckbox, i, m1List);
				}
				if (te060f01M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", te060f01M1Form.M1entersyoriflg, i, m1List);
				}
				if (te060f01M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", te060f01M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Te060f01Form formVO, StandardCodeCheckManager checker)
		{
			checker.DoCheck("Btnheadtenpocd", formVO);
			checker.DoCheck("Btnsyohingun1_cd", formVO);
			checker.DoCheck("Btnsiiresaki_cd", formVO);
			checker.DoCheck("Btnbumon_cd", formVO);
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Te060f01Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

