using com.xebio.bo.Tj090p01.Constant;
using com.xebio.bo.Tj090p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.ReportUtil;
using Common.IntegrationMD.Report;
using Common.ListFactory.Model;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;

namespace com.xebio.bo.Tj090p01.Facade
{
  /// <summary>
  /// Tj090f02のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tj090f02Facade : StandardBaseFacade
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
                Tj090f02Form formVO = (Tj090f02Form)facadeContext.FormVO;
                IDataList m1List = formVO.GetList("M1");

                #region 業務チェック

                #region 1. 件数チェック

				//// 1-1 対象件数
				////       1件も選択されていない場合、エラー 
				//if (m1List == null || m1List.Count <= 0)
				//{
				//	// 印刷する行を選択して下さい。
				//	ErrMsgCls.AddErrMsg("E119", "印刷する行", facadeContext);
				//}
				//else
				//{
				//	int inputflg = 0;
				//	for (int i = 0; i < m1List.Count; i++)
				//	{
				//		Tj090f02M1Form m1formVO = (Tj090f02M1Form)m1List[i];
				//		if (m1formVO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
				//		{
				//			inputflg = 1;
				//			break;
				//		}
				//	}
				//	if (inputflg == 0)
				//	{
				//		// 印刷する行を選択して下さい。
				//		ErrMsgCls.AddErrMsg("E119", "印刷する行", facadeContext);
				//	}
				//}

				////エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				//if (MessageDisplayUtil.HasError(facadeContext))
				//{
				//	return;
				//}

                #endregion

                #endregion

                #region 印刷処理

                string pdfFileNm = string.Empty;

                // 帳票ツールに渡すパラメータを格納
                InputData inputData = new InputData();
                OutputInfo output   = new OutputInfo();

                // PDFファイル名
                pdfFileNm = string.Format("{0}.{1}",
                                          BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_TANAOROSIITIRANHYO_X),
                                          BoSystemConstant.RPT_PDF_EXTENSION
                                         );

				// パラメタを配列形式で格納します
				// 店舗/業者区分
				inputData.AddScreenParameter(1, "1");
				// 店舗コード
				inputData.AddScreenParameter(2, BoSystemFormat.formatTenpoCd(formVO.Head_tenpo_cd));
				// フェイスNo
				inputData.AddScreenParameter(3, BoSystemFormat.formatFaceNo(formVO.Face_no));
				// 棚段
				inputData.AddScreenParameter(4, (string)formVO.Tana_dan);
				// 回数
				inputData.AddScreenParameter(5, (string)formVO.Kai_su);
				// 棚卸日
				inputData.AddScreenParameter(6, BoSystemFormat.formatDate((string)formVO.Dictionary[Tj090p01Constant.DIC_TANAOROSI_YMD]));
				// 送信回数
				inputData.AddScreenParameter(7, (string)formVO.Dictionary[Tj090p01Constant.DIC_SOSINKAI_SU]);

                // 帳票を出力
                BoSystemReport reportCls = new BoSystemReport();
				output = reportCls.MdGeneratePDF(inputData,
												 BoSystemConstant.REPORTID_TANAOROSIITIRANHYO_X,
												 Tj090p01Constant.FORMID_02,
												 Tj090p01Constant.PGID,
												 pdfFileNm
												);

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
				facadeContext.UserMap.Add(Tj090p01Constant.FCDUO_RRT_FLNM, pdfFileNm);

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
