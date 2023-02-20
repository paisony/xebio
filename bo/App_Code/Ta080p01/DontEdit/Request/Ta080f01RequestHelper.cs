using com.xebio.bo.Ta080p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Ta080p01.Request
{
  /// <summary>
  /// Ta080f01RequestHelper の概要の説明です。
  /// </summary>
  public static class Ta080f01RequestHelper
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
			Ta080f01Form formVO = (Ta080f01Form)pageContext.GetFormVO();

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
			paramCol["Yosan_ymd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Yosan_ymd_from"]);
			paramCol["Yosan_ymd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Yosan_ymd_to"]);
			paramCol["Yosan_cd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Yosan_cd_from"]);
			paramCol["Yosan_nm_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Yosan_nm_from"]);
			paramCol["Yosan_cd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Yosan_cd_to"]);
			paramCol["Yosan_nm_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Yosan_nm_to"]);
			paramCol["Add_ymd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Add_ymd_from"]);
			paramCol["Add_ymd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Add_ymd_to"]);
			paramCol["Tantosya_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tantosya_cd"]);
			paramCol["Hanbaiin_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hanbaiin_nm"]);
			paramCol["Apply_ymd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Apply_ymd_from"]);
			paramCol["Apply_ymd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Apply_ymd_to"]);
			paramCol["Sinsei_sb"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Sinsei_sb"]);
			paramCol["Irairiyu_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Irairiyu_cd"]);
			paramCol["Irairiyu_cd1"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Irairiyu_cd1"]);
			paramCol["Jotai_kbn"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Jotai_kbn"]);
			paramCol["Old_jisya_hbn"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Old_jisya_hbn"]);
			paramCol["Maker_hbn"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Maker_hbn"]);
			paramCol["Scan_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Scan_cd"]);
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
			Ta080f01Form formVO = (Ta080f01Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Modeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Modeno"].RequestValue, formInfo["Modeno"]);
			paramCol["Stkmodeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Stkmodeno"].RequestValue, formInfo["Stkmodeno"]);
			paramCol["Yosan_ymd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Yosan_ymd_from"].RequestValue, formInfo["Yosan_ymd_from"]);
			paramCol["Yosan_ymd_from"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Yosan_ymd_from"].RequestValue, formInfo["Yosan_ymd_from"]);
			paramCol["Yosan_ymd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Yosan_ymd_to"].RequestValue, formInfo["Yosan_ymd_to"]);
			paramCol["Yosan_ymd_to"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Yosan_ymd_to"].RequestValue, formInfo["Yosan_ymd_to"]);
			paramCol["Yosan_cd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Yosan_cd_from"].RequestValue, formInfo["Yosan_cd_from"]);
			paramCol["Yosan_nm_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Yosan_nm_from"].RequestValue, formInfo["Yosan_nm_from"]);
			paramCol["Yosan_cd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Yosan_cd_to"].RequestValue, formInfo["Yosan_cd_to"]);
			paramCol["Yosan_nm_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Yosan_nm_to"].RequestValue, formInfo["Yosan_nm_to"]);
			paramCol["Add_ymd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Add_ymd_from"].RequestValue, formInfo["Add_ymd_from"]);
			paramCol["Add_ymd_from"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Add_ymd_from"].RequestValue, formInfo["Add_ymd_from"]);
			paramCol["Add_ymd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Add_ymd_to"].RequestValue, formInfo["Add_ymd_to"]);
			paramCol["Add_ymd_to"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Add_ymd_to"].RequestValue, formInfo["Add_ymd_to"]);
			paramCol["Tantosya_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tantosya_cd"].RequestValue, formInfo["Tantosya_cd"]);
			paramCol["Hanbaiin_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hanbaiin_nm"].RequestValue, formInfo["Hanbaiin_nm"]);
			paramCol["Apply_ymd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Apply_ymd_from"].RequestValue, formInfo["Apply_ymd_from"]);
			paramCol["Apply_ymd_from"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Apply_ymd_from"].RequestValue, formInfo["Apply_ymd_from"]);
			paramCol["Apply_ymd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Apply_ymd_to"].RequestValue, formInfo["Apply_ymd_to"]);
			paramCol["Apply_ymd_to"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Apply_ymd_to"].RequestValue, formInfo["Apply_ymd_to"]);
			paramCol["Sinsei_sb"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Sinsei_sb"].RequestValue, formInfo["Sinsei_sb"]);
			paramCol["Irairiyu_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Irairiyu_cd"].RequestValue, formInfo["Irairiyu_cd"]);
			paramCol["Irairiyu_cd1"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Irairiyu_cd1"].RequestValue, formInfo["Irairiyu_cd1"]);
			paramCol["Jotai_kbn"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Jotai_kbn"].RequestValue, formInfo["Jotai_kbn"]);
			paramCol["Old_jisya_hbn"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Old_jisya_hbn"].RequestValue, formInfo["Old_jisya_hbn"]);
			paramCol["Maker_hbn"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Maker_hbn"].RequestValue, formInfo["Maker_hbn"]);
			paramCol["Scan_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Scan_cd"].RequestValue, formInfo["Scan_cd"]);
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
			Ta080f01Form formVO = (Ta080f01Form)pageContext.GetFormVO();

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
			if (paramCol["Yosan_ymd_from"].DateFullValue != null)
			{
				formVO.Yosan_ymd_from = paramCol["Yosan_ymd_from"].DateFullValue;
			}
			if (paramCol["Yosan_ymd_to"].DateFullValue != null)
			{
				formVO.Yosan_ymd_to = paramCol["Yosan_ymd_to"].DateFullValue;
			}
			if (paramCol["Yosan_cd_from"].UnformatValue != null)
			{
				formVO.Yosan_cd_from = paramCol["Yosan_cd_from"].UnformatValue;
			}
			if (paramCol["Yosan_nm_from"].UnformatValue != null)
			{
				formVO.Yosan_nm_from = paramCol["Yosan_nm_from"].UnformatValue;
			}
			if (paramCol["Yosan_cd_to"].UnformatValue != null)
			{
				formVO.Yosan_cd_to = paramCol["Yosan_cd_to"].UnformatValue;
			}
			if (paramCol["Yosan_nm_to"].UnformatValue != null)
			{
				formVO.Yosan_nm_to = paramCol["Yosan_nm_to"].UnformatValue;
			}
			if (paramCol["Add_ymd_from"].DateFullValue != null)
			{
				formVO.Add_ymd_from = paramCol["Add_ymd_from"].DateFullValue;
			}
			if (paramCol["Add_ymd_to"].DateFullValue != null)
			{
				formVO.Add_ymd_to = paramCol["Add_ymd_to"].DateFullValue;
			}
			if (paramCol["Tantosya_cd"].UnformatValue != null)
			{
				formVO.Tantosya_cd = paramCol["Tantosya_cd"].UnformatValue;
			}
			if (paramCol["Hanbaiin_nm"].UnformatValue != null)
			{
				formVO.Hanbaiin_nm = paramCol["Hanbaiin_nm"].UnformatValue;
			}
			if (paramCol["Apply_ymd_from"].DateFullValue != null)
			{
				formVO.Apply_ymd_from = paramCol["Apply_ymd_from"].DateFullValue;
			}
			if (paramCol["Apply_ymd_to"].DateFullValue != null)
			{
				formVO.Apply_ymd_to = paramCol["Apply_ymd_to"].DateFullValue;
			}
			if (paramCol["Sinsei_sb"].UnformatValue != null)
			{
				formVO.Sinsei_sb = paramCol["Sinsei_sb"].UnformatValue;
			}
			if (paramCol["Irairiyu_cd"].UnformatValue != null)
			{
				formVO.Irairiyu_cd = paramCol["Irairiyu_cd"].UnformatValue;
			}
			if (paramCol["Irairiyu_cd1"].UnformatValue != null)
			{
				formVO.Irairiyu_cd1 = paramCol["Irairiyu_cd1"].UnformatValue;
			}
			if (paramCol["Jotai_kbn"].UnformatValue != null)
			{
				formVO.Jotai_kbn = paramCol["Jotai_kbn"].UnformatValue;
			}
			if (paramCol["Old_jisya_hbn"].UnformatValue != null)
			{
				formVO.Old_jisya_hbn = paramCol["Old_jisya_hbn"].UnformatValue;
			}
			if (paramCol["Maker_hbn"].UnformatValue != null)
			{
				formVO.Maker_hbn = paramCol["Maker_hbn"].UnformatValue;
			}
			if (paramCol["Scan_cd"].UnformatValue != null)
			{
				formVO.Scan_cd = paramCol["Scan_cd"].UnformatValue;
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
				Ta080f01M1Form ta080f01M1Form = (Ta080f01M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					ta080f01M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					ta080f01M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					ta080f01M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Ta080f01Form formVO, StandardCheckManager checker)
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
			if (formVO.Yosan_ymd_from != null)
			{
				checker.DoCheck("Yosan_ymd_from", formVO.Yosan_ymd_from);
			}
			if (formVO.Yosan_ymd_to != null)
			{
				checker.DoCheck("Yosan_ymd_to", formVO.Yosan_ymd_to);
			}
			if (formVO.Yosan_cd_from != null)
			{
				checker.DoCheck("Yosan_cd_from", formVO.Yosan_cd_from);
			}
			if (formVO.Yosan_nm_from != null)
			{
				checker.DoCheck("Yosan_nm_from", formVO.Yosan_nm_from);
			}
			if (formVO.Yosan_cd_to != null)
			{
				checker.DoCheck("Yosan_cd_to", formVO.Yosan_cd_to);
			}
			if (formVO.Yosan_nm_to != null)
			{
				checker.DoCheck("Yosan_nm_to", formVO.Yosan_nm_to);
			}
			if (formVO.Add_ymd_from != null)
			{
				checker.DoCheck("Add_ymd_from", formVO.Add_ymd_from);
			}
			if (formVO.Add_ymd_to != null)
			{
				checker.DoCheck("Add_ymd_to", formVO.Add_ymd_to);
			}
			if (formVO.Tantosya_cd != null)
			{
				checker.DoCheck("Tantosya_cd", formVO.Tantosya_cd);
			}
			if (formVO.Hanbaiin_nm != null)
			{
				checker.DoCheck("Hanbaiin_nm", formVO.Hanbaiin_nm);
			}
			if (formVO.Apply_ymd_from != null)
			{
				checker.DoCheck("Apply_ymd_from", formVO.Apply_ymd_from);
			}
			if (formVO.Apply_ymd_to != null)
			{
				checker.DoCheck("Apply_ymd_to", formVO.Apply_ymd_to);
			}
			if (formVO.Sinsei_sb != null)
			{
				checker.DoCheck("Sinsei_sb", formVO.Sinsei_sb);
			}
			if (formVO.Irairiyu_cd != null)
			{
				checker.DoCheck("Irairiyu_cd", formVO.Irairiyu_cd);
			}
			if (formVO.Irairiyu_cd1 != null)
			{
				checker.DoCheck("Irairiyu_cd1", formVO.Irairiyu_cd1);
			}
			if (formVO.Jotai_kbn != null)
			{
				checker.DoCheck("Jotai_kbn", formVO.Jotai_kbn);
			}
			if (formVO.Old_jisya_hbn != null)
			{
				checker.DoCheck("Old_jisya_hbn", formVO.Old_jisya_hbn);
			}
			if (formVO.Maker_hbn != null)
			{
				checker.DoCheck("Maker_hbn", formVO.Maker_hbn);
			}
			if (formVO.Scan_cd != null)
			{
				checker.DoCheck("Scan_cd", formVO.Scan_cd);
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
		public static void ValidateM1InputValue(Ta080f01Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Ta080f01M1Form ta080f01M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, ta080f01M1Form, i, m1List);
				if (ta080f01M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", ta080f01M1Form.M1selectorcheckbox, i, m1List);
				}
				if (ta080f01M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", ta080f01M1Form.M1entersyoriflg, i, m1List);
				}
				if (ta080f01M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", ta080f01M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Ta080f01Form formVO, StandardCodeCheckManager checker)
		{
			checker.DoCheck("Btnheadtenpocd", formVO);
			checker.DoCheck("Btnyosan_cd_from", formVO);
			checker.DoCheck("Btnyosan_cd_to", formVO);
			checker.DoCheck("Btntanto_cd", formVO);
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Ta080f01Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

