using com.xebio.bo.Tg020p01.Constant;
using com.xebio.bo.Tg020p01.Facade;
using com.xebio.bo.Tg020p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.Model.Context;
using Common.Advanced.Resource;
using Common.Advanced.Web.Context;
using Common.Advanced.Web.Util;
using Common.Business.C01000.C01013;
using Common.Business.C01000.C01014;
using Common.Business.C01000.C01015;
using Common.Business.C99999.Constant;
using Common.Business.C99999.LabelUtil;
using Common.Business.C99999.StringUtil;
using Common.Conditions;
using Common.IntegrationMD.Util;
using Common.Standard.Base;
using Common.Standard.Form;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Util;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Tg020p01.Page
{
  /// <summary>
  /// Tg020f01のコードビハインドです。
  /// </summary>
  public partial class Tg020f01Page : StandardBasePage
	{

		#region メソッド

		#region ページデータをロードするメソッド
		/// <summary>
		/// Tg020f01画面データを作成する。
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
						pageContext.SetFormVO(new Tg020f01Form());
						switch(commandInfo.ActionMode)
						{
							case "ADD":
								break;
							case "DEL":
							case "UPD":
								IFacadeContext facadeContext =
									FacadeContextFactory.GetFacadeContext(pageContext);
								InitFacadeContext(facadeContext);

								// クッキー値を取得
								BoSystemLabelUtil.GetCookieLabel(pageContext.Request, facadeContext);

								new Tg020f01Facade().DoLoad(facadeContext);

								//#region 共通ヘッダ処理

								//// 一覧画面共通処理 ----------
								LoginInfoVO loginInfVO = LoginInfoUtil.GetLoginInfo();
								Tg020f01Form Tg020f01Form = (Tg020f01Form)facadeContext.FormVO;
								ControlHeaderStoreCls.InitialSetHeaderStore<Tg020f01Form>(loginInfVO, Tg020f01Form);
								//// 一覧画面共通処理 ----------

								if (string.IsNullOrEmpty(Tg020f01Form.Modeno))
								{
									// アコーディオンなし
									//AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_NONE);
									// モードNo
									Tg020f01Form.Modeno = BoSystemConstant.MODE_PERCENTOFF.ToString();
									TabUtil.SetTabNumber(pageContext, BoSystemConstant.MODE_PERCENTOFF.ToString());
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

				//// モードNoをセッションに格納
				if (base.GetPageContext() != null)
				{
					FormVOManager fvm = new FormVOManager(Session);
					Tg020f01Form f01VO = (Tg020f01Form)fvm.GetProgramVO(base.GetPageContext().CommandInfo.ProgramId).GetFormVO(Tg020p01Constant.FORMID);
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

				if (pageContext != null)
				{
					string msg = BoSystemLabelUtil.GetScriptLabelPrint(pageContext, Tg020p01Constant.PGID);
					if (!string.IsNullOrEmpty(msg))
					{
						// インフォメッセージが表示されている場合、表示する。
						Page.ClientScript.RegisterStartupScript(typeof(string), "SealPrint", msg);
						return;
					}
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

		#region フォームを呼び出します(ボタンID : Btnseal())
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnseal())
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnBTNSEAL_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnBTNSEAL_FRM");
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
				new Tg020f01Facade().DoBTNSEAL_FRM(facadeContext);

				// ラベル発行機の値をクッキーに登録
				Tg020f01Form f01VO = (Tg020f01Form)facadeContext.FormVO;
				BoSystemLabelUtil.SetCookieLabel(pageContext.Response, f01VO);
				
				
				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
					base.SetError(pageContext);
					return;
				}

				// CSVファイル名を取得
				string csvNm = (string)facadeContext.GetUserObject(Tg020p01Constant.FCDUO_SEAL_CSVFLNM);

				// シールレイアウト
				List<string> layout = (List<string>)facadeContext.GetUserObject(Tg020p01Constant.FCDUO_SEAL_LAYOUTNM);

				// シール発行スクリプトの出力
				BoSystemLabelUtil.createScriptLabelPrint(pageContext, Tg020p01Constant.PGID, layout, csvNm);

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
			#region フォーカス制御

			// フォーカス設定用変数
			string focusItem = string.Empty;
			string focusMno = string.Empty;



			//フォーカス項目の指定
			NameValueCollection FocusList = FormFocusUtil.TakeOverFocus(null, Context);

			// [ヘッダ店舗コード]にフォーカスを当てる。
			focusItem = "Head_tenpo_cd";

			// フォーカス設定
			SetFocusCls.SetFocus(FocusList, focusItem, focusMno);

			#endregion
			
			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNSEAL_FRM");
			
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
						Tg020f01Form tg020f01Form = (Tg020f01Form)pageContext.GetFormVO();
						

						//カード部データを表示する
						RenderCard(tg020f01Form, pageContext.FormInfo, formResource, lang);

						//////エラー判定
						//if (MessageDisplayUtil.HasError(FacadeContextFactory.GetFacadeContext(base.GetPageContext())))
						//{
						//	base.SetError(base.GetPageContext());
						//}

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
		/// <param name="tg020f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderCard(
			Tg020f01Form tg020f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			
			ControlUtil.SetControlValue(Head_tenpo_cd,
				DataFormatUtil.GetFormatItem(tg020f01Form.Head_tenpo_cd,formInfo["Head_tenpo_cd"]));
			ControlUtil.SetControlValue(Head_tenpo_nm,
				DataFormatUtil.GetFormatItem(tg020f01Form.Head_tenpo_nm,formInfo["Head_tenpo_nm"]));
			ControlUtil.SetControlValue(Waririt,
				DataFormatUtil.GetFormatItem(tg020f01Form.Waririt,formInfo["Waririt"]));
			ControlUtil.SetControlValue(Maisu,
				DataFormatUtil.GetFormatItem(tg020f01Form.Maisu,formInfo["Maisu"]));
			ControlUtil.SetControlValue(Inji_comment,
				DataFormatUtil.GetFormatItem(tg020f01Form.Inji_comment,formInfo["Inji_comment"]));
			ControlUtil.SetControlValue(Inji_comment_nm,
				DataFormatUtil.GetFormatItem(tg020f01Form.Inji_comment_nm,formInfo["Inji_comment_nm"]));
			ControlUtil.SetControlValue(Warigak,
				DataFormatUtil.GetFormatItem(tg020f01Form.Warigak,formInfo["Warigak"]));
			ControlUtil.SetControlValue(Maisu2,
				DataFormatUtil.GetFormatItem(tg020f01Form.Maisu2,formInfo["Maisu2"]));
			ControlUtil.SetControlValue(Inji_comment2,
				DataFormatUtil.GetFormatItem(tg020f01Form.Inji_comment2,formInfo["Inji_comment2"]));
			ControlUtil.SetControlValue(Inji_comment_nm2,
				DataFormatUtil.GetFormatItem(tg020f01Form.Inji_comment_nm2,formInfo["Inji_comment_nm2"]));
			ControlUtil.SetControlValue(Label_cd,
				DataFormatUtil.GetFormatItem(tg020f01Form.Label_cd,formInfo["Label_cd"]));
			ControlUtil.SetControlValue(Label_ip,
				DataFormatUtil.GetFormatItem(tg020f01Form.Label_ip,formInfo["Label_ip"]));
			ControlUtil.SetControlValue(Label_nm,
				DataFormatUtil.GetFormatItem(tg020f01Form.Label_nm,formInfo["Label_nm"]));
			ControlUtil.SetControlValue(Modeno,
				DataFormatUtil.GetFormatItem(tg020f01Form.Modeno,formInfo["Modeno"]));
			ControlUtil.SetControlValue(Stkmodeno,
				DataFormatUtil.GetFormatItem(tg020f01Form.Stkmodeno,formInfo["Stkmodeno"]));

			if(!base.CheckUseSelfCustomize()){
				Btnheadtenpocd.Value = base.FormResourceGetString(formResource, "Btnheadtenpocd", lang);
				Btnmodepercentoff.InnerText = base.FormResourceGetString(formResource, "Btnmodepercentoff", lang);
				Btnmodeyenhiki.InnerText = base.FormResourceGetString(formResource, "Btnmodeyenhiki", lang);
				Btnseal.Value = base.FormResourceGetString(formResource, "Btnseal", lang);
				Btnlabel_cd.Value = base.FormResourceGetString(formResource, "Btnlabel_cd", lang);
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
				// に空白を追加
				Inji_comment.Items.Insert(0, new ListItem("", BoSystemConstant.DROPDOWNLIST_MISENTAKU));
				Inji_comment2.Items.Insert(0, new ListItem("", BoSystemConstant.DROPDOWNLIST_MISENTAKU));
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
			// UIScreenController controller = new UIScreenController((Tg020f01Form)base.GetPageContext().GetFormVO());

			/*
			 *登録した機能間連携処理を親画面に感知させる。
			 *機能有効させる場合は、コメントアウトを外してください。
			 */
			//DetailUtil.RunPgSyn(this,(StandardBaseForm)base.GetPageContext().GetFormVO());
			#region 共通ヘッダ表示制御
			LoginInfoVO loginInfVO = LoginInfoUtil.GetLoginInfo();
			ControlHeaderStoreCls.ControlSetHeaderStore(loginInfVO, Head_tenpo_cd, Btnheadtenpocd);
			#endregion


			Tg020f01Form formVo = (Tg020f01Form)base.GetPageContext().GetFormVO();
			//%OFFモード
			if (BoSystemString.Nvl(formVo.Inji_comment).Equals(ConditionInji_comment.VALUE_INJI_COMMENT3))
			{
				ControlCls.Disable(Inji_comment_nm, false);
			}
			else
			{
				ControlCls.Disable(Inji_comment_nm, true);
			}

			//円引きモード	
			if (BoSystemString.Nvl(formVo.Inji_comment2).Equals(ConditionInji_comment.VALUE_INJI_COMMENT3))
			{
				ControlCls.Disable(Inji_comment_nm2, false);
			}
			else
			{
				ControlCls.Disable(Inji_comment_nm2, true);
			}
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
			ControlUtil.SetControlValue(Waririt_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Waririt", lang), base.GetPageContext().FormInfo["Waririt"]));
				DataFormatUtil.SetMustColorCaption(Waririt_lbl, base.GetPageContext().FormInfo["Waririt"]);
			ControlUtil.SetControlValue(Maisu_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Maisu", lang), base.GetPageContext().FormInfo["Maisu"]));
				DataFormatUtil.SetMustColorCaption(Maisu_lbl, base.GetPageContext().FormInfo["Maisu"]);
			ControlUtil.SetControlValue(Inji_comment_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Inji_comment", lang), base.GetPageContext().FormInfo["Inji_comment"]));
				DataFormatUtil.SetMustColorCaption(Inji_comment_lbl, base.GetPageContext().FormInfo["Inji_comment"]);
			ControlUtil.SetControlValue(Inji_comment_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Inji_comment_nm", lang), base.GetPageContext().FormInfo["Inji_comment_nm"]));
				DataFormatUtil.SetMustColorCaption(Inji_comment_nm_lbl, base.GetPageContext().FormInfo["Inji_comment_nm"]);
			ControlUtil.SetControlValue(Warigak_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Warigak", lang), base.GetPageContext().FormInfo["Warigak"]));
				DataFormatUtil.SetMustColorCaption(Warigak_lbl, base.GetPageContext().FormInfo["Warigak"]);
			ControlUtil.SetControlValue(Maisu2_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Maisu2", lang), base.GetPageContext().FormInfo["Maisu2"]));
				DataFormatUtil.SetMustColorCaption(Maisu2_lbl, base.GetPageContext().FormInfo["Maisu2"]);
			ControlUtil.SetControlValue(Inji_comment2_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Inji_comment2", lang), base.GetPageContext().FormInfo["Inji_comment2"]));
				DataFormatUtil.SetMustColorCaption(Inji_comment2_lbl, base.GetPageContext().FormInfo["Inji_comment2"]);
			ControlUtil.SetControlValue(Inji_comment_nm2_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Inji_comment_nm2", lang), base.GetPageContext().FormInfo["Inji_comment_nm2"]));
				DataFormatUtil.SetMustColorCaption(Inji_comment_nm2_lbl, base.GetPageContext().FormInfo["Inji_comment_nm2"]);
			ControlUtil.SetControlValue(Label_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Label_nm", lang), base.GetPageContext().FormInfo["Label_nm"]));
				DataFormatUtil.SetMustColorCaption(Label_nm_lbl, base.GetPageContext().FormInfo["Label_nm"]);
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
				Windowtitle.InnerText = formResource.GetString("Tg020f01_Titlebar", lang);
				//header.FormName = formResource.GetString("Tg020f01_FormCaption", lang);
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
