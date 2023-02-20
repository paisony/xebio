using com.xebio.bo.Tm070p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Tm070p01.Request
{
  /// <summary>
  /// Tm070f01RequestHelper の概要の説明です。
  /// </summary>
  public static class Tm070f01RequestHelper
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
			Tm070f01Form formVO = (Tm070f01Form)pageContext.GetFormVO();

			//カード部を初期化する
			paramCol.InitCardItems(formInfo.GetCardItems());
			//明細「M1」部を初期化する
			paramCol.InitListItems(formInfo.GetListItems("M1"), formVO.GetList("M1").CurrentCount);
			//カード項目の入力値を取得する
			paramCol["Head_tenpo_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_nm"]);
			paramCol["Henko_ymd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Henko_ymd_from"]);
			paramCol["Henko_ymd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Henko_ymd_to"]);
			paramCol["Moto_tenpo_cd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Moto_tenpo_cd_from"]);
			paramCol["Moto_tenpo_nm_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Moto_tenpo_nm_from"]);
			paramCol["Moto_tenpo_cd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Moto_tenpo_cd_to"]);
			paramCol["Moto_tenpo_nm_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Moto_tenpo_nm_to"]);
			paramCol["Tan_cd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tan_cd_from"]);
			paramCol["Tan_nm_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tan_nm_from"]);
			paramCol["Tan_cd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tan_cd_to"]);
			paramCol["Tan_nm_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tan_nm_to"]);
			paramCol["Stkmodeno"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Stkmodeno"]);
			paramCol["Searchcnt"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Searchcnt"]);
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
				paramCol["M1tan_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tan_cd"]);
				paramCol["M1tan_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tan_nm"]);
				paramCol["M1moto_tenpo_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1moto_tenpo_cd"]);
				paramCol["M1moto_tenpo_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1moto_tenpo_nm"]);
				paramCol["M1henko_tenpo_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1henko_tenpo_cd"]);
				paramCol["M1henko_tenpo_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1henko_tenpo_nm"]);
				paramCol["M1henko_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1henko_ymd"]);
				paramCol["M1henko_tm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1henko_tm"]);
				paramCol["M1shozokuten_shokika_check"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1shozokuten_shokika_check"]);
				paramCol["M1upd_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1upd_ymd"]);
				paramCol["M1upd_tm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1upd_tm"]);
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
			Tm070f01Form formVO = (Tm070f01Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Henko_ymd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Henko_ymd_from"].RequestValue, formInfo["Henko_ymd_from"]);
			paramCol["Henko_ymd_from"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Henko_ymd_from"].RequestValue, formInfo["Henko_ymd_from"]);
			paramCol["Henko_ymd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Henko_ymd_to"].RequestValue, formInfo["Henko_ymd_to"]);
			paramCol["Henko_ymd_to"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Henko_ymd_to"].RequestValue, formInfo["Henko_ymd_to"]);
			paramCol["Moto_tenpo_cd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Moto_tenpo_cd_from"].RequestValue, formInfo["Moto_tenpo_cd_from"]);
			paramCol["Moto_tenpo_nm_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Moto_tenpo_nm_from"].RequestValue, formInfo["Moto_tenpo_nm_from"]);
			paramCol["Moto_tenpo_cd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Moto_tenpo_cd_to"].RequestValue, formInfo["Moto_tenpo_cd_to"]);
			paramCol["Moto_tenpo_nm_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Moto_tenpo_nm_to"].RequestValue, formInfo["Moto_tenpo_nm_to"]);
			paramCol["Tan_cd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tan_cd_from"].RequestValue, formInfo["Tan_cd_from"]);
			paramCol["Tan_nm_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tan_nm_from"].RequestValue, formInfo["Tan_nm_from"]);
			paramCol["Tan_cd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tan_cd_to"].RequestValue, formInfo["Tan_cd_to"]);
			paramCol["Tan_nm_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tan_nm_to"].RequestValue, formInfo["Tan_nm_to"]);
			paramCol["Stkmodeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Stkmodeno"].RequestValue, formInfo["Stkmodeno"]);
			paramCol["Searchcnt"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Searchcnt"].RequestValue, formInfo["Searchcnt"]);
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
				paramCol["M1tan_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tan_cd"][i].RequestValue, formInfo["M1tan_cd"]);
				paramCol["M1tan_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tan_nm"][i].RequestValue, formInfo["M1tan_nm"]);
				paramCol["M1moto_tenpo_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1moto_tenpo_cd"][i].RequestValue, formInfo["M1moto_tenpo_cd"]);
				paramCol["M1moto_tenpo_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1moto_tenpo_nm"][i].RequestValue, formInfo["M1moto_tenpo_nm"]);
				paramCol["M1henko_tenpo_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1henko_tenpo_cd"][i].RequestValue, formInfo["M1henko_tenpo_cd"]);
				paramCol["M1henko_tenpo_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1henko_tenpo_nm"][i].RequestValue, formInfo["M1henko_tenpo_nm"]);
				paramCol["M1henko_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1henko_ymd"][i].RequestValue, formInfo["M1henko_ymd"]);
				paramCol["M1henko_ymd"][i].DateFullValue = RequestParameterUtil.GetDateFullValue(
					paramCol["M1henko_ymd"][i].RequestValue, formInfo["M1henko_ymd"]);
				paramCol["M1henko_tm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1henko_tm"][i].RequestValue, formInfo["M1henko_tm"]);
				paramCol["M1henko_tm"][i].DateFullValue = RequestParameterUtil.GetDateFullValue(
					paramCol["M1henko_tm"][i].RequestValue, formInfo["M1henko_tm"]);
				paramCol["M1shozokuten_shokika_check"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1shozokuten_shokika_check"][i].RequestValue, formInfo["M1shozokuten_shokika_check"]);
				paramCol["M1upd_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1upd_ymd"][i].RequestValue, formInfo["M1upd_ymd"]);
				paramCol["M1upd_tm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1upd_tm"][i].RequestValue, formInfo["M1upd_tm"]);
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
			Tm070f01Form formVO = (Tm070f01Form)pageContext.GetFormVO();

			//カード項目の入力値をFormVOにコピーする
			if (paramCol["Head_tenpo_cd"].UnformatValue != null)
			{
				formVO.Head_tenpo_cd = paramCol["Head_tenpo_cd"].UnformatValue;
			}
			if (paramCol["Head_tenpo_nm"].UnformatValue != null)
			{
				formVO.Head_tenpo_nm = paramCol["Head_tenpo_nm"].UnformatValue;
			}
			if (paramCol["Henko_ymd_from"].DateFullValue != null)
			{
				formVO.Henko_ymd_from = paramCol["Henko_ymd_from"].DateFullValue;
			}
			if (paramCol["Henko_ymd_to"].DateFullValue != null)
			{
				formVO.Henko_ymd_to = paramCol["Henko_ymd_to"].DateFullValue;
			}
			if (paramCol["Moto_tenpo_cd_from"].UnformatValue != null)
			{
				formVO.Moto_tenpo_cd_from = paramCol["Moto_tenpo_cd_from"].UnformatValue;
			}
			if (paramCol["Moto_tenpo_nm_from"].UnformatValue != null)
			{
				formVO.Moto_tenpo_nm_from = paramCol["Moto_tenpo_nm_from"].UnformatValue;
			}
			if (paramCol["Moto_tenpo_cd_to"].UnformatValue != null)
			{
				formVO.Moto_tenpo_cd_to = paramCol["Moto_tenpo_cd_to"].UnformatValue;
			}
			if (paramCol["Moto_tenpo_nm_to"].UnformatValue != null)
			{
				formVO.Moto_tenpo_nm_to = paramCol["Moto_tenpo_nm_to"].UnformatValue;
			}
			if (paramCol["Tan_cd_from"].UnformatValue != null)
			{
				formVO.Tan_cd_from = paramCol["Tan_cd_from"].UnformatValue;
			}
			if (paramCol["Tan_nm_from"].UnformatValue != null)
			{
				formVO.Tan_nm_from = paramCol["Tan_nm_from"].UnformatValue;
			}
			if (paramCol["Tan_cd_to"].UnformatValue != null)
			{
				formVO.Tan_cd_to = paramCol["Tan_cd_to"].UnformatValue;
			}
			if (paramCol["Tan_nm_to"].UnformatValue != null)
			{
				formVO.Tan_nm_to = paramCol["Tan_nm_to"].UnformatValue;
			}
			if (paramCol["Stkmodeno"].UnformatValue != null)
			{
				formVO.Stkmodeno = paramCol["Stkmodeno"].UnformatValue;
			}
			if (paramCol["Searchcnt"].UnformatValue != null)
			{
				formVO.Searchcnt = paramCol["Searchcnt"].UnformatValue;
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
				Tm070f01M1Form tm070f01M1Form = (Tm070f01M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					tm070f01M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1tan_cd"][i].UnformatValue != null)
				{
					tm070f01M1Form.M1tan_cd = paramCol["M1tan_cd"][i].UnformatValue;
				}
				if (paramCol["M1tan_nm"][i].UnformatValue != null)
				{
					tm070f01M1Form.M1tan_nm = paramCol["M1tan_nm"][i].UnformatValue;
				}
				if (paramCol["M1moto_tenpo_cd"][i].UnformatValue != null)
				{
					tm070f01M1Form.M1moto_tenpo_cd = paramCol["M1moto_tenpo_cd"][i].UnformatValue;
				}
				if (paramCol["M1moto_tenpo_nm"][i].UnformatValue != null)
				{
					tm070f01M1Form.M1moto_tenpo_nm = paramCol["M1moto_tenpo_nm"][i].UnformatValue;
				}
				if (paramCol["M1henko_tenpo_cd"][i].UnformatValue != null)
				{
					tm070f01M1Form.M1henko_tenpo_cd = paramCol["M1henko_tenpo_cd"][i].UnformatValue;
				}
				if (paramCol["M1henko_tenpo_nm"][i].UnformatValue != null)
				{
					tm070f01M1Form.M1henko_tenpo_nm = paramCol["M1henko_tenpo_nm"][i].UnformatValue;
				}
				if (paramCol["M1henko_ymd"][i].DateFullValue != null)
				{
					tm070f01M1Form.M1henko_ymd = paramCol["M1henko_ymd"][i].DateFullValue;
				}
				if (paramCol["M1henko_tm"][i].DateFullValue != null)
				{
					tm070f01M1Form.M1henko_tm = paramCol["M1henko_tm"][i].DateFullValue;
				}
				if (paramCol["M1shozokuten_shokika_check"][i].UnformatValue != null)
				{
					tm070f01M1Form.M1shozokuten_shokika_check = paramCol["M1shozokuten_shokika_check"][i].UnformatValue;
				}
				if (paramCol["M1upd_ymd"][i].UnformatValue != null)
				{
					tm070f01M1Form.M1upd_ymd = paramCol["M1upd_ymd"][i].UnformatValue;
				}
				if (paramCol["M1upd_tm"][i].UnformatValue != null)
				{
					tm070f01M1Form.M1upd_tm = paramCol["M1upd_tm"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					tm070f01M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					tm070f01M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					tm070f01M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Tm070f01Form formVO, StandardCheckManager checker)
		{
			if (formVO.Head_tenpo_cd != null)
			{
				checker.DoCheck("Head_tenpo_cd", formVO.Head_tenpo_cd);
			}
			if (formVO.Head_tenpo_nm != null)
			{
				checker.DoCheck("Head_tenpo_nm", formVO.Head_tenpo_nm);
			}
			if (formVO.Henko_ymd_from != null)
			{
				checker.DoCheck("Henko_ymd_from", formVO.Henko_ymd_from);
			}
			if (formVO.Henko_ymd_to != null)
			{
				checker.DoCheck("Henko_ymd_to", formVO.Henko_ymd_to);
			}
			if (formVO.Moto_tenpo_cd_from != null)
			{
				checker.DoCheck("Moto_tenpo_cd_from", formVO.Moto_tenpo_cd_from);
			}
			if (formVO.Moto_tenpo_nm_from != null)
			{
				checker.DoCheck("Moto_tenpo_nm_from", formVO.Moto_tenpo_nm_from);
			}
			if (formVO.Moto_tenpo_cd_to != null)
			{
				checker.DoCheck("Moto_tenpo_cd_to", formVO.Moto_tenpo_cd_to);
			}
			if (formVO.Moto_tenpo_nm_to != null)
			{
				checker.DoCheck("Moto_tenpo_nm_to", formVO.Moto_tenpo_nm_to);
			}
			if (formVO.Tan_cd_from != null)
			{
				checker.DoCheck("Tan_cd_from", formVO.Tan_cd_from);
			}
			if (formVO.Tan_nm_from != null)
			{
				checker.DoCheck("Tan_nm_from", formVO.Tan_nm_from);
			}
			if (formVO.Tan_cd_to != null)
			{
				checker.DoCheck("Tan_cd_to", formVO.Tan_cd_to);
			}
			if (formVO.Tan_nm_to != null)
			{
				checker.DoCheck("Tan_nm_to", formVO.Tan_nm_to);
			}
			if (formVO.Stkmodeno != null)
			{
				checker.DoCheck("Stkmodeno", formVO.Stkmodeno);
			}
			if (formVO.Searchcnt != null)
			{
				checker.DoCheck("Searchcnt", formVO.Searchcnt);
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
		public static void ValidateM1InputValue(Tm070f01Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Tm070f01M1Form tm070f01M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, tm070f01M1Form, i, m1List);
				if (tm070f01M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", tm070f01M1Form.M1rowno, i, m1List);
				}
				if (tm070f01M1Form.M1tan_cd != null)
				{
					checker.DoCheck("M1tan_cd", tm070f01M1Form.M1tan_cd, i, m1List);
				}
				if (tm070f01M1Form.M1tan_nm != null)
				{
					checker.DoCheck("M1tan_nm", tm070f01M1Form.M1tan_nm, i, m1List);
				}
				if (tm070f01M1Form.M1moto_tenpo_cd != null)
				{
					checker.DoCheck("M1moto_tenpo_cd", tm070f01M1Form.M1moto_tenpo_cd, i, m1List);
				}
				if (tm070f01M1Form.M1moto_tenpo_nm != null)
				{
					checker.DoCheck("M1moto_tenpo_nm", tm070f01M1Form.M1moto_tenpo_nm, i, m1List);
				}
				if (tm070f01M1Form.M1henko_tenpo_cd != null)
				{
					checker.DoCheck("M1henko_tenpo_cd", tm070f01M1Form.M1henko_tenpo_cd, i, m1List);
				}
				if (tm070f01M1Form.M1henko_tenpo_nm != null)
				{
					checker.DoCheck("M1henko_tenpo_nm", tm070f01M1Form.M1henko_tenpo_nm, i, m1List);
				}
				if (tm070f01M1Form.M1henko_ymd != null)
				{
					checker.DoCheck("M1henko_ymd", tm070f01M1Form.M1henko_ymd, i, m1List);
				}
				if (tm070f01M1Form.M1henko_tm != null)
				{
					checker.DoCheck("M1henko_tm", tm070f01M1Form.M1henko_tm, i, m1List);
				}
				if (tm070f01M1Form.M1shozokuten_shokika_check != null)
				{
					checker.DoCheck("M1shozokuten_shokika_check", tm070f01M1Form.M1shozokuten_shokika_check, i, m1List);
				}
				if (tm070f01M1Form.M1upd_ymd != null)
				{
					checker.DoCheck("M1upd_ymd", tm070f01M1Form.M1upd_ymd, i, m1List);
				}
				if (tm070f01M1Form.M1upd_tm != null)
				{
					checker.DoCheck("M1upd_tm", tm070f01M1Form.M1upd_tm, i, m1List);
				}
				if (tm070f01M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", tm070f01M1Form.M1selectorcheckbox, i, m1List);
				}
				if (tm070f01M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", tm070f01M1Form.M1entersyoriflg, i, m1List);
				}
				if (tm070f01M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", tm070f01M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Tm070f01Form formVO, StandardCodeCheckManager checker)
		{
			checker.DoCheck("Btnheadtenpocd", formVO);
			checker.DoCheck("Btnmototenpocd_from", formVO);
			checker.DoCheck("Btnmototenpocd_to", formVO);
			checker.DoCheck("Btntancd_from", formVO);
			checker.DoCheck("Btntancd_to", formVO);
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Tm070f01Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

