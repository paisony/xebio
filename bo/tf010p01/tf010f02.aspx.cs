using com.xebio.bo.Tf010p01.Constant;
using com.xebio.bo.Tf010p01.Facade;
using com.xebio.bo.Tf010p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.Model.Context;
using Common.Advanced.Resource;
using Common.Advanced.Web.Context;
using Common.Advanced.Web.Util;
using Common.Business.C01000.C01014;
using Common.Business.C01000.C01015;
using Common.Business.C01000.C01019;
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

namespace com.xebio.bo.Tf010p01.Page
{
  /// <summary>
  /// Tf010f02のコードビハインドです。
  /// </summary>
  public partial class Tf010f02Page : StandardBasePage
	{

		#region メソッド

		#region ページデータをロードするメソッド
		/// <summary>
		/// Tf010f02画面データを作成する。
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
						pageContext.SetFormVO(new Tf010f02Form());
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
								new Tf010f02Facade().DoLoad(facadeContext);
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

		#region フォームを呼び出します(ボタンID : Btnback())
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnback())
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
			
			try
			{

				//アクションロジックを処理します
				IFacadeContext facadeContext = FacadeContextFactory.GetFacadeContext(pageContext);
				InitFacadeContext(facadeContext);
				new Tf010f02Facade().DoBTNBACK_FRM(facadeContext);
				
				
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
			// フォーカス設定用変数
			string focusItem = string.Empty;
			string focusMno = string.Empty;

			// 選択された管理Noにフォーカス設定
			focusItem = "M1denpyo_bango";
			focusMno = (string)((Tf010f02Form)pageContext.GetFormVO(Tf010p01Constant.PGID, Tf010p01Constant.FORMID_02)).Dictionary[Tf010p01Constant.DIC_M1SELECTROWIDX];

			// フォーカス設定
			queryList = SetFocusCls.SetFocus(queryList, focusItem, focusMno);
			
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
				new Tf010f02Facade().DoBTNROWINS_MADD(facadeContext);

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

			// 画面より情報を取得する。
			Tf010f02Form formVO = (Tf010f02Form)pageContext.GetFormVO();
			//M1明細データを表示する。
			IDataList m1List = formVO.GetList("M1");

			// フォーカス設定用変数
			string focusItem = string.Empty;
			string focusMno = string.Empty;

			// 表示明細先頭の伝票番号にフォーカス設定
			focusItem = "M1scan_cd";
			focusMno = ((m1List.EndRow % m1List.DispRow) - 1).ToString();

			// フォーカス設定
			queryList = SetFocusCls.SetFocus(queryList, focusItem, focusMno);
				
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
				new Tf010f02Facade().DoBTNROWDEL_FRM(facadeContext);
				
				
				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
					base.SetError(pageContext);
					return;
				}

				// フォーカス行をコードビハインドに戻す
				lastRow = (decimal)facadeContext.GetUserObject(Tf010p01Constant.FCDUO_FOCUSROW);

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

			LoginInfoVO loginInfVo = LoginInfoUtil.GetLoginInfo();

			// フォーカス設定用変数
			string focusItem = "M1scan_cd";
			string focusMno = string.Empty;

			// 削除行の次の行にフォーカス設定
			focusMno = lastRow.ToString();

			// フォーカス設定
			queryList = SetFocusCls.SetFocus(queryList, focusItem, focusMno);

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
				new Tf010f02Facade().DoBTNENTER_FRM(facadeContext);
				
				
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

				#region 出力PDFファイルダウンロード設定

				// PDFファイル名取得
				string pdfNm = facadeContext.GetUserObject(Tf010p01Constant.FCDUO_RRT_FLNM) as string;

				// サーバファイルフルパス
				string serverPath = string.Format(
					"{0}{1}{2}",
					FilePathManager.GetOutFilePath(Tf010p01Constant.PGID),
					Path.DirectorySeparatorChar,
					pdfNm
					);

				// クライアントファイル名
				string clientNm = string.Format(
					"{0}.{1}",
					BoSystemReport.CreateFileName(BoSystemConstant.REPORTNM_SYOHINKEIHIFURIKAEDENPYO_X, 2),
					BoSystemConstant.RPT_PDF_EXTENSION
					);

				// 単一ダウンロード情報
				DLConditionVO dlvo = new DLConditionVO();

				// ダウンロード用VOに値を設定
				dlvo.setSingleFileDownloadCondition(serverPath, clientNm);

				// 単一ダウンロード用にVOをセッションにセット
				SessionInfoUtil.SetPgObject(pageContext.CommandInfo.ProgramId, Tf010p01Constant.SESSION_KEY_DOWNLOAD_INFO, dlvo, Session);

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
			
			//フォーカスを当てる項目を指定したい場合はFormFocusUtilを使ってqueryListに追加すること

			// フォーカス設定用変数
			string focusItem = string.Empty;
			string focusMno = string.Empty;

			// 選択された管理Noにフォーカス設定
			focusItem = "M1denpyo_bango";
			focusMno = (string)((Tf010f02Form)pageContext.GetFormVO(Tf010p01Constant.PGID, Tf010p01Constant.FORMID_02)).Dictionary[Tf010p01Constant.DIC_M1SELECTROWIDX];

			// フォーカス設定
			queryList = SetFocusCls.SetFocus(queryList, focusItem, focusMno);

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
						Tf010f02Form tf010f02Form = (Tf010f02Form)pageContext.GetFormVO();

						//明細ページ情報を表示する
						ShowListPageInfo(tf010f02Form);
			
						//明細部データを表示する
						RenderList(tf010f02Form, pageContext.FormInfo, formResource, lang);

						//カード部データを表示する
						RenderCard(tf010f02Form, pageContext.FormInfo, formResource, lang);
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
		/// <param name="tf010f02Form">画面FormVO</param>
		private void ShowListPageInfo(Tf010f02Form tf010f02Form)
		{
			//M1明細ページ情報を表示する。
			ShowM1ListPageInfo(tf010f02Form.GetList("M1"));

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
		/// <param name="tf010f02Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderList(
			Tf010f02Form tf010f02Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//画面のM1明細部データを設定する。
			RenderM1List(tf010f02Form, formInfo, formResource, lang);
			
		}
		#endregion

		#region M1明細データを表示する
		/// <summary>
		/// M1明細データを表示する。
		/// </summary>
		/// <param name="tf010f02Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderM1List(
			Tf010f02Form tf010f02Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//M1明細部データソースを設定する。
			M1.DataSource = tf010f02Form.GetPageViewList("M1");
			M1.DataBind();

			//M1明細部データをフォーマットする。
			IList m1DataList = (IList)M1.DataSource;
			
			for (int index = 0; index < M1.Items.Count; index++)
			{
				Tf010f02M1Form tf010f02M1Form = (Tf010f02M1Form)m1DataList[index];
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1rowno"),
					DataFormatUtil.GetFormatItem(tf010f02M1Form.M1rowno,formInfo["M1rowno"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1bumon_cd"),
					DataFormatUtil.GetFormatItem(tf010f02M1Form.M1bumon_cd,formInfo["M1bumon_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1bumonkana_nm"),
					DataFormatUtil.GetFormatItem(tf010f02M1Form.M1bumonkana_nm,formInfo["M1bumonkana_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1burando_nm"),
					DataFormatUtil.GetFormatItem(tf010f02M1Form.M1burando_nm,formInfo["M1burando_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1maker_hbn"),
					DataFormatUtil.GetFormatItem(tf010f02M1Form.M1maker_hbn,formInfo["M1maker_hbn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1iro_nm"),
					DataFormatUtil.GetFormatItem(tf010f02M1Form.M1iro_nm,formInfo["M1iro_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1scan_cd"),
					DataFormatUtil.GetFormatItem(tf010f02M1Form.M1scan_cd,formInfo["M1scan_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1suryo"),
					DataFormatUtil.GetFormatItem(tf010f02M1Form.M1suryo,formInfo["M1suryo"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1gen_tnk"),
					DataFormatUtil.GetFormatItem(tf010f02M1Form.M1gen_tnk,formInfo["M1gen_tnk"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1genka_kin"),
					DataFormatUtil.GetFormatItem(tf010f02M1Form.M1genka_kin,formInfo["M1genka_kin"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1hinsyu_ryaku_nm"),
					DataFormatUtil.GetFormatItem(tf010f02M1Form.M1hinsyu_ryaku_nm,formInfo["M1hinsyu_ryaku_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1jisya_hbn"),
					DataFormatUtil.GetFormatItem(tf010f02M1Form.M1jisya_hbn,formInfo["M1jisya_hbn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1syonmk"),
					DataFormatUtil.GetFormatItem(tf010f02M1Form.M1syonmk,formInfo["M1syonmk"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1size_nm"),
					DataFormatUtil.GetFormatItem(tf010f02M1Form.M1size_nm,formInfo["M1size_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1genbaika_tnk"),
					DataFormatUtil.GetFormatItem(tf010f02M1Form.M1genbaika_tnk,formInfo["M1genbaika_tnk"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1baika_kin"),
					DataFormatUtil.GetFormatItem(tf010f02M1Form.M1baika_kin,formInfo["M1baika_kin"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1suryo_hdn"),
					DataFormatUtil.GetFormatItem(tf010f02M1Form.M1suryo_hdn,formInfo["M1suryo_hdn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1genka_kin_hdn"),
					DataFormatUtil.GetFormatItem(tf010f02M1Form.M1genka_kin_hdn,formInfo["M1genka_kin_hdn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1baika_kin_hdn"),
					DataFormatUtil.GetFormatItem(tf010f02M1Form.M1baika_kin_hdn,formInfo["M1baika_kin_hdn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1selectorcheckbox"),
					DataFormatUtil.GetFormatItem(tf010f02M1Form.M1selectorcheckbox,formInfo["M1selectorcheckbox"]));
				((System.Web.UI.WebControls.CheckBox)M1.Items[index].FindControl("M1selectorcheckbox")).Text =
					formResource.GetString("M1selectorcheckbox", lang);
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1entersyoriflg"),
					DataFormatUtil.GetFormatItem(tf010f02M1Form.M1entersyoriflg,formInfo["M1entersyoriflg"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1dtlirokbn"),
					DataFormatUtil.GetFormatItem(tf010f02M1Form.M1dtlirokbn,formInfo["M1dtlirokbn"]));

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
				// (M1.HeaderRow.FindControl("M1bumon_cd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumon_cd", lang), base.GetPageContext().FormInfo["M1bumon_cd"]);
				// (M1.HeaderRow.FindControl("M1bumonkana_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumonkana_nm", lang), base.GetPageContext().FormInfo["M1bumonkana_nm"]);
				// (M1.HeaderRow.FindControl("M1burando_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1burando_nm", lang), base.GetPageContext().FormInfo["M1burando_nm"]);
				// (M1.HeaderRow.FindControl("M1maker_hbn") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1maker_hbn", lang), base.GetPageContext().FormInfo["M1maker_hbn"]);
				// (M1.HeaderRow.FindControl("M1iro_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1iro_nm", lang), base.GetPageContext().FormInfo["M1iro_nm"]);
				// (M1.HeaderRow.FindControl("M1scan_cd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1scan_cd", lang), base.GetPageContext().FormInfo["M1scan_cd"]);
				// (M1.HeaderRow.FindControl("M1suryo") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo", lang), base.GetPageContext().FormInfo["M1suryo"]);
				// (M1.HeaderRow.FindControl("M1gen_tnk") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1gen_tnk", lang), base.GetPageContext().FormInfo["M1gen_tnk"]);
				// (M1.HeaderRow.FindControl("M1genka_kin") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1genka_kin", lang), base.GetPageContext().FormInfo["M1genka_kin"]);
				// (M1.HeaderRow.FindControl("M1hinsyu_ryaku_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hinsyu_ryaku_nm", lang), base.GetPageContext().FormInfo["M1hinsyu_ryaku_nm"]);
				// (M1.HeaderRow.FindControl("M1jisya_hbn") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1jisya_hbn", lang), base.GetPageContext().FormInfo["M1jisya_hbn"]);
				// (M1.HeaderRow.FindControl("M1syonmk") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syonmk", lang), base.GetPageContext().FormInfo["M1syonmk"]);
				// (M1.HeaderRow.FindControl("M1size_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1size_nm", lang), base.GetPageContext().FormInfo["M1size_nm"]);
				// (M1.HeaderRow.FindControl("M1genbaika_tnk") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1genbaika_tnk", lang), base.GetPageContext().FormInfo["M1genbaika_tnk"]);
				// (M1.HeaderRow.FindControl("M1baika_kin") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1baika_kin", lang), base.GetPageContext().FormInfo["M1baika_kin"]);
				// (M1.HeaderRow.FindControl("M1suryo_hdn") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo_hdn", lang), base.GetPageContext().FormInfo["M1suryo_hdn"]);
				// (M1.HeaderRow.FindControl("M1genka_kin_hdn") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1genka_kin_hdn", lang), base.GetPageContext().FormInfo["M1genka_kin_hdn"]);
				// (M1.HeaderRow.FindControl("M1baika_kin_hdn") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1baika_kin_hdn", lang), base.GetPageContext().FormInfo["M1baika_kin_hdn"]);
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
		/// <param name="tf010f02Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderCard(
			Tf010f02Form tf010f02Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			
			ControlUtil.SetControlValue(Head_tenpo_cd,
				DataFormatUtil.GetFormatItem(tf010f02Form.Head_tenpo_cd,formInfo["Head_tenpo_cd"]));
			ControlUtil.SetControlValue(Head_tenpo_nm,
				DataFormatUtil.GetFormatItem(tf010f02Form.Head_tenpo_nm,formInfo["Head_tenpo_nm"]));
			ControlUtil.SetControlValue(Stkmodeno,
				DataFormatUtil.GetFormatItem(tf010f02Form.Stkmodeno,formInfo["Stkmodeno"]));
			ControlUtil.SetControlValue(Apply_ymd,
				DataFormatUtil.GetFormatItem(tf010f02Form.Apply_ymd,formInfo["Apply_ymd"]));
			ControlUtil.SetControlValue(Shinsei_tenpo_cd,
				DataFormatUtil.GetFormatItem(tf010f02Form.Shinsei_tenpo_cd,formInfo["Shinsei_tenpo_cd"]));
			ControlUtil.SetControlValue(Shinsei_tenpo_nm,
				DataFormatUtil.GetFormatItem(tf010f02Form.Shinsei_tenpo_nm,formInfo["Shinsei_tenpo_nm"]));
			ControlUtil.SetControlValue(Sinseitan_cd,
				DataFormatUtil.GetFormatItem(tf010f02Form.Sinseitan_cd,formInfo["Sinseitan_cd"]));
			ControlUtil.SetControlValue(Sinseitan_nm,
				DataFormatUtil.GetFormatItem(tf010f02Form.Sinseitan_nm,formInfo["Sinseitan_nm"]));
			ControlUtil.SetControlValue(Denpyo_bango,
				DataFormatUtil.GetFormatItem(tf010f02Form.Denpyo_bango,formInfo["Denpyo_bango"]));
			ControlUtil.SetControlValue(Sinseiriyu_kb,
				DataFormatUtil.GetFormatItem(tf010f02Form.Sinseiriyu_kb,formInfo["Sinseiriyu_kb"]));
			ControlUtil.SetControlValue(Sinseiriyu,
				DataFormatUtil.GetFormatItem(tf010f02Form.Sinseiriyu,formInfo["Sinseiriyu"]));
			ControlUtil.SetControlValue(Kakuteitan_cd,
				DataFormatUtil.GetFormatItem(tf010f02Form.Kakuteitan_cd,formInfo["Kakuteitan_cd"]));
			ControlUtil.SetControlValue(Kakuteitan_nm,
				DataFormatUtil.GetFormatItem(tf010f02Form.Kakuteitan_nm,formInfo["Kakuteitan_nm"]));
			ControlUtil.SetControlValue(Kakutei_ymd,
				DataFormatUtil.GetFormatItem(tf010f02Form.Kakutei_ymd,formInfo["Kakutei_ymd"]));
			ControlUtil.SetControlValue(Kamoku_cd,
				DataFormatUtil.GetFormatItem(tf010f02Form.Kamoku_cd,formInfo["Kamoku_cd"]));
			ControlUtil.SetControlValue(Kamoku_nm,
				DataFormatUtil.GetFormatItem(tf010f02Form.Kamoku_nm,formInfo["Kamoku_nm"]));
			ControlUtil.SetControlValue(Kyakkariyu,
				DataFormatUtil.GetFormatItem(tf010f02Form.Kyakkariyu,formInfo["Kyakkariyu"]));
			ControlUtil.SetControlValue(Gyomuringi_no,
				DataFormatUtil.GetFormatItem(tf010f02Form.Gyomuringi_no,formInfo["Gyomuringi_no"]));
			ControlUtil.SetControlValue(Jyuri_no,
				DataFormatUtil.GetFormatItem(tf010f02Form.Jyuri_no,formInfo["Jyuri_no"]));
			ControlUtil.SetControlValue(Syonin_flg_nm,
				DataFormatUtil.GetFormatItem(tf010f02Form.Syonin_flg_nm,formInfo["Syonin_flg_nm"]));
			ControlUtil.SetControlValue(Gokei_suryo,
				DataFormatUtil.GetFormatItem(tf010f02Form.Gokei_suryo,formInfo["Gokei_suryo"]));
			ControlUtil.SetControlValue(Genka_kin_gokei1,
				DataFormatUtil.GetFormatItem(tf010f02Form.Genka_kin_gokei1,formInfo["Genka_kin_gokei1"]));

			if(!base.CheckUseSelfCustomize()){
				Btnback.Value = base.FormResourceGetString(formResource, "Btnback", lang);
				Btnkamokucd.Value = base.FormResourceGetString(formResource, "Btnkamokucd", lang);
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
			// UIScreenController controller = new UIScreenController((Tf010f02Form)base.GetPageContext().GetFormVO());
			// controller.ChangeColumnsDisplayMode(M1 ,  new DetailHeaderFixedVO(M1Header , true) , null);

			/*
			 *登録した機能間連携処理を親画面に感知させる。
			 *機能有効させる場合は、コメントアウトを外してください。
			 */
			//DetailUtil.RunPgSyn(this,(StandardBaseForm)base.GetPageContext().GetFormVO());

			#region 画面表示制御

			Tf010f02Form formVo = (Tf010f02Form)base.GetPageContext().GetFormVO();
			IList m1DataList = formVo.GetPageViewList("M1");

			// 一覧画面選択行のVO
			Tf010f01M1Form f01M1Form = (Tf010f01M1Form)formVo.Dictionary[Tf010p01Constant.DIC_M1SELECTVO];

			// [選択モードNo]が「取消」「照会」の場合
			if (   BoSystemConstant.MODE_DEL.Equals(formVo.Stkmodeno)
				|| BoSystemConstant.MODE_REF.Equals(formVo.Stkmodeno)
				|| BoSystemConstant.CHECKBOX_ON.Equals(f01M1Form.Dictionary[Tf010p01Constant.DIC_M1F02ENTERSYORI_FLG].ToString()))
			{

				ControlCls.Disable(Sinseiriyu_kb, true);
				ControlCls.Disable(Sinseiriyu, true);
				ControlCls.Disable(Kamoku_cd, true);
				ControlCls.Disable(Btnkamokucd, true);
				ControlCls.Disable(Kyakkariyu, true);
				ControlCls.Disable(Gyomuringi_no, true);

				// 明細部の制御
				for (int index = 0; index < M1.Items.Count; index++)
				{
					ControlCls.Disable(((MDTextBox)M1.Items[index].FindControl("M1scan_cd")), true);
					ControlCls.Disable(((MDTextBox)M1.Items[index].FindControl("M1suryo")), true);
				}

				// 行追加ボタンを使用不可とする。
				ControlCls.Disable(Btnrowins, true);
				// 行削除ボタンを使用不可とする。
				ControlCls.Disable(Btnrowdel, true);
				// 確定ボタンを使用不可とする。
				ControlCls.Disable(Btnenter, true);
			}

			// Vの場合
			if (!CheckCompanyCls.IsXebio())
			{
				ControlCls.Disable(Gyomuringi_no, true);
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
			ControlUtil.SetControlValue(Apply_ymd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Apply_ymd", lang), base.GetPageContext().FormInfo["Apply_ymd"]));
				DataFormatUtil.SetMustColorCaption(Apply_ymd_lbl, base.GetPageContext().FormInfo["Apply_ymd"]);
			ControlUtil.SetControlValue(Shinsei_tenpo_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Shinsei_tenpo_cd", lang), base.GetPageContext().FormInfo["Shinsei_tenpo_cd"]));
				DataFormatUtil.SetMustColorCaption(Shinsei_tenpo_cd_lbl, base.GetPageContext().FormInfo["Shinsei_tenpo_cd"]);
			ControlUtil.SetControlValue(Shinsei_tenpo_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Shinsei_tenpo_nm", lang), base.GetPageContext().FormInfo["Shinsei_tenpo_nm"]));
				DataFormatUtil.SetMustColorCaption(Shinsei_tenpo_nm_lbl, base.GetPageContext().FormInfo["Shinsei_tenpo_nm"]);
			ControlUtil.SetControlValue(Sinseitan_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Sinseitan_cd", lang), base.GetPageContext().FormInfo["Sinseitan_cd"]));
				DataFormatUtil.SetMustColorCaption(Sinseitan_cd_lbl, base.GetPageContext().FormInfo["Sinseitan_cd"]);
			ControlUtil.SetControlValue(Sinseitan_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Sinseitan_nm", lang), base.GetPageContext().FormInfo["Sinseitan_nm"]));
				DataFormatUtil.SetMustColorCaption(Sinseitan_nm_lbl, base.GetPageContext().FormInfo["Sinseitan_nm"]);
			ControlUtil.SetControlValue(Denpyo_bango_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Denpyo_bango", lang), base.GetPageContext().FormInfo["Denpyo_bango"]));
				DataFormatUtil.SetMustColorCaption(Denpyo_bango_lbl, base.GetPageContext().FormInfo["Denpyo_bango"]);
			ControlUtil.SetControlValue(Sinseiriyu_kb_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Sinseiriyu_kb", lang), base.GetPageContext().FormInfo["Sinseiriyu_kb"]));
				DataFormatUtil.SetMustColorCaption(Sinseiriyu_kb_lbl, base.GetPageContext().FormInfo["Sinseiriyu_kb"]);
			ControlUtil.SetControlValue(Sinseiriyu_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Sinseiriyu", lang), base.GetPageContext().FormInfo["Sinseiriyu"]));
				DataFormatUtil.SetMustColorCaption(Sinseiriyu_lbl, base.GetPageContext().FormInfo["Sinseiriyu"]);
			ControlUtil.SetControlValue(Kakuteitan_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Kakuteitan_cd", lang), base.GetPageContext().FormInfo["Kakuteitan_cd"]));
				DataFormatUtil.SetMustColorCaption(Kakuteitan_cd_lbl, base.GetPageContext().FormInfo["Kakuteitan_cd"]);
			ControlUtil.SetControlValue(Kakuteitan_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Kakuteitan_nm", lang), base.GetPageContext().FormInfo["Kakuteitan_nm"]));
				DataFormatUtil.SetMustColorCaption(Kakuteitan_nm_lbl, base.GetPageContext().FormInfo["Kakuteitan_nm"]);
			ControlUtil.SetControlValue(Kakutei_ymd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Kakutei_ymd", lang), base.GetPageContext().FormInfo["Kakutei_ymd"]));
				DataFormatUtil.SetMustColorCaption(Kakutei_ymd_lbl, base.GetPageContext().FormInfo["Kakutei_ymd"]);
			ControlUtil.SetControlValue(Kamoku_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Kamoku_cd", lang), base.GetPageContext().FormInfo["Kamoku_cd"]));
				DataFormatUtil.SetMustColorCaption(Kamoku_cd_lbl, base.GetPageContext().FormInfo["Kamoku_cd"]);
			ControlUtil.SetControlValue(Kamoku_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Kamoku_nm", lang), base.GetPageContext().FormInfo["Kamoku_nm"]));
				DataFormatUtil.SetMustColorCaption(Kamoku_nm_lbl, base.GetPageContext().FormInfo["Kamoku_nm"]);
			ControlUtil.SetControlValue(Kyakkariyu_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Kyakkariyu", lang), base.GetPageContext().FormInfo["Kyakkariyu"]));
				DataFormatUtil.SetMustColorCaption(Kyakkariyu_lbl, base.GetPageContext().FormInfo["Kyakkariyu"]);
			ControlUtil.SetControlValue(Gyomuringi_no_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Gyomuringi_no", lang), base.GetPageContext().FormInfo["Gyomuringi_no"]));
				DataFormatUtil.SetMustColorCaption(Gyomuringi_no_lbl, base.GetPageContext().FormInfo["Gyomuringi_no"]);
			ControlUtil.SetControlValue(Jyuri_no_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Jyuri_no", lang), base.GetPageContext().FormInfo["Jyuri_no"]));
				DataFormatUtil.SetMustColorCaption(Jyuri_no_lbl, base.GetPageContext().FormInfo["Jyuri_no"]);
			ControlUtil.SetControlValue(Syonin_flg_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Syonin_flg_nm", lang), base.GetPageContext().FormInfo["Syonin_flg_nm"]));
				DataFormatUtil.SetMustColorCaption(Syonin_flg_nm_lbl, base.GetPageContext().FormInfo["Syonin_flg_nm"]);
			ControlUtil.SetControlValue(Gokei_suryo_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Gokei_suryo", lang), base.GetPageContext().FormInfo["Gokei_suryo"]));
				DataFormatUtil.SetMustColorCaption(Gokei_suryo_lbl, base.GetPageContext().FormInfo["Gokei_suryo"]);
			ControlUtil.SetControlValue(Genka_kin_gokei1_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Genka_kin_gokei1", lang), base.GetPageContext().FormInfo["Genka_kin_gokei1"]));
				DataFormatUtil.SetMustColorCaption(Genka_kin_gokei1_lbl, base.GetPageContext().FormInfo["Genka_kin_gokei1"]);
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
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1burando_nm", lang), base.GetPageContext().FormInfo["M1burando_nm"]);
				// M1.Columns[4].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1maker_hbn", lang), base.GetPageContext().FormInfo["M1maker_hbn"]);
				// M1.Columns[5].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1iro_nm", lang), base.GetPageContext().FormInfo["M1iro_nm"]);
				// M1.Columns[6].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1scan_cd", lang), base.GetPageContext().FormInfo["M1scan_cd"]);
				// M1.Columns[7].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo", lang), base.GetPageContext().FormInfo["M1suryo"]);
				// M1.Columns[8].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1gen_tnk", lang), base.GetPageContext().FormInfo["M1gen_tnk"]);
				// M1.Columns[9].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1genka_kin", lang), base.GetPageContext().FormInfo["M1genka_kin"]);
				// M1.Columns[10].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hinsyu_ryaku_nm", lang), base.GetPageContext().FormInfo["M1hinsyu_ryaku_nm"]);
				// M1.Columns[11].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1jisya_hbn", lang), base.GetPageContext().FormInfo["M1jisya_hbn"]);
				// M1.Columns[12].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syonmk", lang), base.GetPageContext().FormInfo["M1syonmk"]);
				// M1.Columns[13].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1size_nm", lang), base.GetPageContext().FormInfo["M1size_nm"]);
				// M1.Columns[14].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1genbaika_tnk", lang), base.GetPageContext().FormInfo["M1genbaika_tnk"]);
				// M1.Columns[15].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1baika_kin", lang), base.GetPageContext().FormInfo["M1baika_kin"]);
				// M1.Columns[16].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo_hdn", lang), base.GetPageContext().FormInfo["M1suryo_hdn"]);
				// M1.Columns[17].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1genka_kin_hdn", lang), base.GetPageContext().FormInfo["M1genka_kin_hdn"]);
				// M1.Columns[18].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1baika_kin_hdn", lang), base.GetPageContext().FormInfo["M1baika_kin_hdn"]);
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
				Windowtitle.InnerText = formResource.GetString("Tf010f02_Titlebar", lang);
				header.FormName = formResource.GetString("Tf010f02_FormCaption", lang);
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
