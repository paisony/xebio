using com.xebio.bo.Tj040p01.Constant;
using com.xebio.bo.Tj040p01.Formvo;
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
using Common.Standard.Message;
using Common.Standard.Model.Data;
using Common.Standard.Util;
using System;
using System.Collections;
using System.Collections.Generic;

namespace com.xebio.bo.Tj040p01.Facade
{
  /// <summary>
  /// Tj040f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tj040f01Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : M1face_no)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(M1face_no)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoM1FACE_NO_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

            //メソッドの開始処理を実行する。
            StartMethod(facadeContext, this.GetType().Name + ".DoM1FACE_NO_FRM");

            try
            {
                //DBコンテキストを設定する。
                SetDBContext(facadeContext);
                //コネクションを取得して、トランザクションを開始する。
                //BeginTransactionWithConnect(facadeContext);
                OpenConnection(facadeContext);

                //以下に業務ロジックを記述する。

                // ログイン情報取得
                LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

                // FormVO取得
                // 画面より情報を取得する。
                Tj040f01Form prevVo = (Tj040f01Form)facadeContext.FormVO;
                Tj040f02Form nextVo = (Tj040f02Form)facadeContext.GetUserObject(Tj040p01Constant.FCDUO_NEXTVO);

                IDataList prevM1List = prevVo.GetList("M1");
                IDataList nextM1List = nextVo.GetList("M1");

                // 選択行の情報を取得する。
                Tj040f01M1Form prevM1Vo = (Tj040f01M1Form)prevM1List.GetPageViewList()[facadeContext.CommandInfo.ListIndex];

                // 一覧の初期化
                nextM1List.ClearCacheData();
                nextM1List.Clear();

                #region 業務チェック
                #endregion

                #region 検索処理

                // Dictionary.「Ｍ１店舗／業者区分」が"1"の場合、[棚卸確定TBL(H)]から検索する
                // Dictionary.「Ｍ１店舗／業者区分」が"2"の場合、[業者棚卸TBL(H)]から検索する
                string sSqlId = "";
                if (ConditionTenpo_gyosya_kbn.VALUE_TENPO.Equals((String)prevM1Vo.Dictionary[Tj040p01Constant.DIC_M1TENPO_GYOSYA_KB]))
                {
                    sSqlId = Tj040p01Constant.SQL_ID_04;
                }
                else
                {
                    sSqlId = Tj040p01Constant.SQL_ID_05;
                }

                FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(sSqlId, facadeContext.DBContext);

                // バインド値の置き換え
                // 店舗コード
                rtSeach.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((String)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "Head_tenpo_cd".ToUpper()]));
                // フェイス№
                rtSeach.BindValue("BIND_FACE_NO", Convert.ToDecimal(BoSystemString.Nvl(prevM1Vo.Dictionary[Tj040p01Constant.DIC_M1FACE_NO].ToString(), "0")));
                // 棚段
                rtSeach.BindValue("BIND_TANA_DAN", Convert.ToDecimal(BoSystemString.Nvl(prevM1Vo.M1tana_dan, "0")));
                // 回数
                rtSeach.BindValue("BIND_KAI_SU", Convert.ToDecimal(BoSystemString.Nvl(prevM1Vo.M1kai_su, "0")));
                // 棚卸日
                rtSeach.BindValue("BIND_TANAOROSI_YMD", Convert.ToDecimal(BoSystemString.Nvl(prevM1Vo.Dictionary[Tj040p01Constant.DIC_M1TANAOROSI_YMD].ToString(), "0")));
                // 送信回数
				rtSeach.BindValue("BIND_SOSINKAI_SU", Convert.ToDecimal(BoSystemString.Nvl(prevM1Vo.Dictionary[Tj040p01Constant.DIC_M1SOSINKAI_SU].ToString(), "0")));

                // 検索結果の取得
                rtSeach.CreateDbCommand();
                IList<Hashtable> tableList = rtSeach.Execute();

                #region 件数チェック

                if (0 == tableList.Count)
                {
                    ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
                }

                //エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
                if (MessageDisplayUtil.HasError(facadeContext))
                {
                    return;
                }

                #endregion

                decimal dScanSuSum   = 0;	// スキャン数合計
                decimal dTeiseiSuSum = 0;	// 訂正数合計
                decimal dGokeiSuSum  = 0;	// 合計数合計

				// 検索時の自社品番、スキャンコードを取得
				string xebiocd1 = (string)prevVo.Dictionary[Tj040p01Constant.DIC_SEARCH_XEBIOCD1];
				string xebiocd2 = (string)prevVo.Dictionary[Tj040p01Constant.DIC_SEARCH_XEBIOCD2];
				string xebiocd3 = (string)prevVo.Dictionary[Tj040p01Constant.DIC_SEARCH_XEBIOCD3];
				string xebiocd4 = (string)prevVo.Dictionary[Tj040p01Constant.DIC_SEARCH_XEBIOCD4];
				string xebiocd5 = (string)prevVo.Dictionary[Tj040p01Constant.DIC_SEARCH_XEBIOCD5];
				string scanCd1 = (string)prevVo.Dictionary[Tj040p01Constant.DIC_SEARCH_JANCD1];
				string scanCd2 = (string)prevVo.Dictionary[Tj040p01Constant.DIC_SEARCH_JANCD2];
				string scanCd3 = (string)prevVo.Dictionary[Tj040p01Constant.DIC_SEARCH_JANCD3];
				string scanCd4 = (string)prevVo.Dictionary[Tj040p01Constant.DIC_SEARCH_JANCD4];
				string scanCd5 = (string)prevVo.Dictionary[Tj040p01Constant.DIC_SEARCH_JANCD5];

				foreach (Hashtable rec in tableList)
				{
                    Tj040f02M1Form m1formVO = new Tj040f02M1Form();

                    // Ｍ１行NO
                    m1formVO.M1rowno = rec["GYO_NBR"].ToString();
                    // Ｍ１部門コード
                    m1formVO.M1bumon_cd = rec["BUMON_CD"].ToString();
                    // Ｍ１部門カナ名
                    m1formVO.M1bumonkana_nm = rec["BUMON_NM"].ToString();
                    // Ｍ１品種略名称
                    m1formVO.M1hinsyu_ryaku_nm = rec["HINSYU_RYAKU_NM"].ToString();
                    // Ｍ１ブランド名
                    m1formVO.M1burando_nm = rec["BURANDO_NMK"].ToString();
                    // Ｍ１自社品番
                    m1formVO.M1jisya_hbn = rec["JISYA_HBN"].ToString();
                    // Ｍ１メーカー品番
                    m1formVO.M1maker_hbn = rec["MAKER_HBN"].ToString();
                    // Ｍ１商品名(カナ)
                    m1formVO.M1syonmk = rec["SYONMK"].ToString();
                    // Ｍ１色
                    m1formVO.M1iro_nm = rec["IRO_NM"].ToString();
                    // Ｍ１サイズ
                    m1formVO.M1size_nm = rec["SIZE_NM"].ToString();
                    // Ｍ１スキャンコード
                    m1formVO.M1scan_cd = rec["JAN_CD"].ToString();
                    // Ｍ１表示用商品コード
					m1formVO.M1hyoji_syohin_cd = BoSystemFormat.formatViewSyohinCd(rec["SYOHIN_CD"].ToString());

                    // ブランドコード
                    m1formVO.Dictionary[Tj040p01Constant.DIC_M1BURANDO_CD] = rec["BURANDO_CD"].ToString();
                    // 品種コード
                    m1formVO.Dictionary[Tj040p01Constant.DIC_M1HINSYU_CD] = ((decimal)rec["HINSYU_CD"]).ToString();
                    // 色コード
                    m1formVO.Dictionary[Tj040p01Constant.DIC_M1IRO_CD] = rec["IRO_CD"].ToString();
                    // サイズコード
                    m1formVO.Dictionary[Tj040p01Constant.DIC_M1SIZE_CD] = rec["SIZE_CD"].ToString();


                    // 店舗の場合
                    if (ConditionTenpo_gyosya_kbn.VALUE_TENPO.Equals((String)prevM1Vo.Dictionary[Tj040p01Constant.DIC_M1TENPO_GYOSYA_KB]))
                    {
                        // Ｍ１スキャン数量
                        m1formVO.M1scan_su = rec["TANAOROSISCAN_SU"].ToString();
                        // Ｍ１訂正数量
                        m1formVO.M1teisei_suryo = rec["TANAOROSITEISEI_SU"].ToString();
                        // Ｍ１訂正数量(隠し)
                        m1formVO.M1teisei_suryo_hdn = rec["TANAOROSITEISEI_SU"].ToString();
                    }
                    // 業者の場合
                    else
                    {
                        // Ｍ１スキャン数量
                        m1formVO.M1scan_su = rec["TANAOROSIGOKEI_SU"].ToString();
                        // Ｍ１訂正数量
                        m1formVO.M1teisei_suryo = string.Empty;
                        // Ｍ１訂正数量(隠し)
                        m1formVO.M1teisei_suryo_hdn = string.Empty;
                    }

                    // Ｍ１合計数量
                    m1formVO.M1gokei_suryo = rec["TANAOROSIGOKEI_SU"].ToString();

                    // Ｍ１選択フラグ(隠し)
                    m1formVO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;
                    // Ｍ１確定処理フラグ(隠し)
                    m1formVO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;
                    // Ｍ１明細色区分(隠し)
					if (m1formVO.M1jisya_hbn.Equals(xebiocd1)
						|| m1formVO.M1jisya_hbn.Equals(xebiocd2)
						|| m1formVO.M1jisya_hbn.Equals(xebiocd3)
						|| m1formVO.M1jisya_hbn.Equals(xebiocd4)
						|| m1formVO.M1jisya_hbn.Equals(xebiocd5)
						|| m1formVO.M1scan_cd.Equals(scanCd1)
						|| m1formVO.M1scan_cd.Equals(scanCd2)
						|| m1formVO.M1scan_cd.Equals(scanCd3)
						|| m1formVO.M1scan_cd.Equals(scanCd4)
						|| m1formVO.M1scan_cd.Equals(scanCd5))
					{
						// 一覧の検索条件で指定した自社品番、スキャンコードと一致する場合、背景色を変える
						m1formVO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_SHOHIN_SHITEI;
					}
					else
					{
						m1formVO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;
					}


                    // 合計値加算
                    dScanSuSum   += Convert.ToDecimal(BoSystemString.Nvl(m1formVO.M1scan_su, "0"));

                    if (!string.IsNullOrEmpty(m1formVO.M1teisei_suryo))
                    {
                        dTeiseiSuSum += Convert.ToDecimal(BoSystemString.Nvl(m1formVO.M1teisei_suryo, "0"));
                    }

                    dGokeiSuSum += Convert.ToDecimal(BoSystemString.Nvl(m1formVO.M1gokei_suryo, "0"));


                    //リストオブジェクトにM1Formを追加します。
                    nextM1List.Add(m1formVO, true);
                }


                #region 合計欄の設定

                nextVo.Gokeiscan_su      = dScanSuSum.ToString();
                nextVo.Gokeiteisei_suryo = dTeiseiSuSum.ToString();
                nextVo.All_gokei_suryo   = dGokeiSuSum.ToString();

                #endregion

                #region カード部設定

                // ヘッダ店舗コード
                nextVo.Head_tenpo_cd = BoSystemFormat.formatTenpoCd((String)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "Head_tenpo_cd".ToUpper()]);
                // ヘッダ店舗名
                nextVo.Head_tenpo_nm = (String)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "Head_tenpo_nm".ToUpper()];

                // モードNO
                nextVo.Modeno = prevVo.Stkmodeno;
                // 選択モードNO
                nextVo.Stkmodeno = prevVo.Stkmodeno;

                // フェイス№
                nextVo.Face_no = (String)prevM1Vo.Dictionary[Tj040p01Constant.DIC_M1FACE_NO];
                nextVo.Dictionary[Tj040p01Constant.DIC_FACE_NO] = (String)prevM1Vo.Dictionary[Tj040p01Constant.DIC_M1FACE_NO];
                // 棚段
                nextVo.Tana_dan = prevM1Vo.M1tana_dan;
                nextVo.Dictionary[Tj040p01Constant.DIC_TANA_DAN] = prevM1Vo.M1tana_dan;
                // 回数
                nextVo.Kai_su = prevM1Vo.M1kai_su;
                // 点数棚卸数量
                nextVo.Tensutanaorosi_su = prevM1Vo.M1tensutanaorosinyuryoku_su;
                // 訂正数量
                nextVo.Teisei_suryo = prevM1Vo.M1tensutanaorositeisei_su;
                // 訂正数量(隠し)
                nextVo.Teisei_suryo_hdn = prevM1Vo.M1tensutanaorositeisei_su;
                // 合計数量
                nextVo.Gokei_suryo = prevM1Vo.M1tensutanaorosigokei_su;
                // 店舗／業者区分
                nextVo.Tenpo_gyosya_kb = (String)prevM1Vo.Dictionary[Tj040p01Constant.DIC_M1TENPO_GYOSYA_KB];
                // 店舗／業者名
                nextVo.Tenpo_gyosya_nm = ConditionUtil.GetLabel("TENPO_GYOSYA_KBN", nextVo.Tenpo_gyosya_kb);
                // 入力担当者コード
                nextVo.Nyuryokutan_cd = (String)prevM1Vo.Dictionary[Tj040p01Constant.DIC_M1NYURYOKUTAN_CD];
                // 入力担当者名称
                nextVo.Nyuryokutan_nm = prevM1Vo.M1nyuryokutan_nm;

				// 訂正フラグ
				if (Tj040p01Constant.TEISEI_FLG_1.Equals(prevM1Vo.Dictionary[Tj040p01Constant.DIC_M1TEISEI_FLG].ToString()))
				{
					// 訂正担当者コード
					nextVo.Teiseitan_cd = (String)prevM1Vo.Dictionary[Tj040p01Constant.DIC_M1TEISEITAN_CD];
					// 訂正担当者名称
					nextVo.Teiseitan_nm = prevM1Vo.M1teiseitan_nm;
				}

                // 入力日
                nextVo.Nyuryoku_ymd = prevM1Vo.M1nyuryoku_ymd;
                // 送信日
                nextVo.Sosin_ymd = prevM1Vo.M1sosin_ymd;
                // 理由コード
                nextVo.Riyu_cd = (String)prevM1Vo.Dictionary[Tj040p01Constant.DIC_M1RIYUCOMMENT_CD];

                // 棚卸日
                nextVo.Dictionary[Tj040p01Constant.DIC_TANAOROSI_YMD] = (String)prevM1Vo.Dictionary[Tj040p01Constant.DIC_M1TANAOROSI_YMD];
                // 送信回数
                nextVo.Dictionary[Tj040p01Constant.DIC_SOSINKAI_SU] = (String)prevM1Vo.Dictionary[Tj040p01Constant.DIC_M1SOSINKAI_SU];
				// 更新日
				nextVo.Dictionary[Tj040p01Constant.DIC_M1UPD_YMD] = (String)prevM1Vo.Dictionary[Tj040p01Constant.DIC_M1UPD_YMD];
				// 更新時間
				nextVo.Dictionary[Tj040p01Constant.DIC_M1UPD_TM] = (String)prevM1Vo.Dictionary[Tj040p01Constant.DIC_M1UPD_TM];

				// 選択明細のVO
				nextVo.Dictionary[Tj040p01Constant.DIC_M1SELCETVO] = prevM1Vo;
				// 選択行のインデックスを設定
				nextVo.Dictionary[Tj040p01Constant.DIC_M1SELCETROWIDX] = facadeContext.CommandInfo.ListIndex.ToString();

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
            EndMethod(facadeContext, this.GetType().Name + ".DoM1FACE_NO_FRM");

		}
		#endregion
	}
}
