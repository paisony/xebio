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
  /// Tf030f01RequestHelper の概要の説明です。
  /// </summary>
  public static class Tf030f01RequestHelper
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
			Tf030f01Form formVO = (Tf030f01Form)pageContext.GetFormVO();

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
			paramCol["Add_ymd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Add_ymd_from"]);
			paramCol["Add_ymd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Add_ymd_to"]);
			paramCol["Tenpo_cd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tenpo_cd_from"]);
			paramCol["Tenpo_nm_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tenpo_nm_from"]);
			paramCol["Tenpo_cd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tenpo_cd_to"]);
			paramCol["Tenpo_nm_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tenpo_nm_to"]);
			paramCol["Siiresaki_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Siiresaki_cd"]);
			paramCol["Siiresaki_ryaku_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Siiresaki_ryaku_nm"]);
			paramCol["Denpyo_bango_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Denpyo_bango_from"]);
			paramCol["Denpyo_bango_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Denpyo_bango_to"]);
			paramCol["Motodenpyo_bango_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Motodenpyo_bango_from"]);
			paramCol["Motodenpyo_bango_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Motodenpyo_bango_to"]);
			paramCol["Searchcnt"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Searchcnt"]);
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
				paramCol["M1add_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1add_ymd"]);
				paramCol["M1tenpo_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tenpo_cd"]);
				paramCol["M1tenpo_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tenpo_nm"]);
				paramCol["M1siiresaki_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1siiresaki_cd"]);
				paramCol["M1siiresaki_ryaku_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1siiresaki_ryaku_nm"]);
				paramCol["M1motodenpyo_bango"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1motodenpyo_bango"]);
				paramCol["M1nohin_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1nohin_ymd"]);
				paramCol["M1nyuryokutan_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1nyuryokutan_nm"]);
				paramCol["M1itemsu"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1itemsu"]);
				paramCol["M1kingaku"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1kingaku"]);
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
			Tf030f01Form formVO = (Tf030f01Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Modeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Modeno"].RequestValue, formInfo["Modeno"]);
			paramCol["Stkmodeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Stkmodeno"].RequestValue, formInfo["Stkmodeno"]);
			paramCol["Add_ymd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Add_ymd_from"].RequestValue, formInfo["Add_ymd_from"]);
			paramCol["Add_ymd_from"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Add_ymd_from"].RequestValue, formInfo["Add_ymd_from"]);
			paramCol["Add_ymd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Add_ymd_to"].RequestValue, formInfo["Add_ymd_to"]);
			paramCol["Add_ymd_to"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Add_ymd_to"].RequestValue, formInfo["Add_ymd_to"]);
			paramCol["Tenpo_cd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tenpo_cd_from"].RequestValue, formInfo["Tenpo_cd_from"]);
			paramCol["Tenpo_nm_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tenpo_nm_from"].RequestValue, formInfo["Tenpo_nm_from"]);
			paramCol["Tenpo_cd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tenpo_cd_to"].RequestValue, formInfo["Tenpo_cd_to"]);
			paramCol["Tenpo_nm_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tenpo_nm_to"].RequestValue, formInfo["Tenpo_nm_to"]);
			paramCol["Siiresaki_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Siiresaki_cd"].RequestValue, formInfo["Siiresaki_cd"]);
			paramCol["Siiresaki_ryaku_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Siiresaki_ryaku_nm"].RequestValue, formInfo["Siiresaki_ryaku_nm"]);
			paramCol["Denpyo_bango_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Denpyo_bango_from"].RequestValue, formInfo["Denpyo_bango_from"]);
			paramCol["Denpyo_bango_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Denpyo_bango_to"].RequestValue, formInfo["Denpyo_bango_to"]);
			paramCol["Motodenpyo_bango_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Motodenpyo_bango_from"].RequestValue, formInfo["Motodenpyo_bango_from"]);
			paramCol["Motodenpyo_bango_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Motodenpyo_bango_to"].RequestValue, formInfo["Motodenpyo_bango_to"]);
			paramCol["Searchcnt"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Searchcnt"].RequestValue, formInfo["Searchcnt"]);
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
				paramCol["M1add_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1add_ymd"][i].RequestValue, formInfo["M1add_ymd"]);
				paramCol["M1add_ymd"][i].DateFullValue = RequestParameterUtil.GetDateFullValue(
					paramCol["M1add_ymd"][i].RequestValue, formInfo["M1add_ymd"]);
				paramCol["M1tenpo_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tenpo_cd"][i].RequestValue, formInfo["M1tenpo_cd"]);
				paramCol["M1tenpo_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tenpo_nm"][i].RequestValue, formInfo["M1tenpo_nm"]);
				paramCol["M1siiresaki_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1siiresaki_cd"][i].RequestValue, formInfo["M1siiresaki_cd"]);
				paramCol["M1siiresaki_ryaku_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1siiresaki_ryaku_nm"][i].RequestValue, formInfo["M1siiresaki_ryaku_nm"]);
				paramCol["M1motodenpyo_bango"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1motodenpyo_bango"][i].RequestValue, formInfo["M1motodenpyo_bango"]);
				paramCol["M1nohin_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1nohin_ymd"][i].RequestValue, formInfo["M1nohin_ymd"]);
				paramCol["M1nohin_ymd"][i].DateFullValue = RequestParameterUtil.GetDateFullValue(
					paramCol["M1nohin_ymd"][i].RequestValue, formInfo["M1nohin_ymd"]);
				paramCol["M1nyuryokutan_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1nyuryokutan_nm"][i].RequestValue, formInfo["M1nyuryokutan_nm"]);
				paramCol["M1itemsu"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1itemsu"][i].RequestValue, formInfo["M1itemsu"]);
				paramCol["M1kingaku"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1kingaku"][i].RequestValue, formInfo["M1kingaku"]);
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
			Tf030f01Form formVO = (Tf030f01Form)pageContext.GetFormVO();

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
			if (paramCol["Add_ymd_from"].DateFullValue != null)
			{
				formVO.Add_ymd_from = paramCol["Add_ymd_from"].DateFullValue;
			}
			if (paramCol["Add_ymd_to"].DateFullValue != null)
			{
				formVO.Add_ymd_to = paramCol["Add_ymd_to"].DateFullValue;
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
			if (paramCol["Siiresaki_cd"].UnformatValue != null)
			{
				formVO.Siiresaki_cd = paramCol["Siiresaki_cd"].UnformatValue;
			}
			if (paramCol["Siiresaki_ryaku_nm"].UnformatValue != null)
			{
				formVO.Siiresaki_ryaku_nm = paramCol["Siiresaki_ryaku_nm"].UnformatValue;
			}
			if (paramCol["Denpyo_bango_from"].UnformatValue != null)
			{
				formVO.Denpyo_bango_from = paramCol["Denpyo_bango_from"].UnformatValue;
			}
			if (paramCol["Denpyo_bango_to"].UnformatValue != null)
			{
				formVO.Denpyo_bango_to = paramCol["Denpyo_bango_to"].UnformatValue;
			}
			if (paramCol["Motodenpyo_bango_from"].UnformatValue != null)
			{
				formVO.Motodenpyo_bango_from = paramCol["Motodenpyo_bango_from"].UnformatValue;
			}
			if (paramCol["Motodenpyo_bango_to"].UnformatValue != null)
			{
				formVO.Motodenpyo_bango_to = paramCol["Motodenpyo_bango_to"].UnformatValue;
			}
			if (paramCol["Searchcnt"].UnformatValue != null)
			{
				formVO.Searchcnt = paramCol["Searchcnt"].UnformatValue;
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
				Tf030f01M1Form tf030f01M1Form = (Tf030f01M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					tf030f01M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1add_ymd"][i].DateFullValue != null)
				{
					tf030f01M1Form.M1add_ymd = paramCol["M1add_ymd"][i].DateFullValue;
				}
				if (paramCol["M1tenpo_cd"][i].UnformatValue != null)
				{
					tf030f01M1Form.M1tenpo_cd = paramCol["M1tenpo_cd"][i].UnformatValue;
				}
				if (paramCol["M1tenpo_nm"][i].UnformatValue != null)
				{
					tf030f01M1Form.M1tenpo_nm = paramCol["M1tenpo_nm"][i].UnformatValue;
				}
				if (paramCol["M1siiresaki_cd"][i].UnformatValue != null)
				{
					tf030f01M1Form.M1siiresaki_cd = paramCol["M1siiresaki_cd"][i].UnformatValue;
				}
				if (paramCol["M1siiresaki_ryaku_nm"][i].UnformatValue != null)
				{
					tf030f01M1Form.M1siiresaki_ryaku_nm = paramCol["M1siiresaki_ryaku_nm"][i].UnformatValue;
				}
				if (paramCol["M1motodenpyo_bango"][i].UnformatValue != null)
				{
					tf030f01M1Form.M1motodenpyo_bango = paramCol["M1motodenpyo_bango"][i].UnformatValue;
				}
				if (paramCol["M1nohin_ymd"][i].DateFullValue != null)
				{
					tf030f01M1Form.M1nohin_ymd = paramCol["M1nohin_ymd"][i].DateFullValue;
				}
				if (paramCol["M1nyuryokutan_nm"][i].UnformatValue != null)
				{
					tf030f01M1Form.M1nyuryokutan_nm = paramCol["M1nyuryokutan_nm"][i].UnformatValue;
				}
				if (paramCol["M1itemsu"][i].UnformatValue != null)
				{
					tf030f01M1Form.M1itemsu = paramCol["M1itemsu"][i].UnformatValue;
				}
				if (paramCol["M1kingaku"][i].UnformatValue != null)
				{
					tf030f01M1Form.M1kingaku = paramCol["M1kingaku"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					tf030f01M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					tf030f01M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					tf030f01M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Tf030f01Form formVO, StandardCheckManager checker)
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
			if (formVO.Add_ymd_from != null)
			{
				checker.DoCheck("Add_ymd_from", formVO.Add_ymd_from);
			}
			if (formVO.Add_ymd_to != null)
			{
				checker.DoCheck("Add_ymd_to", formVO.Add_ymd_to);
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
			if (formVO.Siiresaki_cd != null)
			{
				checker.DoCheck("Siiresaki_cd", formVO.Siiresaki_cd);
			}
			if (formVO.Siiresaki_ryaku_nm != null)
			{
				checker.DoCheck("Siiresaki_ryaku_nm", formVO.Siiresaki_ryaku_nm);
			}
			if (formVO.Denpyo_bango_from != null)
			{
				checker.DoCheck("Denpyo_bango_from", formVO.Denpyo_bango_from);
			}
			if (formVO.Denpyo_bango_to != null)
			{
				checker.DoCheck("Denpyo_bango_to", formVO.Denpyo_bango_to);
			}
			if (formVO.Motodenpyo_bango_from != null)
			{
				checker.DoCheck("Motodenpyo_bango_from", formVO.Motodenpyo_bango_from);
			}
			if (formVO.Motodenpyo_bango_to != null)
			{
				checker.DoCheck("Motodenpyo_bango_to", formVO.Motodenpyo_bango_to);
			}
			if (formVO.Searchcnt != null)
			{
				checker.DoCheck("Searchcnt", formVO.Searchcnt);
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
		public static void ValidateM1InputValue(Tf030f01Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Tf030f01M1Form tf030f01M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, tf030f01M1Form, i, m1List);
				if (tf030f01M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", tf030f01M1Form.M1rowno, i, m1List);
				}
				if (tf030f01M1Form.M1add_ymd != null)
				{
					checker.DoCheck("M1add_ymd", tf030f01M1Form.M1add_ymd, i, m1List);
				}
				if (tf030f01M1Form.M1tenpo_cd != null)
				{
					checker.DoCheck("M1tenpo_cd", tf030f01M1Form.M1tenpo_cd, i, m1List);
				}
				if (tf030f01M1Form.M1tenpo_nm != null)
				{
					checker.DoCheck("M1tenpo_nm", tf030f01M1Form.M1tenpo_nm, i, m1List);
				}
				if (tf030f01M1Form.M1siiresaki_cd != null)
				{
					checker.DoCheck("M1siiresaki_cd", tf030f01M1Form.M1siiresaki_cd, i, m1List);
				}
				if (tf030f01M1Form.M1siiresaki_ryaku_nm != null)
				{
					checker.DoCheck("M1siiresaki_ryaku_nm", tf030f01M1Form.M1siiresaki_ryaku_nm, i, m1List);
				}
				if (tf030f01M1Form.M1motodenpyo_bango != null)
				{
					checker.DoCheck("M1motodenpyo_bango", tf030f01M1Form.M1motodenpyo_bango, i, m1List);
				}
				if (tf030f01M1Form.M1nohin_ymd != null)
				{
					checker.DoCheck("M1nohin_ymd", tf030f01M1Form.M1nohin_ymd, i, m1List);
				}
				if (tf030f01M1Form.M1nyuryokutan_nm != null)
				{
					checker.DoCheck("M1nyuryokutan_nm", tf030f01M1Form.M1nyuryokutan_nm, i, m1List);
				}
				if (tf030f01M1Form.M1itemsu != null)
				{
					checker.DoCheck("M1itemsu", tf030f01M1Form.M1itemsu, i, m1List);
				}
				if (tf030f01M1Form.M1kingaku != null)
				{
					checker.DoCheck("M1kingaku", tf030f01M1Form.M1kingaku, i, m1List);
				}
				if (tf030f01M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", tf030f01M1Form.M1selectorcheckbox, i, m1List);
				}
				if (tf030f01M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", tf030f01M1Form.M1entersyoriflg, i, m1List);
				}
				if (tf030f01M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", tf030f01M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Tf030f01Form formVO, StandardCodeCheckManager checker)
		{
			checker.DoCheck("Btnheadtenpocd", formVO);
			checker.DoCheck("Btntenpocd_from", formVO);
			checker.DoCheck("Btntenpocd_to", formVO);
			checker.DoCheck("Btnsiiresaki_cd", formVO);
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Tf030f01Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

