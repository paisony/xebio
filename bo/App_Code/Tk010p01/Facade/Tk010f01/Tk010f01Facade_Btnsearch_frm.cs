using com.xebio.bo.Tk010p01.Constant;
using com.xebio.bo.Tk010p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
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

namespace com.xebio.bo.Tk010p01.Facade
{
  /// <summary>
  /// Tk010f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tk010f01Facade : StandardBaseFacade
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
				OpenConnection(facadeContext);
			
				//以下に業務ロジックを記述する。
				#region 初期化

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Tk010f01Form f01VO = (Tk010f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");
				
				// 選択モードの初期化
				f01VO.Stkmodeno = string.Empty;

				// 一覧の初期化
				m1List.ClearCacheData();
				m1List.Clear();

				// 検索条件のDictionaryを初期化
				SearchConditionSaveCls.SearchConditionRemove(f01VO);

				#endregion

				// モードによって状態を変更する
				// 条件設定
				switch (f01VO.Modeno)
				{
					case BoSystemConstant.MODE_KAKUTEI:	// 確定モード
						f01VO.Syonin_flg = BoSystemConstant.DROPDOWNLIST_MISENTAKU;
						f01VO.Kessai_flg = ConditionKessai_jotai.VALUE_KESSAI_JOTAI1;

						break;
					case BoSystemConstant.MODE_UPD:		// 修正モード
						f01VO.Kessai_flg = ConditionKessai_jotai.VALUE_KESSAI_JOTAI2;

						break;
					case BoSystemConstant.MODE_REF:		// 照会モード
						break;
					default:
						break;
				}

				#region 業務チェック

				#region 単項目チェック

				// ヘッダ店舗コード 店舗MSTを検索し、存在しない場合エラー
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

				// 店舗コードFROM、TOを取得する
				f01VO.Tenpo_nm_from = string.Empty;
				f01VO.Tenpo_nm_to = string.Empty;
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

				#region 関連チェック

				// 店舗コードＦＲＯＭ > 店舗コードＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Tenpo_cd_from) && !string.IsNullOrEmpty(f01VO.Tenpo_cd_to))
				{
					V03002Check.CodeFromToChk(
									f01VO.Tenpo_cd_from,
									f01VO.Tenpo_cd_to,
									facadeContext,
									"店舗",
									new[] { "Tenpo_cd_from", "Tenpo_cd_to" }
									);
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region 件数チェック

				// 検索件数
				Decimal dCnt = 0;
				String countSqlId = string.Empty;

				// SQLID設定
				switch (f01VO.Modeno)
				{
					case BoSystemConstant.MODE_KAKUTEI:	// 確定モード
						countSqlId = Tk010p01Constant.SQL_ID_01;
						break;
					case BoSystemConstant.MODE_UPD:		// 修正モード
						countSqlId = Tk010p01Constant.SQL_ID_02;
						break;

					case BoSystemConstant.MODE_REF:		// 照会モード
						countSqlId = Tk010p01Constant.SQL_ID_03;
						break;
					default:
						break;
				}

				FindSqlResultTable rtChk = FindSqlUtil.CreateFindSqlResultTable(countSqlId, facadeContext.DBContext);

				// 条件設定
				switch (f01VO.Modeno)
				{
					case BoSystemConstant.MODE_KAKUTEI:	// 確定モード
						AddWhere(f01VO, rtChk, Tk010p01Constant.TABLE_MDIT0060, Tk010p01Constant.SQL_REP_ADD_WHERE_1);
						break;
					case BoSystemConstant.MODE_UPD:		// 修正モード
						AddWhere(f01VO, rtChk, Tk010p01Constant.TABLE_MDIT0070, Tk010p01Constant.SQL_REP_ADD_WHERE_1);
						break;

					case BoSystemConstant.MODE_REF:		// 照会モード
						AddWhere(f01VO, rtChk, Tk010p01Constant.TABLE_MDIT0060, Tk010p01Constant.SQL_REP_ADD_WHERE_1);
						AddWhere(f01VO, rtChk, Tk010p01Constant.TABLE_MDIT0070, Tk010p01Constant.SQL_REP_ADD_WHERE_2);

						break;
					default:
						break;
				}

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

				#endregion

				#endregion

				#region 検索処理

				String SqlId = string.Empty;

				// SQLID設定
				switch (f01VO.Modeno)
				{
					case BoSystemConstant.MODE_KAKUTEI:	// 確定モード
						SqlId = Tk010p01Constant.SQL_ID_04;
						break;
					case BoSystemConstant.MODE_UPD:		// 修正モード
						SqlId = Tk010p01Constant.SQL_ID_05;
						break;

					case BoSystemConstant.MODE_REF:		// 照会モード
						SqlId = Tk010p01Constant.SQL_ID_06;
						break;
					default:
						break;
				}

				FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(SqlId, facadeContext.DBContext);

				// 条件設定
				switch (f01VO.Modeno)
				{
					case BoSystemConstant.MODE_KAKUTEI:	// 確定モード
						AddWhere(f01VO, rtSeach, Tk010p01Constant.TABLE_MDIT0060, Tk010p01Constant.SQL_REP_ADD_WHERE_1);
						break;

					case BoSystemConstant.MODE_UPD:		// 修正モード
						AddWhere(f01VO, rtSeach, Tk010p01Constant.TABLE_MDIT0070, Tk010p01Constant.SQL_REP_ADD_WHERE_1);
						break;

					case BoSystemConstant.MODE_REF:		// 照会モード
						AddWhere(f01VO, rtSeach, Tk010p01Constant.TABLE_MDIT0060, Tk010p01Constant.SQL_REP_ADD_WHERE_1);
						AddWhere(f01VO, rtSeach, Tk010p01Constant.TABLE_MDIT0070, Tk010p01Constant.SQL_REP_ADD_WHERE_2);

						break;
					default:
						break;
				}

				//検索結果を取得します
				rtSeach.CreateDbCommand();
				IList<Hashtable> tableList = rtSeach.Execute();

				int iCnt = 0;

				// 合計数計算
				Decimal dGokei_suryo = 0;
				Decimal dGenka_kin_gokei = 0;

				foreach (Hashtable rec in tableList)
				{
					iCnt++;
					Tk010f01M1Form f01m1VO = new Tk010f01M1Form();

					f01m1VO.M1rowno = iCnt.ToString();																// Ｍ１行NO
					f01m1VO.M1apply_ymd = BoSystemString.ZeroToEmpty(rec["APPLY_YMD"].ToString());					// Ｍ１申請日
					f01m1VO.M1sinsei_kb_nm = rec["SAISHINSEI_FLG_NM"].ToString();									// Ｍ１申請区分名称
					f01m1VO.M1syonin_flg_nm = rec["SYONIN_FLG_NM"].ToString();										// Ｍ１承認状態名称
					f01m1VO.M1kessai_flg_nm = rec["KESSAI_FLG_NM"].ToString();										// Ｍ１決裁状態名称
					f01m1VO.M1notnb_suryo = rec["NOTNB_SURYO"].ToString();											// Ｍ１ＮＢ以外数量
					f01m1VO.M1notnb_genka_kin = rec["NOTNB_GENKA_KIN"].ToString();									// Ｍ１ＮＢ以外原価金額
					f01m1VO.M1nb_suryo = rec["NB_SURYO"].ToString();												// Ｍ１ＮＢ数量
					f01m1VO.M1nb_genka_kin = rec["NB_GENKA_KIN"].ToString();										// Ｍ１ＮＢ原価金額
					f01m1VO.M1tenpogokei_su = rec["TENPOGOKEI_SU"].ToString();										// Ｍ１店舗合計数量
					f01m1VO.M1tenpogokei_genka_kin = rec["TENPOGOKEI_GENKA_KIN"].ToString();						// Ｍ１店舗合計原価金額
					f01m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;										// Ｍ１選択フラグ(隠し)
					f01m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;									// Ｍ１確定処理フラグ
					f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;										// Ｍ１明細色区分(隠し)

					// 送信済み行は色変更
					if (ConditionSosinzumi_flg.VALUE_SOSINZUMI.Equals(rec["SOSINZUMI_FLG"].ToString()))
					{
						f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_SOSINZUMI;											// Ｍ１明細色区分(隠し)
					}

					// Dictionary
					f01m1VO.Dictionary[Tk010p01Constant.DIC_M1TENPO_CD] = rec["TENPO_CD"].ToString();				// Ｍ１店舗コード
					f01m1VO.Dictionary[Tk010p01Constant.DIC_M1TENPO_NM] = rec["TENPO_NM"].ToString();				// Ｍ１店舗名
					f01m1VO.Dictionary[Tk010p01Constant.DIC_M1UPD_YMD] = rec["UPD_UMD"].ToString();					// Ｍ１更新日
					f01m1VO.Dictionary[Tk010p01Constant.DIC_M1UPD_TM] = rec["UPD_TM"].ToString();					// Ｍ１更新時間
					f01m1VO.Dictionary[Tk010p01Constant.DIC_M1KESSAI_FLG] = rec["KESSAI_FLG"].ToString();			// Ｍ１決裁状態区分
					f01m1VO.Dictionary[Tk010p01Constant.DIC_M1SYONIN_FLG] = rec["SYONIN_FLG"].ToString();			// Ｍ１承認状態区分
					f01m1VO.Dictionary[Tk010p01Constant.DIC_M1SAISHINSEI_FLG] = rec["SAISHINSEI_FLG"].ToString();	// Ｍ１再申請フラグ

					// 明細リンク制御用 リンク使用可能
					f01m1VO.Dictionary[Tk010p01Constant.DIC_M1LINKFLG] = Tk010p01Constant.MEISAI_LINK_KANO_FLG;

					// 合計値計算
					// Ｍ１店舗合計数量
					dGokei_suryo += Convert.ToDecimal(BoSystemString.Nvl(rec["TENPOGOKEI_SU"].ToString(), "0"));
					// Ｍ１店舗合計原価金額
					dGenka_kin_gokei += Convert.ToDecimal(BoSystemString.Nvl(rec["TENPOGOKEI_GENKA_KIN"].ToString(), "0"));

					//リストオブジェクトにM1Formを追加します。
					m1List.Add(f01m1VO, true);	

				}

				// 合計数量
				f01VO.Gokei_suryo = dGokei_suryo.ToString();

				// 合計原価金額
				f01VO.Genka_kin_gokei = dGenka_kin_gokei.ToString();

				// 件数の設定
				f01VO.Searchcnt = m1List.Count.ToString();

				// 選択モードNO設定
				f01VO.Stkmodeno = f01VO.Modeno;

				#endregion

				#region 検索条件をDictionaryに設定

				// 検索時のformVOを保持
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

		#region ユーザー定義関数

		#region 検索条件設定
		/// <summary>
		/// AddWhere 検索条件設定
		/// </summary>
		/// <param name="Tk010f01Form">f01VO</param>
		/// <param name="FindSqlResultTable">reader</param>
		/// <param name="String">tableId</param>
		/// <param name="String">repraceId</param>
		/// <returns></returns>
		private void AddWhere(Tk010f01Form f01VO, FindSqlResultTable reader, String tableId, String replaceId)
		{
			ArrayList bindList = new ArrayList();
			BindInfoVO bindVO = new BindInfoVO();
			StringBuilder sRepSql = new StringBuilder();

			// 評価損種別区分
			if (!BoSystemConstant.DROPDOWNLIST_MISENTAKU.Equals(f01VO.Hyokasonsyubetsu_kb))
			{
				sRepSql.Append(" AND ").Append(tableId).Append(".HYOKASONSYUBETSU_KB = :").Append(tableId).Append("_HSYUBETSU_KB");
				bindList.Add(new BindInfoVO(tableId + "_HSYUBETSU_KB", f01VO.Hyokasonsyubetsu_kb, BoSystemSql.BINDTYPE_NUMBER));　// 評価損種別区分
			}

			// 承認状態
			// 確定モード時には条件に含まない（確定テーブルのみ参照）
			if (!BoSystemConstant.MODE_KAKUTEI.Equals(f01VO.Modeno)
				&& tableId.Equals(Tk010p01Constant.TABLE_MDIT0070)
				&& !BoSystemConstant.DROPDOWNLIST_MISENTAKU.Equals(f01VO.Syonin_flg))
			{
				sRepSql.Append(" AND ").Append(tableId).Append(".SYONIN_FLG = :").Append(tableId).Append("_SYONIN_FLG");
				bindList.Add(new BindInfoVO(tableId + "_SYONIN_FLG", f01VO.Syonin_flg, BoSystemSql.BINDTYPE_NUMBER));	// 承認状態
			}

			// 決裁状態
			// 修正モード時には条件に含まない(申請テーブルのみ参照)
			if (!BoSystemConstant.MODE_UPD.Equals(f01VO.Modeno)
				&& tableId.Equals(Tk010p01Constant.TABLE_MDIT0060)
				&& !BoSystemConstant.DROPDOWNLIST_MISENTAKU.Equals(f01VO.Kessai_flg))
			{
				sRepSql.Append(" AND ").Append(tableId).Append(".KESSAI_FLG = :").Append(tableId).Append("_KESSAI_FLG");
				bindList.Add(new BindInfoVO(tableId + "_KESSAI_FLG", f01VO.Kessai_flg, BoSystemSql.BINDTYPE_NUMBER));	// 決済状態
			}

			//申請区分 (申請テーブルを参照)
			if (!BoSystemConstant.DROPDOWNLIST_MISENTAKU.Equals(f01VO.Sinsei_kb))
			{
				sRepSql.Append(" AND ").Append(Tk010p01Constant.TABLE_MDIT0060).Append(".SAISHINSEI_FLG = :").Append(tableId).Append("_SHINSEI_FLG");
				bindList.Add(new BindInfoVO(tableId + "_SHINSEI_FLG", f01VO.Sinsei_kb, BoSystemSql.BINDTYPE_NUMBER));	// 申請区分
			}

			// 店舗コード
			if (!string.IsNullOrEmpty(f01VO.Tenpo_cd_from) || !string.IsNullOrEmpty(f01VO.Tenpo_cd_to))
			{
				string tenpo_Cd_from = BoSystemFormat.formatTenpoCd(f01VO.Tenpo_cd_from);
				string tenpo_Cd_to = BoSystemFormat.formatTenpoCd(f01VO.Tenpo_cd_to);

				if (string.IsNullOrEmpty(tenpo_Cd_from))
				{
					tenpo_Cd_from = "0000";
				}

				if (string.IsNullOrEmpty(tenpo_Cd_to))
				{
					tenpo_Cd_to = "9999";
				}

				sRepSql.Append(" AND ").Append(tableId).Append(".TENPO_CD BETWEEN :").Append(tableId).Append("_TENPO_FROM AND :").Append(tableId).Append("_TENPO_TO");
				bindList.Add(new BindInfoVO(tableId + "_TENPO_FROM", tenpo_Cd_from, BoSystemSql.BINDTYPE_STRING));	// 店舗コードFROM
				bindList.Add(new BindInfoVO(tableId + "_TENPO_TO", tenpo_Cd_to, BoSystemSql.BINDTYPE_STRING));		// 店舗コードTO

			}

			// 処理月
			if (!string.IsNullOrEmpty(f01VO.Syori_ym))
			{
				// 確定データは更新日を参照
				if (tableId.Equals(Tk010p01Constant.TABLE_MDIT0070))
				{
					sRepSql.Append(" AND ").Append(tableId).Append(".UPD_YMD LIKE :").Append(tableId).Append("_SYORI_YM");
				}
				else
				{
					sRepSql.Append(" AND ").Append(tableId).Append(".SYORI_YMD LIKE :").Append(tableId).Append("_SYORI_YM");
				}
				bindList.Add(new BindInfoVO(tableId + "_SYORI_YM", BoSystemString.LeftB(f01VO.Syori_ym,6) + "%", BoSystemSql.BINDTYPE_STRING));	// 処理月

			}

			// 照会モード時
			if (BoSystemConstant.MODE_REF.Equals(f01VO.Modeno))
			{
				// 決裁状態
				switch (f01VO.Kessai_flg)
				{
					case BoSystemConstant.DROPDOWNLIST_MISENTAKU:		// 空白

						if (tableId.Equals(Tk010p01Constant.TABLE_MDIT0060))
						{
							// 承認状態が選択されている場合は、申請テーブルは参照しない
							if (!BoSystemConstant.DROPDOWNLIST_MISENTAKU.Equals(f01VO.Syonin_flg))
							{
								sRepSql.Append(" AND 1 = 0");
							}
						}
						break;

					case ConditionKessai_jotai.VALUE_KESSAI_JOTAI1:		// 未決裁

						if (tableId.Equals(Tk010p01Constant.TABLE_MDIT0060))
						{
							// 承認状態が選択されている場合は、申請テーブルは参照しない
							if (!BoSystemConstant.DROPDOWNLIST_MISENTAKU.Equals(f01VO.Syonin_flg))
							{
								sRepSql.Append(" AND 1 = 0");
							}
						}
						else
						{
							//　確定テーブルは参照しない
							sRepSql.Append(" AND 1 = 0");
						}

						break;

					case ConditionKessai_jotai.VALUE_KESSAI_JOTAI2:		// 決裁済

						if (tableId.Equals(Tk010p01Constant.TABLE_MDIT0060))
						{
							sRepSql.Append(" AND 1 = 0");

						}
						break;
					default:
						break;
				} // switch
			} // 照会モード時

			BoSystemSql.AddSql(reader, replaceId, sRepSql.ToString(), bindList);


		}

		#endregion

		#endregion


	}
}
