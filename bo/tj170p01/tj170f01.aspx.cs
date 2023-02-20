using com.xebio.bo.Tj170p01.Constant;
using com.xebio.bo.Tj170p01.Facade;
using com.xebio.bo.Tj170p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.Model.Context;
using Common.Advanced.Resource;
using Common.Advanced.Web.Context;
using Common.Advanced.Web.Util;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01013;
using Common.Business.C01000.C01014;
using Common.Business.C01000.C01015;
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

namespace com.xebio.bo.Tj170p01.Page
{
  /// <summary>
  /// Tj170f01のコードビハインドです。
  /// </summary>
  public partial class Tj170f01Page : StandardBasePage
	{

		#region メソッド

		#region ページデータをロードするメソッド
		/// <summary>
		/// Tj170f01画面データを作成する。
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
						pageContext.SetFormVO(new Tj170f01Form());
						switch(commandInfo.ActionMode)
						{
							case "ADD":
								break;
							case "INI":
							case "DEL":
							case "UPD":
								IFacadeContext facadeContext =
									FacadeContextFactory.GetFacadeContext(pageContext);
								InitFacadeContext(facadeContext);
								new Tj170f01Facade().DoLoad(facadeContext);

								#region 共通ヘッダ処理

								// 一覧画面共通処理 ----------
								LoginInfoVO loginInfVO = LoginInfoUtil.GetLoginInfo();
								Tj170f01Form tj170f01Form = (Tj170f01Form)facadeContext.FormVO;
								ControlHeaderStoreCls.InitialSetHeaderStore<Tj170f01Form>(loginInfVO, tj170f01Form);

								#endregion
								if (string.IsNullOrEmpty(tj170f01Form.Modeno))
								{
									// アコーディオンなし
									AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_NONE);
									// モードNoを今回に設定
									tj170f01Form.Modeno = BoSystemConstant.MODE_KONKAI.ToString();
									TabUtil.SetTabNumber(pageContext, BoSystemConstant.MODE_KONKAI.ToString());
								}
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
					Tj170f01Form f01VO = (Tj170f01Form)fvm.GetProgramVO(base.GetPageContext().CommandInfo.ProgramId).GetFormVO(Tj170p01Constant.FORMID_01);
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
				// 明細を非表示にする
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

				// 警告メッセージ用HIDDENがある場合、ファサードに渡す
				if (this.Request[BoSystemConstant.WARNING_HDNITEM_NM] != null)
				{
					facadeContext.SetUserObject(BoSystemConstant.WARNING_FCD_KEY, BoSystemString.Nvl(this.Request[BoSystemConstant.WARNING_HDNITEM_NM], "0"));
				}
				new Tj170f01Facade().DoBTNSEARCH_FRM(facadeContext);

				// 警告判定
				if (InfoMsgCls.HasWarn(facadeContext))
				{
					// 警告メッセージを表示
					String Script = InfoMsgCls.showLoadMsg(pageContext, 2, "Btnsearch");
					Page.ClientScript.RegisterStartupScript(typeof(string), "infoDialog", Script);
					//アコーディオンなし
					AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_NONE);
					return;
				}				

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
				ModeUtil.SetMode(pageContext, ModeCls.GetModeNm(((Tj170f01Form)pageContext.GetFormVO()).Stkmodeno));

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
			#region フォーカス設定
			// 一行目の[Ｍ１商品群1リンク]にフォーカスを当てる。
			// フォーカス設定用変数
            string focusItem = string.Empty;
            string focusMno = string.Empty;

            // 表示明細先頭のＭ１元伝リンクにフォーカス設定
			focusItem = "M1syohingun1_cd";
            focusMno = "0";

            // フォーカス設定
            SetFocusCls.SetFocus(queryList, focusItem, focusMno);

			#endregion
			
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
				new Tj170f01Facade().DoBTNZENSTK_FRM(facadeContext);
				
				
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
				new Tj170f01Facade().DoBTNZENKJO_FRM(facadeContext);
				
				
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
				new Tj170f01Facade().DoBTNPRINT_FRM(facadeContext);

				// PDFファイル名を取得
				pdfNm = (string)facadeContext.GetUserObject(Tj170p01Constant.FCDUO_RRT_FLNM);

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

			#region 帳票印刷

			string reportNm = string.Empty;
			if (Shuturyoku_print.SelectedValue.Equals(ConditionShuturyoku_print.VALUE_SHUTURYOKU_PRINT1))
			{
				reportNm = BoSystemConstant.REPORTNM_TANAOROSILOSSLIST;
			}
			else if (Shuturyoku_print.SelectedValue.Equals(ConditionShuturyoku_print.VALUE_SHUTURYOKU_PRINT2))
			{
				reportNm = BoSystemConstant.REPORTNM_TANAOROSILOSSLISTSUMMARY;
			}

			DLConditionVO dlvo = new DLConditionVO();
			// サーバファイルフルパス
			string serverPath = string.Format("{0}{1}{2}",
											FilePathManager.GetOutFilePath(Tj170p01Constant.PGID),
											Path.DirectorySeparatorChar,
											pdfNm
											);
			// クライアントファイル名
			string clientNm = string.Format("{0}.{1}",
											BoSystemReport.CreateFileName(reportNm, 2),
											BoSystemConstant.RPT_PDF_EXTENSION
											);
			// ダウンロード用VOに値を設定
			dlvo.setSingleFileDownloadCondition(serverPath, clientNm);

			// ダウンロード用VOをセッションに格納
			SessionInfoUtil.SetPgObject(BoSystemConstant.SESSION_KEY_DOWNLOAD_VO, dlvo, pageContext);

			#endregion

			#region フォーカス制御
			// フォーカス設定用変数
			string focusItem = string.Empty;
			string focusMno = string.Empty;

			// 1行目の[M1商品群1リンク]にフォーカスを当てる。
			focusItem = "M1syohingun1_cd";
			focusMno = "0";

			// フォーカス設定
			queryList = SetFocusCls.SetFocus(queryList, focusItem, focusMno);
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
				new Tj170f01Facade().DoBTNCSV_FRM(facadeContext);
				
				
				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
					base.SetError(pageContext);
					return;
				}

				// CSVファイル名を取得
				csvNm = (string)facadeContext.GetUserObject(Tj170p01Constant.FCDUO_CSV_FLNM);
	
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
											FilePathManager.GetOutFilePath(Tj170p01Constant.PGID),
											Path.DirectorySeparatorChar,
											csvNm
											);
			// クライアントファイル名
			string clientNm = string.Format("{0}{1}",
											BoSystemReport.CreateFileName(BoSystemConstant.CSVNM_LOSS, 2),
											FilePathManager.EXT_CSV
											);

			// ダウンロード用VOに値を設定
			dlvo.setSingleFileDownloadCondition(serverPath, clientNm);

			// ダウンロード用VOをセッションに格納
			SessionInfoUtil.SetPgObject(BoSystemConstant.SESSION_KEY_DOWNLOAD_VO, dlvo, pageContext);

			#endregion

			#region フォーカス設定
			//todo
			// 一行目の[Ｍ１商品群1リンク]にフォーカスを当てる。
			// フォーカス設定用変数
			string focusItem = string.Empty;
			string focusMno = string.Empty;

			// 表示明細先頭のＭ１元伝リンクにフォーカス設定
			focusItem = "M1syohingun1_cd";
			focusMno = "0";

			// フォーカス設定
			SetFocusCls.SetFocus(queryList, focusItem, focusMno);

			#endregion

			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNCSV_FRM");

			// ダウンロード用VOに値を設定
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
				new Tj170f01Facade().DoPGR_PGN(facadeContext, pageindex);
				
				
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
		
		#region フォームを呼び出します(ボタンID : M1syohingun1_cd(商品群1))
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(M1syohingun1_cd(商品群1))
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnM1SYOHINGUN1_CD_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnM1SYOHINGUN1_CD_FRM");
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
				facadeContext.SetUserObject(Tj170p01Constant.FCDUO_NEXTVO, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Tj170p01Constant.FORMID_02));
				new Tj170f01Facade().DoM1SYOHINGUN1_CD_FRM(facadeContext);
				// 次画面のフォームビーンを設定
				fvm.SetFormVO(Tj170p01Constant.PGID, Tj170p01Constant.FORMID_02, (Tj170f02Form)facadeContext.GetUserObject(Tj170p01Constant.FCDUO_NEXTVO));
				
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
			EndMethod(sender, e, this.GetType().Name + ".OnM1SYOHINGUN1_CD_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : M1syohingun1_ryaku_nm())
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(M1syohingun1_ryaku_nm())
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnM1SYOHINGUN1_RYAKU_NM_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnM1SYOHINGUN1_RYAKU_NM_FRM");
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
				new Tj170f01Facade().DoM1SYOHINGUN1_RYAKU_NM_FRM(facadeContext);
				
				
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
			EndMethod(sender, e, this.GetType().Name + ".OnM1SYOHINGUN1_RYAKU_NM_FRM");
			
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
						Tj170f01Form tj170f01Form = (Tj170f01Form)pageContext.GetFormVO();

						//明細ページ情報を表示する
						ShowListPageInfo(tj170f01Form);
			
						//明細部データを表示する
						RenderList(tj170f01Form, pageContext.FormInfo, formResource, lang);

						//カード部データを表示する
						RenderCard(tj170f01Form, pageContext.FormInfo, formResource, lang);
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
		/// <param name="tj170f01Form">画面FormVO</param>
		private void ShowListPageInfo(Tj170f01Form tj170f01Form)
		{
			//M1明細ページ情報を表示する。
			ShowM1ListPageInfo(tj170f01Form.GetList("M1"));

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
		/// <param name="tj170f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderList(
			Tj170f01Form tj170f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//画面のM1明細部データを設定する。
			RenderM1List(tj170f01Form, formInfo, formResource, lang);
			//M1明細部のページャーにページ情報を設定する。
			RenderM1Pager(tj170f01Form);
			
		}
		#endregion

		#region M1明細データを表示する
		/// <summary>
		/// M1明細データを表示する。
		/// </summary>
		/// <param name="tj170f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderM1List(
			Tj170f01Form tj170f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//M1明細部データソースを設定する。
			M1.DataSource = tj170f01Form.GetPageViewList("M1");
			M1.DataBind();

			//M1明細部データをフォーマットする。
			IList m1DataList = (IList)M1.DataSource;
			
			for (int index = 0; index < M1.Items.Count; index++)
			{
				Tj170f01M1Form tj170f01M1Form = (Tj170f01M1Form)m1DataList[index];
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1rowno"),
					DataFormatUtil.GetFormatItem(tj170f01M1Form.M1rowno,formInfo["M1rowno"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1syohingun2_cd"),
					DataFormatUtil.GetFormatItem(tj170f01M1Form.M1syohingun2_cd,formInfo["M1syohingun2_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1grpnm"),
					DataFormatUtil.GetFormatItem(tj170f01M1Form.M1grpnm,formInfo["M1grpnm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1bumon_cd"),
					DataFormatUtil.GetFormatItem(tj170f01M1Form.M1bumon_cd,formInfo["M1bumon_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1bumonkana_nm"),
					DataFormatUtil.GetFormatItem(tj170f01M1Form.M1bumonkana_nm,formInfo["M1bumonkana_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1tanajityobo_su"),
					DataFormatUtil.GetFormatItem(tj170f01M1Form.M1tanajityobo_su,formInfo["M1tanajityobo_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1tanajisekiso_su"),
					DataFormatUtil.GetFormatItem(tj170f01M1Form.M1tanajisekiso_su,formInfo["M1tanajisekiso_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1jitana_su"),
					DataFormatUtil.GetFormatItem(tj170f01M1Form.M1jitana_su,formInfo["M1jitana_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1ikoukebarai_su"),
					DataFormatUtil.GetFormatItem(tj170f01M1Form.M1ikoukebarai_su,formInfo["M1ikoukebarai_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1rironzaiko_su"),
					DataFormatUtil.GetFormatItem(tj170f01M1Form.M1rironzaiko_su,formInfo["M1rironzaiko_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1rirontanaorosi_su"),
					DataFormatUtil.GetFormatItem(tj170f01M1Form.M1rirontanaorosi_su,formInfo["M1rirontanaorosi_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1loss_su"),
					DataFormatUtil.GetFormatItem(tj170f01M1Form.M1loss_su,formInfo["M1loss_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1loss_kin"),
					DataFormatUtil.GetFormatItem(tj170f01M1Form.M1loss_kin,formInfo["M1loss_kin"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1selectorcheckbox"),
					DataFormatUtil.GetFormatItem(tj170f01M1Form.M1selectorcheckbox,formInfo["M1selectorcheckbox"]));
				((System.Web.UI.WebControls.CheckBox)M1.Items[index].FindControl("M1selectorcheckbox")).Text =
					formResource.GetString("M1selectorcheckbox", lang);
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1entersyoriflg"),
					DataFormatUtil.GetFormatItem(tj170f01M1Form.M1entersyoriflg,formInfo["M1entersyoriflg"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1dtlirokbn"),
					DataFormatUtil.GetFormatItem(tj170f01M1Form.M1dtlirokbn,formInfo["M1dtlirokbn"]));
				if (!base.CheckUseSelfCustomize())
				{

				}

				if(!base.CheckUseSelfCustomize()){
					((System.Web.UI.HtmlControls.HtmlInputButton)M1.Items[index].FindControl("M1syohingun1_cd")).Value =
						tj170f01M1Form.Dictionary[Tj170p01Constant.DIC_M1SYOHINGUN1_CD].ToString() + " " +tj170f01M1Form.Dictionary[Tj170p01Constant.DIC_M1SYOHINGUN1_RYAKU_NM].ToString();
					((System.Web.UI.HtmlControls.HtmlInputButton)M1.Items[index].FindControl("M1syohingun1_ryaku_nm")).Value =
						tj170f01M1Form.Dictionary[Tj170p01Constant.DIC_M1SYOHINGUN1_RYAKU_NM].ToString();
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
				// (M1.HeaderRow.FindControl("M1syohingun1_cd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syohingun1_cd", lang), base.GetPageContext().FormInfo["M1syohingun1_cd"]);
				// (M1.HeaderRow.FindControl("M1syohingun1_ryaku_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syohingun1_ryaku_nm", lang), base.GetPageContext().FormInfo["M1syohingun1_ryaku_nm"]);
				// (M1.HeaderRow.FindControl("M1syohingun2_cd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syohingun2_cd", lang), base.GetPageContext().FormInfo["M1syohingun2_cd"]);
				// (M1.HeaderRow.FindControl("M1grpnm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1grpnm", lang), base.GetPageContext().FormInfo["M1grpnm"]);
				// (M1.HeaderRow.FindControl("M1bumon_cd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumon_cd", lang), base.GetPageContext().FormInfo["M1bumon_cd"]);
				// (M1.HeaderRow.FindControl("M1bumonkana_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumonkana_nm", lang), base.GetPageContext().FormInfo["M1bumonkana_nm"]);
				// (M1.HeaderRow.FindControl("M1tanajityobo_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tanajityobo_su", lang), base.GetPageContext().FormInfo["M1tanajityobo_su"]);
				// (M1.HeaderRow.FindControl("M1tanajisekiso_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tanajisekiso_su", lang), base.GetPageContext().FormInfo["M1tanajisekiso_su"]);
				// (M1.HeaderRow.FindControl("M1jitana_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1jitana_su", lang), base.GetPageContext().FormInfo["M1jitana_su"]);
				// (M1.HeaderRow.FindControl("M1ikoukebarai_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1ikoukebarai_su", lang), base.GetPageContext().FormInfo["M1ikoukebarai_su"]);
				// (M1.HeaderRow.FindControl("M1rironzaiko_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1rironzaiko_su", lang), base.GetPageContext().FormInfo["M1rironzaiko_su"]);
				// (M1.HeaderRow.FindControl("M1rirontanaorosi_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1rirontanaorosi_su", lang), base.GetPageContext().FormInfo["M1rirontanaorosi_su"]);
				// (M1.HeaderRow.FindControl("M1loss_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1loss_su", lang), base.GetPageContext().FormInfo["M1loss_su"]);
				// (M1.HeaderRow.FindControl("M1loss_kin") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1loss_kin", lang), base.GetPageContext().FormInfo["M1loss_kin"]);
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
		/// <param name="tj170f01Form">画面FormVO</param>
		private void RenderM1Pager(Tj170f01Form tj170f01Form)
		{
			Pgr.VirtualItemCount = tj170f01Form.GetList("M1").RecordCount;
			Pgr.CurrentPageIndex = tj170f01Form.GetList("M1").PageNo - 1;
			Pgr.PageSize = tj170f01Form.GetList("M1").DispRow;
		}
		#endregion
		#endregion

		#region カードデータを表示する
		/// <summary>
		/// カードデータを表示する
		/// </summary>
		/// <param name="tj170f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderCard(
			Tj170f01Form tj170f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			
			ControlUtil.SetControlValue(Head_tenpo_cd,
				DataFormatUtil.GetFormatItem(tj170f01Form.Head_tenpo_cd,formInfo["Head_tenpo_cd"]));
			ControlUtil.SetControlValue(Head_tenpo_nm,
				DataFormatUtil.GetFormatItem(tj170f01Form.Head_tenpo_nm,formInfo["Head_tenpo_nm"]));
			ControlUtil.SetControlValue(Modeno,
				DataFormatUtil.GetFormatItem(tj170f01Form.Modeno,formInfo["Modeno"]));
			ControlUtil.SetControlValue(Stkmodeno,
				DataFormatUtil.GetFormatItem(tj170f01Form.Stkmodeno,formInfo["Stkmodeno"]));
			ControlUtil.SetControlValue(Tanaorosikijun_ymd,
				DataFormatUtil.GetFormatItem(tj170f01Form.Tanaorosikijun_ymd,formInfo["Tanaorosikijun_ymd"]));
			ControlUtil.SetControlValue(Tanaorosijissi_ymd1,
				DataFormatUtil.GetFormatItem(tj170f01Form.Tanaorosijissi_ymd1,formInfo["Tanaorosijissi_ymd1"]));
			ControlUtil.SetControlValue(Tanaorosikikan_from1,
				DataFormatUtil.GetFormatItem(tj170f01Form.Tanaorosikikan_from1,formInfo["Tanaorosikikan_from1"]));
			ControlUtil.SetControlValue(Tanaorosikikan_to1,
				DataFormatUtil.GetFormatItem(tj170f01Form.Tanaorosikikan_to1,formInfo["Tanaorosikikan_to1"]));
			ControlUtil.SetControlValue(Tanaorosikijun_ymd1,
				DataFormatUtil.GetFormatItem(tj170f01Form.Tanaorosikijun_ymd1,formInfo["Tanaorosikijun_ymd1"]));
			ControlUtil.SetControlValue(Tanaorosijissi_ymd11,
				DataFormatUtil.GetFormatItem(tj170f01Form.Tanaorosijissi_ymd11,formInfo["Tanaorosijissi_ymd11"]));
			ControlUtil.SetControlValue(Tanaorosikikan_from11,
				DataFormatUtil.GetFormatItem(tj170f01Form.Tanaorosikikan_from11,formInfo["Tanaorosikikan_from11"]));
			ControlUtil.SetControlValue(Tanaorosikikan_to11,
				DataFormatUtil.GetFormatItem(tj170f01Form.Tanaorosikikan_to11,formInfo["Tanaorosikikan_to11"]));
			ControlUtil.SetControlValue(Syohingun1_cd,
				DataFormatUtil.GetFormatItem(tj170f01Form.Syohingun1_cd,formInfo["Syohingun1_cd"]));
			ControlUtil.SetControlValue(Syohingun1_ryaku_nm,
				DataFormatUtil.GetFormatItem(tj170f01Form.Syohingun1_ryaku_nm,formInfo["Syohingun1_ryaku_nm"]));
			ControlUtil.SetControlValue(Syohingun2_cd,
				DataFormatUtil.GetFormatItem(tj170f01Form.Syohingun2_cd,formInfo["Syohingun2_cd"]));
			ControlUtil.SetControlValue(Grpnm,
				DataFormatUtil.GetFormatItem(tj170f01Form.Grpnm,formInfo["Grpnm"]));
			ControlUtil.SetControlValue(Bumon_cd_from,
				DataFormatUtil.GetFormatItem(tj170f01Form.Bumon_cd_from,formInfo["Bumon_cd_from"]));
			ControlUtil.SetControlValue(Bumon_nm_from,
				DataFormatUtil.GetFormatItem(tj170f01Form.Bumon_nm_from,formInfo["Bumon_nm_from"]));
			ControlUtil.SetControlValue(Hinsyu_cd_from,
				DataFormatUtil.GetFormatItem(tj170f01Form.Hinsyu_cd_from,formInfo["Hinsyu_cd_from"]));
			ControlUtil.SetControlValue(Hinsyu_ryaku_nm_from,
				DataFormatUtil.GetFormatItem(tj170f01Form.Hinsyu_ryaku_nm_from,formInfo["Hinsyu_ryaku_nm_from"]));
			ControlUtil.SetControlValue(Bumon_cd_to,
				DataFormatUtil.GetFormatItem(tj170f01Form.Bumon_cd_to,formInfo["Bumon_cd_to"]));
			ControlUtil.SetControlValue(Bumon_nm_to,
				DataFormatUtil.GetFormatItem(tj170f01Form.Bumon_nm_to,formInfo["Bumon_nm_to"]));
			ControlUtil.SetControlValue(Hinsyu_cd_to,
				DataFormatUtil.GetFormatItem(tj170f01Form.Hinsyu_cd_to,formInfo["Hinsyu_cd_to"]));
			ControlUtil.SetControlValue(Hinsyu_ryaku_nm_to,
				DataFormatUtil.GetFormatItem(tj170f01Form.Hinsyu_ryaku_nm_to,formInfo["Hinsyu_ryaku_nm_to"]));
			ControlUtil.SetControlValue(Burando_cd,
				DataFormatUtil.GetFormatItem(tj170f01Form.Burando_cd,formInfo["Burando_cd"]));
			ControlUtil.SetControlValue(Burando_nm,
				DataFormatUtil.GetFormatItem(tj170f01Form.Burando_nm,formInfo["Burando_nm"]));
			ControlUtil.SetControlValue(Loss_tensu,
				DataFormatUtil.GetFormatItem(tj170f01Form.Loss_tensu,formInfo["Loss_tensu"]));
			ControlUtil.SetControlValue(Loss_ari_flg,
				DataFormatUtil.GetFormatItem(tj170f01Form.Loss_ari_flg,formInfo["Loss_ari_flg"]));
			Loss_ari_flg.Text = formResource.GetString("Loss_ari_flg", lang);
			ControlUtil.SetControlValue(Shuturyoku_tani,
				DataFormatUtil.GetFormatItem(tj170f01Form.Shuturyoku_tani,formInfo["Shuturyoku_tani"]));
			ControlUtil.SetControlValue(Sort_jun,
				DataFormatUtil.GetFormatItem(tj170f01Form.Sort_jun,formInfo["Sort_jun"]));
			ControlUtil.SetControlValue(Searchcnt,
				DataFormatUtil.GetFormatItem(tj170f01Form.Searchcnt,formInfo["Searchcnt"]));
			ControlUtil.SetControlValue(Shuturyoku_print,
				DataFormatUtil.GetFormatItem(tj170f01Form.Shuturyoku_print,formInfo["Shuturyoku_print"]));

			if(!base.CheckUseSelfCustomize()){
				Btnheadtenpocd.Value = base.FormResourceGetString(formResource, "Btnheadtenpocd", lang);
				Btnmodekonkai.InnerText = base.FormResourceGetString(formResource, "Btnmodekonkai", lang);
				Btnmodezenkai.InnerText = base.FormResourceGetString(formResource, "Btnmodezenkai", lang);
				Btnsyohingun1_cd.Value = base.FormResourceGetString(formResource, "Btnsyohingun1_cd", lang);
				Btnsyohingun2_cd.Value = base.FormResourceGetString(formResource, "Btnsyohingun2_cd", lang);
				Btnbumon_cd_from.Value = base.FormResourceGetString(formResource, "Btnbumon_cd_from", lang);
				Btnhinsyu_cd_from.Value = base.FormResourceGetString(formResource, "Btnhinsyu_cd_from", lang);
				Btnbumon_cd_to.Value = base.FormResourceGetString(formResource, "Btnbumon_cd_to", lang);
				Btnhinsyu_cd_to.Value = base.FormResourceGetString(formResource, "Btnhinsyu_cd_to", lang);
				Btnburando_cd.Value = base.FormResourceGetString(formResource, "Btnburando_cd", lang);
				Btnsearch.Value = base.FormResourceGetString(formResource, "Btnsearch", lang);
				Btnzenstk.Value = base.FormResourceGetString(formResource, "Btnzenstk", lang);
				Btnzenkjo.Value = base.FormResourceGetString(formResource, "Btnzenkjo", lang);
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
			// UIScreenController controller = new UIScreenController((Tj170f01Form)base.GetPageContext().GetFormVO());
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
			ControlUtil.SetControlValue(Tanaorosijissi_ymd1_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Tanaorosijissi_ymd1", lang), base.GetPageContext().FormInfo["Tanaorosijissi_ymd1"]));
				DataFormatUtil.SetMustColorCaption(Tanaorosijissi_ymd1_lbl, base.GetPageContext().FormInfo["Tanaorosijissi_ymd1"]);
//			ControlUtil.SetControlValue(Tanaorosikikan_from1_lbl, 
//				DataFormatUtil.GetFormatCaption(formResource.GetString("Tanaorosikikan_from1", lang), base.GetPageContext().FormInfo["Tanaorosikikan_from1"]));
			ControlUtil.SetControlValue(Tanaorosikikan_from1_lbl, "棚卸期間");
				DataFormatUtil.SetMustColorCaption(Tanaorosikikan_from1_lbl, base.GetPageContext().FormInfo["Tanaorosikikan_from1"]);
			ControlUtil.SetControlValue(Tanaorosikikan_to1_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Tanaorosikikan_to1", lang), base.GetPageContext().FormInfo["Tanaorosikikan_to1"]));
				DataFormatUtil.SetMustColorCaption(Tanaorosikikan_to1_lbl, base.GetPageContext().FormInfo["Tanaorosikikan_to1"]);
			ControlUtil.SetControlValue(Tanaorosijissi_ymd11_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Tanaorosijissi_ymd11", lang), base.GetPageContext().FormInfo["Tanaorosijissi_ymd11"]));
				DataFormatUtil.SetMustColorCaption(Tanaorosijissi_ymd11_lbl, base.GetPageContext().FormInfo["Tanaorosijissi_ymd11"]);
//			ControlUtil.SetControlValue(Tanaorosikikan_from11_lbl, 
//				DataFormatUtil.GetFormatCaption(formResource.GetString("Tanaorosikikan_from11", lang), base.GetPageContext().FormInfo["Tanaorosikikan_from11"]));
				ControlUtil.SetControlValue(Tanaorosikikan_from11_lbl, "棚卸期間");
				DataFormatUtil.SetMustColorCaption(Tanaorosikikan_from11_lbl, base.GetPageContext().FormInfo["Tanaorosikikan_from11"]);
			ControlUtil.SetControlValue(Tanaorosikikan_to11_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Tanaorosikikan_to11", lang), base.GetPageContext().FormInfo["Tanaorosikikan_to11"]));
				DataFormatUtil.SetMustColorCaption(Tanaorosikikan_to11_lbl, base.GetPageContext().FormInfo["Tanaorosikikan_to11"]);
			ControlUtil.SetControlValue(Syohingun1_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Syohingun1_cd", lang), base.GetPageContext().FormInfo["Syohingun1_cd"]));
				DataFormatUtil.SetMustColorCaption(Syohingun1_cd_lbl, base.GetPageContext().FormInfo["Syohingun1_cd"]);
			ControlUtil.SetControlValue(Syohingun1_ryaku_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Syohingun1_ryaku_nm", lang), base.GetPageContext().FormInfo["Syohingun1_ryaku_nm"]));
				DataFormatUtil.SetMustColorCaption(Syohingun1_ryaku_nm_lbl, base.GetPageContext().FormInfo["Syohingun1_ryaku_nm"]);
			ControlUtil.SetControlValue(Syohingun2_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Syohingun2_cd", lang), base.GetPageContext().FormInfo["Syohingun2_cd"]));
				DataFormatUtil.SetMustColorCaption(Syohingun2_cd_lbl, base.GetPageContext().FormInfo["Syohingun2_cd"]);
			ControlUtil.SetControlValue(Grpnm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Grpnm", lang), base.GetPageContext().FormInfo["Grpnm"]));
				DataFormatUtil.SetMustColorCaption(Grpnm_lbl, base.GetPageContext().FormInfo["Grpnm"]);
//				ControlUtil.SetControlValue(Bumon_cd_from_lbl,
//					DataFormatUtil.GetFormatCaption(formResource.GetString("Bumon_cd_from", lang), base.GetPageContext().FormInfo["Bumon_cd_from"]));
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
			ControlUtil.SetControlValue(Loss_tensu_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Loss_tensu", lang), base.GetPageContext().FormInfo["Loss_tensu"]));
				DataFormatUtil.SetMustColorCaption(Loss_tensu_lbl, base.GetPageContext().FormInfo["Loss_tensu"]);
			ControlUtil.SetControlValue(Loss_ari_flg_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Loss_ari_flg", lang), base.GetPageContext().FormInfo["Loss_ari_flg"]));
				DataFormatUtil.SetMustColorCaption(Loss_ari_flg_lbl, base.GetPageContext().FormInfo["Loss_ari_flg"]);
			ControlUtil.SetControlValue(Shuturyoku_tani_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Shuturyoku_tani", lang), base.GetPageContext().FormInfo["Shuturyoku_tani"]));
				DataFormatUtil.SetMustColorCaption(Shuturyoku_tani_lbl, base.GetPageContext().FormInfo["Shuturyoku_tani"]);
			ControlUtil.SetControlValue(Sort_jun_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Sort_jun", lang), base.GetPageContext().FormInfo["Sort_jun"]));
				DataFormatUtil.SetMustColorCaption(Sort_jun_lbl, base.GetPageContext().FormInfo["Sort_jun"]);
			ControlUtil.SetControlValue(Searchcnt_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Searchcnt", lang), base.GetPageContext().FormInfo["Searchcnt"]));
				DataFormatUtil.SetMustColorCaption(Searchcnt_lbl, base.GetPageContext().FormInfo["Searchcnt"]);
			ControlUtil.SetControlValue(Shuturyoku_print_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Shuturyoku_print", lang), base.GetPageContext().FormInfo["Shuturyoku_print"]));
				DataFormatUtil.SetMustColorCaption(Shuturyoku_print_lbl, base.GetPageContext().FormInfo["Shuturyoku_print"]);
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
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syohingun1_cd", lang), base.GetPageContext().FormInfo["M1syohingun1_cd"]);
				// M1.Columns[2].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syohingun1_ryaku_nm", lang), base.GetPageContext().FormInfo["M1syohingun1_ryaku_nm"]);
				// M1.Columns[3].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syohingun2_cd", lang), base.GetPageContext().FormInfo["M1syohingun2_cd"]);
				// M1.Columns[4].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1grpnm", lang), base.GetPageContext().FormInfo["M1grpnm"]);
				// M1.Columns[5].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumon_cd", lang), base.GetPageContext().FormInfo["M1bumon_cd"]);
				// M1.Columns[6].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumonkana_nm", lang), base.GetPageContext().FormInfo["M1bumonkana_nm"]);
				// M1.Columns[7].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tanajityobo_su", lang), base.GetPageContext().FormInfo["M1tanajityobo_su"]);
				// M1.Columns[8].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tanajisekiso_su", lang), base.GetPageContext().FormInfo["M1tanajisekiso_su"]);
				// M1.Columns[9].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1jitana_su", lang), base.GetPageContext().FormInfo["M1jitana_su"]);
				// M1.Columns[10].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1ikoukebarai_su", lang), base.GetPageContext().FormInfo["M1ikoukebarai_su"]);
				// M1.Columns[11].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1rironzaiko_su", lang), base.GetPageContext().FormInfo["M1rironzaiko_su"]);
				// M1.Columns[12].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1rirontanaorosi_su", lang), base.GetPageContext().FormInfo["M1rirontanaorosi_su"]);
				// M1.Columns[13].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1loss_su", lang), base.GetPageContext().FormInfo["M1loss_su"]);
				// M1.Columns[14].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1loss_kin", lang), base.GetPageContext().FormInfo["M1loss_kin"]);
				// M1.Columns[15].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1selectorcheckbox", lang), base.GetPageContext().FormInfo["M1selectorcheckbox"]);
				// M1.Columns[16].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1entersyoriflg", lang), base.GetPageContext().FormInfo["M1entersyoriflg"]);
				// M1.Columns[17].HeaderText = 
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
				Windowtitle.InnerText = formResource.GetString("Tj170f01_Titlebar", lang);
				header.FormName = formResource.GetString("Tj170f01_FormCaption", lang);
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
