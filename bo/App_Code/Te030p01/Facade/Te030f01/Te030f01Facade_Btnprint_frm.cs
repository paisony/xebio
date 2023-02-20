using com.xebio.bo.Te030p01.Constant;
using com.xebio.bo.Te030p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.ReportUtil;
using Common.Business.V01000.V01001;
using Common.Business.V03000.V03001;
using Common.Conditions;
using Common.IntegrationMD.Report;
using Common.ListFactory.Model;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Data;

namespace com.xebio.bo.Te030p01.Facade
{
  /// <summary>
  /// Te030f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Te030f01Facade : StandardBaseFacade
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
                BeginTransactionWithConnect(facadeContext);

                //以下に業務ロジックを記述する。
                #region 初期化

                // ログイン情報取得
                LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

                // FormVO取得
                // 画面より情報を取得する。
                Te030f01Form f03VO = (Te030f01Form)facadeContext.FormVO;

                #endregion

                #region 業務チェック

                #region 単項目チェック
                // 1-1 ヘッダ店舗コード
                //       店舗マスタを検索し、存在しない場合エラー
                if (!string.IsNullOrEmpty(f03VO.Head_tenpo_cd))
                {
                    Hashtable resultHash = new Hashtable();
                    resultHash = V01001Check.CheckTenpo(f03VO.Head_tenpo_cd, facadeContext, "店舗", new[] { "Head_tenpo_cd" });

                }
                //エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
                if (MessageDisplayUtil.HasError(facadeContext))
                {
                    return;
                }
                #endregion

                #region 関連項目チェック
                // 2-1 入荷日FROM、入荷日TO
                //       入荷日ＦＲＯＭ > 入荷日ＴＯの場合エラー
                if (!string.IsNullOrEmpty(f03VO.Jyuryo_ymd_from) && !string.IsNullOrEmpty(f03VO.Jyuryo_ymd_to))
                {
                    V03001Check.DateFromToChk(
                        f03VO.Jyuryo_ymd_from,
                        f03VO.Jyuryo_ymd_to,
                        facadeContext,
                        "入荷日",
                        new[] { "Jyuryo_ymd_from", "Jyuryo_ymd_to" }
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
											BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_IDOUSYUKKASAILIST),
											BoSystemConstant.RPT_PDF_EXTENSION
											);

				// 店舗コード
				inputData.AddScreenParameter(1, BoSystemFormat.formatTenpoCd(f03VO.Head_tenpo_cd));
				// 入荷日FROM
				inputData.AddScreenParameter(2, BoSystemFormat.formatDate(f03VO.Jyuryo_ymd_from));
				// 入荷日TO
				inputData.AddScreenParameter(3, BoSystemFormat.formatDate(f03VO.Jyuryo_ymd_to));
				// 出力区分
				inputData.AddScreenParameter(4, f03VO.Shuturyoku_kbn);

				// 帳票を出力
				output = reportCls.MdGeneratePDF(inputData,
												BoSystemConstant.REPORTID_IDOUSYUKKASAILIST,
												Te030p01Constant.FORMID_01,
												Te030p01Constant.PGID,
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
				facadeContext.UserMap.Add(Te030p01Constant.FCDUO_RRT_FLNM, pdfFileNm);
				#endregion


				#region 印刷済みフラグ更新

				// 未出力が選択された場合、印刷済みフラグの更新を行う
				if (f03VO.Shuturyoku_kbn.Equals(ConditionShuturyoku_kbn.VALUE_SHUTURYOKU_KBN1))
				{
					// システム日付取得
					SysDateVO sysDateVO = new SysDateVO();
					sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

					// [移動出荷差異リストTBL]を更新する。
					BoSystemLog.logOut("[移動出荷差異リストTBL]を更新 START");
					int Updcnt = Upd_IdoShukkaSai(facadeContext, f03VO, logininfo, sysDateVO);
					BoSystemLog.logOut("[移動出荷差異リストTBL]を更新 END");

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

		#region [移動出荷差異リストTBL]を更新する。
		/// <summary>
		/// [移動出荷差異リストTBL]を更新する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="loginInfo">明細画面VO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private int Upd_IdoShukkaSai(IFacadeContext facadeContext, Te030f01Form f03VO, LoginInfoVO loginInfo, SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable("TE030P01-01", facadeContext.DBContext);

			// 更新日
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
			// 出荷会社コードのバインド
			reader.BindValue("BIND_SYUKKAKAISYA_CD", Convert.ToDecimal(loginInfo.CopCd));
			// 出荷店コードのバインド
			reader.BindValue("BIND_SYUKKATEN_CD", BoSystemFormat.formatTenpoCd(f03VO.Head_tenpo_cd));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion
	}
}