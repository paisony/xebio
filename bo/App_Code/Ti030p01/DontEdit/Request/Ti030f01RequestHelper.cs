using com.xebio.bo.Ti030p01.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;

namespace com.xebio.bo.Ti030p01.Request
{
  /// <summary>
  /// Ti030f01RequestHelper の概要の説明です。
  /// </summary>
  public static class Ti030f01RequestHelper
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
			Ti030f01Form formVO = (Ti030f01Form)pageContext.GetFormVO();

			//カード部を初期化する
			paramCol.InitCardItems(formInfo.GetCardItems());
			//カード項目の入力値を取得する
			paramCol["Head_tenpo_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_nm"]);
			paramCol["Syohizei_rtu1"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Syohizei_rtu1"]);
			paramCol["Syohizeikaisi_ymd1"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Syohizeikaisi_ymd1"]);
			paramCol["Zeisyori_kb1"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Zeisyori_kb1"]);
			paramCol["Syohizei_rtu2"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Syohizei_rtu2"]);
			paramCol["Syohizeikaisi_ymd2"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Syohizeikaisi_ymd2"]);
			paramCol["Zeisyori_kb2"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Zeisyori_kb2"]);
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
			Ti030f01Form formVO = (Ti030f01Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Syohizei_rtu1"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Syohizei_rtu1"].RequestValue, formInfo["Syohizei_rtu1"]);
			paramCol["Syohizeikaisi_ymd1"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Syohizeikaisi_ymd1"].RequestValue, formInfo["Syohizeikaisi_ymd1"]);
			paramCol["Syohizeikaisi_ymd1"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Syohizeikaisi_ymd1"].RequestValue, formInfo["Syohizeikaisi_ymd1"]);
			paramCol["Zeisyori_kb1"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Zeisyori_kb1"].RequestValue, formInfo["Zeisyori_kb1"]);
			paramCol["Syohizei_rtu2"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Syohizei_rtu2"].RequestValue, formInfo["Syohizei_rtu2"]);
			paramCol["Syohizeikaisi_ymd2"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Syohizeikaisi_ymd2"].RequestValue, formInfo["Syohizeikaisi_ymd2"]);
			paramCol["Syohizeikaisi_ymd2"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Syohizeikaisi_ymd2"].RequestValue, formInfo["Syohizeikaisi_ymd2"]);
			paramCol["Zeisyori_kb2"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Zeisyori_kb2"].RequestValue, formInfo["Zeisyori_kb2"]);
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
			Ti030f01Form formVO = (Ti030f01Form)pageContext.GetFormVO();

			//カード項目の入力値をFormVOにコピーする
			if (paramCol["Head_tenpo_cd"].UnformatValue != null)
			{
				formVO.Head_tenpo_cd = paramCol["Head_tenpo_cd"].UnformatValue;
			}
			if (paramCol["Head_tenpo_nm"].UnformatValue != null)
			{
				formVO.Head_tenpo_nm = paramCol["Head_tenpo_nm"].UnformatValue;
			}
			if (paramCol["Syohizei_rtu1"].UnformatValue != null)
			{
				formVO.Syohizei_rtu1 = paramCol["Syohizei_rtu1"].UnformatValue;
			}
			if (paramCol["Syohizeikaisi_ymd1"].DateFullValue != null)
			{
				formVO.Syohizeikaisi_ymd1 = paramCol["Syohizeikaisi_ymd1"].DateFullValue;
			}
			if (paramCol["Zeisyori_kb1"].UnformatValue != null)
			{
				formVO.Zeisyori_kb1 = paramCol["Zeisyori_kb1"].UnformatValue;
			}
			if (paramCol["Syohizei_rtu2"].UnformatValue != null)
			{
				formVO.Syohizei_rtu2 = paramCol["Syohizei_rtu2"].UnformatValue;
			}
			if (paramCol["Syohizeikaisi_ymd2"].DateFullValue != null)
			{
				formVO.Syohizeikaisi_ymd2 = paramCol["Syohizeikaisi_ymd2"].DateFullValue;
			}
			if (paramCol["Zeisyori_kb2"].UnformatValue != null)
			{
				formVO.Zeisyori_kb2 = paramCol["Zeisyori_kb2"].UnformatValue;
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
		public static void ValidateCardInputValue(Ti030f01Form formVO, StandardCheckManager checker)
		{
			if (formVO.Head_tenpo_cd != null)
			{
				checker.DoCheck("Head_tenpo_cd", formVO.Head_tenpo_cd);
			}
			if (formVO.Head_tenpo_nm != null)
			{
				checker.DoCheck("Head_tenpo_nm", formVO.Head_tenpo_nm);
			}
			if (formVO.Syohizei_rtu1 != null)
			{
				checker.DoCheck("Syohizei_rtu1", formVO.Syohizei_rtu1);
			}
			if (formVO.Syohizeikaisi_ymd1 != null)
			{
				checker.DoCheck("Syohizeikaisi_ymd1", formVO.Syohizeikaisi_ymd1);
			}
			if (formVO.Zeisyori_kb1 != null)
			{
				checker.DoCheck("Zeisyori_kb1", formVO.Zeisyori_kb1);
			}
			if (formVO.Syohizei_rtu2 != null)
			{
				checker.DoCheck("Syohizei_rtu2", formVO.Syohizei_rtu2);
			}
			if (formVO.Syohizeikaisi_ymd2 != null)
			{
				checker.DoCheck("Syohizeikaisi_ymd2", formVO.Syohizeikaisi_ymd2);
			}
			if (formVO.Zeisyori_kb2 != null)
			{
				checker.DoCheck("Zeisyori_kb2", formVO.Zeisyori_kb2);
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
		public static void ValidateCardCodeValue(Ti030f01Form formVO, StandardCodeCheckManager checker)
		{
			checker.DoCheck("Btnheadtenpocd", formVO);
		}
	}
}

