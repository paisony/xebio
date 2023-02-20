using com.xebio.bo.Tf060p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Tf060p01.Request
{
  /// <summary>
  /// Tf060f01RequestHelper の概要の説明です。
  /// </summary>
  public static class Tf060f01RequestHelper
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
			Tf060f01Form formVO = (Tf060f01Form)pageContext.GetFormVO();

			//カード部を初期化する
			paramCol.InitCardItems(formInfo.GetCardItems());
			//明細「M1」部を初期化する
			paramCol.InitListItems(formInfo.GetListItems("M1"), formVO.GetList("M1").CurrentCount);
			//カード項目の入力値を取得する
			paramCol["Head_tenpo_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_nm"]);
			paramCol["Getudo"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Getudo"]);
			paramCol["Tukibetu_bumon1_yosan_kin"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tukibetu_bumon1_yosan_kin"]);
			paramCol["Tukibetu_bumon2_yosan_kin"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tukibetu_bumon2_yosan_kin"]);
			paramCol["Tukibetu_bumon3_yosan_kin"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tukibetu_bumon3_yosan_kin"]);
			paramCol["Tukibetu_bumon4_yosan_kin"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tukibetu_bumon4_yosan_kin"]);
			paramCol["Tukibetu_bumon5_yosan_kin"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tukibetu_bumon5_yosan_kin"]);
			paramCol["Tukibetu_yosan_kin_gokei"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tukibetu_yosan_kin_gokei"]);
			paramCol["Bumon1_yosangokei_kin"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon1_yosangokei_kin"]);
			paramCol["Bumon2_yosangokei_kin"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon2_yosangokei_kin"]);
			paramCol["Bumon3_yosangokei_kin"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon3_yosangokei_kin"]);
			paramCol["Bumon4_yosangokei_kin"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon4_yosangokei_kin"]);
			paramCol["Bumon5_yosangokei_kin"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon5_yosangokei_kin"]);
			paramCol["Yosangokei_kin"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Yosangokei_kin"]);
			SCSubBasePage scPage = (SCSubBasePage)page;
			if(StandardBaseCheckManager.CheckUseSelfCustomize()){
				// カード部カスタム項目の値を取得する
				scPage.GetCardRequestValue(paramCol);
			}

			//明細「M1」項目の入力値を取得する
			Repeater M1 = (Repeater)page.FindControl("M1");
			for (int i = 0; i < formVO.GetList("M1").CurrentCount; i++)
			{
				paramCol["M1getunai_hiduke"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1getunai_hiduke"]);
				paramCol["M1yobi"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1yobi"]);
				paramCol["M1bumon1_yosan_kin"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1bumon1_yosan_kin"]);
				paramCol["M1bumon2_yosan_kin"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1bumon2_yosan_kin"]);
				paramCol["M1bumon3_yosan_kin"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1bumon3_yosan_kin"]);
				paramCol["M1bumon4_yosan_kin"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1bumon4_yosan_kin"]);
				paramCol["M1bumon5_yosan_kin"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1bumon5_yosan_kin"]);
				paramCol["M1hibetu_yosan_kin"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hibetu_yosan_kin"]);
				paramCol["M1bumon1_yosan_kin_hdn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1bumon1_yosan_kin_hdn"]);
				paramCol["M1bumon2_yosan_kin_hdn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1bumon2_yosan_kin_hdn"]);
				paramCol["M1bumon3_yosan_kin_hdn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1bumon3_yosan_kin_hdn"]);
				paramCol["M1bumon4_yosan_kin_hdn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1bumon4_yosan_kin_hdn"]);
				paramCol["M1bumon5_yosan_kin_hdn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1bumon5_yosan_kin_hdn"]);
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
			Tf060f01Form formVO = (Tf060f01Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Getudo"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Getudo"].RequestValue, formInfo["Getudo"]);
			paramCol["Tukibetu_bumon1_yosan_kin"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tukibetu_bumon1_yosan_kin"].RequestValue, formInfo["Tukibetu_bumon1_yosan_kin"]);
			paramCol["Tukibetu_bumon2_yosan_kin"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tukibetu_bumon2_yosan_kin"].RequestValue, formInfo["Tukibetu_bumon2_yosan_kin"]);
			paramCol["Tukibetu_bumon3_yosan_kin"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tukibetu_bumon3_yosan_kin"].RequestValue, formInfo["Tukibetu_bumon3_yosan_kin"]);
			paramCol["Tukibetu_bumon4_yosan_kin"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tukibetu_bumon4_yosan_kin"].RequestValue, formInfo["Tukibetu_bumon4_yosan_kin"]);
			paramCol["Tukibetu_bumon5_yosan_kin"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tukibetu_bumon5_yosan_kin"].RequestValue, formInfo["Tukibetu_bumon5_yosan_kin"]);
			paramCol["Tukibetu_yosan_kin_gokei"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tukibetu_yosan_kin_gokei"].RequestValue, formInfo["Tukibetu_yosan_kin_gokei"]);
			paramCol["Bumon1_yosangokei_kin"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon1_yosangokei_kin"].RequestValue, formInfo["Bumon1_yosangokei_kin"]);
			paramCol["Bumon2_yosangokei_kin"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon2_yosangokei_kin"].RequestValue, formInfo["Bumon2_yosangokei_kin"]);
			paramCol["Bumon3_yosangokei_kin"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon3_yosangokei_kin"].RequestValue, formInfo["Bumon3_yosangokei_kin"]);
			paramCol["Bumon4_yosangokei_kin"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon4_yosangokei_kin"].RequestValue, formInfo["Bumon4_yosangokei_kin"]);
			paramCol["Bumon5_yosangokei_kin"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon5_yosangokei_kin"].RequestValue, formInfo["Bumon5_yosangokei_kin"]);
			paramCol["Yosangokei_kin"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Yosangokei_kin"].RequestValue, formInfo["Yosangokei_kin"]);
			SCSubBasePage page = (SCSubBasePage)HttpContext.Current.Handler;
			if(StandardBaseCheckManager.CheckUseSelfCustomize()){
				// カード部カスタム項目のアンフォーマット値を取得する
				page.UnformatCard(paramCol);
			}

			//明細「M1」項目のアンフォーマット値を取得する
			for (int i = 0; i < formVO.GetList("M1").CurrentCount; i++)
			{
				paramCol["M1getunai_hiduke"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1getunai_hiduke"][i].RequestValue, formInfo["M1getunai_hiduke"]);
				paramCol["M1yobi"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1yobi"][i].RequestValue, formInfo["M1yobi"]);
				paramCol["M1bumon1_yosan_kin"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1bumon1_yosan_kin"][i].RequestValue, formInfo["M1bumon1_yosan_kin"]);
				paramCol["M1bumon2_yosan_kin"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1bumon2_yosan_kin"][i].RequestValue, formInfo["M1bumon2_yosan_kin"]);
				paramCol["M1bumon3_yosan_kin"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1bumon3_yosan_kin"][i].RequestValue, formInfo["M1bumon3_yosan_kin"]);
				paramCol["M1bumon4_yosan_kin"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1bumon4_yosan_kin"][i].RequestValue, formInfo["M1bumon4_yosan_kin"]);
				paramCol["M1bumon5_yosan_kin"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1bumon5_yosan_kin"][i].RequestValue, formInfo["M1bumon5_yosan_kin"]);
				paramCol["M1hibetu_yosan_kin"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hibetu_yosan_kin"][i].RequestValue, formInfo["M1hibetu_yosan_kin"]);
				paramCol["M1bumon1_yosan_kin_hdn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1bumon1_yosan_kin_hdn"][i].RequestValue, formInfo["M1bumon1_yosan_kin_hdn"]);
				paramCol["M1bumon2_yosan_kin_hdn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1bumon2_yosan_kin_hdn"][i].RequestValue, formInfo["M1bumon2_yosan_kin_hdn"]);
				paramCol["M1bumon3_yosan_kin_hdn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1bumon3_yosan_kin_hdn"][i].RequestValue, formInfo["M1bumon3_yosan_kin_hdn"]);
				paramCol["M1bumon4_yosan_kin_hdn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1bumon4_yosan_kin_hdn"][i].RequestValue, formInfo["M1bumon4_yosan_kin_hdn"]);
				paramCol["M1bumon5_yosan_kin_hdn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1bumon5_yosan_kin_hdn"][i].RequestValue, formInfo["M1bumon5_yosan_kin_hdn"]);
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
			Tf060f01Form formVO = (Tf060f01Form)pageContext.GetFormVO();

			//カード項目の入力値をFormVOにコピーする
			if (paramCol["Head_tenpo_cd"].UnformatValue != null)
			{
				formVO.Head_tenpo_cd = paramCol["Head_tenpo_cd"].UnformatValue;
			}
			if (paramCol["Head_tenpo_nm"].UnformatValue != null)
			{
				formVO.Head_tenpo_nm = paramCol["Head_tenpo_nm"].UnformatValue;
			}
			if (paramCol["Getudo"].UnformatValue != null)
			{
				formVO.Getudo = paramCol["Getudo"].UnformatValue;
			}
			if (paramCol["Tukibetu_bumon1_yosan_kin"].UnformatValue != null)
			{
				formVO.Tukibetu_bumon1_yosan_kin = paramCol["Tukibetu_bumon1_yosan_kin"].UnformatValue;
			}
			if (paramCol["Tukibetu_bumon2_yosan_kin"].UnformatValue != null)
			{
				formVO.Tukibetu_bumon2_yosan_kin = paramCol["Tukibetu_bumon2_yosan_kin"].UnformatValue;
			}
			if (paramCol["Tukibetu_bumon3_yosan_kin"].UnformatValue != null)
			{
				formVO.Tukibetu_bumon3_yosan_kin = paramCol["Tukibetu_bumon3_yosan_kin"].UnformatValue;
			}
			if (paramCol["Tukibetu_bumon4_yosan_kin"].UnformatValue != null)
			{
				formVO.Tukibetu_bumon4_yosan_kin = paramCol["Tukibetu_bumon4_yosan_kin"].UnformatValue;
			}
			if (paramCol["Tukibetu_bumon5_yosan_kin"].UnformatValue != null)
			{
				formVO.Tukibetu_bumon5_yosan_kin = paramCol["Tukibetu_bumon5_yosan_kin"].UnformatValue;
			}
			if (paramCol["Tukibetu_yosan_kin_gokei"].UnformatValue != null)
			{
				formVO.Tukibetu_yosan_kin_gokei = paramCol["Tukibetu_yosan_kin_gokei"].UnformatValue;
			}
			if (paramCol["Bumon1_yosangokei_kin"].UnformatValue != null)
			{
				formVO.Bumon1_yosangokei_kin = paramCol["Bumon1_yosangokei_kin"].UnformatValue;
			}
			if (paramCol["Bumon2_yosangokei_kin"].UnformatValue != null)
			{
				formVO.Bumon2_yosangokei_kin = paramCol["Bumon2_yosangokei_kin"].UnformatValue;
			}
			if (paramCol["Bumon3_yosangokei_kin"].UnformatValue != null)
			{
				formVO.Bumon3_yosangokei_kin = paramCol["Bumon3_yosangokei_kin"].UnformatValue;
			}
			if (paramCol["Bumon4_yosangokei_kin"].UnformatValue != null)
			{
				formVO.Bumon4_yosangokei_kin = paramCol["Bumon4_yosangokei_kin"].UnformatValue;
			}
			if (paramCol["Bumon5_yosangokei_kin"].UnformatValue != null)
			{
				formVO.Bumon5_yosangokei_kin = paramCol["Bumon5_yosangokei_kin"].UnformatValue;
			}
			if (paramCol["Yosangokei_kin"].UnformatValue != null)
			{
				formVO.Yosangokei_kin = paramCol["Yosangokei_kin"].UnformatValue;
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
				Tf060f01M1Form tf060f01M1Form = (Tf060f01M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1getunai_hiduke"][i].UnformatValue != null)
				{
					tf060f01M1Form.M1getunai_hiduke = paramCol["M1getunai_hiduke"][i].UnformatValue;
				}
				if (paramCol["M1yobi"][i].UnformatValue != null)
				{
					tf060f01M1Form.M1yobi = paramCol["M1yobi"][i].UnformatValue;
				}
				if (paramCol["M1bumon1_yosan_kin"][i].UnformatValue != null)
				{
					tf060f01M1Form.M1bumon1_yosan_kin = paramCol["M1bumon1_yosan_kin"][i].UnformatValue;
				}
				if (paramCol["M1bumon2_yosan_kin"][i].UnformatValue != null)
				{
					tf060f01M1Form.M1bumon2_yosan_kin = paramCol["M1bumon2_yosan_kin"][i].UnformatValue;
				}
				if (paramCol["M1bumon3_yosan_kin"][i].UnformatValue != null)
				{
					tf060f01M1Form.M1bumon3_yosan_kin = paramCol["M1bumon3_yosan_kin"][i].UnformatValue;
				}
				if (paramCol["M1bumon4_yosan_kin"][i].UnformatValue != null)
				{
					tf060f01M1Form.M1bumon4_yosan_kin = paramCol["M1bumon4_yosan_kin"][i].UnformatValue;
				}
				if (paramCol["M1bumon5_yosan_kin"][i].UnformatValue != null)
				{
					tf060f01M1Form.M1bumon5_yosan_kin = paramCol["M1bumon5_yosan_kin"][i].UnformatValue;
				}
				if (paramCol["M1hibetu_yosan_kin"][i].UnformatValue != null)
				{
					tf060f01M1Form.M1hibetu_yosan_kin = paramCol["M1hibetu_yosan_kin"][i].UnformatValue;
				}
				if (paramCol["M1bumon1_yosan_kin_hdn"][i].UnformatValue != null)
				{
					tf060f01M1Form.M1bumon1_yosan_kin_hdn = paramCol["M1bumon1_yosan_kin_hdn"][i].UnformatValue;
				}
				if (paramCol["M1bumon2_yosan_kin_hdn"][i].UnformatValue != null)
				{
					tf060f01M1Form.M1bumon2_yosan_kin_hdn = paramCol["M1bumon2_yosan_kin_hdn"][i].UnformatValue;
				}
				if (paramCol["M1bumon3_yosan_kin_hdn"][i].UnformatValue != null)
				{
					tf060f01M1Form.M1bumon3_yosan_kin_hdn = paramCol["M1bumon3_yosan_kin_hdn"][i].UnformatValue;
				}
				if (paramCol["M1bumon4_yosan_kin_hdn"][i].UnformatValue != null)
				{
					tf060f01M1Form.M1bumon4_yosan_kin_hdn = paramCol["M1bumon4_yosan_kin_hdn"][i].UnformatValue;
				}
				if (paramCol["M1bumon5_yosan_kin_hdn"][i].UnformatValue != null)
				{
					tf060f01M1Form.M1bumon5_yosan_kin_hdn = paramCol["M1bumon5_yosan_kin_hdn"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					tf060f01M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					tf060f01M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					tf060f01M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Tf060f01Form formVO, StandardCheckManager checker)
		{
			if (formVO.Head_tenpo_cd != null)
			{
				checker.DoCheck("Head_tenpo_cd", formVO.Head_tenpo_cd);
			}
			if (formVO.Head_tenpo_nm != null)
			{
				checker.DoCheck("Head_tenpo_nm", formVO.Head_tenpo_nm);
			}
			if (formVO.Getudo != null)
			{
				checker.DoCheck("Getudo", formVO.Getudo);
			}
			if (formVO.Tukibetu_bumon1_yosan_kin != null)
			{
				checker.DoCheck("Tukibetu_bumon1_yosan_kin", formVO.Tukibetu_bumon1_yosan_kin);
			}
			if (formVO.Tukibetu_bumon2_yosan_kin != null)
			{
				checker.DoCheck("Tukibetu_bumon2_yosan_kin", formVO.Tukibetu_bumon2_yosan_kin);
			}
			if (formVO.Tukibetu_bumon3_yosan_kin != null)
			{
				checker.DoCheck("Tukibetu_bumon3_yosan_kin", formVO.Tukibetu_bumon3_yosan_kin);
			}
			if (formVO.Tukibetu_bumon4_yosan_kin != null)
			{
				checker.DoCheck("Tukibetu_bumon4_yosan_kin", formVO.Tukibetu_bumon4_yosan_kin);
			}
			if (formVO.Tukibetu_bumon5_yosan_kin != null)
			{
				checker.DoCheck("Tukibetu_bumon5_yosan_kin", formVO.Tukibetu_bumon5_yosan_kin);
			}
			if (formVO.Tukibetu_yosan_kin_gokei != null)
			{
				checker.DoCheck("Tukibetu_yosan_kin_gokei", formVO.Tukibetu_yosan_kin_gokei);
			}
			if (formVO.Bumon1_yosangokei_kin != null)
			{
				checker.DoCheck("Bumon1_yosangokei_kin", formVO.Bumon1_yosangokei_kin);
			}
			if (formVO.Bumon2_yosangokei_kin != null)
			{
				checker.DoCheck("Bumon2_yosangokei_kin", formVO.Bumon2_yosangokei_kin);
			}
			if (formVO.Bumon3_yosangokei_kin != null)
			{
				checker.DoCheck("Bumon3_yosangokei_kin", formVO.Bumon3_yosangokei_kin);
			}
			if (formVO.Bumon4_yosangokei_kin != null)
			{
				checker.DoCheck("Bumon4_yosangokei_kin", formVO.Bumon4_yosangokei_kin);
			}
			if (formVO.Bumon5_yosangokei_kin != null)
			{
				checker.DoCheck("Bumon5_yosangokei_kin", formVO.Bumon5_yosangokei_kin);
			}
			if (formVO.Yosangokei_kin != null)
			{
				checker.DoCheck("Yosangokei_kin", formVO.Yosangokei_kin);
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
		public static void ValidateM1InputValue(Tf060f01Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Tf060f01M1Form tf060f01M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, tf060f01M1Form, i, m1List);
				if (tf060f01M1Form.M1getunai_hiduke != null)
				{
					checker.DoCheck("M1getunai_hiduke", tf060f01M1Form.M1getunai_hiduke, i, m1List);
				}
				if (tf060f01M1Form.M1yobi != null)
				{
					checker.DoCheck("M1yobi", tf060f01M1Form.M1yobi, i, m1List);
				}
				if (tf060f01M1Form.M1bumon1_yosan_kin != null)
				{
					checker.DoCheck("M1bumon1_yosan_kin", tf060f01M1Form.M1bumon1_yosan_kin, i, m1List);
				}
				if (tf060f01M1Form.M1bumon2_yosan_kin != null)
				{
					checker.DoCheck("M1bumon2_yosan_kin", tf060f01M1Form.M1bumon2_yosan_kin, i, m1List);
				}
				if (tf060f01M1Form.M1bumon3_yosan_kin != null)
				{
					checker.DoCheck("M1bumon3_yosan_kin", tf060f01M1Form.M1bumon3_yosan_kin, i, m1List);
				}
				if (tf060f01M1Form.M1bumon4_yosan_kin != null)
				{
					checker.DoCheck("M1bumon4_yosan_kin", tf060f01M1Form.M1bumon4_yosan_kin, i, m1List);
				}
				if (tf060f01M1Form.M1bumon5_yosan_kin != null)
				{
					checker.DoCheck("M1bumon5_yosan_kin", tf060f01M1Form.M1bumon5_yosan_kin, i, m1List);
				}
				if (tf060f01M1Form.M1hibetu_yosan_kin != null)
				{
					checker.DoCheck("M1hibetu_yosan_kin", tf060f01M1Form.M1hibetu_yosan_kin, i, m1List);
				}
				if (tf060f01M1Form.M1bumon1_yosan_kin_hdn != null)
				{
					checker.DoCheck("M1bumon1_yosan_kin_hdn", tf060f01M1Form.M1bumon1_yosan_kin_hdn, i, m1List);
				}
				if (tf060f01M1Form.M1bumon2_yosan_kin_hdn != null)
				{
					checker.DoCheck("M1bumon2_yosan_kin_hdn", tf060f01M1Form.M1bumon2_yosan_kin_hdn, i, m1List);
				}
				if (tf060f01M1Form.M1bumon3_yosan_kin_hdn != null)
				{
					checker.DoCheck("M1bumon3_yosan_kin_hdn", tf060f01M1Form.M1bumon3_yosan_kin_hdn, i, m1List);
				}
				if (tf060f01M1Form.M1bumon4_yosan_kin_hdn != null)
				{
					checker.DoCheck("M1bumon4_yosan_kin_hdn", tf060f01M1Form.M1bumon4_yosan_kin_hdn, i, m1List);
				}
				if (tf060f01M1Form.M1bumon5_yosan_kin_hdn != null)
				{
					checker.DoCheck("M1bumon5_yosan_kin_hdn", tf060f01M1Form.M1bumon5_yosan_kin_hdn, i, m1List);
				}
				if (tf060f01M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", tf060f01M1Form.M1selectorcheckbox, i, m1List);
				}
				if (tf060f01M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", tf060f01M1Form.M1entersyoriflg, i, m1List);
				}
				if (tf060f01M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", tf060f01M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Tf060f01Form formVO, StandardCodeCheckManager checker)
		{
			checker.DoCheck("Btnheadtenpocd", formVO);
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Tf060f01Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

