using com.xebio.bo.Ta060p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Ta060p01.Request
{
  /// <summary>
  /// Ta060f01RequestHelper の概要の説明です。
  /// </summary>
  public static class Ta060f01RequestHelper
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
			Ta060f01Form formVO = (Ta060f01Form)pageContext.GetFormVO();

			//カード部を初期化する
			paramCol.InitCardItems(formInfo.GetCardItems());
			//明細「M1」部を初期化する
			paramCol.InitListItems(formInfo.GetListItems("M1"), formVO.GetList("M1").CurrentCount);
			//カード項目の入力値を取得する
			paramCol["Head_tenpo_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_nm"]);
			paramCol["Henko_kbn"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Henko_kbn"]);
			paramCol["Bumon_cd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_cd_from"]);
			paramCol["Bumon_nm_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_nm_from"]);
			paramCol["Bumon_cd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_cd_to"]);
			paramCol["Bumon_nm_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_nm_to"]);
			paramCol["Kessai_ymd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Kessai_ymd_from"]);
			paramCol["Kessai_ymd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Kessai_ymd_to"]);
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
				paramCol["M1henko_kbn_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1henko_kbn_nm"]);
				paramCol["M1irai_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1irai_su"]);
				paramCol["M1genkakin"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1genkakin"]);
				paramCol["M1kessai_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1kessai_ymd"]);
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
			Ta060f01Form formVO = (Ta060f01Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Henko_kbn"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Henko_kbn"].RequestValue, formInfo["Henko_kbn"]);
			paramCol["Bumon_cd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_cd_from"].RequestValue, formInfo["Bumon_cd_from"]);
			paramCol["Bumon_nm_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_nm_from"].RequestValue, formInfo["Bumon_nm_from"]);
			paramCol["Bumon_cd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_cd_to"].RequestValue, formInfo["Bumon_cd_to"]);
			paramCol["Bumon_nm_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_nm_to"].RequestValue, formInfo["Bumon_nm_to"]);
			paramCol["Kessai_ymd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Kessai_ymd_from"].RequestValue, formInfo["Kessai_ymd_from"]);
			paramCol["Kessai_ymd_from"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Kessai_ymd_from"].RequestValue, formInfo["Kessai_ymd_from"]);
			paramCol["Kessai_ymd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Kessai_ymd_to"].RequestValue, formInfo["Kessai_ymd_to"]);
			paramCol["Kessai_ymd_to"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Kessai_ymd_to"].RequestValue, formInfo["Kessai_ymd_to"]);
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
				paramCol["M1henko_kbn_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1henko_kbn_nm"][i].RequestValue, formInfo["M1henko_kbn_nm"]);
				paramCol["M1irai_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1irai_su"][i].RequestValue, formInfo["M1irai_su"]);
				paramCol["M1genkakin"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1genkakin"][i].RequestValue, formInfo["M1genkakin"]);
				paramCol["M1kessai_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1kessai_ymd"][i].RequestValue, formInfo["M1kessai_ymd"]);
				paramCol["M1kessai_ymd"][i].DateFullValue = RequestParameterUtil.GetDateFullValue(
					paramCol["M1kessai_ymd"][i].RequestValue, formInfo["M1kessai_ymd"]);
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
			Ta060f01Form formVO = (Ta060f01Form)pageContext.GetFormVO();

			//カード項目の入力値をFormVOにコピーする
			if (paramCol["Head_tenpo_cd"].UnformatValue != null)
			{
				formVO.Head_tenpo_cd = paramCol["Head_tenpo_cd"].UnformatValue;
			}
			if (paramCol["Head_tenpo_nm"].UnformatValue != null)
			{
				formVO.Head_tenpo_nm = paramCol["Head_tenpo_nm"].UnformatValue;
			}
			if (paramCol["Henko_kbn"].UnformatValue != null)
			{
				formVO.Henko_kbn = paramCol["Henko_kbn"].UnformatValue;
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
			if (paramCol["Kessai_ymd_from"].DateFullValue != null)
			{
				formVO.Kessai_ymd_from = paramCol["Kessai_ymd_from"].DateFullValue;
			}
			if (paramCol["Kessai_ymd_to"].DateFullValue != null)
			{
				formVO.Kessai_ymd_to = paramCol["Kessai_ymd_to"].DateFullValue;
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
				Ta060f01M1Form ta060f01M1Form = (Ta060f01M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					ta060f01M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1henko_kbn_nm"][i].UnformatValue != null)
				{
					ta060f01M1Form.M1henko_kbn_nm = paramCol["M1henko_kbn_nm"][i].UnformatValue;
				}
				if (paramCol["M1irai_su"][i].UnformatValue != null)
				{
					ta060f01M1Form.M1irai_su = paramCol["M1irai_su"][i].UnformatValue;
				}
				if (paramCol["M1genkakin"][i].UnformatValue != null)
				{
					ta060f01M1Form.M1genkakin = paramCol["M1genkakin"][i].UnformatValue;
				}
				if (paramCol["M1kessai_ymd"][i].DateFullValue != null)
				{
					ta060f01M1Form.M1kessai_ymd = paramCol["M1kessai_ymd"][i].DateFullValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					ta060f01M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					ta060f01M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					ta060f01M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Ta060f01Form formVO, StandardCheckManager checker)
		{
			if (formVO.Head_tenpo_cd != null)
			{
				checker.DoCheck("Head_tenpo_cd", formVO.Head_tenpo_cd);
			}
			if (formVO.Head_tenpo_nm != null)
			{
				checker.DoCheck("Head_tenpo_nm", formVO.Head_tenpo_nm);
			}
			if (formVO.Henko_kbn != null)
			{
				checker.DoCheck("Henko_kbn", formVO.Henko_kbn);
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
			if (formVO.Kessai_ymd_from != null)
			{
				checker.DoCheck("Kessai_ymd_from", formVO.Kessai_ymd_from);
			}
			if (formVO.Kessai_ymd_to != null)
			{
				checker.DoCheck("Kessai_ymd_to", formVO.Kessai_ymd_to);
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
		public static void ValidateM1InputValue(Ta060f01Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Ta060f01M1Form ta060f01M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, ta060f01M1Form, i, m1List);
				if (ta060f01M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", ta060f01M1Form.M1rowno, i, m1List);
				}
				if (ta060f01M1Form.M1henko_kbn_nm != null)
				{
					checker.DoCheck("M1henko_kbn_nm", ta060f01M1Form.M1henko_kbn_nm, i, m1List);
				}
				if (ta060f01M1Form.M1irai_su != null)
				{
					checker.DoCheck("M1irai_su", ta060f01M1Form.M1irai_su, i, m1List);
				}
				if (ta060f01M1Form.M1genkakin != null)
				{
					checker.DoCheck("M1genkakin", ta060f01M1Form.M1genkakin, i, m1List);
				}
				if (ta060f01M1Form.M1kessai_ymd != null)
				{
					checker.DoCheck("M1kessai_ymd", ta060f01M1Form.M1kessai_ymd, i, m1List);
				}
				if (ta060f01M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", ta060f01M1Form.M1selectorcheckbox, i, m1List);
				}
				if (ta060f01M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", ta060f01M1Form.M1entersyoriflg, i, m1List);
				}
				if (ta060f01M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", ta060f01M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Ta060f01Form formVO, StandardCodeCheckManager checker)
		{
			checker.DoCheck("Btnheadtenpocd", formVO);
			checker.DoCheck("Btnbumon_cd_from", formVO);
			checker.DoCheck("Btnbumon_cd_to", formVO);
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Ta060f01Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

