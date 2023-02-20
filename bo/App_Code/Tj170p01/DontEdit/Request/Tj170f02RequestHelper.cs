using com.xebio.bo.Tj170p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.SelfCustomize.Runtime.PJCommon;
using Common.Advanced.Web.Context;
using Common.Standard.Base;
using Common.Standard.Check;
using System.Web;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Tj170p01.Request
{
  /// <summary>
  /// Tj170f02RequestHelper の概要の説明です。
  /// </summary>
  public static class Tj170f02RequestHelper
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
			Tj170f02Form formVO = (Tj170f02Form)pageContext.GetFormVO();

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
			paramCol["Syohingun1_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Syohingun1_cd"]);
			paramCol["Syohingun1_ryaku_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Syohingun1_ryaku_nm"]);
			paramCol["Syohingun2_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Syohingun2_cd"]);
			paramCol["Grpnm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Grpnm"]);
			paramCol["Gokeitanajityobo_su"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokeitanajityobo_su"]);
			paramCol["Gokeitanajisekiso_su"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokeitanajisekiso_su"]);
			paramCol["Gokeijitana_su"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokeijitana_su"]);
			paramCol["Gokeiikoukebarai_su"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokeiikoukebarai_su"]);
			paramCol["Gokeirironzaiko_su"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokeirironzaiko_su"]);
			paramCol["Gokeirirontanaorosi_su"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokeirirontanaorosi_su"]);
			paramCol["Gokeiloss_su"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokeiloss_su"]);
			paramCol["Gokeiloss_kin"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokeiloss_kin"]);
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
				paramCol["M1genbaika_tnk"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1genbaika_tnk"]);
				paramCol["M1hyoka_tnk"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hyoka_tnk"]);
				paramCol["M1tanajityobo_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tanajityobo_su"]);
				paramCol["M1tanajisekiso_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tanajisekiso_su"]);
				paramCol["M1jitana_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1jitana_su"]);
				paramCol["M1ikoukebarai_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1ikoukebarai_su"]);
				paramCol["M1rironzaiko_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1rironzaiko_su"]);
				paramCol["M1rirontanaorosi_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1rirontanaorosi_su"]);
				paramCol["M1loss_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1loss_su"]);
				paramCol["M1loss_kin"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1loss_kin"]);
				paramCol["M1face_no"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1face_no"]);
				paramCol["M1tana_dan"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1tana_dan"]);
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
			Tj170f02Form formVO = (Tj170f02Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Stkmodeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Stkmodeno"].RequestValue, formInfo["Stkmodeno"]);
			paramCol["Syohingun1_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Syohingun1_cd"].RequestValue, formInfo["Syohingun1_cd"]);
			paramCol["Syohingun1_ryaku_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Syohingun1_ryaku_nm"].RequestValue, formInfo["Syohingun1_ryaku_nm"]);
			paramCol["Syohingun2_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Syohingun2_cd"].RequestValue, formInfo["Syohingun2_cd"]);
			paramCol["Grpnm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Grpnm"].RequestValue, formInfo["Grpnm"]);
			paramCol["Gokeitanajityobo_su"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokeitanajityobo_su"].RequestValue, formInfo["Gokeitanajityobo_su"]);
			paramCol["Gokeitanajisekiso_su"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokeitanajisekiso_su"].RequestValue, formInfo["Gokeitanajisekiso_su"]);
			paramCol["Gokeijitana_su"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokeijitana_su"].RequestValue, formInfo["Gokeijitana_su"]);
			paramCol["Gokeiikoukebarai_su"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokeiikoukebarai_su"].RequestValue, formInfo["Gokeiikoukebarai_su"]);
			paramCol["Gokeirironzaiko_su"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokeirironzaiko_su"].RequestValue, formInfo["Gokeirironzaiko_su"]);
			paramCol["Gokeirirontanaorosi_su"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokeirirontanaorosi_su"].RequestValue, formInfo["Gokeirirontanaorosi_su"]);
			paramCol["Gokeiloss_su"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokeiloss_su"].RequestValue, formInfo["Gokeiloss_su"]);
			paramCol["Gokeiloss_kin"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokeiloss_kin"].RequestValue, formInfo["Gokeiloss_kin"]);
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
				paramCol["M1genbaika_tnk"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1genbaika_tnk"][i].RequestValue, formInfo["M1genbaika_tnk"]);
				paramCol["M1hyoka_tnk"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hyoka_tnk"][i].RequestValue, formInfo["M1hyoka_tnk"]);
				paramCol["M1tanajityobo_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tanajityobo_su"][i].RequestValue, formInfo["M1tanajityobo_su"]);
				paramCol["M1tanajisekiso_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tanajisekiso_su"][i].RequestValue, formInfo["M1tanajisekiso_su"]);
				paramCol["M1jitana_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1jitana_su"][i].RequestValue, formInfo["M1jitana_su"]);
				paramCol["M1ikoukebarai_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1ikoukebarai_su"][i].RequestValue, formInfo["M1ikoukebarai_su"]);
				paramCol["M1rironzaiko_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1rironzaiko_su"][i].RequestValue, formInfo["M1rironzaiko_su"]);
				paramCol["M1rirontanaorosi_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1rirontanaorosi_su"][i].RequestValue, formInfo["M1rirontanaorosi_su"]);
				paramCol["M1loss_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1loss_su"][i].RequestValue, formInfo["M1loss_su"]);
				paramCol["M1loss_kin"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1loss_kin"][i].RequestValue, formInfo["M1loss_kin"]);
				paramCol["M1face_no"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1face_no"][i].RequestValue, formInfo["M1face_no"]);
				paramCol["M1tana_dan"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1tana_dan"][i].RequestValue, formInfo["M1tana_dan"]);
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
			Tj170f02Form formVO = (Tj170f02Form)pageContext.GetFormVO();

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
			if (paramCol["Syohingun1_cd"].UnformatValue != null)
			{
				formVO.Syohingun1_cd = paramCol["Syohingun1_cd"].UnformatValue;
			}
			if (paramCol["Syohingun1_ryaku_nm"].UnformatValue != null)
			{
				formVO.Syohingun1_ryaku_nm = paramCol["Syohingun1_ryaku_nm"].UnformatValue;
			}
			if (paramCol["Syohingun2_cd"].UnformatValue != null)
			{
				formVO.Syohingun2_cd = paramCol["Syohingun2_cd"].UnformatValue;
			}
			if (paramCol["Grpnm"].UnformatValue != null)
			{
				formVO.Grpnm = paramCol["Grpnm"].UnformatValue;
			}
			if (paramCol["Gokeitanajityobo_su"].UnformatValue != null)
			{
				formVO.Gokeitanajityobo_su = paramCol["Gokeitanajityobo_su"].UnformatValue;
			}
			if (paramCol["Gokeitanajisekiso_su"].UnformatValue != null)
			{
				formVO.Gokeitanajisekiso_su = paramCol["Gokeitanajisekiso_su"].UnformatValue;
			}
			if (paramCol["Gokeijitana_su"].UnformatValue != null)
			{
				formVO.Gokeijitana_su = paramCol["Gokeijitana_su"].UnformatValue;
			}
			if (paramCol["Gokeiikoukebarai_su"].UnformatValue != null)
			{
				formVO.Gokeiikoukebarai_su = paramCol["Gokeiikoukebarai_su"].UnformatValue;
			}
			if (paramCol["Gokeirironzaiko_su"].UnformatValue != null)
			{
				formVO.Gokeirironzaiko_su = paramCol["Gokeirironzaiko_su"].UnformatValue;
			}
			if (paramCol["Gokeirirontanaorosi_su"].UnformatValue != null)
			{
				formVO.Gokeirirontanaorosi_su = paramCol["Gokeirirontanaorosi_su"].UnformatValue;
			}
			if (paramCol["Gokeiloss_su"].UnformatValue != null)
			{
				formVO.Gokeiloss_su = paramCol["Gokeiloss_su"].UnformatValue;
			}
			if (paramCol["Gokeiloss_kin"].UnformatValue != null)
			{
				formVO.Gokeiloss_kin = paramCol["Gokeiloss_kin"].UnformatValue;
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
				Tj170f02M1Form tj170f02M1Form = (Tj170f02M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					tj170f02M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1bumon_cd"][i].UnformatValue != null)
				{
					tj170f02M1Form.M1bumon_cd = paramCol["M1bumon_cd"][i].UnformatValue;
				}
				if (paramCol["M1bumonkana_nm"][i].UnformatValue != null)
				{
					tj170f02M1Form.M1bumonkana_nm = paramCol["M1bumonkana_nm"][i].UnformatValue;
				}
				if (paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue != null)
				{
					tj170f02M1Form.M1hinsyu_ryaku_nm = paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue;
				}
				if (paramCol["M1burando_nm"][i].UnformatValue != null)
				{
					tj170f02M1Form.M1burando_nm = paramCol["M1burando_nm"][i].UnformatValue;
				}
				if (paramCol["M1jisya_hbn"][i].UnformatValue != null)
				{
					tj170f02M1Form.M1jisya_hbn = paramCol["M1jisya_hbn"][i].UnformatValue;
				}
				if (paramCol["M1maker_hbn"][i].UnformatValue != null)
				{
					tj170f02M1Form.M1maker_hbn = paramCol["M1maker_hbn"][i].UnformatValue;
				}
				if (paramCol["M1syonmk"][i].UnformatValue != null)
				{
					tj170f02M1Form.M1syonmk = paramCol["M1syonmk"][i].UnformatValue;
				}
				if (paramCol["M1iro_nm"][i].UnformatValue != null)
				{
					tj170f02M1Form.M1iro_nm = paramCol["M1iro_nm"][i].UnformatValue;
				}
				if (paramCol["M1size_nm"][i].UnformatValue != null)
				{
					tj170f02M1Form.M1size_nm = paramCol["M1size_nm"][i].UnformatValue;
				}
				if (paramCol["M1scan_cd"][i].UnformatValue != null)
				{
					tj170f02M1Form.M1scan_cd = paramCol["M1scan_cd"][i].UnformatValue;
				}
				if (paramCol["M1genbaika_tnk"][i].UnformatValue != null)
				{
					tj170f02M1Form.M1genbaika_tnk = paramCol["M1genbaika_tnk"][i].UnformatValue;
				}
				if (paramCol["M1hyoka_tnk"][i].UnformatValue != null)
				{
					tj170f02M1Form.M1hyoka_tnk = paramCol["M1hyoka_tnk"][i].UnformatValue;
				}
				if (paramCol["M1tanajityobo_su"][i].UnformatValue != null)
				{
					tj170f02M1Form.M1tanajityobo_su = paramCol["M1tanajityobo_su"][i].UnformatValue;
				}
				if (paramCol["M1tanajisekiso_su"][i].UnformatValue != null)
				{
					tj170f02M1Form.M1tanajisekiso_su = paramCol["M1tanajisekiso_su"][i].UnformatValue;
				}
				if (paramCol["M1jitana_su"][i].UnformatValue != null)
				{
					tj170f02M1Form.M1jitana_su = paramCol["M1jitana_su"][i].UnformatValue;
				}
				if (paramCol["M1ikoukebarai_su"][i].UnformatValue != null)
				{
					tj170f02M1Form.M1ikoukebarai_su = paramCol["M1ikoukebarai_su"][i].UnformatValue;
				}
				if (paramCol["M1rironzaiko_su"][i].UnformatValue != null)
				{
					tj170f02M1Form.M1rironzaiko_su = paramCol["M1rironzaiko_su"][i].UnformatValue;
				}
				if (paramCol["M1rirontanaorosi_su"][i].UnformatValue != null)
				{
					tj170f02M1Form.M1rirontanaorosi_su = paramCol["M1rirontanaorosi_su"][i].UnformatValue;
				}
				if (paramCol["M1loss_su"][i].UnformatValue != null)
				{
					tj170f02M1Form.M1loss_su = paramCol["M1loss_su"][i].UnformatValue;
				}
				if (paramCol["M1loss_kin"][i].UnformatValue != null)
				{
					tj170f02M1Form.M1loss_kin = paramCol["M1loss_kin"][i].UnformatValue;
				}
				if (paramCol["M1face_no"][i].UnformatValue != null)
				{
					tj170f02M1Form.M1face_no = paramCol["M1face_no"][i].UnformatValue;
				}
				if (paramCol["M1tana_dan"][i].UnformatValue != null)
				{
					tj170f02M1Form.M1tana_dan = paramCol["M1tana_dan"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Tj170f02Form formVO, StandardCheckManager checker)
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
			if (formVO.Syohingun1_cd != null)
			{
				checker.DoCheck("Syohingun1_cd", formVO.Syohingun1_cd);
			}
			if (formVO.Syohingun1_ryaku_nm != null)
			{
				checker.DoCheck("Syohingun1_ryaku_nm", formVO.Syohingun1_ryaku_nm);
			}
			if (formVO.Syohingun2_cd != null)
			{
				checker.DoCheck("Syohingun2_cd", formVO.Syohingun2_cd);
			}
			if (formVO.Grpnm != null)
			{
				checker.DoCheck("Grpnm", formVO.Grpnm);
			}
			if (formVO.Gokeitanajityobo_su != null)
			{
				checker.DoCheck("Gokeitanajityobo_su", formVO.Gokeitanajityobo_su);
			}
			if (formVO.Gokeitanajisekiso_su != null)
			{
				checker.DoCheck("Gokeitanajisekiso_su", formVO.Gokeitanajisekiso_su);
			}
			if (formVO.Gokeijitana_su != null)
			{
				checker.DoCheck("Gokeijitana_su", formVO.Gokeijitana_su);
			}
			if (formVO.Gokeiikoukebarai_su != null)
			{
				checker.DoCheck("Gokeiikoukebarai_su", formVO.Gokeiikoukebarai_su);
			}
			if (formVO.Gokeirironzaiko_su != null)
			{
				checker.DoCheck("Gokeirironzaiko_su", formVO.Gokeirironzaiko_su);
			}
			if (formVO.Gokeirirontanaorosi_su != null)
			{
				checker.DoCheck("Gokeirirontanaorosi_su", formVO.Gokeirirontanaorosi_su);
			}
			if (formVO.Gokeiloss_su != null)
			{
				checker.DoCheck("Gokeiloss_su", formVO.Gokeiloss_su);
			}
			if (formVO.Gokeiloss_kin != null)
			{
				checker.DoCheck("Gokeiloss_kin", formVO.Gokeiloss_kin);
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
		public static void ValidateM1InputValue(Tj170f02Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Tj170f02M1Form tj170f02M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, tj170f02M1Form, i, m1List);
				if (tj170f02M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", tj170f02M1Form.M1rowno, i, m1List);
				}
				if (tj170f02M1Form.M1bumon_cd != null)
				{
					checker.DoCheck("M1bumon_cd", tj170f02M1Form.M1bumon_cd, i, m1List);
				}
				if (tj170f02M1Form.M1bumonkana_nm != null)
				{
					checker.DoCheck("M1bumonkana_nm", tj170f02M1Form.M1bumonkana_nm, i, m1List);
				}
				if (tj170f02M1Form.M1hinsyu_ryaku_nm != null)
				{
					checker.DoCheck("M1hinsyu_ryaku_nm", tj170f02M1Form.M1hinsyu_ryaku_nm, i, m1List);
				}
				if (tj170f02M1Form.M1burando_nm != null)
				{
					checker.DoCheck("M1burando_nm", tj170f02M1Form.M1burando_nm, i, m1List);
				}
				if (tj170f02M1Form.M1jisya_hbn != null)
				{
					checker.DoCheck("M1jisya_hbn", tj170f02M1Form.M1jisya_hbn, i, m1List);
				}
				if (tj170f02M1Form.M1maker_hbn != null)
				{
					checker.DoCheck("M1maker_hbn", tj170f02M1Form.M1maker_hbn, i, m1List);
				}
				if (tj170f02M1Form.M1syonmk != null)
				{
					checker.DoCheck("M1syonmk", tj170f02M1Form.M1syonmk, i, m1List);
				}
				if (tj170f02M1Form.M1iro_nm != null)
				{
					checker.DoCheck("M1iro_nm", tj170f02M1Form.M1iro_nm, i, m1List);
				}
				if (tj170f02M1Form.M1size_nm != null)
				{
					checker.DoCheck("M1size_nm", tj170f02M1Form.M1size_nm, i, m1List);
				}
				if (tj170f02M1Form.M1scan_cd != null)
				{
					checker.DoCheck("M1scan_cd", tj170f02M1Form.M1scan_cd, i, m1List);
				}
				if (tj170f02M1Form.M1genbaika_tnk != null)
				{
					checker.DoCheck("M1genbaika_tnk", tj170f02M1Form.M1genbaika_tnk, i, m1List);
				}
				if (tj170f02M1Form.M1hyoka_tnk != null)
				{
					checker.DoCheck("M1hyoka_tnk", tj170f02M1Form.M1hyoka_tnk, i, m1List);
				}
				if (tj170f02M1Form.M1tanajityobo_su != null)
				{
					checker.DoCheck("M1tanajityobo_su", tj170f02M1Form.M1tanajityobo_su, i, m1List);
				}
				if (tj170f02M1Form.M1tanajisekiso_su != null)
				{
					checker.DoCheck("M1tanajisekiso_su", tj170f02M1Form.M1tanajisekiso_su, i, m1List);
				}
				if (tj170f02M1Form.M1jitana_su != null)
				{
					checker.DoCheck("M1jitana_su", tj170f02M1Form.M1jitana_su, i, m1List);
				}
				if (tj170f02M1Form.M1ikoukebarai_su != null)
				{
					checker.DoCheck("M1ikoukebarai_su", tj170f02M1Form.M1ikoukebarai_su, i, m1List);
				}
				if (tj170f02M1Form.M1rironzaiko_su != null)
				{
					checker.DoCheck("M1rironzaiko_su", tj170f02M1Form.M1rironzaiko_su, i, m1List);
				}
				if (tj170f02M1Form.M1rirontanaorosi_su != null)
				{
					checker.DoCheck("M1rirontanaorosi_su", tj170f02M1Form.M1rirontanaorosi_su, i, m1List);
				}
				if (tj170f02M1Form.M1loss_su != null)
				{
					checker.DoCheck("M1loss_su", tj170f02M1Form.M1loss_su, i, m1List);
				}
				if (tj170f02M1Form.M1loss_kin != null)
				{
					checker.DoCheck("M1loss_kin", tj170f02M1Form.M1loss_kin, i, m1List);
				}
				if (tj170f02M1Form.M1face_no != null)
				{
					checker.DoCheck("M1face_no", tj170f02M1Form.M1face_no, i, m1List);
				}
				if (tj170f02M1Form.M1tana_dan != null)
				{
					checker.DoCheck("M1tana_dan", tj170f02M1Form.M1tana_dan, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Tj170f02Form formVO, StandardCodeCheckManager checker)
		{
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Tj170f02Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

