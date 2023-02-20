using com.xebio.bo.Tj070p01.Constant;
using com.xebio.bo.Tj070p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C99999.Constant;
using Common.Business.C99999.CsvUtil;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.ReportUtil;
using Common.IntegrationMD.Report;
using Common.ListFactory.Model;
using Common.Standard.Base;
using Common.Standard.Csv;
using Common.Standard.Login;
using Common.Standard.Message;
using System.Collections.Generic;

namespace com.xebio.bo.Tj070p01.Facade
{
  /// <summary>
  /// Tj070f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tj070f01Facade : StandardBaseFacade
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
				Tj070f01Form formVO = (Tj070f01Form)facadeContext.FormVO;
				IDataList m1List = formVO.GetList("M1");

				#region 業務チェック


				#endregion

				#region 印刷用CSV作成

				// CSV出力用リスト
				IList<IList<string>> csvList = new List<IList<string>>();

				for (int i = 0; i < m1List.Count; i++)
				{
					Tj070f01M1Form m1formVO = (Tj070f01M1Form)m1List[i];

					IList<string> csvListData = new List<string>();

					// 棚卸確定日
					csvListData.Add(BoSystemFormat.formatDate((string)m1formVO.Dictionary[Tj070p01Constant.DIC_M1TANAOROSIKAKUTEI_YMD]));
					// 店舗コード
					csvListData.Add(BoSystemFormat.formatTenpoCd(m1formVO.M1tenpo_cd));
					// 店舗名
					csvListData.Add(m1formVO.M1tenpo_nm);
					// HHT実施日
					csvListData.Add(BoSystemFormat.formatDate(m1formVO.M1hhtjissi_ymd));
					// 送信確定日
					csvListData.Add(BoSystemFormat.formatDate(m1formVO.M1sosin_kak_ymd));
					// 店舗確定状況区分
					csvListData.Add(m1formVO.M1tenpo_kakutei_jyokyo);
					// 店舗確定状況
					csvListData.Add(m1formVO.M1tenpo_kakutei_jotai_nm);
					// MD送信状況区分
					csvListData.Add(m1formVO.M1md_sosin_jyokyo);
					// MD送信状況
					csvListData.Add(m1formVO.M1sosin_jotai_nm);

					csvList.Add(csvListData);
				}

				// 帳票印刷用CSV作成
				string csvnm = BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_TANAOROSIJOKYOKAKUNINLIST_V);

				// CSV出力
				string csvFilePath = BoSystemCsvUtil.PrinterCsvOut(csvList, PGID, csvnm, CsvUtil.DELIMITER.PIPE);

				#endregion

				#region 印刷処理

				string pdfFileNm = string.Empty;

				// 帳票ツールに渡すパラメータを格納
				InputData inputData = new InputData();

				// 条件を設定
				OutputInfo output = new OutputInfo();
				// PDFファイル名
				pdfFileNm = string.Format("{0}.{1}",
											BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_TANAOROSIJOKYOKAKUNINLIST_V),
											BoSystemConstant.RPT_PDF_EXTENSION
											);

				// 帳票を出力
				BoSystemReport reportCls = new BoSystemReport();
				output = reportCls.MdGenerateCsvToPDF(inputData,
														BoSystemConstant.REPORTID_TANAOROSIJOKYOKAKUNINLIST_V,
														Tj070p01Constant.FORMID_01,
														Tj070p01Constant.PGID,
														pdfFileNm,
														csvFilePath
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
				facadeContext.UserMap.Add(Tj070p01Constant.FCDUO_RRT_FLNM, pdfFileNm);

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
