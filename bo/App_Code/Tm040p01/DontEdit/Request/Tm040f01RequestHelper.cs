using com.xebio.bo.Tm040p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Tm040p01.Request
{
  /// <summary>
  /// Tm040f01RequestHelper の概要の説明です。
  /// </summary>
  public static class Tm040f01RequestHelper
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
			Tm040f01Form formVO = (Tm040f01Form)pageContext.GetFormVO();

			//カード部を初期化する
			paramCol.InitCardItems(formInfo.GetCardItems());
			//明細「M1」部を初期化する
			paramCol.InitListItems(formInfo.GetListItems("M1"), formVO.GetList("M1").CurrentCount);
			//カード項目の入力値を取得する
			paramCol["Modeno"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Modeno"]);
			paramCol["Stkmodeno"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Stkmodeno"]);
			paramCol["Old_jisya_hbn"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Old_jisya_hbn"]);
			paramCol["Scan_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Scan_cd"]);
			paramCol["Bumon_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_nm"]);
			paramCol["Hinsyu_ryaku_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hinsyu_ryaku_nm"]);
			paramCol["Burando_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Burando_nm"]);
			paramCol["Maker_hbn"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Maker_hbn"]);
			paramCol["Syonmk"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Syonmk"]);
			paramCol["Tenpo_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tenpo_cd"]);
			paramCol["Pluflg"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Pluflg"]);
			paramCol["Priceflg"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Priceflg"]);
			paramCol["Zaikoflg"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Zaikoflg"]);
			paramCol["Nyukaflg"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Nyukaflg"]);
			paramCol["Uriflg"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Uriflg"]);
			paramCol["Hojuflg"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hojuflg"]);
			paramCol["Tanpinflg"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tanpinflg"]);
			paramCol["Sijiflg"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Sijiflg"]);
			paramCol["Siji_bango"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Siji_bango"]);
			paramCol["Syukkakaisya_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Syukkakaisya_cd"]);
			paramCol["Jyuryokaisya_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Jyuryokaisya_cd"]);
			paramCol["Syukkaten_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Syukkaten_cd"]);
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
			Tm040f01Form formVO = (Tm040f01Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Modeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Modeno"].RequestValue, formInfo["Modeno"]);
			paramCol["Stkmodeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Stkmodeno"].RequestValue, formInfo["Stkmodeno"]);
			paramCol["Old_jisya_hbn"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Old_jisya_hbn"].RequestValue, formInfo["Old_jisya_hbn"]);
			paramCol["Scan_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Scan_cd"].RequestValue, formInfo["Scan_cd"]);
			paramCol["Bumon_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_nm"].RequestValue, formInfo["Bumon_nm"]);
			paramCol["Hinsyu_ryaku_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hinsyu_ryaku_nm"].RequestValue, formInfo["Hinsyu_ryaku_nm"]);
			paramCol["Burando_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Burando_nm"].RequestValue, formInfo["Burando_nm"]);
			paramCol["Maker_hbn"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Maker_hbn"].RequestValue, formInfo["Maker_hbn"]);
			paramCol["Syonmk"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Syonmk"].RequestValue, formInfo["Syonmk"]);
			paramCol["Tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tenpo_cd"].RequestValue, formInfo["Tenpo_cd"]);
			paramCol["Pluflg"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Pluflg"].RequestValue, formInfo["Pluflg"]);
			paramCol["Priceflg"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Priceflg"].RequestValue, formInfo["Priceflg"]);
			paramCol["Zaikoflg"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Zaikoflg"].RequestValue, formInfo["Zaikoflg"]);
			paramCol["Nyukaflg"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Nyukaflg"].RequestValue, formInfo["Nyukaflg"]);
			paramCol["Uriflg"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Uriflg"].RequestValue, formInfo["Uriflg"]);
			paramCol["Hojuflg"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hojuflg"].RequestValue, formInfo["Hojuflg"]);
			paramCol["Tanpinflg"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tanpinflg"].RequestValue, formInfo["Tanpinflg"]);
			paramCol["Sijiflg"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Sijiflg"].RequestValue, formInfo["Sijiflg"]);
			paramCol["Siji_bango"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Siji_bango"].RequestValue, formInfo["Siji_bango"]);
			paramCol["Syukkakaisya_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Syukkakaisya_cd"].RequestValue, formInfo["Syukkakaisya_cd"]);
			paramCol["Jyuryokaisya_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Jyuryokaisya_cd"].RequestValue, formInfo["Jyuryokaisya_cd"]);
			paramCol["Syukkaten_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Syukkaten_cd"].RequestValue, formInfo["Syukkaten_cd"]);
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
			Tm040f01Form formVO = (Tm040f01Form)pageContext.GetFormVO();

			//カード項目の入力値をFormVOにコピーする
			if (paramCol["Modeno"].UnformatValue != null)
			{
				formVO.Modeno = paramCol["Modeno"].UnformatValue;
			}
			if (paramCol["Stkmodeno"].UnformatValue != null)
			{
				formVO.Stkmodeno = paramCol["Stkmodeno"].UnformatValue;
			}
			if (paramCol["Old_jisya_hbn"].UnformatValue != null)
			{
				formVO.Old_jisya_hbn = paramCol["Old_jisya_hbn"].UnformatValue;
			}
			if (paramCol["Scan_cd"].UnformatValue != null)
			{
				formVO.Scan_cd = paramCol["Scan_cd"].UnformatValue;
			}
			if (paramCol["Bumon_nm"].UnformatValue != null)
			{
				formVO.Bumon_nm = paramCol["Bumon_nm"].UnformatValue;
			}
			if (paramCol["Hinsyu_ryaku_nm"].UnformatValue != null)
			{
				formVO.Hinsyu_ryaku_nm = paramCol["Hinsyu_ryaku_nm"].UnformatValue;
			}
			if (paramCol["Burando_nm"].UnformatValue != null)
			{
				formVO.Burando_nm = paramCol["Burando_nm"].UnformatValue;
			}
			if (paramCol["Maker_hbn"].UnformatValue != null)
			{
				formVO.Maker_hbn = paramCol["Maker_hbn"].UnformatValue;
			}
			if (paramCol["Syonmk"].UnformatValue != null)
			{
				formVO.Syonmk = paramCol["Syonmk"].UnformatValue;
			}
			if (paramCol["Tenpo_cd"].UnformatValue != null)
			{
				formVO.Tenpo_cd = paramCol["Tenpo_cd"].UnformatValue;
			}
			if (paramCol["Pluflg"].UnformatValue != null)
			{
				formVO.Pluflg = paramCol["Pluflg"].UnformatValue;
			}
			if (paramCol["Priceflg"].UnformatValue != null)
			{
				formVO.Priceflg = paramCol["Priceflg"].UnformatValue;
			}
			if (paramCol["Zaikoflg"].UnformatValue != null)
			{
				formVO.Zaikoflg = paramCol["Zaikoflg"].UnformatValue;
			}
			if (paramCol["Nyukaflg"].UnformatValue != null)
			{
				formVO.Nyukaflg = paramCol["Nyukaflg"].UnformatValue;
			}
			if (paramCol["Uriflg"].UnformatValue != null)
			{
				formVO.Uriflg = paramCol["Uriflg"].UnformatValue;
			}
			if (paramCol["Hojuflg"].UnformatValue != null)
			{
				formVO.Hojuflg = paramCol["Hojuflg"].UnformatValue;
			}
			if (paramCol["Tanpinflg"].UnformatValue != null)
			{
				formVO.Tanpinflg = paramCol["Tanpinflg"].UnformatValue;
			}
			if (paramCol["Sijiflg"].UnformatValue != null)
			{
				formVO.Sijiflg = paramCol["Sijiflg"].UnformatValue;
			}
			if (paramCol["Siji_bango"].UnformatValue != null)
			{
				formVO.Siji_bango = paramCol["Siji_bango"].UnformatValue;
			}
			if (paramCol["Syukkakaisya_cd"].UnformatValue != null)
			{
				formVO.Syukkakaisya_cd = paramCol["Syukkakaisya_cd"].UnformatValue;
			}
			if (paramCol["Jyuryokaisya_cd"].UnformatValue != null)
			{
				formVO.Jyuryokaisya_cd = paramCol["Jyuryokaisya_cd"].UnformatValue;
			}
			if (paramCol["Syukkaten_cd"].UnformatValue != null)
			{
				formVO.Syukkaten_cd = paramCol["Syukkaten_cd"].UnformatValue;
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
				Tm040f01M1Form tm040f01M1Form = (Tm040f01M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					tm040f01M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					tm040f01M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					tm040f01M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					tm040f01M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Tm040f01Form formVO, StandardCheckManager checker)
		{
			if (formVO.Modeno != null)
			{
				checker.DoCheck("Modeno", formVO.Modeno);
			}
			if (formVO.Stkmodeno != null)
			{
				checker.DoCheck("Stkmodeno", formVO.Stkmodeno);
			}
			if (formVO.Old_jisya_hbn != null)
			{
				checker.DoCheck("Old_jisya_hbn", formVO.Old_jisya_hbn);
			}
			if (formVO.Scan_cd != null)
			{
				checker.DoCheck("Scan_cd", formVO.Scan_cd);
			}
			if (formVO.Bumon_nm != null)
			{
				checker.DoCheck("Bumon_nm", formVO.Bumon_nm);
			}
			if (formVO.Hinsyu_ryaku_nm != null)
			{
				checker.DoCheck("Hinsyu_ryaku_nm", formVO.Hinsyu_ryaku_nm);
			}
			if (formVO.Burando_nm != null)
			{
				checker.DoCheck("Burando_nm", formVO.Burando_nm);
			}
			if (formVO.Maker_hbn != null)
			{
				checker.DoCheck("Maker_hbn", formVO.Maker_hbn);
			}
			if (formVO.Syonmk != null)
			{
				checker.DoCheck("Syonmk", formVO.Syonmk);
			}
			if (formVO.Tenpo_cd != null)
			{
				checker.DoCheck("Tenpo_cd", formVO.Tenpo_cd);
			}
			if (formVO.Pluflg != null)
			{
				checker.DoCheck("Pluflg", formVO.Pluflg);
			}
			if (formVO.Priceflg != null)
			{
				checker.DoCheck("Priceflg", formVO.Priceflg);
			}
			if (formVO.Zaikoflg != null)
			{
				checker.DoCheck("Zaikoflg", formVO.Zaikoflg);
			}
			if (formVO.Nyukaflg != null)
			{
				checker.DoCheck("Nyukaflg", formVO.Nyukaflg);
			}
			if (formVO.Uriflg != null)
			{
				checker.DoCheck("Uriflg", formVO.Uriflg);
			}
			if (formVO.Hojuflg != null)
			{
				checker.DoCheck("Hojuflg", formVO.Hojuflg);
			}
			if (formVO.Tanpinflg != null)
			{
				checker.DoCheck("Tanpinflg", formVO.Tanpinflg);
			}
			if (formVO.Sijiflg != null)
			{
				checker.DoCheck("Sijiflg", formVO.Sijiflg);
			}
			if (formVO.Siji_bango != null)
			{
				checker.DoCheck("Siji_bango", formVO.Siji_bango);
			}
			if (formVO.Syukkakaisya_cd != null)
			{
				checker.DoCheck("Syukkakaisya_cd", formVO.Syukkakaisya_cd);
			}
			if (formVO.Jyuryokaisya_cd != null)
			{
				checker.DoCheck("Jyuryokaisya_cd", formVO.Jyuryokaisya_cd);
			}
			if (formVO.Syukkaten_cd != null)
			{
				checker.DoCheck("Syukkaten_cd", formVO.Syukkaten_cd);
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
		public static void ValidateM1InputValue(Tm040f01Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Tm040f01M1Form tm040f01M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, tm040f01M1Form, i, m1List);
				if (tm040f01M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", tm040f01M1Form.M1rowno, i, m1List);
				}
				if (tm040f01M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", tm040f01M1Form.M1selectorcheckbox, i, m1List);
				}
				if (tm040f01M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", tm040f01M1Form.M1entersyoriflg, i, m1List);
				}
				if (tm040f01M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", tm040f01M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Tm040f01Form formVO, StandardCodeCheckManager checker)
		{
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Tm040f01Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

