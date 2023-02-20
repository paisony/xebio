using com.xebio.bo.Tj120p01.Constant;
using com.xebio.bo.Tj120p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.ReportUtil;
using Common.IntegrationMD.Report;
using Common.ListFactory.Model;
using Common.Standard.Base;
using Common.Standard.Message;
using System;

namespace com.xebio.bo.Tj120p01.Facade
{
  /// <summary>
  /// Tj120f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tj120f01Facade : StandardBaseFacade
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
				BeginTransactionWithConnect(facadeContext);

				//以下に業務ロジックを記述する。

				#region 初期化
				//カード部を取得します。
				Tj120f01Form f01VO = (Tj120f01Form)facadeContext.FormVO;

				#endregion

				#region 業務チェック
				#endregion

				#region 印刷処理

				#region 帳票パラメータ設定
				// 帳票ツールに渡すパラメータを格納
				InputData inputData = new InputData();

				///棚卸重複リスト(V)クエリプラグインです。
				/// ■パラメータ
				/// ① 店舗コード
				/// ② 棚卸基準日
				/// ③ フェイスNoFROM
				/// ④ フェイスNoTO
				/// ⑤ 入力担当者コード
				/// ⑥ 入力日FROM
				/// ⑦ 入力日TO 

				//[ヘッダ店舗コード]																								
				inputData.AddScreenParameter(1, BoSystemFormat.formatTenpoCd((string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_cd)]));
				//[棚卸基準日]
				inputData.AddScreenParameter(2, BoSystemFormat.formatDate((string)f01VO.Dictionary[Tj120p01Constant.DIC_TANAOROSIKIJUN_YMD]));
				//[フェイスNoFROM]
				inputData.AddScreenParameter(3, BoSystemFormat.formatFaceNo((string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Face_no_from)]));
				//[フェイスNoTO]
				inputData.AddScreenParameter(4, BoSystemFormat.formatFaceNo((string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Face_no_to)]));
				//[入力担当者コード]
				inputData.AddScreenParameter(5, BoSystemFormat.formatTantoCd((string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Nyuryokutan_cd)]));
				//[入力日From]
				inputData.AddScreenParameter(6, BoSystemFormat.formatDate((string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Nyuryoku_ymd_from)]));
				//[入力日To]
				inputData.AddScreenParameter(7, BoSystemFormat.formatDate((string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Nyuryoku_ymd_to)]));

				#endregion

				#region 印刷部品
				// 印刷処理
				string pdfFileNm = "";
				OutputInfo output = new OutputInfo();
				BoSystemReport reportCls = new BoSystemReport();
				// PDFファイル名
				pdfFileNm = string.Format("{0}.{1}",
											BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_TANAOROSIJUFUKULIST_V),
											BoSystemConstant.RPT_PDF_EXTENSION
											);
				// CSV区切り文字をタブに設定
				inputData.CsvSeparator = "\t";
				// 帳票を出力
				BoSystemLog.logOut("帳票出力部品起動 START");
				output = reportCls.MdGeneratePDF(inputData,
												BoSystemConstant.REPORTID_TANAOROSIJUFUKULIST_V,
												Tj120p01Constant.FORMID_01,
												Tj120p01Constant.PGID,
												pdfFileNm
												);
				BoSystemLog.logOut("帳票出力部品起動 END");
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
				facadeContext.UserMap.Add(Tj120p01Constant.FCDUO_RRT_FLNM, pdfFileNm);
				#endregion 
				
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
