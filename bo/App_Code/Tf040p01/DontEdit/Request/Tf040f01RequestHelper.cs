using com.xebio.bo.Tf040p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Tf040p01.Request
{
  /// <summary>
  /// Tf040f01RequestHelper の概要の説明です。
  /// </summary>
  public static class Tf040f01RequestHelper
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
			Tf040f01Form formVO = (Tf040f01Form)pageContext.GetFormVO();

			//カード部を初期化する
			paramCol.InitCardItems(formInfo.GetCardItems());
			//明細「M1」部を初期化する
			paramCol.InitListItems(formInfo.GetListItems("M1"), formVO.GetList("M1").CurrentCount);
			//カード項目の入力値を取得する
			paramCol["Head_tenpo_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_nm"]);
			paramCol["Zenjitu_zandaka"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Zenjitu_zandaka"]);
			paramCol["Zengetu_zandaka"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Zengetu_zandaka"]);
			paramCol["Gokei_zandaka"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokei_zandaka"]);
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
				paramCol["M1kanri_no"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1kanri_no"]);
				paramCol["M1motokanri_no"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1motokanri_no"]);
				paramCol["M1keijo_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1keijo_ymd"]);
				paramCol["M1kamoku_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1kamoku_cd"]);
				paramCol["M1kamoku_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1kamoku_nm"]);
				paramCol["M1nyukin"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1nyukin"]);
				paramCol["M1nyukin_hdn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1nyukin_hdn"]);
				paramCol["M1syukkin"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1syukkin"]);
				paramCol["M1syukkin_hdn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1syukkin_hdn"]);
				paramCol["M1tekiyou"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tekiyou"]);
				paramCol["M1hurikaetenpo_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hurikaetenpo_cd"]);
				paramCol["M1hurikaetenpo_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hurikaetenpo_nm"]);
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
			Tf040f01Form formVO = (Tf040f01Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Zenjitu_zandaka"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Zenjitu_zandaka"].RequestValue, formInfo["Zenjitu_zandaka"]);
			paramCol["Zengetu_zandaka"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Zengetu_zandaka"].RequestValue, formInfo["Zengetu_zandaka"]);
			paramCol["Gokei_zandaka"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokei_zandaka"].RequestValue, formInfo["Gokei_zandaka"]);
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
				paramCol["M1kanri_no"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1kanri_no"][i].RequestValue, formInfo["M1kanri_no"]);
				paramCol["M1motokanri_no"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1motokanri_no"][i].RequestValue, formInfo["M1motokanri_no"]);
				paramCol["M1keijo_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1keijo_ymd"][i].RequestValue, formInfo["M1keijo_ymd"]);
				paramCol["M1keijo_ymd"][i].DateFullValue = RequestParameterUtil.GetDateFullValue(
					paramCol["M1keijo_ymd"][i].RequestValue, formInfo["M1keijo_ymd"]);
				paramCol["M1kamoku_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1kamoku_cd"][i].RequestValue, formInfo["M1kamoku_cd"]);
				paramCol["M1kamoku_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1kamoku_nm"][i].RequestValue, formInfo["M1kamoku_nm"]);
				paramCol["M1nyukin"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1nyukin"][i].RequestValue, formInfo["M1nyukin"]);
				paramCol["M1nyukin_hdn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1nyukin_hdn"][i].RequestValue, formInfo["M1nyukin_hdn"]);
				paramCol["M1syukkin"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1syukkin"][i].RequestValue, formInfo["M1syukkin"]);
				paramCol["M1syukkin_hdn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1syukkin_hdn"][i].RequestValue, formInfo["M1syukkin_hdn"]);
				paramCol["M1tekiyou"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tekiyou"][i].RequestValue, formInfo["M1tekiyou"]);
				paramCol["M1hurikaetenpo_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hurikaetenpo_cd"][i].RequestValue, formInfo["M1hurikaetenpo_cd"]);
				paramCol["M1hurikaetenpo_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hurikaetenpo_nm"][i].RequestValue, formInfo["M1hurikaetenpo_nm"]);
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
			Tf040f01Form formVO = (Tf040f01Form)pageContext.GetFormVO();

			//カード項目の入力値をFormVOにコピーする
			if (paramCol["Head_tenpo_cd"].UnformatValue != null)
			{
				formVO.Head_tenpo_cd = paramCol["Head_tenpo_cd"].UnformatValue;
			}
			if (paramCol["Head_tenpo_nm"].UnformatValue != null)
			{
				formVO.Head_tenpo_nm = paramCol["Head_tenpo_nm"].UnformatValue;
			}
			if (paramCol["Zenjitu_zandaka"].UnformatValue != null)
			{
				formVO.Zenjitu_zandaka = paramCol["Zenjitu_zandaka"].UnformatValue;
			}
			if (paramCol["Zengetu_zandaka"].UnformatValue != null)
			{
				formVO.Zengetu_zandaka = paramCol["Zengetu_zandaka"].UnformatValue;
			}
			if (paramCol["Gokei_zandaka"].UnformatValue != null)
			{
				formVO.Gokei_zandaka = paramCol["Gokei_zandaka"].UnformatValue;
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
				Tf040f01M1Form tf040f01M1Form = (Tf040f01M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					tf040f01M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1kanri_no"][i].UnformatValue != null)
				{
					tf040f01M1Form.M1kanri_no = paramCol["M1kanri_no"][i].UnformatValue;
				}
				if (paramCol["M1motokanri_no"][i].UnformatValue != null)
				{
					tf040f01M1Form.M1motokanri_no = paramCol["M1motokanri_no"][i].UnformatValue;
				}
				if (paramCol["M1keijo_ymd"][i].DateFullValue != null)
				{
					tf040f01M1Form.M1keijo_ymd = paramCol["M1keijo_ymd"][i].DateFullValue;
				}
				if (paramCol["M1kamoku_cd"][i].UnformatValue != null)
				{
					tf040f01M1Form.M1kamoku_cd = paramCol["M1kamoku_cd"][i].UnformatValue;
				}
				if (paramCol["M1kamoku_nm"][i].UnformatValue != null)
				{
					tf040f01M1Form.M1kamoku_nm = paramCol["M1kamoku_nm"][i].UnformatValue;
				}
				if (paramCol["M1nyukin"][i].UnformatValue != null)
				{
					tf040f01M1Form.M1nyukin = paramCol["M1nyukin"][i].UnformatValue;
				}
				if (paramCol["M1nyukin_hdn"][i].UnformatValue != null)
				{
					tf040f01M1Form.M1nyukin_hdn = paramCol["M1nyukin_hdn"][i].UnformatValue;
				}
				if (paramCol["M1syukkin"][i].UnformatValue != null)
				{
					tf040f01M1Form.M1syukkin = paramCol["M1syukkin"][i].UnformatValue;
				}
				if (paramCol["M1syukkin_hdn"][i].UnformatValue != null)
				{
					tf040f01M1Form.M1syukkin_hdn = paramCol["M1syukkin_hdn"][i].UnformatValue;
				}
				if (paramCol["M1tekiyou"][i].UnformatValue != null)
				{
					tf040f01M1Form.M1tekiyou = paramCol["M1tekiyou"][i].UnformatValue;
				}
				if (paramCol["M1hurikaetenpo_cd"][i].UnformatValue != null)
				{
					tf040f01M1Form.M1hurikaetenpo_cd = paramCol["M1hurikaetenpo_cd"][i].UnformatValue;
				}
				if (paramCol["M1hurikaetenpo_nm"][i].UnformatValue != null)
				{
					tf040f01M1Form.M1hurikaetenpo_nm = paramCol["M1hurikaetenpo_nm"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					tf040f01M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					tf040f01M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					tf040f01M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Tf040f01Form formVO, StandardCheckManager checker)
		{
			if (formVO.Head_tenpo_cd != null)
			{
				checker.DoCheck("Head_tenpo_cd", formVO.Head_tenpo_cd);
			}
			if (formVO.Head_tenpo_nm != null)
			{
				checker.DoCheck("Head_tenpo_nm", formVO.Head_tenpo_nm);
			}
			if (formVO.Zenjitu_zandaka != null)
			{
				checker.DoCheck("Zenjitu_zandaka", formVO.Zenjitu_zandaka);
			}
			if (formVO.Zengetu_zandaka != null)
			{
				checker.DoCheck("Zengetu_zandaka", formVO.Zengetu_zandaka);
			}
			if (formVO.Gokei_zandaka != null)
			{
				checker.DoCheck("Gokei_zandaka", formVO.Gokei_zandaka);
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
		public static void ValidateM1InputValue(Tf040f01Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Tf040f01M1Form tf040f01M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, tf040f01M1Form, i, m1List);
				if (tf040f01M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", tf040f01M1Form.M1rowno, i, m1List);
				}
				if (tf040f01M1Form.M1kanri_no != null)
				{
					checker.DoCheck("M1kanri_no", tf040f01M1Form.M1kanri_no, i, m1List);
				}
				if (tf040f01M1Form.M1motokanri_no != null)
				{
					checker.DoCheck("M1motokanri_no", tf040f01M1Form.M1motokanri_no, i, m1List);
				}
				if (tf040f01M1Form.M1keijo_ymd != null)
				{
					checker.DoCheck("M1keijo_ymd", tf040f01M1Form.M1keijo_ymd, i, m1List);
				}
				if (tf040f01M1Form.M1kamoku_cd != null)
				{
					checker.DoCheck("M1kamoku_cd", tf040f01M1Form.M1kamoku_cd, i, m1List);
				}
				if (tf040f01M1Form.M1kamoku_nm != null)
				{
					checker.DoCheck("M1kamoku_nm", tf040f01M1Form.M1kamoku_nm, i, m1List);
				}
				if (tf040f01M1Form.M1nyukin != null)
				{
					checker.DoCheck("M1nyukin", tf040f01M1Form.M1nyukin, i, m1List);
				}
				if (tf040f01M1Form.M1nyukin_hdn != null)
				{
					checker.DoCheck("M1nyukin_hdn", tf040f01M1Form.M1nyukin_hdn, i, m1List);
				}
				if (tf040f01M1Form.M1syukkin != null)
				{
					checker.DoCheck("M1syukkin", tf040f01M1Form.M1syukkin, i, m1List);
				}
				if (tf040f01M1Form.M1syukkin_hdn != null)
				{
					checker.DoCheck("M1syukkin_hdn", tf040f01M1Form.M1syukkin_hdn, i, m1List);
				}
				if (tf040f01M1Form.M1tekiyou != null)
				{
					checker.DoCheck("M1tekiyou", tf040f01M1Form.M1tekiyou, i, m1List);
				}
				if (tf040f01M1Form.M1hurikaetenpo_cd != null)
				{
					checker.DoCheck("M1hurikaetenpo_cd", tf040f01M1Form.M1hurikaetenpo_cd, i, m1List);
				}
				if (tf040f01M1Form.M1hurikaetenpo_nm != null)
				{
					checker.DoCheck("M1hurikaetenpo_nm", tf040f01M1Form.M1hurikaetenpo_nm, i, m1List);
				}
				if (tf040f01M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", tf040f01M1Form.M1selectorcheckbox, i, m1List);
				}
				if (tf040f01M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", tf040f01M1Form.M1entersyoriflg, i, m1List);
				}
				if (tf040f01M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", tf040f01M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Tf040f01Form formVO, StandardCodeCheckManager checker)
		{
			checker.DoCheck("Btnheadtenpocd", formVO);
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Tf040f01Form formVO, StandardCodeCheckManager checker)
		{
			checker.DoCheck("M1btnkamokucd", formVO);
			checker.DoCheck("M1btntenpocd", formVO);
		}
	}
}

