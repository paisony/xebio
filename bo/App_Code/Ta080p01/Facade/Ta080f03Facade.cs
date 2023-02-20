using com.xebio.bo.Ta080p01.Constant;
using com.xebio.bo.Ta080p01.Formvo;
using com.xebio.bo.Ta080p01.Util;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01007;
using Common.Business.C01000.C01012;
using Common.Business.C99999.Constant;
using Common.Business.C99999.DbUtil;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V01000.V01003;
using Common.Business.V01000.V01004;
using Common.Business.V01000.V01005;
using Common.Business.V01000.V01012;
using Common.Business.V01000.V01015;
using Common.Business.V03000.V03001;
using Common.Business.V03000.V03002;
using Common.Business.V03000.V03003;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Model.Data;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace com.xebio.bo.Ta080p01.Facade
{
  /// <summary>
  /// Ta080f03のFacadeクラスです
  /// 画面データのロード業務ロジックを実装します。
  /// </summary>
  public partial class Ta080f03Facade : StandardBaseFacade
	{
		#region 定数を設定します
		/// <summary>;
		/// プログラムID。
		/// </summary>
		private const string PGID = "Ta080p01";
		/// <summary>
		/// フォームID。
		/// </summary>
		private const string FORMID = "Ta080f03";
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Ta080f03Facade()
			: base()
		{
		}
		#endregion

		#region Ta080f03画面データを作成する。
		/// <summary>
		/// Ta080f03画面データを作成する。
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
			//	Ta080f03Form ta080f03Form = (Ta080f03Form)facadeContext.FormVO;
				
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


		#region 検索ボタン_チェック1_マスタ存在チェック
		/// <summary>
		/// 検索ボタンチェック1 マスタ存在チェック
		/// </summary>
		/// <param name="facadeContext"></param>
		/// <param name="f03VO"></param>
		private void ChkSearch1(IFacadeContext facadeContext, Ta080f03Form f03VO)
		{
			// 1.ブランドコード
			// ブランドMSTを検索し、存在しない場合エラー
			if (!string.IsNullOrEmpty(f03VO.Burando_cd))
			{
				Hashtable resultHash = new Hashtable();
				//resultHash = V01012Check.CheckBrand(f03VO.Burando_cd, facadeContext, "ブランド", new[] { "Burando_cd" });
				resultHash = V01012Check.CheckBrand(f03VO.Burando_cd
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
					f03VO.Burando_nm = (string)resultHash["BURANDO_NM"];
				}
			}

			// 2:登録担当者コード
			// 登録担当者MSTを検索し、存在しない場合エラー
			if (!string.IsNullOrEmpty(f03VO.Tantosya_cd))
			{
				Hashtable resultHash = new Hashtable();
				resultHash = V01005Check.CheckTanto(f03VO.Tantosya_cd
													, facadeContext
													, string.Empty
													, null
													, "登録担当者"
													, new[] { "Tantosya_cd" }
													, null
													, null
													, null
													, 0
													, 0
													);
				// 名称をラベルに設定
				if (resultHash != null)
				{
					f03VO.Hanbaiin_nm = (string)resultHash["HANBAIIN_NM"];
				}
			}
			// 3:旧自社品番
			// 発注マスタを検索し、存在しない場合エラー
			if (!string.IsNullOrEmpty(f03VO.Old_jisya_hbn))
			{
				SearchHachuVO searchConditionVO = new SearchHachuVO(
						f03VO.Old_jisya_hbn,	// 自社品番
						f03VO.Head_tenpo_cd,	// 店舗コード
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
					f03VO.Dictionary[Ta080p01Constant.DIC_SEARCH_XEBIOCD] = (string)resultHash["XEBIO_CD"];
					f03VO.Maker_hbn = (string)resultHash["HIN_NBR"];
				}
			}
			// 4:スキャンコード
			// 発注マスタを検索し、存在しない場合エラー
			if (!string.IsNullOrEmpty(f03VO.Scan_cd))
			{
				SearchHachuVO searchConditionVO = new SearchHachuVO(
						f03VO.Scan_cd,			// スキャンコード
						f03VO.Head_tenpo_cd,	// 店舗コード
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
			}
		}
		#endregion

		#region 検索ボタン_チェック2_関連項目チェック
		/// <summary>
		/// 検索ボタンチェック2 関連項目チェック
		/// </summary>
		/// <param name="facadeContext"></param>
		/// <param name="f03VO"></param>
		private void ChkSearch2(IFacadeContext facadeContext, Ta080f03Form f03VO)
		{
			// 1:部門コードFROM-部門コードTO
			if (!string.IsNullOrEmpty(f03VO.Bumon_cd_from) && !string.IsNullOrEmpty(f03VO.Bumon_cd_to))
			{
				V03002Check.CodeFromToChk(
								f03VO.Bumon_cd_from,
								f03VO.Bumon_cd_to,
								facadeContext,
								"部門",
								new[] { "Bumon_cd_from", "Bumon_cd_to" }
								);
			}

			// 2:登録日FROM-登録日TO
			if (!string.IsNullOrEmpty(f03VO.Add_ymd_from) && !string.IsNullOrEmpty(f03VO.Add_ymd_to))
			{
				V03001Check.DateFromToChk(
								f03VO.Add_ymd_from,
								f03VO.Add_ymd_to,
								facadeContext,
								"登録日",
								new[] { "Add_ymd_from", "Add_ymd_to" }
								);
			}
		}
		#endregion

		#region 検索ボタン_検索処理
		private decimal[] DoSelect(IFacadeContext facadeContext, Ta080f01Form f01VO, Ta080f03Form f03VO,IDataList m1List)
		{
			BindInfoVO bindVO = new BindInfoVO();
			ArrayList bindList1 = new ArrayList();
			ArrayList bindList2 = new ArrayList();
			StringBuilder sRepSql1 = new StringBuilder();
			StringBuilder sRepSql2 = new StringBuilder();
			StringBuilder sRepSqlSort = new StringBuilder();
			decimal[] resultSum = new decimal[0];

			// 一覧画面明細選択行情報
			Ta080f01M1Form f01MVO = (Ta080f01M1Form)f03VO.Dictionary[Ta080p01Constant.DIC_M1SELCETVO];

			#region SQLID指定、抽出条件取得
			String sSqlId = "";
			bool aaa = false;
			#region モード[申請] [申請前修正]の場合
			if (f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_APPLY)
				|| f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_SINSEIMAEUPD))
			{
				sSqlId = Ta080p01Constant.SQL_ID_03;
				// 一覧画面項目
				Ta080p01Util.addMeisaiWhere(f01VO, f01MVO, bindVO, bindList1, sRepSql1, "T1", 1, 2);
				// 明細画面項目
				Ta080p01Util.addMeisaiWhere2( f03VO, bindVO, bindList1, sRepSql1, "T1", 1);
			}
			#endregion
			#region モード[申請取消]の場合
			else if (f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_SINSEIZUMITORIKESI))
			{
				sSqlId = Ta080p01Constant.SQL_ID_04;
				Ta080p01Util.addMeisaiWhere(f01VO, f01MVO, bindVO, bindList1, sRepSql1, "T1", 2, 2);
				Ta080p01Util.addMeisaiWhere2( f03VO, bindVO, bindList1, sRepSql1, "T1", 2);
			}
			#endregion
			#region モード[登録履歴照会]の場合
			else if (f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_REF_TOROKURIREKI))
			{
				sSqlId = Ta080p01Constant.SQL_ID_05;
				aaa = true;
				Ta080p01Util.addMeisaiWhere(f01VO, f01MVO, bindVO, bindList1, sRepSql1, "T11", 1, 2);
				Ta080p01Util.addMeisaiWhere2( f03VO, bindVO, bindList1, sRepSql1, "T11", 1);

				Ta080p01Util.addMeisaiWhere(f01VO, f01MVO, bindVO, bindList2, sRepSql2, "T12", 2, 2);
				Ta080p01Util.addMeisaiWhere2( f03VO, bindVO, bindList2, sRepSql2, "T12", 2);
			}
			#endregion
			#region モード[稟議結果照会]の場合
			else if (f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_REF_RINGIKEKKA))
			{
				sSqlId = Ta080p01Constant.SQL_ID_06;
				Ta080p01Util.addMeisaiWhere(f01VO, f01MVO, bindVO, bindList1, sRepSql1, "T2", 3, 2);
				Ta080p01Util.addMeisaiWhere2( f03VO, bindVO, bindList1, sRepSql1, "T2", 3);
			}
			#endregion

			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(sSqlId, facadeContext.DBContext);
			#endregion

			#region 抽出条件設定
			BoSystemSql.AddSql(reader, "ADD_WHERE_T1", sRepSql1.ToString(), bindList1);
			if (aaa)
			{
				BoSystemSql.AddSql(reader, "ADD_WHERE_T2", sRepSql2.ToString(), bindList2);
			}
			#endregion
			#region ソート条件設定
			Ta080p01Util.addMeisaiSort(f03VO, sRepSqlSort, "T", false);
			BoSystemSql.AddSql(reader, "ADD_SORT", sRepSqlSort.ToString());
			
			#endregion
			#region 結果取得
			IList<Hashtable> result = reader.Execute();
			BoSystemLog.logOut("SQL: " + reader.LogSql);
			// 件数チェック
			if (result == null || result.Count <= 0)
			{
				// エラー
				ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
			}
			else
			{
				// 一覧の初期化
				// 検索エラーの場合明細の表示を維持するため、再検索時の明細の初期化をここで実行
				m1List.ClearCacheData();
				m1List.Clear();
				resultSum = Ta080p01Util.DoMeisaiCopy(facadeContext, result, f01VO, f01MVO, m1List);
			}
			#endregion

			return resultSum;
		}
		#endregion

		#region 行数チェック
		private void ChkUpd1_4(IFacadeContext facadeContext,Ta080f03Form f03VO, IDataList m1List)
		{
			bool bErrFlg = true;
			// 行削除リスト存在チェック
			if (m1List.ListRemovedData.Count > 0)
			{
				bErrFlg = false;
			}
			// 対象明細リストチェック
			foreach (Ta080f03M1Form f03MVO in m1List.ListData)
			{
				// モード別対象行判断
				if (ChkUpdRow(f03VO, f03MVO))
				{
					bErrFlg = !ChkUpdRow(f03VO, f03MVO);
					break;
				}
			}
			if (bErrFlg)
			{
				// モード「新規作成」「申請前修正」
				if(
					(BoSystemConstant.MODE_INSERT.Equals(f03VO.Stkmodeno))
				||	(BoSystemConstant.MODE_SINSEIMAEUPD.Equals(f03VO.Stkmodeno))
					){
					// 登録データがありません。
					ErrMsgCls.AddErrMsg("E133", String.Empty, facadeContext);
				}
				// モード「申請」「申請取消」
				else if(
					(BoSystemConstant.MODE_APPLY.Equals(f03VO.Stkmodeno))
				||	(BoSystemConstant.MODE_SINSEIZUMITORIKESI.Equals(f03VO.Stkmodeno))
					)
				{
					// 対象行を選択して下さい。
					ErrMsgCls.AddErrMsg("E119", "対象行", facadeContext);
				}
			}
		}
		#endregion

		#region 確定ボタン_チェック3-6
		private void ChkUpd3_6(IFacadeContext facadeContext, Ta080f03Form f03VO, IDataList m1List, ArrayList tanpinErrList)
		{
			int iCnt = 0;
			// ストアド引数用に累計額を算出
			decimal dRuikei_kin = 0;
			//// 単品レポートエラーヘッダメッセージ
			//Boolean bTanpinErr = false;

			// 代表自社品番ヘッダーメッセージ
			bool bDaihyoErrF = false;
			// 明細エラーフラグ
			bool bMeisaiErr = false;
		
			// 明細単位で以下の処理を実施する。
			//	ストアド(補充依頼チェック処理 MDORDERNEW.checkOrder)を起動する。						
			//	代表自社品番振替フラグが1の場合、						
			//		警告(代表自社品番用)のエラーメッセージリストに追加					
			//		Dictionary.[代表自社品番振替確認フラグ]に"1"を設定					
			//	エラーコードが10、30、40番台の場合、						
			//		通常のエラーメッセージリストに追加					
			//	エラーコードが20番台の場合、						
			//		警告(単品用)のエラーメッセージリストに追加					
			//		対象行のDictionary.[単品レポートフラグ]に1を設定し次の行のチェックを行う。					
			foreach (Ta080f03M1Form f03MVO in m1List.ListData)
			{
				bMeisaiErr = false;
				iCnt++;
				// モード別対象行判断
				if (ChkUpdRow(f03VO, f03MVO))
				{
					#region 実処理
					// 明細の単品フラグ初期化
					if (!Convert.ToString(Ta080p01Constant.FLG_ON).Equals(BoSystemString.Nvl(((string)f03VO.Dictionary[Ta080p01Constant.DIC_TANPIN_TOUROKU_MODE_FLG]), "0")))
					{
						f03MVO.Dictionary[Ta080p01Constant.DIC_TANPIN_REPORT_FLG] = Ta080p01Constant.FLG_OFF;
					}
					f03MVO.Dictionary[Ta080p01Constant.DIC_M1DAIHYO_JISYAHB_HK_FLG] = Ta080p01Constant.FLG_OFF.ToString();

					#region スキャンコード入力チェック
					if (String.IsNullOrEmpty(f03MVO.M1scan_cd))
					{
						// スキャンコードを入力してください
						ErrMsgCls.AddErrMsg("E121", "スキャンコード", facadeContext, new[] { "M1scan_cd" }, f03MVO.M1rowno, (iCnt - 1).ToString(), "M1", m1List.DispRow);
						bMeisaiErr = true;
					}
					#endregion

					#region 依頼数量チェック
					// 入力されていない場合、エラー
					if (String.IsNullOrEmpty(f03MVO.M1irai_su)) {
						ErrMsgCls.AddErrMsg("E121", "依頼数", facadeContext, new[] { "M1irai_su" }, f03MVO.M1rowno, (iCnt - 1).ToString(), "M1", m1List.DispRow);
						bMeisaiErr = true;
					}
					// 0が入力された場合、エラー
					else if("0".Equals(f03MVO.M1irai_su)) {
						ErrMsgCls.AddErrMsg("E103", "依頼数", facadeContext, new[] { "M1irai_su" }, f03MVO.M1rowno, (iCnt - 1).ToString(), "M1", m1List.DispRow);
						bMeisaiErr = true;
					}
					#endregion 
					
					// スキャンコード/依頼数量で入力エラーが発生した場合、その明細行のチェックを終了する
					if (bMeisaiErr)
					{
						continue;
					}

					#region ストアド（チェック処理）を実行する
					#region ■パラメータ設定
					ArrayList paramList = new ArrayList();

					//,v_FURI_F			OUT	NUMBER							/*  1 代表自社品番振替フラグ */
					StoredProcedureCls.SetStoredParam(ref paramList, "v_FURI_F", OracleDbType.Decimal, ParameterDirection.Output);
					//,v_FURIMAE_CD		OUT	MDOT0120.JAN_CD%TYPE			/*  2 代表自社品番振替前商品コード */
					StoredProcedureCls.SetStoredParam(ref paramList, "v_FURIMAE_CD", OracleDbType.Decimal, ParameterDirection.Output);
					//,v_ZANKIN			OUT	VARCHAR2						/*  3 仕入枠残金額 */
					StoredProcedureCls.SetStoredParam(ref paramList, "v_ZANKIN", OracleDbType.Decimal, ParameterDirection.Output);
					//,v_TENPO_CD		IN	MDOT0120.TENPO_CD%TYPE			/*  4 店舗コード */
					StoredProcedureCls.SetStoredParam(ref paramList, "v_TENPO_CD", OracleDbType.Char, ParameterDirection.Input, BoSystemFormat.formatTenpoCd(f03VO.Head_tenpo_cd));
					//,v_JAN_CD			IN	MDOT0120.JAN_CD%TYPE			/*  5 JANコード */
					StoredProcedureCls.SetStoredParam(ref paramList, "v_JAN_CD", OracleDbType.Varchar2, ParameterDirection.Input, BoSystemFormat.formatJanCd(f03MVO.M1scan_cd));
					//,v_IRAI_SU		IN	MDOT0120.IRAI_SU%TYPE			/*  6 依頼数量 */
					StoredProcedureCls.SetStoredParam(ref paramList, "v_IRAI_SU", OracleDbType.Decimal, ParameterDirection.Input, decimal.Parse(f03MVO.M1irai_su));
					//,v_YOSAN_CD		IN	MDOT0120.YOSAN_CD%TYPE			/*  7 仕入枠グループコード */
					StoredProcedureCls.SetStoredParam(ref paramList, "v_YOSAN_CD", OracleDbType.Varchar2, ParameterDirection.Input, BoSystemFormat.formatYosan_Cd(f03VO.Yosan_cd));
					//,v_CHECKKB		IN	NUMBER							/*  8 チェック区分[1]新規[2]申請 */
					int checkkb = 0;
					if (BoSystemConstant.MODE_INSERT.Equals(f03VO.Stkmodeno))
					{
						// 「新規作成」
						checkkb = 1;
					}
					else if (BoSystemConstant.MODE_SINSEIMAEUPD.Equals(f03VO.Stkmodeno))
					{
						// 「申請前修正」
						checkkb = 0;
					} 
					else
					{
						// 「新規作成」「申請前修正」以外
						checkkb = 2;
					}
					StoredProcedureCls.SetStoredParam(ref paramList, "v_CHECKKB", OracleDbType.Decimal, ParameterDirection.Input, checkkb);
					//,v_ZANKIN_KB	IN	NUMBER								/*  9 仕入枠残金額取得区分 [1]なし[2]1円単位で取得[3]10円単位で取得 */
					StoredProcedureCls.SetStoredParam(ref paramList, "v_ZANKIN_KB", OracleDbType.Decimal, ParameterDirection.Input, 1);
					//,v_GENKARUISEKI	IN	NUMBER							/* 10 原価金額累積 */
					StoredProcedureCls.SetStoredParam(ref paramList, "v_GENKARUISEKI", OracleDbType.Decimal, ParameterDirection.Input, dRuikei_kin);

					#endregion
					// ■補充依頼データの入力チェック処理呼び出し
					ArrayList al = StoredProcedureCls.ExecStoredProcedure(facadeContext.DBContext, "MDORDERNEW.checkOrder", paramList);
					#endregion

					#region ストアド結果判定
					if (al != null && al.Count > 0)
					{
						// 商品情報取得
						ArrayList SyohinList = (ArrayList)al[1];
						if (SyohinList == null || SyohinList.Count <= 0)
						{
							if (al[0].ToString().Equals("11"))
							{
								// 商品区分が商品外エラー
								ErrMsgCls.AddErrMsg("E255", String.Empty, facadeContext, new[] { "M1scan_cd" }, f03MVO.M1rowno, (iCnt - 1).ToString(), "M1", m1List.DispRow);
							}
							else
							{
								ErrMsgCls.AddErrMsg("E111", "スキャンコード", facadeContext, new[] { "M1scan_cd" }, f03MVO.M1rowno, (iCnt - 1).ToString(), "M1", m1List.DispRow);
							}
							continue;
						}
						Hashtable SyohinInf = (Hashtable)SyohinList[0];

						#region エラーコード一覧
						// 01:自動定数あり
						// 02:売上実績なし
						// 03:入荷予定あり
						// 04:販完日間近
						// 05:未展開商品
						// 06:投入間近
						// 10:マスタ未存在
						// 11:商品外
						// 12:ドロップ品番
						// 13:初回配分
						// 14:原価マイナス
						// 15:仕入枠違い
						// 16:発注MST.[原価]×[Ｍ１依頼数量] ＞9999999（７桁）
						// 17:ロットエラー
						// 21:補充対象外
						// 22:代表自社品番エラー
						// 23:販完日エラー
						// 24:配分可能数エラー
						// 30:仕入枠エラー
						// 31:仕入枠未設定
						// 40:経年品
						// 41:店舗C評価
						// 42:全社在庫なし
						// 43:返品指示あり
						#endregion

						#region エラーコード判定
						string errCd = al[0].ToString();
						// エラーコード
						decimal dErrcd = Convert.ToDecimal(errCd);
						// 単品登録モード
						string tanpinF = BoSystemString.Nvl(((string)f03VO.Dictionary[Ta080p01Constant.DIC_TANPIN_TOUROKU_MODE_FLG]), "0");


						// 単品登録モードで単品エラーが解消された場合、補充として登録する
						if (Convert.ToString(Ta080p01Constant.FLG_ON).Equals(tanpinF) && !(dErrcd >= 20 && dErrcd < 30))
						{
							f03MVO.Dictionary[Ta080p01Constant.DIC_TANPIN_REPORT_FLG] = Ta080p01Constant.FLG_OFF;
						}
						// [選択モードNo]が「新規作成」で区分が単品レポートかつ単品登録モードがONでない場合は、単品レポートチェック、仕入枠チェックは処理しない。
						if (BoSystemConstant.MODE_INSERT.Equals(f03VO.Stkmodeno) && Convert.ToString(Ta080p01Constant.FLG_ON).Equals(tanpinF) && dErrcd >= 20 && dErrcd < 40)
						{
							#region 登録/更新処理用 項目保持
							// 部門コード	
							f03MVO.Dictionary[Ta080p01Constant.DIC_M1BUMON_CD] = SyohinInf["BUMON_CD"].ToString();
							// 品種コード		
							f03MVO.Dictionary[Ta080p01Constant.DIC_M1HINSYU_CD] = SyohinInf["HINSYU_CD"].ToString();
							// ブランドコード	
							f03MVO.Dictionary[Ta080p01Constant.DIC_M1BURANDO_CD] = SyohinInf["BURANDO_CD"].ToString();
							// 色コード		
							f03MVO.Dictionary[Ta080p01Constant.DIC_M1IRO_CD] = SyohinInf["MAKERCOLOR_CD"].ToString();
							// サイズコード	
							f03MVO.Dictionary[Ta080p01Constant.DIC_M1SIZE_CD] = SyohinInf["SIZE_CD"].ToString();
							// 商品コード		
							f03MVO.Dictionary[Ta080p01Constant.DIC_M1SYOHIN_CD] = SyohinInf["SYOHIN_CD"].ToString();
							// 当初売価		
							f03MVO.Dictionary[Ta080p01Constant.DIC_M1TOSYOBAIKA_TNK] = SyohinInf["TOSYOBAIKA_TNK"].ToString();
							#endregion

							continue;
						}
						// [選択モードNo]が「新規作成」以外で区分が単品登録の場合は、単品レポートチェック、仕入枠チェックは処理しない。
						if (!BoSystemConstant.MODE_INSERT.Equals(f03VO.Stkmodeno) && f03VO.Yosan_cd.Equals("000000") && dErrcd >= 20 && dErrcd < 40)
						{
							#region 登録/更新処理用 項目保持
							// 部門コード	
							f03MVO.Dictionary[Ta080p01Constant.DIC_M1BUMON_CD] = SyohinInf["BUMON_CD"].ToString();
							// 品種コード		
							f03MVO.Dictionary[Ta080p01Constant.DIC_M1HINSYU_CD] = SyohinInf["HINSYU_CD"].ToString();
							// ブランドコード	
							f03MVO.Dictionary[Ta080p01Constant.DIC_M1BURANDO_CD] = SyohinInf["BURANDO_CD"].ToString();
							// 色コード		
							f03MVO.Dictionary[Ta080p01Constant.DIC_M1IRO_CD] = SyohinInf["MAKERCOLOR_CD"].ToString();
							// サイズコード	
							f03MVO.Dictionary[Ta080p01Constant.DIC_M1SIZE_CD] = SyohinInf["SIZE_CD"].ToString();
							// 商品コード		
							f03MVO.Dictionary[Ta080p01Constant.DIC_M1SYOHIN_CD] = SyohinInf["SYOHIN_CD"].ToString();
							// 当初売価		
							f03MVO.Dictionary[Ta080p01Constant.DIC_M1TOSYOBAIKA_TNK] = SyohinInf["TOSYOBAIKA_TNK"].ToString();
							#endregion
							continue;
						}

						#region 代表自社品番振替フラグ判定
						//	 代表自社品番振替フラグが1の場合
						//	 警告(代表自社品番用)のエラーメッセージリストに追加
						//		補充可能な商品に置き換えます({0} {1})。
						//	 Dictionary.[代表自社品番振替確認フラグ]に"1"を設定
						string v_FURI_F = al[2].ToString();
						if (Ta080p01Constant.FLG_ON.ToString().Equals(v_FURI_F))
						{
							// カーソルから商品名を取得
							string sItemNm = ((Hashtable)((ArrayList)al[1])[0])["SYONMK"].ToString();
							//InfoMsgCls.AddWarnMsg("W130", new[] { al[3].ToString(), sItemNm }, facadeContext, null, f03MVO.M1rowno, (iCnt - 1).ToString(), "M1");
							Ta080p01Util.setDaihyoMsg("W130", new[] { SyohinInf["JAN_CD"].ToString(), sItemNm }, facadeContext, null, f03MVO.M1rowno, (iCnt - 1).ToString(), "M1", m1List.DispRow, bDaihyoErrF);
							f03VO.Dictionary[Ta080p01Constant.DIC_M1DAIHYO_JISYAHB_HK_FLG] = Ta080p01Constant.FLG_ON.ToString();
							f03MVO.Dictionary[Ta080p01Constant.DIC_M1DAIHYO_JISYAHB_HK_FLG] = Ta080p01Constant.FLG_ON.ToString();

							BackDetailVO f03M1BackVO = new BackDetailVO();

							f03M1BackVO.M1bumonkana_nm = SyohinInf["BUMONKANA_NM"].ToString();												// Ｍ１部門カナ名
							f03M1BackVO.M1ten_hyoka_kb = SyohinInf["TEN_HYOKA"].ToString();													// Ｍ１店評価
							f03M1BackVO.M1all_hyoka_kb = SyohinInf["ALL_HYOKA"].ToString();													// Ｍ１全評価
							f03M1BackVO.M1tosyu_uriage_su = SyohinInf["URI_SU_TOU"].ToString();												// Ｍ１当週売
							f03M1BackVO.M1hinsyu_ryaku_nm = SyohinInf["HINSYU_RYAKU_NM"].ToString();										// Ｍ１品種略名称
							f03M1BackVO.M1zensyu_uriage_su = SyohinInf["URI_SU_1TH"].ToString();											// Ｍ１前売
							f03M1BackVO.M1zenzensyu_uriage_su = SyohinInf["URI_SU_2TH"].ToString();											// Ｍ１前々売
							f03M1BackVO.M1burando_nm = SyohinInf["BURANDO_NMK"].ToString();													// Ｍ１ブランド名
							f03M1BackVO.M1nyukayotei_su = SyohinInf["NYUKA_SU"].ToString();													// Ｍ１入荷
							f03M1BackVO.M1tenzaiko_su = SyohinInf["REAL_SU"].ToString();													// Ｍ１在庫
							f03M1BackVO.M1jido_su = SyohinInf["JIDO_SU"].ToString();														// Ｍ１自動定数
							f03M1BackVO.M1haibunkano_su = SyohinInf["HAIBUNKANO_SU"].ToString();											// Ｍ１配分可能数
							f03M1BackVO.M1jisya_hbn = SyohinInf["XEBIO_CD"].ToString();														// Ｍ１自社品番
							f03M1BackVO.M1keikaku_ymd = SyohinInf["KEIKAKU_YMD"].ToString();												// Ｍ１計画期間 販売完了日の期末の月 yyyymm
							f03M1BackVO.M1syohin_zokusei = SyohinInf["SYOHIN_ZOKUSEI"].ToString();											// Ｍ１商品属性
							f03M1BackVO.M1lot_su = SyohinInf["MOTOMIYALOT_SU"].ToString();													// Ｍ１ロット数
							f03M1BackVO.M1maker_hbn = SyohinInf["HIN_NBR"].ToString();														// Ｍ１メーカー品番
							f03M1BackVO.M1syonmk = SyohinInf["SYONMK"].ToString();															// Ｍ１商品名(カナ)
							f03M1BackVO.M1iro_nm = SyohinInf["MAKERCOLOR_CD"].ToString();													// Ｍ１色
							f03M1BackVO.M1size_nm = SyohinInf["SIZE_NM"].ToString();														// Ｍ１サイズ
							f03M1BackVO.M1scan_cd = SyohinInf["JAN_CD"].ToString();															// Ｍ１スキャンコード 
							f03M1BackVO.M1gen_tnk = SyohinInf["GENKA"].ToString();															// Ｍ１原単価(隠し)
							f03M1BackVO.M1genkakin = (Convert.ToDecimal(f03MVO.M1irai_su) * Convert.ToDecimal(f03M1BackVO.M1gen_tnk)).ToString();
							// 過去4週売上を設定(メッセージの判定に使用)
							f03MVO.M1uriage_su_hdn = SyohinInf["URI_SU"].ToString();
																																			// Ｍ１原価金額
							f03M1BackVO.M1hanbaikanryo_ymd = BoSystemFormat.formatDate_yyMMdd(SyohinInf["HANBAIKANRYO_YMD"].ToString());	// Ｍ１販売完了日 yymmdd
							f03M1BackVO.M1genkakin_hdn = f03M1BackVO.M1genkakin;															// Ｍ１原価金額(隠し)

							f03MVO.Dictionary[Ta080p01Constant.DIC_M1DAIHYOF_SYOHININF] = f03M1BackVO;

							//continue;
						}
						#endregion

						switch (errCd)
						{
							#region errCd10番台 チェック3_単項目チェック
							case "10":
								// 発注MSTに存在しない場合、エラー
								ErrMsgCls.AddErrMsg("E111", "スキャンコード", facadeContext, new[] { "M1scan_cd" }, f03MVO.M1rowno, (iCnt - 1).ToString(), "M1", m1List.DispRow);
								continue;
							case "11":
								// 商品区分が商品外エラー
								ErrMsgCls.AddErrMsg("E255", String.Empty, facadeContext, new[] { "M1scan_cd" }, f03MVO.M1rowno, (iCnt - 1).ToString(), "M1", m1List.DispRow);
								continue;
							case "12":
								// 特定の商品属性(L37、D41、Y48、S20)の場合はエラー
								ErrMsgCls.AddErrMsg("E238", String.Empty, facadeContext, new[] { "M1scan_cd" }, f03MVO.M1rowno, (iCnt - 1).ToString(), "M1", m1List.DispRow);
								continue;
							case "13":
								// 初回配分前の場合はエラー
								ErrMsgCls.AddErrMsg("E239", String.Empty, facadeContext, new[] { "M1scan_cd" }, f03MVO.M1rowno, (iCnt - 1).ToString(), "M1", m1List.DispRow);
								continue;
							case "14":
								// 原単価がマイナスの商品はエラー
								ErrMsgCls.AddErrMsg("E185", String.Empty, facadeContext, new[] { "M1scan_cd" }, f03MVO.M1rowno, (iCnt - 1).ToString(), "M1", m1List.DispRow);
								continue;
							case "15":
								// 申請前修正、申請の場合、仕入枠グループがヘッダ仕入枠グループコードと異なる場合はエラー
								ErrMsgCls.AddErrMsg("E244", String.Empty, facadeContext, new[] { "M1scan_cd" }, f03MVO.M1rowno, (iCnt - 1).ToString(), "M1", m1List.DispRow);
								continue;
							case "16":
								// [Ｍ１原価金額]（※）＞9999999（７桁）の場合、エラー
								ErrMsgCls.AddErrMsg("E102", "原価金額", facadeContext, new[] { "M1irai_su" }, f03MVO.M1rowno, (iCnt - 1).ToString(), "M1", m1List.DispRow);
								continue;
							case "17":
								// ロット数チェック
								// 依頼数が上記(3-1)エラーチェックの部品にて取得した発注MST.[本宮ロット数]の整数倍でない場合、エラー
								ErrMsgCls.AddErrMsg("E112", "依頼数", facadeContext, new[] { "M1scan_cd", "M1irai_su" }, f03MVO.M1rowno, (iCnt - 1).ToString(), "M1", m1List.DispRow);
								continue;
							#endregion
							#region errCd20番台 チェック4_単品レポートチェック 警告
							// 警告(単品用)のエラーメッセージリストに追加
							// 対象行のDictionary.[単品レポートフラグ]に1を設定
//							case "20":
//								// ロット数チェック⇒17番に変更
//								// 依頼数が上記(3-1)エラーチェックの部品にて取得した発注MST.[本宮ロット数]の整数倍でない場合、エラー
							//								InfoMsgCls.AddWarnMsg("E112", "依頼数", facadeContext, new[] { "M1scan_cd", "M1irai_su" }, f03MVO.M1rowno, (iCnt - 1).ToString(), "M1");
//								f03MVO.Dictionary[Ta080p01Constant.DIC_TANPIN_REPORT_FLG] = Ta080p01Constant.FLG_ON;
//								break;
							case "21":
								// 補充発注対象商品チェック
								// 上記(3-1)エラーチェックの部品にて取得した発注MST.[補充発注対象商品区分]＝"0"の場合、エラー

								// エラーメッセージ設定
								Ta080p01Util.setTanpinReportMsg("E185", String.Empty, facadeContext, new[] { "M1scan_cd" }, f03MVO.M1rowno, (iCnt - 1).ToString(), "M1", m1List.DispRow, tanpinErrList);
								f03VO.Dictionary[Ta080p01Constant.DIC_TANPIN_REPORT_FLG] = Ta080p01Constant.FLG_ON;
								f03MVO.Dictionary[Ta080p01Constant.DIC_TANPIN_REPORT_FLG] = Ta080p01Constant.FLG_ON;
								continue;
							case "22":
								// 代表自社品番補充外チェック
								// 上記(3-1)エラーチェックの部品にて取得した発注MST.[自社品番]で代表自社品番MSTを検索し、代表自社品番MST.[配分対象外フラグ]＝1の場合、エラーとする。

								// エラーメッセージ設定
								Ta080p01Util.setTanpinReportMsg("E185", String.Empty, facadeContext, new[] { "M1scan_cd" }, f03MVO.M1rowno, (iCnt - 1).ToString(), "M1", m1List.DispRow, tanpinErrList);
								f03VO.Dictionary[Ta080p01Constant.DIC_TANPIN_REPORT_FLG] = Ta080p01Constant.FLG_ON;
								f03MVO.Dictionary[Ta080p01Constant.DIC_TANPIN_REPORT_FLG] = Ta080p01Constant.FLG_ON;
								continue;
							case "23":
								// 販売完了日チェック
								// 上記(3-1)エラーチェックの部品にて取得した発注MST.[販売完了日]＜＝システム日付の場合、
								// エラーとする。 ※本宮商品フラグが「1(DC)、3(DC自動)」の場合はチェックしない

								// エラーメッセージ設定
								Ta080p01Util.setTanpinReportMsg("E182", String.Empty, facadeContext, new[] { "M1scan_cd" }, f03MVO.M1rowno, (iCnt - 1).ToString(), "M1", m1List.DispRow, tanpinErrList);
								f03VO.Dictionary[Ta080p01Constant.DIC_TANPIN_REPORT_FLG] = Ta080p01Constant.FLG_ON;
								f03MVO.Dictionary[Ta080p01Constant.DIC_TANPIN_REPORT_FLG] = Ta080p01Constant.FLG_ON;
								continue;
							case "24":
								// 配分可能数チェック
								// [Ｍ１依頼数量]が上記(3-1)エラーチェックの部品にて取得した
								// 発注MST.[配分可能数]＜Ｍ１依頼数量の場合、エラーとする。

								// エラーメッセージ設定
								Ta080p01Util.setTanpinReportMsg("E113", "依頼数", facadeContext, new[] { "M1scan_cd", "M1irai_su" }, f03MVO.M1rowno, (iCnt - 1).ToString(), "M1", m1List.DispRow, tanpinErrList);
								f03VO.Dictionary[Ta080p01Constant.DIC_TANPIN_REPORT_FLG] = Ta080p01Constant.FLG_ON;
								f03MVO.Dictionary[Ta080p01Constant.DIC_TANPIN_REPORT_FLG] = Ta080p01Constant.FLG_ON;
								continue;
							#endregion
							#region errCd30番台 チェック5_仕入枠チェック
							case "30":
								// 仕入枠チェック
								string sSiireWakuNm = string.Empty;
								if (BoSystemConstant.MODE_INSERT.Equals(f03VO.Stkmodeno))
								{
									// 新規の場合
									sSiireWakuNm = SyohinInf["YOSAN_NM"].ToString();
								}
								else
								{
									// 新規以外の場合
									sSiireWakuNm = f03VO.Yosan_nm;
								}
								ErrMsgCls.AddErrMsg("E240", sSiireWakuNm, facadeContext, new[] { "M1scan_cd", "M1irai_su" }, f03MVO.M1rowno, (iCnt - 1).ToString(), "M1", m1List.DispRow);
								continue;
							case "31":
								// 仕入枠存在チェック
								ErrMsgCls.AddErrMsg("E252", String.Empty, facadeContext, new[] { "M1scan_cd", "M1irai_su" }, f03MVO.M1rowno, (iCnt - 1).ToString(), "M1", m1List.DispRow);
								continue;
							#endregion
							#region errCd40番台 チェック6_単品レポートチェック後のチェック
							case "40":
								// 経年品チェック
								ErrMsgCls.AddErrMsg("E245", String.Empty, facadeContext, new[] { "M1scan_cd" }, f03MVO.M1rowno, (iCnt - 1).ToString(), "M1", m1List.DispRow);
								continue;
							case "41":
								// 店舗C評価、在庫数ありチェック
								ErrMsgCls.AddErrMsg("E246", String.Empty, facadeContext, new[] { "M1scan_cd" }, f03MVO.M1rowno, (iCnt - 1).ToString(), "M1", m1List.DispRow);
								continue;
							case "42":
								// 全店在庫100点以下チェック
								ErrMsgCls.AddErrMsg("E247", String.Empty, facadeContext, new[] { "M1scan_cd" }, f03MVO.M1rowno, (iCnt - 1).ToString(), "M1", m1List.DispRow);
								continue;
							case "43":
								// 返品対象チェック
								ErrMsgCls.AddErrMsg("E242", String.Empty, facadeContext, new[] { "M1scan_cd" }, f03MVO.M1rowno, (iCnt - 1).ToString(), "M1", m1List.DispRow);
								continue;
							#endregion
							default:
								BoSystemLog.logOut(errCd);
								break;
						}
						#endregion

						#region 登録/更新処理用 項目保持
						// 部門コード	
						f03MVO.Dictionary[Ta080p01Constant.DIC_M1BUMON_CD] = SyohinInf["BUMON_CD"].ToString();
						// 品種コード		
						f03MVO.Dictionary[Ta080p01Constant.DIC_M1HINSYU_CD] = SyohinInf["HINSYU_CD"].ToString();
						// ブランドコード	
						f03MVO.Dictionary[Ta080p01Constant.DIC_M1BURANDO_CD] = SyohinInf["BURANDO_CD"].ToString();
						// 色コード		
						f03MVO.Dictionary[Ta080p01Constant.DIC_M1IRO_CD] = SyohinInf["MAKERCOLOR_CD"].ToString();
						// サイズコード	
						f03MVO.Dictionary[Ta080p01Constant.DIC_M1SIZE_CD] = SyohinInf["SIZE_CD"].ToString();
						// 商品コード		
						f03MVO.Dictionary[Ta080p01Constant.DIC_M1SYOHIN_CD] = SyohinInf["SYOHIN_CD"].ToString();
						// 当初売価		
						f03MVO.Dictionary[Ta080p01Constant.DIC_M1TOSYOBAIKA_TNK] = SyohinInf["TOSYOBAIKA_TNK"].ToString();
						#endregion

					}
					else
					{
						// OUTパラメータが取得できない場合
						throw new SystemException("ストアド［MDORDERNEW.checkOrder］実行時にエラーが発生しました。");
					}

					// ストアド引数用_累計額加算
					dRuikei_kin += decimal.Parse(BoSystemString.Nvl(f03MVO.M1genkakin, "0"));
					#endregion

					#endregion
				}
			}
		}
		#endregion

		#region 確定ボタン_チェック7 排他チェック
		private void ChkUpd7(IFacadeContext facadeContext, Ta080f03Form f03VO, IDataList m1List)
		{	
			// 明細画面排他チェック
			foreach (Ta080f03M1Form f03MVO in m1List.ListData)
			{
				// モード別対象行判断
				if (ChkUpdRow(f03VO, f03MVO))
				{
					#region 実処理
					StringBuilder sRepSql = new StringBuilder();
					String sHaitaTable = "";
					ArrayList bindList = new ArrayList();
					BindInfoVO bindVO = new BindInfoVO();

					// 対象テーブル名設定
					// モード｢申請｣の場合
					// モード｢申請前修正｣の場合
					if(BoSystemConstant.MODE_APPLY.Equals(f03VO.Stkmodeno)
					|| BoSystemConstant.MODE_SINSEIMAEUPD.Equals(f03VO.Stkmodeno)
					){
						// 補充依頼申請TBL
						sHaitaTable = Ta080p01Constant.TBLID_HOJUIARI_SINSEI;
						Ta080p01Util.setKeyMdot0110(f03MVO, bindVO, bindList, sRepSql);
					}
					// モード｢申請取消｣の場合
					else if (BoSystemConstant.MODE_SINSEIZUMITORIKESI .Equals(f03VO.Stkmodeno))
					{
						// 補充依頼確定TBL
						sHaitaTable = Ta080p01Constant.TBLID_HOJUIRAI_KAKUTEI;
						Ta080p01Util.setKeyMdot0120(f03MVO, bindVO, bindList, sRepSql);
					}
					
					// 新規作成モードの場合以外、排他チェック
					if (!BoSystemConstant.MODE_INSERT.Equals(f03VO.Stkmodeno))
					{
						string sKanriNo = BoSystemString.Nvl(f03MVO.Dictionary[Ta080p01Constant.DIC_M1KANRI_NO] as string, "0");
						if (string.IsNullOrEmpty(sKanriNo) || sKanriNo.Equals("0"))
						{
							// 新規行はチェックなし
							break;
						}
						bool bChk = false;
						bChk = V03003Check.CheckHaita(
								Convert.ToDecimal((string)f03MVO.Dictionary[Ta080p01Constant.DIC_M1UPD_YMD]),
								Convert.ToDecimal((string)f03MVO.Dictionary[Ta080p01Constant.DIC_M1UPD_TM]),
								facadeContext,
								sHaitaTable,
								sRepSql.ToString(),
								bindList,
								1
						);
						if (!bChk)
						{
							break;
						}
					}
					#endregion
				}
			}
		}
		#endregion

		#region 確定ボタン_チェック8 単品申請警告
		private void ChkUpd8(IFacadeContext facadeContext, Ta080f03Form f03VO, IDataList m1List)
		{	
			// 申請対象のデータを自社品番単位で集計し[依頼数量]×発注MST.[当初売価]の合計を算出する。
			// 上記合計が10000以下(名称マスタ(TPUR))の場合は警告表示を行う。

			// 補充依頼用売価金額チェックの金額取得
			LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();
			String meisyo_cd = logininfo.CopCd;
			Hashtable result = V01015Check.CheckMeisyo("TPUR", meisyo_cd, facadeContext);
			decimal chkBaika = decimal.Parse(BoSystemString.Nvl((String)result["MEISYO_NM"], "0"));

			Ta080f01Form form = new Ta080f01Form();

			int iCnt = 0;
			foreach (Ta080f03M1Form f03MVO in m1List.ListData)
			{
				// モード別対象行判断
				if (ChkUpdRow(f03VO, f03MVO))
				{
					#region 実処理
					// 自社品番を取得
					String jisya_hbn = f03MVO.M1jisya_hbn;
					// 依頼数を取得
					decimal irai_su = decimal.Parse(f03MVO.M1irai_su);
					// 当初売価を取得
					decimal tosyo_bik = decimal.Parse((String)f03MVO.Dictionary[Ta080p01Constant.DIC_M1TOSYOBAIKA_TNK]);
					// 行番号を取得
					String rowno = f03MVO.M1rowno;
					// 自行の売価金額を取得
					decimal sumbaika = irai_su * tosyo_bik;

					foreach (Ta080f03M1Form f03MVO2 in m1List.ListData)
					{
						if (!rowno.Equals(f03MVO2.M1rowno) && ChkUpdRow(f03VO, f03MVO2))
						{
							// 自行以外で自社品番が一致するデータが存在する場合、売価を加算
							String jisya_hbn2 = f03MVO2.M1jisya_hbn;
							if (jisya_hbn2.Equals(jisya_hbn))
							{
								decimal irai_su2 = decimal.Parse(f03MVO2.M1irai_su);
								decimal tosyo_bik2 = decimal.Parse((String)f03MVO2.Dictionary[Ta080p01Constant.DIC_M1TOSYOBAIKA_TNK]);
								sumbaika += irai_su2 * tosyo_bik2;
								if (sumbaika > chkBaika)
								{
									// 合計数がチェック金額を超える場合はループ終了
									break;
								}
							}
						}
					}
					if (sumbaika <= chkBaika)
					{
						// チェック対象金額以下の場合は警告を設定
						InfoMsgCls.AddWarnMsg("W126", chkBaika.ToString(), facadeContext, new[] { "M1scan_cd", "M1irai_su" }, f03MVO.M1rowno, iCnt.ToString(), "M1", m1List.DispRow);
					}
					#endregion
				}
				iCnt++;
			}
		}
		#endregion

		#region 確定ボタン_確定処理_｢新規作成｣
		/// <summary>
		/// 明細単位で以下の処理を実施する。															
		///	Dictionary.[単品登録モードフラグ]が"0"かつ対象行のDictionary.[単品レポートフラグ]が"0"の場合
		///	またはDictionary.[単品登録モードフラグ]が"1"の場合、											
		///	または[区分]が単品レポートの場合、以下の処理を実施する。										
		///		[補充発注一時TBL]を登録する。													
		///	ストアド(補充依頼／単品レポート登録処理)を起動する。										
		///	ストアドの戻り値をチェックする。								
		/// </summary>
		/// <param name="facadeContext"></param>
		/// <param name="f03VO"></param>
		/// <param name="m1List"></param>
		private void DoUpdInsert(IFacadeContext facadeContext, Ta080f03Form f03VO, IDataList m1List, LoginInfoVO loginInfo, SysDateVO sysDateVO)
		{
			// 登録モード取得
			string tourokuMode = BoSystemString.Nvl((string)f03VO.Dictionary[Ta080p01Constant.DIC_TANPIN_TOUROKU_MODE_FLG], Ta080p01Constant.FLG_OFF.ToString());
			foreach (Ta080f03M1Form f03MVO in m1List.ListData)
			{
				// モード別対象行判断
				if (ChkUpdRow(f03VO, f03MVO))
				{
					// 単品フラグ取得
					string tanpinF = BoSystemString.Nvl(((decimal?)f03MVO.Dictionary[Ta080p01Constant.DIC_TANPIN_REPORT_FLG]).ToString(), Ta080p01Constant.FLG_OFF.ToString());
					if (!(tourokuMode.Equals(Ta080p01Constant.FLG_OFF.ToString()) && tanpinF.Equals(Ta080p01Constant.FLG_ON.ToString())))
					{
						// 「登録モードが補充で明細が単品レポート」以外の明細を更新対象とする。
						// tempテーブル更新
						ExecInsertOrderTemp(facadeContext, f03VO, f03MVO, loginInfo, sysDateVO);
					}

				}
			}
			// ストアド(補充依頼／単品レポート登録処理)を起動する。
			// ストアドの戻り値をチェックする。
			ExecInsertOrder(facadeContext);

		}
		#endregion

		#region 確定ボタン_確定処理_｢申請｣｢申請前修正｣
		/// <summary>
		/// 明細単位で以下の処理を実施する。									
		/// 	行削除が行われた明細の場合、 ※削除行							
		/// 		[補充依頼申請TBL]を削除する。								
		/// 	対象行の[Dictionary.M１管理No]が空白の場合、 ※新規追加行		
		/// 		[補充発注一時TBL]を登録する。								
		/// 	対象行の[Dictionary.M１管理No]が空白以外の場合、 ※修正行		
		/// 		[補充依頼申請TBL]を更新する。								
		/// 		[選択モードNo]が「申請」で選択状態の場合					
		/// 			[補充依頼確定TBL]を登録する。							
		/// ストアド(補充依頼／単品レポート登録処理)を起動する。				
		/// ストアドの戻り値をチェックする。									
		/// </summary>
		/// <param name="facadeContext"></param>
		/// <param name="f03VO"></param>
		/// <param name="m1List"></param>
		/// <param name="loginInfo"></param>
		/// <param name="sysDateVO"></param>
		private void DoUpdShinseiOrShinseiUpd(IFacadeContext facadeContext, Ta080f03Form f03VO, IDataList m1List, LoginInfoVO loginInfo, SysDateVO sysDateVO)
		{
			#region 削除処理
			// 	行削除が行われた明細の場合、 ※削除行		
			// 		[補充依頼申請TBL]を削除する。			
			DltMdot0110byF03Shinsei(facadeContext, f03VO, m1List);
			#endregion

			foreach (Ta080f03M1Form f03MVO in m1List.ListData)
			{
				// モード別対象行判断
				if (ChkUpdRow(f03VO, f03MVO))
				{
					#region 登録/更新処理

					// 新規追加行の場合
					string sKanriNo = BoSystemString.Nvl(f03MVO.Dictionary[Ta080p01Constant.DIC_M1KANRI_NO] as string, "0");
					if (string.IsNullOrEmpty(sKanriNo) || sKanriNo.Equals("0"))
					{
						ExecInsertOrderTemp(facadeContext, f03VO, f03MVO, loginInfo, sysDateVO);
					}
					// 修正行の場合
					else
					{
						// [補充依頼申請TBL]更新
						// 変更内容更新(フラグ以外)
						int updmdot0110 =  UpdMdot0110byF03Shinseimae(facadeContext, f03VO, f03MVO, m1List, loginInfo, sysDateVO);
						
						//	モード「申請」
						//	[補充依頼確定TBL]を登録する。
						if(BoSystemConstant.MODE_APPLY.Equals(f03VO.Stkmodeno))
						{
							// [補充依頼確定TBL]登録
							int insmdot0120 = InsMdot0120byF03Shinsei(facadeContext, f03VO, f03MVO, loginInfo, sysDateVO);
					
							// [補充依頼申請TBL]更新
							// フラグ更新
							int updmdot0110Sosin = UpdMdot0110byF03Shinsei(facadeContext, f03VO, f03MVO, loginInfo, sysDateVO);
						}
					}
					// ストアド(補充依頼／単品レポート登録処理)を起動する。
					// ストアドの戻り値をチェックする。
					ExecInsertOrder(facadeContext);
				#endregion
				}
			}
		}
		#endregion

		#region 確定ボタン_確定処理_｢申請｣｢申請前修正｣_補充依頼申請TBL削除
		/// <summary>
		/// 確定ボタン_確定処理_｢申請｣｢申請前修正｣_補充依頼申請TBL削除s
		/// </summary>
		/// <param name="facadeContext"></param>
		/// <param name="f03VO"></param>
		/// <param name="m1List"></param>
		/// <param name="loginInfo"></param>
		/// <param name="sysDateVO"></param>
		private void DltMdot0110byF03Shinsei(IFacadeContext facadeContext, Ta080f03Form f03VO, IDataList m1List)
		{
			// 行削除が行われた明細の場合
			foreach (Ta080f03M1Form f03MVO in m1List.ListRemovedData)
			{
				BindInfoVO bindVO = new BindInfoVO();
				ArrayList bindList = new ArrayList();
				StringBuilder sRepSql = new StringBuilder();

				// SQL指定
				FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Ta080p01Constant.SQL_ID_12, facadeContext.DBContext);
				
				// キー項目設定
				Ta080p01Util.setKeyMdot0110(f03MVO, bindVO, bindList, sRepSql);
				BoSystemSql.AddSql(reader, "ADD_WHERE", sRepSql.ToString(), bindList);

				// SQL実行
				using (IDbCommand cmd = reader.CreateDbCommand())
				{
					cmd.ExecuteNonQuery();
				}
			}
		}
		#endregion

		#region 確定ボタン_確定処理_ストアド（補充発注一時TBL登録）起動
		/// <summary>
		/// 確定ボタン_確定処理_ストアド（補充発注一時TBL登録）起動
		/// </summary>
		/// <param name="facadeContext"></param>
		/// <param name="f03VO"></param>
		/// <param name="f03MVO"></param>
		/// <param name="loginInfo"></param>
		/// <param name="sysDateVo"></param>
		private void ExecInsertOrderTemp(IFacadeContext facadeContext, Ta080f03Form f03VO, Ta080f03M1Form f03MVO, LoginInfoVO loginInfo, SysDateVO sysDateVo)
		{
			//ストアド（補充発注一時TBL登録）を実行する
			#region ■パラメータ設定
			// 依頼理由コード
			decimal v_IRAIRIYU_CD = 0;
			// 区分コード
			decimal v_KBN_CD = 0;
			if (f03VO.Stkmodeno.Equals(BoSystemConstant.MODE_INSERT))
			{
				string tanpinF = BoSystemString.Nvl(((decimal?)f03MVO.Dictionary[Ta080p01Constant.DIC_TANPIN_REPORT_FLG]).ToString(), "0");

				// 新規の場合
				if (Convert.ToString(Ta080p01Constant.FLG_ON).Equals(tanpinF))
				{
					// 単品レポートの場合
					v_IRAIRIYU_CD = Convert.ToDecimal(BoSystemString.Nvl(f03MVO.M1irairiyu_cd2, "0"));
					v_KBN_CD = Convert.ToDecimal(Ta080p01Constant.KBN_KBN_CD_TANPINREPORT);
				}
				else
				{
					// 補充の場合
					v_IRAIRIYU_CD = Convert.ToDecimal(BoSystemString.Nvl(f03MVO.M1irairiyu_cd1, "0"));
					v_KBN_CD = Convert.ToDecimal(Ta080p01Constant.KBN_KBN_CD_HOJUIRAI);
				}
			}
			else
			{
				if ("000000".Equals(f03VO.Yosan_cd))
				{
					v_IRAIRIYU_CD = Convert.ToDecimal(BoSystemString.Nvl(f03MVO.M1irairiyu_cd2, "0"));
					v_KBN_CD = Convert.ToDecimal(Ta080p01Constant.KBN_KBN_CD_TANPINREPORT);
				}
				else
				{
					v_IRAIRIYU_CD = Convert.ToDecimal(BoSystemString.Nvl(f03MVO.M1irairiyu_cd1, "0"));
					v_KBN_CD = Convert.ToDecimal(Ta080p01Constant.KBN_KBN_CD_HOJUIRAI);
				}
			}

			ArrayList paramList = new ArrayList();
			//,v_TENPO_CD				IN	MDOT0011_TEMP.TENPO_CD%TYPE				/*  2 店舗コード */
			StoredProcedureCls.SetStoredParam(ref paramList, "v_TENPO_CD", OracleDbType.Char, ParameterDirection.Input, BoSystemFormat.formatTenpoCd(f03VO.Head_tenpo_cd));
			//,v_TANTOSYA_CD			IN	MDOT0011_TEMP.TANTOSYA_CD%TYPE			/*  3 担当者コード */
			StoredProcedureCls.SetStoredParam(ref paramList, "v_TANTOSYA_CD", OracleDbType.Varchar2, ParameterDirection.Input, BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			//,v_KBN_CD					IN	MDOT0011_TEMP.KBN_CD%TYPE				/*  4 区分コード */
			StoredProcedureCls.SetStoredParam(ref paramList, "v_KBN_CD", OracleDbType.Decimal, ParameterDirection.Input, v_KBN_CD);
			//,v_IRAIRIYU_CD			IN	MDOT0011_TEMP.IRAIRIYU_CD%TYPE			/*  5 依頼理由コード */
			StoredProcedureCls.SetStoredParam(ref paramList, "v_IRAIRIYU_CD", OracleDbType.Decimal, ParameterDirection.Input, v_IRAIRIYU_CD);
			//,v_ADD_YMD				IN	MDOT0011_TEMP.ADD_YMD%TYPE				/*  6 登録日 */
			StoredProcedureCls.SetStoredParam(ref paramList, "v_ADD_YMD", OracleDbType.Decimal, ParameterDirection.Input, sysDateVo.Sysdate);
			//,v_ADD_TM					IN	MDOT0011_TEMP.ADD_TM%TYPE				/*  7 登録時間 */
			StoredProcedureCls.SetStoredParam(ref paramList, "v_ADD_TM", OracleDbType.Decimal, ParameterDirection.Input, sysDateVo.Systime_mili);
			//,v_ADDTAN_CD				IN	MDOT0011_TEMP.ADDTAN_CD%TYPE			/*  8 登録担当者コード */
			StoredProcedureCls.SetStoredParam(ref paramList, "v_ADDTAN_CD", OracleDbType.Varchar2, ParameterDirection.Input, BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			//,v_JAN_CD					IN	MDOT0011_TEMP.JAN_CD%TYPE				/*  9 JANコード */
			StoredProcedureCls.SetStoredParam(ref paramList, "v_JAN_CD", OracleDbType.Varchar2, ParameterDirection.Input, BoSystemFormat.formatJanCd(f03MVO.M1scan_cd));
			//,v_IRAI_SU				IN	MDOT0011_TEMP.IRAI_SU%TYPE				/* 10 依頼数量 */
			StoredProcedureCls.SetStoredParam(ref paramList, "v_IRAI_SU", OracleDbType.Decimal, ParameterDirection.Input, Convert.ToDecimal(BoSystemString.Nvl(f03MVO.M1irai_su, "0")));
			#endregion

			// ■補充発注一時TBL登録処理呼び出し
			ArrayList al = StoredProcedureCls.ExecStoredProcedure(facadeContext.DBContext, "MDORDERNEW.insertOrderTemp", paramList);

			#region ■例外処理
			if (al != null && al.Count > 0)
			{
				// エラーコード
				string errCd = al[0].ToString();

				if (errCd.Equals(BoSystemConstant.STORED_NOT_ERR))
				{
					// 正常終了
				}
				else if (errCd.Equals(BoSystemConstant.STORED_NUMBERING_ERR))
				{
					// 採番不可の場合
					ErrMsgCls.AddErrMsg("E230", string.Empty, facadeContext);
					return;
				}
				else
				{
					// それ以外の場合
					throw new SystemException("ストアド［MDORDERNEW.insertOrderTemp］実行時にエラーが発生しました。エラーコード：" + errCd);
				}
			}
			else
			{
				// OUTパラメータが取得できない場合
				throw new SystemException("ストアド［MDORDERNEW.insertOrderTemp］実行時にエラーが発生しました。");
			}
			#endregion
		}
		#endregion

		#region 確定ボタン_確定処理_｢申請前修正｣_補充依頼申請TBL更新
		private int UpdMdot0110byF03Shinseimae(IFacadeContext facadeContext, Ta080f03Form f03VO, Ta080f03M1Form f03MVO, IDataList m1List, LoginInfoVO loginInfo, SysDateVO sysDateVO)
		{
			BindInfoVO bindVO = new BindInfoVO();
			ArrayList bindList = new ArrayList();
			StringBuilder sRepSql = new StringBuilder();
			BindInfoVO bindVO2 = new BindInfoVO();
			ArrayList bindList2 = new ArrayList();
			StringBuilder sRepSql2 = new StringBuilder();

			// SQL指定
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Ta080p01Constant.SQL_ID_08, facadeContext.DBContext);

			// キー項目設定
			Ta080p01Util.setKeyMdot0110(f03MVO, bindVO, bindList, sRepSql);
			BoSystemSql.AddSql(reader, "ADD_WHERE", sRepSql.ToString(), bindList);

			// 更新項目設定
			Ta080p01Util.addUpdMdot0110(f03VO, f03MVO, bindVO2, bindList2, sRepSql2);
			BoSystemSql.AddSql(reader, "ADD_UPDATE", sRepSql2.ToString(), bindList2);

			// 更新項目バインド変数の値を設定 （未申請）
			Ta080p01Util.setFlgMdot0110Shusei(reader, loginInfo, sysDateVO);

			// SQL実行
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region 確定ボタン_確定処理_｢申請｣_補充依頼申請TBL更新
		private int UpdMdot0110byF03Shinsei(IFacadeContext facadeContext, Ta080f03Form f03VO, Ta080f03M1Form f03MVO, LoginInfoVO loginInfo, SysDateVO sysDateVO)
		{
			BindInfoVO bindVO = new BindInfoVO();
			ArrayList bindList = new ArrayList();
			StringBuilder sRepSql = new StringBuilder();

			// SQL指定
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Ta080p01Constant.SQL_ID_08, facadeContext.DBContext);

			// キー項目設定
			Ta080p01Util.setKeyMdot0110(f03MVO, bindVO, bindList, sRepSql);
			BoSystemSql.AddSql(reader, "ADD_WHERE", sRepSql.ToString(), bindList);

			// 更新項目バインド変数の値を設定 （申請）
			Ta080p01Util.setFlgMdot0110Shinsei(reader, loginInfo, sysDateVO);

			// SQL実行
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion
	
		#region 確定ボタン_確定処理_｢申請｣_補充依頼確定TBL登録
		private int InsMdot0120byF03Shinsei(IFacadeContext facadeContext, Ta080f03Form f03VO, Ta080f03M1Form f03MVO, LoginInfoVO loginInfo, SysDateVO sysDateVO)
		{
			BindInfoVO bindVO = new BindInfoVO();
			ArrayList bindList = new ArrayList();
			StringBuilder sRepSql = new StringBuilder();

			// SQL指定
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Ta080p01Constant.SQL_ID_09, facadeContext.DBContext);

			// 抽出条件取得
			Ta080p01Util.setKeyMdot0110(f03MVO, bindVO, bindList, sRepSql);
			BoSystemSql.AddSql(reader, "ADD_WHERE", sRepSql.ToString(), bindList);


			// 更新項目バインド変数の値を設定
			// メッセージ区分
			decimal? dMsgkb = (decimal?)f03MVO.Dictionary[Ta080p01Constant.DIC_M1MESSEGE_KB];
			if (dMsgkb == null)
			{
				dMsgkb = 0;
			}
			reader.BindValue("BIND_MESSEGE_KB", dMsgkb);
			// 申請日				:システム日付(YYYYMMDD)
			reader.BindValue("BIND_SHINSEI_YMD", sysDateVO.Sysdate);
			// 予算年月				:Ｍ１年月度
			reader.BindValue("BIND_YOSAN_YMD", Convert.ToDecimal(BoSystemFormat.formatDate_yyyyMM(f03VO.Yosan_ymd)));
			// 登録日				:システム日付(YYYYMMDD)
			reader.BindValue("BIND_ADD_YMD", sysDateVO.Sysdate);
			// 登録時間:			:システム時刻(HH24MISSFF3)
			reader.BindValue("BIND_ADD_TM", sysDateVO.Systime_mili);
			// 登録担当者コード		:ログイン情報.担当者コード
			reader.BindValue("BIND_ADDTAN_CD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 更新日				:システム日付(YYYYMMDD)
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
			// 更新時間				:システム時刻(HH24MISSFF3)
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
			// 更新担当者コード	:ログイン情報.担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 削除日				:システム日付(YYYYMMDD)
			reader.BindValue("BIND_SAKUJYO_YMD", sysDateVO.Sysdate);

			// SQL実行
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region 確定ボタン_確定処理_ストアド(補充依頼／単品レポート登録処理)起動
		private void ExecInsertOrder(IFacadeContext facadeContext)
		{
			//ストアド（補充依頼／単品レポート登録処理）を実行する
			#region ■パラメータ設定
			ArrayList paramList = new ArrayList();
			//,v_mode			IN	NUMBER		-- [1]HHT[2]BO
			StoredProcedureCls.SetStoredParam(ref paramList, "v_mode", OracleDbType.Decimal, ParameterDirection.Input, 1);	// HHTと同様の更新方式を採用
			#endregion

			// ■補充依頼／単品レポート登録処理呼び出し
			ArrayList al = StoredProcedureCls.ExecStoredProcedure(facadeContext.DBContext, "MDORDERNEW.insertOrder", paramList);

			#region ■例外処理
			if (al != null && al.Count > 0)
			{
				// エラーコード
				string errCd = al[0].ToString();

				if (errCd.Equals(BoSystemConstant.STORED_NOT_ERR))
				{
					// 正常終了
				}
				else if (errCd.Equals(BoSystemConstant.STORED_NUMBERING_ERR))
				{
					// 採番不可の場合
					ErrMsgCls.AddErrMsg("E230", string.Empty, facadeContext);
					return;
				}
				else
				{
					// それ以外の場合
					throw new SystemException("ストアド［MDORDERNEW.insertOrder］実行時にエラーが発生しました。エラーコード：" + errCd);
				}
			}
			else
			{
				// OUTパラメータが取得できない場合
				throw new SystemException("ストアド［MDORDERNEW.insertOrder］実行時にエラーが発生しました。");
			}
			#endregion

		}




		#endregion

		#region 確定ボタン_確定処理_｢申請取消｣
		/// <summary>
		///	明細単位で以下の処理を実施する。
		///		選択されている行の場合、
		///			[補充依頼確定TBL]を削除する。
		///			[補充依頼申請TBL]を更新する。
		/// </summary>
		/// <param name="facadeContext"></param>
		/// <param name="f03VO"></param>
		/// <param name="m1List"></param>
		private void DoUpdShinseiTorikeshi(IFacadeContext facadeContext, Ta080f03Form f03VO, IDataList m1List, LoginInfoVO loginInfo, SysDateVO sysDateVO)
		{
			foreach (Ta080f03M1Form f03MVO in m1List.ListData)
			{
				// モード別対象行判断
				if (ChkUpdRow(f03VO, f03MVO))
				{
					// [補充依頼確定TBL]を削除する。
					int iDltMdot0120Cnt = DltMdot0120byF03ShinseiTorikeshi(facadeContext, f03VO, f03MVO, m1List, loginInfo, sysDateVO);
					// [補充依頼申請TBL]を更新する。
					int iUpdMdot0110Cnt = UpdMdot0110byF03ShinseiTorikeshi(facadeContext, f03VO, f03MVO, m1List, loginInfo, sysDateVO);
				}
			}
		}
		#endregion

		#region 確定ボタン_確定処理_｢申請取消｣_補充依頼確定TBL削除
		private int DltMdot0120byF03ShinseiTorikeshi(IFacadeContext facadeContext, Ta080f03Form f03VO, Ta080f03M1Form f03MVO, IDataList m1List, LoginInfoVO loginInfo, SysDateVO sysDateVO)
		{
			BindInfoVO bindVO = new BindInfoVO();
			ArrayList bindList = new ArrayList();
			StringBuilder sRepSql = new StringBuilder();

			// SQL指定
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Ta080p01Constant.SQL_ID_11, facadeContext.DBContext);

			// キー項目設定
			Ta080p01Util.setKeyMdot0120(f03MVO, bindVO, bindList, sRepSql);
			BoSystemSql.AddSql(reader, "ADD_WHERE", sRepSql.ToString(), bindList);

			// SQL実行
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region 確定ボタン_確定処理_｢申請取消｣_補充依頼申請TBL更新
		private int UpdMdot0110byF03ShinseiTorikeshi(IFacadeContext facadeContext, Ta080f03Form f03VO, Ta080f03M1Form f03MVO, IDataList m1List, LoginInfoVO loginInfo, SysDateVO sysDateVO)
		{
			BindInfoVO bindVO = new BindInfoVO();
			ArrayList bindList = new ArrayList();
			StringBuilder sRepSql = new StringBuilder();

			// SQL指定
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Ta080p01Constant.SQL_ID_08, facadeContext.DBContext);

			// キー項目設定
			Ta080p01Util.setKeyMdot0110(f03MVO, bindVO, bindList, sRepSql);
			BoSystemSql.AddSql(reader, "ADD_WHERE", sRepSql.ToString(), bindList);
			
			// 更新項目バインド変数の値を設定
			Ta080p01Util.setFlgMdot0110Mishinsei(reader, loginInfo, sysDateVO);

			// SQL実行
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region 確定ボタン_単品レポートモード表示
		/// <summary>
		/// ChkTanpinReport 単品レポートモード表示
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="IDataList">m1List</param>
		/// <returns></returns>
		private void DoCopyTanpinReport(Ta080f03Form f03VO)
		{
			int iCnt = 0;
			IDataList m1List = f03VO.GetList("M1");

			decimal[] iDelRow = new decimal[m1List.Count];
			foreach (Ta080f03M1Form f03MVO in m1List.ListData)
			{
				// スキャンコードが入力されていない場合、次明細
				if (string.IsNullOrEmpty(f03MVO.M1scan_cd.Trim()))
				{
					iDelRow[iCnt] = Ta080p01Constant.FLG_ON;
					iCnt++;
					continue;
				}
				// 単品レポートフラグ設定（明細単位） がＯＮの場合
				string tanpinF = BoSystemString.Nvl(((decimal?)f03MVO.Dictionary[Ta080p01Constant.DIC_TANPIN_REPORT_FLG]).ToString(), "0");
				if (Convert.ToString(Ta080p01Constant.FLG_ON).Equals(tanpinF))
				{
					iDelRow[iCnt] = Ta080p01Constant.FLG_OFF;
				}
				else
				{
					iDelRow[iCnt] = Ta080p01Constant.FLG_ON;
				}
				iCnt++;
			}

			// 明細情報を削除
			for (int iFCnt = iDelRow.Length - 1; iFCnt >= 0; iFCnt--)
			{
				if (iDelRow[iFCnt] == Ta080p01Constant.FLG_ON)
				{
					m1List.ListData.RemoveAt(iFCnt);
					m1List.RecordCount = m1List.RecordCount - 1;
				}
			}
			iCnt = 1;
			foreach (Ta080f03M1Form f03MVO in m1List.ListData)
			{
				f03MVO.M1rowno = (iCnt).ToString();
				iCnt++;
			}

			// 合計計算処理
			SumGoukeiDetail(f03VO);

			// 削除した分のページを追加
			AddRowCls.AddEmptyPage<Ta080f03M1Form>("M1", "M1rowno", f03VO);
		}
		#endregion

		#region 確定ボタン_後処理
		/// <summary>
		/// 一覧明細_選択行に更新内容を反映
		/// </summary>
		/// <param name="facadeContext"></param>
		/// <param name="f01VOSearched"></param>
		/// <param name="f01MVOSelected"></param>
		/// <param name="f03VO"></param>
		private void DoAfterUpd(IFacadeContext facadeContext, Ta080f01Form f01VOSearched, Ta080f01M1Form f01MVOSelected, Ta080f03Form f03VO)
		{
			// [選択モードNo]が「新規作成」の場合
			if (BoSystemConstant.MODE_INSERT.Equals(f03VO.Stkmodeno))
			{
				// コードビハインド側で設定
				return;
			}

			BindInfoVO bindVO = new BindInfoVO();
			ArrayList bindList = new ArrayList();
			StringBuilder sRepSql = new StringBuilder();

			// sql
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Ta080p01Constant.SQL_ID_02, facadeContext.DBContext);

			// 検索条件設定
			Ta080p01Util.SetBindDoSelect(f01VOSearched, reader);

			// 検索条件追 一覧明細指定

			// 店舗コード
			sRepSql.AppendLine(" AND T.TENPO_CD = :TENPO_CD");
			bindVO = new BindInfoVO();
			bindVO.BindId = "TENPO_CD";
			bindVO.Value = BoSystemFormat.formatTenpoCd(f01VOSearched.Head_tenpo_cd);
			bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			// 予算年月
			sRepSql.AppendLine(" AND T.YOSAN_YMD= :YOSAN_YMD");
			bindVO = new BindInfoVO();
			bindVO.BindId = "YOSAN_YMD";
			bindVO.Value = f01MVOSelected.M1yosan_ymd;
			bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			// 仕入枠グループコード
			sRepSql.AppendLine(" AND T.YOSAN_CD= :YOSAN_CD");
			bindVO = new BindInfoVO();
			bindVO.BindId = "YOSAN_CD";
			bindVO.Value = f01MVOSelected.Dictionary[Ta080p01Constant.DIC_M1YOSAN_CD].ToString();
			bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			BoSystemSql.AddSql(reader, "ADD_WHERE_T", sRepSql.ToString(), bindList);

			// SQL実行
			IList<Hashtable> result = reader.Execute();
			BoSystemLog.logOut("SQL: " + reader.LogSql);
			Hashtable rec = (Hashtable)result[0];

			f01MVOSelected.M1misinsei_su = BoSystemString.Nvl(rec["MISINSEI_SU"].ToString(), "0");					// Ｍ１未申請数
			f01MVOSelected.M1misinsei_kin = BoSystemString.Nvl(rec["MISINSEI_KIN"].ToString(), "0");				// Ｍ１未申請金額
			f01MVOSelected.M1applygokei_su = BoSystemString.Nvl(rec["SINSEI_SU"].ToString(), "0");					// Ｍ１申請数
			f01MVOSelected.M1applygokei_kin = BoSystemString.Nvl(rec["SINSEI_KIN"].ToString(), "0");				// Ｍ１申請金額
			f01MVOSelected.M1jissekigokei_su = rec["JISSEKIGOKEI_SU"].ToString();									// Ｍ１実績数
			f01MVOSelected.M1jissekigokei_kin = rec["JISSEKIGOKEI_KIN"].ToString();									// Ｍ１実績金額
			if (String.IsNullOrEmpty(rec["YOSAN_KIN"].ToString()))
			{
				f01MVOSelected.M1zan_kin = string.Empty;
			}
			else
			{
				f01MVOSelected.M1zan_kin = (Decimal.Parse(BoSystemString.Nvl(f01MVOSelected.M1yosan_kin, "0"))
						- Decimal.Parse(BoSystemString.Nvl(rec["SINSEI_KIN_MISOSIN"].ToString(), "0"))
						- Decimal.Parse(BoSystemString.Nvl(f01MVOSelected.M1jissekigokei_kin, "0"))
						- Decimal.Parse(BoSystemString.Nvl(rec["SINSEIZUMI_MIKAKUTEI_KIN"].ToString(), "0"))
						).ToString();
			}																										// Ｍ１残金額

			f01MVOSelected.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_ARI;									// 確定フラグの設定
			f01MVOSelected.Dictionary[Ta080p01Constant.DIC_M1LINKED_ITEM_SU] = rec["LINKED_ITEM_SU"];
			f01MVOSelected.Dictionary[Ta080p01Constant.DIC_M1LINKED_LAST_UPD_DATETIME] = rec["LINKED_LAST_UPD_DATETIME"];
			f01MVOSelected.Dictionary[Ta080p01Constant.DIC_M1SINSEI_SU_MISOSIN] = rec["SINSEI_SU_MISOSIN"];			// [Ｍ１未申請数(PC未送信)]
			f01MVOSelected.Dictionary[Ta080p01Constant.DIC_M1SINSEI_KIN_MISOSIN] = rec["SINSEI_KIN_MISOSIN"];		// [Ｍ１未申請金額(PC未送信)]
			f01MVOSelected.Dictionary[Ta080p01Constant.DIC_M1SINSEIZUMI_MIKAKUTEI_KIN] = rec["SINSEIZUMI_MIKAKUTEI_KIN"];	// [Ｍ１申請済み未確定金額]
		}
		#endregion

		#region 合計計算処理
		/// <summary>
		/// SumGoukeiDetail 合計計算処理
		/// </summary>
		/// <param name="Ta080f03Form">f02VO</param>
		/// <returns></returns>
		public void SumGoukeiDetail(Ta080f03Form f03VO)
		{
			decimal dSumSu = 0;		// 合計数量
			decimal dSumKin = 0;	// 合計金額

			foreach (Ta080f03M1Form f03MVO in f03VO.GetList("M1").ListData)
			{
				dSumSu += Convert.ToDecimal(BoSystemString.Nvl(f03MVO.M1irai_su, "0"));					// 合計数量
				dSumKin += Convert.ToDecimal(BoSystemString.Nvl(f03MVO.M1genkakin, "0"));					// 合計金額
			}
			f03VO.Gokei_irai_su = dSumSu.ToString();
			f03VO.Gokei_genkakin = dSumKin.ToString();
		}
		#endregion

		#region モード別明細更新対象判定
		/// <summary>
		/// 渡された明細行が現モードの更新対象行かを判断する。
		/// 対象行の場合true
		/// </summary>
		/// <param name="f03VO"></param>
		/// <param name="f03MVO"></param>
		/// <returns></returns>
		public bool ChkUpdRow(Ta080f03Form f03VO, Ta080f03M1Form f03MVO)
		{
			bool bRowFlg = false;
			// モード「新規作成」
			if (BoSystemConstant.MODE_INSERT.Equals(f03VO.Stkmodeno))
			{
				// 処理対象：スキャンコード入力行
				if (!string.IsNullOrEmpty(f03MVO.M1scan_cd.Trim()))
				{
					bRowFlg = true;
				}
			}
			// モード「申請」
			else if (BoSystemConstant.MODE_APPLY.Equals(f03VO.Stkmodeno))
			{
				// 処理対象：選択行
				if (f03MVO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
				{
					bRowFlg = true;
				}
			}
			// モード「申請前修正」
			else if (BoSystemConstant.MODE_SINSEIMAEUPD.Equals(f03VO.Stkmodeno))
			{
				// 処理対象：変更行
				if (f03MVO.M1entersyoriflg.Equals(BoSystemConstant.CHECKBOX_ON))
				{
					bRowFlg = true;
				}
			}
			// モード「申請取消」
			// 処理対象：選択行
			else if (BoSystemConstant.MODE_SINSEIZUMITORIKESI.Equals(f03VO.Stkmodeno))
			{
				// 処理対象：選択行
				if (f03MVO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
				{
					bRowFlg = true;
				}
			}

			return bRowFlg;
		}
		#endregion 
	}
}
