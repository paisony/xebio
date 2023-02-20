using com.xebio.bo.Tj030p01.Constant;
using com.xebio.bo.Tj030p01.Formvo;
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
using System;

namespace com.xebio.bo.Tj030p01.Facade
{
  /// <summary>
  /// Tj030f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tj030f01Facade : StandardBaseFacade
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
				OpenConnection(facadeContext);

				//以下に業務ロジックを記述する。

				#region 初期化

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Tj030f01Form f01VO = (Tj030f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				#endregion

				#region 業務チェック

				#region 行数チェック

				// 1-1 選択状態
				// 1件も選択されていない場合、エラー
				if (m1List == null || m1List.Count <= 0)
				{
					// 確定対象がありません。
					ErrMsgCls.AddErrMsg("E140", String.Empty, facadeContext);
				}
				else
				{
					int inputflg = 0;
					for (int i = 0; i < m1List.Count; i++)
					{
						Tj030f01M1Form f01m1VO = (Tj030f01M1Form)m1List[i];
						if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
						{
							inputflg = 1;
							break;
						}
					}
					if (inputflg == 0)
					{
						// 確定対象がありません。
						ErrMsgCls.AddErrMsg("E119", "印刷する行", facadeContext);
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
				string pdfFileNm = string.Empty;
				// 帳票ツールに渡すパラメータを格納
				InputData inputData = new InputData();

				// 店舗コード Dictionaryより取得
				String tenpocd = BoSystemFormat.formatTenpoCd((string)f01VO.Dictionary[SearchConditionSaveCls.PREFIX + Tj030p01Constant.DIC_TENPO_CD]);

				for (int i = 0; i < m1List.Count; i++)
				{
					Tj030f01M1Form f01m1VO = (Tj030f01M1Form)m1List[i];
					// Ｍ１選択フラグ(隠し)が"1"の場合、以下の処理を実施する。
					if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
					{
						// パラメタを配列形式で格納します
						// 店舗／業者区分
						inputData.AddScreenParameter(1, (string)f01m1VO.Dictionary[Tj030p01Constant.DIC_M1TENPO_GYOSYA_KB]);
						// 店舗コード
						inputData.AddScreenParameter(2, BoSystemFormat.formatTenpoCd(tenpocd));
						// フェイスNo
						inputData.AddScreenParameter(3, (string)f01m1VO.Dictionary[Tj030p01Constant.DIC_M1FACE_NO]);
						// 棚段
						inputData.AddScreenParameter(4, (string)f01m1VO.M1tana_dan);
						// 回数
						inputData.AddScreenParameter(5, (string)f01m1VO.M1kai_su);
						// 棚卸日
						inputData.AddScreenParameter(6, (string)f01m1VO.Dictionary[Tj030p01Constant.DIC_M1TANAOROSI_YMD]);
						// 送信回数/処理日付
						inputData.AddScreenParameter(7, (string)f01m1VO.Dictionary[Tj030p01Constant.DIC_M1SOSINKAI_SU]);

					}
				}

				OutputInfo output = new OutputInfo();
				BoSystemReport reportCls = new BoSystemReport();

				// PDFファイル名
				pdfFileNm = string.Format("{0}.{1}",
											BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_TANAOROSIITIRANHYO_V,1),
											BoSystemConstant.RPT_PDF_EXTENSION
											);
				// 帳票を出力
				output = reportCls.MdGeneratePDF(inputData,
												BoSystemConstant.REPORTID_TANAOROSIITIRANHYO_V,
												Tj030p01Constant.FORMID_01,
												Tj030p01Constant.PGID,
												pdfFileNm
												);
				
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

				// PDFをファイルをユーザマップに設定
				facadeContext.UserMap.Add(Tj030p01Constant.FCDUO_RRT_FLNM, pdfFileNm);

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
