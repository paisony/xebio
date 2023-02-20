using com.xebio.bo.Tl030p01.Constant;
using com.xebio.bo.Tl030p01.Facade;
using com.xebio.bo.Tl030p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.Model.Context;
using Common.Advanced.Resource;
using Common.Advanced.Web.Context;
using Common.Advanced.Web.Control;
using Common.Advanced.Web.Util;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01008;
using Common.Business.C01000.C01013;
using Common.Business.C01000.C01014;
using Common.Business.C01000.C01015;
using Common.Business.C01000.C01016;
using Common.Business.C99999.Constant;
using Common.Business.C99999.LabelUtil;
using Common.Business.C99999.ReportUtil;
using Common.Business.C99999.StringUtil;
using Common.Conditions;
using Common.IntegrationMD.Util;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Session;
using Common.Standard.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Tl030p01.Page
{
  /// <summary>
  /// Tl030f01のコードビハインドです。
  /// </summary>
  public partial class Tl030f01Page : StandardBasePage
	{

		#region メソッド

		#region ページデータをロードするメソッド
		/// <summary>
		/// Tl030f01画面データを作成する。
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
						pageContext.SetFormVO(new Tl030f01Form());
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

								// クッキー値を取得
								BoSystemLabelUtil.GetCookieLabel(pageContext.Request, facadeContext);

								new Tl030f01Facade().DoLoad(facadeContext);

								#region 共通ヘッダ処理

								// 一覧画面共通処理 ----------
								LoginInfoVO loginInfVO = LoginInfoUtil.GetLoginInfo();
								Tl030f01Form tj130f01Form = (Tl030f01Form)facadeContext.FormVO;
								ControlHeaderStoreCls.InitialSetHeaderStore<Tl030f01Form>(loginInfVO, tj130f01Form);
								// 一覧画面共通処理 ----------

								// アコーディオンなし
								AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_NONE);

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
				
				/*
				*明細スクロール位置情報登録処理を行います。
				*機能有効させる場合は、コメントアウトを外してください。
				*/
				////保持したい明細スクロールのパネルIDを作成する
				//string[] detailPanelId = { , , };
				////保持したい明細スクロールのパネルIDを部品に登録する
				//ScrollRelationship.RegisterRelations(base.GetPageContext(), detailPanelId);

				if (pageContext != null)
				{
					// インフォメッセージ ----------------------------------------------------------------------		
					string infomsg = InfoMsgCls.GetWarningMsg(pageContext, Tl030p01Constant.PGID);
					if (!string.IsNullOrEmpty(infomsg))
					{
						// インフォメッセージが表示されている場合、表示する。
						Page.ClientScript.RegisterStartupScript(typeof(string), "infoDialog", infomsg);
					}
					// インフォメッセージ ----------------------------------------------------------------------		

					//if (Session[Tl030p01Constant.SESSION_SERVER_PATH] != null)
					//{
					//	// ToDo印刷処理テスト
					//	//DLConditionVO dlvo = new DLConditionVO();
					//	//dlvo.setSingleFileDownloadCondition(Session[Tl030p01Constant.SESSION_SERVER_PATH].ToString(), Session[Tl030p01Constant.SESSION_CLIENT_NM].ToString());
					//	//Session.Remove(Tl030p01Constant.SESSION_SERVER_PATH);
					//	//Session.Remove(Tl030p01Constant.SESSION_CLIENT_NM);

					//	base.DownloadPageStartUp(pageContext, dlvo);
					//}

					// 単一ファイルダウンロード処理
					if (SessionInfoUtil.GetPgObject(base.GetPageContext().CommandInfo.ProgramId, Tl030p01Constant.SESSION_KEY_DOWNLOAD_INFO, Session) != null)
					{
						// ダウンロード情報取得
						DLConditionVO dlVO = SessionInfoUtil.GetPgObject(base.GetPageContext().CommandInfo.ProgramId, Tl030p01Constant.SESSION_KEY_DOWNLOAD_INFO, Session) as DLConditionVO;

						// セッション削除
						SessionInfoUtil.RemovePgObject(Tl030p01Constant.SESSION_KEY_DOWNLOAD_INFO, base.GetPageContext());

						base.DownloadPageStartUp(base.GetPageContext(), dlVO);
					}

					// ラベル出力処理
					string labelmsg = BoSystemLabelUtil.GetScriptLabelPrint(pageContext, Tl030p01Constant.PGID);
					if (!string.IsNullOrEmpty(labelmsg))
					{
						// インフォメッセージが表示されている場合、表示する。
						Page.ClientScript.RegisterStartupScript(typeof(string), "SealPrint", labelmsg);
					}
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

				//アクションロジックを処理します
				IFacadeContext facadeContext = FacadeContextFactory.GetFacadeContext(pageContext);
				InitFacadeContext(facadeContext);

				new Tl030f01Facade().DoBTNSEARCH_FRM(facadeContext);
								
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
			focusItem = "M1bumon_cd";
			focusMno = (0).ToString();

			// フォーカス設定
			queryList = SetFocusCls.SetFocus(queryList, focusItem, focusMno);
			
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
				new Tl030f01Facade().DoBTNZENSTK_FRM(facadeContext);
				
				
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
				new Tl030f01Facade().DoBTNZENKJO_FRM(facadeContext);
				
				
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
			
			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNZENKJO_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
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
				new Tl030f01Facade().DoPGR_PGN(facadeContext, pageindex);
				
				
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
		
		#region フォームを呼び出します(ボタンID : M1bumon_cd(部門))
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(M1bumon_cd(部門))
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnM1BUMON_CD_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnM1BUMON_CD_FRM");
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
				facadeContext.SetUserObject(Tl030p01Constant.FCDUO_NEXTVO, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Tl030p01Constant.FORMID_02));
				new Tl030f01Facade().DoM1BUMON_CD_FRM(facadeContext);
				
				
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
			// フォーカス設定用変数
			string focusItem = string.Empty;
			string focusMno = string.Empty;

			// 表示明細先頭の管理Noにフォーカス設定
			focusItem = "M1kakuteibaika_tnk";
			focusMno = (0).ToString();

			// フォーカス設定
			SetFocusCls.SetFocus(queryList, focusItem, focusMno);
			
			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnM1BUMON_CD_FRM");
			
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


			// PDFファイル名
			string pdfNm = string.Empty;
			
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

				new Tl030f01Facade().DoBTNENTER_FRM(facadeContext);

				// 警告判定
				if (InfoMsgCls.HasWarn(facadeContext))
				{
					// 警告判定
					String Script = InfoMsgCls.showLoadMsg(pageContext, 2, "Btnenter");
					Page.ClientScript.RegisterStartupScript(typeof(string), "infoDialog", Script);
					return;
				}

				// インフォメッセージ ----------------------------------------------------------------------	
				// 情報判定	
				if (InfoMsgCls.HasInfo(facadeContext))
				{
					// インフォメッセージの表示
					InfoMsgCls.showLoadMsg(pageContext, 1, Tl030p01Constant.PGID);
				}
				// インフォメッセージ ----------------------------------------------------------------------	

				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
					base.SetError(pageContext);
					return;
				}

				// ラベル発行機の値をクッキーに登録
				Tl030f01Form f01VO = (Tl030f01Form)facadeContext.FormVO;
				BoSystemLabelUtil.SetCookieLabel(pageContext.Response, f01VO);

				// CSVファイル名を取得
				string csvNm = (string)facadeContext.GetUserObject(Tl030p01Constant.FCDUO_SEAL_CSVFLNM);

				// シールレイアウト
				List<string> layout = (List<string>)facadeContext.GetUserObject(Tl030p01Constant.FCDUO_SEAL_LAYOUTNM);

				// シール発行スクリプトの出力
				if (!string.IsNullOrEmpty(csvNm))
				{
					BoSystemLabelUtil.createScriptLabelPrint(pageContext, Tl030p01Constant.PGID, layout, csvNm);
				}

				//遷移先の画面設定（入出力画面定義で設定した遷移先は初期化処理で設定済み）
				//入出力画面定義で設定した遷移先以外の画面に遷移する場合は以下のソースを
				//コメントインし、設定して下さい。
				//commandInfo.ToProgramId = "遷移先プログラムID";
				//commandInfo.ToFormId = "遷移先フォームID";
				
				//他の処理モードを設定する必要がある場合、次の行を修正してください
				commandInfo.ActionMode = "INI";
				commandInfo.PageLoadMode = true;


				#region 帳票出力処理

				// PDFファイル名を取得
				pdfNm = (string)facadeContext.GetUserObject(Tl030p01Constant.FCDUO_RRT_FLNM);

				DLConditionVO dlvo = new DLConditionVO();
				// サーバファイルフルパス
				string serverPath = string.Format("{0}{1}{2}",
												FilePathManager.GetOutFilePath(Tl030p01Constant.PGID),
												Path.DirectorySeparatorChar,
												pdfNm
												);
				// クライアントファイル名
				string clientNm = string.Format("{0}.{1}",
												BoSystemReport.CreateFileName(BoSystemConstant.REPORTNM_BAIHENSAGYOSIJILIST_XV, 2),
												BoSystemConstant.RPT_PDF_EXTENSION
												);


				// ダウンロード用VOに値を設定
				dlvo.setSingleFileDownloadCondition(serverPath, clientNm);

				// 単一ダウンロード用にVOをセッションにセット
				SessionInfoUtil.SetPgObject(pageContext.CommandInfo.ProgramId, Tl030p01Constant.SESSION_KEY_DOWNLOAD_INFO, dlvo, Session);

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

			
			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNENTER_FRM");

			//画面遷移
			base.Forward(pageContext, queryList);
			//base.DownloadPageStartUp(pageContext, dlvo);
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
						Tl030f01Form tl030f01Form = (Tl030f01Form)pageContext.GetFormVO();

						//明細ページ情報を表示する
						ShowListPageInfo(tl030f01Form);
			
						//明細部データを表示する
						RenderList(tl030f01Form, pageContext.FormInfo, formResource, lang);

						//カード部データを表示する
						RenderCard(tl030f01Form, pageContext.FormInfo, formResource, lang);
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
		/// <param name="tl030f01Form">画面FormVO</param>
		private void ShowListPageInfo(Tl030f01Form tl030f01Form)
		{
			//M1明細ページ情報を表示する。
			ShowM1ListPageInfo(tl030f01Form.GetList("M1"));

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
		/// <param name="tl030f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderList(
			Tl030f01Form tl030f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//画面のM1明細部データを設定する。
			RenderM1List(tl030f01Form, formInfo, formResource, lang);
			//M1明細部のページャーにページ情報を設定する。
			RenderM1Pager(tl030f01Form);
			
		}
		#endregion

		#region M1明細データを表示する
		/// <summary>
		/// M1明細データを表示する。
		/// </summary>
		/// <param name="tl030f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderM1List(
			Tl030f01Form tl030f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//M1明細部データソースを設定する。
			M1.DataSource = tl030f01Form.GetPageViewList("M1");
			M1.DataBind();

			//M1明細部データをフォーマットする。
			IList m1DataList = (IList)M1.DataSource;
			
			for (int index = 0; index < M1.Items.Count; index++)
			{
				Tl030f01M1Form tl030f01M1Form = (Tl030f01M1Form)m1DataList[index];
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1rowno"),
					DataFormatUtil.GetFormatItem(tl030f01M1Form.M1rowno,formInfo["M1rowno"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1shinseimoto_nm"),
					DataFormatUtil.GetFormatItem(tl030f01M1Form.M1shinseimoto_nm,formInfo["M1shinseimoto_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1sinseitan_nm"),
					DataFormatUtil.GetFormatItem(tl030f01M1Form.M1sinseitan_nm,formInfo["M1sinseitan_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1baihen_shiji_no"),
					DataFormatUtil.GetFormatItem(tl030f01M1Form.M1baihen_shiji_no,formInfo["M1baihen_shiji_no"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1baihensagyokaisi_ymd"),
					DataFormatUtil.GetFormatItem(tl030f01M1Form.M1baihensagyokaisi_ymd,formInfo["M1baihensagyokaisi_ymd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1baihenkaisi_ymd"),
					DataFormatUtil.GetFormatItem(tl030f01M1Form.M1baihenkaisi_ymd,formInfo["M1baihenkaisi_ymd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1baihen_riyu_nm"),
					DataFormatUtil.GetFormatItem(tl030f01M1Form.M1baihen_riyu_nm,formInfo["M1baihen_riyu_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1hinban_su"),
					DataFormatUtil.GetFormatItem(tl030f01M1Form.M1hinban_su,formInfo["M1hinban_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1zaiko_su"),
					DataFormatUtil.GetFormatItem(tl030f01M1Form.M1zaiko_su,formInfo["M1zaiko_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1selectorcheckbox"),
					DataFormatUtil.GetFormatItem(tl030f01M1Form.M1selectorcheckbox,formInfo["M1selectorcheckbox"]));
				((System.Web.UI.WebControls.CheckBox)M1.Items[index].FindControl("M1selectorcheckbox")).Text =
					formResource.GetString("M1selectorcheckbox", lang);
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1entersyoriflg"),
					DataFormatUtil.GetFormatItem(tl030f01M1Form.M1entersyoriflg,formInfo["M1entersyoriflg"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1dtlirokbn"),
					DataFormatUtil.GetFormatItem(tl030f01M1Form.M1dtlirokbn,formInfo["M1dtlirokbn"]));

				if(!base.CheckUseSelfCustomize()){
					((System.Web.UI.HtmlControls.HtmlInputButton)M1.Items[index].FindControl("M1bumon_cd")).Value =
						tl030f01M1Form.Dictionary[Tl030p01Constant.DIC_M1BUMON_CD].ToString() + " " + tl030f01M1Form.Dictionary[Tl030p01Constant.DIC_M1BUMONKANA_NM].ToString();
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
				// (M1.HeaderRow.FindControl("M1shinseimoto_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1shinseimoto_nm", lang), base.GetPageContext().FormInfo["M1shinseimoto_nm"]);
				// (M1.HeaderRow.FindControl("M1sinseitan_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1sinseitan_nm", lang), base.GetPageContext().FormInfo["M1sinseitan_nm"]);
				// (M1.HeaderRow.FindControl("M1baihen_shiji_no") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1baihen_shiji_no", lang), base.GetPageContext().FormInfo["M1baihen_shiji_no"]);
				// (M1.HeaderRow.FindControl("M1bumon_cd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumon_cd", lang), base.GetPageContext().FormInfo["M1bumon_cd"]);
				// (M1.HeaderRow.FindControl("M1baihensagyokaisi_ymd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1baihensagyokaisi_ymd", lang), base.GetPageContext().FormInfo["M1baihensagyokaisi_ymd"]);
				// (M1.HeaderRow.FindControl("M1baihenkaisi_ymd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1baihenkaisi_ymd", lang), base.GetPageContext().FormInfo["M1baihenkaisi_ymd"]);
				// (M1.HeaderRow.FindControl("M1baihen_riyu_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1baihen_riyu_nm", lang), base.GetPageContext().FormInfo["M1baihen_riyu_nm"]);
				// (M1.HeaderRow.FindControl("M1hinban_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hinban_su", lang), base.GetPageContext().FormInfo["M1hinban_su"]);
				// (M1.HeaderRow.FindControl("M1zaiko_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1zaiko_su", lang), base.GetPageContext().FormInfo["M1zaiko_su"]);
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
		/// <param name="tl030f01Form">画面FormVO</param>
		private void RenderM1Pager(Tl030f01Form tl030f01Form)
		{
			Pgr.VirtualItemCount = tl030f01Form.GetList("M1").RecordCount;
			Pgr.CurrentPageIndex = tl030f01Form.GetList("M1").PageNo - 1;
			Pgr.PageSize = tl030f01Form.GetList("M1").DispRow;
		}
		#endregion
		#endregion

		#region カードデータを表示する
		/// <summary>
		/// カードデータを表示する
		/// </summary>
		/// <param name="tl030f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderCard(
			Tl030f01Form tl030f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			
			ControlUtil.SetControlValue(Head_tenpo_cd,
				DataFormatUtil.GetFormatItem(tl030f01Form.Head_tenpo_cd,formInfo["Head_tenpo_cd"]));
			ControlUtil.SetControlValue(Head_tenpo_nm,
				DataFormatUtil.GetFormatItem(tl030f01Form.Head_tenpo_nm,formInfo["Head_tenpo_nm"]));
			ControlUtil.SetControlValue(Sinseimoto,
				DataFormatUtil.GetFormatItem(tl030f01Form.Sinseimoto,formInfo["Sinseimoto"]));
			ControlUtil.SetControlValue(Bumon_cd_from,
				DataFormatUtil.GetFormatItem(tl030f01Form.Bumon_cd_from,formInfo["Bumon_cd_from"]));
			ControlUtil.SetControlValue(Bumon_nm_from,
				DataFormatUtil.GetFormatItem(tl030f01Form.Bumon_nm_from,formInfo["Bumon_nm_from"]));
			ControlUtil.SetControlValue(Bumon_cd_to,
				DataFormatUtil.GetFormatItem(tl030f01Form.Bumon_cd_to,formInfo["Bumon_cd_to"]));
			ControlUtil.SetControlValue(Bumon_nm_to,
				DataFormatUtil.GetFormatItem(tl030f01Form.Bumon_nm_to,formInfo["Bumon_nm_to"]));
			ControlUtil.SetControlValue(Sinseitan_cd,
				DataFormatUtil.GetFormatItem(tl030f01Form.Sinseitan_cd,formInfo["Sinseitan_cd"]));
			ControlUtil.SetControlValue(Sinseitan_nm,
				DataFormatUtil.GetFormatItem(tl030f01Form.Sinseitan_nm,formInfo["Sinseitan_nm"]));
			ControlUtil.SetControlValue(Baihen_shiji_no_from,
				DataFormatUtil.GetFormatItem(tl030f01Form.Baihen_shiji_no_from,formInfo["Baihen_shiji_no_from"]));
			ControlUtil.SetControlValue(Baihen_shiji_no_to,
				DataFormatUtil.GetFormatItem(tl030f01Form.Baihen_shiji_no_to,formInfo["Baihen_shiji_no_to"]));
			ControlUtil.SetControlValue(Baihensagyokaisi_ymd_from,
				DataFormatUtil.GetFormatItem(tl030f01Form.Baihensagyokaisi_ymd_from,formInfo["Baihensagyokaisi_ymd_from"]));
			ControlUtil.SetControlValue(Baihensagyokaisi_ymd_to,
				DataFormatUtil.GetFormatItem(tl030f01Form.Baihensagyokaisi_ymd_to,formInfo["Baihensagyokaisi_ymd_to"]));
			ControlUtil.SetControlValue(Baihenkaisi_ymd_from,
				DataFormatUtil.GetFormatItem(tl030f01Form.Baihenkaisi_ymd_from,formInfo["Baihenkaisi_ymd_from"]));
			ControlUtil.SetControlValue(Baihenkaisi_ymd_to,
				DataFormatUtil.GetFormatItem(tl030f01Form.Baihenkaisi_ymd_to,formInfo["Baihenkaisi_ymd_to"]));
			ControlUtil.SetControlValue(Genbaika_shijibaika_flg,
				DataFormatUtil.GetFormatItem(tl030f01Form.Genbaika_shijibaika_flg,formInfo["Genbaika_shijibaika_flg"]));
			Genbaika_shijibaika_flg.Text = formResource.GetString("Genbaika_shijibaika_flg", lang);
			ControlUtil.SetControlValue(Searchcnt,
				DataFormatUtil.GetFormatItem(tl030f01Form.Searchcnt,formInfo["Searchcnt"]));
			ControlUtil.SetControlValue(Label_cd,
				DataFormatUtil.GetFormatItem(tl030f01Form.Label_cd,formInfo["Label_cd"]));
			ControlUtil.SetControlValue(Label_ip,
				DataFormatUtil.GetFormatItem(tl030f01Form.Label_ip,formInfo["Label_ip"]));
			ControlUtil.SetControlValue(Label_nm,
				DataFormatUtil.GetFormatItem(tl030f01Form.Label_nm,formInfo["Label_nm"]));

			if(!base.CheckUseSelfCustomize()){
				Btnheadtenpocd.Value = base.FormResourceGetString(formResource, "Btnheadtenpocd", lang);
				Btnbumon_cd_from.Value = base.FormResourceGetString(formResource, "Btnbumon_cd_from", lang);
				Btnbumon_cd_to.Value = base.FormResourceGetString(formResource, "Btnbumon_cd_to", lang);
				Btntanto_cd.Value = base.FormResourceGetString(formResource, "Btntanto_cd", lang);
				Btnsearch.Value = base.FormResourceGetString(formResource, "Btnsearch", lang);
				Btnzenstk.Value = base.FormResourceGetString(formResource, "Btnzenstk", lang);
				Btnzenkjo.Value = base.FormResourceGetString(formResource, "Btnzenkjo", lang);
				Btnlabel_cd.Value = base.FormResourceGetString(formResource, "Btnlabel_cd", lang);
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
				// 申請元
				Sinseimoto.Items.Insert(0, new ListItem("", BoSystemConstant.DROPDOWNLIST_MISENTAKU));
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
			// UIScreenController controller = new UIScreenController((Tl030f01Form)base.GetPageContext().GetFormVO());
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

			// 権限による制御
			LoginInfoVO loginInfVo = LoginInfoUtil.GetLoginInfo();

			// 権限取得部品の戻り値が"FALSE"の場合
			if (!CheckKengenCls.CheckKengen(loginInfVo))
			{
				// 現売価 = 支持売価フラグ非表示
				Genbaika_shijibaika_flg_Label.Visible = false;
				ControlCls.Visible(Genbaika_shijibaika_flg, false);
			}

			Tl030f01Form formVo = (Tl030f01Form)base.GetPageContext().GetFormVO();

			if (ConditionSinseimoto.VALUE_SINSEIMOTO1.Equals(formVo.Sinseimoto)
				&& BoSystemConstant.CHECKBOX_ON.Equals(formVo.Genbaika_shijibaika_flg))
			{
				// 制御なし
			}
			else
			{
				ControlCls.Disable(Btnzenstk, true);
				ControlCls.Disable(Btnzenkjo, true);
			}
			// アルバイトの場合、返品理由は使用不可
			if (loginInfVo.Kengenkbn == BoSystemConstant.TANTO_KENGEN_ARBEIT)
				ControlCls.Disable(Sinseimoto, true);

			IList m1DataList = formVo.GetPageViewList("M1");

			// 明細の入力項目を使用不可にする
			for (int i = 0; i < m1DataList.Count; i++)
			{
				Tl030f01M1Form f01m1VO = (Tl030f01M1Form)m1DataList[i];
				// 行選択不可フラグが不可の場合、行選択不可とする
				if (Tl030p01Constant.ITIRAN_SENTAKU_FUKA.Equals(f01m1VO.Dictionary[Tl030p01Constant.DIC_M1NOTSELECTFLG].ToString()))
				{
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
			ControlUtil.SetControlValue(Sinseimoto_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Sinseimoto", lang), base.GetPageContext().FormInfo["Sinseimoto"]));
				DataFormatUtil.SetMustColorCaption(Sinseimoto_lbl, base.GetPageContext().FormInfo["Sinseimoto"]);
			//ControlUtil.SetControlValue(Bumon_cd_from_lbl, 
				//DataFormatUtil.GetFormatCaption(formResource.GetString("Bumon_cd_from", lang), base.GetPageContext().FormInfo["Bumon_cd_from"]));
				ControlUtil.SetControlValue(Bumon_cd_from_lbl, "部門");
				DataFormatUtil.SetMustColorCaption(Bumon_cd_from_lbl, base.GetPageContext().FormInfo["Bumon_cd_from"]);
			ControlUtil.SetControlValue(Bumon_nm_from_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Bumon_nm_from", lang), base.GetPageContext().FormInfo["Bumon_nm_from"]));
				DataFormatUtil.SetMustColorCaption(Bumon_nm_from_lbl, base.GetPageContext().FormInfo["Bumon_nm_from"]);
			ControlUtil.SetControlValue(Bumon_cd_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Bumon_cd_to", lang), base.GetPageContext().FormInfo["Bumon_cd_to"]));
				DataFormatUtil.SetMustColorCaption(Bumon_cd_to_lbl, base.GetPageContext().FormInfo["Bumon_cd_to"]);
			ControlUtil.SetControlValue(Bumon_nm_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Bumon_nm_to", lang), base.GetPageContext().FormInfo["Bumon_nm_to"]));
				DataFormatUtil.SetMustColorCaption(Bumon_nm_to_lbl, base.GetPageContext().FormInfo["Bumon_nm_to"]);
			ControlUtil.SetControlValue(Sinseitan_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Sinseitan_cd", lang), base.GetPageContext().FormInfo["Sinseitan_cd"]));
				DataFormatUtil.SetMustColorCaption(Sinseitan_cd_lbl, base.GetPageContext().FormInfo["Sinseitan_cd"]);
			ControlUtil.SetControlValue(Sinseitan_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Sinseitan_nm", lang), base.GetPageContext().FormInfo["Sinseitan_nm"]));
				DataFormatUtil.SetMustColorCaption(Sinseitan_nm_lbl, base.GetPageContext().FormInfo["Sinseitan_nm"]);
			//ControlUtil.SetControlValue(Baihen_shiji_no_from_lbl, 
				//DataFormatUtil.GetFormatCaption(formResource.GetString("Baihen_shiji_no_from", lang), base.GetPageContext().FormInfo["Baihen_shiji_no_from"]));
			ControlUtil.SetControlValue(Baihen_shiji_no_from_lbl, "売変指示No");
				DataFormatUtil.SetMustColorCaption(Baihen_shiji_no_from_lbl, base.GetPageContext().FormInfo["Baihen_shiji_no_from"]);
			ControlUtil.SetControlValue(Baihen_shiji_no_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Baihen_shiji_no_to", lang), base.GetPageContext().FormInfo["Baihen_shiji_no_to"]));
				DataFormatUtil.SetMustColorCaption(Baihen_shiji_no_to_lbl, base.GetPageContext().FormInfo["Baihen_shiji_no_to"]);
			//ControlUtil.SetControlValue(Baihensagyokaisi_ymd_from_lbl, 
				//DataFormatUtil.GetFormatCaption(formResource.GetString("Baihensagyokaisi_ymd_from", lang), base.GetPageContext().FormInfo["Baihensagyokaisi_ymd_from"]));
				ControlUtil.SetControlValue(Baihensagyokaisi_ymd_from_lbl, "作業開始日");
				DataFormatUtil.SetMustColorCaption(Baihensagyokaisi_ymd_from_lbl, base.GetPageContext().FormInfo["Baihensagyokaisi_ymd_from"]);
			ControlUtil.SetControlValue(Baihensagyokaisi_ymd_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Baihensagyokaisi_ymd_to", lang), base.GetPageContext().FormInfo["Baihensagyokaisi_ymd_to"]));
				DataFormatUtil.SetMustColorCaption(Baihensagyokaisi_ymd_to_lbl, base.GetPageContext().FormInfo["Baihensagyokaisi_ymd_to"]);
			//ControlUtil.SetControlValue(Baihenkaisi_ymd_from_lbl, 
				//DataFormatUtil.GetFormatCaption(formResource.GetString("Baihenkaisi_ymd_from", lang), base.GetPageContext().FormInfo["Baihenkaisi_ymd_from"]));
				ControlUtil.SetControlValue(Baihenkaisi_ymd_from_lbl, "開始日");
				DataFormatUtil.SetMustColorCaption(Baihenkaisi_ymd_from_lbl, base.GetPageContext().FormInfo["Baihenkaisi_ymd_from"]);
			ControlUtil.SetControlValue(Baihenkaisi_ymd_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Baihenkaisi_ymd_to", lang), base.GetPageContext().FormInfo["Baihenkaisi_ymd_to"]));
				DataFormatUtil.SetMustColorCaption(Baihenkaisi_ymd_to_lbl, base.GetPageContext().FormInfo["Baihenkaisi_ymd_to"]);
			ControlUtil.SetControlValue(Genbaika_shijibaika_flg_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Genbaika_shijibaika_flg", lang), base.GetPageContext().FormInfo["Genbaika_shijibaika_flg"]));
				DataFormatUtil.SetMustColorCaption(Genbaika_shijibaika_flg_lbl, base.GetPageContext().FormInfo["Genbaika_shijibaika_flg"]);
			ControlUtil.SetControlValue(Searchcnt_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Searchcnt", lang), base.GetPageContext().FormInfo["Searchcnt"]));
				DataFormatUtil.SetMustColorCaption(Searchcnt_lbl, base.GetPageContext().FormInfo["Searchcnt"]);
			ControlUtil.SetControlValue(Label_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Label_nm", lang), base.GetPageContext().FormInfo["Label_nm"]));
				DataFormatUtil.SetMustColorCaption(Label_nm_lbl, base.GetPageContext().FormInfo["Label_nm"]);
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
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1shinseimoto_nm", lang), base.GetPageContext().FormInfo["M1shinseimoto_nm"]);
				// M1.Columns[2].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1sinseitan_nm", lang), base.GetPageContext().FormInfo["M1sinseitan_nm"]);
				// M1.Columns[3].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1baihen_shiji_no", lang), base.GetPageContext().FormInfo["M1baihen_shiji_no"]);
				// M1.Columns[4].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumon_cd", lang), base.GetPageContext().FormInfo["M1bumon_cd"]);
				// M1.Columns[5].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1baihensagyokaisi_ymd", lang), base.GetPageContext().FormInfo["M1baihensagyokaisi_ymd"]);
				// M1.Columns[6].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1baihenkaisi_ymd", lang), base.GetPageContext().FormInfo["M1baihenkaisi_ymd"]);
				// M1.Columns[7].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1baihen_riyu_nm", lang), base.GetPageContext().FormInfo["M1baihen_riyu_nm"]);
				// M1.Columns[8].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hinban_su", lang), base.GetPageContext().FormInfo["M1hinban_su"]);
				// M1.Columns[9].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1zaiko_su", lang), base.GetPageContext().FormInfo["M1zaiko_su"]);
				// M1.Columns[10].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1selectorcheckbox", lang), base.GetPageContext().FormInfo["M1selectorcheckbox"]);
				// M1.Columns[11].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1entersyoriflg", lang), base.GetPageContext().FormInfo["M1entersyoriflg"]);
				// M1.Columns[12].HeaderText = 
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
				Windowtitle.InnerText = formResource.GetString("Tl030f01_Titlebar", lang);
				header.FormName = formResource.GetString("Tl030f01_FormCaption", lang);
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
