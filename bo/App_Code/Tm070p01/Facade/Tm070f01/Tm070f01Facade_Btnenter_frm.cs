using com.xebio.bo.Tm070p01.Constant;
using com.xebio.bo.Tm070p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
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
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace com.xebio.bo.Tm070p01.Facade
{
  /// <summary>
  /// Tm070f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tm070f01Facade : StandardBaseFacade
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

				#region 初期処理

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Tm070f01Form f01VO = (Tm070f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// システム日付
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				#endregion

				#region 業務チェック

				#region 更新対象対象チェック

				int inputflg = 0;
				for (int i = 0; i < m1List.Count; i++)
				{
					Tm070f01M1Form f01m1VO = (Tm070f01M1Form)m1List[i];

					//「新規作成」の場合、担当者コードが全て未入力でエラー
					if (f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_INSERT))
					{
						if (!string.IsNullOrEmpty(f01m1VO.M1tan_cd))
						{
							inputflg = 1;
							break;
						}
					}
					//「照会」の場合、所属店初期化が全て未チェックでエラー
					else if (f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_REF))
					{
						if (BoSystemString.Nvl(f01m1VO.M1shozokuten_shokika_check, "0").Equals(BoSystemConstant.CHECKBOX_ON))
						{
							inputflg = 1;
							break;
						}
					}
				}
				if (inputflg == 0)
				{
					// 確定対象がありません。
					ErrMsgCls.AddErrMsg("E140", String.Empty, facadeContext);
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region マスタチェック・関連チェック

				for (int i = 0; i < m1List.Count; i++)
				{
					Tm070f01M1Form f01m1VO = (Tm070f01M1Form)m1List[i];
					string upd_ymd = String.Empty;
					string upd_tm = String.Empty;
					bool errFlg = false;

					//「新規作成」の場合
					if (f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_INSERT))
					{
						// 担当者コードが入力された行
						if (!string.IsNullOrEmpty(f01m1VO.M1tan_cd))
						{
							// 2-1「Ｍ１担当者コード」担当者マスタを検索し、存在しない場合エラー
							f01m1VO.M1tan_nm = String.Empty;
							f01m1VO.M1moto_tenpo_cd = String.Empty;
							f01m1VO.M1moto_tenpo_nm = String.Empty;

							Hashtable tantoInfo = Get_TantoTenpo(facadeContext, f01m1VO.M1tan_cd);
							if (tantoInfo != null)
							{
								// 名称設定
								f01m1VO.M1tan_nm = tantoInfo["HANBAIIN_NM"].ToString();
								f01m1VO.M1moto_tenpo_cd = tantoInfo["HANBAIINTENPO_CD"].ToString();
								f01m1VO.M1moto_tenpo_nm = tantoInfo["TENPO_NM"].ToString();
								upd_ymd = tantoInfo["UPD_YMD"].ToString();
								upd_tm = tantoInfo["UPD_TM"].ToString();
							}
							else
							{
								ErrMsgCls.AddErrMsg("E416", string.Empty, facadeContext, new[] { "M1tan_cd" }, f01m1VO.M1rowno, i.ToString(), "M1", m1List.DispRow);
								errFlg = true;
							}

							// 2-2「Ｍ１担当者コード」所属店舗が変更店舗と同じ担当者コードが入力された場合エラー
							if (f01m1VO.M1moto_tenpo_cd.Equals(BoSystemFormat.formatTenpoCd(f01m1VO.M1henko_tenpo_cd)))
							{
								ErrMsgCls.AddErrMsg("E235", string.Empty, facadeContext, new[] { "M1tan_cd" }, f01m1VO.M1rowno, i.ToString(), "M1", m1List.DispRow);
								errFlg = true;
							}

							// 3-1「Ｍ１担当者コード」新規作成で明細内に同一の担当者コードが入力された場合エラー
							for (int j = 0; j < m1List.Count; j++)
							{
								Tm070f01M1Form f01m1VO2 = (Tm070f01M1Form)m1List[j];

								if (i != j && f01m1VO.M1tan_cd.Equals(f01m1VO2.M1tan_cd))
								{
									ErrMsgCls.AddErrMsg("E234", string.Empty, facadeContext, new[] { "M1tan_cd" }, f01m1VO.M1rowno, i.ToString(), "M1", m1List.DispRow);
									errFlg = true;
									break;
								}
							}
						}
					}

					// エラーが無い場合
					if (!errFlg)
					{
						#region 排他チェック

						//「新規作成」で担当者コードが入力された場合、
						// または「照会」で所属店初期化がチェックされた場合
						if ((f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_INSERT) && !string.IsNullOrEmpty(f01m1VO.M1tan_cd))
							|| (f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_REF) && BoSystemString.Nvl(f01m1VO.M1shozokuten_shokika_check, "0").Equals(BoSystemConstant.CHECKBOX_ON)))
						{
							StringBuilder sRepSql = new StringBuilder();
							sRepSql.Append(" AND HANBAIIN_CD = :BIND_HANBAIIN_CD");

							ArrayList bindList = new ArrayList();
							BindInfoVO bindVO = new BindInfoVO();

							// 担当者コード
							bindVO = new BindInfoVO();
							bindVO.BindId = "BIND_HANBAIIN_CD";
							bindVO.Value = f01m1VO.M1tan_cd;
							bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
							bindList.Add(bindVO);

							// 排他チェック
							V03003Check.CheckHaitaMaxVal(
									Convert.ToDecimal(f01m1VO.M1upd_ymd),
									Convert.ToDecimal(f01m1VO.M1upd_tm),
									facadeContext,
									"BOMT0030",
									sRepSql.ToString(),
									bindList,
									1,
									new[] { "M1tan_cd" },
									f01m1VO.M1rowno,
									i.ToString(),
									"M1",
									m1List.DispRow
							);

							//「新規作成」の場合
							if (f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_INSERT))
							{
								// 排他チェック後に再取得した更新日時をセットする。
								f01m1VO.M1upd_ymd = upd_ymd;
								f01m1VO.M1upd_tm = upd_tm;
							}
						}

						#endregion
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
					Tm070f01M1Form f01m1VO = (Tm070f01M1Form)m1List[i];

					// 所属店舗取得
					string ShozokuTenpoCd = Get_ShozokuTenpo(facadeContext, f01m1VO, sysDateVO);

					//「新規作成」で担当者コードが入力された場合、
					// または「照会」で所属店初期化がチェックされた場合
					if ((f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_INSERT) && !string.IsNullOrEmpty(f01m1VO.M1tan_cd))
						|| (f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_REF) && BoSystemString.Nvl(f01m1VO.M1shozokuten_shokika_check, "0").Equals(BoSystemConstant.CHECKBOX_ON)))
					{
						// [担当者マスタ]を更新する。
						BoSystemLog.logOut("[担当者マスタ]を更新 START");
						int Updcnttanto = Upd_Tanto(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO, ShozokuTenpoCd);
						BoSystemLog.logOut("[担当者マスタ]を更新 END");

						// [担当者所属店変更履歴TBL]を登録する。
						BoSystemLog.logOut("[担当者所属店変更履歴TBL]を登録 START");
						int Inscntrireki = Ins_Rireki(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO, ShozokuTenpoCd);
						BoSystemLog.logOut("[担当者所属店変更履歴TBL]を登録 END");
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

		#region [担当者マスタ]を更新する。
		/// <summary>
		/// [担当者マスタ]を更新する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01VO">画面のVO</param>
		/// <param name="f01m1VO">画面の明細VO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="ShozokuTenpoCd">所属店舗コード</param>
		/// <returns>更新件数</returns>
		private int Upd_Tanto(IFacadeContext facadeContext,
									Tm070f01Form f01VO,
									Tm070f01M1Form f01m1VO,
									LoginInfoVO loginInfo,
									SysDateVO sysDateVO,
									string ShozokuTenpoCd)

		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tm070p01Constant.SQL_ID_03, facadeContext.DBContext);

			// 店舗コード
			if (f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_INSERT))
			{
				reader.BindValue("BIND_HANBAIINTENPO_CD", BoSystemFormat.formatTenpoCd(f01m1VO.M1henko_tenpo_cd));
			}
			else
			{
				reader.BindValue("BIND_HANBAIINTENPO_CD", BoSystemFormat.formatTenpoCd(ShozokuTenpoCd));
			}
			// 更新日
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime);
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));

			// 担当者コード
			reader.BindValue("BIND_HANBAIIN_CD", BoSystemFormat.formatTantoCd(f01m1VO.M1tan_cd));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [担当者所属店変更履歴TBL]を登録する。
		/// <summary>
		/// [担当者所属店変更履歴TBL]を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01VO">画面のVO</param>
		/// <param name="f01m1VO">画面の明細VO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="ShozokuTenpoCd">所属店舗コード</param>
		/// <returns>更新件数</returns>
		private int Ins_Rireki(IFacadeContext facadeContext,
									Tm070f01Form f01VO,
									Tm070f01M1Form f01m1VO,
									LoginInfoVO loginInfo,
									SysDateVO sysDateVO,
									string ShozokuTenpoCd)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tm070p01Constant.SQL_ID_04, facadeContext.DBContext);

			// 担当者コード
			reader.BindValue("BIND_HANBAIIN_CD", BoSystemFormat.formatTantoCd(f01m1VO.M1tan_cd));
			// 変更日
			reader.BindValue("BIND_HENKO_YMD", sysDateVO.Sysdate);
			// 変更時間
			reader.BindValue("BIND_HENKO_TM", sysDateVO.Systime_mili);
			// 担当者店舗コード
			reader.BindValue("BIND_HANBAIINTENPO_CD", BoSystemFormat.formatTenpoCd(ShozokuTenpoCd));
			// 元店舗コード
			if (f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_INSERT))
			{
				reader.BindValue("BIND_MOTO_TENPO_CD", BoSystemFormat.formatTenpoCd(f01m1VO.M1moto_tenpo_cd));
			}
			else
			{
				reader.BindValue("BIND_MOTO_TENPO_CD", BoSystemFormat.formatTenpoCd(f01m1VO.M1henko_tenpo_cd));
			}
			// 変更店舗コード
			if (f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_INSERT))
			{
				reader.BindValue("BIND_HENKO_TENPO_CD", BoSystemFormat.formatTenpoCd(f01m1VO.M1henko_tenpo_cd));
			}
			else
			{
				reader.BindValue("BIND_HENKO_TENPO_CD", BoSystemFormat.formatTenpoCd(ShozokuTenpoCd));
			}
			// 登録日
			reader.BindValue("BIND_ADD_YMD", sysDateVO.Sysdate);
			// 登録時間
			reader.BindValue("BIND_ADD_TM", sysDateVO.Systime_mili);
			// 登録担当者コード
			reader.BindValue("BIND_ADDTAN_CD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 更新日
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 削除日
			reader.BindValue("BIND_SAKUJYO_YMD", sysDateVO.Sysdate);
			// 削除フラグ
			reader.BindValue("BIND_SAKUJYO_FLG", 1);

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region 所属店舗を取得する。
		/// <summary>
		/// 所属店舗を取得する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01m1VO">画面の明細VO</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>所属店舗</returns>
		private String Get_ShozokuTenpo(IFacadeContext facadeContext,
									Tm070f01M1Form f01m1VO,
									SysDateVO sysDateVO)
		{
			String rtnTenpo = "";

			FindSqlResultTable rtGet = FindSqlUtil.CreateFindSqlResultTable(Tm070p01Constant.SQL_ID_05, facadeContext.DBContext);

			// 担当者コードのバインド
			rtGet.BindValue("BIND_HANBAIIN_CD", BoSystemFormat.formatTantoCd(f01m1VO.M1tan_cd));
			// 変更日のバインド
			rtGet.BindValue("BIND_HENKO_YMD", sysDateVO.Sysdate);

			//検索結果を取得します
			rtGet.CreateDbCommand();
			IList<Hashtable> tableList = rtGet.Execute();

			if (tableList.Count > 0)
			{
				Hashtable resultTbl = tableList[0];
				// 最新履歴の販売員店舗コード
				rtnTenpo = resultTbl["HANBAIINTENPO_CD"].ToString();
			}
			else
			{
				// 履歴が1件も無い場合は元店舗コード（担当者マスタの販売員店舗コード）
				rtnTenpo = f01m1VO.M1moto_tenpo_cd;
			}
			return rtnTenpo;
		}
		#endregion

		#region 担当者・店舗情報を取得する。
		/// <summary>
		/// 担当者・店舗情報を取得する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01m1VO">画面の明細VO</param>
		/// <param name="tan_cd">担当者コード</param>
		/// <returns>担当者・店舗情報</returns>
		private Hashtable Get_TantoTenpo(IFacadeContext facadeContext, String tan_cd)
		{
			Hashtable resultTbl = null;

			FindSqlResultTable rtGet = FindSqlUtil.CreateFindSqlResultTable(Tm070p01Constant.SQL_ID_06, facadeContext.DBContext);

			// 担当者コードのバインド
			rtGet.BindValue("BIND_HANBAIIN_CD", BoSystemFormat.formatTantoCd(tan_cd));

			//検索結果を取得します
			rtGet.CreateDbCommand();
			IList<Hashtable> tableList = rtGet.Execute();

			if (tableList.Count > 0)
			{
				resultTbl = tableList[0];
			}

			return resultTbl;
		}
		#endregion

	}
}
