using com.xebio.bo.Tf030p01.Constant;
using com.xebio.bo.Tf030p01.Facade;
using com.xebio.bo.Tf030p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.Model.Context;
using Common.Advanced.Resource;
using Common.Advanced.Web.Context;
using Common.Advanced.Web.Util;
using Common.Business.C01000.C01008;
using Common.Business.C01000.C01014;
using Common.Business.C01000.C01015;
using Common.Business.C01000.C01016;
using Common.Business.C99999.Constant;
using Common.Business.C99999.ReportUtil;
using Common.IntegrationMD.MDControl;
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

namespace com.xebio.bo.Tf030p01.Page
{
  /// <summary>
  /// Tf030f02のコードビハインドです。
  /// </summary>
  public partial class Tf030f02Page : StandardBasePage
	{

		#region メソッド

		#region ページデータをロードするメソッド
		/// <summary>
		/// Tf030f02画面データを作成する。
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
						pageContext.SetFormVO(new Tf030f02Form());
						switch(commandInfo.ActionMode)
						{
							case "ADD":
								break;
							case "INI":
							case "DEL":
							case "UPD":
								IFacadeContext facadeContext =
									FacadeContextFactory.GetFacadeContext(pageContext);
								InitFacadeContext(facadeContext);
								new Tf030f02Facade().DoLoad(facadeContext);
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

		#region フォームを呼び出します(ボタンID : Btnback(戻る))
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnback(戻る))
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

			string modeno = string.Empty;

			try
			{

				//アクションロジックを処理します
				IFacadeContext facadeContext = FacadeContextFactory.GetFacadeContext(pageContext);
				InitFacadeContext(facadeContext);
				new Tf030f02Facade().DoBTNBACK_FRM(facadeContext);
				
				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
					base.SetError(pageContext);
					return;
				}

				modeno = (string)((Tf030f02Form)pageContext.GetFormVO(Tf030p01Constant.PGID, Tf030p01Constant.FORMID_02)).Stkmodeno;

				if (((Tf030f02Form)pageContext.GetFormVO()).Stkmodeno.Equals(BoSystemConstant.MODE_INSERT))
				{
					// 新規作成の場合、モード表示クリア処理
					ModeUtil.ClearMode(pageContext);
				}
				
				//遷移先の画面設定（入出力画面定義で設定した遷移先は初期化処理で設定済み）
				//入出力画面定義で設定した遷移先以外の画面に遷移する場合は以下のソースを
				//コメントインし、設定して下さい。
				//commandInfo.ToProgramId = "遷移先プログラムID";
				//commandInfo.ToFormId = "遷移先フォームID";
				
				//他の処理モードを設定する必要がある場合、次の行を修正してください
				commandInfo.ActionMode = "UPD";
				if (modeno.Equals(BoSystemConstant.MODE_INSERT))
				{
					commandInfo.PageLoadMode = true;
				}
				else
				{
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

			// [選択モードNo]が「新規作成」以外の場合
			if (!modeno.Equals(BoSystemConstant.MODE_INSERT))
			{
				// フォーカス設定用変数
				string focusItem = string.Empty;
				string focusMno = string.Empty;

				// 選択された管理Noにフォーカス設定
				focusItem = "M1denpyo_bango";
				focusMno = (string)((Tf030f02Form)pageContext.GetFormVO(Tf030p01Constant.PGID, Tf030p01Constant.FORMID_02)).Dictionary[Tf030p01Constant.DIC_M1SELCETROWIDX];

				// フォーカス設定
				SetFocusCls.SetFocus(queryList, focusItem, focusMno);
			}

			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNBACK_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region M1明細の行を増やします(ボタンID : Btnrowins(行追加))
		/// <summary>
		/// M1明細の行を増やします。
		/// ボタンID(Btnrowins(行追加))
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
				new Tf030f02Facade().DoBTNROWINS_MADD(facadeContext);
				
				
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

			// フォーカス設定用変数
			string focusItem = string.Empty;
			string focusMno = string.Empty;

			// 追加行にフォーカス設定
			focusItem = "M1tekiyo_cd";
			Tf030f02Form f02VO = (Tf030f02Form)pageContext.GetFormVO(Tf030p01Constant.PGID, Tf030p01Constant.FORMID_02);
			IDataList list = f02VO.GetList("M1");
			focusMno = (list.Count - 1).ToString();

			// フォーカス設定
			SetFocusCls.SetFocus(queryList, focusItem, focusMno);

			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNROWINS_MADD");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Btnrowdel(行削除))
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnrowdel(行削除))
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
				new Tf030f02Facade().DoBTNROWDEL_FRM(facadeContext);
				
				
				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
					base.SetError(pageContext);
					return;
				}

				// フォーカス行をコードビハインドに戻す
				lastRow = (decimal) facadeContext.GetUserObject(Tf030p01Constant.FCDUO_FOCUSROW);
				
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
			focusItem = "M1tekiyo_cd";
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

			string modeno = string.Empty;

			try
			{

				//アクションロジックを処理します
				IFacadeContext facadeContext = FacadeContextFactory.GetFacadeContext(pageContext);
				InitFacadeContext(facadeContext);
				new Tf030f02Facade().DoBTNENTER_FRM(facadeContext);

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

				// 明細画面VO
				Tf030f02Form f02VO = (Tf030f02Form)facadeContext.FormVO;
				modeno = f02VO.Stkmodeno;

				// [選択モードNo]が「修正」の場合
				if (modeno.Equals(BoSystemConstant.MODE_UPD))
				{
					// 一覧画面VO
					FormVOManager fvm = new FormVOManager(Session);
					Tf030f01Form f01VO = (Tf030f01Form)fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Tf030p01Constant.FORMID_01);

					IDataList m1List = f01VO.GetList("M1");
					// 選択行の情報を設定する。
					m1List.GetPageViewList()[Convert.ToInt32(f02VO.Dictionary[Tf030p01Constant.DIC_M1SELCETROWIDX])] = (Tf030f01M1Form)f02VO.Dictionary[Tf030p01Constant.DIC_M1SELCETVO];

					// 次画面のフォームビーンを設定
					fvm.SetFormVO(Tf030p01Constant.PGID, Tf030p01Constant.FORMID_01, f01VO);

					//他の処理モードを設定する必要がある場合、次の行を修正してください
					commandInfo.ActionMode = "UPD";
					commandInfo.PageLoadMode = false;
				}
				else
				{
					//他の処理モードを設定する必要がある場合、次の行を修正してください
					commandInfo.ActionMode = "UPD";
					commandInfo.PageLoadMode = true;
				}

				#region 出力PDFファイルダウンロード設定

				// PDFファイル名取得
				string pdfNm = facadeContext.GetUserObject(Tf030p01Constant.FCDUO_RRT_FLNM) as string;

				// サーバファイルフルパス
				string serverPath = string.Format(
					"{0}{1}{2}",
					FilePathManager.GetOutFilePath(Tf030p01Constant.PGID),
					Path.DirectorySeparatorChar,
					pdfNm
					);

				// クライアントファイル名
				string clientNm = string.Format(
					"{0}.{1}",
					BoSystemReport.CreateFileName(BoSystemConstant.REPORTNM_KEIHIMIBARAILIST, 2),
					BoSystemConstant.RPT_PDF_EXTENSION
					);

				// 単一ダウンロード情報
				DLConditionVO dlvo = new DLConditionVO();

				// ダウンロード用VOに値を設定
				dlvo.setSingleFileDownloadCondition(serverPath, clientNm);

				// 単一ダウンロード用にVOをセッションにセット
				SessionInfoUtil.SetPgObject(pageContext.CommandInfo.ProgramId, Tf030p01Constant.SESSION_KEY_DOWNLOAD_INFO, dlvo, Session);

				#endregion
				
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

			// [選択モードNo]が「修正」の場合
			if (modeno.Equals(BoSystemConstant.MODE_UPD))
			{

				//フォーカスを当てる項目を指定したい場合はFormFocusUtilを使ってqueryListに追加すること

				// フォーカス設定用変数
				string focusItem = string.Empty;
				string focusMno = string.Empty;

				// 選択された管理Noにフォーカス設定
				focusItem = "M1denpyo_bango";
				focusMno = (string)((Tf030f02Form)pageContext.GetFormVO(Tf030p01Constant.PGID, Tf030p01Constant.FORMID_02)).Dictionary[Tf030p01Constant.DIC_M1SELCETROWIDX];

				// フォーカス設定
				SetFocusCls.SetFocus(queryList, focusItem, focusMno);
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
					//if (!MessageDisplayUtil.HasError(pageContext))
					//{
						string lang = WebSettingsUtil.GetLangSettingFromSession(pageContext.Session);
						FormResource formResource =
							ResourceFactory.GetFormResource(pageContext.CommandInfo.FormId);
			
						//標題をセットする
						SetCaption(formResource, lang);

						//FormVOを取得する
						Tf030f02Form tf030f02Form = (Tf030f02Form)pageContext.GetFormVO();

						//明細ページ情報を表示する
						ShowListPageInfo(tf030f02Form);
			
						//明細部データを表示する
						RenderList(tf030f02Form, pageContext.FormInfo, formResource, lang);

						//カード部データを表示する
						RenderCard(tf030f02Form, pageContext.FormInfo, formResource, lang);
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
		/// <param name="tf030f02Form">画面FormVO</param>
		private void ShowListPageInfo(Tf030f02Form tf030f02Form)
		{
			//M1明細ページ情報を表示する。
			ShowM1ListPageInfo(tf030f02Form.GetList("M1"));

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
		/// <param name="tf030f02Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderList(
			Tf030f02Form tf030f02Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//画面のM1明細部データを設定する。
			RenderM1List(tf030f02Form, formInfo, formResource, lang);
			
		}
		#endregion

		#region M1明細データを表示する
		/// <summary>
		/// M1明細データを表示する。
		/// </summary>
		/// <param name="tf030f02Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderM1List(
			Tf030f02Form tf030f02Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//M1明細部データソースを設定する。
			M1.DataSource = tf030f02Form.GetPageViewList("M1");
			M1.DataBind();

			//M1明細部データをフォーマットする。
			IList m1DataList = (IList)M1.DataSource;
			
			for (int index = 0; index < M1.Items.Count; index++)
			{
				Tf030f02M1Form tf030f02M1Form = (Tf030f02M1Form)m1DataList[index];
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1rowno"),
					DataFormatUtil.GetFormatItem(tf030f02M1Form.M1rowno,formInfo["M1rowno"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1tekiyo_cd"),
					DataFormatUtil.GetFormatItem(tf030f02M1Form.M1tekiyo_cd,formInfo["M1tekiyo_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1tekiyo_nm"),
					DataFormatUtil.GetFormatItem(tf030f02M1Form.M1tekiyo_nm,formInfo["M1tekiyo_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1suryo"),
					DataFormatUtil.GetFormatItem(tf030f02M1Form.M1suryo,formInfo["M1suryo"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1tnk"),
					DataFormatUtil.GetFormatItem(tf030f02M1Form.M1tnk,formInfo["M1tnk"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1kingaku"),
					DataFormatUtil.GetFormatItem(tf030f02M1Form.M1kingaku,formInfo["M1kingaku"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1suryo_hdn"),
					DataFormatUtil.GetFormatItem(tf030f02M1Form.M1suryo_hdn,formInfo["M1suryo_hdn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1kingaku_hdn"),
					DataFormatUtil.GetFormatItem(tf030f02M1Form.M1kingaku_hdn,formInfo["M1kingaku_hdn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1selectorcheckbox"),
					DataFormatUtil.GetFormatItem(tf030f02M1Form.M1selectorcheckbox,formInfo["M1selectorcheckbox"]));
				((System.Web.UI.WebControls.CheckBox)M1.Items[index].FindControl("M1selectorcheckbox")).Text =
					formResource.GetString("M1selectorcheckbox", lang);
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1entersyoriflg"),
					DataFormatUtil.GetFormatItem(tf030f02M1Form.M1entersyoriflg,formInfo["M1entersyoriflg"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1dtlirokbn"),
					DataFormatUtil.GetFormatItem(tf030f02M1Form.M1dtlirokbn,formInfo["M1dtlirokbn"]));

				if(!base.CheckUseSelfCustomize()){
					((System.Web.UI.HtmlControls.HtmlInputButton)M1.Items[index].FindControl("M1btntekiyo_cd")).Value =
						formResource.GetString("M1btntekiyo_cd", lang);
					
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
				// (M1.HeaderRow.FindControl("M1tekiyo_cd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tekiyo_cd", lang), base.GetPageContext().FormInfo["M1tekiyo_cd"]);
				// (M1.HeaderRow.FindControl("M1btntekiyo_cd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1btntekiyo_cd", lang), base.GetPageContext().FormInfo["M1btntekiyo_cd"]);
				// (M1.HeaderRow.FindControl("M1tekiyo_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tekiyo_nm", lang), base.GetPageContext().FormInfo["M1tekiyo_nm"]);
				// (M1.HeaderRow.FindControl("M1suryo") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo", lang), base.GetPageContext().FormInfo["M1suryo"]);
				// (M1.HeaderRow.FindControl("M1tnk") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tnk", lang), base.GetPageContext().FormInfo["M1tnk"]);
				// (M1.HeaderRow.FindControl("M1kingaku") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kingaku", lang), base.GetPageContext().FormInfo["M1kingaku"]);
				// (M1.HeaderRow.FindControl("M1suryo_hdn") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo_hdn", lang), base.GetPageContext().FormInfo["M1suryo_hdn"]);
				// (M1.HeaderRow.FindControl("M1kingaku_hdn") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kingaku_hdn", lang), base.GetPageContext().FormInfo["M1kingaku_hdn"]);
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
		/// <param name="tf030f02Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderCard(
			Tf030f02Form tf030f02Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			
			ControlUtil.SetControlValue(Head_tenpo_cd,
				DataFormatUtil.GetFormatItem(tf030f02Form.Head_tenpo_cd,formInfo["Head_tenpo_cd"]));
			ControlUtil.SetControlValue(Head_tenpo_nm,
				DataFormatUtil.GetFormatItem(tf030f02Form.Head_tenpo_nm,formInfo["Head_tenpo_nm"]));
			ControlUtil.SetControlValue(Stkmodeno,
				DataFormatUtil.GetFormatItem(tf030f02Form.Stkmodeno,formInfo["Stkmodeno"]));
			ControlUtil.SetControlValue(Add_ymd,
				DataFormatUtil.GetFormatItem(tf030f02Form.Add_ymd,formInfo["Add_ymd"]));
			ControlUtil.SetControlValue(Tenpo_cd,
				DataFormatUtil.GetFormatItem(tf030f02Form.Tenpo_cd,formInfo["Tenpo_cd"]));
			ControlUtil.SetControlValue(Tenpo_nm,
				DataFormatUtil.GetFormatItem(tf030f02Form.Tenpo_nm,formInfo["Tenpo_nm"]));
			ControlUtil.SetControlValue(Kenpinsya_cd,
				DataFormatUtil.GetFormatItem(tf030f02Form.Kenpinsya_cd,formInfo["Kenpinsya_cd"]));
			ControlUtil.SetControlValue(Kenpinsya_nm,
				DataFormatUtil.GetFormatItem(tf030f02Form.Kenpinsya_nm,formInfo["Kenpinsya_nm"]));
			ControlUtil.SetControlValue(Siiresaki_cd,
				DataFormatUtil.GetFormatItem(tf030f02Form.Siiresaki_cd,formInfo["Siiresaki_cd"]));
			ControlUtil.SetControlValue(Siiresaki_ryaku_nm,
				DataFormatUtil.GetFormatItem(tf030f02Form.Siiresaki_ryaku_nm,formInfo["Siiresaki_ryaku_nm"]));
			ControlUtil.SetControlValue(Denpyo_bango,
				DataFormatUtil.GetFormatItem(tf030f02Form.Denpyo_bango,formInfo["Denpyo_bango"]));
			ControlUtil.SetControlValue(Motodenpyo_bango,
				DataFormatUtil.GetFormatItem(tf030f02Form.Motodenpyo_bango,formInfo["Motodenpyo_bango"]));
			ControlUtil.SetControlValue(Nyuryokutan_cd,
				DataFormatUtil.GetFormatItem(tf030f02Form.Nyuryokutan_cd,formInfo["Nyuryokutan_cd"]));
			ControlUtil.SetControlValue(Nyuryokutan_nm,
				DataFormatUtil.GetFormatItem(tf030f02Form.Nyuryokutan_nm,formInfo["Nyuryokutan_nm"]));
			ControlUtil.SetControlValue(Nohin_ymd,
				DataFormatUtil.GetFormatItem(tf030f02Form.Nohin_ymd,formInfo["Nohin_ymd"]));
			ControlUtil.SetControlValue(Gokei_suryo,
				DataFormatUtil.GetFormatItem(tf030f02Form.Gokei_suryo,formInfo["Gokei_suryo"]));
			ControlUtil.SetControlValue(Gokei_kin,
				DataFormatUtil.GetFormatItem(tf030f02Form.Gokei_kin,formInfo["Gokei_kin"]));

			if(!base.CheckUseSelfCustomize()){
				Btnback.Value = base.FormResourceGetString(formResource, "Btnback", lang);
				Btntenpocd.Value = base.FormResourceGetString(formResource, "Btntenpocd", lang);
				Btntanto_cd.Value = base.FormResourceGetString(formResource, "Btntanto_cd", lang);
				Btnsiiresaki_cd.Value = base.FormResourceGetString(formResource, "Btnsiiresaki_cd", lang);
				Btnrowins.Value = base.FormResourceGetString(formResource, "Btnrowins", lang);
				Btnrowdel.Value = base.FormResourceGetString(formResource, "Btnrowdel", lang);
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
			// UIScreenController controller = new UIScreenController((Tf030f02Form)base.GetPageContext().GetFormVO());
			// controller.ChangeColumnsDisplayMode(M1 ,  new DetailHeaderFixedVO(M1Header , true) , null);

			/*
			 *登録した機能間連携処理を親画面に感知させる。
			 *機能有効させる場合は、コメントアウトを外してください。
			 */
			//DetailUtil.RunPgSyn(this,(StandardBaseForm)base.GetPageContext().GetFormVO());

			#region 画面表示制御
			Tf030f02Form formVo = (Tf030f02Form)base.GetPageContext().GetFormVO();

			// [選択モードNo]が「新規作成」または「修正」の場合
			if (formVo.Stkmodeno.Equals(BoSystemConstant.MODE_INSERT)
				|| formVo.Stkmodeno.Equals(BoSystemConstant.MODE_UPD))
			{
				LoginInfoVO loginInfVo = LoginInfoUtil.GetLoginInfo();

				// 権限取得部品の戻り値が"TRUE"の場合
				if (CheckKengenCls.CheckKengen(loginInfVo))
				{
					// 店舗コードを入力可とする。
					ControlCls.Disable(Tenpo_cd, false);
					ControlCls.Disable(Btntenpocd, false);
				}
				// 権限取得部品の戻り値が"FALSE"の場合
				else
				{
					// 店舗コードを入力不可とする。
					ControlCls.Disable(Tenpo_cd, true);
					ControlCls.Disable(Btntenpocd, true);
				}

				//「新規作成」の場合
				if (formVo.Stkmodeno.Equals(BoSystemConstant.MODE_INSERT))
				{
					// 行追加ボタンを非表示とする。
					ControlCls.Visible(Spanrowins, false);
				}
				//「修正」の場合
				else if (formVo.Stkmodeno.Equals(BoSystemConstant.MODE_UPD))
				{
					// 伝票番号を入力不可とする。
					ControlCls.Disable(Denpyo_bango, true);
				}
			}
			// それ以外の場合
			else
			{
				// 行追加ボタンを使用不可とする。
				ControlCls.Disable(Btnrowins, true);
				// 行削除ボタンを使用不可とする。
				ControlCls.Disable(Btnrowdel, true);
				// 確定ボタンを使用不可とする。
				ControlCls.Disable(Btnenter, true);

				// ヘッダ情報を入力不可とする。
				ControlCls.Disable(Tenpo_cd, true);				// 店舗コード
				ControlCls.Disable(Btntenpocd, true);			// 店舗コードボタン
				ControlCls.Disable(Kenpinsya_cd, true);			// 検品者コード
				ControlCls.Disable(Btntanto_cd, true);			// 担当者コードボタン
				ControlCls.Disable(Siiresaki_cd, true);			// 仕入先コード
				ControlCls.Disable(Btnsiiresaki_cd, true);		// 仕入先コードボタン
				ControlCls.Disable(Denpyo_bango, true);			// 伝票番号
				ControlCls.Disable(Motodenpyo_bango, true);		// 元伝票番号
				ControlCls.Disable(Nohin_ymd, true);			// 納品日

				for (int index = 0; index < M1.Items.Count; index++)
				{
					// 摘要コード、数量、単価を入力不可とする。
					ControlCls.Disable(((MDTextBox)M1.Items[index].FindControl("M1tekiyo_cd")), true);				// Ｍ１摘要コード
					ControlCls.Disable(((HtmlInputButton)M1.Items[index].FindControl("M1btntekiyo_cd")), true);		// Ｍ１摘要コードボタン
					ControlCls.Disable(((MDTextBox)M1.Items[index].FindControl("M1suryo")), true);					// Ｍ１数量
					ControlCls.Disable(((MDTextBox)M1.Items[index].FindControl("M1tnk")), true);					// Ｍ１単価
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
			ControlUtil.SetControlValue(Add_ymd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Add_ymd", lang), base.GetPageContext().FormInfo["Add_ymd"]));
				DataFormatUtil.SetMustColorCaption(Add_ymd_lbl, base.GetPageContext().FormInfo["Add_ymd"]);
			ControlUtil.SetControlValue(Tenpo_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Tenpo_cd", lang), base.GetPageContext().FormInfo["Tenpo_cd"]));
				DataFormatUtil.SetMustColorCaption(Tenpo_cd_lbl, base.GetPageContext().FormInfo["Tenpo_cd"]);
			ControlUtil.SetControlValue(Tenpo_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Tenpo_nm", lang), base.GetPageContext().FormInfo["Tenpo_nm"]));
				DataFormatUtil.SetMustColorCaption(Tenpo_nm_lbl, base.GetPageContext().FormInfo["Tenpo_nm"]);
			ControlUtil.SetControlValue(Kenpinsya_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Kenpinsya_cd", lang), base.GetPageContext().FormInfo["Kenpinsya_cd"]));
				DataFormatUtil.SetMustColorCaption(Kenpinsya_cd_lbl, base.GetPageContext().FormInfo["Kenpinsya_cd"]);
			ControlUtil.SetControlValue(Kenpinsya_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Kenpinsya_nm", lang), base.GetPageContext().FormInfo["Kenpinsya_nm"]));
				DataFormatUtil.SetMustColorCaption(Kenpinsya_nm_lbl, base.GetPageContext().FormInfo["Kenpinsya_nm"]);
			ControlUtil.SetControlValue(Siiresaki_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Siiresaki_cd", lang), base.GetPageContext().FormInfo["Siiresaki_cd"]));
				DataFormatUtil.SetMustColorCaption(Siiresaki_cd_lbl, base.GetPageContext().FormInfo["Siiresaki_cd"]);
			ControlUtil.SetControlValue(Siiresaki_ryaku_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Siiresaki_ryaku_nm", lang), base.GetPageContext().FormInfo["Siiresaki_ryaku_nm"]));
				DataFormatUtil.SetMustColorCaption(Siiresaki_ryaku_nm_lbl, base.GetPageContext().FormInfo["Siiresaki_ryaku_nm"]);
			ControlUtil.SetControlValue(Denpyo_bango_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Denpyo_bango", lang), base.GetPageContext().FormInfo["Denpyo_bango"]));
				DataFormatUtil.SetMustColorCaption(Denpyo_bango_lbl, base.GetPageContext().FormInfo["Denpyo_bango"]);
			ControlUtil.SetControlValue(Motodenpyo_bango_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Motodenpyo_bango", lang), base.GetPageContext().FormInfo["Motodenpyo_bango"]));
				DataFormatUtil.SetMustColorCaption(Motodenpyo_bango_lbl, base.GetPageContext().FormInfo["Motodenpyo_bango"]);
			ControlUtil.SetControlValue(Nyuryokutan_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Nyuryokutan_cd", lang), base.GetPageContext().FormInfo["Nyuryokutan_cd"]));
				DataFormatUtil.SetMustColorCaption(Nyuryokutan_cd_lbl, base.GetPageContext().FormInfo["Nyuryokutan_cd"]);
			ControlUtil.SetControlValue(Nyuryokutan_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Nyuryokutan_nm", lang), base.GetPageContext().FormInfo["Nyuryokutan_nm"]));
				DataFormatUtil.SetMustColorCaption(Nyuryokutan_nm_lbl, base.GetPageContext().FormInfo["Nyuryokutan_nm"]);
			ControlUtil.SetControlValue(Nohin_ymd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Nohin_ymd", lang), base.GetPageContext().FormInfo["Nohin_ymd"]));
				DataFormatUtil.SetMustColorCaption(Nohin_ymd_lbl, base.GetPageContext().FormInfo["Nohin_ymd"]);
			ControlUtil.SetControlValue(Gokei_suryo_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Gokei_suryo", lang), base.GetPageContext().FormInfo["Gokei_suryo"]));
				DataFormatUtil.SetMustColorCaption(Gokei_suryo_lbl, base.GetPageContext().FormInfo["Gokei_suryo"]);
			ControlUtil.SetControlValue(Gokei_kin_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Gokei_kin", lang), base.GetPageContext().FormInfo["Gokei_kin"]));
				DataFormatUtil.SetMustColorCaption(Gokei_kin_lbl, base.GetPageContext().FormInfo["Gokei_kin"]);
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
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tekiyo_cd", lang), base.GetPageContext().FormInfo["M1tekiyo_cd"]);
				// M1.Columns[2].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1btntekiyo_cd", lang), base.GetPageContext().FormInfo["M1btntekiyo_cd"]);
				// M1.Columns[3].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tekiyo_nm", lang), base.GetPageContext().FormInfo["M1tekiyo_nm"]);
				// M1.Columns[4].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo", lang), base.GetPageContext().FormInfo["M1suryo"]);
				// M1.Columns[5].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tnk", lang), base.GetPageContext().FormInfo["M1tnk"]);
				// M1.Columns[6].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kingaku", lang), base.GetPageContext().FormInfo["M1kingaku"]);
				// M1.Columns[7].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo_hdn", lang), base.GetPageContext().FormInfo["M1suryo_hdn"]);
				// M1.Columns[8].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kingaku_hdn", lang), base.GetPageContext().FormInfo["M1kingaku_hdn"]);
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
				Windowtitle.InnerText = formResource.GetString("Tf030f02_Titlebar", lang);
				header.FormName = formResource.GetString("Tf030f02_FormCaption", lang);
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
