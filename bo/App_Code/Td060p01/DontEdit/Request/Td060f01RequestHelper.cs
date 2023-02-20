using com.xebio.bo.Td060p01.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;

namespace com.xebio.bo.Td060p01.Request
{
  /// <summary>
  /// Td060f01RequestHelper の概要の説明です。
  /// </summary>
  public static class Td060f01RequestHelper
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
			Td060f01Form formVO = (Td060f01Form)pageContext.GetFormVO();

			//カード部を初期化する
			paramCol.InitCardItems(formInfo.GetCardItems());
			//カード項目の入力値を取得する
			paramCol["Head_tenpo_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_nm"]);
			paramCol["Shuturyoku_kbn"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Shuturyoku_kbn"]);
			paramCol["Change_ymd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Change_ymd_from"]);
			paramCol["Change_ymd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Change_ymd_to"]);
			paramCol["Change_ymd_hdn"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Change_ymd_hdn"]);
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
			Td060f01Form formVO = (Td060f01Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Shuturyoku_kbn"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Shuturyoku_kbn"].RequestValue, formInfo["Shuturyoku_kbn"]);
			paramCol["Change_ymd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Change_ymd_from"].RequestValue, formInfo["Change_ymd_from"]);
			paramCol["Change_ymd_from"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Change_ymd_from"].RequestValue, formInfo["Change_ymd_from"]);
			paramCol["Change_ymd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Change_ymd_to"].RequestValue, formInfo["Change_ymd_to"]);
			paramCol["Change_ymd_to"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Change_ymd_to"].RequestValue, formInfo["Change_ymd_to"]);
			paramCol["Change_ymd_hdn"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Change_ymd_hdn"].RequestValue, formInfo["Change_ymd_hdn"]);
			paramCol["Change_ymd_hdn"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Change_ymd_hdn"].RequestValue, formInfo["Change_ymd_hdn"]);
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
			Td060f01Form formVO = (Td060f01Form)pageContext.GetFormVO();

			//カード項目の入力値をFormVOにコピーする
			if (paramCol["Head_tenpo_cd"].UnformatValue != null)
			{
				formVO.Head_tenpo_cd = paramCol["Head_tenpo_cd"].UnformatValue;
			}
			if (paramCol["Head_tenpo_nm"].UnformatValue != null)
			{
				formVO.Head_tenpo_nm = paramCol["Head_tenpo_nm"].UnformatValue;
			}
			if (paramCol["Shuturyoku_kbn"].UnformatValue != null)
			{
				formVO.Shuturyoku_kbn = paramCol["Shuturyoku_kbn"].UnformatValue;
			}
			if (paramCol["Change_ymd_from"].DateFullValue != null)
			{
				formVO.Change_ymd_from = paramCol["Change_ymd_from"].DateFullValue;
			}
			if (paramCol["Change_ymd_to"].DateFullValue != null)
			{
				formVO.Change_ymd_to = paramCol["Change_ymd_to"].DateFullValue;
			}
			if (paramCol["Change_ymd_hdn"].DateFullValue != null)
			{
				formVO.Change_ymd_hdn = paramCol["Change_ymd_hdn"].DateFullValue;
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
		public static void ValidateCardInputValue(Td060f01Form formVO, StandardCheckManager checker)
		{
			if (formVO.Head_tenpo_cd != null)
			{
				checker.DoCheck("Head_tenpo_cd", formVO.Head_tenpo_cd);
			}
			if (formVO.Head_tenpo_nm != null)
			{
				checker.DoCheck("Head_tenpo_nm", formVO.Head_tenpo_nm);
			}
			if (formVO.Shuturyoku_kbn != null)
			{
				checker.DoCheck("Shuturyoku_kbn", formVO.Shuturyoku_kbn);
			}
			if (formVO.Change_ymd_from != null)
			{
				checker.DoCheck("Change_ymd_from", formVO.Change_ymd_from);
			}
			if (formVO.Change_ymd_to != null)
			{
				checker.DoCheck("Change_ymd_to", formVO.Change_ymd_to);
			}
			if (formVO.Change_ymd_hdn != null)
			{
				checker.DoCheck("Change_ymd_hdn", formVO.Change_ymd_hdn);
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
		public static void ValidateCardCodeValue(Td060f01Form formVO, StandardCodeCheckManager checker)
		{
			checker.DoCheck("Btnheadtenpocd", formVO);
		}
	}
}

