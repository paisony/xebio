using com.xebio.bo.Tg040p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Tg040p01.Request
{
  /// <summary>
  /// Tg040f02RequestHelper の概要の説明です。
  /// </summary>
  public static class Tg040f02RequestHelper
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
			Tg040f02Form formVO = (Tg040f02Form)pageContext.GetFormVO();

			//カード部を初期化する
			paramCol.InitCardItems(formInfo.GetCardItems());
			//明細「M1」部を初期化する
			paramCol.InitListItems(formInfo.GetListItems("M1"), formVO.GetList("M1").CurrentCount);
			//カード項目の入力値を取得する
			paramCol["Head_tenpo_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_nm"]);
			paramCol["Stock_no"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Stock_no"]);
			paramCol["Ymd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Ymd"]);
			paramCol["Tm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tm"]);
			paramCol["Nyuryokutan_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Nyuryokutan_cd"]);
			paramCol["Nyuryokutan_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Nyuryokutan_nm"]);
			paramCol["Label_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Label_cd"]);
			paramCol["Label_ip"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Label_ip"]);
			paramCol["Label_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Label_nm"]);
			paramCol["Stkmodeno"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Stkmodeno"]);
			paramCol["Gokei_suryo"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokei_suryo"]);
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
				paramCol["M1bumon_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1bumon_cd"]);
				paramCol["M1bumonkana_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1bumonkana_nm"]);
				paramCol["M1hinsyu_ryaku_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hinsyu_ryaku_nm"]);
				paramCol["M1burando_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1burando_nm"]);
				paramCol["M1jisya_hbn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1jisya_hbn"]);
				paramCol["M1maker_hbn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1maker_hbn"]);
				paramCol["M1syonmk"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1syonmk"]);
				paramCol["M1scan_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1scan_cd"]);
				paramCol["M1hanbaikanryo_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hanbaikanryo_ymd"]);
				paramCol["M1iro_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1iro_nm"]);
				paramCol["M1size_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1size_nm"]);
				paramCol["M1suryo"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1suryo"]);
				paramCol["M1suryo_hdn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1suryo_hdn"]);
				paramCol["M1hinsyu_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hinsyu_cd"]);
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
			Tg040f02Form formVO = (Tg040f02Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Stock_no"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Stock_no"].RequestValue, formInfo["Stock_no"]);
			paramCol["Ymd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Ymd"].RequestValue, formInfo["Ymd"]);
			paramCol["Ymd"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Ymd"].RequestValue, formInfo["Ymd"]);
			paramCol["Tm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tm"].RequestValue, formInfo["Tm"]);
			paramCol["Tm"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Tm"].RequestValue, formInfo["Tm"]);
			paramCol["Nyuryokutan_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Nyuryokutan_cd"].RequestValue, formInfo["Nyuryokutan_cd"]);
			paramCol["Nyuryokutan_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Nyuryokutan_nm"].RequestValue, formInfo["Nyuryokutan_nm"]);
			paramCol["Label_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Label_cd"].RequestValue, formInfo["Label_cd"]);
			paramCol["Label_ip"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Label_ip"].RequestValue, formInfo["Label_ip"]);
			paramCol["Label_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Label_nm"].RequestValue, formInfo["Label_nm"]);
			paramCol["Stkmodeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Stkmodeno"].RequestValue, formInfo["Stkmodeno"]);
			paramCol["Gokei_suryo"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokei_suryo"].RequestValue, formInfo["Gokei_suryo"]);
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
				paramCol["M1bumon_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1bumon_cd"][i].RequestValue, formInfo["M1bumon_cd"]);
				paramCol["M1bumonkana_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1bumonkana_nm"][i].RequestValue, formInfo["M1bumonkana_nm"]);
				paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hinsyu_ryaku_nm"][i].RequestValue, formInfo["M1hinsyu_ryaku_nm"]);
				paramCol["M1burando_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1burando_nm"][i].RequestValue, formInfo["M1burando_nm"]);
				paramCol["M1jisya_hbn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1jisya_hbn"][i].RequestValue, formInfo["M1jisya_hbn"]);
				paramCol["M1maker_hbn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1maker_hbn"][i].RequestValue, formInfo["M1maker_hbn"]);
				paramCol["M1syonmk"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1syonmk"][i].RequestValue, formInfo["M1syonmk"]);
				paramCol["M1scan_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1scan_cd"][i].RequestValue, formInfo["M1scan_cd"]);
				paramCol["M1hanbaikanryo_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hanbaikanryo_ymd"][i].RequestValue, formInfo["M1hanbaikanryo_ymd"]);
				paramCol["M1hanbaikanryo_ymd"][i].DateFullValue = RequestParameterUtil.GetDateFullValue(
					paramCol["M1hanbaikanryo_ymd"][i].RequestValue, formInfo["M1hanbaikanryo_ymd"]);
				paramCol["M1iro_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1iro_nm"][i].RequestValue, formInfo["M1iro_nm"]);
				paramCol["M1size_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1size_nm"][i].RequestValue, formInfo["M1size_nm"]);
				paramCol["M1suryo"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1suryo"][i].RequestValue, formInfo["M1suryo"]);
				paramCol["M1suryo_hdn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1suryo_hdn"][i].RequestValue, formInfo["M1suryo_hdn"]);
				paramCol["M1hinsyu_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hinsyu_cd"][i].RequestValue, formInfo["M1hinsyu_cd"]);
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
			Tg040f02Form formVO = (Tg040f02Form)pageContext.GetFormVO();

			//カード項目の入力値をFormVOにコピーする
			if (paramCol["Head_tenpo_cd"].UnformatValue != null)
			{
				formVO.Head_tenpo_cd = paramCol["Head_tenpo_cd"].UnformatValue;
			}
			if (paramCol["Head_tenpo_nm"].UnformatValue != null)
			{
				formVO.Head_tenpo_nm = paramCol["Head_tenpo_nm"].UnformatValue;
			}
			if (paramCol["Stock_no"].UnformatValue != null)
			{
				formVO.Stock_no = paramCol["Stock_no"].UnformatValue;
			}
			if (paramCol["Ymd"].DateFullValue != null)
			{
				formVO.Ymd = paramCol["Ymd"].DateFullValue;
			}
			if (paramCol["Tm"].DateFullValue != null)
			{
				formVO.Tm = paramCol["Tm"].DateFullValue;
			}
			if (paramCol["Nyuryokutan_cd"].UnformatValue != null)
			{
				formVO.Nyuryokutan_cd = paramCol["Nyuryokutan_cd"].UnformatValue;
			}
			if (paramCol["Nyuryokutan_nm"].UnformatValue != null)
			{
				formVO.Nyuryokutan_nm = paramCol["Nyuryokutan_nm"].UnformatValue;
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
			if (paramCol["Stkmodeno"].UnformatValue != null)
			{
				formVO.Stkmodeno = paramCol["Stkmodeno"].UnformatValue;
			}
			if (paramCol["Gokei_suryo"].UnformatValue != null)
			{
				formVO.Gokei_suryo = paramCol["Gokei_suryo"].UnformatValue;
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
				Tg040f02M1Form tg040f02M1Form = (Tg040f02M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					tg040f02M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1bumon_cd"][i].UnformatValue != null)
				{
					tg040f02M1Form.M1bumon_cd = paramCol["M1bumon_cd"][i].UnformatValue;
				}
				if (paramCol["M1bumonkana_nm"][i].UnformatValue != null)
				{
					tg040f02M1Form.M1bumonkana_nm = paramCol["M1bumonkana_nm"][i].UnformatValue;
				}
				if (paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue != null)
				{
					tg040f02M1Form.M1hinsyu_ryaku_nm = paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue;
				}
				if (paramCol["M1burando_nm"][i].UnformatValue != null)
				{
					tg040f02M1Form.M1burando_nm = paramCol["M1burando_nm"][i].UnformatValue;
				}
				if (paramCol["M1jisya_hbn"][i].UnformatValue != null)
				{
					tg040f02M1Form.M1jisya_hbn = paramCol["M1jisya_hbn"][i].UnformatValue;
				}
				if (paramCol["M1maker_hbn"][i].UnformatValue != null)
				{
					tg040f02M1Form.M1maker_hbn = paramCol["M1maker_hbn"][i].UnformatValue;
				}
				if (paramCol["M1syonmk"][i].UnformatValue != null)
				{
					tg040f02M1Form.M1syonmk = paramCol["M1syonmk"][i].UnformatValue;
				}
				if (paramCol["M1scan_cd"][i].UnformatValue != null)
				{
					tg040f02M1Form.M1scan_cd = paramCol["M1scan_cd"][i].UnformatValue;
				}
				if (paramCol["M1hanbaikanryo_ymd"][i].DateFullValue != null)
				{
					tg040f02M1Form.M1hanbaikanryo_ymd = paramCol["M1hanbaikanryo_ymd"][i].DateFullValue;
				}
				if (paramCol["M1iro_nm"][i].UnformatValue != null)
				{
					tg040f02M1Form.M1iro_nm = paramCol["M1iro_nm"][i].UnformatValue;
				}
				if (paramCol["M1size_nm"][i].UnformatValue != null)
				{
					tg040f02M1Form.M1size_nm = paramCol["M1size_nm"][i].UnformatValue;
				}
				if (paramCol["M1suryo"][i].UnformatValue != null)
				{
					tg040f02M1Form.M1suryo = paramCol["M1suryo"][i].UnformatValue;
				}
				if (paramCol["M1suryo_hdn"][i].UnformatValue != null)
				{
					tg040f02M1Form.M1suryo_hdn = paramCol["M1suryo_hdn"][i].UnformatValue;
				}
				if (paramCol["M1hinsyu_cd"][i].UnformatValue != null)
				{
					tg040f02M1Form.M1hinsyu_cd = paramCol["M1hinsyu_cd"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					tg040f02M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					tg040f02M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					tg040f02M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Tg040f02Form formVO, StandardCheckManager checker)
		{
			if (formVO.Head_tenpo_cd != null)
			{
				checker.DoCheck("Head_tenpo_cd", formVO.Head_tenpo_cd);
			}
			if (formVO.Head_tenpo_nm != null)
			{
				checker.DoCheck("Head_tenpo_nm", formVO.Head_tenpo_nm);
			}
			if (formVO.Stock_no != null)
			{
				checker.DoCheck("Stock_no", formVO.Stock_no);
			}
			if (formVO.Ymd != null)
			{
				checker.DoCheck("Ymd", formVO.Ymd);
			}
			if (formVO.Tm != null)
			{
				checker.DoCheck("Tm", formVO.Tm);
			}
			if (formVO.Nyuryokutan_cd != null)
			{
				checker.DoCheck("Nyuryokutan_cd", formVO.Nyuryokutan_cd);
			}
			if (formVO.Nyuryokutan_nm != null)
			{
				checker.DoCheck("Nyuryokutan_nm", formVO.Nyuryokutan_nm);
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
			if (formVO.Stkmodeno != null)
			{
				checker.DoCheck("Stkmodeno", formVO.Stkmodeno);
			}
			if (formVO.Gokei_suryo != null)
			{
				checker.DoCheck("Gokei_suryo", formVO.Gokei_suryo);
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
		public static void ValidateM1InputValue(Tg040f02Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Tg040f02M1Form tg040f02M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, tg040f02M1Form, i, m1List);
				if (tg040f02M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", tg040f02M1Form.M1rowno, i, m1List);
				}
				if (tg040f02M1Form.M1bumon_cd != null)
				{
					checker.DoCheck("M1bumon_cd", tg040f02M1Form.M1bumon_cd, i, m1List);
				}
				if (tg040f02M1Form.M1bumonkana_nm != null)
				{
					checker.DoCheck("M1bumonkana_nm", tg040f02M1Form.M1bumonkana_nm, i, m1List);
				}
				if (tg040f02M1Form.M1hinsyu_ryaku_nm != null)
				{
					checker.DoCheck("M1hinsyu_ryaku_nm", tg040f02M1Form.M1hinsyu_ryaku_nm, i, m1List);
				}
				if (tg040f02M1Form.M1burando_nm != null)
				{
					checker.DoCheck("M1burando_nm", tg040f02M1Form.M1burando_nm, i, m1List);
				}
				if (tg040f02M1Form.M1jisya_hbn != null)
				{
					checker.DoCheck("M1jisya_hbn", tg040f02M1Form.M1jisya_hbn, i, m1List);
				}
				if (tg040f02M1Form.M1maker_hbn != null)
				{
					checker.DoCheck("M1maker_hbn", tg040f02M1Form.M1maker_hbn, i, m1List);
				}
				if (tg040f02M1Form.M1syonmk != null)
				{
					checker.DoCheck("M1syonmk", tg040f02M1Form.M1syonmk, i, m1List);
				}
				if (tg040f02M1Form.M1scan_cd != null)
				{
					checker.DoCheck("M1scan_cd", tg040f02M1Form.M1scan_cd, i, m1List);
				}
				if (tg040f02M1Form.M1hanbaikanryo_ymd != null)
				{
					checker.DoCheck("M1hanbaikanryo_ymd", tg040f02M1Form.M1hanbaikanryo_ymd, i, m1List);
				}
				if (tg040f02M1Form.M1iro_nm != null)
				{
					checker.DoCheck("M1iro_nm", tg040f02M1Form.M1iro_nm, i, m1List);
				}
				if (tg040f02M1Form.M1size_nm != null)
				{
					checker.DoCheck("M1size_nm", tg040f02M1Form.M1size_nm, i, m1List);
				}
				if (tg040f02M1Form.M1suryo != null)
				{
					checker.DoCheck("M1suryo", tg040f02M1Form.M1suryo, i, m1List);
				}
				if (tg040f02M1Form.M1suryo_hdn != null)
				{
					checker.DoCheck("M1suryo_hdn", tg040f02M1Form.M1suryo_hdn, i, m1List);
				}
				if (tg040f02M1Form.M1hinsyu_cd != null)
				{
					checker.DoCheck("M1hinsyu_cd", tg040f02M1Form.M1hinsyu_cd, i, m1List);
				}
				if (tg040f02M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", tg040f02M1Form.M1selectorcheckbox, i, m1List);
				}
				if (tg040f02M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", tg040f02M1Form.M1entersyoriflg, i, m1List);
				}
				if (tg040f02M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", tg040f02M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Tg040f02Form formVO, StandardCodeCheckManager checker)
		{
			checker.DoCheck("Btnlabel_cd", formVO);
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Tg040f02Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

