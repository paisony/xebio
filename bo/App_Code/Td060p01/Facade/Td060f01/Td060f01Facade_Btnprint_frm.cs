using com.xebio.bo.Td060p01.Constant;
using com.xebio.bo.Td060p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.ReportUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.V01000.V01001;
using Common.Business.V03000.V03001;
using Common.Conditions;
using Common.IntegrationMD.Report;
using Common.ListFactory.Model;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System.Collections;
using System.Data;
using System.Text;

namespace com.xebio.bo.Td060p01.Facade
{
  /// <summary>
  /// Td060f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Td060f01Facade : StandardBaseFacade
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

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Td060f01Form f06VO = (Td060f01Form)facadeContext.FormVO;

				#endregion

				#region 業務チェック
	
					#region 単項目チェック
					// 1-1 ヘッダ店舗コード
					//       店舗マスタを検索し、存在しない場合エラー
					if (!string.IsNullOrEmpty(f06VO.Head_tenpo_cd))
					{
						Hashtable resultHash = new Hashtable();
						resultHash = V01001Check.CheckTenpo(f06VO.Head_tenpo_cd, facadeContext, "店舗", new[] { "Head_tenpo_cd" });

					}
					//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}

					#endregion

					#region 関連項目チェック
                	// 2-1 変更日FROM、変更日TO
                	//       変更日ＦＲＯＭ >変更日ＴＯの場合エラー
					if (!string.IsNullOrEmpty(f06VO.Change_ymd_from) && !string.IsNullOrEmpty(f06VO.Change_ymd_to))
					{
						V03001Check.DateFromToChk(
                            f06VO.Change_ymd_from,
							f06VO.Change_ymd_to,
							facadeContext,
							"変更日",
							new[] { "Change_ymd_from", "Change_ymd_to" }
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
											BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_HENPINSIJIHENKOLIST),
											BoSystemConstant.RPT_PDF_EXTENSION
											);

				//店舗コード
				inputData.AddScreenParameter(1, BoSystemFormat.formatTenpoCd(f06VO.Head_tenpo_cd));
				//変更日FROM
				inputData.AddScreenParameter(2, BoSystemFormat.formatDate(f06VO.Change_ymd_from));
				//変更日TO
				inputData.AddScreenParameter(3, BoSystemFormat.formatDate(f06VO.Change_ymd_to));
				//出力区分
				inputData.AddScreenParameter(4, f06VO.Shuturyoku_kbn);

				// 帳票を出力
				output = reportCls.MdGeneratePDF(inputData,
												BoSystemConstant.REPORTID_HENPINSIJIHENKOLIST,
												Td060p01Constant.FORMID_01,
												Td060p01Constant.PGID,
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

				#region 印刷フラグ更新処理

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				// [返品指示変更履歴TBL]を更新する。
				BoSystemLog.logOut("[返品指示変更履歴TBL]を更新 START");
				BoSystemLog.logOut("[返品指示変更履歴TBL]" + " START", BoSystemLog.LOGLEVEL_INFO);

				int Updcntyoteih = Upd_HenpinShijihenkou(facadeContext, f06VO, logininfo, sysDateVO);
				BoSystemLog.logOut("[返品指示変更履歴TBL]を更新 END");

				#endregion

				// PDFをファイルをユーザマップに設定
				facadeContext.UserMap.Add(Td060p01Constant.FCDUO_RRT_FLNM, pdfFileNm);

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

		#region ユーザー定義関数

		#region [返品指示変更履歴TBL]を更新する。
		/// <summary>
		/// [返品指示変更履歴TBL(H)]を更新する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f06Form">一覧画面のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns> 

		private int Upd_HenpinShijihenkou(IFacadeContext facadeContext,
									Td060f01Form f06Form,
									LoginInfoVO loginInfo,
									SysDateVO sysDateVO)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable("TD060P01-01", facadeContext.DBContext);

			#region 更新条件設定

			ArrayList bindList = new ArrayList();
			BindInfoVO bindVO = new BindInfoVO();
			StringBuilder sRepSql = new StringBuilder();

			sRepSql = new StringBuilder();

			// 店舗コードを設定
			sRepSql.Append(" AND TENPO_CD = :BIND_TENPO_CD");

			bindVO = new BindInfoVO();
			bindVO.BindId = "BIND_TENPO_CD";
			bindVO.Value = BoSystemFormat.formatTenpoCd(f06Form.Head_tenpo_cd);
			bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			// 変更日FROMを設定
			if (!string.IsNullOrEmpty(f06Form.Change_ymd_from))
			{
				sRepSql.Append(" AND CHANGE_YMD >= :BIND_CHANGE_YMD_FROM");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_CHANGE_YMD_FROM";
				bindVO.Value = BoSystemFormat.formatDate(f06Form.Change_ymd_from);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 変更日TOを設定
			if (!string.IsNullOrEmpty(f06Form.Change_ymd_to))
			{
				sRepSql.Append(" AND CHANGE_YMD <= :BIND_CHANGE_YMD_TO");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_CHANGE_YMD_TO";
				bindVO.Value = BoSystemFormat.formatDate(f06Form.Change_ymd_to);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			sRepSql.Append(" AND MD_INSATSUZUMI_FLG = 1");

			//「未印刷分」の場合は、検索条件を追加する
			if (f06Form.Shuturyoku_kbn.Equals(ConditionShuturyoku_joken.VALUE_SHUTURYOKU_JOKEN1))
			{
				sRepSql.Append(" AND INSATSUZUMI_FLG = 0");

				sRepSql.Append(" AND MDRT0060.CHANGE_YMD >= (SELECT MAX(LASTPRINT.LAST_PRINT_YMD)");
				sRepSql.Append("							FROM MDRT0060 LASTPRINT");
				sRepSql.Append("							WHERE LASTPRINT.TENPO_CD = MDRT0060.TENPO_CD");
				sRepSql.Append("							AND LASTPRINT.SIJI_BANGO = MDRT0060.SIJI_BANGO)");
			}

			BoSystemSql.AddSql(reader, Td060p01Constant.SQL_ID_01_REP_ADD_WHERE, sRepSql.ToString(), bindList);
			#endregion

			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#endregion
	}
}
