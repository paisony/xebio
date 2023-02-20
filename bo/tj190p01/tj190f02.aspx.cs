using com.xebio.bo.Tj190p01.Constant;
using com.xebio.bo.Tj190p01.Facade;
using com.xebio.bo.Tj190p01.Formvo;
using com.xebio.bo.Tm040p01.Constant;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.Model.Context;
using Common.Advanced.Resource;
using Common.Advanced.Web.Context;
using Common.Advanced.Web.Util;
using Common.Business.C01000.C01003;
using Common.Business.C01000.C01012;
using Common.Business.C01000.C01014;
using Common.Business.C01000.C01015;
using Common.Business.C01000.C01016;
using Common.Business.C01000.C01023;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Conditions;
using Common.IntegrationMD.MDControl;
using Common.IntegrationMD.Util;
using Common.Standard.Base;
using Common.Standard.Message;
using Common.Standard.Util;
using System;
using System.Collections;
using System.Collections.Specialized;

namespace com.xebio.bo.Tj190p01.Page
{
  /// <summary>
  /// Tj190f02のコードビハインドです。
  /// </summary>
  public partial class Tj190f02Page : StandardBasePage
	{

		#region メソッド

		#region ページデータをロードするメソッド
		/// <summary>
		/// Tj190f02画面データを作成する。
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
						pageContext.SetFormVO(new Tj190f02Form());
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
								new Tj190f02Facade().DoLoad(facadeContext);
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
				new Tj190f02Facade().DoBTNBACK_FRM(facadeContext);
				
				
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
			focusMno = (string)((Tj190f02Form)pageContext.GetFormVO(Tj190p01Constant.PGID, Tj190p01Constant.FORMID_02)).Dictionary[Tj190p01Constant.DIC_M1SELCETROWIDX];

			// フォーカス設定
			SetFocusCls.SetFocus(queryList, focusItem, focusMno);
			
			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNBACK_FRM");
			
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
				new Tj190f02Facade().DoBTNROWINS_MADD(facadeContext);
				
				
				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
					base.SetError(pageContext);
					return;
				}

				//アコーディオンを閉じた状態で表示
				AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_CLOSE);
				
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

			// 画面より情報を取得する。
			Tj190f02Form formVO = (Tj190f02Form)pageContext.GetFormVO();

			//M1明細データを表示する。
			IDataList m1List = formVO.GetList("M1");

			//フォーカスを当てる項目を指定したい場合はFormFocusUtilを使ってqueryListに追加すること
			// フォーカス設定用変数
			string focusItem = string.Empty;
			string focusMno = string.Empty;

			// 追加行のページを設定
			//int endpage = (m1List.EndRow / m1List.DispRow) + 1;
			int endpage = m1List.PageCount - 1;
			formVO.GetList("M1").SetPage(endpage);

			// 追加行の次の行にフォーカス設定
			focusItem = "M1scan_cd";
			focusMno = (((Tj190f02Form)pageContext.GetFormVO()).GetList("M1").Count - 1).ToString();

			// フォーカス設定
			SetFocusCls.SetFocus(queryList, focusItem, focusMno);
			
			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNROWINS_MADD");
			
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

			string focusMno = string.Empty;
			
			try
			{

				//アクションロジックを処理します
				IFacadeContext facadeContext = FacadeContextFactory.GetFacadeContext(pageContext);
				InitFacadeContext(facadeContext);
				// new Tj190f02Facade().DoBTNSIZSTK_FRM(facadeContext);

				if (Session[OpenTm040p01Cls.KEY_SIZE_SEARCH_RESULT] != null)
				{
					// セッションにサイズ検索戻り値が設定されている場合

					// セッションからファサードコンテキストに設定
					facadeContext.SetUserObject(Tj190p01Constant.DIC_SIZE_SEARCH_RESULT, Session[OpenTm040p01Cls.KEY_SIZE_SEARCH_RESULT]);

					new Tj190f02Facade().DoBTNSIZSTK_FRM(facadeContext);

					// セッションから削除
					//Session.Remove(OpenTm040p01Cls.KEY_SIZE_SEARCH_RESULT);

					// フォーカスインデックスを取得
					focusMno = (string)facadeContext.GetUserObject(Tj190p01Constant.DIC_FOCUS_INDEX);

					//アコーディオンを閉じた状態で表示
					AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_CLOSE);
				}
				else
				{
					#region サイズ検索画面起動パラメータ設定
					// フォームオブジェクト取得
					Tj190f02Form form = (Tj190f02Form)pageContext.GetFormVO();

					// 画面ID
					string formId = Tm040p01Constant.FORMID_TJ190F02;

					// 現在行数
					int curRowCnt = 0;

					// 明細オブジェクト取得
					IDataList m1List = form.GetList("M1");

					for (int i = m1List.Count - 1; i >= 0; i--)
					{
						// 行オブジェクト取得
						Tj190f02M1Form m1Form = (Tj190f02M1Form)m1List[i];

						if (!string.IsNullOrEmpty(m1Form.M1scan_cd)
							|| !string.IsNullOrEmpty(m1Form.M1jitana_su)
							)
						{
							// いずれかの入力項目が入力されている場合
							curRowCnt = i + 1;
							break;
						}
					}

					// 最大行数
					int maxRowCnt = decimal.ToInt32(GetMaxCntCls.GetMaxCnt(formId, "1"));

					// 発注マスタ検索用情報設定
					SearchHachuVO searchConditionVO = new SearchHachuVO();
					searchConditionVO.Tencd = BoSystemFormat.formatTenpoCd(form.Tenpo_cd_hdn);
					// 後続処理にて押下させるボタンID
					string afterActBtn = this.Btnsizstk.ID;
					#endregion

					// サイズ検索画面起動
					OpenTm040p01Cls.OpenTm040p01(Page, formId, curRowCnt, maxRowCnt, searchConditionVO, afterActBtn);
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
				if (Session[OpenTm040p01Cls.KEY_SIZE_SEARCH_RESULT] != null)
				{
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
			//base.Forward(pageContext, queryList);

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
				new Tj190f02Facade().DoBTNROWDEL_FRM(facadeContext);
				
				
				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
					base.SetError(pageContext);
					return;
				}

				// 明細フォーカスセット用インデックスを取得します。
				index = facadeContext.GetUserObject(Tj190p01Constant.FCDUO_FOCUSROW) as string;

				//アコーディオンを閉じた状態で表示
				AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_CLOSE);
				
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
			// 行削除のフォーカス

			string focusItem = string.Empty;
			string focusMno = string.Empty;

			// 削除行の次の行にフォーカス設定
			focusItem = "M1scan_cd";
			focusMno = (index).ToString();

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
				new Tj190f02Facade().DoPGR_PGN(facadeContext, pageindex);
				
				
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
				new Tj190f02Facade().DoBTNENTER_FRM(facadeContext);
				
				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
					// 明細エラー背景色対応 ----- START
					//base.SetError(pageContext);
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
			// フォーカス設定用変数
			string focusItem = string.Empty;
			string focusMno = string.Empty;

			// 選択された管理Noにフォーカス設定
			focusItem = "M1bumon_cd";
			focusMno = (string)((Tj190f02Form)pageContext.GetFormVO(Tj190p01Constant.PGID, Tj190p01Constant.FORMID_02)).Dictionary[Tj190p01Constant.DIC_M1SELCETROWIDX];

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
						string lang = WebSettingsUtil.GetLangSettingFromSession(pageContext.Session);
						FormResource formResource =
							ResourceFactory.GetFormResource(pageContext.CommandInfo.FormId);
			
						//標題をセットする
						SetCaption(formResource, lang);

						//FormVOを取得する
						Tj190f02Form tj190f02Form = (Tj190f02Form)pageContext.GetFormVO();

						//明細ページ情報を表示する
						ShowListPageInfo(tj190f02Form);
			
						//明細部データを表示する
						RenderList(tj190f02Form, pageContext.FormInfo, formResource, lang);

						//カード部データを表示する
						RenderCard(tj190f02Form, pageContext.FormInfo, formResource, lang);
					//}
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
		/// <param name="tj190f02Form">画面FormVO</param>
		private void ShowListPageInfo(Tj190f02Form tj190f02Form)
		{
			//M1明細ページ情報を表示する。
			ShowM1ListPageInfo(tj190f02Form.GetList("M1"));

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
		/// <param name="tj190f02Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderList(
			Tj190f02Form tj190f02Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//画面のM1明細部データを設定する。
			RenderM1List(tj190f02Form, formInfo, formResource, lang);
			//M1明細部のページャーにページ情報を設定する。
			RenderM1Pager(tj190f02Form);
			
		}
		#endregion

		#region M1明細データを表示する
		/// <summary>
		/// M1明細データを表示する。
		/// </summary>
		/// <param name="tj190f02Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderM1List(
			Tj190f02Form tj190f02Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//M1明細部データソースを設定する。
			M1.DataSource = tj190f02Form.GetPageViewList("M1");
			M1.DataBind();

			//M1明細部データをフォーマットする。
			IList m1DataList = (IList)M1.DataSource;
			
			for (int index = 0; index < M1.Items.Count; index++)
			{
				Tj190f02M1Form tj190f02M1Form = (Tj190f02M1Form)m1DataList[index];
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1rowno"),
					DataFormatUtil.GetFormatItem(tj190f02M1Form.M1rowno,formInfo["M1rowno"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1hinsyu_ryaku_nm"),
					DataFormatUtil.GetFormatItem(tj190f02M1Form.M1hinsyu_ryaku_nm,formInfo["M1hinsyu_ryaku_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1burando_nm"),
					DataFormatUtil.GetFormatItem(tj190f02M1Form.M1burando_nm,formInfo["M1burando_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1jisya_hbn"),
					DataFormatUtil.GetFormatItem(tj190f02M1Form.M1jisya_hbn,formInfo["M1jisya_hbn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1maker_hbn"),
					DataFormatUtil.GetFormatItem(tj190f02M1Form.M1maker_hbn,formInfo["M1maker_hbn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1syonmk"),
					DataFormatUtil.GetFormatItem(tj190f02M1Form.M1syonmk,formInfo["M1syonmk"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1iro_nm"),
					DataFormatUtil.GetFormatItem(tj190f02M1Form.M1iro_nm,formInfo["M1iro_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1size_nm"),
					DataFormatUtil.GetFormatItem(tj190f02M1Form.M1size_nm,formInfo["M1size_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1scan_cd"),
					DataFormatUtil.GetFormatItem(tj190f02M1Form.M1scan_cd,formInfo["M1scan_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1hyoka_tnk"),
					DataFormatUtil.GetFormatItem(tj190f02M1Form.M1hyoka_tnk,formInfo["M1hyoka_tnk"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1tanajityobo_su"),
					DataFormatUtil.GetFormatItem(tj190f02M1Form.M1tanajityobo_su,formInfo["M1tanajityobo_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1tanajityobo_su_hdn"),
					DataFormatUtil.GetFormatItem(tj190f02M1Form.M1tanajityobo_su_hdn, formInfo["M1tanajityobo_su_hdn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1tanajisekiso_su"),
					DataFormatUtil.GetFormatItem(tj190f02M1Form.M1tanajisekiso_su,formInfo["M1tanajisekiso_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1tanajisekiso_su_hdn"),
					DataFormatUtil.GetFormatItem(tj190f02M1Form.M1tanajisekiso_su_hdn, formInfo["M1tanajisekiso_su_hdn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1jitana_su"),
					DataFormatUtil.GetFormatItem(tj190f02M1Form.M1jitana_su,formInfo["M1jitana_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1jitana_su1_hdn"),
					DataFormatUtil.GetFormatItem(tj190f02M1Form.M1jitana_su1_hdn,formInfo["M1jitana_su1_hdn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1loss_su"),
					DataFormatUtil.GetFormatItem(tj190f02M1Form.M1loss_su,formInfo["M1loss_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1loss_kin"),
					DataFormatUtil.GetFormatItem(tj190f02M1Form.M1loss_kin,formInfo["M1loss_kin"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1selectorcheckbox"),
					DataFormatUtil.GetFormatItem(tj190f02M1Form.M1selectorcheckbox,formInfo["M1selectorcheckbox"]));
				((System.Web.UI.WebControls.CheckBox)M1.Items[index].FindControl("M1selectorcheckbox")).Text =
					formResource.GetString("M1selectorcheckbox", lang);
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1entersyoriflg"),
					DataFormatUtil.GetFormatItem(tj190f02M1Form.M1entersyoriflg,formInfo["M1entersyoriflg"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1dtlirokbn"),
					DataFormatUtil.GetFormatItem(tj190f02M1Form.M1dtlirokbn,formInfo["M1dtlirokbn"]));

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
				// (M1.HeaderRow.FindControl("M1size_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1size_nm", lang), base.GetPageContext().FormInfo["M1size_nm"]);
				// (M1.HeaderRow.FindControl("M1scan_cd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1scan_cd", lang), base.GetPageContext().FormInfo["M1scan_cd"]);
				// (M1.HeaderRow.FindControl("M1hyoka_tnk") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hyoka_tnk", lang), base.GetPageContext().FormInfo["M1hyoka_tnk"]);
				// (M1.HeaderRow.FindControl("M1tanajityobo_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tanajityobo_su", lang), base.GetPageContext().FormInfo["M1tanajityobo_su"]);
				// (M1.HeaderRow.FindControl("M1tanajisekiso_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tanajisekiso_su", lang), base.GetPageContext().FormInfo["M1tanajisekiso_su"]);
				// (M1.HeaderRow.FindControl("M1jitana_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1jitana_su", lang), base.GetPageContext().FormInfo["M1jitana_su"]);
				// (M1.HeaderRow.FindControl("M1jitana_su1_hdn") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1jitana_su1_hdn", lang), base.GetPageContext().FormInfo["M1jitana_su1_hdn"]);
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
		/// <param name="tj190f02Form">画面FormVO</param>
		private void RenderM1Pager(Tj190f02Form tj190f02Form)
		{
			Pgr.VirtualItemCount = tj190f02Form.GetList("M1").RecordCount;
			Pgr.CurrentPageIndex = tj190f02Form.GetList("M1").PageNo - 1;
			Pgr.PageSize = tj190f02Form.GetList("M1").DispRow;
		}
		#endregion
		#endregion

		#region カードデータを表示する
		/// <summary>
		/// カードデータを表示する
		/// </summary>
		/// <param name="tj190f02Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderCard(
			Tj190f02Form tj190f02Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			
			ControlUtil.SetControlValue(Head_tenpo_cd,
				DataFormatUtil.GetFormatItem(tj190f02Form.Head_tenpo_cd,formInfo["Head_tenpo_cd"]));
			ControlUtil.SetControlValue(Head_tenpo_nm,
				DataFormatUtil.GetFormatItem(tj190f02Form.Head_tenpo_nm,formInfo["Head_tenpo_nm"]));
			ControlUtil.SetControlValue(Modeno,
				DataFormatUtil.GetFormatItem(tj190f02Form.Modeno,formInfo["Modeno"]));
			ControlUtil.SetControlValue(Stkmodeno,
				DataFormatUtil.GetFormatItem(tj190f02Form.Stkmodeno,formInfo["Stkmodeno"]));
			ControlUtil.SetControlValue(Tenpo_cd_hdn,
				DataFormatUtil.GetFormatItem(tj190f02Form.Tenpo_cd_hdn,formInfo["Tenpo_cd_hdn"]));
			ControlUtil.SetControlValue(Nyuryoku_ymd,
				DataFormatUtil.GetFormatItem(tj190f02Form.Nyuryoku_ymd,formInfo["Nyuryoku_ymd"]));
			ControlUtil.SetControlValue(Rintana_kanri_no,
				DataFormatUtil.GetFormatItem(tj190f02Form.Rintana_kanri_no,formInfo["Rintana_kanri_no"]));
			ControlUtil.SetControlValue(Loss_kanri_no,
				DataFormatUtil.GetFormatItem(tj190f02Form.Loss_kanri_no,formInfo["Loss_kanri_no"]));
			ControlUtil.SetControlValue(Bumon_cd_bo,
				DataFormatUtil.GetFormatItem(tj190f02Form.Bumon_cd_bo,formInfo["Bumon_cd_bo"]));
			ControlUtil.SetControlValue(Bumon_nm,
				DataFormatUtil.GetFormatItem(tj190f02Form.Bumon_nm,formInfo["Bumon_nm"]));
			ControlUtil.SetControlValue(Nyuryokutan_cd,
				DataFormatUtil.GetFormatItem(tj190f02Form.Nyuryokutan_cd,formInfo["Nyuryokutan_cd"]));
			ControlUtil.SetControlValue(Nyuryokutan_nm,
				DataFormatUtil.GetFormatItem(tj190f02Form.Nyuryokutan_nm,formInfo["Nyuryokutan_nm"]));
			ControlUtil.SetControlValue(Losskeisan_ymd,
				DataFormatUtil.GetFormatItem(tj190f02Form.Losskeisan_ymd,formInfo["Losskeisan_ymd"]));
			ControlUtil.SetControlValue(Losskeisan_tm,
				DataFormatUtil.GetFormatItem(tj190f02Form.Losskeisan_tm,formInfo["Losskeisan_tm"]));
			ControlUtil.SetControlValue(Hinsyu_sitei_flg,
				DataFormatUtil.GetFormatItem(tj190f02Form.Hinsyu_sitei_flg,formInfo["Hinsyu_sitei_flg"]));
			ControlUtil.SetControlValue(Hinsyu_cd,
				DataFormatUtil.GetFormatItem(tj190f02Form.Hinsyu_cd,formInfo["Hinsyu_cd"]));
			ControlUtil.SetControlValue(Hinsyu_ryaku_nm,
				DataFormatUtil.GetFormatItem(tj190f02Form.Hinsyu_ryaku_nm,formInfo["Hinsyu_ryaku_nm"]));
			ControlUtil.SetControlValue(Burando_sitei_flg,
				DataFormatUtil.GetFormatItem(tj190f02Form.Burando_sitei_flg,formInfo["Burando_sitei_flg"]));
			ControlUtil.SetControlValue(Burando_cd,
				DataFormatUtil.GetFormatItem(tj190f02Form.Burando_cd,formInfo["Burando_cd"]));
			ControlUtil.SetControlValue(Burando_nm,
				DataFormatUtil.GetFormatItem(tj190f02Form.Burando_nm,formInfo["Burando_nm"]));
			ControlUtil.SetControlValue(Burando_cd1,
				DataFormatUtil.GetFormatItem(tj190f02Form.Burando_cd1,formInfo["Burando_cd1"]));
			ControlUtil.SetControlValue(Burando_nm1,
				DataFormatUtil.GetFormatItem(tj190f02Form.Burando_nm1,formInfo["Burando_nm1"]));
			ControlUtil.SetControlValue(Burando_cd2,
				DataFormatUtil.GetFormatItem(tj190f02Form.Burando_cd2,formInfo["Burando_cd2"]));
			ControlUtil.SetControlValue(Burando_nm2,
				DataFormatUtil.GetFormatItem(tj190f02Form.Burando_nm2,formInfo["Burando_nm2"]));
			ControlUtil.SetControlValue(Burando_cd3,
				DataFormatUtil.GetFormatItem(tj190f02Form.Burando_cd3,formInfo["Burando_cd3"]));
			ControlUtil.SetControlValue(Burando_nm3,
				DataFormatUtil.GetFormatItem(tj190f02Form.Burando_nm3,formInfo["Burando_nm3"]));
			ControlUtil.SetControlValue(Burando_cd4,
				DataFormatUtil.GetFormatItem(tj190f02Form.Burando_cd4,formInfo["Burando_cd4"]));
			ControlUtil.SetControlValue(Burando_nm4,
				DataFormatUtil.GetFormatItem(tj190f02Form.Burando_nm4,formInfo["Burando_nm4"]));
			ControlUtil.SetControlValue(Burando_cd5,
				DataFormatUtil.GetFormatItem(tj190f02Form.Burando_cd5,formInfo["Burando_cd5"]));
			ControlUtil.SetControlValue(Burando_nm5,
				DataFormatUtil.GetFormatItem(tj190f02Form.Burando_nm5,formInfo["Burando_nm5"]));
			ControlUtil.SetControlValue(Burando_cd6,
				DataFormatUtil.GetFormatItem(tj190f02Form.Burando_cd6,formInfo["Burando_cd6"]));
			ControlUtil.SetControlValue(Burando_nm6,
				DataFormatUtil.GetFormatItem(tj190f02Form.Burando_nm6,formInfo["Burando_nm6"]));
			ControlUtil.SetControlValue(Burando_cd7,
				DataFormatUtil.GetFormatItem(tj190f02Form.Burando_cd7,formInfo["Burando_cd7"]));
			ControlUtil.SetControlValue(Burando_nm7,
				DataFormatUtil.GetFormatItem(tj190f02Form.Burando_nm7,formInfo["Burando_nm7"]));
			ControlUtil.SetControlValue(Gokeitanajityobo_su,
				DataFormatUtil.GetFormatItem(tj190f02Form.Gokeitanajityobo_su,formInfo["Gokeitanajityobo_su"]));
			ControlUtil.SetControlValue(Gokeitanajisekiso_su,
				DataFormatUtil.GetFormatItem(tj190f02Form.Gokeitanajisekiso_su,formInfo["Gokeitanajisekiso_su"]));
			ControlUtil.SetControlValue(Gokeijitana_su,
				DataFormatUtil.GetFormatItem(tj190f02Form.Gokeijitana_su,formInfo["Gokeijitana_su"]));
			ControlUtil.SetControlValue(Gokeiloss_su,
				DataFormatUtil.GetFormatItem(tj190f02Form.Gokeiloss_su,formInfo["Gokeiloss_su"]));
			ControlUtil.SetControlValue(Gokeiloss_kin,
				DataFormatUtil.GetFormatItem(tj190f02Form.Gokeiloss_kin,formInfo["Gokeiloss_kin"]));

			if(!base.CheckUseSelfCustomize()){
				Btnback.Value = base.FormResourceGetString(formResource, "Btnback", lang);
				Btnhinsyu_cd.Value = base.FormResourceGetString(formResource, "Btnhinsyu_cd", lang);
				Btnburando_cd.Value = base.FormResourceGetString(formResource, "Btnburando_cd", lang);
				Btnburando_cd1.Value = base.FormResourceGetString(formResource, "Btnburando_cd1", lang);
				Btnburando_cd2.Value = base.FormResourceGetString(formResource, "Btnburando_cd2", lang);
				Btnburando_cd3.Value = base.FormResourceGetString(formResource, "Btnburando_cd3", lang);
				Btnburando_cd4.Value = base.FormResourceGetString(formResource, "Btnburando_cd4", lang);
				Btnburando_cd5.Value = base.FormResourceGetString(formResource, "Btnburando_cd5", lang);
				Btnburando_cd6.Value = base.FormResourceGetString(formResource, "Btnburando_cd6", lang);
				Btnburando_cd7.Value = base.FormResourceGetString(formResource, "Btnburando_cd7", lang);
				Btnrowins.Value = base.FormResourceGetString(formResource, "Btnrowins", lang);
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
			// UIScreenController controller = new UIScreenController((Tj190f02Form)base.GetPageContext().GetFormVO());
			// controller.ChangeColumnsDisplayMode(M1 ,  new DetailHeaderFixedVO(M1Header , true) , null);

			/*
			 *登録した機能間連携処理を親画面に感知させる。
			 *機能有効させる場合は、コメントアウトを外してください。
			 */
			//DetailUtil.RunPgSyn(this,(StandardBaseForm)base.GetPageContext().GetFormVO());
			#region 画面表示制御
			Tj190f02Form formVo = (Tj190f02Form)base.GetPageContext().GetFormVO();
			IList m1DataList = formVo.GetPageViewList("M1");
			// IDataList m1DataList = formVo.GetPageViewList("M1");

			// [選択モードNO]が「修正」以外の場合
			if (!BoSystemConstant.MODE_UPD.Equals(formVo.Stkmodeno))
			{
				// 品種指定フラグを使用不可にする
				ControlCls.Disable(Hinsyu_sitei_flg, true);

				// 品種コードを使用不可にする
				ControlCls.Disable(Hinsyu_cd, true);

				// 品種コードボタンを使用不可にする
				ControlCls.Disable(Btnhinsyu_cd, true);

				// ブランド指定フラグを使用不可にする
				ControlCls.Disable(Burando_sitei_flg,true);

				// ブランドコード～ブランドコード7を使用不可にする
				ControlCls.Disable(Burando_cd, true);
				ControlCls.Disable(Burando_cd1, true);
				ControlCls.Disable(Burando_cd2, true);
				ControlCls.Disable(Burando_cd3, true);
				ControlCls.Disable(Burando_cd4, true);
				ControlCls.Disable(Burando_cd5, true);
				ControlCls.Disable(Burando_cd6, true);
				ControlCls.Disable(Burando_cd7, true);

				// ブランドコードボタン～ブランドコードボタン7を使用不可にする
				ControlCls.Disable(Btnburando_cd, true);
				ControlCls.Disable(Btnburando_cd1, true);
				ControlCls.Disable(Btnburando_cd2, true);
				ControlCls.Disable(Btnburando_cd3, true);
				ControlCls.Disable(Btnburando_cd4, true);
				ControlCls.Disable(Btnburando_cd5, true);
				ControlCls.Disable(Btnburando_cd6, true);
				ControlCls.Disable(Btnburando_cd7, true);

				// 行追加ボタンを使用不可にする
				ControlCls.Disable(Btnrowins, true);

				// サイズ選択ボタンを使用不可にする
				ControlCls.Disable(Btnsizstk, true);

				// 行削除ボタンを使用不可にする
				ControlCls.Disable(Btnrowdel, true);

				// 確定ボタンを使用不可にする
				ControlCls.Disable(Btnenter, true);

				// 明細の入力項目を使用不可にする
				for (int i = 0; i < m1DataList.Count; i++ )
				{
					ControlCls.Disable(((MDTextBox)M1.Items[i].FindControl("M1scan_cd")), true);
					ControlCls.Disable(((MDTextBox)M1.Items[i].FindControl("M1jitana_su")), true);
				}
			}
			// [選択モードNO]が「修正」の場合
			else
			{
				// [品種指定フラグ]が「全品種」の場合
				if (ConditionHinsyu_sitei_flg.VALUE_HINSYU_SITEI_FLG1.Equals(formVo.Hinsyu_sitei_flg))
				{
					// 品種コードを使用不可にする
					ControlCls.Disable(Hinsyu_cd, true);

					// 品種コードボタンを使用不可にする
					ControlCls.Disable(Btnhinsyu_cd, true);
				}

				// [ブランド指定フラグ]が「全ブランド」の場合
				if (ConditionBurando_sitei_flg.VALUE_BURANDO_SITEI_FLG1.Equals(formVo.Burando_sitei_flg))
				{
					// ブランドコード～ブランドコード7を使用不可にする
					ControlCls.Disable(Burando_cd, true);
					ControlCls.Disable(Burando_cd1, true);
					ControlCls.Disable(Burando_cd2, true);
					ControlCls.Disable(Burando_cd3, true);
					ControlCls.Disable(Burando_cd4, true);
					ControlCls.Disable(Burando_cd5, true);
					ControlCls.Disable(Burando_cd6, true);
					ControlCls.Disable(Burando_cd7, true);

					// ブランドコードボタン～ブランドコードボタン7を使用不可にする
					ControlCls.Disable(Btnburando_cd, true);
					ControlCls.Disable(Btnburando_cd1, true);
					ControlCls.Disable(Btnburando_cd2, true);
					ControlCls.Disable(Btnburando_cd3, true);
					ControlCls.Disable(Btnburando_cd4, true);
					ControlCls.Disable(Btnburando_cd5, true);
					ControlCls.Disable(Btnburando_cd6, true);
					ControlCls.Disable(Btnburando_cd7, true);
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
			ControlUtil.SetControlValue(Nyuryoku_ymd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Nyuryoku_ymd", lang), base.GetPageContext().FormInfo["Nyuryoku_ymd"]));
				DataFormatUtil.SetMustColorCaption(Nyuryoku_ymd_lbl, base.GetPageContext().FormInfo["Nyuryoku_ymd"]);
			ControlUtil.SetControlValue(Rintana_kanri_no_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Rintana_kanri_no", lang), base.GetPageContext().FormInfo["Rintana_kanri_no"]));
				DataFormatUtil.SetMustColorCaption(Rintana_kanri_no_lbl, base.GetPageContext().FormInfo["Rintana_kanri_no"]);
			ControlUtil.SetControlValue(Loss_kanri_no_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Loss_kanri_no", lang), base.GetPageContext().FormInfo["Loss_kanri_no"]));
				DataFormatUtil.SetMustColorCaption(Loss_kanri_no_lbl, base.GetPageContext().FormInfo["Loss_kanri_no"]);
			ControlUtil.SetControlValue(Bumon_cd_bo_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Bumon_cd_bo", lang), base.GetPageContext().FormInfo["Bumon_cd_bo"]));
				DataFormatUtil.SetMustColorCaption(Bumon_cd_bo_lbl, base.GetPageContext().FormInfo["Bumon_cd_bo"]);
			ControlUtil.SetControlValue(Bumon_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Bumon_nm", lang), base.GetPageContext().FormInfo["Bumon_nm"]));
				DataFormatUtil.SetMustColorCaption(Bumon_nm_lbl, base.GetPageContext().FormInfo["Bumon_nm"]);
			ControlUtil.SetControlValue(Nyuryokutan_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Nyuryokutan_cd", lang), base.GetPageContext().FormInfo["Nyuryokutan_cd"]));
				DataFormatUtil.SetMustColorCaption(Nyuryokutan_cd_lbl, base.GetPageContext().FormInfo["Nyuryokutan_cd"]);
			ControlUtil.SetControlValue(Nyuryokutan_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Nyuryokutan_nm", lang), base.GetPageContext().FormInfo["Nyuryokutan_nm"]));
				DataFormatUtil.SetMustColorCaption(Nyuryokutan_nm_lbl, base.GetPageContext().FormInfo["Nyuryokutan_nm"]);
			ControlUtil.SetControlValue(Losskeisan_ymd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Losskeisan_ymd", lang), base.GetPageContext().FormInfo["Losskeisan_ymd"]));
				DataFormatUtil.SetMustColorCaption(Losskeisan_ymd_lbl, base.GetPageContext().FormInfo["Losskeisan_ymd"]);
			ControlUtil.SetControlValue(Losskeisan_tm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Losskeisan_tm", lang), base.GetPageContext().FormInfo["Losskeisan_tm"]));
				DataFormatUtil.SetMustColorCaption(Losskeisan_tm_lbl, base.GetPageContext().FormInfo["Losskeisan_tm"]);
			ControlUtil.SetControlValue(Hinsyu_sitei_flg_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Hinsyu_sitei_flg", lang), base.GetPageContext().FormInfo["Hinsyu_sitei_flg"]));
				DataFormatUtil.SetMustColorCaption(Hinsyu_sitei_flg_lbl, base.GetPageContext().FormInfo["Hinsyu_sitei_flg"]);
			ControlUtil.SetControlValue(Hinsyu_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Hinsyu_cd", lang), base.GetPageContext().FormInfo["Hinsyu_cd"]));
				DataFormatUtil.SetMustColorCaption(Hinsyu_cd_lbl, base.GetPageContext().FormInfo["Hinsyu_cd"]);
			ControlUtil.SetControlValue(Hinsyu_ryaku_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Hinsyu_ryaku_nm", lang), base.GetPageContext().FormInfo["Hinsyu_ryaku_nm"]));
				DataFormatUtil.SetMustColorCaption(Hinsyu_ryaku_nm_lbl, base.GetPageContext().FormInfo["Hinsyu_ryaku_nm"]);
			ControlUtil.SetControlValue(Burando_sitei_flg_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Burando_sitei_flg", lang), base.GetPageContext().FormInfo["Burando_sitei_flg"]));
				DataFormatUtil.SetMustColorCaption(Burando_sitei_flg_lbl, base.GetPageContext().FormInfo["Burando_sitei_flg"]);
			//ControlUtil.SetControlValue(Burando_cd_lbl, 
			//	DataFormatUtil.GetFormatCaption(formResource.GetString("Burando_cd", lang), base.GetPageContext().FormInfo["Burando_cd"]));
				ControlUtil.SetControlValue(Burando_cd_lbl, "ブランド");
				DataFormatUtil.SetMustColorCaption(Burando_cd_lbl, base.GetPageContext().FormInfo["Burando_cd"]);
			ControlUtil.SetControlValue(Burando_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Burando_nm", lang), base.GetPageContext().FormInfo["Burando_nm"]));
				DataFormatUtil.SetMustColorCaption(Burando_nm_lbl, base.GetPageContext().FormInfo["Burando_nm"]);
			ControlUtil.SetControlValue(Burando_cd1_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Burando_cd1", lang), base.GetPageContext().FormInfo["Burando_cd1"]));
				DataFormatUtil.SetMustColorCaption(Burando_cd1_lbl, base.GetPageContext().FormInfo["Burando_cd1"]);
			ControlUtil.SetControlValue(Burando_nm1_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Burando_nm1", lang), base.GetPageContext().FormInfo["Burando_nm1"]));
				DataFormatUtil.SetMustColorCaption(Burando_nm1_lbl, base.GetPageContext().FormInfo["Burando_nm1"]);
			ControlUtil.SetControlValue(Burando_cd2_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Burando_cd2", lang), base.GetPageContext().FormInfo["Burando_cd2"]));
				DataFormatUtil.SetMustColorCaption(Burando_cd2_lbl, base.GetPageContext().FormInfo["Burando_cd2"]);
			ControlUtil.SetControlValue(Burando_nm2_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Burando_nm2", lang), base.GetPageContext().FormInfo["Burando_nm2"]));
				DataFormatUtil.SetMustColorCaption(Burando_nm2_lbl, base.GetPageContext().FormInfo["Burando_nm2"]);
			ControlUtil.SetControlValue(Burando_cd3_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Burando_cd3", lang), base.GetPageContext().FormInfo["Burando_cd3"]));
				DataFormatUtil.SetMustColorCaption(Burando_cd3_lbl, base.GetPageContext().FormInfo["Burando_cd3"]);
			ControlUtil.SetControlValue(Burando_nm3_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Burando_nm3", lang), base.GetPageContext().FormInfo["Burando_nm3"]));
				DataFormatUtil.SetMustColorCaption(Burando_nm3_lbl, base.GetPageContext().FormInfo["Burando_nm3"]);
			ControlUtil.SetControlValue(Burando_cd4_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Burando_cd4", lang), base.GetPageContext().FormInfo["Burando_cd4"]));
				DataFormatUtil.SetMustColorCaption(Burando_cd4_lbl, base.GetPageContext().FormInfo["Burando_cd4"]);
			ControlUtil.SetControlValue(Burando_nm4_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Burando_nm4", lang), base.GetPageContext().FormInfo["Burando_nm4"]));
				DataFormatUtil.SetMustColorCaption(Burando_nm4_lbl, base.GetPageContext().FormInfo["Burando_nm4"]);
			ControlUtil.SetControlValue(Burando_cd5_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Burando_cd5", lang), base.GetPageContext().FormInfo["Burando_cd5"]));
				DataFormatUtil.SetMustColorCaption(Burando_cd5_lbl, base.GetPageContext().FormInfo["Burando_cd5"]);
			ControlUtil.SetControlValue(Burando_nm5_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Burando_nm5", lang), base.GetPageContext().FormInfo["Burando_nm5"]));
				DataFormatUtil.SetMustColorCaption(Burando_nm5_lbl, base.GetPageContext().FormInfo["Burando_nm5"]);
			ControlUtil.SetControlValue(Burando_cd6_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Burando_cd6", lang), base.GetPageContext().FormInfo["Burando_cd6"]));
				DataFormatUtil.SetMustColorCaption(Burando_cd6_lbl, base.GetPageContext().FormInfo["Burando_cd6"]);
			ControlUtil.SetControlValue(Burando_nm6_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Burando_nm6", lang), base.GetPageContext().FormInfo["Burando_nm6"]));
				DataFormatUtil.SetMustColorCaption(Burando_nm6_lbl, base.GetPageContext().FormInfo["Burando_nm6"]);
			ControlUtil.SetControlValue(Burando_cd7_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Burando_cd7", lang), base.GetPageContext().FormInfo["Burando_cd7"]));
				DataFormatUtil.SetMustColorCaption(Burando_cd7_lbl, base.GetPageContext().FormInfo["Burando_cd7"]);
			ControlUtil.SetControlValue(Burando_nm7_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Burando_nm7", lang), base.GetPageContext().FormInfo["Burando_nm7"]));
				DataFormatUtil.SetMustColorCaption(Burando_nm7_lbl, base.GetPageContext().FormInfo["Burando_nm7"]);
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
				// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1size_nm", lang), base.GetPageContext().FormInfo["M1size_nm"]);
				// M1.Columns[8].HeaderText = 
				// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1scan_cd", lang), base.GetPageContext().FormInfo["M1scan_cd"]);
				// M1.Columns[9].HeaderText = 
				// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hyoka_tnk", lang), base.GetPageContext().FormInfo["M1hyoka_tnk"]);
				// M1.Columns[10].HeaderText = 
				// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tanajityobo_su", lang), base.GetPageContext().FormInfo["M1tanajityobo_su"]);
				// M1.Columns[11].HeaderText = 
				// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tanajityobo_su_hdn", lang), base.GetPageContext().FormInfo["M1tanajityobo_su_hdn"]);
				// M1.Columns[12].HeaderText = 
				// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tanajisekiso_su", lang), base.GetPageContext().FormInfo["M1tanajisekiso_su"]);
				// M1.Columns[13].HeaderText = 
				// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tanajisekiso_su_hdn", lang), base.GetPageContext().FormInfo["M1tanajisekiso_su_hdn"]);
				// M1.Columns[14].HeaderText = 
				// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1jitana_su", lang), base.GetPageContext().FormInfo["M1jitana_su"]);
				// M1.Columns[15].HeaderText = 
				// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1jitana_su1_hdn", lang), base.GetPageContext().FormInfo["M1jitana_su1_hdn"]);
				// M1.Columns[16].HeaderText = 
				// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1loss_su", lang), base.GetPageContext().FormInfo["M1loss_su"]);
				// M1.Columns[17].HeaderText = 
				// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1loss_kin", lang), base.GetPageContext().FormInfo["M1loss_kin"]);
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
				Windowtitle.InnerText = formResource.GetString("Tj190f02_Titlebar", lang);
				header.FormName = formResource.GetString("Tj190f02_FormCaption", lang);
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
