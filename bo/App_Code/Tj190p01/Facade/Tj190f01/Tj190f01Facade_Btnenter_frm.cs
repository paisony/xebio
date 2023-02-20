using com.xebio.bo.Tj190p01.Constant;
using com.xebio.bo.Tj190p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C99999.Constant;
using Common.Business.C99999.DbUtil;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V03000.V03003;
using Common.Entitys.VO;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace com.xebio.bo.Tj190p01.Facade
{
  /// <summary>
  /// Tj190f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tj190f01Facade : StandardBaseFacade
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
				Tj190f01Form f01VO = (Tj190f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);
				#endregion

				#region 業務チェック

				#region 行数チェック

				// 1-1 選択状態
				// 1件も選択されていない場合、エラー
				if (m1List == null || m1List.Count <= 0)
				{
					ErrMsgCls.AddErrMsg("E119", "対象行", facadeContext);
				}
				else
				{
					int inputflg = 0;
					for (int i = 0; i < m1List.Count; i++)
					{
						Tj190f01M1Form f01m1VO = (Tj190f01M1Form)m1List[i];
						if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
						{
							inputflg = 1;
							break;
						}
					}
					if (inputflg == 0)
					{
						ErrMsgCls.AddErrMsg("E119", "対象行", facadeContext);
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region マスタ存在チェック(警告)
				// 2-1 Ｍ１店舗コード
				// [選択モードNo]が「ロス計算」の場合
				// 臨時棚卸TBL(H)、臨時棚卸TBL(B)を検索し、重複データが存在していた場合、警告メッセージ

				// 警告メッセージの応答結果を取得
				string waningFlg = BoSystemString.Nvl(facadeContext.GetUserObject(BoSystemConstant.WARNING_FCD_KEY) as String, "0");
				if (!waningFlg.Equals("1")) 
				{
					if (BoSystemConstant.MODE_LOSSKEISAN.Equals(f01VO.Stkmodeno))
					{
						// 重複チェック
						if (!TyohukuCheck(m1List, facadeContext))
						{
							// 警告メッセージを表示する
							InfoMsgCls.AddWarnMsg("W116", String.Empty, facadeContext);
							
							if (InfoMsgCls.HasWarn(facadeContext))
							{
								return;
							}

						}
					}
				}
				#endregion

				#region 排他チェック

				// 取消モード、ロス取消モードの場合
				if (BoSystemConstant.MODE_DEL.Equals(f01VO.Stkmodeno)
					 || BoSystemConstant.MODE_LOSSDEL.Equals(f01VO.Stkmodeno))
				{


					StringBuilder sRepSql = new StringBuilder();
					String tableId = string.Empty;

					sRepSql.Append(" AND TENPO_CD = :BIND_TENPO_CD");					// 店舗コード

					// 取消モードの場合
					if (BoSystemConstant.MODE_DEL.Equals(f01VO.Stkmodeno))
					{
						sRepSql.Append(" AND RINTANA_KANRI_NO = :BIND_KANRI_NO");		// 臨棚管理№
						tableId = Tj190p01Constant.RINJI_TABLE_H;
					}
					// ロス取消モードの場合
					else if (BoSystemConstant.MODE_LOSSDEL.Equals(f01VO.Stkmodeno))
					{
						sRepSql.Append(" AND LOSS_KANRI_NO = :BIND_KANRI_NO");			// ロス管理No
						tableId = Tj190p01Constant.RINJI_LOSS_TABLE_H;
					}
					else
					{
						// 通らない
					}

					sRepSql.Append(" AND SYORI_YMD = :BIND_SYORI_YMD");					// 処理日付


					for (int i = 0; i < m1List.Count; i++)
					{
						Tj190f01M1Form f01m1VO = (Tj190f01M1Form)m1List[i];
						// 選択行
						if (BoSystemConstant.CHECKBOX_ON.Equals(f01m1VO.M1selectorcheckbox))
						{
							ArrayList bindList = new ArrayList();
							BindInfoVO bindVO = new BindInfoVO();

							// 店舗コード
							bindVO = new BindInfoVO();
							bindVO.BindId = "BIND_TENPO_CD";
							bindVO.Value = BoSystemFormat.formatTenpoCd(f01m1VO.M1tenpo_cd);
							bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
							bindList.Add(bindVO);

							// 臨棚管理№/ロス管理No
							bindVO = new BindInfoVO();
							bindVO.BindId = "BIND_KANRI_NO";
							// 明細部のDictionaryより取得
							// 取消モードの場合
							if (BoSystemConstant.MODE_DEL.Equals(f01VO.Stkmodeno))
							{
								bindVO.Value = BoSystemString.Nvl(f01m1VO.Dictionary[Tj190p01Constant.DIC_M1RINTANA_KANRI_NO].ToString(),"0");
							}
							else
							{
								bindVO.Value = BoSystemString.Nvl(f01m1VO.Dictionary[Tj190p01Constant.DIC_M1LOSS_KANRI_NO].ToString(),"0");
							}
							bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
							bindList.Add(bindVO);

							// 処理日付
							bindVO = new BindInfoVO();
							bindVO.BindId = "BIND_SYORI_YMD";
							// 明細部より取得
							bindVO.Value = (string)f01m1VO.Dictionary[Tj190p01Constant.DIC_M1SYORI_YMD];
							bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
							bindList.Add(bindVO);

							// 排他チェック
							V03003Check.CheckHaitaMaxVal(
									Convert.ToDecimal((string)f01m1VO.Dictionary[Tj190p01Constant.DIC_M1UPD_YMD]),
									Convert.ToDecimal((string)f01m1VO.Dictionary[Tj190p01Constant.DIC_M1UPD_TM]),
									facadeContext,
									tableId,
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
				}
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#endregion

				#region 更新処理

				// [選択モードNo]の値によって、処理を分岐する
				// 取消モードの場合
				if (BoSystemConstant.MODE_DEL.Equals(f01VO.Stkmodeno))
				{
					// 取消処理
					EnterModeDel(facadeContext, f01VO, m1List, logininfo);
				}
				// ロス計算モードの場合
				else if (BoSystemConstant.MODE_LOSSKEISAN.Equals(f01VO.Stkmodeno))
				{
					// ロス計算処理
					EnterModeLosskeisan(facadeContext, f01VO, m1List, logininfo, sysDateVO);

					//エラーが発生した場合、その時点で処理を中止しクライアント側へエラー内容を返却する。
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}
				}
				// ロス取消モードの場合
				else if (BoSystemConstant.MODE_LOSSDEL.Equals(f01VO.Stkmodeno))
				{
					// ロス取消処理
					EnterModeLossdel(facadeContext, f01VO, m1List, logininfo);
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

		#region 重複チェック
		/// <summary>
		/// TyohukuCheck 重複チェック
		/// </summary>
		/// <param name="IDataList">m1List</param>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <returns>カウント</returns>
		private Boolean TyohukuCheck(IDataList m1List, IFacadeContext facadeContex)
		{
			Boolean retFlg = true;

			FindSqlResultTable rtChk = FindSqlUtil.CreateFindSqlResultTable(Tj190p01Constant.SQL_ID_05, facadeContex.DBContext);
			// 条件設定 コンディション1
			TyohukuCheckAddWhere(m1List, rtChk, Tj190p01Constant.SQL_ID_05_REP_ID_SUBCONDITION1);
			// 条件設定 コンディション2
			TyohukuCheckAddWhere(m1List, rtChk, Tj190p01Constant.SQL_ID_05_REP_ID_SUBCONDITION2);

			// 検索処理
			rtChk.CreateDbCommand();
			IList<Hashtable> tableListcnt = rtChk.Execute();
			BoSystemLog.logOut("SQL: " + rtChk.LogSql);

			// 件数が0件の場合、正常
			if (tableListcnt == null || tableListcnt.Count <= 0)
			{
				retFlg = true;
			}
			else
			{

				// 明細と取得した情報を見比べ重複チェック
				for (int i = 0; i < m1List.Count; i++)
				{
					Tj190f01M1Form f01m1VO = (Tj190f01M1Form)m1List[i];
					foreach (Hashtable rec in tableListcnt)
					{
						if (BoSystemFormat.formatTenpoCd(f01m1VO.M1tenpo_cd).Equals(rec["TENPO_CD"].ToString())
							&& f01m1VO.Dictionary[Tj190p01Constant.DIC_M1RINTANA_KANRI_NO].ToString().Equals(rec["RINTANA_KANRI_NO"].ToString())
							&& BoSystemString.Nvl(f01m1VO.Dictionary[Tj190p01Constant.DIC_M1SYORI_YMD].ToString(),"0").Equals(rec["SYORI_YMD"].ToString()))
						{
							retFlg = false;
							break;
						}
					}
				}
			}

			return retFlg;
		}
		#endregion

		#region 重複チェック　条件設定
		/// <summary>
		/// TyohukuCheckAddWhere 重複チェック　条件設定
		/// </summary>
		/// <param name="IDataList">m1List</param>
		/// <param name="FindSqlResultTable">reader</param>
		/// <param name="String">置き換え変数</param>
		/// <returns></returns>
		private void TyohukuCheckAddWhere(IDataList m1List , FindSqlResultTable reader , String sRepId)
		{
			ArrayList bindList = new ArrayList();
			BindInfoVO bindVO = new BindInfoVO();
			StringBuilder sRepSql = new StringBuilder();
			StringBuilder sBindId = new StringBuilder();

			String First_flg = "S";

			// プレフィクス
			String sPrefix = string.Empty;
			if (Tj190p01Constant.SQL_ID_05_REP_ID_SUBCONDITION1.Equals(sRepId))
			{
				sPrefix = "MAIN_";
			}
			else if (Tj190p01Constant.SQL_ID_05_REP_ID_SUBCONDITION2.Equals(sRepId))
			{
				sPrefix = "SUB_";
			}

			// 条件設定
			for (int i = 0; i < m1List.Count; i++)
			{

				Tj190f01M1Form f01m1VO = (Tj190f01M1Form)m1List[i];

				if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
				{
					//1件目はカンマをつけない。
					if (First_flg == "S")
					{
						sRepSql.Append(" AND (A.TENPO_CD, A.RINTANA_KANRI_NO, A.SYORI_YMD) IN (");
						//初回フラグを終了させる
						First_flg = "E";
					}
					else
					{
						sRepSql.Append(",");
					}
					sRepSql.Append(("("));
					// 店舗コード
					sBindId = new StringBuilder();
					sBindId.Append(sPrefix).Append("BIND_TENPO_CD").Append(i.ToString("0000"));
					sRepSql.Append(" :").Append(sBindId.ToString());

					bindVO = new BindInfoVO();
					bindVO.BindId = sBindId.ToString();
					bindVO.Value = BoSystemFormat.formatTenpoCd(f01m1VO.M1tenpo_cd);
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 管理No
					sBindId = new StringBuilder();
					sBindId.Append(sPrefix).Append("BIND_KANRI_NO").Append(i.ToString("0000"));
					sRepSql.Append(" ,:").Append(sBindId.ToString());

					bindVO = new BindInfoVO();
					bindVO.BindId = sBindId.ToString();
					bindVO.Value = BoSystemString.Nvl(f01m1VO.Dictionary[Tj190p01Constant.DIC_M1RINTANA_KANRI_NO].ToString(),"0");
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 処理日付
					sBindId = new StringBuilder();
					sBindId.Append(sPrefix).Append("BIND_SYORI_YMD").Append(i.ToString("0000"));
					sRepSql.Append(" ,:").Append(sBindId.ToString());

					bindVO = new BindInfoVO();
					bindVO.BindId = sBindId.ToString();
					bindVO.Value = (string)f01m1VO.Dictionary[Tj190p01Constant.DIC_M1SYORI_YMD];
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					sRepSql.Append((")"));
				}
			}

			sRepSql.Append((")"));

			BoSystemSql.AddSql(reader, sRepId, sRepSql.ToString(), bindList);

		}
		#endregion

		#region 更新処理 取消
		/// <summary>
		/// EnterModeDel 更新処理 取消
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="Tj190f01Form">画面情報</param>
		/// <param name="IDataList">明細情報</param>
		/// <param name="LoginInfoVO">ログイン情報</param>
		/// <returns>更新件数</returns>
		private void EnterModeDel(IFacadeContext facadeContext, Tj190f01Form f01VO, IDataList m1List, LoginInfoVO loginInfo)
		{
			// 明細単位で以下の処理を実施する。
			for (int i = 0; i < m1List.Count; i++)
			{
				Tj190f01M1Form f01m1VO = (Tj190f01M1Form)m1List[i];

				// [Ｍ１選択フラグ(隠し)]が"1"の場合、以下の処理を実施する。
				if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
				{
					// [臨時棚卸TBL(H)]を削除する。
					BoSystemLog.logOut("[臨時棚卸TBL(H)]を削除する。 START");
					int Delcntkakuteih = Del_Rintanah(facadeContext, f01VO, f01m1VO, loginInfo);
					BoSystemLog.logOut("[臨時棚卸TBL(H)]を削除する。 END");

					// [臨時棚卸TBL(B)]を削除する。
					BoSystemLog.logOut("[臨時棚卸TBL(B)]を削除する。 START");
					int Delcntkakuteib = Del_Rintanab(facadeContext, f01VO, f01m1VO, loginInfo);
					BoSystemLog.logOut("[臨時棚卸TBL(B)]を削除する。 END");
				}
			}
		}
		#endregion

		#region 更新処理 ロス計算
		/// <summary>
		/// EnterModeDel 更新処理 ロス計算
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="Tj190f01Form">画面情報</param>
		/// <param name="IDataList">明細情報</param>
		/// <param name="LoginInfoVO">ログイン情報</param>
		/// <param name="LoginInfoVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private void EnterModeLosskeisan(IFacadeContext facadeContext, Tj190f01Form f01VO, IDataList m1List, LoginInfoVO loginInfo, SysDateVO sysDateVO)
		{

			// [臨時棚卸一時TBL]を登録する。
			InsRintanaTemp(facadeContext, f01VO, m1List, loginInfo, sysDateVO);

			// ロス計算処理起動
			ArrayList rtLossCalc = LossCalc(facadeContext, f01VO, m1List, loginInfo, sysDateVO);

		}
		#endregion

		#region 更新処理 ロス取消
		/// <summary>
		/// EnterModeDel 更新処理 ロス取消
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="Tj190f01Form">画面情報</param>
		/// <param name="IDataList">明細情報</param>
		/// <param name="LoginInfoVO">ログイン情報</param>
		/// <returns>更新件数</returns>
		private void EnterModeLossdel(IFacadeContext facadeContext, Tj190f01Form f01VO, IDataList m1List, LoginInfoVO loginInfo)
		{

			// 明細単位で以下の処理を実施する。
			for (int i = 0; i < m1List.Count; i++)
			{
				Tj190f01M1Form f01m1VO = (Tj190f01M1Form)m1List[i];

				// [Ｍ１選択フラグ(隠し)]が"1"の場合、以下の処理を実施する。
				if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
				{
					// [臨時棚卸TBL(H)]を削除する。を削除する。
					BoSystemLog.logOut("[臨時棚卸ロスTBL(H)]を削除する。 START");
					int Delcntkakuteilossh = Del_Rintanalossh(facadeContext, f01VO, f01m1VO, loginInfo);
					BoSystemLog.logOut("[臨時棚卸ロスTBL(H)]を削除する。 END");

					// [臨時棚卸TBL(B)]を削除する。を削除する。
					BoSystemLog.logOut("[臨時棚卸ロスTBL(B)]を削除する。 START");
					int Delcntkakuteilossb = Del_Rintanalossb(facadeContext, f01VO, f01m1VO, loginInfo);
					BoSystemLog.logOut("[臨時棚卸ロスTBL(B)]を削除する。 END");
				}
			}

		}
		#endregion

		#region [臨時棚卸TBL(H)]を削除する。
		/// <summary>
		/// [臨時棚卸TBL(H)]を削除する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <returns>更新件数</returns>
		private int Del_Rintanah(IFacadeContext facadeContext,
									Tj190f01Form f01Form,
									Tj190f01M1Form f01M1Form,
									LoginInfoVO loginInfo)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tj190p01Constant.SQL_ID_06, facadeContext.DBContext);

			// 店舗コード
			reader.BindValue(Tj190p01Constant.SQL_ID_06_BIND_TENPO_CD, BoSystemFormat.formatTenpoCd(f01M1Form.M1tenpo_cd));
			// 臨棚管理No
			reader.BindValue(Tj190p01Constant.SQL_ID_06_BIND_KANRI_NO, Convert.ToDecimal(BoSystemString.Nvl(f01M1Form.M1rintana_kanri_no, "0")));
			// 処理日付
			reader.BindValue(Tj190p01Constant.SQL_ID_06_BIND_SYORI_YMD, Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Tj190p01Constant.DIC_M1SYORI_YMD], "0")));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [臨時棚卸TBL(B)]を削除する。
		/// <summary>
		/// [臨時棚卸TBL(B)]を削除する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <returns>更新件数</returns>
		private int Del_Rintanab(IFacadeContext facadeContext,
									Tj190f01Form f01Form,
									Tj190f01M1Form f01M1Form,
									LoginInfoVO loginInfo)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tj190p01Constant.SQL_ID_07, facadeContext.DBContext);

			// 店舗コード
			reader.BindValue(Tj190p01Constant.SQL_ID_06_BIND_TENPO_CD, BoSystemFormat.formatTenpoCd(f01M1Form.M1tenpo_cd));
			// 臨棚管理No
			reader.BindValue(Tj190p01Constant.SQL_ID_06_BIND_KANRI_NO, Convert.ToDecimal(BoSystemString.Nvl(f01M1Form.M1rintana_kanri_no, "0")));
			// 処理日付
			reader.BindValue(Tj190p01Constant.SQL_ID_06_BIND_SYORI_YMD, Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Tj190p01Constant.DIC_M1SYORI_YMD], "0")));


			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [臨時棚卸一時TBL]を登録する。
		/// <summary>
		/// [臨時棚卸一時TBL]を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="IDataList">明細情報</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="LoginInfoVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private int InsRintanaTemp(IFacadeContext facadeContext,
									Tj190f01Form f01Form,
									IDataList m1List,
									LoginInfoVO loginInfo,
									SysDateVO sysDateVO)
		{


			int iRownum = 0;
			
			// Oracleコマンドの生成
			OracleCommand command = facadeContext.DBContext.Connection.CreateCommand() as OracleCommand;
			// トランザクションの設定
			command.Transaction = facadeContext.DBContext.Transaction as OracleTransaction;
			// SQLの実行タイプ
			command.CommandType = CommandType.Text;

			IList<Mdrt0011VO> insertBodyList = new List<Mdrt0011VO>();	// 更新データリスト
			// パラメータバインド処理
			IList<Dictionary<string, string>> insertBindList = new List<Dictionary<string, string>>();
			int counter = 0;    // 制御用カウンタ（一括処理単位のカウンタ）


			// 明細単位で以下の処理を実施する。
			for (int i = 0; i < m1List.Count; i++)
			{
				Tj190f01M1Form f01m1VO = (Tj190f01M1Form)m1List[i];

				counter++;
				iRownum++;

				// [Ｍ１選択フラグ(隠し)]が"1"の場合、以下の処理を実施する。
				if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
				{
					Dictionary<string, string> bindDic = new Dictionary<string, string>();

					// 店舗コード
					BoSystemDb.setInsertVal("TENPO_CD", iRownum.ToString("000"), BoSystemFormat.formatTenpoCd(f01m1VO.M1tenpo_cd), ref bindDic, ref command);
					// 臨棚管理No
					BoSystemDb.setInsertVal("RINTANA_KANRI_NO", iRownum.ToString("000"), Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1rintana_kanri_no, "0")), ref bindDic, ref command);
					// 処理日付
					BoSystemDb.setInsertVal("SYORI_YMD", iRownum.ToString("000"), Convert.ToDecimal(BoSystemString.Nvl((string)f01m1VO.Dictionary[Tj190p01Constant.DIC_M1SYORI_YMD], "0")), ref bindDic, ref command);
					// 部門コード
					BoSystemDb.setInsertVal("BUMON_CD", iRownum.ToString("000"), BoSystemFormat.formatBumonCd((string)f01m1VO.Dictionary[Tj190p01Constant.DIC_M1BUMON_CD]), ref bindDic, ref command);
					// 品種指定フラグ
					BoSystemDb.setInsertVal("HINSYU_SITEI_FLG", iRownum.ToString("000"), Convert.ToDecimal(BoSystemString.Nvl((string)f01m1VO.Dictionary[Tj190p01Constant.DIC_M1HINSYU_SITEI_FLG], "0")), ref bindDic, ref command);
					// 品種コード
					BoSystemDb.setInsertVal("HINSYU_CD", iRownum.ToString("000"), 
						Convert.ToDecimal(BoSystemString.Nvl((string)f01m1VO.Dictionary[Tj190p01Constant.DIC_M1HINSYU_CD],"99")), ref bindDic, ref command);
					// ブランド指定フラグ
					BoSystemDb.setInsertVal("BURANDO_SITEI_FLG", iRownum.ToString("000"), Convert.ToDecimal(BoSystemString.Nvl((string)f01m1VO.Dictionary[Tj190p01Constant.DIC_M1BURANDO_SITEI_FLG], "0")), ref bindDic, ref command);
					// ブランドコード1
					BoSystemDb.setInsertVal("BURANDO_CD1", iRownum.ToString("000"),
						BoSystemString.Nvl(BoSystemFormat.formatBrandCd((string)f01m1VO.Dictionary[Tj190p01Constant.DIC_M1BURANDO_CD])," "), ref bindDic, ref command);
					// ブランドコード2
					BoSystemDb.setInsertVal("BURANDO_CD2", iRownum.ToString("000"),
						BoSystemString.Nvl(BoSystemFormat.formatBrandCd((string)f01m1VO.Dictionary[Tj190p01Constant.DIC_M1BURANDO_CD1]), " "), ref bindDic, ref command);
					// ブランドコード3
					BoSystemDb.setInsertVal("BURANDO_CD3", iRownum.ToString("000"),
						BoSystemString.Nvl(BoSystemFormat.formatBrandCd((string)f01m1VO.Dictionary[Tj190p01Constant.DIC_M1BURANDO_CD2]), " "), ref bindDic, ref command);
					// ブランドコード4
					BoSystemDb.setInsertVal("BURANDO_CD4", iRownum.ToString("000"),
						BoSystemString.Nvl(BoSystemFormat.formatBrandCd((string)f01m1VO.Dictionary[Tj190p01Constant.DIC_M1BURANDO_CD3]), " "), ref bindDic, ref command);
					// ブランドコード5
					BoSystemDb.setInsertVal("BURANDO_CD5", iRownum.ToString("000"),
						BoSystemString.Nvl(BoSystemFormat.formatBrandCd((string)f01m1VO.Dictionary[Tj190p01Constant.DIC_M1BURANDO_CD4]), " "), ref bindDic, ref command);
					// ブランドコード6
					BoSystemDb.setInsertVal("BURANDO_CD6", iRownum.ToString("000"),
						BoSystemString.Nvl(BoSystemFormat.formatBrandCd((string)f01m1VO.Dictionary[Tj190p01Constant.DIC_M1BURANDO_CD5]), " "), ref bindDic, ref command);
					// ブランドコード7
					BoSystemDb.setInsertVal("BURANDO_CD7", iRownum.ToString("000"),
						BoSystemString.Nvl(BoSystemFormat.formatBrandCd((string)f01m1VO.Dictionary[Tj190p01Constant.DIC_M1BURANDO_CD6]), " "), ref bindDic, ref command);
					// ブランドコード8
					BoSystemDb.setInsertVal("BURANDO_CD8", iRownum.ToString("000"),
						BoSystemString.Nvl(BoSystemFormat.formatBrandCd((string)f01m1VO.Dictionary[Tj190p01Constant.DIC_M1BURANDO_CD7]), " "), ref bindDic, ref command);
					// 更新日
					BoSystemDb.setInsertVal("UPD_YMD", iRownum.ToString("000"), Convert.ToDecimal(sysDateVO.Sysdate), ref bindDic, ref command);
					// 更新時間
					BoSystemDb.setInsertVal("UPD_TM", iRownum.ToString("000"), Convert.ToDecimal(sysDateVO.Systime_mili), ref bindDic, ref command);
					// 更新担当者コード
					BoSystemDb.setInsertVal("UPD_TANCD", iRownum.ToString("000"), BoSystemFormat.formatTantoCd(loginInfo.TtsCd), ref bindDic, ref command);

					insertBindList.Add(bindDic);

					// 一括処理単位に達した場合は、マルチインサートを実行
					if (counter == 20)
					{
						// カウンタのリセット
						counter = 0;

						// マルチインサートの実行
						command.CommandText = GetSqlMultiInsT_RintanaTemp(insertBindList);
						//OutPutLog(command.CommandText);
						command.ExecuteNonQuery();

						// 配列、バインドパラメータのクリア
						insertBindList.Clear();
						command.Parameters.Clear();
					}
				}
			}// for

			// 未登録レコードの登録
			if (counter > 0)
			{
				// マルチインサートの実行
				command.CommandText = GetSqlMultiInsT_RintanaTemp(insertBindList);
				BoSystemLog.logOut("[臨時棚卸一時TBL]を登録する。 START");
				command.ExecuteNonQuery();
				BoSystemLog.logOut("[臨時棚卸一時TBL]を登録する。 END");
			}

			return iRownum;
		}
		#endregion

		#region [臨時棚卸一時TBL]へのマルチインサート文作成。
		/// <summary>
		/// [臨時棚卸一時TBL]へのマルチインサートを行うSQL文を取得する。
		/// </summary>
		/// <param name="insertBindList">バインドテキスト</param>
		private string GetSqlMultiInsT_RintanaTemp(IList<Dictionary<string, string>> insertBindList)
		{
			IList<string> insertSqlList = new List<string>();    // 単一のINSERT文を保持するリスト

			// バインドテキストのデータ分INSERT文を作成
			foreach (Dictionary<string, string> bindDic in insertBindList)
			{
				StringBuilder insertSql = new StringBuilder();    // 単一のINSERT文
				insertSql.Append("    INTO MDIT0120_TEMP VALUES ( ");
				insertSql.Append(bindDic["TENPO_CD"]).Append(" , ");
				insertSql.Append(bindDic["RINTANA_KANRI_NO"]).Append(" , ");
				insertSql.Append(bindDic["SYORI_YMD"]).Append(" , ");
				insertSql.Append(bindDic["BUMON_CD"]).Append(" , ");
				insertSql.Append(bindDic["HINSYU_SITEI_FLG"]).Append(" , ");
				insertSql.Append(bindDic["HINSYU_CD"]).Append(" , ");
				insertSql.Append(bindDic["BURANDO_SITEI_FLG"]).Append(" , ");
				insertSql.Append(bindDic["BURANDO_CD1"]).Append(" , ");
				insertSql.Append(bindDic["BURANDO_CD2"]).Append(" , ");
				insertSql.Append(bindDic["BURANDO_CD3"]).Append(" , ");
				insertSql.Append(bindDic["BURANDO_CD4"]).Append(" , ");
				insertSql.Append(bindDic["BURANDO_CD5"]).Append(" , ");
				insertSql.Append(bindDic["BURANDO_CD6"]).Append(" , ");
				insertSql.Append(bindDic["BURANDO_CD7"]).Append(" , ");
				insertSql.Append(bindDic["BURANDO_CD8"]).Append(" , ");
				insertSql.Append(bindDic["UPD_YMD"]).Append(" , ");
				insertSql.Append(bindDic["UPD_TM"]).Append(" , ");
				insertSql.Append(bindDic["UPD_TANCD"]);
				insertSql.Append(" ) ");

				insertSqlList.Add(insertSql.ToString());
			}

			// 単一INSERTをまとめて、マルチインサート文を作成
			StringBuilder sql = new StringBuilder();
			sql.AppendLine("INSERT ALL");
			foreach (string sqlpart in insertSqlList)
			{
				sql.AppendLine(sqlpart);
			}
			sql.AppendLine("SELECT 1 FROM DUAL");
			BoSystemLog.logOut("[臨時棚卸一時TBL]を登録する。 sql:" + sql.ToString());

			return sql.ToString();
		}
		#endregion

		#region ロス計算処理
		/// <summary>
		/// ロス計算処理
		/// </summary>
		/// <param name="IfacadeContext">facadeContext</param>
		/// <param name="Tj100f01Form">f01VO</param>
		/// <param name="String">tanaorosikijun_Ymd</param>
		/// <param name="String">packageId</param>
		/// <returns>結果</returns>
		public ArrayList LossCalc(IFacadeContext facadeContext, Tj190f01Form f01VO, IDataList m1List, LoginInfoVO loginInfo, SysDateVO sysDateVO)
		{

			// ストアド呼び出し
			// ■パラメータ設定
			ArrayList paramList = new ArrayList();

			// 処理呼び出し
			BoSystemLog.logOut("ロス計算処理を起動。 START");
			ArrayList rt = StoredProcedureCls.ExecStoredProcedure(facadeContext.DBContext, Tj190p01Constant.ORACLE_PACKAGE_01, paramList);
			BoSystemLog.logOut("ロス計算処理を起動。 END");

			#region ■例外処理
			if (rt != null && rt.Count > 0)
			{
				// エラーコード
				string errCd = rt[0].ToString();

				if (errCd.Equals(BoSystemConstant.STORED_NOT_ERR))
				{
					// 正常終了
				}
				else if (errCd.Equals(BoSystemConstant.STORED_NUMBERING_ERR))
				{
					// 採番不可の場合
					ErrMsgCls.AddErrMsg("E230", string.Empty, facadeContext);
					return rt;
				}
				else
				{
					// それ以外の場合
					throw new SystemException("ストアド［" + Tj190p01Constant.ORACLE_PACKAGE_01 + "］実行時にエラーが発生しました。エラーコード：" + errCd);
				}
			}
			else
			{
				// OUTパラメータが取得できない場合
				throw new SystemException("ストアド［" + Tj190p01Constant.ORACLE_PACKAGE_01 + "］実行時にエラーが発生しました。");
			}
			#endregion

			return rt;
		}

		#endregion

		#region [臨時棚卸ロスTBL(H)]を削除する。
		/// <summary>
		/// [臨時棚卸ロスTBL(H)]を削除する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <returns>更新件数</returns>
		private int Del_Rintanalossh(IFacadeContext facadeContext,
									Tj190f01Form f01Form,
									Tj190f01M1Form f01M1Form,
									LoginInfoVO loginInfo)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tj190p01Constant.SQL_ID_08, facadeContext.DBContext);

			// 店舗コード
			reader.BindValue(Tj190p01Constant.SQL_ID_06_BIND_TENPO_CD, BoSystemFormat.formatTenpoCd(f01M1Form.M1tenpo_cd));
			// ロス管理No
			reader.BindValue(Tj190p01Constant.SQL_ID_06_BIND_KANRI_NO, Convert.ToDecimal(BoSystemString.Nvl(f01M1Form.M1loss_kanri_no, "0")));
			// 処理日付
			reader.BindValue(Tj190p01Constant.SQL_ID_06_BIND_SYORI_YMD, Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Tj190p01Constant.DIC_M1SYORI_YMD], "0")));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [臨時棚卸ロスTBL(B)]を削除する。
		/// <summary>
		/// [臨時棚卸ロスTBL(B)]を削除する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <returns>更新件数</returns>
		private int Del_Rintanalossb(IFacadeContext facadeContext,
									Tj190f01Form f01Form,
									Tj190f01M1Form f01M1Form,
									LoginInfoVO loginInfo)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tj190p01Constant.SQL_ID_09, facadeContext.DBContext);

			// 店舗コード
			reader.BindValue(Tj190p01Constant.SQL_ID_06_BIND_TENPO_CD, BoSystemFormat.formatTenpoCd(f01M1Form.M1tenpo_cd));
			// ロス管理No
			reader.BindValue(Tj190p01Constant.SQL_ID_06_BIND_KANRI_NO, Convert.ToDecimal(BoSystemString.Nvl(f01M1Form.M1loss_kanri_no, "0")));
			// 処理日付
			reader.BindValue(Tj190p01Constant.SQL_ID_06_BIND_SYORI_YMD, Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Tj190p01Constant.DIC_M1SYORI_YMD], "0")));


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
