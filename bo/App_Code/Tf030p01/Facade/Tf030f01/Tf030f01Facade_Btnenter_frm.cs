using com.xebio.bo.Tf030p01.Constant;
using com.xebio.bo.Tf030p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
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

namespace com.xebio.bo.Tf030p01.Facade
{
  /// <summary>
  /// Tf030f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tf030f01Facade : StandardBaseFacade
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
				Tf030f01Form f01VO = (Tf030f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				#endregion

				#region 業務チェック

				// 5-1 選択チェック
				//       1件も選択されていない場合、エラー
				if (m1List == null || m1List.Count <= 0)
				{
					// 対象行を選択して下さい。
					ErrMsgCls.AddErrMsg("E119", "対象行", facadeContext);
				}
				else
				{
					int inputflg = 0;
					for (int i = 0; i < m1List.Count; i++)
					{
						Tf030f01M1Form f01m1VO = (Tf030f01M1Form) m1List[i];
						if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
						{
							inputflg = 1;
							break;
						}
					}
					if (inputflg == 0)
					{
						// 対象行を選択して下さい。
						ErrMsgCls.AddErrMsg("E119", "対象行", facadeContext);
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				// 5-2 排他チェック
				StringBuilder sRepSql = new StringBuilder();

				sRepSql.Append(" AND DENPYO_BANGO = :BIND_DENPYO_BANGO");
				sRepSql.Append(" AND SYORI_YMD = :BIND_SYORI_YMD");
				sRepSql.Append(" AND TENPO_CD = :BIND_TENPO_CD");

				for (int i = 0; i < m1List.Count; i++)
				{
					Tf030f01M1Form f01m1VO = (Tf030f01M1Form)m1List[i];

					if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
					{
						ArrayList bindList = new ArrayList();
						BindInfoVO bindVO = new BindInfoVO();

						// 伝票番号
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_DENPYO_BANGO";
						bindVO.Value = (string)f01m1VO.Dictionary[Tf030p01Constant.DIC_M1DENPYO_BANGO];
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						// 処理日付
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_SYORI_YMD";
						bindVO.Value = BoSystemFormat.formatDate(f01m1VO.M1add_ymd);
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						// 店舗コード
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_TENPO_CD";
						bindVO.Value = BoSystemFormat.formatTenpoCd(f01m1VO.M1tenpo_cd);
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						// 排他チェック
						V03003Check.CheckHaitaMaxVal(
								Convert.ToDecimal((string)f01m1VO.Dictionary[Tf030p01Constant.DIC_M1UPD_YMD]),
								Convert.ToDecimal((string)f01m1VO.Dictionary[Tf030p01Constant.DIC_M1UPD_TM]),
								facadeContext,
								"MDAT0010",
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

				#region 更新処理

				for (int i = 0; i < m1List.Count; i++)
				{
					Tf030f01M1Form f01m1VO = (Tf030f01M1Form)m1List[i];

					if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
					{
						// [経費未払TBL(H)]を削除する。
						BoSystemLog.logOut("[経費未払TBL(H)]を削除 START");
						int Updcntmibaraih = Del_KeihiMibaraiH(facadeContext, f01m1VO);
						BoSystemLog.logOut("[経費未払TBL(H)]を削除 END");

						// [経費未払TBL(B)]を削除する。
						BoSystemLog.logOut("[経費未払TBL(B)]を削除 START");
						int Updcntmibaraib = Del_KeihiMibaraiB(facadeContext, f01m1VO);
						BoSystemLog.logOut("[経費未払TBL(B)]を削除 END");
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

		#region [経費未払TBL(H)]を削除する。
		/// <summary>
		/// [経費未払TBL(H)]を削除する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01m1VO">画面選択行のVO</param>
		/// <returns>更新件数</returns>
		private int Del_KeihiMibaraiH(IFacadeContext facadeContext,
									Tf030f01M1Form f01m1VO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable("TF030P01-04", facadeContext.DBContext);
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal(f01m1VO.Dictionary[Tf030p01Constant.DIC_M1DENPYO_BANGO]));
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01m1VO.M1add_ymd)));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(f01m1VO.M1tenpo_cd));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [経費未払TBL(B)]を削除する。
		/// <summary>
		/// [経費未払TBL(B)]を削除する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01m1VO">画面選択行のVO</param>
		/// <returns>更新件数</returns>
		private int Del_KeihiMibaraiB(IFacadeContext facadeContext,
									Tf030f01M1Form f01m1VO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable("TF030P01-05", facadeContext.DBContext);
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal(f01m1VO.Dictionary[Tf030p01Constant.DIC_M1DENPYO_BANGO]));
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01m1VO.M1add_ymd)));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(f01m1VO.M1tenpo_cd));

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
