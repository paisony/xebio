using com.xebio.bo.Ta070p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Ta070p01.Request
{
  /// <summary>
  /// Ta070f01RequestHelper の概要の説明です。
  /// </summary>
  public static class Ta070f01RequestHelper
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
			Ta070f01Form formVO = (Ta070f01Form)pageContext.GetFormVO();

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
			paramCol["Bumon_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_cd"]);
			paramCol["Bumon_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_nm"]);
			paramCol["Hinsyu_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hinsyu_cd"]);
			paramCol["Hinsyu_ryaku_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hinsyu_ryaku_nm"]);
			paramCol["Burando_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Burando_cd"]);
			paramCol["Burando_nm_bo1"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Burando_nm_bo1"]);
			paramCol["Kikan"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Kikan"]);
			paramCol["Jido_kbn"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Jido_kbn"]);
			paramCol["Saisin_data"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Saisin_data"]);
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
				paramCol["M1bumon_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1bumon_cd"]);
				paramCol["M1bumonkana_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1bumonkana_nm"]);
				paramCol["M1hinsyu_ryaku_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hinsyu_ryaku_nm"]);
				paramCol["M1burando_nm_bo1"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1burando_nm_bo1"]);
				paramCol["M1maker_hbn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1maker_hbn"]);
				paramCol["M1jisya_hbn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1jisya_hbn"]);
				paramCol["M1syohin_zokusei"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1syohin_zokusei"]);
				paramCol["M1iro_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1iro_nm"]);
				paramCol["M1size_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1size_nm"]);
				paramCol["M1scan_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1scan_cd"]);
				paramCol["M1syonmk"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1syonmk"]);
				paramCol["M1kaisi_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1kaisi_ymd"]);
				paramCol["M1syuryo_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1syuryo_ymd"]);
				paramCol["M1hattyuptn_kbn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hattyuptn_kbn"]);
				paramCol["M1jido_kbnnm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1jido_kbnnm"]);
				paramCol["M1uriage_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1uriage_su"]);
				paramCol["M1genzaisettei_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1genzaisettei_su"]);
				paramCol["M1lot_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1lot_su"]);
				paramCol["M1irairiyu_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1irairiyu_cd"]);
				paramCol["M1henko_irai_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1henko_irai_su"]);
				paramCol["M1hanbaiin_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hanbaiin_nm"]);
				paramCol["M1add_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1add_ymd"]);
				paramCol["M1honbutenpokbnnm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1honbutenpokbnnm"]);
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
			Ta070f01Form formVO = (Ta070f01Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Modeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Modeno"].RequestValue, formInfo["Modeno"]);
			paramCol["Stkmodeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Stkmodeno"].RequestValue, formInfo["Stkmodeno"]);
			paramCol["Bumon_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_cd"].RequestValue, formInfo["Bumon_cd"]);
			paramCol["Bumon_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_nm"].RequestValue, formInfo["Bumon_nm"]);
			paramCol["Hinsyu_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hinsyu_cd"].RequestValue, formInfo["Hinsyu_cd"]);
			paramCol["Hinsyu_ryaku_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hinsyu_ryaku_nm"].RequestValue, formInfo["Hinsyu_ryaku_nm"]);
			paramCol["Burando_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Burando_cd"].RequestValue, formInfo["Burando_cd"]);
			paramCol["Burando_nm_bo1"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Burando_nm_bo1"].RequestValue, formInfo["Burando_nm_bo1"]);
			paramCol["Kikan"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Kikan"].RequestValue, formInfo["Kikan"]);
			paramCol["Kikan"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Kikan"].RequestValue, formInfo["Kikan"]);
			paramCol["Jido_kbn"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Jido_kbn"].RequestValue, formInfo["Jido_kbn"]);
			paramCol["Saisin_data"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Saisin_data"].RequestValue, formInfo["Saisin_data"]);
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
				paramCol["M1bumon_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1bumon_cd"][i].RequestValue, formInfo["M1bumon_cd"]);
				paramCol["M1bumonkana_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1bumonkana_nm"][i].RequestValue, formInfo["M1bumonkana_nm"]);
				paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hinsyu_ryaku_nm"][i].RequestValue, formInfo["M1hinsyu_ryaku_nm"]);
				paramCol["M1burando_nm_bo1"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1burando_nm_bo1"][i].RequestValue, formInfo["M1burando_nm_bo1"]);
				paramCol["M1maker_hbn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1maker_hbn"][i].RequestValue, formInfo["M1maker_hbn"]);
				paramCol["M1jisya_hbn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1jisya_hbn"][i].RequestValue, formInfo["M1jisya_hbn"]);
				paramCol["M1syohin_zokusei"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1syohin_zokusei"][i].RequestValue, formInfo["M1syohin_zokusei"]);
				paramCol["M1iro_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1iro_nm"][i].RequestValue, formInfo["M1iro_nm"]);
				paramCol["M1size_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1size_nm"][i].RequestValue, formInfo["M1size_nm"]);
				paramCol["M1scan_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1scan_cd"][i].RequestValue, formInfo["M1scan_cd"]);
				paramCol["M1syonmk"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1syonmk"][i].RequestValue, formInfo["M1syonmk"]);
				paramCol["M1kaisi_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1kaisi_ymd"][i].RequestValue, formInfo["M1kaisi_ymd"]);
				paramCol["M1kaisi_ymd"][i].DateFullValue = RequestParameterUtil.GetDateFullValue(
					paramCol["M1kaisi_ymd"][i].RequestValue, formInfo["M1kaisi_ymd"]);
				paramCol["M1syuryo_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1syuryo_ymd"][i].RequestValue, formInfo["M1syuryo_ymd"]);
				paramCol["M1syuryo_ymd"][i].DateFullValue = RequestParameterUtil.GetDateFullValue(
					paramCol["M1syuryo_ymd"][i].RequestValue, formInfo["M1syuryo_ymd"]);
				paramCol["M1hattyuptn_kbn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hattyuptn_kbn"][i].RequestValue, formInfo["M1hattyuptn_kbn"]);
				paramCol["M1jido_kbnnm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1jido_kbnnm"][i].RequestValue, formInfo["M1jido_kbnnm"]);
				paramCol["M1uriage_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1uriage_su"][i].RequestValue, formInfo["M1uriage_su"]);
				paramCol["M1genzaisettei_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1genzaisettei_su"][i].RequestValue, formInfo["M1genzaisettei_su"]);
				paramCol["M1lot_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1lot_su"][i].RequestValue, formInfo["M1lot_su"]);
				paramCol["M1irairiyu_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1irairiyu_cd"][i].RequestValue, formInfo["M1irairiyu_cd"]);
				paramCol["M1henko_irai_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1henko_irai_su"][i].RequestValue, formInfo["M1henko_irai_su"]);
				paramCol["M1hanbaiin_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hanbaiin_nm"][i].RequestValue, formInfo["M1hanbaiin_nm"]);
				paramCol["M1add_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1add_ymd"][i].RequestValue, formInfo["M1add_ymd"]);
				paramCol["M1honbutenpokbnnm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1honbutenpokbnnm"][i].RequestValue, formInfo["M1honbutenpokbnnm"]);
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
			Ta070f01Form formVO = (Ta070f01Form)pageContext.GetFormVO();

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
			if (paramCol["Bumon_cd"].UnformatValue != null)
			{
				formVO.Bumon_cd = paramCol["Bumon_cd"].UnformatValue;
			}
			if (paramCol["Bumon_nm"].UnformatValue != null)
			{
				formVO.Bumon_nm = paramCol["Bumon_nm"].UnformatValue;
			}
			if (paramCol["Hinsyu_cd"].UnformatValue != null)
			{
				formVO.Hinsyu_cd = paramCol["Hinsyu_cd"].UnformatValue;
			}
			if (paramCol["Hinsyu_ryaku_nm"].UnformatValue != null)
			{
				formVO.Hinsyu_ryaku_nm = paramCol["Hinsyu_ryaku_nm"].UnformatValue;
			}
			if (paramCol["Burando_cd"].UnformatValue != null)
			{
				formVO.Burando_cd = paramCol["Burando_cd"].UnformatValue;
			}
			if (paramCol["Burando_nm_bo1"].UnformatValue != null)
			{
				formVO.Burando_nm_bo1 = paramCol["Burando_nm_bo1"].UnformatValue;
			}
			if (paramCol["Kikan"].DateFullValue != null)
			{
				formVO.Kikan = paramCol["Kikan"].DateFullValue;
			}
			if (paramCol["Jido_kbn"].UnformatValue != null)
			{
				formVO.Jido_kbn = paramCol["Jido_kbn"].UnformatValue;
			}
			if (paramCol["Saisin_data"].UnformatValue != null)
			{
				formVO.Saisin_data = paramCol["Saisin_data"].UnformatValue;
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
				Ta070f01M1Form ta070f01M1Form = (Ta070f01M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					ta070f01M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1bumon_cd"][i].UnformatValue != null)
				{
					ta070f01M1Form.M1bumon_cd = paramCol["M1bumon_cd"][i].UnformatValue;
				}
				if (paramCol["M1bumonkana_nm"][i].UnformatValue != null)
				{
					ta070f01M1Form.M1bumonkana_nm = paramCol["M1bumonkana_nm"][i].UnformatValue;
				}
				if (paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue != null)
				{
					ta070f01M1Form.M1hinsyu_ryaku_nm = paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue;
				}
				if (paramCol["M1burando_nm_bo1"][i].UnformatValue != null)
				{
					ta070f01M1Form.M1burando_nm_bo1 = paramCol["M1burando_nm_bo1"][i].UnformatValue;
				}
				if (paramCol["M1maker_hbn"][i].UnformatValue != null)
				{
					ta070f01M1Form.M1maker_hbn = paramCol["M1maker_hbn"][i].UnformatValue;
				}
				if (paramCol["M1jisya_hbn"][i].UnformatValue != null)
				{
					ta070f01M1Form.M1jisya_hbn = paramCol["M1jisya_hbn"][i].UnformatValue;
				}
				if (paramCol["M1syohin_zokusei"][i].UnformatValue != null)
				{
					ta070f01M1Form.M1syohin_zokusei = paramCol["M1syohin_zokusei"][i].UnformatValue;
				}
				if (paramCol["M1iro_nm"][i].UnformatValue != null)
				{
					ta070f01M1Form.M1iro_nm = paramCol["M1iro_nm"][i].UnformatValue;
				}
				if (paramCol["M1size_nm"][i].UnformatValue != null)
				{
					ta070f01M1Form.M1size_nm = paramCol["M1size_nm"][i].UnformatValue;
				}
				if (paramCol["M1scan_cd"][i].UnformatValue != null)
				{
					ta070f01M1Form.M1scan_cd = paramCol["M1scan_cd"][i].UnformatValue;
				}
				if (paramCol["M1syonmk"][i].UnformatValue != null)
				{
					ta070f01M1Form.M1syonmk = paramCol["M1syonmk"][i].UnformatValue;
				}
				if (paramCol["M1kaisi_ymd"][i].DateFullValue != null)
				{
					ta070f01M1Form.M1kaisi_ymd = paramCol["M1kaisi_ymd"][i].DateFullValue;
				}
				if (paramCol["M1syuryo_ymd"][i].DateFullValue != null)
				{
					ta070f01M1Form.M1syuryo_ymd = paramCol["M1syuryo_ymd"][i].DateFullValue;
				}
				if (paramCol["M1hattyuptn_kbn"][i].UnformatValue != null)
				{
					ta070f01M1Form.M1hattyuptn_kbn = paramCol["M1hattyuptn_kbn"][i].UnformatValue;
				}
				if (paramCol["M1jido_kbnnm"][i].UnformatValue != null)
				{
					ta070f01M1Form.M1jido_kbnnm = paramCol["M1jido_kbnnm"][i].UnformatValue;
				}
				if (paramCol["M1uriage_su"][i].UnformatValue != null)
				{
					ta070f01M1Form.M1uriage_su = paramCol["M1uriage_su"][i].UnformatValue;
				}
				if (paramCol["M1genzaisettei_su"][i].UnformatValue != null)
				{
					ta070f01M1Form.M1genzaisettei_su = paramCol["M1genzaisettei_su"][i].UnformatValue;
				}
				if (paramCol["M1lot_su"][i].UnformatValue != null)
				{
					ta070f01M1Form.M1lot_su = paramCol["M1lot_su"][i].UnformatValue;
				}
				if (paramCol["M1irairiyu_cd"][i].UnformatValue != null)
				{
					ta070f01M1Form.M1irairiyu_cd = paramCol["M1irairiyu_cd"][i].UnformatValue;
				}
				if (paramCol["M1henko_irai_su"][i].UnformatValue != null)
				{
					ta070f01M1Form.M1henko_irai_su = paramCol["M1henko_irai_su"][i].UnformatValue;
				}
				if (paramCol["M1hanbaiin_nm"][i].UnformatValue != null)
				{
					ta070f01M1Form.M1hanbaiin_nm = paramCol["M1hanbaiin_nm"][i].UnformatValue;
				}
				if (paramCol["M1add_ymd"][i].UnformatValue != null)
				{
					ta070f01M1Form.M1add_ymd = paramCol["M1add_ymd"][i].UnformatValue;
				}
				if (paramCol["M1honbutenpokbnnm"][i].UnformatValue != null)
				{
					ta070f01M1Form.M1honbutenpokbnnm = paramCol["M1honbutenpokbnnm"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					ta070f01M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					ta070f01M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					ta070f01M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Ta070f01Form formVO, StandardCheckManager checker)
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
			if (formVO.Bumon_cd != null)
			{
				checker.DoCheck("Bumon_cd", formVO.Bumon_cd);
			}
			if (formVO.Bumon_nm != null)
			{
				checker.DoCheck("Bumon_nm", formVO.Bumon_nm);
			}
			if (formVO.Hinsyu_cd != null)
			{
				checker.DoCheck("Hinsyu_cd", formVO.Hinsyu_cd);
			}
			if (formVO.Hinsyu_ryaku_nm != null)
			{
				checker.DoCheck("Hinsyu_ryaku_nm", formVO.Hinsyu_ryaku_nm);
			}
			if (formVO.Burando_cd != null)
			{
				checker.DoCheck("Burando_cd", formVO.Burando_cd);
			}
			if (formVO.Burando_nm_bo1 != null)
			{
				checker.DoCheck("Burando_nm_bo1", formVO.Burando_nm_bo1);
			}
			if (formVO.Kikan != null)
			{
				checker.DoCheck("Kikan", formVO.Kikan);
			}
			if (formVO.Jido_kbn != null)
			{
				checker.DoCheck("Jido_kbn", formVO.Jido_kbn);
			}
			if (formVO.Saisin_data != null)
			{
				checker.DoCheck("Saisin_data", formVO.Saisin_data);
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
		public static void ValidateM1InputValue(Ta070f01Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Ta070f01M1Form ta070f01M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, ta070f01M1Form, i, m1List);
				if (ta070f01M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", ta070f01M1Form.M1rowno, i, m1List);
				}
				if (ta070f01M1Form.M1bumon_cd != null)
				{
					checker.DoCheck("M1bumon_cd", ta070f01M1Form.M1bumon_cd, i, m1List);
				}
				if (ta070f01M1Form.M1bumonkana_nm != null)
				{
					checker.DoCheck("M1bumonkana_nm", ta070f01M1Form.M1bumonkana_nm, i, m1List);
				}
				if (ta070f01M1Form.M1hinsyu_ryaku_nm != null)
				{
					checker.DoCheck("M1hinsyu_ryaku_nm", ta070f01M1Form.M1hinsyu_ryaku_nm, i, m1List);
				}
				if (ta070f01M1Form.M1burando_nm_bo1 != null)
				{
					checker.DoCheck("M1burando_nm_bo1", ta070f01M1Form.M1burando_nm_bo1, i, m1List);
				}
				if (ta070f01M1Form.M1maker_hbn != null)
				{
					checker.DoCheck("M1maker_hbn", ta070f01M1Form.M1maker_hbn, i, m1List);
				}
				if (ta070f01M1Form.M1jisya_hbn != null)
				{
					checker.DoCheck("M1jisya_hbn", ta070f01M1Form.M1jisya_hbn, i, m1List);
				}
				if (ta070f01M1Form.M1syohin_zokusei != null)
				{
					checker.DoCheck("M1syohin_zokusei", ta070f01M1Form.M1syohin_zokusei, i, m1List);
				}
				if (ta070f01M1Form.M1iro_nm != null)
				{
					checker.DoCheck("M1iro_nm", ta070f01M1Form.M1iro_nm, i, m1List);
				}
				if (ta070f01M1Form.M1size_nm != null)
				{
					checker.DoCheck("M1size_nm", ta070f01M1Form.M1size_nm, i, m1List);
				}
				if (ta070f01M1Form.M1scan_cd != null)
				{
					checker.DoCheck("M1scan_cd", ta070f01M1Form.M1scan_cd, i, m1List);
				}
				if (ta070f01M1Form.M1syonmk != null)
				{
					checker.DoCheck("M1syonmk", ta070f01M1Form.M1syonmk, i, m1List);
				}
				if (ta070f01M1Form.M1kaisi_ymd != null)
				{
					checker.DoCheck("M1kaisi_ymd", ta070f01M1Form.M1kaisi_ymd, i, m1List);
				}
				if (ta070f01M1Form.M1syuryo_ymd != null)
				{
					checker.DoCheck("M1syuryo_ymd", ta070f01M1Form.M1syuryo_ymd, i, m1List);
				}
				if (ta070f01M1Form.M1hattyuptn_kbn != null)
				{
					checker.DoCheck("M1hattyuptn_kbn", ta070f01M1Form.M1hattyuptn_kbn, i, m1List);
				}
				if (ta070f01M1Form.M1jido_kbnnm != null)
				{
					checker.DoCheck("M1jido_kbnnm", ta070f01M1Form.M1jido_kbnnm, i, m1List);
				}
				if (ta070f01M1Form.M1uriage_su != null)
				{
					checker.DoCheck("M1uriage_su", ta070f01M1Form.M1uriage_su, i, m1List);
				}
				if (ta070f01M1Form.M1genzaisettei_su != null)
				{
					checker.DoCheck("M1genzaisettei_su", ta070f01M1Form.M1genzaisettei_su, i, m1List);
				}
				if (ta070f01M1Form.M1lot_su != null)
				{
					checker.DoCheck("M1lot_su", ta070f01M1Form.M1lot_su, i, m1List);
				}
				if (ta070f01M1Form.M1irairiyu_cd != null)
				{
					checker.DoCheck("M1irairiyu_cd", ta070f01M1Form.M1irairiyu_cd, i, m1List);
				}
				if (ta070f01M1Form.M1henko_irai_su != null)
				{
					checker.DoCheck("M1henko_irai_su", ta070f01M1Form.M1henko_irai_su, i, m1List);
				}
				if (ta070f01M1Form.M1hanbaiin_nm != null)
				{
					checker.DoCheck("M1hanbaiin_nm", ta070f01M1Form.M1hanbaiin_nm, i, m1List);
				}
				if (ta070f01M1Form.M1add_ymd != null)
				{
					checker.DoCheck("M1add_ymd", ta070f01M1Form.M1add_ymd, i, m1List);
				}
				if (ta070f01M1Form.M1honbutenpokbnnm != null)
				{
					checker.DoCheck("M1honbutenpokbnnm", ta070f01M1Form.M1honbutenpokbnnm, i, m1List);
				}
				if (ta070f01M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", ta070f01M1Form.M1selectorcheckbox, i, m1List);
				}
				if (ta070f01M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", ta070f01M1Form.M1entersyoriflg, i, m1List);
				}
				if (ta070f01M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", ta070f01M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Ta070f01Form formVO, StandardCodeCheckManager checker)
		{
			checker.DoCheck("Btnheadtenpocd", formVO);
			checker.DoCheck("Btnbumon_cd", formVO);
			checker.DoCheck("Btnhinsyu_cd", formVO);
			checker.DoCheck("Btnburando_cd", formVO);
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Ta070f01Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

