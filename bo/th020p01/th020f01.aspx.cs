using com.xebio.bo.Th020p01.Constant;
using com.xebio.bo.Th020p01.Facade;
using com.xebio.bo.Th020p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.Model.Context;
using Common.Advanced.Resource;
using Common.Advanced.Web.Context;
using Common.Advanced.Web.Util;
using Common.Business.C01000.C01013;
using Common.Business.C01000.C01014;
using Common.Business.C01000.C01015;
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

namespace com.xebio.bo.Th020p01.Page
{
  /// <summary>
  /// Th020f01のコードビハインドです。
  /// </summary>
  public partial class Th020f01Page : StandardBasePage
	{

		#region メソッド

		#region ページデータをロードするメソッド
		/// <summary>
		/// Th020f01画面データを作成する。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected new void Page_Load(object sender, System.EventArgs e)
		{
			IPageContext pageContext = null;
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".Page_Load");
			bool bjisyaHbnFlg = false;

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
						pageContext.SetFormVO(new Th020f01Form());
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
								new Th020f01Facade().DoLoad(facadeContext);

								#region 共通ヘッダ処理

								// 一覧画面共通処理 ----------
								LoginInfoVO loginInfVO = LoginInfoUtil.GetLoginInfo();
								Th020f01Form th010f01Form = (Th020f01Form)facadeContext.FormVO;
								ControlHeaderStoreCls.InitialSetHeaderStore<Th020f01Form>(loginInfVO, th010f01Form);
								// 一覧画面共通処理 ----------

								if (string.IsNullOrEmpty(th010f01Form.Modeno))
								{
									// アコーディオンなし
									AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_NONE);
									// モードNoを自社品番に設定
									th010f01Form.Modeno = BoSystemConstant.MODE_JISHAHINBAN.ToString();
									TabUtil.SetTabNumber(pageContext, BoSystemConstant.MODE_JISHAHINBAN.ToString());
								}

								#endregion

								Th020f01Form f01VO = (Th020f01Form)pageContext.GetFormVO();

								// 商品マスタ検索からの遷移
								if (pageContext.Session[BoSystemConstant.PRM_TENPO_CD] != null)
								{
									// セッションよりパラメータを受け取る
									f01VO.Head_tenpo_cd = pageContext.Session[BoSystemConstant.PRM_TENPO_CD].ToString();			// 店舗コード
									f01VO.Head_tenpo_nm = pageContext.Session[BoSystemConstant.PRM_TENPO_NM].ToString();			// 店舗名
									f01VO.Old_jisya_hbn_from = pageContext.Session[BoSystemConstant.PRM_JISYA_HBN].ToString();		// 自社品番
									f01VO.Old_jisya_hbn_to = pageContext.Session[BoSystemConstant.PRM_JISYA_HBN].ToString();		// 自社品番
									f01VO.Modeno = BoSystemConstant.MODE_JISHAHINBAN;												// 選択モードNo

									// セッションの削除
									Session.Remove(BoSystemConstant.PRM_TENPO_CD);
									Session.Remove(BoSystemConstant.PRM_TENPO_NM);
									Session.Remove(BoSystemConstant.PRM_JISYA_HBN);

									// 検索処理起動
									new Th020f01Facade().DoBTNSEARCH_FRM(facadeContext);

									//エラー判定
									if (MessageDisplayUtil.HasError(facadeContext))
									{
										//アコーディオンなし
										AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_NONE);
										base.SetError(pageContext);
										return;
									}

									//アコーディオンを閉じた状態で表示
									AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_CLOSE);
									//アコーディオンを閉じた際に表示される検索条件を設定する。
									AccordionUtil.ResetSearchCondition(pageContext);
									// モードを設定 
									ModeUtil.SetMode(pageContext, ModeCls.GetModeNm(((Th020f01Form)pageContext.GetFormVO()).Stkmodeno));

									// 明細が1件のみの場合
									// Xの場合	
									// 在庫検索選択：自エリア店別を選択した状態で、[在庫検索-明細(店舗別)]画面へ遷移する。
									// それ以外の場合	
									// 在庫検索選択：全店を選択した状態で、[在庫検索-明細(店舗別)]画面へ遷移する。
									Th020f01Form formVo = (Th020f01Form)base.GetPageContext().GetFormVO();
									IList m1DataList = formVo.GetPageViewList("M1");
									if (m1DataList != null && m1DataList.Count == 1)
									{
										// 画面遷移フラグを立てる
										bjisyaHbnFlg = true;

										FormVOManager fvm = new FormVOManager(Session);
										facadeContext.SetUserObject(Th020p01Constant.FCDUO_NEXTVO_02, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Th020p01Constant.FORMID_02));
										facadeContext.SetUserObject(Th020p01Constant.FCDUO_NEXTVO_03, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Th020p01Constant.FORMID_03));
										new Th020f01Facade().DoM1JISYA_HBN_FRM(facadeContext);
										// 次画面のフォームビーンを設定(店舗別)
										fvm.SetFormVO(Th020p01Constant.PGID, Th020p01Constant.FORMID_02, (Th020f02Form)facadeContext.GetUserObject(Th020p01Constant.FCDUO_NEXTVO_02));
										// 次画面のフォームビーンを設定(エリア別)
										fvm.SetFormVO(Th020p01Constant.PGID, Th020p01Constant.FORMID_03, (Th020f03Form)facadeContext.GetUserObject(Th020p01Constant.FCDUO_NEXTVO_03));


										//エラー判定
										if (MessageDisplayUtil.HasError(facadeContext))
										{
											base.SetError(pageContext);
											return;
										}

										//commandInfo.ToProgramId = "遷移先プログラムID";
										commandInfo.ToFormId = Th020p01Constant.FORMID_02;
										commandInfo.ActionMode = "INI";
										commandInfo.PageLoadMode = false;

									}
									else
									{
										//他の処理モードを設定する必要がある場合、次の行を修正してください
										commandInfo.ActionMode = "UPD";
										commandInfo.PageLoadMode = false;
									}
								}
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
					Th020f01Form f01VO = (Th020f01Form)fvm.GetProgramVO(base.GetPageContext().CommandInfo.ProgramId).GetFormVO(Th020p01Constant.FORMID_01);
					TabUtil.SetTabNumber(base.GetPageContext(), f01VO.Modeno);
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

			// フォーカス設定用変数
			string focusItem = string.Empty;
			string focusMno = string.Empty;

			// 明細が1件の場合、明細画面に遷移
			if (bjisyaHbnFlg)
			{
				// 明細画面遷移
				base.Forward(pageContext, queryList);
			}
			else
			{
				// 一覧を表示する
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
				//アクションコンテキストを取得する
				pageContext = base.GetPageContext();
				// モード表示クリア処理
				ModeUtil.ClearMode(pageContext);
				Page.ClientScript.RegisterStartupScript(typeof(string), "InitialDetail", ControlCls.InitialDetail(pageContext));
				//クライアントチェックエラー時、画面描画する
				SetItems();
				SetAttribute();
				return;
			}

			//アクションコンテキストを取得する
			//IPageContext pageContext = base.GetPageContext();
			pageContext = base.GetPageContext();
			ICommandInfo commandInfo = pageContext.CommandInfo;
			bool bjisyaHbnFlg = false;

			try
			{
				// モード表示クリア処理
				ModeUtil.ClearMode(pageContext);

				//アクションロジックを処理します
				IFacadeContext facadeContext = FacadeContextFactory.GetFacadeContext(pageContext);
				InitFacadeContext(facadeContext);
				new Th020f01Facade().DoBTNSEARCH_FRM(facadeContext);
				
				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
					//アコーディオンなし
					AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_NONE);
					base.SetError(pageContext);
					return;
				}

				//アコーディオンを閉じた状態で表示
				AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_CLOSE);
				//アコーディオンを閉じた際に表示される検索条件を設定する。
				AccordionUtil.ResetSearchCondition(pageContext);
				// モードを設定 
				ModeUtil.SetMode(pageContext, ModeCls.GetModeNm(((Th020f01Form)pageContext.GetFormVO()).Stkmodeno));
				
				//遷移先の画面設定（入出力画面定義で設定した遷移先は初期化処理で設定済み）
				//入出力画面定義で設定した遷移先以外の画面に遷移する場合は以下のソースを
				//コメントインし、設定して下さい。
				//commandInfo.ToProgramId = "遷移先プログラムID";
				//commandInfo.ToFormId = "遷移先フォームID";

				// 明細が1件のみの場合
				// Xの場合	
				// 在庫検索選択：自エリア店別を選択した状態で、[在庫検索-明細(店舗別)]画面へ遷移する。
				// それ以外の場合	
				// 在庫検索選択：全店を選択した状態で、[在庫検索-明細(店舗別)]画面へ遷移する。
				Th020f01Form formVo = (Th020f01Form)base.GetPageContext().GetFormVO();
				IList m1DataList = formVo.GetPageViewList("M1");
				if (m1DataList != null && m1DataList.Count == 1)
				{
					// 画面遷移フラグを立てる
					bjisyaHbnFlg = true;

					FormVOManager fvm = new FormVOManager(Session);
					facadeContext.SetUserObject(Th020p01Constant.FCDUO_NEXTVO_02, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Th020p01Constant.FORMID_02));
					facadeContext.SetUserObject(Th020p01Constant.FCDUO_NEXTVO_03, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Th020p01Constant.FORMID_03));
					new Th020f01Facade().DoM1JISYA_HBN_FRM(facadeContext);
					// 次画面のフォームビーンを設定(店舗別)
					fvm.SetFormVO(Th020p01Constant.PGID, Th020p01Constant.FORMID_02, (Th020f02Form)facadeContext.GetUserObject(Th020p01Constant.FCDUO_NEXTVO_02));
					// 次画面のフォームビーンを設定(エリア別)
					fvm.SetFormVO(Th020p01Constant.PGID, Th020p01Constant.FORMID_03, (Th020f03Form)facadeContext.GetUserObject(Th020p01Constant.FCDUO_NEXTVO_03));

					//エラー判定
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						base.SetError(pageContext);
						return;
					}

					//他の処理モードを設定する必要がある場合、次の行を修正してください
					commandInfo.ActionMode = "INI";
					commandInfo.PageLoadMode = false;

				}
				else
				{
					//他の処理モードを設定する必要がある場合、次の行を修正してください
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
			// フォーカス設定用変数
			string focusItem = string.Empty;
			string focusMno = string.Empty;

			// 明細が1件の場合、明細画面に遷移
			if (bjisyaHbnFlg)
			{
				pageContext.ButtonInfo.ActFormId = Th020p01Constant.FORMID_02;
			}
			else
			{
				// 遷移先を明示
				pageContext.ButtonInfo.ActFormId = Th020p01Constant.FORMID_01;

				// 表示明細先頭の管理Noにフォーカス設定
				focusItem = "M1jisya_hbn";
				focusMno = (0).ToString();

				// フォーカス設定
				SetFocusCls.SetFocus(queryList, focusItem, focusMno);
			}
			
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
				new Th020f01Facade().DoPGR_PGN(facadeContext, pageindex);
				
				
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
		
		#region フォームを呼び出します(ボタンID : M1jisya_hbn(自社品番))
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(M1jisya_hbn(自社品番))
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnM1JISYA_HBN_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnM1JISYA_HBN_FRM");
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
				facadeContext.SetUserObject(Th020p01Constant.FCDUO_NEXTVO_02, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Th020p01Constant.FORMID_02));
				facadeContext.SetUserObject(Th020p01Constant.FCDUO_NEXTVO_03, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Th020p01Constant.FORMID_03));
				new Th020f01Facade().DoM1JISYA_HBN_FRM(facadeContext);
				// 次画面のフォームビーンを設定(店舗別)
				fvm.SetFormVO(Th020p01Constant.PGID, Th020p01Constant.FORMID_02, (Th020f02Form)facadeContext.GetUserObject(Th020p01Constant.FCDUO_NEXTVO_02));
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

			// フォーカス設定用変数
			string focusItem = string.Empty;
			string focusMno = string.Empty;

			// 画面遷移設定
			if (Zaiko_serchstk.SelectedValue.Equals(ConditionZaiko_serchstk.VALUE_ZAIKO_SERCHSTK1))
			{
				//[在庫検索選択]がエリア選択の場合
				pageContext.ButtonInfo.ActFormId = Th020p01Constant.FORMID_03;

			}
			else
			{
				//[在庫検索選択]がエリア選択以外の場合
				//[在庫検索選択]がエリア選択の場合
				pageContext.ButtonInfo.ActFormId = Th020p01Constant.FORMID_02;
			}

			
			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnM1JISYA_HBN_FRM");
			
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
						Th020f01Form th020f01Form = (Th020f01Form)pageContext.GetFormVO();

						//明細ページ情報を表示する
						ShowListPageInfo(th020f01Form);
			
						//明細部データを表示する
						RenderList(th020f01Form, pageContext.FormInfo, formResource, lang);

						//カード部データを表示する
						RenderCard(th020f01Form, pageContext.FormInfo, formResource, lang);
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
		/// <param name="th020f01Form">画面FormVO</param>
		private void ShowListPageInfo(Th020f01Form th020f01Form)
		{
			//M1明細ページ情報を表示する。
			ShowM1ListPageInfo(th020f01Form.GetList("M1"));

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
		/// <param name="th020f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderList(
			Th020f01Form th020f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//画面のM1明細部データを設定する。
			RenderM1List(th020f01Form, formInfo, formResource, lang);
			//M1明細部のページャーにページ情報を設定する。
			RenderM1Pager(th020f01Form);
			
		}
		#endregion

		#region M1明細データを表示する
		/// <summary>
		/// M1明細データを表示する。
		/// </summary>
		/// <param name="th020f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderM1List(
			Th020f01Form th020f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//M1明細部データソースを設定する。
			M1.DataSource = th020f01Form.GetPageViewList("M1");
			M1.DataBind();

			//M1明細部データをフォーマットする。
			IList m1DataList = (IList)M1.DataSource;
			
			for (int index = 0; index < M1.Items.Count; index++)
			{
				Th020f01M1Form th020f01M1Form = (Th020f01M1Form)m1DataList[index];
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1rowno"),
					DataFormatUtil.GetFormatItem(th020f01M1Form.M1rowno,formInfo["M1rowno"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1bumon_cd"),
					DataFormatUtil.GetFormatItem(th020f01M1Form.M1bumon_cd,formInfo["M1bumon_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1bumonkana_nm"),
					DataFormatUtil.GetFormatItem(th020f01M1Form.M1bumonkana_nm,formInfo["M1bumonkana_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1hinsyu_ryaku_nm"),
					DataFormatUtil.GetFormatItem(th020f01M1Form.M1hinsyu_ryaku_nm,formInfo["M1hinsyu_ryaku_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1burando_nm"),
					DataFormatUtil.GetFormatItem(th020f01M1Form.M1burando_nm,formInfo["M1burando_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1syohin_zokusei"),
					DataFormatUtil.GetFormatItem(th020f01M1Form.M1syohin_zokusei,formInfo["M1syohin_zokusei"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1maker_hbn"),
					DataFormatUtil.GetFormatItem(th020f01M1Form.M1maker_hbn,formInfo["M1maker_hbn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1syonmk"),
					DataFormatUtil.GetFormatItem(th020f01M1Form.M1syonmk,formInfo["M1syonmk"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1iro_nm"),
					DataFormatUtil.GetFormatItem(th020f01M1Form.M1iro_nm,formInfo["M1iro_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1tenzaiko_su"),
					DataFormatUtil.GetFormatItem(th020f01M1Form.M1tenzaiko_su,formInfo["M1tenzaiko_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1zentenzaiko_su"),
					DataFormatUtil.GetFormatItem(th020f01M1Form.M1zentenzaiko_su,formInfo["M1zentenzaiko_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1syoka_rtu"),
					DataFormatUtil.GetFormatItem(th020f01M1Form.M1syoka_rtu,formInfo["M1syoka_rtu"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1selectorcheckbox"),
					DataFormatUtil.GetFormatItem(th020f01M1Form.M1selectorcheckbox,formInfo["M1selectorcheckbox"]));
				((System.Web.UI.WebControls.CheckBox)M1.Items[index].FindControl("M1selectorcheckbox")).Text =
					formResource.GetString("M1selectorcheckbox", lang);
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1entersyoriflg"),
					DataFormatUtil.GetFormatItem(th020f01M1Form.M1entersyoriflg,formInfo["M1entersyoriflg"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1dtlirokbn"),
					DataFormatUtil.GetFormatItem(th020f01M1Form.M1dtlirokbn,formInfo["M1dtlirokbn"]));

				if(!base.CheckUseSelfCustomize()){
					((System.Web.UI.HtmlControls.HtmlInputButton)M1.Items[index].FindControl("M1jisya_hbn")).Value =
						th020f01M1Form.Dictionary[Th020p01Constant.DIC_M1JISYA_HBN].ToString();
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
				// (M1.HeaderRow.FindControl("M1syohin_zokusei") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syohin_zokusei", lang), base.GetPageContext().FormInfo["M1syohin_zokusei"]);
				// (M1.HeaderRow.FindControl("M1maker_hbn") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1maker_hbn", lang), base.GetPageContext().FormInfo["M1maker_hbn"]);
				// (M1.HeaderRow.FindControl("M1syonmk") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syonmk", lang), base.GetPageContext().FormInfo["M1syonmk"]);
				// (M1.HeaderRow.FindControl("M1iro_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1iro_nm", lang), base.GetPageContext().FormInfo["M1iro_nm"]);
				// (M1.HeaderRow.FindControl("M1tenzaiko_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tenzaiko_su", lang), base.GetPageContext().FormInfo["M1tenzaiko_su"]);
				// (M1.HeaderRow.FindControl("M1zentenzaiko_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1zentenzaiko_su", lang), base.GetPageContext().FormInfo["M1zentenzaiko_su"]);
				// (M1.HeaderRow.FindControl("M1syoka_rtu") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syoka_rtu", lang), base.GetPageContext().FormInfo["M1syoka_rtu"]);
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
		/// <param name="th020f01Form">画面FormVO</param>
		private void RenderM1Pager(Th020f01Form th020f01Form)
		{
			Pgr.VirtualItemCount = th020f01Form.GetList("M1").RecordCount;
			Pgr.CurrentPageIndex = th020f01Form.GetList("M1").PageNo - 1;
			Pgr.PageSize = th020f01Form.GetList("M1").DispRow;
		}
		#endregion
		#endregion

		#region カードデータを表示する
		/// <summary>
		/// カードデータを表示する
		/// </summary>
		/// <param name="th020f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderCard(
			Th020f01Form th020f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			
			ControlUtil.SetControlValue(Head_tenpo_cd,
				DataFormatUtil.GetFormatItem(th020f01Form.Head_tenpo_cd,formInfo["Head_tenpo_cd"]));
			ControlUtil.SetControlValue(Head_tenpo_nm,
				DataFormatUtil.GetFormatItem(th020f01Form.Head_tenpo_nm,formInfo["Head_tenpo_nm"]));
			ControlUtil.SetControlValue(Modeno,
				DataFormatUtil.GetFormatItem(th020f01Form.Modeno,formInfo["Modeno"]));
			ControlUtil.SetControlValue(Stkmodeno,
				DataFormatUtil.GetFormatItem(th020f01Form.Stkmodeno,formInfo["Stkmodeno"]));
			ControlUtil.SetControlValue(Old_jisya_hbn_from,
				DataFormatUtil.GetFormatItem(th020f01Form.Old_jisya_hbn_from,formInfo["Old_jisya_hbn_from"]));
			ControlUtil.SetControlValue(Old_jisya_hbn_to,
				DataFormatUtil.GetFormatItem(th020f01Form.Old_jisya_hbn_to,formInfo["Old_jisya_hbn_to"]));
			ControlUtil.SetControlValue(Kaisya_cd,
				DataFormatUtil.GetFormatItem(th020f01Form.Kaisya_cd,formInfo["Kaisya_cd"]));
			ControlUtil.SetControlValue(Kaisya_nm,
				DataFormatUtil.GetFormatItem(th020f01Form.Kaisya_nm,formInfo["Kaisya_nm"]));
			ControlUtil.SetControlValue(Old_jisya_hbn,
				DataFormatUtil.GetFormatItem(th020f01Form.Old_jisya_hbn,formInfo["Old_jisya_hbn"]));
			ControlUtil.SetControlValue(Old_jisya_hbn2,
				DataFormatUtil.GetFormatItem(th020f01Form.Old_jisya_hbn2,formInfo["Old_jisya_hbn2"]));
			ControlUtil.SetControlValue(Old_jisya_hbn3,
				DataFormatUtil.GetFormatItem(th020f01Form.Old_jisya_hbn3,formInfo["Old_jisya_hbn3"]));
			ControlUtil.SetControlValue(Old_jisya_hbn4,
				DataFormatUtil.GetFormatItem(th020f01Form.Old_jisya_hbn4,formInfo["Old_jisya_hbn4"]));
			ControlUtil.SetControlValue(Old_jisya_hbn5,
				DataFormatUtil.GetFormatItem(th020f01Form.Old_jisya_hbn5,formInfo["Old_jisya_hbn5"]));
			ControlUtil.SetControlValue(Kaisya_cd2,
				DataFormatUtil.GetFormatItem(th020f01Form.Kaisya_cd2,formInfo["Kaisya_cd2"]));
			ControlUtil.SetControlValue(Kaisya_nm2,
				DataFormatUtil.GetFormatItem(th020f01Form.Kaisya_nm2,formInfo["Kaisya_nm2"]));
			ControlUtil.SetControlValue(Scan_cd_from,
				DataFormatUtil.GetFormatItem(th020f01Form.Scan_cd_from,formInfo["Scan_cd_from"]));
			ControlUtil.SetControlValue(Scan_cd_to,
				DataFormatUtil.GetFormatItem(th020f01Form.Scan_cd_to,formInfo["Scan_cd_to"]));
			ControlUtil.SetControlValue(Kaisya_cd3,
				DataFormatUtil.GetFormatItem(th020f01Form.Kaisya_cd3,formInfo["Kaisya_cd3"]));
			ControlUtil.SetControlValue(Kaisya_nm3,
				DataFormatUtil.GetFormatItem(th020f01Form.Kaisya_nm3,formInfo["Kaisya_nm3"]));
			ControlUtil.SetControlValue(Maker_hbn,
				DataFormatUtil.GetFormatItem(th020f01Form.Maker_hbn,formInfo["Maker_hbn"]));
			ControlUtil.SetControlValue(Kaisya_cd4,
				DataFormatUtil.GetFormatItem(th020f01Form.Kaisya_cd4,formInfo["Kaisya_cd4"]));
			ControlUtil.SetControlValue(Kaisya_nm4,
				DataFormatUtil.GetFormatItem(th020f01Form.Kaisya_nm4,formInfo["Kaisya_nm4"]));
			ControlUtil.SetControlValue(Searchcnt,
				DataFormatUtil.GetFormatItem(th020f01Form.Searchcnt,formInfo["Searchcnt"]));
			ControlUtil.SetControlValue(Zaiko_serchstk,
				DataFormatUtil.GetFormatItem(th020f01Form.Zaiko_serchstk,formInfo["Zaiko_serchstk"]));

			if(!base.CheckUseSelfCustomize()){
				Btnheadtenpocd.Value = base.FormResourceGetString(formResource, "Btnheadtenpocd", lang);
				Btnmodejishahinban.InnerText = base.FormResourceGetString(formResource, "Btnmodejishahinban", lang);
				Btnmodejishahinban2.InnerText = base.FormResourceGetString(formResource, "Btnmodejishahinban2", lang);
				Btnmodescancd.InnerText = base.FormResourceGetString(formResource, "Btnmodescancd", lang);
				Btnmodemakerhbn.InnerText = base.FormResourceGetString(formResource, "Btnmodemakerhbn", lang);
				Btnkaisha_cd.Value = base.FormResourceGetString(formResource, "Btnkaisha_cd", lang);
				Btnkaisha_cd2.Value = base.FormResourceGetString(formResource, "Btnkaisha_cd2", lang);
				Btnkaisha_cd3.Value = base.FormResourceGetString(formResource, "Btnkaisha_cd3", lang);
				Btnmaker_hbn.Value = base.FormResourceGetString(formResource, "Btnmaker_hbn", lang);
				Btnkaisha_cd4.Value = base.FormResourceGetString(formResource, "Btnkaisha_cd4", lang);
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
				LoginInfoVO loginInfVO = LoginInfoUtil.GetLoginInfo();

				// 会社コード
				String sCopCd = string.Empty;

				// 会社コードと検索条件が一致しない場合自エリア店別は選択不可
				Th020f01Form formVo = (Th020f01Form)base.GetPageContext().GetFormVO();

				switch (formVo.Stkmodeno)
				{
					case BoSystemConstant.MODE_JISHAHINBAN:		// モード自社品番
						sCopCd = formVo.Kaisya_cd;
						break;
					case BoSystemConstant.MODE_JISYAHBNFUKUSU:	// モード自社品番(複数)
						sCopCd = formVo.Kaisya_cd2;
						break;
					case BoSystemConstant.MODE_SCANCD:			// モードスキャンコード
						sCopCd = formVo.Kaisya_cd3;
						break;
					case BoSystemConstant.MODE_MAKERHBN:		// モードメーカー品番
						sCopCd = formVo.Kaisya_cd4;
						break;
					default:
						sCopCd = string.Empty;
						break;
				}

				decimal logincopcd = Convert.ToDecimal(BoSystemString.Nvl(loginInfVO.CopCd, "0"));
				decimal inputkaisyacd = Convert.ToDecimal(BoSystemString.Nvl(sCopCd, "0"));

				if (!string.IsNullOrEmpty(sCopCd) && logincopcd != inputkaisyacd)
				{
					Zaiko_serchstk.Items.RemoveAt(1);
				}

			}
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
			// UIScreenController controller = new UIScreenController((Th020f01Form)base.GetPageContext().GetFormVO());
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
			//ControlUtil.SetControlValue(Old_jisya_hbn_from_lbl, 
				//DataFormatUtil.GetFormatCaption(formResource.GetString("Old_jisya_hbn_from", lang), base.GetPageContext().FormInfo["Old_jisya_hbn_from"]));
				ControlUtil.SetControlValue(Old_jisya_hbn_from_lbl, "自社品番");
				DataFormatUtil.SetMustColorCaption(Old_jisya_hbn_from_lbl, base.GetPageContext().FormInfo["Old_jisya_hbn_from"]);
			ControlUtil.SetControlValue(Old_jisya_hbn_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Old_jisya_hbn_to", lang), base.GetPageContext().FormInfo["Old_jisya_hbn_to"]));
				DataFormatUtil.SetMustColorCaption(Old_jisya_hbn_to_lbl, base.GetPageContext().FormInfo["Old_jisya_hbn_to"]);
			ControlUtil.SetControlValue(Kaisya_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Kaisya_cd", lang), base.GetPageContext().FormInfo["Kaisya_cd"]));
				DataFormatUtil.SetMustColorCaption(Kaisya_cd_lbl, base.GetPageContext().FormInfo["Kaisya_cd"]);
			ControlUtil.SetControlValue(Kaisya_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Kaisya_nm", lang), base.GetPageContext().FormInfo["Kaisya_nm"]));
				DataFormatUtil.SetMustColorCaption(Kaisya_nm_lbl, base.GetPageContext().FormInfo["Kaisya_nm"]);
			//ControlUtil.SetControlValue(Old_jisya_hbn_lbl, 
				//DataFormatUtil.GetFormatCaption(formResource.GetString("Old_jisya_hbn", lang), base.GetPageContext().FormInfo["Old_jisya_hbn"]));
				ControlUtil.SetControlValue(Old_jisya_hbn_lbl, "自社品番(複数)");
				DataFormatUtil.SetMustColorCaption(Old_jisya_hbn_lbl, base.GetPageContext().FormInfo["Old_jisya_hbn"]);
			ControlUtil.SetControlValue(Old_jisya_hbn2_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Old_jisya_hbn2", lang), base.GetPageContext().FormInfo["Old_jisya_hbn2"]));
				DataFormatUtil.SetMustColorCaption(Old_jisya_hbn2_lbl, base.GetPageContext().FormInfo["Old_jisya_hbn2"]);
			ControlUtil.SetControlValue(Old_jisya_hbn3_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Old_jisya_hbn3", lang), base.GetPageContext().FormInfo["Old_jisya_hbn3"]));
				DataFormatUtil.SetMustColorCaption(Old_jisya_hbn3_lbl, base.GetPageContext().FormInfo["Old_jisya_hbn3"]);
			ControlUtil.SetControlValue(Old_jisya_hbn4_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Old_jisya_hbn4", lang), base.GetPageContext().FormInfo["Old_jisya_hbn4"]));
				DataFormatUtil.SetMustColorCaption(Old_jisya_hbn4_lbl, base.GetPageContext().FormInfo["Old_jisya_hbn4"]);
			ControlUtil.SetControlValue(Old_jisya_hbn5_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Old_jisya_hbn5", lang), base.GetPageContext().FormInfo["Old_jisya_hbn5"]));
				DataFormatUtil.SetMustColorCaption(Old_jisya_hbn5_lbl, base.GetPageContext().FormInfo["Old_jisya_hbn5"]);
			ControlUtil.SetControlValue(Kaisya_cd2_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Kaisya_cd2", lang), base.GetPageContext().FormInfo["Kaisya_cd2"]));
				DataFormatUtil.SetMustColorCaption(Kaisya_cd2_lbl, base.GetPageContext().FormInfo["Kaisya_cd2"]);
			ControlUtil.SetControlValue(Kaisya_nm2_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Kaisya_nm2", lang), base.GetPageContext().FormInfo["Kaisya_nm2"]));
				DataFormatUtil.SetMustColorCaption(Kaisya_nm2_lbl, base.GetPageContext().FormInfo["Kaisya_nm2"]);
			//ControlUtil.SetControlValue(Scan_cd_from_lbl, 
				//DataFormatUtil.GetFormatCaption(formResource.GetString("Scan_cd_from", lang), base.GetPageContext().FormInfo["Scan_cd_from"]));
				ControlUtil.SetControlValue(Scan_cd_from_lbl, "ｽｷｬﾝｺｰﾄﾞ");
				DataFormatUtil.SetMustColorCaption(Scan_cd_from_lbl, base.GetPageContext().FormInfo["Scan_cd_from"]);
			ControlUtil.SetControlValue(Scan_cd_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Scan_cd_to", lang), base.GetPageContext().FormInfo["Scan_cd_to"]));
				DataFormatUtil.SetMustColorCaption(Scan_cd_to_lbl, base.GetPageContext().FormInfo["Scan_cd_to"]);
			ControlUtil.SetControlValue(Kaisya_cd3_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Kaisya_cd3", lang), base.GetPageContext().FormInfo["Kaisya_cd3"]));
				DataFormatUtil.SetMustColorCaption(Kaisya_cd3_lbl, base.GetPageContext().FormInfo["Kaisya_cd3"]);
			ControlUtil.SetControlValue(Kaisya_nm3_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Kaisya_nm3", lang), base.GetPageContext().FormInfo["Kaisya_nm3"]));
				DataFormatUtil.SetMustColorCaption(Kaisya_nm3_lbl, base.GetPageContext().FormInfo["Kaisya_nm3"]);
			ControlUtil.SetControlValue(Maker_hbn_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Maker_hbn", lang), base.GetPageContext().FormInfo["Maker_hbn"]));
				DataFormatUtil.SetMustColorCaption(Maker_hbn_lbl, base.GetPageContext().FormInfo["Maker_hbn"]);
			ControlUtil.SetControlValue(Kaisya_cd4_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Kaisya_cd4", lang), base.GetPageContext().FormInfo["Kaisya_cd4"]));
				DataFormatUtil.SetMustColorCaption(Kaisya_cd4_lbl, base.GetPageContext().FormInfo["Kaisya_cd4"]);
			ControlUtil.SetControlValue(Kaisya_nm4_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Kaisya_nm4", lang), base.GetPageContext().FormInfo["Kaisya_nm4"]));
				DataFormatUtil.SetMustColorCaption(Kaisya_nm4_lbl, base.GetPageContext().FormInfo["Kaisya_nm4"]);
			ControlUtil.SetControlValue(Searchcnt_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Searchcnt", lang), base.GetPageContext().FormInfo["Searchcnt"]));
				DataFormatUtil.SetMustColorCaption(Searchcnt_lbl, base.GetPageContext().FormInfo["Searchcnt"]);
			ControlUtil.SetControlValue(Zaiko_serchstk_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Zaiko_serchstk", lang), base.GetPageContext().FormInfo["Zaiko_serchstk"]));
				DataFormatUtil.SetMustColorCaption(Zaiko_serchstk_lbl, base.GetPageContext().FormInfo["Zaiko_serchstk"]);
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
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syohin_zokusei", lang), base.GetPageContext().FormInfo["M1syohin_zokusei"]);
				// M1.Columns[7].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1maker_hbn", lang), base.GetPageContext().FormInfo["M1maker_hbn"]);
				// M1.Columns[8].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syonmk", lang), base.GetPageContext().FormInfo["M1syonmk"]);
				// M1.Columns[9].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1iro_nm", lang), base.GetPageContext().FormInfo["M1iro_nm"]);
				// M1.Columns[10].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tenzaiko_su", lang), base.GetPageContext().FormInfo["M1tenzaiko_su"]);
				// M1.Columns[11].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1zentenzaiko_su", lang), base.GetPageContext().FormInfo["M1zentenzaiko_su"]);
				// M1.Columns[12].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syoka_rtu", lang), base.GetPageContext().FormInfo["M1syoka_rtu"]);
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
				Windowtitle.InnerText = formResource.GetString("Th020f01_Titlebar", lang);
				header.FormName = formResource.GetString("Th020f01_FormCaption", lang);
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
