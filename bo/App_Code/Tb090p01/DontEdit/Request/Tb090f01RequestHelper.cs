using com.xebio.bo.Tb090p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Tb090p01.Request
{
  /// <summary>
  /// Tb090f01RequestHelper の概要の説明です。
  /// </summary>
  public static class Tb090f01RequestHelper
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
			Tb090f01Form formVO = (Tb090f01Form)pageContext.GetFormVO();

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
			paramCol["Motodenpyo_bango_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Motodenpyo_bango_from"]);
			paramCol["Motodenpyo_bango_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Motodenpyo_bango_to"]);
			paramCol["Nyukayotei_ymd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Nyukayotei_ymd_from"]);
			paramCol["Nyukayotei_ymd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Nyukayotei_ymd_to"]);
			paramCol["Siire_kakutei_ymd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Siire_kakutei_ymd_from"]);
			paramCol["Siire_kakutei_ymd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Siire_kakutei_ymd_to"]);
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
			paramCol["Kakutei_sb"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Kakutei_sb"]);
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
				paramCol["M1bumon_cd_bo"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1bumon_cd_bo"]);
				paramCol["M1bumonkana_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1bumonkana_nm"]);
				paramCol["M1siiresaki_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1siiresaki_cd"]);
				paramCol["M1siiresaki_ryaku_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1siiresaki_ryaku_nm"]);
				paramCol["M1nyukayotei_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1nyukayotei_ymd"]);
				paramCol["M1aka_denpyo_bango"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1aka_denpyo_bango"]);
				paramCol["M1kuro_denpyo_bango"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1kuro_denpyo_bango"]);
				paramCol["M1kensu"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1kensu"]);
				paramCol["M1teisei_suryo"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1teisei_suryo"]);
				paramCol["M1genkakin"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1genkakin"]);
				paramCol["M1siire_kakutei_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1siire_kakutei_ymd"]);
				paramCol["M1kakuteitan_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1kakuteitan_nm"]);
				paramCol["M1kakutei_sb_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1kakutei_sb_nm"]);
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
			Tb090f01Form formVO = (Tb090f01Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Modeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Modeno"].RequestValue, formInfo["Modeno"]);
			paramCol["Stkmodeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Stkmodeno"].RequestValue, formInfo["Stkmodeno"]);
			paramCol["Motodenpyo_bango_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Motodenpyo_bango_from"].RequestValue, formInfo["Motodenpyo_bango_from"]);
			paramCol["Motodenpyo_bango_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Motodenpyo_bango_to"].RequestValue, formInfo["Motodenpyo_bango_to"]);
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
			paramCol["Kakutei_sb"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Kakutei_sb"].RequestValue, formInfo["Kakutei_sb"]);
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
				paramCol["M1bumon_cd_bo"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1bumon_cd_bo"][i].RequestValue, formInfo["M1bumon_cd_bo"]);
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
				paramCol["M1aka_denpyo_bango"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1aka_denpyo_bango"][i].RequestValue, formInfo["M1aka_denpyo_bango"]);
				paramCol["M1kuro_denpyo_bango"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1kuro_denpyo_bango"][i].RequestValue, formInfo["M1kuro_denpyo_bango"]);
				paramCol["M1kensu"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1kensu"][i].RequestValue, formInfo["M1kensu"]);
				paramCol["M1teisei_suryo"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1teisei_suryo"][i].RequestValue, formInfo["M1teisei_suryo"]);
				paramCol["M1genkakin"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1genkakin"][i].RequestValue, formInfo["M1genkakin"]);
				paramCol["M1siire_kakutei_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1siire_kakutei_ymd"][i].RequestValue, formInfo["M1siire_kakutei_ymd"]);
				paramCol["M1siire_kakutei_ymd"][i].DateFullValue = RequestParameterUtil.GetDateFullValue(
					paramCol["M1siire_kakutei_ymd"][i].RequestValue, formInfo["M1siire_kakutei_ymd"]);
				paramCol["M1kakuteitan_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1kakuteitan_nm"][i].RequestValue, formInfo["M1kakuteitan_nm"]);
				paramCol["M1kakutei_sb_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1kakutei_sb_nm"][i].RequestValue, formInfo["M1kakutei_sb_nm"]);
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
			Tb090f01Form formVO = (Tb090f01Form)pageContext.GetFormVO();

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
			if (paramCol["Motodenpyo_bango_from"].UnformatValue != null)
			{
				formVO.Motodenpyo_bango_from = paramCol["Motodenpyo_bango_from"].UnformatValue;
			}
			if (paramCol["Motodenpyo_bango_to"].UnformatValue != null)
			{
				formVO.Motodenpyo_bango_to = paramCol["Motodenpyo_bango_to"].UnformatValue;
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
			if (paramCol["Kakutei_sb"].UnformatValue != null)
			{
				formVO.Kakutei_sb = paramCol["Kakutei_sb"].UnformatValue;
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
				Tb090f01M1Form tb090f01M1Form = (Tb090f01M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					tb090f01M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1bumon_cd_bo"][i].UnformatValue != null)
				{
					tb090f01M1Form.M1bumon_cd_bo = paramCol["M1bumon_cd_bo"][i].UnformatValue;
				}
				if (paramCol["M1bumonkana_nm"][i].UnformatValue != null)
				{
					tb090f01M1Form.M1bumonkana_nm = paramCol["M1bumonkana_nm"][i].UnformatValue;
				}
				if (paramCol["M1siiresaki_cd"][i].UnformatValue != null)
				{
					tb090f01M1Form.M1siiresaki_cd = paramCol["M1siiresaki_cd"][i].UnformatValue;
				}
				if (paramCol["M1siiresaki_ryaku_nm"][i].UnformatValue != null)
				{
					tb090f01M1Form.M1siiresaki_ryaku_nm = paramCol["M1siiresaki_ryaku_nm"][i].UnformatValue;
				}
				if (paramCol["M1nyukayotei_ymd"][i].DateFullValue != null)
				{
					tb090f01M1Form.M1nyukayotei_ymd = paramCol["M1nyukayotei_ymd"][i].DateFullValue;
				}
				if (paramCol["M1aka_denpyo_bango"][i].UnformatValue != null)
				{
					tb090f01M1Form.M1aka_denpyo_bango = paramCol["M1aka_denpyo_bango"][i].UnformatValue;
				}
				if (paramCol["M1kuro_denpyo_bango"][i].UnformatValue != null)
				{
					tb090f01M1Form.M1kuro_denpyo_bango = paramCol["M1kuro_denpyo_bango"][i].UnformatValue;
				}
				if (paramCol["M1kensu"][i].UnformatValue != null)
				{
					tb090f01M1Form.M1kensu = paramCol["M1kensu"][i].UnformatValue;
				}
				if (paramCol["M1teisei_suryo"][i].UnformatValue != null)
				{
					tb090f01M1Form.M1teisei_suryo = paramCol["M1teisei_suryo"][i].UnformatValue;
				}
				if (paramCol["M1genkakin"][i].UnformatValue != null)
				{
					tb090f01M1Form.M1genkakin = paramCol["M1genkakin"][i].UnformatValue;
				}
				if (paramCol["M1siire_kakutei_ymd"][i].DateFullValue != null)
				{
					tb090f01M1Form.M1siire_kakutei_ymd = paramCol["M1siire_kakutei_ymd"][i].DateFullValue;
				}
				if (paramCol["M1kakuteitan_nm"][i].UnformatValue != null)
				{
					tb090f01M1Form.M1kakuteitan_nm = paramCol["M1kakuteitan_nm"][i].UnformatValue;
				}
				if (paramCol["M1kakutei_sb_nm"][i].UnformatValue != null)
				{
					tb090f01M1Form.M1kakutei_sb_nm = paramCol["M1kakutei_sb_nm"][i].UnformatValue;
				}
				if (paramCol["M1kyakucyu"][i].UnformatValue != null)
				{
					tb090f01M1Form.M1kyakucyu = paramCol["M1kyakucyu"][i].UnformatValue;
				}
				if (paramCol["M1negaki"][i].UnformatValue != null)
				{
					tb090f01M1Form.M1negaki = paramCol["M1negaki"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					tb090f01M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					tb090f01M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					tb090f01M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Tb090f01Form formVO, StandardCheckManager checker)
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
			if (formVO.Motodenpyo_bango_from != null)
			{
				checker.DoCheck("Motodenpyo_bango_from", formVO.Motodenpyo_bango_from);
			}
			if (formVO.Motodenpyo_bango_to != null)
			{
				checker.DoCheck("Motodenpyo_bango_to", formVO.Motodenpyo_bango_to);
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
			if (formVO.Kakutei_sb != null)
			{
				checker.DoCheck("Kakutei_sb", formVO.Kakutei_sb);
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
		public static void ValidateM1InputValue(Tb090f01Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Tb090f01M1Form tb090f01M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, tb090f01M1Form, i, m1List);
				if (tb090f01M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", tb090f01M1Form.M1rowno, i, m1List);
				}
				if (tb090f01M1Form.M1bumon_cd_bo != null)
				{
					checker.DoCheck("M1bumon_cd_bo", tb090f01M1Form.M1bumon_cd_bo, i, m1List);
				}
				if (tb090f01M1Form.M1bumonkana_nm != null)
				{
					checker.DoCheck("M1bumonkana_nm", tb090f01M1Form.M1bumonkana_nm, i, m1List);
				}
				if (tb090f01M1Form.M1siiresaki_cd != null)
				{
					checker.DoCheck("M1siiresaki_cd", tb090f01M1Form.M1siiresaki_cd, i, m1List);
				}
				if (tb090f01M1Form.M1siiresaki_ryaku_nm != null)
				{
					checker.DoCheck("M1siiresaki_ryaku_nm", tb090f01M1Form.M1siiresaki_ryaku_nm, i, m1List);
				}
				if (tb090f01M1Form.M1nyukayotei_ymd != null)
				{
					checker.DoCheck("M1nyukayotei_ymd", tb090f01M1Form.M1nyukayotei_ymd, i, m1List);
				}
				if (tb090f01M1Form.M1aka_denpyo_bango != null)
				{
					checker.DoCheck("M1aka_denpyo_bango", tb090f01M1Form.M1aka_denpyo_bango, i, m1List);
				}
				if (tb090f01M1Form.M1kuro_denpyo_bango != null)
				{
					checker.DoCheck("M1kuro_denpyo_bango", tb090f01M1Form.M1kuro_denpyo_bango, i, m1List);
				}
				if (tb090f01M1Form.M1kensu != null)
				{
					checker.DoCheck("M1kensu", tb090f01M1Form.M1kensu, i, m1List);
				}
				if (tb090f01M1Form.M1teisei_suryo != null)
				{
					checker.DoCheck("M1teisei_suryo", tb090f01M1Form.M1teisei_suryo, i, m1List);
				}
				if (tb090f01M1Form.M1genkakin != null)
				{
					checker.DoCheck("M1genkakin", tb090f01M1Form.M1genkakin, i, m1List);
				}
				if (tb090f01M1Form.M1siire_kakutei_ymd != null)
				{
					checker.DoCheck("M1siire_kakutei_ymd", tb090f01M1Form.M1siire_kakutei_ymd, i, m1List);
				}
				if (tb090f01M1Form.M1kakuteitan_nm != null)
				{
					checker.DoCheck("M1kakuteitan_nm", tb090f01M1Form.M1kakuteitan_nm, i, m1List);
				}
				if (tb090f01M1Form.M1kakutei_sb_nm != null)
				{
					checker.DoCheck("M1kakutei_sb_nm", tb090f01M1Form.M1kakutei_sb_nm, i, m1List);
				}
				if (tb090f01M1Form.M1kyakucyu != null)
				{
					checker.DoCheck("M1kyakucyu", tb090f01M1Form.M1kyakucyu, i, m1List);
				}
				if (tb090f01M1Form.M1negaki != null)
				{
					checker.DoCheck("M1negaki", tb090f01M1Form.M1negaki, i, m1List);
				}
				if (tb090f01M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", tb090f01M1Form.M1selectorcheckbox, i, m1List);
				}
				if (tb090f01M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", tb090f01M1Form.M1entersyoriflg, i, m1List);
				}
				if (tb090f01M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", tb090f01M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Tb090f01Form formVO, StandardCodeCheckManager checker)
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
		public static void ValidateM1CodeValue(Tb090f01Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

