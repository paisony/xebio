using com.xebio.bo.Tm060p01.Constant;
using com.xebio.bo.Tm060p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C99999.ConfigUtil;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.V03000.V03003;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Data;
using System.Text;

namespace com.xebio.bo.Tm060p01.Facade
{
  /// <summary>
  /// Tm060f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tm060f01Facade : StandardBaseFacade
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

			////メソッドの開始処理を実行する。
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
				Tm060f01Form f01VO = (Tm060f01Form)facadeContext.FormVO;
				Tm060f01M1Form f01m1VO = new Tm060f01M1Form();

				IDataList prevM1List = f01VO.GetList("M1");
				IDataList m1List = f01VO.GetList("M1");

				//UPDATE文の条件をBIND
				for (int i = 0; i < m1List.Count; i++)
				{
					ArrayList bindList = new ArrayList();
					BindInfoVO bindVO = new BindInfoVO();

					f01m1VO = (Tm060f01M1Form)m1List[i];
					if (f01m1VO.M1entersyoriflg.Equals(ConditionKakuteisyori_flg.VALUE_ARI))
					{
						StringBuilder sRepSql = new StringBuilder();
						sRepSql.Append(" AND LOGIN_ID = :BIND_TAN_CD");
						// 担当者コード
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_TAN_CD";
						bindVO.Value = BoSystemFormat.formatTantoCd(f01m1VO.M1tantosya_cd);
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						//// 排他チェック
						V03003Check.CheckHaitaBsLoginUser(
								Convert.ToDecimal((string)f01m1VO.Dictionary[Tm060p01Constant.DIC_M1UPD_YMD]),
								Convert.ToDecimal((string)f01m1VO.Dictionary[Tm060p01Constant.DIC_M1UPD_TM]),
								facadeContext,
								"BS_LOGIN_USER",
								sRepSql.ToString(),
								bindList,
								1
						);
						//V03003Check.CheckHaitaMaxVal(
						//		Convert.ToDecimal((string)f01m1VO.Dictionary[Tm060p01Constant.DIC_M1UPD_YMD]),
						//		Convert.ToDecimal((string)f01m1VO.Dictionary[Tm060p01Constant.DIC_M1UPD_TM]),
						//		facadeContext,
						//		"MDMT0210",
						//		sRepSql.ToString(),
						//		bindList,
						//		1
						//);
						//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
						if (MessageDisplayUtil.HasError(facadeContext))
						{
							return;
						}
					}
				}
				#endregion

				#region 更新処理

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				for (int i = 0; i < m1List.Count; i++)
				{
					f01m1VO = (Tm060f01M1Form)m1List[i];

					if (f01m1VO.M1entersyoriflg.Equals(ConditionKakuteisyori_flg.VALUE_ARI))
					{
						if (f01m1VO.M1passwardsyokika.Equals("0"))
						{
							// [ログインユーザーTBL(H)]を更新する。パスワードチェックなし
							BoSystemLog.logOut("[ログインユーザーTBLパスなし]を更新 START");
							int Updcntmibaraih = Upd_rogin_user(facadeContext, f01VO, logininfo, sysDateVO, f01m1VO);
							BoSystemLog.logOut("[ログインユーザーTBLパスなし]を更新 END");
						}
						else
						{
							// [ログインユーザーTBL(H)]を更新する。パスワードチェックあり
							BoSystemLog.logOut("[ログインユーザーTBLパスあり]を更新 START");
							int Updcntmibaraih = Upd_rogin_user_check(facadeContext, f01VO, logininfo, sysDateVO, f01m1VO);
							BoSystemLog.logOut("[ログインユーザーTBLパスあり]を更新 END");
							// [ログイン失敗管理TBL]を更新する。
							BoSystemLog.logOut("[ログイン失敗管理TBL]を更新 START");
							int Updcntloginfail = Upd_rogin_failure(facadeContext, f01VO, logininfo, f01m1VO);
							BoSystemLog.logOut("[ログイン失敗管理TBL]を更新 END");
						}
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

		#region [ログインユーザーTBL]を更新する。パスワードチェックなし
		/// <summary>
		/// [ログインユーザーTBL(H)]を更新する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f02VO">画面のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="f01m1VO">明細のデータ</param>
		/// <returns>更新件数</returns>
		private int Upd_rogin_user(IFacadeContext facadeContext,
									Tm060f01Form f01VO,
									LoginInfoVO loginInfo,
									SysDateVO sysDateVO,
									Tm060f01M1Form f01m1VO)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable("TM060P01-05", facadeContext.DBContext);
			IDataList m1List = f01VO.GetList("M1");
			String zenjikoku = "";
			//SELECT
			// 担当者コード
			reader.BindValue("BIND_TANCD_1", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));//自分の担当者コード
			// 権限区分
			if (f01m1VO.M1kengen_kb.Equals(ConditionKengen.VALUE_H_KENGEN1))
			{
				reader.BindValue("BIND_MENU", BoSystemConstant.USER_PASSWORD_HONBU);//本部
			}
			else if (f01m1VO.M1kengen_kb.Equals(ConditionKengen.VALUE_H_KENGEN2))
			{
				reader.BindValue("BIND_MENU", BoSystemConstant.USER_PASSWORD_TENCHO);//店長
			}
			else if (f01m1VO.M1kengen_kb.Equals(ConditionKengen.VALUE_H_KENGEN3))
			{
				reader.BindValue("BIND_MENU", BoSystemConstant.USER_PASSWORD_IPPAN);//一般
			}
			else if (f01m1VO.M1kengen_kb.Equals(ConditionKengen.VALUE_H_KENGEN4))
			{
				reader.BindValue("BIND_MENU", BoSystemConstant.USER_PASSWORD_ARBEIT);//アルバイト
			}
			// CREATE_DATETIME
			String date = sysDateVO.Sysdate.ToString();
			String time = sysDateVO.Systime_mili.ToString();
			zenjikoku = BoSystemFormat.formatDateTime(date, time);
			//更新日時
			reader.BindValue("BIND_UPD_TM", zenjikoku);
			// WHERE
			// 更新担当者コード
			reader.BindValue("BIND_TANCD_2", BoSystemFormat.formatTantoCd(f01m1VO.M1tantosya_cd.ToString()));//修正した担当者コード

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [ログインユーザーTBL]を更新する。パスワードチェックあり
		/// <summary>
		/// [ログインユーザーTBL(H)]を更新する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f02VO">画面のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="f01m1VO">明細のデータ</param>
		/// <returns>更新件数</returns>
		private int Upd_rogin_user_check(IFacadeContext facadeContext,
									Tm060f01Form f01VO,
									LoginInfoVO loginInfo,
									SysDateVO sysDateVO,
									Tm060f01M1Form f01m1VO)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable("TM060P01-07", facadeContext.DBContext);
			IDataList m1List = f01VO.GetList("M1");
			String zenjikoku = "";
			//SELECT
			// 担当者コード
			reader.BindValue("BIND_TANCD_1", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));	// 自分の担当者コード
			// 権限区分
			if (f01m1VO.M1kengen_kb.Equals(ConditionKengen.VALUE_H_KENGEN1))
			{
				reader.BindValue("BIND_MENU", BoSystemConstant.USER_PASSWORD_HONBU);	// 本部
			}
			else if (f01m1VO.M1kengen_kb.Equals(ConditionKengen.VALUE_H_KENGEN2))
			{
				reader.BindValue("BIND_MENU", BoSystemConstant.USER_PASSWORD_TENCHO);	// 店長
			}
			else if (f01m1VO.M1kengen_kb.Equals(ConditionKengen.VALUE_H_KENGEN3))
			{
				reader.BindValue("BIND_MENU", BoSystemConstant.USER_PASSWORD_IPPAN);	// 一般
			}
			else if (f01m1VO.M1kengen_kb.Equals(ConditionKengen.VALUE_H_KENGEN4))
			{
				reader.BindValue("BIND_MENU", BoSystemConstant.USER_PASSWORD_ARBEIT);	// アルバイト
			}
			// パスワード更新時間
			String date = sysDateVO.Sysdate.ToString();
			String time = sysDateVO.Systime_mili.ToString();
			zenjikoku = BoSystemFormat.formatDateTime(date, time);
			// 更新時間
			reader.BindValue("BIND_UPD_TM", zenjikoku);
			reader.BindValue("BIND_PASS_TIME", "2000-01-01 00:00:00");
			// パスワード変更
			reader.BindValue("BIND_PASSWORD", BoSystemConfig.GetConfgiVal(BoSystemConstant.BO_CONFIG_LOGIN_USER_PASSWORD));
			reader.BindValue("BIND_LOCK_FLAG", "0");
			// WHERE
			// 更新担当者コード
			reader.BindValue("BIND_TANCD_2", BoSystemFormat.formatTantoCd(f01m1VO.M1tantosya_cd.ToString()));	// 修正した担当者コード

			// クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [ログイン失敗管理TBL]を更新する。
		/// <summary>
		/// [ログイン失敗管理TBL(H)]を更新する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01VO">画面のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="f01m1VO">明細のデータ</param>
		/// <returns>更新件数</returns>
		private int Upd_rogin_failure(IFacadeContext facadeContext,
									Tm060f01Form f01VO,
									LoginInfoVO loginInfo,
									Tm060f01M1Form f01m1VO)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable("TM060P01-08", facadeContext.DBContext);
			IDataList m1List = f01VO.GetList("M1");
			// WHERE
			// 更新担当者コード
			reader.BindValue("BIND_TANCD", BoSystemFormat.formatTantoCd(f01m1VO.M1tantosya_cd.ToString()));	// 修正した担当者コード

			// クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion
		#endregion
	}
}
