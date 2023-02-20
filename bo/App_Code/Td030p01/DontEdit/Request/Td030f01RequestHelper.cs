using com.xebio.bo.Td030p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Td030p01.Request
{
  /// <summary>
  /// Td030f01RequestHelper の概要の説明です。
  /// </summary>
  public static class Td030f01RequestHelper
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
			Td030f01Form formVO = (Td030f01Form)pageContext.GetFormVO();

			//カード部を初期化する
			paramCol.InitCardItems(formInfo.GetCardItems());
			//明細「M1」部を初期化する
			paramCol.InitListItems(formInfo.GetListItems("M1"), formVO.GetList("M1").CurrentCount);
			//カード項目の入力値を取得する
			paramCol["Head_tenpo_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_nm"]);
			paramCol["Denpyo_jyotai"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Denpyo_jyotai"]);
			paramCol["Denpyo_bango_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Denpyo_bango_from"]);
			paramCol["Denpyo_bango_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Denpyo_bango_to"]);
			paramCol["Motodenpyo_bango_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Motodenpyo_bango_from"]);
			paramCol["Motodenpyo_bango_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Motodenpyo_bango_to"]);
			paramCol["Siji_bango_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Siji_bango_from"]);
			paramCol["Siji_bango_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Siji_bango_to"]);
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
			paramCol["Henpin_kakutei_ymd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Henpin_kakutei_ymd_from"]);
			paramCol["Henpin_kakutei_ymd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Henpin_kakutei_ymd_to"]);
			paramCol["Add_ymd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Add_ymd_from"]);
			paramCol["Add_ymd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Add_ymd_to"]);
			paramCol["Nyuryokutan_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Nyuryokutan_cd"]);
			paramCol["Nyuryokutan_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Nyuryokutan_nm"]);
			paramCol["Kakuteitan_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Kakuteitan_cd"]);
			paramCol["Kakuteitan_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Kakuteitan_nm"]);
			paramCol["Henpin_riyu"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Henpin_riyu"]);
			paramCol["Old_jisya_hbn"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Old_jisya_hbn"]);
			paramCol["Maker_hbn"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Maker_hbn"]);
			paramCol["Scan_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Scan_cd"]);
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
				paramCol["M1bumon_cd_bo1"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1bumon_cd_bo1"]);
				paramCol["M1bumonkana_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1bumonkana_nm"]);
				paramCol["M1siiresaki_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1siiresaki_cd"]);
				paramCol["M1siiresaki_ryaku_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1siiresaki_ryaku_nm"]);
				paramCol["M1burando_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1burando_nm"]);
				paramCol["M1henpin_kakutei_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1henpin_kakutei_ymd"]);
				paramCol["M1add_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1add_ymd"]);
				paramCol["M1siji_bango"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1siji_bango"]);
				paramCol["M1motodenpyo_bango"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1motodenpyo_bango"]);
				paramCol["M1itemsu"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1itemsu"]);
				paramCol["M1genkakin"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1genkakin"]);
				paramCol["M1nyuryokutan_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1nyuryokutan_nm"]);
				paramCol["M1kakuteitan_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1kakuteitan_nm"]);
				paramCol["M1henpin_riyu_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1henpin_riyu_nm"]);
				paramCol["M1denpyo_jyotainm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1denpyo_jyotainm"]);
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
			Td030f01Form formVO = (Td030f01Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Denpyo_jyotai"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Denpyo_jyotai"].RequestValue, formInfo["Denpyo_jyotai"]);
			paramCol["Denpyo_bango_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Denpyo_bango_from"].RequestValue, formInfo["Denpyo_bango_from"]);
			paramCol["Denpyo_bango_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Denpyo_bango_to"].RequestValue, formInfo["Denpyo_bango_to"]);
			paramCol["Motodenpyo_bango_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Motodenpyo_bango_from"].RequestValue, formInfo["Motodenpyo_bango_from"]);
			paramCol["Motodenpyo_bango_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Motodenpyo_bango_to"].RequestValue, formInfo["Motodenpyo_bango_to"]);
			paramCol["Siji_bango_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Siji_bango_from"].RequestValue, formInfo["Siji_bango_from"]);
			paramCol["Siji_bango_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Siji_bango_to"].RequestValue, formInfo["Siji_bango_to"]);
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
			paramCol["Henpin_kakutei_ymd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Henpin_kakutei_ymd_from"].RequestValue, formInfo["Henpin_kakutei_ymd_from"]);
			paramCol["Henpin_kakutei_ymd_from"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Henpin_kakutei_ymd_from"].RequestValue, formInfo["Henpin_kakutei_ymd_from"]);
			paramCol["Henpin_kakutei_ymd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Henpin_kakutei_ymd_to"].RequestValue, formInfo["Henpin_kakutei_ymd_to"]);
			paramCol["Henpin_kakutei_ymd_to"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Henpin_kakutei_ymd_to"].RequestValue, formInfo["Henpin_kakutei_ymd_to"]);
			paramCol["Add_ymd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Add_ymd_from"].RequestValue, formInfo["Add_ymd_from"]);
			paramCol["Add_ymd_from"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Add_ymd_from"].RequestValue, formInfo["Add_ymd_from"]);
			paramCol["Add_ymd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Add_ymd_to"].RequestValue, formInfo["Add_ymd_to"]);
			paramCol["Add_ymd_to"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Add_ymd_to"].RequestValue, formInfo["Add_ymd_to"]);
			paramCol["Nyuryokutan_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Nyuryokutan_cd"].RequestValue, formInfo["Nyuryokutan_cd"]);
			paramCol["Nyuryokutan_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Nyuryokutan_nm"].RequestValue, formInfo["Nyuryokutan_nm"]);
			paramCol["Kakuteitan_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Kakuteitan_cd"].RequestValue, formInfo["Kakuteitan_cd"]);
			paramCol["Kakuteitan_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Kakuteitan_nm"].RequestValue, formInfo["Kakuteitan_nm"]);
			paramCol["Henpin_riyu"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Henpin_riyu"].RequestValue, formInfo["Henpin_riyu"]);
			paramCol["Old_jisya_hbn"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Old_jisya_hbn"].RequestValue, formInfo["Old_jisya_hbn"]);
			paramCol["Maker_hbn"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Maker_hbn"].RequestValue, formInfo["Maker_hbn"]);
			paramCol["Scan_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Scan_cd"].RequestValue, formInfo["Scan_cd"]);
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
				paramCol["M1bumon_cd_bo1"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1bumon_cd_bo1"][i].RequestValue, formInfo["M1bumon_cd_bo1"]);
				paramCol["M1bumonkana_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1bumonkana_nm"][i].RequestValue, formInfo["M1bumonkana_nm"]);
				paramCol["M1siiresaki_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1siiresaki_cd"][i].RequestValue, formInfo["M1siiresaki_cd"]);
				paramCol["M1siiresaki_ryaku_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1siiresaki_ryaku_nm"][i].RequestValue, formInfo["M1siiresaki_ryaku_nm"]);
				paramCol["M1burando_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1burando_nm"][i].RequestValue, formInfo["M1burando_nm"]);
				paramCol["M1henpin_kakutei_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1henpin_kakutei_ymd"][i].RequestValue, formInfo["M1henpin_kakutei_ymd"]);
				paramCol["M1henpin_kakutei_ymd"][i].DateFullValue = RequestParameterUtil.GetDateFullValue(
					paramCol["M1henpin_kakutei_ymd"][i].RequestValue, formInfo["M1henpin_kakutei_ymd"]);
				paramCol["M1add_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1add_ymd"][i].RequestValue, formInfo["M1add_ymd"]);
				paramCol["M1add_ymd"][i].DateFullValue = RequestParameterUtil.GetDateFullValue(
					paramCol["M1add_ymd"][i].RequestValue, formInfo["M1add_ymd"]);
				paramCol["M1siji_bango"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1siji_bango"][i].RequestValue, formInfo["M1siji_bango"]);
				paramCol["M1motodenpyo_bango"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1motodenpyo_bango"][i].RequestValue, formInfo["M1motodenpyo_bango"]);
				paramCol["M1itemsu"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1itemsu"][i].RequestValue, formInfo["M1itemsu"]);
				paramCol["M1genkakin"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1genkakin"][i].RequestValue, formInfo["M1genkakin"]);
				paramCol["M1nyuryokutan_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1nyuryokutan_nm"][i].RequestValue, formInfo["M1nyuryokutan_nm"]);
				paramCol["M1kakuteitan_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1kakuteitan_nm"][i].RequestValue, formInfo["M1kakuteitan_nm"]);
				paramCol["M1henpin_riyu_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1henpin_riyu_nm"][i].RequestValue, formInfo["M1henpin_riyu_nm"]);
				paramCol["M1denpyo_jyotainm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1denpyo_jyotainm"][i].RequestValue, formInfo["M1denpyo_jyotainm"]);
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
			Td030f01Form formVO = (Td030f01Form)pageContext.GetFormVO();

			//カード項目の入力値をFormVOにコピーする
			if (paramCol["Head_tenpo_cd"].UnformatValue != null)
			{
				formVO.Head_tenpo_cd = paramCol["Head_tenpo_cd"].UnformatValue;
			}
			if (paramCol["Head_tenpo_nm"].UnformatValue != null)
			{
				formVO.Head_tenpo_nm = paramCol["Head_tenpo_nm"].UnformatValue;
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
			if (paramCol["Motodenpyo_bango_from"].UnformatValue != null)
			{
				formVO.Motodenpyo_bango_from = paramCol["Motodenpyo_bango_from"].UnformatValue;
			}
			if (paramCol["Motodenpyo_bango_to"].UnformatValue != null)
			{
				formVO.Motodenpyo_bango_to = paramCol["Motodenpyo_bango_to"].UnformatValue;
			}
			if (paramCol["Siji_bango_from"].UnformatValue != null)
			{
				formVO.Siji_bango_from = paramCol["Siji_bango_from"].UnformatValue;
			}
			if (paramCol["Siji_bango_to"].UnformatValue != null)
			{
				formVO.Siji_bango_to = paramCol["Siji_bango_to"].UnformatValue;
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
			if (paramCol["Henpin_kakutei_ymd_from"].DateFullValue != null)
			{
				formVO.Henpin_kakutei_ymd_from = paramCol["Henpin_kakutei_ymd_from"].DateFullValue;
			}
			if (paramCol["Henpin_kakutei_ymd_to"].DateFullValue != null)
			{
				formVO.Henpin_kakutei_ymd_to = paramCol["Henpin_kakutei_ymd_to"].DateFullValue;
			}
			if (paramCol["Add_ymd_from"].DateFullValue != null)
			{
				formVO.Add_ymd_from = paramCol["Add_ymd_from"].DateFullValue;
			}
			if (paramCol["Add_ymd_to"].DateFullValue != null)
			{
				formVO.Add_ymd_to = paramCol["Add_ymd_to"].DateFullValue;
			}
			if (paramCol["Nyuryokutan_cd"].UnformatValue != null)
			{
				formVO.Nyuryokutan_cd = paramCol["Nyuryokutan_cd"].UnformatValue;
			}
			if (paramCol["Nyuryokutan_nm"].UnformatValue != null)
			{
				formVO.Nyuryokutan_nm = paramCol["Nyuryokutan_nm"].UnformatValue;
			}
			if (paramCol["Kakuteitan_cd"].UnformatValue != null)
			{
				formVO.Kakuteitan_cd = paramCol["Kakuteitan_cd"].UnformatValue;
			}
			if (paramCol["Kakuteitan_nm"].UnformatValue != null)
			{
				formVO.Kakuteitan_nm = paramCol["Kakuteitan_nm"].UnformatValue;
			}
			if (paramCol["Henpin_riyu"].UnformatValue != null)
			{
				formVO.Henpin_riyu = paramCol["Henpin_riyu"].UnformatValue;
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
				Td030f01M1Form td030f01M1Form = (Td030f01M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					td030f01M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1bumon_cd_bo1"][i].UnformatValue != null)
				{
					td030f01M1Form.M1bumon_cd_bo1 = paramCol["M1bumon_cd_bo1"][i].UnformatValue;
				}
				if (paramCol["M1bumonkana_nm"][i].UnformatValue != null)
				{
					td030f01M1Form.M1bumonkana_nm = paramCol["M1bumonkana_nm"][i].UnformatValue;
				}
				if (paramCol["M1siiresaki_cd"][i].UnformatValue != null)
				{
					td030f01M1Form.M1siiresaki_cd = paramCol["M1siiresaki_cd"][i].UnformatValue;
				}
				if (paramCol["M1siiresaki_ryaku_nm"][i].UnformatValue != null)
				{
					td030f01M1Form.M1siiresaki_ryaku_nm = paramCol["M1siiresaki_ryaku_nm"][i].UnformatValue;
				}
				if (paramCol["M1burando_nm"][i].UnformatValue != null)
				{
					td030f01M1Form.M1burando_nm = paramCol["M1burando_nm"][i].UnformatValue;
				}
				if (paramCol["M1henpin_kakutei_ymd"][i].DateFullValue != null)
				{
					td030f01M1Form.M1henpin_kakutei_ymd = paramCol["M1henpin_kakutei_ymd"][i].DateFullValue;
				}
				if (paramCol["M1add_ymd"][i].DateFullValue != null)
				{
					td030f01M1Form.M1add_ymd = paramCol["M1add_ymd"][i].DateFullValue;
				}
				if (paramCol["M1siji_bango"][i].UnformatValue != null)
				{
					td030f01M1Form.M1siji_bango = paramCol["M1siji_bango"][i].UnformatValue;
				}
				if (paramCol["M1motodenpyo_bango"][i].UnformatValue != null)
				{
					td030f01M1Form.M1motodenpyo_bango = paramCol["M1motodenpyo_bango"][i].UnformatValue;
				}
				if (paramCol["M1itemsu"][i].UnformatValue != null)
				{
					td030f01M1Form.M1itemsu = paramCol["M1itemsu"][i].UnformatValue;
				}
				if (paramCol["M1genkakin"][i].UnformatValue != null)
				{
					td030f01M1Form.M1genkakin = paramCol["M1genkakin"][i].UnformatValue;
				}
				if (paramCol["M1nyuryokutan_nm"][i].UnformatValue != null)
				{
					td030f01M1Form.M1nyuryokutan_nm = paramCol["M1nyuryokutan_nm"][i].UnformatValue;
				}
				if (paramCol["M1kakuteitan_nm"][i].UnformatValue != null)
				{
					td030f01M1Form.M1kakuteitan_nm = paramCol["M1kakuteitan_nm"][i].UnformatValue;
				}
				if (paramCol["M1henpin_riyu_nm"][i].UnformatValue != null)
				{
					td030f01M1Form.M1henpin_riyu_nm = paramCol["M1henpin_riyu_nm"][i].UnformatValue;
				}
				if (paramCol["M1denpyo_jyotainm"][i].UnformatValue != null)
				{
					td030f01M1Form.M1denpyo_jyotainm = paramCol["M1denpyo_jyotainm"][i].UnformatValue;
				}
				if (paramCol["M1syorinm"][i].UnformatValue != null)
				{
					td030f01M1Form.M1syorinm = paramCol["M1syorinm"][i].UnformatValue;
				}
				if (paramCol["M1syoriymd"][i].DateFullValue != null)
				{
					td030f01M1Form.M1syoriymd = paramCol["M1syoriymd"][i].DateFullValue;
				}
				if (paramCol["M1syori_tm"][i].DateFullValue != null)
				{
					td030f01M1Form.M1syori_tm = paramCol["M1syori_tm"][i].DateFullValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					td030f01M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					td030f01M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					td030f01M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Td030f01Form formVO, StandardCheckManager checker)
		{
			if (formVO.Head_tenpo_cd != null)
			{
				checker.DoCheck("Head_tenpo_cd", formVO.Head_tenpo_cd);
			}
			if (formVO.Head_tenpo_nm != null)
			{
				checker.DoCheck("Head_tenpo_nm", formVO.Head_tenpo_nm);
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
			if (formVO.Motodenpyo_bango_from != null)
			{
				checker.DoCheck("Motodenpyo_bango_from", formVO.Motodenpyo_bango_from);
			}
			if (formVO.Motodenpyo_bango_to != null)
			{
				checker.DoCheck("Motodenpyo_bango_to", formVO.Motodenpyo_bango_to);
			}
			if (formVO.Siji_bango_from != null)
			{
				checker.DoCheck("Siji_bango_from", formVO.Siji_bango_from);
			}
			if (formVO.Siji_bango_to != null)
			{
				checker.DoCheck("Siji_bango_to", formVO.Siji_bango_to);
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
			if (formVO.Henpin_kakutei_ymd_from != null)
			{
				checker.DoCheck("Henpin_kakutei_ymd_from", formVO.Henpin_kakutei_ymd_from);
			}
			if (formVO.Henpin_kakutei_ymd_to != null)
			{
				checker.DoCheck("Henpin_kakutei_ymd_to", formVO.Henpin_kakutei_ymd_to);
			}
			if (formVO.Add_ymd_from != null)
			{
				checker.DoCheck("Add_ymd_from", formVO.Add_ymd_from);
			}
			if (formVO.Add_ymd_to != null)
			{
				checker.DoCheck("Add_ymd_to", formVO.Add_ymd_to);
			}
			if (formVO.Nyuryokutan_cd != null)
			{
				checker.DoCheck("Nyuryokutan_cd", formVO.Nyuryokutan_cd);
			}
			if (formVO.Nyuryokutan_nm != null)
			{
				checker.DoCheck("Nyuryokutan_nm", formVO.Nyuryokutan_nm);
			}
			if (formVO.Kakuteitan_cd != null)
			{
				checker.DoCheck("Kakuteitan_cd", formVO.Kakuteitan_cd);
			}
			if (formVO.Kakuteitan_nm != null)
			{
				checker.DoCheck("Kakuteitan_nm", formVO.Kakuteitan_nm);
			}
			if (formVO.Henpin_riyu != null)
			{
				checker.DoCheck("Henpin_riyu", formVO.Henpin_riyu);
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
		public static void ValidateM1InputValue(Td030f01Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Td030f01M1Form td030f01M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, td030f01M1Form, i, m1List);
				if (td030f01M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", td030f01M1Form.M1rowno, i, m1List);
				}
				if (td030f01M1Form.M1bumon_cd_bo1 != null)
				{
					checker.DoCheck("M1bumon_cd_bo1", td030f01M1Form.M1bumon_cd_bo1, i, m1List);
				}
				if (td030f01M1Form.M1bumonkana_nm != null)
				{
					checker.DoCheck("M1bumonkana_nm", td030f01M1Form.M1bumonkana_nm, i, m1List);
				}
				if (td030f01M1Form.M1siiresaki_cd != null)
				{
					checker.DoCheck("M1siiresaki_cd", td030f01M1Form.M1siiresaki_cd, i, m1List);
				}
				if (td030f01M1Form.M1siiresaki_ryaku_nm != null)
				{
					checker.DoCheck("M1siiresaki_ryaku_nm", td030f01M1Form.M1siiresaki_ryaku_nm, i, m1List);
				}
				if (td030f01M1Form.M1burando_nm != null)
				{
					checker.DoCheck("M1burando_nm", td030f01M1Form.M1burando_nm, i, m1List);
				}
				if (td030f01M1Form.M1henpin_kakutei_ymd != null)
				{
					checker.DoCheck("M1henpin_kakutei_ymd", td030f01M1Form.M1henpin_kakutei_ymd, i, m1List);
				}
				if (td030f01M1Form.M1add_ymd != null)
				{
					checker.DoCheck("M1add_ymd", td030f01M1Form.M1add_ymd, i, m1List);
				}
				if (td030f01M1Form.M1siji_bango != null)
				{
					checker.DoCheck("M1siji_bango", td030f01M1Form.M1siji_bango, i, m1List);
				}
				if (td030f01M1Form.M1motodenpyo_bango != null)
				{
					checker.DoCheck("M1motodenpyo_bango", td030f01M1Form.M1motodenpyo_bango, i, m1List);
				}
				if (td030f01M1Form.M1itemsu != null)
				{
					checker.DoCheck("M1itemsu", td030f01M1Form.M1itemsu, i, m1List);
				}
				if (td030f01M1Form.M1genkakin != null)
				{
					checker.DoCheck("M1genkakin", td030f01M1Form.M1genkakin, i, m1List);
				}
				if (td030f01M1Form.M1nyuryokutan_nm != null)
				{
					checker.DoCheck("M1nyuryokutan_nm", td030f01M1Form.M1nyuryokutan_nm, i, m1List);
				}
				if (td030f01M1Form.M1kakuteitan_nm != null)
				{
					checker.DoCheck("M1kakuteitan_nm", td030f01M1Form.M1kakuteitan_nm, i, m1List);
				}
				if (td030f01M1Form.M1henpin_riyu_nm != null)
				{
					checker.DoCheck("M1henpin_riyu_nm", td030f01M1Form.M1henpin_riyu_nm, i, m1List);
				}
				if (td030f01M1Form.M1denpyo_jyotainm != null)
				{
					checker.DoCheck("M1denpyo_jyotainm", td030f01M1Form.M1denpyo_jyotainm, i, m1List);
				}
				if (td030f01M1Form.M1syorinm != null)
				{
					checker.DoCheck("M1syorinm", td030f01M1Form.M1syorinm, i, m1List);
				}
				if (td030f01M1Form.M1syoriymd != null)
				{
					checker.DoCheck("M1syoriymd", td030f01M1Form.M1syoriymd, i, m1List);
				}
				if (td030f01M1Form.M1syori_tm != null)
				{
					checker.DoCheck("M1syori_tm", td030f01M1Form.M1syori_tm, i, m1List);
				}
				if (td030f01M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", td030f01M1Form.M1selectorcheckbox, i, m1List);
				}
				if (td030f01M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", td030f01M1Form.M1entersyoriflg, i, m1List);
				}
				if (td030f01M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", td030f01M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Td030f01Form formVO, StandardCodeCheckManager checker)
		{
			checker.DoCheck("Btnheadtenpocd", formVO);
			checker.DoCheck("Btnsiiresaki_cd", formVO);
			checker.DoCheck("Btnbumon_cd_from", formVO);
			checker.DoCheck("Btnbumon_cd_to", formVO);
			checker.DoCheck("Btnnyuryokutanto_cd", formVO);
			checker.DoCheck("Btnkakuteitanto_cd", formVO);
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Td030f01Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

