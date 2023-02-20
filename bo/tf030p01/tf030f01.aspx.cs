﻿using com.xebio.bo.Tf030p01.Constant;
using com.xebio.bo.Tf030p01.Facade;
using com.xebio.bo.Tf030p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.Model.Context;
using Common.Advanced.Resource;
using Common.Advanced.Web.Context;
using Common.Advanced.Web.Control;
using Common.Advanced.Web.Util;
using Common.Business.C01000.C01008;
using Common.Business.C01000.C01013;
using Common.Business.C01000.C01014;
using Common.Business.C01000.C01015;
using Common.Business.C01000.C01016;
using Common.Business.C01000.C01026;
using Common.Business.C99999.Constant;
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
using System.Collections.Specialized;
using System.IO;

namespace com.xebio.bo.Tf030p01.Page
{
  /// <summary>
  /// Tf030f01のコードビハインドです。
  /// </summary>
  public partial class Tf030f01Page : StandardBasePage
	{

		#region メソッド

		#region ページデータをロードするメソッド
		/// <summary>
		/// Tf030f01画面データを作成する。
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
						pageContext.SetFormVO(new Tf030f01Form());
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
								new Tf030f01Facade().DoLoad(facadeContext);

								#region 共通ヘッダ処理

								// 一覧画面共通処理 ----------
								LoginInfoVO loginInfVO = LoginInfoUtil.GetLoginInfo();
								Tf030f01Form tf030f01Form = (Tf030f01Form)facadeContext.FormVO;
								ControlHeaderStoreCls.InitialSetHeaderStore<Tf030f01Form>(loginInfVO, tf030f01Form);
								// 一覧画面共通処理 ----------

								if (string.IsNullOrEmpty(tf030f01Form.Modeno))
								{
									// アコーディオンなし
									AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_NONE);
									// モードNoを照会に設定
									tf030f01Form.Modeno = BoSystemConstant.MODE_REF.ToString();
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
					Tf030f01Form f01VO = (Tf030f01Form)fvm.GetProgramVO(base.GetPageContext().CommandInfo.ProgramId).GetFormVO(Tf030p01Constant.FORMID_01);
					TabUtil.SetTabNumber(base.GetPageContext(), f01VO.Modeno);
				}

				// 単一ファイルダウンロード処理
				if (SessionInfoUtil.GetPgObject(base.GetPageContext().CommandInfo.ProgramId, Tf030p01Constant.SESSION_KEY_DOWNLOAD_INFO, Session) != null)
				{
					// ダウンロード情報取得
					DLConditionVO dlVO = SessionInfoUtil.GetPgObject(base.GetPageContext().CommandInfo.ProgramId, Tf030p01Constant.SESSION_KEY_DOWNLOAD_INFO, Session) as DLConditionVO;

					// セッション削除
					SessionInfoUtil.RemovePgObject(Tf030p01Constant.SESSION_KEY_DOWNLOAD_INFO, base.GetPageContext());

					base.DownloadPageStartUp(base.GetPageContext(), dlVO);
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
				// モード表示クリア処理
				ModeUtil.ClearMode(pageContext);
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

				// 次画面のフォームVOをファサードに設定
				FormVOManager fvm = new FormVOManager(Session);
				facadeContext.SetUserObject(Tf030p01Constant.FCDUO_NEXTVO, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Tf030p01Constant.FORMID_02));

				new Tf030f01Facade().DoBTNINSERT_FRM(facadeContext);

				// 次画面のフォームビーンを設定
				fvm.SetFormVO(Tf030p01Constant.PGID, Tf030p01Constant.FORMID_02, (Tf030f02Form)facadeContext.GetUserObject(Tf030p01Constant.FCDUO_NEXTVO));

				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
					// アコーディオンなし
					AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_NONE);

					commandInfo.ActionMode = "INI";
					base.SetError(pageContext);
					return;
				}

				// モードを設定 
				ModeUtil.SetMode(pageContext, ModeCls.GetModeNm(((Tf030f01Form)pageContext.GetFormVO()).Stkmodeno));
				
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
				// モード表示クリア処理
				ModeUtil.ClearMode(pageContext);
				// 明細初期化処理
				Page.ClientScript.RegisterStartupScript(typeof(string), "initialDetail", ControlCls.InitialDetail(pageContext));
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
				new Tf030f01Facade().DoBTNSEARCH_FRM(facadeContext);
				
				
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

				// モードを設定 
				ModeUtil.SetMode(pageContext, ModeCls.GetModeNm(((Tf030f01Form)pageContext.GetFormVO()).Stkmodeno));

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

			// フォーカス設定用変数
			string focusItem = string.Empty;
			string focusMno = string.Empty;

			// 表示明細先頭の伝票番号にフォーカス設定
			focusItem = "M1denpyo_bango";
			// 1行目にフォーカス設定
			focusMno = (0).ToString();

			// フォーカス設定
			SetFocusCls.SetFocus(queryList, focusItem, focusMno);
			
			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNSEARCH_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion

		#region フォームを呼び出します(ボタンID : Btnprint(印刷))
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
				new Tf030f01Facade().DoBTNPRINT_FRM(facadeContext);
				
				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
					base.SetError(pageContext);
					return;
				}

				// PDFファイル名を取得
				pdfNm = (string)facadeContext.GetUserObject(Tf030p01Constant.FCDUO_RRT_FLNM);

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

			DLConditionVO dlvo = new DLConditionVO();
			// サーバファイルフルパス
			string serverPath = string.Format("{0}{1}{2}",
											FilePathManager.GetOutFilePath(Tf030p01Constant.PGID),
											Path.DirectorySeparatorChar,
											pdfNm
											);
			// クライアントファイル名
			string clientNm = string.Format("{0}.{1}",
											BoSystemReport.CreateFileName(BoSystemConstant.REPORTNM_KEIHIMIBARAILIST, 2),
											BoSystemConstant.RPT_PDF_EXTENSION
											);
			// ダウンロード用VOに値を設定
			dlvo.setSingleFileDownloadCondition(serverPath, clientNm);

			// ダウンロード用VOをセッションに格納
			SessionInfoUtil.SetPgObject(BoSystemConstant.SESSION_KEY_DOWNLOAD_VO, dlvo, pageContext);

			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNPRINT_FRM");

			//画面遷移
			base.Forward(pageContext, queryList);
			//base.DownloadPageStartUp(pageContext, dlvo);
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
				facadeContext.SetUserObject(Tf030p01Constant.FCDUO_NEXTVO, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Tf030p01Constant.FORMID_02));

				new Tf030f01Facade().DoM1DENPYO_BANGO_FRM(facadeContext);

				// 次画面のフォームビーンを設定
				fvm.SetFormVO(Tf030p01Constant.PGID, Tf030p01Constant.FORMID_02, (Tf030f02Form)facadeContext.GetUserObject(Tf030p01Constant.FCDUO_NEXTVO));
				
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
			
			try
			{

				//アクションロジックを処理します
				IFacadeContext facadeContext = FacadeContextFactory.GetFacadeContext(pageContext);
				InitFacadeContext(facadeContext);
				new Tf030f01Facade().DoBTNENTER_FRM(facadeContext);
				
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
						Tf030f01Form tf030f01Form = (Tf030f01Form)pageContext.GetFormVO();

						//明細ページ情報を表示する
						ShowListPageInfo(tf030f01Form);
			
						//明細部データを表示する
						RenderList(tf030f01Form, pageContext.FormInfo, formResource, lang);

						//カード部データを表示する
						RenderCard(tf030f01Form, pageContext.FormInfo, formResource, lang);
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
		/// <param name="tf030f01Form">画面FormVO</param>
		private void ShowListPageInfo(Tf030f01Form tf030f01Form)
		{
			//M1明細ページ情報を表示する。
			ShowM1ListPageInfo(tf030f01Form.GetList("M1"));

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
		/// <param name="tf030f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderList(
			Tf030f01Form tf030f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//画面のM1明細部データを設定する。
			RenderM1List(tf030f01Form, formInfo, formResource, lang);
			
		}
		#endregion

		#region M1明細データを表示する
		/// <summary>
		/// M1明細データを表示する。
		/// </summary>
		/// <param name="tf030f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderM1List(
			Tf030f01Form tf030f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//M1明細部データソースを設定する。
			M1.DataSource = tf030f01Form.GetPageViewList("M1");
			M1.DataBind();

			//M1明細部データをフォーマットする。
			IList m1DataList = (IList)M1.DataSource;
			
			for (int index = 0; index < M1.Items.Count; index++)
			{
				Tf030f01M1Form tf030f01M1Form = (Tf030f01M1Form)m1DataList[index];
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1rowno"),
					DataFormatUtil.GetFormatItem(tf030f01M1Form.M1rowno,formInfo["M1rowno"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1add_ymd"),
					DataFormatUtil.GetFormatItem(tf030f01M1Form.M1add_ymd,formInfo["M1add_ymd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1tenpo_cd"),
					DataFormatUtil.GetFormatItem(tf030f01M1Form.M1tenpo_cd,formInfo["M1tenpo_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1tenpo_nm"),
					DataFormatUtil.GetFormatItem(tf030f01M1Form.M1tenpo_nm,formInfo["M1tenpo_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1siiresaki_cd"),
					DataFormatUtil.GetFormatItem(tf030f01M1Form.M1siiresaki_cd,formInfo["M1siiresaki_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1siiresaki_ryaku_nm"),
					DataFormatUtil.GetFormatItem(tf030f01M1Form.M1siiresaki_ryaku_nm,formInfo["M1siiresaki_ryaku_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1motodenpyo_bango"),
					DataFormatUtil.GetFormatItem(tf030f01M1Form.M1motodenpyo_bango,formInfo["M1motodenpyo_bango"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1nohin_ymd"),
					DataFormatUtil.GetFormatItem(tf030f01M1Form.M1nohin_ymd,formInfo["M1nohin_ymd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1nyuryokutan_nm"),
					DataFormatUtil.GetFormatItem(tf030f01M1Form.M1nyuryokutan_nm,formInfo["M1nyuryokutan_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1itemsu"),
					DataFormatUtil.GetFormatItem(tf030f01M1Form.M1itemsu,formInfo["M1itemsu"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1kingaku"),
					DataFormatUtil.GetFormatItem(tf030f01M1Form.M1kingaku,formInfo["M1kingaku"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1selectorcheckbox"),
					DataFormatUtil.GetFormatItem(tf030f01M1Form.M1selectorcheckbox,formInfo["M1selectorcheckbox"]));
				((System.Web.UI.WebControls.CheckBox)M1.Items[index].FindControl("M1selectorcheckbox")).Text =
					formResource.GetString("M1selectorcheckbox", lang);
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1entersyoriflg"),
					DataFormatUtil.GetFormatItem(tf030f01M1Form.M1entersyoriflg,formInfo["M1entersyoriflg"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1dtlirokbn"),
					DataFormatUtil.GetFormatItem(tf030f01M1Form.M1dtlirokbn,formInfo["M1dtlirokbn"]));

				if(!base.CheckUseSelfCustomize()){
					// ボタンのValueに伝票番号を設定
					((System.Web.UI.HtmlControls.HtmlInputButton)M1.Items[index].FindControl("M1denpyo_bango")).Value =
						tf030f01M1Form.Dictionary[Tf030p01Constant.DIC_M1DENPYO_BANGO].ToString();

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
				// (M1.HeaderRow.FindControl("M1tenpo_cd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tenpo_cd", lang), base.GetPageContext().FormInfo["M1tenpo_cd"]);
				// (M1.HeaderRow.FindControl("M1tenpo_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tenpo_nm", lang), base.GetPageContext().FormInfo["M1tenpo_nm"]);
				// (M1.HeaderRow.FindControl("M1siiresaki_cd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1siiresaki_cd", lang), base.GetPageContext().FormInfo["M1siiresaki_cd"]);
				// (M1.HeaderRow.FindControl("M1siiresaki_ryaku_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1siiresaki_ryaku_nm", lang), base.GetPageContext().FormInfo["M1siiresaki_ryaku_nm"]);
				// (M1.HeaderRow.FindControl("M1denpyo_bango") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1denpyo_bango", lang), base.GetPageContext().FormInfo["M1denpyo_bango"]);
				// (M1.HeaderRow.FindControl("M1motodenpyo_bango") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1motodenpyo_bango", lang), base.GetPageContext().FormInfo["M1motodenpyo_bango"]);
				// (M1.HeaderRow.FindControl("M1nohin_ymd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1nohin_ymd", lang), base.GetPageContext().FormInfo["M1nohin_ymd"]);
				// (M1.HeaderRow.FindControl("M1nyuryokutan_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1nyuryokutan_nm", lang), base.GetPageContext().FormInfo["M1nyuryokutan_nm"]);
				// (M1.HeaderRow.FindControl("M1itemsu") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1itemsu", lang), base.GetPageContext().FormInfo["M1itemsu"]);
				// (M1.HeaderRow.FindControl("M1kingaku") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kingaku", lang), base.GetPageContext().FormInfo["M1kingaku"]);
				// (M1.HeaderRow.FindControl("M1selectorcheckbox") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1selectorcheckbox", lang), base.GetPageContext().FormInfo["M1selectorcheckbox"]);
				// (M1.HeaderRow.FindControl("M1entersyoriflg") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1entersyoriflg", lang), base.GetPageContext().FormInfo["M1entersyoriflg"]);
				// (M1.HeaderRow.FindControl("M1dtlirokbn") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1dtlirokbn", lang), base.GetPageContext().FormInfo["M1dtlirokbn"]);
				// }

		}
		#endregion
		#endregion

		#region カードデータを表示する
		/// <summary>
		/// カードデータを表示する
		/// </summary>
		/// <param name="tf030f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderCard(
			Tf030f01Form tf030f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			
			ControlUtil.SetControlValue(Head_tenpo_cd,
				DataFormatUtil.GetFormatItem(tf030f01Form.Head_tenpo_cd,formInfo["Head_tenpo_cd"]));
			ControlUtil.SetControlValue(Head_tenpo_nm,
				DataFormatUtil.GetFormatItem(tf030f01Form.Head_tenpo_nm,formInfo["Head_tenpo_nm"]));
			ControlUtil.SetControlValue(Modeno,
				DataFormatUtil.GetFormatItem(tf030f01Form.Modeno,formInfo["Modeno"]));
			ControlUtil.SetControlValue(Stkmodeno,
				DataFormatUtil.GetFormatItem(tf030f01Form.Stkmodeno,formInfo["Stkmodeno"]));
			ControlUtil.SetControlValue(Add_ymd_from,
				DataFormatUtil.GetFormatItem(tf030f01Form.Add_ymd_from,formInfo["Add_ymd_from"]));
			ControlUtil.SetControlValue(Add_ymd_to,
				DataFormatUtil.GetFormatItem(tf030f01Form.Add_ymd_to,formInfo["Add_ymd_to"]));
			ControlUtil.SetControlValue(Tenpo_cd_from,
				DataFormatUtil.GetFormatItem(tf030f01Form.Tenpo_cd_from,formInfo["Tenpo_cd_from"]));
			ControlUtil.SetControlValue(Tenpo_nm_from,
				DataFormatUtil.GetFormatItem(tf030f01Form.Tenpo_nm_from,formInfo["Tenpo_nm_from"]));
			ControlUtil.SetControlValue(Tenpo_cd_to,
				DataFormatUtil.GetFormatItem(tf030f01Form.Tenpo_cd_to,formInfo["Tenpo_cd_to"]));
			ControlUtil.SetControlValue(Tenpo_nm_to,
				DataFormatUtil.GetFormatItem(tf030f01Form.Tenpo_nm_to,formInfo["Tenpo_nm_to"]));
			ControlUtil.SetControlValue(Siiresaki_cd,
				DataFormatUtil.GetFormatItem(tf030f01Form.Siiresaki_cd,formInfo["Siiresaki_cd"]));
			ControlUtil.SetControlValue(Siiresaki_ryaku_nm,
				DataFormatUtil.GetFormatItem(tf030f01Form.Siiresaki_ryaku_nm,formInfo["Siiresaki_ryaku_nm"]));
			ControlUtil.SetControlValue(Denpyo_bango_from,
				DataFormatUtil.GetFormatItem(tf030f01Form.Denpyo_bango_from,formInfo["Denpyo_bango_from"]));
			ControlUtil.SetControlValue(Denpyo_bango_to,
				DataFormatUtil.GetFormatItem(tf030f01Form.Denpyo_bango_to,formInfo["Denpyo_bango_to"]));
			ControlUtil.SetControlValue(Motodenpyo_bango_from,
				DataFormatUtil.GetFormatItem(tf030f01Form.Motodenpyo_bango_from,formInfo["Motodenpyo_bango_from"]));
			ControlUtil.SetControlValue(Motodenpyo_bango_to,
				DataFormatUtil.GetFormatItem(tf030f01Form.Motodenpyo_bango_to,formInfo["Motodenpyo_bango_to"]));
			ControlUtil.SetControlValue(Searchcnt,
				DataFormatUtil.GetFormatItem(tf030f01Form.Searchcnt,formInfo["Searchcnt"]));

			if(!base.CheckUseSelfCustomize()){
				Btnheadtenpocd.Value = base.FormResourceGetString(formResource, "Btnheadtenpocd", lang);
				Btnmoderef.InnerText = base.FormResourceGetString(formResource, "Btnmoderef", lang);
				Btnmodeupd.InnerText = base.FormResourceGetString(formResource, "Btnmodeupd", lang);
				Btnmodedel.InnerText = base.FormResourceGetString(formResource, "Btnmodedel", lang);
				Btntenpocd_from.Value = base.FormResourceGetString(formResource, "Btntenpocd_from", lang);
				Btntenpocd_to.Value = base.FormResourceGetString(formResource, "Btntenpocd_to", lang);
				Btnsiiresaki_cd.Value = base.FormResourceGetString(formResource, "Btnsiiresaki_cd", lang);
				Btninsert.Value = base.FormResourceGetString(formResource, "Btninsert", lang);
				Btnsearch.Value = base.FormResourceGetString(formResource, "Btnsearch", lang);
				Btnprint.Value = base.FormResourceGetString(formResource, "Btnprint", lang);
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
			// UIScreenController controller = new UIScreenController((Tf030f01Form)base.GetPageContext().GetFormVO());
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

			Tf030f01Form formVo = (Tf030f01Form)base.GetPageContext().GetFormVO();

			if (BoSystemString.Nvl(formVo.Stkmodeno).Equals(BoSystemConstant.MODE_DEL))
			{
				// [選択モードNo]が「取消」の場合
				// 確定ボタン使用可
				ControlCls.Disable(Btnenter, false);
			}
			else
			{
				// [選択モードNo]が「取消」以外の場合

				// 確定ボタン使用不可
				ControlCls.Disable(Btnenter, true);
			}

			if (BoSystemString.Nvl(formVo.Stkmodeno).Equals(BoSystemConstant.MODE_REF))
			{
				// 照会モードの場合
				// 印刷ボタン使用可
				ControlCls.Disable(Btnprint, false);
			}
			else
			{
				// 照会モード以外の場合
				// 印刷ボタン使用不可
				ControlCls.Disable(Btnprint, true);
			}

			LoginInfoVO loginInfVo = LoginInfoUtil.GetLoginInfo();

			// 権限取得部品の戻り値が"TRUE"の場合
			if (CheckKengenCls.CheckKengen(loginInfVo))
			{
				// 店舗コードを入力可とする。
				ControlCls.Disable(Tenpo_cd_from, false);
				ControlCls.Disable(Btntenpocd_from, false);
				ControlCls.Disable(Tenpo_cd_to, false);
				ControlCls.Disable(Btntenpocd_to, false);
			}
			// 権限取得部品の戻り値が"FALSE"の場合
			else
			{
				// 店舗コードを入力不可とする。
				ControlCls.Disable(Tenpo_cd_from, true);
				ControlCls.Disable(Btntenpocd_from, true);
				ControlCls.Disable(Tenpo_cd_to, true);
				ControlCls.Disable(Btntenpocd_to, true);
			}

			// 照会モードで店舗権限の場合
			if (BoSystemString.Nvl(formVo.Stkmodeno).Equals(BoSystemConstant.MODE_REF) && !CheckKengenCls.CheckKengen(loginInfVo))
			{
				IList m1DataList = formVo.GetPageViewList("M1");
				for (int index = 0; index < M1.Items.Count; index++)
				{
					Tf030f01M1Form f01m1VO = (Tf030f01M1Form)m1DataList[index];

					// 送信済みの場合
					if (ConditionSosinzumi_flg.VALUE_SOSINZUMI.Equals(f01m1VO.Dictionary[Tf030p01Constant.DIC_M1SOSINZUMI_FLG].ToString()))
					{
						// 行選択を不可にする。
						((AdvancedCheckBox)M1.Items[index].FindControl("M1selectorcheckbox")).Visible = false;
					}
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
			//ControlUtil.SetControlValue(Add_ymd_from_lbl, 
			//	DataFormatUtil.GetFormatCaption(formResource.GetString("Add_ymd_from", lang), base.GetPageContext().FormInfo["Add_ymd_from"]));
				ControlUtil.SetControlValue(Add_ymd_from_lbl, "登録日");
				DataFormatUtil.SetMustColorCaption(Add_ymd_from_lbl, base.GetPageContext().FormInfo["Add_ymd_from"]);
			ControlUtil.SetControlValue(Add_ymd_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Add_ymd_to", lang), base.GetPageContext().FormInfo["Add_ymd_to"]));
				DataFormatUtil.SetMustColorCaption(Add_ymd_to_lbl, base.GetPageContext().FormInfo["Add_ymd_to"]);
			//ControlUtil.SetControlValue(Tenpo_cd_from_lbl, 
			//	DataFormatUtil.GetFormatCaption(formResource.GetString("Tenpo_cd_from", lang), base.GetPageContext().FormInfo["Tenpo_cd_from"]));
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
			ControlUtil.SetControlValue(Siiresaki_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Siiresaki_cd", lang), base.GetPageContext().FormInfo["Siiresaki_cd"]));
				DataFormatUtil.SetMustColorCaption(Siiresaki_cd_lbl, base.GetPageContext().FormInfo["Siiresaki_cd"]);
			ControlUtil.SetControlValue(Siiresaki_ryaku_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Siiresaki_ryaku_nm", lang), base.GetPageContext().FormInfo["Siiresaki_ryaku_nm"]));
				DataFormatUtil.SetMustColorCaption(Siiresaki_ryaku_nm_lbl, base.GetPageContext().FormInfo["Siiresaki_ryaku_nm"]);
			//ControlUtil.SetControlValue(Denpyo_bango_from_lbl, 
			//	DataFormatUtil.GetFormatCaption(formResource.GetString("Denpyo_bango_from", lang), base.GetPageContext().FormInfo["Denpyo_bango_from"]));
				ControlUtil.SetControlValue(Denpyo_bango_from_lbl, "伝票番号");
				DataFormatUtil.SetMustColorCaption(Denpyo_bango_from_lbl, base.GetPageContext().FormInfo["Denpyo_bango_from"]);
			ControlUtil.SetControlValue(Denpyo_bango_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Denpyo_bango_to", lang), base.GetPageContext().FormInfo["Denpyo_bango_to"]));
				DataFormatUtil.SetMustColorCaption(Denpyo_bango_to_lbl, base.GetPageContext().FormInfo["Denpyo_bango_to"]);
			//ControlUtil.SetControlValue(Motodenpyo_bango_from_lbl, 
			//	DataFormatUtil.GetFormatCaption(formResource.GetString("Motodenpyo_bango_from", lang), base.GetPageContext().FormInfo["Motodenpyo_bango_from"]));
				ControlUtil.SetControlValue(Motodenpyo_bango_from_lbl, "元伝票番号");
				DataFormatUtil.SetMustColorCaption(Motodenpyo_bango_from_lbl, base.GetPageContext().FormInfo["Motodenpyo_bango_from"]);
			ControlUtil.SetControlValue(Motodenpyo_bango_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Motodenpyo_bango_to", lang), base.GetPageContext().FormInfo["Motodenpyo_bango_to"]));
				DataFormatUtil.SetMustColorCaption(Motodenpyo_bango_to_lbl, base.GetPageContext().FormInfo["Motodenpyo_bango_to"]);
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
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tenpo_cd", lang), base.GetPageContext().FormInfo["M1tenpo_cd"]);
				// M1.Columns[3].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tenpo_nm", lang), base.GetPageContext().FormInfo["M1tenpo_nm"]);
				// M1.Columns[4].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1siiresaki_cd", lang), base.GetPageContext().FormInfo["M1siiresaki_cd"]);
				// M1.Columns[5].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1siiresaki_ryaku_nm", lang), base.GetPageContext().FormInfo["M1siiresaki_ryaku_nm"]);
				// M1.Columns[6].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1denpyo_bango", lang), base.GetPageContext().FormInfo["M1denpyo_bango"]);
				// M1.Columns[7].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1motodenpyo_bango", lang), base.GetPageContext().FormInfo["M1motodenpyo_bango"]);
				// M1.Columns[8].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1nohin_ymd", lang), base.GetPageContext().FormInfo["M1nohin_ymd"]);
				// M1.Columns[9].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1nyuryokutan_nm", lang), base.GetPageContext().FormInfo["M1nyuryokutan_nm"]);
				// M1.Columns[10].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1itemsu", lang), base.GetPageContext().FormInfo["M1itemsu"]);
				// M1.Columns[11].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kingaku", lang), base.GetPageContext().FormInfo["M1kingaku"]);
				// M1.Columns[12].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1selectorcheckbox", lang), base.GetPageContext().FormInfo["M1selectorcheckbox"]);
				// M1.Columns[13].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1entersyoriflg", lang), base.GetPageContext().FormInfo["M1entersyoriflg"]);
				// M1.Columns[14].HeaderText = 
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
				Windowtitle.InnerText = formResource.GetString("Tf030f01_Titlebar", lang);
				header.FormName = formResource.GetString("Tf030f01_FormCaption", lang);
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
