using com.xebio.bo.Tj130p01.Constant;
using com.xebio.bo.Tj130p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.ReportUtil;
using Common.IntegrationMD.Report;
using Common.ListFactory.Model;
using Common.Standard.Base;
using Common.Standard.Message;
using System;

namespace com.xebio.bo.Tj130p01.Facade
{
  /// <summary>
  /// Tj130f02のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tj130f02Facade : StandardBaseFacade
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
		
			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNPRINT_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得して、トランザクションを開始する。
				BeginTransactionWithConnect(facadeContext);
			
				//以下に業務ロジックを記述する。

				#region 初期化
				//カード部を取得します。
				Tj130f02Form f02VO = (Tj130f02Form)facadeContext.FormVO;

				// 選択行を取得します。
				Tj130f01M1Form prevM1Vo = (Tj130f01M1Form)f02VO.Dictionary[Tj130p01Constant.DIC_M1SELCETVO];

				#endregion

				#region 業務チェック
				#endregion

				#region 印刷処理

				#region 帳票パラメータ設定
				// 帳票ツールに渡すパラメータを格納
				InputData inputData = new InputData();
				/// ■パラメータ
				/// ①店舗/業者区分 ：1固定
				/// ②店舗コード	
				/// ③ﾌｪｲｽNo		
				/// ④棚段			
				/// ⑤回数			
				/// ⑥棚卸日		
				/// ⑦送信回数


				//[店舗/業者区分]
				inputData.AddScreenParameter(1, "1");
				//[ヘッダ店舗コード]																								
				inputData.AddScreenParameter(2, BoSystemFormat.formatTenpoCd(f02VO.Head_tenpo_cd));
				//[フェイスNo]
				inputData.AddScreenParameter(3, BoSystemFormat.formatFaceNo(prevM1Vo.M1face_no));
				//[棚段]
				inputData.AddScreenParameter(4, prevM1Vo.M1tana_dan);
				//[回数]
				inputData.AddScreenParameter(5, prevM1Vo.M1kai_su);
				//[棚卸日]
				inputData.AddScreenParameter(6, BoSystemFormat.formatDate((string)prevM1Vo.Dictionary[Tj130p01Constant.DIC_M1TANAOROSI_YMD]));
				//[送信回数]
				inputData.AddScreenParameter(7, (string)prevM1Vo.Dictionary[Tj130p01Constant.DIC_M1SOSINKAI_SU]);



				#endregion

				#region 印刷部品
				// 印刷処理
				string pdfFileNm = "";
				OutputInfo output = new OutputInfo();
				BoSystemReport reportCls = new BoSystemReport();
				// PDFファイル名
				pdfFileNm = string.Format("{0}.{1}",
											BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_TANAOROSIITIRANHYO_X),
											BoSystemConstant.RPT_PDF_EXTENSION
											);
				// 帳票を出力
				output = reportCls.MdGeneratePDF(inputData,
												BoSystemConstant.REPORTID_TANAOROSIITIRANHYO_X,
												Tj130p01Constant.FORMID_02,
												Tj130p01Constant.PGID,
												pdfFileNm
												);
				if (output.ReportState == ReportState.DataNotFound)
				{
					// 検索結果が0件の場合エラー
					ErrMsgCls.AddErrMsg("E174", String.Empty, facadeContext);
				}
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}



				#endregion 印刷部品

				// PDFをファイルをユーザマップに設定
				facadeContext.UserMap.Add(Tj130p01Constant.FCDUO_RRT_FLNM, pdfFileNm);
				#endregion 

				//トランザクションをコミットする。
			//	CommitTransaction(facadeContext);
			}
			catch (System.Exception ex)
			{
				//トランザクションをロールバックする。
			//	RollbackTransaction(facadeContext);
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
