using com.xebio.bo.Tb090p01.Constant;
using com.xebio.bo.Tb090p01.Formvo;
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

namespace com.xebio.bo.Tb090p01.Facade
{
  /// <summary>
  /// Tb090f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tb090f01Facade : StandardBaseFacade
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
			//	//コネクションを取得して、トランザクションを開始する。
			//	BeginTransactionWithConnect(facadeContext);
				//コネクションを取得する。
				OpenConnection(facadeContext);

				//以下に業務ロジックを記述する。

				#region 初期化

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Tb090f01Form prevVo = (Tb090f01Form)facadeContext.FormVO;
				Tb090f02Form nextVo = (Tb090f02Form)facadeContext.GetUserObject(Tb090p01Constant.FCDUO_NEXTVO);

				IDataList prevM1List = prevVo.GetList("M1");
				IDataList nextM1List = nextVo.GetList("M1");

				// 選択行の情報を取得する。
				Tb090f01M1Form prevM1Vo = (Tb090f01M1Form)prevM1List.GetPageViewList()[facadeContext.CommandInfo.ListIndex];

				// Dictionaryから検索条件を取得
				String tenpoCd = BoSystemFormat.formatTenpoCd((string)prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Head_tenpo_cd)]);
				String tenpoNm = (string)prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Head_tenpo_nm)];
				String oldJishahinban = BoSystemFormat.formatJisyaHbn((string)prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Old_jisya_hbn)]);
				String scanCd = BoSystemFormat.formatJanCd((string)prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Scan_cd)]);

				// 一覧の初期化
				nextM1List.ClearCacheData();
				nextM1List.Clear();

				#endregion

				#region 業務チェック
				#endregion

				#region 検索処理

				// [選択モードNO]が「仕入確定」の場合、仕入入荷予定テーブルから検索する。
				string sSqlId = "";
				sSqlId = Tb090p01Constant.SQL_ID_03;

				FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(sSqlId, facadeContext.DBContext);
				// バインド値の置き換え
				// 確定種別
				rtSeach.BindValue(Tb090p01Constant.SQL_ID_03_REP_KAKUTEI_SB, Convert.ToDecimal((string)prevM1Vo.Dictionary[Tb090p01Constant.DIC_M1KAKUTEI_SB]));
				// 仕入先コード
				rtSeach.BindValue(Tb090p01Constant.SQL_ID_03_REP_SIIRESAKI_CD, BoSystemFormat.formatSiiresakiCd(prevM1Vo.M1siiresaki_cd));
				// 伝票番号
				rtSeach.BindValue(Tb090p01Constant.SQL_ID_03_REP_DENPYO_BANGO, Convert.ToDecimal((string)prevM1Vo.Dictionary[Tb090p01Constant.DIC_M1DENPYO_BANGO]));
				// 入荷予定日
				rtSeach.BindValue(Tb090p01Constant.SQL_ID_03_REP_SITEINOHIN_YMD, Convert.ToDecimal(BoSystemFormat.formatDate(prevM1Vo.M1nyukayotei_ymd)));
				// 店舗コード
				rtSeach.BindValue(Tb090p01Constant.SQL_ID_03_REP_TENPO_CD, BoSystemFormat.formatTenpoCd(tenpoCd));

				//検索結果を取得します
				rtSeach.CreateDbCommand();
				IList<Hashtable> tableList = rtSeach.Execute();

				decimal dTeiseiSuSum = 0;		// 訂正数合計
				decimal dKinSum = 0;			// 原価金額合計

				foreach (Hashtable rec in tableList)
				{
					Tb090f02M1Form f02m1VO = new Tb090f02M1Form();

					f02m1VO.M1rowno = rec["DENPYOGYO_NO"].ToString();													// Ｍ１行NO
					f02m1VO.M1hinsyu_ryaku_nm = rec["HINSYU_RYAKU_NM"].ToString();										// Ｍ１品種略名称
					f02m1VO.M1burando_nm = rec["BURANDO_NMK"].ToString();												// Ｍ１ブランド名
					f02m1VO.M1jisya_hbn = BoSystemFormat.formatJisyaHbn(rec["JISYA_HBN"].ToString());					// Ｍ１自社品番
					f02m1VO.M1maker_hbn = rec["MAKER_HBN"].ToString();													// Ｍ１メーカー品番
					f02m1VO.M1syonmk = rec["SYONMK"].ToString();														// Ｍ１商品名(カナ)
					f02m1VO.M1iro_nm = rec["IRO_NM"].ToString();														// Ｍ１色
					f02m1VO.M1size_nm = rec["SIZE_NM"].ToString();														// Ｍ１サイズ
					f02m1VO.M1scan_cd = BoSystemFormat.formatJanCd(rec["JAN_CD"].ToString());							// Ｍ１スキャンコード
					if (!((string)prevM1Vo.Dictionary[Tb090p01Constant.DIC_M1KAKUTEI_SB]).Equals(BoSystemConstant.KAKUTEI_SB_HENPIN_MANUAL)
						&& !((string)prevM1Vo.Dictionary[Tb090p01Constant.DIC_M1KAKUTEI_SB]).Equals(BoSystemConstant.KAKUTEI_SB_HENPIN_MANUAL_TEISEI))
					{
						// マニュアル以外の場合
						f02m1VO.M1nohin_su = rec["YOTEI_SU"].ToString();												// Ｍ１納品数
					}
					else
					{
						// マニュアルの場合空白
						f02m1VO.M1nohin_su = string.Empty;																// Ｍ１納品数
					}
					f02m1VO.M1kensu = rec["JISSEKI_SU"].ToString();														// Ｍ１検数
					f02m1VO.M1teisei_suryo = string.Empty;																// Ｍ１訂正数
					f02m1VO.M1gen_tnk = rec["GEN_TNK"].ToString();														// Ｍ１原単価

					// [選択モードNo]が「訂正」、かつ確定フラグが１の場合
					// 一覧画面の選択情報
					if (BoSystemConstant.MODE_TEISEI.Equals(prevVo.Stkmodeno)
						&& ConditionKakuteisyori_flg.VALUE_ARI.Equals(prevM1Vo.M1entersyoriflg))
					{
						Dictionary<string, Tb090f02M1Form> dicM1List = (Dictionary<string, Tb090f02M1Form>)prevM1Vo.Dictionary[Tb090p01Constant.DIC_M1MEISAILIST];
		
						// 明細リスト
						if (dicM1List != null)
						{
							Tb090f02M1Form tmpf02m1VO = (Tb090f02M1Form)dicM1List[f02m1VO.M1rowno];

							f02m1VO.M1hinsyu_ryaku_nm = tmpf02m1VO.M1hinsyu_ryaku_nm;									// Ｍ１品種略名称
							f02m1VO.M1burando_nm = tmpf02m1VO.M1burando_nm;												// Ｍ１ブランド名
							f02m1VO.M1jisya_hbn = BoSystemFormat.formatJisyaHbn(tmpf02m1VO.M1jisya_hbn);				// Ｍ１自社品番
							f02m1VO.M1maker_hbn = tmpf02m1VO.M1maker_hbn;												// Ｍ１メーカー品番
							f02m1VO.M1syonmk = tmpf02m1VO.M1syonmk;														// Ｍ１商品名(カナ)
							f02m1VO.M1iro_nm = tmpf02m1VO.M1iro_nm;														// Ｍ１色
							f02m1VO.M1size_nm = tmpf02m1VO.M1size_nm;													// Ｍ１サイズ
							f02m1VO.M1scan_cd = BoSystemFormat.formatJanCd(tmpf02m1VO.M1scan_cd);						// Ｍ１スキャンコード
							f02m1VO.M1nohin_su = tmpf02m1VO.M1nohin_su;													// Ｍ１納品数
							f02m1VO.M1kensu = BoSystemString.Nvl(tmpf02m1VO.M1teisei_suryo, tmpf02m1VO.M1kensu);		// Ｍ１検数
							f02m1VO.M1gen_tnk = tmpf02m1VO.M1gen_tnk;													// Ｍ１原単価
						}
					}

					f02m1VO.M1genkakin = (Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1gen_tnk, "0"))
											* Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1kensu, "0"))).ToString();
																														// Ｍ１原価金額

					f02m1VO.M1teisei_suryo_hdn = f02m1VO.M1kensu;														// Ｍ１訂正数(隠し)
					f02m1VO.M1genkakin_hdn = f02m1VO.M1genkakin;														// Ｍ１原価金額(隠し)

					f02m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;											// Ｍ１選択フラグ(隠し)
					f02m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;										// Ｍ１確定処理フラグ(隠し)

					// 仕入伝票訂正-一覧.旧自社品番、スキャンコードと一致する場合
					string jancd = (string)prevVo.Dictionary[Tb090p01Constant.DIC_SEARCH_JANCD];
					string xebiocd = (string)prevVo.Dictionary[Tb090p01Constant.DIC_SEARCH_XEBIOCD];
					if (jancd.Equals(f02m1VO.M1scan_cd) || xebiocd.Equals(f02m1VO.M1jisya_hbn))
					{
						// 一覧画面で入力されたスキャンコード、自社品番が一致する場合、背景色変更
						f02m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_SHOHIN_SHITEI;
					}
					else
					{
						f02m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;
					}
					//if (   f02m1VO.M1scan_cd.Equals(scanCd)
					//	|| f02m1VO.M1jisya_hbn.Equals(oldJishahinban)
					//	|| rec["OLD_XEBIO_CD"].ToString().Equals(oldJishahinban))
					//{
					//	f02m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_SHOHIN_SHITEI;								// Ｍ１明細色区分(隠し)
					//}
					//else
					//{
					//	f02m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;										// Ｍ１明細色区分(隠し)
					//}

					// 合計値加算
					dTeiseiSuSum += Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1kensu, "0"));
					dKinSum += Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1genkakin, "0"));

					// Dictionary(確定時に再取得するものはここでは取得しない)
					f02m1VO.Dictionary[Tb090p01Constant.DIC_M1JISYA_HBN]	=  f02m1VO.M1jisya_hbn;											// 自社品番
					f02m1VO.Dictionary[Tb090p01Constant.DIC_M1SCAN_CD]		= f02m1VO.M1scan_cd;											// スキャンコード
					f02m1VO.Dictionary[Tb090p01Constant.DIC_M1SYOHIN_CD]	= rec["SYOHIN_CD"].ToString();									// 商品コード
					f02m1VO.Dictionary[Tb090p01Constant.DIC_M1SIZE_CD]		= BoSystemFormat.formatSizeCd(rec["SIZE_CD"].ToString());		// サイズコード
					f02m1VO.Dictionary[Tb090p01Constant.DIC_M1HINSYU_CD]	= BoSystemFormat.formatHinsyuCd(rec["HINSYU_CD"].ToString());	// 品種コード
					f02m1VO.Dictionary[Tb090p01Constant.DIC_M1BURANDO_CD]	= BoSystemFormat.formatBrandCd(rec["BURANDO_CD"].ToString());	// ブランドコード
					f02m1VO.Dictionary[Tb090p01Constant.DIC_M1IRO_CD] = BoSystemFormat.formatIroCd(rec["IRO_CD"].ToString());				// 色コード

					//リストオブジェクトにM1Formを追加します。
					nextM1List.Add(f02m1VO, true);

				}

				// 合計欄の設定
				nextVo.Gokei_teisei_suryo = dTeiseiSuSum.ToString();
				nextVo.Gokei_genkakin = dKinSum.ToString();

				// 0件チェック
				if (nextM1List.Count == 0)
				{
					ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
					return;
				}

				#region カード部設定

				// ヘッダ店舗コード
				nextVo.Head_tenpo_cd = tenpoCd;
				// ヘッダ店舗名
				nextVo.Head_tenpo_nm = tenpoNm;
				// 選択モードNO
				nextVo.Stkmodeno = prevVo.Stkmodeno;

				// 伝票番号
				nextVo.Denpyo_bango = (string)prevM1Vo.Dictionary[Tb090p01Constant.DIC_M1MOTODENPYO_BANGO];
				// 仕入先コード
				nextVo.Siiresaki_cd = prevM1Vo.M1siiresaki_cd;
				// 仕入先名
				nextVo.Siiresaki_ryaku_nm = prevM1Vo.M1siiresaki_ryaku_nm;
				// 部門コード
				nextVo.Bumon_cd = prevM1Vo.M1bumon_cd_bo;
				// 部門名
				nextVo.Bumon_nm = (string)prevM1Vo.Dictionary[Tb090p01Constant.DIC_M1BUMON_NM];
				// 確定担当者コード
				nextVo.Kakuteitan_cd = (string)prevM1Vo.Dictionary[Tb090p01Constant.DIC_M1FIXED_TANCD];
				// 確定担当者名称
				nextVo.Kakuteitan_nm = prevM1Vo.M1kakuteitan_nm;
				// 入荷予定日
				nextVo.Nyukayotei_ymd = prevM1Vo.M1nyukayotei_ymd;
				// 仕入確定日
				nextVo.Siire_kakutei_ymd = prevM1Vo.M1siire_kakutei_ymd;
				// 確定種別
				nextVo.Kakutei_sb_nm = prevM1Vo.M1kakutei_sb_nm;

				// 備考
				nextVo.Biko_kb = (string)prevM1Vo.Dictionary[Tb090p01Constant.DIC_M1BIKO_KB];
				// 備考①
				nextVo.Biko1 = (string)prevM1Vo.Dictionary[Tb090p01Constant.DIC_M1BIKO1];
				// 備考②
				nextVo.Biko2 = (string)prevM1Vo.Dictionary[Tb090p01Constant.DIC_M1BIKO2];

				// 選択明細のVO
				nextVo.Dictionary[Tb090p01Constant.DIC_M1SELCETVO] = prevM1Vo;
				// 選択行のインデックスを設定
				nextVo.Dictionary[Tb090p01Constant.DIC_M1SELCETROWIDX] = facadeContext.CommandInfo.ListIndex.ToString();

				#endregion

				#endregion

				//	//トランザクションをコミットする。
			//	CommitTransaction(facadeContext);
			}
			catch (System.Exception ex)
			{
			//	//トランザクションをロールバックする。
			//	RollbackTransaction(facadeContext);
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
