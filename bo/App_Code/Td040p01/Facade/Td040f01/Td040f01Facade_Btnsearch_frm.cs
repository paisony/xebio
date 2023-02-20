﻿using com.xebio.bo.Td040p01.Constant;
using com.xebio.bo.Td040p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01012;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V01000.V01001;
using Common.Business.V01000.V01002;
using Common.Business.V01000.V01003;
using Common.Business.V01000.V01004;
using Common.Business.V01000.V01005;
using Common.Business.V01000.V01010;
using Common.Business.V01000.V01012;
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

namespace com.xebio.bo.Td040p01.Facade
{
  /// <summary>
  /// Td040f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Td040f01Facade : StandardBaseFacade
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

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNSEARCH_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
//				//コネクションを取得して、トランザクションを開始する。
//				BeginTransactionWithConnect(facadeContext);
				//コネクションを取得する。
				OpenConnection(facadeContext);
			
				//以下に業務ロジックを記述する。

				#region 初期化

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Td040f01Form f01VO = (Td040f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

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
															, "仕入先"
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

				// 1-3 ブランドコード
				//       ブランドマスタを検索し、存在しない場合エラー
				f01VO.Burando_nm = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Burando_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01012Check.CheckBrand(f01VO.Burando_cd
														, facadeContext
														, string.Empty
														, null
														, "ブランド"
														, new[] { "Burando_cd" }
														, null
														, null
														, null
														, 0
														, 0
														);
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Burando_nm = (string)resultHash["BURANDO_NMK"];
					}
				}

				// 1-4 入力担当者コード
				//       担当者マスタを検索し、存在しない場合エラー
				f01VO.Nyuryokutan_nm = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Nyuryokutan_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01005Check.CheckTanto(f01VO.Nyuryokutan_cd
														, facadeContext
														, string.Empty
														, null
														, "入力担当者"
														, new[] { "Nyuryokutan_cd" }
														, null
														, null
														, null
														, 0
														, 0
														);
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Nyuryokutan_nm = (string)resultHash["HANBAIIN_NM"];
					}
				}

				// 1-5 自社品番
				//       発注マスタを検索し、存在しない場合エラー
				f01VO.Maker_hbn = string.Empty;
				f01VO.Dictionary[Td040p01Constant.DIC_SEARCH_XEBIOCD] = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn))
				{
					SearchHachuVO searchConditionVO = new SearchHachuVO(
						f01VO.Old_jisya_hbn,	// 自社品番
						f01VO.Head_tenpo_cd,	// 店舗コード
						0,						// 店別単価マスタ 検索フラグ 0:検索しない 1:検索する
						0,						// 売変 検索フラグ 0:検索しない 1:検索する
						0,						// 店在庫 検索フラグ 0:検索しない 1:検索する
						0,						// 入荷予定数 検索フラグ 0:検索しない 1:検索する
						0,						// 売上実績数 検索フラグ 0:検索しない 1:検索する
						0,						// 依頼集計数(補充) 検索フラグ 0:検索しない 1:検索する
						0,						// 依頼集計数(単品) 検索フラグ 0:検索しない 1:検索する
						0,						// 指示検索 検索フラグ 0:検索しない 1:出荷指示、2:返品指示
						"",						// 指示NO（移動出荷マニュアル、返品マニュアル用）
						"",						// 出荷会社コード（移動出荷マニュアル)
						"",						// 入荷会社コード（移動出荷マニュアル)
						""						// 指示店舗コード（移動出荷マニュアル、返品マニュアル用）
					);

					Hashtable resultHash = new Hashtable();
					resultHash = V01003Check.CheckXebioCd(searchConditionVO, facadeContext, "自社品番", new[] { "Old_jisya_hbn" });

					// 名称をラベルに設定
					if (resultHash != null)
					{
						// 自社品番をディクショナリに退避
						f01VO.Dictionary[Td040p01Constant.DIC_SEARCH_XEBIOCD] = (string)resultHash["XEBIO_CD"];
						f01VO.Maker_hbn = (string)resultHash["HIN_NBR"];
					}
				}

				// 1-6 スキャンコード
				//       発注マスタを検索し、存在しない場合エラー
				f01VO.Dictionary[Td040p01Constant.DIC_SEARCH_JANCD] = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Scan_cd))
				{
					SearchHachuVO searchConditionVO = new SearchHachuVO(
						f01VO.Scan_cd,			// スキャンコード
						f01VO.Head_tenpo_cd,	// 店舗コード
						0,						// 店別単価マスタ 検索フラグ 0:検索しない 1:検索する
						0,						// 売変 検索フラグ 0:検索しない 1:検索する
						0,						// 店在庫 検索フラグ 0:検索しない 1:検索する
						0,						// 入荷予定数 検索フラグ 0:検索しない 1:検索する
						0,						// 売上実績数 検索フラグ 0:検索しない 1:検索する
						0,						// 依頼集計数(補充) 検索フラグ 0:検索しない 1:検索する
						0,						// 依頼集計数(単品) 検索フラグ 0:検索しない 1:検索する
						0,						// 指示検索 検索フラグ 0:検索しない 1:出荷指示、2:返品指示
						"",						// 指示NO（移動出荷マニュアル、返品マニュアル用）
						"",						// 出荷会社コード（移動出荷マニュアル)
						"",						// 入荷会社コード（移動出荷マニュアル)
						""						// 指示店舗コード（移動出荷マニュアル、返品マニュアル用）
					);

					Hashtable resultHash = new Hashtable();
					resultHash = V01004Check.CheckScanCd(searchConditionVO, facadeContext, "スキャンコード", new[] { "Scan_cd" });
					if (resultHash != null)
					{
						// JANコードをディクショナリに退避
						f01VO.Dictionary[Td040p01Constant.DIC_SEARCH_JANCD] = (string)resultHash["JAN_CD"];
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region 関連項目チェック

				// 2-1 伝票番号FROM、伝票番号TO
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

				// 2-2 部門コードFROM、部門コードTO
				//       部門コードＦＲＯＭ > 部門コードＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Bumon_cd_from) && !string.IsNullOrEmpty(f01VO.Bumon_cd_to))
				{
					V03002Check.CodeFromToChk(
									f01VO.Bumon_cd_from,
									f01VO.Bumon_cd_to,
									facadeContext,
									"部門コード",
									new[] { "Bumon_cd_from", "Bumon_cd_to" }
									);
				}

				// 2-3 返品確定日FROM、返品確定日TO
				//       返品確定日ＦＲＯＭ > 返品確定日ＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Henpin_kakutei_ymd_from) && !string.IsNullOrEmpty(f01VO.Henpin_kakutei_ymd_to))
				{
					V03001Check.DateFromToChk(
									f01VO.Henpin_kakutei_ymd_from,
									f01VO.Henpin_kakutei_ymd_to,
									facadeContext,
									"返品確定日",
									new[] { "Henpin_kakutei_ymd_from", "Henpin_kakutei_ymd_to" }
									);
				}

				// 2-4 登録日FROM、登録日TO
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

				// 部門コードFrom(名称取得、チェックは行わない)
				//       部門マスタを検索し、名前を設定する。
				f01VO.Bumon_nm_from = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Bumon_cd_from))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01010Check.CheckBumon(f01VO.Bumon_cd_from, facadeContext);
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Bumon_nm_from = (string)resultHash["BUMON_NM"];
					}
				}

				// 部門コードTo(名称取得、チェックは行わない)
				//       部門マスタを検索し、名前を設定する。
				f01VO.Bumon_nm_to = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Bumon_cd_to))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01010Check.CheckBumon(f01VO.Bumon_cd_to, facadeContext);
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Bumon_nm_to = (string)resultHash["BUMON_NM"];
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#endregion

				#region 件数チェック

				FindSqlResultTable rtChk = FindSqlUtil.CreateFindSqlResultTable(Td040p01Constant.SQL_ID_01, facadeContext.DBContext);

				#region テーブルID設定
				// テーブルIDを設定 -----------

				ArrayList bindList = new ArrayList();
				BindInfoVO bindVO = new BindInfoVO();
				StringBuilder sRepSql = new StringBuilder();
				Decimal dCnt = 0;

				sRepSql.AppendLine("		MDRT0020 T1");	// 返品確定テーブル(H)
				sRepSql.AppendLine("INNER JOIN");
				sRepSql.AppendLine("		MDRT0021 T2");	// 返品確定テーブル(B)

				BoSystemSql.AddSql(rtChk, Td040p01Constant.SQL_ID_01_REP_TABLE_ID, sRepSql.ToString(), bindList);
				#endregion

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

				#region 検索処理

				// 返品確定テーブルから検索する。

				FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(Td040p01Constant.SQL_ID_02, facadeContext.DBContext);

				#region テーブルID設定
				// テーブルIDを設定 -----------

				BoSystemSql.AddSql(rtSeach, Td040p01Constant.SQL_ID_01_REP_TABLE_ID, sRepSql.ToString(), bindList);
				#endregion

				// 検索条件設定
				this.AddWhere(f01VO, rtSeach);

				//検索結果を取得します
				rtSeach.CreateDbCommand();
				IList<Hashtable> tableList = rtSeach.Execute();

				int iCnt = 0;
				foreach (Hashtable rec in tableList)
				{
					iCnt++;
					Td040f01M1Form f01m1VO = new Td040f01M1Form();

					f01m1VO.M1rowno = iCnt.ToString();																	// Ｍ１行NO
					f01m1VO.M1bumon_cd = rec["BUMON_CD"].ToString();													// Ｍ１部門コード
					f01m1VO.M1bumonkana_nm = rec["BUMONKANA_NM"].ToString();											// Ｍ１部門カナ名
					f01m1VO.M1siiresaki_cd = rec["SIIRESAKI_CD"].ToString();											// Ｍ１仕入先コード
					f01m1VO.M1siiresaki_ryaku_nm = rec["SIIRESAKI_RYAKU_NM"].ToString();								// Ｍ１仕入先略式名称
					f01m1VO.M1kakutei_ymd = BoSystemFormat.formatDate_yyMMdd(rec["HENPIN_YMD"].ToString());				// Ｍ１確定日 
					f01m1VO.M1add_ymd = BoSystemFormat.formatDate_yyMMdd(rec["ADD_YMD"].ToString());					// Ｍ１登録日
					f01m1VO.M1denpyo_bango = BoSystemFormat.formatDenpyoNo(rec["DENPYO_BANGO"].ToString());				// Ｍ１伝票番号
					f01m1VO.M1kanri_no = string.Empty;
					if (!"0".Equals(rec["KANRI_NO"].ToString()))
					{
						f01m1VO.M1kanri_no = BoSystemFormat.formatDenpyoNo(rec["KANRI_NO"].ToString());
					}																									// Ｍ１管理番号
					f01m1VO.M1siji_bango = BoSystemString.ZeroToEmpty(rec["SIJI_BANGO"].ToString());					// Ｍ１指示番号
					f01m1VO.M1hinsyu_ryaku_nm = rec["HINSYU_RYAKU_NM"].ToString();										// Ｍ１品種略名称
					f01m1VO.M1nyuryokutan_nm = rec["HANBAIIN_NM"].ToString();											// Ｍ１入力担当者名称
					f01m1VO.M1burando_nm = rec["BURANDO_NMK"].ToString();												// Ｍ１ブランド名
					f01m1VO.M1henpin_riyu_nm = rec["HENPIN_RIYU_NM"].ToString();										// Ｍ１返品理由名称
					f01m1VO.M1jisya_hbn = rec["JISYA_HBN"].ToString();													// Ｍ１自社品番
					f01m1VO.M1maker_hbn = rec["MAKER_HBN"].ToString();													// Ｍ１メーカー品番
					f01m1VO.M1syonmk = rec["SYONMK"].ToString();														// Ｍ１商品名(カナ)
					f01m1VO.M1iro_nm = rec["IRO_NM"].ToString();														// Ｍ１色
					f01m1VO.M1size_nm = rec["SIZE_NM"].ToString();														// Ｍ１サイズ
					f01m1VO.M1scan_cd = rec["JAN_CD"].ToString();														// Ｍ１スキャンコード
					f01m1VO.M1itemsu = rec["HENPINJISSEKI_SU"].ToString();												// Ｍ１数量
					f01m1VO.M1kakutei_tm = BoSystemFormat.formatTime(rec["UPD_TM"].ToString(), 1);						// Ｍ１確定時間
					f01m1VO.M1kai_su = rec["KAISU"].ToString();															// Ｍ１回数
					f01m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;											// Ｍ１選択フラグ(隠し)
					f01m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;										// Ｍ１確定処理フラグ(隠し)

					if (rec["SOSINZUMI_FLG"].ToString().Equals(ConditionSosinzumi_flg.VALUE_SOSINZUMI))
					{
						f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_SOSINZUMI;									// Ｍ１明細色区分(隠し)
					}
					else
					{
						f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;										// Ｍ１明細色区分(隠し)
					}

					//リストオブジェクトにM1Formを追加します。
					m1List.Add(f01m1VO, true);
				}

				// 検索件数の設定
				f01VO.Searchcnt = m1List.Count.ToString();

				// 検索条件を退避
				SearchConditionSaveCls.SearchConditionSave(f01VO);

				#endregion

				//トランザクションをコミットする。
//				CommitTransaction(facadeContext);
			}
			catch (System.Exception ex)
			{
				//トランザクションをロールバックする。
//				RollbackTransaction(facadeContext);
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
		/// <param name="f01VO">Td040f01Form</param>
		/// <param name="FindSqlResultTable">rtChk</param>
		/// <returns></returns>
		private void AddWhere(Td040f01Form f01VO, FindSqlResultTable reader)
		{
			ArrayList bindList = new ArrayList();
			BindInfoVO bindVO = new BindInfoVO();
			StringBuilder sRepSql = new StringBuilder();

			#region 検索条件設定

			// 検索条件を設定 -----------

			sRepSql = new StringBuilder();


			// 店舗コードを設定
			sRepSql.Append(" AND T1.TENPO_CD = :BIND_TENPO_CD");

			bindVO = new BindInfoVO();
			bindVO.BindId = "BIND_TENPO_CD";
			bindVO.Value = BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd);
			bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
			bindList.Add(bindVO);

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

			// ブランドコードを設定

			if (!string.IsNullOrEmpty(f01VO.Burando_cd))
			{
				sRepSql.Append(" AND T1.BURANDO_CD = :BIND_BURANDO_CD");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_BURANDO_CD";
				bindVO.Value = BoSystemFormat.formatBrandCd(f01VO.Burando_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 部門FROMを設定

			if (!string.IsNullOrEmpty(f01VO.Bumon_cd_from))
			{
				sRepSql.Append(" AND T1.BUMON_CD >= :BIND_BUMON_CD_FROM");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_BUMON_CD_FROM";
				bindVO.Value = BoSystemFormat.formatBumonCd(f01VO.Bumon_cd_from);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 部門TOを設定

			if (!string.IsNullOrEmpty(f01VO.Bumon_cd_to))
			{
				sRepSql.Append(" AND T1.BUMON_CD <= :BIND_BUMON_CD_TO");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_BUMON_CD_TO";
				bindVO.Value = BoSystemFormat.formatBumonCd(f01VO.Bumon_cd_to);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 入力担当者コードを設定

			if (!string.IsNullOrEmpty(f01VO.Nyuryokutan_cd))
			{
				sRepSql.Append(" AND T1.UPD_TANCD = :BIND_UPD_TANCD");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_UPD_TANCD";
				bindVO.Value = BoSystemFormat.formatTantoCd(f01VO.Nyuryokutan_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 返品確定日FROMを設定

			if (!string.IsNullOrEmpty(f01VO.Henpin_kakutei_ymd_from))
			{
				sRepSql.Append(" AND T1.HENPIN_YMD >= :BIND_HENPIN_YMD_FROM");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_HENPIN_YMD_FROM";
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Henpin_kakutei_ymd_from);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 返品確定日TOを設定

			if (!string.IsNullOrEmpty(f01VO.Henpin_kakutei_ymd_to))
			{
				sRepSql.Append(" AND T1.HENPIN_YMD <= :BIND_HENPIN_YMD_TO");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_HENPIN_YMD_TO";
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Henpin_kakutei_ymd_to);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 登録日FROMを設定

			if (!string.IsNullOrEmpty(f01VO.Add_ymd_from))
			{
				sRepSql.Append(" AND CASE WHEN T1.KANRI_NO = 0");
				sRepSql.Append("     THEN T1.ADD_YMD");
				sRepSql.Append("     ELSE T1.HHTADD_YMD");
				sRepSql.Append("     END        >= :BIND_ADD_YMD_FROM");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_ADD_YMD_FROM";
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Add_ymd_from);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 登録日TOを設定

			if (!string.IsNullOrEmpty(f01VO.Add_ymd_to))
			{
				sRepSql.Append(" AND CASE WHEN T1.KANRI_NO = 0");
				sRepSql.Append("     THEN T1.ADD_YMD");
				sRepSql.Append("     ELSE T1.HHTADD_YMD");
				sRepSql.Append("     END        <= :BIND_ADD_YMD_TO");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_ADD_YMD_TO";
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Add_ymd_to);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}


			// 返品理由を設定

			if (!string.IsNullOrEmpty(f01VO.Henpin_riyu) && !f01VO.Henpin_riyu.Equals(BoSystemConstant.DROPDOWNLIST_MISENTAKU))
			{
				sRepSql.Append(" AND T1.HENPIN_RIYU = :BIND_HENPIN_RIYU");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_HENPIN_RIYU";
				bindVO.Value = f01VO.Henpin_riyu;
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// スキャンコードを設定

			if (!string.IsNullOrEmpty(f01VO.Scan_cd))
			{
				sRepSql.Append(" AND T2.JAN_CD = :BIND_JAN_CD");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_JAN_CD";
				bindVO.Value = (string)f01VO.Dictionary[Td040p01Constant.DIC_SEARCH_JANCD];
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);

			}
			// 自社品番を設定

			if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn))
			{
				//// 自社品番が10桁の場合
				//if (f01VO.Old_jisya_hbn.Length == 10)
				//{
				//	sRepSql.Append(" AND T2.JAN_CD IN (");
				//	sRepSql.Append("					SELECT");
				//	sRepSql.Append("						MDMT0130.JAN_CD");
				//	sRepSql.Append("					FROM MDMT0130");
				//	sRepSql.Append("					WHERE MDMT0130.OLD_XEBIO_CD = :BIND_JISYA_HBN");
				//	sRepSql.Append("					)");

				//}
				//// 自社品番が10桁以外の場合
				//else
				//{
					sRepSql.Append(" AND T2.JISYA_HBN = :BIND_JISYA_HBN");
				//}

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_JISYA_HBN";
				bindVO.Value = (string)f01VO.Dictionary[Td040p01Constant.DIC_SEARCH_XEBIOCD];
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);

			}

			BoSystemSql.AddSql(reader, Td040p01Constant.SQL_ID_01_REP_ADD_WHERE1, sRepSql.ToString(), bindList);

			bindList = new ArrayList();
			sRepSql = new StringBuilder();

			// 回数を設定

			if (!string.IsNullOrEmpty(f01VO.Kai_su))
			{
				sRepSql.Append(" AND T3.KAISU >= :BIND_KAI_SU");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_KAI_SU";
				bindVO.Value = f01VO.Kai_su;
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);

			}

			BoSystemSql.AddSql(reader, Td040p01Constant.SQL_ID_01_REP_ADD_WHERE2, sRepSql.ToString(), bindList);

			#endregion

		}

		#endregion
	}
}
