using com.xebio.bo.Ta070p01.Constant;
using com.xebio.bo.Ta070p01.Formvo;
using com.xebio.bo.Ta070p01.Util;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01003;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01012;
using Common.Business.C01000.C01023;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V01000.V01001;
using Common.Business.V01000.V01003;
using Common.Business.V01000.V01004;
using Common.Business.V01000.V01010;
using Common.Business.V01000.V01011;
using Common.Business.V01000.V01012;
using Common.Business.V03000.V03001;
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

namespace com.xebio.bo.Ta070p01.Facade
{
  /// <summary>
  /// Ta070f01のFacadeクラスです
  /// 画面データのロード業務ロジックを実装します。
  /// </summary>
  public partial class Ta070f01Facade : StandardBaseFacade
	{
		#region 定数を設定します
		/// <summary>;
		/// プログラムID。
		/// </summary>
		private const string PGID = "Ta070p01";
		/// <summary>
		/// フォームID。
		/// </summary>
		private const string FORMID = "Ta070f01";
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Ta070f01Facade()
			: base()
		{
		}
		#endregion

		#region Ta070f01画面データを作成する。
		/// <summary>
		/// Ta070f01画面データを作成する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoLoad(IFacadeContext facadeContext)
		{
			//使用時にコメントアウトをはずす。
			////メソッドの開始処理を実行する。
			//StartMethod(facadeContext, this.GetType().Name + ".DoLoad");
			//try
			//{
			//	//DBコンテキストを設定する。
			//	SetDBContext(facadeContext);
			//	//コネクションを開きます。
			//	OpenConnection(facadeContext);
				
			//	//以下に業務ロジックを記述する。
				
			//	//カード部を取得します。
			//	Ta070f01Form ta070f01Form = (Ta070f01Form)facadeContext.FormVO;
				
			//	//モデル層処理ロジックを記述してください。
			//	//カード部 データを取得(要実装)........
				
			//	//M1明細部のデータを作成します。
			//	DoM1ListLoad(facadeContext);
				
			//}
			//catch (System.Exception ex)
			//{
			//	//例外処理を実行する。
			//	ThrowException(ex, facadeContext);
			//}
			//finally
			//{
			//	//コネクションを開放する。
			//	CloseConnection(facadeContext);
			//}
			////メソッドの終了処理を実行する。
			//EndMethod(facadeContext, this.GetType().Name + ".DoLoad");
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

		#region 検索入力チェック
		/// <summary>
		/// ChkSelInput 検索入力チェック
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="Ta070f01Form">f01VO</param>
		/// <param name="String">mode</param>
		/// <returns>Decimal</returns>
		private void ChkSelInput ( IFacadeContext facadeContext, Ta070f01Form f01VO, String mode )
		{
			#region 検索入力チェック
			// 検索時は、以下のチェックを行う
			if (Ta070p01Constant.CHECK_MODE_BTNSEARCH.Equals(mode))
			{
				// 1-1 部門コード及び品種コード
				//     品種が入力されていて、部門コードが入力されていない場合
				if (!string.IsNullOrEmpty(f01VO.Hinsyu_cd) && string.IsNullOrEmpty(f01VO.Bumon_cd))
				{
					ErrMsgCls.AddErrMsg("E183", string.Empty, facadeContext, new[] { "Bumon_cd", "Hinsyu_cd" });
				}
			}

			#endregion
		}
		#endregion
		#region 検索単項目チェック
		/// <summary>
		/// ChkSelSingleItem 検索単項目チェック
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="Ta070f01Form">f01VO</param>
		/// <param name="String">mode</param>
		/// <returns>Decimal</returns>
		private void ChkSelSingleItem ( IFacadeContext facadeContext, Ta070f01Form f01VO, String mode )
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

			// 検索時は、以下のチェックを行う
			if (Ta070p01Constant.CHECK_MODE_BTNSEARCH.Equals(mode))
			{

				// 1-2 部門コード
				//     部門マスタを検索し、存在しない場合エラー
				if (!string.IsNullOrEmpty(f01VO.Bumon_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01010Check.CheckBumon(f01VO.Bumon_cd
														, facadeContext
														, string.Empty
														, null
														, "部門"
														, new[] { "Bumon_cd" }
														, null
														, null
														, null
														, 0
														, 0
														);
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Bumon_nm = (string)resultHash["BUMON_NM"];
					}
				}
				// 1-3 品種コード
				//     品種マスタを検索し、存在しない場合エラー
				if (!string.IsNullOrEmpty(f01VO.Hinsyu_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01011Check.CheckHinsyu(f01VO.Bumon_cd
														, f01VO.Hinsyu_cd
														, facadeContext
														, string.Empty
														, null
														, "品種"
														, new[] { "Hinsyu_cd" }
														, null
														, null
														, null
														, 0
														, 0
														);
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Hinsyu_ryaku_nm = (string)resultHash["HINSYU_RYAKU_NM"];
					}
				}
				// 1-4 ブランドコード
				//     ブランドマスタを検索し、存在しない場合エラー
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
														, 0);
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Burando_nm_bo1 = (string)resultHash["BURANDO_NMK"];
					}
				}
				// 1-5 自社品番
				//     発注マスタを検索し、存在しない場合エラー
				f01VO.Dictionary[Ta070p01Constant.DIC_SEARCH_XEBIOCD] = string.Empty;
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
					if (resultHash != null)
					{
						// 自社品番をディクショナリに退避
						f01VO.Dictionary[Ta070p01Constant.DIC_SEARCH_XEBIOCD] = (string)resultHash["XEBIO_CD"];
						// メーカー品番をラベルに設定
						f01VO.Maker_hbn = (string)resultHash["HIN_NBR"];
					}
				}

				// 1-6 スキャンコード
				//     発注マスタを検索し、存在しない場合エラー
				f01VO.Dictionary[Ta070p01Constant.DIC_SEARCH_JANCD] = string.Empty;
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
						f01VO.Dictionary[Ta070p01Constant.DIC_SEARCH_JANCD] = (string)hs["JAN_CD"];
					}
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
		/// <param name="Ta070f01Form">f01VO</param>
		/// <param name="String">mode</param>
		/// <returns>Decimal</returns>
		private void ChkSelRelatedItem ( IFacadeContext facadeContext, Ta070f01Form f01VO, String mode )
		{
			#region 関連項目チェック
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
		/// <param name="Ta070f01Form">f01VO</param>
		/// <param name="IDBContext">DBContext</param>
		/// <param name="blCount">blCount</param>
		/// <returns>IList<Hashtable></returns>
		private IList<Hashtable> DoSelect ( Ta070f01Form f01VO, IDBContext DBContext, bool blCount )
		{
			FindSqlResultTable rtSearch = null;
			if (blCount)
			{
				// 件数取得
				rtSearch = FindSqlUtil.CreateFindSqlResultTable(Ta070p01Constant.SQL_ID_01, DBContext);
			}
			else
			{
				// 検索結果取得
				rtSearch = FindSqlUtil.CreateFindSqlResultTable(Ta070p01Constant.SQL_ID_02, DBContext);
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
		/// <param name="Ta070f01Form">f01VO</param>
		/// <param name="FindSqlResultTable">rtChk</param>
		/// <param name="blCount">blCount</param>
		/// <returns></returns>
		private void SetBind ( Ta070f01Form f01VO, FindSqlResultTable reader, bool blCount )
		{
			ArrayList bindList = new ArrayList();
			ArrayList bindList2 = new ArrayList();
			BindInfoVO bindVO = new BindInfoVO();
			StringBuilder sRepSql1 = new StringBuilder();		// 依頼用のリプレースSQL
			StringBuilder sRepSql2 = new StringBuilder();		// マスタ用のリプレースSQL
			#region 検索条件設定
			// 検索結果取得の場合
			if (!blCount)
			{
			}


			// 店舗コードを設定
			sRepSql1.Append(" AND T1.TENPO_CD = :BIND_TENPO_CD1").AppendLine();
			bindVO = new BindInfoVO();
			bindVO.BindId = "BIND_TENPO_CD1";
			bindVO.Value = BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd);
			bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
			bindList.Add(bindVO);
			sRepSql2.Append(" AND T1.TENPO_CD = :BIND_TENPO_CD2").AppendLine();
			bindVO = new BindInfoVO();
			bindVO.BindId = "BIND_TENPO_CD2";
			bindVO.Value = BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd);
			bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
			bindList2.Add(bindVO);

			// 部門コードを設定
			if (!string.IsNullOrEmpty(f01VO.Bumon_cd))
			{
				sRepSql1.Append(" AND T1.BUMON_CD = :BIND_BUMON_CD1").AppendLine();
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_BUMON_CD1";
				bindVO.Value = BoSystemFormat.formatBumonCd(f01VO.Bumon_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
				sRepSql2.Append(" AND T2.BUMON_CD = :BIND_BUMON_CD2").AppendLine();
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_BUMON_CD2";
				bindVO.Value = BoSystemFormat.formatBumonCd(f01VO.Bumon_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList2.Add(bindVO);
			}

			// 品種コードを設定
			if (!string.IsNullOrEmpty(f01VO.Hinsyu_cd))
			{
				sRepSql1.Append(" AND T1.HINSYU_CD = :BIND_HINSYU_CD1").AppendLine();
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_HINSYU_CD1";
				bindVO.Value = BoSystemFormat.formatHinsyuCd(f01VO.Hinsyu_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
				sRepSql2.Append(" AND T2.HINSYU_CD = :BIND_HINSYU_CD2").AppendLine();
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_HINSYU_CD2";
				bindVO.Value = BoSystemFormat.formatHinsyuCd(f01VO.Hinsyu_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList2.Add(bindVO);

			}

			// ブランドコードを設定
			if (!string.IsNullOrEmpty(f01VO.Burando_cd))
			{
				sRepSql1.Append(" AND T1.BURANDO_CD = :BIND_BURANDO_CD1").AppendLine();
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_BURANDO_CD1";
				bindVO.Value = BoSystemFormat.formatBrandCd(f01VO.Burando_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
				sRepSql2.Append(" AND T2.BURANDO_CD = :BIND_BURANDO_CD2").AppendLine();
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_BURANDO_CD2";
				bindVO.Value = BoSystemFormat.formatBrandCd(f01VO.Burando_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList2.Add(bindVO);
			}

			// 開始日を設定
			if (!string.IsNullOrEmpty(f01VO.Kikan))
			{
				sRepSql1.Append(" AND T1.KAISI_YMD <= :BIND_KAISI_YMD1").AppendLine();
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_KAISI_YMD1";
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Kikan);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
				sRepSql2.Append(" AND T1.KAISI_YMD <= :BIND_KAISI_YMD2").AppendLine();
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_KAISI_YMD2";
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Kikan);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList2.Add(bindVO);
			}

			// 終了日を設定
			if (!string.IsNullOrEmpty(f01VO.Kikan))
			{
				sRepSql1.Append(" AND T1.SYURYO_YMD >= :BIND_SYURYO_YMD1").AppendLine();
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SYURYO_YMD1";
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Kikan);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
				sRepSql2.Append(" AND T1.SYURYO_YMD >= :BIND_SYURYO_YMD2").AppendLine();
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SYURYO_YMD2";
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Kikan);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList2.Add(bindVO);
			}

			// 自動区分を設定
			if (!string.IsNullOrEmpty(f01VO.Jido_kbn) && !f01VO.Jido_kbn.Equals(BoSystemConstant.DROPDOWNLIST_MISENTAKU))
			{
				sRepSql1.Append(" AND T1.JIDO_KBN = :BIND_JIDO_KBN1").AppendLine();
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_JIDO_KBN1";
				bindVO.Value = f01VO.Jido_kbn;
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
				sRepSql2.Append(" AND T1.JIDO_KBN = :BIND_JIDO_KBN2").AppendLine();
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_JIDO_KBN2";
				bindVO.Value = f01VO.Jido_kbn;
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList2.Add(bindVO);
			}

			// 旧自社品番
			string xebiocd = (string)f01VO.Dictionary[Ta070p01Constant.DIC_SEARCH_XEBIOCD];
			if (!string.IsNullOrEmpty(xebiocd))
			{
				// 旧自社品番の桁数が10桁の場合
				//if (f01VO.Old_jisya_hbn.Length == 10)
				//{
				//	// ①自動定数依頼TBL検索用
				//	// ＪＡＮコード　IN サブクエリ.JANコード
				//	sRepSql1.Append(" AND T1.JAN_CD IN ( SELECT M10.JAN_CD FROM MDMT0130 M10").AppendLine();
				//	sRepSql1.Append(" 		                              WHERE M10.OLD_XEBIO_CD = :BIND_OLD_JISYA_HBN1)").AppendLine();
				//	// ②自動定数MST検索用
				//	// 旧自社品番
				//	sRepSql2.Append(" AND T2.OLD_XEBIO_CD = :BIND_OLD_JISYA_HBN2").AppendLine();
				//}
				//else
				//{
					// ①自動定数依頼TBL検索用
					// 自社品番
					sRepSql1.Append(" AND T1.JISYA_HBN = :BIND_OLD_JISYA_HBN1").AppendLine();
					// ②自動定数MST検索用
					// 自社品番
					sRepSql2.Append(" AND T2.XEBIO_CD = :BIND_OLD_JISYA_HBN2").AppendLine();
				//}
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_OLD_JISYA_HBN1";
				bindVO.Value = BoSystemFormat.formatJisyaHbn(xebiocd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_OLD_JISYA_HBN2";
				bindVO.Value = BoSystemFormat.formatJisyaHbn(xebiocd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList2.Add(bindVO);
			}

			// スキャンコードを設定
			string scancd = (string)f01VO.Dictionary[Ta070p01Constant.DIC_SEARCH_JANCD];
			if (!string.IsNullOrEmpty(scancd))
			{
				sRepSql1.Append(" AND T1.JAN_CD = :BIND_SCAN_CD1").AppendLine();
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SCAN_CD1";
				bindVO.Value = BoSystemFormat.formatJanCd(scancd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
				sRepSql2.Append(" AND T2.JAN_CD = :BIND_SCAN_CD2").AppendLine();
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SCAN_CD2";
				bindVO.Value = BoSystemFormat.formatJanCd(scancd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList2.Add(bindVO);

			}

			// 送信済みフラグを設定
			// [最新データ]が入力されている場合に条件とする。
			// Miyamoto 修正、取消モードの場合、未送信データのみ取得する START
			if (BoSystemString.Nvl(f01VO.Modeno).Equals(BoSystemConstant.MODE_UPD)
				|| BoSystemString.Nvl(f01VO.Modeno).Equals(BoSystemConstant.MODE_DEL)
				|| (BoSystemString.Nvl(f01VO.Modeno).Equals(BoSystemConstant.MODE_REF)
					&& BoSystemConstant.CHECKBOX_ON.Equals(f01VO.Saisin_data))
				)
			{
				// 送信済みフラグ（0(未送信)）
				sRepSql1.Append(" AND T1.SOSINZUMI_FLG = ").Append(ConditionSosinzumi_flg.VALUE_MISOSIN).AppendLine();
			}
			//if (BoSystemConstant.CHECKBOX_ON.Equals(f01VO.Saisin_data))
			//{
			//	// 送信済みフラグ（0(未送信)）
			//	sRepSql1.Append(" AND T1.SOSINZUMI_FLG = ").Append(ConditionSosinzumi_flg.VALUE_MISOSIN).AppendLine();
			//}
			// Miyamoto 修正、取消モードの場合、未送信データのみ取得する END


			// 検索条件の有効可否設定
			// [選択モードNO]が「修正」「削除」の場合、自動定数依頼TBLから検索する。（①のSQLで検索する）
			if (BoSystemConstant.MODE_UPD.Equals(f01VO.Modeno) || BoSystemConstant.MODE_DEL.Equals(f01VO.Modeno))
			{
				// 依頼テーブル検索を可
				BoSystemSql.AddSql(reader, Ta070p01Constant.SQL_ID_01_REP_ADD_WHERE_KAHI_IRAI, Ta070p01Constant.SERCH_YUKO_KA);
				// 依頼テーブル検索条件を設定
				BoSystemSql.AddSql(reader, Ta070p01Constant.SQL_ID_01_REP_ADD_WHERE_IRAI, sRepSql1.ToString(), bindList);
				// マスタテーブル検索を否
				BoSystemSql.AddSql(reader, Ta070p01Constant.SQL_ID_01_REP_ADD_WHERE_KAHI_MST, Ta070p01Constant.SERCH_YUKO_HI);
				// マスタテーブル検索条件を未設定
				BoSystemSql.AddSql(reader, Ta070p01Constant.SQL_ID_01_REP_ADD_WHERE_MST, "");

			}
			// [選択モードNo]が「照会」の場合、最新データの入力状態により判定
			else if (BoSystemConstant.MODE_REF.Equals(f01VO.Modeno))
			{

				// [最新データ]が入力された場合、（②のSQLで検索する）
				if(BoSystemConstant.CHECKBOX_ON.Equals(f01VO.Saisin_data))
				{
					// 依頼テーブル検索を否
					BoSystemSql.AddSql(reader, Ta070p01Constant.SQL_ID_01_REP_ADD_WHERE_KAHI_IRAI, Ta070p01Constant.SERCH_YUKO_HI);
					// 依頼テーブル検索条件を未設定
					BoSystemSql.AddSql(reader, Ta070p01Constant.SQL_ID_01_REP_ADD_WHERE_IRAI, "");
					// マスタテーブル検索を可
					BoSystemSql.AddSql(reader, Ta070p01Constant.SQL_ID_01_REP_ADD_WHERE_KAHI_MST, Ta070p01Constant.SERCH_YUKO_KA);
					// マスタテーブル検索条件を設定
					BoSystemSql.AddSql(reader, Ta070p01Constant.SQL_ID_01_REP_ADD_WHERE_MST, sRepSql2.ToString(), bindList2);

				// [最新データ]が未入力された場合、（①、②をUNION ALLしたSQLで検索する）
				} else if (BoSystemConstant.CHECKBOX_OFF.Equals(f01VO.Saisin_data)){
					// 依頼テーブル検索を可
					BoSystemSql.AddSql(reader, Ta070p01Constant.SQL_ID_01_REP_ADD_WHERE_KAHI_IRAI, Ta070p01Constant.SERCH_YUKO_KA);
					// 依頼テーブル検索条件を設定
					BoSystemSql.AddSql(reader, Ta070p01Constant.SQL_ID_01_REP_ADD_WHERE_IRAI, sRepSql1.ToString(), bindList);
					// マスタテーブル検索を可
					BoSystemSql.AddSql(reader, Ta070p01Constant.SQL_ID_01_REP_ADD_WHERE_KAHI_MST, Ta070p01Constant.SERCH_YUKO_KA);
					// マスタテーブル検索条件を設定
					BoSystemSql.AddSql(reader, Ta070p01Constant.SQL_ID_01_REP_ADD_WHERE_MST, sRepSql2.ToString(), bindList2);
				}

			}
			#endregion

		}
		#endregion
		#region 転記処理(検索結果)
		/// <summary>
		/// DoCopy 明細転記処理
		/// </summary>
		/// <param name="IDataList">m1List</param>
		/// <param name="tableList">取得情報</param>
		/// <returns></returns>
		public void DoCopy ( Ta070f01Form f01VO, IDataList m1List, IList<Hashtable> tableList )
		{
			int iCnt = 0;
			foreach (Hashtable rec in tableList)
			{
				iCnt++;
				Ta070f01M1Form f01m1VO = new Ta070f01M1Form();

				#region 明細転記
				f01m1VO.M1rowno = iCnt.ToString();																	// Ｍ１行NO
				f01m1VO.M1bumon_cd =  rec["BUMON_CD"].ToString();													// Ｍ１部門コード
				f01m1VO.M1bumonkana_nm =  rec["BUMONKANA_NM"].ToString();											// Ｍ１部門カナ名
				f01m1VO.M1hinsyu_ryaku_nm =  rec["HINSYU_RYAKU_NM"].ToString();										// Ｍ１品種略名称
				f01m1VO.M1burando_nm_bo1 =  rec["BURANDO_NMK"].ToString();											// Ｍ１ブランド名＿ＢＯ１
				f01m1VO.M1maker_hbn =  rec["HIN_NBR"].ToString();													// Ｍ１メーカー品番
				f01m1VO.M1jisya_hbn =  rec["XEBIO_CD"].ToString();													// Ｍ１自社品番
				f01m1VO.M1syohin_zokusei =  rec["SYOHIN_ZOKUSEI"].ToString();										// Ｍ１商品属性
				f01m1VO.M1iro_nm =  rec["IRO_NM"].ToString();														// Ｍ１色
				f01m1VO.M1size_nm =  rec["SIZE_NM"].ToString();														// Ｍ１サイズ
				f01m1VO.M1scan_cd =  rec["JAN_CD"].ToString();														// Ｍ１スキャンコード
				f01m1VO.M1syonmk =  rec["SYONMK"].ToString();														// Ｍ１商品名(カナ)
				f01m1VO.M1kaisi_ymd =  rec["KAISI_YMD"].ToString();													// Ｍ１開始日
				f01m1VO.M1syuryo_ymd =  rec["SYURYO_YMD"].ToString();												// Ｍ１終了日
				f01m1VO.M1hattyuptn_kbn = rec["HATTYUPTN_NM"].ToString();											// Ｍ１発注パターン
				f01m1VO.M1jido_kbnnm = rec["JIDO_KBN_NM"].ToString();												// Ｍ１自動区分名称
				f01m1VO.M1uriage_su = rec["URI_SU"].ToString();														// Ｍ１売上数
				f01m1VO.M1genzaisettei_su =  rec["GENZAISETTEI_SU"].ToString();										// Ｍ１現在設定数
				f01m1VO.M1lot_su =  rec["LOT_SU"].ToString();														// Ｍ１ロット数
				f01m1VO.M1henko_irai_su =  BoSystemString.Nvl(rec["IRAI_SU"].ToString());							// Ｍ１変更依頼数量
				f01m1VO.M1irairiyu_cd =  rec["IRAIRIYU_CD"].ToString();												// Ｍ１依頼理由コード
				f01m1VO.M1hanbaiin_nm = rec["JIDOTESU_UPD_TANNM"].ToString();										// Ｍ１担当者名
				f01m1VO.M1add_ymd = BoSystemString.RightB(rec["ADD_YMD"].ToString(),6);								// Ｍ１登録日
				f01m1VO.M1honbutenpokbnnm = rec["ADD_KBN_NM"].ToString();											// Ｍ１本部店舗区分名称
				f01m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;											// Ｍ１選択フラグ(隠し)
				f01m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;										// Ｍ１確定処理フラグ(隠し)
				if (ConditionSosinzumi_flg.VALUE_SOSINZUMI.Equals(rec["SOSINZUMI_FLG"].ToString()))
				{
					f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_SOSINZUMI;									// Ｍ１明細色区分(隠し)
				}
				else
				{

					string jancd = (string)f01VO.Dictionary[Ta070p01Constant.DIC_SEARCH_JANCD];
					string xebiocd = (string)f01VO.Dictionary[Ta070p01Constant.DIC_SEARCH_XEBIOCD];
					if (jancd.Equals(f01m1VO.M1scan_cd) || xebiocd.Equals(f01m1VO.M1jisya_hbn))
					{
						// 一覧画面で入力されたスキャンコード、自社品番が一致する場合、背景色変更
						f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_SHOHIN_SHITEI;							// Ｍ１明細色区分(隠し)
					}
					else
					{
						f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;									// Ｍ１明細色区分(隠し)
					}
				}

				// Dictionary
				f01m1VO.Dictionary.Add(Ta070p01Constant.DIC_M1TENPO_CD, rec["TENPO_CD"].ToString());				// 店舗コード
				f01m1VO.Dictionary.Add(Ta070p01Constant.DIC_M1UPD_YMD, rec["UPD_YMD"].ToString());					// 更新日
				f01m1VO.Dictionary.Add(Ta070p01Constant.DIC_M1UPD_TM, rec["UPD_TM"].ToString());					// 更新時間
				f01m1VO.Dictionary.Add(Ta070p01Constant.DIC_M1SYORI_YMD, rec["SYORI_YMD"].ToString());				// 処理日付
				f01m1VO.Dictionary.Add(Ta070p01Constant.DIC_M1SYORI_TM, rec["SYORI_TM"].ToString());				// 処理時間
				#endregion

				//リストオブジェクトにM1Formを追加します。
				m1List.Add(f01m1VO, true);
			}

		}
		#endregion
		#region 転記処理(発注マスタ)
		/// <summary>
		/// DoCopy 明細転記処理
		/// </summary>
		/// <param name="IDataList">m1List</param>
		/// <param name="Hashtable">取得情報</param>
		/// <param name="string">店舗コード</param>
		/// <param name="bool">サイズ選択フラグ</param>
		/// <returns></returns>
		public void DoShohinCopy ( Ta070f01M1Form f01m1VO, Hashtable syohinData, string TenpoCd, bool blSize)
		{
			// 発注マスタ検索値をフォームビーン再設定
			f01m1VO.M1bumon_cd = (string)syohinData["BUMON_CD"];													// Ｍ１部門コード
			f01m1VO.M1bumonkana_nm = (string)syohinData["BUMONKANA_NM"];											// Ｍ１部門カナ名
			f01m1VO.M1hinsyu_ryaku_nm = (string)syohinData["HINSYU_RYAKU_NM"];										// Ｍ１品種略名称
			f01m1VO.M1burando_nm_bo1 = (string)syohinData["BURANDO_NMK"];											// Ｍ１ブランド名＿ＢＯ１
			f01m1VO.M1maker_hbn = (string)syohinData["HIN_NBR"];													// Ｍ１メーカー品番
			f01m1VO.M1jisya_hbn = (string)syohinData["XEBIO_CD"];													// Ｍ１自社品番
			f01m1VO.M1syohin_zokusei = Ta070p01Util.HashContains(syohinData, "SYOHIN_ZOKUSEI");						// Ｍ１商品属性
			f01m1VO.M1iro_nm = (string)syohinData["IRO_NM"];														// Ｍ１色
			f01m1VO.M1size_nm = (string)syohinData["SIZE_NM"];														// Ｍ１サイズ
			f01m1VO.M1scan_cd = (string)syohinData["JAN_CD"];														// Ｍ１スキャンコード
			f01m1VO.M1syonmk = (string)syohinData["SYONMK"];														// Ｍ１商品名(カナ)
			//f01m1VO.M1kaisi_ymd =  (decimal)syohinData["JIDOTESU_KAISI_YMD"].ToString();							// Ｍ１開始日	←　自動定数開始日
			//f01m1VO.M1syuryo_ymd =  (decimal)syohinData["JIDOTESU_SYURYO_YMD"].ToString();						// Ｍ１終了日	←　自動定数終了日
			f01m1VO.M1hattyuptn_kbn = Ta070p01Util.HashContains(syohinData, "HATTYUPTN_NM");						// Ｍ１発注パターン区分名
			f01m1VO.M1jido_kbnnm = Ta070p01Util.HashContains(syohinData, "JIDO_KBN_NM");							// Ｍ１自動区分名称
			f01m1VO.M1uriage_su = Ta070p01Util.HashContainsDec(syohinData, "URI_SU");								// Ｍ１売上数	←　売上実績数
			f01m1VO.M1genzaisettei_su = Ta070p01Util.HashContainsDec(syohinData, "JIDO_SU");						// Ｍ１現在設定数	←　自動定数
			f01m1VO.M1lot_su = Ta070p01Util.HashContainsDec(syohinData, "LOT_SU");									// Ｍ１ロット数
			f01m1VO.M1add_ymd = Ta070p01Util.RightB(Ta070p01Util.HashContainsDec(syohinData, "JIDOTESU_UPD_YMD"), 6);	// Ｍ１登録日	←　自動定数マスタ 更新日
			f01m1VO.M1hanbaiin_nm = Ta070p01Util.HashContains(syohinData, "JIDOTESU_UPD_TANNM");					// Ｍ１担当者名
			f01m1VO.M1honbutenpokbnnm = Ta070p01Util.HashContains(syohinData, "JIDOTESU_ADD_NM");					// Ｍ１本部店舗区分名称		← 登録区分名

			// 更新用
			f01m1VO.Dictionary[Ta070p01Constant.DIC_M1TENPO_CD] = TenpoCd;															// 店舗コード
			f01m1VO.Dictionary[Ta070p01Constant.DIC_M1HINSYU_CD] = (Convert.ToDecimal(syohinData["HINSYU_CD"]).ToString());					// 品種コード
			f01m1VO.Dictionary[Ta070p01Constant.DIC_M1BURANDO_CD] = (string)syohinData["BURANDO_CD"];								// ブランドコード
			f01m1VO.Dictionary[Ta070p01Constant.DIC_M1IRO_CD] = (string)syohinData["MAKERCOLOR_CD"];								// 色コード
			f01m1VO.Dictionary[Ta070p01Constant.DIC_M1SIZE_CD] = (string)syohinData["SIZE_CD"];										// サイズコード
			f01m1VO.Dictionary[Ta070p01Constant.DIC_M1SYOHIN_CD] = (string)syohinData["SYOHIN_CD"];									// 商品コード
			f01m1VO.Dictionary[Ta070p01Constant.DIC_M1GENKA] = (Convert.ToDecimal(syohinData["GENKA"]).ToString());							// 原単価
			f01m1VO.Dictionary[Ta070p01Constant.DIC_M1HATTYUPTN_KBN] = Ta070p01Util.HashContainsDec(syohinData, "HATTYUPTN_KBN");	// 発注パターン区分
			f01m1VO.Dictionary[Ta070p01Constant.DIC_M1JIDO_KBN] = Ta070p01Util.HashContainsDec(syohinData, "JIDO_KBN");				// 自動区分
			f01m1VO.Dictionary[Ta070p01Constant.DIC_M1MOTOMIYASYOHIN_FLG] = Ta070p01Util.HashContainsDec(syohinData, "MOTOMIYASYOHIN_FLG");	// 本宮商品フラグ

			// チェック用
			f01m1VO.Dictionary[Ta070p01Constant.DIC_M1HANBAIKANRYO_YMD] = (Convert.ToDecimal(syohinData["HANBAIKANRYO_YMD"]).ToString());				// 販売完了日
			f01m1VO.Dictionary[Ta070p01Constant.DIC_M1KANOUSUGOE_FLG] = (Convert.ToDecimal(syohinData["KANOUSUGOE_KANOUTORIHIKI_FLG"]).ToString());	// 可能数越可能取引フラグ
			f01m1VO.Dictionary[Ta070p01Constant.DIC_M1JIDOHATTYUKANO_FLG] = (Convert.ToDecimal(syohinData["JIDOHATTYUKANO_FLG"]).ToString());			// 自動発注可能フラグチェック
			f01m1VO.Dictionary[Ta070p01Constant.DIC_M1HAIBUNKANO_SU] = (Convert.ToDecimal(syohinData["HAIBUNKANO_SU"]).ToString());					// 配分可能数チェック

			if (blSize)
			{

				f01m1VO.M1henko_irai_su = Ta070p01Util.HashContains(syohinData, OpenTm040p01Cls.COLUMN_INPUT_SURYO);		// Ｍ１変更依頼数量
				f01m1VO.M1kaisi_ymd = Ta070p01Util.HashContainsDec(syohinData, "JIDOTESU_KAISI_YMD");						// Ｍ１開始日
				f01m1VO.M1syuryo_ymd = Ta070p01Util.HashContainsDec(syohinData, "JIDOTESU_SYURYO_YMD");						// Ｍ１終了日

				f01m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;											// Ｍ１選択フラグ(隠し)
				f01m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_ARI;										// Ｍ１確定処理フラグ(隠し)
				f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;											// Ｍ１明細色区分(隠し)
			}
		}
		#endregion
		#region 検索条件クリア
		/// <summary>
		/// ClearSeachItem 検索条件クリア
		/// </summary>
		/// <param name="Ta070f01Form">f01VO</param>
		/// <param name="Hashtable">取得情報</param>
		/// <param name="string">店舗コード</param>
		/// <param name="bool">サイズ選択フラグ</param>
		/// <returns></returns>
		public void ClearSeachItem ( Ta070f01Form f01VO)
		{
			// 検索項目の初期化
			f01VO.Bumon_cd = "";					// 部門コード
			f01VO.Bumon_nm = "";					// 部門名
			f01VO.Hinsyu_cd = "";					// 品種コード
			f01VO.Hinsyu_ryaku_nm = "";				// 品種略名称
			f01VO.Burando_cd = "";					// ブランドコード
			f01VO.Burando_nm_bo1 = "";				// ブランド名＿ＢＯ１
			f01VO.Kikan = "";						// 期間
			f01VO.Jido_kbn = "";					// 自動区分
			f01VO.Saisin_data = "";					// 最新データ
			f01VO.Old_jisya_hbn = "";				// 旧自社品番
			f01VO.Maker_hbn = "";					// メーカー品番
			f01VO.Scan_cd = "";						// スキャンコード
		}
		#endregion
		#region 行数チェック
		/// <summary>
		/// ChkRowCount 行数チェック
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="IDataList">m1List</param>
		/// <param name="string">Modeno</param>
		/// <returns></returns>
		private void ChkRowCount ( IFacadeContext facadeContext, IDataList m1List, string Modeno )
		{
			int inputflg = 0;
			// [選択モードNo]が「新規作成」の場合、確定処理チェック
			if (BoSystemConstant.MODE_INSERT.Equals(Modeno))
			{
				foreach (Ta070f01M1Form f01m1VO in m1List.ListData)
				{
					// スキャンコードが入力されている場合
					if (!string.IsNullOrEmpty(f01m1VO.M1scan_cd))
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
			// [選択モードNo]が「修正」の場合、確定処理チェック 
			else if (BoSystemConstant.MODE_UPD.Equals(Modeno))
			{
				foreach (Ta070f01M1Form f01m1VO in m1List.ListData)
				{
					// 確定処理フラグがONの場合
					if (f01m1VO.M1entersyoriflg.Equals(ConditionKakuteisyori_flg.VALUE_ARI))
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
			// [選択モードNo]が「取消」の場合、選択行数チェック
			else if (BoSystemConstant.MODE_DEL.Equals(Modeno))
			{
				foreach (Ta070f01M1Form f02m1VO in m1List.ListData)
				{
					if (f02m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
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
		#region 明細行数チェック
		/// <summary>
		/// ChkDetailCount 明細行数チェック
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="Decimal">dCnt</param>
		/// <returns>Decimal</returns>
		private void ChkDetailCount ( IFacadeContext facadeContext, Decimal cnt )
		{
			// コンフィグファイルより最大件数を取得
			Decimal dCnt = GetMaxCntCls.GetMaxCnt(facadeContext.CommandInfo.FormId.ToUpper());

			if (cnt > dCnt)
			{
				// 最大件数を超えている場合、エラーとする。
				ErrMsgCls.AddErrMsg("E147", dCnt.ToString(), facadeContext);
			}
		}
		#endregion
		#region 更新入力値チェック
		/// <summary>
		/// ChkUpdInput 更新入力値チェック
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="Ta070f01Form">f01VO</param>
		/// <param name="IDataList">m1List</param>
		/// <param name="SysDateVO">sysDateVO</param>
		/// <returns>Decimal</returns>
		private void ChkUpdInput ( IFacadeContext facadeContext, Ta070f01Form f01VO, IDataList m1List, SysDateVO sysDateVO )
		{
			// [選択モードNo]が「取消」の場合は、処理しない。
			if (BoSystemConstant.MODE_DEL.Equals(f01VO.Stkmodeno))
			{
				return;
			}
			#region 入力値チェック
			int iCnt = 0;
			foreach (Ta070f01M1Form f01m1VO in m1List.ListData)
			{
				bool meisaiErr = false;
				// 新規作成の場合はスキャンコード入力時、修正の場合は確定処理フラグがONの場合
				if ((f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_INSERT) && !string.IsNullOrEmpty(f01m1VO.M1scan_cd))
					|| (f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_UPD) && f01m1VO.M1entersyoriflg.Equals(ConditionKakuteisyori_flg.VALUE_ARI)))
				{
					// 2-1 Ｍ１スキャンコード
					//     対象行が未入力の場合、エラー
					if (!meisaiErr && string.IsNullOrEmpty(f01m1VO.M1scan_cd))
					{
						meisaiErr = true;
						ErrMsgCls.AddErrMsg("E121", "スキャンコード", facadeContext, new[] { "M1scan_cd" }
							, f01m1VO.M1rowno, iCnt.ToString(), "M1", m1List.DispRow);

					}
					// 2-2 Ｍ１開始日
					//     対象行が未入力の場合、エラー
					if (!meisaiErr && string.IsNullOrEmpty(f01m1VO.M1kaisi_ymd))
					{
						meisaiErr = true;
						ErrMsgCls.AddErrMsg("E121", "開始日", facadeContext, new[] { "M1kaisi_ymd" }
							, f01m1VO.M1rowno, iCnt.ToString(), "M1", m1List.DispRow);

					}
					// 2-3 Ｍ１終了日
					//     対象行が未入力の場合、エラー
					if (!meisaiErr && string.IsNullOrEmpty(f01m1VO.M1syuryo_ymd))
					{
						meisaiErr = true;
						ErrMsgCls.AddErrMsg("E121", "終了日", facadeContext, new[] { "M1syuryo_ymd" }
							, f01m1VO.M1rowno, iCnt.ToString(), "M1", m1List.DispRow);

					}
					// 2-4 Ｍ１変更依頼数量
					//     対象行が未入力の場合、エラー
					if (!meisaiErr && string.IsNullOrEmpty(f01m1VO.M1henko_irai_su))
					{
						meisaiErr = true;
						ErrMsgCls.AddErrMsg("E121", "変更依頼", facadeContext, new[] { "M1henko_irai_su" }
							, f01m1VO.M1rowno, iCnt.ToString(), "M1", m1List.DispRow);

					}
					// 2-5 Ｍ１依頼理由コード
					//     対象行が未入力の場合、エラー
					if (!meisaiErr && f01m1VO.M1irairiyu_cd.Equals(BoSystemConstant.DROPDOWNLIST_MISENTAKU))
					{
						meisaiErr = true;
						ErrMsgCls.AddErrMsg("E121", "依頼理由", facadeContext, new[] { "M1irairiyu_cd" }
							, f01m1VO.M1rowno, iCnt.ToString(), "M1", m1List.DispRow);

					}
				}
				iCnt++;
			}
			#endregion
		}
		#endregion
		#region 更新マスタチェック
		/// <summary>
		/// ChkUpdMst 更新マスタチェック
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="Ta070f01Form">f01VO</param>
		/// <param name="IDataList">m1List</param>
		/// <param name="SysDateVO">sysDateVO</param>
		/// <returns>bool(true:警告あり、false:警告なし)</returns>
		private void ChkUpdMst ( IFacadeContext facadeContext, Ta070f01Form f01VO, IDataList m1List, SysDateVO sysDateVO )
		{
			// [選択モードNo]が「取消」の場合は、処理しない。
			if (BoSystemConstant.MODE_DEL.Equals(f01VO.Stkmodeno))
			{
				return;
			}
			#region 単項目チェック
			int iCnt = 0;
			string TenpoCd = f01VO.Head_tenpo_cd;
			foreach (Ta070f01M1Form f01m1VO in m1List.ListData)
			{
				// 新規作成の場合はスキャンコード入力時、修正の場合は確定処理フラグがONの場合
				if ((f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_INSERT) && !string.IsNullOrEmpty(f01m1VO.M1scan_cd))
					|| (f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_UPD) && f01m1VO.M1entersyoriflg.Equals(ConditionKakuteisyori_flg.VALUE_ARI)))
				{
					bool meisaiErr = false;
					// 店舗コードが未設定の場合（新規作成の場合）
					if (!string.IsNullOrEmpty((string)f01m1VO.Dictionary[Ta070p01Constant.DIC_M1TENPO_CD]))
					{
						TenpoCd = BoSystemFormat.formatTenpoCd((string)f01m1VO.Dictionary[Ta070p01Constant.DIC_M1TENPO_CD]);
					}

					#region Ｍ１スキャンコード
					// 3-1 Ｍ１スキャンコード
					//     発注MSTに存在しない場合、エラー
					SearchHachuVO searchConditionVO = new SearchHachuVO(
						f01m1VO.M1scan_cd,		// スキャンコード
						TenpoCd,				// 店舗コード
						0,						// 店別単価マスタ 検索フラグ 0:検索しない 1:検索する
						0,						// 売変 検索フラグ 0:検索しない 1:検索する
						0,						// 店在庫 検索フラグ 0:検索しない 1:検索する
						0,						// 入荷予定数 検索フラグ 0:検索しない 1:検索する
						1,						// 売上実績数 検索フラグ 0:検索しない 1:検索する
						0,						// 依頼集計数(補充) 検索フラグ 0:検索しない 1:検索する
						0,						// 依頼集計数(単品) 検索フラグ 0:検索しない 1:検索する
						0,						// 指示検索 検索フラグ 0:検索しない 1:出荷指示、2:返品指示
						string.Empty,			// 指示NO（移動出荷マニュアル、返品マニュアル用）
						string.Empty,			// 出荷会社コード（移動出荷マニュアル)
						string.Empty,			// 入荷会社コード（移動出荷マニュアル)
						string.Empty			// 指示店舗コード（移動出荷マニュアル、返品マニュアル用）
					);

					Hashtable syohinData = V01004Check.CheckScanCd(
														searchConditionVO,
														facadeContext,
														"スキャンコード",
														new[] { "M1scan_cd" },
														f01m1VO.M1rowno,
														iCnt.ToString(),
														"M1",
														m1List.DispRow
												);
					if (syohinData != null)
					{
						// 発注マスタ情報設定
						DoShohinCopy(f01m1VO, syohinData, TenpoCd, false);
					}
					else
					{
						meisaiErr = true;
					}
					// 3-2 Ｍ１スキャンコード
					//     原単価がマイナスの商品はエラー
					if(!meisaiErr
					&& Convert.ToDecimal(BoSystemString.Nvl((string)f01m1VO.Dictionary[Ta070p01Constant.DIC_M1GENKA],"0")) < 0 )
					{
						ErrMsgCls.AddErrMsg("E146", String.Empty, facadeContext, new[] { "M1scan_cd" }
							, f01m1VO.M1rowno, iCnt.ToString(), "M1", m1List.DispRow);
						meisaiErr = true;
					}
					// 3-3 Ｍ１スキャンコード
					//     販売完了日チェック
					//     [販売完了日]＜システム日付の場合はエラー
					if (!meisaiErr)
					{
						// [本宮商品フラグ]が"2"か"4"の場合のみ
						if (Convert.ToDecimal(BoSystemString.Nvl((string)f01m1VO.Dictionary[Ta070p01Constant.DIC_M1MOTOMIYASYOHIN_FLG], "0")) == Ta070p01Constant.CHECK_MOTOMIYASYOHIN_FLG1
						 || Convert.ToDecimal(BoSystemString.Nvl((string)f01m1VO.Dictionary[Ta070p01Constant.DIC_M1MOTOMIYASYOHIN_FLG], "0")) == Ta070p01Constant.CHECK_MOTOMIYASYOHIN_FLG2)
						{
							if (Convert.ToDecimal(BoSystemFormat.formatDate((string)f01m1VO.Dictionary[Ta070p01Constant.DIC_M1HANBAIKANRYO_YMD])) < sysDateVO.Sysdate)
							{
								ErrMsgCls.AddErrMsg("E182", String.Empty, facadeContext, new[] { "M1scan_cd" }
								, f01m1VO.M1rowno, iCnt.ToString(), "M1", m1List.DispRow);
								meisaiErr = true;
							}
						}
					}
					// 3-4 Ｍ１スキャンコード
					//     自動発注可能フラグチェック
					//     [自動発注可能フラグ]＝0（不可）の場合、エラー
					if (!meisaiErr)
					{
						if (Convert.ToDecimal(BoSystemString.Nvl((string)f01m1VO.Dictionary[Ta070p01Constant.DIC_M1JIDOHATTYUKANO_FLG], "0")) == Ta070p01Constant.FLG_OFF)
						{
							ErrMsgCls.AddErrMsg("E151", String.Empty, facadeContext, new[] { "M1scan_cd" }
							, f01m1VO.M1rowno, iCnt.ToString(), "M1", m1List.DispRow);
							meisaiErr = true;
						}
					}
					#endregion
					// 3-5 Ｍ１終了日
					//     終了日＞販売完了日の場合エラー
					if (!meisaiErr)
					{
						if (Convert.ToDecimal(BoSystemFormat.formatDate(f01m1VO .M1syuryo_ymd)) > Convert.ToDecimal(BoSystemFormat.formatDate((string)f01m1VO.Dictionary[Ta070p01Constant.DIC_M1HANBAIKANRYO_YMD])))
						{
							ErrMsgCls.AddErrMsg("E117", "終了日", facadeContext, new[] { "M1syuryo_ymd" }
							, f01m1VO.M1rowno, iCnt.ToString(), "M1", m1List.DispRow);
							meisaiErr = true;
						}
					}
				}

				iCnt++;
			}
			#endregion
		}
		#endregion
		#region 更新関連項目チェック
		/// <summary>
		/// ChkSelSingleItem 更新関連項目チェック
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="Ta070f01Form">f01VO</param>
		/// <param name="String">mode</param>
		/// <returns>Decimal</returns>
		private void ChkUpdRelatedItem ( IFacadeContext facadeContext, Ta070f01Form f01VO, IDataList m1List)
		{
			// [選択モードNo]が「取消」の場合は、処理しない。
			if (BoSystemConstant.MODE_DEL.Equals(f01VO.Stkmodeno))
			{
				return;
			}
			#region 関連項目チェック
			int iCnt = 0;
			foreach (Ta070f01M1Form f01m1VO in m1List.ListData)
			{
				bool meisaiErr = false;
				// 新規作成の場合はスキャンコード入力時、修正の場合は確定処理フラグがONの場合
				if ((f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_INSERT) && !string.IsNullOrEmpty(f01m1VO.M1scan_cd))
					|| (f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_UPD) && f01m1VO.M1entersyoriflg.Equals(ConditionKakuteisyori_flg.VALUE_ARI)))
				{
					// 4-1 Ｍ１開始日、Ｍ１終了日
					//     [Ｍ１開始日] > [Ｍ１終了日]の場合エラー
					if (V03001Check.DateFromToChk(f01m1VO.M1kaisi_ymd
											 , f01m1VO.M1syuryo_ymd
											 , facadeContext
											 , "開始日／終了日"
											 , new[] { "M1kaisi_ymd", "M1syuryo_ymd" }
											 , f01m1VO.M1rowno, iCnt.ToString(), "M1", m1List.DispRow) > 0 )
					{
						meisaiErr = true;
					}
					// 4-2 スキャンコード
					//     重複チェック
					int iCheckCnt = 0;
					if (!meisaiErr)
					{
						foreach (Ta070f01M1Form f01m1VOcheck in m1List.ListData)
						{
							if (iCheckCnt != iCnt)
							{
								if (!string.IsNullOrEmpty(f01m1VOcheck.M1scan_cd)
									&& f01m1VOcheck.M1scan_cd.Equals(f01m1VO.M1scan_cd)
									&& f01m1VOcheck.M1entersyoriflg.Equals(ConditionKakuteisyori_flg.VALUE_ARI))
								{
									meisaiErr = true;
									ErrMsgCls.AddErrMsg("E130", String.Empty, facadeContext, new[] { "M1scan_cd" }
										, f01m1VO.M1rowno, iCnt.ToString(), "M1", m1List.DispRow);
								}
							}
							iCheckCnt++;
						}
					}
				}
				iCnt++;
			}
			#endregion
		}
		#endregion
		#region 更新警告チェック
		/// <summary>
		/// ChkSelSingleItem 更新警告チェック
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="Ta070f01Form">f01VO</param>
		/// <param name="IDataList">m1List</param>
		/// <returns>bool(true:警告あり、false:警告なし)</returns>
		private bool ChkUpdWarn ( IFacadeContext facadeContext, Ta070f01Form f01VO, IDataList m1List )
		{
			bool blWorn = false;
			// [選択モードNo]が「取消」の場合は、処理しない。
			if (BoSystemConstant.MODE_DEL.Equals(f01VO.Stkmodeno))
			{
				return blWorn;
			}
			#region 単項目チェック
			int iCnt = 0;
			foreach (Ta070f01M1Form f01m1VO in m1List.ListData)
			{
				// 新規作成の場合はスキャンコード入力時、修正の場合は確定処理フラグがONの場合
				if ((f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_INSERT) && !string.IsNullOrEmpty(f01m1VO.M1scan_cd))
					|| (f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_UPD) && f01m1VO.M1entersyoriflg.Equals(ConditionKakuteisyori_flg.VALUE_ARI)))
				{
					// 3-8 Ｍ１変更依頼数量
					//     売上実績チェック
					//     [Ｍ１変更依頼数量]が、[売上実績数]の1/2を超えている場合、警告を行う。
					if (Ta070p01Util.ChkUriageIai(f01m1VO.M1uriage_su, f01m1VO.M1henko_irai_su))
					{
						InfoMsgCls.AddWarnMsg("W105", String.Empty, facadeContext, new[] { "M1uriage_su", "M1henko_irai_su" }
											, f01m1VO.M1rowno, iCnt.ToString(), "M1", m1List.DispRow);
						blWorn = true;
					}
				}

				iCnt++;
			}
			#endregion
			return blWorn;
		}
		#endregion
		#region 排他チェック
		/// <summary>
		/// ChkUpdHaita 排他チェック
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="IDataList">m1List</param>
		/// <param name="string">sModeNo</param>
		/// <returns></returns>
		private void ChkUpdHaita ( IFacadeContext facadeContext, IDataList m1List, string sModeno )
		{
			// [選択モードNo]が「新規作成」の場合は、処理しない。
			if (BoSystemConstant.MODE_INSERT.Equals(sModeno))
			{
				return;
			}

			#region 排他チェック
			StringBuilder sRepSql = new StringBuilder();
			sRepSql.Append(" AND TENPO_CD = :BIND_TENPO_CD");
			sRepSql.Append(" AND SYORI_YMD = :BIND_SYORI_YMD");
			sRepSql.Append(" AND JAN_CD = :BIND_JAN_CD");
			// 自動定数依頼TBLを設定
			String sHaitaTable = "MDOT0050";
			int iCnt = 0;
			foreach (Ta070f01M1Form f01m1VO in m1List.ListData)
			{

				// 対象行のみ実施
				// 削除の場合は、選択行
				// 修正の場合は、確定行
				if ((BoSystemConstant.MODE_DEL.Equals(sModeno) && f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
				|| (BoSystemConstant.MODE_UPD.Equals(sModeno) && f01m1VO.M1entersyoriflg.Equals(ConditionKakuteisyori_flg.VALUE_ARI)))
				{
					ArrayList bindList = new ArrayList();
					BindInfoVO bindVO = new BindInfoVO();

					// 店舗コード
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_TENPO_CD";
					bindVO.Value = BoSystemFormat.formatTenpoCd((string)f01m1VO.Dictionary[Ta070p01Constant.DIC_M1TENPO_CD]);
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 処理日付
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_SYORI_YMD";
					bindVO.Value = (string)f01m1VO.Dictionary[Ta070p01Constant.DIC_M1SYORI_YMD];
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// JANコード
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_JAN_CD";
					bindVO.Value = BoSystemFormat.formatJanCd(f01m1VO.M1scan_cd);
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 排他チェック
					V03003Check.CheckHaitaMaxVal(
							Convert.ToDecimal((string)f01m1VO.Dictionary[Ta070p01Constant.DIC_M1UPD_YMD]),
							Convert.ToDecimal((string)f01m1VO.Dictionary[Ta070p01Constant.DIC_M1UPD_TM]),
							facadeContext,
							sHaitaTable,
							sRepSql.ToString(),
							bindList,
							1,
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
		#region 自動定数依頼TBLを更新(MERGE)する。(SQL_ID_03)
		/// <summary>
		/// 自動定数依頼TBLを更新(MERGE)する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01M1Form">一覧のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="String">mode</param>
		/// <returns>更新件数</returns>
		public static int Merge_Auto ( IFacadeContext facadeContext
									, Ta070f01M1Form f01M1Form
									, LoginInfoVO loginInfo
									, SysDateVO sysDateVO
									, string sModeno
		)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Ta070p01Constant.SQL_ID_03, facadeContext.DBContext);
			// 01.店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01M1Form.Dictionary[Ta070p01Constant.DIC_M1TENPO_CD]));

			// [選択モードNo]が「新規作成」の場合
			if (BoSystemConstant.MODE_INSERT.Equals(sModeno))
			{
				// 02.処理日付
				reader.BindValue("BIND_SYORI_YMD", sysDateVO.Sysdate);
				// 03.処理時間
				reader.BindValue("BIND_SYORI_TM", sysDateVO.Systime_mili);
			}
			else
			{
				// 02.処理日付
				reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal((string)f01M1Form.Dictionary[Ta070p01Constant.DIC_M1SYORI_YMD]));
				// 03.処理時間
				reader.BindValue("BIND_SYORI_TM", Convert.ToDecimal((string)f01M1Form.Dictionary[Ta070p01Constant.DIC_M1SYORI_TM]));
			}
			// 04.開始日
			reader.BindValue("BIND_KAISI_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01M1Form.M1kaisi_ymd)));
			// 05.終了日
			reader.BindValue("BIND_SYURYO_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01M1Form.M1syuryo_ymd)));
			// 06.部門コード
			reader.BindValue("BIND_BUMON_CD", BoSystemFormat.formatBumonCd(f01M1Form.M1bumon_cd));
			// 07.品種コード
			reader.BindValue("BIND_HINSYU_CD", Convert.ToDecimal(BoSystemFormat.formatHinsyuCd((string)f01M1Form.Dictionary[Ta070p01Constant.DIC_M1HINSYU_CD])));
			// 08.ブランドコード
			reader.BindValue("BIND_BURANDO_CD", BoSystemFormat.formatBrandCd((string)f01M1Form.Dictionary[Ta070p01Constant.DIC_M1BURANDO_CD]));
			// 09.自社品番
			reader.BindValue("BIND_JISYA_HBN", BoSystemFormat.formatJisyaHbn(f01M1Form.M1jisya_hbn));
			// 10.色コード
			reader.BindValue("BIND_IRO_CD", BoSystemFormat.formatIroCd((string)f01M1Form.Dictionary[Ta070p01Constant.DIC_M1IRO_CD]));
			// 11.サイズコード
			reader.BindValue("BIND_SIZE_CD", BoSystemFormat.formatSizeCd((string)f01M1Form.Dictionary[Ta070p01Constant.DIC_M1SIZE_CD]));
			// 12.サイズ名
			reader.BindValue("BIND_SIZE_NM", f01M1Form.M1size_nm);
			// 13.ＪＡＮコード
			reader.BindValue("BIND_JAN_CD", BoSystemFormat.formatJanCd(f01M1Form.M1scan_cd));
			// 14.商品コード
			reader.BindValue("BIND_SYOHIN_CD", BoSystemString.Nvl((string)f01M1Form.Dictionary[Ta070p01Constant.DIC_M1SYOHIN_CD], "0"));
			// 15.メーカー品番
			reader.BindValue("BIND_HIN_NBR", f01M1Form.M1maker_hbn);
			// 16.商品名(カナ)	
			reader.BindValue("BIND_SYONMK", f01M1Form.M1syonmk);
			// 17.原単価
			reader.BindValue("BIND_GEN_TNK", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Ta070p01Constant.DIC_M1GENKA], "0")));
			// 18.現在設定数
			reader.BindValue("BIND_GENZAISETTEI_SU", Convert.ToDecimal(BoSystemString.Nvl(f01M1Form.M1genzaisettei_su, "0")));
			// 19.依頼数量
			reader.BindValue("BIND_IRAI_SU", Convert.ToDecimal(BoSystemString.Nvl(f01M1Form.M1henko_irai_su, "0")));
			// 20.発注パターン区分
			reader.BindValue("BIND_HATTYUPTN_KBN", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Ta070p01Constant.DIC_M1HATTYUPTN_KBN], "0")));
			// 21.自動区分
			reader.BindValue("BIND_JIDO_KBN", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Ta070p01Constant.DIC_M1JIDO_KBN], "0")));
			// 22.売上実績数
			reader.BindValue("BIND_URIAGE_SU", Convert.ToDecimal(BoSystemString.Nvl(f01M1Form.M1uriage_su, "0")));
			// 23.依頼理由コード
			reader.BindValue("BIND_IRAIRIYU_CD", Convert.ToDecimal(BoSystemString.Nvl(f01M1Form.M1irairiyu_cd, "0")));
			// 24.ロット数
			reader.BindValue("BIND_LOT_SU", Convert.ToDecimal(BoSystemString.Nvl(f01M1Form.M1lot_su, "0")));
			// 25.登録日
			reader.BindValue("BIND_ADD_YMD", sysDateVO.Sysdate);
			// 26.登録時間
			reader.BindValue("BIND_ADD_TM", sysDateVO.Systime_mili);
			// 27.登録担当者コード
			reader.BindValue("BIND_ADDTAN_CD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 28.更新日
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
			// 29.更新時間
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
			// 30.更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 31.削除日
			reader.BindValue("BIND_SAKUJYO_YMD", sysDateVO.Sysdate);
			// 32.削除フラグ
			reader.BindValue("BIND_SAKUJYO_FLG", Ta070p01Constant.FLG_OFF);						// 0（なし）
			// 33.送信依頼フラグ
			reader.BindValue("BIND_SOSINIRAI_FLG", Convert.ToDecimal(ConditionSosinirai_flg.VALUE_ARI));			// 1（送信対象）
			// 34.送信済フラグ
			reader.BindValue("BIND_SOSINZUMI_FLG", Convert.ToDecimal(ConditionSosinzumi_flg.VALUE_MISOSIN));		// 0（未送信）
			// 35.送信日
			reader.BindValue("BIND_SOSIN_YMD", 0);
			// 36.送信時間
			reader.BindValue("BIND_SOSIN_TM", 0);

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}

		#endregion
		#region 自動定数依頼TBLを削除する。(SQL_ID_04)
		/// <summary>
		/// 補充依頼確定TBL(B)更新（メッセージ区分）
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="Ta070f01M1Form">f01M1Form</param>
		/// <param name="decimal">delKbn</param>
		/// <returns>更新件数</returns>
		public static int Del_Auto ( IFacadeContext facadeContext,
									Ta070f01M1Form f01M1Form)
		{
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Ta070p01Constant.SQL_ID_04, facadeContext.DBContext);

			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01M1Form.Dictionary[Ta070p01Constant.DIC_M1TENPO_CD]));
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(BoSystemString.Nvl((string)f01M1Form.Dictionary[Ta070p01Constant.DIC_M1SYORI_YMD]))));
			// ＪＡＮコード
			reader.BindValue("BIND_JAN_CD", BoSystemFormat.formatJanCd(f01M1Form.M1scan_cd));
			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion
	}
}
