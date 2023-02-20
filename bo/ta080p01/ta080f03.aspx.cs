using com.xebio.bo.Ta080p01.Constant;
using com.xebio.bo.Ta080p01.Facade;
using com.xebio.bo.Ta080p01.Formvo;
using com.xebio.bo.Ta080p01.Util;
using com.xebio.bo.Tm040p01.Constant;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.Model.Context;
using Common.Advanced.Resource;
using Common.Advanced.Web.Context;
using Common.Advanced.Web.Control;
using Common.Advanced.Web.Util;
using Common.Business.C01000.C01003;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01008;
using Common.Business.C01000.C01012;
using Common.Business.C01000.C01014;
using Common.Business.C01000.C01015;
using Common.Business.C01000.C01016;
using Common.Business.C01000.C01023;
using Common.Business.C99999.Constant;
using Common.Business.C99999.StringUtil;
using Common.IntegrationMD.Constant;
using Common.IntegrationMD.MDControl;
using Common.IntegrationMD.Util;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Util;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Ta080p01.Page
{
  /// <summary>
  /// Ta080f03のコードビハインドです。
  /// </summary>
  public partial class Ta080f03Page : StandardBasePage
	{

		#region メソッド

		#region ページデータをロードするメソッド
		/// <summary>
		/// Ta080f03画面データを作成する。
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
						pageContext.SetFormVO(new Ta080f03Form());
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
								new Ta080f03Facade().DoLoad(facadeContext);
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

			// フォームを取得
			Ta080f03Form formVo = (Ta080f03Form)pageContext.GetFormVO();
			
			try
			{

				//アクションロジックを処理します
				IFacadeContext facadeContext = FacadeContextFactory.GetFacadeContext(pageContext);
				InitFacadeContext(facadeContext);
				new Ta080f03Facade().DoBTNBACK_FRM(facadeContext);
				
				
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
				// [選択モードNo]が「新規作成」の場合
				if (BoSystemConstant.MODE_INSERT.Equals(formVo.Stkmodeno))
				{
					commandInfo.ActionMode = "INI";
					commandInfo.PageLoadMode = true;
					// 新規作成の場合、モード表示クリア処理
					ModeUtil.ClearMode(pageContext);
				}
				else
				{
					commandInfo.ActionMode = "UPD";
					commandInfo.PageLoadMode = false;
				}
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
			// [選択モードNo]が「新規作成」以外の場合
			if (!BoSystemConstant.MODE_INSERT.Equals(formVo.Stkmodeno))
			{
				// フォーカス設定用変数
				string focusItem = string.Empty;
				string focusMno = string.Empty;

				// 選択された仕入枠グループにフォーカス設定
				focusItem = "M1yosan_cd";
				focusMno = (string)((Ta080f03Form)pageContext.GetFormVO(Ta080p01Constant.PGID, Ta080p01Constant.FORMID_03)).Dictionary[Ta080p01Constant.DIC_M1SELCETROWIDX];

				// フォーカス設定
				SetFocusCls.SetFocus(queryList, focusItem, focusMno);
			}

			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNBACK_FRM");
			
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

				pageContext = base.GetPageContext();

				// エラーの場合、モードを設定 
				//ModeUtil.SetMode(pageContext, ModeCls.GetModeNm(((Ta080f03Form)pageContext.GetFormVO()).Stkmodeno));

				//明細初期化処理
				//Page.ClientScript.RegisterStartupScript(typeof(string), "InitialDetail", ControlCls.InitialDetail(pageContext));
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
				new Ta080f03Facade().DoBTNSEARCH_FRM(facadeContext);
			
				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
					// アコーディオンなし
					// AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_NONE);
		
					base.SetError(pageContext);

					// エラーの場合、モードを設定 
					//ModeUtil.SetMode(pageContext, ModeCls.GetModeNm(((Ta080f03Form)pageContext.GetFormVO()).Stkmodeno));
					
					// 検索エラー時、明細をクリアしないためコメントアウト
//					// 明細初期化処理 
//					Page.ClientScript.RegisterStartupScript(typeof(string), "InitialDetail", ControlCls.InitialDetail(pageContext));
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
			#region フォーカス制御

			// フォーカス設定
			//SetFocusCls.SetFocus(queryList, focusItem, focusMno);
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
				new Ta080f03Facade().DoBTNZENSTK_FRM(facadeContext);
				
				
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
				new Ta080f03Facade().DoBTNZENKJO_FRM(facadeContext);
				
				
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
		
		#region M1明細の行を増やします(ボタンID : Btnrowins())
		/// <summary>
		/// M1明細の行を増やします。
		/// ボタンID(Btnrowins())
		/// アクションID(MADD)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnBTNROWINS_MADD(object sender, System.EventArgs e)
		{
			//フォーカスセット用インデックス
			string index;
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnBTNROWINS_MADD");
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
				new Ta080f03Facade().DoBTNROWINS_MADD(facadeContext);

				//明細フォーカスセット用インデックスを取得します。
				index = facadeContext.GetUserObject(MdSystemConstant.DETAIL_FOCUS_INDEX) as string;

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
			// フォーカス設定用変数
			string focusItem = string.Empty;
			string focusMno = string.Empty;

			// 追加行のＭ１スキャンコードにフォーカス設定
			focusItem = "M1scan_cd";
			focusMno = index;

			// フォーカス設定
			SetFocusCls.SetFocus(queryList, focusItem, focusMno);
			
			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNROWINS_MADD");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region 明細の行を増やします(ボタンID : Btnpageins())
		/// <summary>
		/// 明細の行を増やします。
		/// ボタンID(Btnpageins())
		/// アクションID(MADD)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnBTNPAGEINS_MINSX(object sender, System.EventArgs e)
		{
			//フォーカスセット用インデックス
			string index;
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnBTNPAGEINS_MINSX");
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
				new Ta080f03Facade().DoBTNPAGEINS_MINSX(facadeContext);
				//明細フォーカスセット用インデックスを取得します。
				index = facadeContext.GetUserObject(MdSystemConstant.DETAIL_FOCUS_INDEX) as string;				
				
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
			//queryList = FormFocusUtil.SetFocus(queryList, "項目ID", index);
			// フォーカス設定用変数
			string focusItem = string.Empty;
			string focusMno = string.Empty;

			// 追加行のＭ１スキャンコードにフォーカス設定
			focusItem = "M1scan_cd";
			focusMno = (0).ToString();

			// フォーカス設定
			SetFocusCls.SetFocus(queryList, focusItem, focusMno);

			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNPAGEINS_MINSX");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Btnsizstk())
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnsizstk())
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnBTNSIZSTK_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnBTNSIZSTK_FRM");
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

			// フォーカスインデックス初期化
			string focusMno = string.Empty;

			try
			{

				//アクションロジックを処理します
				IFacadeContext facadeContext = FacadeContextFactory.GetFacadeContext(pageContext);
				InitFacadeContext(facadeContext);
				//new Ta080f03Facade().DoBTNSIZSTK_FRM(facadeContext);

				// セッションにサイズ検索戻り値が設定されている場合
				if (Session[OpenTm040p01Cls.KEY_SIZE_SEARCH_RESULT] != null)
				{

					// セッションからファサードコンテキストに設定
					facadeContext.SetUserObject(Ta080p01Constant.KEY_SIZE_SEARCH_RESULT, Session[OpenTm040p01Cls.KEY_SIZE_SEARCH_RESULT]);

					new Ta080f03Facade().DoBTNSIZSTK_FRM(facadeContext);

					// フォーカスインデックスを取得
					focusMno = (string)facadeContext.GetUserObject(Ta080p01Constant.KEY_SIZE_FOCUS_INDEX);
				}
				else
				{
					#region サイズ検索画面起動パラメータ設定
					// フォームオブジェクト取得
					Ta080f03Form formVo = (Ta080f03Form)pageContext.GetFormVO();

					// 発注マスタ検索用情報設定
					SearchHachuVO searchHachuVO = new SearchHachuVO();
					searchHachuVO.Tencd = formVo.Head_tenpo_cd;			// 店舗コード
					searchHachuVO.Sijino = string.Empty;				// 指示NO（移動出荷マニュアル、返品マニュアル用）
					searchHachuVO.Syukakaisyacd = string.Empty;			// 出荷会社コード（移動出荷マニュアル)
					searchHachuVO.Nyukakaisyacd = string.Empty;			// 入荷会社コード（移動出荷マニュアル)
					searchHachuVO.Sijitencd = string.Empty;				// 指示店舗コード（移動出荷マニュアル、返品マニュアル用）

					// 最大件数
					int dMaxCnt = 0;
					dMaxCnt = decimal.ToInt32(GetMaxCntCls.GetMaxCnt(facadeContext.CommandInfo.FormId.ToUpper(), "1"));

					#endregion

					// サイズ検索画面起動
					OpenTm040p01Cls.OpenTm040p01(Page
												, Tm040p01Constant.FORMID_TA010F02
												, Ta080p01Util.GetRowCnt(formVo.GetList("M1"))
												, dMaxCnt
												, searchHachuVO
												, "1"
												, Btnsizstk.ID);
				
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
			EndMethod(sender, e, this.GetType().Name + ".OnBTNSIZSTK_FRM");

			//画面遷移
			// base.Forward(pageContext, queryList);
			if (Session[OpenTm040p01Cls.KEY_SIZE_SEARCH_RESULT] != null)
			{
				// セッションにサイズ検索戻り値が設定されている場合
				// セッションから削除
				Session.Remove(OpenTm040p01Cls.KEY_SIZE_SEARCH_RESULT);

				// フォーカス設定
				SetFocusCls.SetFocus(queryList, "M1scan_cd", focusMno);

				//画面遷移
				base.Forward(pageContext, queryList);
			}
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Btnrowdel())
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnrowdel())
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnBTNROWDEL_FRM(object sender, System.EventArgs e)
		{
			// フォーカスセット用インデックス
			string index;

			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnBTNROWDEL_FRM");
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
				new Ta080f03Facade().DoBTNROWDEL_FRM(facadeContext);
				
				
				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
					base.SetError(pageContext);
					return;
				}

				// フォーカスセット用インデックス
				index = facadeContext.GetUserObject(Ta080p01Constant.FCDUO_FOCUSROW) as string;

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

			focusItem = "M1scan_cd";
			focusMno = index;

			// フォーカス設定
			SetFocusCls.SetFocus(queryList, focusItem, focusMno);

			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNROWDEL_FRM");
			
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
				new Ta080f03Facade().DoPGR_PGN(facadeContext, pageindex);
				
				
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
			string sStkmodeno = "";
			try
			{

				//アクションロジックを処理します
				IFacadeContext facadeContext = FacadeContextFactory.GetFacadeContext(pageContext);
				InitFacadeContext(facadeContext);

				// 一覧画面VO
				FormVOManager fvm = new FormVOManager(Session);
				Ta080f01Form f01VO = (Ta080f01Form)fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Ta080p01Constant.FORMID_01);
				// 明細画面VO
				Ta080f03Form f03VO = (Ta080f03Form)facadeContext.FormVO;
				sStkmodeno = f03VO.Stkmodeno;


				// 代表自社品番振替メッセージ、単品レポートメッセージでいいえが押された場合、ファサードの呼び出しをしない
				if (!"2".Equals(BoSystemString.Nvl(this.Request[BoSystemConstant.TANPIN_TOUROKU_FLG]))
					&& !"4".Equals(BoSystemString.Nvl(this.Request[BoSystemConstant.TANPIN_TOUROKU_FLG]))
					)
				{
					// 単品レポートメッセージ用hidden項目がある場合、ファサードに渡す
					if (this.Request[BoSystemConstant.TANPIN_TOUROKU_FLG] != null)
					{
						facadeContext.SetUserObject(BoSystemConstant.TANPIN_FCD_KEY, this.Request[BoSystemConstant.TANPIN_TOUROKU_FLG]);
					}
					// 警告メッセージ用hidden項目がある場合、ファサードに渡す
					if (this.Request[BoSystemConstant.WARNING_HDNITEM_NM] != null)
					{
						facadeContext.SetUserObject(BoSystemConstant.WARNING_FCD_KEY, BoSystemString.Nvl(this.Request[BoSystemConstant.WARNING_HDNITEM_NM], "0"));
					}

					new Ta080f03Facade().DoBTNENTER_FRM(facadeContext);

					// 一覧画面VO
					fvm = new FormVOManager(Session);
					f01VO = (Ta080f01Form)fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Ta080p01Constant.FORMID_01);
					// 明細画面VO
					f03VO = (Ta080f03Form)facadeContext.FormVO;
					sStkmodeno = f03VO.Stkmodeno;
					IDataList m1List = f01VO.GetList("M1");
					// 明細画面のフォームビーンを設定
					fvm.SetFormVO(Ta080p01Constant.PGID, Ta080p01Constant.FORMID_03, f03VO);

					// 警告判定
					if (InfoMsgCls.HasWarn(facadeContext))
					{
						string script = "";
						if (Convert.ToString(Ta080p01Constant.FLG_ON).Equals(f03VO.Dictionary[Ta080p01Constant.DIC_M1DAIHYO_JISYAHB_HK_FLG])
							&& (BoSystemString.Nvl(sStkmodeno).Equals(BoSystemConstant.MODE_INSERT)
							|| BoSystemString.Nvl(sStkmodeno).Equals(BoSystemConstant.MODE_APPLY)
							|| BoSystemString.Nvl(sStkmodeno).Equals(BoSystemConstant.MODE_SINSEIMAEUPD))
							)
						{
							// 警告メッセージの表示(代表自社品番)
							script = InfoMsgCls.showLoadMsg(pageContext, 4, "Btnenter");
							Page.ClientScript.RegisterStartupScript(typeof(string), "infoDialog", script);
							return;
						}
						else if (Convert.ToString(Ta080p01Constant.FLG_ON).Equals(BoSystemString.Nvl(((decimal?)f03VO.Dictionary[Ta080p01Constant.DIC_TANPIN_REPORT_FLG]).ToString(), "0"))
								&& BoSystemString.Nvl(sStkmodeno).Equals(BoSystemConstant.MODE_INSERT))
						{
							// 警告メッセージの表示(単品レポート)
							script = InfoMsgCls.showLoadMsg(pageContext, 3, "Btnenter");
							Page.ClientScript.RegisterStartupScript(typeof(string), "infoDialog", script);
							return;
						}
						else
						{
							// 通常の警告アラーム
							script = InfoMsgCls.showLoadMsg(pageContext, 2, "Btnenter");
							Page.ClientScript.RegisterStartupScript(typeof(string), "infoDialog", script);
							return;
						}
					}
					//エラー判定
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						// 明細エラー背景色対応 ----- START
						//base.SetError(pageContext);
						// 明細エラー背景色対応 ----- END
						return;
					}
					// 単品登録モード判定
					if ("1".Equals(BoSystemString.Nvl(this.Request[BoSystemConstant.TANPIN_TOUROKU_FLG])))
					{
						if (Ta080p01Constant.FLG_ON.ToString().Equals(f03VO.Dictionary[Ta080p01Constant.DIC_TANPIN_TOUROKU_MODE_FLG]))
						{
							SetItems();
							SetAttribute();
							return;
						}
					}
				}

				// 次画面のフォームビーンを設定
				fvm.SetFormVO(Ta080p01Constant.PGID, Ta080p01Constant.FORMID_01, f01VO);

				//遷移先の画面設定（入出力画面定義で設定した遷移先は初期化処理で設定済み）
				//入出力画面定義で設定した遷移先以外の画面に遷移する場合は以下のソースを
				//コメントインし、設定して下さい。
				//commandInfo.ToProgramId = "遷移先プログラムID";
				//commandInfo.ToFormId = "遷移先フォームID";
				
				//他の処理モードを設定する必要がある場合、次の行を修正してください
				commandInfo.ActionMode = "UPD";

				// [選択モードNo]が「新規」の場合
				if (BoSystemString.Nvl(sStkmodeno).Equals(BoSystemConstant.MODE_INSERT))
				{
					commandInfo.PageLoadMode = true;
				}
				else
				{
					commandInfo.PageLoadMode = false;
				}

				// 画面遷移設定
				// 一覧画面に遷移
				pageContext.ButtonInfo.ActFormId = Ta080p01Constant.FORMID_01;
				
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

			// [選択モードNo]が「新規」の場合
			if (BoSystemString.Nvl(sStkmodeno).Equals(BoSystemConstant.MODE_INSERT))
			{
				// 権限取得部品の戻り値が"TRUE"の場合
				if (CheckKengenCls.CheckKengen(LoginInfoUtil.GetLoginInfo()))
				{
					// [ヘッダ店舗コード]にフォーカスを当てる。
					focusItem = "Head_tenpo_cd";
				}
				// 権限取得部品の戻り値が"FALSE"の場合
				else
				{
					// [年月度from]にフォーカスを当てる。
					focusItem = "Yosan_ymd_from";
				}
			}
			else
			{
				// 選択された仕入枠グループにフォーカス設定
				focusItem = "M1yosan_cd";
				focusMno = (string)((Ta080f03Form)pageContext.GetFormVO(Ta080p01Constant.PGID, Ta080p01Constant.FORMID_03)).Dictionary[Ta080p01Constant.DIC_M1SELCETROWIDX];
			}

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
						Ta080f03Form ta080f03Form = (Ta080f03Form)pageContext.GetFormVO();

						//明細ページ情報を表示する
						ShowListPageInfo(ta080f03Form);
			
						//明細部データを表示する
						RenderList(ta080f03Form, pageContext.FormInfo, formResource, lang);

						//カード部データを表示する
						RenderCard(ta080f03Form, pageContext.FormInfo, formResource, lang);
					}
					
					// 明細エラー背景色対応 ----START
					// エラー判定
					if (MessageDisplayUtil.HasError(FacadeContextFactory.GetFacadeContext(base.GetPageContext())))
					{
						base.SetError(base.GetPageContext());
					}

					// 明細エラー背景色対応 ----END
					
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
		/// <param name="ta080f03Form">画面FormVO</param>
		private void ShowListPageInfo(Ta080f03Form ta080f03Form)
		{
			//M1明細ページ情報を表示する。
			ShowM1ListPageInfo(ta080f03Form.GetList("M1"));

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
		/// <param name="ta080f03Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderList(
			Ta080f03Form ta080f03Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//画面のM1明細部データを設定する。
			RenderM1List(ta080f03Form, formInfo, formResource, lang);
			//M1明細部のページャーにページ情報を設定する。
			RenderM1Pager(ta080f03Form);
			
		}
		#endregion

		#region M1明細データを表示する
		/// <summary>
		/// M1明細データを表示する。
		/// </summary>
		/// <param name="ta080f03Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderM1List(
			Ta080f03Form ta080f03Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//M1明細部データソースを設定する。
			M1.DataSource = ta080f03Form.GetPageViewList("M1");
			M1.DataBind();

			//M1明細部データをフォーマットする。
			IList m1DataList = (IList)M1.DataSource;
			
			for (int index = 0; index < M1.Items.Count; index++)
			{
				Ta080f03M1Form ta080f03M1Form = (Ta080f03M1Form)m1DataList[index];
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1rowno"),
					DataFormatUtil.GetFormatItem(ta080f03M1Form.M1rowno,formInfo["M1rowno"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1bumonkana_nm"),
					DataFormatUtil.GetFormatItem(ta080f03M1Form.M1bumonkana_nm,formInfo["M1bumonkana_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1ten_hyoka_kb"),
					DataFormatUtil.GetFormatItem(ta080f03M1Form.M1ten_hyoka_kb,formInfo["M1ten_hyoka_kb"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1all_hyoka_kb"),
					DataFormatUtil.GetFormatItem(ta080f03M1Form.M1all_hyoka_kb,formInfo["M1all_hyoka_kb"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1tosyu_uriage_su"),
					DataFormatUtil.GetFormatItem(ta080f03M1Form.M1tosyu_uriage_su,formInfo["M1tosyu_uriage_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1hinsyu_ryaku_nm"),
					DataFormatUtil.GetFormatItem(ta080f03M1Form.M1hinsyu_ryaku_nm,formInfo["M1hinsyu_ryaku_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1zensyu_uriage_su"),
					DataFormatUtil.GetFormatItem(ta080f03M1Form.M1zensyu_uriage_su,formInfo["M1zensyu_uriage_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1zenzensyu_uriage_su"),
					DataFormatUtil.GetFormatItem(ta080f03M1Form.M1zenzensyu_uriage_su,formInfo["M1zenzensyu_uriage_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1burando_nm"),
					DataFormatUtil.GetFormatItem(ta080f03M1Form.M1burando_nm,formInfo["M1burando_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1nyukayotei_su"),
					DataFormatUtil.GetFormatItem(ta080f03M1Form.M1nyukayotei_su,formInfo["M1nyukayotei_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1tenzaiko_su"),
					DataFormatUtil.GetFormatItem(ta080f03M1Form.M1tenzaiko_su,formInfo["M1tenzaiko_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1jido_su"),
					DataFormatUtil.GetFormatItem(ta080f03M1Form.M1jido_su,formInfo["M1jido_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1haibunkano_su"),
					DataFormatUtil.GetFormatItem(ta080f03M1Form.M1haibunkano_su,formInfo["M1haibunkano_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1jisya_hbn"),
					DataFormatUtil.GetFormatItem(ta080f03M1Form.M1jisya_hbn,formInfo["M1jisya_hbn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1keikaku_ymd"),
					DataFormatUtil.GetFormatItem(ta080f03M1Form.M1keikaku_ymd,formInfo["M1keikaku_ymd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1syohin_zokusei"),
					DataFormatUtil.GetFormatItem(ta080f03M1Form.M1syohin_zokusei,formInfo["M1syohin_zokusei"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1lot_su"),
					DataFormatUtil.GetFormatItem(ta080f03M1Form.M1lot_su,formInfo["M1lot_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1maker_hbn"),
					DataFormatUtil.GetFormatItem(ta080f03M1Form.M1maker_hbn,formInfo["M1maker_hbn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1syonmk"),
					DataFormatUtil.GetFormatItem(ta080f03M1Form.M1syonmk,formInfo["M1syonmk"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1iro_nm"),
					DataFormatUtil.GetFormatItem(ta080f03M1Form.M1iro_nm,formInfo["M1iro_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1size_nm"),
					DataFormatUtil.GetFormatItem(ta080f03M1Form.M1size_nm,formInfo["M1size_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1scan_cd"),
					DataFormatUtil.GetFormatItem(ta080f03M1Form.M1scan_cd,formInfo["M1scan_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1irai_su"),
					DataFormatUtil.GetFormatItem(ta080f03M1Form.M1irai_su,formInfo["M1irai_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1hatchu_msg"),
					DataFormatUtil.GetFormatItem(ta080f03M1Form.M1hatchu_msg,formInfo["M1hatchu_msg"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1genkakin"),
					DataFormatUtil.GetFormatItem(ta080f03M1Form.M1genkakin,formInfo["M1genkakin"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1hanbaiin_nm"),
					DataFormatUtil.GetFormatItem(ta080f03M1Form.M1hanbaiin_nm,formInfo["M1hanbaiin_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1irairiyu_cd1"),
					DataFormatUtil.GetFormatItem(ta080f03M1Form.M1irairiyu_cd1,formInfo["M1irairiyu_cd1"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1irairiyu_cd2"),
					DataFormatUtil.GetFormatItem(ta080f03M1Form.M1irairiyu_cd2,formInfo["M1irairiyu_cd2"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1add_ymd"),
					DataFormatUtil.GetFormatItem(ta080f03M1Form.M1add_ymd,formInfo["M1add_ymd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1hanbaikanryo_ymd"),
					DataFormatUtil.GetFormatItem(ta080f03M1Form.M1hanbaikanryo_ymd,formInfo["M1hanbaikanryo_ymd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1uriage_su_hdn"),
					DataFormatUtil.GetFormatItem(ta080f03M1Form.M1uriage_su_hdn, formInfo["M1uriage_su_hdn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1irai_su_hdn"),
					DataFormatUtil.GetFormatItem(ta080f03M1Form.M1irai_su_hdn,formInfo["M1irai_su_hdn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1irairiyu_cd_hdn1"),
					DataFormatUtil.GetFormatItem(ta080f03M1Form.M1irairiyu_cd_hdn1,formInfo["M1irairiyu_cd_hdn1"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1irairiyu_cd_hdn2"),
					DataFormatUtil.GetFormatItem(ta080f03M1Form.M1irairiyu_cd_hdn2,formInfo["M1irairiyu_cd_hdn2"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1gen_tnk"),
					DataFormatUtil.GetFormatItem(ta080f03M1Form.M1gen_tnk,formInfo["M1gen_tnk"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1genkakin_hdn"),
					DataFormatUtil.GetFormatItem(ta080f03M1Form.M1genkakin_hdn,formInfo["M1genkakin_hdn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1selectorcheckbox"),
					DataFormatUtil.GetFormatItem(ta080f03M1Form.M1selectorcheckbox,formInfo["M1selectorcheckbox"]));
				((System.Web.UI.WebControls.CheckBox)M1.Items[index].FindControl("M1selectorcheckbox")).Text =
					formResource.GetString("M1selectorcheckbox", lang);
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1entersyoriflg"),
					DataFormatUtil.GetFormatItem(ta080f03M1Form.M1entersyoriflg,formInfo["M1entersyoriflg"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1dtlirokbn"),
					DataFormatUtil.GetFormatItem(ta080f03M1Form.M1dtlirokbn,formInfo["M1dtlirokbn"]));

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
				// (M1.HeaderRow.FindControl("M1bumonkana_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumonkana_nm", lang), base.GetPageContext().FormInfo["M1bumonkana_nm"]);
				// (M1.HeaderRow.FindControl("M1ten_hyoka_kb") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1ten_hyoka_kb", lang), base.GetPageContext().FormInfo["M1ten_hyoka_kb"]);
				// (M1.HeaderRow.FindControl("M1all_hyoka_kb") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1all_hyoka_kb", lang), base.GetPageContext().FormInfo["M1all_hyoka_kb"]);
				// (M1.HeaderRow.FindControl("M1tosyu_uriage_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tosyu_uriage_su", lang), base.GetPageContext().FormInfo["M1tosyu_uriage_su"]);
				// (M1.HeaderRow.FindControl("M1hinsyu_ryaku_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hinsyu_ryaku_nm", lang), base.GetPageContext().FormInfo["M1hinsyu_ryaku_nm"]);
				// (M1.HeaderRow.FindControl("M1zensyu_uriage_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1zensyu_uriage_su", lang), base.GetPageContext().FormInfo["M1zensyu_uriage_su"]);
				// (M1.HeaderRow.FindControl("M1zenzensyu_uriage_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1zenzensyu_uriage_su", lang), base.GetPageContext().FormInfo["M1zenzensyu_uriage_su"]);
				// (M1.HeaderRow.FindControl("M1burando_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1burando_nm", lang), base.GetPageContext().FormInfo["M1burando_nm"]);
				// (M1.HeaderRow.FindControl("M1nyukayotei_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1nyukayotei_su", lang), base.GetPageContext().FormInfo["M1nyukayotei_su"]);
				// (M1.HeaderRow.FindControl("M1tenzaiko_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tenzaiko_su", lang), base.GetPageContext().FormInfo["M1tenzaiko_su"]);
				// (M1.HeaderRow.FindControl("M1jido_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1jido_su", lang), base.GetPageContext().FormInfo["M1jido_su"]);
				// (M1.HeaderRow.FindControl("M1haibunkano_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1haibunkano_su", lang), base.GetPageContext().FormInfo["M1haibunkano_su"]);
				// (M1.HeaderRow.FindControl("M1jisya_hbn") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1jisya_hbn", lang), base.GetPageContext().FormInfo["M1jisya_hbn"]);
				// (M1.HeaderRow.FindControl("M1keikaku_ymd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1keikaku_ymd", lang), base.GetPageContext().FormInfo["M1keikaku_ymd"]);
				// (M1.HeaderRow.FindControl("M1syohin_zokusei") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syohin_zokusei", lang), base.GetPageContext().FormInfo["M1syohin_zokusei"]);
				// (M1.HeaderRow.FindControl("M1lot_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1lot_su", lang), base.GetPageContext().FormInfo["M1lot_su"]);
				// (M1.HeaderRow.FindControl("M1maker_hbn") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1maker_hbn", lang), base.GetPageContext().FormInfo["M1maker_hbn"]);
				// (M1.HeaderRow.FindControl("M1syonmk") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syonmk", lang), base.GetPageContext().FormInfo["M1syonmk"]);
				// (M1.HeaderRow.FindControl("M1iro_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1iro_nm", lang), base.GetPageContext().FormInfo["M1iro_nm"]);
				// (M1.HeaderRow.FindControl("M1size_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1size_nm", lang), base.GetPageContext().FormInfo["M1size_nm"]);
				// (M1.HeaderRow.FindControl("M1scan_cd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1scan_cd", lang), base.GetPageContext().FormInfo["M1scan_cd"]);
				// (M1.HeaderRow.FindControl("M1irai_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1irai_su", lang), base.GetPageContext().FormInfo["M1irai_su"]);
				// (M1.HeaderRow.FindControl("M1hatchu_msg") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hatchu_msg", lang), base.GetPageContext().FormInfo["M1hatchu_msg"]);
				// (M1.HeaderRow.FindControl("M1genkakin") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1genkakin", lang), base.GetPageContext().FormInfo["M1genkakin"]);
				// (M1.HeaderRow.FindControl("M1hanbaiin_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hanbaiin_nm", lang), base.GetPageContext().FormInfo["M1hanbaiin_nm"]);
				// (M1.HeaderRow.FindControl("M1irairiyu_cd1") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1irairiyu_cd1", lang), base.GetPageContext().FormInfo["M1irairiyu_cd1"]);
				// (M1.HeaderRow.FindControl("M1irairiyu_cd2") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1irairiyu_cd2", lang), base.GetPageContext().FormInfo["M1irairiyu_cd2"]);
				// (M1.HeaderRow.FindControl("M1add_ymd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1add_ymd", lang), base.GetPageContext().FormInfo["M1add_ymd"]);
				// (M1.HeaderRow.FindControl("M1hanbaikanryo_ymd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hanbaikanryo_ymd", lang), base.GetPageContext().FormInfo["M1hanbaikanryo_ymd"]);
				// (M1.HeaderRow.FindControl("M1uriage_su_hdn") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1uriage_su_hdn", lang), base.GetPageContext().FormInfo["M1uriage_su_hdn"]);
				// (M1.HeaderRow.FindControl("M1irai_su_hdn") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1irai_su_hdn", lang), base.GetPageContext().FormInfo["M1irai_su_hdn"]);
				// (M1.HeaderRow.FindControl("M1irairiyu_cd_hdn1") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1irairiyu_cd_hdn1", lang), base.GetPageContext().FormInfo["M1irairiyu_cd_hdn1"]);
				// (M1.HeaderRow.FindControl("M1irairiyu_cd_hdn2") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1irairiyu_cd_hdn2", lang), base.GetPageContext().FormInfo["M1irairiyu_cd_hdn2"]);
				// (M1.HeaderRow.FindControl("M1gen_tnk") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1gen_tnk", lang), base.GetPageContext().FormInfo["M1gen_tnk"]);
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
		/// <param name="ta080f03Form">画面FormVO</param>
		private void RenderM1Pager(Ta080f03Form ta080f03Form)
		{
			Pgr.VirtualItemCount = ta080f03Form.GetList("M1").RecordCount;
			Pgr.CurrentPageIndex = ta080f03Form.GetList("M1").PageNo - 1;
			Pgr.PageSize = ta080f03Form.GetList("M1").DispRow;
		}
		#endregion
		#endregion

		#region カードデータを表示する
		/// <summary>
		/// カードデータを表示する
		/// </summary>
		/// <param name="ta080f03Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderCard(
			Ta080f03Form ta080f03Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			
			ControlUtil.SetControlValue(Head_tenpo_cd,
				DataFormatUtil.GetFormatItem(ta080f03Form.Head_tenpo_cd,formInfo["Head_tenpo_cd"]));
			ControlUtil.SetControlValue(Head_tenpo_nm,
				DataFormatUtil.GetFormatItem(ta080f03Form.Head_tenpo_nm,formInfo["Head_tenpo_nm"]));
			ControlUtil.SetControlValue(Stkmodeno,
				DataFormatUtil.GetFormatItem(ta080f03Form.Stkmodeno,formInfo["Stkmodeno"]));
			ControlUtil.SetControlValue(Meisai_modeno,
				DataFormatUtil.GetFormatItem(ta080f03Form.Meisai_modeno,formInfo["Meisai_modeno"]));
			ControlUtil.SetControlValue(Meisai_stkmodeno,
				DataFormatUtil.GetFormatItem(ta080f03Form.Meisai_stkmodeno,formInfo["Meisai_stkmodeno"]));
			ControlUtil.SetControlValue(Yosan_ymd,
				DataFormatUtil.GetFormatItem(ta080f03Form.Yosan_ymd,formInfo["Yosan_ymd"]));
			ControlUtil.SetControlValue(Yosan_cd,
				DataFormatUtil.GetFormatItem(ta080f03Form.Yosan_cd,formInfo["Yosan_cd"]));
			ControlUtil.SetControlValue(Yosan_nm,
				DataFormatUtil.GetFormatItem(ta080f03Form.Yosan_nm,formInfo["Yosan_nm"]));
			ControlUtil.SetControlValue(Yosan_kin,
				DataFormatUtil.GetFormatItem(ta080f03Form.Yosan_kin,formInfo["Yosan_kin"]));
			ControlUtil.SetControlValue(Misinsei_su,
				DataFormatUtil.GetFormatItem(ta080f03Form.Misinsei_su,formInfo["Misinsei_su"]));
			ControlUtil.SetControlValue(Misinsei_kin,
				DataFormatUtil.GetFormatItem(ta080f03Form.Misinsei_kin,formInfo["Misinsei_kin"]));
			ControlUtil.SetControlValue(Apply_su,
				DataFormatUtil.GetFormatItem(ta080f03Form.Apply_su,formInfo["Apply_su"]));
			ControlUtil.SetControlValue(Apply_kin,
				DataFormatUtil.GetFormatItem(ta080f03Form.Apply_kin,formInfo["Apply_kin"]));
			ControlUtil.SetControlValue(Jisseki_su,
				DataFormatUtil.GetFormatItem(ta080f03Form.Jisseki_su,formInfo["Jisseki_su"]));
			ControlUtil.SetControlValue(Jisseki_kin,
				DataFormatUtil.GetFormatItem(ta080f03Form.Jisseki_kin,formInfo["Jisseki_kin"]));
			ControlUtil.SetControlValue(Zan_kin,
				DataFormatUtil.GetFormatItem(ta080f03Form.Zan_kin,formInfo["Zan_kin"]));
			ControlUtil.SetControlValue(Yosan_ymd1,
				DataFormatUtil.GetFormatItem(ta080f03Form.Yosan_ymd1,formInfo["Yosan_ymd1"]));
			ControlUtil.SetControlValue(Yosan_cd1,
				DataFormatUtil.GetFormatItem(ta080f03Form.Yosan_cd1,formInfo["Yosan_cd1"]));
			ControlUtil.SetControlValue(Yosan_nm1,
				DataFormatUtil.GetFormatItem(ta080f03Form.Yosan_nm1,formInfo["Yosan_nm1"]));
			ControlUtil.SetControlValue(Bumon_cd_from,
				DataFormatUtil.GetFormatItem(ta080f03Form.Bumon_cd_from,formInfo["Bumon_cd_from"]));
			ControlUtil.SetControlValue(Bumon_nm_from,
				DataFormatUtil.GetFormatItem(ta080f03Form.Bumon_nm_from,formInfo["Bumon_nm_from"]));
			ControlUtil.SetControlValue(Bumon_cd_to,
				DataFormatUtil.GetFormatItem(ta080f03Form.Bumon_cd_to,formInfo["Bumon_cd_to"]));
			ControlUtil.SetControlValue(Bumon_nm_to,
				DataFormatUtil.GetFormatItem(ta080f03Form.Bumon_nm_to,formInfo["Bumon_nm_to"]));
			ControlUtil.SetControlValue(Hinsyu_cd_all,
				DataFormatUtil.GetFormatItem(ta080f03Form.Hinsyu_cd_all,formInfo["Hinsyu_cd_all"]));
			Hinsyu_cd_all.Text = formResource.GetString("Hinsyu_cd_all", lang);
			ControlUtil.SetControlValue(Hinsyu_cd1,
				DataFormatUtil.GetFormatItem(ta080f03Form.Hinsyu_cd1,formInfo["Hinsyu_cd1"]));
			Hinsyu_cd1.Text = formResource.GetString("Hinsyu_cd1", lang);
			ControlUtil.SetControlValue(Hinsyu_cd2,
				DataFormatUtil.GetFormatItem(ta080f03Form.Hinsyu_cd2,formInfo["Hinsyu_cd2"]));
			Hinsyu_cd2.Text = formResource.GetString("Hinsyu_cd2", lang);
			ControlUtil.SetControlValue(Hinsyu_cd3,
				DataFormatUtil.GetFormatItem(ta080f03Form.Hinsyu_cd3,formInfo["Hinsyu_cd3"]));
			Hinsyu_cd3.Text = formResource.GetString("Hinsyu_cd3", lang);
			ControlUtil.SetControlValue(Hinsyu_cd4,
				DataFormatUtil.GetFormatItem(ta080f03Form.Hinsyu_cd4,formInfo["Hinsyu_cd4"]));
			Hinsyu_cd4.Text = formResource.GetString("Hinsyu_cd4", lang);
			ControlUtil.SetControlValue(Hinsyu_cd5,
				DataFormatUtil.GetFormatItem(ta080f03Form.Hinsyu_cd5,formInfo["Hinsyu_cd5"]));
			Hinsyu_cd5.Text = formResource.GetString("Hinsyu_cd5", lang);
			ControlUtil.SetControlValue(Hinsyu_cd6,
				DataFormatUtil.GetFormatItem(ta080f03Form.Hinsyu_cd6,formInfo["Hinsyu_cd6"]));
			Hinsyu_cd6.Text = formResource.GetString("Hinsyu_cd6", lang);
			ControlUtil.SetControlValue(Hinsyu_cd7,
				DataFormatUtil.GetFormatItem(ta080f03Form.Hinsyu_cd7,formInfo["Hinsyu_cd7"]));
			Hinsyu_cd7.Text = formResource.GetString("Hinsyu_cd7", lang);
			ControlUtil.SetControlValue(Hinsyu_cd8,
				DataFormatUtil.GetFormatItem(ta080f03Form.Hinsyu_cd8,formInfo["Hinsyu_cd8"]));
			Hinsyu_cd8.Text = formResource.GetString("Hinsyu_cd8", lang);
			ControlUtil.SetControlValue(Hinsyu_cd9,
				DataFormatUtil.GetFormatItem(ta080f03Form.Hinsyu_cd9,formInfo["Hinsyu_cd9"]));
			Hinsyu_cd9.Text = formResource.GetString("Hinsyu_cd9", lang);
			ControlUtil.SetControlValue(Burando_cd,
				DataFormatUtil.GetFormatItem(ta080f03Form.Burando_cd,formInfo["Burando_cd"]));
			ControlUtil.SetControlValue(Burando_nm,
				DataFormatUtil.GetFormatItem(ta080f03Form.Burando_nm,formInfo["Burando_nm"]));
			ControlUtil.SetControlValue(Old_jisya_hbn,
				DataFormatUtil.GetFormatItem(ta080f03Form.Old_jisya_hbn,formInfo["Old_jisya_hbn"]));
			ControlUtil.SetControlValue(Maker_hbn,
				DataFormatUtil.GetFormatItem(ta080f03Form.Maker_hbn,formInfo["Maker_hbn"]));
			ControlUtil.SetControlValue(Scan_cd,
				DataFormatUtil.GetFormatItem(ta080f03Form.Scan_cd,formInfo["Scan_cd"]));
			ControlUtil.SetControlValue(Add_ymd_from,
				DataFormatUtil.GetFormatItem(ta080f03Form.Add_ymd_from,formInfo["Add_ymd_from"]));
			ControlUtil.SetControlValue(Add_ymd_to,
				DataFormatUtil.GetFormatItem(ta080f03Form.Add_ymd_to,formInfo["Add_ymd_to"]));
			ControlUtil.SetControlValue(Tantosya_cd,
				DataFormatUtil.GetFormatItem(ta080f03Form.Tantosya_cd,formInfo["Tantosya_cd"]));
			ControlUtil.SetControlValue(Hanbaiin_nm,
				DataFormatUtil.GetFormatItem(ta080f03Form.Hanbaiin_nm,formInfo["Hanbaiin_nm"]));
			ControlUtil.SetControlValue(Irairiyu_cd1,
				DataFormatUtil.GetFormatItem(ta080f03Form.Irairiyu_cd1,formInfo["Irairiyu_cd1"]));
			ControlUtil.SetControlValue(Irairiyu_cd2,
				DataFormatUtil.GetFormatItem(ta080f03Form.Irairiyu_cd2,formInfo["Irairiyu_cd2"]));
			ControlUtil.SetControlValue(Hyoka_kb_mise,
				DataFormatUtil.GetFormatItem(ta080f03Form.Hyoka_kb_mise,formInfo["Hyoka_kb_mise"]));
			ControlUtil.SetControlValue(Hyoka_kb_all,
				DataFormatUtil.GetFormatItem(ta080f03Form.Hyoka_kb_all,formInfo["Hyoka_kb_all"]));
			ControlUtil.SetControlValue(Sortkb1,
				DataFormatUtil.GetFormatItem(ta080f03Form.Sortkb1,formInfo["Sortkb1"]));
			ControlUtil.SetControlValue(Sortoptionkb1,
				DataFormatUtil.GetFormatItem(ta080f03Form.Sortoptionkb1,formInfo["Sortoptionkb1"]));
			ControlUtil.SetControlValue(Sortkb2,
				DataFormatUtil.GetFormatItem(ta080f03Form.Sortkb2,formInfo["Sortkb2"]));
			ControlUtil.SetControlValue(Sortoptionkb2,
				DataFormatUtil.GetFormatItem(ta080f03Form.Sortoptionkb2,formInfo["Sortoptionkb2"]));
			ControlUtil.SetControlValue(Sortkb3,
				DataFormatUtil.GetFormatItem(ta080f03Form.Sortkb3,formInfo["Sortkb3"]));
			ControlUtil.SetControlValue(Sortoptionkb3,
				DataFormatUtil.GetFormatItem(ta080f03Form.Sortoptionkb3,formInfo["Sortoptionkb3"]));
			ControlUtil.SetControlValue(Gokei_irai_su,
				DataFormatUtil.GetFormatItem(ta080f03Form.Gokei_irai_su,formInfo["Gokei_irai_su"]));
			ControlUtil.SetControlValue(Gokei_genkakin,
				DataFormatUtil.GetFormatItem(ta080f03Form.Gokei_genkakin,formInfo["Gokei_genkakin"]));
			ControlUtil.SetControlValue(Footer_zan_kin,
				DataFormatUtil.GetFormatItem(ta080f03Form.Footer_zan_kin,formInfo["Footer_zan_kin"]));

			if(!base.CheckUseSelfCustomize()){
				Btnback.Value = base.FormResourceGetString(formResource, "Btnback", lang);
				Btnmodeyosanjoho.InnerText = base.FormResourceGetString(formResource, "Btnmodeyosanjoho", lang);
				Btnmodesiborikomi.InnerText = base.FormResourceGetString(formResource, "Btnmodesiborikomi", lang);
				Btnbumon_cd_from.Value = base.FormResourceGetString(formResource, "Btnbumon_cd_from", lang);
				Btnbumon_cdto.Value = base.FormResourceGetString(formResource, "Btnbumon_cdto", lang);
				Btnburando_cd.Value = base.FormResourceGetString(formResource, "Btnburando_cd", lang);
				Btntanto_cd.Value = base.FormResourceGetString(formResource, "Btntanto_cd", lang);
				Btnsearch.Value = base.FormResourceGetString(formResource, "Btnsearch", lang);
				Btnzenstk.Value = base.FormResourceGetString(formResource, "Btnzenstk", lang);
				Btnzenkjo.Value = base.FormResourceGetString(formResource, "Btnzenkjo", lang);
				Btnrowins.Value = base.FormResourceGetString(formResource, "Btnrowins", lang);
				Btnpageins.Value = base.FormResourceGetString(formResource, "Btnpageins", lang);
				Btnsizstk.Value = base.FormResourceGetString(formResource, "Btnsizstk", lang);
				Btnrowdel.Value = base.FormResourceGetString(formResource, "Btnrowdel", lang);
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
				// 依頼理由１に空白を追加
				Irairiyu_cd1.Items.Insert(0, new ListItem("", BoSystemConstant.DROPDOWNLIST_MISENTAKU));
				// 依頼理由２に空白を追加
				Irairiyu_cd2.Items.Insert(0, new ListItem("", BoSystemConstant.DROPDOWNLIST_MISENTAKU));
				// 店評価に空白を追加
				Hyoka_kb_mise.Items.Insert(0, new ListItem("", BoSystemConstant.DROPDOWNLIST_MISENTAKU));
				// 全評価に空白を追加
				Hyoka_kb_all.Items.Insert(0, new ListItem("", BoSystemConstant.DROPDOWNLIST_MISENTAKU));
			}
			for (int index = 0; index < M1.Items.Count; index++)
			{
				// 空白行が存在しない場合
				if (!((MDCodeCondition)M1.Items[index].FindControl("M1irairiyu_cd1")).Items[0].Value.Equals(BoSystemConstant.DROPDOWNLIST_MISENTAKU))
				{
					// 依頼理由コードに空白を追加
//					((MDCodeCondition)M1.Items[index].FindControl("M1irairiyu_cd1")).Items.Insert(0, new ListItem("", BoSystemConstant.DROPDOWNLIST_MISENTAKU));
				}
				// 空白行が存在しない場合
				if (!((MDCodeCondition)M1.Items[index].FindControl("M1irairiyu_cd2")).Items[0].Value.Equals(BoSystemConstant.DROPDOWNLIST_MISENTAKU))
				{
					// 依頼理由コードに空白を追加
//					((MDCodeCondition)M1.Items[index].FindControl("M1irairiyu_cd2")).Items.Insert(0, new ListItem("", BoSystemConstant.DROPDOWNLIST_MISENTAKU));
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
			// UIScreenController controller = new UIScreenController((Ta080f03Form)base.GetPageContext().GetFormVO());
			// controller.ChangeColumnsDisplayMode(M1 ,  new DetailHeaderFixedVO(M1Header , true) , null);

			/*
			 *登録した機能間連携処理を親画面に感知させる。
			 *機能有効させる場合は、コメントアウトを外してください。
			 */
			//DetailUtil.RunPgSyn(this,(StandardBaseForm)base.GetPageContext().GetFormVO());
			#region 画面表示制御
			Ta080f03Form formVo = (Ta080f03Form)base.GetPageContext().GetFormVO();

			// IDataList m1List = formVo.GetList("M1");
			IList m1DataList = formVo.GetPageViewList("M1");
			#region 項目活性制御

			string tanpinF = BoSystemString.Nvl(((string)formVo.Dictionary[Ta080p01Constant.DIC_TANPIN_TOUROKU_MODE_FLG]), "0");

			// 全選択ボタン  申請／申請取消の場合のみ使用可
			// 全解除ボタン  申請／申請取消の場合のみ使用可				
			// 行追加ボタン	新規作成の場合、非表示					
			//				申請前修正モード以外の場合使用不可
			//				申請前修正モード_単品レポートが選択された場合使用不可
			// ページ追加ボタン ※新規作成の場合のみ表示									
			// 行削除ボタン ※新規作成／申請前修正の場合のみ使用可								
			// 確定ボタン ※登録履歴照会/申請取消モードの場合、使用不可		
			// M1スキャンコード
			// M1依頼数
			// M1依頼理由1、M1依頼理由2

			#region [選択モードNo]が「新規作成」「申請」「申請前修正」「申請取消」の場合
			if (BoSystemString.Nvl(formVo.Stkmodeno).Equals(BoSystemConstant.MODE_INSERT)
			|| BoSystemString.Nvl(formVo.Stkmodeno).Equals(BoSystemConstant.MODE_APPLY)
			|| BoSystemString.Nvl(formVo.Stkmodeno).Equals(BoSystemConstant.MODE_SINSEIMAEUPD)
			|| BoSystemString.Nvl(formVo.Stkmodeno).Equals(BoSystemConstant.MODE_SINSEIZUMITORIKESI))
			{
				#region カード部項目
				// 全選択ボタン		------	使用可  	Btnzenstk
				ControlCls.Disable(Btnzenstk, false);
				// 全解除ボタン		------	使用可  	Btnzenkjo
				ControlCls.Disable(Btnzenkjo, false);
				// 確定ボタン		------	使用可  	Btnenter
				ControlCls.Disable(Btnrowins, false);

				#region [選択モードNo]が「新規作成」の場合
				if (BoSystemString.Nvl(formVo.Stkmodeno).Equals(BoSystemConstant.MODE_INSERT))
				{
					// モードタブ		------	使用不可
					Btnmodesiborikomi.Attributes.Add("tabindex", "-1");
					Btnmodesiborikomi.Style.Add("pointer-events", "none");
					// 行追加ボタン		表示無	使用不可	Btnrowins
					ControlCls.Visible(Btnrowins, false);
					ControlCls.Disable(Btnrowins, true);
					ControlCls.Visible(Spanrowins, false);
					// 行削除ボタン		------	使用可		Btnrowdel
					ControlCls.Disable(Btnrowdel, false);
					// 全選択ボタン		------	使用不可
					ControlCls.Disable(Btnzenstk, true);
					// 全解除ボタン		------	使用不可
					ControlCls.Disable(Btnzenkjo, true);


					// 単品登録モード判定
					if (Ta080p01Constant.FLG_ON.ToString().Equals(tanpinF))
					{
						// ページ追加ボタン	表示有	使用不可  	Btnpageins
						ControlCls.Visible(Btnpageins, true);
						ControlCls.Disable(Btnpageins, true);
						ControlCls.Visible(Spanpageins, true);

						// サイズ選択ボタン	------	使用不可  	Btnsizstk
						ControlCls.Disable(Btnsizstk, true);
					}
					else
					{
						// ページ追加ボタン	表示有	使用可  	Btnpageins
						ControlCls.Visible(Btnpageins, true);
						ControlCls.Disable(Btnpageins, false);
						ControlCls.Visible(Spanpageins, true);

						// サイズ選択ボタン	------	使用可  	Btnsizstk
						ControlCls.Disable(Btnsizstk, false);
					}
				}
				#endregion
				#region [選択モードNo]が「申請」「申請前修正」「申請取消」の場合
				else
				{
					// モードタブ		未定	使用可

					// ページ追加ボタン	表示無	使用不可  	Btnpageins
					ControlCls.Visible(Btnpageins, false);
					ControlCls.Disable(Btnpageins, true);
					ControlCls.Visible(Spanpageins, false);

					#region [選択モードNo]が「申請前修正」の場合
					if (BoSystemString.Nvl(formVo.Stkmodeno).Equals(BoSystemConstant.MODE_SINSEIMAEUPD))
					{
						// 行削除ボタン		------	使用可		Btnrowdel
						ControlCls.Disable(Btnrowdel, false);
						// 全選択ボタン		------	使用不可
						ControlCls.Disable(Btnzenstk, true);
						// 全解除ボタン		------	使用不可
						ControlCls.Disable(Btnzenkjo, true);


						// 単品登録モード判定
						if (Ta080p01Constant.FLG_ON.ToString().Equals(tanpinF))
						{
							// 行追加ボタン		表示有	使用不可	Btnrowins
							ControlCls.Visible(Btnrowins, true);
							ControlCls.Disable(Btnrowins, true);
							ControlCls.Visible(Spanrowins, true);

							// サイズ選択ボタン	------	使用不可  	Btnsizstk
							ControlCls.Disable(Btnsizstk, true);
						}
						else
						{
							// 行追加ボタン		表示有	使用可		Btnrowins
							ControlCls.Visible(Btnrowins, true);
							ControlCls.Disable(Btnrowins, false);
							ControlCls.Visible(Spanrowins, true);
			
							// サイズ選択ボタン	------	使用可  	Btnsizstk
							ControlCls.Disable(Btnsizstk, false);
						}
					}
					#endregion
					#region [選択モードNo]が「申請」「申請取消」の場合
					else
					{
						// 行追加ボタン		表示有	使用不可	Btnrowins
						ControlCls.Visible(Btnrowins, true);
						ControlCls.Disable(Btnrowins, true);
						ControlCls.Visible(Spanrowins, true);
						if (BoSystemString.Nvl(formVo.Stkmodeno).Equals(BoSystemConstant.MODE_APPLY))
						{
							ControlCls.Disable(Btnrowdel, false);
						}
						else
						{
							ControlCls.Disable(Btnrowdel, true);
						}

						// サイズ選択ボタン	------	使用不可	Btnsizstk
						ControlCls.Disable(Btnsizstk, true);

						// 全選択ボタン		------	使用可
						ControlCls.Disable(Btnzenstk, false);
						// 全解除ボタン		------	使用可
						ControlCls.Disable(Btnzenkjo, false);

					}
					#endregion
				}	
				#endregion

				// 単品登録モード判定
				if (Ta080p01Constant.FLG_ON.ToString().Equals(tanpinF))
				{
					// 依頼理由1		表示無	使用不可	
					ControlCls.Visible(Irairiyu_cd1, false);
					ControlCls.Disable(Irairiyu_cd1, true);
					// 依頼理由2		表示有	使用可	
					ControlCls.Visible(Irairiyu_cd2, true);
					ControlCls.Disable(Irairiyu_cd2, false);
				}
				else
				{
					// 依頼理由1		表示有	使用可	
					ControlCls.Visible(Irairiyu_cd1, true);
					ControlCls.Disable(Irairiyu_cd1, false);
					// 依頼理由2		表示無	使用不可	
					ControlCls.Visible(Irairiyu_cd2, false);
					ControlCls.Disable(Irairiyu_cd2, true);
				}
				#endregion

				#region 明細部項目
				for (int index = 0; index < M1.Items.Count; index++)
				{
					// 行選択を可にする。
					((AdvancedCheckBox)M1.Items[index].FindControl("M1selectorcheckbox")).Visible = true;

					#region モード「新規作成」｢申請｣｢申請前修正｣の場合
					if (BoSystemString.Nvl(formVo.Stkmodeno).Equals(BoSystemConstant.MODE_APPLY)
					|| BoSystemString.Nvl(formVo.Stkmodeno).Equals(BoSystemConstant.MODE_SINSEIMAEUPD)
					|| BoSystemString.Nvl(formVo.Stkmodeno).Equals(BoSystemConstant.MODE_INSERT))
					{

						// 単品登録モードの場合
						if (Ta080p01Constant.FLG_ON.ToString().Equals(tanpinF))
						{
							// M1スキャンコード	------	使用不可	()M1.Items[index].FindControl("M1scan_cd")
							ControlCls.Disable((MDTextBox)M1.Items[index].FindControl("M1scan_cd"), true);
							// M1依頼数			------	使用可		()M1.Items[index].FindControl("M1irai_su")
							ControlCls.Disable((MDTextBox)M1.Items[index].FindControl("M1irai_su"), false);
							// M1依頼理由1		表示無	使用不可	(MDCodeCondition)M1.Items[index].FindControl("Irairiyu_cd1")
							ControlCls.Visible((MDCodeCondition)M1.Items[index].FindControl("M1irairiyu_cd1"), false);
							ControlCls.Disable((MDCodeCondition)M1.Items[index].FindControl("M1irairiyu_cd1"), true);
							// M1依頼理由2		表示有	使用可		(MDCodeCondition)M1.Items[index].FindControl("Irairiyu_cd2")
							ControlCls.Visible((MDCodeCondition)M1.Items[index].FindControl("M1irairiyu_cd2"), true);
							ControlCls.Disable((MDCodeCondition)M1.Items[index].FindControl("M1irairiyu_cd2"), false);
						}
						else
						{
							// M1スキャンコード	------	使用可		()M1.Items[index].FindControl("M1scan_cd")
							ControlCls.Disable((MDTextBox)M1.Items[index].FindControl("M1scan_cd"), false);
							// M1依頼数			------	使用可		()M1.Items[index].FindControl("M1irai_su")
							ControlCls.Disable((MDTextBox)M1.Items[index].FindControl("M1irai_su"), false);
							// M1依頼理由1		表示有	使用可		(MDCodeCondition)M1.Items[index].FindControl("Irairiyu_cd1")
							ControlCls.Visible((MDCodeCondition)M1.Items[index].FindControl("M1irairiyu_cd1"), true);
							ControlCls.Disable((MDCodeCondition)M1.Items[index].FindControl("M1irairiyu_cd1"), false);
							// M1依頼理由2		表示無	使用不可	(MDCodeCondition)M1.Items[index].FindControl("Irairiyu_cd2")
							ControlCls.Visible((MDCodeCondition)M1.Items[index].FindControl("M1irairiyu_cd2"), false);
							ControlCls.Disable((MDCodeCondition)M1.Items[index].FindControl("M1irairiyu_cd2"), true);
						}
					}
					#endregion
					#region モード｢申請取消｣｢登録履歴照会｣の場合
					else
					{
						// M1スキャンコード	------	使用不可
						ControlCls.Disable((MDTextBox)M1.Items[index].FindControl("M1scan_cd"), true);
						// M1依頼数			------	使用不可
						ControlCls.Disable((MDTextBox)M1.Items[index].FindControl("M1irai_su"), true);

						// 単品登録モードの場合
						if (Ta080p01Constant.FLG_ON.ToString().Equals(tanpinF))
						{
							// M1依頼理由1		表示無	使用不可		
							ControlCls.Visible((MDCodeCondition)M1.Items[index].FindControl("M1irairiyu_cd1"), false);
							ControlCls.Disable((MDCodeCondition)M1.Items[index].FindControl("M1irairiyu_cd1"), true);
							// M1依頼理由2		表示有	使用不可	
							ControlCls.Visible((MDCodeCondition)M1.Items[index].FindControl("M1irairiyu_cd2"), true);
							ControlCls.Disable((MDCodeCondition)M1.Items[index].FindControl("M1irairiyu_cd2"), true);
						}
						else
						{
							// M1依頼理由1		表示有	使用不可		
							ControlCls.Visible((MDCodeCondition)M1.Items[index].FindControl("M1irairiyu_cd1"), true);
							ControlCls.Disable((MDCodeCondition)M1.Items[index].FindControl("M1irairiyu_cd1"), true);
							// M1依頼理由2		表示無	使用不可	
							ControlCls.Visible((MDCodeCondition)M1.Items[index].FindControl("M1irairiyu_cd2"), false);
							ControlCls.Disable((MDCodeCondition)M1.Items[index].FindControl("M1irairiyu_cd2"), true);

						}
					}
					#endregion
				}
				#endregion
			}
			#endregion
			#region [選択モードNo]が「登録履歴照会」の場合
			else if (BoSystemString.Nvl(formVo.Stkmodeno).Equals(BoSystemConstant.MODE_REF_TOROKURIREKI))
			{
				#region カード部項目

				// モードタブ		------	使用可	

				// 全選択ボタン		------	使用不可
				ControlCls.Disable(Btnzenstk, true);
				// 全解除ボタン		------	使用不可
				ControlCls.Disable(Btnzenkjo, true);
				// 行追加ボタン		表示有	使用不可
				ControlCls.Visible(Btnrowins, true);
				ControlCls.Disable(Btnrowins, true);
				ControlCls.Visible(Spanrowins, true);
				// サイズ選択ボタン	------	使用不可  	Btnsizstk
				ControlCls.Disable(Btnsizstk, true);
				// ページ追加ボタン	表示無	使用不可
				ControlCls.Visible(Btnpageins, false);
				ControlCls.Disable(Btnpageins, true);
				ControlCls.Visible(Spanpageins, false);
				// 行削除ボタン		------	使用不可
				ControlCls.Disable(Btnrowdel, true);
				// 確定ボタン		------	使用不可
				ControlCls.Disable(Btnenter, true);

				// 単品登録モード判定
				if (Ta080p01Constant.FLG_ON.ToString().Equals(formVo.Dictionary[Ta080p01Constant.DIC_TANPIN_TOUROKU_MODE_FLG]))
				{
					// 依頼理由1		表示無	使用不可	
					ControlCls.Visible(Irairiyu_cd1, false);
					ControlCls.Disable(Irairiyu_cd1, true);
					// 依頼理由2		表示有	使用可	
					ControlCls.Visible(Irairiyu_cd2, true);
					ControlCls.Disable(Irairiyu_cd2, false);
				}
				else
				{
					// 依頼理由1		表示有	使用可	
					ControlCls.Visible(Irairiyu_cd1, true);
					ControlCls.Disable(Irairiyu_cd1, false);
					// 依頼理由2		表示無	使用不可	
					ControlCls.Visible(Irairiyu_cd2, false);
					ControlCls.Disable(Irairiyu_cd2, true);
				}

				#endregion

				#region 名細部項目
				// 明細情報
				for (int index = 0; index < M1.Items.Count; index++)
				{
					// 行選択を不可にする。
					((AdvancedCheckBox)M1.Items[index].FindControl("M1selectorcheckbox")).Visible = false;

					// M1スキャンコード	------	使用不可
					ControlCls.Disable((MDTextBox)M1.Items[index].FindControl("M1scan_cd"), true);
					// M1依頼数			------	使用不可
					ControlCls.Disable((MDTextBox)M1.Items[index].FindControl("M1irai_su"), true);

					// 単品登録モード判定
					if (Ta080p01Constant.FLG_ON.ToString().Equals(formVo.Dictionary[Ta080p01Constant.DIC_TANPIN_TOUROKU_MODE_FLG]))
					{
						// M1依頼理由1		表示無	使用不可
						ControlCls.Visible((MDCodeCondition)M1.Items[index].FindControl("M1irairiyu_cd1"), false);
						ControlCls.Disable((MDCodeCondition)M1.Items[index].FindControl("M1irairiyu_cd1"), true);
						// M1依頼理由2		表示有	使用不可
						ControlCls.Visible((MDCodeCondition)M1.Items[index].FindControl("M1irairiyu_cd2"), true);
						ControlCls.Disable((MDCodeCondition)M1.Items[index].FindControl("M1irairiyu_cd2"), true);
					}
					else
					{
						// M1依頼理由1		表示有	使用不可
						ControlCls.Visible((MDCodeCondition)M1.Items[index].FindControl("M1irairiyu_cd1"), true);
						ControlCls.Disable((MDCodeCondition)M1.Items[index].FindControl("M1irairiyu_cd1"), true);
						// M1依頼理由2		表示無	使用不可
						ControlCls.Visible((MDCodeCondition)M1.Items[index].FindControl("M1irairiyu_cd2"), false);
						ControlCls.Disable((MDCodeCondition)M1.Items[index].FindControl("M1irairiyu_cd2"), true);
					}
				}
				#endregion
			}
			#endregion
			#endregion

			#region 明細項目文字色設定
			for (int index = 0; index < M1.Items.Count; index++)
			{
				Ta080f03M1Form F03m01VO = (Ta080f03M1Form)m1DataList[index];
				// 計画期間を過ぎている場合は文字色を青とする。
				if (Ta080p01Constant.FLG_ON.Equals(F03m01VO.Dictionary[Ta080p01Constant.DIC_IROFLG_M1_M1KEIKAKU_YMD]))
				{
					ControlCls.SetFontColor((WebControl)M1.Items[index].FindControl("M1keikaku_ymd"), 3);
				}
				// [選択モードNo]が「申請」かつ同一商品が存在する場合、文字を青色表示。
				if (Ta080p01Constant.FLG_ON.Equals( F03m01VO.Dictionary[Ta080p01Constant.DIC_IROFLG_M1_M1SCAN_CD]))
				{
					ControlCls.SetFontColor((MDTextBox)M1.Items[index].FindControl("M1scan_cd"), 3);
				}
				// 数量が基準値を超える場合、フォントカラーを青色にする。
				// 基準値（過去2週の売上×5個以上）
				if (Ta080p01Constant.FLG_ON.Equals( F03m01VO.Dictionary[Ta080p01Constant.DIC_IROFLG_M1_M1IRAI_SU]))
				{
					ControlCls.SetFontColor((MDTextBox)M1.Items[index].FindControl("M1irai_su"), 3);
				}
				// [選択モードNo]が「申請」かつ同一商品が存在する場合、文字を青色表示。
				if (Ta080p01Constant.FLG_ON.Equals( (F03m01VO.Dictionary[Ta080p01Constant.DIC_IROFLG_M1_M1HANBAIIN_NM])))
				{
					ControlCls.SetFontColor((WebControl)M1.Items[index].FindControl("M1hanbaiin_nm"), 3);
				}
				// システム日付の＋7日以内の場合赤色表示
				if (Ta080p01Constant.FLG_ON.Equals((F03m01VO.Dictionary[Ta080p01Constant.DIC_IROFLG_M1_M1HANBAIKANRYO_YMD])))
				{
					ControlCls.SetFontColor((WebControl)M1.Items[index].FindControl("M1hanbaikanryo_ymd"), 2);
				}
			}
			#endregion

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
			ControlUtil.SetControlValue(Yosan_ymd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Yosan_ymd", lang), base.GetPageContext().FormInfo["Yosan_ymd"]));
				DataFormatUtil.SetMustColorCaption(Yosan_ymd_lbl, base.GetPageContext().FormInfo["Yosan_ymd"]);
			ControlUtil.SetControlValue(Yosan_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Yosan_cd", lang), base.GetPageContext().FormInfo["Yosan_cd"]));
				DataFormatUtil.SetMustColorCaption(Yosan_cd_lbl, base.GetPageContext().FormInfo["Yosan_cd"]);
			ControlUtil.SetControlValue(Yosan_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Yosan_nm", lang), base.GetPageContext().FormInfo["Yosan_nm"]));
				DataFormatUtil.SetMustColorCaption(Yosan_nm_lbl, base.GetPageContext().FormInfo["Yosan_nm"]);
			ControlUtil.SetControlValue(Yosan_kin_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Yosan_kin", lang), base.GetPageContext().FormInfo["Yosan_kin"]));
				DataFormatUtil.SetMustColorCaption(Yosan_kin_lbl, base.GetPageContext().FormInfo["Yosan_kin"]);
			ControlUtil.SetControlValue(Misinsei_su_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Misinsei_su", lang), base.GetPageContext().FormInfo["Misinsei_su"]));
				DataFormatUtil.SetMustColorCaption(Misinsei_su_lbl, base.GetPageContext().FormInfo["Misinsei_su"]);
			ControlUtil.SetControlValue(Misinsei_kin_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Misinsei_kin", lang), base.GetPageContext().FormInfo["Misinsei_kin"]));
				DataFormatUtil.SetMustColorCaption(Misinsei_kin_lbl, base.GetPageContext().FormInfo["Misinsei_kin"]);
			ControlUtil.SetControlValue(Apply_su_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Apply_su", lang), base.GetPageContext().FormInfo["Apply_su"]));
				DataFormatUtil.SetMustColorCaption(Apply_su_lbl, base.GetPageContext().FormInfo["Apply_su"]);
			ControlUtil.SetControlValue(Apply_kin_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Apply_kin", lang), base.GetPageContext().FormInfo["Apply_kin"]));
				DataFormatUtil.SetMustColorCaption(Apply_kin_lbl, base.GetPageContext().FormInfo["Apply_kin"]);
			ControlUtil.SetControlValue(Jisseki_su_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Jisseki_su", lang), base.GetPageContext().FormInfo["Jisseki_su"]));
				DataFormatUtil.SetMustColorCaption(Jisseki_su_lbl, base.GetPageContext().FormInfo["Jisseki_su"]);
			ControlUtil.SetControlValue(Jisseki_kin_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Jisseki_kin", lang), base.GetPageContext().FormInfo["Jisseki_kin"]));
				DataFormatUtil.SetMustColorCaption(Jisseki_kin_lbl, base.GetPageContext().FormInfo["Jisseki_kin"]);
			ControlUtil.SetControlValue(Zan_kin_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Zan_kin", lang), base.GetPageContext().FormInfo["Zan_kin"]));
				DataFormatUtil.SetMustColorCaption(Zan_kin_lbl, base.GetPageContext().FormInfo["Zan_kin"]);
			ControlUtil.SetControlValue(Yosan_ymd1_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Yosan_ymd1", lang), base.GetPageContext().FormInfo["Yosan_ymd1"]));
				DataFormatUtil.SetMustColorCaption(Yosan_ymd1_lbl, base.GetPageContext().FormInfo["Yosan_ymd1"]);
			ControlUtil.SetControlValue(Yosan_cd1_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Yosan_cd1", lang), base.GetPageContext().FormInfo["Yosan_cd1"]));
				DataFormatUtil.SetMustColorCaption(Yosan_cd1_lbl, base.GetPageContext().FormInfo["Yosan_cd1"]);
			ControlUtil.SetControlValue(Yosan_nm1_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Yosan_nm1", lang), base.GetPageContext().FormInfo["Yosan_nm1"]));
				DataFormatUtil.SetMustColorCaption(Yosan_nm1_lbl, base.GetPageContext().FormInfo["Yosan_nm1"]);
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
			//ControlUtil.SetControlValue(Hinsyu_cd_all_lbl, 
			//	DataFormatUtil.GetFormatCaption(formResource.GetString("Hinsyu_cd_all", lang), base.GetPageContext().FormInfo["Hinsyu_cd_all"]));
			ControlUtil.SetControlValue(Hinsyu_cd_all_lbl, "品種");
				DataFormatUtil.SetMustColorCaption(Hinsyu_cd_all_lbl, base.GetPageContext().FormInfo["Hinsyu_cd_all"]);
			ControlUtil.SetControlValue(Hinsyu_cd1_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Hinsyu_cd1", lang), base.GetPageContext().FormInfo["Hinsyu_cd1"]));
				DataFormatUtil.SetMustColorCaption(Hinsyu_cd1_lbl, base.GetPageContext().FormInfo["Hinsyu_cd1"]);
			ControlUtil.SetControlValue(Hinsyu_cd2_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Hinsyu_cd2", lang), base.GetPageContext().FormInfo["Hinsyu_cd2"]));
				DataFormatUtil.SetMustColorCaption(Hinsyu_cd2_lbl, base.GetPageContext().FormInfo["Hinsyu_cd2"]);
			ControlUtil.SetControlValue(Hinsyu_cd3_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Hinsyu_cd3", lang), base.GetPageContext().FormInfo["Hinsyu_cd3"]));
				DataFormatUtil.SetMustColorCaption(Hinsyu_cd3_lbl, base.GetPageContext().FormInfo["Hinsyu_cd3"]);
			ControlUtil.SetControlValue(Hinsyu_cd4_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Hinsyu_cd4", lang), base.GetPageContext().FormInfo["Hinsyu_cd4"]));
				DataFormatUtil.SetMustColorCaption(Hinsyu_cd4_lbl, base.GetPageContext().FormInfo["Hinsyu_cd4"]);
			ControlUtil.SetControlValue(Hinsyu_cd5_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Hinsyu_cd5", lang), base.GetPageContext().FormInfo["Hinsyu_cd5"]));
				DataFormatUtil.SetMustColorCaption(Hinsyu_cd5_lbl, base.GetPageContext().FormInfo["Hinsyu_cd5"]);
			ControlUtil.SetControlValue(Hinsyu_cd6_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Hinsyu_cd6", lang), base.GetPageContext().FormInfo["Hinsyu_cd6"]));
				DataFormatUtil.SetMustColorCaption(Hinsyu_cd6_lbl, base.GetPageContext().FormInfo["Hinsyu_cd6"]);
			ControlUtil.SetControlValue(Hinsyu_cd7_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Hinsyu_cd7", lang), base.GetPageContext().FormInfo["Hinsyu_cd7"]));
				DataFormatUtil.SetMustColorCaption(Hinsyu_cd7_lbl, base.GetPageContext().FormInfo["Hinsyu_cd7"]);
			ControlUtil.SetControlValue(Hinsyu_cd8_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Hinsyu_cd8", lang), base.GetPageContext().FormInfo["Hinsyu_cd8"]));
				DataFormatUtil.SetMustColorCaption(Hinsyu_cd8_lbl, base.GetPageContext().FormInfo["Hinsyu_cd8"]);
			ControlUtil.SetControlValue(Hinsyu_cd9_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Hinsyu_cd9", lang), base.GetPageContext().FormInfo["Hinsyu_cd9"]));
				DataFormatUtil.SetMustColorCaption(Hinsyu_cd9_lbl, base.GetPageContext().FormInfo["Hinsyu_cd9"]);
			ControlUtil.SetControlValue(Burando_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Burando_cd", lang), base.GetPageContext().FormInfo["Burando_cd"]));
				DataFormatUtil.SetMustColorCaption(Burando_cd_lbl, base.GetPageContext().FormInfo["Burando_cd"]);
			ControlUtil.SetControlValue(Burando_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Burando_nm", lang), base.GetPageContext().FormInfo["Burando_nm"]));
				DataFormatUtil.SetMustColorCaption(Burando_nm_lbl, base.GetPageContext().FormInfo["Burando_nm"]);
			ControlUtil.SetControlValue(Old_jisya_hbn_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Old_jisya_hbn", lang), base.GetPageContext().FormInfo["Old_jisya_hbn"]));
				DataFormatUtil.SetMustColorCaption(Old_jisya_hbn_lbl, base.GetPageContext().FormInfo["Old_jisya_hbn"]);
			ControlUtil.SetControlValue(Maker_hbn_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Maker_hbn", lang), base.GetPageContext().FormInfo["Maker_hbn"]));
				DataFormatUtil.SetMustColorCaption(Maker_hbn_lbl, base.GetPageContext().FormInfo["Maker_hbn"]);
			ControlUtil.SetControlValue(Scan_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Scan_cd", lang), base.GetPageContext().FormInfo["Scan_cd"]));
				DataFormatUtil.SetMustColorCaption(Scan_cd_lbl, base.GetPageContext().FormInfo["Scan_cd"]);
			ControlUtil.SetControlValue(Add_ymd_from_lbl, "登録日");
				DataFormatUtil.SetMustColorCaption(Add_ymd_from_lbl, base.GetPageContext().FormInfo["Add_ymd_from"]);
			ControlUtil.SetControlValue(Add_ymd_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Add_ymd_to", lang), base.GetPageContext().FormInfo["Add_ymd_to"]));
				DataFormatUtil.SetMustColorCaption(Add_ymd_to_lbl, base.GetPageContext().FormInfo["Add_ymd_to"]);
			ControlUtil.SetControlValue(Tantosya_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Tantosya_cd", lang), base.GetPageContext().FormInfo["Tantosya_cd"]));
				DataFormatUtil.SetMustColorCaption(Tantosya_cd_lbl, base.GetPageContext().FormInfo["Tantosya_cd"]);
			ControlUtil.SetControlValue(Hanbaiin_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Hanbaiin_nm", lang), base.GetPageContext().FormInfo["Hanbaiin_nm"]));
				DataFormatUtil.SetMustColorCaption(Hanbaiin_nm_lbl, base.GetPageContext().FormInfo["Hanbaiin_nm"]);
			ControlUtil.SetControlValue(Irairiyu_cd1_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Irairiyu_cd1", lang), base.GetPageContext().FormInfo["Irairiyu_cd1"]));
				DataFormatUtil.SetMustColorCaption(Irairiyu_cd1_lbl, base.GetPageContext().FormInfo["Irairiyu_cd1"]);
			ControlUtil.SetControlValue(Irairiyu_cd2_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Irairiyu_cd2", lang), base.GetPageContext().FormInfo["Irairiyu_cd2"]));
				DataFormatUtil.SetMustColorCaption(Irairiyu_cd2_lbl, base.GetPageContext().FormInfo["Irairiyu_cd2"]);
			ControlUtil.SetControlValue(Hyoka_kb_mise_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Hyoka_kb_mise", lang), base.GetPageContext().FormInfo["Hyoka_kb_mise"]));
				DataFormatUtil.SetMustColorCaption(Hyoka_kb_mise_lbl, base.GetPageContext().FormInfo["Hyoka_kb_mise"]);
			ControlUtil.SetControlValue(Hyoka_kb_all_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Hyoka_kb_all", lang), base.GetPageContext().FormInfo["Hyoka_kb_all"]));
				DataFormatUtil.SetMustColorCaption(Hyoka_kb_all_lbl, base.GetPageContext().FormInfo["Hyoka_kb_all"]);
			ControlUtil.SetControlValue(Sortkb1_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Sortkb1", lang), base.GetPageContext().FormInfo["Sortkb1"]));
				DataFormatUtil.SetMustColorCaption(Sortkb1_lbl, base.GetPageContext().FormInfo["Sortkb1"]);
			ControlUtil.SetControlValue(Sortoptionkb1_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Sortoptionkb1", lang), base.GetPageContext().FormInfo["Sortoptionkb1"]));
				DataFormatUtil.SetMustColorCaption(Sortoptionkb1_lbl, base.GetPageContext().FormInfo["Sortoptionkb1"]);
			ControlUtil.SetControlValue(Sortkb2_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Sortkb2", lang), base.GetPageContext().FormInfo["Sortkb2"]));
				DataFormatUtil.SetMustColorCaption(Sortkb2_lbl, base.GetPageContext().FormInfo["Sortkb2"]);
			ControlUtil.SetControlValue(Sortoptionkb2_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Sortoptionkb2", lang), base.GetPageContext().FormInfo["Sortoptionkb2"]));
				DataFormatUtil.SetMustColorCaption(Sortoptionkb2_lbl, base.GetPageContext().FormInfo["Sortoptionkb2"]);
			ControlUtil.SetControlValue(Sortkb3_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Sortkb3", lang), base.GetPageContext().FormInfo["Sortkb3"]));
				DataFormatUtil.SetMustColorCaption(Sortkb3_lbl, base.GetPageContext().FormInfo["Sortkb3"]);
			ControlUtil.SetControlValue(Sortoptionkb3_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Sortoptionkb3", lang), base.GetPageContext().FormInfo["Sortoptionkb3"]));
				DataFormatUtil.SetMustColorCaption(Sortoptionkb3_lbl, base.GetPageContext().FormInfo["Sortoptionkb3"]);
			ControlUtil.SetControlValue(Gokei_irai_su_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Gokei_irai_su", lang), base.GetPageContext().FormInfo["Gokei_irai_su"]));
				DataFormatUtil.SetMustColorCaption(Gokei_irai_su_lbl, base.GetPageContext().FormInfo["Gokei_irai_su"]);
			ControlUtil.SetControlValue(Gokei_genkakin_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Gokei_genkakin", lang), base.GetPageContext().FormInfo["Gokei_genkakin"]));
				DataFormatUtil.SetMustColorCaption(Gokei_genkakin_lbl, base.GetPageContext().FormInfo["Gokei_genkakin"]);
			ControlUtil.SetControlValue(Footer_zan_kin_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Footer_zan_kin", lang), base.GetPageContext().FormInfo["Footer_zan_kin"]));
				DataFormatUtil.SetMustColorCaption(Footer_zan_kin_lbl, base.GetPageContext().FormInfo["Footer_zan_kin"]);
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
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumonkana_nm", lang), base.GetPageContext().FormInfo["M1bumonkana_nm"]);
				// M1.Columns[2].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1ten_hyoka_kb", lang), base.GetPageContext().FormInfo["M1ten_hyoka_kb"]);
				// M1.Columns[3].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1all_hyoka_kb", lang), base.GetPageContext().FormInfo["M1all_hyoka_kb"]);
				// M1.Columns[4].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tosyu_uriage_su", lang), base.GetPageContext().FormInfo["M1tosyu_uriage_su"]);
				// M1.Columns[5].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hinsyu_ryaku_nm", lang), base.GetPageContext().FormInfo["M1hinsyu_ryaku_nm"]);
				// M1.Columns[6].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1zensyu_uriage_su", lang), base.GetPageContext().FormInfo["M1zensyu_uriage_su"]);
				// M1.Columns[7].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1zenzensyu_uriage_su", lang), base.GetPageContext().FormInfo["M1zenzensyu_uriage_su"]);
				// M1.Columns[8].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1burando_nm", lang), base.GetPageContext().FormInfo["M1burando_nm"]);
				// M1.Columns[9].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1nyukayotei_su", lang), base.GetPageContext().FormInfo["M1nyukayotei_su"]);
				// M1.Columns[10].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tenzaiko_su", lang), base.GetPageContext().FormInfo["M1tenzaiko_su"]);
				// M1.Columns[11].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1jido_su", lang), base.GetPageContext().FormInfo["M1jido_su"]);
				// M1.Columns[12].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1haibunkano_su", lang), base.GetPageContext().FormInfo["M1haibunkano_su"]);
				// M1.Columns[13].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1jisya_hbn", lang), base.GetPageContext().FormInfo["M1jisya_hbn"]);
				// M1.Columns[14].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1keikaku_ymd", lang), base.GetPageContext().FormInfo["M1keikaku_ymd"]);
				// M1.Columns[15].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syohin_zokusei", lang), base.GetPageContext().FormInfo["M1syohin_zokusei"]);
				// M1.Columns[16].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1lot_su", lang), base.GetPageContext().FormInfo["M1lot_su"]);
				// M1.Columns[17].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1maker_hbn", lang), base.GetPageContext().FormInfo["M1maker_hbn"]);
				// M1.Columns[18].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syonmk", lang), base.GetPageContext().FormInfo["M1syonmk"]);
				// M1.Columns[19].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1iro_nm", lang), base.GetPageContext().FormInfo["M1iro_nm"]);
				// M1.Columns[20].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1size_nm", lang), base.GetPageContext().FormInfo["M1size_nm"]);
				// M1.Columns[21].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1scan_cd", lang), base.GetPageContext().FormInfo["M1scan_cd"]);
				// M1.Columns[22].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1irai_su", lang), base.GetPageContext().FormInfo["M1irai_su"]);
				// M1.Columns[23].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hatchu_msg", lang), base.GetPageContext().FormInfo["M1hatchu_msg"]);
				// M1.Columns[24].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1genkakin", lang), base.GetPageContext().FormInfo["M1genkakin"]);
				// M1.Columns[25].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hanbaiin_nm", lang), base.GetPageContext().FormInfo["M1hanbaiin_nm"]);
				// M1.Columns[26].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1irairiyu_cd1", lang), base.GetPageContext().FormInfo["M1irairiyu_cd1"]);
				// M1.Columns[27].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1irairiyu_cd2", lang), base.GetPageContext().FormInfo["M1irairiyu_cd2"]);
				// M1.Columns[28].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1add_ymd", lang), base.GetPageContext().FormInfo["M1add_ymd"]);
				// M1.Columns[29].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hanbaikanryo_ymd", lang), base.GetPageContext().FormInfo["M1hanbaikanryo_ymd"]);
				// M1.Columns[30].HeaderText = 
				// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1uriage_su_hdn", lang), base.GetPageContext().FormInfo["M1uriage_su_hdn"]);
				// M1.Columns[31].HeaderText = 
				// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1irai_su_hdn", lang), base.GetPageContext().FormInfo["M1irai_su_hdn"]);
				// M1.Columns[32].HeaderText = 
				// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1irairiyu_cd_hdn1", lang), base.GetPageContext().FormInfo["M1irairiyu_cd_hdn1"]);
				// M1.Columns[33].HeaderText = 
				// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1irairiyu_cd_hdn2", lang), base.GetPageContext().FormInfo["M1irairiyu_cd_hdn2"]);
				// M1.Columns[34].HeaderText = 
				// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1gen_tnk", lang), base.GetPageContext().FormInfo["M1gen_tnk"]);
				// M1.Columns[35].HeaderText = 
				// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1genkakin_hdn", lang), base.GetPageContext().FormInfo["M1genkakin_hdn"]);
				// M1.Columns[36].HeaderText = 
				// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1selectorcheckbox", lang), base.GetPageContext().FormInfo["M1selectorcheckbox"]);
				// M1.Columns[37].HeaderText = 
				// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1entersyoriflg", lang), base.GetPageContext().FormInfo["M1entersyoriflg"]);
				// M1.Columns[38].HeaderText = 
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
				Windowtitle.InnerText = formResource.GetString("Ta080f03_Titlebar", lang);
				header.FormName = formResource.GetString("Ta080f03_FormCaption", lang);
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
