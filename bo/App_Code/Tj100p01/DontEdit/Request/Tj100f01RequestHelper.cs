using com.xebio.bo.Tj100p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Tj100p01.Request
{
  /// <summary>
  /// Tj100f01RequestHelper の概要の説明です。
  /// </summary>
  public static class Tj100f01RequestHelper
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
			Tj100f01Form formVO = (Tj100f01Form)pageContext.GetFormVO();

			//カード部を初期化する
			paramCol.InitCardItems(formInfo.GetCardItems());
			//明細「M1」部を初期化する
			paramCol.InitListItems(formInfo.GetListItems("M1"), formVO.GetList("M1").CurrentCount);
			//カード項目の入力値を取得する
			paramCol["Head_tenpo_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_nm"]);
			paramCol["Torimore_ketsuban"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Torimore_ketsuban"]);
			paramCol["Face_no_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Face_no_from"]);
			paramCol["Face_no_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Face_no_to"]);
			paramCol["Face_no_from1"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Face_no_from1"]);
			paramCol["Face_no_to1"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Face_no_to1"]);
			paramCol["Face_no_from2"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Face_no_from2"]);
			paramCol["Face_no_to2"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Face_no_to2"]);
			paramCol["Face_no_from3"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Face_no_from3"]);
			paramCol["Face_no_to3"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Face_no_to3"]);
			paramCol["Face_no_from4"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Face_no_from4"]);
			paramCol["Face_no_to4"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Face_no_to4"]);
			paramCol["Face_no_from5"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Face_no_from5"]);
			paramCol["Face_no_to5"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Face_no_to5"]);
			paramCol["Face_no_from6"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Face_no_from6"]);
			paramCol["Face_no_to6"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Face_no_to6"]);
			paramCol["Face_no_from7"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Face_no_from7"]);
			paramCol["Face_no_to7"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Face_no_to7"]);
			paramCol["Face_no_from8"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Face_no_from8"]);
			paramCol["Face_no_to8"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Face_no_to8"]);
			paramCol["Face_no_from9"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Face_no_from9"]);
			paramCol["Face_no_to9"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Face_no_to9"]);
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
				paramCol["M1face_no"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1face_no"]);
				paramCol["M1tana_dan"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tana_dan"]);
				paramCol["M1selectorcheckbox"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1selectorcheckbox"]);
				paramCol["M1entersyoriflg"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1entersyoriflg"]);
				paramCol["M1dtlirokbn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1dtlirokbn"]);
				paramCol["M1rowno2"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1rowno2"]);
				paramCol["M1face_no2"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1face_no2"]);
				paramCol["M1tana_dan2"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tana_dan2"]);
				paramCol["M1selectorcheckbox2"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1selectorcheckbox2"]);
				paramCol["M1entersyoriflg2"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1entersyoriflg2"]);
				paramCol["M1dtlirokbn2"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1dtlirokbn2"]);
				paramCol["M1rowno3"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1rowno3"]);
				paramCol["M1face_no3"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1face_no3"]);
				paramCol["M1tana_dan3"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tana_dan3"]);
				paramCol["M1selectorcheckbox3"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1selectorcheckbox3"]);
				paramCol["M1entersyoriflg3"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1entersyoriflg3"]);
				paramCol["M1dtlirokbn3"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1dtlirokbn3"]);
				paramCol["M1rowno4"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1rowno4"]);
				paramCol["M1face_no4"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1face_no4"]);
				paramCol["M1tana_dan4"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tana_dan4"]);
				paramCol["M1selectorcheckbox4"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1selectorcheckbox4"]);
				paramCol["M1entersyoriflg4"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1entersyoriflg4"]);
				paramCol["M1dtlirokbn4"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1dtlirokbn4"]);
				paramCol["M1rowno5"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1rowno5"]);
				paramCol["M1face_no5"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1face_no5"]);
				paramCol["M1tana_dan5"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tana_dan5"]);
				paramCol["M1selectorcheckbox5"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1selectorcheckbox5"]);
				paramCol["M1entersyoriflg5"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1entersyoriflg5"]);
				paramCol["M1dtlirokbn5"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1dtlirokbn5"]);
				paramCol["M1rowno6"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1rowno6"]);
				paramCol["M1face_no6"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1face_no6"]);
				paramCol["M1tana_dan6"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tana_dan6"]);
				paramCol["M1selectorcheckbox6"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1selectorcheckbox6"]);
				paramCol["M1entersyoriflg6"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1entersyoriflg6"]);
				paramCol["M1dtlirokbn6"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1dtlirokbn6"]);
				paramCol["M1rowno7"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1rowno7"]);
				paramCol["M1face_no7"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1face_no7"]);
				paramCol["M1tana_dan7"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tana_dan7"]);
				paramCol["M1selectorcheckbox7"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1selectorcheckbox7"]);
				paramCol["M1entersyoriflg7"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1entersyoriflg7"]);
				paramCol["M1dtlirokbn7"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1dtlirokbn7"]);
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
			Tj100f01Form formVO = (Tj100f01Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Torimore_ketsuban"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Torimore_ketsuban"].RequestValue, formInfo["Torimore_ketsuban"]);
			paramCol["Face_no_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Face_no_from"].RequestValue, formInfo["Face_no_from"]);
			paramCol["Face_no_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Face_no_to"].RequestValue, formInfo["Face_no_to"]);
			paramCol["Face_no_from1"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Face_no_from1"].RequestValue, formInfo["Face_no_from1"]);
			paramCol["Face_no_to1"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Face_no_to1"].RequestValue, formInfo["Face_no_to1"]);
			paramCol["Face_no_from2"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Face_no_from2"].RequestValue, formInfo["Face_no_from2"]);
			paramCol["Face_no_to2"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Face_no_to2"].RequestValue, formInfo["Face_no_to2"]);
			paramCol["Face_no_from3"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Face_no_from3"].RequestValue, formInfo["Face_no_from3"]);
			paramCol["Face_no_to3"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Face_no_to3"].RequestValue, formInfo["Face_no_to3"]);
			paramCol["Face_no_from4"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Face_no_from4"].RequestValue, formInfo["Face_no_from4"]);
			paramCol["Face_no_to4"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Face_no_to4"].RequestValue, formInfo["Face_no_to4"]);
			paramCol["Face_no_from5"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Face_no_from5"].RequestValue, formInfo["Face_no_from5"]);
			paramCol["Face_no_to5"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Face_no_to5"].RequestValue, formInfo["Face_no_to5"]);
			paramCol["Face_no_from6"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Face_no_from6"].RequestValue, formInfo["Face_no_from6"]);
			paramCol["Face_no_to6"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Face_no_to6"].RequestValue, formInfo["Face_no_to6"]);
			paramCol["Face_no_from7"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Face_no_from7"].RequestValue, formInfo["Face_no_from7"]);
			paramCol["Face_no_to7"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Face_no_to7"].RequestValue, formInfo["Face_no_to7"]);
			paramCol["Face_no_from8"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Face_no_from8"].RequestValue, formInfo["Face_no_from8"]);
			paramCol["Face_no_to8"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Face_no_to8"].RequestValue, formInfo["Face_no_to8"]);
			paramCol["Face_no_from9"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Face_no_from9"].RequestValue, formInfo["Face_no_from9"]);
			paramCol["Face_no_to9"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Face_no_to9"].RequestValue, formInfo["Face_no_to9"]);
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
				paramCol["M1face_no"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1face_no"][i].RequestValue, formInfo["M1face_no"]);
				paramCol["M1tana_dan"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tana_dan"][i].RequestValue, formInfo["M1tana_dan"]);
				paramCol["M1selectorcheckbox"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1selectorcheckbox"][i].RequestValue, formInfo["M1selectorcheckbox"]);
				paramCol["M1entersyoriflg"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1entersyoriflg"][i].RequestValue, formInfo["M1entersyoriflg"]);
				paramCol["M1dtlirokbn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1dtlirokbn"][i].RequestValue, formInfo["M1dtlirokbn"]);
				paramCol["M1rowno2"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1rowno2"][i].RequestValue, formInfo["M1rowno2"]);
				paramCol["M1face_no2"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1face_no2"][i].RequestValue, formInfo["M1face_no2"]);
				paramCol["M1tana_dan2"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tana_dan2"][i].RequestValue, formInfo["M1tana_dan2"]);
				paramCol["M1selectorcheckbox2"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1selectorcheckbox2"][i].RequestValue, formInfo["M1selectorcheckbox2"]);
				paramCol["M1entersyoriflg2"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1entersyoriflg2"][i].RequestValue, formInfo["M1entersyoriflg2"]);
				paramCol["M1dtlirokbn2"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1dtlirokbn2"][i].RequestValue, formInfo["M1dtlirokbn2"]);
				paramCol["M1rowno3"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1rowno3"][i].RequestValue, formInfo["M1rowno3"]);
				paramCol["M1face_no3"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1face_no3"][i].RequestValue, formInfo["M1face_no3"]);
				paramCol["M1tana_dan3"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tana_dan3"][i].RequestValue, formInfo["M1tana_dan3"]);
				paramCol["M1selectorcheckbox3"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1selectorcheckbox3"][i].RequestValue, formInfo["M1selectorcheckbox3"]);
				paramCol["M1entersyoriflg3"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1entersyoriflg3"][i].RequestValue, formInfo["M1entersyoriflg3"]);
				paramCol["M1dtlirokbn3"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1dtlirokbn3"][i].RequestValue, formInfo["M1dtlirokbn3"]);
				paramCol["M1rowno4"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1rowno4"][i].RequestValue, formInfo["M1rowno4"]);
				paramCol["M1face_no4"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1face_no4"][i].RequestValue, formInfo["M1face_no4"]);
				paramCol["M1tana_dan4"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tana_dan4"][i].RequestValue, formInfo["M1tana_dan4"]);
				paramCol["M1selectorcheckbox4"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1selectorcheckbox4"][i].RequestValue, formInfo["M1selectorcheckbox4"]);
				paramCol["M1entersyoriflg4"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1entersyoriflg4"][i].RequestValue, formInfo["M1entersyoriflg4"]);
				paramCol["M1dtlirokbn4"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1dtlirokbn4"][i].RequestValue, formInfo["M1dtlirokbn4"]);
				paramCol["M1rowno5"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1rowno5"][i].RequestValue, formInfo["M1rowno5"]);
				paramCol["M1face_no5"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1face_no5"][i].RequestValue, formInfo["M1face_no5"]);
				paramCol["M1tana_dan5"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tana_dan5"][i].RequestValue, formInfo["M1tana_dan5"]);
				paramCol["M1selectorcheckbox5"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1selectorcheckbox5"][i].RequestValue, formInfo["M1selectorcheckbox5"]);
				paramCol["M1entersyoriflg5"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1entersyoriflg5"][i].RequestValue, formInfo["M1entersyoriflg5"]);
				paramCol["M1dtlirokbn5"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1dtlirokbn5"][i].RequestValue, formInfo["M1dtlirokbn5"]);
				paramCol["M1rowno6"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1rowno6"][i].RequestValue, formInfo["M1rowno6"]);
				paramCol["M1face_no6"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1face_no6"][i].RequestValue, formInfo["M1face_no6"]);
				paramCol["M1tana_dan6"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tana_dan6"][i].RequestValue, formInfo["M1tana_dan6"]);
				paramCol["M1selectorcheckbox6"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1selectorcheckbox6"][i].RequestValue, formInfo["M1selectorcheckbox6"]);
				paramCol["M1entersyoriflg6"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1entersyoriflg6"][i].RequestValue, formInfo["M1entersyoriflg6"]);
				paramCol["M1dtlirokbn6"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1dtlirokbn6"][i].RequestValue, formInfo["M1dtlirokbn6"]);
				paramCol["M1rowno7"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1rowno7"][i].RequestValue, formInfo["M1rowno7"]);
				paramCol["M1face_no7"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1face_no7"][i].RequestValue, formInfo["M1face_no7"]);
				paramCol["M1tana_dan7"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tana_dan7"][i].RequestValue, formInfo["M1tana_dan7"]);
				paramCol["M1selectorcheckbox7"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1selectorcheckbox7"][i].RequestValue, formInfo["M1selectorcheckbox7"]);
				paramCol["M1entersyoriflg7"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1entersyoriflg7"][i].RequestValue, formInfo["M1entersyoriflg7"]);
				paramCol["M1dtlirokbn7"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1dtlirokbn7"][i].RequestValue, formInfo["M1dtlirokbn7"]);
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
			Tj100f01Form formVO = (Tj100f01Form)pageContext.GetFormVO();

			//カード項目の入力値をFormVOにコピーする
			if (paramCol["Head_tenpo_cd"].UnformatValue != null)
			{
				formVO.Head_tenpo_cd = paramCol["Head_tenpo_cd"].UnformatValue;
			}
			if (paramCol["Head_tenpo_nm"].UnformatValue != null)
			{
				formVO.Head_tenpo_nm = paramCol["Head_tenpo_nm"].UnformatValue;
			}
			if (paramCol["Torimore_ketsuban"].UnformatValue != null)
			{
				formVO.Torimore_ketsuban = paramCol["Torimore_ketsuban"].UnformatValue;
			}
			if (paramCol["Face_no_from"].UnformatValue != null)
			{
				formVO.Face_no_from = paramCol["Face_no_from"].UnformatValue;
			}
			if (paramCol["Face_no_to"].UnformatValue != null)
			{
				formVO.Face_no_to = paramCol["Face_no_to"].UnformatValue;
			}
			if (paramCol["Face_no_from1"].UnformatValue != null)
			{
				formVO.Face_no_from1 = paramCol["Face_no_from1"].UnformatValue;
			}
			if (paramCol["Face_no_to1"].UnformatValue != null)
			{
				formVO.Face_no_to1 = paramCol["Face_no_to1"].UnformatValue;
			}
			if (paramCol["Face_no_from2"].UnformatValue != null)
			{
				formVO.Face_no_from2 = paramCol["Face_no_from2"].UnformatValue;
			}
			if (paramCol["Face_no_to2"].UnformatValue != null)
			{
				formVO.Face_no_to2 = paramCol["Face_no_to2"].UnformatValue;
			}
			if (paramCol["Face_no_from3"].UnformatValue != null)
			{
				formVO.Face_no_from3 = paramCol["Face_no_from3"].UnformatValue;
			}
			if (paramCol["Face_no_to3"].UnformatValue != null)
			{
				formVO.Face_no_to3 = paramCol["Face_no_to3"].UnformatValue;
			}
			if (paramCol["Face_no_from4"].UnformatValue != null)
			{
				formVO.Face_no_from4 = paramCol["Face_no_from4"].UnformatValue;
			}
			if (paramCol["Face_no_to4"].UnformatValue != null)
			{
				formVO.Face_no_to4 = paramCol["Face_no_to4"].UnformatValue;
			}
			if (paramCol["Face_no_from5"].UnformatValue != null)
			{
				formVO.Face_no_from5 = paramCol["Face_no_from5"].UnformatValue;
			}
			if (paramCol["Face_no_to5"].UnformatValue != null)
			{
				formVO.Face_no_to5 = paramCol["Face_no_to5"].UnformatValue;
			}
			if (paramCol["Face_no_from6"].UnformatValue != null)
			{
				formVO.Face_no_from6 = paramCol["Face_no_from6"].UnformatValue;
			}
			if (paramCol["Face_no_to6"].UnformatValue != null)
			{
				formVO.Face_no_to6 = paramCol["Face_no_to6"].UnformatValue;
			}
			if (paramCol["Face_no_from7"].UnformatValue != null)
			{
				formVO.Face_no_from7 = paramCol["Face_no_from7"].UnformatValue;
			}
			if (paramCol["Face_no_to7"].UnformatValue != null)
			{
				formVO.Face_no_to7 = paramCol["Face_no_to7"].UnformatValue;
			}
			if (paramCol["Face_no_from8"].UnformatValue != null)
			{
				formVO.Face_no_from8 = paramCol["Face_no_from8"].UnformatValue;
			}
			if (paramCol["Face_no_to8"].UnformatValue != null)
			{
				formVO.Face_no_to8 = paramCol["Face_no_to8"].UnformatValue;
			}
			if (paramCol["Face_no_from9"].UnformatValue != null)
			{
				formVO.Face_no_from9 = paramCol["Face_no_from9"].UnformatValue;
			}
			if (paramCol["Face_no_to9"].UnformatValue != null)
			{
				formVO.Face_no_to9 = paramCol["Face_no_to9"].UnformatValue;
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
				Tj100f01M1Form tj100f01M1Form = (Tj100f01M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					tj100f01M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1face_no"][i].UnformatValue != null)
				{
					tj100f01M1Form.M1face_no = paramCol["M1face_no"][i].UnformatValue;
				}
				if (paramCol["M1tana_dan"][i].UnformatValue != null)
				{
					tj100f01M1Form.M1tana_dan = paramCol["M1tana_dan"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					tj100f01M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					tj100f01M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					tj100f01M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
				}
				if (paramCol["M1rowno2"][i].UnformatValue != null)
				{
					tj100f01M1Form.M1rowno2 = paramCol["M1rowno2"][i].UnformatValue;
				}
				if (paramCol["M1face_no2"][i].UnformatValue != null)
				{
					tj100f01M1Form.M1face_no2 = paramCol["M1face_no2"][i].UnformatValue;
				}
				if (paramCol["M1tana_dan2"][i].UnformatValue != null)
				{
					tj100f01M1Form.M1tana_dan2 = paramCol["M1tana_dan2"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox2"][i].UnformatValue != null)
				{
					tj100f01M1Form.M1selectorcheckbox2 = paramCol["M1selectorcheckbox2"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg2"][i].UnformatValue != null)
				{
					tj100f01M1Form.M1entersyoriflg2 = paramCol["M1entersyoriflg2"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn2"][i].UnformatValue != null)
				{
					tj100f01M1Form.M1dtlirokbn2 = paramCol["M1dtlirokbn2"][i].UnformatValue;
				}
				if (paramCol["M1rowno3"][i].UnformatValue != null)
				{
					tj100f01M1Form.M1rowno3 = paramCol["M1rowno3"][i].UnformatValue;
				}
				if (paramCol["M1face_no3"][i].UnformatValue != null)
				{
					tj100f01M1Form.M1face_no3 = paramCol["M1face_no3"][i].UnformatValue;
				}
				if (paramCol["M1tana_dan3"][i].UnformatValue != null)
				{
					tj100f01M1Form.M1tana_dan3 = paramCol["M1tana_dan3"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox3"][i].UnformatValue != null)
				{
					tj100f01M1Form.M1selectorcheckbox3 = paramCol["M1selectorcheckbox3"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg3"][i].UnformatValue != null)
				{
					tj100f01M1Form.M1entersyoriflg3 = paramCol["M1entersyoriflg3"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn3"][i].UnformatValue != null)
				{
					tj100f01M1Form.M1dtlirokbn3 = paramCol["M1dtlirokbn3"][i].UnformatValue;
				}
				if (paramCol["M1rowno4"][i].UnformatValue != null)
				{
					tj100f01M1Form.M1rowno4 = paramCol["M1rowno4"][i].UnformatValue;
				}
				if (paramCol["M1face_no4"][i].UnformatValue != null)
				{
					tj100f01M1Form.M1face_no4 = paramCol["M1face_no4"][i].UnformatValue;
				}
				if (paramCol["M1tana_dan4"][i].UnformatValue != null)
				{
					tj100f01M1Form.M1tana_dan4 = paramCol["M1tana_dan4"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox4"][i].UnformatValue != null)
				{
					tj100f01M1Form.M1selectorcheckbox4 = paramCol["M1selectorcheckbox4"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg4"][i].UnformatValue != null)
				{
					tj100f01M1Form.M1entersyoriflg4 = paramCol["M1entersyoriflg4"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn4"][i].UnformatValue != null)
				{
					tj100f01M1Form.M1dtlirokbn4 = paramCol["M1dtlirokbn4"][i].UnformatValue;
				}
				if (paramCol["M1rowno5"][i].UnformatValue != null)
				{
					tj100f01M1Form.M1rowno5 = paramCol["M1rowno5"][i].UnformatValue;
				}
				if (paramCol["M1face_no5"][i].UnformatValue != null)
				{
					tj100f01M1Form.M1face_no5 = paramCol["M1face_no5"][i].UnformatValue;
				}
				if (paramCol["M1tana_dan5"][i].UnformatValue != null)
				{
					tj100f01M1Form.M1tana_dan5 = paramCol["M1tana_dan5"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox5"][i].UnformatValue != null)
				{
					tj100f01M1Form.M1selectorcheckbox5 = paramCol["M1selectorcheckbox5"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg5"][i].UnformatValue != null)
				{
					tj100f01M1Form.M1entersyoriflg5 = paramCol["M1entersyoriflg5"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn5"][i].UnformatValue != null)
				{
					tj100f01M1Form.M1dtlirokbn5 = paramCol["M1dtlirokbn5"][i].UnformatValue;
				}
				if (paramCol["M1rowno6"][i].UnformatValue != null)
				{
					tj100f01M1Form.M1rowno6 = paramCol["M1rowno6"][i].UnformatValue;
				}
				if (paramCol["M1face_no6"][i].UnformatValue != null)
				{
					tj100f01M1Form.M1face_no6 = paramCol["M1face_no6"][i].UnformatValue;
				}
				if (paramCol["M1tana_dan6"][i].UnformatValue != null)
				{
					tj100f01M1Form.M1tana_dan6 = paramCol["M1tana_dan6"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox6"][i].UnformatValue != null)
				{
					tj100f01M1Form.M1selectorcheckbox6 = paramCol["M1selectorcheckbox6"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg6"][i].UnformatValue != null)
				{
					tj100f01M1Form.M1entersyoriflg6 = paramCol["M1entersyoriflg6"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn6"][i].UnformatValue != null)
				{
					tj100f01M1Form.M1dtlirokbn6 = paramCol["M1dtlirokbn6"][i].UnformatValue;
				}
				if (paramCol["M1rowno7"][i].UnformatValue != null)
				{
					tj100f01M1Form.M1rowno7 = paramCol["M1rowno7"][i].UnformatValue;
				}
				if (paramCol["M1face_no7"][i].UnformatValue != null)
				{
					tj100f01M1Form.M1face_no7 = paramCol["M1face_no7"][i].UnformatValue;
				}
				if (paramCol["M1tana_dan7"][i].UnformatValue != null)
				{
					tj100f01M1Form.M1tana_dan7 = paramCol["M1tana_dan7"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox7"][i].UnformatValue != null)
				{
					tj100f01M1Form.M1selectorcheckbox7 = paramCol["M1selectorcheckbox7"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg7"][i].UnformatValue != null)
				{
					tj100f01M1Form.M1entersyoriflg7 = paramCol["M1entersyoriflg7"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn7"][i].UnformatValue != null)
				{
					tj100f01M1Form.M1dtlirokbn7 = paramCol["M1dtlirokbn7"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Tj100f01Form formVO, StandardCheckManager checker)
		{
			if (formVO.Head_tenpo_cd != null)
			{
				checker.DoCheck("Head_tenpo_cd", formVO.Head_tenpo_cd);
			}
			if (formVO.Head_tenpo_nm != null)
			{
				checker.DoCheck("Head_tenpo_nm", formVO.Head_tenpo_nm);
			}
			if (formVO.Torimore_ketsuban != null)
			{
				checker.DoCheck("Torimore_ketsuban", formVO.Torimore_ketsuban);
			}
			if (formVO.Face_no_from != null)
			{
				checker.DoCheck("Face_no_from", formVO.Face_no_from);
			}
			if (formVO.Face_no_to != null)
			{
				checker.DoCheck("Face_no_to", formVO.Face_no_to);
			}
			if (formVO.Face_no_from1 != null)
			{
				checker.DoCheck("Face_no_from1", formVO.Face_no_from1);
			}
			if (formVO.Face_no_to1 != null)
			{
				checker.DoCheck("Face_no_to1", formVO.Face_no_to1);
			}
			if (formVO.Face_no_from2 != null)
			{
				checker.DoCheck("Face_no_from2", formVO.Face_no_from2);
			}
			if (formVO.Face_no_to2 != null)
			{
				checker.DoCheck("Face_no_to2", formVO.Face_no_to2);
			}
			if (formVO.Face_no_from3 != null)
			{
				checker.DoCheck("Face_no_from3", formVO.Face_no_from3);
			}
			if (formVO.Face_no_to3 != null)
			{
				checker.DoCheck("Face_no_to3", formVO.Face_no_to3);
			}
			if (formVO.Face_no_from4 != null)
			{
				checker.DoCheck("Face_no_from4", formVO.Face_no_from4);
			}
			if (formVO.Face_no_to4 != null)
			{
				checker.DoCheck("Face_no_to4", formVO.Face_no_to4);
			}
			if (formVO.Face_no_from5 != null)
			{
				checker.DoCheck("Face_no_from5", formVO.Face_no_from5);
			}
			if (formVO.Face_no_to5 != null)
			{
				checker.DoCheck("Face_no_to5", formVO.Face_no_to5);
			}
			if (formVO.Face_no_from6 != null)
			{
				checker.DoCheck("Face_no_from6", formVO.Face_no_from6);
			}
			if (formVO.Face_no_to6 != null)
			{
				checker.DoCheck("Face_no_to6", formVO.Face_no_to6);
			}
			if (formVO.Face_no_from7 != null)
			{
				checker.DoCheck("Face_no_from7", formVO.Face_no_from7);
			}
			if (formVO.Face_no_to7 != null)
			{
				checker.DoCheck("Face_no_to7", formVO.Face_no_to7);
			}
			if (formVO.Face_no_from8 != null)
			{
				checker.DoCheck("Face_no_from8", formVO.Face_no_from8);
			}
			if (formVO.Face_no_to8 != null)
			{
				checker.DoCheck("Face_no_to8", formVO.Face_no_to8);
			}
			if (formVO.Face_no_from9 != null)
			{
				checker.DoCheck("Face_no_from9", formVO.Face_no_from9);
			}
			if (formVO.Face_no_to9 != null)
			{
				checker.DoCheck("Face_no_to9", formVO.Face_no_to9);
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
		public static void ValidateM1InputValue(Tj100f01Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Tj100f01M1Form tj100f01M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, tj100f01M1Form, i, m1List);
				if (tj100f01M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", tj100f01M1Form.M1rowno, i, m1List);
				}
				if (tj100f01M1Form.M1face_no != null)
				{
					checker.DoCheck("M1face_no", tj100f01M1Form.M1face_no, i, m1List);
				}
				if (tj100f01M1Form.M1tana_dan != null)
				{
					checker.DoCheck("M1tana_dan", tj100f01M1Form.M1tana_dan, i, m1List);
				}
				if (tj100f01M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", tj100f01M1Form.M1selectorcheckbox, i, m1List);
				}
				if (tj100f01M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", tj100f01M1Form.M1entersyoriflg, i, m1List);
				}
				if (tj100f01M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", tj100f01M1Form.M1dtlirokbn, i, m1List);
				}
				if (tj100f01M1Form.M1rowno2 != null)
				{
					checker.DoCheck("M1rowno2", tj100f01M1Form.M1rowno2, i, m1List);
				}
				if (tj100f01M1Form.M1face_no2 != null)
				{
					checker.DoCheck("M1face_no2", tj100f01M1Form.M1face_no2, i, m1List);
				}
				if (tj100f01M1Form.M1tana_dan2 != null)
				{
					checker.DoCheck("M1tana_dan2", tj100f01M1Form.M1tana_dan2, i, m1List);
				}
				if (tj100f01M1Form.M1selectorcheckbox2 != null)
				{
					checker.DoCheck("M1selectorcheckbox2", tj100f01M1Form.M1selectorcheckbox2, i, m1List);
				}
				if (tj100f01M1Form.M1entersyoriflg2 != null)
				{
					checker.DoCheck("M1entersyoriflg2", tj100f01M1Form.M1entersyoriflg2, i, m1List);
				}
				if (tj100f01M1Form.M1dtlirokbn2 != null)
				{
					checker.DoCheck("M1dtlirokbn2", tj100f01M1Form.M1dtlirokbn2, i, m1List);
				}
				if (tj100f01M1Form.M1rowno3 != null)
				{
					checker.DoCheck("M1rowno3", tj100f01M1Form.M1rowno3, i, m1List);
				}
				if (tj100f01M1Form.M1face_no3 != null)
				{
					checker.DoCheck("M1face_no3", tj100f01M1Form.M1face_no3, i, m1List);
				}
				if (tj100f01M1Form.M1tana_dan3 != null)
				{
					checker.DoCheck("M1tana_dan3", tj100f01M1Form.M1tana_dan3, i, m1List);
				}
				if (tj100f01M1Form.M1selectorcheckbox3 != null)
				{
					checker.DoCheck("M1selectorcheckbox3", tj100f01M1Form.M1selectorcheckbox3, i, m1List);
				}
				if (tj100f01M1Form.M1entersyoriflg3 != null)
				{
					checker.DoCheck("M1entersyoriflg3", tj100f01M1Form.M1entersyoriflg3, i, m1List);
				}
				if (tj100f01M1Form.M1dtlirokbn3 != null)
				{
					checker.DoCheck("M1dtlirokbn3", tj100f01M1Form.M1dtlirokbn3, i, m1List);
				}
				if (tj100f01M1Form.M1rowno4 != null)
				{
					checker.DoCheck("M1rowno4", tj100f01M1Form.M1rowno4, i, m1List);
				}
				if (tj100f01M1Form.M1face_no4 != null)
				{
					checker.DoCheck("M1face_no4", tj100f01M1Form.M1face_no4, i, m1List);
				}
				if (tj100f01M1Form.M1tana_dan4 != null)
				{
					checker.DoCheck("M1tana_dan4", tj100f01M1Form.M1tana_dan4, i, m1List);
				}
				if (tj100f01M1Form.M1selectorcheckbox4 != null)
				{
					checker.DoCheck("M1selectorcheckbox4", tj100f01M1Form.M1selectorcheckbox4, i, m1List);
				}
				if (tj100f01M1Form.M1entersyoriflg4 != null)
				{
					checker.DoCheck("M1entersyoriflg4", tj100f01M1Form.M1entersyoriflg4, i, m1List);
				}
				if (tj100f01M1Form.M1dtlirokbn4 != null)
				{
					checker.DoCheck("M1dtlirokbn4", tj100f01M1Form.M1dtlirokbn4, i, m1List);
				}
				if (tj100f01M1Form.M1rowno5 != null)
				{
					checker.DoCheck("M1rowno5", tj100f01M1Form.M1rowno5, i, m1List);
				}
				if (tj100f01M1Form.M1face_no5 != null)
				{
					checker.DoCheck("M1face_no5", tj100f01M1Form.M1face_no5, i, m1List);
				}
				if (tj100f01M1Form.M1tana_dan5 != null)
				{
					checker.DoCheck("M1tana_dan5", tj100f01M1Form.M1tana_dan5, i, m1List);
				}
				if (tj100f01M1Form.M1selectorcheckbox5 != null)
				{
					checker.DoCheck("M1selectorcheckbox5", tj100f01M1Form.M1selectorcheckbox5, i, m1List);
				}
				if (tj100f01M1Form.M1entersyoriflg5 != null)
				{
					checker.DoCheck("M1entersyoriflg5", tj100f01M1Form.M1entersyoriflg5, i, m1List);
				}
				if (tj100f01M1Form.M1dtlirokbn5 != null)
				{
					checker.DoCheck("M1dtlirokbn5", tj100f01M1Form.M1dtlirokbn5, i, m1List);
				}
				if (tj100f01M1Form.M1rowno6 != null)
				{
					checker.DoCheck("M1rowno6", tj100f01M1Form.M1rowno6, i, m1List);
				}
				if (tj100f01M1Form.M1face_no6 != null)
				{
					checker.DoCheck("M1face_no6", tj100f01M1Form.M1face_no6, i, m1List);
				}
				if (tj100f01M1Form.M1tana_dan6 != null)
				{
					checker.DoCheck("M1tana_dan6", tj100f01M1Form.M1tana_dan6, i, m1List);
				}
				if (tj100f01M1Form.M1selectorcheckbox6 != null)
				{
					checker.DoCheck("M1selectorcheckbox6", tj100f01M1Form.M1selectorcheckbox6, i, m1List);
				}
				if (tj100f01M1Form.M1entersyoriflg6 != null)
				{
					checker.DoCheck("M1entersyoriflg6", tj100f01M1Form.M1entersyoriflg6, i, m1List);
				}
				if (tj100f01M1Form.M1dtlirokbn6 != null)
				{
					checker.DoCheck("M1dtlirokbn6", tj100f01M1Form.M1dtlirokbn6, i, m1List);
				}
				if (tj100f01M1Form.M1rowno7 != null)
				{
					checker.DoCheck("M1rowno7", tj100f01M1Form.M1rowno7, i, m1List);
				}
				if (tj100f01M1Form.M1face_no7 != null)
				{
					checker.DoCheck("M1face_no7", tj100f01M1Form.M1face_no7, i, m1List);
				}
				if (tj100f01M1Form.M1tana_dan7 != null)
				{
					checker.DoCheck("M1tana_dan7", tj100f01M1Form.M1tana_dan7, i, m1List);
				}
				if (tj100f01M1Form.M1selectorcheckbox7 != null)
				{
					checker.DoCheck("M1selectorcheckbox7", tj100f01M1Form.M1selectorcheckbox7, i, m1List);
				}
				if (tj100f01M1Form.M1entersyoriflg7 != null)
				{
					checker.DoCheck("M1entersyoriflg7", tj100f01M1Form.M1entersyoriflg7, i, m1List);
				}
				if (tj100f01M1Form.M1dtlirokbn7 != null)
				{
					checker.DoCheck("M1dtlirokbn7", tj100f01M1Form.M1dtlirokbn7, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Tj100f01Form formVO, StandardCodeCheckManager checker)
		{
			checker.DoCheck("Btnheadtenpocd", formVO);
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Tj100f01Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

