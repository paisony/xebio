using com.xebio.bo.Tb010p01.Constant;
using com.xebio.bo.Tb010p01.Formvo;
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

namespace com.xebio.bo.Tb010p01.Facade
{
  /// <summary>
  /// Tb010f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tb010f01Facade : StandardBaseFacade
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
				////コネクションを取得して、トランザクションを開始する。
				//BeginTransactionWithConnect(facadeContext);
				//コネクションを取得する。
				OpenConnection(facadeContext);

				//以下に業務ロジックを記述する。
				
				#region 初期化

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Tb010f01Form prevVo = (Tb010f01Form)facadeContext.FormVO;
				Tb010f02Form nextVo = (Tb010f02Form)facadeContext.GetUserObject(Tb010p01Constant.FCDUO_NEXTVO);

				IDataList prevM1List = prevVo.GetList("M1");
				IDataList nextM1List = nextVo.GetList("M1");

				// 選択行の情報を取得する。
				Tb010f01M1Form prevM1Vo = (Tb010f01M1Form)prevM1List.GetPageViewList()[facadeContext.CommandInfo.ListIndex];

				// Dictionaryから検索条件を取得
				String tenpoCd = BoSystemFormat.formatTenpoCd((string)prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Head_tenpo_cd)]);
				String tenpoNm = (string)prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Head_tenpo_nm)];
				String denpyoJotai = (string)prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Denpyo_jyotai)];
				String oldJishahinban = BoSystemFormat.formatJisyaHbn((string)prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Old_jisya_hbn)]);
				String scanCd = BoSystemFormat.formatJanCd((string)prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Scan_cd)]);

				// 一覧の初期化
				nextM1List.ClearCacheData();
				nextM1List.Clear();

				#endregion

				#region 業務チェック

				#endregion

				#region 検索処理

				// [伝票状態]が空白、かつDictionary.[Ｍ１伝票状態] <> NULLの場合、
				// または、仕入入荷検索-一覧.[伝票状態]が"未処理"、"仕掛中"の場合、仕入入荷予定予定テーブルから検索する。
				string sSqlId = "";

				// 伝票状態によってSQL、テーブルを変更する
				switch (denpyoJotai)
				{
					// 「未処理」「仕掛中」の場合
					case ConditionSiiire_denpyo_jotai.VALUE_SIIIRE_DENPYO_JOTAI2:
					case ConditionSiiire_denpyo_jotai.VALUE_SIIIRE_DENPYO_JOTAI3:
						sSqlId = Tb010p01Constant.SQL_ID_07;
						break;

					// 「確定」「ﾏﾆｭｱﾙ仕入」「差異あり」の場合
					case ConditionSiiire_denpyo_jotai.VALUE_SIIIRE_DENPYO_JOTAI1:
					case ConditionSiiire_denpyo_jotai.VALUE_SIIIRE_DENPYO_JOTAI4:
					case ConditionSiiire_denpyo_jotai.VALUE_SIIIRE_DENPYO_JOTAI5:
						sSqlId = Tb010p01Constant.SQL_ID_08;
						break;

					// 「登録履歴」「取消履歴」の場合
					case ConditionSiiire_denpyo_jotai.VALUE_SIIIRE_DENPYO_JOTAI6:
					case ConditionSiiire_denpyo_jotai.VALUE_SIIIRE_DENPYO_JOTAI7:
						sSqlId = Tb010p01Constant.SQL_ID_09;
						break;

					// 空白の場合
					default:
						// Dictionary.[Ｍ１伝票状態] <> NULLの場合
						if(!string.IsNullOrEmpty(prevM1Vo.Dictionary[Tb010p01Constant.DIC_M1DENPYO_JYOTAI].ToString()))
						{
							sSqlId = Tb010p01Constant.SQL_ID_07;
						}
						// Dictionary.[Ｍ１伝票状態] = NULLの場合
						else
						{
							sSqlId = Tb010p01Constant.SQL_ID_08;
						}
						break;
				}

				FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(sSqlId, facadeContext.DBContext);

				// バインド値の置き換え
				// 仕入先コード
				rtSeach.BindValue(Tb010p01Constant.SQL_ID_07_REP_SIIRESAKI_CD, BoSystemFormat.formatSiiresakiCd(prevM1Vo.M1siiresaki_cd));
				// 伝票番号
				rtSeach.BindValue(Tb010p01Constant.SQL_ID_07_REP_DENPYO_BANGO, Convert.ToDecimal((string)prevM1Vo.Dictionary[Tb010p01Constant.DIC_M1DENPYO_BANGO]));
				// 入荷予定日
				rtSeach.BindValue(Tb010p01Constant.SQL_ID_07_REP_SITEINOHIN_YMD, Convert.ToDecimal(BoSystemFormat.formatDate(prevM1Vo.M1nyukayotei_ymd)));
				// 店舗コード
				rtSeach.BindValue(Tb010p01Constant.SQL_ID_07_REP_TENPO_CD, tenpoCd);

				if (Tb010p01Constant.SQL_ID_08.Equals(sSqlId) || Tb010p01Constant.SQL_ID_09.Equals(sSqlId))
				{
					// 確定種別
					rtSeach.BindValue(Tb010p01Constant.SQL_ID_07_REP_KAKUTEI_SB, Convert.ToDecimal((string)prevM1Vo.Dictionary[Tb010p01Constant.DIC_M1KAKUTEI_SB]));
				}

				if (Tb010p01Constant.SQL_ID_09.Equals(sSqlId))
				{
					// 履歴No
					rtSeach.BindValue(Tb010p01Constant.SQL_ID_07_REP_RIREKI_NO, Convert.ToDecimal((string)prevM1Vo.Dictionary[Tb010p01Constant.DIC_M1RIREKI_NO]));
					// 赤黒区分
					rtSeach.BindValue(Tb010p01Constant.SQL_ID_07_REP_AKAKURO_KBN, Convert.ToDecimal((string)prevM1Vo.Dictionary[Tb010p01Constant.DIC_M1AKAKURO_KBN]));
				}

				//検索結果を取得します
				rtSeach.CreateDbCommand();
				IList<Hashtable> tableList = rtSeach.Execute();

				decimal dNohinSuSum = 0;	// 納品数合計
				decimal dKenSuSum = 0;		// 検数合計
				decimal dKinSum = 0;		// 原価金額合計

				foreach (Hashtable rec in tableList)
				{
					Tb010f02M1Form f02m1VO = new Tb010f02M1Form();

					f02m1VO.M1rowno = rec["DENPYOGYO_NO"].ToString();						// Ｍ１行NO
					f02m1VO.M1hinsyu_ryaku_nm = rec["HINSYU_RYAKU_NM"].ToString();			// Ｍ１品種略名称
					f02m1VO.M1burando_nm = rec["BURANDO_NMK"].ToString();					// Ｍ１ブランド名
					f02m1VO.M1jisya_hbn = rec["JISYA_HBN"].ToString();						// Ｍ１自社品番
					f02m1VO.M1maker_hbn = rec["MAKER_HBN"].ToString();						// Ｍ１メーカー品番
					f02m1VO.M1syonmk = rec["SYONMK"].ToString();							// Ｍ１商品名(カナ)
					f02m1VO.M1iro_nm = rec["IRO_NM"].ToString();							// Ｍ１色
					f02m1VO.M1size_nm = rec["SIZE_NM"].ToString();							// Ｍ１サイズ
					f02m1VO.M1scan_cd = rec["JAN_CD"].ToString();							// Ｍ１スキャンコード
					f02m1VO.M1nohin_su = rec["YOTEI_SU"].ToString();						// Ｍ１納品数
					f02m1VO.M1gen_tnk = rec["GEN_TNK"].ToString();							// Ｍ１原単価
					string dKakuteiF = rec["KAKUTEI_FLG"].ToString();
					if (BoSystemString.Nvl(dKakuteiF, "0").Equals("0"))
					{
						f02m1VO.M1kensu = string.Empty;										// Ｍ１検数
						f02m1VO.M1genka_kin = (Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1gen_tnk, "0"))
												* Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1nohin_su, "0"))).ToString();
																							// Ｍ１原価金額
					}
					else
					{
						f02m1VO.M1kensu = rec["JISSEKI_SU"].ToString();						// Ｍ１検数
						f02m1VO.M1genka_kin = (Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1gen_tnk, "0"))
												* Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1kensu, "0"))).ToString();
																							// Ｍ１原価金額
					}
					f02m1VO.M1kyakucyu = rec["KYAKUTYU_FLG_MK"].ToString();					// Ｍ１客注
					f02m1VO.M1negaki = rec["NEGAKIHIN_FLG_MK"].ToString();					// Ｍ１値書

					f02m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;				// Ｍ１選択フラグ(隠し)
					f02m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;			// Ｍ１確定処理フラグ(隠し)

					// 仕入入荷検索-一覧.旧自社品番、スキャンコードと一致する場合
					string jancd = (string)prevVo.Dictionary[Tb010p01Constant.DIC_SEARCH_JANCD];
					string xebiocd = (string)prevVo.Dictionary[Tb010p01Constant.DIC_SEARCH_XEBIOCD];
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
					//	f02m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_SHOHIN_SHITEI;	// Ｍ１明細色区分(隠し)
					//}
					//else
					//{
					//	f02m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;
						
					//}

					// 合計値加算
					dNohinSuSum += Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1nohin_su, "0"));
					dKenSuSum += Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1kensu, "0"));
					dKinSum += Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1genka_kin, "0"));

					//リストオブジェクトにM1Formを追加します。
					nextM1List.Add(f02m1VO, true);

				}

				// 合計欄の設定
				nextVo.Gokei_nohin_su = dNohinSuSum.ToString();
				nextVo.Gokei_kensu = dKenSuSum.ToString();
				nextVo.Genka_kin_gokei = dKinSum.ToString();

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

				// 伝票番号
				nextVo.Denpyo_bango = (string)prevM1Vo.Dictionary[Tb010p01Constant.DIC_M1DENPYO_BANGO];
				// 元伝票番号
				nextVo.Motodenpyo_bango = prevM1Vo.M1motodenpyo_bango;
				// 仕入先コード
				nextVo.Siiresaki_cd = prevM1Vo.M1siiresaki_cd;
				// 仕入先名
				nextVo.Siiresaki_ryaku_nm = prevM1Vo.M1siiresaki_ryaku_nm;
				// 部門コード
				nextVo.Bumon_cd = prevM1Vo.M1bumon_cd;
				// 部門名
				nextVo.Bumon_nm = (string)prevM1Vo.Dictionary[Tb010p01Constant.DIC_M1BUMON_NM];
				// 担当者コード
				nextVo.Tantosya_cd = (string)prevM1Vo.Dictionary[Tb010p01Constant.DIC_M1TANTOSYA_CD];
				// 担当者名
				nextVo.Hanbaiin_nm = (string)prevM1Vo.Dictionary[Tb010p01Constant.DIC_M1TANTOSYA_NM];
				// 入荷予定日
				nextVo.Nyukayotei_ymd = prevM1Vo.M1nyukayotei_ymd;
				// 仕入確定日
				nextVo.Siire_kakutei_ymd = prevM1Vo.M1siire_kakutei_ymd;
				// 伝票状態名称
				nextVo.Denpyo_jyotainm = prevM1Vo.M1denpyo_jyotainm;
				// 処理名称
				nextVo.Syorinm = prevM1Vo.M1syorinm;
				// 処理日
				nextVo.Syoriymd = prevM1Vo.M1syoriymd;
				// 処理時間
				nextVo.Syori_tm = prevM1Vo.M1syori_tm;

				// 選択明細のVO
				nextVo.Dictionary[Tb010p01Constant.DIC_M1SELCETVO] = prevM1Vo;
				// 選択行のインデックスを設定
				nextVo.Dictionary[Tb010p01Constant.DIC_M1SELCETROWIDX] = facadeContext.CommandInfo.ListIndex.ToString();
				
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
			EndMethod(facadeContext, this.GetType().Name + ".DoM1DENPYO_BANGO_FRM");

		}
		#endregion
	}
}
