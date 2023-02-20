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
  /// Tj170f01RequestHelper の概要の説明です。
  /// </summary>
  public static class Tj170f01RequestHelper
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
			Tj170f01Form formVO = (Tj170f01Form)pageContext.GetFormVO();

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
			paramCol["Tanaorosikijun_ymd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tanaorosikijun_ymd"]);
			paramCol["Tanaorosijissi_ymd1"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tanaorosijissi_ymd1"]);
			paramCol["Tanaorosikikan_from1"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tanaorosikikan_from1"]);
			paramCol["Tanaorosikikan_to1"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tanaorosikikan_to1"]);
			paramCol["Tanaorosikijun_ymd1"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tanaorosikijun_ymd1"]);
			paramCol["Tanaorosijissi_ymd11"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tanaorosijissi_ymd11"]);
			paramCol["Tanaorosikikan_from11"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tanaorosikikan_from11"]);
			paramCol["Tanaorosikikan_to11"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tanaorosikikan_to11"]);
			paramCol["Syohingun1_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Syohingun1_cd"]);
			paramCol["Syohingun1_ryaku_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Syohingun1_ryaku_nm"]);
			paramCol["Syohingun2_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Syohingun2_cd"]);
			paramCol["Grpnm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Grpnm"]);
			paramCol["Bumon_cd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_cd_from"]);
			paramCol["Bumon_nm_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_nm_from"]);
			paramCol["Hinsyu_cd_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hinsyu_cd_from"]);
			paramCol["Hinsyu_ryaku_nm_from"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hinsyu_ryaku_nm_from"]);
			paramCol["Bumon_cd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_cd_to"]);
			paramCol["Bumon_nm_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_nm_to"]);
			paramCol["Hinsyu_cd_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hinsyu_cd_to"]);
			paramCol["Hinsyu_ryaku_nm_to"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Hinsyu_ryaku_nm_to"]);
			paramCol["Burando_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Burando_cd"]);
			paramCol["Burando_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Burando_nm"]);
			paramCol["Loss_tensu"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Loss_tensu"]);
			paramCol["Loss_ari_flg"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Loss_ari_flg"]);
			paramCol["Shuturyoku_tani"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Shuturyoku_tani"]);
			paramCol["Sort_jun"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Sort_jun"]);
			paramCol["Searchcnt"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Searchcnt"]);
			paramCol["Shuturyoku_print"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Shuturyoku_print"]);
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
				paramCol["M1syohingun2_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1syohingun2_cd"]);
				paramCol["M1grpnm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1grpnm"]);
				paramCol["M1bumon_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1bumon_cd"]);
				paramCol["M1bumonkana_nm"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1bumonkana_nm"]);
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
			Tj170f01Form formVO = (Tj170f01Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Modeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Modeno"].RequestValue, formInfo["Modeno"]);
			paramCol["Stkmodeno"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Stkmodeno"].RequestValue, formInfo["Stkmodeno"]);
			paramCol["Tanaorosikijun_ymd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tanaorosikijun_ymd"].RequestValue, formInfo["Tanaorosikijun_ymd"]);
			paramCol["Tanaorosikijun_ymd"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Tanaorosikijun_ymd"].RequestValue, formInfo["Tanaorosikijun_ymd"]);
			paramCol["Tanaorosijissi_ymd1"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tanaorosijissi_ymd1"].RequestValue, formInfo["Tanaorosijissi_ymd1"]);
			paramCol["Tanaorosijissi_ymd1"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Tanaorosijissi_ymd1"].RequestValue, formInfo["Tanaorosijissi_ymd1"]);
			paramCol["Tanaorosikikan_from1"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tanaorosikikan_from1"].RequestValue, formInfo["Tanaorosikikan_from1"]);
			paramCol["Tanaorosikikan_from1"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Tanaorosikikan_from1"].RequestValue, formInfo["Tanaorosikikan_from1"]);
			paramCol["Tanaorosikikan_to1"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tanaorosikikan_to1"].RequestValue, formInfo["Tanaorosikikan_to1"]);
			paramCol["Tanaorosikikan_to1"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Tanaorosikikan_to1"].RequestValue, formInfo["Tanaorosikikan_to1"]);
			paramCol["Tanaorosikijun_ymd1"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tanaorosikijun_ymd1"].RequestValue, formInfo["Tanaorosikijun_ymd1"]);
			paramCol["Tanaorosikijun_ymd1"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Tanaorosikijun_ymd1"].RequestValue, formInfo["Tanaorosikijun_ymd1"]);
			paramCol["Tanaorosijissi_ymd11"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tanaorosijissi_ymd11"].RequestValue, formInfo["Tanaorosijissi_ymd11"]);
			paramCol["Tanaorosijissi_ymd11"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Tanaorosijissi_ymd11"].RequestValue, formInfo["Tanaorosijissi_ymd11"]);
			paramCol["Tanaorosikikan_from11"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tanaorosikikan_from11"].RequestValue, formInfo["Tanaorosikikan_from11"]);
			paramCol["Tanaorosikikan_from11"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Tanaorosikikan_from11"].RequestValue, formInfo["Tanaorosikikan_from11"]);
			paramCol["Tanaorosikikan_to11"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tanaorosikikan_to11"].RequestValue, formInfo["Tanaorosikikan_to11"]);
			paramCol["Tanaorosikikan_to11"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Tanaorosikikan_to11"].RequestValue, formInfo["Tanaorosikikan_to11"]);
			paramCol["Syohingun1_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Syohingun1_cd"].RequestValue, formInfo["Syohingun1_cd"]);
			paramCol["Syohingun1_ryaku_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Syohingun1_ryaku_nm"].RequestValue, formInfo["Syohingun1_ryaku_nm"]);
			paramCol["Syohingun2_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Syohingun2_cd"].RequestValue, formInfo["Syohingun2_cd"]);
			paramCol["Grpnm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Grpnm"].RequestValue, formInfo["Grpnm"]);
			paramCol["Bumon_cd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_cd_from"].RequestValue, formInfo["Bumon_cd_from"]);
			paramCol["Bumon_nm_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_nm_from"].RequestValue, formInfo["Bumon_nm_from"]);
			paramCol["Hinsyu_cd_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hinsyu_cd_from"].RequestValue, formInfo["Hinsyu_cd_from"]);
			paramCol["Hinsyu_ryaku_nm_from"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hinsyu_ryaku_nm_from"].RequestValue, formInfo["Hinsyu_ryaku_nm_from"]);
			paramCol["Bumon_cd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_cd_to"].RequestValue, formInfo["Bumon_cd_to"]);
			paramCol["Bumon_nm_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_nm_to"].RequestValue, formInfo["Bumon_nm_to"]);
			paramCol["Hinsyu_cd_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hinsyu_cd_to"].RequestValue, formInfo["Hinsyu_cd_to"]);
			paramCol["Hinsyu_ryaku_nm_to"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Hinsyu_ryaku_nm_to"].RequestValue, formInfo["Hinsyu_ryaku_nm_to"]);
			paramCol["Burando_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Burando_cd"].RequestValue, formInfo["Burando_cd"]);
			paramCol["Burando_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Burando_nm"].RequestValue, formInfo["Burando_nm"]);
			paramCol["Loss_tensu"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Loss_tensu"].RequestValue, formInfo["Loss_tensu"]);
			paramCol["Loss_ari_flg"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Loss_ari_flg"].RequestValue, formInfo["Loss_ari_flg"]);
			paramCol["Shuturyoku_tani"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Shuturyoku_tani"].RequestValue, formInfo["Shuturyoku_tani"]);
			paramCol["Sort_jun"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Sort_jun"].RequestValue, formInfo["Sort_jun"]);
			paramCol["Searchcnt"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Searchcnt"].RequestValue, formInfo["Searchcnt"]);
			paramCol["Shuturyoku_print"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Shuturyoku_print"].RequestValue, formInfo["Shuturyoku_print"]);
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
				paramCol["M1syohingun2_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1syohingun2_cd"][i].RequestValue, formInfo["M1syohingun2_cd"]);
				paramCol["M1grpnm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1grpnm"][i].RequestValue, formInfo["M1grpnm"]);
				paramCol["M1bumon_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1bumon_cd"][i].RequestValue, formInfo["M1bumon_cd"]);
				paramCol["M1bumonkana_nm"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1bumonkana_nm"][i].RequestValue, formInfo["M1bumonkana_nm"]);
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
			Tj170f01Form formVO = (Tj170f01Form)pageContext.GetFormVO();

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
			if (paramCol["Tanaorosikijun_ymd"].DateFullValue != null)
			{
				formVO.Tanaorosikijun_ymd = paramCol["Tanaorosikijun_ymd"].DateFullValue;
			}
			if (paramCol["Tanaorosijissi_ymd1"].DateFullValue != null)
			{
				formVO.Tanaorosijissi_ymd1 = paramCol["Tanaorosijissi_ymd1"].DateFullValue;
			}
			if (paramCol["Tanaorosikikan_from1"].DateFullValue != null)
			{
				formVO.Tanaorosikikan_from1 = paramCol["Tanaorosikikan_from1"].DateFullValue;
			}
			if (paramCol["Tanaorosikikan_to1"].DateFullValue != null)
			{
				formVO.Tanaorosikikan_to1 = paramCol["Tanaorosikikan_to1"].DateFullValue;
			}
			if (paramCol["Tanaorosikijun_ymd1"].DateFullValue != null)
			{
				formVO.Tanaorosikijun_ymd1 = paramCol["Tanaorosikijun_ymd1"].DateFullValue;
			}
			if (paramCol["Tanaorosijissi_ymd11"].DateFullValue != null)
			{
				formVO.Tanaorosijissi_ymd11 = paramCol["Tanaorosijissi_ymd11"].DateFullValue;
			}
			if (paramCol["Tanaorosikikan_from11"].DateFullValue != null)
			{
				formVO.Tanaorosikikan_from11 = paramCol["Tanaorosikikan_from11"].DateFullValue;
			}
			if (paramCol["Tanaorosikikan_to11"].DateFullValue != null)
			{
				formVO.Tanaorosikikan_to11 = paramCol["Tanaorosikikan_to11"].DateFullValue;
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
			if (paramCol["Bumon_cd_from"].UnformatValue != null)
			{
				formVO.Bumon_cd_from = paramCol["Bumon_cd_from"].UnformatValue;
			}
			if (paramCol["Bumon_nm_from"].UnformatValue != null)
			{
				formVO.Bumon_nm_from = paramCol["Bumon_nm_from"].UnformatValue;
			}
			if (paramCol["Hinsyu_cd_from"].UnformatValue != null)
			{
				formVO.Hinsyu_cd_from = paramCol["Hinsyu_cd_from"].UnformatValue;
			}
			if (paramCol["Hinsyu_ryaku_nm_from"].UnformatValue != null)
			{
				formVO.Hinsyu_ryaku_nm_from = paramCol["Hinsyu_ryaku_nm_from"].UnformatValue;
			}
			if (paramCol["Bumon_cd_to"].UnformatValue != null)
			{
				formVO.Bumon_cd_to = paramCol["Bumon_cd_to"].UnformatValue;
			}
			if (paramCol["Bumon_nm_to"].UnformatValue != null)
			{
				formVO.Bumon_nm_to = paramCol["Bumon_nm_to"].UnformatValue;
			}
			if (paramCol["Hinsyu_cd_to"].UnformatValue != null)
			{
				formVO.Hinsyu_cd_to = paramCol["Hinsyu_cd_to"].UnformatValue;
			}
			if (paramCol["Hinsyu_ryaku_nm_to"].UnformatValue != null)
			{
				formVO.Hinsyu_ryaku_nm_to = paramCol["Hinsyu_ryaku_nm_to"].UnformatValue;
			}
			if (paramCol["Burando_cd"].UnformatValue != null)
			{
				formVO.Burando_cd = paramCol["Burando_cd"].UnformatValue;
			}
			if (paramCol["Burando_nm"].UnformatValue != null)
			{
				formVO.Burando_nm = paramCol["Burando_nm"].UnformatValue;
			}
			if (paramCol["Loss_tensu"].UnformatValue != null)
			{
				formVO.Loss_tensu = paramCol["Loss_tensu"].UnformatValue;
			}
			if (paramCol["Loss_ari_flg"].UnformatValue != null)
			{
				formVO.Loss_ari_flg = paramCol["Loss_ari_flg"].UnformatValue;
			}
			if (paramCol["Shuturyoku_tani"].UnformatValue != null)
			{
				formVO.Shuturyoku_tani = paramCol["Shuturyoku_tani"].UnformatValue;
			}
			if (paramCol["Sort_jun"].UnformatValue != null)
			{
				formVO.Sort_jun = paramCol["Sort_jun"].UnformatValue;
			}
			if (paramCol["Searchcnt"].UnformatValue != null)
			{
				formVO.Searchcnt = paramCol["Searchcnt"].UnformatValue;
			}
			if (paramCol["Shuturyoku_print"].UnformatValue != null)
			{
				formVO.Shuturyoku_print = paramCol["Shuturyoku_print"].UnformatValue;
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
				Tj170f01M1Form tj170f01M1Form = (Tj170f01M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					tj170f01M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1syohingun2_cd"][i].UnformatValue != null)
				{
					tj170f01M1Form.M1syohingun2_cd = paramCol["M1syohingun2_cd"][i].UnformatValue;
				}
				if (paramCol["M1grpnm"][i].UnformatValue != null)
				{
					tj170f01M1Form.M1grpnm = paramCol["M1grpnm"][i].UnformatValue;
				}
				if (paramCol["M1bumon_cd"][i].UnformatValue != null)
				{
					tj170f01M1Form.M1bumon_cd = paramCol["M1bumon_cd"][i].UnformatValue;
				}
				if (paramCol["M1bumonkana_nm"][i].UnformatValue != null)
				{
					tj170f01M1Form.M1bumonkana_nm = paramCol["M1bumonkana_nm"][i].UnformatValue;
				}
				if (paramCol["M1tanajityobo_su"][i].UnformatValue != null)
				{
					tj170f01M1Form.M1tanajityobo_su = paramCol["M1tanajityobo_su"][i].UnformatValue;
				}
				if (paramCol["M1tanajisekiso_su"][i].UnformatValue != null)
				{
					tj170f01M1Form.M1tanajisekiso_su = paramCol["M1tanajisekiso_su"][i].UnformatValue;
				}
				if (paramCol["M1jitana_su"][i].UnformatValue != null)
				{
					tj170f01M1Form.M1jitana_su = paramCol["M1jitana_su"][i].UnformatValue;
				}
				if (paramCol["M1ikoukebarai_su"][i].UnformatValue != null)
				{
					tj170f01M1Form.M1ikoukebarai_su = paramCol["M1ikoukebarai_su"][i].UnformatValue;
				}
				if (paramCol["M1rironzaiko_su"][i].UnformatValue != null)
				{
					tj170f01M1Form.M1rironzaiko_su = paramCol["M1rironzaiko_su"][i].UnformatValue;
				}
				if (paramCol["M1rirontanaorosi_su"][i].UnformatValue != null)
				{
					tj170f01M1Form.M1rirontanaorosi_su = paramCol["M1rirontanaorosi_su"][i].UnformatValue;
				}
				if (paramCol["M1loss_su"][i].UnformatValue != null)
				{
					tj170f01M1Form.M1loss_su = paramCol["M1loss_su"][i].UnformatValue;
				}
				if (paramCol["M1loss_kin"][i].UnformatValue != null)
				{
					tj170f01M1Form.M1loss_kin = paramCol["M1loss_kin"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					tj170f01M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					tj170f01M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					tj170f01M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Tj170f01Form formVO, StandardCheckManager checker)
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
			if (formVO.Tanaorosikijun_ymd != null)
			{
				checker.DoCheck("Tanaorosikijun_ymd", formVO.Tanaorosikijun_ymd);
			}
			if (formVO.Tanaorosijissi_ymd1 != null)
			{
				checker.DoCheck("Tanaorosijissi_ymd1", formVO.Tanaorosijissi_ymd1);
			}
			if (formVO.Tanaorosikikan_from1 != null)
			{
				checker.DoCheck("Tanaorosikikan_from1", formVO.Tanaorosikikan_from1);
			}
			if (formVO.Tanaorosikikan_to1 != null)
			{
				checker.DoCheck("Tanaorosikikan_to1", formVO.Tanaorosikikan_to1);
			}
			if (formVO.Tanaorosikijun_ymd1 != null)
			{
				checker.DoCheck("Tanaorosikijun_ymd1", formVO.Tanaorosikijun_ymd1);
			}
			if (formVO.Tanaorosijissi_ymd11 != null)
			{
				checker.DoCheck("Tanaorosijissi_ymd11", formVO.Tanaorosijissi_ymd11);
			}
			if (formVO.Tanaorosikikan_from11 != null)
			{
				checker.DoCheck("Tanaorosikikan_from11", formVO.Tanaorosikikan_from11);
			}
			if (formVO.Tanaorosikikan_to11 != null)
			{
				checker.DoCheck("Tanaorosikikan_to11", formVO.Tanaorosikikan_to11);
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
			if (formVO.Bumon_cd_from != null)
			{
				checker.DoCheck("Bumon_cd_from", formVO.Bumon_cd_from);
			}
			if (formVO.Bumon_nm_from != null)
			{
				checker.DoCheck("Bumon_nm_from", formVO.Bumon_nm_from);
			}
			if (formVO.Hinsyu_cd_from != null)
			{
				checker.DoCheck("Hinsyu_cd_from", formVO.Hinsyu_cd_from);
			}
			if (formVO.Hinsyu_ryaku_nm_from != null)
			{
				checker.DoCheck("Hinsyu_ryaku_nm_from", formVO.Hinsyu_ryaku_nm_from);
			}
			if (formVO.Bumon_cd_to != null)
			{
				checker.DoCheck("Bumon_cd_to", formVO.Bumon_cd_to);
			}
			if (formVO.Bumon_nm_to != null)
			{
				checker.DoCheck("Bumon_nm_to", formVO.Bumon_nm_to);
			}
			if (formVO.Hinsyu_cd_to != null)
			{
				checker.DoCheck("Hinsyu_cd_to", formVO.Hinsyu_cd_to);
			}
			if (formVO.Hinsyu_ryaku_nm_to != null)
			{
				checker.DoCheck("Hinsyu_ryaku_nm_to", formVO.Hinsyu_ryaku_nm_to);
			}
			if (formVO.Burando_cd != null)
			{
				checker.DoCheck("Burando_cd", formVO.Burando_cd);
			}
			if (formVO.Burando_nm != null)
			{
				checker.DoCheck("Burando_nm", formVO.Burando_nm);
			}
			if (formVO.Loss_tensu != null)
			{
				checker.DoCheck("Loss_tensu", formVO.Loss_tensu);
			}
			if (formVO.Loss_ari_flg != null)
			{
				checker.DoCheck("Loss_ari_flg", formVO.Loss_ari_flg);
			}
			if (formVO.Shuturyoku_tani != null)
			{
				checker.DoCheck("Shuturyoku_tani", formVO.Shuturyoku_tani);
			}
			if (formVO.Sort_jun != null)
			{
				checker.DoCheck("Sort_jun", formVO.Sort_jun);
			}
			if (formVO.Searchcnt != null)
			{
				checker.DoCheck("Searchcnt", formVO.Searchcnt);
			}
			if (formVO.Shuturyoku_print != null)
			{
				checker.DoCheck("Shuturyoku_print", formVO.Shuturyoku_print);
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
		public static void ValidateM1InputValue(Tj170f01Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Tj170f01M1Form tj170f01M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, tj170f01M1Form, i, m1List);
				if (tj170f01M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", tj170f01M1Form.M1rowno, i, m1List);
				}
				if (tj170f01M1Form.M1syohingun2_cd != null)
				{
					checker.DoCheck("M1syohingun2_cd", tj170f01M1Form.M1syohingun2_cd, i, m1List);
				}
				if (tj170f01M1Form.M1grpnm != null)
				{
					checker.DoCheck("M1grpnm", tj170f01M1Form.M1grpnm, i, m1List);
				}
				if (tj170f01M1Form.M1bumon_cd != null)
				{
					checker.DoCheck("M1bumon_cd", tj170f01M1Form.M1bumon_cd, i, m1List);
				}
				if (tj170f01M1Form.M1bumonkana_nm != null)
				{
					checker.DoCheck("M1bumonkana_nm", tj170f01M1Form.M1bumonkana_nm, i, m1List);
				}
				if (tj170f01M1Form.M1tanajityobo_su != null)
				{
					checker.DoCheck("M1tanajityobo_su", tj170f01M1Form.M1tanajityobo_su, i, m1List);
				}
				if (tj170f01M1Form.M1tanajisekiso_su != null)
				{
					checker.DoCheck("M1tanajisekiso_su", tj170f01M1Form.M1tanajisekiso_su, i, m1List);
				}
				if (tj170f01M1Form.M1jitana_su != null)
				{
					checker.DoCheck("M1jitana_su", tj170f01M1Form.M1jitana_su, i, m1List);
				}
				if (tj170f01M1Form.M1ikoukebarai_su != null)
				{
					checker.DoCheck("M1ikoukebarai_su", tj170f01M1Form.M1ikoukebarai_su, i, m1List);
				}
				if (tj170f01M1Form.M1rironzaiko_su != null)
				{
					checker.DoCheck("M1rironzaiko_su", tj170f01M1Form.M1rironzaiko_su, i, m1List);
				}
				if (tj170f01M1Form.M1rirontanaorosi_su != null)
				{
					checker.DoCheck("M1rirontanaorosi_su", tj170f01M1Form.M1rirontanaorosi_su, i, m1List);
				}
				if (tj170f01M1Form.M1loss_su != null)
				{
					checker.DoCheck("M1loss_su", tj170f01M1Form.M1loss_su, i, m1List);
				}
				if (tj170f01M1Form.M1loss_kin != null)
				{
					checker.DoCheck("M1loss_kin", tj170f01M1Form.M1loss_kin, i, m1List);
				}
				if (tj170f01M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", tj170f01M1Form.M1selectorcheckbox, i, m1List);
				}
				if (tj170f01M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", tj170f01M1Form.M1entersyoriflg, i, m1List);
				}
				if (tj170f01M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", tj170f01M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Tj170f01Form formVO, StandardCodeCheckManager checker)
		{
			checker.DoCheck("Btnheadtenpocd", formVO);
			checker.DoCheck("Btnsyohingun1_cd", formVO);
			checker.DoCheck("Btnsyohingun2_cd", formVO);
			checker.DoCheck("Btnbumon_cd_from", formVO);
			checker.DoCheck("Btnhinsyu_cd_from", formVO);
			checker.DoCheck("Btnbumon_cd_to", formVO);
			checker.DoCheck("Btnhinsyu_cd_to", formVO);
			checker.DoCheck("Btnburando_cd", formVO);
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Tj170f01Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

