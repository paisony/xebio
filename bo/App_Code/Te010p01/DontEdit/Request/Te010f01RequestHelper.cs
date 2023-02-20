using com.xebio.bo.Te010p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Te010p01.Request
{
  /// <summary>
  /// Te010f01RequestHelper の概要の説明です。
  /// </summary>
  public static class Te010f01RequestHelper
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
			Te010f01Form formVO = (Te010f01Form)pageContext.GetFormVO();

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
			paramCol["Denpyo_jyotai"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Denpyo_jyotai"]);
			paramCol["Denpyo_bango_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Denpyo_bango_from"]);
			paramCol["Denpyo_bango_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Denpyo_bango_to"]);
			paramCol["Siji_bango_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Siji_bango_from"]);
			paramCol["Siji_bango_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Siji_bango_to"]);
			paramCol["Syukka_ymd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Syukka_ymd_from"]);
			paramCol["Syukka_ymd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Syukka_ymd_to"]);
			paramCol["Kaisya_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Kaisya_cd"]);
			paramCol["Kaisya_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Kaisya_nm"]);
			paramCol["Jyuryoten_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Jyuryoten_cd"]);
			paramCol["Juryoten_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Juryoten_nm"]);
			paramCol["Nyuryokutan_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Nyuryokutan_cd"]);
			paramCol["Nyuryokutan_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Nyuryokutan_nm"]);
			paramCol["Bumon_cd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_cd_from"]);
			paramCol["Bumon_nm_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_nm_from"]);
			paramCol["Bumon_cd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_cd_to"]);
			paramCol["Bumon_nm_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_nm_to"]);
			paramCol["Shukkariyu_kbn"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Shukkariyu_kbn"]);
			paramCol["Old_jisya_hbn"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Old_jisya_hbn"]);
			paramCol["Maker_hbn"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Maker_hbn"]);
			paramCol["Scan_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Scan_cd"]);
			paramCol["Offline_no"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Offline_no"]);
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
				paramCol["M1kaisyakana_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1kaisyakana_nm"]);
				paramCol["M1jyuryoten_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1jyuryoten_cd"]);
				paramCol["M1juryoten_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1juryoten_nm"]);
				paramCol["M1scm_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1scm_cd"]);
				paramCol["M1siji_bango"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1siji_bango"]);
				paramCol["M1syukka_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1syukka_ymd"]);
				paramCol["M1jyuryo_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1jyuryo_ymd"]);
				paramCol["M1syukka_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1syukka_su"]);
				paramCol["M1kakutei_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1kakutei_su"]);
				paramCol["M1nyuryokutan_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1nyuryokutan_nm"]);
				paramCol["M1shukkariyu_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1shukkariyu_nm"]);
				paramCol["M1syorinm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1syorinm"]);
				paramCol["M1syoriymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1syoriymd"]);
				paramCol["M1syori_tm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1syori_tm"]);
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
			Te010f01Form formVO = (Te010f01Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Modeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Modeno"].RequestValue, formInfo["Modeno"]);
			paramCol["Stkmodeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Stkmodeno"].RequestValue, formInfo["Stkmodeno"]);
			paramCol["Denpyo_jyotai"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Denpyo_jyotai"].RequestValue, formInfo["Denpyo_jyotai"]);
			paramCol["Denpyo_bango_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Denpyo_bango_from"].RequestValue, formInfo["Denpyo_bango_from"]);
			paramCol["Denpyo_bango_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Denpyo_bango_to"].RequestValue, formInfo["Denpyo_bango_to"]);
			paramCol["Siji_bango_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Siji_bango_from"].RequestValue, formInfo["Siji_bango_from"]);
			paramCol["Siji_bango_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Siji_bango_to"].RequestValue, formInfo["Siji_bango_to"]);
			paramCol["Syukka_ymd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Syukka_ymd_from"].RequestValue, formInfo["Syukka_ymd_from"]);
			paramCol["Syukka_ymd_from"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Syukka_ymd_from"].RequestValue, formInfo["Syukka_ymd_from"]);
			paramCol["Syukka_ymd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Syukka_ymd_to"].RequestValue, formInfo["Syukka_ymd_to"]);
			paramCol["Syukka_ymd_to"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Syukka_ymd_to"].RequestValue, formInfo["Syukka_ymd_to"]);
			paramCol["Kaisya_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Kaisya_cd"].RequestValue, formInfo["Kaisya_cd"]);
			paramCol["Kaisya_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Kaisya_nm"].RequestValue, formInfo["Kaisya_nm"]);
			paramCol["Jyuryoten_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Jyuryoten_cd"].RequestValue, formInfo["Jyuryoten_cd"]);
			paramCol["Juryoten_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Juryoten_nm"].RequestValue, formInfo["Juryoten_nm"]);
			paramCol["Nyuryokutan_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Nyuryokutan_cd"].RequestValue, formInfo["Nyuryokutan_cd"]);
			paramCol["Nyuryokutan_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Nyuryokutan_nm"].RequestValue, formInfo["Nyuryokutan_nm"]);
			paramCol["Bumon_cd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_cd_from"].RequestValue, formInfo["Bumon_cd_from"]);
			paramCol["Bumon_nm_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_nm_from"].RequestValue, formInfo["Bumon_nm_from"]);
			paramCol["Bumon_cd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_cd_to"].RequestValue, formInfo["Bumon_cd_to"]);
			paramCol["Bumon_nm_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_nm_to"].RequestValue, formInfo["Bumon_nm_to"]);
			paramCol["Shukkariyu_kbn"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Shukkariyu_kbn"].RequestValue, formInfo["Shukkariyu_kbn"]);
			paramCol["Old_jisya_hbn"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Old_jisya_hbn"].RequestValue, formInfo["Old_jisya_hbn"]);
			paramCol["Maker_hbn"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Maker_hbn"].RequestValue, formInfo["Maker_hbn"]);
			paramCol["Scan_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Scan_cd"].RequestValue, formInfo["Scan_cd"]);
			paramCol["Offline_no"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Offline_no"].RequestValue, formInfo["Offline_no"]);
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
				paramCol["M1kaisyakana_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1kaisyakana_nm"][i].RequestValue, formInfo["M1kaisyakana_nm"]);
				paramCol["M1jyuryoten_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1jyuryoten_cd"][i].RequestValue, formInfo["M1jyuryoten_cd"]);
				paramCol["M1juryoten_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1juryoten_nm"][i].RequestValue, formInfo["M1juryoten_nm"]);
				paramCol["M1scm_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1scm_cd"][i].RequestValue, formInfo["M1scm_cd"]);
				paramCol["M1siji_bango"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1siji_bango"][i].RequestValue, formInfo["M1siji_bango"]);
				paramCol["M1syukka_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1syukka_ymd"][i].RequestValue, formInfo["M1syukka_ymd"]);
				paramCol["M1syukka_ymd"][i].DateFullValue = RequestParameterUtil.GetDateFullValue(
					paramCol["M1syukka_ymd"][i].RequestValue, formInfo["M1syukka_ymd"]);
				paramCol["M1jyuryo_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1jyuryo_ymd"][i].RequestValue, formInfo["M1jyuryo_ymd"]);
				paramCol["M1jyuryo_ymd"][i].DateFullValue = RequestParameterUtil.GetDateFullValue(
					paramCol["M1jyuryo_ymd"][i].RequestValue, formInfo["M1jyuryo_ymd"]);
				paramCol["M1syukka_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1syukka_su"][i].RequestValue, formInfo["M1syukka_su"]);
				paramCol["M1kakutei_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1kakutei_su"][i].RequestValue, formInfo["M1kakutei_su"]);
				paramCol["M1nyuryokutan_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1nyuryokutan_nm"][i].RequestValue, formInfo["M1nyuryokutan_nm"]);
				paramCol["M1shukkariyu_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1shukkariyu_nm"][i].RequestValue, formInfo["M1shukkariyu_nm"]);
				paramCol["M1syorinm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1syorinm"][i].RequestValue, formInfo["M1syorinm"]);
				paramCol["M1syoriymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1syoriymd"][i].RequestValue, formInfo["M1syoriymd"]);
				paramCol["M1syoriymd"][i].DateFullValue = RequestParameterUtil.GetDateFullValue(
					paramCol["M1syoriymd"][i].RequestValue, formInfo["M1syoriymd"]);
				paramCol["M1syori_tm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1syori_tm"][i].RequestValue, formInfo["M1syori_tm"]);
				paramCol["M1syori_tm"][i].DateFullValue = RequestParameterUtil.GetDateFullValue(
					paramCol["M1syori_tm"][i].RequestValue, formInfo["M1syori_tm"]);
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
			Te010f01Form formVO = (Te010f01Form)pageContext.GetFormVO();

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
			if (paramCol["Denpyo_jyotai"].UnformatValue != null)
			{
				formVO.Denpyo_jyotai = paramCol["Denpyo_jyotai"].UnformatValue;
			}
			if (paramCol["Denpyo_bango_from"].UnformatValue != null)
			{
				formVO.Denpyo_bango_from = paramCol["Denpyo_bango_from"].UnformatValue;
			}
			if (paramCol["Denpyo_bango_to"].UnformatValue != null)
			{
				formVO.Denpyo_bango_to = paramCol["Denpyo_bango_to"].UnformatValue;
			}
			if (paramCol["Siji_bango_from"].UnformatValue != null)
			{
				formVO.Siji_bango_from = paramCol["Siji_bango_from"].UnformatValue;
			}
			if (paramCol["Siji_bango_to"].UnformatValue != null)
			{
				formVO.Siji_bango_to = paramCol["Siji_bango_to"].UnformatValue;
			}
			if (paramCol["Syukka_ymd_from"].DateFullValue != null)
			{
				formVO.Syukka_ymd_from = paramCol["Syukka_ymd_from"].DateFullValue;
			}
			if (paramCol["Syukka_ymd_to"].DateFullValue != null)
			{
				formVO.Syukka_ymd_to = paramCol["Syukka_ymd_to"].DateFullValue;
			}
			if (paramCol["Kaisya_cd"].UnformatValue != null)
			{
				formVO.Kaisya_cd = paramCol["Kaisya_cd"].UnformatValue;
			}
			if (paramCol["Kaisya_nm"].UnformatValue != null)
			{
				formVO.Kaisya_nm = paramCol["Kaisya_nm"].UnformatValue;
			}
			if (paramCol["Jyuryoten_cd"].UnformatValue != null)
			{
				formVO.Jyuryoten_cd = paramCol["Jyuryoten_cd"].UnformatValue;
			}
			if (paramCol["Juryoten_nm"].UnformatValue != null)
			{
				formVO.Juryoten_nm = paramCol["Juryoten_nm"].UnformatValue;
			}
			if (paramCol["Nyuryokutan_cd"].UnformatValue != null)
			{
				formVO.Nyuryokutan_cd = paramCol["Nyuryokutan_cd"].UnformatValue;
			}
			if (paramCol["Nyuryokutan_nm"].UnformatValue != null)
			{
				formVO.Nyuryokutan_nm = paramCol["Nyuryokutan_nm"].UnformatValue;
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
			if (paramCol["Shukkariyu_kbn"].UnformatValue != null)
			{
				formVO.Shukkariyu_kbn = paramCol["Shukkariyu_kbn"].UnformatValue;
			}
			if (paramCol["Old_jisya_hbn"].UnformatValue != null)
			{
				formVO.Old_jisya_hbn = paramCol["Old_jisya_hbn"].UnformatValue;
			}
			if (paramCol["Maker_hbn"].UnformatValue != null)
			{
				formVO.Maker_hbn = paramCol["Maker_hbn"].UnformatValue;
			}
			if (paramCol["Scan_cd"].UnformatValue != null)
			{
				formVO.Scan_cd = paramCol["Scan_cd"].UnformatValue;
			}
			if (paramCol["Offline_no"].UnformatValue != null)
			{
				formVO.Offline_no = paramCol["Offline_no"].UnformatValue;
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
				Te010f01M1Form te010f01M1Form = (Te010f01M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					te010f01M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1kaisyakana_nm"][i].UnformatValue != null)
				{
					te010f01M1Form.M1kaisyakana_nm = paramCol["M1kaisyakana_nm"][i].UnformatValue;
				}
				if (paramCol["M1jyuryoten_cd"][i].UnformatValue != null)
				{
					te010f01M1Form.M1jyuryoten_cd = paramCol["M1jyuryoten_cd"][i].UnformatValue;
				}
				if (paramCol["M1juryoten_nm"][i].UnformatValue != null)
				{
					te010f01M1Form.M1juryoten_nm = paramCol["M1juryoten_nm"][i].UnformatValue;
				}
				if (paramCol["M1scm_cd"][i].UnformatValue != null)
				{
					te010f01M1Form.M1scm_cd = paramCol["M1scm_cd"][i].UnformatValue;
				}
				if (paramCol["M1siji_bango"][i].UnformatValue != null)
				{
					te010f01M1Form.M1siji_bango = paramCol["M1siji_bango"][i].UnformatValue;
				}
				if (paramCol["M1syukka_ymd"][i].DateFullValue != null)
				{
					te010f01M1Form.M1syukka_ymd = paramCol["M1syukka_ymd"][i].DateFullValue;
				}
				if (paramCol["M1jyuryo_ymd"][i].DateFullValue != null)
				{
					te010f01M1Form.M1jyuryo_ymd = paramCol["M1jyuryo_ymd"][i].DateFullValue;
				}
				if (paramCol["M1syukka_su"][i].UnformatValue != null)
				{
					te010f01M1Form.M1syukka_su = paramCol["M1syukka_su"][i].UnformatValue;
				}
				if (paramCol["M1kakutei_su"][i].UnformatValue != null)
				{
					te010f01M1Form.M1kakutei_su = paramCol["M1kakutei_su"][i].UnformatValue;
				}
				if (paramCol["M1nyuryokutan_nm"][i].UnformatValue != null)
				{
					te010f01M1Form.M1nyuryokutan_nm = paramCol["M1nyuryokutan_nm"][i].UnformatValue;
				}
				if (paramCol["M1shukkariyu_nm"][i].UnformatValue != null)
				{
					te010f01M1Form.M1shukkariyu_nm = paramCol["M1shukkariyu_nm"][i].UnformatValue;
				}
				if (paramCol["M1syorinm"][i].UnformatValue != null)
				{
					te010f01M1Form.M1syorinm = paramCol["M1syorinm"][i].UnformatValue;
				}
				if (paramCol["M1syoriymd"][i].DateFullValue != null)
				{
					te010f01M1Form.M1syoriymd = paramCol["M1syoriymd"][i].DateFullValue;
				}
				if (paramCol["M1syori_tm"][i].DateFullValue != null)
				{
					te010f01M1Form.M1syori_tm = paramCol["M1syori_tm"][i].DateFullValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					te010f01M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					te010f01M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					te010f01M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Te010f01Form formVO, StandardCheckManager checker)
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
			if (formVO.Denpyo_jyotai != null)
			{
				checker.DoCheck("Denpyo_jyotai", formVO.Denpyo_jyotai);
			}
			if (formVO.Denpyo_bango_from != null)
			{
				checker.DoCheck("Denpyo_bango_from", formVO.Denpyo_bango_from);
			}
			if (formVO.Denpyo_bango_to != null)
			{
				checker.DoCheck("Denpyo_bango_to", formVO.Denpyo_bango_to);
			}
			if (formVO.Siji_bango_from != null)
			{
				checker.DoCheck("Siji_bango_from", formVO.Siji_bango_from);
			}
			if (formVO.Siji_bango_to != null)
			{
				checker.DoCheck("Siji_bango_to", formVO.Siji_bango_to);
			}
			if (formVO.Syukka_ymd_from != null)
			{
				checker.DoCheck("Syukka_ymd_from", formVO.Syukka_ymd_from);
			}
			if (formVO.Syukka_ymd_to != null)
			{
				checker.DoCheck("Syukka_ymd_to", formVO.Syukka_ymd_to);
			}
			if (formVO.Kaisya_cd != null)
			{
				checker.DoCheck("Kaisya_cd", formVO.Kaisya_cd);
			}
			if (formVO.Kaisya_nm != null)
			{
				checker.DoCheck("Kaisya_nm", formVO.Kaisya_nm);
			}
			if (formVO.Jyuryoten_cd != null)
			{
				checker.DoCheck("Jyuryoten_cd", formVO.Jyuryoten_cd);
			}
			if (formVO.Juryoten_nm != null)
			{
				checker.DoCheck("Juryoten_nm", formVO.Juryoten_nm);
			}
			if (formVO.Nyuryokutan_cd != null)
			{
				checker.DoCheck("Nyuryokutan_cd", formVO.Nyuryokutan_cd);
			}
			if (formVO.Nyuryokutan_nm != null)
			{
				checker.DoCheck("Nyuryokutan_nm", formVO.Nyuryokutan_nm);
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
			if (formVO.Shukkariyu_kbn != null)
			{
				checker.DoCheck("Shukkariyu_kbn", formVO.Shukkariyu_kbn);
			}
			if (formVO.Old_jisya_hbn != null)
			{
				checker.DoCheck("Old_jisya_hbn", formVO.Old_jisya_hbn);
			}
			if (formVO.Maker_hbn != null)
			{
				checker.DoCheck("Maker_hbn", formVO.Maker_hbn);
			}
			if (formVO.Scan_cd != null)
			{
				checker.DoCheck("Scan_cd", formVO.Scan_cd);
			}
			if (formVO.Offline_no != null)
			{
				checker.DoCheck("Offline_no", formVO.Offline_no);
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
		public static void ValidateM1InputValue(Te010f01Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Te010f01M1Form te010f01M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, te010f01M1Form, i, m1List);
				if (te010f01M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", te010f01M1Form.M1rowno, i, m1List);
				}
				if (te010f01M1Form.M1kaisyakana_nm != null)
				{
					checker.DoCheck("M1kaisyakana_nm", te010f01M1Form.M1kaisyakana_nm, i, m1List);
				}
				if (te010f01M1Form.M1jyuryoten_cd != null)
				{
					checker.DoCheck("M1jyuryoten_cd", te010f01M1Form.M1jyuryoten_cd, i, m1List);
				}
				if (te010f01M1Form.M1juryoten_nm != null)
				{
					checker.DoCheck("M1juryoten_nm", te010f01M1Form.M1juryoten_nm, i, m1List);
				}
				if (te010f01M1Form.M1scm_cd != null)
				{
					checker.DoCheck("M1scm_cd", te010f01M1Form.M1scm_cd, i, m1List);
				}
				if (te010f01M1Form.M1siji_bango != null)
				{
					checker.DoCheck("M1siji_bango", te010f01M1Form.M1siji_bango, i, m1List);
				}
				if (te010f01M1Form.M1syukka_ymd != null)
				{
					checker.DoCheck("M1syukka_ymd", te010f01M1Form.M1syukka_ymd, i, m1List);
				}
				if (te010f01M1Form.M1jyuryo_ymd != null)
				{
					checker.DoCheck("M1jyuryo_ymd", te010f01M1Form.M1jyuryo_ymd, i, m1List);
				}
				if (te010f01M1Form.M1syukka_su != null)
				{
					checker.DoCheck("M1syukka_su", te010f01M1Form.M1syukka_su, i, m1List);
				}
				if (te010f01M1Form.M1kakutei_su != null)
				{
					checker.DoCheck("M1kakutei_su", te010f01M1Form.M1kakutei_su, i, m1List);
				}
				if (te010f01M1Form.M1nyuryokutan_nm != null)
				{
					checker.DoCheck("M1nyuryokutan_nm", te010f01M1Form.M1nyuryokutan_nm, i, m1List);
				}
				if (te010f01M1Form.M1shukkariyu_nm != null)
				{
					checker.DoCheck("M1shukkariyu_nm", te010f01M1Form.M1shukkariyu_nm, i, m1List);
				}
				if (te010f01M1Form.M1syorinm != null)
				{
					checker.DoCheck("M1syorinm", te010f01M1Form.M1syorinm, i, m1List);
				}
				if (te010f01M1Form.M1syoriymd != null)
				{
					checker.DoCheck("M1syoriymd", te010f01M1Form.M1syoriymd, i, m1List);
				}
				if (te010f01M1Form.M1syori_tm != null)
				{
					checker.DoCheck("M1syori_tm", te010f01M1Form.M1syori_tm, i, m1List);
				}
				if (te010f01M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", te010f01M1Form.M1selectorcheckbox, i, m1List);
				}
				if (te010f01M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", te010f01M1Form.M1entersyoriflg, i, m1List);
				}
				if (te010f01M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", te010f01M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Te010f01Form formVO, StandardCodeCheckManager checker)
		{
			checker.DoCheck("Btnheadtenpocd", formVO);
			checker.DoCheck("Btnkaisha_cd", formVO);
			checker.DoCheck("Btntenpocd", formVO);
			checker.DoCheck("Btnnyuryokutanto_cd", formVO);
			checker.DoCheck("Btnbumon_cd_from", formVO);
			checker.DoCheck("Btnbumon_cd_to", formVO);
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Te010f01Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

