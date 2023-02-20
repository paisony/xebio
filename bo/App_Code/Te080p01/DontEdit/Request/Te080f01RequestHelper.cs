using com.xebio.bo.Te080p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Te080p01.Request
{
  /// <summary>
  /// Te080f01RequestHelper の概要の説明です。
  /// </summary>
  public static class Te080f01RequestHelper
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
			Te080f01Form formVO = (Te080f01Form)pageContext.GetFormVO();

			//カード部を初期化する
			paramCol.InitCardItems(formInfo.GetCardItems());
			//明細「M1」部を初期化する
			paramCol.InitListItems(formInfo.GetListItems("M1"), formVO.GetList("M1").CurrentCount);
			//カード項目の入力値を取得する
			paramCol["Head_tenpo_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_nm"]);
			paramCol["Scm_gokei"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Scm_gokei"]);
			paramCol["Denpyo_gokei"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Denpyo_gokei"]);
			paramCol["Selectrowno"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Selectrowno"]);
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
				paramCol["M1kaisya_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1kaisya_cd"]);
				paramCol["M1kaisya_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1kaisya_nm"]);
				paramCol["M1syukkaten_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1syukkaten_cd"]);
				paramCol["M1syukkaten_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1syukkaten_nm"]);
				paramCol["M1scmden_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1scmden_cd"]);
				paramCol["M1scm_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1scm_cd"]);
				paramCol["M1denpyo_bango"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1denpyo_bango"]);
				paramCol["M1syukka_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1syukka_ymd"]);
				paramCol["M1yotei_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1yotei_su"]);
				paramCol["M1kyakucyu"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1kyakucyu"]);
				paramCol["M1negaki"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1negaki"]);
				paramCol["M1tenpolc_kbn_hdn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tenpolc_kbn_hdn"]);
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
			Te080f01Form formVO = (Te080f01Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Scm_gokei"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Scm_gokei"].RequestValue, formInfo["Scm_gokei"]);
			paramCol["Denpyo_gokei"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Denpyo_gokei"].RequestValue, formInfo["Denpyo_gokei"]);
			paramCol["Selectrowno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Selectrowno"].RequestValue, formInfo["Selectrowno"]);
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
				paramCol["M1kaisya_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1kaisya_cd"][i].RequestValue, formInfo["M1kaisya_cd"]);
				paramCol["M1kaisya_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1kaisya_nm"][i].RequestValue, formInfo["M1kaisya_nm"]);
				paramCol["M1syukkaten_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1syukkaten_cd"][i].RequestValue, formInfo["M1syukkaten_cd"]);
				paramCol["M1syukkaten_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1syukkaten_nm"][i].RequestValue, formInfo["M1syukkaten_nm"]);
				paramCol["M1scmden_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1scmden_cd"][i].RequestValue, formInfo["M1scmden_cd"]);
				paramCol["M1scm_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1scm_cd"][i].RequestValue, formInfo["M1scm_cd"]);
				paramCol["M1denpyo_bango"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1denpyo_bango"][i].RequestValue, formInfo["M1denpyo_bango"]);
				paramCol["M1syukka_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1syukka_ymd"][i].RequestValue, formInfo["M1syukka_ymd"]);
				paramCol["M1syukka_ymd"][i].DateFullValue = RequestParameterUtil.GetDateFullValue(
					paramCol["M1syukka_ymd"][i].RequestValue, formInfo["M1syukka_ymd"]);
				paramCol["M1yotei_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1yotei_su"][i].RequestValue, formInfo["M1yotei_su"]);
				paramCol["M1kyakucyu"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1kyakucyu"][i].RequestValue, formInfo["M1kyakucyu"]);
				paramCol["M1negaki"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1negaki"][i].RequestValue, formInfo["M1negaki"]);
				paramCol["M1tenpolc_kbn_hdn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tenpolc_kbn_hdn"][i].RequestValue, formInfo["M1tenpolc_kbn_hdn"]);
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
			Te080f01Form formVO = (Te080f01Form)pageContext.GetFormVO();

			//カード項目の入力値をFormVOにコピーする
			if (paramCol["Head_tenpo_cd"].UnformatValue != null)
			{
				formVO.Head_tenpo_cd = paramCol["Head_tenpo_cd"].UnformatValue;
			}
			if (paramCol["Head_tenpo_nm"].UnformatValue != null)
			{
				formVO.Head_tenpo_nm = paramCol["Head_tenpo_nm"].UnformatValue;
			}
			if (paramCol["Scm_gokei"].UnformatValue != null)
			{
				formVO.Scm_gokei = paramCol["Scm_gokei"].UnformatValue;
			}
			if (paramCol["Denpyo_gokei"].UnformatValue != null)
			{
				formVO.Denpyo_gokei = paramCol["Denpyo_gokei"].UnformatValue;
			}
			if (paramCol["Selectrowno"].UnformatValue != null)
			{
				formVO.Selectrowno = paramCol["Selectrowno"].UnformatValue;
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
				Te080f01M1Form te080f01M1Form = (Te080f01M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					te080f01M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1kaisya_cd"][i].UnformatValue != null)
				{
					te080f01M1Form.M1kaisya_cd = paramCol["M1kaisya_cd"][i].UnformatValue;
				}
				if (paramCol["M1kaisya_nm"][i].UnformatValue != null)
				{
					te080f01M1Form.M1kaisya_nm = paramCol["M1kaisya_nm"][i].UnformatValue;
				}
				if (paramCol["M1syukkaten_cd"][i].UnformatValue != null)
				{
					te080f01M1Form.M1syukkaten_cd = paramCol["M1syukkaten_cd"][i].UnformatValue;
				}
				if (paramCol["M1syukkaten_nm"][i].UnformatValue != null)
				{
					te080f01M1Form.M1syukkaten_nm = paramCol["M1syukkaten_nm"][i].UnformatValue;
				}
				if (paramCol["M1scmden_cd"][i].UnformatValue != null)
				{
					te080f01M1Form.M1scmden_cd = paramCol["M1scmden_cd"][i].UnformatValue;
				}
				if (paramCol["M1scm_cd"][i].UnformatValue != null)
				{
					te080f01M1Form.M1scm_cd = paramCol["M1scm_cd"][i].UnformatValue;
				}
				if (paramCol["M1denpyo_bango"][i].UnformatValue != null)
				{
					te080f01M1Form.M1denpyo_bango = paramCol["M1denpyo_bango"][i].UnformatValue;
				}
				if (paramCol["M1syukka_ymd"][i].DateFullValue != null)
				{
					te080f01M1Form.M1syukka_ymd = paramCol["M1syukka_ymd"][i].DateFullValue;
				}
				if (paramCol["M1yotei_su"][i].UnformatValue != null)
				{
					te080f01M1Form.M1yotei_su = paramCol["M1yotei_su"][i].UnformatValue;
				}
				if (paramCol["M1kyakucyu"][i].UnformatValue != null)
				{
					te080f01M1Form.M1kyakucyu = paramCol["M1kyakucyu"][i].UnformatValue;
				}
				if (paramCol["M1negaki"][i].UnformatValue != null)
				{
					te080f01M1Form.M1negaki = paramCol["M1negaki"][i].UnformatValue;
				}
				if (paramCol["M1tenpolc_kbn_hdn"][i].UnformatValue != null)
				{
					te080f01M1Form.M1tenpolc_kbn_hdn = paramCol["M1tenpolc_kbn_hdn"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					te080f01M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					te080f01M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					te080f01M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Te080f01Form formVO, StandardCheckManager checker)
		{
			if (formVO.Head_tenpo_cd != null)
			{
				checker.DoCheck("Head_tenpo_cd", formVO.Head_tenpo_cd);
			}
			if (formVO.Head_tenpo_nm != null)
			{
				checker.DoCheck("Head_tenpo_nm", formVO.Head_tenpo_nm);
			}
			if (formVO.Scm_gokei != null)
			{
				checker.DoCheck("Scm_gokei", formVO.Scm_gokei);
			}
			if (formVO.Denpyo_gokei != null)
			{
				checker.DoCheck("Denpyo_gokei", formVO.Denpyo_gokei);
			}
			if (formVO.Selectrowno != null)
			{
				checker.DoCheck("Selectrowno", formVO.Selectrowno);
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
		public static void ValidateM1InputValue(Te080f01Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Te080f01M1Form te080f01M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, te080f01M1Form, i, m1List);
				if (te080f01M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", te080f01M1Form.M1rowno, i, m1List);
				}
				if (te080f01M1Form.M1kaisya_cd != null)
				{
					checker.DoCheck("M1kaisya_cd", te080f01M1Form.M1kaisya_cd, i, m1List);
				}
				if (te080f01M1Form.M1kaisya_nm != null)
				{
					checker.DoCheck("M1kaisya_nm", te080f01M1Form.M1kaisya_nm, i, m1List);
				}
				if (te080f01M1Form.M1syukkaten_cd != null)
				{
					checker.DoCheck("M1syukkaten_cd", te080f01M1Form.M1syukkaten_cd, i, m1List);
				}
				if (te080f01M1Form.M1syukkaten_nm != null)
				{
					checker.DoCheck("M1syukkaten_nm", te080f01M1Form.M1syukkaten_nm, i, m1List);
				}
				if (te080f01M1Form.M1scmden_cd != null)
				{
					checker.DoCheck("M1scmden_cd", te080f01M1Form.M1scmden_cd, i, m1List);
				}
				if (te080f01M1Form.M1scm_cd != null)
				{
					checker.DoCheck("M1scm_cd", te080f01M1Form.M1scm_cd, i, m1List);
				}
				if (te080f01M1Form.M1denpyo_bango != null)
				{
					checker.DoCheck("M1denpyo_bango", te080f01M1Form.M1denpyo_bango, i, m1List);
				}
				if (te080f01M1Form.M1syukka_ymd != null)
				{
					checker.DoCheck("M1syukka_ymd", te080f01M1Form.M1syukka_ymd, i, m1List);
				}
				if (te080f01M1Form.M1yotei_su != null)
				{
					checker.DoCheck("M1yotei_su", te080f01M1Form.M1yotei_su, i, m1List);
				}
				if (te080f01M1Form.M1kyakucyu != null)
				{
					checker.DoCheck("M1kyakucyu", te080f01M1Form.M1kyakucyu, i, m1List);
				}
				if (te080f01M1Form.M1negaki != null)
				{
					checker.DoCheck("M1negaki", te080f01M1Form.M1negaki, i, m1List);
				}
				if (te080f01M1Form.M1tenpolc_kbn_hdn != null)
				{
					checker.DoCheck("M1tenpolc_kbn_hdn", te080f01M1Form.M1tenpolc_kbn_hdn, i, m1List);
				}
				if (te080f01M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", te080f01M1Form.M1selectorcheckbox, i, m1List);
				}
				if (te080f01M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", te080f01M1Form.M1entersyoriflg, i, m1List);
				}
				if (te080f01M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", te080f01M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Te080f01Form formVO, StandardCodeCheckManager checker)
		{
			checker.DoCheck("Btnheadtenpocd", formVO);
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Te080f01Form formVO, StandardCodeCheckManager checker)
		{
			checker.DoCheck("M1btnkaisha_cd", formVO);
			checker.DoCheck("M1btnsyukkatencd", formVO);
		}
	}
}

