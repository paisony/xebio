using com.xebio.bo.Tf070p01.Constant;
using com.xebio.bo.Tf070p01.Formvo;
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

namespace com.xebio.bo.Tf070p01.Facade
{
  /// <summary>
  /// Tf070f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tf070f01Facade : StandardBaseFacade
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

				// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
				#region 初期化
				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Tf070f01Form f01VO = (Tf070f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");
				#endregion

				#region 業務チェック

				#region 選択チェック
				// 1-1 選択状態
				// 1件も選択されていない場合、エラー
				bool selFlg = false;
				for (int i = 0; i < m1List.Count; i++)
				{
					// 明細行オブジェクト取得
					Tf070f01M1Form m1Form = (Tf070f01M1Form)m1List[i];

					if (m1Form.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
					{
						// Ｍ１選択フラグＯＮの場合
						selFlg = true;
						break;
					}
				}

				if (!selFlg)
				{
					// 対象行を選択してください。
					ErrMsgCls.AddErrMsg("E119", "対象行", facadeContext);
				}

				// エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region 排他チェック

				StringBuilder sRepSql = new StringBuilder();

				if (f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_SINSEITORIKESI))
				{
					// [選択モードNo]が「申請済取消」の場合

					// テーブルID
					string tableId = "MDAT0020";	// 経費振替申請TBL(H)

					// 抽出条件
					sRepSql.Append(" AND TONANHINTENPO_CD = :BIND_TONANHINTENPO_CD");	// 盗難品店舗コード
					sRepSql.Append(" AND TONANHINKANRI_NO = :BIND_TONANHINKANRI_NO");	// 盗難品管理番号
					sRepSql.Append(" AND TONANHINSYORI_YMD = :BIND_TONANHINSYORI_YMD");	// 盗難品処理日付

					for (int i = 0; i < m1List.Count; i++)
					{
						Tf070f01M1Form f01m1VO = (Tf070f01M1Form)m1List[i];

						if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
						{
							// Ｍ１選択フラグＯＮの場合

							ArrayList bindList = new ArrayList();
							BindInfoVO bindVO = new BindInfoVO();

							// 盗難品店舗コード
							bindVO = new BindInfoVO();
							bindVO.BindId = "BIND_TONANHINTENPO_CD";
							bindVO.Value = BoSystemFormat.formatTenpoCd((string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_cd)]);
							bindVO.Type = BoSystemSql.BINDTYPE_STRING;
							bindList.Add(bindVO);

							// 盗難品管理番号
							bindVO = new BindInfoVO();
							bindVO.BindId = "BIND_TONANHINKANRI_NO";
							bindVO.Value = BoSystemFormat.formatDenpyoNo((string)f01m1VO.Dictionary[Tf070p01Constant.DIC_M1KANRI_NO]);
							bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;
							bindList.Add(bindVO);

							// 盗難品処理日付
							bindVO = new BindInfoVO();
							bindVO.BindId = "BIND_TONANHINSYORI_YMD";
							bindVO.Value = (string)f01m1VO.Dictionary[Tf070p01Constant.DIC_M1SYORI_YMD];
							bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;
							bindList.Add(bindVO);

							// 排他チェック
							V03003Check.CheckHaitaMaxVal(
								Convert.ToDecimal((string)f01m1VO.Dictionary[Tf070p01Constant.DIC_M1KEIHISINSEI_UPD_YMD]),	// Ｍ１経費申請更新日
								Convert.ToDecimal((string)f01m1VO.Dictionary[Tf070p01Constant.DIC_M1KEIHISINSEI_UPD_TM]),	// Ｍ１経費申請更新時間
								facadeContext,
								tableId,
								sRepSql.ToString(),
								bindList,
								1,
								null,
								f01m1VO.M1rowno,
								i.ToString(),
								"M1",
								m1List.DispRow
								);
						}
					}
				}
				else if (f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_DEL))
				{
					// [選択モードNo]が「取消」の場合、

					// テーブルID
					string tableId = "MDAT0040";	// 盗難品TBL(H)

					// 抽出条件
					sRepSql.Append(" AND TENPO_CD = :BIND_TENPO_CD");	// 店舗コード
					sRepSql.Append(" AND KANRI_NO = :BIND_KANRI_NO");	// 管理No
					sRepSql.Append(" AND SYORI_YMD = :BIND_SYORI_YMD");	// 処理日付

					for (int i = 0; i < m1List.Count; i++)
					{
						Tf070f01M1Form f01m1VO = (Tf070f01M1Form)m1List[i];

						if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
						{
							// Ｍ１選択フラグＯＮの場合

							ArrayList bindList = new ArrayList();
							BindInfoVO bindVO = new BindInfoVO();

							// 店舗コード
							bindVO = new BindInfoVO();
							bindVO.BindId = "BIND_TENPO_CD";
							bindVO.Value = BoSystemFormat.formatTenpoCd((string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_cd)]);
							bindVO.Type = BoSystemSql.BINDTYPE_STRING;
							bindList.Add(bindVO);

							// 管理No
							bindVO = new BindInfoVO();
							bindVO.BindId = "BIND_KANRI_NO";
							bindVO.Value = BoSystemFormat.formatDenpyoNo((string)f01m1VO.Dictionary[Tf070p01Constant.DIC_M1KANRI_NO]);
							bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;
							bindList.Add(bindVO);

							// 処理日付
							bindVO = new BindInfoVO();
							bindVO.BindId = "BIND_SYORI_YMD";
							bindVO.Value = (string)f01m1VO.Dictionary[Tf070p01Constant.DIC_M1SYORI_YMD];
							bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;
							bindList.Add(bindVO);

							// 排他チェック
							V03003Check.CheckHaitaMaxVal(
								Convert.ToDecimal((string)f01m1VO.Dictionary[Tf070p01Constant.DIC_M1UPD_YMD]),	// Ｍ１更新日
								Convert.ToDecimal((string)f01m1VO.Dictionary[Tf070p01Constant.DIC_M1UPD_TM]),	// Ｍ１更新時間
								facadeContext,
								tableId,
								sRepSql.ToString(),
								bindList,
								1,
								null,
								f01m1VO.M1rowno,
								i.ToString(),
								"M1",
								m1List.DispRow
								);
						}
					}
				}

				// エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#endregion

				#region 更新処理

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				for (int i = 0; i < m1List.Count; i++)
				{
					Tf070f01M1Form f01m1VO = (Tf070f01M1Form)m1List[i];
					if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
					{
						if (f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_SINSEITORIKESI))
						{
							#region 申請済取消
							// [経費振替申請TBL(B)]を削除する。
							BoSystemLog.logOut("[経費振替申請TBL(B)]を削除 START");
							int Delcntb = Del_KeihiFurikaeShinseiB(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO);
							BoSystemLog.logOut("[経費振替申請TBL(B)]を削除 END");

							// [経費振替申請TBL(H)]を削除する。
							BoSystemLog.logOut("[経費振替申請TBL(H)]を削除 START");
							int Delcnth = Del_KeihiFurikaeShinseiH(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO);
							BoSystemLog.logOut("[経費振替申請TBL(H)]を削除 END");

							// [盗難品TBL(H)]を更新する。
							BoSystemLog.logOut("[盗難品TBL(H)]を更新 START");
							int Updcnth = Upd_TonanhinH(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO);
							BoSystemLog.logOut("[盗難品TBL(H)]を更新 END");
							#endregion
						}
						else if (f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_DEL))
						{
							#region 取消
							// [盗難品TBL(B)]を検索し、[盗難品履歴TBL(B)]を登録する。
							BoSystemLog.logOut("[盗難品TBL(B)]を検索し、[盗難品履歴TBL(B)]を登録 START");
							int Inscntb = Ins_TonanhinRirekiB(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO);
							BoSystemLog.logOut("[盗難品TBL(B)]を検索し、[盗難品履歴TBL(B)]を登録 END");

							// [盗難品TBL(B)]を削除する。
							BoSystemLog.logOut("[盗難品TBL(B)]を削除 START");
							int Delcntb = Del_TonanhinB(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO);
							BoSystemLog.logOut("[盗難品TBL(B)]を削除 END");

							// [盗難品TBL(H)]を検索し、[盗難品履歴TBL(H)]を登録する。
							BoSystemLog.logOut("[盗難品TBL(H)]を検索し、[盗難品履歴TBL(H)]を登録 START");
							int Inscnth = Ins_TonanhinRirekiH(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO);
							BoSystemLog.logOut("[盗難品TBL(H)]を検索し、[盗難品履歴TBL(H)]を登録 END");

							// [盗難品TBL(H)]を削除する。
							BoSystemLog.logOut("[盗難品TBL(H)]を削除 START");
							int Delcnth = Del_TonanhinH(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO);
							BoSystemLog.logOut("[盗難品TBL(H)]を削除 END");
							#endregion
						}
					}
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
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNENTER_FRM");

		}
		#endregion

		#region 経費振替申請TBL(B)削除
		/// <summary>
		/// [経費振替申請TBL(B)]を削除する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private int Del_KeihiFurikaeShinseiB(
			IFacadeContext facadeContext,
			Tf070f01Form f01Form,
			Tf070f01M1Form f01M1Form,
			LoginInfoVO loginInfo,
			SysDateVO sysDateVO
			)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tf070p01Constant.SQL_ID_04, facadeContext.DBContext);

			// 盗難品管理番号
			reader.BindValue("TONANHINKANRI_NO", Convert.ToDecimal(f01M1Form.Dictionary[Tf070p01Constant.DIC_M1KANRI_NO]));
			// 盗難品処理日付
			reader.BindValue("TONANHINSYORI_YMD", Convert.ToDecimal(f01M1Form.Dictionary[Tf070p01Constant.DIC_M1SYORI_YMD]));
			// 盗難品店舗コード
			reader.BindValue("TONANHINTENPO_CD", BoSystemFormat.formatTenpoCd((string)f01Form.Dictionary[SearchConditionSaveCls.GetKey(() => f01Form.Head_tenpo_cd)]));

			// クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region 経費振替申請TBL(H)削除
		/// <summary>
		/// [経費振替申請TBL(H)]を削除する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private int Del_KeihiFurikaeShinseiH(
			IFacadeContext facadeContext,
			Tf070f01Form f01Form,
			Tf070f01M1Form f01M1Form,
			LoginInfoVO loginInfo,
			SysDateVO sysDateVO
			)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tf070p01Constant.SQL_ID_05, facadeContext.DBContext);

			// 盗難品管理番号
			reader.BindValue("TONANHINKANRI_NO", Convert.ToDecimal(f01M1Form.Dictionary[Tf070p01Constant.DIC_M1KANRI_NO]));
			// 盗難品処理日付
			reader.BindValue("TONANHINSYORI_YMD", Convert.ToDecimal(f01M1Form.Dictionary[Tf070p01Constant.DIC_M1SYORI_YMD]));
			// 盗難品店舗コード
			reader.BindValue("TONANHINTENPO_CD", BoSystemFormat.formatTenpoCd((string)f01Form.Dictionary[SearchConditionSaveCls.GetKey(() => f01Form.Head_tenpo_cd)]));

			// クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region 盗難品TBL(H)更新
		/// <summary>
		/// [盗難品TBL(H)]を更新する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private int Upd_TonanhinH(
			IFacadeContext facadeContext,
			Tf070f01Form f01Form,
			Tf070f01M1Form f01M1Form,
			LoginInfoVO loginInfo,
			SysDateVO sysDateVO
			)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tf070p01Constant.SQL_ID_06, facadeContext.DBContext);

			// 更新日
			reader.BindValue("UPD_YMD", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("UPD_TM", sysDateVO.Systime_mili);
			// 更新担当者コード
			reader.BindValue("UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 削除日
			reader.BindValue("SAKUJYO_YMD", sysDateVO.Sysdate);

			// 店舗コード
			reader.BindValue("TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01Form.Dictionary[SearchConditionSaveCls.GetKey(() => f01Form.Head_tenpo_cd)]));
			// 管理№
			reader.BindValue("KANRI_NO", Convert.ToDecimal(f01M1Form.Dictionary[Tf070p01Constant.DIC_M1KANRI_NO]));
			// 処理日付
			reader.BindValue("SYORI_YMD", Convert.ToDecimal(f01M1Form.Dictionary[Tf070p01Constant.DIC_M1SYORI_YMD]));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region 盗難品履歴TBL(B)登録
		/// <summary>
		/// [盗難品TBL(B)]を検索し、[盗難品履歴TBL(B)]を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private int Ins_TonanhinRirekiB(
			IFacadeContext facadeContext,
			Tf070f01Form f01Form,
			Tf070f01M1Form f01M1Form,
			LoginInfoVO loginInfo,
			SysDateVO sysDateVO
			)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tf070p01Constant.SQL_ID_07, facadeContext.DBContext);

			// 店舗コード
			reader.BindValue("TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01Form.Dictionary[SearchConditionSaveCls.GetKey(() => f01Form.Head_tenpo_cd)]));
			// 管理№
			reader.BindValue("KANRI_NO", Convert.ToDecimal(f01M1Form.Dictionary[Tf070p01Constant.DIC_M1KANRI_NO]));
			// 処理日付
			reader.BindValue("SYORI_YMD", Convert.ToDecimal(f01M1Form.Dictionary[Tf070p01Constant.DIC_M1SYORI_YMD]));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region 盗難品TBL(B)削除
		/// <summary>
		/// [盗難品TBL(B)]を削除する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private int Del_TonanhinB(
			IFacadeContext facadeContext,
			Tf070f01Form f01Form,
			Tf070f01M1Form f01M1Form,
			LoginInfoVO loginInfo,
			SysDateVO sysDateVO
			)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tf070p01Constant.SQL_ID_08, facadeContext.DBContext);

			// 店舗コード
			reader.BindValue("TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01Form.Dictionary[SearchConditionSaveCls.GetKey(() => f01Form.Head_tenpo_cd)]));
			// 管理№
			reader.BindValue("KANRI_NO", Convert.ToDecimal(f01M1Form.Dictionary[Tf070p01Constant.DIC_M1KANRI_NO]));
			// 処理日付
			reader.BindValue("SYORI_YMD", Convert.ToDecimal(f01M1Form.Dictionary[Tf070p01Constant.DIC_M1SYORI_YMD]));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region 盗難品履歴TBL(H)登録
		/// <summary>
		/// [盗難品TBL(H)]を検索し、[盗難品履歴TBL(H)]を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private int Ins_TonanhinRirekiH(
			IFacadeContext facadeContext,
			Tf070f01Form f01Form,
			Tf070f01M1Form f01M1Form,
			LoginInfoVO loginInfo,
			SysDateVO sysDateVO
			)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tf070p01Constant.SQL_ID_09, facadeContext.DBContext);

			// 履歴処理日付
			reader.BindValue("RIREKI_SYORI_YMD", Convert.ToDecimal(f01M1Form.Dictionary[Tf070p01Constant.DIC_M1UPD_YMD]));
			// 履歴処理時間
			reader.BindValue("RIREKI_SYORI_TM", Convert.ToDecimal(f01M1Form.Dictionary[Tf070p01Constant.DIC_M1UPD_TM]));

			// 更新日
			reader.BindValue("UPD_YMD", Convert.ToDecimal(f01M1Form.Dictionary[Tf070p01Constant.DIC_M1UPD_YMD]));
			// 更新時間
			reader.BindValue("UPD_TM", Convert.ToDecimal(f01M1Form.Dictionary[Tf070p01Constant.DIC_M1UPD_TM]));
			// 更新担当者コード
			reader.BindValue("UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 削除日
			reader.BindValue("SAKUJYO_YMD", Convert.ToDecimal(f01M1Form.Dictionary[Tf070p01Constant.DIC_M1UPD_YMD]));

			// 店舗コード
			reader.BindValue("TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01Form.Dictionary[SearchConditionSaveCls.GetKey(() => f01Form.Head_tenpo_cd)]));
			// 管理№
			reader.BindValue("KANRI_NO", Convert.ToDecimal(f01M1Form.Dictionary[Tf070p01Constant.DIC_M1KANRI_NO]));
			// 処理日付
			reader.BindValue("SYORI_YMD", Convert.ToDecimal(f01M1Form.Dictionary[Tf070p01Constant.DIC_M1SYORI_YMD]));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region 盗難品TBL(H)削除
		/// <summary>
		/// [盗難品TBL(H)]を削除する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private int Del_TonanhinH(
			IFacadeContext facadeContext,
			Tf070f01Form f01Form,
			Tf070f01M1Form f01M1Form,
			LoginInfoVO loginInfo,
			SysDateVO sysDateVO
			)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tf070p01Constant.SQL_ID_10, facadeContext.DBContext);

			// 店舗コード
			reader.BindValue("TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01Form.Dictionary[SearchConditionSaveCls.GetKey(() => f01Form.Head_tenpo_cd)]));
			// 管理№
			reader.BindValue("KANRI_NO", Convert.ToDecimal(f01M1Form.Dictionary[Tf070p01Constant.DIC_M1KANRI_NO]));
			// 処理日付
			reader.BindValue("SYORI_YMD", Convert.ToDecimal(f01M1Form.Dictionary[Tf070p01Constant.DIC_M1SYORI_YMD]));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion
	}
}
