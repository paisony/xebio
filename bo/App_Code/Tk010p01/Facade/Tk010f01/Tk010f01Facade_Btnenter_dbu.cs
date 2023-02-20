using com.xebio.bo.Tk010p01.Constant;
using com.xebio.bo.Tk010p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
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

namespace com.xebio.bo.Tk010p01.Facade
{
  /// <summary>
  /// Tk010f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tk010f01Facade : StandardBaseFacade
	{
		#region データベース更新処理を行います。(ボタンID : Btnenter)
		/// <summary>
		/// データベース更新処理を行います。
		/// ボタンID(Btnenter)
		/// アクションID(DBU)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNENTER_DBU(IFacadeContext facadeContext)
		{
			//使用時にコメントアウトをはずす。
			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNENTER_DBU");
			
			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得して、トランザクションを開始する。
				BeginTransactionWithConnect(facadeContext);
			
				//以下に業務ロジックを記述する。
			
				//カード部を取得します。
				Tk010f01Form tk010f01Form = (Tk010f01Form)facadeContext.FormVO;
			
				//モデル層処理ロジックを記述してください。

				#region 初期化

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				IDataList m1List = tk010f01Form.GetList("M1");

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				#endregion

				#region 警告表示
				// 警告メッセージの応答結果を取得
				string waningFlg = BoSystemString.Nvl(facadeContext.GetUserObject(BoSystemConstant.WARNING_FCD_KEY) as String, "0");

				if (!waningFlg.Equals("1"))
				{
					// 警告メッセージを表示する
					InfoMsgCls.AddWarnMsg("I102", String.Empty, facadeContext);
					// 警告メッセージ表示
					if (InfoMsgCls.HasWarn(facadeContext))
					{
						return;
					}
				}
				#endregion

				#region 業務チェック

				#region 行数チェック

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
						Tk010f01M1Form f01m1VO = (Tk010f01M1Form)m1List[i];
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

				#region 排他チェック

				for (int i = 0; i < m1List.Count; i++)
				{
					Tk010f01M1Form f01m1VO = (Tk010f01M1Form)m1List[i];

					// 選択行
					if (BoSystemConstant.CHECKBOX_ON.Equals(f01m1VO.M1selectorcheckbox))
					{
						StringBuilder sRepSql = new StringBuilder();
						String tableId = string.Empty;
						ArrayList bindList = new ArrayList();
						BindInfoVO bindVO = new BindInfoVO();

						sRepSql.Append(" AND TENPO_CD = :BIND_TENPO_CD");						// 店舗コード
						sRepSql.Append(" AND APPLY_YMD = :BIND_APPLY_YMD");						// 申請日
						sRepSql.Append(" AND KESSAI_FLG = 0");									// 決裁状態 0固定
						sRepSql.Append(" AND SHINSEI_FLG = 1");									// 申請状態 1固定
						sRepSql.Append(" AND SAISHINSEI_FLG = :BIND_SAISHINSEI_FLG");			// 再申請フラグ

						// 店舗コード
						bindList.Add(new BindInfoVO("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(f01m1VO.Dictionary[Tk010p01Constant.DIC_M1TENPO_CD].ToString()), BoSystemSql.BINDTYPE_STRING));
						// 申請日
						bindList.Add(new BindInfoVO("BIND_APPLY_YMD", BoSystemFormat.formatDate(BoSystemString.Nvl(f01m1VO.M1apply_ymd,"0")), BoSystemSql.BINDTYPE_NUMBER));
						// 再申請フラグ
						bindList.Add(new BindInfoVO("BIND_SAISHINSEI_FLG", f01m1VO.Dictionary[Tk010p01Constant.DIC_M1SAISHINSEI_FLG].ToString(), BoSystemSql.BINDTYPE_NUMBER));

						// 評価損種別区分 設定されている場合のみ参照する
						if (!BoSystemConstant.DROPDOWNLIST_MISENTAKU.Equals(tk010f01Form.Dictionary[SearchConditionSaveCls.GetKey(() => tk010f01Form.Hyokasonsyubetsu_kb)].ToString()))
						{
							sRepSql.Append(" AND HYOKASONSYUBETSU_KB = :BIND_HYOKASONSYUBETSU_KB");			// 再申請フラグ
							bindList.Add(new BindInfoVO("BIND_HYOKASONSYUBETSU_KB", tk010f01Form.Dictionary[SearchConditionSaveCls.GetKey(() => tk010f01Form.Hyokasonsyubetsu_kb)].ToString(), BoSystemSql.BINDTYPE_NUMBER));
						}

						// 排他チェック
						V03003Check.CheckHaitaMaxVal(
								Convert.ToDecimal((string)f01m1VO.Dictionary[Tk010p01Constant.DIC_M1UPD_YMD]),
								Convert.ToDecimal((string)f01m1VO.Dictionary[Tk010p01Constant.DIC_M1UPD_TM]),
								facadeContext,
								"MDIT0060",
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
					Tk010f01M1Form f01m1VO = (Tk010f01M1Form)m1List[i];

					// 選択行
					if (BoSystemConstant.CHECKBOX_ON.Equals(f01m1VO.M1selectorcheckbox))
					{
						// [評価損確定TBL]を登録する。
						BoSystemLog.logOut("[評価損確定TBL]を登録する。 START");
						int ins_Cnt = ins_hyokaKakutei(facadeContext, tk010f01Form, f01m1VO, logininfo, sysDateVO);
						BoSystemLog.logOut("[評価損確定TBL]を登録する。 END");

						// [評価損申請TBL]を更新する。
						BoSystemLog.logOut("[評価損申請TBL]を更新する。 START");
						int upds_Cnt = upd_hyokaSinsei(facadeContext, tk010f01Form, f01m1VO, logininfo, sysDateVO);
						BoSystemLog.logOut("[評価損申請TBL]を更新する。 END");
					}
				}

				#endregion

				//トランザクションをコミットする。
				CommitTransaction(facadeContext);
				//RollbackTransaction(facadeContext);

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
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNENTER_DBU");
			
	
		}
		#endregion

		#region ユーザー定義関数

		#region 更新処理 評価損確定TBLを登録

		/// <summary>
		/// 更新処理 評価損確定TBLを登録
		/// </summary>
		/// <param name="facadeContext">facadeContext</param>
		/// <param name="Tk010f01Form">f01VO</param>
		/// <param name="IDataList">Tk010f01M1Form</param>
		/// <param name="LoginInfoVO">loginInfo</param>
		/// <param name="SysDateVO">sysDateVO</param>
		/// <returns>更新件数</returns>
		private int ins_hyokaKakutei(IFacadeContext facadeContext, Tk010f01Form f01VO, Tk010f01M1Form f01m1VO, LoginInfoVO loginInfo, SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tk010p01Constant.SQL_ID_09, facadeContext.DBContext);

			// 申請日
			reader.BindValue(Tk010p01Constant.BIND1_APPLY_YMD, Convert.ToDecimal(BoSystemFormat.formatDate(BoSystemString.Nvl(f01m1VO.M1apply_ymd, "0"))));
			// 登録日
			reader.BindValue(Tk010p01Constant.BIND_ADD_YMD, Convert.ToDecimal(sysDateVO.Sysdate));
			// 登録時間
			reader.BindValue(Tk010p01Constant.BIND_ADD_TM, Convert.ToDecimal(sysDateVO.Systime_mili));
			// 登録担当者コード
			reader.BindValue(Tk010p01Constant.BIND_ADD_TANCD, BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 更新日
			reader.BindValue(Tk010p01Constant.BIND_UPD_YMD, Convert.ToDecimal(sysDateVO.Sysdate));
			// 更新時間
			reader.BindValue(Tk010p01Constant.BIND_UPD_TM, Convert.ToDecimal(sysDateVO.Systime_mili));
			// 更新担当者コード
			reader.BindValue(Tk010p01Constant.BIND_UPD_TANCD, BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 削除日
			reader.BindValue(Tk010p01Constant.BIND_DEL_YMD, Convert.ToDecimal(sysDateVO.Sysdate));

			// 条件
			// 店舗コード
			reader.BindValue(Tk010p01Constant.BIND_TENPO_CD, BoSystemFormat.formatTenpoCd(f01m1VO.Dictionary[Tk010p01Constant.DIC_M1TENPO_CD].ToString()));
			// 処理日付
			reader.BindValue(Tk010p01Constant.BIND_SYORI_YMD, BoSystemString.LeftB(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Syori_ym)].ToString(), 6) + "%");
			// 申請日
			reader.BindValue(Tk010p01Constant.BIND2_APPLY_YMD, Convert.ToDecimal(BoSystemFormat.formatDate(BoSystemString.Nvl(f01m1VO.M1apply_ymd, "0"))));
			// 再申請フラグ
			reader.BindValue(Tk010p01Constant.BIND_SAISHINSEI_FLG, Convert.ToDecimal(f01m1VO.Dictionary[Tk010p01Constant.DIC_M1SAISHINSEI_FLG].ToString()));
			// 評価損種別区分1
			reader.BindValue(Tk010p01Constant.BIND1_HYOKASONSYUBETSU, Convert.ToDecimal(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Hyokasonsyubetsu_kb)].ToString()));
			// 評価損種別区分2
			reader.BindValue(Tk010p01Constant.BIND2_HYOKASONSYUBETSU, Convert.ToDecimal(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Hyokasonsyubetsu_kb)].ToString()));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}


		#endregion

		#region 更新処理 評価損確申請TBLを更新

		/// <summary>
		/// 更新処理 評価損確申請TBLを更新
		/// </summary>
		/// <param name="facadeContext">facadeContext</param>
		/// <param name="Tk010f01Form">f01VO</param>
		/// <param name="IDataList">Tk010f01M1Form</param>
		/// <param name="LoginInfoVO">loginInfo</param>
		/// <param name="SysDateVO">sysDateVO</param>
		/// <returns>更新件数</returns>
		private int upd_hyokaSinsei(IFacadeContext facadeContext, Tk010f01Form f01VO, Tk010f01M1Form f01m1VO, LoginInfoVO loginInfo, SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tk010p01Constant.SQL_ID_10, facadeContext.DBContext);

			// 更新日
			reader.BindValue(Tk010p01Constant.BIND_UPD_YMD, Convert.ToDecimal(sysDateVO.Sysdate));
			// 更新時間
			reader.BindValue(Tk010p01Constant.BIND_UPD_TM, Convert.ToDecimal(sysDateVO.Systime_mili));

			// 条件
			// 店舗コード
			reader.BindValue(Tk010p01Constant.BIND_TENPO_CD, BoSystemFormat.formatTenpoCd(f01m1VO.Dictionary[Tk010p01Constant.DIC_M1TENPO_CD].ToString()));
			// 処理日付
			reader.BindValue(Tk010p01Constant.BIND_SYORI_YMD, BoSystemString.LeftB(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Syori_ym)].ToString(), 6) + "%");
			// 申請日
			reader.BindValue(Tk010p01Constant.BIND_APPLY_YMD, Convert.ToDecimal(BoSystemFormat.formatDate(BoSystemString.Nvl(f01m1VO.M1apply_ymd,"0"))));
			// 評価損種別区分1
			reader.BindValue(Tk010p01Constant.BIND1_HYOKASONSYUBETSU, Convert.ToDecimal(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Hyokasonsyubetsu_kb)].ToString()));
			// 評価損種別区分2
			reader.BindValue(Tk010p01Constant.BIND2_HYOKASONSYUBETSU, Convert.ToDecimal(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Hyokasonsyubetsu_kb)].ToString()));
			// 再申請フラグ
			reader.BindValue(Tk010p01Constant.BIND_SAISHINSEI_FLG, Convert.ToDecimal(f01m1VO.Dictionary[Tk010p01Constant.DIC_M1SAISHINSEI_FLG].ToString()));
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
