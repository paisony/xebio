using com.xebio.bo.Tj080p01.Constant;
using com.xebio.bo.Tj080p01.Facade;
using com.xebio.bo.Tj080p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.Model.Context;
using Common.Advanced.Resource;
using Common.Advanced.Web.Context;
using Common.Advanced.Web.Util;
using Common.Business.C01000.C01008;
using Common.Business.C01000.C01013;
using Common.Business.C01000.C01014;
using Common.Business.C01000.C01015;
using Common.Business.C01000.C01026;
using Common.Business.C99999.Constant;
using Common.Business.C99999.ReportUtil;
using Common.Business.C99999.StringUtil;
using Common.Conditions;
using Common.IntegrationMD.Util;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Session;
using Common.Standard.Util;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Tj080p01.Page
{
  /// <summary>
  /// Tj080f01のコードビハインドです。
  /// </summary>
  public partial class Tj080f01Page : StandardBasePage
	{

		#region メソッド

		#region ページデータをロードするメソッド
		/// <summary>
		/// Tj080f01画面データを作成する。
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
						pageContext.SetFormVO(new Tj080f01Form());
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
								new Tj080f01Facade().DoLoad(facadeContext);

								#region 共通ヘッダ処理

								// 一覧画面共通処理 ----------
								LoginInfoVO loginInfVO = LoginInfoUtil.GetLoginInfo();
								Tj080f01Form tj080f01Form = (Tj080f01Form)facadeContext.FormVO;
								ControlHeaderStoreCls.InitialSetHeaderStore<Tj080f01Form>(loginInfVO, tj080f01Form);
								// 一覧画面共通処理 ----------

								if (string.IsNullOrEmpty(tj080f01Form.Modeno))
								{
									// アコーディオンなし
									AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_NONE);
									// モードNoを照会に設定
									tj080f01Form.Modeno = BoSystemConstant.MODE_REF.ToString();
									TabUtil.SetTabNumber(pageContext, BoSystemConstant.MODE_REF.ToString());
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
					Tj080f01Form formVO = (Tj080f01Form)fvm.GetProgramVO(base.GetPageContext().CommandInfo.ProgramId).GetFormVO(Tj080p01Constant.FORMID_01);
					TabUtil.SetTabNumber(base.GetPageContext(), formVO.Modeno);
				}	
			
				/*
				*明細スクロール位置情報登録処理を行います。
				*機能有効させる場合は、コメントアウトを外してください。
				*/
				////保持したい明細スクロールのパネルIDを作成する
				//string[] detailPanelId = { , , };
				////保持したい明細スクロールのパネルIDを部品に登録する
				//ScrollRelationship.RegisterRelations(base.GetPageContext(), detailPanelId);

				// ファイルダウンロード
				if (SessionInfoUtil.GetPgObject(BoSystemConstant.SESSION_KEY_DOWNLOAD_VO, base.GetPageContext()) != null)
				{
					// ダウンロード用VOをセッションから取得
					DLConditionVO dlvo = SessionInfoUtil.GetPgObject(BoSystemConstant.SESSION_KEY_DOWNLOAD_VO, base.GetPageContext()) as DLConditionVO;

					// ダウンロード用VOをセッションから削除
					SessionInfoUtil.RemovePgObject(BoSystemConstant.SESSION_KEY_DOWNLOAD_VO, base.GetPageContext());

					base.DownloadPageStartUp(base.GetPageContext(), dlvo);
				}
				
				
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
			//IPageContext pageContext = base.GetPageContext();
			pageContext = base.GetPageContext();
			ICommandInfo commandInfo = pageContext.CommandInfo;
			
			try
			{
				// モード表示クリア処理
				ModeUtil.ClearMode(pageContext);

				//アクションロジックを処理します
				IFacadeContext facadeContext = FacadeContextFactory.GetFacadeContext(pageContext);
				InitFacadeContext(facadeContext);
				new Tj080f01Facade().DoBTNSEARCH_FRM(facadeContext);
				
				
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
				// モードを設定 
				ModeUtil.SetMode(pageContext, ModeCls.GetModeNm(((Tj080f01Form)pageContext.GetFormVO()).Stkmodeno));

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
			EndMethod(sender, e, this.GetType().Name + ".OnBTNSEARCH_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Btnprint())
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnprint())
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnBTNPRINT_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnBTNPRINT_FRM");
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

			// PDFファイル名
			string pdfNm = string.Empty;	

			try
			{

				//アクションロジックを処理します
				IFacadeContext facadeContext = FacadeContextFactory.GetFacadeContext(pageContext);
				InitFacadeContext(facadeContext);
				new Tj080f01Facade().DoBTNPRINT_FRM(facadeContext);
				
				
				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
					base.SetError(pageContext);
					return;
				}

				// PDFファイル名を取得
				pdfNm = (string)facadeContext.GetUserObject(Tj080p01Constant.FCDUO_RRT_FLNM);					

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

			#region 帳票出力処理

			DLConditionVO dlvo = new DLConditionVO();
			// サーバファイルフルパス
			string serverPath = string.Format("{0}{1}{2}",
											FilePathManager.GetOutFilePath(Tj080p01Constant.PGID),
											Path.DirectorySeparatorChar,
											pdfNm
											);
			// クライアントファイル名
			string clientNm = string.Format("{0}.{1}",
											BoSystemReport.CreateFileName(BoSystemConstant.REPORTNM_TANAOROSIJOKYOKAKUNINLIST_X,2),
											BoSystemConstant.RPT_PDF_EXTENSION
											);
			// ダウンロード用VOに値を設定
			dlvo.setSingleFileDownloadCondition(serverPath, clientNm);

			// ダウンロード用VOをセッションに格納
			SessionInfoUtil.SetPgObject(BoSystemConstant.SESSION_KEY_DOWNLOAD_VO, dlvo, pageContext);

			#endregion

			//フォーカスを当てる項目を指定したい場合はFormFocusUtilを使ってqueryListに追加すること

			// フォーカス設定用変数
			string focusItem = string.Empty;
			string focusMno  = string.Empty;

			// ヘッダ店舗コードにフォーカス設定
			focusItem = "Head_tenpo_cd";

			// フォーカス設定
			SetFocusCls.SetFocus(queryList, focusItem, focusMno);

			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNPRINT_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
			//base.DownloadPageStartUp(pageContext, dlvo);
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
				new Tj080f01Facade().DoPGR_PGN(facadeContext, pageindex);
				
				
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
						Tj080f01Form tj080f01Form = (Tj080f01Form)pageContext.GetFormVO();

						//明細ページ情報を表示する
						ShowListPageInfo(tj080f01Form);
			
						//明細部データを表示する
						RenderList(tj080f01Form, pageContext.FormInfo, formResource, lang);

						//カード部データを表示する
						RenderCard(tj080f01Form, pageContext.FormInfo, formResource, lang);
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
		/// <param name="tj080f01Form">画面FormVO</param>
		private void ShowListPageInfo(Tj080f01Form tj080f01Form)
		{
			//M1明細ページ情報を表示する。
			ShowM1ListPageInfo(tj080f01Form.GetList("M1"));

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
		/// <param name="tj080f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderList(
			Tj080f01Form tj080f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//画面のM1明細部データを設定する。
			RenderM1List(tj080f01Form, formInfo, formResource, lang);
			//M1明細部のページャーにページ情報を設定する。
			RenderM1Pager(tj080f01Form);
			
		}
		#endregion

		#region M1明細データを表示する
		/// <summary>
		/// M1明細データを表示する。
		/// </summary>
		/// <param name="tj080f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderM1List(
			Tj080f01Form tj080f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//M1明細部データソースを設定する。
			M1.DataSource = tj080f01Form.GetPageViewList("M1");
			M1.DataBind();

			//M1明細部データをフォーマットする。
			IList m1DataList = (IList)M1.DataSource;
			
			for (int index = 0; index < M1.Items.Count; index++)
			{
				Tj080f01M1Form tj080f01M1Form = (Tj080f01M1Form)m1DataList[index];
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1rowno"),
					DataFormatUtil.GetFormatItem(tj080f01M1Form.M1rowno,formInfo["M1rowno"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1tenpo_cd"),
					DataFormatUtil.GetFormatItem(tj080f01M1Form.M1tenpo_cd,formInfo["M1tenpo_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1tenpo_nm"),
					DataFormatUtil.GetFormatItem(tj080f01M1Form.M1tenpo_nm,formInfo["M1tenpo_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1sosin_kak_ymd"),
					DataFormatUtil.GetFormatItem(tj080f01M1Form.M1sosin_kak_ymd,formInfo["M1sosin_kak_ymd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1tenpo_kakutei_jyokyo"),
					DataFormatUtil.GetFormatItem(tj080f01M1Form.M1tenpo_kakutei_jyokyo,formInfo["M1tenpo_kakutei_jyokyo"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1tenpo_kakutei_jyokyo_nm"),
					DataFormatUtil.GetFormatItem(tj080f01M1Form.M1tenpo_kakutei_jyokyo_nm,formInfo["M1tenpo_kakutei_jyokyo_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1md_sosin_jyokyo"),
					DataFormatUtil.GetFormatItem(tj080f01M1Form.M1md_sosin_jyokyo,formInfo["M1md_sosin_jyokyo"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1md_sosin_jyokyo_nm"),
					DataFormatUtil.GetFormatItem(tj080f01M1Form.M1md_sosin_jyokyo_nm,formInfo["M1md_sosin_jyokyo_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1selectorcheckbox"),
					DataFormatUtil.GetFormatItem(tj080f01M1Form.M1selectorcheckbox,formInfo["M1selectorcheckbox"]));
				((System.Web.UI.WebControls.CheckBox)M1.Items[index].FindControl("M1selectorcheckbox")).Text =
					formResource.GetString("M1selectorcheckbox", lang);
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1entersyoriflg"),
					DataFormatUtil.GetFormatItem(tj080f01M1Form.M1entersyoriflg,formInfo["M1entersyoriflg"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1dtlirokbn"),
					DataFormatUtil.GetFormatItem(tj080f01M1Form.M1dtlirokbn,formInfo["M1dtlirokbn"]));

				if(!base.CheckUseSelfCustomize()){
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
				// (M1.HeaderRow.FindControl("M1sosin_kak_ymd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1sosin_kak_ymd", lang), base.GetPageContext().FormInfo["M1sosin_kak_ymd"]);
				// (M1.HeaderRow.FindControl("M1tenpo_kakutei_jyokyo") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tenpo_kakutei_jyokyo", lang), base.GetPageContext().FormInfo["M1tenpo_kakutei_jyokyo"]);
				// (M1.HeaderRow.FindControl("M1tenpo_kakutei_jyokyo_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tenpo_kakutei_jyokyo_nm", lang), base.GetPageContext().FormInfo["M1tenpo_kakutei_jyokyo_nm"]);
				// (M1.HeaderRow.FindControl("M1md_sosin_jyokyo") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1md_sosin_jyokyo", lang), base.GetPageContext().FormInfo["M1md_sosin_jyokyo"]);
				// (M1.HeaderRow.FindControl("M1md_sosin_jyokyo_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1md_sosin_jyokyo_nm", lang), base.GetPageContext().FormInfo["M1md_sosin_jyokyo_nm"]);
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
		/// <param name="tj080f01Form">画面FormVO</param>
		private void RenderM1Pager(Tj080f01Form tj080f01Form)
		{
			Pgr.VirtualItemCount = tj080f01Form.GetList("M1").RecordCount;
			Pgr.CurrentPageIndex = tj080f01Form.GetList("M1").PageNo - 1;
			Pgr.PageSize = tj080f01Form.GetList("M1").DispRow;
		}
		#endregion
		#endregion

		#region カードデータを表示する
		/// <summary>
		/// カードデータを表示する
		/// </summary>
		/// <param name="tj080f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderCard(
			Tj080f01Form tj080f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			
			ControlUtil.SetControlValue(Head_tenpo_cd,
				DataFormatUtil.GetFormatItem(tj080f01Form.Head_tenpo_cd,formInfo["Head_tenpo_cd"]));
			ControlUtil.SetControlValue(Head_tenpo_nm,
				DataFormatUtil.GetFormatItem(tj080f01Form.Head_tenpo_nm,formInfo["Head_tenpo_nm"]));
			ControlUtil.SetControlValue(Modeno,
				DataFormatUtil.GetFormatItem(tj080f01Form.Modeno,formInfo["Modeno"]));
			ControlUtil.SetControlValue(Stkmodeno,
				DataFormatUtil.GetFormatItem(tj080f01Form.Stkmodeno,formInfo["Stkmodeno"]));
			ControlUtil.SetControlValue(Tenpo_cd_from,
				DataFormatUtil.GetFormatItem(tj080f01Form.Tenpo_cd_from,formInfo["Tenpo_cd_from"]));
			ControlUtil.SetControlValue(Tenpo_nm_from,
				DataFormatUtil.GetFormatItem(tj080f01Form.Tenpo_nm_from,formInfo["Tenpo_nm_from"]));
			ControlUtil.SetControlValue(Tenpo_cd_to,
				DataFormatUtil.GetFormatItem(tj080f01Form.Tenpo_cd_to,formInfo["Tenpo_cd_to"]));
			ControlUtil.SetControlValue(Tenpo_nm_to,
				DataFormatUtil.GetFormatItem(tj080f01Form.Tenpo_nm_to,formInfo["Tenpo_nm_to"]));
			ControlUtil.SetControlValue(Tenpo_kakutei_jyokyo,
				DataFormatUtil.GetFormatItem(tj080f01Form.Tenpo_kakutei_jyokyo,formInfo["Tenpo_kakutei_jyokyo"]));
			ControlUtil.SetControlValue(Sosin_jyotai,
				DataFormatUtil.GetFormatItem(tj080f01Form.Sosin_jyotai,formInfo["Sosin_jyotai"]));
			ControlUtil.SetControlValue(Sosin_ymd_from,
				DataFormatUtil.GetFormatItem(tj080f01Form.Sosin_ymd_from,formInfo["Sosin_ymd_from"]));
			ControlUtil.SetControlValue(Sosin_ymd_to,
				DataFormatUtil.GetFormatItem(tj080f01Form.Sosin_ymd_to,formInfo["Sosin_ymd_to"]));
			ControlUtil.SetControlValue(Konkai_flg,
				DataFormatUtil.GetFormatItem(tj080f01Form.Konkai_flg,formInfo["Konkai_flg"]));
			Konkai_flg.Text = formResource.GetString("Konkai_flg", lang);
			ControlUtil.SetControlValue(Searchcnt,
				DataFormatUtil.GetFormatItem(tj080f01Form.Searchcnt,formInfo["Searchcnt"]));

			if(!base.CheckUseSelfCustomize()){
				Btnheadtenpocd.Value = base.FormResourceGetString(formResource, "Btnheadtenpocd", lang);
				Btnmoderef.InnerText = base.FormResourceGetString(formResource, "Btnmoderef", lang);
				Btnmodesyuryokakuninref.InnerText = base.FormResourceGetString(formResource, "Btnmodesyuryokakuninref", lang);
				Btntenpocd_from.Value = base.FormResourceGetString(formResource, "Btntenpocd_from", lang);
				Btntenpocd_to.Value = base.FormResourceGetString(formResource, "Btntenpocd_to", lang);
				Btnsearch.Value = base.FormResourceGetString(formResource, "Btnsearch", lang);
				Btnprint.Value = base.FormResourceGetString(formResource, "Btnprint", lang);
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
				// 店舗確定状況に空白を追加
				Tenpo_kakutei_jyokyo.Items.Insert(0, new ListItem("", BoSystemConstant.DROPDOWNLIST_MISENTAKU));
				// 送信状態に空白を追加
				Sosin_jyotai.Items.Insert(0, new ListItem("", BoSystemConstant.DROPDOWNLIST_MISENTAKU));
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
			// UIScreenController controller = new UIScreenController((Tj080f01Form)base.GetPageContext().GetFormVO());
			// controller.ChangeColumnsDisplayMode(M1 ,  new DetailHeaderFixedVO(M1Header , true) , null);

			/*
			 *登録した機能間連携処理を親画面に感知させる。
			 *機能有効させる場合は、コメントアウトを外してください。
			 */
			//DetailUtil.RunPgSyn(this,(StandardBaseForm)base.GetPageContext().GetFormVO());


			LoginInfoVO loginInfVO = LoginInfoUtil.GetLoginInfo();

			#region 共通ヘッダ表示制御
			ControlHeaderStoreCls.ControlSetHeaderStore(loginInfVO, Head_tenpo_cd, Btnheadtenpocd);
			#endregion

			Tj080f01Form formVO = (Tj080f01Form)base.GetPageContext().GetFormVO();
			IList m1List = formVO.GetPageViewList("M1");

			#region 画面表示制御

			if (base.GetPageContext().CommandInfo.ActionMode.Equals("INI"))
			{
				// 明細ボタン部を非表示とする
				ControlCls.Visible(meisaiBtnArea, false);
			}
			else
			{
				// 明細ボタン部を表示する
				ControlCls.Visible(meisaiBtnArea, true);
			}
			//　送信日FROM-TO
			if (ConditionSosin_jotai.VALUE_SOSIN_JOTAI2.Equals(formVO.Sosin_jyotai))
			{
				ControlCls.Disable(Sosin_ymd_from, false);
				ControlCls.Disable(Sosin_ymd_to, false);

			}
			else
			{
				ControlCls.Disable(Sosin_ymd_from, true);
				ControlCls.Disable(Sosin_ymd_to, true);
			}
			// [選択モードNo]が「終了確認照会」以外の場合
			if (!BoSystemString.Nvl(formVO.Stkmodeno).Equals(BoSystemConstant.MODE_SYURYOKAKUNINREF))
			{
				// 印刷ボタン使用不可
				ControlCls.Disable(Btnprint, true);
			}
			else
			{
				// 印刷ボタン使用可
				ControlCls.Disable(Btnprint, false);
			}

			// 権限取得部品の戻り値が"FALSE"の場合
			if (!CheckKengenCls.CheckKengen(loginInfVO))
			{
				// 店舗コードFROM使用不可
				ControlCls.Disable(Tenpo_cd_from, true);
				// 店舗コードFROMボタン使用不可
				ControlCls.Disable(Btntenpocd_from, true);

				// 店舗コードTO使用不可
				ControlCls.Disable(Tenpo_cd_to, true);
				// 店舗コードTOボタン使用不可
				ControlCls.Disable(Btntenpocd_to, true);
			}

			#endregion

			#region 明細色設定

			for (int i = 0; i < M1.Items.Count; i++)
			{
				Tj080f01M1Form m1formVO = (Tj080f01M1Form)m1List[i];

				// 店舗確定状況
				if ("0".Equals(m1formVO.M1tenpo_kakutei_jyokyo))
				{
					// 店舗確定状況
					((TextBox)M1.Items[i].FindControl("M1tenpo_kakutei_jyokyo")).ForeColor = Color.Red;
					// 店舗確定状況名称
					((TextBox)M1.Items[i].FindControl("M1tenpo_kakutei_jyokyo_nm")).ForeColor = Color.Red;
				}

				// MD送信状況
				if ("0".Equals(m1formVO.M1md_sosin_jyokyo))
				{
					// MD送信状況
					((TextBox)M1.Items[i].FindControl("M1md_sosin_jyokyo")).ForeColor = Color.Red;
					// MD送信状況名称
					((TextBox)M1.Items[i].FindControl("M1md_sosin_jyokyo_nm")).ForeColor = Color.Red;
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
			ControlUtil.SetControlValue(Tenpo_cd_from_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Tenpo_cd_from", lang), base.GetPageContext().FormInfo["Tenpo_cd_from"]));
				DataFormatUtil.SetMustColorCaption(Tenpo_cd_from_lbl, base.GetPageContext().FormInfo["Tenpo_cd_from"]);
			ControlUtil.SetControlValue(Tenpo_nm_from_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Tenpo_nm_from", lang), base.GetPageContext().FormInfo["Tenpo_nm_from"]));
				DataFormatUtil.SetMustColorCaption(Tenpo_nm_from_lbl, base.GetPageContext().FormInfo["Tenpo_nm_from"]);
			ControlUtil.SetControlValue(Tenpo_cd_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Tenpo_cd_to", lang), base.GetPageContext().FormInfo["Tenpo_cd_to"]));
				DataFormatUtil.SetMustColorCaption(Tenpo_cd_to_lbl, base.GetPageContext().FormInfo["Tenpo_cd_to"]);
			ControlUtil.SetControlValue(Tenpo_nm_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Tenpo_nm_to", lang), base.GetPageContext().FormInfo["Tenpo_nm_to"]));
				DataFormatUtil.SetMustColorCaption(Tenpo_nm_to_lbl, base.GetPageContext().FormInfo["Tenpo_nm_to"]);
			ControlUtil.SetControlValue(Tenpo_kakutei_jyokyo_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Tenpo_kakutei_jyokyo", lang), base.GetPageContext().FormInfo["Tenpo_kakutei_jyokyo"]));
				DataFormatUtil.SetMustColorCaption(Tenpo_kakutei_jyokyo_lbl, base.GetPageContext().FormInfo["Tenpo_kakutei_jyokyo"]);
			ControlUtil.SetControlValue(Sosin_jyotai_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Sosin_jyotai", lang), base.GetPageContext().FormInfo["Sosin_jyotai"]));
				DataFormatUtil.SetMustColorCaption(Sosin_jyotai_lbl, base.GetPageContext().FormInfo["Sosin_jyotai"]);
			//ControlUtil.SetControlValue(Sosin_ymd_from_lbl, 
			//	DataFormatUtil.GetFormatCaption(formResource.GetString("Sosin_ymd_from", lang), base.GetPageContext().FormInfo["Sosin_ymd_from"]));
				ControlUtil.SetControlValue(Sosin_ymd_from_lbl, "送信日");
				DataFormatUtil.SetMustColorCaption(Sosin_ymd_from_lbl, base.GetPageContext().FormInfo["Sosin_ymd_from"]);
			ControlUtil.SetControlValue(Sosin_ymd_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Sosin_ymd_to", lang), base.GetPageContext().FormInfo["Sosin_ymd_to"]));
				DataFormatUtil.SetMustColorCaption(Sosin_ymd_to_lbl, base.GetPageContext().FormInfo["Sosin_ymd_to"]);
			ControlUtil.SetControlValue(Konkai_flg_lbl,
				DataFormatUtil.GetFormatCaption(formResource.GetString("Konkai_flg", lang), base.GetPageContext().FormInfo["Konkai_flg"]));
				DataFormatUtil.SetMustColorCaption(Konkai_flg_lbl, base.GetPageContext().FormInfo["Konkai_flg"]);
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
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tenpo_cd", lang), base.GetPageContext().FormInfo["M1tenpo_cd"]);
				// M1.Columns[2].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tenpo_nm", lang), base.GetPageContext().FormInfo["M1tenpo_nm"]);
				// M1.Columns[3].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1sosin_kak_ymd", lang), base.GetPageContext().FormInfo["M1sosin_kak_ymd"]);
				// M1.Columns[4].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tenpo_kakutei_jyokyo", lang), base.GetPageContext().FormInfo["M1tenpo_kakutei_jyokyo"]);
				// M1.Columns[5].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tenpo_kakutei_jyokyo_nm", lang), base.GetPageContext().FormInfo["M1tenpo_kakutei_jyokyo_nm"]);
				// M1.Columns[6].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1md_sosin_jyokyo", lang), base.GetPageContext().FormInfo["M1md_sosin_jyokyo"]);
				// M1.Columns[7].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1md_sosin_jyokyo_nm", lang), base.GetPageContext().FormInfo["M1md_sosin_jyokyo_nm"]);
				// M1.Columns[8].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1selectorcheckbox", lang), base.GetPageContext().FormInfo["M1selectorcheckbox"]);
				// M1.Columns[9].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1entersyoriflg", lang), base.GetPageContext().FormInfo["M1entersyoriflg"]);
				// M1.Columns[10].HeaderText = 
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
				Windowtitle.InnerText = formResource.GetString("Tj080f01_Titlebar", lang);
				header.FormName = formResource.GetString("Tj080f01_FormCaption", lang);
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
