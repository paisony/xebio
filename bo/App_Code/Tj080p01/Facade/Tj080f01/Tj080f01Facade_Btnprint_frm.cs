//---------------------------------------------------------
// 標準
//---------------------------------------------------------
//---------------------------------------------------------
// com.xebio.bo.Common
//---------------------------------------------------------
using com.xebio.bo.Tj080p01.Constant;
using com.xebio.bo.Tj080p01.Formvo;
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

namespace com.xebio.bo.Tj080p01.Facade
{
  ///----------------------------------------------------------------------------------
  /// <summary>
  /// Facadeクラス：Tj080f01
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  ///----------------------------------------------------------------------------------
  public partial class Tj080f01Facade : StandardBaseFacade
	{
		#region フォームを呼び出します。(ボタンID : Btnprint)
		///------------------------------------------------------------------------------
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnprint)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		///------------------------------------------------------------------------------
		public void DoBTNPRINT_FRM(IFacadeContext facadeContext)
		{
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNPRINT_FRM");

			try
			{
				//=========================================================
				// DBコネクション
				//=========================================================

				#region DBコネクション

				// DBコンテキストを設定する。
				SetDBContext(facadeContext);

				// コネクションを取得して、トランザクションを開始する。
				OpenConnection(facadeContext);

				// ログイン情報取得
				LoginInfoVO loginInfVO = LoginInfoUtil.GetLoginInfo();

				#endregion

				//=========================================================
				// 画面情報の取得
				//=========================================================

				#region 画面情報の取得

				// FormVO取得
				// 画面より情報を取得する。
				Tj080f01Form formVO = (Tj080f01Form)facadeContext.FormVO;
				IDataList m1List = formVO.GetList("M1");

				#endregion

				//=========================================================
				// CSV出力
				//=========================================================

				#region 印刷用CSV作成

				//------------------------------------
				//
				// 主となるCSVデータ格納Listの宣言
				//
				//------------------------------------

				// 例）
				// 1行目：列名
				// 2行目：データ１
				// 3行目：データ２

				// CSV出力用リスト
				IList<IList<string>> csvList = new List<IList<string>>();

				//------------------------------------
				//
				// 列名となる一行を設定
				//
				//------------------------------------

				// CSVファイルの先頭一行となる列名を設定
				IList<string> csvColumnListData = new List<string>();
				csvColumnListData.Add("H棚卸確定日");
				csvColumnListData.Add("M店舗コード");
				csvColumnListData.Add("M店舗名");
				csvColumnListData.Add("M送信確定日");
				csvColumnListData.Add("M店舗確定状況区分");
				csvColumnListData.Add("M店舗確定状況名");
				csvColumnListData.Add("MMD送信状況区分");
				csvColumnListData.Add("MMD送信状況名");

				// リストに列名の行を追加
				csvList.Add(csvColumnListData);

				//------------------------------------
				//
				// データとなる行を順に設定
				//
				//------------------------------------

				// 画面入力条件から取得したデータだけ繰り返す
				for (int i = 0; i < m1List.Count; i++)
				{
					// データを取得
					Tj080f01M1Form m1formVO = (Tj080f01M1Form)m1List[i];

					// 一行分のCSVデータとなるListの初期化
					IList<string> csvListData = new List<string>();

					// Listにデータを追加
					// ※csvColumnListDataで設定した列名と追加する順番を合わせる
					// ※Addする順番に合わせてCSVにデータが書き込まれる

					// 棚卸確定日
					csvListData.Add(BoSystemFormat.formatDate((string)m1formVO.Dictionary[Tj080p01Constant.DIC_M1TANAOROSIKAKUTEI_YMD]));
					
					// 店舗コード
					csvListData.Add(BoSystemFormat.formatTenpoCd(m1formVO.M1tenpo_cd));
					
					// 店舗名
					csvListData.Add(m1formVO.M1tenpo_nm);

					// 送信確定日
					csvListData.Add(BoSystemFormat.formatDate(m1formVO.M1sosin_kak_ymd));

					// 店舗確定状況区分
					csvListData.Add(m1formVO.M1tenpo_kakutei_jyokyo);
					
        			// 店舗確定状況名
					csvListData.Add(m1formVO.M1tenpo_kakutei_jyokyo_nm);
					
					// MD送信状況区分
					csvListData.Add(m1formVO.M1md_sosin_jyokyo);
					
					// MD送信状況名
					csvListData.Add(m1formVO.M1md_sosin_jyokyo_nm);

					// 一行分のCSVデータをListに格納
					csvList.Add(csvListData);
				}

				//------------------------------------
				//
				// CSV出力処理
				//
				//------------------------------------

				// 帳票印刷用CSV作成
				string csvnm = BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_TANAOROSIJOKYOKAKUNINLIST_X);

				// CSV出力
				string csvFilePath = BoSystemCsvUtil.PrinterCsvOut(csvList, PGID, csvnm, CsvUtil.DELIMITER.COMMA);

				#endregion

				//=========================================================
				// PDF出力
				//=========================================================

				#region 印刷処理

				// PDFファイル名
				string pdfFileNm = string.Empty;

				// 帳票ツールに渡すパラメータを格納	
				BoSystemReport reportCls = new BoSystemReport();

				// 入力データ
				InputData inputData = new InputData();

				// 条件を設定
				OutputInfo output = new OutputInfo();
				
				//------------------------------------
				//
				// PDF出力処理
				//
				//------------------------------------
				
				// PDFファイル名
				pdfFileNm = string.Format("{0}.{1}",
											BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_TANAOROSIJOKYOKAKUNINLIST_X),
											BoSystemConstant.RPT_PDF_EXTENSION
											);

				// 帳票を出力
				output = reportCls.MdGenerateCsvToPDF(inputData,
														BoSystemConstant.REPORTID_TANAOROSIJOKYOKAKUNINLIST_X,
														Tj080p01Constant.FORMID_01,
														Tj080p01Constant.PGID,
														pdfFileNm,
														csvFilePath
														);
				#endregion

				//=========================================================
				// 件数チェック
				//=========================================================
				
				#region 件数チェック

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

				//=========================================================
				// ユーザマップ設定
				//=========================================================

				#region ユーザマップ設定

				// PDFをファイルをユーザマップに設定
				facadeContext.UserMap.Add(Tj080p01Constant.FCDUO_RRT_FLNM, pdfFileNm);

				#endregion
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
