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
  /// Ta080f02RequestHelper の概要の説明です。
  /// </summary>
  public static class Ta080f02RequestHelper
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
			Ta080f02Form formVO = (Ta080f02Form)pageContext.GetFormVO();

			//カード部を初期化する
			paramCol.InitCardItems(formInfo.GetCardItems());
			//明細「M1」部を初期化する
			paramCol.InitListItems(formInfo.GetListItems("M1"), formVO.GetList("M1").CurrentCount);
			//カード項目の入力値を取得する
			paramCol["Head_tenpo_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_nm"]);
			paramCol["Yosan_ymd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Yosan_ymd"]);
			paramCol["Yosan_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Yosan_cd"]);
			paramCol["Yosan_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Yosan_nm"]);
			paramCol["Yosan_kin"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Yosan_kin"]);
			paramCol["Misinsei_su"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Misinsei_su"]);
			paramCol["Misinsei_kin"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Misinsei_kin"]);
			paramCol["Apply_su"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Apply_su"]);
			paramCol["Apply_kin"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Apply_kin"]);
			paramCol["Jisseki_su_bo2"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Jisseki_su_bo2"]);
			paramCol["Jisseki_kin"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Jisseki_kin"]);
			paramCol["Zan_kin"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Zan_kin"]);
			SCSubBasePage scPage = (SCSubBasePage)page;
			if(StandardBaseCheckManager.CheckUseSelfCustomize()){
				// カード部カスタム項目の値を取得する
				scPage.GetCardRequestValue(paramCol);
			}

			//明細「M1」項目の入力値を取得する
			Repeater M1 = (Repeater)page.FindControl("M1");
			for (int i = 0; i < formVO.GetList("M1").CurrentCount; i++)
			{
				paramCol["M1hanbaiin_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hanbaiin_cd"]);
				paramCol["M1hanbaiin_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hanbaiin_nm"]);
				paramCol["M1irai_riyu"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1irai_riyu"]);
				paramCol["M1bumonkana_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1bumonkana_nm"]);
				paramCol["M1hinsyu_ryaku_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hinsyu_ryaku_nm"]);
				paramCol["M1burando_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1burando_nm"]);
				paramCol["M1maker_hbn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1maker_hbn"]);
				paramCol["M1syonmk"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1syonmk"]);
				paramCol["M1iro_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1iro_nm"]);
				paramCol["M1size_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1size_nm"]);
				paramCol["M1season_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1season_nm"]);
				paramCol["M1jotai_kbn_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1jotai_kbn_nm"]);
				paramCol["M1comment_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1comment_nm"]);
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
			Ta080f02Form formVO = (Ta080f02Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Yosan_ymd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Yosan_ymd"].RequestValue, formInfo["Yosan_ymd"]);
			paramCol["Yosan_ymd"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Yosan_ymd"].RequestValue, formInfo["Yosan_ymd"]);
			paramCol["Yosan_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Yosan_cd"].RequestValue, formInfo["Yosan_cd"]);
			paramCol["Yosan_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Yosan_nm"].RequestValue, formInfo["Yosan_nm"]);
			paramCol["Yosan_kin"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Yosan_kin"].RequestValue, formInfo["Yosan_kin"]);
			paramCol["Misinsei_su"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Misinsei_su"].RequestValue, formInfo["Misinsei_su"]);
			paramCol["Misinsei_kin"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Misinsei_kin"].RequestValue, formInfo["Misinsei_kin"]);
			paramCol["Apply_su"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Apply_su"].RequestValue, formInfo["Apply_su"]);
			paramCol["Apply_kin"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Apply_kin"].RequestValue, formInfo["Apply_kin"]);
			paramCol["Jisseki_su_bo2"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Jisseki_su_bo2"].RequestValue, formInfo["Jisseki_su_bo2"]);
			paramCol["Jisseki_kin"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Jisseki_kin"].RequestValue, formInfo["Jisseki_kin"]);
			paramCol["Zan_kin"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Zan_kin"].RequestValue, formInfo["Zan_kin"]);
			SCSubBasePage page = (SCSubBasePage)HttpContext.Current.Handler;
			if(StandardBaseCheckManager.CheckUseSelfCustomize()){
				// カード部カスタム項目のアンフォーマット値を取得する
				page.UnformatCard(paramCol);
			}

			//明細「M1」項目のアンフォーマット値を取得する
			for (int i = 0; i < formVO.GetList("M1").CurrentCount; i++)
			{
				paramCol["M1hanbaiin_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hanbaiin_cd"][i].RequestValue, formInfo["M1hanbaiin_cd"]);
				paramCol["M1hanbaiin_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hanbaiin_nm"][i].RequestValue, formInfo["M1hanbaiin_nm"]);
				paramCol["M1irai_riyu"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1irai_riyu"][i].RequestValue, formInfo["M1irai_riyu"]);
				paramCol["M1bumonkana_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1bumonkana_nm"][i].RequestValue, formInfo["M1bumonkana_nm"]);
				paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hinsyu_ryaku_nm"][i].RequestValue, formInfo["M1hinsyu_ryaku_nm"]);
				paramCol["M1burando_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1burando_nm"][i].RequestValue, formInfo["M1burando_nm"]);
				paramCol["M1maker_hbn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1maker_hbn"][i].RequestValue, formInfo["M1maker_hbn"]);
				paramCol["M1syonmk"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1syonmk"][i].RequestValue, formInfo["M1syonmk"]);
				paramCol["M1iro_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1iro_nm"][i].RequestValue, formInfo["M1iro_nm"]);
				paramCol["M1size_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1size_nm"][i].RequestValue, formInfo["M1size_nm"]);
				paramCol["M1season_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1season_nm"][i].RequestValue, formInfo["M1season_nm"]);
				paramCol["M1jotai_kbn_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1jotai_kbn_nm"][i].RequestValue, formInfo["M1jotai_kbn_nm"]);
				paramCol["M1comment_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1comment_nm"][i].RequestValue, formInfo["M1comment_nm"]);
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
			Ta080f02Form formVO = (Ta080f02Form)pageContext.GetFormVO();

			//カード項目の入力値をFormVOにコピーする
			if (paramCol["Head_tenpo_cd"].UnformatValue != null)
			{
				formVO.Head_tenpo_cd = paramCol["Head_tenpo_cd"].UnformatValue;
			}
			if (paramCol["Head_tenpo_nm"].UnformatValue != null)
			{
				formVO.Head_tenpo_nm = paramCol["Head_tenpo_nm"].UnformatValue;
			}
			if (paramCol["Yosan_ymd"].DateFullValue != null)
			{
				formVO.Yosan_ymd = paramCol["Yosan_ymd"].DateFullValue;
			}
			if (paramCol["Yosan_cd"].UnformatValue != null)
			{
				formVO.Yosan_cd = paramCol["Yosan_cd"].UnformatValue;
			}
			if (paramCol["Yosan_nm"].UnformatValue != null)
			{
				formVO.Yosan_nm = paramCol["Yosan_nm"].UnformatValue;
			}
			if (paramCol["Yosan_kin"].UnformatValue != null)
			{
				formVO.Yosan_kin = paramCol["Yosan_kin"].UnformatValue;
			}
			if (paramCol["Misinsei_su"].UnformatValue != null)
			{
				formVO.Misinsei_su = paramCol["Misinsei_su"].UnformatValue;
			}
			if (paramCol["Misinsei_kin"].UnformatValue != null)
			{
				formVO.Misinsei_kin = paramCol["Misinsei_kin"].UnformatValue;
			}
			if (paramCol["Apply_su"].UnformatValue != null)
			{
				formVO.Apply_su = paramCol["Apply_su"].UnformatValue;
			}
			if (paramCol["Apply_kin"].UnformatValue != null)
			{
				formVO.Apply_kin = paramCol["Apply_kin"].UnformatValue;
			}
			if (paramCol["Jisseki_su_bo2"].UnformatValue != null)
			{
				formVO.Jisseki_su_bo2 = paramCol["Jisseki_su_bo2"].UnformatValue;
			}
			if (paramCol["Jisseki_kin"].UnformatValue != null)
			{
				formVO.Jisseki_kin = paramCol["Jisseki_kin"].UnformatValue;
			}
			if (paramCol["Zan_kin"].UnformatValue != null)
			{
				formVO.Zan_kin = paramCol["Zan_kin"].UnformatValue;
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
				Ta080f02M1Form ta080f02M1Form = (Ta080f02M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1hanbaiin_cd"][i].UnformatValue != null)
				{
					ta080f02M1Form.M1hanbaiin_cd = paramCol["M1hanbaiin_cd"][i].UnformatValue;
				}
				if (paramCol["M1hanbaiin_nm"][i].UnformatValue != null)
				{
					ta080f02M1Form.M1hanbaiin_nm = paramCol["M1hanbaiin_nm"][i].UnformatValue;
				}
				if (paramCol["M1irai_riyu"][i].UnformatValue != null)
				{
					ta080f02M1Form.M1irai_riyu = paramCol["M1irai_riyu"][i].UnformatValue;
				}
				if (paramCol["M1bumonkana_nm"][i].UnformatValue != null)
				{
					ta080f02M1Form.M1bumonkana_nm = paramCol["M1bumonkana_nm"][i].UnformatValue;
				}
				if (paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue != null)
				{
					ta080f02M1Form.M1hinsyu_ryaku_nm = paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue;
				}
				if (paramCol["M1burando_nm"][i].UnformatValue != null)
				{
					ta080f02M1Form.M1burando_nm = paramCol["M1burando_nm"][i].UnformatValue;
				}
				if (paramCol["M1maker_hbn"][i].UnformatValue != null)
				{
					ta080f02M1Form.M1maker_hbn = paramCol["M1maker_hbn"][i].UnformatValue;
				}
				if (paramCol["M1syonmk"][i].UnformatValue != null)
				{
					ta080f02M1Form.M1syonmk = paramCol["M1syonmk"][i].UnformatValue;
				}
				if (paramCol["M1iro_nm"][i].UnformatValue != null)
				{
					ta080f02M1Form.M1iro_nm = paramCol["M1iro_nm"][i].UnformatValue;
				}
				if (paramCol["M1size_nm"][i].UnformatValue != null)
				{
					ta080f02M1Form.M1size_nm = paramCol["M1size_nm"][i].UnformatValue;
				}
				if (paramCol["M1season_nm"][i].UnformatValue != null)
				{
					ta080f02M1Form.M1season_nm = paramCol["M1season_nm"][i].UnformatValue;
				}
				if (paramCol["M1jotai_kbn_nm"][i].UnformatValue != null)
				{
					ta080f02M1Form.M1jotai_kbn_nm = paramCol["M1jotai_kbn_nm"][i].UnformatValue;
				}
				if (paramCol["M1comment_nm"][i].UnformatValue != null)
				{
					ta080f02M1Form.M1comment_nm = paramCol["M1comment_nm"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					ta080f02M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					ta080f02M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					ta080f02M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Ta080f02Form formVO, StandardCheckManager checker)
		{
			if (formVO.Head_tenpo_cd != null)
			{
				checker.DoCheck("Head_tenpo_cd", formVO.Head_tenpo_cd);
			}
			if (formVO.Head_tenpo_nm != null)
			{
				checker.DoCheck("Head_tenpo_nm", formVO.Head_tenpo_nm);
			}
			if (formVO.Yosan_ymd != null)
			{
				checker.DoCheck("Yosan_ymd", formVO.Yosan_ymd);
			}
			if (formVO.Yosan_cd != null)
			{
				checker.DoCheck("Yosan_cd", formVO.Yosan_cd);
			}
			if (formVO.Yosan_nm != null)
			{
				checker.DoCheck("Yosan_nm", formVO.Yosan_nm);
			}
			if (formVO.Yosan_kin != null)
			{
				checker.DoCheck("Yosan_kin", formVO.Yosan_kin);
			}
			if (formVO.Misinsei_su != null)
			{
				checker.DoCheck("Misinsei_su", formVO.Misinsei_su);
			}
			if (formVO.Misinsei_kin != null)
			{
				checker.DoCheck("Misinsei_kin", formVO.Misinsei_kin);
			}
			if (formVO.Apply_su != null)
			{
				checker.DoCheck("Apply_su", formVO.Apply_su);
			}
			if (formVO.Apply_kin != null)
			{
				checker.DoCheck("Apply_kin", formVO.Apply_kin);
			}
			if (formVO.Jisseki_su_bo2 != null)
			{
				checker.DoCheck("Jisseki_su_bo2", formVO.Jisseki_su_bo2);
			}
			if (formVO.Jisseki_kin != null)
			{
				checker.DoCheck("Jisseki_kin", formVO.Jisseki_kin);
			}
			if (formVO.Zan_kin != null)
			{
				checker.DoCheck("Zan_kin", formVO.Zan_kin);
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
		public static void ValidateM1InputValue(Ta080f02Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Ta080f02M1Form ta080f02M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, ta080f02M1Form, i, m1List);
				if (ta080f02M1Form.M1hanbaiin_cd != null)
				{
					checker.DoCheck("M1hanbaiin_cd", ta080f02M1Form.M1hanbaiin_cd, i, m1List);
				}
				if (ta080f02M1Form.M1hanbaiin_nm != null)
				{
					checker.DoCheck("M1hanbaiin_nm", ta080f02M1Form.M1hanbaiin_nm, i, m1List);
				}
				if (ta080f02M1Form.M1irai_riyu != null)
				{
					checker.DoCheck("M1irai_riyu", ta080f02M1Form.M1irai_riyu, i, m1List);
				}
				if (ta080f02M1Form.M1bumonkana_nm != null)
				{
					checker.DoCheck("M1bumonkana_nm", ta080f02M1Form.M1bumonkana_nm, i, m1List);
				}
				if (ta080f02M1Form.M1hinsyu_ryaku_nm != null)
				{
					checker.DoCheck("M1hinsyu_ryaku_nm", ta080f02M1Form.M1hinsyu_ryaku_nm, i, m1List);
				}
				if (ta080f02M1Form.M1burando_nm != null)
				{
					checker.DoCheck("M1burando_nm", ta080f02M1Form.M1burando_nm, i, m1List);
				}
				if (ta080f02M1Form.M1maker_hbn != null)
				{
					checker.DoCheck("M1maker_hbn", ta080f02M1Form.M1maker_hbn, i, m1List);
				}
				if (ta080f02M1Form.M1syonmk != null)
				{
					checker.DoCheck("M1syonmk", ta080f02M1Form.M1syonmk, i, m1List);
				}
				if (ta080f02M1Form.M1iro_nm != null)
				{
					checker.DoCheck("M1iro_nm", ta080f02M1Form.M1iro_nm, i, m1List);
				}
				if (ta080f02M1Form.M1size_nm != null)
				{
					checker.DoCheck("M1size_nm", ta080f02M1Form.M1size_nm, i, m1List);
				}
				if (ta080f02M1Form.M1season_nm != null)
				{
					checker.DoCheck("M1season_nm", ta080f02M1Form.M1season_nm, i, m1List);
				}
				if (ta080f02M1Form.M1jotai_kbn_nm != null)
				{
					checker.DoCheck("M1jotai_kbn_nm", ta080f02M1Form.M1jotai_kbn_nm, i, m1List);
				}
				if (ta080f02M1Form.M1comment_nm != null)
				{
					checker.DoCheck("M1comment_nm", ta080f02M1Form.M1comment_nm, i, m1List);
				}
				if (ta080f02M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", ta080f02M1Form.M1selectorcheckbox, i, m1List);
				}
				if (ta080f02M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", ta080f02M1Form.M1entersyoriflg, i, m1List);
				}
				if (ta080f02M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", ta080f02M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Ta080f02Form formVO, StandardCodeCheckManager checker)
		{
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Ta080f02Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

