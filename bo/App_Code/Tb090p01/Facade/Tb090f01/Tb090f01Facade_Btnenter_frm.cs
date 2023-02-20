using com.xebio.bo.Tb090p01.Constant;
using com.xebio.bo.Tb090p01.Formvo;
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

namespace com.xebio.bo.Tb090p01.Facade
{
  /// <summary>
  /// Tb090f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tb090f01Facade : StandardBaseFacade
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
				Tb090f01Form f01VO = (Tb090f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				#endregion

				#region 業務チェック

				#region 行数チェック

				if (m1List == null || m1List.Count <= 0)
				{
					// 取消する行を選択してください。
					ErrMsgCls.AddErrMsg("E119", "取消する行", facadeContext);
				}
				else
				{
					int inputflg = 0;
					for (int i = 0; i < m1List.Count; i++)
					{
						Tb090f01M1Form f01m1VO = (Tb090f01M1Form)m1List[i];

						// [Ｍ１選択フラグ(隠し)]が"1"の場合
						if ( f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
						{
							inputflg = 1;
							break;
						}
					}

					if (inputflg == 0)
					{
						// 取消する行を選択してください。
						ErrMsgCls.AddErrMsg("E119", "取消する行", facadeContext);
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

				sRepSql.Append(" AND MOTOKAKUTEI_SB		= :BIND_MOTOKAKUTEI_SB");
				sRepSql.Append(" AND SIIRESAKI_CD		= :BIND_SIIRESAKI_CD");
				sRepSql.Append(" AND MOTODENPYO_BANGO	= :BIND_MOTODENPYO_BANGO");
				sRepSql.Append(" AND SITEINOHIN_YMD		= :BIND_SITEINOHIN_YMD");
				sRepSql.Append(" AND TENPO_CD			= :BIND_TENPO_CD");
				sRepSql.Append(" AND SHINKURO_FLG		= :BIND_SHINKURO_FLG ");

				for (int i = 0; i < m1List.Count; i++)
				{
					Tb090f01M1Form f01m1VO = (Tb090f01M1Form)m1List[i];

					// [Ｍ１選択フラグ(隠し)]が"1"の場合
					if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
					{
						ArrayList bindList = new ArrayList();
						BindInfoVO bindVO = new BindInfoVO();

						// 元確定種別
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_MOTOKAKUTEI_SB";
						bindVO.Value = (string)f01m1VO.Dictionary[Tb090p01Constant.DIC_M1MOTOKAKUTEI_SB];
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						// 仕入先コード
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_SIIRESAKI_CD";
						bindVO.Value = BoSystemFormat.formatSiiresakiCd(f01m1VO.M1siiresaki_cd);
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						// 元伝票番号
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_MOTODENPYO_BANGO";
						bindVO.Value = BoSystemFormat.formatDenpyoNo((string)f01m1VO.Dictionary[Tb090p01Constant.DIC_M1MOTODENPYO_BANGO]);
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						// 指定納品日
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_SITEINOHIN_YMD";
						bindVO.Value = BoSystemFormat.formatDate(f01m1VO.M1nyukayotei_ymd);
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						// 店舗コード
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_TENPO_CD";
						bindVO.Value = BoSystemFormat.formatTenpoCd((string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_cd)]);
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						// 新黒フラグ
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_SHINKURO_FLG";
						bindVO.Value = BoSystemConstant.SHINKURO_FLG_SHINKURO;
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						// 排他チェック
						V03003Check.CheckHaitaMaxVal(
								Convert.ToDecimal((string)f01m1VO.Dictionary[Tb090p01Constant.DIC_M1UPD_YMD]),
								Convert.ToDecimal((string)f01m1VO.Dictionary[Tb090p01Constant.DIC_M1UPD_TM]),
								facadeContext,
								"MDPT0020",
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
					Tb090f01M1Form f01m1VO = (Tb090f01M1Form)m1List[i];

					// [Ｍ１選択フラグ(隠し)]が"1"の場合
					if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
					{
						// [仕入入荷確定TBL(H)]【赤伝】を検索し、[仕入入荷履歴TBL(H)]【赤伝】を登録
						BoSystemLog.logOut("[仕入入荷確定TBL(H)]【赤伝】を検索し、[仕入入荷履歴TBL(H)]【赤伝】を登録 START");
						int Inscntrirekiakah = Ins_ShiireRirekiAkah(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO);
						BoSystemLog.logOut("[仕入入荷確定TBL(H)]【赤伝】を検索し、[仕入入荷履歴TBL(H)]【赤伝】を登録 END  ");

						// [仕入入荷確定TBL(B)]【赤伝】を検索し、[仕入入荷履歴TBL(B)]【赤伝】を登録
						BoSystemLog.logOut("[仕入入荷確定TBL(B)]【赤伝】を検索し、[仕入入荷履歴TBL(B)]【赤伝】を登録 START");
						int Inscntrirekiakab = Ins_ShiireRirekiAkab(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO);
						BoSystemLog.logOut("[仕入入荷確定TBL(B)]【赤伝】を検索し、[仕入入荷履歴TBL(B)]【赤伝】を登録 END  ");

						// [仕入入荷確定TBL(H)]【新黒伝】を検索し、[仕入入荷履歴TBL(H)]【赤伝】を登録
						BoSystemLog.logOut("[仕入入荷確定TBL(H)]【新黒伝】を検索し、[仕入入荷履歴TBL(H)]【赤伝】を登録 START");
						int Inscntrirekikuroh = Ins_ShiireRirekiKuroh(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO);
						BoSystemLog.logOut("[仕入入荷確定TBL(H)]【新黒伝】を検索し、[仕入入荷履歴TBL(H)]【赤伝】を登録 END  ");

						// [仕入入荷確定TBL(B)]【新黒伝】を検索し、[仕入入荷履歴TBL(B)]【赤伝】を登録
						BoSystemLog.logOut("[仕入入荷確定TBL(B)]【新黒伝】を検索し、[仕入入荷履歴TBL(B)]【赤伝】を登録 START");
						int Inscntrirekikurob = Ins_ShiireRirekiKurob(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO);
						BoSystemLog.logOut("[仕入入荷確定TBL(B)]【新黒伝】を検索し、[仕入入荷履歴TBL(B)]【赤伝】を登録 END  ");

						// [仕入入荷確定TBL(B)]【赤伝】【新黒伝】を削除
						BoSystemLog.logOut("[仕入入荷確定TBL(B)]【赤伝】【新黒伝】を削除 START");
						int Delcntkakub = Del_ShiireKakuteib(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO);
						BoSystemLog.logOut("[仕入入荷確定TBL(B)]【赤伝】【新黒伝】を削除 END  ");

						// [仕入入荷確定TBL(H)]【赤伝】【新黒伝】を削除
						BoSystemLog.logOut("[仕入入荷確定TBL(H)]【赤伝】【新黒伝】を削除 START");
						int Delcntkakuh = Del_ShiireKakuteih(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO);
						BoSystemLog.logOut("[仕入入荷確定TBL(H)]【赤伝】【新黒伝】を削除 END  ");

						// [仕入入荷確定TBL(H)]【元伝】を更新
						BoSystemLog.logOut("[仕入入荷確定TBL(H)]【元伝】を更新 START");
						int Updcntkakuh = Upd_ShiireKakuteih(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO);
						BoSystemLog.logOut("[仕入入荷確定TBL(H)]【元伝】を更新 END  ");

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

		#region [仕入入荷確定TBL(H)]【赤伝】を検索し、[仕入入荷履歴TBL(H)]【赤伝】を登録
		/// <summary>
		/// [仕入入荷確定TBL(H)]【赤伝】を検索し、[仕入入荷履歴TBL(H)]【赤伝】を登録を行います。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="dDenno">伝票番号</param>
		/// <returns>更新件数</returns>
		private int Ins_ShiireRirekiAkah(IFacadeContext facadeContext,
										Tb090f01Form f01Form,
										Tb090f01M1Form f01M1Form,
										LoginInfoVO loginInfo,
										SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tb090p01Constant.SQL_ID_04, facadeContext.DBContext);

			decimal syoriSb = 5;
			decimal akakuroKbn = 2;
			decimal kakuteiSb = Convert.ToDecimal((string)f01M1Form.Dictionary[Tb090p01Constant.DIC_M1KAKUTEI_SB]);

			// 処理種別（[3]訂正 [4]訂正修正 [5]訂正取消）
			reader.BindValue("BIND_SYORI_SB_1", syoriSb);
			reader.BindValue("BIND_SYORI_SB_2", syoriSb);
			reader.BindValue("BIND_SYORI_SB_3", syoriSb);
			reader.BindValue("BIND_SYORI_SB_4", syoriSb);
			reader.BindValue("BIND_SYORI_SB_5", syoriSb);
			// 赤黒区分（[1]黒伝 [2]赤伝）
			reader.BindValue("BIND_AKAKURO_KBN_1", akakuroKbn);
			reader.BindValue("BIND_AKAKURO_KBN_2", akakuroKbn);
			reader.BindValue("BIND_AKAKURO_KBN_3", akakuroKbn);
			reader.BindValue("BIND_AKAKURO_KBN_4", akakuroKbn);
			reader.BindValue("BIND_AKAKURO_KBN_5", akakuroKbn);
			reader.BindValue("BIND_AKAKURO_KBN_6", akakuroKbn);
			// 履歴処理日
			reader.BindValue("BIND_SYORI_YMD", sysDateVO.Sysdate);
			// 履歴処理時間
			reader.BindValue("BIND_SYORI_TM", sysDateVO.Systime_mili);
			// 確定種別
			reader.BindValue("BIND_KAKUTEI_SB_1", kakuteiSb);
			// 更新日
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));

			// 登録条件
			// 確定種別
			reader.BindValue("BIND_KAKUTEI_SB_2", kakuteiSb);
			reader.BindValue("BIND_KAKUTEI_SB_3", kakuteiSb);
			// 仕入先コード
			reader.BindValue("BIND_SIIRESAKI_CD", BoSystemFormat.formatSiiresakiCd(f01M1Form.M1siiresaki_cd));
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal(BoSystemFormat.formatDenpyoNo(f01M1Form.M1aka_denpyo_bango)));
			// 指定納品日
			reader.BindValue("BIND_SITEINOHIN_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01M1Form.M1nyukayotei_ymd)));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01Form.Dictionary[SearchConditionSaveCls.GetKey(() => f01Form.Head_tenpo_cd)]));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [仕入入荷確定TBL(B)]【赤伝】を検索し、[仕入入荷履歴TBL(B)]【赤伝】を登録
		/// <summary>
		/// [仕入入荷確定TBL(B)]【赤伝】を検索し、[仕入入荷履歴TBL(B)]【赤伝】を登録を行います。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="dDenno">伝票番号</param>
		/// <returns>更新件数</returns>
		private int Ins_ShiireRirekiAkab(IFacadeContext facadeContext,
										Tb090f01Form f01Form,
										Tb090f01M1Form f01M1Form,
										LoginInfoVO loginInfo,
										SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tb090p01Constant.SQL_ID_05, facadeContext.DBContext);


			decimal syoriSb = 5;
			decimal akakuroKbn = 2;
			decimal kakuteiSb = Convert.ToDecimal((string)f01M1Form.Dictionary[Tb090p01Constant.DIC_M1KAKUTEI_SB]);
			decimal denpyogyoNo = 0;

			// 処理種別（[3]訂正 [4]訂正修正 [5]訂正取消）
			reader.BindValue("BIND_SYORI_SB_1", syoriSb);
			reader.BindValue("BIND_SYORI_SB_2", syoriSb);
			// 赤黒区分（[1]黒伝 [2]赤伝）
			reader.BindValue("BIND_AKAKURO_KBN_1", akakuroKbn);
			reader.BindValue("BIND_AKAKURO_KBN_2", akakuroKbn);

			// 登録条件
			// 確定種別
			reader.BindValue("BIND_KAKUTEI_SB_1", kakuteiSb);
			reader.BindValue("BIND_KAKUTEI_SB_2", kakuteiSb);
			// 仕入先コード
			reader.BindValue("BIND_SIIRESAKI_CD", BoSystemFormat.formatSiiresakiCd(f01M1Form.M1siiresaki_cd));
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal(BoSystemFormat.formatDenpyoNo(f01M1Form.M1aka_denpyo_bango)));
			// 指定納品日
			reader.BindValue("BIND_SITEINOHIN_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01M1Form.M1nyukayotei_ymd)));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01Form.Dictionary[SearchConditionSaveCls.GetKey(() => f01Form.Head_tenpo_cd)]));
			// 伝票行№(伝票単位のため0を設定)
			reader.BindValue("BIND_DENPYOGYO_NO_1", denpyogyoNo);
			reader.BindValue("BIND_DENPYOGYO_NO_2", denpyogyoNo);

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [仕入入荷確定TBL(H)]【新黒伝】を検索し、[仕入入荷履歴TBL(H)]【赤伝】を登録
		/// <summary>
		/// [仕入入荷確定TBL(H)]【新黒伝】を検索し、[仕入入荷履歴TBL(H)]【赤伝】を登録を行います。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="dDenno">伝票番号</param>
		/// <returns>更新件数</returns>
		private int Ins_ShiireRirekiKuroh(IFacadeContext facadeContext,
										Tb090f01Form f01Form,
										Tb090f01M1Form f01M1Form,
										LoginInfoVO loginInfo,
										SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tb090p01Constant.SQL_ID_04, facadeContext.DBContext);

			decimal syoriSb = 5;
			decimal akakuroKbn = 2;
			decimal kakuteiSb = Convert.ToDecimal((string)f01M1Form.Dictionary[Tb090p01Constant.DIC_M1KAKUTEI_SB]);

			// 処理種別（[3]訂正 [4]訂正修正 [5]訂正取消）
			reader.BindValue("BIND_SYORI_SB_1", syoriSb);
			reader.BindValue("BIND_SYORI_SB_2", syoriSb);
			reader.BindValue("BIND_SYORI_SB_3", syoriSb);
			reader.BindValue("BIND_SYORI_SB_4", syoriSb);
			reader.BindValue("BIND_SYORI_SB_5", syoriSb);
			// 赤黒区分（[1]黒伝 [2]赤伝）
			reader.BindValue("BIND_AKAKURO_KBN_1", akakuroKbn);
			reader.BindValue("BIND_AKAKURO_KBN_2", akakuroKbn);
			reader.BindValue("BIND_AKAKURO_KBN_3", akakuroKbn);
			reader.BindValue("BIND_AKAKURO_KBN_4", akakuroKbn);
			reader.BindValue("BIND_AKAKURO_KBN_5", akakuroKbn);
			reader.BindValue("BIND_AKAKURO_KBN_6", akakuroKbn);
			// 履歴処理日
			reader.BindValue("BIND_SYORI_YMD", sysDateVO.Sysdate);
			// 履歴処理時間
			reader.BindValue("BIND_SYORI_TM", sysDateVO.Systime_mili);
			// 確定種別
			reader.BindValue("BIND_KAKUTEI_SB_1", kakuteiSb);
			// 更新日
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));

			// 登録条件
			// 確定種別
			reader.BindValue("BIND_KAKUTEI_SB_2", kakuteiSb);
			reader.BindValue("BIND_KAKUTEI_SB_3", kakuteiSb);
			// 仕入先コード
			reader.BindValue("BIND_SIIRESAKI_CD", BoSystemFormat.formatSiiresakiCd(f01M1Form.M1siiresaki_cd));
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal(BoSystemFormat.formatDenpyoNo(f01M1Form.M1kuro_denpyo_bango)));
			// 指定納品日
			reader.BindValue("BIND_SITEINOHIN_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01M1Form.M1nyukayotei_ymd)));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01Form.Dictionary[SearchConditionSaveCls.GetKey(() => f01Form.Head_tenpo_cd)]));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [仕入入荷確定TBL(B)]【新黒伝】を検索し、[仕入入荷履歴TBL(B)]【赤伝】を登録
		/// <summary>
		/// [仕入入荷確定TBL(B)]【新黒伝】を検索し、[仕入入荷履歴TBL(B)]【赤伝】を登録を行います。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="dDenno">伝票番号</param>
		/// <returns>更新件数</returns>
		private int Ins_ShiireRirekiKurob(IFacadeContext facadeContext,
										Tb090f01Form f01Form,
										Tb090f01M1Form f01M1Form,
										LoginInfoVO loginInfo,
										SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tb090p01Constant.SQL_ID_05, facadeContext.DBContext);


			decimal syoriSb = 5;
			decimal akakuroKbn = 2;
			decimal kakuteiSb = Convert.ToDecimal((string)f01M1Form.Dictionary[Tb090p01Constant.DIC_M1KAKUTEI_SB]);
			decimal denpyogyoNo = 0;

			// 処理種別（[3]訂正 [4]訂正修正 [5]訂正取消）
			reader.BindValue("BIND_SYORI_SB_1", syoriSb);
			reader.BindValue("BIND_SYORI_SB_2", syoriSb);
			// 赤黒区分（[1]黒伝 [2]赤伝）
			reader.BindValue("BIND_AKAKURO_KBN_1", akakuroKbn);
			reader.BindValue("BIND_AKAKURO_KBN_2", akakuroKbn);

			// 登録条件
			// 確定種別
			reader.BindValue("BIND_KAKUTEI_SB_1", kakuteiSb);
			reader.BindValue("BIND_KAKUTEI_SB_2", kakuteiSb);
			// 仕入先コード
			reader.BindValue("BIND_SIIRESAKI_CD", BoSystemFormat.formatSiiresakiCd(f01M1Form.M1siiresaki_cd));
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal(BoSystemFormat.formatDenpyoNo(f01M1Form.M1kuro_denpyo_bango)));
			// 指定納品日
			reader.BindValue("BIND_SITEINOHIN_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01M1Form.M1nyukayotei_ymd)));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01Form.Dictionary[SearchConditionSaveCls.GetKey(() => f01Form.Head_tenpo_cd)]));
			// 伝票行№(伝票単位のため0を設定)
			reader.BindValue("BIND_DENPYOGYO_NO_1", denpyogyoNo);
			reader.BindValue("BIND_DENPYOGYO_NO_2", denpyogyoNo);

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [仕入入荷確定TBL(B)]の削除
		/// <summary>
		/// [仕入入荷確定TBL(B)]の削除を行います。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="dDenno">伝票番号</param>
		/// <returns>更新件数</returns>
		private int Del_ShiireKakuteib(IFacadeContext facadeContext,
									Tb090f01Form f01Form,
									Tb090f01M1Form f01M1Form,
									LoginInfoVO loginInfo,
									SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tb090p01Constant.SQL_ID_06, facadeContext.DBContext);

			// 削除条件
			// 確定種別
			reader.BindValue("BIND_KAKUTEI_SB", Convert.ToDecimal(f01M1Form.Dictionary[Tb090p01Constant.DIC_M1KAKUTEI_SB]));
			// 仕入先コード
			reader.BindValue("BIND_SIIRESAKI_CD", BoSystemFormat.formatSiiresakiCd(f01M1Form.M1siiresaki_cd));
			// 指定納品日
			reader.BindValue("BIND_SITEINOHIN_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01M1Form.M1nyukayotei_ymd)));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01Form.Dictionary[SearchConditionSaveCls.GetKey(() => f01Form.Head_tenpo_cd)]));
			// 元伝票番号
			reader.BindValue("BIND_MOTODENPYO_BANGO", Convert.ToDecimal(BoSystemFormat.formatDenpyoNo((string)f01M1Form.Dictionary[Tb090p01Constant.DIC_M1MOTODENPYO_BANGO])));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [仕入入荷確定TBL(H)]の削除
		/// <summary>
		/// [仕入入荷確定TBL(H)]の削除を行います。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="dDenno">伝票番号</param>
		/// <returns>更新件数</returns>
		private int Del_ShiireKakuteih(IFacadeContext facadeContext,
									Tb090f01Form f01Form,
									Tb090f01M1Form f01M1Form,
									LoginInfoVO loginInfo,
									SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tb090p01Constant.SQL_ID_07, facadeContext.DBContext);

			// 削除条件
			// 確定種別
			reader.BindValue("BIND_KAKUTEI_SB", Convert.ToDecimal(f01M1Form.Dictionary[Tb090p01Constant.DIC_M1KAKUTEI_SB]));
			// 仕入先コード
			reader.BindValue("BIND_SIIRESAKI_CD", BoSystemFormat.formatSiiresakiCd(f01M1Form.M1siiresaki_cd));
			// 元伝票番号
			reader.BindValue("BIND_MOTODENPYO_BANGO", Convert.ToDecimal(BoSystemFormat.formatDenpyoNo((string)f01M1Form.Dictionary[Tb090p01Constant.DIC_M1MOTODENPYO_BANGO])));
			// 指定納品日
			reader.BindValue("BIND_SITEINOHIN_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01M1Form.M1nyukayotei_ymd)));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01Form.Dictionary[SearchConditionSaveCls.GetKey(() => f01Form.Head_tenpo_cd)]));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [仕入入荷確定TBL(H)]を更新する。
		/// <summary>
		/// [仕入入荷確定TBL(H)]を更新する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private int Upd_ShiireKakuteih(IFacadeContext facadeContext,
									Tb090f01Form f01Form,
									Tb090f01M1Form f01M1Form,
									LoginInfoVO loginInfo,
									SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tb090p01Constant.SQL_ID_08, facadeContext.DBContext);

			// 更新内容
			// 新黒フラグ
			reader.BindValue("BIND_SHINKURO_FLG", Convert.ToDecimal(BoSystemConstant.SHINKURO_FLG_SHINKURO));
			// 更新日
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));

			// 更新条件
			// 確定種別
			reader.BindValue("BIND_KAKUTEI_SB", Convert.ToDecimal(f01M1Form.Dictionary[Tb090p01Constant.DIC_M1MOTOKAKUTEI_SB]));
			// 仕入先コード
			reader.BindValue("BIND_SIIRESAKI_CD", BoSystemFormat.formatSiiresakiCd(f01M1Form.M1siiresaki_cd));
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal(BoSystemFormat.formatDenpyoNo((string)f01M1Form.Dictionary[Tb090p01Constant.DIC_M1MOTODENPYO_BANGO])));
			// 指定納品日
			reader.BindValue("BIND_SITEINOHIN_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01M1Form.M1nyukayotei_ymd)));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01Form.Dictionary[SearchConditionSaveCls.GetKey(() => f01Form.Head_tenpo_cd)]));

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
