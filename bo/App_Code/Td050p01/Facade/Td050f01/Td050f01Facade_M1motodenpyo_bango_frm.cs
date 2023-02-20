using com.xebio.bo.Td050p01.Constant;
using com.xebio.bo.Td050p01.Formvo;
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

namespace com.xebio.bo.Td050p01.Facade
{
  /// <summary>
  /// Td050f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Td050f01Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : M1motodenpyo_bango)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(M1motodenpyo_bango)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoM1MOTODENPYO_BANGO_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

            //メソッドの開始処理を実行する。
            StartMethod(facadeContext, this.GetType().Name + ".DoM1MOTODENPYO_BANGO_FRM");

            try
            {
                //DBコンテキストを設定する。
                SetDBContext(facadeContext);
				//コネクションを取得して、トランザクションを開始する。
				OpenConnection(facadeContext);

                //以下に業務ロジックを記述する。
                #region 初期化

                // ログイン情報取得
                LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

                // FormVO取得
                // 画面より情報を取得する。
                Td050f01Form prevVo = (Td050f01Form)facadeContext.FormVO;
                Td050f02Form nextVo = (Td050f02Form)facadeContext.GetUserObject(Td050p01Constant.FCDUO_NEXTVO);

                IDataList prevM1List = prevVo.GetList("M1");
                IDataList nextM1List = nextVo.GetList("M1");
                // 選択行の情報を取得する。
                Td050f01M1Form prevM1Vo = (Td050f01M1Form)prevM1List.GetPageViewList()[facadeContext.CommandInfo.ListIndex];

                // 一覧の初期化
                nextM1List.ClearCacheData();
                nextM1List.Clear();

                #endregion

                #region 業務チェック
                #endregion

                #region 検索処理

                FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(Td050p01Constant.SQL_ID_03, facadeContext.DBContext);

                // バインド値の置き換え
                // 伝票番号 ：黒伝が存在する場合は、黒伝の内容を検索する
				if(string.IsNullOrEmpty(((string)prevM1Vo.Dictionary[Td050p01Constant.DIC_M1KURODENPYO_BANGO])))
				{
					rtSeach.BindValue(Td050p01Constant.SQL_ID_03_REP_DENPYO_BANGO, Convert.ToDecimal(BoSystemString.Nvl((string)prevM1Vo.Dictionary[Td050p01Constant.DIC_M1MOTODENPYO_BANGO], "0")));
				}
				else
				{
					rtSeach.BindValue(Td050p01Constant.SQL_ID_03_REP_DENPYO_BANGO, Convert.ToDecimal(BoSystemString.Nvl((string)prevM1Vo.Dictionary[Td050p01Constant.DIC_M1KURODENPYO_BANGO], "0")));
				}
				
                // 処理日付
                rtSeach.BindValue(Td050p01Constant.SQL_ID_03_REP_SYORI_YMD, Convert.ToDecimal(BoSystemString.Nvl((string)prevM1Vo.Dictionary[Td050p01Constant.DIC_M1SYORI_YMD], "0")));
                // 店舗コード
                rtSeach.BindValue(Td050p01Constant.SQL_ID_03_REP_TENPO_CD, BoSystemFormat.formatTenpoCd((string)prevM1Vo.Dictionary[Td050p01Constant.DIC_M1TENPO_CD]));

                //検索結果を取得します
                rtSeach.CreateDbCommand();
                IList<Hashtable> tableList = rtSeach.Execute();
				if (tableList == null || tableList.Count <= 0)
				{
					// エラー
					ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
				}
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

                decimal dSuryoSum = 0;	// 合計訂正数量
                decimal dKinSum = 0;	// 原価金額合計
                foreach (Hashtable rec in tableList)
                {
                    Td050f02M1Form f02m1VO = new Td050f02M1Form();
                    f02m1VO.M1rowno = rec["DENPYOGYO_NO"].ToString();				// Ｍ１行NO
                    f02m1VO.M1hinsyu_ryaku_nm = rec["HINSYU_RYAKU_NM"].ToString();	// Ｍ１品種略名称
                    f02m1VO.M1jisya_hbn = rec["JISYA_HBN"].ToString();				// Ｍ１自社品番
                    f02m1VO.Dictionary[Td050p01Constant.DIC_M1JISYA_HBN] = rec["JISYA_HBN"].ToString();	// Ｍ１自社品番(変更前情報)
                    f02m1VO.M1maker_hbn = rec["MAKER_HBN"].ToString();				// Ｍ１メーカー品番
                    f02m1VO.M1syonmk = rec["SYONMK"].ToString();					// Ｍ１商品名(カナ)
                    f02m1VO.M1iro_nm = rec["IRO_NM"].ToString();					// Ｍ１色
                    f02m1VO.M1size_nm = rec["SIZE_NM"].ToString();					// Ｍ１サイズ
                    f02m1VO.M1scan_cd = rec["JAN_CD"].ToString();					// Ｍ１スキャンコード     ←　JANコード
                    f02m1VO.M1yotei_su = rec["HENPINYOTEI_SU"].ToString();			// Ｍ１予定数量           ←　返品予定数
                    f02m1VO.M1kakutei_su = rec["HENPINJISSEKI_SU"].ToString();		// Ｍ１確定数量           ←　返品実績数
                    f02m1VO.M1teisei_suryo = "";                                    // Ｍ１訂正数量           ←　空白固定
                    f02m1VO.M1gen_tnk = rec["GEN_TNK"].ToString();					// Ｍ１原単価
                    f02m1VO.M1genka_kin = rec["GENKA_KIN"].ToString();				// Ｍ１原価金額           ←　原単価×返品実績数
                    f02m1VO.M1teisei_suryo_hdn = f02m1VO.M1kakutei_su;   			// Ｍ１訂正数量（隠し）   ←　Ｍ１確定数量
                    f02m1VO.M1genka_kin_hdn = f02m1VO.M1genka_kin;   				// Ｍ１原価金額（隠し）   ←　Ｍ１原価金額
                    f02m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;		// Ｍ１選択フラグ(隠し)
                    f02m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;	// Ｍ１確定処理フラグ(隠し)

                    
					// または[Ｍ１スキャンコード]が返品伝票訂正-一覧.[スキャンコード]と等しい場合
					if (f02m1VO.M1jisya_hbn.Equals((string)prevVo.Dictionary[Td050p01Constant.DIC_SEARCH_XEBIOCD])
					 || f02m1VO.M1scan_cd.Equals((string)prevVo.Dictionary[Td050p01Constant.DIC_SEARCH_JANCD]))
					{

                        // 一覧画面で入力されたスキャンコードが一致する場合、背景色変更
                        f02m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_SHOHIN_SHITEI;	// Ｍ１明細色区分(隠し)  ←　"2"（自社品番/スキャンコード検索）
                    }
                    else
                    {
                        f02m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;			// Ｍ１明細色区分(隠し)　←　"0"（通常）
                    }

                    // 合計値加算
                    dSuryoSum += Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1kakutei_su, "0"));	// Ｍ１確定数量の合計
                    dKinSum += Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1genka_kin, "0"));		// Ｍ１原価金額の合計

                    //リストオブジェクトにM1Formを追加します。
                    nextM1List.Add(f02m1VO, true);

                }

                // 合計欄の設定
                nextVo.Gokeiteisei_suryo = dSuryoSum.ToString();
                nextVo.Genka_kin_gokei = dKinSum.ToString();


                #region カード部設定
                // ヘッダ店舗コード
				nextVo.Head_tenpo_cd = (string)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "HEAD_TENPO_CD"];
                // ヘッダ店舗名
				nextVo.Head_tenpo_nm = (string)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "HEAD_TENPO_NM"];
                // 選択モードNO
                nextVo.Stkmodeno = prevVo.Stkmodeno;
                // 伝票番号
                nextVo.Denpyo_bango = (string)prevM1Vo.Dictionary[Td050p01Constant.DIC_M1MOTODENPYO_BANGO];
                // 入力担当者コード
                nextVo.Nyuryokutan_cd = (string)prevM1Vo.Dictionary[Td050p01Constant.DIC_M1HHTADDTAN_CD];
                // 入力担当者名
                nextVo.Nyuryokutan_nm = prevM1Vo.M1nyuryokutan_nm;
                // 確定担当者コード
                nextVo.Kakuteitan_cd = (string)prevM1Vo.Dictionary[Td050p01Constant.DIC_M1UPD_TANCD];
                // 確定担当者名称
                nextVo.Kakuteitan_nm = prevM1Vo.M1kakuteitan_nm;
                // 返品理由
                nextVo.Henpin_riyu_nm = prevM1Vo.M1henpin_riyu_nm;
                // 仕入先コード
                nextVo.Siiresaki_cd = prevM1Vo.M1siiresaki_cd;
                // 仕入先名
                nextVo.Siiresaki_ryaku_nm = prevM1Vo.M1siiresaki_ryaku_nm;
                // 部門コード
                nextVo.Bumon_cd = prevM1Vo.M1bumon_cd_bo1;
                // 部門名
                nextVo.Bumon_nm = (string)prevM1Vo.Dictionary[Td050p01Constant.DIC_M1BUMON_NM];
                // 指示番号
                nextVo.Siji_bango = prevM1Vo.M1siji_bango;
                // 返品確定日
                nextVo.Henpin_kakutei_ymd = prevM1Vo.M1henpin_kakutei_ymd;
                // 登録日
                nextVo.Add_ymd = prevM1Vo.M1add_ymd;
                // 備考
                nextVo.Biko = (string)prevM1Vo.Dictionary[Td050p01Constant.DIC_M1BIKO];

                // 選択明細のVO
                nextVo.Dictionary[Td050p01Constant.DIC_M1SELCETVO] = prevM1Vo;
                // 選択行のインデックスを設定
                nextVo.Dictionary[Td050p01Constant.DIC_M1SELCETROWIDX] = facadeContext.CommandInfo.ListIndex.ToString();

                #endregion

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
            EndMethod(facadeContext, this.GetType().Name + ".DoM1MOTODENPYO_BANGO_FRM");

		}
		#endregion
	}
}
