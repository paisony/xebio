using com.xebio.bo.Tb090p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Tb090p01.Request
{
  /// <summary>
  /// Tb090f02RequestHelper の概要の説明です。
  /// </summary>
  public static class Tb090f02RequestHelper
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
			Tb090f02Form formVO = (Tb090f02Form)pageContext.GetFormVO();

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
			paramCol["Denpyo_bango"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Denpyo_bango"]);
			paramCol["Siiresaki_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Siiresaki_cd"]);
			paramCol["Siiresaki_ryaku_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Siiresaki_ryaku_nm"]);
			paramCol["Bumon_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_cd"]);
			paramCol["Bumon_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_nm"]);
			paramCol["Kakuteitan_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Kakuteitan_cd"]);
			paramCol["Kakuteitan_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Kakuteitan_nm"]);
			paramCol["Nyukayotei_ymd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Nyukayotei_ymd"]);
			paramCol["Siire_kakutei_ymd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Siire_kakutei_ymd"]);
			paramCol["Kakutei_sb_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Kakutei_sb_nm"]);
			paramCol["Biko_kb"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Biko_kb"]);
			paramCol["Biko1"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Biko1"]);
			paramCol["Biko2"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Biko2"]);
			paramCol["Gokei_teisei_suryo"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokei_teisei_suryo"]);
			paramCol["Gokei_genkakin"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokei_genkakin"]);
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
				paramCol["M1nohin_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1nohin_su"]);
				paramCol["M1kensu"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1kensu"]);
				paramCol["M1teisei_suryo"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1teisei_suryo"]);
				paramCol["M1gen_tnk"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1gen_tnk"]);
				paramCol["M1genkakin"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1genkakin"]);
				paramCol["M1teisei_suryo_hdn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1teisei_suryo_hdn"]);
				paramCol["M1genkakin_hdn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1genkakin_hdn"]);
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
			Tb090f02Form formVO = (Tb090f02Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Stkmodeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Stkmodeno"].RequestValue, formInfo["Stkmodeno"]);
			paramCol["Denpyo_bango"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Denpyo_bango"].RequestValue, formInfo["Denpyo_bango"]);
			paramCol["Siiresaki_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Siiresaki_cd"].RequestValue, formInfo["Siiresaki_cd"]);
			paramCol["Siiresaki_ryaku_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Siiresaki_ryaku_nm"].RequestValue, formInfo["Siiresaki_ryaku_nm"]);
			paramCol["Bumon_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_cd"].RequestValue, formInfo["Bumon_cd"]);
			paramCol["Bumon_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_nm"].RequestValue, formInfo["Bumon_nm"]);
			paramCol["Kakuteitan_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Kakuteitan_cd"].RequestValue, formInfo["Kakuteitan_cd"]);
			paramCol["Kakuteitan_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Kakuteitan_nm"].RequestValue, formInfo["Kakuteitan_nm"]);
			paramCol["Nyukayotei_ymd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Nyukayotei_ymd"].RequestValue, formInfo["Nyukayotei_ymd"]);
			paramCol["Nyukayotei_ymd"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Nyukayotei_ymd"].RequestValue, formInfo["Nyukayotei_ymd"]);
			paramCol["Siire_kakutei_ymd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Siire_kakutei_ymd"].RequestValue, formInfo["Siire_kakutei_ymd"]);
			paramCol["Siire_kakutei_ymd"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Siire_kakutei_ymd"].RequestValue, formInfo["Siire_kakutei_ymd"]);
			paramCol["Kakutei_sb_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Kakutei_sb_nm"].RequestValue, formInfo["Kakutei_sb_nm"]);
			paramCol["Biko_kb"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Biko_kb"].RequestValue, formInfo["Biko_kb"]);
			paramCol["Biko1"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Biko1"].RequestValue, formInfo["Biko1"]);
			paramCol["Biko2"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Biko2"].RequestValue, formInfo["Biko2"]);
			paramCol["Gokei_teisei_suryo"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokei_teisei_suryo"].RequestValue, formInfo["Gokei_teisei_suryo"]);
			paramCol["Gokei_genkakin"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokei_genkakin"].RequestValue, formInfo["Gokei_genkakin"]);
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
				paramCol["M1nohin_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1nohin_su"][i].RequestValue, formInfo["M1nohin_su"]);
				paramCol["M1kensu"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1kensu"][i].RequestValue, formInfo["M1kensu"]);
				paramCol["M1teisei_suryo"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1teisei_suryo"][i].RequestValue, formInfo["M1teisei_suryo"]);
				paramCol["M1gen_tnk"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1gen_tnk"][i].RequestValue, formInfo["M1gen_tnk"]);
				paramCol["M1genkakin"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1genkakin"][i].RequestValue, formInfo["M1genkakin"]);
				paramCol["M1teisei_suryo_hdn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1teisei_suryo_hdn"][i].RequestValue, formInfo["M1teisei_suryo_hdn"]);
				paramCol["M1genkakin_hdn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1genkakin_hdn"][i].RequestValue, formInfo["M1genkakin_hdn"]);
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
			Tb090f02Form formVO = (Tb090f02Form)pageContext.GetFormVO();

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
			if (paramCol["Denpyo_bango"].UnformatValue != null)
			{
				formVO.Denpyo_bango = paramCol["Denpyo_bango"].UnformatValue;
			}
			if (paramCol["Siiresaki_cd"].UnformatValue != null)
			{
				formVO.Siiresaki_cd = paramCol["Siiresaki_cd"].UnformatValue;
			}
			if (paramCol["Siiresaki_ryaku_nm"].UnformatValue != null)
			{
				formVO.Siiresaki_ryaku_nm = paramCol["Siiresaki_ryaku_nm"].UnformatValue;
			}
			if (paramCol["Bumon_cd"].UnformatValue != null)
			{
				formVO.Bumon_cd = paramCol["Bumon_cd"].UnformatValue;
			}
			if (paramCol["Bumon_nm"].UnformatValue != null)
			{
				formVO.Bumon_nm = paramCol["Bumon_nm"].UnformatValue;
			}
			if (paramCol["Kakuteitan_cd"].UnformatValue != null)
			{
				formVO.Kakuteitan_cd = paramCol["Kakuteitan_cd"].UnformatValue;
			}
			if (paramCol["Kakuteitan_nm"].UnformatValue != null)
			{
				formVO.Kakuteitan_nm = paramCol["Kakuteitan_nm"].UnformatValue;
			}
			if (paramCol["Nyukayotei_ymd"].DateFullValue != null)
			{
				formVO.Nyukayotei_ymd = paramCol["Nyukayotei_ymd"].DateFullValue;
			}
			if (paramCol["Siire_kakutei_ymd"].DateFullValue != null)
			{
				formVO.Siire_kakutei_ymd = paramCol["Siire_kakutei_ymd"].DateFullValue;
			}
			if (paramCol["Kakutei_sb_nm"].UnformatValue != null)
			{
				formVO.Kakutei_sb_nm = paramCol["Kakutei_sb_nm"].UnformatValue;
			}
			if (paramCol["Biko_kb"].UnformatValue != null)
			{
				formVO.Biko_kb = paramCol["Biko_kb"].UnformatValue;
			}
			if (paramCol["Biko1"].UnformatValue != null)
			{
				formVO.Biko1 = paramCol["Biko1"].UnformatValue;
			}
			if (paramCol["Biko2"].UnformatValue != null)
			{
				formVO.Biko2 = paramCol["Biko2"].UnformatValue;
			}
			if (paramCol["Gokei_teisei_suryo"].UnformatValue != null)
			{
				formVO.Gokei_teisei_suryo = paramCol["Gokei_teisei_suryo"].UnformatValue;
			}
			if (paramCol["Gokei_genkakin"].UnformatValue != null)
			{
				formVO.Gokei_genkakin = paramCol["Gokei_genkakin"].UnformatValue;
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
				Tb090f02M1Form tb090f02M1Form = (Tb090f02M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					tb090f02M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue != null)
				{
					tb090f02M1Form.M1hinsyu_ryaku_nm = paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue;
				}
				if (paramCol["M1burando_nm"][i].UnformatValue != null)
				{
					tb090f02M1Form.M1burando_nm = paramCol["M1burando_nm"][i].UnformatValue;
				}
				if (paramCol["M1jisya_hbn"][i].UnformatValue != null)
				{
					tb090f02M1Form.M1jisya_hbn = paramCol["M1jisya_hbn"][i].UnformatValue;
				}
				if (paramCol["M1maker_hbn"][i].UnformatValue != null)
				{
					tb090f02M1Form.M1maker_hbn = paramCol["M1maker_hbn"][i].UnformatValue;
				}
				if (paramCol["M1syonmk"][i].UnformatValue != null)
				{
					tb090f02M1Form.M1syonmk = paramCol["M1syonmk"][i].UnformatValue;
				}
				if (paramCol["M1iro_nm"][i].UnformatValue != null)
				{
					tb090f02M1Form.M1iro_nm = paramCol["M1iro_nm"][i].UnformatValue;
				}
				if (paramCol["M1size_nm"][i].UnformatValue != null)
				{
					tb090f02M1Form.M1size_nm = paramCol["M1size_nm"][i].UnformatValue;
				}
				if (paramCol["M1scan_cd"][i].UnformatValue != null)
				{
					tb090f02M1Form.M1scan_cd = paramCol["M1scan_cd"][i].UnformatValue;
				}
				if (paramCol["M1nohin_su"][i].UnformatValue != null)
				{
					tb090f02M1Form.M1nohin_su = paramCol["M1nohin_su"][i].UnformatValue;
				}
				if (paramCol["M1kensu"][i].UnformatValue != null)
				{
					tb090f02M1Form.M1kensu = paramCol["M1kensu"][i].UnformatValue;
				}
				if (paramCol["M1teisei_suryo"][i].UnformatValue != null)
				{
					tb090f02M1Form.M1teisei_suryo = paramCol["M1teisei_suryo"][i].UnformatValue;
				}
				if (paramCol["M1gen_tnk"][i].UnformatValue != null)
				{
					tb090f02M1Form.M1gen_tnk = paramCol["M1gen_tnk"][i].UnformatValue;
				}
				if (paramCol["M1genkakin"][i].UnformatValue != null)
				{
					tb090f02M1Form.M1genkakin = paramCol["M1genkakin"][i].UnformatValue;
				}
				if (paramCol["M1teisei_suryo_hdn"][i].UnformatValue != null)
				{
					tb090f02M1Form.M1teisei_suryo_hdn = paramCol["M1teisei_suryo_hdn"][i].UnformatValue;
				}
				if (paramCol["M1genkakin_hdn"][i].UnformatValue != null)
				{
					tb090f02M1Form.M1genkakin_hdn = paramCol["M1genkakin_hdn"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					tb090f02M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					tb090f02M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					tb090f02M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Tb090f02Form formVO, StandardCheckManager checker)
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
			if (formVO.Denpyo_bango != null)
			{
				checker.DoCheck("Denpyo_bango", formVO.Denpyo_bango);
			}
			if (formVO.Siiresaki_cd != null)
			{
				checker.DoCheck("Siiresaki_cd", formVO.Siiresaki_cd);
			}
			if (formVO.Siiresaki_ryaku_nm != null)
			{
				checker.DoCheck("Siiresaki_ryaku_nm", formVO.Siiresaki_ryaku_nm);
			}
			if (formVO.Bumon_cd != null)
			{
				checker.DoCheck("Bumon_cd", formVO.Bumon_cd);
			}
			if (formVO.Bumon_nm != null)
			{
				checker.DoCheck("Bumon_nm", formVO.Bumon_nm);
			}
			if (formVO.Kakuteitan_cd != null)
			{
				checker.DoCheck("Kakuteitan_cd", formVO.Kakuteitan_cd);
			}
			if (formVO.Kakuteitan_nm != null)
			{
				checker.DoCheck("Kakuteitan_nm", formVO.Kakuteitan_nm);
			}
			if (formVO.Nyukayotei_ymd != null)
			{
				checker.DoCheck("Nyukayotei_ymd", formVO.Nyukayotei_ymd);
			}
			if (formVO.Siire_kakutei_ymd != null)
			{
				checker.DoCheck("Siire_kakutei_ymd", formVO.Siire_kakutei_ymd);
			}
			if (formVO.Kakutei_sb_nm != null)
			{
				checker.DoCheck("Kakutei_sb_nm", formVO.Kakutei_sb_nm);
			}
			if (formVO.Biko_kb != null)
			{
				checker.DoCheck("Biko_kb", formVO.Biko_kb);
			}
			if (formVO.Biko1 != null)
			{
				checker.DoCheck("Biko1", formVO.Biko1);
			}
			if (formVO.Biko2 != null)
			{
				checker.DoCheck("Biko2", formVO.Biko2);
			}
			if (formVO.Gokei_teisei_suryo != null)
			{
				checker.DoCheck("Gokei_teisei_suryo", formVO.Gokei_teisei_suryo);
			}
			if (formVO.Gokei_genkakin != null)
			{
				checker.DoCheck("Gokei_genkakin", formVO.Gokei_genkakin);
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
		public static void ValidateM1InputValue(Tb090f02Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Tb090f02M1Form tb090f02M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, tb090f02M1Form, i, m1List);
				if (tb090f02M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", tb090f02M1Form.M1rowno, i, m1List);
				}
				if (tb090f02M1Form.M1hinsyu_ryaku_nm != null)
				{
					checker.DoCheck("M1hinsyu_ryaku_nm", tb090f02M1Form.M1hinsyu_ryaku_nm, i, m1List);
				}
				if (tb090f02M1Form.M1burando_nm != null)
				{
					checker.DoCheck("M1burando_nm", tb090f02M1Form.M1burando_nm, i, m1List);
				}
				if (tb090f02M1Form.M1jisya_hbn != null)
				{
					checker.DoCheck("M1jisya_hbn", tb090f02M1Form.M1jisya_hbn, i, m1List);
				}
				if (tb090f02M1Form.M1maker_hbn != null)
				{
					checker.DoCheck("M1maker_hbn", tb090f02M1Form.M1maker_hbn, i, m1List);
				}
				if (tb090f02M1Form.M1syonmk != null)
				{
					checker.DoCheck("M1syonmk", tb090f02M1Form.M1syonmk, i, m1List);
				}
				if (tb090f02M1Form.M1iro_nm != null)
				{
					checker.DoCheck("M1iro_nm", tb090f02M1Form.M1iro_nm, i, m1List);
				}
				if (tb090f02M1Form.M1size_nm != null)
				{
					checker.DoCheck("M1size_nm", tb090f02M1Form.M1size_nm, i, m1List);
				}
				if (tb090f02M1Form.M1scan_cd != null)
				{
					checker.DoCheck("M1scan_cd", tb090f02M1Form.M1scan_cd, i, m1List);
				}
				if (tb090f02M1Form.M1nohin_su != null)
				{
					checker.DoCheck("M1nohin_su", tb090f02M1Form.M1nohin_su, i, m1List);
				}
				if (tb090f02M1Form.M1kensu != null)
				{
					checker.DoCheck("M1kensu", tb090f02M1Form.M1kensu, i, m1List);
				}
				if (tb090f02M1Form.M1teisei_suryo != null)
				{
					checker.DoCheck("M1teisei_suryo", tb090f02M1Form.M1teisei_suryo, i, m1List);
				}
				if (tb090f02M1Form.M1gen_tnk != null)
				{
					checker.DoCheck("M1gen_tnk", tb090f02M1Form.M1gen_tnk, i, m1List);
				}
				if (tb090f02M1Form.M1genkakin != null)
				{
					checker.DoCheck("M1genkakin", tb090f02M1Form.M1genkakin, i, m1List);
				}
				if (tb090f02M1Form.M1teisei_suryo_hdn != null)
				{
					checker.DoCheck("M1teisei_suryo_hdn", tb090f02M1Form.M1teisei_suryo_hdn, i, m1List);
				}
				if (tb090f02M1Form.M1genkakin_hdn != null)
				{
					checker.DoCheck("M1genkakin_hdn", tb090f02M1Form.M1genkakin_hdn, i, m1List);
				}
				if (tb090f02M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", tb090f02M1Form.M1selectorcheckbox, i, m1List);
				}
				if (tb090f02M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", tb090f02M1Form.M1entersyoriflg, i, m1List);
				}
				if (tb090f02M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", tb090f02M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Tb090f02Form formVO, StandardCodeCheckManager checker)
		{
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Tb090f02Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

