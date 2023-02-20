using com.xebio.bo.Tb050p01.Constant;
using com.xebio.bo.Tb050p01.Facade;
using com.xebio.bo.Tb050p01.Formvo;
using com.xebio.bo.Tm040p01.Constant;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.Model.Context;
using Common.Advanced.Resource;
using Common.Advanced.Web.Context;
using Common.Advanced.Web.Util;
using Common.Business.C01000.C01003;
using Common.Business.C01000.C01008;
using Common.Business.C01000.C01012;
using Common.Business.C01000.C01013;
using Common.Business.C01000.C01014;
using Common.Business.C01000.C01015;
using Common.Business.C01000.C01016;
using Common.Business.C01000.C01023;
using Common.Business.C01000.C01024;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.ReportUtil;
using Common.Conditions;
using Common.IntegrationMD.Constant;
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
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Tb050p01.Page
{
  /// <summary>
  /// Tb050f01のコードビハインドです。
  /// </summary>
  public partial class Tb050f01Page : StandardBasePage
	{

		#region メソッド

		#region ページデータをロードするメソッド
		/// <summary>
		/// Tb050f01画面データを作成する。
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
						pageContext.SetFormVO(new Tb050f01Form());
						switch(commandInfo.ActionMode)
						{
							case "ADD":
								break;
							case "INI": //メニューから遷移時
							case "DEL":
							case "UPD":
								IFacadeContext facadeContext =
									FacadeContextFactory.GetFacadeContext(pageContext);
								InitFacadeContext(facadeContext);
								new Tb050f01Facade().DoLoad(facadeContext);

								#region 共通ヘッダ処理

								// 一覧画面共通処理 ----------
								LoginInfoVO loginInfVO = LoginInfoUtil.GetLoginInfo();
								Tb050f01Form tb050f01Form = (Tb050f01Form)facadeContext.FormVO;
								ControlHeaderStoreCls.InitialSetHeaderStore<Tb050f01Form>(loginInfVO, tb050f01Form);
								// 一覧画面共通処理 ----------

								// アコーディオンなし
								AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_OPEN);

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


				// 単一ファイルダウンロード処理
				if (SessionInfoUtil.GetPgObject(base.GetPageContext().CommandInfo.ProgramId, Tb050p01Constant.SESSION_KEY_DOWNLOAD_INFO, Session) != null)
				{
					// ダウンロード情報取得
					DLConditionVO dlVO = SessionInfoUtil.GetPgObject(base.GetPageContext().CommandInfo.ProgramId, Tb050p01Constant.SESSION_KEY_DOWNLOAD_INFO, Session) as DLConditionVO;

					// セッション削除
					SessionInfoUtil.RemovePgObject(Tb050p01Constant.SESSION_KEY_DOWNLOAD_INFO, base.GetPageContext());

					base.DownloadPageStartUp(base.GetPageContext(), dlVO);
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
				new Tb050f01Facade().DoBTNPAGEINS_MINSX(facadeContext);
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

			LoginInfoVO loginInfVo = LoginInfoUtil.GetLoginInfo();

			// フォーカス設定用変数
			string focusItem = string.Empty;
			string focusMno = string.Empty;

			// 追加行のＭ１スキャンコードにフォーカス設定
			// 権限取得部品の戻り値が"TRUE"の場合
			if (CheckKengenCls.CheckKengen(loginInfVo))
			{
				focusItem = "M1tenpo_cd";
			}
			else
			{
				focusItem = "M1scan_cd";
			}
			focusMno = index;

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
			
			string focusMno = string.Empty;

			try
			{

				//アクションロジックを処理します
				IFacadeContext facadeContext = FacadeContextFactory.GetFacadeContext(pageContext);
				InitFacadeContext(facadeContext);
				// new Tb050f01Facade().DoBTNSIZSTK_FRM(facadeContext);
				
				if (Session[OpenTm040p01Cls.KEY_SIZE_SEARCH_RESULT] != null)
				{
					// セッションにサイズ検索戻り値が設定されている場合

					// セッションからファサードコンテキストに設定
					facadeContext.SetUserObject(Tb050p01Constant.DIC_SIZE_SEARCH_RESULT, Session[OpenTm040p01Cls.KEY_SIZE_SEARCH_RESULT]);

					new Tb050f01Facade().DoBTNSIZSTK_FRM(facadeContext);

					// セッションから削除
					//Session.Remove(OpenTm040p01Cls.KEY_SIZE_SEARCH_RESULT);

					// フォーカスインデックスを取得
					focusMno = (string)facadeContext.GetUserObject(Tb050p01Constant.DIC_FOCUS_INDEX);

					//アコーディオンを閉じた状態で表示
					AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_CLOSE);
				}
				else
				{
					#region サイズ検索画面起動パラメータ設定
					// フォームオブジェクト取得
					Tb050f01Form form = (Tb050f01Form)pageContext.GetFormVO();

					// 画面ID
					string formId = Tm040p01Constant.FORMID_TB050F01;

					// 現在行数
					int curRowCnt = 0;

					// 明細オブジェクト取得
					IDataList m1List = form.GetList("M1");

					for (int i = m1List.Count - 1; i >= 0; i--)
					{
						// 行オブジェクト取得
						Tb050f01M1Form m1Form = (Tb050f01M1Form)m1List[i];

						if (!string.IsNullOrEmpty(m1Form.M1scan_cd)
							|| !string.IsNullOrEmpty(m1Form.M1kensu)
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
					searchConditionVO.Tencd = BoSystemFormat.formatTenpoCd(form.Head_tenpo_cd);
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
			EndMethod(sender, e, this.GetType().Name + ".OnBTNSIZSTK_FRM");
			
			//画面遷移
			//base.Forward(pageContext, queryList);

			if (Session[OpenTm040p01Cls.KEY_SIZE_SEARCH_RESULT] != null)
			{
				// セッションにサイズ検索戻り値が設定されている場合

				// セッションから削除
				Session.Remove(OpenTm040p01Cls.KEY_SIZE_SEARCH_RESULT);

				// フォーカス設定
				// 権限取得部品の戻り値が"TRUE"の場合
				LoginInfoVO loginInfVo = LoginInfoUtil.GetLoginInfo();

				string focusItem = string.Empty;
				if (CheckKengenCls.CheckKengen(loginInfVo))
				{
					focusItem = "M1tenpo_cd";
				}
				else
				{
					focusItem = "M1scan_cd";
				}

				SetFocusCls.SetFocus(queryList, focusItem, focusMno);

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

			// 行削除最終行
			decimal lastRow = 0;

			try
			{

				//アクションロジックを処理します
				IFacadeContext facadeContext = FacadeContextFactory.GetFacadeContext(pageContext);
				InitFacadeContext(facadeContext);
				new Tb050f01Facade().DoBTNROWDEL_FRM(facadeContext);
				
				
				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
					base.SetError(pageContext);
					return;
				}

				// フォーカス行をコードビハインドに戻す
				lastRow = (decimal)facadeContext.GetUserObject(Tb050p01Constant.FCDUO_FOCUSROW);

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

			LoginInfoVO loginInfVo = LoginInfoUtil.GetLoginInfo();

			// フォーカス設定用変数
			string focusItem = string.Empty;
			string focusMno = string.Empty;

			// 削除行の次の行にフォーカス設定
			// 権限取得部品の戻り値が"TRUE"の場合
			if (CheckKengenCls.CheckKengen(loginInfVo))
			{
				focusItem = "M1tenpo_cd";
			}
			else
			{
				focusItem = "M1scan_cd";
			}
			focusMno = lastRow.ToString();

			// フォーカス設定
			queryList = SetFocusCls.SetFocus(queryList, focusItem, focusMno);

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

			string focusMno = string.Empty;

			try
			{

				//アクションロジックを処理します
				IFacadeContext facadeContext = FacadeContextFactory.GetFacadeContext(pageContext);
				InitFacadeContext(facadeContext);
				//new Tb050f01Facade().DoBTNCSV_TORIKOMI_FRM(facadeContext);

				// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
				if (Session[OpenTm050p01Cls.KEY_CSV_IMPORT_RESULT] != null)
				{
					// セッションにCSV取込戻り値が設定されている場合

					// セッションからファサードコンテキストに設定
					facadeContext.SetUserObject(Tb050p01Constant.DIC_CSV_IMPORT_RESULT, Session[OpenTm050p01Cls.KEY_CSV_IMPORT_RESULT]);

					new Tb050f01Facade().DoBTNCSV_TORIKOMI_FRM(facadeContext);

					focusMno = facadeContext.GetUserObject(Tb050p01Constant.DIC_FOCUS_INDEX).ToString();
				}
				else
				{
					#region CSV取込画面起動パラメータ設定
					// フォームオブジェクト取得
					Tb050f01Form form = (Tb050f01Form)pageContext.GetFormVO();

					// 画面ID
					string formId = Tb050p01Constant.FORMID_01;

					// 現在行数
					int curRowCnt = 0;
					// 明細オブジェクト取得
					IDataList m1List = form.GetList("M1");
					for (int i = m1List.Count - 1; i >= 0; i--)
					{
						// 行オブジェクト取得
						Tb050f01M1Form m1Form = (Tb050f01M1Form)m1List[i];

						if (
							(CheckKengenCls.CheckKengen(LoginInfoUtil.GetLoginInfo()) && !string.IsNullOrEmpty(m1Form.M1tenpo_cd))
							|| !string.IsNullOrEmpty(m1Form.M1scan_cd)
							|| !string.IsNullOrEmpty(m1Form.M1kensu)
							)
						{
							// いずれかの入力項目が入力されている場合
							curRowCnt = i + 1;
							break;
						}
					}

					// 最大行数
					int maxRowCnt = decimal.ToInt32(GetMaxCntCls.GetMaxCnt(formId.ToUpper(), "1"));

					// CSV名称
					string csvName = BoSystemConstant.CSVNM_MANUAL;

					// 後続処理にて押下させるボタンID
					string afterActBtn = this.Btncsv_torikomi.ID;

					// CSVチェック情報を設定
					CsvCheckInfoVO csvCheckInfoVO = new CsvCheckInfoVO();
					csvCheckInfoVO.Index_scan_cd = 1;                           // スキャンコードが格納されているインデックス
					// 項目情報
					CsvCheckItemInfoVO item = null;
					// 店舗コード
					item = new CsvCheckItemInfoVO();
					item.Item_id = "TENPO_CD";                                  // 項目ID
					item.Item_name = "店舗コード";                              // 項目名
					item.Required_flg = true;                                   // 必須チェックフラグ
					item.Type_kbn = CsvCheckItemInfoVO.TYPE_KBN_HALF_NUM;       // 属性チェック区分
					item.Max_length = 4;                                        // 最大桁数
					item.Mst_check_id = CsvCheckItemInfoVO.MST_CHECK_ID_TENPO;  // マスタチェックID
					csvCheckInfoVO.List_csv_item_info.Add(item);
					// スキャンコード
					item = new CsvCheckItemInfoVO();
					item.Item_id = "SCAN_CD";                                   // 項目ID
					item.Item_name = "スキャンコード";                          // 項目名
					item.Required_flg = true;                                   // 必須チェックフラグ
					item.Type_kbn = CsvCheckItemInfoVO.TYPE_KBN_HALF_NUM;       // 属性チェック区分
																				// 最大桁数チェックはIndex_scan_cdにより桁数チェックが行われるため不要
					item.Mst_check_id = CsvCheckItemInfoVO.MST_CHECK_ID_HATCHU; // マスタチェックID
					csvCheckInfoVO.List_csv_item_info.Add(item);
					// 数量
					item = new CsvCheckItemInfoVO();
					item.Item_id = "SURYO";                                     // 項目ID
					item.Item_name = "数量";                                    // 項目名
					item.Required_flg = true;                                   // 必須チェックフラグ
					item.Type_kbn = CsvCheckItemInfoVO.TYPE_KBN_NUMERIC;        // 属性チェック区分
					item.Max_length = 7;                                        // 最大桁数
					item.Zero_check_flg = true;                                 // ０チェックフラグ
					csvCheckInfoVO.List_csv_item_info.Add(item);

					// CSV取込画面用にセッションに設定
					Session[OpenTm050p01Cls.KEY_CSV_CHECK_INFO] = csvCheckInfoVO;
					// 取込結果反映用にDictionaryに設定
					form.Dictionary[Tb050p01Constant.DIC_CSV_CHECK_INFO] = csvCheckInfoVO;
					#endregion

					// CSV取込画面起動
					OpenTm050p01Cls.OpenTm050p01(Page, formId, curRowCnt, maxRowCnt, csvName, afterActBtn);
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
			EndMethod(sender, e, this.GetType().Name + ".OnBTNCSV_TORIKOMI_FRM");
			
			//画面遷移
			//base.Forward(pageContext, queryList);

			if (Session[OpenTm050p01Cls.KEY_CSV_IMPORT_RESULT] != null)
			{
				// セッションにCSV取込戻り値が設定されている場合

				// セッションから削除
				Session.Remove(OpenTm050p01Cls.KEY_CSV_IMPORT_RESULT);

				// フォーカス設定
				// 権限取得部品の戻り値が"TRUE"の場合
				LoginInfoVO loginInfVo = LoginInfoUtil.GetLoginInfo();

				string focusItem = string.Empty;
				if (CheckKengenCls.CheckKengen(loginInfVo))
				{
					focusItem = "M1tenpo_cd";
				}
				else
				{
					focusItem = "M1scan_cd";
				}

				SetFocusCls.SetFocus(queryList, focusItem, focusMno);

				//画面遷移
				base.Forward(pageContext, queryList);
			}
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
				new Tb050f01Facade().DoPGR_PGN(facadeContext, pageindex);
				
				
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
				new Tb050f01Facade().DoBTNENTER_FRM(facadeContext);
				
				
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

				#region 出力PDFファイルダウンロード設定

				// PDFファイル名取得
				string pdfNm = facadeContext.GetUserObject(Tb050p01Constant.FCDUO_RRT_FLNM) as string;

				// サーバファイルフルパス
				string serverPath = string.Format("{0}{1}{2}",
												FilePathManager.GetOutFilePath(Tb050p01Constant.PGID),
												Path.DirectorySeparatorChar,
												pdfNm
												);
				// クライアントファイル名
				string clientNm = string.Format("{0}.{1}",
												BoSystemReport.CreateFileName(BoSystemConstant.REPORTNM_MANUALSIIREDENPYO, 2),
												BoSystemConstant.RPT_PDF_EXTENSION
												);

				// 単一ダウンロード情報
				DLConditionVO dlvo = new DLConditionVO();

				// ダウンロード用VOに値を設定
				dlvo.setSingleFileDownloadCondition(serverPath, clientNm);

				// 単一ダウンロード用にVOをセッションにセット
				SessionInfoUtil.SetPgObject(pageContext.CommandInfo.ProgramId, Tb050p01Constant.SESSION_KEY_DOWNLOAD_INFO, dlvo, Session);

				#endregion

				//共通アクション
				base.DoCommonAction();
			}
			catch (System.Exception ex)
			{
				ThrowException(ex, pageContext);
				return;
			}
			
			
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
						Tb050f01Form tb050f01Form = (Tb050f01Form)pageContext.GetFormVO();

						//明細ページ情報を表示する
						ShowListPageInfo(tb050f01Form);
			
						//明細部データを表示する
						RenderList(tb050f01Form, pageContext.FormInfo, formResource, lang);

						//カード部データを表示する
						RenderCard(tb050f01Form, pageContext.FormInfo, formResource, lang);
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
		/// <param name="tb050f01Form">画面FormVO</param>
		private void ShowListPageInfo(Tb050f01Form tb050f01Form)
		{
			//M1明細ページ情報を表示する。
			ShowM1ListPageInfo(tb050f01Form.GetList("M1"));

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
		/// <param name="tb050f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderList(
			Tb050f01Form tb050f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//画面のM1明細部データを設定する。
			RenderM1List(tb050f01Form, formInfo, formResource, lang);
			//M1明細部のページャーにページ情報を設定する。
			RenderM1Pager(tb050f01Form);
			
		}
		#endregion

		#region M1明細データを表示する
		/// <summary>
		/// M1明細データを表示する。
		/// </summary>
		/// <param name="tb050f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderM1List(
			Tb050f01Form tb050f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//M1明細部データソースを設定する。
			M1.DataSource = tb050f01Form.GetPageViewList("M1");
			M1.DataBind();

			//M1明細部データをフォーマットする。
			IList m1DataList = (IList)M1.DataSource;
			
			for (int index = 0; index < M1.Items.Count; index++)
			{
				Tb050f01M1Form tb050f01M1Form = (Tb050f01M1Form)m1DataList[index];
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1rowno"),
					DataFormatUtil.GetFormatItem(tb050f01M1Form.M1rowno,formInfo["M1rowno"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1tenpo_cd"),
					DataFormatUtil.GetFormatItem(tb050f01M1Form.M1tenpo_cd,formInfo["M1tenpo_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1tenpo_nm"),
					DataFormatUtil.GetFormatItem(tb050f01M1Form.M1tenpo_nm,formInfo["M1tenpo_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1bumon_cd"),
					DataFormatUtil.GetFormatItem(tb050f01M1Form.M1bumon_cd,formInfo["M1bumon_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1bumonkana_nm"),
					DataFormatUtil.GetFormatItem(tb050f01M1Form.M1bumonkana_nm,formInfo["M1bumonkana_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1hinsyu_ryaku_nm"),
					DataFormatUtil.GetFormatItem(tb050f01M1Form.M1hinsyu_ryaku_nm,formInfo["M1hinsyu_ryaku_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1burando_nm"),
					DataFormatUtil.GetFormatItem(tb050f01M1Form.M1burando_nm,formInfo["M1burando_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1jisya_hbn"),
					DataFormatUtil.GetFormatItem(tb050f01M1Form.M1jisya_hbn,formInfo["M1jisya_hbn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1maker_hbn"),
					DataFormatUtil.GetFormatItem(tb050f01M1Form.M1maker_hbn,formInfo["M1maker_hbn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1syonmk"),
					DataFormatUtil.GetFormatItem(tb050f01M1Form.M1syonmk,formInfo["M1syonmk"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1iro_nm"),
					DataFormatUtil.GetFormatItem(tb050f01M1Form.M1iro_nm,formInfo["M1iro_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1size_nm"),
					DataFormatUtil.GetFormatItem(tb050f01M1Form.M1size_nm,formInfo["M1size_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1scan_cd"),
					DataFormatUtil.GetFormatItem(tb050f01M1Form.M1scan_cd,formInfo["M1scan_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1kensu"),
					DataFormatUtil.GetFormatItem(tb050f01M1Form.M1kensu,formInfo["M1kensu"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1gen_tnk"),
					DataFormatUtil.GetFormatItem(tb050f01M1Form.M1gen_tnk,formInfo["M1gen_tnk"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1genka_kin"),
					DataFormatUtil.GetFormatItem(tb050f01M1Form.M1genka_kin,formInfo["M1genka_kin"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1kensu_hdn"),
					DataFormatUtil.GetFormatItem(tb050f01M1Form.M1kensu_hdn,formInfo["M1kensu_hdn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1genka_kin_hdn"),
					DataFormatUtil.GetFormatItem(tb050f01M1Form.M1genka_kin_hdn,formInfo["M1genka_kin_hdn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1selectorcheckbox"),
					DataFormatUtil.GetFormatItem(tb050f01M1Form.M1selectorcheckbox,formInfo["M1selectorcheckbox"]));
				((System.Web.UI.WebControls.CheckBox)M1.Items[index].FindControl("M1selectorcheckbox")).Text =
					formResource.GetString("M1selectorcheckbox", lang);
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1entersyoriflg"),
					DataFormatUtil.GetFormatItem(tb050f01M1Form.M1entersyoriflg,formInfo["M1entersyoriflg"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1dtlirokbn"),
					DataFormatUtil.GetFormatItem(tb050f01M1Form.M1dtlirokbn,formInfo["M1dtlirokbn"]));

				if(!base.CheckUseSelfCustomize()){
					((System.Web.UI.HtmlControls.HtmlInputButton)M1.Items[index].FindControl("M1btntenpocd")).Value =
						formResource.GetString("M1btntenpocd", lang);
						
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
				// (M1.HeaderRow.FindControl("M1btntenpocd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1btntenpocd", lang), base.GetPageContext().FormInfo["M1btntenpocd"]);
				// (M1.HeaderRow.FindControl("M1tenpo_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tenpo_nm", lang), base.GetPageContext().FormInfo["M1tenpo_nm"]);
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
				// (M1.HeaderRow.FindControl("M1iro_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1iro_nm", lang), base.GetPageContext().FormInfo["M1iro_nm"]);
				// (M1.HeaderRow.FindControl("M1size_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1size_nm", lang), base.GetPageContext().FormInfo["M1size_nm"]);
				// (M1.HeaderRow.FindControl("M1scan_cd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1scan_cd", lang), base.GetPageContext().FormInfo["M1scan_cd"]);
				// (M1.HeaderRow.FindControl("M1kensu") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kensu", lang), base.GetPageContext().FormInfo["M1kensu"]);
				// (M1.HeaderRow.FindControl("M1gen_tnk") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1gen_tnk", lang), base.GetPageContext().FormInfo["M1gen_tnk"]);
				// (M1.HeaderRow.FindControl("M1genka_kin") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1genka_kin", lang), base.GetPageContext().FormInfo["M1genka_kin"]);
				// (M1.HeaderRow.FindControl("M1kensu_hdn") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kensu_hdn", lang), base.GetPageContext().FormInfo["M1kensu_hdn"]);
				// (M1.HeaderRow.FindControl("M1genka_kin_hdn") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1genka_kin_hdn", lang), base.GetPageContext().FormInfo["M1genka_kin_hdn"]);
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
		/// <param name="tb050f01Form">画面FormVO</param>
		private void RenderM1Pager(Tb050f01Form tb050f01Form)
		{
			Pgr.VirtualItemCount = tb050f01Form.GetList("M1").RecordCount;
			Pgr.CurrentPageIndex = tb050f01Form.GetList("M1").PageNo - 1;
			Pgr.PageSize = tb050f01Form.GetList("M1").DispRow;
		}
		#endregion
		#endregion

		#region カードデータを表示する
		/// <summary>
		/// カードデータを表示する
		/// </summary>
		/// <param name="tb050f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderCard(
			Tb050f01Form tb050f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			
			ControlUtil.SetControlValue(Head_tenpo_cd,
				DataFormatUtil.GetFormatItem(tb050f01Form.Head_tenpo_cd,formInfo["Head_tenpo_cd"]));
			ControlUtil.SetControlValue(Head_tenpo_nm,
				DataFormatUtil.GetFormatItem(tb050f01Form.Head_tenpo_nm,formInfo["Head_tenpo_nm"]));
			ControlUtil.SetControlValue(Biko_kb,
				DataFormatUtil.GetFormatItem(tb050f01Form.Biko_kb,formInfo["Biko_kb"]));
			ControlUtil.SetControlValue(Biko1,
				DataFormatUtil.GetFormatItem(tb050f01Form.Biko1,formInfo["Biko1"]));
			ControlUtil.SetControlValue(Biko2,
				DataFormatUtil.GetFormatItem(tb050f01Form.Biko2,formInfo["Biko2"]));
			ControlUtil.SetControlValue(Gokei_kensu,
				DataFormatUtil.GetFormatItem(tb050f01Form.Gokei_kensu,formInfo["Gokei_kensu"]));
			ControlUtil.SetControlValue(Genka_kin_gokei,
				DataFormatUtil.GetFormatItem(tb050f01Form.Genka_kin_gokei,formInfo["Genka_kin_gokei"]));

			if(!base.CheckUseSelfCustomize()){
				Btnheadtenpocd.Value = base.FormResourceGetString(formResource, "Btnheadtenpocd", lang);
				Btnpageins.Value = base.FormResourceGetString(formResource, "Btnpageins", lang);
				Btnsizstk.Value = base.FormResourceGetString(formResource, "Btnsizstk", lang);
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
			// UIScreenController controller = new UIScreenController((Tb050f01Form)base.GetPageContext().GetFormVO());
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

			Tb050f01Form formVo = (Tb050f01Form)base.GetPageContext().GetFormVO();
			IList m1DataList = formVo.GetPageViewList("M1");

			// 備考区分が２の場合は備考②を活性化する
			if (ConditionBiko_kbn.VALUE_BIKO_KBN2.Equals(formVo.Biko_kb))
			{
				ControlCls.Disable(Biko2, false);
			}
			// それ以外は非活性化
			else
			{
				ControlCls.Disable(Biko2, true);
			}

			// 権限取得部品の戻り値が"FALSE"の場合
			if (!CheckKengenCls.CheckKengen(loginInfVO))
			{
				// CSV取込ボタンを非表示とする
				ControlCls.Visible(Btncsv_torikomiArea, false);

				// 明細部チェックボックスの制御
				for (int index = 0; index < M1.Items.Count; index++)
				{
					// [Ｍ１店舗コード]を非活性とする
					ControlCls.Disable((TextBox)M1.Items[index].FindControl("M1tenpo_cd"), true);
					// [Ｍ１店舗コードボタン]を非活性とする
					ControlCls.Disable((HtmlInputButton)M1.Items[index].FindControl("M1btntenpocd"), true);
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
			ControlUtil.SetControlValue(Biko_kb_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Biko_kb", lang), base.GetPageContext().FormInfo["Biko_kb"]));
				DataFormatUtil.SetMustColorCaption(Biko_kb_lbl, base.GetPageContext().FormInfo["Biko_kb"]);
			ControlUtil.SetControlValue(Biko1_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Biko1", lang), base.GetPageContext().FormInfo["Biko1"]));
				DataFormatUtil.SetMustColorCaption(Biko1_lbl, base.GetPageContext().FormInfo["Biko1"]);
			ControlUtil.SetControlValue(Biko2_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Biko2", lang), base.GetPageContext().FormInfo["Biko2"]));
				DataFormatUtil.SetMustColorCaption(Biko2_lbl, base.GetPageContext().FormInfo["Biko2"]);
			ControlUtil.SetControlValue(Gokei_kensu_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Gokei_kensu", lang), base.GetPageContext().FormInfo["Gokei_kensu"]));
				DataFormatUtil.SetMustColorCaption(Gokei_kensu_lbl, base.GetPageContext().FormInfo["Gokei_kensu"]);
			ControlUtil.SetControlValue(Genka_kin_gokei_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Genka_kin_gokei", lang), base.GetPageContext().FormInfo["Genka_kin_gokei"]));
				DataFormatUtil.SetMustColorCaption(Genka_kin_gokei_lbl, base.GetPageContext().FormInfo["Genka_kin_gokei"]);
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
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1btntenpocd", lang), base.GetPageContext().FormInfo["M1btntenpocd"]);
				// M1.Columns[3].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tenpo_nm", lang), base.GetPageContext().FormInfo["M1tenpo_nm"]);
				// M1.Columns[4].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumon_cd", lang), base.GetPageContext().FormInfo["M1bumon_cd"]);
				// M1.Columns[5].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumonkana_nm", lang), base.GetPageContext().FormInfo["M1bumonkana_nm"]);
				// M1.Columns[6].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hinsyu_ryaku_nm", lang), base.GetPageContext().FormInfo["M1hinsyu_ryaku_nm"]);
				// M1.Columns[7].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1burando_nm", lang), base.GetPageContext().FormInfo["M1burando_nm"]);
				// M1.Columns[8].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1jisya_hbn", lang), base.GetPageContext().FormInfo["M1jisya_hbn"]);
				// M1.Columns[9].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1maker_hbn", lang), base.GetPageContext().FormInfo["M1maker_hbn"]);
				// M1.Columns[10].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syonmk", lang), base.GetPageContext().FormInfo["M1syonmk"]);
				// M1.Columns[11].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1iro_nm", lang), base.GetPageContext().FormInfo["M1iro_nm"]);
				// M1.Columns[12].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1size_nm", lang), base.GetPageContext().FormInfo["M1size_nm"]);
				// M1.Columns[13].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1scan_cd", lang), base.GetPageContext().FormInfo["M1scan_cd"]);
				// M1.Columns[14].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kensu", lang), base.GetPageContext().FormInfo["M1kensu"]);
				// M1.Columns[15].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1gen_tnk", lang), base.GetPageContext().FormInfo["M1gen_tnk"]);
				// M1.Columns[16].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1genka_kin", lang), base.GetPageContext().FormInfo["M1genka_kin"]);
				// M1.Columns[17].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kensu_hdn", lang), base.GetPageContext().FormInfo["M1kensu_hdn"]);
				// M1.Columns[18].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1genka_kin_hdn", lang), base.GetPageContext().FormInfo["M1genka_kin_hdn"]);
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
				Windowtitle.InnerText = formResource.GetString("Tb050f01_Titlebar", lang);
				header.FormName = formResource.GetString("Tb050f01_FormCaption", lang);
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
