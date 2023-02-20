using com.xebio.bo.Tl010p01.Constant;
using com.xebio.bo.Tl010p01.Formvo;
using com.xebio.bo.Tl020p01.Constant;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.ReportUtil;
using Common.IntegrationMD.Report;
using Common.ListFactory.Model;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;

namespace com.xebio.bo.Tl010p01.Facade
{
  /// <summary>
  /// Tl010f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tl010f01Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : Btnprint)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnprint)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNPRINT_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNPRINT_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得して、トランザクションを開始する。
				//BeginTransactionWithConnect(facadeContext);
				OpenConnection(facadeContext);

				//以下に業務ロジックを記述する。

				// ログイン情報取得
				LoginInfoVO loginInfVO = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Tl010f01Form formVO = (Tl010f01Form)facadeContext.FormVO;
				IDataList m1List = formVO.GetList("M1");

				#region 業務チェック

				#region 1. 選択行チェック

				// 1-1 選択行
				//       1件も選択されていない場合、エラー 
				if (m1List == null || m1List.Count <= 0)
				{
					// 印刷する行を選択して下さい。
					ErrMsgCls.AddErrMsg("E119", "印刷する行", facadeContext);
				}
				else
				{
					int inputflg = 0;
					for (int i = 0; i < m1List.Count; i++)
					{
						Tl010f01M1Form m1formVO = (Tl010f01M1Form)m1List[i];
						if (m1formVO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
						{
							inputflg = 1;
							break;
						}
					}
					if (inputflg == 0)
					{
						// 印刷する行を選択して下さい。
						ErrMsgCls.AddErrMsg("E119", "印刷する行", facadeContext);
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#endregion

				#region 印刷処理

				string pdfFileNm = "";

				// 退避検索条件を取得
				string tenpocd = BoSystemFormat.formatTenpoCd((string)formVO.Dictionary[SearchConditionSaveCls.PREFIX + "Head_tenpo_cd".ToUpper()]);

				// 帳票ツールに渡すパラメータを格納
				InputData inputData = new InputData();
				OutputInfo output = new OutputInfo();

				// PDFファイル名
				pdfFileNm = string.Format("{0}.{1}",
											BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_BAIHENSAGYOSIJILIST_V),
											BoSystemConstant.RPT_PDF_EXTENSION
											);

				// 帳票出力テスト用
				// 1:店舗コード
				// 2:部門コードFrom
				// 3:部門コードTo
				// 4:開始日From
				// 5:開始日To
				//inputData.AddScreenParameter(1, BoSystemFormat.formatTenpoCd(tenpocd));
				//inputData.AddScreenParameter(2, BoSystemFormat.formatBumonCd(formVO.Bumon_cd_from));
				//inputData.AddScreenParameter(3, BoSystemFormat.formatBumonCd(formVO.Bumon_cd_to));
				//inputData.AddScreenParameter(4, BoSystemFormat.formatDate(formVO.Baihenkaisi_ymd_from));
				//inputData.AddScreenParameter(5, BoSystemFormat.formatDate(formVO.Baihenkaisi_ymd_to));


				for (int i = 0; i < m1List.Count; i++)
				{
					Tl010f01M1Form m1formVO = (Tl010f01M1Form)m1List[i];

					// 選択明細のみ対象
					if (BoSystemConstant.CHECKBOX_ON.Equals(m1formVO.M1selectorcheckbox))
					{
						// 店舗コード
						inputData.AddScreenParameter(1, BoSystemFormat.formatTenpoCd(tenpocd));
						// 売変開始日
						inputData.AddScreenParameter(2, BoSystemFormat.formatDate(m1formVO.M1baihenkaisi_ymd));
						// 部門コード
						inputData.AddScreenParameter(3, BoSystemFormat.formatBumonCd(m1formVO.Dictionary[Tl010p01Constant.DIC_M1BUMON_CD].ToString()));
						// 売変No
						inputData.AddScreenParameter(4, BoSystemFormat.formatBaihen_shiji_no(m1formVO.Dictionary[Tl010p01Constant.DIC_M1BAIHEN_NO].ToString()));

					}
				}

				// 帳票を出力
				BoSystemReport reportCls = new BoSystemReport();
				output = reportCls.MdGeneratePDF(inputData,
												 BoSystemConstant.REPORTID_BAIHENSAGYOSIJILIST_V,
												 Tl010p01Constant.FORMID_01,
												 Tl010p01Constant.PGID,
												 pdfFileNm
												);
				// output.ReportState = ReportState.DataNotFound;
				#region 件数チェック

				if (output.ReportState == ReportState.DataNotFound)
				{
					// 抽出件数は0件です。
					ErrMsgCls.AddErrMsg("E174", string.Empty, facadeContext);
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#endregion

				// PDFをファイルをユーザマップに設定
				facadeContext.UserMap.Add(Tl020p01Constant.FCDUO_RRT_FLNM, pdfFileNm);

				//トランザクションをコミットする。
				//CommitTransaction(facadeContext);
			}
			catch (System.Exception ex)
			{
				//トランザクションをロールバックする。
				//RollbackTransaction(facadeContext);
				//例外処理を実行する。
				ThrowException(ex, facadeContext);
			}
			finally
			{
				//コネクションを開放する。
				CloseConnection(facadeContext);
			}
			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNPRINT_FRM");

		}
		#endregion
	}
}
