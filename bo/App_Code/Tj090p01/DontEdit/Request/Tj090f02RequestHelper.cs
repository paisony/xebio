using com.xebio.bo.Tj090p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Tj090p01.Request
{
  /// <summary>
  /// Tj090f02RequestHelper の概要の説明です。
  /// </summary>
  public static class Tj090f02RequestHelper
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
			Tj090f02Form formVO = (Tj090f02Form)pageContext.GetFormVO();

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
			paramCol["Face_no"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Face_no"]);
			paramCol["Tana_dan"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tana_dan"]);
			paramCol["Kai_su"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Kai_su"]);
			paramCol["Tensutanaorosi_su"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tensutanaorosi_su"]);
			paramCol["Nyuryokutan_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Nyuryokutan_cd"]);
			paramCol["Nyuryokutan_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Nyuryokutan_nm"]);
			paramCol["Nyuryoku_ymd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Nyuryoku_ymd"]);
			paramCol["Riyucomment_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Riyucomment_nm"]);
			paramCol["Gokeiscan_su"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokeiscan_su"]);
			paramCol["Gokeiteisei_suryo"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokeiteisei_suryo"]);
			paramCol["All_gokei_suryo"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["All_gokei_suryo"]);
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
				paramCol["M1bumon_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1bumon_cd"]);
				paramCol["M1bumonkana_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1bumonkana_nm"]);
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
				paramCol["M1hyoji_syohin_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hyoji_syohin_cd"]);
				paramCol["M1scan_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1scan_su"]);
				paramCol["M1teisei_suryo"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1teisei_suryo"]);
				paramCol["M1teisei_suryo_hdn"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1teisei_suryo_hdn"]);
				paramCol["M1gokei_suryo"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1gokei_suryo"]);
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
			Tj090f02Form formVO = (Tj090f02Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Modeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Modeno"].RequestValue, formInfo["Modeno"]);
			paramCol["Stkmodeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Stkmodeno"].RequestValue, formInfo["Stkmodeno"]);
			paramCol["Face_no"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Face_no"].RequestValue, formInfo["Face_no"]);
			paramCol["Tana_dan"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tana_dan"].RequestValue, formInfo["Tana_dan"]);
			paramCol["Kai_su"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Kai_su"].RequestValue, formInfo["Kai_su"]);
			paramCol["Tensutanaorosi_su"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tensutanaorosi_su"].RequestValue, formInfo["Tensutanaorosi_su"]);
			paramCol["Nyuryokutan_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Nyuryokutan_cd"].RequestValue, formInfo["Nyuryokutan_cd"]);
			paramCol["Nyuryokutan_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Nyuryokutan_nm"].RequestValue, formInfo["Nyuryokutan_nm"]);
			paramCol["Nyuryoku_ymd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Nyuryoku_ymd"].RequestValue, formInfo["Nyuryoku_ymd"]);
			paramCol["Nyuryoku_ymd"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Nyuryoku_ymd"].RequestValue, formInfo["Nyuryoku_ymd"]);
			paramCol["Riyucomment_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Riyucomment_nm"].RequestValue, formInfo["Riyucomment_nm"]);
			paramCol["Gokeiscan_su"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokeiscan_su"].RequestValue, formInfo["Gokeiscan_su"]);
			paramCol["Gokeiteisei_suryo"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokeiteisei_suryo"].RequestValue, formInfo["Gokeiteisei_suryo"]);
			paramCol["All_gokei_suryo"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["All_gokei_suryo"].RequestValue, formInfo["All_gokei_suryo"]);
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
				paramCol["M1bumon_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1bumon_cd"][i].RequestValue, formInfo["M1bumon_cd"]);
				paramCol["M1bumonkana_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1bumonkana_nm"][i].RequestValue, formInfo["M1bumonkana_nm"]);
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
				paramCol["M1hyoji_syohin_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hyoji_syohin_cd"][i].RequestValue, formInfo["M1hyoji_syohin_cd"]);
				paramCol["M1scan_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1scan_su"][i].RequestValue, formInfo["M1scan_su"]);
				paramCol["M1teisei_suryo"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1teisei_suryo"][i].RequestValue, formInfo["M1teisei_suryo"]);
				paramCol["M1teisei_suryo_hdn"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1teisei_suryo_hdn"][i].RequestValue, formInfo["M1teisei_suryo_hdn"]);
				paramCol["M1gokei_suryo"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1gokei_suryo"][i].RequestValue, formInfo["M1gokei_suryo"]);
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
			Tj090f02Form formVO = (Tj090f02Form)pageContext.GetFormVO();

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
			if (paramCol["Face_no"].UnformatValue != null)
			{
				formVO.Face_no = paramCol["Face_no"].UnformatValue;
			}
			if (paramCol["Tana_dan"].UnformatValue != null)
			{
				formVO.Tana_dan = paramCol["Tana_dan"].UnformatValue;
			}
			if (paramCol["Kai_su"].UnformatValue != null)
			{
				formVO.Kai_su = paramCol["Kai_su"].UnformatValue;
			}
			if (paramCol["Tensutanaorosi_su"].UnformatValue != null)
			{
				formVO.Tensutanaorosi_su = paramCol["Tensutanaorosi_su"].UnformatValue;
			}
			if (paramCol["Nyuryokutan_cd"].UnformatValue != null)
			{
				formVO.Nyuryokutan_cd = paramCol["Nyuryokutan_cd"].UnformatValue;
			}
			if (paramCol["Nyuryokutan_nm"].UnformatValue != null)
			{
				formVO.Nyuryokutan_nm = paramCol["Nyuryokutan_nm"].UnformatValue;
			}
			if (paramCol["Nyuryoku_ymd"].DateFullValue != null)
			{
				formVO.Nyuryoku_ymd = paramCol["Nyuryoku_ymd"].DateFullValue;
			}
			if (paramCol["Riyucomment_nm"].UnformatValue != null)
			{
				formVO.Riyucomment_nm = paramCol["Riyucomment_nm"].UnformatValue;
			}
			if (paramCol["Gokeiscan_su"].UnformatValue != null)
			{
				formVO.Gokeiscan_su = paramCol["Gokeiscan_su"].UnformatValue;
			}
			if (paramCol["Gokeiteisei_suryo"].UnformatValue != null)
			{
				formVO.Gokeiteisei_suryo = paramCol["Gokeiteisei_suryo"].UnformatValue;
			}
			if (paramCol["All_gokei_suryo"].UnformatValue != null)
			{
				formVO.All_gokei_suryo = paramCol["All_gokei_suryo"].UnformatValue;
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
				Tj090f02M1Form tj090f02M1Form = (Tj090f02M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					tj090f02M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1bumon_cd"][i].UnformatValue != null)
				{
					tj090f02M1Form.M1bumon_cd = paramCol["M1bumon_cd"][i].UnformatValue;
				}
				if (paramCol["M1bumonkana_nm"][i].UnformatValue != null)
				{
					tj090f02M1Form.M1bumonkana_nm = paramCol["M1bumonkana_nm"][i].UnformatValue;
				}
				if (paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue != null)
				{
					tj090f02M1Form.M1hinsyu_ryaku_nm = paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue;
				}
				if (paramCol["M1burando_nm"][i].UnformatValue != null)
				{
					tj090f02M1Form.M1burando_nm = paramCol["M1burando_nm"][i].UnformatValue;
				}
				if (paramCol["M1jisya_hbn"][i].UnformatValue != null)
				{
					tj090f02M1Form.M1jisya_hbn = paramCol["M1jisya_hbn"][i].UnformatValue;
				}
				if (paramCol["M1maker_hbn"][i].UnformatValue != null)
				{
					tj090f02M1Form.M1maker_hbn = paramCol["M1maker_hbn"][i].UnformatValue;
				}
				if (paramCol["M1syonmk"][i].UnformatValue != null)
				{
					tj090f02M1Form.M1syonmk = paramCol["M1syonmk"][i].UnformatValue;
				}
				if (paramCol["M1iro_nm"][i].UnformatValue != null)
				{
					tj090f02M1Form.M1iro_nm = paramCol["M1iro_nm"][i].UnformatValue;
				}
				if (paramCol["M1size_nm"][i].UnformatValue != null)
				{
					tj090f02M1Form.M1size_nm = paramCol["M1size_nm"][i].UnformatValue;
				}
				if (paramCol["M1scan_cd"][i].UnformatValue != null)
				{
					tj090f02M1Form.M1scan_cd = paramCol["M1scan_cd"][i].UnformatValue;
				}
				if (paramCol["M1hyoji_syohin_cd"][i].UnformatValue != null)
				{
					tj090f02M1Form.M1hyoji_syohin_cd = paramCol["M1hyoji_syohin_cd"][i].UnformatValue;
				}
				if (paramCol["M1scan_su"][i].UnformatValue != null)
				{
					tj090f02M1Form.M1scan_su = paramCol["M1scan_su"][i].UnformatValue;
				}
				if (paramCol["M1teisei_suryo"][i].UnformatValue != null)
				{
					tj090f02M1Form.M1teisei_suryo = paramCol["M1teisei_suryo"][i].UnformatValue;
				}
				if (paramCol["M1teisei_suryo_hdn"][i].UnformatValue != null)
				{
					tj090f02M1Form.M1teisei_suryo_hdn = paramCol["M1teisei_suryo_hdn"][i].UnformatValue;
				}
				if (paramCol["M1gokei_suryo"][i].UnformatValue != null)
				{
					tj090f02M1Form.M1gokei_suryo = paramCol["M1gokei_suryo"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					tj090f02M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					tj090f02M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					tj090f02M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Tj090f02Form formVO, StandardCheckManager checker)
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
			if (formVO.Face_no != null)
			{
				checker.DoCheck("Face_no", formVO.Face_no);
			}
			if (formVO.Tana_dan != null)
			{
				checker.DoCheck("Tana_dan", formVO.Tana_dan);
			}
			if (formVO.Kai_su != null)
			{
				checker.DoCheck("Kai_su", formVO.Kai_su);
			}
			if (formVO.Tensutanaorosi_su != null)
			{
				checker.DoCheck("Tensutanaorosi_su", formVO.Tensutanaorosi_su);
			}
			if (formVO.Nyuryokutan_cd != null)
			{
				checker.DoCheck("Nyuryokutan_cd", formVO.Nyuryokutan_cd);
			}
			if (formVO.Nyuryokutan_nm != null)
			{
				checker.DoCheck("Nyuryokutan_nm", formVO.Nyuryokutan_nm);
			}
			if (formVO.Nyuryoku_ymd != null)
			{
				checker.DoCheck("Nyuryoku_ymd", formVO.Nyuryoku_ymd);
			}
			if (formVO.Riyucomment_nm != null)
			{
				checker.DoCheck("Riyucomment_nm", formVO.Riyucomment_nm);
			}
			if (formVO.Gokeiscan_su != null)
			{
				checker.DoCheck("Gokeiscan_su", formVO.Gokeiscan_su);
			}
			if (formVO.Gokeiteisei_suryo != null)
			{
				checker.DoCheck("Gokeiteisei_suryo", formVO.Gokeiteisei_suryo);
			}
			if (formVO.All_gokei_suryo != null)
			{
				checker.DoCheck("All_gokei_suryo", formVO.All_gokei_suryo);
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
		public static void ValidateM1InputValue(Tj090f02Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Tj090f02M1Form tj090f02M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, tj090f02M1Form, i, m1List);
				if (tj090f02M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", tj090f02M1Form.M1rowno, i, m1List);
				}
				if (tj090f02M1Form.M1bumon_cd != null)
				{
					checker.DoCheck("M1bumon_cd", tj090f02M1Form.M1bumon_cd, i, m1List);
				}
				if (tj090f02M1Form.M1bumonkana_nm != null)
				{
					checker.DoCheck("M1bumonkana_nm", tj090f02M1Form.M1bumonkana_nm, i, m1List);
				}
				if (tj090f02M1Form.M1hinsyu_ryaku_nm != null)
				{
					checker.DoCheck("M1hinsyu_ryaku_nm", tj090f02M1Form.M1hinsyu_ryaku_nm, i, m1List);
				}
				if (tj090f02M1Form.M1burando_nm != null)
				{
					checker.DoCheck("M1burando_nm", tj090f02M1Form.M1burando_nm, i, m1List);
				}
				if (tj090f02M1Form.M1jisya_hbn != null)
				{
					checker.DoCheck("M1jisya_hbn", tj090f02M1Form.M1jisya_hbn, i, m1List);
				}
				if (tj090f02M1Form.M1maker_hbn != null)
				{
					checker.DoCheck("M1maker_hbn", tj090f02M1Form.M1maker_hbn, i, m1List);
				}
				if (tj090f02M1Form.M1syonmk != null)
				{
					checker.DoCheck("M1syonmk", tj090f02M1Form.M1syonmk, i, m1List);
				}
				if (tj090f02M1Form.M1iro_nm != null)
				{
					checker.DoCheck("M1iro_nm", tj090f02M1Form.M1iro_nm, i, m1List);
				}
				if (tj090f02M1Form.M1size_nm != null)
				{
					checker.DoCheck("M1size_nm", tj090f02M1Form.M1size_nm, i, m1List);
				}
				if (tj090f02M1Form.M1scan_cd != null)
				{
					checker.DoCheck("M1scan_cd", tj090f02M1Form.M1scan_cd, i, m1List);
				}
				if (tj090f02M1Form.M1hyoji_syohin_cd != null)
				{
					checker.DoCheck("M1hyoji_syohin_cd", tj090f02M1Form.M1hyoji_syohin_cd, i, m1List);
				}
				if (tj090f02M1Form.M1scan_su != null)
				{
					checker.DoCheck("M1scan_su", tj090f02M1Form.M1scan_su, i, m1List);
				}
				if (tj090f02M1Form.M1teisei_suryo != null)
				{
					checker.DoCheck("M1teisei_suryo", tj090f02M1Form.M1teisei_suryo, i, m1List);
				}
				if (tj090f02M1Form.M1teisei_suryo_hdn != null)
				{
					checker.DoCheck("M1teisei_suryo_hdn", tj090f02M1Form.M1teisei_suryo_hdn, i, m1List);
				}
				if (tj090f02M1Form.M1gokei_suryo != null)
				{
					checker.DoCheck("M1gokei_suryo", tj090f02M1Form.M1gokei_suryo, i, m1List);
				}
				if (tj090f02M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", tj090f02M1Form.M1selectorcheckbox, i, m1List);
				}
				if (tj090f02M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", tj090f02M1Form.M1entersyoriflg, i, m1List);
				}
				if (tj090f02M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", tj090f02M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Tj090f02Form formVO, StandardCodeCheckManager checker)
		{
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Tj090f02Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

