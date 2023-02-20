using com.xebio.bo.Ta030p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Ta030p01.Request
{
  /// <summary>
  /// Ta030f02RequestHelper の概要の説明です。
  /// </summary>
  public static class Ta030f02RequestHelper
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
			Ta030f02Form formVO = (Ta030f02Form)pageContext.GetFormVO();

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
			paramCol["Gokei_itemsu"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokei_itemsu"]);
			paramCol["Gokei_kingaku"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokei_kingaku"]);
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
				paramCol["M1hojuirai_kbn_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hojuirai_kbn_nm"]);
				paramCol["M1sinsei_jotainm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1sinsei_jotainm"]);
				paramCol["M1bumon_cd_bo"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1bumon_cd_bo"]);
				paramCol["M1bumonkana_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1bumonkana_nm"]);
				paramCol["M1hinsyu_ryaku_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hinsyu_ryaku_nm"]);
				paramCol["M1burando_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1burando_nm"]);
				paramCol["M1jisya_hbn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1jisya_hbn"]);
				paramCol["M1syohin_zokusei"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1syohin_zokusei"]);
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
				paramCol["M1itemsu"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1itemsu"]);
				paramCol["M1kingaku"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1kingaku"]);
				paramCol["M1hattyu_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hattyu_ymd"]);
				paramCol["M1hanbaiin_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hanbaiin_nm"]);
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
			Ta030f02Form formVO = (Ta030f02Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Stkmodeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Stkmodeno"].RequestValue, formInfo["Stkmodeno"]);
			paramCol["Gokei_itemsu"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokei_itemsu"].RequestValue, formInfo["Gokei_itemsu"]);
			paramCol["Gokei_kingaku"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokei_kingaku"].RequestValue, formInfo["Gokei_kingaku"]);
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
				paramCol["M1hojuirai_kbn_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hojuirai_kbn_nm"][i].RequestValue, formInfo["M1hojuirai_kbn_nm"]);
				paramCol["M1sinsei_jotainm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1sinsei_jotainm"][i].RequestValue, formInfo["M1sinsei_jotainm"]);
				paramCol["M1bumon_cd_bo"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1bumon_cd_bo"][i].RequestValue, formInfo["M1bumon_cd_bo"]);
				paramCol["M1bumonkana_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1bumonkana_nm"][i].RequestValue, formInfo["M1bumonkana_nm"]);
				paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hinsyu_ryaku_nm"][i].RequestValue, formInfo["M1hinsyu_ryaku_nm"]);
				paramCol["M1burando_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1burando_nm"][i].RequestValue, formInfo["M1burando_nm"]);
				paramCol["M1jisya_hbn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1jisya_hbn"][i].RequestValue, formInfo["M1jisya_hbn"]);
				paramCol["M1syohin_zokusei"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1syohin_zokusei"][i].RequestValue, formInfo["M1syohin_zokusei"]);
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
				paramCol["M1itemsu"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1itemsu"][i].RequestValue, formInfo["M1itemsu"]);
				paramCol["M1kingaku"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1kingaku"][i].RequestValue, formInfo["M1kingaku"]);
				paramCol["M1hattyu_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hattyu_ymd"][i].RequestValue, formInfo["M1hattyu_ymd"]);
				paramCol["M1hattyu_ymd"][i].DateFullValue = RequestParameterUtil.GetDateFullValue(
					paramCol["M1hattyu_ymd"][i].RequestValue, formInfo["M1hattyu_ymd"]);
				paramCol["M1hanbaiin_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hanbaiin_nm"][i].RequestValue, formInfo["M1hanbaiin_nm"]);
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
			Ta030f02Form formVO = (Ta030f02Form)pageContext.GetFormVO();

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
			if (paramCol["Gokei_itemsu"].UnformatValue != null)
			{
				formVO.Gokei_itemsu = paramCol["Gokei_itemsu"].UnformatValue;
			}
			if (paramCol["Gokei_kingaku"].UnformatValue != null)
			{
				formVO.Gokei_kingaku = paramCol["Gokei_kingaku"].UnformatValue;
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
				Ta030f02M1Form ta030f02M1Form = (Ta030f02M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					ta030f02M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1hojuirai_kbn_nm"][i].UnformatValue != null)
				{
					ta030f02M1Form.M1hojuirai_kbn_nm = paramCol["M1hojuirai_kbn_nm"][i].UnformatValue;
				}
				if (paramCol["M1sinsei_jotainm"][i].UnformatValue != null)
				{
					ta030f02M1Form.M1sinsei_jotainm = paramCol["M1sinsei_jotainm"][i].UnformatValue;
				}
				if (paramCol["M1bumon_cd_bo"][i].UnformatValue != null)
				{
					ta030f02M1Form.M1bumon_cd_bo = paramCol["M1bumon_cd_bo"][i].UnformatValue;
				}
				if (paramCol["M1bumonkana_nm"][i].UnformatValue != null)
				{
					ta030f02M1Form.M1bumonkana_nm = paramCol["M1bumonkana_nm"][i].UnformatValue;
				}
				if (paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue != null)
				{
					ta030f02M1Form.M1hinsyu_ryaku_nm = paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue;
				}
				if (paramCol["M1burando_nm"][i].UnformatValue != null)
				{
					ta030f02M1Form.M1burando_nm = paramCol["M1burando_nm"][i].UnformatValue;
				}
				if (paramCol["M1jisya_hbn"][i].UnformatValue != null)
				{
					ta030f02M1Form.M1jisya_hbn = paramCol["M1jisya_hbn"][i].UnformatValue;
				}
				if (paramCol["M1syohin_zokusei"][i].UnformatValue != null)
				{
					ta030f02M1Form.M1syohin_zokusei = paramCol["M1syohin_zokusei"][i].UnformatValue;
				}
				if (paramCol["M1maker_hbn"][i].UnformatValue != null)
				{
					ta030f02M1Form.M1maker_hbn = paramCol["M1maker_hbn"][i].UnformatValue;
				}
				if (paramCol["M1syonmk"][i].UnformatValue != null)
				{
					ta030f02M1Form.M1syonmk = paramCol["M1syonmk"][i].UnformatValue;
				}
				if (paramCol["M1iro_nm"][i].UnformatValue != null)
				{
					ta030f02M1Form.M1iro_nm = paramCol["M1iro_nm"][i].UnformatValue;
				}
				if (paramCol["M1size_nm"][i].UnformatValue != null)
				{
					ta030f02M1Form.M1size_nm = paramCol["M1size_nm"][i].UnformatValue;
				}
				if (paramCol["M1scan_cd"][i].UnformatValue != null)
				{
					ta030f02M1Form.M1scan_cd = paramCol["M1scan_cd"][i].UnformatValue;
				}
				if (paramCol["M1itemsu"][i].UnformatValue != null)
				{
					ta030f02M1Form.M1itemsu = paramCol["M1itemsu"][i].UnformatValue;
				}
				if (paramCol["M1kingaku"][i].UnformatValue != null)
				{
					ta030f02M1Form.M1kingaku = paramCol["M1kingaku"][i].UnformatValue;
				}
				if (paramCol["M1hattyu_ymd"][i].DateFullValue != null)
				{
					ta030f02M1Form.M1hattyu_ymd = paramCol["M1hattyu_ymd"][i].DateFullValue;
				}
				if (paramCol["M1hanbaiin_nm"][i].UnformatValue != null)
				{
					ta030f02M1Form.M1hanbaiin_nm = paramCol["M1hanbaiin_nm"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					ta030f02M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					ta030f02M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					ta030f02M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Ta030f02Form formVO, StandardCheckManager checker)
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
			if (formVO.Gokei_itemsu != null)
			{
				checker.DoCheck("Gokei_itemsu", formVO.Gokei_itemsu);
			}
			if (formVO.Gokei_kingaku != null)
			{
				checker.DoCheck("Gokei_kingaku", formVO.Gokei_kingaku);
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
		public static void ValidateM1InputValue(Ta030f02Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Ta030f02M1Form ta030f02M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, ta030f02M1Form, i, m1List);
				if (ta030f02M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", ta030f02M1Form.M1rowno, i, m1List);
				}
				if (ta030f02M1Form.M1hojuirai_kbn_nm != null)
				{
					checker.DoCheck("M1hojuirai_kbn_nm", ta030f02M1Form.M1hojuirai_kbn_nm, i, m1List);
				}
				if (ta030f02M1Form.M1sinsei_jotainm != null)
				{
					checker.DoCheck("M1sinsei_jotainm", ta030f02M1Form.M1sinsei_jotainm, i, m1List);
				}
				if (ta030f02M1Form.M1bumon_cd_bo != null)
				{
					checker.DoCheck("M1bumon_cd_bo", ta030f02M1Form.M1bumon_cd_bo, i, m1List);
				}
				if (ta030f02M1Form.M1bumonkana_nm != null)
				{
					checker.DoCheck("M1bumonkana_nm", ta030f02M1Form.M1bumonkana_nm, i, m1List);
				}
				if (ta030f02M1Form.M1hinsyu_ryaku_nm != null)
				{
					checker.DoCheck("M1hinsyu_ryaku_nm", ta030f02M1Form.M1hinsyu_ryaku_nm, i, m1List);
				}
				if (ta030f02M1Form.M1burando_nm != null)
				{
					checker.DoCheck("M1burando_nm", ta030f02M1Form.M1burando_nm, i, m1List);
				}
				if (ta030f02M1Form.M1jisya_hbn != null)
				{
					checker.DoCheck("M1jisya_hbn", ta030f02M1Form.M1jisya_hbn, i, m1List);
				}
				if (ta030f02M1Form.M1syohin_zokusei != null)
				{
					checker.DoCheck("M1syohin_zokusei", ta030f02M1Form.M1syohin_zokusei, i, m1List);
				}
				if (ta030f02M1Form.M1maker_hbn != null)
				{
					checker.DoCheck("M1maker_hbn", ta030f02M1Form.M1maker_hbn, i, m1List);
				}
				if (ta030f02M1Form.M1syonmk != null)
				{
					checker.DoCheck("M1syonmk", ta030f02M1Form.M1syonmk, i, m1List);
				}
				if (ta030f02M1Form.M1iro_nm != null)
				{
					checker.DoCheck("M1iro_nm", ta030f02M1Form.M1iro_nm, i, m1List);
				}
				if (ta030f02M1Form.M1size_nm != null)
				{
					checker.DoCheck("M1size_nm", ta030f02M1Form.M1size_nm, i, m1List);
				}
				if (ta030f02M1Form.M1scan_cd != null)
				{
					checker.DoCheck("M1scan_cd", ta030f02M1Form.M1scan_cd, i, m1List);
				}
				if (ta030f02M1Form.M1itemsu != null)
				{
					checker.DoCheck("M1itemsu", ta030f02M1Form.M1itemsu, i, m1List);
				}
				if (ta030f02M1Form.M1kingaku != null)
				{
					checker.DoCheck("M1kingaku", ta030f02M1Form.M1kingaku, i, m1List);
				}
				if (ta030f02M1Form.M1hattyu_ymd != null)
				{
					checker.DoCheck("M1hattyu_ymd", ta030f02M1Form.M1hattyu_ymd, i, m1List);
				}
				if (ta030f02M1Form.M1hanbaiin_nm != null)
				{
					checker.DoCheck("M1hanbaiin_nm", ta030f02M1Form.M1hanbaiin_nm, i, m1List);
				}
				if (ta030f02M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", ta030f02M1Form.M1selectorcheckbox, i, m1List);
				}
				if (ta030f02M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", ta030f02M1Form.M1entersyoriflg, i, m1List);
				}
				if (ta030f02M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", ta030f02M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Ta030f02Form formVO, StandardCodeCheckManager checker)
		{
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Ta030f02Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

