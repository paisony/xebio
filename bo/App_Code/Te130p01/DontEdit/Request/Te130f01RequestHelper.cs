using com.xebio.bo.Te130p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Te130p01.Request
{
  /// <summary>
  /// Te130f01RequestHelper の概要の説明です。
  /// </summary>
  public static class Te130f01RequestHelper
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
			Te130f01Form formVO = (Te130f01Form)pageContext.GetFormVO();

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
			paramCol["Idodenpyo_bango_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Idodenpyo_bango_from"]);
			paramCol["Idodenpyo_bango_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Idodenpyo_bango_to"]);
			paramCol["Siji_bango_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Siji_bango_from"]);
			paramCol["Siji_bango_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Siji_bango_to"]);
			paramCol["Jyuryokaisya_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Jyuryokaisya_cd"]);
			paramCol["Nyukakaisya_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Nyukakaisya_nm"]);
			paramCol["Jyuryoten_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Jyuryoten_cd"]);
			paramCol["Juryoten_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Juryoten_nm"]);
			paramCol["Jyuryo_ymd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Jyuryo_ymd_from"]);
			paramCol["Jyuryo_ymd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Jyuryo_ymd_to"]);
			paramCol["Syukkakaisya_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Syukkakaisya_cd"]);
			paramCol["Syukkakaisya_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Syukkakaisya_nm"]);
			paramCol["Syukkaten_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Syukkaten_cd"]);
			paramCol["Syukkatenpo_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Syukkatenpo_nm"]);
			paramCol["Syukka_ymd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Syukka_ymd_from"]);
			paramCol["Syukka_ymd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Syukka_ymd_to"]);
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
				paramCol["M1syukkakaisya_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1syukkakaisya_cd"]);
				paramCol["M1syukkaten_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1syukkaten_cd"]);
				paramCol["M1syukkatenpo_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1syukkatenpo_nm"]);
				paramCol["M1jyuryokaisya_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1jyuryokaisya_cd"]);
				paramCol["M1jyuryoten_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1jyuryoten_cd"]);
				paramCol["M1juryoten_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1juryoten_nm"]);
				paramCol["M1idodenpyo_bango"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1idodenpyo_bango"]);
				paramCol["M1siji_bango"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1siji_bango"]);
				paramCol["M1syukka_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1syukka_ymd"]);
				paramCol["M1jyuryo_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1jyuryo_ymd"]);
				paramCol["M1nyukayotei_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1nyukayotei_su"]);
				paramCol["M1nyukajisseki_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1nyukajisseki_su"]);
				paramCol["M1kyakucyu"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1kyakucyu"]);
				paramCol["M1syorinm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1syorinm"]);
				paramCol["M1syori_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1syori_ymd"]);
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
			Te130f01Form formVO = (Te130f01Form)pageContext.GetFormVO();

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
			paramCol["Idodenpyo_bango_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Idodenpyo_bango_from"].RequestValue, formInfo["Idodenpyo_bango_from"]);
			paramCol["Idodenpyo_bango_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Idodenpyo_bango_to"].RequestValue, formInfo["Idodenpyo_bango_to"]);
			paramCol["Siji_bango_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Siji_bango_from"].RequestValue, formInfo["Siji_bango_from"]);
			paramCol["Siji_bango_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Siji_bango_to"].RequestValue, formInfo["Siji_bango_to"]);
			paramCol["Jyuryokaisya_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Jyuryokaisya_cd"].RequestValue, formInfo["Jyuryokaisya_cd"]);
			paramCol["Nyukakaisya_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Nyukakaisya_nm"].RequestValue, formInfo["Nyukakaisya_nm"]);
			paramCol["Jyuryoten_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Jyuryoten_cd"].RequestValue, formInfo["Jyuryoten_cd"]);
			paramCol["Juryoten_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Juryoten_nm"].RequestValue, formInfo["Juryoten_nm"]);
			paramCol["Jyuryo_ymd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Jyuryo_ymd_from"].RequestValue, formInfo["Jyuryo_ymd_from"]);
			paramCol["Jyuryo_ymd_from"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Jyuryo_ymd_from"].RequestValue, formInfo["Jyuryo_ymd_from"]);
			paramCol["Jyuryo_ymd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Jyuryo_ymd_to"].RequestValue, formInfo["Jyuryo_ymd_to"]);
			paramCol["Jyuryo_ymd_to"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Jyuryo_ymd_to"].RequestValue, formInfo["Jyuryo_ymd_to"]);
			paramCol["Syukkakaisya_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Syukkakaisya_cd"].RequestValue, formInfo["Syukkakaisya_cd"]);
			paramCol["Syukkakaisya_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Syukkakaisya_nm"].RequestValue, formInfo["Syukkakaisya_nm"]);
			paramCol["Syukkaten_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Syukkaten_cd"].RequestValue, formInfo["Syukkaten_cd"]);
			paramCol["Syukkatenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Syukkatenpo_nm"].RequestValue, formInfo["Syukkatenpo_nm"]);
			paramCol["Syukka_ymd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Syukka_ymd_from"].RequestValue, formInfo["Syukka_ymd_from"]);
			paramCol["Syukka_ymd_from"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Syukka_ymd_from"].RequestValue, formInfo["Syukka_ymd_from"]);
			paramCol["Syukka_ymd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Syukka_ymd_to"].RequestValue, formInfo["Syukka_ymd_to"]);
			paramCol["Syukka_ymd_to"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Syukka_ymd_to"].RequestValue, formInfo["Syukka_ymd_to"]);
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
				paramCol["M1syukkakaisya_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1syukkakaisya_cd"][i].RequestValue, formInfo["M1syukkakaisya_cd"]);
				paramCol["M1syukkaten_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1syukkaten_cd"][i].RequestValue, formInfo["M1syukkaten_cd"]);
				paramCol["M1syukkatenpo_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1syukkatenpo_nm"][i].RequestValue, formInfo["M1syukkatenpo_nm"]);
				paramCol["M1jyuryokaisya_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1jyuryokaisya_cd"][i].RequestValue, formInfo["M1jyuryokaisya_cd"]);
				paramCol["M1jyuryoten_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1jyuryoten_cd"][i].RequestValue, formInfo["M1jyuryoten_cd"]);
				paramCol["M1juryoten_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1juryoten_nm"][i].RequestValue, formInfo["M1juryoten_nm"]);
				paramCol["M1idodenpyo_bango"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1idodenpyo_bango"][i].RequestValue, formInfo["M1idodenpyo_bango"]);
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
				paramCol["M1nyukayotei_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1nyukayotei_su"][i].RequestValue, formInfo["M1nyukayotei_su"]);
				paramCol["M1nyukajisseki_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1nyukajisseki_su"][i].RequestValue, formInfo["M1nyukajisseki_su"]);
				paramCol["M1kyakucyu"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1kyakucyu"][i].RequestValue, formInfo["M1kyakucyu"]);
				paramCol["M1syorinm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1syorinm"][i].RequestValue, formInfo["M1syorinm"]);
				paramCol["M1syori_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1syori_ymd"][i].RequestValue, formInfo["M1syori_ymd"]);
				paramCol["M1syori_ymd"][i].DateFullValue = RequestParameterUtil.GetDateFullValue(
					paramCol["M1syori_ymd"][i].RequestValue, formInfo["M1syori_ymd"]);
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
			Te130f01Form formVO = (Te130f01Form)pageContext.GetFormVO();

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
			if (paramCol["Idodenpyo_bango_from"].UnformatValue != null)
			{
				formVO.Idodenpyo_bango_from = paramCol["Idodenpyo_bango_from"].UnformatValue;
			}
			if (paramCol["Idodenpyo_bango_to"].UnformatValue != null)
			{
				formVO.Idodenpyo_bango_to = paramCol["Idodenpyo_bango_to"].UnformatValue;
			}
			if (paramCol["Siji_bango_from"].UnformatValue != null)
			{
				formVO.Siji_bango_from = paramCol["Siji_bango_from"].UnformatValue;
			}
			if (paramCol["Siji_bango_to"].UnformatValue != null)
			{
				formVO.Siji_bango_to = paramCol["Siji_bango_to"].UnformatValue;
			}
			if (paramCol["Jyuryokaisya_cd"].UnformatValue != null)
			{
				formVO.Jyuryokaisya_cd = paramCol["Jyuryokaisya_cd"].UnformatValue;
			}
			if (paramCol["Nyukakaisya_nm"].UnformatValue != null)
			{
				formVO.Nyukakaisya_nm = paramCol["Nyukakaisya_nm"].UnformatValue;
			}
			if (paramCol["Jyuryoten_cd"].UnformatValue != null)
			{
				formVO.Jyuryoten_cd = paramCol["Jyuryoten_cd"].UnformatValue;
			}
			if (paramCol["Juryoten_nm"].UnformatValue != null)
			{
				formVO.Juryoten_nm = paramCol["Juryoten_nm"].UnformatValue;
			}
			if (paramCol["Jyuryo_ymd_from"].DateFullValue != null)
			{
				formVO.Jyuryo_ymd_from = paramCol["Jyuryo_ymd_from"].DateFullValue;
			}
			if (paramCol["Jyuryo_ymd_to"].DateFullValue != null)
			{
				formVO.Jyuryo_ymd_to = paramCol["Jyuryo_ymd_to"].DateFullValue;
			}
			if (paramCol["Syukkakaisya_cd"].UnformatValue != null)
			{
				formVO.Syukkakaisya_cd = paramCol["Syukkakaisya_cd"].UnformatValue;
			}
			if (paramCol["Syukkakaisya_nm"].UnformatValue != null)
			{
				formVO.Syukkakaisya_nm = paramCol["Syukkakaisya_nm"].UnformatValue;
			}
			if (paramCol["Syukkaten_cd"].UnformatValue != null)
			{
				formVO.Syukkaten_cd = paramCol["Syukkaten_cd"].UnformatValue;
			}
			if (paramCol["Syukkatenpo_nm"].UnformatValue != null)
			{
				formVO.Syukkatenpo_nm = paramCol["Syukkatenpo_nm"].UnformatValue;
			}
			if (paramCol["Syukka_ymd_from"].DateFullValue != null)
			{
				formVO.Syukka_ymd_from = paramCol["Syukka_ymd_from"].DateFullValue;
			}
			if (paramCol["Syukka_ymd_to"].DateFullValue != null)
			{
				formVO.Syukka_ymd_to = paramCol["Syukka_ymd_to"].DateFullValue;
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
				Te130f01M1Form te130f01M1Form = (Te130f01M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					te130f01M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1syukkakaisya_cd"][i].UnformatValue != null)
				{
					te130f01M1Form.M1syukkakaisya_cd = paramCol["M1syukkakaisya_cd"][i].UnformatValue;
				}
				if (paramCol["M1syukkaten_cd"][i].UnformatValue != null)
				{
					te130f01M1Form.M1syukkaten_cd = paramCol["M1syukkaten_cd"][i].UnformatValue;
				}
				if (paramCol["M1syukkatenpo_nm"][i].UnformatValue != null)
				{
					te130f01M1Form.M1syukkatenpo_nm = paramCol["M1syukkatenpo_nm"][i].UnformatValue;
				}
				if (paramCol["M1jyuryokaisya_cd"][i].UnformatValue != null)
				{
					te130f01M1Form.M1jyuryokaisya_cd = paramCol["M1jyuryokaisya_cd"][i].UnformatValue;
				}
				if (paramCol["M1jyuryoten_cd"][i].UnformatValue != null)
				{
					te130f01M1Form.M1jyuryoten_cd = paramCol["M1jyuryoten_cd"][i].UnformatValue;
				}
				if (paramCol["M1juryoten_nm"][i].UnformatValue != null)
				{
					te130f01M1Form.M1juryoten_nm = paramCol["M1juryoten_nm"][i].UnformatValue;
				}
				if (paramCol["M1idodenpyo_bango"][i].UnformatValue != null)
				{
					te130f01M1Form.M1idodenpyo_bango = paramCol["M1idodenpyo_bango"][i].UnformatValue;
				}
				if (paramCol["M1siji_bango"][i].UnformatValue != null)
				{
					te130f01M1Form.M1siji_bango = paramCol["M1siji_bango"][i].UnformatValue;
				}
				if (paramCol["M1syukka_ymd"][i].DateFullValue != null)
				{
					te130f01M1Form.M1syukka_ymd = paramCol["M1syukka_ymd"][i].DateFullValue;
				}
				if (paramCol["M1jyuryo_ymd"][i].DateFullValue != null)
				{
					te130f01M1Form.M1jyuryo_ymd = paramCol["M1jyuryo_ymd"][i].DateFullValue;
				}
				if (paramCol["M1nyukayotei_su"][i].UnformatValue != null)
				{
					te130f01M1Form.M1nyukayotei_su = paramCol["M1nyukayotei_su"][i].UnformatValue;
				}
				if (paramCol["M1nyukajisseki_su"][i].UnformatValue != null)
				{
					te130f01M1Form.M1nyukajisseki_su = paramCol["M1nyukajisseki_su"][i].UnformatValue;
				}
				if (paramCol["M1kyakucyu"][i].UnformatValue != null)
				{
					te130f01M1Form.M1kyakucyu = paramCol["M1kyakucyu"][i].UnformatValue;
				}
				if (paramCol["M1syorinm"][i].UnformatValue != null)
				{
					te130f01M1Form.M1syorinm = paramCol["M1syorinm"][i].UnformatValue;
				}
				if (paramCol["M1syori_ymd"][i].DateFullValue != null)
				{
					te130f01M1Form.M1syori_ymd = paramCol["M1syori_ymd"][i].DateFullValue;
				}
				if (paramCol["M1syori_tm"][i].DateFullValue != null)
				{
					te130f01M1Form.M1syori_tm = paramCol["M1syori_tm"][i].DateFullValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					te130f01M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					te130f01M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					te130f01M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Te130f01Form formVO, StandardCheckManager checker)
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
			if (formVO.Idodenpyo_bango_from != null)
			{
				checker.DoCheck("Idodenpyo_bango_from", formVO.Idodenpyo_bango_from);
			}
			if (formVO.Idodenpyo_bango_to != null)
			{
				checker.DoCheck("Idodenpyo_bango_to", formVO.Idodenpyo_bango_to);
			}
			if (formVO.Siji_bango_from != null)
			{
				checker.DoCheck("Siji_bango_from", formVO.Siji_bango_from);
			}
			if (formVO.Siji_bango_to != null)
			{
				checker.DoCheck("Siji_bango_to", formVO.Siji_bango_to);
			}
			if (formVO.Jyuryokaisya_cd != null)
			{
				checker.DoCheck("Jyuryokaisya_cd", formVO.Jyuryokaisya_cd);
			}
			if (formVO.Nyukakaisya_nm != null)
			{
				checker.DoCheck("Nyukakaisya_nm", formVO.Nyukakaisya_nm);
			}
			if (formVO.Jyuryoten_cd != null)
			{
				checker.DoCheck("Jyuryoten_cd", formVO.Jyuryoten_cd);
			}
			if (formVO.Juryoten_nm != null)
			{
				checker.DoCheck("Juryoten_nm", formVO.Juryoten_nm);
			}
			if (formVO.Jyuryo_ymd_from != null)
			{
				checker.DoCheck("Jyuryo_ymd_from", formVO.Jyuryo_ymd_from);
			}
			if (formVO.Jyuryo_ymd_to != null)
			{
				checker.DoCheck("Jyuryo_ymd_to", formVO.Jyuryo_ymd_to);
			}
			if (formVO.Syukkakaisya_cd != null)
			{
				checker.DoCheck("Syukkakaisya_cd", formVO.Syukkakaisya_cd);
			}
			if (formVO.Syukkakaisya_nm != null)
			{
				checker.DoCheck("Syukkakaisya_nm", formVO.Syukkakaisya_nm);
			}
			if (formVO.Syukkaten_cd != null)
			{
				checker.DoCheck("Syukkaten_cd", formVO.Syukkaten_cd);
			}
			if (formVO.Syukkatenpo_nm != null)
			{
				checker.DoCheck("Syukkatenpo_nm", formVO.Syukkatenpo_nm);
			}
			if (formVO.Syukka_ymd_from != null)
			{
				checker.DoCheck("Syukka_ymd_from", formVO.Syukka_ymd_from);
			}
			if (formVO.Syukka_ymd_to != null)
			{
				checker.DoCheck("Syukka_ymd_to", formVO.Syukka_ymd_to);
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
		public static void ValidateM1InputValue(Te130f01Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Te130f01M1Form te130f01M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, te130f01M1Form, i, m1List);
				if (te130f01M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", te130f01M1Form.M1rowno, i, m1List);
				}
				if (te130f01M1Form.M1syukkakaisya_cd != null)
				{
					checker.DoCheck("M1syukkakaisya_cd", te130f01M1Form.M1syukkakaisya_cd, i, m1List);
				}
				if (te130f01M1Form.M1syukkaten_cd != null)
				{
					checker.DoCheck("M1syukkaten_cd", te130f01M1Form.M1syukkaten_cd, i, m1List);
				}
				if (te130f01M1Form.M1syukkatenpo_nm != null)
				{
					checker.DoCheck("M1syukkatenpo_nm", te130f01M1Form.M1syukkatenpo_nm, i, m1List);
				}
				if (te130f01M1Form.M1jyuryokaisya_cd != null)
				{
					checker.DoCheck("M1jyuryokaisya_cd", te130f01M1Form.M1jyuryokaisya_cd, i, m1List);
				}
				if (te130f01M1Form.M1jyuryoten_cd != null)
				{
					checker.DoCheck("M1jyuryoten_cd", te130f01M1Form.M1jyuryoten_cd, i, m1List);
				}
				if (te130f01M1Form.M1juryoten_nm != null)
				{
					checker.DoCheck("M1juryoten_nm", te130f01M1Form.M1juryoten_nm, i, m1List);
				}
				if (te130f01M1Form.M1idodenpyo_bango != null)
				{
					checker.DoCheck("M1idodenpyo_bango", te130f01M1Form.M1idodenpyo_bango, i, m1List);
				}
				if (te130f01M1Form.M1siji_bango != null)
				{
					checker.DoCheck("M1siji_bango", te130f01M1Form.M1siji_bango, i, m1List);
				}
				if (te130f01M1Form.M1syukka_ymd != null)
				{
					checker.DoCheck("M1syukka_ymd", te130f01M1Form.M1syukka_ymd, i, m1List);
				}
				if (te130f01M1Form.M1jyuryo_ymd != null)
				{
					checker.DoCheck("M1jyuryo_ymd", te130f01M1Form.M1jyuryo_ymd, i, m1List);
				}
				if (te130f01M1Form.M1nyukayotei_su != null)
				{
					checker.DoCheck("M1nyukayotei_su", te130f01M1Form.M1nyukayotei_su, i, m1List);
				}
				if (te130f01M1Form.M1nyukajisseki_su != null)
				{
					checker.DoCheck("M1nyukajisseki_su", te130f01M1Form.M1nyukajisseki_su, i, m1List);
				}
				if (te130f01M1Form.M1kyakucyu != null)
				{
					checker.DoCheck("M1kyakucyu", te130f01M1Form.M1kyakucyu, i, m1List);
				}
				if (te130f01M1Form.M1syorinm != null)
				{
					checker.DoCheck("M1syorinm", te130f01M1Form.M1syorinm, i, m1List);
				}
				if (te130f01M1Form.M1syori_ymd != null)
				{
					checker.DoCheck("M1syori_ymd", te130f01M1Form.M1syori_ymd, i, m1List);
				}
				if (te130f01M1Form.M1syori_tm != null)
				{
					checker.DoCheck("M1syori_tm", te130f01M1Form.M1syori_tm, i, m1List);
				}
				if (te130f01M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", te130f01M1Form.M1selectorcheckbox, i, m1List);
				}
				if (te130f01M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", te130f01M1Form.M1entersyoriflg, i, m1List);
				}
				if (te130f01M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", te130f01M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Te130f01Form formVO, StandardCodeCheckManager checker)
		{
			checker.DoCheck("Btnheadtenpocd", formVO);
			checker.DoCheck("Btntenpocd", formVO);
			checker.DoCheck("Btnkaisha_cd", formVO);
			checker.DoCheck("Btnsyukkatencd", formVO);
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Te130f01Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

