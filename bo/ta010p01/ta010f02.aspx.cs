using com.xebio.bo.Ta010p01.Constant;
using com.xebio.bo.Ta010p01.Facade;
using com.xebio.bo.Ta010p01.Formvo;
using com.xebio.bo.Ta010p01.Util;
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

namespace com.xebio.bo.Ta010p01.Page
{
  /// <summary>
  /// Ta010f02のコードビハインドです。
  /// </summary>
  public partial class Ta010f02Page : StandardBasePage
	{

		#region メソッド

		#region ページデータをロードするメソッド
		/// <summary>
		/// Ta010f02画面データを作成する。
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
					if (commandInfo.PageLoadMode && commandInfo.ActionMode != null)
					{
						pageContext.SetFormVO(new Ta010f02Form());
						switch (commandInfo.ActionMode)
						{
							case "ADD":
								break;
							case "INI":
							case "DEL":
							case "UPD":
								IFacadeContext facadeContext =
									FacadeContextFactory.GetFacadeContext(pageContext);
								InitFacadeContext(facadeContext);
								new Ta010f02Facade().DoLoad(facadeContext);
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
				new Ta010f02Facade().DoBTNBACK_FRM(facadeContext);
				
				
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
				if (((Ta010f02Form)pageContext.GetFormVO()).Stkmodeno.Equals(BoSystemConstant.MODE_INSERT))
				{
					commandInfo.ActionMode = "INI";
					commandInfo.PageLoadMode = true;
					// 新規作成の場合、モード表示クリア処理
					ModeUtil.ClearMode(pageContext);
				}
				else
				{
					//他の処理モードを設定する必要がある場合、次の行を修正してください
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
			// 新規作成以外の場合
			if (!((Ta010f02Form)pageContext.GetFormVO()).Stkmodeno.Equals(BoSystemConstant.MODE_INSERT))
			{
				// フォーカス設定用変数
				string focusItem = string.Empty;
				string focusMno = string.Empty;

				// 選択された管理番号にフォーカス設定
				focusItem = "M1kanri_no";
				focusMno = (string)((Ta010f02Form)pageContext.GetFormVO(Ta010p01Constant.PGID, Ta010p01Constant.FORMID_02)).Dictionary[Ta010p01Constant.DIC_M1SELCETROWIDX];

				// フォーカス設定
				SetFocusCls.SetFocus(queryList, focusItem, focusMno);
			}

			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNBACK_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion

		#region フォームを呼び出します(ボタンID : Btnzenstk(全選択))
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnzenstk(全選択))
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
				new Ta010f02Facade().DoBTNZENSTK_FRM(facadeContext);
				
				
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

		#region フォームを呼び出します(ボタンID : Btnzenkjo(全解除))
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnzenkjo(全解除))
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
				new Ta010f02Facade().DoBTNZENKJO_FRM(facadeContext);
				
				
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

		#region M1明細の行を増やします(ボタンID : Btnrowins(行追加))
		/// <summary>
		/// M1明細の行を増やします。
		/// ボタンID(Btnrowins(行追加))
		/// アクションID(MADD)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnBTNROWINS_MADD(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnBTNROWINS_MADD");
			//フォーカスセット用インデックス
			string index;
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
				new Ta010f02Facade().DoBTNROWINS_MADD(facadeContext);
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

		#region 明細の行を増やします(ボタンID : Btnpageins(ページ追加))
		/// <summary>
		/// 明細の行を増やします。
		/// ボタンID(Btnpageins(ページ追加))
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
				new Ta010f02Facade().DoBTNPAGEINS_MINSX(facadeContext);
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

		#region フォームを呼び出します(ボタンID : Btnsizstk(サイズ選択))
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnsizstk(サイズ選択))
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
				// new Ta010f02Facade().DoBTNSIZSTK_FRM(facadeContext);

				// セッションにサイズ検索戻り値が設定されている場合
				if (Session[OpenTm040p01Cls.KEY_SIZE_SEARCH_RESULT] != null)
				{

					// セッションからファサードコンテキストに設定
					facadeContext.SetUserObject(Ta010p01Constant.KEY_SIZE_SEARCH_RESULT, Session[OpenTm040p01Cls.KEY_SIZE_SEARCH_RESULT]);

					new Ta010f02Facade().DoBTNSIZSTK_FRM(facadeContext);

					// フォーカスインデックスを取得
					focusMno = (string)facadeContext.GetUserObject(Ta010p01Constant.KEY_SIZE_FOCUS_INDEX);
				}
				else
				{
					#region サイズ検索画面起動パラメータ設定
					// フォームオブジェクト取得
					Ta010f02Form formVo = (Ta010f02Form)pageContext.GetFormVO();

					// 発注マスタ検索用情報設定
					SearchHachuVO searchHachuVO = new SearchHachuVO();
					searchHachuVO.Tencd = formVo.Head_tenpo_cd;			// 店舗コード
					searchHachuVO.Sijino = string.Empty;				// 指示NO（移動出荷マニュアル、返品マニュアル用）
					searchHachuVO.Syukakaisyacd = string.Empty;			// 出荷会社コード（移動出荷マニュアル)
					searchHachuVO.Nyukakaisyacd = string.Empty;			// 入荷会社コード（移動出荷マニュアル)
					searchHachuVO.Sijitencd	= string.Empty;				// 指示店舗コード（移動出荷マニュアル、返品マニュアル用）

					// 最大件数
					int dMaxCnt = 0;
					// 新規作成
					if (BoSystemConstant.MODE_INSERT.Equals(formVo.Stkmodeno))
					{
						dMaxCnt = decimal.ToInt32(GetMaxCntCls.GetMaxCnt(facadeContext.CommandInfo.FormId.ToUpper(), "1"));
					}
					else
					{
						dMaxCnt = decimal.ToInt32(GetMaxCntCls.GetMaxCnt(facadeContext.CommandInfo.FormId.ToUpper(), "2"));
					}

					#endregion

					// サイズ検索画面起動
					OpenTm040p01Cls.OpenTm040p01( Page
												, Tm040p01Constant.FORMID_TA010F02
												, Ta010p01Util.GetRowCnt(formVo.GetList("M1"))
												, dMaxCnt
												, searchHachuVO
												, formVo.Kbn_cd
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
				// セッションにサイズ検索戻り値が設定されている場合
				if (Session[OpenTm040p01Cls.KEY_SIZE_SEARCH_RESULT] != null)
				{
					// セッションから削除
					Session.Remove(OpenTm040p01Cls.KEY_SIZE_SEARCH_RESULT);
				}

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

		#region フォームを呼び出します(ボタンID : Btnrowdel(行削除))
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnrowdel(行削除))
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnBTNROWDEL_FRM(object sender, System.EventArgs e)
		{
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

			// フォーカスセット用インデックス
			string index;
			
			try
			{

				//アクションロジックを処理します
				IFacadeContext facadeContext = FacadeContextFactory.GetFacadeContext(pageContext);
				InitFacadeContext(facadeContext);
				new Ta010f02Facade().DoBTNROWDEL_FRM(facadeContext);
				
				
				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
					base.SetError(pageContext);
					return;
				}

				// フォーカスセット用インデックス
				index = facadeContext.GetUserObject(Ta010p01Constant.FCDUO_FOCUSROW) as string;
				
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
				new Ta010f02Facade().DoPGR_PGN(facadeContext, pageindex);
				
				
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
				Ta010f01Form f01VO = (Ta010f01Form)fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Ta010p01Constant.FORMID_01);
				// 明細画面VO
				Ta010f02Form f02VO = (Ta010f02Form)facadeContext.FormVO;
				sStkmodeno = f02VO.Stkmodeno;

				// 単品レポートメッセージでいいえが押された場合、ファサードの呼び出しをしない
				if (!"2".Equals(BoSystemString.Nvl(this.Request[BoSystemConstant.TANPIN_TOUROKU_FLG])))
				{
					// 単品レポートメッセージ用hidden項目がある場合、ファサードに渡す
					if (this.Request[BoSystemConstant.TANPIN_TOUROKU_FLG] != null)
					{
						facadeContext.SetUserObject(BoSystemConstant.TANPIN_FCD_KEY, this.Request[BoSystemConstant.TANPIN_TOUROKU_FLG]);
					}

					new Ta010f02Facade().DoBTNENTER_FRM(facadeContext);

					// 一覧画面VO
					fvm = new FormVOManager(Session);
					f01VO = (Ta010f01Form)fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Ta010p01Constant.FORMID_01);
					// 明細画面VO
					f02VO = (Ta010f02Form)facadeContext.FormVO;
					sStkmodeno = f02VO.Stkmodeno;
					IDataList m1List = f01VO.GetList("M1");

					// 警告判定
					if (InfoMsgCls.HasWarn(facadeContext))
					{
						string script = "";
						if (Convert.ToString(Ta010p01Constant.FLG_ON).Equals(f02VO.Dictionary[Ta010p01Constant.DIC_TANPIN_REPORT_FLG]))
						{
							// 警告メッセージの表示(単品レポート)
							script = InfoMsgCls.showLoadMsg(pageContext, 3, "Btnenter");
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
						if (Ta010p01Constant.FLG_ON.ToString().Equals(f02VO.Dictionary[Ta010p01Constant.DIC_TANPIN_TOUROKU_MODE_FLG]))
						{
							SetItems();
							SetAttribute();
							return;
						}
					}
				}

				// 次画面のフォームビーンを設定
				fvm.SetFormVO(Ta010p01Constant.PGID, Ta010p01Constant.FORMID_01, f01VO);

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
					// [依頼日from]にフォーカスを当てる。
					focusItem = "Irai_ymd_from";
				}
			}
			else
			{
				// 選択された管理Noにフォーカス設定
				focusItem = "M1kanri_no";
				focusMno = (string)((Ta010f02Form)pageContext.GetFormVO(Ta010p01Constant.PGID, Ta010p01Constant.FORMID_02)).Dictionary[Ta010p01Constant.DIC_M1SELCETROWIDX];
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
					// エラー時の画面表示対応 --------------------------------  str
					//if (!MessageDisplayUtil.HasError(pageContext))
					//{
					// エラー時の画面表示対応 --------------------------------  end
						string lang = WebSettingsUtil.GetLangSettingFromSession(pageContext.Session);
						FormResource formResource =
							ResourceFactory.GetFormResource(pageContext.CommandInfo.FormId);
			
						//標題をセットする
						SetCaption(formResource, lang);

						//FormVOを取得する
						Ta010f02Form ta010f02Form = (Ta010f02Form)pageContext.GetFormVO();

						//明細ページ情報を表示する
						ShowListPageInfo(ta010f02Form);
			
						//明細部データを表示する
						RenderList(ta010f02Form, pageContext.FormInfo, formResource, lang);

						//カード部データを表示する
						RenderCard(ta010f02Form, pageContext.FormInfo, formResource, lang);
					// エラー時の画面表示対応 --------------------------------  str
					//}
					// エラー時の画面表示対応 --------------------------------  end

						// 明細エラー背景色対応 ----- START
						//エラー判定
						if (MessageDisplayUtil.HasError(FacadeContextFactory.GetFacadeContext(base.GetPageContext())))
						{
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
		/// <param name="ta010f02Form">画面FormVO</param>
		private void ShowListPageInfo(Ta010f02Form ta010f02Form)
		{
			//M1明細ページ情報を表示する。
			ShowM1ListPageInfo(ta010f02Form.GetList("M1"));

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
		/// <param name="ta010f02Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderList(
			Ta010f02Form ta010f02Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//画面のM1明細部データを設定する。
			RenderM1List(ta010f02Form, formInfo, formResource, lang);
			//M1明細部のページャーにページ情報を設定する。
			RenderM1Pager(ta010f02Form);
			
		}
		#endregion

		#region M1明細データを表示する
		/// <summary>
		/// M1明細データを表示する。
		/// </summary>
		/// <param name="ta010f02Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderM1List(
			Ta010f02Form ta010f02Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//M1明細部データソースを設定する。
			M1.DataSource = ta010f02Form.GetPageViewList("M1");
			M1.DataBind();

			//M1明細部データをフォーマットする。
			IList m1DataList = (IList)M1.DataSource;
			
			for (int index = 0; index < M1.Items.Count; index++)
			{
				Ta010f02M1Form ta010f02M1Form = (Ta010f02M1Form)m1DataList[index];
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1rowno"),
					DataFormatUtil.GetFormatItem(ta010f02M1Form.M1rowno,formInfo["M1rowno"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1bumonkana_nm"),
					DataFormatUtil.GetFormatItem(ta010f02M1Form.M1bumonkana_nm,formInfo["M1bumonkana_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1hyoka_kb"),
					DataFormatUtil.GetFormatItem(ta010f02M1Form.M1hyoka_kb,formInfo["M1hyoka_kb"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1kahi_nm"),
					DataFormatUtil.GetFormatItem(ta010f02M1Form.M1kahi_nm,formInfo["M1kahi_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1tenzaiko_su"),
					DataFormatUtil.GetFormatItem(ta010f02M1Form.M1tenzaiko_su,formInfo["M1tenzaiko_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1hinsyu_ryaku_nm"),
					DataFormatUtil.GetFormatItem(ta010f02M1Form.M1hinsyu_ryaku_nm,formInfo["M1hinsyu_ryaku_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1nyukayotei_su"),
					DataFormatUtil.GetFormatItem(ta010f02M1Form.M1nyukayotei_su,formInfo["M1nyukayotei_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1uriage_su"),
					DataFormatUtil.GetFormatItem(ta010f02M1Form.M1uriage_su,formInfo["M1uriage_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1burando_nm"),
					DataFormatUtil.GetFormatItem(ta010f02M1Form.M1burando_nm,formInfo["M1burando_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1jido_su"),
					DataFormatUtil.GetFormatItem(ta010f02M1Form.M1jido_su,formInfo["M1jido_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1haibunkano_su"),
					DataFormatUtil.GetFormatItem(ta010f02M1Form.M1haibunkano_su,formInfo["M1haibunkano_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1jisya_hbn"),
					DataFormatUtil.GetFormatItem(ta010f02M1Form.M1jisya_hbn,formInfo["M1jisya_hbn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1irai_syukei"),
					DataFormatUtil.GetFormatItem(ta010f02M1Form.M1irai_syukei,formInfo["M1irai_syukei"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1syohin_zokusei"),
					DataFormatUtil.GetFormatItem(ta010f02M1Form.M1syohin_zokusei,formInfo["M1syohin_zokusei"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1lot_su"),
					DataFormatUtil.GetFormatItem(ta010f02M1Form.M1lot_su,formInfo["M1lot_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1iro_nm"),
					DataFormatUtil.GetFormatItem(ta010f02M1Form.M1iro_nm,formInfo["M1iro_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1size_nm"),
					DataFormatUtil.GetFormatItem(ta010f02M1Form.M1size_nm,formInfo["M1size_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1maker_hbn"),
					DataFormatUtil.GetFormatItem(ta010f02M1Form.M1maker_hbn,formInfo["M1maker_hbn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1syonmk"),
					DataFormatUtil.GetFormatItem(ta010f02M1Form.M1syonmk,formInfo["M1syonmk"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1hatchu_msg"),
					DataFormatUtil.GetFormatItem(ta010f02M1Form.M1hatchu_msg,formInfo["M1hatchu_msg"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1irai_su"),
					DataFormatUtil.GetFormatItem(ta010f02M1Form.M1irai_su,formInfo["M1irai_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1scan_cd"),
					DataFormatUtil.GetFormatItem(ta010f02M1Form.M1scan_cd,formInfo["M1scan_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1genkakin"),
					DataFormatUtil.GetFormatItem(ta010f02M1Form.M1genkakin,formInfo["M1genkakin"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1irai_su_hdn"),
					DataFormatUtil.GetFormatItem(ta010f02M1Form.M1irai_su_hdn,formInfo["M1irai_su_hdn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1gen_tnk"),
					DataFormatUtil.GetFormatItem(ta010f02M1Form.M1gen_tnk,formInfo["M1gen_tnk"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1genkakin_hdn"),
					DataFormatUtil.GetFormatItem(ta010f02M1Form.M1genkakin_hdn,formInfo["M1genkakin_hdn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1selectorcheckbox"),
					DataFormatUtil.GetFormatItem(ta010f02M1Form.M1selectorcheckbox,formInfo["M1selectorcheckbox"]));
				((System.Web.UI.WebControls.CheckBox)M1.Items[index].FindControl("M1selectorcheckbox")).Text =
					formResource.GetString("M1selectorcheckbox", lang);
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1entersyoriflg"),
					DataFormatUtil.GetFormatItem(ta010f02M1Form.M1entersyoriflg,formInfo["M1entersyoriflg"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1dtlirokbn"),
					DataFormatUtil.GetFormatItem(ta010f02M1Form.M1dtlirokbn,formInfo["M1dtlirokbn"]));

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
				// (M1.HeaderRow.FindControl("M1hyoka_kb") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hyoka_kb", lang), base.GetPageContext().FormInfo["M1hyoka_kb"]);
				// (M1.HeaderRow.FindControl("M1kahi_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kahi_nm", lang), base.GetPageContext().FormInfo["M1kahi_nm"]);
				// (M1.HeaderRow.FindControl("M1tenzaiko_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tenzaiko_su", lang), base.GetPageContext().FormInfo["M1tenzaiko_su"]);
				// (M1.HeaderRow.FindControl("M1hinsyu_ryaku_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hinsyu_ryaku_nm", lang), base.GetPageContext().FormInfo["M1hinsyu_ryaku_nm"]);
				// (M1.HeaderRow.FindControl("M1nyukayotei_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1nyukayotei_su", lang), base.GetPageContext().FormInfo["M1nyukayotei_su"]);
				// (M1.HeaderRow.FindControl("M1uriage_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1uriage_su", lang), base.GetPageContext().FormInfo["M1uriage_su"]);
				// (M1.HeaderRow.FindControl("M1burando_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1burando_nm", lang), base.GetPageContext().FormInfo["M1burando_nm"]);
				// (M1.HeaderRow.FindControl("M1jido_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1jido_su", lang), base.GetPageContext().FormInfo["M1jido_su"]);
				// (M1.HeaderRow.FindControl("M1haibunkano_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1haibunkano_su", lang), base.GetPageContext().FormInfo["M1haibunkano_su"]);
				// (M1.HeaderRow.FindControl("M1jisya_hbn") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1jisya_hbn", lang), base.GetPageContext().FormInfo["M1jisya_hbn"]);
				// (M1.HeaderRow.FindControl("M1irai_syukei") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1irai_syukei", lang), base.GetPageContext().FormInfo["M1irai_syukei"]);
				// (M1.HeaderRow.FindControl("M1syohin_zokusei") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syohin_zokusei", lang), base.GetPageContext().FormInfo["M1syohin_zokusei"]);
				// (M1.HeaderRow.FindControl("M1lot_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1lot_su", lang), base.GetPageContext().FormInfo["M1lot_su"]);
				// (M1.HeaderRow.FindControl("M1iro_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1iro_nm", lang), base.GetPageContext().FormInfo["M1iro_nm"]);
				// (M1.HeaderRow.FindControl("M1size_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1size_nm", lang), base.GetPageContext().FormInfo["M1size_nm"]);
				// (M1.HeaderRow.FindControl("M1maker_hbn") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1maker_hbn", lang), base.GetPageContext().FormInfo["M1maker_hbn"]);
				// (M1.HeaderRow.FindControl("M1syonmk") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syonmk", lang), base.GetPageContext().FormInfo["M1syonmk"]);
				// (M1.HeaderRow.FindControl("M1hatchu_msg") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hatchu_msg", lang), base.GetPageContext().FormInfo["M1hatchu_msg"]);
				// (M1.HeaderRow.FindControl("M1irai_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1irai_su", lang), base.GetPageContext().FormInfo["M1irai_su"]);
				// (M1.HeaderRow.FindControl("M1scan_cd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1scan_cd", lang), base.GetPageContext().FormInfo["M1scan_cd"]);
				// (M1.HeaderRow.FindControl("M1genkakin") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1genkakin", lang), base.GetPageContext().FormInfo["M1genkakin"]);
				// (M1.HeaderRow.FindControl("M1irai_su_hdn") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1irai_su_hdn", lang), base.GetPageContext().FormInfo["M1irai_su_hdn"]);
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
		/// <param name="ta010f02Form">画面FormVO</param>
		private void RenderM1Pager(Ta010f02Form ta010f02Form)
		{
			Pgr.VirtualItemCount = ta010f02Form.GetList("M1").RecordCount;
			Pgr.CurrentPageIndex = ta010f02Form.GetList("M1").PageNo - 1;
			Pgr.PageSize = ta010f02Form.GetList("M1").DispRow;
		}
		#endregion
		#endregion

		#region カードデータを表示する
		/// <summary>
		/// カードデータを表示する
		/// </summary>
		/// <param name="ta010f02Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderCard(
			Ta010f02Form ta010f02Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			
			ControlUtil.SetControlValue(Head_tenpo_cd,
				DataFormatUtil.GetFormatItem(ta010f02Form.Head_tenpo_cd,formInfo["Head_tenpo_cd"]));
			ControlUtil.SetControlValue(Head_tenpo_nm,
				DataFormatUtil.GetFormatItem(ta010f02Form.Head_tenpo_nm,formInfo["Head_tenpo_nm"]));
			ControlUtil.SetControlValue(Stkmodeno,
				DataFormatUtil.GetFormatItem(ta010f02Form.Stkmodeno,formInfo["Stkmodeno"]));
			ControlUtil.SetControlValue(Kbn_cd,
				DataFormatUtil.GetFormatItem(ta010f02Form.Kbn_cd,formInfo["Kbn_cd"]));
			ControlUtil.SetControlValue(Hattyu_ymd,
				DataFormatUtil.GetFormatItem(ta010f02Form.Hattyu_ymd,formInfo["Hattyu_ymd"]));
			ControlUtil.SetControlValue(Tantosya_cd,
				DataFormatUtil.GetFormatItem(ta010f02Form.Tantosya_cd,formInfo["Tantosya_cd"]));
			ControlUtil.SetControlValue(Hanbaiin_nm,
				DataFormatUtil.GetFormatItem(ta010f02Form.Hanbaiin_nm,formInfo["Hanbaiin_nm"]));
			ControlUtil.SetControlValue(Irairiyu_cd1,
				DataFormatUtil.GetFormatItem(ta010f02Form.Irairiyu_cd1, formInfo["Irairiyu_cd1"]));
			ControlUtil.SetControlValue(Irairiyu_cd2,
				DataFormatUtil.GetFormatItem(ta010f02Form.Irairiyu_cd2, formInfo["Irairiyu_cd2"]));
			ControlUtil.SetControlValue(Gokei_irai_su,
				DataFormatUtil.GetFormatItem(ta010f02Form.Gokei_irai_su,formInfo["Gokei_irai_su"]));
			ControlUtil.SetControlValue(Gokei_genkakin,
				DataFormatUtil.GetFormatItem(ta010f02Form.Gokei_genkakin,formInfo["Gokei_genkakin"]));

			if(!base.CheckUseSelfCustomize()){
				Btnback.Value = base.FormResourceGetString(formResource, "Btnback", lang);
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
			// UIScreenController controller = new UIScreenController((Ta010f02Form)base.GetPageContext().GetFormVO());
			// controller.ChangeColumnsDisplayMode(M1 ,  new DetailHeaderFixedVO(M1Header , true) , null);

			/*
			 *登録した機能間連携処理を親画面に感知させる。
			 *機能有効させる場合は、コメントアウトを外してください。
			 */
			//DetailUtil.RunPgSyn(this,(StandardBaseForm)base.GetPageContext().GetFormVO());
			#region 画面表示制御
			Ta010f02Form formVo = (Ta010f02Form)base.GetPageContext().GetFormVO();
			IDataList m1List = formVo.GetList("M1");

			// [選択モードNo]が「新規」の場合
			// [選択モードNo]が「申請」の場合
			// [選択モードNo]が「修正」の場合
			if (BoSystemString.Nvl(formVo.Stkmodeno).Equals(BoSystemConstant.MODE_INSERT)
			|| BoSystemString.Nvl(formVo.Stkmodeno).Equals(BoSystemConstant.MODE_APPLY)
			|| BoSystemString.Nvl(formVo.Stkmodeno).Equals(BoSystemConstant.MODE_UPD))
			{
				// --------------------------------------------------------------
				// 新規作成判定
				// --------------------------------------------------------------
				// [選択モードNo]が「新規」の場合
				if (BoSystemString.Nvl(formVo.Stkmodeno).Equals(BoSystemConstant.MODE_INSERT))
				{
					// 依頼理由コード使用可
					ControlCls.Disable(Irairiyu_cd1, false);
					ControlCls.Disable(Irairiyu_cd2, false);
					// 行追加ボタン非表示
					ControlCls.Visible(Btnrowins, false);
					ControlCls.Visible(Spanrowins, false);
					// 単品登録モード判定
					if (Ta010p01Constant.FLG_ON.ToString().Equals(formVo.Dictionary[Ta010p01Constant.DIC_TANPIN_TOUROKU_MODE_FLG]))
					{
						// 区分コード使用不可
						ControlCls.Disable(Kbn_cd, true);
						// ページ追加ボタン表示
						// ページ追加ボタン使用不可
						ControlCls.Visible(Btnpageins, true);
						ControlCls.Disable(Btnpageins, true);
						ControlCls.Visible(Spanpageins, true);
					}
					else
					{
						// 区分コード使用可
						ControlCls.Disable(Kbn_cd, false);
						// ページ追加ボタン表示
						// ページ追加ボタン使用可
						ControlCls.Visible(Btnpageins, true);
						ControlCls.Disable(Btnpageins, false);
						ControlCls.Visible(Spanpageins, true);
					}
				}
				// [選択モードNo]が「申請」の場合
				// [選択モードNo]が「修正」の場合
				else
				{
					// 区分コード使用不可
					ControlCls.Disable(Kbn_cd, true);
					// 行追加ボタン表示
					ControlCls.Visible(Btnrowins, true);
					ControlCls.Visible(Spanrowins, true);
					if (BoSystemString.Nvl(formVo.Stkmodeno).Equals(BoSystemConstant.MODE_UPD))
					{
						// 依頼理由コード使用可
						ControlCls.Disable(Irairiyu_cd1, false);
						ControlCls.Disable(Irairiyu_cd2, false);
						// 修正の場合、行追加ボタン使用可
						ControlCls.Disable(Btnrowins, false);
					}
					else
					{
						// 依頼理由コード使用不可
						ControlCls.Disable(Irairiyu_cd1, true);
						ControlCls.Disable(Irairiyu_cd2, true);
						// 申請の場合、行追加ボタン使用不可
						ControlCls.Disable(Btnrowins, true);
					}
					// ページ追加ボタン非表示
					ControlCls.Visible(Btnpageins, false);
					ControlCls.Visible(Spanpageins, false);
				}

				// --------------------------------------------------------------
				// 申請判定
				// --------------------------------------------------------------
				// [選択モードNo]が「申請」の場合
				if (BoSystemString.Nvl(formVo.Stkmodeno).Equals(BoSystemConstant.MODE_APPLY))
				{
					// 全選択ボタン使用可
					ControlCls.Disable(Btnzenstk, false);
					// 全解除ボタン使用可
					ControlCls.Disable(Btnzenkjo, false);
					// サイズ選択ボタン使用不可
					ControlCls.Disable(Btnsizstk, true);
					// 行削除ボタン使用不可
					ControlCls.Disable(Btnrowdel, true);
					// 明細情報
					for (int index = 0; index < M1.Items.Count; index++)
					{
						// スキャンコード、数量を使用不可とする。
						ControlCls.Disable(((MDTextBox)M1.Items[index].FindControl("M1scan_cd")), true);
						ControlCls.Disable(((MDTextBox)M1.Items[index].FindControl("M1irai_su")), true);
						// 選択を使用可とする。
						((AdvancedCheckBox)M1.Items[index].FindControl("M1selectorcheckbox")).Visible = true;
					}
				}
				// [選択モードNo]が「新規」の場合
				// [選択モードNo]が「修正」の場合
				else
				{
					// 全選択ボタン使用不可
					ControlCls.Disable(Btnzenstk, true);
					// 全解除ボタン使用不可
					ControlCls.Disable(Btnzenkjo, true);
					// サイズ選択ボタン使用可
					ControlCls.Disable(Btnsizstk, false);
					// 行削除ボタン使用可
					ControlCls.Disable(Btnrowdel, false);
					// 明細情報
					for (int index = 0; index < M1.Items.Count; index++)
					{
						// 単品登録モード判定
						if (Ta010p01Constant.FLG_ON.ToString().Equals(formVo.Dictionary[Ta010p01Constant.DIC_TANPIN_TOUROKU_MODE_FLG]))
						{
							// スキャンコード、数量を使用不可とする。
							ControlCls.Disable(((MDTextBox)M1.Items[index].FindControl("M1scan_cd")), true);
							// 数量修正可能な場合数量を使用可
							if (Ta010p01Constant.FLG_ON.ToString().Equals(((Ta010f02M1Form)m1List[index]).Dictionary[Ta010p01Constant.DIC_M1TANPIN_UPD_FLG]))
							{
								ControlCls.Disable(((MDTextBox)M1.Items[index].FindControl("M1irai_su")), false);
							}
							else
							{
								ControlCls.Disable(((MDTextBox)M1.Items[index].FindControl("M1irai_su")), true);
							}
						}
						else
						{
							// スキャンコード、数量を使用可とする。
							ControlCls.Disable(((MDTextBox)M1.Items[index].FindControl("M1scan_cd")), false);
							ControlCls.Disable(((MDTextBox)M1.Items[index].FindControl("M1irai_su")), false);
						}
						// 選択を使用可とする。
						((AdvancedCheckBox)M1.Items[index].FindControl("M1selectorcheckbox")).Visible = true;
					}

				}
				// 確定ボタン使用可
				ControlCls.Disable(Btnenter, false);
			}
			else
			{
				// 区分コード使用不可
				ControlCls.Disable(Kbn_cd, true);
				// 依頼理由コード使用不可
				ControlCls.Disable(Irairiyu_cd1, true);
				ControlCls.Disable(Irairiyu_cd2, true);
				// 全選択ボタン使用不可
				ControlCls.Disable(Btnzenstk, true);
				// 全解除ボタン使用不可
				ControlCls.Disable(Btnzenkjo, true);
				// 行追加ボタン表示
				// 行追加ボタン使用不可
				ControlCls.Visible(Btnrowins, true);
				ControlCls.Disable(Btnrowins, true);
				ControlCls.Visible(Spanrowins, true);
				// ページ追加ボタン非表示
				ControlCls.Visible(Btnpageins, false);
				ControlCls.Visible(Spanpageins, false);
				// サイズ選択ボタン使用不可
				ControlCls.Disable(Btnsizstk, true);
				// 行削除ボタン使用不可
				ControlCls.Disable(Btnrowdel, true);
				// 明細情報
				for (int index = 0; index < M1.Items.Count; index++)
				{
					// スキャンコード、数量を使用不可とする。
					ControlCls.Disable(((MDTextBox)M1.Items[index].FindControl("M1scan_cd")), true);
					ControlCls.Disable(((MDTextBox)M1.Items[index].FindControl("M1irai_su")), true);
					// 選択を使用不可とする。
					((AdvancedCheckBox)M1.Items[index].FindControl("M1selectorcheckbox")).Visible = false;
				}
				// 確定ボタン使用不可
				ControlCls.Disable(Btnenter, true);
			}
			#endregion
			// 区分を設定
			if (string.IsNullOrEmpty(Kbn_cd.Text) || Kbn_cd.Text == BoSystemConstant.DROPDOWNLIST_MISENTAKU)
			{
				Kbn_cd.SelectedIndex = 1;
			}

			// 依頼理由を設定
			if (string.IsNullOrEmpty(Irairiyu_cd1.Text) || Irairiyu_cd1.Text == BoSystemConstant.DROPDOWNLIST_MISENTAKU)
			{
				Irairiyu_cd1.SelectedIndex = 1;
			}
			if (string.IsNullOrEmpty(Irairiyu_cd2.Text) || Irairiyu_cd2.Text == BoSystemConstant.DROPDOWNLIST_MISENTAKU)
			{
				Irairiyu_cd2.SelectedIndex = 1;
			}

			// タブインデックス設定
			// 明細情報
			for (int index = 0; index < M1.Items.Count; index++)
			{
				// スキャンコード、数量を使用不可とする。
				((MDTextBox)M1.Items[index].FindControl("M1scan_cd")).TabIndex = Convert.ToInt16(2 * index);
				((MDTextBox)M1.Items[index].FindControl("M1irai_su")).TabIndex = Convert.ToInt16(2 * index + 1);
			}
			// 確定ボタンのタブインデックスの明細の後に設定
			Btnenter.Attributes.Add("tabindex", (M1.Items.Count * 2).ToString());
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
			ControlUtil.SetControlValue(Kbn_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Kbn_cd", lang), base.GetPageContext().FormInfo["Kbn_cd"]));
				DataFormatUtil.SetMustColorCaption(Kbn_cd_lbl, base.GetPageContext().FormInfo["Kbn_cd"]);
			ControlUtil.SetControlValue(Hattyu_ymd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Hattyu_ymd", lang), base.GetPageContext().FormInfo["Hattyu_ymd"]));
				DataFormatUtil.SetMustColorCaption(Hattyu_ymd_lbl, base.GetPageContext().FormInfo["Hattyu_ymd"]);
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
			ControlUtil.SetControlValue(Gokei_irai_su_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Gokei_irai_su", lang), base.GetPageContext().FormInfo["Gokei_irai_su"]));
				DataFormatUtil.SetMustColorCaption(Gokei_irai_su_lbl, base.GetPageContext().FormInfo["Gokei_irai_su"]);
			ControlUtil.SetControlValue(Gokei_genkakin_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Gokei_genkakin", lang), base.GetPageContext().FormInfo["Gokei_genkakin"]));
				DataFormatUtil.SetMustColorCaption(Gokei_genkakin_lbl, base.GetPageContext().FormInfo["Gokei_genkakin"]);
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
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hyoka_kb", lang), base.GetPageContext().FormInfo["M1hyoka_kb"]);
				// M1.Columns[3].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kahi_nm", lang), base.GetPageContext().FormInfo["M1kahi_nm"]);
				// M1.Columns[4].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tenzaiko_su", lang), base.GetPageContext().FormInfo["M1tenzaiko_su"]);
				// M1.Columns[5].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hinsyu_ryaku_nm", lang), base.GetPageContext().FormInfo["M1hinsyu_ryaku_nm"]);
				// M1.Columns[6].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1nyukayotei_su", lang), base.GetPageContext().FormInfo["M1nyukayotei_su"]);
				// M1.Columns[7].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1uriage_su", lang), base.GetPageContext().FormInfo["M1uriage_su"]);
				// M1.Columns[8].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1burando_nm", lang), base.GetPageContext().FormInfo["M1burando_nm"]);
				// M1.Columns[9].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1jido_su", lang), base.GetPageContext().FormInfo["M1jido_su"]);
				// M1.Columns[10].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1haibunkano_su", lang), base.GetPageContext().FormInfo["M1haibunkano_su"]);
				// M1.Columns[11].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1jisya_hbn", lang), base.GetPageContext().FormInfo["M1jisya_hbn"]);
				// M1.Columns[12].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1irai_syukei", lang), base.GetPageContext().FormInfo["M1irai_syukei"]);
				// M1.Columns[13].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syohin_zokusei", lang), base.GetPageContext().FormInfo["M1syohin_zokusei"]);
				// M1.Columns[14].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1lot_su", lang), base.GetPageContext().FormInfo["M1lot_su"]);
				// M1.Columns[15].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1iro_nm", lang), base.GetPageContext().FormInfo["M1iro_nm"]);
				// M1.Columns[16].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1size_nm", lang), base.GetPageContext().FormInfo["M1size_nm"]);
				// M1.Columns[17].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1maker_hbn", lang), base.GetPageContext().FormInfo["M1maker_hbn"]);
				// M1.Columns[18].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syonmk", lang), base.GetPageContext().FormInfo["M1syonmk"]);
				// M1.Columns[19].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hatchu_msg", lang), base.GetPageContext().FormInfo["M1hatchu_msg"]);
				// M1.Columns[20].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1irai_su", lang), base.GetPageContext().FormInfo["M1irai_su"]);
				// M1.Columns[21].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1scan_cd", lang), base.GetPageContext().FormInfo["M1scan_cd"]);
				// M1.Columns[22].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1genkakin", lang), base.GetPageContext().FormInfo["M1genkakin"]);
				// M1.Columns[23].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1irai_su_hdn", lang), base.GetPageContext().FormInfo["M1irai_su_hdn"]);
				// M1.Columns[24].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1gen_tnk", lang), base.GetPageContext().FormInfo["M1gen_tnk"]);
				// M1.Columns[25].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1genkakin_hdn", lang), base.GetPageContext().FormInfo["M1genkakin_hdn"]);
				// M1.Columns[26].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1selectorcheckbox", lang), base.GetPageContext().FormInfo["M1selectorcheckbox"]);
				// M1.Columns[27].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1entersyoriflg", lang), base.GetPageContext().FormInfo["M1entersyoriflg"]);
				// M1.Columns[28].HeaderText = 
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
				Windowtitle.InnerText = formResource.GetString("Ta010f02_Titlebar", lang);
				header.FormName = formResource.GetString("Ta010f02_FormCaption", lang);
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
