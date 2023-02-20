using com.xebio.bo.Tf030p01.Constant;
using com.xebio.bo.Tf030p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.V01000.V01001;
using Common.Business.V01000.V01002;
using Common.Business.V03000.V03001;
using Common.Business.V03000.V03002;
using Common.Business.V03000.V03004;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace com.xebio.bo.Tf030p01.Facade
{
  /// <summary>
  /// Tf030f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tf030f01Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : Btnsearch)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnsearch)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNSEARCH_FRM(IFacadeContext facadeContext)
		{

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNSEARCH_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得する。
				OpenConnection(facadeContext);

				//以下に業務ロジックを記述する。

				#region 初期化

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Tf030f01Form f01VO = (Tf030f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// 選択モードNoの初期化
				f01VO.Stkmodeno = string.Empty;

				// 一覧の初期化
				m1List.ClearCacheData();
				m1List.Clear();

				#endregion

				#region 業務チェック

				#region 単項目チェック

				// 1-1 ヘッダ店舗コード
				//       店舗マスタを検索し、存在しない場合エラー
				f01VO.Head_tenpo_nm = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Head_tenpo_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01001Check.CheckTenpo(f01VO.Head_tenpo_cd, facadeContext, "店舗", new[] { "Head_tenpo_cd" });
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Head_tenpo_nm = (string)resultHash["TENPO_NM"];
					}
				}

				// 1-2 仕入先コード
				//       仕入先マスタを検索し、存在しない場合エラー
				f01VO.Siiresaki_ryaku_nm = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Siiresaki_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01002Check.CheckShiiresaki(f01VO.Siiresaki_cd
															, facadeContext
															, string.Empty
															, null
															, "取引先"
															, new[] { "Siiresaki_cd" }
															, null
															, null
															, null
															, 0
															, 0
															);
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Siiresaki_ryaku_nm = (string)resultHash["SIIRESAKI_RYAKU_NM"];
					}
				}

				// 店舗コードFrom(名称取得、チェックは行わない)
				//       店舗マスタを検索し、名前を設定する。
				f01VO.Tenpo_nm_from = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Tenpo_cd_from))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01001Check.CheckTenpo(f01VO.Tenpo_cd_from
														, facadeContext
														, string.Empty
														, null
														, null
														, null
														, null
														, null
														, null
														, 0
														, 0
														);
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Tenpo_nm_from = (string)resultHash["TENPO_NM"];
					}
				}

				// 店舗コードTo(名称取得、チェックは行わない)
				//       店舗マスタを検索し、名前を設定する。
				f01VO.Tenpo_nm_to = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Tenpo_cd_to))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01001Check.CheckTenpo(f01VO.Tenpo_cd_to
														, facadeContext
														, string.Empty
														, null
														, null
														, null
														, null
														, null
														, null
														, 0
														, 0
														);
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Tenpo_nm_to = (string)resultHash["TENPO_NM"];
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region 関連項目チェック

				// 2-1 登録日FROM、登録日TO
				//       登録日ＦＲＯＭ > 登録日ＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Add_ymd_from) && !string.IsNullOrEmpty(f01VO.Add_ymd_to))
				{
					V03001Check.DateFromToChk(
									f01VO.Add_ymd_from,
									f01VO.Add_ymd_to,
									facadeContext,
									"登録日",
									new[] { "Add_ymd_from", "Add_ymd_to" }
									);
				}

				// 2-2 店舗コードFROM、店舗コードTO
				//       店舗コードＦＲＯＭ > 店舗コードＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Tenpo_cd_from) && !string.IsNullOrEmpty(f01VO.Tenpo_cd_to))
				{
					V03002Check.CodeFromToChk(
									f01VO.Tenpo_cd_from,
									f01VO.Tenpo_cd_to,
									facadeContext,
									"店舗コード",
									new[] { "Tenpo_cd_from", "Tenpo_cd_to" }
									);
				}

				// 2-3 伝票番号FROM、伝票番号TO
				//       伝票番号ＦＲＯＭ > 伝票番号ＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Denpyo_bango_from) && !string.IsNullOrEmpty(f01VO.Denpyo_bango_to))
				{
					V03002Check.CodeFromToChk(
									f01VO.Denpyo_bango_from,
									f01VO.Denpyo_bango_to,
									facadeContext,
									"伝票番号",
									new[] { "Denpyo_bango_from", "Denpyo_bango_to" }
									);
				}

				// 2-4 元伝票番号FROM、元伝票番号TO
				//       元伝票番号ＦＲＯＭ > 元伝票番号ＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Motodenpyo_bango_from) && !string.IsNullOrEmpty(f01VO.Motodenpyo_bango_to))
				{
					V03002Check.CodeFromToChk(
									f01VO.Motodenpyo_bango_from,
									f01VO.Motodenpyo_bango_to,
									facadeContext,
									"元伝票番号",
									new[] { "Motodenpyo_bango_from", "Motodenpyo_bango_to" }
									);
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#endregion

				#region 件数チェック

				FindSqlResultTable rtChk = FindSqlUtil.CreateFindSqlResultTable(Tf030p01Constant.SQL_ID_01, facadeContext.DBContext);

				// 検索条件設定
				this.AddWhere(f01VO, rtChk);

				//検索結果を取得します
				rtChk.CreateDbCommand();
				IList<Hashtable> tableListcnt = rtChk.Execute();

				BoSystemLog.logOut("SQL: " + rtChk.LogSql);

				if (tableListcnt == null || tableListcnt.Count <= 0)
				{
					// エラー
					ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
				}
				else
				{
					Hashtable resultTbl = tableListcnt[0];
					Decimal dCnt = (Decimal)resultTbl["CNT"];

					// 0件チェック
					if (dCnt <= 0)
					{
						ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
					}
					else
					{
						// 最大件数チェック
						V03004Check.MaxCountCheck(facadeContext.CommandInfo.FormId.ToUpper(), dCnt, facadeContext);
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region 検索処理

				// 経費未払テーブルから検索する。
				FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(Tf030p01Constant.SQL_ID_02, facadeContext.DBContext);

				// 検索条件設定
				this.AddWhere(f01VO, rtSeach);

				//検索結果を取得します
				rtSeach.CreateDbCommand();
				IList<Hashtable> tableList = rtSeach.Execute();

				int iCnt = 0;
				foreach (Hashtable rec in tableList)
				{
					iCnt++;
					Tf030f01M1Form f01m1VO = new Tf030f01M1Form();

					f01m1VO.M1rowno = iCnt.ToString();																	// Ｍ１行NO
					f01m1VO.M1add_ymd = BoSystemFormat.formatDate(rec["SYORI_YMD"].ToString());							// Ｍ１登録日
					f01m1VO.M1tenpo_cd = rec["TENPO_CD"].ToString();													// Ｍ１店舗コード
					f01m1VO.M1tenpo_nm = rec["TENPO_NM"].ToString();													// Ｍ１店舗名
					f01m1VO.M1siiresaki_cd = rec["SIIRESAKI_CD"].ToString();											// Ｍ１仕入先コード
					f01m1VO.M1siiresaki_ryaku_nm = rec["SIIRESAKI_RYAKU_NM"].ToString();								// Ｍ１仕入先略式名称
					f01m1VO.M1motodenpyo_bango = BoSystemFormat.formatDenpyoNo(rec["MOTODENPYO_BANGO"].ToString());		// Ｍ１元伝票番号
					f01m1VO.M1nohin_ymd = BoSystemFormat.formatDate(rec["NOHINSYO_YMD"].ToString());					// Ｍ１納品日
					f01m1VO.M1nyuryokutan_nm = rec["NYURYOKUTAN_NM"].ToString();										// Ｍ１入力担当者名称
					f01m1VO.M1itemsu = rec["SURYO"].ToString();															// Ｍ１数量
					f01m1VO.M1kingaku = rec["KINGAKU"].ToString();														// Ｍ１金額
					f01m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;											// Ｍ１選択フラグ(隠し)
					f01m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;										// Ｍ１確定処理フラグ(隠し)
					// 送信済フラグが1の場合
					if (ConditionSosinzumi_flg.VALUE_SOSINZUMI.Equals(rec["SOSINZUMI_FLG"].ToString()))
					{
						f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_SOSINZUMI;									// Ｍ１明細色区分(隠し)
					}
					else
					{
						f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;										// Ｍ１明細色区分(隠し)
					}
					
					// Dictionary
					f01m1VO.Dictionary.Add(Tf030p01Constant.DIC_M1DENPYO_BANGO, BoSystemFormat.formatDenpyoNo(rec["DENPYO_BANGO"].ToString()));		// 伝票番号
					f01m1VO.Dictionary.Add(Tf030p01Constant.DIC_M1SYORI_YMD, rec["SYORI_YMD"].ToString());											// 処理日付
					f01m1VO.Dictionary.Add(Tf030p01Constant.DIC_M1SYORI_TM, rec["SYORI_TM"].ToString());											// 処理時間
					f01m1VO.Dictionary.Add(Tf030p01Constant.DIC_M1KENPINSYA_CD, BoSystemFormat.formatTantoCd(rec["KENPINSYA_CD"].ToString()));		// 検品者コード
					f01m1VO.Dictionary.Add(Tf030p01Constant.DIC_M1KENPINSYA_NM, rec["KENPINSYA_NM"].ToString());									// 検品者名称
					f01m1VO.Dictionary.Add(Tf030p01Constant.DIC_M1NYURYOKUTAN_CD, BoSystemFormat.formatTantoCd(rec["NYURYOKUTAN_CD"].ToString()));	// 入力者コード
					f01m1VO.Dictionary.Add(Tf030p01Constant.DIC_M1SOSINZUMI_FLG, rec["SOSINZUMI_FLG"].ToString());									// 送信済フラグ
					f01m1VO.Dictionary.Add(Tf030p01Constant.DIC_M1UPD_YMD, BoSystemFormat.formatDate(rec["UPD_YMD"].ToString()));					// 更新日
					f01m1VO.Dictionary.Add(Tf030p01Constant.DIC_M1UPD_TM, rec["UPD_TM"].ToString());												// 更新時間

					//リストオブジェクトにM1Formを追加します。
					m1List.Add(f01m1VO, true);
				}

				// モードNoを選択モードNoへ設定
				f01VO.Stkmodeno = f01VO.Modeno;

				// 検索件数の設定
				f01VO.Searchcnt = m1List.Count.ToString();

				// 検索条件を退避
				SearchConditionSaveCls.SearchConditionSave(f01VO);

				#endregion

				//トランザクションをコミットする。
				//CommitTransaction(facadeContext);
			}
			catch (System.Exception ex)
			{
				//トランザクションをロールバックする。
				//RollbackTransaction(facadeContext);
				//例外処理を実行する。
				ThrowException(ex, facadeContext);
			}
			finally
			{
				//コネクションを開放する。
				CloseConnection(facadeContext);
			}
			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNSEARCH_FRM");

		}
		#endregion

		#region 検索条件設定
		/// <summary>
		/// AddWhere 検索条件設定
		/// </summary>
		/// <param name="f01VO">Tf030f01Form</param>
		/// <param name="FindSqlResultTable">rtChk</param>
		/// <returns></returns>
		private void AddWhere(Tf030f01Form f01VO, FindSqlResultTable reader)
		{
			ArrayList bindList = new ArrayList();
			BindInfoVO bindVO = new BindInfoVO();
			StringBuilder sRepSql = new StringBuilder();

			// 検索条件を設定 -----------

			sRepSql = new StringBuilder();

			// 登録日FROMを設定
			if (!string.IsNullOrEmpty(f01VO.Add_ymd_from))
			{
				sRepSql.Append(" AND T1.SYORI_YMD >= :BIND_SYORI_YMD_FROM");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SYORI_YMD_FROM";
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Add_ymd_from);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 登録日TOを設定
			if (!string.IsNullOrEmpty(f01VO.Add_ymd_to))
			{
				sRepSql.Append(" AND T1.SYORI_YMD <= :BIND_SYORI_YMD_TO");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SYORI_YMD_TO";
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Add_ymd_to);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 店舗コードFROMを設定
			if (!string.IsNullOrEmpty(f01VO.Tenpo_cd_from))
			{
				sRepSql.Append(" AND T1.TENPO_CD >= :BIND_TENPO_CD_FROM");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_TENPO_CD_FROM";
				bindVO.Value = BoSystemFormat.formatTenpoCd(f01VO.Tenpo_cd_from);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 店舗コードTOを設定
			if (!string.IsNullOrEmpty(f01VO.Tenpo_cd_to))
			{
				sRepSql.Append(" AND T1.TENPO_CD <= :BIND_TENPO_CD_TO");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_TENPO_CD_TO";
				bindVO.Value = BoSystemFormat.formatTenpoCd(f01VO.Tenpo_cd_to);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 仕入先コードを設定
			if (!string.IsNullOrEmpty(f01VO.Siiresaki_cd))
			{
				sRepSql.Append(" AND T1.SIIRESAKI_CD = :BIND_SIIRESAKI_CD");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SIIRESAKI_CD";
				bindVO.Value = BoSystemFormat.formatSiiresakiCd(f01VO.Siiresaki_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 伝票番号FROMを設定
			if (!string.IsNullOrEmpty(f01VO.Denpyo_bango_from))
			{
				sRepSql.Append(" AND T1.DENPYO_BANGO >= :BIND_DENPYO_BANGO_FROM");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_DENPYO_BANGO_FROM";
				bindVO.Value = BoSystemFormat.formatDenpyoNo(f01VO.Denpyo_bango_from);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 伝票番号TOを設定
			if (!string.IsNullOrEmpty(f01VO.Denpyo_bango_to))
			{
				sRepSql.Append(" AND T1.DENPYO_BANGO <= :BIND_DENPYO_BANGO_TO");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_DENPYO_BANGO_TO";
				bindVO.Value = BoSystemFormat.formatDenpyoNo(f01VO.Denpyo_bango_to);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 元伝票番号FROMを設定
			if (!string.IsNullOrEmpty(f01VO.Motodenpyo_bango_from))
			{
				sRepSql.Append(" AND T1.MOTODENPYO_BANGO >= :BIND_MOTODENPYO_FROM");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_MOTODENPYO_FROM";
				bindVO.Value = BoSystemFormat.formatDenpyoNo(f01VO.Motodenpyo_bango_from);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 元伝票番号TOを設定
			if (!string.IsNullOrEmpty(f01VO.Motodenpyo_bango_to))
			{
				sRepSql.Append(" AND T1.MOTODENPYO_BANGO <= :BIND_MOTODENPYO_TO");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_MOTODENPYO_TO";
				bindVO.Value = BoSystemFormat.formatDenpyoNo(f01VO.Motodenpyo_bango_to);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 送信済フラグ
			// モードが「修正」か「取消」の場合
			if (BoSystemConstant.MODE_UPD.Equals(f01VO.Modeno) || BoSystemConstant.MODE_DEL.Equals(f01VO.Modeno))
			{
				sRepSql.Append(" AND T1.SOSINZUMI_FLG = 0");
			}

			BoSystemSql.AddSql(reader, Tf030p01Constant.REP_ADD_WHERE, sRepSql.ToString(), bindList);

		}

		#endregion

	}
}
