using com.xebio.bo.Tg010p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Tg010p01.Request
{
  /// <summary>
  /// Tg010f01RequestHelper の概要の説明です。
  /// </summary>
  public static class Tg010f01RequestHelper
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
			Tg010f01Form formVO = (Tg010f01Form)pageContext.GetFormVO();

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
			paramCol["Burando_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Burando_nm"]);
			paramCol["Searchcnt"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Searchcnt"]);
			paramCol["Syutsuryoku_seal"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Syutsuryoku_seal"]);
			paramCol["Label_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Label_cd"]);
			paramCol["Label_ip"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Label_ip"]);
			paramCol["Label_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Label_nm"]);
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
				paramCol["M1hinsyu_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hinsyu_cd"]);
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
				paramCol["M1iro_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1iro_nm"]);
				paramCol["M1size_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1size_nm"]);
				paramCol["M1hanbaikanryo_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hanbaikanryo_ymd"]);
				paramCol["M1scan_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1scan_cd"]);
				paramCol["M1baihenkaisi_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1baihenkaisi_ymd"]);
				paramCol["M1sijibaika_tnk"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1sijibaika_tnk"]);
				paramCol["M1saisinbaika_tnk"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1saisinbaika_tnk"]);
				paramCol["M1maisu"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1maisu"]);
				paramCol["M1itemkbn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1itemkbn"]);
				paramCol["M1siire_kb"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1siire_kb"]);
				paramCol["M1tyotatsu_kb"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tyotatsu_kb"]);
				paramCol["M1makerkakaku_tnk"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1makerkakaku_tnk"]);
				paramCol["M1baika_zei"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1baika_zei"]);
				paramCol["M1burando_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1burando_cd"]);
				paramCol["M1bumon_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1bumon_nm"]);
				paramCol["M1siiresaki_cd_bo1"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1siiresaki_cd_bo1"]);
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
			Tg010f01Form formVO = (Tg010f01Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Modeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Modeno"].RequestValue, formInfo["Modeno"]);
			paramCol["Stkmodeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Stkmodeno"].RequestValue, formInfo["Stkmodeno"]);
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
			paramCol["Burando_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Burando_nm"].RequestValue, formInfo["Burando_nm"]);
			paramCol["Searchcnt"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Searchcnt"].RequestValue, formInfo["Searchcnt"]);
			paramCol["Syutsuryoku_seal"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Syutsuryoku_seal"].RequestValue, formInfo["Syutsuryoku_seal"]);
			paramCol["Label_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Label_cd"].RequestValue, formInfo["Label_cd"]);
			paramCol["Label_ip"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Label_ip"].RequestValue, formInfo["Label_ip"]);
			paramCol["Label_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Label_nm"].RequestValue, formInfo["Label_nm"]);
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
				paramCol["M1hinsyu_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hinsyu_cd"][i].RequestValue, formInfo["M1hinsyu_cd"]);
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
				paramCol["M1iro_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1iro_nm"][i].RequestValue, formInfo["M1iro_nm"]);
				paramCol["M1size_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1size_nm"][i].RequestValue, formInfo["M1size_nm"]);
				paramCol["M1hanbaikanryo_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hanbaikanryo_ymd"][i].RequestValue, formInfo["M1hanbaikanryo_ymd"]);
				paramCol["M1hanbaikanryo_ymd"][i].DateFullValue = RequestParameterUtil.GetDateFullValue(
					paramCol["M1hanbaikanryo_ymd"][i].RequestValue, formInfo["M1hanbaikanryo_ymd"]);
				paramCol["M1scan_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1scan_cd"][i].RequestValue, formInfo["M1scan_cd"]);
				paramCol["M1baihenkaisi_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1baihenkaisi_ymd"][i].RequestValue, formInfo["M1baihenkaisi_ymd"]);
				paramCol["M1baihenkaisi_ymd"][i].DateFullValue = RequestParameterUtil.GetDateFullValue(
					paramCol["M1baihenkaisi_ymd"][i].RequestValue, formInfo["M1baihenkaisi_ymd"]);
				paramCol["M1sijibaika_tnk"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1sijibaika_tnk"][i].RequestValue, formInfo["M1sijibaika_tnk"]);
				paramCol["M1saisinbaika_tnk"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1saisinbaika_tnk"][i].RequestValue, formInfo["M1saisinbaika_tnk"]);
				paramCol["M1maisu"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1maisu"][i].RequestValue, formInfo["M1maisu"]);
				paramCol["M1itemkbn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1itemkbn"][i].RequestValue, formInfo["M1itemkbn"]);
				paramCol["M1siire_kb"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1siire_kb"][i].RequestValue, formInfo["M1siire_kb"]);
				paramCol["M1tyotatsu_kb"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tyotatsu_kb"][i].RequestValue, formInfo["M1tyotatsu_kb"]);
				paramCol["M1makerkakaku_tnk"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1makerkakaku_tnk"][i].RequestValue, formInfo["M1makerkakaku_tnk"]);
				paramCol["M1baika_zei"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1baika_zei"][i].RequestValue, formInfo["M1baika_zei"]);
				paramCol["M1burando_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1burando_cd"][i].RequestValue, formInfo["M1burando_cd"]);
				paramCol["M1bumon_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1bumon_nm"][i].RequestValue, formInfo["M1bumon_nm"]);
				paramCol["M1siiresaki_cd_bo1"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1siiresaki_cd_bo1"][i].RequestValue, formInfo["M1siiresaki_cd_bo1"]);
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
			Tg010f01Form formVO = (Tg010f01Form)pageContext.GetFormVO();

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
			if (paramCol["Burando_nm"].UnformatValue != null)
			{
				formVO.Burando_nm = paramCol["Burando_nm"].UnformatValue;
			}
			if (paramCol["Searchcnt"].UnformatValue != null)
			{
				formVO.Searchcnt = paramCol["Searchcnt"].UnformatValue;
			}
			if (paramCol["Syutsuryoku_seal"].UnformatValue != null)
			{
				formVO.Syutsuryoku_seal = paramCol["Syutsuryoku_seal"].UnformatValue;
			}
			if (paramCol["Label_cd"].UnformatValue != null)
			{
				formVO.Label_cd = paramCol["Label_cd"].UnformatValue;
			}
			if (paramCol["Label_ip"].UnformatValue != null)
			{
				formVO.Label_ip = paramCol["Label_ip"].UnformatValue;
			}
			if (paramCol["Label_nm"].UnformatValue != null)
			{
				formVO.Label_nm = paramCol["Label_nm"].UnformatValue;
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
				Tg010f01M1Form tg010f01M1Form = (Tg010f01M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					tg010f01M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1bumon_cd"][i].UnformatValue != null)
				{
					tg010f01M1Form.M1bumon_cd = paramCol["M1bumon_cd"][i].UnformatValue;
				}
				if (paramCol["M1bumonkana_nm"][i].UnformatValue != null)
				{
					tg010f01M1Form.M1bumonkana_nm = paramCol["M1bumonkana_nm"][i].UnformatValue;
				}
				if (paramCol["M1hinsyu_cd"][i].UnformatValue != null)
				{
					tg010f01M1Form.M1hinsyu_cd = paramCol["M1hinsyu_cd"][i].UnformatValue;
				}
				if (paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue != null)
				{
					tg010f01M1Form.M1hinsyu_ryaku_nm = paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue;
				}
				if (paramCol["M1burando_nm"][i].UnformatValue != null)
				{
					tg010f01M1Form.M1burando_nm = paramCol["M1burando_nm"][i].UnformatValue;
				}
				if (paramCol["M1jisya_hbn"][i].UnformatValue != null)
				{
					tg010f01M1Form.M1jisya_hbn = paramCol["M1jisya_hbn"][i].UnformatValue;
				}
				if (paramCol["M1maker_hbn"][i].UnformatValue != null)
				{
					tg010f01M1Form.M1maker_hbn = paramCol["M1maker_hbn"][i].UnformatValue;
				}
				if (paramCol["M1syonmk"][i].UnformatValue != null)
				{
					tg010f01M1Form.M1syonmk = paramCol["M1syonmk"][i].UnformatValue;
				}
				if (paramCol["M1iro_nm"][i].UnformatValue != null)
				{
					tg010f01M1Form.M1iro_nm = paramCol["M1iro_nm"][i].UnformatValue;
				}
				if (paramCol["M1size_nm"][i].UnformatValue != null)
				{
					tg010f01M1Form.M1size_nm = paramCol["M1size_nm"][i].UnformatValue;
				}
				if (paramCol["M1hanbaikanryo_ymd"][i].DateFullValue != null)
				{
					tg010f01M1Form.M1hanbaikanryo_ymd = paramCol["M1hanbaikanryo_ymd"][i].DateFullValue;
				}
				if (paramCol["M1scan_cd"][i].UnformatValue != null)
				{
					tg010f01M1Form.M1scan_cd = paramCol["M1scan_cd"][i].UnformatValue;
				}
				if (paramCol["M1baihenkaisi_ymd"][i].DateFullValue != null)
				{
					tg010f01M1Form.M1baihenkaisi_ymd = paramCol["M1baihenkaisi_ymd"][i].DateFullValue;
				}
				if (paramCol["M1sijibaika_tnk"][i].UnformatValue != null)
				{
					tg010f01M1Form.M1sijibaika_tnk = paramCol["M1sijibaika_tnk"][i].UnformatValue;
				}
				if (paramCol["M1saisinbaika_tnk"][i].UnformatValue != null)
				{
					tg010f01M1Form.M1saisinbaika_tnk = paramCol["M1saisinbaika_tnk"][i].UnformatValue;
				}
				if (paramCol["M1maisu"][i].UnformatValue != null)
				{
					tg010f01M1Form.M1maisu = paramCol["M1maisu"][i].UnformatValue;
				}
				if (paramCol["M1itemkbn"][i].UnformatValue != null)
				{
					tg010f01M1Form.M1itemkbn = paramCol["M1itemkbn"][i].UnformatValue;
				}
				if (paramCol["M1siire_kb"][i].UnformatValue != null)
				{
					tg010f01M1Form.M1siire_kb = paramCol["M1siire_kb"][i].UnformatValue;
				}
				if (paramCol["M1tyotatsu_kb"][i].UnformatValue != null)
				{
					tg010f01M1Form.M1tyotatsu_kb = paramCol["M1tyotatsu_kb"][i].UnformatValue;
				}
				if (paramCol["M1makerkakaku_tnk"][i].UnformatValue != null)
				{
					tg010f01M1Form.M1makerkakaku_tnk = paramCol["M1makerkakaku_tnk"][i].UnformatValue;
				}
				if (paramCol["M1baika_zei"][i].UnformatValue != null)
				{
					tg010f01M1Form.M1baika_zei = paramCol["M1baika_zei"][i].UnformatValue;
				}
				if (paramCol["M1burando_cd"][i].UnformatValue != null)
				{
					tg010f01M1Form.M1burando_cd = paramCol["M1burando_cd"][i].UnformatValue;
				}
				if (paramCol["M1bumon_nm"][i].UnformatValue != null)
				{
					tg010f01M1Form.M1bumon_nm = paramCol["M1bumon_nm"][i].UnformatValue;
				}
				if (paramCol["M1siiresaki_cd_bo1"][i].UnformatValue != null)
				{
					tg010f01M1Form.M1siiresaki_cd_bo1 = paramCol["M1siiresaki_cd_bo1"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					tg010f01M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					tg010f01M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					tg010f01M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Tg010f01Form formVO, StandardCheckManager checker)
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
			if (formVO.Burando_nm != null)
			{
				checker.DoCheck("Burando_nm", formVO.Burando_nm);
			}
			if (formVO.Searchcnt != null)
			{
				checker.DoCheck("Searchcnt", formVO.Searchcnt);
			}
			if (formVO.Syutsuryoku_seal != null)
			{
				checker.DoCheck("Syutsuryoku_seal", formVO.Syutsuryoku_seal);
			}
			if (formVO.Label_cd != null)
			{
				checker.DoCheck("Label_cd", formVO.Label_cd);
			}
			if (formVO.Label_ip != null)
			{
				checker.DoCheck("Label_ip", formVO.Label_ip);
			}
			if (formVO.Label_nm != null)
			{
				checker.DoCheck("Label_nm", formVO.Label_nm);
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
		public static void ValidateM1InputValue(Tg010f01Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Tg010f01M1Form tg010f01M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, tg010f01M1Form, i, m1List);
				if (tg010f01M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", tg010f01M1Form.M1rowno, i, m1List);
				}
				if (tg010f01M1Form.M1bumon_cd != null)
				{
					checker.DoCheck("M1bumon_cd", tg010f01M1Form.M1bumon_cd, i, m1List);
				}
				if (tg010f01M1Form.M1bumonkana_nm != null)
				{
					checker.DoCheck("M1bumonkana_nm", tg010f01M1Form.M1bumonkana_nm, i, m1List);
				}
				if (tg010f01M1Form.M1hinsyu_cd != null)
				{
					checker.DoCheck("M1hinsyu_cd", tg010f01M1Form.M1hinsyu_cd, i, m1List);
				}
				if (tg010f01M1Form.M1hinsyu_ryaku_nm != null)
				{
					checker.DoCheck("M1hinsyu_ryaku_nm", tg010f01M1Form.M1hinsyu_ryaku_nm, i, m1List);
				}
				if (tg010f01M1Form.M1burando_nm != null)
				{
					checker.DoCheck("M1burando_nm", tg010f01M1Form.M1burando_nm, i, m1List);
				}
				if (tg010f01M1Form.M1jisya_hbn != null)
				{
					checker.DoCheck("M1jisya_hbn", tg010f01M1Form.M1jisya_hbn, i, m1List);
				}
				if (tg010f01M1Form.M1maker_hbn != null)
				{
					checker.DoCheck("M1maker_hbn", tg010f01M1Form.M1maker_hbn, i, m1List);
				}
				if (tg010f01M1Form.M1syonmk != null)
				{
					checker.DoCheck("M1syonmk", tg010f01M1Form.M1syonmk, i, m1List);
				}
				if (tg010f01M1Form.M1iro_nm != null)
				{
					checker.DoCheck("M1iro_nm", tg010f01M1Form.M1iro_nm, i, m1List);
				}
				if (tg010f01M1Form.M1size_nm != null)
				{
					checker.DoCheck("M1size_nm", tg010f01M1Form.M1size_nm, i, m1List);
				}
				if (tg010f01M1Form.M1hanbaikanryo_ymd != null)
				{
					checker.DoCheck("M1hanbaikanryo_ymd", tg010f01M1Form.M1hanbaikanryo_ymd, i, m1List);
				}
				if (tg010f01M1Form.M1scan_cd != null)
				{
					checker.DoCheck("M1scan_cd", tg010f01M1Form.M1scan_cd, i, m1List);
				}
				if (tg010f01M1Form.M1baihenkaisi_ymd != null)
				{
					checker.DoCheck("M1baihenkaisi_ymd", tg010f01M1Form.M1baihenkaisi_ymd, i, m1List);
				}
				if (tg010f01M1Form.M1sijibaika_tnk != null)
				{
					checker.DoCheck("M1sijibaika_tnk", tg010f01M1Form.M1sijibaika_tnk, i, m1List);
				}
				if (tg010f01M1Form.M1saisinbaika_tnk != null)
				{
					checker.DoCheck("M1saisinbaika_tnk", tg010f01M1Form.M1saisinbaika_tnk, i, m1List);
				}
				if (tg010f01M1Form.M1maisu != null)
				{
					checker.DoCheck("M1maisu", tg010f01M1Form.M1maisu, i, m1List);
				}
				if (tg010f01M1Form.M1itemkbn != null)
				{
					checker.DoCheck("M1itemkbn", tg010f01M1Form.M1itemkbn, i, m1List);
				}
				if (tg010f01M1Form.M1siire_kb != null)
				{
					checker.DoCheck("M1siire_kb", tg010f01M1Form.M1siire_kb, i, m1List);
				}
				if (tg010f01M1Form.M1tyotatsu_kb != null)
				{
					checker.DoCheck("M1tyotatsu_kb", tg010f01M1Form.M1tyotatsu_kb, i, m1List);
				}
				if (tg010f01M1Form.M1makerkakaku_tnk != null)
				{
					checker.DoCheck("M1makerkakaku_tnk", tg010f01M1Form.M1makerkakaku_tnk, i, m1List);
				}
				if (tg010f01M1Form.M1baika_zei != null)
				{
					checker.DoCheck("M1baika_zei", tg010f01M1Form.M1baika_zei, i, m1List);
				}
				if (tg010f01M1Form.M1burando_cd != null)
				{
					checker.DoCheck("M1burando_cd", tg010f01M1Form.M1burando_cd, i, m1List);
				}
				if (tg010f01M1Form.M1bumon_nm != null)
				{
					checker.DoCheck("M1bumon_nm", tg010f01M1Form.M1bumon_nm, i, m1List);
				}
				if (tg010f01M1Form.M1siiresaki_cd_bo1 != null)
				{
					checker.DoCheck("M1siiresaki_cd_bo1", tg010f01M1Form.M1siiresaki_cd_bo1, i, m1List);
				}
				if (tg010f01M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", tg010f01M1Form.M1selectorcheckbox, i, m1List);
				}
				if (tg010f01M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", tg010f01M1Form.M1entersyoriflg, i, m1List);
				}
				if (tg010f01M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", tg010f01M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Tg010f01Form formVO, StandardCodeCheckManager checker)
		{
			checker.DoCheck("Btnheadtenpocd", formVO);
			checker.DoCheck("Btnbumon_cd", formVO);
			checker.DoCheck("Btnhinsyu_cd", formVO);
			checker.DoCheck("Btnburando_cd", formVO);
			checker.DoCheck("Btnlabel_cd", formVO);
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Tg010f01Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

