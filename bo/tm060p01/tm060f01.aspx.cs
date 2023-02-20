using com.xebio.bo.Tm060p01.Facade;
using com.xebio.bo.Tm060p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.Model.Context;
using Common.Advanced.Resource;
using Common.Advanced.Web.Context;
using Common.Advanced.Web.Util;
using Common.Business.C01000.C01013;
using Common.Business.C01000.C01014;
using Common.Business.C01000.C01015;
using Common.Business.C01000.C01016;
using Common.Business.C99999.Constant;
using Common.IntegrationMD.Util;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Util;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Tm060p01.Page
{
  /// <summary>
  /// Tm060f01のコードビハインドです。
  /// </summary>
  public partial class Tm060f01Page : StandardBasePage
	{

		#region メソッド

		#region ページデータをロードするメソッド
		/// <summary>
		/// Tm060f01画面データを作成する。
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
						pageContext.SetFormVO(new Tm060f01Form());
						switch (commandInfo.ActionMode)
						{
							case "ADD":
								break;
							case "INI":	// メニューから遷移時
							case "DEL":
							case "UPD":
								IFacadeContext facadeContext =
									FacadeContextFactory.GetFacadeContext(pageContext);
								InitFacadeContext(facadeContext);
								new Tm060f01Facade().DoLoad(facadeContext);
								#region 共通ヘッダ処理

								// 一覧画面共通処理 ----------
								LoginInfoVO loginInfVO = LoginInfoUtil.GetLoginInfo();
								Tm060f01Form te130f01Form = (Tm060f01Form)facadeContext.FormVO;
								ControlHeaderStoreCls.InitialSetHeaderStore<Tm060f01Form>(loginInfVO, te130f01Form);
								// 一覧画面共通処理 ----------
								#endregion
								// アコーディオンなし
								AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_NONE);
								break;
						}
					}
				}
				else
				{
					//メッセージの初期化
					base.InitMessage();
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
			IPageContext pageContext = null;
			//入力チェックに失敗した場合、何も処理せずに返します
			if (!base.DoValidate(sender))
			{
				//クライアントチェックエラー時、画面描画する
				SetItems();
				SetAttribute();
				//アクションコンテキストを取得する
				pageContext = base.GetPageContext();
				// 明細初期化処理
				Page.ClientScript.RegisterStartupScript(typeof(string), "InitialDetail", ControlCls.InitialDetail(pageContext));
				return;
			}

			//アクションコンテキストを取得する
			pageContext = base.GetPageContext();
			ICommandInfo commandInfo = pageContext.CommandInfo;

			try
			{
				//アクションロジックを処理します
				IFacadeContext facadeContext = FacadeContextFactory.GetFacadeContext(pageContext);
				InitFacadeContext(facadeContext);
				new Tm060f01Facade().DoBTNSEARCH_FRM(facadeContext);

				//エラー判定
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					// アコーディオンなし
					AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_NONE);
					commandInfo.ActionMode = "INI";
					base.SetError(pageContext);
					return;
				}
				//アコーディオンを閉じた状態で表示
				AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_CLOSE);

				//アコーディオンを閉じた際に表示される検索条件を設定する。
				AccordionUtil.ResetSearchCondition(pageContext);
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
			//フォーカス設定用変数
			string focusItem = string.Empty;
			string focusMno = string.Empty;
			// 表示明細先頭の伝票番号設定
			focusItem = "M1kengen_kb";
			focusMno = 0.ToString();
			// フォーカス設定
			SetFocusCls.SetFocus(queryList, focusItem, focusMno);

			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNSEARCH_FRM");

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
				new Tm060f01Facade().DoPGR_PGN(facadeContext, pageindex);

				//エラー判定
				if (MessageDisplayUtil.HasError(facadeContext))
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
				new Tm060f01Facade().DoBTNENTER_FRM(facadeContext);

				//エラー判定
				if (MessageDisplayUtil.HasError(facadeContext))
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
				commandInfo.PageLoadMode = true;

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
			if (!base.IsPostBack || base.IsPageValid)
			{
				//ページコンテキストを取得する
				IPageContext pageContext = base.GetPageContext();
				if (pageContext != null && pageContext.GetFormVO() != null)
				{
					string lang = WebSettingsUtil.GetLangSettingFromSession(pageContext.Session);
					FormResource formResource =
					ResourceFactory.GetFormResource(pageContext.CommandInfo.FormId);

					//標題をセットする
					SetCaption(formResource, lang);

					//FormVOを取得する
					Tm060f01Form tm060f01Form = (Tm060f01Form)pageContext.GetFormVO();

					//明細ページ情報を表示する
					ShowListPageInfo(tm060f01Form);

					//明細部データを表示する
					RenderList(tm060f01Form, pageContext.FormInfo, formResource, lang);

					//カード部データを表示する
					RenderCard(tm060f01Form, pageContext.FormInfo, formResource, lang);

					//共通フォームデータ表示処理
					base.DoCommonRenderForm();
				}
			}
		}
		#endregion

		#region 明細ページ情報(全体)を表示する
		#region 明細ページ情報を表示する
		/// <summary>
		/// 明細ページ情報を表示する。
		/// </summary>
		/// <param name="tm060f01Form">画面FormVO</param>
		private void ShowListPageInfo(Tm060f01Form tm060f01Form)
		{
			//M1明細ページ情報を表示する。
			ShowM1ListPageInfo(tm060f01Form.GetList("M1"));

		}
		#endregion

		#region M1明細ページ情報を表示する
		/// <summary>
		/// M1明細ページ情報を表示する。
		/// </summary>
		/// <param name="m1List">明細リスト</param>
		private void ShowM1ListPageInfo(IDataList m1List)
		{
			if (m1List == null)
			{
				return;
			}

			int startRow = m1List.StartRow;
			int endRow = m1List.EndRow;
			int recordCount = m1List.RecordCount;
			int dispRow = m1List.DispRow;

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
			if (endRow < recordCount && recordCount != 0)
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

		#region 明細部データ(全体)を表示する
		#region 明細部データを表示する
		/// <summary>
		/// 明細部データを表示する。
		/// </summary>
		/// <param name="tm060f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderList(
			Tm060f01Form tm060f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//画面のM1明細部データを設定する。
			RenderM1List(tm060f01Form, formInfo, formResource, lang);
			//M1明細部のページャーにページ情報を設定する。
			RenderM1Pager(tm060f01Form);

		}
		#endregion

		#region M1明細データを表示する
		/// <summary>
		/// M1明細データを表示する。
		/// </summary>
		/// <param name="tm060f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderM1List(
			Tm060f01Form tm060f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//M1明細部データソースを設定する。
			M1.DataSource = tm060f01Form.GetPageViewList("M1");
			M1.DataBind();

			//M1明細部データをフォーマットする。
			IList m1DataList = (IList)M1.DataSource;

			for (int index = 0; index < M1.Items.Count; index++)
			{
				Tm060f01M1Form tm060f01M1Form = (Tm060f01M1Form)m1DataList[index];
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1rowno"),
					DataFormatUtil.GetFormatItem(tm060f01M1Form.M1rowno, formInfo["M1rowno"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1tantosya_cd"),
					DataFormatUtil.GetFormatItem(tm060f01M1Form.M1tantosya_cd, formInfo["M1tantosya_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1hanbaiin_nm"),
					DataFormatUtil.GetFormatItem(tm060f01M1Form.M1hanbaiin_nm, formInfo["M1hanbaiin_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1syokusei_kb_nm"),
					DataFormatUtil.GetFormatItem(tm060f01M1Form.M1syokusei_kb_nm, formInfo["M1syokusei_kb_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1kengen_kb"),
					DataFormatUtil.GetFormatItem(tm060f01M1Form.M1kengen_kb, formInfo["M1kengen_kb"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1passwardsyokika"),
					DataFormatUtil.GetFormatItem(tm060f01M1Form.M1passwardsyokika, formInfo["M1passwardsyokika"]));
				((System.Web.UI.WebControls.CheckBox)M1.Items[index].FindControl("M1passwardsyokika")).Text =
					string.Empty;
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1selectorcheckbox"),
					DataFormatUtil.GetFormatItem(tm060f01M1Form.M1selectorcheckbox, formInfo["M1selectorcheckbox"]));
				((System.Web.UI.WebControls.CheckBox)M1.Items[index].FindControl("M1selectorcheckbox")).Text =
					formResource.GetString("M1selectorcheckbox", lang);
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1entersyoriflg"),
					DataFormatUtil.GetFormatItem(tm060f01M1Form.M1entersyoriflg, formInfo["M1entersyoriflg"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1dtlirokbn"),
					DataFormatUtil.GetFormatItem(tm060f01M1Form.M1dtlirokbn, formInfo["M1dtlirokbn"]));

				if (!base.CheckUseSelfCustomize())
				{
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
			// (M1.HeaderRow.FindControl("M1tantosya_cd") as Label).Text = 
			// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tantosya_cd", lang), base.GetPageContext().FormInfo["M1tantosya_cd"]);
			// (M1.HeaderRow.FindControl("M1hanbaiin_nm") as Label).Text = 
			// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hanbaiin_nm", lang), base.GetPageContext().FormInfo["M1hanbaiin_nm"]);
			// (M1.HeaderRow.FindControl("M1syokusei_kb_nm") as Label).Text = 
			// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syokusei_kb_nm", lang), base.GetPageContext().FormInfo["M1syokusei_kb_nm"]);
			// (M1.HeaderRow.FindControl("M1kengen_kb") as Label).Text = 
			// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kengen_kb", lang), base.GetPageContext().FormInfo["M1kengen_kb"]);
			// (M1.HeaderRow.FindControl("M1passwardsyokika") as Label).Text = 
			// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1passwardsyokika", lang), base.GetPageContext().FormInfo["M1passwardsyokika"]);
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
		/// <param name="tm060f01Form">画面FormVO</param>
		private void RenderM1Pager(Tm060f01Form tm060f01Form)
		{
			Pgr.VirtualItemCount = tm060f01Form.GetList("M1").RecordCount;
			Pgr.CurrentPageIndex = tm060f01Form.GetList("M1").PageNo - 1;
			Pgr.PageSize = tm060f01Form.GetList("M1").DispRow;
		}
		#endregion
		#endregion

		#region カードデータを表示する
		/// <summary>
		/// カードデータを表示する
		/// </summary>
		/// <param name="tm060f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderCard(
			Tm060f01Form tm060f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{

			ControlUtil.SetControlValue(Head_tenpo_cd,
				DataFormatUtil.GetFormatItem(tm060f01Form.Head_tenpo_cd, formInfo["Head_tenpo_cd"]));
			ControlUtil.SetControlValue(Head_tenpo_nm,
				DataFormatUtil.GetFormatItem(tm060f01Form.Head_tenpo_nm, formInfo["Head_tenpo_nm"]));
			ControlUtil.SetControlValue(Tantosya_cd_from,
				DataFormatUtil.GetFormatItem(tm060f01Form.Tantosya_cd_from, formInfo["Tantosya_cd_from"]));
			ControlUtil.SetControlValue(Hanbaiin_nm_from,
				DataFormatUtil.GetFormatItem(tm060f01Form.Hanbaiin_nm_from, formInfo["Hanbaiin_nm_from"]));
			ControlUtil.SetControlValue(Tantosya_cd_to,
				DataFormatUtil.GetFormatItem(tm060f01Form.Tantosya_cd_to, formInfo["Tantosya_cd_to"]));
			ControlUtil.SetControlValue(Hanbaiin_nm_to,
				DataFormatUtil.GetFormatItem(tm060f01Form.Hanbaiin_nm_to, formInfo["Hanbaiin_nm_to"]));
			ControlUtil.SetControlValue(Syokusei_kb,
				DataFormatUtil.GetFormatItem(tm060f01Form.Syokusei_kb, formInfo["Syokusei_kb"]));
			ControlUtil.SetControlValue(Searchcnt,
				DataFormatUtil.GetFormatItem(tm060f01Form.Searchcnt, formInfo["Searchcnt"]));
			ControlUtil.SetControlValue(Kengen_kb,
				DataFormatUtil.GetFormatItem(tm060f01Form.Kengen_kb, formInfo["Kengen_kb"]));

			if (!base.CheckUseSelfCustomize())
			{
				Btnheadtenpocd.Value = base.FormResourceGetString(formResource, "Btnheadtenpocd", lang);
				Btntanto_cd_from.Value = base.FormResourceGetString(formResource, "Btntanto_cd_from", lang);
				Btntanto_cd_to.Value = base.FormResourceGetString(formResource, "Btntanto_cd_to", lang);
				Btnsearch.Value = base.FormResourceGetString(formResource, "Btnsearch", lang);
				Pgr.Text = base.FormResourceGetString(formResource, "Pgr", lang);
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
			if (!IsPostBack)
			{
				// 伝票状態に空白を追加
				Syokusei_kb.Items.Insert(0, new ListItem("", BoSystemConstant.DROPDOWNLIST_MISENTAKU));
				// 伝票状態に空白を追加
				Kengen_kb.Items.Insert(0, new ListItem("", BoSystemConstant.DROPDOWNLIST_MISENTAKU));
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
			// UIScreenController controller = new UIScreenController((Tm060f01Form)base.GetPageContext().GetFormVO());
			// controller.ChangeColumnsDisplayMode(M1 ,  new DetailHeaderFixedVO(M1Header , true) , null);

			/*
			 *登録した機能間連携処理を親画面に感知させる。
			 *機能有効させる場合は、コメントアウトを外してください。
			 */
			//DetailUtil.RunPgSyn(this,(StandardBaseForm)base.GetPageContext().GetFormVO());
			#region 共通ヘッダ表示制御
			LoginInfoVO loginInfVO = LoginInfoUtil.GetLoginInfo();
			ControlHeaderStoreCls.ControlSetHeaderStore(loginInfVO, Head_tenpo_cd, Btnheadtenpocd);
			#endregion

			#region 画面表示制御
			// ログイン情報取得
			LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();
			if (base.GetPageContext().CommandInfo.ActionMode.Equals("INI"))
			{
				// 明細ボタン部を非表示とする
				ControlCls.Visible(meisaiBtnArea, false);
				// フッター部を非表示とする
				ControlCls.Visible(footerBtnArea, false);

			}
			else
			{
				// 明細ボタン部を表示する
				ControlCls.Visible(meisaiBtnArea, true);
				// フッター部を表示する
				ControlCls.Visible(footerBtnArea, true);
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
			if (!base.CheckUseSelfCustomize())
			{
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
			ControlUtil.SetControlValue(Tantosya_cd_from_lbl, "担当者");
			DataFormatUtil.SetMustColorCaption(Tantosya_cd_from_lbl, base.GetPageContext().FormInfo["Tantosya_cd_from"]);
			ControlUtil.SetControlValue(Hanbaiin_nm_from_lbl,
				DataFormatUtil.GetFormatCaption(formResource.GetString("Hanbaiin_nm_from", lang), base.GetPageContext().FormInfo["Hanbaiin_nm_from"]));
			DataFormatUtil.SetMustColorCaption(Hanbaiin_nm_from_lbl, base.GetPageContext().FormInfo["Hanbaiin_nm_from"]);
			ControlUtil.SetControlValue(Tantosya_cd_to_lbl,
				DataFormatUtil.GetFormatCaption(formResource.GetString("Tantosya_cd_to", lang), base.GetPageContext().FormInfo["Tantosya_cd_to"]));
			DataFormatUtil.SetMustColorCaption(Tantosya_cd_to_lbl, base.GetPageContext().FormInfo["Tantosya_cd_to"]);
			ControlUtil.SetControlValue(Hanbaiin_nm_to_lbl,
				DataFormatUtil.GetFormatCaption(formResource.GetString("Hanbaiin_nm_to", lang), base.GetPageContext().FormInfo["Hanbaiin_nm_to"]));
			DataFormatUtil.SetMustColorCaption(Hanbaiin_nm_to_lbl, base.GetPageContext().FormInfo["Hanbaiin_nm_to"]);
			ControlUtil.SetControlValue(Syokusei_kb_lbl,
				DataFormatUtil.GetFormatCaption(formResource.GetString("Syokusei_kb", lang), base.GetPageContext().FormInfo["Syokusei_kb"]));
			DataFormatUtil.SetMustColorCaption(Syokusei_kb_lbl, base.GetPageContext().FormInfo["Syokusei_kb"]);
			ControlUtil.SetControlValue(Searchcnt_lbl,
				DataFormatUtil.GetFormatCaption(formResource.GetString("Searchcnt", lang), base.GetPageContext().FormInfo["Searchcnt"]));
			DataFormatUtil.SetMustColorCaption(Searchcnt_lbl, base.GetPageContext().FormInfo["Searchcnt"]);
			ControlUtil.SetControlValue(Kengen_kb_lbl,
				DataFormatUtil.GetFormatCaption(formResource.GetString("Kengen_kb", lang), base.GetPageContext().FormInfo["Kengen_kb"]));
			DataFormatUtil.SetMustColorCaption(Kengen_kb_lbl, base.GetPageContext().FormInfo["Kengen_kb"]);
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
			if (!base.CheckUseSelfCustomize())
			{
				// 多段明細を有効にするため、コメントアウトする。
				// M1.Columns[0].HeaderText = 
				// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1rowno", lang), base.GetPageContext().FormInfo["M1rowno"]);
				// M1.Columns[1].HeaderText = 
				// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1tantosya_cd", lang), base.GetPageContext().FormInfo["M1tantosya_cd"]);
				// M1.Columns[2].HeaderText = 
				// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hanbaiin_nm", lang), base.GetPageContext().FormInfo["M1hanbaiin_nm"]);
				// M1.Columns[3].HeaderText = 
				// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syokusei_kb_nm", lang), base.GetPageContext().FormInfo["M1syokusei_kb_nm"]);
				// M1.Columns[4].HeaderText = 
				// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1kengen_kb", lang), base.GetPageContext().FormInfo["M1kengen_kb"]);
				// M1.Columns[5].HeaderText = 
				// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1passwardsyokika", lang), base.GetPageContext().FormInfo["M1passwardsyokika"]);
				// M1.Columns[6].HeaderText = 
				// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1selectorcheckbox", lang), base.GetPageContext().FormInfo["M1selectorcheckbox"]);
				// M1.Columns[7].HeaderText = 
				// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1entersyoriflg", lang), base.GetPageContext().FormInfo["M1entersyoriflg"]);
				// M1.Columns[8].HeaderText = 
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
				Windowtitle.InnerText = formResource.GetString("Tm060f01_Titlebar", lang);
				header.FormName = formResource.GetString("Tm060f01_FormCaption", lang);
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
