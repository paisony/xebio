using com.xebio.bo.Tf070p01.Constant;
using com.xebio.bo.Tf070p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C01000.C01019;
using Common.Business.C99999.ConfigUtil;
using Common.Business.C99999.Constant;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.ReportUtil;
using Common.IntegrationMD.Report;
using Common.ListFactory.Model;
using Common.Standard.Base;
using Common.Standard.Message;
using System.Collections.Generic;
using System.IO;

namespace com.xebio.bo.Tf070p01.Facade
{
  /// <summary>
  /// Tf070f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tf070f01Facade : StandardBaseFacade
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
				////コネクションを取得して、トランザクションを開始する。
				//BeginTransactionWithConnect(facadeContext);
				OpenConnection(facadeContext);

				//以下に業務ロジックを記述する。

				// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
				#region 初期化
				// FormVO取得
				// 画面より情報を取得する。
				Tf070f01Form f01VO = (Tf070f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// 選択行リスト
				List<Tf070f01M1Form> selRowList = new List<Tf070f01M1Form>();
				#endregion

				#region 選択行チェック
				// 1-1 選択状態
				// 1件も選択されていない場合、エラー
				for (int i = 0; i < m1List.Count; i++)
				{
					// 明細行オブジェクト取得
					Tf070f01M1Form m1Form = (Tf070f01M1Form)m1List[i];

					if (m1Form.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
					{
						// 明細選択フラグがONの場合
						selRowList.Add(m1Form);
					}
				}

				if (selRowList.Count == 0)
				{
					// 印刷する行を選択して下さい。
					ErrMsgCls.AddErrMsg("E119", "印刷する行", facadeContext);
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region 印刷処理
				// PDFファイル名
				string pdfFileNm = string.Empty;
				// 退避検索条件を取得
				string tenpocd = f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_cd)] as string;

				// 帳票ツールに渡すパラメータ
				InputData inputData = new InputData();
				OutputInfo output = new OutputInfo();
				BoSystemReport reportCls = new BoSystemReport();
				// 複数ファイルダウンロード用ディレクトリパス
				string multiDownloadPath = BoSystemConfig.GetConfgiVal(BoSystemConstant.DOWNLOAD_FOLDER_PATH);
				// 出力PDFファイル名のリスト
				List<string> pdfFileNmList = new List<string>();

				// Xの場合、店舗控えの出力は行わない
				string tenpohikae_f = Tf070p01Constant.TENPO_HIKAE_FLG_ON;	// 出力あり
				if (CheckCompanyCls.IsXebio())
				{
					tenpohikae_f = Tf070p01Constant.TENPO_HIKAE_FLG_OFF;	// 出力なし
				}

				foreach (Tf070f01M1Form selRow in selRowList)
				{
					// 店舗コード
					inputData.AddScreenParameter(1, tenpocd);
					// 管理番号
					inputData.AddScreenParameter(2, selRow.Dictionary[Tf070p01Constant.DIC_M1KANRI_NO]);
					// 処理日付
					inputData.AddScreenParameter(3, selRow.Dictionary[Tf070p01Constant.DIC_M1SYORI_YMD]);
					// 印刷モード
					inputData.AddScreenParameter(4, Tf070p01Constant.PRINT_MODE_SHOKAI);	// 照会
					// 店舗控えフラグ
					inputData.AddScreenParameter(5, tenpohikae_f);
				}

				// PDFファイル名
				pdfFileNm = string.Format(
					"{0}.{1}",
					BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_SYOHINTOUNANJIKOHOKOKUSYO),
					BoSystemConstant.RPT_PDF_EXTENSION
					);

				// 帳票を出力
				output = reportCls.MdGeneratePDF(
					inputData,
					BoSystemConstant.REPORTID_SYOHINTOUNANJIKOHOKOKUSYO,
					Tf070p01Constant.FORMID_01,
					Tf070p01Constant.PGID,
					pdfFileNm
					);

				pdfFileNm = string.Format(
					"{0}.{1}",
					BoSystemReport.CreateFileName(BoSystemConstant.REPORTNM_SYOHINTOUNANJIKOHOKOKUSYO),
					BoSystemConstant.RPT_PDF_EXTENSION
					);

				if (!string.IsNullOrEmpty(output.TransferFile))
				{
					// 出力されたPDFを複数ファイルダウンロード用ディレクトリにコピー
					File.Copy(output.TransferFile, multiDownloadPath + Path.DirectorySeparatorChar + pdfFileNm);
				}

				// ファイル名をリストに追加
				pdfFileNmList.Add(pdfFileNm);

				#endregion

				#region 対象件数チェック
				BoSystemLog.logOut("ReportState［" + output.ReportState + "］");
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

				// PDFをファイルをユーザマップに設定
				//facadeContext.UserMap.Add(Tf070p01Constant.FCDUO_RRT_FLNM, pdfFileNm);
				// 出力PDFファイル名のリストをユーザマップに設定
				facadeContext.UserMap.Add(Tf070p01Constant.FCDUO_RRT_FLNM, pdfFileNmList);

				// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

				////トランザクションをコミットする。
				//CommitTransaction(facadeContext);
			}
			catch (System.Exception ex)
			{
				////トランザクションをロールバックする。
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
