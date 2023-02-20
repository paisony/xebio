using com.xebio.bo.Tm060p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Tm060p01.Request
{
  /// <summary>
  /// Tm060f01RequestHelper の概要の説明です。
  /// </summary>
  public static class Tm060f01RequestHelper
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
			Tm060f01Form formVO = (Tm060f01Form)pageContext.GetFormVO();

			//カード部を初期化する
			paramCol.InitCardItems(formInfo.GetCardItems());
			//明細「M1」部を初期化する
			paramCol.InitListItems(formInfo.GetListItems("M1"), formVO.GetList("M1").CurrentCount);
			//カード項目の入力値を取得する
			paramCol["Head_tenpo_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_nm"]);
			paramCol["Tantosya_cd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tantosya_cd_from"]);
			paramCol["Hanbaiin_nm_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hanbaiin_nm_from"]);
			paramCol["Tantosya_cd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tantosya_cd_to"]);
			paramCol["Hanbaiin_nm_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hanbaiin_nm_to"]);
			paramCol["Syokusei_kb"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Syokusei_kb"]);
			paramCol["Searchcnt"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Searchcnt"]);
			paramCol["Kengen_kb"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Kengen_kb"]);
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
				paramCol["M1tantosya_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tantosya_cd"]);
				paramCol["M1hanbaiin_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hanbaiin_nm"]);
				paramCol["M1syokusei_kb_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1syokusei_kb_nm"]);
				paramCol["M1kengen_kb"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1kengen_kb"]);
				paramCol["M1passwardsyokika"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1passwardsyokika"]);
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
			Tm060f01Form formVO = (Tm060f01Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Tantosya_cd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tantosya_cd_from"].RequestValue, formInfo["Tantosya_cd_from"]);
			paramCol["Hanbaiin_nm_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hanbaiin_nm_from"].RequestValue, formInfo["Hanbaiin_nm_from"]);
			paramCol["Tantosya_cd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tantosya_cd_to"].RequestValue, formInfo["Tantosya_cd_to"]);
			paramCol["Hanbaiin_nm_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hanbaiin_nm_to"].RequestValue, formInfo["Hanbaiin_nm_to"]);
			paramCol["Syokusei_kb"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Syokusei_kb"].RequestValue, formInfo["Syokusei_kb"]);
			paramCol["Searchcnt"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Searchcnt"].RequestValue, formInfo["Searchcnt"]);
			paramCol["Kengen_kb"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Kengen_kb"].RequestValue, formInfo["Kengen_kb"]);
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
				paramCol["M1tantosya_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tantosya_cd"][i].RequestValue, formInfo["M1tantosya_cd"]);
				paramCol["M1hanbaiin_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hanbaiin_nm"][i].RequestValue, formInfo["M1hanbaiin_nm"]);
				paramCol["M1syokusei_kb_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1syokusei_kb_nm"][i].RequestValue, formInfo["M1syokusei_kb_nm"]);
				paramCol["M1kengen_kb"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1kengen_kb"][i].RequestValue, formInfo["M1kengen_kb"]);
				paramCol["M1passwardsyokika"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1passwardsyokika"][i].RequestValue, formInfo["M1passwardsyokika"]);
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
			Tm060f01Form formVO = (Tm060f01Form)pageContext.GetFormVO();

			//カード項目の入力値をFormVOにコピーする
			if (paramCol["Head_tenpo_cd"].UnformatValue != null)
			{
				formVO.Head_tenpo_cd = paramCol["Head_tenpo_cd"].UnformatValue;
			}
			if (paramCol["Head_tenpo_nm"].UnformatValue != null)
			{
				formVO.Head_tenpo_nm = paramCol["Head_tenpo_nm"].UnformatValue;
			}
			if (paramCol["Tantosya_cd_from"].UnformatValue != null)
			{
				formVO.Tantosya_cd_from = paramCol["Tantosya_cd_from"].UnformatValue;
			}
			if (paramCol["Hanbaiin_nm_from"].UnformatValue != null)
			{
				formVO.Hanbaiin_nm_from = paramCol["Hanbaiin_nm_from"].UnformatValue;
			}
			if (paramCol["Tantosya_cd_to"].UnformatValue != null)
			{
				formVO.Tantosya_cd_to = paramCol["Tantosya_cd_to"].UnformatValue;
			}
			if (paramCol["Hanbaiin_nm_to"].UnformatValue != null)
			{
				formVO.Hanbaiin_nm_to = paramCol["Hanbaiin_nm_to"].UnformatValue;
			}
			if (paramCol["Syokusei_kb"].UnformatValue != null)
			{
				formVO.Syokusei_kb = paramCol["Syokusei_kb"].UnformatValue;
			}
			if (paramCol["Searchcnt"].UnformatValue != null)
			{
				formVO.Searchcnt = paramCol["Searchcnt"].UnformatValue;
			}
			if (paramCol["Kengen_kb"].UnformatValue != null)
			{
				formVO.Kengen_kb = paramCol["Kengen_kb"].UnformatValue;
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
				Tm060f01M1Form tm060f01M1Form = (Tm060f01M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					tm060f01M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1tantosya_cd"][i].UnformatValue != null)
				{
					tm060f01M1Form.M1tantosya_cd = paramCol["M1tantosya_cd"][i].UnformatValue;
				}
				if (paramCol["M1hanbaiin_nm"][i].UnformatValue != null)
				{
					tm060f01M1Form.M1hanbaiin_nm = paramCol["M1hanbaiin_nm"][i].UnformatValue;
				}
				if (paramCol["M1syokusei_kb_nm"][i].UnformatValue != null)
				{
					tm060f01M1Form.M1syokusei_kb_nm = paramCol["M1syokusei_kb_nm"][i].UnformatValue;
				}
				if (paramCol["M1kengen_kb"][i].UnformatValue != null)
				{
					tm060f01M1Form.M1kengen_kb = paramCol["M1kengen_kb"][i].UnformatValue;
				}
				if (paramCol["M1passwardsyokika"][i].UnformatValue != null)
				{
					tm060f01M1Form.M1passwardsyokika = paramCol["M1passwardsyokika"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					tm060f01M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					tm060f01M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					tm060f01M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Tm060f01Form formVO, StandardCheckManager checker)
		{
			if (formVO.Head_tenpo_cd != null)
			{
				checker.DoCheck("Head_tenpo_cd", formVO.Head_tenpo_cd);
			}
			if (formVO.Head_tenpo_nm != null)
			{
				checker.DoCheck("Head_tenpo_nm", formVO.Head_tenpo_nm);
			}
			if (formVO.Tantosya_cd_from != null)
			{
				checker.DoCheck("Tantosya_cd_from", formVO.Tantosya_cd_from);
			}
			if (formVO.Hanbaiin_nm_from != null)
			{
				checker.DoCheck("Hanbaiin_nm_from", formVO.Hanbaiin_nm_from);
			}
			if (formVO.Tantosya_cd_to != null)
			{
				checker.DoCheck("Tantosya_cd_to", formVO.Tantosya_cd_to);
			}
			if (formVO.Hanbaiin_nm_to != null)
			{
				checker.DoCheck("Hanbaiin_nm_to", formVO.Hanbaiin_nm_to);
			}
			if (formVO.Syokusei_kb != null)
			{
				checker.DoCheck("Syokusei_kb", formVO.Syokusei_kb);
			}
			if (formVO.Searchcnt != null)
			{
				checker.DoCheck("Searchcnt", formVO.Searchcnt);
			}
			if (formVO.Kengen_kb != null)
			{
				checker.DoCheck("Kengen_kb", formVO.Kengen_kb);
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
		public static void ValidateM1InputValue(Tm060f01Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Tm060f01M1Form tm060f01M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, tm060f01M1Form, i, m1List);
				if (tm060f01M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", tm060f01M1Form.M1rowno, i, m1List);
				}
				if (tm060f01M1Form.M1tantosya_cd != null)
				{
					checker.DoCheck("M1tantosya_cd", tm060f01M1Form.M1tantosya_cd, i, m1List);
				}
				if (tm060f01M1Form.M1hanbaiin_nm != null)
				{
					checker.DoCheck("M1hanbaiin_nm", tm060f01M1Form.M1hanbaiin_nm, i, m1List);
				}
				if (tm060f01M1Form.M1syokusei_kb_nm != null)
				{
					checker.DoCheck("M1syokusei_kb_nm", tm060f01M1Form.M1syokusei_kb_nm, i, m1List);
				}
				if (tm060f01M1Form.M1kengen_kb != null)
				{
					checker.DoCheck("M1kengen_kb", tm060f01M1Form.M1kengen_kb, i, m1List);
				}
				if (tm060f01M1Form.M1passwardsyokika != null)
				{
					checker.DoCheck("M1passwardsyokika", tm060f01M1Form.M1passwardsyokika, i, m1List);
				}
				if (tm060f01M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", tm060f01M1Form.M1selectorcheckbox, i, m1List);
				}
				if (tm060f01M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", tm060f01M1Form.M1entersyoriflg, i, m1List);
				}
				if (tm060f01M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", tm060f01M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Tm060f01Form formVO, StandardCodeCheckManager checker)
		{
			checker.DoCheck("Btnheadtenpocd", formVO);
			checker.DoCheck("Btntanto_cd_from", formVO);
			checker.DoCheck("Btntanto_cd_to", formVO);
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Tm060f01Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

