using com.xebio.bo.Tg070p01.Constant;
using com.xebio.bo.Tg070p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01008;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.ReportUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V01000.V01001;
using Common.Business.V03000.V03001;
using Common.IntegrationMD.Report;
using Common.ListFactory.Model;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Data;

namespace com.xebio.bo.Tg070p01.Facade
{
  /// <summary>
  /// Tg070f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tg070f01Facade : StandardBaseFacade
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

				//以下に業務ロジックを記述する。

				#region 初期化

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Tg070f01Form f01VO = (Tg070f01Form)facadeContext.FormVO;

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);
				#endregion

				#region 業務チェック
				// 1-1 ヘッダ店舗コード
				// 店舗マスタを検索し、存在しない場合エラー V01001			
				if (!string.IsNullOrEmpty(f01VO.Head_tenpo_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01001Check.CheckTenpo(f01VO.Head_tenpo_cd, facadeContext, "店舗", new[] { "Head_tenpo_cd" });
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Head_tenpo_nm = (string)resultHash["TENPO_NM"];
					}
				}
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				// 2-1 振替日付FROM-振替日付TO
				// 振替日付FROM > 振替日付TOの場合、エラー V03001			
				if (!string.IsNullOrEmpty(f01VO.Hurikae_ymd_from) && !string.IsNullOrEmpty(f01VO.Hurikae_ymd_to))
				{
					V03001Check.DateFromToChk(
									f01VO.Hurikae_ymd_from,
									f01VO.Hurikae_ymd_to,
									facadeContext,
									"振替日",
									new[] { "Hurikae_ymd_from", "Hurikae_ymd_to" }
									);
				}
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region 印刷処理
				// 帳票パラメータ設定
				InputData inputData = new InputData();
				// 会社コード	
				// 店舗コード	
				// 振替日付From	
				// 振替日付To	
				// 印刷済みフラグ

				inputData.AddScreenParameter(1, logininfo.CopCd.ToString());
				inputData.AddScreenParameter(2, BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
				inputData.AddScreenParameter(3, BoSystemFormat.formatDate(f01VO.Hurikae_ymd_from));
				inputData.AddScreenParameter(4, BoSystemFormat.formatDate(f01VO.Hurikae_ymd_to));
				inputData.AddScreenParameter(5, "1");

				// 印刷処理
				OutputInfo output = new OutputInfo();
				BoSystemReport reportCls = new BoSystemReport();
				string pdfFileNm = string.Empty;

				// PDFファイル名
				pdfFileNm = string.Format("{0}.{1}",
											BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_INSUTOACODEFURIKAELIST),
											BoSystemConstant.RPT_PDF_EXTENSION
											);
				// 帳票を出力
				output = reportCls.MdGeneratePDF(inputData,
												BoSystemConstant.REPORTID_INSUTOACODEFURIKAELIST,
												Tg070p01Constant.FORMID,
												Tg070p01Constant.PGID,
												pdfFileNm
												);

				// 3-1 対象件数 
				// 対象件数が0件の場合エラー E145 -								
				if (output.ReportState == ReportState.FatalError || output.ReportState == ReportState.DataNotFound || output.ReportState == ReportState.MaxRecord)
				{
					// 対象件数が0件の場合、エラーtteir
					ErrMsgCls.AddErrMsg("E174", String.Empty, facadeContext);
				}
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion
				// PDFをファイルをユーザマップに設定
				facadeContext.UserMap.Add(Tg070p01Constant.FCDUO_RRT_FLNM, pdfFileNm);

				#region 更新処理
				// ログイン権限が店舗の場合、[インストアコード振替データTBL]を更新する。
				// 権限取得部品の戻り値が"FALSE"の場合
				if (!CheckKengenCls.CheckKengen(logininfo))
				{
					// XMLからSQLを取得する。
					FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable("TG070P01-01", facadeContext.DBContext);

					reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
					reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
					reader.BindValue("BIND_KAISYA_CD", decimal.Parse(logininfo.CopCd));
					reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
					reader.BindValue("BIND_HURIKAE_YMD_FROM", decimal.Parse(BoSystemString.Nvl(BoSystemFormat.formatDate(f01VO.Hurikae_ymd_from), "0")));
					reader.BindValue("BIND_HURIKAE_YMD_TO", decimal.Parse(BoSystemString.Nvl(BoSystemFormat.formatDate(f01VO.Hurikae_ymd_to), "99999999")));

					//クエリを実行する。
					using (IDbCommand cmd = reader.CreateDbCommand())
					{
						cmd.ExecuteNonQuery();
					}
				}
				#endregion
				//トランザクションをコミットする。
				CommitTransaction(facadeContext);
			}
			catch (System.Exception ex)
			{
				//トランザクションをロールバックする。
				RollbackTransaction(facadeContext);
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
