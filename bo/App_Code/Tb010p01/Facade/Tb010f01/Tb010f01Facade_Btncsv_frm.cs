using com.xebio.bo.Tb010p01.Constant;
using com.xebio.bo.Tb010p01.Formvo;
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
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace com.xebio.bo.Tb010p01.Facade
{
  /// <summary>
  /// Tb010f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tb010f01Facade : StandardBaseFacade
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
				////コネクションを取得して、トランザクションを開始する。
				//BeginTransactionWithConnect(facadeContext);
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
				Tb010f01Form f01VO = (Tb010f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				// Dictionaryから検索条件を取得
				String denpyoJyotai = (string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Denpyo_jyotai)];

				#endregion

				#region 業務チェック

				#region 行数チェック

				// 1-1 選択状態
				// 1件も選択されていない場合、エラー
				if (m1List == null || m1List.Count <= 0)
				{
					// 印刷する行を選択して下さい。
					ErrMsgCls.AddErrMsg("E119", String.Empty, facadeContext, new[] { "印刷する行" });
				}
				else
				{
					int inputflg = 0;
					for (int i = 0; i < m1List.Count; i++)
					{
						Tb010f01M1Form f01m1VO = (Tb010f01M1Form)m1List[i];
						if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
						{
							inputflg = 1;
							break;
						}
					}
					if (inputflg == 0)
					{
						// 確定対象がありません。
						ErrMsgCls.AddErrMsg("E119", "CSV出力する行", facadeContext);
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

				#region テーブルID設定
				// テーブルIDを設定 -----------
				// 伝票状態によってSQL、SQLIDを変更する
				ArrayList bindList = new ArrayList();

				String sSqlId = null;
				String sTblId1 = null;
				String sTblId2 = null;

				switch (denpyoJyotai)
				{
					// 「未処理」「仕掛中」の場合
					case ConditionSiiire_denpyo_jotai.VALUE_SIIIRE_DENPYO_JOTAI2:
					case ConditionSiiire_denpyo_jotai.VALUE_SIIIRE_DENPYO_JOTAI3:
						sSqlId = Tb010p01Constant.SQL_ID_11;
						sTblId1 = Tb010p01Constant.TABLE_ID_MDPT0010;	// 仕入入荷予定テーブル(H)
						break;

					// 「確定」「ﾏﾆｭｱﾙ仕入」「差異あり」の場合
					case ConditionSiiire_denpyo_jotai.VALUE_SIIIRE_DENPYO_JOTAI1:
					case ConditionSiiire_denpyo_jotai.VALUE_SIIIRE_DENPYO_JOTAI4:
					case ConditionSiiire_denpyo_jotai.VALUE_SIIIRE_DENPYO_JOTAI5:
						sSqlId = Tb010p01Constant.SQL_ID_12;
						sTblId1 = Tb010p01Constant.TABLE_ID_MDPT0020;	// 仕入入荷確定テーブル(H)
						break;

					// 「登録履歴」「取消履歴」の場合
					case ConditionSiiire_denpyo_jotai.VALUE_SIIIRE_DENPYO_JOTAI6:
					case ConditionSiiire_denpyo_jotai.VALUE_SIIIRE_DENPYO_JOTAI7:
						sSqlId = Tb010p01Constant.SQL_ID_13;
						sTblId1 = Tb010p01Constant.TABLE_ID_MDPT0060;	// 仕入入荷履歴テーブル(H)
						break;

					// 空白の場合
					default:
						sSqlId = Tb010p01Constant.SQL_ID_10;
						sTblId1 = Tb010p01Constant.TABLE_ID_MDPT0010;	// 仕入入荷予定テーブル(H)
						sTblId2 = Tb010p01Constant.TABLE_ID_MDPT0020;	// 仕入入荷確定テーブル(H)
						break;
				}

				FindSqlResultTable rtSearch = FindSqlUtil.CreateFindSqlResultTable(sSqlId, facadeContext.DBContext);

				BoSystemSql.AddSql(rtSearch, Tb010p01Constant.SQL_ID_01_REP_TABLE_ID1, sTblId1 + " T1", bindList);

				// 伝票状態が空白の場合
				if (BoSystemConstant.DROPDOWNLIST_MISENTAKU.Equals(denpyoJyotai))
				{
					BoSystemSql.AddSql(rtSearch, Tb010p01Constant.SQL_ID_01_REP_TABLE_ID2, sTblId2 + " T1", bindList);
				}

				#endregion

				// 検索条件設定
				this.AddWhereForCsv(f01VO, rtSearch, sTblId1, Tb010p01Constant.SQL_ID_01_REP_ADD_WHERE1);

				// 伝票状態が空白の場合
				if (BoSystemConstant.DROPDOWNLIST_MISENTAKU.Equals(denpyoJyotai))
				{
					this.AddWhereForCsv(f01VO, rtSearch, sTblId2, Tb010p01Constant.SQL_ID_01_REP_ADD_WHERE2);
				}

				//検索結果を取得します
				rtSearch.CreateDbCommand();
				IList<Hashtable> tableList = rtSearch.Execute();

				BoSystemLog.logOut("SQL: " + rtSearch.LogSql);

				if (tableList == null || tableList.Count <= 0)
				{
					// エラー
					ErrMsgCls.AddErrMsg("E174", String.Empty, facadeContext);
				}
				else
				{
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

					csvListData.Add(BoSystemFormat.formatTenpoCd(rec["TENPO_CD"].ToString()));			// 店舗コード
					csvListData.Add(rec["TENPO_NM"].ToString());										// 店舗名
					csvListData.Add(BoSystemFormat.formatBumonCd(rec["BUMON_CD"].ToString()));			// 部門コード
					csvListData.Add(rec["BUMONKANA_NM"].ToString());									// 部門カナ名
					csvListData.Add(BoSystemFormat.formatSiiresakiCd(rec["SIIRESAKI_CD"].ToString()));	// 仕入先コード
					csvListData.Add(rec["SIIRESAKI_RYAKU_NM"].ToString());								// 仕入先略式名称
					csvListData.Add(BoSystemFormat.formatDate(rec["SITEINOHIN_YMD"].ToString()));		// 入荷予定日
					csvListData.Add(BoSystemFormat.formatDenpyoNo(rec["DENPYO_BANGO"].ToString()));		// 伝票番号
					csvListData.Add(BoSystemFormat.formatDenpyoNo(rec["MOTODENPYO_BANGO"].ToString()));	// 元伝票番号
					csvListData.Add(rec["SIIREYOTEIGOKEI_SU"].ToString());								// 合計予定数量
					csvListData.Add(rec["SIIREJISSEKIGOKEI_SU"].ToString());							// 合計確定数量
					csvListData.Add(rec["SIIREJISSEKIGOKEI_KIN"].ToString());							// 合計原価金額
					csvListData.Add(BoSystemFormat.formatDate(rec["JYURYO_YMD"].ToString()));			// 仕入確定日
					csvListData.Add(BoSystemFormat.formatTantoCd(rec["ADDTAN_CD"].ToString()));			// 登録担当者コード
					csvListData.Add(rec["ADDTAN_NM"].ToString());										// 登録担当者名
					csvListData.Add(BoSystemFormat.formatTantoCd(rec["UPD_TANCD"].ToString()));			// 更新担当者コード
					csvListData.Add(rec["UPD_TANNM"].ToString());										// 更新担当者名
					csvListData.Add(rec["DENJYOTAI_NM"].ToString());									// 伝票状態
					csvListData.Add(rec["SYORI_NM"].ToString());										// 処理
					csvListData.Add(BoSystemFormat.formatDate(rec["SYORI_YMD"].ToString()));			// 処理日
					csvListData.Add(rec["SYORI_TM"].ToString());										// 処理時間
					csvListData.Add(rec["DENPYOGYO_NO"].ToString());									// 行番号
					csvListData.Add(BoSystemFormat.formatBrandCd(rec["BURANDO_CD"].ToString()));		// ブランドコード
					csvListData.Add(rec["BURANDO_NMK"].ToString());										// ブランド名
					csvListData.Add(BoSystemFormat.formatJisyaHbn(rec["JISYA_HBN"].ToString()));		// 自社品番
					csvListData.Add(rec["MAKER_HBN"].ToString());										// メーカー品番
					csvListData.Add(rec["SYONMK"].ToString());											// 商品名
					csvListData.Add(rec["IRO_NM"].ToString());											// 色名
					csvListData.Add(rec["SIZE_NM"].ToString());											// サイズ名
					csvListData.Add(BoSystemFormat.formatJanCd(rec["JAN_CD"].ToString()));				// スキャンコード
					csvListData.Add(rec["YOTEI_SU"].ToString());										// 納品数
					csvListData.Add(rec["JISSEKI_SU"].ToString());										// 検数
					csvListData.Add(rec["GEN_TNK"].ToString());											// 原単価
					csvListData.Add(rec["GENKAKIN"].ToString());										// 原価金額
					csvListData.Add(rec["KYAKUTYU_FLG"].ToString());									// 客注フラグ
					csvListData.Add(rec["NEGAKIHIN_FLG"].ToString());									// 値書フラグ

					csvList.Add(csvListData);
				}
				
				// CSV出力
				string tmpFileName = BoSystemCsvUtil.CsvOut(csvList, PGID, BoSystemConstant.CSVID_SIIRE);

				// 一時ファイルをユーザマップに設定
				facadeContext.UserMap.Add(Tb010p01Constant.FCDUO_CSV_FLNM, tmpFileName);

				#endregion


				////トランザクションをコミットする。
				//CommitTransaction(facadeContext);
			}
			catch (System.Exception ex)
			{
				////トランザクションをロールバックする。
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
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNCSV_FRM");

		}
		#endregion

		#region 検索条件設定
		/// <summary>
		/// AddWhere 検索条件設定
		/// </summary>
		/// <param name="f01VO">Tb010f01Form</param>
		/// <param name="FindSqlResultTable">rtChk</param>
		/// <param name="String">table_id</param>
		/// <param name="String">add_where_id</param>
		/// <returns></returns>
		private void AddWhereForCsv(Tb010f01Form f01VO, FindSqlResultTable reader,String table_id,  String add_where_id)
		{
			ArrayList bindList = new ArrayList();
			BindInfoVO bindVO = new BindInfoVO();
			StringBuilder sRepSql = new StringBuilder();

			// バインドIDを作成
			StringBuilder sBindId = new StringBuilder();

			//  Dictionaryより取得
			String tenpoCd = BoSystemFormat.formatTenpoCd((string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_cd)]);
			String denpyoJyotai = (string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Denpyo_jyotai)];

			// 検索条件を設定 -----------

			// 明細行Listの取得
			IDataList m1List = f01VO.GetList("M1");

			// データが存在するかのフラグ
			Boolean bExistsF = false;

			// 明細行数分繰り返す
			for (int i = 0; i < m1List.Count; i++)
			{
				Tb010f01M1Form f01m1VO = (Tb010f01M1Form)m1List[i];

				// 選択されている行の場合
				if (BoSystemConstant.CHECKBOX_ON.Equals(f01m1VO.M1selectorcheckbox))
				{

					// 伝票状態が空白場合
					if (BoSystemConstant.DROPDOWNLIST_MISENTAKU.Equals(denpyoJyotai))
					{
						// 入荷予定テーブルの場合は確定種別がNULLではない場合にSKIP
						// 入荷確定テーブルの場合は確定種別がNULLの場合にSKIP
						if ((Tb010p01Constant.TABLE_ID_MDPT0010.Equals(table_id)
								&& !string.IsNullOrEmpty((string)f01m1VO.Dictionary[Tb010p01Constant.DIC_M1KAKUTEI_SB]))
							|| (Tb010p01Constant.TABLE_ID_MDPT0020.Equals(table_id)
								&& string.IsNullOrEmpty((string)f01m1VO.Dictionary[Tb010p01Constant.DIC_M1KAKUTEI_SB]))
							)
						{
							continue;
						}
					}

					// 先頭行以外はコンマを追記
					if (bExistsF)
					{
						sRepSql.Append(" , ");
					}

					// 条件設定
					sRepSql.Append(" ( ");

					// 仕入入荷予定テーブル以外の場合
					if (!Tb010p01Constant.TABLE_ID_MDPT0010.Equals(table_id))
					{
						// 確定種別
						sBindId = new StringBuilder();
						sBindId.Append("BIND_KAKU_SB").Append(i.ToString("0000"));
						sRepSql.Append(" :").Append(sBindId.ToString());

						bindVO = new BindInfoVO();
						bindVO.BindId = sBindId.ToString();
						bindVO.Value = (string)f01m1VO.Dictionary[Tb010p01Constant.DIC_M1KAKUTEI_SB];
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						sRepSql.Append(" ,");
					}

					// 仕入先コード
					sBindId = new StringBuilder();
					sBindId.Append("BIND_SIIRE_CD").Append(i.ToString("0000"));
					sRepSql.Append(" :").Append(sBindId.ToString());

					bindVO = new BindInfoVO();
					bindVO.BindId = sBindId.ToString();
					bindVO.Value = BoSystemFormat.formatSiiresakiCd((string)f01m1VO.M1siiresaki_cd);
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 伝票番号
					sBindId = new StringBuilder();
					sBindId.Append("BIND_DEN_NO").Append(i.ToString("0000"));
					sRepSql.Append(" ,:").Append(sBindId.ToString());

					bindVO = new BindInfoVO();
					bindVO.BindId = sBindId.ToString();
					bindVO.Value = BoSystemFormat.formatDenpyoNo((string)f01m1VO.Dictionary[Tb010p01Constant.DIC_M1DENPYO_BANGO]);
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 指定納品日
					sBindId = new StringBuilder();
					sBindId.Append("BIND_SITEI_YMD").Append(i.ToString("0000"));
					sRepSql.Append(" ,:").Append(sBindId.ToString());

					bindVO = new BindInfoVO();
					bindVO.BindId = sBindId.ToString();
					bindVO.Value = BoSystemFormat.formatDate((string)f01m1VO.M1nyukayotei_ymd);
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 店舗コード
					sBindId = new StringBuilder();
					sBindId.Append("BIND_TENPO_CD").Append(i.ToString("0000"));
					sRepSql.Append(" ,:").Append(sBindId.ToString());

					bindVO = new BindInfoVO();
					bindVO.BindId = sBindId.ToString();
					bindVO.Value = BoSystemFormat.formatTenpoCd(tenpoCd);
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 仕入入荷履歴テーブルの場合
					if (Tb010p01Constant.TABLE_ID_MDPT0060.Equals(table_id))
					{
						// 履歴No
						sBindId = new StringBuilder();
						sBindId.Append("BIND_RIREKI_NO").Append(i.ToString("0000"));
						sRepSql.Append(" ,:").Append(sBindId.ToString());

						bindVO = new BindInfoVO();
						bindVO.BindId = sBindId.ToString();
						bindVO.Value = (string)f01m1VO.Dictionary[Tb010p01Constant.DIC_M1RIREKI_NO];
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						// 赤黒区分
						sBindId = new StringBuilder();
						sBindId.Append("BIND_AKAKURO_KBN").Append(i.ToString("0000"));
						sRepSql.Append(" ,:").Append(sBindId.ToString());

						bindVO = new BindInfoVO();
						bindVO.BindId = sBindId.ToString();
						bindVO.Value = (string)f01m1VO.Dictionary[Tb010p01Constant.DIC_M1AKAKURO_KBN];
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);

					}

					sRepSql.Append(" )");

					// フラグ更新
					bExistsF = true;

				}

			}

			// 対象件数が0件の場合
			if (!bExistsF)
			{
				// 条件設定
				sRepSql.Append(" (");
				// 仕入入荷予定テーブル以外の場合
				if (!Tb010p01Constant.TABLE_ID_MDPT0010.Equals(table_id))
				{
					sRepSql.Append("0, ");
				}

				sRepSql.Append(" '0', 0, 0, '0' ");

				// 仕入入荷履歴テーブルの場合
				if (Tb010p01Constant.TABLE_ID_MDPT0060.Equals(table_id))
				{
					sRepSql.Append(", 0, 0");
				}

				sRepSql.Append(" )");
			}

			BoSystemSql.AddSql(reader, add_where_id, sRepSql.ToString(), bindList);

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
			csvListData.Add("部門コード");
			csvListData.Add("部門名");
			csvListData.Add("仕入先コード");
			csvListData.Add("仕入先名");
			csvListData.Add("入荷予定日");
			csvListData.Add("伝票番号");
			csvListData.Add("元伝票番号");
			csvListData.Add("合計予定数量");
			csvListData.Add("合計確定数量");
			csvListData.Add("合計原価金額");
			csvListData.Add("仕入確定日");
			csvListData.Add("登録担当者コード");
			csvListData.Add("登録担当者名");
			csvListData.Add("更新担当者コード");
			csvListData.Add("更新担当者名");
			csvListData.Add("伝票状態");
			csvListData.Add("処理");
			csvListData.Add("処理日");
			csvListData.Add("処理時間");
			csvListData.Add("行番号");
			csvListData.Add("ブランドコード");
			csvListData.Add("ブランド名");
			csvListData.Add("自社品番");
			csvListData.Add("メーカー品番");
			csvListData.Add("商品名");
			csvListData.Add("色名");
			csvListData.Add("サイズ名");
			csvListData.Add("スキャンコード");
			csvListData.Add("納品数");
			csvListData.Add("検数");
			csvListData.Add("原単価");
			csvListData.Add("原価金額");
			csvListData.Add("客注フラグ");
			csvListData.Add("値書フラグ");

			return csvListData;

		}
		#endregion

	}
}
