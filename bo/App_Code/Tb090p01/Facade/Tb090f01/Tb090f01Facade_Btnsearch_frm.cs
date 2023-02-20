using com.xebio.bo.Tb090p01.Constant;
using com.xebio.bo.Tb090p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01012;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.V01000.V01001;
using Common.Business.V01000.V01002;
using Common.Business.V01000.V01003;
using Common.Business.V01000.V01004;
using Common.Business.V01000.V01010;
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

namespace com.xebio.bo.Tb090p01.Facade
{
  /// <summary>
  /// Tb090f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tb090f01Facade : StandardBaseFacade
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
			//	//コネクションを取得して、トランザクションを開始する。
			//	BeginTransactionWithConnect(facadeContext);
				//コネクションを取得する。
				OpenConnection(facadeContext);
				
			//	//以下に業務ロジックを記述する。

				#region 初期化

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Tb090f01Form f01VO = (Tb090f01Form)facadeContext.FormVO;
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

				// 1-3 自社品番
				//       発注マスタを検索し、存在しない場合エラー
				f01VO.Maker_hbn = string.Empty;
				f01VO.Dictionary[Tb090p01Constant.DIC_SEARCH_XEBIOCD] = string.Empty;
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
						f01VO.Dictionary[Tb090p01Constant.DIC_SEARCH_XEBIOCD] = (string)resultHash["XEBIO_CD"];
						f01VO.Maker_hbn = (string)resultHash["HIN_NBR"];
					}
				}

				// 1-4 スキャンコード
				//       発注マスタを検索し、存在しない場合エラー
				f01VO.Dictionary[Tb090p01Constant.DIC_SEARCH_JANCD] = string.Empty;
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
						f01VO.Dictionary[Tb090p01Constant.DIC_SEARCH_JANCD] = (string)resultHash["JAN_CD"];
					}	
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

				#region 関連項目チェック

				// 2-1 元伝票番号FROM、元伝票番号TO
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

				// 2-2 入荷予定日FROM、入荷予定日TO
				//       入荷予定日ＦＲＯＭ > 入荷予定日ＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Nyukayotei_ymd_from) && !string.IsNullOrEmpty(f01VO.Nyukayotei_ymd_to))
				{
					V03001Check.DateFromToChk(
									f01VO.Nyukayotei_ymd_from,
									f01VO.Nyukayotei_ymd_to,
									facadeContext,
									"入荷予定日",
									new[] { "Nyukayotei_ymd_from", "Nyukayotei_ymd_to" }
									);
				}

				// 2-3 仕入確定日FROM、仕入確定日TO
				//       仕入確定日ＦＲＯＭ > 返品確定日ＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Siire_kakutei_ymd_from) && !string.IsNullOrEmpty(f01VO.Siire_kakutei_ymd_to))
				{
					V03001Check.DateFromToChk(
									f01VO.Siire_kakutei_ymd_from,
									f01VO.Siire_kakutei_ymd_to,
									facadeContext,
									"返品確定日",
									new[] { "Siire_kakutei_ymd_from", "Siire_kakutei_ymd_to" }
									);
				}

				// 2-4 部門コードFROM、部門コードTO
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

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#endregion

				#region 件数チェック

				FindSqlResultTable rtChk = FindSqlUtil.CreateFindSqlResultTable(Tb090p01Constant.SQL_ID_01, facadeContext.DBContext);

				#region テーブルID設定
				// テーブルIDを設定 -----------

				ArrayList bindList = new ArrayList();
				BindInfoVO bindVO = new BindInfoVO();
				StringBuilder sRepSql = new StringBuilder();
				Decimal dCnt = 0;

				sRepSql.Append("MDPT0020 T1");	// 仕入入荷確定テーブル

				BoSystemSql.AddSql(rtChk, Tb090p01Constant.SQL_ID_01_REP_TABLE_ID, sRepSql.ToString(), bindList);

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

				string sSqlId = "";

				sSqlId = Tb090p01Constant.SQL_ID_02;

				// 仕入確定テーブルから検索する。
				FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(sSqlId, facadeContext.DBContext);

				#region テーブルID設定

				// テーブルIDを設定 -----------
				BoSystemSql.AddSql(rtSeach, Tb090p01Constant.SQL_ID_01_REP_TABLE_ID, sRepSql.ToString(), bindList);

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
					Tb090f01M1Form f01m1VO = new Tb090f01M1Form();

					f01m1VO.M1rowno = iCnt.ToString();																	// Ｍ１ＮＯ
					f01m1VO.M1bumon_cd_bo = rec["BUMON_CD"].ToString();													// Ｍ１部門コード
					f01m1VO.M1bumonkana_nm = rec["BUMONKANA_NM"].ToString();											// Ｍ１部門カナ名
					f01m1VO.M1siiresaki_cd = rec["SIIRESAKI_CD"].ToString();											// Ｍ１仕入先コード
					f01m1VO.M1siiresaki_ryaku_nm = rec["SIIRESAKI_RYAKU_NM"].ToString();								// Ｍ１仕入先名称
					f01m1VO.M1nyukayotei_ymd = BoSystemFormat.formatDate(rec["SITEINOHIN_YMD"].ToString());				// Ｍ１入荷予定日
					// [確定種別]="2"OR"3"、かつ[送信済フラグ]＝"0"の場合
					if (  (  BoSystemConstant.KAKUTEI_SB_HENPIN_TSUJO_TEISEI.Equals(rec["KAKUTEI_SB"].ToString())
						  || BoSystemConstant.KAKUTEI_SB_HENPIN_MANUAL_TEISEI.Equals(rec["KAKUTEI_SB"].ToString()))
						&& BoSystemConstant.SOSINZUMI_FLG_MISOSIN.Equals(rec["SOSINZUMI_FLG"].ToString()))
					{
						f01m1VO.Dictionary.Add(Tb090p01Constant.DIC_M1MOTODENPYO_BANGO, BoSystemFormat.formatDenpyoNo(rec["MOTODENPYO_BANGO"].ToString()));
																														// Ｍ１伝票番号リンク
						f01m1VO.M1aka_denpyo_bango = rec["AKA_DENPYO_BANGO"].ToString();								// Ｍ１赤伝票番号
						f01m1VO.M1kuro_denpyo_bango = rec["DENPYO_BANGO"].ToString();									// Ｍ１黒伝票番号
					}
					else
					{
						f01m1VO.Dictionary.Add(Tb090p01Constant.DIC_M1MOTODENPYO_BANGO, BoSystemFormat.formatDenpyoNo(rec["DENPYO_BANGO"].ToString()));
																														// Ｍ１伝票番号リンク
						f01m1VO.M1aka_denpyo_bango = string.Empty;														// Ｍ１赤伝票番号
						f01m1VO.M1kuro_denpyo_bango = string.Empty;														// Ｍ１黒伝票番号

					}

					f01m1VO.M1kensu = rec["SIIREJISSEKIGOKEI_SU"].ToString();											// Ｍ１検数
					f01m1VO.M1teisei_suryo = string.Empty;																// Ｍ１訂正数
					f01m1VO.M1genkakin = rec["SIIREJISSEKIGOKEI_KIN"].ToString();										// Ｍ１原価金額
					f01m1VO.M1siire_kakutei_ymd = rec["JYURYO_YMD"].ToString();											// Ｍ１仕入確定日
					f01m1VO.M1kakuteitan_nm = rec["KAKUTEI_TANTOSHA_NM"].ToString();									// Ｍ１確定担当者名称
					f01m1VO.M1kakutei_sb_nm = rec["KAKUTEI_JYOTAI_NM"].ToString();										// Ｍ１確定種別名称
					f01m1VO.M1kyakucyu = rec["KYAKUTYU_FLG"].ToString();												// Ｍ１客注
					f01m1VO.M1negaki = rec["NEGAKIHIN_FLG"].ToString();													// Ｍ１値書

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
					f01m1VO.Dictionary.Add(Tb090p01Constant.DIC_M1DENPYO_BANGO, BoSystemFormat.formatDate(rec["DENPYO_BANGO"].ToString()));	// 伝票番号
					f01m1VO.Dictionary.Add(Tb090p01Constant.DIC_M1UPD_YMD, BoSystemFormat.formatDate(rec["UPD_YMD"].ToString()));			// 更新日
					f01m1VO.Dictionary.Add(Tb090p01Constant.DIC_M1UPD_TM, rec["UPD_TM"].ToString());										// 更新時間
					f01m1VO.Dictionary.Add(Tb090p01Constant.DIC_M1SOSINZUMI_FLG, rec["SOSINZUMI_FLG"].ToString());							// 送信済フラグ
					f01m1VO.Dictionary.Add(Tb090p01Constant.DIC_M1KAKUTEI_SB, rec["KAKUTEI_SB"].ToString());								// 確定種別
					f01m1VO.Dictionary.Add(Tb090p01Constant.DIC_M1MOTOKAKUTEI_SB, rec["MOTOKAKUTEI_SB"].ToString());						// 元確定種別
					f01m1VO.Dictionary.Add(Tb090p01Constant.DIC_M1BIKO_KB, rec["BIKO_KB"].ToString());										// 備考区分
					f01m1VO.Dictionary.Add(Tb090p01Constant.DIC_M1BIKO1, rec["BIKO1"].ToString());											// 備考１
					f01m1VO.Dictionary.Add(Tb090p01Constant.DIC_M1BIKO2, rec["BIKO2"].ToString());											// 備考２
					f01m1VO.Dictionary.Add(Tb090p01Constant.DIC_M1FIXED_TANCD, rec["UPD_TANCD"].ToString());								// 確定担当者コード
					f01m1VO.Dictionary.Add(Tb090p01Constant.DIC_M1BUMON_NM, rec["BUMON_NM"].ToString());									// 部門名

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

			//	//トランザクションをコミットする。
			//	CommitTransaction(facadeContext);
			}
			catch (System.Exception ex)
			{
			//	//トランザクションをロールバックする。
			//	RollbackTransaction(facadeContext);
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
		/// <param name="f01VO">Tb090f01Form</param>
		/// <param name="FindSqlResultTable">rtChk</param>
		/// <param name="StringBuilder">table_id</param>
		/// <param name="String">add_where_id</param>
		/// <returns></returns>
		private void AddWhere(Tb090f01Form f01VO, FindSqlResultTable reader)
		{
			ArrayList bindList = new ArrayList();
			BindInfoVO bindVO = new BindInfoVO();
			StringBuilder sRepSql = new StringBuilder();

			#region 検索条件設定

			// 検索条件を設定 -----------

			sRepSql = new StringBuilder();

			// 店舗コードを設定
			sRepSql.Append("	AND T1.TENPO_CD = :BIND_TENPO_CD");

			bindVO = new BindInfoVO();
			bindVO.BindId = "BIND_TENPO_CD";
			bindVO.Value = BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd);
			bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			// 入荷予定日FROM-TOを設定

			if (!string.IsNullOrEmpty(f01VO.Nyukayotei_ymd_from) || !string.IsNullOrEmpty(f01VO.Nyukayotei_ymd_to))
			{
				String nyukayotei_ymd_from = f01VO.Nyukayotei_ymd_from;
				String nyukayotei_ymd_to = f01VO.Nyukayotei_ymd_to;

				// 入荷予定日FROM
				if (string.IsNullOrEmpty(f01VO.Nyukayotei_ymd_from))
				{
					nyukayotei_ymd_from = "0";
				}

				// 入荷予定日TO
				if (string.IsNullOrEmpty(f01VO.Nyukayotei_ymd_to))
				{
					nyukayotei_ymd_to = "99999999";
				}

				sRepSql.Append("	AND T1.SITEINOHIN_YMD BETWEEN :BIND_SITEI_FRM AND :BIND_SITEI_TO");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SITEI_FRM";
				bindVO.Value = BoSystemFormat.formatDate(nyukayotei_ymd_from);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SITEI_TO";
				bindVO.Value = BoSystemFormat.formatDate(nyukayotei_ymd_to);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 仕入確定日FROM-TOを設定

			if (!string.IsNullOrEmpty(f01VO.Siire_kakutei_ymd_from) || !string.IsNullOrEmpty(f01VO.Siire_kakutei_ymd_to))
			{
				String siire_kakutei_ymd_from = f01VO.Siire_kakutei_ymd_from;
				String siire_kakutei_ymd_to = f01VO.Siire_kakutei_ymd_to;

				// 仕入確定日FROM
				if (string.IsNullOrEmpty(f01VO.Siire_kakutei_ymd_from))
				{
					siire_kakutei_ymd_from = "0";
				}

				// 仕入確定日TO
				if (string.IsNullOrEmpty(f01VO.Siire_kakutei_ymd_to))
				{
					siire_kakutei_ymd_to = "99999999";
				}

				sRepSql.Append("	AND T1.JYURYO_YMD BETWEEN :BIND_SIIRE_FRM AND :BIND_SIIRE_TO");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SIIRE_FRM";
				bindVO.Value = BoSystemFormat.formatDate(siire_kakutei_ymd_from);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SIIRE_TO";
				bindVO.Value = BoSystemFormat.formatDate(siire_kakutei_ymd_to);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);

			}

			// 自社品番を設定

			if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn))
			{
				sRepSql.Append("	AND EXISTS (");
				sRepSql.Append("		SELECT 1");
				sRepSql.Append("		FROM MDPT0021 T2");
				sRepSql.Append("		WHERE T2.KAKUTEI_SB = T1.KAKUTEI_SB");
				sRepSql.Append("		AND   T2.SIIRESAKI_CD = T1.SIIRESAKI_CD");
				sRepSql.Append("		AND   T2.DENPYO_BANGO = T1.DENPYO_BANGO");
				sRepSql.Append("		AND   T2.SITEINOHIN_YMD = T1.SITEINOHIN_YMD");
				sRepSql.Append("		AND   T2.TENPO_CD = T1.TENPO_CD");

				//// 自社品番が10桁の場合
				//if (f01VO.Old_jisya_hbn.Length == 10)
				//{
				//	sRepSql.Append("	AND   T2.JAN_CD IN (");
				//	sRepSql.Append("			SELECT");
				//	sRepSql.Append("				MDMT0130.JAN_CD");
				//	sRepSql.Append("			FROM MDMT0130");
				//	sRepSql.Append("			WHERE MDMT0130.OLD_XEBIO_CD = :BIND_JISYA_HBN");
				//	sRepSql.Append("		)");
				//}
				//// 自社品番が10桁以外の場合
				//else
				//{
					sRepSql.Append("	AND   T2.JISYA_HBN = :BIND_JISYA_HBN");
				//}
				sRepSql.Append("	 )");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_JISYA_HBN";
				bindVO.Value = (string)f01VO.Dictionary[Tb090p01Constant.DIC_SEARCH_XEBIOCD];
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);

			}

			// スキャンコードを設定

			if (!string.IsNullOrEmpty(f01VO.Scan_cd))
			{
				sRepSql.Append("	AND EXISTS (");
				sRepSql.Append("		SELECT 1");
				sRepSql.Append("		FROM MDPT0021 T2");
				sRepSql.Append("		WHERE T2.KAKUTEI_SB = T1.KAKUTEI_SB");
				sRepSql.Append("		AND   T2.SIIRESAKI_CD = T1.SIIRESAKI_CD");
				sRepSql.Append("		AND   T2.DENPYO_BANGO = T1.DENPYO_BANGO");
				sRepSql.Append("		AND   T2.SITEINOHIN_YMD = T1.SITEINOHIN_YMD");
				sRepSql.Append("		AND   T2.TENPO_CD = T1.TENPO_CD");
				sRepSql.Append("		AND   T2.JAN_CD = :BIND_JAN_CD");
				sRepSql.Append("	 )");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_JAN_CD";
				bindVO.Value = (string)f01VO.Dictionary[Tb090p01Constant.DIC_SEARCH_JANCD];
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);

			}

			// 元伝票番号FROM-TOを設定

			if (!string.IsNullOrEmpty(f01VO.Motodenpyo_bango_from) || !string.IsNullOrEmpty(f01VO.Motodenpyo_bango_to))
			{
				String motodenpyo_bango_from = f01VO.Motodenpyo_bango_from;
				String motodenpyo_bango_to = f01VO.Motodenpyo_bango_to;

				// 元伝票番号FROM
				if (string.IsNullOrEmpty(f01VO.Motodenpyo_bango_from))
				{
					motodenpyo_bango_from = "0";
				}

				// 元伝票番号TO
				if (string.IsNullOrEmpty(f01VO.Motodenpyo_bango_to))
				{
					motodenpyo_bango_to = "999999";
				}

				sRepSql.Append(" AND T1.DENPYO_BANGO BETWEEN :BIND_DEN_FROM AND :BIND_DEN_TO");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_DEN_FROM";
				bindVO.Value = BoSystemFormat.formatDenpyoNo(motodenpyo_bango_from);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_DEN_TO";
				bindVO.Value = BoSystemFormat.formatDenpyoNo(motodenpyo_bango_to);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);

			}

			// 仕入先コードを設定

			if (!string.IsNullOrEmpty(f01VO.Siiresaki_cd))
			{
				sRepSql.Append("	AND T1.SIIRESAKI_CD = :BIND_SIIRE_CD");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SIIRE_CD";
				bindVO.Value = BoSystemFormat.formatSiiresakiCd(f01VO.Siiresaki_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 部門FROM-TOを設定

			if (!string.IsNullOrEmpty(f01VO.Bumon_cd_from) || !string.IsNullOrEmpty(f01VO.Bumon_cd_to))
			{
				String bumon_cd_from = f01VO.Bumon_cd_from;
				String bumon_cd_to = f01VO.Bumon_cd_to;

				// 部門FROM
				if (string.IsNullOrEmpty(f01VO.Bumon_cd_from))
				{
					bumon_cd_from = "000";
				}

				// 部門TO
				if (string.IsNullOrEmpty(f01VO.Bumon_cd_to))
				{
					bumon_cd_to = "999";
				}

				sRepSql.Append("	AND T1.BUMON_CD BETWEEN :BIND_BMNCD_FRM AND :BIND_BMNCD_TO");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_BMNCD_FRM";
				bindVO.Value = BoSystemFormat.formatBumonCd(bumon_cd_from);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_BMNCD_TO";
				bindVO.Value = BoSystemFormat.formatBumonCd(bumon_cd_to);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 確定種別
			switch (f01VO.Kakutei_sb)
			{
				/* 仕入確定の場合 */
				case ConditionSiire_kakutei_jotai.VALUE_SIIRE_KAKUTEI_JOTAI1:
					sRepSql.Append(" AND T1.KAKUTEI_JYOTAI = 0");
					break;
				/* マニュアル仕入の場合 */
				case ConditionSiire_kakutei_jotai.VALUE_SIIRE_KAKUTEI_JOTAI3:
					sRepSql.Append(" AND T1.KAKUTEI_JYOTAI = 1");
					break;
				/* SCM仕入の場合 */
				case ConditionSiire_kakutei_jotai.VALUE_SIIRE_KAKUTEI_JOTAI2:
					sRepSql.Append(" AND T1.KAKUTEI_JYOTAI = 2");
					break;
				/* 訂正の場合 */
				case ConditionSiire_kakutei_jotai.VALUE_SIIRE_KAKUTEI_JOTAI4:
					sRepSql.Append(" AND T1.KAKUTEI_JYOTAI = 3");
					break;
				default:
					// 未選択
					break;
			}

			// モードが「訂正」の場合
			if (BoSystemConstant.MODE_TEISEI.Equals(f01VO.Modeno))
			{
				sRepSql.Append(" AND ((T1.KAKUTEI_SB = 0 OR T1.KAKUTEI_SB = 1 )");
				sRepSql.Append(" AND T1.SOSINZUMI_FLG = 1 ");
				sRepSql.Append(" OR ");
				sRepSql.Append("  (T1.KAKUTEI_SB = 2 OR T1.KAKUTEI_SB = 3 ))");
			}
			// 取消モードの場合の条件
			else if (BoSystemConstant.MODE_DEL.Equals(f01VO.Modeno))
			{
				sRepSql.Append(" AND (T1.KAKUTEI_SB = 2 OR T1.KAKUTEI_SB = 3 )");
				sRepSql.Append(" AND T1.SOSINZUMI_FLG = 0 ");
			}

			sRepSql.Append(" AND T1.SHINKURO_FLG = 1 ");

			BoSystemSql.AddSql(reader, Tb090p01Constant.SQL_ID_01_REP_ADD_WHERE, sRepSql.ToString(), bindList);

			#endregion

		}

		#endregion
	}
}
