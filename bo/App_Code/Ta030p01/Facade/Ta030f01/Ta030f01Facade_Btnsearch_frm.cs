using com.xebio.bo.Ta030p01.Constant;
using com.xebio.bo.Ta030p01.Formvo;
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
using Common.Business.V01000.V01010;
using Common.Business.V01000.V01012;
using Common.Business.V03000.V03001;
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

namespace com.xebio.bo.Ta030p01.Facade
{
  /// <summary>
  /// Ta030f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Ta030f01Facade : StandardBaseFacade
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

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Ta030f01Form f03VO = (Ta030f01Form)facadeContext.FormVO;
				IDataList m1List = f03VO.GetList("M1");

				Ta030f02Form f02VO = new Ta030f02Form();
				//Ta030f01Form f02VO = (Ta030f02Form)facadeContext.FormVO;
				IDataList m1List2 = f02VO.GetList("M1");

				// 選択モードNoの初期化
				f03VO.Stkmodeno = string.Empty;

				// 合計欄の初期化
				f03VO.Gokei_itemsu = string.Empty;
				f03VO.Gokei_kingaku = string.Empty;

				// 一覧の初期化
				m1List.ClearCacheData();
				m1List.Clear();
				m1List2.ClearCacheData();
				m1List2.Clear();

				#endregion

				#region 業務チェック

				#region マスタ存在チェック

				// 1-1 ヘッダ店舗コード
				//       店舗マスタを検索し、存在しない場合エラー
				//f03VO.Head_tenpo_nm = string.Empty;
				if (!string.IsNullOrEmpty(f03VO.Head_tenpo_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01001Check.CheckTenpo(f03VO.Head_tenpo_cd, facadeContext, "店舗", new[] { "Head_tenpo_cd" });
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f03VO.Head_tenpo_nm = (string)resultHash["TENPO_NM"];
					}
				}

				// 1-2 仕入先コード
				//       仕入先マスタを検索し、存在しない場合エラー
				//f03VO.Siiresaki_ryaku_nm = string.Empty;
				if (!string.IsNullOrEmpty(f03VO.Siiresaki_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01002Check.CheckShiiresaki(f03VO.Siiresaki_cd
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
						f03VO.Siiresaki_ryaku_nm = (string)resultHash["SIIRESAKI_RYAKU_NM"];
					}
				}
				
				// 1-3 部門コード
				//       部門マスタを検索し、存在しない場合エラー
				//f03VO.Bumon_nm = string.Empty;
				if (!string.IsNullOrEmpty(f03VO.Bumon_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01010Check.CheckBumon(f03VO.Bumon_cd
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
						f03VO.Bumon_nm = (string)resultHash["BUMON_NM"];
					}
				}

				// 1-4 ブランドコード
				//       ブランドマスタを検索し、存在しない場合エラー
				if (!string.IsNullOrEmpty(f03VO.Burando_cd))
				{
					Hashtable resultHash = new Hashtable();
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
						f03VO.Burando_nm = (string)resultHash["BURANDO_NMK"];
					}
				}

				// 2-3 自社品番
				//       発注マスタを検索し、存在しない場合エラー
				f03VO.Dictionary[Ta030p01Constant.DIC_SEARCH_XEBIOCD] = string.Empty;
				f03VO.Maker_hbn = string.Empty;
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
						f03VO.Dictionary[Ta030p01Constant.DIC_SEARCH_XEBIOCD] = (string)resultHash["XEBIO_CD"];
						f03VO.Maker_hbn = (string)resultHash["HIN_NBR"];
					}
				}


				// 1-6 スキャンコード
				//       発注マスタを検索し、存在しない場合エラー
				f03VO.Dictionary[Ta030p01Constant.DIC_SEARCH_JANCD] = string.Empty;
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
					Hashtable hs = V01004Check.CheckScanCd(searchConditionVO, facadeContext, "スキャンコード", new[] { "Scan_cd" });
					if (hs != null)
					{
						// JANコードをディクショナリに退避
						f03VO.Dictionary[Ta030p01Constant.DIC_SEARCH_JANCD] = (string)hs["JAN_CD"];
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region 関連項目チェック
				//2-1 発注日FROM、発注日TO
				//      発注日FROM > 発注日ＴＯの場合エラー
				if (!string.IsNullOrEmpty(f03VO.Hattyu_ymd_from) && !string.IsNullOrEmpty(f03VO.Hattyu_ymd_to))
				{
					V03001Check.DateFromToChk(
						f03VO.Hattyu_ymd_from,
						f03VO.Hattyu_ymd_to,
						facadeContext,
						"発注日",
						new[] { "Hattyu_ymd_from", "Hattyu_ymd_to" }
				 );
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region 件数チェック

				#region テーブルID設定
				// テーブルIDを設定 -----------

				FindSqlResultTable rtChk = new FindSqlResultTable();
				FindSqlResultTable rtSearch = new FindSqlResultTable();
				ArrayList bindList = new ArrayList();
				BindInfoVO bindVO = new BindInfoVO();
				StringBuilder sRepSql = new StringBuilder();
				Decimal dCnt = 0;



				// [モードNO]が「照会部門別」の場合
				if (f03VO.Modeno.Equals(BoSystemConstant.MODE_REF_BUMON))
				{
					BoSystemLog.logOut("[補充依頼結果TBL(H)]を検索 START");
					// [区分]が未選択の場合
					if (f03VO.Kbn_cd.Equals(BoSystemConstant.DROPDOWNLIST_MISENTAKU))
					{
						//「申請状態」が未選択の場合
						if (f03VO.Shinsei_flg.Equals(BoSystemConstant.DROPDOWNLIST_MISENTAKU))
						{
							rtSearch = FindSqlUtil.CreateFindSqlResultTable(Ta030p01Constant.SQL_HEAD_ID_01_02_03_04, facadeContext.DBContext);
							AddWhere(f03VO, rtSearch, BoSystemConstant.DROPDOWNLIST_MISENTAKU, Ta030p01Constant.SQL_HEAD_ID_01_ADD_WHERE);
							AddWhere(f03VO, rtSearch, BoSystemConstant.DROPDOWNLIST_MISENTAKU, Ta030p01Constant.SQL_HEAD_ID_02_ADD_WHERE);
							AddWhere(f03VO, rtSearch, BoSystemConstant.DROPDOWNLIST_MISENTAKU, Ta030p01Constant.SQL_HEAD_ID_03_ADD_WHERE);
							AddWhere(f03VO, rtSearch, BoSystemConstant.DROPDOWNLIST_MISENTAKU, Ta030p01Constant.SQL_HEAD_ID_04_ADD_WHERE);
						}
						//「申請状態」が未申請の場合
						else if (f03VO.Shinsei_flg.Equals(ConditionSinsei_jotai.VALUE_SINSEI_JOTAI1))
						{
							rtSearch = FindSqlUtil.CreateFindSqlResultTable(Ta030p01Constant.SQL_HEAD_ID_01_03, facadeContext.DBContext);
							AddWhere(f03VO, rtSearch, BoSystemConstant.DROPDOWNLIST_MISENTAKU, Ta030p01Constant.SQL_HEAD_ID_01_ADD_WHERE);
							AddWhere(f03VO, rtSearch, BoSystemConstant.DROPDOWNLIST_MISENTAKU, Ta030p01Constant.SQL_HEAD_ID_03_ADD_WHERE);
						}
						//「申請状態」が申請済の場合
						//else if (f03VO.Shinsei_flg.Equals(ConditionSinsei_jotai.VALUE_SINSEI_JOTAI2))
						else
						{
							rtSearch = FindSqlUtil.CreateFindSqlResultTable(Ta030p01Constant.SQL_HEAD_ID_02_04, facadeContext.DBContext);
							AddWhere(f03VO, rtSearch, BoSystemConstant.DROPDOWNLIST_MISENTAKU, Ta030p01Constant.SQL_HEAD_ID_02_ADD_WHERE);
							AddWhere(f03VO, rtSearch, BoSystemConstant.DROPDOWNLIST_MISENTAKU, Ta030p01Constant.SQL_HEAD_ID_04_ADD_WHERE);
						}
					}
					//[区分]が補充依頼または単品レポートの場合
					else if (f03VO.Kbn_cd.Equals(ConditionHojuirai_kbn2.VALUE_HOJUIRAI_KBN21) || f03VO.Kbn_cd.Equals(ConditionHojuirai_kbn2.VALUE_HOJUIRAI_KBN22))
					{
						//「申請状態」が未選択の場合（SQL① UNION ALL ②）
						if (f03VO.Shinsei_flg.Equals(BoSystemConstant.DROPDOWNLIST_MISENTAKU))
						{
							rtSearch = FindSqlUtil.CreateFindSqlResultTable(Ta030p01Constant.SQL_HEAD_ID_01_02, facadeContext.DBContext);
							AddWhere(f03VO, rtSearch, BoSystemConstant.DROPDOWNLIST_MISENTAKU, Ta030p01Constant.SQL_HEAD_ID_01_ADD_WHERE);
							AddWhere(f03VO, rtSearch, BoSystemConstant.DROPDOWNLIST_MISENTAKU, Ta030p01Constant.SQL_HEAD_ID_02_ADD_WHERE);
						}
						//「申請状態」が未申請の場合（SQL①）
						else if (f03VO.Shinsei_flg.Equals(ConditionSinsei_jotai.VALUE_SINSEI_JOTAI1))
						{
							rtSearch = FindSqlUtil.CreateFindSqlResultTable(Ta030p01Constant.SQL_HEAD_ID_01, facadeContext.DBContext);
							AddWhere(f03VO, rtSearch, BoSystemConstant.DROPDOWNLIST_MISENTAKU, Ta030p01Constant.SQL_HEAD_ID_01_ADD_WHERE);

						}
						//「申請状態」が申請済の場合（SQL②）
						//else if (f03VO.Shinsei_flg.Equals(ConditionSinsei_jotai.VALUE_SINSEI_JOTAI2))
						else
						{
							rtSearch = FindSqlUtil.CreateFindSqlResultTable(Ta030p01Constant.SQL_HEAD_ID_02, facadeContext.DBContext);
							AddWhere(f03VO, rtSearch, BoSystemConstant.DROPDOWNLIST_MISENTAKU, Ta030p01Constant.SQL_HEAD_ID_02_ADD_WHERE);
						}
					}
					//[区分]が出荷要望の場合
					//else if(f03VO.Kbn_cd.Equals(ConditionHojuirai_kbn2.VALUE_HOJUIRAI_KBN23))
					else
					{
						//「申請状態」が未選択の場合（SQL③ UNION ALL ④）
						if (f03VO.Shinsei_flg.Equals(BoSystemConstant.DROPDOWNLIST_MISENTAKU))
						{
							rtSearch = FindSqlUtil.CreateFindSqlResultTable(Ta030p01Constant.SQL_HEAD_ID_03_04, facadeContext.DBContext);
							AddWhere(f03VO, rtSearch, BoSystemConstant.DROPDOWNLIST_MISENTAKU, Ta030p01Constant.SQL_HEAD_ID_03_ADD_WHERE);
							AddWhere(f03VO, rtSearch, BoSystemConstant.DROPDOWNLIST_MISENTAKU, Ta030p01Constant.SQL_HEAD_ID_04_ADD_WHERE);
						}
						//「申請状態」が未申請の場合（SQL③）
						else if (f03VO.Shinsei_flg.Equals(ConditionSinsei_jotai.VALUE_SINSEI_JOTAI1))
						{
							rtSearch = FindSqlUtil.CreateFindSqlResultTable(Ta030p01Constant.SQL_HEAD_ID_03, facadeContext.DBContext);
							AddWhere(f03VO, rtSearch, BoSystemConstant.DROPDOWNLIST_MISENTAKU, Ta030p01Constant.SQL_HEAD_ID_03_ADD_WHERE);
						}
						//「申請状態」が申請済の場合（SQL④）
						//else if (f03VO.Shinsei_flg.Equals(ConditionSinsei_jotai.VALUE_SINSEI_JOTAI2))
						else
						{
							rtSearch = FindSqlUtil.CreateFindSqlResultTable(Ta030p01Constant.SQL_HEAD_ID_04, facadeContext.DBContext);
							AddWhere(f03VO, rtSearch, BoSystemConstant.DROPDOWNLIST_MISENTAKU, Ta030p01Constant.SQL_HEAD_ID_04_ADD_WHERE);
						}
					}
					BoSystemLog.logOut("[補充依頼結果TBL(H)]を検索 END");
				}
				// [モードNO]が「照会単品別」の場合
				else 
				{
					BoSystemLog.logOut("[補充依頼結果TBL(B)]を検索 START");
					// [区分]が未選択の場合
					if (f03VO.Kbn_cd.Equals(BoSystemConstant.DROPDOWNLIST_MISENTAKU))
					{
						//「申請状態」が未選択の場合
						if (f03VO.Shinsei_flg.Equals(BoSystemConstant.DROPDOWNLIST_MISENTAKU))
						{
							rtSearch = FindSqlUtil.CreateFindSqlResultTable(Ta030p01Constant.SQL_DETAIL_ID_01_02_03_04, facadeContext.DBContext);
							AddWhere(f03VO, rtSearch, BoSystemConstant.DROPDOWNLIST_MISENTAKU, Ta030p01Constant.SQL_DETAIL_ID_01_ADD_WHERE);
							AddWhere(f03VO, rtSearch, BoSystemConstant.DROPDOWNLIST_MISENTAKU, Ta030p01Constant.SQL_DETAIL_ID_02_ADD_WHERE);
							AddWhere(f03VO, rtSearch, BoSystemConstant.DROPDOWNLIST_MISENTAKU, Ta030p01Constant.SQL_DETAIL_ID_03_ADD_WHERE);
							AddWhere(f03VO, rtSearch, BoSystemConstant.DROPDOWNLIST_MISENTAKU, Ta030p01Constant.SQL_DETAIL_ID_04_ADD_WHERE);
						}
						//「申請状態」が未申請の場合
						else if (f03VO.Shinsei_flg.Equals(ConditionSinsei_jotai.VALUE_SINSEI_JOTAI1))
						{
							rtSearch = FindSqlUtil.CreateFindSqlResultTable(Ta030p01Constant.SQL_DETAIL_ID_01_03, facadeContext.DBContext);
							AddWhere(f03VO, rtSearch, BoSystemConstant.DROPDOWNLIST_MISENTAKU, Ta030p01Constant.SQL_DETAIL_ID_01_ADD_WHERE);
							AddWhere(f03VO, rtSearch, BoSystemConstant.DROPDOWNLIST_MISENTAKU, Ta030p01Constant.SQL_DETAIL_ID_03_ADD_WHERE);
						}
						//「申請状態」が申請済の場合
						//else if (f03VO.Shinsei_flg.Equals(ConditionSinsei_jotai.VALUE_SINSEI_JOTAI2))
						else
						{
							rtSearch = FindSqlUtil.CreateFindSqlResultTable(Ta030p01Constant.SQL_DETAIL_ID_02_04, facadeContext.DBContext);
							AddWhere(f03VO, rtSearch, BoSystemConstant.DROPDOWNLIST_MISENTAKU, Ta030p01Constant.SQL_DETAIL_ID_02_ADD_WHERE);
							AddWhere(f03VO, rtSearch, BoSystemConstant.DROPDOWNLIST_MISENTAKU, Ta030p01Constant.SQL_DETAIL_ID_04_ADD_WHERE);
						}
					}
					//[区分]が補充依頼または単品レポートの場合
					else if (f03VO.Kbn_cd.Equals(ConditionHojuirai_kbn2.VALUE_HOJUIRAI_KBN21) || f03VO.Kbn_cd.Equals(ConditionHojuirai_kbn2.VALUE_HOJUIRAI_KBN22))
					{
						//「申請状態」が未選択の場合（SQL① UNION ALL ②）
						if (f03VO.Shinsei_flg.Equals(BoSystemConstant.DROPDOWNLIST_MISENTAKU))
						{
							rtSearch = FindSqlUtil.CreateFindSqlResultTable(Ta030p01Constant.SQL_DETAIL_ID_01_02, facadeContext.DBContext);
							AddWhere(f03VO, rtSearch, BoSystemConstant.DROPDOWNLIST_MISENTAKU, Ta030p01Constant.SQL_DETAIL_ID_01_ADD_WHERE);
							AddWhere(f03VO, rtSearch, BoSystemConstant.DROPDOWNLIST_MISENTAKU, Ta030p01Constant.SQL_DETAIL_ID_02_ADD_WHERE);
						}
						//「申請状態」が未申請の場合（SQL①）
						else if (f03VO.Shinsei_flg.Equals(ConditionSinsei_jotai.VALUE_SINSEI_JOTAI1))
						{
							//部門LINK押下時に発行されるSQLを利用
							rtSearch = FindSqlUtil.CreateFindSqlResultTable(Ta030p01Constant.SQL_DETAIL_ID_01, facadeContext.DBContext);
							AddWhere(f03VO, rtSearch, BoSystemConstant.DROPDOWNLIST_MISENTAKU, Ta030p01Constant.SQL_DETAIL_ID_01_ADD_WHERE);

						}
						//「申請状態」が申請済の場合（SQL②）
						//else if (f03VO.Shinsei_flg.Equals(ConditionSinsei_jotai.VALUE_SINSEI_JOTAI2))
						else
						{
							//部門LINK押下時に発行されるSQLを利用
							rtSearch = FindSqlUtil.CreateFindSqlResultTable(Ta030p01Constant.SQL_DETAIL_ID_02, facadeContext.DBContext);
							AddWhere(f03VO, rtSearch, BoSystemConstant.DROPDOWNLIST_MISENTAKU, Ta030p01Constant.SQL_DETAIL_ID_02_ADD_WHERE);
						}
					}
					//[区分]が出荷要望の場合
					//else if(f03VO.Kbn_cd.Equals(ConditionHojuirai_kbn2.VALUE_HOJUIRAI_KBN23))
					else
					{
						//「申請状態」が未選択の場合（SQL③ UNION ALL ④）
						if (f03VO.Shinsei_flg.Equals(BoSystemConstant.DROPDOWNLIST_MISENTAKU))
						{
							rtSearch = FindSqlUtil.CreateFindSqlResultTable(Ta030p01Constant.SQL_DETAIL_ID_03_04, facadeContext.DBContext);
							AddWhere(f03VO, rtSearch, BoSystemConstant.DROPDOWNLIST_MISENTAKU, Ta030p01Constant.SQL_DETAIL_ID_03_ADD_WHERE);
							AddWhere(f03VO, rtSearch, BoSystemConstant.DROPDOWNLIST_MISENTAKU, Ta030p01Constant.SQL_DETAIL_ID_04_ADD_WHERE);
						}
						//「申請状態」が未申請の場合（SQL③）
						else if (f03VO.Shinsei_flg.Equals(ConditionSinsei_jotai.VALUE_SINSEI_JOTAI1))
						{
							//部門LINK押下時に発行されるSQLを利用
							rtSearch = FindSqlUtil.CreateFindSqlResultTable(Ta030p01Constant.SQL_DETAIL_ID_03, facadeContext.DBContext);
							AddWhere(f03VO, rtSearch, BoSystemConstant.DROPDOWNLIST_MISENTAKU, Ta030p01Constant.SQL_DETAIL_ID_03_ADD_WHERE);
						}
						//「申請状態」が申請済の場合（SQL④）
						//else if (f03VO.Shinsei_flg.Equals(ConditionSinsei_jotai.VALUE_SINSEI_JOTAI2))
						else
						{
							//部門LINK押下時に発行されるSQLを利用
							rtSearch = FindSqlUtil.CreateFindSqlResultTable(Ta030p01Constant.SQL_DETAIL_ID_04, facadeContext.DBContext);
							AddWhere(f03VO, rtSearch, BoSystemConstant.DROPDOWNLIST_MISENTAKU, Ta030p01Constant.SQL_DETAIL_ID_04_ADD_WHERE);
						}
					}
					BoSystemLog.logOut("[補充依頼結果TBL(B)]を検索 END");
				}
				

				#endregion

				#region 検索チェック

				//検索結果を取得します
				rtSearch.CreateDbCommand();
				IList<Hashtable> tableListcnt = rtSearch.Execute();

				if (logger.IsDebugEnabled)
				{
					logger.Debug("SQL: " + rtSearch.LogSql);
				}

				if (tableListcnt == null || tableListcnt.Count <= 0)
				{
					// エラー
					ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
				}
				else
				{
					//Hashtable resultTbl = tableListcnt.Count;
					dCnt = (Decimal)tableListcnt.Count;

					//0件チェック
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
				//f03VO.Searchcnt = dCnt.ToString();

				#endregion
				#endregion

				#endregion

				#region 検索処理

				//検索結果を取得します
				rtSearch.CreateDbCommand();
				IList<Hashtable> tableList = rtSearch.Execute();

				// [モードNO]が「照会部門別」の場合
				if (f03VO.Modeno.Equals(BoSystemConstant.MODE_REF_BUMON))
				{
					decimal sumSuryoGokei = 0;	// 数量合計
					decimal sumKingakuGokei = 0;		// 金額合計

					int iCnt = 0;
					foreach (Hashtable rec in tableList)
					{
						iCnt++;
						Ta030f01M1Form f01m1VO = new Ta030f01M1Form();

						f01m1VO.M1rowno = iCnt.ToString();								// Ｍ１行NO
						f01m1VO.M1hojuirai_kbn_nm = rec["KBN_NM"].ToString();			// Ｍ１区分
						f01m1VO.M1sinsei_jotainm = rec["SHINSEI_NM"].ToString();	    // Ｍ１状態区分
						f01m1VO.M1itemsu = rec["SUM_SURYO"].ToString();					// Ｍ１数量
						f01m1VO.M1kingaku = rec["SUM_KINGAKU"].ToString();				// Ｍ１金額

						// Ｍ１選択フラグ(隠し)
						f01m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;
						// Ｍ１確定処理フラグ(隠し)
						f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;
						// Ｍ１明細色区分(隠し)
						f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;			// Ｍ１明細色区分(隠し)

						// Dictionary
						f01m1VO.Dictionary.Add(Ta030p01Constant.DIC_M1TENPO_CD, f03VO.Head_tenpo_cd);				// 店舗コード
						f01m1VO.Dictionary.Add(Ta030p01Constant.DIC_M1BUMON_CD, rec["BUMON_CD"].ToString());		// 部門コード
						f01m1VO.Dictionary.Add(Ta030p01Constant.DIC_M1BUMONKANA_NM, rec["BUMON_NM"].ToString());	// 部門カナ名                    
						f01m1VO.Dictionary.Add(Ta030p01Constant.DIC_M1KBN_CD, rec["KBN_CD"].ToString());			// 区分コード
						f01m1VO.Dictionary.Add(Ta030p01Constant.DIC_M1SHINSEI_FLG, rec["SHINSEI_FLG"].ToString());	// 申請状態
						f01m1VO.Dictionary.Add(Ta030p01Constant.DIC_M1BURANDO_CD, f03VO.Burando_cd);				// ブランド
						f01m1VO.Dictionary.Add(Ta030p01Constant.DIC_M1UPD_YMD_FROM, f03VO.Hattyu_ymd_from);			// 発注日FROM
						f01m1VO.Dictionary.Add(Ta030p01Constant.DIC_M1UPD_YMD_TO, f03VO.Hattyu_ymd_to);				// 発注日TO
						f01m1VO.Dictionary.Add(Ta030p01Constant.DIC_M1JISYA_HBN, f03VO.Old_jisya_hbn);				// 自社品番
						f01m1VO.Dictionary.Add(Ta030p01Constant.DIC_M1JAN_CD, f03VO.Scan_cd);						// スキャンコード
						

						// 合計値加算
						sumSuryoGokei += Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1itemsu, "0"));
						sumKingakuGokei += Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1kingaku, "0"));

						//リストオブジェクトにM1Formを追加します。
						m1List.Add(f01m1VO, true);
					}

					// 合計欄の設定
					f03VO.Gokei_itemsu = sumSuryoGokei.ToString();
					f03VO.Gokei_kingaku = sumKingakuGokei.ToString();

					// 検索件数の設定
					f03VO.Searchcnt = m1List.Count.ToString();

					// モードNoを選択モードNoへ設定
					f03VO.Stkmodeno = f03VO.Modeno;
				}
				// [モードNO]が「照会単品別」の場合
				else
				{


					decimal sumSuryoGokei = 0;	    // 数量合計
					decimal sumKingakuGokei = 0;	// 金額合計

					int iCnt = 0;
					foreach (Hashtable rec in tableList)
					{
						iCnt++;
						Ta030f02M1Form f02m1VO = new Ta030f02M1Form();
						

						f02m1VO.M1rowno = iCnt.ToString();								// Ｍ１行NO
						f02m1VO.M1hojuirai_kbn_nm = rec["KBN_NM"].ToString();			// Ｍ１区分
						f02m1VO.M1sinsei_jotainm = rec["SHINSEI_NM"].ToString();	    // Ｍ１状態区分

						f02m1VO.M1bumon_cd_bo = rec["BUMON_CD"].ToString();				// Ｍ１部門コード
						f02m1VO.M1bumonkana_nm = rec["BUMON_NM"].ToString();			// Ｍ１部門名
						f02m1VO.M1hinsyu_ryaku_nm = rec["HINSYU_RYAKU_NM"].ToString();	// Ｍ１品種名
						f02m1VO.M1burando_nm = rec["BURANDO_NMK"].ToString();			// Ｍ１ブランド
						f02m1VO.M1jisya_hbn = rec["JISYA_HBN"].ToString();				// Ｍ１自社品番
						f02m1VO.M1syohin_zokusei = rec["SYOHIN_ZOKUSEI"].ToString();	// Ｍ１コア(商品属性）
						f02m1VO.M1maker_hbn = rec["HIN_NBR"].ToString();				// Ｍ１メーカー品番
						f02m1VO.M1syonmk = rec["SYONMK"].ToString();					// Ｍ１商品名
						f02m1VO.M1iro_nm = rec["IRO_RYAKU_NM"].ToString();				// Ｍ１色
						f02m1VO.M1size_nm = rec["SIZE_NM"].ToString();					// Ｍ１サイズ
						f02m1VO.M1scan_cd = rec["JAN_CD"].ToString();					// Ｍ１スキャンコード
						f02m1VO.M1itemsu = rec["IRAI_SU"].ToString();					// Ｍ１数量
						f02m1VO.M1kingaku = rec["IRAI_KIN"].ToString();					// Ｍ１金額
						f02m1VO.M1hattyu_ymd = rec["UPD_YMD"].ToString();				// Ｍ１発注日
						f02m1VO.M1hanbaiin_nm = rec["HANBAIIN_NM"].ToString();			// Ｍ１担当者

						f02m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;		// Ｍ１選択フラグ(隠し)
						f02m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;	// Ｍ１確定処理フラグ(隠し)

						// Ｍ１選択フラグ(隠し)
						f02m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;
						// Ｍ１確定処理フラグ(隠し)
						f02m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;

						string xebiocd = (string)f03VO.Dictionary[Ta030p01Constant.DIC_SEARCH_XEBIOCD];
						string jancd = (string)f03VO.Dictionary[Ta030p01Constant.DIC_SEARCH_JANCD];
						if (xebiocd.Equals(f02m1VO.M1jisya_hbn) || jancd.Equals(f02m1VO.M1scan_cd))
						{
							// 一覧画面で入力されたスキャンコードが一致する場合、背景色変更
							f02m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_SHOHIN_SHITEI;	// Ｍ１明細色区分(隠し)
						}
						else
						{
							// Ｍ１明細色区分(隠し)
							f02m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;			// Ｍ１明細色区分(隠し)
						}

						// Dictionary
						f02m1VO.Dictionary.Add(Ta030p01Constant.DIC_M1TENPO_CD, f03VO.Head_tenpo_cd);				// 店舗コード
						f02m1VO.Dictionary.Add(Ta030p01Constant.DIC_M1BUMON_CD, rec["BUMON_CD"].ToString());		// 部門コード
						f02m1VO.Dictionary.Add(Ta030p01Constant.DIC_M1BUMONKANA_NM, rec["BUMON_NM"].ToString());	// 部門カナ名 
						

						// 合計値加算
						sumSuryoGokei += Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1itemsu, "0"));
						sumKingakuGokei += Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1kingaku, "0"));

						//リストオブジェクトにM1Formを追加します。
						m1List2.Add(f02m1VO, true);

						// 合計欄の設定
						f02VO.Gokei_itemsu = sumSuryoGokei.ToString();
						f02VO.Gokei_kingaku = sumKingakuGokei.ToString();
					}

					#region カード部設定
					// ヘッダ店舗コード
					f02VO.Head_tenpo_cd = f03VO.Head_tenpo_cd;
					// ヘッダ店舗名
					f02VO.Head_tenpo_nm = f03VO.Head_tenpo_nm;
					//選択モードNo
					f02VO.Dictionary[Ta030p01Constant.DIC_MODENO] = f03VO.Modeno.ToString();		
					#endregion

					// モードNoを選択モードNoへ設定
					f03VO.Stkmodeno = f03VO.Modeno;

					facadeContext.SetUserObject(Ta030p01Constant.FCDUO_NEXTVO, f02VO);

					//一覧画面戻り時のフォーカス項目
					Ta030f01Form f01VO = (Ta030f01Form)facadeContext.FormVO;
					f01VO.Dictionary[Ta030p01Constant.DIC_FOCUS_ITEM] = "Head_tenpo_cd";
				}

				// 検索条件を退避
				SearchConditionSaveCls.SearchConditionSave(f03VO);

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
		/// <param name="f01VO">Td030f01Form</param>
		/// <param name="FindSqlResultTable">rtChk</param>
		/// <param name="string">denpyo_jyotai</param>
		/// <param name="string">add_where_id</param>
		/// <returns></returns>
		
		#region 検索条件設定
		private void AddWhere(Ta030f01Form f03VO, FindSqlResultTable reader, string DROPDOWNLIST, string add_where_id)
		{
			ArrayList bindList = new ArrayList();
			BindInfoVO bindVO = new BindInfoVO();
			StringBuilder sRepSql = new StringBuilder();			

			// 検索条件を設定 -----------
			sRepSql = new StringBuilder();

			// バインド変数
			string add_bind = "";
			if (add_where_id.Equals(Ta030p01Constant.SQL_HEAD_ID_01_ADD_WHERE) || add_where_id.Equals(Ta030p01Constant.SQL_DETAIL_ID_01_ADD_WHERE))
			{
				add_bind = "01";
			}
			else if (add_where_id.Equals(Ta030p01Constant.SQL_HEAD_ID_02_ADD_WHERE) || add_where_id.Equals(Ta030p01Constant.SQL_DETAIL_ID_02_ADD_WHERE))
			{
				add_bind = "02";
			}
			else if (add_where_id.Equals(Ta030p01Constant.SQL_HEAD_ID_03_ADD_WHERE) || add_where_id.Equals(Ta030p01Constant.SQL_DETAIL_ID_03_ADD_WHERE))
			{
				add_bind = "03";
			}
			else if (add_where_id.Equals(Ta030p01Constant.SQL_HEAD_ID_04_ADD_WHERE) || add_where_id.Equals(Ta030p01Constant.SQL_DETAIL_ID_04_ADD_WHERE))
			{
				add_bind = "04";
			}

			// 「店舗コード」を設定
			sRepSql.Append(" AND T1.TENPO_CD = :BIND_TENPO_CD_" + add_bind);
			bindVO = new BindInfoVO();
			bindVO.BindId = "BIND_TENPO_CD_" + add_bind;
			bindVO.Value = BoSystemFormat.formatTenpoCd(f03VO.Head_tenpo_cd);
			bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
			bindList.Add(bindVO);
			
			// 区分を設定
			// 補充発注申請または補充依頼確定の場合のみ設定
			if (add_where_id.Equals(Ta030p01Constant.SQL_HEAD_ID_01_ADD_WHERE) || add_where_id.Equals(Ta030p01Constant.SQL_HEAD_ID_02_ADD_WHERE)
				|| add_where_id.Equals(Ta030p01Constant.SQL_DETAIL_ID_01_ADD_WHERE) || add_where_id.Equals(Ta030p01Constant.SQL_DETAIL_ID_02_ADD_WHERE))
			{
				//「区分」が未選択の場合
				if (f03VO.Kbn_cd.Equals(BoSystemConstant.DROPDOWNLIST_MISENTAKU) )
				{
					//string add_Val = "1','2";
					sRepSql.Append(" AND T1.KBN_CD in (1, :BIND_KBN_CD_" + add_bind);
					sRepSql.Append(" 	  )");
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_KBN_CD_" + add_bind;
					//bindVO.Value = add_Val;
					bindVO.Value = "2";
				}
				//「区分」が選択されていた場合、補充依頼か単品レポートを設定
				else
				{
					sRepSql.Append(" AND T1.KBN_CD = :BIND_KBN_CD_" + add_bind);
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_KBN_CD_" + add_bind;
					bindVO.Value = f03VO.Kbn_cd;
				}

				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 「申請状態」を設定
			// 補充発注申請または出荷要望申請の場合のみ適用
			if (add_where_id.Equals(Ta030p01Constant.SQL_HEAD_ID_01_ADD_WHERE) || add_where_id.Equals(Ta030p01Constant.SQL_HEAD_ID_03_ADD_WHERE)
				||add_where_id.Equals(Ta030p01Constant.SQL_DETAIL_ID_01_ADD_WHERE) || add_where_id.Equals(Ta030p01Constant.SQL_DETAIL_ID_03_ADD_WHERE))
			{	
				sRepSql.Append(" AND T1.SHINSEI_FLG = :BIND_SHINSEI_FLG_" + add_bind);
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SHINSEI_FLG_" + add_bind;
				bindVO.Value = "0";
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}
			
			// 「仕入先コード」を設定
			// 「仕入先コード」が空白でない場合のみ適用
			if (!string.IsNullOrEmpty(f03VO.Siiresaki_cd))
			{	
				sRepSql.Append(" AND  EXISTS ( ");
				sRepSql.Append("       SELECT 1");
				sRepSql.Append("       FROM MDMT0130 M1");
				sRepSql.Append("       WHERE M1.JAN_CD = T2.JAN_CD");
				sRepSql.Append("       AND    M1.SIIRESAKI_CD = :BIND_SIIRESAKI_CD_" + add_bind);
				sRepSql.Append(" 	  )");
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SIIRESAKI_CD_" + add_bind;
				bindVO.Value = BoSystemFormat.formatSiiresakiCd(f03VO.Siiresaki_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}
			
			// 「部門コード」を設定
			// 「部門コード」が空白でない場合のみ適用
			if (!string.IsNullOrEmpty(f03VO.Bumon_cd))
			{
				sRepSql.Append(" AND T2.BUMON_CD = :BIND_BUMON_CD_" + add_bind);
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_BUMON_CD_" + add_bind;
				bindVO.Value = BoSystemFormat.formatBumonCd(f03VO.Bumon_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}
			
			// 「ブランドコード」を設定
			// 「ブランドコード」が空白でない場合のみ適用
			if (!string.IsNullOrEmpty(f03VO.Burando_cd))
			{				
				sRepSql.Append(" AND T2.BURANDO_CD = :BIND_BURANDO_CD_" + add_bind);
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_BURANDO_CD_" + add_bind;
				bindVO.Value = BoSystemFormat.formatBrandCd(f03VO.Burando_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}
			
			//「発注日FROM」を設定
			// 「発注日FROM」が空白でない場合のみ適用
			if (!string.IsNullOrEmpty(f03VO.Hattyu_ymd_from))
			{	
				sRepSql.Append(" AND T1.UPD_YMD >= :BIND_UPD_YMD_FROM_" + add_bind); 
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_UPD_YMD_FROM_" + add_bind;
				bindVO.Value = BoSystemFormat.formatDate(f03VO.Hattyu_ymd_from);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}
			
			//「発注日TO」を設定
			// 「発注日TO」が空白でない場合のみ適用
			if (!string.IsNullOrEmpty(f03VO.Hattyu_ymd_to))
			{	
				sRepSql.Append(" AND T1.UPD_YMD <= :BIND_UPD_YMD_TO_" + add_bind);
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_UPD_YMD_TO_" + add_bind;
				bindVO.Value = BoSystemFormat.formatDate(f03VO.Hattyu_ymd_to);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}
			
			// 「自社品番」を設定
			// 「自社品番」が空白でない場合のみ適用
			if (!string.IsNullOrEmpty(f03VO.Old_jisya_hbn))
			{
				//// [自社品番]が10桁の場合
				//if (f03VO.Old_jisya_hbn.Length == 10)
				//{
				//	sRepSql.Append(" AND  EXISTS ( ");
				//	sRepSql.Append("       SELECT 1");
				//	sRepSql.Append("       FROM MDMT0130 M1");
				//	sRepSql.Append("       WHERE M1.JAN_CD = T2.JAN_CD");
				//	sRepSql.Append("       AND   M1.OLD_XEBIO_CD = :BIND_JISYA_HBN_" + add_bind);
				//	sRepSql.Append(" 	  )");
				//}
				//else
				//{
					sRepSql.Append("AND	T2.JISYA_HBN = :BIND_JISYA_HBN_" + add_bind);
				//}
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_JISYA_HBN_" + add_bind;
				bindVO.Value = (string)f03VO.Dictionary[Ta030p01Constant.DIC_SEARCH_XEBIOCD];
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 「スキャンコード」を設定
			// 「スキャンコード」が空白でない場合のみ適用
			if (!string.IsNullOrEmpty(f03VO.Scan_cd))
			{
				//// [スキャンコード]が13桁の場合、JANで検索
				//if (f03VO.Scan_cd.Length == 13)
				//{
					sRepSql.Append(" AND T2.JAN_CD = :BIND_JAN_CD_" + add_bind);
				//}
				//// [スキャンコード]が18桁の場合、商品コードで検索
				//else
				//{
				//	sRepSql.Append(" AND T2.SYOHIN_CD = :BIND_JAN_CD_" + add_bind);
				//}
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_JAN_CD_" + add_bind;
				bindVO.Value = (string)f03VO.Dictionary[Ta030p01Constant.DIC_SEARCH_JANCD];
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			BoSystemSql.AddSql(reader, add_where_id, sRepSql.ToString(), bindList);
			
		}
		#endregion

		#endregion
	}
}
