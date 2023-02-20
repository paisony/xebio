using com.xebio.bo.Tl030p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Tl030p01.Request
{
  /// <summary>
  /// Tl030f01RequestHelper の概要の説明です。
  /// </summary>
  public static class Tl030f01RequestHelper
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
			Tl030f01Form formVO = (Tl030f01Form)pageContext.GetFormVO();

			//カード部を初期化する
			paramCol.InitCardItems(formInfo.GetCardItems());
			//明細「M1」部を初期化する
			paramCol.InitListItems(formInfo.GetListItems("M1"), formVO.GetList("M1").CurrentCount);
			//カード項目の入力値を取得する
			paramCol["Head_tenpo_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_nm"]);
			paramCol["Sinseimoto"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Sinseimoto"]);
			paramCol["Bumon_cd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_cd_from"]);
			paramCol["Bumon_nm_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_nm_from"]);
			paramCol["Bumon_cd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_cd_to"]);
			paramCol["Bumon_nm_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_nm_to"]);
			paramCol["Sinseitan_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Sinseitan_cd"]);
			paramCol["Sinseitan_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Sinseitan_nm"]);
			paramCol["Baihen_shiji_no_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Baihen_shiji_no_from"]);
			paramCol["Baihen_shiji_no_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Baihen_shiji_no_to"]);
			paramCol["Baihensagyokaisi_ymd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Baihensagyokaisi_ymd_from"]);
			paramCol["Baihensagyokaisi_ymd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Baihensagyokaisi_ymd_to"]);
			paramCol["Baihenkaisi_ymd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Baihenkaisi_ymd_from"]);
			paramCol["Baihenkaisi_ymd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Baihenkaisi_ymd_to"]);
			paramCol["Genbaika_shijibaika_flg"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Genbaika_shijibaika_flg"]);
			paramCol["Searchcnt"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Searchcnt"]);
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
				paramCol["M1shinseimoto_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1shinseimoto_nm"]);
				paramCol["M1sinseitan_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1sinseitan_nm"]);
				paramCol["M1baihen_shiji_no"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1baihen_shiji_no"]);
				paramCol["M1baihensagyokaisi_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1baihensagyokaisi_ymd"]);
				paramCol["M1baihenkaisi_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1baihenkaisi_ymd"]);
				paramCol["M1baihen_riyu_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1baihen_riyu_nm"]);
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
			Tl030f01Form formVO = (Tl030f01Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Sinseimoto"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Sinseimoto"].RequestValue, formInfo["Sinseimoto"]);
			paramCol["Bumon_cd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_cd_from"].RequestValue, formInfo["Bumon_cd_from"]);
			paramCol["Bumon_nm_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_nm_from"].RequestValue, formInfo["Bumon_nm_from"]);
			paramCol["Bumon_cd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_cd_to"].RequestValue, formInfo["Bumon_cd_to"]);
			paramCol["Bumon_nm_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_nm_to"].RequestValue, formInfo["Bumon_nm_to"]);
			paramCol["Sinseitan_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Sinseitan_cd"].RequestValue, formInfo["Sinseitan_cd"]);
			paramCol["Sinseitan_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Sinseitan_nm"].RequestValue, formInfo["Sinseitan_nm"]);
			paramCol["Baihen_shiji_no_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Baihen_shiji_no_from"].RequestValue, formInfo["Baihen_shiji_no_from"]);
			paramCol["Baihen_shiji_no_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Baihen_shiji_no_to"].RequestValue, formInfo["Baihen_shiji_no_to"]);
			paramCol["Baihensagyokaisi_ymd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Baihensagyokaisi_ymd_from"].RequestValue, formInfo["Baihensagyokaisi_ymd_from"]);
			paramCol["Baihensagyokaisi_ymd_from"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Baihensagyokaisi_ymd_from"].RequestValue, formInfo["Baihensagyokaisi_ymd_from"]);
			paramCol["Baihensagyokaisi_ymd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Baihensagyokaisi_ymd_to"].RequestValue, formInfo["Baihensagyokaisi_ymd_to"]);
			paramCol["Baihensagyokaisi_ymd_to"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Baihensagyokaisi_ymd_to"].RequestValue, formInfo["Baihensagyokaisi_ymd_to"]);
			paramCol["Baihenkaisi_ymd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Baihenkaisi_ymd_from"].RequestValue, formInfo["Baihenkaisi_ymd_from"]);
			paramCol["Baihenkaisi_ymd_from"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Baihenkaisi_ymd_from"].RequestValue, formInfo["Baihenkaisi_ymd_from"]);
			paramCol["Baihenkaisi_ymd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Baihenkaisi_ymd_to"].RequestValue, formInfo["Baihenkaisi_ymd_to"]);
			paramCol["Baihenkaisi_ymd_to"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Baihenkaisi_ymd_to"].RequestValue, formInfo["Baihenkaisi_ymd_to"]);
			paramCol["Genbaika_shijibaika_flg"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Genbaika_shijibaika_flg"].RequestValue, formInfo["Genbaika_shijibaika_flg"]);
			paramCol["Searchcnt"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Searchcnt"].RequestValue, formInfo["Searchcnt"]);
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
				paramCol["M1shinseimoto_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1shinseimoto_nm"][i].RequestValue, formInfo["M1shinseimoto_nm"]);
				paramCol["M1sinseitan_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1sinseitan_nm"][i].RequestValue, formInfo["M1sinseitan_nm"]);
				paramCol["M1baihen_shiji_no"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1baihen_shiji_no"][i].RequestValue, formInfo["M1baihen_shiji_no"]);
				paramCol["M1baihensagyokaisi_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1baihensagyokaisi_ymd"][i].RequestValue, formInfo["M1baihensagyokaisi_ymd"]);
				paramCol["M1baihensagyokaisi_ymd"][i].DateFullValue = RequestParameterUtil.GetDateFullValue(
					paramCol["M1baihensagyokaisi_ymd"][i].RequestValue, formInfo["M1baihensagyokaisi_ymd"]);
				paramCol["M1baihenkaisi_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1baihenkaisi_ymd"][i].RequestValue, formInfo["M1baihenkaisi_ymd"]);
				paramCol["M1baihenkaisi_ymd"][i].DateFullValue = RequestParameterUtil.GetDateFullValue(
					paramCol["M1baihenkaisi_ymd"][i].RequestValue, formInfo["M1baihenkaisi_ymd"]);
				paramCol["M1baihen_riyu_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1baihen_riyu_nm"][i].RequestValue, formInfo["M1baihen_riyu_nm"]);
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
			Tl030f01Form formVO = (Tl030f01Form)pageContext.GetFormVO();

			//カード項目の入力値をFormVOにコピーする
			if (paramCol["Head_tenpo_cd"].UnformatValue != null)
			{
				formVO.Head_tenpo_cd = paramCol["Head_tenpo_cd"].UnformatValue;
			}
			if (paramCol["Head_tenpo_nm"].UnformatValue != null)
			{
				formVO.Head_tenpo_nm = paramCol["Head_tenpo_nm"].UnformatValue;
			}
			if (paramCol["Sinseimoto"].UnformatValue != null)
			{
				formVO.Sinseimoto = paramCol["Sinseimoto"].UnformatValue;
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
			if (paramCol["Sinseitan_cd"].UnformatValue != null)
			{
				formVO.Sinseitan_cd = paramCol["Sinseitan_cd"].UnformatValue;
			}
			if (paramCol["Sinseitan_nm"].UnformatValue != null)
			{
				formVO.Sinseitan_nm = paramCol["Sinseitan_nm"].UnformatValue;
			}
			if (paramCol["Baihen_shiji_no_from"].UnformatValue != null)
			{
				formVO.Baihen_shiji_no_from = paramCol["Baihen_shiji_no_from"].UnformatValue;
			}
			if (paramCol["Baihen_shiji_no_to"].UnformatValue != null)
			{
				formVO.Baihen_shiji_no_to = paramCol["Baihen_shiji_no_to"].UnformatValue;
			}
			if (paramCol["Baihensagyokaisi_ymd_from"].DateFullValue != null)
			{
				formVO.Baihensagyokaisi_ymd_from = paramCol["Baihensagyokaisi_ymd_from"].DateFullValue;
			}
			if (paramCol["Baihensagyokaisi_ymd_to"].DateFullValue != null)
			{
				formVO.Baihensagyokaisi_ymd_to = paramCol["Baihensagyokaisi_ymd_to"].DateFullValue;
			}
			if (paramCol["Baihenkaisi_ymd_from"].DateFullValue != null)
			{
				formVO.Baihenkaisi_ymd_from = paramCol["Baihenkaisi_ymd_from"].DateFullValue;
			}
			if (paramCol["Baihenkaisi_ymd_to"].DateFullValue != null)
			{
				formVO.Baihenkaisi_ymd_to = paramCol["Baihenkaisi_ymd_to"].DateFullValue;
			}
			if (paramCol["Genbaika_shijibaika_flg"].UnformatValue != null)
			{
				formVO.Genbaika_shijibaika_flg = paramCol["Genbaika_shijibaika_flg"].UnformatValue;
			}
			if (paramCol["Searchcnt"].UnformatValue != null)
			{
				formVO.Searchcnt = paramCol["Searchcnt"].UnformatValue;
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
				Tl030f01M1Form tl030f01M1Form = (Tl030f01M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					tl030f01M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1shinseimoto_nm"][i].UnformatValue != null)
				{
					tl030f01M1Form.M1shinseimoto_nm = paramCol["M1shinseimoto_nm"][i].UnformatValue;
				}
				if (paramCol["M1sinseitan_nm"][i].UnformatValue != null)
				{
					tl030f01M1Form.M1sinseitan_nm = paramCol["M1sinseitan_nm"][i].UnformatValue;
				}
				if (paramCol["M1baihen_shiji_no"][i].UnformatValue != null)
				{
					tl030f01M1Form.M1baihen_shiji_no = paramCol["M1baihen_shiji_no"][i].UnformatValue;
				}
				if (paramCol["M1baihensagyokaisi_ymd"][i].DateFullValue != null)
				{
					tl030f01M1Form.M1baihensagyokaisi_ymd = paramCol["M1baihensagyokaisi_ymd"][i].DateFullValue;
				}
				if (paramCol["M1baihenkaisi_ymd"][i].DateFullValue != null)
				{
					tl030f01M1Form.M1baihenkaisi_ymd = paramCol["M1baihenkaisi_ymd"][i].DateFullValue;
				}
				if (paramCol["M1baihen_riyu_nm"][i].UnformatValue != null)
				{
					tl030f01M1Form.M1baihen_riyu_nm = paramCol["M1baihen_riyu_nm"][i].UnformatValue;
				}
				if (paramCol["M1hinban_su"][i].UnformatValue != null)
				{
					tl030f01M1Form.M1hinban_su = paramCol["M1hinban_su"][i].UnformatValue;
				}
				if (paramCol["M1zaiko_su"][i].UnformatValue != null)
				{
					tl030f01M1Form.M1zaiko_su = paramCol["M1zaiko_su"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					tl030f01M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					tl030f01M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					tl030f01M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Tl030f01Form formVO, StandardCheckManager checker)
		{
			if (formVO.Head_tenpo_cd != null)
			{
				checker.DoCheck("Head_tenpo_cd", formVO.Head_tenpo_cd);
			}
			if (formVO.Head_tenpo_nm != null)
			{
				checker.DoCheck("Head_tenpo_nm", formVO.Head_tenpo_nm);
			}
			if (formVO.Sinseimoto != null)
			{
				checker.DoCheck("Sinseimoto", formVO.Sinseimoto);
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
			if (formVO.Sinseitan_cd != null)
			{
				checker.DoCheck("Sinseitan_cd", formVO.Sinseitan_cd);
			}
			if (formVO.Sinseitan_nm != null)
			{
				checker.DoCheck("Sinseitan_nm", formVO.Sinseitan_nm);
			}
			if (formVO.Baihen_shiji_no_from != null)
			{
				checker.DoCheck("Baihen_shiji_no_from", formVO.Baihen_shiji_no_from);
			}
			if (formVO.Baihen_shiji_no_to != null)
			{
				checker.DoCheck("Baihen_shiji_no_to", formVO.Baihen_shiji_no_to);
			}
			if (formVO.Baihensagyokaisi_ymd_from != null)
			{
				checker.DoCheck("Baihensagyokaisi_ymd_from", formVO.Baihensagyokaisi_ymd_from);
			}
			if (formVO.Baihensagyokaisi_ymd_to != null)
			{
				checker.DoCheck("Baihensagyokaisi_ymd_to", formVO.Baihensagyokaisi_ymd_to);
			}
			if (formVO.Baihenkaisi_ymd_from != null)
			{
				checker.DoCheck("Baihenkaisi_ymd_from", formVO.Baihenkaisi_ymd_from);
			}
			if (formVO.Baihenkaisi_ymd_to != null)
			{
				checker.DoCheck("Baihenkaisi_ymd_to", formVO.Baihenkaisi_ymd_to);
			}
			if (formVO.Genbaika_shijibaika_flg != null)
			{
				checker.DoCheck("Genbaika_shijibaika_flg", formVO.Genbaika_shijibaika_flg);
			}
			if (formVO.Searchcnt != null)
			{
				checker.DoCheck("Searchcnt", formVO.Searchcnt);
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
		public static void ValidateM1InputValue(Tl030f01Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Tl030f01M1Form tl030f01M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, tl030f01M1Form, i, m1List);
				if (tl030f01M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", tl030f01M1Form.M1rowno, i, m1List);
				}
				if (tl030f01M1Form.M1shinseimoto_nm != null)
				{
					checker.DoCheck("M1shinseimoto_nm", tl030f01M1Form.M1shinseimoto_nm, i, m1List);
				}
				if (tl030f01M1Form.M1sinseitan_nm != null)
				{
					checker.DoCheck("M1sinseitan_nm", tl030f01M1Form.M1sinseitan_nm, i, m1List);
				}
				if (tl030f01M1Form.M1baihen_shiji_no != null)
				{
					checker.DoCheck("M1baihen_shiji_no", tl030f01M1Form.M1baihen_shiji_no, i, m1List);
				}
				if (tl030f01M1Form.M1baihensagyokaisi_ymd != null)
				{
					checker.DoCheck("M1baihensagyokaisi_ymd", tl030f01M1Form.M1baihensagyokaisi_ymd, i, m1List);
				}
				if (tl030f01M1Form.M1baihenkaisi_ymd != null)
				{
					checker.DoCheck("M1baihenkaisi_ymd", tl030f01M1Form.M1baihenkaisi_ymd, i, m1List);
				}
				if (tl030f01M1Form.M1baihen_riyu_nm != null)
				{
					checker.DoCheck("M1baihen_riyu_nm", tl030f01M1Form.M1baihen_riyu_nm, i, m1List);
				}
				if (tl030f01M1Form.M1hinban_su != null)
				{
					checker.DoCheck("M1hinban_su", tl030f01M1Form.M1hinban_su, i, m1List);
				}
				if (tl030f01M1Form.M1zaiko_su != null)
				{
					checker.DoCheck("M1zaiko_su", tl030f01M1Form.M1zaiko_su, i, m1List);
				}
				if (tl030f01M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", tl030f01M1Form.M1selectorcheckbox, i, m1List);
				}
				if (tl030f01M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", tl030f01M1Form.M1entersyoriflg, i, m1List);
				}
				if (tl030f01M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", tl030f01M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Tl030f01Form formVO, StandardCodeCheckManager checker)
		{
			checker.DoCheck("Btnheadtenpocd", formVO);
			checker.DoCheck("Btnbumon_cd_from", formVO);
			checker.DoCheck("Btnbumon_cd_to", formVO);
			checker.DoCheck("Btntanto_cd", formVO);
			checker.DoCheck("Btnlabel_cd", formVO);
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Tl030f01Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

