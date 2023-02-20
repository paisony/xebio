using com.xebio.bo.Ta080p01.Constant;
using com.xebio.bo.Ta080p01.Formvo;
using com.xebio.bo.Ta080p01.Util;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01012;
using Common.Business.C99999.Constant;
using Common.Business.C99999.DbUtil;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V01000.V01001;
using Common.Business.V01000.V01003;
using Common.Business.V01000.V01004;
using Common.Business.V01000.V01005;
using Common.Business.V03000.V03001;
using Common.Business.V03000.V03002;
using Common.Business.V03000.V03004;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
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
  /// Ta080f01のFacadeクラスです
  /// 画面データのロード業務ロジックを実装します。
  /// </summary>
  public partial class Ta080f01Facade : StandardBaseFacade
	{
		#region 定数を設定します
		/// <summary>;
		/// プログラムID。
		/// </summary>
		private const string PGID = "Ta080p01";
		/// <summary>
		/// フォームID。
		/// </summary>
		private const string FORMID = "Ta080f01";
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Ta080f01Facade()
			: base()
		{
		}
		#endregion

		#region Ta080f01画面データを作成する。
		/// <summary>
		/// Ta080f01画面データを作成する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoLoad(IFacadeContext facadeContext)
		{
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
				Ta080f01Form ta080f01Form = (Ta080f01Form)facadeContext.FormVO;

				#region 画面データ設定

				// 年月度FROM、TO初期表示
				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);
				ta080f01Form.Yosan_ymd_from = ta080f01Form.Yosan_ymd_to = sysDateVO.Sysdate.ToString().Substring(0, 6);

				#endregion

				//M1明細部のデータを作成します。
				DoM1ListLoad(facadeContext);

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

		#region M1明細部データの更新をする。
		/// <summary>
		/// M1明細部データの更新をする。
		/// 明細ID(M1)の処理メソッド
		/// アクションID(DBU)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		private void DoM1ListStore(IFacadeContext facadeContext)
		{
			//このメソッドは、M1の明細部のデータを更新するために生成されております。
			//画面のデーターベース更新処理（DBUアクション）で呼ばれます。
			//コネクションの開始・終了は、呼び出しもとのメソッドで管理されます。
			//必要な処理を実装してください。

		}
		#endregion


		#region 新規作成ボタン_チェック1_マスタ存在チェック
		/// <summary>
		/// 新規作成チェック1 マスタ存在チェック
		/// </summary>
		/// <param name="facadeContext"></param>
		/// <param name="f01VO"></param>
		private void ChkInsert1(IFacadeContext facadeContext, Ta080f01Form f01VO)
		{
			// 1:ヘッダ店舗コード
			// 店舗MSTを検索し、存在しない場合エラー
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

		}
		#endregion

		#region 検索ボタン_チェック1_マスタ存在チェック
		/// <summary>
		/// 検索ボタンチェック1 マスタ存在チェック
		/// </summary>
		/// <param name="facadeContext"></param>
		/// <param name="f01VO"></param>
		private void ChkSearch1(IFacadeContext facadeContext, Ta080f01Form f01VO)
		{
			// 1:ヘッダ店舗コード
			// 店舗MSTを検索し、存在しない場合エラー
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
			// 2:登録担当者コード
			// 登録担当者MSTを検索し、存在しない場合エラー
			if (!string.IsNullOrEmpty(f01VO.Tantosya_cd))
			{
				Hashtable resultHash = new Hashtable();
				resultHash = V01005Check.CheckTanto(f01VO.Tantosya_cd
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
					f01VO.Hanbaiin_nm = (string)resultHash["HANBAIIN_NM"];
				}
			}
			// 3:旧自社品番
			// 発注マスタを検索し、存在しない場合エラー
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
					f01VO.Dictionary[Ta080p01Constant.DIC_SEARCH_XEBIOCD] = (string)resultHash["XEBIO_CD"];
					f01VO.Maker_hbn = (string)resultHash["HIN_NBR"];
				}
			}
			// 4:スキャンコード
			// 発注マスタを検索し、存在しない場合エラー
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
			}
		}
		#endregion

		#region 検索ボタン_チェック2_関連項目チェック
		/// <summary>
		/// 検索ボタンチェック2 関連項目チェック
		/// </summary>
		/// <param name="facadeContext"></param>
		/// <param name="f01VO"></param>
		private void ChkSearch2(IFacadeContext facadeContext, Ta080f01Form f01VO)
		{
			// 1:年月度FROM-年月度TO
			if (!string.IsNullOrEmpty(f01VO.Yosan_ymd_from) && !string.IsNullOrEmpty(f01VO.Yosan_ymd_to))
			{
				V03001Check.DateFromToChk(
								f01VO.Yosan_ymd_from,
								f01VO.Yosan_ymd_to,
								facadeContext,
								"年月度",
								new[] { "Yosan_ymd_from", "Yosan_ymd_to" }
								);
			}

			// 2:仕入枠グループコードFROM-仕入枠グループコードTO
			if (!string.IsNullOrEmpty(f01VO.Yosan_cd_from) && !string.IsNullOrEmpty(f01VO.Yosan_cd_to))
			{
				V03002Check.CodeFromToChk(
								f01VO.Yosan_cd_from,
								f01VO.Yosan_cd_to,
								facadeContext,
								"仕入枠ｸﾞﾙｰﾌﾟ",
								new[] { "Yosan_cd_from", "Yosan_cd_to" }
								);
			}

			// 3:登録日FROM-登録日TO
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

			// 4:申請日FROM-申請日TO
			if (!string.IsNullOrEmpty(f01VO.Apply_ymd_from) && !string.IsNullOrEmpty(f01VO.Apply_ymd_to))
			{
				V03001Check.DateFromToChk(
								f01VO.Apply_ymd_from,
								f01VO.Apply_ymd_to,
								facadeContext,
								"申請日",
								new[] { "Apply_ymd_from", "Apply_ymd_to" }
								);
			}

		}
		#endregion

		#region 検索ボタン_チェック3_件数チェック
		/// <summary>
		/// 検索ボタンチェック3 件数チェック
		/// </summary>
		/// <param name="facadeContext"></param>
		/// <param name="tableListcnt"></param>
		/// <returns></returns>
		private Decimal ChkSearch3(IFacadeContext facadeContext, Ta080f01Form f01VO)
		{
			// sql
			FindSqlResultTable rtSearch = FindSqlUtil.CreateFindSqlResultTable(Ta080p01Constant.SQL_ID_01, facadeContext.DBContext);

			// 検索条件設定
			SetBindChkSearch3(f01VO, rtSearch);

			// 結果取得
			IList<Hashtable> result = rtSearch.Execute();
			BoSystemLog.logOut("SQL: " + rtSearch.LogSql);
			Hashtable resultTbl = result[0];
			Decimal dCnt = (Decimal)resultTbl["CNT"];

			if (result == null || result.Count <= 0)
			{
				// エラー
				ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
			}
			else
			{
				if (dCnt <= 0)
				{
					// 1:検索件数が0件の場合エラー
					ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
				}
				else
				{
					// 2:検索件数が最大件数を超える場合エラー
					V03004Check.MaxCountCheck(facadeContext.CommandInfo.FormId.ToUpper(), dCnt, facadeContext);
				}
			}
			return dCnt;
		}
		#endregion

		#region 検索ボタン_チェック3_件数チェック_検索条件設定

		private void SetBindChkSearch3(Ta080f01Form f01VO, FindSqlResultTable reader)
		{
			BindInfoVO bindVO = new BindInfoVO();
			ArrayList bindListT10 = new ArrayList();
			ArrayList bindListT20 = new ArrayList();
			StringBuilder sRepSqlT10 = new StringBuilder();
			StringBuilder sRepSqlT20 = new StringBuilder();


			Ta080p01Util.AddItiranWhere(f01VO, bindVO, bindListT10, sRepSqlT10, "T10");
			Ta080p01Util.AddItiranWhere(f01VO, bindVO, bindListT20, sRepSqlT20, "T20");

			BoSystemSql.AddSql(reader, "ADD_WHERE_T10", sRepSqlT10.ToString(), bindListT10);
			BoSystemSql.AddSql(reader, "ADD_WHERE_T20", sRepSqlT20.ToString(), bindListT20);

			// 店舗コード 最後に適応すること
			reader.BindValue("TENPO_CD_T10", BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
			reader.BindValue("TENPO_CD_T20", BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));

		}

		#endregion

		#region 検索ボタン_検索処理
		/// <summary>
		/// 検索ボタン_検索処理
		/// </summary>
		/// <param name="facadeContext"></param>
		/// <param name="f01VO"></param>
		/// <param name="m1List"></param>
		private void DoSelect(IFacadeContext facadeContext, Ta080f01Form f01VO, IDataList m1List)
		{
			// sql
			FindSqlResultTable rtSearch = FindSqlUtil.CreateFindSqlResultTable(Ta080p01Constant.SQL_ID_02, facadeContext.DBContext);

			// 検索条件設定
			Ta080p01Util.SetBindDoSelect(f01VO, rtSearch);

			// SQL実行
			IList<Hashtable> result = rtSearch.Execute();
			BoSystemLog.logOut("SQL: " + rtSearch.LogSql);

			// 結果取得
			int iCnt = 0;
			foreach (Hashtable rec in result)
			{
				iCnt++;
				Ta080f01M1Form f01MVO = new Ta080f01M1Form();

				#region 明細転記
				f01MVO.M1rowno				= iCnt.ToString();													// Ｍ１行NO
				f01MVO.M1yosan_ymd			= rec["YOSAN_YMD"].ToString();										// Ｍ１年月度
				f01MVO.M1yosan_kin			= rec["YOSAN_KIN"].ToString();										// Ｍ１予算金額
				f01MVO.M1misinsei_su		= BoSystemString.Nvl(rec["MISINSEI_SU"].ToString(), "0");			// Ｍ１未申請数
				f01MVO.M1misinsei_kin		= BoSystemString.Nvl(rec["MISINSEI_KIN"].ToString(), "0");			// Ｍ１未申請金額
				f01MVO.M1applygokei_su		= BoSystemString.Nvl(rec["SINSEI_SU"].ToString(), "0");				// Ｍ１申請数
				f01MVO.M1applygokei_kin		= BoSystemString.Nvl(rec["SINSEI_KIN"].ToString(), "0");			// Ｍ１申請金額
				f01MVO.M1jissekigokei_su	= rec["JISSEKIGOKEI_SU"].ToString();								// Ｍ１実績数
				f01MVO.M1jissekigokei_kin	= rec["JISSEKIGOKEI_KIN"].ToString();								// Ｍ１実績金額
				if (String.IsNullOrEmpty(rec["YOSAN_KIN"].ToString()))
				{
					f01MVO.M1zan_kin = string.Empty;
				}
				else
				{
					f01MVO.M1zan_kin = (Decimal.Parse(BoSystemString.Nvl(f01MVO.M1yosan_kin, "0"))
						- Decimal.Parse(BoSystemString.Nvl(rec["SINSEI_KIN_MISOSIN"].ToString(), "0"))
						- Decimal.Parse(BoSystemString.Nvl(f01MVO.M1jissekigokei_kin, "0"))
						- Decimal.Parse(BoSystemString.Nvl(rec["SINSEIZUMI_MIKAKUTEI_KIN"].ToString(), "0"))
						).ToString();
				}																								// Ｍ１残金額

				// Dictionary
				f01MVO.Dictionary.Add(Ta080p01Constant.DIC_M1YOSAN_CD, rec["YOSAN_CD"].ToString());							// [Ｍ１仕入枠グループコード]
				f01MVO.Dictionary.Add(Ta080p01Constant.DIC_M1YOSAN_NM, rec["YOSAN_NM"].ToString());							// [Ｍ１仕入枠グループ名]
				f01MVO.Dictionary.Add(Ta080p01Constant.DIC_M1KBN_CD, rec["KBN_CD"].ToString());								// [Ｍ１区分コード]
				f01MVO.Dictionary.Add(Ta080p01Constant.DIC_M1LINKED_ITEM_SU, rec["LINKED_ITEM_SU"]);						// [Ｍ１リンク先件数]
				f01MVO.Dictionary.Add(Ta080p01Constant.DIC_M1LINKED_LAST_UPD_DATETIME, rec["LINKED_LAST_UPD_DATETIME"]);	// [Ｍ１リンク先最新更新日時]
				f01MVO.Dictionary.Add(Ta080p01Constant.DIC_M1KYOYO_KIN, rec["KYOYO_KIN"]);									// [Ｍ１許容金額]
				f01MVO.Dictionary.Add(Ta080p01Constant.DIC_M1SINSEI_SU_MISOSIN, rec["SINSEI_SU_MISOSIN"]);					// [Ｍ１未申請数(PC未送信)]
				f01MVO.Dictionary.Add(Ta080p01Constant.DIC_M1SINSEI_KIN_MISOSIN, rec["SINSEI_KIN_MISOSIN"]);				// [Ｍ１未申請金額(PC未送信)]
				f01MVO.Dictionary.Add(Ta080p01Constant.DIC_M1SINSEIZUMI_MIKAKUTEI_KIN, rec["SINSEIZUMI_MIKAKUTEI_KIN"]);	// [Ｍ１申請済み未確定金額]
				#endregion

				//リストオブジェクトにM1Formを追加します。
				m1List.Add(f01MVO, true);
			}
		}
		#endregion

		#region 検索ボタン_検索条件保持_SearchConditionSaveCls代替
		/// <summary>
		/// 検索条件保持_SearchConditionSaveCls代替
		/// </summary>
		/// <param name="f01VO"></param>
		/// <returns></returns>
		private Ta080f01Form SearchConditionSave(Ta080f01Form f01VO)
		{
			Ta080f01Form searchConditionVO = new Ta080f01Form();
			// ヘッダ店舗コード
			searchConditionVO.Head_tenpo_cd = f01VO.Head_tenpo_cd;
			// ヘッダ店舗名
			searchConditionVO.Head_tenpo_nm = f01VO.Head_tenpo_nm;
			// モードNO
			searchConditionVO.Modeno = f01VO.Modeno;
			// 選択モードNO
			searchConditionVO.Stkmodeno = f01VO.Stkmodeno;
			// 年月度FROM
			searchConditionVO.Yosan_ymd_from = f01VO.Yosan_ymd_from;
			// 年月度TO
			searchConditionVO.Yosan_ymd_to = f01VO.Yosan_ymd_to;
			// 仕入枠グループコードFROM
			searchConditionVO.Yosan_cd_from = f01VO.Yosan_cd_from;
			// 仕入枠グループコードTO
			searchConditionVO.Yosan_cd_to = f01VO.Yosan_cd_to;
			// 登録日FROM
			searchConditionVO.Add_ymd_from = f01VO.Add_ymd_from;
			// 登録日TO
			searchConditionVO.Add_ymd_to = f01VO.Add_ymd_to;
			// 登録担当者コード
			searchConditionVO.Tantosya_cd = f01VO.Tantosya_cd;
			// 申請日FROM
			searchConditionVO.Apply_ymd_from = f01VO.Apply_ymd_from;
			// 申請日TO
			searchConditionVO.Apply_ymd_to = f01VO.Apply_ymd_to;
			// 申請種別
			searchConditionVO.Sinsei_sb = f01VO.Sinsei_sb;
			// 依頼理由コード
			searchConditionVO.Irairiyu_cd = f01VO.Irairiyu_cd;
			searchConditionVO.Irairiyu_cd1 = f01VO.Irairiyu_cd1;
			// 状態
			searchConditionVO.Jotai_kbn = f01VO.Jotai_kbn;
			// 旧自社品番
			searchConditionVO.Old_jisya_hbn = f01VO.Old_jisya_hbn;
			// スキャンコード
			searchConditionVO.Scan_cd = f01VO.Scan_cd;
			// ディクショナリ
			searchConditionVO.Dictionary = f01VO.Dictionary;
			return searchConditionVO;
		}
		#endregion

		#region 仕入枠グループリンク処理
		/// <summary>
		/// 仕入枠グループリンク処理
		/// </summary>
		/// <param name="facadeContext"></param>
		/// <param name="f01VO"></param>
		/// <param name="f01MVO"></param>
		/// <param name="m1List"></param>
		private IList<Hashtable> DoSelectLink(IFacadeContext facadeContext, Ta080f01Form f01VO, Ta080f01M1Form f01MVO)
		{
			BindInfoVO bindVO = new BindInfoVO();
			ArrayList bindList1 = new ArrayList();
			ArrayList bindList2 = new ArrayList();
			StringBuilder sRepSql1 = new StringBuilder();
			StringBuilder sRepSql2 = new StringBuilder();
			StringBuilder sRepSqlSort = new StringBuilder();
			decimal[] resultSum = new decimal[0];

			#region SQLID指定、抽出条件取得
			String sSqlId = "";
			bool addWhere2Flg = false;
			#region モード[申請] [申請前修正]の場合
			if (   f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_APPLY)
				|| f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_SINSEIMAEUPD))
			{
				sSqlId = Ta080p01Constant.SQL_ID_03;
				Ta080p01Util.addMeisaiWhere(f01VO, f01MVO, bindVO, bindList1, sRepSql1, "T1", 1, 2);
			}
			#endregion
			#region モード[申請取消]の場合
			else if (f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_SINSEIZUMITORIKESI))
			{
				sSqlId = Ta080p01Constant.SQL_ID_04;
				Ta080p01Util.addMeisaiWhere(f01VO, f01MVO, bindVO, bindList1, sRepSql1, "T1", 2, 2);
			}
			#endregion
			#region モード[登録履歴照会]の場合
			else if (f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_REF_TOROKURIREKI))
			{
				sSqlId = Ta080p01Constant.SQL_ID_05;
				addWhere2Flg = true;
				Ta080p01Util.addMeisaiWhere(f01VO, f01MVO, bindVO, bindList1, sRepSql1, "T11", 1, 2);
				Ta080p01Util.addMeisaiWhere(f01VO, f01MVO, bindVO, bindList2, sRepSql2, "T12", 2, 2);
			}
			#endregion
			#region モード[稟議結果照会]の場合
			else if (f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_REF_RINGIKEKKA))
			{
				sSqlId = Ta080p01Constant.SQL_ID_06;
				Ta080p01Util.addMeisaiWhere(f01VO, f01MVO, bindVO, bindList1, sRepSql1, "T2", 3, 2);
			}
			#endregion

			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(sSqlId, facadeContext.DBContext);
			#endregion

			#region 抽出条件設定
			BoSystemSql.AddSql(reader, "ADD_WHERE_T1", sRepSql1.ToString(), bindList1);
			if (addWhere2Flg)
			{
				BoSystemSql.AddSql(reader, "ADD_WHERE_T2", sRepSql2.ToString(), bindList2);
			}
			#endregion

			#region ソート条件設定
			// モード[稟議結果照会]以外の場合、ソート条件を設定
			if (!f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_REF_RINGIKEKKA))
			{
				Ta080p01Util.addMeisaiSort(null, sRepSqlSort, "T", true);
				BoSystemSql.AddSql(reader, "ADD_SORT", sRepSqlSort.ToString());
			}
			#endregion
			
			// SQL実行
			IList<Hashtable> result = reader.Execute();
			BoSystemLog.logOut("SQL: " + reader.LogSql);
			// 件数チェック
			if (result == null || result.Count <= 0)
			{
				// エラー
				ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
			}
			return result;
		}
		#endregion

		#region 確定ボタン_チェック1_選択チェック
		/// <summary>
		/// 明細行が1件も選択されていない場合、エラー
		/// </summary>
		/// <param name="facadeContext"></param>
		/// <param name="f01VO"></param>
		/// <param name="m1List"></param>
		private void ChkUpd1(IFacadeContext facadeContext, IDataList m1List)
		{
			int inputflg = 0;
			if (m1List == null || m1List.Count <= 0)
			{
				// 対象行を選択して下さい。
				ErrMsgCls.AddErrMsg("E119", "対象行", facadeContext);
			}
			else
			{
				foreach (Ta080f01M1Form f01MVO in m1List.ListData)
				{
					if (BoSystemString.Nvl(f01MVO.M1selectorcheckbox, BoSystemConstant.CHECKBOX_OFF).Equals(BoSystemConstant.CHECKBOX_ON))
					{
						inputflg = 1;
						break;
					}
				}
				if (inputflg == 0)
				{
					// 対象行を選択して下さい。
					ErrMsgCls.AddErrMsg("E119", "対象行", facadeContext);
				}
			}
		}
		#endregion

		#region 確定ボタン_チェック2_仕入枠チェック
		/// <summary>
		/// 仕入枠ごとの許容金額チェック
		/// Dictionary.[M1許容金額]＜＝([M1実績金額]＋[Ｍ１申請金額]＋[M1未申請金額]) の場合エラー
		/// </summary>
		/// <param name="facadeContext"></param>
		/// <param name="f01VO"></param>
		/// <param name="m1List"></param>
		private void ChkUpd2(IFacadeContext facadeContext, IDataList m1List)
		{
			foreach (Ta080f01M1Form f01MVO in m1List.ListData)
			{
				// 選択行のみ かつ
				// 補充依頼データのみ
				if(BoSystemString.Nvl(f01MVO.M1selectorcheckbox, BoSystemConstant.CHECKBOX_OFF).Equals(BoSystemConstant.CHECKBOX_ON)
				&& Ta080p01Constant.KBN_KBN_CD_HOJUIRAI.Equals(f01MVO.Dictionary[Ta080p01Constant.DIC_M1KBN_CD].ToString())
				){
					// dictionaryからM1許容金額を取得
					decimal M1kyoyo_kin = decimal.Parse(BoSystemString.Nvl(f01MVO.Dictionary[Ta080p01Constant.DIC_M1KYOYO_KIN].ToString(), "0"));
					// M1未申請金額
					decimal M1misinsei_kin = decimal.Parse(f01MVO.M1misinsei_kin);
					// M1申請金額(未送信分のみ)
					//decimal M1sinsei_kin = decimal.Parse(f01MVO.M1applygokei_kin);
					decimal M1sinsei_kin = (decimal)f01MVO.Dictionary[Ta080p01Constant.DIC_M1SINSEI_KIN_MISOSIN];
					// M1実績金額
					decimal M1jisseki_kin = decimal.Parse(f01MVO.M1jissekigokei_kin);
					decimal M1mikakutei_kin = (decimal)f01MVO.Dictionary[Ta080p01Constant.DIC_M1SINSEIZUMI_MIKAKUTEI_KIN];

					if (M1kyoyo_kin <= (M1misinsei_kin + M1sinsei_kin + M1jisseki_kin + M1mikakutei_kin))
					{
						// 当月の{仕入枠グループ名称}の仕入枠予算を超えています。
						ErrMsgCls.AddErrMsg("E240", f01MVO.Dictionary[Ta080p01Constant.DIC_M1YOSAN_NM].ToString(), facadeContext);
					}
				}
			}
		}

		#endregion

		#region 確定ボタン_チェック3_単項目チェック-チェック4_単品レポートチェック
		/// <summary>
		/// 確定ボタン_チェック3_単項目チェック-チェック4_単品レポートチェック
		/// </summary>
		/// <param name="facadeContext"></param>
		/// <param name="f01VO"></param>
		/// <param name="m1List"></param>
		private void ChkUpd3_4(IFacadeContext facadeContext, Ta080f01Form f01VO, IDataList m1List)
		{	
			int iCnt = 0;

			foreach (Ta080f01M1Form f01MVO in m1List.ListData)
			{
				// 選択行のみ かつ
				// 補充依頼データのみ
				if (BoSystemString.Nvl(f01MVO.M1selectorcheckbox, BoSystemConstant.CHECKBOX_OFF).Equals(BoSystemConstant.CHECKBOX_ON)
				&& Ta080p01Constant.KBN_KBN_CD_HOJUIRAI.Equals(f01MVO.Dictionary[Ta080p01Constant.DIC_M1KBN_CD].ToString())
				)
				{
					// 選択行明細情報の取得
					IList<Hashtable> result = DoSelectLink(facadeContext, f01VO, f01MVO);
					// ストアド引数用に累計額を算出
					decimal dRuikei_kin = 0;

					// 明細各行に対して更新処理を実行
					foreach (Hashtable rec in result)
					{
						//// 一覧画面チェックでは依頼数量チェックの必要なし
						// 依頼数量入力チェック
						// 空白の場合エラー
						// 0の場合エラー

						// 依頼数量チェックを通過した場合、ストアド（チェック処理）を実行する
						#region ■パラメータ設定
						ArrayList paramList = new ArrayList();
						//,v_FURI_F		OUT	NUMBER								/*  1 代表自社品番振替フラグ */
						StoredProcedureCls.SetStoredParam(ref paramList, "v_FURI_F", OracleDbType.Decimal, ParameterDirection.Output);
						//,v_FURIMAE_CD	OUT	MDOT0120.JAN_CD%TYPE				/*  2 代表自社品番振替前商品コード */
						StoredProcedureCls.SetStoredParam(ref paramList, "v_FURIMAE_CD", OracleDbType.Decimal, ParameterDirection.Output);
						//,v_ZANKIN		OUT	VARCHAR2							/*  3 仕入枠残金額 */
						StoredProcedureCls.SetStoredParam(ref paramList, "v_ZANKIN", OracleDbType.Decimal, ParameterDirection.Output);
						//,v_TENPO_CD		IN	MDOT0120.TENPO_CD%TYPE			/*  4 店舗コード */
						StoredProcedureCls.SetStoredParam(ref paramList, "v_TENPO_CD", OracleDbType.Char, ParameterDirection.Input, BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
						//,v_JAN_CD		IN	MDOT0120.JAN_CD%TYPE				/*  5 JANコード */
						StoredProcedureCls.SetStoredParam(ref paramList, "v_JAN_CD", OracleDbType.Varchar2, ParameterDirection.Input, BoSystemFormat.formatJanCd(rec["JAN_CD"].ToString()));
						//,v_IRAI_SU		IN	MDOT0120.IRAI_SU%TYPE			/*  6 依頼数量 */
						StoredProcedureCls.SetStoredParam(ref paramList, "v_IRAI_SU", OracleDbType.Decimal, ParameterDirection.Input, decimal.Parse(rec["IRAI_SU"].ToString()));
						//,v_YOSAN_CD		IN	MDOT0120.YOSAN_CD%TYPE			/*  7 仕入枠グループコード */
						StoredProcedureCls.SetStoredParam(ref paramList, "v_YOSAN_CD", OracleDbType.Varchar2, ParameterDirection.Input, BoSystemFormat.formatYosan_Cd(f01MVO.Dictionary[Ta080p01Constant.DIC_M1YOSAN_CD].ToString()));
						//,v_CHECKKB		IN	NUMBER							/*  8 チェック区分[1]新規[2]申請 */
						StoredProcedureCls.SetStoredParam(ref paramList, "v_CHECKKB", OracleDbType.Decimal, ParameterDirection.Input, 2);
						//,v_ZANKIN_KB	IN	NUMBER								/*  9 仕入枠残金額取得区分 [1]なし[2]1円単位で取得[3]10円単位で取得 */
						StoredProcedureCls.SetStoredParam(ref paramList, "v_ZANKIN_KB", OracleDbType.Decimal, ParameterDirection.Input, 1);
						//,v_GENKARUISEKI	IN	NUMBER							/* 10 原価金額累積 */
						StoredProcedureCls.SetStoredParam(ref paramList, "v_GENKARUISEKI", OracleDbType.Decimal, ParameterDirection.Input, dRuikei_kin);

						#endregion
						// ■補充依頼データの入力チェック処理呼び出し
						ArrayList al = StoredProcedureCls.ExecStoredProcedure(facadeContext.DBContext, "MDORDERNEW.checkOrder", paramList);
						#region ■例外処理
						if (al != null && al.Count > 0)
						{
							// 10～30番代までエラーエラーとして処理する
							// 30番31番は確定ボタンチェック2で拾い済みのためここでは見ない

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

							// エラーコード
							string errCd = al[0].ToString();
							switch (errCd)
							{
								#region errCd10番台 チェック3_単項目チェック
								case "10":
									// 発注MSTに存在しない場合、エラー
								case "12":
									// 特定の商品属性(L37、D41、Y48、S20)の場合はエラー
								case "13":
									// 初回配分前の場合はエラー
								case "14":
									// 原単価がマイナスの商品はエラー
								case "15":
									// 申請前修正、申請の場合、仕入枠グループがヘッダ仕入枠グループコードと異なる場合はエラー
								case "16":
									// [Ｍ１原価金額]（※）＞9999999（７桁）の場合、エラー
								case "17":
									// ロット数チェック
									ErrMsgCls.AddErrMsg("E253", String.Empty, facadeContext, null, f01MVO.M1rowno, iCnt.ToString(), "M1");
									break;
								#endregion
								#region errCd20番台 チェック4_単品レポートチェック
								//								case "20":
//									// ロット数チェック⇒17番に変更
								case "21":
									// 補充発注対象商品チェック
								case "22":
									// 代表自社品番補充外チェック
								case "23":
									// 販売完了日チェック
								case "24":
									// 配分可能数チェック
								case "40":
								case "41":
								case "42":
								case "43":
									// 単品レポート振替後のエラーにする
									ErrMsgCls.AddErrMsg("E254", String.Empty, facadeContext, null, f01MVO.M1rowno, iCnt.ToString(), "M1");
									break;
								#endregion
								default:
									break;
							}
						}
						else
						{
							// OUTパラメータが取得できない場合
							throw new SystemException("ストアド［MDORDERNEW.checkOrder］実行時にエラーが発生しました。");
						}
						#endregion
						// ------------------------------------------------------------------------------------
						// エラーが発生した場合、その時点で現一覧明細行のチェックを終了し、次一覧明細のチェックを行う
						// ------------------------------------------------------------------------------------
						if (MessageDisplayUtil.HasError(facadeContext))
						{
							// 現一覧明細に紐付く明細のチェックを終了する。
							break;
						}
						// ストアド引数用_累計額加算
						dRuikei_kin += Convert.ToDecimal(rec["IRAI_SU"]) * Convert.ToDecimal(rec["GEN_TNK"]);
					}	
				}
				iCnt++;
			}
		}

		#endregion

		#region 確定ボタン_チェック5_排他チェック1
		/// <summary>
		/// モード｢申請｣時の排他チェック
		/// </summary>
		/// <param name="facadeContext"></param>
		/// <param name="f01VO"></param>
		/// <param name="m1List"></param>
		private void ChkUpd5(IFacadeContext facadeContext, Ta080f01Form f01VO, IDataList m1List)
		{	
			foreach (Ta080f01M1Form f01MVO in m1List.ListData)
			{	
				// 選択行のみ
				if (BoSystemString.Nvl(f01MVO.M1selectorcheckbox, BoSystemConstant.CHECKBOX_OFF).Equals(BoSystemConstant.CHECKBOX_ON))
				{
					FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Ta080p01Constant.SQL_ID_07, facadeContext.DBContext);

					BindInfoVO bindVO = new BindInfoVO();
					ArrayList bindList = new ArrayList();
					StringBuilder sRepSql = new StringBuilder();
					
					// 明細条件を設定
					Ta080p01Util.addMeisaiWhere(f01VO, f01MVO, bindVO, bindList, sRepSql, "T1", 1, 3);

					// dictionaryより検索時の更新日、更新時間、明細件数を取得
					decimal updYmd = decimal.Parse(f01MVO.Dictionary[Ta080p01Constant.DIC_M1LINKED_LAST_UPD_DATETIME].ToString().Substring(0,8));
					decimal updTm  = decimal.Parse(f01MVO.Dictionary[Ta080p01Constant.DIC_M1LINKED_LAST_UPD_DATETIME].ToString().Substring(8));
					decimal itemSu = decimal.Parse(f01MVO.Dictionary[Ta080p01Constant.DIC_M1LINKED_ITEM_SU].ToString());
					
					 // 排他処理実行
					Ta080p01Util.CheckHaitaMaxVal_local(updYmd
						, updTm
						, itemSu
						, facadeContext
						, Ta080p01Constant.TBLID_HOJUIARI_SINSEI
						, sRepSql.ToString()
						, bindList
						, 1
						, null
						, null
						, null
						, null
						, 0);
				}
			}
		}
		#endregion

		#region 確定ボタン_チェック6_排他チェック2
		/// <summary>
		/// モード｢申請取消｣時の排他チェック
		/// </summary>
		/// <param name="facadeContext"></param>
		/// <param name="f01VO"></param>
		/// <param name="m1List"></param>
		private void ChkUpd6(IFacadeContext facadeContext, Ta080f01Form f01VO, IDataList m1List)
		{	
			foreach (Ta080f01M1Form f01MVO in m1List.ListData)
			{	
				// 選択行のみ
				if (BoSystemString.Nvl(f01MVO.M1selectorcheckbox, BoSystemConstant.CHECKBOX_OFF).Equals(BoSystemConstant.CHECKBOX_ON))
				{
					FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Ta080p01Constant.SQL_ID_07, facadeContext.DBContext);

					BindInfoVO bindVO = new BindInfoVO();
					ArrayList bindList = new ArrayList();
					StringBuilder sRepSql = new StringBuilder();
					
					// 明細条件を設定
					Ta080p01Util.addMeisaiWhere(f01VO, f01MVO, bindVO, bindList, sRepSql, "T1", 2, 3);

					// dictionaryより検索時の更新日、更新時間、明細件数を取得
					decimal updYmd = decimal.Parse(f01MVO.Dictionary[Ta080p01Constant.DIC_M1LINKED_LAST_UPD_DATETIME].ToString().Substring(0,8));
					decimal updTm  = decimal.Parse(f01MVO.Dictionary[Ta080p01Constant.DIC_M1LINKED_LAST_UPD_DATETIME].ToString().Substring(8));
					decimal itemSu = decimal.Parse(f01MVO.Dictionary[Ta080p01Constant.DIC_M1LINKED_ITEM_SU].ToString());
					
					 // 排他処理実行
					Ta080p01Util.CheckHaitaMaxVal_local(
						updYmd
						, updTm
						, itemSu
						, facadeContext
						, Ta080p01Constant.TBLID_HOJUIRAI_KAKUTEI
						, sRepSql.ToString()
						, bindList
						, 1
						, null
						, null
						, null
						, null
						, 0);
				
				}
			}
		}
		#endregion

		#region 確定ボタン_確定処理_モード[申請]
		/// <summary>
		/// [補充依頼申請TBL]を更新する。
		/// [補充依頼申請TBL]を検索し、[補充依頼確定TBL]を登録する。
		/// 対象行の[Dictionary.区分コード]が"1"(補充依頼)の場合、[補充依頼確定TBL]を更新する。
		/// </summary>
		/// <param name="facadeContext"></param>
		/// <param name="f01VO"></param>
		/// <param name="m1List"></param>
		private void DoUpdShinsei(IFacadeContext facadeContext, Ta080f01Form f01VO, IDataList m1List, LoginInfoVO loginInfo, SysDateVO sysDateVO)
		{
			foreach (Ta080f01M1Form f01MVO in m1List.ListData)
			{
				// 選択行のみ
				if (BoSystemString.Nvl(f01MVO.M1selectorcheckbox, BoSystemConstant.CHECKBOX_OFF).Equals(BoSystemConstant.CHECKBOX_ON))
				{
					// 補充依頼確定TBLの登録
					int iInsMdot0120Cnt = InsMdot0120byF01Shinsei(facadeContext, f01VO, f01MVO, loginInfo, sysDateVO);

					// 補充依頼申請TBLの更新
					int iUpdMdot0110Cnt = UpdMdot0110byF01Shinsei(facadeContext, f01VO, f01MVO, loginInfo, sysDateVO);

					// 選択行が補充依頼データの場合
					int iUpdMdot0120Cnt = 0;
					if (Ta080p01Constant.KBN_KBN_CD_HOJUIRAI.Equals(f01MVO.Dictionary[Ta080p01Constant.DIC_M1KBN_CD].ToString()))
					{
						// 補充依頼確定TBLの更新
						iUpdMdot0120Cnt = UpdMdot0120byF01Shinsei(facadeContext, f01VO, f01MVO, loginInfo, sysDateVO);
					}
				}
			}
		}
		#endregion

		#region 確定ボタン_確定処理_モード[申請]_補充依頼申請TBL更新
		/// <summary>
		/// 補充依頼申請TBL更新（未申請→申請済）
		/// </summary>
		/// <param name="facadeContext"></param>
		/// <param name="f01VO"></param>
		/// <param name="f01MVO"></param>
		/// <param name="loginInfo"></param>
		/// <param name="sysDateVO"></param>
		/// <returns></returns>
		private int UpdMdot0110byF01Shinsei(IFacadeContext facadeContext, Ta080f01Form f01VO, Ta080f01M1Form f01MVO, LoginInfoVO loginInfo, SysDateVO sysDateVO)
		{
			BindInfoVO bindVO = new BindInfoVO();
			ArrayList bindList = new ArrayList();
			StringBuilder sRepSql = new StringBuilder();

			// SQL指定
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Ta080p01Constant.SQL_ID_08, facadeContext.DBContext);
			// 抽出条件取得
			Ta080p01Util.addMeisaiWhere(f01VO, f01MVO, bindVO, bindList, sRepSql, "T1", 1, 2);
			// 抽出条件設定
			BoSystemSql.AddSql(reader, "ADD_WHERE", sRepSql.ToString(), bindList);

			// 更新項目バインド変数の値を設定
			Ta080p01Util.setFlgMdot0110Shinsei(reader, loginInfo, sysDateVO);

			// SQL実行
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}

		#endregion

		#region 確定ボタン_確定処理_モード[申請]_補充依頼確定TBL登録
		/// <summary>
		/// 補充依頼確定TBL登録
		/// </summary>
		/// <param name="facadeContext"></param>
		/// <param name="f01VO"></param>
		/// <param name="f01MVO"></param>
		/// <param name="loginInfo"></param>
		/// <param name="sysDateVO"></param>
		/// <returns></returns>
		private int InsMdot0120byF01Shinsei(IFacadeContext facadeContext, Ta080f01Form f01VO, Ta080f01M1Form f01MVO, LoginInfoVO loginInfo, SysDateVO sysDateVO)
		{
			BindInfoVO bindVO = new BindInfoVO();
			ArrayList bindList = new ArrayList();
			StringBuilder sRepSql = new StringBuilder();

			// SQL指定
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Ta080p01Constant.SQL_ID_09, facadeContext.DBContext);
			// 抽出条件取得（リンク処理の条件と共通）
			Ta080p01Util.addMeisaiWhere(f01VO, f01MVO, bindVO, bindList, sRepSql, "T1", 1, 2);
			// 抽出条件設定
			BoSystemSql.AddSql(reader, "ADD_WHERE", sRepSql.ToString(), bindList);
			// 更新項目バインド変数の値を設定
			// メッセージ区分
			//reader.BindValue("BIND_MESSEGE_KB", (decimal) f01MVO.Dictionary[Ta080p01Constant.DIC_M1MESSEGE_KB]);
			reader.BindValue("BIND_MESSEGE_KB", 0);
			// 申請日				:システム日付(YYYYMMDD)
			reader.BindValue("BIND_SHINSEI_YMD", sysDateVO.Sysdate);
			// 予算年月				:Ｍ１年月度
			reader.BindValue("BIND_YOSAN_YMD", decimal.Parse(BoSystemFormat.formatDate_yyyyMM(f01MVO.M1yosan_ymd)));
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

		#region 確定ボタン_確定処理_モード[申請]_補充依頼確定TBL更新
		/// <summary>
		/// 補充依頼データのメッセージ区分を設定
		/// </summary>
		/// <param name="facadeContext"></param>
		/// <param name="f01VO"></param>
		/// <param name="f01MVO"></param>
		/// <param name="loginInfo"></param>
		/// <param name="sysDateVO"></param>
		/// <returns></returns>
		private int UpdMdot0120byF01Shinsei(IFacadeContext facadeContext, Ta080f01Form f01VO, Ta080f01M1Form f01MVO, LoginInfoVO loginInfo, SysDateVO sysDateVO)
		{
			// SQL指定
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Ta080p01Constant.SQL_ID_10, facadeContext.DBContext);
			// 抽出項目バインド変数の値を設定
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
			// 区分コード
			reader.BindValue("BIND_KBN_CD", decimal.Parse(f01MVO.Dictionary[Ta080p01Constant.DIC_M1KBN_CD].ToString()));
			// 仕入枠グループコード
			reader.BindValue("BIND_YOSAN_CD", f01MVO.Dictionary[Ta080p01Constant.DIC_M1YOSAN_CD].ToString());
			// 登録日
			reader.BindValue("BIND_ADD_YMD", sysDateVO.Sysdate);
			// 登録時間
			reader.BindValue("BIND_ADD_TM", sysDateVO.Systime_mili);

			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region 確定ボタン_確定処理_モード[申請取消]
		/// <summary>
		/// [補充依頼申請TBL]を更新する。
		/// [補充依頼確定TBL]を削除する。
		/// </summary>
		/// <param name="facadeContext"></param>
		/// <param name="f01VO"></param>
		/// <param name="m1List"></param>
		/// <param name="loginInfo"></param>
		/// <param name="sysDateVO"></param>
		private void DoUpdShinseiTorikeshi(IFacadeContext facadeContext, Ta080f01Form f01VO, IDataList m1List, LoginInfoVO loginInfo, SysDateVO sysDateVO)
		{
			foreach (Ta080f01M1Form f01MVO in m1List.ListData)
			{
				// 選択行のみ
				if (BoSystemString.Nvl(f01MVO.M1selectorcheckbox, BoSystemConstant.CHECKBOX_OFF).Equals(BoSystemConstant.CHECKBOX_ON))
				{
					// 補充依頼申請TBLの更新
					int iUpdMdot0110Cnt = UpdMdot0110byF01ShinseiTorikeshi(facadeContext, f01VO, f01MVO, loginInfo, sysDateVO);
					// 補充依頼確定TBLの削除
					int iDltMdot0120Cnt = DltMdot0120byF01ShinseiTorikeshi(facadeContext, f01VO, f01MVO, loginInfo, sysDateVO);
				}
			}
		}
		#endregion

		#region 確定ボタン_確定処理_モード[申請取消]_補充依頼申請TBL更新
		/// <summary>
		/// 確定ボタン_確定処理_モード[申請取消]_補充依頼申請TBL更新
		/// </summary>
		/// <param name="facadeContext"></param>
		/// <param name="f01VO"></param>
		/// <param name="f01MVO"></param>
		/// <param name="loginInfo"></param>
		/// <param name="sysDateVO"></param>
		/// <returns></returns>
		private int UpdMdot0110byF01ShinseiTorikeshi(IFacadeContext facadeContext, Ta080f01Form f01VO, Ta080f01M1Form f01MVO, LoginInfoVO loginInfo, SysDateVO sysDateVO)
		{
			BindInfoVO bindVO = new BindInfoVO();
			ArrayList bindList = new ArrayList();
			StringBuilder sRepSql = new StringBuilder();

			// SQL指定
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Ta080p01Constant.SQL_ID_08, facadeContext.DBContext);

			// 条件文追記1
			sRepSql.AppendLine(" AND EXISTS( SELECT 1 FROM "+ Ta080p01Constant.TBLID_HOJUIRAI_KAKUTEI + " T2 WHERE 0 = 0");

			// Exists文抽出条件取得
			Ta080p01Util.addMeisaiWhere(f01VO, f01MVO, bindVO, bindList, sRepSql, "T2", 2, 3);

			// 条件文追記2
			sRepSql.AppendLine();
//			sRepSql.AppendLine(" /* 以下更新対象テーブル（補充依頼申請）との結合条件 */");
			sRepSql.AppendLine(" AND T2.TENPO_CD  = T1.TENPO_CD");
			sRepSql.AppendLine(" AND T2.KBN_CD    = T1.KBN_CD");
			sRepSql.AppendLine(" AND T2.SYORI_YMD = T1.SYORI_YMD");
			sRepSql.AppendLine(" AND T2.KANRI_NO  = T1.KANRI_NO");
			sRepSql.AppendLine(" AND T2.GYO_NO    = T1.GYO_NO");
			sRepSql.AppendLine(" )");

			// 抽出条件設定
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

		#region 確定ボタン_確定処理_モード[申請取消]_補充依頼確定TBL削除
		private int DltMdot0120byF01ShinseiTorikeshi(IFacadeContext facadeContext, Ta080f01Form f01VO, Ta080f01M1Form f01MVO, LoginInfoVO loginInfo, SysDateVO sysDateVO)
		{
			BindInfoVO bindVO = new BindInfoVO();
			ArrayList bindList = new ArrayList();
			StringBuilder sRepSql = new StringBuilder();

			// SQL指定
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Ta080p01Constant.SQL_ID_11, facadeContext.DBContext);

			// 抽出条件取得（排他処理の条件と共通）
			Ta080p01Util.addMeisaiWhere(f01VO, f01MVO, bindVO, bindList, sRepSql, "T1", 2, 3);

			// 抽出条件設定
			BoSystemSql.AddSql(reader, "ADD_WHERE", sRepSql.ToString(), bindList);

			// SQL実行
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}

		#endregion


	}
}
