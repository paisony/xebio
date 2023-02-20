using com.xebio.bo.Tf010p01.Constant;
using com.xebio.bo.Tf010p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.CsvUtil;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.SqlUtil;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace com.xebio.bo.Tf010p01.Facade
{
  /// <summary>
  /// Tf010f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tf010f01Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : Btncsv)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btncsv)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNCSV_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNCSV_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
			//	//コネクションを取得して、トランザクションを開始する。
			//	BeginTransactionWithConnect(facadeContext);
				//コネクションを取得する。
				OpenConnection(facadeContext);

				//以下に業務ロジックを記述する。

				#region 初期化

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// ログインユーザIDを取得
				string loginId = Convert.ToString(logininfo.LoginId);

				// FormVO取得
				// 画面より情報を取得する。
				Tf010f01Form f01VO = (Tf010f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				#endregion

				#region 業務チェック

				#region 行数チェック

				// 1-1 選択状態
				// 1件も選択されていない場合、エラー
				if (m1List == null || m1List.Count <= 0)
				{
					// 出力する行を選択して下さい。
					ErrMsgCls.AddErrMsg("E119", String.Empty, facadeContext, new[] { "出力する行" });
				}
				else
				{
					int inputflg = 0;
					for (int i = 0; i < m1List.Count; i++)
					{
						Tf010f01M1Form f01m1VO = (Tf010f01M1Form)m1List[i];
						if (BoSystemConstant.CHECKBOX_ON.Equals(f01m1VO.M1selectorcheckbox))
						{
							inputflg = 1;
							break;
						}
					}
					if (inputflg == 0)
					{
						// 出力する行を選択して下さい。
						ErrMsgCls.AddErrMsg("E119", "出力する行", facadeContext);
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#endregion

				#region 検索処理

				#region 検索条件設定

				// 検索条件を設定 -----------

				StringBuilder sRepSql = new StringBuilder("AND (T1.TENPO_CD, T1.DENPYO_BANGO, T1.SYORI_YMD) in (('','','')");
				StringBuilder sRepSql_Sinsei = new StringBuilder();
				StringBuilder sRepSql_Kakutei = new StringBuilder();

				// 明細行数分繰り返す
				for (int i = 0; i < m1List.Count; i++)
				{

					Tf010f01M1Form f01m1VO = (Tf010f01M1Form)m1List[i];

					// 選択フラグが１の場合
					if (BoSystemConstant.CHECKBOX_ON.Equals(f01m1VO.M1selectorcheckbox))
					{
						if (string.IsNullOrEmpty(f01m1VO.M1kakutei_ymd))
						{
							sRepSql_Sinsei.Append(",");
							sRepSql_Sinsei.Append("('");
							//申請店舗
							sRepSql_Sinsei.Append(BoSystemFormat.formatTenpoCd(f01m1VO.M1shinsei_tenpo_cd));
							sRepSql_Sinsei.Append("', ");
							//伝票番号
							sRepSql_Sinsei.Append(BoSystemFormat.formatDenpyoNo(f01m1VO.Dictionary[Tf010p01Constant.DIC_M1DENPYO_BANGO].ToString()));
							sRepSql_Sinsei.Append(", ");
							//処理日
							sRepSql_Sinsei.Append(BoSystemFormat.formatDate(f01m1VO.Dictionary[Tf010p01Constant.DIC_M1SYORI_YMD].ToString()));
							sRepSql_Sinsei.Append(")");

						}
						else
						{
							sRepSql_Kakutei.Append(",");
							sRepSql_Kakutei.Append("('");
							//申請店舗
							sRepSql_Kakutei.Append(BoSystemFormat.formatTenpoCd(f01m1VO.M1shinsei_tenpo_cd));
							sRepSql_Kakutei.Append("', ");
							//伝票番号
							sRepSql_Kakutei.Append(BoSystemFormat.formatDenpyoNo(f01m1VO.Dictionary[Tf010p01Constant.DIC_M1DENPYO_BANGO].ToString()));
							sRepSql_Kakutei.Append(", ");
							//処理日
							sRepSql_Kakutei.Append(BoSystemFormat.formatDate(f01m1VO.Dictionary[Tf010p01Constant.DIC_M1SYORI_YMD].ToString()));
							sRepSql_Kakutei.Append(")");
						}
					}
				}

				#endregion

				#region テーブルID設定
				// 条件によってSQL、SQLIDを変更する

				String sSqlId = null;
				String sTblId1 = null;
				String sTblId2 = null;
				ArrayList bindList = new ArrayList();

				// 経費振替申請テーブル(H)の条件がある場合
				if (sRepSql_Sinsei.Length > 0)
				{
					sSqlId = Tf010p01Constant.SQL_ID_17;
					sTblId1 = Tf010p01Constant.TABLE_ID_MDAT0020;		// 経費振替申請テーブル(H)
					sRepSql_Sinsei.Insert(0, sRepSql);
					sRepSql_Sinsei.Append(")");

					// 経費振替確定テーブル(H)の条件がある場合
					if (sRepSql_Kakutei.Length > 0)
					{
						sSqlId = Tf010p01Constant.SQL_ID_19;
						sTblId2 = Tf010p01Constant.TABLE_ID_MDAT0030;	// 経費振替確定テーブル(H)
						sRepSql_Kakutei.Insert(0, sRepSql);
						sRepSql_Kakutei.Append(")");
					}
				}
				// 経費振替申請テーブル(H)の条件がなく、経費振替確定テーブル(H)の条件がある場合
				else
				{
					sSqlId = Tf010p01Constant.SQL_ID_18;
					sTblId1 = Tf010p01Constant.TABLE_ID_MDAT0030;		// 経費振替確定テーブル(H)
					sRepSql_Kakutei.Insert(0, sRepSql);
					sRepSql_Kakutei.Append(")");
				}

				FindSqlResultTable rtSearch = FindSqlUtil.CreateFindSqlResultTable(sSqlId, facadeContext.DBContext);

				switch (sSqlId)
				{
					// 経費振替申請テーブル(H)
					case Tf010p01Constant.SQL_ID_17:
						// テーブルID設定
						BoSystemSql.AddSql(rtSearch, Tf010p01Constant.SQL_ID_01_REP_TABLE_ID1, sTblId1 + " T1", bindList);
						// 検索条件設定
						BoSystemSql.AddSql(rtSearch, Tf010p01Constant.SQL_ID_01_REP_ADD_WHERE1, sRepSql_Sinsei.ToString(), bindList);
						break;
					// 経費振替確定テーブル(H)
					case Tf010p01Constant.SQL_ID_18:
						// テーブルID設定
						BoSystemSql.AddSql(rtSearch, Tf010p01Constant.SQL_ID_01_REP_TABLE_ID1, sTblId1 + " T1", bindList);
						// 検索条件設定
						BoSystemSql.AddSql(rtSearch, Tf010p01Constant.SQL_ID_01_REP_ADD_WHERE1, sRepSql_Kakutei.ToString(), bindList);
						break;
					// 経費振替申請テーブル(H)、経費振替確定テーブル(H)
					default:
						// テーブルID設定
						BoSystemSql.AddSql(rtSearch, Tf010p01Constant.SQL_ID_01_REP_TABLE_ID1, sTblId1 + " T1", bindList);
						// 検索条件設定
						BoSystemSql.AddSql(rtSearch, Tf010p01Constant.SQL_ID_01_REP_ADD_WHERE1, sRepSql_Sinsei.ToString(), bindList);
						// テーブルID設定
						BoSystemSql.AddSql(rtSearch, Tf010p01Constant.SQL_ID_01_REP_TABLE_ID2, sTblId2 + " T1", bindList);
						// 検索条件設定
						BoSystemSql.AddSql(rtSearch, Tf010p01Constant.SQL_ID_01_REP_ADD_WHERE2, sRepSql_Kakutei.ToString(), bindList);
						break;
				}

				#endregion

				#region オーダーバイの追加

				StringBuilder sbOrderSql = new StringBuilder();

				sbOrderSql.AppendLine("");
				sbOrderSql.AppendLine("					ORDER BY ");
				sbOrderSql.AppendLine("						 APPLY_YMD ");
				sbOrderSql.AppendLine("						,KAKUTEI_YMD ");
				sbOrderSql.AppendLine("						,TENPO_CD ");
				sbOrderSql.AppendLine("						,DENPYO_BANGO ");
				sbOrderSql.AppendLine("						,DENPYOGYO_NO ");

				BoSystemSql.AddSql(rtSearch, Tf010p01Constant.SQL_ID_01_REP_ADD_ORDER1, sbOrderSql.ToString(), new ArrayList());

				#endregion

				//検索結果を取得します
				rtSearch.CreateDbCommand();
				IList<Hashtable> tableList = rtSearch.Execute();

				BoSystemLog.logOut("SQL: " + rtSearch.LogSql);

				if (tableList == null || tableList.Count <= 0)
				{
					// エラー
					ErrMsgCls.AddErrMsg("E174", String.Empty, facadeContext);
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region CSV出力設定

				// CSV出力用リスト
				IList<IList<string>> csvList = new List<IList<string>>();

				// ヘッダ項目の設定
				csvList.Add(this.getCsvHeader());

				// データ項目の設定
				foreach (Hashtable rec in tableList)
				{
					IList<string> csvListData = new List<string>();

					csvListData.Add(BoSystemFormat.formatTenpoCd(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_cd)].ToString()));
																										// 店舗コード
					csvListData.Add(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_nm)].ToString());
																										// 店舗名
					csvListData.Add(BoSystemFormat.formatDate(rec["APPLY_YMD"].ToString()));			// 申請日
					if ("0".Equals(rec["KAKUTEI_YMD"].ToString()))
					{
						csvListData.Add("");															// 確定日
					}
					else
					{
						csvListData.Add(BoSystemFormat.formatDate(rec["KAKUTEI_YMD"].ToString()));		// 確定日
					}
					csvListData.Add(BoSystemFormat.formatTenpoCd(rec["TENPO_CD"].ToString()));			// 申請店舗コード
					csvListData.Add(rec["TENPO_NM"].ToString());										// 申請店舗名
					csvListData.Add(BoSystemFormat.formatDenpyoNo(rec["DENPYO_BANGO"].ToString()));		// 伝票番号
					csvListData.Add(rec["JYURI_NO"].ToString());										// 受理番号
					if (!"0".Equals(rec["GYOMURINGI_NO"].ToString()))
					{
						csvListData.Add(rec["GYOMURINGI_NO"].ToString());
					}
					else
					{
						csvListData.Add(string.Empty);
					}																					// 業務稟議No
					csvListData.Add(rec["KAMOKU_CD"].ToString());										// 科目コード
					csvListData.Add(rec["KAMOKU_NM"].ToString());										// 科目名
					csvListData.Add(rec["SURYO_KEI"].ToString());										// 合計数量
					csvListData.Add(rec["GENKA"].ToString());											// 原価金額
					csvListData.Add(BoSystemFormat.formatTantoCd(rec["SINSEITAN_CD"].ToString()));		// 申請担当者コード
					csvListData.Add(rec["HANBAIIN_NM"].ToString());										// 申請担当者名
					csvListData.Add(BoSystemFormat.formatTantoCd(rec["KAKUTEITAN_CD"].ToString()));		// 確定担当者コード
					csvListData.Add(rec["KAKUTEITAN_NM"].ToString());									// 確定担当者名
					csvListData.Add(rec["SINSEIRIYU"].ToString());										// 申請理由
					csvListData.Add(rec["KYAKKARIYU"].ToString());										// 却下理由
					csvListData.Add(rec["SYONIN"].ToString());											// 承認状態
					csvListData.Add(rec["DENPYOGYO_NO"].ToString());									// 行番号
					csvListData.Add(BoSystemFormat.formatBumonCd(rec["BUMON_CD"].ToString()));			// 部門コード
					csvListData.Add(rec["BUMON_NM"].ToString());										// 部門名
					csvListData.Add(BoSystemFormat.formatHinsyuCd(rec["HINSYU_CD"].ToString()));		// 品種コード
					csvListData.Add(rec["HINSYU_RYAKU_NM"].ToString());									// 品種名
					csvListData.Add(BoSystemFormat.formatBrandCd(rec["BURANDO_CD"].ToString()));		// ブランドコード
					csvListData.Add(rec["BURANDO_NMK"].ToString());										// ブランド名
					csvListData.Add(BoSystemFormat.formatJisyaHbn(rec["JISYA_HBN"].ToString()));		// 自社品番
					csvListData.Add(rec["MAKER_HBN"].ToString());										// メーカー品番
					csvListData.Add(rec["SYONMK"].ToString());											// 商品名
					csvListData.Add(rec["IRO_NM"].ToString());											// 色名
					csvListData.Add(rec["SIZE_NM"].ToString());											// サイズ名
					csvListData.Add(BoSystemFormat.formatJanCd(rec["JAN_CD"].ToString()));				// スキャンコード
					csvListData.Add(rec["SURYO"].ToString());											// 数量
					csvListData.Add(rec["HYOKA_TNK"].ToString());										// 原単価
					csvListData.Add(rec["GENKA_KIN"].ToString());										// 原価金額
					csvListData.Add(rec["BAIKA_TNK"].ToString());										// 現売価
					csvListData.Add(rec["BAIKA_KIN"].ToString());										// 売価金額
					
					csvList.Add(csvListData);
				}

				// CSV出力
				string tmpFileName = BoSystemCsvUtil.CsvOut(csvList, PGID, BoSystemConstant.CSVID_KEIHI);

				// 一時ファイルをユーザマップに設定
				facadeContext.UserMap.Add(Tf010p01Constant.FCDUO_CSV_FLNM, tmpFileName);

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
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNCSV_FRM");

		}
		#endregion

		#region CSVヘッダ項目設定

		/// <summary>
		/// getCsvHeader CSVヘッダ項目設定
		/// </summary>
		/// <returns>IList</returns>
		private IList<string> getCsvHeader()
		{

			IList<string> csvListData = new List<string>();

			csvListData.Add("店舗コード");
			csvListData.Add("店舗名");
			csvListData.Add("申請日");
			csvListData.Add("確定日");
			csvListData.Add("申請店舗コード");
			csvListData.Add("申請店舗名");
			csvListData.Add("伝票番号");
			csvListData.Add("受理番号");
			csvListData.Add("業務稟議No");
			csvListData.Add("科目コード");
			csvListData.Add("科目名");
			csvListData.Add("合計数量");
			csvListData.Add("原価金額");
			csvListData.Add("申請担当者コード");
			csvListData.Add("申請担当者名");
			csvListData.Add("確定担当者コード");
			csvListData.Add("確定担当者名");
			csvListData.Add("申請理由");
			csvListData.Add("却下理由");
			csvListData.Add("承認状態");
			csvListData.Add("行番号");
			csvListData.Add("部門コード");
			csvListData.Add("部門名");
			csvListData.Add("品種コード");
			csvListData.Add("品種名");
			csvListData.Add("ブランドコード");
			csvListData.Add("ブランド名");
			csvListData.Add("自社品番");
			csvListData.Add("メーカー品番");
			csvListData.Add("商品名");
			csvListData.Add("色名");
			csvListData.Add("サイズ名");
			csvListData.Add("スキャンコード");
			csvListData.Add("数量");
			csvListData.Add("原単価");
			csvListData.Add("原価金額");
			csvListData.Add("現売価");
			csvListData.Add("売価金額");

			return csvListData;

		}
		#endregion
	}
}
