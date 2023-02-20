using com.xebio.bo.Tg040p01.Constant;
using com.xebio.bo.Tg040p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01012;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.V01000.V01001;
using Common.Business.V01000.V01003;
using Common.Business.V01000.V01004;
using Common.Business.V01000.V01005;
using Common.Business.V03000.V03001;
using Common.Business.V03000.V03004;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace com.xebio.bo.Tg040p01.Facade
{
  /// <summary>
  /// Tg040f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tg040f01Facade : StandardBaseFacade
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
				//コネクションを取得する。
				OpenConnection(facadeContext);

				//以下に業務ロジックを記述する。

				#region 初期化
				// FormVO取得
				// 画面より情報を取得する。
				Tg040f01Form f01VO = (Tg040f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// 一覧の初期化
				m1List.ClearCacheData();
				m1List.Clear();

				// 検索条件のDictionary初期化
				f01VO.Dictionary.Clear();
				#endregion

				#region 業務チェック

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

				// 1-2 担当者コード
				//       担当者マスタを検索し、存在しない場合エラー
				if (!string.IsNullOrEmpty(f01VO.Tan_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01005Check.CheckTanto(f01VO.Tan_cd
														, facadeContext
														, string.Empty
														, null
														, "担当者"
														, new[] { "Tan_cd" }
														, null
														, null
														, null
														, 0
														, 0
														);
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Hanbaiin_nm = (string)resultHash["HANBAIIN_NM"];
					}
				}

				// 1-3 自社品番
				//       発注マスタを検索し、存在しない場合エラー
				f01VO.Maker_hbn = string.Empty;
				f01VO.Dictionary[Tg040p01Constant.DIC_SEARCH_XEBIOCD] = string.Empty;
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
						f01VO.Dictionary[Tg040p01Constant.DIC_SEARCH_XEBIOCD] = (string)resultHash["XEBIO_CD"];
						f01VO.Maker_hbn = (string)resultHash["HIN_NBR"];
					}
				}
				
				//1-4スキャンコード 存在
				//       発注マスタを検索し、存在しない場合エラー
				f01VO.Dictionary[Tg040p01Constant.DIC_SEARCH_JANCD] = string.Empty;
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
						f01VO.Dictionary[Tg040p01Constant.DIC_SEARCH_JANCD] = (string)resultHash["JAN_CD"];
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region 関連チェック
				// 2-1 日付FROM、日付TO
				//       日付ＦＲＯＭ > 日付ＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Ymd_from) && !string.IsNullOrEmpty(f01VO.Ymd_to))
				{
					V03001Check.DateFromToChk(
									f01VO.Ymd_from,
									f01VO.Ymd_to,
									facadeContext,
									"日付",
									new[] { "Ymd_from", "Ymd_to" }
									);
				}

				// 2-2 販売完了日FROM、販売完了日TO
				//       販売完了日ＦＲＯＭ > 販売完了日ＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Hanbaikanryo_ymd_from) && !string.IsNullOrEmpty(f01VO.Hanbaikanryo_ymd_to))
				{
					V03001Check.DateFromToChk(
									f01VO.Hanbaikanryo_ymd_from,
									f01VO.Hanbaikanryo_ymd_to,
									facadeContext,
									"販売完了日",
									new[] { "Hanbaikanryo_ymd_from", "Hanbaikanryo_ymd_to" }
									);
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#endregion

				#region 検索処理
				FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(Tg040p01Constant.SQL_ID_01, facadeContext.DBContext);

				// 検索条件設定
				AddWhere(f01VO, rtSeach);

				//検索結果を取得します
				rtSeach.CreateDbCommand();
				IList<Hashtable> tableList = rtSeach.Execute();
				#endregion

				#region 件数チェック
				Decimal dCnt = 0;
				if (tableList == null || tableList.Count <= 0)
				{
					// エラー
					ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
				}
				else
				{
					Hashtable resultTbl = tableList[0];
					dCnt = tableList.Count;

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
				#endregion

				#region 画面の表示
				int iCnt = 0;
				foreach (Hashtable rec in tableList)
				{
					iCnt++;
					Tg040f01M1Form f01m1VO = new Tg040f01M1Form();

					f01m1VO.M1rowno = iCnt.ToString();								// Ｍ１行NO

					// Ｍ１日付リンク
					f01m1VO.Dictionary.Add(Tg040p01Constant.DIC_M1YMD, BoSystemFormat.formatDate(rec["UPD_YMD"].ToString(), 1));

					f01m1VO.M1tm = BoSystemFormat.formatTime(rec["UPD_TM"].ToString());						// Ｍ１時間
					f01m1VO.M1hanbaiin_nm = rec["HANBAIIN_NM"].ToString();			// Ｍ１担当者名
					f01m1VO.M1stock_no = rec["STOCK_NO"].ToString();				// Ｍ１ストック№
					f01m1VO.M1suryo = rec["GOKEIYOTEI_SU"].ToString();				// Ｍ１数量
					f01m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;		// Ｍ１選択フラグ(隠し)
					f01m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;	// Ｍ１確定処理フラグ(隠し)
					f01m1VO.M1entersyoriflg = ConditionMeisaiiro_kbn.VALUE_NOMAL;	// Ｍ１明細色区分(隠し)

					// Dictionary
					f01m1VO.Dictionary.Add(Tg040p01Constant.DIC_KANRI_NO, rec["KANRI_NO"].ToString());		// [Ｍ１管理№] 
					f01m1VO.Dictionary.Add(Tg040p01Constant.DIC_TANCD, rec["UPD_TANCD"].ToString());		// [Ｍ１担当者コード] 
					f01m1VO.Dictionary.Add(Tg040p01Constant.DIC_SYORI_YMD, rec["SYORI_YMD"].ToString());	// [Ｍ１処理日付] 
					f01m1VO.Dictionary.Add(Tg040p01Constant.DIC_SYORI_TM, rec["SYORI_TM"].ToString());		// [Ｍ１処理時間] 

					// 排他ＳＱＬ
					f01m1VO.Dictionary.Add(Tg040p01Constant.DIC_UPD_YMD, rec["UPD_YMD"].ToString());	// 更新日
					f01m1VO.Dictionary.Add(Tg040p01Constant.DIC_UPD_TM, rec["UPD_TM"].ToString());		// 更新時間

					//リストオブジェクトにM1Formを追加します。
					m1List.Add(f01m1VO, true);
				}
				#endregion

				// モードNoを選択モードNoへ設定
				f01VO.Stkmodeno = f01VO.Modeno;

				// 検索条件を退避
				SearchConditionSaveCls.SearchConditionSave(f01VO);

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
		/// <param name="f01VO">Tg040f01Form</param>
		/// <param name="FindSqlResultTable">reader</param>
		/// <returns></returns>
		private void AddWhere(Tg040f01Form f01VO, FindSqlResultTable reader)
		{
			ArrayList bindList = new ArrayList();
			BindInfoVO bindVO = new BindInfoVO();
			StringBuilder sRepSql = new StringBuilder();

			#region 検索条件設定

			// 検索条件を設定 -----------

			sRepSql = new StringBuilder();

			// 店舗コード
			sRepSql.Append(" AND T1.TENPO_CD = :BIND_TENPO_CD ");

			bindVO = new BindInfoVO();
			bindVO.BindId = "BIND_TENPO_CD";
			bindVO.Value = BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd);
			bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			// 日付ＦＲＯＭ
			if (!string.IsNullOrEmpty(f01VO.Ymd_from))
			{
				sRepSql.Append("  AND T1.UPD_YMD >= :BIND_YMD_FROM ");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_YMD_FROM";
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Ymd_from);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 日付ＴＯ
			if (!string.IsNullOrEmpty(f01VO.Ymd_to))
			{
				sRepSql.Append(" AND T1.UPD_YMD <= :BIND_YMD_TO ");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_YMD_TO";
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Ymd_to);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// ストック№
			if (!string.IsNullOrEmpty(f01VO.Stock_no))
			{
				sRepSql.Append(" AND T1.STOCK_NO = :BIND_STOCK_NO ");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_STOCK_NO";
				bindVO.Value = f01VO.Stock_no;
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 担当者コード
			if (!string.IsNullOrEmpty(f01VO.Tan_cd))
			{
				sRepSql.Append(" AND T1.UPD_TANCD = :BIND_UPD_TANCD ");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_UPD_TANCD";
				bindVO.Value = BoSystemFormat.formatTantoCd(f01VO.Tan_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 旧自社品番
			if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn))
			{
				sRepSql.Append(" AND EXISTS ( ");
				sRepSql.Append(" 	SELECT	1 ");
				sRepSql.Append(" 	FROM	MDBT0021 T2 ");
				sRepSql.Append(" 	WHERE	0 = 0 ");
				sRepSql.Append("	AND T1.TENPO_CD = T2.TENPO_CD ");
				sRepSql.Append("	AND T1.KANRI_NO = T2.KANRI_NO ");
				sRepSql.Append("	AND T1.SYORI_YMD = T2.SYORI_YMD ");
				//if (f01VO.Old_jisya_hbn.Length == 10)
				//{	// ※[旧自社品番]の桁数 = 10の場合
				//	sRepSql.Append("	AND T2.JAN_CD IN ( ");
				//	sRepSql.Append("		SELECT	M2.JAN_CD ");
				//	sRepSql.Append("		FROM	MDMT0130 M2 ");
				//	sRepSql.Append("		WHERE	M2.OLD_XEBIO_CD = :BIND_OLD_XEBIO_CD ");
				//	sRepSql.Append("	) ");
				//}
				//else
				//{	// [自社品番]の桁数 = 10以外の場合
					sRepSql.Append("	AND T2.JISYA_HBN = :BIND_OLD_XEBIO_CD ");
				//}
				sRepSql.Append(" ) ");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_OLD_XEBIO_CD";
				bindVO.Value = (string)f01VO.Dictionary[Tg040p01Constant.DIC_SEARCH_XEBIOCD];
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// スキャンコード
			if (!string.IsNullOrEmpty(f01VO.Scan_cd))
			{
				sRepSql.Append(" AND EXISTS ( ");
				sRepSql.Append(" 	SELECT	1 ");
				sRepSql.Append(" 	FROM	MDBT0021 T2 ");
				sRepSql.Append(" 	WHERE	0 = 0 ");
				sRepSql.Append("	AND T1.TENPO_CD = T2.TENPO_CD ");
				sRepSql.Append("	AND T1.KANRI_NO = T2.KANRI_NO ");
				sRepSql.Append("	AND T1.SYORI_YMD = T2.SYORI_YMD ");
				sRepSql.Append("	AND T2.JAN_CD = :BIND_SCAN_CD ");
				sRepSql.Append("	) ");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SCAN_CD";
				bindVO.Value = (string)f01VO.Dictionary[Tg040p01Constant.DIC_SEARCH_JANCD];
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// [販売完了日FROM]、[販売完了日TO]いずれかが入力されていた場合
			if (!string.IsNullOrEmpty(f01VO.Hanbaikanryo_ymd_from) || !string.IsNullOrEmpty(f01VO.Hanbaikanryo_ymd_to))
			{
				sRepSql.Append(" AND EXISTS ( ");
				sRepSql.Append(" 	SELECT	1 ");
				sRepSql.Append(" 	FROM	MDBT0021 T2 ");
				sRepSql.Append(" 	WHERE	0 = 0 ");
				sRepSql.Append("	AND T1.TENPO_CD = T2.TENPO_CD ");
				sRepSql.Append("	AND T1.KANRI_NO = T2.KANRI_NO ");
				sRepSql.Append("	AND T1.SYORI_YMD = T2.SYORI_YMD ");
				sRepSql.Append("	AND T2.HANBAIKANRYO_YMD >= :BIND_HANBAIKANRYO_FROM ");
				sRepSql.Append("	AND T2.HANBAIKANRYO_YMD <= :BIND_HANBAIKANRYO_TO ");
				sRepSql.Append("	) ");

				string wkfrom = f01VO.Hanbaikanryo_ymd_from.ToString();	// 販売完了日FROM作業用
				string wkto = f01VO.Hanbaikanryo_ymd_to.ToString();		// 販売完了日TO作業用

				// [販売完了日FROM]が未入力だった場合、"0"に置き換える。
				if (string.IsNullOrEmpty(f01VO.Hanbaikanryo_ymd_from))
				{
					wkfrom = (0).ToString();
				}

				// [販売完了日TO]が未入力だった場合、"99999999"に置き換える。
				if (string.IsNullOrEmpty(f01VO.Hanbaikanryo_ymd_to))
				{
					wkto = (99999999).ToString();
				}

				// 販売完了日FROM
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_HANBAIKANRYO_FROM";
				bindVO.Value = BoSystemFormat.formatDate(wkfrom);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);

				// 販売完了日TO
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_HANBAIKANRYO_TO";
				bindVO.Value = BoSystemFormat.formatDate(wkto);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			BoSystemSql.AddSql(reader, Tg040p01Constant.SQL_ID_01_REP_ADD_WHERE, sRepSql.ToString(), bindList);
			#endregion
		}

		#endregion
	}
}
