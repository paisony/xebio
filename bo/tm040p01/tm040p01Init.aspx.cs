using com.xebio.bo.Tm040p01.Constant;
using com.xebio.bo.Tm040p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.Web.Context;
using Common.Business.C01000.C01014;
using Common.Business.C01000.C01023;
using Common.Standard.Base;
using Common.Standard.Form;
using System.Collections.Specialized;

namespace com.xebio.bo.Tm040p01.Page
{
  /// <summary>
  /// Tm040p01の初期化ページです。
  /// </summary>
  public partial class Tm040p01InitPage : StandardBasePage
	{
		#region メソッド
		
		#region プログラム初期化するメソッド
		protected new void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				//ページコンテキストを取得する
				IPageContext pageContext = base.GetPageContext();
				ICommandInfo commandInfo = pageContext.CommandInfo;
	
				//プログラムIDを取得する
				string pgId = commandInfo.ProgramId;

				//フォームVOマネージャーを取得する
				FormVOManager fm = new FormVOManager(pageContext.Session);
	
				//プログラムVOを初期化してセッションに保存する
				fm.SetProgramVO(pgId, new Tm040p01PgForm());

				if(base.CheckUseSelfCustomize()){
					//項目拡張機能をしたい場合はまず下の行を有効にして下さい。
					//セルフカスタマイズを使用する場合も下の行を有効にしてください。
					//ExtItemInfoManager eim = new ExtItemInfoManager(pageContext.Session);
					//ExtItemInfoFlgManager efm = new ExtItemInfoFlgManager(pageContext.Session);

					//このプログラムに属する画面の項目情報を拡張したい場合、下の行を有効に
					//して下さい。
					//セルフカスタマイズを使用する場合も下の行を有効にしてください。
					//efm.SetItemInfoFlg(pgId, "Tm040f01", true);
					//efm.SetItemInfoFlg(pgId, "Tm040f02", true);
				}

				//セッションに持っているこのプログラム以外のプログラム情報：フォームVO、
				//拡張項目情報と項目情報拡張フラグを一括で消去する場合は下の行を有効に
				//して下さい。他プログラムのプログラム情報を残したい場合はAPIを参考に
				//処理をして下さい。
				//fm.RemoveProgramVOExcept(pgId);
				//eim.RemoveItemInfoExcept(pgId);
				//efm.RemoveItemInfoFlgExcept(pgId);

				//遷移先の画面を設定します(入出力画面定義で定義したスタート画面を設定済み)
				commandInfo.ToFormId = FormInfoManager.GetProgramInfo(pgId).StartupForm;

				//他の処理モードを設定する必要がある場合、次の行は修正する必要があります
				commandInfo.ActionMode = "UPD";
				commandInfo.PageLoadMode = true;

				//プログラム初期化処理
				base.InitProgram();

				//フォーカス項目の指定
				NameValueCollection queryList = FormFocusUtil.TakeOverFocus(null, Context);

				// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
				// プログラムVOを取得
				Tm040p01PgForm pgForm = (Tm040p01PgForm)pageContext.GetParent();

				// 起動パラメータをリクエストから取得
				pgForm.Dictionary[Tm040p01Constant.DIC_FORM_ID] = Request.QueryString[OpenTm040p01Cls.PARAM_FORM_ID];					// 呼出元画面ID
				pgForm.Dictionary[Tm040p01Constant.DIC_CUR_ROW_CNT] = Request.QueryString[OpenTm040p01Cls.PARAM_CUR_ROW_CNT];			// 現在行数
				pgForm.Dictionary[Tm040p01Constant.DIC_MAX_ROW_CNT] = Request.QueryString[OpenTm040p01Cls.PARAM_MAX_ROW_CNT];			// 最大行数
				pgForm.Dictionary[Tm040p01Constant.DIC_TENPO_CD] = Request.QueryString[OpenTm040p01Cls.PARAM_TENPO_CD];					// 店舗コード
				pgForm.Dictionary[Tm040p01Constant.DIC_SIJI_BANGO] = Request.QueryString[OpenTm040p01Cls.PARAM_SIJI_BANGO];				// 指示番号
				pgForm.Dictionary[Tm040p01Constant.DIC_SYUKKA_KAISYA_CD] = Request.QueryString[OpenTm040p01Cls.PARAM_SYUKKA_KAISYA_CD];	// 出荷会社コード
				pgForm.Dictionary[Tm040p01Constant.DIC_JURYO_KAISYA_CD] = Request.QueryString[OpenTm040p01Cls.PARAM_JURYO_KAISYA_CD];	// 入荷会社コード
				pgForm.Dictionary[Tm040p01Constant.DIC_SYUKKA_TEN_CD] = Request.QueryString[OpenTm040p01Cls.PARAM_SYUKKA_TEN_CD];		// 出荷店コード
				pgForm.Dictionary[Tm040p01Constant.DIC_HOJUIRAI_KBN] = Request.QueryString[OpenTm040p01Cls.PARAM_HOJUIRAI_KBN];			// 補充依頼区分

				#region フォーカス制御
				// フォーカス設定用変数
				string focusItem = "Old_jisya_hbn";	// 自社品番
				string focusMno = string.Empty;

				// フォーカス設定
				queryList = SetFocusCls.SetFocus(queryList, focusItem, focusMno);
				#endregion
				// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

				//画面遷移をする
				base.Forward(pageContext, queryList);
			}
		}
		#endregion
		
		#endregion
	}
}
