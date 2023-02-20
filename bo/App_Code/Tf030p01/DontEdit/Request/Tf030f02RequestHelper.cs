using com.xebio.bo.Tf030p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Tf030p01.Request
{
  /// <summary>
  /// Tf030f02RequestHelper の概要の説明です。
  /// </summary>
  public static class Tf030f02RequestHelper
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
			Tf030f02Form formVO = (Tf030f02Form)pageContext.GetFormVO();

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
			paramCol["Add_ymd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Add_ymd"]);
			paramCol["Tenpo_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tenpo_cd"]);
			paramCol["Tenpo_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tenpo_nm"]);
			paramCol["Kenpinsya_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Kenpinsya_cd"]);
			paramCol["Kenpinsya_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Kenpinsya_nm"]);
			paramCol["Siiresaki_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Siiresaki_cd"]);
			paramCol["Siiresaki_ryaku_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Siiresaki_ryaku_nm"]);
			paramCol["Denpyo_bango"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Denpyo_bango"]);
			paramCol["Motodenpyo_bango"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Motodenpyo_bango"]);
			paramCol["Nyuryokutan_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Nyuryokutan_cd"]);
			paramCol["Nyuryokutan_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Nyuryokutan_nm"]);
			paramCol["Nohin_ymd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Nohin_ymd"]);
			paramCol["Gokei_suryo"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokei_suryo"]);
			paramCol["Gokei_kin"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokei_kin"]);
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
				paramCol["M1tekiyo_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tekiyo_cd"]);
				paramCol["M1tekiyo_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tekiyo_nm"]);
				paramCol["M1suryo"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1suryo"]);
				paramCol["M1tnk"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tnk"]);
				paramCol["M1kingaku"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1kingaku"]);
				paramCol["M1suryo_hdn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1suryo_hdn"]);
				paramCol["M1kingaku_hdn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1kingaku_hdn"]);
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
			Tf030f02Form formVO = (Tf030f02Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Stkmodeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Stkmodeno"].RequestValue, formInfo["Stkmodeno"]);
			paramCol["Add_ymd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Add_ymd"].RequestValue, formInfo["Add_ymd"]);
			paramCol["Add_ymd"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Add_ymd"].RequestValue, formInfo["Add_ymd"]);
			paramCol["Tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tenpo_cd"].RequestValue, formInfo["Tenpo_cd"]);
			paramCol["Tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tenpo_nm"].RequestValue, formInfo["Tenpo_nm"]);
			paramCol["Kenpinsya_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Kenpinsya_cd"].RequestValue, formInfo["Kenpinsya_cd"]);
			paramCol["Kenpinsya_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Kenpinsya_nm"].RequestValue, formInfo["Kenpinsya_nm"]);
			paramCol["Siiresaki_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Siiresaki_cd"].RequestValue, formInfo["Siiresaki_cd"]);
			paramCol["Siiresaki_ryaku_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Siiresaki_ryaku_nm"].RequestValue, formInfo["Siiresaki_ryaku_nm"]);
			paramCol["Denpyo_bango"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Denpyo_bango"].RequestValue, formInfo["Denpyo_bango"]);
			paramCol["Motodenpyo_bango"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Motodenpyo_bango"].RequestValue, formInfo["Motodenpyo_bango"]);
			paramCol["Nyuryokutan_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Nyuryokutan_cd"].RequestValue, formInfo["Nyuryokutan_cd"]);
			paramCol["Nyuryokutan_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Nyuryokutan_nm"].RequestValue, formInfo["Nyuryokutan_nm"]);
			paramCol["Nohin_ymd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Nohin_ymd"].RequestValue, formInfo["Nohin_ymd"]);
			paramCol["Nohin_ymd"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Nohin_ymd"].RequestValue, formInfo["Nohin_ymd"]);
			paramCol["Gokei_suryo"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokei_suryo"].RequestValue, formInfo["Gokei_suryo"]);
			paramCol["Gokei_kin"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokei_kin"].RequestValue, formInfo["Gokei_kin"]);
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
				paramCol["M1tekiyo_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tekiyo_cd"][i].RequestValue, formInfo["M1tekiyo_cd"]);
				paramCol["M1tekiyo_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tekiyo_nm"][i].RequestValue, formInfo["M1tekiyo_nm"]);
				paramCol["M1suryo"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1suryo"][i].RequestValue, formInfo["M1suryo"]);
				paramCol["M1tnk"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tnk"][i].RequestValue, formInfo["M1tnk"]);
				paramCol["M1kingaku"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1kingaku"][i].RequestValue, formInfo["M1kingaku"]);
				paramCol["M1suryo_hdn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1suryo_hdn"][i].RequestValue, formInfo["M1suryo_hdn"]);
				paramCol["M1kingaku_hdn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1kingaku_hdn"][i].RequestValue, formInfo["M1kingaku_hdn"]);
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
			Tf030f02Form formVO = (Tf030f02Form)pageContext.GetFormVO();

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
			if (paramCol["Add_ymd"].DateFullValue != null)
			{
				formVO.Add_ymd = paramCol["Add_ymd"].DateFullValue;
			}
			if (paramCol["Tenpo_cd"].UnformatValue != null)
			{
				formVO.Tenpo_cd = paramCol["Tenpo_cd"].UnformatValue;
			}
			if (paramCol["Tenpo_nm"].UnformatValue != null)
			{
				formVO.Tenpo_nm = paramCol["Tenpo_nm"].UnformatValue;
			}
			if (paramCol["Kenpinsya_cd"].UnformatValue != null)
			{
				formVO.Kenpinsya_cd = paramCol["Kenpinsya_cd"].UnformatValue;
			}
			if (paramCol["Kenpinsya_nm"].UnformatValue != null)
			{
				formVO.Kenpinsya_nm = paramCol["Kenpinsya_nm"].UnformatValue;
			}
			if (paramCol["Siiresaki_cd"].UnformatValue != null)
			{
				formVO.Siiresaki_cd = paramCol["Siiresaki_cd"].UnformatValue;
			}
			if (paramCol["Siiresaki_ryaku_nm"].UnformatValue != null)
			{
				formVO.Siiresaki_ryaku_nm = paramCol["Siiresaki_ryaku_nm"].UnformatValue;
			}
			if (paramCol["Denpyo_bango"].UnformatValue != null)
			{
				formVO.Denpyo_bango = paramCol["Denpyo_bango"].UnformatValue;
			}
			if (paramCol["Motodenpyo_bango"].UnformatValue != null)
			{
				formVO.Motodenpyo_bango = paramCol["Motodenpyo_bango"].UnformatValue;
			}
			if (paramCol["Nyuryokutan_cd"].UnformatValue != null)
			{
				formVO.Nyuryokutan_cd = paramCol["Nyuryokutan_cd"].UnformatValue;
			}
			if (paramCol["Nyuryokutan_nm"].UnformatValue != null)
			{
				formVO.Nyuryokutan_nm = paramCol["Nyuryokutan_nm"].UnformatValue;
			}
			if (paramCol["Nohin_ymd"].DateFullValue != null)
			{
				formVO.Nohin_ymd = paramCol["Nohin_ymd"].DateFullValue;
			}
			if (paramCol["Gokei_suryo"].UnformatValue != null)
			{
				formVO.Gokei_suryo = paramCol["Gokei_suryo"].UnformatValue;
			}
			if (paramCol["Gokei_kin"].UnformatValue != null)
			{
				formVO.Gokei_kin = paramCol["Gokei_kin"].UnformatValue;
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
				Tf030f02M1Form tf030f02M1Form = (Tf030f02M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					tf030f02M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1tekiyo_cd"][i].UnformatValue != null)
				{
					tf030f02M1Form.M1tekiyo_cd = paramCol["M1tekiyo_cd"][i].UnformatValue;
				}
				if (paramCol["M1tekiyo_nm"][i].UnformatValue != null)
				{
					tf030f02M1Form.M1tekiyo_nm = paramCol["M1tekiyo_nm"][i].UnformatValue;
				}
				if (paramCol["M1suryo"][i].UnformatValue != null)
				{
					tf030f02M1Form.M1suryo = paramCol["M1suryo"][i].UnformatValue;
				}
				if (paramCol["M1tnk"][i].UnformatValue != null)
				{
					tf030f02M1Form.M1tnk = paramCol["M1tnk"][i].UnformatValue;
				}
				if (paramCol["M1kingaku"][i].UnformatValue != null)
				{
					tf030f02M1Form.M1kingaku = paramCol["M1kingaku"][i].UnformatValue;
				}
				if (paramCol["M1suryo_hdn"][i].UnformatValue != null)
				{
					tf030f02M1Form.M1suryo_hdn = paramCol["M1suryo_hdn"][i].UnformatValue;
				}
				if (paramCol["M1kingaku_hdn"][i].UnformatValue != null)
				{
					tf030f02M1Form.M1kingaku_hdn = paramCol["M1kingaku_hdn"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					tf030f02M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					tf030f02M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					tf030f02M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Tf030f02Form formVO, StandardCheckManager checker)
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
			if (formVO.Add_ymd != null)
			{
				checker.DoCheck("Add_ymd", formVO.Add_ymd);
			}
			if (formVO.Tenpo_cd != null)
			{
				checker.DoCheck("Tenpo_cd", formVO.Tenpo_cd);
			}
			if (formVO.Tenpo_nm != null)
			{
				checker.DoCheck("Tenpo_nm", formVO.Tenpo_nm);
			}
			if (formVO.Kenpinsya_cd != null)
			{
				checker.DoCheck("Kenpinsya_cd", formVO.Kenpinsya_cd);
			}
			if (formVO.Kenpinsya_nm != null)
			{
				checker.DoCheck("Kenpinsya_nm", formVO.Kenpinsya_nm);
			}
			if (formVO.Siiresaki_cd != null)
			{
				checker.DoCheck("Siiresaki_cd", formVO.Siiresaki_cd);
			}
			if (formVO.Siiresaki_ryaku_nm != null)
			{
				checker.DoCheck("Siiresaki_ryaku_nm", formVO.Siiresaki_ryaku_nm);
			}
			if (formVO.Denpyo_bango != null)
			{
				checker.DoCheck("Denpyo_bango", formVO.Denpyo_bango);
			}
			if (formVO.Motodenpyo_bango != null)
			{
				checker.DoCheck("Motodenpyo_bango", formVO.Motodenpyo_bango);
			}
			if (formVO.Nyuryokutan_cd != null)
			{
				checker.DoCheck("Nyuryokutan_cd", formVO.Nyuryokutan_cd);
			}
			if (formVO.Nyuryokutan_nm != null)
			{
				checker.DoCheck("Nyuryokutan_nm", formVO.Nyuryokutan_nm);
			}
			if (formVO.Nohin_ymd != null)
			{
				checker.DoCheck("Nohin_ymd", formVO.Nohin_ymd);
			}
			if (formVO.Gokei_suryo != null)
			{
				checker.DoCheck("Gokei_suryo", formVO.Gokei_suryo);
			}
			if (formVO.Gokei_kin != null)
			{
				checker.DoCheck("Gokei_kin", formVO.Gokei_kin);
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
		public static void ValidateM1InputValue(Tf030f02Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Tf030f02M1Form tf030f02M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, tf030f02M1Form, i, m1List);
				if (tf030f02M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", tf030f02M1Form.M1rowno, i, m1List);
				}
				if (tf030f02M1Form.M1tekiyo_cd != null)
				{
					checker.DoCheck("M1tekiyo_cd", tf030f02M1Form.M1tekiyo_cd, i, m1List);
				}
				if (tf030f02M1Form.M1tekiyo_nm != null)
				{
					checker.DoCheck("M1tekiyo_nm", tf030f02M1Form.M1tekiyo_nm, i, m1List);
				}
				if (tf030f02M1Form.M1suryo != null)
				{
					checker.DoCheck("M1suryo", tf030f02M1Form.M1suryo, i, m1List);
				}
				if (tf030f02M1Form.M1tnk != null)
				{
					checker.DoCheck("M1tnk", tf030f02M1Form.M1tnk, i, m1List);
				}
				if (tf030f02M1Form.M1kingaku != null)
				{
					checker.DoCheck("M1kingaku", tf030f02M1Form.M1kingaku, i, m1List);
				}
				if (tf030f02M1Form.M1suryo_hdn != null)
				{
					checker.DoCheck("M1suryo_hdn", tf030f02M1Form.M1suryo_hdn, i, m1List);
				}
				if (tf030f02M1Form.M1kingaku_hdn != null)
				{
					checker.DoCheck("M1kingaku_hdn", tf030f02M1Form.M1kingaku_hdn, i, m1List);
				}
				if (tf030f02M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", tf030f02M1Form.M1selectorcheckbox, i, m1List);
				}
				if (tf030f02M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", tf030f02M1Form.M1entersyoriflg, i, m1List);
				}
				if (tf030f02M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", tf030f02M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Tf030f02Form formVO, StandardCodeCheckManager checker)
		{
			checker.DoCheck("Btntenpocd", formVO);
			checker.DoCheck("Btntanto_cd", formVO);
			checker.DoCheck("Btnsiiresaki_cd", formVO);
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Tf030f02Form formVO, StandardCodeCheckManager checker)
		{
			checker.DoCheck("M1btntekiyo_cd", formVO);
		}
	}
}

