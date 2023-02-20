using com.xebio.bo.Td010p01.Constant;
using com.xebio.bo.Td010p01.Facade;
using com.xebio.bo.Td010p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.Model.Context;
using Common.Advanced.Resource;
using Common.Advanced.Web.Context;
using Common.Advanced.Web.Util;
using Common.Business.C01000.C01014;
using Common.Business.C01000.C01015;
using Common.Business.C01000.C01016;
using Common.Business.C99999.Constant;
using Common.Business.C99999.StringUtil;
using Common.IntegrationMD.MDControl;
using Common.IntegrationMD.Util;
using Common.Standard.Base;
using Common.Standard.Message;
using Common.Standard.Util;
using System;
using System.Collections;
using System.Collections.Specialized;

namespace com.xebio.bo.Td010p01.Page
{
  /// <summary>
  /// Td010f02のコードビハインドです。
  /// </summary>
  public partial class Td010f02Page : StandardBasePage
	{

		#region メソッド

		#region ページデータをロードするメソッド
		/// <summary>
		/// Td010f02画面データを作成する。
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
						pageContext.SetFormVO(new Td010f02Form());
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
								new Td010f02Facade().DoLoad(facadeContext);

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

			// フォーカス設定用変数
			string focusItem = string.Empty;
			string focusMno = string.Empty;

			try
			{

				//アクションロジックを処理します
				IFacadeContext facadeContext = FacadeContextFactory.GetFacadeContext(pageContext);
				InitFacadeContext(facadeContext);
				new Td010f02Facade().DoBTNBACK_FRM(facadeContext);

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
			Td010f02Form f02VO = (Td010f02Form)pageContext.GetFormVO(Td010p01Constant.PGID, Td010p01Constant.FORMID_02);
			IDataList m1List = f02VO.GetList("M1");

			// 一覧画面選択行のVO
			Td010f01M1Form f01M1Form = (Td010f01M1Form)f02VO.Dictionary[Td010p01Constant.DIC_M1SELCETVO];

			// 選択された管理Noにフォーカス設定
			if (string.IsNullOrEmpty(f01M1Form.Dictionary[Td010p01Constant.DIC_M1DENPYO_BANGO].ToString()))
			{
				focusItem = "M1kanri_no";
			}
			else
			{
				focusItem = "M1denpyo_bango";
			}

			// 1行目にフォーカス設定
			focusMno = (string)((Td010f02Form) pageContext.GetFormVO(Td010p01Constant.PGID, Td010p01Constant.FORMID_02)).Dictionary[Td010p01Constant.DIC_M1SELCETROWIDX];

			// フォーカス設定
			SetFocusCls.SetFocus(queryList, focusItem, focusMno);

			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNBACK_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region M1明細の行を増やします(ボタンID : Btnrowins(行追加))
		/// <summary>
		/// M1明細の行を増やします。
		/// ボタンID(Btnrowins(行追加))
		/// アクションID(MADD)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnBTNROWINS_MADD(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnBTNROWINS_MADD");
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

				// 一覧画面のフォームVOをファサードに設定
				FormVOManager fvm = new FormVOManager(Session);
				new Td010f02Facade().DoBTNROWINS_MADD(facadeContext);
				
				
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

			// フォーカス設定用変数
			string focusItem = string.Empty;
			string focusMno = string.Empty;

			// 追加行にフォーカス設定
			focusItem = "M1scan_cd";
			// ■仮対応 明細が-2
			Td010f02Form f02VO = (Td010f02Form)pageContext.GetFormVO(Td010p01Constant.PGID, Td010p01Constant.FORMID_02);
			IDataList list = f02VO.GetList("M1");
			//focusMno = (list.Count - 1 - 2).ToString();
			focusMno = (list.Count - 1).ToString();

			// フォーカス設定
			SetFocusCls.SetFocus(queryList, focusItem, focusMno);

			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNROWINS_MADD");
			
			//画面遷移
			base.Forward(pageContext, queryList);
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : Btnrowdel(行削除))
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnrowdel(行削除))
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnBTNROWDEL_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnBTNROWDEL_FRM");
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

			// 行削除最終行
			decimal lastRow = 0;

			try
			{

				//アクションロジックを処理します
				IFacadeContext facadeContext = FacadeContextFactory.GetFacadeContext(pageContext);
				InitFacadeContext(facadeContext);
				new Td010f02Facade().DoBTNROWDEL_FRM(facadeContext);
				
				
				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
					base.SetError(pageContext);
					return;
				}

				// フォーカス行をコードビハインドに戻す
				lastRow = (decimal) facadeContext.GetUserObject(Td010p01Constant.FCDUO_FOCUSROW);

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

			// 削除行の次の行にフォーカス設定
			focusItem = "M1scan_cd";
			// ■仮対応 明細が-2
			//focusMno = (lastRow - 2).ToString();
			focusMno = (lastRow).ToString();

			// フォーカス設定
			SetFocusCls.SetFocus(queryList, focusItem, focusMno);
			
			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNROWDEL_FRM");
			
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

			// フォーカス設定用変数
			string focusItem = string.Empty;
			string focusMno = string.Empty;

			try
			{

				//アクションロジックを処理します
				IFacadeContext facadeContext = FacadeContextFactory.GetFacadeContext(pageContext);
				InitFacadeContext(facadeContext);
				new Td010f02Facade().DoBTNENTER_FRM(facadeContext);


				// 一覧画面VO
				FormVOManager fvm = new FormVOManager(Session);
				Td010f01Form f01VO = (Td010f01Form)fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Td010p01Constant.FORMID_01);
				// 明細画面VO
				Td010f02Form f02VO = (Td010f02Form)facadeContext.FormVO;
				
				IDataList m1List = f01VO.GetList("M1");
				// 選択行の情報を設定する。
				// ■仮対応 選択行が-2されている
				//m1List.GetPageViewList()[facadeContext.CommandInfo.ListIndex] = (Td010f01M1Form)f02VO.Dictionary[Td010p01Constant.DIC_M1SELCETVO];
				m1List.GetPageViewList()[Convert.ToInt32(f02VO.Dictionary[Td010p01Constant.DIC_M1SELCETROWIDX])] = (Td010f01M1Form)f02VO.Dictionary[Td010p01Constant.DIC_M1SELCETVO];
				//m1List.GetPageViewList()[facadeContext.CommandInfo.ListIndex + 2] = (Td010f01M1Form)f02VO.Dictionary[Td010p01Constant.DIC_M1SELCETVO];

				// 次画面のフォームビーンを設定
				fvm.SetFormVO(Td010p01Constant.PGID, Td010p01Constant.FORMID_01, f01VO);
				
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

				// 選択された管理Noにフォーカス設定
				Td010f01M1Form f01M1Form = (Td010f01M1Form)f02VO.Dictionary[Td010p01Constant.DIC_M1SELCETVO];

				if (string.IsNullOrEmpty(f01M1Form.Dictionary[Td010p01Constant.DIC_M1DENPYO_BANGO].ToString()))
				{
					focusItem = "M1kanri_no";
				}
				else
				{
					focusItem = "M1denpyo_bango";
				}

			}
			catch (System.Exception ex)
			{
				ThrowException(ex, pageContext);
				return;
			}
			
			//URLクエリ追加用NameValueCollection
			NameValueCollection queryList = new NameValueCollection();
			
			//フォーカスを当てる項目を指定したい場合はFormFocusUtilを使ってqueryListに追加すること


			focusMno = (string)((Td010f02Form)pageContext.GetFormVO(Td010p01Constant.PGID, Td010p01Constant.FORMID_02)).Dictionary[Td010p01Constant.DIC_M1SELCETROWIDX];

			// フォーカス設定
			SetFocusCls.SetFocus(queryList, focusItem, focusMno);

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
					if (!MessageDisplayUtil.HasError(pageContext))
					{
						string lang = WebSettingsUtil.GetLangSettingFromSession(pageContext.Session);
						FormResource formResource =
							ResourceFactory.GetFormResource(pageContext.CommandInfo.FormId);
			
						//標題をセットする
						SetCaption(formResource, lang);

						//FormVOを取得する
						Td010f02Form td010f02Form = (Td010f02Form)pageContext.GetFormVO();

						//明細ページ情報を表示する
						ShowListPageInfo(td010f02Form);
			
						//明細部データを表示する
						RenderList(td010f02Form, pageContext.FormInfo, formResource, lang);

						//カード部データを表示する
						RenderCard(td010f02Form, pageContext.FormInfo, formResource, lang);
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
		/// <param name="td010f02Form">画面FormVO</param>
		private void ShowListPageInfo(Td010f02Form td010f02Form)
		{
			//M1明細ページ情報を表示する。
			ShowM1ListPageInfo(td010f02Form.GetList("M1"));

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
		/// <param name="td010f02Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderList(
			Td010f02Form td010f02Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//画面のM1明細部データを設定する。
			RenderM1List(td010f02Form, formInfo, formResource, lang);
			
		}
		#endregion

		#region M1明細データを表示する
		/// <summary>
		/// M1明細データを表示する。
		/// </summary>
		/// <param name="td010f02Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderM1List(
			Td010f02Form td010f02Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//M1明細部データソースを設定する。
			M1.DataSource = td010f02Form.GetPageViewList("M1");
			M1.DataBind();

			//M1明細部データをフォーマットする。
			IList m1DataList = (IList)M1.DataSource;
			
			for (int index = 0; index < M1.Items.Count; index++)
			{
				Td010f02M1Form td010f02M1Form = (Td010f02M1Form)m1DataList[index];
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1rowno"),
					DataFormatUtil.GetFormatItem(td010f02M1Form.M1rowno,formInfo["M1rowno"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1hinsyu_ryaku_nm"),
					DataFormatUtil.GetFormatItem(td010f02M1Form.M1hinsyu_ryaku_nm,formInfo["M1hinsyu_ryaku_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1jisya_hbn"),
					DataFormatUtil.GetFormatItem(td010f02M1Form.M1jisya_hbn,formInfo["M1jisya_hbn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1maker_hbn"),
					DataFormatUtil.GetFormatItem(td010f02M1Form.M1maker_hbn,formInfo["M1maker_hbn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1syonmk"),
					DataFormatUtil.GetFormatItem(td010f02M1Form.M1syonmk,formInfo["M1syonmk"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1iro_nm"),
					DataFormatUtil.GetFormatItem(td010f02M1Form.M1iro_nm,formInfo["M1iro_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1size_nm"),
					DataFormatUtil.GetFormatItem(td010f02M1Form.M1size_nm,formInfo["M1size_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1scan_cd"),
					DataFormatUtil.GetFormatItem(td010f02M1Form.M1scan_cd,formInfo["M1scan_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1suryo"),
					DataFormatUtil.GetFormatItem(td010f02M1Form.M1suryo,formInfo["M1suryo"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1gen_tnk"),
					DataFormatUtil.GetFormatItem(td010f02M1Form.M1gen_tnk,formInfo["M1gen_tnk"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1genkakin"),
					DataFormatUtil.GetFormatItem(td010f02M1Form.M1genkakin, formInfo["M1genkakin"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1suryo_hdn"),
					DataFormatUtil.GetFormatItem(td010f02M1Form.M1suryo_hdn, formInfo["M1suryo_hdn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1genkakin_hdn"),
					DataFormatUtil.GetFormatItem(td010f02M1Form.M1genkakin_hdn, formInfo["M1genkakin_hdn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1selectorcheckbox"),
					DataFormatUtil.GetFormatItem(td010f02M1Form.M1selectorcheckbox, formInfo["M1selectorcheckbox"]));
				((System.Web.UI.WebControls.CheckBox)M1.Items[index].FindControl("M1selectorcheckbox")).Text =
					formResource.GetString("M1selectorcheckbox", lang);
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1entersyoriflg"),
					DataFormatUtil.GetFormatItem(td010f02M1Form.M1entersyoriflg,formInfo["M1entersyoriflg"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1dtlirokbn"),
					DataFormatUtil.GetFormatItem(td010f02M1Form.M1dtlirokbn,formInfo["M1dtlirokbn"]));

				if (!base.CheckUseSelfCustomize())
				{
					//((HtmlGenericControl)M1.Items[index].FindControl("M1Row")).Attributes.Remove("class");
					//((HtmlGenericControl)M1.Items[index].FindControl("M1Row")).Attributes.Add("class", "str-result-item-01 js-search");
					
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
				// (M1.HeaderRow.FindControl("M1suryo") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo", lang), base.GetPageContext().FormInfo["M1suryo"]);
				// (M1.HeaderRow.FindControl("M1gen_tnk") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1gen_tnk", lang), base.GetPageContext().FormInfo["M1gen_tnk"]);
				// (M1.HeaderRow.FindControl("M1genkakin") as Label).Text = 
				// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1genkakin", lang), base.GetPageContext().FormInfo["M1genkakin"]);
				// (M1.HeaderRow.FindControl("M1suryo_hdn") as Label).Text = 
				// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo_hdn", lang), base.GetPageContext().FormInfo["M1suryo_hdn"]);
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
		/// <param name="td010f02Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderCard(
			Td010f02Form td010f02Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			
			ControlUtil.SetControlValue(Head_tenpo_cd,
				DataFormatUtil.GetFormatItem(td010f02Form.Head_tenpo_cd,formInfo["Head_tenpo_cd"]));
			ControlUtil.SetControlValue(Head_tenpo_nm,
				DataFormatUtil.GetFormatItem(td010f02Form.Head_tenpo_nm,formInfo["Head_tenpo_nm"]));
			ControlUtil.SetControlValue(Stkmodeno,
				DataFormatUtil.GetFormatItem(td010f02Form.Stkmodeno,formInfo["Stkmodeno"]));
			ControlUtil.SetControlValue(Siji_bango,
				DataFormatUtil.GetFormatItem(td010f02Form.Siji_bango,formInfo["Siji_bango"]));
			ControlUtil.SetControlValue(Kanri_no,
				DataFormatUtil.GetFormatItem(td010f02Form.Kanri_no,formInfo["Kanri_no"]));
			ControlUtil.SetControlValue(Denpyo_bango,
				DataFormatUtil.GetFormatItem(td010f02Form.Denpyo_bango,formInfo["Denpyo_bango"]));
			ControlUtil.SetControlValue(Siiresaki_cd,
				DataFormatUtil.GetFormatItem(td010f02Form.Siiresaki_cd,formInfo["Siiresaki_cd"]));
			ControlUtil.SetControlValue(Siiresaki_ryaku_nm,
				DataFormatUtil.GetFormatItem(td010f02Form.Siiresaki_ryaku_nm,formInfo["Siiresaki_ryaku_nm"]));
			ControlUtil.SetControlValue(Nyuryokutan_cd,
				DataFormatUtil.GetFormatItem(td010f02Form.Nyuryokutan_cd,formInfo["Nyuryokutan_cd"]));
			ControlUtil.SetControlValue(Nyuryokutan_nm,
				DataFormatUtil.GetFormatItem(td010f02Form.Nyuryokutan_nm,formInfo["Nyuryokutan_nm"]));
			ControlUtil.SetControlValue(Bumon_cd,
				DataFormatUtil.GetFormatItem(td010f02Form.Bumon_cd,formInfo["Bumon_cd"]));
			ControlUtil.SetControlValue(Bumon_nm,
				DataFormatUtil.GetFormatItem(td010f02Form.Bumon_nm,formInfo["Bumon_nm"]));
			ControlUtil.SetControlValue(Burando_cd,
				DataFormatUtil.GetFormatItem(td010f02Form.Burando_cd,formInfo["Burando_cd"]));
			ControlUtil.SetControlValue(Burando_nm,
				DataFormatUtil.GetFormatItem(td010f02Form.Burando_nm,formInfo["Burando_nm"]));
			ControlUtil.SetControlValue(Henpin_riyu_nm,
				DataFormatUtil.GetFormatItem(td010f02Form.Henpin_riyu_nm,formInfo["Henpin_riyu_nm"]));
			ControlUtil.SetControlValue(Henpin_kakutei_ymd,
				DataFormatUtil.GetFormatItem(td010f02Form.Henpin_kakutei_ymd,formInfo["Henpin_kakutei_ymd"]));
			ControlUtil.SetControlValue(Add_ymd,
				DataFormatUtil.GetFormatItem(td010f02Form.Add_ymd,formInfo["Add_ymd"]));
			ControlUtil.SetControlValue(Gokei_suryo,
				DataFormatUtil.GetFormatItem(td010f02Form.Gokei_suryo,formInfo["Gokei_suryo"]));
			ControlUtil.SetControlValue(Genka_kin_gokei,
				DataFormatUtil.GetFormatItem(td010f02Form.Genka_kin_gokei,formInfo["Genka_kin_gokei"]));

			if(!base.CheckUseSelfCustomize()){
				Btnback.Value = base.FormResourceGetString(formResource, "Btnback", lang);
				Btnrowins.Value = base.FormResourceGetString(formResource, "Btnrowins", lang);
				Btnrowdel.Value = base.FormResourceGetString(formResource, "Btnrowdel", lang);
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
			// UIScreenController controller = new UIScreenController((Td010f02Form)base.GetPageContext().GetFormVO());
			// controller.ChangeColumnsDisplayMode(M1 ,  new DetailHeaderFixedVO(M1Header , true) , null);

			/*
			 *登録した機能間連携処理を親画面に感知させる。
			 *機能有効させる場合は、コメントアウトを外してください。
			 */
			//DetailUtil.RunPgSyn(this,(StandardBaseForm)base.GetPageContext().GetFormVO());


			#region 画面表示制御
			Td010f02Form formVo = (Td010f02Form)base.GetPageContext().GetFormVO();
			//IDataList m1DataList = formVo.GetList("M1");


			// [選択モードNo]が「確定前修正」以外の場合
			if (!BoSystemString.Nvl(formVo.Stkmodeno).Equals(BoSystemConstant.MODE_KAKUTEIMAEUPD))
			{
				// 明細ボタンを使用不可とする。
				ControlCls.Disable(Btnrowins, true);
				ControlCls.Disable(Btnrowdel, true);
				// 確定ボタンを使用不可とする。
				ControlCls.Disable(Btnenter, true);

				for (int index = 0; index < M1.Items.Count; index++)
				{
					// スキャンコード、数量を使用不可とする。
					//((MDTextBox)M1.Items[index].FindControl("M1scan_cd")).Disabled = true;
					//((MDTextBox)M1.Items[index].FindControl("M1suryo")).Disabled = true;

					ControlCls.Disable(((MDTextBox)M1.Items[index].FindControl("M1scan_cd")), true);
					ControlCls.Disable(((MDTextBox)M1.Items[index].FindControl("M1suryo")), true);

				}
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
			ControlUtil.SetControlValue(Siji_bango_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Siji_bango", lang), base.GetPageContext().FormInfo["Siji_bango"]));
				DataFormatUtil.SetMustColorCaption(Siji_bango_lbl, base.GetPageContext().FormInfo["Siji_bango"]);
			ControlUtil.SetControlValue(Kanri_no_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Kanri_no", lang), base.GetPageContext().FormInfo["Kanri_no"]));
				DataFormatUtil.SetMustColorCaption(Kanri_no_lbl, base.GetPageContext().FormInfo["Kanri_no"]);
			ControlUtil.SetControlValue(Denpyo_bango_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Denpyo_bango", lang), base.GetPageContext().FormInfo["Denpyo_bango"]));
				DataFormatUtil.SetMustColorCaption(Denpyo_bango_lbl, base.GetPageContext().FormInfo["Denpyo_bango"]);
			ControlUtil.SetControlValue(Siiresaki_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Siiresaki_cd", lang), base.GetPageContext().FormInfo["Siiresaki_cd"]));
				DataFormatUtil.SetMustColorCaption(Siiresaki_cd_lbl, base.GetPageContext().FormInfo["Siiresaki_cd"]);
			ControlUtil.SetControlValue(Siiresaki_ryaku_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Siiresaki_ryaku_nm", lang), base.GetPageContext().FormInfo["Siiresaki_ryaku_nm"]));
				DataFormatUtil.SetMustColorCaption(Siiresaki_ryaku_nm_lbl, base.GetPageContext().FormInfo["Siiresaki_ryaku_nm"]);
			ControlUtil.SetControlValue(Nyuryokutan_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Nyuryokutan_cd", lang), base.GetPageContext().FormInfo["Nyuryokutan_cd"]));
				DataFormatUtil.SetMustColorCaption(Nyuryokutan_cd_lbl, base.GetPageContext().FormInfo["Nyuryokutan_cd"]);
			ControlUtil.SetControlValue(Nyuryokutan_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Nyuryokutan_nm", lang), base.GetPageContext().FormInfo["Nyuryokutan_nm"]));
				DataFormatUtil.SetMustColorCaption(Nyuryokutan_nm_lbl, base.GetPageContext().FormInfo["Nyuryokutan_nm"]);
			ControlUtil.SetControlValue(Bumon_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Bumon_cd", lang), base.GetPageContext().FormInfo["Bumon_cd"]));
				DataFormatUtil.SetMustColorCaption(Bumon_cd_lbl, base.GetPageContext().FormInfo["Bumon_cd"]);
			ControlUtil.SetControlValue(Bumon_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Bumon_nm", lang), base.GetPageContext().FormInfo["Bumon_nm"]));
				DataFormatUtil.SetMustColorCaption(Bumon_nm_lbl, base.GetPageContext().FormInfo["Bumon_nm"]);
			ControlUtil.SetControlValue(Burando_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Burando_cd", lang), base.GetPageContext().FormInfo["Burando_cd"]));
				DataFormatUtil.SetMustColorCaption(Burando_cd_lbl, base.GetPageContext().FormInfo["Burando_cd"]);
			ControlUtil.SetControlValue(Burando_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Burando_nm", lang), base.GetPageContext().FormInfo["Burando_nm"]));
				DataFormatUtil.SetMustColorCaption(Burando_nm_lbl, base.GetPageContext().FormInfo["Burando_nm"]);
			ControlUtil.SetControlValue(Henpin_riyu_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Henpin_riyu_nm", lang), base.GetPageContext().FormInfo["Henpin_riyu_nm"]));
				DataFormatUtil.SetMustColorCaption(Henpin_riyu_nm_lbl, base.GetPageContext().FormInfo["Henpin_riyu_nm"]);
			ControlUtil.SetControlValue(Henpin_kakutei_ymd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Henpin_kakutei_ymd", lang), base.GetPageContext().FormInfo["Henpin_kakutei_ymd"]));
				DataFormatUtil.SetMustColorCaption(Henpin_kakutei_ymd_lbl, base.GetPageContext().FormInfo["Henpin_kakutei_ymd"]);
			ControlUtil.SetControlValue(Add_ymd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Add_ymd", lang), base.GetPageContext().FormInfo["Add_ymd"]));
				DataFormatUtil.SetMustColorCaption(Add_ymd_lbl, base.GetPageContext().FormInfo["Add_ymd"]);
			ControlUtil.SetControlValue(Gokei_suryo_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Gokei_suryo", lang), base.GetPageContext().FormInfo["Gokei_suryo"]));
				DataFormatUtil.SetMustColorCaption(Gokei_suryo_lbl, base.GetPageContext().FormInfo["Gokei_suryo"]);
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
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hinsyu_ryaku_nm", lang), base.GetPageContext().FormInfo["M1hinsyu_ryaku_nm"]);
				// M1.Columns[2].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1jisya_hbn", lang), base.GetPageContext().FormInfo["M1jisya_hbn"]);
				// M1.Columns[3].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1maker_hbn", lang), base.GetPageContext().FormInfo["M1maker_hbn"]);
				// M1.Columns[4].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syonmk", lang), base.GetPageContext().FormInfo["M1syonmk"]);
				// M1.Columns[5].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1iro_nm", lang), base.GetPageContext().FormInfo["M1iro_nm"]);
				// M1.Columns[6].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1size_nm", lang), base.GetPageContext().FormInfo["M1size_nm"]);
				// M1.Columns[7].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1scan_cd", lang), base.GetPageContext().FormInfo["M1scan_cd"]);
				// M1.Columns[8].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo", lang), base.GetPageContext().FormInfo["M1suryo"]);
				// M1.Columns[9].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1gen_tnk", lang), base.GetPageContext().FormInfo["M1gen_tnk"]);
				// M1.Columns[10].HeaderText = 
				// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1genkakin", lang), base.GetPageContext().FormInfo["M1genkakin"]);
				// M1.Columns[11].HeaderText = 
				// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo_hdn", lang), base.GetPageContext().FormInfo["M1suryo_hdn"]);
				// M1.Columns[12].HeaderText = 
				// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1genkakin_hdn", lang), base.GetPageContext().FormInfo["M1genkakin_hdn"]);
				// M1.Columns[11].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1suryo_hdn", lang), base.GetPageContext().FormInfo["M1suryo_hdn"]);
				// M1.Columns[12].HeaderText = 
				// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1genkakin_hdn", lang), base.GetPageContext().FormInfo["M1genkakin_hdn"]);
				// M1.Columns[13].HeaderText = 
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
				Windowtitle.InnerText = formResource.GetString("Td010f02_Titlebar", lang);
				header.FormName = formResource.GetString("Td010f02_FormCaption", lang);
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

		#region ユーザ定義関数

		#endregion



	}
}
