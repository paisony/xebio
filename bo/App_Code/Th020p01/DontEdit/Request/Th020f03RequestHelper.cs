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
  /// Th020f03RequestHelper の概要の説明です。
  /// </summary>
  public static class Th020f03RequestHelper
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
			Th020f03Form formVO = (Th020f03Form)pageContext.GetFormVO();

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
			paramCol["Meisaihead_iro_nm1"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Meisaihead_iro_nm1"]);
			paramCol["Meisaihead_iro_nm2"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Meisaihead_iro_nm2"]);
			paramCol["Meisaihead_iro_nm3"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Meisaihead_iro_nm3"]);
			paramCol["Meisaihead_iro_nm4"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Meisaihead_iro_nm4"]);
			paramCol["Meisaihead_iro_nm5"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Meisaihead_iro_nm5"]);
			paramCol["Meisaihead_iro_nm6"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Meisaihead_iro_nm6"]);
			paramCol["Meisaihead_iro_nm7"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Meisaihead_iro_nm7"]);
			paramCol["Meisaihead_iro_nm8"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Meisaihead_iro_nm8"]);
			paramCol["Meisaihead_iro_nm9"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Meisaihead_iro_nm9"]);
			paramCol["Meisaihead_iro_nm10"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Meisaihead_iro_nm10"]);
			paramCol["Meisaihead_iro_nm11"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Meisaihead_iro_nm11"]);
			paramCol["Meisaihead_iro_nm12"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Meisaihead_iro_nm12"]);
			paramCol["Meisaihead_iro_nm13"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Meisaihead_iro_nm13"]);
			paramCol["Meisaihead_iro_nm14"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Meisaihead_iro_nm14"]);
			paramCol["Meisaihead_iro_nm15"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Meisaihead_iro_nm15"]);
			paramCol["Meisaihead_iro_nm16"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Meisaihead_iro_nm16"]);
			paramCol["Meisaihead_iro_nm17"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Meisaihead_iro_nm17"]);
			paramCol["Meisaihead_iro_nm18"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Meisaihead_iro_nm18"]);
			paramCol["Meisaihead_iro_nm19"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Meisaihead_iro_nm19"]);
			paramCol["Meisaihead_iro_nm20"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Meisaihead_iro_nm20"]);
			paramCol["Meisaihead_iro_nm21"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Meisaihead_iro_nm21"]);
			paramCol["Meisaihead_iro_nm22"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Meisaihead_iro_nm22"]);
			paramCol["Meisaihead_iro_nm23"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Meisaihead_iro_nm23"]);
			paramCol["Meisaihead_iro_nm24"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Meisaihead_iro_nm24"]);
			paramCol["Meisaihead_iro_nm25"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Meisaihead_iro_nm25"]);
			paramCol["Meisaihead_iro_nm26"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Meisaihead_iro_nm26"]);
			paramCol["Meisaihead_iro_nm27"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Meisaihead_iro_nm27"]);
			paramCol["Meisaihead_iro_nm28"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Meisaihead_iro_nm28"]);
			paramCol["Meisaihead_iro_nm29"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Meisaihead_iro_nm29"]);
			paramCol["Meisaihead_iro_nm30"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Meisaihead_iro_nm30"]);
			paramCol["Tenpo_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tenpo_nm"]);
			paramCol["Tenpo_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Tenpo_cd"]);
			paramCol["All_gokei_suryo"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["All_gokei_suryo"]);
			paramCol["Gokei_suryo1"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokei_suryo1"]);
			paramCol["Gokei_suryo2"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokei_suryo2"]);
			paramCol["Gokei_suryo3"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokei_suryo3"]);
			paramCol["Gokei_suryo4"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokei_suryo4"]);
			paramCol["Gokei_suryo5"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokei_suryo5"]);
			paramCol["Gokei_suryo6"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokei_suryo6"]);
			paramCol["Gokei_suryo7"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokei_suryo7"]);
			paramCol["Gokei_suryo8"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokei_suryo8"]);
			paramCol["Gokei_suryo9"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokei_suryo9"]);
			paramCol["Gokei_suryo10"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokei_suryo10"]);
			paramCol["Gokei_suryo11"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokei_suryo11"]);
			paramCol["Gokei_suryo12"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokei_suryo12"]);
			paramCol["Gokei_suryo13"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokei_suryo13"]);
			paramCol["Gokei_suryo14"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokei_suryo14"]);
			paramCol["Gokei_suryo15"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokei_suryo15"]);
			paramCol["Gokei_suryo16"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokei_suryo16"]);
			paramCol["Gokei_suryo17"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokei_suryo17"]);
			paramCol["Gokei_suryo18"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokei_suryo18"]);
			paramCol["Gokei_suryo19"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokei_suryo19"]);
			paramCol["Gokei_suryo20"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokei_suryo20"]);
			paramCol["Gokei_suryo21"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokei_suryo21"]);
			paramCol["Gokei_suryo22"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokei_suryo22"]);
			paramCol["Gokei_suryo23"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokei_suryo23"]);
			paramCol["Gokei_suryo24"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokei_suryo24"]);
			paramCol["Gokei_suryo25"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokei_suryo25"]);
			paramCol["Gokei_suryo26"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokei_suryo26"]);
			paramCol["Gokei_suryo27"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokei_suryo27"]);
			paramCol["Gokei_suryo28"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokei_suryo28"]);
			paramCol["Gokei_suryo29"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokei_suryo29"]);
			paramCol["Gokei_suryo30"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Gokei_suryo30"]);
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
				paramCol["M1area_cd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1area_cd"]);
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
			Th020f03Form formVO = (Th020f03Form)pageContext.GetFormVO();

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
			paramCol["Meisaihead_iro_nm1"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Meisaihead_iro_nm1"].RequestValue, formInfo["Meisaihead_iro_nm1"]);
			paramCol["Meisaihead_iro_nm2"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Meisaihead_iro_nm2"].RequestValue, formInfo["Meisaihead_iro_nm2"]);
			paramCol["Meisaihead_iro_nm3"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Meisaihead_iro_nm3"].RequestValue, formInfo["Meisaihead_iro_nm3"]);
			paramCol["Meisaihead_iro_nm4"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Meisaihead_iro_nm4"].RequestValue, formInfo["Meisaihead_iro_nm4"]);
			paramCol["Meisaihead_iro_nm5"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Meisaihead_iro_nm5"].RequestValue, formInfo["Meisaihead_iro_nm5"]);
			paramCol["Meisaihead_iro_nm6"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Meisaihead_iro_nm6"].RequestValue, formInfo["Meisaihead_iro_nm6"]);
			paramCol["Meisaihead_iro_nm7"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Meisaihead_iro_nm7"].RequestValue, formInfo["Meisaihead_iro_nm7"]);
			paramCol["Meisaihead_iro_nm8"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Meisaihead_iro_nm8"].RequestValue, formInfo["Meisaihead_iro_nm8"]);
			paramCol["Meisaihead_iro_nm9"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Meisaihead_iro_nm9"].RequestValue, formInfo["Meisaihead_iro_nm9"]);
			paramCol["Meisaihead_iro_nm10"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Meisaihead_iro_nm10"].RequestValue, formInfo["Meisaihead_iro_nm10"]);
			paramCol["Meisaihead_iro_nm11"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Meisaihead_iro_nm11"].RequestValue, formInfo["Meisaihead_iro_nm11"]);
			paramCol["Meisaihead_iro_nm12"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Meisaihead_iro_nm12"].RequestValue, formInfo["Meisaihead_iro_nm12"]);
			paramCol["Meisaihead_iro_nm13"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Meisaihead_iro_nm13"].RequestValue, formInfo["Meisaihead_iro_nm13"]);
			paramCol["Meisaihead_iro_nm14"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Meisaihead_iro_nm14"].RequestValue, formInfo["Meisaihead_iro_nm14"]);
			paramCol["Meisaihead_iro_nm15"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Meisaihead_iro_nm15"].RequestValue, formInfo["Meisaihead_iro_nm15"]);
			paramCol["Meisaihead_iro_nm16"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Meisaihead_iro_nm16"].RequestValue, formInfo["Meisaihead_iro_nm16"]);
			paramCol["Meisaihead_iro_nm17"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Meisaihead_iro_nm17"].RequestValue, formInfo["Meisaihead_iro_nm17"]);
			paramCol["Meisaihead_iro_nm18"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Meisaihead_iro_nm18"].RequestValue, formInfo["Meisaihead_iro_nm18"]);
			paramCol["Meisaihead_iro_nm19"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Meisaihead_iro_nm19"].RequestValue, formInfo["Meisaihead_iro_nm19"]);
			paramCol["Meisaihead_iro_nm20"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Meisaihead_iro_nm20"].RequestValue, formInfo["Meisaihead_iro_nm20"]);
			paramCol["Meisaihead_iro_nm21"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Meisaihead_iro_nm21"].RequestValue, formInfo["Meisaihead_iro_nm21"]);
			paramCol["Meisaihead_iro_nm22"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Meisaihead_iro_nm22"].RequestValue, formInfo["Meisaihead_iro_nm22"]);
			paramCol["Meisaihead_iro_nm23"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Meisaihead_iro_nm23"].RequestValue, formInfo["Meisaihead_iro_nm23"]);
			paramCol["Meisaihead_iro_nm24"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Meisaihead_iro_nm24"].RequestValue, formInfo["Meisaihead_iro_nm24"]);
			paramCol["Meisaihead_iro_nm25"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Meisaihead_iro_nm25"].RequestValue, formInfo["Meisaihead_iro_nm25"]);
			paramCol["Meisaihead_iro_nm26"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Meisaihead_iro_nm26"].RequestValue, formInfo["Meisaihead_iro_nm26"]);
			paramCol["Meisaihead_iro_nm27"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Meisaihead_iro_nm27"].RequestValue, formInfo["Meisaihead_iro_nm27"]);
			paramCol["Meisaihead_iro_nm28"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Meisaihead_iro_nm28"].RequestValue, formInfo["Meisaihead_iro_nm28"]);
			paramCol["Meisaihead_iro_nm29"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Meisaihead_iro_nm29"].RequestValue, formInfo["Meisaihead_iro_nm29"]);
			paramCol["Meisaihead_iro_nm30"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Meisaihead_iro_nm30"].RequestValue, formInfo["Meisaihead_iro_nm30"]);
			paramCol["Tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tenpo_nm"].RequestValue, formInfo["Tenpo_nm"]);
			paramCol["Tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Tenpo_cd"].RequestValue, formInfo["Tenpo_cd"]);
			paramCol["All_gokei_suryo"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["All_gokei_suryo"].RequestValue, formInfo["All_gokei_suryo"]);
			paramCol["Gokei_suryo1"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokei_suryo1"].RequestValue, formInfo["Gokei_suryo1"]);
			paramCol["Gokei_suryo2"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokei_suryo2"].RequestValue, formInfo["Gokei_suryo2"]);
			paramCol["Gokei_suryo3"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokei_suryo3"].RequestValue, formInfo["Gokei_suryo3"]);
			paramCol["Gokei_suryo4"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokei_suryo4"].RequestValue, formInfo["Gokei_suryo4"]);
			paramCol["Gokei_suryo5"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokei_suryo5"].RequestValue, formInfo["Gokei_suryo5"]);
			paramCol["Gokei_suryo6"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokei_suryo6"].RequestValue, formInfo["Gokei_suryo6"]);
			paramCol["Gokei_suryo7"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokei_suryo7"].RequestValue, formInfo["Gokei_suryo7"]);
			paramCol["Gokei_suryo8"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokei_suryo8"].RequestValue, formInfo["Gokei_suryo8"]);
			paramCol["Gokei_suryo9"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokei_suryo9"].RequestValue, formInfo["Gokei_suryo9"]);
			paramCol["Gokei_suryo10"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokei_suryo10"].RequestValue, formInfo["Gokei_suryo10"]);
			paramCol["Gokei_suryo11"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokei_suryo11"].RequestValue, formInfo["Gokei_suryo11"]);
			paramCol["Gokei_suryo12"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokei_suryo12"].RequestValue, formInfo["Gokei_suryo12"]);
			paramCol["Gokei_suryo13"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokei_suryo13"].RequestValue, formInfo["Gokei_suryo13"]);
			paramCol["Gokei_suryo14"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokei_suryo14"].RequestValue, formInfo["Gokei_suryo14"]);
			paramCol["Gokei_suryo15"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokei_suryo15"].RequestValue, formInfo["Gokei_suryo15"]);
			paramCol["Gokei_suryo16"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokei_suryo16"].RequestValue, formInfo["Gokei_suryo16"]);
			paramCol["Gokei_suryo17"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokei_suryo17"].RequestValue, formInfo["Gokei_suryo17"]);
			paramCol["Gokei_suryo18"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokei_suryo18"].RequestValue, formInfo["Gokei_suryo18"]);
			paramCol["Gokei_suryo19"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokei_suryo19"].RequestValue, formInfo["Gokei_suryo19"]);
			paramCol["Gokei_suryo20"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokei_suryo20"].RequestValue, formInfo["Gokei_suryo20"]);
			paramCol["Gokei_suryo21"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokei_suryo21"].RequestValue, formInfo["Gokei_suryo21"]);
			paramCol["Gokei_suryo22"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokei_suryo22"].RequestValue, formInfo["Gokei_suryo22"]);
			paramCol["Gokei_suryo23"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokei_suryo23"].RequestValue, formInfo["Gokei_suryo23"]);
			paramCol["Gokei_suryo24"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokei_suryo24"].RequestValue, formInfo["Gokei_suryo24"]);
			paramCol["Gokei_suryo25"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokei_suryo25"].RequestValue, formInfo["Gokei_suryo25"]);
			paramCol["Gokei_suryo26"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokei_suryo26"].RequestValue, formInfo["Gokei_suryo26"]);
			paramCol["Gokei_suryo27"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokei_suryo27"].RequestValue, formInfo["Gokei_suryo27"]);
			paramCol["Gokei_suryo28"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokei_suryo28"].RequestValue, formInfo["Gokei_suryo28"]);
			paramCol["Gokei_suryo29"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokei_suryo29"].RequestValue, formInfo["Gokei_suryo29"]);
			paramCol["Gokei_suryo30"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Gokei_suryo30"].RequestValue, formInfo["Gokei_suryo30"]);
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
				paramCol["M1area_cd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1area_cd"][i].RequestValue, formInfo["M1area_cd"]);
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
			Th020f03Form formVO = (Th020f03Form)pageContext.GetFormVO();

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
			if (paramCol["Meisaihead_iro_nm1"].UnformatValue != null)
			{
				formVO.Meisaihead_iro_nm1 = paramCol["Meisaihead_iro_nm1"].UnformatValue;
			}
			if (paramCol["Meisaihead_iro_nm2"].UnformatValue != null)
			{
				formVO.Meisaihead_iro_nm2 = paramCol["Meisaihead_iro_nm2"].UnformatValue;
			}
			if (paramCol["Meisaihead_iro_nm3"].UnformatValue != null)
			{
				formVO.Meisaihead_iro_nm3 = paramCol["Meisaihead_iro_nm3"].UnformatValue;
			}
			if (paramCol["Meisaihead_iro_nm4"].UnformatValue != null)
			{
				formVO.Meisaihead_iro_nm4 = paramCol["Meisaihead_iro_nm4"].UnformatValue;
			}
			if (paramCol["Meisaihead_iro_nm5"].UnformatValue != null)
			{
				formVO.Meisaihead_iro_nm5 = paramCol["Meisaihead_iro_nm5"].UnformatValue;
			}
			if (paramCol["Meisaihead_iro_nm6"].UnformatValue != null)
			{
				formVO.Meisaihead_iro_nm6 = paramCol["Meisaihead_iro_nm6"].UnformatValue;
			}
			if (paramCol["Meisaihead_iro_nm7"].UnformatValue != null)
			{
				formVO.Meisaihead_iro_nm7 = paramCol["Meisaihead_iro_nm7"].UnformatValue;
			}
			if (paramCol["Meisaihead_iro_nm8"].UnformatValue != null)
			{
				formVO.Meisaihead_iro_nm8 = paramCol["Meisaihead_iro_nm8"].UnformatValue;
			}
			if (paramCol["Meisaihead_iro_nm9"].UnformatValue != null)
			{
				formVO.Meisaihead_iro_nm9 = paramCol["Meisaihead_iro_nm9"].UnformatValue;
			}
			if (paramCol["Meisaihead_iro_nm10"].UnformatValue != null)
			{
				formVO.Meisaihead_iro_nm10 = paramCol["Meisaihead_iro_nm10"].UnformatValue;
			}
			if (paramCol["Meisaihead_iro_nm11"].UnformatValue != null)
			{
				formVO.Meisaihead_iro_nm11 = paramCol["Meisaihead_iro_nm11"].UnformatValue;
			}
			if (paramCol["Meisaihead_iro_nm12"].UnformatValue != null)
			{
				formVO.Meisaihead_iro_nm12 = paramCol["Meisaihead_iro_nm12"].UnformatValue;
			}
			if (paramCol["Meisaihead_iro_nm13"].UnformatValue != null)
			{
				formVO.Meisaihead_iro_nm13 = paramCol["Meisaihead_iro_nm13"].UnformatValue;
			}
			if (paramCol["Meisaihead_iro_nm14"].UnformatValue != null)
			{
				formVO.Meisaihead_iro_nm14 = paramCol["Meisaihead_iro_nm14"].UnformatValue;
			}
			if (paramCol["Meisaihead_iro_nm15"].UnformatValue != null)
			{
				formVO.Meisaihead_iro_nm15 = paramCol["Meisaihead_iro_nm15"].UnformatValue;
			}
			if (paramCol["Meisaihead_iro_nm16"].UnformatValue != null)
			{
				formVO.Meisaihead_iro_nm16 = paramCol["Meisaihead_iro_nm16"].UnformatValue;
			}
			if (paramCol["Meisaihead_iro_nm17"].UnformatValue != null)
			{
				formVO.Meisaihead_iro_nm17 = paramCol["Meisaihead_iro_nm17"].UnformatValue;
			}
			if (paramCol["Meisaihead_iro_nm18"].UnformatValue != null)
			{
				formVO.Meisaihead_iro_nm18 = paramCol["Meisaihead_iro_nm18"].UnformatValue;
			}
			if (paramCol["Meisaihead_iro_nm19"].UnformatValue != null)
			{
				formVO.Meisaihead_iro_nm19 = paramCol["Meisaihead_iro_nm19"].UnformatValue;
			}
			if (paramCol["Meisaihead_iro_nm20"].UnformatValue != null)
			{
				formVO.Meisaihead_iro_nm20 = paramCol["Meisaihead_iro_nm20"].UnformatValue;
			}
			if (paramCol["Meisaihead_iro_nm21"].UnformatValue != null)
			{
				formVO.Meisaihead_iro_nm21 = paramCol["Meisaihead_iro_nm21"].UnformatValue;
			}
			if (paramCol["Meisaihead_iro_nm22"].UnformatValue != null)
			{
				formVO.Meisaihead_iro_nm22 = paramCol["Meisaihead_iro_nm22"].UnformatValue;
			}
			if (paramCol["Meisaihead_iro_nm23"].UnformatValue != null)
			{
				formVO.Meisaihead_iro_nm23 = paramCol["Meisaihead_iro_nm23"].UnformatValue;
			}
			if (paramCol["Meisaihead_iro_nm24"].UnformatValue != null)
			{
				formVO.Meisaihead_iro_nm24 = paramCol["Meisaihead_iro_nm24"].UnformatValue;
			}
			if (paramCol["Meisaihead_iro_nm25"].UnformatValue != null)
			{
				formVO.Meisaihead_iro_nm25 = paramCol["Meisaihead_iro_nm25"].UnformatValue;
			}
			if (paramCol["Meisaihead_iro_nm26"].UnformatValue != null)
			{
				formVO.Meisaihead_iro_nm26 = paramCol["Meisaihead_iro_nm26"].UnformatValue;
			}
			if (paramCol["Meisaihead_iro_nm27"].UnformatValue != null)
			{
				formVO.Meisaihead_iro_nm27 = paramCol["Meisaihead_iro_nm27"].UnformatValue;
			}
			if (paramCol["Meisaihead_iro_nm28"].UnformatValue != null)
			{
				formVO.Meisaihead_iro_nm28 = paramCol["Meisaihead_iro_nm28"].UnformatValue;
			}
			if (paramCol["Meisaihead_iro_nm29"].UnformatValue != null)
			{
				formVO.Meisaihead_iro_nm29 = paramCol["Meisaihead_iro_nm29"].UnformatValue;
			}
			if (paramCol["Meisaihead_iro_nm30"].UnformatValue != null)
			{
				formVO.Meisaihead_iro_nm30 = paramCol["Meisaihead_iro_nm30"].UnformatValue;
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
			if (paramCol["Gokei_suryo1"].UnformatValue != null)
			{
				formVO.Gokei_suryo1 = paramCol["Gokei_suryo1"].UnformatValue;
			}
			if (paramCol["Gokei_suryo2"].UnformatValue != null)
			{
				formVO.Gokei_suryo2 = paramCol["Gokei_suryo2"].UnformatValue;
			}
			if (paramCol["Gokei_suryo3"].UnformatValue != null)
			{
				formVO.Gokei_suryo3 = paramCol["Gokei_suryo3"].UnformatValue;
			}
			if (paramCol["Gokei_suryo4"].UnformatValue != null)
			{
				formVO.Gokei_suryo4 = paramCol["Gokei_suryo4"].UnformatValue;
			}
			if (paramCol["Gokei_suryo5"].UnformatValue != null)
			{
				formVO.Gokei_suryo5 = paramCol["Gokei_suryo5"].UnformatValue;
			}
			if (paramCol["Gokei_suryo6"].UnformatValue != null)
			{
				formVO.Gokei_suryo6 = paramCol["Gokei_suryo6"].UnformatValue;
			}
			if (paramCol["Gokei_suryo7"].UnformatValue != null)
			{
				formVO.Gokei_suryo7 = paramCol["Gokei_suryo7"].UnformatValue;
			}
			if (paramCol["Gokei_suryo8"].UnformatValue != null)
			{
				formVO.Gokei_suryo8 = paramCol["Gokei_suryo8"].UnformatValue;
			}
			if (paramCol["Gokei_suryo9"].UnformatValue != null)
			{
				formVO.Gokei_suryo9 = paramCol["Gokei_suryo9"].UnformatValue;
			}
			if (paramCol["Gokei_suryo10"].UnformatValue != null)
			{
				formVO.Gokei_suryo10 = paramCol["Gokei_suryo10"].UnformatValue;
			}
			if (paramCol["Gokei_suryo11"].UnformatValue != null)
			{
				formVO.Gokei_suryo11 = paramCol["Gokei_suryo11"].UnformatValue;
			}
			if (paramCol["Gokei_suryo12"].UnformatValue != null)
			{
				formVO.Gokei_suryo12 = paramCol["Gokei_suryo12"].UnformatValue;
			}
			if (paramCol["Gokei_suryo13"].UnformatValue != null)
			{
				formVO.Gokei_suryo13 = paramCol["Gokei_suryo13"].UnformatValue;
			}
			if (paramCol["Gokei_suryo14"].UnformatValue != null)
			{
				formVO.Gokei_suryo14 = paramCol["Gokei_suryo14"].UnformatValue;
			}
			if (paramCol["Gokei_suryo15"].UnformatValue != null)
			{
				formVO.Gokei_suryo15 = paramCol["Gokei_suryo15"].UnformatValue;
			}
			if (paramCol["Gokei_suryo16"].UnformatValue != null)
			{
				formVO.Gokei_suryo16 = paramCol["Gokei_suryo16"].UnformatValue;
			}
			if (paramCol["Gokei_suryo17"].UnformatValue != null)
			{
				formVO.Gokei_suryo17 = paramCol["Gokei_suryo17"].UnformatValue;
			}
			if (paramCol["Gokei_suryo18"].UnformatValue != null)
			{
				formVO.Gokei_suryo18 = paramCol["Gokei_suryo18"].UnformatValue;
			}
			if (paramCol["Gokei_suryo19"].UnformatValue != null)
			{
				formVO.Gokei_suryo19 = paramCol["Gokei_suryo19"].UnformatValue;
			}
			if (paramCol["Gokei_suryo20"].UnformatValue != null)
			{
				formVO.Gokei_suryo20 = paramCol["Gokei_suryo20"].UnformatValue;
			}
			if (paramCol["Gokei_suryo21"].UnformatValue != null)
			{
				formVO.Gokei_suryo21 = paramCol["Gokei_suryo21"].UnformatValue;
			}
			if (paramCol["Gokei_suryo22"].UnformatValue != null)
			{
				formVO.Gokei_suryo22 = paramCol["Gokei_suryo22"].UnformatValue;
			}
			if (paramCol["Gokei_suryo23"].UnformatValue != null)
			{
				formVO.Gokei_suryo23 = paramCol["Gokei_suryo23"].UnformatValue;
			}
			if (paramCol["Gokei_suryo24"].UnformatValue != null)
			{
				formVO.Gokei_suryo24 = paramCol["Gokei_suryo24"].UnformatValue;
			}
			if (paramCol["Gokei_suryo25"].UnformatValue != null)
			{
				formVO.Gokei_suryo25 = paramCol["Gokei_suryo25"].UnformatValue;
			}
			if (paramCol["Gokei_suryo26"].UnformatValue != null)
			{
				formVO.Gokei_suryo26 = paramCol["Gokei_suryo26"].UnformatValue;
			}
			if (paramCol["Gokei_suryo27"].UnformatValue != null)
			{
				formVO.Gokei_suryo27 = paramCol["Gokei_suryo27"].UnformatValue;
			}
			if (paramCol["Gokei_suryo28"].UnformatValue != null)
			{
				formVO.Gokei_suryo28 = paramCol["Gokei_suryo28"].UnformatValue;
			}
			if (paramCol["Gokei_suryo29"].UnformatValue != null)
			{
				formVO.Gokei_suryo29 = paramCol["Gokei_suryo29"].UnformatValue;
			}
			if (paramCol["Gokei_suryo30"].UnformatValue != null)
			{
				formVO.Gokei_suryo30 = paramCol["Gokei_suryo30"].UnformatValue;
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
				Th020f03M1Form th020f03M1Form = (Th020f03M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					th020f03M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1area_cd"][i].UnformatValue != null)
				{
					th020f03M1Form.M1area_cd = paramCol["M1area_cd"][i].UnformatValue;
				}
				if (paramCol["M1gokei_suryo"][i].UnformatValue != null)
				{
					th020f03M1Form.M1gokei_suryo = paramCol["M1gokei_suryo"][i].UnformatValue;
				}
				if (paramCol["M1syoka_rtu"][i].UnformatValue != null)
				{
					th020f03M1Form.M1syoka_rtu = paramCol["M1syoka_rtu"][i].UnformatValue;
				}
				if (paramCol["M1suryo1"][i].UnformatValue != null)
				{
					th020f03M1Form.M1suryo1 = paramCol["M1suryo1"][i].UnformatValue;
				}
				if (paramCol["M1suryo2"][i].UnformatValue != null)
				{
					th020f03M1Form.M1suryo2 = paramCol["M1suryo2"][i].UnformatValue;
				}
				if (paramCol["M1suryo3"][i].UnformatValue != null)
				{
					th020f03M1Form.M1suryo3 = paramCol["M1suryo3"][i].UnformatValue;
				}
				if (paramCol["M1suryo4"][i].UnformatValue != null)
				{
					th020f03M1Form.M1suryo4 = paramCol["M1suryo4"][i].UnformatValue;
				}
				if (paramCol["M1suryo5"][i].UnformatValue != null)
				{
					th020f03M1Form.M1suryo5 = paramCol["M1suryo5"][i].UnformatValue;
				}
				if (paramCol["M1suryo6"][i].UnformatValue != null)
				{
					th020f03M1Form.M1suryo6 = paramCol["M1suryo6"][i].UnformatValue;
				}
				if (paramCol["M1suryo7"][i].UnformatValue != null)
				{
					th020f03M1Form.M1suryo7 = paramCol["M1suryo7"][i].UnformatValue;
				}
				if (paramCol["M1suryo8"][i].UnformatValue != null)
				{
					th020f03M1Form.M1suryo8 = paramCol["M1suryo8"][i].UnformatValue;
				}
				if (paramCol["M1suryo9"][i].UnformatValue != null)
				{
					th020f03M1Form.M1suryo9 = paramCol["M1suryo9"][i].UnformatValue;
				}
				if (paramCol["M1suryo10"][i].UnformatValue != null)
				{
					th020f03M1Form.M1suryo10 = paramCol["M1suryo10"][i].UnformatValue;
				}
				if (paramCol["M1suryo11"][i].UnformatValue != null)
				{
					th020f03M1Form.M1suryo11 = paramCol["M1suryo11"][i].UnformatValue;
				}
				if (paramCol["M1suryo12"][i].UnformatValue != null)
				{
					th020f03M1Form.M1suryo12 = paramCol["M1suryo12"][i].UnformatValue;
				}
				if (paramCol["M1suryo13"][i].UnformatValue != null)
				{
					th020f03M1Form.M1suryo13 = paramCol["M1suryo13"][i].UnformatValue;
				}
				if (paramCol["M1suryo14"][i].UnformatValue != null)
				{
					th020f03M1Form.M1suryo14 = paramCol["M1suryo14"][i].UnformatValue;
				}
				if (paramCol["M1suryo15"][i].UnformatValue != null)
				{
					th020f03M1Form.M1suryo15 = paramCol["M1suryo15"][i].UnformatValue;
				}
				if (paramCol["M1suryo16"][i].UnformatValue != null)
				{
					th020f03M1Form.M1suryo16 = paramCol["M1suryo16"][i].UnformatValue;
				}
				if (paramCol["M1suryo17"][i].UnformatValue != null)
				{
					th020f03M1Form.M1suryo17 = paramCol["M1suryo17"][i].UnformatValue;
				}
				if (paramCol["M1suryo18"][i].UnformatValue != null)
				{
					th020f03M1Form.M1suryo18 = paramCol["M1suryo18"][i].UnformatValue;
				}
				if (paramCol["M1suryo19"][i].UnformatValue != null)
				{
					th020f03M1Form.M1suryo19 = paramCol["M1suryo19"][i].UnformatValue;
				}
				if (paramCol["M1suryo20"][i].UnformatValue != null)
				{
					th020f03M1Form.M1suryo20 = paramCol["M1suryo20"][i].UnformatValue;
				}
				if (paramCol["M1suryo21"][i].UnformatValue != null)
				{
					th020f03M1Form.M1suryo21 = paramCol["M1suryo21"][i].UnformatValue;
				}
				if (paramCol["M1suryo22"][i].UnformatValue != null)
				{
					th020f03M1Form.M1suryo22 = paramCol["M1suryo22"][i].UnformatValue;
				}
				if (paramCol["M1suryo23"][i].UnformatValue != null)
				{
					th020f03M1Form.M1suryo23 = paramCol["M1suryo23"][i].UnformatValue;
				}
				if (paramCol["M1suryo24"][i].UnformatValue != null)
				{
					th020f03M1Form.M1suryo24 = paramCol["M1suryo24"][i].UnformatValue;
				}
				if (paramCol["M1suryo25"][i].UnformatValue != null)
				{
					th020f03M1Form.M1suryo25 = paramCol["M1suryo25"][i].UnformatValue;
				}
				if (paramCol["M1suryo26"][i].UnformatValue != null)
				{
					th020f03M1Form.M1suryo26 = paramCol["M1suryo26"][i].UnformatValue;
				}
				if (paramCol["M1suryo27"][i].UnformatValue != null)
				{
					th020f03M1Form.M1suryo27 = paramCol["M1suryo27"][i].UnformatValue;
				}
				if (paramCol["M1suryo28"][i].UnformatValue != null)
				{
					th020f03M1Form.M1suryo28 = paramCol["M1suryo28"][i].UnformatValue;
				}
				if (paramCol["M1suryo29"][i].UnformatValue != null)
				{
					th020f03M1Form.M1suryo29 = paramCol["M1suryo29"][i].UnformatValue;
				}
				if (paramCol["M1suryo30"][i].UnformatValue != null)
				{
					th020f03M1Form.M1suryo30 = paramCol["M1suryo30"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					th020f03M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					th020f03M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					th020f03M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Th020f03Form formVO, StandardCheckManager checker)
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
			if (formVO.Meisaihead_iro_nm1 != null)
			{
				checker.DoCheck("Meisaihead_iro_nm1", formVO.Meisaihead_iro_nm1);
			}
			if (formVO.Meisaihead_iro_nm2 != null)
			{
				checker.DoCheck("Meisaihead_iro_nm2", formVO.Meisaihead_iro_nm2);
			}
			if (formVO.Meisaihead_iro_nm3 != null)
			{
				checker.DoCheck("Meisaihead_iro_nm3", formVO.Meisaihead_iro_nm3);
			}
			if (formVO.Meisaihead_iro_nm4 != null)
			{
				checker.DoCheck("Meisaihead_iro_nm4", formVO.Meisaihead_iro_nm4);
			}
			if (formVO.Meisaihead_iro_nm5 != null)
			{
				checker.DoCheck("Meisaihead_iro_nm5", formVO.Meisaihead_iro_nm5);
			}
			if (formVO.Meisaihead_iro_nm6 != null)
			{
				checker.DoCheck("Meisaihead_iro_nm6", formVO.Meisaihead_iro_nm6);
			}
			if (formVO.Meisaihead_iro_nm7 != null)
			{
				checker.DoCheck("Meisaihead_iro_nm7", formVO.Meisaihead_iro_nm7);
			}
			if (formVO.Meisaihead_iro_nm8 != null)
			{
				checker.DoCheck("Meisaihead_iro_nm8", formVO.Meisaihead_iro_nm8);
			}
			if (formVO.Meisaihead_iro_nm9 != null)
			{
				checker.DoCheck("Meisaihead_iro_nm9", formVO.Meisaihead_iro_nm9);
			}
			if (formVO.Meisaihead_iro_nm10 != null)
			{
				checker.DoCheck("Meisaihead_iro_nm10", formVO.Meisaihead_iro_nm10);
			}
			if (formVO.Meisaihead_iro_nm11 != null)
			{
				checker.DoCheck("Meisaihead_iro_nm11", formVO.Meisaihead_iro_nm11);
			}
			if (formVO.Meisaihead_iro_nm12 != null)
			{
				checker.DoCheck("Meisaihead_iro_nm12", formVO.Meisaihead_iro_nm12);
			}
			if (formVO.Meisaihead_iro_nm13 != null)
			{
				checker.DoCheck("Meisaihead_iro_nm13", formVO.Meisaihead_iro_nm13);
			}
			if (formVO.Meisaihead_iro_nm14 != null)
			{
				checker.DoCheck("Meisaihead_iro_nm14", formVO.Meisaihead_iro_nm14);
			}
			if (formVO.Meisaihead_iro_nm15 != null)
			{
				checker.DoCheck("Meisaihead_iro_nm15", formVO.Meisaihead_iro_nm15);
			}
			if (formVO.Meisaihead_iro_nm16 != null)
			{
				checker.DoCheck("Meisaihead_iro_nm16", formVO.Meisaihead_iro_nm16);
			}
			if (formVO.Meisaihead_iro_nm17 != null)
			{
				checker.DoCheck("Meisaihead_iro_nm17", formVO.Meisaihead_iro_nm17);
			}
			if (formVO.Meisaihead_iro_nm18 != null)
			{
				checker.DoCheck("Meisaihead_iro_nm18", formVO.Meisaihead_iro_nm18);
			}
			if (formVO.Meisaihead_iro_nm19 != null)
			{
				checker.DoCheck("Meisaihead_iro_nm19", formVO.Meisaihead_iro_nm19);
			}
			if (formVO.Meisaihead_iro_nm20 != null)
			{
				checker.DoCheck("Meisaihead_iro_nm20", formVO.Meisaihead_iro_nm20);
			}
			if (formVO.Meisaihead_iro_nm21 != null)
			{
				checker.DoCheck("Meisaihead_iro_nm21", formVO.Meisaihead_iro_nm21);
			}
			if (formVO.Meisaihead_iro_nm22 != null)
			{
				checker.DoCheck("Meisaihead_iro_nm22", formVO.Meisaihead_iro_nm22);
			}
			if (formVO.Meisaihead_iro_nm23 != null)
			{
				checker.DoCheck("Meisaihead_iro_nm23", formVO.Meisaihead_iro_nm23);
			}
			if (formVO.Meisaihead_iro_nm24 != null)
			{
				checker.DoCheck("Meisaihead_iro_nm24", formVO.Meisaihead_iro_nm24);
			}
			if (formVO.Meisaihead_iro_nm25 != null)
			{
				checker.DoCheck("Meisaihead_iro_nm25", formVO.Meisaihead_iro_nm25);
			}
			if (formVO.Meisaihead_iro_nm26 != null)
			{
				checker.DoCheck("Meisaihead_iro_nm26", formVO.Meisaihead_iro_nm26);
			}
			if (formVO.Meisaihead_iro_nm27 != null)
			{
				checker.DoCheck("Meisaihead_iro_nm27", formVO.Meisaihead_iro_nm27);
			}
			if (formVO.Meisaihead_iro_nm28 != null)
			{
				checker.DoCheck("Meisaihead_iro_nm28", formVO.Meisaihead_iro_nm28);
			}
			if (formVO.Meisaihead_iro_nm29 != null)
			{
				checker.DoCheck("Meisaihead_iro_nm29", formVO.Meisaihead_iro_nm29);
			}
			if (formVO.Meisaihead_iro_nm30 != null)
			{
				checker.DoCheck("Meisaihead_iro_nm30", formVO.Meisaihead_iro_nm30);
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
			if (formVO.Gokei_suryo1 != null)
			{
				checker.DoCheck("Gokei_suryo1", formVO.Gokei_suryo1);
			}
			if (formVO.Gokei_suryo2 != null)
			{
				checker.DoCheck("Gokei_suryo2", formVO.Gokei_suryo2);
			}
			if (formVO.Gokei_suryo3 != null)
			{
				checker.DoCheck("Gokei_suryo3", formVO.Gokei_suryo3);
			}
			if (formVO.Gokei_suryo4 != null)
			{
				checker.DoCheck("Gokei_suryo4", formVO.Gokei_suryo4);
			}
			if (formVO.Gokei_suryo5 != null)
			{
				checker.DoCheck("Gokei_suryo5", formVO.Gokei_suryo5);
			}
			if (formVO.Gokei_suryo6 != null)
			{
				checker.DoCheck("Gokei_suryo6", formVO.Gokei_suryo6);
			}
			if (formVO.Gokei_suryo7 != null)
			{
				checker.DoCheck("Gokei_suryo7", formVO.Gokei_suryo7);
			}
			if (formVO.Gokei_suryo8 != null)
			{
				checker.DoCheck("Gokei_suryo8", formVO.Gokei_suryo8);
			}
			if (formVO.Gokei_suryo9 != null)
			{
				checker.DoCheck("Gokei_suryo9", formVO.Gokei_suryo9);
			}
			if (formVO.Gokei_suryo10 != null)
			{
				checker.DoCheck("Gokei_suryo10", formVO.Gokei_suryo10);
			}
			if (formVO.Gokei_suryo11 != null)
			{
				checker.DoCheck("Gokei_suryo11", formVO.Gokei_suryo11);
			}
			if (formVO.Gokei_suryo12 != null)
			{
				checker.DoCheck("Gokei_suryo12", formVO.Gokei_suryo12);
			}
			if (formVO.Gokei_suryo13 != null)
			{
				checker.DoCheck("Gokei_suryo13", formVO.Gokei_suryo13);
			}
			if (formVO.Gokei_suryo14 != null)
			{
				checker.DoCheck("Gokei_suryo14", formVO.Gokei_suryo14);
			}
			if (formVO.Gokei_suryo15 != null)
			{
				checker.DoCheck("Gokei_suryo15", formVO.Gokei_suryo15);
			}
			if (formVO.Gokei_suryo16 != null)
			{
				checker.DoCheck("Gokei_suryo16", formVO.Gokei_suryo16);
			}
			if (formVO.Gokei_suryo17 != null)
			{
				checker.DoCheck("Gokei_suryo17", formVO.Gokei_suryo17);
			}
			if (formVO.Gokei_suryo18 != null)
			{
				checker.DoCheck("Gokei_suryo18", formVO.Gokei_suryo18);
			}
			if (formVO.Gokei_suryo19 != null)
			{
				checker.DoCheck("Gokei_suryo19", formVO.Gokei_suryo19);
			}
			if (formVO.Gokei_suryo20 != null)
			{
				checker.DoCheck("Gokei_suryo20", formVO.Gokei_suryo20);
			}
			if (formVO.Gokei_suryo21 != null)
			{
				checker.DoCheck("Gokei_suryo21", formVO.Gokei_suryo21);
			}
			if (formVO.Gokei_suryo22 != null)
			{
				checker.DoCheck("Gokei_suryo22", formVO.Gokei_suryo22);
			}
			if (formVO.Gokei_suryo23 != null)
			{
				checker.DoCheck("Gokei_suryo23", formVO.Gokei_suryo23);
			}
			if (formVO.Gokei_suryo24 != null)
			{
				checker.DoCheck("Gokei_suryo24", formVO.Gokei_suryo24);
			}
			if (formVO.Gokei_suryo25 != null)
			{
				checker.DoCheck("Gokei_suryo25", formVO.Gokei_suryo25);
			}
			if (formVO.Gokei_suryo26 != null)
			{
				checker.DoCheck("Gokei_suryo26", formVO.Gokei_suryo26);
			}
			if (formVO.Gokei_suryo27 != null)
			{
				checker.DoCheck("Gokei_suryo27", formVO.Gokei_suryo27);
			}
			if (formVO.Gokei_suryo28 != null)
			{
				checker.DoCheck("Gokei_suryo28", formVO.Gokei_suryo28);
			}
			if (formVO.Gokei_suryo29 != null)
			{
				checker.DoCheck("Gokei_suryo29", formVO.Gokei_suryo29);
			}
			if (formVO.Gokei_suryo30 != null)
			{
				checker.DoCheck("Gokei_suryo30", formVO.Gokei_suryo30);
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
		public static void ValidateM1InputValue(Th020f03Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Th020f03M1Form th020f03M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, th020f03M1Form, i, m1List);
				if (th020f03M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", th020f03M1Form.M1rowno, i, m1List);
				}
				if (th020f03M1Form.M1area_cd != null)
				{
					checker.DoCheck("M1area_cd", th020f03M1Form.M1area_cd, i, m1List);
				}
				if (th020f03M1Form.M1gokei_suryo != null)
				{
					checker.DoCheck("M1gokei_suryo", th020f03M1Form.M1gokei_suryo, i, m1List);
				}
				if (th020f03M1Form.M1syoka_rtu != null)
				{
					checker.DoCheck("M1syoka_rtu", th020f03M1Form.M1syoka_rtu, i, m1List);
				}
				if (th020f03M1Form.M1suryo1 != null)
				{
					checker.DoCheck("M1suryo1", th020f03M1Form.M1suryo1, i, m1List);
				}
				if (th020f03M1Form.M1suryo2 != null)
				{
					checker.DoCheck("M1suryo2", th020f03M1Form.M1suryo2, i, m1List);
				}
				if (th020f03M1Form.M1suryo3 != null)
				{
					checker.DoCheck("M1suryo3", th020f03M1Form.M1suryo3, i, m1List);
				}
				if (th020f03M1Form.M1suryo4 != null)
				{
					checker.DoCheck("M1suryo4", th020f03M1Form.M1suryo4, i, m1List);
				}
				if (th020f03M1Form.M1suryo5 != null)
				{
					checker.DoCheck("M1suryo5", th020f03M1Form.M1suryo5, i, m1List);
				}
				if (th020f03M1Form.M1suryo6 != null)
				{
					checker.DoCheck("M1suryo6", th020f03M1Form.M1suryo6, i, m1List);
				}
				if (th020f03M1Form.M1suryo7 != null)
				{
					checker.DoCheck("M1suryo7", th020f03M1Form.M1suryo7, i, m1List);
				}
				if (th020f03M1Form.M1suryo8 != null)
				{
					checker.DoCheck("M1suryo8", th020f03M1Form.M1suryo8, i, m1List);
				}
				if (th020f03M1Form.M1suryo9 != null)
				{
					checker.DoCheck("M1suryo9", th020f03M1Form.M1suryo9, i, m1List);
				}
				if (th020f03M1Form.M1suryo10 != null)
				{
					checker.DoCheck("M1suryo10", th020f03M1Form.M1suryo10, i, m1List);
				}
				if (th020f03M1Form.M1suryo11 != null)
				{
					checker.DoCheck("M1suryo11", th020f03M1Form.M1suryo11, i, m1List);
				}
				if (th020f03M1Form.M1suryo12 != null)
				{
					checker.DoCheck("M1suryo12", th020f03M1Form.M1suryo12, i, m1List);
				}
				if (th020f03M1Form.M1suryo13 != null)
				{
					checker.DoCheck("M1suryo13", th020f03M1Form.M1suryo13, i, m1List);
				}
				if (th020f03M1Form.M1suryo14 != null)
				{
					checker.DoCheck("M1suryo14", th020f03M1Form.M1suryo14, i, m1List);
				}
				if (th020f03M1Form.M1suryo15 != null)
				{
					checker.DoCheck("M1suryo15", th020f03M1Form.M1suryo15, i, m1List);
				}
				if (th020f03M1Form.M1suryo16 != null)
				{
					checker.DoCheck("M1suryo16", th020f03M1Form.M1suryo16, i, m1List);
				}
				if (th020f03M1Form.M1suryo17 != null)
				{
					checker.DoCheck("M1suryo17", th020f03M1Form.M1suryo17, i, m1List);
				}
				if (th020f03M1Form.M1suryo18 != null)
				{
					checker.DoCheck("M1suryo18", th020f03M1Form.M1suryo18, i, m1List);
				}
				if (th020f03M1Form.M1suryo19 != null)
				{
					checker.DoCheck("M1suryo19", th020f03M1Form.M1suryo19, i, m1List);
				}
				if (th020f03M1Form.M1suryo20 != null)
				{
					checker.DoCheck("M1suryo20", th020f03M1Form.M1suryo20, i, m1List);
				}
				if (th020f03M1Form.M1suryo21 != null)
				{
					checker.DoCheck("M1suryo21", th020f03M1Form.M1suryo21, i, m1List);
				}
				if (th020f03M1Form.M1suryo22 != null)
				{
					checker.DoCheck("M1suryo22", th020f03M1Form.M1suryo22, i, m1List);
				}
				if (th020f03M1Form.M1suryo23 != null)
				{
					checker.DoCheck("M1suryo23", th020f03M1Form.M1suryo23, i, m1List);
				}
				if (th020f03M1Form.M1suryo24 != null)
				{
					checker.DoCheck("M1suryo24", th020f03M1Form.M1suryo24, i, m1List);
				}
				if (th020f03M1Form.M1suryo25 != null)
				{
					checker.DoCheck("M1suryo25", th020f03M1Form.M1suryo25, i, m1List);
				}
				if (th020f03M1Form.M1suryo26 != null)
				{
					checker.DoCheck("M1suryo26", th020f03M1Form.M1suryo26, i, m1List);
				}
				if (th020f03M1Form.M1suryo27 != null)
				{
					checker.DoCheck("M1suryo27", th020f03M1Form.M1suryo27, i, m1List);
				}
				if (th020f03M1Form.M1suryo28 != null)
				{
					checker.DoCheck("M1suryo28", th020f03M1Form.M1suryo28, i, m1List);
				}
				if (th020f03M1Form.M1suryo29 != null)
				{
					checker.DoCheck("M1suryo29", th020f03M1Form.M1suryo29, i, m1List);
				}
				if (th020f03M1Form.M1suryo30 != null)
				{
					checker.DoCheck("M1suryo30", th020f03M1Form.M1suryo30, i, m1List);
				}
				if (th020f03M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", th020f03M1Form.M1selectorcheckbox, i, m1List);
				}
				if (th020f03M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", th020f03M1Form.M1entersyoriflg, i, m1List);
				}
				if (th020f03M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", th020f03M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Th020f03Form formVO, StandardCodeCheckManager checker)
		{
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Th020f03Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

