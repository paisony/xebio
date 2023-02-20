using com.xebio.bo.Tg040p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Tg040p01.Request
{
  /// <summary>
  /// Tg040f01RequestHelper の概要の説明です。
  /// </summary>
  public static class Tg040f01RequestHelper
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
			Tg040f01Form formVO = (Tg040f01Form)pageContext.GetFormVO();

			//カード部を初期化する
			paramCol.InitCardItems(formInfo.GetCardItems());
			//明細「M1」部を初期化する
			paramCol.InitListItems(formInfo.GetListItems("M1"), formVO.GetList("M1").CurrentCount);
			//カード項目の入力値を取得する
			paramCol["Head_tenpo_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_nm"]);
			paramCol["Ymd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Ymd_from"]);
			paramCol["Ymd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Ymd_to"]);
			paramCol["Stock_no"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Stock_no"]);
			paramCol["Tan_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tan_cd"]);
			paramCol["Hanbaiin_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hanbaiin_nm"]);
			paramCol["Old_jisya_hbn"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Old_jisya_hbn"]);
			paramCol["Maker_hbn"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Maker_hbn"]);
			paramCol["Scan_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Scan_cd"]);
			paramCol["Hanbaikanryo_ymd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hanbaikanryo_ymd_from"]);
			paramCol["Hanbaikanryo_ymd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hanbaikanryo_ymd_to"]);
			paramCol["Searchcnt"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Searchcnt"]);
			paramCol["Modeno"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Modeno"]);
			paramCol["Stkmodeno"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Stkmodeno"]);
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
				paramCol["M1tm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tm"]);
				paramCol["M1hanbaiin_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hanbaiin_nm"]);
				paramCol["M1stock_no"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1stock_no"]);
				paramCol["M1suryo"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1suryo"]);
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
			Tg040f01Form formVO = (Tg040f01Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Ymd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Ymd_from"].RequestValue, formInfo["Ymd_from"]);
			paramCol["Ymd_from"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Ymd_from"].RequestValue, formInfo["Ymd_from"]);
			paramCol["Ymd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Ymd_to"].RequestValue, formInfo["Ymd_to"]);
			paramCol["Ymd_to"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Ymd_to"].RequestValue, formInfo["Ymd_to"]);
			paramCol["Stock_no"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Stock_no"].RequestValue, formInfo["Stock_no"]);
			paramCol["Tan_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tan_cd"].RequestValue, formInfo["Tan_cd"]);
			paramCol["Hanbaiin_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hanbaiin_nm"].RequestValue, formInfo["Hanbaiin_nm"]);
			paramCol["Old_jisya_hbn"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Old_jisya_hbn"].RequestValue, formInfo["Old_jisya_hbn"]);
			paramCol["Maker_hbn"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Maker_hbn"].RequestValue, formInfo["Maker_hbn"]);
			paramCol["Scan_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Scan_cd"].RequestValue, formInfo["Scan_cd"]);
			paramCol["Hanbaikanryo_ymd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hanbaikanryo_ymd_from"].RequestValue, formInfo["Hanbaikanryo_ymd_from"]);
			paramCol["Hanbaikanryo_ymd_from"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Hanbaikanryo_ymd_from"].RequestValue, formInfo["Hanbaikanryo_ymd_from"]);
			paramCol["Hanbaikanryo_ymd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hanbaikanryo_ymd_to"].RequestValue, formInfo["Hanbaikanryo_ymd_to"]);
			paramCol["Hanbaikanryo_ymd_to"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Hanbaikanryo_ymd_to"].RequestValue, formInfo["Hanbaikanryo_ymd_to"]);
			paramCol["Searchcnt"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Searchcnt"].RequestValue, formInfo["Searchcnt"]);
			paramCol["Modeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Modeno"].RequestValue, formInfo["Modeno"]);
			paramCol["Stkmodeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Stkmodeno"].RequestValue, formInfo["Stkmodeno"]);
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
				paramCol["M1tm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tm"][i].RequestValue, formInfo["M1tm"]);
				paramCol["M1tm"][i].DateFullValue = RequestParameterUtil.GetDateFullValue(
					paramCol["M1tm"][i].RequestValue, formInfo["M1tm"]);
				paramCol["M1hanbaiin_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hanbaiin_nm"][i].RequestValue, formInfo["M1hanbaiin_nm"]);
				paramCol["M1stock_no"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1stock_no"][i].RequestValue, formInfo["M1stock_no"]);
				paramCol["M1suryo"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1suryo"][i].RequestValue, formInfo["M1suryo"]);
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
			Tg040f01Form formVO = (Tg040f01Form)pageContext.GetFormVO();

			//カード項目の入力値をFormVOにコピーする
			if (paramCol["Head_tenpo_cd"].UnformatValue != null)
			{
				formVO.Head_tenpo_cd = paramCol["Head_tenpo_cd"].UnformatValue;
			}
			if (paramCol["Head_tenpo_nm"].UnformatValue != null)
			{
				formVO.Head_tenpo_nm = paramCol["Head_tenpo_nm"].UnformatValue;
			}
			if (paramCol["Ymd_from"].DateFullValue != null)
			{
				formVO.Ymd_from = paramCol["Ymd_from"].DateFullValue;
			}
			if (paramCol["Ymd_to"].DateFullValue != null)
			{
				formVO.Ymd_to = paramCol["Ymd_to"].DateFullValue;
			}
			if (paramCol["Stock_no"].UnformatValue != null)
			{
				formVO.Stock_no = paramCol["Stock_no"].UnformatValue;
			}
			if (paramCol["Tan_cd"].UnformatValue != null)
			{
				formVO.Tan_cd = paramCol["Tan_cd"].UnformatValue;
			}
			if (paramCol["Hanbaiin_nm"].UnformatValue != null)
			{
				formVO.Hanbaiin_nm = paramCol["Hanbaiin_nm"].UnformatValue;
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
			if (paramCol["Hanbaikanryo_ymd_from"].DateFullValue != null)
			{
				formVO.Hanbaikanryo_ymd_from = paramCol["Hanbaikanryo_ymd_from"].DateFullValue;
			}
			if (paramCol["Hanbaikanryo_ymd_to"].DateFullValue != null)
			{
				formVO.Hanbaikanryo_ymd_to = paramCol["Hanbaikanryo_ymd_to"].DateFullValue;
			}
			if (paramCol["Searchcnt"].UnformatValue != null)
			{
				formVO.Searchcnt = paramCol["Searchcnt"].UnformatValue;
			}
			if (paramCol["Modeno"].UnformatValue != null)
			{
				formVO.Modeno = paramCol["Modeno"].UnformatValue;
			}
			if (paramCol["Stkmodeno"].UnformatValue != null)
			{
				formVO.Stkmodeno = paramCol["Stkmodeno"].UnformatValue;
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
				Tg040f01M1Form tg040f01M1Form = (Tg040f01M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					tg040f01M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1tm"][i].DateFullValue != null)
				{
					tg040f01M1Form.M1tm = paramCol["M1tm"][i].DateFullValue;
				}
				if (paramCol["M1hanbaiin_nm"][i].UnformatValue != null)
				{
					tg040f01M1Form.M1hanbaiin_nm = paramCol["M1hanbaiin_nm"][i].UnformatValue;
				}
				if (paramCol["M1stock_no"][i].UnformatValue != null)
				{
					tg040f01M1Form.M1stock_no = paramCol["M1stock_no"][i].UnformatValue;
				}
				if (paramCol["M1suryo"][i].UnformatValue != null)
				{
					tg040f01M1Form.M1suryo = paramCol["M1suryo"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					tg040f01M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					tg040f01M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					tg040f01M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Tg040f01Form formVO, StandardCheckManager checker)
		{
			if (formVO.Head_tenpo_cd != null)
			{
				checker.DoCheck("Head_tenpo_cd", formVO.Head_tenpo_cd);
			}
			if (formVO.Head_tenpo_nm != null)
			{
				checker.DoCheck("Head_tenpo_nm", formVO.Head_tenpo_nm);
			}
			if (formVO.Ymd_from != null)
			{
				checker.DoCheck("Ymd_from", formVO.Ymd_from);
			}
			if (formVO.Ymd_to != null)
			{
				checker.DoCheck("Ymd_to", formVO.Ymd_to);
			}
			if (formVO.Stock_no != null)
			{
				checker.DoCheck("Stock_no", formVO.Stock_no);
			}
			if (formVO.Tan_cd != null)
			{
				checker.DoCheck("Tan_cd", formVO.Tan_cd);
			}
			if (formVO.Hanbaiin_nm != null)
			{
				checker.DoCheck("Hanbaiin_nm", formVO.Hanbaiin_nm);
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
			if (formVO.Hanbaikanryo_ymd_from != null)
			{
				checker.DoCheck("Hanbaikanryo_ymd_from", formVO.Hanbaikanryo_ymd_from);
			}
			if (formVO.Hanbaikanryo_ymd_to != null)
			{
				checker.DoCheck("Hanbaikanryo_ymd_to", formVO.Hanbaikanryo_ymd_to);
			}
			if (formVO.Searchcnt != null)
			{
				checker.DoCheck("Searchcnt", formVO.Searchcnt);
			}
			if (formVO.Modeno != null)
			{
				checker.DoCheck("Modeno", formVO.Modeno);
			}
			if (formVO.Stkmodeno != null)
			{
				checker.DoCheck("Stkmodeno", formVO.Stkmodeno);
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
		public static void ValidateM1InputValue(Tg040f01Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Tg040f01M1Form tg040f01M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, tg040f01M1Form, i, m1List);
				if (tg040f01M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", tg040f01M1Form.M1rowno, i, m1List);
				}
				if (tg040f01M1Form.M1tm != null)
				{
					checker.DoCheck("M1tm", tg040f01M1Form.M1tm, i, m1List);
				}
				if (tg040f01M1Form.M1hanbaiin_nm != null)
				{
					checker.DoCheck("M1hanbaiin_nm", tg040f01M1Form.M1hanbaiin_nm, i, m1List);
				}
				if (tg040f01M1Form.M1stock_no != null)
				{
					checker.DoCheck("M1stock_no", tg040f01M1Form.M1stock_no, i, m1List);
				}
				if (tg040f01M1Form.M1suryo != null)
				{
					checker.DoCheck("M1suryo", tg040f01M1Form.M1suryo, i, m1List);
				}
				if (tg040f01M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", tg040f01M1Form.M1selectorcheckbox, i, m1List);
				}
				if (tg040f01M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", tg040f01M1Form.M1entersyoriflg, i, m1List);
				}
				if (tg040f01M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", tg040f01M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Tg040f01Form formVO, StandardCodeCheckManager checker)
		{
			checker.DoCheck("Btnheadtenpocd", formVO);
			checker.DoCheck("Btntanto_cd", formVO);
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Tg040f01Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

