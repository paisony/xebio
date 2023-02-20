using com.xebio.bo.Tf021p01.Constant;
using com.xebio.bo.Tf021p01.Facade;
using com.xebio.bo.Tf021p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.Model.Context;
using Common.Advanced.Resource;
using Common.Advanced.Web.Context;
using Common.Advanced.Web.Control;
using Common.Advanced.Web.Util;
using Common.Business.C01000.C01013;
using Common.Business.C01000.C01014;
using Common.Business.C01000.C01015;
using Common.Business.C01000.C01016;
using Common.Business.C01000.C01026;
using Common.Business.C99999.Constant;
using Common.Business.C99999.ReportUtil;
using Common.IntegrationMD.MDControl;
using Common.IntegrationMD.Util;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Session;
using Common.Standard.Util;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Tf021p01.Page
{
  /// <summary>
  /// Tf021f01のコードビハインドです。
  /// </summary>
  public partial class Tf021f01Page : StandardBasePage
	{

		#region メソッド

		#region ページデータをロードするメソッド
		/// <summary>
		/// Tf021f01画面データを作成する。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected new void Page_Load(object sender, System.EventArgs e)
		{
			IPageContext pageContext = null;
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".Page_Load");
			
			try
			{
				if(!IsPostBack)
				{
					//アクションコンテキスト取得
					pageContext = base.GetPageContext();
					ICommandInfo commandInfo=pageContext.CommandInfo;
					//画面初期化処理
					base.InitForm(pageContext);
					
					//画面データ初期化
					if(commandInfo.PageLoadMode && commandInfo.ActionMode!=null)
					{
						pageContext.SetFormVO(new Tf021f01Form());
						switch(commandInfo.ActionMode)
						{
							case "ADD":
								break;
							case "INI": //メニューから遷移時
							case "DEL":
							case "UPD":
								IFacadeContext facadeContext =
									FacadeContextFactory.GetFacadeContext(pageContext);
								InitFacadeContext(facadeContext);
								new Tf021f01Facade().DoLoad(facadeContext);

								#region 共通ヘッダ処理

								// 一覧画面共通処理 ----------
								LoginInfoVO loginInfVO = LoginInfoUtil.GetLoginInfo();
								Tf021f01Form tf021f01Form = (Tf021f01Form)facadeContext.FormVO;
								ControlHeaderStoreCls.InitialSetHeaderStore<Tf021f01Form>(loginInfVO, tf021f01Form);
								// 一覧画面共通処理 ----------

								// 初期表示時のモードとアコーディオン状態を設定
								if (string.IsNullOrEmpty(tf021f01Form.Modeno))
								{
									// アコーディオンなし
									AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_NONE);
									// モードNoを申請に設定
									tf021f01Form.Modeno = BoSystemConstant.MODE_APPLY;
									TabUtil.SetTabNumber(pageContext, BoSystemConstant.MODE_APPLY);
								}

								#endregion

								break;
						}
					}
				}
				else
				{
					//メッセージの初期化
					base.InitMessage();
				}

				// 単一ファイルダウンロード処理
				if (SessionInfoUtil.GetPgObject(base.GetPageContext().CommandInfo.ProgramId, Tf021p01Constant.SESSION_KEY_DOWNLOAD_INFO, Session) != null)
				{
					// ダウンロード情報取得
					DLConditionVO dlVO = SessionInfoUtil.GetPgObject(base.GetPageContext().CommandInfo.ProgramId, Tf021p01Constant.SESSION_KEY_DOWNLOAD_INFO, Session) as DLConditionVO;

					// セッション削除
					SessionInfoUtil.RemovePgObject(Tf021p01Constant.SESSION_KEY_DOWNLOAD_INFO, base.GetPageContext());

					base.DownloadPageStartUp(base.GetPageContext(), dlVO);
				}

				// モードNoをセッションに格納
				if (base.GetPageContext() != null)
				{
					FormVOManager fvm = new FormVOManager(Session);
					Tf021f01Form f01VO = (Tf021f01Form)fvm.GetProgramVO(base.GetPageContext().CommandInfo.ProgramId).GetFormVO(Tf021p01Constant.FORMID_01);
					TabUtil.SetTabNumber(base.GetPageContext(), f01VO.Modeno);
				}
				
				/*
				*明細スクロール位置情報登録処理を行います。
				*機能有効させる場合は、コメントアウトを外してください。
				*/
				////保持したい明細スクロールのパネルIDを作成する
				//string[] detailPanelId = { , , };
				////保持したい明細スクロールのパネルIDを部品に登録する
				//ScrollRelationship.RegisterRelations(base.GetPageContext(), detailPanelId);

				// ファイルダウンロード
				if (SessionInfoUtil.GetPgObject(BoSystemConstant.SESSION_KEY_DOWNLOAD_VO, base.GetPageContext()) != null)
				{
					// ダウンロード用VOをセッションから取得
					DLConditionVO dlvo = SessionInfoUtil.GetPgObject(BoSystemConstant.SESSION_KEY_DOWNLOAD_VO, base.GetPageContext()) as DLConditionVO;

					// ダウンロード用VOをセッションから削除
					SessionInfoUtil.RemovePgObject(BoSystemConstant.SESSION_KEY_DOWNLOAD_VO, base.GetPageContext());

					base.DownloadPageStartUp(base.GetPageContext(), dlvo);
				}

				
				
			}
			catch (System.Exception ex)
			{
				ThrowException(ex, pageContext);
			}
			
			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".Page_Load");
		}
		#endregion

		#region フォームを呼び出します(ボタンID : Btninsert(新規作成))
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btninsert(新規作成))
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnBTNINSERT_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnBTNINSERT_FRM");
			IPageContext pageContext = null;
			//入力チェックに失敗した場合、何も処理せずに返します
			if (!base.DoValidate(sender))
			{
				//クライアントチェックエラー時、画面描画する
				SetItems();
				SetAttribute();
				//アクションコンテキストを取得する
				pageContext = base.GetPageContext();
				// 明細初期化処理
				Page.ClientScript.RegisterStartupScript(typeof(string), "InitialDetail", ControlCls.InitialDetail(pageContext));
				// アコーディオンなし
				AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_NONE);
				return;
			}

			//アクションコンテキストを取得する
			//IPageContext pageContext = base.GetPageContext();
			pageContext = base.GetPageContext();
			ICommandInfo commandInfo = pageContext.CommandInfo;
			
			try
			{

				//アクションロジックを処理します
				IFacadeContext facadeContext = FacadeContextFactory.GetFacadeContext(pageContext);
				InitFacadeContext(facadeContext);

				// 次画面のフォームVOをファサードに設定
				FormVOManager fvm = new FormVOManager(Session);
				facadeContext.SetUserObject(Tf021p01Constant.FCDUO_NEXTVO, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Tf021p01Constant.FORMID_02));

				new Tf021f01Facade().DoBTNINSERT_FRM(facadeContext);

				// 次画面のフォームビーンを設定
				fvm.SetFormVO(Tf021p01Constant.PGID, Tf021p01Constant.FORMID_02, (Tf021f02Form)facadeContext.GetUserObject(Tf021p01Constant.FCDUO_NEXTVO));

				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
					// アコーディオンなし
					AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_NONE);

					// モード表示クリア処理
					ModeUtil.ClearMode(pageContext);
					// 明細初期化処理
					Page.ClientScript.RegisterStartupScript(typeof(string), "InitialDetail", ControlCls.InitialDetail(pageContext));

					commandInfo.ActionMode = "INI";
					base.SetError(pageContext);
					return;
				}

				// モードを設定 
				ModeUtil.SetMode(pageContext, ModeCls.GetModeNm(((Tf021f01Form)pageContext.GetFormVO()).Stkmodeno));

				//遷移先の画面設定（入出力画面定義で設定した遷移先は初期化処理で設定済み）
				//入出力画面定義で設定した遷移先以外の画面に遷移する場合は以下のソースを
				//コメントインし、設定して下さい。
				//commandInfo.ToProgramId = "遷移先プログラムID";
				//commandInfo.ToFormId = "遷移先フォームID";
				
				//他の処理モードを設定する必要がある場合、次の行を修正してください
				commandInfo.ActionMode = "INI";
				commandInfo.PageLoadMode = false;
				
				//共通アクション
				base.DoCommonAction();
			}
			catch (System.Exception ex)
			{
				ThrowException(ex, pageContext);
				return;
			}
			
			//URLクエリ追加用NameValueCollection
			NameValueCollection queryList = new NameValueCollection();
			
			//フォーカスを当てる項目を指定したい場合はFormFocusUtilを使ってqueryListに追加すること
			
			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNINSERT_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Btnsearch(検索))
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnsearch(検索))
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnBTNSEARCH_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnBTNSEARCH_FRM");
			IPageContext pageContext = null;
			//入力チェックに失敗した場合、何も処理せずに返します
			if (!base.DoValidate(sender))
			{
				//クライアントチェックエラー時、画面描画する
				SetItems();
				SetAttribute();

				//アクションコンテキストを取得する
				pageContext = base.GetPageContext();
				// 明細初期化処理
				Page.ClientScript.RegisterStartupScript(typeof(string), "InitialDetail", ControlCls.InitialDetail(pageContext));
				// アコーディオンなし
				AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_NONE);

				return;
			}
			
			//アクションコンテキストを取得する
			//IPageContext pageContext = base.GetPageContext();
			pageContext = base.GetPageContext();
			ICommandInfo commandInfo = pageContext.CommandInfo;
			
			try
			{

				//アクションロジックを処理します
				IFacadeContext facadeContext = FacadeContextFactory.GetFacadeContext(pageContext);
				InitFacadeContext(facadeContext);
				new Tf021f01Facade().DoBTNSEARCH_FRM(facadeContext);
				
				
				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
					//アコーディオンを開いた状態で表示
					AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_NONE);

					pageContext = base.GetPageContext();
					// モード表示クリア処理
					ModeUtil.ClearMode(pageContext);
					// 明細初期化処理
					Page.ClientScript.RegisterStartupScript(typeof(string), "InitialDetail", ControlCls.InitialDetail(pageContext));

					commandInfo.ActionMode = "INI";
					base.SetError(pageContext);

					return;
				}

				//アコーディオンを閉じた状態で表示
				AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_CLOSE);

				//アコーディオンを閉じた際に表示される検索条件を設定する。
				AccordionUtil.ResetSearchCondition(pageContext);

				// モードを設定 
				ModeUtil.SetMode(pageContext, ModeCls.GetModeNm(((Tf021f01Form)pageContext.GetFormVO()).Stkmodeno));

				//遷移先の画面設定（入出力画面定義で設定した遷移先は初期化処理で設定済み）
				//入出力画面定義で設定した遷移先以外の画面に遷移する場合は以下のソースを
				//コメントインし、設定して下さい。
				//commandInfo.ToProgramId = "遷移先プログラムID";
				//commandInfo.ToFormId = "遷移先フォームID";
				
				//他の処理モードを設定する必要がある場合、次の行を修正してください
				commandInfo.ActionMode = "UPD";
				commandInfo.PageLoadMode = false;
				
				//共通アクション
				base.DoCommonAction();
			}
			catch (System.Exception ex)
			{
				ThrowException(ex, pageContext);
				return;
			}
			
			//URLクエリ追加用NameValueCollection
			NameValueCollection queryList = new NameValueCollection();
			
			//フォーカスを当てる項目を指定したい場合はFormFocusUtilを使ってqueryListに追加すること

			// フォーカス設定用変数
			string focusItem = string.Empty;
			string focusMno = string.Empty;

			// 表示明細先頭の伝票番号にフォーカス設定
			Tf021f01Form formVo = (Tf021f01Form)base.GetPageContext().GetFormVO();
			IList m1DataList = formVo.GetPageViewList("M1");
			Tf021f01M1Form tf010f01M1Form = (Tf021f01M1Form)m1DataList[0];

			// テーブル区分が０（経費振替予定テーブルの場合）
			if ("0".Equals(tf010f01M1Form.Dictionary[Tf021p01Constant.DIC_M1TBLFLG].ToString()))
			{
				focusItem = "M1kanri_no";
			}
			else
			{
				focusItem = "M1denpyo_bango";
			}
			focusMno = 0.ToString();

			// フォーカス設定
			queryList = SetFocusCls.SetFocus(queryList, focusItem, focusMno);

			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNSEARCH_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Btnprint())
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnprint())
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnBTNPRINT_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnBTNPRINT_FRM");
			//入力チェックに失敗した場合、何も処理せずに返します
			if (!base.DoValidate(sender))
			{
				//クライアントチェックエラー時、画面描画する
				SetItems();
				SetAttribute();
				return;
			}
			
			//アクションコンテキストを取得する
			IPageContext pageContext = base.GetPageContext();
			ICommandInfo commandInfo = pageContext.CommandInfo;

			DLConditionVO dlvo = new DLConditionVO();

			try
			{

				//アクションロジックを処理します
				IFacadeContext facadeContext = FacadeContextFactory.GetFacadeContext(pageContext);
				InitFacadeContext(facadeContext);
				new Tf021f01Facade().DoBTNPRINT_FRM(facadeContext);
				
				
				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
					base.SetError(pageContext);
					return;
				}
				
				//遷移先の画面設定（入出力画面定義で設定した遷移先は初期化処理で設定済み）
				//入出力画面定義で設定した遷移先以外の画面に遷移する場合は以下のソースを
				//コメントインし、設定して下さい。
				//commandInfo.ToProgramId = "遷移先プログラムID";
				//commandInfo.ToFormId = "遷移先フォームID";
				
				//他の処理モードを設定する必要がある場合、次の行を修正してください
				commandInfo.ActionMode = "UPD";
				commandInfo.PageLoadMode = false;

				// 帳票名
				string chohyoNm = BoSystemConstant.REPORTNM_SYOHINKEIHIFURIKAEDENPYO_X;

				// サーバファイルフルパス
				string serverPath = string.Format("{0}{1}{2}",
												FilePathManager.GetOutFilePath(Tf021p01Constant.PGID),
												Path.DirectorySeparatorChar,
												(string)facadeContext.GetUserObject(Tf021p01Constant.FCDUO_RRT_FLNM)
												);
				// クライアントファイル名
				string clientNm = string.Format("{0}.{1}",
												BoSystemReport.CreateFileName(chohyoNm, 2),
												BoSystemConstant.RPT_PDF_EXTENSION
												);
				// ダウンロード用VOに値を設定
				dlvo.setSingleFileDownloadCondition(serverPath, clientNm);

				// ダウンロード用VOをセッションに格納
				SessionInfoUtil.SetPgObject(BoSystemConstant.SESSION_KEY_DOWNLOAD_VO, dlvo, pageContext);

				//共通アクション
				base.DoCommonAction();
			}
			catch (System.Exception ex)
			{
				ThrowException(ex, pageContext);
				return;
			}
			
			//URLクエリ追加用NameValueCollection
			NameValueCollection queryList = new NameValueCollection();
			
			//フォーカスを当てる項目を指定したい場合はFormFocusUtilを使ってqueryListに追加すること

			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNPRINT_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
			//base.DownloadPageStartUp(pageContext, dlvo);
		}
		#endregion
		
		#region M1明細部のページング処理を実行します。(ボタンID : Pgr())
		/// <summary>
		/// M1明細部のページング処理を実行します。
		/// ボタンID(Pgr())
		/// アクションID(PGN)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.Web.UI.WebControls.DataGridPageChangedEventArg</param>
		protected virtual void OnPGR_PGN(object sender, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnPGR_PGN");
			//入力チェックに失敗した場合、何も処理せずに返します
			if (!base.DoValidate(sender))
			{
				//クライアントチェックエラー時、画面描画する
				SetItems();
				SetAttribute();
				return;
			}
			
			//アクションコンテキストを取得する
			IPageContext pageContext = base.GetPageContext();
			ICommandInfo commandInfo = pageContext.CommandInfo;
			
			try
			{

				//アクションロジックを処理します
				int pageindex = e.NewPageIndex + 1;
				IFacadeContext facadeContext = FacadeContextFactory.GetFacadeContext(pageContext);
				InitFacadeContext(facadeContext);
				new Tf021f01Facade().DoPGR_PGN(facadeContext, pageindex);
				
				
				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
					base.SetError(pageContext);
					return;
				}
				
				//遷移先の画面設定（入出力画面定義で設定した遷移先は初期化処理で設定済み）
				//入出力画面定義で設定した遷移先以外の画面に遷移する場合は以下のソースを
				//コメントインし、設定して下さい。
				//commandInfo.ToProgramId = "遷移先プログラムID";
				//commandInfo.ToFormId = "遷移先フォームID";
				
				//他の処理モードを設定する必要がある場合、次の行を修正してください
				commandInfo.PageLoadMode = false;
				
				//共通アクション
				base.DoCommonAction();
			}
			catch (System.Exception ex)
			{
				ThrowException(ex, pageContext);
				return;
			}
			
			//URLクエリ追加用NameValueCollection
			NameValueCollection queryList = new NameValueCollection();
			
			//フォーカスを当てる項目を指定したい場合はFormFocusUtilを使ってqueryListに追加すること
			
			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnPGR_PGN");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : M1denpyo_bango(伝票番号))
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(M1denpyo_bango(伝票番号))
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnM1DENPYO_BANGO_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnM1DENPYO_BANGO_FRM");
			//入力チェックに失敗した場合、何も処理せずに返します
			if (!base.DoValidate(sender))
			{
				//クライアントチェックエラー時、画面描画する
				SetItems();
				SetAttribute();
				return;
			}
			
			//アクションコンテキストを取得する
			IPageContext pageContext = base.GetPageContext();
			ICommandInfo commandInfo = pageContext.CommandInfo;
			
			try
			{

				//アクションロジックを処理します
				IFacadeContext facadeContext = FacadeContextFactory.GetFacadeContext(pageContext);
				InitFacadeContext(facadeContext);

				// 次画面のフォームVOをファサードに設定
				FormVOManager fvm = new FormVOManager(Session);
				facadeContext.SetUserObject(Tf021p01Constant.FCDUO_NEXTVO, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Tf021p01Constant.FORMID_02));

				new Tf021f01Facade().DoM1DENPYO_BANGO_FRM(facadeContext);

				// 次画面のフォームビーンを設定
				fvm.SetFormVO(Tf021p01Constant.PGID, Tf021p01Constant.FORMID_02, (Tf021f02Form)facadeContext.GetUserObject(Tf021p01Constant.FCDUO_NEXTVO));

				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
					base.SetError(pageContext);
					return;
				}
				
				//遷移先の画面設定（入出力画面定義で設定した遷移先は初期化処理で設定済み）
				//入出力画面定義で設定した遷移先以外の画面に遷移する場合は以下のソースを
				//コメントインし、設定して下さい。
				//commandInfo.ToProgramId = "遷移先プログラムID";
				//commandInfo.ToFormId = "遷移先フォームID";
				
				//他の処理モードを設定する必要がある場合、次の行を修正してください
				commandInfo.ActionMode = "INI";
				commandInfo.PageLoadMode = false;
				
				//共通アクション
				base.DoCommonAction();
			}
			catch (System.Exception ex)
			{
				ThrowException(ex, pageContext);
				return;
			}
			
			//URLクエリ追加用NameValueCollection
			NameValueCollection queryList = new NameValueCollection();
			
			//フォーカスを当てる項目を指定したい場合はFormFocusUtilを使ってqueryListに追加すること
			
			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnM1DENPYO_BANGO_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion

		#region フォームを呼び出します(ボタンID : M1kanri_no(管理No))
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(M1kanri_no(管理No))
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnM1KANRI_NO_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnM1KANRI_NO_FRM");
			//入力チェックに失敗した場合、何も処理せずに返します
			if (!base.DoValidate(sender))
			{
				//クライアントチェックエラー時、画面描画する
				SetItems();
				SetAttribute();
				return;
			}

			//アクションコンテキストを取得する
			IPageContext pageContext = base.GetPageContext();
			ICommandInfo commandInfo = pageContext.CommandInfo;

			try
			{

				//アクションロジックを処理します
				IFacadeContext facadeContext = FacadeContextFactory.GetFacadeContext(pageContext);
				InitFacadeContext(facadeContext);

				// 次画面のフォームVOをファサードに設定
				FormVOManager fvm = new FormVOManager(Session);
				facadeContext.SetUserObject(Tf021p01Constant.FCDUO_NEXTVO, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Tf021p01Constant.FORMID_02));

				new Tf021f01Facade().DoM1DENPYO_BANGO_FRM(facadeContext);
//				new Tf021f01Facade().DoM1KANRI_NO_FRM(facadeContext);

				// 次画面のフォームビーンを設定
				fvm.SetFormVO(Tf021p01Constant.PGID, Tf021p01Constant.FORMID_02, (Tf021f02Form)facadeContext.GetUserObject(Tf021p01Constant.FCDUO_NEXTVO));

				//エラー判定
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					base.SetError(pageContext);
					return;
				}

				//遷移先の画面設定（入出力画面定義で設定した遷移先は初期化処理で設定済み）
				//入出力画面定義で設定した遷移先以外の画面に遷移する場合は以下のソースを
				//コメントインし、設定して下さい。
				//commandInfo.ToProgramId = "遷移先プログラムID";
				//commandInfo.ToFormId = "遷移先フォームID";

				//他の処理モードを設定する必要がある場合、次の行を修正してください
				commandInfo.ActionMode = "INI";
				commandInfo.PageLoadMode = false;

				//共通アクション
				base.DoCommonAction();
			}
			catch (System.Exception ex)
			{
				ThrowException(ex, pageContext);
				return;
			}

			//URLクエリ追加用NameValueCollection
			NameValueCollection queryList = new NameValueCollection();

			//フォーカスを当てる項目を指定したい場合はFormFocusUtilを使ってqueryListに追加すること

			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnM1KANRI_NO_FRM");

			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion

		#region フォームを呼び出します(ボタンID : Btnenter(確定))
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnenter(確定))
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnBTNENTER_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnBTNENTER_FRM");
			//入力チェックに失敗した場合、何も処理せずに返します
			if (!base.DoValidate(sender))
			{
				//クライアントチェックエラー時、画面描画する
				SetItems();
				SetAttribute();
				return;
			}
			
			//アクションコンテキストを取得する
			IPageContext pageContext = base.GetPageContext();
			ICommandInfo commandInfo = pageContext.CommandInfo;

			DLConditionVO dlvo = new DLConditionVO();

			try
			{

				//アクションロジックを処理します
				IFacadeContext facadeContext = FacadeContextFactory.GetFacadeContext(pageContext);
				InitFacadeContext(facadeContext);
				new Tf021f01Facade().DoBTNENTER_FRM(facadeContext);
				
				
				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
					// 明細エラー背景色対応 ----- START
					//base.SetError(pageContext);
					// 明細エラー背景色対応 ----- END
					return;
				}
				
				//遷移先の画面設定（入出力画面定義で設定した遷移先は初期化処理で設定済み）
				//入出力画面定義で設定した遷移先以外の画面に遷移する場合は以下のソースを
				//コメントインし、設定して下さい。
				//commandInfo.ToProgramId = "遷移先プログラムID";
				//commandInfo.ToFormId = "遷移先フォームID";
				
				//他の処理モードを設定する必要がある場合、次の行を修正してください
				commandInfo.ActionMode = "INI";
				commandInfo.PageLoadMode = true;

				// 帳票名
				string chohyoNm = BoSystemConstant.REPORTNM_SYOHINKEIHIFURIKAEDENPYO_X;

				// サーバファイルフルパス
				string serverPath = string.Format("{0}{1}{2}",
												FilePathManager.GetOutFilePath(Tf021p01Constant.PGID),
												Path.DirectorySeparatorChar,
												(string)facadeContext.GetUserObject(Tf021p01Constant.FCDUO_RRT_FLNM)
												);
				// クライアントファイル名
				string clientNm = string.Format("{0}.{1}",
												BoSystemReport.CreateFileName(chohyoNm, 2),
												BoSystemConstant.RPT_PDF_EXTENSION
												);
				// ダウンロード用VOに値を設定
				dlvo.setSingleFileDownloadCondition(serverPath, clientNm);

				// 単一ダウンロード用にVOをセッションにセット
				SessionInfoUtil.SetPgObject(pageContext.CommandInfo.ProgramId, Tf021p01Constant.SESSION_KEY_DOWNLOAD_INFO, dlvo, Session);

				//共通アクション
				base.DoCommonAction();
			}
			catch (System.Exception ex)
			{
				ThrowException(ex, pageContext);
				return;
			}
			
			//URLクエリ追加用NameValueCollection
			NameValueCollection queryList = new NameValueCollection();
			
			//フォーカスを当てる項目を指定したい場合はFormFocusUtilを使ってqueryListに追加すること
			
			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNENTER_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		

		#region 画面にフォームデータを表示するメソッド

		#region フォームのデータを表示する
		/// <summary>
		/// フォームのデータを表示する。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected void RenderForm(object sender, System.EventArgs e)
		{
			if(!base.IsPostBack || base.IsPageValid)
			{
				//ページコンテキストを取得する
				IPageContext pageContext = base.GetPageContext();
				if(pageContext != null && pageContext.GetFormVO()!=null)
				{
					//if (!MessageDisplayUtil.HasError(pageContext))
					//{
						string lang = WebSettingsUtil.GetLangSettingFromSession(pageContext.Session);
						FormResource formResource =
							ResourceFactory.GetFormResource(pageContext.CommandInfo.FormId);
			
						//標題をセットする
						SetCaption(formResource, lang);

						//FormVOを取得する
						Tf021f01Form tf021f01Form = (Tf021f01Form)pageContext.GetFormVO();

						//明細ページ情報を表示する
						ShowListPageInfo(tf021f01Form);
			
						//明細部データを表示する
						RenderList(tf021f01Form, pageContext.FormInfo, formResource, lang);

						//カード部データを表示する
						RenderCard(tf021f01Form, pageContext.FormInfo, formResource, lang);
					//}

					// 明細エラー背景色対応 ----- START
					//エラー判定
					if (MessageDisplayUtil.HasError(FacadeContextFactory.GetFacadeContext(base.GetPageContext())))
					{
						base.SetError(base.GetPageContext());
					}
					// 明細エラー背景色対応 ----- END

					//共通フォームデータ表示処理
					base.DoCommonRenderForm();
				}
			}
		}
		#endregion

		#region 明細ページ情報を表示する
		#region 明細ページ情報を表示する
		/// <summary>
		/// 明細ページ情報を表示する。
		/// </summary>
		/// <param name="tf021f01Form">画面FormVO</param>
		private void ShowListPageInfo(Tf021f01Form tf021f01Form)
		{
			//M1明細ページ情報を表示する。
			ShowM1ListPageInfo(tf021f01Form.GetList("M1"));

		}
		#endregion
		
		#region M1明細ページ情報を表示する
		/// <summary>
		/// M1明細ページ情報を表示する。
		/// </summary>
		/// <param name="m1List">明細リスト</param>
		private void ShowM1ListPageInfo(IDataList m1List)
		{
			if(m1List == null)
			{
				return;
			}

			int startRow = m1List.StartRow;
			int endRow = m1List.EndRow;
			int recordCount = m1List.RecordCount;
			int dispRow=m1List.DispRow;

			//M1明細件数情報
			M1PageInfo.StartRow = startRow;
			M1PageInfo.EndRow = endRow;
			M1PageInfo.RecordCount = recordCount;
			M1PageInfo.PageNo = m1List.PageNo;
			M1PageInfo.PageCount = m1List.PageCount;

			//M1明細改ページ表示制御
			if (startRow > 1)
			{
			}
			else
			{
			}
			if(endRow < recordCount && recordCount != 0)
			{
			}
			else
			{
			}

			//M1明細ページ番号を設定する
			M1PageStartRow.Value = startRow.ToString();
		}
		#endregion
		#endregion

		#region 明細部データを表示する
		#region 明細部データを表示する
		/// <summary>
		/// 明細部データを表示する。
		/// </summary>
		/// <param name="tf021f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderList(
			Tf021f01Form tf021f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//画面のM1明細部データを設定する。
			RenderM1List(tf021f01Form, formInfo, formResource, lang);
			//M1明細部のページャーにページ情報を設定する。
			RenderM1Pager(tf021f01Form);
			
		}
		#endregion

		#region M1明細データを表示する
		/// <summary>
		/// M1明細データを表示する。
		/// </summary>
		/// <param name="tf021f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderM1List(
			Tf021f01Form tf021f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//M1明細部データソースを設定する。
			M1.DataSource = tf021f01Form.GetPageViewList("M1");
			M1.DataBind();

			//M1明細部データをフォーマットする。
			IList m1DataList = (IList)M1.DataSource;
			
			for (int index = 0; index < M1.Items.Count; index++)
			{
				Tf021f01M1Form tf021f01M1Form = (Tf021f01M1Form)m1DataList[index];
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1rowno"),
					DataFormatUtil.GetFormatItem(tf021f01M1Form.M1rowno,formInfo["M1rowno"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1add_ymd"),
					DataFormatUtil.GetFormatItem(tf021f01M1Form.M1add_ymd,formInfo["M1add_ymd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1apply_ymd"),
					DataFormatUtil.GetFormatItem(tf021f01M1Form.M1apply_ymd,formInfo["M1apply_ymd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1kakutei_ymd"),
					DataFormatUtil.GetFormatItem(tf021f01M1Form.M1kakutei_ymd,formInfo["M1kakutei_ymd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1kamoku_cd"),
					DataFormatUtil.GetFormatItem(tf021f01M1Form.M1kamoku_cd,formInfo["M1kamoku_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1kamoku_nm"),
					DataFormatUtil.GetFormatItem(tf021f01M1Form.M1kamoku_nm,formInfo["M1kamoku_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1itemsu"),
					DataFormatUtil.GetFormatItem(tf021f01M1Form.M1itemsu,formInfo["M1itemsu"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1genkakin"),
					DataFormatUtil.GetFormatItem(tf021f01M1Form.M1genkakin,formInfo["M1genkakin"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1baika_tnk"),
					DataFormatUtil.GetFormatItem(tf021f01M1Form.M1baika_tnk,formInfo["M1baika_tnk"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1sinseitan_nm"),
					DataFormatUtil.GetFormatItem(tf021f01M1Form.M1sinseitan_nm,formInfo["M1sinseitan_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1gyomuringi_no"),
					DataFormatUtil.GetFormatItem(tf021f01M1Form.M1gyomuringi_no,formInfo["M1gyomuringi_no"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1jyuri_no"),
					DataFormatUtil.GetFormatItem(tf021f01M1Form.M1jyuri_no,formInfo["M1jyuri_no"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1syonin_flg_nm"),
					DataFormatUtil.GetFormatItem(tf021f01M1Form.M1syonin_flg_nm,formInfo["M1syonin_flg_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1sinseiriyu"),
					DataFormatUtil.GetFormatItem(tf021f01M1Form.M1sinseiriyu,formInfo["M1sinseiriyu"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1kyakkariyu"),
					DataFormatUtil.GetFormatItem(tf021f01M1Form.M1kyakkariyu,formInfo["M1kyakkariyu"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1selectorcheckbox"),
					DataFormatUtil.GetFormatItem(tf021f01M1Form.M1selectorcheckbox,formInfo["M1selectorcheckbox"]));
				((System.Web.UI.WebControls.CheckBox)M1.Items[index].FindControl("M1selectorcheckbox")).Text =
					formResource.GetString("M1selectorcheckbox", lang);
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1entersyoriflg"),
					DataFormatUtil.GetFormatItem(tf021f01M1Form.M1entersyoriflg,formInfo["M1entersyoriflg"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1dtlirokbn"),
					DataFormatUtil.GetFormatItem(tf021f01M1Form.M1dtlirokbn,formInfo["M1dtlirokbn"]));

				if(!base.CheckUseSelfCustomize()){
					((System.Web.UI.HtmlControls.HtmlInputButton)M1.Items[index].FindControl("M1denpyo_bango")).Value =
						tf021f01M1Form.Dictionary[Tf021p01Constant.DIC_M1DENPYO_BANGO].ToString();
					((System.Web.UI.HtmlControls.HtmlInputButton)M1.Items[index].FindControl("M1kanri_no")).Value =
						tf021f01M1Form.Dictionary[Tf021p01Constant.DIC_M1KANRI_NO].ToString();

					// 明細背景色の設定
					DetailColorCls.DetailColorSet(M1, index);
				}
			}
			//M1明細部標題を設定する。
				// 多段明細を有効にする場合は、コメントアウトを外して、必要な情報を追加・修正してください。
				// 左辺は多段明細ヘッダ部のラベル情報を設定してください。
				// 右辺はカード部で定義した多段明細部の標題を設定してください。
				// if (M1.Items.Count > 0)
				// {
				// (M1.HeaderRow.FindControl("M1rowno") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1rowno", lang), base.GetPageContext().FormInfo["M1rowno"]);
				// (M1.HeaderRow.FindControl("M1add_ymd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1add_ymd", lang), base.GetPageContext().FormInfo["M1add_ymd"]);
				// (M1.HeaderRow.FindControl("M1apply_ymd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1apply_ymd", lang), base.GetPageContext().FormInfo["M1apply_ymd"]);
				// (M1.HeaderRow.FindControl("M1kakutei_ymd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kakutei_ymd", lang), base.GetPageContext().FormInfo["M1kakutei_ymd"]);
				// (M1.HeaderRow.FindControl("M1denpyo_bango") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1denpyo_bango", lang), base.GetPageContext().FormInfo["M1denpyo_bango"]);
				// (M1.HeaderRow.FindControl("M1kanri_no") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kanri_no", lang), base.GetPageContext().FormInfo["M1kanri_no"]);
				// (M1.HeaderRow.FindControl("M1kamoku_cd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kamoku_cd", lang), base.GetPageContext().FormInfo["M1kamoku_cd"]);
				// (M1.HeaderRow.FindControl("M1kamoku_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kamoku_nm", lang), base.GetPageContext().FormInfo["M1kamoku_nm"]);
				// (M1.HeaderRow.FindControl("M1itemsu") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1itemsu", lang), base.GetPageContext().FormInfo["M1itemsu"]);
				// (M1.HeaderRow.FindControl("M1genkakin") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1genkakin", lang), base.GetPageContext().FormInfo["M1genkakin"]);
				// (M1.HeaderRow.FindControl("M1baika_tnk") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1baika_tnk", lang), base.GetPageContext().FormInfo["M1baika_tnk"]);
				// (M1.HeaderRow.FindControl("M1sinseitan_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1sinseitan_nm", lang), base.GetPageContext().FormInfo["M1sinseitan_nm"]);
				// (M1.HeaderRow.FindControl("M1gyomuringi_no") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1gyomuringi_no", lang), base.GetPageContext().FormInfo["M1gyomuringi_no"]);
				// (M1.HeaderRow.FindControl("M1jyuri_no") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1jyuri_no", lang), base.GetPageContext().FormInfo["M1jyuri_no"]);
				// (M1.HeaderRow.FindControl("M1syonin_flg_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syonin_flg_nm", lang), base.GetPageContext().FormInfo["M1syonin_flg_nm"]);
				// (M1.HeaderRow.FindControl("M1sinseiriyu") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1sinseiriyu", lang), base.GetPageContext().FormInfo["M1sinseiriyu"]);
				// (M1.HeaderRow.FindControl("M1kyakkariyu") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kyakkariyu", lang), base.GetPageContext().FormInfo["M1kyakkariyu"]);
				// (M1.HeaderRow.FindControl("M1selectorcheckbox") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1selectorcheckbox", lang), base.GetPageContext().FormInfo["M1selectorcheckbox"]);
				// (M1.HeaderRow.FindControl("M1entersyoriflg") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1entersyoriflg", lang), base.GetPageContext().FormInfo["M1entersyoriflg"]);
				// (M1.HeaderRow.FindControl("M1dtlirokbn") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1dtlirokbn", lang), base.GetPageContext().FormInfo["M1dtlirokbn"]);
				// }

		}
		#endregion

		#region M1明細のページャーを表示する
		/// <summary>
		/// M1明細のページャーを表示する。
		/// </summary>
		/// <param name="tf021f01Form">画面FormVO</param>
		private void RenderM1Pager(Tf021f01Form tf021f01Form)
		{
			Pgr.VirtualItemCount = tf021f01Form.GetList("M1").RecordCount;
			Pgr.CurrentPageIndex = tf021f01Form.GetList("M1").PageNo - 1;
			Pgr.PageSize = tf021f01Form.GetList("M1").DispRow;
		}
		#endregion
		#endregion

		#region カードデータを表示する
		/// <summary>
		/// カードデータを表示する
		/// </summary>
		/// <param name="tf021f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderCard(
			Tf021f01Form tf021f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			
			ControlUtil.SetControlValue(Head_tenpo_cd,
				DataFormatUtil.GetFormatItem(tf021f01Form.Head_tenpo_cd,formInfo["Head_tenpo_cd"]));
			ControlUtil.SetControlValue(Head_tenpo_nm,
				DataFormatUtil.GetFormatItem(tf021f01Form.Head_tenpo_nm,formInfo["Head_tenpo_nm"]));
			ControlUtil.SetControlValue(Modeno,
				DataFormatUtil.GetFormatItem(tf021f01Form.Modeno,formInfo["Modeno"]));
			ControlUtil.SetControlValue(Stkmodeno,
				DataFormatUtil.GetFormatItem(tf021f01Form.Stkmodeno,formInfo["Stkmodeno"]));
			ControlUtil.SetControlValue(Syonin_flg,
				DataFormatUtil.GetFormatItem(tf021f01Form.Syonin_flg,formInfo["Syonin_flg"]));
			ControlUtil.SetControlValue(Add_ymd_from,
				DataFormatUtil.GetFormatItem(tf021f01Form.Add_ymd_from,formInfo["Add_ymd_from"]));
			ControlUtil.SetControlValue(Add_ymd_to,
				DataFormatUtil.GetFormatItem(tf021f01Form.Add_ymd_to,formInfo["Add_ymd_to"]));
			ControlUtil.SetControlValue(Apply_ymd_from,
				DataFormatUtil.GetFormatItem(tf021f01Form.Apply_ymd_from,formInfo["Apply_ymd_from"]));
			ControlUtil.SetControlValue(Apply_ymd_to,
				DataFormatUtil.GetFormatItem(tf021f01Form.Apply_ymd_to,formInfo["Apply_ymd_to"]));
			ControlUtil.SetControlValue(Kakutei_ymd_from,
				DataFormatUtil.GetFormatItem(tf021f01Form.Kakutei_ymd_from,formInfo["Kakutei_ymd_from"]));
			ControlUtil.SetControlValue(Kakutei_ymd_to,
				DataFormatUtil.GetFormatItem(tf021f01Form.Kakutei_ymd_to,formInfo["Kakutei_ymd_to"]));
			ControlUtil.SetControlValue(Kamoku_cd_from,
				DataFormatUtil.GetFormatItem(tf021f01Form.Kamoku_cd_from,formInfo["Kamoku_cd_from"]));
			ControlUtil.SetControlValue(Kamoku_nm_from,
				DataFormatUtil.GetFormatItem(tf021f01Form.Kamoku_nm_from,formInfo["Kamoku_nm_from"]));
			ControlUtil.SetControlValue(Kamoku_cd_to,
				DataFormatUtil.GetFormatItem(tf021f01Form.Kamoku_cd_to,formInfo["Kamoku_cd_to"]));
			ControlUtil.SetControlValue(Kamoku_nm_to,
				DataFormatUtil.GetFormatItem(tf021f01Form.Kamoku_nm_to,formInfo["Kamoku_nm_to"]));
			ControlUtil.SetControlValue(Sinseitan_cd,
				DataFormatUtil.GetFormatItem(tf021f01Form.Sinseitan_cd,formInfo["Sinseitan_cd"]));
			ControlUtil.SetControlValue(Sinseitan_nm,
				DataFormatUtil.GetFormatItem(tf021f01Form.Sinseitan_nm,formInfo["Sinseitan_nm"]));
			ControlUtil.SetControlValue(Denpyo_bango_from,
				DataFormatUtil.GetFormatItem(tf021f01Form.Denpyo_bango_from,formInfo["Denpyo_bango_from"]));
			ControlUtil.SetControlValue(Denpyo_bango_to,
				DataFormatUtil.GetFormatItem(tf021f01Form.Denpyo_bango_to,formInfo["Denpyo_bango_to"]));
			ControlUtil.SetControlValue(Kanri_no_from,
				DataFormatUtil.GetFormatItem(tf021f01Form.Kanri_no_from,formInfo["Kanri_no_from"]));
			ControlUtil.SetControlValue(Kanri_no_to,
				DataFormatUtil.GetFormatItem(tf021f01Form.Kanri_no_to,formInfo["Kanri_no_to"]));
			ControlUtil.SetControlValue(Gyomuringi_no_from,
				DataFormatUtil.GetFormatItem(tf021f01Form.Gyomuringi_no_from,formInfo["Gyomuringi_no_from"]));
			ControlUtil.SetControlValue(Gyomuringi_no_to,
				DataFormatUtil.GetFormatItem(tf021f01Form.Gyomuringi_no_to,formInfo["Gyomuringi_no_to"]));
			ControlUtil.SetControlValue(Jyuri_no_from,
				DataFormatUtil.GetFormatItem(tf021f01Form.Jyuri_no_from,formInfo["Jyuri_no_from"]));
			ControlUtil.SetControlValue(Jyuri_no_to,
				DataFormatUtil.GetFormatItem(tf021f01Form.Jyuri_no_to,formInfo["Jyuri_no_to"]));
			ControlUtil.SetControlValue(Searchcnt,
				DataFormatUtil.GetFormatItem(tf021f01Form.Searchcnt,formInfo["Searchcnt"]));

			if(!base.CheckUseSelfCustomize()){
				Btnheadtenpocd.Value = base.FormResourceGetString(formResource, "Btnheadtenpocd", lang);
				Btnmodeapply.InnerText = base.FormResourceGetString(formResource, "Btnmodeapply", lang);
				Btnmodesinseimaesyusei.InnerText = base.FormResourceGetString(formResource, "Btnmodesinseimaesyusei", lang);
				Btnmodesinseimaetorikesi.InnerText = base.FormResourceGetString(formResource, "Btnmodesinseimaetorikesi", lang);
				Btnmodesinseigotorikesi.InnerText = base.FormResourceGetString(formResource, "Btnmodesinseigotorikesi", lang);
				Btnmoderef.InnerText = base.FormResourceGetString(formResource, "Btnmoderef", lang);
				Btnkamokucd_from.Value = base.FormResourceGetString(formResource, "Btnkamokucd_from", lang);
				Btnkamokucd_to.Value = base.FormResourceGetString(formResource, "Btnkamokucd_to", lang);
				Btntanto_cd.Value = base.FormResourceGetString(formResource, "Btntanto_cd", lang);
				Btninsert.Value = base.FormResourceGetString(formResource, "Btninsert", lang);
				Btnsearch.Value = base.FormResourceGetString(formResource, "Btnsearch", lang);
				Btnprint.Value = base.FormResourceGetString(formResource, "Btnprint", lang);
				Pgr.Text = base.FormResourceGetString(formResource, "Pgr", lang);
				Btnenter.Value = base.FormResourceGetString(formResource, "Btnenter", lang);
			}

		}
		#endregion

		#region Items設定(ドロップダウンリストのItems)
		/// <summary>
		/// ドロップダウンリストのItemsを設定します。
		/// </summary>
		protected override void SetItems()
		{
			//
			// 値の追加（「全て」等）を実装して下さい。
			//
			// 承認状態に空白を追加
			if (!IsPostBack)
			{
				Syonin_flg.Items.Insert(0, new ListItem("", BoSystemConstant.DROPDOWNLIST_MISENTAKU));
			}
		}
		#endregion

		#region Attribute設定(Visible等の設定)
		/// <summary>
		/// コントロールのAttributeを設定します。
		/// </summary>
		protected override void SetAttribute()
		{
		
			/*
			 *明細スクロール位置情報生成処理を行います。
			 *機能有効させる場合は、コメントアウトを外してください。
			 */
			//ScrollRelationship.DrawRelations(this, base.GetPageContext());
			
			//
			// 明細部のヘッダ固定、明細列の表示・非表示を制御する部品です。
			// 機能有効する場合は、コメントアウトを外して、必要な情報を追加してください。
			// UIScreenController controller = new UIScreenController((Tf021f01Form)base.GetPageContext().GetFormVO());
			// controller.ChangeColumnsDisplayMode(M1 ,  new DetailHeaderFixedVO(M1Header , true) , null);

			/*
			 *登録した機能間連携処理を親画面に感知させる。
			 *機能有効させる場合は、コメントアウトを外してください。
			 */
			//DetailUtil.RunPgSyn(this,(StandardBaseForm)base.GetPageContext().GetFormVO());

			#region 共通ヘッダ表示制御
			LoginInfoVO loginInfVO = LoginInfoUtil.GetLoginInfo();
			ControlHeaderStoreCls.ControlSetHeaderStore(loginInfVO, Head_tenpo_cd, Btnheadtenpocd);
			#endregion

			#region 画面表示制御
			if (base.GetPageContext().CommandInfo.ActionMode.Equals("INI"))
			{
				// 明細ボタン部を非表示とする
				ControlCls.Visible(meisaiBtnArea, false);
				// フッター部を非表示とする
				ControlCls.Visible(footerBtnArea, false);
			}
			else
			{
				// 明細ボタン部を表示する
				ControlCls.Visible(meisaiBtnArea, true);
				// フッター部を表示する
				ControlCls.Visible(footerBtnArea, true);
			}

			Tf021f01Form formVo = (Tf021f01Form)base.GetPageContext().GetFormVO();
			IList m1DataList = formVo.GetPageViewList("M1");

			// ボタンの制御
			// [選択モードNo]が「照会」「申請前修正」の場合
			if (   BoSystemConstant.MODE_REF.Equals(formVo.Stkmodeno)
				|| BoSystemConstant.MODE_SINSEIMAEUPD.Equals(formVo.Stkmodeno))
			{
				// 確定ボタンを使用不可とする。
				ControlCls.Disable(Btnenter, true);
			}

			// [選択モードNo]が「照会」以外の場合
			if (!BoSystemConstant.MODE_REF.Equals(formVo.Stkmodeno))
			{
				// 印刷ボタンを使用不可とする。
				ControlCls.Disable(Btnprint, true);

			}

			// 明細部の制御
			for (int index = 0; index < M1.Items.Count; index++)
			{
				Tf021f01M1Form tf010f01M1Form = (Tf021f01M1Form)m1DataList[index];

				// [選択モードNo]が「申請」以外の場合
				if (!BoSystemConstant.MODE_APPLY.Equals(formVo.Stkmodeno))
				{
					ControlCls.Disable(((MDTextBox)M1.Items[index].FindControl("M1gyomuringi_no")), true);
				}

				// テーブル区分が０（経費振替予定テーブルの場合）
				if ("0".Equals(tf010f01M1Form.Dictionary[Tf021p01Constant.DIC_M1TBLFLG].ToString()))
				{
					ControlCls.Disable(((HtmlInputButton)M1.Items[index].FindControl("M1denpyo_bango")), true);
					// 伝票番号の文字色を黒にする。
					((HtmlInputButton)M1.Items[index].FindControl("M1denpyo_bango")).Style.Add("color", "black");

					// [選択モードNo]が「照会」の場合
					if (BoSystemConstant.MODE_REF.Equals(formVo.Stkmodeno))
					{
						((AdvancedCheckBox)M1.Items[index].FindControl("M1selectorcheckbox")).Visible = false;
					}

				}
				// それ以外（経費振替申請テーブル、経費振替確定テーブルの場合）
				else
				{
					ControlCls.Disable(((HtmlInputButton)M1.Items[index].FindControl("M1kanri_no")), true);
					// 管理番号の文字色を黒にする。
					((HtmlInputButton)M1.Items[index].FindControl("M1kanri_no")).Style.Add("color", "black");

				}
			}

			#endregion
		}
		#endregion
		#endregion

		#region 標題設定メソッド
		#region 標題を設定する
		/// <summary>
		/// 標題を設定する
		/// </summary>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void SetCaption(FormResource formResource, string lang)
		{
			if(!base.CheckUseSelfCustomize()){
				// カード部標題を設定する
				SetCardCaption(formResource, lang);
			}

			// 明細部標題を設定する
			SetListCaption(formResource, lang);

			// カード、明細以外の標題を設定する
			SetOtherCaption(formResource, lang);
		}
		#endregion

		#region カード部標題を設定する
		/// <summary>
		/// カード部標題を設定する
		/// </summary>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void SetCardCaption(FormResource formResource, string lang)
		{
			ControlUtil.SetControlValue(Head_tenpo_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Head_tenpo_cd", lang), base.GetPageContext().FormInfo["Head_tenpo_cd"]));
				DataFormatUtil.SetMustColorCaption(Head_tenpo_cd_lbl, base.GetPageContext().FormInfo["Head_tenpo_cd"]);
			ControlUtil.SetControlValue(Head_tenpo_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Head_tenpo_nm", lang), base.GetPageContext().FormInfo["Head_tenpo_nm"]));
				DataFormatUtil.SetMustColorCaption(Head_tenpo_nm_lbl, base.GetPageContext().FormInfo["Head_tenpo_nm"]);
			ControlUtil.SetControlValue(Syonin_flg_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Syonin_flg", lang), base.GetPageContext().FormInfo["Syonin_flg"]));
				DataFormatUtil.SetMustColorCaption(Syonin_flg_lbl, base.GetPageContext().FormInfo["Syonin_flg"]);
			//ControlUtil.SetControlValue(Add_ymd_from_lbl, 
			//	DataFormatUtil.GetFormatCaption(formResource.GetString("Add_ymd_from", lang), base.GetPageContext().FormInfo["Add_ymd_from"]));
			ControlUtil.SetControlValue(Add_ymd_from_lbl, "登録日");
				DataFormatUtil.SetMustColorCaption(Add_ymd_from_lbl, base.GetPageContext().FormInfo["Add_ymd_from"]);
			ControlUtil.SetControlValue(Add_ymd_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Add_ymd_to", lang), base.GetPageContext().FormInfo["Add_ymd_to"]));
				DataFormatUtil.SetMustColorCaption(Add_ymd_to_lbl, base.GetPageContext().FormInfo["Add_ymd_to"]);
			//ControlUtil.SetControlValue(Apply_ymd_from_lbl, 
			//	DataFormatUtil.GetFormatCaption(formResource.GetString("Apply_ymd_from", lang), base.GetPageContext().FormInfo["Apply_ymd_from"]));
			ControlUtil.SetControlValue(Apply_ymd_from_lbl, "申請日");
				DataFormatUtil.SetMustColorCaption(Apply_ymd_from_lbl, base.GetPageContext().FormInfo["Apply_ymd_from"]);
			ControlUtil.SetControlValue(Apply_ymd_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Apply_ymd_to", lang), base.GetPageContext().FormInfo["Apply_ymd_to"]));
				DataFormatUtil.SetMustColorCaption(Apply_ymd_to_lbl, base.GetPageContext().FormInfo["Apply_ymd_to"]);
			//ControlUtil.SetControlValue(Kakutei_ymd_from_lbl, 
			//	DataFormatUtil.GetFormatCaption(formResource.GetString("Kakutei_ymd_from", lang), base.GetPageContext().FormInfo["Kakutei_ymd_from"]));
			ControlUtil.SetControlValue(Kakutei_ymd_from_lbl, "確定日");
				DataFormatUtil.SetMustColorCaption(Kakutei_ymd_from_lbl, base.GetPageContext().FormInfo["Kakutei_ymd_from"]);
			ControlUtil.SetControlValue(Kakutei_ymd_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Kakutei_ymd_to", lang), base.GetPageContext().FormInfo["Kakutei_ymd_to"]));
				DataFormatUtil.SetMustColorCaption(Kakutei_ymd_to_lbl, base.GetPageContext().FormInfo["Kakutei_ymd_to"]);
			//ControlUtil.SetControlValue(Kamoku_cd_from_lbl, 
			//	DataFormatUtil.GetFormatCaption(formResource.GetString("Kamoku_cd_from", lang), base.GetPageContext().FormInfo["Kamoku_cd_from"]));
			ControlUtil.SetControlValue(Kamoku_cd_from_lbl, "科目");
				DataFormatUtil.SetMustColorCaption(Kamoku_cd_from_lbl, base.GetPageContext().FormInfo["Kamoku_cd_from"]);
			ControlUtil.SetControlValue(Kamoku_nm_from_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Kamoku_nm_from", lang), base.GetPageContext().FormInfo["Kamoku_nm_from"]));
				DataFormatUtil.SetMustColorCaption(Kamoku_nm_from_lbl, base.GetPageContext().FormInfo["Kamoku_nm_from"]);
			ControlUtil.SetControlValue(Kamoku_cd_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Kamoku_cd_to", lang), base.GetPageContext().FormInfo["Kamoku_cd_to"]));
				DataFormatUtil.SetMustColorCaption(Kamoku_cd_to_lbl, base.GetPageContext().FormInfo["Kamoku_cd_to"]);
			ControlUtil.SetControlValue(Kamoku_nm_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Kamoku_nm_to", lang), base.GetPageContext().FormInfo["Kamoku_nm_to"]));
				DataFormatUtil.SetMustColorCaption(Kamoku_nm_to_lbl, base.GetPageContext().FormInfo["Kamoku_nm_to"]);
			ControlUtil.SetControlValue(Sinseitan_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Sinseitan_cd", lang), base.GetPageContext().FormInfo["Sinseitan_cd"]));
				DataFormatUtil.SetMustColorCaption(Sinseitan_cd_lbl, base.GetPageContext().FormInfo["Sinseitan_cd"]);
			ControlUtil.SetControlValue(Sinseitan_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Sinseitan_nm", lang), base.GetPageContext().FormInfo["Sinseitan_nm"]));
				DataFormatUtil.SetMustColorCaption(Sinseitan_nm_lbl, base.GetPageContext().FormInfo["Sinseitan_nm"]);
			//ControlUtil.SetControlValue(Denpyo_bango_from_lbl, 
			//	DataFormatUtil.GetFormatCaption(formResource.GetString("Denpyo_bango_from", lang), base.GetPageContext().FormInfo["Denpyo_bango_from"]));
			ControlUtil.SetControlValue(Denpyo_bango_from_lbl, "伝票番号");
				DataFormatUtil.SetMustColorCaption(Denpyo_bango_from_lbl, base.GetPageContext().FormInfo["Denpyo_bango_from"]);
			ControlUtil.SetControlValue(Denpyo_bango_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Denpyo_bango_to", lang), base.GetPageContext().FormInfo["Denpyo_bango_to"]));
				DataFormatUtil.SetMustColorCaption(Denpyo_bango_to_lbl, base.GetPageContext().FormInfo["Denpyo_bango_to"]);
			//ControlUtil.SetControlValue(Kanri_no_from_lbl, 
			//	DataFormatUtil.GetFormatCaption(formResource.GetString("Kanri_no_from", lang), base.GetPageContext().FormInfo["Kanri_no_from"]));
			ControlUtil.SetControlValue(Kanri_no_from_lbl, "管理No");
				DataFormatUtil.SetMustColorCaption(Kanri_no_from_lbl, base.GetPageContext().FormInfo["Kanri_no_from"]);
			ControlUtil.SetControlValue(Kanri_no_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Kanri_no_to", lang), base.GetPageContext().FormInfo["Kanri_no_to"]));
				DataFormatUtil.SetMustColorCaption(Kanri_no_to_lbl, base.GetPageContext().FormInfo["Kanri_no_to"]);
			//ControlUtil.SetControlValue(Gyomuringi_no_from_lbl, 
			//	DataFormatUtil.GetFormatCaption(formResource.GetString("Gyomuringi_no_from", lang), base.GetPageContext().FormInfo["Gyomuringi_no_from"]));
			ControlUtil.SetControlValue(Gyomuringi_no_from_lbl, "業務稟議No");
				DataFormatUtil.SetMustColorCaption(Gyomuringi_no_from_lbl, base.GetPageContext().FormInfo["Gyomuringi_no_from"]);
			ControlUtil.SetControlValue(Gyomuringi_no_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Gyomuringi_no_to", lang), base.GetPageContext().FormInfo["Gyomuringi_no_to"]));
				DataFormatUtil.SetMustColorCaption(Gyomuringi_no_to_lbl, base.GetPageContext().FormInfo["Gyomuringi_no_to"]);
			//ControlUtil.SetControlValue(Jyuri_no_from_lbl, 
			//	DataFormatUtil.GetFormatCaption(formResource.GetString("Jyuri_no_from", lang), base.GetPageContext().FormInfo["Jyuri_no_from"]));
			ControlUtil.SetControlValue(Jyuri_no_from_lbl, "受理番号");
				DataFormatUtil.SetMustColorCaption(Jyuri_no_from_lbl, base.GetPageContext().FormInfo["Jyuri_no_from"]);
			ControlUtil.SetControlValue(Jyuri_no_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Jyuri_no_to", lang), base.GetPageContext().FormInfo["Jyuri_no_to"]));
				DataFormatUtil.SetMustColorCaption(Jyuri_no_to_lbl, base.GetPageContext().FormInfo["Jyuri_no_to"]);
			ControlUtil.SetControlValue(Searchcnt_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Searchcnt", lang), base.GetPageContext().FormInfo["Searchcnt"]));
				DataFormatUtil.SetMustColorCaption(Searchcnt_lbl, base.GetPageContext().FormInfo["Searchcnt"]);
		}
		#endregion

		#region 明細部標題を設定する
		/// <summary>
		/// 明細部標題を設定する
		/// </summary>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void SetListCaption(FormResource formResource, string lang)
		{
			SetM1ListCaption(formResource, lang);
		}
		#endregion

		#region M1明細部標題を設定する
		/// <summary>
		/// M1明細部標題を設定する
		/// </summary>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void SetM1ListCaption(FormResource formResource, string lang)
		{
			if(!base.CheckUseSelfCustomize()){
				// 多段明細を有効にするため、コメントアウトする。
				// M1.Columns[0].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1rowno", lang), base.GetPageContext().FormInfo["M1rowno"]);
				// M1.Columns[1].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1add_ymd", lang), base.GetPageContext().FormInfo["M1add_ymd"]);
				// M1.Columns[2].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1apply_ymd", lang), base.GetPageContext().FormInfo["M1apply_ymd"]);
				// M1.Columns[3].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kakutei_ymd", lang), base.GetPageContext().FormInfo["M1kakutei_ymd"]);
				// M1.Columns[4].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1denpyo_bango", lang), base.GetPageContext().FormInfo["M1denpyo_bango"]);
				// M1.Columns[5].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kanri_no", lang), base.GetPageContext().FormInfo["M1kanri_no"]);
				// M1.Columns[6].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kamoku_cd", lang), base.GetPageContext().FormInfo["M1kamoku_cd"]);
				// M1.Columns[7].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kamoku_nm", lang), base.GetPageContext().FormInfo["M1kamoku_nm"]);
				// M1.Columns[8].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1itemsu", lang), base.GetPageContext().FormInfo["M1itemsu"]);
				// M1.Columns[9].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1genkakin", lang), base.GetPageContext().FormInfo["M1genkakin"]);
				// M1.Columns[10].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1baika_tnk", lang), base.GetPageContext().FormInfo["M1baika_tnk"]);
				// M1.Columns[11].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1sinseitan_nm", lang), base.GetPageContext().FormInfo["M1sinseitan_nm"]);
				// M1.Columns[12].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1gyomuringi_no", lang), base.GetPageContext().FormInfo["M1gyomuringi_no"]);
				// M1.Columns[13].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1jyuri_no", lang), base.GetPageContext().FormInfo["M1jyuri_no"]);
				// M1.Columns[14].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syonin_flg_nm", lang), base.GetPageContext().FormInfo["M1syonin_flg_nm"]);
				// M1.Columns[15].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1sinseiriyu", lang), base.GetPageContext().FormInfo["M1sinseiriyu"]);
				// M1.Columns[16].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kyakkariyu", lang), base.GetPageContext().FormInfo["M1kyakkariyu"]);
				// M1.Columns[17].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1selectorcheckbox", lang), base.GetPageContext().FormInfo["M1selectorcheckbox"]);
				// M1.Columns[18].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1entersyoriflg", lang), base.GetPageContext().FormInfo["M1entersyoriflg"]);
				// M1.Columns[19].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1dtlirokbn", lang), base.GetPageContext().FormInfo["M1dtlirokbn"]);
			}
			M1PageInfo.Text = formResource.GetString("M1PageInfo", lang);
			M1PageInfo.NoRecord = formResource.GetString("M1PageInfoNoRec", lang);
		}
		#endregion

		#region カード、明細以外の標題を設定する
		/// <summary>
		/// カード、明細以外の標題を設定する
		/// </summary>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void SetOtherCaption(FormResource formResource, string lang)
		{
			//ウインドウタイトルをリソースファイルから取得するかチェック
			if (base.CheckWindowtitleResource())
			{
				Windowtitle.InnerText = formResource.GetString("Tf021f01_Titlebar", lang);
				header.FormName = formResource.GetString("Tf021f01_FormCaption", lang);
			}
		}
		#endregion
		#endregion
		#endregion

		
		#region OnInit のオーバーライド（画面多重起動制御） 
		/// <summary>
		/// 画面多重起動制御処理の登録を行います。
		/// <summary>
		protected override void OnInit(EventArgs e)
		{
			//画面多重起動制御のハンドラを設定します。画面多重起動制御が不要な場合はコメントアウトしてください。
			base.PreRequestActionEv += new System.EventHandler(CheckMultiWindowControlModule.DoExecute);
			
			base.OnInit(e);
		}
		#endregion
	}
}
