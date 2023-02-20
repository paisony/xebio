using com.xebio.bo.Th010p01.Constant;
using com.xebio.bo.Th010p01.Facade;
using com.xebio.bo.Th010p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using Common.Advanced.Model.Context;
using Common.Advanced.Resource;
using Common.Advanced.Web.Context;
using Common.Advanced.Web.Util;
using Common.Business.C01000.C01013;
using Common.Business.C01000.C01014;
using Common.Business.C01000.C01015;
using Common.Business.C01000.C01018;
using Common.Business.C01000.C01019;
using Common.Business.C01000.C01026;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LabelUtil;
using Common.Business.C99999.ReportUtil;
using Common.Conditions;
using Common.IntegrationMD.Util;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Session;
using Common.Standard.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;

namespace com.xebio.bo.Th010p01.Page
{
  /// <summary>
  /// Th010f01のコードビハインドです。
  /// </summary>
  public partial class Th010f01Page : StandardBasePage
	{

		#region メソッド

		#region ページデータをロードするメソッド
		/// <summary>
		/// Th010f01画面データを作成する。
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
						pageContext.SetFormVO(new Th010f01Form());
						switch(commandInfo.ActionMode)
						{
							case "ADD":
								break;
							case "INI":	// メニューから遷移時
							case "DEL":
							case "UPD":
								IFacadeContext facadeContext =
									FacadeContextFactory.GetFacadeContext(pageContext);
								InitFacadeContext(facadeContext);
								new Th010f01Facade().DoLoad(facadeContext);

								#region 共通ヘッダ処理

								// 一覧画面共通処理 ----------
								LoginInfoVO loginInfVO = LoginInfoUtil.GetLoginInfo();
								Th010f01Form th010f01Form = (Th010f01Form)facadeContext.FormVO;
								ControlHeaderStoreCls.InitialSetHeaderStore<Th010f01Form>(loginInfVO, th010f01Form);
								// 一覧画面共通処理 ----------

								if (string.IsNullOrEmpty(th010f01Form.Modeno))
								{
									// アコーディオンなし
									AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_NONE);
									// モードNoを自社品番に設定
									th010f01Form.Modeno = BoSystemConstant.MODE_JISHAHINBAN.ToString();
									TabUtil.SetTabNumber(pageContext, BoSystemConstant.MODE_JISHAHINBAN.ToString());
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
					Th010f01Form f01VO = (Th010f01Form)fvm.GetProgramVO(base.GetPageContext().CommandInfo.ProgramId).GetFormVO(Th010p01Constant.FORMID_01);
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
				// モード表示クリア処理
				ModeUtil.ClearMode(pageContext);
				//明細初期化処理
				Page.ClientScript.RegisterStartupScript(typeof(string), "InitialDetail", ControlCls.InitialDetail(pageContext));
				return;
			}
			
			//アクションコンテキストを取得する
			//IPageContext pageContext = base.GetPageContext();
			pageContext = base.GetPageContext();
			ICommandInfo commandInfo = pageContext.CommandInfo;
			
			try
			{
				// モード表示クリア処理
				ModeUtil.ClearMode(pageContext);

				//アクションロジックを処理します
				IFacadeContext facadeContext = FacadeContextFactory.GetFacadeContext(pageContext);
				InitFacadeContext(facadeContext);
				new Th010f01Facade().DoBTNSEARCH_FRM(facadeContext);
				
				
				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
					// アコーディオンなし
					AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_NONE);

					base.SetError(pageContext);
					return;
				}

				//アコーディオンを閉じた状態で表示
				AccordionUtil.SetAccordionKbn(pageContext, BoSystemConstant.ACCORDION_ST_CLOSE);
				//アコーディオンを閉じた際に表示される検索条件を設定する。
				AccordionUtil.ResetSearchCondition(pageContext);
				// モードを設定 
				ModeUtil.SetMode(pageContext, ModeCls.GetModeNm(((Th010f01Form)pageContext.GetFormVO()).Stkmodeno));

				
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
			
			//フォーカスを当てる項目を指定したい場合はFormFocusUtilを使ってqueryListに追加すること

			// フォーカス設定用変数
			string focusItem = string.Empty;
			string focusMno = string.Empty;

			// [商品マスタ検索選択]にフォーカスを当てる。
			focusItem = "Syohinmst_serchstk";

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
		
		#region フォームを呼び出します(ボタンID : Btncsv(CSV出力))
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btncsv(CSV出力))
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnBTNCSV_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnBTNCSV_FRM");
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

			// CSVファイル名
			string csvNm = string.Empty;

			try
			{

				//アクションロジックを処理します
				IFacadeContext facadeContext = FacadeContextFactory.GetFacadeContext(pageContext);
				InitFacadeContext(facadeContext);
				new Th010f01Facade().DoBTNCSV_FRM(facadeContext);
				
				
				//エラー判定
				if(MessageDisplayUtil.HasError(facadeContext))
				{
					base.SetError(pageContext);
					return;
				}

				// CSVファイル名を取得
				csvNm = (string)facadeContext.GetUserObject(Th010p01Constant.FCDUO_CSV_FLNM);
				
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

			DLConditionVO dlvo = new DLConditionVO();

			// サーバファイルフルパス
			string serverPath = string.Format("{0}{1}{2}",
											FilePathManager.GetOutFilePath(Th010p01Constant.PGID),
											Path.DirectorySeparatorChar,
											csvNm
											);

			// クライアントファイル名
			string clientNm = string.Format("{0}{1}",
											BoSystemReport.CreateFileName(BoSystemConstant.CSVNM_SYOHIN),
											FilePathManager.EXT_CSV
											);

			// ダウンロード用VOに値を設定
			dlvo.setSingleFileDownloadCondition(serverPath, clientNm);

			// ダウンロード用VOをセッションに格納
			SessionInfoUtil.SetPgObject(BoSystemConstant.SESSION_KEY_DOWNLOAD_VO, dlvo, pageContext);
			
			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnBTNCSV_FRM");
			
			//画面遷移
			base.Forward(pageContext, queryList);
			//base.DownloadPageStartUp(pageContext,dlvo);
		}
		#endregion
		
		#region M1明細部のページング処理を実行します。(ボタンID : Pgr(ページャ))
		/// <summary>
		/// M1明細部のページング処理を実行します。
		/// ボタンID(Pgr(ページャ))
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
				new Th010f01Facade().DoPGR_PGN(facadeContext, pageindex);
				
				
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
		
		#region フォームを呼び出します(ボタンID : M1jisya_hbn(自社品番))
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(M1jisya_hbn(自社品番))
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnM1JISYA_HBN_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnM1JISYA_HBN_FRM");
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

				// 次画面のフォームVOをファサードに設定
				FormVOManager fvm = new FormVOManager(Session);
				facadeContext.SetUserObject(Th010p01Constant.FCDUO_NEXTVO_02, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Th010p01Constant.FORMID_02));
				facadeContext.SetUserObject(Th010p01Constant.FCDUO_NEXTVO_03, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Th010p01Constant.FORMID_03));

				if (Syohinmst_serchstk.SelectedValue.Equals(ConditionSyohinmst_serchstk1.VALUE_SYOHINMST_SERCHSTK13))
				{
					// クッキー値を取得
					BoSystemLabelUtil.GetCookieLabel(pageContext.Request, facadeContext);
				}

				new Th010f01Facade().DoM1JISYA_HBN_FRM(facadeContext);
				
				// 次画面のフォームビーンを設定
				fvm.SetFormVO(Th010p01Constant.PGID, Th010p01Constant.FORMID_02, (Th010f02Form)facadeContext.GetUserObject(Th010p01Constant.FCDUO_NEXTVO_02));
				fvm.SetFormVO(Th010p01Constant.PGID, Th010p01Constant.FORMID_03, (Th010f03Form)facadeContext.GetUserObject(Th010p01Constant.FCDUO_NEXTVO_03));

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

				// フォーカス設定用変数
				string focusItem = string.Empty;
				string focusMno = string.Empty;

				// 画面遷移設定
				if (Syohinmst_serchstk.SelectedValue.Equals(ConditionSyohinmst_serchstk1.VALUE_SYOHINMST_SERCHSTK12))
				{
					//[商品マスタ検索選択]が「メーカー品番検索」の場合
					pageContext.ButtonInfo.ActFormId = Th010p01Constant.FORMID_02;

					// [メーカー品番]にフォーカスを当てる
					focusItem = "Maker_hbn";
				}
				else if (Syohinmst_serchstk.SelectedValue.Equals(ConditionSyohinmst_serchstk1.VALUE_SYOHINMST_SERCHSTK13))
				{
					// [商品マスタ検索選択]が「サイズ別／プライス」の場合
					pageContext.ButtonInfo.ActFormId = Th010p01Constant.FORMID_03;

					// 出力シール項目取得
					Th010f03Form f03VO = (Th010f03Form)pageContext.GetFormVO(Th010p01Constant.PGID, Th010p01Constant.FORMID_03);
					IList<Hashtable> SealItemNm = (IList<Hashtable>) f03VO.Dictionary[Th010p01Constant.DIC_SYUTSURYOKU_SEAL];

					// [出力シール]が使用可能である場合
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
				}
				else
				{
				}

				// フォーカス設定
				SetFocusCls.SetFocus(queryList, focusItem, focusMno);

				//メソッドの終了処理を実行する。
				EndMethod(sender, e, this.GetType().Name + ".OnM1JISYA_HBN_FRM");

				if (Syohinmst_serchstk.SelectedValue.Equals(ConditionSyohinmst_serchstk1.VALUE_SYOHINMST_SERCHSTK11))
				{
					Th010f01Form formVo = (Th010f01Form)base.GetPageContext().GetFormVO();
					IDataList formM1List = formVo.GetList("M1");
					Th010f01M1Form formM1Vo = (Th010f01M1Form)formM1List.GetPageViewList()[FacadeContextFactory.GetFacadeContext(pageContext).CommandInfo.ListIndex];
					pageContext.Session[BoSystemConstant.PRM_TENPO_CD] = BoSystemFormat.formatTenpoCd(formVo.Dictionary[SearchConditionSaveCls.GetKey(() => formVo.Head_tenpo_cd)].ToString());
					pageContext.Session[BoSystemConstant.PRM_TENPO_NM] = formVo.Dictionary[SearchConditionSaveCls.GetKey(() => formVo.Head_tenpo_nm)].ToString();
					pageContext.Session[BoSystemConstant.PRM_JISYA_HBN] = BoSystemFormat.formatJisyaHbn(formM1Vo.Dictionary[Th010p01Constant.DIC_M1XEBIO_CD].ToString());

					commandInfo.ToProgramId = BoSystemConstant.PRM_PGID;
					commandInfo.ToFormId = BoSystemConstant.PRM_FORMID;

					// アクションモードはUPDとする
					commandInfo.ActionMode = "UPD";

					// 画面起動(モーダレス)
					base.ForwardNewPG(pageContext, queryList);
				}
				else
				{
					//画面遷移
					base.Forward(pageContext, queryList);
				}
		}
		#endregion
		
		#region フォームを呼び出します(ボタンID : M1old_jisya_hbn(旧自社品番))
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(M1old_jisya_hbn(旧自社品番))
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">System.EventArgs</param>
		protected virtual void OnM1OLD_JISYA_HBN_FRM(object sender, System.EventArgs e)
		{
			//メソッドの開始処理を実行する。
			StartMethod(sender, e, this.GetType().Name + ".OnM1OLD_JISYA_HBN_FRM");
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

				// 次画面のフォームVOをファサードに設定
				FormVOManager fvm = new FormVOManager(Session);
				facadeContext.SetUserObject(Th010p01Constant.FCDUO_NEXTVO_02, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Th010p01Constant.FORMID_02));
				facadeContext.SetUserObject(Th010p01Constant.FCDUO_NEXTVO_03, fvm.GetProgramVO(facadeContext.CommandInfo.ProgramId).GetFormVO(Th010p01Constant.FORMID_03));

				if (Syohinmst_serchstk.SelectedValue.Equals(ConditionSyohinmst_serchstk1.VALUE_SYOHINMST_SERCHSTK13))
				{
					// クッキー値を取得
					BoSystemLabelUtil.GetCookieLabel(pageContext.Request, facadeContext);
				}

				new Th010f01Facade().DoM1OLD_JISYA_HBN_FRM(facadeContext);

				// 次画面のフォームビーンを設定
				fvm.SetFormVO(Th010p01Constant.PGID, Th010p01Constant.FORMID_02, (Th010f02Form)facadeContext.GetUserObject(Th010p01Constant.FCDUO_NEXTVO_02));
				fvm.SetFormVO(Th010p01Constant.PGID, Th010p01Constant.FORMID_03, (Th010f03Form)facadeContext.GetUserObject(Th010p01Constant.FCDUO_NEXTVO_03));
				
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

			// フォーカス設定用変数
			string focusItem = string.Empty;
			string focusMno = string.Empty;

			// 画面遷移設定
			if (Syohinmst_serchstk.SelectedValue.Equals(ConditionSyohinmst_serchstk1.VALUE_SYOHINMST_SERCHSTK12))
			{
				//[商品マスタ検索選択]が「メーカー品番検索」の場合
				pageContext.ButtonInfo.ActFormId = Th010p01Constant.FORMID_02;

				// [メーカー品番]にフォーカスを当てる
				focusItem = "Maker_hbn";
			}
			else if (Syohinmst_serchstk.SelectedValue.Equals(ConditionSyohinmst_serchstk1.VALUE_SYOHINMST_SERCHSTK13))
			{
				// [商品マスタ検索選択]が「サイズ別／プライス」の場合
				pageContext.ButtonInfo.ActFormId = Th010p01Constant.FORMID_03;

				// 出力シール項目取得
				Th010f03Form f03VO = (Th010f03Form)pageContext.GetFormVO(Th010p01Constant.PGID, Th010p01Constant.FORMID_03);
				IList<Hashtable> SealItemNm = (IList<Hashtable>)f03VO.Dictionary[Th010p01Constant.DIC_SYUTSURYOKU_SEAL];

				// [出力シール]が使用可能である場合
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
			}
			else
			{
			}

			// フォーカス設定
			SetFocusCls.SetFocus(queryList, focusItem, focusMno);
			
			//メソッドの終了処理を実行する。
			EndMethod(sender, e, this.GetType().Name + ".OnM1OLD_JISYA_HBN_FRM");

			if (Syohinmst_serchstk.SelectedValue.Equals(ConditionSyohinmst_serchstk1.VALUE_SYOHINMST_SERCHSTK11))
			{
				Th010f01Form formVo = (Th010f01Form)base.GetPageContext().GetFormVO();
				IDataList formM1List = formVo.GetList("M1");
				Th010f01M1Form formM1Vo = (Th010f01M1Form)formM1List.GetPageViewList()[FacadeContextFactory.GetFacadeContext(pageContext).CommandInfo.ListIndex];
				pageContext.Session[BoSystemConstant.PRM_TENPO_CD] = BoSystemFormat.formatTenpoCd(formVo.Dictionary[SearchConditionSaveCls.GetKey(() => formVo.Head_tenpo_cd)].ToString());
				pageContext.Session[BoSystemConstant.PRM_TENPO_NM] = formVo.Dictionary[SearchConditionSaveCls.GetKey(() => formVo.Head_tenpo_nm)].ToString();
				pageContext.Session[BoSystemConstant.PRM_JISYA_HBN] = BoSystemFormat.formatJisyaHbn(formM1Vo.Dictionary[Th010p01Constant.DIC_M1XEBIO_CD].ToString());

				commandInfo.ToProgramId = BoSystemConstant.PRM_PGID;
				commandInfo.ToFormId = BoSystemConstant.PRM_FORMID;

				// アクションモードはUPDとする
				commandInfo.ActionMode = "UPD";
				
				// 画面起動(モーダレス)
				base.ForwardNewPG(pageContext, queryList);
			}
			else
			{
				//画面遷移
				base.Forward(pageContext, queryList);
			}
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
					//if (!MessageDisplayUtil.HasError(pageContext))
					//{
						string lang = WebSettingsUtil.GetLangSettingFromSession(pageContext.Session);
						FormResource formResource =
							ResourceFactory.GetFormResource(pageContext.CommandInfo.FormId);
			
						//標題をセットする
						SetCaption(formResource, lang);

						//FormVOを取得する
						Th010f01Form th010f01Form = (Th010f01Form)pageContext.GetFormVO();

						//明細ページ情報を表示する
						ShowListPageInfo(th010f01Form);
			
						//明細部データを表示する
						RenderList(th010f01Form, pageContext.FormInfo, formResource, lang);

						//カード部データを表示する
						RenderCard(th010f01Form, pageContext.FormInfo, formResource, lang);
					//}
					
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
		/// <param name="th010f01Form">画面FormVO</param>
		private void ShowListPageInfo(Th010f01Form th010f01Form)
		{
			//M1明細ページ情報を表示する。
			ShowM1ListPageInfo(th010f01Form.GetList("M1"));

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
		/// <param name="th010f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderList(
			Th010f01Form th010f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//画面のM1明細部データを設定する。
			RenderM1List(th010f01Form, formInfo, formResource, lang);
			//M1明細部のページャーにページ情報を設定する。
			RenderM1Pager(th010f01Form);
			
		}
		#endregion

		#region M1明細データを表示する
		/// <summary>
		/// M1明細データを表示する。
		/// </summary>
		/// <param name="th010f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderM1List(
			Th010f01Form th010f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			//M1明細部データソースを設定する。
			M1.DataSource = th010f01Form.GetPageViewList("M1");
			M1.DataBind();

			//M1明細部データをフォーマットする。
			IList m1DataList = (IList)M1.DataSource;
			
			for (int index = 0; index < M1.Items.Count; index++)
			{
				Th010f01M1Form th010f01M1Form = (Th010f01M1Form)m1DataList[index];
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1rowno"),
					DataFormatUtil.GetFormatItem(th010f01M1Form.M1rowno,formInfo["M1rowno"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1siiresaki_cd"),
					DataFormatUtil.GetFormatItem(th010f01M1Form.M1siiresaki_cd,formInfo["M1siiresaki_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1siiresaki_ryaku_nm"),
					DataFormatUtil.GetFormatItem(th010f01M1Form.M1siiresaki_ryaku_nm,formInfo["M1siiresaki_ryaku_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1bumon_cd"),
					DataFormatUtil.GetFormatItem(th010f01M1Form.M1bumon_cd,formInfo["M1bumon_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1bumonkana_nm"),
					DataFormatUtil.GetFormatItem(th010f01M1Form.M1bumonkana_nm,formInfo["M1bumonkana_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1hinsyu_cd"),
					DataFormatUtil.GetFormatItem(th010f01M1Form.M1hinsyu_cd,formInfo["M1hinsyu_cd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1hinsyu_ryaku_nm"),
					DataFormatUtil.GetFormatItem(th010f01M1Form.M1hinsyu_ryaku_nm,formInfo["M1hinsyu_ryaku_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1burando_nm"),
					DataFormatUtil.GetFormatItem(th010f01M1Form.M1burando_nm,formInfo["M1burando_nm"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1syohin_zokusei"),
					DataFormatUtil.GetFormatItem(th010f01M1Form.M1syohin_zokusei,formInfo["M1syohin_zokusei"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1maker_hbn"),
					DataFormatUtil.GetFormatItem(th010f01M1Form.M1maker_hbn,formInfo["M1maker_hbn"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1syonmk"),
					DataFormatUtil.GetFormatItem(th010f01M1Form.M1syonmk,formInfo["M1syonmk"]));

				// Dictionary.[Ｍ１展開区分]が2の場合空白
				if (!th010f01M1Form.Dictionary[Th010p01Constant.DIC_M1TENKAI_KB].ToString().Equals("2"))
				{ 
					ControlUtil.SetControlValue(M1.Items[index].FindControl("M1iro_nm"),
						DataFormatUtil.GetFormatItem(th010f01M1Form.M1iro_nm,formInfo["M1iro_nm"]));
				}

				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1hanbaikanryo_ymd"),
					DataFormatUtil.GetFormatItem(th010f01M1Form.M1hanbaikanryo_ymd,formInfo["M1hanbaikanryo_ymd"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1zeiritsu"),
					DataFormatUtil.GetFormatItem(th010f01M1Form.M1zeiritsu,formInfo["M1zeiritsu"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1saisinbaika_tnk"),
					DataFormatUtil.GetFormatItem(th010f01M1Form.M1saisinbaika_tnk,formInfo["M1saisinbaika_tnk"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1genka"),
					DataFormatUtil.GetFormatItem(th010f01M1Form.M1genka,formInfo["M1genka"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1genbaika_tnk"),
					DataFormatUtil.GetFormatItem(th010f01M1Form.M1genbaika_tnk,formInfo["M1genbaika_tnk"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1makerkakaku_tnk"),
					DataFormatUtil.GetFormatItem(th010f01M1Form.M1makerkakaku_tnk,formInfo["M1makerkakaku_tnk"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1selectorcheckbox"),
					DataFormatUtil.GetFormatItem(th010f01M1Form.M1selectorcheckbox,formInfo["M1selectorcheckbox"]));
				((System.Web.UI.WebControls.CheckBox)M1.Items[index].FindControl("M1selectorcheckbox")).Text =
					formResource.GetString("M1selectorcheckbox", lang);
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1entersyoriflg"),
					DataFormatUtil.GetFormatItem(th010f01M1Form.M1entersyoriflg,formInfo["M1entersyoriflg"]));
				ControlUtil.SetControlValue(M1.Items[index].FindControl("M1dtlirokbn"),
					DataFormatUtil.GetFormatItem(th010f01M1Form.M1dtlirokbn,formInfo["M1dtlirokbn"]));

				if(!base.CheckUseSelfCustomize()){
					((System.Web.UI.HtmlControls.HtmlInputButton)M1.Items[index].FindControl("M1jisya_hbn")).Value =
						th010f01M1Form.Dictionary[Th010p01Constant.DIC_M1XEBIO_CD].ToString();

					// Ｍ１旧自社品番がALL0の場合括弧表示もなし
					if (!th010f01M1Form.Dictionary[Th010p01Constant.DIC_M1OLD_XEBIO_CD].ToString().Equals("0000000000"))
					{ 
						((System.Web.UI.HtmlControls.HtmlInputButton)M1.Items[index].FindControl("M1old_jisya_hbn")).Value =
							"(" + th010f01M1Form.Dictionary[Th010p01Constant.DIC_M1OLD_XEBIO_CD].ToString() + ")";
					}
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
				// (M1.HeaderRow.FindControl("M1siiresaki_cd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1siiresaki_cd", lang), base.GetPageContext().FormInfo["M1siiresaki_cd"]);
				// (M1.HeaderRow.FindControl("M1siiresaki_ryaku_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1siiresaki_ryaku_nm", lang), base.GetPageContext().FormInfo["M1siiresaki_ryaku_nm"]);
				// (M1.HeaderRow.FindControl("M1bumon_cd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumon_cd", lang), base.GetPageContext().FormInfo["M1bumon_cd"]);
				// (M1.HeaderRow.FindControl("M1bumonkana_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumonkana_nm", lang), base.GetPageContext().FormInfo["M1bumonkana_nm"]);
				// (M1.HeaderRow.FindControl("M1hinsyu_cd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hinsyu_cd", lang), base.GetPageContext().FormInfo["M1hinsyu_cd"]);
				// (M1.HeaderRow.FindControl("M1hinsyu_ryaku_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hinsyu_ryaku_nm", lang), base.GetPageContext().FormInfo["M1hinsyu_ryaku_nm"]);
				// (M1.HeaderRow.FindControl("M1burando_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1burando_nm", lang), base.GetPageContext().FormInfo["M1burando_nm"]);
				// (M1.HeaderRow.FindControl("M1jisya_hbn") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1jisya_hbn", lang), base.GetPageContext().FormInfo["M1jisya_hbn"]);
				// (M1.HeaderRow.FindControl("M1old_jisya_hbn") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1old_jisya_hbn", lang), base.GetPageContext().FormInfo["M1old_jisya_hbn"]);
				// (M1.HeaderRow.FindControl("M1syohin_zokusei") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syohin_zokusei", lang), base.GetPageContext().FormInfo["M1syohin_zokusei"]);
				// (M1.HeaderRow.FindControl("M1maker_hbn") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1maker_hbn", lang), base.GetPageContext().FormInfo["M1maker_hbn"]);
				// (M1.HeaderRow.FindControl("M1syonmk") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syonmk", lang), base.GetPageContext().FormInfo["M1syonmk"]);
				// (M1.HeaderRow.FindControl("M1iro_nm") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1iro_nm", lang), base.GetPageContext().FormInfo["M1iro_nm"]);
				// (M1.HeaderRow.FindControl("M1hanbaikanryo_ymd") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hanbaikanryo_ymd", lang), base.GetPageContext().FormInfo["M1hanbaikanryo_ymd"]);
				// (M1.HeaderRow.FindControl("M1zeiritsu") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1zeiritsu", lang), base.GetPageContext().FormInfo["M1zeiritsu"]);
				// (M1.HeaderRow.FindControl("M1saisinbaika_tnk") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1saisinbaika_tnk", lang), base.GetPageContext().FormInfo["M1saisinbaika_tnk"]);
				// (M1.HeaderRow.FindControl("M1genka") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1genka", lang), base.GetPageContext().FormInfo["M1genka"]);
				// (M1.HeaderRow.FindControl("M1genbaika_tnk") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1genbaika_tnk", lang), base.GetPageContext().FormInfo["M1genbaika_tnk"]);
				// (M1.HeaderRow.FindControl("M1makerkakaku_tnk") as Label).Text = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1makerkakaku_tnk", lang), base.GetPageContext().FormInfo["M1makerkakaku_tnk"]);
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
		/// <param name="th010f01Form">画面FormVO</param>
		private void RenderM1Pager(Th010f01Form th010f01Form)
		{
			Pgr.VirtualItemCount = th010f01Form.GetList("M1").RecordCount;
			Pgr.CurrentPageIndex = th010f01Form.GetList("M1").PageNo - 1;
			Pgr.PageSize = th010f01Form.GetList("M1").DispRow;
		}
		#endregion
		#endregion

		#region カードデータを表示する
		/// <summary>
		/// カードデータを表示する
		/// </summary>
		/// <param name="th010f01Form">画面FormVO</param>
		/// <param name="formInfo">画面情報</param>
		/// <param name="formResource">画面リソース</param>
		/// <param name="lang">言語設定</param>
		private void RenderCard(
			Th010f01Form th010f01Form,
			IFormInfo formInfo,
			FormResource formResource,
			string lang)
		{
			
			ControlUtil.SetControlValue(Head_tenpo_cd,
				DataFormatUtil.GetFormatItem(th010f01Form.Head_tenpo_cd,formInfo["Head_tenpo_cd"]));
			ControlUtil.SetControlValue(Head_tenpo_nm,
				DataFormatUtil.GetFormatItem(th010f01Form.Head_tenpo_nm,formInfo["Head_tenpo_nm"]));
			ControlUtil.SetControlValue(Old_jisya_hbn_from,
				DataFormatUtil.GetFormatItem(th010f01Form.Old_jisya_hbn_from,formInfo["Old_jisya_hbn_from"]));
			ControlUtil.SetControlValue(Old_jisya_hbn_to,
				DataFormatUtil.GetFormatItem(th010f01Form.Old_jisya_hbn_to,formInfo["Old_jisya_hbn_to"]));
			ControlUtil.SetControlValue(Scan_cd,
				DataFormatUtil.GetFormatItem(th010f01Form.Scan_cd,formInfo["Scan_cd"]));
			ControlUtil.SetControlValue(Maker_hbn,
				DataFormatUtil.GetFormatItem(th010f01Form.Maker_hbn,formInfo["Maker_hbn"]));
			ControlUtil.SetControlValue(Bumon_cd,
				DataFormatUtil.GetFormatItem(th010f01Form.Bumon_cd,formInfo["Bumon_cd"]));
			ControlUtil.SetControlValue(Bumon_nm,
				DataFormatUtil.GetFormatItem(th010f01Form.Bumon_nm,formInfo["Bumon_nm"]));
			ControlUtil.SetControlValue(Hinsyu_cd,
				DataFormatUtil.GetFormatItem(th010f01Form.Hinsyu_cd,formInfo["Hinsyu_cd"]));
			ControlUtil.SetControlValue(Hinsyu_ryaku_nm,
				DataFormatUtil.GetFormatItem(th010f01Form.Hinsyu_ryaku_nm,formInfo["Hinsyu_ryaku_nm"]));
			ControlUtil.SetControlValue(Burando_cd,
				DataFormatUtil.GetFormatItem(th010f01Form.Burando_cd,formInfo["Burando_cd"]));
			ControlUtil.SetControlValue(Burando_nm,
				DataFormatUtil.GetFormatItem(th010f01Form.Burando_nm,formInfo["Burando_nm"]));
			ControlUtil.SetControlValue(Siiresaki_cd,
				DataFormatUtil.GetFormatItem(th010f01Form.Siiresaki_cd,formInfo["Siiresaki_cd"]));
			ControlUtil.SetControlValue(Siiresaki_ryaku_nm,
				DataFormatUtil.GetFormatItem(th010f01Form.Siiresaki_ryaku_nm,formInfo["Siiresaki_ryaku_nm"]));
			ControlUtil.SetControlValue(Genbaika_tnk_from,
				DataFormatUtil.GetFormatItem(th010f01Form.Genbaika_tnk_from,formInfo["Genbaika_tnk_from"]));
			ControlUtil.SetControlValue(Genbaika_tnk_to,
				DataFormatUtil.GetFormatItem(th010f01Form.Genbaika_tnk_to,formInfo["Genbaika_tnk_to"]));
			ControlUtil.SetControlValue(Makerkakaku_tnk_from,
				DataFormatUtil.GetFormatItem(th010f01Form.Makerkakaku_tnk_from,formInfo["Makerkakaku_tnk_from"]));
			ControlUtil.SetControlValue(Makerkakaku_tnk_to,
				DataFormatUtil.GetFormatItem(th010f01Form.Makerkakaku_tnk_to,formInfo["Makerkakaku_tnk_to"]));
			ControlUtil.SetControlValue(Hanbaikanryo_ymd_from,
				DataFormatUtil.GetFormatItem(th010f01Form.Hanbaikanryo_ymd_from,formInfo["Hanbaikanryo_ymd_from"]));
			ControlUtil.SetControlValue(Hanbaikanryo_ymd_to,
				DataFormatUtil.GetFormatItem(th010f01Form.Hanbaikanryo_ymd_to,formInfo["Hanbaikanryo_ymd_to"]));
			ControlUtil.SetControlValue(Syohinmst_serchstk,
				DataFormatUtil.GetFormatItem(th010f01Form.Syohinmst_serchstk,formInfo["Syohinmst_serchstk"]));
			ControlUtil.SetControlValue(Modeno,
				DataFormatUtil.GetFormatItem(th010f01Form.Modeno,formInfo["Modeno"]));
			ControlUtil.SetControlValue(Stkmodeno,
				DataFormatUtil.GetFormatItem(th010f01Form.Stkmodeno,formInfo["Stkmodeno"]));
			ControlUtil.SetControlValue(Searchcnt,
				DataFormatUtil.GetFormatItem(th010f01Form.Searchcnt, formInfo["Searchcnt"]));

			if(!base.CheckUseSelfCustomize()){
				Btnheadtenpocd.Value = base.FormResourceGetString(formResource, "Btnheadtenpocd", lang);
				Btnmodejishahinban.InnerText = base.FormResourceGetString(formResource, "Btnmodejishahinban", lang);
				Btnmodescancd.InnerText = base.FormResourceGetString(formResource, "Btnmodescancd", lang);
				Btnmodemakerhbn.InnerText = base.FormResourceGetString(formResource, "Btnmodemakerhbn", lang);
				Btnmodesonota.InnerText = base.FormResourceGetString(formResource, "Btnmodesonota", lang);
				Btnmaker_hbn.Value = base.FormResourceGetString(formResource, "Btnmaker_hbn", lang);
				Btnbumon_cd.Value = base.FormResourceGetString(formResource, "Btnbumon_cd", lang);
				Btnhinsyu_cd.Value = base.FormResourceGetString(formResource, "Btnhinsyu_cd", lang);
				Btnburando_cd.Value = base.FormResourceGetString(formResource, "Btnburando_cd", lang);
				Btnsiiresaki_cd.Value = base.FormResourceGetString(formResource, "Btnsiiresaki_cd", lang);
				Btnsearch.Value = base.FormResourceGetString(formResource, "Btnsearch", lang);
				Btncsv.Value = base.FormResourceGetString(formResource, "Btncsv", lang);
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
			// UIScreenController controller = new UIScreenController((Th010f01Form)base.GetPageContext().GetFormVO());
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
			// CSV出力
			if (base.GetPageContext().CommandInfo.ActionMode.Equals("INI") || M1.Items.Count == 0)
			{
				// 明細ボタンを非表示とする
				ControlCls.Visible(meisaiBtnArea, false);
			}
			else
			{
				// 明細ボタンを表示する
				ControlCls.Visible(meisaiBtnArea, true);
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
			//ControlUtil.SetControlValue(Old_jisya_hbn_from_lbl, 
			//	DataFormatUtil.GetFormatCaption(formResource.GetString("Old_jisya_hbn_from", lang), base.GetPageContext().FormInfo["Old_jisya_hbn_from"]));
				ControlUtil.SetControlValue(Old_jisya_hbn_from, "自社品番");
				DataFormatUtil.SetMustColorCaption(Old_jisya_hbn_from_lbl, base.GetPageContext().FormInfo["Old_jisya_hbn_from"]);
			//ControlUtil.SetControlValue(Old_jisya_hbn_to_lbl, 
			//	DataFormatUtil.GetFormatCaption(formResource.GetString("Old_jisya_hbn_to", lang), base.GetPageContext().FormInfo["Old_jisya_hbn_to"]));
				DataFormatUtil.SetMustColorCaption(Old_jisya_hbn_to_lbl, base.GetPageContext().FormInfo["Old_jisya_hbn_to"]);
			ControlUtil.SetControlValue(Scan_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Scan_cd", lang), base.GetPageContext().FormInfo["Scan_cd"]));
				DataFormatUtil.SetMustColorCaption(Scan_cd_lbl, base.GetPageContext().FormInfo["Scan_cd"]);
			ControlUtil.SetControlValue(Maker_hbn_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Maker_hbn", lang), base.GetPageContext().FormInfo["Maker_hbn"]));
				DataFormatUtil.SetMustColorCaption(Maker_hbn_lbl, base.GetPageContext().FormInfo["Maker_hbn"]);
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
			ControlUtil.SetControlValue(Siiresaki_cd_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Siiresaki_cd", lang), base.GetPageContext().FormInfo["Siiresaki_cd"]));
				DataFormatUtil.SetMustColorCaption(Siiresaki_cd_lbl, base.GetPageContext().FormInfo["Siiresaki_cd"]);
			ControlUtil.SetControlValue(Siiresaki_ryaku_nm_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Siiresaki_ryaku_nm", lang), base.GetPageContext().FormInfo["Siiresaki_ryaku_nm"]));
				DataFormatUtil.SetMustColorCaption(Siiresaki_ryaku_nm_lbl, base.GetPageContext().FormInfo["Siiresaki_ryaku_nm"]);
			//ControlUtil.SetControlValue(Genbaika_tnk_from_lbl, 
			//	DataFormatUtil.GetFormatCaption(formResource.GetString("Genbaika_tnk_from", lang), base.GetPageContext().FormInfo["Genbaika_tnk_from"]));
				ControlUtil.SetControlValue(Genbaika_tnk_from, "現売価");
				DataFormatUtil.SetMustColorCaption(Genbaika_tnk_from_lbl, base.GetPageContext().FormInfo["Genbaika_tnk_from"]);
			//ControlUtil.SetControlValue(Genbaika_tnk_to_lbl, 
			//	DataFormatUtil.GetFormatCaption(formResource.GetString("Genbaika_tnk_to", lang), base.GetPageContext().FormInfo["Genbaika_tnk_to"]));
				DataFormatUtil.SetMustColorCaption(Genbaika_tnk_to_lbl, base.GetPageContext().FormInfo["Genbaika_tnk_to"]);
			//ControlUtil.SetControlValue(Makerkakaku_tnk_from_lbl, 
			//	DataFormatUtil.GetFormatCaption(formResource.GetString("Makerkakaku_tnk_from", lang), base.GetPageContext().FormInfo["Makerkakaku_tnk_from"]));
				ControlUtil.SetControlValue(Makerkakaku_tnk_from, "ﾒｰｶｰ価格");
				DataFormatUtil.SetMustColorCaption(Makerkakaku_tnk_from_lbl, base.GetPageContext().FormInfo["Makerkakaku_tnk_from"]);
			//ControlUtil.SetControlValue(Makerkakaku_tnk_to_lbl, 
			//	DataFormatUtil.GetFormatCaption(formResource.GetString("Makerkakaku_tnk_to", lang), base.GetPageContext().FormInfo["Makerkakaku_tnk_to"]));
				DataFormatUtil.SetMustColorCaption(Makerkakaku_tnk_to_lbl, base.GetPageContext().FormInfo["Makerkakaku_tnk_to"]);
			//ControlUtil.SetControlValue(Hanbaikanryo_ymd_from_lbl, 
			//	DataFormatUtil.GetFormatCaption(formResource.GetString("Hanbaikanryo_ymd_from", lang), base.GetPageContext().FormInfo["Hanbaikanryo_ymd_from"]));
				ControlUtil.SetControlValue(Hanbaikanryo_ymd_from, "販売完了日");
				DataFormatUtil.SetMustColorCaption(Hanbaikanryo_ymd_from_lbl, base.GetPageContext().FormInfo["Hanbaikanryo_ymd_from"]);
			//ControlUtil.SetControlValue(Hanbaikanryo_ymd_to_lbl, 
			//	DataFormatUtil.GetFormatCaption(formResource.GetString("Hanbaikanryo_ymd_to", lang), base.GetPageContext().FormInfo["Hanbaikanryo_ymd_to"]));
				DataFormatUtil.SetMustColorCaption(Hanbaikanryo_ymd_to_lbl, base.GetPageContext().FormInfo["Hanbaikanryo_ymd_to"]);
			ControlUtil.SetControlValue(Syohinmst_serchstk_lbl, 
				DataFormatUtil.GetFormatCaption(formResource.GetString("Syohinmst_serchstk", lang), base.GetPageContext().FormInfo["Syohinmst_serchstk"]));
				DataFormatUtil.SetMustColorCaption(Syohinmst_serchstk_lbl, base.GetPageContext().FormInfo["Syohinmst_serchstk"]);
			ControlUtil.SetControlValue(Searchcnt_lbl,
				DataFormatUtil.GetFormatCaption(formResource.GetString("Searchcnt", lang), base.GetPageContext().FormInfo["Searchcnt"]));
				DataFormatUtil.SetMustColorCaption(Searchcnt_lbl, base.GetPageContext().FormInfo["Searchcnt"]);
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
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1siiresaki_cd", lang), base.GetPageContext().FormInfo["M1siiresaki_cd"]);
				// M1.Columns[2].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1siiresaki_ryaku_nm", lang), base.GetPageContext().FormInfo["M1siiresaki_ryaku_nm"]);
				// M1.Columns[3].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumon_cd", lang), base.GetPageContext().FormInfo["M1bumon_cd"]);
				// M1.Columns[4].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1bumonkana_nm", lang), base.GetPageContext().FormInfo["M1bumonkana_nm"]);
				// M1.Columns[5].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hinsyu_cd", lang), base.GetPageContext().FormInfo["M1hinsyu_cd"]);
				// M1.Columns[6].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hinsyu_ryaku_nm", lang), base.GetPageContext().FormInfo["M1hinsyu_ryaku_nm"]);
				// M1.Columns[7].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1burando_nm", lang), base.GetPageContext().FormInfo["M1burando_nm"]);
				// M1.Columns[8].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1jisya_hbn", lang), base.GetPageContext().FormInfo["M1jisya_hbn"]);
				// M1.Columns[9].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1old_jisya_hbn", lang), base.GetPageContext().FormInfo["M1old_jisya_hbn"]);
				// M1.Columns[10].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syohin_zokusei", lang), base.GetPageContext().FormInfo["M1syohin_zokusei"]);
				// M1.Columns[11].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1maker_hbn", lang), base.GetPageContext().FormInfo["M1maker_hbn"]);
				// M1.Columns[12].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1syonmk", lang), base.GetPageContext().FormInfo["M1syonmk"]);
				// M1.Columns[13].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1iro_nm", lang), base.GetPageContext().FormInfo["M1iro_nm"]);
				// M1.Columns[14].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1hanbaikanryo_ymd", lang), base.GetPageContext().FormInfo["M1hanbaikanryo_ymd"]);
				// M1.Columns[15].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1zeiritsu", lang), base.GetPageContext().FormInfo["M1zeiritsu"]);
				// M1.Columns[16].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1saisinbaika_tnk", lang), base.GetPageContext().FormInfo["M1saisinbaika_tnk"]);
				// M1.Columns[17].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1genka", lang), base.GetPageContext().FormInfo["M1genka"]);
				// M1.Columns[18].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1genbaika_tnk", lang), base.GetPageContext().FormInfo["M1genbaika_tnk"]);
				// M1.Columns[19].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1makerkakaku_tnk", lang), base.GetPageContext().FormInfo["M1makerkakaku_tnk"]);
				// M1.Columns[20].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1selectorcheckbox", lang), base.GetPageContext().FormInfo["M1selectorcheckbox"]);
				// M1.Columns[21].HeaderText = 
					// DataFormatUtil.GetFormatListCaption(formResource.GetString("M1entersyoriflg", lang), base.GetPageContext().FormInfo["M1entersyoriflg"]);
				// M1.Columns[22].HeaderText = 
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
				Windowtitle.InnerText = formResource.GetString("Th010f01_Titlebar", lang);
				header.FormName = formResource.GetString("Th010f01_FormCaption", lang);
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
