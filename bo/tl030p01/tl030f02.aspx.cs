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
using Common.Business.C01000.C01014;
using Common.Business.C01000.C01015;
using Common.Business.C01000.C01016;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.StringUtil;
using Common.Conditions;
using Common.IntegrationMD.MDControl;
using Common.IntegrationMD.Util;
using Common.Standard.Base;
using Common.Standard.Message;
using Common.Standard.Util;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Drawing;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Tl030p01.Page
{
  /// <summary>
  /// Tl030f02のコードビハインドです。
  /// </summary>
  public partial class Tl030f02Page : StandardBasePage
	{

		#region メソッド

		#region ページデータをロードするメソッド
		/// <summary>
		/// Tl030f02画面データを作成する。
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
						pageContext.SetFormVO(new Tl030f02Form());
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
								new Tl030f02Facade().DoLoad(facadeContext);
								break;
						}
					}
					else
					{
						if (commandInfo.ActionMode.Equals("INI"))
						{
							// アコーディオンオープン
							AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_OPEN);
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
			
			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".Page_Load");
		}
		#endregion

		#region フォームを呼び出します(ボタンID : Btnback(戻る))
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnback(戻る))
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnBTNBACK_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnBTNBACK_FRM");
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
				new Tl030f02Facade().DoBTNBACK_FRM(facadeContext);
				
				
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

			// 選択された管理Noにフォーカス設定
			focusItem = "M1bumon_cd";
			focusMno = (string)((Tl030f02Form)pageContext.GetFormVO(Tl030p01Constant.PGID, Tl030p01Constant.FORMID_02)).Dictionary[Tl030p01Constant.DIC_M1SELCETROWIDX];

			// フォーカス設定
			SetFocusCls.SetFocus(queryList, focusItem, focusMno);

			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNBACK_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Btnzensyonin())
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnzensyonin())
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnBTNZENSYONIN_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnBTNZENSYONIN_FRM");
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
				new Tl030f02Facade().DoBTNZENSYONIN_FRM(facadeContext);
				
				
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
			EndMethod(sender, e, this.GetType().Name + ".OnBTNZENSYONIN_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Btnzenkyakka())
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnzenkyakka())
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnBTNZENKYAKKA_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnBTNZENKYAKKA_FRM");
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
				new Tl030f02Facade().DoBTNZENKYAKKA_FRM(facadeContext);
				
				
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
			EndMethod(sender, e, this.GetType().Name + ".OnBTNZENKYAKKA_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Btnzenbaihen())
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnzenbaihen())
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnBTNZENBAIHEN_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnBTNZENBAIHEN_FRM");
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
				new Tl030f02Facade().DoBTNZENBAIHEN_FRM(facadeContext);
				
				
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
			EndMethod(sender, e, this.GetType().Name + ".OnBTNZENBAIHEN_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Btnzenentyo())
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnzenentyo())
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnBTNZENENTYO_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnBTNZENENTYO_FRM");
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
				new Tl030f02Facade().DoBTNZENENTYO_FRM(facadeContext);
				
				
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
			EndMethod(sender, e, this.GetType().Name + ".OnBTNZENENTYO_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region M1明細部のページング処理を実行します。(ボタンID : Pgr(ページャ))
		/// <summary>
		/// M1明細部のページング処理を実行します。
		/// ボタンID(Pgr(ページャ))
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
				new Tl030f02Facade().DoPGR_PGN(facadeContext, pageindex);
				
				
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

				// 警告メッセージ判定
				if (this.Request[BoSystemConstant.WARNING_HDNITEM_NM] != null)
				{
					facadeContext.SetUserObject(BoSystemConstant.WARNING_FCD_KEY, BoSystemString.Nvl(this.Request[BoSystemConstant.WARNING_HDNITEM_NM], "0"));
				}

				new Tl030f02Facade().DoBTNENTER_FRM(facadeContext);

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

			// 選択された管理Noにフォーカス設定
			focusItem = "M1bumon_cd";
			focusMno = (string)((Tl030f02Form)pageContext.GetFormVO(Tl030p01Constant.PGID, Tl030p01Constant.FORMID_02)).Dictionary[Tl030p01Constant.DIC_M1SELCETROWIDX];

			// フォーカス設定
			SetFocusCls.SetFocus(queryList, focusItem, focusMno);
			
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
					if (!MessageDisplayUtil.HasError(pageContext))
					{
						string lang = WebSettingsUtil.GetLangSettingFromSession(pageContext.Session);
						FormResource formResource =
							ResourceFactory.GetFormResource(pageContext.CommandInfo.FormId);
			
						//標題をセットする
						SetCaption(formResource, lang);

						//FormVOを取得する
						Tl030f02Form tl030f02Form = (Tl030f02Form)pageContext.GetFormVO();

						//明細ページ情報を表示する
						ShowListPageInfo(tl030f02Form);
			
						//明細部データを表示する
						RenderList(tl030f02Form, pageContext.FormInfo, formResource, lang);

						//カード部データを表示する
						RenderCard(tl030f02Form, pageContext.FormInfo, formResource, lang);
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
		/// <param name="tl030f02Form">画面FormVO</param>
		private void ShowListPageInfo(Tl030f02Form tl030f02Form)
		{
			//M1明細ページ情報を表示する。
			ShowM1ListPageInfo(tl030f02Form.GetList("M1"));

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
		/// <param name="tl030f02Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderList(
			Tl030f02Form tl030f02Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//画面のM1明細部データを設定する。
			RenderM1List(tl030f02Form, formInfo, formResource, lang);
			//M1明細部のページャーにページ情報を設定する。
			RenderM1Pager(tl030f02Form);
			
		}
		#endregion

		#region M1明細データを表示する
		/// <summary>
		/// M1明細データを表示する。
		/// </summary>
		/// <param name="tl030f02Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderM1List(
			Tl030f02Form tl030f02Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//M1明細部データソースを設定する。
			M1.DataSource = tl030f02Form.GetPageViewList("M1");
			M1.DataBind();

			//M1明細部データをフォーマットする。
			IList m1DataList = (IList)M1.DataSource;
			
			for (int index = 0; index < M1.Items.Count; index++)
			{
				Tl030f02M1Form tl030f02M1Form = (Tl030f02M1Form)m1DataList[index];
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1rowno"),
					DataFormatUtil.GetFormatItem(tl030f02M1Form.M1rowno,formInfo["M1rowno"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1hinsyu_ryaku_nm"),
					DataFormatUtil.GetFormatItem(tl030f02M1Form.M1hinsyu_ryaku_nm,formInfo["M1hinsyu_ryaku_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1burando_nm"),
					DataFormatUtil.GetFormatItem(tl030f02M1Form.M1burando_nm,formInfo["M1burando_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1jisya_hbn"),
					DataFormatUtil.GetFormatItem(tl030f02M1Form.M1jisya_hbn,formInfo["M1jisya_hbn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1maker_hbn"),
					DataFormatUtil.GetFormatItem(tl030f02M1Form.M1maker_hbn,formInfo["M1maker_hbn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1syonmk"),
					DataFormatUtil.GetFormatItem(tl030f02M1Form.M1syonmk,formInfo["M1syonmk"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1iro_nm"),
					DataFormatUtil.GetFormatItem(tl030f02M1Form.M1iro_nm,formInfo["M1iro_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1season_kb"),
					DataFormatUtil.GetFormatItem(tl030f02M1Form.M1season_kb,formInfo["M1season_kb"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1hanbaikanryo_ymd"),
					DataFormatUtil.GetFormatItem(tl030f02M1Form.M1hanbaikanryo_ymd,formInfo["M1hanbaikanryo_ymd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1mtobaika_tnk"),
					DataFormatUtil.GetFormatItem(tl030f02M1Form.M1mtobaika_tnk,formInfo["M1mtobaika_tnk"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1gen_tnk"),
					DataFormatUtil.GetFormatItem(tl030f02M1Form.M1gen_tnk,formInfo["M1gen_tnk"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1yobobaika_tnk"),
					DataFormatUtil.GetFormatItem(tl030f02M1Form.M1yobobaika_tnk,formInfo["M1yobobaika_tnk"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1kakuteibaika_tnk"),
					DataFormatUtil.GetFormatItem(tl030f02M1Form.M1kakuteibaika_tnk,formInfo["M1kakuteibaika_tnk"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1neire_rtu_genko"),
					DataFormatUtil.GetFormatItem(tl030f02M1Form.M1neire_rtu_genko,formInfo["M1neire_rtu_genko"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1neire_rtu_baihengo"),
					DataFormatUtil.GetFormatItem(tl030f02M1Form.M1neire_rtu_baihengo,formInfo["M1neire_rtu_baihengo"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1zaiko_su"),
					DataFormatUtil.GetFormatItem(tl030f02M1Form.M1zaiko_su,formInfo["M1zaiko_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1uriage_su"),
					DataFormatUtil.GetFormatItem(tl030f02M1Form.M1uriage_su,formInfo["M1uriage_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1syonin_flg"),
					DataFormatUtil.GetFormatItem(tl030f02M1Form.M1syonin_flg,formInfo["M1syonin_flg"]));
				((System.Web.UI.WebControls.CheckBox)M1.Items[index].FindControl("M1syonin_flg")).Text =
					formResource.GetString("M1syonin_flg", lang);
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1kyakka_flg"),
					DataFormatUtil.GetFormatItem(tl030f02M1Form.M1kyakka_flg,formInfo["M1kyakka_flg"]));
				((System.Web.UI.WebControls.CheckBox)M1.Items[index].FindControl("M1kyakka_flg")).Text =
					formResource.GetString("M1kyakka_flg", lang);
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1selectorcheckbox"),
					DataFormatUtil.GetFormatItem(tl030f02M1Form.M1selectorcheckbox,formInfo["M1selectorcheckbox"]));
				((System.Web.UI.WebControls.CheckBox)M1.Items[index].FindControl("M1selectorcheckbox")).Text =
					formResource.GetString("M1selectorcheckbox", lang);
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1entersyoriflg"),
					DataFormatUtil.GetFormatItem(tl030f02M1Form.M1entersyoriflg,formInfo["M1entersyoriflg"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1dtlirokbn"),
					DataFormatUtil.GetFormatItem(tl030f02M1Form.M1dtlirokbn,formInfo["M1dtlirokbn"]));

				if(!base.CheckUseSelfCustomize()){
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
				// (M1.HeaderRow.FindControl("M1hinsyu_ryaku_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hinsyu_ryaku_nm", lang), base.GetPageContext().FormInfo["M1hinsyu_ryaku_nm"]);
				// (M1.HeaderRow.FindControl("M1burando_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1burando_nm", lang), base.GetPageContext().FormInfo["M1burando_nm"]);
				// (M1.HeaderRow.FindControl("M1jisya_hbn") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1jisya_hbn", lang), base.GetPageContext().FormInfo["M1jisya_hbn"]);
				// (M1.HeaderRow.FindControl("M1maker_hbn") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1maker_hbn", lang), base.GetPageContext().FormInfo["M1maker_hbn"]);
				// (M1.HeaderRow.FindControl("M1syonmk") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syonmk", lang), base.GetPageContext().FormInfo["M1syonmk"]);
				// (M1.HeaderRow.FindControl("M1iro_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1iro_nm", lang), base.GetPageContext().FormInfo["M1iro_nm"]);
				// (M1.HeaderRow.FindControl("M1season_kb") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1season_kb", lang), base.GetPageContext().FormInfo["M1season_kb"]);
				// (M1.HeaderRow.FindControl("M1hanbaikanryo_ymd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hanbaikanryo_ymd", lang), base.GetPageContext().FormInfo["M1hanbaikanryo_ymd"]);
				// (M1.HeaderRow.FindControl("M1mtobaika_tnk") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1mtobaika_tnk", lang), base.GetPageContext().FormInfo["M1mtobaika_tnk"]);
				// (M1.HeaderRow.FindControl("M1gen_tnk") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1gen_tnk", lang), base.GetPageContext().FormInfo["M1gen_tnk"]);
				// (M1.HeaderRow.FindControl("M1yobobaika_tnk") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1yobobaika_tnk", lang), base.GetPageContext().FormInfo["M1yobobaika_tnk"]);
				// (M1.HeaderRow.FindControl("M1kakuteibaika_tnk") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kakuteibaika_tnk", lang), base.GetPageContext().FormInfo["M1kakuteibaika_tnk"]);
				// (M1.HeaderRow.FindControl("M1neire_rtu_genko") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1neire_rtu_genko", lang), base.GetPageContext().FormInfo["M1neire_rtu_genko"]);
				// (M1.HeaderRow.FindControl("M1neire_rtu_baihengo") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1neire_rtu_baihengo", lang), base.GetPageContext().FormInfo["M1neire_rtu_baihengo"]);
				// (M1.HeaderRow.FindControl("M1zaiko_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1zaiko_su", lang), base.GetPageContext().FormInfo["M1zaiko_su"]);
				// (M1.HeaderRow.FindControl("M1uriage_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1uriage_su", lang), base.GetPageContext().FormInfo["M1uriage_su"]);
				// (M1.HeaderRow.FindControl("M1syonin_flg") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syonin_flg", lang), base.GetPageContext().FormInfo["M1syonin_flg"]);
				// (M1.HeaderRow.FindControl("M1kyakka_flg") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kyakka_flg", lang), base.GetPageContext().FormInfo["M1kyakka_flg"]);
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
		/// <param name="tl030f02Form">画面FormVO</param>
		private void RenderM1Pager(Tl030f02Form tl030f02Form)
		{
			Pgr.VirtualItemCount = tl030f02Form.GetList("M1").RecordCount;
			Pgr.CurrentPageIndex = tl030f02Form.GetList("M1").PageNo - 1;
			Pgr.PageSize = tl030f02Form.GetList("M1").DispRow;
		}
		#endregion
		#endregion

		#region カードデータを表示する
		/// <summary>
		/// カードデータを表示する
		/// </summary>
		/// <param name="tl030f02Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderCard(
			Tl030f02Form tl030f02Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			
			ControlUtil.SetControlValue(Head_tenpo_cd,
				DataFormatUtil.GetFormatItem(tl030f02Form.Head_tenpo_cd,formInfo["Head_tenpo_cd"]));
			ControlUtil.SetControlValue(Head_tenpo_nm,
				DataFormatUtil.GetFormatItem(tl030f02Form.Head_tenpo_nm,formInfo["Head_tenpo_nm"]));
			ControlUtil.SetControlValue(Shinseimoto_nm,
				DataFormatUtil.GetFormatItem(tl030f02Form.Shinseimoto_nm,formInfo["Shinseimoto_nm"]));
			ControlUtil.SetControlValue(Sinseitan_cd,
				DataFormatUtil.GetFormatItem(tl030f02Form.Sinseitan_cd,formInfo["Sinseitan_cd"]));
			ControlUtil.SetControlValue(Sinseitan_nm,
				DataFormatUtil.GetFormatItem(tl030f02Form.Sinseitan_nm,formInfo["Sinseitan_nm"]));
			ControlUtil.SetControlValue(Bumon_cd,
				DataFormatUtil.GetFormatItem(tl030f02Form.Bumon_cd,formInfo["Bumon_cd"]));
			ControlUtil.SetControlValue(Bumon_nm,
				DataFormatUtil.GetFormatItem(tl030f02Form.Bumon_nm,formInfo["Bumon_nm"]));
			ControlUtil.SetControlValue(Baihen_shiji_no,
				DataFormatUtil.GetFormatItem(tl030f02Form.Baihen_shiji_no,formInfo["Baihen_shiji_no"]));
			ControlUtil.SetControlValue(Baihen_riyu_nm,
				DataFormatUtil.GetFormatItem(tl030f02Form.Baihen_riyu_nm,formInfo["Baihen_riyu_nm"]));
			ControlUtil.SetControlValue(Aihensagyokaisi_ymd,
				DataFormatUtil.GetFormatItem(tl030f02Form.Aihensagyokaisi_ymd,formInfo["Aihensagyokaisi_ymd"]));
			ControlUtil.SetControlValue(Baihenkaisi_ymd,
				DataFormatUtil.GetFormatItem(tl030f02Form.Baihenkaisi_ymd,formInfo["Baihenkaisi_ymd"]));

			if(!base.CheckUseSelfCustomize()){
				Btnback.Value = base.FormResourceGetString(formResource, "Btnback", lang);
				Btnzensyonin.Value = base.FormResourceGetString(formResource, "Btnzensyonin", lang);
				Btnzenkyakka.Value = base.FormResourceGetString(formResource, "Btnzenkyakka", lang);
				Btnzenbaihen.Value = base.FormResourceGetString(formResource, "Btnzenbaihen", lang);
				Btnzenentyo.Value = base.FormResourceGetString(formResource, "Btnzenentyo", lang);
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
			// UIScreenController controller = new UIScreenController((Tl030f02Form)base.GetPageContext().GetFormVO());
			// controller.ChangeColumnsDisplayMode(M1 ,  new DetailHeaderFixedVO(M1Header , true) , null);

			/*
			 *登録した機能間連携処理を親画面に感知させる。
			 *機能有効させる場合は、コメントアウトを外してください。
			 */
			//DetailUtil.RunPgSyn(this,(StandardBaseForm)base.GetPageContext().GetFormVO());
			#region 画面表示制御
			Tl030f02Form formVo = (Tl030f02Form)base.GetPageContext().GetFormVO();
			IList m1DataList = formVo.GetPageViewList("M1");

			// 一覧画面の選択明細行情報取得
			Tl030f01M1Form prevM1Vo = (Tl030f01M1Form)formVo.Dictionary[Tl030p01Constant.DIC_M1SELCETVO];

			// [売変確定(X)-一覧画面(Dictionary)].[Ｍ１申請元区分]<>"1"の場合、非表示
			if (!ConditionSinseimoto.VALUE_SINSEIMOTO1.Equals(prevM1Vo.Dictionary[Tl030p01Constant.DIC_M1SINSEIMOTO_KBN].ToString()))
			{

				// 全承認ボタン、全却下ボタンを使用不可にする
				ControlCls.Visible(MeisaiBtnBaihenEntyo, false);

				// 明細ヘッダー部標題変更
				M1syonin_flg_lbl.Text = "承認";
				M1kyakka_flg_lbl.Text = "却下";

			}
			else if (ConditionSinseimoto.VALUE_SINSEIMOTO1.Equals(prevM1Vo.Dictionary[Tl030p01Constant.DIC_M1SINSEIMOTO_KBN].ToString()))
			{

				// 全売変ボタン、全延長ボタンを使用不可にする
				ControlCls.Visible(MeisaiBtnSyoninKyakka, false);

				// 明細の入力項目を使用不可にする
				for (int i = 0; i < M1.Items.Count; i++)
				{
					ControlCls.Disable(((MDTextBox)M1.Items[i].FindControl("M1kakuteibaika_tnk")), true);
				}

				// 明細ヘッダー部標題変更
				M1syonin_flg_lbl.Text = "売変";
				M1kyakka_flg_lbl.Text = "延長";

			}

			// システム日付取得
			String sysDateVO = formVo.Dictionary[Tl030p01Constant.DIC_SYSDATE].ToString();
			// 確定ボタン制御フラグ
			// 一行でもチェックボックスがチェック可能だった場合は確定ボタンを押下可能とする
			bool enterBtnDisableFlg = true;

			// 明細制御
			for (int i = 0; i < M1.Items.Count; i++)
			{
				Tl030f02M1Form f02m1VO = (Tl030f02M1Form)m1DataList[i];
				String kakuFlg = f02m1VO.Dictionary[Tl030p01Constant.DIC_M1ENTERSYORIFLG].ToString();

				// [売変確定(X)-一覧画面(Dictionary)].[Ｍ１申請元区分]="1"(本部)の場合
				if (ConditionSinseimoto.VALUE_SINSEIMOTO1.Equals(prevM1Vo.Dictionary[Tl030p01Constant.DIC_M1SINSEIMOTO_KBN].ToString()))
				{
					// Ｍ１承認状態

					// 作業開始日＜システム日付かつ、Ｍ１確定処理フラグ(隠し)="0"の場合チェック可能
					// 作業開始日、開始日を設定
					DateTime dtSagyokaisi_ymd;

					if (DateTime.TryParse(BoSystemFormat.formatDate(formVo.Aihensagyokaisi_ymd,1), out dtSagyokaisi_ymd))
					{
						if (dtSagyokaisi_ymd <= DateTime.Parse(BoSystemFormat.formatDate(sysDateVO,1))
							&& kakuFlg.Equals(ConditionKakuteisyori_flg.VALUE_NASI))
						{
							// チェック可能
						}
						else
						{
							// チェック不可
							ControlCls.Disable(((AdvancedCheckBox)M1.Items[i].FindControl("M1syonin_flg")), true);
						}
					}


					// Ｍ１却下フラグ
					// 開始日-1、開始日+2を取得
					DateTime kaisi_ymd;

					if (DateTime.TryParse(BoSystemFormat.formatDate(formVo.Baihenkaisi_ymd,1), out kaisi_ymd))
					{
						DateTime kaisi_ymd_bf = kaisi_ymd.AddDays(-1);
						DateTime kaisi_ymd_af = kaisi_ymd.AddDays(2);
						if (kaisi_ymd_bf <= DateTime.Parse(BoSystemFormat.formatDate(sysDateVO, 1)) && DateTime.Parse(BoSystemFormat.formatDate(sysDateVO, 1)) <= kaisi_ymd_af
							&& ConditionBaihen_riytu.VALUE_BAIHEN_RIYTU1.Equals(prevM1Vo.Dictionary[Tl030p01Constant.DIC_M1BAIHEN_RIYTU].ToString()))
						{
							// チェック可能
						}
						else
						{
							// チェック不可
							ControlCls.Disable(((AdvancedCheckBox)M1.Items[i].FindControl("M1kyakka_flg")), true);
						}				
					}
				}

				// 確定フラグが1の場合チェック不可
				if (kakuFlg.Equals(ConditionKakuteisyori_flg.VALUE_ARI))
				{
					// チェック不可
					ControlCls.Disable(((AdvancedCheckBox)M1.Items[i].FindControl("M1syonin_flg")), true);
					ControlCls.Disable(((AdvancedCheckBox)M1.Items[i].FindControl("M1kyakka_flg")), true);
					ControlCls.Disable(((MDTextBox)M1.Items[i].FindControl("M1kakuteibaika_tnk")), true);

				}

				// 本部、店舗共通
				// 旧自社品番のカラー管理商品の場合、最初の自社品番のみ変更可能とする
				if (("0").Equals(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1COLOR_TENKAI_BAIKA_KAHEN_FLG].ToString()))
				{
					// チェック不可
					ControlCls.Disable(((MDTextBox)M1.Items[i].FindControl("M1kakuteibaika_tnk")), true);
					ControlCls.Disable(((AdvancedCheckBox)M1.Items[i].FindControl("M1syonin_flg")), true);
					ControlCls.Disable(((AdvancedCheckBox)M1.Items[i].FindControl("M1kyakka_flg")), true);
				}

				// 旧自社品番のカラー管理商品の場合、文字色を赤にする
				decimal djisyaHbnCnt = Convert.ToDecimal(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1JISYA_HBN_KENSU].ToString()); 
				if (("1").Equals(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1JISYA_HBN_COLOR_TENKAI_FLG].ToString())
					&& djisyaHbnCnt >= 2)
				{
					((TextBox)M1.Items[i].FindControl("M1rowno")).ForeColor = Color.Red;
					((TextBox)M1.Items[i].FindControl("M1hinsyu_ryaku_nm")).ForeColor = Color.Red;
					((TextBox)M1.Items[i].FindControl("M1burando_nm")).ForeColor = Color.Red;
					((TextBox)M1.Items[i].FindControl("M1jisya_hbn")).ForeColor = Color.Red;
					((TextBox)M1.Items[i].FindControl("M1maker_hbn")).ForeColor = Color.Red;
					((TextBox)M1.Items[i].FindControl("M1syonmk")).ForeColor = Color.Red;
					((TextBox)M1.Items[i].FindControl("M1iro_nm")).ForeColor = Color.Red;
					((TextBox)M1.Items[i].FindControl("M1season_kb")).ForeColor = Color.Red;
					((TextBox)M1.Items[i].FindControl("M1hanbaikanryo_ymd")).ForeColor = Color.Red;
					((TextBox)M1.Items[i].FindControl("M1mtobaika_tnk")).ForeColor = Color.Red;
					((TextBox)M1.Items[i].FindControl("M1gen_tnk")).ForeColor = Color.Red;
					((TextBox)M1.Items[i].FindControl("M1yobobaika_tnk")).ForeColor = Color.Red;
					((MDTextBox)M1.Items[i].FindControl("M1kakuteibaika_tnk")).ForeColor = Color.Red;
					((TextBox)M1.Items[i].FindControl("M1neire_rtu_genko")).ForeColor = Color.Red;
					((TextBox)M1.Items[i].FindControl("M1neire_rtu_baihengo")).ForeColor = Color.Red;
					((TextBox)M1.Items[i].FindControl("M1zaiko_su")).ForeColor = Color.Red;
					((TextBox)M1.Items[i].FindControl("M1uriage_su")).ForeColor = Color.Red;
					((TextBox)M1.Items[i].FindControl("M1uriage_su")).ForeColor = Color.Red;

				}

				// 確定可能か判定
				AdvancedCheckBox syonin_flg = (AdvancedCheckBox)M1.Items[i].FindControl("M1syonin_flg");
				AdvancedCheckBox kyakka_flg = (AdvancedCheckBox)M1.Items[i].FindControl("M1kyakka_flg");

				if (syonin_flg.Enabled == true || kyakka_flg.Enabled == true)
				{
					// 確定ボタンを押下可能にする
					enterBtnDisableFlg = false;
				}
				else
				{
					// 処理なし
				}
			} //for

			// 確定ボタン使用制御
			ControlCls.Disable(Btnenter, enterBtnDisableFlg);


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
			ControlUtil.SetControlValue(Shinseimoto_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Shinseimoto_nm", lang), base.GetPageContext().FormInfo["Shinseimoto_nm"]));
				DataFormatUtil.SetMustColorCaption(Shinseimoto_nm_lbl, base.GetPageContext().FormInfo["Shinseimoto_nm"]);
			ControlUtil.SetControlValue(Sinseitan_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Sinseitan_cd", lang), base.GetPageContext().FormInfo["Sinseitan_cd"]));
				DataFormatUtil.SetMustColorCaption(Sinseitan_cd_lbl, base.GetPageContext().FormInfo["Sinseitan_cd"]);
			ControlUtil.SetControlValue(Sinseitan_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Sinseitan_nm", lang), base.GetPageContext().FormInfo["Sinseitan_nm"]));
				DataFormatUtil.SetMustColorCaption(Sinseitan_nm_lbl, base.GetPageContext().FormInfo["Sinseitan_nm"]);
			ControlUtil.SetControlValue(Bumon_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Bumon_cd", lang), base.GetPageContext().FormInfo["Bumon_cd"]));
				DataFormatUtil.SetMustColorCaption(Bumon_cd_lbl, base.GetPageContext().FormInfo["Bumon_cd"]);
			ControlUtil.SetControlValue(Bumon_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Bumon_nm", lang), base.GetPageContext().FormInfo["Bumon_nm"]));
				DataFormatUtil.SetMustColorCaption(Bumon_nm_lbl, base.GetPageContext().FormInfo["Bumon_nm"]);
			ControlUtil.SetControlValue(Baihen_shiji_no_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Baihen_shiji_no", lang), base.GetPageContext().FormInfo["Baihen_shiji_no"]));
				DataFormatUtil.SetMustColorCaption(Baihen_shiji_no_lbl, base.GetPageContext().FormInfo["Baihen_shiji_no"]);
			ControlUtil.SetControlValue(Baihen_riyu_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Baihen_riyu_nm", lang), base.GetPageContext().FormInfo["Baihen_riyu_nm"]));
				DataFormatUtil.SetMustColorCaption(Baihen_riyu_nm_lbl, base.GetPageContext().FormInfo["Baihen_riyu_nm"]);
			ControlUtil.SetControlValue(Aihensagyokaisi_ymd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Aihensagyokaisi_ymd", lang), base.GetPageContext().FormInfo["Aihensagyokaisi_ymd"]));
				DataFormatUtil.SetMustColorCaption(Aihensagyokaisi_ymd_lbl, base.GetPageContext().FormInfo["Aihensagyokaisi_ymd"]);
			ControlUtil.SetControlValue(Baihenkaisi_ymd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Baihenkaisi_ymd", lang), base.GetPageContext().FormInfo["Baihenkaisi_ymd"]));
				DataFormatUtil.SetMustColorCaption(Baihenkaisi_ymd_lbl, base.GetPageContext().FormInfo["Baihenkaisi_ymd"]);
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
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hinsyu_ryaku_nm", lang), base.GetPageContext().FormInfo["M1hinsyu_ryaku_nm"]);
				// M1.Columns[2].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1burando_nm", lang), base.GetPageContext().FormInfo["M1burando_nm"]);
				// M1.Columns[3].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1jisya_hbn", lang), base.GetPageContext().FormInfo["M1jisya_hbn"]);
				// M1.Columns[4].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1maker_hbn", lang), base.GetPageContext().FormInfo["M1maker_hbn"]);
				// M1.Columns[5].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syonmk", lang), base.GetPageContext().FormInfo["M1syonmk"]);
				// M1.Columns[6].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1iro_nm", lang), base.GetPageContext().FormInfo["M1iro_nm"]);
				// M1.Columns[7].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1season_kb", lang), base.GetPageContext().FormInfo["M1season_kb"]);
				// M1.Columns[8].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hanbaikanryo_ymd", lang), base.GetPageContext().FormInfo["M1hanbaikanryo_ymd"]);
				// M1.Columns[9].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1mtobaika_tnk", lang), base.GetPageContext().FormInfo["M1mtobaika_tnk"]);
				// M1.Columns[10].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1gen_tnk", lang), base.GetPageContext().FormInfo["M1gen_tnk"]);
				// M1.Columns[11].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1yobobaika_tnk", lang), base.GetPageContext().FormInfo["M1yobobaika_tnk"]);
				// M1.Columns[12].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kakuteibaika_tnk", lang), base.GetPageContext().FormInfo["M1kakuteibaika_tnk"]);
				// M1.Columns[13].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1neire_rtu_genko", lang), base.GetPageContext().FormInfo["M1neire_rtu_genko"]);
				// M1.Columns[14].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1neire_rtu_baihengo", lang), base.GetPageContext().FormInfo["M1neire_rtu_baihengo"]);
				// M1.Columns[15].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1zaiko_su", lang), base.GetPageContext().FormInfo["M1zaiko_su"]);
				// M1.Columns[16].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1uriage_su", lang), base.GetPageContext().FormInfo["M1uriage_su"]);
				// M1.Columns[17].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syonin_flg", lang), base.GetPageContext().FormInfo["M1syonin_flg"]);
				// M1.Columns[18].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kyakka_flg", lang), base.GetPageContext().FormInfo["M1kyakka_flg"]);
				// M1.Columns[19].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1selectorcheckbox", lang), base.GetPageContext().FormInfo["M1selectorcheckbox"]);
				// M1.Columns[20].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1entersyoriflg", lang), base.GetPageContext().FormInfo["M1entersyoriflg"]);
				// M1.Columns[21].HeaderText = 
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
				Windowtitle.InnerText = formResource.GetString("Tl030f02_Titlebar", lang);
				header.FormName = formResource.GetString("Tl030f02_FormCaption", lang);
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
