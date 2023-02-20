using com.xebio.bo.Tf020p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Tf020p01.Request
{
  /// <summary>
  /// Tf020f01RequestHelper の概要の説明です。
  /// </summary>
  public static class Tf020f01RequestHelper
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
			Tf020f01Form formVO = (Tf020f01Form)pageContext.GetFormVO();

			//カード部を初期化する
			paramCol.InitCardItems(formInfo.GetCardItems());
			//明細「M1」部を初期化する
			paramCol.InitListItems(formInfo.GetListItems("M1"), formVO.GetList("M1").CurrentCount);
			//カード項目の入力値を取得する
			paramCol["Head_tenpo_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_nm"]);
			paramCol["Modeno"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Modeno"]);
			paramCol["Stkmodeno"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Stkmodeno"]);
			paramCol["Syonin_flg"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Syonin_flg"]);
			paramCol["Apply_ymd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Apply_ymd_from"]);
			paramCol["Apply_ymd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Apply_ymd_to"]);
			paramCol["Kakutei_ymd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Kakutei_ymd_from"]);
			paramCol["Kakutei_ymd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Kakutei_ymd_to"]);
			paramCol["Denpyo_bango_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Denpyo_bango_from"]);
			paramCol["Denpyo_bango_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Denpyo_bango_to"]);
			paramCol["Kamoku_cd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Kamoku_cd_from"]);
			paramCol["Kamoku_nm_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Kamoku_nm_from"]);
			paramCol["Kamoku_cd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Kamoku_cd_to"]);
			paramCol["Kamoku_nm_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Kamoku_nm_to"]);
			paramCol["Sinseitan_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Sinseitan_cd"]);
			paramCol["Sinseitan_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Sinseitan_nm"]);
			paramCol["Jyuri_no_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Jyuri_no_from"]);
			paramCol["Jyuri_no_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Jyuri_no_to"]);
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
				paramCol["M1apply_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1apply_ymd"]);
				paramCol["M1kakutei_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1kakutei_ymd"]);
				paramCol["M1kamoku_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1kamoku_cd"]);
				paramCol["M1kamoku_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1kamoku_nm"]);
				paramCol["M1itemsu"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1itemsu"]);
				paramCol["M1genkakin"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1genkakin"]);
				paramCol["M1baika_tnk"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1baika_tnk"]);
				paramCol["M1sinseitan_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1sinseitan_nm"]);
				paramCol["M1jyuri_no"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1jyuri_no"]);
				paramCol["M1syonin_flg_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1syonin_flg_nm"]);
				paramCol["M1sinseiriyu"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1sinseiriyu"]);
				paramCol["M1kyakkariyu"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1kyakkariyu"]);
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
			Tf020f01Form formVO = (Tf020f01Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Modeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Modeno"].RequestValue, formInfo["Modeno"]);
			paramCol["Stkmodeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Stkmodeno"].RequestValue, formInfo["Stkmodeno"]);
			paramCol["Syonin_flg"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Syonin_flg"].RequestValue, formInfo["Syonin_flg"]);
			paramCol["Apply_ymd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Apply_ymd_from"].RequestValue, formInfo["Apply_ymd_from"]);
			paramCol["Apply_ymd_from"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Apply_ymd_from"].RequestValue, formInfo["Apply_ymd_from"]);
			paramCol["Apply_ymd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Apply_ymd_to"].RequestValue, formInfo["Apply_ymd_to"]);
			paramCol["Apply_ymd_to"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Apply_ymd_to"].RequestValue, formInfo["Apply_ymd_to"]);
			paramCol["Kakutei_ymd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Kakutei_ymd_from"].RequestValue, formInfo["Kakutei_ymd_from"]);
			paramCol["Kakutei_ymd_from"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Kakutei_ymd_from"].RequestValue, formInfo["Kakutei_ymd_from"]);
			paramCol["Kakutei_ymd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Kakutei_ymd_to"].RequestValue, formInfo["Kakutei_ymd_to"]);
			paramCol["Kakutei_ymd_to"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Kakutei_ymd_to"].RequestValue, formInfo["Kakutei_ymd_to"]);
			paramCol["Denpyo_bango_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Denpyo_bango_from"].RequestValue, formInfo["Denpyo_bango_from"]);
			paramCol["Denpyo_bango_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Denpyo_bango_to"].RequestValue, formInfo["Denpyo_bango_to"]);
			paramCol["Kamoku_cd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Kamoku_cd_from"].RequestValue, formInfo["Kamoku_cd_from"]);
			paramCol["Kamoku_nm_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Kamoku_nm_from"].RequestValue, formInfo["Kamoku_nm_from"]);
			paramCol["Kamoku_cd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Kamoku_cd_to"].RequestValue, formInfo["Kamoku_cd_to"]);
			paramCol["Kamoku_nm_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Kamoku_nm_to"].RequestValue, formInfo["Kamoku_nm_to"]);
			paramCol["Sinseitan_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Sinseitan_cd"].RequestValue, formInfo["Sinseitan_cd"]);
			paramCol["Sinseitan_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Sinseitan_nm"].RequestValue, formInfo["Sinseitan_nm"]);
			paramCol["Jyuri_no_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Jyuri_no_from"].RequestValue, formInfo["Jyuri_no_from"]);
			paramCol["Jyuri_no_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Jyuri_no_to"].RequestValue, formInfo["Jyuri_no_to"]);
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
				paramCol["M1apply_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1apply_ymd"][i].RequestValue, formInfo["M1apply_ymd"]);
				paramCol["M1apply_ymd"][i].DateFullValue = RequestParameterUtil.GetDateFullValue(
					paramCol["M1apply_ymd"][i].RequestValue, formInfo["M1apply_ymd"]);
				paramCol["M1kakutei_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1kakutei_ymd"][i].RequestValue, formInfo["M1kakutei_ymd"]);
				paramCol["M1kakutei_ymd"][i].DateFullValue = RequestParameterUtil.GetDateFullValue(
					paramCol["M1kakutei_ymd"][i].RequestValue, formInfo["M1kakutei_ymd"]);
				paramCol["M1kamoku_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1kamoku_cd"][i].RequestValue, formInfo["M1kamoku_cd"]);
				paramCol["M1kamoku_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1kamoku_nm"][i].RequestValue, formInfo["M1kamoku_nm"]);
				paramCol["M1itemsu"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1itemsu"][i].RequestValue, formInfo["M1itemsu"]);
				paramCol["M1genkakin"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1genkakin"][i].RequestValue, formInfo["M1genkakin"]);
				paramCol["M1baika_tnk"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1baika_tnk"][i].RequestValue, formInfo["M1baika_tnk"]);
				paramCol["M1sinseitan_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1sinseitan_nm"][i].RequestValue, formInfo["M1sinseitan_nm"]);
				paramCol["M1jyuri_no"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1jyuri_no"][i].RequestValue, formInfo["M1jyuri_no"]);
				paramCol["M1syonin_flg_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1syonin_flg_nm"][i].RequestValue, formInfo["M1syonin_flg_nm"]);
				paramCol["M1sinseiriyu"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1sinseiriyu"][i].RequestValue, formInfo["M1sinseiriyu"]);
				paramCol["M1kyakkariyu"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1kyakkariyu"][i].RequestValue, formInfo["M1kyakkariyu"]);
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
			Tf020f01Form formVO = (Tf020f01Form)pageContext.GetFormVO();

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
			if (paramCol["Syonin_flg"].UnformatValue != null)
			{
				formVO.Syonin_flg = paramCol["Syonin_flg"].UnformatValue;
			}
			if (paramCol["Apply_ymd_from"].DateFullValue != null)
			{
				formVO.Apply_ymd_from = paramCol["Apply_ymd_from"].DateFullValue;
			}
			if (paramCol["Apply_ymd_to"].DateFullValue != null)
			{
				formVO.Apply_ymd_to = paramCol["Apply_ymd_to"].DateFullValue;
			}
			if (paramCol["Kakutei_ymd_from"].DateFullValue != null)
			{
				formVO.Kakutei_ymd_from = paramCol["Kakutei_ymd_from"].DateFullValue;
			}
			if (paramCol["Kakutei_ymd_to"].DateFullValue != null)
			{
				formVO.Kakutei_ymd_to = paramCol["Kakutei_ymd_to"].DateFullValue;
			}
			if (paramCol["Denpyo_bango_from"].UnformatValue != null)
			{
				formVO.Denpyo_bango_from = paramCol["Denpyo_bango_from"].UnformatValue;
			}
			if (paramCol["Denpyo_bango_to"].UnformatValue != null)
			{
				formVO.Denpyo_bango_to = paramCol["Denpyo_bango_to"].UnformatValue;
			}
			if (paramCol["Kamoku_cd_from"].UnformatValue != null)
			{
				formVO.Kamoku_cd_from = paramCol["Kamoku_cd_from"].UnformatValue;
			}
			if (paramCol["Kamoku_nm_from"].UnformatValue != null)
			{
				formVO.Kamoku_nm_from = paramCol["Kamoku_nm_from"].UnformatValue;
			}
			if (paramCol["Kamoku_cd_to"].UnformatValue != null)
			{
				formVO.Kamoku_cd_to = paramCol["Kamoku_cd_to"].UnformatValue;
			}
			if (paramCol["Kamoku_nm_to"].UnformatValue != null)
			{
				formVO.Kamoku_nm_to = paramCol["Kamoku_nm_to"].UnformatValue;
			}
			if (paramCol["Sinseitan_cd"].UnformatValue != null)
			{
				formVO.Sinseitan_cd = paramCol["Sinseitan_cd"].UnformatValue;
			}
			if (paramCol["Sinseitan_nm"].UnformatValue != null)
			{
				formVO.Sinseitan_nm = paramCol["Sinseitan_nm"].UnformatValue;
			}
			if (paramCol["Jyuri_no_from"].UnformatValue != null)
			{
				formVO.Jyuri_no_from = paramCol["Jyuri_no_from"].UnformatValue;
			}
			if (paramCol["Jyuri_no_to"].UnformatValue != null)
			{
				formVO.Jyuri_no_to = paramCol["Jyuri_no_to"].UnformatValue;
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
				Tf020f01M1Form tf020f01M1Form = (Tf020f01M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					tf020f01M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1apply_ymd"][i].DateFullValue != null)
				{
					tf020f01M1Form.M1apply_ymd = paramCol["M1apply_ymd"][i].DateFullValue;
				}
				if (paramCol["M1kakutei_ymd"][i].DateFullValue != null)
				{
					tf020f01M1Form.M1kakutei_ymd = paramCol["M1kakutei_ymd"][i].DateFullValue;
				}
				if (paramCol["M1kamoku_cd"][i].UnformatValue != null)
				{
					tf020f01M1Form.M1kamoku_cd = paramCol["M1kamoku_cd"][i].UnformatValue;
				}
				if (paramCol["M1kamoku_nm"][i].UnformatValue != null)
				{
					tf020f01M1Form.M1kamoku_nm = paramCol["M1kamoku_nm"][i].UnformatValue;
				}
				if (paramCol["M1itemsu"][i].UnformatValue != null)
				{
					tf020f01M1Form.M1itemsu = paramCol["M1itemsu"][i].UnformatValue;
				}
				if (paramCol["M1genkakin"][i].UnformatValue != null)
				{
					tf020f01M1Form.M1genkakin = paramCol["M1genkakin"][i].UnformatValue;
				}
				if (paramCol["M1baika_tnk"][i].UnformatValue != null)
				{
					tf020f01M1Form.M1baika_tnk = paramCol["M1baika_tnk"][i].UnformatValue;
				}
				if (paramCol["M1sinseitan_nm"][i].UnformatValue != null)
				{
					tf020f01M1Form.M1sinseitan_nm = paramCol["M1sinseitan_nm"][i].UnformatValue;
				}
				if (paramCol["M1jyuri_no"][i].UnformatValue != null)
				{
					tf020f01M1Form.M1jyuri_no = paramCol["M1jyuri_no"][i].UnformatValue;
				}
				if (paramCol["M1syonin_flg_nm"][i].UnformatValue != null)
				{
					tf020f01M1Form.M1syonin_flg_nm = paramCol["M1syonin_flg_nm"][i].UnformatValue;
				}
				if (paramCol["M1sinseiriyu"][i].UnformatValue != null)
				{
					tf020f01M1Form.M1sinseiriyu = paramCol["M1sinseiriyu"][i].UnformatValue;
				}
				if (paramCol["M1kyakkariyu"][i].UnformatValue != null)
				{
					tf020f01M1Form.M1kyakkariyu = paramCol["M1kyakkariyu"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					tf020f01M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					tf020f01M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					tf020f01M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Tf020f01Form formVO, StandardCheckManager checker)
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
			if (formVO.Syonin_flg != null)
			{
				checker.DoCheck("Syonin_flg", formVO.Syonin_flg);
			}
			if (formVO.Apply_ymd_from != null)
			{
				checker.DoCheck("Apply_ymd_from", formVO.Apply_ymd_from);
			}
			if (formVO.Apply_ymd_to != null)
			{
				checker.DoCheck("Apply_ymd_to", formVO.Apply_ymd_to);
			}
			if (formVO.Kakutei_ymd_from != null)
			{
				checker.DoCheck("Kakutei_ymd_from", formVO.Kakutei_ymd_from);
			}
			if (formVO.Kakutei_ymd_to != null)
			{
				checker.DoCheck("Kakutei_ymd_to", formVO.Kakutei_ymd_to);
			}
			if (formVO.Denpyo_bango_from != null)
			{
				checker.DoCheck("Denpyo_bango_from", formVO.Denpyo_bango_from);
			}
			if (formVO.Denpyo_bango_to != null)
			{
				checker.DoCheck("Denpyo_bango_to", formVO.Denpyo_bango_to);
			}
			if (formVO.Kamoku_cd_from != null)
			{
				checker.DoCheck("Kamoku_cd_from", formVO.Kamoku_cd_from);
			}
			if (formVO.Kamoku_nm_from != null)
			{
				checker.DoCheck("Kamoku_nm_from", formVO.Kamoku_nm_from);
			}
			if (formVO.Kamoku_cd_to != null)
			{
				checker.DoCheck("Kamoku_cd_to", formVO.Kamoku_cd_to);
			}
			if (formVO.Kamoku_nm_to != null)
			{
				checker.DoCheck("Kamoku_nm_to", formVO.Kamoku_nm_to);
			}
			if (formVO.Sinseitan_cd != null)
			{
				checker.DoCheck("Sinseitan_cd", formVO.Sinseitan_cd);
			}
			if (formVO.Sinseitan_nm != null)
			{
				checker.DoCheck("Sinseitan_nm", formVO.Sinseitan_nm);
			}
			if (formVO.Jyuri_no_from != null)
			{
				checker.DoCheck("Jyuri_no_from", formVO.Jyuri_no_from);
			}
			if (formVO.Jyuri_no_to != null)
			{
				checker.DoCheck("Jyuri_no_to", formVO.Jyuri_no_to);
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
		public static void ValidateM1InputValue(Tf020f01Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Tf020f01M1Form tf020f01M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, tf020f01M1Form, i, m1List);
				if (tf020f01M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", tf020f01M1Form.M1rowno, i, m1List);
				}
				if (tf020f01M1Form.M1apply_ymd != null)
				{
					checker.DoCheck("M1apply_ymd", tf020f01M1Form.M1apply_ymd, i, m1List);
				}
				if (tf020f01M1Form.M1kakutei_ymd != null)
				{
					checker.DoCheck("M1kakutei_ymd", tf020f01M1Form.M1kakutei_ymd, i, m1List);
				}
				if (tf020f01M1Form.M1kamoku_cd != null)
				{
					checker.DoCheck("M1kamoku_cd", tf020f01M1Form.M1kamoku_cd, i, m1List);
				}
				if (tf020f01M1Form.M1kamoku_nm != null)
				{
					checker.DoCheck("M1kamoku_nm", tf020f01M1Form.M1kamoku_nm, i, m1List);
				}
				if (tf020f01M1Form.M1itemsu != null)
				{
					checker.DoCheck("M1itemsu", tf020f01M1Form.M1itemsu, i, m1List);
				}
				if (tf020f01M1Form.M1genkakin != null)
				{
					checker.DoCheck("M1genkakin", tf020f01M1Form.M1genkakin, i, m1List);
				}
				if (tf020f01M1Form.M1baika_tnk != null)
				{
					checker.DoCheck("M1baika_tnk", tf020f01M1Form.M1baika_tnk, i, m1List);
				}
				if (tf020f01M1Form.M1sinseitan_nm != null)
				{
					checker.DoCheck("M1sinseitan_nm", tf020f01M1Form.M1sinseitan_nm, i, m1List);
				}
				if (tf020f01M1Form.M1jyuri_no != null)
				{
					checker.DoCheck("M1jyuri_no", tf020f01M1Form.M1jyuri_no, i, m1List);
				}
				if (tf020f01M1Form.M1syonin_flg_nm != null)
				{
					checker.DoCheck("M1syonin_flg_nm", tf020f01M1Form.M1syonin_flg_nm, i, m1List);
				}
				if (tf020f01M1Form.M1sinseiriyu != null)
				{
					checker.DoCheck("M1sinseiriyu", tf020f01M1Form.M1sinseiriyu, i, m1List);
				}
				if (tf020f01M1Form.M1kyakkariyu != null)
				{
					checker.DoCheck("M1kyakkariyu", tf020f01M1Form.M1kyakkariyu, i, m1List);
				}
				if (tf020f01M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", tf020f01M1Form.M1selectorcheckbox, i, m1List);
				}
				if (tf020f01M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", tf020f01M1Form.M1entersyoriflg, i, m1List);
				}
				if (tf020f01M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", tf020f01M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Tf020f01Form formVO, StandardCodeCheckManager checker)
		{
			checker.DoCheck("Btnheadtenpocd", formVO);
			checker.DoCheck("Btnkamokucd_from", formVO);
			checker.DoCheck("Btnkamokucd_to", formVO);
			checker.DoCheck("Btntanto_cd", formVO);
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Tf020f01Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

