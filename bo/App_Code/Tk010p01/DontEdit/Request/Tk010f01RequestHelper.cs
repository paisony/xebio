using com.xebio.bo.Tk010p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Tk010p01.Request
{
  /// <summary>
  /// Tk010f01RequestHelper の概要の説明です。
  /// </summary>
  public static class Tk010f01RequestHelper
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
			Tk010f01Form formVO = (Tk010f01Form)pageContext.GetFormVO();

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
			paramCol["Hyokasonsyubetsu_kb"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hyokasonsyubetsu_kb"]);
			paramCol["Syonin_flg"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Syonin_flg"]);
			paramCol["Kessai_flg"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Kessai_flg"]);
			paramCol["Sinsei_kb"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Sinsei_kb"]);
			paramCol["Tenpo_cd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tenpo_cd_from"]);
			paramCol["Tenpo_nm_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tenpo_nm_from"]);
			paramCol["Tenpo_cd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tenpo_cd_to"]);
			paramCol["Tenpo_nm_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tenpo_nm_to"]);
			paramCol["Syori_ym"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Syori_ym"]);
			paramCol["Searchcnt"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Searchcnt"]);
			paramCol["Gokei_suryo"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokei_suryo"]);
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
				paramCol["M1apply_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1apply_ymd"]);
				paramCol["M1sinsei_kb_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1sinsei_kb_nm"]);
				paramCol["M1syonin_flg_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1syonin_flg_nm"]);
				paramCol["M1kessai_flg_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1kessai_flg_nm"]);
				paramCol["M1notnb_suryo"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1notnb_suryo"]);
				paramCol["M1notnb_genka_kin"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1notnb_genka_kin"]);
				paramCol["M1nb_suryo"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1nb_suryo"]);
				paramCol["M1nb_genka_kin"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1nb_genka_kin"]);
				paramCol["M1tenpogokei_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tenpogokei_su"]);
				paramCol["M1tenpogokei_genka_kin"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tenpogokei_genka_kin"]);
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
			Tk010f01Form formVO = (Tk010f01Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Modeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Modeno"].RequestValue, formInfo["Modeno"]);
			paramCol["Stkmodeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Stkmodeno"].RequestValue, formInfo["Stkmodeno"]);
			paramCol["Hyokasonsyubetsu_kb"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hyokasonsyubetsu_kb"].RequestValue, formInfo["Hyokasonsyubetsu_kb"]);
			paramCol["Syonin_flg"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Syonin_flg"].RequestValue, formInfo["Syonin_flg"]);
			paramCol["Kessai_flg"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Kessai_flg"].RequestValue, formInfo["Kessai_flg"]);
			paramCol["Sinsei_kb"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Sinsei_kb"].RequestValue, formInfo["Sinsei_kb"]);
			paramCol["Tenpo_cd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tenpo_cd_from"].RequestValue, formInfo["Tenpo_cd_from"]);
			paramCol["Tenpo_nm_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tenpo_nm_from"].RequestValue, formInfo["Tenpo_nm_from"]);
			paramCol["Tenpo_cd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tenpo_cd_to"].RequestValue, formInfo["Tenpo_cd_to"]);
			paramCol["Tenpo_nm_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tenpo_nm_to"].RequestValue, formInfo["Tenpo_nm_to"]);
			paramCol["Syori_ym"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Syori_ym"].RequestValue, formInfo["Syori_ym"]);
			paramCol["Searchcnt"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Searchcnt"].RequestValue, formInfo["Searchcnt"]);
			paramCol["Gokei_suryo"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokei_suryo"].RequestValue, formInfo["Gokei_suryo"]);
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
				paramCol["M1apply_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1apply_ymd"][i].RequestValue, formInfo["M1apply_ymd"]);
				paramCol["M1apply_ymd"][i].DateFullValue = RequestParameterUtil.GetDateFullValue(
					paramCol["M1apply_ymd"][i].RequestValue, formInfo["M1apply_ymd"]);
				paramCol["M1sinsei_kb_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1sinsei_kb_nm"][i].RequestValue, formInfo["M1sinsei_kb_nm"]);
				paramCol["M1syonin_flg_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1syonin_flg_nm"][i].RequestValue, formInfo["M1syonin_flg_nm"]);
				paramCol["M1kessai_flg_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1kessai_flg_nm"][i].RequestValue, formInfo["M1kessai_flg_nm"]);
				paramCol["M1notnb_suryo"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1notnb_suryo"][i].RequestValue, formInfo["M1notnb_suryo"]);
				paramCol["M1notnb_genka_kin"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1notnb_genka_kin"][i].RequestValue, formInfo["M1notnb_genka_kin"]);
				paramCol["M1nb_suryo"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1nb_suryo"][i].RequestValue, formInfo["M1nb_suryo"]);
				paramCol["M1nb_genka_kin"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1nb_genka_kin"][i].RequestValue, formInfo["M1nb_genka_kin"]);
				paramCol["M1tenpogokei_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tenpogokei_su"][i].RequestValue, formInfo["M1tenpogokei_su"]);
				paramCol["M1tenpogokei_genka_kin"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tenpogokei_genka_kin"][i].RequestValue, formInfo["M1tenpogokei_genka_kin"]);
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
			Tk010f01Form formVO = (Tk010f01Form)pageContext.GetFormVO();

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
			if (paramCol["Hyokasonsyubetsu_kb"].UnformatValue != null)
			{
				formVO.Hyokasonsyubetsu_kb = paramCol["Hyokasonsyubetsu_kb"].UnformatValue;
			}
			if (paramCol["Syonin_flg"].UnformatValue != null)
			{
				formVO.Syonin_flg = paramCol["Syonin_flg"].UnformatValue;
			}
			if (paramCol["Kessai_flg"].UnformatValue != null)
			{
				formVO.Kessai_flg = paramCol["Kessai_flg"].UnformatValue;
			}
			if (paramCol["Sinsei_kb"].UnformatValue != null)
			{
				formVO.Sinsei_kb = paramCol["Sinsei_kb"].UnformatValue;
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
			if (paramCol["Syori_ym"].UnformatValue != null)
			{
				formVO.Syori_ym = paramCol["Syori_ym"].UnformatValue;
			}
			if (paramCol["Searchcnt"].UnformatValue != null)
			{
				formVO.Searchcnt = paramCol["Searchcnt"].UnformatValue;
			}
			if (paramCol["Gokei_suryo"].UnformatValue != null)
			{
				formVO.Gokei_suryo = paramCol["Gokei_suryo"].UnformatValue;
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
				Tk010f01M1Form tk010f01M1Form = (Tk010f01M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					tk010f01M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1apply_ymd"][i].DateFullValue != null)
				{
					tk010f01M1Form.M1apply_ymd = paramCol["M1apply_ymd"][i].DateFullValue;
				}
				if (paramCol["M1sinsei_kb_nm"][i].UnformatValue != null)
				{
					tk010f01M1Form.M1sinsei_kb_nm = paramCol["M1sinsei_kb_nm"][i].UnformatValue;
				}
				if (paramCol["M1syonin_flg_nm"][i].UnformatValue != null)
				{
					tk010f01M1Form.M1syonin_flg_nm = paramCol["M1syonin_flg_nm"][i].UnformatValue;
				}
				if (paramCol["M1kessai_flg_nm"][i].UnformatValue != null)
				{
					tk010f01M1Form.M1kessai_flg_nm = paramCol["M1kessai_flg_nm"][i].UnformatValue;
				}
				if (paramCol["M1notnb_suryo"][i].UnformatValue != null)
				{
					tk010f01M1Form.M1notnb_suryo = paramCol["M1notnb_suryo"][i].UnformatValue;
				}
				if (paramCol["M1notnb_genka_kin"][i].UnformatValue != null)
				{
					tk010f01M1Form.M1notnb_genka_kin = paramCol["M1notnb_genka_kin"][i].UnformatValue;
				}
				if (paramCol["M1nb_suryo"][i].UnformatValue != null)
				{
					tk010f01M1Form.M1nb_suryo = paramCol["M1nb_suryo"][i].UnformatValue;
				}
				if (paramCol["M1nb_genka_kin"][i].UnformatValue != null)
				{
					tk010f01M1Form.M1nb_genka_kin = paramCol["M1nb_genka_kin"][i].UnformatValue;
				}
				if (paramCol["M1tenpogokei_su"][i].UnformatValue != null)
				{
					tk010f01M1Form.M1tenpogokei_su = paramCol["M1tenpogokei_su"][i].UnformatValue;
				}
				if (paramCol["M1tenpogokei_genka_kin"][i].UnformatValue != null)
				{
					tk010f01M1Form.M1tenpogokei_genka_kin = paramCol["M1tenpogokei_genka_kin"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					tk010f01M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					tk010f01M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					tk010f01M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Tk010f01Form formVO, StandardCheckManager checker)
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
			if (formVO.Hyokasonsyubetsu_kb != null)
			{
				checker.DoCheck("Hyokasonsyubetsu_kb", formVO.Hyokasonsyubetsu_kb);
			}
			if (formVO.Syonin_flg != null)
			{
				checker.DoCheck("Syonin_flg", formVO.Syonin_flg);
			}
			if (formVO.Kessai_flg != null)
			{
				checker.DoCheck("Kessai_flg", formVO.Kessai_flg);
			}
			if (formVO.Sinsei_kb != null)
			{
				checker.DoCheck("Sinsei_kb", formVO.Sinsei_kb);
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
			if (formVO.Syori_ym != null)
			{
				checker.DoCheck("Syori_ym", formVO.Syori_ym);
			}
			if (formVO.Searchcnt != null)
			{
				checker.DoCheck("Searchcnt", formVO.Searchcnt);
			}
			if (formVO.Gokei_suryo != null)
			{
				checker.DoCheck("Gokei_suryo", formVO.Gokei_suryo);
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
		public static void ValidateM1InputValue(Tk010f01Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Tk010f01M1Form tk010f01M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, tk010f01M1Form, i, m1List);
				if (tk010f01M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", tk010f01M1Form.M1rowno, i, m1List);
				}
				if (tk010f01M1Form.M1apply_ymd != null)
				{
					checker.DoCheck("M1apply_ymd", tk010f01M1Form.M1apply_ymd, i, m1List);
				}
				if (tk010f01M1Form.M1sinsei_kb_nm != null)
				{
					checker.DoCheck("M1sinsei_kb_nm", tk010f01M1Form.M1sinsei_kb_nm, i, m1List);
				}
				if (tk010f01M1Form.M1syonin_flg_nm != null)
				{
					checker.DoCheck("M1syonin_flg_nm", tk010f01M1Form.M1syonin_flg_nm, i, m1List);
				}
				if (tk010f01M1Form.M1kessai_flg_nm != null)
				{
					checker.DoCheck("M1kessai_flg_nm", tk010f01M1Form.M1kessai_flg_nm, i, m1List);
				}
				if (tk010f01M1Form.M1notnb_suryo != null)
				{
					checker.DoCheck("M1notnb_suryo", tk010f01M1Form.M1notnb_suryo, i, m1List);
				}
				if (tk010f01M1Form.M1notnb_genka_kin != null)
				{
					checker.DoCheck("M1notnb_genka_kin", tk010f01M1Form.M1notnb_genka_kin, i, m1List);
				}
				if (tk010f01M1Form.M1nb_suryo != null)
				{
					checker.DoCheck("M1nb_suryo", tk010f01M1Form.M1nb_suryo, i, m1List);
				}
				if (tk010f01M1Form.M1nb_genka_kin != null)
				{
					checker.DoCheck("M1nb_genka_kin", tk010f01M1Form.M1nb_genka_kin, i, m1List);
				}
				if (tk010f01M1Form.M1tenpogokei_su != null)
				{
					checker.DoCheck("M1tenpogokei_su", tk010f01M1Form.M1tenpogokei_su, i, m1List);
				}
				if (tk010f01M1Form.M1tenpogokei_genka_kin != null)
				{
					checker.DoCheck("M1tenpogokei_genka_kin", tk010f01M1Form.M1tenpogokei_genka_kin, i, m1List);
				}
				if (tk010f01M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", tk010f01M1Form.M1selectorcheckbox, i, m1List);
				}
				if (tk010f01M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", tk010f01M1Form.M1entersyoriflg, i, m1List);
				}
				if (tk010f01M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", tk010f01M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Tk010f01Form formVO, StandardCodeCheckManager checker)
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
		public static void ValidateM1CodeValue(Tk010f01Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

