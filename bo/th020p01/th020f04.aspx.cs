using com.xebio.bo.Th020p01.Facade;
using com.xebio.bo.Th020p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.Model.Context;
using Common.Advanced.Resource;
using Common.Advanced.Web.Context;
using Common.Advanced.Web.Util;
using Common.Business.C01000.C01016;
using Common.Business.C99999.Constant;
using Common.IntegrationMD.Util;
using Common.Standard.Base;
using Common.Standard.Message;
using Common.Standard.Util;
using System;
using System.Collections;
using System.Collections.Specialized;

namespace com.xebio.bo.Th020p01.Page
{
  /// <summary>
  /// Th020f04のコードビハインドです。
  /// </summary>
  public partial class Th020f04Page : StandardBasePage
	{

		#region メソッド

		#region ページデータをロードするメソッド
		/// <summary>
		/// Th020f04画面データを作成する。
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
						pageContext.SetFormVO(new Th020f04Form());
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
								new Th020f04Facade().DoLoad(facadeContext);
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
				new Th020f04Facade().DoBTNBACK_FRM(facadeContext);
				
				
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
			EndMethod(sender, e, this.GetType().Name + ".OnBTNBACK_FRM");
			
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
						Th020f04Form th020f04Form = (Th020f04Form)pageContext.GetFormVO();

						//明細ページ情報を表示する
						ShowListPageInfo(th020f04Form);
			
						//明細部データを表示する
						RenderList(th020f04Form, pageContext.FormInfo, formResource, lang);

						//カード部データを表示する
						RenderCard(th020f04Form, pageContext.FormInfo, formResource, lang);
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
		/// <param name="th020f04Form">画面FormVO</param>
		private void ShowListPageInfo(Th020f04Form th020f04Form)
		{
			//M1明細ページ情報を表示する。
			ShowM1ListPageInfo(th020f04Form.GetList("M1"));

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
		/// <param name="th020f04Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderList(
			Th020f04Form th020f04Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//画面のM1明細部データを設定する。
			RenderM1List(th020f04Form, formInfo, formResource, lang);
			
		}
		#endregion

		#region M1明細データを表示する
		/// <summary>
		/// M1明細データを表示する。
		/// </summary>
		/// <param name="th020f04Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderM1List(
			Th020f04Form th020f04Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//M1明細部データソースを設定する。
			M1.DataSource = th020f04Form.GetPageViewList("M1");
			M1.DataBind();

			//M1明細部データをフォーマットする。
			IList m1DataList = (IList)M1.DataSource;
			
			for (int index = 0; index < M1.Items.Count; index++)
			{
				Th020f04M1Form th020f04M1Form = (Th020f04M1Form)m1DataList[index];
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1rowno"),
					DataFormatUtil.GetFormatItem(th020f04M1Form.M1rowno,formInfo["M1rowno"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1tenpo_cd"),
					DataFormatUtil.GetFormatItem(th020f04M1Form.M1tenpo_cd,formInfo["M1tenpo_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1tenpo_nm"),
					DataFormatUtil.GetFormatItem(th020f04M1Form.M1tenpo_nm,formInfo["M1tenpo_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1uriage_su"),
					DataFormatUtil.GetFormatItem(th020f04M1Form.M1uriage_su,formInfo["M1uriage_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1freezaiko_su"),
					DataFormatUtil.GetFormatItem(th020f04M1Form.M1freezaiko_su,formInfo["M1freezaiko_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1syoka_rtu"),
					DataFormatUtil.GetFormatItem(th020f04M1Form.M1syoka_rtu,formInfo["M1syoka_rtu"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1tyobozaiko_su"),
					DataFormatUtil.GetFormatItem(th020f04M1Form.M1tyobozaiko_su,formInfo["M1tyobozaiko_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1azukariyoyaku_su"),
					DataFormatUtil.GetFormatItem(th020f04M1Form.M1azukariyoyaku_su,formInfo["M1azukariyoyaku_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1sekiso_su"),
					DataFormatUtil.GetFormatItem(th020f04M1Form.M1sekiso_su,formInfo["M1sekiso_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1tonan_su"),
					DataFormatUtil.GetFormatItem(th020f04M1Form.M1tonan_su,formInfo["M1tonan_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1hyokasonsinsei_su"),
					DataFormatUtil.GetFormatItem(th020f04M1Form.M1hyokasonsinsei_su,formInfo["M1hyokasonsinsei_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1selectorcheckbox"),
					DataFormatUtil.GetFormatItem(th020f04M1Form.M1selectorcheckbox,formInfo["M1selectorcheckbox"]));
				((System.Web.UI.WebControls.CheckBox)M1.Items[index].FindControl("M1selectorcheckbox")).Text =
					formResource.GetString("M1selectorcheckbox", lang);
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1entersyoriflg"),
					DataFormatUtil.GetFormatItem(th020f04M1Form.M1entersyoriflg,formInfo["M1entersyoriflg"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1dtlirokbn"),
					DataFormatUtil.GetFormatItem(th020f04M1Form.M1dtlirokbn,formInfo["M1dtlirokbn"]));

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
				// (M1.HeaderRow.FindControl("M1tenpo_cd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tenpo_cd", lang), base.GetPageContext().FormInfo["M1tenpo_cd"]);
				// (M1.HeaderRow.FindControl("M1tenpo_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tenpo_nm", lang), base.GetPageContext().FormInfo["M1tenpo_nm"]);
				// (M1.HeaderRow.FindControl("M1uriage_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1uriage_su", lang), base.GetPageContext().FormInfo["M1uriage_su"]);
				// (M1.HeaderRow.FindControl("M1freezaiko_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1freezaiko_su", lang), base.GetPageContext().FormInfo["M1freezaiko_su"]);
				// (M1.HeaderRow.FindControl("M1syoka_rtu") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syoka_rtu", lang), base.GetPageContext().FormInfo["M1syoka_rtu"]);
				// (M1.HeaderRow.FindControl("M1tyobozaiko_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tyobozaiko_su", lang), base.GetPageContext().FormInfo["M1tyobozaiko_su"]);
				// (M1.HeaderRow.FindControl("M1azukariyoyaku_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1azukariyoyaku_su", lang), base.GetPageContext().FormInfo["M1azukariyoyaku_su"]);
				// (M1.HeaderRow.FindControl("M1sekiso_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1sekiso_su", lang), base.GetPageContext().FormInfo["M1sekiso_su"]);
				// (M1.HeaderRow.FindControl("M1tonan_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tonan_su", lang), base.GetPageContext().FormInfo["M1tonan_su"]);
				// (M1.HeaderRow.FindControl("M1hyokasonsinsei_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hyokasonsinsei_su", lang), base.GetPageContext().FormInfo["M1hyokasonsinsei_su"]);
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
		/// <param name="th020f04Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderCard(
			Th020f04Form th020f04Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			
			ControlUtil.SetControlValue(Head_tenpo_cd,
				DataFormatUtil.GetFormatItem(th020f04Form.Head_tenpo_cd,formInfo["Head_tenpo_cd"]));
			ControlUtil.SetControlValue(Head_tenpo_nm,
				DataFormatUtil.GetFormatItem(th020f04Form.Head_tenpo_nm,formInfo["Head_tenpo_nm"]));
			ControlUtil.SetControlValue(Kaisya_cd,
				DataFormatUtil.GetFormatItem(th020f04Form.Kaisya_cd,formInfo["Kaisya_cd"]));
			ControlUtil.SetControlValue(Kaisya_nm,
				DataFormatUtil.GetFormatItem(th020f04Form.Kaisya_nm,formInfo["Kaisya_nm"]));
			ControlUtil.SetControlValue(Bumon_cd,
				DataFormatUtil.GetFormatItem(th020f04Form.Bumon_cd,formInfo["Bumon_cd"]));
			ControlUtil.SetControlValue(Bumon_nm,
				DataFormatUtil.GetFormatItem(th020f04Form.Bumon_nm,formInfo["Bumon_nm"]));
			ControlUtil.SetControlValue(Hinsyu_ryaku_nm,
				DataFormatUtil.GetFormatItem(th020f04Form.Hinsyu_ryaku_nm,formInfo["Hinsyu_ryaku_nm"]));
			ControlUtil.SetControlValue(Hinsyu_cd,
				DataFormatUtil.GetFormatItem(th020f04Form.Hinsyu_cd,formInfo["Hinsyu_cd"]));
			ControlUtil.SetControlValue(Burando_cd,
				DataFormatUtil.GetFormatItem(th020f04Form.Burando_cd,formInfo["Burando_cd"]));
			ControlUtil.SetControlValue(Burando_nm,
				DataFormatUtil.GetFormatItem(th020f04Form.Burando_nm,formInfo["Burando_nm"]));
			ControlUtil.SetControlValue(Jisya_hbn,
				DataFormatUtil.GetFormatItem(th020f04Form.Jisya_hbn,formInfo["Jisya_hbn"]));
			ControlUtil.SetControlValue(Maker_hbn,
				DataFormatUtil.GetFormatItem(th020f04Form.Maker_hbn,formInfo["Maker_hbn"]));
			ControlUtil.SetControlValue(Syohin_zokusei,
				DataFormatUtil.GetFormatItem(th020f04Form.Syohin_zokusei,formInfo["Syohin_zokusei"]));
			ControlUtil.SetControlValue(Syonmk,
				DataFormatUtil.GetFormatItem(th020f04Form.Syonmk,formInfo["Syonmk"]));
			ControlUtil.SetControlValue(Iro_nm,
				DataFormatUtil.GetFormatItem(th020f04Form.Iro_nm,formInfo["Iro_nm"]));
			ControlUtil.SetControlValue(Size_nm,
				DataFormatUtil.GetFormatItem(th020f04Form.Size_nm,formInfo["Size_nm"]));
			ControlUtil.SetControlValue(Scan_cd,
				DataFormatUtil.GetFormatItem(th020f04Form.Scan_cd,formInfo["Scan_cd"]));

			if(!base.CheckUseSelfCustomize()){
				Btnback.Value = base.FormResourceGetString(formResource, "Btnback", lang);
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
			// UIScreenController controller = new UIScreenController((Th020f04Form)base.GetPageContext().GetFormVO());
			// controller.ChangeColumnsDisplayMode(M1 ,  new DetailHeaderFixedVO(M1Header , true) , null);

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
			ControlUtil.SetControlValue(Kaisya_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Kaisya_cd", lang), base.GetPageContext().FormInfo["Kaisya_cd"]));
				DataFormatUtil.SetMustColorCaption(Kaisya_cd_lbl, base.GetPageContext().FormInfo["Kaisya_cd"]);
			ControlUtil.SetControlValue(Kaisya_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Kaisya_nm", lang), base.GetPageContext().FormInfo["Kaisya_nm"]));
				DataFormatUtil.SetMustColorCaption(Kaisya_nm_lbl, base.GetPageContext().FormInfo["Kaisya_nm"]);
			ControlUtil.SetControlValue(Bumon_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Bumon_cd", lang), base.GetPageContext().FormInfo["Bumon_cd"]));
				DataFormatUtil.SetMustColorCaption(Bumon_cd_lbl, base.GetPageContext().FormInfo["Bumon_cd"]);
			ControlUtil.SetControlValue(Bumon_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Bumon_nm", lang), base.GetPageContext().FormInfo["Bumon_nm"]));
				DataFormatUtil.SetMustColorCaption(Bumon_nm_lbl, base.GetPageContext().FormInfo["Bumon_nm"]);
			ControlUtil.SetControlValue(Hinsyu_ryaku_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Hinsyu_ryaku_nm", lang), base.GetPageContext().FormInfo["Hinsyu_ryaku_nm"]));
				DataFormatUtil.SetMustColorCaption(Hinsyu_ryaku_nm_lbl, base.GetPageContext().FormInfo["Hinsyu_ryaku_nm"]);
			ControlUtil.SetControlValue(Burando_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Burando_cd", lang), base.GetPageContext().FormInfo["Burando_cd"]));
				DataFormatUtil.SetMustColorCaption(Burando_cd_lbl, base.GetPageContext().FormInfo["Burando_cd"]);
			ControlUtil.SetControlValue(Burando_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Burando_nm", lang), base.GetPageContext().FormInfo["Burando_nm"]));
				DataFormatUtil.SetMustColorCaption(Burando_nm_lbl, base.GetPageContext().FormInfo["Burando_nm"]);
			ControlUtil.SetControlValue(Jisya_hbn_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Jisya_hbn", lang), base.GetPageContext().FormInfo["Jisya_hbn"]));
				DataFormatUtil.SetMustColorCaption(Jisya_hbn_lbl, base.GetPageContext().FormInfo["Jisya_hbn"]);
			ControlUtil.SetControlValue(Maker_hbn_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Maker_hbn", lang), base.GetPageContext().FormInfo["Maker_hbn"]));
				DataFormatUtil.SetMustColorCaption(Maker_hbn_lbl, base.GetPageContext().FormInfo["Maker_hbn"]);
			ControlUtil.SetControlValue(Syohin_zokusei_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Syohin_zokusei", lang), base.GetPageContext().FormInfo["Syohin_zokusei"]));
				DataFormatUtil.SetMustColorCaption(Syohin_zokusei_lbl, base.GetPageContext().FormInfo["Syohin_zokusei"]);
			ControlUtil.SetControlValue(Syonmk_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Syonmk", lang), base.GetPageContext().FormInfo["Syonmk"]));
				DataFormatUtil.SetMustColorCaption(Syonmk_lbl, base.GetPageContext().FormInfo["Syonmk"]);
			ControlUtil.SetControlValue(Iro_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Iro_nm", lang), base.GetPageContext().FormInfo["Iro_nm"]));
				DataFormatUtil.SetMustColorCaption(Iro_nm_lbl, base.GetPageContext().FormInfo["Iro_nm"]);
			ControlUtil.SetControlValue(Size_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Size_nm", lang), base.GetPageContext().FormInfo["Size_nm"]));
				DataFormatUtil.SetMustColorCaption(Size_nm_lbl, base.GetPageContext().FormInfo["Size_nm"]);
			ControlUtil.SetControlValue(Scan_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Scan_cd", lang), base.GetPageContext().FormInfo["Scan_cd"]));
				DataFormatUtil.SetMustColorCaption(Scan_cd_lbl, base.GetPageContext().FormInfo["Scan_cd"]);
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
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1uriage_su", lang), base.GetPageContext().FormInfo["M1uriage_su"]);
				// M1.Columns[4].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1freezaiko_su", lang), base.GetPageContext().FormInfo["M1freezaiko_su"]);
				// M1.Columns[5].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syoka_rtu", lang), base.GetPageContext().FormInfo["M1syoka_rtu"]);
				// M1.Columns[6].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tyobozaiko_su", lang), base.GetPageContext().FormInfo["M1tyobozaiko_su"]);
				// M1.Columns[7].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1azukariyoyaku_su", lang), base.GetPageContext().FormInfo["M1azukariyoyaku_su"]);
				// M1.Columns[8].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1sekiso_su", lang), base.GetPageContext().FormInfo["M1sekiso_su"]);
				// M1.Columns[9].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tonan_su", lang), base.GetPageContext().FormInfo["M1tonan_su"]);
				// M1.Columns[10].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hyokasonsinsei_su", lang), base.GetPageContext().FormInfo["M1hyokasonsinsei_su"]);
				// M1.Columns[11].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1selectorcheckbox", lang), base.GetPageContext().FormInfo["M1selectorcheckbox"]);
				// M1.Columns[12].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1entersyoriflg", lang), base.GetPageContext().FormInfo["M1entersyoriflg"]);
				// M1.Columns[13].HeaderText = 
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
				Windowtitle.InnerText = formResource.GetString("Th020f04_Titlebar", lang);
				header.FormName = formResource.GetString("Th020f04_FormCaption", lang);
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
