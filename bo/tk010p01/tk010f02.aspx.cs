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
using Common.Business.C01000.C01014;
using Common.Business.C01000.C01015;
using Common.Business.C01000.C01016;
using Common.Business.C99999.Constant;
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
using System.Web.UI.WebControls;

namespace com.xebio.bo.Tk010p01.Page
{
  /// <summary>
  /// Tk010f02のコードビハインドです。
  /// </summary>
  public partial class Tk010f02Page : StandardBasePage
	{

		#region メソッド

		#region ページデータをロードするメソッド
		/// <summary>
		/// Tk010f02画面データを作成する。
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
						pageContext.SetFormVO(new Tk010f02Form());
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
								new Tk010f02Facade().DoLoad(facadeContext);
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

		#region フォームを呼び出します(ボタンID : Btnback())
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnback())
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
				new Tk010f02Facade().DoBTNBACK_FRM(facadeContext);
				
				
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
			focusItem = "M1tenpo_cd";
			focusMno = (string)((Tk010f02Form)pageContext.GetFormVO(Tk010p01Constant.PGID, Tk010p01Constant.FORMID_02)).Dictionary[Tk010p01Constant.DIC_M1SELCETROWIDX];

			// フォーカス設定
			SetFocusCls.SetFocus(queryList, focusItem, focusMno);

			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNBACK_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Btnikkatsusyonin())
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnikkatsusyonin())
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnBTNIKKATSUSYONIN_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnBTNIKKATSUSYONIN_FRM");
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
				new Tk010f02Facade().DoBTNIKKATSUSYONIN_FRM(facadeContext);
				
				
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
			EndMethod(sender, e, this.GetType().Name + ".OnBTNIKKATSUSYONIN_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Btnikkatsukyakka())
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnikkatsukyakka())
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnBTNIKKATSUKYAKKA_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnBTNIKKATSUKYAKKA_FRM");
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
				new Tk010f02Facade().DoBTNIKKATSUKYAKKA_FRM(facadeContext);
				
				
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
			EndMethod(sender, e, this.GetType().Name + ".OnBTNIKKATSUKYAKKA_FRM");
			
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
				new Tk010f02Facade().DoBTNZENKJO_FRM(facadeContext);
				
				
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
				new Tk010f02Facade().DoPGR_PGN(facadeContext, pageindex);
				
				
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
				new Tk010f02Facade().DoBTNENTER_FRM(facadeContext);
				
				
				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
					// 明細エラー背景色対応 ----- START
					// base.SetError(pageContext);
					// 明細エラー背景色対応 ----- END
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
						Tk010f02Form tk010f02Form = (Tk010f02Form)pageContext.GetFormVO();

						//明細ページ情報を表示する
						ShowListPageInfo(tk010f02Form);
			
						//明細部データを表示する
						RenderList(tk010f02Form, pageContext.FormInfo, formResource, lang);

						//カード部データを表示する
						RenderCard(tk010f02Form, pageContext.FormInfo, formResource, lang);
					//}

					// 明細エラー背景色対応 ----- START
					//エラー判定
					if (MessageDisplayUtil.HasError(FacadeContextFactory.GetFacadeContext(base.GetPageContext())))
					{
						SetItems();
						SetAttribute();
						base.SetError(base.GetPageContext());
					}
					// 明細エラー背景色対応 ----- END
					
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
		/// <param name="tk010f02Form">画面FormVO</param>
		private void ShowListPageInfo(Tk010f02Form tk010f02Form)
		{
			//M1明細ページ情報を表示する。
			ShowM1ListPageInfo(tk010f02Form.GetList("M1"));

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
		/// <param name="tk010f02Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderList(
			Tk010f02Form tk010f02Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//画面のM1明細部データを設定する。
			RenderM1List(tk010f02Form, formInfo, formResource, lang);
			//M1明細部のページャーにページ情報を設定する。
			RenderM1Pager(tk010f02Form);
			
		}
		#endregion

		#region M1明細データを表示する
		/// <summary>
		/// M1明細データを表示する。
		/// </summary>
		/// <param name="tk010f02Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderM1List(
			Tk010f02Form tk010f02Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//M1明細部データソースを設定する。
			M1.DataSource = tk010f02Form.GetPageViewList("M1");
			M1.DataBind();

			//M1明細部データをフォーマットする。
			IList m1DataList = (IList)M1.DataSource;
			
			for (int index = 0; index < M1.Items.Count; index++)
			{
				Tk010f02M1Form tk010f02M1Form = (Tk010f02M1Form)m1DataList[index];
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1rowno"),
					DataFormatUtil.GetFormatItem(tk010f02M1Form.M1rowno,formInfo["M1rowno"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1bumon_cd"),
					DataFormatUtil.GetFormatItem(tk010f02M1Form.M1bumon_cd,formInfo["M1bumon_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1hinsyu_cd"),
					DataFormatUtil.GetFormatItem(tk010f02M1Form.M1hinsyu_cd,formInfo["M1hinsyu_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1burando_nm"),
					DataFormatUtil.GetFormatItem(tk010f02M1Form.M1burando_nm,formInfo["M1burando_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1jisya_hbn"),
					DataFormatUtil.GetFormatItem(tk010f02M1Form.M1jisya_hbn,formInfo["M1jisya_hbn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1hanbaikanryo_ymd"),
					DataFormatUtil.GetFormatItem(tk010f02M1Form.M1hanbaikanryo_ymd,formInfo["M1hanbaikanryo_ymd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1maker_hbn"),
					DataFormatUtil.GetFormatItem(tk010f02M1Form.M1maker_hbn,formInfo["M1maker_hbn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1syonmk"),
					DataFormatUtil.GetFormatItem(tk010f02M1Form.M1syonmk,formInfo["M1syonmk"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1scan_cd"),
					DataFormatUtil.GetFormatItem(tk010f02M1Form.M1scan_cd,formInfo["M1scan_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1iro_nm"),
					DataFormatUtil.GetFormatItem(tk010f02M1Form.M1iro_nm,formInfo["M1iro_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1size_nm"),
					DataFormatUtil.GetFormatItem(tk010f02M1Form.M1size_nm,formInfo["M1size_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1genbaika_tnk"),
					DataFormatUtil.GetFormatItem(tk010f02M1Form.M1genbaika_tnk,formInfo["M1genbaika_tnk"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1suryo"),
					DataFormatUtil.GetFormatItem(tk010f02M1Form.M1suryo,formInfo["M1suryo"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1gen_tnk"),
					DataFormatUtil.GetFormatItem(tk010f02M1Form.M1gen_tnk,formInfo["M1gen_tnk"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1genkakin"),
					DataFormatUtil.GetFormatItem(tk010f02M1Form.M1genkakin,formInfo["M1genkakin"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1nyuryoku_ymd"),
					DataFormatUtil.GetFormatItem(tk010f02M1Form.M1nyuryoku_ymd,formInfo["M1nyuryoku_ymd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1apply_ymd"),
					DataFormatUtil.GetFormatItem(tk010f02M1Form.M1apply_ymd,formInfo["M1apply_ymd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1nyuryokusha_cd"),
					DataFormatUtil.GetFormatItem(tk010f02M1Form.M1nyuryokusha_cd,formInfo["M1nyuryokusha_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1sinseisya_cd"),
					DataFormatUtil.GetFormatItem(tk010f02M1Form.M1sinseisya_cd,formInfo["M1sinseisya_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1hyokasonsyubetsu_kb"),
					DataFormatUtil.GetFormatItem(tk010f02M1Form.M1hyokasonsyubetsu_kb,formInfo["M1hyokasonsyubetsu_kb"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1hyokasonriyu_kb_keinen"),
					DataFormatUtil.GetFormatItem(tk010f02M1Form.M1hyokasonriyu_kb_keinen,formInfo["M1hyokasonriyu_kb_keinen"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1hyokasonriyu_kb"),
					DataFormatUtil.GetFormatItem(tk010f02M1Form.M1hyokasonriyu_kb,formInfo["M1hyokasonriyu_kb"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1hyokasonriyu"),
					DataFormatUtil.GetFormatItem(tk010f02M1Form.M1hyokasonriyu,formInfo["M1hyokasonriyu"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1kyakkariyu_kb"),
					DataFormatUtil.GetFormatItem(tk010f02M1Form.M1kyakkariyu_kb,formInfo["M1kyakkariyu_kb"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1kyakkariyu"),
					DataFormatUtil.GetFormatItem(tk010f02M1Form.M1kyakkariyu,formInfo["M1kyakkariyu"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1tyotatsu_nm"),
					DataFormatUtil.GetFormatItem(tk010f02M1Form.M1tyotatsu_nm,formInfo["M1tyotatsu_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1syonin_flg"),
					DataFormatUtil.GetFormatItem(tk010f02M1Form.M1syonin_flg,formInfo["M1syonin_flg"]));
				((System.Web.UI.WebControls.CheckBox)M1.Items[index].FindControl("M1syonin_flg")).Text =
					formResource.GetString("M1syonin_flg", lang);
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1kyakka_flg"),
					DataFormatUtil.GetFormatItem(tk010f02M1Form.M1kyakka_flg,formInfo["M1kyakka_flg"]));
				((System.Web.UI.WebControls.CheckBox)M1.Items[index].FindControl("M1kyakka_flg")).Text =
					formResource.GetString("M1kyakka_flg", lang);
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1hinsyu_ryaku_nm"),
					DataFormatUtil.GetFormatItem(tk010f02M1Form.M1hinsyu_ryaku_nm,formInfo["M1hinsyu_ryaku_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1bumon_nm"),
					DataFormatUtil.GetFormatItem(tk010f02M1Form.M1bumon_nm,formInfo["M1bumon_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1suryo_hdn"),
					DataFormatUtil.GetFormatItem(tk010f02M1Form.M1suryo_hdn,formInfo["M1suryo_hdn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1genkakin_hdn"),
					DataFormatUtil.GetFormatItem(tk010f02M1Form.M1genkakin_hdn,formInfo["M1genkakin_hdn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1selectorcheckbox"),
					DataFormatUtil.GetFormatItem(tk010f02M1Form.M1selectorcheckbox,formInfo["M1selectorcheckbox"]));
				((System.Web.UI.WebControls.CheckBox)M1.Items[index].FindControl("M1selectorcheckbox")).Text =
					formResource.GetString("M1selectorcheckbox", lang);
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1entersyoriflg"),
					DataFormatUtil.GetFormatItem(tk010f02M1Form.M1entersyoriflg,formInfo["M1entersyoriflg"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1dtlirokbn"),
					DataFormatUtil.GetFormatItem(tk010f02M1Form.M1dtlirokbn,formInfo["M1dtlirokbn"]));

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
				// (M1.HeaderRow.FindControl("M1bumon_cd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumon_cd", lang), base.GetPageContext().FormInfo["M1bumon_cd"]);
				// (M1.HeaderRow.FindControl("M1hinsyu_cd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hinsyu_cd", lang), base.GetPageContext().FormInfo["M1hinsyu_cd"]);
				// (M1.HeaderRow.FindControl("M1burando_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1burando_nm", lang), base.GetPageContext().FormInfo["M1burando_nm"]);
				// (M1.HeaderRow.FindControl("M1jisya_hbn") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1jisya_hbn", lang), base.GetPageContext().FormInfo["M1jisya_hbn"]);
				// (M1.HeaderRow.FindControl("M1hanbaikanryo_ymd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hanbaikanryo_ymd", lang), base.GetPageContext().FormInfo["M1hanbaikanryo_ymd"]);
				// (M1.HeaderRow.FindControl("M1maker_hbn") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1maker_hbn", lang), base.GetPageContext().FormInfo["M1maker_hbn"]);
				// (M1.HeaderRow.FindControl("M1syonmk") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syonmk", lang), base.GetPageContext().FormInfo["M1syonmk"]);
				// (M1.HeaderRow.FindControl("M1scan_cd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1scan_cd", lang), base.GetPageContext().FormInfo["M1scan_cd"]);
				// (M1.HeaderRow.FindControl("M1iro_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1iro_nm", lang), base.GetPageContext().FormInfo["M1iro_nm"]);
				// (M1.HeaderRow.FindControl("M1size_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1size_nm", lang), base.GetPageContext().FormInfo["M1size_nm"]);
				// (M1.HeaderRow.FindControl("M1genbaika_tnk") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1genbaika_tnk", lang), base.GetPageContext().FormInfo["M1genbaika_tnk"]);
				// (M1.HeaderRow.FindControl("M1suryo") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo", lang), base.GetPageContext().FormInfo["M1suryo"]);
				// (M1.HeaderRow.FindControl("M1gen_tnk") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1gen_tnk", lang), base.GetPageContext().FormInfo["M1gen_tnk"]);
				// (M1.HeaderRow.FindControl("M1genkakin") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1genkakin", lang), base.GetPageContext().FormInfo["M1genkakin"]);
				// (M1.HeaderRow.FindControl("M1nyuryoku_ymd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1nyuryoku_ymd", lang), base.GetPageContext().FormInfo["M1nyuryoku_ymd"]);
				// (M1.HeaderRow.FindControl("M1apply_ymd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1apply_ymd", lang), base.GetPageContext().FormInfo["M1apply_ymd"]);
				// (M1.HeaderRow.FindControl("M1nyuryokusha_cd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1nyuryokusha_cd", lang), base.GetPageContext().FormInfo["M1nyuryokusha_cd"]);
				// (M1.HeaderRow.FindControl("M1sinseisya_cd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1sinseisya_cd", lang), base.GetPageContext().FormInfo["M1sinseisya_cd"]);
				// (M1.HeaderRow.FindControl("M1hyokasonsyubetsu_kb") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hyokasonsyubetsu_kb", lang), base.GetPageContext().FormInfo["M1hyokasonsyubetsu_kb"]);
				// (M1.HeaderRow.FindControl("M1hyokasonriyu_kb") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hyokasonriyu_kb", lang), base.GetPageContext().FormInfo["M1hyokasonriyu_kb"]);
				// (M1.HeaderRow.FindControl("M1hyokasonriyu_kb_keinen") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hyokasonriyu_kb_keinen", lang), base.GetPageContext().FormInfo["M1hyokasonriyu_kb_keinen"]);
				// (M1.HeaderRow.FindControl("M1hyokasonriyu") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hyokasonriyu", lang), base.GetPageContext().FormInfo["M1hyokasonriyu"]);
				// (M1.HeaderRow.FindControl("M1kyakkariyu_kb") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kyakkariyu_kb", lang), base.GetPageContext().FormInfo["M1kyakkariyu_kb"]);
				// (M1.HeaderRow.FindControl("M1kyakkariyu") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kyakkariyu", lang), base.GetPageContext().FormInfo["M1kyakkariyu"]);
				// (M1.HeaderRow.FindControl("M1tyotatsu_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tyotatsu_nm", lang), base.GetPageContext().FormInfo["M1tyotatsu_nm"]);
				// (M1.HeaderRow.FindControl("M1syonin_flg") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syonin_flg", lang), base.GetPageContext().FormInfo["M1syonin_flg"]);
				// (M1.HeaderRow.FindControl("M1kyakka_flg") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kyakka_flg", lang), base.GetPageContext().FormInfo["M1kyakka_flg"]);
				// (M1.HeaderRow.FindControl("M1hinsyu_ryaku_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hinsyu_ryaku_nm", lang), base.GetPageContext().FormInfo["M1hinsyu_ryaku_nm"]);
				// (M1.HeaderRow.FindControl("M1bumon_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumon_nm", lang), base.GetPageContext().FormInfo["M1bumon_nm"]);
				// (M1.HeaderRow.FindControl("M1suryo_hdn") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo_hdn", lang), base.GetPageContext().FormInfo["M1suryo_hdn"]);
				// (M1.HeaderRow.FindControl("M1genkakin_hdn") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1genkakin_hdn", lang), base.GetPageContext().FormInfo["M1genkakin_hdn"]);
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
		/// <param name="tk010f02Form">画面FormVO</param>
		private void RenderM1Pager(Tk010f02Form tk010f02Form)
		{
			Pgr.VirtualItemCount = tk010f02Form.GetList("M1").RecordCount;
			Pgr.CurrentPageIndex = tk010f02Form.GetList("M1").PageNo - 1;
			Pgr.PageSize = tk010f02Form.GetList("M1").DispRow;
		}
		#endregion
		#endregion

		#region カードデータを表示する
		/// <summary>
		/// カードデータを表示する
		/// </summary>
		/// <param name="tk010f02Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderCard(
			Tk010f02Form tk010f02Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			
			ControlUtil.SetControlValue(Head_tenpo_cd,
				DataFormatUtil.GetFormatItem(tk010f02Form.Head_tenpo_cd,formInfo["Head_tenpo_cd"]));
			ControlUtil.SetControlValue(Head_tenpo_nm,
				DataFormatUtil.GetFormatItem(tk010f02Form.Head_tenpo_nm,formInfo["Head_tenpo_nm"]));
			ControlUtil.SetControlValue(Stkmodeno,
				DataFormatUtil.GetFormatItem(tk010f02Form.Stkmodeno,formInfo["Stkmodeno"]));
			ControlUtil.SetControlValue(Syori_ym,
				DataFormatUtil.GetFormatItem(tk010f02Form.Syori_ym,formInfo["Syori_ym"]));
			ControlUtil.SetControlValue(Tenpo_cd,
				DataFormatUtil.GetFormatItem(tk010f02Form.Tenpo_cd,formInfo["Tenpo_cd"]));
			ControlUtil.SetControlValue(Tenpo_nm,
				DataFormatUtil.GetFormatItem(tk010f02Form.Tenpo_nm,formInfo["Tenpo_nm"]));
			ControlUtil.SetControlValue(Syonin_flg_nm,
				DataFormatUtil.GetFormatItem(tk010f02Form.Syonin_flg_nm,formInfo["Syonin_flg_nm"]));
			ControlUtil.SetControlValue(Kessai_flg_nm,
				DataFormatUtil.GetFormatItem(tk010f02Form.Kessai_flg_nm,formInfo["Kessai_flg_nm"]));
			ControlUtil.SetControlValue(Apply_ymd,
				DataFormatUtil.GetFormatItem(tk010f02Form.Apply_ymd,formInfo["Apply_ymd"]));
			ControlUtil.SetControlValue(Ikkatsukyakka_kyakkariyu_kb,
				DataFormatUtil.GetFormatItem(tk010f02Form.Ikkatsukyakka_kyakkariyu_kb,formInfo["Ikkatsukyakka_kyakkariyu_kb"]));
			ControlUtil.SetControlValue(Ikkatsukyakka_kyakkariyu,
				DataFormatUtil.GetFormatItem(tk010f02Form.Ikkatsukyakka_kyakkariyu,formInfo["Ikkatsukyakka_kyakkariyu"]));
			ControlUtil.SetControlValue(Gokei_suryo,
				DataFormatUtil.GetFormatItem(tk010f02Form.Gokei_suryo,formInfo["Gokei_suryo"]));
			ControlUtil.SetControlValue(Haibun_kin_gokei,
				DataFormatUtil.GetFormatItem(tk010f02Form.Haibun_kin_gokei,formInfo["Haibun_kin_gokei"]));

			if(!base.CheckUseSelfCustomize()){
				Btnback.Value = base.FormResourceGetString(formResource, "Btnback", lang);
				Btnikkatsusyonin.Value = base.FormResourceGetString(formResource, "Btnikkatsusyonin", lang);
				Btnikkatsukyakka.Value = base.FormResourceGetString(formResource, "Btnikkatsukyakka", lang);
				Btnzenkjo.Value = base.FormResourceGetString(formResource, "Btnzenkjo", lang);
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
				// 一括却下用却下理由区分
				Ikkatsukyakka_kyakkariyu_kb.Items.Insert(0, new ListItem("", BoSystemConstant.DROPDOWNLIST_MISENTAKU));
			}
			for (int index = 0; index < M1.Items.Count; index++)
			{
				// 空白行が存在しない場合
				if (!((MDCodeCondition)M1.Items[index].FindControl("M1kyakkariyu_kb")).Items[0].Value.Equals(BoSystemConstant.DROPDOWNLIST_MISENTAKU))
				{
					// Ｍ１評価損却下区分に空白を追加
					MDCodeCondition hyokasonsyubetsu_kb = (MDCodeCondition)M1.Items[index].FindControl("M1kyakkariyu_kb");
					hyokasonsyubetsu_kb.Items.Insert(0, new ListItem("", BoSystemConstant.DROPDOWNLIST_MISENTAKU));
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
			// UIScreenController controller = new UIScreenController((Tk010f02Form)base.GetPageContext().GetFormVO());
			// controller.ChangeColumnsDisplayMode(M1 ,  new DetailHeaderFixedVO(M1Header , true) , null);

			/*
			 *登録した機能間連携処理を親画面に感知させる。
			 *機能有効させる場合は、コメントアウトを外してください。
			 */
			//DetailUtil.RunPgSyn(this,(StandardBaseForm)base.GetPageContext().GetFormVO());

			#region 画面表示制御
			Tk010f02Form formVo = (Tk010f02Form)base.GetPageContext().GetFormVO();
			IList m1DataList = formVo.GetPageViewList("M1");

			// [選択モードNO]が「照会」の場合
			if (BoSystemString.Nvl(formVo.Stkmodeno).Equals(BoSystemConstant.MODE_REF))
			{
				// 一括承認ボタン、一括却下ボタン、全解除ボタン、確定ボタン使用不可
				ControlCls.Disable(Btnikkatsusyonin, true);
				ControlCls.Disable(Btnikkatsukyakka, true);
				ControlCls.Disable(Btnzenkjo, true);
				ControlCls.Disable(Btnenter, true);

				// 一括却下用却下理由区分、一括却下用却下理由使用不可
				ControlCls.Disable(Ikkatsukyakka_kyakkariyu_kb, true);
				ControlCls.Disable(Ikkatsukyakka_kyakkariyu, true);

			}

			// 明細制御
			for (int i = 0; i < M1.Items.Count; i++)
			{
				// [選択モードNO]が「照会」の場合
				if (BoSystemString.Nvl(formVo.Stkmodeno).Equals(BoSystemConstant.MODE_REF))
				{
					// 入力項目を使用不可とする
					ControlCls.Disable(((MDTextBox)M1.Items[i].FindControl("M1scan_cd")), true);						// Ｍ１スキャンコード
					ControlCls.Disable(((MDTextBox)M1.Items[i].FindControl("M1suryo")), true);							// Ｍ１数量
					ControlCls.Disable(((MDCodeCondition)M1.Items[i].FindControl("M1hyokasonsyubetsu_kb")), true);		// Ｍ１評価損種別区分
					ControlCls.Disable(((MDCodeCondition)M1.Items[i].FindControl("M1hyokasonriyu_kb")), true);			// Ｍ１評価損理由区分
					ControlCls.Disable(((MDTextBox)M1.Items[i].FindControl("M1hyokasonriyu")), true);					// Ｍ１評価損理由
					ControlCls.Disable(((MDCodeCondition)M1.Items[i].FindControl("M1kyakkariyu_kb")), true);			// Ｍ１却下理由区分
					ControlCls.Disable(((MDTextBox)M1.Items[i].FindControl("M1kyakkariyu")), true);						// Ｍ１却下理由
					ControlCls.Disable(((AdvancedCheckBox)M1.Items[i].FindControl("M1syonin_flg")), true);					// Ｍ１承認状態
					ControlCls.Disable(((AdvancedCheckBox)M1.Items[i].FindControl("M1kyakka_flg")), true);					// Ｍ１却下フラグ
				}

				Tk010f02M1Form f02m1VO = (Tk010f02M1Form)m1DataList[i];

				// Ｍ１評価損理由区分_経年商品は常に入力不可
				ControlCls.Disable(((MDCodeCondition)M1.Items[i].FindControl("M1hyokasonriyu_kb_keinen")), true);

				// Ｍ１評価損種別区分：「経年品」の場合、Ｍ１評価損理由区分を入力不可にし、「経年商品」固定とする。
				if (ConditionHyokason_syubetsu.VALUE_HYOKASON_SYUBETSU2.Equals(f02m1VO.M1hyokasonsyubetsu_kb))
				{
					ControlCls.Visible(((MDCodeCondition)M1.Items[i].FindControl("M1hyokasonriyu_kb")), false);
				}
				// Ｍ１評価損種別区分：「販売不可」の場合、Ｍ１評価損理由区分を入力可能にし、「経年商品」以外の表示を行う。
				else
				{
					ControlCls.Visible(((MDCodeCondition)M1.Items[i].FindControl("M1hyokasonriyu_kb_keinen")), false);
				}

				// ツールチップを設定

				// 部門コード
				WebControl Bumon_cdControl = (WebControl)M1.Items[i].FindControl("M1bumon_cd");
				Bumon_cdControl.ToolTip = f02m1VO.M1bumon_nm;
				// 品種コード
				WebControl Hinsyu_cdControl = (WebControl)M1.Items[i].FindControl("M1hinsyu_cd");
				Hinsyu_cdControl.ToolTip = f02m1VO.M1hinsyu_ryaku_nm;
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
			ControlUtil.SetControlValue(Syori_ym_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Syori_ym", lang), base.GetPageContext().FormInfo["Syori_ym"]));
				DataFormatUtil.SetMustColorCaption(Syori_ym_lbl, base.GetPageContext().FormInfo["Syori_ym"]);
			ControlUtil.SetControlValue(Tenpo_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Tenpo_cd", lang), base.GetPageContext().FormInfo["Tenpo_cd"]));
				DataFormatUtil.SetMustColorCaption(Tenpo_cd_lbl, base.GetPageContext().FormInfo["Tenpo_cd"]);
			ControlUtil.SetControlValue(Tenpo_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Tenpo_nm", lang), base.GetPageContext().FormInfo["Tenpo_nm"]));
				DataFormatUtil.SetMustColorCaption(Tenpo_nm_lbl, base.GetPageContext().FormInfo["Tenpo_nm"]);
			ControlUtil.SetControlValue(Syonin_flg_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Syonin_flg_nm", lang), base.GetPageContext().FormInfo["Syonin_flg_nm"]));
				DataFormatUtil.SetMustColorCaption(Syonin_flg_nm_lbl, base.GetPageContext().FormInfo["Syonin_flg_nm"]);
			ControlUtil.SetControlValue(Kessai_flg_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Kessai_flg_nm", lang), base.GetPageContext().FormInfo["Kessai_flg_nm"]));
				DataFormatUtil.SetMustColorCaption(Kessai_flg_nm_lbl, base.GetPageContext().FormInfo["Kessai_flg_nm"]);
			ControlUtil.SetControlValue(Apply_ymd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Apply_ymd", lang), base.GetPageContext().FormInfo["Apply_ymd"]));
				DataFormatUtil.SetMustColorCaption(Apply_ymd_lbl, base.GetPageContext().FormInfo["Apply_ymd"]);
			ControlUtil.SetControlValue(Ikkatsukyakka_kyakkariyu_kb_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Ikkatsukyakka_kyakkariyu_kb", lang), base.GetPageContext().FormInfo["Ikkatsukyakka_kyakkariyu_kb"]));
				DataFormatUtil.SetMustColorCaption(Ikkatsukyakka_kyakkariyu_kb_lbl, base.GetPageContext().FormInfo["Ikkatsukyakka_kyakkariyu_kb"]);
			ControlUtil.SetControlValue(Ikkatsukyakka_kyakkariyu_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Ikkatsukyakka_kyakkariyu", lang), base.GetPageContext().FormInfo["Ikkatsukyakka_kyakkariyu"]));
				DataFormatUtil.SetMustColorCaption(Ikkatsukyakka_kyakkariyu_lbl, base.GetPageContext().FormInfo["Ikkatsukyakka_kyakkariyu"]);
			ControlUtil.SetControlValue(Gokei_suryo_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Gokei_suryo", lang), base.GetPageContext().FormInfo["Gokei_suryo"]));
				DataFormatUtil.SetMustColorCaption(Gokei_suryo_lbl, base.GetPageContext().FormInfo["Gokei_suryo"]);
			ControlUtil.SetControlValue(Haibun_kin_gokei_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Haibun_kin_gokei", lang), base.GetPageContext().FormInfo["Haibun_kin_gokei"]));
				DataFormatUtil.SetMustColorCaption(Haibun_kin_gokei_lbl, base.GetPageContext().FormInfo["Haibun_kin_gokei"]);
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
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hinsyu_cd", lang), base.GetPageContext().FormInfo["M1hinsyu_cd"]);
				// M1.Columns[3].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1burando_nm", lang), base.GetPageContext().FormInfo["M1burando_nm"]);
				// M1.Columns[4].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1jisya_hbn", lang), base.GetPageContext().FormInfo["M1jisya_hbn"]);
				// M1.Columns[5].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hanbaikanryo_ymd", lang), base.GetPageContext().FormInfo["M1hanbaikanryo_ymd"]);
				// M1.Columns[6].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1maker_hbn", lang), base.GetPageContext().FormInfo["M1maker_hbn"]);
				// M1.Columns[7].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syonmk", lang), base.GetPageContext().FormInfo["M1syonmk"]);
				// M1.Columns[8].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1scan_cd", lang), base.GetPageContext().FormInfo["M1scan_cd"]);
				// M1.Columns[9].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1iro_nm", lang), base.GetPageContext().FormInfo["M1iro_nm"]);
				// M1.Columns[10].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1size_nm", lang), base.GetPageContext().FormInfo["M1size_nm"]);
				// M1.Columns[11].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1genbaika_tnk", lang), base.GetPageContext().FormInfo["M1genbaika_tnk"]);
				// M1.Columns[12].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo", lang), base.GetPageContext().FormInfo["M1suryo"]);
				// M1.Columns[13].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1gen_tnk", lang), base.GetPageContext().FormInfo["M1gen_tnk"]);
				// M1.Columns[14].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1genkakin", lang), base.GetPageContext().FormInfo["M1genkakin"]);
				// M1.Columns[15].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1nyuryoku_ymd", lang), base.GetPageContext().FormInfo["M1nyuryoku_ymd"]);
				// M1.Columns[16].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1apply_ymd", lang), base.GetPageContext().FormInfo["M1apply_ymd"]);
				// M1.Columns[17].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1nyuryokusha_cd", lang), base.GetPageContext().FormInfo["M1nyuryokusha_cd"]);
				// M1.Columns[18].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1sinseisya_cd", lang), base.GetPageContext().FormInfo["M1sinseisya_cd"]);
				// M1.Columns[19].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hyokasonsyubetsu_kb", lang), base.GetPageContext().FormInfo["M1hyokasonsyubetsu_kb"]);
				// M1.Columns[20].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hyokasonriyu_kb", lang), base.GetPageContext().FormInfo["M1hyokasonriyu_kb"]);
				// M1.Columns[21].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hyokasonriyu_kb_keinen", lang), base.GetPageContext().FormInfo["M1hyokasonriyu_kb_keinen"]);
				// M1.Columns[22].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hyokasonriyu", lang), base.GetPageContext().FormInfo["M1hyokasonriyu"]);
				// M1.Columns[23].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kyakkariyu_kb", lang), base.GetPageContext().FormInfo["M1kyakkariyu_kb"]);
				// M1.Columns[24].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kyakkariyu", lang), base.GetPageContext().FormInfo["M1kyakkariyu"]);
				// M1.Columns[25].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tyotatsu_nm", lang), base.GetPageContext().FormInfo["M1tyotatsu_nm"]);
				// M1.Columns[26].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syonin_flg", lang), base.GetPageContext().FormInfo["M1syonin_flg"]);
				// M1.Columns[27].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kyakka_flg", lang), base.GetPageContext().FormInfo["M1kyakka_flg"]);
				// M1.Columns[28].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hinsyu_ryaku_nm", lang), base.GetPageContext().FormInfo["M1hinsyu_ryaku_nm"]);
				// M1.Columns[29].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumon_nm", lang), base.GetPageContext().FormInfo["M1bumon_nm"]);
				// M1.Columns[30].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo_hdn", lang), base.GetPageContext().FormInfo["M1suryo_hdn"]);
				// M1.Columns[31].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1genkakin_hdn", lang), base.GetPageContext().FormInfo["M1genkakin_hdn"]);
				// M1.Columns[32].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1selectorcheckbox", lang), base.GetPageContext().FormInfo["M1selectorcheckbox"]);
				// M1.Columns[33].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1entersyoriflg", lang), base.GetPageContext().FormInfo["M1entersyoriflg"]);
				// M1.Columns[34].HeaderText = 
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
				Windowtitle.InnerText = formResource.GetString("Tk010f02_Titlebar", lang);
				header.FormName = formResource.GetString("Tk010f02_FormCaption", lang);
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
