using com.xebio.bo.Th010p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Th010p01.Request
{
  /// <summary>
  /// Th010f02RequestHelper の概要の説明です。
  /// </summary>
  public static class Th010f02RequestHelper
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
			Th010f02Form formVO = (Th010f02Form)pageContext.GetFormVO();

			//カード部を初期化する
			paramCol.InitCardItems(formInfo.GetCardItems());
			//明細「M1」部を初期化する
			paramCol.InitListItems(formInfo.GetListItems("M1"), formVO.GetList("M1").CurrentCount);
			//カード項目の入力値を取得する
			paramCol["Head_tenpo_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_nm"]);
			paramCol["Siiresaki_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Siiresaki_cd"]);
			paramCol["Siiresaki_ryaku_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Siiresaki_ryaku_nm"]);
			paramCol["Burando_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Burando_cd"]);
			paramCol["Burando_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Burando_nm"]);
			paramCol["Maker_hbn"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Maker_hbn"]);
			paramCol["Genka_flg"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Genka_flg"]);
			paramCol["Genka"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Genka"]);
			paramCol["Genbaika_flg"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Genbaika_flg"]);
			paramCol["Genbaika_tnk"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Genbaika_tnk"]);
			paramCol["Makerkakaku_flg"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Makerkakaku_flg"]);
			paramCol["Makerkakaku_tnk"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Makerkakaku_tnk"]);
			paramCol["Searchcnt"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Searchcnt"]);
			paramCol["Syohinmst_serchstk"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Syohinmst_serchstk"]);
			paramCol["Stkmodeno"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Stkmodeno"]);
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
				paramCol["M1siiresaki_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1siiresaki_cd"]);
				paramCol["M1siiresaki_ryaku_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1siiresaki_ryaku_nm"]);
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
				paramCol["M1syohin_zokusei"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1syohin_zokusei"]);
				paramCol["M1maker_hbn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1maker_hbn"]);
				paramCol["M1syonmk"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1syonmk"]);
				paramCol["M1iro_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1iro_nm"]);
				paramCol["M1hanbaikanryo_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hanbaikanryo_ymd"]);
				paramCol["M1saisinbaika_tnk"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1saisinbaika_tnk"]);
				paramCol["M1genka"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1genka"]);
				paramCol["M1genbaika_tnk"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1genbaika_tnk"]);
				paramCol["M1selectorcheckbox"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1selectorcheckbox"]);
				paramCol["M1entersyoriflg"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1entersyoriflg"]);
				paramCol["M1dtlirokbn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1dtlirokbn"]);
				paramCol["M1makerkakaku_tnk"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1makerkakaku_tnk"]);
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
			Th010f02Form formVO = (Th010f02Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Siiresaki_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Siiresaki_cd"].RequestValue, formInfo["Siiresaki_cd"]);
			paramCol["Siiresaki_ryaku_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Siiresaki_ryaku_nm"].RequestValue, formInfo["Siiresaki_ryaku_nm"]);
			paramCol["Burando_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Burando_cd"].RequestValue, formInfo["Burando_cd"]);
			paramCol["Burando_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Burando_nm"].RequestValue, formInfo["Burando_nm"]);
			paramCol["Maker_hbn"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Maker_hbn"].RequestValue, formInfo["Maker_hbn"]);
			paramCol["Genka_flg"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Genka_flg"].RequestValue, formInfo["Genka_flg"]);
			paramCol["Genka"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Genka"].RequestValue, formInfo["Genka"]);
			paramCol["Genbaika_flg"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Genbaika_flg"].RequestValue, formInfo["Genbaika_flg"]);
			paramCol["Genbaika_tnk"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Genbaika_tnk"].RequestValue, formInfo["Genbaika_tnk"]);
			paramCol["Makerkakaku_flg"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Makerkakaku_flg"].RequestValue, formInfo["Makerkakaku_flg"]);
			paramCol["Makerkakaku_tnk"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Makerkakaku_tnk"].RequestValue, formInfo["Makerkakaku_tnk"]);
			paramCol["Searchcnt"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Searchcnt"].RequestValue, formInfo["Searchcnt"]);
			paramCol["Syohinmst_serchstk"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Syohinmst_serchstk"].RequestValue, formInfo["Syohinmst_serchstk"]);
			paramCol["Stkmodeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Stkmodeno"].RequestValue, formInfo["Stkmodeno"]);
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
				paramCol["M1siiresaki_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1siiresaki_cd"][i].RequestValue, formInfo["M1siiresaki_cd"]);
				paramCol["M1siiresaki_ryaku_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1siiresaki_ryaku_nm"][i].RequestValue, formInfo["M1siiresaki_ryaku_nm"]);
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
				paramCol["M1syohin_zokusei"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1syohin_zokusei"][i].RequestValue, formInfo["M1syohin_zokusei"]);
				paramCol["M1maker_hbn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1maker_hbn"][i].RequestValue, formInfo["M1maker_hbn"]);
				paramCol["M1syonmk"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1syonmk"][i].RequestValue, formInfo["M1syonmk"]);
				paramCol["M1iro_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1iro_nm"][i].RequestValue, formInfo["M1iro_nm"]);
				paramCol["M1hanbaikanryo_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hanbaikanryo_ymd"][i].RequestValue, formInfo["M1hanbaikanryo_ymd"]);
				paramCol["M1hanbaikanryo_ymd"][i].DateFullValue = RequestParameterUtil.GetDateFullValue(
					paramCol["M1hanbaikanryo_ymd"][i].RequestValue, formInfo["M1hanbaikanryo_ymd"]);
				paramCol["M1saisinbaika_tnk"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1saisinbaika_tnk"][i].RequestValue, formInfo["M1saisinbaika_tnk"]);
				paramCol["M1genka"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1genka"][i].RequestValue, formInfo["M1genka"]);
				paramCol["M1genbaika_tnk"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1genbaika_tnk"][i].RequestValue, formInfo["M1genbaika_tnk"]);
				paramCol["M1selectorcheckbox"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1selectorcheckbox"][i].RequestValue, formInfo["M1selectorcheckbox"]);
				paramCol["M1entersyoriflg"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1entersyoriflg"][i].RequestValue, formInfo["M1entersyoriflg"]);
				paramCol["M1dtlirokbn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1dtlirokbn"][i].RequestValue, formInfo["M1dtlirokbn"]);
				paramCol["M1makerkakaku_tnk"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1makerkakaku_tnk"][i].RequestValue, formInfo["M1makerkakaku_tnk"]);
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
			Th010f02Form formVO = (Th010f02Form)pageContext.GetFormVO();

			//カード項目の入力値をFormVOにコピーする
			if (paramCol["Head_tenpo_cd"].UnformatValue != null)
			{
				formVO.Head_tenpo_cd = paramCol["Head_tenpo_cd"].UnformatValue;
			}
			if (paramCol["Head_tenpo_nm"].UnformatValue != null)
			{
				formVO.Head_tenpo_nm = paramCol["Head_tenpo_nm"].UnformatValue;
			}
			if (paramCol["Siiresaki_cd"].UnformatValue != null)
			{
				formVO.Siiresaki_cd = paramCol["Siiresaki_cd"].UnformatValue;
			}
			if (paramCol["Siiresaki_ryaku_nm"].UnformatValue != null)
			{
				formVO.Siiresaki_ryaku_nm = paramCol["Siiresaki_ryaku_nm"].UnformatValue;
			}
			if (paramCol["Burando_cd"].UnformatValue != null)
			{
				formVO.Burando_cd = paramCol["Burando_cd"].UnformatValue;
			}
			if (paramCol["Burando_nm"].UnformatValue != null)
			{
				formVO.Burando_nm = paramCol["Burando_nm"].UnformatValue;
			}
			if (paramCol["Maker_hbn"].UnformatValue != null)
			{
				formVO.Maker_hbn = paramCol["Maker_hbn"].UnformatValue;
			}
			if (paramCol["Genka_flg"].UnformatValue != null)
			{
				formVO.Genka_flg = paramCol["Genka_flg"].UnformatValue;
			}
			if (paramCol["Genka"].UnformatValue != null)
			{
				formVO.Genka = paramCol["Genka"].UnformatValue;
			}
			if (paramCol["Genbaika_flg"].UnformatValue != null)
			{
				formVO.Genbaika_flg = paramCol["Genbaika_flg"].UnformatValue;
			}
			if (paramCol["Genbaika_tnk"].UnformatValue != null)
			{
				formVO.Genbaika_tnk = paramCol["Genbaika_tnk"].UnformatValue;
			}
			if (paramCol["Makerkakaku_flg"].UnformatValue != null)
			{
				formVO.Makerkakaku_flg = paramCol["Makerkakaku_flg"].UnformatValue;
			}
			if (paramCol["Makerkakaku_tnk"].UnformatValue != null)
			{
				formVO.Makerkakaku_tnk = paramCol["Makerkakaku_tnk"].UnformatValue;
			}
			if (paramCol["Searchcnt"].UnformatValue != null)
			{
				formVO.Searchcnt = paramCol["Searchcnt"].UnformatValue;
			}
			if (paramCol["Syohinmst_serchstk"].UnformatValue != null)
			{
				formVO.Syohinmst_serchstk = paramCol["Syohinmst_serchstk"].UnformatValue;
			}
			if (paramCol["Stkmodeno"].UnformatValue != null)
			{
				formVO.Stkmodeno = paramCol["Stkmodeno"].UnformatValue;
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
				Th010f02M1Form th010f02M1Form = (Th010f02M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					th010f02M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1siiresaki_cd"][i].UnformatValue != null)
				{
					th010f02M1Form.M1siiresaki_cd = paramCol["M1siiresaki_cd"][i].UnformatValue;
				}
				if (paramCol["M1siiresaki_ryaku_nm"][i].UnformatValue != null)
				{
					th010f02M1Form.M1siiresaki_ryaku_nm = paramCol["M1siiresaki_ryaku_nm"][i].UnformatValue;
				}
				if (paramCol["M1bumon_cd"][i].UnformatValue != null)
				{
					th010f02M1Form.M1bumon_cd = paramCol["M1bumon_cd"][i].UnformatValue;
				}
				if (paramCol["M1bumonkana_nm"][i].UnformatValue != null)
				{
					th010f02M1Form.M1bumonkana_nm = paramCol["M1bumonkana_nm"][i].UnformatValue;
				}
				if (paramCol["M1hinsyu_cd"][i].UnformatValue != null)
				{
					th010f02M1Form.M1hinsyu_cd = paramCol["M1hinsyu_cd"][i].UnformatValue;
				}
				if (paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue != null)
				{
					th010f02M1Form.M1hinsyu_ryaku_nm = paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue;
				}
				if (paramCol["M1burando_nm"][i].UnformatValue != null)
				{
					th010f02M1Form.M1burando_nm = paramCol["M1burando_nm"][i].UnformatValue;
				}
				if (paramCol["M1syohin_zokusei"][i].UnformatValue != null)
				{
					th010f02M1Form.M1syohin_zokusei = paramCol["M1syohin_zokusei"][i].UnformatValue;
				}
				if (paramCol["M1maker_hbn"][i].UnformatValue != null)
				{
					th010f02M1Form.M1maker_hbn = paramCol["M1maker_hbn"][i].UnformatValue;
				}
				if (paramCol["M1syonmk"][i].UnformatValue != null)
				{
					th010f02M1Form.M1syonmk = paramCol["M1syonmk"][i].UnformatValue;
				}
				if (paramCol["M1iro_nm"][i].UnformatValue != null)
				{
					th010f02M1Form.M1iro_nm = paramCol["M1iro_nm"][i].UnformatValue;
				}
				if (paramCol["M1hanbaikanryo_ymd"][i].DateFullValue != null)
				{
					th010f02M1Form.M1hanbaikanryo_ymd = paramCol["M1hanbaikanryo_ymd"][i].DateFullValue;
				}
				if (paramCol["M1saisinbaika_tnk"][i].UnformatValue != null)
				{
					th010f02M1Form.M1saisinbaika_tnk = paramCol["M1saisinbaika_tnk"][i].UnformatValue;
				}
				if (paramCol["M1genka"][i].UnformatValue != null)
				{
					th010f02M1Form.M1genka = paramCol["M1genka"][i].UnformatValue;
				}
				if (paramCol["M1genbaika_tnk"][i].UnformatValue != null)
				{
					th010f02M1Form.M1genbaika_tnk = paramCol["M1genbaika_tnk"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					th010f02M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					th010f02M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					th010f02M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
				}
				if (paramCol["M1makerkakaku_tnk"][i].UnformatValue != null)
				{
					th010f02M1Form.M1makerkakaku_tnk = paramCol["M1makerkakaku_tnk"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Th010f02Form formVO, StandardCheckManager checker)
		{
			if (formVO.Head_tenpo_cd != null)
			{
				checker.DoCheck("Head_tenpo_cd", formVO.Head_tenpo_cd);
			}
			if (formVO.Head_tenpo_nm != null)
			{
				checker.DoCheck("Head_tenpo_nm", formVO.Head_tenpo_nm);
			}
			if (formVO.Siiresaki_cd != null)
			{
				checker.DoCheck("Siiresaki_cd", formVO.Siiresaki_cd);
			}
			if (formVO.Siiresaki_ryaku_nm != null)
			{
				checker.DoCheck("Siiresaki_ryaku_nm", formVO.Siiresaki_ryaku_nm);
			}
			if (formVO.Burando_cd != null)
			{
				checker.DoCheck("Burando_cd", formVO.Burando_cd);
			}
			if (formVO.Burando_nm != null)
			{
				checker.DoCheck("Burando_nm", formVO.Burando_nm);
			}
			if (formVO.Maker_hbn != null)
			{
				checker.DoCheck("Maker_hbn", formVO.Maker_hbn);
			}
			if (formVO.Genka_flg != null)
			{
				checker.DoCheck("Genka_flg", formVO.Genka_flg);
			}
			if (formVO.Genka != null)
			{
				checker.DoCheck("Genka", formVO.Genka);
			}
			if (formVO.Genbaika_flg != null)
			{
				checker.DoCheck("Genbaika_flg", formVO.Genbaika_flg);
			}
			if (formVO.Genbaika_tnk != null)
			{
				checker.DoCheck("Genbaika_tnk", formVO.Genbaika_tnk);
			}
			if (formVO.Makerkakaku_flg != null)
			{
				checker.DoCheck("Makerkakaku_flg", formVO.Makerkakaku_flg);
			}
			if (formVO.Makerkakaku_tnk != null)
			{
				checker.DoCheck("Makerkakaku_tnk", formVO.Makerkakaku_tnk);
			}
			if (formVO.Searchcnt != null)
			{
				checker.DoCheck("Searchcnt", formVO.Searchcnt);
			}
			if (formVO.Syohinmst_serchstk != null)
			{
				checker.DoCheck("Syohinmst_serchstk", formVO.Syohinmst_serchstk);
			}
			if (formVO.Stkmodeno != null)
			{
				checker.DoCheck("Stkmodeno", formVO.Stkmodeno);
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
		public static void ValidateM1InputValue(Th010f02Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Th010f02M1Form th010f02M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, th010f02M1Form, i, m1List);
				if (th010f02M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", th010f02M1Form.M1rowno, i, m1List);
				}
				if (th010f02M1Form.M1siiresaki_cd != null)
				{
					checker.DoCheck("M1siiresaki_cd", th010f02M1Form.M1siiresaki_cd, i, m1List);
				}
				if (th010f02M1Form.M1siiresaki_ryaku_nm != null)
				{
					checker.DoCheck("M1siiresaki_ryaku_nm", th010f02M1Form.M1siiresaki_ryaku_nm, i, m1List);
				}
				if (th010f02M1Form.M1bumon_cd != null)
				{
					checker.DoCheck("M1bumon_cd", th010f02M1Form.M1bumon_cd, i, m1List);
				}
				if (th010f02M1Form.M1bumonkana_nm != null)
				{
					checker.DoCheck("M1bumonkana_nm", th010f02M1Form.M1bumonkana_nm, i, m1List);
				}
				if (th010f02M1Form.M1hinsyu_cd != null)
				{
					checker.DoCheck("M1hinsyu_cd", th010f02M1Form.M1hinsyu_cd, i, m1List);
				}
				if (th010f02M1Form.M1hinsyu_ryaku_nm != null)
				{
					checker.DoCheck("M1hinsyu_ryaku_nm", th010f02M1Form.M1hinsyu_ryaku_nm, i, m1List);
				}
				if (th010f02M1Form.M1burando_nm != null)
				{
					checker.DoCheck("M1burando_nm", th010f02M1Form.M1burando_nm, i, m1List);
				}
				if (th010f02M1Form.M1syohin_zokusei != null)
				{
					checker.DoCheck("M1syohin_zokusei", th010f02M1Form.M1syohin_zokusei, i, m1List);
				}
				if (th010f02M1Form.M1maker_hbn != null)
				{
					checker.DoCheck("M1maker_hbn", th010f02M1Form.M1maker_hbn, i, m1List);
				}
				if (th010f02M1Form.M1syonmk != null)
				{
					checker.DoCheck("M1syonmk", th010f02M1Form.M1syonmk, i, m1List);
				}
				if (th010f02M1Form.M1iro_nm != null)
				{
					checker.DoCheck("M1iro_nm", th010f02M1Form.M1iro_nm, i, m1List);
				}
				if (th010f02M1Form.M1hanbaikanryo_ymd != null)
				{
					checker.DoCheck("M1hanbaikanryo_ymd", th010f02M1Form.M1hanbaikanryo_ymd, i, m1List);
				}
				if (th010f02M1Form.M1saisinbaika_tnk != null)
				{
					checker.DoCheck("M1saisinbaika_tnk", th010f02M1Form.M1saisinbaika_tnk, i, m1List);
				}
				if (th010f02M1Form.M1genka != null)
				{
					checker.DoCheck("M1genka", th010f02M1Form.M1genka, i, m1List);
				}
				if (th010f02M1Form.M1genbaika_tnk != null)
				{
					checker.DoCheck("M1genbaika_tnk", th010f02M1Form.M1genbaika_tnk, i, m1List);
				}
				if (th010f02M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", th010f02M1Form.M1selectorcheckbox, i, m1List);
				}
				if (th010f02M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", th010f02M1Form.M1entersyoriflg, i, m1List);
				}
				if (th010f02M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", th010f02M1Form.M1dtlirokbn, i, m1List);
				}
				if (th010f02M1Form.M1makerkakaku_tnk != null)
				{
					checker.DoCheck("M1makerkakaku_tnk", th010f02M1Form.M1makerkakaku_tnk, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Th010f02Form formVO, StandardCodeCheckManager checker)
		{
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Th010f02Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

