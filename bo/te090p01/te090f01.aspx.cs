using com.xebio.bo.Te090p01.Constant;
using com.xebio.bo.Te090p01.Facade;
using com.xebio.bo.Te090p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.Model.Context;
using Common.Advanced.Resource;
using Common.Advanced.Web.Context;
using Common.Advanced.Web.Util;
using Common.Business.C01000.C01013;
using Common.Business.C01000.C01014;
using Common.Business.C01000.C01015;
using Common.Business.C01000.C01016;
using Common.Business.C01000.C01026;
using Common.Business.C99999.Constant;
using Common.Business.C99999.StringUtil;
using Common.Conditions;
using Common.IntegrationMD.Util;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Util;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Drawing;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Te090p01.Page
{
  /// <summary>
  /// Te090f01のコードビハインドです。
  /// </summary>
  public partial class Te090f01Page : StandardBasePage
	{

		#region メソッド

		#region ページデータをロードするメソッド
		/// <summary>
		/// Te090f01画面データを作成する。
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
						pageContext.SetFormVO(new Te090f01Form());
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
								new Te090f01Facade().DoLoad(facadeContext);

								// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
								#region 共通ヘッダ処理
								// 一覧画面共通処理 ----------
								LoginInfoVO loginInfVO = LoginInfoUtil.GetLoginInfo();
								Te090f01Form te090f01Form = (Te090f01Form)facadeContext.FormVO;
								ControlHeaderStoreCls.InitialSetHeaderStore<Te090f01Form>(loginInfVO, te090f01Form);
								// 一覧画面共通処理 ----------

								if (string.IsNullOrEmpty(te090f01Form.Modeno))
								{
									// アコーディオンなし
									AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_NONE);
									// モードNoを入荷確定に設定
									te090f01Form.Modeno = BoSystemConstant.MODE_NYUKAKAKUTEI;
									TabUtil.SetTabNumber(pageContext, BoSystemConstant.MODE_NYUKAKAKUTEI);
								}
								#endregion
								// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

								break;
						}
					}
				}
				else
				{
					//メッセージの初期化
					base.InitMessage();
				}

				// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
				// モードNoをセッションに格納
				if (base.GetPageContext() != null)
				{
					FormVOManager fvm = new FormVOManager(Session);
					Te090f01Form f01VO = (Te090f01Form)fvm.GetProgramVO(base.GetPageContext().CommandInfo.ProgramId).GetFormVO(Te090p01Constant.FORMID_01);
					TabUtil.SetTabNumber(base.GetPageContext(), f01VO.Modeno);
				}
				// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

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

				// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
				//アクションコンテキストを取得する
				pageContext = base.GetPageContext();
				// モード表示クリア処理
				ModeUtil.ClearMode(pageContext);
				// 明細初期化処理
				Page.ClientScript.RegisterStartupScript(typeof(string), "InitialDetail", ControlCls.InitialDetail(base.GetPageContext()));
				// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

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
				new Te090f01Facade().DoBTNSEARCH_FRM(facadeContext);
				
				
				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
					// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
					// アコーディオンなし
					AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_NONE);
					// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

					base.SetError(pageContext);
					return;
				}

				// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
				//アコーディオンを閉じた状態で表示
				AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_CLOSE);

				//アコーディオンを閉じた際に表示される検索条件を設定する。
				AccordionUtil.ResetSearchCondition(pageContext);

				// モードを設定 
				ModeUtil.SetMode(pageContext, ModeCls.GetModeNm(((Te090f01Form)pageContext.GetFormVO()).Stkmodeno));
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
			SetFocusCls.SetFocus(queryList, "M1denpyo_bango", "0");
			// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

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
				new Te090f01Facade().DoPGR_PGN(facadeContext, pageindex);
				
				
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
		
		#region フォームを呼び出します(ボタンID : M1denpyo_bango(伝票番号))
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(M1denpyo_bango(伝票番号))
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnM1DENPYO_BANGO_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnM1DENPYO_BANGO_FRM");
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

				// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
				// 明細画面オブジェクトをファサードコンテキストに設定
				Te090f02Form nextVO = (Te090f02Form)new FormVOManager(Session).GetFormVO(Te090p01Constant.PGID, Te090p01Constant.FORMID_02);
				facadeContext.SetUserObject(Te090p01Constant.FCDUO_NEXTVO, nextVO);
				// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

				new Te090f01Facade().DoM1DENPYO_BANGO_FRM(facadeContext);
				
				
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

			// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
			Te090f01Form form = (Te090f01Form)pageContext.GetFormVO();
			Te090f01M1Form selRow = (Te090f01M1Form)form.GetPageViewList("M1")[commandInfo.ListIndex];

			if	(	(	form.Stkmodeno.Equals(BoSystemConstant.MODE_NYUKAKAKUTEI)			// 入荷確定モード
					&&	selRow.M1entersyoriflg.Equals(ConditionKakuteisyori_flg.VALUE_NASI)	// 未確定
					)
				||	form.Stkmodeno.Equals(BoSystemConstant.MODE_KAKUTEIGOUPD)	// 確定後修正モード
				)
			{
				// （[選択モードNO]が「入荷確定」、かつ[Ｍ１確定処理フラグ]が"0"（未確定））、または[選択モードNO]が「確定後修正」の場合
				// フォーカス設定
				SetFocusCls.SetFocus(queryList, "M1kakutei_su", "0");
			}
			// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnM1DENPYO_BANGO_FRM");
			
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
				new Te090f01Facade().DoBTNENTER_FRM(facadeContext);
				
				
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
						Te090f01Form te090f01Form = (Te090f01Form)pageContext.GetFormVO();

						//明細ページ情報を表示する
						ShowListPageInfo(te090f01Form);
			
						//明細部データを表示する
						RenderList(te090f01Form, pageContext.FormInfo, formResource, lang);

						//カード部データを表示する
						RenderCard(te090f01Form, pageContext.FormInfo, formResource, lang);
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
		/// <param name="te090f01Form">画面FormVO</param>
		private void ShowListPageInfo(Te090f01Form te090f01Form)
		{
			//M1明細ページ情報を表示する。
			ShowM1ListPageInfo(te090f01Form.GetList("M1"));

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
		/// <param name="te090f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderList(
			Te090f01Form te090f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//画面のM1明細部データを設定する。
			RenderM1List(te090f01Form, formInfo, formResource, lang);
			//M1明細部のページャーにページ情報を設定する。
			RenderM1Pager(te090f01Form);
			
		}
		#endregion

		#region M1明細データを表示する
		/// <summary>
		/// M1明細データを表示する。
		/// </summary>
		/// <param name="te090f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderM1List(
			Te090f01Form te090f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//M1明細部データソースを設定する。
			M1.DataSource = te090f01Form.GetPageViewList("M1");
			M1.DataBind();

			//M1明細部データをフォーマットする。
			IList m1DataList = (IList)M1.DataSource;
			
			for (int index = 0; index < M1.Items.Count; index++)
			{
				Te090f01M1Form te090f01M1Form = (Te090f01M1Form)m1DataList[index];
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1rowno"),
					DataFormatUtil.GetFormatItem(te090f01M1Form.M1rowno,formInfo["M1rowno"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1kaisyakana_nm"),
					DataFormatUtil.GetFormatItem(te090f01M1Form.M1kaisyakana_nm,formInfo["M1kaisyakana_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1syukkaten_cd"),
					DataFormatUtil.GetFormatItem(te090f01M1Form.M1syukkaten_cd,formInfo["M1syukkaten_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1syukkaten_nm"),
					DataFormatUtil.GetFormatItem(te090f01M1Form.M1syukkaten_nm,formInfo["M1syukkaten_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1scm_cd"),
					DataFormatUtil.GetFormatItem(te090f01M1Form.M1scm_cd,formInfo["M1scm_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1syukka_ymd"),
					DataFormatUtil.GetFormatItem(te090f01M1Form.M1syukka_ymd,formInfo["M1syukka_ymd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1jyuryo_ymd"),
					DataFormatUtil.GetFormatItem(te090f01M1Form.M1jyuryo_ymd,formInfo["M1jyuryo_ymd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1yotei_su"),
					DataFormatUtil.GetFormatItem(te090f01M1Form.M1yotei_su,formInfo["M1yotei_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1kakutei_su"),
					DataFormatUtil.GetFormatItem(te090f01M1Form.M1kakutei_su,formInfo["M1kakutei_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1kyakucyu"),
					DataFormatUtil.GetFormatItem(te090f01M1Form.M1kyakucyu,formInfo["M1kyakucyu"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1negaki"),
					DataFormatUtil.GetFormatItem(te090f01M1Form.M1negaki,formInfo["M1negaki"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1denpyo_jyotainm"),
					DataFormatUtil.GetFormatItem(te090f01M1Form.M1denpyo_jyotainm,formInfo["M1denpyo_jyotainm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1selectorcheckbox"),
					DataFormatUtil.GetFormatItem(te090f01M1Form.M1selectorcheckbox,formInfo["M1selectorcheckbox"]));
				((System.Web.UI.WebControls.CheckBox)M1.Items[index].FindControl("M1selectorcheckbox")).Text =
					formResource.GetString("M1selectorcheckbox", lang);
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1entersyoriflg"),
					DataFormatUtil.GetFormatItem(te090f01M1Form.M1entersyoriflg,formInfo["M1entersyoriflg"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1dtlirokbn"),
					DataFormatUtil.GetFormatItem(te090f01M1Form.M1dtlirokbn,formInfo["M1dtlirokbn"]));

				if(!base.CheckUseSelfCustomize()){
					//((System.Web.UI.HtmlControls.HtmlInputButton)M1.Items[index].FindControl("M1denpyo_bango")).Value =
					//	formResource.GetString("M1denpyo_bango", lang);

					// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
					// ボタンのValueに伝票番号を設定
					((System.Web.UI.HtmlControls.HtmlInputButton)M1.Items[index].FindControl("M1denpyo_bango")).Value =
						te090f01M1Form.Dictionary[Te090p01Constant.DIC_M1DENPYO_BANGO].ToString();

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
				// (M1.HeaderRow.FindControl("M1kaisyakana_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kaisyakana_nm", lang), base.GetPageContext().FormInfo["M1kaisyakana_nm"]);
				// (M1.HeaderRow.FindControl("M1syukkaten_cd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syukkaten_cd", lang), base.GetPageContext().FormInfo["M1syukkaten_cd"]);
				// (M1.HeaderRow.FindControl("M1syukkaten_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syukkaten_nm", lang), base.GetPageContext().FormInfo["M1syukkaten_nm"]);
				// (M1.HeaderRow.FindControl("M1scm_cd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1scm_cd", lang), base.GetPageContext().FormInfo["M1scm_cd"]);
				// (M1.HeaderRow.FindControl("M1denpyo_bango") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1denpyo_bango", lang), base.GetPageContext().FormInfo["M1denpyo_bango"]);
				// (M1.HeaderRow.FindControl("M1syukka_ymd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syukka_ymd", lang), base.GetPageContext().FormInfo["M1syukka_ymd"]);
				// (M1.HeaderRow.FindControl("M1jyuryo_ymd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1jyuryo_ymd", lang), base.GetPageContext().FormInfo["M1jyuryo_ymd"]);
				// (M1.HeaderRow.FindControl("M1yotei_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1yotei_su", lang), base.GetPageContext().FormInfo["M1yotei_su"]);
				// (M1.HeaderRow.FindControl("M1kakutei_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kakutei_su", lang), base.GetPageContext().FormInfo["M1kakutei_su"]);
				// (M1.HeaderRow.FindControl("M1kyakucyu") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kyakucyu", lang), base.GetPageContext().FormInfo["M1kyakucyu"]);
				// (M1.HeaderRow.FindControl("M1negaki") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1negaki", lang), base.GetPageContext().FormInfo["M1negaki"]);
				// (M1.HeaderRow.FindControl("M1denpyo_jyotainm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1denpyo_jyotainm", lang), base.GetPageContext().FormInfo["M1denpyo_jyotainm"]);
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
		/// <param name="te090f01Form">画面FormVO</param>
		private void RenderM1Pager(Te090f01Form te090f01Form)
		{
			Pgr.VirtualItemCount = te090f01Form.GetList("M1").RecordCount;
			Pgr.CurrentPageIndex = te090f01Form.GetList("M1").PageNo - 1;
			Pgr.PageSize = te090f01Form.GetList("M1").DispRow;
		}
		#endregion
		#endregion

		#region カードデータを表示する
		/// <summary>
		/// カードデータを表示する
		/// </summary>
		/// <param name="te090f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderCard(
			Te090f01Form te090f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			
			ControlUtil.SetControlValue(Head_tenpo_cd,
				DataFormatUtil.GetFormatItem(te090f01Form.Head_tenpo_cd,formInfo["Head_tenpo_cd"]));
			ControlUtil.SetControlValue(Head_tenpo_nm,
				DataFormatUtil.GetFormatItem(te090f01Form.Head_tenpo_nm,formInfo["Head_tenpo_nm"]));
			ControlUtil.SetControlValue(Modeno,
				DataFormatUtil.GetFormatItem(te090f01Form.Modeno,formInfo["Modeno"]));
			ControlUtil.SetControlValue(Stkmodeno,
				DataFormatUtil.GetFormatItem(te090f01Form.Stkmodeno,formInfo["Stkmodeno"]));
			ControlUtil.SetControlValue(Kaisya_cd,
				DataFormatUtil.GetFormatItem(te090f01Form.Kaisya_cd,formInfo["Kaisya_cd"]));
			ControlUtil.SetControlValue(Kaisya_nm,
				DataFormatUtil.GetFormatItem(te090f01Form.Kaisya_nm,formInfo["Kaisya_nm"]));
			ControlUtil.SetControlValue(Syukkaten_cd,
				DataFormatUtil.GetFormatItem(te090f01Form.Syukkaten_cd,formInfo["Syukkaten_cd"]));
			ControlUtil.SetControlValue(Syukkaten_nm,
				DataFormatUtil.GetFormatItem(te090f01Form.Syukkaten_nm,formInfo["Syukkaten_nm"]));
			ControlUtil.SetControlValue(Denpyo_bango_from,
				DataFormatUtil.GetFormatItem(te090f01Form.Denpyo_bango_from,formInfo["Denpyo_bango_from"]));
			ControlUtil.SetControlValue(Denpyo_bango_to,
				DataFormatUtil.GetFormatItem(te090f01Form.Denpyo_bango_to,formInfo["Denpyo_bango_to"]));
			ControlUtil.SetControlValue(Scm_cd,
				DataFormatUtil.GetFormatItem(te090f01Form.Scm_cd,formInfo["Scm_cd"]));
			ControlUtil.SetControlValue(Syukka_ymd_from,
				DataFormatUtil.GetFormatItem(te090f01Form.Syukka_ymd_from,formInfo["Syukka_ymd_from"]));
			ControlUtil.SetControlValue(Syukka_ymd_to,
				DataFormatUtil.GetFormatItem(te090f01Form.Syukka_ymd_to,formInfo["Syukka_ymd_to"]));
			ControlUtil.SetControlValue(Searchcnt,
				DataFormatUtil.GetFormatItem(te090f01Form.Searchcnt,formInfo["Searchcnt"]));

			if(!base.CheckUseSelfCustomize()){
				Btnheadtenpocd.Value = base.FormResourceGetString(formResource, "Btnheadtenpocd", lang);
				Btnmodenyukakakutei.InnerText = base.FormResourceGetString(formResource, "Btnmodenyukakakutei", lang);
				Btnmodekakuteigoupd.InnerText = base.FormResourceGetString(formResource, "Btnmodekakuteigoupd", lang);
				Btnmodekakuteigodel.InnerText = base.FormResourceGetString(formResource, "Btnmodekakuteigodel", lang);
				Btnmoderef.InnerText = base.FormResourceGetString(formResource, "Btnmoderef", lang);
				Btnkaisha_cd.Value = base.FormResourceGetString(formResource, "Btnkaisha_cd", lang);
				Btnsyukkatencd.Value = base.FormResourceGetString(formResource, "Btnsyukkatencd", lang);
				Btnsearch.Value = base.FormResourceGetString(formResource, "Btnsearch", lang);
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
			// UIScreenController controller = new UIScreenController((Te090f01Form)base.GetPageContext().GetFormVO());
			// controller.ChangeColumnsDisplayMode(M1 ,  new DetailHeaderFixedVO(M1Header , true) , null);

			/*
			 *登録した機能間連携処理を親画面に感知させる。
			 *機能有効させる場合は、コメントアウトを外してください。
			 */
			//DetailUtil.RunPgSyn(this,(StandardBaseForm)base.GetPageContext().GetFormVO());

			// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
			#region 共通ヘッダ表示制御
			LoginInfoVO loginInfVO = LoginInfoUtil.GetLoginInfo();
			ControlHeaderStoreCls.ControlSetHeaderStore(loginInfVO, Head_tenpo_cd, Btnheadtenpocd);
			#endregion

			#region 画面表示制御
			if (base.GetPageContext().CommandInfo.ActionMode.Equals("INI"))
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

			Te090f01Form formVo = (Te090f01Form)base.GetPageContext().GetFormVO();

			for (int i = 0; i < this.M1.Items.Count; i++)
			{
				TextBox ctlM1YoteiSu = (TextBox)this.M1.Items[i].FindControl("M1YOTEI_SU");		// Ｍ１予定数量
				TextBox ctlM1KakuteiSu = (TextBox)this.M1.Items[i].FindControl("M1KAKUTEI_SU");	// Ｍ１確定数量

				if (!ctlM1YoteiSu.Text.Equals(ctlM1KakuteiSu.Text))
				{
					// Ｍ１予定数量≠Ｍ１確定数量の場合
					ctlM1KakuteiSu.ForeColor = Color.Red;	// 文字色を赤
				}
			}

			if (BoSystemString.Nvl(formVo.Stkmodeno).Equals(BoSystemConstant.MODE_KAKUTEIGOUPD)
				|| BoSystemString.Nvl(formVo.Stkmodeno).Equals(BoSystemConstant.MODE_REF))
			{
				// [選択モードNo]が「確定後修正」「照会」の場合
				// 確定ボタン使用不可
				ControlCls.Disable(Btnenter, true);
			}
			else
			{
				// それ以外の場合
				// 確定ボタン使用可
				ControlCls.Disable(Btnenter, false);
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
			ControlUtil.SetControlValue(Kaisya_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Kaisya_cd", lang), base.GetPageContext().FormInfo["Kaisya_cd"]));
				DataFormatUtil.SetMustColorCaption(Kaisya_cd_lbl, base.GetPageContext().FormInfo["Kaisya_cd"]);
			ControlUtil.SetControlValue(Kaisya_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Kaisya_nm", lang), base.GetPageContext().FormInfo["Kaisya_nm"]));
				DataFormatUtil.SetMustColorCaption(Kaisya_nm_lbl, base.GetPageContext().FormInfo["Kaisya_nm"]);
			ControlUtil.SetControlValue(Syukkaten_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Syukkaten_cd", lang), base.GetPageContext().FormInfo["Syukkaten_cd"]));
				DataFormatUtil.SetMustColorCaption(Syukkaten_cd_lbl, base.GetPageContext().FormInfo["Syukkaten_cd"]);
			ControlUtil.SetControlValue(Syukkaten_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Syukkaten_nm", lang), base.GetPageContext().FormInfo["Syukkaten_nm"]));
				DataFormatUtil.SetMustColorCaption(Syukkaten_nm_lbl, base.GetPageContext().FormInfo["Syukkaten_nm"]);
			//ControlUtil.SetControlValue(Denpyo_bango_from_lbl, 
			//	DataFormatUtil.GetFormatCaption(formResource.GetString("Denpyo_bango_from", lang), base.GetPageContext().FormInfo["Denpyo_bango_from"]));
			ControlUtil.SetControlValue(Denpyo_bango_from_lbl, "伝票番号");
				DataFormatUtil.SetMustColorCaption(Denpyo_bango_from_lbl, base.GetPageContext().FormInfo["Denpyo_bango_from"]);
			ControlUtil.SetControlValue(Denpyo_bango_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Denpyo_bango_to", lang), base.GetPageContext().FormInfo["Denpyo_bango_to"]));
				DataFormatUtil.SetMustColorCaption(Denpyo_bango_to_lbl, base.GetPageContext().FormInfo["Denpyo_bango_to"]);
			ControlUtil.SetControlValue(Scm_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Scm_cd", lang), base.GetPageContext().FormInfo["Scm_cd"]));
				DataFormatUtil.SetMustColorCaption(Scm_cd_lbl, base.GetPageContext().FormInfo["Scm_cd"]);
			//ControlUtil.SetControlValue(Syukka_ymd_from_lbl, 
			//	DataFormatUtil.GetFormatCaption(formResource.GetString("Syukka_ymd_from", lang), base.GetPageContext().FormInfo["Syukka_ymd_from"]));
			ControlUtil.SetControlValue(Syukka_ymd_from_lbl, "出荷日");
				DataFormatUtil.SetMustColorCaption(Syukka_ymd_from_lbl, base.GetPageContext().FormInfo["Syukka_ymd_from"]);
			ControlUtil.SetControlValue(Syukka_ymd_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Syukka_ymd_to", lang), base.GetPageContext().FormInfo["Syukka_ymd_to"]));
				DataFormatUtil.SetMustColorCaption(Syukka_ymd_to_lbl, base.GetPageContext().FormInfo["Syukka_ymd_to"]);
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
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kaisyakana_nm", lang), base.GetPageContext().FormInfo["M1kaisyakana_nm"]);
				// M1.Columns[2].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syukkaten_cd", lang), base.GetPageContext().FormInfo["M1syukkaten_cd"]);
				// M1.Columns[3].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syukkaten_nm", lang), base.GetPageContext().FormInfo["M1syukkaten_nm"]);
				// M1.Columns[4].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1scm_cd", lang), base.GetPageContext().FormInfo["M1scm_cd"]);
				// M1.Columns[5].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1denpyo_bango", lang), base.GetPageContext().FormInfo["M1denpyo_bango"]);
				// M1.Columns[6].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syukka_ymd", lang), base.GetPageContext().FormInfo["M1syukka_ymd"]);
				// M1.Columns[7].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1jyuryo_ymd", lang), base.GetPageContext().FormInfo["M1jyuryo_ymd"]);
				// M1.Columns[8].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1yotei_su", lang), base.GetPageContext().FormInfo["M1yotei_su"]);
				// M1.Columns[9].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kakutei_su", lang), base.GetPageContext().FormInfo["M1kakutei_su"]);
				// M1.Columns[10].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kyakucyu", lang), base.GetPageContext().FormInfo["M1kyakucyu"]);
				// M1.Columns[11].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1negaki", lang), base.GetPageContext().FormInfo["M1negaki"]);
				// M1.Columns[12].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1denpyo_jyotainm", lang), base.GetPageContext().FormInfo["M1denpyo_jyotainm"]);
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
				Windowtitle.InnerText = formResource.GetString("Te090f01_Titlebar", lang);
				header.FormName = formResource.GetString("Te090f01_FormCaption", lang);
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
