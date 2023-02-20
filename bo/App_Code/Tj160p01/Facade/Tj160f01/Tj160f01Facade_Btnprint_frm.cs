using com.xebio.bo.Tj160p01.Constant;
using com.xebio.bo.Tj160p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
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
using System;
using System.Collections.Generic;

namespace com.xebio.bo.Tj160p01.Facade
{
  /// <summary>
  /// Tj160f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tj160f01Facade : StandardBaseFacade
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

			////メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNPRINT_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得して、トランザクションを開始する。
				BeginTransactionWithConnect(facadeContext);
			
				//以下に業務ロジックを記述する。

				#region 初期化

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Tj160f01Form f01VO = (Tj160f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				#endregion

				#region 印刷用CSV作成

				// CSV出力用リスト
				IList<IList<string>> csvList = new List<IList<string>>();

				for (int i = 0; i < m1List.Count; i++)
				{
					Tj160f01M1Form f01m1VO = (Tj160f01M1Form)m1List[i];

					IList<string> csvListData = new List<string>();
					csvListData.Add(BoSystemFormat.formatTenpoCd(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_cd)].ToString()));	// 店舗コード
					csvListData.Add(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_nm)].ToString());									// 店舗名
					csvListData.Add(f01m1VO.M1face_no);			// フェイスNo
					csvListData.Add(f01m1VO.M1tana_dan);		// 棚段
					csvListData.Add(f01m1VO.M1tyohuku);			// 重複
					csvListData.Add(f01m1VO.M1tantosya_cd);		// 担当者コード
					csvListData.Add(f01m1VO.M1hanbaiin_nm);		// 担当者名
					csvListData.Add(f01m1VO.M1checklist_memo);	// メモ

					csvList.Add(csvListData);
				}

				// 帳票印刷用CSV作成
				string csvnm = BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_TANAOROSICHECKLIST_V);
				// CSV出力
				string csvFilePath = BoSystemCsvUtil.PrinterCsvOut(csvList, PGID, csvnm, CsvUtil.DELIMITER.TAB);

				#endregion

				#region 印刷処理
				string pdfFileNm = String.Empty;

				// 帳票ツールに渡すパラメータを格納	
				BoSystemReport reportCls = new BoSystemReport();
				InputData inputData = new InputData();

				// 店舗コード Dictionaryより取得
				string keyHeadTenpoCd = BoSystemFormat.formatTenpoCd(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_cd)].ToString());

				// 条件を設定
				OutputInfo output = new OutputInfo();
				// PDFファイル名
				pdfFileNm = string.Format("{0}.{1}",
											BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_TANAOROSICHECKLIST_V),
											BoSystemConstant.RPT_PDF_EXTENSION
											);

				// 帳票を出力
				output = reportCls.MdGenerateCsvToPDF(inputData,
														BoSystemConstant.REPORTID_TANAOROSICHECKLIST_V,
														Tj160p01Constant.FORMID_01,
														Tj160p01Constant.PGID,
														pdfFileNm,
														csvFilePath
														);

				// PDFをファイルをユーザマップに設定
				facadeContext.UserMap.Add(Tj160p01Constant.FCDUO_RRT_FLNM, pdfFileNm);

                // 出力件数
                if (output.ReportState == ReportState.FatalError || output.ReportState == ReportState.DataNotFound || output.ReportState == ReportState.MaxRecord)
                {
                    // 抽出件数は0件です。
                    ErrMsgCls.AddErrMsg("E174", "", facadeContext);
                }

                //エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
                if (MessageDisplayUtil.HasError(facadeContext))
                {
                    return;
                }

				#endregion

				//トランザクションをコミットする。
				CommitTransaction(facadeContext);
			}
			catch (System.Exception ex)
			{
				//トランザクションをロールバックする。
				RollbackTransaction(facadeContext);
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
