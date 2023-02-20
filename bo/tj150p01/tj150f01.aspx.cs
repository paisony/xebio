using com.xebio.bo.Tj150p01.Constant;
using com.xebio.bo.Tj150p01.Facade;
using com.xebio.bo.Tj150p01.Formvo;
using Common.Advanced.Info;
using Common.Advanced.Model.Context;
using Common.Advanced.Resource;
using Common.Advanced.Web.Context;
using Common.Advanced.Web.Util;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01008;
using Common.Business.C01000.C01013;
using Common.Business.C01000.C01014;
using Common.IntegrationMD.Util;
using Common.Standard.Base;
using Common.Standard.Constant;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Session;
using Common.Standard.Util;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace com.xebio.bo.Tj150p01.Page
{
  /// <summary>
  /// Tj150f01のコードビハインドです。
  /// </summary>
  public partial class Tj150f01Page : StandardBasePage
	{

		#region メソッド

		#region ページデータをロードするメソッド
		/// <summary>
		/// Tj150f01画面データを作成する。
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
						pageContext.SetFormVO(new Tj150f01Form());
						switch(commandInfo.ActionMode)
						{
							case "ADD":
								break;
							case "INI": //メニューから遷移時
							case "DEL":
							case "UPD":
								IFacadeContext facadeContext =
									FacadeContextFactory.GetFacadeContext(pageContext);
								InitFacadeContext(facadeContext);
								new Tj150f01Facade().DoLoad(facadeContext);
								#region 共通ヘッダ処理

								// 一覧画面共通処理 ----------
								LoginInfoVO loginInfVO = LoginInfoUtil.GetLoginInfo();
								Tj150f01Form Tj150f01Form = (Tj150f01Form)facadeContext.FormVO;
								ControlHeaderStoreCls.InitialSetHeaderStore<Tj150f01Form>(loginInfVO, Tj150f01Form);
								// 一覧画面共通処理 ----------

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
				
				// 複数ファイルダウンロード処理
				if (SessionInfoUtil.GetPgObject(base.GetPageContext().CommandInfo.ProgramId, SessionKeyConstant.DOWNLOAD_FILE_LIST, Session) != null)
				{
					base.MultipleDownloadPageStartUp(base.GetPageContext());
				}
				
				/*
				*明細スクロール位置情報登録処理を行います。
				*機能有効させる場合は、コメントアウトを外してください。
				*/
				////保持したい明細スクロールのパネルIDを作成する
				//string[] detailPanelId = { , , };
				////保持したい明細スクロールのパネルIDを部品に登録する
				//ScrollRelationship.RegisterRelations(base.GetPageContext(), detailPanelId);
				// インフォメッセージ ----------------------------------------------------------------------		
				if (pageContext != null)
				{
					string msg = InfoMsgCls.GetWarningMsg(pageContext, Tj150p01Constant.PGID);
					if (!string.IsNullOrEmpty(msg))
					{
						// インフォメッセージが表示されている場合、表示する。
						Page.ClientScript.RegisterStartupScript(typeof(string), "infoDialog", msg);
					}
				}
				// インフォメッセージ ----------------------------------------------------------------------		


				
			}
			catch (System.Exception ex)
			{
				ThrowException(ex, pageContext);
			}
			
			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".Page_Load");
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
				new Tj150f01Facade().DoBTNENTER_FRM(facadeContext);

				
				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
					base.SetError(pageContext);
					return;
				}

				// インフォメッセージ ----------------------------------------------------------------------	
				// 情報判定	
				if (InfoMsgCls.HasInfo(facadeContext))
				{
					// インフォメッセージの表示
					InfoMsgCls.showLoadMsg(pageContext, 1, Tj150p01Constant.PGID);
				}
				// インフォメッセージ ----------------------------------------------------------------------	

				//遷移先の画面設定（入出力画面定義で設定した遷移先は初期化処理で設定済み）
				//入出力画面定義で設定した遷移先以外の画面に遷移する場合は以下のソースを
				//コメントインし、設定して下さい。
				//commandInfo.ToProgramId = "遷移先プログラムID";
				//commandInfo.ToFormId = "遷移先フォームID";
				
				//他の処理モードを設定する必要がある場合、次の行を修正してください
				commandInfo.ActionMode = "UPD";
				commandInfo.PageLoadMode = false;

				//複数ダウンロード情報
				List<string> dlList = new List<string>();

				// PDFファイル名リスト取得
				dlList = facadeContext.GetUserObject(Tj150p01Constant.FCDUO_RRT_FLNM) as List<string>;

				// 複数ダウンロード用にファイル名をセッションにセット
				SessionInfoUtil.SetPgObject(pageContext.CommandInfo.ProgramId, SessionKeyConstant.DOWNLOAD_FILE_LIST, dlList, Session);

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
			EndMethod(sender, e, this.GetType().Name + ".OnBTNENTER_DBU");

			#region フォーカス制御
			LoginInfoVO loginInfVo = LoginInfoUtil.GetLoginInfo();

			// フォーカス設定用変数
			string focusItem = string.Empty;
			string focusMno = string.Empty;

			// 権限取得部品の戻り値が"TRUE"の場合
			if (CheckKengenCls.CheckKengen(loginInfVo))
			{
				// [ヘッダ店舗コード]にフォーカスを当てる。
				focusItem = "Head_tenpo_cd";
			}
			// 権限取得部品の戻り値が"FALSE"の場合
			// フォーカス設定
			//SetFocusCls.SetFocus(queryList, focusItem, focusMno);
			queryList = SetFocusCls.SetFocus(queryList, focusItem, focusMno);
			#endregion

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
						Tj150f01Form tj150f01Form = (Tj150f01Form)pageContext.GetFormVO();

						//カード部データを表示する
						RenderCard(tj150f01Form, pageContext.FormInfo, formResource, lang);
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
		/// <param name="tj150f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderCard(
			Tj150f01Form tj150f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			
			ControlUtil.SetControlValue(Head_tenpo_cd,
				DataFormatUtil.GetFormatItem(tj150f01Form.Head_tenpo_cd,formInfo["Head_tenpo_cd"]));
			ControlUtil.SetControlValue(Head_tenpo_nm,
				DataFormatUtil.GetFormatItem(tj150f01Form.Head_tenpo_nm,formInfo["Head_tenpo_nm"]));
			ControlUtil.SetControlValue(Tanaorosisyuryo_kb,
				DataFormatUtil.GetFormatItem(tj150f01Form.Tanaorosisyuryo_kb,formInfo["Tanaorosisyuryo_kb"]));

			if(!base.CheckUseSelfCustomize()){
				Btnheadtenpocd.Value = base.FormResourceGetString(formResource, "Btnheadtenpocd", lang);
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
			// フォーカス設定(ラジオボタン)、disabled設定
			// 権限取得部品の戻り値が"FALSE"の場合
			LoginInfoVO loginInfVo = LoginInfoUtil.GetLoginInfo();
			if (!CheckKengenCls.CheckKengen(loginInfVo))
			{
				this.Tanaorosisyuryo_kb.Items[0].Selected = true;
				this.Tanaorosisyuryo_kb.Items[1].Attributes.Add("disabled", "true");
			}

			#region 共通ヘッダ表示制御
			LoginInfoVO loginInfVO = LoginInfoUtil.GetLoginInfo();
			ControlHeaderStoreCls.ControlSetHeaderStore(loginInfVO, Head_tenpo_cd, Btnheadtenpocd);
			#endregion
			
			/*
			 *明細スクロール位置情報生成処理を行います。
			 *機能有効させる場合は、コメントアウトを外してください。
			 */
			//ScrollRelationship.DrawRelations(this, base.GetPageContext());
			
			//
			// 明細部のヘッダ固定、明細列の表示・非表示を制御する部品です。
			// 機能有効する場合は、コメントアウトを外して、必要な情報を追加してください。
			// UIScreenController controller = new UIScreenController((Tj150f01Form)base.GetPageContext().GetFormVO());

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
			ControlUtil.SetControlValue(Tanaorosisyuryo_kb_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Tanaorosisyuryo_kb", lang), base.GetPageContext().FormInfo["Tanaorosisyuryo_kb"]));
				DataFormatUtil.SetMustColorCaption(Tanaorosisyuryo_kb_lbl, base.GetPageContext().FormInfo["Tanaorosisyuryo_kb"]);
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
				Windowtitle.InnerText = formResource.GetString("Tj150f01_Titlebar", lang);
				header.FormName = formResource.GetString("Tj150f01_FormCaption", lang);
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
