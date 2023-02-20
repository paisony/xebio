using com.xebio.bo.Aa010p01.Constant;
using com.xebio.bo.Aa010p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.ReportUtil;
using Common.IntegrationMD.Report;
using Common.ListFactory.Model;
using Common.Standard.Base;
using Common.Standard.Login;

namespace com.xebio.bo.Aa010p01.Facade
{
  /// <summary>
  /// Aa010f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Aa010f01Facade : StandardBaseFacade
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

			#region 初期化

			// ログイン情報取得
			LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

			// FormVO取得
			// 画面より情報を取得する。
			Aa010f01Form f01VO = (Aa010f01Form)facadeContext.FormVO;
			IDataList m1List = f01VO.GetList("M1");

			#endregion


			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得して、トランザクションを開始する。
				BeginTransactionWithConnect(facadeContext);

				//以下に業務ロジックを記述する。


				#region 印刷処理
				string pdfFileNm = "";
				// 退避検索条件を取得
				string tenpocd = f01VO.Head_tenpo_cd;

				string[] wkk = f01VO.Report_dl.Split(':');
				string ReportId = wkk[0];	// 帳票ID
				string ReportNm = wkk[1];	// 帳票名

				// 帳票パラメータ設定 --------------------------------
				// 帳票ツールに渡すパラメータを格納
				InputData inputData = new InputData();
				#region ■帳票パラメータ設定
				switch (ReportId) {
					// ↓ここに各帳票毎のパラメータ設定を記述 ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

					#region 返品伝票
					case "TD010L01":

						// 店舗コード
						inputData.AddScreenParameter(1, BoSystemFormat.formatTenpoCd(tenpocd));
						// 伝票番号
						inputData.AddScreenParameter(2, "455014");
						// 処理日付
						inputData.AddScreenParameter(3, "20130919");
						// 店舗控え出力フラグ
						inputData.AddScreenParameter(4, "1");

						// 店舗コード
						inputData.AddScreenParameter(1, BoSystemFormat.formatTenpoCd(tenpocd));
						// 伝票番号
						inputData.AddScreenParameter(2, "455015");
						// 処理日付
						inputData.AddScreenParameter(3, "20130919");

						break;
					#endregion

					// ↑ここに各帳票毎のパラメータ設定を記述 ↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

				}
				#endregion
				// 帳票パラメータ設定 --------------------------------

				// 印刷処理
				OutputInfo output = new OutputInfo();
				BoSystemReport reportCls = new BoSystemReport();
				// PDFファイル名
				pdfFileNm = string.Format("{0}.{1}",
											BoSystemReport.CreateFileName(ReportId),
											BoSystemConstant.RPT_PDF_EXTENSION
											);
				// 帳票を出力
				output = reportCls.MdGeneratePDF(inputData,
												ReportId,
												Aa010p01Constant.FORMID_01,
												Aa010p01Constant.PGID,
												pdfFileNm
												);


				#endregion

				// PDFをファイルをユーザマップに設定
				facadeContext.UserMap.Add(Aa010p01Constant.FCDUO_RRT_FLNM, pdfFileNm);

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
