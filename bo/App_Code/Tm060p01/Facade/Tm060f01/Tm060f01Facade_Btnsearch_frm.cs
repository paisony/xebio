using com.xebio.bo.Tm060p01.Constant;
using com.xebio.bo.Tm060p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.V01000.V01001;
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

namespace com.xebio.bo.Tm060p01.Facade
{
  /// <summary>
  /// Tm060f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tm060f01Facade : StandardBaseFacade
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
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			////メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNSEARCH_FRM");

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
				IDataList m1List = f01VO.GetList("M1");

				// 一覧の初期化
				m1List.ClearCacheData();
				m1List.Clear();

				#endregion

				#region 単項目チェック
				//  店舗マスタを検索し、存在しない場合エラー
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
				//  担当者コードＦＲＯＭ > 担当者コードＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Tantosya_cd_from) && !string.IsNullOrEmpty(f01VO.Tantosya_cd_to))
				{
					V03002Check.CodeFromToChk(
									f01VO.Tantosya_cd_from,
									f01VO.Tantosya_cd_to,
									facadeContext,
									"担当者コード",
									new[] { "Tantosya_cd_from", "Tantosya_cd_to" }
									);
				}
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region 件数チェック

				#region SQL設定

				StringBuilder sRepSql = new StringBuilder();
				Decimal dCnt = 0;

				#endregion

				// 検索件数が0件の場合エラー
				// 検索件数が最大件数を超える場合エラー
				FindSqlResultTable rtChk = null;
				rtChk = FindSqlUtil.CreateFindSqlResultTable(Tm060p01Constant.SQL_ID_01, facadeContext.DBContext);
				AddWhere1(f01VO, rtChk, 1);
				AddWhere2(f01VO, rtChk, 1);
				rtChk.BindValue(Tm060p01Constant.REP_FROM_INNER_1, BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));//FROM INNER JOIN

				BoSystemLog.logOut("[担当者権限MST]件数を検索 START");
		
				IList<Hashtable> tableListcnt = rtChk.Execute();

				if (logger.IsDebugEnabled)
				{
					BoSystemLog.logOut("SQL: " + rtChk.LogSql);
				}

				if (tableListcnt == null || tableListcnt.Count <= 0)
				{
					// エラー
					ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
				}
				else
				{
					Hashtable resultTbl = tableListcnt[0];
					dCnt = (Decimal)resultTbl["CNT"];

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
				// 検索件数の設定
				f01VO.Searchcnt = dCnt.ToString();
				BoSystemLog.logOut("[担当者権限MST件数]を検索 END");
				#endregion

				#region 検索処理

				BoSystemLog.logOut("[担当者権限MSTデータ]を検索 START");
				FindSqlResultTable rtSeach = null;

				rtSeach = FindSqlUtil.CreateFindSqlResultTable(Tm060p01Constant.SQL_ID_03, facadeContext.DBContext);
				AddWhere1(f01VO, rtSeach, 1);
				AddWhere2(f01VO, rtSeach, 1);
				rtSeach.BindValue(Tm060p01Constant.REP_FROM_INNER_1, BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));//FROM INNER JOIN

				BoSystemLog.logOut("[担当者権限MSTデータ]を検索 GOAL");
				//検索結果を取得します
				rtSeach.CreateDbCommand();
				IList<Hashtable> tableList = rtSeach.Execute();
				int iCnt = 0;
				foreach (Hashtable rec in tableList)
				{
					iCnt++;
					Tm060f01M1Form f01m1VO = new Tm060f01M1Form();
					f01m1VO.M1rowno = iCnt.ToString();						// Ｍ１行NO
					f01m1VO.M1tantosya_cd = BoSystemFormat.formatTantoCd(rec["HANBAIIN_CD"].ToString());	// Ｍ１販売員コード
					f01m1VO.M1hanbaiin_nm = rec["HANBAIIN_NM"].ToString();	// Ｍ１販売員名
					f01m1VO.M1syokusei_kb_nm = rec["MEISYO_NM"].ToString();	// Ｍ１職制名
					f01m1VO.M1kengen_kb = rec["KENGEN_KB"].ToString();		// Ｍ１権限区分
					// Ｍ１選択フラグ(隠し)
					f01m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;
					// Ｍ１確定処理フラグ(隠し)
					f01m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;
					// Ｍ１明細色区分(隠し)
					f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;
					//DICTIONARY
					f01m1VO.Dictionary.Add(Tm060p01Constant.DIC_M1UPD_YMD, BoSystemFormat.formatDate(rec["UPD_YMD"].ToString()));		// 更新日
					f01m1VO.Dictionary.Add(Tm060p01Constant.DIC_M1UPD_TM, rec["UPD_TM"].ToString());									// 更新時間
					f01m1VO.Dictionary.Add(Tm060p01Constant.DIC_M1TAN_CD, BoSystemFormat.formatTantoCd(rec["HANBAIIN_CD"].ToString()));	// 更新担当者コード
					//リストオブジェクトにM1Formを追加します。
					m1List.Add(f01m1VO, true);

				}

				#endregion
				// 検索件数の設定
				f01VO.Searchcnt = m1List.Count.ToString();

				// 検索条件を退避
				SearchConditionSaveCls.SearchConditionSave(f01VO);

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
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNSEARCH_FRM");

		}
		
		#region 検索条件設定 Where句
		/// <summary>
		/// AddWhere 検索条件設定
		/// </summary>
		/// <param name="f01VO">Ta040f01Form</param>
		/// <param name="FindSqlResultTable">rtChk</param>
		/// <param name="int">selKbn</param>
		/// <returns></returns>
		private void AddWhere2(Tm060f01Form f01VO, FindSqlResultTable reader, int selKbn)
		{
			ArrayList bindList = new ArrayList();
			BindInfoVO bindVO = new BindInfoVO();
			StringBuilder sRepSql = new StringBuilder();

			// 担当者コードFROMを設定
			if (!string.IsNullOrEmpty(f01VO.Tantosya_cd_from))
			{
				sRepSql.Append(" AND MDMT0210.HANBAIIN_CD  >= :BIND_TAN_CD_FROM");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_TAN_CD_FROM";
				bindVO.Value = BoSystemFormat.formatTantoCd(f01VO.Tantosya_cd_from);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 担当者コードTOを設定
			if (!string.IsNullOrEmpty(f01VO.Tantosya_cd_to))
			{
				sRepSql.Append(" AND MDMT0210.HANBAIIN_CD  <= :BIND_TAN_CD_TO");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_TAN_CD_TO";
				bindVO.Value = BoSystemFormat.formatTantoCd(f01VO.Tantosya_cd_to);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 権限区分を設定
			if (!f01VO.Kengen_kb.Equals(BoSystemConstant.DROPDOWNLIST_MISENTAKU))
			{
				sRepSql.Append(" AND MDMT0210.KENGEN_KB = :BIND_KENGEN_KB ");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_KENGEN_KB";
				bindVO.Value = f01VO.Kengen_kb;
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}
			BoSystemSql.AddSql(reader, Tm060p01Constant.SQL_ID_01_REP_ADD_WHERE2, sRepSql.ToString(), bindList);
		}
		#endregion

		#region 検索条件設定 from句
		/// <summary>
		/// AddWhere 検索条件設定
		/// </summary>
		/// <param name="f01VO">Ta040f01Form</param>
		/// <param name="FindSqlResultTable">rtChk</param>
		/// <param name="int">selKbn</param>
		/// <returns></returns>
		private void AddWhere1(Tm060f01Form f01VO, FindSqlResultTable reader, int selKbn)
		{
			ArrayList bindList = new ArrayList();
			BindInfoVO bindVO = new BindInfoVO();
			StringBuilder sRepSql = new StringBuilder();

			if (f01VO.Syokusei_kb.Equals(BoSystemConstant.DROPDOWNLIST_MISENTAKU))		//職制区分がない場合
			{
					sRepSql.Append(" ");
			}
			else
			{
				if (f01VO.Syokusei_kb.Equals("5") || f01VO.Syokusei_kb.Equals("50"))//職制区分がアルバイトだった場合
				{
					sRepSql.Append(" 	AND BOMT0030.HANBAIIN_KB IN  ");
					sRepSql.Append("		(:BIND_SYOKUSEI_KB_1, :BIND_SYOKUSEI_KB_2 )");

					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_SYOKUSEI_KB_1";
					bindVO.Value = "5";
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_SYOKUSEI_KB_2";
					bindVO.Value = "50";
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);

				}
				else                                                                //職制区分がアルバイト以外だった場合
				{
					sRepSql.Append(" 	AND BOMT0030.HANBAIIN_KB = :BIND_SYOKUSEI_KB_1");

					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_SYOKUSEI_KB_1";
					bindVO.Value = f01VO.Syokusei_kb;
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);

				}
			}
			BoSystemSql.AddSql(reader, Tm060p01Constant.SQL_ID_01_REP_ADD_WHERE1, sRepSql.ToString(), bindList);
		}

		#endregion
		#endregion
	}
}
