﻿using com.xebio.bo.Tl010p01.Formvo;
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
  /// Tl010f02RequestHelper の概要の説明です。
  /// </summary>
  public static class Tl010f02RequestHelper
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
			Tl010f02Form formVO = (Tl010f02Form)pageContext.GetFormVO();

			//カード部を初期化する
			paramCol.InitCardItems(formInfo.GetCardItems());
			//明細「M1」部を初期化する
			paramCol.InitListItems(formInfo.GetListItems("M1"), formVO.GetList("M1").CurrentCount);
			//カード項目の入力値を取得する
			paramCol["Head_tenpo_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_nm"]);
			paramCol["Bumon_cd_bo"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_cd_bo"]);
			paramCol["Bumon_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_nm"]);
			paramCol["Baihenkaisi_ymd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Baihenkaisi_ymd"]);
			paramCol["Kaishi_jyotai_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Kaishi_jyotai_nm"]);
			paramCol["Comment_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Comment_nm"]);
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
				paramCol["M1gen_tnk"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1gen_tnk"]);
				paramCol["M1genbaika_tnm1k"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1genbaika_tnm1k"]);
				paramCol["M1mtobaika_tnk"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1mtobaika_tnk"]);
				paramCol["M1shinbaika_tnk"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1shinbaika_tnk"]);
				paramCol["M1neire_rtu_genko"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1neire_rtu_genko"]);
				paramCol["M1neire_rtu_baihengo"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1neire_rtu_baihengo"]);
				paramCol["M1zaiko_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1zaiko_su"]);
				paramCol["M1uriage_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1uriage_su"]);
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
			Tl010f02Form formVO = (Tl010f02Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Bumon_cd_bo"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_cd_bo"].RequestValue, formInfo["Bumon_cd_bo"]);
			paramCol["Bumon_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_nm"].RequestValue, formInfo["Bumon_nm"]);
			paramCol["Baihenkaisi_ymd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Baihenkaisi_ymd"].RequestValue, formInfo["Baihenkaisi_ymd"]);
			paramCol["Baihenkaisi_ymd"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Baihenkaisi_ymd"].RequestValue, formInfo["Baihenkaisi_ymd"]);
			paramCol["Kaishi_jyotai_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Kaishi_jyotai_nm"].RequestValue, formInfo["Kaishi_jyotai_nm"]);
			paramCol["Comment_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Comment_nm"].RequestValue, formInfo["Comment_nm"]);
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
				paramCol["M1gen_tnk"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1gen_tnk"][i].RequestValue, formInfo["M1gen_tnk"]);
				paramCol["M1genbaika_tnm1k"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1genbaika_tnm1k"][i].RequestValue, formInfo["M1genbaika_tnm1k"]);
				paramCol["M1mtobaika_tnk"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1mtobaika_tnk"][i].RequestValue, formInfo["M1mtobaika_tnk"]);
				paramCol["M1shinbaika_tnk"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1shinbaika_tnk"][i].RequestValue, formInfo["M1shinbaika_tnk"]);
				paramCol["M1neire_rtu_genko"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1neire_rtu_genko"][i].RequestValue, formInfo["M1neire_rtu_genko"]);
				paramCol["M1neire_rtu_baihengo"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1neire_rtu_baihengo"][i].RequestValue, formInfo["M1neire_rtu_baihengo"]);
				paramCol["M1zaiko_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1zaiko_su"][i].RequestValue, formInfo["M1zaiko_su"]);
				paramCol["M1uriage_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1uriage_su"][i].RequestValue, formInfo["M1uriage_su"]);
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
			Tl010f02Form formVO = (Tl010f02Form)pageContext.GetFormVO();

			//カード項目の入力値をFormVOにコピーする
			if (paramCol["Head_tenpo_cd"].UnformatValue != null)
			{
				formVO.Head_tenpo_cd = paramCol["Head_tenpo_cd"].UnformatValue;
			}
			if (paramCol["Head_tenpo_nm"].UnformatValue != null)
			{
				formVO.Head_tenpo_nm = paramCol["Head_tenpo_nm"].UnformatValue;
			}
			if (paramCol["Bumon_cd_bo"].UnformatValue != null)
			{
				formVO.Bumon_cd_bo = paramCol["Bumon_cd_bo"].UnformatValue;
			}
			if (paramCol["Bumon_nm"].UnformatValue != null)
			{
				formVO.Bumon_nm = paramCol["Bumon_nm"].UnformatValue;
			}
			if (paramCol["Baihenkaisi_ymd"].DateFullValue != null)
			{
				formVO.Baihenkaisi_ymd = paramCol["Baihenkaisi_ymd"].DateFullValue;
			}
			if (paramCol["Kaishi_jyotai_nm"].UnformatValue != null)
			{
				formVO.Kaishi_jyotai_nm = paramCol["Kaishi_jyotai_nm"].UnformatValue;
			}
			if (paramCol["Comment_nm"].UnformatValue != null)
			{
				formVO.Comment_nm = paramCol["Comment_nm"].UnformatValue;
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
				Tl010f02M1Form tl010f02M1Form = (Tl010f02M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					tl010f02M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1burando_nm"][i].UnformatValue != null)
				{
					tl010f02M1Form.M1burando_nm = paramCol["M1burando_nm"][i].UnformatValue;
				}
				if (paramCol["M1jisya_hbn"][i].UnformatValue != null)
				{
					tl010f02M1Form.M1jisya_hbn = paramCol["M1jisya_hbn"][i].UnformatValue;
				}
				if (paramCol["M1maker_hbn"][i].UnformatValue != null)
				{
					tl010f02M1Form.M1maker_hbn = paramCol["M1maker_hbn"][i].UnformatValue;
				}
				if (paramCol["M1syonmk"][i].UnformatValue != null)
				{
					tl010f02M1Form.M1syonmk = paramCol["M1syonmk"][i].UnformatValue;
				}
				if (paramCol["M1iro_nm"][i].UnformatValue != null)
				{
					tl010f02M1Form.M1iro_nm = paramCol["M1iro_nm"][i].UnformatValue;
				}
				if (paramCol["M1gen_tnk"][i].UnformatValue != null)
				{
					tl010f02M1Form.M1gen_tnk = paramCol["M1gen_tnk"][i].UnformatValue;
				}
				if (paramCol["M1genbaika_tnm1k"][i].UnformatValue != null)
				{
					tl010f02M1Form.M1genbaika_tnm1k = paramCol["M1genbaika_tnm1k"][i].UnformatValue;
				}
				if (paramCol["M1mtobaika_tnk"][i].UnformatValue != null)
				{
					tl010f02M1Form.M1mtobaika_tnk = paramCol["M1mtobaika_tnk"][i].UnformatValue;
				}
				if (paramCol["M1shinbaika_tnk"][i].UnformatValue != null)
				{
					tl010f02M1Form.M1shinbaika_tnk = paramCol["M1shinbaika_tnk"][i].UnformatValue;
				}
				if (paramCol["M1neire_rtu_genko"][i].UnformatValue != null)
				{
					tl010f02M1Form.M1neire_rtu_genko = paramCol["M1neire_rtu_genko"][i].UnformatValue;
				}
				if (paramCol["M1neire_rtu_baihengo"][i].UnformatValue != null)
				{
					tl010f02M1Form.M1neire_rtu_baihengo = paramCol["M1neire_rtu_baihengo"][i].UnformatValue;
				}
				if (paramCol["M1zaiko_su"][i].UnformatValue != null)
				{
					tl010f02M1Form.M1zaiko_su = paramCol["M1zaiko_su"][i].UnformatValue;
				}
				if (paramCol["M1uriage_su"][i].UnformatValue != null)
				{
					tl010f02M1Form.M1uriage_su = paramCol["M1uriage_su"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					tl010f02M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					tl010f02M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					tl010f02M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Tl010f02Form formVO, StandardCheckManager checker)
		{
			if (formVO.Head_tenpo_cd != null)
			{
				checker.DoCheck("Head_tenpo_cd", formVO.Head_tenpo_cd);
			}
			if (formVO.Head_tenpo_nm != null)
			{
				checker.DoCheck("Head_tenpo_nm", formVO.Head_tenpo_nm);
			}
			if (formVO.Bumon_cd_bo != null)
			{
				checker.DoCheck("Bumon_cd_bo", formVO.Bumon_cd_bo);
			}
			if (formVO.Bumon_nm != null)
			{
				checker.DoCheck("Bumon_nm", formVO.Bumon_nm);
			}
			if (formVO.Baihenkaisi_ymd != null)
			{
				checker.DoCheck("Baihenkaisi_ymd", formVO.Baihenkaisi_ymd);
			}
			if (formVO.Kaishi_jyotai_nm != null)
			{
				checker.DoCheck("Kaishi_jyotai_nm", formVO.Kaishi_jyotai_nm);
			}
			if (formVO.Comment_nm != null)
			{
				checker.DoCheck("Comment_nm", formVO.Comment_nm);
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
		public static void ValidateM1InputValue(Tl010f02Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Tl010f02M1Form tl010f02M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, tl010f02M1Form, i, m1List);
				if (tl010f02M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", tl010f02M1Form.M1rowno, i, m1List);
				}
				if (tl010f02M1Form.M1burando_nm != null)
				{
					checker.DoCheck("M1burando_nm", tl010f02M1Form.M1burando_nm, i, m1List);
				}
				if (tl010f02M1Form.M1jisya_hbn != null)
				{
					checker.DoCheck("M1jisya_hbn", tl010f02M1Form.M1jisya_hbn, i, m1List);
				}
				if (tl010f02M1Form.M1maker_hbn != null)
				{
					checker.DoCheck("M1maker_hbn", tl010f02M1Form.M1maker_hbn, i, m1List);
				}
				if (tl010f02M1Form.M1syonmk != null)
				{
					checker.DoCheck("M1syonmk", tl010f02M1Form.M1syonmk, i, m1List);
				}
				if (tl010f02M1Form.M1iro_nm != null)
				{
					checker.DoCheck("M1iro_nm", tl010f02M1Form.M1iro_nm, i, m1List);
				}
				if (tl010f02M1Form.M1gen_tnk != null)
				{
					checker.DoCheck("M1gen_tnk", tl010f02M1Form.M1gen_tnk, i, m1List);
				}
				if (tl010f02M1Form.M1genbaika_tnm1k != null)
				{
					checker.DoCheck("M1genbaika_tnm1k", tl010f02M1Form.M1genbaika_tnm1k, i, m1List);
				}
				if (tl010f02M1Form.M1mtobaika_tnk != null)
				{
					checker.DoCheck("M1mtobaika_tnk", tl010f02M1Form.M1mtobaika_tnk, i, m1List);
				}
				if (tl010f02M1Form.M1shinbaika_tnk != null)
				{
					checker.DoCheck("M1shinbaika_tnk", tl010f02M1Form.M1shinbaika_tnk, i, m1List);
				}
				if (tl010f02M1Form.M1neire_rtu_genko != null)
				{
					checker.DoCheck("M1neire_rtu_genko", tl010f02M1Form.M1neire_rtu_genko, i, m1List);
				}
				if (tl010f02M1Form.M1neire_rtu_baihengo != null)
				{
					checker.DoCheck("M1neire_rtu_baihengo", tl010f02M1Form.M1neire_rtu_baihengo, i, m1List);
				}
				if (tl010f02M1Form.M1zaiko_su != null)
				{
					checker.DoCheck("M1zaiko_su", tl010f02M1Form.M1zaiko_su, i, m1List);
				}
				if (tl010f02M1Form.M1uriage_su != null)
				{
					checker.DoCheck("M1uriage_su", tl010f02M1Form.M1uriage_su, i, m1List);
				}
				if (tl010f02M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", tl010f02M1Form.M1selectorcheckbox, i, m1List);
				}
				if (tl010f02M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", tl010f02M1Form.M1entersyoriflg, i, m1List);
				}
				if (tl010f02M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", tl010f02M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Tl010f02Form formVO, StandardCodeCheckManager checker)
		{
			checker.DoCheck("Btnlabel_cd", formVO);
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Tl010f02Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

