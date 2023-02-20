using com.xebio.bo.Tj060p01.Constant;
using com.xebio.bo.Tj060p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.ReportUtil;
using Common.Business.V01000.V01019;
using Common.Conditions;
using Common.IntegrationMD.Report;
using Common.ListFactory.Model;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using System;
using System.Collections;

namespace com.xebio.bo.Tj060p01.Facade
{
  /// <summary>
  /// Tj060f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tj060f01Facade : StandardBaseFacade
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

				#region 初期化
				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				//カード部を取得します。
				Tj060f01Form f01VO = (Tj060f01Form)facadeContext.FormVO;

				#endregion

				#region 業務チェック

				#region ① ヘッダ店舗コード
				// 店舗マスタを検索し、存在しない場合エラー
				if (!string.IsNullOrEmpty(f01VO.Head_tenpo_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01019Check.CheckTenpoTanaorosijissiYmd(f01VO.Head_tenpo_cd, f01VO.Modeno, "1", facadeContext, "店舗", new[] { "Head_tenpo_cd" });
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Head_tenpo_nm = (string)resultHash["TENPO_NM"];
						f01VO.Tanaorosikijun_ymd = resultHash["TANAOROSIKIJUN_YMD_KONKAI"].ToString();
						f01VO.Tanaorosijissi_ymd = resultHash["TANAOROSIJISSI_YMD_KONKAI"].ToString();
						f01VO.Tanaorosikikan_from = resultHash["TANAOROSIKIKAN_FROM_KONKAI"].ToString();
						f01VO.Tanaorosikikan_to = resultHash["TANAOROSIKIKAN_TO_KONAKI"].ToString();
						f01VO.Tanaorosikijun_ymd1 = resultHash["TANAOROSIKIJUN_YMD_ZENKAI"].ToString();
						f01VO.Tanaorosijissi_ymd1 = resultHash["TANAOROSIJISSI_YMD_ZENKAI"].ToString();
						f01VO.Tanaorosikikan_from1 = resultHash["TANAOROSIKIKAN_FROM_ZENKAI"].ToString();
						f01VO.Tanaorosikikan_to1 = resultHash["TANAOROSIKIKAN_TO_ZENKAI"].ToString();
					}
				}
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#endregion

				#region 印刷処理

				// 帳票ID
				string pdfFileId = string.Empty;
				// 帳票名
				string pdfFileNm = String.Empty;
				// 帳票ツールに渡すパラメータを格納
				InputData inputData = new InputData();
				OutputInfo output = new OutputInfo();
				BoSystemReport reportCls = new BoSystemReport();

				#region ■帳票パラメータ設定

				// 店舗コード
				inputData.AddScreenParameter(1, BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));

				#endregion

				#region ■対象帳票ID、PDF名称を取得
				if (f01VO.Tanaorosi_hokokusyo_kb == ConditionTanaorosi_hokokusyo_x.VALUE_TANAOROSI_HOKOKUSYO_X1)
				{
					// 棚卸集計表
					// ■パラメータ
					// ① 店舗コード
					// ② 棚卸日
					// ③ 棚卸日FROM
					// ④ 棚卸日TO
					// ⑤ 送信済みフラグ(1:未送信データのみ出力 2: 送信済みデータのみを出力 (未設定)：両方とも出力)

					if (f01VO.Modeno == BoSystemConstant.MODE_KONKAI)
					{
						// モード今回の場合、今回_棚卸日を設定
						inputData.AddScreenParameter(2, f01VO.Tanaorosikijun_ymd);
						inputData.AddScreenParameter(3, f01VO.Tanaorosikikan_from);
						inputData.AddScreenParameter(4, f01VO.Tanaorosikikan_to);

					}
					else if (f01VO.Modeno == BoSystemConstant.MODE_ZENKAI)
					{
						// モード前回の場合、前回_棚卸日を設定
						inputData.AddScreenParameter(2, f01VO.Tanaorosikijun_ymd1);
						inputData.AddScreenParameter(3, f01VO.Tanaorosikikan_from1);
						inputData.AddScreenParameter(4, f01VO.Tanaorosikikan_to1);
					}
					inputData.AddScreenParameter(5, "2");

					pdfFileId = BoSystemConstant.REPORTID_TANAOROSISYUKEIHYO_X;
					pdfFileNm = string.Format("{0}.{1}",
											BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_TANAOROSISYUKEIHYO_X),
											BoSystemConstant.RPT_PDF_EXTENSION
											);
				}
				else if (f01VO.Tanaorosi_hokokusyo_kb == ConditionTanaorosi_hokokusyo_x.VALUE_TANAOROSI_HOKOKUSYO_X2)
				{
					// 棚卸欠番報告書
					// ■パラメータ
					// ① 店舗コード
					// ② フェイスNoFrom
					// ③ フェイスNoTo
					// ④ 棚卸基準日


					if (f01VO.Modeno == BoSystemConstant.MODE_KONKAI)
					{
						// モード今回の場合、今回_棚卸日を設定
						inputData.AddScreenParameter(2, "-1");
						inputData.AddScreenParameter(3, "-1");
						inputData.AddScreenParameter(4, f01VO.Tanaorosikijun_ymd);

					}
					else if (f01VO.Modeno == BoSystemConstant.MODE_ZENKAI)
					{
						// モード前回の場合、前回_棚卸日を設定
						inputData.AddScreenParameter(2,"-1");
						inputData.AddScreenParameter(3,"-1");
						inputData.AddScreenParameter(4, f01VO.Tanaorosikijun_ymd1);
					}

					pdfFileId = BoSystemConstant.REPORTID_TANAOROSIKETUBANHOKOKUSYO_X;
					pdfFileNm = string.Format("{0}.{1}",
											BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_TANAOROSIKETUBANHOKOKUSYO_X),
											BoSystemConstant.RPT_PDF_EXTENSION
											);
				}
				else if (f01VO.Tanaorosi_hokokusyo_kb == ConditionTanaorosi_hokokusyo_x.VALUE_TANAOROSI_HOKOKUSYO_X3)
				{
					// 棚卸訂正報告書
					// ■パラメータ
					// ① 店舗コード
					// ② 棚卸日
					// ③ 送信済みフラグ(1:未送信データのみ出力 2: 送信済みデータのみを出力 (未設定)：両方とも出力)
		
					if (f01VO.Modeno == BoSystemConstant.MODE_KONKAI)
					{
						// モード今回の場合、今回_棚卸日を設定
						inputData.AddScreenParameter(2, f01VO.Tanaorosikijun_ymd);

					}
					else if (f01VO.Modeno == BoSystemConstant.MODE_ZENKAI)
					{
						// モード前回の場合、前回_棚卸日を設定
						inputData.AddScreenParameter(2, f01VO.Tanaorosikijun_ymd1);
					}

					inputData.AddScreenParameter(3, "2");

					pdfFileId = BoSystemConstant.REPORTID_TANAOROSITEISEIHOKOKUSYO_X;
					pdfFileNm = string.Format("{0}.{1}",
											BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_TANAOROSITEISEIHOKOKUSYO_X),
											BoSystemConstant.RPT_PDF_EXTENSION
											);
				}
				else if (f01VO.Tanaorosi_hokokusyo_kb == ConditionTanaorosi_hokokusyo_x.VALUE_TANAOROSI_HOKOKUSYO_X4)
				{
					// 棚卸修正報告書
					// ■パラメータ
					// ①店舗コード
					// ②棚卸日
					// ③送信日
					// ④送信済みフラグ(1:未送信データのみ出力 2: 送信済みデータのみを出力 (未設定)：両方とも出力)
					if (f01VO.Modeno == BoSystemConstant.MODE_KONKAI)
					{
						// モード今回の場合、今回_棚卸日を設定
						inputData.AddScreenParameter(2, f01VO.Tanaorosikijun_ymd);
						inputData.AddScreenParameter(3, f01VO.Tanaorosijissi_ymd);

					}
					else if (f01VO.Modeno == BoSystemConstant.MODE_ZENKAI)
					{
						// モード前回の場合、前回_棚卸日を設定
						inputData.AddScreenParameter(2, f01VO.Tanaorosikijun_ymd1);
						inputData.AddScreenParameter(3, f01VO.Tanaorosijissi_ymd1);
					}
					inputData.AddScreenParameter(4, "2");

					pdfFileId = BoSystemConstant.REPORTID_TANAOROSISYUSEIHOKOKUSYO_X;
					pdfFileNm = string.Format("{0}.{1}",
											BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_TANAOROSISYUSEIHOKOKUSYO_X),
											BoSystemConstant.RPT_PDF_EXTENSION
											);
				}

				#endregion

				// 帳票出力
				output = reportCls.MdGeneratePDF(inputData,
												pdfFileId,
												Tj060p01Constant.FORMID_01,
												Tj060p01Constant.PGID,
												pdfFileNm
												);

				if (output.ReportState == ReportState.DataNotFound)
				{
					// 検索結果が0件の場合エラー
					ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
				}
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
	
				// PDFをファイルをユーザマップに設定
				facadeContext.UserMap.Add(Tj060p01Constant.FCDUO_RRT_FLNM, pdfFileNm);

				#endregion
			
						
			}
			catch (System.Exception ex)
			{
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
