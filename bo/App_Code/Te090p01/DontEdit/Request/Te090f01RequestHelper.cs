using com.xebio.bo.Te090p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Te090p01.Request
{
  /// <summary>
  /// Te090f01RequestHelper の概要の説明です。
  /// </summary>
  public static class Te090f01RequestHelper
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
			Te090f01Form formVO = (Te090f01Form)pageContext.GetFormVO();

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
			paramCol["Kaisya_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Kaisya_cd"]);
			paramCol["Kaisya_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Kaisya_nm"]);
			paramCol["Syukkaten_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Syukkaten_cd"]);
			paramCol["Syukkaten_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Syukkaten_nm"]);
			paramCol["Denpyo_bango_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Denpyo_bango_from"]);
			paramCol["Denpyo_bango_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Denpyo_bango_to"]);
			paramCol["Scm_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Scm_cd"]);
			paramCol["Syukka_ymd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Syukka_ymd_from"]);
			paramCol["Syukka_ymd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Syukka_ymd_to"]);
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
				paramCol["M1kaisyakana_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1kaisyakana_nm"]);
				paramCol["M1syukkaten_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1syukkaten_cd"]);
				paramCol["M1syukkaten_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1syukkaten_nm"]);
				paramCol["M1scm_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1scm_cd"]);
				paramCol["M1syukka_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1syukka_ymd"]);
				paramCol["M1jyuryo_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1jyuryo_ymd"]);
				paramCol["M1yotei_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1yotei_su"]);
				paramCol["M1kakutei_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1kakutei_su"]);
				paramCol["M1kyakucyu"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1kyakucyu"]);
				paramCol["M1negaki"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1negaki"]);
				paramCol["M1denpyo_jyotainm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1denpyo_jyotainm"]);
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
			Te090f01Form formVO = (Te090f01Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Modeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Modeno"].RequestValue, formInfo["Modeno"]);
			paramCol["Stkmodeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Stkmodeno"].RequestValue, formInfo["Stkmodeno"]);
			paramCol["Kaisya_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Kaisya_cd"].RequestValue, formInfo["Kaisya_cd"]);
			paramCol["Kaisya_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Kaisya_nm"].RequestValue, formInfo["Kaisya_nm"]);
			paramCol["Syukkaten_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Syukkaten_cd"].RequestValue, formInfo["Syukkaten_cd"]);
			paramCol["Syukkaten_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Syukkaten_nm"].RequestValue, formInfo["Syukkaten_nm"]);
			paramCol["Denpyo_bango_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Denpyo_bango_from"].RequestValue, formInfo["Denpyo_bango_from"]);
			paramCol["Denpyo_bango_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Denpyo_bango_to"].RequestValue, formInfo["Denpyo_bango_to"]);
			paramCol["Scm_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Scm_cd"].RequestValue, formInfo["Scm_cd"]);
			paramCol["Syukka_ymd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Syukka_ymd_from"].RequestValue, formInfo["Syukka_ymd_from"]);
			paramCol["Syukka_ymd_from"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Syukka_ymd_from"].RequestValue, formInfo["Syukka_ymd_from"]);
			paramCol["Syukka_ymd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Syukka_ymd_to"].RequestValue, formInfo["Syukka_ymd_to"]);
			paramCol["Syukka_ymd_to"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Syukka_ymd_to"].RequestValue, formInfo["Syukka_ymd_to"]);
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
				paramCol["M1kaisyakana_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1kaisyakana_nm"][i].RequestValue, formInfo["M1kaisyakana_nm"]);
				paramCol["M1syukkaten_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1syukkaten_cd"][i].RequestValue, formInfo["M1syukkaten_cd"]);
				paramCol["M1syukkaten_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1syukkaten_nm"][i].RequestValue, formInfo["M1syukkaten_nm"]);
				paramCol["M1scm_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1scm_cd"][i].RequestValue, formInfo["M1scm_cd"]);
				paramCol["M1syukka_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1syukka_ymd"][i].RequestValue, formInfo["M1syukka_ymd"]);
				paramCol["M1syukka_ymd"][i].DateFullValue = RequestParameterUtil.GetDateFullValue(
					paramCol["M1syukka_ymd"][i].RequestValue, formInfo["M1syukka_ymd"]);
				paramCol["M1jyuryo_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1jyuryo_ymd"][i].RequestValue, formInfo["M1jyuryo_ymd"]);
				paramCol["M1jyuryo_ymd"][i].DateFullValue = RequestParameterUtil.GetDateFullValue(
					paramCol["M1jyuryo_ymd"][i].RequestValue, formInfo["M1jyuryo_ymd"]);
				paramCol["M1yotei_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1yotei_su"][i].RequestValue, formInfo["M1yotei_su"]);
				paramCol["M1kakutei_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1kakutei_su"][i].RequestValue, formInfo["M1kakutei_su"]);
				paramCol["M1kyakucyu"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1kyakucyu"][i].RequestValue, formInfo["M1kyakucyu"]);
				paramCol["M1negaki"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1negaki"][i].RequestValue, formInfo["M1negaki"]);
				paramCol["M1denpyo_jyotainm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1denpyo_jyotainm"][i].RequestValue, formInfo["M1denpyo_jyotainm"]);
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
			Te090f01Form formVO = (Te090f01Form)pageContext.GetFormVO();

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
			if (paramCol["Kaisya_cd"].UnformatValue != null)
			{
				formVO.Kaisya_cd = paramCol["Kaisya_cd"].UnformatValue;
			}
			if (paramCol["Kaisya_nm"].UnformatValue != null)
			{
				formVO.Kaisya_nm = paramCol["Kaisya_nm"].UnformatValue;
			}
			if (paramCol["Syukkaten_cd"].UnformatValue != null)
			{
				formVO.Syukkaten_cd = paramCol["Syukkaten_cd"].UnformatValue;
			}
			if (paramCol["Syukkaten_nm"].UnformatValue != null)
			{
				formVO.Syukkaten_nm = paramCol["Syukkaten_nm"].UnformatValue;
			}
			if (paramCol["Denpyo_bango_from"].UnformatValue != null)
			{
				formVO.Denpyo_bango_from = paramCol["Denpyo_bango_from"].UnformatValue;
			}
			if (paramCol["Denpyo_bango_to"].UnformatValue != null)
			{
				formVO.Denpyo_bango_to = paramCol["Denpyo_bango_to"].UnformatValue;
			}
			if (paramCol["Scm_cd"].UnformatValue != null)
			{
				formVO.Scm_cd = paramCol["Scm_cd"].UnformatValue;
			}
			if (paramCol["Syukka_ymd_from"].DateFullValue != null)
			{
				formVO.Syukka_ymd_from = paramCol["Syukka_ymd_from"].DateFullValue;
			}
			if (paramCol["Syukka_ymd_to"].DateFullValue != null)
			{
				formVO.Syukka_ymd_to = paramCol["Syukka_ymd_to"].DateFullValue;
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
				Te090f01M1Form te090f01M1Form = (Te090f01M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					te090f01M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1kaisyakana_nm"][i].UnformatValue != null)
				{
					te090f01M1Form.M1kaisyakana_nm = paramCol["M1kaisyakana_nm"][i].UnformatValue;
				}
				if (paramCol["M1syukkaten_cd"][i].UnformatValue != null)
				{
					te090f01M1Form.M1syukkaten_cd = paramCol["M1syukkaten_cd"][i].UnformatValue;
				}
				if (paramCol["M1syukkaten_nm"][i].UnformatValue != null)
				{
					te090f01M1Form.M1syukkaten_nm = paramCol["M1syukkaten_nm"][i].UnformatValue;
				}
				if (paramCol["M1scm_cd"][i].UnformatValue != null)
				{
					te090f01M1Form.M1scm_cd = paramCol["M1scm_cd"][i].UnformatValue;
				}
				if (paramCol["M1syukka_ymd"][i].DateFullValue != null)
				{
					te090f01M1Form.M1syukka_ymd = paramCol["M1syukka_ymd"][i].DateFullValue;
				}
				if (paramCol["M1jyuryo_ymd"][i].DateFullValue != null)
				{
					te090f01M1Form.M1jyuryo_ymd = paramCol["M1jyuryo_ymd"][i].DateFullValue;
				}
				if (paramCol["M1yotei_su"][i].UnformatValue != null)
				{
					te090f01M1Form.M1yotei_su = paramCol["M1yotei_su"][i].UnformatValue;
				}
				if (paramCol["M1kakutei_su"][i].UnformatValue != null)
				{
					te090f01M1Form.M1kakutei_su = paramCol["M1kakutei_su"][i].UnformatValue;
				}
				if (paramCol["M1kyakucyu"][i].UnformatValue != null)
				{
					te090f01M1Form.M1kyakucyu = paramCol["M1kyakucyu"][i].UnformatValue;
				}
				if (paramCol["M1negaki"][i].UnformatValue != null)
				{
					te090f01M1Form.M1negaki = paramCol["M1negaki"][i].UnformatValue;
				}
				if (paramCol["M1denpyo_jyotainm"][i].UnformatValue != null)
				{
					te090f01M1Form.M1denpyo_jyotainm = paramCol["M1denpyo_jyotainm"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					te090f01M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					te090f01M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					te090f01M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Te090f01Form formVO, StandardCheckManager checker)
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
			if (formVO.Kaisya_cd != null)
			{
				checker.DoCheck("Kaisya_cd", formVO.Kaisya_cd);
			}
			if (formVO.Kaisya_nm != null)
			{
				checker.DoCheck("Kaisya_nm", formVO.Kaisya_nm);
			}
			if (formVO.Syukkaten_cd != null)
			{
				checker.DoCheck("Syukkaten_cd", formVO.Syukkaten_cd);
			}
			if (formVO.Syukkaten_nm != null)
			{
				checker.DoCheck("Syukkaten_nm", formVO.Syukkaten_nm);
			}
			if (formVO.Denpyo_bango_from != null)
			{
				checker.DoCheck("Denpyo_bango_from", formVO.Denpyo_bango_from);
			}
			if (formVO.Denpyo_bango_to != null)
			{
				checker.DoCheck("Denpyo_bango_to", formVO.Denpyo_bango_to);
			}
			if (formVO.Scm_cd != null)
			{
				checker.DoCheck("Scm_cd", formVO.Scm_cd);
			}
			if (formVO.Syukka_ymd_from != null)
			{
				checker.DoCheck("Syukka_ymd_from", formVO.Syukka_ymd_from);
			}
			if (formVO.Syukka_ymd_to != null)
			{
				checker.DoCheck("Syukka_ymd_to", formVO.Syukka_ymd_to);
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
		public static void ValidateM1InputValue(Te090f01Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Te090f01M1Form te090f01M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, te090f01M1Form, i, m1List);
				if (te090f01M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", te090f01M1Form.M1rowno, i, m1List);
				}
				if (te090f01M1Form.M1kaisyakana_nm != null)
				{
					checker.DoCheck("M1kaisyakana_nm", te090f01M1Form.M1kaisyakana_nm, i, m1List);
				}
				if (te090f01M1Form.M1syukkaten_cd != null)
				{
					checker.DoCheck("M1syukkaten_cd", te090f01M1Form.M1syukkaten_cd, i, m1List);
				}
				if (te090f01M1Form.M1syukkaten_nm != null)
				{
					checker.DoCheck("M1syukkaten_nm", te090f01M1Form.M1syukkaten_nm, i, m1List);
				}
				if (te090f01M1Form.M1scm_cd != null)
				{
					checker.DoCheck("M1scm_cd", te090f01M1Form.M1scm_cd, i, m1List);
				}
				if (te090f01M1Form.M1syukka_ymd != null)
				{
					checker.DoCheck("M1syukka_ymd", te090f01M1Form.M1syukka_ymd, i, m1List);
				}
				if (te090f01M1Form.M1jyuryo_ymd != null)
				{
					checker.DoCheck("M1jyuryo_ymd", te090f01M1Form.M1jyuryo_ymd, i, m1List);
				}
				if (te090f01M1Form.M1yotei_su != null)
				{
					checker.DoCheck("M1yotei_su", te090f01M1Form.M1yotei_su, i, m1List);
				}
				if (te090f01M1Form.M1kakutei_su != null)
				{
					checker.DoCheck("M1kakutei_su", te090f01M1Form.M1kakutei_su, i, m1List);
				}
				if (te090f01M1Form.M1kyakucyu != null)
				{
					checker.DoCheck("M1kyakucyu", te090f01M1Form.M1kyakucyu, i, m1List);
				}
				if (te090f01M1Form.M1negaki != null)
				{
					checker.DoCheck("M1negaki", te090f01M1Form.M1negaki, i, m1List);
				}
				if (te090f01M1Form.M1denpyo_jyotainm != null)
				{
					checker.DoCheck("M1denpyo_jyotainm", te090f01M1Form.M1denpyo_jyotainm, i, m1List);
				}
				if (te090f01M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", te090f01M1Form.M1selectorcheckbox, i, m1List);
				}
				if (te090f01M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", te090f01M1Form.M1entersyoriflg, i, m1List);
				}
				if (te090f01M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", te090f01M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Te090f01Form formVO, StandardCodeCheckManager checker)
		{
			checker.DoCheck("Btnheadtenpocd", formVO);
			checker.DoCheck("Btnkaisha_cd", formVO);
			checker.DoCheck("Btnsyukkatencd", formVO);
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Te090f01Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

