using com.xebio.bo.Tj180p01.Facade;
using com.xebio.bo.Tj180p01.Formvo;
using Common.Advanced.Info;
using Common.Advanced.Model.Context;
using Common.Advanced.Resource;
using Common.Advanced.Web.Context;
using Common.Advanced.Web.Util;
using Common.Business.C01000.C01008;
using Common.Business.C01000.C01013;
using Common.Business.C01000.C01014;
using Common.Business.C99999.Constant;
using Common.IntegrationMD.Util;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Util;
using System;
using System.Collections.Specialized;

namespace com.xebio.bo.Tj180p01.Page
{
  /// <summary>
  /// Tj180f01のコードビハインドです。
  /// </summary>
  public partial class Tj180f01Page : StandardBasePage
	{

		#region メソッド

		#region ページデータをロードするメソッド
		/// <summary>
		/// Tj180f01画面データを作成する。
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
						pageContext.SetFormVO(new Tj180f01Form());
						switch(commandInfo.ActionMode)
						{
							case "ADD":
								break;
							case "DEL":
							case "UPD":
								IFacadeContext facadeContext =
									FacadeContextFactory.GetFacadeContext(pageContext);
								InitFacadeContext(facadeContext);
								new Tj180f01Facade().DoLoad(facadeContext);

								#region 共通ヘッダ処理

								// 一覧画面共通処理 ----------
								LoginInfoVO loginInfVO = LoginInfoUtil.GetLoginInfo();
								Tj180f01Form tj180f01Form = (Tj180f01Form)facadeContext.FormVO;
								ControlHeaderStoreCls.InitialSetHeaderStore<Tj180f01Form>(loginInfVO, tj180f01Form);

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
				new Tj180f01Facade().DoBTNSEARCH_FRM(facadeContext);
				
				
				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
					// アコーディオンなし
					AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_NONE);

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

			#region フォーカス制御
			//URLクエリ追加用NameValueCollection
			NameValueCollection queryList = new NameValueCollection();

			// フォーカス設定用変数
			string focusItem = string.Empty;
			string focusMno = string.Empty;

			// ログイン情報取得
			LoginInfoVO loginInfVo = LoginInfoUtil.GetLoginInfo();

			// 権限取得部品の戻り値が"TRUE"の場合
			if (CheckKengenCls.CheckKengen(loginInfVo))
			{
				// [ヘッダ店舗コード]にフォーカスを当てる。
				focusItem = "Head_tenpo_cd";
			}
			// 権限取得部品の戻り値が"FALSE"の場合
			else
			{
				// [検索ボタン]にフォーカスを当てる。
				focusItem = "Btnsearch";
			}

			// フォーカス設定
			SetFocusCls.SetFocus(queryList, focusItem, focusMno);
			//queryList = SetFocusCls.SetFocus(queryList, focusItem, focusMno);
			#endregion

			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNSEARCH_FRM");
			
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
					//エラー時でも"-"で表示するため
					//if (!MessageDisplayUtil.HasError(pageContext))
					//{
					string lang = WebSettingsUtil.GetLangSettingFromSession(pageContext.Session);
					FormResource formResource =
						ResourceFactory.GetFormResource(pageContext.CommandInfo.FormId);
			
					//標題をセットする
					SetCaption(formResource, lang);

					//FormVOを取得する
					Tj180f01Form tj180f01Form = (Tj180f01Form)pageContext.GetFormVO();

					//カード部データを表示する
					RenderCard(tj180f01Form, pageContext.FormInfo, formResource, lang);
					//}
					
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
		/// <param name="tj180f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderCard(
			Tj180f01Form tj180f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			
			ControlUtil.SetControlValue(Head_tenpo_cd,
				DataFormatUtil.GetFormatItem(tj180f01Form.Head_tenpo_cd,formInfo["Head_tenpo_cd"]));
			ControlUtil.SetControlValue(Head_tenpo_nm,
				DataFormatUtil.GetFormatItem(tj180f01Form.Head_tenpo_nm,formInfo["Head_tenpo_nm"]));
			ControlUtil.SetControlValue(Kijunbi_zen_tyobozaiko_su,
				DataFormatUtil.GetFormatItem(tj180f01Form.Kijunbi_zen_tyobozaiko_su,formInfo["Kijunbi_zen_tyobozaiko_su"]));
			ControlUtil.SetControlValue(Tojitsuuri_su,
				DataFormatUtil.GetFormatItem(tj180f01Form.Tojitsuuri_su,formInfo["Tojitsuuri_su"]));
			ControlUtil.SetControlValue(Tojitsunyusyukka_su,
				DataFormatUtil.GetFormatItem(tj180f01Form.Tojitsunyusyukka_su,formInfo["Tojitsunyusyukka_su"]));
			ControlUtil.SetControlValue(Tojitsuyosokuzai_su,
				DataFormatUtil.GetFormatItem(tj180f01Form.Tojitsuyosokuzai_su,formInfo["Tojitsuyosokuzai_su"]));
			ControlUtil.SetControlValue(Tenpotanaorosi_su,
				DataFormatUtil.GetFormatItem(tj180f01Form.Tenpotanaorosi_su,formInfo["Tenpotanaorosi_su"]));
			ControlUtil.SetControlValue(Gyosyatanaorosi_su,
				DataFormatUtil.GetFormatItem(tj180f01Form.Gyosyatanaorosi_su,formInfo["Gyosyatanaorosi_su"]));
			ControlUtil.SetControlValue(Sai_su,
				DataFormatUtil.GetFormatItem(tj180f01Form.Sai_su,formInfo["Sai_su"]));

			if(!base.CheckUseSelfCustomize()){
				Btnheadtenpocd.Value = base.FormResourceGetString(formResource, "Btnheadtenpocd", lang);
				Btnsearch.Value = base.FormResourceGetString(formResource, "Btnsearch", lang);
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
			// UIScreenController controller = new UIScreenController((Tj180f01Form)base.GetPageContext().GetFormVO());

			/*
			 *登録した機能間連携処理を親画面に感知させる。
			 *機能有効させる場合は、コメントアウトを外してください。
			 */
			//DetailUtil.RunPgSyn(this,(StandardBaseForm)base.GetPageContext().GetFormVO());

			#region 共通ヘッダ表示制御
			LoginInfoVO loginInfVO = LoginInfoUtil.GetLoginInfo();
			ControlHeaderStoreCls.ControlSetHeaderStore(loginInfVO, Head_tenpo_cd, Btnheadtenpocd);
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
			ControlUtil.SetControlValue(Kijunbi_zen_tyobozaiko_su_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Kijunbi_zen_tyobozaiko_su", lang), base.GetPageContext().FormInfo["Kijunbi_zen_tyobozaiko_su"]));
				DataFormatUtil.SetMustColorCaption(Kijunbi_zen_tyobozaiko_su_lbl, base.GetPageContext().FormInfo["Kijunbi_zen_tyobozaiko_su"]);
			ControlUtil.SetControlValue(Tojitsuuri_su_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Tojitsuuri_su", lang), base.GetPageContext().FormInfo["Tojitsuuri_su"]));
				DataFormatUtil.SetMustColorCaption(Tojitsuuri_su_lbl, base.GetPageContext().FormInfo["Tojitsuuri_su"]);
			ControlUtil.SetControlValue(Tojitsunyusyukka_su_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Tojitsunyusyukka_su", lang), base.GetPageContext().FormInfo["Tojitsunyusyukka_su"]));
				DataFormatUtil.SetMustColorCaption(Tojitsunyusyukka_su_lbl, base.GetPageContext().FormInfo["Tojitsunyusyukka_su"]);
			ControlUtil.SetControlValue(Tojitsuyosokuzai_su_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Tojitsuyosokuzai_su", lang), base.GetPageContext().FormInfo["Tojitsuyosokuzai_su"]));
				DataFormatUtil.SetMustColorCaption(Tojitsuyosokuzai_su_lbl, base.GetPageContext().FormInfo["Tojitsuyosokuzai_su"]);
			ControlUtil.SetControlValue(Tenpotanaorosi_su_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Tenpotanaorosi_su", lang), base.GetPageContext().FormInfo["Tenpotanaorosi_su"]));
				DataFormatUtil.SetMustColorCaption(Tenpotanaorosi_su_lbl, base.GetPageContext().FormInfo["Tenpotanaorosi_su"]);
			ControlUtil.SetControlValue(Gyosyatanaorosi_su_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Gyosyatanaorosi_su", lang), base.GetPageContext().FormInfo["Gyosyatanaorosi_su"]));
				DataFormatUtil.SetMustColorCaption(Gyosyatanaorosi_su_lbl, base.GetPageContext().FormInfo["Gyosyatanaorosi_su"]);
			ControlUtil.SetControlValue(Sai_su_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Sai_su", lang), base.GetPageContext().FormInfo["Sai_su"]));
				DataFormatUtil.SetMustColorCaption(Sai_su_lbl, base.GetPageContext().FormInfo["Sai_su"]);
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
				Windowtitle.InnerText = formResource.GetString("Tj180f01_Titlebar", lang);
				header.FormName = formResource.GetString("Tj180f01_FormCaption", lang);
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
