using com.xebio.bo.Tb040p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Tb040p01.Request
{
  /// <summary>
  /// Tb040f01RequestHelper の概要の説明です。
  /// </summary>
  public static class Tb040f01RequestHelper
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
			Tb040f01Form formVO = (Tb040f01Form)pageContext.GetFormVO();

			//カード部を初期化する
			paramCol.InitCardItems(formInfo.GetCardItems());
			//明細「M1」部を初期化する
			paramCol.InitListItems(formInfo.GetListItems("M1"), formVO.GetList("M1").CurrentCount);
			//カード項目の入力値を取得する
			paramCol["Head_tenpo_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_nm"]);
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
				paramCol["M1siiresaki_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1siiresaki_cd"]);
				paramCol["M1siiresaki_ryaku_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1siiresaki_ryaku_nm"]);
				paramCol["M1denpyo_barcode"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1denpyo_barcode"]);
				paramCol["M1bumon_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1bumon_cd"]);
				paramCol["M1bumonkana_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1bumonkana_nm"]);
				paramCol["M1nyukayotei_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1nyukayotei_ymd"]);
				paramCol["M1nohin_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1nohin_su"]);
				paramCol["M1genka_kin"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1genka_kin"]);
				paramCol["M1kyakucyu"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1kyakucyu"]);
				paramCol["M1negaki"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1negaki"]);
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
			Tb040f01Form formVO = (Tb040f01Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
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
				paramCol["M1siiresaki_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1siiresaki_cd"][i].RequestValue, formInfo["M1siiresaki_cd"]);
				paramCol["M1siiresaki_ryaku_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1siiresaki_ryaku_nm"][i].RequestValue, formInfo["M1siiresaki_ryaku_nm"]);
				paramCol["M1denpyo_barcode"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1denpyo_barcode"][i].RequestValue, formInfo["M1denpyo_barcode"]);
				paramCol["M1bumon_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1bumon_cd"][i].RequestValue, formInfo["M1bumon_cd"]);
				paramCol["M1bumonkana_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1bumonkana_nm"][i].RequestValue, formInfo["M1bumonkana_nm"]);
				paramCol["M1nyukayotei_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1nyukayotei_ymd"][i].RequestValue, formInfo["M1nyukayotei_ymd"]);
				paramCol["M1nyukayotei_ymd"][i].DateFullValue = RequestParameterUtil.GetDateFullValue(
					paramCol["M1nyukayotei_ymd"][i].RequestValue, formInfo["M1nyukayotei_ymd"]);
				paramCol["M1nohin_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1nohin_su"][i].RequestValue, formInfo["M1nohin_su"]);
				paramCol["M1genka_kin"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1genka_kin"][i].RequestValue, formInfo["M1genka_kin"]);
				paramCol["M1kyakucyu"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1kyakucyu"][i].RequestValue, formInfo["M1kyakucyu"]);
				paramCol["M1negaki"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1negaki"][i].RequestValue, formInfo["M1negaki"]);
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
			Tb040f01Form formVO = (Tb040f01Form)pageContext.GetFormVO();

			//カード項目の入力値をFormVOにコピーする
			if (paramCol["Head_tenpo_cd"].UnformatValue != null)
			{
				formVO.Head_tenpo_cd = paramCol["Head_tenpo_cd"].UnformatValue;
			}
			if (paramCol["Head_tenpo_nm"].UnformatValue != null)
			{
				formVO.Head_tenpo_nm = paramCol["Head_tenpo_nm"].UnformatValue;
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
				Tb040f01M1Form tb040f01M1Form = (Tb040f01M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					tb040f01M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1siiresaki_cd"][i].UnformatValue != null)
				{
					tb040f01M1Form.M1siiresaki_cd = paramCol["M1siiresaki_cd"][i].UnformatValue;
				}
				if (paramCol["M1siiresaki_ryaku_nm"][i].UnformatValue != null)
				{
					tb040f01M1Form.M1siiresaki_ryaku_nm = paramCol["M1siiresaki_ryaku_nm"][i].UnformatValue;
				}
				if (paramCol["M1denpyo_barcode"][i].UnformatValue != null)
				{
					tb040f01M1Form.M1denpyo_barcode = paramCol["M1denpyo_barcode"][i].UnformatValue;
				}
				if (paramCol["M1bumon_cd"][i].UnformatValue != null)
				{
					tb040f01M1Form.M1bumon_cd = paramCol["M1bumon_cd"][i].UnformatValue;
				}
				if (paramCol["M1bumonkana_nm"][i].UnformatValue != null)
				{
					tb040f01M1Form.M1bumonkana_nm = paramCol["M1bumonkana_nm"][i].UnformatValue;
				}
				if (paramCol["M1nyukayotei_ymd"][i].DateFullValue != null)
				{
					tb040f01M1Form.M1nyukayotei_ymd = paramCol["M1nyukayotei_ymd"][i].DateFullValue;
				}
				if (paramCol["M1nohin_su"][i].UnformatValue != null)
				{
					tb040f01M1Form.M1nohin_su = paramCol["M1nohin_su"][i].UnformatValue;
				}
				if (paramCol["M1genka_kin"][i].UnformatValue != null)
				{
					tb040f01M1Form.M1genka_kin = paramCol["M1genka_kin"][i].UnformatValue;
				}
				if (paramCol["M1kyakucyu"][i].UnformatValue != null)
				{
					tb040f01M1Form.M1kyakucyu = paramCol["M1kyakucyu"][i].UnformatValue;
				}
				if (paramCol["M1negaki"][i].UnformatValue != null)
				{
					tb040f01M1Form.M1negaki = paramCol["M1negaki"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					tb040f01M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					tb040f01M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					tb040f01M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Tb040f01Form formVO, StandardCheckManager checker)
		{
			if (formVO.Head_tenpo_cd != null)
			{
				checker.DoCheck("Head_tenpo_cd", formVO.Head_tenpo_cd);
			}
			if (formVO.Head_tenpo_nm != null)
			{
				checker.DoCheck("Head_tenpo_nm", formVO.Head_tenpo_nm);
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
		public static void ValidateM1InputValue(Tb040f01Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Tb040f01M1Form tb040f01M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, tb040f01M1Form, i, m1List);
				if (tb040f01M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", tb040f01M1Form.M1rowno, i, m1List);
				}
				if (tb040f01M1Form.M1siiresaki_cd != null)
				{
					checker.DoCheck("M1siiresaki_cd", tb040f01M1Form.M1siiresaki_cd, i, m1List);
				}
				if (tb040f01M1Form.M1siiresaki_ryaku_nm != null)
				{
					checker.DoCheck("M1siiresaki_ryaku_nm", tb040f01M1Form.M1siiresaki_ryaku_nm, i, m1List);
				}
				if (tb040f01M1Form.M1denpyo_barcode != null)
				{
					checker.DoCheck("M1denpyo_barcode", tb040f01M1Form.M1denpyo_barcode, i, m1List);
				}
				if (tb040f01M1Form.M1bumon_cd != null)
				{
					checker.DoCheck("M1bumon_cd", tb040f01M1Form.M1bumon_cd, i, m1List);
				}
				if (tb040f01M1Form.M1bumonkana_nm != null)
				{
					checker.DoCheck("M1bumonkana_nm", tb040f01M1Form.M1bumonkana_nm, i, m1List);
				}
				if (tb040f01M1Form.M1nyukayotei_ymd != null)
				{
					checker.DoCheck("M1nyukayotei_ymd", tb040f01M1Form.M1nyukayotei_ymd, i, m1List);
				}
				if (tb040f01M1Form.M1nohin_su != null)
				{
					checker.DoCheck("M1nohin_su", tb040f01M1Form.M1nohin_su, i, m1List);
				}
				if (tb040f01M1Form.M1genka_kin != null)
				{
					checker.DoCheck("M1genka_kin", tb040f01M1Form.M1genka_kin, i, m1List);
				}
				if (tb040f01M1Form.M1kyakucyu != null)
				{
					checker.DoCheck("M1kyakucyu", tb040f01M1Form.M1kyakucyu, i, m1List);
				}
				if (tb040f01M1Form.M1negaki != null)
				{
					checker.DoCheck("M1negaki", tb040f01M1Form.M1negaki, i, m1List);
				}
				if (tb040f01M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", tb040f01M1Form.M1selectorcheckbox, i, m1List);
				}
				if (tb040f01M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", tb040f01M1Form.M1entersyoriflg, i, m1List);
				}
				if (tb040f01M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", tb040f01M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Tb040f01Form formVO, StandardCodeCheckManager checker)
		{
			checker.DoCheck("Btnheadtenpocd", formVO);
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Tb040f01Form formVO, StandardCodeCheckManager checker)
		{
			checker.DoCheck("M1btnsiiresaki_cd", formVO);
		}
	}
}

