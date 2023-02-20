using com.xebio.bo.Tg070p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.Web.Context;
using Common.Business.C01000.C01008;
using Common.Business.C01000.C01014;
using Common.Standard.Base;
using Common.Standard.Form;
using Common.Standard.Login;
using System.Collections.Specialized;

namespace com.xebio.bo.Tg070p01.Page
{
  /// <summary>
  /// Tg070p01の初期化ページです。
  /// </summary>
  public partial class Tg070p01InitPage : StandardBasePage
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
				fm.SetProgramVO(pgId, new Tg070p01PgForm());

				if(base.CheckUseSelfCustomize()){
					//項目拡張機能をしたい場合はまず下の行を有効にして下さい。
					//セルフカスタマイズを使用する場合も下の行を有効にしてください。
					//ExtItemInfoManager eim = new ExtItemInfoManager(pageContext.Session);
					//ExtItemInfoFlgManager efm = new ExtItemInfoFlgManager(pageContext.Session);

					//このプログラムに属する画面の項目情報を拡張したい場合、下の行を有効に
					//して下さい。
					//セルフカスタマイズを使用する場合も下の行を有効にしてください。
					//efm.SetItemInfoFlg(pgId, "Tg070f01", true);
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
				commandInfo.ActionMode = "INI";
				commandInfo.PageLoadMode = true;

				//プログラム初期化処理
				base.InitProgram();

				#region 画面表示


				#endregion

				#region フォーカス制御
				LoginInfoVO loginInfVo = LoginInfoUtil.GetLoginInfo();

				// フォーカス設定用変数
				string focusItem = string.Empty;
				string focusMno = string.Empty;

				//フォーカス項目の指定
				NameValueCollection queryList = FormFocusUtil.TakeOverFocus(null, Context);

				// 権限取得部品の戻り値が"TRUE"の場合
				if (!CheckKengenCls.CheckKengen(loginInfVo))
				{
					// [ヘッダ店舗コード]にフォーカスを当てる。
					focusItem = "Head_tenpo_cd";
				}
				// 権限取得部品の戻り値が"FALSE"の場合
				else
				{
					// [振替日付FROM]にフォーカスを当てる。
					focusItem = "Hurikae_ymd_from";
				}

				// フォーカス設定
				SetFocusCls.SetFocus(queryList, focusItem, focusMno);

				#endregion

				//画面遷移をする
				base.Forward(pageContext, queryList);
			}
		}
		#endregion
		
		#endregion
	}
}
