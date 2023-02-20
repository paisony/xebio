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
  /// Tl030f02RequestHelper の概要の説明です。
  /// </summary>
  public static class Tl030f02RequestHelper
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
			Tl030f02Form formVO = (Tl030f02Form)pageContext.GetFormVO();

			//カード部を初期化する
			paramCol.InitCardItems(formInfo.GetCardItems());
			//明細「M1」部を初期化する
			paramCol.InitListItems(formInfo.GetListItems("M1"), formVO.GetList("M1").CurrentCount);
			//カード項目の入力値を取得する
			paramCol["Head_tenpo_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Head_tenpo_nm"]);
			paramCol["Shinseimoto_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Shinseimoto_nm"]);
			paramCol["Sinseitan_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Sinseitan_cd"]);
			paramCol["Sinseitan_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Sinseitan_nm"]);
			paramCol["Bumon_cd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_cd"]);
			paramCol["Bumon_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Bumon_nm"]);
			paramCol["Baihen_shiji_no"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Baihen_shiji_no"]);
			paramCol["Baihen_riyu_nm"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Baihen_riyu_nm"]);
			paramCol["Aihensagyokaisi_ymd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Aihensagyokaisi_ymd"]);
			paramCol["Baihenkaisi_ymd"].RequestValue = RequestParameterUtil.GetRequestValue(
				page, formInfo["Baihenkaisi_ymd"]);
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
				paramCol["M1season_kb"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1season_kb"]);
				paramCol["M1hanbaikanryo_ymd"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1hanbaikanryo_ymd"]);
				paramCol["M1mtobaika_tnk"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1mtobaika_tnk"]);
				paramCol["M1gen_tnk"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1gen_tnk"]);
				paramCol["M1yobobaika_tnk"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1yobobaika_tnk"]);
				paramCol["M1kakuteibaika_tnk"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1kakuteibaika_tnk"]);
				paramCol["M1neire_rtu_genko"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1neire_rtu_genko"]);
				paramCol["M1neire_rtu_baihengo"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1neire_rtu_baihengo"]);
				paramCol["M1zaiko_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1zaiko_su"]);
				paramCol["M1uriage_su"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1uriage_su"]);
				paramCol["M1syonin_flg"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1syonin_flg"]);
				paramCol["M1kyakka_flg"][i].RequestValue = RequestParameterUtil.GetRequestValue(
					M1.Items[i], formInfo["M1kyakka_flg"]);
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
			Tl030f02Form formVO = (Tl030f02Form)pageContext.GetFormVO();

			//カード項目のアンフォーマット値を取得する
			paramCol["Head_tenpo_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_cd"].RequestValue, formInfo["Head_tenpo_cd"]);
			paramCol["Head_tenpo_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Head_tenpo_nm"].RequestValue, formInfo["Head_tenpo_nm"]);
			paramCol["Shinseimoto_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Shinseimoto_nm"].RequestValue, formInfo["Shinseimoto_nm"]);
			paramCol["Sinseitan_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Sinseitan_cd"].RequestValue, formInfo["Sinseitan_cd"]);
			paramCol["Sinseitan_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Sinseitan_nm"].RequestValue, formInfo["Sinseitan_nm"]);
			paramCol["Bumon_cd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_cd"].RequestValue, formInfo["Bumon_cd"]);
			paramCol["Bumon_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Bumon_nm"].RequestValue, formInfo["Bumon_nm"]);
			paramCol["Baihen_shiji_no"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Baihen_shiji_no"].RequestValue, formInfo["Baihen_shiji_no"]);
			paramCol["Baihen_riyu_nm"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Baihen_riyu_nm"].RequestValue, formInfo["Baihen_riyu_nm"]);
			paramCol["Aihensagyokaisi_ymd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Aihensagyokaisi_ymd"].RequestValue, formInfo["Aihensagyokaisi_ymd"]);
			paramCol["Aihensagyokaisi_ymd"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Aihensagyokaisi_ymd"].RequestValue, formInfo["Aihensagyokaisi_ymd"]);
			paramCol["Baihenkaisi_ymd"].UnformatValue = RequestParameterUtil.GetUnformatValue(
				paramCol["Baihenkaisi_ymd"].RequestValue, formInfo["Baihenkaisi_ymd"]);
			paramCol["Baihenkaisi_ymd"].DateFullValue = RequestParameterUtil.GetDateFullValue(
				paramCol["Baihenkaisi_ymd"].RequestValue, formInfo["Baihenkaisi_ymd"]);
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
				paramCol["M1season_kb"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1season_kb"][i].RequestValue, formInfo["M1season_kb"]);
				paramCol["M1hanbaikanryo_ymd"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1hanbaikanryo_ymd"][i].RequestValue, formInfo["M1hanbaikanryo_ymd"]);
				paramCol["M1hanbaikanryo_ymd"][i].DateFullValue = RequestParameterUtil.GetDateFullValue(
					paramCol["M1hanbaikanryo_ymd"][i].RequestValue, formInfo["M1hanbaikanryo_ymd"]);
				paramCol["M1mtobaika_tnk"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1mtobaika_tnk"][i].RequestValue, formInfo["M1mtobaika_tnk"]);
				paramCol["M1gen_tnk"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1gen_tnk"][i].RequestValue, formInfo["M1gen_tnk"]);
				paramCol["M1yobobaika_tnk"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1yobobaika_tnk"][i].RequestValue, formInfo["M1yobobaika_tnk"]);
				paramCol["M1kakuteibaika_tnk"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1kakuteibaika_tnk"][i].RequestValue, formInfo["M1kakuteibaika_tnk"]);
				paramCol["M1neire_rtu_genko"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1neire_rtu_genko"][i].RequestValue, formInfo["M1neire_rtu_genko"]);
				paramCol["M1neire_rtu_baihengo"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1neire_rtu_baihengo"][i].RequestValue, formInfo["M1neire_rtu_baihengo"]);
				paramCol["M1zaiko_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1zaiko_su"][i].RequestValue, formInfo["M1zaiko_su"]);
				paramCol["M1uriage_su"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1uriage_su"][i].RequestValue, formInfo["M1uriage_su"]);
				paramCol["M1syonin_flg"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1syonin_flg"][i].RequestValue, formInfo["M1syonin_flg"]);
				paramCol["M1kyakka_flg"][i].UnformatValue = RequestParameterUtil.GetUnformatValue(
					paramCol["M1kyakka_flg"][i].RequestValue, formInfo["M1kyakka_flg"]);
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
			Tl030f02Form formVO = (Tl030f02Form)pageContext.GetFormVO();

			//カード項目の入力値をFormVOにコピーする
			if (paramCol["Head_tenpo_cd"].UnformatValue != null)
			{
				formVO.Head_tenpo_cd = paramCol["Head_tenpo_cd"].UnformatValue;
			}
			if (paramCol["Head_tenpo_nm"].UnformatValue != null)
			{
				formVO.Head_tenpo_nm = paramCol["Head_tenpo_nm"].UnformatValue;
			}
			if (paramCol["Shinseimoto_nm"].UnformatValue != null)
			{
				formVO.Shinseimoto_nm = paramCol["Shinseimoto_nm"].UnformatValue;
			}
			if (paramCol["Sinseitan_cd"].UnformatValue != null)
			{
				formVO.Sinseitan_cd = paramCol["Sinseitan_cd"].UnformatValue;
			}
			if (paramCol["Sinseitan_nm"].UnformatValue != null)
			{
				formVO.Sinseitan_nm = paramCol["Sinseitan_nm"].UnformatValue;
			}
			if (paramCol["Bumon_cd"].UnformatValue != null)
			{
				formVO.Bumon_cd = paramCol["Bumon_cd"].UnformatValue;
			}
			if (paramCol["Bumon_nm"].UnformatValue != null)
			{
				formVO.Bumon_nm = paramCol["Bumon_nm"].UnformatValue;
			}
			if (paramCol["Baihen_shiji_no"].UnformatValue != null)
			{
				formVO.Baihen_shiji_no = paramCol["Baihen_shiji_no"].UnformatValue;
			}
			if (paramCol["Baihen_riyu_nm"].UnformatValue != null)
			{
				formVO.Baihen_riyu_nm = paramCol["Baihen_riyu_nm"].UnformatValue;
			}
			if (paramCol["Aihensagyokaisi_ymd"].DateFullValue != null)
			{
				formVO.Aihensagyokaisi_ymd = paramCol["Aihensagyokaisi_ymd"].DateFullValue;
			}
			if (paramCol["Baihenkaisi_ymd"].DateFullValue != null)
			{
				formVO.Baihenkaisi_ymd = paramCol["Baihenkaisi_ymd"].DateFullValue;
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
				Tl030f02M1Form tl030f02M1Form = (Tl030f02M1Form)m1List.GetRowAt(i);
							
				if (paramCol["M1rowno"][i].UnformatValue != null)
				{
					tl030f02M1Form.M1rowno = paramCol["M1rowno"][i].UnformatValue;
				}
				if (paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue != null)
				{
					tl030f02M1Form.M1hinsyu_ryaku_nm = paramCol["M1hinsyu_ryaku_nm"][i].UnformatValue;
				}
				if (paramCol["M1burando_nm"][i].UnformatValue != null)
				{
					tl030f02M1Form.M1burando_nm = paramCol["M1burando_nm"][i].UnformatValue;
				}
				if (paramCol["M1jisya_hbn"][i].UnformatValue != null)
				{
					tl030f02M1Form.M1jisya_hbn = paramCol["M1jisya_hbn"][i].UnformatValue;
				}
				if (paramCol["M1maker_hbn"][i].UnformatValue != null)
				{
					tl030f02M1Form.M1maker_hbn = paramCol["M1maker_hbn"][i].UnformatValue;
				}
				if (paramCol["M1syonmk"][i].UnformatValue != null)
				{
					tl030f02M1Form.M1syonmk = paramCol["M1syonmk"][i].UnformatValue;
				}
				if (paramCol["M1iro_nm"][i].UnformatValue != null)
				{
					tl030f02M1Form.M1iro_nm = paramCol["M1iro_nm"][i].UnformatValue;
				}
				if (paramCol["M1season_kb"][i].UnformatValue != null)
				{
					tl030f02M1Form.M1season_kb = paramCol["M1season_kb"][i].UnformatValue;
				}
				if (paramCol["M1hanbaikanryo_ymd"][i].DateFullValue != null)
				{
					tl030f02M1Form.M1hanbaikanryo_ymd = paramCol["M1hanbaikanryo_ymd"][i].DateFullValue;
				}
				if (paramCol["M1mtobaika_tnk"][i].UnformatValue != null)
				{
					tl030f02M1Form.M1mtobaika_tnk = paramCol["M1mtobaika_tnk"][i].UnformatValue;
				}
				if (paramCol["M1gen_tnk"][i].UnformatValue != null)
				{
					tl030f02M1Form.M1gen_tnk = paramCol["M1gen_tnk"][i].UnformatValue;
				}
				if (paramCol["M1yobobaika_tnk"][i].UnformatValue != null)
				{
					tl030f02M1Form.M1yobobaika_tnk = paramCol["M1yobobaika_tnk"][i].UnformatValue;
				}
				if (paramCol["M1kakuteibaika_tnk"][i].UnformatValue != null)
				{
					tl030f02M1Form.M1kakuteibaika_tnk = paramCol["M1kakuteibaika_tnk"][i].UnformatValue;
				}
				if (paramCol["M1neire_rtu_genko"][i].UnformatValue != null)
				{
					tl030f02M1Form.M1neire_rtu_genko = paramCol["M1neire_rtu_genko"][i].UnformatValue;
				}
				if (paramCol["M1neire_rtu_baihengo"][i].UnformatValue != null)
				{
					tl030f02M1Form.M1neire_rtu_baihengo = paramCol["M1neire_rtu_baihengo"][i].UnformatValue;
				}
				if (paramCol["M1zaiko_su"][i].UnformatValue != null)
				{
					tl030f02M1Form.M1zaiko_su = paramCol["M1zaiko_su"][i].UnformatValue;
				}
				if (paramCol["M1uriage_su"][i].UnformatValue != null)
				{
					tl030f02M1Form.M1uriage_su = paramCol["M1uriage_su"][i].UnformatValue;
				}
				if (paramCol["M1syonin_flg"][i].UnformatValue != null)
				{
					tl030f02M1Form.M1syonin_flg = paramCol["M1syonin_flg"][i].UnformatValue;
				}
				if (paramCol["M1kyakka_flg"][i].UnformatValue != null)
				{
					tl030f02M1Form.M1kyakka_flg = paramCol["M1kyakka_flg"][i].UnformatValue;
				}
				if (paramCol["M1selectorcheckbox"][i].UnformatValue != null)
				{
					tl030f02M1Form.M1selectorcheckbox = paramCol["M1selectorcheckbox"][i].UnformatValue;
				}
				if (paramCol["M1entersyoriflg"][i].UnformatValue != null)
				{
					tl030f02M1Form.M1entersyoriflg = paramCol["M1entersyoriflg"][i].UnformatValue;
				}
				if (paramCol["M1dtlirokbn"][i].UnformatValue != null)
				{
					tl030f02M1Form.M1dtlirokbn = paramCol["M1dtlirokbn"][i].UnformatValue;
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
		public static void ValidateCardInputValue(Tl030f02Form formVO, StandardCheckManager checker)
		{
			if (formVO.Head_tenpo_cd != null)
			{
				checker.DoCheck("Head_tenpo_cd", formVO.Head_tenpo_cd);
			}
			if (formVO.Head_tenpo_nm != null)
			{
				checker.DoCheck("Head_tenpo_nm", formVO.Head_tenpo_nm);
			}
			if (formVO.Shinseimoto_nm != null)
			{
				checker.DoCheck("Shinseimoto_nm", formVO.Shinseimoto_nm);
			}
			if (formVO.Sinseitan_cd != null)
			{
				checker.DoCheck("Sinseitan_cd", formVO.Sinseitan_cd);
			}
			if (formVO.Sinseitan_nm != null)
			{
				checker.DoCheck("Sinseitan_nm", formVO.Sinseitan_nm);
			}
			if (formVO.Bumon_cd != null)
			{
				checker.DoCheck("Bumon_cd", formVO.Bumon_cd);
			}
			if (formVO.Bumon_nm != null)
			{
				checker.DoCheck("Bumon_nm", formVO.Bumon_nm);
			}
			if (formVO.Baihen_shiji_no != null)
			{
				checker.DoCheck("Baihen_shiji_no", formVO.Baihen_shiji_no);
			}
			if (formVO.Baihen_riyu_nm != null)
			{
				checker.DoCheck("Baihen_riyu_nm", formVO.Baihen_riyu_nm);
			}
			if (formVO.Aihensagyokaisi_ymd != null)
			{
				checker.DoCheck("Aihensagyokaisi_ymd", formVO.Aihensagyokaisi_ymd);
			}
			if (formVO.Baihenkaisi_ymd != null)
			{
				checker.DoCheck("Baihenkaisi_ymd", formVO.Baihenkaisi_ymd);
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
		public static void ValidateM1InputValue(Tl030f02Form formVO, StandardCheckManager checker)
		{
			// SCSubBasePageの取得
			SCSubBasePage scPage = (SCSubBasePage)HttpContext.Current.Handler;
			//明細「M1」項目の入力値チェックをする
			int i = 0;
			IDataList m1List = formVO.GetList("M1");
			foreach (Tl030f02M1Form tl030f02M1Form in m1List.GetCheckRowList())
			{
				// 明細「M1」上のカスタム項目の入力チェックを実行
				scPage.CheckListItems("M1", checker, tl030f02M1Form, i, m1List);
				if (tl030f02M1Form.M1rowno != null)
				{
					checker.DoCheck("M1rowno", tl030f02M1Form.M1rowno, i, m1List);
				}
				if (tl030f02M1Form.M1hinsyu_ryaku_nm != null)
				{
					checker.DoCheck("M1hinsyu_ryaku_nm", tl030f02M1Form.M1hinsyu_ryaku_nm, i, m1List);
				}
				if (tl030f02M1Form.M1burando_nm != null)
				{
					checker.DoCheck("M1burando_nm", tl030f02M1Form.M1burando_nm, i, m1List);
				}
				if (tl030f02M1Form.M1jisya_hbn != null)
				{
					checker.DoCheck("M1jisya_hbn", tl030f02M1Form.M1jisya_hbn, i, m1List);
				}
				if (tl030f02M1Form.M1maker_hbn != null)
				{
					checker.DoCheck("M1maker_hbn", tl030f02M1Form.M1maker_hbn, i, m1List);
				}
				if (tl030f02M1Form.M1syonmk != null)
				{
					checker.DoCheck("M1syonmk", tl030f02M1Form.M1syonmk, i, m1List);
				}
				if (tl030f02M1Form.M1iro_nm != null)
				{
					checker.DoCheck("M1iro_nm", tl030f02M1Form.M1iro_nm, i, m1List);
				}
				if (tl030f02M1Form.M1season_kb != null)
				{
					checker.DoCheck("M1season_kb", tl030f02M1Form.M1season_kb, i, m1List);
				}
				if (tl030f02M1Form.M1hanbaikanryo_ymd != null)
				{
					checker.DoCheck("M1hanbaikanryo_ymd", tl030f02M1Form.M1hanbaikanryo_ymd, i, m1List);
				}
				if (tl030f02M1Form.M1mtobaika_tnk != null)
				{
					checker.DoCheck("M1mtobaika_tnk", tl030f02M1Form.M1mtobaika_tnk, i, m1List);
				}
				if (tl030f02M1Form.M1gen_tnk != null)
				{
					checker.DoCheck("M1gen_tnk", tl030f02M1Form.M1gen_tnk, i, m1List);
				}
				if (tl030f02M1Form.M1yobobaika_tnk != null)
				{
					checker.DoCheck("M1yobobaika_tnk", tl030f02M1Form.M1yobobaika_tnk, i, m1List);
				}
				if (tl030f02M1Form.M1kakuteibaika_tnk != null)
				{
					checker.DoCheck("M1kakuteibaika_tnk", tl030f02M1Form.M1kakuteibaika_tnk, i, m1List);
				}
				if (tl030f02M1Form.M1neire_rtu_genko != null)
				{
					checker.DoCheck("M1neire_rtu_genko", tl030f02M1Form.M1neire_rtu_genko, i, m1List);
				}
				if (tl030f02M1Form.M1neire_rtu_baihengo != null)
				{
					checker.DoCheck("M1neire_rtu_baihengo", tl030f02M1Form.M1neire_rtu_baihengo, i, m1List);
				}
				if (tl030f02M1Form.M1zaiko_su != null)
				{
					checker.DoCheck("M1zaiko_su", tl030f02M1Form.M1zaiko_su, i, m1List);
				}
				if (tl030f02M1Form.M1uriage_su != null)
				{
					checker.DoCheck("M1uriage_su", tl030f02M1Form.M1uriage_su, i, m1List);
				}
				if (tl030f02M1Form.M1syonin_flg != null)
				{
					checker.DoCheck("M1syonin_flg", tl030f02M1Form.M1syonin_flg, i, m1List);
				}
				if (tl030f02M1Form.M1kyakka_flg != null)
				{
					checker.DoCheck("M1kyakka_flg", tl030f02M1Form.M1kyakka_flg, i, m1List);
				}
				if (tl030f02M1Form.M1selectorcheckbox != null)
				{
					checker.DoCheck("M1selectorcheckbox", tl030f02M1Form.M1selectorcheckbox, i, m1List);
				}
				if (tl030f02M1Form.M1entersyoriflg != null)
				{
					checker.DoCheck("M1entersyoriflg", tl030f02M1Form.M1entersyoriflg, i, m1List);
				}
				if (tl030f02M1Form.M1dtlirokbn != null)
				{
					checker.DoCheck("M1dtlirokbn", tl030f02M1Form.M1dtlirokbn, i, m1List);
				}

				i++;
			}
		}

		/// <summary>
		/// カード部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateCardCodeValue(Tl030f02Form formVO, StandardCodeCheckManager checker)
		{
		}

		/// <summary>
		/// 明細部コード存在チェックをします。
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <param name="checker">チェックマネージャ</param>
		public static void ValidateM1CodeValue(Tl030f02Form formVO, StandardCodeCheckManager checker)
		{
		}
	}
}

