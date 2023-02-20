using com.xebio.bo.Td050p01.Constant;
using com.xebio.bo.Td050p01.Facade;
using com.xebio.bo.Td050p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.Model.Context;
using Common.Advanced.Resource;
using Common.Advanced.Web.Context;
using Common.Advanced.Web.Control;
using Common.Advanced.Web.Util;
using Common.Business.C01000.C01013;
using Common.Business.C01000.C01014;
using Common.Business.C01000.C01015;
using Common.Business.C01000.C01016;
using Common.Business.C01000.C01026;
using Common.Business.C99999.Constant;
using Common.Business.C99999.StringUtil;
using Common.IntegrationMD.Util;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Session;
using Common.Standard.Util;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Td050p01.Page
{
  /// <summary>
  /// Td050f01のコードビハインドです。
  /// </summary>
  public partial class Td050f01Page : StandardBasePage
	{

		#region メソッド

		#region ページデータをロードするメソッド
		/// <summary>
		/// Td050f01画面データを作成する。
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
						pageContext.SetFormVO(new Td050f01Form());
						switch(commandInfo.ActionMode)
						{
							case "ADD":
								break;
							case "INI":	// メニューから遷移時
							case "DEL":
							case "UPD":
								IFacadeContext facadeContext = FacadeContextFactory.GetFacadeContext(pageContext);
								InitFacadeContext(facadeContext);
								new Td050f01Facade().DoLoad(facadeContext);
								#region 共通ヘッダ処理

								// 一覧画面共通処理	----------
								LoginInfoVO	loginInfVO = LoginInfoUtil.GetLoginInfo();
								Td050f01Form td050f01Form =	(Td050f01Form)facadeContext.FormVO;
								ControlHeaderStoreCls.InitialSetHeaderStore<Td050f01Form>(loginInfVO, td050f01Form);
								// 一覧画面共通処理	----------

								if (string.IsNullOrEmpty(td050f01Form.Modeno))
								{
									// アコーディオンなし
									AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_NONE);
									// モードNoを訂正に設定
									td050f01Form.Modeno	= BoSystemConstant.MODE_TEISEI.ToString();
									TabUtil.SetTabNumber(pageContext, BoSystemConstant.MODE_TEISEI.ToString());
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
					FormVOManager fvm =	new	FormVOManager(Session);
					Td050f01Form f01VO = (Td050f01Form)fvm.GetProgramVO(base.GetPageContext().CommandInfo.ProgramId).GetFormVO(Td050p01Constant.FORMID_01);
					TabUtil.SetTabNumber(base.GetPageContext(),	f01VO.Modeno);
				}

				#region 印刷処理
				if (pageContext != null)
				{
					DLConditionVO dlvo = new DLConditionVO();
					dlvo = (DLConditionVO)SessionInfoUtil.GetPgObject(Td050p01Constant.PGID, "DLVO", pageContext.Session);
					// 使ったら削除
					SessionInfoUtil.RemovePgObject("DLVO", pageContext);
					if (dlvo != null)
					{
						base.DownloadPageStartUp(pageContext, dlvo);
					}
				}
				#endregion

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
			// 共通チェックエラー時の明細初期化対応 ---------------------------  ADD_STR
			// ページコンテキスト初期化
			IPageContext pageContext = null;
			// 共通チェックエラー時の明細初期化対応 ---------------------------  ADD_END
			//入力チェックに失敗した場合、何も処理せずに返します
			if (!base.DoValidate(sender))
			{
				//クライアントチェックエラー時、画面描画する
				SetItems();
				SetAttribute();
				// 共通チェックエラー時の明細初期化対応 ---------------------------  ADD_STR
				pageContext = base.GetPageContext();
				// モード表示クリア処理
				ModeUtil.ClearMode(pageContext);
				// 明細初期化処理
				Page.ClientScript.RegisterStartupScript(typeof(string), "InitialDetail", ControlCls.InitialDetail(pageContext));
				// 共通チェックエラー時の明細初期化対応 ---------------------------  ADD_END
				return;
			}

			// 共通チェックエラー時の明細初期化対応 ---------------------------  UPD_STR
			////アクションコンテキストを取得する
			//IPageContext pageContext = base.GetPageContext();
			pageContext = base.GetPageContext();
			// 共通チェックエラー時の明細初期化対応 ---------------------------  UPD_END
			ICommandInfo commandInfo = pageContext.CommandInfo;
			
			try
			{

				//アクションロジックを処理します
				IFacadeContext facadeContext = FacadeContextFactory.GetFacadeContext(pageContext);
				InitFacadeContext(facadeContext);
				new Td050f01Facade().DoBTNSEARCH_FRM(facadeContext);
				
				
				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
					// エラー時の画面表示対応 --------------------------------  UPD_STR
					////アコーディオンを開いたた状態で表示
					//AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_OPEN);
					// ---------------------------------------------------------------
					// アコーディオンなし
					AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_NONE);
					// エラー時の画面表示対応 --------------------------------  UPD_END

					base.SetError(pageContext);
					return;
				}

				//アコーディオンを閉じた状態で表示
				AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_CLOSE);

				//アコーディオンを閉じた際に表示される検索条件を設定する。
				AccordionUtil.ResetSearchCondition(pageContext);

				// モードを設定 
				ModeUtil.SetMode(pageContext, ModeCls.GetModeNm(((Td050f01Form)pageContext.GetFormVO()).Stkmodeno));

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

            // 表示明細先頭のＭ１元伝リンクにフォーカス設定
            focusItem = "M1motodenpyo_bango";
            focusMno = (0).ToString();

            // フォーカス設定
            SetFocusCls.SetFocus(queryList, focusItem, focusMno);
			
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
				new Td050f01Facade().DoPGR_PGN(facadeContext, pageindex);
				
				
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
		
		#region フォームを呼び出します(ボタンID : M1motodenpyo_bango(元伝))
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(M1motodenpyo_bango(元伝))
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnM1MOTODENPYO_BANGO_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnM1MOTODENPYO_BANGO_FRM");
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
                facadeContext.SetUserObject(Td050p01Constant.FCDUO_NEXTVO, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Td050p01Constant.FORMID_02));

                new Td050f01Facade().DoM1MOTODENPYO_BANGO_FRM(facadeContext);
				
				// 次画面のフォームビーンを設定
				fvm.SetFormVO(Td050p01Constant.PGID, Td050p01Constant.FORMID_02, (Td050f02Form)facadeContext.GetUserObject(Td050p01Constant.FCDUO_NEXTVO));
				
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
			EndMethod(sender, e, this.GetType().Name + ".OnM1MOTODENPYO_BANGO_FRM");
			
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
				new Td050f01Facade().DoBTNENTER_FRM(facadeContext);
				
				
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
					// エラー時の画面表示対応 --------------------------------  str
					//if (!MessageDisplayUtil.HasError(pageContext))
					//{
					// エラー時の画面表示対応 --------------------------------  end
						string lang = WebSettingsUtil.GetLangSettingFromSession(pageContext.Session);
						FormResource formResource =
							ResourceFactory.GetFormResource(pageContext.CommandInfo.FormId);
			
						//標題をセットする
						SetCaption(formResource, lang);

						//FormVOを取得する
						Td050f01Form td050f01Form = (Td050f01Form)pageContext.GetFormVO();

						//明細ページ情報を表示する
						ShowListPageInfo(td050f01Form);
			
						//明細部データを表示する
						RenderList(td050f01Form, pageContext.FormInfo, formResource, lang);

						//カード部データを表示する
						RenderCard(td050f01Form, pageContext.FormInfo, formResource, lang);
					// エラー時の画面表示対応 --------------------------------  str
					//}
					// エラー時の画面表示対応 --------------------------------  end
					
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
		/// <param name="td050f01Form">画面FormVO</param>
		private void ShowListPageInfo(Td050f01Form td050f01Form)
		{
			//M1明細ページ情報を表示する。
			ShowM1ListPageInfo(td050f01Form.GetList("M1"));

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
		/// <param name="td050f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderList(
			Td050f01Form td050f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//画面のM1明細部データを設定する。
			RenderM1List(td050f01Form, formInfo, formResource, lang);
			//M1明細部のページャーにページ情報を設定する。
			RenderM1Pager(td050f01Form);
			
		}
		#endregion

		#region M1明細データを表示する
		/// <summary>
		/// M1明細データを表示する。
		/// </summary>
		/// <param name="td050f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderM1List(
			Td050f01Form td050f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//M1明細部データソースを設定する。
			M1.DataSource = td050f01Form.GetPageViewList("M1");
			M1.DataBind();

			//M1明細部データをフォーマットする。
			IList m1DataList = (IList)M1.DataSource;
			
			for (int index = 0; index < M1.Items.Count; index++)
			{
				Td050f01M1Form td050f01M1Form = (Td050f01M1Form)m1DataList[index];
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1rowno"),
					DataFormatUtil.GetFormatItem(td050f01M1Form.M1rowno,formInfo["M1rowno"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1bumon_cd_bo1"),
					DataFormatUtil.GetFormatItem(td050f01M1Form.M1bumon_cd_bo1,formInfo["M1bumon_cd_bo1"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1bumonkana_nm"),
					DataFormatUtil.GetFormatItem(td050f01M1Form.M1bumonkana_nm,formInfo["M1bumonkana_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1siiresaki_cd"),
					DataFormatUtil.GetFormatItem(td050f01M1Form.M1siiresaki_cd,formInfo["M1siiresaki_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1siiresaki_ryaku_nm"),
					DataFormatUtil.GetFormatItem(td050f01M1Form.M1siiresaki_ryaku_nm,formInfo["M1siiresaki_ryaku_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1burando_nm"),
					DataFormatUtil.GetFormatItem(td050f01M1Form.M1burando_nm,formInfo["M1burando_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1henpin_kakutei_ymd"),
					DataFormatUtil.GetFormatItem(td050f01M1Form.M1henpin_kakutei_ymd,formInfo["M1henpin_kakutei_ymd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1add_ymd"),
					DataFormatUtil.GetFormatItem(td050f01M1Form.M1add_ymd,formInfo["M1add_ymd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1aka_denpyo_bango"),
					DataFormatUtil.GetFormatItem(td050f01M1Form.M1aka_denpyo_bango,formInfo["M1aka_denpyo_bango"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1kuro_denpyo_bango"),
					DataFormatUtil.GetFormatItem(td050f01M1Form.M1kuro_denpyo_bango,formInfo["M1kuro_denpyo_bango"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1itemsu"),
					DataFormatUtil.GetFormatItem(td050f01M1Form.M1itemsu,formInfo["M1itemsu"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1teisei_suryo"),
					DataFormatUtil.GetFormatItem(td050f01M1Form.M1teisei_suryo,formInfo["M1teisei_suryo"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1genkakin"),
					DataFormatUtil.GetFormatItem(td050f01M1Form.M1genkakin,formInfo["M1genkakin"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1nyuryokutan_nm"),
					DataFormatUtil.GetFormatItem(td050f01M1Form.M1nyuryokutan_nm,formInfo["M1nyuryokutan_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1kakuteitan_nm"),
					DataFormatUtil.GetFormatItem(td050f01M1Form.M1kakuteitan_nm,formInfo["M1kakuteitan_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1henpin_riyu_nm"),
					DataFormatUtil.GetFormatItem(td050f01M1Form.M1henpin_riyu_nm,formInfo["M1henpin_riyu_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1siji_bango"),
					DataFormatUtil.GetFormatItem(td050f01M1Form.M1siji_bango,formInfo["M1siji_bango"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1selectorcheckbox"),
					DataFormatUtil.GetFormatItem(td050f01M1Form.M1selectorcheckbox,formInfo["M1selectorcheckbox"]));
				((System.Web.UI.WebControls.CheckBox)M1.Items[index].FindControl("M1selectorcheckbox")).Text =
					formResource.GetString("M1selectorcheckbox", lang);
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1entersyoriflg"),
					DataFormatUtil.GetFormatItem(td050f01M1Form.M1entersyoriflg,formInfo["M1entersyoriflg"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1dtlirokbn"),
					DataFormatUtil.GetFormatItem(td050f01M1Form.M1dtlirokbn,formInfo["M1dtlirokbn"]));

				if(!base.CheckUseSelfCustomize()){
                    // ボタンのValueに元伝Noを設定
                    ((System.Web.UI.HtmlControls.HtmlInputButton)M1.Items[index].FindControl("M1motodenpyo_bango")).Value =
                        td050f01M1Form.Dictionary[Td050p01Constant.DIC_M1MOTODENPYO_BANGO].ToString();
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
				// (M1.HeaderRow.FindControl("M1bumon_cd_bo1") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumon_cd_bo1", lang), base.GetPageContext().FormInfo["M1bumon_cd_bo1"]);
				// (M1.HeaderRow.FindControl("M1bumonkana_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumonkana_nm", lang), base.GetPageContext().FormInfo["M1bumonkana_nm"]);
				// (M1.HeaderRow.FindControl("M1siiresaki_cd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1siiresaki_cd", lang), base.GetPageContext().FormInfo["M1siiresaki_cd"]);
				// (M1.HeaderRow.FindControl("M1siiresaki_ryaku_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1siiresaki_ryaku_nm", lang), base.GetPageContext().FormInfo["M1siiresaki_ryaku_nm"]);
				// (M1.HeaderRow.FindControl("M1burando_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1burando_nm", lang), base.GetPageContext().FormInfo["M1burando_nm"]);
				// (M1.HeaderRow.FindControl("M1henpin_kakutei_ymd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1henpin_kakutei_ymd", lang), base.GetPageContext().FormInfo["M1henpin_kakutei_ymd"]);
				// (M1.HeaderRow.FindControl("M1add_ymd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1add_ymd", lang), base.GetPageContext().FormInfo["M1add_ymd"]);
				// (M1.HeaderRow.FindControl("M1motodenpyo_bango") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1motodenpyo_bango", lang), base.GetPageContext().FormInfo["M1motodenpyo_bango"]);
				// (M1.HeaderRow.FindControl("M1aka_denpyo_bango") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1aka_denpyo_bango", lang), base.GetPageContext().FormInfo["M1aka_denpyo_bango"]);
				// (M1.HeaderRow.FindControl("M1kuro_denpyo_bango") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kuro_denpyo_bango", lang), base.GetPageContext().FormInfo["M1kuro_denpyo_bango"]);
				// (M1.HeaderRow.FindControl("M1itemsu") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1itemsu", lang), base.GetPageContext().FormInfo["M1itemsu"]);
				// (M1.HeaderRow.FindControl("M1teisei_suryo") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1teisei_suryo", lang), base.GetPageContext().FormInfo["M1teisei_suryo"]);
				// (M1.HeaderRow.FindControl("M1genkakin") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1genkakin", lang), base.GetPageContext().FormInfo["M1genkakin"]);
				// (M1.HeaderRow.FindControl("M1nyuryokutan_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1nyuryokutan_nm", lang), base.GetPageContext().FormInfo["M1nyuryokutan_nm"]);
				// (M1.HeaderRow.FindControl("M1kakuteitan_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kakuteitan_nm", lang), base.GetPageContext().FormInfo["M1kakuteitan_nm"]);
				// (M1.HeaderRow.FindControl("M1henpin_riyu_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1henpin_riyu_nm", lang), base.GetPageContext().FormInfo["M1henpin_riyu_nm"]);
				// (M1.HeaderRow.FindControl("M1siji_bango") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1siji_bango", lang), base.GetPageContext().FormInfo["M1siji_bango"]);
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
		/// <param name="td050f01Form">画面FormVO</param>
		private void RenderM1Pager(Td050f01Form td050f01Form)
		{
			Pgr.VirtualItemCount = td050f01Form.GetList("M1").RecordCount;
			Pgr.CurrentPageIndex = td050f01Form.GetList("M1").PageNo - 1;
			Pgr.PageSize = td050f01Form.GetList("M1").DispRow;
		}
		#endregion
		#endregion

		#region カードデータを表示する
		/// <summary>
		/// カードデータを表示する
		/// </summary>
		/// <param name="td050f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderCard(
			Td050f01Form td050f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			
			ControlUtil.SetControlValue(Head_tenpo_cd,
				DataFormatUtil.GetFormatItem(td050f01Form.Head_tenpo_cd,formInfo["Head_tenpo_cd"]));
			ControlUtil.SetControlValue(Head_tenpo_nm,
				DataFormatUtil.GetFormatItem(td050f01Form.Head_tenpo_nm,formInfo["Head_tenpo_nm"]));
			ControlUtil.SetControlValue(Modeno,
				DataFormatUtil.GetFormatItem(td050f01Form.Modeno,formInfo["Modeno"]));
			ControlUtil.SetControlValue(Stkmodeno,
				DataFormatUtil.GetFormatItem(td050f01Form.Stkmodeno,formInfo["Stkmodeno"]));
			ControlUtil.SetControlValue(Denpyo_bango_from,
				DataFormatUtil.GetFormatItem(td050f01Form.Denpyo_bango_from,formInfo["Denpyo_bango_from"]));
			ControlUtil.SetControlValue(Denpyo_bango_to,
				DataFormatUtil.GetFormatItem(td050f01Form.Denpyo_bango_to,formInfo["Denpyo_bango_to"]));
			ControlUtil.SetControlValue(Siji_bango_from,
				DataFormatUtil.GetFormatItem(td050f01Form.Siji_bango_from,formInfo["Siji_bango_from"]));
			ControlUtil.SetControlValue(Siji_bango_to,
				DataFormatUtil.GetFormatItem(td050f01Form.Siji_bango_to,formInfo["Siji_bango_to"]));
			ControlUtil.SetControlValue(Siiresaki_cd,
				DataFormatUtil.GetFormatItem(td050f01Form.Siiresaki_cd,formInfo["Siiresaki_cd"]));
			ControlUtil.SetControlValue(Siiresaki_ryaku_nm,
				DataFormatUtil.GetFormatItem(td050f01Form.Siiresaki_ryaku_nm,formInfo["Siiresaki_ryaku_nm"]));
			ControlUtil.SetControlValue(Bumon_cd_from,
				DataFormatUtil.GetFormatItem(td050f01Form.Bumon_cd_from,formInfo["Bumon_cd_from"]));
			ControlUtil.SetControlValue(Bumon_nm_from,
				DataFormatUtil.GetFormatItem(td050f01Form.Bumon_nm_from,formInfo["Bumon_nm_from"]));
			ControlUtil.SetControlValue(Bumon_cd_to,
				DataFormatUtil.GetFormatItem(td050f01Form.Bumon_cd_to,formInfo["Bumon_cd_to"]));
			ControlUtil.SetControlValue(Bumon_nm_to,
				DataFormatUtil.GetFormatItem(td050f01Form.Bumon_nm_to,formInfo["Bumon_nm_to"]));
			ControlUtil.SetControlValue(Henpin_kakutei_ymd_from,
				DataFormatUtil.GetFormatItem(td050f01Form.Henpin_kakutei_ymd_from,formInfo["Henpin_kakutei_ymd_from"]));
			ControlUtil.SetControlValue(Henpin_kakutei_ymd_to,
				DataFormatUtil.GetFormatItem(td050f01Form.Henpin_kakutei_ymd_to,formInfo["Henpin_kakutei_ymd_to"]));
			ControlUtil.SetControlValue(Add_ymd_from,
				DataFormatUtil.GetFormatItem(td050f01Form.Add_ymd_from,formInfo["Add_ymd_from"]));
			ControlUtil.SetControlValue(Add_ymd_to,
				DataFormatUtil.GetFormatItem(td050f01Form.Add_ymd_to,formInfo["Add_ymd_to"]));
			ControlUtil.SetControlValue(Nyuryokutan_cd,
				DataFormatUtil.GetFormatItem(td050f01Form.Nyuryokutan_cd,formInfo["Nyuryokutan_cd"]));
			ControlUtil.SetControlValue(Nyuryokutan_nm,
				DataFormatUtil.GetFormatItem(td050f01Form.Nyuryokutan_nm,formInfo["Nyuryokutan_nm"]));
			ControlUtil.SetControlValue(Kakuteitan_cd,
				DataFormatUtil.GetFormatItem(td050f01Form.Kakuteitan_cd,formInfo["Kakuteitan_cd"]));
			ControlUtil.SetControlValue(Kakuteitan_nm,
				DataFormatUtil.GetFormatItem(td050f01Form.Kakuteitan_nm,formInfo["Kakuteitan_nm"]));
			ControlUtil.SetControlValue(Henpin_riyu,
				DataFormatUtil.GetFormatItem(td050f01Form.Henpin_riyu,formInfo["Henpin_riyu"]));
			ControlUtil.SetControlValue(Old_jisya_hbn,
				DataFormatUtil.GetFormatItem(td050f01Form.Old_jisya_hbn,formInfo["Old_jisya_hbn"]));
			ControlUtil.SetControlValue(Maker_hbn,
				DataFormatUtil.GetFormatItem(td050f01Form.Maker_hbn,formInfo["Maker_hbn"]));
			ControlUtil.SetControlValue(Scan_cd,
				DataFormatUtil.GetFormatItem(td050f01Form.Scan_cd,formInfo["Scan_cd"]));
			ControlUtil.SetControlValue(Searchcnt,
				DataFormatUtil.GetFormatItem(td050f01Form.Searchcnt,formInfo["Searchcnt"]));

			if(!base.CheckUseSelfCustomize()){
				Btnheadtenpocd.Value = base.FormResourceGetString(formResource, "Btnheadtenpocd", lang);
				Btnmodeteisei.InnerText = base.FormResourceGetString(formResource, "Btnmodeteisei", lang);
				Btnmodedel.InnerText = base.FormResourceGetString(formResource, "Btnmodedel", lang);
				Btnsiiresaki_cd.Value = base.FormResourceGetString(formResource, "Btnsiiresaki_cd", lang);
				Btnbumon_cd_from.Value = base.FormResourceGetString(formResource, "Btnbumon_cd_from", lang);
				Btnbumon_cd_to.Value = base.FormResourceGetString(formResource, "Btnbumon_cd_to", lang);
				Btnnyuryokutanto_cd.Value = base.FormResourceGetString(formResource, "Btnnyuryokutanto_cd", lang);
				Btnkakuteitanto_cd.Value = base.FormResourceGetString(formResource, "Btnkakuteitanto_cd", lang);
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
			if (!IsPostBack)
			{
				// 返品理由に空白を追加
				Henpin_riyu.Items.Insert(0, new ListItem("", BoSystemConstant.DROPDOWNLIST_MISENTAKU));
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
			// UIScreenController controller = new UIScreenController((Td050f01Form)base.GetPageContext().GetFormVO());
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


            Td050f01Form formVo = (Td050f01Form)base.GetPageContext().GetFormVO();
            //IDataList m1DataList = formVo.GetList("M1");

            if (BoSystemString.Nvl(formVo.Stkmodeno).Equals(BoSystemConstant.MODE_DEL))
            {
                // [選択モードNo]が「取消」の場合
                // 確定ボタン使用可
                ControlCls.Disable(Btnenter, false);
				for (int index = 0; index < M1.Items.Count; index++)
				{
					// 選択を使用可とする。
					((AdvancedCheckBox)M1.Items[index].FindControl("M1selectorcheckbox")).Visible = true;
				}
			}
            else
            {
                // [選択モードNo]が「取消」以外の場合
                // 確定ボタン使用不可
                ControlCls.Disable(Btnenter, true);
				for (int index = 0; index < M1.Items.Count; index++)
				{
					// 選択を使用不可とする。
					((AdvancedCheckBox)M1.Items[index].FindControl("M1selectorcheckbox")).Visible = false;
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
			//ControlUtil.SetControlValue(Denpyo_bango_from_lbl, 
				//	DataFormatUtil.GetFormatCaption(formResource.GetString("Denpyo_bango_from", lang), base.GetPageContext().FormInfo["Denpyo_bango_from"]));
			ControlUtil.SetControlValue(Denpyo_bango_from_lbl, "伝票番号");
				DataFormatUtil.SetMustColorCaption(Denpyo_bango_from_lbl, base.GetPageContext().FormInfo["Denpyo_bango_from"]);
			ControlUtil.SetControlValue(Denpyo_bango_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Denpyo_bango_to", lang), base.GetPageContext().FormInfo["Denpyo_bango_to"]));
				DataFormatUtil.SetMustColorCaption(Denpyo_bango_to_lbl, base.GetPageContext().FormInfo["Denpyo_bango_to"]);
			//ControlUtil.SetControlValue(Siji_bango_from_lbl,
			//	DataFormatUtil.GetFormatCaption(formResource.GetString("Siji_bango_from", lang), base.GetPageContext().FormInfo["Siji_bango_from"]));
			ControlUtil.SetControlValue(Siji_bango_from_lbl,"指示番号");
				DataFormatUtil.SetMustColorCaption(Siji_bango_from_lbl, base.GetPageContext().FormInfo["Siji_bango_from"]);
			ControlUtil.SetControlValue(Siji_bango_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Siji_bango_to", lang), base.GetPageContext().FormInfo["Siji_bango_to"]));
				DataFormatUtil.SetMustColorCaption(Siji_bango_to_lbl, base.GetPageContext().FormInfo["Siji_bango_to"]);
			ControlUtil.SetControlValue(Siiresaki_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Siiresaki_cd", lang), base.GetPageContext().FormInfo["Siiresaki_cd"]));
				DataFormatUtil.SetMustColorCaption(Siiresaki_cd_lbl, base.GetPageContext().FormInfo["Siiresaki_cd"]);
			ControlUtil.SetControlValue(Siiresaki_ryaku_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Siiresaki_ryaku_nm", lang), base.GetPageContext().FormInfo["Siiresaki_ryaku_nm"]));
				DataFormatUtil.SetMustColorCaption(Siiresaki_ryaku_nm_lbl, base.GetPageContext().FormInfo["Siiresaki_ryaku_nm"]);
			//ControlUtil.SetControlValue(Bumon_cd_from_lbl, 
			//	DataFormatUtil.GetFormatCaption(formResource.GetString("Bumon_cd_from", lang), base.GetPageContext().FormInfo["Bumon_cd_from"]));
			ControlUtil.SetControlValue(Bumon_cd_from_lbl, "部門");
				DataFormatUtil.SetMustColorCaption(Bumon_cd_from_lbl, base.GetPageContext().FormInfo["Bumon_cd_from"]);
			ControlUtil.SetControlValue(Bumon_nm_from_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Bumon_nm_from", lang), base.GetPageContext().FormInfo["Bumon_nm_from"]));
				DataFormatUtil.SetMustColorCaption(Bumon_nm_from_lbl, base.GetPageContext().FormInfo["Bumon_nm_from"]);
			ControlUtil.SetControlValue(Bumon_cd_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Bumon_cd_to", lang), base.GetPageContext().FormInfo["Bumon_cd_to"]));
				DataFormatUtil.SetMustColorCaption(Bumon_cd_to_lbl, base.GetPageContext().FormInfo["Bumon_cd_to"]);
			ControlUtil.SetControlValue(Bumon_nm_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Bumon_nm_to", lang), base.GetPageContext().FormInfo["Bumon_nm_to"]));
				DataFormatUtil.SetMustColorCaption(Bumon_nm_to_lbl, base.GetPageContext().FormInfo["Bumon_nm_to"]);
			//ControlUtil.SetControlValue(Henpin_kakutei_ymd_from_lbl, 
			//	DataFormatUtil.GetFormatCaption(formResource.GetString("Henpin_kakutei_ymd_from", lang), base.GetPageContext().FormInfo["Henpin_kakutei_ymd_from"]));
			ControlUtil.SetControlValue(Henpin_kakutei_ymd_from_lbl, "返品確定日"); 
				DataFormatUtil.SetMustColorCaption(Henpin_kakutei_ymd_from_lbl, base.GetPageContext().FormInfo["Henpin_kakutei_ymd_from"]);
			ControlUtil.SetControlValue(Henpin_kakutei_ymd_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Henpin_kakutei_ymd_to", lang), base.GetPageContext().FormInfo["Henpin_kakutei_ymd_to"]));
				DataFormatUtil.SetMustColorCaption(Henpin_kakutei_ymd_to_lbl, base.GetPageContext().FormInfo["Henpin_kakutei_ymd_to"]);
			//ControlUtil.SetControlValue(Add_ymd_from_lbl, 
			//	DataFormatUtil.GetFormatCaption(formResource.GetString("Add_ymd_from", lang), base.GetPageContext().FormInfo["Add_ymd_from"]));
			ControlUtil.SetControlValue(Add_ymd_from_lbl, "登録日");
				DataFormatUtil.SetMustColorCaption(Add_ymd_from_lbl, base.GetPageContext().FormInfo["Add_ymd_from"]);
			ControlUtil.SetControlValue(Add_ymd_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Add_ymd_to", lang), base.GetPageContext().FormInfo["Add_ymd_to"]));
				DataFormatUtil.SetMustColorCaption(Add_ymd_to_lbl, base.GetPageContext().FormInfo["Add_ymd_to"]);
			ControlUtil.SetControlValue(Nyuryokutan_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Nyuryokutan_cd", lang), base.GetPageContext().FormInfo["Nyuryokutan_cd"]));
				DataFormatUtil.SetMustColorCaption(Nyuryokutan_cd_lbl, base.GetPageContext().FormInfo["Nyuryokutan_cd"]);
			ControlUtil.SetControlValue(Nyuryokutan_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Nyuryokutan_nm", lang), base.GetPageContext().FormInfo["Nyuryokutan_nm"]));
				DataFormatUtil.SetMustColorCaption(Nyuryokutan_nm_lbl, base.GetPageContext().FormInfo["Nyuryokutan_nm"]);
			ControlUtil.SetControlValue(Kakuteitan_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Kakuteitan_cd", lang), base.GetPageContext().FormInfo["Kakuteitan_cd"]));
				DataFormatUtil.SetMustColorCaption(Kakuteitan_cd_lbl, base.GetPageContext().FormInfo["Kakuteitan_cd"]);
			ControlUtil.SetControlValue(Kakuteitan_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Kakuteitan_nm", lang), base.GetPageContext().FormInfo["Kakuteitan_nm"]));
				DataFormatUtil.SetMustColorCaption(Kakuteitan_nm_lbl, base.GetPageContext().FormInfo["Kakuteitan_nm"]);
			ControlUtil.SetControlValue(Henpin_riyu_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Henpin_riyu", lang), base.GetPageContext().FormInfo["Henpin_riyu"]));
				DataFormatUtil.SetMustColorCaption(Henpin_riyu_lbl, base.GetPageContext().FormInfo["Henpin_riyu"]);
			ControlUtil.SetControlValue(Old_jisya_hbn_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Old_jisya_hbn", lang), base.GetPageContext().FormInfo["Old_jisya_hbn"]));
				DataFormatUtil.SetMustColorCaption(Old_jisya_hbn_lbl, base.GetPageContext().FormInfo["Old_jisya_hbn"]);
			ControlUtil.SetControlValue(Maker_hbn_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Maker_hbn", lang), base.GetPageContext().FormInfo["Maker_hbn"]));
				DataFormatUtil.SetMustColorCaption(Maker_hbn_lbl, base.GetPageContext().FormInfo["Maker_hbn"]);
			ControlUtil.SetControlValue(Scan_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Scan_cd", lang), base.GetPageContext().FormInfo["Scan_cd"]));
				DataFormatUtil.SetMustColorCaption(Scan_cd_lbl, base.GetPageContext().FormInfo["Scan_cd"]);
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
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumon_cd_bo1", lang), base.GetPageContext().FormInfo["M1bumon_cd_bo1"]);
				// M1.Columns[2].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumonkana_nm", lang), base.GetPageContext().FormInfo["M1bumonkana_nm"]);
				// M1.Columns[3].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1siiresaki_cd", lang), base.GetPageContext().FormInfo["M1siiresaki_cd"]);
				// M1.Columns[4].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1siiresaki_ryaku_nm", lang), base.GetPageContext().FormInfo["M1siiresaki_ryaku_nm"]);
				// M1.Columns[5].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1burando_nm", lang), base.GetPageContext().FormInfo["M1burando_nm"]);
				// M1.Columns[6].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1henpin_kakutei_ymd", lang), base.GetPageContext().FormInfo["M1henpin_kakutei_ymd"]);
				// M1.Columns[7].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1add_ymd", lang), base.GetPageContext().FormInfo["M1add_ymd"]);
				// M1.Columns[8].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1motodenpyo_bango", lang), base.GetPageContext().FormInfo["M1motodenpyo_bango"]);
				// M1.Columns[9].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1aka_denpyo_bango", lang), base.GetPageContext().FormInfo["M1aka_denpyo_bango"]);
				// M1.Columns[10].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kuro_denpyo_bango", lang), base.GetPageContext().FormInfo["M1kuro_denpyo_bango"]);
				// M1.Columns[11].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1itemsu", lang), base.GetPageContext().FormInfo["M1itemsu"]);
				// M1.Columns[12].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1teisei_suryo", lang), base.GetPageContext().FormInfo["M1teisei_suryo"]);
				// M1.Columns[13].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1genkakin", lang), base.GetPageContext().FormInfo["M1genkakin"]);
				// M1.Columns[14].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1nyuryokutan_nm", lang), base.GetPageContext().FormInfo["M1nyuryokutan_nm"]);
				// M1.Columns[15].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kakuteitan_nm", lang), base.GetPageContext().FormInfo["M1kakuteitan_nm"]);
				// M1.Columns[16].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1henpin_riyu_nm", lang), base.GetPageContext().FormInfo["M1henpin_riyu_nm"]);
				// M1.Columns[17].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1siji_bango", lang), base.GetPageContext().FormInfo["M1siji_bango"]);
				// M1.Columns[18].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1selectorcheckbox", lang), base.GetPageContext().FormInfo["M1selectorcheckbox"]);
				// M1.Columns[19].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1entersyoriflg", lang), base.GetPageContext().FormInfo["M1entersyoriflg"]);
				// M1.Columns[20].HeaderText = 
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
				Windowtitle.InnerText = formResource.GetString("Td050f01_Titlebar", lang);
				header.FormName = formResource.GetString("Td050f01_FormCaption", lang);
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
