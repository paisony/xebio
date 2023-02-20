using com.xebio.bo.Tf010p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Tf010p01.Request
{
  /// <summary>
  /// Tf010f02RequestHelper の概要の説明です。
  /// </summary>
  public static class Tf010f02RequestHelper
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
			Tf010f02Form formVO = (Tf010f02Form)pageContext.GetFormVO();

			//カード部を初期化する
			paramCol.InitCardItems(formInfo.GetCardItems());
			//明細「M1」部を初期化する
			paramCol.InitListItems(formInfo.GetListItems("M1"), formVO.GetList("M1").CurrentCount);
			//カード項目の入力値を取得する
			paramCol["Head_tenpo_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_nm"]);
			paramCol["Stkmodeno"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Stkmodeno"]);
			paramCol["Apply_ymd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Apply_ymd"]);
			paramCol["Shinsei_tenpo_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Shinsei_tenpo_cd"]);
			paramCol["Shinsei_tenpo_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Shinsei_tenpo_nm"]);
			paramCol["Sinseitan_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Sinseitan_cd"]);
			paramCol["Sinseitan_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Sinseitan_nm"]);
			paramCol["Denpyo_bango"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Denpyo_bango"]);
			paramCol["Sinseiriyu_kb"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Sinseiriyu_kb"]);
			paramCol["Sinseiriyu"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Sinseiriyu"]);
			paramCol["Kakuteitan_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Kakuteitan_cd"]);
			paramCol["Kakuteitan_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Kakuteitan_nm"]);
			paramCol["Kakutei_ymd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Kakutei_ymd"]);
			paramCol["Kamoku_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Kamoku_cd"]);
			paramCol["Kamoku_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Kamoku_nm"]);
			paramCol["Kyakkariyu"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Kyakkariyu"]);
			paramCol["Gyomuringi_no"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gyomuringi_no"]);
			paramCol["Jyuri_no"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Jyuri_no"]);
			paramCol["Syonin_flg_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Syonin_flg_nm"]);
			paramCol["Gokei_suryo"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokei_suryo"]);
			paramCol["Genka_kin_gokei1"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Genka_kin_gokei1"]);
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
				paramCol["M1burando_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1burando_nm"]);
				paramCol["M1maker_hbn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1maker_hbn"]);
				paramCol["M1iro_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1iro_nm"]);
				paramCol["M1scan_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1scan_cd"]);
				paramCol["M1suryo"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1suryo"]);
				paramCol["M1gen_tnk"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1gen_tnk"]);
				paramCol["M1genka_kin"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1genka_kin"]);
				paramCol["M1hinsyu_ryaku_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hinsyu_ryaku_nm"]);
				paramCol["M1jisya_hbn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1jisya_hbn"]);
				paramCol["M1syonmk"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1syonmk"]);
				paramCol["M1size_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1size_nm"]);
				paramCol["M1genbaika_tnk"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1genbaika_tnk"]);
				paramCol["M1baika_kin"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1baika_kin"]);
				paramCol["M1suryo_hdn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1suryo_hdn"]);
				paramCol["M1genka_kin_hdn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1genka_kin_hdn"]);
				paramCol["M1baika_kin_hdn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1baika_kin_hdn"]);
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
			Tf010f02Form formVO = (Tf010f02Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Stkmodeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Stkmodeno"].RequestValue, formInfo["Stkmodeno"]);
			paramCol["Apply_ymd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Apply_ymd"].RequestValue, formInfo["Apply_ymd"]);
			paramCol["Apply_ymd"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Apply_ymd"].RequestValue, formInfo["Apply_ymd"]);
			paramCol["Shinsei_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Shinsei_tenpo_cd"].RequestValue, formInfo["Shinsei_tenpo_cd"]);
			paramCol["Shinsei_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Shinsei_tenpo_nm"].RequestValue, formInfo["Shinsei_tenpo_nm"]);
			paramCol["Sinseitan_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Sinseitan_cd"].RequestValue, formInfo["Sinseitan_cd"]);
			paramCol["Sinseitan_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Sinseitan_nm"].RequestValue, formInfo["Sinseitan_nm"]);
			paramCol["Denpyo_bango"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Denpyo_bango"].RequestValue, formInfo["Denpyo_bango"]);
			paramCol["Sinseiriyu_kb"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Sinseiriyu_kb"].RequestValue, formInfo["Sinseiriyu_kb"]);
			paramCol["Sinseiriyu"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Sinseiriyu"].RequestValue, formInfo["Sinseiriyu"]);
			paramCol["Kakuteitan_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Kakuteitan_cd"].RequestValue, formInfo["Kakuteitan_cd"]);
			paramCol["Kakuteitan_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Kakuteitan_nm"].RequestValue, formInfo["Kakuteitan_nm"]);
			paramCol["Kakutei_ymd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Kakutei_ymd"].RequestValue, formInfo["Kakutei_ymd"]);
			paramCol["Kakutei_ymd"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Kakutei_ymd"].RequestValue, formInfo["Kakutei_ymd"]);
			paramCol["Kamoku_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Kamoku_cd"].RequestValue, formInfo["Kamoku_cd"]);
			paramCol["Kamoku_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Kamoku_nm"].RequestValue, formInfo["Kamoku_nm"]);
			paramCol["Kyakkariyu"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Kyakkariyu"].RequestValue, formInfo["Kyakkariyu"]);
			paramCol["Gyomuringi_no"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gyomuringi_no"].RequestValue, formInfo["Gyomuringi_no"]);
			paramCol["Jyuri_no"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Jyuri_no"].RequestValue, formInfo["Jyuri_no"]);
			paramCol["Syonin_flg_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Syonin_flg_nm"].RequestValue, formInfo["Syonin_flg_nm"]);
			paramCol["Gokei_suryo"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokei_suryo"].RequestValue, formInfo["Gokei_suryo"]);
			paramCol["Genka_kin_gokei1"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Genka_kin_gokei1"].RequestValue, formInfo["Genka_kin_gokei1"]);
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
				paramCol["M1burando_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1burando_nm"][i].RequestValue, formInfo["M1burando_nm"]);
				paramCol["M1maker_hbn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1maker_hbn"][i].RequestValue, formInfo["M1maker_hbn"]);
				paramCol["M1iro_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1iro_nm"][i].RequestValue, formInfo["M1iro_nm"]);
				paramCol["M1scan_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1scan_cd"][i].RequestValue, formInfo["M1scan_cd"]);
				paramCol["M1suryo"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1suryo"][i].RequestValue, formInfo["M1suryo"]);
				paramCol["M1gen_tnk"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1gen_tnk"][i].RequestValue, formInfo["M1gen_tnk"]);
				paramCol["M1genka_kin"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1genka_kin"][i].RequestValue, formInfo["M1genka_kin"]);
				paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hinsyu_ryaku_nm"][i].RequestValue, formInfo["M1hinsyu_ryaku_nm"]);
				paramCol["M1jisya_hbn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1jisya_hbn"][i].RequestValue, formInfo["M1jisya_hbn"]);
				paramCol["M1syonmk"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1syonmk"][i].RequestValue, formInfo["M1syonmk"]);
				paramCol["M1size_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1size_nm"][i].RequestValue, formInfo["M1size_nm"]);
				paramCol["M1genbaika_tnk"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1genbaika_tnk"][i].RequestValue, formInfo["M1genbaika_tnk"]);
				paramCol["M1baika_kin"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1baika_kin"][i].RequestValue, formInfo["M1baika_kin"]);
				paramCol["M1suryo_hdn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1suryo_hdn"][i].RequestValue, formInfo["M1suryo_hdn"]);
				paramCol["M1genka_kin_hdn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1genka_kin_hdn"][i].RequestValue, formInfo["M1genka_kin_hdn"]);
				paramCol["M1baika_kin_hdn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1baika_kin_hdn"][i].RequestValue, formInfo["M1baika_kin_hdn"]);
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
			Tf010f02Form formVO = (Tf010f02Form)pageContext.GetFormVO();

			//カード項目の入力値をFormVOにコピーする
			if (paramCol["Head_tenpo_cd"].UnformatValue != null)
			{
				formVO.Head_tenpo_cd = paramCol["Head_tenpo_cd"].UnformatValue;
			}
			if (paramCol["Head_tenpo_nm"].UnformatValue != null)
			{
				formVO.Head_tenpo_nm = paramCol["Head_tenpo_nm"].UnformatValue;
			}
			if (paramCol["Stkmodeno"].UnformatValue != null)
			{
				formVO.Stkmodeno = paramCol["Stkmodeno"].UnformatValue;
			}
			if (paramCol["Apply_ymd"].DateFullValue != null)
			{
				formVO.Apply_ymd = paramCol["Apply_ymd"].DateFullValue;
			}
			if (paramCol["Shinsei_tenpo_cd"].UnformatValue != null)
			{
				formVO.Shinsei_tenpo_cd = paramCol["Shinsei_tenpo_cd"].UnformatValue;
			}
			if (paramCol["Shinsei_tenpo_nm"].UnformatValue != null)
			{
				formVO.Shinsei_tenpo_nm = paramCol["Shinsei_tenpo_nm"].UnformatValue;
			}
			if (paramCol["Sinseitan_cd"].UnformatValue != null)
			{
				formVO.Sinseitan_cd = paramCol["Sinseitan_cd"].UnformatValue;
			}
			if (paramCol["Sinseitan_nm"].UnformatValue != null)
			{
				formVO.Sinseitan_nm = paramCol["Sinseitan_nm"].UnformatValue;
			}
			if (paramCol["Denpyo_bango"].UnformatValue != null)
			{
				formVO.Denpyo_bango = paramCol["Denpyo_bango"].UnformatValue;
			}
			if (paramCol["Sinseiriyu_kb"].UnformatValue != null)
			{
				formVO.Sinseiriyu_kb = paramCol["Sinseiriyu_kb"].UnformatValue;
			}
			if (paramCol["Sinseiriyu"].UnformatValue != null)
			{
				formVO.Sinseiriyu = paramCol["Sinseiriyu"].UnformatValue;
			}
			if (paramCol["Kakuteitan_cd"].UnformatValue != null)
			{
				formVO.Kakuteitan_cd = paramCol["Kakuteitan_cd"].UnformatValue;
			}
			if (paramCol["Kakuteitan_nm"].UnformatValue != null)
			{
				formVO.Kakuteitan_nm = paramCol["Kakuteitan_nm"].UnformatValue;
			}
			if (paramCol["Kakutei_ymd"].DateFullValue != null)
			{
				formVO.Kakutei_ymd = paramCol["Kakutei_ymd"].DateFullValue;
			}
			if (paramCol["Kamoku_cd"].UnformatValue != null)
			{
				formVO.Kamoku_cd = paramCol["Kamoku_cd"].UnformatValue;
			}
			if (paramCol["Kamoku_nm"].UnformatValue != null)
			{
				formVO.Kamoku_nm = paramCol["Kamoku_nm"].UnformatValue;
			}
			if (paramCol["Kyakkariyu"].UnformatValue != null)
			{
				formVO.Kyakkariyu = paramCol["Kyakkariyu"].UnformatValue;
			}
			if (paramCol["Gyomuringi_no"].UnformatValue != null)
			{
				formVO.Gyomuringi_no = paramCol["Gyomuringi_no"].UnformatValue;
			}
			if (paramCol["Jyuri_no"].UnformatValue != null)
			{
				formVO.Jyuri_no = paramCol["Jyuri_no"].UnformatValue;
			}
			if (paramCol["Syonin_flg_nm"].UnformatValue != null)
			{
				formVO.Syonin_flg_nm = paramCol["Syonin_flg_nm"].UnformatValue;
			}
			if (paramCol["Gokei_suryo"].UnformatValue != null)
			{
				formVO.Gokei_suryo = paramCol["Gokei_suryo"].UnformatValue;
			}
			if (paramCol["Genka_kin_gokei1"].UnformatValue != null)
			{
				formVO.Genka_kin_gokei1 = paramCol["Genka_kin_gokei1"].UnformatValue;
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
				Tf010f02M1Form tf010f02M1Form = (Tf010f02M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					tf010f02M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1bumon_cd"][i].UnformatValue != null)
				{
					tf010f02M1Form.M1bumon_cd = paramCol["M1bumon_cd"][i].UnformatValue;
				}
				if (paramCol["M1bumonkana_nm"][i].UnformatValue != null)
				{
					tf010f02M1Form.M1bumonkana_nm = paramCol["M1bumonkana_nm"][i].UnformatValue;
				}
				if (paramCol["M1burando_nm"][i].UnformatValue != null)
				{
					tf010f02M1Form.M1burando_nm = paramCol["M1burando_nm"][i].UnformatValue;
				}
				if (paramCol["M1maker_hbn"][i].UnformatValue != null)
				{
					tf010f02M1Form.M1maker_hbn = paramCol["M1maker_hbn"][i].UnformatValue;
				}
				if (paramCol["M1iro_nm"][i].UnformatValue != null)
				{
					tf010f02M1Form.M1iro_nm = paramCol["M1iro_nm"][i].UnformatValue;
				}
				if (paramCol["M1scan_cd"][i].UnformatValue != null)
				{
					tf010f02M1Form.M1scan_cd = paramCol["M1scan_cd"][i].UnformatValue;
				}
				if (paramCol["M1suryo"][i].UnformatValue != null)
				{
					tf010f02M1Form.M1suryo = paramCol["M1suryo"][i].UnformatValue;
				}
				if (paramCol["M1gen_tnk"][i].UnformatValue != null)
				{
					tf010f02M1Form.M1gen_tnk = paramCol["M1gen_tnk"][i].UnformatValue;
				}
				if (paramCol["M1genka_kin"][i].UnformatValue != null)
				{
					tf010f02M1Form.M1genka_kin = paramCol["M1genka_kin"][i].UnformatValue;
				}
				if (paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue != null)
				{
					tf010f02M1Form.M1hinsyu_ryaku_nm = paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue;
				}
				if (paramCol["M1jisya_hbn"][i].UnformatValue != null)
				{
					tf010f02M1Form.M1jisya_hbn = paramCol["M1jisya_hbn"][i].UnformatValue;
				}
				if (paramCol["M1syonmk"][i].UnformatValue != null)
				{
					tf010f02M1Form.M1syonmk = paramCol["M1syonmk"][i].UnformatValue;
				}
				if (paramCol["M1size_nm"][i].UnformatValue != null)
				{
					tf010f02M1Form.M1size_nm = paramCol["M1size_nm"][i].UnformatValue;
				}
				if (paramCol["M1genbaika_tnk"][i].UnformatValue != null)
				{
					tf010f02M1Form.M1genbaika_tnk = paramCol["M1genbaika_tnk"][i].UnformatValue;
				}
				if (paramCol["M1baika_kin"][i].UnformatValue != null)
				{
					tf010f02M1Form.M1baika_kin = paramCol["M1baika_kin"][i].UnformatValue;
				}
				if (paramCol["M1suryo_hdn"][i].UnformatValue != null)
				{
					tf010f02M1Form.M1suryo_hdn = paramCol["M1suryo_hdn"][i].UnformatValue;
				}
				if (paramCol["M1genka_kin_hdn"][i].UnformatValue != null)
				{
					tf010f02M1Form.M1genka_kin_hdn = paramCol["M1genka_kin_hdn"][i].UnformatValue;
				}
				if (paramCol["M1baika_kin_hdn"][i].UnformatValue != null)
				{
					tf010f02M1Form.M1baika_kin_hdn = paramCol["M1baika_kin_hdn"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					tf010f02M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					tf010f02M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					tf010f02M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Tf010f02Form formVO, StandardCheckManager checker)
		{
			if (formVO.Head_tenpo_cd != null)
			{
				checker.DoCheck("Head_tenpo_cd", formVO.Head_tenpo_cd);
			}
			if (formVO.Head_tenpo_nm != null)
			{
				checker.DoCheck("Head_tenpo_nm", formVO.Head_tenpo_nm);
			}
			if (formVO.Stkmodeno != null)
			{
				checker.DoCheck("Stkmodeno", formVO.Stkmodeno);
			}
			if (formVO.Apply_ymd != null)
			{
				checker.DoCheck("Apply_ymd", formVO.Apply_ymd);
			}
			if (formVO.Shinsei_tenpo_cd != null)
			{
				checker.DoCheck("Shinsei_tenpo_cd", formVO.Shinsei_tenpo_cd);
			}
			if (formVO.Shinsei_tenpo_nm != null)
			{
				checker.DoCheck("Shinsei_tenpo_nm", formVO.Shinsei_tenpo_nm);
			}
			if (formVO.Sinseitan_cd != null)
			{
				checker.DoCheck("Sinseitan_cd", formVO.Sinseitan_cd);
			}
			if (formVO.Sinseitan_nm != null)
			{
				checker.DoCheck("Sinseitan_nm", formVO.Sinseitan_nm);
			}
			if (formVO.Denpyo_bango != null)
			{
				checker.DoCheck("Denpyo_bango", formVO.Denpyo_bango);
			}
			if (formVO.Sinseiriyu_kb != null)
			{
				checker.DoCheck("Sinseiriyu_kb", formVO.Sinseiriyu_kb);
			}
			if (formVO.Sinseiriyu != null)
			{
				checker.DoCheck("Sinseiriyu", formVO.Sinseiriyu);
			}
			if (formVO.Kakuteitan_cd != null)
			{
				checker.DoCheck("Kakuteitan_cd", formVO.Kakuteitan_cd);
			}
			if (formVO.Kakuteitan_nm != null)
			{
				checker.DoCheck("Kakuteitan_nm", formVO.Kakuteitan_nm);
			}
			if (formVO.Kakutei_ymd != null)
			{
				checker.DoCheck("Kakutei_ymd", formVO.Kakutei_ymd);
			}
			if (formVO.Kamoku_cd != null)
			{
				checker.DoCheck("Kamoku_cd", formVO.Kamoku_cd);
			}
			if (formVO.Kamoku_nm != null)
			{
				checker.DoCheck("Kamoku_nm", formVO.Kamoku_nm);
			}
			if (formVO.Kyakkariyu != null)
			{
				checker.DoCheck("Kyakkariyu", formVO.Kyakkariyu);
			}
			if (formVO.Gyomuringi_no != null)
			{
				checker.DoCheck("Gyomuringi_no", formVO.Gyomuringi_no);
			}
			if (formVO.Jyuri_no != null)
			{
				checker.DoCheck("Jyuri_no", formVO.Jyuri_no);
			}
			if (formVO.Syonin_flg_nm != null)
			{
				checker.DoCheck("Syonin_flg_nm", formVO.Syonin_flg_nm);
			}
			if (formVO.Gokei_suryo != null)
			{
				checker.DoCheck("Gokei_suryo", formVO.Gokei_suryo);
			}
			if (formVO.Genka_kin_gokei1 != null)
			{
				checker.DoCheck("Genka_kin_gokei1", formVO.Genka_kin_gokei1);
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
		public static void ValidateM1InputValue(Tf010f02Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Tf010f02M1Form tf010f02M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, tf010f02M1Form, i, m1List);
				if (tf010f02M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", tf010f02M1Form.M1rowno, i, m1List);
				}
				if (tf010f02M1Form.M1bumon_cd != null)
				{
					checker.DoCheck("M1bumon_cd", tf010f02M1Form.M1bumon_cd, i, m1List);
				}
				if (tf010f02M1Form.M1bumonkana_nm != null)
				{
					checker.DoCheck("M1bumonkana_nm", tf010f02M1Form.M1bumonkana_nm, i, m1List);
				}
				if (tf010f02M1Form.M1burando_nm != null)
				{
					checker.DoCheck("M1burando_nm", tf010f02M1Form.M1burando_nm, i, m1List);
				}
				if (tf010f02M1Form.M1maker_hbn != null)
				{
					checker.DoCheck("M1maker_hbn", tf010f02M1Form.M1maker_hbn, i, m1List);
				}
				if (tf010f02M1Form.M1iro_nm != null)
				{
					checker.DoCheck("M1iro_nm", tf010f02M1Form.M1iro_nm, i, m1List);
				}
				if (tf010f02M1Form.M1scan_cd != null)
				{
					checker.DoCheck("M1scan_cd", tf010f02M1Form.M1scan_cd, i, m1List);
				}
				if (tf010f02M1Form.M1suryo != null)
				{
					checker.DoCheck("M1suryo", tf010f02M1Form.M1suryo, i, m1List);
				}
				if (tf010f02M1Form.M1gen_tnk != null)
				{
					checker.DoCheck("M1gen_tnk", tf010f02M1Form.M1gen_tnk, i, m1List);
				}
				if (tf010f02M1Form.M1genka_kin != null)
				{
					checker.DoCheck("M1genka_kin", tf010f02M1Form.M1genka_kin, i, m1List);
				}
				if (tf010f02M1Form.M1hinsyu_ryaku_nm != null)
				{
					checker.DoCheck("M1hinsyu_ryaku_nm", tf010f02M1Form.M1hinsyu_ryaku_nm, i, m1List);
				}
				if (tf010f02M1Form.M1jisya_hbn != null)
				{
					checker.DoCheck("M1jisya_hbn", tf010f02M1Form.M1jisya_hbn, i, m1List);
				}
				if (tf010f02M1Form.M1syonmk != null)
				{
					checker.DoCheck("M1syonmk", tf010f02M1Form.M1syonmk, i, m1List);
				}
				if (tf010f02M1Form.M1size_nm != null)
				{
					checker.DoCheck("M1size_nm", tf010f02M1Form.M1size_nm, i, m1List);
				}
				if (tf010f02M1Form.M1genbaika_tnk != null)
				{
					checker.DoCheck("M1genbaika_tnk", tf010f02M1Form.M1genbaika_tnk, i, m1List);
				}
				if (tf010f02M1Form.M1baika_kin != null)
				{
					checker.DoCheck("M1baika_kin", tf010f02M1Form.M1baika_kin, i, m1List);
				}
				if (tf010f02M1Form.M1suryo_hdn != null)
				{
					checker.DoCheck("M1suryo_hdn", tf010f02M1Form.M1suryo_hdn, i, m1List);
				}
				if (tf010f02M1Form.M1genka_kin_hdn != null)
				{
					checker.DoCheck("M1genka_kin_hdn", tf010f02M1Form.M1genka_kin_hdn, i, m1List);
				}
				if (tf010f02M1Form.M1baika_kin_hdn != null)
				{
					checker.DoCheck("M1baika_kin_hdn", tf010f02M1Form.M1baika_kin_hdn, i, m1List);
				}
				if (tf010f02M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", tf010f02M1Form.M1selectorcheckbox, i, m1List);
				}
				if (tf010f02M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", tf010f02M1Form.M1entersyoriflg, i, m1List);
				}
				if (tf010f02M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", tf010f02M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Tf010f02Form formVO, StandardCodeCheckManager checker)
		{
			checker.DoCheck("Btnkamokucd", formVO);
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Tf010f02Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

