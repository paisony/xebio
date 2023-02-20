using com.xebio.bo.Tb030p01.Constant;
using com.xebio.bo.Tb030p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C01000.C01020;
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
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace com.xebio.bo.Tb030p01.Facade
{
  /// <summary>
  /// Tb030f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tb030f01Facade : StandardBaseFacade
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
				Tb030f01Form f01VO = (Tb030f01Form) facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				#endregion

				#region 業務チェック

				#region 行数チェック

				if (m1List == null || m1List.Count <= 0)
				{
					// 確定対象がありません。
					ErrMsgCls.AddErrMsg("E140", String.Empty, facadeContext);
				}
				else
				{
					int inputflg = 0;
					for (int i = 0; i < m1List.Count; i++)
					{
						Tb030f01M1Form f01m1VO = (Tb030f01M1Form)m1List[i];

						// モードが「仕入確定」で、[Ｍ１確定フラグ(隠し)]が"0"、かつ[Ｍ１選択フラグ(隠し)]が"1"の場合
						if (BoSystemConstant.MODE_SIIREKAKUTEI.Equals(f01VO.Modeno)
							&& f01m1VO.M1entersyoriflg.Equals(BoSystemConstant.CHECKBOX_OFF)
							&& f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
						{
							inputflg = 1;
							break;
						}

						// モードが「取消」で、[Ｍ１選択フラグ(隠し)]が"1"の場合
						if (BoSystemConstant.MODE_DEL.Equals(f01VO.Modeno)
							&& f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
						{
							inputflg = 1;
							break;
						}

						// モードが「照会」で、[Ｍ１確定フラグ(隠し)]が"1"の場合
						if (BoSystemConstant.MODE_REF.Equals(f01VO.Modeno)
							&& f01m1VO.M1entersyoriflg.Equals(BoSystemConstant.CHECKBOX_ON))
						{
							inputflg = 1;
							break;
						}

					}

					if (inputflg == 0)
					{
						// 確定対象がありません。
						ErrMsgCls.AddErrMsg("E140", String.Empty, facadeContext);
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

				// 仕入共通部品更新用配列
				TbCommonConfirmReg commonReg = new TbCommonConfirmReg(facadeContext, logininfo);

				StringBuilder sRepSql = new StringBuilder();

				// モードが「照会」、「取消」の場合
				if (!BoSystemConstant.MODE_SIIREKAKUTEI.Equals(f01VO.Modeno))
				{

					sRepSql.Append(" AND KAKUTEI_SB		= :BIND_KAKUTEI_SB");
					sRepSql.Append(" AND SIIRESAKI_CD	= :BIND_SIIRESAKI_CD");
					sRepSql.Append(" AND DENPYO_BANGO	= :BIND_DENPYO_BANGO");
					sRepSql.Append(" AND SITEINOHIN_YMD	= :BIND_SITEINOHIN_YMD");
					sRepSql.Append(" AND TENPO_CD		= :BIND_TENPO_CD");
				}


				for (int i = 0; i < m1List.Count; i++)
				{
					Tb030f01M1Form f01m1VO = (Tb030f01M1Form)m1List[i];

					#region 仕入確定データ取得処理

					// モードが「仕入確定」で、[Ｍ１確定フラグ(隠し)]が"0"、かつ[Ｍ１選択フラグ(隠し)]が"1"の場合
					if (BoSystemConstant.MODE_SIIREKAKUTEI.Equals(f01VO.Modeno)
						&& f01m1VO.M1entersyoriflg.Equals(BoSystemConstant.CHECKBOX_OFF)
						&& f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
					{
						TbCommonRegVO regVO = new TbCommonRegVO();

						// 行番号
						regVO.Gyo_no = i.ToString();

						// 明細番号
						regVO.Rowno = f01m1VO.M1rowno;

						// 仕入先コード
						regVO.Siiresaki_cd = f01m1VO.M1siiresaki_cd;

						// 伝票番号
						regVO.Denpyo_bango = (string)f01m1VO.Dictionary[Tb030p01Constant.DIC_M1DENPYO_BANGO];

						// 入荷予定日
						regVO.Nyukayotei_ymd = BoSystemFormat.formatDate(f01m1VO.M1nyukayotei_ymd);

						// 店舗コード
						regVO.Tenpo_cd = BoSystemFormat.formatTenpoCd((string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_cd)]);

						// 納品書日付
						regVO.Nohinsyo_ymd = (string)f01m1VO.Dictionary[Tb030p01Constant.DIC_M1NOHINSYO_YMD];

						// 部門コード
						regVO.Bumon_cd = f01m1VO.M1bumon_cd;

						// サブ仕入先コード
						regVO.Subsiiresaki_cd = (string)f01m1VO.Dictionary[Tb030p01Constant.DIC_M1SUBSIIRESAKI_CD];

						// 仕入予定合計数量
						regVO.Siireyoteigokei_su = (string)f01m1VO.Dictionary[Tb030p01Constant.DIC_M1SIIREYOTEIGOKEI_SU];

						// 仕入予定合計金額
						regVO.Siireyoteigokei_kin = (string)f01m1VO.Dictionary[Tb030p01Constant.DIC_M1SIIREYOTEIGOKEI_KIN];

						// 更新日
						regVO.Upd_ymd = (string)f01m1VO.Dictionary[Tb030p01Constant.DIC_M1UPD_YMD];

						// 更新時間
						regVO.Upd_tm = (string)f01m1VO.Dictionary[Tb030p01Constant.DIC_M1UPD_TM];

						commonReg.AddList(regVO);

					}

					#endregion

					#region 「取消」「照会」排他処理

					// モードが「取消」で、[Ｍ１選択フラグ(隠し)]が"1"の場合
					// モードが「照会」で、[Ｍ１確定フラグ(隠し)]が"1"の場合
					if (
						(BoSystemConstant.MODE_DEL.Equals(f01VO.Modeno)
							&& f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
						||
						(BoSystemConstant.MODE_REF.Equals(f01VO.Modeno)
							&& f01m1VO.M1entersyoriflg.Equals(BoSystemConstant.CHECKBOX_ON)))
						{
						ArrayList bindList = new ArrayList();
						BindInfoVO bindVO = new BindInfoVO();

						// 確定種別
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_KAKUTEI_SB";
						bindVO.Value = (string)f01m1VO.Dictionary[Tb030p01Constant.DIC_M1KAKUTEI_SB];
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						// 仕入先コード
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_SIIRESAKI_CD";
						bindVO.Value = BoSystemFormat.formatSiiresakiCd(f01m1VO.M1siiresaki_cd);
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						// 伝票番号
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_DENPYO_BANGO";
						bindVO.Value = BoSystemFormat.formatDenpyoNo((string)f01m1VO.Dictionary[Tb030p01Constant.DIC_M1DENPYO_BANGO]);
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

						// 排他チェック
						V03003Check.CheckHaitaMaxVal(
								Convert.ToDecimal((string)f01m1VO.Dictionary[Tb030p01Constant.DIC_M1UPD_YMD]),
								Convert.ToDecimal((string)f01m1VO.Dictionary[Tb030p01Constant.DIC_M1UPD_TM]),
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

					#endregion
				}

				#region 「仕入確定」排他処理

				if (BoSystemConstant.MODE_SIIREKAKUTEI.Equals(f01VO.Modeno))
				{
					commonReg.isCheckHaita();
				}

				#endregion

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#endregion

				#region 更新処理

				if (BoSystemConstant.MODE_SIIREKAKUTEI.Equals(f01VO.Modeno))
				{
					#region 仕入確定

					commonReg.updData();

					#endregion
				}
				else
				{
					for (int i = 0; i < m1List.Count; i++)
					{
						Tb030f01M1Form f01m1VO = (Tb030f01M1Form)m1List[i];

						#region 取消
						// モードが「取消」で、[Ｍ１選択フラグ(隠し)]が"1"の場合
						if (BoSystemConstant.MODE_DEL.Equals(f01VO.Modeno)
							&& f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
						{
							// [SCM予定TBL(H)]のFOR UPDATE
							BoSystemLog.logOut("[SCM予定TBL(H)]のFOR UPDATE START");
							int forUpdRtn = ForUpd_SCMYoteih(facadeContext, f01VO, f01m1VO);
							BoSystemLog.logOut("[SCM予定TBL(H)]のFOR UPDATE END  ");

							// [仕入入荷予定TBL(B)]の更新
							BoSystemLog.logOut("[仕入入荷予定TBL(B)]の更新 START");
							int Updcntyoteib = Upd_ShiireYoteib(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO);
							BoSystemLog.logOut("[仕入入荷予定TBL(B)]の更新 END  ");

							// [仕入入荷予定TBL(H)]の更新
							BoSystemLog.logOut("[仕入入荷予定TBL(H)]の更新 START");
							int Updcntyoteih = Upd_ShiireYoteih(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO);
							BoSystemLog.logOut("[仕入入荷予定TBL(H)]の更新 END  ");

							// [仕入入荷確定TBL(H)]を検索し、[仕入入荷履歴TBL(H)]を登録
							BoSystemLog.logOut("[仕入入荷確定TBL(H)]を検索し、[仕入入荷履歴TBL(H)]を登録 START");
							int Inscntrirekih = Ins_ShiireRirekih(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO);
							BoSystemLog.logOut("[仕入入荷確定TBL(H)]を検索し、[仕入入荷履歴TBL(H)]を登録 END  ");

							// [仕入入荷確定TBL(B)]を検索し、[仕入入荷履歴TBL(B)]を登録
							BoSystemLog.logOut("[仕入入荷確定TBL(B)]を検索し、[仕入入荷履歴TBL(B)]を登録 START");
							int Inscntrirekib = Ins_ShiireRirekib(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO);
							BoSystemLog.logOut("[仕入入荷確定TBL(B)]を検索し、[仕入入荷履歴TBL(B)]を登録 END  ");

							// [仕入入荷確定TBL(H)]の削除
							BoSystemLog.logOut("[仕入入荷確定TBL(H)]の削除 START");
							int Delcntkakuh = Del_ShiireKakuteih(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO);
							BoSystemLog.logOut("[仕入入荷確定TBL(H)]の削除 END  ");

							// [仕入入荷確定TBL(B)]の削除
							BoSystemLog.logOut("[仕入入荷確定TBL(H)]の削除 START");
							int Delcntkakub = Del_ShiireKakuteib(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO);
							BoSystemLog.logOut("[仕入入荷確定TBL(H)]の削除 END  ");

							// SCM検品督促リスト用データの削除
							BoSystemLog.logOut("SCM検品督促リスト用データの削除 START");
							int Delcntkenb = Del_SCMKenpinTokusokuList(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO);
							BoSystemLog.logOut("SCM検品督促リスト用データの削除 END  ");
						}
						#endregion

						#region 照会
						// モードが「照会」で、[Ｍ１確定フラグ(隠し)]が"1"の場合
						if (BoSystemConstant.MODE_REF.Equals(f01VO.Modeno)
							&& f01m1VO.M1entersyoriflg.Equals(BoSystemConstant.CHECKBOX_ON))
						{
							// [仕入入荷確定TBL(H)]を更新する。
							BoSystemLog.logOut("[仕入入荷確定TBL(H)]を更新 START");
							int Delcntyoteih = Upd_ShiireNyukaKakuteiChkh(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO);
							BoSystemLog.logOut("[仕入入荷確定TBL(H)]を更新 END");

						}
						#endregion
					}
				}

				#endregion

				//	//トランザクションをコミットする。
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

		#region [SCM予定TBL(H)]のFOR UPDATE
		/// <summary>
		/// [SCM予定TBL(H)]のFOR UPDATEを行います。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <returns>件数</returns>
		private int ForUpd_SCMYoteih(IFacadeContext facadeContext,
									Tb030f01Form f01Form,
									Tb030f01M1Form f01M1Form)
		{

			#region SCM予定TBL(B)から値の取得

			// XMLからSQLを取得する。
			FindSqlResultTable rtSearch = FindSqlUtil.CreateFindSqlResultTable(Tb030p01Constant.SQL_ID_06, facadeContext.DBContext);

			// 仕入先コード
			rtSearch.BindValue("BIND_SIIRESAKI_CD", BoSystemFormat.formatSiiresakiCd(f01M1Form.M1siiresaki_cd));

			// 伝票番号
			rtSearch.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal(BoSystemFormat.formatDenpyoNo((string)f01M1Form.Dictionary[Tb030p01Constant.DIC_M1DENPYO_BANGO])));

			// 指定納品日
			rtSearch.BindValue("BIND_SITEINOHIN_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01M1Form.M1nyukayotei_ymd)));

			// 店舗コード
			rtSearch.BindValue("BIND_TENCD", BoSystemFormat.formatTenpoCd((string)f01Form.Dictionary[SearchConditionSaveCls.GetKey(() => f01Form.Head_tenpo_cd)]));

			//検索結果を取得します
			rtSearch.CreateDbCommand();
			IList<Hashtable> tableList = rtSearch.Execute();

			#endregion

			#region SCM予定TBL(H)のFOR UPDATE

			int iCnt = 0;

			// 取得したデータを元にFORUPDATEを行う
			foreach (Hashtable rec in tableList)
			{

				// XMLからSQLを取得する。
				FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tb030p01Constant.SQL_ID_07, facadeContext.DBContext);

				// 検索条件
				// 店舗コード
				reader.BindValue("BIND_TENCD", BoSystemFormat.formatTenpoCd(rec["TENPO_CD"].ToString()));
				// SCMコード
				reader.BindValue("BIND_SCM_CD", BoSystemFormat.formatScmCd(rec["SCM_CD"].ToString()));
				// 納入着予定日
				reader.BindValue("BIND_TYAKUYOTEI_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(rec["NONYUTYAKUYOTEI_YMD"].ToString())));

				//検索結果を取得します
				reader.CreateDbCommand();
				IList<Hashtable> scmList = reader.Execute();

				iCnt++;

			}

			return iCnt;

			#endregion
		}

		#endregion

		#region [仕入入荷予定TBL(B)]の更新
		/// <summary>
		/// [仕入入荷予定TBL(B)]の更新を行います。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="dDenno">伝票番号</param>
		/// <returns>更新件数</returns>
		private int Upd_ShiireYoteib(IFacadeContext facadeContext, 
									Tb030f01Form f01Form, 
									Tb030f01M1Form f01M1Form, 
									LoginInfoVO loginInfo, 
									SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tb030p01Constant.SQL_ID_08, facadeContext.DBContext);

			// 更新内容
			// 確定フラグ
			reader.BindValue("BIND_KAKUTEI_FLG", 0);
			// 更新日
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 削除日
			reader.BindValue("BIND_SAKUJYO_YMD", sysDateVO.Sysdate);
			// 削除フラグ
			reader.BindValue("BIND_SAKUJYO_FLG", 0);

			// 更新条件
			// 仕入先コード
			reader.BindValue("BIND_SIIRESAKI_CD", BoSystemFormat.formatSiiresakiCd(f01M1Form.M1siiresaki_cd));
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal(BoSystemFormat.formatDenpyoNo((string)f01M1Form.Dictionary[Tb030p01Constant.DIC_M1DENPYO_BANGO])));
			// 指定納品日
			reader.BindValue("BIND_SITEINOHIN_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01M1Form.M1nyukayotei_ymd)));
			// 店舗コード
			reader.BindValue("BIND_TENCD", BoSystemFormat.formatTenpoCd((string)f01Form.Dictionary[SearchConditionSaveCls.GetKey(() => f01Form.Head_tenpo_cd)]));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [仕入入荷予定TBL(H)]の更新
		/// <summary>
		/// [仕入入荷予定TBL(H)]の更新を行います。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="dDenno">伝票番号</param>
		/// <returns>更新件数</returns>
		private int Upd_ShiireYoteih(IFacadeContext facadeContext,
									Tb030f01Form f01Form,
									Tb030f01M1Form f01M1Form,
									LoginInfoVO loginInfo,
									SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tb030p01Constant.SQL_ID_09, facadeContext.DBContext);

			// 更新内容
			// 確定フラグ
			reader.BindValue("BIND_KAKUTEI_FLG", 0);
			// 伝票状態
			reader.BindValue("BIND_DENPYO_JYOTAI", 0);
			// 更新日
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 削除日
			reader.BindValue("BIND_SAKUJYO_YMD", sysDateVO.Sysdate);
			// 削除フラグ
			reader.BindValue("BIND_SAKUJYO_FLG", 0);

			// 更新条件
			// 仕入先コード
			reader.BindValue("BIND_SIIRESAKI_CD", BoSystemFormat.formatSiiresakiCd(f01M1Form.M1siiresaki_cd));
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal(BoSystemFormat.formatDenpyoNo((string)f01M1Form.Dictionary[Tb030p01Constant.DIC_M1DENPYO_BANGO])));
			// 指定納品日
			reader.BindValue("BIND_SITEINOHIN_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01M1Form.M1nyukayotei_ymd)));
			// 店舗コード
			reader.BindValue("BIND_TENCD", BoSystemFormat.formatTenpoCd((string)f01Form.Dictionary[SearchConditionSaveCls.GetKey(() => f01Form.Head_tenpo_cd)]));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [仕入入荷確定TBL(H)]を検索し、[仕入入荷履歴TBL(H)]を登録
		/// <summary>
		/// [仕入入荷確定TBL(H)]を検索し、[仕入入荷履歴TBL(H)]を登録を行います。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="dDenno">伝票番号</param>
		/// <returns>更新件数</returns>
		private int Ins_ShiireRirekih(IFacadeContext facadeContext,
									Tb030f01Form f01Form,
									Tb030f01M1Form f01M1Form,
									LoginInfoVO loginInfo,
									SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tb030p01Constant.SQL_ID_10, facadeContext.DBContext);

			// 仕入実績合計数
			StringBuilder sRepSql = new StringBuilder();
			sRepSql.Append(" ,SIIREJISSEKIGOKEI_SU * -1");

			BoSystemSql.AddSql(reader, TbCommonRegConstant.SQL_ID_07_REP_JISSEKIGOKEI_SU, sRepSql.ToString(), new ArrayList());

			// 仕入実績合計金額
			sRepSql = new StringBuilder();
			sRepSql.Append(" ,SIIREJISSEKIGOKEI_KIN * -1");

			BoSystemSql.AddSql(reader, TbCommonRegConstant.SQL_ID_07_REP_JISSEKIGOKEI_KIN, sRepSql.ToString(), new ArrayList());

			// 税込伝票金
			sRepSql = new StringBuilder();
			sRepSql.Append(" ,ZEIKOMI_DENPYO_KIN * -1");

			BoSystemSql.AddSql(reader, TbCommonRegConstant.SQL_ID_07_REP_ZEIKOMI_DENPYO_KIN, sRepSql.ToString(), new ArrayList());

			// 登録内容
			// 赤黒区分
			reader.BindValue("BIND_AKAKURO_KBN", 1);
			// 履歴処理日
			reader.BindValue("BIND_SYORI_YMD", sysDateVO.Sysdate);
			// 履歴処理時間
			reader.BindValue("BIND_SYORI_TM", sysDateVO.Systime_mili);
			// 処理種別
			reader.BindValue("BIND_SYORI_SB", 2);

			// 登録条件
			// 確定種別
			reader.BindValue("BIND_KAKUTEI_SB", Convert.ToDecimal(f01M1Form.Dictionary[Tb030p01Constant.DIC_M1KAKUTEI_SB]));
			// 仕入先コード
			reader.BindValue("BIND_SIIRESAKI_CD", BoSystemFormat.formatSiiresakiCd(f01M1Form.M1siiresaki_cd));
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal(BoSystemFormat.formatDenpyoNo((string)f01M1Form.Dictionary[Tb030p01Constant.DIC_M1DENPYO_BANGO])));
			// 指定納品日
			reader.BindValue("BIND_SITEINOHIN_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01M1Form.M1nyukayotei_ymd)));
			// 店舗コード
			reader.BindValue("BIND_TENCD", BoSystemFormat.formatTenpoCd((string)f01Form.Dictionary[SearchConditionSaveCls.GetKey(() => f01Form.Head_tenpo_cd)]));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [仕入入荷確定TBL(B)]を検索し、[仕入入荷履歴TBL(B)]を登録
		/// <summary>
		/// [仕入入荷確定TBL(B)]を検索し、[仕入入荷履歴TBL(B)]を登録を行います。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="dDenno">伝票番号</param>
		/// <returns>更新件数</returns>
		private int Ins_ShiireRirekib(IFacadeContext facadeContext,
									Tb030f01Form f01Form,
									Tb030f01M1Form f01M1Form,
									LoginInfoVO loginInfo,
									SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tb030p01Constant.SQL_ID_11, facadeContext.DBContext);

			// 実績数
			StringBuilder sRepSql = new StringBuilder();
			sRepSql.Append(" ,JISSEKI_SU * -1");

			BoSystemSql.AddSql(reader, TbCommonRegConstant.SQL_ID_06_REP_JISSEKI_SU, sRepSql.ToString(), new ArrayList());


			// 登録内容
			// 赤黒区分
			reader.BindValue("BIND_AKAKURO_KBN", 1);

			// 登録条件
			// 確定種別
			reader.BindValue("BIND_KAKUTEI_SB", Convert.ToDecimal(f01M1Form.Dictionary[Tb030p01Constant.DIC_M1KAKUTEI_SB]));
			// 仕入先コード
			reader.BindValue("BIND_SIIRESAKI_CD", BoSystemFormat.formatSiiresakiCd(f01M1Form.M1siiresaki_cd));
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal(BoSystemFormat.formatDenpyoNo((string)f01M1Form.Dictionary[Tb030p01Constant.DIC_M1DENPYO_BANGO])));
			// 指定納品日
			reader.BindValue("BIND_SITEINOHIN_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01M1Form.M1nyukayotei_ymd)));
			// 店舗コード
			reader.BindValue("BIND_TENCD", BoSystemFormat.formatTenpoCd((string)f01Form.Dictionary[SearchConditionSaveCls.GetKey(() => f01Form.Head_tenpo_cd)]));

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
									Tb030f01Form f01Form, 
									Tb030f01M1Form f01M1Form, 
									LoginInfoVO loginInfo, 
									SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tb030p01Constant.SQL_ID_12, facadeContext.DBContext);

			// 登録条件
			// 確定種別
			reader.BindValue("BIND_KAKUTEI_SB", Convert.ToDecimal(f01M1Form.Dictionary[Tb030p01Constant.DIC_M1KAKUTEI_SB]));
			// 仕入先コード
			reader.BindValue("BIND_SIIRESAKI_CD", BoSystemFormat.formatSiiresakiCd(f01M1Form.M1siiresaki_cd));
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal(BoSystemFormat.formatDenpyoNo((string)f01M1Form.Dictionary[Tb030p01Constant.DIC_M1DENPYO_BANGO])));
			// 指定納品日
			reader.BindValue("BIND_SITEINOHIN_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01M1Form.M1nyukayotei_ymd)));
			// 店舗コード
			reader.BindValue("BIND_TENCD", BoSystemFormat.formatTenpoCd((string)f01Form.Dictionary[SearchConditionSaveCls.GetKey(() => f01Form.Head_tenpo_cd)]));

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
									Tb030f01Form f01Form,
									Tb030f01M1Form f01M1Form,
									LoginInfoVO loginInfo,
									SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tb030p01Constant.SQL_ID_13, facadeContext.DBContext);

			// 登録条件
			// 確定種別
			reader.BindValue("BIND_KAKUTEI_SB", Convert.ToDecimal(f01M1Form.Dictionary[Tb030p01Constant.DIC_M1KAKUTEI_SB]));
			// 仕入先コード
			reader.BindValue("BIND_SIIRESAKI_CD", BoSystemFormat.formatSiiresakiCd(f01M1Form.M1siiresaki_cd));
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal(BoSystemFormat.formatDenpyoNo((string)f01M1Form.Dictionary[Tb030p01Constant.DIC_M1DENPYO_BANGO])));
			// 指定納品日
			reader.BindValue("BIND_SITEINOHIN_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01M1Form.M1nyukayotei_ymd)));
			// 店舗コード
			reader.BindValue("BIND_TENCD", BoSystemFormat.formatTenpoCd((string)f01Form.Dictionary[SearchConditionSaveCls.GetKey(() => f01Form.Head_tenpo_cd)]));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region SCM検品督促リスト用データの削除
		/// <summary>
		/// SCM検品督促リスト用データの削除を行います。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="dDenno">伝票番号</param>
		/// <returns>更新件数</returns>
		private int Del_SCMKenpinTokusokuList(IFacadeContext facadeContext,
									Tb030f01Form f01Form,
									Tb030f01M1Form f01M1Form,
									LoginInfoVO loginInfo,
									SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tb030p01Constant.SQL_ID_14, facadeContext.DBContext);

			// 登録条件
			// 仕入先コード
			reader.BindValue("BIND_SIIRESAKI_CD", BoSystemFormat.formatSiiresakiCd(f01M1Form.M1siiresaki_cd));
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal(BoSystemFormat.formatDenpyoNo((string)f01M1Form.Dictionary[Tb030p01Constant.DIC_M1DENPYO_BANGO])));
			// 指定納品日
			reader.BindValue("BIND_SITEINOHIN_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01M1Form.M1nyukayotei_ymd)));
			// 店舗コード
			reader.BindValue("BIND_TENCD", BoSystemFormat.formatTenpoCd((string)f01Form.Dictionary[SearchConditionSaveCls.GetKey(() => f01Form.Head_tenpo_cd)]));

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
		private int Upd_ShiireNyukaKakuteiChkh(IFacadeContext facadeContext,
									Tb030f01Form f01Form,
									Tb030f01M1Form f01M1Form,
									LoginInfoVO loginInfo,
									SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tb030p01Constant.SQL_ID_15, facadeContext.DBContext);

			// 入力フラグ
			decimal dnyuryokuF = 0;
			if (BoSystemConstant.CHECKBOX_ON.Equals(f01M1Form.M1nyuka_kakutei_check))
			{
				// チェックありの場合は"1"
				dnyuryokuF = 1;
			}
			else
			{
				// その他の場合は"0"
				dnyuryokuF = 0;
			}

			// 更新内容
			// 入力フラグ
			reader.BindValue("BIND_INPUT_FLG", dnyuryokuF);
			// チェック担当者
			reader.BindValue("BIND_CHECK_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));

			// 更新条件
			// 確定種別
			reader.BindValue("BIND_KAKUTEI_SB", Convert.ToDecimal(f01M1Form.Dictionary[Tb030p01Constant.DIC_M1KAKUTEI_SB]));
			// 仕入先コード
			reader.BindValue("BIND_SIIRESAKI_CD", BoSystemFormat.formatSiiresakiCd(f01M1Form.M1siiresaki_cd));
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal(BoSystemFormat.formatDenpyoNo((string)f01M1Form.Dictionary[Tb030p01Constant.DIC_M1DENPYO_BANGO])));
			// 指定納品日
			reader.BindValue("BIND_SITEINOHIN_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01M1Form.M1nyukayotei_ymd)));
			// 店舗コード
			reader.BindValue("BIND_TENCD", BoSystemFormat.formatTenpoCd((string)f01Form.Dictionary[SearchConditionSaveCls.GetKey(() => f01Form.Head_tenpo_cd)]));

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
