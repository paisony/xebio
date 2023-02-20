using com.xebio.bo.Tg040p01.Constant;
using com.xebio.bo.Tg040p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.ReportUtil;
using Common.IntegrationMD.Report;
using Common.ListFactory.Model;
using Common.Standard.Base;
using Common.Standard.Message;

namespace com.xebio.bo.Tg040p01.Facade
{
  /// <summary>
  /// Tg040f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tg040f01Facade : StandardBaseFacade
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
				// FormVO取得
				// 画面より情報を取得する。
				Tg040f01Form f01VO = (Tg040f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");
				#endregion

				#region 業務チェック
				// [選択状態] 1件も選択されていない場合、エラー
				int inputflg = 0;
				for (int i = 0; i < m1List.Count; i++)
				{
					Tg040f01M1Form f01m1VO = (Tg040f01M1Form)m1List[i];
					if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
					{
						inputflg = 1;
						break;
					}
				}
				if (inputflg == 0)
				{
					// {印刷する行}を選択して下さい。
					ErrMsgCls.AddErrMsg("E119", "印刷する行", facadeContext);
				}
				
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region 印刷処理

				string pdfFileNm = "";

				// 帳票ツールに渡すパラメータを格納
				BoSystemReport reportCls = new BoSystemReport();
				InputData inputData = new InputData();
				OutputInfo output = new OutputInfo();

				// PDFファイル名
				pdfFileNm = string.Format("{0}.{1}",
											BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_SYOHINSTOCKMEISAISYO),
											BoSystemConstant.RPT_PDF_EXTENSION
											);

				for (int i = 0; i < m1List.Count; i++)
				{
					Tg040f01M1Form f01m1VO = (Tg040f01M1Form)m1List[i];

					// 選択明細のみ対象
					if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
					{
						// 店舗コード
						// TODO yusy 帳票出力するため一旦修正
						//inputData.AddScreenParameter(1, (string)f01VO.Dictionary[SearchConditionSaveCls.PREFIX + "HEAD_TENPO_CD"]);
						inputData.AddScreenParameter(1, BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
						// 管理No 
						inputData.AddScreenParameter(2, f01m1VO.Dictionary[Tg040p01Constant.DIC_KANRI_NO].ToString());
						// 処理日付
						inputData.AddScreenParameter(3, f01m1VO.Dictionary[Tg040p01Constant.DIC_SYORI_YMD].ToString());
					}
				}

				// 帳票を出力
				output = reportCls.MdGeneratePDF(inputData,
												BoSystemConstant.REPORTID_SYOHINSTOCKMEISAISYO,
												Tg040p01Constant.FORMID_01,
												Tg040p01Constant.PGID,
												pdfFileNm
												);

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
				facadeContext.UserMap.Add(Tg040p01Constant.FCDUO_RRT_FLNM, pdfFileNm);

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
