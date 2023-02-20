using com.xebio.bo.Td050p01.Constant;
using com.xebio.bo.Td050p01.Formvo;
using com.xebio.bo.Td050p01.Util;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01012;
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
using Common.Business.V03000.V03001;
using Common.Business.V03000.V03002;
using Common.Business.V03000.V03003;
using Common.Business.V03000.V03004;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace com.xebio.bo.Td050p01.Facade
{
  /// <summary>
  /// Td050f01のFacadeクラスです
  /// 画面データのロード業務ロジックを実装します。
  /// </summary>
  public partial class Td050f01Facade : StandardBaseFacade
	{
		#region 定数を設定します
		/// <summary>;
		/// プログラムID。
		/// </summary>
		private const string PGID = "Td050p01";
		/// <summary>
		/// フォームID。
		/// </summary>
		private const string FORMID = "Td050f01";
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Td050f01Facade()
			: base()
		{
		}
		#endregion

		#region Td050f01画面データを作成する。
		/// <summary>
		/// Td050f01画面データを作成する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoLoad(IFacadeContext facadeContext)
		{
			//使用時にコメントアウトをはずす。
			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoLoad");
			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを開きます。
				OpenConnection(facadeContext);

				//以下に業務ロジックを記述する。

				//カード部を取得します。
				Td050f01Form td050f01Form = (Td050f01Form)facadeContext.FormVO;
				if (string.IsNullOrEmpty(td050f01Form.Modeno))
				{
					// システム日付取得
					SysDateVO sysDateVO = new SysDateVO();
					sysDateVO = SysdateCls.GetSysdateTime(facadeContext);
					td050f01Form.Henpin_kakutei_ymd_from = Td050p01Util.GetHenpinKakuteiYmdInit(sysDateVO);
					td050f01Form.Henpin_kakutei_ymd_to = BoSystemFormat.formatDate(sysDateVO.Sysdate);
				}

				////モデル層処理ロジックを記述してください。
				////カード部 データを取得(要実装)........

				////M1明細部のデータを作成します。
				//DoM1ListLoad(facadeContext);

			}
			catch (System.Exception ex)
			{
				//例外処理を実行する。
				ThrowException(ex, facadeContext);
			}
			finally
			{
				//コネクションを開放する。
				CloseConnection(facadeContext);
			}
			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoLoad");
		}
		#endregion
		#region M1明細部データの作成をする。
		/// <summary>
		/// M1明細部データの作成をする。
		/// 明細ID(M1)の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoM1ListLoad(IFacadeContext facadeContext)
		{
			//このメソッドは、M1の明細のデータを生成するために、
			//画面のLoad処理と改ページ処理で呼ばれます。
			//コネクションの開始・終了は呼び出しもとのメソッドで管理されます。
			//必要な処理を実装してください。
			
		}
		#endregion

		#region 検索単項目チェック
		/// <summary>
		/// ChkSelSingleItem 検索単項目チェック
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="Td050f01Form">f01VO</param>
		/// <returns>Decimal</returns>
		private void ChkSelSingleItem ( IFacadeContext facadeContext, Td050f01Form f01VO )
		{
			#region 単項目チェック
			// 1-1 ヘッダ店舗コード
			//       店舗マスタを検索し、存在しない場合エラー
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

			// 1-3 入力担当者コード
			//       担当者マスタを検索し、存在しない場合エラー
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

			// 1-4 確定担当者コード
			//       担当者マスタを検索し、存在しない場合エラー
			if (!string.IsNullOrEmpty(f01VO.Kakuteitan_cd))
			{
				Hashtable resultHash = new Hashtable();
				resultHash = V01005Check.CheckTanto(f01VO.Kakuteitan_cd
													, facadeContext
													, string.Empty
													, null
													, "確定担当者"
													, new[] { "Kakuteitan_cd" }
													, null
													, null
													, null
													, 0
													, 0
													);
				// 名称をラベルに設定
				if (resultHash != null)
				{
					f01VO.Kakuteitan_nm = (string)resultHash["HANBAIIN_NM"];
				}
			}

			// 1-5 自社品番
			//       発注マスタを検索し、存在しない場合エラー
			f01VO.Dictionary[Td050p01Constant.DIC_SEARCH_XEBIOCD] = string.Empty;
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
				Hashtable resultHash = V01003Check.CheckXebioCd(searchConditionVO, facadeContext, "自社品番", new[] { "Old_jisya_hbn" });
				// メーカー品番をラベルに設定
				if (resultHash != null)
				{
					// 自社品番をディクショナリに退避
					f01VO.Dictionary[Td050p01Constant.DIC_SEARCH_XEBIOCD] = (string)resultHash["XEBIO_CD"];
					f01VO.Maker_hbn = (string)resultHash["HIN_NBR"];
				}
			}

			// 1-6 スキャンコード
			//       発注マスタを検索し、存在しない場合エラー
			f01VO.Dictionary[Td050p01Constant.DIC_SEARCH_JANCD] = string.Empty;
			if (!string.IsNullOrEmpty(f01VO.Scan_cd))
			{
				SearchHachuVO searchConditionVO2 = new SearchHachuVO(
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
				Hashtable hs = V01004Check.CheckScanCd(searchConditionVO2, facadeContext, "スキャンコード", new[] { "Scan_cd" });
				if (hs != null)
				{
					// JANコードをディクショナリに退避
					f01VO.Dictionary[Td050p01Constant.DIC_SEARCH_JANCD] = (string)hs["JAN_CD"];
				}
			}
			#endregion

		}
		#endregion
		#region 検索関連項目チェック
		/// <summary>
		/// ChkSelSingleItem 検索関連項目チェック
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="Td050f01Form">f01VO</param>
		/// <returns>Decimal</returns>
		private void ChkSelRelatedItem ( IFacadeContext facadeContext, Td050f01Form f01VO )
		{
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


			// 2-2 指示番号FROM、指示番号TO 
			//       指示番号ＦＲＯＭ と 指示番号ＴＯの桁数が違う場合エラー
			int iErrF = 0;
			if (!string.IsNullOrEmpty(f01VO.Siji_bango_from) && !string.IsNullOrEmpty(f01VO.Siji_bango_to))
			{
				if (f01VO.Siji_bango_from.Length != f01VO.Siji_bango_to.Length)
				{
					ErrMsgCls.AddErrMsg("E194", string.Empty, facadeContext, new[] { "Siji_bango_from", "Siji_bango_to" });
					iErrF = 1;
				}

			}

			// 2-3 指示番号FROM、指示番号TO 
			//       指示番号ＦＲＯＭ > 指示番号ＴＯの場合エラー
			if (iErrF == 0)
			{
				if (!string.IsNullOrEmpty(f01VO.Siji_bango_from) && !string.IsNullOrEmpty(f01VO.Siji_bango_to))
				{
					V03002Check.CodeFromToChk(
									f01VO.Siji_bango_from,
									f01VO.Siji_bango_to,
									facadeContext,
									"指示番号",
									new[] { "Siji_bango_from", "Siji_bango_to" }
									);
				}
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

			// 2-5 返品確定日FROM、返品確定日TO
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

			// 2-6 登録日FROM、登録日TO
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
			#endregion
		}
		#endregion
		#region 件数チェック
		/// <summary>
		/// ChkCount 件数チェック
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="IList<Hashtable>">tableListcnt</param>
		/// <returns>Decimal</returns>
		private Decimal ChkCount ( IFacadeContext facadeContext, IList<Hashtable> tableListcnt )
		{
			Hashtable resultTbl = tableListcnt[0];
			Decimal dCnt = (Decimal)resultTbl["CNT"];
			if (tableListcnt == null || tableListcnt.Count <= 0)
			{
				// エラー
				ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
			}
			else
			{

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
			return dCnt;
		}
		#endregion
		#region 検索処理
		/// <summary>
		/// DoSelect 検索処理
		/// </summary>
		/// <param name="Td050f01Form">f01VO</param>
		/// <param name="IDBContext">DBContext</param>
		/// <param name="blCount">blCount</param>
		/// <returns>IList<Hashtable></returns>
		private IList<Hashtable> DoSelect ( Td050f01Form f01VO, IDBContext DBContext, bool blCount )
		{
			FindSqlResultTable rtSearch = null;
			if (blCount)
			{
				// 件数取得
				rtSearch = FindSqlUtil.CreateFindSqlResultTable(Td050p01Constant.SQL_ID_01, DBContext);
			}
			else
			{
				// 検索結果取得
				rtSearch = FindSqlUtil.CreateFindSqlResultTable(Td050p01Constant.SQL_ID_02, DBContext);
			}

			// 検索条件設定
			SetBind(f01VO, rtSearch, blCount);

			//検索結果を取得します
			rtSearch.CreateDbCommand();
			IList<Hashtable> result = rtSearch.Execute();
			BoSystemLog.logOut("SQL: " + rtSearch.LogSql);
			return result;
		}
		#endregion
		#region 検索条件設定
		/// <summary>
		/// AddWhere 検索条件設定
		/// </summary>
		/// <param name="f01VO">Td050f01Form</param>
		/// <param name="FindSqlResultTable">rtChk</param>
		/// <param name="blCount">blCount</param>
		/// <returns></returns>
		private void SetBind ( Td050f01Form f01VO, FindSqlResultTable reader, bool blCount )
		{
			ArrayList bindList = new ArrayList();
			BindInfoVO bindVO = new BindInfoVO();
			StringBuilder sRepSql = new StringBuilder();
			#region 検索条件設定
			sRepSql = new StringBuilder();

			// 店舗コードを設定
			sRepSql.Append(" AND T1.TENPO_CD = :BIND_TENPO_CD").AppendLine();

			bindVO = new BindInfoVO();
			bindVO.BindId = "BIND_TENPO_CD";
			bindVO.Value = BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd);
			bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			// 新黒フラグを設定（1:新黒）
			sRepSql.Append(" AND T1.SHINKURO_FLG = ").Append(BoSystemConstant.SHINKURO_FLG_SHINKURO).AppendLine();

			//// 伝票番号を設定
			//if (!string.IsNullOrEmpty(f01VO.Denpyo_bango_from) || !string.IsNullOrEmpty(f01VO.Denpyo_bango_to))
			//{
			//	// 伝票番号FROMを設定
			//	if (!string.IsNullOrEmpty(f01VO.Denpyo_bango_from))
			//	{
			//	}
			//}

			// 伝票番号FROMを設定
			if (!string.IsNullOrEmpty(f01VO.Denpyo_bango_from))
			{
				sRepSql.Append(" AND T1.DENPYO_BANGO >= :BIND_DENPYO_BANGO_FROM").AppendLine();

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_DENPYO_BANGO_FROM";
				bindVO.Value = BoSystemFormat.formatDenpyoNo(f01VO.Denpyo_bango_from);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 伝票番号TOを設定
			if (!string.IsNullOrEmpty(f01VO.Denpyo_bango_to))
			{
				sRepSql.Append(" AND T1.DENPYO_BANGO <= :BIND_DENPYO_BANGO_TO").AppendLine();

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_DENPYO_BANGO_TO";
				bindVO.Value = BoSystemFormat.formatDenpyoNo(f01VO.Denpyo_bango_to);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 指示番号FROMを設定

			if (!string.IsNullOrEmpty(f01VO.Siji_bango_from))
			{
				sRepSql.Append(" AND T1.SIJI_BANGO >= :BIND_SIJI_BANGO_FROM").AppendLine();

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SIJI_BANGO_FROM";
				bindVO.Value = BoSystemFormat.HenpinSijiNoGetSijino(f01VO.Siji_bango_from);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}


			// 指示番号TOを設定

			if (!string.IsNullOrEmpty(f01VO.Siji_bango_to))
			{
				sRepSql.Append(" AND T1.SIJI_BANGO <= :BIND_SIJI_BANGO_TO").AppendLine();

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SIJI_BANGO_TO";
				bindVO.Value = BoSystemFormat.HenpinSijiNoGetSijino(f01VO.Siji_bango_to);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 仕入先コードを設定

			if (!string.IsNullOrEmpty(f01VO.Siiresaki_cd))
			{
				sRepSql.Append(" AND T1.SIIRESAKI_CD = :BIND_SIIRESAKI_CD").AppendLine();

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SIIRESAKI_CD";
				bindVO.Value = BoSystemFormat.formatSiiresakiCd(f01VO.Siiresaki_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 部門FROMを設定

			if (!string.IsNullOrEmpty(f01VO.Bumon_cd_from))
			{
				sRepSql.Append(" AND T1.BUMON_CD >= :BIND_BUMON_CD_FROM").AppendLine();

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_BUMON_CD_FROM";
				bindVO.Value = BoSystemFormat.formatBumonCd(f01VO.Bumon_cd_from);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 部門TOを設定

			if (!string.IsNullOrEmpty(f01VO.Bumon_cd_to))
			{
				sRepSql.Append(" AND T1.BUMON_CD <= :BIND_BUMON_CD_TO").AppendLine();

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_BUMON_CD_TO";
				bindVO.Value = BoSystemFormat.formatBumonCd(f01VO.Bumon_cd_to);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 返品確定日FROMを設定

			if (!string.IsNullOrEmpty(f01VO.Henpin_kakutei_ymd_from))
			{
				sRepSql.Append(" AND T1.HENPIN_YMD >= :BIND_HENPIN_YMD_FROM").AppendLine();

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_HENPIN_YMD_FROM";
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Henpin_kakutei_ymd_from);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 返品確定日TOを設定

			if (!string.IsNullOrEmpty(f01VO.Henpin_kakutei_ymd_to))
			{
				sRepSql.Append(" AND T1.HENPIN_YMD <= :BIND_HENPIN_YMD_TO").AppendLine();

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_HENPIN_YMD_TO";
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Henpin_kakutei_ymd_to);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// HHT登録日FROMを設定

			if (!string.IsNullOrEmpty(f01VO.Add_ymd_from))
			{
				sRepSql.Append(" AND T1.HHTADD_YMD >= :BIND_HHTADD_YMD_FROM").AppendLine();

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_HHTADD_YMD_FROM";
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Add_ymd_from);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// HHT登録日TOを設定

			if (!string.IsNullOrEmpty(f01VO.Add_ymd_to))
			{
				sRepSql.Append(" AND T1.HHTADD_YMD <= :BIND_HHTADD_YMD_TO").AppendLine();

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_HHTADD_YMD_TO";
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Add_ymd_to);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// HHT登録担当者コードを設定

			if (!string.IsNullOrEmpty(f01VO.Nyuryokutan_cd))
			{
				sRepSql.Append(" AND T1.HHTADDTAN_CD = :BIND_INP_TANCD").AppendLine();

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_INP_TANCD";
				bindVO.Value = BoSystemFormat.formatTantoCd(f01VO.Nyuryokutan_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 更新担当者コードを設定

			if (!string.IsNullOrEmpty(f01VO.Kakuteitan_cd))
			{
				sRepSql.Append(" AND T1.UPD_TANCD = :BIND_UPD_TANCD").AppendLine();

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_UPD_TANCD";
				bindVO.Value = BoSystemFormat.formatTantoCd(f01VO.Kakuteitan_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 返品理由を設定

			if (!string.IsNullOrEmpty(f01VO.Henpin_riyu) && !f01VO.Henpin_riyu.Equals(BoSystemConstant.DROPDOWNLIST_MISENTAKU))
			{
				sRepSql.Append(" AND T1.HENPIN_RIYU = :BIND_HENPIN_RIYU").AppendLine();

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_HENPIN_RIYU";
				bindVO.Value = f01VO.Henpin_riyu;
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 旧自社品番
			if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn))
			{
				sRepSql.Append(" AND EXISTS(").AppendLine();
				sRepSql.Append(" 		SELECT 1 FROM MDRT0021 ST1").AppendLine();	// 返品確定TBL(B)
				sRepSql.Append(" 		WHERE").AppendLine();
				sRepSql.Append(" 				ST1.TENPO_CD  = T1.TENPO_CD").AppendLine();          // 店舗コード
				sRepSql.Append(" 		AND		ST1.DENPYO_BANGO = T1.DENPYO_BANGO").AppendLine();   // 伝票番号
				sRepSql.Append(" 		AND		ST1.SYORI_YMD = T1.SYORI_YMD").AppendLine();         // 処理日付

				//// 旧自社品番の桁数が10桁の場合
				//if (f01VO.Old_jisya_hbn.Length == 10)
				//{
				//	// ＪＡＮコード　IN サブクエリ?旧自社品番
				//	sRepSql.Append(" 		AND		ST1.JAN_CD    IN (SELECT SM1.JAN_CD FROM MDMT0130 SM1").AppendLine();
				//	sRepSql.Append(" 		                                           WHERE SM1.OLD_XEBIO_CD = :BIND_OLD_JISYA_HBN)").AppendLine();
				//}
				//else
				//{
					// 自社品番
					sRepSql.Append(" 		AND		ST1.JISYA_HBN    = :BIND_OLD_JISYA_HBN").AppendLine();
				//}
				sRepSql.Append(" )").AppendLine();
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_OLD_JISYA_HBN";
				bindVO.Value = (string)f01VO.Dictionary[Td050p01Constant.DIC_SEARCH_XEBIOCD];
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// スキャンコードを設定
			if (!string.IsNullOrEmpty(f01VO.Scan_cd))
			{
				sRepSql.Append(" AND EXISTS(").AppendLine();
				sRepSql.Append(" 		SELECT 1 FROM MDRT0021 ST2").AppendLine();	// 返品確定TBL(B)
				sRepSql.Append(" 		WHERE").AppendLine();
				sRepSql.Append(" 				ST2.TENPO_CD  = T1.TENPO_CD").AppendLine();          // 店舗コード
				sRepSql.Append(" 		AND		ST2.DENPYO_BANGO = T1.DENPYO_BANGO").AppendLine();   // 伝票番号
				sRepSql.Append(" 		AND		ST2.SYORI_YMD = T1.SYORI_YMD").AppendLine();         // 処理日付
				sRepSql.Append(" 		AND		ST2.JAN_CD    = :BIND_SCAN_CD").AppendLine();        // ＪＡＮコード ← スキャンコード
				sRepSql.Append(" )");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SCAN_CD";
				bindVO.Value = (string)f01VO.Dictionary[Td050p01Constant.DIC_SEARCH_JANCD];
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);

			}

			// [選択モードNo]が「訂正」の場合

			if (f01VO.Modeno.Equals(BoSystemConstant.MODE_TEISEI))
			{
				sRepSql.Append(" AND (").AppendLine();
				sRepSql.Append("         (").AppendLine();
				// 確定種別(0（通常）, 1（ﾏﾆｭｱﾙ返品）)
				sRepSql.Append("             T1.KAKUTEI_SB IN (").Append(BoSystemConstant.KAKUTEI_SB_HENPIN_TSUJO).Append(",").Append(BoSystemConstant.KAKUTEI_SB_HENPIN_MANUAL).Append(")").AppendLine();
				// 送信済みフラグ（1（送信済））
				sRepSql.Append("         AND T1.SOSINZUMI_FLG = ").Append(ConditionSosinzumi_flg.VALUE_SOSINZUMI).AppendLine();
				sRepSql.Append("         )").AppendLine();
				sRepSql.Append("      OR (").AppendLine();
				// 確定種別(2（通常訂正）, 3（ﾏﾆｭｱﾙ訂正）)
				sRepSql.Append("             T1.KAKUTEI_SB IN (").Append(BoSystemConstant.KAKUTEI_SB_HENPIN_TSUJO_TEISEI).Append(",").Append(BoSystemConstant.KAKUTEI_SB_HENPIN_MANUAL_TEISEI).Append(")").AppendLine();
				sRepSql.Append("         )").AppendLine();
				sRepSql.Append("      )").AppendLine();

			}

			// [選択モードNo]が「取消」の場合
			if (f01VO.Modeno.Equals(BoSystemConstant.MODE_DEL))
			{

				// 確定種別(2（通常訂正）, 3（ﾏﾆｭｱﾙ訂正）)
				sRepSql.Append(" AND T1.KAKUTEI_SB IN (").Append(BoSystemConstant.KAKUTEI_SB_HENPIN_TSUJO_TEISEI).Append(",").Append(BoSystemConstant.KAKUTEI_SB_HENPIN_MANUAL_TEISEI).Append(")").AppendLine();
				// 送信済みフラグ（0(未送信)）
				sRepSql.Append(" AND T1.SOSINZUMI_FLG = ").Append(ConditionSosinzumi_flg.VALUE_MISOSIN).AppendLine();
			}


			BoSystemSql.AddSql(reader, Td050p01Constant.SQL_ID_01_REP_ADD_WHERE, sRepSql.ToString(), bindList);
			#endregion

		}

		#endregion
		#region 転記処理(検索結果)
		/// <summary>
		/// DoCopy 明細転記処理
		/// </summary>
		/// <param name="IDataList">m1List</param>
		/// <param name="tableList">取得情報</param>
		public void DoCopy ( Td050f01Form f01VO, IDataList m1List, IList<Hashtable> tableList )
		{
			int iCnt = 0;
			foreach (Hashtable rec in tableList)
			{
				iCnt++;
				Td050f01M1Form f01m1VO = new Td050f01M1Form();

				#region 明細転記
				f01m1VO.M1rowno = iCnt.ToString();																	// Ｍ１行NO
				f01m1VO.M1bumon_cd_bo1 = rec["BUMON_CD"].ToString();											    // Ｍ１部門コード
				f01m1VO.M1bumonkana_nm = rec["BUMONKANA_NM"].ToString();											// Ｍ１部門カナ名
				f01m1VO.M1siiresaki_cd = rec["SIIRESAKI_CD"].ToString();											// Ｍ１仕入先コード
				f01m1VO.M1siiresaki_ryaku_nm = rec["SIIRESAKI_RYAKU_NM"].ToString();								// Ｍ１仕入先略式名称
				f01m1VO.M1burando_nm = rec["BURANDO_NMK"].ToString();												// Ｍ１ブランド名
				f01m1VO.M1henpin_kakutei_ymd = rec["HENPIN_YMD"].ToString();                                        // Ｍ１返品確定日
				f01m1VO.M1add_ymd = rec["HHTADD_YMD"].ToString();													// Ｍ１登録日

				// （返品確定TBL(H).[確定種別]が2（通常訂正）、または3（ﾏﾆｭｱﾙ訂正））、かつ返品確定TBL(H).[送信済フラグ]が0（未送信）の場合
				if (ConditionSosinzumi_flg.VALUE_MISOSIN.Equals(rec["SOSINZUMI_FLG"].ToString())
				 && (BoSystemConstant.KAKUTEI_SB_HENPIN_TSUJO_TEISEI.Equals(rec["KAKUTEI_SB"].ToString())
				   || BoSystemConstant.KAKUTEI_SB_HENPIN_MANUAL_TEISEI.Equals(rec["KAKUTEI_SB"].ToString())))
				{

					// 返品確定TBL(H).[元伝票番号]を設定
					if (string.IsNullOrEmpty(BoSystemString.ZeroToEmpty(rec["MOTODENPYO_BANGO"].ToString())))
					{
						f01m1VO.Dictionary.Add(Td050p01Constant.DIC_M1MOTODENPYO_BANGO, string.Empty);    // Ｍ１元伝リンク
					}
					else
					{
						f01m1VO.Dictionary.Add(Td050p01Constant.DIC_M1MOTODENPYO_BANGO, BoSystemFormat.formatDenpyoNo(rec["MOTODENPYO_BANGO"].ToString()));    // Ｍ１元伝リンク
					}
					// 返品確定TBL(H)（T2）.[伝票番号]を設定
					f01m1VO.M1aka_denpyo_bango = BoSystemString.ZeroToEmpty(rec["AKA_DENPYO_BANGO"].ToString());     // Ｍ１赤伝票番号
					// 返品確定TBL(H).[伝票番号]を設定
					f01m1VO.M1kuro_denpyo_bango = BoSystemString.ZeroToEmpty(rec["DENPYO_BANGO"].ToString());        // Ｍ１黒伝票番号

					f01m1VO.Dictionary.Add(Td050p01Constant.DIC_M1KURODENPYO_BANGO, BoSystemFormat.formatDenpyoNo(rec["DENPYO_BANGO"].ToString()));    // Ｍ１黒伝票番号

				}
				else
				{
					// 返品確定TBL(H).[伝票番号]を設定
					if (string.IsNullOrEmpty(BoSystemString.ZeroToEmpty(rec["DENPYO_BANGO"].ToString())))
					{
						f01m1VO.Dictionary.Add(Td050p01Constant.DIC_M1MOTODENPYO_BANGO, string.Empty);        // Ｍ１元伝リンク
					}
					else
					{
						f01m1VO.Dictionary.Add(Td050p01Constant.DIC_M1MOTODENPYO_BANGO, BoSystemFormat.formatDenpyoNo(rec["DENPYO_BANGO"].ToString()));        // Ｍ１元伝リンク
					}
					f01m1VO.M1aka_denpyo_bango = "";
					f01m1VO.M1kuro_denpyo_bango = "";
				}

				f01m1VO.M1itemsu = rec["HENPINJISSEKIGOKEI_SU"].ToString();                                        // Ｍ１数量
				f01m1VO.M1teisei_suryo = string.Empty;                                                              // Ｍ１訂正数量
				f01m1VO.M1genkakin = rec["HENPINJISSEKIGOUKEI_KIN"].ToString();                                     // Ｍ１原価金額
				f01m1VO.M1nyuryokutan_nm = rec["INP_TAN_NM"].ToString();                                            // Ｍ１入力担当者名称
				f01m1VO.M1kakuteitan_nm = rec["KAK_TAN_NM"].ToString();                                            // Ｍ１確定担当者名称
				f01m1VO.M1henpin_riyu_nm = rec["HENPIN_RIYU_NM"].ToString();										// Ｍ１返品理由名称
				f01m1VO.M1siji_bango = BoSystemString.ZeroToEmpty(rec["SIJI_BANGO"].ToString());					// Ｍ１指示番号
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

				// Dictionary
				f01m1VO.Dictionary.Add(Td050p01Constant.DIC_M1UPD_YMD, rec["UPD_YMD"].ToString());                      // 更新日
				f01m1VO.Dictionary.Add(Td050p01Constant.DIC_M1UPD_TM, rec["UPD_TM"].ToString());                        // 更新時間
				f01m1VO.Dictionary.Add(Td050p01Constant.DIC_M1SYORI_YMD, rec["SYORI_YMD"].ToString());                  // 処理日付
				f01m1VO.Dictionary.Add(Td050p01Constant.DIC_M1SYORI_TM, rec["SYORI_TM"].ToString());                    // 処理時間
				f01m1VO.Dictionary.Add(Td050p01Constant.DIC_M1KANRI_NO, rec["KANRI_NO"].ToString());                    // 管理№
				f01m1VO.Dictionary.Add(Td050p01Constant.DIC_M1KAKUTEI_SB, rec["KAKUTEI_SB"].ToString());                // 確定種別
				f01m1VO.Dictionary.Add(Td050p01Constant.DIC_M1BURANDO_CD, rec["BURANDO_CD"].ToString());                // ブランドコード
				f01m1VO.Dictionary.Add(Td050p01Constant.DIC_M1SUBSIIRESAKI_CD, rec["SUBSIIRESAKI_CD"].ToString());      // サブ仕入先コード
				f01m1VO.Dictionary.Add(Td050p01Constant.DIC_M1HENPINYOTEIGOKEI_SU, rec["HENPINYOTEIGOKEI_SU"].ToString());        // 返品予定合計数量
				f01m1VO.Dictionary.Add(Td050p01Constant.DIC_M1HENPINYOTEIGOUKEI_KIN, rec["HENPINYOTEIGOUKEI_KIN"].ToString());    // 返品予定合計金額
				f01m1VO.Dictionary.Add(Td050p01Constant.DIC_M1HENPIN_RIYU, rec["HENPIN_RIYU"].ToString());              // 返品理由
				f01m1VO.Dictionary.Add(Td050p01Constant.DIC_M1TANTOSYA_CD, rec["TANTOSYA_CD"].ToString());              // 担当者コード
				f01m1VO.Dictionary.Add(Td050p01Constant.DIC_M1HHTADDTAN_CD, rec["HHTADDTAN_CD"].ToString());            // 入力担当者コード
				f01m1VO.Dictionary.Add(Td050p01Constant.DIC_M1UPD_TANCD, rec["UPD_TANCD"].ToString());                  // 確定担当者コード
				f01m1VO.Dictionary.Add(Td050p01Constant.DIC_M1SOSINZUMI_FLG, rec["SOSINZUMI_FLG"].ToString());          // 送信済フラグ
				f01m1VO.Dictionary.Add(Td050p01Constant.DIC_M1HHTSERIAL_NO, rec["HHTSERIAL_NO"].ToString());            // HHTシリアル番号
				f01m1VO.Dictionary.Add(Td050p01Constant.DIC_M1HHTSEQUENCE_NO, rec["HHTSEQUENCE_NO"].ToString());        // HHTシーケンスNo.
				f01m1VO.Dictionary.Add(Td050p01Constant.DIC_M1BUMON_NM, rec["BUMON_NM"].ToString());                    // 部門名
				f01m1VO.Dictionary.Add(Td050p01Constant.DIC_M1BIKO, rec["BIKO"].ToString());                            // 備考

				f01m1VO.Dictionary.Add(Td050p01Constant.DIC_M1TENPO_CD, rec["TENPO_CD"].ToString());				    // 店舗コード
				#endregion

				//リストオブジェクトにM1Formを追加します。
				m1List.Add(f01m1VO, true);
			}

		}
		#endregion

		#region 行数チェック
		/// <summary>
		/// ChkRowCount 行数チェック
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="IDataList">m1List</param>
		/// <returns></returns>
		private void ChkRowCount ( IFacadeContext facadeContext, IDataList m1List )
		{
			if (m1List == null || m1List.Count <= 0)
			{
				// 確定対象がありません。
				ErrMsgCls.AddErrMsg("E140", String.Empty, facadeContext);
			}
			else
			{
				int inputflg = 0;
				foreach (Td050f01M1Form f01m1VO in m1List.ListData)
				{
					if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
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
		}
		#endregion
		#region 排他チェック
		/// <summary>
		/// ChkUpdHaita 排他チェック
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="IDataList">m1List</param>
		/// <returns></returns>
		private void ChkUpdHaita ( IFacadeContext facadeContext, IDataList m1List )
		{
			#region 排他チェック

			StringBuilder sRepSql = new StringBuilder();
			sRepSql.Append(" AND TENPO_CD = :BIND_TENPO_CD");
			sRepSql.Append(" AND DENPYO_BANGO = :BIND_DENPYO_BANGO");
			sRepSql.Append(" AND SYORI_YMD = :BIND_SYORI_YMD");
			int iCnt = 0;
			foreach (Td050f01M1Form f01m1VO in m1List.ListData)
			{

				// 対象行のみ実施
				if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
				{
					ArrayList bindList = new ArrayList();
					BindInfoVO bindVO = new BindInfoVO();

					// 店舗コード
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_TENPO_CD";
					bindVO.Value = BoSystemFormat.formatTenpoCd((string)f01m1VO.Dictionary[Td050p01Constant.DIC_M1TENPO_CD]);
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 伝票番号
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_DENPYO_BANGO";
					bindVO.Value = BoSystemFormat.formatDenpyoNo((string)f01m1VO.Dictionary[Td050p01Constant.DIC_M1MOTODENPYO_BANGO]);
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 処理日付
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_SYORI_YMD";
					bindVO.Value = (string)f01m1VO.Dictionary[Td050p01Constant.DIC_M1SYORI_YMD];
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);


					// 排他チェック
					V03003Check.CheckHaitaMaxVal(
							Convert.ToDecimal((string)f01m1VO.Dictionary[Td050p01Constant.DIC_M1UPD_YMD]),
							Convert.ToDecimal((string)f01m1VO.Dictionary[Td050p01Constant.DIC_M1UPD_TM]),
							facadeContext,
							"MDRT0020",
							sRepSql.ToString(),
							bindList,
							1,
						//new[] { "M1kanri_no" },
							null,
							f01m1VO.M1rowno,
							iCnt.ToString(),
							"M1",
							m1List.DispRow
					);
				}
				iCnt++;
			}
			#endregion
		}
		#endregion
		#region [返品確定TBL(B)]を削除する。(SQL_ID_06)
		/// <summary>
		/// [返品予定TBL(B)]を削除する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="dDenno">伝票番号</param>
		/// <returns>更新件数</returns>
		public static int Del_HenpinKakuteib ( IFacadeContext facadeContext,
									Td050f01Form f01Form,
									Td050f01M1Form f01M1Form,
									LoginInfoVO loginInfo,
									SysDateVO sysDateVO,
									decimal dDenno )
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Td050p01Constant.SQL_ID_06, facadeContext.DBContext);

			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", dDenno);
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Td050p01Constant.DIC_M1SYORI_YMD], "0")));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01M1Form.Dictionary[Td050p01Constant.DIC_M1TENPO_CD]));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion
		#region [返品確定TBL(H)]を削除する。(SQL_ID_07)
		/// <summary>
		/// [返品予定TBL(H)]を削除する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="dDenno">伝票番号</param>
		/// <returns>更新件数</returns>
		public static int Del_HenpinKakuteih ( IFacadeContext facadeContext,
									Td050f01Form f01Form,
									Td050f01M1Form f01M1Form,
									LoginInfoVO loginInfo,
									SysDateVO sysDateVO,
									decimal dDenno )
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Td050p01Constant.SQL_ID_07, facadeContext.DBContext);

			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", dDenno);
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Td050p01Constant.DIC_M1SYORI_YMD], "0")));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01M1Form.Dictionary[Td050p01Constant.DIC_M1TENPO_CD]));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion
	}
}
