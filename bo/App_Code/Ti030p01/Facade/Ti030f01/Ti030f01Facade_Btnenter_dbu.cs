using com.xebio.bo.Ti030p01.Constant;
using com.xebio.bo.Ti030p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V01000.V01001;
using Common.Business.V03000.V03003;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace com.xebio.bo.Ti030p01.Facade
{
  /// <summary>
  /// Ti030f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Ti030f01Facade : StandardBaseFacade
	{
		#region データベース更新処理を行います。(ボタンID : Btnenter)
		/// <summary>
		/// データベース更新処理を行います。
		/// ボタンID(Btnenter)
		/// アクションID(DBU)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNENTER_DBU(IFacadeContext facadeContext)
		{
			//使用時にコメントアウトをはずす。
			////メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNENTER_DBU");
			
			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得して、トランザクションを開始する。
				BeginTransactionWithConnect(facadeContext);
			
				//以下に業務ロジックを記述する。

				#region 初期化

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();
			
				//カード部を取得します。
				Ti030f01Form ti030f01Form = (Ti030f01Form)facadeContext.FormVO;

				#endregion

				#region 業務チェック

				#region 単項目チェック

				// 1-1 ヘッダ店舗コード
				// 店舗マスタを検索し、存在しない場合エラー
				if (!string.IsNullOrEmpty(ti030f01Form.Head_tenpo_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01001Check.CheckTenpo(ti030f01Form.Head_tenpo_cd, facadeContext, "店舗", new[] { "Head_tenpo_cd" });
					// 名称をラベルに設定
					if (resultHash != null)
					{
						ti030f01Form.Head_tenpo_nm = (string)resultHash["TENPO_NM"];
					}
				}

				// 1-2 消費税率１
				// 入力値が0～100の範囲外の場合、エラー
				if (!string.IsNullOrEmpty(ti030f01Form.Syohizei_rtu1))
				{
					if (!IsRange(Convert.ToDecimal((string)ti030f01Form.Syohizei_rtu1), 0, 100))
					{
						ErrMsgCls.AddErrMsg("E163", String.Empty, facadeContext, new[] { "Syohizei_rtu1" });
					}
				}

				// 1-3 消費税率２
				// 入力値が0～100の範囲外の場合、エラー
				if (!string.IsNullOrEmpty(ti030f01Form.Syohizei_rtu2))
				{
					if (!IsRange(Convert.ToDecimal((string)ti030f01Form.Syohizei_rtu2), 0, 100))
					{
						ErrMsgCls.AddErrMsg("E164", String.Empty, facadeContext, new[] { "Syohizei_rtu2" });
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region 関連チェック

				// 2-1 消費税開始日１、消費税開始日２
				// 消費税開始日１と消費税開始日２が同一の場合、エラー
				if (!string.IsNullOrEmpty(ti030f01Form.Syohizeikaisi_ymd1) && !string.IsNullOrEmpty(ti030f01Form.Syohizeikaisi_ymd2))
				{
					if (ti030f01Form.Syohizeikaisi_ymd1.Equals(ti030f01Form.Syohizeikaisi_ymd2))
					{
						ErrMsgCls.AddErrMsg("E166", String.Empty, facadeContext, new[] { "Syohizeikaisi_ymd1", "Syohizeikaisi_ymd2" });	
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region 排他チェック
				StringBuilder sRepSql = new StringBuilder();
				ArrayList bindList = new ArrayList();

				// 検索時に取得した更新日、更新時間とDB上の更新日、更新時間を比較し異なる場合、エラー
				sRepSql.Append(" AND TENPO_CD = '0000'");
				sRepSql.Append(" AND SAKUJYO_FLG = 0");

				// 排他チェック
				V03003Check.CheckHaita(
						Convert.ToDecimal((string)ti030f01Form.Dictionary[Ti030p01Constant.DIC_UPD_YMD]),
						Convert.ToDecimal((string)ti030f01Form.Dictionary[Ti030p01Constant.DIC_UPD_TM]),
						facadeContext,
						"BOMT0090",
						sRepSql.ToString(),
						bindList,
						1
				);

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#endregion

				#region 更新処理

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				// 店舗コード="0000"のレコード存在チェック
				if (Count_UnyoKanri(facadeContext) > 0)
				{
					// 存在した場合、運用管理MSTを更新する。
					BoSystemLog.logOut("[運用管理MST]を更新 START");
					int updcnth = Upd_UnyoKanri(facadeContext, ti030f01Form, logininfo, sysDateVO);
					BoSystemLog.logOut("[運用管理MST]を更新 END");
				}
				else
				{
					// 存在しない場合、運用管理MSTを登録する。
					BoSystemLog.logOut("[運用管理MST]を登録 START");
					int updcnth = Ins_UnyoKanri(facadeContext, ti030f01Form, logininfo, sysDateVO);
					BoSystemLog.logOut("[運用管理MST]を登録 END");
				}

				#endregion

				//トランザクションをコミットする。
				CommitTransaction(facadeContext);

				#region 画面表示

				// Dictionaryを最新化する。
				ti030f01Form.Dictionary[Ti030p01Constant.DIC_UPD_YMD] = sysDateVO.Sysdate.ToString();		// 更新日
				ti030f01Form.Dictionary[Ti030p01Constant.DIC_UPD_TM] = sysDateVO.Systime_mili.ToString();	// 更新時間

				#endregion

			}
			catch (System.Exception ex)
			{
				//トランザクションをロールバックする。
				RollbackTransaction(facadeContext);
				//例外処理を実行する。
				ThrowException(ex, facadeContext);
			}
			finally
			{
				//コネクションを開放する。
				CloseConnection(facadeContext);
			}
			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNENTER_DBU");
			
	
		}
		#endregion

		#region ユーザー定義関数

		#region 数値範囲チェック

		/// <summary>
		/// 数値範囲チェック
		/// </summary>
		/// <param name="a">対象数値</param>
		/// <param name="from">範囲（開始）</param>
		/// <param name="to">範囲（終了）</param>
		/// <returns>結果</returns>
		public Boolean IsRange(Decimal a, Decimal from, Decimal to)
		{
			return (from <= a && a <= to);
		}

		#endregion

		#region [運用管理MST] 検索　件数取得

		/// <summary>
		/// [運用管理MST] 検索　件数取得
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <returns>件数</returns>
		public int Count_UnyoKanri(IFacadeContext facadeContext)
		{
			// 店舗コード="0000"のレコード存在チェック
			// 運用管理MSTから検索
			string sSqlId = Ti030p01Constant.SQL_ID_01;

			FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(sSqlId, facadeContext.DBContext);

			// 検索結果を取得
			rtSeach.CreateDbCommand();
			IList<Hashtable> tableList = rtSeach.Execute();

			BoSystemLog.logOut("SQL: " + rtSeach.LogSql);

			int returnCount = 0;

			// 検索結果が存在した場合、その値を返却
			if (tableList != null && tableList.Count > 0)
			{
				returnCount = tableList.Count;
			}

			return returnCount;
		}

		#endregion

		#region [運用管理MST] 更新

		/// <summary>
		/// [運用管理MST] 更新
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="ti030f01Form">画面のVO</param>
		/// <param name="LoginInfoVO">ログイン情報</param>
		/// <param name="SysDateVO">システム情報</param>
		/// <returns>更新件数</returns>
		public int Upd_UnyoKanri(IFacadeContext facadeContext,
								Ti030f01Form ti030f01Form,
								LoginInfoVO loginInfo,
								SysDateVO sysDateVO)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Ti030p01Constant.SQL_ID_02, facadeContext.DBContext);

			// 消費税率１
			reader.BindValue("BIND_SYOHIZEI_RTU1", Convert.ToDecimal(BoSystemString.Nvl(ti030f01Form.Syohizei_rtu1, "0")));
			// 消費税率２
			reader.BindValue("BIND_SYOHIZEI_RTU2", Convert.ToDecimal(BoSystemString.Nvl(ti030f01Form.Syohizei_rtu2, "0")));
			// 消費税開始日１
			reader.BindValue("BIND_SYOHIZEIKAISI_YMD1", Convert.ToDecimal(BoSystemFormat.formatDate(ti030f01Form.Syohizeikaisi_ymd1, 0)));
			// 消費税開始日２
			reader.BindValue("BIND_SYOHIZEIKAISI_YMD2", Convert.ToDecimal(BoSystemFormat.formatDate(ti030f01Form.Syohizeikaisi_ymd2,0)));
			// 税処理区分1
			reader.BindValue("BIND_ZEISYORI_KB1", Convert.ToDecimal(ti030f01Form.Zeisyori_kb1));
			// 税処理区分2
			reader.BindValue("BIND_ZEISYORI_KB2", Convert.ToDecimal(ti030f01Form.Zeisyori_kb2));
			// 更新日
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 削除日
			reader.BindValue("BIND_SAKUJYO_YMD", sysDateVO.Sysdate);

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}

		#endregion

		#region [運用管理MST] 登録
		/// <summary>
		/// [運用管理MST] 登録
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="ti030f01Form">画面のVO</param>
		/// <param name="LoginInfoVO">ログイン情報</param>
		/// <param name="SysDateVO">システム情報</param>
		/// <returns>更新件数</returns>
		public int Ins_UnyoKanri(IFacadeContext facadeContext,
								Ti030f01Form ti030f01Form,
								LoginInfoVO loginInfo,
								SysDateVO sysDateVO)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Ti030p01Constant.SQL_ID_03, facadeContext.DBContext);

			// 消費税率１
			reader.BindValue("BIND_SYOHIZEI_RTU1", Convert.ToDecimal(BoSystemString.Nvl(ti030f01Form.Syohizei_rtu1, "0")));
			// 消費税率２
			reader.BindValue("BIND_SYOHIZEI_RTU2", Convert.ToDecimal(BoSystemString.Nvl(ti030f01Form.Syohizei_rtu2, "0")));
			// 消費税開始日１
			reader.BindValue("BIND_SYOHIZEIKAISI_YMD1", Convert.ToDecimal(BoSystemFormat.formatDate(ti030f01Form.Syohizeikaisi_ymd1, 0)));
			// 消費税開始日２
			reader.BindValue("BIND_SYOHIZEIKAISI_YMD2", Convert.ToDecimal(BoSystemFormat.formatDate(ti030f01Form.Syohizeikaisi_ymd2, 0)));
			// 税処理区分1
			reader.BindValue("BIND_ZEISYORI_KB1", Convert.ToDecimal(ti030f01Form.Zeisyori_kb1));
			// 税処理区分2
			reader.BindValue("BIND_ZEISYORI_KB2", Convert.ToDecimal(ti030f01Form.Zeisyori_kb2));
			// 登録日
			reader.BindValue("BIND_ADD_YMD", sysDateVO.Sysdate);
			// 登録時間
			reader.BindValue("BIND_ADD_TM", sysDateVO.Systime_mili);
			// 登録担当者コード
			reader.BindValue("BIND_ADDTAN_CD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 更新日
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 削除日
			reader.BindValue("BIND_SAKUJYO_YMD", sysDateVO.Sysdate);

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#endregion

	}
}