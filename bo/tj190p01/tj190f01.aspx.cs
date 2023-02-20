using com.xebio.bo.Tj190p01.Constant;
using com.xebio.bo.Tj190p01.Facade;
using com.xebio.bo.Tj190p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.Model.Context;
using Common.Advanced.Resource;
using Common.Advanced.Web.Context;
using Common.Advanced.Web.Util;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01008;
using Common.Business.C01000.C01013;
using Common.Business.C01000.C01014;
using Common.Business.C01000.C01015;
using Common.Business.C01000.C01016;
using Common.Business.C01000.C01026;
using Common.Business.C99999.Constant;
using Common.Business.C99999.ReportUtil;
using Common.Business.C99999.StringUtil;
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

namespace com.xebio.bo.Tj190p01.Page
{
  /// <summary>
  /// Tj190f01のコードビハインドです。
  /// </summary>
  public partial class Tj190f01Page : StandardBasePage
	{

		#region メソッド

		#region ページデータをロードするメソッド
		/// <summary>
		/// Tj190f01画面データを作成する。
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
						pageContext.SetFormVO(new Tj190f01Form());
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
								new Tj190f01Facade().DoLoad(facadeContext);

								#region 共通ヘッダ処理

								// 一覧画面共通処理 ----------
								LoginInfoVO loginInfVO = LoginInfoUtil.GetLoginInfo();
								Tj190f01Form tj190f01Form = (Tj190f01Form)facadeContext.FormVO;
								ControlHeaderStoreCls.InitialSetHeaderStore<Tj190f01Form>(loginInfVO, tj190f01Form);
								// 一覧画面共通処理 ----------

								if (string.IsNullOrEmpty(tj190f01Form.Modeno))
								{
									// アコーディオンなし
									AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_NONE);
									// モードNoを照会に設定
									tj190f01Form.Modeno = BoSystemConstant.MODE_UPD.ToString();
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
					Tj190f01Form f01VO = (Tj190f01Form)fvm.GetProgramVO(base.GetPageContext().CommandInfo.ProgramId).GetFormVO(Tj190p01Constant.FORMID_01);
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
				AccordionUtil.SetAccordionKbn(base.GetPageContext(), BoSystemConstant.ACCORDION_ST_NONE);
				Stkmodeno.Value = string.Empty;
				SetItems();
				SetAttribute();

				//アクションコンテキストを取得する
				pageContext = base.GetPageContext();
				// モード表示クリア処理
				ModeUtil.ClearMode(pageContext);
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
				// モード表示クリア処理
				ModeUtil.ClearMode(pageContext);

				//アクションロジックを処理します
				IFacadeContext facadeContext = FacadeContextFactory.GetFacadeContext(pageContext);
				InitFacadeContext(facadeContext);

				new Tj190f01Facade().DoBTNSEARCH_FRM(facadeContext);
	
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
				ModeUtil.SetMode(pageContext, ModeCls.GetModeNm(((Tj190f01Form)pageContext.GetFormVO()).Stkmodeno));
				
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
				new Tj190f01Facade().DoBTNPRINT_FRM(facadeContext);

				// PDFファイル名を取得
				pdfNm = (string)facadeContext.GetUserObject(Tj190p01Constant.FCDUO_RRT_FLNM);

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
											FilePathManager.GetOutFilePath(Tj190p01Constant.PGID),
											Path.DirectorySeparatorChar,
											pdfNm
											);
			// クライアントファイル名
			string clientNm = string.Format("{0}.{1}",
											BoSystemReport.CreateFileName(BoSystemConstant.REPORTNM_RINJITANAOROSILOSSLIST, 2),
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
				new Tj190f01Facade().DoBTNCSV_FRM(facadeContext);
				
				
				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
					base.SetError(pageContext);
					return;
				}

				// CSVファイル名を取得
				csvNm = (string)facadeContext.GetUserObject(Tj190p01Constant.FCDUO_CSV_FLNM);
				
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
			#region CSV出力処理

			DLConditionVO dlvo = new DLConditionVO();
			// サーバファイルフルパス
			string serverPath = string.Format("{0}{1}{2}",
											FilePathManager.GetOutFilePath(Tj190p01Constant.PGID),
											Path.DirectorySeparatorChar,
											csvNm
											);
			// クライアントファイル名
			string clientNm = string.Format("{0}{1}",
											BoSystemReport.CreateFileName(BoSystemConstant.CSVNM_RINTANA, 2),
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
			//base.DownloadPageStartUp(pageContext, dlvo);
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
				new Tj190f01Facade().DoPGR_PGN(facadeContext, pageindex);
				
				
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
				facadeContext.SetUserObject(Tj190p01Constant.FCDUO_NEXTVO, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Tj190p01Constant.FORMID_02));

				new Tj190f01Facade().DoM1BUMON_CD_FRM(facadeContext);

				// 次画面のフォームビーンを設定
				fvm.SetFormVO(Tj190p01Constant.PGID, Tj190p01Constant.FORMID_02, (Tj190f02Form)facadeContext.GetUserObject(Tj190p01Constant.FCDUO_NEXTVO));

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

			if (BoSystemConstant.MODE_UPD.Equals(Stkmodeno)) {
				// フォーカス設定用変数
				string focusItem = string.Empty;
				string focusMno = string.Empty;

				focusItem = "Hinsyu_sitei_flg";

				// フォーカス設定
				SetFocusCls.SetFocus(queryList, focusItem, focusMno);
			}
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

				new Tj190f01Facade().DoBTNENTER_FRM(facadeContext);

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
						Tj190f01Form tj190f01Form = (Tj190f01Form)pageContext.GetFormVO();

						//明細ページ情報を表示する
						ShowListPageInfo(tj190f01Form);
			
						//明細部データを表示する
						RenderList(tj190f01Form, pageContext.FormInfo, formResource, lang);

						//カード部データを表示する
						RenderCard(tj190f01Form, pageContext.FormInfo, formResource, lang);
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
		/// <param name="tj190f01Form">画面FormVO</param>
		private void ShowListPageInfo(Tj190f01Form tj190f01Form)
		{
			//M1明細ページ情報を表示する。
			ShowM1ListPageInfo(tj190f01Form.GetList("M1"));

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
		/// <param name="tj190f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderList(
			Tj190f01Form tj190f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//画面のM1明細部データを設定する。
			RenderM1List(tj190f01Form, formInfo, formResource, lang);
			//M1明細部のページャーにページ情報を設定する。
			RenderM1Pager(tj190f01Form);
			
		}
		#endregion

		#region M1明細データを表示する
		/// <summary>
		/// M1明細データを表示する。
		/// </summary>
		/// <param name="tj190f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderM1List(
			Tj190f01Form tj190f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//M1明細部データソースを設定する。
			M1.DataSource = tj190f01Form.GetPageViewList("M1");
			M1.DataBind();

			//M1明細部データをフォーマットする。
			IList m1DataList = (IList)M1.DataSource;
			
			for (int index = 0; index < M1.Items.Count; index++)
			{
				Tj190f01M1Form tj190f01M1Form = (Tj190f01M1Form)m1DataList[index];
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1rowno"),
					DataFormatUtil.GetFormatItem(tj190f01M1Form.M1rowno,formInfo["M1rowno"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1tenpo_cd"),
					DataFormatUtil.GetFormatItem(tj190f01M1Form.M1tenpo_cd,formInfo["M1tenpo_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1tenpo_nm"),
					DataFormatUtil.GetFormatItem(tj190f01M1Form.M1tenpo_nm,formInfo["M1tenpo_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1nyuryoku_ymd"),
					DataFormatUtil.GetFormatItem(tj190f01M1Form.M1nyuryoku_ymd,formInfo["M1nyuryoku_ymd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1rintana_kanri_no"),
					DataFormatUtil.GetFormatItem(tj190f01M1Form.M1rintana_kanri_no,formInfo["M1rintana_kanri_no"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1loss_kanri_no"),
					DataFormatUtil.GetFormatItem(tj190f01M1Form.M1loss_kanri_no,formInfo["M1loss_kanri_no"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1hinsyu_ryaku_nm"),
					DataFormatUtil.GetFormatItem(tj190f01M1Form.M1hinsyu_ryaku_nm,formInfo["M1hinsyu_ryaku_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1burando_nm1"),
					DataFormatUtil.GetFormatItem(tj190f01M1Form.M1burando_nm1,formInfo["M1burando_nm1"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1burando_nm2"),
					DataFormatUtil.GetFormatItem(tj190f01M1Form.M1burando_nm2,formInfo["M1burando_nm2"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1burando_nm3"),
					DataFormatUtil.GetFormatItem(tj190f01M1Form.M1burando_nm3,formInfo["M1burando_nm3"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1burando_nm4"),
					DataFormatUtil.GetFormatItem(tj190f01M1Form.M1burando_nm4,formInfo["M1burando_nm4"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1burando_nm5"),
					DataFormatUtil.GetFormatItem(tj190f01M1Form.M1burando_nm5,formInfo["M1burando_nm5"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1burando_nm6"),
					DataFormatUtil.GetFormatItem(tj190f01M1Form.M1burando_nm6,formInfo["M1burando_nm6"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1burando_nm7"),
					DataFormatUtil.GetFormatItem(tj190f01M1Form.M1burando_nm7,formInfo["M1burando_nm7"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1burando_nm8"),
					DataFormatUtil.GetFormatItem(tj190f01M1Form.M1burando_nm8,formInfo["M1burando_nm8"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1tanajityobo_su"),
					DataFormatUtil.GetFormatItem(tj190f01M1Form.M1tanajityobo_su,formInfo["M1tanajityobo_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1tanajisekiso_su"),
					DataFormatUtil.GetFormatItem(tj190f01M1Form.M1tanajisekiso_su,formInfo["M1tanajisekiso_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1jitana_su"),
					DataFormatUtil.GetFormatItem(tj190f01M1Form.M1jitana_su,formInfo["M1jitana_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1nyuryokutan_nm"),
					DataFormatUtil.GetFormatItem(tj190f01M1Form.M1nyuryokutan_nm,formInfo["M1nyuryokutan_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1loss_su"),
					DataFormatUtil.GetFormatItem(tj190f01M1Form.M1loss_su,formInfo["M1loss_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1loss_kin"),
					DataFormatUtil.GetFormatItem(tj190f01M1Form.M1loss_kin,formInfo["M1loss_kin"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1losskeisan_ymd"),
					DataFormatUtil.GetFormatItem(tj190f01M1Form.M1losskeisan_ymd,formInfo["M1losskeisan_ymd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1losskeisan_tm"),
					DataFormatUtil.GetFormatItem(tj190f01M1Form.M1losskeisan_tm,formInfo["M1losskeisan_tm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1selectorcheckbox"),
					DataFormatUtil.GetFormatItem(tj190f01M1Form.M1selectorcheckbox,formInfo["M1selectorcheckbox"]));
				((System.Web.UI.WebControls.CheckBox)M1.Items[index].FindControl("M1selectorcheckbox")).Text =
					formResource.GetString("M1selectorcheckbox", lang);
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1entersyoriflg"),
					DataFormatUtil.GetFormatItem(tj190f01M1Form.M1entersyoriflg,formInfo["M1entersyoriflg"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1dtlirokbn"),
					DataFormatUtil.GetFormatItem(tj190f01M1Form.M1dtlirokbn,formInfo["M1dtlirokbn"]));

				if(!base.CheckUseSelfCustomize()){
					((System.Web.UI.HtmlControls.HtmlInputButton)M1.Items[index].FindControl("M1bumon_cd")).Value =
						tj190f01M1Form.Dictionary[Tj190p01Constant.DIC_M1BUMON_CD].ToString() + " " + tj190f01M1Form.Dictionary[Tj190p01Constant.DIC_M1BUMON_NM].ToString();
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
				// (M1.HeaderRow.FindControl("M1tenpo_cd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tenpo_cd", lang), base.GetPageContext().FormInfo["M1tenpo_cd"]);
				// (M1.HeaderRow.FindControl("M1tenpo_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tenpo_nm", lang), base.GetPageContext().FormInfo["M1tenpo_nm"]);
				// (M1.HeaderRow.FindControl("M1nyuryoku_ymd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1nyuryoku_ymd", lang), base.GetPageContext().FormInfo["M1nyuryoku_ymd"]);
				// (M1.HeaderRow.FindControl("M1rintana_kanri_no") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1rintana_kanri_no", lang), base.GetPageContext().FormInfo["M1rintana_kanri_no"]);
				// (M1.HeaderRow.FindControl("M1loss_kanri_no") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1loss_kanri_no", lang), base.GetPageContext().FormInfo["M1loss_kanri_no"]);
				// (M1.HeaderRow.FindControl("M1bumon_cd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumon_cd", lang), base.GetPageContext().FormInfo["M1bumon_cd"]);
				// (M1.HeaderRow.FindControl("M1hinsyu_ryaku_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hinsyu_ryaku_nm", lang), base.GetPageContext().FormInfo["M1hinsyu_ryaku_nm"]);
				// (M1.HeaderRow.FindControl("M1burando_nm1") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1burando_nm1", lang), base.GetPageContext().FormInfo["M1burando_nm1"]);
				// (M1.HeaderRow.FindControl("M1burando_nm2") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1burando_nm2", lang), base.GetPageContext().FormInfo["M1burando_nm2"]);
				// (M1.HeaderRow.FindControl("M1burando_nm3") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1burando_nm3", lang), base.GetPageContext().FormInfo["M1burando_nm3"]);
				// (M1.HeaderRow.FindControl("M1burando_nm4") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1burando_nm4", lang), base.GetPageContext().FormInfo["M1burando_nm4"]);
				// (M1.HeaderRow.FindControl("M1burando_nm5") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1burando_nm5", lang), base.GetPageContext().FormInfo["M1burando_nm5"]);
				// (M1.HeaderRow.FindControl("M1burando_nm6") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1burando_nm6", lang), base.GetPageContext().FormInfo["M1burando_nm6"]);
				// (M1.HeaderRow.FindControl("M1burando_nm7") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1burando_nm7", lang), base.GetPageContext().FormInfo["M1burando_nm7"]);
				// (M1.HeaderRow.FindControl("M1burando_nm8") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1burando_nm8", lang), base.GetPageContext().FormInfo["M1burando_nm8"]);
				// (M1.HeaderRow.FindControl("M1tanajityobo_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tanajityobo_su", lang), base.GetPageContext().FormInfo["M1tanajityobo_su"]);
				// (M1.HeaderRow.FindControl("M1tanajisekiso_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tanajisekiso_su", lang), base.GetPageContext().FormInfo["M1tanajisekiso_su"]);
				// (M1.HeaderRow.FindControl("M1jitana_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1jitana_su", lang), base.GetPageContext().FormInfo["M1jitana_su"]);
				// (M1.HeaderRow.FindControl("M1nyuryokutan_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1nyuryokutan_nm", lang), base.GetPageContext().FormInfo["M1nyuryokutan_nm"]);
				// (M1.HeaderRow.FindControl("M1loss_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1loss_su", lang), base.GetPageContext().FormInfo["M1loss_su"]);
				// (M1.HeaderRow.FindControl("M1loss_kin") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1loss_kin", lang), base.GetPageContext().FormInfo["M1loss_kin"]);
				// (M1.HeaderRow.FindControl("M1losskeisan_ymd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1losskeisan_ymd", lang), base.GetPageContext().FormInfo["M1losskeisan_ymd"]);
				// (M1.HeaderRow.FindControl("M1losskeisan_tm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1losskeisan_tm", lang), base.GetPageContext().FormInfo["M1losskeisan_tm"]);
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
		/// <param name="tj190f01Form">画面FormVO</param>
		private void RenderM1Pager(Tj190f01Form tj190f01Form)
		{
			Pgr.VirtualItemCount = tj190f01Form.GetList("M1").RecordCount;
			Pgr.CurrentPageIndex = tj190f01Form.GetList("M1").PageNo - 1;
			Pgr.PageSize = tj190f01Form.GetList("M1").DispRow;
		}
		#endregion
		#endregion

		#region カードデータを表示する
		/// <summary>
		/// カードデータを表示する
		/// </summary>
		/// <param name="tj190f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderCard(
			Tj190f01Form tj190f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			
			ControlUtil.SetControlValue(Head_tenpo_cd,
				DataFormatUtil.GetFormatItem(tj190f01Form.Head_tenpo_cd,formInfo["Head_tenpo_cd"]));
			ControlUtil.SetControlValue(Head_tenpo_nm,
				DataFormatUtil.GetFormatItem(tj190f01Form.Head_tenpo_nm,formInfo["Head_tenpo_nm"]));
			ControlUtil.SetControlValue(Modeno,
				DataFormatUtil.GetFormatItem(tj190f01Form.Modeno,formInfo["Modeno"]));
			ControlUtil.SetControlValue(Stkmodeno,
				DataFormatUtil.GetFormatItem(tj190f01Form.Stkmodeno,formInfo["Stkmodeno"]));
			ControlUtil.SetControlValue(Nyuryoku_ymd_from,
				DataFormatUtil.GetFormatItem(tj190f01Form.Nyuryoku_ymd_from,formInfo["Nyuryoku_ymd_from"]));
			ControlUtil.SetControlValue(Nyuryoku_ymd_to,
				DataFormatUtil.GetFormatItem(tj190f01Form.Nyuryoku_ymd_to,formInfo["Nyuryoku_ymd_to"]));
			ControlUtil.SetControlValue(Tenpo_cd_from,
				DataFormatUtil.GetFormatItem(tj190f01Form.Tenpo_cd_from,formInfo["Tenpo_cd_from"]));
			ControlUtil.SetControlValue(Tenpo_nm_from,
				DataFormatUtil.GetFormatItem(tj190f01Form.Tenpo_nm_from,formInfo["Tenpo_nm_from"]));
			ControlUtil.SetControlValue(Tenpo_cd_to,
				DataFormatUtil.GetFormatItem(tj190f01Form.Tenpo_cd_to,formInfo["Tenpo_cd_to"]));
			ControlUtil.SetControlValue(Tenpo_nm_to,
				DataFormatUtil.GetFormatItem(tj190f01Form.Tenpo_nm_to,formInfo["Tenpo_nm_to"]));
			ControlUtil.SetControlValue(Nyuryokutan_cd,
				DataFormatUtil.GetFormatItem(tj190f01Form.Nyuryokutan_cd,formInfo["Nyuryokutan_cd"]));
			ControlUtil.SetControlValue(Nyuryokutan_nm,
				DataFormatUtil.GetFormatItem(tj190f01Form.Nyuryokutan_nm,formInfo["Nyuryokutan_nm"]));
			ControlUtil.SetControlValue(Bumon_cd_from,
				DataFormatUtil.GetFormatItem(tj190f01Form.Bumon_cd_from,formInfo["Bumon_cd_from"]));
			ControlUtil.SetControlValue(Bumon_nm_from,
				DataFormatUtil.GetFormatItem(tj190f01Form.Bumon_nm_from,formInfo["Bumon_nm_from"]));
			ControlUtil.SetControlValue(Hinsyu_cd_from,
				DataFormatUtil.GetFormatItem(tj190f01Form.Hinsyu_cd_from,formInfo["Hinsyu_cd_from"]));
			ControlUtil.SetControlValue(Hinsyu_ryaku_nm_from,
				DataFormatUtil.GetFormatItem(tj190f01Form.Hinsyu_ryaku_nm_from,formInfo["Hinsyu_ryaku_nm_from"]));
			ControlUtil.SetControlValue(Bumon_cd_to,
				DataFormatUtil.GetFormatItem(tj190f01Form.Bumon_cd_to,formInfo["Bumon_cd_to"]));
			ControlUtil.SetControlValue(Bumon_nm_to,
				DataFormatUtil.GetFormatItem(tj190f01Form.Bumon_nm_to,formInfo["Bumon_nm_to"]));
			ControlUtil.SetControlValue(Hinsyu_cd_to,
				DataFormatUtil.GetFormatItem(tj190f01Form.Hinsyu_cd_to,formInfo["Hinsyu_cd_to"]));
			ControlUtil.SetControlValue(Hinsyu_ryaku_nm_to,
				DataFormatUtil.GetFormatItem(tj190f01Form.Hinsyu_ryaku_nm_to,formInfo["Hinsyu_ryaku_nm_to"]));
			ControlUtil.SetControlValue(Burando_cd,
				DataFormatUtil.GetFormatItem(tj190f01Form.Burando_cd,formInfo["Burando_cd"]));
			ControlUtil.SetControlValue(Burando_nm,
				DataFormatUtil.GetFormatItem(tj190f01Form.Burando_nm,formInfo["Burando_nm"]));
			ControlUtil.SetControlValue(Old_jisya_hbn,
				DataFormatUtil.GetFormatItem(tj190f01Form.Old_jisya_hbn,formInfo["Old_jisya_hbn"]));
			ControlUtil.SetControlValue(Scan_cd,
				DataFormatUtil.GetFormatItem(tj190f01Form.Scan_cd,formInfo["Scan_cd"]));
			ControlUtil.SetControlValue(Loss_kanri_no,
				DataFormatUtil.GetFormatItem(tj190f01Form.Loss_kanri_no,formInfo["Loss_kanri_no"]));
			ControlUtil.SetControlValue(Meisai_sort,
				DataFormatUtil.GetFormatItem(tj190f01Form.Meisai_sort,formInfo["Meisai_sort"]));
			ControlUtil.SetControlValue(Searchcnt,
				DataFormatUtil.GetFormatItem(tj190f01Form.Searchcnt,formInfo["Searchcnt"]));
			ControlUtil.SetControlValue(Gokeitanajityobo_su,
				DataFormatUtil.GetFormatItem(tj190f01Form.Gokeitanajityobo_su,formInfo["Gokeitanajityobo_su"]));
			ControlUtil.SetControlValue(Gokeitanajisekiso_su,
				DataFormatUtil.GetFormatItem(tj190f01Form.Gokeitanajisekiso_su,formInfo["Gokeitanajisekiso_su"]));
			ControlUtil.SetControlValue(Gokeijitana_su,
				DataFormatUtil.GetFormatItem(tj190f01Form.Gokeijitana_su,formInfo["Gokeijitana_su"]));
			ControlUtil.SetControlValue(Gokeiloss_su,
				DataFormatUtil.GetFormatItem(tj190f01Form.Gokeiloss_su,formInfo["Gokeiloss_su"]));
			ControlUtil.SetControlValue(Gokeiloss_kin,
				DataFormatUtil.GetFormatItem(tj190f01Form.Gokeiloss_kin,formInfo["Gokeiloss_kin"]));

			if(!base.CheckUseSelfCustomize()){
				Btnheadtenpocd.Value = base.FormResourceGetString(formResource, "Btnheadtenpocd", lang);
				Btnmodeupd.InnerText = base.FormResourceGetString(formResource, "Btnmodeupd", lang);
				Btnmodedel.InnerText = base.FormResourceGetString(formResource, "Btnmodedel", lang);
				Btnmoderef.InnerText = base.FormResourceGetString(formResource, "Btnmoderef", lang);
				Btnmodelosskeisan.InnerText = base.FormResourceGetString(formResource, "Btnmodelosskeisan", lang);
				Btnmodelossdel.InnerText = base.FormResourceGetString(formResource, "Btnmodelossdel", lang);
				Btnmodelossref.InnerText = base.FormResourceGetString(formResource, "Btnmodelossref", lang);
				Btntenpocd_from.Value = base.FormResourceGetString(formResource, "Btntenpocd_from", lang);
				Btntenpocd_to.Value = base.FormResourceGetString(formResource, "Btntenpocd_to", lang);
				Btntanto_cd.Value = base.FormResourceGetString(formResource, "Btntanto_cd", lang);
				Btnbumon_cd_from.Value = base.FormResourceGetString(formResource, "Btnbumon_cd_from", lang);
				Btnhinsyu_cd_from.Value = base.FormResourceGetString(formResource, "Btnhinsyu_cd_from", lang);
				Btnbumon_cd_to.Value = base.FormResourceGetString(formResource, "Btnbumon_cd_to", lang);
				Btnhinsyu_cd_to.Value = base.FormResourceGetString(formResource, "Btnhinsyu_cd_to", lang);
				Btnburando_cd.Value = base.FormResourceGetString(formResource, "Btnburando_cd", lang);
				Btnsearch.Value = base.FormResourceGetString(formResource, "Btnsearch", lang);
				Btnprint.Value = base.FormResourceGetString(formResource, "Btnprint", lang);
				Btncsv.Value = base.FormResourceGetString(formResource, "Btncsv", lang);
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
				LoginInfoVO loginInfVO = LoginInfoUtil.GetLoginInfo();

				if (!CheckKengenCls.CheckKengen(loginInfVO))
				{
					// 明細ソート、「店舗／部門／品種／ブランド順」使用不可
					Meisai_sort.Items.RemoveAt(2);
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
			// UIScreenController controller = new UIScreenController((Tj190f01Form)base.GetPageContext().GetFormVO());
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

			// 権限取得部品の戻り値が"FALSE"の場合
			if (!CheckKengenCls.CheckKengen(loginInfVO))
			{
				// 店舗コードFROM、店舗コードTO使用不可
				ControlCls.Disable(Tenpo_cd_from, true);
				ControlCls.Disable(Tenpo_cd_to, true);
				ControlCls.Visible(Btntenpocd_from, false);
				ControlCls.Visible(Btntenpocd_to, false);


			}

			// 選択モードによる分岐
			Tj190f01Form formVo = (Tj190f01Form)base.GetPageContext().GetFormVO();

			if (!BoSystemString.Nvl(formVo.Stkmodeno).Equals(BoSystemConstant.MODE_LOSSREF))
			{
				// [選択モードNO]が「ロス照会」以外の場合、印刷ボタン、CSVボタンを使用不可とする
				ControlCls.Disable(Btncsv, true);
				ControlCls.Disable(Btnprint, true);
			}

			if (BoSystemConstant.MODE_UPD.Equals(formVo.Modeno)
				|| BoSystemConstant.MODE_REF.Equals(formVo.Modeno)
				|| BoSystemConstant.MODE_LOSSREF.Equals(formVo.Modeno))
			{
				// [選択モードNO]が「修正」、「照会」、「ロス照会」の場合、確定ボタンを隠す
				ControlCls.Disable(Btnenter, true);
			}

			if (BoSystemConstant.MODE_UPD.Equals(formVo.Modeno)
				|| BoSystemConstant.MODE_DEL.Equals(formVo.Modeno)
				|| BoSystemConstant.MODE_REF.Equals(formVo.Modeno)
				|| BoSystemConstant.MODE_LOSSKEISAN.Equals(formVo.Modeno))
			{
				// [選択モードNO]が「修正」、「取消」、「照会」、「ロス照会」の場合、明細合計部を隠す
				ControlCls.Visible(meisaiSumArea, false);
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
			//ControlUtil.SetControlValue(Nyuryoku_ymd_from_lbl, 
			//	DataFormatUtil.GetFormatCaption(formResource.GetString("Nyuryoku_ymd_from", lang), base.GetPageContext().FormInfo["Nyuryoku_ymd_from"]));
				ControlUtil.SetControlValue(Nyuryoku_ymd_from_lbl, "入力日");
				DataFormatUtil.SetMustColorCaption(Nyuryoku_ymd_from_lbl, base.GetPageContext().FormInfo["Nyuryoku_ymd_from"]);
			ControlUtil.SetControlValue(Nyuryoku_ymd_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Nyuryoku_ymd_to", lang), base.GetPageContext().FormInfo["Nyuryoku_ymd_to"]));
				DataFormatUtil.SetMustColorCaption(Nyuryoku_ymd_to_lbl, base.GetPageContext().FormInfo["Nyuryoku_ymd_to"]);
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
			ControlUtil.SetControlValue(Nyuryokutan_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Nyuryokutan_cd", lang), base.GetPageContext().FormInfo["Nyuryokutan_cd"]));
				DataFormatUtil.SetMustColorCaption(Nyuryokutan_cd_lbl, base.GetPageContext().FormInfo["Nyuryokutan_cd"]);
			ControlUtil.SetControlValue(Nyuryokutan_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Nyuryokutan_nm", lang), base.GetPageContext().FormInfo["Nyuryokutan_nm"]));
				DataFormatUtil.SetMustColorCaption(Nyuryokutan_nm_lbl, base.GetPageContext().FormInfo["Nyuryokutan_nm"]);
			//ControlUtil.SetControlValue(Bumon_cd_from_lbl, 
			//	DataFormatUtil.GetFormatCaption(formResource.GetString("Bumon_cd_from", lang), base.GetPageContext().FormInfo["Bumon_cd_from"]));
				ControlUtil.SetControlValue(Bumon_cd_from_lbl, "部門・品種");
				DataFormatUtil.SetMustColorCaption(Bumon_cd_from_lbl, base.GetPageContext().FormInfo["Bumon_cd_from"]);
			ControlUtil.SetControlValue(Bumon_nm_from_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Bumon_nm_from", lang), base.GetPageContext().FormInfo["Bumon_nm_from"]));
				DataFormatUtil.SetMustColorCaption(Bumon_nm_from_lbl, base.GetPageContext().FormInfo["Bumon_nm_from"]);
			ControlUtil.SetControlValue(Hinsyu_cd_from_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Hinsyu_cd_from", lang), base.GetPageContext().FormInfo["Hinsyu_cd_from"]));
				DataFormatUtil.SetMustColorCaption(Hinsyu_cd_from_lbl, base.GetPageContext().FormInfo["Hinsyu_cd_from"]);
			ControlUtil.SetControlValue(Hinsyu_ryaku_nm_from_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Hinsyu_ryaku_nm_from", lang), base.GetPageContext().FormInfo["Hinsyu_ryaku_nm_from"]));
				DataFormatUtil.SetMustColorCaption(Hinsyu_ryaku_nm_from_lbl, base.GetPageContext().FormInfo["Hinsyu_ryaku_nm_from"]);
			ControlUtil.SetControlValue(Bumon_cd_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Bumon_cd_to", lang), base.GetPageContext().FormInfo["Bumon_cd_to"]));
				DataFormatUtil.SetMustColorCaption(Bumon_cd_to_lbl, base.GetPageContext().FormInfo["Bumon_cd_to"]);
			ControlUtil.SetControlValue(Bumon_nm_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Bumon_nm_to", lang), base.GetPageContext().FormInfo["Bumon_nm_to"]));
				DataFormatUtil.SetMustColorCaption(Bumon_nm_to_lbl, base.GetPageContext().FormInfo["Bumon_nm_to"]);
			ControlUtil.SetControlValue(Hinsyu_cd_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Hinsyu_cd_to", lang), base.GetPageContext().FormInfo["Hinsyu_cd_to"]));
				DataFormatUtil.SetMustColorCaption(Hinsyu_cd_to_lbl, base.GetPageContext().FormInfo["Hinsyu_cd_to"]);
			ControlUtil.SetControlValue(Hinsyu_ryaku_nm_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Hinsyu_ryaku_nm_to", lang), base.GetPageContext().FormInfo["Hinsyu_ryaku_nm_to"]));
				DataFormatUtil.SetMustColorCaption(Hinsyu_ryaku_nm_to_lbl, base.GetPageContext().FormInfo["Hinsyu_ryaku_nm_to"]);
			ControlUtil.SetControlValue(Burando_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Burando_cd", lang), base.GetPageContext().FormInfo["Burando_cd"]));
				DataFormatUtil.SetMustColorCaption(Burando_cd_lbl, base.GetPageContext().FormInfo["Burando_cd"]);
			ControlUtil.SetControlValue(Burando_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Burando_nm", lang), base.GetPageContext().FormInfo["Burando_nm"]));
				DataFormatUtil.SetMustColorCaption(Burando_nm_lbl, base.GetPageContext().FormInfo["Burando_nm"]);
			ControlUtil.SetControlValue(Old_jisya_hbn_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Old_jisya_hbn", lang), base.GetPageContext().FormInfo["Old_jisya_hbn"]));
				DataFormatUtil.SetMustColorCaption(Old_jisya_hbn_lbl, base.GetPageContext().FormInfo["Old_jisya_hbn"]);
			ControlUtil.SetControlValue(Scan_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Scan_cd", lang), base.GetPageContext().FormInfo["Scan_cd"]));
				DataFormatUtil.SetMustColorCaption(Scan_cd_lbl, base.GetPageContext().FormInfo["Scan_cd"]);
			ControlUtil.SetControlValue(Loss_kanri_no_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Loss_kanri_no", lang), base.GetPageContext().FormInfo["Loss_kanri_no"]));
				DataFormatUtil.SetMustColorCaption(Loss_kanri_no_lbl, base.GetPageContext().FormInfo["Loss_kanri_no"]);
			//ControlUtil.SetControlValue(Meisai_sort_lbl, 
				//DataFormatUtil.GetFormatCaption(formResource.GetString("Meisai_sort", lang), base.GetPageContext().FormInfo["Meisai_sort"]));
				ControlUtil.SetControlValue(Meisai_sort_lbl, "");
				DataFormatUtil.SetMustColorCaption(Meisai_sort_lbl, base.GetPageContext().FormInfo["Meisai_sort"]);
			ControlUtil.SetControlValue(Searchcnt_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Searchcnt", lang), base.GetPageContext().FormInfo["Searchcnt"]));
				DataFormatUtil.SetMustColorCaption(Searchcnt_lbl, base.GetPageContext().FormInfo["Searchcnt"]);
			ControlUtil.SetControlValue(Gokeitanajityobo_su_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Gokeitanajityobo_su", lang), base.GetPageContext().FormInfo["Gokeitanajityobo_su"]));
				DataFormatUtil.SetMustColorCaption(Gokeitanajityobo_su_lbl, base.GetPageContext().FormInfo["Gokeitanajityobo_su"]);
			ControlUtil.SetControlValue(Gokeitanajisekiso_su_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Gokeitanajisekiso_su", lang), base.GetPageContext().FormInfo["Gokeitanajisekiso_su"]));
				DataFormatUtil.SetMustColorCaption(Gokeitanajisekiso_su_lbl, base.GetPageContext().FormInfo["Gokeitanajisekiso_su"]);
			ControlUtil.SetControlValue(Gokeijitana_su_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Gokeijitana_su", lang), base.GetPageContext().FormInfo["Gokeijitana_su"]));
				DataFormatUtil.SetMustColorCaption(Gokeijitana_su_lbl, base.GetPageContext().FormInfo["Gokeijitana_su"]);
			ControlUtil.SetControlValue(Gokeiloss_su_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Gokeiloss_su", lang), base.GetPageContext().FormInfo["Gokeiloss_su"]));
				DataFormatUtil.SetMustColorCaption(Gokeiloss_su_lbl, base.GetPageContext().FormInfo["Gokeiloss_su"]);
			ControlUtil.SetControlValue(Gokeiloss_kin_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Gokeiloss_kin", lang), base.GetPageContext().FormInfo["Gokeiloss_kin"]));
				DataFormatUtil.SetMustColorCaption(Gokeiloss_kin_lbl, base.GetPageContext().FormInfo["Gokeiloss_kin"]);
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
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1nyuryoku_ymd", lang), base.GetPageContext().FormInfo["M1nyuryoku_ymd"]);
				// M1.Columns[4].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1rintana_kanri_no", lang), base.GetPageContext().FormInfo["M1rintana_kanri_no"]);
				// M1.Columns[5].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1loss_kanri_no", lang), base.GetPageContext().FormInfo["M1loss_kanri_no"]);
				// M1.Columns[6].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumon_cd", lang), base.GetPageContext().FormInfo["M1bumon_cd"]);
				// M1.Columns[7].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hinsyu_ryaku_nm", lang), base.GetPageContext().FormInfo["M1hinsyu_ryaku_nm"]);
				// M1.Columns[8].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1burando_nm1", lang), base.GetPageContext().FormInfo["M1burando_nm1"]);
				// M1.Columns[9].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1burando_nm2", lang), base.GetPageContext().FormInfo["M1burando_nm2"]);
				// M1.Columns[10].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1burando_nm3", lang), base.GetPageContext().FormInfo["M1burando_nm3"]);
				// M1.Columns[11].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1burando_nm4", lang), base.GetPageContext().FormInfo["M1burando_nm4"]);
				// M1.Columns[12].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1burando_nm5", lang), base.GetPageContext().FormInfo["M1burando_nm5"]);
				// M1.Columns[13].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1burando_nm6", lang), base.GetPageContext().FormInfo["M1burando_nm6"]);
				// M1.Columns[14].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1burando_nm7", lang), base.GetPageContext().FormInfo["M1burando_nm7"]);
				// M1.Columns[15].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1burando_nm8", lang), base.GetPageContext().FormInfo["M1burando_nm8"]);
				// M1.Columns[16].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tanajityobo_su", lang), base.GetPageContext().FormInfo["M1tanajityobo_su"]);
				// M1.Columns[17].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tanajisekiso_su", lang), base.GetPageContext().FormInfo["M1tanajisekiso_su"]);
				// M1.Columns[18].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1jitana_su", lang), base.GetPageContext().FormInfo["M1jitana_su"]);
				// M1.Columns[19].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1nyuryokutan_nm", lang), base.GetPageContext().FormInfo["M1nyuryokutan_nm"]);
				// M1.Columns[20].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1loss_su", lang), base.GetPageContext().FormInfo["M1loss_su"]);
				// M1.Columns[21].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1loss_kin", lang), base.GetPageContext().FormInfo["M1loss_kin"]);
				// M1.Columns[22].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1losskeisan_ymd", lang), base.GetPageContext().FormInfo["M1losskeisan_ymd"]);
				// M1.Columns[23].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1losskeisan_tm", lang), base.GetPageContext().FormInfo["M1losskeisan_tm"]);
				// M1.Columns[24].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1selectorcheckbox", lang), base.GetPageContext().FormInfo["M1selectorcheckbox"]);
				// M1.Columns[25].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1entersyoriflg", lang), base.GetPageContext().FormInfo["M1entersyoriflg"]);
				// M1.Columns[26].HeaderText = 
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
				Windowtitle.InnerText = formResource.GetString("Tj190f01_Titlebar", lang);
				header.FormName = formResource.GetString("Tj190f01_FormCaption", lang);
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
