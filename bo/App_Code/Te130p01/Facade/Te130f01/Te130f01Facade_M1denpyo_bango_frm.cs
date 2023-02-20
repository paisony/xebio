using com.xebio.bo.Te130p01.Constant;
using com.xebio.bo.Te130p01.Formvo;
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

namespace com.xebio.bo.Te130p01.Facade
{
  /// <summary>
  /// Te130f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Te130f01Facade : StandardBaseFacade
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
				Te130f01Form prevVo = (Te130f01Form)facadeContext.FormVO;
				Te130f02Form nextVo = (Te130f02Form)facadeContext.GetUserObject(Te130p01Constant.FCDUO_NEXTVO);

				IDataList prevM1List = prevVo.GetList("M1");
				IDataList nextM1List = nextVo.GetList("M1");

				// 選択行の情報を取得する。
				Te130f01M1Form prevM1Vo = (Te130f01M1Form)prevM1List.GetPageViewList()[facadeContext.CommandInfo.ListIndex];

				// Dictionaryから検索条件を取得
				String tenpoCd = BoSystemFormat.formatTenpoCd((string)prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Head_tenpo_cd)]);
				String tenpoNm = (string)prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Head_tenpo_nm)];
				String oldJishahinban = (string)prevVo.Dictionary[Te130p01Constant.DIC_SEARCH_XEBIOCD];
				String scanCd = (string)prevVo.Dictionary[Te130p01Constant.DIC_SEARCH_JANCD];
				//一覧の初期化
				nextM1List.ClearCacheData();
				nextM1List.Clear();

				#endregion

				#region 検索処理
				FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(Te130p01Constant.SQL_ID_03, facadeContext.DBContext);
				//入荷会社コード
				rtSeach.BindValue(Te130p01Constant.SQL_ID_02_JYURYOKAISYA_CD, Convert.ToDecimal((string)prevM1Vo.Dictionary[Te130p01Constant.DIC_M1NYUKAKAI_CD]));
				//入荷店コード
				rtSeach.BindValue(Te130p01Constant.SQL_ID_02_JYURYOTEN_CD, BoSystemFormat.formatTenpoCd(prevM1Vo.M1jyuryoten_cd));
				//伝票番号
				rtSeach.BindValue(Te130p01Constant.SQL_ID_02_DENPYO_BANGO, Convert.ToDecimal(BoSystemFormat.formatDenpyoNo((string)prevM1Vo.Dictionary[Te130p01Constant.DIC_M1DENPYOBANGO])));
				//入荷日
				rtSeach.BindValue(Te130p01Constant.SQL_ID_02_JYURYO_YMD, Convert.ToDecimal(BoSystemFormat.formatDate(Convert.ToDecimal(prevM1Vo.M1jyuryo_ymd))));
				//履歴No
				rtSeach.BindValue(Te130p01Constant.SQL_ID_02_RIREKI_NO, Convert.ToDecimal(prevM1Vo.Dictionary[Te130p01Constant.DIC_M1RIREKI_NO]));
				//赤黒区分
				rtSeach.BindValue(Te130p01Constant.SQL_ID_02_AKAKURO_KBN, Convert.ToDecimal(prevM1Vo.Dictionary[Te130p01Constant.DIC_M1AKAKURO_KBN]));	
				
				//検索結果を取得します
				rtSeach.CreateDbCommand();
				IList<Hashtable> tableList = rtSeach.Execute();
	
				decimal dYoteiSum = 0;		//配送数合計
				decimal dKakuteiSum = 0;	// 原価金額合計
				decimal dGenkaSum = 0;

				int iCnt = 0;
				foreach (Hashtable rec in tableList)
				{
					iCnt++;
					Te130f02M1Form f02m1VO = new Te130f02M1Form();
	
					//原価金額計算
	
					f02m1VO.M1rowno = iCnt.ToString(); 			                    // Ｍ１行NO
					f02m1VO.M1bumon_cd = rec["BUMON_CD"].ToString();				// Ｍ１部門
					f02m1VO.M1bumonkana_nm = rec["BUMONKANA_NM"].ToString();		// Ｍ１部門かな
					f02m1VO.M1hinsyu_ryaku_nm = rec["HINSYU_RYAKU_NM"].ToString();  // Ｍ１品種
					f02m1VO.M1burando_nm = rec["BURANDO_NMK"].ToString();			// Ｍ１ブランド
					f02m1VO.M1jisya_hbn = rec["JISYA_HBN"].ToString();				// Ｍ１自社品番
					f02m1VO.M1maker_hbn = rec["MAKER_HBN"].ToString();				// Ｍ１メーカー品番
					f02m1VO.M1syonmk = rec["SYONMK"].ToString();					// Ｍ１商品名
					f02m1VO.M1iro_nm = rec["IRO_NM"].ToString();					// Ｍ１色
					f02m1VO.M1size_nm = rec["SIZE_NM"].ToString();					// Ｍ１サイズ
					f02m1VO.M1scan_cd = rec["JAN_CD"].ToString();					// Ｍ１スキャンコード
					f02m1VO.M1nyukayotei_su = rec["NYUKAYOTEI_SU"].ToString();		// Ｍ１予定数量
					f02m1VO.M1nyukajisseki_su = rec["NYUKAJISSEKI_SU"].ToString();	// Ｍ１確定数量
					f02m1VO.M1gen_tnk = rec["GEN_TNK"].ToString();					// Ｍ１減単価
					//f02m1VO.M1genka_kin = rec["GEN_TNK"].ToString();				// Ｍ１原価金額
					f02m1VO.M1genka_kin = (Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1gen_tnk, "0"))
											* Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1nyukajisseki_su, "0"))).ToString();
	
					f02m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;		// Ｍ１選択フラグ(隠し)
					f02m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;	// Ｍ１確定処理フラグ(隠し)
					f02m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;		// Ｍ１明細色区分(隠し)
	
					// 合計値加算
					dYoteiSum += Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1nyukayotei_su, "0"));
					dKakuteiSum += Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1nyukajisseki_su, "0"));
					dGenkaSum += Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1genka_kin, "0"));
					// 仕入入荷検索-一覧.旧自社品番、スキャンコードと一致する場合
					if (f02m1VO.M1scan_cd.Equals(scanCd) || f02m1VO.M1jisya_hbn.Equals(oldJishahinban))
					{
						f02m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_SHOHIN_SHITEI;	// Ｍ１明細色区分(隠し)
					}
					else
					{
						f02m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;			// Ｍ１明細色区分(隠し)
					}

	
					//リストオブジェクトにM1Formを追加します。
					nextM1List.Add(f02m1VO, true);
	
				}
	
				// 合計欄の設定
				nextVo.Nyukayotei_su_gokei = dYoteiSum.ToString();
				nextVo.Nyukajisseki_su_gokei = dKakuteiSum.ToString();
				nextVo.Genka_kin_gokei = dGenkaSum.ToString();
	
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
				//伝票番号
				nextVo.Denpyo_bango = BoSystemFormat.formatDenpyoNo((string)prevM1Vo.Dictionary[Te130p01Constant.DIC_M1DENPYOBANGO]);
				//SCMコード
				nextVo.Scm_cd = BoSystemFormat.formatViewScmCd((string)prevM1Vo.Dictionary[Te130p01Constant.DIC_M1SCM_CD]);
				//入荷会社コード
				nextVo.Jyuryokaisya_cd = (string)prevM1Vo.Dictionary[Te130p01Constant.DIC_M1NYUKAKAI_CD];
				//入荷会社名
				nextVo.Nyukakaisya_nm = (string)prevM1Vo.Dictionary[Te130p01Constant.DIC_M1NYUKAKAI_NM];
				//入荷店コード
				nextVo.Jyuryoten_cd = prevM1Vo.M1jyuryoten_cd;
				//入荷店名
				nextVo.Juryoten_nm = prevM1Vo.M1juryoten_nm;
				//入荷担当者コード
				nextVo.Nyukatan_cd = BoSystemFormat.formatTantoCd((string)prevM1Vo.Dictionary[Te130p01Constant.DIC_M1ADDTAN_CD]);
				//入荷担当者名
				nextVo.Nyukatan_nm = (string)prevM1Vo.Dictionary[Te130p01Constant.DIC_M1NYUKAHANBAI_NM];
				//入荷日
				nextVo.Jyuryo_ymd = prevM1Vo.M1jyuryo_ymd;
				//出荷会社コード
				nextVo.Syukkakaisya_cd = (string)prevM1Vo.Dictionary[Te130p01Constant.DIC_M1SYUKKAKAI_CD];
				//出荷会社名
				nextVo.Syukkakaisya_nm = (string)prevM1Vo.Dictionary[Te130p01Constant.DIC_M1SYUKKAKAI_NM];
				//出荷店コード
				nextVo.Syukkaten_cd = prevM1Vo.M1syukkaten_cd;
				//出荷店名
				nextVo.Syukkatenpo_nm = prevM1Vo.M1syukkatenpo_nm;
				//出荷担当者コード
				nextVo.Syukkatan_cd = BoSystemFormat.formatTantoCd((string)prevM1Vo.Dictionary[Te130p01Constant.DIC_M1SYUKKATAN_CD]);
				//出荷担当者名
				nextVo.Syukkatan_nm = (string)prevM1Vo.Dictionary[Te130p01Constant.DIC_M1SYUKKAHANBAI_NM];
				//出荷日
				nextVo.Syukka_ymd = prevM1Vo.M1syukka_ymd;
				//処理
				nextVo.Syorinm = prevM1Vo.M1syorinm;
				//処理日
				nextVo.Syoriymd = prevM1Vo.M1syori_ymd;
				//処理時間
				nextVo.Syori_tm = prevM1Vo.M1syori_tm;



				//選択明細のVO
				nextVo.Dictionary[Te130p01Constant.DIC_M1SELCETVO] = prevM1Vo;
				// 選択行のインデックスを設定
				nextVo.Dictionary[Te130p01Constant.DIC_M1SELCETROWIDX] = facadeContext.CommandInfo.ListIndex.ToString();

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
			EndMethod(facadeContext, this.GetType().Name + ".DoM1DENPYO_BANGO_FRM");

		}
		#endregion
	}
}
