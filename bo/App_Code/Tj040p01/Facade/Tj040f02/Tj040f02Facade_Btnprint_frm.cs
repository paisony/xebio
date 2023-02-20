using com.xebio.bo.Tj040p01.Constant;
using com.xebio.bo.Tj040p01.Formvo;
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
using System;

namespace com.xebio.bo.Tj040p01.Facade
{
  /// <summary>
  /// Tj040f02のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tj040f02Facade : StandardBaseFacade
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
                Tj040f02Form formVO = (Tj040f02Form)facadeContext.FormVO;
                IDataList m1List = formVO.GetList("M1");

				// 前画面の選択行情報を取得する。
				// 一覧画面選択行のVO
				Tj040f01M1Form f01M1Form = (Tj040f01M1Form)formVO.Dictionary[Tj040p01Constant.DIC_M1SELCETVO];

                #region 業務チェック
                #endregion

                #region 印刷処理

				string pdfFileNm = string.Empty;

                // 帳票ツールに渡すパラメータを格納
                InputData inputData = new InputData();

				// 店舗コード Dictionaryより取得
				String tenpocd = BoSystemFormat.formatTenpoCd((string)formVO.Head_tenpo_cd);

				// パラメータ設定
				// 店舗／業者区分
				inputData.AddScreenParameter(1, (string)f01M1Form.Dictionary[Tj040p01Constant.DIC_M1TENPO_GYOSYA_KB]);
				// 店舗コード
				inputData.AddScreenParameter(2, BoSystemFormat.formatTenpoCd(tenpocd));
				// フェイスNo
				inputData.AddScreenParameter(3, (string)f01M1Form.Dictionary[Tj040p01Constant.DIC_M1FACE_NO]);
				// 棚段
				inputData.AddScreenParameter(4, (string)f01M1Form.M1tana_dan);
				// 回数
				inputData.AddScreenParameter(5, (string)f01M1Form.M1kai_su);
				// 棚卸日
				inputData.AddScreenParameter(6, (string)f01M1Form.Dictionary[Tj040p01Constant.DIC_M1TANAOROSI_YMD]);
				// 送信回数/処理日付
				inputData.AddScreenParameter(7, (string)f01M1Form.Dictionary[Tj040p01Constant.DIC_M1SOSINKAI_SU]);


				OutputInfo output = new OutputInfo();

                // PDFファイル名
                pdfFileNm = string.Format("{0}.{1}",
                                            BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_TANAOROSIITIRANHYO_X),
                                            BoSystemConstant.RPT_PDF_EXTENSION
                                            );

                // 帳票を出力
                BoSystemReport reportCls = new BoSystemReport();
				output = reportCls.MdGeneratePDF(inputData,
													BoSystemConstant.REPORTID_TANAOROSIITIRANHYO_X,
													Tj040p01Constant.FORMID_02,
													Tj040p01Constant.PGID,
													pdfFileNm
													);

                #region 件数チェック

				if (output.ReportState == ReportState.FatalError || output.ReportState == ReportState.DataNotFound || output.ReportState == ReportState.MaxRecord)
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
                facadeContext.UserMap.Add(Tj040p01Constant.FCDUO_RRT_FLNM, pdfFileNm);

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
