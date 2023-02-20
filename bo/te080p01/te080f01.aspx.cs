using com.xebio.bo.Te080p01.Constant;
using com.xebio.bo.Te080p01.Facade;
using com.xebio.bo.Te080p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.Model.Context;
using Common.Advanced.Resource;
using Common.Advanced.Web.Context;
using Common.Advanced.Web.Util;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01013;
using Common.Business.C01000.C01014;
using Common.Business.C01000.C01016;
using Common.Business.C99999.Constant;
using Common.Business.C99999.StringUtil;
using Common.IntegrationMD.MDControl;
using Common.IntegrationMD.Util;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Util;
using System;
using System.Collections;
using System.Collections.Specialized;

namespace com.xebio.bo.Te080p01.Page
{
  /// <summary>
  /// Te080f01のコードビハインドです。
  /// </summary>
  public partial class Te080f01Page : StandardBasePage
	{

		#region メソッド

		#region ページデータをロードするメソッド
		/// <summary>
		/// Te080f01画面データを作成する。
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
						pageContext.SetFormVO(new Te080f01Form());
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
								new Te080f01Facade().DoLoad(facadeContext);

								#region 共通ヘッダ処理

								// 一覧画面共通処理 ----------
								LoginInfoVO loginInfVO = LoginInfoUtil.GetLoginInfo();
								Te080f01Form te080f01Form = (Te080f01Form)facadeContext.FormVO;
								ControlHeaderStoreCls.InitialSetHeaderStore<Te080f01Form>(loginInfVO, te080f01Form);
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

				// インフォメッセージ ----------------------------------------------------------------------		
				if (pageContext != null)
				{
					string msg = InfoMsgCls.GetWarningMsg(pageContext, Te080p01Constant.PGID);
					if (!string.IsNullOrEmpty(msg))
					{
						// インフォメッセージが表示されている場合、表示する。
						Page.ClientScript.RegisterStartupScript(typeof(string), "infoDialog", msg);
						return;
					}
				}
				// インフォメッセージ ----------------------------------------------------------------------		
				
			}
			catch (System.Exception ex)
			{
				ThrowException(ex, pageContext);
			}
			
			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".Page_Load");
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
				new Te080f01Facade().DoBTNROWDEL_FRM(facadeContext);
				
				
				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
					base.SetError(pageContext);
					return;
				}

				// フォーカス行をコードビハインドに戻す
				lastRow = (decimal)facadeContext.GetUserObject(Te080p01Constant.FCDUO_FOCUSROW);

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

			// 削除行の次の行にフォーカス設定
			focusItem = "M1kaisya_cd";
			focusMno = lastRow.ToString();

			// フォーカス設定
			SetFocusCls.SetFocus(queryList, focusItem, focusMno);
			
			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNROWDEL_FRM");
			
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
				new Te080f01Facade().DoBTNENTER_FRM(facadeContext);

				// インフォメッセージ ----------------------------------------------------------------------	
				// 情報判定	
				if (InfoMsgCls.HasInfo(facadeContext))
				{
					// インフォメッセージの表示
					InfoMsgCls.showLoadMsg(pageContext, 1, Te080p01Constant.PGID);
				}
				// インフォメッセージ ----------------------------------------------------------------------	
				
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

		#region フォームを呼び出します(ボタンID : Btnrowins(ボタン行追加（ダミー）))
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnrowins(ボタン行追加（ダミー）))
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnBTNROWINS_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnBTNROWINS_FRM");
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

			// フォーカス設定用変数
			string focusItem = string.Empty;
			string focusMno = string.Empty;

			try
			{

				//アクションロジックを処理します
				IFacadeContext facadeContext = FacadeContextFactory.GetFacadeContext(pageContext);
				InitFacadeContext(facadeContext);
				new Te080f01Facade().DoBTNROWINS_FRM(facadeContext);

				Te080f01Form te080f01Form = (Te080f01Form)facadeContext.FormVO;

				#region フォーカス行
				int listCount = Convert.ToInt16(te080f01Form.Dictionary[Te080p01Constant.DIC_LIST_COUNT]);
				if (listCount == 0)
				{
					focusMno = (Convert.ToInt16(te080f01Form.Selectrowno) + 1).ToString();
				}
				else
				{
					focusMno = (Convert.ToInt16(te080f01Form.Selectrowno) + listCount).ToString();
				}
				#endregion

				//エラー判定
				if (MessageDisplayUtil.HasError(facadeContext))
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

			// フォーカス項目
			focusItem = "M1scmden_cd";

			//フォーカスを当てる項目を指定したい場合はFormFocusUtilを使ってqueryListに追加すること
			queryList = SetFocusCls.SetFocus(queryList, focusItem, focusMno);

			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNROWINS_FRM");

			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion

		#region フォームを呼び出します(ボタンID : Btnclear(ボタンクリア（ダミー）))
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnclear(ボタンクリア（ダミー）))
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnBTNCLEAR_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnBTNCLEAR_FRM");
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
				new Te080f01Facade().DoBTNCLEAR_FRM(facadeContext);
				
				
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
			EndMethod(sender, e, this.GetType().Name + ".OnBTNCLEAR_FRM");
			
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
						Te080f01Form te080f01Form = (Te080f01Form)pageContext.GetFormVO();

						//明細ページ情報を表示する
						ShowListPageInfo(te080f01Form);
			
						//明細部データを表示する
						RenderList(te080f01Form, pageContext.FormInfo, formResource, lang);

						//カード部データを表示する
						RenderCard(te080f01Form, pageContext.FormInfo, formResource, lang);
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
		/// <param name="te080f01Form">画面FormVO</param>
		private void ShowListPageInfo(Te080f01Form te080f01Form)
		{
			//M1明細ページ情報を表示する。
			ShowM1ListPageInfo(te080f01Form.GetList("M1"));

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
		/// <param name="te080f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderList(
			Te080f01Form te080f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//画面のM1明細部データを設定する。
			RenderM1List(te080f01Form, formInfo, formResource, lang);
			
		}
		#endregion

		#region M1明細データを表示する
		/// <summary>
		/// M1明細データを表示する。
		/// </summary>
		/// <param name="te080f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderM1List(
			Te080f01Form te080f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//M1明細部データソースを設定する。
			M1.DataSource = te080f01Form.GetPageViewList("M1");
			M1.DataBind();

			//M1明細部データをフォーマットする。
			IList m1DataList = (IList)M1.DataSource;
			
			for (int index = 0; index < M1.Items.Count; index++)
			{
				Te080f01M1Form te080f01M1Form = (Te080f01M1Form)m1DataList[index];
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1rowno"),
					DataFormatUtil.GetFormatItem(te080f01M1Form.M1rowno,formInfo["M1rowno"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1kaisya_cd"),
					DataFormatUtil.GetFormatItem(te080f01M1Form.M1kaisya_cd,formInfo["M1kaisya_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1kaisya_nm"),
					DataFormatUtil.GetFormatItem(te080f01M1Form.M1kaisya_nm,formInfo["M1kaisya_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1syukkaten_cd"),
					DataFormatUtil.GetFormatItem(te080f01M1Form.M1syukkaten_cd,formInfo["M1syukkaten_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1syukkaten_nm"),
					DataFormatUtil.GetFormatItem(te080f01M1Form.M1syukkaten_nm,formInfo["M1syukkaten_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1scmden_cd"),
					DataFormatUtil.GetFormatItem(te080f01M1Form.M1scmden_cd,formInfo["M1scmden_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1scm_cd"),
					DataFormatUtil.GetFormatItem(te080f01M1Form.M1scm_cd,formInfo["M1scm_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1denpyo_bango"),
					DataFormatUtil.GetFormatItem(te080f01M1Form.M1denpyo_bango,formInfo["M1denpyo_bango"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1syukka_ymd"),
					DataFormatUtil.GetFormatItem(te080f01M1Form.M1syukka_ymd,formInfo["M1syukka_ymd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1yotei_su"),
					DataFormatUtil.GetFormatItem(te080f01M1Form.M1yotei_su,formInfo["M1yotei_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1kyakucyu"),
					DataFormatUtil.GetFormatItem(te080f01M1Form.M1kyakucyu,formInfo["M1kyakucyu"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1negaki"),
					DataFormatUtil.GetFormatItem(te080f01M1Form.M1negaki,formInfo["M1negaki"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1tenpolc_kbn_hdn"),
					DataFormatUtil.GetFormatItem(te080f01M1Form.M1tenpolc_kbn_hdn,formInfo["M1tenpolc_kbn_hdn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1selectorcheckbox"),
					DataFormatUtil.GetFormatItem(te080f01M1Form.M1selectorcheckbox,formInfo["M1selectorcheckbox"]));
				((System.Web.UI.WebControls.CheckBox)M1.Items[index].FindControl("M1selectorcheckbox")).Text =
					formResource.GetString("M1selectorcheckbox", lang);
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1entersyoriflg"),
					DataFormatUtil.GetFormatItem(te080f01M1Form.M1entersyoriflg,formInfo["M1entersyoriflg"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1dtlirokbn"),
					DataFormatUtil.GetFormatItem(te080f01M1Form.M1dtlirokbn,formInfo["M1dtlirokbn"]));

				if(!base.CheckUseSelfCustomize()){
					((System.Web.UI.HtmlControls.HtmlInputButton)M1.Items[index].FindControl("M1btnkaisha_cd")).Value =
						formResource.GetString("M1btnkaisha_cd", lang);
					((System.Web.UI.HtmlControls.HtmlInputButton)M1.Items[index].FindControl("M1btnsyukkatencd")).Value =
						formResource.GetString("M1btnsyukkatencd", lang);

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
				// (M1.HeaderRow.FindControl("M1kaisya_cd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kaisya_cd", lang), base.GetPageContext().FormInfo["M1kaisya_cd"]);
				// (M1.HeaderRow.FindControl("M1btnkaisha_cd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1btnkaisha_cd", lang), base.GetPageContext().FormInfo["M1btnkaisha_cd"]);
				// (M1.HeaderRow.FindControl("M1kaisya_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kaisya_nm", lang), base.GetPageContext().FormInfo["M1kaisya_nm"]);
				// (M1.HeaderRow.FindControl("M1syukkaten_cd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syukkaten_cd", lang), base.GetPageContext().FormInfo["M1syukkaten_cd"]);
				// (M1.HeaderRow.FindControl("M1btnsyukkatencd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1btnsyukkatencd", lang), base.GetPageContext().FormInfo["M1btnsyukkatencd"]);
				// (M1.HeaderRow.FindControl("M1syukkaten_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syukkaten_nm", lang), base.GetPageContext().FormInfo["M1syukkaten_nm"]);
				// (M1.HeaderRow.FindControl("M1scmden_cd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1scmden_cd", lang), base.GetPageContext().FormInfo["M1scmden_cd"]);
				// (M1.HeaderRow.FindControl("M1scm_cd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1scm_cd", lang), base.GetPageContext().FormInfo["M1scm_cd"]);
				// (M1.HeaderRow.FindControl("M1denpyo_bango") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1denpyo_bango", lang), base.GetPageContext().FormInfo["M1denpyo_bango"]);
				// (M1.HeaderRow.FindControl("M1syukka_ymd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syukka_ymd", lang), base.GetPageContext().FormInfo["M1syukka_ymd"]);
				// (M1.HeaderRow.FindControl("M1yotei_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1yotei_su", lang), base.GetPageContext().FormInfo["M1yotei_su"]);
				// (M1.HeaderRow.FindControl("M1kyakucyu") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kyakucyu", lang), base.GetPageContext().FormInfo["M1kyakucyu"]);
				// (M1.HeaderRow.FindControl("M1negaki") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1negaki", lang), base.GetPageContext().FormInfo["M1negaki"]);
				// (M1.HeaderRow.FindControl("M1tenpolc_kbn_hdn") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tenpolc_kbn_hdn", lang), base.GetPageContext().FormInfo["M1tenpolc_kbn_hdn"]);
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
		/// <param name="te080f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderCard(
			Te080f01Form te080f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{

			ControlUtil.SetControlValue(Head_tenpo_cd,
				DataFormatUtil.GetFormatItem(te080f01Form.Head_tenpo_cd, formInfo["Head_tenpo_cd"]));
			ControlUtil.SetControlValue(Head_tenpo_nm,
				DataFormatUtil.GetFormatItem(te080f01Form.Head_tenpo_nm, formInfo["Head_tenpo_nm"]));
			ControlUtil.SetControlValue(Scm_gokei,
				DataFormatUtil.GetFormatItem(te080f01Form.Scm_gokei, formInfo["Scm_gokei"]));
			ControlUtil.SetControlValue(Denpyo_gokei,
				DataFormatUtil.GetFormatItem(te080f01Form.Denpyo_gokei, formInfo["Denpyo_gokei"]));
			ControlUtil.SetControlValue(Selectrowno,
				DataFormatUtil.GetFormatItem(te080f01Form.Selectrowno, formInfo["Selectrowno"]));

			if(!base.CheckUseSelfCustomize()){
				Btnheadtenpocd.Value = base.FormResourceGetString(formResource, "Btnheadtenpocd", lang);
				Btnrowdel.Value = base.FormResourceGetString(formResource, "Btnrowdel", lang);
				Btnenter.Value = base.FormResourceGetString(formResource, "Btnenter", lang);
				Btnrowins.Value = base.FormResourceGetString(formResource, "Btnrowins", lang);
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
			// UIScreenController controller = new UIScreenController((Te080f01Form)base.GetPageContext().GetFormVO());
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


			// エラー行のSCM/伝票番号のテキストの背景色を変更
			Te080f01Form formVo = (Te080f01Form)base.GetPageContext().GetFormVO();
			IDataList m1List = formVo.GetList("M1");

			for (int index = 0; index < M1.Items.Count; index++)
			{
				Te080f01M1Form f01m1VO = (Te080f01M1Form)m1List[index];
				string errFlg = BoSystemString.Nvl((string)f01m1VO.Dictionary[Te080p01Constant.DIC_M1ERRFLG], "");
				string css = ((MDTextBox)M1.Items[index].FindControl("M1scmden_cd")).CssClass;
				css = css.Replace(" error-input-code", "");
				if (errFlg.Equals("1"))
				{
					// エラーの場合

					// エラーのCSSクラスを設定
					((MDTextBox)M1.Items[index].FindControl("M1scmden_cd")).CssClass = css + " error-input-code";
					// エラーフラグ初期化
					f01m1VO.Dictionary[Te080p01Constant.DIC_M1ERRFLG] = "";
				}

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
			ControlUtil.SetControlValue(Scm_gokei_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Scm_gokei", lang), base.GetPageContext().FormInfo["Scm_gokei"]));
				DataFormatUtil.SetMustColorCaption(Scm_gokei_lbl, base.GetPageContext().FormInfo["Scm_gokei"]);
			ControlUtil.SetControlValue(Denpyo_gokei_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Denpyo_gokei", lang), base.GetPageContext().FormInfo["Denpyo_gokei"]));
			DataFormatUtil.SetMustColorCaption(Denpyo_gokei_lbl, base.GetPageContext().FormInfo["Denpyo_gokei"]);
			ControlUtil.SetControlValue(Selectrowno_lbl,
				DataFormatUtil.GetFormatCaption(formResource.GetString("Selectrowno", lang), base.GetPageContext().FormInfo["Selectrowno"]));
			DataFormatUtil.SetMustColorCaption(Selectrowno_lbl, base.GetPageContext().FormInfo["Selectrowno"]);
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
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kaisya_cd", lang), base.GetPageContext().FormInfo["M1kaisya_cd"]);
				// M1.Columns[2].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1btnkaisha_cd", lang), base.GetPageContext().FormInfo["M1btnkaisha_cd"]);
				// M1.Columns[3].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kaisya_nm", lang), base.GetPageContext().FormInfo["M1kaisya_nm"]);
				// M1.Columns[4].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syukkaten_cd", lang), base.GetPageContext().FormInfo["M1syukkaten_cd"]);
				// M1.Columns[5].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1btnsyukkatencd", lang), base.GetPageContext().FormInfo["M1btnsyukkatencd"]);
				// M1.Columns[6].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syukkaten_nm", lang), base.GetPageContext().FormInfo["M1syukkaten_nm"]);
				// M1.Columns[7].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1scmden_cd", lang), base.GetPageContext().FormInfo["M1scmden_cd"]);
				// M1.Columns[8].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1scm_cd", lang), base.GetPageContext().FormInfo["M1scm_cd"]);
				// M1.Columns[9].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1denpyo_bango", lang), base.GetPageContext().FormInfo["M1denpyo_bango"]);
				// M1.Columns[10].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syukka_ymd", lang), base.GetPageContext().FormInfo["M1syukka_ymd"]);
				// M1.Columns[11].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1yotei_su", lang), base.GetPageContext().FormInfo["M1yotei_su"]);
				// M1.Columns[12].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kyakucyu", lang), base.GetPageContext().FormInfo["M1kyakucyu"]);
				// M1.Columns[13].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1negaki", lang), base.GetPageContext().FormInfo["M1negaki"]);
				// M1.Columns[14].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tenpolc_kbn_hdn", lang), base.GetPageContext().FormInfo["M1tenpolc_kbn_hdn"]);
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
				Windowtitle.InnerText = formResource.GetString("Te080f01_Titlebar", lang);
				header.FormName = formResource.GetString("Te080f01_FormCaption", lang);
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
