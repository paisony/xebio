using com.xebio.bo.Tj040p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Tj040p01.Request
{
  /// <summary>
  /// Tj040f01RequestHelper の概要の説明です。
  /// </summary>
  public static class Tj040f01RequestHelper
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
			Tj040f01Form formVO = (Tj040f01Form)pageContext.GetFormVO();

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
			paramCol["Face_no_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Face_no_from"]);
			paramCol["Face_no_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Face_no_to"]);
			paramCol["Tana_dan_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tana_dan_from"]);
			paramCol["Tana_dan_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tana_dan_to"]);
			paramCol["Tenpo_gyosya_kb"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tenpo_gyosya_kb"]);
			paramCol["Nyuryoku_ymd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Nyuryoku_ymd_from"]);
			paramCol["Nyuryoku_ymd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Nyuryoku_ymd_to"]);
			paramCol["Sosin_ymd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Sosin_ymd_from"]);
			paramCol["Sosin_ymd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Sosin_ymd_to"]);
			paramCol["Nyuryokutan_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Nyuryokutan_cd"]);
			paramCol["Nyuryokutan_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Nyuryokutan_nm"]);
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
			paramCol["Sosin_jyotai"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Sosin_jyotai"]);
			paramCol["Teisei_flg"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Teisei_flg"]);
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
				paramCol["M1tana_dan"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tana_dan"]);
				paramCol["M1kai_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1kai_su"]);
				paramCol["M1tensutanaorosinyuryoku_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tensutanaorosinyuryoku_su"]);
				paramCol["M1tensutanaorositeisei_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tensutanaorositeisei_su"]);
				paramCol["M1tensutanaorosigokei_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tensutanaorosigokei_su"]);
				paramCol["M1scan_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1scan_su"]);
				paramCol["M1teisei_suryo"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1teisei_suryo"]);
				paramCol["M1gokei_suryo"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1gokei_suryo"]);
				paramCol["M1nyuryokutan_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1nyuryokutan_nm"]);
				paramCol["M1teiseitan_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1teiseitan_nm"]);
				paramCol["M1riyucomment_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1riyucomment_nm"]);
				paramCol["M1nyuryoku_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1nyuryoku_ymd"]);
				paramCol["M1sosin_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1sosin_ymd"]);
				paramCol["M1gyosya"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1gyosya"]);
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
			Tj040f01Form formVO = (Tj040f01Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Modeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Modeno"].RequestValue, formInfo["Modeno"]);
			paramCol["Stkmodeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Stkmodeno"].RequestValue, formInfo["Stkmodeno"]);
			paramCol["Face_no_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Face_no_from"].RequestValue, formInfo["Face_no_from"]);
			paramCol["Face_no_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Face_no_to"].RequestValue, formInfo["Face_no_to"]);
			paramCol["Tana_dan_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tana_dan_from"].RequestValue, formInfo["Tana_dan_from"]);
			paramCol["Tana_dan_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tana_dan_to"].RequestValue, formInfo["Tana_dan_to"]);
			paramCol["Tenpo_gyosya_kb"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tenpo_gyosya_kb"].RequestValue, formInfo["Tenpo_gyosya_kb"]);
			paramCol["Nyuryoku_ymd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Nyuryoku_ymd_from"].RequestValue, formInfo["Nyuryoku_ymd_from"]);
			paramCol["Nyuryoku_ymd_from"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Nyuryoku_ymd_from"].RequestValue, formInfo["Nyuryoku_ymd_from"]);
			paramCol["Nyuryoku_ymd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Nyuryoku_ymd_to"].RequestValue, formInfo["Nyuryoku_ymd_to"]);
			paramCol["Nyuryoku_ymd_to"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Nyuryoku_ymd_to"].RequestValue, formInfo["Nyuryoku_ymd_to"]);
			paramCol["Sosin_ymd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Sosin_ymd_from"].RequestValue, formInfo["Sosin_ymd_from"]);
			paramCol["Sosin_ymd_from"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Sosin_ymd_from"].RequestValue, formInfo["Sosin_ymd_from"]);
			paramCol["Sosin_ymd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Sosin_ymd_to"].RequestValue, formInfo["Sosin_ymd_to"]);
			paramCol["Sosin_ymd_to"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Sosin_ymd_to"].RequestValue, formInfo["Sosin_ymd_to"]);
			paramCol["Nyuryokutan_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Nyuryokutan_cd"].RequestValue, formInfo["Nyuryokutan_cd"]);
			paramCol["Nyuryokutan_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Nyuryokutan_nm"].RequestValue, formInfo["Nyuryokutan_nm"]);
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
			paramCol["Sosin_jyotai"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Sosin_jyotai"].RequestValue, formInfo["Sosin_jyotai"]);
			paramCol["Teisei_flg"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Teisei_flg"].RequestValue, formInfo["Teisei_flg"]);
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
				paramCol["M1tana_dan"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tana_dan"][i].RequestValue, formInfo["M1tana_dan"]);
				paramCol["M1kai_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1kai_su"][i].RequestValue, formInfo["M1kai_su"]);
				paramCol["M1tensutanaorosinyuryoku_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tensutanaorosinyuryoku_su"][i].RequestValue, formInfo["M1tensutanaorosinyuryoku_su"]);
				paramCol["M1tensutanaorositeisei_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tensutanaorositeisei_su"][i].RequestValue, formInfo["M1tensutanaorositeisei_su"]);
				paramCol["M1tensutanaorosigokei_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tensutanaorosigokei_su"][i].RequestValue, formInfo["M1tensutanaorosigokei_su"]);
				paramCol["M1scan_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1scan_su"][i].RequestValue, formInfo["M1scan_su"]);
				paramCol["M1teisei_suryo"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1teisei_suryo"][i].RequestValue, formInfo["M1teisei_suryo"]);
				paramCol["M1gokei_suryo"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1gokei_suryo"][i].RequestValue, formInfo["M1gokei_suryo"]);
				paramCol["M1nyuryokutan_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1nyuryokutan_nm"][i].RequestValue, formInfo["M1nyuryokutan_nm"]);
				paramCol["M1teiseitan_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1teiseitan_nm"][i].RequestValue, formInfo["M1teiseitan_nm"]);
				paramCol["M1riyucomment_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1riyucomment_nm"][i].RequestValue, formInfo["M1riyucomment_nm"]);
				paramCol["M1nyuryoku_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1nyuryoku_ymd"][i].RequestValue, formInfo["M1nyuryoku_ymd"]);
				paramCol["M1nyuryoku_ymd"][i].DateFullValue = RequestParameterUtil.GetDateFullValue(
					paramCol["M1nyuryoku_ymd"][i].RequestValue, formInfo["M1nyuryoku_ymd"]);
				paramCol["M1sosin_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1sosin_ymd"][i].RequestValue, formInfo["M1sosin_ymd"]);
				paramCol["M1sosin_ymd"][i].DateFullValue = RequestParameterUtil.GetDateFullValue(
					paramCol["M1sosin_ymd"][i].RequestValue, formInfo["M1sosin_ymd"]);
				paramCol["M1gyosya"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1gyosya"][i].RequestValue, formInfo["M1gyosya"]);
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
			Tj040f01Form formVO = (Tj040f01Form)pageContext.GetFormVO();

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
			if (paramCol["Face_no_from"].UnformatValue != null)
			{
				formVO.Face_no_from = paramCol["Face_no_from"].UnformatValue;
			}
			if (paramCol["Face_no_to"].UnformatValue != null)
			{
				formVO.Face_no_to = paramCol["Face_no_to"].UnformatValue;
			}
			if (paramCol["Tana_dan_from"].UnformatValue != null)
			{
				formVO.Tana_dan_from = paramCol["Tana_dan_from"].UnformatValue;
			}
			if (paramCol["Tana_dan_to"].UnformatValue != null)
			{
				formVO.Tana_dan_to = paramCol["Tana_dan_to"].UnformatValue;
			}
			if (paramCol["Tenpo_gyosya_kb"].UnformatValue != null)
			{
				formVO.Tenpo_gyosya_kb = paramCol["Tenpo_gyosya_kb"].UnformatValue;
			}
			if (paramCol["Nyuryoku_ymd_from"].DateFullValue != null)
			{
				formVO.Nyuryoku_ymd_from = paramCol["Nyuryoku_ymd_from"].DateFullValue;
			}
			if (paramCol["Nyuryoku_ymd_to"].DateFullValue != null)
			{
				formVO.Nyuryoku_ymd_to = paramCol["Nyuryoku_ymd_to"].DateFullValue;
			}
			if (paramCol["Sosin_ymd_from"].DateFullValue != null)
			{
				formVO.Sosin_ymd_from = paramCol["Sosin_ymd_from"].DateFullValue;
			}
			if (paramCol["Sosin_ymd_to"].DateFullValue != null)
			{
				formVO.Sosin_ymd_to = paramCol["Sosin_ymd_to"].DateFullValue;
			}
			if (paramCol["Nyuryokutan_cd"].UnformatValue != null)
			{
				formVO.Nyuryokutan_cd = paramCol["Nyuryokutan_cd"].UnformatValue;
			}
			if (paramCol["Nyuryokutan_nm"].UnformatValue != null)
			{
				formVO.Nyuryokutan_nm = paramCol["Nyuryokutan_nm"].UnformatValue;
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
			if (paramCol["Sosin_jyotai"].UnformatValue != null)
			{
				formVO.Sosin_jyotai = paramCol["Sosin_jyotai"].UnformatValue;
			}
			if (paramCol["Teisei_flg"].UnformatValue != null)
			{
				formVO.Teisei_flg = paramCol["Teisei_flg"].UnformatValue;
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
				Tj040f01M1Form tj040f01M1Form = (Tj040f01M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					tj040f01M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1tana_dan"][i].UnformatValue != null)
				{
					tj040f01M1Form.M1tana_dan = paramCol["M1tana_dan"][i].UnformatValue;
				}
				if (paramCol["M1kai_su"][i].UnformatValue != null)
				{
					tj040f01M1Form.M1kai_su = paramCol["M1kai_su"][i].UnformatValue;
				}
				if (paramCol["M1tensutanaorosinyuryoku_su"][i].UnformatValue != null)
				{
					tj040f01M1Form.M1tensutanaorosinyuryoku_su = paramCol["M1tensutanaorosinyuryoku_su"][i].UnformatValue;
				}
				if (paramCol["M1tensutanaorositeisei_su"][i].UnformatValue != null)
				{
					tj040f01M1Form.M1tensutanaorositeisei_su = paramCol["M1tensutanaorositeisei_su"][i].UnformatValue;
				}
				if (paramCol["M1tensutanaorosigokei_su"][i].UnformatValue != null)
				{
					tj040f01M1Form.M1tensutanaorosigokei_su = paramCol["M1tensutanaorosigokei_su"][i].UnformatValue;
				}
				if (paramCol["M1scan_su"][i].UnformatValue != null)
				{
					tj040f01M1Form.M1scan_su = paramCol["M1scan_su"][i].UnformatValue;
				}
				if (paramCol["M1teisei_suryo"][i].UnformatValue != null)
				{
					tj040f01M1Form.M1teisei_suryo = paramCol["M1teisei_suryo"][i].UnformatValue;
				}
				if (paramCol["M1gokei_suryo"][i].UnformatValue != null)
				{
					tj040f01M1Form.M1gokei_suryo = paramCol["M1gokei_suryo"][i].UnformatValue;
				}
				if (paramCol["M1nyuryokutan_nm"][i].UnformatValue != null)
				{
					tj040f01M1Form.M1nyuryokutan_nm = paramCol["M1nyuryokutan_nm"][i].UnformatValue;
				}
				if (paramCol["M1teiseitan_nm"][i].UnformatValue != null)
				{
					tj040f01M1Form.M1teiseitan_nm = paramCol["M1teiseitan_nm"][i].UnformatValue;
				}
				if (paramCol["M1riyucomment_nm"][i].UnformatValue != null)
				{
					tj040f01M1Form.M1riyucomment_nm = paramCol["M1riyucomment_nm"][i].UnformatValue;
				}
				if (paramCol["M1nyuryoku_ymd"][i].DateFullValue != null)
				{
					tj040f01M1Form.M1nyuryoku_ymd = paramCol["M1nyuryoku_ymd"][i].DateFullValue;
				}
				if (paramCol["M1sosin_ymd"][i].DateFullValue != null)
				{
					tj040f01M1Form.M1sosin_ymd = paramCol["M1sosin_ymd"][i].DateFullValue;
				}
				if (paramCol["M1gyosya"][i].UnformatValue != null)
				{
					tj040f01M1Form.M1gyosya = paramCol["M1gyosya"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					tj040f01M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					tj040f01M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					tj040f01M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Tj040f01Form formVO, StandardCheckManager checker)
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
			if (formVO.Face_no_from != null)
			{
				checker.DoCheck("Face_no_from", formVO.Face_no_from);
			}
			if (formVO.Face_no_to != null)
			{
				checker.DoCheck("Face_no_to", formVO.Face_no_to);
			}
			if (formVO.Tana_dan_from != null)
			{
				checker.DoCheck("Tana_dan_from", formVO.Tana_dan_from);
			}
			if (formVO.Tana_dan_to != null)
			{
				checker.DoCheck("Tana_dan_to", formVO.Tana_dan_to);
			}
			if (formVO.Tenpo_gyosya_kb != null)
			{
				checker.DoCheck("Tenpo_gyosya_kb", formVO.Tenpo_gyosya_kb);
			}
			if (formVO.Nyuryoku_ymd_from != null)
			{
				checker.DoCheck("Nyuryoku_ymd_from", formVO.Nyuryoku_ymd_from);
			}
			if (formVO.Nyuryoku_ymd_to != null)
			{
				checker.DoCheck("Nyuryoku_ymd_to", formVO.Nyuryoku_ymd_to);
			}
			if (formVO.Sosin_ymd_from != null)
			{
				checker.DoCheck("Sosin_ymd_from", formVO.Sosin_ymd_from);
			}
			if (formVO.Sosin_ymd_to != null)
			{
				checker.DoCheck("Sosin_ymd_to", formVO.Sosin_ymd_to);
			}
			if (formVO.Nyuryokutan_cd != null)
			{
				checker.DoCheck("Nyuryokutan_cd", formVO.Nyuryokutan_cd);
			}
			if (formVO.Nyuryokutan_nm != null)
			{
				checker.DoCheck("Nyuryokutan_nm", formVO.Nyuryokutan_nm);
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
			if (formVO.Sosin_jyotai != null)
			{
				checker.DoCheck("Sosin_jyotai", formVO.Sosin_jyotai);
			}
			if (formVO.Teisei_flg != null)
			{
				checker.DoCheck("Teisei_flg", formVO.Teisei_flg);
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
		public static void ValidateM1InputValue(Tj040f01Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Tj040f01M1Form tj040f01M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, tj040f01M1Form, i, m1List);
				if (tj040f01M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", tj040f01M1Form.M1rowno, i, m1List);
				}
				if (tj040f01M1Form.M1tana_dan != null)
				{
					checker.DoCheck("M1tana_dan", tj040f01M1Form.M1tana_dan, i, m1List);
				}
				if (tj040f01M1Form.M1kai_su != null)
				{
					checker.DoCheck("M1kai_su", tj040f01M1Form.M1kai_su, i, m1List);
				}
				if (tj040f01M1Form.M1tensutanaorosinyuryoku_su != null)
				{
					checker.DoCheck("M1tensutanaorosinyuryoku_su", tj040f01M1Form.M1tensutanaorosinyuryoku_su, i, m1List);
				}
				if (tj040f01M1Form.M1tensutanaorositeisei_su != null)
				{
					checker.DoCheck("M1tensutanaorositeisei_su", tj040f01M1Form.M1tensutanaorositeisei_su, i, m1List);
				}
				if (tj040f01M1Form.M1tensutanaorosigokei_su != null)
				{
					checker.DoCheck("M1tensutanaorosigokei_su", tj040f01M1Form.M1tensutanaorosigokei_su, i, m1List);
				}
				if (tj040f01M1Form.M1scan_su != null)
				{
					checker.DoCheck("M1scan_su", tj040f01M1Form.M1scan_su, i, m1List);
				}
				if (tj040f01M1Form.M1teisei_suryo != null)
				{
					checker.DoCheck("M1teisei_suryo", tj040f01M1Form.M1teisei_suryo, i, m1List);
				}
				if (tj040f01M1Form.M1gokei_suryo != null)
				{
					checker.DoCheck("M1gokei_suryo", tj040f01M1Form.M1gokei_suryo, i, m1List);
				}
				if (tj040f01M1Form.M1nyuryokutan_nm != null)
				{
					checker.DoCheck("M1nyuryokutan_nm", tj040f01M1Form.M1nyuryokutan_nm, i, m1List);
				}
				if (tj040f01M1Form.M1teiseitan_nm != null)
				{
					checker.DoCheck("M1teiseitan_nm", tj040f01M1Form.M1teiseitan_nm, i, m1List);
				}
				if (tj040f01M1Form.M1riyucomment_nm != null)
				{
					checker.DoCheck("M1riyucomment_nm", tj040f01M1Form.M1riyucomment_nm, i, m1List);
				}
				if (tj040f01M1Form.M1nyuryoku_ymd != null)
				{
					checker.DoCheck("M1nyuryoku_ymd", tj040f01M1Form.M1nyuryoku_ymd, i, m1List);
				}
				if (tj040f01M1Form.M1sosin_ymd != null)
				{
					checker.DoCheck("M1sosin_ymd", tj040f01M1Form.M1sosin_ymd, i, m1List);
				}
				if (tj040f01M1Form.M1gyosya != null)
				{
					checker.DoCheck("M1gyosya", tj040f01M1Form.M1gyosya, i, m1List);
				}
				if (tj040f01M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", tj040f01M1Form.M1selectorcheckbox, i, m1List);
				}
				if (tj040f01M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", tj040f01M1Form.M1entersyoriflg, i, m1List);
				}
				if (tj040f01M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", tj040f01M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Tj040f01Form formVO, StandardCodeCheckManager checker)
		{
			checker.DoCheck("Btnheadtenpocd", formVO);
			checker.DoCheck("Btntanto_cd", formVO);
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Tj040f01Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

