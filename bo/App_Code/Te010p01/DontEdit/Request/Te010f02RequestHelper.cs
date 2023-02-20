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
  /// Te010f02RequestHelper の概要の説明です。
  /// </summary>
  public static class Te010f02RequestHelper
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
			Te010f02Form formVO = (Te010f02Form)pageContext.GetFormVO();

			//カード部を初期化する
			paramCol.InitCardItems(formInfo.GetCardItems());
			//明細「M1」部を初期化する
			paramCol.InitListItems(formInfo.GetListItems("M1"), formVO.GetList("M1").CurrentCount);
			//カード項目の入力値を取得する
			paramCol["Head_tenpo_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_nm"]);
			paramCol["Denpyo_bango"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Denpyo_bango"]);
			paramCol["Siji_bango"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Siji_bango"]);
			paramCol["Scm_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Scm_cd"]);
			paramCol["Shukkariyu_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Shukkariyu_nm"]);
			paramCol["Syukkatan_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Syukkatan_cd"]);
			paramCol["Syukkatan_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Syukkatan_nm"]);
			paramCol["Syukka_ymd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Syukka_ymd"]);
			paramCol["Kaisya_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Kaisya_cd"]);
			paramCol["Kaisya_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Kaisya_nm"]);
			paramCol["Jyuryoten_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Jyuryoten_cd"]);
			paramCol["Juryoten_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Juryoten_nm"]);
			paramCol["Nyukatan_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Nyukatan_cd"]);
			paramCol["Nyukatan_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Nyukatan_nm"]);
			paramCol["Jyuryo_ymd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Jyuryo_ymd"]);
			paramCol["Syorinm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Syorinm"]);
			paramCol["Syoriymd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Syoriymd"]);
			paramCol["Syori_tm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Syori_tm"]);
			paramCol["Syukkasuryo_gokei"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Syukkasuryo_gokei"]);
			paramCol["Gokeikakutei_su"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokeikakutei_su"]);
			paramCol["Genka_kin_gokei"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Genka_kin_gokei"]);
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
				paramCol["M1scan_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1scan_cd"]);
				paramCol["M1syukka_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1syukka_su"]);
				paramCol["M1kakutei_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1kakutei_su"]);
				paramCol["M1gen_tnk"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1gen_tnk"]);
				paramCol["M1genkakin"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1genkakin"]);
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
			Te010f02Form formVO = (Te010f02Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Denpyo_bango"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Denpyo_bango"].RequestValue, formInfo["Denpyo_bango"]);
			paramCol["Siji_bango"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Siji_bango"].RequestValue, formInfo["Siji_bango"]);
			paramCol["Scm_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Scm_cd"].RequestValue, formInfo["Scm_cd"]);
			paramCol["Shukkariyu_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Shukkariyu_nm"].RequestValue, formInfo["Shukkariyu_nm"]);
			paramCol["Syukkatan_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Syukkatan_cd"].RequestValue, formInfo["Syukkatan_cd"]);
			paramCol["Syukkatan_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Syukkatan_nm"].RequestValue, formInfo["Syukkatan_nm"]);
			paramCol["Syukka_ymd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Syukka_ymd"].RequestValue, formInfo["Syukka_ymd"]);
			paramCol["Syukka_ymd"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Syukka_ymd"].RequestValue, formInfo["Syukka_ymd"]);
			paramCol["Kaisya_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Kaisya_cd"].RequestValue, formInfo["Kaisya_cd"]);
			paramCol["Kaisya_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Kaisya_nm"].RequestValue, formInfo["Kaisya_nm"]);
			paramCol["Jyuryoten_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Jyuryoten_cd"].RequestValue, formInfo["Jyuryoten_cd"]);
			paramCol["Juryoten_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Juryoten_nm"].RequestValue, formInfo["Juryoten_nm"]);
			paramCol["Nyukatan_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Nyukatan_cd"].RequestValue, formInfo["Nyukatan_cd"]);
			paramCol["Nyukatan_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Nyukatan_nm"].RequestValue, formInfo["Nyukatan_nm"]);
			paramCol["Jyuryo_ymd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Jyuryo_ymd"].RequestValue, formInfo["Jyuryo_ymd"]);
			paramCol["Jyuryo_ymd"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Jyuryo_ymd"].RequestValue, formInfo["Jyuryo_ymd"]);
			paramCol["Syorinm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Syorinm"].RequestValue, formInfo["Syorinm"]);
			paramCol["Syoriymd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Syoriymd"].RequestValue, formInfo["Syoriymd"]);
			paramCol["Syoriymd"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Syoriymd"].RequestValue, formInfo["Syoriymd"]);
			paramCol["Syori_tm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Syori_tm"].RequestValue, formInfo["Syori_tm"]);
			paramCol["Syori_tm"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Syori_tm"].RequestValue, formInfo["Syori_tm"]);
			paramCol["Syukkasuryo_gokei"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Syukkasuryo_gokei"].RequestValue, formInfo["Syukkasuryo_gokei"]);
			paramCol["Gokeikakutei_su"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokeikakutei_su"].RequestValue, formInfo["Gokeikakutei_su"]);
			paramCol["Genka_kin_gokei"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Genka_kin_gokei"].RequestValue, formInfo["Genka_kin_gokei"]);
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
				paramCol["M1scan_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1scan_cd"][i].RequestValue, formInfo["M1scan_cd"]);
				paramCol["M1syukka_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1syukka_su"][i].RequestValue, formInfo["M1syukka_su"]);
				paramCol["M1kakutei_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1kakutei_su"][i].RequestValue, formInfo["M1kakutei_su"]);
				paramCol["M1gen_tnk"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1gen_tnk"][i].RequestValue, formInfo["M1gen_tnk"]);
				paramCol["M1genkakin"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1genkakin"][i].RequestValue, formInfo["M1genkakin"]);
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
			Te010f02Form formVO = (Te010f02Form)pageContext.GetFormVO();

			//カード項目の入力値をFormVOにコピーする
			if (paramCol["Head_tenpo_cd"].UnformatValue != null)
			{
				formVO.Head_tenpo_cd = paramCol["Head_tenpo_cd"].UnformatValue;
			}
			if (paramCol["Head_tenpo_nm"].UnformatValue != null)
			{
				formVO.Head_tenpo_nm = paramCol["Head_tenpo_nm"].UnformatValue;
			}
			if (paramCol["Denpyo_bango"].UnformatValue != null)
			{
				formVO.Denpyo_bango = paramCol["Denpyo_bango"].UnformatValue;
			}
			if (paramCol["Siji_bango"].UnformatValue != null)
			{
				formVO.Siji_bango = paramCol["Siji_bango"].UnformatValue;
			}
			if (paramCol["Scm_cd"].UnformatValue != null)
			{
				formVO.Scm_cd = paramCol["Scm_cd"].UnformatValue;
			}
			if (paramCol["Shukkariyu_nm"].UnformatValue != null)
			{
				formVO.Shukkariyu_nm = paramCol["Shukkariyu_nm"].UnformatValue;
			}
			if (paramCol["Syukkatan_cd"].UnformatValue != null)
			{
				formVO.Syukkatan_cd = paramCol["Syukkatan_cd"].UnformatValue;
			}
			if (paramCol["Syukkatan_nm"].UnformatValue != null)
			{
				formVO.Syukkatan_nm = paramCol["Syukkatan_nm"].UnformatValue;
			}
			if (paramCol["Syukka_ymd"].DateFullValue != null)
			{
				formVO.Syukka_ymd = paramCol["Syukka_ymd"].DateFullValue;
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
			if (paramCol["Nyukatan_cd"].UnformatValue != null)
			{
				formVO.Nyukatan_cd = paramCol["Nyukatan_cd"].UnformatValue;
			}
			if (paramCol["Nyukatan_nm"].UnformatValue != null)
			{
				formVO.Nyukatan_nm = paramCol["Nyukatan_nm"].UnformatValue;
			}
			if (paramCol["Jyuryo_ymd"].DateFullValue != null)
			{
				formVO.Jyuryo_ymd = paramCol["Jyuryo_ymd"].DateFullValue;
			}
			if (paramCol["Syorinm"].UnformatValue != null)
			{
				formVO.Syorinm = paramCol["Syorinm"].UnformatValue;
			}
			if (paramCol["Syoriymd"].DateFullValue != null)
			{
				formVO.Syoriymd = paramCol["Syoriymd"].DateFullValue;
			}
			if (paramCol["Syori_tm"].DateFullValue != null)
			{
				formVO.Syori_tm = paramCol["Syori_tm"].DateFullValue;
			}
			if (paramCol["Syukkasuryo_gokei"].UnformatValue != null)
			{
				formVO.Syukkasuryo_gokei = paramCol["Syukkasuryo_gokei"].UnformatValue;
			}
			if (paramCol["Gokeikakutei_su"].UnformatValue != null)
			{
				formVO.Gokeikakutei_su = paramCol["Gokeikakutei_su"].UnformatValue;
			}
			if (paramCol["Genka_kin_gokei"].UnformatValue != null)
			{
				formVO.Genka_kin_gokei = paramCol["Genka_kin_gokei"].UnformatValue;
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
				Te010f02M1Form te010f02M1Form = (Te010f02M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					te010f02M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1bumon_cd"][i].UnformatValue != null)
				{
					te010f02M1Form.M1bumon_cd = paramCol["M1bumon_cd"][i].UnformatValue;
				}
				if (paramCol["M1bumonkana_nm"][i].UnformatValue != null)
				{
					te010f02M1Form.M1bumonkana_nm = paramCol["M1bumonkana_nm"][i].UnformatValue;
				}
				if (paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue != null)
				{
					te010f02M1Form.M1hinsyu_ryaku_nm = paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue;
				}
				if (paramCol["M1burando_nm"][i].UnformatValue != null)
				{
					te010f02M1Form.M1burando_nm = paramCol["M1burando_nm"][i].UnformatValue;
				}
				if (paramCol["M1jisya_hbn"][i].UnformatValue != null)
				{
					te010f02M1Form.M1jisya_hbn = paramCol["M1jisya_hbn"][i].UnformatValue;
				}
				if (paramCol["M1maker_hbn"][i].UnformatValue != null)
				{
					te010f02M1Form.M1maker_hbn = paramCol["M1maker_hbn"][i].UnformatValue;
				}
				if (paramCol["M1syonmk"][i].UnformatValue != null)
				{
					te010f02M1Form.M1syonmk = paramCol["M1syonmk"][i].UnformatValue;
				}
				if (paramCol["M1iro_nm"][i].UnformatValue != null)
				{
					te010f02M1Form.M1iro_nm = paramCol["M1iro_nm"][i].UnformatValue;
				}
				if (paramCol["M1size_nm"][i].UnformatValue != null)
				{
					te010f02M1Form.M1size_nm = paramCol["M1size_nm"][i].UnformatValue;
				}
				if (paramCol["M1scan_cd"][i].UnformatValue != null)
				{
					te010f02M1Form.M1scan_cd = paramCol["M1scan_cd"][i].UnformatValue;
				}
				if (paramCol["M1syukka_su"][i].UnformatValue != null)
				{
					te010f02M1Form.M1syukka_su = paramCol["M1syukka_su"][i].UnformatValue;
				}
				if (paramCol["M1kakutei_su"][i].UnformatValue != null)
				{
					te010f02M1Form.M1kakutei_su = paramCol["M1kakutei_su"][i].UnformatValue;
				}
				if (paramCol["M1gen_tnk"][i].UnformatValue != null)
				{
					te010f02M1Form.M1gen_tnk = paramCol["M1gen_tnk"][i].UnformatValue;
				}
				if (paramCol["M1genkakin"][i].UnformatValue != null)
				{
					te010f02M1Form.M1genkakin = paramCol["M1genkakin"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					te010f02M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					te010f02M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					te010f02M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Te010f02Form formVO, StandardCheckManager checker)
		{
			if (formVO.Head_tenpo_cd != null)
			{
				checker.DoCheck("Head_tenpo_cd", formVO.Head_tenpo_cd);
			}
			if (formVO.Head_tenpo_nm != null)
			{
				checker.DoCheck("Head_tenpo_nm", formVO.Head_tenpo_nm);
			}
			if (formVO.Denpyo_bango != null)
			{
				checker.DoCheck("Denpyo_bango", formVO.Denpyo_bango);
			}
			if (formVO.Siji_bango != null)
			{
				checker.DoCheck("Siji_bango", formVO.Siji_bango);
			}
			if (formVO.Scm_cd != null)
			{
				checker.DoCheck("Scm_cd", formVO.Scm_cd);
			}
			if (formVO.Shukkariyu_nm != null)
			{
				checker.DoCheck("Shukkariyu_nm", formVO.Shukkariyu_nm);
			}
			if (formVO.Syukkatan_cd != null)
			{
				checker.DoCheck("Syukkatan_cd", formVO.Syukkatan_cd);
			}
			if (formVO.Syukkatan_nm != null)
			{
				checker.DoCheck("Syukkatan_nm", formVO.Syukkatan_nm);
			}
			if (formVO.Syukka_ymd != null)
			{
				checker.DoCheck("Syukka_ymd", formVO.Syukka_ymd);
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
			if (formVO.Nyukatan_cd != null)
			{
				checker.DoCheck("Nyukatan_cd", formVO.Nyukatan_cd);
			}
			if (formVO.Nyukatan_nm != null)
			{
				checker.DoCheck("Nyukatan_nm", formVO.Nyukatan_nm);
			}
			if (formVO.Jyuryo_ymd != null)
			{
				checker.DoCheck("Jyuryo_ymd", formVO.Jyuryo_ymd);
			}
			if (formVO.Syorinm != null)
			{
				checker.DoCheck("Syorinm", formVO.Syorinm);
			}
			if (formVO.Syoriymd != null)
			{
				checker.DoCheck("Syoriymd", formVO.Syoriymd);
			}
			if (formVO.Syori_tm != null)
			{
				checker.DoCheck("Syori_tm", formVO.Syori_tm);
			}
			if (formVO.Syukkasuryo_gokei != null)
			{
				checker.DoCheck("Syukkasuryo_gokei", formVO.Syukkasuryo_gokei);
			}
			if (formVO.Gokeikakutei_su != null)
			{
				checker.DoCheck("Gokeikakutei_su", formVO.Gokeikakutei_su);
			}
			if (formVO.Genka_kin_gokei != null)
			{
				checker.DoCheck("Genka_kin_gokei", formVO.Genka_kin_gokei);
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
		public static void ValidateM1InputValue(Te010f02Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Te010f02M1Form te010f02M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, te010f02M1Form, i, m1List);
				if (te010f02M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", te010f02M1Form.M1rowno, i, m1List);
				}
				if (te010f02M1Form.M1bumon_cd != null)
				{
					checker.DoCheck("M1bumon_cd", te010f02M1Form.M1bumon_cd, i, m1List);
				}
				if (te010f02M1Form.M1bumonkana_nm != null)
				{
					checker.DoCheck("M1bumonkana_nm", te010f02M1Form.M1bumonkana_nm, i, m1List);
				}
				if (te010f02M1Form.M1hinsyu_ryaku_nm != null)
				{
					checker.DoCheck("M1hinsyu_ryaku_nm", te010f02M1Form.M1hinsyu_ryaku_nm, i, m1List);
				}
				if (te010f02M1Form.M1burando_nm != null)
				{
					checker.DoCheck("M1burando_nm", te010f02M1Form.M1burando_nm, i, m1List);
				}
				if (te010f02M1Form.M1jisya_hbn != null)
				{
					checker.DoCheck("M1jisya_hbn", te010f02M1Form.M1jisya_hbn, i, m1List);
				}
				if (te010f02M1Form.M1maker_hbn != null)
				{
					checker.DoCheck("M1maker_hbn", te010f02M1Form.M1maker_hbn, i, m1List);
				}
				if (te010f02M1Form.M1syonmk != null)
				{
					checker.DoCheck("M1syonmk", te010f02M1Form.M1syonmk, i, m1List);
				}
				if (te010f02M1Form.M1iro_nm != null)
				{
					checker.DoCheck("M1iro_nm", te010f02M1Form.M1iro_nm, i, m1List);
				}
				if (te010f02M1Form.M1size_nm != null)
				{
					checker.DoCheck("M1size_nm", te010f02M1Form.M1size_nm, i, m1List);
				}
				if (te010f02M1Form.M1scan_cd != null)
				{
					checker.DoCheck("M1scan_cd", te010f02M1Form.M1scan_cd, i, m1List);
				}
				if (te010f02M1Form.M1syukka_su != null)
				{
					checker.DoCheck("M1syukka_su", te010f02M1Form.M1syukka_su, i, m1List);
				}
				if (te010f02M1Form.M1kakutei_su != null)
				{
					checker.DoCheck("M1kakutei_su", te010f02M1Form.M1kakutei_su, i, m1List);
				}
				if (te010f02M1Form.M1gen_tnk != null)
				{
					checker.DoCheck("M1gen_tnk", te010f02M1Form.M1gen_tnk, i, m1List);
				}
				if (te010f02M1Form.M1genkakin != null)
				{
					checker.DoCheck("M1genkakin", te010f02M1Form.M1genkakin, i, m1List);
				}
				if (te010f02M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", te010f02M1Form.M1selectorcheckbox, i, m1List);
				}
				if (te010f02M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", te010f02M1Form.M1entersyoriflg, i, m1List);
				}
				if (te010f02M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", te010f02M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Te010f02Form formVO, StandardCodeCheckManager checker)
		{
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Te010f02Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

