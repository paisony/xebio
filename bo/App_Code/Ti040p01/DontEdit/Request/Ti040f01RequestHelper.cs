using com.xebio.bo.Ti040p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Ti040p01.Request
{
  /// <summary>
  /// Ti040f01RequestHelper の概要の説明です。
  /// </summary>
  public static class Ti040f01RequestHelper
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
			Ti040f01Form formVO = (Ti040f01Form)pageContext.GetFormVO();

			//カード部を初期化する
			paramCol.InitCardItems(formInfo.GetCardItems());
			//明細「M1」部を初期化する
			paramCol.InitListItems(formInfo.GetListItems("M1"), formVO.GetList("M1").CurrentCount);
			//カード項目の入力値を取得する
			paramCol["Head_tenpo_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_nm"]);
			paramCol["Label_cd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Label_cd_from"]);
			paramCol["Label_cd_from2"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Label_cd_from2"]);
			paramCol["Label_cd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Label_cd_to"]);
			paramCol["Label_cd_to2"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Label_cd_to2"]);
			paramCol["Label_ip_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Label_ip_from"]);
			paramCol["Label_ip_from2"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Label_ip_from2"]);
			paramCol["Label_ip_from3"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Label_ip_from3"]);
			paramCol["Label_ip_from4"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Label_ip_from4"]);
			paramCol["Label_ip_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Label_ip_to"]);
			paramCol["Label_ip_to2"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Label_ip_to2"]);
			paramCol["Label_ip_to3"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Label_ip_to3"]);
			paramCol["Label_ip_to4"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Label_ip_to4"]);
			paramCol["Label_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Label_nm"]);
			paramCol["Label_biko"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Label_biko"]);
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
				paramCol["M1label_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1label_cd"]);
				paramCol["M1label_cd2"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1label_cd2"]);
				paramCol["M1label_ip"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1label_ip"]);
				paramCol["M1label_ip2"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1label_ip2"]);
				paramCol["M1label_ip3"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1label_ip3"]);
				paramCol["M1label_ip4"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1label_ip4"]);
				paramCol["M1label_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1label_nm"]);
				paramCol["M1label_biko"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1label_biko"]);
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
			Ti040f01Form formVO = (Ti040f01Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Label_cd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Label_cd_from"].RequestValue, formInfo["Label_cd_from"]);
			paramCol["Label_cd_from2"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Label_cd_from2"].RequestValue, formInfo["Label_cd_from2"]);
			paramCol["Label_cd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Label_cd_to"].RequestValue, formInfo["Label_cd_to"]);
			paramCol["Label_cd_to2"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Label_cd_to2"].RequestValue, formInfo["Label_cd_to2"]);
			paramCol["Label_ip_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Label_ip_from"].RequestValue, formInfo["Label_ip_from"]);
			paramCol["Label_ip_from2"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Label_ip_from2"].RequestValue, formInfo["Label_ip_from2"]);
			paramCol["Label_ip_from3"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Label_ip_from3"].RequestValue, formInfo["Label_ip_from3"]);
			paramCol["Label_ip_from4"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Label_ip_from4"].RequestValue, formInfo["Label_ip_from4"]);
			paramCol["Label_ip_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Label_ip_to"].RequestValue, formInfo["Label_ip_to"]);
			paramCol["Label_ip_to2"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Label_ip_to2"].RequestValue, formInfo["Label_ip_to2"]);
			paramCol["Label_ip_to3"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Label_ip_to3"].RequestValue, formInfo["Label_ip_to3"]);
			paramCol["Label_ip_to4"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Label_ip_to4"].RequestValue, formInfo["Label_ip_to4"]);
			paramCol["Label_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Label_nm"].RequestValue, formInfo["Label_nm"]);
			paramCol["Label_biko"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Label_biko"].RequestValue, formInfo["Label_biko"]);
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
				paramCol["M1label_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1label_cd"][i].RequestValue, formInfo["M1label_cd"]);
				paramCol["M1label_cd2"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1label_cd2"][i].RequestValue, formInfo["M1label_cd2"]);
				paramCol["M1label_ip"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1label_ip"][i].RequestValue, formInfo["M1label_ip"]);
				paramCol["M1label_ip2"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1label_ip2"][i].RequestValue, formInfo["M1label_ip2"]);
				paramCol["M1label_ip3"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1label_ip3"][i].RequestValue, formInfo["M1label_ip3"]);
				paramCol["M1label_ip4"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1label_ip4"][i].RequestValue, formInfo["M1label_ip4"]);
				paramCol["M1label_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1label_nm"][i].RequestValue, formInfo["M1label_nm"]);
				paramCol["M1label_biko"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1label_biko"][i].RequestValue, formInfo["M1label_biko"]);
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
			Ti040f01Form formVO = (Ti040f01Form)pageContext.GetFormVO();

			//カード項目の入力値をFormVOにコピーする
			if (paramCol["Head_tenpo_cd"].UnformatValue != null)
			{
				formVO.Head_tenpo_cd = paramCol["Head_tenpo_cd"].UnformatValue;
			}
			if (paramCol["Head_tenpo_nm"].UnformatValue != null)
			{
				formVO.Head_tenpo_nm = paramCol["Head_tenpo_nm"].UnformatValue;
			}
			if (paramCol["Label_cd_from"].UnformatValue != null)
			{
				formVO.Label_cd_from = paramCol["Label_cd_from"].UnformatValue;
			}
			if (paramCol["Label_cd_from2"].UnformatValue != null)
			{
				formVO.Label_cd_from2 = paramCol["Label_cd_from2"].UnformatValue;
			}
			if (paramCol["Label_cd_to"].UnformatValue != null)
			{
				formVO.Label_cd_to = paramCol["Label_cd_to"].UnformatValue;
			}
			if (paramCol["Label_cd_to2"].UnformatValue != null)
			{
				formVO.Label_cd_to2 = paramCol["Label_cd_to2"].UnformatValue;
			}
			if (paramCol["Label_ip_from"].UnformatValue != null)
			{
				formVO.Label_ip_from = paramCol["Label_ip_from"].UnformatValue;
			}
			if (paramCol["Label_ip_from2"].UnformatValue != null)
			{
				formVO.Label_ip_from2 = paramCol["Label_ip_from2"].UnformatValue;
			}
			if (paramCol["Label_ip_from3"].UnformatValue != null)
			{
				formVO.Label_ip_from3 = paramCol["Label_ip_from3"].UnformatValue;
			}
			if (paramCol["Label_ip_from4"].UnformatValue != null)
			{
				formVO.Label_ip_from4 = paramCol["Label_ip_from4"].UnformatValue;
			}
			if (paramCol["Label_ip_to"].UnformatValue != null)
			{
				formVO.Label_ip_to = paramCol["Label_ip_to"].UnformatValue;
			}
			if (paramCol["Label_ip_to2"].UnformatValue != null)
			{
				formVO.Label_ip_to2 = paramCol["Label_ip_to2"].UnformatValue;
			}
			if (paramCol["Label_ip_to3"].UnformatValue != null)
			{
				formVO.Label_ip_to3 = paramCol["Label_ip_to3"].UnformatValue;
			}
			if (paramCol["Label_ip_to4"].UnformatValue != null)
			{
				formVO.Label_ip_to4 = paramCol["Label_ip_to4"].UnformatValue;
			}
			if (paramCol["Label_nm"].UnformatValue != null)
			{
				formVO.Label_nm = paramCol["Label_nm"].UnformatValue;
			}
			if (paramCol["Label_biko"].UnformatValue != null)
			{
				formVO.Label_biko = paramCol["Label_biko"].UnformatValue;
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
				Ti040f01M1Form ti040f01M1Form = (Ti040f01M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					ti040f01M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1label_cd"][i].UnformatValue != null)
				{
					ti040f01M1Form.M1label_cd = paramCol["M1label_cd"][i].UnformatValue;
				}
				if (paramCol["M1label_cd2"][i].UnformatValue != null)
				{
					ti040f01M1Form.M1label_cd2 = paramCol["M1label_cd2"][i].UnformatValue;
				}
				if (paramCol["M1label_ip"][i].UnformatValue != null)
				{
					ti040f01M1Form.M1label_ip = paramCol["M1label_ip"][i].UnformatValue;
				}
				if (paramCol["M1label_ip2"][i].UnformatValue != null)
				{
					ti040f01M1Form.M1label_ip2 = paramCol["M1label_ip2"][i].UnformatValue;
				}
				if (paramCol["M1label_ip3"][i].UnformatValue != null)
				{
					ti040f01M1Form.M1label_ip3 = paramCol["M1label_ip3"][i].UnformatValue;
				}
				if (paramCol["M1label_ip4"][i].UnformatValue != null)
				{
					ti040f01M1Form.M1label_ip4 = paramCol["M1label_ip4"][i].UnformatValue;
				}
				if (paramCol["M1label_nm"][i].UnformatValue != null)
				{
					ti040f01M1Form.M1label_nm = paramCol["M1label_nm"][i].UnformatValue;
				}
				if (paramCol["M1label_biko"][i].UnformatValue != null)
				{
					ti040f01M1Form.M1label_biko = paramCol["M1label_biko"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					ti040f01M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					ti040f01M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					ti040f01M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Ti040f01Form formVO, StandardCheckManager checker)
		{
			if (formVO.Head_tenpo_cd != null)
			{
				checker.DoCheck("Head_tenpo_cd", formVO.Head_tenpo_cd);
			}
			if (formVO.Head_tenpo_nm != null)
			{
				checker.DoCheck("Head_tenpo_nm", formVO.Head_tenpo_nm);
			}
			if (formVO.Label_cd_from != null)
			{
				checker.DoCheck("Label_cd_from", formVO.Label_cd_from);
			}
			if (formVO.Label_cd_from2 != null)
			{
				checker.DoCheck("Label_cd_from2", formVO.Label_cd_from2);
			}
			if (formVO.Label_cd_to != null)
			{
				checker.DoCheck("Label_cd_to", formVO.Label_cd_to);
			}
			if (formVO.Label_cd_to2 != null)
			{
				checker.DoCheck("Label_cd_to2", formVO.Label_cd_to2);
			}
			if (formVO.Label_ip_from != null)
			{
				checker.DoCheck("Label_ip_from", formVO.Label_ip_from);
			}
			if (formVO.Label_ip_from2 != null)
			{
				checker.DoCheck("Label_ip_from2", formVO.Label_ip_from2);
			}
			if (formVO.Label_ip_from3 != null)
			{
				checker.DoCheck("Label_ip_from3", formVO.Label_ip_from3);
			}
			if (formVO.Label_ip_from4 != null)
			{
				checker.DoCheck("Label_ip_from4", formVO.Label_ip_from4);
			}
			if (formVO.Label_ip_to != null)
			{
				checker.DoCheck("Label_ip_to", formVO.Label_ip_to);
			}
			if (formVO.Label_ip_to2 != null)
			{
				checker.DoCheck("Label_ip_to2", formVO.Label_ip_to2);
			}
			if (formVO.Label_ip_to3 != null)
			{
				checker.DoCheck("Label_ip_to3", formVO.Label_ip_to3);
			}
			if (formVO.Label_ip_to4 != null)
			{
				checker.DoCheck("Label_ip_to4", formVO.Label_ip_to4);
			}
			if (formVO.Label_nm != null)
			{
				checker.DoCheck("Label_nm", formVO.Label_nm);
			}
			if (formVO.Label_biko != null)
			{
				checker.DoCheck("Label_biko", formVO.Label_biko);
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
		public static void ValidateM1InputValue(Ti040f01Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Ti040f01M1Form ti040f01M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, ti040f01M1Form, i, m1List);
				if (ti040f01M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", ti040f01M1Form.M1rowno, i, m1List);
				}
				if (ti040f01M1Form.M1label_cd != null)
				{
					checker.DoCheck("M1label_cd", ti040f01M1Form.M1label_cd, i, m1List);
				}
				if (ti040f01M1Form.M1label_cd2 != null)
				{
					checker.DoCheck("M1label_cd2", ti040f01M1Form.M1label_cd2, i, m1List);
				}
				if (ti040f01M1Form.M1label_ip != null)
				{
					checker.DoCheck("M1label_ip", ti040f01M1Form.M1label_ip, i, m1List);
				}
				if (ti040f01M1Form.M1label_ip2 != null)
				{
					checker.DoCheck("M1label_ip2", ti040f01M1Form.M1label_ip2, i, m1List);
				}
				if (ti040f01M1Form.M1label_ip3 != null)
				{
					checker.DoCheck("M1label_ip3", ti040f01M1Form.M1label_ip3, i, m1List);
				}
				if (ti040f01M1Form.M1label_ip4 != null)
				{
					checker.DoCheck("M1label_ip4", ti040f01M1Form.M1label_ip4, i, m1List);
				}
				if (ti040f01M1Form.M1label_nm != null)
				{
					checker.DoCheck("M1label_nm", ti040f01M1Form.M1label_nm, i, m1List);
				}
				if (ti040f01M1Form.M1label_biko != null)
				{
					checker.DoCheck("M1label_biko", ti040f01M1Form.M1label_biko, i, m1List);
				}
				if (ti040f01M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", ti040f01M1Form.M1selectorcheckbox, i, m1List);
				}
				if (ti040f01M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", ti040f01M1Form.M1entersyoriflg, i, m1List);
				}
				if (ti040f01M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", ti040f01M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Ti040f01Form formVO, StandardCodeCheckManager checker)
		{
			checker.DoCheck("Btnheadtenpocd", formVO);
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Ti040f01Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

