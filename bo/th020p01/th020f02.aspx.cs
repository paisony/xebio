﻿using com.xebio.bo.Th020p01.Constant;
using com.xebio.bo.Th020p01.Facade;
using com.xebio.bo.Th020p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.Model.Context;
using Common.Advanced.Resource;
using Common.Advanced.Web.Context;
using Common.Advanced.Web.Util;
using Common.Business.C01000.C01014;
using Common.Business.C01000.C01015;
using Common.Business.C01000.C01016;
using Common.Business.C99999.Constant;
using Common.Business.C99999.StringUtil;
using Common.IntegrationMD.Util;
using Common.Standard.Base;
using Common.Standard.Message;
using Common.Standard.Util;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Drawing;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Th020p01.Page
{
  /// <summary>
  /// Th020f02のコードビハインドです。
  /// </summary>
  public partial class Th020f02Page : StandardBasePage
	{

		#region メソッド

		#region ページデータをロードするメソッド
		/// <summary>
		/// Th020f02画面データを作成する。
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
						pageContext.SetFormVO(new Th020f02Form());
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
								new Th020f02Facade().DoLoad(facadeContext);
								break;
						}
					}
					else
					{
						if (commandInfo.ActionMode.Equals("INI"))
						{
							// アコーディオンオープン
							AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_OPEN);

							Th020f02Form formVo = (Th020f02Form)base.GetPageContext().GetFormVO();

							// 前画面モード情報がDictionaryに存在した場合、そのモードを設定
							if (formVo.Dictionary[Th020p01Constant.DIC_PREV_ACTION_MODE] != null
								&& !string.IsNullOrEmpty(formVo.Dictionary[Th020p01Constant.DIC_PREV_ACTION_MODE].ToString()))
							{
								commandInfo.ActionMode = formVo.Dictionary[Th020p01Constant.DIC_PREV_ACTION_MODE].ToString();
								formVo.Dictionary[Th020p01Constant.DIC_PREV_ACTION_MODE] = string.Empty;
							}

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
				new Th020f02Facade().DoBTNBACK_FRM(facadeContext);
				
				
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
			focusItem = "M1jisya_hbn";
			focusMno = (string)((Th020f02Form)pageContext.GetFormVO(Th020p01Constant.PGID, Th020p01Constant.FORMID_02)).Dictionary[Th020p01Constant.DIC_M1SELCETROWIDX];

			// フォーカス設定
			SetFocusCls.SetFocus(queryList, focusItem, focusMno);
			
			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNBACK_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Btnarea(エリアへ))
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnarea(エリアへ))
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnBTNAREA_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnBTNAREA_FRM");
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
				facadeContext.SetUserObject(Th020p01Constant.FCDUO_NEXTVO_03, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Th020p01Constant.FORMID_03));
				new Th020f02Facade().DoBTNAREA_FRM(facadeContext);
				// 次画面のフォームビーンを設定(エリア別)
				fvm.SetFormVO(Th020p01Constant.PGID, Th020p01Constant.FORMID_03, (Th020f03Form)facadeContext.GetUserObject(Th020p01Constant.FCDUO_NEXTVO_03));
				
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
			EndMethod(sender, e, this.GetType().Name + ".OnBTNAREA_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Btnprev(前へ))
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnprev(前へ))
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnBTNPREV_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnBTNPREV_FRM");
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
				new Th020f02Facade().DoBTNPREV_FRM(facadeContext);
				
				
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
				// commandInfo.ActionMode = "UPD";
				commandInfo.ActionMode = Th020p01Constant.ACTION_PREV;
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
			focusItem = "Meisaihead_iro_nm1";

			// フォーカス設定
			SetFocusCls.SetFocus(queryList, focusItem, focusMno);
			
			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNPREV_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Btnnext(次へ))
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnnext(次へ))
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnBTNNEXT_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnBTNNEXT_FRM");
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
				new Th020f02Facade().DoBTNNEXT_FRM(facadeContext);
				
				
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
				// commandInfo.ActionMode = "UPD";
				commandInfo.ActionMode = Th020p01Constant.ACTION_NEXT;
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
			focusItem = "Meisaihead_iro_nm16";

			// フォーカス設定
			SetFocusCls.SetFocus(queryList, focusItem, focusMno);
			
			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNNEXT_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Meisaihead_iro_nm1())
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Meisaihead_iro_nm1())
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnMEISAIHEAD_IRO_NM1_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM1_FRM");
			//入力チェックに失敗した場合、何も処理せずに返します
			if (!base.DoValidate(sender))
			{
				//クライアントチェックエラー時、画面描画する
				SetItems();
				SetAttribute();
				return;
			}
			
			// アクションコンテキストを取得する
			IPageContext pageContext = base.GetPageContext();
			ICommandInfo commandInfo = pageContext.CommandInfo;

			try
			{

				//アクションロジックを処理します
				IFacadeContext facadeContext = FacadeContextFactory.GetFacadeContext(pageContext);
				InitFacadeContext(facadeContext);

				// 選択列の情報をDictionaryに保持する
				Th020f02Form formVo = (Th020f02Form)pageContext.GetFormVO();

				// 明細標題ハッシュテーブル取得
				Hashtable HeadRec = (Hashtable)formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_HASH];

				// JANコード
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_JAN_CD] = HeadRec["JAN_CD01"].ToString();
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_SIZE_NM] = HeadRec["SIZE_NM01"].ToString();

				// 次画面のフォームVOをファサードに設定
				FormVOManager fvm = new FormVOManager(Session);
				facadeContext.SetUserObject(Th020p01Constant.FCDUO_NEXTVO_04, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Th020p01Constant.FORMID_04));
				new Th020f02Facade().DoMEISAIHEAD_IRO_NM1_FRM(facadeContext);
				// 次画面のフォームビーンを設定
				fvm.SetFormVO(Th020p01Constant.PGID, Th020p01Constant.FORMID_04, (Th020f04Form)facadeContext.GetUserObject(Th020p01Constant.FCDUO_NEXTVO_04));

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
			EndMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM1_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Meisaihead_iro_nm2())
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Meisaihead_iro_nm2())
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnMEISAIHEAD_IRO_NM2_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM2_FRM");
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

				// Facade処理は統一する
				// 選択列の情報をDictionaryに保持する
				Th020f02Form formVo = (Th020f02Form)pageContext.GetFormVO();

				// 明細標題ハッシュテーブル取得
				Hashtable HeadRec = (Hashtable)formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_HASH];

				// JANコードを保持
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_JAN_CD] = HeadRec["JAN_CD02"].ToString();
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_SIZE_NM] = HeadRec["SIZE_NM02"].ToString();

				// 次画面のフォームVOをファサードに設定
				FormVOManager fvm = new FormVOManager(Session);
				facadeContext.SetUserObject(Th020p01Constant.FCDUO_NEXTVO_04, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Th020p01Constant.FORMID_04));
				new Th020f02Facade().DoMEISAIHEAD_IRO_NM1_FRM(facadeContext);
				// 次画面のフォームビーンを設定
				fvm.SetFormVO(Th020p01Constant.PGID, Th020p01Constant.FORMID_04, (Th020f04Form)facadeContext.GetUserObject(Th020p01Constant.FCDUO_NEXTVO_04));
				// new Th020f02Facade().DoMEISAIHEAD_IRO_NM2_FRM(facadeContext);
				
				
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
			EndMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM2_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Meisaihead_iro_nm3())
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Meisaihead_iro_nm3())
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnMEISAIHEAD_IRO_NM3_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM3_FRM");
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

				// Facade処理は統一する
				// 選択列の情報をDictionaryに保持する
				Th020f02Form formVo = (Th020f02Form)pageContext.GetFormVO();

				// 明細標題ハッシュテーブル取得
				Hashtable HeadRec = (Hashtable)formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_HASH];

				// JANコードを保持
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_JAN_CD] = HeadRec["JAN_CD03"].ToString();
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_SIZE_NM] = HeadRec["SIZE_NM03"].ToString();

				// 次画面のフォームVOをファサードに設定
				FormVOManager fvm = new FormVOManager(Session);
				facadeContext.SetUserObject(Th020p01Constant.FCDUO_NEXTVO_04, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Th020p01Constant.FORMID_04));
				new Th020f02Facade().DoMEISAIHEAD_IRO_NM1_FRM(facadeContext);
				// 次画面のフォームビーンを設定
				fvm.SetFormVO(Th020p01Constant.PGID, Th020p01Constant.FORMID_04, (Th020f04Form)facadeContext.GetUserObject(Th020p01Constant.FCDUO_NEXTVO_04));
				// new Th020f02Facade().DoMEISAIHEAD_IRO_NM3_FRM(facadeContext);


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
			EndMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM3_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Meisaihead_iro_nm4())
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Meisaihead_iro_nm4())
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnMEISAIHEAD_IRO_NM4_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM4_FRM");
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

				// Facade処理は統一する
				// 選択列の情報をDictionaryに保持する
				Th020f02Form formVo = (Th020f02Form)pageContext.GetFormVO();

				// 明細標題ハッシュテーブル取得
				Hashtable HeadRec = (Hashtable)formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_HASH];

				// JANコードを保持
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_JAN_CD] = HeadRec["JAN_CD04"].ToString();
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_SIZE_NM] = HeadRec["SIZE_NM04"].ToString();

				// 次画面のフォームVOをファサードに設定
				FormVOManager fvm = new FormVOManager(Session);
				facadeContext.SetUserObject(Th020p01Constant.FCDUO_NEXTVO_04, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Th020p01Constant.FORMID_04));
				new Th020f02Facade().DoMEISAIHEAD_IRO_NM1_FRM(facadeContext);
				// 次画面のフォームビーンを設定
				fvm.SetFormVO(Th020p01Constant.PGID, Th020p01Constant.FORMID_04, (Th020f04Form)facadeContext.GetUserObject(Th020p01Constant.FCDUO_NEXTVO_04));
				// new Th020f02Facade().DoMEISAIHEAD_IRO_NM4_FRM(facadeContext);


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
			EndMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM4_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Meisaihead_iro_nm5())
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Meisaihead_iro_nm5())
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnMEISAIHEAD_IRO_NM5_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM5_FRM");
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

				// Facade処理は統一する
				// 選択列の情報をDictionaryに保持する
				Th020f02Form formVo = (Th020f02Form)pageContext.GetFormVO();

				// 明細標題ハッシュテーブル取得
				Hashtable HeadRec = (Hashtable)formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_HASH];

				// JANコードを保持
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_JAN_CD] = HeadRec["JAN_CD05"].ToString();
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_SIZE_NM] = HeadRec["SIZE_NM05"].ToString();

				// 次画面のフォームVOをファサードに設定
				FormVOManager fvm = new FormVOManager(Session);
				facadeContext.SetUserObject(Th020p01Constant.FCDUO_NEXTVO_04, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Th020p01Constant.FORMID_04));
				new Th020f02Facade().DoMEISAIHEAD_IRO_NM1_FRM(facadeContext);
				// 次画面のフォームビーンを設定
				fvm.SetFormVO(Th020p01Constant.PGID, Th020p01Constant.FORMID_04, (Th020f04Form)facadeContext.GetUserObject(Th020p01Constant.FCDUO_NEXTVO_04));
				// new Th020f02Facade().DoMEISAIHEAD_IRO_NM5_FRM(facadeContext);


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
			EndMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM5_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Meisaihead_iro_nm6())
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Meisaihead_iro_nm6())
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnMEISAIHEAD_IRO_NM6_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM6_FRM");
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

				// Facade処理は統一する
				// 選択列の情報をDictionaryに保持する
				Th020f02Form formVo = (Th020f02Form)pageContext.GetFormVO();

				// 明細標題ハッシュテーブル取得
				Hashtable HeadRec = (Hashtable)formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_HASH];

				// JANコードを保持
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_JAN_CD] = HeadRec["JAN_CD06"].ToString();
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_SIZE_NM] = HeadRec["SIZE_NM06"].ToString();

				// 次画面のフォームVOをファサードに設定
				FormVOManager fvm = new FormVOManager(Session);
				facadeContext.SetUserObject(Th020p01Constant.FCDUO_NEXTVO_04, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Th020p01Constant.FORMID_04));
				new Th020f02Facade().DoMEISAIHEAD_IRO_NM1_FRM(facadeContext);
				// 次画面のフォームビーンを設定
				fvm.SetFormVO(Th020p01Constant.PGID, Th020p01Constant.FORMID_04, (Th020f04Form)facadeContext.GetUserObject(Th020p01Constant.FCDUO_NEXTVO_04));
				// new Th020f02Facade().DoMEISAIHEAD_IRO_NM6_FRM(facadeContext);


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
			EndMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM6_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Meisaihead_iro_nm7())
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Meisaihead_iro_nm7())
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnMEISAIHEAD_IRO_NM7_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM7_FRM");
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

				// Facade処理は統一する
				// 選択列の情報をDictionaryに保持する
				Th020f02Form formVo = (Th020f02Form)pageContext.GetFormVO();

				// 明細標題ハッシュテーブル取得
				Hashtable HeadRec = (Hashtable)formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_HASH];

				// JANコードを保持
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_JAN_CD] = HeadRec["JAN_CD07"].ToString();
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_SIZE_NM] = HeadRec["SIZE_NM07"].ToString();

				// 次画面のフォームVOをファサードに設定
				FormVOManager fvm = new FormVOManager(Session);
				facadeContext.SetUserObject(Th020p01Constant.FCDUO_NEXTVO_04, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Th020p01Constant.FORMID_04));
				new Th020f02Facade().DoMEISAIHEAD_IRO_NM1_FRM(facadeContext);
				// 次画面のフォームビーンを設定
				fvm.SetFormVO(Th020p01Constant.PGID, Th020p01Constant.FORMID_04, (Th020f04Form)facadeContext.GetUserObject(Th020p01Constant.FCDUO_NEXTVO_04));
				// new Th020f02Facade().DoMEISAIHEAD_IRO_NM7_FRM(facadeContext);


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
			EndMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM7_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Meisaihead_iro_nm8())
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Meisaihead_iro_nm8())
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnMEISAIHEAD_IRO_NM8_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM8_FRM");
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

				// Facade処理は統一する
				// 選択列の情報をDictionaryに保持する
				Th020f02Form formVo = (Th020f02Form)pageContext.GetFormVO();

				// 明細標題ハッシュテーブル取得
				Hashtable HeadRec = (Hashtable)formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_HASH];

				// JANコードを保持
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_JAN_CD] = HeadRec["JAN_CD08"].ToString();
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_SIZE_NM] = HeadRec["SIZE_NM08"].ToString();

				// 次画面のフォームVOをファサードに設定
				FormVOManager fvm = new FormVOManager(Session);
				facadeContext.SetUserObject(Th020p01Constant.FCDUO_NEXTVO_04, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Th020p01Constant.FORMID_04));
				new Th020f02Facade().DoMEISAIHEAD_IRO_NM1_FRM(facadeContext);
				// 次画面のフォームビーンを設定
				fvm.SetFormVO(Th020p01Constant.PGID, Th020p01Constant.FORMID_04, (Th020f04Form)facadeContext.GetUserObject(Th020p01Constant.FCDUO_NEXTVO_04));
				// new Th020f02Facade().DoMEISAIHEAD_IRO_NM8_FRM(facadeContext);


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
			EndMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM8_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Meisaihead_iro_nm9())
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Meisaihead_iro_nm9())
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnMEISAIHEAD_IRO_NM9_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM9_FRM");
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

				// Facade処理は統一する
				// 選択列の情報をDictionaryに保持する
				Th020f02Form formVo = (Th020f02Form)pageContext.GetFormVO();

				// 明細標題ハッシュテーブル取得
				Hashtable HeadRec = (Hashtable)formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_HASH];

				// JANコードを保持
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_JAN_CD] = HeadRec["JAN_CD09"].ToString();
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_SIZE_NM] = HeadRec["SIZE_NM09"].ToString();

				// 次画面のフォームVOをファサードに設定
				FormVOManager fvm = new FormVOManager(Session);
				facadeContext.SetUserObject(Th020p01Constant.FCDUO_NEXTVO_04, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Th020p01Constant.FORMID_04));
				new Th020f02Facade().DoMEISAIHEAD_IRO_NM1_FRM(facadeContext);
				// 次画面のフォームビーンを設定
				fvm.SetFormVO(Th020p01Constant.PGID, Th020p01Constant.FORMID_04, (Th020f04Form)facadeContext.GetUserObject(Th020p01Constant.FCDUO_NEXTVO_04));
				// new Th020f02Facade().DoMEISAIHEAD_IRO_NM9_FRM(facadeContext);


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
			EndMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM9_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Meisaihead_iro_nm10())
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Meisaihead_iro_nm10())
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnMEISAIHEAD_IRO_NM10_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM10_FRM");
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

				// Facade処理は統一する
				// 選択列の情報をDictionaryに保持する
				Th020f02Form formVo = (Th020f02Form)pageContext.GetFormVO();

				// 明細標題ハッシュテーブル取得
				Hashtable HeadRec = (Hashtable)formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_HASH];

				// JANコードを保持
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_JAN_CD] = HeadRec["JAN_CD10"].ToString();
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_SIZE_NM] = HeadRec["SIZE_NM10"].ToString();

				// 次画面のフォームVOをファサードに設定
				FormVOManager fvm = new FormVOManager(Session);
				facadeContext.SetUserObject(Th020p01Constant.FCDUO_NEXTVO_04, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Th020p01Constant.FORMID_04));
				new Th020f02Facade().DoMEISAIHEAD_IRO_NM1_FRM(facadeContext);
				// 次画面のフォームビーンを設定
				fvm.SetFormVO(Th020p01Constant.PGID, Th020p01Constant.FORMID_04, (Th020f04Form)facadeContext.GetUserObject(Th020p01Constant.FCDUO_NEXTVO_04));
				// new Th020f02Facade().DoMEISAIHEAD_IRO_NM10_FRM(facadeContext);


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
			EndMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM10_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Meisaihead_iro_nm11())
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Meisaihead_iro_nm11())
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnMEISAIHEAD_IRO_NM11_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM11_FRM");
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

				// Facade処理は統一する
				// 選択列の情報をDictionaryに保持する
				Th020f02Form formVo = (Th020f02Form)pageContext.GetFormVO();

				// 明細標題ハッシュテーブル取得
				Hashtable HeadRec = (Hashtable)formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_HASH];

				// JANコードを保持
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_JAN_CD] = HeadRec["JAN_CD11"].ToString();
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_SIZE_NM] = HeadRec["SIZE_NM11"].ToString();

				// 次画面のフォームVOをファサードに設定
				FormVOManager fvm = new FormVOManager(Session);
				facadeContext.SetUserObject(Th020p01Constant.FCDUO_NEXTVO_04, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Th020p01Constant.FORMID_04));
				new Th020f02Facade().DoMEISAIHEAD_IRO_NM1_FRM(facadeContext);
				// 次画面のフォームビーンを設定
				fvm.SetFormVO(Th020p01Constant.PGID, Th020p01Constant.FORMID_04, (Th020f04Form)facadeContext.GetUserObject(Th020p01Constant.FCDUO_NEXTVO_04));
				// new Th020f02Facade().DoMEISAIHEAD_IRO_NM11_FRM(facadeContext);


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
			EndMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM11_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Meisaihead_iro_nm12())
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Meisaihead_iro_nm12())
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnMEISAIHEAD_IRO_NM12_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM12_FRM");
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

				// Facade処理は統一する
				// 選択列の情報をDictionaryに保持する
				Th020f02Form formVo = (Th020f02Form)pageContext.GetFormVO();

				// 明細標題ハッシュテーブル取得
				Hashtable HeadRec = (Hashtable)formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_HASH];

				// JANコードを保持
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_JAN_CD] = HeadRec["JAN_CD12"].ToString();
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_SIZE_NM] = HeadRec["SIZE_NM12"].ToString();

				// 次画面のフォームVOをファサードに設定
				FormVOManager fvm = new FormVOManager(Session);
				facadeContext.SetUserObject(Th020p01Constant.FCDUO_NEXTVO_04, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Th020p01Constant.FORMID_04));
				new Th020f02Facade().DoMEISAIHEAD_IRO_NM1_FRM(facadeContext);
				// 次画面のフォームビーンを設定
				fvm.SetFormVO(Th020p01Constant.PGID, Th020p01Constant.FORMID_04, (Th020f04Form)facadeContext.GetUserObject(Th020p01Constant.FCDUO_NEXTVO_04));
				// new Th020f02Facade().DoMEISAIHEAD_IRO_NM12_FRM(facadeContext);


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
			EndMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM12_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Meisaihead_iro_nm13())
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Meisaihead_iro_nm13())
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnMEISAIHEAD_IRO_NM13_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM13_FRM");
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

				// Facade処理は統一する
				// 選択列の情報をDictionaryに保持する
				Th020f02Form formVo = (Th020f02Form)pageContext.GetFormVO();

				// 明細標題ハッシュテーブル取得
				Hashtable HeadRec = (Hashtable)formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_HASH];

				// JANコードを保持
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_JAN_CD] = HeadRec["JAN_CD13"].ToString();
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_SIZE_NM] = HeadRec["SIZE_NM13"].ToString();

				// 次画面のフォームVOをファサードに設定
				FormVOManager fvm = new FormVOManager(Session);
				facadeContext.SetUserObject(Th020p01Constant.FCDUO_NEXTVO_04, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Th020p01Constant.FORMID_04));
				new Th020f02Facade().DoMEISAIHEAD_IRO_NM1_FRM(facadeContext);
				// 次画面のフォームビーンを設定
				fvm.SetFormVO(Th020p01Constant.PGID, Th020p01Constant.FORMID_04, (Th020f04Form)facadeContext.GetUserObject(Th020p01Constant.FCDUO_NEXTVO_04));
				// new Th020f02Facade().DoMEISAIHEAD_IRO_NM2_FRM(facadeContext);


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
			EndMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM13_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Meisaihead_iro_nm14())
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Meisaihead_iro_nm14())
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnMEISAIHEAD_IRO_NM14_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM14_FRM");
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

				// Facade処理は統一する
				// 選択列の情報をDictionaryに保持する
				Th020f02Form formVo = (Th020f02Form)pageContext.GetFormVO();

				// 明細標題ハッシュテーブル取得
				Hashtable HeadRec = (Hashtable)formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_HASH];

				// JANコードを保持
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_JAN_CD] = HeadRec["JAN_CD14"].ToString();
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_SIZE_NM] = HeadRec["SIZE_NM14"].ToString();

				// 次画面のフォームVOをファサードに設定
				FormVOManager fvm = new FormVOManager(Session);
				facadeContext.SetUserObject(Th020p01Constant.FCDUO_NEXTVO_04, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Th020p01Constant.FORMID_04));
				new Th020f02Facade().DoMEISAIHEAD_IRO_NM1_FRM(facadeContext);
				// 次画面のフォームビーンを設定
				fvm.SetFormVO(Th020p01Constant.PGID, Th020p01Constant.FORMID_04, (Th020f04Form)facadeContext.GetUserObject(Th020p01Constant.FCDUO_NEXTVO_04));
				// new Th020f02Facade().DoMEISAIHEAD_IRO_NM2_FRM(facadeContext);


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
			EndMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM14_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Meisaihead_iro_nm15())
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Meisaihead_iro_nm15())
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnMEISAIHEAD_IRO_NM15_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM15_FRM");
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

				// Facade処理は統一する
				// 選択列の情報をDictionaryに保持する
				Th020f02Form formVo = (Th020f02Form)pageContext.GetFormVO();

				// 明細標題ハッシュテーブル取得
				Hashtable HeadRec = (Hashtable)formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_HASH];

				// JANコードを保持
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_JAN_CD] = HeadRec["JAN_CD15"].ToString();
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_SIZE_NM] = HeadRec["SIZE_NM15"].ToString();

				// 次画面のフォームVOをファサードに設定
				FormVOManager fvm = new FormVOManager(Session);
				facadeContext.SetUserObject(Th020p01Constant.FCDUO_NEXTVO_04, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Th020p01Constant.FORMID_04));
				new Th020f02Facade().DoMEISAIHEAD_IRO_NM1_FRM(facadeContext);
				// 次画面のフォームビーンを設定
				fvm.SetFormVO(Th020p01Constant.PGID, Th020p01Constant.FORMID_04, (Th020f04Form)facadeContext.GetUserObject(Th020p01Constant.FCDUO_NEXTVO_04));
				// new Th020f02Facade().DoMEISAIHEAD_IRO_NM2_FRM(facadeContext);


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
			EndMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM15_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Meisaihead_iro_nm16())
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Meisaihead_iro_nm16())
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnMEISAIHEAD_IRO_NM16_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM16_FRM");
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

				// Facade処理は統一する
				// 選択列の情報をDictionaryに保持する
				Th020f02Form formVo = (Th020f02Form)pageContext.GetFormVO();

				// 明細標題ハッシュテーブル取得
				Hashtable HeadRec = (Hashtable)formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_HASH];

				// JANコードを保持
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_JAN_CD] = HeadRec["JAN_CD16"].ToString();
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_SIZE_NM] = HeadRec["SIZE_NM16"].ToString();

				// 次画面のフォームVOをファサードに設定
				FormVOManager fvm = new FormVOManager(Session);
				facadeContext.SetUserObject(Th020p01Constant.FCDUO_NEXTVO_04, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Th020p01Constant.FORMID_04));
				new Th020f02Facade().DoMEISAIHEAD_IRO_NM1_FRM(facadeContext);
				// 次画面のフォームビーンを設定
				fvm.SetFormVO(Th020p01Constant.PGID, Th020p01Constant.FORMID_04, (Th020f04Form)facadeContext.GetUserObject(Th020p01Constant.FCDUO_NEXTVO_04));
				// new Th020f02Facade().DoMEISAIHEAD_IRO_NM2_FRM(facadeContext);


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
			EndMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM16_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Meisaihead_iro_nm17())
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Meisaihead_iro_nm17())
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnMEISAIHEAD_IRO_NM17_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM17_FRM");
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

				// Facade処理は統一する
				// 選択列の情報をDictionaryに保持する
				Th020f02Form formVo = (Th020f02Form)pageContext.GetFormVO();

				// 明細標題ハッシュテーブル取得
				Hashtable HeadRec = (Hashtable)formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_HASH];

				// JANコードを保持
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_JAN_CD] = HeadRec["JAN_CD17"].ToString();
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_SIZE_NM] = HeadRec["SIZE_NM17"].ToString();

				// 次画面のフォームVOをファサードに設定
				FormVOManager fvm = new FormVOManager(Session);
				facadeContext.SetUserObject(Th020p01Constant.FCDUO_NEXTVO_04, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Th020p01Constant.FORMID_04));
				new Th020f02Facade().DoMEISAIHEAD_IRO_NM1_FRM(facadeContext);
				// 次画面のフォームビーンを設定
				fvm.SetFormVO(Th020p01Constant.PGID, Th020p01Constant.FORMID_04, (Th020f04Form)facadeContext.GetUserObject(Th020p01Constant.FCDUO_NEXTVO_04));
				// new Th020f02Facade().DoMEISAIHEAD_IRO_NM2_FRM(facadeContext);


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
			EndMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM17_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Meisaihead_iro_nm18())
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Meisaihead_iro_nm18())
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnMEISAIHEAD_IRO_NM18_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM18_FRM");
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

				// Facade処理は統一する
				// 選択列の情報をDictionaryに保持する
				Th020f02Form formVo = (Th020f02Form)pageContext.GetFormVO();

				// 明細標題ハッシュテーブル取得
				Hashtable HeadRec = (Hashtable)formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_HASH];

				// JANコードを保持
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_JAN_CD] = HeadRec["JAN_CD18"].ToString();
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_SIZE_NM] = HeadRec["SIZE_NM18"].ToString();

				// 次画面のフォームVOをファサードに設定
				FormVOManager fvm = new FormVOManager(Session);
				facadeContext.SetUserObject(Th020p01Constant.FCDUO_NEXTVO_04, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Th020p01Constant.FORMID_04));
				new Th020f02Facade().DoMEISAIHEAD_IRO_NM1_FRM(facadeContext);
				// 次画面のフォームビーンを設定
				fvm.SetFormVO(Th020p01Constant.PGID, Th020p01Constant.FORMID_04, (Th020f04Form)facadeContext.GetUserObject(Th020p01Constant.FCDUO_NEXTVO_04));
				// new Th020f02Facade().DoMEISAIHEAD_IRO_NM2_FRM(facadeContext);


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
			EndMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM18_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Meisaihead_iro_nm19())
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Meisaihead_iro_nm19())
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnMEISAIHEAD_IRO_NM19_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM19_FRM");
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

				// Facade処理は統一する
				// 選択列の情報をDictionaryに保持する
				Th020f02Form formVo = (Th020f02Form)pageContext.GetFormVO();

				// 明細標題ハッシュテーブル取得
				Hashtable HeadRec = (Hashtable)formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_HASH];

				// JANコードを保持
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_JAN_CD] = HeadRec["JAN_CD19"].ToString();
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_SIZE_NM] = HeadRec["SIZE_NM19"].ToString();

				// 次画面のフォームVOをファサードに設定
				FormVOManager fvm = new FormVOManager(Session);
				facadeContext.SetUserObject(Th020p01Constant.FCDUO_NEXTVO_04, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Th020p01Constant.FORMID_04));
				new Th020f02Facade().DoMEISAIHEAD_IRO_NM1_FRM(facadeContext);
				// 次画面のフォームビーンを設定
				fvm.SetFormVO(Th020p01Constant.PGID, Th020p01Constant.FORMID_04, (Th020f04Form)facadeContext.GetUserObject(Th020p01Constant.FCDUO_NEXTVO_04));
				// new Th020f02Facade().DoMEISAIHEAD_IRO_NM2_FRM(facadeContext);


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
			EndMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM19_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Meisaihead_iro_nm20())
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Meisaihead_iro_nm20())
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnMEISAIHEAD_IRO_NM20_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM20_FRM");
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

				// Facade処理は統一する
				// 選択列の情報をDictionaryに保持する
				Th020f02Form formVo = (Th020f02Form)pageContext.GetFormVO();

				// 明細標題ハッシュテーブル取得
				Hashtable HeadRec = (Hashtable)formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_HASH];

				// JANコードを保持
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_JAN_CD] = HeadRec["JAN_CD20"].ToString();
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_SIZE_NM] = HeadRec["SIZE_NM20"].ToString();

				// 次画面のフォームVOをファサードに設定
				FormVOManager fvm = new FormVOManager(Session);
				facadeContext.SetUserObject(Th020p01Constant.FCDUO_NEXTVO_04, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Th020p01Constant.FORMID_04));
				new Th020f02Facade().DoMEISAIHEAD_IRO_NM1_FRM(facadeContext);
				// 次画面のフォームビーンを設定
				fvm.SetFormVO(Th020p01Constant.PGID, Th020p01Constant.FORMID_04, (Th020f04Form)facadeContext.GetUserObject(Th020p01Constant.FCDUO_NEXTVO_04));
				// new Th020f02Facade().DoMEISAIHEAD_IRO_NM2_FRM(facadeContext);


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
			EndMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM20_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Meisaihead_iro_nm21())
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Meisaihead_iro_nm21())
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnMEISAIHEAD_IRO_NM21_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM21_FRM");
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

				// Facade処理は統一する
				// 選択列の情報をDictionaryに保持する
				Th020f02Form formVo = (Th020f02Form)pageContext.GetFormVO();

				// 明細標題ハッシュテーブル取得
				Hashtable HeadRec = (Hashtable)formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_HASH];

				// JANコードを保持
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_JAN_CD] = HeadRec["JAN_CD21"].ToString();
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_SIZE_NM] = HeadRec["SIZE_NM21"].ToString();

				// 次画面のフォームVOをファサードに設定
				FormVOManager fvm = new FormVOManager(Session);
				facadeContext.SetUserObject(Th020p01Constant.FCDUO_NEXTVO_04, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Th020p01Constant.FORMID_04));
				new Th020f02Facade().DoMEISAIHEAD_IRO_NM1_FRM(facadeContext);
				// 次画面のフォームビーンを設定
				fvm.SetFormVO(Th020p01Constant.PGID, Th020p01Constant.FORMID_04, (Th020f04Form)facadeContext.GetUserObject(Th020p01Constant.FCDUO_NEXTVO_04));
				// new Th020f02Facade().DoMEISAIHEAD_IRO_NM2_FRM(facadeContext);


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
			EndMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM21_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Meisaihead_iro_nm22())
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Meisaihead_iro_nm22())
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnMEISAIHEAD_IRO_NM22_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM22_FRM");
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

				// Facade処理は統一する
				// 選択列の情報をDictionaryに保持する
				Th020f02Form formVo = (Th020f02Form)pageContext.GetFormVO();

				// 明細標題ハッシュテーブル取得
				Hashtable HeadRec = (Hashtable)formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_HASH];

				// JANコードを保持
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_JAN_CD] = HeadRec["JAN_CD22"].ToString();
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_SIZE_NM] = HeadRec["SIZE_NM22"].ToString();

				// 次画面のフォームVOをファサードに設定
				FormVOManager fvm = new FormVOManager(Session);
				facadeContext.SetUserObject(Th020p01Constant.FCDUO_NEXTVO_04, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Th020p01Constant.FORMID_04));
				new Th020f02Facade().DoMEISAIHEAD_IRO_NM1_FRM(facadeContext);
				// 次画面のフォームビーンを設定
				fvm.SetFormVO(Th020p01Constant.PGID, Th020p01Constant.FORMID_04, (Th020f04Form)facadeContext.GetUserObject(Th020p01Constant.FCDUO_NEXTVO_04));
				// new Th020f02Facade().DoMEISAIHEAD_IRO_NM2_FRM(facadeContext);


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
			EndMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM22_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Meisaihead_iro_nm23())
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Meisaihead_iro_nm23())
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnMEISAIHEAD_IRO_NM23_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM23_FRM");
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

				// Facade処理は統一する
				// 選択列の情報をDictionaryに保持する
				Th020f02Form formVo = (Th020f02Form)pageContext.GetFormVO();

				// 明細標題ハッシュテーブル取得
				Hashtable HeadRec = (Hashtable)formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_HASH];

				// JANコードを保持
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_JAN_CD] = HeadRec["JAN_CD23"].ToString();
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_SIZE_NM] = HeadRec["SIZE_NM23"].ToString();

				// 次画面のフォームVOをファサードに設定
				FormVOManager fvm = new FormVOManager(Session);
				facadeContext.SetUserObject(Th020p01Constant.FCDUO_NEXTVO_04, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Th020p01Constant.FORMID_04));
				new Th020f02Facade().DoMEISAIHEAD_IRO_NM1_FRM(facadeContext);
				// 次画面のフォームビーンを設定
				fvm.SetFormVO(Th020p01Constant.PGID, Th020p01Constant.FORMID_04, (Th020f04Form)facadeContext.GetUserObject(Th020p01Constant.FCDUO_NEXTVO_04));
				// new Th020f02Facade().DoMEISAIHEAD_IRO_NM2_FRM(facadeContext);


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
			EndMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM23_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Meisaihead_iro_nm24())
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Meisaihead_iro_nm24())
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnMEISAIHEAD_IRO_NM24_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM24_FRM");
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

				// Facade処理は統一する
				// 選択列の情報をDictionaryに保持する
				Th020f02Form formVo = (Th020f02Form)pageContext.GetFormVO();

				// 明細標題ハッシュテーブル取得
				Hashtable HeadRec = (Hashtable)formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_HASH];

				// JANコードを保持
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_JAN_CD] = HeadRec["JAN_CD24"].ToString();
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_SIZE_NM] = HeadRec["SIZE_NM24"].ToString();

				// 次画面のフォームVOをファサードに設定
				FormVOManager fvm = new FormVOManager(Session);
				facadeContext.SetUserObject(Th020p01Constant.FCDUO_NEXTVO_04, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Th020p01Constant.FORMID_04));
				new Th020f02Facade().DoMEISAIHEAD_IRO_NM1_FRM(facadeContext);
				// 次画面のフォームビーンを設定
				fvm.SetFormVO(Th020p01Constant.PGID, Th020p01Constant.FORMID_04, (Th020f04Form)facadeContext.GetUserObject(Th020p01Constant.FCDUO_NEXTVO_04));
				// new Th020f02Facade().DoMEISAIHEAD_IRO_NM2_FRM(facadeContext);


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
			EndMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM24_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Meisaihead_iro_nm25())
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Meisaihead_iro_nm25())
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnMEISAIHEAD_IRO_NM25_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM25_FRM");
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

				// Facade処理は統一する
				// 選択列の情報をDictionaryに保持する
				Th020f02Form formVo = (Th020f02Form)pageContext.GetFormVO();

				// 明細標題ハッシュテーブル取得
				Hashtable HeadRec = (Hashtable)formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_HASH];

				// JANコードを保持
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_JAN_CD] = HeadRec["JAN_CD25"].ToString();
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_SIZE_NM] = HeadRec["SIZE_NM25"].ToString();

				// 次画面のフォームVOをファサードに設定
				FormVOManager fvm = new FormVOManager(Session);
				facadeContext.SetUserObject(Th020p01Constant.FCDUO_NEXTVO_04, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Th020p01Constant.FORMID_04));
				new Th020f02Facade().DoMEISAIHEAD_IRO_NM1_FRM(facadeContext);
				// 次画面のフォームビーンを設定
				fvm.SetFormVO(Th020p01Constant.PGID, Th020p01Constant.FORMID_04, (Th020f04Form)facadeContext.GetUserObject(Th020p01Constant.FCDUO_NEXTVO_04));
				// new Th020f02Facade().DoMEISAIHEAD_IRO_NM2_FRM(facadeContext);


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
			EndMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM25_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Meisaihead_iro_nm26())
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Meisaihead_iro_nm26())
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnMEISAIHEAD_IRO_NM26_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM26_FRM");
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

				// Facade処理は統一する
				// 選択列の情報をDictionaryに保持する
				Th020f02Form formVo = (Th020f02Form)pageContext.GetFormVO();

				// 明細標題ハッシュテーブル取得
				Hashtable HeadRec = (Hashtable)formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_HASH];

				// JANコードを保持
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_JAN_CD] = HeadRec["JAN_CD26"].ToString();
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_SIZE_NM] = HeadRec["SIZE_NM26"].ToString();

				// 次画面のフォームVOをファサードに設定
				FormVOManager fvm = new FormVOManager(Session);
				facadeContext.SetUserObject(Th020p01Constant.FCDUO_NEXTVO_04, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Th020p01Constant.FORMID_04));
				new Th020f02Facade().DoMEISAIHEAD_IRO_NM1_FRM(facadeContext);
				// 次画面のフォームビーンを設定
				fvm.SetFormVO(Th020p01Constant.PGID, Th020p01Constant.FORMID_04, (Th020f04Form)facadeContext.GetUserObject(Th020p01Constant.FCDUO_NEXTVO_04));
				// new Th020f02Facade().DoMEISAIHEAD_IRO_NM2_FRM(facadeContext);


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
			EndMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM26_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Meisaihead_iro_nm27())
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Meisaihead_iro_nm27())
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnMEISAIHEAD_IRO_NM27_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM27_FRM");
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

				// Facade処理は統一する
				// 選択列の情報をDictionaryに保持する
				Th020f02Form formVo = (Th020f02Form)pageContext.GetFormVO();

				// 明細標題ハッシュテーブル取得
				Hashtable HeadRec = (Hashtable)formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_HASH];

				// JANコードを保持
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_JAN_CD] = HeadRec["JAN_CD27"].ToString();
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_SIZE_NM] = HeadRec["SIZE_NM27"].ToString();

				// 次画面のフォームVOをファサードに設定
				FormVOManager fvm = new FormVOManager(Session);
				facadeContext.SetUserObject(Th020p01Constant.FCDUO_NEXTVO_04, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Th020p01Constant.FORMID_04));
				new Th020f02Facade().DoMEISAIHEAD_IRO_NM1_FRM(facadeContext);
				// 次画面のフォームビーンを設定
				fvm.SetFormVO(Th020p01Constant.PGID, Th020p01Constant.FORMID_04, (Th020f04Form)facadeContext.GetUserObject(Th020p01Constant.FCDUO_NEXTVO_04));
				// new Th020f02Facade().DoMEISAIHEAD_IRO_NM2_FRM(facadeContext);


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
			EndMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM27_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Meisaihead_iro_nm28())
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Meisaihead_iro_nm28())
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnMEISAIHEAD_IRO_NM28_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM28_FRM");
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

				// Facade処理は統一する
				// 選択列の情報をDictionaryに保持する
				Th020f02Form formVo = (Th020f02Form)pageContext.GetFormVO();

				// 明細標題ハッシュテーブル取得
				Hashtable HeadRec = (Hashtable)formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_HASH];

				// JANコードを保持
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_JAN_CD] = HeadRec["JAN_CD28"].ToString();
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_SIZE_NM] = HeadRec["SIZE_NM28"].ToString();

				// 次画面のフォームVOをファサードに設定
				FormVOManager fvm = new FormVOManager(Session);
				facadeContext.SetUserObject(Th020p01Constant.FCDUO_NEXTVO_04, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Th020p01Constant.FORMID_04));
				new Th020f02Facade().DoMEISAIHEAD_IRO_NM1_FRM(facadeContext);
				// 次画面のフォームビーンを設定
				fvm.SetFormVO(Th020p01Constant.PGID, Th020p01Constant.FORMID_04, (Th020f04Form)facadeContext.GetUserObject(Th020p01Constant.FCDUO_NEXTVO_04));
				// new Th020f02Facade().DoMEISAIHEAD_IRO_NM2_FRM(facadeContext);


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
			EndMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM28_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Meisaihead_iro_nm29())
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Meisaihead_iro_nm29())
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnMEISAIHEAD_IRO_NM29_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM29_FRM");
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

				// Facade処理は統一する
				// 選択列の情報をDictionaryに保持する
				Th020f02Form formVo = (Th020f02Form)pageContext.GetFormVO();

				// 明細標題ハッシュテーブル取得
				Hashtable HeadRec = (Hashtable)formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_HASH];

				// JANコードを保持
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_JAN_CD] = HeadRec["JAN_CD29"].ToString();
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_SIZE_NM] = HeadRec["SIZE_NM29"].ToString();

				// 次画面のフォームVOをファサードに設定
				FormVOManager fvm = new FormVOManager(Session);
				facadeContext.SetUserObject(Th020p01Constant.FCDUO_NEXTVO_04, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Th020p01Constant.FORMID_04));
				new Th020f02Facade().DoMEISAIHEAD_IRO_NM1_FRM(facadeContext);
				// 次画面のフォームビーンを設定
				fvm.SetFormVO(Th020p01Constant.PGID, Th020p01Constant.FORMID_04, (Th020f04Form)facadeContext.GetUserObject(Th020p01Constant.FCDUO_NEXTVO_04));
				// new Th020f02Facade().DoMEISAIHEAD_IRO_NM2_FRM(facadeContext);


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
			EndMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM29_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Meisaihead_iro_nm30())
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Meisaihead_iro_nm30())
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnMEISAIHEAD_IRO_NM30_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM30_FRM");
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

				// Facade処理は統一する
				// 選択列の情報をDictionaryに保持する
				Th020f02Form formVo = (Th020f02Form)pageContext.GetFormVO();

				// 明細標題ハッシュテーブル取得
				Hashtable HeadRec = (Hashtable)formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_HASH];

				// JANコードを保持
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_JAN_CD] = HeadRec["JAN_CD30"].ToString();
				formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_SIZE_NM] = HeadRec["SIZE_NM30"].ToString();

				// 次画面のフォームVOをファサードに設定
				FormVOManager fvm = new FormVOManager(Session);
				facadeContext.SetUserObject(Th020p01Constant.FCDUO_NEXTVO_04, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Th020p01Constant.FORMID_04));
				new Th020f02Facade().DoMEISAIHEAD_IRO_NM1_FRM(facadeContext);
				// 次画面のフォームビーンを設定
				fvm.SetFormVO(Th020p01Constant.PGID, Th020p01Constant.FORMID_04, (Th020f04Form)facadeContext.GetUserObject(Th020p01Constant.FCDUO_NEXTVO_04));
				// new Th020f02Facade().DoMEISAIHEAD_IRO_NM2_FRM(facadeContext);


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
			EndMethod(sender, e, this.GetType().Name + ".OnMEISAIHEAD_IRO_NM30_FRM");
			
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
						Th020f02Form th020f02Form = (Th020f02Form)pageContext.GetFormVO();

						//明細ページ情報を表示する
						ShowListPageInfo(th020f02Form);
			
						//明細部データを表示する
						RenderList(th020f02Form, pageContext.FormInfo, formResource, lang);

						//カード部データを表示する
						RenderCard(th020f02Form, pageContext.FormInfo, formResource, lang);
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
		/// <param name="th020f02Form">画面FormVO</param>
		private void ShowListPageInfo(Th020f02Form th020f02Form)
		{
			//M1明細ページ情報を表示する。
			ShowM1ListPageInfo(th020f02Form.GetList("M1"));

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
		/// <param name="th020f02Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderList(
			Th020f02Form th020f02Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//画面のM1明細部データを設定する。
			RenderM1List(th020f02Form, formInfo, formResource, lang);
			
		}
		#endregion

		#region M1明細データを表示する
		/// <summary>
		/// M1明細データを表示する。
		/// </summary>
		/// <param name="th020f02Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderM1List(
			Th020f02Form th020f02Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//M1明細部データソースを設定する。
			M1.DataSource = th020f02Form.GetPageViewList("M1");
			M1.DataBind();

			//M1明細部データをフォーマットする。
			IList m1DataList = (IList)M1.DataSource;
			
			for (int index = 0; index < M1.Items.Count; index++)
			{
				Th020f02M1Form th020f02M1Form = (Th020f02M1Form)m1DataList[index];
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1rowno"),
					DataFormatUtil.GetFormatItem(th020f02M1Form.M1rowno,formInfo["M1rowno"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1tenpo_cd"),
					DataFormatUtil.GetFormatItem(th020f02M1Form.M1tenpo_cd,formInfo["M1tenpo_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1tenpo_nm"),
					DataFormatUtil.GetFormatItem(th020f02M1Form.M1tenpo_nm,formInfo["M1tenpo_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1gokei_suryo"),
					DataFormatUtil.GetFormatItem(th020f02M1Form.M1gokei_suryo,formInfo["M1gokei_suryo"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1syoka_rtu"),
					DataFormatUtil.GetFormatItem(th020f02M1Form.M1syoka_rtu,formInfo["M1syoka_rtu"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1suryo1"),
					DataFormatUtil.GetFormatItem(th020f02M1Form.M1suryo1,formInfo["M1suryo1"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1suryo2"),
					DataFormatUtil.GetFormatItem(th020f02M1Form.M1suryo2,formInfo["M1suryo2"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1suryo3"),
					DataFormatUtil.GetFormatItem(th020f02M1Form.M1suryo3,formInfo["M1suryo3"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1suryo4"),
					DataFormatUtil.GetFormatItem(th020f02M1Form.M1suryo4,formInfo["M1suryo4"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1suryo5"),
					DataFormatUtil.GetFormatItem(th020f02M1Form.M1suryo5,formInfo["M1suryo5"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1suryo6"),
					DataFormatUtil.GetFormatItem(th020f02M1Form.M1suryo6,formInfo["M1suryo6"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1suryo7"),
					DataFormatUtil.GetFormatItem(th020f02M1Form.M1suryo7,formInfo["M1suryo7"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1suryo8"),
					DataFormatUtil.GetFormatItem(th020f02M1Form.M1suryo8,formInfo["M1suryo8"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1suryo9"),
					DataFormatUtil.GetFormatItem(th020f02M1Form.M1suryo9,formInfo["M1suryo9"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1suryo10"),
					DataFormatUtil.GetFormatItem(th020f02M1Form.M1suryo10,formInfo["M1suryo10"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1suryo11"),
					DataFormatUtil.GetFormatItem(th020f02M1Form.M1suryo11,formInfo["M1suryo11"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1suryo12"),
					DataFormatUtil.GetFormatItem(th020f02M1Form.M1suryo12,formInfo["M1suryo12"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1suryo13"),
					DataFormatUtil.GetFormatItem(th020f02M1Form.M1suryo13,formInfo["M1suryo13"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1suryo14"),
					DataFormatUtil.GetFormatItem(th020f02M1Form.M1suryo14,formInfo["M1suryo14"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1suryo15"),
					DataFormatUtil.GetFormatItem(th020f02M1Form.M1suryo15,formInfo["M1suryo15"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1suryo16"),
					DataFormatUtil.GetFormatItem(th020f02M1Form.M1suryo16,formInfo["M1suryo16"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1suryo17"),
					DataFormatUtil.GetFormatItem(th020f02M1Form.M1suryo17,formInfo["M1suryo17"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1suryo18"),
					DataFormatUtil.GetFormatItem(th020f02M1Form.M1suryo18,formInfo["M1suryo18"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1suryo19"),
					DataFormatUtil.GetFormatItem(th020f02M1Form.M1suryo19,formInfo["M1suryo19"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1suryo20"),
					DataFormatUtil.GetFormatItem(th020f02M1Form.M1suryo20,formInfo["M1suryo20"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1suryo21"),
					DataFormatUtil.GetFormatItem(th020f02M1Form.M1suryo21,formInfo["M1suryo21"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1suryo22"),
					DataFormatUtil.GetFormatItem(th020f02M1Form.M1suryo22,formInfo["M1suryo22"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1suryo23"),
					DataFormatUtil.GetFormatItem(th020f02M1Form.M1suryo23,formInfo["M1suryo23"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1suryo24"),
					DataFormatUtil.GetFormatItem(th020f02M1Form.M1suryo24,formInfo["M1suryo24"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1suryo25"),
					DataFormatUtil.GetFormatItem(th020f02M1Form.M1suryo25,formInfo["M1suryo25"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1suryo26"),
					DataFormatUtil.GetFormatItem(th020f02M1Form.M1suryo26,formInfo["M1suryo26"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1suryo27"),
					DataFormatUtil.GetFormatItem(th020f02M1Form.M1suryo27,formInfo["M1suryo27"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1suryo28"),
					DataFormatUtil.GetFormatItem(th020f02M1Form.M1suryo28,formInfo["M1suryo28"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1suryo29"),
					DataFormatUtil.GetFormatItem(th020f02M1Form.M1suryo29,formInfo["M1suryo29"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1suryo30"),
					DataFormatUtil.GetFormatItem(th020f02M1Form.M1suryo30,formInfo["M1suryo30"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1selectorcheckbox"),
					DataFormatUtil.GetFormatItem(th020f02M1Form.M1selectorcheckbox,formInfo["M1selectorcheckbox"]));
				((System.Web.UI.WebControls.CheckBox)M1.Items[index].FindControl("M1selectorcheckbox")).Text =
					formResource.GetString("M1selectorcheckbox", lang);
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1entersyoriflg"),
					DataFormatUtil.GetFormatItem(th020f02M1Form.M1entersyoriflg,formInfo["M1entersyoriflg"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1dtlirokbn"),
					DataFormatUtil.GetFormatItem(th020f02M1Form.M1dtlirokbn,formInfo["M1dtlirokbn"]));

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
				// (M1.HeaderRow.FindControl("M1tenpo_cd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tenpo_cd", lang), base.GetPageContext().FormInfo["M1tenpo_cd"]);
				// (M1.HeaderRow.FindControl("M1tenpo_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tenpo_nm", lang), base.GetPageContext().FormInfo["M1tenpo_nm"]);
				// (M1.HeaderRow.FindControl("M1gokei_suryo") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1gokei_suryo", lang), base.GetPageContext().FormInfo["M1gokei_suryo"]);
				// (M1.HeaderRow.FindControl("M1syoka_rtu") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syoka_rtu", lang), base.GetPageContext().FormInfo["M1syoka_rtu"]);
				// (M1.HeaderRow.FindControl("M1suryo1") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo1", lang), base.GetPageContext().FormInfo["M1suryo1"]);
				// (M1.HeaderRow.FindControl("M1suryo2") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo2", lang), base.GetPageContext().FormInfo["M1suryo2"]);
				// (M1.HeaderRow.FindControl("M1suryo3") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo3", lang), base.GetPageContext().FormInfo["M1suryo3"]);
				// (M1.HeaderRow.FindControl("M1suryo4") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo4", lang), base.GetPageContext().FormInfo["M1suryo4"]);
				// (M1.HeaderRow.FindControl("M1suryo5") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo5", lang), base.GetPageContext().FormInfo["M1suryo5"]);
				// (M1.HeaderRow.FindControl("M1suryo6") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo6", lang), base.GetPageContext().FormInfo["M1suryo6"]);
				// (M1.HeaderRow.FindControl("M1suryo7") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo7", lang), base.GetPageContext().FormInfo["M1suryo7"]);
				// (M1.HeaderRow.FindControl("M1suryo8") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo8", lang), base.GetPageContext().FormInfo["M1suryo8"]);
				// (M1.HeaderRow.FindControl("M1suryo9") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo9", lang), base.GetPageContext().FormInfo["M1suryo9"]);
				// (M1.HeaderRow.FindControl("M1suryo10") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo10", lang), base.GetPageContext().FormInfo["M1suryo10"]);
				// (M1.HeaderRow.FindControl("M1suryo11") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo11", lang), base.GetPageContext().FormInfo["M1suryo11"]);
				// (M1.HeaderRow.FindControl("M1suryo12") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo12", lang), base.GetPageContext().FormInfo["M1suryo12"]);
				// (M1.HeaderRow.FindControl("M1suryo13") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo13", lang), base.GetPageContext().FormInfo["M1suryo13"]);
				// (M1.HeaderRow.FindControl("M1suryo14") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo14", lang), base.GetPageContext().FormInfo["M1suryo14"]);
				// (M1.HeaderRow.FindControl("M1suryo15") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo15", lang), base.GetPageContext().FormInfo["M1suryo15"]);
				// (M1.HeaderRow.FindControl("M1suryo16") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo16", lang), base.GetPageContext().FormInfo["M1suryo16"]);
				// (M1.HeaderRow.FindControl("M1suryo17") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo17", lang), base.GetPageContext().FormInfo["M1suryo17"]);
				// (M1.HeaderRow.FindControl("M1suryo18") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo18", lang), base.GetPageContext().FormInfo["M1suryo18"]);
				// (M1.HeaderRow.FindControl("M1suryo19") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo19", lang), base.GetPageContext().FormInfo["M1suryo19"]);
				// (M1.HeaderRow.FindControl("M1suryo20") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo20", lang), base.GetPageContext().FormInfo["M1suryo20"]);
				// (M1.HeaderRow.FindControl("M1suryo21") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo21", lang), base.GetPageContext().FormInfo["M1suryo21"]);
				// (M1.HeaderRow.FindControl("M1suryo22") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo22", lang), base.GetPageContext().FormInfo["M1suryo22"]);
				// (M1.HeaderRow.FindControl("M1suryo23") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo23", lang), base.GetPageContext().FormInfo["M1suryo23"]);
				// (M1.HeaderRow.FindControl("M1suryo24") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo24", lang), base.GetPageContext().FormInfo["M1suryo24"]);
				// (M1.HeaderRow.FindControl("M1suryo25") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo25", lang), base.GetPageContext().FormInfo["M1suryo25"]);
				// (M1.HeaderRow.FindControl("M1suryo26") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo26", lang), base.GetPageContext().FormInfo["M1suryo26"]);
				// (M1.HeaderRow.FindControl("M1suryo27") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo27", lang), base.GetPageContext().FormInfo["M1suryo27"]);
				// (M1.HeaderRow.FindControl("M1suryo28") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo28", lang), base.GetPageContext().FormInfo["M1suryo28"]);
				// (M1.HeaderRow.FindControl("M1suryo29") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo29", lang), base.GetPageContext().FormInfo["M1suryo29"]);
				// (M1.HeaderRow.FindControl("M1suryo30") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo30", lang), base.GetPageContext().FormInfo["M1suryo30"]);
				// (M1.HeaderRow.FindControl("M1selectorcheckbox") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1selectorcheckbox", lang), base.GetPageContext().FormInfo["M1selectorcheckbox"]);
				// (M1.HeaderRow.FindControl("M1entersyoriflg") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1entersyoriflg", lang), base.GetPageContext().FormInfo["M1entersyoriflg"]);
				// (M1.HeaderRow.FindControl("M1dtlirokbn") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1dtlirokbn", lang), base.GetPageContext().FormInfo["M1dtlirokbn"]);
				// }

		}
		#endregion
		#endregion

		#region カードデータを表示する
		/// <summary>
		/// カードデータを表示する
		/// </summary>
		/// <param name="th020f02Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderCard(
			Th020f02Form th020f02Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			
			ControlUtil.SetControlValue(Head_tenpo_cd,
				DataFormatUtil.GetFormatItem(th020f02Form.Head_tenpo_cd,formInfo["Head_tenpo_cd"]));
			ControlUtil.SetControlValue(Head_tenpo_nm,
				DataFormatUtil.GetFormatItem(th020f02Form.Head_tenpo_nm,formInfo["Head_tenpo_nm"]));
			ControlUtil.SetControlValue(Kaisya_cd,
				DataFormatUtil.GetFormatItem(th020f02Form.Kaisya_cd,formInfo["Kaisya_cd"]));
			ControlUtil.SetControlValue(Kaisya_nm,
				DataFormatUtil.GetFormatItem(th020f02Form.Kaisya_nm,formInfo["Kaisya_nm"]));
			ControlUtil.SetControlValue(Bumon_cd,
				DataFormatUtil.GetFormatItem(th020f02Form.Bumon_cd,formInfo["Bumon_cd"]));
			ControlUtil.SetControlValue(Bumon_nm,
				DataFormatUtil.GetFormatItem(th020f02Form.Bumon_nm,formInfo["Bumon_nm"]));
			ControlUtil.SetControlValue(Hinsyu_ryaku_nm,
				DataFormatUtil.GetFormatItem(th020f02Form.Hinsyu_ryaku_nm,formInfo["Hinsyu_ryaku_nm"]));
			ControlUtil.SetControlValue(Hinsyu_cd,
				DataFormatUtil.GetFormatItem(th020f02Form.Hinsyu_cd,formInfo["Hinsyu_cd"]));
			ControlUtil.SetControlValue(Burando_cd,
				DataFormatUtil.GetFormatItem(th020f02Form.Burando_cd,formInfo["Burando_cd"]));
			ControlUtil.SetControlValue(Burando_nm,
				DataFormatUtil.GetFormatItem(th020f02Form.Burando_nm,formInfo["Burando_nm"]));
			ControlUtil.SetControlValue(Jisya_hbn,
				DataFormatUtil.GetFormatItem(th020f02Form.Jisya_hbn,formInfo["Jisya_hbn"]));
			ControlUtil.SetControlValue(Maker_hbn,
				DataFormatUtil.GetFormatItem(th020f02Form.Maker_hbn,formInfo["Maker_hbn"]));
			ControlUtil.SetControlValue(Syohin_zokusei,
				DataFormatUtil.GetFormatItem(th020f02Form.Syohin_zokusei,formInfo["Syohin_zokusei"]));
			ControlUtil.SetControlValue(Syonmk,
				DataFormatUtil.GetFormatItem(th020f02Form.Syonmk,formInfo["Syonmk"]));
			ControlUtil.SetControlValue(Iro_nm,
				DataFormatUtil.GetFormatItem(th020f02Form.Iro_nm,formInfo["Iro_nm"]));
			ControlUtil.SetControlValue(Zentenzaiko_su,
				DataFormatUtil.GetFormatItem(th020f02Form.Zentenzaiko_su,formInfo["Zentenzaiko_su"]));
			ControlUtil.SetControlValue(Zentensyoka_rtu,
				DataFormatUtil.GetFormatItem(th020f02Form.Zentensyoka_rtu,formInfo["Zentensyoka_rtu"]));
			ControlUtil.SetControlValue(Tenpo_nm,
				DataFormatUtil.GetFormatItem(th020f02Form.Tenpo_nm,formInfo["Tenpo_nm"]));
			ControlUtil.SetControlValue(Tenpo_cd,
				DataFormatUtil.GetFormatItem(th020f02Form.Tenpo_cd,formInfo["Tenpo_cd"]));
			ControlUtil.SetControlValue(All_gokei_suryo,
				DataFormatUtil.GetFormatItem(th020f02Form.All_gokei_suryo,formInfo["All_gokei_suryo"]));
			ControlUtil.SetControlValue(Suryo1,
				DataFormatUtil.GetFormatItem(th020f02Form.Suryo1,formInfo["Suryo1"]));
			ControlUtil.SetControlValue(Suryo2,
				DataFormatUtil.GetFormatItem(th020f02Form.Suryo2,formInfo["Suryo2"]));
			ControlUtil.SetControlValue(Suryo3,
				DataFormatUtil.GetFormatItem(th020f02Form.Suryo3,formInfo["Suryo3"]));
			ControlUtil.SetControlValue(Suryo4,
				DataFormatUtil.GetFormatItem(th020f02Form.Suryo4,formInfo["Suryo4"]));
			ControlUtil.SetControlValue(Suryo5,
				DataFormatUtil.GetFormatItem(th020f02Form.Suryo5,formInfo["Suryo5"]));
			ControlUtil.SetControlValue(Suryo6,
				DataFormatUtil.GetFormatItem(th020f02Form.Suryo6,formInfo["Suryo6"]));
			ControlUtil.SetControlValue(Suryo7,
				DataFormatUtil.GetFormatItem(th020f02Form.Suryo7,formInfo["Suryo7"]));
			ControlUtil.SetControlValue(Suryo8,
				DataFormatUtil.GetFormatItem(th020f02Form.Suryo8,formInfo["Suryo8"]));
			ControlUtil.SetControlValue(Suryo9,
				DataFormatUtil.GetFormatItem(th020f02Form.Suryo9,formInfo["Suryo9"]));
			ControlUtil.SetControlValue(Suryo10,
				DataFormatUtil.GetFormatItem(th020f02Form.Suryo10,formInfo["Suryo10"]));
			ControlUtil.SetControlValue(Suryo11,
				DataFormatUtil.GetFormatItem(th020f02Form.Suryo11,formInfo["Suryo11"]));
			ControlUtil.SetControlValue(Suryo12,
				DataFormatUtil.GetFormatItem(th020f02Form.Suryo12,formInfo["Suryo12"]));
			ControlUtil.SetControlValue(Suryo13,
				DataFormatUtil.GetFormatItem(th020f02Form.Suryo13,formInfo["Suryo13"]));
			ControlUtil.SetControlValue(Suryo14,
				DataFormatUtil.GetFormatItem(th020f02Form.Suryo14,formInfo["Suryo14"]));
			ControlUtil.SetControlValue(Suryo15,
				DataFormatUtil.GetFormatItem(th020f02Form.Suryo15,formInfo["Suryo15"]));
			ControlUtil.SetControlValue(Suryo16,
				DataFormatUtil.GetFormatItem(th020f02Form.Suryo16,formInfo["Suryo16"]));
			ControlUtil.SetControlValue(Suryo17,
				DataFormatUtil.GetFormatItem(th020f02Form.Suryo17,formInfo["Suryo17"]));
			ControlUtil.SetControlValue(Suryo18,
				DataFormatUtil.GetFormatItem(th020f02Form.Suryo18,formInfo["Suryo18"]));
			ControlUtil.SetControlValue(Suryo19,
				DataFormatUtil.GetFormatItem(th020f02Form.Suryo19,formInfo["Suryo19"]));
			ControlUtil.SetControlValue(Suryo20,
				DataFormatUtil.GetFormatItem(th020f02Form.Suryo20,formInfo["Suryo20"]));
			ControlUtil.SetControlValue(Suryo21,
				DataFormatUtil.GetFormatItem(th020f02Form.Suryo21,formInfo["Suryo21"]));
			ControlUtil.SetControlValue(Suryo22,
				DataFormatUtil.GetFormatItem(th020f02Form.Suryo22,formInfo["Suryo22"]));
			ControlUtil.SetControlValue(Suryo23,
				DataFormatUtil.GetFormatItem(th020f02Form.Suryo23,formInfo["Suryo23"]));
			ControlUtil.SetControlValue(Suryo24,
				DataFormatUtil.GetFormatItem(th020f02Form.Suryo24,formInfo["Suryo24"]));
			ControlUtil.SetControlValue(Suryo25,
				DataFormatUtil.GetFormatItem(th020f02Form.Suryo25,formInfo["Suryo25"]));
			ControlUtil.SetControlValue(Suryo26,
				DataFormatUtil.GetFormatItem(th020f02Form.Suryo26,formInfo["Suryo26"]));
			ControlUtil.SetControlValue(Suryo27,
				DataFormatUtil.GetFormatItem(th020f02Form.Suryo27,formInfo["Suryo27"]));
			ControlUtil.SetControlValue(Suryo28,
				DataFormatUtil.GetFormatItem(th020f02Form.Suryo28,formInfo["Suryo28"]));
			ControlUtil.SetControlValue(Suryo29,
				DataFormatUtil.GetFormatItem(th020f02Form.Suryo29,formInfo["Suryo29"]));
			ControlUtil.SetControlValue(Suryo30,
				DataFormatUtil.GetFormatItem(th020f02Form.Suryo30,formInfo["Suryo30"]));

			if(!base.CheckUseSelfCustomize()){
				Btnback.Value = base.FormResourceGetString(formResource, "Btnback", lang);
				Btnarea.Value = base.FormResourceGetString(formResource, "Btnarea", lang);
				//Btnprev.Value = base.FormResourceGetString(formResource, "Btnprev", lang);
				//Btnnext.Value = base.FormResourceGetString(formResource, "Btnnext", lang);
				Btnprev.Value = "<< 前へ";
				Btnnext.Value = "次へ >>";
				Meisaihead_iro_nm1.Value = base.FormResourceGetString(formResource, "Meisaihead_iro_nm1", lang);
				Meisaihead_iro_nm2.Value = base.FormResourceGetString(formResource, "Meisaihead_iro_nm2", lang);
				Meisaihead_iro_nm3.Value = base.FormResourceGetString(formResource, "Meisaihead_iro_nm3", lang);
				Meisaihead_iro_nm4.Value = base.FormResourceGetString(formResource, "Meisaihead_iro_nm4", lang);
				Meisaihead_iro_nm5.Value = base.FormResourceGetString(formResource, "Meisaihead_iro_nm5", lang);
				Meisaihead_iro_nm6.Value = base.FormResourceGetString(formResource, "Meisaihead_iro_nm6", lang);
				Meisaihead_iro_nm7.Value = base.FormResourceGetString(formResource, "Meisaihead_iro_nm7", lang);
				Meisaihead_iro_nm8.Value = base.FormResourceGetString(formResource, "Meisaihead_iro_nm8", lang);
				Meisaihead_iro_nm9.Value = base.FormResourceGetString(formResource, "Meisaihead_iro_nm9", lang);
				Meisaihead_iro_nm10.Value = base.FormResourceGetString(formResource, "Meisaihead_iro_nm10", lang);
				Meisaihead_iro_nm11.Value = base.FormResourceGetString(formResource, "Meisaihead_iro_nm11", lang);
				Meisaihead_iro_nm12.Value = base.FormResourceGetString(formResource, "Meisaihead_iro_nm12", lang);
				Meisaihead_iro_nm13.Value = base.FormResourceGetString(formResource, "Meisaihead_iro_nm13", lang);
				Meisaihead_iro_nm14.Value = base.FormResourceGetString(formResource, "Meisaihead_iro_nm14", lang);
				Meisaihead_iro_nm15.Value = base.FormResourceGetString(formResource, "Meisaihead_iro_nm15", lang);
				Meisaihead_iro_nm16.Value = base.FormResourceGetString(formResource, "Meisaihead_iro_nm16", lang);
				Meisaihead_iro_nm17.Value = base.FormResourceGetString(formResource, "Meisaihead_iro_nm17", lang);
				Meisaihead_iro_nm18.Value = base.FormResourceGetString(formResource, "Meisaihead_iro_nm18", lang);
				Meisaihead_iro_nm19.Value = base.FormResourceGetString(formResource, "Meisaihead_iro_nm19", lang);
				Meisaihead_iro_nm20.Value = base.FormResourceGetString(formResource, "Meisaihead_iro_nm20", lang);
				Meisaihead_iro_nm21.Value = base.FormResourceGetString(formResource, "Meisaihead_iro_nm21", lang);
				Meisaihead_iro_nm22.Value = base.FormResourceGetString(formResource, "Meisaihead_iro_nm22", lang);
				Meisaihead_iro_nm23.Value = base.FormResourceGetString(formResource, "Meisaihead_iro_nm23", lang);
				Meisaihead_iro_nm24.Value = base.FormResourceGetString(formResource, "Meisaihead_iro_nm24", lang);
				Meisaihead_iro_nm25.Value = base.FormResourceGetString(formResource, "Meisaihead_iro_nm25", lang);
				Meisaihead_iro_nm26.Value = base.FormResourceGetString(formResource, "Meisaihead_iro_nm26", lang);
				Meisaihead_iro_nm27.Value = base.FormResourceGetString(formResource, "Meisaihead_iro_nm27", lang);
				Meisaihead_iro_nm28.Value = base.FormResourceGetString(formResource, "Meisaihead_iro_nm28", lang);
				Meisaihead_iro_nm29.Value = base.FormResourceGetString(formResource, "Meisaihead_iro_nm29", lang);
				Meisaihead_iro_nm30.Value = base.FormResourceGetString(formResource, "Meisaihead_iro_nm30", lang);
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
			// UIScreenController controller = new UIScreenController((Th020f02Form)base.GetPageContext().GetFormVO());
			// controller.ChangeColumnsDisplayMode(M1 ,  new DetailHeaderFixedVO(M1Header , true) , null);

			/*
			 *登録した機能間連携処理を親画面に感知させる。
			 *機能有効させる場合は、コメントアウトを外してください。
			 */
			//DetailUtil.RunPgSyn(this,(StandardBaseForm)base.GetPageContext().GetFormVO());

			Th020f02Form formVo = (Th020f02Form)base.GetPageContext().GetFormVO();

			IDataList M1List = formVo.GetList("M1");

			// 明細標題ハッシュテーブル取得
			Hashtable HeadRec = (Hashtable) formVo.Dictionary[Th020p01Constant.DIC_M1HEAD_HASH];

			if (HeadRec != null)
			{
				// 明細標題定義
				hyodaiEdit(HeadRec, "JAN_CD01", "SIZE_NM01", Meisaihead_iro_nm1);
				hyodaiEdit(HeadRec, "JAN_CD02", "SIZE_NM02", Meisaihead_iro_nm2);
				hyodaiEdit(HeadRec, "JAN_CD03", "SIZE_NM03", Meisaihead_iro_nm3);
				hyodaiEdit(HeadRec, "JAN_CD04", "SIZE_NM04", Meisaihead_iro_nm4);
				hyodaiEdit(HeadRec, "JAN_CD05", "SIZE_NM05", Meisaihead_iro_nm5);
				hyodaiEdit(HeadRec, "JAN_CD06", "SIZE_NM06", Meisaihead_iro_nm6);
				hyodaiEdit(HeadRec, "JAN_CD07", "SIZE_NM07", Meisaihead_iro_nm7);
				hyodaiEdit(HeadRec, "JAN_CD08", "SIZE_NM08", Meisaihead_iro_nm8);
				hyodaiEdit(HeadRec, "JAN_CD09", "SIZE_NM09", Meisaihead_iro_nm9);
				hyodaiEdit(HeadRec, "JAN_CD10", "SIZE_NM10", Meisaihead_iro_nm10);
				hyodaiEdit(HeadRec, "JAN_CD11", "SIZE_NM11", Meisaihead_iro_nm11);
				hyodaiEdit(HeadRec, "JAN_CD12", "SIZE_NM12", Meisaihead_iro_nm12);
				hyodaiEdit(HeadRec, "JAN_CD13", "SIZE_NM13", Meisaihead_iro_nm13);
				hyodaiEdit(HeadRec, "JAN_CD14", "SIZE_NM14", Meisaihead_iro_nm14);
				hyodaiEdit(HeadRec, "JAN_CD15", "SIZE_NM15", Meisaihead_iro_nm15);
				hyodaiEdit(HeadRec, "JAN_CD16", "SIZE_NM16", Meisaihead_iro_nm16);
				hyodaiEdit(HeadRec, "JAN_CD17", "SIZE_NM17", Meisaihead_iro_nm17);
				hyodaiEdit(HeadRec, "JAN_CD18", "SIZE_NM18", Meisaihead_iro_nm18);
				hyodaiEdit(HeadRec, "JAN_CD19", "SIZE_NM19", Meisaihead_iro_nm19);
				hyodaiEdit(HeadRec, "JAN_CD20", "SIZE_NM20", Meisaihead_iro_nm20);
				hyodaiEdit(HeadRec, "JAN_CD21", "SIZE_NM21", Meisaihead_iro_nm21);
				hyodaiEdit(HeadRec, "JAN_CD22", "SIZE_NM22", Meisaihead_iro_nm22);
				hyodaiEdit(HeadRec, "JAN_CD23", "SIZE_NM23", Meisaihead_iro_nm23);
				hyodaiEdit(HeadRec, "JAN_CD24", "SIZE_NM24", Meisaihead_iro_nm24);
				hyodaiEdit(HeadRec, "JAN_CD25", "SIZE_NM25", Meisaihead_iro_nm25);
				hyodaiEdit(HeadRec, "JAN_CD26", "SIZE_NM26", Meisaihead_iro_nm26);
				hyodaiEdit(HeadRec, "JAN_CD27", "SIZE_NM27", Meisaihead_iro_nm27);
				hyodaiEdit(HeadRec, "JAN_CD28", "SIZE_NM28", Meisaihead_iro_nm28);
				hyodaiEdit(HeadRec, "JAN_CD29", "SIZE_NM29", Meisaihead_iro_nm29);
				hyodaiEdit(HeadRec, "JAN_CD30", "SIZE_NM30", Meisaihead_iro_nm30);
				
			}

			// 初期表示時
			if (base.GetPageContext().CommandInfo.ActionMode.Equals("INI"))
			{
				// 明細標題16がNULLの場合、次へ、前へボタンを非表示にする
				if (string.IsNullOrEmpty(Meisaihead_iro_nm16.Value))
				{
					ControlCls.Visible(Btnprev, false);
					ControlCls.Visible(Btnnext, false);

				}
				else
				{
					// 16以上ある場合、前へボタンを非表示にする
					ControlCls.Visible(Btnprev, false);
				}
			}
			else
			{
				// 次へボタンクリック
				if (base.GetPageContext().CommandInfo.ActionMode.Equals(Th020p01Constant.ACTION_NEXT))
				{
					// 次へボタンを非表示にする
					ControlCls.Visible(Btnnext, false);
				} 
				// 前へボタンクリック
				else if (base.GetPageContext().CommandInfo.ActionMode.Equals(Th020p01Constant.ACTION_PREV))
				{
					// 前へボタンを非表示にする
					ControlCls.Visible(Btnprev, false);
				}
			}

			// 明細表示制御
			ditailChange();

			if (HeadRec != null)
			{
				// 文字色を変更する
				colorChange("M1suryo1", HeadRec["JAN_CD01"].ToString(), HeadRec["SYOHIN_CD01"].ToString());
				colorChange("M1suryo2", HeadRec["JAN_CD02"].ToString(), HeadRec["SYOHIN_CD02"].ToString());
				colorChange("M1suryo3", HeadRec["JAN_CD03"].ToString(), HeadRec["SYOHIN_CD03"].ToString());
				colorChange("M1suryo4", HeadRec["JAN_CD04"].ToString(), HeadRec["SYOHIN_CD04"].ToString());
				colorChange("M1suryo5", HeadRec["JAN_CD05"].ToString(), HeadRec["SYOHIN_CD05"].ToString());
				colorChange("M1suryo6", HeadRec["JAN_CD06"].ToString(), HeadRec["SYOHIN_CD06"].ToString());
				colorChange("M1suryo7", HeadRec["JAN_CD07"].ToString(), HeadRec["SYOHIN_CD07"].ToString());
				colorChange("M1suryo8", HeadRec["JAN_CD08"].ToString(), HeadRec["SYOHIN_CD08"].ToString());
				colorChange("M1suryo9", HeadRec["JAN_CD09"].ToString(), HeadRec["SYOHIN_CD09"].ToString());
				colorChange("M1suryo10", HeadRec["JAN_CD10"].ToString(), HeadRec["SYOHIN_CD10"].ToString());
				colorChange("M1suryo11", HeadRec["JAN_CD11"].ToString(), HeadRec["SYOHIN_CD11"].ToString());
				colorChange("M1suryo12", HeadRec["JAN_CD12"].ToString(), HeadRec["SYOHIN_CD12"].ToString());
				colorChange("M1suryo13", HeadRec["JAN_CD13"].ToString(), HeadRec["SYOHIN_CD13"].ToString());
				colorChange("M1suryo14", HeadRec["JAN_CD14"].ToString(), HeadRec["SYOHIN_CD14"].ToString());
				colorChange("M1suryo15", HeadRec["JAN_CD15"].ToString(), HeadRec["SYOHIN_CD15"].ToString());
				colorChange("M1suryo16", HeadRec["JAN_CD16"].ToString(), HeadRec["SYOHIN_CD16"].ToString());
				colorChange("M1suryo17", HeadRec["JAN_CD17"].ToString(), HeadRec["SYOHIN_CD17"].ToString());
				colorChange("M1suryo18", HeadRec["JAN_CD18"].ToString(), HeadRec["SYOHIN_CD18"].ToString());
				colorChange("M1suryo19", HeadRec["JAN_CD19"].ToString(), HeadRec["SYOHIN_CD19"].ToString());
				colorChange("M1suryo20", HeadRec["JAN_CD20"].ToString(), HeadRec["SYOHIN_CD20"].ToString());
				colorChange("M1suryo21", HeadRec["JAN_CD21"].ToString(), HeadRec["SYOHIN_CD21"].ToString());
				colorChange("M1suryo22", HeadRec["JAN_CD22"].ToString(), HeadRec["SYOHIN_CD22"].ToString());
				colorChange("M1suryo23", HeadRec["JAN_CD23"].ToString(), HeadRec["SYOHIN_CD23"].ToString());
				colorChange("M1suryo24", HeadRec["JAN_CD24"].ToString(), HeadRec["SYOHIN_CD24"].ToString());
				colorChange("M1suryo25", HeadRec["JAN_CD25"].ToString(), HeadRec["SYOHIN_CD25"].ToString());
				colorChange("M1suryo26", HeadRec["JAN_CD26"].ToString(), HeadRec["SYOHIN_CD26"].ToString());
				colorChange("M1suryo27", HeadRec["JAN_CD27"].ToString(), HeadRec["SYOHIN_CD27"].ToString());
				colorChange("M1suryo28", HeadRec["JAN_CD28"].ToString(), HeadRec["SYOHIN_CD28"].ToString());
				colorChange("M1suryo29", HeadRec["JAN_CD29"].ToString(), HeadRec["SYOHIN_CD29"].ToString());
				colorChange("M1suryo30", HeadRec["JAN_CD30"].ToString(), HeadRec["SYOHIN_CD30"].ToString());
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
			ControlUtil.SetControlValue(Kaisya_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Kaisya_cd", lang), base.GetPageContext().FormInfo["Kaisya_cd"]));
				DataFormatUtil.SetMustColorCaption(Kaisya_cd_lbl, base.GetPageContext().FormInfo["Kaisya_cd"]);
			ControlUtil.SetControlValue(Kaisya_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Kaisya_nm", lang), base.GetPageContext().FormInfo["Kaisya_nm"]));
				DataFormatUtil.SetMustColorCaption(Kaisya_nm_lbl, base.GetPageContext().FormInfo["Kaisya_nm"]);
			ControlUtil.SetControlValue(Bumon_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Bumon_cd", lang), base.GetPageContext().FormInfo["Bumon_cd"]));
				DataFormatUtil.SetMustColorCaption(Bumon_cd_lbl, base.GetPageContext().FormInfo["Bumon_cd"]);
			ControlUtil.SetControlValue(Bumon_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Bumon_nm", lang), base.GetPageContext().FormInfo["Bumon_nm"]));
				DataFormatUtil.SetMustColorCaption(Bumon_nm_lbl, base.GetPageContext().FormInfo["Bumon_nm"]);
			ControlUtil.SetControlValue(Hinsyu_ryaku_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Hinsyu_ryaku_nm", lang), base.GetPageContext().FormInfo["Hinsyu_ryaku_nm"]));
				DataFormatUtil.SetMustColorCaption(Hinsyu_ryaku_nm_lbl, base.GetPageContext().FormInfo["Hinsyu_ryaku_nm"]);
			ControlUtil.SetControlValue(Burando_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Burando_cd", lang), base.GetPageContext().FormInfo["Burando_cd"]));
				DataFormatUtil.SetMustColorCaption(Burando_cd_lbl, base.GetPageContext().FormInfo["Burando_cd"]);
			ControlUtil.SetControlValue(Burando_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Burando_nm", lang), base.GetPageContext().FormInfo["Burando_nm"]));
				DataFormatUtil.SetMustColorCaption(Burando_nm_lbl, base.GetPageContext().FormInfo["Burando_nm"]);
			ControlUtil.SetControlValue(Jisya_hbn_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Jisya_hbn", lang), base.GetPageContext().FormInfo["Jisya_hbn"]));
				DataFormatUtil.SetMustColorCaption(Jisya_hbn_lbl, base.GetPageContext().FormInfo["Jisya_hbn"]);
			ControlUtil.SetControlValue(Maker_hbn_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Maker_hbn", lang), base.GetPageContext().FormInfo["Maker_hbn"]));
				DataFormatUtil.SetMustColorCaption(Maker_hbn_lbl, base.GetPageContext().FormInfo["Maker_hbn"]);
			ControlUtil.SetControlValue(Syohin_zokusei_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Syohin_zokusei", lang), base.GetPageContext().FormInfo["Syohin_zokusei"]));
				DataFormatUtil.SetMustColorCaption(Syohin_zokusei_lbl, base.GetPageContext().FormInfo["Syohin_zokusei"]);
			ControlUtil.SetControlValue(Syonmk_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Syonmk", lang), base.GetPageContext().FormInfo["Syonmk"]));
				DataFormatUtil.SetMustColorCaption(Syonmk_lbl, base.GetPageContext().FormInfo["Syonmk"]);
			ControlUtil.SetControlValue(Iro_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Iro_nm", lang), base.GetPageContext().FormInfo["Iro_nm"]));
				DataFormatUtil.SetMustColorCaption(Iro_nm_lbl, base.GetPageContext().FormInfo["Iro_nm"]);
			ControlUtil.SetControlValue(Zentenzaiko_su_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Zentenzaiko_su", lang), base.GetPageContext().FormInfo["Zentenzaiko_su"]));
				DataFormatUtil.SetMustColorCaption(Zentenzaiko_su_lbl, base.GetPageContext().FormInfo["Zentenzaiko_su"]);
			ControlUtil.SetControlValue(Zentensyoka_rtu_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Zentensyoka_rtu", lang), base.GetPageContext().FormInfo["Zentensyoka_rtu"]));
				DataFormatUtil.SetMustColorCaption(Zentensyoka_rtu_lbl, base.GetPageContext().FormInfo["Zentensyoka_rtu"]);
			ControlUtil.SetControlValue(Tenpo_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Tenpo_nm", lang), base.GetPageContext().FormInfo["Tenpo_nm"]));
				DataFormatUtil.SetMustColorCaption(Tenpo_nm_lbl, base.GetPageContext().FormInfo["Tenpo_nm"]);
			ControlUtil.SetControlValue(All_gokei_suryo_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("All_gokei_suryo", lang), base.GetPageContext().FormInfo["All_gokei_suryo"]));
				DataFormatUtil.SetMustColorCaption(All_gokei_suryo_lbl, base.GetPageContext().FormInfo["All_gokei_suryo"]);
			ControlUtil.SetControlValue(Suryo1_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Suryo1", lang), base.GetPageContext().FormInfo["Suryo1"]));
				DataFormatUtil.SetMustColorCaption(Suryo1_lbl, base.GetPageContext().FormInfo["Suryo1"]);
			ControlUtil.SetControlValue(Suryo2_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Suryo2", lang), base.GetPageContext().FormInfo["Suryo2"]));
				DataFormatUtil.SetMustColorCaption(Suryo2_lbl, base.GetPageContext().FormInfo["Suryo2"]);
			ControlUtil.SetControlValue(Suryo3_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Suryo3", lang), base.GetPageContext().FormInfo["Suryo3"]));
				DataFormatUtil.SetMustColorCaption(Suryo3_lbl, base.GetPageContext().FormInfo["Suryo3"]);
			ControlUtil.SetControlValue(Suryo4_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Suryo4", lang), base.GetPageContext().FormInfo["Suryo4"]));
				DataFormatUtil.SetMustColorCaption(Suryo4_lbl, base.GetPageContext().FormInfo["Suryo4"]);
			ControlUtil.SetControlValue(Suryo5_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Suryo5", lang), base.GetPageContext().FormInfo["Suryo5"]));
				DataFormatUtil.SetMustColorCaption(Suryo5_lbl, base.GetPageContext().FormInfo["Suryo5"]);
			ControlUtil.SetControlValue(Suryo6_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Suryo6", lang), base.GetPageContext().FormInfo["Suryo6"]));
				DataFormatUtil.SetMustColorCaption(Suryo6_lbl, base.GetPageContext().FormInfo["Suryo6"]);
			ControlUtil.SetControlValue(Suryo7_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Suryo7", lang), base.GetPageContext().FormInfo["Suryo7"]));
				DataFormatUtil.SetMustColorCaption(Suryo7_lbl, base.GetPageContext().FormInfo["Suryo7"]);
			ControlUtil.SetControlValue(Suryo8_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Suryo8", lang), base.GetPageContext().FormInfo["Suryo8"]));
				DataFormatUtil.SetMustColorCaption(Suryo8_lbl, base.GetPageContext().FormInfo["Suryo8"]);
			ControlUtil.SetControlValue(Suryo9_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Suryo9", lang), base.GetPageContext().FormInfo["Suryo9"]));
				DataFormatUtil.SetMustColorCaption(Suryo9_lbl, base.GetPageContext().FormInfo["Suryo9"]);
			ControlUtil.SetControlValue(Suryo10_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Suryo10", lang), base.GetPageContext().FormInfo["Suryo10"]));
				DataFormatUtil.SetMustColorCaption(Suryo10_lbl, base.GetPageContext().FormInfo["Suryo10"]);
			ControlUtil.SetControlValue(Suryo11_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Suryo11", lang), base.GetPageContext().FormInfo["Suryo11"]));
				DataFormatUtil.SetMustColorCaption(Suryo11_lbl, base.GetPageContext().FormInfo["Suryo11"]);
			ControlUtil.SetControlValue(Suryo12_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Suryo12", lang), base.GetPageContext().FormInfo["Suryo12"]));
				DataFormatUtil.SetMustColorCaption(Suryo12_lbl, base.GetPageContext().FormInfo["Suryo12"]);
			ControlUtil.SetControlValue(Suryo13_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Suryo13", lang), base.GetPageContext().FormInfo["Suryo13"]));
				DataFormatUtil.SetMustColorCaption(Suryo13_lbl, base.GetPageContext().FormInfo["Suryo13"]);
			ControlUtil.SetControlValue(Suryo14_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Suryo14", lang), base.GetPageContext().FormInfo["Suryo14"]));
				DataFormatUtil.SetMustColorCaption(Suryo14_lbl, base.GetPageContext().FormInfo["Suryo14"]);
			ControlUtil.SetControlValue(Suryo15_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Suryo15", lang), base.GetPageContext().FormInfo["Suryo15"]));
				DataFormatUtil.SetMustColorCaption(Suryo15_lbl, base.GetPageContext().FormInfo["Suryo15"]);
			ControlUtil.SetControlValue(Suryo16_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Suryo16", lang), base.GetPageContext().FormInfo["Suryo16"]));
				DataFormatUtil.SetMustColorCaption(Suryo16_lbl, base.GetPageContext().FormInfo["Suryo16"]);
			ControlUtil.SetControlValue(Suryo17_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Suryo17", lang), base.GetPageContext().FormInfo["Suryo17"]));
				DataFormatUtil.SetMustColorCaption(Suryo17_lbl, base.GetPageContext().FormInfo["Suryo17"]);
			ControlUtil.SetControlValue(Suryo18_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Suryo18", lang), base.GetPageContext().FormInfo["Suryo18"]));
				DataFormatUtil.SetMustColorCaption(Suryo18_lbl, base.GetPageContext().FormInfo["Suryo18"]);
			ControlUtil.SetControlValue(Suryo19_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Suryo19", lang), base.GetPageContext().FormInfo["Suryo19"]));
				DataFormatUtil.SetMustColorCaption(Suryo19_lbl, base.GetPageContext().FormInfo["Suryo19"]);
			ControlUtil.SetControlValue(Suryo20_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Suryo20", lang), base.GetPageContext().FormInfo["Suryo20"]));
				DataFormatUtil.SetMustColorCaption(Suryo20_lbl, base.GetPageContext().FormInfo["Suryo20"]);
			ControlUtil.SetControlValue(Suryo21_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Suryo21", lang), base.GetPageContext().FormInfo["Suryo21"]));
				DataFormatUtil.SetMustColorCaption(Suryo21_lbl, base.GetPageContext().FormInfo["Suryo21"]);
			ControlUtil.SetControlValue(Suryo22_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Suryo22", lang), base.GetPageContext().FormInfo["Suryo22"]));
				DataFormatUtil.SetMustColorCaption(Suryo22_lbl, base.GetPageContext().FormInfo["Suryo22"]);
			ControlUtil.SetControlValue(Suryo23_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Suryo23", lang), base.GetPageContext().FormInfo["Suryo23"]));
				DataFormatUtil.SetMustColorCaption(Suryo23_lbl, base.GetPageContext().FormInfo["Suryo23"]);
			ControlUtil.SetControlValue(Suryo24_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Suryo24", lang), base.GetPageContext().FormInfo["Suryo24"]));
				DataFormatUtil.SetMustColorCaption(Suryo24_lbl, base.GetPageContext().FormInfo["Suryo24"]);
			ControlUtil.SetControlValue(Suryo25_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Suryo25", lang), base.GetPageContext().FormInfo["Suryo25"]));
				DataFormatUtil.SetMustColorCaption(Suryo25_lbl, base.GetPageContext().FormInfo["Suryo25"]);
			ControlUtil.SetControlValue(Suryo26_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Suryo26", lang), base.GetPageContext().FormInfo["Suryo26"]));
				DataFormatUtil.SetMustColorCaption(Suryo26_lbl, base.GetPageContext().FormInfo["Suryo26"]);
			ControlUtil.SetControlValue(Suryo27_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Suryo27", lang), base.GetPageContext().FormInfo["Suryo27"]));
				DataFormatUtil.SetMustColorCaption(Suryo27_lbl, base.GetPageContext().FormInfo["Suryo27"]);
			ControlUtil.SetControlValue(Suryo28_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Suryo28", lang), base.GetPageContext().FormInfo["Suryo28"]));
				DataFormatUtil.SetMustColorCaption(Suryo28_lbl, base.GetPageContext().FormInfo["Suryo28"]);
			ControlUtil.SetControlValue(Suryo29_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Suryo29", lang), base.GetPageContext().FormInfo["Suryo29"]));
				DataFormatUtil.SetMustColorCaption(Suryo29_lbl, base.GetPageContext().FormInfo["Suryo29"]);
			ControlUtil.SetControlValue(Suryo30_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Suryo30", lang), base.GetPageContext().FormInfo["Suryo30"]));
				DataFormatUtil.SetMustColorCaption(Suryo30_lbl, base.GetPageContext().FormInfo["Suryo30"]);
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
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1gokei_suryo", lang), base.GetPageContext().FormInfo["M1gokei_suryo"]);
				// M1.Columns[4].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syoka_rtu", lang), base.GetPageContext().FormInfo["M1syoka_rtu"]);
				// M1.Columns[5].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo1", lang), base.GetPageContext().FormInfo["M1suryo1"]);
				// M1.Columns[6].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo2", lang), base.GetPageContext().FormInfo["M1suryo2"]);
				// M1.Columns[7].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo3", lang), base.GetPageContext().FormInfo["M1suryo3"]);
				// M1.Columns[8].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo4", lang), base.GetPageContext().FormInfo["M1suryo4"]);
				// M1.Columns[9].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo5", lang), base.GetPageContext().FormInfo["M1suryo5"]);
				// M1.Columns[10].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo6", lang), base.GetPageContext().FormInfo["M1suryo6"]);
				// M1.Columns[11].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo7", lang), base.GetPageContext().FormInfo["M1suryo7"]);
				// M1.Columns[12].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo8", lang), base.GetPageContext().FormInfo["M1suryo8"]);
				// M1.Columns[13].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo9", lang), base.GetPageContext().FormInfo["M1suryo9"]);
				// M1.Columns[14].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo10", lang), base.GetPageContext().FormInfo["M1suryo10"]);
				// M1.Columns[15].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo11", lang), base.GetPageContext().FormInfo["M1suryo11"]);
				// M1.Columns[16].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo12", lang), base.GetPageContext().FormInfo["M1suryo12"]);
				// M1.Columns[17].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo13", lang), base.GetPageContext().FormInfo["M1suryo13"]);
				// M1.Columns[18].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo14", lang), base.GetPageContext().FormInfo["M1suryo14"]);
				// M1.Columns[19].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo15", lang), base.GetPageContext().FormInfo["M1suryo15"]);
				// M1.Columns[20].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo16", lang), base.GetPageContext().FormInfo["M1suryo16"]);
				// M1.Columns[21].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo17", lang), base.GetPageContext().FormInfo["M1suryo17"]);
				// M1.Columns[22].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo18", lang), base.GetPageContext().FormInfo["M1suryo18"]);
				// M1.Columns[23].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo19", lang), base.GetPageContext().FormInfo["M1suryo19"]);
				// M1.Columns[24].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo20", lang), base.GetPageContext().FormInfo["M1suryo20"]);
				// M1.Columns[25].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo21", lang), base.GetPageContext().FormInfo["M1suryo21"]);
				// M1.Columns[26].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo22", lang), base.GetPageContext().FormInfo["M1suryo22"]);
				// M1.Columns[27].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo23", lang), base.GetPageContext().FormInfo["M1suryo23"]);
				// M1.Columns[28].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo24", lang), base.GetPageContext().FormInfo["M1suryo24"]);
				// M1.Columns[29].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo25", lang), base.GetPageContext().FormInfo["M1suryo25"]);
				// M1.Columns[30].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo26", lang), base.GetPageContext().FormInfo["M1suryo26"]);
				// M1.Columns[31].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo27", lang), base.GetPageContext().FormInfo["M1suryo27"]);
				// M1.Columns[32].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo28", lang), base.GetPageContext().FormInfo["M1suryo28"]);
				// M1.Columns[33].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo29", lang), base.GetPageContext().FormInfo["M1suryo29"]);
				// M1.Columns[34].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo30", lang), base.GetPageContext().FormInfo["M1suryo30"]);
				// M1.Columns[35].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1selectorcheckbox", lang), base.GetPageContext().FormInfo["M1selectorcheckbox"]);
				// M1.Columns[36].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1entersyoriflg", lang), base.GetPageContext().FormInfo["M1entersyoriflg"]);
				// M1.Columns[37].HeaderText = 
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
				Windowtitle.InnerText = formResource.GetString("Th020f02_Titlebar", lang);
				header.FormName = formResource.GetString("Th020f02_FormCaption", lang);
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

		#region ユーザー定義関数

		#region 数量文字色変更

		/// <summary>
		/// 数量文字色変更
		/// </summary>
		/// <param name="String">suryoId</param>
		/// <param name="String">jan_cd</param>
		/// <param name="String">syohin_cd</param>
		private void colorChange(String suryoId, String jan_cd, String syohin_cd)
		{

			Th020f02Form formVo = (Th020f02Form)base.GetPageContext().GetFormVO();
			IDataList M1List = formVo.GetList("M1");

			// 検査用スキャンコード
			decimal dScan_Cd_from;
			decimal dScan_Cd_to;

			bool bScancdFlg = false;

			// スキャンコードがnullの場合、0を設定
			if (string.IsNullOrEmpty(formVo.Dictionary[Th020p01Constant.DIC_SCAN_CD_FROM].ToString())
				&& string.IsNullOrEmpty(formVo.Dictionary[Th020p01Constant.DIC_SCAN_CD_TO].ToString()))
			{
				dScan_Cd_from = 0;
				dScan_Cd_to = 0;
			}
			else
			{
				dScan_Cd_from = Convert.ToDecimal((BoSystemString.Nvl(formVo.Dictionary[Th020p01Constant.DIC_SCAN_CD_FROM].ToString(), "0")));
				dScan_Cd_to = Convert.ToDecimal((BoSystemString.Nvl(formVo.Dictionary[Th020p01Constant.DIC_SCAN_CD_TO].ToString(), "9999999999999")));
			}

			// JANコードか商品コードが範囲内の場合、文字色変更処理を行う
			if (Convert.ToDecimal((BoSystemString.Nvl(jan_cd, "-1"))) >= dScan_Cd_from
				&& Convert.ToDecimal((BoSystemString.Nvl(jan_cd, "-1"))) <= dScan_Cd_to)
			{
				bScancdFlg = true;
			}

			if (Convert.ToDecimal((BoSystemString.Nvl(BoSystemString.ZeroToEmpty(syohin_cd), "-1"))) >= dScan_Cd_from
				&& Convert.ToDecimal((BoSystemString.Nvl(BoSystemString.ZeroToEmpty(syohin_cd), "-1"))) <= dScan_Cd_to)
			{
				bScancdFlg = true;
			}

				if (M1List.Count > 0)
				{
					for (int i = 0; i < M1List.Count; i++)
					{
						// 数量が0だった場合、灰色にする
						if (((TextBox)M1.Items[i].FindControl(suryoId)).Text.Equals("0"))
						{
							((TextBox)M1.Items[i].FindControl(suryoId)).ForeColor = Color.DarkGray;
						}

						// 検索条件のスキャンコードの場合、赤色にする
						if (bScancdFlg)
						{
							((TextBox)M1.Items[i].FindControl(suryoId)).ForeColor = Color.Red;
						}
					}
				}

			return;
		}

		#endregion

		#region 明細表示制御

		/// <summary>
		/// 明細表示制御
		/// </summary>
		private void ditailChange()
		{
			Th020f02Form formVo = (Th020f02Form)base.GetPageContext().GetFormVO();

			IDataList M1List = formVo.GetList("M1");

			// 1～15表示フラグ
			bool bPrevDisp = false;
			// 16～30表示フラグ
			bool bNextDisp = false;

			// 初期表示の場合
			if(base.GetPageContext().CommandInfo.ActionMode.Equals("INI"))
			{
				// 1～15を表示し、16～30を非表示にする
				bPrevDisp = true;
				bNextDisp = false;

			}
			// 次へボタンクリックの場合
			else if (base.GetPageContext().CommandInfo.ActionMode.Equals(Th020p01Constant.ACTION_NEXT))
			{
				// 1～15を非表示にし、16～30を表示にする
				bPrevDisp = false;
				bNextDisp = true;
			}
			// 前へボタンクリックの場合
			else if (base.GetPageContext().CommandInfo.ActionMode.Equals(Th020p01Constant.ACTION_PREV))
			{
				// 1～15を表示にし、16～30を非表示にする
				bPrevDisp = true;
				bNextDisp = false;
			}

			// 明細標題表示制御
			ControlCls.Visible(Meisaihead_iro_nm1, bPrevDisp);
			ControlCls.Visible(Meisaihead_iro_nm2, bPrevDisp);
			ControlCls.Visible(Meisaihead_iro_nm3, bPrevDisp);
			ControlCls.Visible(Meisaihead_iro_nm4, bPrevDisp);
			ControlCls.Visible(Meisaihead_iro_nm5, bPrevDisp);
			ControlCls.Visible(Meisaihead_iro_nm6, bPrevDisp);
			ControlCls.Visible(Meisaihead_iro_nm7, bPrevDisp);
			ControlCls.Visible(Meisaihead_iro_nm8, bPrevDisp);
			ControlCls.Visible(Meisaihead_iro_nm9, bPrevDisp);
			ControlCls.Visible(Meisaihead_iro_nm10, bPrevDisp);
			ControlCls.Visible(Meisaihead_iro_nm11, bPrevDisp);
			ControlCls.Visible(Meisaihead_iro_nm12, bPrevDisp);
			ControlCls.Visible(Meisaihead_iro_nm13, bPrevDisp);
			ControlCls.Visible(Meisaihead_iro_nm14, bPrevDisp);
			ControlCls.Visible(Meisaihead_iro_nm15, bPrevDisp);
			ControlCls.Visible(Meisaihead_iro_nm16, bNextDisp);
			ControlCls.Visible(Meisaihead_iro_nm17, bNextDisp);
			ControlCls.Visible(Meisaihead_iro_nm18, bNextDisp);
			ControlCls.Visible(Meisaihead_iro_nm19, bNextDisp);
			ControlCls.Visible(Meisaihead_iro_nm20, bNextDisp);
			ControlCls.Visible(Meisaihead_iro_nm21, bNextDisp);
			ControlCls.Visible(Meisaihead_iro_nm22, bNextDisp);
			ControlCls.Visible(Meisaihead_iro_nm23, bNextDisp);
			ControlCls.Visible(Meisaihead_iro_nm24, bNextDisp);
			ControlCls.Visible(Meisaihead_iro_nm25, bNextDisp);
			ControlCls.Visible(Meisaihead_iro_nm26, bNextDisp);
			ControlCls.Visible(Meisaihead_iro_nm27, bNextDisp);
			ControlCls.Visible(Meisaihead_iro_nm28, bNextDisp);
			ControlCls.Visible(Meisaihead_iro_nm29, bNextDisp);
			ControlCls.Visible(Meisaihead_iro_nm30, bNextDisp);

			// フッター数量表示制御
			ControlCls.Visible(Suryo1, bPrevDisp);
			ControlCls.Visible(Suryo2, bPrevDisp);
			ControlCls.Visible(Suryo3, bPrevDisp);
			ControlCls.Visible(Suryo4, bPrevDisp);
			ControlCls.Visible(Suryo5, bPrevDisp);
			ControlCls.Visible(Suryo6, bPrevDisp);
			ControlCls.Visible(Suryo7, bPrevDisp);
			ControlCls.Visible(Suryo8, bPrevDisp);
			ControlCls.Visible(Suryo9, bPrevDisp);
			ControlCls.Visible(Suryo10, bPrevDisp);
			ControlCls.Visible(Suryo11, bPrevDisp);
			ControlCls.Visible(Suryo12, bPrevDisp);
			ControlCls.Visible(Suryo13, bPrevDisp);
			ControlCls.Visible(Suryo14, bPrevDisp);
			ControlCls.Visible(Suryo15, bPrevDisp);
			ControlCls.Visible(Suryo16, bNextDisp);
			ControlCls.Visible(Suryo17, bNextDisp);
			ControlCls.Visible(Suryo18, bNextDisp);
			ControlCls.Visible(Suryo19, bNextDisp);
			ControlCls.Visible(Suryo20, bNextDisp);
			ControlCls.Visible(Suryo21, bNextDisp);
			ControlCls.Visible(Suryo22, bNextDisp);
			ControlCls.Visible(Suryo23, bNextDisp);
			ControlCls.Visible(Suryo24, bNextDisp);
			ControlCls.Visible(Suryo25, bNextDisp);
			ControlCls.Visible(Suryo26, bNextDisp);
			ControlCls.Visible(Suryo27, bNextDisp);
			ControlCls.Visible(Suryo28, bNextDisp);
			ControlCls.Visible(Suryo29, bNextDisp);
			ControlCls.Visible(Suryo30, bNextDisp);

			// 明細表示制御
			if (M1List.Count > 0)
			{
				for (int i = 0; i < M1List.Count; i++)
				{

					ControlCls.Visible(((TextBox)M1.Items[i].FindControl("M1suryo1")), bPrevDisp);
					ControlCls.Visible(((TextBox)M1.Items[i].FindControl("M1suryo2")), bPrevDisp);
					ControlCls.Visible(((TextBox)M1.Items[i].FindControl("M1suryo3")), bPrevDisp);
					ControlCls.Visible(((TextBox)M1.Items[i].FindControl("M1suryo4")), bPrevDisp);
					ControlCls.Visible(((TextBox)M1.Items[i].FindControl("M1suryo5")), bPrevDisp);
					ControlCls.Visible(((TextBox)M1.Items[i].FindControl("M1suryo6")), bPrevDisp);
					ControlCls.Visible(((TextBox)M1.Items[i].FindControl("M1suryo7")), bPrevDisp);
					ControlCls.Visible(((TextBox)M1.Items[i].FindControl("M1suryo8")), bPrevDisp);
					ControlCls.Visible(((TextBox)M1.Items[i].FindControl("M1suryo9")), bPrevDisp);
					ControlCls.Visible(((TextBox)M1.Items[i].FindControl("M1suryo10")), bPrevDisp);
					ControlCls.Visible(((TextBox)M1.Items[i].FindControl("M1suryo11")), bPrevDisp);
					ControlCls.Visible(((TextBox)M1.Items[i].FindControl("M1suryo12")), bPrevDisp);
					ControlCls.Visible(((TextBox)M1.Items[i].FindControl("M1suryo13")), bPrevDisp);
					ControlCls.Visible(((TextBox)M1.Items[i].FindControl("M1suryo14")), bPrevDisp);
					ControlCls.Visible(((TextBox)M1.Items[i].FindControl("M1suryo15")), bPrevDisp);
					ControlCls.Visible(((TextBox)M1.Items[i].FindControl("M1suryo16")), bNextDisp);
					ControlCls.Visible(((TextBox)M1.Items[i].FindControl("M1suryo17")), bNextDisp);
					ControlCls.Visible(((TextBox)M1.Items[i].FindControl("M1suryo18")), bNextDisp);
					ControlCls.Visible(((TextBox)M1.Items[i].FindControl("M1suryo19")), bNextDisp);
					ControlCls.Visible(((TextBox)M1.Items[i].FindControl("M1suryo20")), bNextDisp);
					ControlCls.Visible(((TextBox)M1.Items[i].FindControl("M1suryo21")), bNextDisp);
					ControlCls.Visible(((TextBox)M1.Items[i].FindControl("M1suryo22")), bNextDisp);
					ControlCls.Visible(((TextBox)M1.Items[i].FindControl("M1suryo23")), bNextDisp);
					ControlCls.Visible(((TextBox)M1.Items[i].FindControl("M1suryo24")), bNextDisp);
					ControlCls.Visible(((TextBox)M1.Items[i].FindControl("M1suryo25")), bNextDisp);
					ControlCls.Visible(((TextBox)M1.Items[i].FindControl("M1suryo26")), bNextDisp);
					ControlCls.Visible(((TextBox)M1.Items[i].FindControl("M1suryo27")), bNextDisp);
					ControlCls.Visible(((TextBox)M1.Items[i].FindControl("M1suryo28")), bNextDisp);
					ControlCls.Visible(((TextBox)M1.Items[i].FindControl("M1suryo29")), bNextDisp);
					ControlCls.Visible(((TextBox)M1.Items[i].FindControl("M1suryo30")), bNextDisp);
				}
			}


		}

		#endregion

		#region 明細標題設定

		/// <summary>
		/// 明細標題設定
		/// </summary>
		/// <returns>結果</returns>
		private void hyodaiEdit(Hashtable rec, String jan_id, String size_nm_id , HtmlInputButton btn)
		{
			String hyodaiNm = string.Empty;

			hyodaiNm = rec[size_nm_id].ToString();
			btn.Value = hyodaiNm;
			// janがnullの場合、押下不可にする
			if (string.IsNullOrEmpty(rec[jan_id].ToString()))
			{
				ControlCls.Disable(btn, true);
			}
			return;
		}

		#endregion

		#endregion

	}
}
