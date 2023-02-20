using com.xebio.bo.Tk010p01.Constant;
using com.xebio.bo.Tk010p01.Facade;
using com.xebio.bo.Tk010p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.Model.Context;
using Common.Advanced.Resource;
using Common.Advanced.Web.Context;
using Common.Advanced.Web.Control;
using Common.Advanced.Web.Util;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01013;
using Common.Business.C01000.C01014;
using Common.Business.C01000.C01015;
using Common.Business.C01000.C01016;
using Common.Business.C01000.C01026;
using Common.Business.C99999.Constant;
using Common.Business.C99999.ControlUtil;
using Common.Business.C99999.StringUtil;
using Common.Conditions;
using Common.IntegrationMD.Util;
using Common.Standard.Base;
using Common.Standard.Constant;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Session;
using Common.Standard.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Tk010p01.Page
{
  /// <summary>
  /// Tk010f01のコードビハインドです。
  /// </summary>
  public partial class Tk010f01Page : StandardBasePage
	{

		#region メソッド

		#region ページデータをロードするメソッド
		/// <summary>
		/// Tk010f01画面データを作成する。
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
						pageContext.SetFormVO(new Tk010f01Form());
						switch(commandInfo.ActionMode)
						{
							case "ADD":
								break;
							case "INI":	// メニューから遷移時
							case "DEL":
							case "UPD":
								IFacadeContext facadeContext =
									FacadeContextFactory.GetFacadeContext(pageContext);
								InitFacadeContext(facadeContext);
								new Tk010f01Facade().DoLoad(facadeContext);

								#region 共通ヘッダ処理

								// 一覧画面共通処理 ----------
								LoginInfoVO loginInfVO = LoginInfoUtil.GetLoginInfo();
								Tk010f01Form tk010f01Form = (Tk010f01Form)facadeContext.FormVO;
								ControlHeaderStoreCls.InitialSetHeaderStore<Tk010f01Form>(loginInfVO, tk010f01Form);
								// 一覧画面共通処理 ----------

								if (string.IsNullOrEmpty(tk010f01Form.Modeno))
								{
									// アコーディオンなし
									AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_NONE);
									// モードNoを確定に設定
									tk010f01Form.Modeno = BoSystemConstant.MODE_KAKUTEI.ToString();
									TabUtil.SetTabNumber(pageContext, BoSystemConstant.MODE_REF.ToString());
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

				// モードNoをセッションに格納
				if (base.GetPageContext() != null)
				{
					FormVOManager fvm = new FormVOManager(Session);
					Tk010f01Form f01VO = (Tk010f01Form)fvm.GetProgramVO(base.GetPageContext().CommandInfo.ProgramId).GetFormVO(Tk010p01Constant.FORMID_01);
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
				
				
			}
			catch (System.Exception ex)
			{
				ThrowException(ex, pageContext);
			}

			// 複数ファイルダウンロード処理
			if (SessionInfoUtil.GetPgObject(base.GetPageContext().CommandInfo.ProgramId, SessionKeyConstant.DOWNLOAD_FILE_LIST, Session) != null)
			{
				base.MultipleDownloadPageStartUp(base.GetPageContext());
			}
			
			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".Page_Load");
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
				//アクションコンテキストを取得する
				pageContext = base.GetPageContext();
				// モード表示クリア処理
				ModeUtil.ClearMode(pageContext);
				// 明細初期化処理
				Page.ClientScript.RegisterStartupScript(typeof(string), "InitialDetail", ControlCls.InitialDetail(pageContext));

				//クライアントチェックエラー時、画面描画する
				SetItems();
				SetAttribute();
				return;
			}
			
			//アクションコンテキストを取得する
			//IPageContext pageContext = base.GetPageContext();
			pageContext = base.GetPageContext();
			ICommandInfo commandInfo = pageContext.CommandInfo;
			
			try
			{
				// モード表示クリア処理
				ModeUtil.ClearMode(pageContext);

				//アクションロジックを処理します
				IFacadeContext facadeContext = FacadeContextFactory.GetFacadeContext(pageContext);
				InitFacadeContext(facadeContext);
				new Tk010f01Facade().DoBTNSEARCH_FRM(facadeContext);
				
				
				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
					//アコーディオンなし
					AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_NONE);

					base.SetError(pageContext);
					return;
				}

				//アコーディオンを閉じた状態で表示
				AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_CLOSE);
				//アコーディオンを閉じた際に表示される検索条件を設定する。
				AccordionUtil.ResetSearchCondition(pageContext);
				// モードを設定 
				ModeUtil.SetMode(pageContext, ModeCls.GetModeNm(((Tk010f01Form)pageContext.GetFormVO()).Stkmodeno));
				
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

			// 表示明細先頭の管理Noにフォーカス設定
			focusItem = "M1tenpo_cd";
			focusMno = (0).ToString();

			// フォーカス設定
			SetFocusCls.SetFocus(queryList, focusItem, focusMno);
			
			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNSEARCH_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Btnzenstk())
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnzenstk())
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnBTNZENSTK_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnBTNZENSTK_FRM");
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
				new Tk010f01Facade().DoBTNZENSTK_FRM(facadeContext);
				
				
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

			// 表示明細先頭の管理Noにフォーカス設定
			focusItem = "M1tenpo_cd";
			focusMno = (0).ToString();

			// フォーカス設定
			SetFocusCls.SetFocus(queryList, focusItem, focusMno);

			
			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNZENSTK_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Btnzenkjo())
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnzenkjo())
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnBTNZENKJO_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnBTNZENKJO_FRM");
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
				new Tk010f01Facade().DoBTNZENKJO_FRM(facadeContext);
				
				
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

			// 表示明細先頭の管理Noにフォーカス設定
			focusItem = "M1tenpo_cd";
			focusMno = (0).ToString();

			// フォーカス設定
			SetFocusCls.SetFocus(queryList, focusItem, focusMno);
						
			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNZENKJO_FRM");
			
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

			// PDFファイル名
			string pdfNm = string.Empty;
			
			try
			{

				//アクションロジックを処理します
				IFacadeContext facadeContext = FacadeContextFactory.GetFacadeContext(pageContext);
				InitFacadeContext(facadeContext);
				new Tk010f01Facade().DoBTNPRINT_FRM(facadeContext);

				// PDFファイル名を取得
				pdfNm = (string)facadeContext.GetUserObject(Tk010p01Constant.FCDUO_RRT_FLNM_2);
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

				#region 帳票出力処理
				//複数ダウンロード情報
				List<string> dlList = new List<string>();

				// PDFファイル名リスト取得
				dlList = facadeContext.GetUserObject(Tk010p01Constant.FCDUO_RRT_FLNM) as List<string>;

				// 複数ダウンロード用にファイル名をセッションにセット
				SessionInfoUtil.SetPgObject(pageContext.CommandInfo.ProgramId, SessionKeyConstant.DOWNLOAD_FILE_LIST, dlList, Session);
				#endregion

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

			//#region 帳票出力処理

			//DLConditionVO dlvo = new DLConditionVO();
			//// サーバファイルフルパス
			//string serverPath = string.Format("{0}{1}{2}",
			//								FilePathManager.GetOutFilePath(Tk010p01Constant.PGID),
			//								Path.DirectorySeparatorChar,
			//								pdfNm
			//								);
			//// クライアントファイル名
			//// 評価損確定一覧表
			//string clientNm = string.Format("{0}.{1}",
			//								BoSystemReport.CreateFileName(BoSystemConstant.REPORTNM_HYOKASONKAKUTEISYUKEIHYO, 2),
			//								BoSystemConstant.RPT_PDF_EXTENSION
			//								);

			//// ダウンロード用VOに値を設定
			//dlvo.setSingleFileDownloadCondition(serverPath, clientNm);

			//#endregion
			
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
				new Tk010f01Facade().DoPGR_PGN(facadeContext, pageindex);
				
				
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
		
		#region フォームを呼び出します(ボタンID : M1tenpo_cd(店舗))
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(M1tenpo_cd(店舗))
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnM1TENPO_CD_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnM1TENPO_CD_FRM");
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
				facadeContext.SetUserObject(Tk010p01Constant.FCDUO_NEXTVO, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Tk010p01Constant.FORMID_02));

				new Tk010f01Facade().DoM1TENPO_CD_FRM(facadeContext);

				// 次画面のフォームビーンを設定
				fvm.SetFormVO(Tk010p01Constant.PGID, Tk010p01Constant.FORMID_02, (Tk010f02Form)facadeContext.GetUserObject(Tk010p01Constant.FCDUO_NEXTVO));

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
			if (!BoSystemConstant.MODE_REF.Equals(Stkmodeno))
			{
				// フォーカス設定用変数
				string focusItem = string.Empty;
				string focusMno = string.Empty;

				focusItem = "M1scan_cd";
				focusMno = (0).ToString();

				// フォーカス設定
				SetFocusCls.SetFocus(queryList, focusItem, focusMno);
			}
			
			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnM1TENPO_CD_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : M1tenpo_nm())
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(M1tenpo_nm())
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnM1TENPO_NM_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnM1TENPO_NM_FRM");
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
				new Tk010f01Facade().DoM1TENPO_NM_FRM(facadeContext);
				
				
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
				commandInfo.PageLoadMode = true;
				
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
			EndMethod(sender, e, this.GetType().Name + ".OnM1TENPO_NM_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region データベース更新処理を行います(ボタンID : Btnenter(確定))
		/// <summary>
		/// データベース更新処理を行います。
		/// ボタンID(Btnenter(確定))
		/// アクションID(DBU)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnBTNENTER_DBU(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnBTNENTER_DBU");
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

				// 警告メッセージ判定
				if (this.Request[BoSystemConstant.WARNING_HDNITEM_NM] != null)
				{
					facadeContext.SetUserObject(BoSystemConstant.WARNING_FCD_KEY, BoSystemString.Nvl(this.Request[BoSystemConstant.WARNING_HDNITEM_NM], "0"));
				}

				new Tk010f01Facade().DoBTNENTER_DBU(facadeContext);

				// 警告判定
				if (InfoMsgCls.HasWarn(facadeContext))
				{
					// 警告判定
					String Script = InfoMsgCls.showLoadMsg(pageContext, 2, "Btnenter");
					Page.ClientScript.RegisterStartupScript(typeof(string), "infoDialog", Script);
					return;
				}
				
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
				commandInfo.PageLoadMode = true;
				
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
			EndMethod(sender, e, this.GetType().Name + ".OnBTNENTER_DBU");
			
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
						Tk010f01Form tk010f01Form = (Tk010f01Form)pageContext.GetFormVO();

						//明細ページ情報を表示する
						ShowListPageInfo(tk010f01Form);
			
						//明細部データを表示する
						RenderList(tk010f01Form, pageContext.FormInfo, formResource, lang);

						//カード部データを表示する
						RenderCard(tk010f01Form, pageContext.FormInfo, formResource, lang);
					//}
					
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
		/// <param name="tk010f01Form">画面FormVO</param>
		private void ShowListPageInfo(Tk010f01Form tk010f01Form)
		{
			//M1明細ページ情報を表示する。
			ShowM1ListPageInfo(tk010f01Form.GetList("M1"));

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
		/// <param name="tk010f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderList(
			Tk010f01Form tk010f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//画面のM1明細部データを設定する。
			RenderM1List(tk010f01Form, formInfo, formResource, lang);
			//M1明細部のページャーにページ情報を設定する。
			RenderM1Pager(tk010f01Form);
			
		}
		#endregion

		#region M1明細データを表示する
		/// <summary>
		/// M1明細データを表示する。
		/// </summary>
		/// <param name="tk010f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderM1List(
			Tk010f01Form tk010f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//M1明細部データソースを設定する。
			M1.DataSource = tk010f01Form.GetPageViewList("M1");
			M1.DataBind();

			//M1明細部データをフォーマットする。
			IList m1DataList = (IList)M1.DataSource;
			
			for (int index = 0; index < M1.Items.Count; index++)
			{
				Tk010f01M1Form tk010f01M1Form = (Tk010f01M1Form)m1DataList[index];
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1rowno"),
					DataFormatUtil.GetFormatItem(tk010f01M1Form.M1rowno,formInfo["M1rowno"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1apply_ymd"),
					DataFormatUtil.GetFormatItem(tk010f01M1Form.M1apply_ymd,formInfo["M1apply_ymd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1sinsei_kb_nm"),
					DataFormatUtil.GetFormatItem(tk010f01M1Form.M1sinsei_kb_nm,formInfo["M1sinsei_kb_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1syonin_flg_nm"),
					DataFormatUtil.GetFormatItem(tk010f01M1Form.M1syonin_flg_nm,formInfo["M1syonin_flg_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1kessai_flg_nm"),
					DataFormatUtil.GetFormatItem(tk010f01M1Form.M1kessai_flg_nm,formInfo["M1kessai_flg_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1notnb_suryo"),
					DataFormatUtil.GetFormatItem(tk010f01M1Form.M1notnb_suryo,formInfo["M1notnb_suryo"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1notnb_genka_kin"),
					DataFormatUtil.GetFormatItem(tk010f01M1Form.M1notnb_genka_kin,formInfo["M1notnb_genka_kin"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1nb_suryo"),
					DataFormatUtil.GetFormatItem(tk010f01M1Form.M1nb_suryo,formInfo["M1nb_suryo"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1nb_genka_kin"),
					DataFormatUtil.GetFormatItem(tk010f01M1Form.M1nb_genka_kin,formInfo["M1nb_genka_kin"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1tenpogokei_su"),
					DataFormatUtil.GetFormatItem(tk010f01M1Form.M1tenpogokei_su,formInfo["M1tenpogokei_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1tenpogokei_genka_kin"),
					DataFormatUtil.GetFormatItem(tk010f01M1Form.M1tenpogokei_genka_kin,formInfo["M1tenpogokei_genka_kin"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1selectorcheckbox"),
					DataFormatUtil.GetFormatItem(tk010f01M1Form.M1selectorcheckbox,formInfo["M1selectorcheckbox"]));
				((System.Web.UI.WebControls.CheckBox)M1.Items[index].FindControl("M1selectorcheckbox")).Text =
					formResource.GetString("M1selectorcheckbox", lang);
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1entersyoriflg"),
					DataFormatUtil.GetFormatItem(tk010f01M1Form.M1entersyoriflg,formInfo["M1entersyoriflg"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1dtlirokbn"),
					DataFormatUtil.GetFormatItem(tk010f01M1Form.M1dtlirokbn,formInfo["M1dtlirokbn"]));

				if(!base.CheckUseSelfCustomize()){
					((System.Web.UI.HtmlControls.HtmlInputButton)M1.Items[index].FindControl("M1tenpo_cd")).Value =
						tk010f01M1Form.Dictionary[Tk010p01Constant.DIC_M1TENPO_CD].ToString() + ' ' + tk010f01M1Form.Dictionary[Tk010p01Constant.DIC_M1TENPO_NM].ToString();
					// 明細背景色の設定
					DetailColorCls.DetailColorSet(M1, index);
					//((System.Web.UI.HtmlControls.HtmlInputButton)M1.Items[index].FindControl("M1tenpo_nm")).Value =
						//formResource.GetString("M1tenpo_nm", lang);
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
				// (M1.HeaderRow.FindControl("M1tenpo_cd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tenpo_cd", lang), base.GetPageContext().FormInfo["M1tenpo_cd"]);
				// (M1.HeaderRow.FindControl("M1tenpo_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tenpo_nm", lang), base.GetPageContext().FormInfo["M1tenpo_nm"]);
				// (M1.HeaderRow.FindControl("M1apply_ymd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1apply_ymd", lang), base.GetPageContext().FormInfo["M1apply_ymd"]);
				// (M1.HeaderRow.FindControl("M1sinsei_kb_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1sinsei_kb_nm", lang), base.GetPageContext().FormInfo["M1sinsei_kb_nm"]);
				// (M1.HeaderRow.FindControl("M1syonin_flg_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syonin_flg_nm", lang), base.GetPageContext().FormInfo["M1syonin_flg_nm"]);
				// (M1.HeaderRow.FindControl("M1kessai_flg_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kessai_flg_nm", lang), base.GetPageContext().FormInfo["M1kessai_flg_nm"]);
				// (M1.HeaderRow.FindControl("M1notnb_suryo") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1notnb_suryo", lang), base.GetPageContext().FormInfo["M1notnb_suryo"]);
				// (M1.HeaderRow.FindControl("M1notnb_genka_kin") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1notnb_genka_kin", lang), base.GetPageContext().FormInfo["M1notnb_genka_kin"]);
				// (M1.HeaderRow.FindControl("M1nb_suryo") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1nb_suryo", lang), base.GetPageContext().FormInfo["M1nb_suryo"]);
				// (M1.HeaderRow.FindControl("M1nb_genka_kin") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1nb_genka_kin", lang), base.GetPageContext().FormInfo["M1nb_genka_kin"]);
				// (M1.HeaderRow.FindControl("M1tenpogokei_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tenpogokei_su", lang), base.GetPageContext().FormInfo["M1tenpogokei_su"]);
				// (M1.HeaderRow.FindControl("M1tenpogokei_genka_kin") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tenpogokei_genka_kin", lang), base.GetPageContext().FormInfo["M1tenpogokei_genka_kin"]);
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
		/// <param name="tk010f01Form">画面FormVO</param>
		private void RenderM1Pager(Tk010f01Form tk010f01Form)
		{
			Pgr.VirtualItemCount = tk010f01Form.GetList("M1").RecordCount;
			Pgr.CurrentPageIndex = tk010f01Form.GetList("M1").PageNo - 1;
			Pgr.PageSize = tk010f01Form.GetList("M1").DispRow;
		}
		#endregion
		#endregion

		#region カードデータを表示する
		/// <summary>
		/// カードデータを表示する
		/// </summary>
		/// <param name="tk010f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderCard(
			Tk010f01Form tk010f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			
			ControlUtil.SetControlValue(Head_tenpo_cd,
				DataFormatUtil.GetFormatItem(tk010f01Form.Head_tenpo_cd,formInfo["Head_tenpo_cd"]));
			ControlUtil.SetControlValue(Head_tenpo_nm,
				DataFormatUtil.GetFormatItem(tk010f01Form.Head_tenpo_nm,formInfo["Head_tenpo_nm"]));
			ControlUtil.SetControlValue(Modeno,
				DataFormatUtil.GetFormatItem(tk010f01Form.Modeno,formInfo["Modeno"]));
			ControlUtil.SetControlValue(Stkmodeno,
				DataFormatUtil.GetFormatItem(tk010f01Form.Stkmodeno,formInfo["Stkmodeno"]));
			ControlUtil.SetControlValue(Hyokasonsyubetsu_kb,
				DataFormatUtil.GetFormatItem(tk010f01Form.Hyokasonsyubetsu_kb,formInfo["Hyokasonsyubetsu_kb"]));
			ControlUtil.SetControlValue(Syonin_flg,
				DataFormatUtil.GetFormatItem(tk010f01Form.Syonin_flg,formInfo["Syonin_flg"]));
			ControlUtil.SetControlValue(Kessai_flg,
				DataFormatUtil.GetFormatItem(tk010f01Form.Kessai_flg,formInfo["Kessai_flg"]));
			ControlUtil.SetControlValue(Sinsei_kb,
				DataFormatUtil.GetFormatItem(tk010f01Form.Sinsei_kb,formInfo["Sinsei_kb"]));
			ControlUtil.SetControlValue(Tenpo_cd_from,
				DataFormatUtil.GetFormatItem(tk010f01Form.Tenpo_cd_from,formInfo["Tenpo_cd_from"]));
			ControlUtil.SetControlValue(Tenpo_nm_from,
				DataFormatUtil.GetFormatItem(tk010f01Form.Tenpo_nm_from,formInfo["Tenpo_nm_from"]));
			ControlUtil.SetControlValue(Tenpo_cd_to,
				DataFormatUtil.GetFormatItem(tk010f01Form.Tenpo_cd_to,formInfo["Tenpo_cd_to"]));
			ControlUtil.SetControlValue(Tenpo_nm_to,
				DataFormatUtil.GetFormatItem(tk010f01Form.Tenpo_nm_to,formInfo["Tenpo_nm_to"]));
			ControlUtil.SetControlValue(Syori_ym,
				DataFormatUtil.GetFormatItem(tk010f01Form.Syori_ym,formInfo["Syori_ym"]));
			ControlUtil.SetControlValue(Searchcnt,
				DataFormatUtil.GetFormatItem(tk010f01Form.Searchcnt,formInfo["Searchcnt"]));
			ControlUtil.SetControlValue(Gokei_suryo,
				DataFormatUtil.GetFormatItem(tk010f01Form.Gokei_suryo,formInfo["Gokei_suryo"]));
			ControlUtil.SetControlValue(Genka_kin_gokei,
				DataFormatUtil.GetFormatItem(tk010f01Form.Genka_kin_gokei,formInfo["Genka_kin_gokei"]));

			if(!base.CheckUseSelfCustomize()){
				Btnheadtenpocd.Value = base.FormResourceGetString(formResource, "Btnheadtenpocd", lang);
				Btnmodekakutei.InnerText = base.FormResourceGetString(formResource, "Btnmodekakutei", lang);
				Btnmodeupd.InnerText = base.FormResourceGetString(formResource, "Btnmodeupd", lang);
				Btnmoderef.InnerText = base.FormResourceGetString(formResource, "Btnmoderef", lang);
				Btntenpocd_from.Value = base.FormResourceGetString(formResource, "Btntenpocd_from", lang);
				Btntenpocd_to.Value = base.FormResourceGetString(formResource, "Btntenpocd_to", lang);
				Btnsearch.Value = base.FormResourceGetString(formResource, "Btnsearch", lang);
				Btnzenstk.Value = base.FormResourceGetString(formResource, "Btnzenstk", lang);
				Btnzenkjo.Value = base.FormResourceGetString(formResource, "Btnzenkjo", lang);
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
			if (!IsPostBack)
			{
				// 評価損種別区分
				Hyokasonsyubetsu_kb.Items.Insert(0, new ListItem("", BoSystemConstant.DROPDOWNLIST_MISENTAKU));
				// 承認状態
				Syonin_flg.Items.Insert(0, new ListItem("", BoSystemConstant.DROPDOWNLIST_MISENTAKU));
				// 決裁状態
				Kessai_flg.Items.Insert(0, new ListItem("", BoSystemConstant.DROPDOWNLIST_MISENTAKU));
				// 申請区分
				Sinsei_kb.Items.Insert(0, new ListItem("", BoSystemConstant.DROPDOWNLIST_MISENTAKU));
			}

			#region 処理月
			// カード部
			Tk010f01Form f01VO = (Tk010f01Form)base.GetPageContext().GetFormVO();

			// 処理月ドロップダウン設定
			BoSystemControl.SetSyoriYm((DropDownList)FindControl("Syori_ym"), (string)f01VO.Dictionary[Tk010p01Constant.DIC_SYSDATE]);

			// 選択項目を表示
			Syori_ym.SelectedValue = f01VO.Syori_ym;
			#endregion

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
			// UIScreenController controller = new UIScreenController((Tk010f01Form)base.GetPageContext().GetFormVO());
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

			// 初期表示時
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

			// 選択モードによる分岐
			Tk010f01Form formVo = (Tk010f01Form)base.GetPageContext().GetFormVO();

			if (!BoSystemString.Nvl(formVo.Stkmodeno).Equals(BoSystemConstant.MODE_REF))
			{
				// [選択モードNo]が「照会」以外の場合、印刷ボタンをDisabledにする。
				ControlCls.Disable(Btnprint, true);
			}

			if (!BoSystemString.Nvl(formVo.Stkmodeno).Equals(BoSystemConstant.MODE_KAKUTEI))
			{
				// [選択モードNo]が「確定」以外の場合、確定ボタンをDisabledにする。
				ControlCls.Disable(Btnenter, true);
			}

			if (BoSystemString.Nvl(formVo.Stkmodeno).Equals(BoSystemConstant.MODE_UPD))
			{
				// [選択モードNo]が「修正」の場合、全選択、全解除ボタンをDisabledにする。
				ControlCls.Disable(Btnzenstk, true);
				ControlCls.Disable(Btnzenkjo, true);

			}

			IList m1DataList = formVo.GetPageViewList("M1");

			// 明細の入力項目を使用不可にする
			for (int i = 0; i < m1DataList.Count; i++)
			{
				Tk010f01M1Form f01m1VO = (Tk010f01M1Form)m1DataList[i];

				// 選択モードNoが「照会」の場合で、[決裁状態]＝[未決裁]の明細については、選択不可とする。
				if (BoSystemString.Nvl(formVo.Stkmodeno).Equals(BoSystemConstant.MODE_REF))
				{
					if (ConditionKessai_jotai.VALUE_KESSAI_JOTAI1.Equals(f01m1VO.Dictionary[Tk010p01Constant.DIC_M1KESSAI_FLG].ToString()))
					{
						((AdvancedCheckBox)M1.Items[i].FindControl("M1selectorcheckbox")).Visible = false;
					}
				}

				// 明細リンクフラグが使用不可だった場合、明細リンクを使用不可とする
				if (Tk010p01Constant.MEISAI_LINK_FUKA_FLG.Equals(f01m1VO.Dictionary[Tk010p01Constant.DIC_M1LINKFLG].ToString()))
				{
					ControlCls.Disable((HtmlInputButton)M1.Items[i].FindControl("M1tenpo_cd"), true);
					// 行選択も不可
					((AdvancedCheckBox)M1.Items[i].FindControl("M1selectorcheckbox")).Visible = false;
				}


			}


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
			ControlUtil.SetControlValue(Hyokasonsyubetsu_kb_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Hyokasonsyubetsu_kb", lang), base.GetPageContext().FormInfo["Hyokasonsyubetsu_kb"]));
				DataFormatUtil.SetMustColorCaption(Hyokasonsyubetsu_kb_lbl, base.GetPageContext().FormInfo["Hyokasonsyubetsu_kb"]);
			ControlUtil.SetControlValue(Syonin_flg_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Syonin_flg", lang), base.GetPageContext().FormInfo["Syonin_flg"]));
				DataFormatUtil.SetMustColorCaption(Syonin_flg_lbl, base.GetPageContext().FormInfo["Syonin_flg"]);
			ControlUtil.SetControlValue(Kessai_flg_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Kessai_flg", lang), base.GetPageContext().FormInfo["Kessai_flg"]));
				DataFormatUtil.SetMustColorCaption(Kessai_flg_lbl, base.GetPageContext().FormInfo["Kessai_flg"]);
			ControlUtil.SetControlValue(Sinsei_kb_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Sinsei_kb", lang), base.GetPageContext().FormInfo["Sinsei_kb"]));
				DataFormatUtil.SetMustColorCaption(Sinsei_kb_lbl, base.GetPageContext().FormInfo["Sinsei_kb"]);
			// ControlUtil.SetControlValue(Tenpo_cd_from_lbl, 
				// DataFormatUtil.GetFormatCaption(formResource.GetString("Tenpo_cd_from", lang), base.GetPageContext().FormInfo["Tenpo_cd_from"]));
				ControlUtil.SetControlValue(Tenpo_cd_from_lbl, "店舗");
				DataFormatUtil.SetMustColorCaption(Tenpo_cd_from_lbl, base.GetPageContext().FormInfo["Tenpo_cd_from"]);
			ControlUtil.SetControlValue(Tenpo_nm_from_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Tenpo_nm_from", lang), base.GetPageContext().FormInfo["Tenpo_nm_from"]));
				DataFormatUtil.SetMustColorCaption(Tenpo_nm_from_lbl, base.GetPageContext().FormInfo["Tenpo_nm_from"]);
			ControlUtil.SetControlValue(Tenpo_cd_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Tenpo_cd_to", lang), base.GetPageContext().FormInfo["Tenpo_cd_to"]));
				DataFormatUtil.SetMustColorCaption(Tenpo_cd_to_lbl, base.GetPageContext().FormInfo["Tenpo_cd_to"]);
			ControlUtil.SetControlValue(Tenpo_nm_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Tenpo_nm_to", lang), base.GetPageContext().FormInfo["Tenpo_nm_to"]));
				DataFormatUtil.SetMustColorCaption(Tenpo_nm_to_lbl, base.GetPageContext().FormInfo["Tenpo_nm_to"]);
			ControlUtil.SetControlValue(Syori_ym_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Syori_ym", lang), base.GetPageContext().FormInfo["Syori_ym"]));
				DataFormatUtil.SetMustColorCaption(Syori_ym_lbl, base.GetPageContext().FormInfo["Syori_ym"]);
			ControlUtil.SetControlValue(Searchcnt_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Searchcnt", lang), base.GetPageContext().FormInfo["Searchcnt"]));
				DataFormatUtil.SetMustColorCaption(Searchcnt_lbl, base.GetPageContext().FormInfo["Searchcnt"]);
			ControlUtil.SetControlValue(Gokei_suryo_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Gokei_suryo", lang), base.GetPageContext().FormInfo["Gokei_suryo"]));
				DataFormatUtil.SetMustColorCaption(Gokei_suryo_lbl, base.GetPageContext().FormInfo["Gokei_suryo"]);
			ControlUtil.SetControlValue(Genka_kin_gokei_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Genka_kin_gokei", lang), base.GetPageContext().FormInfo["Genka_kin_gokei"]));
				DataFormatUtil.SetMustColorCaption(Genka_kin_gokei_lbl, base.GetPageContext().FormInfo["Genka_kin_gokei"]);
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
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tenpo_cd", lang), base.GetPageContext().FormInfo["M1tenpo_cd"]);
				// M1.Columns[2].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tenpo_nm", lang), base.GetPageContext().FormInfo["M1tenpo_nm"]);
				// M1.Columns[3].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1apply_ymd", lang), base.GetPageContext().FormInfo["M1apply_ymd"]);
				// M1.Columns[4].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1sinsei_kb_nm", lang), base.GetPageContext().FormInfo["M1sinsei_kb_nm"]);
				// M1.Columns[5].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syonin_flg_nm", lang), base.GetPageContext().FormInfo["M1syonin_flg_nm"]);
				// M1.Columns[6].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kessai_flg_nm", lang), base.GetPageContext().FormInfo["M1kessai_flg_nm"]);
				// M1.Columns[7].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1notnb_suryo", lang), base.GetPageContext().FormInfo["M1notnb_suryo"]);
				// M1.Columns[8].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1notnb_genka_kin", lang), base.GetPageContext().FormInfo["M1notnb_genka_kin"]);
				// M1.Columns[9].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1nb_suryo", lang), base.GetPageContext().FormInfo["M1nb_suryo"]);
				// M1.Columns[10].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1nb_genka_kin", lang), base.GetPageContext().FormInfo["M1nb_genka_kin"]);
				// M1.Columns[11].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tenpogokei_su", lang), base.GetPageContext().FormInfo["M1tenpogokei_su"]);
				// M1.Columns[12].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tenpogokei_genka_kin", lang), base.GetPageContext().FormInfo["M1tenpogokei_genka_kin"]);
				// M1.Columns[13].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1selectorcheckbox", lang), base.GetPageContext().FormInfo["M1selectorcheckbox"]);
				// M1.Columns[14].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1entersyoriflg", lang), base.GetPageContext().FormInfo["M1entersyoriflg"]);
				// M1.Columns[15].HeaderText = 
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
				Windowtitle.InnerText = formResource.GetString("Tk010f01_Titlebar", lang);
				header.FormName = formResource.GetString("Tk010f01_FormCaption", lang);
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
