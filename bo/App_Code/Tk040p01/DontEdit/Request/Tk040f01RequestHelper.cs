using com.xebio.bo.Tk040p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Tk040p01.Request
{
  /// <summary>
  /// Tk040f01RequestHelper の概要の説明です。
  /// </summary>
  public static class Tk040f01RequestHelper
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
			Tk040f01Form formVO = (Tk040f01Form)pageContext.GetFormVO();

			//カード部を初期化する
			paramCol.InitCardItems(formInfo.GetCardItems());
			//明細「M1」部を初期化する
			paramCol.InitListItems(formInfo.GetListItems("M1"), formVO.GetList("M1").CurrentCount);
			//カード項目の入力値を取得する
			paramCol["Head_tenpo_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_nm"]);
			paramCol["Bumon_cd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_cd_from"]);
			paramCol["Bumon_nm_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_nm_from"]);
			paramCol["Bumon_cd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_cd_to"]);
			paramCol["Bumon_nm_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_nm_to"]);
			paramCol["Hanbaikanryo_ymd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hanbaikanryo_ymd_from"]);
			paramCol["Hanbaikanryo_ymd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hanbaikanryo_ymd_to"]);
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
			paramCol["Scan_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Scan_cd"]);
			paramCol["Scan_cd2"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Scan_cd2"]);
			paramCol["Scan_cd3"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Scan_cd3"]);
			paramCol["Scan_cd4"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Scan_cd4"]);
			paramCol["Scan_cd5"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Scan_cd5"]);
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
				paramCol["M1hanbaikanryo_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hanbaikanryo_ymd"]);
				paramCol["M1iro_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1iro_nm"]);
				paramCol["M1size_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1size_nm"]);
				paramCol["M1scan_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1scan_cd"]);
				paramCol["M1face_no"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1face_no"]);
				paramCol["M1tana_dan"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tana_dan"]);
				paramCol["M1tanaorosi_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tanaorosi_su"]);
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
			Tk040f01Form formVO = (Tk040f01Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Bumon_cd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_cd_from"].RequestValue, formInfo["Bumon_cd_from"]);
			paramCol["Bumon_nm_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_nm_from"].RequestValue, formInfo["Bumon_nm_from"]);
			paramCol["Bumon_cd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_cd_to"].RequestValue, formInfo["Bumon_cd_to"]);
			paramCol["Bumon_nm_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_nm_to"].RequestValue, formInfo["Bumon_nm_to"]);
			paramCol["Hanbaikanryo_ymd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hanbaikanryo_ymd_from"].RequestValue, formInfo["Hanbaikanryo_ymd_from"]);
			paramCol["Hanbaikanryo_ymd_from"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Hanbaikanryo_ymd_from"].RequestValue, formInfo["Hanbaikanryo_ymd_from"]);
			paramCol["Hanbaikanryo_ymd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hanbaikanryo_ymd_to"].RequestValue, formInfo["Hanbaikanryo_ymd_to"]);
			paramCol["Hanbaikanryo_ymd_to"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Hanbaikanryo_ymd_to"].RequestValue, formInfo["Hanbaikanryo_ymd_to"]);
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
			paramCol["Scan_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Scan_cd"].RequestValue, formInfo["Scan_cd"]);
			paramCol["Scan_cd2"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Scan_cd2"].RequestValue, formInfo["Scan_cd2"]);
			paramCol["Scan_cd3"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Scan_cd3"].RequestValue, formInfo["Scan_cd3"]);
			paramCol["Scan_cd4"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Scan_cd4"].RequestValue, formInfo["Scan_cd4"]);
			paramCol["Scan_cd5"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Scan_cd5"].RequestValue, formInfo["Scan_cd5"]);
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
				paramCol["M1hanbaikanryo_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hanbaikanryo_ymd"][i].RequestValue, formInfo["M1hanbaikanryo_ymd"]);
				paramCol["M1hanbaikanryo_ymd"][i].DateFullValue = RequestParameterUtil.GetDateFullValue(
					paramCol["M1hanbaikanryo_ymd"][i].RequestValue, formInfo["M1hanbaikanryo_ymd"]);
				paramCol["M1iro_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1iro_nm"][i].RequestValue, formInfo["M1iro_nm"]);
				paramCol["M1size_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1size_nm"][i].RequestValue, formInfo["M1size_nm"]);
				paramCol["M1scan_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1scan_cd"][i].RequestValue, formInfo["M1scan_cd"]);
				paramCol["M1face_no"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1face_no"][i].RequestValue, formInfo["M1face_no"]);
				paramCol["M1tana_dan"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tana_dan"][i].RequestValue, formInfo["M1tana_dan"]);
				paramCol["M1tanaorosi_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tanaorosi_su"][i].RequestValue, formInfo["M1tanaorosi_su"]);
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
			Tk040f01Form formVO = (Tk040f01Form)pageContext.GetFormVO();

			//カード項目の入力値をFormVOにコピーする
			if (paramCol["Head_tenpo_cd"].UnformatValue != null)
			{
				formVO.Head_tenpo_cd = paramCol["Head_tenpo_cd"].UnformatValue;
			}
			if (paramCol["Head_tenpo_nm"].UnformatValue != null)
			{
				formVO.Head_tenpo_nm = paramCol["Head_tenpo_nm"].UnformatValue;
			}
			if (paramCol["Bumon_cd_from"].UnformatValue != null)
			{
				formVO.Bumon_cd_from = paramCol["Bumon_cd_from"].UnformatValue;
			}
			if (paramCol["Bumon_nm_from"].UnformatValue != null)
			{
				formVO.Bumon_nm_from = paramCol["Bumon_nm_from"].UnformatValue;
			}
			if (paramCol["Bumon_cd_to"].UnformatValue != null)
			{
				formVO.Bumon_cd_to = paramCol["Bumon_cd_to"].UnformatValue;
			}
			if (paramCol["Bumon_nm_to"].UnformatValue != null)
			{
				formVO.Bumon_nm_to = paramCol["Bumon_nm_to"].UnformatValue;
			}
			if (paramCol["Hanbaikanryo_ymd_from"].DateFullValue != null)
			{
				formVO.Hanbaikanryo_ymd_from = paramCol["Hanbaikanryo_ymd_from"].DateFullValue;
			}
			if (paramCol["Hanbaikanryo_ymd_to"].DateFullValue != null)
			{
				formVO.Hanbaikanryo_ymd_to = paramCol["Hanbaikanryo_ymd_to"].DateFullValue;
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
			if (paramCol["Scan_cd"].UnformatValue != null)
			{
				formVO.Scan_cd = paramCol["Scan_cd"].UnformatValue;
			}
			if (paramCol["Scan_cd2"].UnformatValue != null)
			{
				formVO.Scan_cd2 = paramCol["Scan_cd2"].UnformatValue;
			}
			if (paramCol["Scan_cd3"].UnformatValue != null)
			{
				formVO.Scan_cd3 = paramCol["Scan_cd3"].UnformatValue;
			}
			if (paramCol["Scan_cd4"].UnformatValue != null)
			{
				formVO.Scan_cd4 = paramCol["Scan_cd4"].UnformatValue;
			}
			if (paramCol["Scan_cd5"].UnformatValue != null)
			{
				formVO.Scan_cd5 = paramCol["Scan_cd5"].UnformatValue;
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
				Tk040f01M1Form tk040f01M1Form = (Tk040f01M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					tk040f01M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1bumon_cd"][i].UnformatValue != null)
				{
					tk040f01M1Form.M1bumon_cd = paramCol["M1bumon_cd"][i].UnformatValue;
				}
				if (paramCol["M1bumonkana_nm"][i].UnformatValue != null)
				{
					tk040f01M1Form.M1bumonkana_nm = paramCol["M1bumonkana_nm"][i].UnformatValue;
				}
				if (paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue != null)
				{
					tk040f01M1Form.M1hinsyu_ryaku_nm = paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue;
				}
				if (paramCol["M1burando_nm"][i].UnformatValue != null)
				{
					tk040f01M1Form.M1burando_nm = paramCol["M1burando_nm"][i].UnformatValue;
				}
				if (paramCol["M1jisya_hbn"][i].UnformatValue != null)
				{
					tk040f01M1Form.M1jisya_hbn = paramCol["M1jisya_hbn"][i].UnformatValue;
				}
				if (paramCol["M1maker_hbn"][i].UnformatValue != null)
				{
					tk040f01M1Form.M1maker_hbn = paramCol["M1maker_hbn"][i].UnformatValue;
				}
				if (paramCol["M1syonmk"][i].UnformatValue != null)
				{
					tk040f01M1Form.M1syonmk = paramCol["M1syonmk"][i].UnformatValue;
				}
				if (paramCol["M1hanbaikanryo_ymd"][i].DateFullValue != null)
				{
					tk040f01M1Form.M1hanbaikanryo_ymd = paramCol["M1hanbaikanryo_ymd"][i].DateFullValue;
				}
				if (paramCol["M1iro_nm"][i].UnformatValue != null)
				{
					tk040f01M1Form.M1iro_nm = paramCol["M1iro_nm"][i].UnformatValue;
				}
				if (paramCol["M1size_nm"][i].UnformatValue != null)
				{
					tk040f01M1Form.M1size_nm = paramCol["M1size_nm"][i].UnformatValue;
				}
				if (paramCol["M1scan_cd"][i].UnformatValue != null)
				{
					tk040f01M1Form.M1scan_cd = paramCol["M1scan_cd"][i].UnformatValue;
				}
				if (paramCol["M1face_no"][i].UnformatValue != null)
				{
					tk040f01M1Form.M1face_no = paramCol["M1face_no"][i].UnformatValue;
				}
				if (paramCol["M1tana_dan"][i].UnformatValue != null)
				{
					tk040f01M1Form.M1tana_dan = paramCol["M1tana_dan"][i].UnformatValue;
				}
				if (paramCol["M1tanaorosi_su"][i].UnformatValue != null)
				{
					tk040f01M1Form.M1tanaorosi_su = paramCol["M1tanaorosi_su"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					tk040f01M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					tk040f01M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					tk040f01M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Tk040f01Form formVO, StandardCheckManager checker)
		{
			if (formVO.Head_tenpo_cd != null)
			{
				checker.DoCheck("Head_tenpo_cd", formVO.Head_tenpo_cd);
			}
			if (formVO.Head_tenpo_nm != null)
			{
				checker.DoCheck("Head_tenpo_nm", formVO.Head_tenpo_nm);
			}
			if (formVO.Bumon_cd_from != null)
			{
				checker.DoCheck("Bumon_cd_from", formVO.Bumon_cd_from);
			}
			if (formVO.Bumon_nm_from != null)
			{
				checker.DoCheck("Bumon_nm_from", formVO.Bumon_nm_from);
			}
			if (formVO.Bumon_cd_to != null)
			{
				checker.DoCheck("Bumon_cd_to", formVO.Bumon_cd_to);
			}
			if (formVO.Bumon_nm_to != null)
			{
				checker.DoCheck("Bumon_nm_to", formVO.Bumon_nm_to);
			}
			if (formVO.Hanbaikanryo_ymd_from != null)
			{
				checker.DoCheck("Hanbaikanryo_ymd_from", formVO.Hanbaikanryo_ymd_from);
			}
			if (formVO.Hanbaikanryo_ymd_to != null)
			{
				checker.DoCheck("Hanbaikanryo_ymd_to", formVO.Hanbaikanryo_ymd_to);
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
			if (formVO.Scan_cd != null)
			{
				checker.DoCheck("Scan_cd", formVO.Scan_cd);
			}
			if (formVO.Scan_cd2 != null)
			{
				checker.DoCheck("Scan_cd2", formVO.Scan_cd2);
			}
			if (formVO.Scan_cd3 != null)
			{
				checker.DoCheck("Scan_cd3", formVO.Scan_cd3);
			}
			if (formVO.Scan_cd4 != null)
			{
				checker.DoCheck("Scan_cd4", formVO.Scan_cd4);
			}
			if (formVO.Scan_cd5 != null)
			{
				checker.DoCheck("Scan_cd5", formVO.Scan_cd5);
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
		public static void ValidateM1InputValue(Tk040f01Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Tk040f01M1Form tk040f01M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, tk040f01M1Form, i, m1List);
				if (tk040f01M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", tk040f01M1Form.M1rowno, i, m1List);
				}
				if (tk040f01M1Form.M1bumon_cd != null)
				{
					checker.DoCheck("M1bumon_cd", tk040f01M1Form.M1bumon_cd, i, m1List);
				}
				if (tk040f01M1Form.M1bumonkana_nm != null)
				{
					checker.DoCheck("M1bumonkana_nm", tk040f01M1Form.M1bumonkana_nm, i, m1List);
				}
				if (tk040f01M1Form.M1hinsyu_ryaku_nm != null)
				{
					checker.DoCheck("M1hinsyu_ryaku_nm", tk040f01M1Form.M1hinsyu_ryaku_nm, i, m1List);
				}
				if (tk040f01M1Form.M1burando_nm != null)
				{
					checker.DoCheck("M1burando_nm", tk040f01M1Form.M1burando_nm, i, m1List);
				}
				if (tk040f01M1Form.M1jisya_hbn != null)
				{
					checker.DoCheck("M1jisya_hbn", tk040f01M1Form.M1jisya_hbn, i, m1List);
				}
				if (tk040f01M1Form.M1maker_hbn != null)
				{
					checker.DoCheck("M1maker_hbn", tk040f01M1Form.M1maker_hbn, i, m1List);
				}
				if (tk040f01M1Form.M1syonmk != null)
				{
					checker.DoCheck("M1syonmk", tk040f01M1Form.M1syonmk, i, m1List);
				}
				if (tk040f01M1Form.M1hanbaikanryo_ymd != null)
				{
					checker.DoCheck("M1hanbaikanryo_ymd", tk040f01M1Form.M1hanbaikanryo_ymd, i, m1List);
				}
				if (tk040f01M1Form.M1iro_nm != null)
				{
					checker.DoCheck("M1iro_nm", tk040f01M1Form.M1iro_nm, i, m1List);
				}
				if (tk040f01M1Form.M1size_nm != null)
				{
					checker.DoCheck("M1size_nm", tk040f01M1Form.M1size_nm, i, m1List);
				}
				if (tk040f01M1Form.M1scan_cd != null)
				{
					checker.DoCheck("M1scan_cd", tk040f01M1Form.M1scan_cd, i, m1List);
				}
				if (tk040f01M1Form.M1face_no != null)
				{
					checker.DoCheck("M1face_no", tk040f01M1Form.M1face_no, i, m1List);
				}
				if (tk040f01M1Form.M1tana_dan != null)
				{
					checker.DoCheck("M1tana_dan", tk040f01M1Form.M1tana_dan, i, m1List);
				}
				if (tk040f01M1Form.M1tanaorosi_su != null)
				{
					checker.DoCheck("M1tanaorosi_su", tk040f01M1Form.M1tanaorosi_su, i, m1List);
				}
				if (tk040f01M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", tk040f01M1Form.M1selectorcheckbox, i, m1List);
				}
				if (tk040f01M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", tk040f01M1Form.M1entersyoriflg, i, m1List);
				}
				if (tk040f01M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", tk040f01M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Tk040f01Form formVO, StandardCodeCheckManager checker)
		{
			checker.DoCheck("Btnheadtenpocd", formVO);
			checker.DoCheck("Btnbumon_cd_from", formVO);
			checker.DoCheck("Btnbumon_cd_to", formVO);
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Tk040f01Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

