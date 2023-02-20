using com.xebio.bo.Tb090p01.Constant;
using com.xebio.bo.Tb090p01.Facade;
using com.xebio.bo.Tb090p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.Model.Context;
using Common.Advanced.Resource;
using Common.Advanced.Web.Context;
using Common.Advanced.Web.Util;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01014;
using Common.Business.C01000.C01015;
using Common.Business.C01000.C01016;
using Common.Business.C99999.Constant;
using Common.Business.C99999.ReportUtil;
using Common.Business.C99999.StringUtil;
using Common.Conditions;
using Common.IntegrationMD.MDControl;
using Common.IntegrationMD.Util;
using Common.Standard.Base;
using Common.Standard.Message;
using Common.Standard.Session;
using Common.Standard.Util;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.IO;

namespace com.xebio.bo.Tb090p01.Page
{
  /// <summary>
  /// Tb090f02のコードビハインドです。
  /// </summary>
  public partial class Tb090f02Page : StandardBasePage
	{

		#region メソッド

		#region ページデータをロードするメソッド
		/// <summary>
		/// Tb090f02画面データを作成する。
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
						pageContext.SetFormVO(new Tb090f02Form());
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
								new Tb090f02Facade().DoLoad(facadeContext);
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
			
			try
			{

				//アクションロジックを処理します
				IFacadeContext facadeContext = FacadeContextFactory.GetFacadeContext(pageContext);
				InitFacadeContext(facadeContext);
				new Tb090f02Facade().DoBTNBACK_FRM(facadeContext);
				
				
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

			// 選択された元伝票番号にフォーカス設定
			focusItem = "M1motodenpyo_bango";
			focusMno = (string)((Tb090f02Form)pageContext.GetFormVO(Tb090p01Constant.PGID, Tb090p01Constant.FORMID_02)).Dictionary[Tb090p01Constant.DIC_M1SELCETROWIDX];

			// フォーカス設定
			queryList = SetFocusCls.SetFocus(queryList, focusItem, focusMno);

			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNBACK_FRM");
			
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
				new Tb090f02Facade().DoBTNENTER_FRM(facadeContext);

				// 警告判定
				if (InfoMsgCls.HasWarn(facadeContext))
				{
					// 警告メッセージの表示
					string script = InfoMsgCls.showLoadMsg(pageContext, 2, "Btnenter");
					Page.ClientScript.RegisterStartupScript(typeof(string), "infoDialog", script);
					return;
				}

				// 一覧画面VO
				FormVOManager fvm = new FormVOManager(Session);
				Tb090f01Form f01VO = (Tb090f01Form)fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Tb090p01Constant.FORMID_01);
				// 明細画面VO
				Tb090f02Form f02VO = (Tb090f02Form)facadeContext.FormVO;

				IDataList m1List = f01VO.GetList("M1");

				// 次画面のフォームビーンを設定
				fvm.SetFormVO(Tb090p01Constant.PGID, Tb090p01Constant.FORMID_01, f01VO);

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
				commandInfo.PageLoadMode = false;

				#region 出力PDFファイルダウンロード設定

				// PDFファイル名取得
				string pdfNm = facadeContext.GetUserObject(Tb090p01Constant.FCDUO_RRT_FLNM) as string;

				// サーバファイルフルパス
				string serverPath = string.Format(
					"{0}{1}{2}",
					FilePathManager.GetOutFilePath(Tb090p01Constant.PGID),
					Path.DirectorySeparatorChar,
					pdfNm
					);

				// クライアントファイル名
				string clientNm = string.Format(
					"{0}.{1}",
					BoSystemReport.CreateFileName(BoSystemConstant.REPORTNM_SIIRETEISEIDENPYO, 2),
					BoSystemConstant.RPT_PDF_EXTENSION
					);

				// 単一ダウンロード情報
				DLConditionVO dlvo = new DLConditionVO();

				// ダウンロード用VOに値を設定
				dlvo.setSingleFileDownloadCondition(serverPath, clientNm);

				// 単一ダウンロード用にVOをセッションにセット
				SessionInfoUtil.SetPgObject(pageContext.CommandInfo.ProgramId, Tb090p01Constant.SESSION_KEY_DOWNLOAD_INFO, dlvo, Session);

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

			// 選択された元伝票番号にフォーカス設定
			focusItem = "M1motodenpyo_bango";
			focusMno = (string)((Tb090f02Form)pageContext.GetFormVO(Tb090p01Constant.PGID, Tb090p01Constant.FORMID_02)).Dictionary[Tb090p01Constant.DIC_M1SELCETROWIDX];

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
					//if (!MessageDisplayUtil.HasError(pageContext))
					//{
						string lang = WebSettingsUtil.GetLangSettingFromSession(pageContext.Session);
						FormResource formResource =
							ResourceFactory.GetFormResource(pageContext.CommandInfo.FormId);
			
						//標題をセットする
						SetCaption(formResource, lang);

						//FormVOを取得する
						Tb090f02Form tb090f02Form = (Tb090f02Form)pageContext.GetFormVO();

						//明細ページ情報を表示する
						ShowListPageInfo(tb090f02Form);
			
						//明細部データを表示する
						RenderList(tb090f02Form, pageContext.FormInfo, formResource, lang);

						//カード部データを表示する
						RenderCard(tb090f02Form, pageContext.FormInfo, formResource, lang);
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
		/// <param name="tb090f02Form">画面FormVO</param>
		private void ShowListPageInfo(Tb090f02Form tb090f02Form)
		{
			//M1明細ページ情報を表示する。
			ShowM1ListPageInfo(tb090f02Form.GetList("M1"));

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
		/// <param name="tb090f02Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderList(
			Tb090f02Form tb090f02Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//画面のM1明細部データを設定する。
			RenderM1List(tb090f02Form, formInfo, formResource, lang);
			
		}
		#endregion

		#region M1明細データを表示する
		/// <summary>
		/// M1明細データを表示する。
		/// </summary>
		/// <param name="tb090f02Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderM1List(
			Tb090f02Form tb090f02Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//M1明細部データソースを設定する。
			M1.DataSource = tb090f02Form.GetPageViewList("M1");
			M1.DataBind();

			//M1明細部データをフォーマットする。
			IList m1DataList = (IList)M1.DataSource;
			
			for (int index = 0; index < M1.Items.Count; index++)
			{
				Tb090f02M1Form tb090f02M1Form = (Tb090f02M1Form)m1DataList[index];
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1rowno"),
					DataFormatUtil.GetFormatItem(tb090f02M1Form.M1rowno,formInfo["M1rowno"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1hinsyu_ryaku_nm"),
					DataFormatUtil.GetFormatItem(tb090f02M1Form.M1hinsyu_ryaku_nm,formInfo["M1hinsyu_ryaku_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1burando_nm"),
					DataFormatUtil.GetFormatItem(tb090f02M1Form.M1burando_nm,formInfo["M1burando_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1jisya_hbn"),
					DataFormatUtil.GetFormatItem(tb090f02M1Form.M1jisya_hbn,formInfo["M1jisya_hbn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1maker_hbn"),
					DataFormatUtil.GetFormatItem(tb090f02M1Form.M1maker_hbn,formInfo["M1maker_hbn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1syonmk"),
					DataFormatUtil.GetFormatItem(tb090f02M1Form.M1syonmk,formInfo["M1syonmk"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1iro_nm"),
					DataFormatUtil.GetFormatItem(tb090f02M1Form.M1iro_nm,formInfo["M1iro_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1size_nm"),
					DataFormatUtil.GetFormatItem(tb090f02M1Form.M1size_nm,formInfo["M1size_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1scan_cd"),
					DataFormatUtil.GetFormatItem(tb090f02M1Form.M1scan_cd,formInfo["M1scan_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1nohin_su"),
					DataFormatUtil.GetFormatItem(tb090f02M1Form.M1nohin_su,formInfo["M1nohin_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1kensu"),
					DataFormatUtil.GetFormatItem(tb090f02M1Form.M1kensu,formInfo["M1kensu"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1teisei_suryo"),
					DataFormatUtil.GetFormatItem(tb090f02M1Form.M1teisei_suryo,formInfo["M1teisei_suryo"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1gen_tnk"),
					DataFormatUtil.GetFormatItem(tb090f02M1Form.M1gen_tnk,formInfo["M1gen_tnk"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1genkakin"),
					DataFormatUtil.GetFormatItem(tb090f02M1Form.M1genkakin,formInfo["M1genkakin"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1teisei_suryo_hdn"),
					DataFormatUtil.GetFormatItem(tb090f02M1Form.M1teisei_suryo_hdn,formInfo["M1teisei_suryo_hdn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1genkakin_hdn"),
					DataFormatUtil.GetFormatItem(tb090f02M1Form.M1genkakin_hdn,formInfo["M1genkakin_hdn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1selectorcheckbox"),
					DataFormatUtil.GetFormatItem(tb090f02M1Form.M1selectorcheckbox,formInfo["M1selectorcheckbox"]));
				((System.Web.UI.WebControls.CheckBox)M1.Items[index].FindControl("M1selectorcheckbox")).Text =
					formResource.GetString("M1selectorcheckbox", lang);
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1entersyoriflg"),
					DataFormatUtil.GetFormatItem(tb090f02M1Form.M1entersyoriflg,formInfo["M1entersyoriflg"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1dtlirokbn"),
					DataFormatUtil.GetFormatItem(tb090f02M1Form.M1dtlirokbn,formInfo["M1dtlirokbn"]));

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
				// (M1.HeaderRow.FindControl("M1hinsyu_ryaku_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hinsyu_ryaku_nm", lang), base.GetPageContext().FormInfo["M1hinsyu_ryaku_nm"]);
				// (M1.HeaderRow.FindControl("M1burando_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1burando_nm", lang), base.GetPageContext().FormInfo["M1burando_nm"]);
				// (M1.HeaderRow.FindControl("M1jisya_hbn") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1jisya_hbn", lang), base.GetPageContext().FormInfo["M1jisya_hbn"]);
				// (M1.HeaderRow.FindControl("M1maker_hbn") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1maker_hbn", lang), base.GetPageContext().FormInfo["M1maker_hbn"]);
				// (M1.HeaderRow.FindControl("M1syonmk") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syonmk", lang), base.GetPageContext().FormInfo["M1syonmk"]);
				// (M1.HeaderRow.FindControl("M1iro_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1iro_nm", lang), base.GetPageContext().FormInfo["M1iro_nm"]);
				// (M1.HeaderRow.FindControl("M1size_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1size_nm", lang), base.GetPageContext().FormInfo["M1size_nm"]);
				// (M1.HeaderRow.FindControl("M1scan_cd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1scan_cd", lang), base.GetPageContext().FormInfo["M1scan_cd"]);
				// (M1.HeaderRow.FindControl("M1nohin_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1nohin_su", lang), base.GetPageContext().FormInfo["M1nohin_su"]);
				// (M1.HeaderRow.FindControl("M1kensu") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kensu", lang), base.GetPageContext().FormInfo["M1kensu"]);
				// (M1.HeaderRow.FindControl("M1teisei_suryo") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1teisei_suryo", lang), base.GetPageContext().FormInfo["M1teisei_suryo"]);
				// (M1.HeaderRow.FindControl("M1gen_tnk") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1gen_tnk", lang), base.GetPageContext().FormInfo["M1gen_tnk"]);
				// (M1.HeaderRow.FindControl("M1genkakin") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1genkakin", lang), base.GetPageContext().FormInfo["M1genkakin"]);
				// (M1.HeaderRow.FindControl("M1teisei_suryo_hdn") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1teisei_suryo_hdn", lang), base.GetPageContext().FormInfo["M1teisei_suryo_hdn"]);
				// (M1.HeaderRow.FindControl("M1genkakin_hdn") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1genkakin_hdn", lang), base.GetPageContext().FormInfo["M1genkakin_hdn"]);
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
		/// <param name="tb090f02Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderCard(
			Tb090f02Form tb090f02Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			
			ControlUtil.SetControlValue(Head_tenpo_cd,
				DataFormatUtil.GetFormatItem(tb090f02Form.Head_tenpo_cd,formInfo["Head_tenpo_cd"]));
			ControlUtil.SetControlValue(Head_tenpo_nm,
				DataFormatUtil.GetFormatItem(tb090f02Form.Head_tenpo_nm,formInfo["Head_tenpo_nm"]));
			ControlUtil.SetControlValue(Stkmodeno,
				DataFormatUtil.GetFormatItem(tb090f02Form.Stkmodeno,formInfo["Stkmodeno"]));
			ControlUtil.SetControlValue(Denpyo_bango,
				DataFormatUtil.GetFormatItem(tb090f02Form.Denpyo_bango,formInfo["Denpyo_bango"]));
			ControlUtil.SetControlValue(Siiresaki_cd,
				DataFormatUtil.GetFormatItem(tb090f02Form.Siiresaki_cd,formInfo["Siiresaki_cd"]));
			ControlUtil.SetControlValue(Siiresaki_ryaku_nm,
				DataFormatUtil.GetFormatItem(tb090f02Form.Siiresaki_ryaku_nm,formInfo["Siiresaki_ryaku_nm"]));
			ControlUtil.SetControlValue(Bumon_cd,
				DataFormatUtil.GetFormatItem(tb090f02Form.Bumon_cd,formInfo["Bumon_cd"]));
			ControlUtil.SetControlValue(Bumon_nm,
				DataFormatUtil.GetFormatItem(tb090f02Form.Bumon_nm,formInfo["Bumon_nm"]));
			ControlUtil.SetControlValue(Kakuteitan_cd,
				DataFormatUtil.GetFormatItem(tb090f02Form.Kakuteitan_cd,formInfo["Kakuteitan_cd"]));
			ControlUtil.SetControlValue(Kakuteitan_nm,
				DataFormatUtil.GetFormatItem(tb090f02Form.Kakuteitan_nm,formInfo["Kakuteitan_nm"]));
			ControlUtil.SetControlValue(Nyukayotei_ymd,
				DataFormatUtil.GetFormatItem(tb090f02Form.Nyukayotei_ymd,formInfo["Nyukayotei_ymd"]));
			ControlUtil.SetControlValue(Siire_kakutei_ymd,
				DataFormatUtil.GetFormatItem(tb090f02Form.Siire_kakutei_ymd,formInfo["Siire_kakutei_ymd"]));
			ControlUtil.SetControlValue(Kakutei_sb_nm,
				DataFormatUtil.GetFormatItem(tb090f02Form.Kakutei_sb_nm,formInfo["Kakutei_sb_nm"]));
			ControlUtil.SetControlValue(Biko_kb,
				DataFormatUtil.GetFormatItem(tb090f02Form.Biko_kb,formInfo["Biko_kb"]));
			ControlUtil.SetControlValue(Biko1,
				DataFormatUtil.GetFormatItem(tb090f02Form.Biko1,formInfo["Biko1"]));
			ControlUtil.SetControlValue(Biko2,
				DataFormatUtil.GetFormatItem(tb090f02Form.Biko2,formInfo["Biko2"]));
			ControlUtil.SetControlValue(Gokei_teisei_suryo,
				DataFormatUtil.GetFormatItem(tb090f02Form.Gokei_teisei_suryo,formInfo["Gokei_teisei_suryo"]));
			ControlUtil.SetControlValue(Gokei_genkakin,
				DataFormatUtil.GetFormatItem(tb090f02Form.Gokei_genkakin,formInfo["Gokei_genkakin"]));

			if(!base.CheckUseSelfCustomize()){
				Btnback.Value = base.FormResourceGetString(formResource, "Btnback", lang);
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
			// UIScreenController controller = new UIScreenController((Tb090f02Form)base.GetPageContext().GetFormVO());
			// controller.ChangeColumnsDisplayMode(M1 ,  new DetailHeaderFixedVO(M1Header , true) , null);

			/*
			 *登録した機能間連携処理を親画面に感知させる。
			 *機能有効させる場合は、コメントアウトを外してください。
			 */
			//DetailUtil.RunPgSyn(this,(StandardBaseForm)base.GetPageContext().GetFormVO());

			#region 画面表示制御

			Tb090f02Form formVo = (Tb090f02Form)base.GetPageContext().GetFormVO();

			// 一覧画面の選択情報
			String entersyoriflg = ((Tb090f01M1Form)formVo.Dictionary[Tb090p01Constant.DIC_M1SELCETVO]).M1entersyoriflg;

			// [選択モードNo]が「訂正」以外、もしくは確定フラグが１の場合
			if (!BoSystemConstant.MODE_TEISEI.Equals(formVo.Stkmodeno)
				|| ConditionKakuteisyori_flg.VALUE_ARI.Equals(entersyoriflg))
			{
				// 備考を使用不可とする。
				ControlCls.Disable(Biko_kb, true);
				// ①を使用不可とする。
				ControlCls.Disable(Biko1, true);
				// ②を使用不可とする。
				ControlCls.Disable(Biko2, true);

				// 確定ボタンを使用不可とする。
				ControlCls.Disable(Btnenter, true);

				for (int index = 0; index < M1.Items.Count; index++)
				{
					// スキャンコードを使用不可とする。
					ControlCls.Disable(((MDTextBox)M1.Items[index].FindControl("M1scan_cd")), true);
					// 訂正数量を使用不可とする。
					ControlCls.Disable(((MDTextBox)M1.Items[index].FindControl("M1teisei_suryo")), true);

				}
			// 備考区分が２の場合は備考②を活性化する
			}
			else if (ConditionBiko_kbn.VALUE_BIKO_KBN2.Equals(formVo.Biko_kb))
			{
				ControlCls.Disable(Biko2, false);
			}
			// それ以外は非活性化
			else
			{
				ControlCls.Disable(Biko2, true);
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
			ControlUtil.SetControlValue(Denpyo_bango_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Denpyo_bango", lang), base.GetPageContext().FormInfo["Denpyo_bango"]));
				DataFormatUtil.SetMustColorCaption(Denpyo_bango_lbl, base.GetPageContext().FormInfo["Denpyo_bango"]);
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
			ControlUtil.SetControlValue(Kakuteitan_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Kakuteitan_cd", lang), base.GetPageContext().FormInfo["Kakuteitan_cd"]));
				DataFormatUtil.SetMustColorCaption(Kakuteitan_cd_lbl, base.GetPageContext().FormInfo["Kakuteitan_cd"]);
			ControlUtil.SetControlValue(Kakuteitan_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Kakuteitan_nm", lang), base.GetPageContext().FormInfo["Kakuteitan_nm"]));
				DataFormatUtil.SetMustColorCaption(Kakuteitan_nm_lbl, base.GetPageContext().FormInfo["Kakuteitan_nm"]);
			ControlUtil.SetControlValue(Nyukayotei_ymd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Nyukayotei_ymd", lang), base.GetPageContext().FormInfo["Nyukayotei_ymd"]));
				DataFormatUtil.SetMustColorCaption(Nyukayotei_ymd_lbl, base.GetPageContext().FormInfo["Nyukayotei_ymd"]);
			ControlUtil.SetControlValue(Siire_kakutei_ymd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Siire_kakutei_ymd", lang), base.GetPageContext().FormInfo["Siire_kakutei_ymd"]));
				DataFormatUtil.SetMustColorCaption(Siire_kakutei_ymd_lbl, base.GetPageContext().FormInfo["Siire_kakutei_ymd"]);
			ControlUtil.SetControlValue(Kakutei_sb_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Kakutei_sb_nm", lang), base.GetPageContext().FormInfo["Kakutei_sb_nm"]));
				DataFormatUtil.SetMustColorCaption(Kakutei_sb_nm_lbl, base.GetPageContext().FormInfo["Kakutei_sb_nm"]);
			ControlUtil.SetControlValue(Biko_kb_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Biko_kb", lang), base.GetPageContext().FormInfo["Biko_kb"]));
				DataFormatUtil.SetMustColorCaption(Biko_kb_lbl, base.GetPageContext().FormInfo["Biko_kb"]);
			ControlUtil.SetControlValue(Biko1_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Biko1", lang), base.GetPageContext().FormInfo["Biko1"]));
				DataFormatUtil.SetMustColorCaption(Biko1_lbl, base.GetPageContext().FormInfo["Biko1"]);
			ControlUtil.SetControlValue(Biko2_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Biko2", lang), base.GetPageContext().FormInfo["Biko2"]));
				DataFormatUtil.SetMustColorCaption(Biko2_lbl, base.GetPageContext().FormInfo["Biko2"]);
			ControlUtil.SetControlValue(Gokei_teisei_suryo_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Gokei_teisei_suryo", lang), base.GetPageContext().FormInfo["Gokei_teisei_suryo"]));
				DataFormatUtil.SetMustColorCaption(Gokei_teisei_suryo_lbl, base.GetPageContext().FormInfo["Gokei_teisei_suryo"]);
			ControlUtil.SetControlValue(Gokei_genkakin_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Gokei_genkakin", lang), base.GetPageContext().FormInfo["Gokei_genkakin"]));
				DataFormatUtil.SetMustColorCaption(Gokei_genkakin_lbl, base.GetPageContext().FormInfo["Gokei_genkakin"]);
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
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hinsyu_ryaku_nm", lang), base.GetPageContext().FormInfo["M1hinsyu_ryaku_nm"]);
				// M1.Columns[2].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1burando_nm", lang), base.GetPageContext().FormInfo["M1burando_nm"]);
				// M1.Columns[3].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1jisya_hbn", lang), base.GetPageContext().FormInfo["M1jisya_hbn"]);
				// M1.Columns[4].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1maker_hbn", lang), base.GetPageContext().FormInfo["M1maker_hbn"]);
				// M1.Columns[5].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syonmk", lang), base.GetPageContext().FormInfo["M1syonmk"]);
				// M1.Columns[6].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1iro_nm", lang), base.GetPageContext().FormInfo["M1iro_nm"]);
				// M1.Columns[7].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1size_nm", lang), base.GetPageContext().FormInfo["M1size_nm"]);
				// M1.Columns[8].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1scan_cd", lang), base.GetPageContext().FormInfo["M1scan_cd"]);
				// M1.Columns[9].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1nohin_su", lang), base.GetPageContext().FormInfo["M1nohin_su"]);
				// M1.Columns[10].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kensu", lang), base.GetPageContext().FormInfo["M1kensu"]);
				// M1.Columns[11].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1teisei_suryo", lang), base.GetPageContext().FormInfo["M1teisei_suryo"]);
				// M1.Columns[12].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1gen_tnk", lang), base.GetPageContext().FormInfo["M1gen_tnk"]);
				// M1.Columns[13].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1genkakin", lang), base.GetPageContext().FormInfo["M1genkakin"]);
				// M1.Columns[14].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1teisei_suryo_hdn", lang), base.GetPageContext().FormInfo["M1teisei_suryo_hdn"]);
				// M1.Columns[15].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1genkakin_hdn", lang), base.GetPageContext().FormInfo["M1genkakin_hdn"]);
				// M1.Columns[16].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1selectorcheckbox", lang), base.GetPageContext().FormInfo["M1selectorcheckbox"]);
				// M1.Columns[17].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1entersyoriflg", lang), base.GetPageContext().FormInfo["M1entersyoriflg"]);
				// M1.Columns[18].HeaderText = 
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
				Windowtitle.InnerText = formResource.GetString("Tb090f02_Titlebar", lang);
				header.FormName = formResource.GetString("Tb090f02_FormCaption", lang);
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
