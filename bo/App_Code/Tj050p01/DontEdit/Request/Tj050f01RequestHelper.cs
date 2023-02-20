using com.xebio.bo.Tj050p01.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;

namespace com.xebio.bo.Tj050p01.Request
{
  /// <summary>
  /// Tj050f01RequestHelper の概要の説明です。
  /// </summary>
  public static class Tj050f01RequestHelper
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
			Tj050f01Form formVO = (Tj050f01Form)pageContext.GetFormVO();

			//カード部を初期化する
			paramCol.InitCardItems(formInfo.GetCardItems());
			//カード項目の入力値を取得する
			paramCol["Head_tenpo_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_nm"]);
			paramCol["Modeno"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Modeno"]);
			paramCol["Stkmodeno"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Stkmodeno"]);
			paramCol["Tanaorosikijun_ymd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tanaorosikijun_ymd"]);
			paramCol["Tanaorosijissi_ymd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tanaorosijissi_ymd"]);
			paramCol["Tanaorosikikan_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tanaorosikikan_from"]);
			paramCol["Tanaorosikikan_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tanaorosikikan_to"]);
			paramCol["Tanaorosikijun_ymd1"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tanaorosikijun_ymd1"]);
			paramCol["Tanaorosijissi_ymd1"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tanaorosijissi_ymd1"]);
			paramCol["Tanaorosikikan_from1"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tanaorosikikan_from1"]);
			paramCol["Tanaorosikikan_to1"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tanaorosikikan_to1"]);
			paramCol["Tanaorosi_hokokusyo_kb"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tanaorosi_hokokusyo_kb"]);
			SCSubBasePage scPage = (SCSubBasePage)page;
			if(StandardBaseCheckManager.CheckUseSelfCustomize()){
				// カード部カスタム項目の値を取得する
				scPage.GetCardRequestValue(paramCol);
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
			Tj050f01Form formVO = (Tj050f01Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Modeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Modeno"].RequestValue, formInfo["Modeno"]);
			paramCol["Stkmodeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Stkmodeno"].RequestValue, formInfo["Stkmodeno"]);
			paramCol["Tanaorosikijun_ymd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tanaorosikijun_ymd"].RequestValue, formInfo["Tanaorosikijun_ymd"]);
			paramCol["Tanaorosikijun_ymd"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Tanaorosikijun_ymd"].RequestValue, formInfo["Tanaorosikijun_ymd"]);
			paramCol["Tanaorosijissi_ymd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tanaorosijissi_ymd"].RequestValue, formInfo["Tanaorosijissi_ymd"]);
			paramCol["Tanaorosijissi_ymd"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Tanaorosijissi_ymd"].RequestValue, formInfo["Tanaorosijissi_ymd"]);
			paramCol["Tanaorosikikan_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tanaorosikikan_from"].RequestValue, formInfo["Tanaorosikikan_from"]);
			paramCol["Tanaorosikikan_from"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Tanaorosikikan_from"].RequestValue, formInfo["Tanaorosikikan_from"]);
			paramCol["Tanaorosikikan_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tanaorosikikan_to"].RequestValue, formInfo["Tanaorosikikan_to"]);
			paramCol["Tanaorosikikan_to"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Tanaorosikikan_to"].RequestValue, formInfo["Tanaorosikikan_to"]);
			paramCol["Tanaorosikijun_ymd1"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tanaorosikijun_ymd1"].RequestValue, formInfo["Tanaorosikijun_ymd1"]);
			paramCol["Tanaorosikijun_ymd1"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Tanaorosikijun_ymd1"].RequestValue, formInfo["Tanaorosikijun_ymd1"]);
			paramCol["Tanaorosijissi_ymd1"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tanaorosijissi_ymd1"].RequestValue, formInfo["Tanaorosijissi_ymd1"]);
			paramCol["Tanaorosijissi_ymd1"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Tanaorosijissi_ymd1"].RequestValue, formInfo["Tanaorosijissi_ymd1"]);
			paramCol["Tanaorosikikan_from1"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tanaorosikikan_from1"].RequestValue, formInfo["Tanaorosikikan_from1"]);
			paramCol["Tanaorosikikan_from1"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Tanaorosikikan_from1"].RequestValue, formInfo["Tanaorosikikan_from1"]);
			paramCol["Tanaorosikikan_to1"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tanaorosikikan_to1"].RequestValue, formInfo["Tanaorosikikan_to1"]);
			paramCol["Tanaorosikikan_to1"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Tanaorosikikan_to1"].RequestValue, formInfo["Tanaorosikikan_to1"]);
			paramCol["Tanaorosi_hokokusyo_kb"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tanaorosi_hokokusyo_kb"].RequestValue, formInfo["Tanaorosi_hokokusyo_kb"]);
			SCSubBasePage page = (SCSubBasePage)HttpContext.Current.Handler;
			if(StandardBaseCheckManager.CheckUseSelfCustomize()){
				// カード部カスタム項目のアンフォーマット値を取得する
				page.UnformatCard(paramCol);
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
			Tj050f01Form formVO = (Tj050f01Form)pageContext.GetFormVO();

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
			if (paramCol["Tanaorosikijun_ymd"].DateFullValue != null)
			{
				formVO.Tanaorosikijun_ymd = paramCol["Tanaorosikijun_ymd"].DateFullValue;
			}
			if (paramCol["Tanaorosijissi_ymd"].DateFullValue != null)
			{
				formVO.Tanaorosijissi_ymd = paramCol["Tanaorosijissi_ymd"].DateFullValue;
			}
			if (paramCol["Tanaorosikikan_from"].DateFullValue != null)
			{
				formVO.Tanaorosikikan_from = paramCol["Tanaorosikikan_from"].DateFullValue;
			}
			if (paramCol["Tanaorosikikan_to"].DateFullValue != null)
			{
				formVO.Tanaorosikikan_to = paramCol["Tanaorosikikan_to"].DateFullValue;
			}
			if (paramCol["Tanaorosikijun_ymd1"].DateFullValue != null)
			{
				formVO.Tanaorosikijun_ymd1 = paramCol["Tanaorosikijun_ymd1"].DateFullValue;
			}
			if (paramCol["Tanaorosijissi_ymd1"].DateFullValue != null)
			{
				formVO.Tanaorosijissi_ymd1 = paramCol["Tanaorosijissi_ymd1"].DateFullValue;
			}
			if (paramCol["Tanaorosikikan_from1"].DateFullValue != null)
			{
				formVO.Tanaorosikikan_from1 = paramCol["Tanaorosikikan_from1"].DateFullValue;
			}
			if (paramCol["Tanaorosikikan_to1"].DateFullValue != null)
			{
				formVO.Tanaorosikikan_to1 = paramCol["Tanaorosikikan_to1"].DateFullValue;
			}
			if (paramCol["Tanaorosi_hokokusyo_kb"].UnformatValue != null)
			{
				formVO.Tanaorosi_hokokusyo_kb = paramCol["Tanaorosi_hokokusyo_kb"].UnformatValue;
			}
			if(StandardBaseCheckManager.CheckUseSelfCustomize()){
				// カード部カスタム項目の入力値をFormVOにコピーする
				SCSubBasePage page = (SCSubBasePage)HttpContext.Current.Handler;
				page.CopyCardForm(paramCol, formVO);
			}
		}

		/// <summary>
		/// カード項目の入力値チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardInputValue(Tj050f01Form formVO, StandardCheckManager checker)
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
			if (formVO.Tanaorosikijun_ymd != null)
			{
				checker.DoCheck("Tanaorosikijun_ymd", formVO.Tanaorosikijun_ymd);
			}
			if (formVO.Tanaorosijissi_ymd != null)
			{
				checker.DoCheck("Tanaorosijissi_ymd", formVO.Tanaorosijissi_ymd);
			}
			if (formVO.Tanaorosikikan_from != null)
			{
				checker.DoCheck("Tanaorosikikan_from", formVO.Tanaorosikikan_from);
			}
			if (formVO.Tanaorosikikan_to != null)
			{
				checker.DoCheck("Tanaorosikikan_to", formVO.Tanaorosikikan_to);
			}
			if (formVO.Tanaorosikijun_ymd1 != null)
			{
				checker.DoCheck("Tanaorosikijun_ymd1", formVO.Tanaorosikijun_ymd1);
			}
			if (formVO.Tanaorosijissi_ymd1 != null)
			{
				checker.DoCheck("Tanaorosijissi_ymd1", formVO.Tanaorosijissi_ymd1);
			}
			if (formVO.Tanaorosikikan_from1 != null)
			{
				checker.DoCheck("Tanaorosikikan_from1", formVO.Tanaorosikikan_from1);
			}
			if (formVO.Tanaorosikikan_to1 != null)
			{
				checker.DoCheck("Tanaorosikikan_to1", formVO.Tanaorosikikan_to1);
			}
			if (formVO.Tanaorosi_hokokusyo_kb != null)
			{
				checker.DoCheck("Tanaorosi_hokokusyo_kb", formVO.Tanaorosi_hokokusyo_kb);
			}
			if(StandardBaseCheckManager.CheckUseSelfCustomize()){
				// カード部カスタム項目の入力チェックを実行
				((SCSubBasePage)HttpContext.Current.Handler).CheckCardItems(checker, formVO);
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Tj050f01Form formVO, StandardCodeCheckManager checker)
		{
			checker.DoCheck("Btnheadtenpocd", formVO);
		}
	}
}

