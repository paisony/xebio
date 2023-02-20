using com.xebio.bo.Tf060p01.Constant;
using com.xebio.bo.Tf060p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V03000.V03003;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Data;
using System.Text;

namespace com.xebio.bo.Tf060p01.Facade
{
  /// <summary>
  /// Tf060f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tf060f01Facade : StandardBaseFacade
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

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				// FormVO取得
				// 画面より情報を取得する。
				Tf060f01Form f01VO = (Tf060f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// 合計数計算
				this.setGokei(f01VO, false);

				#endregion

				#region 業務チェック

				#region 関連チェック

				// 1-1 月別部門(１～５)予算額
				//       月別部門１予算額～月別部門５予算額の合計が「999999」より大きい場合はエラー
				if (!string.IsNullOrEmpty(f01VO.Tukibetu_yosan_kin_gokei))
				{
					if (Convert.ToDecimal(f01VO.Tukibetu_yosan_kin_gokei) > Tf060p01Constant.MAX_KINGAKU)
					{
						// 月別部門合計の合計が有効桁数を超えています。
						ErrMsgCls.AddErrMsg("E102", "月別部門合計の合計", facadeContext, new[] { "Tukibetu_yosan_kin_gokei" });
					}
				}

				// 1-2 Ｍ１部門(１～５)予算額
				//       Ｍ１部門１予算額～Ｍ１部門５予算額の合計が「999999」より大きい場合はエラー
				for (int i = 0; i < m1List.Count; i++)
				{
					Tf060f01M1Form f01m1VO = (Tf060f01M1Form)m1List[i];
					if (!string.IsNullOrEmpty(f01m1VO.M1hibetu_yosan_kin))
					{
						if (Convert.ToDecimal(f01m1VO.M1hibetu_yosan_kin) > Tf060p01Constant.MAX_KINGAKU)
						{
							string title = f01m1VO.M1getunai_hiduke + "(" + f01m1VO.M1yobi + ")";
							// 日(曜日)の合計が有効桁数を超えています。
							ErrMsgCls.AddErrMsg("E102", title + "の合計", facadeContext, new[] { "M1hibetu_yosan_kin" }, null, i.ToString(), "M1", 0);
						}
					}
				}

				// 1-3 Ｍ１部門(１～５)予算額
				//       Ｍ１部門１予算額の1日～月末日の合計が「999999」より大きい場合はエラー
				//		（※部門２～部門５も同様にチェックする）
				// 部門１
				if (!string.IsNullOrEmpty(f01VO.Bumon1_yosangokei_kin))
				{
					if (Convert.ToDecimal(f01VO.Bumon1_yosangokei_kin) > Tf060p01Constant.MAX_KINGAKU)
					{
						// 部門１の合計が有効桁数を超えています。
						ErrMsgCls.AddErrMsg("E102", "部門１の合計", facadeContext, new[] { "Bumon1_yosangokei_kin" });
					}
				}
				// 部門２
				if (!string.IsNullOrEmpty(f01VO.Bumon2_yosangokei_kin))
				{
					if (Convert.ToDecimal(f01VO.Bumon2_yosangokei_kin) > Tf060p01Constant.MAX_KINGAKU)
					{
						// 部門２の合計が有効桁数を超えています。
						ErrMsgCls.AddErrMsg("E102", "部門２の合計", facadeContext, new[] { "Bumon2_yosangokei_kin" });
					}
				}
				// 部門３
				if (!string.IsNullOrEmpty(f01VO.Bumon3_yosangokei_kin))
				{
					if (Convert.ToDecimal(f01VO.Bumon3_yosangokei_kin) > Tf060p01Constant.MAX_KINGAKU)
					{
						// 部門３の合計が有効桁数を超えています。
						ErrMsgCls.AddErrMsg("E102", "部門３の合計", facadeContext, new[] { "Bumon3_yosangokei_kin" });
					}
				}
				// 部門４
				if (!string.IsNullOrEmpty(f01VO.Bumon4_yosangokei_kin))
				{
					if (Convert.ToDecimal(f01VO.Bumon4_yosangokei_kin) > Tf060p01Constant.MAX_KINGAKU)
					{
						// 部門４の合計が有効桁数を超えています。
						ErrMsgCls.AddErrMsg("E102", "部門４の合計", facadeContext, new[] { "Bumon4_yosangokei_kin" });
					}
				}
				// 部門５
				if (!string.IsNullOrEmpty(f01VO.Bumon5_yosangokei_kin))
				{
					if (Convert.ToDecimal(f01VO.Bumon5_yosangokei_kin) > Tf060p01Constant.MAX_KINGAKU)
					{
						// 部門５の合計が有効桁数を超えています。
						ErrMsgCls.AddErrMsg("E102", "部門５の合計", facadeContext, new[] { "Bumon5_yosangokei_kin" });
					}
				}
				
				// 1-4 月別部門(１～５)予算額、Ｍ１部門(１～５)予算額
				//       月別部門１予算額とＭ１部門１予算額の1日～月末日の合計が異なる場合、エラー
				//		（※部門２～部門５も同様にチェックする）
				// 部門１
				if (!BoSystemString.Nvl(f01VO.Tukibetu_bumon1_yosan_kin, "0").Equals(f01VO.Bumon1_yosangokei_kin))
				{
					// 月別部門合計と部門１の合計が異なります。
					ErrMsgCls.AddErrMsg("E143", new[] { "部門１" }, facadeContext, new[] { "Tukibetu_bumon1_yosan_kin" });
				}
				// 部門２
				if (!BoSystemString.Nvl(f01VO.Tukibetu_bumon2_yosan_kin, "0").Equals(f01VO.Bumon2_yosangokei_kin))
				{
					// 月別部門合計と部門２の合計が異なります。
					ErrMsgCls.AddErrMsg("E143", new[] { "部門２" }, facadeContext, new[] { "Tukibetu_bumon2_yosan_kin" });
				}
				// 部門３
				if (!BoSystemString.Nvl(f01VO.Tukibetu_bumon3_yosan_kin, "0").Equals(f01VO.Bumon3_yosangokei_kin))
				{
					// 月別部門合計と部門３の合計が異なります。
					ErrMsgCls.AddErrMsg("E143", new[] { "部門３" }, facadeContext, new[] { "Tukibetu_bumon3_yosan_kin" });
				}
				// 部門４
				if (!BoSystemString.Nvl(f01VO.Tukibetu_bumon4_yosan_kin, "0").Equals(f01VO.Bumon4_yosangokei_kin))
				{
					// 月別部門合計と部門４の合計が異なります。
					ErrMsgCls.AddErrMsg("E143", new[] { "部門４" }, facadeContext, new[] { "Tukibetu_bumon4_yosan_kin" });
				}
				// 部門５
				if (!BoSystemString.Nvl(f01VO.Tukibetu_bumon5_yosan_kin, "0").Equals(f01VO.Bumon5_yosangokei_kin))
				{
					// 月別部門合計と部門５の合計が異なります。
					ErrMsgCls.AddErrMsg("E143", new[] { "部門５" }, facadeContext, new[] { "Tukibetu_bumon5_yosan_kin" });
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region 排他チェック
				// 2-1 排他チェック

				ArrayList upd_ymd_list = (ArrayList)f01VO.Dictionary[Tf060p01Constant.DIC_UPD_YMD_LIST];
				ArrayList upd_tm_list = (ArrayList)f01VO.Dictionary[Tf060p01Constant.DIC_UPD_TM_LIST];

				StringBuilder sRepSql = new StringBuilder();

				sRepSql.Append(" AND TENPO_CD = :BIND_TENPO_CD");
				sRepSql.Append(" AND GETUDO = :BIND_GETUDO");
				sRepSql.Append(" AND NIPPANBUMON_CD = :BIND_NIPPANBUMON_CD");

				// 部門(１～５)の排他チェックを行う。
				int bumon_cd = 0;
				for (int i = 0; i < 5; i++)
				{
					bumon_cd++;

					// 更新日時が設定されている場合、チェックする。
					if (!string.IsNullOrEmpty(upd_ymd_list[i].ToString()) && !string.IsNullOrEmpty(upd_tm_list[i].ToString()))
					{
						ArrayList bindList = new ArrayList();
						BindInfoVO bindVO = new BindInfoVO();

						// 店舗コード
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_TENPO_CD";
						bindVO.Value = BoSystemFormat.formatTenpoCd((string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_cd)]);
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						// 月度
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_GETUDO";
						bindVO.Value = f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Getudo)].ToString().PadLeft(2, '0');
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						// 日販部門コード
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_NIPPANBUMON_CD";
						bindVO.Value = bumon_cd.ToString();
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);
						
						// 排他チェック
						V03003Check.CheckHaitaMaxVal(
								Convert.ToDecimal(upd_ymd_list[i]),
								Convert.ToDecimal(upd_tm_list[i]),
								facadeContext,
								"MDAT0090",
								sRepSql.ToString(),
								bindList,
								1
						);
					}

					//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}
				}
				#endregion

				#endregion

				#region 更新処理

				int iMrgYosan = 0;

				// 部門１～５の予算を登録する。
				bumon_cd = 0;
				for (int i = 0; i < 5; i++)
				{
					bumon_cd++;

					// [日販部門予算TBL]をマージする。
					BoSystemLog.logOut("[[日販部門予算TBL]をマージ START");
					iMrgYosan += Mrg_Yosan(facadeContext, f01VO, m1List, logininfo, sysDateVO, bumon_cd);
					BoSystemLog.logOut("[[日販部門予算TBL]をマージ END");
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

		#region [日販部門予算TBL]をマージする。
		/// <summary>
		/// [日販部門予算TBL]をマージする。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01VO">画面VO</param>
		/// <param name="m1List">明細データ</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="bumon_cd">日販部門コード</param>
		/// <returns>更新件数</returns>
		private int Mrg_Yosan(IFacadeContext facadeContext,
									Tf060f01Form f01VO,
									IDataList m1List,
									LoginInfoVO loginInfo,
									SysDateVO sysDateVO,
									int bumon_cd)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable("TF060P01-02", facadeContext.DBContext);

			// 店舗コード（検索押下時の内容）
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_cd)]));
			// 月度（検索押下時の内容）
			reader.BindValue("BIND_GETUDO", f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Getudo)].ToString().PadLeft(2, '0'));
			// 日販部門コード
			reader.BindValue("BIND_NIPPANBUMON_CD", bumon_cd);

			// 予算額1
			reader.BindValue("BIND_YOSAN1_KIN", getYosanKin(m1List, bumon_cd, 1));
			// 予算額2
			reader.BindValue("BIND_YOSAN2_KIN", getYosanKin(m1List, bumon_cd, 2));
			// 予算額3
			reader.BindValue("BIND_YOSAN3_KIN", getYosanKin(m1List, bumon_cd, 3));
			// 予算額4
			reader.BindValue("BIND_YOSAN4_KIN", getYosanKin(m1List, bumon_cd, 4));
			// 予算額5
			reader.BindValue("BIND_YOSAN5_KIN", getYosanKin(m1List, bumon_cd, 5));
			// 予算額6
			reader.BindValue("BIND_YOSAN6_KIN", getYosanKin(m1List, bumon_cd, 6));
			// 予算額7
			reader.BindValue("BIND_YOSAN7_KIN", getYosanKin(m1List, bumon_cd, 7));
			// 予算額8
			reader.BindValue("BIND_YOSAN8_KIN", getYosanKin(m1List, bumon_cd, 8));
			// 予算額9
			reader.BindValue("BIND_YOSAN9_KIN", getYosanKin(m1List, bumon_cd, 9));
			// 予算額10
			reader.BindValue("BIND_YOSAN10_KIN", getYosanKin(m1List, bumon_cd, 10));
			// 予算額11
			reader.BindValue("BIND_YOSAN11_KIN", getYosanKin(m1List, bumon_cd, 11));
			// 予算額12
			reader.BindValue("BIND_YOSAN12_KIN", getYosanKin(m1List, bumon_cd, 12));
			// 予算額13
			reader.BindValue("BIND_YOSAN13_KIN", getYosanKin(m1List, bumon_cd, 13));
			// 予算額14
			reader.BindValue("BIND_YOSAN14_KIN", getYosanKin(m1List, bumon_cd, 14));
			// 予算額15
			reader.BindValue("BIND_YOSAN15_KIN", getYosanKin(m1List, bumon_cd, 15));
			// 予算額16
			reader.BindValue("BIND_YOSAN16_KIN", getYosanKin(m1List, bumon_cd, 16));
			// 予算額17
			reader.BindValue("BIND_YOSAN17_KIN", getYosanKin(m1List, bumon_cd, 17));
			// 予算額18
			reader.BindValue("BIND_YOSAN18_KIN", getYosanKin(m1List, bumon_cd, 18));
			// 予算額19
			reader.BindValue("BIND_YOSAN19_KIN", getYosanKin(m1List, bumon_cd, 19));
			// 予算額20
			reader.BindValue("BIND_YOSAN20_KIN", getYosanKin(m1List, bumon_cd, 20));
			// 予算額21
			reader.BindValue("BIND_YOSAN21_KIN", getYosanKin(m1List, bumon_cd, 21));
			// 予算額22
			reader.BindValue("BIND_YOSAN22_KIN", getYosanKin(m1List, bumon_cd, 22));
			// 予算額23
			reader.BindValue("BIND_YOSAN23_KIN", getYosanKin(m1List, bumon_cd, 23));
			// 予算額24
			reader.BindValue("BIND_YOSAN24_KIN", getYosanKin(m1List, bumon_cd, 24));
			// 予算額25
			reader.BindValue("BIND_YOSAN25_KIN", getYosanKin(m1List, bumon_cd, 25));
			// 予算額26
			reader.BindValue("BIND_YOSAN26_KIN", getYosanKin(m1List, bumon_cd, 26));
			// 予算額27
			reader.BindValue("BIND_YOSAN27_KIN", getYosanKin(m1List, bumon_cd, 27));
			// 予算額28
			reader.BindValue("BIND_YOSAN28_KIN", getYosanKin(m1List, bumon_cd, 28));
			// 予算額29
			reader.BindValue("BIND_YOSAN29_KIN", getYosanKin(m1List, bumon_cd, 29));
			// 予算額30
			reader.BindValue("BIND_YOSAN30_KIN", getYosanKin(m1List, bumon_cd, 30));
			// 予算額31
			reader.BindValue("BIND_YOSAN31_KIN", getYosanKin(m1List, bumon_cd, 31));
			// 予算額合計
			reader.BindValue("BIND_YOSANGOKEI_KIN", getYosanGokei(f01VO, bumon_cd));
			// 登録日
			reader.BindValue("BIND_ADD_YMD", Convert.ToDecimal(sysDateVO.Sysdate));
			// 登録時間
			reader.BindValue("BIND_ADD_TM", Convert.ToDecimal(sysDateVO.Systime_mili));
			// 登録担当者コード
			reader.BindValue("BIND_ADDTAN_CD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 更新日
			reader.BindValue("BIND_UPD_YMD", Convert.ToDecimal(sysDateVO.Sysdate));
			// 更新時間
			reader.BindValue("BIND_UPD_TM", Convert.ToDecimal(sysDateVO.Systime_mili));
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 削除日
			reader.BindValue("BIND_SAKUJYO_YMD", Convert.ToDecimal(sysDateVO.Sysdate));
			// 削除フラグ
			reader.BindValue("BIND_SAKUJYO_FLG", 0);
			// 送信依頼フラグ
			reader.BindValue("BIND_SOSINIRAI_FLG", 1);
			// 送信済フラグ
			reader.BindValue("BIND_SOSINZUMI_FLG", 0);
			// 送信日
			reader.BindValue("BIND_SOSIN_YMD", 0);
			// 送信時間
			reader.BindValue("BIND_SOSIN_TM", 0);

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region 対象の予算金額を取得する。
		/// <summary>
		/// 対象の予算金額を取得する。
		/// </summary>
		/// <param name="m1List">明細データ</param>
		/// <param name="bumon_cd">日販部門コード</param>
		/// <param name="day">日</param>
		/// <returns>予算金額</returns>
		private decimal getYosanKin(IDataList m1List,
									int bumon_cd,
									int day)
		{
			decimal yosankin = 0;

			if (m1List.Count >= day)
			{
				Tf060f01M1Form f01m1VO = (Tf060f01M1Form)m1List[day - 1];

				if (bumon_cd == 1)
				{
					yosankin = Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1bumon1_yosan_kin, "0"));
				}
				else if (bumon_cd == 2)
				{
					yosankin = Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1bumon2_yosan_kin, "0"));
				}
				else if (bumon_cd == 3)
				{
					yosankin = Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1bumon3_yosan_kin, "0"));
				}
				else if (bumon_cd == 4)
				{
					yosankin = Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1bumon4_yosan_kin, "0"));
				}
				else if (bumon_cd == 5)
				{
					yosankin = Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1bumon5_yosan_kin, "0"));
				}
			}

			return yosankin;
		}
		#endregion

		#region 対象の予算額合計を取得する。
		/// <summary>
		/// 対象の予算額合計を取得する。
		/// </summary>
		/// <param name="f01VO">画面VO</param>
		/// <param name="bumon_cd">日販部門コード</param>
		/// <returns>予算額合計</returns>
		private decimal getYosanGokei(Tf060f01Form f01VO,
									int bumon_cd)
		{
			decimal yosangokei = 0;

			// 予算額合計
			if (bumon_cd == 1)
			{
				yosangokei = Convert.ToDecimal(f01VO.Bumon1_yosangokei_kin);
			}
			else if (bumon_cd == 2)
			{
				yosangokei = Convert.ToDecimal(f01VO.Bumon2_yosangokei_kin);
			}
			else if (bumon_cd == 3)
			{
				yosangokei = Convert.ToDecimal(f01VO.Bumon3_yosangokei_kin);
			}
			else if (bumon_cd == 4)
			{
				yosangokei = Convert.ToDecimal(f01VO.Bumon4_yosangokei_kin);
			}
			else if (bumon_cd == 5)
			{
				yosangokei = Convert.ToDecimal(f01VO.Bumon5_yosangokei_kin);
			}

			return yosangokei;
		}
		#endregion

		#endregion

	}
}
