using com.xebio.bo.Tf021p01.Constant;
using com.xebio.bo.Tf021p01.Formvo;
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

namespace com.xebio.bo.Tf021p01.Facade
{
  /// <summary>
  /// Tf021f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tf021f01Facade : StandardBaseFacade
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
			//	//コネクションを取得して、トランザクションを開始する。
			//	BeginTransactionWithConnect(facadeContext);
				//コネクションを取得する。
				OpenConnection(facadeContext);
				
				//以下に業務ロジックを記述する。
				#region 初期化

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Tf021f01Form f01VO = (Tf021f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// Dictionaryから検索条件を取得
				String tenpoCd = BoSystemFormat.formatTenpoCd((string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_cd)]);

				#endregion

				#region 行数チェック

				if (m1List == null || m1List.Count <= 0)
				{
					// 印刷する行を選択して下さい。
					ErrMsgCls.AddErrMsg("E119", "印刷する行", facadeContext);
				}
				else
				{
					int inputflg = 0;
					for (int i = 0; i < m1List.Count; i++)
					{
						Tf021f01M1Form f01m1VO = (Tf021f01M1Form)m1List[i];

						// 選択行の場合
						if (BoSystemConstant.CHECKBOX_ON.Equals(f01m1VO.M1selectorcheckbox))
						{
							inputflg = 1;
						}
					}

					if (inputflg == 0)
					{
						// 印刷する行を選択して下さい。
						ErrMsgCls.AddErrMsg("E119", "印刷する行", facadeContext);
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region 印刷処理

				// 帳票ツールに渡すパラメータを格納

				InputData inputData = new InputData();

				for (int i = 0; i < m1List.Count; i++)
				{
					Tf021f01M1Form f01m1VO = (Tf021f01M1Form)m1List[i];

					// 選択明細、かつテーブル区分が0以外の場合対象
					if (   BoSystemConstant.CHECKBOX_ON.Equals(f01m1VO.M1selectorcheckbox)
						&& !"0".Equals(f01m1VO.Dictionary[Tf021p01Constant.DIC_M1TBLFLG].ToString()))
					{
						// 店舗コード
						inputData.AddScreenParameter(1, BoSystemFormat.formatTenpoCd(tenpoCd));
						// 処理日付
						inputData.AddScreenParameter(2, BoSystemFormat.formatDate(f01m1VO.Dictionary[Tf021p01Constant.DIC_M1SYORI_YMD].ToString()));
						// 伝票番号
						inputData.AddScreenParameter(3, BoSystemFormat.formatDenpyoNo(f01m1VO.Dictionary[Tf021p01Constant.DIC_M1DENPYO_BANGO].ToString()));
						// テーブル区分
						inputData.AddScreenParameter(4, f01m1VO.Dictionary[Tf021p01Constant.DIC_M1TBLFLG].ToString());
						// 会社コード
						inputData.AddScreenParameter(5, logininfo.CopCd);
						// 店舗控え出力フラグ
						inputData.AddScreenParameter(6, "1");
					}
				}

				string pdfFileNm = string.Empty;
				OutputInfo output = new OutputInfo();
				BoSystemReport reportCls = new BoSystemReport();

				// PDFファイル名
				pdfFileNm = string.Format("{0}.{1}",
											BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_SYOHINKEIHIFURIKAEDENPYO_X),
											BoSystemConstant.RPT_PDF_EXTENSION
											);
				// 帳票を出力
				output = reportCls.MdGeneratePDF(inputData,
												BoSystemConstant.REPORTID_SYOHINKEIHIFURIKAEDENPYO_X,
												Tf021p01Constant.FORMID_01,
												Tf021p01Constant.PGID,
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
				facadeContext.UserMap.Add(Tf021p01Constant.FCDUO_RRT_FLNM, pdfFileNm);

			//	//トランザクションをコミットする。
			//	CommitTransaction(facadeContext);
			}
			catch (System.Exception ex)
			{
			//	//トランザクションをロールバックする。
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
