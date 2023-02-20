using com.xebio.bo.Tb030p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Tb030p01.Request
{
  /// <summary>
  /// Tb030f01RequestHelper の概要の説明です。
  /// </summary>
  public static class Tb030f01RequestHelper
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
			Tb030f01Form formVO = (Tb030f01Form)pageContext.GetFormVO();

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
			paramCol["Nyukayotei_ymd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Nyukayotei_ymd_from"]);
			paramCol["Nyukayotei_ymd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Nyukayotei_ymd_to"]);
			paramCol["Siire_kakutei_ymd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Siire_kakutei_ymd_from"]);
			paramCol["Siire_kakutei_ymd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Siire_kakutei_ymd_to"]);
			paramCol["Denpyo_bango_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Denpyo_bango_from"]);
			paramCol["Denpyo_bango_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Denpyo_bango_to"]);
			paramCol["Siiresaki_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Siiresaki_cd"]);
			paramCol["Siiresaki_ryaku_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Siiresaki_ryaku_nm"]);
			paramCol["Bumon_cd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_cd_from"]);
			paramCol["Bumon_nm_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_nm_from"]);
			paramCol["Bumon_cd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_cd_to"]);
			paramCol["Bumon_nm_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_nm_to"]);
			paramCol["Old_jisya_hbn"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Old_jisya_hbn"]);
			paramCol["Maker_hbn"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Maker_hbn"]);
			paramCol["Scan_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Scan_cd"]);
			paramCol["Kakutei_jyotai"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Kakutei_jyotai"]);
			paramCol["Scm_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Scm_cd"]);
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
				paramCol["M1siiresaki_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1siiresaki_cd"]);
				paramCol["M1siiresaki_ryaku_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1siiresaki_ryaku_nm"]);
				paramCol["M1nyukayotei_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1nyukayotei_ymd"]);
				paramCol["M1itemsu"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1itemsu"]);
				paramCol["M1genka_kin"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1genka_kin"]);
				paramCol["M1siire_kakutei_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1siire_kakutei_ymd"]);
				paramCol["M1kakuteitan_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1kakuteitan_nm"]);
				paramCol["M1denpyo_jyotainm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1denpyo_jyotainm"]);
				paramCol["M1kyakucyu"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1kyakucyu"]);
				paramCol["M1negaki"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1negaki"]);
				paramCol["M1nyuka_kakutei_check"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1nyuka_kakutei_check"]);
				paramCol["M1check_tannm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1check_tannm"]);
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
			Tb030f01Form formVO = (Tb030f01Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Modeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Modeno"].RequestValue, formInfo["Modeno"]);
			paramCol["Stkmodeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Stkmodeno"].RequestValue, formInfo["Stkmodeno"]);
			paramCol["Nyukayotei_ymd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Nyukayotei_ymd_from"].RequestValue, formInfo["Nyukayotei_ymd_from"]);
			paramCol["Nyukayotei_ymd_from"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Nyukayotei_ymd_from"].RequestValue, formInfo["Nyukayotei_ymd_from"]);
			paramCol["Nyukayotei_ymd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Nyukayotei_ymd_to"].RequestValue, formInfo["Nyukayotei_ymd_to"]);
			paramCol["Nyukayotei_ymd_to"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Nyukayotei_ymd_to"].RequestValue, formInfo["Nyukayotei_ymd_to"]);
			paramCol["Siire_kakutei_ymd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Siire_kakutei_ymd_from"].RequestValue, formInfo["Siire_kakutei_ymd_from"]);
			paramCol["Siire_kakutei_ymd_from"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Siire_kakutei_ymd_from"].RequestValue, formInfo["Siire_kakutei_ymd_from"]);
			paramCol["Siire_kakutei_ymd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Siire_kakutei_ymd_to"].RequestValue, formInfo["Siire_kakutei_ymd_to"]);
			paramCol["Siire_kakutei_ymd_to"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Siire_kakutei_ymd_to"].RequestValue, formInfo["Siire_kakutei_ymd_to"]);
			paramCol["Denpyo_bango_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Denpyo_bango_from"].RequestValue, formInfo["Denpyo_bango_from"]);
			paramCol["Denpyo_bango_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Denpyo_bango_to"].RequestValue, formInfo["Denpyo_bango_to"]);
			paramCol["Siiresaki_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Siiresaki_cd"].RequestValue, formInfo["Siiresaki_cd"]);
			paramCol["Siiresaki_ryaku_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Siiresaki_ryaku_nm"].RequestValue, formInfo["Siiresaki_ryaku_nm"]);
			paramCol["Bumon_cd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_cd_from"].RequestValue, formInfo["Bumon_cd_from"]);
			paramCol["Bumon_nm_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_nm_from"].RequestValue, formInfo["Bumon_nm_from"]);
			paramCol["Bumon_cd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_cd_to"].RequestValue, formInfo["Bumon_cd_to"]);
			paramCol["Bumon_nm_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_nm_to"].RequestValue, formInfo["Bumon_nm_to"]);
			paramCol["Old_jisya_hbn"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Old_jisya_hbn"].RequestValue, formInfo["Old_jisya_hbn"]);
			paramCol["Maker_hbn"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Maker_hbn"].RequestValue, formInfo["Maker_hbn"]);
			paramCol["Scan_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Scan_cd"].RequestValue, formInfo["Scan_cd"]);
			paramCol["Kakutei_jyotai"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Kakutei_jyotai"].RequestValue, formInfo["Kakutei_jyotai"]);
			paramCol["Scm_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Scm_cd"].RequestValue, formInfo["Scm_cd"]);
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
				paramCol["M1siiresaki_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1siiresaki_cd"][i].RequestValue, formInfo["M1siiresaki_cd"]);
				paramCol["M1siiresaki_ryaku_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1siiresaki_ryaku_nm"][i].RequestValue, formInfo["M1siiresaki_ryaku_nm"]);
				paramCol["M1nyukayotei_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1nyukayotei_ymd"][i].RequestValue, formInfo["M1nyukayotei_ymd"]);
				paramCol["M1nyukayotei_ymd"][i].DateFullValue = RequestParameterUtil.GetDateFullValue(
					paramCol["M1nyukayotei_ymd"][i].RequestValue, formInfo["M1nyukayotei_ymd"]);
				paramCol["M1itemsu"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1itemsu"][i].RequestValue, formInfo["M1itemsu"]);
				paramCol["M1genka_kin"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1genka_kin"][i].RequestValue, formInfo["M1genka_kin"]);
				paramCol["M1siire_kakutei_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1siire_kakutei_ymd"][i].RequestValue, formInfo["M1siire_kakutei_ymd"]);
				paramCol["M1siire_kakutei_ymd"][i].DateFullValue = RequestParameterUtil.GetDateFullValue(
					paramCol["M1siire_kakutei_ymd"][i].RequestValue, formInfo["M1siire_kakutei_ymd"]);
				paramCol["M1kakuteitan_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1kakuteitan_nm"][i].RequestValue, formInfo["M1kakuteitan_nm"]);
				paramCol["M1denpyo_jyotainm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1denpyo_jyotainm"][i].RequestValue, formInfo["M1denpyo_jyotainm"]);
				paramCol["M1kyakucyu"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1kyakucyu"][i].RequestValue, formInfo["M1kyakucyu"]);
				paramCol["M1negaki"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1negaki"][i].RequestValue, formInfo["M1negaki"]);
				paramCol["M1nyuka_kakutei_check"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1nyuka_kakutei_check"][i].RequestValue, formInfo["M1nyuka_kakutei_check"]);
				paramCol["M1check_tannm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1check_tannm"][i].RequestValue, formInfo["M1check_tannm"]);
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
			Tb030f01Form formVO = (Tb030f01Form)pageContext.GetFormVO();

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
			if (paramCol["Nyukayotei_ymd_from"].DateFullValue != null)
			{
				formVO.Nyukayotei_ymd_from = paramCol["Nyukayotei_ymd_from"].DateFullValue;
			}
			if (paramCol["Nyukayotei_ymd_to"].DateFullValue != null)
			{
				formVO.Nyukayotei_ymd_to = paramCol["Nyukayotei_ymd_to"].DateFullValue;
			}
			if (paramCol["Siire_kakutei_ymd_from"].DateFullValue != null)
			{
				formVO.Siire_kakutei_ymd_from = paramCol["Siire_kakutei_ymd_from"].DateFullValue;
			}
			if (paramCol["Siire_kakutei_ymd_to"].DateFullValue != null)
			{
				formVO.Siire_kakutei_ymd_to = paramCol["Siire_kakutei_ymd_to"].DateFullValue;
			}
			if (paramCol["Denpyo_bango_from"].UnformatValue != null)
			{
				formVO.Denpyo_bango_from = paramCol["Denpyo_bango_from"].UnformatValue;
			}
			if (paramCol["Denpyo_bango_to"].UnformatValue != null)
			{
				formVO.Denpyo_bango_to = paramCol["Denpyo_bango_to"].UnformatValue;
			}
			if (paramCol["Siiresaki_cd"].UnformatValue != null)
			{
				formVO.Siiresaki_cd = paramCol["Siiresaki_cd"].UnformatValue;
			}
			if (paramCol["Siiresaki_ryaku_nm"].UnformatValue != null)
			{
				formVO.Siiresaki_ryaku_nm = paramCol["Siiresaki_ryaku_nm"].UnformatValue;
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
			if (paramCol["Kakutei_jyotai"].UnformatValue != null)
			{
				formVO.Kakutei_jyotai = paramCol["Kakutei_jyotai"].UnformatValue;
			}
			if (paramCol["Scm_cd"].UnformatValue != null)
			{
				formVO.Scm_cd = paramCol["Scm_cd"].UnformatValue;
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
				Tb030f01M1Form tb030f01M1Form = (Tb030f01M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					tb030f01M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1bumon_cd"][i].UnformatValue != null)
				{
					tb030f01M1Form.M1bumon_cd = paramCol["M1bumon_cd"][i].UnformatValue;
				}
				if (paramCol["M1bumonkana_nm"][i].UnformatValue != null)
				{
					tb030f01M1Form.M1bumonkana_nm = paramCol["M1bumonkana_nm"][i].UnformatValue;
				}
				if (paramCol["M1siiresaki_cd"][i].UnformatValue != null)
				{
					tb030f01M1Form.M1siiresaki_cd = paramCol["M1siiresaki_cd"][i].UnformatValue;
				}
				if (paramCol["M1siiresaki_ryaku_nm"][i].UnformatValue != null)
				{
					tb030f01M1Form.M1siiresaki_ryaku_nm = paramCol["M1siiresaki_ryaku_nm"][i].UnformatValue;
				}
				if (paramCol["M1nyukayotei_ymd"][i].DateFullValue != null)
				{
					tb030f01M1Form.M1nyukayotei_ymd = paramCol["M1nyukayotei_ymd"][i].DateFullValue;
				}
				if (paramCol["M1itemsu"][i].UnformatValue != null)
				{
					tb030f01M1Form.M1itemsu = paramCol["M1itemsu"][i].UnformatValue;
				}
				if (paramCol["M1genka_kin"][i].UnformatValue != null)
				{
					tb030f01M1Form.M1genka_kin = paramCol["M1genka_kin"][i].UnformatValue;
				}
				if (paramCol["M1siire_kakutei_ymd"][i].DateFullValue != null)
				{
					tb030f01M1Form.M1siire_kakutei_ymd = paramCol["M1siire_kakutei_ymd"][i].DateFullValue;
				}
				if (paramCol["M1kakuteitan_nm"][i].UnformatValue != null)
				{
					tb030f01M1Form.M1kakuteitan_nm = paramCol["M1kakuteitan_nm"][i].UnformatValue;
				}
				if (paramCol["M1denpyo_jyotainm"][i].UnformatValue != null)
				{
					tb030f01M1Form.M1denpyo_jyotainm = paramCol["M1denpyo_jyotainm"][i].UnformatValue;
				}
				if (paramCol["M1kyakucyu"][i].UnformatValue != null)
				{
					tb030f01M1Form.M1kyakucyu = paramCol["M1kyakucyu"][i].UnformatValue;
				}
				if (paramCol["M1negaki"][i].UnformatValue != null)
				{
					tb030f01M1Form.M1negaki = paramCol["M1negaki"][i].UnformatValue;
				}
				if (paramCol["M1nyuka_kakutei_check"][i].UnformatValue != null)
				{
					tb030f01M1Form.M1nyuka_kakutei_check = paramCol["M1nyuka_kakutei_check"][i].UnformatValue;
				}
				if (paramCol["M1check_tannm"][i].UnformatValue != null)
				{
					tb030f01M1Form.M1check_tannm = paramCol["M1check_tannm"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					tb030f01M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					tb030f01M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					tb030f01M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Tb030f01Form formVO, StandardCheckManager checker)
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
			if (formVO.Nyukayotei_ymd_from != null)
			{
				checker.DoCheck("Nyukayotei_ymd_from", formVO.Nyukayotei_ymd_from);
			}
			if (formVO.Nyukayotei_ymd_to != null)
			{
				checker.DoCheck("Nyukayotei_ymd_to", formVO.Nyukayotei_ymd_to);
			}
			if (formVO.Siire_kakutei_ymd_from != null)
			{
				checker.DoCheck("Siire_kakutei_ymd_from", formVO.Siire_kakutei_ymd_from);
			}
			if (formVO.Siire_kakutei_ymd_to != null)
			{
				checker.DoCheck("Siire_kakutei_ymd_to", formVO.Siire_kakutei_ymd_to);
			}
			if (formVO.Denpyo_bango_from != null)
			{
				checker.DoCheck("Denpyo_bango_from", formVO.Denpyo_bango_from);
			}
			if (formVO.Denpyo_bango_to != null)
			{
				checker.DoCheck("Denpyo_bango_to", formVO.Denpyo_bango_to);
			}
			if (formVO.Siiresaki_cd != null)
			{
				checker.DoCheck("Siiresaki_cd", formVO.Siiresaki_cd);
			}
			if (formVO.Siiresaki_ryaku_nm != null)
			{
				checker.DoCheck("Siiresaki_ryaku_nm", formVO.Siiresaki_ryaku_nm);
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
			if (formVO.Kakutei_jyotai != null)
			{
				checker.DoCheck("Kakutei_jyotai", formVO.Kakutei_jyotai);
			}
			if (formVO.Scm_cd != null)
			{
				checker.DoCheck("Scm_cd", formVO.Scm_cd);
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
		public static void ValidateM1InputValue(Tb030f01Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Tb030f01M1Form tb030f01M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, tb030f01M1Form, i, m1List);
				if (tb030f01M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", tb030f01M1Form.M1rowno, i, m1List);
				}
				if (tb030f01M1Form.M1bumon_cd != null)
				{
					checker.DoCheck("M1bumon_cd", tb030f01M1Form.M1bumon_cd, i, m1List);
				}
				if (tb030f01M1Form.M1bumonkana_nm != null)
				{
					checker.DoCheck("M1bumonkana_nm", tb030f01M1Form.M1bumonkana_nm, i, m1List);
				}
				if (tb030f01M1Form.M1siiresaki_cd != null)
				{
					checker.DoCheck("M1siiresaki_cd", tb030f01M1Form.M1siiresaki_cd, i, m1List);
				}
				if (tb030f01M1Form.M1siiresaki_ryaku_nm != null)
				{
					checker.DoCheck("M1siiresaki_ryaku_nm", tb030f01M1Form.M1siiresaki_ryaku_nm, i, m1List);
				}
				if (tb030f01M1Form.M1nyukayotei_ymd != null)
				{
					checker.DoCheck("M1nyukayotei_ymd", tb030f01M1Form.M1nyukayotei_ymd, i, m1List);
				}
				if (tb030f01M1Form.M1itemsu != null)
				{
					checker.DoCheck("M1itemsu", tb030f01M1Form.M1itemsu, i, m1List);
				}
				if (tb030f01M1Form.M1genka_kin != null)
				{
					checker.DoCheck("M1genka_kin", tb030f01M1Form.M1genka_kin, i, m1List);
				}
				if (tb030f01M1Form.M1siire_kakutei_ymd != null)
				{
					checker.DoCheck("M1siire_kakutei_ymd", tb030f01M1Form.M1siire_kakutei_ymd, i, m1List);
				}
				if (tb030f01M1Form.M1kakuteitan_nm != null)
				{
					checker.DoCheck("M1kakuteitan_nm", tb030f01M1Form.M1kakuteitan_nm, i, m1List);
				}
				if (tb030f01M1Form.M1denpyo_jyotainm != null)
				{
					checker.DoCheck("M1denpyo_jyotainm", tb030f01M1Form.M1denpyo_jyotainm, i, m1List);
				}
				if (tb030f01M1Form.M1kyakucyu != null)
				{
					checker.DoCheck("M1kyakucyu", tb030f01M1Form.M1kyakucyu, i, m1List);
				}
				if (tb030f01M1Form.M1negaki != null)
				{
					checker.DoCheck("M1negaki", tb030f01M1Form.M1negaki, i, m1List);
				}
				if (tb030f01M1Form.M1nyuka_kakutei_check != null)
				{
					checker.DoCheck("M1nyuka_kakutei_check", tb030f01M1Form.M1nyuka_kakutei_check, i, m1List);
				}
				if (tb030f01M1Form.M1check_tannm != null)
				{
					checker.DoCheck("M1check_tannm", tb030f01M1Form.M1check_tannm, i, m1List);
				}
				if (tb030f01M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", tb030f01M1Form.M1selectorcheckbox, i, m1List);
				}
				if (tb030f01M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", tb030f01M1Form.M1entersyoriflg, i, m1List);
				}
				if (tb030f01M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", tb030f01M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Tb030f01Form formVO, StandardCodeCheckManager checker)
		{
			checker.DoCheck("Btnheadtenpocd", formVO);
			checker.DoCheck("Btnsiiresaki_cd", formVO);
			checker.DoCheck("Btnbumon_cd_from", formVO);
			checker.DoCheck("Btnbumon_cd_to", formVO);
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Tb030f01Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

