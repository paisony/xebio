using com.xebio.bo.Tg020p01.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;

namespace com.xebio.bo.Tg020p01.Request
{
  /// <summary>
  /// Tg020f01RequestHelper の概要の説明です。
  /// </summary>
  public static class Tg020f01RequestHelper
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
			Tg020f01Form formVO = (Tg020f01Form)pageContext.GetFormVO();

			//カード部を初期化する
			paramCol.InitCardItems(formInfo.GetCardItems());
			//カード項目の入力値を取得する
			paramCol["Head_tenpo_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_nm"]);
			paramCol["Waririt"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Waririt"]);
			paramCol["Maisu"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Maisu"]);
			paramCol["Inji_comment"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Inji_comment"]);
			paramCol["Inji_comment_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Inji_comment_nm"]);
			paramCol["Warigak"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Warigak"]);
			paramCol["Maisu2"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Maisu2"]);
			paramCol["Inji_comment2"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Inji_comment2"]);
			paramCol["Inji_comment_nm2"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Inji_comment_nm2"]);
			paramCol["Label_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Label_cd"]);
			paramCol["Label_ip"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Label_ip"]);
			paramCol["Label_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Label_nm"]);
			paramCol["Modeno"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Modeno"]);
			paramCol["Stkmodeno"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Stkmodeno"]);
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
			Tg020f01Form formVO = (Tg020f01Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Waririt"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Waririt"].RequestValue, formInfo["Waririt"]);
			paramCol["Maisu"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Maisu"].RequestValue, formInfo["Maisu"]);
			paramCol["Inji_comment"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Inji_comment"].RequestValue, formInfo["Inji_comment"]);
			paramCol["Inji_comment_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Inji_comment_nm"].RequestValue, formInfo["Inji_comment_nm"]);
			paramCol["Warigak"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Warigak"].RequestValue, formInfo["Warigak"]);
			paramCol["Maisu2"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Maisu2"].RequestValue, formInfo["Maisu2"]);
			paramCol["Inji_comment2"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Inji_comment2"].RequestValue, formInfo["Inji_comment2"]);
			paramCol["Inji_comment_nm2"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Inji_comment_nm2"].RequestValue, formInfo["Inji_comment_nm2"]);
			paramCol["Label_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Label_cd"].RequestValue, formInfo["Label_cd"]);
			paramCol["Label_ip"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Label_ip"].RequestValue, formInfo["Label_ip"]);
			paramCol["Label_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Label_nm"].RequestValue, formInfo["Label_nm"]);
			paramCol["Modeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Modeno"].RequestValue, formInfo["Modeno"]);
			paramCol["Stkmodeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Stkmodeno"].RequestValue, formInfo["Stkmodeno"]);
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
			Tg020f01Form formVO = (Tg020f01Form)pageContext.GetFormVO();

			//カード項目の入力値をFormVOにコピーする
			if (paramCol["Head_tenpo_cd"].UnformatValue != null)
			{
				formVO.Head_tenpo_cd = paramCol["Head_tenpo_cd"].UnformatValue;
			}
			if (paramCol["Head_tenpo_nm"].UnformatValue != null)
			{
				formVO.Head_tenpo_nm = paramCol["Head_tenpo_nm"].UnformatValue;
			}
			if (paramCol["Waririt"].UnformatValue != null)
			{
				formVO.Waririt = paramCol["Waririt"].UnformatValue;
			}
			if (paramCol["Maisu"].UnformatValue != null)
			{
				formVO.Maisu = paramCol["Maisu"].UnformatValue;
			}
			if (paramCol["Inji_comment"].UnformatValue != null)
			{
				formVO.Inji_comment = paramCol["Inji_comment"].UnformatValue;
			}
			if (paramCol["Inji_comment_nm"].UnformatValue != null)
			{
				formVO.Inji_comment_nm = paramCol["Inji_comment_nm"].UnformatValue;
			}
			if (paramCol["Warigak"].UnformatValue != null)
			{
				formVO.Warigak = paramCol["Warigak"].UnformatValue;
			}
			if (paramCol["Maisu2"].UnformatValue != null)
			{
				formVO.Maisu2 = paramCol["Maisu2"].UnformatValue;
			}
			if (paramCol["Inji_comment2"].UnformatValue != null)
			{
				formVO.Inji_comment2 = paramCol["Inji_comment2"].UnformatValue;
			}
			if (paramCol["Inji_comment_nm2"].UnformatValue != null)
			{
				formVO.Inji_comment_nm2 = paramCol["Inji_comment_nm2"].UnformatValue;
			}
			if (paramCol["Label_cd"].UnformatValue != null)
			{
				formVO.Label_cd = paramCol["Label_cd"].UnformatValue;
			}
			if (paramCol["Label_ip"].UnformatValue != null)
			{
				formVO.Label_ip = paramCol["Label_ip"].UnformatValue;
			}
			if (paramCol["Label_nm"].UnformatValue != null)
			{
				formVO.Label_nm = paramCol["Label_nm"].UnformatValue;
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
		}

		/// <summary>
		/// カード項目の入力値チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardInputValue(Tg020f01Form formVO, StandardCheckManager checker)
		{
			if (formVO.Head_tenpo_cd != null)
			{
				checker.DoCheck("Head_tenpo_cd", formVO.Head_tenpo_cd);
			}
			if (formVO.Head_tenpo_nm != null)
			{
				checker.DoCheck("Head_tenpo_nm", formVO.Head_tenpo_nm);
			}
			if (formVO.Waririt != null)
			{
				checker.DoCheck("Waririt", formVO.Waririt);
			}
			if (formVO.Maisu != null)
			{
				checker.DoCheck("Maisu", formVO.Maisu);
			}
			if (formVO.Inji_comment != null)
			{
				checker.DoCheck("Inji_comment", formVO.Inji_comment);
			}
			if (formVO.Inji_comment_nm != null)
			{
				checker.DoCheck("Inji_comment_nm", formVO.Inji_comment_nm);
			}
			if (formVO.Warigak != null)
			{
				checker.DoCheck("Warigak", formVO.Warigak);
			}
			if (formVO.Maisu2 != null)
			{
				checker.DoCheck("Maisu2", formVO.Maisu2);
			}
			if (formVO.Inji_comment2 != null)
			{
				checker.DoCheck("Inji_comment2", formVO.Inji_comment2);
			}
			if (formVO.Inji_comment_nm2 != null)
			{
				checker.DoCheck("Inji_comment_nm2", formVO.Inji_comment_nm2);
			}
			if (formVO.Label_cd != null)
			{
				checker.DoCheck("Label_cd", formVO.Label_cd);
			}
			if (formVO.Label_ip != null)
			{
				checker.DoCheck("Label_ip", formVO.Label_ip);
			}
			if (formVO.Label_nm != null)
			{
				checker.DoCheck("Label_nm", formVO.Label_nm);
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
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Tg020f01Form formVO, StandardCodeCheckManager checker)
		{
			checker.DoCheck("Btnheadtenpocd", formVO);
			checker.DoCheck("Btnlabel_cd", formVO);
		}
	}
}

