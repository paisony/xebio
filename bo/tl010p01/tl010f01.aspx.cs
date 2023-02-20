using com.xebio.bo.Tl010p01.Constant;
using com.xebio.bo.Tl010p01.Facade;
using com.xebio.bo.Tl010p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.Model.Context;
using Common.Advanced.Resource;
using Common.Advanced.Web.Context;
using Common.Advanced.Web.Util;
using Common.Business.C01000.C01013;
using Common.Business.C01000.C01014;
using Common.Business.C01000.C01015;
using Common.Business.C01000.C01016;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LabelUtil;
using Common.Business.C99999.ReportUtil;
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

namespace com.xebio.bo.Tl010p01.Page
{
  /// <summary>
  /// Tl010f01のコードビハインドです。
  /// </summary>
  public partial class Tl010f01Page : StandardBasePage
	{

		#region メソッド

		#region ページデータをロードするメソッド
		/// <summary>
		/// Tl010f01画面データを作成する。
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
						pageContext.SetFormVO(new Tl010f01Form());
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
		
								new Tl010f01Facade().DoLoad(facadeContext);

								#region 共通ヘッダ処理

								// 一覧画面共通処理 ----------
								LoginInfoVO loginInfVO = LoginInfoUtil.GetLoginInfo();
								Tl010f01Form tl010f01Form = (Tl010f01Form)facadeContext.FormVO;
								ControlHeaderStoreCls.InitialSetHeaderStore<Tl010f01Form>(loginInfVO, tl010f01Form);
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

				// ファイルダウンロード
				if (SessionInfoUtil.GetPgObject(BoSystemConstant.SESSION_KEY_DOWNLOAD_VO, base.GetPageContext()) != null)
				{
					// ダウンロード用VOをセッションから取得
					DLConditionVO dlvo = SessionInfoUtil.GetPgObject(BoSystemConstant.SESSION_KEY_DOWNLOAD_VO, base.GetPageContext()) as DLConditionVO;

					// ダウンロード用VOをセッションから削除
					SessionInfoUtil.RemovePgObject(BoSystemConstant.SESSION_KEY_DOWNLOAD_VO, base.GetPageContext());

					base.DownloadPageStartUp(base.GetPageContext(), dlvo);
				}

				if (pageContext != null)
				{
					string msg = BoSystemLabelUtil.GetScriptLabelPrint(pageContext, Tl010p01Constant.PGID);
					if (!string.IsNullOrEmpty(msg))
					{
						// インフォメッセージが表示されている場合、表示する。
						Page.ClientScript.RegisterStartupScript(typeof(string), "SealPrint", msg);
						return;
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
				//クライアントチェックエラー時、画面描画する
				SetItems();
				SetAttribute();
				pageContext = base.GetPageContext();
				Page.ClientScript.RegisterStartupScript(typeof(string), "InitialDetail", ControlCls.InitialDetail(pageContext));

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
				new Tl010f01Facade().DoBTNSEARCH_FRM(facadeContext);
				
				
				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
					// アコーディオンなし
					AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_NONE);
					commandInfo.ActionMode = "INI";

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
			string focusItem = string.Empty;
			string focusMno  = string.Empty;

			// 表示明細先頭の管理Noにフォーカス設定
			focusItem = "M1bumonkana_nm";
			focusMno  = (0).ToString();

			// フォーカス設定
			SetFocusCls.SetFocus(queryList, focusItem, focusMno);

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

			// PDFファイル名
			string pdfNm = string.Empty;
			try
			{

				//アクションロジックを処理します
				IFacadeContext facadeContext = FacadeContextFactory.GetFacadeContext(pageContext);
				InitFacadeContext(facadeContext);
				new Tl010f01Facade().DoBTNPRINT_FRM(facadeContext);

				// PDFファイル名を取得
				pdfNm = (string)facadeContext.GetUserObject(Tl010p01Constant.FCDUO_RRT_FLNM);
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
			#region 帳票出力処理

			DLConditionVO dlvo = new DLConditionVO();
			// サーバファイルフルパス
			string serverPath = string.Format("{0}{1}{2}",
											FilePathManager.GetOutFilePath(Tl010p01Constant.PGID),
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

			// ダウンロード用VOをセッションに格納
			SessionInfoUtil.SetPgObject(BoSystemConstant.SESSION_KEY_DOWNLOAD_VO, dlvo, pageContext);

			#endregion

			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNPRINT_FRM");

			//画面遷移
			base.Forward(pageContext, queryList);
			//base.DownloadPageStartUp(pageContext, dlvo);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Btnseal())
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnseal())
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnBTNSEAL_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnBTNSEAL_FRM");
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
				new Tl010f01Facade().DoBTNSEAL_FRM(facadeContext);

				// ラベル発行機の値をクッキーに登録
				Tl010f01Form f01VO = (Tl010f01Form)facadeContext.FormVO;
				BoSystemLabelUtil.SetCookieLabel(pageContext.Response, f01VO);
				
				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
					base.SetError(pageContext);
					return;
				}

				// CSVファイル名を取得
				string csvNm = (string)facadeContext.GetUserObject(Tl010p01Constant.FCDUO_SEAL_CSVFLNM);

				// シールレイアウト
				List<string> layout = (List<string>)facadeContext.GetUserObject(Tl010p01Constant.FCDUO_SEAL_LAYOUTNM);

				// シール発行スクリプトの出力
				BoSystemLabelUtil.createScriptLabelPrint(pageContext, Tl010p01Constant.PGID, layout, csvNm);

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

			//// Cookieへの保存
			//Tl010f01Form f01_2VO = (Tl010f01Form)pageContext.GetFormVO(Tl010p01Constant.PGID, Tl010p01Constant.FORMID_01);
			//Response.Cookies["Label_cd"].Value = f01_2VO.Label_cd;

			//URLクエリ追加用NameValueCollection
			NameValueCollection queryList = new NameValueCollection();
			
			//フォーカスを当てる項目を指定したい場合はFormFocusUtilを使ってqueryListに追加すること
			
			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNSEAL_FRM");
			
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
				new Tl010f01Facade().DoPGR_PGN(facadeContext, pageindex);
				
				
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
				new Tl010f01Facade().DoM1BUMON_CD_FRM(facadeContext);
				
				
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
			EndMethod(sender, e, this.GetType().Name + ".OnM1BUMON_CD_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : M1bumonkana_nm())
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(M1bumonkana_nm())
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnM1BUMONKANA_NM_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnM1BUMONKANA_NM_FRM");
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
				facadeContext.SetUserObject(Tl010p01Constant.FCDUO_NEXTVO, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Tl010p01Constant.FORMID_02));

				new Tl010f01Facade().DoM1BUMONKANA_NM_FRM(facadeContext);

				// 次画面のフォームビーンを設定
				fvm.SetFormVO(Tl010p01Constant.PGID, Tl010p01Constant.FORMID_02, (Tl010f02Form)facadeContext.GetUserObject(Tl010p01Constant.FCDUO_NEXTVO));
				
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
			EndMethod(sender, e, this.GetType().Name + ".OnM1BUMONKANA_NM_FRM");
			
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
					Tl010f01Form tl010f01Form = (Tl010f01Form)pageContext.GetFormVO();

					//明細ページ情報を表示する
					ShowListPageInfo(tl010f01Form);
			
					//明細部データを表示する
					RenderList(tl010f01Form, pageContext.FormInfo, formResource, lang);

					//カード部データを表示する
					RenderCard(tl010f01Form, pageContext.FormInfo, formResource, lang);
					//}

					if (MessageDisplayUtil.HasError(FacadeContextFactory.GetFacadeContext(base.GetPageContext())))
					{
						base.SetError(base.GetPageContext());
					}


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
		/// <param name="tl010f01Form">画面FormVO</param>
		private void ShowListPageInfo(Tl010f01Form tl010f01Form)
		{
			//M1明細ページ情報を表示する。
			ShowM1ListPageInfo(tl010f01Form.GetList("M1"));

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
		/// <param name="tl010f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderList(
			Tl010f01Form tl010f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//画面のM1明細部データを設定する。
			RenderM1List(tl010f01Form, formInfo, formResource, lang);
			//M1明細部のページャーにページ情報を設定する。
			RenderM1Pager(tl010f01Form);
			
		}
		#endregion

		#region M1明細データを表示する
		/// <summary>
		/// M1明細データを表示する。
		/// </summary>
		/// <param name="tl010f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderM1List(
			Tl010f01Form tl010f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//M1明細部データソースを設定する。
			M1.DataSource = tl010f01Form.GetPageViewList("M1");
			M1.DataBind();

			//M1明細部データをフォーマットする。
			IList m1DataList = (IList)M1.DataSource;
			
			for (int index = 0; index < M1.Items.Count; index++)
			{
				Tl010f01M1Form tl010f01M1Form = (Tl010f01M1Form)m1DataList[index];
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1rowno"),
					DataFormatUtil.GetFormatItem(tl010f01M1Form.M1rowno,formInfo["M1rowno"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1baihenkaisi_ymd"),
					DataFormatUtil.GetFormatItem(tl010f01M1Form.M1baihenkaisi_ymd,formInfo["M1baihenkaisi_ymd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1hinban_su"),
					DataFormatUtil.GetFormatItem(tl010f01M1Form.M1hinban_su,formInfo["M1hinban_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1zaiko_su"),
					DataFormatUtil.GetFormatItem(tl010f01M1Form.M1zaiko_su,formInfo["M1zaiko_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1selectorcheckbox"),
					DataFormatUtil.GetFormatItem(tl010f01M1Form.M1selectorcheckbox,formInfo["M1selectorcheckbox"]));
				((System.Web.UI.WebControls.CheckBox)M1.Items[index].FindControl("M1selectorcheckbox")).Text =
					formResource.GetString("M1selectorcheckbox", lang);
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1entersyoriflg"),
					DataFormatUtil.GetFormatItem(tl010f01M1Form.M1entersyoriflg,formInfo["M1entersyoriflg"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1dtlirokbn"),
					DataFormatUtil.GetFormatItem(tl010f01M1Form.M1dtlirokbn,formInfo["M1dtlirokbn"]));

				if(!base.CheckUseSelfCustomize()){
					//((System.Web.UI.HtmlControls.HtmlInputButton)M1.Items[index].FindControl("M1bumon_cd")).Value =
					//	formResource.GetString("M1bumon_cd", lang);
					//((System.Web.UI.HtmlControls.HtmlInputButton)M1.Items[index].FindControl("M1bumonkana_nm")).Value =
					//	formResource.GetString("M1bumonkana_nm", lang);
					((System.Web.UI.HtmlControls.HtmlInputButton)M1.Items[index].FindControl("M1bumon_cd")).Value =
						BoSystemFormat.formatBumonCd(tl010f01M1Form.Dictionary[Tl010p01Constant.DIC_M1BUMON_CD].ToString());
					((System.Web.UI.HtmlControls.HtmlInputButton)M1.Items[index].FindControl("M1bumonkana_nm")).Value =
						BoSystemFormat.formatBumonCd(tl010f01M1Form.Dictionary[Tl010p01Constant.DIC_M1BUMON_CD].ToString() + " " + tl010f01M1Form.Dictionary[Tl010p01Constant.DIC_M1BUMON_NM].ToString());

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
				// (M1.HeaderRow.FindControl("M1bumon_cd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumon_cd", lang), base.GetPageContext().FormInfo["M1bumon_cd"]);
				// (M1.HeaderRow.FindControl("M1bumonkana_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumonkana_nm", lang), base.GetPageContext().FormInfo["M1bumonkana_nm"]);
				// (M1.HeaderRow.FindControl("M1baihenkaisi_ymd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1baihenkaisi_ymd", lang), base.GetPageContext().FormInfo["M1baihenkaisi_ymd"]);
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
		/// <param name="tl010f01Form">画面FormVO</param>
		private void RenderM1Pager(Tl010f01Form tl010f01Form)
		{
			Pgr.VirtualItemCount = tl010f01Form.GetList("M1").RecordCount;
			Pgr.CurrentPageIndex = tl010f01Form.GetList("M1").PageNo - 1;
			Pgr.PageSize = tl010f01Form.GetList("M1").DispRow;
		}
		#endregion
		#endregion

		#region カードデータを表示する
		/// <summary>
		/// カードデータを表示する
		/// </summary>
		/// <param name="tl010f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderCard(
			Tl010f01Form tl010f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			
			ControlUtil.SetControlValue(Head_tenpo_cd,
				DataFormatUtil.GetFormatItem(tl010f01Form.Head_tenpo_cd,formInfo["Head_tenpo_cd"]));
			ControlUtil.SetControlValue(Head_tenpo_nm,
				DataFormatUtil.GetFormatItem(tl010f01Form.Head_tenpo_nm,formInfo["Head_tenpo_nm"]));
			ControlUtil.SetControlValue(Kaishi_jyotai,
				DataFormatUtil.GetFormatItem(tl010f01Form.Kaishi_jyotai,formInfo["Kaishi_jyotai"]));
			ControlUtil.SetControlValue(Bumon_cd_from,
				DataFormatUtil.GetFormatItem(tl010f01Form.Bumon_cd_from,formInfo["Bumon_cd_from"]));
			ControlUtil.SetControlValue(Bumon_nm_from,
				DataFormatUtil.GetFormatItem(tl010f01Form.Bumon_nm_from,formInfo["Bumon_nm_from"]));
			ControlUtil.SetControlValue(Bumon_cd_to,
				DataFormatUtil.GetFormatItem(tl010f01Form.Bumon_cd_to,formInfo["Bumon_cd_to"]));
			ControlUtil.SetControlValue(Bumon_nm_to,
				DataFormatUtil.GetFormatItem(tl010f01Form.Bumon_nm_to,formInfo["Bumon_nm_to"]));
			ControlUtil.SetControlValue(Baihenkaisi_ymd_from,
				DataFormatUtil.GetFormatItem(tl010f01Form.Baihenkaisi_ymd_from,formInfo["Baihenkaisi_ymd_from"]));
			ControlUtil.SetControlValue(Baihenkaisi_ymd_to,
				DataFormatUtil.GetFormatItem(tl010f01Form.Baihenkaisi_ymd_to,formInfo["Baihenkaisi_ymd_to"]));
			ControlUtil.SetControlValue(Old_jisya_hbn,
				DataFormatUtil.GetFormatItem(tl010f01Form.Old_jisya_hbn,formInfo["Old_jisya_hbn"]));
			ControlUtil.SetControlValue(Maker_hbn,
				DataFormatUtil.GetFormatItem(tl010f01Form.Maker_hbn,formInfo["Maker_hbn"]));
			ControlUtil.SetControlValue(Searchcnt,
				DataFormatUtil.GetFormatItem(tl010f01Form.Searchcnt,formInfo["Searchcnt"]));
			ControlUtil.SetControlValue(Eigyo_ymd_hdn,
				DataFormatUtil.GetFormatItem(tl010f01Form.Eigyo_ymd_hdn, formInfo["Eigyo_ymd_hdn"]));
			ControlUtil.SetControlValue(Eigyo_ymd_hdn2,
				DataFormatUtil.GetFormatItem(tl010f01Form.Eigyo_ymd_hdn2, formInfo["Eigyo_ymd_hdn2"]));
			ControlUtil.SetControlValue(Shuturyoku_seal,
				DataFormatUtil.GetFormatItem(tl010f01Form.Shuturyoku_seal,formInfo["Shuturyoku_seal"]));
			//ControlUtil.SetControlValue(Label_cd,
			//	DataFormatUtil.GetFormatItem(tl010f01Form.Label_cd,formInfo["Label_cd"]));

			// Cookieが存在する場合、保存したラベル発行機IDを設定、存在しない場合は空白
			if (Request.Cookies["Label_cd"] != null)
			{
				ControlUtil.SetControlValue(Label_cd, Request.Cookies["Label_cd"].Value);
			}
			else
			{
				ControlUtil.SetControlValue(Label_cd, string.Empty);
			}	
			
			ControlUtil.SetControlValue(Label_ip,
				DataFormatUtil.GetFormatItem(tl010f01Form.Label_ip,formInfo["Label_ip"]));
			ControlUtil.SetControlValue(Label_nm,
				DataFormatUtil.GetFormatItem(tl010f01Form.Label_nm,formInfo["Label_nm"]));

			if(!base.CheckUseSelfCustomize()){
				Btnheadtenpocd.Value = base.FormResourceGetString(formResource, "Btnheadtenpocd", lang);
				Btnbumon_cd_from.Value = base.FormResourceGetString(formResource, "Btnbumon_cd_from", lang);
				Btnbumon_cd_to.Value = base.FormResourceGetString(formResource, "Btnbumon_cd_to", lang);
				Btnsearch.Value = base.FormResourceGetString(formResource, "Btnsearch", lang);
				Btnprint.Value = base.FormResourceGetString(formResource, "Btnprint", lang);
				Btnseal.Value = base.FormResourceGetString(formResource, "Btnseal", lang);
				Pgr.Text = base.FormResourceGetString(formResource, "Pgr", lang);
				Btnlabel_cd.Value = base.FormResourceGetString(formResource, "Btnlabel_cd", lang);
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

			if (!base.GetPageContext().CommandInfo.ActionMode.Equals("INI"))
			{
				if (!IsPostBack)
				{

					// [出力シール]の名称を設定
					Tl010f01Form formVO = (Tl010f01Form)base.GetPageContext().GetFormVO();
					IList<Hashtable> sealList = (IList<Hashtable>)formVO.Dictionary[Tl010p01Constant.DIC_SYUTSURYOKU_SEAL];
					int iIndex = 0;
					foreach (Hashtable insSealItemNm in sealList)
					{
						Shuturyoku_seal.Items.Insert(
									iIndex
									, new ListItem((string)sealList[iIndex]["TAX_HYOJIMONGON"], sealList[iIndex]["TAX_CD"].ToString())
									);
						iIndex++;
					}
					// 先頭を選択状態に設定
					Shuturyoku_seal.Items[0].Selected = true;
				}
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
			// UIScreenController controller = new UIScreenController((Tl010f01Form)base.GetPageContext().GetFormVO());
			// controller.ChangeColumnsDisplayMode(M1 ,  new DetailHeaderFixedVO(M1Header , true) , null);

			/*
			 *登録した機能間連携処理を親画面に感知させる。
			 *機能有効させる場合は、コメントアウトを外してください。
			 */
			//DetailUtil.RunPgSyn(this,(StandardBaseForm)base.GetPageContext().GetFormVO());


			LoginInfoVO loginInfVO = LoginInfoUtil.GetLoginInfo();

			#region 共通ヘッダ表示制御
			ControlHeaderStoreCls.ControlSetHeaderStore(loginInfVO, Head_tenpo_cd, Btnheadtenpocd);
			#endregion

			#region 画面表示制御

			if (base.GetPageContext().CommandInfo.ActionMode.Equals("INI"))
			{
				// 明細ボタン部を非表示とする
				ControlCls.Visible(meisaiBtnArea, false);
			}
			else
			{
				// 明細ボタン部を表示する
				ControlCls.Visible(meisaiBtnArea, true);
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
			ControlUtil.SetControlValue(Kaishi_jyotai_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Kaishi_jyotai", lang), base.GetPageContext().FormInfo["Kaishi_jyotai"]));
				DataFormatUtil.SetMustColorCaption(Kaishi_jyotai_lbl, base.GetPageContext().FormInfo["Kaishi_jyotai"]);
			//ControlUtil.SetControlValue(Bumon_cd_from_lbl, 
			//	DataFormatUtil.GetFormatCaption(formResource.GetString("Bumon_cd_from", lang), base.GetPageContext().FormInfo["Bumon_cd_from"]));
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
			//ControlUtil.SetControlValue(Baihenkaisi_ymd_from_lbl, 
			//	DataFormatUtil.GetFormatCaption(formResource.GetString("Baihenkaisi_ymd_from", lang), base.GetPageContext().FormInfo["Baihenkaisi_ymd_from"]));
			ControlUtil.SetControlValue(Baihenkaisi_ymd_from_lbl, "開始日");
				DataFormatUtil.SetMustColorCaption(Baihenkaisi_ymd_from_lbl, base.GetPageContext().FormInfo["Baihenkaisi_ymd_from"]);
			ControlUtil.SetControlValue(Baihenkaisi_ymd_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Baihenkaisi_ymd_to", lang), base.GetPageContext().FormInfo["Baihenkaisi_ymd_to"]));
				DataFormatUtil.SetMustColorCaption(Baihenkaisi_ymd_to_lbl, base.GetPageContext().FormInfo["Baihenkaisi_ymd_to"]);
			ControlUtil.SetControlValue(Old_jisya_hbn_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Old_jisya_hbn", lang), base.GetPageContext().FormInfo["Old_jisya_hbn"]));
				DataFormatUtil.SetMustColorCaption(Old_jisya_hbn_lbl, base.GetPageContext().FormInfo["Old_jisya_hbn"]);
			ControlUtil.SetControlValue(Maker_hbn_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Maker_hbn", lang), base.GetPageContext().FormInfo["Maker_hbn"]));
				DataFormatUtil.SetMustColorCaption(Maker_hbn_lbl, base.GetPageContext().FormInfo["Maker_hbn"]);
			ControlUtil.SetControlValue(Searchcnt_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Searchcnt", lang), base.GetPageContext().FormInfo["Searchcnt"]));
				DataFormatUtil.SetMustColorCaption(Searchcnt_lbl, base.GetPageContext().FormInfo["Searchcnt"]);
			ControlUtil.SetControlValue(Shuturyoku_seal_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Shuturyoku_seal", lang), base.GetPageContext().FormInfo["Shuturyoku_seal"]));
				DataFormatUtil.SetMustColorCaption(Shuturyoku_seal_lbl, base.GetPageContext().FormInfo["Shuturyoku_seal"]);
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
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumon_cd", lang), base.GetPageContext().FormInfo["M1bumon_cd"]);
				// M1.Columns[2].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumonkana_nm", lang), base.GetPageContext().FormInfo["M1bumonkana_nm"]);
				// M1.Columns[3].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1baihenkaisi_ymd", lang), base.GetPageContext().FormInfo["M1baihenkaisi_ymd"]);
				// M1.Columns[4].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hinban_su", lang), base.GetPageContext().FormInfo["M1hinban_su"]);
				// M1.Columns[5].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1zaiko_su", lang), base.GetPageContext().FormInfo["M1zaiko_su"]);
				// M1.Columns[6].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1selectorcheckbox", lang), base.GetPageContext().FormInfo["M1selectorcheckbox"]);
				// M1.Columns[7].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1entersyoriflg", lang), base.GetPageContext().FormInfo["M1entersyoriflg"]);
				// M1.Columns[8].HeaderText = 
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
				Windowtitle.InnerText = formResource.GetString("Tl010f01_Titlebar", lang);
				header.FormName = formResource.GetString("Tl010f01_FormCaption", lang);
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
