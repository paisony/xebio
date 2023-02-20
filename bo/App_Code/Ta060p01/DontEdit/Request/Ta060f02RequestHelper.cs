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
  /// Ta060f02RequestHelper の概要の説明です。
  /// </summary>
  public static class Ta060f02RequestHelper
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
			Ta060f02Form formVO = (Ta060f02Form)pageContext.GetFormVO();

			//カード部を初期化する
			paramCol.InitCardItems(formInfo.GetCardItems());
			//明細「M1」部を初期化する
			paramCol.InitListItems(formInfo.GetListItems("M1"), formVO.GetList("M1").CurrentCount);
			//カード項目の入力値を取得する
			paramCol["Head_tenpo_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_nm"]);
			paramCol["Henko_kbn_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Henko_kbn_nm"]);
			paramCol["Bumon_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_cd"]);
			paramCol["Bumon_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_nm"]);
			paramCol["Kessai_ymd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Kessai_ymd"]);
			paramCol["Gokei_irai_su"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokei_irai_su"]);
			paramCol["Gokei_genkakin"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokei_genkakin"]);
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
				paramCol["M1hinsyu_ryaku_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hinsyu_ryaku_nm"]);
				paramCol["M1burando_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1burando_nm"]);
				paramCol["M1jisya_hbn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1jisya_hbn"]);
				paramCol["M1syohin_zokusei"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1syohin_zokusei"]);
				paramCol["M1maker_hbn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1maker_hbn"]);
				paramCol["M1syonmk"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1syonmk"]);
				paramCol["M1iro_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1iro_nm"]);
				paramCol["M1size_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1size_nm"]);
				paramCol["M1scan_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1scan_cd"]);
				paramCol["M1irai_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1irai_su"]);
				paramCol["M1genkakin"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1genkakin"]);
				paramCol["M1comment_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1comment_nm"]);
				paramCol["M1comment_nm2"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1comment_nm2"]);
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
			Ta060f02Form formVO = (Ta060f02Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Henko_kbn_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Henko_kbn_nm"].RequestValue, formInfo["Henko_kbn_nm"]);
			paramCol["Bumon_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_cd"].RequestValue, formInfo["Bumon_cd"]);
			paramCol["Bumon_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_nm"].RequestValue, formInfo["Bumon_nm"]);
			paramCol["Kessai_ymd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Kessai_ymd"].RequestValue, formInfo["Kessai_ymd"]);
			paramCol["Kessai_ymd"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Kessai_ymd"].RequestValue, formInfo["Kessai_ymd"]);
			paramCol["Gokei_irai_su"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokei_irai_su"].RequestValue, formInfo["Gokei_irai_su"]);
			paramCol["Gokei_genkakin"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokei_genkakin"].RequestValue, formInfo["Gokei_genkakin"]);
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
				paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hinsyu_ryaku_nm"][i].RequestValue, formInfo["M1hinsyu_ryaku_nm"]);
				paramCol["M1burando_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1burando_nm"][i].RequestValue, formInfo["M1burando_nm"]);
				paramCol["M1jisya_hbn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1jisya_hbn"][i].RequestValue, formInfo["M1jisya_hbn"]);
				paramCol["M1syohin_zokusei"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1syohin_zokusei"][i].RequestValue, formInfo["M1syohin_zokusei"]);
				paramCol["M1maker_hbn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1maker_hbn"][i].RequestValue, formInfo["M1maker_hbn"]);
				paramCol["M1syonmk"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1syonmk"][i].RequestValue, formInfo["M1syonmk"]);
				paramCol["M1iro_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1iro_nm"][i].RequestValue, formInfo["M1iro_nm"]);
				paramCol["M1size_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1size_nm"][i].RequestValue, formInfo["M1size_nm"]);
				paramCol["M1scan_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1scan_cd"][i].RequestValue, formInfo["M1scan_cd"]);
				paramCol["M1irai_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1irai_su"][i].RequestValue, formInfo["M1irai_su"]);
				paramCol["M1genkakin"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1genkakin"][i].RequestValue, formInfo["M1genkakin"]);
				paramCol["M1comment_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1comment_nm"][i].RequestValue, formInfo["M1comment_nm"]);
				paramCol["M1comment_nm2"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1comment_nm2"][i].RequestValue, formInfo["M1comment_nm2"]);
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
			Ta060f02Form formVO = (Ta060f02Form)pageContext.GetFormVO();

			//カード項目の入力値をFormVOにコピーする
			if (paramCol["Head_tenpo_cd"].UnformatValue != null)
			{
				formVO.Head_tenpo_cd = paramCol["Head_tenpo_cd"].UnformatValue;
			}
			if (paramCol["Head_tenpo_nm"].UnformatValue != null)
			{
				formVO.Head_tenpo_nm = paramCol["Head_tenpo_nm"].UnformatValue;
			}
			if (paramCol["Henko_kbn_nm"].UnformatValue != null)
			{
				formVO.Henko_kbn_nm = paramCol["Henko_kbn_nm"].UnformatValue;
			}
			if (paramCol["Bumon_cd"].UnformatValue != null)
			{
				formVO.Bumon_cd = paramCol["Bumon_cd"].UnformatValue;
			}
			if (paramCol["Bumon_nm"].UnformatValue != null)
			{
				formVO.Bumon_nm = paramCol["Bumon_nm"].UnformatValue;
			}
			if (paramCol["Kessai_ymd"].DateFullValue != null)
			{
				formVO.Kessai_ymd = paramCol["Kessai_ymd"].DateFullValue;
			}
			if (paramCol["Gokei_irai_su"].UnformatValue != null)
			{
				formVO.Gokei_irai_su = paramCol["Gokei_irai_su"].UnformatValue;
			}
			if (paramCol["Gokei_genkakin"].UnformatValue != null)
			{
				formVO.Gokei_genkakin = paramCol["Gokei_genkakin"].UnformatValue;
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
				Ta060f02M1Form ta060f02M1Form = (Ta060f02M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					ta060f02M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue != null)
				{
					ta060f02M1Form.M1hinsyu_ryaku_nm = paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue;
				}
				if (paramCol["M1burando_nm"][i].UnformatValue != null)
				{
					ta060f02M1Form.M1burando_nm = paramCol["M1burando_nm"][i].UnformatValue;
				}
				if (paramCol["M1jisya_hbn"][i].UnformatValue != null)
				{
					ta060f02M1Form.M1jisya_hbn = paramCol["M1jisya_hbn"][i].UnformatValue;
				}
				if (paramCol["M1syohin_zokusei"][i].UnformatValue != null)
				{
					ta060f02M1Form.M1syohin_zokusei = paramCol["M1syohin_zokusei"][i].UnformatValue;
				}
				if (paramCol["M1maker_hbn"][i].UnformatValue != null)
				{
					ta060f02M1Form.M1maker_hbn = paramCol["M1maker_hbn"][i].UnformatValue;
				}
				if (paramCol["M1syonmk"][i].UnformatValue != null)
				{
					ta060f02M1Form.M1syonmk = paramCol["M1syonmk"][i].UnformatValue;
				}
				if (paramCol["M1iro_nm"][i].UnformatValue != null)
				{
					ta060f02M1Form.M1iro_nm = paramCol["M1iro_nm"][i].UnformatValue;
				}
				if (paramCol["M1size_nm"][i].UnformatValue != null)
				{
					ta060f02M1Form.M1size_nm = paramCol["M1size_nm"][i].UnformatValue;
				}
				if (paramCol["M1scan_cd"][i].UnformatValue != null)
				{
					ta060f02M1Form.M1scan_cd = paramCol["M1scan_cd"][i].UnformatValue;
				}
				if (paramCol["M1irai_su"][i].UnformatValue != null)
				{
					ta060f02M1Form.M1irai_su = paramCol["M1irai_su"][i].UnformatValue;
				}
				if (paramCol["M1genkakin"][i].UnformatValue != null)
				{
					ta060f02M1Form.M1genkakin = paramCol["M1genkakin"][i].UnformatValue;
				}
				if (paramCol["M1comment_nm"][i].UnformatValue != null)
				{
					ta060f02M1Form.M1comment_nm = paramCol["M1comment_nm"][i].UnformatValue;
				}
				if (paramCol["M1comment_nm2"][i].UnformatValue != null)
				{
					ta060f02M1Form.M1comment_nm2 = paramCol["M1comment_nm2"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					ta060f02M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					ta060f02M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					ta060f02M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Ta060f02Form formVO, StandardCheckManager checker)
		{
			if (formVO.Head_tenpo_cd != null)
			{
				checker.DoCheck("Head_tenpo_cd", formVO.Head_tenpo_cd);
			}
			if (formVO.Head_tenpo_nm != null)
			{
				checker.DoCheck("Head_tenpo_nm", formVO.Head_tenpo_nm);
			}
			if (formVO.Henko_kbn_nm != null)
			{
				checker.DoCheck("Henko_kbn_nm", formVO.Henko_kbn_nm);
			}
			if (formVO.Bumon_cd != null)
			{
				checker.DoCheck("Bumon_cd", formVO.Bumon_cd);
			}
			if (formVO.Bumon_nm != null)
			{
				checker.DoCheck("Bumon_nm", formVO.Bumon_nm);
			}
			if (formVO.Kessai_ymd != null)
			{
				checker.DoCheck("Kessai_ymd", formVO.Kessai_ymd);
			}
			if (formVO.Gokei_irai_su != null)
			{
				checker.DoCheck("Gokei_irai_su", formVO.Gokei_irai_su);
			}
			if (formVO.Gokei_genkakin != null)
			{
				checker.DoCheck("Gokei_genkakin", formVO.Gokei_genkakin);
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
		public static void ValidateM1InputValue(Ta060f02Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Ta060f02M1Form ta060f02M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, ta060f02M1Form, i, m1List);
				if (ta060f02M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", ta060f02M1Form.M1rowno, i, m1List);
				}
				if (ta060f02M1Form.M1hinsyu_ryaku_nm != null)
				{
					checker.DoCheck("M1hinsyu_ryaku_nm", ta060f02M1Form.M1hinsyu_ryaku_nm, i, m1List);
				}
				if (ta060f02M1Form.M1burando_nm != null)
				{
					checker.DoCheck("M1burando_nm", ta060f02M1Form.M1burando_nm, i, m1List);
				}
				if (ta060f02M1Form.M1jisya_hbn != null)
				{
					checker.DoCheck("M1jisya_hbn", ta060f02M1Form.M1jisya_hbn, i, m1List);
				}
				if (ta060f02M1Form.M1syohin_zokusei != null)
				{
					checker.DoCheck("M1syohin_zokusei", ta060f02M1Form.M1syohin_zokusei, i, m1List);
				}
				if (ta060f02M1Form.M1maker_hbn != null)
				{
					checker.DoCheck("M1maker_hbn", ta060f02M1Form.M1maker_hbn, i, m1List);
				}
				if (ta060f02M1Form.M1syonmk != null)
				{
					checker.DoCheck("M1syonmk", ta060f02M1Form.M1syonmk, i, m1List);
				}
				if (ta060f02M1Form.M1iro_nm != null)
				{
					checker.DoCheck("M1iro_nm", ta060f02M1Form.M1iro_nm, i, m1List);
				}
				if (ta060f02M1Form.M1size_nm != null)
				{
					checker.DoCheck("M1size_nm", ta060f02M1Form.M1size_nm, i, m1List);
				}
				if (ta060f02M1Form.M1scan_cd != null)
				{
					checker.DoCheck("M1scan_cd", ta060f02M1Form.M1scan_cd, i, m1List);
				}
				if (ta060f02M1Form.M1irai_su != null)
				{
					checker.DoCheck("M1irai_su", ta060f02M1Form.M1irai_su, i, m1List);
				}
				if (ta060f02M1Form.M1genkakin != null)
				{
					checker.DoCheck("M1genkakin", ta060f02M1Form.M1genkakin, i, m1List);
				}
				if (ta060f02M1Form.M1comment_nm != null)
				{
					checker.DoCheck("M1comment_nm", ta060f02M1Form.M1comment_nm, i, m1List);
				}
				if (ta060f02M1Form.M1comment_nm2 != null)
				{
					checker.DoCheck("M1comment_nm2", ta060f02M1Form.M1comment_nm2, i, m1List);
				}
				if (ta060f02M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", ta060f02M1Form.M1selectorcheckbox, i, m1List);
				}
				if (ta060f02M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", ta060f02M1Form.M1entersyoriflg, i, m1List);
				}
				if (ta060f02M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", ta060f02M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Ta060f02Form formVO, StandardCodeCheckManager checker)
		{
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Ta060f02Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

