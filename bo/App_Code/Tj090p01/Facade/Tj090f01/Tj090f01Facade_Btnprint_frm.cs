using com.xebio.bo.Tj090p01.Constant;
using com.xebio.bo.Tj090p01.Formvo;
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

namespace com.xebio.bo.Tj090p01.Facade
{
  /// <summary>
  /// Tj090f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tj090f01Facade : StandardBaseFacade
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
                Tj090f01Form formVO = (Tj090f01Form)facadeContext.FormVO;
                IDataList m1List = formVO.GetList("M1");

                #region 業務チェック

                #region 1. 選択行チェック

                //// 1-1 対象件数
                ////       1件も選択されていない場合、エラー 
                //if (m1List == null || m1List.Count <= 0)
                //{
                //    // 印刷する行を選択して下さい。
                //    ErrMsgCls.AddErrMsg("E119", "印刷する行", facadeContext);
                //}
                //else
                //{
                //    int inputflg = 0;
                //    for (int i = 0; i < m1List.Count; i++)
                //    {
                //        Tj090f01M1Form m1formVO = (Tj090f01M1Form)m1List[i];
                //        if (m1formVO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
                //        {
                //            inputflg = 1;
                //            break;
                //        }
                //    }
                //    if (inputflg == 0)
                //    {
                //        // 印刷する行を選択して下さい。
                //        ErrMsgCls.AddErrMsg("E119", "印刷する行", facadeContext);
                //    }
                //}

                ////エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
                //if (MessageDisplayUtil.HasError(facadeContext))
                //{
                //    return;
                //}

                #endregion

                #endregion

                #region 印刷処理

                string pdfFileNm = string.Empty;

                // 退避検索条件を取得
				// 店舗コード
                string tenpocd = BoSystemFormat.formatTenpoCd((string)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Head_tenpo_cd)]);
				// フェイスNoFROM
				string faceno_from = BoSystemFormat.formatFaceNo((string)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Face_no_from)]);
				// フェイスNoTO
				string faceno_to = BoSystemFormat.formatFaceNo((string)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Face_no_to)]);
				// 棚段NoFROM
				string tanadan_from = (string)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Tana_dan_from)];
				// 棚段NoTO
				string tanadan_to = (string)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Tana_dan_to)];
				// 入力担当者コード
				string nyuryokutancd = BoSystemFormat.formatTantoCd((string)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Nyuryokutan_cd)]);
				// 入力日FROM
				string nyuryokuymd_from = BoSystemFormat.formatDate((string)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Nyuryoku_ymd_from)]);
				// 入力日TO
				string nyuryokuymd_to = BoSystemFormat.formatDate((string)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Nyuryoku_ymd_to)]);

                // 帳票ツールに渡すパラメータを格納
                InputData inputData = new InputData();
                OutputInfo output   = new OutputInfo();

                // PDFファイル名
                pdfFileNm = string.Format("{0}.{1}",
                                          BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_TANAOROSIUNMATCHLIST_X),
                                          BoSystemConstant.RPT_PDF_EXTENSION
                                         );

				// パラメタを配列形式で格納します
				// 店舗コード
				inputData.AddScreenParameter(1, BoSystemFormat.formatTenpoCd(tenpocd));
				// 棚卸基準日
				inputData.AddScreenParameter(2, (string)formVO.Dictionary[Tj090p01Constant.DIC_TANAOROSIKIJUN_YMD]);
				// フェイスNoFROM
				inputData.AddScreenParameter(3, BoSystemFormat.formatFaceNo(faceno_from));
				// フェイスNoTO
				inputData.AddScreenParameter(4, BoSystemFormat.formatFaceNo(faceno_to));
				// 棚段NoFROM
				inputData.AddScreenParameter(5, tanadan_from);
				// 棚段NoTO
				inputData.AddScreenParameter(6, tanadan_to);
				// 入力担当者コード
				inputData.AddScreenParameter(7, BoSystemFormat.formatTantoCd(nyuryokutancd));
				// 入力日FROM
				inputData.AddScreenParameter(8, BoSystemFormat.formatDate(nyuryokuymd_from));
				// 入力日TO
				inputData.AddScreenParameter(9, BoSystemFormat.formatDate(nyuryokuymd_to));

                // 帳票を出力
                BoSystemReport reportCls = new BoSystemReport();
				output = reportCls.MdGeneratePDF(inputData,
												 BoSystemConstant.REPORTID_TANAOROSIUNMATCHLIST_X,
												 Tj090p01Constant.FORMID_01,
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
