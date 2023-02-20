using com.xebio.bo.Tb010p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Tb010p01.Request
{
  /// <summary>
  /// Tb010f01RequestHelper の概要の説明です。
  /// </summary>
  public static class Tb010f01RequestHelper
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
			Tb010f01Form formVO = (Tb010f01Form)pageContext.GetFormVO();

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
			paramCol["Denpyo_bango_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Denpyo_bango_from"]);
			paramCol["Denpyo_bango_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Denpyo_bango_to"]);
			paramCol["Motodenpyo_bango_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Motodenpyo_bango_from"]);
			paramCol["Motodenpyo_bango_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Motodenpyo_bango_to"]);
			paramCol["Old_jisya_hbn"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Old_jisya_hbn"]);
			paramCol["Maker_hbn"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Maker_hbn"]);
			paramCol["Scan_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Scan_cd"]);
			paramCol["Searchcnt"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Searchcnt"]);
			paramCol["Eigyo_ymd_hdn"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Eigyo_ymd_hdn"]);
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
				paramCol["M1motodenpyo_bango"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1motodenpyo_bango"]);
				paramCol["M1nohin_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1nohin_su"]);
				paramCol["M1kensu"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1kensu"]);
				paramCol["M1genka_kin"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1genka_kin"]);
				paramCol["M1siire_kakutei_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1siire_kakutei_ymd"]);
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
			Tb010f01Form formVO = (Tb010f01Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Denpyo_jyotai"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Denpyo_jyotai"].RequestValue, formInfo["Denpyo_jyotai"]);
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
			paramCol["Denpyo_bango_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Denpyo_bango_from"].RequestValue, formInfo["Denpyo_bango_from"]);
			paramCol["Denpyo_bango_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Denpyo_bango_to"].RequestValue, formInfo["Denpyo_bango_to"]);
			paramCol["Motodenpyo_bango_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Motodenpyo_bango_from"].RequestValue, formInfo["Motodenpyo_bango_from"]);
			paramCol["Motodenpyo_bango_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Motodenpyo_bango_to"].RequestValue, formInfo["Motodenpyo_bango_to"]);
			paramCol["Old_jisya_hbn"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Old_jisya_hbn"].RequestValue, formInfo["Old_jisya_hbn"]);
			paramCol["Maker_hbn"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Maker_hbn"].RequestValue, formInfo["Maker_hbn"]);
			paramCol["Scan_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Scan_cd"].RequestValue, formInfo["Scan_cd"]);
			paramCol["Searchcnt"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Searchcnt"].RequestValue, formInfo["Searchcnt"]);
			paramCol["Eigyo_ymd_hdn"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Eigyo_ymd_hdn"].RequestValue, formInfo["Eigyo_ymd_hdn"]);
			paramCol["Eigyo_ymd_hdn"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Eigyo_ymd_hdn"].RequestValue, formInfo["Eigyo_ymd_hdn"]);
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
				paramCol["M1motodenpyo_bango"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1motodenpyo_bango"][i].RequestValue, formInfo["M1motodenpyo_bango"]);
				paramCol["M1nohin_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1nohin_su"][i].RequestValue, formInfo["M1nohin_su"]);
				paramCol["M1kensu"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1kensu"][i].RequestValue, formInfo["M1kensu"]);
				paramCol["M1genka_kin"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1genka_kin"][i].RequestValue, formInfo["M1genka_kin"]);
				paramCol["M1siire_kakutei_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1siire_kakutei_ymd"][i].RequestValue, formInfo["M1siire_kakutei_ymd"]);
				paramCol["M1siire_kakutei_ymd"][i].DateFullValue = RequestParameterUtil.GetDateFullValue(
					paramCol["M1siire_kakutei_ymd"][i].RequestValue, formInfo["M1siire_kakutei_ymd"]);
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
			Tb010f01Form formVO = (Tb010f01Form)pageContext.GetFormVO();

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
			if (paramCol["Eigyo_ymd_hdn"].DateFullValue != null)
			{
				formVO.Eigyo_ymd_hdn = paramCol["Eigyo_ymd_hdn"].DateFullValue;
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
				Tb010f01M1Form tb010f01M1Form = (Tb010f01M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					tb010f01M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1bumon_cd"][i].UnformatValue != null)
				{
					tb010f01M1Form.M1bumon_cd = paramCol["M1bumon_cd"][i].UnformatValue;
				}
				if (paramCol["M1bumonkana_nm"][i].UnformatValue != null)
				{
					tb010f01M1Form.M1bumonkana_nm = paramCol["M1bumonkana_nm"][i].UnformatValue;
				}
				if (paramCol["M1siiresaki_cd"][i].UnformatValue != null)
				{
					tb010f01M1Form.M1siiresaki_cd = paramCol["M1siiresaki_cd"][i].UnformatValue;
				}
				if (paramCol["M1siiresaki_ryaku_nm"][i].UnformatValue != null)
				{
					tb010f01M1Form.M1siiresaki_ryaku_nm = paramCol["M1siiresaki_ryaku_nm"][i].UnformatValue;
				}
				if (paramCol["M1nyukayotei_ymd"][i].DateFullValue != null)
				{
					tb010f01M1Form.M1nyukayotei_ymd = paramCol["M1nyukayotei_ymd"][i].DateFullValue;
				}
				if (paramCol["M1motodenpyo_bango"][i].UnformatValue != null)
				{
					tb010f01M1Form.M1motodenpyo_bango = paramCol["M1motodenpyo_bango"][i].UnformatValue;
				}
				if (paramCol["M1nohin_su"][i].UnformatValue != null)
				{
					tb010f01M1Form.M1nohin_su = paramCol["M1nohin_su"][i].UnformatValue;
				}
				if (paramCol["M1kensu"][i].UnformatValue != null)
				{
					tb010f01M1Form.M1kensu = paramCol["M1kensu"][i].UnformatValue;
				}
				if (paramCol["M1genka_kin"][i].UnformatValue != null)
				{
					tb010f01M1Form.M1genka_kin = paramCol["M1genka_kin"][i].UnformatValue;
				}
				if (paramCol["M1siire_kakutei_ymd"][i].DateFullValue != null)
				{
					tb010f01M1Form.M1siire_kakutei_ymd = paramCol["M1siire_kakutei_ymd"][i].DateFullValue;
				}
				if (paramCol["M1denpyo_jyotainm"][i].UnformatValue != null)
				{
					tb010f01M1Form.M1denpyo_jyotainm = paramCol["M1denpyo_jyotainm"][i].UnformatValue;
				}
				if (paramCol["M1syorinm"][i].UnformatValue != null)
				{
					tb010f01M1Form.M1syorinm = paramCol["M1syorinm"][i].UnformatValue;
				}
				if (paramCol["M1syoriymd"][i].DateFullValue != null)
				{
					tb010f01M1Form.M1syoriymd = paramCol["M1syoriymd"][i].DateFullValue;
				}
				if (paramCol["M1syori_tm"][i].DateFullValue != null)
				{
					tb010f01M1Form.M1syori_tm = paramCol["M1syori_tm"][i].DateFullValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					tb010f01M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					tb010f01M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					tb010f01M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Tb010f01Form formVO, StandardCheckManager checker)
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
			if (formVO.Eigyo_ymd_hdn != null)
			{
				checker.DoCheck("Eigyo_ymd_hdn", formVO.Eigyo_ymd_hdn);
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
		public static void ValidateM1InputValue(Tb010f01Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Tb010f01M1Form tb010f01M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, tb010f01M1Form, i, m1List);
				if (tb010f01M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", tb010f01M1Form.M1rowno, i, m1List);
				}
				if (tb010f01M1Form.M1bumon_cd != null)
				{
					checker.DoCheck("M1bumon_cd", tb010f01M1Form.M1bumon_cd, i, m1List);
				}
				if (tb010f01M1Form.M1bumonkana_nm != null)
				{
					checker.DoCheck("M1bumonkana_nm", tb010f01M1Form.M1bumonkana_nm, i, m1List);
				}
				if (tb010f01M1Form.M1siiresaki_cd != null)
				{
					checker.DoCheck("M1siiresaki_cd", tb010f01M1Form.M1siiresaki_cd, i, m1List);
				}
				if (tb010f01M1Form.M1siiresaki_ryaku_nm != null)
				{
					checker.DoCheck("M1siiresaki_ryaku_nm", tb010f01M1Form.M1siiresaki_ryaku_nm, i, m1List);
				}
				if (tb010f01M1Form.M1nyukayotei_ymd != null)
				{
					checker.DoCheck("M1nyukayotei_ymd", tb010f01M1Form.M1nyukayotei_ymd, i, m1List);
				}
				if (tb010f01M1Form.M1motodenpyo_bango != null)
				{
					checker.DoCheck("M1motodenpyo_bango", tb010f01M1Form.M1motodenpyo_bango, i, m1List);
				}
				if (tb010f01M1Form.M1nohin_su != null)
				{
					checker.DoCheck("M1nohin_su", tb010f01M1Form.M1nohin_su, i, m1List);
				}
				if (tb010f01M1Form.M1kensu != null)
				{
					checker.DoCheck("M1kensu", tb010f01M1Form.M1kensu, i, m1List);
				}
				if (tb010f01M1Form.M1genka_kin != null)
				{
					checker.DoCheck("M1genka_kin", tb010f01M1Form.M1genka_kin, i, m1List);
				}
				if (tb010f01M1Form.M1siire_kakutei_ymd != null)
				{
					checker.DoCheck("M1siire_kakutei_ymd", tb010f01M1Form.M1siire_kakutei_ymd, i, m1List);
				}
				if (tb010f01M1Form.M1denpyo_jyotainm != null)
				{
					checker.DoCheck("M1denpyo_jyotainm", tb010f01M1Form.M1denpyo_jyotainm, i, m1List);
				}
				if (tb010f01M1Form.M1syorinm != null)
				{
					checker.DoCheck("M1syorinm", tb010f01M1Form.M1syorinm, i, m1List);
				}
				if (tb010f01M1Form.M1syoriymd != null)
				{
					checker.DoCheck("M1syoriymd", tb010f01M1Form.M1syoriymd, i, m1List);
				}
				if (tb010f01M1Form.M1syori_tm != null)
				{
					checker.DoCheck("M1syori_tm", tb010f01M1Form.M1syori_tm, i, m1List);
				}
				if (tb010f01M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", tb010f01M1Form.M1selectorcheckbox, i, m1List);
				}
				if (tb010f01M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", tb010f01M1Form.M1entersyoriflg, i, m1List);
				}
				if (tb010f01M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", tb010f01M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Tb010f01Form formVO, StandardCodeCheckManager checker)
		{
			checker.DoCheck("Btnheadtenpocd", formVO);
			checker.DoCheck("Btnsiiresaki_cd", formVO);
			checker.DoCheck("Btnbumon_cd_from", formVO);
			checker.DoCheck("Btnbumon_cdto", formVO);
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Tb010f01Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

