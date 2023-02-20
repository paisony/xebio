using com.xebio.bo.Tj170p01.Constant;
using com.xebio.bo.Tj170p01.Facade;
using com.xebio.bo.Tj170p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.Model.Context;
using Common.Advanced.Resource;
using Common.Advanced.Web.Context;
using Common.Advanced.Web.Util;
using Common.Business.C01000.C01014;
using Common.Business.C99999.Constant;
using Common.IntegrationMD.Util;
using Common.Standard.Base;
using Common.Standard.Message;
using Common.Standard.Util;
using System;
using System.Collections;
using System.Collections.Specialized;

namespace com.xebio.bo.Tj170p01.Page
{
  /// <summary>
  /// Tj170f02のコードビハインドです。
  /// </summary>
  public partial class Tj170f02Page : StandardBasePage
	{

		#region メソッド

		#region ページデータをロードするメソッド
		/// <summary>
		/// Tj170f02画面データを作成する。
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
						pageContext.SetFormVO(new Tj170f02Form());
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
								new Tj170f02Facade().DoLoad(facadeContext);
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
				new Tj170f02Facade().DoBTNBACK_FRM(facadeContext);
				
				
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
			focusItem = "M1syohingun1_cd";
			focusMno = (string)((Tj170f02Form)pageContext.GetFormVO(Tj170p01Constant.PGID, Tj170p01Constant.FORMID_02)).Dictionary[Tj170p01Constant.DIC_M1SELCETROWIDX];

			// フォーカス設定
			SetFocusCls.SetFocus(queryList, focusItem, focusMno);

			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNBACK_FRM");
			
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
				new Tj170f02Facade().DoPGR_PGN(facadeContext, pageindex);
				
				
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
					if (!MessageDisplayUtil.HasError(pageContext))
					{
						string lang = WebSettingsUtil.GetLangSettingFromSession(pageContext.Session);
						FormResource formResource =
							ResourceFactory.GetFormResource(pageContext.CommandInfo.FormId);
			
						//標題をセットする
						SetCaption(formResource, lang);

						//FormVOを取得する
						Tj170f02Form tj170f02Form = (Tj170f02Form)pageContext.GetFormVO();

						//明細ページ情報を表示する
						ShowListPageInfo(tj170f02Form);
			
						//明細部データを表示する
						RenderList(tj170f02Form, pageContext.FormInfo, formResource, lang);

						//カード部データを表示する
						RenderCard(tj170f02Form, pageContext.FormInfo, formResource, lang);
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
		/// <param name="tj170f02Form">画面FormVO</param>
		private void ShowListPageInfo(Tj170f02Form tj170f02Form)
		{
			//M1明細ページ情報を表示する。
			ShowM1ListPageInfo(tj170f02Form.GetList("M1"));

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
		/// <param name="tj170f02Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderList(
			Tj170f02Form tj170f02Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//画面のM1明細部データを設定する。
			RenderM1List(tj170f02Form, formInfo, formResource, lang);
			//M1明細部のページャーにページ情報を設定する。
			RenderM1Pager(tj170f02Form);
			
		}
		#endregion

		#region M1明細データを表示する
		/// <summary>
		/// M1明細データを表示する。
		/// </summary>
		/// <param name="tj170f02Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderM1List(
			Tj170f02Form tj170f02Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//M1明細部データソースを設定する。
			M1.DataSource = tj170f02Form.GetPageViewList("M1");
			M1.DataBind();

			//M1明細部データをフォーマットする。
			IList m1DataList = (IList)M1.DataSource;
			
			for (int index = 0; index < M1.Items.Count; index++)
			{
				Tj170f02M1Form tj170f02M1Form = (Tj170f02M1Form)m1DataList[index];
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1rowno"),
					DataFormatUtil.GetFormatItem(tj170f02M1Form.M1rowno,formInfo["M1rowno"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1bumon_cd"),
					DataFormatUtil.GetFormatItem(tj170f02M1Form.M1bumon_cd,formInfo["M1bumon_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1bumonkana_nm"),
					DataFormatUtil.GetFormatItem(tj170f02M1Form.M1bumonkana_nm,formInfo["M1bumonkana_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1hinsyu_ryaku_nm"),
					DataFormatUtil.GetFormatItem(tj170f02M1Form.M1hinsyu_ryaku_nm,formInfo["M1hinsyu_ryaku_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1burando_nm"),
					DataFormatUtil.GetFormatItem(tj170f02M1Form.M1burando_nm,formInfo["M1burando_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1jisya_hbn"),
					DataFormatUtil.GetFormatItem(tj170f02M1Form.M1jisya_hbn,formInfo["M1jisya_hbn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1maker_hbn"),
					DataFormatUtil.GetFormatItem(tj170f02M1Form.M1maker_hbn,formInfo["M1maker_hbn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1syonmk"),
					DataFormatUtil.GetFormatItem(tj170f02M1Form.M1syonmk,formInfo["M1syonmk"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1iro_nm"),
					DataFormatUtil.GetFormatItem(tj170f02M1Form.M1iro_nm,formInfo["M1iro_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1size_nm"),
					DataFormatUtil.GetFormatItem(tj170f02M1Form.M1size_nm,formInfo["M1size_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1scan_cd"),
					DataFormatUtil.GetFormatItem(tj170f02M1Form.M1scan_cd,formInfo["M1scan_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1genbaika_tnk"),
					DataFormatUtil.GetFormatItem(tj170f02M1Form.M1genbaika_tnk,formInfo["M1genbaika_tnk"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1hyoka_tnk"),
					DataFormatUtil.GetFormatItem(tj170f02M1Form.M1hyoka_tnk,formInfo["M1hyoka_tnk"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1tanajityobo_su"),
					DataFormatUtil.GetFormatItem(tj170f02M1Form.M1tanajityobo_su,formInfo["M1tanajityobo_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1tanajisekiso_su"),
					DataFormatUtil.GetFormatItem(tj170f02M1Form.M1tanajisekiso_su,formInfo["M1tanajisekiso_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1jitana_su"),
					DataFormatUtil.GetFormatItem(tj170f02M1Form.M1jitana_su,formInfo["M1jitana_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1ikoukebarai_su"),
					DataFormatUtil.GetFormatItem(tj170f02M1Form.M1ikoukebarai_su,formInfo["M1ikoukebarai_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1rironzaiko_su"),
					DataFormatUtil.GetFormatItem(tj170f02M1Form.M1rironzaiko_su,formInfo["M1rironzaiko_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1rirontanaorosi_su"),
					DataFormatUtil.GetFormatItem(tj170f02M1Form.M1rirontanaorosi_su,formInfo["M1rirontanaorosi_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1loss_su"),
					DataFormatUtil.GetFormatItem(tj170f02M1Form.M1loss_su,formInfo["M1loss_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1loss_kin"),
					DataFormatUtil.GetFormatItem(tj170f02M1Form.M1loss_kin,formInfo["M1loss_kin"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1face_no"),
					DataFormatUtil.GetFormatItem(tj170f02M1Form.M1face_no,formInfo["M1face_no"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1tana_dan"),
					DataFormatUtil.GetFormatItem(tj170f02M1Form.M1tana_dan,formInfo["M1tana_dan"]));

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
				// (M1.HeaderRow.FindControl("M1genbaika_tnk") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1genbaika_tnk", lang), base.GetPageContext().FormInfo["M1genbaika_tnk"]);
				// (M1.HeaderRow.FindControl("M1hyoka_tnk") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hyoka_tnk", lang), base.GetPageContext().FormInfo["M1hyoka_tnk"]);
				// (M1.HeaderRow.FindControl("M1tanajityobo_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tanajityobo_su", lang), base.GetPageContext().FormInfo["M1tanajityobo_su"]);
				// (M1.HeaderRow.FindControl("M1tanajisekiso_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tanajisekiso_su", lang), base.GetPageContext().FormInfo["M1tanajisekiso_su"]);
				// (M1.HeaderRow.FindControl("M1jitana_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1jitana_su", lang), base.GetPageContext().FormInfo["M1jitana_su"]);
				// (M1.HeaderRow.FindControl("M1ikoukebarai_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1ikoukebarai_su", lang), base.GetPageContext().FormInfo["M1ikoukebarai_su"]);
				// (M1.HeaderRow.FindControl("M1rironzaiko_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1rironzaiko_su", lang), base.GetPageContext().FormInfo["M1rironzaiko_su"]);
				// (M1.HeaderRow.FindControl("M1rirontanaorosi_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1rirontanaorosi_su", lang), base.GetPageContext().FormInfo["M1rirontanaorosi_su"]);
				// (M1.HeaderRow.FindControl("M1loss_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1loss_su", lang), base.GetPageContext().FormInfo["M1loss_su"]);
				// (M1.HeaderRow.FindControl("M1loss_kin") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1loss_kin", lang), base.GetPageContext().FormInfo["M1loss_kin"]);
				// (M1.HeaderRow.FindControl("M1face_no") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1face_no", lang), base.GetPageContext().FormInfo["M1face_no"]);
				// (M1.HeaderRow.FindControl("M1tana_dan") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tana_dan", lang), base.GetPageContext().FormInfo["M1tana_dan"]);
				// }

		}
		#endregion

		#region M1明細のページャーを表示する
		/// <summary>
		/// M1明細のページャーを表示する。
		/// </summary>
		/// <param name="tj170f02Form">画面FormVO</param>
		private void RenderM1Pager(Tj170f02Form tj170f02Form)
		{
			Pgr.VirtualItemCount = tj170f02Form.GetList("M1").RecordCount;
			Pgr.CurrentPageIndex = tj170f02Form.GetList("M1").PageNo - 1;
			Pgr.PageSize = tj170f02Form.GetList("M1").DispRow;
		}
		#endregion
		#endregion

		#region カードデータを表示する
		/// <summary>
		/// カードデータを表示する
		/// </summary>
		/// <param name="tj170f02Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderCard(
			Tj170f02Form tj170f02Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			
			ControlUtil.SetControlValue(Head_tenpo_cd,
				DataFormatUtil.GetFormatItem(tj170f02Form.Head_tenpo_cd,formInfo["Head_tenpo_cd"]));
			ControlUtil.SetControlValue(Head_tenpo_nm,
				DataFormatUtil.GetFormatItem(tj170f02Form.Head_tenpo_nm,formInfo["Head_tenpo_nm"]));
			ControlUtil.SetControlValue(Stkmodeno,
				DataFormatUtil.GetFormatItem(tj170f02Form.Stkmodeno,formInfo["Stkmodeno"]));
			ControlUtil.SetControlValue(Syohingun1_cd,
				DataFormatUtil.GetFormatItem(tj170f02Form.Syohingun1_cd,formInfo["Syohingun1_cd"]));
			ControlUtil.SetControlValue(Syohingun1_ryaku_nm,
				DataFormatUtil.GetFormatItem(tj170f02Form.Syohingun1_ryaku_nm,formInfo["Syohingun1_ryaku_nm"]));
			ControlUtil.SetControlValue(Syohingun2_cd,
				DataFormatUtil.GetFormatItem(tj170f02Form.Syohingun2_cd,formInfo["Syohingun2_cd"]));
			ControlUtil.SetControlValue(Grpnm,
				DataFormatUtil.GetFormatItem(tj170f02Form.Grpnm,formInfo["Grpnm"]));
			ControlUtil.SetControlValue(Gokeitanajityobo_su,
				DataFormatUtil.GetFormatItem(tj170f02Form.Gokeitanajityobo_su,formInfo["Gokeitanajityobo_su"]));
			ControlUtil.SetControlValue(Gokeitanajisekiso_su,
				DataFormatUtil.GetFormatItem(tj170f02Form.Gokeitanajisekiso_su,formInfo["Gokeitanajisekiso_su"]));
			ControlUtil.SetControlValue(Gokeijitana_su,
				DataFormatUtil.GetFormatItem(tj170f02Form.Gokeijitana_su,formInfo["Gokeijitana_su"]));
			ControlUtil.SetControlValue(Gokeiikoukebarai_su,
				DataFormatUtil.GetFormatItem(tj170f02Form.Gokeiikoukebarai_su,formInfo["Gokeiikoukebarai_su"]));
			ControlUtil.SetControlValue(Gokeirironzaiko_su,
				DataFormatUtil.GetFormatItem(tj170f02Form.Gokeirironzaiko_su,formInfo["Gokeirironzaiko_su"]));
			ControlUtil.SetControlValue(Gokeirirontanaorosi_su,
				DataFormatUtil.GetFormatItem(tj170f02Form.Gokeirirontanaorosi_su,formInfo["Gokeirirontanaorosi_su"]));
			ControlUtil.SetControlValue(Gokeiloss_su,
				DataFormatUtil.GetFormatItem(tj170f02Form.Gokeiloss_su,formInfo["Gokeiloss_su"]));
			ControlUtil.SetControlValue(Gokeiloss_kin,
				DataFormatUtil.GetFormatItem(tj170f02Form.Gokeiloss_kin,formInfo["Gokeiloss_kin"]));

			if(!base.CheckUseSelfCustomize()){
				Btnback.Value = base.FormResourceGetString(formResource, "Btnback", lang);
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
			// UIScreenController controller = new UIScreenController((Tj170f02Form)base.GetPageContext().GetFormVO());
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
			ControlUtil.SetControlValue(Syohingun1_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Syohingun1_cd", lang), base.GetPageContext().FormInfo["Syohingun1_cd"]));
				DataFormatUtil.SetMustColorCaption(Syohingun1_cd_lbl, base.GetPageContext().FormInfo["Syohingun1_cd"]);
			ControlUtil.SetControlValue(Syohingun1_ryaku_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Syohingun1_ryaku_nm", lang), base.GetPageContext().FormInfo["Syohingun1_ryaku_nm"]));
				DataFormatUtil.SetMustColorCaption(Syohingun1_ryaku_nm_lbl, base.GetPageContext().FormInfo["Syohingun1_ryaku_nm"]);
			ControlUtil.SetControlValue(Syohingun2_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Syohingun2_cd", lang), base.GetPageContext().FormInfo["Syohingun2_cd"]));
				DataFormatUtil.SetMustColorCaption(Syohingun2_cd_lbl, base.GetPageContext().FormInfo["Syohingun2_cd"]);
			ControlUtil.SetControlValue(Grpnm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Grpnm", lang), base.GetPageContext().FormInfo["Grpnm"]));
				DataFormatUtil.SetMustColorCaption(Grpnm_lbl, base.GetPageContext().FormInfo["Grpnm"]);
			ControlUtil.SetControlValue(Gokeitanajityobo_su_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Gokeitanajityobo_su", lang), base.GetPageContext().FormInfo["Gokeitanajityobo_su"]));
				DataFormatUtil.SetMustColorCaption(Gokeitanajityobo_su_lbl, base.GetPageContext().FormInfo["Gokeitanajityobo_su"]);
			ControlUtil.SetControlValue(Gokeitanajisekiso_su_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Gokeitanajisekiso_su", lang), base.GetPageContext().FormInfo["Gokeitanajisekiso_su"]));
				DataFormatUtil.SetMustColorCaption(Gokeitanajisekiso_su_lbl, base.GetPageContext().FormInfo["Gokeitanajisekiso_su"]);
			ControlUtil.SetControlValue(Gokeijitana_su_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Gokeijitana_su", lang), base.GetPageContext().FormInfo["Gokeijitana_su"]));
				DataFormatUtil.SetMustColorCaption(Gokeijitana_su_lbl, base.GetPageContext().FormInfo["Gokeijitana_su"]);
			ControlUtil.SetControlValue(Gokeiikoukebarai_su_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Gokeiikoukebarai_su", lang), base.GetPageContext().FormInfo["Gokeiikoukebarai_su"]));
				DataFormatUtil.SetMustColorCaption(Gokeiikoukebarai_su_lbl, base.GetPageContext().FormInfo["Gokeiikoukebarai_su"]);
			ControlUtil.SetControlValue(Gokeirironzaiko_su_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Gokeirironzaiko_su", lang), base.GetPageContext().FormInfo["Gokeirironzaiko_su"]));
				DataFormatUtil.SetMustColorCaption(Gokeirironzaiko_su_lbl, base.GetPageContext().FormInfo["Gokeirironzaiko_su"]);
			ControlUtil.SetControlValue(Gokeirirontanaorosi_su_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Gokeirirontanaorosi_su", lang), base.GetPageContext().FormInfo["Gokeirirontanaorosi_su"]));
				DataFormatUtil.SetMustColorCaption(Gokeirirontanaorosi_su_lbl, base.GetPageContext().FormInfo["Gokeirirontanaorosi_su"]);
			ControlUtil.SetControlValue(Gokeiloss_su_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Gokeiloss_su", lang), base.GetPageContext().FormInfo["Gokeiloss_su"]));
				DataFormatUtil.SetMustColorCaption(Gokeiloss_su_lbl, base.GetPageContext().FormInfo["Gokeiloss_su"]);
			ControlUtil.SetControlValue(Gokeiloss_kin_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Gokeiloss_kin", lang), base.GetPageContext().FormInfo["Gokeiloss_kin"]));
				DataFormatUtil.SetMustColorCaption(Gokeiloss_kin_lbl, base.GetPageContext().FormInfo["Gokeiloss_kin"]);
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
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hinsyu_ryaku_nm", lang), base.GetPageContext().FormInfo["M1hinsyu_ryaku_nm"]);
				// M1.Columns[4].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1burando_nm", lang), base.GetPageContext().FormInfo["M1burando_nm"]);
				// M1.Columns[5].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1jisya_hbn", lang), base.GetPageContext().FormInfo["M1jisya_hbn"]);
				// M1.Columns[6].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1maker_hbn", lang), base.GetPageContext().FormInfo["M1maker_hbn"]);
				// M1.Columns[7].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syonmk", lang), base.GetPageContext().FormInfo["M1syonmk"]);
				// M1.Columns[8].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1iro_nm", lang), base.GetPageContext().FormInfo["M1iro_nm"]);
				// M1.Columns[9].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1size_nm", lang), base.GetPageContext().FormInfo["M1size_nm"]);
				// M1.Columns[10].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1scan_cd", lang), base.GetPageContext().FormInfo["M1scan_cd"]);
				// M1.Columns[11].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1genbaika_tnk", lang), base.GetPageContext().FormInfo["M1genbaika_tnk"]);
				// M1.Columns[12].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hyoka_tnk", lang), base.GetPageContext().FormInfo["M1hyoka_tnk"]);
				// M1.Columns[13].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tanajityobo_su", lang), base.GetPageContext().FormInfo["M1tanajityobo_su"]);
				// M1.Columns[14].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tanajisekiso_su", lang), base.GetPageContext().FormInfo["M1tanajisekiso_su"]);
				// M1.Columns[15].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1jitana_su", lang), base.GetPageContext().FormInfo["M1jitana_su"]);
				// M1.Columns[16].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1ikoukebarai_su", lang), base.GetPageContext().FormInfo["M1ikoukebarai_su"]);
				// M1.Columns[17].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1rironzaiko_su", lang), base.GetPageContext().FormInfo["M1rironzaiko_su"]);
				// M1.Columns[18].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1rirontanaorosi_su", lang), base.GetPageContext().FormInfo["M1rirontanaorosi_su"]);
				// M1.Columns[19].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1loss_su", lang), base.GetPageContext().FormInfo["M1loss_su"]);
				// M1.Columns[20].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1loss_kin", lang), base.GetPageContext().FormInfo["M1loss_kin"]);
				// M1.Columns[21].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1face_no", lang), base.GetPageContext().FormInfo["M1face_no"]);
				// M1.Columns[22].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tana_dan", lang), base.GetPageContext().FormInfo["M1tana_dan"]);
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
				Windowtitle.InnerText = formResource.GetString("Tj170f02_Titlebar", lang);
				header.FormName = formResource.GetString("Tj170f02_FormCaption", lang);
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
