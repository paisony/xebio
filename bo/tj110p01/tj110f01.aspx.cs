using com.xebio.bo.Tj110p01.Constant;
using com.xebio.bo.Tj110p01.Facade;
using com.xebio.bo.Tj110p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.Model.Context;
using Common.Advanced.Resource;
using Common.Advanced.Web.Context;
using Common.Advanced.Web.Control;
using Common.Advanced.Web.Util;
using Common.Business.C01000.C01013;
using Common.Business.C01000.C01015;
using Common.Business.C99999.Constant;
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
using System.Web.UI.WebControls;

namespace com.xebio.bo.Tj110p01.Page
{
  /// <summary>
  /// Tj110f01のコードビハインドです。
  /// </summary>
  public partial class Tj110f01Page : StandardBasePage
	{

		#region メソッド

		#region ページデータをロードするメソッド
		/// <summary>
		/// Tj110f01画面データを作成する。
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
						pageContext.SetFormVO(new Tj110f01Form());
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
								new Tj110f01Facade().DoLoad(facadeContext);

								#region 共通ヘッダ処理

								// 一覧画面共通処理 ----------
								LoginInfoVO loginInfVO = LoginInfoUtil.GetLoginInfo();
								Tj110f01Form tj110f01Form = (Tj110f01Form)facadeContext.FormVO;
								ControlHeaderStoreCls.InitialSetHeaderStore<Tj110f01Form>(loginInfVO, tj110f01Form);
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
			pageContext = base.GetPageContext();
			ICommandInfo commandInfo = pageContext.CommandInfo;
			
			try
			{

				//アクションロジックを処理します
				IFacadeContext facadeContext = FacadeContextFactory.GetFacadeContext(pageContext);
				InitFacadeContext(facadeContext);
				new Tj110f01Facade().DoBTNSEARCH_FRM(facadeContext);
				
				
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
				new Tj110f01Facade().DoBTNZENSTK_FRM(facadeContext);
				
				
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
				new Tj110f01Facade().DoBTNZENKJO_FRM(facadeContext);
				
				
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

			DLConditionVO dlvo = new DLConditionVO();

			try
			{
				//アクションロジックを処理します
				IFacadeContext facadeContext = FacadeContextFactory.GetFacadeContext(pageContext);
				InitFacadeContext(facadeContext);
				new Tj110f01Facade().DoBTNPRINT_FRM(facadeContext);
				
				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
					base.SetError(pageContext);
					return;
				}

				Tj110f01Form f01VO = (Tj110f01Form)facadeContext.FormVO;

				//遷移先の画面設定（入出力画面定義で設定した遷移先は初期化処理で設定済み）
				//入出力画面定義で設定した遷移先以外の画面に遷移する場合は以下のソースを
				//コメントインし、設定して下さい。
				//commandInfo.ToProgramId = "遷移先プログラムID";
				//commandInfo.ToFormId = "遷移先フォームID";
				
				//他の処理モードを設定する必要がある場合、次の行を修正してください
				commandInfo.ActionMode = "UPD";
				commandInfo.PageLoadMode = false;

				#region 印刷処理

				//複数ダウンロード情報
				List<string> dlList = new List<string>();
				// PDFファイル名リスト取得
				dlList = facadeContext.GetUserObject(Tj110p01Constant.FCDUO_RRT_FLNM) as List<string>;

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
		
			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNPRINT_FRM");

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
				new Tj110f01Facade().DoPGR_PGN(facadeContext, pageindex);
				
				
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
				new Tj110f01Facade().DoBTNENTER_FRM(facadeContext);
				
				
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
//					if (!MessageDisplayUtil.HasError(pageContext))
//					{
						string lang = WebSettingsUtil.GetLangSettingFromSession(pageContext.Session);
						FormResource formResource =
							ResourceFactory.GetFormResource(pageContext.CommandInfo.FormId);
			
						//標題をセットする
						SetCaption(formResource, lang);

						//FormVOを取得する
						Tj110f01Form tj110f01Form = (Tj110f01Form)pageContext.GetFormVO();

						//明細ページ情報を表示する
						ShowListPageInfo(tj110f01Form);
			
						//明細部データを表示する
						RenderList(tj110f01Form, pageContext.FormInfo, formResource, lang);

						//カード部データを表示する
						RenderCard(tj110f01Form, pageContext.FormInfo, formResource, lang);
//					}
					
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
		/// <param name="tj110f01Form">画面FormVO</param>
		private void ShowListPageInfo(Tj110f01Form tj110f01Form)
		{
			//M1明細ページ情報を表示する。
			ShowM1ListPageInfo(tj110f01Form.GetList("M1"));

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
		/// <param name="tj110f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderList(
			Tj110f01Form tj110f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//画面のM1明細部データを設定する。
			RenderM1List(tj110f01Form, formInfo, formResource, lang);
			//M1明細部のページャーにページ情報を設定する。
			RenderM1Pager(tj110f01Form);
			
		}
		#endregion

		#region M1明細データを表示する
		/// <summary>
		/// M1明細データを表示する。
		/// </summary>
		/// <param name="tj110f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderM1List(
			Tj110f01Form tj110f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//M1明細部データソースを設定する。
			M1.DataSource = tj110f01Form.GetPageViewList("M1");
			M1.DataBind();

			//M1明細部データをフォーマットする。
			IList m1DataList = (IList)M1.DataSource;
			
			for (int index = 0; index < M1.Items.Count; index++)
			{
				Tj110f01M1Form tj110f01M1Form = (Tj110f01M1Form)m1DataList[index];
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1rowno"),
					DataFormatUtil.GetFormatItem(tj110f01M1Form.M1rowno,formInfo["M1rowno"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1face_no"),
					DataFormatUtil.GetFormatItem(tj110f01M1Form.M1face_no,formInfo["M1face_no"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1tana_dan"),
					DataFormatUtil.GetFormatItem(tj110f01M1Form.M1tana_dan,formInfo["M1tana_dan"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1selectorcheckbox"),
					DataFormatUtil.GetFormatItem(tj110f01M1Form.M1selectorcheckbox,formInfo["M1selectorcheckbox"]));
				((System.Web.UI.WebControls.CheckBox)M1.Items[index].FindControl("M1selectorcheckbox")).Text =
					formResource.GetString("M1selectorcheckbox", lang);
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1entersyoriflg"),
					DataFormatUtil.GetFormatItem(tj110f01M1Form.M1entersyoriflg,formInfo["M1entersyoriflg"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1dtlirokbn"),
					DataFormatUtil.GetFormatItem(tj110f01M1Form.M1dtlirokbn,formInfo["M1dtlirokbn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1rowno2"),
					DataFormatUtil.GetFormatItem(tj110f01M1Form.M1rowno2,formInfo["M1rowno2"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1face_no2"),
					DataFormatUtil.GetFormatItem(tj110f01M1Form.M1face_no2,formInfo["M1face_no2"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1tana_dan2"),
					DataFormatUtil.GetFormatItem(tj110f01M1Form.M1tana_dan2,formInfo["M1tana_dan2"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1selectorcheckbox2"),
					DataFormatUtil.GetFormatItem(tj110f01M1Form.M1selectorcheckbox2,formInfo["M1selectorcheckbox2"]));
				((System.Web.UI.WebControls.CheckBox)M1.Items[index].FindControl("M1selectorcheckbox2")).Text =
					formResource.GetString("M1selectorcheckbox2", lang);
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1entersyoriflg2"),
					DataFormatUtil.GetFormatItem(tj110f01M1Form.M1entersyoriflg2,formInfo["M1entersyoriflg2"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1dtlirokbn2"),
					DataFormatUtil.GetFormatItem(tj110f01M1Form.M1dtlirokbn2,formInfo["M1dtlirokbn2"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1rowno3"),
					DataFormatUtil.GetFormatItem(tj110f01M1Form.M1rowno3,formInfo["M1rowno3"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1face_no3"),
					DataFormatUtil.GetFormatItem(tj110f01M1Form.M1face_no3,formInfo["M1face_no3"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1tana_dan3"),
					DataFormatUtil.GetFormatItem(tj110f01M1Form.M1tana_dan3,formInfo["M1tana_dan3"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1selectorcheckbox3"),
					DataFormatUtil.GetFormatItem(tj110f01M1Form.M1selectorcheckbox3,formInfo["M1selectorcheckbox3"]));
				((System.Web.UI.WebControls.CheckBox)M1.Items[index].FindControl("M1selectorcheckbox3")).Text =
					formResource.GetString("M1selectorcheckbox3", lang);
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1entersyoriflg3"),
					DataFormatUtil.GetFormatItem(tj110f01M1Form.M1entersyoriflg3,formInfo["M1entersyoriflg3"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1dtlirokbn3"),
					DataFormatUtil.GetFormatItem(tj110f01M1Form.M1dtlirokbn3,formInfo["M1dtlirokbn3"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1rowno4"),
					DataFormatUtil.GetFormatItem(tj110f01M1Form.M1rowno4,formInfo["M1rowno4"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1face_no4"),
					DataFormatUtil.GetFormatItem(tj110f01M1Form.M1face_no4,formInfo["M1face_no4"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1tana_dan4"),
					DataFormatUtil.GetFormatItem(tj110f01M1Form.M1tana_dan4,formInfo["M1tana_dan4"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1selectorcheckbox4"),
					DataFormatUtil.GetFormatItem(tj110f01M1Form.M1selectorcheckbox4,formInfo["M1selectorcheckbox4"]));
				((System.Web.UI.WebControls.CheckBox)M1.Items[index].FindControl("M1selectorcheckbox4")).Text =
					formResource.GetString("M1selectorcheckbox4", lang);
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1entersyoriflg4"),
					DataFormatUtil.GetFormatItem(tj110f01M1Form.M1entersyoriflg4,formInfo["M1entersyoriflg4"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1dtlirokbn4"),
					DataFormatUtil.GetFormatItem(tj110f01M1Form.M1dtlirokbn4,formInfo["M1dtlirokbn4"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1rowno5"),
					DataFormatUtil.GetFormatItem(tj110f01M1Form.M1rowno5,formInfo["M1rowno5"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1face_no5"),
					DataFormatUtil.GetFormatItem(tj110f01M1Form.M1face_no5,formInfo["M1face_no5"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1tana_dan5"),
					DataFormatUtil.GetFormatItem(tj110f01M1Form.M1tana_dan5,formInfo["M1tana_dan5"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1selectorcheckbox5"),
					DataFormatUtil.GetFormatItem(tj110f01M1Form.M1selectorcheckbox5,formInfo["M1selectorcheckbox5"]));
				((System.Web.UI.WebControls.CheckBox)M1.Items[index].FindControl("M1selectorcheckbox5")).Text =
					formResource.GetString("M1selectorcheckbox5", lang);
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1entersyoriflg5"),
					DataFormatUtil.GetFormatItem(tj110f01M1Form.M1entersyoriflg5,formInfo["M1entersyoriflg5"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1dtlirokbn5"),
					DataFormatUtil.GetFormatItem(tj110f01M1Form.M1dtlirokbn5,formInfo["M1dtlirokbn5"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1rowno6"),
					DataFormatUtil.GetFormatItem(tj110f01M1Form.M1rowno6,formInfo["M1rowno6"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1face_no6"),
					DataFormatUtil.GetFormatItem(tj110f01M1Form.M1face_no6,formInfo["M1face_no6"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1tana_dan6"),
					DataFormatUtil.GetFormatItem(tj110f01M1Form.M1tana_dan6,formInfo["M1tana_dan6"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1selectorcheckbox6"),
					DataFormatUtil.GetFormatItem(tj110f01M1Form.M1selectorcheckbox6,formInfo["M1selectorcheckbox6"]));
				((System.Web.UI.WebControls.CheckBox)M1.Items[index].FindControl("M1selectorcheckbox6")).Text =
					formResource.GetString("M1selectorcheckbox6", lang);
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1entersyoriflg6"),
					DataFormatUtil.GetFormatItem(tj110f01M1Form.M1entersyoriflg6,formInfo["M1entersyoriflg6"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1dtlirokbn6"),
					DataFormatUtil.GetFormatItem(tj110f01M1Form.M1dtlirokbn6,formInfo["M1dtlirokbn6"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1rowno7"),
					DataFormatUtil.GetFormatItem(tj110f01M1Form.M1rowno7,formInfo["M1rowno7"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1face_no7"),
					DataFormatUtil.GetFormatItem(tj110f01M1Form.M1face_no7,formInfo["M1face_no7"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1tana_dan7"),
					DataFormatUtil.GetFormatItem(tj110f01M1Form.M1tana_dan7,formInfo["M1tana_dan7"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1selectorcheckbox7"),
					DataFormatUtil.GetFormatItem(tj110f01M1Form.M1selectorcheckbox7,formInfo["M1selectorcheckbox7"]));
				((System.Web.UI.WebControls.CheckBox)M1.Items[index].FindControl("M1selectorcheckbox7")).Text =
					formResource.GetString("M1selectorcheckbox7", lang);
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1entersyoriflg7"),
					DataFormatUtil.GetFormatItem(tj110f01M1Form.M1entersyoriflg7,formInfo["M1entersyoriflg7"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1dtlirokbn7"),
					DataFormatUtil.GetFormatItem(tj110f01M1Form.M1dtlirokbn7,formInfo["M1dtlirokbn7"]));

				if(!base.CheckUseSelfCustomize()){
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
				// (M1.HeaderRow.FindControl("M1selectorcheckbox") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1selectorcheckbox", lang), base.GetPageContext().FormInfo["M1selectorcheckbox"]);
				// (M1.HeaderRow.FindControl("M1entersyoriflg") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1entersyoriflg", lang), base.GetPageContext().FormInfo["M1entersyoriflg"]);
				// (M1.HeaderRow.FindControl("M1dtlirokbn") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1dtlirokbn", lang), base.GetPageContext().FormInfo["M1dtlirokbn"]);
				// (M1.HeaderRow.FindControl("M1rowno2") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1rowno2", lang), base.GetPageContext().FormInfo["M1rowno2"]);
				// (M1.HeaderRow.FindControl("M1face_no2") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1face_no2", lang), base.GetPageContext().FormInfo["M1face_no2"]);
				// (M1.HeaderRow.FindControl("M1tana_dan2") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tana_dan2", lang), base.GetPageContext().FormInfo["M1tana_dan2"]);
				// (M1.HeaderRow.FindControl("M1selectorcheckbox2") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1selectorcheckbox2", lang), base.GetPageContext().FormInfo["M1selectorcheckbox2"]);
				// (M1.HeaderRow.FindControl("M1entersyoriflg2") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1entersyoriflg2", lang), base.GetPageContext().FormInfo["M1entersyoriflg2"]);
				// (M1.HeaderRow.FindControl("M1dtlirokbn2") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1dtlirokbn2", lang), base.GetPageContext().FormInfo["M1dtlirokbn2"]);
				// (M1.HeaderRow.FindControl("M1rowno3") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1rowno3", lang), base.GetPageContext().FormInfo["M1rowno3"]);
				// (M1.HeaderRow.FindControl("M1face_no3") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1face_no3", lang), base.GetPageContext().FormInfo["M1face_no3"]);
				// (M1.HeaderRow.FindControl("M1tana_dan3") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tana_dan3", lang), base.GetPageContext().FormInfo["M1tana_dan3"]);
				// (M1.HeaderRow.FindControl("M1selectorcheckbox3") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1selectorcheckbox3", lang), base.GetPageContext().FormInfo["M1selectorcheckbox3"]);
				// (M1.HeaderRow.FindControl("M1entersyoriflg3") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1entersyoriflg3", lang), base.GetPageContext().FormInfo["M1entersyoriflg3"]);
				// (M1.HeaderRow.FindControl("M1dtlirokbn3") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1dtlirokbn3", lang), base.GetPageContext().FormInfo["M1dtlirokbn3"]);
				// (M1.HeaderRow.FindControl("M1rowno4") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1rowno4", lang), base.GetPageContext().FormInfo["M1rowno4"]);
				// (M1.HeaderRow.FindControl("M1face_no4") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1face_no4", lang), base.GetPageContext().FormInfo["M1face_no4"]);
				// (M1.HeaderRow.FindControl("M1tana_dan4") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tana_dan4", lang), base.GetPageContext().FormInfo["M1tana_dan4"]);
				// (M1.HeaderRow.FindControl("M1selectorcheckbox4") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1selectorcheckbox4", lang), base.GetPageContext().FormInfo["M1selectorcheckbox4"]);
				// (M1.HeaderRow.FindControl("M1entersyoriflg4") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1entersyoriflg4", lang), base.GetPageContext().FormInfo["M1entersyoriflg4"]);
				// (M1.HeaderRow.FindControl("M1dtlirokbn4") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1dtlirokbn4", lang), base.GetPageContext().FormInfo["M1dtlirokbn4"]);
				// (M1.HeaderRow.FindControl("M1rowno5") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1rowno5", lang), base.GetPageContext().FormInfo["M1rowno5"]);
				// (M1.HeaderRow.FindControl("M1face_no5") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1face_no5", lang), base.GetPageContext().FormInfo["M1face_no5"]);
				// (M1.HeaderRow.FindControl("M1tana_dan5") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tana_dan5", lang), base.GetPageContext().FormInfo["M1tana_dan5"]);
				// (M1.HeaderRow.FindControl("M1selectorcheckbox5") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1selectorcheckbox5", lang), base.GetPageContext().FormInfo["M1selectorcheckbox5"]);
				// (M1.HeaderRow.FindControl("M1entersyoriflg5") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1entersyoriflg5", lang), base.GetPageContext().FormInfo["M1entersyoriflg5"]);
				// (M1.HeaderRow.FindControl("M1dtlirokbn5") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1dtlirokbn5", lang), base.GetPageContext().FormInfo["M1dtlirokbn5"]);
				// (M1.HeaderRow.FindControl("M1rowno6") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1rowno6", lang), base.GetPageContext().FormInfo["M1rowno6"]);
				// (M1.HeaderRow.FindControl("M1face_no6") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1face_no6", lang), base.GetPageContext().FormInfo["M1face_no6"]);
				// (M1.HeaderRow.FindControl("M1tana_dan6") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tana_dan6", lang), base.GetPageContext().FormInfo["M1tana_dan6"]);
				// (M1.HeaderRow.FindControl("M1selectorcheckbox6") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1selectorcheckbox6", lang), base.GetPageContext().FormInfo["M1selectorcheckbox6"]);
				// (M1.HeaderRow.FindControl("M1entersyoriflg6") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1entersyoriflg6", lang), base.GetPageContext().FormInfo["M1entersyoriflg6"]);
				// (M1.HeaderRow.FindControl("M1dtlirokbn6") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1dtlirokbn6", lang), base.GetPageContext().FormInfo["M1dtlirokbn6"]);
				// (M1.HeaderRow.FindControl("M1rowno7") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1rowno7", lang), base.GetPageContext().FormInfo["M1rowno7"]);
				// (M1.HeaderRow.FindControl("M1face_no7") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1face_no7", lang), base.GetPageContext().FormInfo["M1face_no7"]);
				// (M1.HeaderRow.FindControl("M1tana_dan7") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tana_dan7", lang), base.GetPageContext().FormInfo["M1tana_dan7"]);
				// (M1.HeaderRow.FindControl("M1selectorcheckbox7") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1selectorcheckbox7", lang), base.GetPageContext().FormInfo["M1selectorcheckbox7"]);
				// (M1.HeaderRow.FindControl("M1entersyoriflg7") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1entersyoriflg7", lang), base.GetPageContext().FormInfo["M1entersyoriflg7"]);
				// (M1.HeaderRow.FindControl("M1dtlirokbn7") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1dtlirokbn7", lang), base.GetPageContext().FormInfo["M1dtlirokbn7"]);
				// }

		}
		#endregion

		#region M1明細のページャーを表示する
		/// <summary>
		/// M1明細のページャーを表示する。
		/// </summary>
		/// <param name="tj110f01Form">画面FormVO</param>
		private void RenderM1Pager(Tj110f01Form tj110f01Form)
		{
			Pgr.VirtualItemCount = tj110f01Form.GetList("M1").RecordCount;
			Pgr.CurrentPageIndex = tj110f01Form.GetList("M1").PageNo - 1;
			Pgr.PageSize = tj110f01Form.GetList("M1").DispRow;
		}
		#endregion
		#endregion

		#region カードデータを表示する
		/// <summary>
		/// カードデータを表示する
		/// </summary>
		/// <param name="tj110f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderCard(
			Tj110f01Form tj110f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			
			ControlUtil.SetControlValue(Head_tenpo_cd,
				DataFormatUtil.GetFormatItem(tj110f01Form.Head_tenpo_cd,formInfo["Head_tenpo_cd"]));
			ControlUtil.SetControlValue(Head_tenpo_nm,
				DataFormatUtil.GetFormatItem(tj110f01Form.Head_tenpo_nm,formInfo["Head_tenpo_nm"]));
			ControlUtil.SetControlValue(Torimore_ketsuban,
				DataFormatUtil.GetFormatItem(tj110f01Form.Torimore_ketsuban,formInfo["Torimore_ketsuban"]));
			ControlUtil.SetControlValue(Face_no_from,
				DataFormatUtil.GetFormatItem(tj110f01Form.Face_no_from,formInfo["Face_no_from"]));
			ControlUtil.SetControlValue(Face_no_to,
				DataFormatUtil.GetFormatItem(tj110f01Form.Face_no_to, formInfo["Face_no_to"]));
			ControlUtil.SetControlValue(Searchcnt,
				DataFormatUtil.GetFormatItem(tj110f01Form.Searchcnt, formInfo["Searchcnt"]));

			if(!base.CheckUseSelfCustomize()){
				Btnheadtenpocd.Value = base.FormResourceGetString(formResource, "Btnheadtenpocd", lang);
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
			if (!IsPostBack)
			{
				// に空白を設定
				Torimore_ketsuban.Items.Insert(0, new ListItem("", BoSystemConstant.DROPDOWNLIST_MISENTAKU));
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
			// UIScreenController controller = new UIScreenController((Tj110f01Form)base.GetPageContext().GetFormVO());
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

			// 明細制御

			if (M1.Items.Count > 0)
			{
				for (int index = 0; index < M1.Items.Count; index++)
				{
					// 選択を使用不可とする。
					TextBox row1 = (TextBox)(M1.Items[index].FindControl("M1rowno"));
					if (String.IsNullOrEmpty(row1.Text.Trim()))
					{
						((AdvancedCheckBox)M1.Items[index].FindControl("M1selectorcheckbox")).Visible = false;
					}

					// 選択を使用不可とする。
					TextBox row2 = (TextBox)(M1.Items[index].FindControl("M1rowno2"));
					if (String.IsNullOrEmpty(row2.Text.Trim()))
					{
						((AdvancedCheckBox)M1.Items[index].FindControl("M1selectorcheckbox2")).Visible = false;
					}

					// 選択を使用不可とする。
					TextBox row3 = (TextBox)(M1.Items[index].FindControl("M1rowno3"));
					if (String.IsNullOrEmpty(row3.Text.Trim()))
					{
						((AdvancedCheckBox)M1.Items[index].FindControl("M1selectorcheckbox3")).Visible = false;
					}

					// 選択を使用不可とする。
					TextBox row4 = (TextBox)(M1.Items[index].FindControl("M1rowno4"));
					if (String.IsNullOrEmpty(row4.Text.Trim()))
					{
						((AdvancedCheckBox)M1.Items[index].FindControl("M1selectorcheckbox4")).Visible = false;
					}

					// 選択を使用不可とする。
					TextBox row5 = (TextBox)(M1.Items[index].FindControl("M1rowno5"));
					if (String.IsNullOrEmpty(row5.Text.Trim()))
					{
						((AdvancedCheckBox)M1.Items[index].FindControl("M1selectorcheckbox5")).Visible = false;
					}

					// 選択を使用不可とする。
					TextBox row6 = (TextBox)(M1.Items[index].FindControl("M1rowno6"));
					if (String.IsNullOrEmpty(row6.Text.Trim()))
					{
						((AdvancedCheckBox)M1.Items[index].FindControl("M1selectorcheckbox6")).Visible = false;
					}

					// 選択を使用不可とする。
					TextBox row7 = (TextBox)(M1.Items[index].FindControl("M1rowno7"));
					if (String.IsNullOrEmpty(row7.Text.Trim()))
					{
						((AdvancedCheckBox)M1.Items[index].FindControl("M1selectorcheckbox7")).Visible = false;
					}
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
			ControlUtil.SetControlValue(Torimore_ketsuban_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Torimore_ketsuban", lang), base.GetPageContext().FormInfo["Torimore_ketsuban"]));
				DataFormatUtil.SetMustColorCaption(Torimore_ketsuban_lbl, base.GetPageContext().FormInfo["Torimore_ketsuban"]);
//			ControlUtil.SetControlValue(Face_no_from_lbl, 
//				DataFormatUtil.GetFormatCaption(formResource.GetString("Face_no_from", lang), base.GetPageContext().FormInfo["Face_no_from"]));
//				DataFormatUtil.SetMustColorCaption(Face_no_from_lbl, base.GetPageContext().FormInfo["Face_no_from"]);
			ControlUtil.SetControlValue(Face_no_from_lbl,"フェイスNo");
			ControlUtil.SetControlValue(Face_no_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Face_no_to", lang), base.GetPageContext().FormInfo["Face_no_to"]));
				DataFormatUtil.SetMustColorCaption(Face_no_to_lbl, base.GetPageContext().FormInfo["Face_no_to"]);
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
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1selectorcheckbox", lang), base.GetPageContext().FormInfo["M1selectorcheckbox"]);
				// M1.Columns[4].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1entersyoriflg", lang), base.GetPageContext().FormInfo["M1entersyoriflg"]);
				// M1.Columns[5].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1dtlirokbn", lang), base.GetPageContext().FormInfo["M1dtlirokbn"]);
				// M1.Columns[6].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1rowno2", lang), base.GetPageContext().FormInfo["M1rowno2"]);
				// M1.Columns[7].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1face_no2", lang), base.GetPageContext().FormInfo["M1face_no2"]);
				// M1.Columns[8].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tana_dan2", lang), base.GetPageContext().FormInfo["M1tana_dan2"]);
				// M1.Columns[9].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1selectorcheckbox2", lang), base.GetPageContext().FormInfo["M1selectorcheckbox2"]);
				// M1.Columns[10].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1entersyoriflg2", lang), base.GetPageContext().FormInfo["M1entersyoriflg2"]);
				// M1.Columns[11].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1dtlirokbn2", lang), base.GetPageContext().FormInfo["M1dtlirokbn2"]);
				// M1.Columns[12].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1rowno3", lang), base.GetPageContext().FormInfo["M1rowno3"]);
				// M1.Columns[13].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1face_no3", lang), base.GetPageContext().FormInfo["M1face_no3"]);
				// M1.Columns[14].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tana_dan3", lang), base.GetPageContext().FormInfo["M1tana_dan3"]);
				// M1.Columns[15].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1selectorcheckbox3", lang), base.GetPageContext().FormInfo["M1selectorcheckbox3"]);
				// M1.Columns[16].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1entersyoriflg3", lang), base.GetPageContext().FormInfo["M1entersyoriflg3"]);
				// M1.Columns[17].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1dtlirokbn3", lang), base.GetPageContext().FormInfo["M1dtlirokbn3"]);
				// M1.Columns[18].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1rowno4", lang), base.GetPageContext().FormInfo["M1rowno4"]);
				// M1.Columns[19].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1face_no4", lang), base.GetPageContext().FormInfo["M1face_no4"]);
				// M1.Columns[20].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tana_dan4", lang), base.GetPageContext().FormInfo["M1tana_dan4"]);
				// M1.Columns[21].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1selectorcheckbox4", lang), base.GetPageContext().FormInfo["M1selectorcheckbox4"]);
				// M1.Columns[22].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1entersyoriflg4", lang), base.GetPageContext().FormInfo["M1entersyoriflg4"]);
				// M1.Columns[23].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1dtlirokbn4", lang), base.GetPageContext().FormInfo["M1dtlirokbn4"]);
				// M1.Columns[24].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1rowno5", lang), base.GetPageContext().FormInfo["M1rowno5"]);
				// M1.Columns[25].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1face_no5", lang), base.GetPageContext().FormInfo["M1face_no5"]);
				// M1.Columns[26].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tana_dan5", lang), base.GetPageContext().FormInfo["M1tana_dan5"]);
				// M1.Columns[27].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1selectorcheckbox5", lang), base.GetPageContext().FormInfo["M1selectorcheckbox5"]);
				// M1.Columns[28].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1entersyoriflg5", lang), base.GetPageContext().FormInfo["M1entersyoriflg5"]);
				// M1.Columns[29].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1dtlirokbn5", lang), base.GetPageContext().FormInfo["M1dtlirokbn5"]);
				// M1.Columns[30].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1rowno6", lang), base.GetPageContext().FormInfo["M1rowno6"]);
				// M1.Columns[31].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1face_no6", lang), base.GetPageContext().FormInfo["M1face_no6"]);
				// M1.Columns[32].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tana_dan6", lang), base.GetPageContext().FormInfo["M1tana_dan6"]);
				// M1.Columns[33].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1selectorcheckbox6", lang), base.GetPageContext().FormInfo["M1selectorcheckbox6"]);
				// M1.Columns[34].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1entersyoriflg6", lang), base.GetPageContext().FormInfo["M1entersyoriflg6"]);
				// M1.Columns[35].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1dtlirokbn6", lang), base.GetPageContext().FormInfo["M1dtlirokbn6"]);
				// M1.Columns[36].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1rowno7", lang), base.GetPageContext().FormInfo["M1rowno7"]);
				// M1.Columns[37].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1face_no7", lang), base.GetPageContext().FormInfo["M1face_no7"]);
				// M1.Columns[38].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tana_dan7", lang), base.GetPageContext().FormInfo["M1tana_dan7"]);
				// M1.Columns[39].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1selectorcheckbox7", lang), base.GetPageContext().FormInfo["M1selectorcheckbox7"]);
				// M1.Columns[40].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1entersyoriflg7", lang), base.GetPageContext().FormInfo["M1entersyoriflg7"]);
				// M1.Columns[41].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1dtlirokbn7", lang), base.GetPageContext().FormInfo["M1dtlirokbn7"]);
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
				Windowtitle.InnerText = formResource.GetString("Tj110f01_Titlebar", lang);
				header.FormName = formResource.GetString("Tj110f01_FormCaption", lang);
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
