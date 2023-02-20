using com.xebio.bo.Tm030p01.Constant;
using com.xebio.bo.Tm030p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Model.Data;
using System;
using System.Data;

namespace com.xebio.bo.Tm030p01.Facade
{
  /// <summary>
  /// Tm030f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tm030f01Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : M1tyohyo_nm)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(M1tyohyo_nm)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoM1TYOHYO_NM_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoM1TYOHYO_NM_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得して、トランザクションを開始する。
				BeginTransactionWithConnect(facadeContext);

				//以下に業務ロジックを記述する。

				// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
				#region 初期化
				// ログイン情報取得
				LoginInfoVO loginInfo = LoginInfoUtil.GetLoginInfo();

				// システム日付情報取得
				SysDateVO sysdateVO = SysdateCls.GetSysdateTime(facadeContext);

				// FormVO取得
				// 画面より情報を取得する。
				Tm030f01Form f01VO = (Tm030f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// 選択行オブジェクト取得
				Tm030f01M1Form m1Form = (Tm030f01M1Form)m1List.GetPageViewList()[facadeContext.CommandInfo.ListIndex];
				#endregion

				#region 更新処理
				switch ((string)m1Form.Dictionary[Tm030p01Constant.DIC_M1TYOHYO_ID])
				{
					case Tm030p01Constant.LIST_ID_TD060L01:

						// [返品指示変更履歴TBL]を更新する。
						BoSystemLog.logOut("[返品指示変更履歴TBL]を更新 START");
						Upd_MDRT0060(facadeContext, loginInfo, sysdateVO);
						BoSystemLog.logOut("[返品指示変更履歴TBL]を更新 END");

						break;
					case Tm030p01Constant.LIST_ID_TE030L01:

						// [移動出荷差異リスト]を更新する。
						BoSystemLog.logOut("[移動出荷差異リスト]を更新 START");
						Upd_MDNT0030(facadeContext, loginInfo, sysdateVO);
						BoSystemLog.logOut("[移動出荷差異リスト]を更新 END");

						break;
					case Tm030p01Constant.LIST_ID_TG050L01:

						// [エラー品番TBL]を更新する。
						BoSystemLog.logOut("[エラー品番TBL]を更新 START");
						Upd_MDBT0080(facadeContext, loginInfo, sysdateVO);
						BoSystemLog.logOut("[エラー品番TBL]を更新 END");

						break;
					case Tm030p01Constant.LIST_ID_TG070L01:

						// [インストアコード振替データTBL]を更新する。
						BoSystemLog.logOut("[インストアコード振替データTBL]を更新 START");
						Upd_MDBT0090(facadeContext, loginInfo, sysdateVO);
						BoSystemLog.logOut("[インストアコード振替データTBL]を更新 END");

						break;
					default:
						break;
				}
				#endregion
				// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

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
			EndMethod(facadeContext, this.GetType().Name + ".DoM1TYOHYO_NM_FRM");

		}
		#endregion

		#region 返品指示変更履歴TBL更新
		/// <summary>
		/// 返品指示変更履歴TBL更新
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysdateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private static int Upd_MDRT0060(IFacadeContext facadeContext, LoginInfoVO loginInfo, SysDateVO sysdateVO)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tm030p01Constant.SQL_ID_12, facadeContext.DBContext);

			// 店舗コード
			reader.BindValue("TENPO_CD", BoSystemFormat.formatTenpoCd(loginInfo.TnpCd));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region 移動出荷差異リスト更新
		/// <summary>
		/// 移動出荷差異リスト更新
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysdateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private static int Upd_MDNT0030(IFacadeContext facadeContext, LoginInfoVO loginInfo, SysDateVO sysdateVO)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tm030p01Constant.SQL_ID_13, facadeContext.DBContext);

			// 更新日
			reader.BindValue("UPD_YMD", sysdateVO.Sysdate);
			// 更新時間
			reader.BindValue("UPD_TM", sysdateVO.Systime_mili);
			// 出荷店コード
			reader.BindValue("SYUKKATEN_CD", BoSystemFormat.formatTenpoCd(loginInfo.TnpCd));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region エラー品番TBL更新
		/// <summary>
		/// エラー品番TBL更新
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysdateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private static int Upd_MDBT0080(IFacadeContext facadeContext, LoginInfoVO loginInfo, SysDateVO sysdateVO)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tm030p01Constant.SQL_ID_14, facadeContext.DBContext);

			// 更新日
			reader.BindValue("UPD_YMD", sysdateVO.Sysdate);
			// 更新時間
			reader.BindValue("UPD_TM", sysdateVO.Systime_mili);
			// 会社コード
			reader.BindValue("KAISYA_CD", Convert.ToDecimal(loginInfo.CopCd));
			// 店舗コード
			reader.BindValue("TENPO_CD", BoSystemFormat.formatTenpoCd(loginInfo.TnpCd));
			// 伝票日付
			// システム日付 - 1日
			DateTime sysdate;
			DateTime.TryParseExact(sysdateVO.Sysdate.ToString(), "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out sysdate);
			decimal denpyoYmd;
			decimal.TryParse(sysdate.AddDays(-1D).ToString("yyyyMMdd"), out denpyoYmd);
			reader.BindValue("DENPYO_YMD", denpyoYmd);

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region インストアコード振替データTBL更新
		/// <summary>
		/// インストアコード振替データTBL更新
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysdateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private static int Upd_MDBT0090(IFacadeContext facadeContext, LoginInfoVO loginInfo, SysDateVO sysdateVO)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tm030p01Constant.SQL_ID_15, facadeContext.DBContext);

			// 更新日
			reader.BindValue("UPD_YMD", sysdateVO.Sysdate);
			// 更新時間
			reader.BindValue("UPD_TM", sysdateVO.Systime_mili);
			// 会社コード
			reader.BindValue("KAISYA_CD", Convert.ToDecimal(loginInfo.CopCd));
			// 店舗コード
			reader.BindValue("TENPO_CD", BoSystemFormat.formatTenpoCd(loginInfo.TnpCd));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion
	}
}
