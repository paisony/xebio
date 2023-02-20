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
  /// Tf070f01RequestHelper の概要の説明です。
  /// </summary>
  public static class Tf070f01RequestHelper
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
			Tf070f01Form formVO = (Tf070f01Form)pageContext.GetFormVO();

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
			paramCol["Tonanhinkanri_no_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tonanhinkanri_no_from"]);
			paramCol["Tonanhinkanri_no_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tonanhinkanri_no_to"]);
			paramCol["Jikohassei_ymd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Jikohassei_ymd_from"]);
			paramCol["Jikohassei_ymd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Jikohassei_ymd_to"]);
			paramCol["Hokoku_ymd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hokoku_ymd_from"]);
			paramCol["Hokoku_ymd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hokoku_ymd_to"]);
			paramCol["Hokokutan_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hokokutan_cd"]);
			paramCol["Hokokutan_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hokokutan_nm"]);
			paramCol["Keisatsutodoke_ymd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Keisatsutodoke_ymd_from"]);
			paramCol["Keisatsutodoke_ymd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Keisatsutodoke_ymd_to"]);
			paramCol["Jyuri_no_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Jyuri_no_from"]);
			paramCol["Jyuri_no_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Jyuri_no_to"]);
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
				paramCol["M1jikohassei_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1jikohassei_ymd"]);
				paramCol["M1hokoku_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hokoku_ymd"]);
				paramCol["M1hokokutan_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hokokutan_nm"]);
				paramCol["M1tentyotan_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tentyotan_nm"]);
				paramCol["M1keisatsutodoke_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1keisatsutodoke_ymd"]);
				paramCol["M1todokedesakikeisatsu_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1todokedesakikeisatsu_nm"]);
				paramCol["M1jyuri_no"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1jyuri_no"]);
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
			Tf070f01Form formVO = (Tf070f01Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Modeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Modeno"].RequestValue, formInfo["Modeno"]);
			paramCol["Stkmodeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Stkmodeno"].RequestValue, formInfo["Stkmodeno"]);
			paramCol["Tonanhinkanri_no_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tonanhinkanri_no_from"].RequestValue, formInfo["Tonanhinkanri_no_from"]);
			paramCol["Tonanhinkanri_no_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tonanhinkanri_no_to"].RequestValue, formInfo["Tonanhinkanri_no_to"]);
			paramCol["Jikohassei_ymd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Jikohassei_ymd_from"].RequestValue, formInfo["Jikohassei_ymd_from"]);
			paramCol["Jikohassei_ymd_from"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Jikohassei_ymd_from"].RequestValue, formInfo["Jikohassei_ymd_from"]);
			paramCol["Jikohassei_ymd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Jikohassei_ymd_to"].RequestValue, formInfo["Jikohassei_ymd_to"]);
			paramCol["Jikohassei_ymd_to"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Jikohassei_ymd_to"].RequestValue, formInfo["Jikohassei_ymd_to"]);
			paramCol["Hokoku_ymd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hokoku_ymd_from"].RequestValue, formInfo["Hokoku_ymd_from"]);
			paramCol["Hokoku_ymd_from"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Hokoku_ymd_from"].RequestValue, formInfo["Hokoku_ymd_from"]);
			paramCol["Hokoku_ymd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hokoku_ymd_to"].RequestValue, formInfo["Hokoku_ymd_to"]);
			paramCol["Hokoku_ymd_to"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Hokoku_ymd_to"].RequestValue, formInfo["Hokoku_ymd_to"]);
			paramCol["Hokokutan_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hokokutan_cd"].RequestValue, formInfo["Hokokutan_cd"]);
			paramCol["Hokokutan_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hokokutan_nm"].RequestValue, formInfo["Hokokutan_nm"]);
			paramCol["Keisatsutodoke_ymd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Keisatsutodoke_ymd_from"].RequestValue, formInfo["Keisatsutodoke_ymd_from"]);
			paramCol["Keisatsutodoke_ymd_from"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Keisatsutodoke_ymd_from"].RequestValue, formInfo["Keisatsutodoke_ymd_from"]);
			paramCol["Keisatsutodoke_ymd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Keisatsutodoke_ymd_to"].RequestValue, formInfo["Keisatsutodoke_ymd_to"]);
			paramCol["Keisatsutodoke_ymd_to"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Keisatsutodoke_ymd_to"].RequestValue, formInfo["Keisatsutodoke_ymd_to"]);
			paramCol["Jyuri_no_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Jyuri_no_from"].RequestValue, formInfo["Jyuri_no_from"]);
			paramCol["Jyuri_no_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Jyuri_no_to"].RequestValue, formInfo["Jyuri_no_to"]);
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
				paramCol["M1jikohassei_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1jikohassei_ymd"][i].RequestValue, formInfo["M1jikohassei_ymd"]);
				paramCol["M1jikohassei_ymd"][i].DateFullValue = RequestParameterUtil.GetDateFullValue(
					paramCol["M1jikohassei_ymd"][i].RequestValue, formInfo["M1jikohassei_ymd"]);
				paramCol["M1hokoku_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hokoku_ymd"][i].RequestValue, formInfo["M1hokoku_ymd"]);
				paramCol["M1hokoku_ymd"][i].DateFullValue = RequestParameterUtil.GetDateFullValue(
					paramCol["M1hokoku_ymd"][i].RequestValue, formInfo["M1hokoku_ymd"]);
				paramCol["M1hokokutan_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hokokutan_nm"][i].RequestValue, formInfo["M1hokokutan_nm"]);
				paramCol["M1tentyotan_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tentyotan_nm"][i].RequestValue, formInfo["M1tentyotan_nm"]);
				paramCol["M1keisatsutodoke_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1keisatsutodoke_ymd"][i].RequestValue, formInfo["M1keisatsutodoke_ymd"]);
				paramCol["M1keisatsutodoke_ymd"][i].DateFullValue = RequestParameterUtil.GetDateFullValue(
					paramCol["M1keisatsutodoke_ymd"][i].RequestValue, formInfo["M1keisatsutodoke_ymd"]);
				paramCol["M1todokedesakikeisatsu_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1todokedesakikeisatsu_nm"][i].RequestValue, formInfo["M1todokedesakikeisatsu_nm"]);
				paramCol["M1jyuri_no"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1jyuri_no"][i].RequestValue, formInfo["M1jyuri_no"]);
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
			Tf070f01Form formVO = (Tf070f01Form)pageContext.GetFormVO();

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
			if (paramCol["Tonanhinkanri_no_from"].UnformatValue != null)
			{
				formVO.Tonanhinkanri_no_from = paramCol["Tonanhinkanri_no_from"].UnformatValue;
			}
			if (paramCol["Tonanhinkanri_no_to"].UnformatValue != null)
			{
				formVO.Tonanhinkanri_no_to = paramCol["Tonanhinkanri_no_to"].UnformatValue;
			}
			if (paramCol["Jikohassei_ymd_from"].DateFullValue != null)
			{
				formVO.Jikohassei_ymd_from = paramCol["Jikohassei_ymd_from"].DateFullValue;
			}
			if (paramCol["Jikohassei_ymd_to"].DateFullValue != null)
			{
				formVO.Jikohassei_ymd_to = paramCol["Jikohassei_ymd_to"].DateFullValue;
			}
			if (paramCol["Hokoku_ymd_from"].DateFullValue != null)
			{
				formVO.Hokoku_ymd_from = paramCol["Hokoku_ymd_from"].DateFullValue;
			}
			if (paramCol["Hokoku_ymd_to"].DateFullValue != null)
			{
				formVO.Hokoku_ymd_to = paramCol["Hokoku_ymd_to"].DateFullValue;
			}
			if (paramCol["Hokokutan_cd"].UnformatValue != null)
			{
				formVO.Hokokutan_cd = paramCol["Hokokutan_cd"].UnformatValue;
			}
			if (paramCol["Hokokutan_nm"].UnformatValue != null)
			{
				formVO.Hokokutan_nm = paramCol["Hokokutan_nm"].UnformatValue;
			}
			if (paramCol["Keisatsutodoke_ymd_from"].DateFullValue != null)
			{
				formVO.Keisatsutodoke_ymd_from = paramCol["Keisatsutodoke_ymd_from"].DateFullValue;
			}
			if (paramCol["Keisatsutodoke_ymd_to"].DateFullValue != null)
			{
				formVO.Keisatsutodoke_ymd_to = paramCol["Keisatsutodoke_ymd_to"].DateFullValue;
			}
			if (paramCol["Jyuri_no_from"].UnformatValue != null)
			{
				formVO.Jyuri_no_from = paramCol["Jyuri_no_from"].UnformatValue;
			}
			if (paramCol["Jyuri_no_to"].UnformatValue != null)
			{
				formVO.Jyuri_no_to = paramCol["Jyuri_no_to"].UnformatValue;
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
				Tf070f01M1Form tf070f01M1Form = (Tf070f01M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					tf070f01M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1jikohassei_ymd"][i].DateFullValue != null)
				{
					tf070f01M1Form.M1jikohassei_ymd = paramCol["M1jikohassei_ymd"][i].DateFullValue;
				}
				if (paramCol["M1hokoku_ymd"][i].DateFullValue != null)
				{
					tf070f01M1Form.M1hokoku_ymd = paramCol["M1hokoku_ymd"][i].DateFullValue;
				}
				if (paramCol["M1hokokutan_nm"][i].UnformatValue != null)
				{
					tf070f01M1Form.M1hokokutan_nm = paramCol["M1hokokutan_nm"][i].UnformatValue;
				}
				if (paramCol["M1tentyotan_nm"][i].UnformatValue != null)
				{
					tf070f01M1Form.M1tentyotan_nm = paramCol["M1tentyotan_nm"][i].UnformatValue;
				}
				if (paramCol["M1keisatsutodoke_ymd"][i].DateFullValue != null)
				{
					tf070f01M1Form.M1keisatsutodoke_ymd = paramCol["M1keisatsutodoke_ymd"][i].DateFullValue;
				}
				if (paramCol["M1todokedesakikeisatsu_nm"][i].UnformatValue != null)
				{
					tf070f01M1Form.M1todokedesakikeisatsu_nm = paramCol["M1todokedesakikeisatsu_nm"][i].UnformatValue;
				}
				if (paramCol["M1jyuri_no"][i].UnformatValue != null)
				{
					tf070f01M1Form.M1jyuri_no = paramCol["M1jyuri_no"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					tf070f01M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					tf070f01M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					tf070f01M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Tf070f01Form formVO, StandardCheckManager checker)
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
			if (formVO.Tonanhinkanri_no_from != null)
			{
				checker.DoCheck("Tonanhinkanri_no_from", formVO.Tonanhinkanri_no_from);
			}
			if (formVO.Tonanhinkanri_no_to != null)
			{
				checker.DoCheck("Tonanhinkanri_no_to", formVO.Tonanhinkanri_no_to);
			}
			if (formVO.Jikohassei_ymd_from != null)
			{
				checker.DoCheck("Jikohassei_ymd_from", formVO.Jikohassei_ymd_from);
			}
			if (formVO.Jikohassei_ymd_to != null)
			{
				checker.DoCheck("Jikohassei_ymd_to", formVO.Jikohassei_ymd_to);
			}
			if (formVO.Hokoku_ymd_from != null)
			{
				checker.DoCheck("Hokoku_ymd_from", formVO.Hokoku_ymd_from);
			}
			if (formVO.Hokoku_ymd_to != null)
			{
				checker.DoCheck("Hokoku_ymd_to", formVO.Hokoku_ymd_to);
			}
			if (formVO.Hokokutan_cd != null)
			{
				checker.DoCheck("Hokokutan_cd", formVO.Hokokutan_cd);
			}
			if (formVO.Hokokutan_nm != null)
			{
				checker.DoCheck("Hokokutan_nm", formVO.Hokokutan_nm);
			}
			if (formVO.Keisatsutodoke_ymd_from != null)
			{
				checker.DoCheck("Keisatsutodoke_ymd_from", formVO.Keisatsutodoke_ymd_from);
			}
			if (formVO.Keisatsutodoke_ymd_to != null)
			{
				checker.DoCheck("Keisatsutodoke_ymd_to", formVO.Keisatsutodoke_ymd_to);
			}
			if (formVO.Jyuri_no_from != null)
			{
				checker.DoCheck("Jyuri_no_from", formVO.Jyuri_no_from);
			}
			if (formVO.Jyuri_no_to != null)
			{
				checker.DoCheck("Jyuri_no_to", formVO.Jyuri_no_to);
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
		public static void ValidateM1InputValue(Tf070f01Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Tf070f01M1Form tf070f01M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, tf070f01M1Form, i, m1List);
				if (tf070f01M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", tf070f01M1Form.M1rowno, i, m1List);
				}
				if (tf070f01M1Form.M1jikohassei_ymd != null)
				{
					checker.DoCheck("M1jikohassei_ymd", tf070f01M1Form.M1jikohassei_ymd, i, m1List);
				}
				if (tf070f01M1Form.M1hokoku_ymd != null)
				{
					checker.DoCheck("M1hokoku_ymd", tf070f01M1Form.M1hokoku_ymd, i, m1List);
				}
				if (tf070f01M1Form.M1hokokutan_nm != null)
				{
					checker.DoCheck("M1hokokutan_nm", tf070f01M1Form.M1hokokutan_nm, i, m1List);
				}
				if (tf070f01M1Form.M1tentyotan_nm != null)
				{
					checker.DoCheck("M1tentyotan_nm", tf070f01M1Form.M1tentyotan_nm, i, m1List);
				}
				if (tf070f01M1Form.M1keisatsutodoke_ymd != null)
				{
					checker.DoCheck("M1keisatsutodoke_ymd", tf070f01M1Form.M1keisatsutodoke_ymd, i, m1List);
				}
				if (tf070f01M1Form.M1todokedesakikeisatsu_nm != null)
				{
					checker.DoCheck("M1todokedesakikeisatsu_nm", tf070f01M1Form.M1todokedesakikeisatsu_nm, i, m1List);
				}
				if (tf070f01M1Form.M1jyuri_no != null)
				{
					checker.DoCheck("M1jyuri_no", tf070f01M1Form.M1jyuri_no, i, m1List);
				}
				if (tf070f01M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", tf070f01M1Form.M1selectorcheckbox, i, m1List);
				}
				if (tf070f01M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", tf070f01M1Form.M1entersyoriflg, i, m1List);
				}
				if (tf070f01M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", tf070f01M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Tf070f01Form formVO, StandardCodeCheckManager checker)
		{
			checker.DoCheck("Btnheadtenpocd", formVO);
			checker.DoCheck("Btntanto_cd", formVO);
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Tf070f01Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

