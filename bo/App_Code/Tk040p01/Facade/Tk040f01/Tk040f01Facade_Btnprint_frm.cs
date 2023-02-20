using com.xebio.bo.Tk040p01.Constant;
using com.xebio.bo.Tk040p01.Formvo;
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

namespace com.xebio.bo.Tk040p01.Facade
{
  /// <summary>
  /// Tk040f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tk040f01Facade : StandardBaseFacade
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
				Tk040f01Form formVO = (Tk040f01Form)facadeContext.FormVO;
				IDataList m1List = formVO.GetList("M1");

				#region 業務チェック

				#endregion

				#region 印刷処理



				string pdfFileNm = string.Empty;

				// 帳票ツールに渡すパラメータを格納
				InputData inputData = new InputData();

				// 退避検索条件を取得
				string tenpocd = BoSystemFormat.formatTenpoCd((string)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Head_tenpo_cd)]);

				string bumoncd_from = BoSystemFormat.formatBumonCd((string)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Bumon_cd_from)]);
				string bumoncd_to   = BoSystemFormat.formatBumonCd((string)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Bumon_cd_to)]);

				string hanbaikanryoymd_from = BoSystemFormat.formatDate((string)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Hanbaikanryo_ymd_from)]);
				string hanbaikanryoymd_to   = BoSystemFormat.formatDate((string)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Hanbaikanryo_ymd_to)]);

				string jisyahbn1 = BoSystemFormat.formatJisyaHbn((string)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Old_jisya_hbn)]);
				string jisyahbn2 = BoSystemFormat.formatJisyaHbn((string)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Old_jisya_hbn2)]);
				string jisyahbn3 = BoSystemFormat.formatJisyaHbn((string)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Old_jisya_hbn3)]);
				string jisyahbn4 = BoSystemFormat.formatJisyaHbn((string)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Old_jisya_hbn4)]);
				string jisyahbn5 = BoSystemFormat.formatJisyaHbn((string)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Old_jisya_hbn5)]);

				string scancd1 = BoSystemFormat.formatJanCd((string)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Scan_cd)]);
				string scancd2 = BoSystemFormat.formatJanCd((string)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Scan_cd2)]);
				string scancd3 = BoSystemFormat.formatJanCd((string)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Scan_cd3)]);
				string scancd4 = BoSystemFormat.formatJanCd((string)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Scan_cd4)]);
				string scancd5 = BoSystemFormat.formatJanCd((string)formVO.Dictionary[SearchConditionSaveCls.GetKey(() => formVO.Scan_cd5)]);

				// パラメータ設定
				// 店舗コード
				inputData.AddScreenParameter(1, BoSystemFormat.formatTenpoCd(tenpocd));
				// 部門コードFROM
				inputData.AddScreenParameter(2, BoSystemFormat.formatBumonCd(bumoncd_from));
				// 部門コードTO
				inputData.AddScreenParameter(3, BoSystemFormat.formatBumonCd(bumoncd_to));
				// 販売日FROM
				inputData.AddScreenParameter(4, BoSystemFormat.formatDate(hanbaikanryoymd_from));
				// 販売日TO
				inputData.AddScreenParameter(5, BoSystemFormat.formatDate(hanbaikanryoymd_to));
				// 自社品番１
				inputData.AddScreenParameter(6, BoSystemFormat.formatJisyaHbn(jisyahbn1));
				// 自社品番２
				inputData.AddScreenParameter(7, BoSystemFormat.formatJisyaHbn(jisyahbn2));
				// 自社品番３
				inputData.AddScreenParameter(8, BoSystemFormat.formatJisyaHbn(jisyahbn3));
				// 自社品番４
				inputData.AddScreenParameter(9, BoSystemFormat.formatJisyaHbn(jisyahbn4));
				// 自社品番５
				inputData.AddScreenParameter(10, BoSystemFormat.formatJisyaHbn(jisyahbn5));
				// スキャンコード１
				inputData.AddScreenParameter(11, BoSystemFormat.formatJanCd(scancd1));
				// スキャンコード２
				inputData.AddScreenParameter(12, BoSystemFormat.formatJanCd(scancd2));
				// スキャンコード３
				inputData.AddScreenParameter(13, BoSystemFormat.formatJanCd(scancd3));
				// スキャンコード４
				inputData.AddScreenParameter(14, BoSystemFormat.formatJanCd(scancd4));
				// スキャンコード５
				inputData.AddScreenParameter(15, BoSystemFormat.formatJanCd(scancd5));
				// 棚卸基準日
				inputData.AddScreenParameter(16, BoSystemFormat.formatDate((string)formVO.Dictionary[Tk040p01Constant.DIC_TANAOROSHIKIJUNYMD]));


				OutputInfo output = new OutputInfo();

				// PDFファイル名
				pdfFileNm = string.Format("{0}.{1}",
											BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_LOCATIONLIST),
											BoSystemConstant.RPT_PDF_EXTENSION
											);

				// 帳票を出力
				BoSystemReport reportCls = new BoSystemReport();
				output = reportCls.MdGeneratePDF(inputData,
													 BoSystemConstant.REPORTID_LOCATIONLIST,
													 Tk040p01Constant.FORMID_01,
													 Tk040p01Constant.PGID,
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
				facadeContext.UserMap.Add(Tk040p01Constant.FCDUO_RRT_FLNM, pdfFileNm);

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
