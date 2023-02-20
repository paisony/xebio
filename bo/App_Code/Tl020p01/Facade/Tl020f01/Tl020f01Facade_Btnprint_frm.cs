using com.xebio.bo.Tl020p01.Constant;
using com.xebio.bo.Tl020p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C01000.C01028;
using Common.Business.C99999.Constant;
using Common.Business.C99999.CsvUtil;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.ReportUtil;
using Common.Business.C99999.SqlUtil;
using Common.Conditions;
using Common.IntegrationMD.Report;
using Common.ListFactory.Model;
using Common.Standard.Base;
using Common.Standard.Csv;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace com.xebio.bo.Tl020p01.Facade
{
    /// <summary>
    /// Tl020f01のFacadeクラスです
    /// 各アクションの業務ロジックを実装します。
    /// </summary>
    public partial class Tl020f01Facade : StandardBaseFacade
    {

        #region フォームを呼び出します。(ボタンID : Btnprint)
        /// <summary>
        /// フォームを呼び出します。
        /// ボタンID(Btnprint)
        /// アクションID(FRM)
        /// の処理メソッド。
        /// </summary>
        /// <param name="facadeContext">ファサードコンテキスト</param>
        public void DoBTNPRINT_FRM(IFacadeContext facadeContext)
        {

            //使用時にコメントアウトをはずす。
            //モックアップテンプレートと共有している処理をコメントアウト。
            //必要に応じて処理を有効にしてください。

            //メソッドの開始処理を実行する。
            StartMethod(facadeContext, this.GetType().Name + ".DoBTNPRINT_FRM");

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
                Tl020f01Form formVO = (Tl020f01Form)facadeContext.FormVO;
                IDataList m1List = formVO.GetList("M1");

                #region 業務チェック

                // 1-1 選択行
                //       1件も選択されていない場合、エラー 
                if (m1List == null || m1List.Count <= 0)
                {
                    // 印刷する行を選択して下さい。
                    ErrMsgCls.AddErrMsg("E119", "印刷する行", facadeContext);
                }
                else
                {
                    int inputflg = 0;
                    for (int i = 0; i < m1List.Count; i++)
                    {
                        Tl020f01M1Form m1formVO = (Tl020f01M1Form)m1List[i];
                        if (m1formVO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
                        {
                            inputflg = 1;
                            break;
                        }
                    }
                    if (inputflg == 0)
                    {
                        // 印刷する行を選択して下さい。
                        ErrMsgCls.AddErrMsg("E119", "印刷する行", facadeContext);
                    }
                }

                //エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
                if (MessageDisplayUtil.HasError(facadeContext))
                {
                    return;
                }

                #endregion

                #region 印刷処理

                string pdfFileNm = string.Empty;

                // 退避検索条件を取得
                string tenpocd = BoSystemFormat.formatTenpoCd((string)formVO.Dictionary[SearchConditionSaveCls.PREFIX + "Head_tenpo_cd".ToUpper()]);

                // 帳票ツールに渡すパラメータを格納
                InputData inputData = new InputData();
                OutputInfo output = new OutputInfo();

                // PDFファイル名
                pdfFileNm = string.Format("{0}.{1}",
                                            BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_BAIHENSAGYOSIJILIST_X),
                                            BoSystemConstant.RPT_PDF_EXTENSION
                                            );

                // 印刷用CSV出力用データ取得
                FindSqlResultTable rtCsvSeach = FindSqlUtil.CreateFindSqlResultTable(Tl020p01Constant.SQL_ID_07, facadeContext.DBContext);
                ReplaceWherePrint(formVO, rtCsvSeach);

                //検索結果を取得します
                rtCsvSeach.CreateDbCommand();  // TODO yusy いらない？

                IList<Hashtable> tableList = rtCsvSeach.Execute();

                if (tableList == null || tableList.Count <= 0)
                {
                    // 抽出件数は0件です。
                    ErrMsgCls.AddErrMsg("E174", string.Empty, facadeContext);

                    //エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
                    if (MessageDisplayUtil.HasError(facadeContext))
                    {
                        return;
                    }
                }

                // 帳票用CSV作成
                // 印刷用CSV出力用リスト
                IList<IList<string>> csvList = BaihenSijiListcls.outBaihenSijiCsvList(tableList, facadeContext);

                // 帳票印刷用CSV作成
                string csvnm = BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_BAIHENSAGYOSIJILIST_X);
                // CSV出力
                string csvFilePath = BoSystemCsvUtil.PrinterCsvOut(csvList, PGID, csvnm, CsvUtil.DELIMITER.COMMA);
                // 帳票を出力
                BoSystemReport reportCls = new BoSystemReport();
                output = reportCls.MdGenerateCsvToPDF(inputData,
                                                        BoSystemConstant.REPORTID_BAIHENSAGYOSIJILIST_X,
                                                        Tl020p01Constant.FORMID_01,
                                                        Tl020p01Constant.PGID,
                                                        pdfFileNm,
                                                        csvFilePath
                                                        );

                #region 件数チェック
                if (output.ReportState == ReportState.DataNotFound)
                {
                    // 抽出件数は0件です。
                    ErrMsgCls.AddErrMsg("E174", string.Empty, facadeContext);
                }

                //エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
                if (MessageDisplayUtil.HasError(facadeContext))
                {
                    return;
                }
                #endregion

                #endregion

                // PDFをファイルをユーザマップに設定
                facadeContext.UserMap.Add(Tl020p01Constant.FCDUO_RRT_FLNM, pdfFileNm);

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
            EndMethod(facadeContext, this.GetType().Name + ".DoBTNPRINT_FRM");

        }
        #endregion

        #region 検索条件設定
        /// <summary>
        /// ReplaceWherePrint 検索条件設定
        /// </summary>
        /// <param name="formVO">Tl020f01Form</param>
        /// <param name="FindSqlResultTable">reader</param>
        /// <returns></returns>
        private void ReplaceWherePrint(Tl020f01Form formVO, FindSqlResultTable reader)
        {

            // 退避検索条件を取得
            string tenpocd = BoSystemFormat.formatTenpoCd((string)formVO.Dictionary[SearchConditionSaveCls.PREFIX + "Head_tenpo_cd".ToUpper()]);

            // 店舗コード
            reader.BindValue("BIND_TENPO_CD_01", tenpocd);
            reader.BindValue("BIND_TENPO_CD_02", tenpocd);
            reader.BindValue("BIND_TENPO_CD_03", tenpocd);
            reader.BindValue("BIND_TENPO_CD_04", tenpocd);
            reader.BindValue("BIND_TENPO_CD_05", tenpocd);
            reader.BindValue("BIND_TENPO_CD_06", tenpocd);

            // 確定用検索条件
            StringBuilder sRepSqlKakutei = new StringBuilder();
            StringBuilder sRepSqlKakuteiMax = new StringBuilder();
            ArrayList bindListKakutei = new ArrayList();
            ArrayList bindListKakuteiMax = new ArrayList();
            int iCnt = 1;
            sRepSqlKakutei.Append(" AND (MDCT0030.BAIHENKAISI_YMD, MDCT0030.BAIHEN_NO, MDCT0030.BUMON_CD) IN (");
            sRepSqlKakuteiMax.Append(" AND (MDCT0030_MAX.BAIHENKAISI_YMD, MDCT0030_MAX.BAIHEN_NO, MDCT0030_MAX.BUMON_CD) IN (");

            // 指示用検索条件
            StringBuilder sRepSqlSiji = new StringBuilder();
            StringBuilder sRepSqlSijiMax = new StringBuilder();
            ArrayList bindListSiji = new ArrayList();
            ArrayList bindListSijiMax = new ArrayList();

            int iCnt2 = 1;
            sRepSqlSiji.Append(" AND (MDCT0010.BAIHENKAISI_YMD, MDCT0010.BAIHEN_NO, MDCT0010.BUMON_CD, MDCT0010.BAIHENSAGYOKAISI_YMD, MDCT0010.BAIHEN_RIYTU) IN (");
            sRepSqlSijiMax.Append(" AND (MDCT0010_MAX.BAIHENKAISI_YMD, MDCT0010_MAX.BAIHEN_NO, MDCT0010_MAX.BUMON_CD, MDCT0010_MAX.BAIHENSAGYOKAISI_YMD, MDCT0010_MAX.BAIHEN_RIYTU) IN (");

            IDataList m1List = formVO.GetList("M1");

            for (int i = 0; i < m1List.Count; i++)
            {
                Tl020f01M1Form m1formVO = (Tl020f01M1Form)m1List[i];

                // 選択明細のみ対象
                if (BoSystemConstant.CHECKBOX_ON.Equals(m1formVO.M1selectorcheckbox))
                {
                    // 申請元ごとに作成
                    switch (m1formVO.Dictionary[Tl020p01Constant.DIC_M1SINSEIMOTO_KBN].ToString())
                    {
                        case ConditionSinseimoto.VALUE_SINSEIMOTO2:     // 店舗

                            #region 確定データ条件

                            // 確定データ
                            if (iCnt != 1)
                            {
                                sRepSqlKakutei.Append(" , ");
                                sRepSqlKakuteiMax.Append(" , ");
                            }

                            // 検索条件1 確定
                            sRepSqlKakutei.Append(" ( ");
                            sRepSqlKakutei.Append(" :BIND1_BAIHENKAISI_YMD").Append(iCnt.ToString("000"));
                            sRepSqlKakutei.Append(" ,:BIND1_BAIHEN_NO").Append(iCnt.ToString("000"));
                            sRepSqlKakutei.Append(" ,:BIND1_BUMON_CD").Append(iCnt.ToString("000"));
                            sRepSqlKakutei.Append(" ) ");

                            // 売変開始日
                            bindListKakutei.Add(new BindInfoVO("BIND1_BAIHENKAISI_YMD" + iCnt.ToString("000")
                                                        , BoSystemFormat.formatDate(m1formVO.M1baihenkaisi_ymd)
                                                        , BoSystemSql.BINDTYPE_NUMBER)
                                                        );
                            // 売変No
                            bindListKakutei.Add(new BindInfoVO("BIND1_BAIHEN_NO" + iCnt.ToString("000")
                                                        , BoSystemFormat.formatBaihen_shiji_no(m1formVO.Dictionary[Tl020p01Constant.DIC_M1BAIHEN_NO].ToString())
                                                        , BoSystemSql.BINDTYPE_STRING));

                            // 部門コード
                            bindListKakutei.Add(new BindInfoVO("BIND1_BUMON_CD" + iCnt.ToString("000")
                                                        , BoSystemFormat.formatBumonCd(m1formVO.Dictionary[Tl020p01Constant.DIC_M1BUMON_CD].ToString())
                                                        , BoSystemSql.BINDTYPE_STRING));

                            // 検索条件2 確定 最大売変No
                            sRepSqlKakuteiMax.Append(" ( ");
                            sRepSqlKakuteiMax.Append(" :BIND2_BAIHENKAISI_YMD").Append(iCnt.ToString("000"));
                            sRepSqlKakuteiMax.Append(" ,:BIND2_BAIHEN_NO").Append(iCnt.ToString("000"));
                            sRepSqlKakuteiMax.Append(" ,:BIND2_BUMON_CD").Append(iCnt.ToString("000"));
                            sRepSqlKakuteiMax.Append(" ) ");

                            // 売変開始日
                            bindListKakuteiMax.Add(new BindInfoVO("BIND2_BAIHENKAISI_YMD" + iCnt.ToString("000")
                                                        , BoSystemFormat.formatDate(m1formVO.M1baihenkaisi_ymd)
                                                        , BoSystemSql.BINDTYPE_NUMBER)
                                                        );
                            // 売変No
                            bindListKakuteiMax.Add(new BindInfoVO("BIND2_BAIHEN_NO" + iCnt.ToString("000")
                                                        , BoSystemFormat.formatBaihen_shiji_no(m1formVO.Dictionary[Tl020p01Constant.DIC_M1BAIHEN_NO].ToString())
                                                        , BoSystemSql.BINDTYPE_STRING));

                            // 部門コード
                            bindListKakuteiMax.Add(new BindInfoVO("BIND2_BUMON_CD" + iCnt.ToString("000")
                                                        , BoSystemFormat.formatBumonCd(m1formVO.Dictionary[Tl020p01Constant.DIC_M1BUMON_CD].ToString())
                                                        , BoSystemSql.BINDTYPE_STRING));

                            iCnt++;
                            #endregion

                            break;

                        case ConditionSinseimoto.VALUE_SINSEIMOTO1:     // 本部

                            #region 指示データ条件

                            // 指示データ
                            if (iCnt2 != 1)
                            {
                                sRepSqlSiji.Append(" , ");
                                sRepSqlSijiMax.Append(" , ");
                            }

                            // 検索条件3 指示
                            sRepSqlSiji.Append(" ( ");
                            sRepSqlSiji.Append(" :BIND3_BAIHENKAISI_YMD").Append(iCnt2.ToString("000"));
                            sRepSqlSiji.Append(" ,:BIND3_BAIHEN_NO").Append(iCnt2.ToString("000"));
                            sRepSqlSiji.Append(" ,:BIND3_BUMON_CD").Append(iCnt2.ToString("000"));
                            sRepSqlSiji.Append(" ,:BIND3_SAGYOKAISI").Append(iCnt2.ToString("000"));
                            sRepSqlSiji.Append(" ,:BIND3_BAIHEN_RIYTU").Append(iCnt2.ToString("000"));
                            sRepSqlSiji.Append(" ) ");

                            // 売変開始日
                            bindListSiji.Add(new BindInfoVO("BIND3_BAIHENKAISI_YMD" + iCnt2.ToString("000")
                                                        , BoSystemFormat.formatDate(m1formVO.M1baihenkaisi_ymd)
                                                        , BoSystemSql.BINDTYPE_NUMBER)
                                                        );
                            // 売変No
                            bindListSiji.Add(new BindInfoVO("BIND3_BAIHEN_NO" + iCnt2.ToString("000")
                                                        , BoSystemFormat.formatBaihen_shiji_no(m1formVO.Dictionary[Tl020p01Constant.DIC_M1BAIHEN_NO].ToString())
                                                        , BoSystemSql.BINDTYPE_STRING));

                            // 部門コード
                            bindListSiji.Add(new BindInfoVO("BIND3_BUMON_CD" + iCnt2.ToString("000")
                                                        , BoSystemFormat.formatBumonCd(m1formVO.Dictionary[Tl020p01Constant.DIC_M1BUMON_CD].ToString())
                                                        , BoSystemSql.BINDTYPE_STRING));

                            // 作業開始日
                            bindListSiji.Add(new BindInfoVO("BIND3_SAGYOKAISI" + iCnt2.ToString("000")
                                                        , BoSystemFormat.formatDate(m1formVO.Dictionary[Tl020p01Constant.DIC_M1BAIHENSAGYOKAISI_YMD].ToString())
                                                        , BoSystemSql.BINDTYPE_NUMBER));

                            // 売変理由
                            bindListSiji.Add(new BindInfoVO("BIND3_BAIHEN_RIYTU" + iCnt2.ToString("000")
                                                        , m1formVO.Dictionary[Tl020p01Constant.DIC_M1BAIHEN_RIYTU].ToString()
                                                        , BoSystemSql.BINDTYPE_NUMBER));

                            // 検索条件4 指示 最大売変No
                            sRepSqlSijiMax.Append(" ( ");
                            sRepSqlSijiMax.Append(" :BIND4_BAIHENKAISI_YMD").Append(iCnt2.ToString("000"));
                            sRepSqlSijiMax.Append(" ,:BIND4_BAIHEN_NO").Append(iCnt2.ToString("000"));
                            sRepSqlSijiMax.Append(" ,:BIND4_BUMON_CD").Append(iCnt2.ToString("000"));
                            sRepSqlSijiMax.Append(" ,:BIND4_SAGYOKAISI").Append(iCnt2.ToString("000"));
                            sRepSqlSijiMax.Append(" ,:BIND4_BAIHEN_RIYTU").Append(iCnt2.ToString("000"));
                            sRepSqlSijiMax.Append(" ) ");

                            // 売変開始日
                            bindListSijiMax.Add(new BindInfoVO("BIND4_BAIHENKAISI_YMD" + iCnt2.ToString("000")
                                                        , BoSystemFormat.formatDate(m1formVO.M1baihenkaisi_ymd)
                                                        , BoSystemSql.BINDTYPE_NUMBER)
                                                        );
                            // 売変No
                            bindListSijiMax.Add(new BindInfoVO("BIND4_BAIHEN_NO" + iCnt2.ToString("000")
                            , BoSystemFormat.formatBaihen_shiji_no(m1formVO.Dictionary[Tl020p01Constant.DIC_M1BAIHEN_NO].ToString())
                            , BoSystemSql.BINDTYPE_STRING));

                            // 部門コード
                            bindListSijiMax.Add(new BindInfoVO("BIND4_BUMON_CD" + iCnt2.ToString("000")
                                                        , BoSystemFormat.formatBumonCd(m1formVO.Dictionary[Tl020p01Constant.DIC_M1BUMON_CD].ToString())
                                                        , BoSystemSql.BINDTYPE_STRING));

                            // 作業開始日
                            bindListSijiMax.Add(new BindInfoVO("BIND4_SAGYOKAISI" + iCnt2.ToString("000")
                                                        , BoSystemFormat.formatDate(m1formVO.Dictionary[Tl020p01Constant.DIC_M1BAIHENSAGYOKAISI_YMD].ToString())
                                                        , BoSystemSql.BINDTYPE_NUMBER));

                            // 売変理由
                            bindListSijiMax.Add(new BindInfoVO("BIND4_BAIHEN_RIYTU" + iCnt2.ToString("000")
                                                        , m1formVO.Dictionary[Tl020p01Constant.DIC_M1BAIHEN_RIYTU].ToString()
                                                        , BoSystemSql.BINDTYPE_NUMBER));

                            iCnt2++;
                            #endregion

                            break;
                        default:
                            break;
                    }
                }
            } // for

            sRepSqlKakutei.Append(" ) ");
            sRepSqlKakuteiMax.Append(" ) ");
            sRepSqlSiji.Append(" ) ");
            sRepSqlSijiMax.Append(" ) ");

            //売変確定データが選ばれていなかった場合、条件文を初期化する。
            if (iCnt == 1)
            {
                sRepSqlKakutei.Length = 0;
                sRepSqlKakuteiMax.Length = 0;
                bindListKakutei.Clear();
                bindListKakuteiMax.Clear();
                sRepSqlKakutei.Append(" AND 1 = 0");
                sRepSqlKakuteiMax.Append(" AND 1 = 0");
            }

            // 売変指示データが選ばれていなかった場合、条件文を初期化する。
            if (iCnt2 == 1)
            {
                sRepSqlSiji.Length = 0;
                sRepSqlSijiMax.Length = 0;
                bindListSiji.Clear();
                bindListSijiMax.Clear();
                sRepSqlSiji.Append(" AND 1 = 0");
                sRepSqlSijiMax.Append(" AND 1 = 0");
            }

            // 検索条件1 確定
            BoSystemSql.AddSql(reader, "REPLACE_WHERE_1", sRepSqlKakutei.ToString(), bindListKakutei);
            // 検索条件2 確定 最大売変No
            BoSystemSql.AddSql(reader, "REPLACE_WHERE_2", sRepSqlKakuteiMax.ToString(), bindListKakuteiMax);
            // 検索条件3 指示
            BoSystemSql.AddSql(reader, "REPLACE_WHERE_3", sRepSqlSiji.ToString(), bindListSiji);
            // 検索条件4 指示 最大売変No
            BoSystemSql.AddSql(reader, "REPLACE_WHERE_4", sRepSqlSijiMax.ToString(), bindListSijiMax);

        }
        #endregion

    }
}
