﻿using com.xebio.bo.Te130p01.Constant;
using com.xebio.bo.Te130p01.Facade;
using com.xebio.bo.Te130p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.Model.Context;
using Common.Advanced.Resource;
using Common.Advanced.Web.Context;
using Common.Advanced.Web.Util;
using Common.Business.C01000.C01008;
using Common.Business.C01000.C01013;
using Common.Business.C01000.C01014;
using Common.Business.C01000.C01015;
using Common.Business.C01000.C01016;
using Common.Business.C99999.Constant;
using Common.Business.C99999.ReportUtil;
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
using System.Web.UI.WebControls;

namespace com.xebio.bo.Te130p01.Page
{
  /// <summary>
  /// Te130f01のコードビハインドです。
  /// </summary>
  public partial class Te130f01Page : StandardBasePage
	{

		#region メソッド

		#region ページデータをロードするメソッド
		/// <summary>
		/// Te130f01画面データを作成する。
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
						pageContext.SetFormVO(new Te130f01Form());
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
								new Te130f01Facade().DoLoad(facadeContext);
								
								#region 共通ヘッダ処理

								// 一覧画面共通処理 ----------
								LoginInfoVO loginInfVO = LoginInfoUtil.GetLoginInfo();
								Te130f01Form te130f01Form = (Te130f01Form)facadeContext.FormVO;
								ControlHeaderStoreCls.InitialSetHeaderStore<Te130f01Form>(loginInfVO, te130f01Form);
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
				//アクションコンテキストを取得する
				pageContext = base.GetPageContext();
				// 明細初期化処理
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
				new Te130f01Facade().DoBTNSEARCH_FRM(facadeContext);
				
				
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
			//フォーカス設定用変数
			string focusItem = string.Empty;
			string focusMno = string.Empty;

			// 表示明細先頭の伝票番号設定
			focusItem = "M1denpyo_bango";
			focusMno = 0.ToString();
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
				new Te130f01Facade().DoBTNPRINT_FRM(facadeContext);

				//エラー判定
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					base.SetError(pageContext);
					return;
				}

				// PDFファイル名を取得
				pdfNm = (string)facadeContext.GetUserObject(Te130p01Constant.FCDUO_RRT_FLNM);

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
											FilePathManager.GetOutFilePath(Te130p01Constant.PGID),
											Path.DirectorySeparatorChar,
											pdfNm
											);
			// クライアントファイル名
			string clientNm = string.Format("{0}.{1}",
											BoSystemReport.CreateFileName(BoSystemConstant.REPORTNM_KIGYOKANSIIREDENPYO, 2),
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
		
		#region フォームを呼び出します(ボタンID : Btncsv())
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btncsv())
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnBTNCSV_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnBTNCSV_FRM");
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

			// CSVファイル名
			string csvNm = string.Empty;
			
			try
			{

				//アクションロジックを処理します
				IFacadeContext facadeContext = FacadeContextFactory.GetFacadeContext(pageContext);
				InitFacadeContext(facadeContext);
				new Te130f01Facade().DoBTNCSV_FRM(facadeContext);

				//エラー判定
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					base.SetError(pageContext);
					return;
				}

				// CSVファイル名を取得
				csvNm = (string)facadeContext.GetUserObject(Te130p01Constant.FCDUO_CSV_FLNM);


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
			EndMethod(sender, e, this.GetType().Name + ".OnBTNCSV_FRM");
			
			#region CSV出力処理
			DLConditionVO dlvo = new DLConditionVO();
			// サーバファイルフルパス
			string serverPath = string.Format("{0}{1}{2}",
											FilePathManager.GetOutFilePath(Te130p01Constant.PGID),
											Path.DirectorySeparatorChar,
											csvNm
											);
			// クライアントファイル名
			string clientNm = string.Format("{0}{1}",
											BoSystemReport.CreateFileName(BoSystemConstant.CSVNM_KIGYOKAN,2),
											FilePathManager.EXT_CSV
											);

			// ダウンロード用VOに値を設定
			dlvo.setSingleFileDownloadCondition(serverPath, clientNm);

			// ダウンロード用VOをセッションに格納
			SessionInfoUtil.SetPgObject(BoSystemConstant.SESSION_KEY_DOWNLOAD_VO, dlvo, pageContext);

			#endregion

			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNCSV_FRM");
			
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
				new Te130f01Facade().DoPGR_PGN(facadeContext, pageindex);
				
				
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
				facadeContext.SetUserObject(Te130p01Constant.FCDUO_NEXTVO, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Te130p01Constant.FORMID_02));
				new Te130f01Facade().DoM1DENPYO_BANGO_FRM(facadeContext);

				// 次画面のフォームビーンを設定
				fvm.SetFormVO(Te130p01Constant.PGID, Te130p01Constant.FORMID_02, (Te130f02Form)facadeContext.GetUserObject(Te130p01Constant.FCDUO_NEXTVO));
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
				//	if (!MessageDisplayUtil.HasError(pageContext))
				//	{
						string lang = WebSettingsUtil.GetLangSettingFromSession(pageContext.Session);
						FormResource formResource =
							ResourceFactory.GetFormResource(pageContext.CommandInfo.FormId);
			
						//標題をセットする
						SetCaption(formResource, lang);

						//FormVOを取得する
						Te130f01Form te130f01Form = (Te130f01Form)pageContext.GetFormVO();

						//明細ページ情報を表示する
						ShowListPageInfo(te130f01Form);
			
						//明細部データを表示する
						RenderList(te130f01Form, pageContext.FormInfo, formResource, lang);

						//カード部データを表示する
						RenderCard(te130f01Form, pageContext.FormInfo, formResource, lang);
				//	}
					
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
		/// <param name="te130f01Form">画面FormVO</param>
		private void ShowListPageInfo(Te130f01Form te130f01Form)
		{
			//M1明細ページ情報を表示する。
			ShowM1ListPageInfo(te130f01Form.GetList("M1"));

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
		/// <param name="te130f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderList(
			Te130f01Form te130f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//画面のM1明細部データを設定する。
			RenderM1List(te130f01Form, formInfo, formResource, lang);
			//M1明細部のページャーにページ情報を設定する。
			RenderM1Pager(te130f01Form);
			
		}
		#endregion

		#region M1明細データを表示する
		/// <summary>
		/// M1明細データを表示する。
		/// </summary>
		/// <param name="te130f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderM1List(
			Te130f01Form te130f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//M1明細部データソースを設定する。
			M1.DataSource = te130f01Form.GetPageViewList("M1");
			M1.DataBind();

			//M1明細部データをフォーマットする。
			IList m1DataList = (IList)M1.DataSource;
			
			for (int index = 0; index < M1.Items.Count; index++)
			{
				Te130f01M1Form te130f01M1Form = (Te130f01M1Form)m1DataList[index];
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1rowno"),
					DataFormatUtil.GetFormatItem(te130f01M1Form.M1rowno,formInfo["M1rowno"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1syukkakaisya_cd"),
					DataFormatUtil.GetFormatItem(te130f01M1Form.M1syukkakaisya_cd,formInfo["M1syukkakaisya_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1syukkaten_cd"),
					DataFormatUtil.GetFormatItem(te130f01M1Form.M1syukkaten_cd,formInfo["M1syukkaten_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1syukkatenpo_nm"),
					DataFormatUtil.GetFormatItem(te130f01M1Form.M1syukkatenpo_nm,formInfo["M1syukkatenpo_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1jyuryokaisya_cd"),
					DataFormatUtil.GetFormatItem(te130f01M1Form.M1jyuryokaisya_cd,formInfo["M1jyuryokaisya_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1jyuryoten_cd"),
					DataFormatUtil.GetFormatItem(te130f01M1Form.M1jyuryoten_cd,formInfo["M1jyuryoten_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1juryoten_nm"),
					DataFormatUtil.GetFormatItem(te130f01M1Form.M1juryoten_nm,formInfo["M1juryoten_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1idodenpyo_bango"),
					DataFormatUtil.GetFormatItem(te130f01M1Form.M1idodenpyo_bango,formInfo["M1idodenpyo_bango"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1siji_bango"),
					DataFormatUtil.GetFormatItem(te130f01M1Form.M1siji_bango,formInfo["M1siji_bango"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1syukka_ymd"),
					DataFormatUtil.GetFormatItem(te130f01M1Form.M1syukka_ymd,formInfo["M1syukka_ymd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1jyuryo_ymd"),
					DataFormatUtil.GetFormatItem(te130f01M1Form.M1jyuryo_ymd,formInfo["M1jyuryo_ymd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1nyukayotei_su"),
					DataFormatUtil.GetFormatItem(te130f01M1Form.M1nyukayotei_su,formInfo["M1nyukayotei_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1nyukajisseki_su"),
					DataFormatUtil.GetFormatItem(te130f01M1Form.M1nyukajisseki_su,formInfo["M1nyukajisseki_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1kyakucyu"),
					DataFormatUtil.GetFormatItem(te130f01M1Form.M1kyakucyu,formInfo["M1kyakucyu"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1syorinm"),
					DataFormatUtil.GetFormatItem(te130f01M1Form.M1syorinm,formInfo["M1syorinm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1syori_ymd"),
					DataFormatUtil.GetFormatItem(te130f01M1Form.M1syori_ymd,formInfo["M1syori_ymd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1syori_tm"),
					DataFormatUtil.GetFormatItem(te130f01M1Form.M1syori_tm,formInfo["M1syori_tm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1selectorcheckbox"),
					DataFormatUtil.GetFormatItem(te130f01M1Form.M1selectorcheckbox,formInfo["M1selectorcheckbox"]));
				((System.Web.UI.WebControls.CheckBox)M1.Items[index].FindControl("M1selectorcheckbox")).Text =
					formResource.GetString("M1selectorcheckbox", lang);
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1entersyoriflg"),
					DataFormatUtil.GetFormatItem(te130f01M1Form.M1entersyoriflg,formInfo["M1entersyoriflg"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1dtlirokbn"),
					DataFormatUtil.GetFormatItem(te130f01M1Form.M1dtlirokbn,formInfo["M1dtlirokbn"]));

				if(!base.CheckUseSelfCustomize()){
					((System.Web.UI.HtmlControls.HtmlInputButton)M1.Items[index].FindControl("M1denpyo_bango")).Value =
						 te130f01M1Form.Dictionary[Te130p01Constant.DIC_M1DENPYOBANGO].ToString();

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
				// (M1.HeaderRow.FindControl("M1syukkakaisya_cd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syukkakaisya_cd", lang), base.GetPageContext().FormInfo["M1syukkakaisya_cd"]);
				// (M1.HeaderRow.FindControl("M1syukkaten_cd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syukkaten_cd", lang), base.GetPageContext().FormInfo["M1syukkaten_cd"]);
				// (M1.HeaderRow.FindControl("M1syukkatenpo_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syukkatenpo_nm", lang), base.GetPageContext().FormInfo["M1syukkatenpo_nm"]);
				// (M1.HeaderRow.FindControl("M1jyuryokaisya_cd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1jyuryokaisya_cd", lang), base.GetPageContext().FormInfo["M1jyuryokaisya_cd"]);
				// (M1.HeaderRow.FindControl("M1jyuryoten_cd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1jyuryoten_cd", lang), base.GetPageContext().FormInfo["M1jyuryoten_cd"]);
				// (M1.HeaderRow.FindControl("M1juryoten_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1juryoten_nm", lang), base.GetPageContext().FormInfo["M1juryoten_nm"]);
				// (M1.HeaderRow.FindControl("M1denpyo_bango") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1denpyo_bango", lang), base.GetPageContext().FormInfo["M1denpyo_bango"]);
				// (M1.HeaderRow.FindControl("M1idodenpyo_bango") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1idodenpyo_bango", lang), base.GetPageContext().FormInfo["M1idodenpyo_bango"]);
				// (M1.HeaderRow.FindControl("M1siji_bango") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1siji_bango", lang), base.GetPageContext().FormInfo["M1siji_bango"]);
				// (M1.HeaderRow.FindControl("M1syukka_ymd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syukka_ymd", lang), base.GetPageContext().FormInfo["M1syukka_ymd"]);
				// (M1.HeaderRow.FindControl("M1jyuryo_ymd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1jyuryo_ymd", lang), base.GetPageContext().FormInfo["M1jyuryo_ymd"]);
				// (M1.HeaderRow.FindControl("M1nyukayotei_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1nyukayotei_su", lang), base.GetPageContext().FormInfo["M1nyukayotei_su"]);
				// (M1.HeaderRow.FindControl("M1nyukajisseki_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1nyukajisseki_su", lang), base.GetPageContext().FormInfo["M1nyukajisseki_su"]);
				// (M1.HeaderRow.FindControl("M1kyakucyu") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kyakucyu", lang), base.GetPageContext().FormInfo["M1kyakucyu"]);
				// (M1.HeaderRow.FindControl("M1syorinm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syorinm", lang), base.GetPageContext().FormInfo["M1syorinm"]);
				// (M1.HeaderRow.FindControl("M1syori_ymd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syori_ymd", lang), base.GetPageContext().FormInfo["M1syori_ymd"]);
				// (M1.HeaderRow.FindControl("M1syori_tm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syori_tm", lang), base.GetPageContext().FormInfo["M1syori_tm"]);
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
		/// <param name="te130f01Form">画面FormVO</param>
		private void RenderM1Pager(Te130f01Form te130f01Form)
		{
			Pgr.VirtualItemCount = te130f01Form.GetList("M1").RecordCount;
			Pgr.CurrentPageIndex = te130f01Form.GetList("M1").PageNo - 1;
			Pgr.PageSize = te130f01Form.GetList("M1").DispRow;
		}
		#endregion
		#endregion

		#region カードデータを表示する
		/// <summary>
		/// カードデータを表示する
		/// </summary>
		/// <param name="te130f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderCard(
			Te130f01Form te130f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			
			ControlUtil.SetControlValue(Head_tenpo_cd,
				DataFormatUtil.GetFormatItem(te130f01Form.Head_tenpo_cd,formInfo["Head_tenpo_cd"]));
			ControlUtil.SetControlValue(Head_tenpo_nm,
				DataFormatUtil.GetFormatItem(te130f01Form.Head_tenpo_nm,formInfo["Head_tenpo_nm"]));
			ControlUtil.SetControlValue(Denpyo_jyotai,
				DataFormatUtil.GetFormatItem(te130f01Form.Denpyo_jyotai,formInfo["Denpyo_jyotai"]));
			ControlUtil.SetControlValue(Denpyo_bango_from,
				DataFormatUtil.GetFormatItem(te130f01Form.Denpyo_bango_from,formInfo["Denpyo_bango_from"]));
			ControlUtil.SetControlValue(Denpyo_bango_to,
				DataFormatUtil.GetFormatItem(te130f01Form.Denpyo_bango_to,formInfo["Denpyo_bango_to"]));
			ControlUtil.SetControlValue(Idodenpyo_bango_from,
				DataFormatUtil.GetFormatItem(te130f01Form.Idodenpyo_bango_from,formInfo["Idodenpyo_bango_from"]));
			ControlUtil.SetControlValue(Idodenpyo_bango_to,
				DataFormatUtil.GetFormatItem(te130f01Form.Idodenpyo_bango_to,formInfo["Idodenpyo_bango_to"]));
			ControlUtil.SetControlValue(Siji_bango_from,
				DataFormatUtil.GetFormatItem(te130f01Form.Siji_bango_from,formInfo["Siji_bango_from"]));
			ControlUtil.SetControlValue(Siji_bango_to,
				DataFormatUtil.GetFormatItem(te130f01Form.Siji_bango_to,formInfo["Siji_bango_to"]));
			ControlUtil.SetControlValue(Jyuryokaisya_cd,
				DataFormatUtil.GetFormatItem(te130f01Form.Jyuryokaisya_cd,formInfo["Jyuryokaisya_cd"]));
			ControlUtil.SetControlValue(Nyukakaisya_nm,
				DataFormatUtil.GetFormatItem(te130f01Form.Nyukakaisya_nm,formInfo["Nyukakaisya_nm"]));
			ControlUtil.SetControlValue(Jyuryoten_cd,
				DataFormatUtil.GetFormatItem(te130f01Form.Jyuryoten_cd,formInfo["Jyuryoten_cd"]));
			ControlUtil.SetControlValue(Juryoten_nm,
				DataFormatUtil.GetFormatItem(te130f01Form.Juryoten_nm,formInfo["Juryoten_nm"]));
			ControlUtil.SetControlValue(Jyuryo_ymd_from,
				DataFormatUtil.GetFormatItem(te130f01Form.Jyuryo_ymd_from,formInfo["Jyuryo_ymd_from"]));
			ControlUtil.SetControlValue(Jyuryo_ymd_to,
				DataFormatUtil.GetFormatItem(te130f01Form.Jyuryo_ymd_to,formInfo["Jyuryo_ymd_to"]));
			ControlUtil.SetControlValue(Syukkakaisya_cd,
				DataFormatUtil.GetFormatItem(te130f01Form.Syukkakaisya_cd,formInfo["Syukkakaisya_cd"]));
			ControlUtil.SetControlValue(Syukkakaisya_nm,
				DataFormatUtil.GetFormatItem(te130f01Form.Syukkakaisya_nm,formInfo["Syukkakaisya_nm"]));
			ControlUtil.SetControlValue(Syukkaten_cd,
				DataFormatUtil.GetFormatItem(te130f01Form.Syukkaten_cd,formInfo["Syukkaten_cd"]));
			ControlUtil.SetControlValue(Syukkatenpo_nm,
				DataFormatUtil.GetFormatItem(te130f01Form.Syukkatenpo_nm,formInfo["Syukkatenpo_nm"]));
			ControlUtil.SetControlValue(Syukka_ymd_from,
				DataFormatUtil.GetFormatItem(te130f01Form.Syukka_ymd_from,formInfo["Syukka_ymd_from"]));
			ControlUtil.SetControlValue(Syukka_ymd_to,
				DataFormatUtil.GetFormatItem(te130f01Form.Syukka_ymd_to,formInfo["Syukka_ymd_to"]));
			ControlUtil.SetControlValue(Old_jisya_hbn,
				DataFormatUtil.GetFormatItem(te130f01Form.Old_jisya_hbn,formInfo["Old_jisya_hbn"]));
			ControlUtil.SetControlValue(Maker_hbn,
				DataFormatUtil.GetFormatItem(te130f01Form.Maker_hbn,formInfo["Maker_hbn"]));
			ControlUtil.SetControlValue(Scan_cd,
				DataFormatUtil.GetFormatItem(te130f01Form.Scan_cd,formInfo["Scan_cd"]));
			ControlUtil.SetControlValue(Searchcnt,
				DataFormatUtil.GetFormatItem(te130f01Form.Searchcnt, formInfo["Searchcnt"]));


			if(!base.CheckUseSelfCustomize()){
				Btnheadtenpocd.Value = base.FormResourceGetString(formResource, "Btnheadtenpocd", lang);
				Btntenpocd.Value = base.FormResourceGetString(formResource, "Btntenpocd", lang);
				Btnkaisha_cd.Value = base.FormResourceGetString(formResource, "Btnkaisha_cd", lang);
				Btnsyukkatencd.Value = base.FormResourceGetString(formResource, "Btnsyukkatencd", lang);
				Btnsearch.Value = base.FormResourceGetString(formResource, "Btnsearch", lang);
				Btnprint.Value = base.FormResourceGetString(formResource, "Btnprint", lang);
				Btncsv.Value = base.FormResourceGetString(formResource, "Btncsv", lang);
				Pgr.Text = base.FormResourceGetString(formResource, "Pgr", lang);
			}

		}
		#endregion

		#region Items設定(ドロップダウンリストのItems)
		/// <summary>
		/// ドロップダウンリストのItemsを設定します。
		/// </summary>
		protected override void SetItems()
		{
			if (!IsPostBack)
			{
				// 伝票状態に空白を追加
				Denpyo_jyotai.Items.Insert(0, new ListItem("", BoSystemConstant.DROPDOWNLIST_MISENTAKU));
			}
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
			// UIScreenController controller = new UIScreenController((Te130f01Form)base.GetPageContext().GetFormVO());
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
			// ログイン情報取得
			LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();
			if (base.GetPageContext().CommandInfo.ActionMode.Equals("INI"))
			{
				if (!CheckKengenCls.CheckKengen(loginInfVO))//本部以外
				{
					ControlCls.Disable(Jyuryoten_cd, true);
				}
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

				// [伝票状態]が「登録履歴」、「取消履歴」の場合
				if (Denpyo_jyotai.SelectedValue.Equals(ConditionKigyokan_denpyo_jotai.VALUE_DENPYO_JOTAI4)
					|| Denpyo_jyotai.SelectedValue.Equals(ConditionKigyokan_denpyo_jotai.VALUE_DENPYO_JOTAI5))
				{
					// 印刷ボタン使用不可
					ControlCls.Disable(Btnprint, true);
				}
				else
				{
					// 印刷ボタン使用可
					ControlCls.Disable(Btnprint, false);
				}
				////権限取得部品(C01008①ログイン情報)の戻り値が"FALSE"(店舗端末)、かつXの場合、非表示
				//if (CheckCompanyCls.IsXebio() && !CheckKengenCls.CheckKengen(loginInfVO))
				//{
				//	// CSVボタン使用不可
				//	ControlCls.Disable(Btncsv, true);
				//}
				//else
				//{
				//	// CSVボタン使用可
				//	ControlCls.Disable(Btncsv, false);
				//}
				Te130f01Form formVo = (Te130f01Form)base.GetPageContext().GetFormVO();
			}

			for (int index = 0; index < M1.Items.Count; index++)
			{

				String yoteisu;
				String kakuteisu;

				yoteisu = ((System.Web.UI.WebControls.TextBox)M1.Items[index].FindControl("M1nyukayotei_su")).Text;
				kakuteisu = ((System.Web.UI.WebControls.TextBox)M1.Items[index].FindControl("M1nyukajisseki_su")).Text;
				// 予定数量と確定数量の値が異なる場合
				//if (((prevM1Vo.Dictionary[Te070p01Constant.DIC_M1KAKUTEI_FLG]).Equals(Te070p01Constant.DIC_M1KAKUTEIFLG)) &&  (yoteisu != kakuteisu))
				if (yoteisu != kakuteisu)
				{

					//確定数量の文字色を赤にする。
					((TextBox)M1.Items[index].FindControl("M1nyukajisseki_su")).Style.Add("color", "red");

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
			ControlUtil.SetControlValue(Denpyo_jyotai_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Denpyo_jyotai", lang), base.GetPageContext().FormInfo["Denpyo_jyotai"]));
				DataFormatUtil.SetMustColorCaption(Denpyo_jyotai_lbl, base.GetPageContext().FormInfo["Denpyo_jyotai"]);
			//ControlUtil.SetControlValue(Denpyo_bango_from_lbl, 
				ControlUtil.SetControlValue(Denpyo_bango_from_lbl, "伝票番号");
				//DataFormatUtil.GetFormatCaption(formResource.GetString("Denpyo_bango_from", lang), base.GetPageContext().FormInfo["Denpyo_bango_from"]));
				DataFormatUtil.SetMustColorCaption(Denpyo_bango_from_lbl, base.GetPageContext().FormInfo["Denpyo_bango_from"]);
			ControlUtil.SetControlValue(Denpyo_bango_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Denpyo_bango_to", lang), base.GetPageContext().FormInfo["Denpyo_bango_to"]));
				DataFormatUtil.SetMustColorCaption(Denpyo_bango_to_lbl, base.GetPageContext().FormInfo["Denpyo_bango_to"]);
			ControlUtil.SetControlValue(Idodenpyo_bango_from_lbl,"移動伝票"); 
				//DataFormatUtil.GetFormatCaption(formResource.GetString("Idodenpyo_bango_from", lang), base.GetPageContext().FormInfo["Idodenpyo_bango_from"]));
				DataFormatUtil.SetMustColorCaption(Idodenpyo_bango_from_lbl, base.GetPageContext().FormInfo["Idodenpyo_bango_from"]);
			ControlUtil.SetControlValue(Idodenpyo_bango_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Idodenpyo_bango_to", lang), base.GetPageContext().FormInfo["Idodenpyo_bango_to"]));
				DataFormatUtil.SetMustColorCaption(Idodenpyo_bango_to_lbl, base.GetPageContext().FormInfo["Idodenpyo_bango_to"]);
			ControlUtil.SetControlValue(Siji_bango_from_lbl, "指示番号");
				//DataFormatUtil.GetFormatCaption(formResource.GetString("Siji_bango_from", lang), base.GetPageContext().FormInfo["Siji_bango_from"]));
				DataFormatUtil.SetMustColorCaption(Siji_bango_from_lbl, base.GetPageContext().FormInfo["Siji_bango_from"]);
			ControlUtil.SetControlValue(Siji_bango_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Siji_bango_to", lang), base.GetPageContext().FormInfo["Siji_bango_to"]));
				DataFormatUtil.SetMustColorCaption(Siji_bango_to_lbl, base.GetPageContext().FormInfo["Siji_bango_to"]);
			ControlUtil.SetControlValue(Jyuryokaisya_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Jyuryokaisya_cd", lang), base.GetPageContext().FormInfo["Jyuryokaisya_cd"]));
				DataFormatUtil.SetMustColorCaption(Jyuryokaisya_cd_lbl, base.GetPageContext().FormInfo["Jyuryokaisya_cd"]);
			ControlUtil.SetControlValue(Nyukakaisya_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Nyukakaisya_nm", lang), base.GetPageContext().FormInfo["Nyukakaisya_nm"]));
				DataFormatUtil.SetMustColorCaption(Nyukakaisya_nm_lbl, base.GetPageContext().FormInfo["Nyukakaisya_nm"]);
			ControlUtil.SetControlValue(Jyuryoten_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Jyuryoten_cd", lang), base.GetPageContext().FormInfo["Jyuryoten_cd"]));
				DataFormatUtil.SetMustColorCaption(Jyuryoten_cd_lbl, base.GetPageContext().FormInfo["Jyuryoten_cd"]);
			ControlUtil.SetControlValue(Juryoten_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Juryoten_nm", lang), base.GetPageContext().FormInfo["Juryoten_nm"]));
				DataFormatUtil.SetMustColorCaption(Juryoten_nm_lbl, base.GetPageContext().FormInfo["Juryoten_nm"]);
			ControlUtil.SetControlValue(Jyuryo_ymd_from_lbl, "入荷日");
				//DataFormatUtil.GetFormatCaption(formResource.GetString("Jyuryo_ymd_from", lang), base.GetPageContext().FormInfo["Jyuryo_ymd_from"]));
				DataFormatUtil.SetMustColorCaption(Jyuryo_ymd_from_lbl, base.GetPageContext().FormInfo["Jyuryo_ymd_from"]);
			ControlUtil.SetControlValue(Jyuryo_ymd_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Jyuryo_ymd_to", lang), base.GetPageContext().FormInfo["Jyuryo_ymd_to"]));
				DataFormatUtil.SetMustColorCaption(Jyuryo_ymd_to_lbl, base.GetPageContext().FormInfo["Jyuryo_ymd_to"]);
			ControlUtil.SetControlValue(Syukkakaisya_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Syukkakaisya_cd", lang), base.GetPageContext().FormInfo["Syukkakaisya_cd"]));
				DataFormatUtil.SetMustColorCaption(Syukkakaisya_cd_lbl, base.GetPageContext().FormInfo["Syukkakaisya_cd"]);
			ControlUtil.SetControlValue(Syukkakaisya_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Syukkakaisya_nm", lang), base.GetPageContext().FormInfo["Syukkakaisya_nm"]));
				DataFormatUtil.SetMustColorCaption(Syukkakaisya_nm_lbl, base.GetPageContext().FormInfo["Syukkakaisya_nm"]);
			ControlUtil.SetControlValue(Syukkaten_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Syukkaten_cd", lang), base.GetPageContext().FormInfo["Syukkaten_cd"]));
				DataFormatUtil.SetMustColorCaption(Syukkaten_cd_lbl, base.GetPageContext().FormInfo["Syukkaten_cd"]);
			ControlUtil.SetControlValue(Syukkatenpo_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Syukkatenpo_nm", lang), base.GetPageContext().FormInfo["Syukkatenpo_nm"]));
				DataFormatUtil.SetMustColorCaption(Syukkatenpo_nm_lbl, base.GetPageContext().FormInfo["Syukkatenpo_nm"]);
			ControlUtil.SetControlValue(Syukka_ymd_from_lbl, "出荷日");
				//DataFormatUtil.GetFormatCaption(formResource.GetString("Syukka_ymd_from", lang), base.GetPageContext().FormInfo["Syukka_ymd_from"]));
				DataFormatUtil.SetMustColorCaption(Syukka_ymd_from_lbl, base.GetPageContext().FormInfo["Syukka_ymd_from"]);
			ControlUtil.SetControlValue(Syukka_ymd_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Syukka_ymd_to", lang), base.GetPageContext().FormInfo["Syukka_ymd_to"]));
				DataFormatUtil.SetMustColorCaption(Syukka_ymd_to_lbl, base.GetPageContext().FormInfo["Syukka_ymd_to"]);
			ControlUtil.SetControlValue(Old_jisya_hbn_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Old_jisya_hbn", lang), base.GetPageContext().FormInfo["Old_jisya_hbn"]));
				DataFormatUtil.SetMustColorCaption(Old_jisya_hbn_lbl, base.GetPageContext().FormInfo["Old_jisya_hbn"]);
			ControlUtil.SetControlValue(Maker_hbn_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Maker_hbn", lang), base.GetPageContext().FormInfo["Maker_hbn"]));
				DataFormatUtil.SetMustColorCaption(Maker_hbn_lbl, base.GetPageContext().FormInfo["Maker_hbn"]);
			ControlUtil.SetControlValue(Scan_cd_lbl,"ｽｷｬﾝｺｰﾄﾞ"); 
				//DataFormatUtil.GetFormatCaption(formResource.GetString("Scan_cd", lang), base.GetPageContext().FormInfo["Scan_cd"]));
				DataFormatUtil.SetMustColorCaption(Scan_cd_lbl, base.GetPageContext().FormInfo["Scan_cd"]);
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
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syukkakaisya_cd", lang), base.GetPageContext().FormInfo["M1syukkakaisya_cd"]);
				// M1.Columns[2].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syukkaten_cd", lang), base.GetPageContext().FormInfo["M1syukkaten_cd"]);
				// M1.Columns[3].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syukkatenpo_nm", lang), base.GetPageContext().FormInfo["M1syukkatenpo_nm"]);
				// M1.Columns[4].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1jyuryokaisya_cd", lang), base.GetPageContext().FormInfo["M1jyuryokaisya_cd"]);
				// M1.Columns[5].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1jyuryoten_cd", lang), base.GetPageContext().FormInfo["M1jyuryoten_cd"]);
				// M1.Columns[6].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1juryoten_nm", lang), base.GetPageContext().FormInfo["M1juryoten_nm"]);
				// M1.Columns[7].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1denpyo_bango", lang), base.GetPageContext().FormInfo["M1denpyo_bango"]);
				// M1.Columns[8].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1idodenpyo_bango", lang), base.GetPageContext().FormInfo["M1idodenpyo_bango"]);
				// M1.Columns[9].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1siji_bango", lang), base.GetPageContext().FormInfo["M1siji_bango"]);
				// M1.Columns[10].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syukka_ymd", lang), base.GetPageContext().FormInfo["M1syukka_ymd"]);
				// M1.Columns[11].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1jyuryo_ymd", lang), base.GetPageContext().FormInfo["M1jyuryo_ymd"]);
				// M1.Columns[12].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1nyukayotei_su", lang), base.GetPageContext().FormInfo["M1nyukayotei_su"]);
				// M1.Columns[13].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1nyukajisseki_su", lang), base.GetPageContext().FormInfo["M1nyukajisseki_su"]);
				// M1.Columns[14].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kyakucyu", lang), base.GetPageContext().FormInfo["M1kyakucyu"]);
				// M1.Columns[15].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syorinm", lang), base.GetPageContext().FormInfo["M1syorinm"]);
				// M1.Columns[16].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syori_ymd", lang), base.GetPageContext().FormInfo["M1syori_ymd"]);
				// M1.Columns[17].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syori_tm", lang), base.GetPageContext().FormInfo["M1syori_tm"]);
				// M1.Columns[18].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1selectorcheckbox", lang), base.GetPageContext().FormInfo["M1selectorcheckbox"]);
				// M1.Columns[19].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1entersyoriflg", lang), base.GetPageContext().FormInfo["M1entersyoriflg"]);
				// M1.Columns[20].HeaderText = 
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
				Windowtitle.InnerText = formResource.GetString("Te130f01_Titlebar", lang);
				header.FormName = formResource.GetString("Te130f01_FormCaption", lang);
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
