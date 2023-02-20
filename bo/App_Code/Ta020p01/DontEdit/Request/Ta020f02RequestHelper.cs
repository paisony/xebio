using com.xebio.bo.Ta020p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Ta020p01.Request
{
  /// <summary>
  /// Ta020f02RequestHelper の概要の説明です。
  /// </summary>
  public static class Ta020f02RequestHelper
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
			Ta020f02Form formVO = (Ta020f02Form)pageContext.GetFormVO();

			//カード部を初期化する
			paramCol.InitCardItems(formInfo.GetCardItems());
			//明細「M1」部を初期化する
			paramCol.InitListItems(formInfo.GetListItems("M1"), formVO.GetList("M1").CurrentCount);
			//カード項目の入力値を取得する
			paramCol["Head_tenpo_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_nm"]);
			paramCol["Stkmodeno"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Stkmodeno"]);
			paramCol["Irai_ymd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Irai_ymd"]);
			paramCol["Tantosya_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tantosya_cd"]);
			paramCol["Hanbaiin_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hanbaiin_nm"]);
			paramCol["Irairiyu_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Irairiyu_cd"]);
			paramCol["Gokei_irai_su"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokei_irai_su"]);
			paramCol["Gokei_genkakin"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokei_genkakin"]);
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
				paramCol["M1bumonkana_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1bumonkana_nm"]);
				paramCol["M1hyoka_kb"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hyoka_kb"]);
				paramCol["M1kahi_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1kahi_nm"]);
				paramCol["M1tenzaiko_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tenzaiko_su"]);
				paramCol["M1hinsyu_ryaku_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hinsyu_ryaku_nm"]);
				paramCol["M1nyukayotei_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1nyukayotei_su"]);
				paramCol["M1uriage_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1uriage_su"]);
				paramCol["M1burando_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1burando_nm"]);
				paramCol["M1jido_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1jido_su"]);
				paramCol["M1jisya_hbn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1jisya_hbn"]);
				paramCol["M1syohin_zokusei"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1syohin_zokusei"]);
				paramCol["M1iro_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1iro_nm"]);
				paramCol["M1size_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1size_nm"]);
				paramCol["M1maker_hbn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1maker_hbn"]);
				paramCol["M1syonmk"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1syonmk"]);
				paramCol["M1hatchu_msg"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hatchu_msg"]);
				paramCol["M1scan_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1scan_cd"]);
				paramCol["M1irai_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1irai_su"]);
				paramCol["M1genkakin"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1genkakin"]);
				paramCol["M1irai_su_hdn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1irai_su_hdn"]);
				paramCol["M1gen_tnk"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1gen_tnk"]);
				paramCol["M1genkakin_hdn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1genkakin_hdn"]);
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
			Ta020f02Form formVO = (Ta020f02Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Stkmodeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Stkmodeno"].RequestValue, formInfo["Stkmodeno"]);
			paramCol["Irai_ymd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Irai_ymd"].RequestValue, formInfo["Irai_ymd"]);
			paramCol["Irai_ymd"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Irai_ymd"].RequestValue, formInfo["Irai_ymd"]);
			paramCol["Tantosya_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tantosya_cd"].RequestValue, formInfo["Tantosya_cd"]);
			paramCol["Hanbaiin_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hanbaiin_nm"].RequestValue, formInfo["Hanbaiin_nm"]);
			paramCol["Irairiyu_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Irairiyu_cd"].RequestValue, formInfo["Irairiyu_cd"]);
			paramCol["Gokei_irai_su"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokei_irai_su"].RequestValue, formInfo["Gokei_irai_su"]);
			paramCol["Gokei_genkakin"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokei_genkakin"].RequestValue, formInfo["Gokei_genkakin"]);
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
				paramCol["M1bumonkana_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1bumonkana_nm"][i].RequestValue, formInfo["M1bumonkana_nm"]);
				paramCol["M1hyoka_kb"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hyoka_kb"][i].RequestValue, formInfo["M1hyoka_kb"]);
				paramCol["M1kahi_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1kahi_nm"][i].RequestValue, formInfo["M1kahi_nm"]);
				paramCol["M1tenzaiko_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tenzaiko_su"][i].RequestValue, formInfo["M1tenzaiko_su"]);
				paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hinsyu_ryaku_nm"][i].RequestValue, formInfo["M1hinsyu_ryaku_nm"]);
				paramCol["M1nyukayotei_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1nyukayotei_su"][i].RequestValue, formInfo["M1nyukayotei_su"]);
				paramCol["M1uriage_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1uriage_su"][i].RequestValue, formInfo["M1uriage_su"]);
				paramCol["M1burando_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1burando_nm"][i].RequestValue, formInfo["M1burando_nm"]);
				paramCol["M1jido_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1jido_su"][i].RequestValue, formInfo["M1jido_su"]);
				paramCol["M1jisya_hbn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1jisya_hbn"][i].RequestValue, formInfo["M1jisya_hbn"]);
				paramCol["M1syohin_zokusei"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1syohin_zokusei"][i].RequestValue, formInfo["M1syohin_zokusei"]);
				paramCol["M1iro_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1iro_nm"][i].RequestValue, formInfo["M1iro_nm"]);
				paramCol["M1size_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1size_nm"][i].RequestValue, formInfo["M1size_nm"]);
				paramCol["M1maker_hbn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1maker_hbn"][i].RequestValue, formInfo["M1maker_hbn"]);
				paramCol["M1syonmk"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1syonmk"][i].RequestValue, formInfo["M1syonmk"]);
				paramCol["M1hatchu_msg"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hatchu_msg"][i].RequestValue, formInfo["M1hatchu_msg"]);
				paramCol["M1scan_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1scan_cd"][i].RequestValue, formInfo["M1scan_cd"]);
				paramCol["M1irai_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1irai_su"][i].RequestValue, formInfo["M1irai_su"]);
				paramCol["M1genkakin"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1genkakin"][i].RequestValue, formInfo["M1genkakin"]);
				paramCol["M1irai_su_hdn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1irai_su_hdn"][i].RequestValue, formInfo["M1irai_su_hdn"]);
				paramCol["M1gen_tnk"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1gen_tnk"][i].RequestValue, formInfo["M1gen_tnk"]);
				paramCol["M1genkakin_hdn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1genkakin_hdn"][i].RequestValue, formInfo["M1genkakin_hdn"]);
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
			Ta020f02Form formVO = (Ta020f02Form)pageContext.GetFormVO();

			//カード項目の入力値をFormVOにコピーする
			if (paramCol["Head_tenpo_cd"].UnformatValue != null)
			{
				formVO.Head_tenpo_cd = paramCol["Head_tenpo_cd"].UnformatValue;
			}
			if (paramCol["Head_tenpo_nm"].UnformatValue != null)
			{
				formVO.Head_tenpo_nm = paramCol["Head_tenpo_nm"].UnformatValue;
			}
			if (paramCol["Stkmodeno"].UnformatValue != null)
			{
				formVO.Stkmodeno = paramCol["Stkmodeno"].UnformatValue;
			}
			if (paramCol["Irai_ymd"].DateFullValue != null)
			{
				formVO.Irai_ymd = paramCol["Irai_ymd"].DateFullValue;
			}
			if (paramCol["Tantosya_cd"].UnformatValue != null)
			{
				formVO.Tantosya_cd = paramCol["Tantosya_cd"].UnformatValue;
			}
			if (paramCol["Hanbaiin_nm"].UnformatValue != null)
			{
				formVO.Hanbaiin_nm = paramCol["Hanbaiin_nm"].UnformatValue;
			}
			if (paramCol["Irairiyu_cd"].UnformatValue != null)
			{
				formVO.Irairiyu_cd = paramCol["Irairiyu_cd"].UnformatValue;
			}
			if (paramCol["Gokei_irai_su"].UnformatValue != null)
			{
				formVO.Gokei_irai_su = paramCol["Gokei_irai_su"].UnformatValue;
			}
			if (paramCol["Gokei_genkakin"].UnformatValue != null)
			{
				formVO.Gokei_genkakin = paramCol["Gokei_genkakin"].UnformatValue;
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
				Ta020f02M1Form ta020f02M1Form = (Ta020f02M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					ta020f02M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1bumonkana_nm"][i].UnformatValue != null)
				{
					ta020f02M1Form.M1bumonkana_nm = paramCol["M1bumonkana_nm"][i].UnformatValue;
				}
				if (paramCol["M1hyoka_kb"][i].UnformatValue != null)
				{
					ta020f02M1Form.M1hyoka_kb = paramCol["M1hyoka_kb"][i].UnformatValue;
				}
				if (paramCol["M1kahi_nm"][i].UnformatValue != null)
				{
					ta020f02M1Form.M1kahi_nm = paramCol["M1kahi_nm"][i].UnformatValue;
				}
				if (paramCol["M1tenzaiko_su"][i].UnformatValue != null)
				{
					ta020f02M1Form.M1tenzaiko_su = paramCol["M1tenzaiko_su"][i].UnformatValue;
				}
				if (paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue != null)
				{
					ta020f02M1Form.M1hinsyu_ryaku_nm = paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue;
				}
				if (paramCol["M1nyukayotei_su"][i].UnformatValue != null)
				{
					ta020f02M1Form.M1nyukayotei_su = paramCol["M1nyukayotei_su"][i].UnformatValue;
				}
				if (paramCol["M1uriage_su"][i].UnformatValue != null)
				{
					ta020f02M1Form.M1uriage_su = paramCol["M1uriage_su"][i].UnformatValue;
				}
				if (paramCol["M1burando_nm"][i].UnformatValue != null)
				{
					ta020f02M1Form.M1burando_nm = paramCol["M1burando_nm"][i].UnformatValue;
				}
				if (paramCol["M1jido_su"][i].UnformatValue != null)
				{
					ta020f02M1Form.M1jido_su = paramCol["M1jido_su"][i].UnformatValue;
				}
				if (paramCol["M1jisya_hbn"][i].UnformatValue != null)
				{
					ta020f02M1Form.M1jisya_hbn = paramCol["M1jisya_hbn"][i].UnformatValue;
				}
				if (paramCol["M1syohin_zokusei"][i].UnformatValue != null)
				{
					ta020f02M1Form.M1syohin_zokusei = paramCol["M1syohin_zokusei"][i].UnformatValue;
				}
				if (paramCol["M1iro_nm"][i].UnformatValue != null)
				{
					ta020f02M1Form.M1iro_nm = paramCol["M1iro_nm"][i].UnformatValue;
				}
				if (paramCol["M1size_nm"][i].UnformatValue != null)
				{
					ta020f02M1Form.M1size_nm = paramCol["M1size_nm"][i].UnformatValue;
				}
				if (paramCol["M1maker_hbn"][i].UnformatValue != null)
				{
					ta020f02M1Form.M1maker_hbn = paramCol["M1maker_hbn"][i].UnformatValue;
				}
				if (paramCol["M1syonmk"][i].UnformatValue != null)
				{
					ta020f02M1Form.M1syonmk = paramCol["M1syonmk"][i].UnformatValue;
				}
				if (paramCol["M1hatchu_msg"][i].UnformatValue != null)
				{
					ta020f02M1Form.M1hatchu_msg = paramCol["M1hatchu_msg"][i].UnformatValue;
				}
				if (paramCol["M1scan_cd"][i].UnformatValue != null)
				{
					ta020f02M1Form.M1scan_cd = paramCol["M1scan_cd"][i].UnformatValue;
				}
				if (paramCol["M1irai_su"][i].UnformatValue != null)
				{
					ta020f02M1Form.M1irai_su = paramCol["M1irai_su"][i].UnformatValue;
				}
				if (paramCol["M1genkakin"][i].UnformatValue != null)
				{
					ta020f02M1Form.M1genkakin = paramCol["M1genkakin"][i].UnformatValue;
				}
				if (paramCol["M1irai_su_hdn"][i].UnformatValue != null)
				{
					ta020f02M1Form.M1irai_su_hdn = paramCol["M1irai_su_hdn"][i].UnformatValue;
				}
				if (paramCol["M1gen_tnk"][i].UnformatValue != null)
				{
					ta020f02M1Form.M1gen_tnk = paramCol["M1gen_tnk"][i].UnformatValue;
				}
				if (paramCol["M1genkakin_hdn"][i].UnformatValue != null)
				{
					ta020f02M1Form.M1genkakin_hdn = paramCol["M1genkakin_hdn"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					ta020f02M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					ta020f02M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					ta020f02M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Ta020f02Form formVO, StandardCheckManager checker)
		{
			if (formVO.Head_tenpo_cd != null)
			{
				checker.DoCheck("Head_tenpo_cd", formVO.Head_tenpo_cd);
			}
			if (formVO.Head_tenpo_nm != null)
			{
				checker.DoCheck("Head_tenpo_nm", formVO.Head_tenpo_nm);
			}
			if (formVO.Stkmodeno != null)
			{
				checker.DoCheck("Stkmodeno", formVO.Stkmodeno);
			}
			if (formVO.Irai_ymd != null)
			{
				checker.DoCheck("Irai_ymd", formVO.Irai_ymd);
			}
			if (formVO.Tantosya_cd != null)
			{
				checker.DoCheck("Tantosya_cd", formVO.Tantosya_cd);
			}
			if (formVO.Hanbaiin_nm != null)
			{
				checker.DoCheck("Hanbaiin_nm", formVO.Hanbaiin_nm);
			}
			if (formVO.Irairiyu_cd != null)
			{
				checker.DoCheck("Irairiyu_cd", formVO.Irairiyu_cd);
			}
			if (formVO.Gokei_irai_su != null)
			{
				checker.DoCheck("Gokei_irai_su", formVO.Gokei_irai_su);
			}
			if (formVO.Gokei_genkakin != null)
			{
				checker.DoCheck("Gokei_genkakin", formVO.Gokei_genkakin);
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
		public static void ValidateM1InputValue(Ta020f02Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Ta020f02M1Form ta020f02M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, ta020f02M1Form, i, m1List);
				if (ta020f02M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", ta020f02M1Form.M1rowno, i, m1List);
				}
				if (ta020f02M1Form.M1bumonkana_nm != null)
				{
					checker.DoCheck("M1bumonkana_nm", ta020f02M1Form.M1bumonkana_nm, i, m1List);
				}
				if (ta020f02M1Form.M1hyoka_kb != null)
				{
					checker.DoCheck("M1hyoka_kb", ta020f02M1Form.M1hyoka_kb, i, m1List);
				}
				if (ta020f02M1Form.M1kahi_nm != null)
				{
					checker.DoCheck("M1kahi_nm", ta020f02M1Form.M1kahi_nm, i, m1List);
				}
				if (ta020f02M1Form.M1tenzaiko_su != null)
				{
					checker.DoCheck("M1tenzaiko_su", ta020f02M1Form.M1tenzaiko_su, i, m1List);
				}
				if (ta020f02M1Form.M1hinsyu_ryaku_nm != null)
				{
					checker.DoCheck("M1hinsyu_ryaku_nm", ta020f02M1Form.M1hinsyu_ryaku_nm, i, m1List);
				}
				if (ta020f02M1Form.M1nyukayotei_su != null)
				{
					checker.DoCheck("M1nyukayotei_su", ta020f02M1Form.M1nyukayotei_su, i, m1List);
				}
				if (ta020f02M1Form.M1uriage_su != null)
				{
					checker.DoCheck("M1uriage_su", ta020f02M1Form.M1uriage_su, i, m1List);
				}
				if (ta020f02M1Form.M1burando_nm != null)
				{
					checker.DoCheck("M1burando_nm", ta020f02M1Form.M1burando_nm, i, m1List);
				}
				if (ta020f02M1Form.M1jido_su != null)
				{
					checker.DoCheck("M1jido_su", ta020f02M1Form.M1jido_su, i, m1List);
				}
				if (ta020f02M1Form.M1jisya_hbn != null)
				{
					checker.DoCheck("M1jisya_hbn", ta020f02M1Form.M1jisya_hbn, i, m1List);
				}
				if (ta020f02M1Form.M1syohin_zokusei != null)
				{
					checker.DoCheck("M1syohin_zokusei", ta020f02M1Form.M1syohin_zokusei, i, m1List);
				}
				if (ta020f02M1Form.M1iro_nm != null)
				{
					checker.DoCheck("M1iro_nm", ta020f02M1Form.M1iro_nm, i, m1List);
				}
				if (ta020f02M1Form.M1size_nm != null)
				{
					checker.DoCheck("M1size_nm", ta020f02M1Form.M1size_nm, i, m1List);
				}
				if (ta020f02M1Form.M1maker_hbn != null)
				{
					checker.DoCheck("M1maker_hbn", ta020f02M1Form.M1maker_hbn, i, m1List);
				}
				if (ta020f02M1Form.M1syonmk != null)
				{
					checker.DoCheck("M1syonmk", ta020f02M1Form.M1syonmk, i, m1List);
				}
				if (ta020f02M1Form.M1hatchu_msg != null)
				{
					checker.DoCheck("M1hatchu_msg", ta020f02M1Form.M1hatchu_msg, i, m1List);
				}
				if (ta020f02M1Form.M1scan_cd != null)
				{
					checker.DoCheck("M1scan_cd", ta020f02M1Form.M1scan_cd, i, m1List);
				}
				if (ta020f02M1Form.M1irai_su != null)
				{
					checker.DoCheck("M1irai_su", ta020f02M1Form.M1irai_su, i, m1List);
				}
				if (ta020f02M1Form.M1genkakin != null)
				{
					checker.DoCheck("M1genkakin", ta020f02M1Form.M1genkakin, i, m1List);
				}
				if (ta020f02M1Form.M1irai_su_hdn != null)
				{
					checker.DoCheck("M1irai_su_hdn", ta020f02M1Form.M1irai_su_hdn, i, m1List);
				}
				if (ta020f02M1Form.M1gen_tnk != null)
				{
					checker.DoCheck("M1gen_tnk", ta020f02M1Form.M1gen_tnk, i, m1List);
				}
				if (ta020f02M1Form.M1genkakin_hdn != null)
				{
					checker.DoCheck("M1genkakin_hdn", ta020f02M1Form.M1genkakin_hdn, i, m1List);
				}
				if (ta020f02M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", ta020f02M1Form.M1selectorcheckbox, i, m1List);
				}
				if (ta020f02M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", ta020f02M1Form.M1entersyoriflg, i, m1List);
				}
				if (ta020f02M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", ta020f02M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Ta020f02Form formVO, StandardCodeCheckManager checker)
		{
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Ta020f02Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

