using com.xebio.bo.Tj050p01.Constant;
using com.xebio.bo.Tj050p01.Facade;
using com.xebio.bo.Tj050p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.Model.Context;
using Common.Advanced.Resource;
using Common.Advanced.Web.Context;
using Common.Advanced.Web.Util;
using Common.Business.C01000.C01008;
using Common.Business.C01000.C01013;
using Common.Business.C99999.Constant;
using Common.Business.C99999.ReportUtil;
using Common.Conditions;
using Common.IntegrationMD.Util;
using Common.Standard.Base;
using Common.Standard.Control;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Session;
using Common.Standard.Util;
using System;
using System.Collections.Specialized;
using System.IO;

namespace com.xebio.bo.Tj050p01.Page
{
  /// <summary>
  /// Tj050f01のコードビハインドです。
  /// </summary>
  public partial class Tj050f01Page : StandardBasePage
	{

		#region メソッド

		#region ページデータをロードするメソッド
		/// <summary>
		/// Tj050f01画面データを作成する。
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
						pageContext.SetFormVO(new Tj050f01Form());
						switch(commandInfo.ActionMode)
						{
							case "ADD":
								break;
							case "DEL":
							case "UPD":
								IFacadeContext facadeContext =
									FacadeContextFactory.GetFacadeContext(pageContext);
								InitFacadeContext(facadeContext);
								new Tj050f01Facade().DoLoad(facadeContext);

								#region ヘッダ処理

								// 一覧画面共通処理 ----------
								LoginInfoVO loginInfVO = LoginInfoUtil.GetLoginInfo();
								Tj050f01Form Tj050f01Form = (Tj050f01Form)facadeContext.FormVO;
								ControlHeaderStoreCls.InitialSetHeaderStore<Tj050f01Form>(loginInfVO, Tj050f01Form);
								// 一覧画面共通処理 ----------

								if (string.IsNullOrEmpty(Tj050f01Form.Modeno))
								{
									// モードNoを今回に設定
									Tj050f01Form.Modeno = BoSystemConstant.MODE_KONKAI.ToString();
									TabUtil.SetTabNumber(pageContext, BoSystemConstant.MODE_KONKAI.ToString());
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
					Tj050f01Form f01VO = (Tj050f01Form)fvm.GetProgramVO(base.GetPageContext().CommandInfo.ProgramId).GetFormVO(Tj050p01Constant.FORMID_01);
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
				new Tj050f01Facade().DoBTNPRINT_FRM(facadeContext);
				
				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
					base.SetError(pageContext);
					return;
				}
				ControlDisplayUtil.InitControlList(this, facadeContext);

				// PDFファイル名を取得			
				pdfNm = (string)facadeContext.GetUserObject(Tj050p01Constant.FCDUO_RRT_FLNM);
							
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

			#region 帳票出力処理
			DLConditionVO dlvo = new DLConditionVO();
			// サーバファイルフルパス
			string serverPath = string.Format("{0}{1}{2}",
											FilePathManager.GetOutFilePath(Tj050p01Constant.PGID),
											Path.DirectorySeparatorChar,
											pdfNm
											);

			// クライアントファイル名
			string reportNm = string.Empty; 
			
			//FormVOを取得する
			Tj050f01Form tj050f01Form = (Tj050f01Form)pageContext.GetFormVO();

			if (tj050f01Form.Tanaorosi_hokokusyo_kb == ConditionTanaorosi_hokokusyo_v.VALUE_TANAOROSI_HOKOKUSYO_X1)
			{
				reportNm = BoSystemConstant.REPORTNM_TANAOROSISYUKEIHYO_V;
			}
			else if (tj050f01Form.Tanaorosi_hokokusyo_kb == ConditionTanaorosi_hokokusyo_v.VALUE_TANAOROSI_HOKOKUSYO_X2)
			{
				reportNm = BoSystemConstant.REPORTNM_TANAOROSIKETUBANHOKOKUSYO_V;
			}
			else if (tj050f01Form.Tanaorosi_hokokusyo_kb == ConditionTanaorosi_hokokusyo_v.VALUE_TANAOROSI_HOKOKUSYO_X4)
			{
				reportNm = BoSystemConstant.REPORTNM_TANAOROSISYUSEIHOKOKUSYO_V;
			}

			string clientNm = string.Format("{0}.{1}",
											BoSystemReport.CreateFileName(reportNm,2),
											BoSystemConstant.RPT_PDF_EXTENSION
											);
			// ダウンロード用VOに値を設定
			dlvo.setSingleFileDownloadCondition(serverPath, clientNm);

			// ダウンロード用VOをセッションに格納
			SessionInfoUtil.SetPgObject(BoSystemConstant.SESSION_KEY_DOWNLOAD_VO, dlvo, pageContext);

			#endregion


			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNPRINT_FRM");

			//画面遷移
			base.Forward(pageContext, queryList);
			//base.DownloadPageStartUp(pageContext, dlvo);
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
						Tj050f01Form tj050f01Form = (Tj050f01Form)pageContext.GetFormVO();

						//カード部データを表示する
						RenderCard(tj050f01Form, pageContext.FormInfo, formResource, lang);
					}
					
					//共通フォームデータ表示処理
					base.DoCommonRenderForm();
				}
			}
		}
		#endregion


		#region カードデータを表示する
		/// <summary>
		/// カードデータを表示する
		/// </summary>
		/// <param name="tj050f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderCard(
			Tj050f01Form tj050f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			
			ControlUtil.SetControlValue(Head_tenpo_cd,
				DataFormatUtil.GetFormatItem(tj050f01Form.Head_tenpo_cd,formInfo["Head_tenpo_cd"]));
			ControlUtil.SetControlValue(Head_tenpo_nm,
				DataFormatUtil.GetFormatItem(tj050f01Form.Head_tenpo_nm,formInfo["Head_tenpo_nm"]));
			ControlUtil.SetControlValue(Modeno,
				DataFormatUtil.GetFormatItem(tj050f01Form.Modeno,formInfo["Modeno"]));
			ControlUtil.SetControlValue(Stkmodeno,
				DataFormatUtil.GetFormatItem(tj050f01Form.Stkmodeno,formInfo["Stkmodeno"]));
			ControlUtil.SetControlValue(Tanaorosikijun_ymd,
				DataFormatUtil.GetFormatItem(tj050f01Form.Tanaorosikijun_ymd,formInfo["Tanaorosikijun_ymd"]));
			ControlUtil.SetControlValue(Tanaorosijissi_ymd,
				DataFormatUtil.GetFormatItem(tj050f01Form.Tanaorosijissi_ymd,formInfo["Tanaorosijissi_ymd"]));
			ControlUtil.SetControlValue(Tanaorosikikan_from,
				DataFormatUtil.GetFormatItem(tj050f01Form.Tanaorosikikan_from,formInfo["Tanaorosikikan_from"]));
			ControlUtil.SetControlValue(Tanaorosikikan_to,
				DataFormatUtil.GetFormatItem(tj050f01Form.Tanaorosikikan_to,formInfo["Tanaorosikikan_to"]));
			ControlUtil.SetControlValue(Tanaorosikijun_ymd1,
				DataFormatUtil.GetFormatItem(tj050f01Form.Tanaorosikijun_ymd1,formInfo["Tanaorosikijun_ymd1"]));
			ControlUtil.SetControlValue(Tanaorosijissi_ymd1,
				DataFormatUtil.GetFormatItem(tj050f01Form.Tanaorosijissi_ymd1,formInfo["Tanaorosijissi_ymd1"]));
			ControlUtil.SetControlValue(Tanaorosikikan_from1,
				DataFormatUtil.GetFormatItem(tj050f01Form.Tanaorosikikan_from1,formInfo["Tanaorosikikan_from1"]));
			ControlUtil.SetControlValue(Tanaorosikikan_to1,
				DataFormatUtil.GetFormatItem(tj050f01Form.Tanaorosikikan_to1,formInfo["Tanaorosikikan_to1"]));
			ControlUtil.SetControlValue(Tanaorosi_hokokusyo_kb,
				DataFormatUtil.GetFormatItem(tj050f01Form.Tanaorosi_hokokusyo_kb,formInfo["Tanaorosi_hokokusyo_kb"]));

			if(!base.CheckUseSelfCustomize()){
				Btnheadtenpocd.Value = base.FormResourceGetString(formResource, "Btnheadtenpocd", lang);
				Btnmodekonkai.InnerText = base.FormResourceGetString(formResource, "Btnmodekonkai", lang);
				Btnmodezenkai.InnerText = base.FormResourceGetString(formResource, "Btnmodezenkai", lang);
				Btnprint.Value = base.FormResourceGetString(formResource, "Btnprint", lang);
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
			#region 共通ヘッダ表示制御
			LoginInfoVO loginInfVO = LoginInfoUtil.GetLoginInfo();
			ControlHeaderStoreCls.ControlSetHeaderStore(loginInfVO, Head_tenpo_cd, Btnheadtenpocd);
			#endregion



			// フォーカス設定(ラジオボタン)
			// 権限取得部品の戻り値が"FALSE"の場合
			LoginInfoVO loginInfVo = LoginInfoUtil.GetLoginInfo();
			if (!CheckKengenCls.CheckKengen(loginInfVo))
			{
				this.Tanaorosi_hokokusyo_kb.Items[0].Selected = true;
			}


			/*
			 *明細スクロール位置情報生成処理を行います。
			 *機能有効させる場合は、コメントアウトを外してください。
			 */
			//ScrollRelationship.DrawRelations(this, base.GetPageContext());
			
			//
			// 明細部のヘッダ固定、明細列の表示・非表示を制御する部品です。
			// 機能有効する場合は、コメントアウトを外して、必要な情報を追加してください。
			// UIScreenController controller = new UIScreenController((Tj050f01Form)base.GetPageContext().GetFormVO());

			/*
			 *登録した機能間連携処理を親画面に感知させる。
			 *機能有効させる場合は、コメントアウトを外してください。
			 */
			//DetailUtil.RunPgSyn(this,(StandardBaseForm)base.GetPageContext().GetFormVO());


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
			ControlUtil.SetControlValue(Tanaorosijissi_ymd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Tanaorosijissi_ymd", lang), base.GetPageContext().FormInfo["Tanaorosijissi_ymd"]));
				DataFormatUtil.SetMustColorCaption(Tanaorosijissi_ymd_lbl, base.GetPageContext().FormInfo["Tanaorosijissi_ymd"]);
			ControlUtil.SetControlValue(Tanaorosikikan_from_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Tanaorosikikan_from", lang), base.GetPageContext().FormInfo["Tanaorosikikan_from"]));
				DataFormatUtil.SetMustColorCaption(Tanaorosikikan_from_lbl, base.GetPageContext().FormInfo["Tanaorosikikan_from"]);
			ControlUtil.SetControlValue(Tanaorosikikan_to_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Tanaorosikikan_to", lang), base.GetPageContext().FormInfo["Tanaorosikikan_to"]));
				DataFormatUtil.SetMustColorCaption(Tanaorosikikan_to_lbl, base.GetPageContext().FormInfo["Tanaorosikikan_to"]);
			ControlUtil.SetControlValue(Tanaorosijissi_ymd1_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Tanaorosijissi_ymd1", lang), base.GetPageContext().FormInfo["Tanaorosijissi_ymd1"]));
				DataFormatUtil.SetMustColorCaption(Tanaorosijissi_ymd1_lbl, base.GetPageContext().FormInfo["Tanaorosijissi_ymd1"]);
			ControlUtil.SetControlValue(Tanaorosikikan_from1_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Tanaorosikikan_from1", lang), base.GetPageContext().FormInfo["Tanaorosikikan_from1"]));
				DataFormatUtil.SetMustColorCaption(Tanaorosikikan_from1_lbl, base.GetPageContext().FormInfo["Tanaorosikikan_from1"]);
			ControlUtil.SetControlValue(Tanaorosikikan_to1_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Tanaorosikikan_to1", lang), base.GetPageContext().FormInfo["Tanaorosikikan_to1"]));
				DataFormatUtil.SetMustColorCaption(Tanaorosikikan_to1_lbl, base.GetPageContext().FormInfo["Tanaorosikikan_to1"]);
			ControlUtil.SetControlValue(Tanaorosi_hokokusyo_kb_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Tanaorosi_hokokusyo_kb", lang), base.GetPageContext().FormInfo["Tanaorosi_hokokusyo_kb"]));
				DataFormatUtil.SetMustColorCaption(Tanaorosi_hokokusyo_kb_lbl, base.GetPageContext().FormInfo["Tanaorosi_hokokusyo_kb"]);
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
				Windowtitle.InnerText = formResource.GetString("Tj050f01_Titlebar", lang);
				header.FormName = formResource.GetString("Tj050f01_FormCaption", lang);
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
