using com.xebio.bo.Tf070p01.Constant;
using com.xebio.bo.Tf070p01.Facade;
using com.xebio.bo.Tf070p01.Formvo;
using com.xebio.bo.Tm050p01.Constant;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.Model.Context;
using Common.Advanced.Resource;
using Common.Advanced.Web.Context;
using Common.Advanced.Web.Util;
using Common.Business.C01000.C01003;
using Common.Business.C01000.C01008;
using Common.Business.C01000.C01014;
using Common.Business.C01000.C01015;
using Common.Business.C01000.C01016;
using Common.Business.C01000.C01019;
using Common.Business.C01000.C01024;
using Common.Business.C99999.Constant;
using Common.Conditions;
using Common.IntegrationMD.Constant;
using Common.IntegrationMD.MDControl;
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
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Tf070p01.Page
{
  /// <summary>
  /// Tf070f02のコードビハインドです。
  /// </summary>
  public partial class Tf070f02Page : StandardBasePage
	{

		#region メソッド

		#region ページデータをロードするメソッド
		/// <summary>
		/// Tf070f02画面データを作成する。
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
						pageContext.SetFormVO(new Tf070f02Form());
						switch(commandInfo.ActionMode)
						{
							case "ADD":
								break;
							case "DEL":
							case "UPD":
								IFacadeContext facadeContext =
									FacadeContextFactory.GetFacadeContext(pageContext);
								InitFacadeContext(facadeContext);
								new Tf070f02Facade().DoLoad(facadeContext);
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

			// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
			// 画面情報取得
			Tf070f02Form form = (Tf070f02Form)pageContext.GetFormVO();
			// 選択モードNo取得
			string mode = form.Stkmodeno;
			// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

			try
			{

				//アクションロジックを処理します
				IFacadeContext facadeContext = FacadeContextFactory.GetFacadeContext(pageContext);
				InitFacadeContext(facadeContext);
				new Tf070f02Facade().DoBTNBACK_FRM(facadeContext);
				
				
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
				//commandInfo.PageLoadMode = true;

				// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
				if (mode.Equals(BoSystemConstant.MODE_INSERT))
				{
					// 新規作成モードの場合
					commandInfo.PageLoadMode = true;
				}
				else
				{
					// 新規作成モード以外の場合
					commandInfo.PageLoadMode = false;
				}
				// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
				
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

			// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
			if (!mode.Equals(BoSystemConstant.MODE_INSERT))
			{
				// 新規作成モード以外の場合
				string focusItem = "M1tonanhinkanri_no";
				string focusMno = form.Dictionary[Tf070p01Constant.DIC_M1SELCETROWIDX] as string;

				// フォーカス設定
				SetFocusCls.SetFocus(queryList, focusItem, focusMno);
			}
			// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

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
				new Tf070f02Facade().DoBTNROWINS_MADD(facadeContext);
				
				
				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
					//base.SetError(pageContext);
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

			// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
			string focusItem = "M1hassei_tm";
			string focusMno = (((Tf070f02Form)pageContext.GetFormVO()).GetList("M1").Count - 1).ToString();

			// フォーカス設定
			SetFocusCls.SetFocus(queryList, focusItem, focusMno);
			// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

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
				new Tf070f02Facade().DoBTNPAGEINS_MINSX(facadeContext);
				//明細フォーカスセット用インデックスを取得します。
				index = facadeContext.GetUserObject(MdSystemConstant.DETAIL_FOCUS_INDEX) as string;
				
				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
					//base.SetError(pageContext);
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

			// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
			// フォーカス設定
			SetFocusCls.SetFocus(queryList, "M1hassei_tm", index);
			// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNPAGEINS_MINSX");
			
			//画面遷移
			base.Forward(pageContext, queryList);
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

			// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
			// フォーカスセット用インデックス
			string index;
			// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

			try
			{

				//アクションロジックを処理します
				IFacadeContext facadeContext = FacadeContextFactory.GetFacadeContext(pageContext);
				InitFacadeContext(facadeContext);
				new Tf070f02Facade().DoBTNROWDEL_FRM(facadeContext);
				
				
				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
					//base.SetError(pageContext);
					return;
				}

				// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
				// 明細フォーカスセット用インデックスを取得します。
				index = facadeContext.GetUserObject(Tf070p01Constant.FCDUO_FOCUSROW) as string;
				// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

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

			// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
			// フォーカス設定
			SetFocusCls.SetFocus(queryList, "M1hassei_tm", index);
			// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNROWDEL_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Btncsv_torikomi())
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btncsv_torikomi())
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnBTNCSV_TORIKOMI_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnBTNCSV_TORIKOMI_FRM");
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

			// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
			string focusMno = string.Empty;
			// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

			try
			{

				//アクションロジックを処理します
				IFacadeContext facadeContext = FacadeContextFactory.GetFacadeContext(pageContext);
				InitFacadeContext(facadeContext);
				//new Tf070f02Facade().DoBTNCSV_TORIKOMI_FRM(facadeContext);

				// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
				if (Session[OpenTm050p01Cls.KEY_CSV_IMPORT_RESULT] != null)
				{
					// セッションにCSV取込戻り値が設定されている場合

					// セッションからファサードコンテキストに設定
					facadeContext.SetUserObject(Tf070p01Constant.DIC_CSV_IMPORT_RESULT, Session[OpenTm050p01Cls.KEY_CSV_IMPORT_RESULT]);

					new Tf070f02Facade().DoBTNCSV_TORIKOMI_FRM(facadeContext);

					focusMno = facadeContext.GetUserObject(Tf070p01Constant.DIC_FOCUS_INDEX).ToString();
				}
				else
				{
					#region CSV取込画面起動パラメータ設定
					// フォームオブジェクト取得
					Tf070f02Form form = (Tf070f02Form)pageContext.GetFormVO();

					// 画面ID
					string formId = Tm050p01Constant.FORMID_TF070F02;

					// 現在行数
					int curRowCnt = 0;
					// 明細オブジェクト取得
					IDataList m1List = form.GetList("M1");
					for (int i = m1List.Count - 1; i >= 0; i--)
					{
						// 行オブジェクト取得
						Tf070f02M1Form m1Form = (Tf070f02M1Form)m1List[i];

						if (
							!string.IsNullOrEmpty(m1Form.M1hassei_tm)			// Ｍ１発生時間
							|| !string.IsNullOrEmpty(m1Form.M1hasseibasyo)		// Ｍ１発生場所
							|| !string.IsNullOrEmpty(m1Form.M1hakkentan_cd)		// Ｍ１発見担当者コード
							|| !m1Form.M1hakkenjyokyo_kb.Equals(BoSystemConstant.DROPDOWNLIST_MISENTAKU)	// Ｍ１発見状況区分
							|| !string.IsNullOrEmpty(m1Form.M1hakkenjyokyo_nm)	// Ｍ１発見状況
							|| !string.IsNullOrEmpty(m1Form.M1scan_cd)			// Ｍ１スキャンコード
							|| !string.IsNullOrEmpty(m1Form.M1sinsei_su)		// Ｍ１申請数
							|| !string.IsNullOrEmpty(m1Form.M1jyuri_su)			// Ｍ１受理数
							)
						{
							// いずれかの入力項目が入力されている場合
							curRowCnt = i + 1;
							break;
						}
					}
					form.Dictionary[Tf070p01Constant.DIC_CUR_ROW_CNT] = curRowCnt;

					// 最大行数
					int maxRowCnt = decimal.ToInt32(GetMaxCntCls.GetMaxCnt(formId.ToUpper(), Tf070p01Constant.MAX_CNT_EDABAN_SHINKI));

					// CSV名称
					string csvName = BoSystemConstant.CSVNM_TONAN_TOROKU;

					// 後続処理にて押下させるボタンID
					string afterActBtn = this.Btncsv_torikomi.ID;

					#region CSVチェック情報
					CsvCheckInfoVO csvCheckInfoVO = new CsvCheckInfoVO();

					// 店舗コード
					csvCheckInfoVO.Tenpo_cd = form.Head_tenpo_cd;
		
					// スキャンコードが格納されているインデックス
					csvCheckInfoVO.Index_scan_cd = 5;

					// 項目情報
					CsvCheckItemInfoVO item = null;

					// 発生時間
					item = new CsvCheckItemInfoVO();
					item.Item_id = Tf070p01Constant.CSV_ITEM_ID_HASSEI_JIKAN;		// 項目ID
					item.Item_name = "発生時間";									// 項目名
					item.Required_flg = true;										// 必須チェックフラグ
					item.Type_kbn = CsvCheckItemInfoVO.TYPE_KBN_HALF_NUM;			// 属性チェック区分
					item.Max_length = 2;											// 最大桁数
					csvCheckInfoVO.List_csv_item_info.Add(item);

					// 発生場所
					item = new CsvCheckItemInfoVO();
					item.Item_id = Tf070p01Constant.CSV_ITEM_ID_HASSEI_BASHO;		// 項目ID
					item.Item_name = "発生場所";									// 項目名
					item.Required_flg = true;										// 必須チェックフラグ
					item.Type_kbn = CsvCheckItemInfoVO.TYPE_KBN_ILLEGAL;			// 属性チェック区分
					item.Max_byte = 20;												// 最大バイト数
					csvCheckInfoVO.List_csv_item_info.Add(item);

					// 発見者コード
					item = new CsvCheckItemInfoVO();
					item.Item_id = Tf070p01Constant.CSV_ITEM_ID_HAKKENSHA_CD;		// 項目ID
					item.Item_name = "発見者コード";								// 項目名
					item.Required_flg = true;										// 必須チェックフラグ
					item.Type_kbn = CsvCheckItemInfoVO.TYPE_KBN_HALF_NUM;			// 属性チェック区分
					item.Max_length = 7;											// 最大桁数
					item.Mst_check_id = CsvCheckItemInfoVO.MST_CHECK_ID_TANTOSHA;	// マスタチェックID
					csvCheckInfoVO.List_csv_item_info.Add(item);

					// 発見状況区分
					item = new CsvCheckItemInfoVO();
					item.Item_id = Tf070p01Constant.CSV_ITEM_ID_HAKKENJOKYO_KBN;	// 項目ID
					item.Item_name = "発見状況区分";								// 項目名
					item.Required_flg = true;										// 必須チェックフラグ
					item.Type_kbn = CsvCheckItemInfoVO.TYPE_KBN_HALF_NUM;			// 属性チェック区分
					item.Max_length = 1;											// 最大桁数
					item.Mst_check_id = CsvCheckItemInfoVO.MST_CHECK_ID_MEISHO;		// マスタチェックID
					item.Sikibetsu_cd = "KHHK";										// 識別コード
					csvCheckInfoVO.List_csv_item_info.Add(item);

					// 発見状況テキスト
					item = new CsvCheckItemInfoVO();
					item.Item_id = Tf070p01Constant.CSV_ITEM_ID_HAKKENJOKYO_TEXT;	// 項目ID
					item.Item_name = "発見状況テキスト";							// 項目名
					item.Type_kbn = CsvCheckItemInfoVO.TYPE_KBN_ILLEGAL;			// 属性チェック区分
					item.Max_byte = 80;												// 最大バイト数
					csvCheckInfoVO.List_csv_item_info.Add(item);

					// スキャンコード
					item = new CsvCheckItemInfoVO();
					item.Item_id = Tf070p01Constant.CSV_ITEM_ID_SCAN_CD;			// 項目ID
					item.Item_name = "スキャンコード";								// 項目名
					item.Required_flg = true;										// 必須チェックフラグ
					item.Type_kbn = CsvCheckItemInfoVO.TYPE_KBN_HALF_NUM;			// 属性チェック区分
					item.Mst_check_id = CsvCheckItemInfoVO.MST_CHECK_ID_HATCHU;		// マスタチェックID
					csvCheckInfoVO.List_csv_item_info.Add(item);

					// 申請数
					item = new CsvCheckItemInfoVO();
					item.Item_id = Tf070p01Constant.CSV_ITEM_ID_SINSEI_SU;			// 項目ID
					item.Item_name = "申請数";										// 項目名
					item.Required_flg = true;										// 必須チェックフラグ
					item.Type_kbn = CsvCheckItemInfoVO.TYPE_KBN_NUMERIC;			// 属性チェック区分
					item.Max_length = 3;											// 最大桁数
					item.Zero_check_flg = true;										// ０チェックフラグ
					csvCheckInfoVO.List_csv_item_info.Add(item);

					// 受理数
					item = new CsvCheckItemInfoVO();
					item.Item_id = Tf070p01Constant.CSV_ITEM_ID_JURI_SU;			// 項目ID
					item.Item_name = "受理数";										// 項目名
					item.Type_kbn = CsvCheckItemInfoVO.TYPE_KBN_NUMERIC;			// 属性チェック区分
					item.Max_length = 3;											// 最大桁数
					csvCheckInfoVO.List_csv_item_info.Add(item);
					#endregion

					// CSVチェック情報をセッションに設定
					Session[OpenTm050p01Cls.KEY_CSV_CHECK_INFO] = csvCheckInfoVO;
					#endregion

					// CSV取込画面起動
					OpenTm050p01Cls.OpenTm050p01(Page, formId, curRowCnt, maxRowCnt, csvName, afterActBtn);
				}
				// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

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
				// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
				if (Session[OpenTm050p01Cls.KEY_CSV_IMPORT_RESULT] != null)
				{
					// セッションにCSV取込戻り値が設定されている場合
					// セッションから削除
					Session.Remove(OpenTm050p01Cls.KEY_CSV_IMPORT_RESULT);
				}
				// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

				ThrowException(ex, pageContext);
				return;
			}
			
			//URLクエリ追加用NameValueCollection
			NameValueCollection queryList = new NameValueCollection();
			
			//フォーカスを当てる項目を指定したい場合はFormFocusUtilを使ってqueryListに追加すること
			
			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNCSV_TORIKOMI_FRM");
			
			//画面遷移
			//base.Forward(pageContext, queryList);

			// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
			if (Session[OpenTm050p01Cls.KEY_CSV_IMPORT_RESULT] != null)
			{
				// セッションにCSV取込戻り値が設定されている場合

				// セッションから削除
				Session.Remove(OpenTm050p01Cls.KEY_CSV_IMPORT_RESULT);

				// フォーカス設定
				SetFocusCls.SetFocus(queryList, "M1hassei_tm", focusMno);

				//画面遷移
				base.Forward(pageContext, queryList);
			}
			// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
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
				new Tf070f02Facade().DoPGR_PGN(facadeContext, pageindex);
				
				
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

			// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
			// 画面情報取得
			Tf070f02Form form = (Tf070f02Form)pageContext.GetFormVO();
//			// 単一ダウンロード情報
//			DLConditionVO dlvo = new DLConditionVO();
			// 複数ダウンロード情報
			List<string> dlList = new List<string>();
			// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

			try
			{

				//アクションロジックを処理します
				IFacadeContext facadeContext = FacadeContextFactory.GetFacadeContext(pageContext);
				InitFacadeContext(facadeContext);
				new Tf070f02Facade().DoBTNENTER_FRM(facadeContext);
				
				
				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
					//base.SetError(pageContext);
					return;
				}
				
				//遷移先の画面設定（入出力画面定義で設定した遷移先は初期化処理で設定済み）
				//入出力画面定義で設定した遷移先以外の画面に遷移する場合は以下のソースを
				//コメントインし、設定して下さい。
				//commandInfo.ToProgramId = "遷移先プログラムID";
				//commandInfo.ToFormId = "遷移先フォームID";
				
				//他の処理モードを設定する必要がある場合、次の行を修正してください
				//commandInfo.ActionMode = "UPD";
				//commandInfo.PageLoadMode = true;

				// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
				if (form.Stkmodeno.Equals(BoSystemConstant.MODE_INSERT))
				{
					// 新規作成モードの場合
					commandInfo.ActionMode = "INI";
					commandInfo.PageLoadMode = true;
				}
				else
				{
					// 新規作成モード以外の場合
					commandInfo.ActionMode = "UPD";
					commandInfo.PageLoadMode = false;
				}

				#region 出力PDFファイルダウンロード設定
				#region 新規作成/経費申請
				// PDFファイル名リスト取得
				if (form.Stkmodeno.Equals(BoSystemConstant.MODE_INSERT) || form.Stkmodeno.Equals(BoSystemConstant.MODE_KEIHISINSEI)) 
				{ 
					dlList = facadeContext.GetUserObject(Tf070p01Constant.FCDUO_RRT_FLNM) as List<string>;
					// 複数ダウンロード用にファイル名をセッションにセット
					SessionInfoUtil.SetPgObject(pageContext.CommandInfo.ProgramId, SessionKeyConstant.DOWNLOAD_FILE_LIST, dlList, Session);
				}
				#endregion
				#endregion

				// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

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

			// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
			if (!form.Stkmodeno.Equals(BoSystemConstant.MODE_INSERT))
			{
				// 新規作成モード以外の場合
				string focusItem = "M1tonanhinkanri_no";
				string focusMno = form.Dictionary[Tf070p01Constant.DIC_M1SELCETROWIDX] as string;

				// フォーカス設定
				SetFocusCls.SetFocus(queryList, focusItem, focusMno);
			}
			// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

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
						Tf070f02Form tf070f02Form = (Tf070f02Form)pageContext.GetFormVO();

						//明細ページ情報を表示する
						ShowListPageInfo(tf070f02Form);
			
						//明細部データを表示する
						RenderList(tf070f02Form, pageContext.FormInfo, formResource, lang);

						//カード部データを表示する
						RenderCard(tf070f02Form, pageContext.FormInfo, formResource, lang);
					//}

					// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
					//エラー判定
					if (MessageDisplayUtil.HasError(FacadeContextFactory.GetFacadeContext(pageContext)))
					{
						base.SetError(pageContext);
						SetItems();
					}
					// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

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
		/// <param name="tf070f02Form">画面FormVO</param>
		private void ShowListPageInfo(Tf070f02Form tf070f02Form)
		{
			//M1明細ページ情報を表示する。
			ShowM1ListPageInfo(tf070f02Form.GetList("M1"));

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
		/// <param name="tf070f02Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderList(
			Tf070f02Form tf070f02Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//画面のM1明細部データを設定する。
			RenderM1List(tf070f02Form, formInfo, formResource, lang);
			//M1明細部のページャーにページ情報を設定する。
			RenderM1Pager(tf070f02Form);
			
		}
		#endregion

		#region M1明細データを表示する
		/// <summary>
		/// M1明細データを表示する。
		/// </summary>
		/// <param name="tf070f02Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderM1List(
			Tf070f02Form tf070f02Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//M1明細部データソースを設定する。
			M1.DataSource = tf070f02Form.GetPageViewList("M1");
			M1.DataBind();

			//M1明細部データをフォーマットする。
			IList m1DataList = (IList)M1.DataSource;
			
			for (int index = 0; index < M1.Items.Count; index++)
			{
				Tf070f02M1Form tf070f02M1Form = (Tf070f02M1Form)m1DataList[index];
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1rowno"),
					DataFormatUtil.GetFormatItem(tf070f02M1Form.M1rowno,formInfo["M1rowno"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1hassei_tm"),
					DataFormatUtil.GetFormatItem(tf070f02M1Form.M1hassei_tm,formInfo["M1hassei_tm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1hasseibasyo"),
					DataFormatUtil.GetFormatItem(tf070f02M1Form.M1hasseibasyo,formInfo["M1hasseibasyo"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1bumon_cd"),
					DataFormatUtil.GetFormatItem(tf070f02M1Form.M1bumon_cd,formInfo["M1bumon_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1bumonkana_nm"),
					DataFormatUtil.GetFormatItem(tf070f02M1Form.M1bumonkana_nm,formInfo["M1bumonkana_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1hinsyu_ryaku_nm"),
					DataFormatUtil.GetFormatItem(tf070f02M1Form.M1hinsyu_ryaku_nm,formInfo["M1hinsyu_ryaku_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1hakkentan_cd"),
					DataFormatUtil.GetFormatItem(tf070f02M1Form.M1hakkentan_cd,formInfo["M1hakkentan_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1hakkentan_nm"),
					DataFormatUtil.GetFormatItem(tf070f02M1Form.M1hakkentan_nm,formInfo["M1hakkentan_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1burando_nm"),
					DataFormatUtil.GetFormatItem(tf070f02M1Form.M1burando_nm,formInfo["M1burando_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1jisya_hbn"),
					DataFormatUtil.GetFormatItem(tf070f02M1Form.M1jisya_hbn,formInfo["M1jisya_hbn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1hakkenjyokyo_kb"),
					DataFormatUtil.GetFormatItem(tf070f02M1Form.M1hakkenjyokyo_kb,formInfo["M1hakkenjyokyo_kb"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1hakkenjyokyo_nm"),
					DataFormatUtil.GetFormatItem(tf070f02M1Form.M1hakkenjyokyo_nm,formInfo["M1hakkenjyokyo_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1maker_hbn"),
					DataFormatUtil.GetFormatItem(tf070f02M1Form.M1maker_hbn,formInfo["M1maker_hbn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1syonmk"),
					DataFormatUtil.GetFormatItem(tf070f02M1Form.M1syonmk,formInfo["M1syonmk"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1iro_nm"),
					DataFormatUtil.GetFormatItem(tf070f02M1Form.M1iro_nm,formInfo["M1iro_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1size_nm"),
					DataFormatUtil.GetFormatItem(tf070f02M1Form.M1size_nm,formInfo["M1size_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1scan_cd"),
					DataFormatUtil.GetFormatItem(tf070f02M1Form.M1scan_cd,formInfo["M1scan_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1sinsei_su"),
					DataFormatUtil.GetFormatItem(tf070f02M1Form.M1sinsei_su,formInfo["M1sinsei_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1jyuri_su"),
					DataFormatUtil.GetFormatItem(tf070f02M1Form.M1jyuri_su,formInfo["M1jyuri_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1baika_hon"),
					DataFormatUtil.GetFormatItem(tf070f02M1Form.M1baika_hon,formInfo["M1baika_hon"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1baika_kin"),
					DataFormatUtil.GetFormatItem(tf070f02M1Form.M1baika_kin,formInfo["M1baika_kin"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1sinsei_su_hdn"),
					DataFormatUtil.GetFormatItem(tf070f02M1Form.M1sinsei_su_hdn,formInfo["M1sinsei_su_hdn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1jyuri_su_hdn"),
					DataFormatUtil.GetFormatItem(tf070f02M1Form.M1jyuri_su_hdn,formInfo["M1jyuri_su_hdn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1baika_kin_hdn"),
					DataFormatUtil.GetFormatItem(tf070f02M1Form.M1baika_kin_hdn,formInfo["M1baika_kin_hdn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1selectorcheckbox"),
					DataFormatUtil.GetFormatItem(tf070f02M1Form.M1selectorcheckbox,formInfo["M1selectorcheckbox"]));
				((System.Web.UI.WebControls.CheckBox)M1.Items[index].FindControl("M1selectorcheckbox")).Text =
					formResource.GetString("M1selectorcheckbox", lang);
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1entersyoriflg"),
					DataFormatUtil.GetFormatItem(tf070f02M1Form.M1entersyoriflg,formInfo["M1entersyoriflg"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1dtlirokbn"),
					DataFormatUtil.GetFormatItem(tf070f02M1Form.M1dtlirokbn,formInfo["M1dtlirokbn"]));

				if(!base.CheckUseSelfCustomize()){
					((System.Web.UI.HtmlControls.HtmlInputButton)M1.Items[index].FindControl("M1btntanto_cd")).Value =
						formResource.GetString("M1btntanto_cd", lang);

					// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
					// 明細背景色の設定
					DetailColorCls.DetailColorSet(M1, index);
					// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
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
				// (M1.HeaderRow.FindControl("M1hassei_tm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hassei_tm", lang), base.GetPageContext().FormInfo["M1hassei_tm"]);
				// (M1.HeaderRow.FindControl("M1hasseibasyo") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hasseibasyo", lang), base.GetPageContext().FormInfo["M1hasseibasyo"]);
				// (M1.HeaderRow.FindControl("M1bumon_cd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumon_cd", lang), base.GetPageContext().FormInfo["M1bumon_cd"]);
				// (M1.HeaderRow.FindControl("M1bumonkana_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumonkana_nm", lang), base.GetPageContext().FormInfo["M1bumonkana_nm"]);
				// (M1.HeaderRow.FindControl("M1hinsyu_ryaku_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hinsyu_ryaku_nm", lang), base.GetPageContext().FormInfo["M1hinsyu_ryaku_nm"]);
				// (M1.HeaderRow.FindControl("M1hakkentan_cd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hakkentan_cd", lang), base.GetPageContext().FormInfo["M1hakkentan_cd"]);
				// (M1.HeaderRow.FindControl("M1btntanto_cd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1btntanto_cd", lang), base.GetPageContext().FormInfo["M1btntanto_cd"]);
				// (M1.HeaderRow.FindControl("M1hakkentan_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hakkentan_nm", lang), base.GetPageContext().FormInfo["M1hakkentan_nm"]);
				// (M1.HeaderRow.FindControl("M1burando_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1burando_nm", lang), base.GetPageContext().FormInfo["M1burando_nm"]);
				// (M1.HeaderRow.FindControl("M1jisya_hbn") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1jisya_hbn", lang), base.GetPageContext().FormInfo["M1jisya_hbn"]);
				// (M1.HeaderRow.FindControl("M1hakkenjyokyo_kb") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hakkenjyokyo_kb", lang), base.GetPageContext().FormInfo["M1hakkenjyokyo_kb"]);
				// (M1.HeaderRow.FindControl("M1hakkenjyokyo_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hakkenjyokyo_nm", lang), base.GetPageContext().FormInfo["M1hakkenjyokyo_nm"]);
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
				// (M1.HeaderRow.FindControl("M1sinsei_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1sinsei_su", lang), base.GetPageContext().FormInfo["M1sinsei_su"]);
				// (M1.HeaderRow.FindControl("M1jyuri_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1jyuri_su", lang), base.GetPageContext().FormInfo["M1jyuri_su"]);
				// (M1.HeaderRow.FindControl("M1baika_hon") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1baika_hon", lang), base.GetPageContext().FormInfo["M1baika_hon"]);
				// (M1.HeaderRow.FindControl("M1baika_kin") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1baika_kin", lang), base.GetPageContext().FormInfo["M1baika_kin"]);
				// (M1.HeaderRow.FindControl("M1sinsei_su_hdn") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1sinsei_su_hdn", lang), base.GetPageContext().FormInfo["M1sinsei_su_hdn"]);
				// (M1.HeaderRow.FindControl("M1jyuri_su_hdn") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1jyuri_su_hdn", lang), base.GetPageContext().FormInfo["M1jyuri_su_hdn"]);
				// (M1.HeaderRow.FindControl("M1baika_kin_hdn") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1baika_kin_hdn", lang), base.GetPageContext().FormInfo["M1baika_kin_hdn"]);
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
		/// <param name="tf070f02Form">画面FormVO</param>
		private void RenderM1Pager(Tf070f02Form tf070f02Form)
		{
			Pgr.VirtualItemCount = tf070f02Form.GetList("M1").RecordCount;
			Pgr.CurrentPageIndex = tf070f02Form.GetList("M1").PageNo - 1;
			Pgr.PageSize = tf070f02Form.GetList("M1").DispRow;
		}
		#endregion
		#endregion

		#region カードデータを表示する
		/// <summary>
		/// カードデータを表示する
		/// </summary>
		/// <param name="tf070f02Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderCard(
			Tf070f02Form tf070f02Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			
			ControlUtil.SetControlValue(Head_tenpo_cd,
				DataFormatUtil.GetFormatItem(tf070f02Form.Head_tenpo_cd,formInfo["Head_tenpo_cd"]));
			ControlUtil.SetControlValue(Head_tenpo_nm,
				DataFormatUtil.GetFormatItem(tf070f02Form.Head_tenpo_nm,formInfo["Head_tenpo_nm"]));
			ControlUtil.SetControlValue(Stkmodeno,
				DataFormatUtil.GetFormatItem(tf070f02Form.Stkmodeno,formInfo["Stkmodeno"]));
			ControlUtil.SetControlValue(Tonanhinkanri_no,
				DataFormatUtil.GetFormatItem(tf070f02Form.Tonanhinkanri_no,formInfo["Tonanhinkanri_no"]));
			ControlUtil.SetControlValue(Jikohassei_ymd,
				DataFormatUtil.GetFormatItem(tf070f02Form.Jikohassei_ymd,formInfo["Jikohassei_ymd"]));
			ControlUtil.SetControlValue(Hokoku_ymd,
				DataFormatUtil.GetFormatItem(tf070f02Form.Hokoku_ymd,formInfo["Hokoku_ymd"]));
			ControlUtil.SetControlValue(Hokokutan_cd,
				DataFormatUtil.GetFormatItem(tf070f02Form.Hokokutan_cd,formInfo["Hokokutan_cd"]));
			ControlUtil.SetControlValue(Hokokutan_nm,
				DataFormatUtil.GetFormatItem(tf070f02Form.Hokokutan_nm,formInfo["Hokokutan_nm"]));
			ControlUtil.SetControlValue(Tentyotan_cd,
				DataFormatUtil.GetFormatItem(tf070f02Form.Tentyotan_cd,formInfo["Tentyotan_cd"]));
			ControlUtil.SetControlValue(Tentyotan_nm,
				DataFormatUtil.GetFormatItem(tf070f02Form.Tentyotan_nm,formInfo["Tentyotan_nm"]));
			ControlUtil.SetControlValue(Keisatsutodoke_ymd,
				DataFormatUtil.GetFormatItem(tf070f02Form.Keisatsutodoke_ymd,formInfo["Keisatsutodoke_ymd"]));
			ControlUtil.SetControlValue(Todokedesakikeisatsu_nm,
				DataFormatUtil.GetFormatItem(tf070f02Form.Todokedesakikeisatsu_nm,formInfo["Todokedesakikeisatsu_nm"]));
			ControlUtil.SetControlValue(Jyuri_no,
				DataFormatUtil.GetFormatItem(tf070f02Form.Jyuri_no,formInfo["Jyuri_no"]));
			ControlUtil.SetControlValue(Gokeisinsei_su,
				DataFormatUtil.GetFormatItem(tf070f02Form.Gokeisinsei_su,formInfo["Gokeisinsei_su"]));
			ControlUtil.SetControlValue(Gokeijyuri_su,
				DataFormatUtil.GetFormatItem(tf070f02Form.Gokeijyuri_su,formInfo["Gokeijyuri_su"]));
			ControlUtil.SetControlValue(Gokeibaika_kin,
				DataFormatUtil.GetFormatItem(tf070f02Form.Gokeibaika_kin,formInfo["Gokeibaika_kin"]));

			if(!base.CheckUseSelfCustomize()){
				Btnback.Value = base.FormResourceGetString(formResource, "Btnback", lang);
				Btnhokokutanto_cd.Value = base.FormResourceGetString(formResource, "Btnhokokutanto_cd", lang);
				Btntenhchotanto_cd.Value = base.FormResourceGetString(formResource, "Btntenhchotanto_cd", lang);
				Btnrowins.Value = base.FormResourceGetString(formResource, "Btnrowins", lang);
				Btnpageins.Value = base.FormResourceGetString(formResource, "Btnpageins", lang);
				Btnrowdel.Value = base.FormResourceGetString(formResource, "Btnrowdel", lang);
				Btncsv_torikomi.Value = base.FormResourceGetString(formResource, "Btncsv_torikomi", lang);
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
			//if (!IsPostBack)
			//{
				for (int i = 0; i < this.M1.Items.Count; i++)
				{
					// Ｍ１発見状況区分に空白を追加
					MDConditionDDList m1HakkenjyokyoKb = (MDConditionDDList)this.M1.Items[i].FindControl("M1hakkenjyokyo_kb");
					ListItem empty = new ListItem(string.Empty, BoSystemConstant.DROPDOWNLIST_MISENTAKU);
					m1HakkenjyokyoKb.Items.Remove(empty);
					m1HakkenjyokyoKb.Items.Insert(0, empty);

					if (CheckCompanyCls.IsXebio())
					{
						// Xの場合
						ListItem rintana = new ListItem(ConditionUtil.GetLabel(ConditionHakkenjyokyo_kb.ID, ConditionHakkenjyokyo_kb.VALUE_HAKKENJYOKYO_KB5), ConditionHakkenjyokyo_kb.VALUE_HAKKENJYOKYO_KB5);
						// 「"5"（臨棚で発見）」を削除
						m1HakkenjyokyoKb.Items.Remove(rintana);
					}
				}
			//}
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
			// UIScreenController controller = new UIScreenController((Tf070f02Form)base.GetPageContext().GetFormVO());
			// controller.ChangeColumnsDisplayMode(M1 ,  new DetailHeaderFixedVO(M1Header , true) , null);

			/*
			 *登録した機能間連携処理を親画面に感知させる。
			 *機能有効させる場合は、コメントアウトを外してください。
			 */
			//DetailUtil.RunPgSyn(this,(StandardBaseForm)base.GetPageContext().GetFormVO());

			// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
			#region 項目制御
			Tf070f02Form form = (Tf070f02Form)base.GetPageContext().GetFormVO();

			for (int i = 0; i < this.M1.Items.Count; i++)
			{
				// Ｍ１発見状況区分
				MDConditionDDList m1HakkenjyokyoKb = (MDConditionDDList)this.M1.Items[i].FindControl("M1hakkenjyokyo_kb");
				if (!m1HakkenjyokyoKb.SelectedValue.Equals(ConditionHakkenjyokyo_kb.VALUE_HAKKENJYOKYO_KB7))
				{
					// 「その他」以外の場合
					// Ｍ１発見状況　使用不可
					ControlCls.Disable((MDTextBox)this.M1.Items[i].FindControl("M1hakkenjyokyo_nm"), true);
				}
				else
				{
					// Ｍ１発見状況　使用可
					ControlCls.Disable((MDTextBox)this.M1.Items[i].FindControl("M1hakkenjyokyo_nm"), false);
				}
			}

			if (form.Stkmodeno.Equals(BoSystemConstant.MODE_INSERT))
			{
				// 新規作成モードの場合

				if (CheckCompanyCls.IsXebio())
				{
					// Xの場合
					// 受理番号　使用不可
					ControlCls.Disable(this.Jyuri_no, true);
				}

				// 行追加ボタン　非表示
				ControlCls.Visible(this.Spanrowins, false);

				if (!CheckKengenCls.CheckKengen(LoginInfoUtil.GetLoginInfo()))
				{
					// 店舗の場合
					// CSV取込ボタン　非表示
					ControlCls.Visible(this.Spancsv_torikomi, false);
				}
			}
			else
			{
				// 新規作成モード以外の場合

				// ページ追加ボタン　非表示
				ControlCls.Visible(this.Spanpageins, false);
				// CSV取込ボタン　使用不可
				ControlCls.Disable(this.Btncsv_torikomi, true);

				if (!CheckKengenCls.CheckKengen(LoginInfoUtil.GetLoginInfo()))
				{
					// 店舗の場合
					// CSV取込ボタン　非表示
					ControlCls.Visible(this.Spancsv_torikomi, false);
				}

				if	(	(	!form.Stkmodeno.Equals(BoSystemConstant.MODE_KEIHISINSEI)	// 経費申請モード以外
						&&	!form.Stkmodeno.Equals(BoSystemConstant.MODE_UPD)			// 修正モード以外
						)
					||	(	form.Stkmodeno.Equals(BoSystemConstant.MODE_KEIHISINSEI)											// 経費申請モード
						&&	form.Dictionary[Tf070p01Constant.DIC_KAKUTEISYORI_FLG].Equals(ConditionKakuteisyori_flg.VALUE_ARI)	// 確定済
						)
					)
				{
					// [選択モードNO]が「経費申請」、「修正」のいずれでもない場合
					// [選択モードNO]が「経費申請」、かつ選択行.[Ｍ１確定処理フラグ(隠し)]が"1"（確定済）の場合

					// 事故発生日　使用不可
					ControlCls.Disable(this.Jikohassei_ymd, true);
					// 報告日　使用不可
					ControlCls.Disable(this.Hokoku_ymd, true);
					// 報告担当者コード　使用不可
					ControlCls.Disable(this.Hokokutan_cd, true);
					// 報告担当者コードボタン　使用不可
					ControlCls.Disable(this.Btnhokokutanto_cd, true);
					// 店長担当者コード　使用不可
					ControlCls.Disable(this.Tentyotan_cd, true);
					// 店長担当者コードボタン　使用不可
					ControlCls.Disable(this.Btntenhchotanto_cd, true);
					// 警察届出日　使用不可
					ControlCls.Disable(this.Keisatsutodoke_ymd, true);
					// 届出先警察署名　使用不可
					ControlCls.Disable(this.Todokedesakikeisatsu_nm, true);

					// 行追加ボタン　使用不可
					ControlCls.Disable(this.Btnrowins, true);
					// 行削除ボタン　使用不可
					ControlCls.Disable(this.Btnrowdel, true);

					for (int i = 0; i < this.M1.Items.Count; i++)
					{
						// Ｍ１発生時間　使用不可
						ControlCls.Disable((MDTextBox)this.M1.Items[i].FindControl("M1hassei_tm"), true);
						// Ｍ１発生場所　使用不可
						ControlCls.Disable((MDTextBox)this.M1.Items[i].FindControl("M1hasseibasyo"), true);
						// Ｍ１発見担当者コード　使用不可
						ControlCls.Disable((MDTextBox)this.M1.Items[i].FindControl("M1hakkentan_cd"), true);
						// Ｍ１担当者コードボタン　使用不可
						ControlCls.Disable((HtmlInputButton)this.M1.Items[i].FindControl("M1btntanto_cd"), true);
						// Ｍ１発見状況区分　使用不可
						ControlCls.Disable((MDConditionDDList)this.M1.Items[i].FindControl("M1hakkenjyokyo_kb"), true);
						// Ｍ１発見状況　使用不可
						ControlCls.Disable((MDTextBox)this.M1.Items[i].FindControl("M1hakkenjyokyo_nm"), true);
						// Ｍ１スキャンコード　使用不可
						ControlCls.Disable((MDTextBox)this.M1.Items[i].FindControl("M1scan_cd"), true);
						// Ｍ１申請数　使用不可
						ControlCls.Disable((MDTextBox)this.M1.Items[i].FindControl("M1sinsei_su"), true);
						// Ｍ１受理数　使用不可
						ControlCls.Disable((MDTextBox)this.M1.Items[i].FindControl("M1jyuri_su"), true);
					}

					// 確定ボタン　使用不可
					ControlCls.Disable(this.Btnenter, true);
				}

				if (	(	CheckCompanyCls.IsXebio()									// X
						&&	!form.Stkmodeno.Equals(BoSystemConstant.MODE_KEIHISINSEI)	// 経費申請モード以外
						)
					||	(	!CheckCompanyCls.IsXebio()									// X以外
						&&	!form.Stkmodeno.Equals(BoSystemConstant.MODE_KEIHISINSEI)	// 経費申請モード以外
						&&	!form.Stkmodeno.Equals(BoSystemConstant.MODE_UPD)			// 修正モード以外
						)
					||	(	form.Stkmodeno.Equals(BoSystemConstant.MODE_KEIHISINSEI)											// 経費申請モード
						&&	form.Dictionary[Tf070p01Constant.DIC_KAKUTEISYORI_FLG].Equals(ConditionKakuteisyori_flg.VALUE_ARI)	// 確定済
						)
					)
				{
					// Xの場合、かつ[選択モードNO]が「経費申請」でない場合
					// X以外の場合、かつ[選択モードNO]が「経費申請」「修正」のいずれでもない場合
					// [選択モードNO]が「経費申請」、かつ選択行.[Ｍ１確定処理フラグ(隠し)]が"1"（確定済）の場合

					// 受理番号　使用不可
					ControlCls.Disable(this.Jyuri_no, true);
				}
			}
			#endregion
			// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
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
			ControlUtil.SetControlValue(Tonanhinkanri_no_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Tonanhinkanri_no", lang), base.GetPageContext().FormInfo["Tonanhinkanri_no"]));
				DataFormatUtil.SetMustColorCaption(Tonanhinkanri_no_lbl, base.GetPageContext().FormInfo["Tonanhinkanri_no"]);
			ControlUtil.SetControlValue(Jikohassei_ymd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Jikohassei_ymd", lang), base.GetPageContext().FormInfo["Jikohassei_ymd"]));
				DataFormatUtil.SetMustColorCaption(Jikohassei_ymd_lbl, base.GetPageContext().FormInfo["Jikohassei_ymd"]);
			ControlUtil.SetControlValue(Hokoku_ymd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Hokoku_ymd", lang), base.GetPageContext().FormInfo["Hokoku_ymd"]));
				DataFormatUtil.SetMustColorCaption(Hokoku_ymd_lbl, base.GetPageContext().FormInfo["Hokoku_ymd"]);
			ControlUtil.SetControlValue(Hokokutan_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Hokokutan_cd", lang), base.GetPageContext().FormInfo["Hokokutan_cd"]));
				DataFormatUtil.SetMustColorCaption(Hokokutan_cd_lbl, base.GetPageContext().FormInfo["Hokokutan_cd"]);
			ControlUtil.SetControlValue(Hokokutan_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Hokokutan_nm", lang), base.GetPageContext().FormInfo["Hokokutan_nm"]));
				DataFormatUtil.SetMustColorCaption(Hokokutan_nm_lbl, base.GetPageContext().FormInfo["Hokokutan_nm"]);
			ControlUtil.SetControlValue(Tentyotan_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Tentyotan_cd", lang), base.GetPageContext().FormInfo["Tentyotan_cd"]));
				DataFormatUtil.SetMustColorCaption(Tentyotan_cd_lbl, base.GetPageContext().FormInfo["Tentyotan_cd"]);
			ControlUtil.SetControlValue(Tentyotan_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Tentyotan_nm", lang), base.GetPageContext().FormInfo["Tentyotan_nm"]));
				DataFormatUtil.SetMustColorCaption(Tentyotan_nm_lbl, base.GetPageContext().FormInfo["Tentyotan_nm"]);
			ControlUtil.SetControlValue(Keisatsutodoke_ymd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Keisatsutodoke_ymd", lang), base.GetPageContext().FormInfo["Keisatsutodoke_ymd"]));
				DataFormatUtil.SetMustColorCaption(Keisatsutodoke_ymd_lbl, base.GetPageContext().FormInfo["Keisatsutodoke_ymd"]);
			ControlUtil.SetControlValue(Todokedesakikeisatsu_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Todokedesakikeisatsu_nm", lang), base.GetPageContext().FormInfo["Todokedesakikeisatsu_nm"]));
				DataFormatUtil.SetMustColorCaption(Todokedesakikeisatsu_nm_lbl, base.GetPageContext().FormInfo["Todokedesakikeisatsu_nm"]);
			ControlUtil.SetControlValue(Jyuri_no_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Jyuri_no", lang), base.GetPageContext().FormInfo["Jyuri_no"]));
				DataFormatUtil.SetMustColorCaption(Jyuri_no_lbl, base.GetPageContext().FormInfo["Jyuri_no"]);
			ControlUtil.SetControlValue(Gokeisinsei_su_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Gokeisinsei_su", lang), base.GetPageContext().FormInfo["Gokeisinsei_su"]));
				DataFormatUtil.SetMustColorCaption(Gokeisinsei_su_lbl, base.GetPageContext().FormInfo["Gokeisinsei_su"]);
			ControlUtil.SetControlValue(Gokeijyuri_su_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Gokeijyuri_su", lang), base.GetPageContext().FormInfo["Gokeijyuri_su"]));
				DataFormatUtil.SetMustColorCaption(Gokeijyuri_su_lbl, base.GetPageContext().FormInfo["Gokeijyuri_su"]);
			ControlUtil.SetControlValue(Gokeibaika_kin_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Gokeibaika_kin", lang), base.GetPageContext().FormInfo["Gokeibaika_kin"]));
				DataFormatUtil.SetMustColorCaption(Gokeibaika_kin_lbl, base.GetPageContext().FormInfo["Gokeibaika_kin"]);
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
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hassei_tm", lang), base.GetPageContext().FormInfo["M1hassei_tm"]);
				// M1.Columns[2].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hasseibasyo", lang), base.GetPageContext().FormInfo["M1hasseibasyo"]);
				// M1.Columns[3].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumon_cd", lang), base.GetPageContext().FormInfo["M1bumon_cd"]);
				// M1.Columns[4].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumonkana_nm", lang), base.GetPageContext().FormInfo["M1bumonkana_nm"]);
				// M1.Columns[5].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hinsyu_ryaku_nm", lang), base.GetPageContext().FormInfo["M1hinsyu_ryaku_nm"]);
				// M1.Columns[6].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hakkentan_cd", lang), base.GetPageContext().FormInfo["M1hakkentan_cd"]);
				// M1.Columns[7].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1btntanto_cd", lang), base.GetPageContext().FormInfo["M1btntanto_cd"]);
				// M1.Columns[8].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hakkentan_nm", lang), base.GetPageContext().FormInfo["M1hakkentan_nm"]);
				// M1.Columns[9].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1burando_nm", lang), base.GetPageContext().FormInfo["M1burando_nm"]);
				// M1.Columns[10].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1jisya_hbn", lang), base.GetPageContext().FormInfo["M1jisya_hbn"]);
				// M1.Columns[11].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hakkenjyokyo_kb", lang), base.GetPageContext().FormInfo["M1hakkenjyokyo_kb"]);
				// M1.Columns[12].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hakkenjyokyo_nm", lang), base.GetPageContext().FormInfo["M1hakkenjyokyo_nm"]);
				// M1.Columns[13].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1maker_hbn", lang), base.GetPageContext().FormInfo["M1maker_hbn"]);
				// M1.Columns[14].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syonmk", lang), base.GetPageContext().FormInfo["M1syonmk"]);
				// M1.Columns[15].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1iro_nm", lang), base.GetPageContext().FormInfo["M1iro_nm"]);
				// M1.Columns[16].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1size_nm", lang), base.GetPageContext().FormInfo["M1size_nm"]);
				// M1.Columns[17].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1scan_cd", lang), base.GetPageContext().FormInfo["M1scan_cd"]);
				// M1.Columns[18].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1sinsei_su", lang), base.GetPageContext().FormInfo["M1sinsei_su"]);
				// M1.Columns[19].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1jyuri_su", lang), base.GetPageContext().FormInfo["M1jyuri_su"]);
				// M1.Columns[20].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1baika_hon", lang), base.GetPageContext().FormInfo["M1baika_hon"]);
				// M1.Columns[21].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1baika_kin", lang), base.GetPageContext().FormInfo["M1baika_kin"]);
				// M1.Columns[22].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1sinsei_su_hdn", lang), base.GetPageContext().FormInfo["M1sinsei_su_hdn"]);
				// M1.Columns[23].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1jyuri_su_hdn", lang), base.GetPageContext().FormInfo["M1jyuri_su_hdn"]);
				// M1.Columns[24].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1baika_kin_hdn", lang), base.GetPageContext().FormInfo["M1baika_kin_hdn"]);
				// M1.Columns[25].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1selectorcheckbox", lang), base.GetPageContext().FormInfo["M1selectorcheckbox"]);
				// M1.Columns[26].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1entersyoriflg", lang), base.GetPageContext().FormInfo["M1entersyoriflg"]);
				// M1.Columns[27].HeaderText = 
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
				Windowtitle.InnerText = formResource.GetString("Tf070f02_Titlebar", lang);
				header.FormName = formResource.GetString("Tf070f02_FormCaption", lang);
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
