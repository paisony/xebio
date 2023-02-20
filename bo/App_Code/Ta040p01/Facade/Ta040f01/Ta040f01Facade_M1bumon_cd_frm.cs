using com.xebio.bo.Ta040p01.Constant;
using com.xebio.bo.Ta040p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.StringUtil;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;

namespace com.xebio.bo.Ta040p01.Facade
{
  /// <summary>
  /// Ta040f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Ta040f01Facade : StandardBaseFacade
    {

        #region フォームを呼び出します。(ボタンID : M1bumon_cd)
        /// <summary>
        /// フォームを呼び出します。
        /// ボタンID(M1bumon_cd)
        /// アクションID(FRM)
        /// の処理メソッド。
        /// </summary>
        /// <param name="facadeContext">ファサードコンテキスト</param>
        public void DoM1BUMON_CD_FRM(IFacadeContext facadeContext)
        {

            //使用時にコメントアウトをはずす。
            //モックアップテンプレートと共有している処理をコメントアウト。
            //必要に応じて処理を有効にしてください。

            //メソッドの開始処理を実行する。
            StartMethod(facadeContext, this.GetType().Name + ".DoM1BUMON_CD_FRM");

            try
            {
                //DBコンテキストを設定する。
                SetDBContext(facadeContext);
                //コネクションを取得して、トランザクションを開始する。
                //BeginTransactionWithConnect(facadeContext);
                //コネクションを取得する。
                OpenConnection(facadeContext);

                //以下に業務ロジックを記述する。

                #region 初期化

                // ログイン情報取得
                LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

                // FormVO取得
                // 画面より情報を取得する。
                Ta040f01Form prevVo = (Ta040f01Form)facadeContext.FormVO;
                Ta040f02Form nextVo = (Ta040f02Form)facadeContext.GetUserObject(Ta040p01Constant.FCDUO_NEXTVO);

                IDataList prevM1List = prevVo.GetList("M1");
                IDataList nextM1List = nextVo.GetList("M1");

                // 選択行の情報を取得する。
                Ta040f01M1Form prevM1Vo = (Ta040f01M1Form)prevM1List.GetPageViewList()[facadeContext.CommandInfo.ListIndex];

                // Dictionaryから検索条件を取得
                String tenpoCd = BoSystemFormat.formatTenpoCd((string)prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Head_tenpo_cd)]);
                String tenpoNm = (string)prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Head_tenpo_nm)];

                //一覧の初期化
                nextM1List.ClearCacheData();
                nextM1List.Clear();

                #endregion

                #region 検索処理
                FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(Ta040p01Constant.SQL_ID_03, facadeContext.DBContext);

                rtSeach.BindValue(Ta040p01Constant.SQL_ID_02_REP_TENPO_CD, tenpoCd);
                //決裁日
                rtSeach.BindValue(Ta040p01Constant.SQL_ID_03_REP_KESSAI_YMD, Convert.ToDecimal(BoSystemFormat.formatDate(prevM1Vo.M1kessai_ymd, 0)));
                //変更区分
                rtSeach.BindValue(Ta040p01Constant.SQL_ID_04_REP_HENKO_KBN, Convert.ToDecimal((string)prevM1Vo.Dictionary[Ta040p01Constant.DIC_M1HENKO_KBN]));
                //部門コード
                rtSeach.BindValue(Ta040p01Constant.SQL_ID_05_REP_BUMON_CD, BoSystemFormat.formatBumonCd((string)prevM1Vo.Dictionary[Ta040p01Constant.DIC_M1BUMON_CD]));

                //検索結果を取得します
                rtSeach.CreateDbCommand();
                IList<Hashtable> tableList = rtSeach.Execute();

                decimal dHaisouSum = 0; //配送数合計
                decimal dKinSum = 0;	// 原価金額合計
                int iCnt = 0;
                foreach (Hashtable rec in tableList)
                {
                    iCnt++;
                    Ta040f02M1Form f02m1VO = new Ta040f02M1Form();

                    //原価金額計算

                    f02m1VO.M1rowno = iCnt.ToString(); 			                    // Ｍ１行NO
                    f02m1VO.M1hinsyu_ryaku_nm = rec["HINSYU_RYAKU_NM"].ToString();	// Ｍ１品種略名称
                    f02m1VO.M1burando_nm = rec["BURANDO_NMK"].ToString();           // Ｍ１ブランド名称
                    f02m1VO.M1jisya_hbn = rec["JISYA_HBN"].ToString();				// Ｍ１自社品番
                    f02m1VO.M1syohin_zokusei = rec["SYOHIN_ZOKUSEI"].ToString();    // Ｍ１コア(商品属性)
                    f02m1VO.M1scan_cd = rec["JAN_CD"].ToString();					// Ｍ１スキャンコード
                    f02m1VO.M1maker_hbn = rec["HIN_NBR"].ToString();				// Ｍ１メーカー品番
                    f02m1VO.M1syonmk = rec["SYONMK"].ToString();					// Ｍ１商品名(カナ)
                    f02m1VO.M1iro_nm = rec["IRO_NM"].ToString();					// Ｍ１色
                    f02m1VO.M1size_nm = rec["SIZE_NM"].ToString();					// Ｍ１サイズ
                    f02m1VO.M1season_nm = rec["MEISYO_NM"].ToString();				// Ｍ１シーズン
                    f02m1VO.M1hanbaikanryo_ymd = rec["HANBAIKANRYO_YMD"].ToString();// Ｍ１販売日
                    f02m1VO.M1hattyu_su = rec["IRAI_SU"].ToString();             	// Ｍ１発注数量
                    f02m1VO.M1haibun_su = rec["HAIBUN_SU"].ToString();              // Ｍ１配分数量
                    f02m1VO.M1genkakin = rec["GEN_TNK"].ToString();              	// Ｍ１原価金額
                    f02m1VO.M1comment_nm = rec["COMMENT_NM"].ToString();            // Ｍ１コメント

                    f02m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;
                                                                                    // Ｍ１選択フラグ(隠し)
                    f02m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;   
                                                                                    // Ｍ１確定処理フラグ(隠し)
                    f02m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;
                                                                                    // Ｍ１明細色区分(隠し)

                    f02m1VO.M1genkakin = (Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1genkakin, "0")) 
											* Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1haibun_su, "0"))).ToString();
                    // Ｍ１原価金額

                    // 合計値加算
                    dHaisouSum += Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1haibun_su, "0"));
                    dKinSum += Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1genkakin, "0"));

                    //リストオブジェクトにM1Formを追加します。
                    nextM1List.Add(f02m1VO, true);

                }

                // 合計欄の設定
                nextVo.Gokei_haibun_su = dHaisouSum.ToString();
                nextVo.Gokei_genkakin = dKinSum.ToString();

                // 0件チェック
                if (nextM1List.Count == 0)
                {
                    ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
                    return;
                }

                #endregion

                #region カード部設定
                // ヘッダ店舗コード
                nextVo.Head_tenpo_cd = tenpoCd;
                // ヘッダ店舗名
                nextVo.Head_tenpo_nm = tenpoNm;
                //変更区分
                nextVo.Henko_kbn_nm = prevM1Vo.M1henko_kbn_nm;
                //決済日
                nextVo.Kessai_ymd = prevM1Vo.M1kessai_ymd;
                //部門コード
                nextVo.Bumon_cd = BoSystemFormat.formatBumonCd((string)prevM1Vo.Dictionary[Ta040p01Constant.DIC_M1BUMON_CD]);
                //部門名
                nextVo.Bumon_nm = (string)prevM1Vo.Dictionary[Ta040p01Constant.DIC_M1BUMON_NM];

                //選択明細のVO
                nextVo.Dictionary[Ta040p01Constant.DIC_M1SELCETVO] = prevM1Vo;
                // 選択行のインデックスを設定
                nextVo.Dictionary[Ta040p01Constant.DIC_M1SELCETROWIDX] = facadeContext.CommandInfo.ListIndex.ToString();

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
            EndMethod(facadeContext, this.GetType().Name + ".DoM1BUMON_CD_FRM");
        }
        #endregion
    }
}