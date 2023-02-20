using com.xebio.bo.Tk020p01.Constant;
using com.xebio.bo.Tk020p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C01000.C01019;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.ReportUtil;
using Common.IntegrationMD.Report;
using Common.ListFactory.Model;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;

namespace com.xebio.bo.Tk020p01.Facade
{
  /// <summary>
  /// Tk020f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tk020f01Facade : StandardBaseFacade
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
				//コネクションを取得する。
				OpenConnection(facadeContext);

				//以下に業務ロジックを記述する。

				#region 初期化
				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Tk020f01Form f01VO = (Tk020f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");
				#endregion

				#region 業務チェック

				// 選択行チェックは行わず、カード部の条件で出力する
				//// 選択行チェック
				//int inputflg = 0;
				//for (int i = 0; i < m1List.Count; i++)
				//{
				//	Tk020f01M1Form f01m1VO = (Tk020f01M1Form)m1List[i];
				//	if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
				//	{
				//		inputflg = 1;
				//		break;
				//	}
				//}
				//if (inputflg == 0)
				//{
				//	// {印刷する行}を選択して下さい。
				//	ErrMsgCls.AddErrMsg("E119", "印刷する行", facadeContext);
				//}

				////エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				//if (MessageDisplayUtil.HasError(facadeContext))
				//{
				//	return;
				//}
				#endregion

				#region 印刷処理
				string pdfFileNm = "";

				// 帳票ツールに渡すパラメータを格納
				InputData inputData = new InputData();
				// [FROMID]
				inputData.AddScreenParameter(1, Tk020p01Constant.PGID);
				// [店舗コード]
				inputData.AddScreenParameter(2, BoSystemFormat.formatTenpoCd(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_cd)].ToString()));
				// [処理月]
				inputData.AddScreenParameter(3, f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Syori_ym)].ToString());
				// [承認状態]
				inputData.AddScreenParameter(4, f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Kyakka_flg)].ToString());
				// ↓↓評価損確定画面で使用するパラメータ、この画面からは空白を設定する↓↓
				// 評価損種別区分
				inputData.AddScreenParameter(5, string.Empty);
				// 申請日
				inputData.AddScreenParameter(6, string.Empty);
				// 再申請フラグ
				inputData.AddScreenParameter(7, string.Empty);		


				// カード部の条件で出力する
				//for (int i = 0; i < m1List.Count; i++)
				//{
				//	Tk020f01M1Form f01m1VO = (Tk020f01M1Form)m1List[i];

				//	// 選択明細のみ対象
				//	if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
				//	{
				//		// [店舗コード]
				//		inputData.AddScreenParameter(1, (string)f01VO.Dictionary[SearchConditionSaveCls.PREFIX + "HEAD_TENPO_CD"]);
				//		// [処理月]
				//		inputData.AddScreenParameter(2, (string)f01VO.Dictionary[SearchConditionSaveCls.PREFIX + "SYORI_YM"]);
				//		// [承認状態]
				//		inputData.AddScreenParameter(3, f01m1VO.Dictionary[Tk020p01Constant.DIC_SYONIN_JOTAI_KB].ToString());
				//		// [評価損種別区分]
				//		inputData.AddScreenParameter(4, f01m1VO.Dictionary[Tk020p01Constant.DIC_HYOKASONSYUBETSU_KB].ToString());
				//		// [申請日]
				//		inputData.AddScreenParameter(5, f01m1VO.Dictionary[Tk020p01Constant.DIC_APPLY_YMD].ToString());
				//		// [再申請フラグ]
				//		inputData.AddScreenParameter(6, f01m1VO.Dictionary[Tk020p01Constant.DIC_SAISHINSEI_FLG].ToString());
				//	}
				//}

				// 帳票を出力
				OutputInfo output = new OutputInfo();
				BoSystemReport reportCls = new BoSystemReport();

				// 会社コードで評価損確定一覧表を出力
				if(CheckCompanyCls.IsXebio())
				{
					// PDFファイル名
					pdfFileNm = string.Format("{0}.{1}",
												BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_HYOKASONKAKUTEIITIRANHYO_X),
												BoSystemConstant.RPT_PDF_EXTENSION
												);
					// 帳票を出力
					output = reportCls.MdGeneratePDF(inputData,
													BoSystemConstant.REPORTID_HYOKASONKAKUTEIITIRANHYO_X,
													Tk020p01Constant.FORMID_01,
													Tk020p01Constant.PGID,
													pdfFileNm
													);
				}
				else
				{
					// PDFファイル名
					pdfFileNm = string.Format("{0}.{1}",
												BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_HYOKASONKAKUTEIITIRANHYO_V),
												BoSystemConstant.RPT_PDF_EXTENSION
												);
					// 帳票を出力
					output = reportCls.MdGeneratePDF(inputData,
													BoSystemConstant.REPORTID_HYOKASONKAKUTEIITIRANHYO_V,
													Tk020p01Constant.FORMID_01,
													Tk020p01Constant.PGID,
													pdfFileNm
													);
				}

				#region 件数チェック
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

				#endregion

				// PDFをファイルをユーザマップに設定
				facadeContext.UserMap.Add(Tk020p01Constant.FCDUO_RRT_FLNM, pdfFileNm);

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
