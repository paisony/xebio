using com.xebio.bo.Td050p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Td050p01.Request
{
  /// <summary>
  /// Td050f02RequestHelper の概要の説明です。
  /// </summary>
  public static class Td050f02RequestHelper
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
			Td050f02Form formVO = (Td050f02Form)pageContext.GetFormVO();

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
			paramCol["Nyuryokutan_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Nyuryokutan_cd"]);
			paramCol["Nyuryokutan_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Nyuryokutan_nm"]);
			paramCol["Kakuteitan_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Kakuteitan_cd"]);
			paramCol["Kakuteitan_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Kakuteitan_nm"]);
			paramCol["Henpin_riyu_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Henpin_riyu_nm"]);
			paramCol["Siiresaki_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Siiresaki_cd"]);
			paramCol["Siiresaki_ryaku_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Siiresaki_ryaku_nm"]);
			paramCol["Bumon_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_cd"]);
			paramCol["Bumon_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_nm"]);
			paramCol["Siji_bango"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Siji_bango"]);
			paramCol["Henpin_kakutei_ymd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Henpin_kakutei_ymd"]);
			paramCol["Add_ymd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Add_ymd"]);
			paramCol["Biko"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Biko"]);
			paramCol["Gokeiteisei_suryo"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokeiteisei_suryo"]);
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
				paramCol["M1hinsyu_ryaku_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hinsyu_ryaku_nm"]);
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
				paramCol["M1yotei_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1yotei_su"]);
				paramCol["M1kakutei_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1kakutei_su"]);
				paramCol["M1teisei_suryo"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1teisei_suryo"]);
				paramCol["M1gen_tnk"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1gen_tnk"]);
				paramCol["M1genka_kin"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1genka_kin"]);
				paramCol["M1teisei_suryo_hdn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1teisei_suryo_hdn"]);
				paramCol["M1genka_kin_hdn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1genka_kin_hdn"]);
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
			Td050f02Form formVO = (Td050f02Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Stkmodeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Stkmodeno"].RequestValue, formInfo["Stkmodeno"]);
			paramCol["Denpyo_bango"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Denpyo_bango"].RequestValue, formInfo["Denpyo_bango"]);
			paramCol["Nyuryokutan_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Nyuryokutan_cd"].RequestValue, formInfo["Nyuryokutan_cd"]);
			paramCol["Nyuryokutan_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Nyuryokutan_nm"].RequestValue, formInfo["Nyuryokutan_nm"]);
			paramCol["Kakuteitan_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Kakuteitan_cd"].RequestValue, formInfo["Kakuteitan_cd"]);
			paramCol["Kakuteitan_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Kakuteitan_nm"].RequestValue, formInfo["Kakuteitan_nm"]);
			paramCol["Henpin_riyu_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Henpin_riyu_nm"].RequestValue, formInfo["Henpin_riyu_nm"]);
			paramCol["Siiresaki_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Siiresaki_cd"].RequestValue, formInfo["Siiresaki_cd"]);
			paramCol["Siiresaki_ryaku_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Siiresaki_ryaku_nm"].RequestValue, formInfo["Siiresaki_ryaku_nm"]);
			paramCol["Bumon_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_cd"].RequestValue, formInfo["Bumon_cd"]);
			paramCol["Bumon_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_nm"].RequestValue, formInfo["Bumon_nm"]);
			paramCol["Siji_bango"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Siji_bango"].RequestValue, formInfo["Siji_bango"]);
			paramCol["Henpin_kakutei_ymd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Henpin_kakutei_ymd"].RequestValue, formInfo["Henpin_kakutei_ymd"]);
			paramCol["Henpin_kakutei_ymd"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Henpin_kakutei_ymd"].RequestValue, formInfo["Henpin_kakutei_ymd"]);
			paramCol["Add_ymd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Add_ymd"].RequestValue, formInfo["Add_ymd"]);
			paramCol["Add_ymd"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Add_ymd"].RequestValue, formInfo["Add_ymd"]);
			paramCol["Biko"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Biko"].RequestValue, formInfo["Biko"]);
			paramCol["Gokeiteisei_suryo"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokeiteisei_suryo"].RequestValue, formInfo["Gokeiteisei_suryo"]);
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
				paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hinsyu_ryaku_nm"][i].RequestValue, formInfo["M1hinsyu_ryaku_nm"]);
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
				paramCol["M1yotei_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1yotei_su"][i].RequestValue, formInfo["M1yotei_su"]);
				paramCol["M1kakutei_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1kakutei_su"][i].RequestValue, formInfo["M1kakutei_su"]);
				paramCol["M1teisei_suryo"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1teisei_suryo"][i].RequestValue, formInfo["M1teisei_suryo"]);
				paramCol["M1gen_tnk"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1gen_tnk"][i].RequestValue, formInfo["M1gen_tnk"]);
				paramCol["M1genka_kin"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1genka_kin"][i].RequestValue, formInfo["M1genka_kin"]);
				paramCol["M1teisei_suryo_hdn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1teisei_suryo_hdn"][i].RequestValue, formInfo["M1teisei_suryo_hdn"]);
				paramCol["M1genka_kin_hdn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1genka_kin_hdn"][i].RequestValue, formInfo["M1genka_kin_hdn"]);
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
			Td050f02Form formVO = (Td050f02Form)pageContext.GetFormVO();

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
			if (paramCol["Nyuryokutan_cd"].UnformatValue != null)
			{
				formVO.Nyuryokutan_cd = paramCol["Nyuryokutan_cd"].UnformatValue;
			}
			if (paramCol["Nyuryokutan_nm"].UnformatValue != null)
			{
				formVO.Nyuryokutan_nm = paramCol["Nyuryokutan_nm"].UnformatValue;
			}
			if (paramCol["Kakuteitan_cd"].UnformatValue != null)
			{
				formVO.Kakuteitan_cd = paramCol["Kakuteitan_cd"].UnformatValue;
			}
			if (paramCol["Kakuteitan_nm"].UnformatValue != null)
			{
				formVO.Kakuteitan_nm = paramCol["Kakuteitan_nm"].UnformatValue;
			}
			if (paramCol["Henpin_riyu_nm"].UnformatValue != null)
			{
				formVO.Henpin_riyu_nm = paramCol["Henpin_riyu_nm"].UnformatValue;
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
			if (paramCol["Siji_bango"].UnformatValue != null)
			{
				formVO.Siji_bango = paramCol["Siji_bango"].UnformatValue;
			}
			if (paramCol["Henpin_kakutei_ymd"].DateFullValue != null)
			{
				formVO.Henpin_kakutei_ymd = paramCol["Henpin_kakutei_ymd"].DateFullValue;
			}
			if (paramCol["Add_ymd"].DateFullValue != null)
			{
				formVO.Add_ymd = paramCol["Add_ymd"].DateFullValue;
			}
			if (paramCol["Biko"].UnformatValue != null)
			{
				formVO.Biko = paramCol["Biko"].UnformatValue;
			}
			if (paramCol["Gokeiteisei_suryo"].UnformatValue != null)
			{
				formVO.Gokeiteisei_suryo = paramCol["Gokeiteisei_suryo"].UnformatValue;
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
				Td050f02M1Form td050f02M1Form = (Td050f02M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					td050f02M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue != null)
				{
					td050f02M1Form.M1hinsyu_ryaku_nm = paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue;
				}
				if (paramCol["M1jisya_hbn"][i].UnformatValue != null)
				{
					td050f02M1Form.M1jisya_hbn = paramCol["M1jisya_hbn"][i].UnformatValue;
				}
				if (paramCol["M1maker_hbn"][i].UnformatValue != null)
				{
					td050f02M1Form.M1maker_hbn = paramCol["M1maker_hbn"][i].UnformatValue;
				}
				if (paramCol["M1syonmk"][i].UnformatValue != null)
				{
					td050f02M1Form.M1syonmk = paramCol["M1syonmk"][i].UnformatValue;
				}
				if (paramCol["M1iro_nm"][i].UnformatValue != null)
				{
					td050f02M1Form.M1iro_nm = paramCol["M1iro_nm"][i].UnformatValue;
				}
				if (paramCol["M1size_nm"][i].UnformatValue != null)
				{
					td050f02M1Form.M1size_nm = paramCol["M1size_nm"][i].UnformatValue;
				}
				if (paramCol["M1scan_cd"][i].UnformatValue != null)
				{
					td050f02M1Form.M1scan_cd = paramCol["M1scan_cd"][i].UnformatValue;
				}
				if (paramCol["M1yotei_su"][i].UnformatValue != null)
				{
					td050f02M1Form.M1yotei_su = paramCol["M1yotei_su"][i].UnformatValue;
				}
				if (paramCol["M1kakutei_su"][i].UnformatValue != null)
				{
					td050f02M1Form.M1kakutei_su = paramCol["M1kakutei_su"][i].UnformatValue;
				}
				if (paramCol["M1teisei_suryo"][i].UnformatValue != null)
				{
					td050f02M1Form.M1teisei_suryo = paramCol["M1teisei_suryo"][i].UnformatValue;
				}
				if (paramCol["M1gen_tnk"][i].UnformatValue != null)
				{
					td050f02M1Form.M1gen_tnk = paramCol["M1gen_tnk"][i].UnformatValue;
				}
				if (paramCol["M1genka_kin"][i].UnformatValue != null)
				{
					td050f02M1Form.M1genka_kin = paramCol["M1genka_kin"][i].UnformatValue;
				}
				if (paramCol["M1teisei_suryo_hdn"][i].UnformatValue != null)
				{
					td050f02M1Form.M1teisei_suryo_hdn = paramCol["M1teisei_suryo_hdn"][i].UnformatValue;
				}
				if (paramCol["M1genka_kin_hdn"][i].UnformatValue != null)
				{
					td050f02M1Form.M1genka_kin_hdn = paramCol["M1genka_kin_hdn"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					td050f02M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					td050f02M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					td050f02M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Td050f02Form formVO, StandardCheckManager checker)
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
			if (formVO.Nyuryokutan_cd != null)
			{
				checker.DoCheck("Nyuryokutan_cd", formVO.Nyuryokutan_cd);
			}
			if (formVO.Nyuryokutan_nm != null)
			{
				checker.DoCheck("Nyuryokutan_nm", formVO.Nyuryokutan_nm);
			}
			if (formVO.Kakuteitan_cd != null)
			{
				checker.DoCheck("Kakuteitan_cd", formVO.Kakuteitan_cd);
			}
			if (formVO.Kakuteitan_nm != null)
			{
				checker.DoCheck("Kakuteitan_nm", formVO.Kakuteitan_nm);
			}
			if (formVO.Henpin_riyu_nm != null)
			{
				checker.DoCheck("Henpin_riyu_nm", formVO.Henpin_riyu_nm);
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
			if (formVO.Siji_bango != null)
			{
				checker.DoCheck("Siji_bango", formVO.Siji_bango);
			}
			if (formVO.Henpin_kakutei_ymd != null)
			{
				checker.DoCheck("Henpin_kakutei_ymd", formVO.Henpin_kakutei_ymd);
			}
			if (formVO.Add_ymd != null)
			{
				checker.DoCheck("Add_ymd", formVO.Add_ymd);
			}
			if (formVO.Biko != null)
			{
				checker.DoCheck("Biko", formVO.Biko);
			}
			if (formVO.Gokeiteisei_suryo != null)
			{
				checker.DoCheck("Gokeiteisei_suryo", formVO.Gokeiteisei_suryo);
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
		public static void ValidateM1InputValue(Td050f02Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Td050f02M1Form td050f02M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, td050f02M1Form, i, m1List);
				if (td050f02M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", td050f02M1Form.M1rowno, i, m1List);
				}
				if (td050f02M1Form.M1hinsyu_ryaku_nm != null)
				{
					checker.DoCheck("M1hinsyu_ryaku_nm", td050f02M1Form.M1hinsyu_ryaku_nm, i, m1List);
				}
				if (td050f02M1Form.M1jisya_hbn != null)
				{
					checker.DoCheck("M1jisya_hbn", td050f02M1Form.M1jisya_hbn, i, m1List);
				}
				if (td050f02M1Form.M1maker_hbn != null)
				{
					checker.DoCheck("M1maker_hbn", td050f02M1Form.M1maker_hbn, i, m1List);
				}
				if (td050f02M1Form.M1syonmk != null)
				{
					checker.DoCheck("M1syonmk", td050f02M1Form.M1syonmk, i, m1List);
				}
				if (td050f02M1Form.M1iro_nm != null)
				{
					checker.DoCheck("M1iro_nm", td050f02M1Form.M1iro_nm, i, m1List);
				}
				if (td050f02M1Form.M1size_nm != null)
				{
					checker.DoCheck("M1size_nm", td050f02M1Form.M1size_nm, i, m1List);
				}
				if (td050f02M1Form.M1scan_cd != null)
				{
					checker.DoCheck("M1scan_cd", td050f02M1Form.M1scan_cd, i, m1List);
				}
				if (td050f02M1Form.M1yotei_su != null)
				{
					checker.DoCheck("M1yotei_su", td050f02M1Form.M1yotei_su, i, m1List);
				}
				if (td050f02M1Form.M1kakutei_su != null)
				{
					checker.DoCheck("M1kakutei_su", td050f02M1Form.M1kakutei_su, i, m1List);
				}
				if (td050f02M1Form.M1teisei_suryo != null)
				{
					checker.DoCheck("M1teisei_suryo", td050f02M1Form.M1teisei_suryo, i, m1List);
				}
				if (td050f02M1Form.M1gen_tnk != null)
				{
					checker.DoCheck("M1gen_tnk", td050f02M1Form.M1gen_tnk, i, m1List);
				}
				if (td050f02M1Form.M1genka_kin != null)
				{
					checker.DoCheck("M1genka_kin", td050f02M1Form.M1genka_kin, i, m1List);
				}
				if (td050f02M1Form.M1teisei_suryo_hdn != null)
				{
					checker.DoCheck("M1teisei_suryo_hdn", td050f02M1Form.M1teisei_suryo_hdn, i, m1List);
				}
				if (td050f02M1Form.M1genka_kin_hdn != null)
				{
					checker.DoCheck("M1genka_kin_hdn", td050f02M1Form.M1genka_kin_hdn, i, m1List);
				}
				if (td050f02M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", td050f02M1Form.M1selectorcheckbox, i, m1List);
				}
				if (td050f02M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", td050f02M1Form.M1entersyoriflg, i, m1List);
				}
				if (td050f02M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", td050f02M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Td050f02Form formVO, StandardCodeCheckManager checker)
		{
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Td050f02Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

