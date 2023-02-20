using com.xebio.bo.Th020p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Th020p01.Request
{
  /// <summary>
  /// Th020f01RequestHelper の概要の説明です。
  /// </summary>
  public static class Th020f01RequestHelper
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
			Th020f01Form formVO = (Th020f01Form)pageContext.GetFormVO();

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
			paramCol["Old_jisya_hbn_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Old_jisya_hbn_from"]);
			paramCol["Old_jisya_hbn_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Old_jisya_hbn_to"]);
			paramCol["Kaisya_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Kaisya_cd"]);
			paramCol["Kaisya_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Kaisya_nm"]);
			paramCol["Old_jisya_hbn"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Old_jisya_hbn"]);
			paramCol["Old_jisya_hbn2"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Old_jisya_hbn2"]);
			paramCol["Old_jisya_hbn3"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Old_jisya_hbn3"]);
			paramCol["Old_jisya_hbn4"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Old_jisya_hbn4"]);
			paramCol["Old_jisya_hbn5"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Old_jisya_hbn5"]);
			paramCol["Kaisya_cd2"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Kaisya_cd2"]);
			paramCol["Kaisya_nm2"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Kaisya_nm2"]);
			paramCol["Scan_cd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Scan_cd_from"]);
			paramCol["Scan_cd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Scan_cd_to"]);
			paramCol["Kaisya_cd3"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Kaisya_cd3"]);
			paramCol["Kaisya_nm3"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Kaisya_nm3"]);
			paramCol["Maker_hbn"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Maker_hbn"]);
			paramCol["Kaisya_cd4"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Kaisya_cd4"]);
			paramCol["Kaisya_nm4"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Kaisya_nm4"]);
			paramCol["Searchcnt"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Searchcnt"]);
			paramCol["Zaiko_serchstk"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Zaiko_serchstk"]);
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
				paramCol["M1syohin_zokusei"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1syohin_zokusei"]);
				paramCol["M1maker_hbn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1maker_hbn"]);
				paramCol["M1syonmk"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1syonmk"]);
				paramCol["M1iro_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1iro_nm"]);
				paramCol["M1tenzaiko_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tenzaiko_su"]);
				paramCol["M1zentenzaiko_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1zentenzaiko_su"]);
				paramCol["M1syoka_rtu"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1syoka_rtu"]);
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
			Th020f01Form formVO = (Th020f01Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Modeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Modeno"].RequestValue, formInfo["Modeno"]);
			paramCol["Stkmodeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Stkmodeno"].RequestValue, formInfo["Stkmodeno"]);
			paramCol["Old_jisya_hbn_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Old_jisya_hbn_from"].RequestValue, formInfo["Old_jisya_hbn_from"]);
			paramCol["Old_jisya_hbn_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Old_jisya_hbn_to"].RequestValue, formInfo["Old_jisya_hbn_to"]);
			paramCol["Kaisya_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Kaisya_cd"].RequestValue, formInfo["Kaisya_cd"]);
			paramCol["Kaisya_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Kaisya_nm"].RequestValue, formInfo["Kaisya_nm"]);
			paramCol["Old_jisya_hbn"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Old_jisya_hbn"].RequestValue, formInfo["Old_jisya_hbn"]);
			paramCol["Old_jisya_hbn2"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Old_jisya_hbn2"].RequestValue, formInfo["Old_jisya_hbn2"]);
			paramCol["Old_jisya_hbn3"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Old_jisya_hbn3"].RequestValue, formInfo["Old_jisya_hbn3"]);
			paramCol["Old_jisya_hbn4"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Old_jisya_hbn4"].RequestValue, formInfo["Old_jisya_hbn4"]);
			paramCol["Old_jisya_hbn5"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Old_jisya_hbn5"].RequestValue, formInfo["Old_jisya_hbn5"]);
			paramCol["Kaisya_cd2"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Kaisya_cd2"].RequestValue, formInfo["Kaisya_cd2"]);
			paramCol["Kaisya_nm2"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Kaisya_nm2"].RequestValue, formInfo["Kaisya_nm2"]);
			paramCol["Scan_cd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Scan_cd_from"].RequestValue, formInfo["Scan_cd_from"]);
			paramCol["Scan_cd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Scan_cd_to"].RequestValue, formInfo["Scan_cd_to"]);
			paramCol["Kaisya_cd3"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Kaisya_cd3"].RequestValue, formInfo["Kaisya_cd3"]);
			paramCol["Kaisya_nm3"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Kaisya_nm3"].RequestValue, formInfo["Kaisya_nm3"]);
			paramCol["Maker_hbn"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Maker_hbn"].RequestValue, formInfo["Maker_hbn"]);
			paramCol["Kaisya_cd4"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Kaisya_cd4"].RequestValue, formInfo["Kaisya_cd4"]);
			paramCol["Kaisya_nm4"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Kaisya_nm4"].RequestValue, formInfo["Kaisya_nm4"]);
			paramCol["Searchcnt"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Searchcnt"].RequestValue, formInfo["Searchcnt"]);
			paramCol["Zaiko_serchstk"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Zaiko_serchstk"].RequestValue, formInfo["Zaiko_serchstk"]);
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
				paramCol["M1syohin_zokusei"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1syohin_zokusei"][i].RequestValue, formInfo["M1syohin_zokusei"]);
				paramCol["M1maker_hbn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1maker_hbn"][i].RequestValue, formInfo["M1maker_hbn"]);
				paramCol["M1syonmk"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1syonmk"][i].RequestValue, formInfo["M1syonmk"]);
				paramCol["M1iro_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1iro_nm"][i].RequestValue, formInfo["M1iro_nm"]);
				paramCol["M1tenzaiko_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tenzaiko_su"][i].RequestValue, formInfo["M1tenzaiko_su"]);
				paramCol["M1zentenzaiko_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1zentenzaiko_su"][i].RequestValue, formInfo["M1zentenzaiko_su"]);
				paramCol["M1syoka_rtu"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1syoka_rtu"][i].RequestValue, formInfo["M1syoka_rtu"]);
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
			Th020f01Form formVO = (Th020f01Form)pageContext.GetFormVO();

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
			if (paramCol["Old_jisya_hbn_from"].UnformatValue != null)
			{
				formVO.Old_jisya_hbn_from = paramCol["Old_jisya_hbn_from"].UnformatValue;
			}
			if (paramCol["Old_jisya_hbn_to"].UnformatValue != null)
			{
				formVO.Old_jisya_hbn_to = paramCol["Old_jisya_hbn_to"].UnformatValue;
			}
			if (paramCol["Kaisya_cd"].UnformatValue != null)
			{
				formVO.Kaisya_cd = paramCol["Kaisya_cd"].UnformatValue;
			}
			if (paramCol["Kaisya_nm"].UnformatValue != null)
			{
				formVO.Kaisya_nm = paramCol["Kaisya_nm"].UnformatValue;
			}
			if (paramCol["Old_jisya_hbn"].UnformatValue != null)
			{
				formVO.Old_jisya_hbn = paramCol["Old_jisya_hbn"].UnformatValue;
			}
			if (paramCol["Old_jisya_hbn2"].UnformatValue != null)
			{
				formVO.Old_jisya_hbn2 = paramCol["Old_jisya_hbn2"].UnformatValue;
			}
			if (paramCol["Old_jisya_hbn3"].UnformatValue != null)
			{
				formVO.Old_jisya_hbn3 = paramCol["Old_jisya_hbn3"].UnformatValue;
			}
			if (paramCol["Old_jisya_hbn4"].UnformatValue != null)
			{
				formVO.Old_jisya_hbn4 = paramCol["Old_jisya_hbn4"].UnformatValue;
			}
			if (paramCol["Old_jisya_hbn5"].UnformatValue != null)
			{
				formVO.Old_jisya_hbn5 = paramCol["Old_jisya_hbn5"].UnformatValue;
			}
			if (paramCol["Kaisya_cd2"].UnformatValue != null)
			{
				formVO.Kaisya_cd2 = paramCol["Kaisya_cd2"].UnformatValue;
			}
			if (paramCol["Kaisya_nm2"].UnformatValue != null)
			{
				formVO.Kaisya_nm2 = paramCol["Kaisya_nm2"].UnformatValue;
			}
			if (paramCol["Scan_cd_from"].UnformatValue != null)
			{
				formVO.Scan_cd_from = paramCol["Scan_cd_from"].UnformatValue;
			}
			if (paramCol["Scan_cd_to"].UnformatValue != null)
			{
				formVO.Scan_cd_to = paramCol["Scan_cd_to"].UnformatValue;
			}
			if (paramCol["Kaisya_cd3"].UnformatValue != null)
			{
				formVO.Kaisya_cd3 = paramCol["Kaisya_cd3"].UnformatValue;
			}
			if (paramCol["Kaisya_nm3"].UnformatValue != null)
			{
				formVO.Kaisya_nm3 = paramCol["Kaisya_nm3"].UnformatValue;
			}
			if (paramCol["Maker_hbn"].UnformatValue != null)
			{
				formVO.Maker_hbn = paramCol["Maker_hbn"].UnformatValue;
			}
			if (paramCol["Kaisya_cd4"].UnformatValue != null)
			{
				formVO.Kaisya_cd4 = paramCol["Kaisya_cd4"].UnformatValue;
			}
			if (paramCol["Kaisya_nm4"].UnformatValue != null)
			{
				formVO.Kaisya_nm4 = paramCol["Kaisya_nm4"].UnformatValue;
			}
			if (paramCol["Searchcnt"].UnformatValue != null)
			{
				formVO.Searchcnt = paramCol["Searchcnt"].UnformatValue;
			}
			if (paramCol["Zaiko_serchstk"].UnformatValue != null)
			{
				formVO.Zaiko_serchstk = paramCol["Zaiko_serchstk"].UnformatValue;
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
				Th020f01M1Form th020f01M1Form = (Th020f01M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					th020f01M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1bumon_cd"][i].UnformatValue != null)
				{
					th020f01M1Form.M1bumon_cd = paramCol["M1bumon_cd"][i].UnformatValue;
				}
				if (paramCol["M1bumonkana_nm"][i].UnformatValue != null)
				{
					th020f01M1Form.M1bumonkana_nm = paramCol["M1bumonkana_nm"][i].UnformatValue;
				}
				if (paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue != null)
				{
					th020f01M1Form.M1hinsyu_ryaku_nm = paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue;
				}
				if (paramCol["M1burando_nm"][i].UnformatValue != null)
				{
					th020f01M1Form.M1burando_nm = paramCol["M1burando_nm"][i].UnformatValue;
				}
				if (paramCol["M1syohin_zokusei"][i].UnformatValue != null)
				{
					th020f01M1Form.M1syohin_zokusei = paramCol["M1syohin_zokusei"][i].UnformatValue;
				}
				if (paramCol["M1maker_hbn"][i].UnformatValue != null)
				{
					th020f01M1Form.M1maker_hbn = paramCol["M1maker_hbn"][i].UnformatValue;
				}
				if (paramCol["M1syonmk"][i].UnformatValue != null)
				{
					th020f01M1Form.M1syonmk = paramCol["M1syonmk"][i].UnformatValue;
				}
				if (paramCol["M1iro_nm"][i].UnformatValue != null)
				{
					th020f01M1Form.M1iro_nm = paramCol["M1iro_nm"][i].UnformatValue;
				}
				if (paramCol["M1tenzaiko_su"][i].UnformatValue != null)
				{
					th020f01M1Form.M1tenzaiko_su = paramCol["M1tenzaiko_su"][i].UnformatValue;
				}
				if (paramCol["M1zentenzaiko_su"][i].UnformatValue != null)
				{
					th020f01M1Form.M1zentenzaiko_su = paramCol["M1zentenzaiko_su"][i].UnformatValue;
				}
				if (paramCol["M1syoka_rtu"][i].UnformatValue != null)
				{
					th020f01M1Form.M1syoka_rtu = paramCol["M1syoka_rtu"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					th020f01M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					th020f01M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					th020f01M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Th020f01Form formVO, StandardCheckManager checker)
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
			if (formVO.Old_jisya_hbn_from != null)
			{
				checker.DoCheck("Old_jisya_hbn_from", formVO.Old_jisya_hbn_from);
			}
			if (formVO.Old_jisya_hbn_to != null)
			{
				checker.DoCheck("Old_jisya_hbn_to", formVO.Old_jisya_hbn_to);
			}
			if (formVO.Kaisya_cd != null)
			{
				checker.DoCheck("Kaisya_cd", formVO.Kaisya_cd);
			}
			if (formVO.Kaisya_nm != null)
			{
				checker.DoCheck("Kaisya_nm", formVO.Kaisya_nm);
			}
			if (formVO.Old_jisya_hbn != null)
			{
				checker.DoCheck("Old_jisya_hbn", formVO.Old_jisya_hbn);
			}
			if (formVO.Old_jisya_hbn2 != null)
			{
				checker.DoCheck("Old_jisya_hbn2", formVO.Old_jisya_hbn2);
			}
			if (formVO.Old_jisya_hbn3 != null)
			{
				checker.DoCheck("Old_jisya_hbn3", formVO.Old_jisya_hbn3);
			}
			if (formVO.Old_jisya_hbn4 != null)
			{
				checker.DoCheck("Old_jisya_hbn4", formVO.Old_jisya_hbn4);
			}
			if (formVO.Old_jisya_hbn5 != null)
			{
				checker.DoCheck("Old_jisya_hbn5", formVO.Old_jisya_hbn5);
			}
			if (formVO.Kaisya_cd2 != null)
			{
				checker.DoCheck("Kaisya_cd2", formVO.Kaisya_cd2);
			}
			if (formVO.Kaisya_nm2 != null)
			{
				checker.DoCheck("Kaisya_nm2", formVO.Kaisya_nm2);
			}
			if (formVO.Scan_cd_from != null)
			{
				checker.DoCheck("Scan_cd_from", formVO.Scan_cd_from);
			}
			if (formVO.Scan_cd_to != null)
			{
				checker.DoCheck("Scan_cd_to", formVO.Scan_cd_to);
			}
			if (formVO.Kaisya_cd3 != null)
			{
				checker.DoCheck("Kaisya_cd3", formVO.Kaisya_cd3);
			}
			if (formVO.Kaisya_nm3 != null)
			{
				checker.DoCheck("Kaisya_nm3", formVO.Kaisya_nm3);
			}
			if (formVO.Maker_hbn != null)
			{
				checker.DoCheck("Maker_hbn", formVO.Maker_hbn);
			}
			if (formVO.Kaisya_cd4 != null)
			{
				checker.DoCheck("Kaisya_cd4", formVO.Kaisya_cd4);
			}
			if (formVO.Kaisya_nm4 != null)
			{
				checker.DoCheck("Kaisya_nm4", formVO.Kaisya_nm4);
			}
			if (formVO.Searchcnt != null)
			{
				checker.DoCheck("Searchcnt", formVO.Searchcnt);
			}
			if (formVO.Zaiko_serchstk != null)
			{
				checker.DoCheck("Zaiko_serchstk", formVO.Zaiko_serchstk);
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
		public static void ValidateM1InputValue(Th020f01Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Th020f01M1Form th020f01M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, th020f01M1Form, i, m1List);
				if (th020f01M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", th020f01M1Form.M1rowno, i, m1List);
				}
				if (th020f01M1Form.M1bumon_cd != null)
				{
					checker.DoCheck("M1bumon_cd", th020f01M1Form.M1bumon_cd, i, m1List);
				}
				if (th020f01M1Form.M1bumonkana_nm != null)
				{
					checker.DoCheck("M1bumonkana_nm", th020f01M1Form.M1bumonkana_nm, i, m1List);
				}
				if (th020f01M1Form.M1hinsyu_ryaku_nm != null)
				{
					checker.DoCheck("M1hinsyu_ryaku_nm", th020f01M1Form.M1hinsyu_ryaku_nm, i, m1List);
				}
				if (th020f01M1Form.M1burando_nm != null)
				{
					checker.DoCheck("M1burando_nm", th020f01M1Form.M1burando_nm, i, m1List);
				}
				if (th020f01M1Form.M1syohin_zokusei != null)
				{
					checker.DoCheck("M1syohin_zokusei", th020f01M1Form.M1syohin_zokusei, i, m1List);
				}
				if (th020f01M1Form.M1maker_hbn != null)
				{
					checker.DoCheck("M1maker_hbn", th020f01M1Form.M1maker_hbn, i, m1List);
				}
				if (th020f01M1Form.M1syonmk != null)
				{
					checker.DoCheck("M1syonmk", th020f01M1Form.M1syonmk, i, m1List);
				}
				if (th020f01M1Form.M1iro_nm != null)
				{
					checker.DoCheck("M1iro_nm", th020f01M1Form.M1iro_nm, i, m1List);
				}
				if (th020f01M1Form.M1tenzaiko_su != null)
				{
					checker.DoCheck("M1tenzaiko_su", th020f01M1Form.M1tenzaiko_su, i, m1List);
				}
				if (th020f01M1Form.M1zentenzaiko_su != null)
				{
					checker.DoCheck("M1zentenzaiko_su", th020f01M1Form.M1zentenzaiko_su, i, m1List);
				}
				if (th020f01M1Form.M1syoka_rtu != null)
				{
					checker.DoCheck("M1syoka_rtu", th020f01M1Form.M1syoka_rtu, i, m1List);
				}
				if (th020f01M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", th020f01M1Form.M1selectorcheckbox, i, m1List);
				}
				if (th020f01M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", th020f01M1Form.M1entersyoriflg, i, m1List);
				}
				if (th020f01M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", th020f01M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Th020f01Form formVO, StandardCodeCheckManager checker)
		{
			checker.DoCheck("Btnheadtenpocd", formVO);
			checker.DoCheck("Btnkaisha_cd", formVO);
			checker.DoCheck("Btnkaisha_cd2", formVO);
			checker.DoCheck("Btnkaisha_cd3", formVO);
			checker.DoCheck("Btnmaker_hbn", formVO);
			checker.DoCheck("Btnkaisha_cd4", formVO);
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Th020f01Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

