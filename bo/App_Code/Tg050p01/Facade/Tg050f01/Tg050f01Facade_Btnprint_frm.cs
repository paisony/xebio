using com.xebio.bo.Tg050p01.Constant;
using com.xebio.bo.Tg050p01.Formvo;
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

namespace com.xebio.bo.Tg050p01.Facade
{
  /// <summary>
  /// Tg050f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tg050f01Facade : StandardBaseFacade
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
				BeginTransactionWithConnect(facadeContext);

				//以下に業務ロジックを記述する。

				#region 初期化
				// FormVO取得
				// 画面より情報を取得する。
				Tg050f01Form f05VO = (Tg050f01Form)facadeContext.FormVO;

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// システム日付取得
				SysDateVO SysDateVO = SysdateCls.GetSysdateTime(facadeContext);
				string strSysDate = SysDateVO.Sysdate.ToString();
				#endregion

				#region 業務チェック

				#region 単項目チェック
				// 1-1 ヘッダ店舗コード
				//       店舗マスタを検索し、存在しない場合エラー
				if (!string.IsNullOrEmpty(f05VO.Head_tenpo_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01001Check.CheckTenpo(f05VO.Head_tenpo_cd, facadeContext, "店舗", new[] { "Head_tenpo_cd" });

				}
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region 関連項目チェック
				// 2-1 登録日FROM、登録日TO
				//       登録日ＦＲＯＭ > 登録日ＴＯの場合エラー
				if (!string.IsNullOrEmpty(f05VO.Uriage_ymd_from) && !string.IsNullOrEmpty(f05VO.Uriage_ymd_to))
				{
					V03001Check.DateFromToChk(
									f05VO.Uriage_ymd_from,
									f05VO.Uriage_ymd_to,
									facadeContext,
									"売上日付",
									new[] { "Uriage_ymd_from", "Uriage_ymd_to" }
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

				string pdfFileNm = "";

				// 帳票ツールに渡すパラメータを格納
				BoSystemReport reportCls = new BoSystemReport();
				InputData inputData = new InputData();
				OutputInfo output = new OutputInfo();

				// PDFファイル名
				pdfFileNm = string.Format("{0}.{1}",
											BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_ERRORHINBANLIST),
											BoSystemConstant.RPT_PDF_EXTENSION
											);

				// パラメータ設定
				// 会社コード
				inputData.AddScreenParameter(1, logininfo.CopCd.ToString());
				// 店舗コード
				inputData.AddScreenParameter(2, f05VO.Head_tenpo_cd.ToString());
				// 伝票日付FROM
				inputData.AddScreenParameter(3, BoSystemFormat.formatDate(f05VO.Uriage_ymd_from.ToString()));
				// 伝票日付TO
				inputData.AddScreenParameter(4, BoSystemFormat.formatDate(f05VO.Uriage_ymd_to.ToString()));
				// 印刷済フラグ
				inputData.AddScreenParameter(5, (1).ToString());

				// 帳票を出力
				output = reportCls.MdGeneratePDF(inputData,
												BoSystemConstant.REPORTID_ERRORHINBANLIST,
												Tg050p01Constant.FORMID_01,
												Tg050p01Constant.PGID,
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

				// PDFをファイルをユーザマップに設定
				facadeContext.UserMap.Add(Tg050p01Constant.FCDUO_RRT_FLNM, pdfFileNm);

				#endregion

				#region 更新処理
				// 権限取得部品の戻り値が"FALSE"の場合
				if (!CheckKengenCls.CheckKengen(logininfo))
				{
					// [エラー品番TBL]を更新する。
					Upd_MDBT0080(facadeContext, f05VO, logininfo, SysDateVO);

					//トランザクションをコミットする。
					CommitTransaction(facadeContext);

				}
				#endregion
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

		#region ユーザー定義関数

		#region エラー品番ＴＢＬ＿更新
		/// <summary>
		/// 画面に表示されている管理Noを取得
		/// </summary>
		/// <param name="m1List">明細リスト</param>
		/// <param name="M1KanriNo">Ｍ１管理No</param>
		private int Upd_MDBT0080(IFacadeContext facadeContext, Tg050f01Form f01VO, LoginInfoVO loginInfo, SysDateVO sysDateVO)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tg050p01Constant.SQL_ID_01, facadeContext.DBContext);

			#region 更新部
			//更新日
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
			//更新時間
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
			#endregion

			#region 条件部
			// 会社コード
			reader.BindValue("BIND_KAISYA_CD", Convert.ToDecimal(BoSystemString.Nvl(loginInfo.CopCd, "0")));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
			// 売上日付FROM
			reader.BindValue("BIND_URIAGEYMD_FROM", Convert.ToDecimal(BoSystemFormat.formatDate(BoSystemString.Nvl(f01VO.Uriage_ymd_from, "0"))));
			// 売上日付TO
			reader.BindValue("BIND_URIAGEYMD_TO", Convert.ToDecimal(BoSystemFormat.formatDate(BoSystemString.Nvl(f01VO.Uriage_ymd_to, "99999999"))));
			#endregion

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}

		#endregion

		#endregion
	}
}
