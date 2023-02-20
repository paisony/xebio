using com.xebio.bo.Ta010p01.Constant;
using com.xebio.bo.Ta010p01.Formvo;
using com.xebio.bo.Ta010p01.Util;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01019;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V01000.V01001;
using Common.Business.V01000.V01005;
using Common.Business.V03000.V03001;
using Common.Business.V03000.V03003;
using Common.Business.V03000.V03004;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace com.xebio.bo.Ta010p01.Facade
{
  /// <summary>
  /// Ta010f01のFacadeクラスです
  /// 画面データのロード業務ロジックを実装します。
  /// </summary>
  public partial class Ta010f01Facade : StandardBaseFacade
	{
		#region 定数を設定します
		/// <summary>;
		/// プログラムID。
		/// </summary>
		private const string PGID = "Ta010p01";
		/// <summary>
		/// フォームID。
		/// </summary>
		private const string FORMID = "Ta010f01";
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Ta010f01Facade()
			: base()
		{
		}
		#endregion

		#region Ta010f01画面データを作成する。
		/// <summary>
		/// Ta010f01画面データを作成する。
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
			//	Ta010f01Form ta010f01Form = (Ta010f01Form)facadeContext.FormVO;
				
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
		#region 検索単項目チェック
		/// <summary>
		/// ChkSelSingleItem 検索単項目チェック
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="Ta010f01Form">f01VO</param>
		/// <param name="String">mode</param>
		/// <returns>Decimal</returns>
		private void ChkSelSingleItem ( IFacadeContext facadeContext, Ta010f01Form f01VO, String mode )
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
			//// 新規作成時は、以下のチェックを行う
			//if (Ta010p01Constant.CHECK_MODE_BTNINSERT.Equals(mode))
			//{
			//	// 1-3 区分コード
			//	//     未選択の場合、エラー
			//	if (string.IsNullOrEmpty(f01VO.Kbn_cd) || f01VO.Kbn_cd.Equals(BoSystemConstant.DROPDOWNLIST_MISENTAKU))
			//	{
			//		ErrMsgCls.AddErrMsg("E119", "区分", facadeContext, new[] { "Kbn_cd" });
			//	}
			//}

			// 検索時は、以下のチェックを行う
			if (Ta010p01Constant.CHECK_MODE_BTNSEARCH.Equals(mode))
			{

				// 1-2 担当者コード
				//       担当者マスタを検索し、存在しない場合エラー
				if (!string.IsNullOrEmpty(f01VO.Tantosya_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01005Check.CheckTanto(f01VO.Tantosya_cd
														, facadeContext
														, string.Empty
														, null
														, "担当者"
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
			}
			#endregion
		}
		#endregion
		#region 検索関連項目チェック
		/// <summary>
		/// ChkSelSingleItem 検索関連項目チェック
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="Ta010f01Form">f01VO</param>
		/// <param name="String">mode</param>
		/// <returns>Decimal</returns>
		private void ChkSelRelatedItem ( IFacadeContext facadeContext, Ta010f01Form f01VO, String mode )
		{
			#region 関連項目チェック
			// 検索時は、以下のチェックを行う
			if (Ta010p01Constant.CHECK_MODE_BTNSEARCH.Equals(mode))
			{
				// 2-1 発注日FROM、発注日TO
				//       発注日ＦＲＯＭ > 発注日ＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Hattyu_ymd_from) && !string.IsNullOrEmpty(f01VO.Hattyu_ymd_to))
				{
					V03001Check.DateFromToChk(
									f01VO.Hattyu_ymd_from,
									f01VO.Hattyu_ymd_to,
									facadeContext,
									"発注日",
									new[] { "Hattyu_ymd_from", "Hattyu_ymd_to" }
									);
				}
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
		/// <param name="Ta010f01Form">f01VO</param>
		/// <param name="IDBContext">DBContext</param>
		/// <param name="blCount">blCount</param>
		/// <returns>IList<Hashtable></returns>
		private IList<Hashtable> DoSelect ( Ta010f01Form f01VO, IDBContext DBContext, bool blCount )
		{
			FindSqlResultTable rtSearch = null;
			if (blCount)
			{
				// 件数取得
				rtSearch = FindSqlUtil.CreateFindSqlResultTable(Ta010p01Constant.SQL_ID_01, DBContext);
			}
			else
			{
				// 検索結果取得
				rtSearch = FindSqlUtil.CreateFindSqlResultTable(Ta010p01Constant.SQL_ID_02, DBContext);
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
		/// <param name="Ta010f01Form">f01VO</param>
		/// <param name="FindSqlResultTable">rtChk</param>
		/// <param name="blCount">blCount</param>
		/// <returns></returns>
		private void SetBind ( Ta010f01Form f01VO, FindSqlResultTable reader, bool blCount )
		{
			ArrayList bindList = new ArrayList();
			ArrayList bindList2 = new ArrayList();
			BindInfoVO bindVO = new BindInfoVO();
			StringBuilder sRepSql1 = new StringBuilder();		// 申請用のリプレースSQL
			StringBuilder sRepSql2 = new StringBuilder();		// 確定用のリプレースSQL
			#region 検索条件設定
			// 検索結果取得の場合
			if (!blCount)
			{
			}


			// 店舗コードを設定
			sRepSql1.Append(" AND T1.TENPO_CD = :BIND_TENPO_CD1").AppendLine();
			sRepSql2.Append(" AND T1.TENPO_CD = :BIND_TENPO_CD2").AppendLine();
			bindVO = new BindInfoVO();
			bindVO.BindId = "BIND_TENPO_CD1";
			bindVO.Value = BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd);
			bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
			bindList.Add(bindVO);
			bindVO = new BindInfoVO();
			bindVO.BindId = "BIND_TENPO_CD2";
			bindVO.Value = BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd);
			bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
			bindList2.Add(bindVO);

			// 区分コードを設定
			if (!string.IsNullOrEmpty(f01VO.Kbn_cd) && !f01VO.Kbn_cd.Equals(BoSystemConstant.DROPDOWNLIST_MISENTAKU))
			{
				sRepSql1.Append(" AND T1.KBN_CD = :BIND_KBN_CD1").AppendLine();
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_KBN_CD1";
				bindVO.Value = f01VO.Kbn_cd;
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
				sRepSql2.Append(" AND T1.KBN_CD = :BIND_KBN_CD2").AppendLine();
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_KBN_CD2";
				bindVO.Value = f01VO.Kbn_cd;
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList2.Add(bindVO);
			}

			// 発注日FROMを設定
			if (!string.IsNullOrEmpty(f01VO.Hattyu_ymd_from))
			{
				sRepSql1.Append(" AND T1.UPD_YMD >= :BIND_UPD_YMD_FROM1").AppendLine();
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_UPD_YMD_FROM1";
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Hattyu_ymd_from);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
				sRepSql2.Append(" AND T1.UPD_YMD >= :BIND_UPD_YMD_FROM2").AppendLine();
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_UPD_YMD_FROM2";
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Hattyu_ymd_from);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList2.Add(bindVO);
			}

			// 発注日TOを設定
			if (!string.IsNullOrEmpty(f01VO.Hattyu_ymd_to))
			{
				sRepSql1.Append(" AND T1.UPD_YMD <= :BIND_UPD_YMD_TO1").AppendLine();
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_UPD_YMD_TO1";
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Hattyu_ymd_to);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
				sRepSql2.Append(" AND T1.UPD_YMD <= :BIND_UPD_YMD_TO2").AppendLine();
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_UPD_YMD_TO2";
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Hattyu_ymd_to);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList2.Add(bindVO);
			}

			// 更新担当者コードを設定
			if (!string.IsNullOrEmpty(f01VO.Tantosya_cd))
			{
				sRepSql1.Append(" AND T1.UPD_TANCD = :BIND_UPD_TANCD1").AppendLine();

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_UPD_TANCD1";
				bindVO.Value = BoSystemFormat.formatTantoCd(f01VO.Tantosya_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);

				sRepSql2.Append(" AND T1.UPD_TANCD = :BIND_UPD_TANCD2").AppendLine();

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_UPD_TANCD2";
				bindVO.Value = BoSystemFormat.formatTantoCd(f01VO.Tantosya_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList2.Add(bindVO);
			}

			// 依頼理由コードを設定
			if (!string.IsNullOrEmpty(Ta010p01Util.GetIrairiyu_cd<Ta010f01Form>(f01VO)) && !Ta010p01Util.GetIrairiyu_cd<Ta010f01Form>(f01VO).Equals(BoSystemConstant.DROPDOWNLIST_MISENTAKU))
			{
				sRepSql1.Append(" AND T1.IRAIRIYU_CD = :BIND_IRAIRIYU_CD1").AppendLine();
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_IRAIRIYU_CD1";
				bindVO.Value = Ta010p01Util.GetIrairiyu_cd<Ta010f01Form>(f01VO);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
				sRepSql2.Append(" AND T1.IRAIRIYU_CD = :BIND_IRAIRIYU_CD2").AppendLine();
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_IRAIRIYU_CD2";
				bindVO.Value = Ta010p01Util.GetIrairiyu_cd<Ta010f01Form>(f01VO);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList2.Add(bindVO);
			}

			// 送信済みフラグを設定
			// [選択モードNo]が「取消」の場合　または
			// Vの場合、「修正」の場合も条件とする。
			if (BoSystemConstant.MODE_DEL.Equals(f01VO.Modeno)
			||  (CheckCompanyCls.IsVictoria() && BoSystemConstant.MODE_UPD.Equals(f01VO.Modeno)))
			{
				// 送信済みフラグ（0(未送信)）
				sRepSql2.Append(" AND T1.SOSINZUMI_FLG = ").Append(ConditionSosinzumi_flg.VALUE_MISOSIN).AppendLine();
			}

			// 検索条件の有効可否設定
			// 会社がXの場合
			if(CheckCompanyCls.IsXebio())
			{
				// [選択モードNo]が「申請」、「修正」の場合、補充依頼申請テーブルから検索する。（①のSQLを実行する）
				if(BoSystemConstant.MODE_APPLY.Equals(f01VO.Modeno) || BoSystemConstant.MODE_UPD.Equals(f01VO.Modeno) )
				{
					// 申請テーブル検索を可
					BoSystemSql.AddSql(reader, Ta010p01Constant.SQL_ID_01_REP_ADD_WHERE_KAHI_SHIN, Ta010p01Constant.SERCH_YUKO_KA);
					// 申請テーブル検索条件を設定
					BoSystemSql.AddSql(reader, Ta010p01Constant.SQL_ID_01_REP_ADD_WHERE_SHIN, sRepSql1.ToString(), bindList);
					// 確定テーブル検索を否
					BoSystemSql.AddSql(reader, Ta010p01Constant.SQL_ID_01_REP_ADD_WHERE_KAHI_KAKU, Ta010p01Constant.SERCH_YUKO_HI);
					// 申請テーブル検索条件を未設定
					BoSystemSql.AddSql(reader, Ta010p01Constant.SQL_ID_01_REP_ADD_WHERE_KAKU, "");

				// [選択モードNo]が「取消」の場合、補充依頼確定テーブルから検索する。（②のSQLを実行する）
				} else if(BoSystemConstant.MODE_DEL.Equals(f01VO.Modeno)) {
					// 申請テーブル検索を否
					BoSystemSql.AddSql(reader, Ta010p01Constant.SQL_ID_01_REP_ADD_WHERE_KAHI_SHIN, Ta010p01Constant.SERCH_YUKO_HI);
					// 申請テーブル検索条件を未設定
					BoSystemSql.AddSql(reader, Ta010p01Constant.SQL_ID_01_REP_ADD_WHERE_SHIN, "");
					// 確定テーブル検索を可
					BoSystemSql.AddSql(reader, Ta010p01Constant.SQL_ID_01_REP_ADD_WHERE_KAHI_KAKU, Ta010p01Constant.SERCH_YUKO_KA);
					// 申請テーブル検索条件を設定
					BoSystemSql.AddSql(reader, Ta010p01Constant.SQL_ID_01_REP_ADD_WHERE_KAKU, sRepSql2.ToString(), bindList2);

				// [選択モードNo]が「照会」の場合、状態の入力状態により判定
				} else if(BoSystemConstant.MODE_REF.Equals(f01VO.Modeno)) {
					
					// [状態]が空白、補充依頼申請テーブルと補充依頼確定テーブルから検索する。（① UNION ALL ②のSQLを実行する。）
					if (string.IsNullOrEmpty(f01VO.Shinsei_flg) || f01VO.Shinsei_flg.Equals(BoSystemConstant.DROPDOWNLIST_MISENTAKU))
					{
						// 申請テーブル検索を可
						BoSystemSql.AddSql(reader, Ta010p01Constant.SQL_ID_01_REP_ADD_WHERE_KAHI_SHIN, Ta010p01Constant.SERCH_YUKO_KA);
						// 申請テーブル検索条件を設定
						BoSystemSql.AddSql(reader, Ta010p01Constant.SQL_ID_01_REP_ADD_WHERE_SHIN, sRepSql1.ToString(), bindList);
						// 確定テーブル検索を可
						BoSystemSql.AddSql(reader, Ta010p01Constant.SQL_ID_01_REP_ADD_WHERE_KAHI_KAKU, Ta010p01Constant.SERCH_YUKO_KA);
						// 申請テーブル検索条件を設定
						BoSystemSql.AddSql(reader, Ta010p01Constant.SQL_ID_01_REP_ADD_WHERE_KAKU, sRepSql2.ToString(), bindList2);
					}
					// [状態]が未申請、補充依頼申請テーブルから検索する。（①のSQLを実行する）
					else if(ConditionSinsei_jotai.VALUE_SINSEI_JOTAI1.Equals(f01VO.Shinsei_flg))
					{
						// 申請テーブル検索を可
						BoSystemSql.AddSql(reader, Ta010p01Constant.SQL_ID_01_REP_ADD_WHERE_KAHI_SHIN, Ta010p01Constant.SERCH_YUKO_KA);
						// 申請テーブル検索条件を設定
						BoSystemSql.AddSql(reader, Ta010p01Constant.SQL_ID_01_REP_ADD_WHERE_SHIN, sRepSql1.ToString(), bindList);
						// 確定テーブル検索を否
						BoSystemSql.AddSql(reader, Ta010p01Constant.SQL_ID_01_REP_ADD_WHERE_KAHI_KAKU, Ta010p01Constant.SERCH_YUKO_HI);
						// 申請テーブル検索条件を未設定
						BoSystemSql.AddSql(reader, Ta010p01Constant.SQL_ID_01_REP_ADD_WHERE_KAKU, "");

					}
					// [状態]が申請済、補充依頼確定テーブルから検索する。（②のSQLを実行する）
					else if(ConditionSinsei_jotai.VALUE_SINSEI_JOTAI2.Equals(f01VO.Shinsei_flg))
					{
						// 申請テーブル検索を否
						BoSystemSql.AddSql(reader, Ta010p01Constant.SQL_ID_01_REP_ADD_WHERE_KAHI_SHIN, Ta010p01Constant.SERCH_YUKO_HI);
						// 申請テーブル検索条件を未設定
						BoSystemSql.AddSql(reader, Ta010p01Constant.SQL_ID_01_REP_ADD_WHERE_SHIN, "");
						// 確定テーブル検索を可
						BoSystemSql.AddSql(reader, Ta010p01Constant.SQL_ID_01_REP_ADD_WHERE_KAHI_KAKU, Ta010p01Constant.SERCH_YUKO_KA);
						// 申請テーブル検索条件を設定
						BoSystemSql.AddSql(reader, Ta010p01Constant.SQL_ID_01_REP_ADD_WHERE_KAKU, sRepSql2.ToString(), bindList2);
					}
				}
			// その他の場合
			} else {
				// 申請テーブル検索を否
				BoSystemSql.AddSql(reader, Ta010p01Constant.SQL_ID_01_REP_ADD_WHERE_KAHI_SHIN, Ta010p01Constant.SERCH_YUKO_HI);
				// 申請テーブル検索条件を未設定
				BoSystemSql.AddSql(reader, Ta010p01Constant.SQL_ID_01_REP_ADD_WHERE_SHIN, "");
				// 確定テーブル検索を可
				BoSystemSql.AddSql(reader, Ta010p01Constant.SQL_ID_01_REP_ADD_WHERE_KAHI_KAKU, Ta010p01Constant.SERCH_YUKO_KA);
				// 申請テーブル検索条件を設定
				BoSystemSql.AddSql(reader, Ta010p01Constant.SQL_ID_01_REP_ADD_WHERE_KAKU, sRepSql2.ToString(), bindList2);
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
		public void DoCopy ( Ta010f01Form f01VO, IDataList m1List, IList<Hashtable> tableList )
		{
			int iCnt = 0;
			foreach (Hashtable rec in tableList)
			{
				iCnt++;
				Ta010f01M1Form f01m1VO = new Ta010f01M1Form();

				#region 明細転記
				f01m1VO.M1rowno = iCnt.ToString();																	// Ｍ１行NO
				f01m1VO.M1hojuirai_kbn_nm = rec["MEISYO_NM1"].ToString();											// Ｍ１補充依頼区分名称
				f01m1VO.Dictionary.Add(Ta010p01Constant.DIC_M1KANRI_NO,
							BoSystemFormat.formatDenpyoNo(rec["KANRI_NO"].ToString()));								// Ｍ１管理NOリンク
				f01m1VO.M1hattyu_ymd = BoSystemString.ZeroToEmpty(rec["UPD_YMD"].ToString());						// Ｍ１発注日
				f01m1VO.M1itemsu = rec["IRAIGOKEI_SU"].ToString();													// Ｍ１数量
				f01m1VO.M1genkakin = rec["IRAIGOKEI_KIN"].ToString();												// Ｍ１原価金額
				f01m1VO.M1hanbaiin_nm = rec["HANBAIIN_NM"].ToString();												// Ｍ１担当者名
				f01m1VO.M1irai_riyu = rec["RIYUCOMMENT_NM"].ToString();												// Ｍ１依頼理由
				f01m1VO.M1sinsei_jotainm = rec["MEISYO_NM2"].ToString();											// Ｍ１申請状態名称
				f01m1VO.M1apply_ymd = BoSystemString.ZeroToEmpty(rec["APPLY_YMD"].ToString());						// Ｍ１申請日
				f01m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;											// Ｍ１選択フラグ(隠し)
				f01m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;										// Ｍ１確定処理フラグ(隠し)
				if (rec["SOSINZUMI_FLG"].ToString().Equals(ConditionSosinzumi_flg.VALUE_SOSINZUMI))
				{
					// 送信済みの場合、背景色変更
					f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_SOSINZUMI;									// Ｍ１明細色区分(隠し)
				}
				else
				{
					f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;										// Ｍ１明細色区分(隠し)
				}

				// Dictionary
				f01m1VO.Dictionary.Add(Ta010p01Constant.DIC_M1TENPO_CD, rec["TENPO_CD"].ToString());				// 店舗コード
				f01m1VO.Dictionary.Add(Ta010p01Constant.DIC_M1UPD_YMD, rec["UPD_YMD"].ToString());					// 更新日
				f01m1VO.Dictionary.Add(Ta010p01Constant.DIC_M1UPD_TM, rec["UPD_TM"].ToString());					// 更新時間
				f01m1VO.Dictionary.Add(Ta010p01Constant.DIC_M1SYORI_YMD, rec["SYORI_YMD"].ToString());				// 処理日付
				f01m1VO.Dictionary.Add(Ta010p01Constant.DIC_M1SYORI_TM, rec["SYORI_TM"].ToString());				// 処理時間
				f01m1VO.Dictionary.Add(Ta010p01Constant.DIC_M1KBN_CD, rec["KBN_CD"].ToString());					// 区分コード
				f01m1VO.Dictionary.Add(Ta010p01Constant.DIC_M1IRAIRIYU_CD, rec["IRAIRIYU_CD"].ToString());			// 依頼理由コード
				f01m1VO.Dictionary.Add(Ta010p01Constant.DIC_M1SHINSEI_FLG, rec["SHINSEI_FLG"].ToString());			// 申請状態
				f01m1VO.Dictionary.Add(Ta010p01Constant.DIC_M1TANTOSYA_CD, rec["UPD_TANCD"].ToString());			// 更新担当者コード
				#endregion

				//リストオブジェクトにM1Formを追加します。
				m1List.Add(f01m1VO, true);
			}

		}
		#endregion
		#region 転記処理(管理Noリンク)
		/// <summary>
		/// DoCopy 明細転記処理
		/// </summary>
		/// <param name="Ta010f01M1Form">prevM1Vo</param>
		/// <param name="IDataList">nextM1List</param>
		/// <param name="tableList">取得情報</param>
		/// <returns>合計集計情報</returns>
		public decimal[] DoDetailCopy ( Ta010f01M1Form prevM1Vo, IDataList nextM1List, IList<Hashtable> tableList )
		{

			decimal dIraiSum = 0;	// 合計依頼数量
			decimal dKinSum = 0;	// 合計原価金額
			foreach (Hashtable rec in tableList)
			{
				Ta010f02M1Form f02m1VO = new Ta010f02M1Form();
				f02m1VO.M1rowno = rec["GYO_NO"].ToString();						// Ｍ１行NO
				f02m1VO.M1bumonkana_nm = rec["BUMONKANA_NM"].ToString();		// Ｍ１部門カナ名
				f02m1VO.M1hyoka_kb = rec["HYOKA_KB"].ToString();				// Ｍ１評価区分
				f02m1VO.M1kahi_nm = rec["HOJU_NM"].ToString();					// Ｍ１可否名称              ← 補充発注対象商品区分名
				f02m1VO.M1tenzaiko_su = rec["TENZAIKO_SU"].ToString();			// Ｍ１店在庫数
				f02m1VO.M1hinsyu_ryaku_nm = rec["HINSYU_RYAKU_NM"].ToString();	// Ｍ１品種略名称
				f02m1VO.M1nyukayotei_su = rec["NYUKAYOTEI_SU"].ToString();		// Ｍ１入荷予定数
				f02m1VO.M1uriage_su = rec["URIAGE_SU"].ToString();				// Ｍ１売上実績数
				f02m1VO.M1burando_nm = rec["BURANDO_NMK"].ToString();			// Ｍ１ブランド名
				f02m1VO.M1jido_su = rec["JIDO_SU"].ToString();					// Ｍ１自動定数
				f02m1VO.M1haibunkano_su = rec["HAIBUNKANO_SU"].ToString();		// Ｍ１配分可能数
				f02m1VO.M1jisya_hbn = rec["JISYA_HBN"].ToString();				// Ｍ１自社品番
				f02m1VO.M1irai_syukei = rec["SYUKEI_SU"].ToString();			// Ｍ１依頼集計              ← 依頼集計数
				f02m1VO.M1syohin_zokusei = rec["SYOHIN_ZOKUSEI"].ToString();	// Ｍ１商品属性
				f02m1VO.M1lot_su = rec["LOT_SU"].ToString();					// Ｍ１ロット数
				f02m1VO.M1iro_nm = rec["IRO_NM"].ToString();					// Ｍ１色
				f02m1VO.M1size_nm = rec["SIZE_NM"].ToString();					// Ｍ１サイズ
				f02m1VO.M1maker_hbn = rec["HIN_NBR"].ToString();				// Ｍ１メーカー品番
				f02m1VO.M1syonmk = rec["SYONMK"].ToString();					// Ｍ１商品名(カナ)
				// 未申請の場合
				if (ConditionSinsei_jotai.VALUE_SINSEI_JOTAI1.Equals(prevM1Vo.Dictionary[Ta010p01Constant.DIC_M1SHINSEI_FLG]))
				{
					f02m1VO.M1hatchu_msg = Ta010p01Util.GetHtms(f02m1VO);			// Ｍ１発注メッセージ
					// 申請済みの場合
				}
				else if (ConditionSinsei_jotai.VALUE_SINSEI_JOTAI2.Equals(prevM1Vo.Dictionary[Ta010p01Constant.DIC_M1SHINSEI_FLG]))
				{
					f02m1VO.M1hatchu_msg = rec["MESSEGE_NM"].ToString();			// Ｍ１発注メッセージ
				}
				f02m1VO.M1irai_su = rec["IRAI_SU"].ToString();					// Ｍ１依頼数量              ← 数量
				f02m1VO.M1scan_cd = rec["JAN_CD"].ToString();					// Ｍ１スキャンコード        ← JANコード
				f02m1VO.M1genkakin = rec["IRAI_KIN"].ToString();				// Ｍ１原価金額              ← 依頼金額
				f02m1VO.M1irai_su_hdn = rec["IRAI_SU"].ToString();				// Ｍ１依頼数量(隠し)        ← 数量
				f02m1VO.M1gen_tnk = rec["GEN_TNK"].ToString();					// Ｍ１原単価(隠し)
				f02m1VO.M1genkakin_hdn = rec["IRAI_KIN"].ToString();			// Ｍ１原価金額(隠し)        ← 依頼金額
				f02m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;		// Ｍ１選択フラグ(隠し)
				f02m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;	// Ｍ１確定処理フラグ(隠し)
				f02m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;		// Ｍ１明細色区分(隠し)      ←　"0"（通常）

				// Dictionary
				f02m1VO.Dictionary.Add(Ta010p01Constant.DIC_M1BUMON_CD, rec["BUMON_CD"].ToString());							// 部門コード
				f02m1VO.Dictionary.Add(Ta010p01Constant.DIC_M1HINSYU_CD, rec["HINSYU_CD"].ToString());							// 品種コード
				f02m1VO.Dictionary.Add(Ta010p01Constant.DIC_M1BURANDO_CD, rec["BURANDO_CD"].ToString());						// ブランドコード
				f02m1VO.Dictionary.Add(Ta010p01Constant.DIC_M1IRO_CD, rec["IRO_CD"].ToString());								// 色コード
				f02m1VO.Dictionary.Add(Ta010p01Constant.DIC_M1SIZE_CD, rec["SIZE_CD"].ToString());								// サイズコード
				f02m1VO.Dictionary.Add(Ta010p01Constant.DIC_M1SYOHIN_CD, rec["SYOHIN_CD"].ToString());							// 商品コード
				f02m1VO.Dictionary.Add(Ta010p01Constant.DIC_M1HANBAIKANRYO_YMD, rec["HANBAIKANRYO_YMD"].ToString());			// 販売完了日
				f02m1VO.Dictionary.Add(Ta010p01Constant.DIC_M1HATYUTAISYO_KB, rec["HATYUTAISYO_KB"].ToString());				// 補充区分
				f02m1VO.Dictionary.Add(Ta010p01Constant.DIC_M1HYOKA_KB, rec["HYOKA_KB"].ToString());							// 評価区分
				f02m1VO.Dictionary.Add(Ta010p01Constant.DIC_M1MESSEGE_KB, rec["MESSEGE_KB"].ToString());						// メッセージ区分
				f02m1VO.Dictionary.Add(Ta010p01Constant.DIC_M1KANOUSUGOE_FLG, rec["KANOUSUGOE_KANOUTORIHIKI_FLG"].ToString());	// 可能数越可能取引フラグ
				f02m1VO.Dictionary.Add(Ta010p01Constant.DIC_M1MOTOMIYASYOHIN_FLG, rec["MOTOMIYASYOHIN_FLG"].ToString());		// 本宮商品フラグ

				// 合計値加算
				dIraiSum += Convert.ToDecimal(f02m1VO.M1irai_su);				// Ｍ１依頼数量の合計
				dKinSum += Convert.ToDecimal(f02m1VO.M1genkakin);				// Ｍ１原価金額の合計

				//リストオブジェクトにM1Formを追加します。
				nextM1List.Add(f02m1VO, true);

			}
			return new decimal[]{ dIraiSum, dKinSum };
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
				foreach (Ta010f01M1Form f01m1VO in m1List.ListData)
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
		#region 更新単項目チェック
		/// <summary>
		/// ChkSelSingleItem 更新単項目チェック
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="Ta010f01Form">f01VO</param>
		/// <param name="SysDateVO">sysDateVO</param>
		/// <returns>Decimal</returns>
		private void ChkUpdSingleItem ( IFacadeContext facadeContext, Ta010f01Form f01VO, SysDateVO sysDateVO )
		{
			#region 単項目チェック
			#endregion
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
		private void ChkUpdHaita ( IFacadeContext facadeContext, IDataList m1List, string sModeno)
		{
			#region 排他チェック

			StringBuilder sRepSql = new StringBuilder();
			sRepSql.Append(" AND TENPO_CD = :BIND_TENPO_CD");
			sRepSql.Append(" AND KANRI_NO = :BIND_KANRI_NO");
			sRepSql.Append(" AND SYORI_YMD = :BIND_SYORI_YMD");
			sRepSql.Append(" AND KBN_CD = :BIND_KBN_CD");
			String sHaitaTable = "";
			// [選択モードNo]が「申請」の場合
			if (BoSystemConstant.MODE_APPLY.Equals(sModeno))
			{
				// 補充依頼申請TBL(H)を設定
				sHaitaTable = "MDOT0010";
			}
			// [選択モードNo]が「取消」の場合
			else if (BoSystemConstant.MODE_DEL.Equals(sModeno))
			{
				// 補充依頼確定TBL(H)を設定
				sHaitaTable = "MDOT0020";
			}
			int iCnt = 0;
			foreach (Ta010f01M1Form f01m1VO in m1List.ListData)
			{

				// 対象行のみ実施
				if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
				{
					ArrayList bindList = new ArrayList();
					BindInfoVO bindVO = new BindInfoVO();

					// 店舗コード
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_TENPO_CD";
					bindVO.Value = BoSystemFormat.formatTenpoCd((string)f01m1VO.Dictionary[Ta010p01Constant.DIC_M1TENPO_CD]);
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 管理No
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_KANRI_NO";
					bindVO.Value = BoSystemFormat.formatDenpyoNo((string)f01m1VO.Dictionary[Ta010p01Constant.DIC_M1KANRI_NO]);
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 処理日付
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_SYORI_YMD";
					bindVO.Value = (string)f01m1VO.Dictionary[Ta010p01Constant.DIC_M1SYORI_YMD];
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 区分コード
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_KBN_CD";
					bindVO.Value = (string)f01m1VO.Dictionary[Ta010p01Constant.DIC_M1KBN_CD];
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 排他チェック
					V03003Check.CheckHaitaMaxVal(
							Convert.ToDecimal((string)f01m1VO.Dictionary[Ta010p01Constant.DIC_M1UPD_YMD]),
							Convert.ToDecimal((string)f01m1VO.Dictionary[Ta010p01Constant.DIC_M1UPD_TM]),
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
		#region [補充依頼申請TBL(B)]を検索し、[補充依頼確定TBL(B)]を登録する。(SQL_ID_06)
		/// <summary>
		/// [補充依頼申請TBL(B)]を検索し、[補充依頼確定TBL(B)]を登録
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="Ta010f01M1Form">f01M1Form</param>
		/// <returns>更新件数</returns>
		public static int Ins_DetailOrderAplly( IFacadeContext facadeContext,
									Ta010f01M1Form f01M1Form)
		{
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Ta010p01Constant.SQL_ID_06, facadeContext.DBContext);

			// -------------------------------------------
			// バインド変数の置き換え
			// -------------------------------------------
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01M1Form.Dictionary[Ta010p01Constant.DIC_M1TENPO_CD]));
			// 管理No
			reader.BindValue("BIND_KANRI_NO", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Ta010p01Constant.DIC_M1KANRI_NO], "0")));
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(BoSystemString.Nvl((string)f01M1Form.Dictionary[Ta010p01Constant.DIC_M1SYORI_YMD]))));
			// 区分コード
			reader.BindValue("BIND_KBN_CD1", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Ta010p01Constant.DIC_M1KBN_CD], "0")));
			reader.BindValue("BIND_KBN_CD2", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Ta010p01Constant.DIC_M1KBN_CD], "0")));
			reader.BindValue("BIND_KBN_CD3", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Ta010p01Constant.DIC_M1KBN_CD], "0")));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion
		#region 補充依頼確定TBL(B)更新（メッセージ区分）する。(SQL_ID_07)
		/// <summary>
		/// 補充依頼確定TBL(B)更新（メッセージ区分）
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="Ta010f01M1Form">f01M1Form</param>
		/// <returns>更新件数</returns>
		public static int Ins_HeadOrderAplly_Msg ( IFacadeContext facadeContext,
									Ta010f01M1Form f01M1Form )
		{
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Ta010p01Constant.SQL_ID_07, facadeContext.DBContext);

			// -------------------------------------------
			// バインド変数の置き換え
			// -------------------------------------------
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01M1Form.Dictionary[Ta010p01Constant.DIC_M1TENPO_CD]));
			// 管理No
			reader.BindValue("BIND_KANRI_NO", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Ta010p01Constant.DIC_M1KANRI_NO], "0")));
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(BoSystemString.Nvl((string)f01M1Form.Dictionary[Ta010p01Constant.DIC_M1SYORI_YMD]))));
			// 区分コード
			reader.BindValue("BIND_KBN_CD", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Ta010p01Constant.DIC_M1KBN_CD], "0")));
			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion
		

	}
}
