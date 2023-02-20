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
  /// Th020f02RequestHelper の概要の説明です。
  /// </summary>
  public static class Th020f02RequestHelper
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
			Th020f02Form formVO = (Th020f02Form)pageContext.GetFormVO();

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
			paramCol["Zentenzaiko_su"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Zentenzaiko_su"]);
			paramCol["Zentensyoka_rtu"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Zentensyoka_rtu"]);
			paramCol["Tenpo_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tenpo_nm"]);
			paramCol["Tenpo_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tenpo_cd"]);
			paramCol["All_gokei_suryo"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["All_gokei_suryo"]);
			paramCol["Suryo1"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Suryo1"]);
			paramCol["Suryo2"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Suryo2"]);
			paramCol["Suryo3"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Suryo3"]);
			paramCol["Suryo4"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Suryo4"]);
			paramCol["Suryo5"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Suryo5"]);
			paramCol["Suryo6"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Suryo6"]);
			paramCol["Suryo7"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Suryo7"]);
			paramCol["Suryo8"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Suryo8"]);
			paramCol["Suryo9"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Suryo9"]);
			paramCol["Suryo10"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Suryo10"]);
			paramCol["Suryo11"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Suryo11"]);
			paramCol["Suryo12"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Suryo12"]);
			paramCol["Suryo13"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Suryo13"]);
			paramCol["Suryo14"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Suryo14"]);
			paramCol["Suryo15"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Suryo15"]);
			paramCol["Suryo16"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Suryo16"]);
			paramCol["Suryo17"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Suryo17"]);
			paramCol["Suryo18"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Suryo18"]);
			paramCol["Suryo19"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Suryo19"]);
			paramCol["Suryo20"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Suryo20"]);
			paramCol["Suryo21"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Suryo21"]);
			paramCol["Suryo22"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Suryo22"]);
			paramCol["Suryo23"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Suryo23"]);
			paramCol["Suryo24"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Suryo24"]);
			paramCol["Suryo25"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Suryo25"]);
			paramCol["Suryo26"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Suryo26"]);
			paramCol["Suryo27"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Suryo27"]);
			paramCol["Suryo28"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Suryo28"]);
			paramCol["Suryo29"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Suryo29"]);
			paramCol["Suryo30"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Suryo30"]);
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
				paramCol["M1gokei_suryo"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1gokei_suryo"]);
				paramCol["M1syoka_rtu"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1syoka_rtu"]);
				paramCol["M1suryo1"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1suryo1"]);
				paramCol["M1suryo2"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1suryo2"]);
				paramCol["M1suryo3"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1suryo3"]);
				paramCol["M1suryo4"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1suryo4"]);
				paramCol["M1suryo5"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1suryo5"]);
				paramCol["M1suryo6"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1suryo6"]);
				paramCol["M1suryo7"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1suryo7"]);
				paramCol["M1suryo8"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1suryo8"]);
				paramCol["M1suryo9"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1suryo9"]);
				paramCol["M1suryo10"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1suryo10"]);
				paramCol["M1suryo11"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1suryo11"]);
				paramCol["M1suryo12"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1suryo12"]);
				paramCol["M1suryo13"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1suryo13"]);
				paramCol["M1suryo14"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1suryo14"]);
				paramCol["M1suryo15"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1suryo15"]);
				paramCol["M1suryo16"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1suryo16"]);
				paramCol["M1suryo17"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1suryo17"]);
				paramCol["M1suryo18"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1suryo18"]);
				paramCol["M1suryo19"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1suryo19"]);
				paramCol["M1suryo20"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1suryo20"]);
				paramCol["M1suryo21"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1suryo21"]);
				paramCol["M1suryo22"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1suryo22"]);
				paramCol["M1suryo23"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1suryo23"]);
				paramCol["M1suryo24"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1suryo24"]);
				paramCol["M1suryo25"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1suryo25"]);
				paramCol["M1suryo26"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1suryo26"]);
				paramCol["M1suryo27"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1suryo27"]);
				paramCol["M1suryo28"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1suryo28"]);
				paramCol["M1suryo29"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1suryo29"]);
				paramCol["M1suryo30"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1suryo30"]);
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
			Th020f02Form formVO = (Th020f02Form)pageContext.GetFormVO();

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
			paramCol["Zentenzaiko_su"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Zentenzaiko_su"].RequestValue, formInfo["Zentenzaiko_su"]);
			paramCol["Zentensyoka_rtu"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Zentensyoka_rtu"].RequestValue, formInfo["Zentensyoka_rtu"]);
			paramCol["Tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tenpo_nm"].RequestValue, formInfo["Tenpo_nm"]);
			paramCol["Tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tenpo_cd"].RequestValue, formInfo["Tenpo_cd"]);
			paramCol["All_gokei_suryo"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["All_gokei_suryo"].RequestValue, formInfo["All_gokei_suryo"]);
			paramCol["Suryo1"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Suryo1"].RequestValue, formInfo["Suryo1"]);
			paramCol["Suryo2"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Suryo2"].RequestValue, formInfo["Suryo2"]);
			paramCol["Suryo3"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Suryo3"].RequestValue, formInfo["Suryo3"]);
			paramCol["Suryo4"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Suryo4"].RequestValue, formInfo["Suryo4"]);
			paramCol["Suryo5"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Suryo5"].RequestValue, formInfo["Suryo5"]);
			paramCol["Suryo6"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Suryo6"].RequestValue, formInfo["Suryo6"]);
			paramCol["Suryo7"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Suryo7"].RequestValue, formInfo["Suryo7"]);
			paramCol["Suryo8"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Suryo8"].RequestValue, formInfo["Suryo8"]);
			paramCol["Suryo9"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Suryo9"].RequestValue, formInfo["Suryo9"]);
			paramCol["Suryo10"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Suryo10"].RequestValue, formInfo["Suryo10"]);
			paramCol["Suryo11"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Suryo11"].RequestValue, formInfo["Suryo11"]);
			paramCol["Suryo12"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Suryo12"].RequestValue, formInfo["Suryo12"]);
			paramCol["Suryo13"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Suryo13"].RequestValue, formInfo["Suryo13"]);
			paramCol["Suryo14"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Suryo14"].RequestValue, formInfo["Suryo14"]);
			paramCol["Suryo15"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Suryo15"].RequestValue, formInfo["Suryo15"]);
			paramCol["Suryo16"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Suryo16"].RequestValue, formInfo["Suryo16"]);
			paramCol["Suryo17"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Suryo17"].RequestValue, formInfo["Suryo17"]);
			paramCol["Suryo18"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Suryo18"].RequestValue, formInfo["Suryo18"]);
			paramCol["Suryo19"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Suryo19"].RequestValue, formInfo["Suryo19"]);
			paramCol["Suryo20"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Suryo20"].RequestValue, formInfo["Suryo20"]);
			paramCol["Suryo21"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Suryo21"].RequestValue, formInfo["Suryo21"]);
			paramCol["Suryo22"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Suryo22"].RequestValue, formInfo["Suryo22"]);
			paramCol["Suryo23"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Suryo23"].RequestValue, formInfo["Suryo23"]);
			paramCol["Suryo24"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Suryo24"].RequestValue, formInfo["Suryo24"]);
			paramCol["Suryo25"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Suryo25"].RequestValue, formInfo["Suryo25"]);
			paramCol["Suryo26"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Suryo26"].RequestValue, formInfo["Suryo26"]);
			paramCol["Suryo27"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Suryo27"].RequestValue, formInfo["Suryo27"]);
			paramCol["Suryo28"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Suryo28"].RequestValue, formInfo["Suryo28"]);
			paramCol["Suryo29"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Suryo29"].RequestValue, formInfo["Suryo29"]);
			paramCol["Suryo30"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Suryo30"].RequestValue, formInfo["Suryo30"]);
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
				paramCol["M1gokei_suryo"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1gokei_suryo"][i].RequestValue, formInfo["M1gokei_suryo"]);
				paramCol["M1syoka_rtu"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1syoka_rtu"][i].RequestValue, formInfo["M1syoka_rtu"]);
				paramCol["M1suryo1"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1suryo1"][i].RequestValue, formInfo["M1suryo1"]);
				paramCol["M1suryo2"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1suryo2"][i].RequestValue, formInfo["M1suryo2"]);
				paramCol["M1suryo3"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1suryo3"][i].RequestValue, formInfo["M1suryo3"]);
				paramCol["M1suryo4"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1suryo4"][i].RequestValue, formInfo["M1suryo4"]);
				paramCol["M1suryo5"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1suryo5"][i].RequestValue, formInfo["M1suryo5"]);
				paramCol["M1suryo6"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1suryo6"][i].RequestValue, formInfo["M1suryo6"]);
				paramCol["M1suryo7"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1suryo7"][i].RequestValue, formInfo["M1suryo7"]);
				paramCol["M1suryo8"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1suryo8"][i].RequestValue, formInfo["M1suryo8"]);
				paramCol["M1suryo9"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1suryo9"][i].RequestValue, formInfo["M1suryo9"]);
				paramCol["M1suryo10"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1suryo10"][i].RequestValue, formInfo["M1suryo10"]);
				paramCol["M1suryo11"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1suryo11"][i].RequestValue, formInfo["M1suryo11"]);
				paramCol["M1suryo12"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1suryo12"][i].RequestValue, formInfo["M1suryo12"]);
				paramCol["M1suryo13"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1suryo13"][i].RequestValue, formInfo["M1suryo13"]);
				paramCol["M1suryo14"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1suryo14"][i].RequestValue, formInfo["M1suryo14"]);
				paramCol["M1suryo15"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1suryo15"][i].RequestValue, formInfo["M1suryo15"]);
				paramCol["M1suryo16"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1suryo16"][i].RequestValue, formInfo["M1suryo16"]);
				paramCol["M1suryo17"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1suryo17"][i].RequestValue, formInfo["M1suryo17"]);
				paramCol["M1suryo18"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1suryo18"][i].RequestValue, formInfo["M1suryo18"]);
				paramCol["M1suryo19"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1suryo19"][i].RequestValue, formInfo["M1suryo19"]);
				paramCol["M1suryo20"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1suryo20"][i].RequestValue, formInfo["M1suryo20"]);
				paramCol["M1suryo21"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1suryo21"][i].RequestValue, formInfo["M1suryo21"]);
				paramCol["M1suryo22"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1suryo22"][i].RequestValue, formInfo["M1suryo22"]);
				paramCol["M1suryo23"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1suryo23"][i].RequestValue, formInfo["M1suryo23"]);
				paramCol["M1suryo24"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1suryo24"][i].RequestValue, formInfo["M1suryo24"]);
				paramCol["M1suryo25"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1suryo25"][i].RequestValue, formInfo["M1suryo25"]);
				paramCol["M1suryo26"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1suryo26"][i].RequestValue, formInfo["M1suryo26"]);
				paramCol["M1suryo27"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1suryo27"][i].RequestValue, formInfo["M1suryo27"]);
				paramCol["M1suryo28"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1suryo28"][i].RequestValue, formInfo["M1suryo28"]);
				paramCol["M1suryo29"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1suryo29"][i].RequestValue, formInfo["M1suryo29"]);
				paramCol["M1suryo30"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1suryo30"][i].RequestValue, formInfo["M1suryo30"]);
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
			Th020f02Form formVO = (Th020f02Form)pageContext.GetFormVO();

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
			if (paramCol["Zentenzaiko_su"].UnformatValue != null)
			{
				formVO.Zentenzaiko_su = paramCol["Zentenzaiko_su"].UnformatValue;
			}
			if (paramCol["Zentensyoka_rtu"].UnformatValue != null)
			{
				formVO.Zentensyoka_rtu = paramCol["Zentensyoka_rtu"].UnformatValue;
			}
			if (paramCol["Tenpo_nm"].UnformatValue != null)
			{
				formVO.Tenpo_nm = paramCol["Tenpo_nm"].UnformatValue;
			}
			if (paramCol["Tenpo_cd"].UnformatValue != null)
			{
				formVO.Tenpo_cd = paramCol["Tenpo_cd"].UnformatValue;
			}
			if (paramCol["All_gokei_suryo"].UnformatValue != null)
			{
				formVO.All_gokei_suryo = paramCol["All_gokei_suryo"].UnformatValue;
			}
			if (paramCol["Suryo1"].UnformatValue != null)
			{
				formVO.Suryo1 = paramCol["Suryo1"].UnformatValue;
			}
			if (paramCol["Suryo2"].UnformatValue != null)
			{
				formVO.Suryo2 = paramCol["Suryo2"].UnformatValue;
			}
			if (paramCol["Suryo3"].UnformatValue != null)
			{
				formVO.Suryo3 = paramCol["Suryo3"].UnformatValue;
			}
			if (paramCol["Suryo4"].UnformatValue != null)
			{
				formVO.Suryo4 = paramCol["Suryo4"].UnformatValue;
			}
			if (paramCol["Suryo5"].UnformatValue != null)
			{
				formVO.Suryo5 = paramCol["Suryo5"].UnformatValue;
			}
			if (paramCol["Suryo6"].UnformatValue != null)
			{
				formVO.Suryo6 = paramCol["Suryo6"].UnformatValue;
			}
			if (paramCol["Suryo7"].UnformatValue != null)
			{
				formVO.Suryo7 = paramCol["Suryo7"].UnformatValue;
			}
			if (paramCol["Suryo8"].UnformatValue != null)
			{
				formVO.Suryo8 = paramCol["Suryo8"].UnformatValue;
			}
			if (paramCol["Suryo9"].UnformatValue != null)
			{
				formVO.Suryo9 = paramCol["Suryo9"].UnformatValue;
			}
			if (paramCol["Suryo10"].UnformatValue != null)
			{
				formVO.Suryo10 = paramCol["Suryo10"].UnformatValue;
			}
			if (paramCol["Suryo11"].UnformatValue != null)
			{
				formVO.Suryo11 = paramCol["Suryo11"].UnformatValue;
			}
			if (paramCol["Suryo12"].UnformatValue != null)
			{
				formVO.Suryo12 = paramCol["Suryo12"].UnformatValue;
			}
			if (paramCol["Suryo13"].UnformatValue != null)
			{
				formVO.Suryo13 = paramCol["Suryo13"].UnformatValue;
			}
			if (paramCol["Suryo14"].UnformatValue != null)
			{
				formVO.Suryo14 = paramCol["Suryo14"].UnformatValue;
			}
			if (paramCol["Suryo15"].UnformatValue != null)
			{
				formVO.Suryo15 = paramCol["Suryo15"].UnformatValue;
			}
			if (paramCol["Suryo16"].UnformatValue != null)
			{
				formVO.Suryo16 = paramCol["Suryo16"].UnformatValue;
			}
			if (paramCol["Suryo17"].UnformatValue != null)
			{
				formVO.Suryo17 = paramCol["Suryo17"].UnformatValue;
			}
			if (paramCol["Suryo18"].UnformatValue != null)
			{
				formVO.Suryo18 = paramCol["Suryo18"].UnformatValue;
			}
			if (paramCol["Suryo19"].UnformatValue != null)
			{
				formVO.Suryo19 = paramCol["Suryo19"].UnformatValue;
			}
			if (paramCol["Suryo20"].UnformatValue != null)
			{
				formVO.Suryo20 = paramCol["Suryo20"].UnformatValue;
			}
			if (paramCol["Suryo21"].UnformatValue != null)
			{
				formVO.Suryo21 = paramCol["Suryo21"].UnformatValue;
			}
			if (paramCol["Suryo22"].UnformatValue != null)
			{
				formVO.Suryo22 = paramCol["Suryo22"].UnformatValue;
			}
			if (paramCol["Suryo23"].UnformatValue != null)
			{
				formVO.Suryo23 = paramCol["Suryo23"].UnformatValue;
			}
			if (paramCol["Suryo24"].UnformatValue != null)
			{
				formVO.Suryo24 = paramCol["Suryo24"].UnformatValue;
			}
			if (paramCol["Suryo25"].UnformatValue != null)
			{
				formVO.Suryo25 = paramCol["Suryo25"].UnformatValue;
			}
			if (paramCol["Suryo26"].UnformatValue != null)
			{
				formVO.Suryo26 = paramCol["Suryo26"].UnformatValue;
			}
			if (paramCol["Suryo27"].UnformatValue != null)
			{
				formVO.Suryo27 = paramCol["Suryo27"].UnformatValue;
			}
			if (paramCol["Suryo28"].UnformatValue != null)
			{
				formVO.Suryo28 = paramCol["Suryo28"].UnformatValue;
			}
			if (paramCol["Suryo29"].UnformatValue != null)
			{
				formVO.Suryo29 = paramCol["Suryo29"].UnformatValue;
			}
			if (paramCol["Suryo30"].UnformatValue != null)
			{
				formVO.Suryo30 = paramCol["Suryo30"].UnformatValue;
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
				Th020f02M1Form th020f02M1Form = (Th020f02M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					th020f02M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1tenpo_cd"][i].UnformatValue != null)
				{
					th020f02M1Form.M1tenpo_cd = paramCol["M1tenpo_cd"][i].UnformatValue;
				}
				if (paramCol["M1tenpo_nm"][i].UnformatValue != null)
				{
					th020f02M1Form.M1tenpo_nm = paramCol["M1tenpo_nm"][i].UnformatValue;
				}
				if (paramCol["M1gokei_suryo"][i].UnformatValue != null)
				{
					th020f02M1Form.M1gokei_suryo = paramCol["M1gokei_suryo"][i].UnformatValue;
				}
				if (paramCol["M1syoka_rtu"][i].UnformatValue != null)
				{
					th020f02M1Form.M1syoka_rtu = paramCol["M1syoka_rtu"][i].UnformatValue;
				}
				if (paramCol["M1suryo1"][i].UnformatValue != null)
				{
					th020f02M1Form.M1suryo1 = paramCol["M1suryo1"][i].UnformatValue;
				}
				if (paramCol["M1suryo2"][i].UnformatValue != null)
				{
					th020f02M1Form.M1suryo2 = paramCol["M1suryo2"][i].UnformatValue;
				}
				if (paramCol["M1suryo3"][i].UnformatValue != null)
				{
					th020f02M1Form.M1suryo3 = paramCol["M1suryo3"][i].UnformatValue;
				}
				if (paramCol["M1suryo4"][i].UnformatValue != null)
				{
					th020f02M1Form.M1suryo4 = paramCol["M1suryo4"][i].UnformatValue;
				}
				if (paramCol["M1suryo5"][i].UnformatValue != null)
				{
					th020f02M1Form.M1suryo5 = paramCol["M1suryo5"][i].UnformatValue;
				}
				if (paramCol["M1suryo6"][i].UnformatValue != null)
				{
					th020f02M1Form.M1suryo6 = paramCol["M1suryo6"][i].UnformatValue;
				}
				if (paramCol["M1suryo7"][i].UnformatValue != null)
				{
					th020f02M1Form.M1suryo7 = paramCol["M1suryo7"][i].UnformatValue;
				}
				if (paramCol["M1suryo8"][i].UnformatValue != null)
				{
					th020f02M1Form.M1suryo8 = paramCol["M1suryo8"][i].UnformatValue;
				}
				if (paramCol["M1suryo9"][i].UnformatValue != null)
				{
					th020f02M1Form.M1suryo9 = paramCol["M1suryo9"][i].UnformatValue;
				}
				if (paramCol["M1suryo10"][i].UnformatValue != null)
				{
					th020f02M1Form.M1suryo10 = paramCol["M1suryo10"][i].UnformatValue;
				}
				if (paramCol["M1suryo11"][i].UnformatValue != null)
				{
					th020f02M1Form.M1suryo11 = paramCol["M1suryo11"][i].UnformatValue;
				}
				if (paramCol["M1suryo12"][i].UnformatValue != null)
				{
					th020f02M1Form.M1suryo12 = paramCol["M1suryo12"][i].UnformatValue;
				}
				if (paramCol["M1suryo13"][i].UnformatValue != null)
				{
					th020f02M1Form.M1suryo13 = paramCol["M1suryo13"][i].UnformatValue;
				}
				if (paramCol["M1suryo14"][i].UnformatValue != null)
				{
					th020f02M1Form.M1suryo14 = paramCol["M1suryo14"][i].UnformatValue;
				}
				if (paramCol["M1suryo15"][i].UnformatValue != null)
				{
					th020f02M1Form.M1suryo15 = paramCol["M1suryo15"][i].UnformatValue;
				}
				if (paramCol["M1suryo16"][i].UnformatValue != null)
				{
					th020f02M1Form.M1suryo16 = paramCol["M1suryo16"][i].UnformatValue;
				}
				if (paramCol["M1suryo17"][i].UnformatValue != null)
				{
					th020f02M1Form.M1suryo17 = paramCol["M1suryo17"][i].UnformatValue;
				}
				if (paramCol["M1suryo18"][i].UnformatValue != null)
				{
					th020f02M1Form.M1suryo18 = paramCol["M1suryo18"][i].UnformatValue;
				}
				if (paramCol["M1suryo19"][i].UnformatValue != null)
				{
					th020f02M1Form.M1suryo19 = paramCol["M1suryo19"][i].UnformatValue;
				}
				if (paramCol["M1suryo20"][i].UnformatValue != null)
				{
					th020f02M1Form.M1suryo20 = paramCol["M1suryo20"][i].UnformatValue;
				}
				if (paramCol["M1suryo21"][i].UnformatValue != null)
				{
					th020f02M1Form.M1suryo21 = paramCol["M1suryo21"][i].UnformatValue;
				}
				if (paramCol["M1suryo22"][i].UnformatValue != null)
				{
					th020f02M1Form.M1suryo22 = paramCol["M1suryo22"][i].UnformatValue;
				}
				if (paramCol["M1suryo23"][i].UnformatValue != null)
				{
					th020f02M1Form.M1suryo23 = paramCol["M1suryo23"][i].UnformatValue;
				}
				if (paramCol["M1suryo24"][i].UnformatValue != null)
				{
					th020f02M1Form.M1suryo24 = paramCol["M1suryo24"][i].UnformatValue;
				}
				if (paramCol["M1suryo25"][i].UnformatValue != null)
				{
					th020f02M1Form.M1suryo25 = paramCol["M1suryo25"][i].UnformatValue;
				}
				if (paramCol["M1suryo26"][i].UnformatValue != null)
				{
					th020f02M1Form.M1suryo26 = paramCol["M1suryo26"][i].UnformatValue;
				}
				if (paramCol["M1suryo27"][i].UnformatValue != null)
				{
					th020f02M1Form.M1suryo27 = paramCol["M1suryo27"][i].UnformatValue;
				}
				if (paramCol["M1suryo28"][i].UnformatValue != null)
				{
					th020f02M1Form.M1suryo28 = paramCol["M1suryo28"][i].UnformatValue;
				}
				if (paramCol["M1suryo29"][i].UnformatValue != null)
				{
					th020f02M1Form.M1suryo29 = paramCol["M1suryo29"][i].UnformatValue;
				}
				if (paramCol["M1suryo30"][i].UnformatValue != null)
				{
					th020f02M1Form.M1suryo30 = paramCol["M1suryo30"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					th020f02M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					th020f02M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					th020f02M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Th020f02Form formVO, StandardCheckManager checker)
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
			if (formVO.Zentenzaiko_su != null)
			{
				checker.DoCheck("Zentenzaiko_su", formVO.Zentenzaiko_su);
			}
			if (formVO.Zentensyoka_rtu != null)
			{
				checker.DoCheck("Zentensyoka_rtu", formVO.Zentensyoka_rtu);
			}
			if (formVO.Tenpo_nm != null)
			{
				checker.DoCheck("Tenpo_nm", formVO.Tenpo_nm);
			}
			if (formVO.Tenpo_cd != null)
			{
				checker.DoCheck("Tenpo_cd", formVO.Tenpo_cd);
			}
			if (formVO.All_gokei_suryo != null)
			{
				checker.DoCheck("All_gokei_suryo", formVO.All_gokei_suryo);
			}
			if (formVO.Suryo1 != null)
			{
				checker.DoCheck("Suryo1", formVO.Suryo1);
			}
			if (formVO.Suryo2 != null)
			{
				checker.DoCheck("Suryo2", formVO.Suryo2);
			}
			if (formVO.Suryo3 != null)
			{
				checker.DoCheck("Suryo3", formVO.Suryo3);
			}
			if (formVO.Suryo4 != null)
			{
				checker.DoCheck("Suryo4", formVO.Suryo4);
			}
			if (formVO.Suryo5 != null)
			{
				checker.DoCheck("Suryo5", formVO.Suryo5);
			}
			if (formVO.Suryo6 != null)
			{
				checker.DoCheck("Suryo6", formVO.Suryo6);
			}
			if (formVO.Suryo7 != null)
			{
				checker.DoCheck("Suryo7", formVO.Suryo7);
			}
			if (formVO.Suryo8 != null)
			{
				checker.DoCheck("Suryo8", formVO.Suryo8);
			}
			if (formVO.Suryo9 != null)
			{
				checker.DoCheck("Suryo9", formVO.Suryo9);
			}
			if (formVO.Suryo10 != null)
			{
				checker.DoCheck("Suryo10", formVO.Suryo10);
			}
			if (formVO.Suryo11 != null)
			{
				checker.DoCheck("Suryo11", formVO.Suryo11);
			}
			if (formVO.Suryo12 != null)
			{
				checker.DoCheck("Suryo12", formVO.Suryo12);
			}
			if (formVO.Suryo13 != null)
			{
				checker.DoCheck("Suryo13", formVO.Suryo13);
			}
			if (formVO.Suryo14 != null)
			{
				checker.DoCheck("Suryo14", formVO.Suryo14);
			}
			if (formVO.Suryo15 != null)
			{
				checker.DoCheck("Suryo15", formVO.Suryo15);
			}
			if (formVO.Suryo16 != null)
			{
				checker.DoCheck("Suryo16", formVO.Suryo16);
			}
			if (formVO.Suryo17 != null)
			{
				checker.DoCheck("Suryo17", formVO.Suryo17);
			}
			if (formVO.Suryo18 != null)
			{
				checker.DoCheck("Suryo18", formVO.Suryo18);
			}
			if (formVO.Suryo19 != null)
			{
				checker.DoCheck("Suryo19", formVO.Suryo19);
			}
			if (formVO.Suryo20 != null)
			{
				checker.DoCheck("Suryo20", formVO.Suryo20);
			}
			if (formVO.Suryo21 != null)
			{
				checker.DoCheck("Suryo21", formVO.Suryo21);
			}
			if (formVO.Suryo22 != null)
			{
				checker.DoCheck("Suryo22", formVO.Suryo22);
			}
			if (formVO.Suryo23 != null)
			{
				checker.DoCheck("Suryo23", formVO.Suryo23);
			}
			if (formVO.Suryo24 != null)
			{
				checker.DoCheck("Suryo24", formVO.Suryo24);
			}
			if (formVO.Suryo25 != null)
			{
				checker.DoCheck("Suryo25", formVO.Suryo25);
			}
			if (formVO.Suryo26 != null)
			{
				checker.DoCheck("Suryo26", formVO.Suryo26);
			}
			if (formVO.Suryo27 != null)
			{
				checker.DoCheck("Suryo27", formVO.Suryo27);
			}
			if (formVO.Suryo28 != null)
			{
				checker.DoCheck("Suryo28", formVO.Suryo28);
			}
			if (formVO.Suryo29 != null)
			{
				checker.DoCheck("Suryo29", formVO.Suryo29);
			}
			if (formVO.Suryo30 != null)
			{
				checker.DoCheck("Suryo30", formVO.Suryo30);
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
		public static void ValidateM1InputValue(Th020f02Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Th020f02M1Form th020f02M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, th020f02M1Form, i, m1List);
				if (th020f02M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", th020f02M1Form.M1rowno, i, m1List);
				}
				if (th020f02M1Form.M1tenpo_cd != null)
				{
					checker.DoCheck("M1tenpo_cd", th020f02M1Form.M1tenpo_cd, i, m1List);
				}
				if (th020f02M1Form.M1tenpo_nm != null)
				{
					checker.DoCheck("M1tenpo_nm", th020f02M1Form.M1tenpo_nm, i, m1List);
				}
				if (th020f02M1Form.M1gokei_suryo != null)
				{
					checker.DoCheck("M1gokei_suryo", th020f02M1Form.M1gokei_suryo, i, m1List);
				}
				if (th020f02M1Form.M1syoka_rtu != null)
				{
					checker.DoCheck("M1syoka_rtu", th020f02M1Form.M1syoka_rtu, i, m1List);
				}
				if (th020f02M1Form.M1suryo1 != null)
				{
					checker.DoCheck("M1suryo1", th020f02M1Form.M1suryo1, i, m1List);
				}
				if (th020f02M1Form.M1suryo2 != null)
				{
					checker.DoCheck("M1suryo2", th020f02M1Form.M1suryo2, i, m1List);
				}
				if (th020f02M1Form.M1suryo3 != null)
				{
					checker.DoCheck("M1suryo3", th020f02M1Form.M1suryo3, i, m1List);
				}
				if (th020f02M1Form.M1suryo4 != null)
				{
					checker.DoCheck("M1suryo4", th020f02M1Form.M1suryo4, i, m1List);
				}
				if (th020f02M1Form.M1suryo5 != null)
				{
					checker.DoCheck("M1suryo5", th020f02M1Form.M1suryo5, i, m1List);
				}
				if (th020f02M1Form.M1suryo6 != null)
				{
					checker.DoCheck("M1suryo6", th020f02M1Form.M1suryo6, i, m1List);
				}
				if (th020f02M1Form.M1suryo7 != null)
				{
					checker.DoCheck("M1suryo7", th020f02M1Form.M1suryo7, i, m1List);
				}
				if (th020f02M1Form.M1suryo8 != null)
				{
					checker.DoCheck("M1suryo8", th020f02M1Form.M1suryo8, i, m1List);
				}
				if (th020f02M1Form.M1suryo9 != null)
				{
					checker.DoCheck("M1suryo9", th020f02M1Form.M1suryo9, i, m1List);
				}
				if (th020f02M1Form.M1suryo10 != null)
				{
					checker.DoCheck("M1suryo10", th020f02M1Form.M1suryo10, i, m1List);
				}
				if (th020f02M1Form.M1suryo11 != null)
				{
					checker.DoCheck("M1suryo11", th020f02M1Form.M1suryo11, i, m1List);
				}
				if (th020f02M1Form.M1suryo12 != null)
				{
					checker.DoCheck("M1suryo12", th020f02M1Form.M1suryo12, i, m1List);
				}
				if (th020f02M1Form.M1suryo13 != null)
				{
					checker.DoCheck("M1suryo13", th020f02M1Form.M1suryo13, i, m1List);
				}
				if (th020f02M1Form.M1suryo14 != null)
				{
					checker.DoCheck("M1suryo14", th020f02M1Form.M1suryo14, i, m1List);
				}
				if (th020f02M1Form.M1suryo15 != null)
				{
					checker.DoCheck("M1suryo15", th020f02M1Form.M1suryo15, i, m1List);
				}
				if (th020f02M1Form.M1suryo16 != null)
				{
					checker.DoCheck("M1suryo16", th020f02M1Form.M1suryo16, i, m1List);
				}
				if (th020f02M1Form.M1suryo17 != null)
				{
					checker.DoCheck("M1suryo17", th020f02M1Form.M1suryo17, i, m1List);
				}
				if (th020f02M1Form.M1suryo18 != null)
				{
					checker.DoCheck("M1suryo18", th020f02M1Form.M1suryo18, i, m1List);
				}
				if (th020f02M1Form.M1suryo19 != null)
				{
					checker.DoCheck("M1suryo19", th020f02M1Form.M1suryo19, i, m1List);
				}
				if (th020f02M1Form.M1suryo20 != null)
				{
					checker.DoCheck("M1suryo20", th020f02M1Form.M1suryo20, i, m1List);
				}
				if (th020f02M1Form.M1suryo21 != null)
				{
					checker.DoCheck("M1suryo21", th020f02M1Form.M1suryo21, i, m1List);
				}
				if (th020f02M1Form.M1suryo22 != null)
				{
					checker.DoCheck("M1suryo22", th020f02M1Form.M1suryo22, i, m1List);
				}
				if (th020f02M1Form.M1suryo23 != null)
				{
					checker.DoCheck("M1suryo23", th020f02M1Form.M1suryo23, i, m1List);
				}
				if (th020f02M1Form.M1suryo24 != null)
				{
					checker.DoCheck("M1suryo24", th020f02M1Form.M1suryo24, i, m1List);
				}
				if (th020f02M1Form.M1suryo25 != null)
				{
					checker.DoCheck("M1suryo25", th020f02M1Form.M1suryo25, i, m1List);
				}
				if (th020f02M1Form.M1suryo26 != null)
				{
					checker.DoCheck("M1suryo26", th020f02M1Form.M1suryo26, i, m1List);
				}
				if (th020f02M1Form.M1suryo27 != null)
				{
					checker.DoCheck("M1suryo27", th020f02M1Form.M1suryo27, i, m1List);
				}
				if (th020f02M1Form.M1suryo28 != null)
				{
					checker.DoCheck("M1suryo28", th020f02M1Form.M1suryo28, i, m1List);
				}
				if (th020f02M1Form.M1suryo29 != null)
				{
					checker.DoCheck("M1suryo29", th020f02M1Form.M1suryo29, i, m1List);
				}
				if (th020f02M1Form.M1suryo30 != null)
				{
					checker.DoCheck("M1suryo30", th020f02M1Form.M1suryo30, i, m1List);
				}
				if (th020f02M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", th020f02M1Form.M1selectorcheckbox, i, m1List);
				}
				if (th020f02M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", th020f02M1Form.M1entersyoriflg, i, m1List);
				}
				if (th020f02M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", th020f02M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Th020f02Form formVO, StandardCodeCheckManager checker)
		{
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Th020f02Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

