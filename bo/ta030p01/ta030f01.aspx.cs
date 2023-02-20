using com.xebio.bo.Ta030p01.Constant;
using com.xebio.bo.Ta030p01.Facade;
using com.xebio.bo.Ta030p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.Model.Context;
using Common.Advanced.Resource;
using Common.Advanced.Web.Context;
using Common.Advanced.Web.Util;
using Common.Business.C01000.C01013;
using Common.Business.C01000.C01014;
using Common.Business.C01000.C01015;
using Common.Business.C01000.C01019;
using Common.Business.C01000.C01026;
using Common.Business.C99999.Constant;
using Common.IntegrationMD.Util;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Util;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Ta030p01.Page
{
  /// <summary>
  /// Ta030f01のコードビハインドです。
  /// </summary>
  public partial class Ta030f01Page : StandardBasePage
	{

		#region メソッド

   
		#region ページデータをロードするメソッド
		/// <summary>
		/// Ta030f01画面データを作成する。
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
						pageContext.SetFormVO(new Ta030f01Form());
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
								new Ta030f01Facade().DoLoad(facadeContext);

                                #region 共通ヘッダ処理

                                // 一覧画面共通処理 ----------
                                LoginInfoVO loginInfVO = LoginInfoUtil.GetLoginInfo();
                                Ta030f01Form ta030f01Form = (Ta030f01Form)facadeContext.FormVO;
                                ControlHeaderStoreCls.InitialSetHeaderStore<Ta030f01Form>(loginInfVO, ta030f01Form);
                                // 一覧画面共通処理 ----------

								// 初期表示時のモードとアコーディオン状態を設定
                                if (string.IsNullOrEmpty(ta030f01Form.Modeno))
                                {
                                    // アコーディオンなし
                                    AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_NONE);
                                    // モードNoを照会部門別に設定
									ta030f01Form.Modeno = BoSystemConstant.MODE_REF_BUMON.ToString();
									TabUtil.SetTabNumber(pageContext, BoSystemConstant.MODE_REF_BUMON.ToString());
                                }
								
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
				

                // モードNoをセッションに格納
                if (base.GetPageContext() != null)
                {
					FormVOManager fvm = new FormVOManager(Session);
					Ta030f01Form f03VO = (Ta030f01Form)fvm.GetProgramVO(base.GetPageContext().CommandInfo.ProgramId).GetFormVO(Ta030p01Constant.FORMID_01);                 
                    TabUtil.SetTabNumber(base.GetPageContext(), f03VO.Modeno);

					// [モードNO]が「照会単品別」の場合
					if (f03VO.Modeno.Equals(BoSystemConstant.MODE_REF_TANPIN))
					{
						// アコーディオンなし
						AccordionUtil.SetAccordionKbn(base.GetPageContext(), BoSystemConstant.ACCORDION_ST_NONE);

					}
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
				// モード表示クリア処理
				ModeUtil.ClearMode(pageContext);
				// 明細初期化処理
				Page.ClientScript.RegisterStartupScript(typeof(string), "InitialDetail", ControlCls.InitialDetail(pageContext));
				return;
			}
			//アクションコンテキストを取得する
			pageContext = base.GetPageContext();
			ICommandInfo commandInfo = pageContext.CommandInfo;

			try
			{

				//アクションロジックを処理します
				IFacadeContext facadeContext = FacadeContextFactory.GetFacadeContext(pageContext);
				InitFacadeContext(facadeContext);
				new Ta030f01Facade().DoBTNSEARCH_FRM(facadeContext);
				
				
				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
					// アコーディオンなし
					AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_NONE);
					commandInfo.ActionMode = "INI";

					base.SetError(pageContext);
					return;
				}
				
				//遷移先の画面設定（入出力画面定義で設定した遷移先は初期化処理で設定済み）
				//入出力画面定義で設定した遷移先以外の画面に遷移する場合は以下のソースを
				//コメントインし、設定して下さい。
				// [モードNO]が「照会単品別」の場合
				Ta030f01Form ta030f01Form = (Ta030f01Form)facadeContext.FormVO;
				if (ta030f01Form.Modeno.Equals(BoSystemConstant.MODE_REF_TANPIN))
				{
					//commandInfo.ToProgramId = "Ta030p01";
					commandInfo.ToFormId = "TA030F02";


					// 次画面のフォームVOをファサードに設定
					FormVOManager fvm = new FormVOManager(Session);
					//facadeContext.SetUserObject(Ta030p01Constant.FCDUO_NEXTVO, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Ta030p01Constant.FORMID_02));

					// 次画面のフォームビーンを設定
					fvm.SetFormVO(Ta030p01Constant.PGID, Ta030p01Constant.FORMID_02, (Ta030f02Form)facadeContext.GetUserObject(Ta030p01Constant.FCDUO_NEXTVO));

					//アコーディオンを閉じた状態で表示
					AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_OPEN);

					//アコーディオンを閉じた際に表示される検索条件を設定する。
					AccordionUtil.ResetSearchCondition(pageContext);

					//他の処理モードを設定する必要がある場合、次の行を修正してください
					commandInfo.ActionMode = "UPD";
					commandInfo.PageLoadMode = false;
				}
				else
				{ 
					// 他の処理モードを設定する必要がある場合、次の行を修正してください

					//アコーディオンを閉じた状態で表示
					AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_CLOSE);

					//アコーディオンを閉じた際に表示される検索条件を設定する。
					AccordionUtil.ResetSearchCondition(pageContext);
					
					commandInfo.ActionMode = "UPD";
					commandInfo.PageLoadMode = false;
				}

				// モードを設定 
				ModeUtil.SetMode(pageContext, ModeCls.GetModeNm(((Ta030f01Form)pageContext.GetFormVO()).Stkmodeno));

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
			focusItem = "M1bumon_cd_bo";
			// 1行目にフォーカス設定
			focusMno = 0.ToString();

			// フォーカス設定
			queryList = SetFocusCls.SetFocus(queryList, focusItem, focusMno);
			
			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNSEARCH_FRM");
			
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
				new Ta030f01Facade().DoPGR_PGN(facadeContext, pageindex);
				
				
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
		
		#region フォームを呼び出します(ボタンID : M1bumon_cd_bo(部門))
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(M1bumon_cd_bo(部門))
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnM1BUMON_CD_BO_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnM1BUMON_CD_BO_FRM");
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
				facadeContext.SetUserObject(Ta030p01Constant.FCDUO_NEXTVO, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Ta030p01Constant.FORMID_02));

				new Ta030f01Facade().DoM1BUMON_CD_BO_FRM(facadeContext);

				// 次画面のフォームビーンを設定
				fvm.SetFormVO(Ta030p01Constant.PGID, Ta030p01Constant.FORMID_02, (Ta030f02Form)facadeContext.GetUserObject(Ta030p01Constant.FCDUO_NEXTVO));
				
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
			EndMethod(sender, e, this.GetType().Name + ".OnM1BUMON_CD_BO_FRM");
			
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
						Ta030f01Form ta030f01Form = (Ta030f01Form)pageContext.GetFormVO();

						//明細ページ情報を表示する
						ShowListPageInfo(ta030f01Form);
			
						//明細部データを表示する
						RenderList(ta030f01Form, pageContext.FormInfo, formResource, lang);

						//カード部データを表示する
						RenderCard(ta030f01Form, pageContext.FormInfo, formResource, lang);
					//}
					
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
		/// <param name="ta030f01Form">画面FormVO</param>
		private void ShowListPageInfo(Ta030f01Form ta030f01Form)
		{
			//M1明細ページ情報を表示する。
			ShowM1ListPageInfo(ta030f01Form.GetList("M1"));

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
		/// <param name="ta030f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderList(
			Ta030f01Form ta030f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//画面のM1明細部データを設定する。
			RenderM1List(ta030f01Form, formInfo, formResource, lang);
			//M1明細部のページャーにページ情報を設定する。
			RenderM1Pager(ta030f01Form);
			
		}
		#endregion

		#region M1明細データを表示する
		/// <summary>
		/// M1明細データを表示する。
		/// </summary>
		/// <param name="ta030f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderM1List(
			Ta030f01Form ta030f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//M1明細部データソースを設定する。
			M1.DataSource = ta030f01Form.GetPageViewList("M1");
			M1.DataBind();

			//M1明細部データをフォーマットする。
			IList m1DataList = (IList)M1.DataSource;

			if (ta030f01Form.Modeno.Equals(BoSystemConstant.MODE_REF_BUMON))
			{ 
				for (int index = 0; index < M1.Items.Count; index++)
				{
					Ta030f01M1Form ta030f01M1Form = (Ta030f01M1Form)m1DataList[index];
					ControlUtil.SetControlValue(M1.Items[index].FindControl("M1rowno"),
						DataFormatUtil.GetFormatItem(ta030f01M1Form.M1rowno,formInfo["M1rowno"]));
					ControlUtil.SetControlValue(M1.Items[index].FindControl("M1hojuirai_kbn_nm"),
						DataFormatUtil.GetFormatItem(ta030f01M1Form.M1hojuirai_kbn_nm,formInfo["M1hojuirai_kbn_nm"]));
					ControlUtil.SetControlValue(M1.Items[index].FindControl("M1sinsei_jotainm"),
						DataFormatUtil.GetFormatItem(ta030f01M1Form.M1sinsei_jotainm,formInfo["M1sinsei_jotainm"]));
					ControlUtil.SetControlValue(M1.Items[index].FindControl("M1itemsu"),
						DataFormatUtil.GetFormatItem(ta030f01M1Form.M1itemsu,formInfo["M1itemsu"]));
					ControlUtil.SetControlValue(M1.Items[index].FindControl("M1kingaku"),
						DataFormatUtil.GetFormatItem(ta030f01M1Form.M1kingaku,formInfo["M1kingaku"]));
					ControlUtil.SetControlValue(M1.Items[index].FindControl("M1selectorcheckbox"),
						DataFormatUtil.GetFormatItem(ta030f01M1Form.M1selectorcheckbox,formInfo["M1selectorcheckbox"]));
					((System.Web.UI.WebControls.CheckBox)M1.Items[index].FindControl("M1selectorcheckbox")).Text =
						formResource.GetString("M1selectorcheckbox", lang);
					ControlUtil.SetControlValue(M1.Items[index].FindControl("M1entersyoriflg"),
						DataFormatUtil.GetFormatItem(ta030f01M1Form.M1entersyoriflg,formInfo["M1entersyoriflg"]));
					ControlUtil.SetControlValue(M1.Items[index].FindControl("M1dtlirokbn"),
						DataFormatUtil.GetFormatItem(ta030f01M1Form.M1dtlirokbn,formInfo["M1dtlirokbn"]));
					ControlUtil.SetControlValue(Searchcnt,
						DataFormatUtil.GetFormatItem(ta030f01Form.Searchcnt, formInfo["Searchcnt"]));
					if (!base.CheckUseSelfCustomize())
					{
						// ボタンのValueに部門コードと部門名を設定
						((System.Web.UI.HtmlControls.HtmlInputButton)M1.Items[index].FindControl("M1bumon_cd_bo")).Value =
							ta030f01M1Form.Dictionary[Ta030p01Constant.DIC_M1BUMON_CD].ToString()
							+ " " + ta030f01M1Form.Dictionary[Ta030p01Constant.DIC_M1BUMONKANA_NM].ToString();
					}
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
				// (M1.HeaderRow.FindControl("M1hojuirai_kbn_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hojuirai_kbn_nm", lang), base.GetPageContext().FormInfo["M1hojuirai_kbn_nm"]);
				// (M1.HeaderRow.FindControl("M1sinsei_jotainm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1sinsei_jotainm", lang), base.GetPageContext().FormInfo["M1sinsei_jotainm"]);
				// (M1.HeaderRow.FindControl("M1bumon_cd_bo") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumon_cd_bo", lang), base.GetPageContext().FormInfo["M1bumon_cd_bo"]);
				// (M1.HeaderRow.FindControl("M1itemsu") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1itemsu", lang), base.GetPageContext().FormInfo["M1itemsu"]);
				// (M1.HeaderRow.FindControl("M1kingaku") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kingaku", lang), base.GetPageContext().FormInfo["M1kingaku"]);
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
		/// <param name="ta030f01Form">画面FormVO</param>
		private void RenderM1Pager(Ta030f01Form ta030f01Form)
		{
			Pgr.VirtualItemCount = ta030f01Form.GetList("M1").RecordCount;
			Pgr.CurrentPageIndex = ta030f01Form.GetList("M1").PageNo - 1;
			Pgr.PageSize = ta030f01Form.GetList("M1").DispRow;
		}
		#endregion
		#endregion

		#region カードデータを表示する
		/// <summary>
		/// カードデータを表示する
		/// </summary>
		/// <param name="ta030f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderCard(
			Ta030f01Form ta030f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			
			ControlUtil.SetControlValue(Head_tenpo_cd,
				DataFormatUtil.GetFormatItem(ta030f01Form.Head_tenpo_cd,formInfo["Head_tenpo_cd"]));
			ControlUtil.SetControlValue(Head_tenpo_nm,
				DataFormatUtil.GetFormatItem(ta030f01Form.Head_tenpo_nm,formInfo["Head_tenpo_nm"]));
			ControlUtil.SetControlValue(Modeno,
				DataFormatUtil.GetFormatItem(ta030f01Form.Modeno,formInfo["Modeno"]));
			ControlUtil.SetControlValue(Stkmodeno,
				DataFormatUtil.GetFormatItem(ta030f01Form.Stkmodeno,formInfo["Stkmodeno"]));
			ControlUtil.SetControlValue(Kbn_cd,
				DataFormatUtil.GetFormatItem(ta030f01Form.Kbn_cd,formInfo["Kbn_cd"]));
			ControlUtil.SetControlValue(Shinsei_flg,
				DataFormatUtil.GetFormatItem(ta030f01Form.Shinsei_flg,formInfo["Shinsei_flg"]));
			ControlUtil.SetControlValue(Siiresaki_cd,
				DataFormatUtil.GetFormatItem(ta030f01Form.Siiresaki_cd,formInfo["Siiresaki_cd"]));
			ControlUtil.SetControlValue(Siiresaki_ryaku_nm,
				DataFormatUtil.GetFormatItem(ta030f01Form.Siiresaki_ryaku_nm,formInfo["Siiresaki_ryaku_nm"]));
			ControlUtil.SetControlValue(Bumon_cd,
				DataFormatUtil.GetFormatItem(ta030f01Form.Bumon_cd,formInfo["Bumon_cd"]));
			ControlUtil.SetControlValue(Bumon_nm,
				DataFormatUtil.GetFormatItem(ta030f01Form.Bumon_nm,formInfo["Bumon_nm"]));
			ControlUtil.SetControlValue(Burando_cd,
				DataFormatUtil.GetFormatItem(ta030f01Form.Burando_cd,formInfo["Burando_cd"]));
			ControlUtil.SetControlValue(Burando_nm,
				DataFormatUtil.GetFormatItem(ta030f01Form.Burando_nm,formInfo["Burando_nm"]));
			ControlUtil.SetControlValue(Hattyu_ymd_from,
				DataFormatUtil.GetFormatItem(ta030f01Form.Hattyu_ymd_from,formInfo["Hattyu_ymd_from"]));
			ControlUtil.SetControlValue(Hattyu_ymd_to,
				DataFormatUtil.GetFormatItem(ta030f01Form.Hattyu_ymd_to,formInfo["Hattyu_ymd_to"]));
			ControlUtil.SetControlValue(Old_jisya_hbn,
				DataFormatUtil.GetFormatItem(ta030f01Form.Old_jisya_hbn,formInfo["Old_jisya_hbn"]));
			ControlUtil.SetControlValue(Maker_hbn,
				DataFormatUtil.GetFormatItem(ta030f01Form.Maker_hbn,formInfo["Maker_hbn"]));
			ControlUtil.SetControlValue(Scan_cd,
				DataFormatUtil.GetFormatItem(ta030f01Form.Scan_cd,formInfo["Scan_cd"]));
			ControlUtil.SetControlValue(Gokei_itemsu,
				DataFormatUtil.GetFormatItem(ta030f01Form.Gokei_itemsu,formInfo["Gokei_itemsu"]));
			ControlUtil.SetControlValue(Gokei_kingaku,
				DataFormatUtil.GetFormatItem(ta030f01Form.Gokei_kingaku,formInfo["Gokei_kingaku"]));

			if(!base.CheckUseSelfCustomize()){
				Btnheadtenpocd.Value = base.FormResourceGetString(formResource, "Btnheadtenpocd", lang);
				Btnmoderef_bumon.InnerText = base.FormResourceGetString(formResource, "Btnmoderef_bumon", lang);
				Btnmoderef_tanpin.InnerText = base.FormResourceGetString(formResource, "Btnmoderef_tanpin", lang);
				Btnsiiresaki_cd.Value = base.FormResourceGetString(formResource, "Btnsiiresaki_cd", lang);
				Btnbumon_cd.Value = base.FormResourceGetString(formResource, "Btnbumon_cd", lang);
				Btnburando_cd.Value = base.FormResourceGetString(formResource, "Btnburando_cd", lang);
				Btnsearch.Value = base.FormResourceGetString(formResource, "Btnsearch", lang);
				Pgr.Text = base.FormResourceGetString(formResource, "Pgr", lang);
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
				Kbn_cd.Items.Insert(0, new ListItem("", BoSystemConstant.DROPDOWNLIST_MISENTAKU));
				Shinsei_flg.Items.Insert(0, new ListItem("", BoSystemConstant.DROPDOWNLIST_MISENTAKU));

			}
		}
		#endregion

		#region Attribute設定(Visible等の設定)
		/// <summary>
		/// コントロールのAttributeを設定します。
		/// </summary>
		protected override void SetAttribute()
		{
			LoginInfoVO loginInfVO = LoginInfoUtil.GetLoginInfo();
			if (!CheckCompanyCls.IsXebio())
			{
				// ログイン情報.[会社コード]＜＞"1"（X）の場合
				// 申請状態を使用不可にする
				ControlCls.Disable(Shinsei_flg, true);
			}
			/*
			 *明細スクロール位置情報生成処理を行います。
			 *機能有効させる場合は、コメントアウトを外してください。
			 */
			//ScrollRelationship.DrawRelations(this, base.GetPageContext());
			
			//
			// 明細部のヘッダ固定、明細列の表示・非表示を制御する部品です。
			// 機能有効する場合は、コメントアウトを外して、必要な情報を追加してください。
			// UIScreenController controller = new UIScreenController((Ta030f01Form)base.GetPageContext().GetFormVO());
			// controller.ChangeColumnsDisplayMode(M1 ,  new DetailHeaderFixedVO(M1Header , true) , null);

			/*
			 *登録した機能間連携処理を親画面に感知させる。
			 *機能有効させる場合は、コメントアウトを外してください。
			 */
			//DetailUtil.RunPgSyn(this,(StandardBaseForm)base.GetPageContext().GetFormVO());

            #region 共通ヘッダ表示制御
            //LoginInfoVO loginInfVO = LoginInfoUtil.GetLoginInfo();
            ControlHeaderStoreCls.ControlSetHeaderStore(loginInfVO, Head_tenpo_cd, Btnheadtenpocd);
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
			ControlUtil.SetControlValue(Kbn_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Kbn_cd", lang), base.GetPageContext().FormInfo["Kbn_cd"]));
				DataFormatUtil.SetMustColorCaption(Kbn_cd_lbl, base.GetPageContext().FormInfo["Kbn_cd"]);
			ControlUtil.SetControlValue(Shinsei_flg_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Shinsei_flg", lang), base.GetPageContext().FormInfo["Shinsei_flg"]));
				DataFormatUtil.SetMustColorCaption(Shinsei_flg_lbl, base.GetPageContext().FormInfo["Shinsei_flg"]);
			ControlUtil.SetControlValue(Siiresaki_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Siiresaki_cd", lang), base.GetPageContext().FormInfo["Siiresaki_cd"]));
				DataFormatUtil.SetMustColorCaption(Siiresaki_cd_lbl, base.GetPageContext().FormInfo["Siiresaki_cd"]);
			ControlUtil.SetControlValue(Siiresaki_ryaku_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Siiresaki_ryaku_nm", lang), base.GetPageContext().FormInfo["Siiresaki_ryaku_nm"]));
				DataFormatUtil.SetMustColorCaption(Siiresaki_ryaku_nm_lbl, base.GetPageContext().FormInfo["Siiresaki_ryaku_nm"]);
			ControlUtil.SetControlValue(Bumon_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Bumon_cd", lang), base.GetPageContext().FormInfo["Bumon_cd"]));
				DataFormatUtil.SetMustColorCaption(Bumon_cd_lbl, base.GetPageContext().FormInfo["Bumon_cd"]);
			ControlUtil.SetControlValue(Bumon_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Bumon_nm", lang), base.GetPageContext().FormInfo["Bumon_nm"]));
				DataFormatUtil.SetMustColorCaption(Bumon_nm_lbl, base.GetPageContext().FormInfo["Bumon_nm"]);
			ControlUtil.SetControlValue(Burando_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Burando_cd", lang), base.GetPageContext().FormInfo["Burando_cd"]));
				DataFormatUtil.SetMustColorCaption(Burando_cd_lbl, base.GetPageContext().FormInfo["Burando_cd"]);
			ControlUtil.SetControlValue(Burando_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Burando_nm", lang), base.GetPageContext().FormInfo["Burando_nm"]));
				DataFormatUtil.SetMustColorCaption(Burando_nm_lbl, base.GetPageContext().FormInfo["Burando_nm"]);
			//ControlUtil.SetControlValue(Hattyu_ymd_from_lbl, 
			//	DataFormatUtil.GetFormatCaption(formResource.GetString("Hattyu_ymd_from", lang), base.GetPageContext().FormInfo["Hattyu_ymd_from"]));
				ControlUtil.SetControlValue(Hattyu_ymd_from_lbl, "発注日");
				DataFormatUtil.SetMustColorCaption(Hattyu_ymd_from_lbl, base.GetPageContext().FormInfo["Hattyu_ymd_from"]);
				ControlUtil.SetControlValue(Hattyu_ymd_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Hattyu_ymd_to", lang), base.GetPageContext().FormInfo["Hattyu_ymd_to"]));
				DataFormatUtil.SetMustColorCaption(Hattyu_ymd_to_lbl, base.GetPageContext().FormInfo["Hattyu_ymd_to"]);
			ControlUtil.SetControlValue(Old_jisya_hbn_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Old_jisya_hbn", lang), base.GetPageContext().FormInfo["Old_jisya_hbn"]));
				DataFormatUtil.SetMustColorCaption(Old_jisya_hbn_lbl, base.GetPageContext().FormInfo["Old_jisya_hbn"]);
			ControlUtil.SetControlValue(Maker_hbn_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Maker_hbn", lang), base.GetPageContext().FormInfo["Maker_hbn"]));
				DataFormatUtil.SetMustColorCaption(Maker_hbn_lbl, base.GetPageContext().FormInfo["Maker_hbn"]);
			ControlUtil.SetControlValue(Scan_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Scan_cd", lang), base.GetPageContext().FormInfo["Scan_cd"]));
				DataFormatUtil.SetMustColorCaption(Scan_cd_lbl, base.GetPageContext().FormInfo["Scan_cd"]);
			ControlUtil.SetControlValue(Gokei_itemsu_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Gokei_itemsu", lang), base.GetPageContext().FormInfo["Gokei_itemsu"]));
				DataFormatUtil.SetMustColorCaption(Gokei_itemsu_lbl, base.GetPageContext().FormInfo["Gokei_itemsu"]);
			ControlUtil.SetControlValue(Gokei_kingaku_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Gokei_kingaku", lang), base.GetPageContext().FormInfo["Gokei_kingaku"]));
				DataFormatUtil.SetMustColorCaption(Gokei_kingaku_lbl, base.GetPageContext().FormInfo["Gokei_kingaku"]);
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
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hojuirai_kbn_nm", lang), base.GetPageContext().FormInfo["M1hojuirai_kbn_nm"]);
				// M1.Columns[2].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1sinsei_jotainm", lang), base.GetPageContext().FormInfo["M1sinsei_jotainm"]);
				// M1.Columns[3].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumon_cd_bo", lang), base.GetPageContext().FormInfo["M1bumon_cd_bo"]);
				// M1.Columns[4].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1itemsu", lang), base.GetPageContext().FormInfo["M1itemsu"]);
				// M1.Columns[5].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kingaku", lang), base.GetPageContext().FormInfo["M1kingaku"]);
				// M1.Columns[6].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1selectorcheckbox", lang), base.GetPageContext().FormInfo["M1selectorcheckbox"]);
				// M1.Columns[7].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1entersyoriflg", lang), base.GetPageContext().FormInfo["M1entersyoriflg"]);
				// M1.Columns[8].HeaderText = 
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
				Windowtitle.InnerText = formResource.GetString("Ta030f01_Titlebar", lang);
				header.FormName = formResource.GetString("Ta030f01_FormCaption", lang);
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
