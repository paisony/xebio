using com.xebio.bo.Tj090p01.Constant;
using com.xebio.bo.Tj090p01.Formvo;
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
using System;
using System.Collections;
using System.Collections.Generic;

namespace com.xebio.bo.Tj090p01.Facade
{
  /// <summary>
  /// Tj090f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tj090f01Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : M1rowno)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(M1rowno)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoM1ROWNO_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

            //メソッドの開始処理を実行する。
            StartMethod(facadeContext, this.GetType().Name + ".DoM1ROWNO_FRM");

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
                Tj090f01Form prevVo = (Tj090f01Form)facadeContext.FormVO;
                Tj090f02Form nextVo = (Tj090f02Form)facadeContext.GetUserObject(Tj090p01Constant.FCDUO_NEXTVO);

                IDataList prevM1List = prevVo.GetList("M1");
                IDataList nextM1List = nextVo.GetList("M1");

                // 選択行の情報を取得する。
                Tj090f01M1Form prevM1Vo = (Tj090f01M1Form)prevM1List.GetPageViewList()[facadeContext.CommandInfo.ListIndex];

                // 一覧の初期化
                nextM1List.ClearCacheData();
                nextM1List.Clear();

                #region 業務チェック
                #endregion

                #region 検索処理

                FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(Tj090p01Constant.SQL_ID_03, facadeContext.DBContext);

                // バインド値の置き換え
                // 店舗コード
                rtSeach.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((String)prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Head_tenpo_cd)]));
                // フェイス№
                rtSeach.BindValue("BIND_FACE_NO", Convert.ToDecimal(BoSystemString.Nvl(prevM1Vo.Dictionary[Tj090p01Constant.DIC_M1FACE_NO].ToString(), "0")));
                // 棚段
                rtSeach.BindValue("BIND_TANA_DAN", Convert.ToDecimal(BoSystemString.Nvl(prevM1Vo.Dictionary[Tj090p01Constant.DIC_M1TANA_DAN].ToString(), "0")));
                // 回数
                rtSeach.BindValue("BIND_KAI_SU", Convert.ToDecimal(BoSystemString.Nvl(prevM1Vo.M1kai_su, "0")));
                // 棚卸日
                rtSeach.BindValue("BIND_TANAOROSI_YMD", Convert.ToDecimal(BoSystemString.Nvl(prevM1Vo.Dictionary[Tj090p01Constant.DIC_M1TANAOROSI_YMD].ToString(), "0")));
                // 送信回数
                rtSeach.BindValue("BIND_SOSINKAI_SU", Convert.ToDecimal(BoSystemString.Nvl(prevM1Vo.Dictionary[Tj090p01Constant.DIC_M1SOSINKAI_SU].ToString(), "0")));

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

				foreach (Hashtable rec in tableList)
				{
                    Tj090f02M1Form m1formVO = new Tj090f02M1Form();

                    // Ｍ１行NO
                    m1formVO.M1rowno = rec["GYO_NBR"].ToString();
                    // Ｍ１部門コード
                    m1formVO.M1bumon_cd = rec["BUMON_CD"].ToString();
                    // Ｍ１部門カナ名
					m1formVO.M1bumonkana_nm = rec["BUMONKANA_NM"].ToString();
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
                    m1formVO.Dictionary[Tj090p01Constant.DIC_M1BURANDO_CD] = rec["BURANDO_CD"].ToString();
                    // 品種コード
                    m1formVO.Dictionary[Tj090p01Constant.DIC_M1HINSYU_CD] = ((decimal)rec["HINSYU_CD"]).ToString();
                    // 色コード
                    m1formVO.Dictionary[Tj090p01Constant.DIC_M1IRO_CD] = rec["IRO_CD"].ToString();
                    // サイズコード
                    m1formVO.Dictionary[Tj090p01Constant.DIC_M1SIZE_CD] = rec["SIZE_CD"].ToString();

                    // Ｍ１スキャン数量
                    m1formVO.M1scan_su = rec["TANAOROSISCAN_SU"].ToString();
                    // Ｍ１訂正数量
                    m1formVO.M1teisei_suryo = rec["TANAOROSITEISEI_SU"].ToString();
                    // Ｍ１訂正数量(隠し)
                    m1formVO.M1teisei_suryo_hdn = rec["TANAOROSITEISEI_SU"].ToString();
                    // Ｍ１合計数量
                    m1formVO.M1gokei_suryo = rec["TANAOROSIGOKEI_SU"].ToString();

                    // Ｍ１選択フラグ(隠し)
                    m1formVO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;
                    // Ｍ１確定処理フラグ(隠し)
                    m1formVO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;
                    // Ｍ１明細色区分(隠し)
                    m1formVO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;


                    // 合計値加算
                    dScanSuSum   += Convert.ToDecimal(BoSystemString.Nvl(m1formVO.M1scan_su, "0"));
                    dTeiseiSuSum += Convert.ToDecimal(BoSystemString.Nvl(m1formVO.M1teisei_suryo, "0"));
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
                nextVo.Head_tenpo_cd = BoSystemFormat.formatTenpoCd((String)prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Head_tenpo_cd)]);
                // ヘッダ店舗名
                nextVo.Head_tenpo_nm = (String)prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Head_tenpo_nm)];

                // モードNO
                nextVo.Modeno = prevVo.Stkmodeno;
                // 選択モードNO
                nextVo.Stkmodeno = prevVo.Stkmodeno;

                // フェイス№
                nextVo.Face_no = prevM1Vo.M1face_no;
                nextVo.Dictionary[Tj090p01Constant.DIC_FACE_NO] = (String)prevM1Vo.Dictionary[Tj090p01Constant.DIC_M1FACE_NO];
                // 棚段
                nextVo.Tana_dan = prevM1Vo.M1tana_dan;
                nextVo.Dictionary[Tj090p01Constant.DIC_TANA_DAN] = (String)prevM1Vo.Dictionary[Tj090p01Constant.DIC_M1TANA_DAN];
                // 回数
                nextVo.Kai_su = prevM1Vo.M1kai_su;
                // 点数棚卸数量
                nextVo.Tensutanaorosi_su = prevM1Vo.M1tensutanaorosigokei_su;
                // 入力担当者コード
                nextVo.Nyuryokutan_cd = (String)prevM1Vo.Dictionary[Tj090p01Constant.DIC_M1NYURYOKUTAN_CD];
                // 入力担当者名称
                nextVo.Nyuryokutan_nm = prevM1Vo.M1nyuryokutan_nm;
                // 入力日
                nextVo.Nyuryoku_ymd = prevM1Vo.M1nyuryoku_ymd;
                // 理由コメント情報
                nextVo.Riyucomment_nm = prevM1Vo.M1riyucomment_nm;

				// 点数棚卸訂正数
				nextVo.Dictionary[Tj090p01Constant.DIC_TENSUTANAOROSITEISEI_SU] = (String)prevM1Vo.M1tensutanaorositeisei_su;
                // 棚卸日
                nextVo.Dictionary[Tj090p01Constant.DIC_TANAOROSI_YMD] = (String)prevM1Vo.Dictionary[Tj090p01Constant.DIC_M1TANAOROSI_YMD];
                // 送信回数
                nextVo.Dictionary[Tj090p01Constant.DIC_SOSINKAI_SU] = (String)prevM1Vo.Dictionary[Tj090p01Constant.DIC_M1SOSINKAI_SU];
				// 更新日
				nextVo.Dictionary[Tj090p01Constant.DIC_UPD_YMD] = (String)prevM1Vo.Dictionary[Tj090p01Constant.DIC_M1UPD_YMD];
				// 更新時間
				nextVo.Dictionary[Tj090p01Constant.DIC_UPD_TM] = (String)prevM1Vo.Dictionary[Tj090p01Constant.DIC_M1UPD_TM];

				// 選択明細のVO
				nextVo.Dictionary[Tj090p01Constant.DIC_M1SELCETVO] = prevM1Vo;
				// 選択行のインデックスを設定
				nextVo.Dictionary[Tj090p01Constant.DIC_M1SELCETROWIDX] = facadeContext.CommandInfo.ListIndex.ToString();

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
            EndMethod(facadeContext, this.GetType().Name + ".DoM1ROWNO_FRM");

		}
		#endregion
	}
}
