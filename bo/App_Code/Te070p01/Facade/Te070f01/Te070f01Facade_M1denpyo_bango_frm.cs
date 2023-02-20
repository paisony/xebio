using com.xebio.bo.Te070p01.Constant;
using com.xebio.bo.Te070p01.Formvo;
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

namespace com.xebio.bo.Te070p01.Facade
{
  /// <summary>
  /// Te070f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Te070f01Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : M1denpyo_bango)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(M1denpyo_bango)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoM1DENPYO_BANGO_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

            //メソッドの開始処理を実行する。
            StartMethod(facadeContext, this.GetType().Name + ".DoM1DENPYO_BANGO_FRM");

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
                Te070f01Form prevVo = (Te070f01Form)facadeContext.FormVO;
                Te070f02Form nextVo = (Te070f02Form)facadeContext.GetUserObject(Te070p01Constant.FCDUO_NEXTVO);

                IDataList prevM1List = prevVo.GetList("M1");
                IDataList nextM1List = nextVo.GetList("M1");

               // 選択行の情報を取得する。
               Te070f01M1Form prevM1Vo = (Te070f01M1Form)prevM1List.GetPageViewList()[facadeContext.CommandInfo.ListIndex];

               // Dictionaryから検索条件を取得
               String tenpoCd = BoSystemFormat.formatTenpoCd((string)prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Head_tenpo_cd)]);
               String tenpoNm = (string)prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Head_tenpo_nm)];
               String denpyoJotai = (string)prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Denpyo_jyotai)];
               String oldJishahinban = (string)prevVo.Dictionary[Te070p01Constant.DIC_SEARCH_XEBIOCD];
               String scanCd = (string)prevVo.Dictionary[Te070p01Constant.DIC_SEARCH_JANCD];

   
				// 一覧の初期化
				nextM1List.ClearCacheData();
				nextM1List.Clear();

				#endregion

                #region 検索処理

                // [伝票状態]が空白、かつDictionary.[Ｍ１確定フラグ]="0"の場合、
                // または、、[伝票状態]="未処理"の場合、移動入荷予定テーブルから検索する。
                string sSqlId = "";

                // 伝票状態によってSQL、テーブルを変更する
                switch (denpyoJotai)
                {
                    // 「未処理」」の場合
                    case ConditionIdonyuka_denpyo_jotai.VALUE_IDONYUKA_DENPYO_JOTAI2:
                        sSqlId = Te070p01Constant.SQL_ID_07;
                        break;

                    // 「確定」「差異あり」の場合
                    case ConditionIdonyuka_denpyo_jotai.VALUE_IDONYUKA_DENPYO_JOTAI1:
                    case ConditionIdonyuka_denpyo_jotai.VALUE_IDONYUKA_DENPYO_JOTAI3:
                        sSqlId = Te070p01Constant.SQL_ID_08;
                        break;

                    // 「登録履歴」「取消履歴」の場合
                    case ConditionIdonyuka_denpyo_jotai.VALUE_IDONYUKA_DENPYO_JOTAI4:
                    case ConditionIdonyuka_denpyo_jotai.VALUE_IDONYUKA_DENPYO_JOTAI5:
                        sSqlId = Te070p01Constant.SQL_ID_09;
                        break;

                    // 空白の場合
                    default:
                        //        Dictionary.[Ｍ１確定フラグ]="0"
                        if (prevM1Vo.Dictionary[Te070p01Constant.DIC_M1KAKUTEI_FLG].Equals(Te070p01Constant.DIC_M1KAKUTEIFLG0))
                        {
                            sSqlId = Te070p01Constant.SQL_ID_07;
                        }
                        //       Dictionary.[Ｍ１確定フラグ]="1"(確定)
                        else
                        {
                            sSqlId = Te070p01Constant.SQL_ID_08;
                        }
                        break;
                }

                FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(sSqlId, facadeContext.DBContext);

                // バインド値の置き換え
                // 店舗LC区分
                rtSeach.BindValue(Te070p01Constant.SQL_ID_07_REP_TENPOLC_KBN, Convert.ToDecimal(prevM1Vo.Dictionary[Te070p01Constant.DIC_M1TENPOLC_KBN]));
                // 出荷会社コード
                rtSeach.BindValue(Te070p01Constant.SQL_ID_07_REP_SYUKKAKAISYA_CD, Convert.ToDecimal(prevM1Vo.Dictionary[Te070p01Constant.DIC_M1SYUKKAKAISYA_CD]));
				// 出荷店コード
                rtSeach.BindValue(Te070p01Constant.SQL_ID_07_REP_SYUKKATEN_CD, BoSystemFormat.formatTenpoCd(prevM1Vo.M1syukkaten_cd));
                // 伝票番号
                rtSeach.BindValue(Te070p01Constant.SQL_ID_07_REP_DENPYO_BANGO, Convert.ToDecimal(prevM1Vo.Dictionary[Te070p01Constant.DIC_M1DENPYO_BANGO]));
                // 出荷日
                rtSeach.BindValue(Te070p01Constant.SQL_ID_07_REP_SYUKKA_YMD, Convert.ToDecimal(BoSystemFormat.formatDate(prevM1Vo.M1syukka_ymd, 0)));

                if (Te070p01Constant.SQL_ID_09.Equals(sSqlId))
                {
                    // 履歴No
                    rtSeach.BindValue(Te070p01Constant.SQL_ID_07_REP_RIREKI_NO, Convert.ToDecimal((string)prevM1Vo.Dictionary[Te070p01Constant.DIC_M1RIREKI_NO]));
                    // 赤黒区分
                    rtSeach.BindValue(Te070p01Constant.SQL_ID_07_REP_AKAKURO_KBN, Convert.ToDecimal((string)prevM1Vo.Dictionary[Te070p01Constant.DIC_M1AKAKURO_KBN]));
                }

                //検索結果を取得します
                rtSeach.CreateDbCommand();
                IList<Hashtable> tableList = rtSeach.Execute();

                decimal dyoteiSuSum = 0;	// 予定数量合計
                decimal dkakuteiSuSum = 0;	// 確定数量合計
                decimal dKinSum = 0;		// 原価金額合計

                foreach (Hashtable rec in tableList)
                {
                    Te070f02M1Form f02m1VO = new Te070f02M1Form();

                    f02m1VO.M1rowno = rec["DENPYOGYO_NO"].ToString();						// Ｍ１行NO
                    f02m1VO.M1bumon_cd = rec["BUMON_CD"].ToString();			            // Ｍ１部門コード
                    f02m1VO.M1bumonkana_nm = rec["BUMONKANA_NM"].ToString();                // Ｍ１部門カナ名                                                                       //部門名称
                    f02m1VO.M1hinsyu_ryaku_nm = rec["HINSYU_RYAKU_NM"].ToString();			// Ｍ１品種略名称
                    f02m1VO.M1burando_nm = rec["BURANDO_NMK"].ToString();					//　ブランド名
                    f02m1VO.M1jisya_hbn = rec["JISYA_HBN"].ToString();						// Ｍ１自社品番
                    f02m1VO.M1maker_hbn = rec["MAKER_HBN"].ToString();						// Ｍ１メーカー品番
                    f02m1VO.M1syonmk = rec["SYONMK"].ToString();							// Ｍ１商品名(カナ)
                    f02m1VO.M1iro_nm = rec["IRO_SEISIKI_NMK"].ToString();					// Ｍ１色
                    f02m1VO.M1size_nm = rec["SIZE_NM"].ToString();							// Ｍ１サイズ
                    f02m1VO.M1scan_cd = rec["JAN_CD"].ToString();							// Ｍ１スキャンコード
                    f02m1VO.M1yotei_su = rec["NYUKAYOTEI_SU"].ToString();					// Ｍ１予定数量
                    // Dictionary.[Ｍ１確定フラグ] = 0の場合
                    if (prevM1Vo.Dictionary[Te070p01Constant.DIC_M1KAKUTEI_FLG].Equals(Te070p01Constant.DIC_M1KAKUTEIFLG0))
                    {
                        f02m1VO.M1kakutei_su = "0";                                         // Ｍ１確定数量
                    }
                    else
                    {
                        f02m1VO.M1kakutei_su = rec["NYUKAJISSEKI_SU"].ToString();			// Ｍ１確定数量

                    }
                    f02m1VO.M1gen_tnk = rec["GEN_TNK"].ToString();						    // Ｍ１原単価


                    if (prevM1Vo.Dictionary[Te070p01Constant.DIC_M1KAKUTEI_FLG].Equals(Te070p01Constant.DIC_M1KAKUTEIFLG0))
                    {
                        f02m1VO.M1genka_kin = (Convert.ToDecimal(f02m1VO.M1gen_tnk) * Convert.ToDecimal(f02m1VO.M1yotei_su)).ToString();
                                                                                           // Ｍ１原価金額
                    }
                    else
                    {
                        f02m1VO.M1genka_kin = (Convert.ToDecimal(f02m1VO.M1gen_tnk) * Convert.ToDecimal(f02m1VO.M1kakutei_su)).ToString();

                    }
 
                    f02m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;				// Ｍ１選択フラグ(隠し)
                    f02m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;			// Ｍ１確定処理フラグ(隠し)

                    // 移動入荷検索-一覧.旧自社品番、スキャンコードと一致する場合
					if (f02m1VO.M1scan_cd.Equals(scanCd) || f02m1VO.M1jisya_hbn.Equals(oldJishahinban))
                    {
                        f02m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_SHOHIN_SHITEI;	// Ｍ１明細色区分(隠し)
                    }
                    else
                    {
                        f02m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;			// Ｍ１明細色区分(隠し)
                    }

                    // 合計値加算
                    dyoteiSuSum += Convert.ToDecimal(f02m1VO.M1yotei_su);
                    dkakuteiSuSum += Convert.ToDecimal(f02m1VO.M1kakutei_su);
                    dKinSum += Convert.ToDecimal(f02m1VO.M1genka_kin);

                    //リストオブジェクトにM1Formを追加します。
                    nextM1List.Add(f02m1VO, true);

                }

                // 合計欄の設定
                nextVo.Gokeiyotei_su = dyoteiSuSum.ToString();
                nextVo.Gokeikakutei_su = dkakuteiSuSum.ToString();
                nextVo.Genka_kin_gokei = dKinSum.ToString();

                 //0件チェック
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

                // 伝票番号
                nextVo.Denpyo_bango = (string)prevM1Vo.Dictionary[Te070p01Constant.DIC_M1DENPYO_BANGO];
                // SCMコード
                nextVo.Scm_cd = BoSystemFormat.formatViewScmCd(prevM1Vo.M1scm_cd);
                // 入荷担当者コード 
                nextVo.Nyukatan_cd = (string)prevM1Vo.Dictionary[Te070p01Constant.DIC_M1ADDHANBAIIN_CD];
                // 入荷担当者
                nextVo.Nyukatan_nm = (string)prevM1Vo.Dictionary[Te070p01Constant.DIC_M1HANBAIIN_NM];
                // 入荷日
                nextVo.Jyuryo_ymd = prevM1Vo.M1jyuryo_ymd;

                LoginInfoVO loginInfVo = LoginInfoUtil.GetLoginInfo();

                decimal loginkaisyacd = Convert.ToDecimal(BoSystemString.Nvl(BoSystemFormat.formatKaisyaCd(loginInfVo.CopCd), "0"));
				decimal syukkakaisya_cd = Convert.ToDecimal(BoSystemString.Nvl(BoSystemFormat.formatKaisyaCd((string)prevM1Vo.Dictionary[Te070p01Constant.DIC_M1SYUKKAKAISYA_CD]), "0"));

                if (loginkaisyacd == syukkakaisya_cd)
                {
                    // 会社コード
                    nextVo.Kaisya_cd ="";
                    // 会社名
                    nextVo.Kaisya_nm ="";
                }
                else
                {
                    // 会社コード
                    nextVo.Kaisya_cd = (string)prevM1Vo.Dictionary[Te070p01Constant.DIC_M1SYUKKAKAISYA_CD];
                    // 会社名
                    nextVo.Kaisya_nm = (string)prevM1Vo.Dictionary[Te070p01Constant.DIC_M1SYUKKAKAISYA_NM];

                }

                //// 出荷店コード
                nextVo.Syukkaten_cd = (string)prevM1Vo.Dictionary[Te070p01Constant.DIC_M1SYUKKATEN_CD];
                //// 出荷店名
                nextVo.Syukkaten_nm = (string)prevM1Vo.Dictionary[Te070p01Constant.DIC_M1TENPO_NM];
                // 出荷担当者コード
                nextVo.Syukkatan_cd = (string)prevM1Vo.Dictionary[Te070p01Constant.DIC_M1SYUKKATAN_CD];
                // 出荷担当者名
                nextVo.Syukkatan_nm = (string)prevM1Vo.Dictionary[Te070p01Constant.DIC_M1SYUKKATAN_HANBAIIN_NM];
                // 出荷日
                nextVo.Syukka_ymd = (string)prevM1Vo.M1syukka_ymd;
                // 伝票状態
                nextVo.Denpyo_jyotainm = prevM1Vo.M1denpyo_jyotainm;
                // 処理名称
                nextVo.Syorinm = prevM1Vo.M1syorinm;
                // 処理日
                nextVo.Syoriymd = prevM1Vo.M1syoriymd;
                // 処理時間
                nextVo.Syori_tm = prevM1Vo.M1syori_tm;

                // 選択明細のVO
                nextVo.Dictionary[Te070p01Constant.DIC_M1SELCETVO] = prevM1Vo;
                // 選択行のインデックスを設定
                nextVo.Dictionary[Te070p01Constant.DIC_M1SELCETROWIDX] = facadeContext.CommandInfo.ListIndex.ToString();

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
			EndMethod(facadeContext, this.GetType().Name + ".DoM1DENPYO_BANGO_FRM");

		}
		#endregion
	}
}
