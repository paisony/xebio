using com.xebio.bo.Tj080p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Tj080p01.Request
{
  /// <summary>
  /// Tj080f01RequestHelper の概要の説明です。
  /// </summary>
  public static class Tj080f01RequestHelper
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
			Tj080f01Form formVO = (Tj080f01Form)pageContext.GetFormVO();

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
			paramCol["Tenpo_cd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tenpo_cd_from"]);
			paramCol["Tenpo_nm_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tenpo_nm_from"]);
			paramCol["Tenpo_cd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tenpo_cd_to"]);
			paramCol["Tenpo_nm_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tenpo_nm_to"]);
			paramCol["Tenpo_kakutei_jyokyo"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tenpo_kakutei_jyokyo"]);
			paramCol["Sosin_jyotai"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Sosin_jyotai"]);
			paramCol["Sosin_ymd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Sosin_ymd_from"]);
			paramCol["Sosin_ymd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Sosin_ymd_to"]);
			paramCol["Konkai_flg"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Konkai_flg"]);
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
				paramCol["M1tenpo_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tenpo_cd"]);
				paramCol["M1tenpo_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tenpo_nm"]);
				paramCol["M1sosin_kak_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1sosin_kak_ymd"]);
				paramCol["M1tenpo_kakutei_jyokyo"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tenpo_kakutei_jyokyo"]);
				paramCol["M1tenpo_kakutei_jyokyo_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tenpo_kakutei_jyokyo_nm"]);
				paramCol["M1md_sosin_jyokyo"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1md_sosin_jyokyo"]);
				paramCol["M1md_sosin_jyokyo_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1md_sosin_jyokyo_nm"]);
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
			Tj080f01Form formVO = (Tj080f01Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Modeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Modeno"].RequestValue, formInfo["Modeno"]);
			paramCol["Stkmodeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Stkmodeno"].RequestValue, formInfo["Stkmodeno"]);
			paramCol["Tenpo_cd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tenpo_cd_from"].RequestValue, formInfo["Tenpo_cd_from"]);
			paramCol["Tenpo_nm_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tenpo_nm_from"].RequestValue, formInfo["Tenpo_nm_from"]);
			paramCol["Tenpo_cd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tenpo_cd_to"].RequestValue, formInfo["Tenpo_cd_to"]);
			paramCol["Tenpo_nm_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tenpo_nm_to"].RequestValue, formInfo["Tenpo_nm_to"]);
			paramCol["Tenpo_kakutei_jyokyo"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tenpo_kakutei_jyokyo"].RequestValue, formInfo["Tenpo_kakutei_jyokyo"]);
			paramCol["Sosin_jyotai"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Sosin_jyotai"].RequestValue, formInfo["Sosin_jyotai"]);
			paramCol["Sosin_ymd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Sosin_ymd_from"].RequestValue, formInfo["Sosin_ymd_from"]);
			paramCol["Sosin_ymd_from"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Sosin_ymd_from"].RequestValue, formInfo["Sosin_ymd_from"]);
			paramCol["Sosin_ymd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Sosin_ymd_to"].RequestValue, formInfo["Sosin_ymd_to"]);
			paramCol["Sosin_ymd_to"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Sosin_ymd_to"].RequestValue, formInfo["Sosin_ymd_to"]);
			paramCol["Konkai_flg"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Konkai_flg"].RequestValue, formInfo["Konkai_flg"]);
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
				paramCol["M1tenpo_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tenpo_cd"][i].RequestValue, formInfo["M1tenpo_cd"]);
				paramCol["M1tenpo_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tenpo_nm"][i].RequestValue, formInfo["M1tenpo_nm"]);
				paramCol["M1sosin_kak_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1sosin_kak_ymd"][i].RequestValue, formInfo["M1sosin_kak_ymd"]);
				paramCol["M1sosin_kak_ymd"][i].DateFullValue = RequestParameterUtil.GetDateFullValue(
					paramCol["M1sosin_kak_ymd"][i].RequestValue, formInfo["M1sosin_kak_ymd"]);
				paramCol["M1tenpo_kakutei_jyokyo"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tenpo_kakutei_jyokyo"][i].RequestValue, formInfo["M1tenpo_kakutei_jyokyo"]);
				paramCol["M1tenpo_kakutei_jyokyo_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tenpo_kakutei_jyokyo_nm"][i].RequestValue, formInfo["M1tenpo_kakutei_jyokyo_nm"]);
				paramCol["M1md_sosin_jyokyo"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1md_sosin_jyokyo"][i].RequestValue, formInfo["M1md_sosin_jyokyo"]);
				paramCol["M1md_sosin_jyokyo_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1md_sosin_jyokyo_nm"][i].RequestValue, formInfo["M1md_sosin_jyokyo_nm"]);
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
			Tj080f01Form formVO = (Tj080f01Form)pageContext.GetFormVO();

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
			if (paramCol["Tenpo_kakutei_jyokyo"].UnformatValue != null)
			{
				formVO.Tenpo_kakutei_jyokyo = paramCol["Tenpo_kakutei_jyokyo"].UnformatValue;
			}
			if (paramCol["Sosin_jyotai"].UnformatValue != null)
			{
				formVO.Sosin_jyotai = paramCol["Sosin_jyotai"].UnformatValue;
			}
			if (paramCol["Sosin_ymd_from"].DateFullValue != null)
			{
				formVO.Sosin_ymd_from = paramCol["Sosin_ymd_from"].DateFullValue;
			}
			if (paramCol["Sosin_ymd_to"].DateFullValue != null)
			{
				formVO.Sosin_ymd_to = paramCol["Sosin_ymd_to"].DateFullValue;
			}
			if (paramCol["Konkai_flg"].UnformatValue != null)
			{
				formVO.Konkai_flg = paramCol["Konkai_flg"].UnformatValue;
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
				Tj080f01M1Form tj080f01M1Form = (Tj080f01M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					tj080f01M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1tenpo_cd"][i].UnformatValue != null)
				{
					tj080f01M1Form.M1tenpo_cd = paramCol["M1tenpo_cd"][i].UnformatValue;
				}
				if (paramCol["M1tenpo_nm"][i].UnformatValue != null)
				{
					tj080f01M1Form.M1tenpo_nm = paramCol["M1tenpo_nm"][i].UnformatValue;
				}
				if (paramCol["M1sosin_kak_ymd"][i].DateFullValue != null)
				{
					tj080f01M1Form.M1sosin_kak_ymd = paramCol["M1sosin_kak_ymd"][i].DateFullValue;
				}
				if (paramCol["M1tenpo_kakutei_jyokyo"][i].UnformatValue != null)
				{
					tj080f01M1Form.M1tenpo_kakutei_jyokyo = paramCol["M1tenpo_kakutei_jyokyo"][i].UnformatValue;
				}
				if (paramCol["M1tenpo_kakutei_jyokyo_nm"][i].UnformatValue != null)
				{
					tj080f01M1Form.M1tenpo_kakutei_jyokyo_nm = paramCol["M1tenpo_kakutei_jyokyo_nm"][i].UnformatValue;
				}
				if (paramCol["M1md_sosin_jyokyo"][i].UnformatValue != null)
				{
					tj080f01M1Form.M1md_sosin_jyokyo = paramCol["M1md_sosin_jyokyo"][i].UnformatValue;
				}
				if (paramCol["M1md_sosin_jyokyo_nm"][i].UnformatValue != null)
				{
					tj080f01M1Form.M1md_sosin_jyokyo_nm = paramCol["M1md_sosin_jyokyo_nm"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					tj080f01M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					tj080f01M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					tj080f01M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Tj080f01Form formVO, StandardCheckManager checker)
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
			if (formVO.Tenpo_kakutei_jyokyo != null)
			{
				checker.DoCheck("Tenpo_kakutei_jyokyo", formVO.Tenpo_kakutei_jyokyo);
			}
			if (formVO.Sosin_jyotai != null)
			{
				checker.DoCheck("Sosin_jyotai", formVO.Sosin_jyotai);
			}
			if (formVO.Sosin_ymd_from != null)
			{
				checker.DoCheck("Sosin_ymd_from", formVO.Sosin_ymd_from);
			}
			if (formVO.Sosin_ymd_to != null)
			{
				checker.DoCheck("Sosin_ymd_to", formVO.Sosin_ymd_to);
			}
			if (formVO.Konkai_flg != null)
			{
				checker.DoCheck("Konkai_flg", formVO.Konkai_flg);
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
		public static void ValidateM1InputValue(Tj080f01Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Tj080f01M1Form tj080f01M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, tj080f01M1Form, i, m1List);
				if (tj080f01M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", tj080f01M1Form.M1rowno, i, m1List);
				}
				if (tj080f01M1Form.M1tenpo_cd != null)
				{
					checker.DoCheck("M1tenpo_cd", tj080f01M1Form.M1tenpo_cd, i, m1List);
				}
				if (tj080f01M1Form.M1tenpo_nm != null)
				{
					checker.DoCheck("M1tenpo_nm", tj080f01M1Form.M1tenpo_nm, i, m1List);
				}
				if (tj080f01M1Form.M1sosin_kak_ymd != null)
				{
					checker.DoCheck("M1sosin_kak_ymd", tj080f01M1Form.M1sosin_kak_ymd, i, m1List);
				}
				if (tj080f01M1Form.M1tenpo_kakutei_jyokyo != null)
				{
					checker.DoCheck("M1tenpo_kakutei_jyokyo", tj080f01M1Form.M1tenpo_kakutei_jyokyo, i, m1List);
				}
				if (tj080f01M1Form.M1tenpo_kakutei_jyokyo_nm != null)
				{
					checker.DoCheck("M1tenpo_kakutei_jyokyo_nm", tj080f01M1Form.M1tenpo_kakutei_jyokyo_nm, i, m1List);
				}
				if (tj080f01M1Form.M1md_sosin_jyokyo != null)
				{
					checker.DoCheck("M1md_sosin_jyokyo", tj080f01M1Form.M1md_sosin_jyokyo, i, m1List);
				}
				if (tj080f01M1Form.M1md_sosin_jyokyo_nm != null)
				{
					checker.DoCheck("M1md_sosin_jyokyo_nm", tj080f01M1Form.M1md_sosin_jyokyo_nm, i, m1List);
				}
				if (tj080f01M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", tj080f01M1Form.M1selectorcheckbox, i, m1List);
				}
				if (tj080f01M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", tj080f01M1Form.M1entersyoriflg, i, m1List);
				}
				if (tj080f01M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", tj080f01M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Tj080f01Form formVO, StandardCodeCheckManager checker)
		{
			checker.DoCheck("Btnheadtenpocd", formVO);
			checker.DoCheck("Btntenpocd_from", formVO);
			checker.DoCheck("Btntenpocd_to", formVO);
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Tj080f01Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

