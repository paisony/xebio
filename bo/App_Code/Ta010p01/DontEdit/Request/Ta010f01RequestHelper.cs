using com.xebio.bo.Ta010p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Ta010p01.Request
{
  /// <summary>
  /// Ta010f01RequestHelper の概要の説明です。
  /// </summary>
  public static class Ta010f01RequestHelper
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
			Ta010f01Form formVO = (Ta010f01Form)pageContext.GetFormVO();

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
			paramCol["Kbn_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Kbn_cd"]);
			paramCol["Hattyu_ymd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hattyu_ymd_from"]);
			paramCol["Hattyu_ymd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hattyu_ymd_to"]);
			paramCol["Tantosya_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tantosya_cd"]);
			paramCol["Hanbaiin_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hanbaiin_nm"]);
			paramCol["Irairiyu_cd1"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Irairiyu_cd1"]);
			paramCol["Irairiyu_cd2"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Irairiyu_cd2"]);
			paramCol["Shinsei_flg"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Shinsei_flg"]);
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
				paramCol["M1hojuirai_kbn_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hojuirai_kbn_nm"]);
				paramCol["M1hattyu_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hattyu_ymd"]);
				paramCol["M1itemsu"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1itemsu"]);
				paramCol["M1genkakin"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1genkakin"]);
				paramCol["M1hanbaiin_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hanbaiin_nm"]);
				paramCol["M1irai_riyu"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1irai_riyu"]);
				paramCol["M1sinsei_jotainm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1sinsei_jotainm"]);
				paramCol["M1apply_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1apply_ymd"]);
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
			Ta010f01Form formVO = (Ta010f01Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Modeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Modeno"].RequestValue, formInfo["Modeno"]);
			paramCol["Stkmodeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Stkmodeno"].RequestValue, formInfo["Stkmodeno"]);
			paramCol["Kbn_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Kbn_cd"].RequestValue, formInfo["Kbn_cd"]);
			paramCol["Hattyu_ymd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hattyu_ymd_from"].RequestValue, formInfo["Hattyu_ymd_from"]);
			paramCol["Hattyu_ymd_from"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Hattyu_ymd_from"].RequestValue, formInfo["Hattyu_ymd_from"]);
			paramCol["Hattyu_ymd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hattyu_ymd_to"].RequestValue, formInfo["Hattyu_ymd_to"]);
			paramCol["Hattyu_ymd_to"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Hattyu_ymd_to"].RequestValue, formInfo["Hattyu_ymd_to"]);
			paramCol["Tantosya_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tantosya_cd"].RequestValue, formInfo["Tantosya_cd"]);
			paramCol["Hanbaiin_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hanbaiin_nm"].RequestValue, formInfo["Hanbaiin_nm"]);
			paramCol["Irairiyu_cd1"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Irairiyu_cd1"].RequestValue, formInfo["Irairiyu_cd1"]);
			paramCol["Irairiyu_cd2"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Irairiyu_cd2"].RequestValue, formInfo["Irairiyu_cd2"]);
			paramCol["Shinsei_flg"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Shinsei_flg"].RequestValue, formInfo["Shinsei_flg"]);
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
				paramCol["M1hojuirai_kbn_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hojuirai_kbn_nm"][i].RequestValue, formInfo["M1hojuirai_kbn_nm"]);
				paramCol["M1hattyu_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hattyu_ymd"][i].RequestValue, formInfo["M1hattyu_ymd"]);
				paramCol["M1hattyu_ymd"][i].DateFullValue = RequestParameterUtil.GetDateFullValue(
					paramCol["M1hattyu_ymd"][i].RequestValue, formInfo["M1hattyu_ymd"]);
				paramCol["M1itemsu"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1itemsu"][i].RequestValue, formInfo["M1itemsu"]);
				paramCol["M1genkakin"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1genkakin"][i].RequestValue, formInfo["M1genkakin"]);
				paramCol["M1hanbaiin_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hanbaiin_nm"][i].RequestValue, formInfo["M1hanbaiin_nm"]);
				paramCol["M1irai_riyu"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1irai_riyu"][i].RequestValue, formInfo["M1irai_riyu"]);
				paramCol["M1sinsei_jotainm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1sinsei_jotainm"][i].RequestValue, formInfo["M1sinsei_jotainm"]);
				paramCol["M1apply_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1apply_ymd"][i].RequestValue, formInfo["M1apply_ymd"]);
				paramCol["M1apply_ymd"][i].DateFullValue = RequestParameterUtil.GetDateFullValue(
					paramCol["M1apply_ymd"][i].RequestValue, formInfo["M1apply_ymd"]);
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
			Ta010f01Form formVO = (Ta010f01Form)pageContext.GetFormVO();

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
			if (paramCol["Kbn_cd"].UnformatValue != null)
			{
				formVO.Kbn_cd = paramCol["Kbn_cd"].UnformatValue;
			}
			if (paramCol["Hattyu_ymd_from"].DateFullValue != null)
			{
				formVO.Hattyu_ymd_from = paramCol["Hattyu_ymd_from"].DateFullValue;
			}
			if (paramCol["Hattyu_ymd_to"].DateFullValue != null)
			{
				formVO.Hattyu_ymd_to = paramCol["Hattyu_ymd_to"].DateFullValue;
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
			if (paramCol["Shinsei_flg"].UnformatValue != null)
			{
				formVO.Shinsei_flg = paramCol["Shinsei_flg"].UnformatValue;
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
				Ta010f01M1Form ta010f01M1Form = (Ta010f01M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					ta010f01M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1hojuirai_kbn_nm"][i].UnformatValue != null)
				{
					ta010f01M1Form.M1hojuirai_kbn_nm = paramCol["M1hojuirai_kbn_nm"][i].UnformatValue;
				}
				if (paramCol["M1hattyu_ymd"][i].DateFullValue != null)
				{
					ta010f01M1Form.M1hattyu_ymd = paramCol["M1hattyu_ymd"][i].DateFullValue;
				}
				if (paramCol["M1itemsu"][i].UnformatValue != null)
				{
					ta010f01M1Form.M1itemsu = paramCol["M1itemsu"][i].UnformatValue;
				}
				if (paramCol["M1genkakin"][i].UnformatValue != null)
				{
					ta010f01M1Form.M1genkakin = paramCol["M1genkakin"][i].UnformatValue;
				}
				if (paramCol["M1hanbaiin_nm"][i].UnformatValue != null)
				{
					ta010f01M1Form.M1hanbaiin_nm = paramCol["M1hanbaiin_nm"][i].UnformatValue;
				}
				if (paramCol["M1irai_riyu"][i].UnformatValue != null)
				{
					ta010f01M1Form.M1irai_riyu = paramCol["M1irai_riyu"][i].UnformatValue;
				}
				if (paramCol["M1sinsei_jotainm"][i].UnformatValue != null)
				{
					ta010f01M1Form.M1sinsei_jotainm = paramCol["M1sinsei_jotainm"][i].UnformatValue;
				}
				if (paramCol["M1apply_ymd"][i].DateFullValue != null)
				{
					ta010f01M1Form.M1apply_ymd = paramCol["M1apply_ymd"][i].DateFullValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					ta010f01M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					ta010f01M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					ta010f01M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Ta010f01Form formVO, StandardCheckManager checker)
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
			if (formVO.Kbn_cd != null)
			{
				checker.DoCheck("Kbn_cd", formVO.Kbn_cd);
			}
			if (formVO.Hattyu_ymd_from != null)
			{
				checker.DoCheck("Hattyu_ymd_from", formVO.Hattyu_ymd_from);
			}
			if (formVO.Hattyu_ymd_to != null)
			{
				checker.DoCheck("Hattyu_ymd_to", formVO.Hattyu_ymd_to);
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
			if (formVO.Shinsei_flg != null)
			{
				checker.DoCheck("Shinsei_flg", formVO.Shinsei_flg);
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
		public static void ValidateM1InputValue(Ta010f01Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Ta010f01M1Form ta010f01M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, ta010f01M1Form, i, m1List);
				if (ta010f01M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", ta010f01M1Form.M1rowno, i, m1List);
				}
				if (ta010f01M1Form.M1hojuirai_kbn_nm != null)
				{
					checker.DoCheck("M1hojuirai_kbn_nm", ta010f01M1Form.M1hojuirai_kbn_nm, i, m1List);
				}
				if (ta010f01M1Form.M1hattyu_ymd != null)
				{
					checker.DoCheck("M1hattyu_ymd", ta010f01M1Form.M1hattyu_ymd, i, m1List);
				}
				if (ta010f01M1Form.M1itemsu != null)
				{
					checker.DoCheck("M1itemsu", ta010f01M1Form.M1itemsu, i, m1List);
				}
				if (ta010f01M1Form.M1genkakin != null)
				{
					checker.DoCheck("M1genkakin", ta010f01M1Form.M1genkakin, i, m1List);
				}
				if (ta010f01M1Form.M1hanbaiin_nm != null)
				{
					checker.DoCheck("M1hanbaiin_nm", ta010f01M1Form.M1hanbaiin_nm, i, m1List);
				}
				if (ta010f01M1Form.M1irai_riyu != null)
				{
					checker.DoCheck("M1irai_riyu", ta010f01M1Form.M1irai_riyu, i, m1List);
				}
				if (ta010f01M1Form.M1sinsei_jotainm != null)
				{
					checker.DoCheck("M1sinsei_jotainm", ta010f01M1Form.M1sinsei_jotainm, i, m1List);
				}
				if (ta010f01M1Form.M1apply_ymd != null)
				{
					checker.DoCheck("M1apply_ymd", ta010f01M1Form.M1apply_ymd, i, m1List);
				}
				if (ta010f01M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", ta010f01M1Form.M1selectorcheckbox, i, m1List);
				}
				if (ta010f01M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", ta010f01M1Form.M1entersyoriflg, i, m1List);
				}
				if (ta010f01M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", ta010f01M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Ta010f01Form formVO, StandardCodeCheckManager checker)
		{
			checker.DoCheck("Btnheadtenpocd", formVO);
			checker.DoCheck("Btntanto_cd", formVO);
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Ta010f01Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

