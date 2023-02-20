using com.xebio.bo.Tl010p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Tl010p01.Request
{
  /// <summary>
  /// Tl010f01RequestHelper の概要の説明です。
  /// </summary>
  public static class Tl010f01RequestHelper
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
			Tl010f01Form formVO = (Tl010f01Form)pageContext.GetFormVO();

			//カード部を初期化する
			paramCol.InitCardItems(formInfo.GetCardItems());
			//明細「M1」部を初期化する
			paramCol.InitListItems(formInfo.GetListItems("M1"), formVO.GetList("M1").CurrentCount);
			//カード項目の入力値を取得する
			paramCol["Head_tenpo_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_nm"]);
			paramCol["Kaishi_jyotai"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Kaishi_jyotai"]);
			paramCol["Bumon_cd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_cd_from"]);
			paramCol["Bumon_nm_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_nm_from"]);
			paramCol["Bumon_cd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_cd_to"]);
			paramCol["Bumon_nm_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_nm_to"]);
			paramCol["Baihenkaisi_ymd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Baihenkaisi_ymd_from"]);
			paramCol["Baihenkaisi_ymd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Baihenkaisi_ymd_to"]);
			paramCol["Old_jisya_hbn"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Old_jisya_hbn"]);
			paramCol["Maker_hbn"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Maker_hbn"]);
			paramCol["Searchcnt"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Searchcnt"]);
			paramCol["Eigyo_ymd_hdn"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Eigyo_ymd_hdn"]);
			paramCol["Eigyo_ymd_hdn2"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Eigyo_ymd_hdn2"]);
			paramCol["Shuturyoku_seal"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Shuturyoku_seal"]);
			paramCol["Label_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Label_cd"]);
			paramCol["Label_ip"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Label_ip"]);
			paramCol["Label_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Label_nm"]);
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
				paramCol["M1baihenkaisi_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1baihenkaisi_ymd"]);
				paramCol["M1hinban_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hinban_su"]);
				paramCol["M1zaiko_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1zaiko_su"]);
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
			Tl010f01Form formVO = (Tl010f01Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Kaishi_jyotai"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Kaishi_jyotai"].RequestValue, formInfo["Kaishi_jyotai"]);
			paramCol["Bumon_cd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_cd_from"].RequestValue, formInfo["Bumon_cd_from"]);
			paramCol["Bumon_nm_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_nm_from"].RequestValue, formInfo["Bumon_nm_from"]);
			paramCol["Bumon_cd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_cd_to"].RequestValue, formInfo["Bumon_cd_to"]);
			paramCol["Bumon_nm_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_nm_to"].RequestValue, formInfo["Bumon_nm_to"]);
			paramCol["Baihenkaisi_ymd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Baihenkaisi_ymd_from"].RequestValue, formInfo["Baihenkaisi_ymd_from"]);
			paramCol["Baihenkaisi_ymd_from"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Baihenkaisi_ymd_from"].RequestValue, formInfo["Baihenkaisi_ymd_from"]);
			paramCol["Baihenkaisi_ymd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Baihenkaisi_ymd_to"].RequestValue, formInfo["Baihenkaisi_ymd_to"]);
			paramCol["Baihenkaisi_ymd_to"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Baihenkaisi_ymd_to"].RequestValue, formInfo["Baihenkaisi_ymd_to"]);
			paramCol["Old_jisya_hbn"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Old_jisya_hbn"].RequestValue, formInfo["Old_jisya_hbn"]);
			paramCol["Maker_hbn"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Maker_hbn"].RequestValue, formInfo["Maker_hbn"]);
			paramCol["Searchcnt"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Searchcnt"].RequestValue, formInfo["Searchcnt"]);
			paramCol["Eigyo_ymd_hdn"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Eigyo_ymd_hdn"].RequestValue, formInfo["Eigyo_ymd_hdn"]);
			paramCol["Eigyo_ymd_hdn"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Eigyo_ymd_hdn"].RequestValue, formInfo["Eigyo_ymd_hdn"]);
			paramCol["Eigyo_ymd_hdn2"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Eigyo_ymd_hdn2"].RequestValue, formInfo["Eigyo_ymd_hdn2"]);
			paramCol["Eigyo_ymd_hdn2"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Eigyo_ymd_hdn2"].RequestValue, formInfo["Eigyo_ymd_hdn2"]);
			paramCol["Shuturyoku_seal"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Shuturyoku_seal"].RequestValue, formInfo["Shuturyoku_seal"]);
			paramCol["Label_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Label_cd"].RequestValue, formInfo["Label_cd"]);
			paramCol["Label_ip"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Label_ip"].RequestValue, formInfo["Label_ip"]);
			paramCol["Label_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Label_nm"].RequestValue, formInfo["Label_nm"]);
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
				paramCol["M1baihenkaisi_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1baihenkaisi_ymd"][i].RequestValue, formInfo["M1baihenkaisi_ymd"]);
				paramCol["M1baihenkaisi_ymd"][i].DateFullValue = RequestParameterUtil.GetDateFullValue(
					paramCol["M1baihenkaisi_ymd"][i].RequestValue, formInfo["M1baihenkaisi_ymd"]);
				paramCol["M1hinban_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hinban_su"][i].RequestValue, formInfo["M1hinban_su"]);
				paramCol["M1zaiko_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1zaiko_su"][i].RequestValue, formInfo["M1zaiko_su"]);
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
			Tl010f01Form formVO = (Tl010f01Form)pageContext.GetFormVO();

			//カード項目の入力値をFormVOにコピーする
			if (paramCol["Head_tenpo_cd"].UnformatValue != null)
			{
				formVO.Head_tenpo_cd = paramCol["Head_tenpo_cd"].UnformatValue;
			}
			if (paramCol["Head_tenpo_nm"].UnformatValue != null)
			{
				formVO.Head_tenpo_nm = paramCol["Head_tenpo_nm"].UnformatValue;
			}
			if (paramCol["Kaishi_jyotai"].UnformatValue != null)
			{
				formVO.Kaishi_jyotai = paramCol["Kaishi_jyotai"].UnformatValue;
			}
			if (paramCol["Bumon_cd_from"].UnformatValue != null)
			{
				formVO.Bumon_cd_from = paramCol["Bumon_cd_from"].UnformatValue;
			}
			if (paramCol["Bumon_nm_from"].UnformatValue != null)
			{
				formVO.Bumon_nm_from = paramCol["Bumon_nm_from"].UnformatValue;
			}
			if (paramCol["Bumon_cd_to"].UnformatValue != null)
			{
				formVO.Bumon_cd_to = paramCol["Bumon_cd_to"].UnformatValue;
			}
			if (paramCol["Bumon_nm_to"].UnformatValue != null)
			{
				formVO.Bumon_nm_to = paramCol["Bumon_nm_to"].UnformatValue;
			}
			if (paramCol["Baihenkaisi_ymd_from"].DateFullValue != null)
			{
				formVO.Baihenkaisi_ymd_from = paramCol["Baihenkaisi_ymd_from"].DateFullValue;
			}
			if (paramCol["Baihenkaisi_ymd_to"].DateFullValue != null)
			{
				formVO.Baihenkaisi_ymd_to = paramCol["Baihenkaisi_ymd_to"].DateFullValue;
			}
			if (paramCol["Old_jisya_hbn"].UnformatValue != null)
			{
				formVO.Old_jisya_hbn = paramCol["Old_jisya_hbn"].UnformatValue;
			}
			if (paramCol["Maker_hbn"].UnformatValue != null)
			{
				formVO.Maker_hbn = paramCol["Maker_hbn"].UnformatValue;
			}
			if (paramCol["Searchcnt"].UnformatValue != null)
			{
				formVO.Searchcnt = paramCol["Searchcnt"].UnformatValue;
			}
			if (paramCol["Eigyo_ymd_hdn"].DateFullValue != null)
			{
				formVO.Eigyo_ymd_hdn = paramCol["Eigyo_ymd_hdn"].DateFullValue;
			}
			if (paramCol["Eigyo_ymd_hdn2"].DateFullValue != null)
			{
				formVO.Eigyo_ymd_hdn2 = paramCol["Eigyo_ymd_hdn2"].DateFullValue;
			}
			if (paramCol["Shuturyoku_seal"].UnformatValue != null)
			{
				formVO.Shuturyoku_seal = paramCol["Shuturyoku_seal"].UnformatValue;
			}
			if (paramCol["Label_cd"].UnformatValue != null)
			{
				formVO.Label_cd = paramCol["Label_cd"].UnformatValue;
			}
			if (paramCol["Label_ip"].UnformatValue != null)
			{
				formVO.Label_ip = paramCol["Label_ip"].UnformatValue;
			}
			if (paramCol["Label_nm"].UnformatValue != null)
			{
				formVO.Label_nm = paramCol["Label_nm"].UnformatValue;
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
				Tl010f01M1Form tl010f01M1Form = (Tl010f01M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					tl010f01M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1baihenkaisi_ymd"][i].DateFullValue != null)
				{
					tl010f01M1Form.M1baihenkaisi_ymd = paramCol["M1baihenkaisi_ymd"][i].DateFullValue;
				}
				if (paramCol["M1hinban_su"][i].UnformatValue != null)
				{
					tl010f01M1Form.M1hinban_su = paramCol["M1hinban_su"][i].UnformatValue;
				}
				if (paramCol["M1zaiko_su"][i].UnformatValue != null)
				{
					tl010f01M1Form.M1zaiko_su = paramCol["M1zaiko_su"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					tl010f01M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					tl010f01M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					tl010f01M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Tl010f01Form formVO, StandardCheckManager checker)
		{
			if (formVO.Head_tenpo_cd != null)
			{
				checker.DoCheck("Head_tenpo_cd", formVO.Head_tenpo_cd);
			}
			if (formVO.Head_tenpo_nm != null)
			{
				checker.DoCheck("Head_tenpo_nm", formVO.Head_tenpo_nm);
			}
			if (formVO.Kaishi_jyotai != null)
			{
				checker.DoCheck("Kaishi_jyotai", formVO.Kaishi_jyotai);
			}
			if (formVO.Bumon_cd_from != null)
			{
				checker.DoCheck("Bumon_cd_from", formVO.Bumon_cd_from);
			}
			if (formVO.Bumon_nm_from != null)
			{
				checker.DoCheck("Bumon_nm_from", formVO.Bumon_nm_from);
			}
			if (formVO.Bumon_cd_to != null)
			{
				checker.DoCheck("Bumon_cd_to", formVO.Bumon_cd_to);
			}
			if (formVO.Bumon_nm_to != null)
			{
				checker.DoCheck("Bumon_nm_to", formVO.Bumon_nm_to);
			}
			if (formVO.Baihenkaisi_ymd_from != null)
			{
				checker.DoCheck("Baihenkaisi_ymd_from", formVO.Baihenkaisi_ymd_from);
			}
			if (formVO.Baihenkaisi_ymd_to != null)
			{
				checker.DoCheck("Baihenkaisi_ymd_to", formVO.Baihenkaisi_ymd_to);
			}
			if (formVO.Old_jisya_hbn != null)
			{
				checker.DoCheck("Old_jisya_hbn", formVO.Old_jisya_hbn);
			}
			if (formVO.Maker_hbn != null)
			{
				checker.DoCheck("Maker_hbn", formVO.Maker_hbn);
			}
			if (formVO.Searchcnt != null)
			{
				checker.DoCheck("Searchcnt", formVO.Searchcnt);
			}
			if (formVO.Eigyo_ymd_hdn != null)
			{
				checker.DoCheck("Eigyo_ymd_hdn", formVO.Eigyo_ymd_hdn);
			}
			if (formVO.Eigyo_ymd_hdn2 != null)
			{
				checker.DoCheck("Eigyo_ymd_hdn2", formVO.Eigyo_ymd_hdn2);
			}
			if (formVO.Shuturyoku_seal != null)
			{
				checker.DoCheck("Shuturyoku_seal", formVO.Shuturyoku_seal);
			}
			if (formVO.Label_cd != null)
			{
				checker.DoCheck("Label_cd", formVO.Label_cd);
			}
			if (formVO.Label_ip != null)
			{
				checker.DoCheck("Label_ip", formVO.Label_ip);
			}
			if (formVO.Label_nm != null)
			{
				checker.DoCheck("Label_nm", formVO.Label_nm);
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
		public static void ValidateM1InputValue(Tl010f01Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Tl010f01M1Form tl010f01M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, tl010f01M1Form, i, m1List);
				if (tl010f01M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", tl010f01M1Form.M1rowno, i, m1List);
				}
				if (tl010f01M1Form.M1baihenkaisi_ymd != null)
				{
					checker.DoCheck("M1baihenkaisi_ymd", tl010f01M1Form.M1baihenkaisi_ymd, i, m1List);
				}
				if (tl010f01M1Form.M1hinban_su != null)
				{
					checker.DoCheck("M1hinban_su", tl010f01M1Form.M1hinban_su, i, m1List);
				}
				if (tl010f01M1Form.M1zaiko_su != null)
				{
					checker.DoCheck("M1zaiko_su", tl010f01M1Form.M1zaiko_su, i, m1List);
				}
				if (tl010f01M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", tl010f01M1Form.M1selectorcheckbox, i, m1List);
				}
				if (tl010f01M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", tl010f01M1Form.M1entersyoriflg, i, m1List);
				}
				if (tl010f01M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", tl010f01M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Tl010f01Form formVO, StandardCodeCheckManager checker)
		{
			checker.DoCheck("Btnheadtenpocd", formVO);
			checker.DoCheck("Btnbumon_cd_from", formVO);
			checker.DoCheck("Btnbumon_cd_to", formVO);
			checker.DoCheck("Btnlabel_cd", formVO);
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Tl010f01Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

