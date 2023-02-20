using com.xebio.bo.Tj180p01.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;

namespace com.xebio.bo.Tj180p01.Request
{
  /// <summary>
  /// Tj180f01RequestHelper の概要の説明です。
  /// </summary>
  public static class Tj180f01RequestHelper
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
			Tj180f01Form formVO = (Tj180f01Form)pageContext.GetFormVO();

			//カード部を初期化する
			paramCol.InitCardItems(formInfo.GetCardItems());
			//カード項目の入力値を取得する
			paramCol["Head_tenpo_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_nm"]);
			paramCol["Kijunbi_zen_tyobozaiko_su"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Kijunbi_zen_tyobozaiko_su"]);
			paramCol["Tojitsuuri_su"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tojitsuuri_su"]);
			paramCol["Tojitsunyusyukka_su"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tojitsunyusyukka_su"]);
			paramCol["Tojitsuyosokuzai_su"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tojitsuyosokuzai_su"]);
			paramCol["Tenpotanaorosi_su"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tenpotanaorosi_su"]);
			paramCol["Gyosyatanaorosi_su"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gyosyatanaorosi_su"]);
			paramCol["Sai_su"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Sai_su"]);
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
			Tj180f01Form formVO = (Tj180f01Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Kijunbi_zen_tyobozaiko_su"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Kijunbi_zen_tyobozaiko_su"].RequestValue, formInfo["Kijunbi_zen_tyobozaiko_su"]);
			paramCol["Tojitsuuri_su"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tojitsuuri_su"].RequestValue, formInfo["Tojitsuuri_su"]);
			paramCol["Tojitsunyusyukka_su"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tojitsunyusyukka_su"].RequestValue, formInfo["Tojitsunyusyukka_su"]);
			paramCol["Tojitsuyosokuzai_su"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tojitsuyosokuzai_su"].RequestValue, formInfo["Tojitsuyosokuzai_su"]);
			paramCol["Tenpotanaorosi_su"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tenpotanaorosi_su"].RequestValue, formInfo["Tenpotanaorosi_su"]);
			paramCol["Gyosyatanaorosi_su"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gyosyatanaorosi_su"].RequestValue, formInfo["Gyosyatanaorosi_su"]);
			paramCol["Sai_su"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Sai_su"].RequestValue, formInfo["Sai_su"]);
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
			Tj180f01Form formVO = (Tj180f01Form)pageContext.GetFormVO();

			//カード項目の入力値をFormVOにコピーする
			if (paramCol["Head_tenpo_cd"].UnformatValue != null)
			{
				formVO.Head_tenpo_cd = paramCol["Head_tenpo_cd"].UnformatValue;
			}
			if (paramCol["Head_tenpo_nm"].UnformatValue != null)
			{
				formVO.Head_tenpo_nm = paramCol["Head_tenpo_nm"].UnformatValue;
			}
			if (paramCol["Kijunbi_zen_tyobozaiko_su"].UnformatValue != null)
			{
				formVO.Kijunbi_zen_tyobozaiko_su = paramCol["Kijunbi_zen_tyobozaiko_su"].UnformatValue;
			}
			if (paramCol["Tojitsuuri_su"].UnformatValue != null)
			{
				formVO.Tojitsuuri_su = paramCol["Tojitsuuri_su"].UnformatValue;
			}
			if (paramCol["Tojitsunyusyukka_su"].UnformatValue != null)
			{
				formVO.Tojitsunyusyukka_su = paramCol["Tojitsunyusyukka_su"].UnformatValue;
			}
			if (paramCol["Tojitsuyosokuzai_su"].UnformatValue != null)
			{
				formVO.Tojitsuyosokuzai_su = paramCol["Tojitsuyosokuzai_su"].UnformatValue;
			}
			if (paramCol["Tenpotanaorosi_su"].UnformatValue != null)
			{
				formVO.Tenpotanaorosi_su = paramCol["Tenpotanaorosi_su"].UnformatValue;
			}
			if (paramCol["Gyosyatanaorosi_su"].UnformatValue != null)
			{
				formVO.Gyosyatanaorosi_su = paramCol["Gyosyatanaorosi_su"].UnformatValue;
			}
			if (paramCol["Sai_su"].UnformatValue != null)
			{
				formVO.Sai_su = paramCol["Sai_su"].UnformatValue;
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
		public static void ValidateCardInputValue(Tj180f01Form formVO, StandardCheckManager checker)
		{
			if (formVO.Head_tenpo_cd != null)
			{
				checker.DoCheck("Head_tenpo_cd", formVO.Head_tenpo_cd);
			}
			if (formVO.Head_tenpo_nm != null)
			{
				checker.DoCheck("Head_tenpo_nm", formVO.Head_tenpo_nm);
			}
			if (formVO.Kijunbi_zen_tyobozaiko_su != null)
			{
				checker.DoCheck("Kijunbi_zen_tyobozaiko_su", formVO.Kijunbi_zen_tyobozaiko_su);
			}
			if (formVO.Tojitsuuri_su != null)
			{
				checker.DoCheck("Tojitsuuri_su", formVO.Tojitsuuri_su);
			}
			if (formVO.Tojitsunyusyukka_su != null)
			{
				checker.DoCheck("Tojitsunyusyukka_su", formVO.Tojitsunyusyukka_su);
			}
			if (formVO.Tojitsuyosokuzai_su != null)
			{
				checker.DoCheck("Tojitsuyosokuzai_su", formVO.Tojitsuyosokuzai_su);
			}
			if (formVO.Tenpotanaorosi_su != null)
			{
				checker.DoCheck("Tenpotanaorosi_su", formVO.Tenpotanaorosi_su);
			}
			if (formVO.Gyosyatanaorosi_su != null)
			{
				checker.DoCheck("Gyosyatanaorosi_su", formVO.Gyosyatanaorosi_su);
			}
			if (formVO.Sai_su != null)
			{
				checker.DoCheck("Sai_su", formVO.Sai_su);
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
		public static void ValidateCardCodeValue(Tj180f01Form formVO, StandardCodeCheckManager checker)
		{
			checker.DoCheck("Btnheadtenpocd", formVO);
		}
	}
}

