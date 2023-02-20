using com.xebio.bo.Th010p01.Constant;
using com.xebio.bo.Th010p01.Facade;
using com.xebio.bo.Th010p01.Formvo;
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
using Common.Business.C99999.LabelUtil;
using Common.IntegrationMD.Util;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.UI.WebControls;

namespace com.xebio.bo.Th010p01.Page
{
  /// <summary>
  /// Th010f03のコードビハインドです。
  /// </summary>
  public partial class Th010f03Page : StandardBasePage
	{

		#region メソッド

		#region ページデータをロードするメソッド
		/// <summary>
		/// Th010f03画面データを作成する。
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
						pageContext.SetFormVO(new Th010f03Form());
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
								new Th010f03Facade().DoLoad(facadeContext);

								break;
						}
					}

					//アコーディオンを開いたた状態で表示
					AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_OPEN);

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

				if (pageContext != null)
				{
					string msg = BoSystemLabelUtil.GetScriptLabelPrint(pageContext, Th010p01Constant.PGID);
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

		#region フォームを呼び出します(ボタンID : Btnback(戻る))
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
				new Th010f03Facade().DoBTNBACK_FRM(facadeContext);
				
				
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
			
			// 戻り先ID設定
			string strBackID = (string)((Th010f03Form)pageContext.GetFormVO(Th010p01Constant.PGID, Th010p01Constant.FORMID_03)).Dictionary[Th010p01Constant.DIC_M1BACKID];
			// 戻り先自社品番
			string strJisyaHbn = (string)((Th010f03Form)pageContext.GetFormVO(Th010p01Constant.PGID, Th010p01Constant.FORMID_03)).Dictionary[Th010p01Constant.DIC_M1ID];

			// フォーカス変数設定
			if (!string.IsNullOrEmpty(strBackID))
			{
				pageContext.ButtonInfo.ActFormId = strBackID.ToString();
			}

			// 選択された自社品番／旧自社品番にフォーカス設定
			if (strJisyaHbn.Equals(Th010p01Constant.M1JISYA_HBN))
			{
				focusItem = "M1jisya_hbn";
			}
			else
			{
				focusItem = "M1old_jisya_hbn";
			}

			focusMno = (string)((Th010f03Form)pageContext.GetFormVO(Th010p01Constant.PGID, Th010p01Constant.FORMID_03)).Dictionary[Th010p01Constant.DIC_M1SELCETROWIDX];


			// フォーカス設定
			SetFocusCls.SetFocus(queryList, focusItem, focusMno);
			
			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNBACK_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Btnseal(シール発行))
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
				new Th010f03Facade().DoBTNSEAL_FRM(facadeContext);

				// ラベル発行機の値をクッキーに登録
				Th010f03Form f01VO = (Th010f03Form)facadeContext.FormVO;
				BoSystemLabelUtil.SetCookieLabel(pageContext.Response, f01VO);
				
				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
					base.SetError(pageContext);
					return;
				}

				// CSVファイル名を取得
				string csvNm = (string)facadeContext.GetUserObject(Th010p01Constant.FCDUO_SEAL_CSVFLNM);

				// シールレイアウト
				List<string> layout = (List<string>)facadeContext.GetUserObject(Th010p01Constant.FCDUO_SEAL_LAYOUTNM);

				// シール発行スクリプトの出力
				BoSystemLabelUtil.createScriptLabelPrint(pageContext, Th010p01Constant.PGID, layout, csvNm);
				
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

			// Cookieへの保存
			Th010f03Form f03VO = (Th010f03Form)pageContext.GetFormVO(Th010p01Constant.PGID, Th010p01Constant.FORMID_03);
			Response.Cookies["Label_cd"].Value = f03VO.Label_cd;

			//URLクエリ追加用NameValueCollection
			NameValueCollection queryList = new NameValueCollection();
			
			//フォーカスを当てる項目を指定したい場合はFormFocusUtilを使ってqueryListに追加すること
			
			// フォーカス設定用変数
			string focusItem = string.Empty;
			string focusMno = string.Empty;

			// [出力シール]が使用可能である場合
			IList<Hashtable> SealItemNm = (IList<Hashtable>)f03VO.Dictionary[Th010p01Constant.DIC_SYUTSURYOKU_SEAL];

			if (SealItemNm.Count > 1)
			{
				// [出力シール]にフォーカスを当てる
				focusItem = "Syutsuryoku_seal";
			}
			// [出力シール]が使用可能でない場合
			else
			{
				// ログイン情報
				LoginInfoVO loginInfVo = LoginInfoUtil.GetLoginInfo();
				if (CheckCompanyCls.IsXebio(loginInfVo.CopCd))
				{
					// [レイアウト]にフォーカスを当てる
					focusItem = "Layout";
				}
				else
				{
					// [Ｍ１枚数]にフォーカスを当てる
					focusItem = "M1maisu";
					focusMno = (0).ToString();
				}
			}

			// フォーカス設定
			SetFocusCls.SetFocus(queryList, focusItem, focusMno);
			
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
						Th010f03Form th010f03Form = (Th010f03Form)pageContext.GetFormVO();

						//明細ページ情報を表示する
						ShowListPageInfo(th010f03Form);
			
						//明細部データを表示する
						RenderList(th010f03Form, pageContext.FormInfo, formResource, lang);

						//カード部データを表示する
						RenderCard(th010f03Form, pageContext.FormInfo, formResource, lang);
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
		/// <param name="th010f03Form">画面FormVO</param>
		private void ShowListPageInfo(Th010f03Form th010f03Form)
		{
			//M1明細ページ情報を表示する。
			ShowM1ListPageInfo(th010f03Form.GetList("M1"));

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
		/// <param name="th010f03Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderList(
			Th010f03Form th010f03Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//画面のM1明細部データを設定する。
			RenderM1List(th010f03Form, formInfo, formResource, lang);
			
		}
		#endregion

		#region M1明細データを表示する
		/// <summary>
		/// M1明細データを表示する。
		/// </summary>
		/// <param name="th010f03Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderM1List(
			Th010f03Form th010f03Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//M1明細部データソースを設定する。
			M1.DataSource = th010f03Form.GetPageViewList("M1");
			M1.DataBind();

			//M1明細部データをフォーマットする。
			IList m1DataList = (IList)M1.DataSource;
			
			for (int index = 0; index < M1.Items.Count; index++)
			{
				Th010f03M1Form th010f03M1Form = (Th010f03M1Form)m1DataList[index];
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1rowno"),
					DataFormatUtil.GetFormatItem(th010f03M1Form.M1rowno,formInfo["M1rowno"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1iro_nm"),
					DataFormatUtil.GetFormatItem(th010f03M1Form.M1iro_nm,formInfo["M1iro_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1size_nm"),
					DataFormatUtil.GetFormatItem(th010f03M1Form.M1size_nm,formInfo["M1size_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1scan_cd"),
					DataFormatUtil.GetFormatItem(th010f03M1Form.M1scan_cd,formInfo["M1scan_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1maisu"),
					DataFormatUtil.GetFormatItem(th010f03M1Form.M1maisu,formInfo["M1maisu"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1selectorcheckbox"),
					DataFormatUtil.GetFormatItem(th010f03M1Form.M1selectorcheckbox,formInfo["M1selectorcheckbox"]));
				((System.Web.UI.WebControls.CheckBox)M1.Items[index].FindControl("M1selectorcheckbox")).Text =
					formResource.GetString("M1selectorcheckbox", lang);
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1entersyoriflg"),
					DataFormatUtil.GetFormatItem(th010f03M1Form.M1entersyoriflg,formInfo["M1entersyoriflg"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1dtlirokbn"),
					DataFormatUtil.GetFormatItem(th010f03M1Form.M1dtlirokbn,formInfo["M1dtlirokbn"]));

				if(!base.CheckUseSelfCustomize()){
					// 明細背景色の設定
					//DetailColorCls.DetailColorSet(M1, index);
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
				// (M1.HeaderRow.FindControl("M1iro_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1iro_nm", lang), base.GetPageContext().FormInfo["M1iro_nm"]);
				// (M1.HeaderRow.FindControl("M1size_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1size_nm", lang), base.GetPageContext().FormInfo["M1size_nm"]);
				// (M1.HeaderRow.FindControl("M1scan_cd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1scan_cd", lang), base.GetPageContext().FormInfo["M1scan_cd"]);
				// (M1.HeaderRow.FindControl("M1maisu") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1maisu", lang), base.GetPageContext().FormInfo["M1maisu"]);
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
		/// <param name="th010f03Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderCard(
			Th010f03Form th010f03Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			
			ControlUtil.SetControlValue(Head_tenpo_cd,
				DataFormatUtil.GetFormatItem(th010f03Form.Head_tenpo_cd,formInfo["Head_tenpo_cd"]));
			ControlUtil.SetControlValue(Head_tenpo_nm,
				DataFormatUtil.GetFormatItem(th010f03Form.Head_tenpo_nm,formInfo["Head_tenpo_nm"]));
			ControlUtil.SetControlValue(Stkmodeno,
				DataFormatUtil.GetFormatItem(th010f03Form.Stkmodeno,formInfo["Stkmodeno"]));
			ControlUtil.SetControlValue(Siiresaki_cd,
				DataFormatUtil.GetFormatItem(th010f03Form.Siiresaki_cd,formInfo["Siiresaki_cd"]));
			ControlUtil.SetControlValue(Siiresaki_ryaku_nm,
				DataFormatUtil.GetFormatItem(th010f03Form.Siiresaki_ryaku_nm,formInfo["Siiresaki_ryaku_nm"]));
			ControlUtil.SetControlValue(Bumon_cd,
				DataFormatUtil.GetFormatItem(th010f03Form.Bumon_cd,formInfo["Bumon_cd"]));
			ControlUtil.SetControlValue(Bumon_nm,
				DataFormatUtil.GetFormatItem(th010f03Form.Bumon_nm,formInfo["Bumon_nm"]));
			ControlUtil.SetControlValue(Hinsyu_cd,
				DataFormatUtil.GetFormatItem(th010f03Form.Hinsyu_cd,formInfo["Hinsyu_cd"]));
			ControlUtil.SetControlValue(Hinsyu_ryaku_nm,
				DataFormatUtil.GetFormatItem(th010f03Form.Hinsyu_ryaku_nm,formInfo["Hinsyu_ryaku_nm"]));
			ControlUtil.SetControlValue(Burando_cd,
				DataFormatUtil.GetFormatItem(th010f03Form.Burando_cd,formInfo["Burando_cd"]));
			ControlUtil.SetControlValue(Burando_nm,
				DataFormatUtil.GetFormatItem(th010f03Form.Burando_nm,formInfo["Burando_nm"]));
			ControlUtil.SetControlValue(Jisya_hbn,
				DataFormatUtil.GetFormatItem(th010f03Form.Jisya_hbn,formInfo["Jisya_hbn"]));
			
			// Ｍ１旧自社品番がALL0の場合括弧表示もなし
			//if (!th010f03Form.Old_jisya_hbn.Equals("0000000000"))
			//{ 
				ControlUtil.SetControlValue(Old_jisya_hbn,
					DataFormatUtil.GetFormatItem(th010f03Form.Old_jisya_hbn,formInfo["Old_jisya_hbn"]));
				//}

			ControlUtil.SetControlValue(Maker_hbn,
				DataFormatUtil.GetFormatItem(th010f03Form.Maker_hbn,formInfo["Maker_hbn"]));
			ControlUtil.SetControlValue(Syonmk,
				DataFormatUtil.GetFormatItem(th010f03Form.Syonmk,formInfo["Syonmk"]));
			ControlUtil.SetControlValue(Syohin_zokusei,
				DataFormatUtil.GetFormatItem(th010f03Form.Syohin_zokusei,formInfo["Syohin_zokusei"]));
			ControlUtil.SetControlValue(Hanbaikanryo_ymd,
				DataFormatUtil.GetFormatItem(th010f03Form.Hanbaikanryo_ymd,formInfo["Hanbaikanryo_ymd"]));
			ControlUtil.SetControlValue(Saisinbaika_tnk,
				DataFormatUtil.GetFormatItem(th010f03Form.Saisinbaika_tnk,formInfo["Saisinbaika_tnk"]));
			ControlUtil.SetControlValue(Genka,
				DataFormatUtil.GetFormatItem(th010f03Form.Genka,formInfo["Genka"]));
			ControlUtil.SetControlValue(Genbaika_tnk,
				DataFormatUtil.GetFormatItem(th010f03Form.Genbaika_tnk,formInfo["Genbaika_tnk"]));
			ControlUtil.SetControlValue(Makerkakaku_tnk,
				DataFormatUtil.GetFormatItem(th010f03Form.Makerkakaku_tnk,formInfo["Makerkakaku_tnk"]));
			ControlUtil.SetControlValue(Syutsuryoku_seal,
				DataFormatUtil.GetFormatItem(th010f03Form.Syutsuryoku_seal, formInfo["Syutsuryoku_seal"]));
			ControlUtil.SetControlValue(Layout,
				DataFormatUtil.GetFormatItem(th010f03Form.Layout,formInfo["Layout"]));

			// Cookieが存在する場合、保存したラベル発行機IDを設定、存在しない場合は空白
			if (Request.Cookies["Label_cd"] != null)
			{
				ControlUtil.SetControlValue(Label_cd, Request.Cookies["Label_cd"].Value);
			}
			else
			{
				ControlUtil.SetControlValue(Label_cd, string.Empty);
			}
			
			ControlUtil.SetControlValue(Label_ip,
				DataFormatUtil.GetFormatItem(th010f03Form.Label_ip,formInfo["Label_ip"]));
			ControlUtil.SetControlValue(Label_nm,
				DataFormatUtil.GetFormatItem(th010f03Form.Label_nm,formInfo["Label_nm"]));

			if(!base.CheckUseSelfCustomize()){
				Btnback.Value = base.FormResourceGetString(formResource, "Btnback", lang);
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

			// [出力シール]の名称を設定
			Th010f03Form f03VO = (Th010f03Form)base.GetPageContext().GetFormVO();
			IList<Hashtable> sealList = (IList<Hashtable>)f03VO.Dictionary[Th010p01Constant.DIC_SYUTSURYOKU_SEAL];
			if (Syutsuryoku_seal.Items.Count <= 0)
			{
				int iIndex = 0;
				foreach (Hashtable insSealItemNm in sealList)
				{
					Syutsuryoku_seal.Items.Insert(
						iIndex
						, new ListItem((string)sealList[iIndex]["TAX_HYOJIMONGON"], sealList[iIndex]["TAX_CD"].ToString())
					);
					iIndex++;
				}

				// 出力シール
				Syutsuryoku_seal.SelectedValue = sealList[0]["TAX_CD"].ToString();
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
			// UIScreenController controller = new UIScreenController((Th010f03Form)base.GetPageContext().GetFormVO());
			// controller.ChangeColumnsDisplayMode(M1 ,  new DetailHeaderFixedVO(M1Header , true) , null);

			/*
			 *登録した機能間連携処理を親画面に感知させる。
			 *機能有効させる場合は、コメントアウトを外してください。
			 */
			//DetailUtil.RunPgSyn(this,(StandardBaseForm)base.GetPageContext().GetFormVO());

			#region 画面表示制御
			Th010f03Form f03VO = (Th010f03Form)base.GetPageContext().GetFormVO();
			IList<Hashtable> sealList = (IList<Hashtable>)f03VO.Dictionary[Th010p01Constant.DIC_SYUTSURYOKU_SEAL];
			// 出力シール
			if (sealList.Count <= 1)
			{
				// 明細ボタンを非表示とする
				ControlCls.Visible(Syutsuryoku_seal_lbl, false);
				ControlCls.Visible(Syutsuryoku_seal, false);
			}
			else
			{
				// 明細ボタンを表示する
				ControlCls.Visible(Syutsuryoku_seal_lbl, true);
				ControlCls.Visible(Syutsuryoku_seal, true);
			}
			// レイアウト
			LoginInfoVO loginInfVo = LoginInfoUtil.GetLoginInfo();
			if (CheckCompanyCls.IsVictoria(loginInfVo.CopCd))
			{
				// 明細ボタンを非表示とする
				ControlCls.Visible(Layout_lbl, false);
				ControlCls.Visible(Layout, false);
			}
			else
			{
				// 明細ボタンを表示する
				ControlCls.Visible(Layout_lbl, true);
				ControlCls.Visible(Layout, true);
			}
			// 旧自社品番括弧
			Th010f03Form formVo = (Th010f03Form)base.GetPageContext().GetFormVO();
			if (formVo.Old_jisya_hbn.Equals("0000000000"))
			{
				// 旧自社品番括弧を非表示とする
				ControlCls.Visible(KakkoStr, false);
				ControlCls.Visible(KakkoEnd, false);
				Old_jisya_hbn.Visible = false;
			}
			else
			{
				// 旧自社品番括弧を表示する
				ControlCls.Visible(KakkoStr, true);
				ControlCls.Visible(KakkoEnd, true);
				Old_jisya_hbn.Visible = true;

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
			ControlUtil.SetControlValue(Hinsyu_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Hinsyu_cd", lang), base.GetPageContext().FormInfo["Hinsyu_cd"]));
				DataFormatUtil.SetMustColorCaption(Hinsyu_cd_lbl, base.GetPageContext().FormInfo["Hinsyu_cd"]);
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
			ControlUtil.SetControlValue(Old_jisya_hbn_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Old_jisya_hbn", lang), base.GetPageContext().FormInfo["Old_jisya_hbn"]));
				DataFormatUtil.SetMustColorCaption(Old_jisya_hbn_lbl, base.GetPageContext().FormInfo["Old_jisya_hbn"]);
			ControlUtil.SetControlValue(Maker_hbn_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Maker_hbn", lang), base.GetPageContext().FormInfo["Maker_hbn"]));
				DataFormatUtil.SetMustColorCaption(Maker_hbn_lbl, base.GetPageContext().FormInfo["Maker_hbn"]);
			ControlUtil.SetControlValue(Syonmk_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Syonmk", lang), base.GetPageContext().FormInfo["Syonmk"]));
				DataFormatUtil.SetMustColorCaption(Syonmk_lbl, base.GetPageContext().FormInfo["Syonmk"]);
			ControlUtil.SetControlValue(Syohin_zokusei_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Syohin_zokusei", lang), base.GetPageContext().FormInfo["Syohin_zokusei"]));
				DataFormatUtil.SetMustColorCaption(Syohin_zokusei_lbl, base.GetPageContext().FormInfo["Syohin_zokusei"]);
			ControlUtil.SetControlValue(Hanbaikanryo_ymd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Hanbaikanryo_ymd", lang), base.GetPageContext().FormInfo["Hanbaikanryo_ymd"]));
				DataFormatUtil.SetMustColorCaption(Hanbaikanryo_ymd_lbl, base.GetPageContext().FormInfo["Hanbaikanryo_ymd"]);
			ControlUtil.SetControlValue(Saisinbaika_tnk_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Saisinbaika_tnk", lang), base.GetPageContext().FormInfo["Saisinbaika_tnk"]));
				DataFormatUtil.SetMustColorCaption(Saisinbaika_tnk_lbl, base.GetPageContext().FormInfo["Saisinbaika_tnk"]);
			ControlUtil.SetControlValue(Genka_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Genka", lang), base.GetPageContext().FormInfo["Genka"]));
				DataFormatUtil.SetMustColorCaption(Genka_lbl, base.GetPageContext().FormInfo["Genka"]);
			ControlUtil.SetControlValue(Genbaika_tnk_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Genbaika_tnk", lang), base.GetPageContext().FormInfo["Genbaika_tnk"]));
				DataFormatUtil.SetMustColorCaption(Genbaika_tnk_lbl, base.GetPageContext().FormInfo["Genbaika_tnk"]);
			ControlUtil.SetControlValue(Makerkakaku_tnk_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Makerkakaku_tnk", lang), base.GetPageContext().FormInfo["Makerkakaku_tnk"]));
				DataFormatUtil.SetMustColorCaption(Makerkakaku_tnk_lbl, base.GetPageContext().FormInfo["Makerkakaku_tnk"]);
				ControlUtil.SetControlValue(Syutsuryoku_seal_lbl,
				DataFormatUtil.GetFormatCaption(formResource.GetString("Syutsuryoku_seal", lang), base.GetPageContext().FormInfo["Syutsuryoku_seal"]));
				DataFormatUtil.SetMustColorCaption(Syutsuryoku_seal_lbl, base.GetPageContext().FormInfo["Syutsuryoku_seal"]);
			ControlUtil.SetControlValue(Layout_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Layout", lang), base.GetPageContext().FormInfo["Layout"]));
				DataFormatUtil.SetMustColorCaption(Layout_lbl, base.GetPageContext().FormInfo["Layout"]);
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
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1iro_nm", lang), base.GetPageContext().FormInfo["M1iro_nm"]);
				// M1.Columns[2].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1size_nm", lang), base.GetPageContext().FormInfo["M1size_nm"]);
				// M1.Columns[3].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1scan_cd", lang), base.GetPageContext().FormInfo["M1scan_cd"]);
				// M1.Columns[4].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1maisu", lang), base.GetPageContext().FormInfo["M1maisu"]);
				// M1.Columns[5].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1selectorcheckbox", lang), base.GetPageContext().FormInfo["M1selectorcheckbox"]);
				// M1.Columns[6].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1entersyoriflg", lang), base.GetPageContext().FormInfo["M1entersyoriflg"]);
				// M1.Columns[7].HeaderText = 
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
				Windowtitle.InnerText = formResource.GetString("Th010f03_Titlebar", lang);
				header.FormName = formResource.GetString("Th010f03_FormCaption", lang);
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
