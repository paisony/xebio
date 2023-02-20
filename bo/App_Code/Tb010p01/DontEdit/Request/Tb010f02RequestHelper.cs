using com.xebio.bo.Tb010p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Tb010p01.Request
{
  /// <summary>
  /// Tb010f02RequestHelper の概要の説明です。
  /// </summary>
  public static class Tb010f02RequestHelper
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
			Tb010f02Form formVO = (Tb010f02Form)pageContext.GetFormVO();

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
			paramCol["Motodenpyo_bango"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Motodenpyo_bango"]);
			paramCol["Siiresaki_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Siiresaki_cd"]);
			paramCol["Siiresaki_ryaku_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Siiresaki_ryaku_nm"]);
			paramCol["Bumon_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_cd"]);
			paramCol["Bumon_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_nm"]);
			paramCol["Tantosya_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tantosya_cd"]);
			paramCol["Hanbaiin_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hanbaiin_nm"]);
			paramCol["Nyukayotei_ymd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Nyukayotei_ymd"]);
			paramCol["Siire_kakutei_ymd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Siire_kakutei_ymd"]);
			paramCol["Denpyo_jyotainm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Denpyo_jyotainm"]);
			paramCol["Syorinm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Syorinm"]);
			paramCol["Syoriymd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Syoriymd"]);
			paramCol["Syori_tm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Syori_tm"]);
			paramCol["Gokei_nohin_su"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokei_nohin_su"]);
			paramCol["Gokei_kensu"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokei_kensu"]);
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
				paramCol["M1gen_tnk"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1gen_tnk"]);
				paramCol["M1genka_kin"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1genka_kin"]);
				paramCol["M1kyakucyu"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1kyakucyu"]);
				paramCol["M1negaki"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1negaki"]);
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
			Tb010f02Form formVO = (Tb010f02Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Denpyo_bango"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Denpyo_bango"].RequestValue, formInfo["Denpyo_bango"]);
			paramCol["Motodenpyo_bango"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Motodenpyo_bango"].RequestValue, formInfo["Motodenpyo_bango"]);
			paramCol["Siiresaki_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Siiresaki_cd"].RequestValue, formInfo["Siiresaki_cd"]);
			paramCol["Siiresaki_ryaku_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Siiresaki_ryaku_nm"].RequestValue, formInfo["Siiresaki_ryaku_nm"]);
			paramCol["Bumon_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_cd"].RequestValue, formInfo["Bumon_cd"]);
			paramCol["Bumon_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_nm"].RequestValue, formInfo["Bumon_nm"]);
			paramCol["Tantosya_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tantosya_cd"].RequestValue, formInfo["Tantosya_cd"]);
			paramCol["Hanbaiin_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hanbaiin_nm"].RequestValue, formInfo["Hanbaiin_nm"]);
			paramCol["Nyukayotei_ymd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Nyukayotei_ymd"].RequestValue, formInfo["Nyukayotei_ymd"]);
			paramCol["Nyukayotei_ymd"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Nyukayotei_ymd"].RequestValue, formInfo["Nyukayotei_ymd"]);
			paramCol["Siire_kakutei_ymd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Siire_kakutei_ymd"].RequestValue, formInfo["Siire_kakutei_ymd"]);
			paramCol["Siire_kakutei_ymd"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Siire_kakutei_ymd"].RequestValue, formInfo["Siire_kakutei_ymd"]);
			paramCol["Denpyo_jyotainm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Denpyo_jyotainm"].RequestValue, formInfo["Denpyo_jyotainm"]);
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
			paramCol["Gokei_nohin_su"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokei_nohin_su"].RequestValue, formInfo["Gokei_nohin_su"]);
			paramCol["Gokei_kensu"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokei_kensu"].RequestValue, formInfo["Gokei_kensu"]);
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
				paramCol["M1gen_tnk"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1gen_tnk"][i].RequestValue, formInfo["M1gen_tnk"]);
				paramCol["M1genka_kin"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1genka_kin"][i].RequestValue, formInfo["M1genka_kin"]);
				paramCol["M1kyakucyu"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1kyakucyu"][i].RequestValue, formInfo["M1kyakucyu"]);
				paramCol["M1negaki"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1negaki"][i].RequestValue, formInfo["M1negaki"]);
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
			Tb010f02Form formVO = (Tb010f02Form)pageContext.GetFormVO();

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
			if (paramCol["Motodenpyo_bango"].UnformatValue != null)
			{
				formVO.Motodenpyo_bango = paramCol["Motodenpyo_bango"].UnformatValue;
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
			if (paramCol["Tantosya_cd"].UnformatValue != null)
			{
				formVO.Tantosya_cd = paramCol["Tantosya_cd"].UnformatValue;
			}
			if (paramCol["Hanbaiin_nm"].UnformatValue != null)
			{
				formVO.Hanbaiin_nm = paramCol["Hanbaiin_nm"].UnformatValue;
			}
			if (paramCol["Nyukayotei_ymd"].DateFullValue != null)
			{
				formVO.Nyukayotei_ymd = paramCol["Nyukayotei_ymd"].DateFullValue;
			}
			if (paramCol["Siire_kakutei_ymd"].DateFullValue != null)
			{
				formVO.Siire_kakutei_ymd = paramCol["Siire_kakutei_ymd"].DateFullValue;
			}
			if (paramCol["Denpyo_jyotainm"].UnformatValue != null)
			{
				formVO.Denpyo_jyotainm = paramCol["Denpyo_jyotainm"].UnformatValue;
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
			if (paramCol["Gokei_nohin_su"].UnformatValue != null)
			{
				formVO.Gokei_nohin_su = paramCol["Gokei_nohin_su"].UnformatValue;
			}
			if (paramCol["Gokei_kensu"].UnformatValue != null)
			{
				formVO.Gokei_kensu = paramCol["Gokei_kensu"].UnformatValue;
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
				Tb010f02M1Form tb010f02M1Form = (Tb010f02M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					tb010f02M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue != null)
				{
					tb010f02M1Form.M1hinsyu_ryaku_nm = paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue;
				}
				if (paramCol["M1burando_nm"][i].UnformatValue != null)
				{
					tb010f02M1Form.M1burando_nm = paramCol["M1burando_nm"][i].UnformatValue;
				}
				if (paramCol["M1jisya_hbn"][i].UnformatValue != null)
				{
					tb010f02M1Form.M1jisya_hbn = paramCol["M1jisya_hbn"][i].UnformatValue;
				}
				if (paramCol["M1maker_hbn"][i].UnformatValue != null)
				{
					tb010f02M1Form.M1maker_hbn = paramCol["M1maker_hbn"][i].UnformatValue;
				}
				if (paramCol["M1syonmk"][i].UnformatValue != null)
				{
					tb010f02M1Form.M1syonmk = paramCol["M1syonmk"][i].UnformatValue;
				}
				if (paramCol["M1iro_nm"][i].UnformatValue != null)
				{
					tb010f02M1Form.M1iro_nm = paramCol["M1iro_nm"][i].UnformatValue;
				}
				if (paramCol["M1size_nm"][i].UnformatValue != null)
				{
					tb010f02M1Form.M1size_nm = paramCol["M1size_nm"][i].UnformatValue;
				}
				if (paramCol["M1scan_cd"][i].UnformatValue != null)
				{
					tb010f02M1Form.M1scan_cd = paramCol["M1scan_cd"][i].UnformatValue;
				}
				if (paramCol["M1nohin_su"][i].UnformatValue != null)
				{
					tb010f02M1Form.M1nohin_su = paramCol["M1nohin_su"][i].UnformatValue;
				}
				if (paramCol["M1kensu"][i].UnformatValue != null)
				{
					tb010f02M1Form.M1kensu = paramCol["M1kensu"][i].UnformatValue;
				}
				if (paramCol["M1gen_tnk"][i].UnformatValue != null)
				{
					tb010f02M1Form.M1gen_tnk = paramCol["M1gen_tnk"][i].UnformatValue;
				}
				if (paramCol["M1genka_kin"][i].UnformatValue != null)
				{
					tb010f02M1Form.M1genka_kin = paramCol["M1genka_kin"][i].UnformatValue;
				}
				if (paramCol["M1kyakucyu"][i].UnformatValue != null)
				{
					tb010f02M1Form.M1kyakucyu = paramCol["M1kyakucyu"][i].UnformatValue;
				}
				if (paramCol["M1negaki"][i].UnformatValue != null)
				{
					tb010f02M1Form.M1negaki = paramCol["M1negaki"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					tb010f02M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					tb010f02M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					tb010f02M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Tb010f02Form formVO, StandardCheckManager checker)
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
			if (formVO.Motodenpyo_bango != null)
			{
				checker.DoCheck("Motodenpyo_bango", formVO.Motodenpyo_bango);
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
			if (formVO.Tantosya_cd != null)
			{
				checker.DoCheck("Tantosya_cd", formVO.Tantosya_cd);
			}
			if (formVO.Hanbaiin_nm != null)
			{
				checker.DoCheck("Hanbaiin_nm", formVO.Hanbaiin_nm);
			}
			if (formVO.Nyukayotei_ymd != null)
			{
				checker.DoCheck("Nyukayotei_ymd", formVO.Nyukayotei_ymd);
			}
			if (formVO.Siire_kakutei_ymd != null)
			{
				checker.DoCheck("Siire_kakutei_ymd", formVO.Siire_kakutei_ymd);
			}
			if (formVO.Denpyo_jyotainm != null)
			{
				checker.DoCheck("Denpyo_jyotainm", formVO.Denpyo_jyotainm);
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
			if (formVO.Gokei_nohin_su != null)
			{
				checker.DoCheck("Gokei_nohin_su", formVO.Gokei_nohin_su);
			}
			if (formVO.Gokei_kensu != null)
			{
				checker.DoCheck("Gokei_kensu", formVO.Gokei_kensu);
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
		public static void ValidateM1InputValue(Tb010f02Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Tb010f02M1Form tb010f02M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, tb010f02M1Form, i, m1List);
				if (tb010f02M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", tb010f02M1Form.M1rowno, i, m1List);
				}
				if (tb010f02M1Form.M1hinsyu_ryaku_nm != null)
				{
					checker.DoCheck("M1hinsyu_ryaku_nm", tb010f02M1Form.M1hinsyu_ryaku_nm, i, m1List);
				}
				if (tb010f02M1Form.M1burando_nm != null)
				{
					checker.DoCheck("M1burando_nm", tb010f02M1Form.M1burando_nm, i, m1List);
				}
				if (tb010f02M1Form.M1jisya_hbn != null)
				{
					checker.DoCheck("M1jisya_hbn", tb010f02M1Form.M1jisya_hbn, i, m1List);
				}
				if (tb010f02M1Form.M1maker_hbn != null)
				{
					checker.DoCheck("M1maker_hbn", tb010f02M1Form.M1maker_hbn, i, m1List);
				}
				if (tb010f02M1Form.M1syonmk != null)
				{
					checker.DoCheck("M1syonmk", tb010f02M1Form.M1syonmk, i, m1List);
				}
				if (tb010f02M1Form.M1iro_nm != null)
				{
					checker.DoCheck("M1iro_nm", tb010f02M1Form.M1iro_nm, i, m1List);
				}
				if (tb010f02M1Form.M1size_nm != null)
				{
					checker.DoCheck("M1size_nm", tb010f02M1Form.M1size_nm, i, m1List);
				}
				if (tb010f02M1Form.M1scan_cd != null)
				{
					checker.DoCheck("M1scan_cd", tb010f02M1Form.M1scan_cd, i, m1List);
				}
				if (tb010f02M1Form.M1nohin_su != null)
				{
					checker.DoCheck("M1nohin_su", tb010f02M1Form.M1nohin_su, i, m1List);
				}
				if (tb010f02M1Form.M1kensu != null)
				{
					checker.DoCheck("M1kensu", tb010f02M1Form.M1kensu, i, m1List);
				}
				if (tb010f02M1Form.M1gen_tnk != null)
				{
					checker.DoCheck("M1gen_tnk", tb010f02M1Form.M1gen_tnk, i, m1List);
				}
				if (tb010f02M1Form.M1genka_kin != null)
				{
					checker.DoCheck("M1genka_kin", tb010f02M1Form.M1genka_kin, i, m1List);
				}
				if (tb010f02M1Form.M1kyakucyu != null)
				{
					checker.DoCheck("M1kyakucyu", tb010f02M1Form.M1kyakucyu, i, m1List);
				}
				if (tb010f02M1Form.M1negaki != null)
				{
					checker.DoCheck("M1negaki", tb010f02M1Form.M1negaki, i, m1List);
				}
				if (tb010f02M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", tb010f02M1Form.M1selectorcheckbox, i, m1List);
				}
				if (tb010f02M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", tb010f02M1Form.M1entersyoriflg, i, m1List);
				}
				if (tb010f02M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", tb010f02M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Tb010f02Form formVO, StandardCodeCheckManager checker)
		{
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Tb010f02Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

