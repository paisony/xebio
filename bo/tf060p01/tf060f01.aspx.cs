using com.xebio.bo.Tf060p01.Constant;
using com.xebio.bo.Tf060p01.Facade;
using com.xebio.bo.Tf060p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.Model.Context;
using Common.Advanced.Resource;
using Common.Advanced.Web.Context;
using Common.Advanced.Web.Util;
using Common.Business.C01000.C01013;
using Common.Business.C01000.C01014;
using Common.Business.C01000.C01015;
using Common.Business.C01000.C01024;
using Common.Business.C99999.Constant;
using Common.IntegrationMD.Util;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Util;
using System;
using System.Collections;
using System.Collections.Specialized;

namespace com.xebio.bo.Tf060p01.Page
{
  /// <summary>
  /// Tf060f01のコードビハインドです。
  /// </summary>
  public partial class Tf060f01Page : StandardBasePage
	{

		#region メソッド

		#region ページデータをロードするメソッド
		/// <summary>
		/// Tf060f01画面データを作成する。
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
						pageContext.SetFormVO(new Tf060f01Form());
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
								new Tf060f01Facade().DoLoad(facadeContext);

								#region 共通ヘッダ処理

								// 一覧画面共通処理 ----------
								LoginInfoVO loginInfVO = LoginInfoUtil.GetLoginInfo();
								Tf060f01Form tf060f01Form = (Tf060f01Form)facadeContext.FormVO;
								ControlHeaderStoreCls.InitialSetHeaderStore<Tf060f01Form>(loginInfVO, tf060f01Form);
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
				Page.ClientScript.RegisterStartupScript(typeof(string), "initialDetail", ControlCls.InitialDetail(pageContext));
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
				new Tf060f01Facade().DoBTNSEARCH_FRM(facadeContext);
				
				
				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
					// アコーディオンなし
					AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_NONE);
					commandInfo.ActionMode = "INI";

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

			// フォーカス設定用変数
			string focusItem = string.Empty;
			string focusMno = string.Empty;

			// 表示明細先頭の伝票番号にフォーカス設定
			focusItem = "Tukibetu_bumon1_yosan_kin";
			// 1行目にフォーカス設定
			focusMno = "0";

			// フォーカス設定
			SetFocusCls.SetFocus(queryList, focusItem, focusMno);

			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNSEARCH_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Btncsv_torikomi(CSV取込))
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btncsv_torikomi(CSV取込))
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

			try
			{

				//アクションロジックを処理します
				IFacadeContext facadeContext = FacadeContextFactory.GetFacadeContext(pageContext);
				InitFacadeContext(facadeContext);

				if (Session[OpenTm050p01Cls.KEY_CSV_IMPORT_RESULT] != null)
				{
					// セッションにCSV取込戻り値が設定されている場合

					// セッションからファサードコンテキストに設定
					facadeContext.SetUserObject(Tf060p01Constant.DIC_CSV_IMPORT_RESULT, Session[OpenTm050p01Cls.KEY_CSV_IMPORT_RESULT]);

					new Tf060f01Facade().DoBTNCSV_TORIKOMI_FRM(facadeContext);
				}
				else
				{
					#region CSV取込画面起動パラメータ設定
					// フォームオブジェクト取得
					Tf060f01Form form = (Tf060f01Form)pageContext.GetFormVO();

					// 画面ID
					string formId = Tf060p01Constant.FORMID_01.ToUpper();

					// 現在行数
					int curRowCnt = 0;
					// 最大行数
					int maxRowCnt = 31;

					// CSV名称
					string csvName = BoSystemConstant.CSVNM_YOSAN_TOROKU;

					// 後続処理にて押下させるボタンID
					string afterActBtn = this.Btncsv_torikomi.ID;

					// CSVチェック情報を設定
					CsvCheckInfoVO csvCheckInfoVO = new CsvCheckInfoVO();

					// 年月
					csvCheckInfoVO.Monthly = (string)form.Dictionary[Tf060p01Constant.DIC_YYYYMM];

					// 日が格納されているインデックス
					csvCheckInfoVO.Index_day = 0;

					// 項目情報
					CsvCheckItemInfoVO item = null;
					// 日
					item = new CsvCheckItemInfoVO();
					item.Item_id = "DAY";										// 項目ID
					item.Item_name = "日";										// 項目名
					item.Required_flg = true;                                   // 必須チェックフラグ
					item.Type_kbn = CsvCheckItemInfoVO.TYPE_KBN_HALF_NUM;       // 属性チェック区分
					item.Max_length = 2;                                        // 最大桁数
					csvCheckInfoVO.List_csv_item_info.Add(item);
					// 部門１
					item = new CsvCheckItemInfoVO();
					item.Item_id = "BUMON1";									// 項目ID
					item.Item_name = "部門１";									// 項目名
					item.Required_flg = false;                                  // 必須チェックフラグ
					item.Type_kbn = CsvCheckItemInfoVO.TYPE_KBN_NUMERIC;		// 属性チェック区分
					item.Max_length = 6;                                        // 最大桁数
					item.Zero_check_flg = false;                                // ０チェックフラグ
					csvCheckInfoVO.List_csv_item_info.Add(item);
					// 部門２
					item = new CsvCheckItemInfoVO();
					item.Item_id = "BUMON2";									// 項目ID
					item.Item_name = "部門２";									// 項目名
					item.Required_flg = false;                                  // 必須チェックフラグ
					item.Type_kbn = CsvCheckItemInfoVO.TYPE_KBN_NUMERIC;		// 属性チェック区分
					item.Max_length = 6;                                        // 最大桁数
					item.Zero_check_flg = false;                                // ０チェックフラグ
					csvCheckInfoVO.List_csv_item_info.Add(item);
					// 部門３
					item = new CsvCheckItemInfoVO();
					item.Item_id = "BUMON3";									// 項目ID
					item.Item_name = "部門３";									// 項目名
					item.Required_flg = false;                                  // 必須チェックフラグ
					item.Type_kbn = CsvCheckItemInfoVO.TYPE_KBN_NUMERIC;		// 属性チェック区分
					item.Max_length = 6;                                        // 最大桁数
					item.Zero_check_flg = false;                                // ０チェックフラグ
					csvCheckInfoVO.List_csv_item_info.Add(item);
					// 部門４
					item = new CsvCheckItemInfoVO();
					item.Item_id = "BUMON4";									// 項目ID
					item.Item_name = "部門４";									// 項目名
					item.Required_flg = false;                                  // 必須チェックフラグ
					item.Type_kbn = CsvCheckItemInfoVO.TYPE_KBN_NUMERIC;		// 属性チェック区分
					item.Max_length = 6;                                        // 最大桁数
					item.Zero_check_flg = false;                                // ０チェックフラグ
					csvCheckInfoVO.List_csv_item_info.Add(item);
					// 部門５
					item = new CsvCheckItemInfoVO();
					item.Item_id = "BUMON5";									// 項目ID
					item.Item_name = "部門５";									// 項目名
					item.Required_flg = false;                                  // 必須チェックフラグ
					item.Type_kbn = CsvCheckItemInfoVO.TYPE_KBN_NUMERIC;		// 属性チェック区分
					item.Max_length = 6;                                        // 最大桁数
					item.Zero_check_flg = false;                                // ０チェックフラグ
					csvCheckInfoVO.List_csv_item_info.Add(item);

					// CSV取込画面用にセッションに設定
					Session[OpenTm050p01Cls.KEY_CSV_CHECK_INFO] = csvCheckInfoVO;
					// 取込結果反映用にDictionaryに設定
					form.Dictionary[Tf060p01Constant.DIC_CSV_CHECK_INFO] = csvCheckInfoVO;
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
			EndMethod(sender, e, this.GetType().Name + ".OnBTNCSV_TORIKOMI_FRM");
			
			//画面遷移
			//base.Forward(pageContext, queryList);

			if (Session[OpenTm050p01Cls.KEY_CSV_IMPORT_RESULT] != null)
			{
				// セッションにCSV取込戻り値が設定されている場合

				// セッションから削除
				Session.Remove(OpenTm050p01Cls.KEY_CSV_IMPORT_RESULT);

				SetFocusCls.SetFocus(queryList, "Tukibetu_bumon1_yosan_kin");

				//画面遷移
				base.Forward(pageContext, queryList);
			}
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
				new Tf060f01Facade().DoBTNENTER_FRM(facadeContext);
				
				
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
					//if (!MessageDisplayUtil.HasError(pageContext))
					//{
						string lang = WebSettingsUtil.GetLangSettingFromSession(pageContext.Session);
						FormResource formResource =
							ResourceFactory.GetFormResource(pageContext.CommandInfo.FormId);
			
						//標題をセットする
						SetCaption(formResource, lang);

						//FormVOを取得する
						Tf060f01Form tf060f01Form = (Tf060f01Form)pageContext.GetFormVO();

						//明細ページ情報を表示する
						ShowListPageInfo(tf060f01Form);
			
						//明細部データを表示する
						RenderList(tf060f01Form, pageContext.FormInfo, formResource, lang);

						//カード部データを表示する
						RenderCard(tf060f01Form, pageContext.FormInfo, formResource, lang);
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
		/// <param name="tf060f01Form">画面FormVO</param>
		private void ShowListPageInfo(Tf060f01Form tf060f01Form)
		{
			//M1明細ページ情報を表示する。
			ShowM1ListPageInfo(tf060f01Form.GetList("M1"));

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
		/// <param name="tf060f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderList(
			Tf060f01Form tf060f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//画面のM1明細部データを設定する。
			RenderM1List(tf060f01Form, formInfo, formResource, lang);
			
		}
		#endregion

		#region M1明細データを表示する
		/// <summary>
		/// M1明細データを表示する。
		/// </summary>
		/// <param name="tf060f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderM1List(
			Tf060f01Form tf060f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//M1明細部データソースを設定する。
			M1.DataSource = tf060f01Form.GetPageViewList("M1");
			M1.DataBind();

			//M1明細部データをフォーマットする。
			IList m1DataList = (IList)M1.DataSource;
			
			for (int index = 0; index < M1.Items.Count; index++)
			{
				Tf060f01M1Form tf060f01M1Form = (Tf060f01M1Form)m1DataList[index];
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1getunai_hiduke"),
					DataFormatUtil.GetFormatItem(tf060f01M1Form.M1getunai_hiduke,formInfo["M1getunai_hiduke"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1yobi"),
					DataFormatUtil.GetFormatItem(tf060f01M1Form.M1yobi,formInfo["M1yobi"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1bumon1_yosan_kin"),
					DataFormatUtil.GetFormatItem(tf060f01M1Form.M1bumon1_yosan_kin,formInfo["M1bumon1_yosan_kin"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1bumon2_yosan_kin"),
					DataFormatUtil.GetFormatItem(tf060f01M1Form.M1bumon2_yosan_kin,formInfo["M1bumon2_yosan_kin"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1bumon3_yosan_kin"),
					DataFormatUtil.GetFormatItem(tf060f01M1Form.M1bumon3_yosan_kin,formInfo["M1bumon3_yosan_kin"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1bumon4_yosan_kin"),
					DataFormatUtil.GetFormatItem(tf060f01M1Form.M1bumon4_yosan_kin,formInfo["M1bumon4_yosan_kin"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1bumon5_yosan_kin"),
					DataFormatUtil.GetFormatItem(tf060f01M1Form.M1bumon5_yosan_kin,formInfo["M1bumon5_yosan_kin"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1hibetu_yosan_kin"),
					DataFormatUtil.GetFormatItem(tf060f01M1Form.M1hibetu_yosan_kin,formInfo["M1hibetu_yosan_kin"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1bumon1_yosan_kin_hdn"),
					DataFormatUtil.GetFormatItem(tf060f01M1Form.M1bumon1_yosan_kin_hdn,formInfo["M1bumon1_yosan_kin_hdn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1bumon2_yosan_kin_hdn"),
					DataFormatUtil.GetFormatItem(tf060f01M1Form.M1bumon2_yosan_kin_hdn,formInfo["M1bumon2_yosan_kin_hdn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1bumon3_yosan_kin_hdn"),
					DataFormatUtil.GetFormatItem(tf060f01M1Form.M1bumon3_yosan_kin_hdn,formInfo["M1bumon3_yosan_kin_hdn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1bumon4_yosan_kin_hdn"),
					DataFormatUtil.GetFormatItem(tf060f01M1Form.M1bumon4_yosan_kin_hdn,formInfo["M1bumon4_yosan_kin_hdn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1bumon5_yosan_kin_hdn"),
					DataFormatUtil.GetFormatItem(tf060f01M1Form.M1bumon5_yosan_kin_hdn,formInfo["M1bumon5_yosan_kin_hdn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1selectorcheckbox"),
					DataFormatUtil.GetFormatItem(tf060f01M1Form.M1selectorcheckbox,formInfo["M1selectorcheckbox"]));
				((System.Web.UI.WebControls.CheckBox)M1.Items[index].FindControl("M1selectorcheckbox")).Text =
					formResource.GetString("M1selectorcheckbox", lang);
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1entersyoriflg"),
					DataFormatUtil.GetFormatItem(tf060f01M1Form.M1entersyoriflg,formInfo["M1entersyoriflg"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1dtlirokbn"),
					DataFormatUtil.GetFormatItem(tf060f01M1Form.M1dtlirokbn,formInfo["M1dtlirokbn"]));

				if(!base.CheckUseSelfCustomize()){
				}
			}
			//M1明細部標題を設定する。
				// 多段明細を有効にする場合は、コメントアウトを外して、必要な情報を追加・修正してください。
				// 左辺は多段明細ヘッダ部のラベル情報を設定してください。
				// 右辺はカード部で定義した多段明細部の標題を設定してください。
				// if (M1.Items.Count > 0)
				// {
				// (M1.HeaderRow.FindControl("M1getunai_hiduke") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1getunai_hiduke", lang), base.GetPageContext().FormInfo["M1getunai_hiduke"]);
				// (M1.HeaderRow.FindControl("M1yobi") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1yobi", lang), base.GetPageContext().FormInfo["M1yobi"]);
				// (M1.HeaderRow.FindControl("M1bumon1_yosan_kin") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumon1_yosan_kin", lang), base.GetPageContext().FormInfo["M1bumon1_yosan_kin"]);
				// (M1.HeaderRow.FindControl("M1bumon2_yosan_kin") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumon2_yosan_kin", lang), base.GetPageContext().FormInfo["M1bumon2_yosan_kin"]);
				// (M1.HeaderRow.FindControl("M1bumon3_yosan_kin") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumon3_yosan_kin", lang), base.GetPageContext().FormInfo["M1bumon3_yosan_kin"]);
				// (M1.HeaderRow.FindControl("M1bumon4_yosan_kin") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumon4_yosan_kin", lang), base.GetPageContext().FormInfo["M1bumon4_yosan_kin"]);
				// (M1.HeaderRow.FindControl("M1bumon5_yosan_kin") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumon5_yosan_kin", lang), base.GetPageContext().FormInfo["M1bumon5_yosan_kin"]);
				// (M1.HeaderRow.FindControl("M1hibetu_yosan_kin") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hibetu_yosan_kin", lang), base.GetPageContext().FormInfo["M1hibetu_yosan_kin"]);
				// (M1.HeaderRow.FindControl("M1bumon1_yosan_kin_hdn") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumon1_yosan_kin_hdn", lang), base.GetPageContext().FormInfo["M1bumon1_yosan_kin_hdn"]);
				// (M1.HeaderRow.FindControl("M1bumon2_yosan_kin_hdn") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumon2_yosan_kin_hdn", lang), base.GetPageContext().FormInfo["M1bumon2_yosan_kin_hdn"]);
				// (M1.HeaderRow.FindControl("M1bumon3_yosan_kin_hdn") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumon3_yosan_kin_hdn", lang), base.GetPageContext().FormInfo["M1bumon3_yosan_kin_hdn"]);
				// (M1.HeaderRow.FindControl("M1bumon4_yosan_kin_hdn") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumon4_yosan_kin_hdn", lang), base.GetPageContext().FormInfo["M1bumon4_yosan_kin_hdn"]);
				// (M1.HeaderRow.FindControl("M1bumon5_yosan_kin_hdn") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumon5_yosan_kin_hdn", lang), base.GetPageContext().FormInfo["M1bumon5_yosan_kin_hdn"]);
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
		/// <param name="tf060f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderCard(
			Tf060f01Form tf060f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			
			ControlUtil.SetControlValue(Head_tenpo_cd,
				DataFormatUtil.GetFormatItem(tf060f01Form.Head_tenpo_cd,formInfo["Head_tenpo_cd"]));
			ControlUtil.SetControlValue(Head_tenpo_nm,
				DataFormatUtil.GetFormatItem(tf060f01Form.Head_tenpo_nm,formInfo["Head_tenpo_nm"]));
			ControlUtil.SetControlValue(Getudo,
				DataFormatUtil.GetFormatItem(tf060f01Form.Getudo,formInfo["Getudo"]));
			ControlUtil.SetControlValue(Tukibetu_bumon1_yosan_kin,
				DataFormatUtil.GetFormatItem(tf060f01Form.Tukibetu_bumon1_yosan_kin,formInfo["Tukibetu_bumon1_yosan_kin"]));
			ControlUtil.SetControlValue(Tukibetu_bumon2_yosan_kin,
				DataFormatUtil.GetFormatItem(tf060f01Form.Tukibetu_bumon2_yosan_kin,formInfo["Tukibetu_bumon2_yosan_kin"]));
			ControlUtil.SetControlValue(Tukibetu_bumon3_yosan_kin,
				DataFormatUtil.GetFormatItem(tf060f01Form.Tukibetu_bumon3_yosan_kin,formInfo["Tukibetu_bumon3_yosan_kin"]));
			ControlUtil.SetControlValue(Tukibetu_bumon4_yosan_kin,
				DataFormatUtil.GetFormatItem(tf060f01Form.Tukibetu_bumon4_yosan_kin,formInfo["Tukibetu_bumon4_yosan_kin"]));
			ControlUtil.SetControlValue(Tukibetu_bumon5_yosan_kin,
				DataFormatUtil.GetFormatItem(tf060f01Form.Tukibetu_bumon5_yosan_kin,formInfo["Tukibetu_bumon5_yosan_kin"]));
			ControlUtil.SetControlValue(Tukibetu_yosan_kin_gokei,
				DataFormatUtil.GetFormatItem(tf060f01Form.Tukibetu_yosan_kin_gokei,formInfo["Tukibetu_yosan_kin_gokei"]));
			ControlUtil.SetControlValue(Bumon1_yosangokei_kin,
				DataFormatUtil.GetFormatItem(tf060f01Form.Bumon1_yosangokei_kin,formInfo["Bumon1_yosangokei_kin"]));
			ControlUtil.SetControlValue(Bumon2_yosangokei_kin,
				DataFormatUtil.GetFormatItem(tf060f01Form.Bumon2_yosangokei_kin,formInfo["Bumon2_yosangokei_kin"]));
			ControlUtil.SetControlValue(Bumon3_yosangokei_kin,
				DataFormatUtil.GetFormatItem(tf060f01Form.Bumon3_yosangokei_kin,formInfo["Bumon3_yosangokei_kin"]));
			ControlUtil.SetControlValue(Bumon4_yosangokei_kin,
				DataFormatUtil.GetFormatItem(tf060f01Form.Bumon4_yosangokei_kin,formInfo["Bumon4_yosangokei_kin"]));
			ControlUtil.SetControlValue(Bumon5_yosangokei_kin,
				DataFormatUtil.GetFormatItem(tf060f01Form.Bumon5_yosangokei_kin,formInfo["Bumon5_yosangokei_kin"]));
			ControlUtil.SetControlValue(Yosangokei_kin,
				DataFormatUtil.GetFormatItem(tf060f01Form.Yosangokei_kin,formInfo["Yosangokei_kin"]));

			if(!base.CheckUseSelfCustomize()){
				Btnheadtenpocd.Value = base.FormResourceGetString(formResource, "Btnheadtenpocd", lang);
				Btnsearch.Value = base.FormResourceGetString(formResource, "Btnsearch", lang);
				Btncsv_torikomi.Value = base.FormResourceGetString(formResource, "Btncsv_torikomi", lang);
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
			// UIScreenController controller = new UIScreenController((Tf060f01Form)base.GetPageContext().GetFormVO());
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

			if (base.GetPageContext().CommandInfo.ActionMode.Equals("INI"))
			{
				// 明細ボタン部を非表示とする
				ControlCls.Visible(meisaiBtnArea, false);
				// 月別部門合計を非表示とする
				ControlCls.Visible(bumongokeiArea, false);
				// フッター部を非表示とする
				ControlCls.Visible(footerArea, false);
				// フッターボタン部を非表示とする
				ControlCls.Visible(footerBtnArea, false);
			}
			else
			{
				// 明細ボタン部を表示する
				ControlCls.Visible(meisaiBtnArea, true);
				// 月別部門合計を表示する
				ControlCls.Visible(bumongokeiArea, true);
				// フッター部を表示する
				ControlCls.Visible(footerArea, true);
				// フッターボタン部を表示する
				ControlCls.Visible(footerBtnArea, true);
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
			ControlUtil.SetControlValue(Getudo_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Getudo", lang), base.GetPageContext().FormInfo["Getudo"]));
				DataFormatUtil.SetMustColorCaption(Getudo_lbl, base.GetPageContext().FormInfo["Getudo"]);
			//ControlUtil.SetControlValue(Tukibetu_bumon1_yosan_kin_lbl, 
			//	DataFormatUtil.GetFormatCaption(formResource.GetString("Tukibetu_bumon1_yosan_kin", lang), base.GetPageContext().FormInfo["Tukibetu_bumon1_yosan_kin"]));
				ControlUtil.SetControlValue(Tukibetu_bumon1_yosan_kin_lbl, "月別部門合計");
				DataFormatUtil.SetMustColorCaption(Tukibetu_bumon1_yosan_kin_lbl, base.GetPageContext().FormInfo["Tukibetu_bumon1_yosan_kin"]);
			ControlUtil.SetControlValue(Tukibetu_bumon2_yosan_kin_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Tukibetu_bumon2_yosan_kin", lang), base.GetPageContext().FormInfo["Tukibetu_bumon2_yosan_kin"]));
				DataFormatUtil.SetMustColorCaption(Tukibetu_bumon2_yosan_kin_lbl, base.GetPageContext().FormInfo["Tukibetu_bumon2_yosan_kin"]);
			ControlUtil.SetControlValue(Tukibetu_bumon3_yosan_kin_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Tukibetu_bumon3_yosan_kin", lang), base.GetPageContext().FormInfo["Tukibetu_bumon3_yosan_kin"]));
				DataFormatUtil.SetMustColorCaption(Tukibetu_bumon3_yosan_kin_lbl, base.GetPageContext().FormInfo["Tukibetu_bumon3_yosan_kin"]);
			ControlUtil.SetControlValue(Tukibetu_bumon4_yosan_kin_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Tukibetu_bumon4_yosan_kin", lang), base.GetPageContext().FormInfo["Tukibetu_bumon4_yosan_kin"]));
				DataFormatUtil.SetMustColorCaption(Tukibetu_bumon4_yosan_kin_lbl, base.GetPageContext().FormInfo["Tukibetu_bumon4_yosan_kin"]);
			ControlUtil.SetControlValue(Tukibetu_bumon5_yosan_kin_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Tukibetu_bumon5_yosan_kin", lang), base.GetPageContext().FormInfo["Tukibetu_bumon5_yosan_kin"]));
				DataFormatUtil.SetMustColorCaption(Tukibetu_bumon5_yosan_kin_lbl, base.GetPageContext().FormInfo["Tukibetu_bumon5_yosan_kin"]);
			ControlUtil.SetControlValue(Tukibetu_yosan_kin_gokei_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Tukibetu_yosan_kin_gokei", lang), base.GetPageContext().FormInfo["Tukibetu_yosan_kin_gokei"]));
				DataFormatUtil.SetMustColorCaption(Tukibetu_yosan_kin_gokei_lbl, base.GetPageContext().FormInfo["Tukibetu_yosan_kin_gokei"]);
			ControlUtil.SetControlValue(Bumon1_yosangokei_kin_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Bumon1_yosangokei_kin", lang), base.GetPageContext().FormInfo["Bumon1_yosangokei_kin"]));
				DataFormatUtil.SetMustColorCaption(Bumon1_yosangokei_kin_lbl, base.GetPageContext().FormInfo["Bumon1_yosangokei_kin"]);
			ControlUtil.SetControlValue(Bumon2_yosangokei_kin_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Bumon2_yosangokei_kin", lang), base.GetPageContext().FormInfo["Bumon2_yosangokei_kin"]));
				DataFormatUtil.SetMustColorCaption(Bumon2_yosangokei_kin_lbl, base.GetPageContext().FormInfo["Bumon2_yosangokei_kin"]);
			ControlUtil.SetControlValue(Bumon3_yosangokei_kin_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Bumon3_yosangokei_kin", lang), base.GetPageContext().FormInfo["Bumon3_yosangokei_kin"]));
				DataFormatUtil.SetMustColorCaption(Bumon3_yosangokei_kin_lbl, base.GetPageContext().FormInfo["Bumon3_yosangokei_kin"]);
			ControlUtil.SetControlValue(Bumon4_yosangokei_kin_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Bumon4_yosangokei_kin", lang), base.GetPageContext().FormInfo["Bumon4_yosangokei_kin"]));
				DataFormatUtil.SetMustColorCaption(Bumon4_yosangokei_kin_lbl, base.GetPageContext().FormInfo["Bumon4_yosangokei_kin"]);
			ControlUtil.SetControlValue(Bumon5_yosangokei_kin_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Bumon5_yosangokei_kin", lang), base.GetPageContext().FormInfo["Bumon5_yosangokei_kin"]));
				DataFormatUtil.SetMustColorCaption(Bumon5_yosangokei_kin_lbl, base.GetPageContext().FormInfo["Bumon5_yosangokei_kin"]);
			ControlUtil.SetControlValue(Yosangokei_kin_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Yosangokei_kin", lang), base.GetPageContext().FormInfo["Yosangokei_kin"]));
				DataFormatUtil.SetMustColorCaption(Yosangokei_kin_lbl, base.GetPageContext().FormInfo["Yosangokei_kin"]);
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
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1getunai_hiduke", lang), base.GetPageContext().FormInfo["M1getunai_hiduke"]);
				// M1.Columns[1].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1yobi", lang), base.GetPageContext().FormInfo["M1yobi"]);
				// M1.Columns[2].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumon1_yosan_kin", lang), base.GetPageContext().FormInfo["M1bumon1_yosan_kin"]);
				// M1.Columns[3].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumon2_yosan_kin", lang), base.GetPageContext().FormInfo["M1bumon2_yosan_kin"]);
				// M1.Columns[4].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumon3_yosan_kin", lang), base.GetPageContext().FormInfo["M1bumon3_yosan_kin"]);
				// M1.Columns[5].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumon4_yosan_kin", lang), base.GetPageContext().FormInfo["M1bumon4_yosan_kin"]);
				// M1.Columns[6].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumon5_yosan_kin", lang), base.GetPageContext().FormInfo["M1bumon5_yosan_kin"]);
				// M1.Columns[7].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hibetu_yosan_kin", lang), base.GetPageContext().FormInfo["M1hibetu_yosan_kin"]);
				// M1.Columns[8].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumon1_yosan_kin_hdn", lang), base.GetPageContext().FormInfo["M1bumon1_yosan_kin_hdn"]);
				// M1.Columns[9].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumon2_yosan_kin_hdn", lang), base.GetPageContext().FormInfo["M1bumon2_yosan_kin_hdn"]);
				// M1.Columns[10].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumon3_yosan_kin_hdn", lang), base.GetPageContext().FormInfo["M1bumon3_yosan_kin_hdn"]);
				// M1.Columns[11].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumon4_yosan_kin_hdn", lang), base.GetPageContext().FormInfo["M1bumon4_yosan_kin_hdn"]);
				// M1.Columns[12].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumon5_yosan_kin_hdn", lang), base.GetPageContext().FormInfo["M1bumon5_yosan_kin_hdn"]);
				// M1.Columns[13].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1selectorcheckbox", lang), base.GetPageContext().FormInfo["M1selectorcheckbox"]);
				// M1.Columns[14].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1entersyoriflg", lang), base.GetPageContext().FormInfo["M1entersyoriflg"]);
				// M1.Columns[15].HeaderText = 
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
				Windowtitle.InnerText = formResource.GetString("Tf060f01_Titlebar", lang);
				header.FormName = formResource.GetString("Tf060f01_FormCaption", lang);
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
