using com.xebio.bo.Tj040p01.Constant;
using com.xebio.bo.Tj040p01.Facade;
using com.xebio.bo.Tj040p01.Formvo;
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
using Common.Business.C01000.C01026;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
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
using System.Web.UI.WebControls;

namespace com.xebio.bo.Tj040p01.Page
{
  /// <summary>
  /// Tj040f01のコードビハインドです。
  /// </summary>
  public partial class Tj040f01Page : StandardBasePage
	{

		#region メソッド

		#region ページデータをロードするメソッド
		/// <summary>
		/// Tj040f01画面データを作成する。
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
						pageContext.SetFormVO(new Tj040f01Form());
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
								new Tj040f01Facade().DoLoad(facadeContext);

                                #region 共通ヘッダ処理

                                // 一覧画面共通処理 ----------
                                LoginInfoVO loginInfVO = LoginInfoUtil.GetLoginInfo();
                                Tj040f01Form tj040f01Form = (Tj040f01Form)facadeContext.FormVO;
                                ControlHeaderStoreCls.InitialSetHeaderStore<Tj040f01Form>(loginInfVO, tj040f01Form);
                                // 一覧画面共通処理 ----------

                                if (string.IsNullOrEmpty(tj040f01Form.Modeno))
                                {
                                    // アコーディオンなし
                                    AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_NONE);
                                    // モードNoを返品確定に設定
                                    tj040f01Form.Modeno = BoSystemConstant.MODE_REF.ToString();
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
                    Tj040f01Form formVO = (Tj040f01Form)fvm.GetProgramVO(base.GetPageContext().CommandInfo.ProgramId).GetFormVO(Tj040p01Constant.FORMID_01);
                    TabUtil.SetTabNumber(base.GetPageContext(), formVO.Modeno);
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
				new Tj040f01Facade().DoBTNSEARCH_FRM(facadeContext);
				
				
				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
                    // アコーディオンなし
                    AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_NONE);

					base.SetError(pageContext);
					return;
				}

                //アコーディオンを閉じた状態で表示
                AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_CLOSE);
				//アコーディオンを閉じた際に表示される検索条件を設定する。
				AccordionUtil.ResetSearchCondition(pageContext);
				// モードを設定 
				ModeUtil.SetMode(pageContext, ModeCls.GetModeNm(((Tj040f01Form)pageContext.GetFormVO()).Stkmodeno));

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
            string focusMno = string.Empty;

            // 表示明細先頭の管理Noにフォーカス設定
            focusItem = "M1face_no";
            focusMno  = (0).ToString();

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
				new Tj040f01Facade().DoBTNZENSTK_FRM(facadeContext);
				
				
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
				new Tj040f01Facade().DoBTNZENKJO_FRM(facadeContext);
				
				
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
				new Tj040f01Facade().DoBTNPRINT_FRM(facadeContext);
				
				
				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
					base.SetError(pageContext);
					return;
				}

                // PDFファイル名を取得
                pdfNm = (string)facadeContext.GetUserObject(Tj040p01Constant.FCDUO_RRT_FLNM);				

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

            DLConditionVO dlvo = new DLConditionVO();
            // サーバファイルフルパス
            string serverPath = string.Format("{0}{1}{2}",
                                            FilePathManager.GetOutFilePath(Tj040p01Constant.PGID),
                                            Path.DirectorySeparatorChar,
                                            pdfNm
                                            );
            // クライアントファイル名
            string clientNm = string.Format("{0}.{1}",
											BoSystemReport.CreateFileName(BoSystemConstant.REPORTNM_TANAOROSIITIRANHYO_X,2),
                                            BoSystemConstant.RPT_PDF_EXTENSION
                                            );
            // ダウンロード用VOに値を設定
            dlvo.setSingleFileDownloadCondition(serverPath, clientNm);

			// ダウンロード用VOをセッションに格納
			SessionInfoUtil.SetPgObject(BoSystemConstant.SESSION_KEY_DOWNLOAD_VO, dlvo, pageContext);

			//フォーカスを当てる項目を指定したい場合はFormFocusUtilを使ってqueryListに追加すること

            // フォーカス設定用変数
            string focusItem = string.Empty;
            string focusMno  = string.Empty;

            // 表示明細先頭の管理Noにフォーカス設定
            focusItem = "M1face_no";
            // ■仮対応 明細が-2
            focusMno = (0).ToString();

            // フォーカス設定
            SetFocusCls.SetFocus(queryList, focusItem, focusMno);			

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
				new Tj040f01Facade().DoBTNCSV_FRM(facadeContext);
				
				
				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
					base.SetError(pageContext);
					return;
				}

                // CSVファイル名を取得
                csvNm = (string)facadeContext.GetUserObject(Tj040p01Constant.FCDUO_CSV_FLNM);				

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

            #region CSV出力処理

            DLConditionVO dlvo = new DLConditionVO();
            // サーバファイルフルパス
            string serverPath = string.Format("{0}{1}{2}",
                                            FilePathManager.GetOutFilePath(Tj040p01Constant.PGID),
                                            Path.DirectorySeparatorChar,
                                            csvNm
                                            );
            // クライアントファイル名
            string clientNm = string.Format("{0}{1}",
                                            BoSystemReport.CreateFileName("棚卸データCSV",2),
                                            FilePathManager.EXT_CSV
                                            );

            // ダウンロード用VOに値を設定
            dlvo.setSingleFileDownloadCondition(serverPath, clientNm);

			// ダウンロード用VOをセッションに格納
			SessionInfoUtil.SetPgObject(BoSystemConstant.SESSION_KEY_DOWNLOAD_VO, dlvo, pageContext);

            #endregion

			//フォーカスを当てる項目を指定したい場合はFormFocusUtilを使ってqueryListに追加すること

            // フォーカス設定用変数
            string focusItem = string.Empty;
            string focusMno  = string.Empty;

            // 表示明細先頭の管理Noにフォーカス設定
            focusItem = "M1face_no";
            // ■仮対応 明細が-2
            focusMno = (0).ToString();

            // フォーカス設定
            SetFocusCls.SetFocus(queryList, focusItem, focusMno);

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
				new Tj040f01Facade().DoPGR_PGN(facadeContext, pageindex);
				
				
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
		
		#region フォームを呼び出します(ボタンID : M1face_no(ﾌｪｲｽNo))
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(M1face_no(ﾌｪｲｽNo))
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnM1FACE_NO_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnM1FACE_NO_FRM");
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
                facadeContext.SetUserObject(Tj040p01Constant.FCDUO_NEXTVO, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Tj040p01Constant.FORMID_02));
                
                new Tj040f01Facade().DoM1FACE_NO_FRM(facadeContext);

                // 次画面のフォームビーンを設定
                fvm.SetFormVO(Tj040p01Constant.PGID, Tj040p01Constant.FORMID_02, (Tj040f02Form)facadeContext.GetUserObject(Tj040p01Constant.FCDUO_NEXTVO));
				
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
			EndMethod(sender, e, this.GetType().Name + ".OnM1FACE_NO_FRM");
			
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
				new Tj040f01Facade().DoBTNENTER_FRM(facadeContext);
				
				
				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
                    // アコーディオンなし
                    AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_NONE);

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
						Tj040f01Form tj040f01Form = (Tj040f01Form)pageContext.GetFormVO();

						//明細ページ情報を表示する
						ShowListPageInfo(tj040f01Form);
			
						//明細部データを表示する
						RenderList(tj040f01Form, pageContext.FormInfo, formResource, lang);

						//カード部データを表示する
						RenderCard(tj040f01Form, pageContext.FormInfo, formResource, lang);
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
		/// <param name="tj040f01Form">画面FormVO</param>
		private void ShowListPageInfo(Tj040f01Form tj040f01Form)
		{
			//M1明細ページ情報を表示する。
			ShowM1ListPageInfo(tj040f01Form.GetList("M1"));

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
		/// <param name="tj040f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderList(
			Tj040f01Form tj040f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//画面のM1明細部データを設定する。
			RenderM1List(tj040f01Form, formInfo, formResource, lang);
			//M1明細部のページャーにページ情報を設定する。
			RenderM1Pager(tj040f01Form);
			
		}
		#endregion

		#region M1明細データを表示する
		/// <summary>
		/// M1明細データを表示する。
		/// </summary>
		/// <param name="tj040f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderM1List(
			Tj040f01Form tj040f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//M1明細部データソースを設定する。
			M1.DataSource = tj040f01Form.GetPageViewList("M1");
			M1.DataBind();

			//M1明細部データをフォーマットする。
			IList m1DataList = (IList)M1.DataSource;
			
			for (int index = 0; index < M1.Items.Count; index++)
			{
				Tj040f01M1Form tj040f01M1Form = (Tj040f01M1Form)m1DataList[index];
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1rowno"),
					DataFormatUtil.GetFormatItem(tj040f01M1Form.M1rowno,formInfo["M1rowno"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1tana_dan"),
					DataFormatUtil.GetFormatItem(tj040f01M1Form.M1tana_dan,formInfo["M1tana_dan"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1kai_su"),
					DataFormatUtil.GetFormatItem(tj040f01M1Form.M1kai_su,formInfo["M1kai_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1tensutanaorosinyuryoku_su"),
					DataFormatUtil.GetFormatItem(tj040f01M1Form.M1tensutanaorosinyuryoku_su,formInfo["M1tensutanaorosinyuryoku_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1tensutanaorositeisei_su"),
					DataFormatUtil.GetFormatItem(tj040f01M1Form.M1tensutanaorositeisei_su,formInfo["M1tensutanaorositeisei_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1tensutanaorosigokei_su"),
					DataFormatUtil.GetFormatItem(tj040f01M1Form.M1tensutanaorosigokei_su,formInfo["M1tensutanaorosigokei_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1scan_su"),
					DataFormatUtil.GetFormatItem(tj040f01M1Form.M1scan_su,formInfo["M1scan_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1teisei_suryo"),
					DataFormatUtil.GetFormatItem(tj040f01M1Form.M1teisei_suryo,formInfo["M1teisei_suryo"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1gokei_suryo"),
					DataFormatUtil.GetFormatItem(tj040f01M1Form.M1gokei_suryo,formInfo["M1gokei_suryo"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1nyuryokutan_nm"),
					DataFormatUtil.GetFormatItem(tj040f01M1Form.M1nyuryokutan_nm,formInfo["M1nyuryokutan_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1teiseitan_nm"),
					DataFormatUtil.GetFormatItem(tj040f01M1Form.M1teiseitan_nm,formInfo["M1teiseitan_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1riyucomment_nm"),
					DataFormatUtil.GetFormatItem(tj040f01M1Form.M1riyucomment_nm,formInfo["M1riyucomment_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1nyuryoku_ymd"),
					DataFormatUtil.GetFormatItem(tj040f01M1Form.M1nyuryoku_ymd,formInfo["M1nyuryoku_ymd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1sosin_ymd"),
					DataFormatUtil.GetFormatItem(tj040f01M1Form.M1sosin_ymd,formInfo["M1sosin_ymd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1gyosya"),
					DataFormatUtil.GetFormatItem(tj040f01M1Form.M1gyosya,formInfo["M1gyosya"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1selectorcheckbox"),
					DataFormatUtil.GetFormatItem(tj040f01M1Form.M1selectorcheckbox,formInfo["M1selectorcheckbox"]));
				((System.Web.UI.WebControls.CheckBox)M1.Items[index].FindControl("M1selectorcheckbox")).Text =
					formResource.GetString("M1selectorcheckbox", lang);
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1entersyoriflg"),
					DataFormatUtil.GetFormatItem(tj040f01M1Form.M1entersyoriflg,formInfo["M1entersyoriflg"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1dtlirokbn"),
					DataFormatUtil.GetFormatItem(tj040f01M1Form.M1dtlirokbn,formInfo["M1dtlirokbn"]));

				if(!base.CheckUseSelfCustomize()){
                    //((System.Web.UI.HtmlControls.HtmlInputButton)M1.Items[index].FindControl("M1face_no")).Value =
                    //    formResource.GetString("M1face_no", lang);
                    ((System.Web.UI.HtmlControls.HtmlInputButton)M1.Items[index].FindControl("M1face_no")).Value =
						BoSystemFormat.formatFaceNo(tj040f01M1Form.Dictionary[Tj040p01Constant.DIC_M1FACE_NO].ToString());

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
				// (M1.HeaderRow.FindControl("M1face_no") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1face_no", lang), base.GetPageContext().FormInfo["M1face_no"]);
				// (M1.HeaderRow.FindControl("M1tana_dan") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tana_dan", lang), base.GetPageContext().FormInfo["M1tana_dan"]);
				// (M1.HeaderRow.FindControl("M1kai_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kai_su", lang), base.GetPageContext().FormInfo["M1kai_su"]);
				// (M1.HeaderRow.FindControl("M1tensutanaorosinyuryoku_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tensutanaorosinyuryoku_su", lang), base.GetPageContext().FormInfo["M1tensutanaorosinyuryoku_su"]);
				// (M1.HeaderRow.FindControl("M1tensutanaorositeisei_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tensutanaorositeisei_su", lang), base.GetPageContext().FormInfo["M1tensutanaorositeisei_su"]);
				// (M1.HeaderRow.FindControl("M1tensutanaorosigokei_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tensutanaorosigokei_su", lang), base.GetPageContext().FormInfo["M1tensutanaorosigokei_su"]);
				// (M1.HeaderRow.FindControl("M1scan_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1scan_su", lang), base.GetPageContext().FormInfo["M1scan_su"]);
				// (M1.HeaderRow.FindControl("M1teisei_suryo") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1teisei_suryo", lang), base.GetPageContext().FormInfo["M1teisei_suryo"]);
				// (M1.HeaderRow.FindControl("M1gokei_suryo") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1gokei_suryo", lang), base.GetPageContext().FormInfo["M1gokei_suryo"]);
				// (M1.HeaderRow.FindControl("M1nyuryokutan_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1nyuryokutan_nm", lang), base.GetPageContext().FormInfo["M1nyuryokutan_nm"]);
				// (M1.HeaderRow.FindControl("M1teiseitan_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1teiseitan_nm", lang), base.GetPageContext().FormInfo["M1teiseitan_nm"]);
				// (M1.HeaderRow.FindControl("M1riyucomment_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1riyucomment_nm", lang), base.GetPageContext().FormInfo["M1riyucomment_nm"]);
				// (M1.HeaderRow.FindControl("M1nyuryoku_ymd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1nyuryoku_ymd", lang), base.GetPageContext().FormInfo["M1nyuryoku_ymd"]);
				// (M1.HeaderRow.FindControl("M1sosin_ymd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1sosin_ymd", lang), base.GetPageContext().FormInfo["M1sosin_ymd"]);
				// (M1.HeaderRow.FindControl("M1gyosya") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1gyosya", lang), base.GetPageContext().FormInfo["M1gyosya"]);
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
		/// <param name="tj040f01Form">画面FormVO</param>
		private void RenderM1Pager(Tj040f01Form tj040f01Form)
		{
			Pgr.VirtualItemCount = tj040f01Form.GetList("M1").RecordCount;
			Pgr.CurrentPageIndex = tj040f01Form.GetList("M1").PageNo - 1;
			Pgr.PageSize = tj040f01Form.GetList("M1").DispRow;
		}
		#endregion
		#endregion

		#region カードデータを表示する
		/// <summary>
		/// カードデータを表示する
		/// </summary>
		/// <param name="tj040f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderCard(
			Tj040f01Form tj040f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			
			ControlUtil.SetControlValue(Head_tenpo_cd,
				DataFormatUtil.GetFormatItem(tj040f01Form.Head_tenpo_cd,formInfo["Head_tenpo_cd"]));
			ControlUtil.SetControlValue(Head_tenpo_nm,
				DataFormatUtil.GetFormatItem(tj040f01Form.Head_tenpo_nm,formInfo["Head_tenpo_nm"]));
			ControlUtil.SetControlValue(Modeno,
				DataFormatUtil.GetFormatItem(tj040f01Form.Modeno,formInfo["Modeno"]));
			ControlUtil.SetControlValue(Stkmodeno,
				DataFormatUtil.GetFormatItem(tj040f01Form.Stkmodeno,formInfo["Stkmodeno"]));
			ControlUtil.SetControlValue(Face_no_from,
				DataFormatUtil.GetFormatItem(tj040f01Form.Face_no_from,formInfo["Face_no_from"]));
			ControlUtil.SetControlValue(Face_no_to,
				DataFormatUtil.GetFormatItem(tj040f01Form.Face_no_to,formInfo["Face_no_to"]));
			ControlUtil.SetControlValue(Tana_dan_from,
				DataFormatUtil.GetFormatItem(tj040f01Form.Tana_dan_from,formInfo["Tana_dan_from"]));
			ControlUtil.SetControlValue(Tana_dan_to,
				DataFormatUtil.GetFormatItem(tj040f01Form.Tana_dan_to,formInfo["Tana_dan_to"]));
			ControlUtil.SetControlValue(Tenpo_gyosya_kb,
				DataFormatUtil.GetFormatItem(tj040f01Form.Tenpo_gyosya_kb,formInfo["Tenpo_gyosya_kb"]));
			ControlUtil.SetControlValue(Nyuryoku_ymd_from,
				DataFormatUtil.GetFormatItem(tj040f01Form.Nyuryoku_ymd_from,formInfo["Nyuryoku_ymd_from"]));
			ControlUtil.SetControlValue(Nyuryoku_ymd_to,
				DataFormatUtil.GetFormatItem(tj040f01Form.Nyuryoku_ymd_to,formInfo["Nyuryoku_ymd_to"]));
			ControlUtil.SetControlValue(Sosin_ymd_from,
				DataFormatUtil.GetFormatItem(tj040f01Form.Sosin_ymd_from,formInfo["Sosin_ymd_from"]));
			ControlUtil.SetControlValue(Sosin_ymd_to,
				DataFormatUtil.GetFormatItem(tj040f01Form.Sosin_ymd_to,formInfo["Sosin_ymd_to"]));
			ControlUtil.SetControlValue(Nyuryokutan_cd,
				DataFormatUtil.GetFormatItem(tj040f01Form.Nyuryokutan_cd,formInfo["Nyuryokutan_cd"]));
			ControlUtil.SetControlValue(Nyuryokutan_nm,
				DataFormatUtil.GetFormatItem(tj040f01Form.Nyuryokutan_nm,formInfo["Nyuryokutan_nm"]));
			ControlUtil.SetControlValue(Old_jisya_hbn,
				DataFormatUtil.GetFormatItem(tj040f01Form.Old_jisya_hbn,formInfo["Old_jisya_hbn"]));
			ControlUtil.SetControlValue(Old_jisya_hbn2,
				DataFormatUtil.GetFormatItem(tj040f01Form.Old_jisya_hbn2,formInfo["Old_jisya_hbn2"]));
			ControlUtil.SetControlValue(Old_jisya_hbn3,
				DataFormatUtil.GetFormatItem(tj040f01Form.Old_jisya_hbn3,formInfo["Old_jisya_hbn3"]));
			ControlUtil.SetControlValue(Old_jisya_hbn4,
				DataFormatUtil.GetFormatItem(tj040f01Form.Old_jisya_hbn4,formInfo["Old_jisya_hbn4"]));
			ControlUtil.SetControlValue(Old_jisya_hbn5,
				DataFormatUtil.GetFormatItem(tj040f01Form.Old_jisya_hbn5,formInfo["Old_jisya_hbn5"]));
			ControlUtil.SetControlValue(Sosin_jyotai,
				DataFormatUtil.GetFormatItem(tj040f01Form.Sosin_jyotai,formInfo["Sosin_jyotai"]));
			ControlUtil.SetControlValue(Teisei_flg,
				DataFormatUtil.GetFormatItem(tj040f01Form.Teisei_flg,formInfo["Teisei_flg"]));
            //Teisei_flg.Text = formResource.GetString("Teisei_flg", lang);
            Teisei_flg.Text = "訂正あり";
            ControlUtil.SetControlValue(Scan_cd,
				DataFormatUtil.GetFormatItem(tj040f01Form.Scan_cd,formInfo["Scan_cd"]));
			ControlUtil.SetControlValue(Scan_cd2,
				DataFormatUtil.GetFormatItem(tj040f01Form.Scan_cd2,formInfo["Scan_cd2"]));
			ControlUtil.SetControlValue(Scan_cd3,
				DataFormatUtil.GetFormatItem(tj040f01Form.Scan_cd3,formInfo["Scan_cd3"]));
			ControlUtil.SetControlValue(Scan_cd4,
				DataFormatUtil.GetFormatItem(tj040f01Form.Scan_cd4,formInfo["Scan_cd4"]));
			ControlUtil.SetControlValue(Scan_cd5,
				DataFormatUtil.GetFormatItem(tj040f01Form.Scan_cd5,formInfo["Scan_cd5"]));
			ControlUtil.SetControlValue(Searchcnt,
				DataFormatUtil.GetFormatItem(tj040f01Form.Searchcnt,formInfo["Searchcnt"]));

			if(!base.CheckUseSelfCustomize()){
				Btnheadtenpocd.Value = base.FormResourceGetString(formResource, "Btnheadtenpocd", lang);
				Btnmoderef.InnerText = base.FormResourceGetString(formResource, "Btnmoderef", lang);
				Btnmodeupd.InnerText = base.FormResourceGetString(formResource, "Btnmodeupd", lang);
				Btnmodedel.InnerText = base.FormResourceGetString(formResource, "Btnmodedel", lang);
				Btntanto_cd.Value = base.FormResourceGetString(formResource, "Btntanto_cd", lang);
				Btnsearch.Value = base.FormResourceGetString(formResource, "Btnsearch", lang);
				Btnzenstk.Value = base.FormResourceGetString(formResource, "Btnzenstk", lang);
				Btnzenkjo.Value = base.FormResourceGetString(formResource, "Btnzenkjo", lang);
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
				// 店舗／業者区分に空白を追加
				Tenpo_gyosya_kb.Items.Insert(0, new ListItem("", BoSystemConstant.DROPDOWNLIST_MISENTAKU));
				// 送信状態に空白を追加
				Sosin_jyotai.Items.Insert(0, new ListItem("", BoSystemConstant.DROPDOWNLIST_MISENTAKU));
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
			// UIScreenController controller = new UIScreenController((Tj040f01Form)base.GetPageContext().GetFormVO());
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


            Tj040f01Form formVO = (Tj040f01Form)base.GetPageContext().GetFormVO();

			//　送信日FROM-TO
			if ("1".Equals(formVO.Sosin_jyotai))
			{
				ControlCls.Disable(Sosin_ymd_from, true);
				ControlCls.Disable(Sosin_ymd_to, true);
			}
			else
			{
				ControlCls.Disable(Sosin_ymd_from, false);
				ControlCls.Disable(Sosin_ymd_to, false);
			}

            // [選択モードNo]が「取消」以外の場合
            if (!BoSystemString.Nvl(formVO.Stkmodeno).Equals(BoSystemConstant.MODE_DEL))
            {
                // 全選択ボタン使用不可
                ControlCls.Disable(Btnzenstk, true);
                // 全解除ボタン使用不可
                ControlCls.Disable(Btnzenkjo, true);

                // 確定ボタン使用不可
                ControlCls.Disable(Btnenter, true);
            }
            else
            {
                // 全選択ボタン使用可
                ControlCls.Disable(Btnzenstk, false);
                // 全解除ボタン使用可
                ControlCls.Disable(Btnzenkjo, false);

                // 確定ボタン使用不可
                ControlCls.Disable(Btnenter, false);
            }

            // [選択モードNo]が「照会」以外の場合
            if (!BoSystemString.Nvl(formVO.Stkmodeno).Equals(BoSystemConstant.MODE_REF))
            {
                // 印刷ボタン使用不可
                ControlCls.Disable(Btnprint, true);
                // CSV出力ボタン使用不可
                ControlCls.Disable(Btncsv, true);
            }
            else
            {
                // 印刷ボタン使用可
                ControlCls.Disable(Btnprint, false);

                // 権限取得部品の戻り値が"TRUE"の場合
                if (CheckKengenCls.CheckKengen(loginInfVO))
                {
                    // CSV出力ボタン使用可
                    ControlCls.Disable(Btncsv, false);
                }
                // 権限取得部品の戻り値が"FALSE"の場合
                else
                {
                    // CSV出力ボタン使用不可
                    ControlCls.Disable(Btncsv, true);
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
			//ControlUtil.SetControlValue(Face_no_from_lbl, 
				//DataFormatUtil.GetFormatCaption(formResource.GetString("Face_no_from", lang), base.GetPageContext().FormInfo["Face_no_from"]));
				ControlUtil.SetControlValue(Face_no_from_lbl, "フェイスNo");
				DataFormatUtil.SetMustColorCaption(Face_no_from_lbl, base.GetPageContext().FormInfo["Face_no_from"]);
			ControlUtil.SetControlValue(Face_no_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Face_no_to", lang), base.GetPageContext().FormInfo["Face_no_to"]));
				DataFormatUtil.SetMustColorCaption(Face_no_to_lbl, base.GetPageContext().FormInfo["Face_no_to"]);
			//ControlUtil.SetControlValue(Tana_dan_from_lbl, 
				//DataFormatUtil.GetFormatCaption(formResource.GetString("Tana_dan_from", lang), base.GetPageContext().FormInfo["Tana_dan_from"]));
				ControlUtil.SetControlValue(Tana_dan_from_lbl, "棚段");
				DataFormatUtil.SetMustColorCaption(Tana_dan_from_lbl, base.GetPageContext().FormInfo["Tana_dan_from"]);
			ControlUtil.SetControlValue(Tana_dan_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Tana_dan_to", lang), base.GetPageContext().FormInfo["Tana_dan_to"]));
				DataFormatUtil.SetMustColorCaption(Tana_dan_to_lbl, base.GetPageContext().FormInfo["Tana_dan_to"]);
			ControlUtil.SetControlValue(Tenpo_gyosya_kb_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Tenpo_gyosya_kb", lang), base.GetPageContext().FormInfo["Tenpo_gyosya_kb"]));
				DataFormatUtil.SetMustColorCaption(Tenpo_gyosya_kb_lbl, base.GetPageContext().FormInfo["Tenpo_gyosya_kb"]);
			//ControlUtil.SetControlValue(Nyuryoku_ymd_from_lbl, 
				//DataFormatUtil.GetFormatCaption(formResource.GetString("Nyuryoku_ymd_from", lang), base.GetPageContext().FormInfo["Nyuryoku_ymd_from"]));
				ControlUtil.SetControlValue(Nyuryoku_ymd_from_lbl, "入力日");
				DataFormatUtil.SetMustColorCaption(Nyuryoku_ymd_from_lbl, base.GetPageContext().FormInfo["Nyuryoku_ymd_from"]);
			ControlUtil.SetControlValue(Nyuryoku_ymd_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Nyuryoku_ymd_to", lang), base.GetPageContext().FormInfo["Nyuryoku_ymd_to"]));
				DataFormatUtil.SetMustColorCaption(Nyuryoku_ymd_to_lbl, base.GetPageContext().FormInfo["Nyuryoku_ymd_to"]);
			//ControlUtil.SetControlValue(Sosin_ymd_from_lbl, 
				//DataFormatUtil.GetFormatCaption(formResource.GetString("Sosin_ymd_from", lang), base.GetPageContext().FormInfo["Sosin_ymd_from"]));
			ControlUtil.SetControlValue(Sosin_ymd_from_lbl, "送信日");
				DataFormatUtil.SetMustColorCaption(Sosin_ymd_from_lbl, base.GetPageContext().FormInfo["Sosin_ymd_from"]);
			ControlUtil.SetControlValue(Sosin_ymd_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Sosin_ymd_to", lang), base.GetPageContext().FormInfo["Sosin_ymd_to"]));
				DataFormatUtil.SetMustColorCaption(Sosin_ymd_to_lbl, base.GetPageContext().FormInfo["Sosin_ymd_to"]);
			ControlUtil.SetControlValue(Nyuryokutan_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Nyuryokutan_cd", lang), base.GetPageContext().FormInfo["Nyuryokutan_cd"]));
				DataFormatUtil.SetMustColorCaption(Nyuryokutan_cd_lbl, base.GetPageContext().FormInfo["Nyuryokutan_cd"]);
			ControlUtil.SetControlValue(Nyuryokutan_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Nyuryokutan_nm", lang), base.GetPageContext().FormInfo["Nyuryokutan_nm"]));
				DataFormatUtil.SetMustColorCaption(Nyuryokutan_nm_lbl, base.GetPageContext().FormInfo["Nyuryokutan_nm"]);
			//ControlUtil.SetControlValue(Old_jisya_hbn_lbl, 
				//DataFormatUtil.GetFormatCaption(formResource.GetString("Old_jisya_hbn", lang), base.GetPageContext().FormInfo["Old_jisya_hbn"]));
				ControlUtil.SetControlValue(Old_jisya_hbn_lbl, "自社品番");
				DataFormatUtil.SetMustColorCaption(Old_jisya_hbn_lbl, base.GetPageContext().FormInfo["Old_jisya_hbn"]);
			ControlUtil.SetControlValue(Old_jisya_hbn2_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Old_jisya_hbn2", lang), base.GetPageContext().FormInfo["Old_jisya_hbn2"]));
				DataFormatUtil.SetMustColorCaption(Old_jisya_hbn2_lbl, base.GetPageContext().FormInfo["Old_jisya_hbn2"]);
			ControlUtil.SetControlValue(Old_jisya_hbn3_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Old_jisya_hbn3", lang), base.GetPageContext().FormInfo["Old_jisya_hbn3"]));
				DataFormatUtil.SetMustColorCaption(Old_jisya_hbn3_lbl, base.GetPageContext().FormInfo["Old_jisya_hbn3"]);
			ControlUtil.SetControlValue(Old_jisya_hbn4_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Old_jisya_hbn4", lang), base.GetPageContext().FormInfo["Old_jisya_hbn4"]));
				DataFormatUtil.SetMustColorCaption(Old_jisya_hbn4_lbl, base.GetPageContext().FormInfo["Old_jisya_hbn4"]);
			ControlUtil.SetControlValue(Old_jisya_hbn5_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Old_jisya_hbn5", lang), base.GetPageContext().FormInfo["Old_jisya_hbn5"]));
				DataFormatUtil.SetMustColorCaption(Old_jisya_hbn5_lbl, base.GetPageContext().FormInfo["Old_jisya_hbn5"]);
			ControlUtil.SetControlValue(Sosin_jyotai_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Sosin_jyotai", lang), base.GetPageContext().FormInfo["Sosin_jyotai"]));
				DataFormatUtil.SetMustColorCaption(Sosin_jyotai_lbl, base.GetPageContext().FormInfo["Sosin_jyotai"]);
			ControlUtil.SetControlValue(Teisei_flg_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Teisei_flg", lang), base.GetPageContext().FormInfo["Teisei_flg"]));
				DataFormatUtil.SetMustColorCaption(Teisei_flg_lbl, base.GetPageContext().FormInfo["Teisei_flg"]);
			//ControlUtil.SetControlValue(Scan_cd_lbl, 
				//DataFormatUtil.GetFormatCaption(formResource.GetString("Scan_cd", lang), base.GetPageContext().FormInfo["Scan_cd"]));
				ControlUtil.SetControlValue(Scan_cd_lbl, "ｽｷｬﾝｺｰﾄﾞ");
				DataFormatUtil.SetMustColorCaption(Scan_cd_lbl, base.GetPageContext().FormInfo["Scan_cd"]);
			ControlUtil.SetControlValue(Scan_cd2_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Scan_cd2", lang), base.GetPageContext().FormInfo["Scan_cd2"]));
				DataFormatUtil.SetMustColorCaption(Scan_cd2_lbl, base.GetPageContext().FormInfo["Scan_cd2"]);
			ControlUtil.SetControlValue(Scan_cd3_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Scan_cd3", lang), base.GetPageContext().FormInfo["Scan_cd3"]));
				DataFormatUtil.SetMustColorCaption(Scan_cd3_lbl, base.GetPageContext().FormInfo["Scan_cd3"]);
			ControlUtil.SetControlValue(Scan_cd4_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Scan_cd4", lang), base.GetPageContext().FormInfo["Scan_cd4"]));
				DataFormatUtil.SetMustColorCaption(Scan_cd4_lbl, base.GetPageContext().FormInfo["Scan_cd4"]);
			ControlUtil.SetControlValue(Scan_cd5_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Scan_cd5", lang), base.GetPageContext().FormInfo["Scan_cd5"]));
				DataFormatUtil.SetMustColorCaption(Scan_cd5_lbl, base.GetPageContext().FormInfo["Scan_cd5"]);
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
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1face_no", lang), base.GetPageContext().FormInfo["M1face_no"]);
				// M1.Columns[2].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tana_dan", lang), base.GetPageContext().FormInfo["M1tana_dan"]);
				// M1.Columns[3].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kai_su", lang), base.GetPageContext().FormInfo["M1kai_su"]);
				// M1.Columns[4].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tensutanaorosinyuryoku_su", lang), base.GetPageContext().FormInfo["M1tensutanaorosinyuryoku_su"]);
				// M1.Columns[5].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tensutanaorositeisei_su", lang), base.GetPageContext().FormInfo["M1tensutanaorositeisei_su"]);
				// M1.Columns[6].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tensutanaorosigokei_su", lang), base.GetPageContext().FormInfo["M1tensutanaorosigokei_su"]);
				// M1.Columns[7].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1scan_su", lang), base.GetPageContext().FormInfo["M1scan_su"]);
				// M1.Columns[8].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1teisei_suryo", lang), base.GetPageContext().FormInfo["M1teisei_suryo"]);
				// M1.Columns[9].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1gokei_suryo", lang), base.GetPageContext().FormInfo["M1gokei_suryo"]);
				// M1.Columns[10].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1nyuryokutan_nm", lang), base.GetPageContext().FormInfo["M1nyuryokutan_nm"]);
				// M1.Columns[11].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1teiseitan_nm", lang), base.GetPageContext().FormInfo["M1teiseitan_nm"]);
				// M1.Columns[12].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1riyucomment_nm", lang), base.GetPageContext().FormInfo["M1riyucomment_nm"]);
				// M1.Columns[13].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1nyuryoku_ymd", lang), base.GetPageContext().FormInfo["M1nyuryoku_ymd"]);
				// M1.Columns[14].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1sosin_ymd", lang), base.GetPageContext().FormInfo["M1sosin_ymd"]);
				// M1.Columns[15].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1gyosya", lang), base.GetPageContext().FormInfo["M1gyosya"]);
				// M1.Columns[16].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1selectorcheckbox", lang), base.GetPageContext().FormInfo["M1selectorcheckbox"]);
				// M1.Columns[17].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1entersyoriflg", lang), base.GetPageContext().FormInfo["M1entersyoriflg"]);
				// M1.Columns[18].HeaderText = 
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
				Windowtitle.InnerText = formResource.GetString("Tj040f01_Titlebar", lang);
				header.FormName = formResource.GetString("Tj040f01_FormCaption", lang);
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
