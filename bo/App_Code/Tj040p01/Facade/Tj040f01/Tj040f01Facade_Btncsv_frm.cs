using com.xebio.bo.Tj040p01.Constant;
using com.xebio.bo.Tj040p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.ReportUtil;
using Common.Business.C99999.SqlUtil;
using Common.Conditions;
using Common.IntegrationMD.Util;
using Common.Standard.Base;
using Common.Standard.Csv;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace com.xebio.bo.Tj040p01.Facade
{
  /// <summary>
  /// Tj040f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tj040f01Facade : StandardBaseFacade
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
                //コネクションを取得して、トランザクションを開始する。
                //BeginTransactionWithConnect(facadeContext);
                OpenConnection(facadeContext);

                //以下に業務ロジックを記述する。

                // ログイン情報取得
                LoginInfoVO loginInfVO = LoginInfoUtil.GetLoginInfo();

                // FormVO取得
                // 画面より情報を取得する。
                Tj040f01Form formVO = (Tj040f01Form)facadeContext.FormVO;
                IDataList m1List = formVO.GetList("M1");

                #region 業務チェック

                #region 1. 選択行チェック

                // 1-1 選択行
                //       1件も選択されていない場合、エラー 
                if (m1List == null || m1List.Count <= 0)
                {
                    // CSV出力を選択して下さい。
					ErrMsgCls.AddErrMsg("E119", "CSV出力する行", facadeContext);
                }
                else
                {
                    int inputflg = 0;
                    for (int i = 0; i < m1List.Count; i++)
                    {
                        Tj040f01M1Form m1formVO = (Tj040f01M1Form)m1List[i];
                        if (m1formVO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
                        {
                            inputflg = 1;
                            break;
                        }
                    }
                    if (inputflg == 0)
                    {
						// CSV出力する行を選択して下さい。
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

                #region CSV出力処理

                #region 検索処理

                FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(Tj040p01Constant.SQL_ID_03, facadeContext.DBContext);

                // 検索条件設定
                // 店舗用WHERE句設定
                AddWhere(formVO, rtSeach, m1List, ConditionTenpo_gyosya_kbn.VALUE_TENPO);
                // 業者用用WHERE句設定
                AddWhere(formVO, rtSeach, m1List, ConditionTenpo_gyosya_kbn.VALUE_GYOSYA);

                // 検索結果を取得します
                rtSeach.CreateDbCommand();
                IList<Hashtable> tableList = rtSeach.Execute();

                if (logger.IsDebugEnabled)
                {
					BoSystemLog.logOut("SQL: " + rtSeach.LogSql);
                }

                // 件数チェック
                if (tableList == null || tableList.Count <= 0)
                {
                    // エラー
                    ErrMsgCls.AddErrMsg("E174", String.Empty, facadeContext);
                }

                // エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
                if (MessageDisplayUtil.HasError(facadeContext))
                {
                    return;
                }

                #endregion

                #region CSV出力

                // CSV出力用リスト
                IList<IList<string>> csvList = new List<IList<string>>();

				#region CSVヘッダ出力編集

				IList<string> csvHeadListData = new List<string>();

				// 店舗コード
				csvHeadListData.Add("店舗コード");
				// 店舗名
				csvHeadListData.Add("店舗名");
				// フェイス№
				csvHeadListData.Add("フェイス№");
				// 棚段
				csvHeadListData.Add("棚段");
				// 回数
				csvHeadListData.Add("回数");
				// 送信回数
				csvHeadListData.Add("送信回数");
				// 点数棚卸入力数
				csvHeadListData.Add("点数棚卸入力数");
				// 点数棚卸訂正数
				csvHeadListData.Add("点数棚卸訂正数");
				// 点数棚卸合計数
				csvHeadListData.Add("点数棚卸合計数");
				// 棚卸理由
				csvHeadListData.Add("棚卸理由");
				// 入力日
				csvHeadListData.Add("入力日");
				// 送信日
				csvHeadListData.Add("送信日");
				// 入力担当者コード
				csvHeadListData.Add("入力担当者コード");
				// 入力担当者名
				csvHeadListData.Add("入力担当者名");
				// 訂正担当者コード
				csvHeadListData.Add("訂正担当者コード");
				// 訂正担当者名
				csvHeadListData.Add("訂正担当者名");
				// 部門コード
				csvHeadListData.Add("部門コード");
				// 部門名
				csvHeadListData.Add("部門名");
				// 品種コード
				csvHeadListData.Add("品種コード");
				// 品種名
				csvHeadListData.Add("品種名");
				// ブランドコード
				csvHeadListData.Add("ブランドコード");
				// ブランド名
				csvHeadListData.Add("ブランド名");
				// 自社品番
				csvHeadListData.Add("自社品番");
				// メーカー品番
				csvHeadListData.Add("メーカー品番");
				// 商品名
				csvHeadListData.Add("商品名");
				// 色名
				csvHeadListData.Add("色名");
				// サイズ名
				csvHeadListData.Add("サイズ名");
				// スキャンコード
				csvHeadListData.Add("スキャンコード");
				// 棚卸スキャン数
				csvHeadListData.Add("棚卸スキャン数");
				// 棚卸訂正数
				csvHeadListData.Add("棚卸訂正数");
				// 棚卸合計数
				csvHeadListData.Add("棚卸合計数");
				// 店舗／業者
				csvHeadListData.Add("店舗／業者");

				csvList.Add(csvHeadListData);

				#endregion

				foreach (Hashtable rec in tableList)
				{
                    IList<string> csvListData = new List<string>();

                    #region CSV出力編集

                    // 店舗コード
                    csvListData.Add(BoSystemFormat.formatTenpoCd(rec["TENPO_CD"].ToString()));
                    // 店舗名
                    csvListData.Add(rec["TENPO_NM"].ToString());
                    // フェイス№
                    csvListData.Add(rec["FACE_NO"].ToString());
                    // 棚段
                    csvListData.Add(rec["TANA_DAN"].ToString());
                    // 回数
                    csvListData.Add(rec["KAI_SU"].ToString());
                    // 送信回数
                    csvListData.Add(rec["SOSINKAI_SU"].ToString());
                    // 点数棚卸入力数
                    csvListData.Add(rec["TENSUTANAOROSINYURYOKU_SU"].ToString());
                    // 点数棚卸訂正数
                    csvListData.Add(rec["TENSUTANAOROSITEISEI_SU"].ToString());
                    // 点数棚卸合計数
                    csvListData.Add(rec["TENSUTANAOROSIGOKEI_SU"].ToString());
                    // 棚卸理由
                    csvListData.Add(rec["TANAOROSIRIYU_NM"].ToString());
                    // 入力日
                    csvListData.Add(rec["ADD_YMD"].ToString());
                    // 送信日
                    csvListData.Add(rec["SOSIN_YMD"].ToString());
                    // 入力担当者コード
                    csvListData.Add(rec["ADDTAN_CD"].ToString());
                    // 入力担当者名
                    csvListData.Add(rec["ADDTAN_NM"].ToString());
                    // 訂正担当者コード
					csvListData.Add(rec["UPDTAN_CD"].ToString());
                    // 訂正担当者名
                    csvListData.Add(rec["UPDTAN_NM"].ToString());
                    // 部門コード
                    csvListData.Add(rec["BUMON_CD"].ToString());
                    // 部門名
                    csvListData.Add(rec["BUMONKANA_NM"].ToString());
                    // 品種コード
                    csvListData.Add(rec["HINSYU_CD"].ToString());
                    // 品種名
                    csvListData.Add(rec["HINSYU_RYAKU_NM"].ToString());
                    // ブランドコード
                    csvListData.Add(rec["BURANDO_CD"].ToString());
                    // ブランド名
					csvListData.Add(rec["BURANDO_NMK"].ToString());
                    // 自社品番
                    csvListData.Add(rec["JISYA_HBN"].ToString());
                    // メーカー品番
                    csvListData.Add(rec["MAKER_HBN"].ToString());
                    // 商品名
					csvListData.Add(rec["SYONMK"].ToString());
                    // 色名
                    csvListData.Add(rec["IRO_NM"].ToString());
                    // サイズ名
                    csvListData.Add(rec["SIZE_NM"].ToString());
                    // スキャンコード
                    csvListData.Add(rec["JAN_CD"].ToString());
                    // 棚卸スキャン数
                    csvListData.Add(rec["TANAOROSISCAN_SU"].ToString());
                    // 棚卸訂正数
                    csvListData.Add(rec["TANAOROSITEISEI_SU"].ToString());
                    // 棚卸合計数
                    csvListData.Add(rec["TANAOROSIGOKEI_SU"].ToString());
                    // 店舗／業者
					csvListData.Add(rec["TENPO_GYOSYA_NM"].ToString());

                    #endregion

					csvList.Add(csvListData);
                }

                // 一時ファイル格納ディレクトリを取得
                string tmpDir = FilePathManager.GetOutFilePath(PGID);
                // 一時ファイル名を取得
                string tmpFileName = string.Format("{0}{1}",
                                                    BoSystemReport.CreateFileName("TJ040C01"),
                                                    FilePathManager.EXT_CSV
                                                  );
                // 一時ファイルパスを取得
                string tmpFilePath = tmpDir + @"\" + tmpFileName;

                // 一時ファイルを出力
                StandardCsvWriter.WriteCsvFile(csvList, tmpFilePath, CsvUtil.DELIMITER.COMMA);

                // 一時ファイルをユーザマップに設定
                facadeContext.UserMap.Add(Tj040p01Constant.FCDUO_CSV_FLNM, tmpFileName);

                #endregion

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
            EndMethod(facadeContext, this.GetType().Name + ".DoBTNCSV_FRM");

		}
		#endregion

        #region 検索条件設定
        /// <summary>
        /// AddWhere 検索条件設定
        /// </summary>
        /// <param name="Tj040f01Form">formVO</param>
        /// <param name="FindSqlResultTable">reader</param>
        /// <param name="IDataList">f01m1VO</param>
 		/// <param name="int">tenpoGyosyaKb(1:店舗、2:業者)</param>
        /// <returns></returns>
        private void AddWhere(Tj040f01Form formVO, FindSqlResultTable reader, IDataList m1List, string tenpoGyosyaKb)
        {
            ArrayList  bindList = new ArrayList();
            BindInfoVO bindVO   = new BindInfoVO();

            StringBuilder sRepSql = new StringBuilder();

            String sREP_ID  = String.Empty;
            String sTableId = String.Empty;

            // バインドIDを作成
            StringBuilder sbindId = new StringBuilder();

            ArrayList m1formVOList = new ArrayList();

            // 店舗コード Dictionaryより取得
            String tenpocd = BoSystemFormat.formatTenpoCd((string)formVO.Dictionary[SearchConditionSaveCls.PREFIX + "Head_tenpo_cd".ToUpper()]);

            #region 店舗、業者抽出

            // 店舗、業者によって設定するWHERE句、テーブルを決定する
            if (ConditionTenpo_gyosya_kbn.VALUE_TENPO.Equals(tenpoGyosyaKb))
            {
                sREP_ID = "REPLACE_ID_MEISAI_SENTAKU1";
            }
            else
            {
                sREP_ID = "REPLACE_ID_MEISAI_SENTAKU2";
            }

            // 検索条件を設定 -----------

            sRepSql = new StringBuilder();

            int inputflg = 0;
            for (int i = 0; i < m1List.Count; i++)
            {
                Tj040f01M1Form m1formVO = (Tj040f01M1Form)m1List[i];

                // 選択されている行のみチェック
                if (BoSystemConstant.CHECKBOX_ON.Equals(m1formVO.M1selectorcheckbox))
                {
                    // 「Ｍ１店舗／業者区分」が"1"の存在チェック
                    if (tenpoGyosyaKb.Equals(m1formVO.Dictionary[Tj040p01Constant.DIC_M1TENPO_GYOSYA_KB]))
                    {
                        inputflg = 1;
                        m1formVOList.Add((Tj040f01M1Form)m1formVO);
                    }
                    // 「Ｍ１店舗／業者区分」が"2"の存在チェック
                    else if (tenpoGyosyaKb.Equals(m1formVO.Dictionary[Tj040p01Constant.DIC_M1TENPO_GYOSYA_KB]))
                    {
                        inputflg = 1;
                        m1formVOList.Add((Tj040f01M1Form)m1formVO);
                    }
                }
            }
            if (inputflg == 0)
            {
                sRepSql.Append(" AND 1 = 0");
                BoSystemSql.AddSql(reader, sREP_ID, sRepSql.ToString(), bindList);
                return;
            }

            #endregion

            #region 条件設定 店舗コード、店舗コード、棚段、回数、棚卸日、送信回数

            sRepSql.Append(" AND (");
            sRepSql.Append(sTableId).Append(" T1.TENPO_CD").Append(",");
			sRepSql.Append(sTableId).Append(" T1.FACE_NO").Append(",");
			sRepSql.Append(sTableId).Append(" T1.TANA_DAN").Append(",");
			sRepSql.Append(sTableId).Append(" T1.KAI_SU").Append(",");
			sRepSql.Append(sTableId).Append(" T1.TANAOROSI_YMD").Append(",");

            // 店舗参照時は"送信回数"、業者参照時は"処理日付"
            if (ConditionTenpo_gyosya_kbn.VALUE_TENPO.Equals(tenpoGyosyaKb))
            {
				sRepSql.Append(sTableId).Append(" T1.SOSINKAI_SU");
            }
            else
            {
				sRepSql.Append(sTableId).Append(" T1.SYORI_YMD");
            }
            sRepSql.Append(" ) IN ( ");

            Boolean bConmaF = false;

            for (int i = 0; i < m1formVOList.Count; i++)
            {
                Tj040f01M1Form m1formVO = (Tj040f01M1Form)m1formVOList[i];

                if (bConmaF)
                {
                    sRepSql.Append(" , ");
                }

                // 条件設定
                sRepSql.Append(" ( ");

                // 店舗コード
                sbindId = new StringBuilder();
                sbindId.Append("BIND_TENPO_CD").Append(i.ToString("0000")).Append(tenpoGyosyaKb.ToString()); ;
                sRepSql.Append(" :").Append(sbindId.ToString());

                bindVO = new BindInfoVO();
                bindVO.BindId = sbindId.ToString();
                bindVO.Value  = BoSystemFormat.formatTenpoCd(tenpocd);
                bindVO.Type   = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
                bindList.Add(bindVO);

                // フェイス№
                sbindId = new StringBuilder();
                sbindId.Append("BIND_FACE_NO").Append(i.ToString("0000")).Append(tenpoGyosyaKb.ToString()); ;
                sRepSql.Append(" ,:").Append(sbindId.ToString());

                bindVO = new BindInfoVO();
                bindVO.BindId = sbindId.ToString();
                bindVO.Value  = (string)m1formVO.Dictionary[Tj040p01Constant.DIC_M1FACE_NO];
                bindVO.Type   = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
                bindList.Add(bindVO);

                // 棚段
                sbindId = new StringBuilder();
                sbindId.Append("BIND_TANA_DAN").Append(i.ToString("0000")).Append(tenpoGyosyaKb.ToString()); ;
                sRepSql.Append(" ,:").Append(sbindId.ToString());

                bindVO = new BindInfoVO();
                bindVO.BindId = sbindId.ToString();
                bindVO.Value  = (string)m1formVO.M1tana_dan;
                bindVO.Type   = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
                bindList.Add(bindVO);

                // 回数
                sbindId = new StringBuilder();
                sbindId.Append("BIND_KAI_SU").Append(i.ToString("0000")).Append(tenpoGyosyaKb.ToString()); ;
                sRepSql.Append(" ,:").Append(sbindId.ToString());

                bindVO = new BindInfoVO();
                bindVO.BindId = sbindId.ToString();
                bindVO.Value  = (string)m1formVO.M1kai_su;
                bindVO.Type   = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
                bindList.Add(bindVO);

                // 棚卸日
                sbindId = new StringBuilder();
                sbindId.Append("BIND_TANAOROSI_YMD").Append(i.ToString("0000")).Append(tenpoGyosyaKb.ToString()); ;
                sRepSql.Append(" ,:").Append(sbindId.ToString());

                bindVO = new BindInfoVO();
                bindVO.BindId = sbindId.ToString();
                bindVO.Value  = BoSystemFormat.formatDate((string)m1formVO.Dictionary[Tj040p01Constant.DIC_M1TANAOROSI_YMD]);
                bindVO.Type   = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
                bindList.Add(bindVO);

                // 送信回数/処理日付
                sbindId = new StringBuilder();
                sbindId.Append("BIND_SOSINKAI_SU").Append(i.ToString("0000")).Append(tenpoGyosyaKb.ToString()); ;
                sRepSql.Append(" ,:").Append(sbindId.ToString());

                bindVO = new BindInfoVO();
                bindVO.BindId = sbindId.ToString();
                bindVO.Value = (string)m1formVO.Dictionary[Tj040p01Constant.DIC_M1SOSINKAI_SU];
                bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
                bindList.Add(bindVO);
                sRepSql.Append(" ) ");

                // フラグ更新
                bConmaF = true;
            }

            sRepSql.Append(" )");

            #endregion

            BoSystemSql.AddSql(reader, sREP_ID, sRepSql.ToString(), bindList);

        }
        #endregion
	}
}
