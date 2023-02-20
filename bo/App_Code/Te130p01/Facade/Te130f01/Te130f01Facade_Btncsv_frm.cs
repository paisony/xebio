using com.xebio.bo.Te130p01.Constant;
using com.xebio.bo.Te130p01.Formvo;
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

namespace com.xebio.bo.Te130p01.Facade
{
  /// <summary>
  /// Te130f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Te130f01Facade : StandardBaseFacade
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
				Te130f01Form f01VO = (Te130f01Form)facadeContext.FormVO;
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
						Te130f01M1Form f01m1VO = (Te130f01M1Form)m1List[i];
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


				FindSqlResultTable rtSearch = FindSqlUtil.CreateFindSqlResultTable(Te130p01Constant.SQL_ID_11, facadeContext.DBContext);
				#endregion

				// 検索条件設定
				//	this.AddWherecsv(f01VO, rtSearch, sTblId1, Te130p01Constant.SQL_ID_01_REP_ADD_WHERE1);//from~
				this.AddWherecsv(f01VO, rtSearch, 1);//from~

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
				csvList.Add(this.getCsvHeader(f01VO));

				// データ項目の設定
				foreach (Hashtable rec in tableList)
				{
					IList<string> csvListData = new List<string>();
					Te130f01M1Form f01m1VO = new Te130f01M1Form();

					csvListData.Add(rec["SYUKKAKAISYA_NM"].ToString());									// 出荷会社略名
					csvListData.Add(BoSystemFormat.formatTenpoCd(rec["SYUKKATEN_CD"].ToString()));		// 出荷会社店舗コード
					csvListData.Add(rec["SYUKKATEN_NM"].ToString());									// 出荷会社店舗名
					csvListData.Add(rec["NYUKAKAISYA_NM"].ToString());									// 入荷会社略名
					csvListData.Add(BoSystemFormat.formatTenpoCd(rec["JYURYOTEN_CD"].ToString()));		// 入荷会社店舗コード
					csvListData.Add(rec["NYUKATEN_NM"].ToString());										// 入荷会社店舗名

					//csvListData.Add(BoSystemFormat.formatDenpyoNo(rec["DENPYO_BANGO"].ToString()));		// 伝票番号
					//csvListData.Add(BoSystemFormat.formatDenpyoNo(rec["IDODENPYO_BANGO"].ToString()));	// 移動伝票
					//csvListData.Add(BoSystemFormat.formatIdoSijiNo(rec["SYUKKA_SIJI_NO"].ToString()));	// 指示番号
					csvListData.Add(rec["DENPYO_BANGO"].ToString());		// 伝票番号
					csvListData.Add(rec["IDODENPYO_BANGO"].ToString());		// 移動伝票
					csvListData.Add(rec["SYUKKA_SIJI_NO"].ToString());		// 指示番号

					csvListData.Add(BoSystemFormat.formatDate(rec["SYUKKA_YMD"].ToString()));			// 出荷日
					csvListData.Add(BoSystemFormat.formatDate(rec["JYURYO_YMD"].ToString()));			// 入荷日
					csvListData.Add(rec["NYUKAYOTEIGOUKEI_SU"].ToString());								// 合計予定数
					csvListData.Add(rec["NYUKAJISSEKIGOUKEI_SU"].ToString());							// 合計確定数
					if (f01VO.Denpyo_jyotai.Equals(ConditionKigyokan_denpyo_jotai.VALUE_DENPYO_JOTAI1)
						|| f01VO.Denpyo_jyotai.Equals(ConditionKigyokan_denpyo_jotai.VALUE_DENPYO_JOTAI3)
						|| f01VO.Denpyo_jyotai.Equals(BoSystemConstant.DROPDOWNLIST_MISENTAKU))
					{
						csvListData.Add(string.Empty);	// Ｍ１処理名
						csvListData.Add(string.Empty);	// Ｍ１処理日
						csvListData.Add(string.Empty);	// Ｍ１処理時間
					}
					else
					{
						csvListData.Add(rec["SYORI"].ToString());											// Ｍ１処理名
						csvListData.Add(BoSystemFormat.formatDate(rec["RIREKI_SYORI_YMD"].ToString()));		// Ｍ１処理日
						csvListData.Add(rec["RIREKI_SYORI_TM"].ToString());									// Ｍ１処理時間
					}
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
					csvListData.Add(rec["NYUKAYOTEI_SU"].ToString());									// 予定数量
					csvListData.Add(rec["NYUKAJISSEKI_SU"].ToString());									// 確定数量
					csvListData.Add(rec["GEN_TNK"].ToString());											// 原単価
					csvListData.Add(rec["GEN_KIN"].ToString());											// 原価金額

					csvList.Add(csvListData);
				}

				// CSV出力
				string tmpFileName = BoSystemCsvUtil.CsvOut(csvList, PGID, BoSystemConstant.CSVID_KIGYOKAN);

				// 一時ファイルをユーザマップに設定
				facadeContext.UserMap.Add(Te130p01Constant.FCDUO_CSV_FLNM, tmpFileName);

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

		private void AddWherecsv(Te130f01Form f01VO, FindSqlResultTable reader, int selKbn)
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
				Te130f01M1Form f01m1VO = (Te130f01M1Form)m1List[i];

				// 選択されている行の場合
				if (BoSystemConstant.CHECKBOX_ON.Equals(f01m1VO.M1selectorcheckbox))
				{
					// 先頭行以外はコンマを追記
					if (bExistsF)
					{
						sRepSql.Append(" , ");
					}

					// 条件設定
					sRepSql.Append(" ( ");

					// 入荷会社コード
					sBindId = new StringBuilder();
					sBindId.Append("BIND_JYURYOKAISYA_CD").Append(i.ToString("0000"));
					sRepSql.Append(" :").Append(sBindId.ToString());

					bindVO = new BindInfoVO();
					bindVO.BindId = sBindId.ToString();
					bindVO.Value = BoSystemFormat.formatKaisyaCd(f01m1VO.Dictionary[Te130p01Constant.DIC_M1NYUKAKAI_CD].ToString());
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 入荷店コード
					sBindId = new StringBuilder();
					sBindId.Append("BIND_JYURYOTEN_CD").Append(i.ToString("0000"));
					sRepSql.Append(" ,:").Append(sBindId.ToString());

					bindVO = new BindInfoVO();
					bindVO.BindId = sBindId.ToString();
					bindVO.Value = BoSystemFormat.formatTenpoCd((string)f01m1VO.M1jyuryoten_cd);
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 伝票番号
					sBindId = new StringBuilder();
					sBindId.Append("BIND_DENPYOBANGO").Append(i.ToString("0000"));
					sRepSql.Append(" ,:").Append(sBindId.ToString());

					bindVO = new BindInfoVO();
					bindVO.BindId = sBindId.ToString();
					bindVO.Value = BoSystemFormat.formatDenpyoNo((string)f01m1VO.Dictionary[Te130p01Constant.DIC_M1DENPYOBANGO]);
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 入荷日
					sBindId = new StringBuilder();
					sBindId.Append("BIND_JYURYO_YMD").Append(i.ToString("0000"));
					sRepSql.Append(" ,:").Append(sBindId.ToString());

					bindVO = new BindInfoVO();
					bindVO.BindId = sBindId.ToString();
					bindVO.Value = BoSystemFormat.formatDate((string)f01m1VO.M1jyuryo_ymd);
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 履歴No
					sBindId = new StringBuilder();
					sBindId.Append("BIND_RIREKI_NO").Append(i.ToString("0000"));
					sRepSql.Append(" ,:").Append(sBindId.ToString());

					bindVO = new BindInfoVO();
					bindVO.BindId = sBindId.ToString();
					bindVO.Value = (string)f01m1VO.Dictionary[Te130p01Constant.DIC_M1RIREKI_NO];
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 赤黒区分
					sBindId = new StringBuilder();
					sBindId.Append("BIND_AKAKURO_KBN").Append(i.ToString("0000"));
					sRepSql.Append(" ,:").Append(sBindId.ToString());

					bindVO = new BindInfoVO();
					bindVO.BindId = sBindId.ToString();
					bindVO.Value = (string)f01m1VO.Dictionary[Te130p01Constant.DIC_M1AKAKURO_KBN];
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);


					sRepSql.Append(" )");

					// フラグ更新
					bExistsF = true;

				}
			}
			sRepSql.Append(" )");

			// 対象件数が0件の場合
			if (!bExistsF)
			{
				// 条件設定
				sRepSql.Append(" (");

				sRepSql.Append(" 0, '0', 0, 0, 0, 0 ");

				sRepSql.Append(" )");
			}

			BoSystemSql.AddSql(reader, Te130p01Constant.SQL_ID_01_REP_ADD_WHERE1, sRepSql.ToString(), bindList);

		}

		#endregion

		#region CSVヘッダ項目設定

		/// <summary>
		/// getCsvHeader CSVヘッダ項目設定
		/// </summary>
		/// <returns>IList</returns>
		private IList<string> getCsvHeader(Te130f01Form f01VO)
		{

			IList<string> csvListData = new List<string>();


			csvListData.Add("出荷会社略名");
			csvListData.Add("出荷会社店舗コード");
			csvListData.Add("出荷会社店舗名");
			csvListData.Add("入荷会社略名");
			csvListData.Add("入荷会社店舗コード");
			csvListData.Add("入荷会社店舗名");
			csvListData.Add("伝票番号");
			csvListData.Add("移動伝票");
			csvListData.Add("指示番号");
			csvListData.Add("出荷日");
			csvListData.Add("入荷日");
			csvListData.Add("合計予定数");
			csvListData.Add("合計確定数");
			csvListData.Add("処理");
			csvListData.Add("処理日");
			csvListData.Add("処理時間");
			csvListData.Add("部門コード");
			csvListData.Add("部門名");
			csvListData.Add("品種コード");
			csvListData.Add("品種名");
			csvListData.Add("ブランドコード");
			csvListData.Add("ブランド名");
			csvListData.Add("自社品番");
			csvListData.Add("メーカー品番");
			csvListData.Add("商品名");
			csvListData.Add("色");
			csvListData.Add("サイズ");
			csvListData.Add("スキャンコード");
			csvListData.Add("予定数量");
			csvListData.Add("確定数量");
			csvListData.Add("原単価");
			csvListData.Add("原価金額");

			return csvListData;

		}
		#endregion
	}
}
