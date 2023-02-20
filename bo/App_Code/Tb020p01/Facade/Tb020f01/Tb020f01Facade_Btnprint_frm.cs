using com.xebio.bo.Tb020p01.Constant;
using com.xebio.bo.Tb020p01.Formvo;
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

namespace com.xebio.bo.Tb020p01.Facade
{
  /// <summary>
  /// Tb020f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tb020f01Facade : StandardBaseFacade
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
				Tb020f01Form f01VO = (Tb020f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");
				#endregion

				#region 業務チェック

				#region 選択行/件数チェック

				if (m1List == null || m1List.Count <= 0)
				{
					// 抽出件数は0件です。
					ErrMsgCls.AddErrMsg("E174", String.Empty, facadeContext);
				}
				else
				{
					int inputflg = 0;
					for (int i = 0; i < m1List.Count; i++)
					{
						Tb020f01M1Form f01m1VO = (Tb020f01M1Form)m1List[i];
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
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#endregion

				#region 印刷処理

				string pdfFileNm = "";

				// 退避検索条件を取得
				string scm_jotai = (string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Scm_jotai)];

				// 帳票ツールに渡すパラメータを格納
				BoSystemReport reportCls = new BoSystemReport();
				InputData inputData = new InputData();
				OutputInfo output = new OutputInfo();

				// PDFファイル名
				pdfFileNm = string.Format("{0}.{1}",
											BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_SCMSIIRENYUKALIST),
											BoSystemConstant.RPT_PDF_EXTENSION
											);

				for (int i = 0; i < m1List.Count; i++)
				{
					Tb020f01M1Form f01m1VO = (Tb020f01M1Form)m1List[i];

					// 選択明細のみ対象
					if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
					{
						// SCM状態（未処理/確定）
						inputData.AddScreenParameter(1, scm_jotai);
						// 店舗コード
						inputData.AddScreenParameter(2, BoSystemFormat.formatTenpoCd(f01m1VO.Dictionary[Tb020p01Constant.DIC_M1TENPO_CD].ToString()));
						// SCMコード
						inputData.AddScreenParameter(3, BoSystemFormat.formatScmCd(f01m1VO.Dictionary[Tb020p01Constant.DIC_M1SCM_CD].ToString()));
						// 納入先着予定日
						inputData.AddScreenParameter(4, BoSystemFormat.formatDate(f01m1VO.Dictionary[Tb020p01Constant.DIC_M1NONYUTYAKUYOTEI_YMD].ToString()));
					}
				}

				// 帳票を出力
				output = reportCls.MdGeneratePDF(inputData,
												BoSystemConstant.REPORTID_SCMSIIRENYUKALIST,
												Tb020p01Constant.FORMID_01,
												Tb020p01Constant.PGID,
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
				facadeContext.UserMap.Add(Tb020p01Constant.FCDUO_RRT_FLNM, pdfFileNm);

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
