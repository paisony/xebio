using com.xebio.bo.Tg040p01.Constant;
using com.xebio.bo.Tg040p01.Facade;
using com.xebio.bo.Tg040p01.Formvo;
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
using Common.Business.C99999.LabelUtil;
using Common.Business.C99999.ReportUtil;
using Common.Business.C99999.StringUtil;
using Common.IntegrationMD.Constant;
using Common.IntegrationMD.MDControl;
using Common.IntegrationMD.Util;
using Common.Standard.Base;
using Common.Standard.Message;
using Common.Standard.Session;
using Common.Standard.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;

namespace com.xebio.bo.Tg040p01.Page
{
  /// <summary>
  /// Tg040f02のコードビハインドです。
  /// </summary>
  public partial class Tg040f02Page : StandardBasePage
	{

		#region メソッド

		#region ページデータをロードするメソッド
		/// <summary>
		/// Tg040f02画面データを作成する。
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
						pageContext.SetFormVO(new Tg040f02Form());
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
								new Tg040f02Facade().DoLoad(facadeContext);
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

				if (pageContext != null)
				{
					string msg = BoSystemLabelUtil.GetScriptLabelPrint(pageContext, Tg040p01Constant.PGID);
					if (!string.IsNullOrEmpty(msg))
					{
						// インフォメッセージが表示されている場合、表示する。
						Page.ClientScript.RegisterStartupScript(typeof(string), "SealPrint", msg);
						return;
					}
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

		#region フォームを呼び出します(ボタンID : Btnback(戻る))
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
				new Tg040f02Facade().DoBTNBACK_FRM(facadeContext);
				
				
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
				if (((Tg040f02Form)pageContext.GetFormVO()).Stkmodeno.Equals(BoSystemConstant.MODE_INSERT))
				{
					// 新規作成の場合、モード表示クリア処理
					ModeUtil.ClearMode(pageContext);
					commandInfo.ActionMode = "INI";
					commandInfo.PageLoadMode = true;
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
			// 新規作成以外の場合設定
			if (!((Tg040f02Form)pageContext.GetFormVO()).Stkmodeno.Equals(BoSystemConstant.MODE_INSERT))
			{
				// フォーカス設定用変数
				string focusItem = string.Empty;
				string focusMno = string.Empty;

				// 選択された管理Noにフォーカス設定
				focusItem = "M1ymd";
				focusMno = (string)((Tg040f02Form)pageContext.GetFormVO(Tg040p01Constant.PGID, Tg040p01Constant.FORMID_02)).Dictionary[Tg040p01Constant.FCDUO_FOCUSROW];

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
				new Tg040f02Facade().DoBTNZENSTK_FRM(facadeContext);
				
				
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
				new Tg040f02Facade().DoBTNZENKJO_FRM(facadeContext);
				
				
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
				new Tg040f02Facade().DoBTNROWINS_MADD(facadeContext);
				
				
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

			#region フォーカス制御

			//URLクエリ追加用NameValueCollection
			NameValueCollection queryList = new NameValueCollection();
			
			//フォーカスを当てる項目を指定したい場合はFormFocusUtilを使ってqueryListに追加すること

			// フォーカス設定用変数
			string focusItem = string.Empty;
			string focusMno = string.Empty;

			// 明細取得
			Tg040f02Form f02VO = (Tg040f02Form)base.GetPageContext().GetFormVO();
			IDataList m1DataList = f02VO.GetList("M1");

			// 対象ページに設定
			int pageIndex = (m1DataList.Count) / m1DataList.DispRow + 1;
			f02VO.GetList("M1").SetPage(pageIndex);

			// 追加した行の[Ｍ１スキャンコード]に設定
			focusItem = "M1scan_cd";

			// 明細インデックス(0～99)
			int wkCnt = m1DataList.Count;
            while (wkCnt > m1DataList.DispRow)
            {
                wkCnt = wkCnt % m1DataList.DispRow;
				if(wkCnt == 0)
                {
                    wkCnt = m1DataList.DispRow;
                    break;
				}
			}
			focusMno = (wkCnt - 1).ToString();

			// フォーカス設定
			SetFocusCls.SetFocus(queryList, focusItem, focusMno);
			#endregion
			
			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNROWINS_MADD");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region 明細の行を増やします(ボタンID : Btnpageins(ページ追加))
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
				new Tg040f02Facade().DoBTNPAGEINS_MINSX(facadeContext);
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

			#region フォーカス制御
			//URLクエリ追加用NameValueCollection
			NameValueCollection queryList = new NameValueCollection();
			
			//フォーカスを当てる項目を指定したい場合はFormFocusUtilを使ってqueryListに追加すること

			// フォーカス設定用変数
			string focusItem = string.Empty;
			string focusMno = string.Empty;

			// 明細取得
			Tg040f02Form f02VO = (Tg040f02Form)base.GetPageContext().GetFormVO();
			IDataList m1DataList = f02VO.GetList("M1");

			// データ追加前件数＋１を計算
			int wkCnt = m1DataList.Count - m1DataList.DispRow + 1;

			// 対象ページに設定
			int pageIndex = wkCnt / m1DataList.DispRow + 1;
			f02VO.GetList("M1").SetPage(pageIndex);

			// 追加した行の[Ｍ１スキャンコード]に設定
			focusItem = "M1scan_cd";

			// 明細インデックス(0～99)
			focusMno = index;

			// フォーカス設定
			SetFocusCls.SetFocus(queryList, focusItem, focusMno);
			#endregion
			
			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNPAGEINS_MINSX");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion

		#region フォームを呼び出します(ボタンID : Btnsizstk(サイズ選択))
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
				//new Tg040f02Facade().DoBTNSIZSTK_FRM(facadeContext);

				if (Session[OpenTm040p01Cls.KEY_SIZE_SEARCH_RESULT] != null)
				{
					// セッションにサイズ検索戻り値が設定されている場合

					// セッションからファサードコンテキストに設定
					facadeContext.SetUserObject(Tg040p01Constant.DIC_SIZE_SEARCH_RESULT, Session[OpenTm040p01Cls.KEY_SIZE_SEARCH_RESULT]);

					new Tg040f02Facade().DoBTNSIZSTK_FRM(facadeContext);

					// フォーカスインデックスを取得
					focusMno = (string)facadeContext.GetUserObject(Tg040p01Constant.DIC_FOCUS_INDEX);

					//アコーディオンを閉じた状態で表示
					AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_CLOSE);
				}
				else
				{
					#region サイズ検索画面起動パラメータ設定
					// フォームオブジェクト取得
					Tg040f02Form form = (Tg040f02Form)pageContext.GetFormVO();

					// 画面ID
					string formId = Tm040p01Constant.FORMID_TG040F02;

					// 現在行数
					int curRowCnt = 0;

					// 明細オブジェクト取得
					IDataList m1List = form.GetList("M1");

					for (int i = m1List.Count - 1; i >= 0; i--)
					{
						// 行オブジェクト取得
						Tg040f02M1Form m1Form = (Tg040f02M1Form)m1List[i];

						// いずれかの入力項目が入力されている場合
						if (!string.IsNullOrEmpty(m1Form.M1scan_cd) || !string.IsNullOrEmpty(m1Form.M1suryo))
						{
							curRowCnt = i + 1;
							break;
						}
					}

					// 最大行数
					// 最大件数
					int intMaxCnt = 0;
					// 新規作成
					if (BoSystemConstant.MODE_INSERT.Equals(form.Stkmodeno))
					{
						intMaxCnt = decimal.ToInt32(GetMaxCntCls.GetMaxCnt(facadeContext.CommandInfo.FormId.ToUpper(), "1"));
					}
					else
					{
						intMaxCnt = decimal.ToInt32(GetMaxCntCls.GetMaxCnt(facadeContext.CommandInfo.FormId.ToUpper(), "2"));
					}

					// 発注マスタ検索用情報設定
					SearchHachuVO searchConditionVO = new SearchHachuVO();
					
					// 後続処理にて押下させるボタンID
					string afterActBtn = this.Btnsizstk.ID;
					#endregion

					// サイズ検索画面起動
					OpenTm040p01Cls.OpenTm040p01(Page, formId, curRowCnt, intMaxCnt, searchConditionVO, afterActBtn);
				}

				//エラー判定
				if (MessageDisplayUtil.HasError(facadeContext))
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
		
		#region フォームを呼び出します(ボタンID : Btnrowdel(行削除))
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

			string index;
			
			try
			{

				//アクションロジックを処理します
				IFacadeContext facadeContext = FacadeContextFactory.GetFacadeContext(pageContext);
				InitFacadeContext(facadeContext);
				new Tg040f02Facade().DoBTNROWDEL_FRM(facadeContext);
				
				
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

				index = facadeContext.GetUserObject(Tg040p01Constant.FCDUO_FOCUSROW) as string;

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

			#region フォーカス制御
			//URLクエリ追加用NameValueCollection
			NameValueCollection queryList = new NameValueCollection();
			
			//フォーカスを当てる項目を指定したい場合はFormFocusUtilを使ってqueryListに追加すること

			// フォーカス設定
			SetFocusCls.SetFocus(queryList, "M1scan_cd", index);
			#endregion
			
			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNROWDEL_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Btnseal(シール発行))
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnseal())
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnBTNSEAL_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnBTNSEAL_FRM");
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
				new Tg040f02Facade().DoBTNSEAL_FRM(facadeContext);

				// ラベル発行機の値をクッキーに登録
				Tg040f02Form f02VO_Cookie = (Tg040f02Form)facadeContext.FormVO;
				BoSystemLabelUtil.SetCookieLabel(pageContext.Response, f02VO_Cookie);
				
				
				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
					base.SetError(pageContext);
					return;
				}

				// CSVファイル名を取得
				string csvNm = (string)facadeContext.GetUserObject(Tg040p01Constant.FCDUO_SEAL_CSVFLNM);
				// シールレイアウト
				List<string> layout = (List<string>)facadeContext.GetUserObject(Tg040p01Constant.FCDUO_SEAL_LAYOUTNM);
				// シール発行スクリプトの出力
				if (!string.IsNullOrEmpty(csvNm))
				{
					BoSystemLabelUtil.createScriptLabelPrint(pageContext, Tg040p01Constant.PGID, layout, csvNm);
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
			
			#region フォーカス制御
			//URLクエリ追加用NameValueCollection
			NameValueCollection queryList = new NameValueCollection();

			//フォーカスを当てる項目を指定したい場合はFormFocusUtilを使ってqueryListに追加すること

			// フォーカス設定用変数
			string focusItem = string.Empty;
			string focusMno = string.Empty;

			// 1頁目の先頭行の[Ｍ１スキャンコード]に設定
			focusItem = "M1scan_cd";
			focusMno = (0).ToString();

			// 対象ページに設定
			Tg040f02Form f02VO = (Tg040f02Form)base.GetPageContext().GetFormVO();
			f02VO.GetList("M1").SetPage(1);

			// フォーカス設定
			SetFocusCls.SetFocus(queryList, focusItem, focusMno);
			#endregion

			
			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNSEAL_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region M1明細部のページング処理を実行します。(ボタンID : Pgr(ページャ))
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
				new Tg040f02Facade().DoPGR_PGN(facadeContext, pageindex);
				
				
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

			// 明細取得
			Tg040f02Form f02VO = (Tg040f02Form)base.GetPageContext().GetFormVO();
			
			try
			{

				//アクションロジックを処理します
				IFacadeContext facadeContext = FacadeContextFactory.GetFacadeContext(pageContext);
				InitFacadeContext(facadeContext);
				new Tg040f02Facade().DoBTNENTER_FRM(facadeContext);
				
				
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
				
				if (!(	string.IsNullOrEmpty(f02VO.Stock_no) 
						&& string.IsNullOrEmpty(f02VO.Ymd) 
						&& string.IsNullOrEmpty(f02VO.Tm)
						&& string.IsNullOrEmpty(f02VO.Nyuryokutan_cd) 
						&& string.IsNullOrEmpty(f02VO.Nyuryokutan_nm)))
				{	// 日付リンクの場合
					commandInfo.PageLoadMode = false;
				}
				else
				{	// 新規作成の場合
					commandInfo.PageLoadMode = true;
				}

				#region 出力PDFファイルダウンロード設定
				// PDFファイル名取得
				string pdfNm = facadeContext.GetUserObject(Tg040p01Constant.FCDUO_RRT_FLNM) as string;

				// サーバファイルフルパス
				string serverPath = string.Format(
					"{0}{1}{2}",
					FilePathManager.GetOutFilePath(Tg040p01Constant.PGID),
					Path.DirectorySeparatorChar,
					pdfNm
					);

				// クライアントファイル名
				string clientNm = string.Format(
					"{0}.{1}",
					BoSystemReport.CreateFileName(BoSystemConstant.REPORTNM_SYOHINSTOCKMEISAISYO, 2),
					BoSystemConstant.RPT_PDF_EXTENSION
					);

				// 単一ダウンロード情報
				DLConditionVO dlvo = new DLConditionVO();

				// ダウンロード用VOに値を設定
				dlvo.setSingleFileDownloadCondition(serverPath, clientNm);

				// 単一ダウンロード用にVOをセッションにセット
				SessionInfoUtil.SetPgObject(pageContext.CommandInfo.ProgramId, Tg040p01Constant.SESSION_KEY_DOWNLOAD_INFO, dlvo, Session);
				#endregion
				
				//共通アクション
				base.DoCommonAction();
			}
			catch (System.Exception ex)
			{
				ThrowException(ex, pageContext);
				return;
			}

			#region フォーカス制御
			//URLクエリ追加用NameValueCollection
			NameValueCollection queryList = new NameValueCollection();

			//フォーカスを当てる項目を指定したい場合はFormFocusUtilを使ってqueryListに追加すること

			if (!(	string.IsNullOrEmpty(f02VO.Stock_no)
					&& string.IsNullOrEmpty(f02VO.Ymd)
					&& string.IsNullOrEmpty(f02VO.Tm)
					&& string.IsNullOrEmpty(f02VO.Nyuryokutan_cd)
					&& string.IsNullOrEmpty(f02VO.Nyuryokutan_nm)))
			{	// 日付リンクの場合

				// フォーカス設定用変数
				string focusItem = string.Empty;
				string focusMno = string.Empty;

				// 選択された管理Noにフォーカス設定
				focusItem = "M1ymd";
				focusMno = (string)((Tg040f02Form)pageContext.GetFormVO(Tg040p01Constant.PGID, Tg040p01Constant.FORMID_02)).Dictionary[Tg040p01Constant.FCDUO_FOCUSROW];

				// フォーカス設定
				SetFocusCls.SetFocus(queryList, focusItem, focusMno);
			}
			#endregion

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
						Tg040f02Form tg040f02Form = (Tg040f02Form)pageContext.GetFormVO();

						//明細ページ情報を表示する
						ShowListPageInfo(tg040f02Form);
			
						//明細部データを表示する
						RenderList(tg040f02Form, pageContext.FormInfo, formResource, lang);

						//カード部データを表示する
						RenderCard(tg040f02Form, pageContext.FormInfo, formResource, lang);
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
		/// <param name="tg040f02Form">画面FormVO</param>
		private void ShowListPageInfo(Tg040f02Form tg040f02Form)
		{
			//M1明細ページ情報を表示する。
			ShowM1ListPageInfo(tg040f02Form.GetList("M1"));

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
		/// <param name="tg040f02Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderList(
			Tg040f02Form tg040f02Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//画面のM1明細部データを設定する。
			RenderM1List(tg040f02Form, formInfo, formResource, lang);
			//M1明細部のページャーにページ情報を設定する。
			RenderM1Pager(tg040f02Form);
			
		}
		#endregion

		#region M1明細データを表示する
		/// <summary>
		/// M1明細データを表示する。
		/// </summary>
		/// <param name="tg040f02Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderM1List(
			Tg040f02Form tg040f02Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//M1明細部データソースを設定する。
			M1.DataSource = tg040f02Form.GetPageViewList("M1");
			M1.DataBind();

			//M1明細部データをフォーマットする。
			IList m1DataList = (IList)M1.DataSource;
			
			for (int index = 0; index < M1.Items.Count; index++)
			{
				Tg040f02M1Form tg040f02M1Form = (Tg040f02M1Form)m1DataList[index];
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1rowno"),
					DataFormatUtil.GetFormatItem(tg040f02M1Form.M1rowno,formInfo["M1rowno"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1bumon_cd"),
					DataFormatUtil.GetFormatItem(tg040f02M1Form.M1bumon_cd,formInfo["M1bumon_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1bumonkana_nm"),
					DataFormatUtil.GetFormatItem(tg040f02M1Form.M1bumonkana_nm,formInfo["M1bumonkana_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1hinsyu_ryaku_nm"),
					DataFormatUtil.GetFormatItem(tg040f02M1Form.M1hinsyu_ryaku_nm,formInfo["M1hinsyu_ryaku_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1burando_nm"),
					DataFormatUtil.GetFormatItem(tg040f02M1Form.M1burando_nm,formInfo["M1burando_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1jisya_hbn"),
					DataFormatUtil.GetFormatItem(tg040f02M1Form.M1jisya_hbn,formInfo["M1jisya_hbn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1maker_hbn"),
					DataFormatUtil.GetFormatItem(tg040f02M1Form.M1maker_hbn,formInfo["M1maker_hbn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1syonmk"),
					DataFormatUtil.GetFormatItem(tg040f02M1Form.M1syonmk,formInfo["M1syonmk"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1scan_cd"),
					DataFormatUtil.GetFormatItem(tg040f02M1Form.M1scan_cd,formInfo["M1scan_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1hanbaikanryo_ymd"),
					DataFormatUtil.GetFormatItem(tg040f02M1Form.M1hanbaikanryo_ymd,formInfo["M1hanbaikanryo_ymd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1iro_nm"),
					DataFormatUtil.GetFormatItem(tg040f02M1Form.M1iro_nm,formInfo["M1iro_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1size_nm"),
					DataFormatUtil.GetFormatItem(tg040f02M1Form.M1size_nm,formInfo["M1size_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1suryo"),
					DataFormatUtil.GetFormatItem(tg040f02M1Form.M1suryo,formInfo["M1suryo"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1suryo_hdn"),
					DataFormatUtil.GetFormatItem(tg040f02M1Form.M1suryo_hdn,formInfo["M1suryo_hdn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1hinsyu_cd"),
					DataFormatUtil.GetFormatItem(tg040f02M1Form.M1hinsyu_cd,formInfo["M1hinsyu_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1selectorcheckbox"),
					DataFormatUtil.GetFormatItem(tg040f02M1Form.M1selectorcheckbox,formInfo["M1selectorcheckbox"]));
				((System.Web.UI.WebControls.CheckBox)M1.Items[index].FindControl("M1selectorcheckbox")).Text =
					formResource.GetString("M1selectorcheckbox", lang);
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1entersyoriflg"),
					DataFormatUtil.GetFormatItem(tg040f02M1Form.M1entersyoriflg,formInfo["M1entersyoriflg"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1dtlirokbn"),
					DataFormatUtil.GetFormatItem(tg040f02M1Form.M1dtlirokbn,formInfo["M1dtlirokbn"]));

				if (!base.CheckUseSelfCustomize())
				{
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
				// (M1.HeaderRow.FindControl("M1bumonkana_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumonkana_nm", lang), base.GetPageContext().FormInfo["M1bumonkana_nm"]);
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
				// (M1.HeaderRow.FindControl("M1scan_cd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1scan_cd", lang), base.GetPageContext().FormInfo["M1scan_cd"]);
				// (M1.HeaderRow.FindControl("M1hanbaikanryo_ymd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hanbaikanryo_ymd", lang), base.GetPageContext().FormInfo["M1hanbaikanryo_ymd"]);
				// (M1.HeaderRow.FindControl("M1iro_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1iro_nm", lang), base.GetPageContext().FormInfo["M1iro_nm"]);
				// (M1.HeaderRow.FindControl("M1size_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1size_nm", lang), base.GetPageContext().FormInfo["M1size_nm"]);
				// (M1.HeaderRow.FindControl("M1suryo") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo", lang), base.GetPageContext().FormInfo["M1suryo"]);
				// (M1.HeaderRow.FindControl("M1suryo_hdn") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo_hdn", lang), base.GetPageContext().FormInfo["M1suryo_hdn"]);
				// (M1.HeaderRow.FindControl("M1hinsyu_cd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hinsyu_cd", lang), base.GetPageContext().FormInfo["M1hinsyu_cd"]);
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
		/// <param name="tg040f02Form">画面FormVO</param>
		private void RenderM1Pager(Tg040f02Form tg040f02Form)
		{
			Pgr.VirtualItemCount = tg040f02Form.GetList("M1").RecordCount;
			Pgr.CurrentPageIndex = tg040f02Form.GetList("M1").PageNo - 1;
			Pgr.PageSize = tg040f02Form.GetList("M1").DispRow;
		}
		#endregion
		#endregion

		#region カードデータを表示する
		/// <summary>
		/// カードデータを表示する
		/// </summary>
		/// <param name="tg040f02Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderCard(
			Tg040f02Form tg040f02Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			
			ControlUtil.SetControlValue(Head_tenpo_cd,
				DataFormatUtil.GetFormatItem(tg040f02Form.Head_tenpo_cd,formInfo["Head_tenpo_cd"]));
			ControlUtil.SetControlValue(Head_tenpo_nm,
				DataFormatUtil.GetFormatItem(tg040f02Form.Head_tenpo_nm,formInfo["Head_tenpo_nm"]));
			ControlUtil.SetControlValue(Stock_no,
				DataFormatUtil.GetFormatItem(tg040f02Form.Stock_no,formInfo["Stock_no"]));
			ControlUtil.SetControlValue(Ymd,
				DataFormatUtil.GetFormatItem(tg040f02Form.Ymd,formInfo["Ymd"]));
			ControlUtil.SetControlValue(Tm,
				DataFormatUtil.GetFormatItem(tg040f02Form.Tm,formInfo["Tm"]));
			ControlUtil.SetControlValue(Nyuryokutan_cd,
				DataFormatUtil.GetFormatItem(tg040f02Form.Nyuryokutan_cd,formInfo["Nyuryokutan_cd"]));
			ControlUtil.SetControlValue(Nyuryokutan_nm,
				DataFormatUtil.GetFormatItem(tg040f02Form.Nyuryokutan_nm,formInfo["Nyuryokutan_nm"]));
			ControlUtil.SetControlValue(Label_cd,
				DataFormatUtil.GetFormatItem(tg040f02Form.Label_cd,formInfo["Label_cd"]));
			ControlUtil.SetControlValue(Label_ip,
				DataFormatUtil.GetFormatItem(tg040f02Form.Label_ip,formInfo["Label_ip"]));
			ControlUtil.SetControlValue(Label_nm,
				DataFormatUtil.GetFormatItem(tg040f02Form.Label_nm,formInfo["Label_nm"]));
			ControlUtil.SetControlValue(Stkmodeno,
				DataFormatUtil.GetFormatItem(tg040f02Form.Stkmodeno,formInfo["Stkmodeno"]));
			ControlUtil.SetControlValue(Gokei_suryo,
				DataFormatUtil.GetFormatItem(tg040f02Form.Gokei_suryo,formInfo["Gokei_suryo"]));

			if(!base.CheckUseSelfCustomize()){
				Btnback.Value = base.FormResourceGetString(formResource, "Btnback", lang);
				Btnzenstk.Value = base.FormResourceGetString(formResource, "Btnzenstk", lang);
				Btnzenkjo.Value = base.FormResourceGetString(formResource, "Btnzenkjo", lang);
				Btnrowins.Value = base.FormResourceGetString(formResource, "Btnrowins", lang);
				Btnpageins.Value = base.FormResourceGetString(formResource, "Btnpageins", lang);
				Btnsizstk.Value = base.FormResourceGetString(formResource, "Btnsizstk", lang);
				Btnrowdel.Value = base.FormResourceGetString(formResource, "Btnrowdel", lang);
				Btnseal.Value = base.FormResourceGetString(formResource, "Btnseal", lang);
				Btnlabel_cd.Value = base.FormResourceGetString(formResource, "Btnlabel_cd", lang);
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
			// UIScreenController controller = new UIScreenController((Tg040f02Form)base.GetPageContext().GetFormVO());
			// controller.ChangeColumnsDisplayMode(M1 ,  new DetailHeaderFixedVO(M1Header , true) , null);

			/*
			 *登録した機能間連携処理を親画面に感知させる。
			 *機能有効させる場合は、コメントアウトを外してください。
			 */
			//DetailUtil.RunPgSyn(this,(StandardBaseForm)base.GetPageContext().GetFormVO());

			#region 画面表示制御
			Tg040f02Form formVo = (Tg040f02Form)base.GetPageContext().GetFormVO();
			IList m1DataList = formVo.GetPageViewList("M1");
			#endregion

			#region 画面遷移制御
			// 日付リンクの場合
			if (!( string.IsNullOrEmpty(formVo.Stock_no) && string.IsNullOrEmpty(formVo.Ymd) && string.IsNullOrEmpty(formVo.Tm)
					&& string.IsNullOrEmpty(formVo.Nyuryokutan_cd) && string.IsNullOrEmpty(formVo.Nyuryokutan_nm)))
			{

				// [選択モードNo]が「修正」以外の場合、Disabledとする。
				if (!BoSystemString.Nvl(formVo.Stkmodeno).Equals(BoSystemConstant.MODE_UPD))
				{
					// 明細制御
					for (int i = 0; i < M1.Items.Count; i++)
					{
						// 明細情報
						Tg040f02M1Form f02m1VO = (Tg040f02M1Form)m1DataList[i];

						// 入力項目を使用不可とする
						ControlCls.Disable(((MDTextBox)M1.Items[i].FindControl("M1scan_cd")), true);	// Ｍ１スキャンコード
						ControlCls.Disable(((MDTextBox)M1.Items[i].FindControl("M1suryo")), true);		// Ｍ１数量
					}

					// 確定ボタン
					ControlCls.Disable(Btnenter, true);

					// 行追加ボタン
					ControlCls.Disable(Btnrowins, true);

					// 行削除ボタン
					ControlCls.Disable(Btnrowdel, true);
				}

				// [選択モードNo]が「照会」以外の場合、Disabledとする。
				if (!BoSystemString.Nvl(formVo.Stkmodeno).Equals(BoSystemConstant.MODE_REF))
				{
					// 全選択ボタン
					ControlCls.Disable(Btnzenstk, true);

					// 全解除ボタン
					ControlCls.Disable(Btnzenkjo, true);
				}

				// [選択モードNo]が「取消」の場合、Disabledとする。
				if (BoSystemString.Nvl(formVo.Stkmodeno).Equals(BoSystemConstant.MODE_DEL))
				{
					// シール発行ボタン
					ControlCls.Disable(Btnseal, true);
					// ラベル発行機コードボタン
					ControlCls.Disable(Btnlabel_cd, true);
				}

				// ページ追加ボタン
				ControlCls.Visible(BtnpageinsArea, false);
			}
			// 新規作成の場合
			else
			{
				// 全選択ボタン
				ControlCls.Disable(Btnzenstk, true);

				// 全解除ボタン
				ControlCls.Disable(Btnzenkjo, true);

				// 行追加ボタン
				ControlCls.Visible(BtnrowinsArea, false);

				// ラベル発行機コードボタン
				//ControlCls.Visible(Btnlabel_cd, false);
			}

			// サイズ選択ボタン
			
			if (string.IsNullOrEmpty(formVo.Stock_no) 
				&& string.IsNullOrEmpty(formVo.Ymd) 
				&& string.IsNullOrEmpty(formVo.Tm)
				&& string.IsNullOrEmpty(formVo.Nyuryokutan_cd) 
				&& string.IsNullOrEmpty(formVo.Nyuryokutan_nm))
			{// 新規作成の場合
				// 活性化
				ControlCls.Disable(Btnsizstk, false);
			}
			else
			{// 日付リンクの場合
				// モードが「照会」または「取消」の場合
				if (BoSystemString.Nvl(formVo.Stkmodeno).Equals(BoSystemConstant.MODE_REF)
					|| BoSystemString.Nvl(formVo.Stkmodeno).Equals(BoSystemConstant.MODE_DEL))
				{
					// 非活性
					ControlCls.Disable(Btnsizstk, true);
				}
				else
				{
					// 活性化
					ControlCls.Disable(Btnsizstk, false);
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
			ControlUtil.SetControlValue(Stock_no_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Stock_no", lang), base.GetPageContext().FormInfo["Stock_no"]));
				DataFormatUtil.SetMustColorCaption(Stock_no_lbl, base.GetPageContext().FormInfo["Stock_no"]);
			ControlUtil.SetControlValue(Ymd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Ymd", lang), base.GetPageContext().FormInfo["Ymd"]));
				DataFormatUtil.SetMustColorCaption(Ymd_lbl, base.GetPageContext().FormInfo["Ymd"]);
			ControlUtil.SetControlValue(Tm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Tm", lang), base.GetPageContext().FormInfo["Tm"]));
				DataFormatUtil.SetMustColorCaption(Tm_lbl, base.GetPageContext().FormInfo["Tm"]);
			ControlUtil.SetControlValue(Nyuryokutan_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Nyuryokutan_cd", lang), base.GetPageContext().FormInfo["Nyuryokutan_cd"]));
				DataFormatUtil.SetMustColorCaption(Nyuryokutan_cd_lbl, base.GetPageContext().FormInfo["Nyuryokutan_cd"]);
			ControlUtil.SetControlValue(Nyuryokutan_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Nyuryokutan_nm", lang), base.GetPageContext().FormInfo["Nyuryokutan_nm"]));
				DataFormatUtil.SetMustColorCaption(Nyuryokutan_nm_lbl, base.GetPageContext().FormInfo["Nyuryokutan_nm"]);
			ControlUtil.SetControlValue(Label_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Label_nm", lang), base.GetPageContext().FormInfo["Label_nm"]));
				DataFormatUtil.SetMustColorCaption(Label_nm_lbl, base.GetPageContext().FormInfo["Label_nm"]);
			ControlUtil.SetControlValue(Gokei_suryo_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Gokei_suryo", lang), base.GetPageContext().FormInfo["Gokei_suryo"]));
				DataFormatUtil.SetMustColorCaption(Gokei_suryo_lbl, base.GetPageContext().FormInfo["Gokei_suryo"]);
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
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumonkana_nm", lang), base.GetPageContext().FormInfo["M1bumonkana_nm"]);
				// M1.Columns[3].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hinsyu_ryaku_nm", lang), base.GetPageContext().FormInfo["M1hinsyu_ryaku_nm"]);
				// M1.Columns[4].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1burando_nm", lang), base.GetPageContext().FormInfo["M1burando_nm"]);
				// M1.Columns[5].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1jisya_hbn", lang), base.GetPageContext().FormInfo["M1jisya_hbn"]);
				// M1.Columns[6].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1maker_hbn", lang), base.GetPageContext().FormInfo["M1maker_hbn"]);
				// M1.Columns[7].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syonmk", lang), base.GetPageContext().FormInfo["M1syonmk"]);
				// M1.Columns[8].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1scan_cd", lang), base.GetPageContext().FormInfo["M1scan_cd"]);
				// M1.Columns[9].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hanbaikanryo_ymd", lang), base.GetPageContext().FormInfo["M1hanbaikanryo_ymd"]);
				// M1.Columns[10].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1iro_nm", lang), base.GetPageContext().FormInfo["M1iro_nm"]);
				// M1.Columns[11].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1size_nm", lang), base.GetPageContext().FormInfo["M1size_nm"]);
				// M1.Columns[12].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo", lang), base.GetPageContext().FormInfo["M1suryo"]);
				// M1.Columns[13].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo_hdn", lang), base.GetPageContext().FormInfo["M1suryo_hdn"]);
				// M1.Columns[14].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hinsyu_cd", lang), base.GetPageContext().FormInfo["M1hinsyu_cd"]);
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
				Windowtitle.InnerText = formResource.GetString("Tg040f02_Titlebar", lang);
				header.FormName = formResource.GetString("Tg040f02_FormCaption", lang);
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
