using com.xebio.bo.Te130p01.Constant;
using com.xebio.bo.Te130p01.Facade;
using com.xebio.bo.Te130p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.Model.Context;
using Common.Advanced.Resource;
using Common.Advanced.Web.Context;
using Common.Advanced.Web.Util;
using Common.Business.C01000.C01014;
using Common.Business.C01000.C01016;
using Common.Business.C99999.Constant;
using Common.IntegrationMD.Util;
using Common.Standard.Base;
using Common.Standard.Message;
using Common.Standard.Util;
using System;
using System.Collections;
using System.Collections.Specialized;

namespace com.xebio.bo.Te130p01.Page
{
  /// <summary>
  /// Te130f02のコードビハインドです。
  /// </summary>
  public partial class Te130f02Page : StandardBasePage
	{

		#region メソッド

		#region ページデータをロードするメソッド
		/// <summary>
		/// Te130f02画面データを作成する。
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
				if (!IsPostBack)
				{
					//アクションコンテキスト取得
					pageContext = base.GetPageContext();
					ICommandInfo commandInfo = pageContext.CommandInfo;
					//画面初期化処理
					base.InitForm(pageContext);

					//画面データ初期化
					if (commandInfo.PageLoadMode && commandInfo.ActionMode != null)
					{
						pageContext.SetFormVO(new Te130f02Form());
						switch (commandInfo.ActionMode)
						{
							case "ADD":
								break;
							case "INI":
							case "DEL":
							case "UPD":
								IFacadeContext facadeContext =
									FacadeContextFactory.GetFacadeContext(pageContext);
								InitFacadeContext(facadeContext);
								new Te130f02Facade().DoLoad(facadeContext);
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
				new Te130f02Facade().DoBTNBACK_FRM(facadeContext);
				
				
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

			// 選択された部門コードにフォーカス設定
            focusItem = "M1denpyo_bango";
			focusMno = (string)((Te130f02Form) pageContext.GetFormVO(Te130p01Constant.PGID, Te130p01Constant.FORMID_02)).Dictionary[Te130p01Constant.DIC_M1SELCETROWIDX];

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
				new Te130f02Facade().DoPGR_PGN(facadeContext, pageindex);
				
				
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
						Te130f02Form te130f02Form = (Te130f02Form)pageContext.GetFormVO();

						//明細ページ情報を表示する
						ShowListPageInfo(te130f02Form);
			
						//明細部データを表示する
						RenderList(te130f02Form, pageContext.FormInfo, formResource, lang);

						//カード部データを表示する
						RenderCard(te130f02Form, pageContext.FormInfo, formResource, lang);
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
		/// <param name="te130f02Form">画面FormVO</param>
		private void ShowListPageInfo(Te130f02Form te130f02Form)
		{
			//M1明細ページ情報を表示する。
			ShowM1ListPageInfo(te130f02Form.GetList("M1"));

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
		/// <param name="te130f02Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderList(
			Te130f02Form te130f02Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//画面のM1明細部データを設定する。
			RenderM1List(te130f02Form, formInfo, formResource, lang);
			//M1明細部のページャーにページ情報を設定する。
			RenderM1Pager(te130f02Form);
			
		}
		#endregion

		#region M1明細データを表示する
		/// <summary>
		/// M1明細データを表示する。
		/// </summary>
		/// <param name="te130f02Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderM1List(
			Te130f02Form te130f02Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//M1明細部データソースを設定する。
			M1.DataSource = te130f02Form.GetPageViewList("M1");
			M1.DataBind();

			//M1明細部データをフォーマットする。
			IList m1DataList = (IList)M1.DataSource;
			
			for (int index = 0; index < M1.Items.Count; index++)
			{
				Te130f02M1Form te130f02M1Form = (Te130f02M1Form)m1DataList[index];
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1rowno"),
					DataFormatUtil.GetFormatItem(te130f02M1Form.M1rowno,formInfo["M1rowno"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1bumon_cd"),
					DataFormatUtil.GetFormatItem(te130f02M1Form.M1bumon_cd,formInfo["M1bumon_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1bumonkana_nm"),
					DataFormatUtil.GetFormatItem(te130f02M1Form.M1bumonkana_nm,formInfo["M1bumonkana_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1hinsyu_ryaku_nm"),
					DataFormatUtil.GetFormatItem(te130f02M1Form.M1hinsyu_ryaku_nm,formInfo["M1hinsyu_ryaku_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1burando_nm"),
					DataFormatUtil.GetFormatItem(te130f02M1Form.M1burando_nm,formInfo["M1burando_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1jisya_hbn"),
					DataFormatUtil.GetFormatItem(te130f02M1Form.M1jisya_hbn,formInfo["M1jisya_hbn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1maker_hbn"),
					DataFormatUtil.GetFormatItem(te130f02M1Form.M1maker_hbn,formInfo["M1maker_hbn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1syonmk"),
					DataFormatUtil.GetFormatItem(te130f02M1Form.M1syonmk,formInfo["M1syonmk"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1iro_nm"),
					DataFormatUtil.GetFormatItem(te130f02M1Form.M1iro_nm,formInfo["M1iro_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1size_nm"),
					DataFormatUtil.GetFormatItem(te130f02M1Form.M1size_nm,formInfo["M1size_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1scan_cd"),
					DataFormatUtil.GetFormatItem(te130f02M1Form.M1scan_cd,formInfo["M1scan_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1nyukayotei_su"),
					DataFormatUtil.GetFormatItem(te130f02M1Form.M1nyukayotei_su,formInfo["M1nyukayotei_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1nyukajisseki_su"),
					DataFormatUtil.GetFormatItem(te130f02M1Form.M1nyukajisseki_su,formInfo["M1nyukajisseki_su"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1gen_tnk"),
					DataFormatUtil.GetFormatItem(te130f02M1Form.M1gen_tnk,formInfo["M1gen_tnk"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1genka_kin"),
					DataFormatUtil.GetFormatItem(te130f02M1Form.M1genka_kin,formInfo["M1genka_kin"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1selectorcheckbox"),
					DataFormatUtil.GetFormatItem(te130f02M1Form.M1selectorcheckbox,formInfo["M1selectorcheckbox"]));
				((System.Web.UI.WebControls.CheckBox)M1.Items[index].FindControl("M1selectorcheckbox")).Text =
					formResource.GetString("M1selectorcheckbox", lang);
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1entersyoriflg"),
					DataFormatUtil.GetFormatItem(te130f02M1Form.M1entersyoriflg,formInfo["M1entersyoriflg"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1dtlirokbn"),
					DataFormatUtil.GetFormatItem(te130f02M1Form.M1dtlirokbn,formInfo["M1dtlirokbn"]));

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
				// (M1.HeaderRow.FindControl("M1nyukayotei_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1nyukayotei_su", lang), base.GetPageContext().FormInfo["M1nyukayotei_su"]);
				// (M1.HeaderRow.FindControl("M1nyukajisseki_su") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1nyukajisseki_su", lang), base.GetPageContext().FormInfo["M1nyukajisseki_su"]);
				// (M1.HeaderRow.FindControl("M1gen_tnk") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1gen_tnk", lang), base.GetPageContext().FormInfo["M1gen_tnk"]);
				// (M1.HeaderRow.FindControl("M1genka_kin") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1genka_kin", lang), base.GetPageContext().FormInfo["M1genka_kin"]);
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
		/// <param name="te130f02Form">画面FormVO</param>
		private void RenderM1Pager(Te130f02Form te130f02Form)
		{
			Pgr.VirtualItemCount = te130f02Form.GetList("M1").RecordCount;
			Pgr.CurrentPageIndex = te130f02Form.GetList("M1").PageNo - 1;
			Pgr.PageSize = te130f02Form.GetList("M1").DispRow;
		}
		#endregion
		#endregion

		#region カードデータを表示する
		/// <summary>
		/// カードデータを表示する
		/// </summary>
		/// <param name="te130f02Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderCard(
			Te130f02Form te130f02Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			
			ControlUtil.SetControlValue(Head_tenpo_cd,
				DataFormatUtil.GetFormatItem(te130f02Form.Head_tenpo_cd,formInfo["Head_tenpo_cd"]));
			ControlUtil.SetControlValue(Head_tenpo_nm,
				DataFormatUtil.GetFormatItem(te130f02Form.Head_tenpo_nm,formInfo["Head_tenpo_nm"]));
			ControlUtil.SetControlValue(Denpyo_bango,
				DataFormatUtil.GetFormatItem(te130f02Form.Denpyo_bango,formInfo["Denpyo_bango"]));
			ControlUtil.SetControlValue(Scm_cd,
				DataFormatUtil.GetFormatItem(te130f02Form.Scm_cd,formInfo["Scm_cd"]));
			ControlUtil.SetControlValue(Jyuryokaisya_cd,
				DataFormatUtil.GetFormatItem(te130f02Form.Jyuryokaisya_cd,formInfo["Jyuryokaisya_cd"]));
			ControlUtil.SetControlValue(Nyukakaisya_nm,
				DataFormatUtil.GetFormatItem(te130f02Form.Nyukakaisya_nm,formInfo["Nyukakaisya_nm"]));
			ControlUtil.SetControlValue(Jyuryoten_cd,
				DataFormatUtil.GetFormatItem(te130f02Form.Jyuryoten_cd,formInfo["Jyuryoten_cd"]));
			ControlUtil.SetControlValue(Juryoten_nm,
				DataFormatUtil.GetFormatItem(te130f02Form.Juryoten_nm,formInfo["Juryoten_nm"]));
			ControlUtil.SetControlValue(Nyukatan_cd,
				DataFormatUtil.GetFormatItem(te130f02Form.Nyukatan_cd,formInfo["Nyukatan_cd"]));
			ControlUtil.SetControlValue(Nyukatan_nm,
				DataFormatUtil.GetFormatItem(te130f02Form.Nyukatan_nm,formInfo["Nyukatan_nm"]));
			ControlUtil.SetControlValue(Jyuryo_ymd,
				DataFormatUtil.GetFormatItem(te130f02Form.Jyuryo_ymd,formInfo["Jyuryo_ymd"]));
			ControlUtil.SetControlValue(Syukkakaisya_cd,
				DataFormatUtil.GetFormatItem(te130f02Form.Syukkakaisya_cd,formInfo["Syukkakaisya_cd"]));
			ControlUtil.SetControlValue(Syukkakaisya_nm,
				DataFormatUtil.GetFormatItem(te130f02Form.Syukkakaisya_nm,formInfo["Syukkakaisya_nm"]));
			ControlUtil.SetControlValue(Syukkaten_cd,
				DataFormatUtil.GetFormatItem(te130f02Form.Syukkaten_cd,formInfo["Syukkaten_cd"]));
			ControlUtil.SetControlValue(Syukkatenpo_nm,
				DataFormatUtil.GetFormatItem(te130f02Form.Syukkatenpo_nm,formInfo["Syukkatenpo_nm"]));
			ControlUtil.SetControlValue(Syukkatan_cd,
				DataFormatUtil.GetFormatItem(te130f02Form.Syukkatan_cd,formInfo["Syukkatan_cd"]));
			ControlUtil.SetControlValue(Syukkatan_nm,
				DataFormatUtil.GetFormatItem(te130f02Form.Syukkatan_nm,formInfo["Syukkatan_nm"]));
			ControlUtil.SetControlValue(Syukka_ymd,
				DataFormatUtil.GetFormatItem(te130f02Form.Syukka_ymd,formInfo["Syukka_ymd"]));
			ControlUtil.SetControlValue(Syorinm,
				DataFormatUtil.GetFormatItem(te130f02Form.Syorinm,formInfo["Syorinm"]));
			ControlUtil.SetControlValue(Syoriymd,
				DataFormatUtil.GetFormatItem(te130f02Form.Syoriymd,formInfo["Syoriymd"]));
			ControlUtil.SetControlValue(Syori_tm,
				DataFormatUtil.GetFormatItem(te130f02Form.Syori_tm,formInfo["Syori_tm"]));
			ControlUtil.SetControlValue(Nyukayotei_su_gokei,
				DataFormatUtil.GetFormatItem(te130f02Form.Nyukayotei_su_gokei,formInfo["Nyukayotei_su_gokei"]));
			ControlUtil.SetControlValue(Nyukajisseki_su_gokei,
				DataFormatUtil.GetFormatItem(te130f02Form.Nyukajisseki_su_gokei,formInfo["Nyukajisseki_su_gokei"]));
			ControlUtil.SetControlValue(Genka_kin_gokei,
				DataFormatUtil.GetFormatItem(te130f02Form.Genka_kin_gokei,formInfo["Genka_kin_gokei"]));

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
			// UIScreenController controller = new UIScreenController((Te130f02Form)base.GetPageContext().GetFormVO());
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
			ControlUtil.SetControlValue(Denpyo_bango_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Denpyo_bango", lang), base.GetPageContext().FormInfo["Denpyo_bango"]));
				DataFormatUtil.SetMustColorCaption(Denpyo_bango_lbl, base.GetPageContext().FormInfo["Denpyo_bango"]);
			ControlUtil.SetControlValue(Scm_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Scm_cd", lang), base.GetPageContext().FormInfo["Scm_cd"]));
				DataFormatUtil.SetMustColorCaption(Scm_cd_lbl, base.GetPageContext().FormInfo["Scm_cd"]);
			ControlUtil.SetControlValue(Jyuryokaisya_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Jyuryokaisya_cd", lang), base.GetPageContext().FormInfo["Jyuryokaisya_cd"]));
				DataFormatUtil.SetMustColorCaption(Jyuryokaisya_cd_lbl, base.GetPageContext().FormInfo["Jyuryokaisya_cd"]);
			ControlUtil.SetControlValue(Nyukakaisya_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Nyukakaisya_nm", lang), base.GetPageContext().FormInfo["Nyukakaisya_nm"]));
				DataFormatUtil.SetMustColorCaption(Nyukakaisya_nm_lbl, base.GetPageContext().FormInfo["Nyukakaisya_nm"]);
			ControlUtil.SetControlValue(Jyuryoten_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Jyuryoten_cd", lang), base.GetPageContext().FormInfo["Jyuryoten_cd"]));
				DataFormatUtil.SetMustColorCaption(Jyuryoten_cd_lbl, base.GetPageContext().FormInfo["Jyuryoten_cd"]);
			ControlUtil.SetControlValue(Juryoten_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Juryoten_nm", lang), base.GetPageContext().FormInfo["Juryoten_nm"]));
				DataFormatUtil.SetMustColorCaption(Juryoten_nm_lbl, base.GetPageContext().FormInfo["Juryoten_nm"]);
			ControlUtil.SetControlValue(Nyukatan_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Nyukatan_cd", lang), base.GetPageContext().FormInfo["Nyukatan_cd"]));
				DataFormatUtil.SetMustColorCaption(Nyukatan_cd_lbl, base.GetPageContext().FormInfo["Nyukatan_cd"]);
			ControlUtil.SetControlValue(Nyukatan_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Nyukatan_nm", lang), base.GetPageContext().FormInfo["Nyukatan_nm"]));
				DataFormatUtil.SetMustColorCaption(Nyukatan_nm_lbl, base.GetPageContext().FormInfo["Nyukatan_nm"]);
			ControlUtil.SetControlValue(Jyuryo_ymd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Jyuryo_ymd", lang), base.GetPageContext().FormInfo["Jyuryo_ymd"]));
				DataFormatUtil.SetMustColorCaption(Jyuryo_ymd_lbl, base.GetPageContext().FormInfo["Jyuryo_ymd"]);
			ControlUtil.SetControlValue(Syukkakaisya_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Syukkakaisya_cd", lang), base.GetPageContext().FormInfo["Syukkakaisya_cd"]));
				DataFormatUtil.SetMustColorCaption(Syukkakaisya_cd_lbl, base.GetPageContext().FormInfo["Syukkakaisya_cd"]);
			ControlUtil.SetControlValue(Syukkakaisya_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Syukkakaisya_nm", lang), base.GetPageContext().FormInfo["Syukkakaisya_nm"]));
				DataFormatUtil.SetMustColorCaption(Syukkakaisya_nm_lbl, base.GetPageContext().FormInfo["Syukkakaisya_nm"]);
			ControlUtil.SetControlValue(Syukkaten_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Syukkaten_cd", lang), base.GetPageContext().FormInfo["Syukkaten_cd"]));
				DataFormatUtil.SetMustColorCaption(Syukkaten_cd_lbl, base.GetPageContext().FormInfo["Syukkaten_cd"]);
			ControlUtil.SetControlValue(Syukkatenpo_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Syukkatenpo_nm", lang), base.GetPageContext().FormInfo["Syukkatenpo_nm"]));
				DataFormatUtil.SetMustColorCaption(Syukkatenpo_nm_lbl, base.GetPageContext().FormInfo["Syukkatenpo_nm"]);
			ControlUtil.SetControlValue(Syukkatan_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Syukkatan_cd", lang), base.GetPageContext().FormInfo["Syukkatan_cd"]));
				DataFormatUtil.SetMustColorCaption(Syukkatan_cd_lbl, base.GetPageContext().FormInfo["Syukkatan_cd"]);
			ControlUtil.SetControlValue(Syukkatan_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Syukkatan_nm", lang), base.GetPageContext().FormInfo["Syukkatan_nm"]));
				DataFormatUtil.SetMustColorCaption(Syukkatan_nm_lbl, base.GetPageContext().FormInfo["Syukkatan_nm"]);
			ControlUtil.SetControlValue(Syukka_ymd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Syukka_ymd", lang), base.GetPageContext().FormInfo["Syukka_ymd"]));
				DataFormatUtil.SetMustColorCaption(Syukka_ymd_lbl, base.GetPageContext().FormInfo["Syukka_ymd"]);
			ControlUtil.SetControlValue(Syorinm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Syorinm", lang), base.GetPageContext().FormInfo["Syorinm"]));
				DataFormatUtil.SetMustColorCaption(Syorinm_lbl, base.GetPageContext().FormInfo["Syorinm"]);
			ControlUtil.SetControlValue(Syoriymd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Syoriymd", lang), base.GetPageContext().FormInfo["Syoriymd"]));
				DataFormatUtil.SetMustColorCaption(Syoriymd_lbl, base.GetPageContext().FormInfo["Syoriymd"]);
			ControlUtil.SetControlValue(Syori_tm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Syori_tm", lang), base.GetPageContext().FormInfo["Syori_tm"]));
				DataFormatUtil.SetMustColorCaption(Syori_tm_lbl, base.GetPageContext().FormInfo["Syori_tm"]);
			ControlUtil.SetControlValue(Nyukayotei_su_gokei_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Nyukayotei_su_gokei", lang), base.GetPageContext().FormInfo["Nyukayotei_su_gokei"]));
				DataFormatUtil.SetMustColorCaption(Nyukayotei_su_gokei_lbl, base.GetPageContext().FormInfo["Nyukayotei_su_gokei"]);
			ControlUtil.SetControlValue(Nyukajisseki_su_gokei_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Nyukajisseki_su_gokei", lang), base.GetPageContext().FormInfo["Nyukajisseki_su_gokei"]));
				DataFormatUtil.SetMustColorCaption(Nyukajisseki_su_gokei_lbl, base.GetPageContext().FormInfo["Nyukajisseki_su_gokei"]);
			ControlUtil.SetControlValue(Genka_kin_gokei_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Genka_kin_gokei", lang), base.GetPageContext().FormInfo["Genka_kin_gokei"]));
				DataFormatUtil.SetMustColorCaption(Genka_kin_gokei_lbl, base.GetPageContext().FormInfo["Genka_kin_gokei"]);
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
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1nyukayotei_su", lang), base.GetPageContext().FormInfo["M1nyukayotei_su"]);
				// M1.Columns[12].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1nyukajisseki_su", lang), base.GetPageContext().FormInfo["M1nyukajisseki_su"]);
				// M1.Columns[13].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1gen_tnk", lang), base.GetPageContext().FormInfo["M1gen_tnk"]);
				// M1.Columns[14].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1genka_kin", lang), base.GetPageContext().FormInfo["M1genka_kin"]);
				// M1.Columns[15].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1selectorcheckbox", lang), base.GetPageContext().FormInfo["M1selectorcheckbox"]);
				// M1.Columns[16].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1entersyoriflg", lang), base.GetPageContext().FormInfo["M1entersyoriflg"]);
				// M1.Columns[17].HeaderText = 
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
				Windowtitle.InnerText = formResource.GetString("Te130f02_Titlebar", lang);
				header.FormName = formResource.GetString("Te130f02_FormCaption", lang);
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
