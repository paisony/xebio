using com.xebio.bo.Ti040p01.Constant;
using com.xebio.bo.Ti040p01.Facade;
using com.xebio.bo.Ti040p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.Model.Context;
using Common.Advanced.Resource;
using Common.Advanced.Web.Context;
using Common.Advanced.Web.Util;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01008;
using Common.Business.C01000.C01013;
using Common.Business.C01000.C01014;
using Common.Business.C01000.C01015;
using Common.Business.C01000.C01016;
using Common.Business.C99999.Constant;
using Common.Business.C99999.StringUtil;
using Common.IntegrationMD.Util;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Util;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Ti040p01.Page
{
  /// <summary>
  /// Ti040f01のコードビハインドです。
  /// </summary>
  public partial class Ti040f01Page : StandardBasePage
	{

		#region メソッド

		#region ページデータをロードするメソッド
		/// <summary>
		/// Ti040f01画面データを作成する。
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
						pageContext.SetFormVO(new Ti040f01Form());
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
								new Ti040f01Facade().DoLoad(facadeContext);

                                #region 共通ヘッダ処理

                                // 一覧画面共通処理 ----------
                                LoginInfoVO loginInfVO = LoginInfoUtil.GetLoginInfo();
                                Ti040f01Form ti040f01Form = (Ti040f01Form)facadeContext.FormVO;
                                ControlHeaderStoreCls.InitialSetHeaderStore<Ti040f01Form>(loginInfVO, ti040f01Form);
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
				new Ti040f01Facade().DoBTNSEARCH_FRM(facadeContext);
				
				
				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
                    // アコーディオンなし
                    AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_NONE);

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

			LoginInfoVO loginInfVO = LoginInfoUtil.GetLoginInfo();

			//フォーカスを当てる項目を指定したい場合はFormFocusUtilを使ってqueryListに追加すること
            string focusItem = string.Empty;
            string focusMno  = string.Empty;

            // 権限取得部品の戻り値が"TRUE"の場合
            if (CheckKengenCls.CheckKengen(loginInfVO))
            {
                // 表示明細先頭の管理Noにフォーカス設定
                focusItem = "M1label_cd";
                focusMno  = (0).ToString();
            }
            // 権限取得部品の戻り値が"FALSE"の場合
            else
            {
                // 表示明細先頭の管理Noにフォーカス設定
                focusItem = "M1label_nm";
                focusMno  = (0).ToString();
            }

            // フォーカス設定
            SetFocusCls.SetFocus(queryList, focusItem, focusMno);			

			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNSEARCH_FRM");
			
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
				new Ti040f01Facade().DoBTNROWINS_MADD(facadeContext);
				
				
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

            // 画面より情報を取得する。
            Ti040f01Form formVO = (Ti040f01Form)pageContext.GetFormVO();

            //M1明細データを表示する。
            IDataList m1List = formVO.GetList("M1");

			//フォーカスを当てる項目を指定したい場合はFormFocusUtilを使ってqueryListに追加すること
            // フォーカス設定用変数
            string focusItem = string.Empty;
            string focusMno  = string.Empty;

            // 追加行のページを設定
            int endpage = (m1List.EndRow / m1List.DispRow) + 1;
            formVO.GetList("M1").SetPage(endpage);

            // 追加行の次の行にフォーカス設定
            focusItem = "M1label_cd";
            focusMno  = ((m1List.EndRow % m1List.DispRow) - 1).ToString();

            // フォーカス設定
            SetFocusCls.SetFocus(queryList, focusItem, focusMno);
			
			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNROWINS_MADD");
			
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

            // 行削除最終行
            decimal lastRow = 0;			

			try
			{

				//アクションロジックを処理します
				IFacadeContext facadeContext = FacadeContextFactory.GetFacadeContext(pageContext);
				InitFacadeContext(facadeContext);
				new Ti040f01Facade().DoBTNROWDEL_FRM(facadeContext);
				
				
				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
					base.SetError(pageContext);
					return;
				}

                // フォーカス行をコードビハインドに戻す
                lastRow = (decimal)facadeContext.GetUserObject(Ti040p01Constant.FCDUO_FOCUSROW);				

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
            string focusMno  = string.Empty;

            // 削除行の次の行にフォーカス設定
            focusItem = "M1label_cd";
            focusMno  = (lastRow).ToString();

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
                new Ti040f01Facade().DoPGR_PGN(facadeContext, pageindex);


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
				// 警告メッセージ用hidden項目がある場合、ファサードに渡す
				if (this.Request[BoSystemConstant.WARNING_HDNITEM_NM] != null)
				{
					facadeContext.SetUserObject(BoSystemConstant.WARNING_FCD_KEY, BoSystemString.Nvl(this.Request[BoSystemConstant.WARNING_HDNITEM_NM], "0"));
				}
				new Ti040f01Facade().DoBTNENTER_FRM(facadeContext);

				// 警告判定
				if (InfoMsgCls.HasWarn(facadeContext))
				{
					// 警告メッセージの表示
					string script = InfoMsgCls.showLoadMsg(pageContext, 2, "Btnenter");
					Page.ClientScript.RegisterStartupScript(typeof(string), "infoDialog", script);
					return;
				}
				
				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
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
						Ti040f01Form ti040f01Form = (Ti040f01Form)pageContext.GetFormVO();

						//明細ページ情報を表示する
						ShowListPageInfo(ti040f01Form);
			
						//明細部データを表示する
						RenderList(ti040f01Form, pageContext.FormInfo, formResource, lang);

						//カード部データを表示する
						RenderCard(ti040f01Form, pageContext.FormInfo, formResource, lang);
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
		/// <param name="ti040f01Form">画面FormVO</param>
		private void ShowListPageInfo(Ti040f01Form ti040f01Form)
		{
			//M1明細ページ情報を表示する。
			ShowM1ListPageInfo(ti040f01Form.GetList("M1"));

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
		/// <param name="ti040f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderList(
			Ti040f01Form ti040f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//画面のM1明細部データを設定する。
			RenderM1List(ti040f01Form, formInfo, formResource, lang);
            //M1明細部のページャーにページ情報を設定する。
            RenderM1Pager(ti040f01Form);
			
		}
		#endregion

		#region M1明細データを表示する
		/// <summary>
		/// M1明細データを表示する。
		/// </summary>
		/// <param name="ti040f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderM1List(
			Ti040f01Form ti040f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//M1明細部データソースを設定する。
			M1.DataSource = ti040f01Form.GetPageViewList("M1");
			M1.DataBind();

			//M1明細部データをフォーマットする。
			IList m1DataList = (IList)M1.DataSource;
			
			for (int index = 0; index < M1.Items.Count; index++)
			{
				Ti040f01M1Form ti040f01M1Form = (Ti040f01M1Form)m1DataList[index];
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1rowno"),
					DataFormatUtil.GetFormatItem(ti040f01M1Form.M1rowno,formInfo["M1rowno"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1label_cd"),
					DataFormatUtil.GetFormatItem(ti040f01M1Form.M1label_cd,formInfo["M1label_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1label_cd2"),
					DataFormatUtil.GetFormatItem(ti040f01M1Form.M1label_cd2,formInfo["M1label_cd2"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1label_ip"),
					DataFormatUtil.GetFormatItem(ti040f01M1Form.M1label_ip,formInfo["M1label_ip"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1label_ip2"),
					DataFormatUtil.GetFormatItem(ti040f01M1Form.M1label_ip2,formInfo["M1label_ip2"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1label_ip3"),
					DataFormatUtil.GetFormatItem(ti040f01M1Form.M1label_ip3,formInfo["M1label_ip3"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1label_ip4"),
					DataFormatUtil.GetFormatItem(ti040f01M1Form.M1label_ip4,formInfo["M1label_ip4"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1label_nm"),
					DataFormatUtil.GetFormatItem(ti040f01M1Form.M1label_nm,formInfo["M1label_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1label_biko"),
					DataFormatUtil.GetFormatItem(ti040f01M1Form.M1label_biko,formInfo["M1label_biko"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1selectorcheckbox"),
					DataFormatUtil.GetFormatItem(ti040f01M1Form.M1selectorcheckbox,formInfo["M1selectorcheckbox"]));
				((System.Web.UI.WebControls.CheckBox)M1.Items[index].FindControl("M1selectorcheckbox")).Text =
					formResource.GetString("M1selectorcheckbox", lang);
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1entersyoriflg"),
					DataFormatUtil.GetFormatItem(ti040f01M1Form.M1entersyoriflg,formInfo["M1entersyoriflg"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1dtlirokbn"),
					DataFormatUtil.GetFormatItem(ti040f01M1Form.M1dtlirokbn,formInfo["M1dtlirokbn"]));

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
				// (M1.HeaderRow.FindControl("M1label_cd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1label_cd", lang), base.GetPageContext().FormInfo["M1label_cd"]);
				// (M1.HeaderRow.FindControl("M1label_cd2") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1label_cd2", lang), base.GetPageContext().FormInfo["M1label_cd2"]);
				// (M1.HeaderRow.FindControl("M1label_ip") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1label_ip", lang), base.GetPageContext().FormInfo["M1label_ip"]);
				// (M1.HeaderRow.FindControl("M1label_ip2") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1label_ip2", lang), base.GetPageContext().FormInfo["M1label_ip2"]);
				// (M1.HeaderRow.FindControl("M1label_ip3") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1label_ip3", lang), base.GetPageContext().FormInfo["M1label_ip3"]);
				// (M1.HeaderRow.FindControl("M1label_ip4") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1label_ip4", lang), base.GetPageContext().FormInfo["M1label_ip4"]);
				// (M1.HeaderRow.FindControl("M1label_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1label_nm", lang), base.GetPageContext().FormInfo["M1label_nm"]);
				// (M1.HeaderRow.FindControl("M1label_biko") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1label_biko", lang), base.GetPageContext().FormInfo["M1label_biko"]);
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
        /// <param name="ti040f01Form">画面FormVO</param>
        private void RenderM1Pager(Ti040f01Form ti040f01Form)
        {
            Pgr.VirtualItemCount = ti040f01Form.GetList("M1").RecordCount;
            Pgr.CurrentPageIndex = ti040f01Form.GetList("M1").PageNo - 1;
            Pgr.PageSize = ti040f01Form.GetList("M1").DispRow;
        }
        #endregion        
        #endregion

		#region カードデータを表示する
		/// <summary>
		/// カードデータを表示する
		/// </summary>
		/// <param name="ti040f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderCard(
			Ti040f01Form ti040f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			
			ControlUtil.SetControlValue(Head_tenpo_cd,
				DataFormatUtil.GetFormatItem(ti040f01Form.Head_tenpo_cd,formInfo["Head_tenpo_cd"]));
			ControlUtil.SetControlValue(Head_tenpo_nm,
				DataFormatUtil.GetFormatItem(ti040f01Form.Head_tenpo_nm,formInfo["Head_tenpo_nm"]));
			ControlUtil.SetControlValue(Label_cd_from,
				DataFormatUtil.GetFormatItem(ti040f01Form.Label_cd_from,formInfo["Label_cd_from"]));
			ControlUtil.SetControlValue(Label_cd_from2,
				DataFormatUtil.GetFormatItem(ti040f01Form.Label_cd_from2,formInfo["Label_cd_from2"]));
			ControlUtil.SetControlValue(Label_cd_to,
				DataFormatUtil.GetFormatItem(ti040f01Form.Label_cd_to,formInfo["Label_cd_to"]));
			ControlUtil.SetControlValue(Label_cd_to2,
				DataFormatUtil.GetFormatItem(ti040f01Form.Label_cd_to2,formInfo["Label_cd_to2"]));
			ControlUtil.SetControlValue(Label_ip_from,
				DataFormatUtil.GetFormatItem(ti040f01Form.Label_ip_from,formInfo["Label_ip_from"]));
			ControlUtil.SetControlValue(Label_ip_from2,
				DataFormatUtil.GetFormatItem(ti040f01Form.Label_ip_from2,formInfo["Label_ip_from2"]));
			ControlUtil.SetControlValue(Label_ip_from3,
				DataFormatUtil.GetFormatItem(ti040f01Form.Label_ip_from3,formInfo["Label_ip_from3"]));
			ControlUtil.SetControlValue(Label_ip_from4,
				DataFormatUtil.GetFormatItem(ti040f01Form.Label_ip_from4,formInfo["Label_ip_from4"]));
			ControlUtil.SetControlValue(Label_ip_to,
				DataFormatUtil.GetFormatItem(ti040f01Form.Label_ip_to,formInfo["Label_ip_to"]));
			ControlUtil.SetControlValue(Label_ip_to2,
				DataFormatUtil.GetFormatItem(ti040f01Form.Label_ip_to2,formInfo["Label_ip_to2"]));
			ControlUtil.SetControlValue(Label_ip_to3,
				DataFormatUtil.GetFormatItem(ti040f01Form.Label_ip_to3,formInfo["Label_ip_to3"]));
			ControlUtil.SetControlValue(Label_ip_to4,
				DataFormatUtil.GetFormatItem(ti040f01Form.Label_ip_to4,formInfo["Label_ip_to4"]));
			ControlUtil.SetControlValue(Label_nm,
				DataFormatUtil.GetFormatItem(ti040f01Form.Label_nm,formInfo["Label_nm"]));
			ControlUtil.SetControlValue(Label_biko,
				DataFormatUtil.GetFormatItem(ti040f01Form.Label_biko,formInfo["Label_biko"]));
            ControlUtil.SetControlValue(Searchcnt,
                DataFormatUtil.GetFormatItem(ti040f01Form.Searchcnt, formInfo["Searchcnt"]));

			if(!base.CheckUseSelfCustomize()){
				Btnheadtenpocd.Value = base.FormResourceGetString(formResource, "Btnheadtenpocd", lang);
				Btnsearch.Value = base.FormResourceGetString(formResource, "Btnsearch", lang);
				Btnrowins.Value = base.FormResourceGetString(formResource, "Btnrowins", lang);
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
			// UIScreenController controller = new UIScreenController((Ti040f01Form)base.GetPageContext().GetFormVO());
			// controller.ChangeColumnsDisplayMode(M1 ,  new DetailHeaderFixedVO(M1Header , true) , null);

			/*
			 *登録した機能間連携処理を親画面に感知させる。
			 *機能有効させる場合は、コメントアウトを外してください。
			 */
			//DetailUtil.RunPgSyn(this,(StandardBaseForm)base.GetPageContext().GetFormVO());

            LoginInfoVO loginInfVO = LoginInfoUtil.GetLoginInfo();

            //アクションコンテキストを取得する
            IPageContext pageContext = base.GetPageContext();
            //IFacadeContext facadeContext = FacadeContextFactory.GetFacadeContext(pageContext);

            #region 共通ヘッダ表示制御
            ControlHeaderStoreCls.ControlSetHeaderStore(loginInfVO, Head_tenpo_cd, Btnheadtenpocd);
            #endregion

            #region 画面表示制御

            if ("INI".Equals(base.GetPageContext().CommandInfo.ActionMode))
            {
                // 明細ボタン部を非表示とする
                ControlCls.Visible(meisaiBtnArea, false);
                // フッター部を非表示とする
                ControlCls.Visible(footerBtnArea, false);
            }
            else
            {
                // 明細ボタン部を表示する
                ControlCls.Visible(meisaiBtnArea, true);
                // フッター部を表示する
                ControlCls.Visible(footerBtnArea, true);
            }


            // 権限取得部品の戻り値が"FALSE"の場合
            if (!CheckKengenCls.CheckKengen(loginInfVO))
            {
                // 行追加ボタン使用不可
                ControlCls.Disable(Btnrowins, true);
                // 行削除ボタン使用不可
                ControlCls.Disable(Btnrowdel, true);
            }
            else
            {
                // 行追加ボタン使用可
                ControlCls.Disable(Btnrowins, false);
                // 行削除ボタン使用可
                ControlCls.Disable(Btnrowdel, false);
            }

            #endregion

            // 画面より情報を取得する。
            Ti040f01Form formVO = (Ti040f01Form)pageContext.GetFormVO();

            //M1明細データを表示する。
            //IDataList m1List = formVO.GetList("M1");

            #region 明細画面表示制御

            //// 明細行を選択不可にする。
            //for (int i = 0; i < M1.Items.Count; i++)
            //{
            //    ((Common.Advanced.Web.Control.AdvancedCheckBox)M1.Items[i].FindControl("M1selectorcheckbox")).Visible = false;
            //}

            // 権限取得部品の戻り値が"FALSE"の場合
            if (!CheckKengenCls.CheckKengen(loginInfVO))
            {
                for (int i = 0; i < M1.Items.Count; i++)
                {
                    //ｍ１ラベル発行機ｉｄ
                    ControlCls.Disable(((TextBox)M1.Items[i].FindControl("M1label_cd")), true);
                    //ｍ１ラベル発行機ｉｄ2
                    ControlCls.Disable(((TextBox)M1.Items[i].FindControl("M1label_cd2")), true);

                    //ｍ１ラベル発行機ｉｐ
                    ControlCls.Disable(((TextBox)M1.Items[i].FindControl("M1label_ip")), true);
                    //ｍ１ラベル発行機ｉｐ2
                    ControlCls.Disable(((TextBox)M1.Items[i].FindControl("M1label_ip2")), true);
                    //ｍ１ラベル発行機ｉｐ3
                    ControlCls.Disable(((TextBox)M1.Items[i].FindControl("M1label_ip3")), true);
                    //ｍ１ラベル発行機ｉｐ4
                    ControlCls.Disable(((TextBox)M1.Items[i].FindControl("M1label_ip4")), true);
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
			//ControlUtil.SetControlValue(Label_cd_from_lbl,
			//	DataFormatUtil.GetFormatCaption(formResource.GetString("Label_cd_from", lang), base.GetPageContext().FormInfo["Label_cd_from"]));
				ControlUtil.SetControlValue(Label_cd_from_lbl, "ラベル発行機ＩＤ");
				DataFormatUtil.SetMustColorCaption(Label_cd_from_lbl, base.GetPageContext().FormInfo["Label_cd_from"]);
			ControlUtil.SetControlValue(Label_cd_from2_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Label_cd_from2", lang), base.GetPageContext().FormInfo["Label_cd_from2"]));
				DataFormatUtil.SetMustColorCaption(Label_cd_from2_lbl, base.GetPageContext().FormInfo["Label_cd_from2"]);
			ControlUtil.SetControlValue(Label_cd_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Label_cd_to", lang), base.GetPageContext().FormInfo["Label_cd_to"]));
				DataFormatUtil.SetMustColorCaption(Label_cd_to_lbl, base.GetPageContext().FormInfo["Label_cd_to"]);
			ControlUtil.SetControlValue(Label_cd_to2_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Label_cd_to2", lang), base.GetPageContext().FormInfo["Label_cd_to2"]));
				DataFormatUtil.SetMustColorCaption(Label_cd_to2_lbl, base.GetPageContext().FormInfo["Label_cd_to2"]);
			//ControlUtil.SetControlValue(Label_ip_from_lbl, 
				//	DataFormatUtil.GetFormatCaption(formResource.GetString("Label_ip_from", lang), base.GetPageContext().FormInfo["Label_ip_from"]));
				ControlUtil.SetControlValue(Label_ip_from_lbl, "ラベル発行機ＩＰ");
				DataFormatUtil.SetMustColorCaption(Label_ip_from_lbl, base.GetPageContext().FormInfo["Label_ip_from"]);
			ControlUtil.SetControlValue(Label_ip_from2_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Label_ip_from2", lang), base.GetPageContext().FormInfo["Label_ip_from2"]));
				DataFormatUtil.SetMustColorCaption(Label_ip_from2_lbl, base.GetPageContext().FormInfo["Label_ip_from2"]);
			ControlUtil.SetControlValue(Label_ip_from3_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Label_ip_from3", lang), base.GetPageContext().FormInfo["Label_ip_from3"]));
				DataFormatUtil.SetMustColorCaption(Label_ip_from3_lbl, base.GetPageContext().FormInfo["Label_ip_from3"]);
			ControlUtil.SetControlValue(Label_ip_from4_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Label_ip_from4", lang), base.GetPageContext().FormInfo["Label_ip_from4"]));
				DataFormatUtil.SetMustColorCaption(Label_ip_from4_lbl, base.GetPageContext().FormInfo["Label_ip_from4"]);
			ControlUtil.SetControlValue(Label_ip_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Label_ip_to", lang), base.GetPageContext().FormInfo["Label_ip_to"]));
				DataFormatUtil.SetMustColorCaption(Label_ip_to_lbl, base.GetPageContext().FormInfo["Label_ip_to"]);
			ControlUtil.SetControlValue(Label_ip_to2_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Label_ip_to2", lang), base.GetPageContext().FormInfo["Label_ip_to2"]));
				DataFormatUtil.SetMustColorCaption(Label_ip_to2_lbl, base.GetPageContext().FormInfo["Label_ip_to2"]);
			ControlUtil.SetControlValue(Label_ip_to3_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Label_ip_to3", lang), base.GetPageContext().FormInfo["Label_ip_to3"]));
				DataFormatUtil.SetMustColorCaption(Label_ip_to3_lbl, base.GetPageContext().FormInfo["Label_ip_to3"]);
			ControlUtil.SetControlValue(Label_ip_to4_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Label_ip_to4", lang), base.GetPageContext().FormInfo["Label_ip_to4"]));
				DataFormatUtil.SetMustColorCaption(Label_ip_to4_lbl, base.GetPageContext().FormInfo["Label_ip_to4"]);
			ControlUtil.SetControlValue(Label_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Label_nm", lang), base.GetPageContext().FormInfo["Label_nm"]));
				DataFormatUtil.SetMustColorCaption(Label_nm_lbl, base.GetPageContext().FormInfo["Label_nm"]);
			ControlUtil.SetControlValue(Label_biko_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Label_biko", lang), base.GetPageContext().FormInfo["Label_biko"]));
				DataFormatUtil.SetMustColorCaption(Label_biko_lbl, base.GetPageContext().FormInfo["Label_biko"]);
            ControlUtil.SetControlValue(Searchcnt_lbl,
                DataFormatUtil.GetFormatCaption(formResource.GetString("Searchcnt", lang), base.GetPageContext().FormInfo["Searchcnt"]));
                DataFormatUtil.SetMustColorCaption(Searchcnt_lbl, base.GetPageContext().FormInfo["Searchcnt"]);
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
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1label_cd", lang), base.GetPageContext().FormInfo["M1label_cd"]);
				// M1.Columns[2].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1label_cd2", lang), base.GetPageContext().FormInfo["M1label_cd2"]);
				// M1.Columns[3].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1label_ip", lang), base.GetPageContext().FormInfo["M1label_ip"]);
				// M1.Columns[4].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1label_ip2", lang), base.GetPageContext().FormInfo["M1label_ip2"]);
				// M1.Columns[5].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1label_ip3", lang), base.GetPageContext().FormInfo["M1label_ip3"]);
				// M1.Columns[6].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1label_ip4", lang), base.GetPageContext().FormInfo["M1label_ip4"]);
				// M1.Columns[7].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1label_nm", lang), base.GetPageContext().FormInfo["M1label_nm"]);
				// M1.Columns[8].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1label_biko", lang), base.GetPageContext().FormInfo["M1label_biko"]);
				// M1.Columns[9].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1selectorcheckbox", lang), base.GetPageContext().FormInfo["M1selectorcheckbox"]);
				// M1.Columns[10].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1entersyoriflg", lang), base.GetPageContext().FormInfo["M1entersyoriflg"]);
				// M1.Columns[11].HeaderText = 
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
				Windowtitle.InnerText = formResource.GetString("Ti040f01_Titlebar", lang);
				header.FormName = formResource.GetString("Ti040f01_FormCaption", lang);
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
