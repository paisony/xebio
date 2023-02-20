using com.xebio.bo.Tf050p01.Constant;
using com.xebio.bo.Tf050p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.ReportUtil;
using Common.Business.V01000.V01001;
using Common.Business.V03000.V03001;
using Common.IntegrationMD.Report;
using Common.ListFactory.Model;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using System;
using System.Collections;

namespace com.xebio.bo.Tf050p01.Facade
{
  /// <summary>
  /// Tf050f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tf050f01Facade : StandardBaseFacade
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

			////メソッドの開始処理を実行する。
            StartMethod(facadeContext, this.GetType().Name + ".DoBTNPRINT_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得して、トランザクションを開始する。
                //BeginTransactionWithConnect(facadeContext);
                //コネクションを取得する。
                OpenConnection(facadeContext);

				//以下に業務ロジックを記述する。
                #region 初期化

                // ログイン情報取得
                LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

                // FormVO取得
                // 画面より情報を取得する。
                Tf050f01Form f05VO = (Tf050f01Form)facadeContext.FormVO;

				//業務日付を取得する
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);
				DateTime date = DateTime.Parse(sysDateVO.Sysdate.ToString().Insert(4, "/").Insert(7, "/"));

				//6ヶ月前の年月を取得する
				string chkNengetsu = new DateTime(date.Year, date.Month, 1).AddMonths(-6).ToString("yyMM");

                #endregion

                #region 業務チェック

                #region 単項目チェック
                // 1-1 ヘッダ店舗コード
                //       店舗マスタを検索し、存在しない場合エラー
                if (!string.IsNullOrEmpty(f05VO.Head_tenpo_cd))
                {
                    Hashtable resultHash = new Hashtable();
                    resultHash = V01001Check.CheckTenpo(
                        f05VO.Head_tenpo_cd,
                        facadeContext, 
                        "店舗", 
                        new[] { "Head_tenpo_cd" }
                        );
                }

				// 1-2 出力期間From
				//       6ヶ月以前が入力された場合、エラー
				if (!string.IsNullOrEmpty(f05VO.Kikan_from))
				{
					if (BoSystemFormat.formatDate_yyMM(f05VO.Kikan_from).CompareTo(chkNengetsu) < 0)
					{
						// 期間Fromに6ヶ月以前は入力できません。。
						ErrMsgCls.AddErrMsg("E231", "出力期間From", facadeContext, new[] { "Kikan_from" });
					}
				}

				// 1-3 出力期間To
				//       6ヶ月以前が入力された場合、エラー
				if (!string.IsNullOrEmpty(f05VO.Kikan_to))
				{
					if (BoSystemFormat.formatDate_yyMM(f05VO.Kikan_to).CompareTo(chkNengetsu) < 0)
					{
						// 期間Toに6ヶ月以前は入力できません。。
						ErrMsgCls.AddErrMsg("E231", "出力期間To", facadeContext, new[] { "Kikan_to" });
					}
				}
            
                //エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
                if (MessageDisplayUtil.HasError(facadeContext))
                {
					return;
                }
                
                #endregion
                
                #region 関連項目チェック
                 //2-1期間FROM、期間TO
                 //      期間FROM > 期間ＴＯの場合エラー
                if (!string.IsNullOrEmpty(f05VO.Kikan_from) && !string.IsNullOrEmpty(f05VO.Kikan_to))
                {
                    V03001Check.DateFromToChk(
                        f05VO.Kikan_from,
                        f05VO.Kikan_to,
                        facadeContext,
                        "出力期間",
                        new[] { "Kikan_from", "Kikan_to" }
                        );
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
				BoSystemReport reportCls = new BoSystemReport();
				InputData inputData = new InputData();
				OutputInfo output = new OutputInfo();

				// PDFファイル名
				pdfFileNm = string.Format("{0}.{1}",
											BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_KOGUTIGENKINSUITOTYO),
											BoSystemConstant.RPT_PDF_EXTENSION
											);

				//画面区分
				inputData.AddScreenParameter(1, "2");
				//店舗コード
				inputData.AddScreenParameter(2, BoSystemFormat.formatTenpoCd(f05VO.Head_tenpo_cd));
				//出力期間From
				inputData.AddScreenParameter(3, BoSystemFormat.formatDate(f05VO.Kikan_from));
				//出力期間To
				inputData.AddScreenParameter(4, BoSystemFormat.formatDate(f05VO.Kikan_to));
				//予備
				inputData.AddScreenParameter(5, "");

				// 帳票を出力
				output = reportCls.MdGeneratePDF(inputData,
												BoSystemConstant.REPORTID_KOGUTIGENKINSUITOTYO,
												Tf050p01Constant.FORMID_01,
												Tf050p01Constant.PGID,
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
				facadeContext.UserMap.Add(Tf050p01Constant.FCDUO_RRT_FLNM, pdfFileNm);

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
