using com.xebio.bo.Tk030p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Tk030p01.Request
{
  /// <summary>
  /// Tk030f01RequestHelper の概要の説明です。
  /// </summary>
  public static class Tk030f01RequestHelper
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
			Tk030f01Form formVO = (Tk030f01Form)pageContext.GetFormVO();

			//カード部を初期化する
			paramCol.InitCardItems(formInfo.GetCardItems());
			//明細「M1」部を初期化する
			paramCol.InitListItems(formInfo.GetListItems("M1"), formVO.GetList("M1").CurrentCount);
			//カード項目の入力値を取得する
			paramCol["Head_tenpo_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_nm"]);
			paramCol["Syori_ym"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Syori_ym"]);
			paramCol["Tenpo_cd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tenpo_cd_from"]);
			paramCol["Tenpo_nm_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tenpo_nm_from"]);
			paramCol["Tenpo_cd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tenpo_cd_to"]);
			paramCol["Tenpo_nm_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tenpo_nm_to"]);
			paramCol["Searchcnt"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Searchcnt"]);
			paramCol["Gokei_suryo"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokei_suryo"]);
			paramCol["Haibun_kin_gokei"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Haibun_kin_gokei"]);
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
				paramCol["M1tenpo_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tenpo_cd"]);
				paramCol["M1bumon_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1bumon_cd"]);
				paramCol["M1hinsyu_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hinsyu_cd"]);
				paramCol["M1burando_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1burando_nm"]);
				paramCol["M1jisya_hbn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1jisya_hbn"]);
				paramCol["M1hanbaikanryo_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hanbaikanryo_ymd"]);
				paramCol["M1maker_hbn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1maker_hbn"]);
				paramCol["M1syonmk"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1syonmk"]);
				paramCol["M1scan_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1scan_cd"]);
				paramCol["M1iro_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1iro_nm"]);
				paramCol["M1size_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1size_nm"]);
				paramCol["M1genbaika_tnk"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1genbaika_tnk"]);
				paramCol["M1hyokason_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hyokason_su"]);
				paramCol["M1gen_tnk"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1gen_tnk"]);
				paramCol["M1haibun_kin"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1haibun_kin"]);
				paramCol["M1nyuryoku_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1nyuryoku_ymd"]);
				paramCol["M1apply_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1apply_ymd"]);
				paramCol["M1nyuryokusha_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1nyuryokusha_cd"]);
				paramCol["M1sinseisya_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1sinseisya_cd"]);
				paramCol["M1hyokasonsyubetsu_kb"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hyokasonsyubetsu_kb"]);
				paramCol["M1hyokasonriyu"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hyokasonriyu"]);
				paramCol["M1kyakkariyu_kb"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1kyakkariyu_kb"]);
				paramCol["M1kyakkariyu"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1kyakkariyu"]);
				paramCol["M1syonin_flg"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1syonin_flg"]);
				paramCol["M1kyakka_flg"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1kyakka_flg"]);
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
			Tk030f01Form formVO = (Tk030f01Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Syori_ym"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Syori_ym"].RequestValue, formInfo["Syori_ym"]);
			paramCol["Tenpo_cd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tenpo_cd_from"].RequestValue, formInfo["Tenpo_cd_from"]);
			paramCol["Tenpo_nm_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tenpo_nm_from"].RequestValue, formInfo["Tenpo_nm_from"]);
			paramCol["Tenpo_cd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tenpo_cd_to"].RequestValue, formInfo["Tenpo_cd_to"]);
			paramCol["Tenpo_nm_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tenpo_nm_to"].RequestValue, formInfo["Tenpo_nm_to"]);
			paramCol["Searchcnt"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Searchcnt"].RequestValue, formInfo["Searchcnt"]);
			paramCol["Gokei_suryo"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokei_suryo"].RequestValue, formInfo["Gokei_suryo"]);
			paramCol["Haibun_kin_gokei"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Haibun_kin_gokei"].RequestValue, formInfo["Haibun_kin_gokei"]);
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
				paramCol["M1tenpo_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tenpo_cd"][i].RequestValue, formInfo["M1tenpo_cd"]);
				paramCol["M1bumon_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1bumon_cd"][i].RequestValue, formInfo["M1bumon_cd"]);
				paramCol["M1hinsyu_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hinsyu_cd"][i].RequestValue, formInfo["M1hinsyu_cd"]);
				paramCol["M1burando_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1burando_nm"][i].RequestValue, formInfo["M1burando_nm"]);
				paramCol["M1jisya_hbn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1jisya_hbn"][i].RequestValue, formInfo["M1jisya_hbn"]);
				paramCol["M1hanbaikanryo_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hanbaikanryo_ymd"][i].RequestValue, formInfo["M1hanbaikanryo_ymd"]);
				paramCol["M1hanbaikanryo_ymd"][i].DateFullValue = RequestParameterUtil.GetDateFullValue(
					paramCol["M1hanbaikanryo_ymd"][i].RequestValue, formInfo["M1hanbaikanryo_ymd"]);
				paramCol["M1maker_hbn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1maker_hbn"][i].RequestValue, formInfo["M1maker_hbn"]);
				paramCol["M1syonmk"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1syonmk"][i].RequestValue, formInfo["M1syonmk"]);
				paramCol["M1scan_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1scan_cd"][i].RequestValue, formInfo["M1scan_cd"]);
				paramCol["M1iro_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1iro_nm"][i].RequestValue, formInfo["M1iro_nm"]);
				paramCol["M1size_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1size_nm"][i].RequestValue, formInfo["M1size_nm"]);
				paramCol["M1genbaika_tnk"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1genbaika_tnk"][i].RequestValue, formInfo["M1genbaika_tnk"]);
				paramCol["M1hyokason_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hyokason_su"][i].RequestValue, formInfo["M1hyokason_su"]);
				paramCol["M1gen_tnk"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1gen_tnk"][i].RequestValue, formInfo["M1gen_tnk"]);
				paramCol["M1haibun_kin"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1haibun_kin"][i].RequestValue, formInfo["M1haibun_kin"]);
				paramCol["M1nyuryoku_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1nyuryoku_ymd"][i].RequestValue, formInfo["M1nyuryoku_ymd"]);
				paramCol["M1apply_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1apply_ymd"][i].RequestValue, formInfo["M1apply_ymd"]);
				paramCol["M1nyuryokusha_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1nyuryokusha_cd"][i].RequestValue, formInfo["M1nyuryokusha_cd"]);
				paramCol["M1sinseisya_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1sinseisya_cd"][i].RequestValue, formInfo["M1sinseisya_cd"]);
				paramCol["M1hyokasonsyubetsu_kb"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hyokasonsyubetsu_kb"][i].RequestValue, formInfo["M1hyokasonsyubetsu_kb"]);
				paramCol["M1hyokasonriyu"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hyokasonriyu"][i].RequestValue, formInfo["M1hyokasonriyu"]);
				paramCol["M1kyakkariyu_kb"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1kyakkariyu_kb"][i].RequestValue, formInfo["M1kyakkariyu_kb"]);
				paramCol["M1kyakkariyu"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1kyakkariyu"][i].RequestValue, formInfo["M1kyakkariyu"]);
				paramCol["M1syonin_flg"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1syonin_flg"][i].RequestValue, formInfo["M1syonin_flg"]);
				paramCol["M1kyakka_flg"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1kyakka_flg"][i].RequestValue, formInfo["M1kyakka_flg"]);
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
			Tk030f01Form formVO = (Tk030f01Form)pageContext.GetFormVO();

			//カード項目の入力値をFormVOにコピーする
			if (paramCol["Head_tenpo_cd"].UnformatValue != null)
			{
				formVO.Head_tenpo_cd = paramCol["Head_tenpo_cd"].UnformatValue;
			}
			if (paramCol["Head_tenpo_nm"].UnformatValue != null)
			{
				formVO.Head_tenpo_nm = paramCol["Head_tenpo_nm"].UnformatValue;
			}
			if (paramCol["Syori_ym"].UnformatValue != null)
			{
				formVO.Syori_ym = paramCol["Syori_ym"].UnformatValue;
			}
			if (paramCol["Tenpo_cd_from"].UnformatValue != null)
			{
				formVO.Tenpo_cd_from = paramCol["Tenpo_cd_from"].UnformatValue;
			}
			if (paramCol["Tenpo_nm_from"].UnformatValue != null)
			{
				formVO.Tenpo_nm_from = paramCol["Tenpo_nm_from"].UnformatValue;
			}
			if (paramCol["Tenpo_cd_to"].UnformatValue != null)
			{
				formVO.Tenpo_cd_to = paramCol["Tenpo_cd_to"].UnformatValue;
			}
			if (paramCol["Tenpo_nm_to"].UnformatValue != null)
			{
				formVO.Tenpo_nm_to = paramCol["Tenpo_nm_to"].UnformatValue;
			}
			if (paramCol["Searchcnt"].UnformatValue != null)
			{
				formVO.Searchcnt = paramCol["Searchcnt"].UnformatValue;
			}
			if (paramCol["Gokei_suryo"].UnformatValue != null)
			{
				formVO.Gokei_suryo = paramCol["Gokei_suryo"].UnformatValue;
			}
			if (paramCol["Haibun_kin_gokei"].UnformatValue != null)
			{
				formVO.Haibun_kin_gokei = paramCol["Haibun_kin_gokei"].UnformatValue;
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
				Tk030f01M1Form tk030f01M1Form = (Tk030f01M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					tk030f01M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1tenpo_cd"][i].UnformatValue != null)
				{
					tk030f01M1Form.M1tenpo_cd = paramCol["M1tenpo_cd"][i].UnformatValue;
				}
				if (paramCol["M1bumon_cd"][i].UnformatValue != null)
				{
					tk030f01M1Form.M1bumon_cd = paramCol["M1bumon_cd"][i].UnformatValue;
				}
				if (paramCol["M1hinsyu_cd"][i].UnformatValue != null)
				{
					tk030f01M1Form.M1hinsyu_cd = paramCol["M1hinsyu_cd"][i].UnformatValue;
				}
				if (paramCol["M1burando_nm"][i].UnformatValue != null)
				{
					tk030f01M1Form.M1burando_nm = paramCol["M1burando_nm"][i].UnformatValue;
				}
				if (paramCol["M1jisya_hbn"][i].UnformatValue != null)
				{
					tk030f01M1Form.M1jisya_hbn = paramCol["M1jisya_hbn"][i].UnformatValue;
				}
				if (paramCol["M1hanbaikanryo_ymd"][i].DateFullValue != null)
				{
					tk030f01M1Form.M1hanbaikanryo_ymd = paramCol["M1hanbaikanryo_ymd"][i].DateFullValue;
				}
				if (paramCol["M1maker_hbn"][i].UnformatValue != null)
				{
					tk030f01M1Form.M1maker_hbn = paramCol["M1maker_hbn"][i].UnformatValue;
				}
				if (paramCol["M1syonmk"][i].UnformatValue != null)
				{
					tk030f01M1Form.M1syonmk = paramCol["M1syonmk"][i].UnformatValue;
				}
				if (paramCol["M1scan_cd"][i].UnformatValue != null)
				{
					tk030f01M1Form.M1scan_cd = paramCol["M1scan_cd"][i].UnformatValue;
				}
				if (paramCol["M1iro_nm"][i].UnformatValue != null)
				{
					tk030f01M1Form.M1iro_nm = paramCol["M1iro_nm"][i].UnformatValue;
				}
				if (paramCol["M1size_nm"][i].UnformatValue != null)
				{
					tk030f01M1Form.M1size_nm = paramCol["M1size_nm"][i].UnformatValue;
				}
				if (paramCol["M1genbaika_tnk"][i].UnformatValue != null)
				{
					tk030f01M1Form.M1genbaika_tnk = paramCol["M1genbaika_tnk"][i].UnformatValue;
				}
				if (paramCol["M1hyokason_su"][i].UnformatValue != null)
				{
					tk030f01M1Form.M1hyokason_su = paramCol["M1hyokason_su"][i].UnformatValue;
				}
				if (paramCol["M1gen_tnk"][i].UnformatValue != null)
				{
					tk030f01M1Form.M1gen_tnk = paramCol["M1gen_tnk"][i].UnformatValue;
				}
				if (paramCol["M1haibun_kin"][i].UnformatValue != null)
				{
					tk030f01M1Form.M1haibun_kin = paramCol["M1haibun_kin"][i].UnformatValue;
				}
				if (paramCol["M1nyuryoku_ymd"][i].UnformatValue != null)
				{
					tk030f01M1Form.M1nyuryoku_ymd = paramCol["M1nyuryoku_ymd"][i].UnformatValue;
				}
				if (paramCol["M1apply_ymd"][i].UnformatValue != null)
				{
					tk030f01M1Form.M1apply_ymd = paramCol["M1apply_ymd"][i].UnformatValue;
				}
				if (paramCol["M1nyuryokusha_cd"][i].UnformatValue != null)
				{
					tk030f01M1Form.M1nyuryokusha_cd = paramCol["M1nyuryokusha_cd"][i].UnformatValue;
				}
				if (paramCol["M1sinseisya_cd"][i].UnformatValue != null)
				{
					tk030f01M1Form.M1sinseisya_cd = paramCol["M1sinseisya_cd"][i].UnformatValue;
				}
				if (paramCol["M1hyokasonsyubetsu_kb"][i].UnformatValue != null)
				{
					tk030f01M1Form.M1hyokasonsyubetsu_kb = paramCol["M1hyokasonsyubetsu_kb"][i].UnformatValue;
				}
				if (paramCol["M1hyokasonriyu"][i].UnformatValue != null)
				{
					tk030f01M1Form.M1hyokasonriyu = paramCol["M1hyokasonriyu"][i].UnformatValue;
				}
				if (paramCol["M1kyakkariyu_kb"][i].UnformatValue != null)
				{
					tk030f01M1Form.M1kyakkariyu_kb = paramCol["M1kyakkariyu_kb"][i].UnformatValue;
				}
				if (paramCol["M1kyakkariyu"][i].UnformatValue != null)
				{
					tk030f01M1Form.M1kyakkariyu = paramCol["M1kyakkariyu"][i].UnformatValue;
				}
				if (paramCol["M1syonin_flg"][i].UnformatValue != null)
				{
					tk030f01M1Form.M1syonin_flg = paramCol["M1syonin_flg"][i].UnformatValue;
				}
				if (paramCol["M1kyakka_flg"][i].UnformatValue != null)
				{
					tk030f01M1Form.M1kyakka_flg = paramCol["M1kyakka_flg"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					tk030f01M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					tk030f01M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					tk030f01M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Tk030f01Form formVO, StandardCheckManager checker)
		{
			if (formVO.Head_tenpo_cd != null)
			{
				checker.DoCheck("Head_tenpo_cd", formVO.Head_tenpo_cd);
			}
			if (formVO.Head_tenpo_nm != null)
			{
				checker.DoCheck("Head_tenpo_nm", formVO.Head_tenpo_nm);
			}
			if (formVO.Syori_ym != null)
			{
				checker.DoCheck("Syori_ym", formVO.Syori_ym);
			}
			if (formVO.Tenpo_cd_from != null)
			{
				checker.DoCheck("Tenpo_cd_from", formVO.Tenpo_cd_from);
			}
			if (formVO.Tenpo_nm_from != null)
			{
				checker.DoCheck("Tenpo_nm_from", formVO.Tenpo_nm_from);
			}
			if (formVO.Tenpo_cd_to != null)
			{
				checker.DoCheck("Tenpo_cd_to", formVO.Tenpo_cd_to);
			}
			if (formVO.Tenpo_nm_to != null)
			{
				checker.DoCheck("Tenpo_nm_to", formVO.Tenpo_nm_to);
			}
			if (formVO.Searchcnt != null)
			{
				checker.DoCheck("Searchcnt", formVO.Searchcnt);
			}
			if (formVO.Gokei_suryo != null)
			{
				checker.DoCheck("Gokei_suryo", formVO.Gokei_suryo);
			}
			if (formVO.Haibun_kin_gokei != null)
			{
				checker.DoCheck("Haibun_kin_gokei", formVO.Haibun_kin_gokei);
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
		public static void ValidateM1InputValue(Tk030f01Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Tk030f01M1Form tk030f01M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, tk030f01M1Form, i, m1List);
				if (tk030f01M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", tk030f01M1Form.M1rowno, i, m1List);
				}
				if (tk030f01M1Form.M1tenpo_cd != null)
				{
					checker.DoCheck("M1tenpo_cd", tk030f01M1Form.M1tenpo_cd, i, m1List);
				}
				if (tk030f01M1Form.M1bumon_cd != null)
				{
					checker.DoCheck("M1bumon_cd", tk030f01M1Form.M1bumon_cd, i, m1List);
				}
				if (tk030f01M1Form.M1hinsyu_cd != null)
				{
					checker.DoCheck("M1hinsyu_cd", tk030f01M1Form.M1hinsyu_cd, i, m1List);
				}
				if (tk030f01M1Form.M1burando_nm != null)
				{
					checker.DoCheck("M1burando_nm", tk030f01M1Form.M1burando_nm, i, m1List);
				}
				if (tk030f01M1Form.M1jisya_hbn != null)
				{
					checker.DoCheck("M1jisya_hbn", tk030f01M1Form.M1jisya_hbn, i, m1List);
				}
				if (tk030f01M1Form.M1hanbaikanryo_ymd != null)
				{
					checker.DoCheck("M1hanbaikanryo_ymd", tk030f01M1Form.M1hanbaikanryo_ymd, i, m1List);
				}
				if (tk030f01M1Form.M1maker_hbn != null)
				{
					checker.DoCheck("M1maker_hbn", tk030f01M1Form.M1maker_hbn, i, m1List);
				}
				if (tk030f01M1Form.M1syonmk != null)
				{
					checker.DoCheck("M1syonmk", tk030f01M1Form.M1syonmk, i, m1List);
				}
				if (tk030f01M1Form.M1scan_cd != null)
				{
					checker.DoCheck("M1scan_cd", tk030f01M1Form.M1scan_cd, i, m1List);
				}
				if (tk030f01M1Form.M1iro_nm != null)
				{
					checker.DoCheck("M1iro_nm", tk030f01M1Form.M1iro_nm, i, m1List);
				}
				if (tk030f01M1Form.M1size_nm != null)
				{
					checker.DoCheck("M1size_nm", tk030f01M1Form.M1size_nm, i, m1List);
				}
				if (tk030f01M1Form.M1genbaika_tnk != null)
				{
					checker.DoCheck("M1genbaika_tnk", tk030f01M1Form.M1genbaika_tnk, i, m1List);
				}
				if (tk030f01M1Form.M1hyokason_su != null)
				{
					checker.DoCheck("M1hyokason_su", tk030f01M1Form.M1hyokason_su, i, m1List);
				}
				if (tk030f01M1Form.M1gen_tnk != null)
				{
					checker.DoCheck("M1gen_tnk", tk030f01M1Form.M1gen_tnk, i, m1List);
				}
				if (tk030f01M1Form.M1haibun_kin != null)
				{
					checker.DoCheck("M1haibun_kin", tk030f01M1Form.M1haibun_kin, i, m1List);
				}
				if (tk030f01M1Form.M1nyuryoku_ymd != null)
				{
					checker.DoCheck("M1nyuryoku_ymd", tk030f01M1Form.M1nyuryoku_ymd, i, m1List);
				}
				if (tk030f01M1Form.M1apply_ymd != null)
				{
					checker.DoCheck("M1apply_ymd", tk030f01M1Form.M1apply_ymd, i, m1List);
				}
				if (tk030f01M1Form.M1nyuryokusha_cd != null)
				{
					checker.DoCheck("M1nyuryokusha_cd", tk030f01M1Form.M1nyuryokusha_cd, i, m1List);
				}
				if (tk030f01M1Form.M1sinseisya_cd != null)
				{
					checker.DoCheck("M1sinseisya_cd", tk030f01M1Form.M1sinseisya_cd, i, m1List);
				}
				if (tk030f01M1Form.M1hyokasonsyubetsu_kb != null)
				{
					checker.DoCheck("M1hyokasonsyubetsu_kb", tk030f01M1Form.M1hyokasonsyubetsu_kb, i, m1List);
				}
				if (tk030f01M1Form.M1hyokasonriyu != null)
				{
					checker.DoCheck("M1hyokasonriyu", tk030f01M1Form.M1hyokasonriyu, i, m1List);
				}
				if (tk030f01M1Form.M1kyakkariyu_kb != null)
				{
					checker.DoCheck("M1kyakkariyu_kb", tk030f01M1Form.M1kyakkariyu_kb, i, m1List);
				}
				if (tk030f01M1Form.M1kyakkariyu != null)
				{
					checker.DoCheck("M1kyakkariyu", tk030f01M1Form.M1kyakkariyu, i, m1List);
				}
				if (tk030f01M1Form.M1syonin_flg != null)
				{
					checker.DoCheck("M1syonin_flg", tk030f01M1Form.M1syonin_flg, i, m1List);
				}
				if (tk030f01M1Form.M1kyakka_flg != null)
				{
					checker.DoCheck("M1kyakka_flg", tk030f01M1Form.M1kyakka_flg, i, m1List);
				}
				if (tk030f01M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", tk030f01M1Form.M1selectorcheckbox, i, m1List);
				}
				if (tk030f01M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", tk030f01M1Form.M1entersyoriflg, i, m1List);
				}
				if (tk030f01M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", tk030f01M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Tk030f01Form formVO, StandardCodeCheckManager checker)
		{
			checker.DoCheck("Btnheadtenpocd", formVO);
			checker.DoCheck("Btntenpocd_from", formVO);
			checker.DoCheck("Btntenpocd_to", formVO);
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Tk030f01Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

