using com.xebio.bo.Th020p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Th020p01.Request
{
  /// <summary>
  /// Th020f04RequestHelper の概要の説明です。
  /// </summary>
  public static class Th020f04RequestHelper
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
			Th020f04Form formVO = (Th020f04Form)pageContext.GetFormVO();

			//カード部を初期化する
			paramCol.InitCardItems(formInfo.GetCardItems());
			//明細「M1」部を初期化する
			paramCol.InitListItems(formInfo.GetListItems("M1"), formVO.GetList("M1").CurrentCount);
			//カード項目の入力値を取得する
			paramCol["Head_tenpo_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_nm"]);
			paramCol["Kaisya_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Kaisya_cd"]);
			paramCol["Kaisya_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Kaisya_nm"]);
			paramCol["Bumon_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_cd"]);
			paramCol["Bumon_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_nm"]);
			paramCol["Hinsyu_ryaku_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hinsyu_ryaku_nm"]);
			paramCol["Hinsyu_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hinsyu_cd"]);
			paramCol["Burando_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Burando_cd"]);
			paramCol["Burando_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Burando_nm"]);
			paramCol["Jisya_hbn"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Jisya_hbn"]);
			paramCol["Maker_hbn"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Maker_hbn"]);
			paramCol["Syohin_zokusei"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Syohin_zokusei"]);
			paramCol["Syonmk"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Syonmk"]);
			paramCol["Iro_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Iro_nm"]);
			paramCol["Size_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Size_nm"]);
			paramCol["Scan_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Scan_cd"]);
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
				paramCol["M1tenpo_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tenpo_cd"]);
				paramCol["M1tenpo_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tenpo_nm"]);
				paramCol["M1uriage_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1uriage_su"]);
				paramCol["M1freezaiko_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1freezaiko_su"]);
				paramCol["M1syoka_rtu"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1syoka_rtu"]);
				paramCol["M1tyobozaiko_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tyobozaiko_su"]);
				paramCol["M1azukariyoyaku_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1azukariyoyaku_su"]);
				paramCol["M1sekiso_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1sekiso_su"]);
				paramCol["M1tonan_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tonan_su"]);
				paramCol["M1hyokasonsinsei_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hyokasonsinsei_su"]);
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
			Th020f04Form formVO = (Th020f04Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Kaisya_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Kaisya_cd"].RequestValue, formInfo["Kaisya_cd"]);
			paramCol["Kaisya_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Kaisya_nm"].RequestValue, formInfo["Kaisya_nm"]);
			paramCol["Bumon_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_cd"].RequestValue, formInfo["Bumon_cd"]);
			paramCol["Bumon_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_nm"].RequestValue, formInfo["Bumon_nm"]);
			paramCol["Hinsyu_ryaku_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hinsyu_ryaku_nm"].RequestValue, formInfo["Hinsyu_ryaku_nm"]);
			paramCol["Hinsyu_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hinsyu_cd"].RequestValue, formInfo["Hinsyu_cd"]);
			paramCol["Burando_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Burando_cd"].RequestValue, formInfo["Burando_cd"]);
			paramCol["Burando_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Burando_nm"].RequestValue, formInfo["Burando_nm"]);
			paramCol["Jisya_hbn"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Jisya_hbn"].RequestValue, formInfo["Jisya_hbn"]);
			paramCol["Maker_hbn"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Maker_hbn"].RequestValue, formInfo["Maker_hbn"]);
			paramCol["Syohin_zokusei"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Syohin_zokusei"].RequestValue, formInfo["Syohin_zokusei"]);
			paramCol["Syonmk"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Syonmk"].RequestValue, formInfo["Syonmk"]);
			paramCol["Iro_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Iro_nm"].RequestValue, formInfo["Iro_nm"]);
			paramCol["Size_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Size_nm"].RequestValue, formInfo["Size_nm"]);
			paramCol["Scan_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Scan_cd"].RequestValue, formInfo["Scan_cd"]);
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
				paramCol["M1tenpo_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tenpo_cd"][i].RequestValue, formInfo["M1tenpo_cd"]);
				paramCol["M1tenpo_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tenpo_nm"][i].RequestValue, formInfo["M1tenpo_nm"]);
				paramCol["M1uriage_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1uriage_su"][i].RequestValue, formInfo["M1uriage_su"]);
				paramCol["M1freezaiko_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1freezaiko_su"][i].RequestValue, formInfo["M1freezaiko_su"]);
				paramCol["M1syoka_rtu"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1syoka_rtu"][i].RequestValue, formInfo["M1syoka_rtu"]);
				paramCol["M1tyobozaiko_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tyobozaiko_su"][i].RequestValue, formInfo["M1tyobozaiko_su"]);
				paramCol["M1azukariyoyaku_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1azukariyoyaku_su"][i].RequestValue, formInfo["M1azukariyoyaku_su"]);
				paramCol["M1sekiso_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1sekiso_su"][i].RequestValue, formInfo["M1sekiso_su"]);
				paramCol["M1tonan_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tonan_su"][i].RequestValue, formInfo["M1tonan_su"]);
				paramCol["M1hyokasonsinsei_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hyokasonsinsei_su"][i].RequestValue, formInfo["M1hyokasonsinsei_su"]);
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
			Th020f04Form formVO = (Th020f04Form)pageContext.GetFormVO();

			//カード項目の入力値をFormVOにコピーする
			if (paramCol["Head_tenpo_cd"].UnformatValue != null)
			{
				formVO.Head_tenpo_cd = paramCol["Head_tenpo_cd"].UnformatValue;
			}
			if (paramCol["Head_tenpo_nm"].UnformatValue != null)
			{
				formVO.Head_tenpo_nm = paramCol["Head_tenpo_nm"].UnformatValue;
			}
			if (paramCol["Kaisya_cd"].UnformatValue != null)
			{
				formVO.Kaisya_cd = paramCol["Kaisya_cd"].UnformatValue;
			}
			if (paramCol["Kaisya_nm"].UnformatValue != null)
			{
				formVO.Kaisya_nm = paramCol["Kaisya_nm"].UnformatValue;
			}
			if (paramCol["Bumon_cd"].UnformatValue != null)
			{
				formVO.Bumon_cd = paramCol["Bumon_cd"].UnformatValue;
			}
			if (paramCol["Bumon_nm"].UnformatValue != null)
			{
				formVO.Bumon_nm = paramCol["Bumon_nm"].UnformatValue;
			}
			if (paramCol["Hinsyu_ryaku_nm"].UnformatValue != null)
			{
				formVO.Hinsyu_ryaku_nm = paramCol["Hinsyu_ryaku_nm"].UnformatValue;
			}
			if (paramCol["Hinsyu_cd"].UnformatValue != null)
			{
				formVO.Hinsyu_cd = paramCol["Hinsyu_cd"].UnformatValue;
			}
			if (paramCol["Burando_cd"].UnformatValue != null)
			{
				formVO.Burando_cd = paramCol["Burando_cd"].UnformatValue;
			}
			if (paramCol["Burando_nm"].UnformatValue != null)
			{
				formVO.Burando_nm = paramCol["Burando_nm"].UnformatValue;
			}
			if (paramCol["Jisya_hbn"].UnformatValue != null)
			{
				formVO.Jisya_hbn = paramCol["Jisya_hbn"].UnformatValue;
			}
			if (paramCol["Maker_hbn"].UnformatValue != null)
			{
				formVO.Maker_hbn = paramCol["Maker_hbn"].UnformatValue;
			}
			if (paramCol["Syohin_zokusei"].UnformatValue != null)
			{
				formVO.Syohin_zokusei = paramCol["Syohin_zokusei"].UnformatValue;
			}
			if (paramCol["Syonmk"].UnformatValue != null)
			{
				formVO.Syonmk = paramCol["Syonmk"].UnformatValue;
			}
			if (paramCol["Iro_nm"].UnformatValue != null)
			{
				formVO.Iro_nm = paramCol["Iro_nm"].UnformatValue;
			}
			if (paramCol["Size_nm"].UnformatValue != null)
			{
				formVO.Size_nm = paramCol["Size_nm"].UnformatValue;
			}
			if (paramCol["Scan_cd"].UnformatValue != null)
			{
				formVO.Scan_cd = paramCol["Scan_cd"].UnformatValue;
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
				Th020f04M1Form th020f04M1Form = (Th020f04M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					th020f04M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1tenpo_cd"][i].UnformatValue != null)
				{
					th020f04M1Form.M1tenpo_cd = paramCol["M1tenpo_cd"][i].UnformatValue;
				}
				if (paramCol["M1tenpo_nm"][i].UnformatValue != null)
				{
					th020f04M1Form.M1tenpo_nm = paramCol["M1tenpo_nm"][i].UnformatValue;
				}
				if (paramCol["M1uriage_su"][i].UnformatValue != null)
				{
					th020f04M1Form.M1uriage_su = paramCol["M1uriage_su"][i].UnformatValue;
				}
				if (paramCol["M1freezaiko_su"][i].UnformatValue != null)
				{
					th020f04M1Form.M1freezaiko_su = paramCol["M1freezaiko_su"][i].UnformatValue;
				}
				if (paramCol["M1syoka_rtu"][i].UnformatValue != null)
				{
					th020f04M1Form.M1syoka_rtu = paramCol["M1syoka_rtu"][i].UnformatValue;
				}
				if (paramCol["M1tyobozaiko_su"][i].UnformatValue != null)
				{
					th020f04M1Form.M1tyobozaiko_su = paramCol["M1tyobozaiko_su"][i].UnformatValue;
				}
				if (paramCol["M1azukariyoyaku_su"][i].UnformatValue != null)
				{
					th020f04M1Form.M1azukariyoyaku_su = paramCol["M1azukariyoyaku_su"][i].UnformatValue;
				}
				if (paramCol["M1sekiso_su"][i].UnformatValue != null)
				{
					th020f04M1Form.M1sekiso_su = paramCol["M1sekiso_su"][i].UnformatValue;
				}
				if (paramCol["M1tonan_su"][i].UnformatValue != null)
				{
					th020f04M1Form.M1tonan_su = paramCol["M1tonan_su"][i].UnformatValue;
				}
				if (paramCol["M1hyokasonsinsei_su"][i].UnformatValue != null)
				{
					th020f04M1Form.M1hyokasonsinsei_su = paramCol["M1hyokasonsinsei_su"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					th020f04M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					th020f04M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					th020f04M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Th020f04Form formVO, StandardCheckManager checker)
		{
			if (formVO.Head_tenpo_cd != null)
			{
				checker.DoCheck("Head_tenpo_cd", formVO.Head_tenpo_cd);
			}
			if (formVO.Head_tenpo_nm != null)
			{
				checker.DoCheck("Head_tenpo_nm", formVO.Head_tenpo_nm);
			}
			if (formVO.Kaisya_cd != null)
			{
				checker.DoCheck("Kaisya_cd", formVO.Kaisya_cd);
			}
			if (formVO.Kaisya_nm != null)
			{
				checker.DoCheck("Kaisya_nm", formVO.Kaisya_nm);
			}
			if (formVO.Bumon_cd != null)
			{
				checker.DoCheck("Bumon_cd", formVO.Bumon_cd);
			}
			if (formVO.Bumon_nm != null)
			{
				checker.DoCheck("Bumon_nm", formVO.Bumon_nm);
			}
			if (formVO.Hinsyu_ryaku_nm != null)
			{
				checker.DoCheck("Hinsyu_ryaku_nm", formVO.Hinsyu_ryaku_nm);
			}
			if (formVO.Hinsyu_cd != null)
			{
				checker.DoCheck("Hinsyu_cd", formVO.Hinsyu_cd);
			}
			if (formVO.Burando_cd != null)
			{
				checker.DoCheck("Burando_cd", formVO.Burando_cd);
			}
			if (formVO.Burando_nm != null)
			{
				checker.DoCheck("Burando_nm", formVO.Burando_nm);
			}
			if (formVO.Jisya_hbn != null)
			{
				checker.DoCheck("Jisya_hbn", formVO.Jisya_hbn);
			}
			if (formVO.Maker_hbn != null)
			{
				checker.DoCheck("Maker_hbn", formVO.Maker_hbn);
			}
			if (formVO.Syohin_zokusei != null)
			{
				checker.DoCheck("Syohin_zokusei", formVO.Syohin_zokusei);
			}
			if (formVO.Syonmk != null)
			{
				checker.DoCheck("Syonmk", formVO.Syonmk);
			}
			if (formVO.Iro_nm != null)
			{
				checker.DoCheck("Iro_nm", formVO.Iro_nm);
			}
			if (formVO.Size_nm != null)
			{
				checker.DoCheck("Size_nm", formVO.Size_nm);
			}
			if (formVO.Scan_cd != null)
			{
				checker.DoCheck("Scan_cd", formVO.Scan_cd);
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
		public static void ValidateM1InputValue(Th020f04Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Th020f04M1Form th020f04M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, th020f04M1Form, i, m1List);
				if (th020f04M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", th020f04M1Form.M1rowno, i, m1List);
				}
				if (th020f04M1Form.M1tenpo_cd != null)
				{
					checker.DoCheck("M1tenpo_cd", th020f04M1Form.M1tenpo_cd, i, m1List);
				}
				if (th020f04M1Form.M1tenpo_nm != null)
				{
					checker.DoCheck("M1tenpo_nm", th020f04M1Form.M1tenpo_nm, i, m1List);
				}
				if (th020f04M1Form.M1uriage_su != null)
				{
					checker.DoCheck("M1uriage_su", th020f04M1Form.M1uriage_su, i, m1List);
				}
				if (th020f04M1Form.M1freezaiko_su != null)
				{
					checker.DoCheck("M1freezaiko_su", th020f04M1Form.M1freezaiko_su, i, m1List);
				}
				if (th020f04M1Form.M1syoka_rtu != null)
				{
					checker.DoCheck("M1syoka_rtu", th020f04M1Form.M1syoka_rtu, i, m1List);
				}
				if (th020f04M1Form.M1tyobozaiko_su != null)
				{
					checker.DoCheck("M1tyobozaiko_su", th020f04M1Form.M1tyobozaiko_su, i, m1List);
				}
				if (th020f04M1Form.M1azukariyoyaku_su != null)
				{
					checker.DoCheck("M1azukariyoyaku_su", th020f04M1Form.M1azukariyoyaku_su, i, m1List);
				}
				if (th020f04M1Form.M1sekiso_su != null)
				{
					checker.DoCheck("M1sekiso_su", th020f04M1Form.M1sekiso_su, i, m1List);
				}
				if (th020f04M1Form.M1tonan_su != null)
				{
					checker.DoCheck("M1tonan_su", th020f04M1Form.M1tonan_su, i, m1List);
				}
				if (th020f04M1Form.M1hyokasonsinsei_su != null)
				{
					checker.DoCheck("M1hyokasonsinsei_su", th020f04M1Form.M1hyokasonsinsei_su, i, m1List);
				}
				if (th020f04M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", th020f04M1Form.M1selectorcheckbox, i, m1List);
				}
				if (th020f04M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", th020f04M1Form.M1entersyoriflg, i, m1List);
				}
				if (th020f04M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", th020f04M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Th020f04Form formVO, StandardCodeCheckManager checker)
		{
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Th020f04Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

