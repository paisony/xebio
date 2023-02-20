using com.xebio.bo.Te010p01.Constant;
using com.xebio.bo.Te010p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.ReportUtil;
using Common.IntegrationMD.Report;
using Common.ListFactory.Model;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;

namespace com.xebio.bo.Te010p01.Facade
{
  /// <summary>
  /// Te010f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Te010f01Facade : StandardBaseFacade
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
				Te010f01Form f01VO = (Te010f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				#endregion

				#region 業務チェック
				// 行数チェック
				// 行数チェック
				ChkRowCount(facadeContext, m1List, logininfo, Te010p01Constant.CHECK_MODE_BTNPRINT);
				// ------------------------------------------------------------------------------------
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				// ------------------------------------------------------------------------------------
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
											BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_IDOUSYUKKADENPYO),
											BoSystemConstant.RPT_PDF_EXTENSION
											);

				for (int i = 0; i < m1List.Count; i++)
				{
					Te010f01M1Form f01m1VO = (Te010f01M1Form)m1List[i];

					// 選択明細のみ対象
					if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
					{
						// Dictionary.[Ｍ１参照テーブル]が"2"(移動出荷履歴TBL)の行 または
						// ログイン情報．権限が、"2"（店舗）で、Dictionary.[Ｍ１送信済フラグ]が"1"(送信済)の行
						if (Te010p01Constant.REF_TBL_RIREKI.Equals(f01m1VO.Dictionary[Te010p01Constant.DIC_REF_TBL].ToString())
						|| (logininfo.Kengenkbn == BoSystemConstant.TANTO_KENGEN_TENCHO && BoSystemConstant.SOSINZUMI_FLG_SOSINZUMI.Equals(f01m1VO.Dictionary[Te010p01Constant.DIC_M1SOSINZUMI_FLG].ToString())))
						{
							// 次の行
							continue;
						}
						else
						{
							//出荷店コード
							inputData.AddScreenParameter(1, BoSystemFormat.formatTenpoCd(f01m1VO.Dictionary[Te010p01Constant.DIC_M1TENPO_CD].ToString()));
							//出荷会社コード
							inputData.AddScreenParameter(2, f01m1VO.Dictionary[Te010p01Constant.DIC_M1SYUKKAKAISYA_CD].ToString());
							//伝票番号
							inputData.AddScreenParameter(3, f01m1VO.Dictionary[Te010p01Constant.DIC_M1DENPYO_BANGO].ToString());
							//出荷日
							inputData.AddScreenParameter(4, f01m1VO.Dictionary[Te010p01Constant.DIC_M1SYUKKA_YMD].ToString());
							// 店舗控えフラグ(0:印刷なし)
							inputData.AddScreenParameter(5, "0");
						}
					}
				}

				// 帳票を出力
				output = reportCls.MdGeneratePDF(inputData,
												BoSystemConstant.REPORTID_IDOUSYUKKADENPYO,
												Te010p01Constant.FORMID_01,
												Te010p01Constant.PGID,
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
				facadeContext.UserMap.Add(Te010p01Constant.FCDUO_RRT_FLNM, pdfFileNm);

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
