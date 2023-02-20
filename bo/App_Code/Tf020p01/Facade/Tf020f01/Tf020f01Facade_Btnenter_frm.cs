using com.xebio.bo.Tf020p01.Constant;
using com.xebio.bo.Tf020p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.V03000.V03003;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Data;
using System.Text;

namespace com.xebio.bo.Tf020p01.Facade
{
  /// <summary>
  /// Tf020f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tf020f01Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : Btnenter)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnenter)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNENTER_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNENTER_FRM");

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
				Tf020f01Form f01VO = (Tf020f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				#endregion

				#region 業務チェック

				#region 行数チェック

				if (m1List == null || m1List.Count <= 0)
				{
					// 対象行がありません。
					ErrMsgCls.AddErrMsg("E119", "対象行", facadeContext);
				}
				else
				{
					int inputflg = 0;
					for (int i = 0; i < m1List.Count; i++)
					{
						Tf020f01M1Form f01m1VO = (Tf020f01M1Form)m1List[i];

						// モードが「取消」で、[Ｍ１選択フラグ(隠し)]が"1"の場合
						if (BoSystemConstant.MODE_DEL.Equals(f01VO.Modeno)
							&& BoSystemConstant.CHECKBOX_ON.Equals(f01m1VO.M1selectorcheckbox))
						{
							inputflg = 1;
							break;
						}
					}

					if (inputflg == 0)
					{
						// 対象行がありません。
						ErrMsgCls.AddErrMsg("E119", "対象行", facadeContext);
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region 排他チェック

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				StringBuilder sRepSql = new StringBuilder();

				sRepSql.Append(" AND TENPO_CD		= :BIND_TENPO_CD");
				sRepSql.Append(" AND DENPYO_BANGO	= :BIND_DENPYO_BANGO");
				sRepSql.Append(" AND SYORI_YMD		= :BIND_SYORI_YMD");

				for (int i = 0; i < m1List.Count; i++)
				{
					Tf020f01M1Form f01m1VO = (Tf020f01M1Form)m1List[i];

					// モードが「取消」で、[Ｍ１選択フラグ(隠し)]が"1"の場合
					if (   BoSystemConstant.MODE_DEL.Equals(f01VO.Modeno)
						&& BoSystemConstant.CHECKBOX_ON.Equals(f01m1VO.M1selectorcheckbox))
					{
						ArrayList bindList = new ArrayList();
						BindInfoVO bindVO = new BindInfoVO();

						// 店舗コード
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_TENPO_CD";
						bindVO.Value = BoSystemFormat.formatTenpoCd((string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_cd)]);
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						// 伝票番号
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_DENPYO_BANGO";
						bindVO.Value = BoSystemFormat.formatDenpyoNo((string)f01m1VO.Dictionary[Tf020p01Constant.DIC_M1DENPYO_BANGO]);
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						// 処理日
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_SYORI_YMD";
						bindVO.Value = BoSystemFormat.formatDate((string)f01m1VO.Dictionary[Tf020p01Constant.DIC_M1SYORI_YMD]);
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						// 排他チェック
						V03003Check.CheckHaitaMaxVal(
								Convert.ToDecimal((string)f01m1VO.Dictionary[Tf020p01Constant.DIC_M1UPD_YMD]),
								Convert.ToDecimal((string)f01m1VO.Dictionary[Tf020p01Constant.DIC_M1UPD_TM]),
								facadeContext,
								"MDAT0020",
								sRepSql.ToString(),
								bindList,
								1,
								null,
								f01m1VO.M1rowno,
								i.ToString(),
								"M1",
								100
						);
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#endregion

				#region 更新処理

				for (int i = 0; i < m1List.Count; i++)
				{
					Tf020f01M1Form f01m1VO = (Tf020f01M1Form)m1List[i];

					// モードが「取消」で、[Ｍ１選択フラグ(隠し)]が"1"の場合
					if (BoSystemConstant.MODE_DEL.Equals(f01VO.Modeno)
						&& BoSystemConstant.CHECKBOX_ON.Equals(f01m1VO.M1selectorcheckbox))
					{
						// [経費振替確定TBL(H)]を削除する。
						BoSystemLog.logOut("[経費振替申請TBL(H)]を削除 START");
						int Delcntsinseih = Del_Sakujo_KeihiFurikaeSinseih(facadeContext, f01VO, f01m1VO);
						BoSystemLog.logOut("[経費振替申請TBL(H)]を削除 END  ");

						// [経費振替確定TBL(B)]を削除する。
						BoSystemLog.logOut("[経費振替申請TBL(B)]を削除 START");
						int Delcntsinseib = Del_Sakujo_KeihiFurikaeSinseib(facadeContext, f01VO, f01m1VO);
						BoSystemLog.logOut("[経費振替申請TBL(B)]を削除 END  ");
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
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNENTER_FRM");

		}

		#endregion

		#region ユーザー定義関数

		#region [経費振替申請TBL(H)]の削除
		/// <summary>
		/// [経費振替確定TBL(H)]の削除を行います。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <returns>更新件数</returns>
		private int Del_Sakujo_KeihiFurikaeSinseih(IFacadeContext facadeContext,
													Tf020f01Form f01Form,
													Tf020f01M1Form f01M1Form)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tf020p01Constant.SQL_ID_08, facadeContext.DBContext);

			// 削除条件
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01Form.Dictionary[SearchConditionSaveCls.GetKey(() => f01Form.Head_tenpo_cd)]));
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal((string)f01M1Form.Dictionary[Tf020p01Constant.DIC_M1DENPYO_BANGO]));
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal((string)f01M1Form.Dictionary[Tf020p01Constant.DIC_M1SYORI_YMD]));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [経費振替申請TBL(B)]の削除
		/// <summary>
		/// [経費振替確定TBL(B)]の削除を行います。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <returns>更新件数</returns>
		private int Del_Sakujo_KeihiFurikaeSinseib(IFacadeContext facadeContext,
													Tf020f01Form f01Form,
													Tf020f01M1Form f01M1Form)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tf020p01Constant.SQL_ID_09, facadeContext.DBContext);

			// 削除条件
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01Form.Dictionary[SearchConditionSaveCls.GetKey(() => f01Form.Head_tenpo_cd)]));
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal((string)f01M1Form.Dictionary[Tf020p01Constant.DIC_M1DENPYO_BANGO]));
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal((string)f01M1Form.Dictionary[Tf020p01Constant.DIC_M1SYORI_YMD]));

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
