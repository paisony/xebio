using com.xebio.bo.Tk010p01.Constant;
using com.xebio.bo.Tk010p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.StringUtil;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;

namespace com.xebio.bo.Tk010p01.Facade
{
  /// <summary>
  /// Tk010f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tk010f01Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : M1tenpo_cd)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(M1tenpo_cd)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoM1TENPO_CD_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			////メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoM1TENPO_CD_FRM");

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
				Tk010f01Form prevVo = (Tk010f01Form)facadeContext.FormVO;
				Tk010f02Form nextVo = (Tk010f02Form)facadeContext.GetUserObject(Tk010p01Constant.FCDUO_NEXTVO);

				IDataList prevM1List = prevVo.GetList("M1");
				IDataList nextM1List = nextVo.GetList("M1");

				// 選択行の情報を取得する。
				Tk010f01M1Form prevM1Vo = (Tk010f01M1Form)prevM1List.GetPageViewList()[facadeContext.CommandInfo.ListIndex];

				// 一覧の初期化
				nextM1List.ClearCacheData();
				nextM1List.Clear();

				#endregion

				#region 業務チェック
				#endregion

				#region 検索処理

				string sSqlId = string.Empty;

				// 決裁状態
				switch (prevM1Vo.Dictionary[Tk010p01Constant.DIC_M1KESSAI_FLG].ToString())
				{
					case ConditionKessai_jotai.VALUE_KESSAI_JOTAI1:		// 未決裁
						sSqlId = Tk010p01Constant.SQL_ID_07;
						break;

					case ConditionKessai_jotai.VALUE_KESSAI_JOTAI2:		// 決裁済
						sSqlId = Tk010p01Constant.SQL_ID_08;
						break;

					default:
						break;
				} // switch

				FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(sSqlId, facadeContext.DBContext);

				// バインド値の置き換え
				// 店舗コード
				rtSeach.BindValue(Tk010p01Constant.BIND_TENPO_CD, BoSystemFormat.formatTenpoCd(prevM1Vo.Dictionary[Tk010p01Constant.DIC_M1TENPO_CD].ToString()));
				// 申請日
				rtSeach.BindValue(Tk010p01Constant.BIND_APPLY_YMD, Convert.ToDecimal(BoSystemFormat.formatDate(BoSystemString.Nvl(prevM1Vo.M1apply_ymd, "0"))));
				// 処理年月
				rtSeach.BindValue(Tk010p01Constant.BIND_SYORI_YMD, BoSystemString.LeftB(prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Syori_ym)].ToString(), 6) + "%");
				// 再申請フラグ
				rtSeach.BindValue(Tk010p01Constant.BIND_SAISHINSEI_FLG, Convert.ToDecimal(prevM1Vo.Dictionary[Tk010p01Constant.DIC_M1SAISHINSEI_FLG].ToString()));
				// 評価損種別1
				rtSeach.BindValue(Tk010p01Constant.BIND1_HYOKASONSYUBETSU, Convert.ToDecimal(prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Hyokasonsyubetsu_kb)].ToString()));
				// 評価損種別2
				rtSeach.BindValue(Tk010p01Constant.BIND2_HYOKASONSYUBETSU, Convert.ToDecimal(prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Hyokasonsyubetsu_kb)].ToString()));

				// 確定テーブル参照時のみ設定
				if (Tk010p01Constant.SQL_ID_08.Equals(sSqlId))
				{
					// 承認フラグ
					rtSeach.BindValue(Tk010p01Constant.BIND_SYONIN_FLG, Convert.ToDecimal(prevM1Vo.Dictionary[Tk010p01Constant.DIC_M1SYONIN_FLG].ToString()));
					string modeFlg = "0";
					// 修正モードフラグ
					if (BoSystemConstant.MODE_UPD.Equals(prevVo.Stkmodeno))
					{
						modeFlg = "1";
					}
					// 修正モードフラグ1
					rtSeach.BindValue(Tk010p01Constant.BIND1_UPD_FLG, modeFlg);
					// 修正モードフラグ2
					rtSeach.BindValue(Tk010p01Constant.BIND2_UPD_FLG, modeFlg);
				}

				//検索結果を取得します
				rtSeach.CreateDbCommand();

				IList<Hashtable> tableList = rtSeach.Execute();

				BoSystemLog.logOut("SQL: " + rtSeach.LogSql);

				if (tableList == null || tableList.Count <= 0)
				{
					// エラー
					ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
				}
				else
				{
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region 項目設定

				// 明細部
				int iCnt = 0;
				// 合計数計算
				Decimal dGokei_suryo = 0;
				Decimal dGenka_kin_gokei = 0;

				foreach (Hashtable rec in tableList)
				{
					Tk010f02M1Form f02m1VO = new Tk010f02M1Form();
					iCnt++;
					f02m1VO.M1rowno = iCnt.ToString();											// Ｍ１行NO
					f02m1VO.M1bumon_cd = rec["BUMON_CD"].ToString();							// Ｍ１部門コード
					f02m1VO.M1hinsyu_cd = rec["HINSYU_CD"].ToString();							// Ｍ１品種コード
					f02m1VO.M1burando_nm = rec["BURANDOKANA"].ToString();						// Ｍ１ブランド名
					f02m1VO.M1jisya_hbn = rec["JISYA_HBN"].ToString();							// Ｍ１自社品番
					f02m1VO.M1hanbaikanryo_ymd = BoSystemFormat.formatDate_yyMMdd(rec["HANBAIKANRYO_YMD"].ToString());
																								// Ｍ１販売完了日
					f02m1VO.M1maker_hbn = rec["MAKER_HBN"].ToString();							// Ｍ１メーカー品番
					f02m1VO.M1syonmk = rec["SYONMK"].ToString();								// Ｍ１商品名(カナ)
					f02m1VO.M1scan_cd = rec["JAN_CD"].ToString();								// Ｍ１スキャンコード
					f02m1VO.M1iro_nm = rec["IRO_NM"].ToString();								// Ｍ１色
					f02m1VO.M1size_nm = rec["SIZE_NM"].ToString();								// Ｍ１サイズ
					f02m1VO.M1genbaika_tnk = rec["JODAI1_TNK"].ToString();						// Ｍ１現売価
					f02m1VO.M1suryo = rec["HYOKASON_SU"].ToString();							// Ｍ１数量
					f02m1VO.M1gen_tnk = rec["GEN_TNK"].ToString();								// Ｍ１原単価
					// Ｍ１原価金額 ([Ｍ１原単価]×[M１数量])
					f02m1VO.M1genkakin = (Convert.ToDecimal(f02m1VO.M1gen_tnk) * Convert.ToDecimal(f02m1VO.M1suryo)).ToString();
					f02m1VO.M1nyuryoku_ymd = BoSystemFormat.formatDate_yyMMdd(rec["ADD_YMD"].ToString());
																								// Ｍ１入力日
					f02m1VO.M1apply_ymd = BoSystemFormat.formatDate_yyMMdd(rec["APPLY_YMD"].ToString());
																								// Ｍ１申請日
					f02m1VO.M1nyuryokusha_cd = rec["ADDTAN_CD"].ToString();						// Ｍ１入力者コード
					f02m1VO.M1sinseisya_cd = rec["UPD_TANCD"].ToString();						// Ｍ１申請者コード
					f02m1VO.M1hyokasonsyubetsu_kb = rec["HYOKASONSYUBETSU_KB"].ToString();		// Ｍ１評価損種別区分
					f02m1VO.M1hyokasonriyu_kb = rec["HYOKASONRIYU_KB"].ToString();				// Ｍ１評価損理由区分
					f02m1VO.M1hyokasonriyu = rec["HYOKASONRIYU"].ToString();					// Ｍ１評価損理由
					f02m1VO.M1kyakkariyu_kb = rec["KYAKKARIYU_KB"].ToString();					// Ｍ１却下理由区分
					f02m1VO.M1kyakkariyu = rec["KYAKKARIYU"].ToString();						// Ｍ１却下理由
					f02m1VO.M1tyotatsu_nm = rec["TYOTATSU_KB_NM"].ToString();					// Ｍ１調達区分名称
					// Ｍ１承認状態
					// [選択モードNo]が「修正」「照会」の場合で、[評価損確定TBL].[承認状態]が1:承認の場合、チェック
					if ((BoSystemConstant.MODE_REF.Equals(prevVo.Stkmodeno) || BoSystemConstant.MODE_UPD.Equals(prevVo.Stkmodeno))
						&& (ConditionSyonin_jotai2.VALUE_SYONIN_JOTAI21).Equals(rec["SYONIN_FLG"].ToString()))
					{
						f02m1VO.M1syonin_flg = BoSystemConstant.CHECKBOX_ON;
					}
					else
					{
						f02m1VO.M1syonin_flg = BoSystemConstant.CHECKBOX_OFF;
					}
					// Ｍ１却下フラグ
					// [選択モードNo]が「修正」「照会」の場合で、[評価損確定TBL].[承認状態]が2:却下の場合、チェック
					if ((BoSystemConstant.MODE_REF.Equals(prevVo.Stkmodeno) || BoSystemConstant.MODE_UPD.Equals(prevVo.Stkmodeno))
						&& (ConditionSyonin_jotai2.VALUE_SYONIN_JOTAI22).Equals(rec["SYONIN_FLG"].ToString()))
					{
						f02m1VO.M1kyakka_flg = BoSystemConstant.CHECKBOX_ON;
					}
					else
					{
						f02m1VO.M1kyakka_flg = BoSystemConstant.CHECKBOX_OFF;
					}

					f02m1VO.M1suryo_hdn = f02m1VO.M1suryo;															// Ｍ１数量（隠し）
					f02m1VO.M1genkakin_hdn = f02m1VO.M1genkakin;													// Ｍ１原価金額（隠し）
					f02m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;										// Ｍ１選択フラグ(隠し)
					f02m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;									// Ｍ１確定処理フラグ
					f02m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;										// Ｍ１明細色区分(隠し)

					// 合計値計算
					// Ｍ１店舗合計数量
					dGokei_suryo += Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1suryo, "0"));
					// Ｍ１店舗合計原価金額
					dGenka_kin_gokei += Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1genkakin, "0"));

					// Dictionary
					f02m1VO.Dictionary[Tk010p01Constant.DIC_M1KANRI_NO] = rec["KANRI_NO"].ToString();				// 管理No
					f02m1VO.Dictionary[Tk010p01Constant.DIC_M1GYO_NBR] = rec["GYO_NBR"].ToString();					// 行No
					f02m1VO.Dictionary[Tk010p01Constant.DIC_M1SYORI_YMD] = rec["SYORI_YMD"].ToString();				// 処理日付
					f02m1VO.Dictionary[Tk010p01Constant.DIC_M1SYORI_TM] = rec["SYORI_TM"].ToString();				// 処理時間
					f02m1VO.Dictionary[Tk010p01Constant.DIC_M1BURANDO_CD] = rec["BURANDO_CD"].ToString();			// ブランドコード
					f02m1VO.Dictionary[Tk010p01Constant.DIC_M1SIZE_CD] = rec["SIZE_CD"].ToString();					// サイズコード
					f02m1VO.Dictionary[Tk010p01Constant.DIC_M1IRO_CD] = rec["IRO_CD"].ToString();					// 色コード
					f02m1VO.Dictionary[Tk010p01Constant.DIC_M1SYOHIN_CD] = rec["SYOHIN_CD"].ToString();				// 商品コード
					f02m1VO.Dictionary[Tk010p01Constant.DIC_M1TYOTATSU_KB] = rec["TYOTATSU_KB"].ToString();			// 調達区分
					f02m1VO.M1bumon_nm = rec["BUMONKANA"].ToString();												// 部門カナ名　※ツールチップ
					f02m1VO.M1hinsyu_ryaku_nm = rec["HINSYU_RYAKU_NM"].ToString();									// 品種略名称　※ツールチップ

					// 元数量、原価金額、調達区分を退避 一覧再表示用
					f02m1VO.Dictionary[Tk010p01Constant.DIC_M1SURYO_MOTO] = f02m1VO.M1suryo;						// 元数量
					f02m1VO.Dictionary[Tk010p01Constant.DIC_M1GENKA_KIN_MOTO] = f02m1VO.M1genkakin;					// 元原価金額
					f02m1VO.Dictionary[Tk010p01Constant.DIC_M1TYOTATSU_KB_MOTO] = rec["TYOTATSU_KB"].ToString();	// 元調達区分

					//リストオブジェクトにM1Formを追加します。
					nextM1List.Add(f02m1VO, true);

				}

				// カード部
				nextVo.Head_tenpo_cd = prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Head_tenpo_cd)].ToString();		// ヘッダ店舗コード
				nextVo.Head_tenpo_nm = prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Head_tenpo_nm)].ToString();		// ヘッダ店舗名
				nextVo.Stkmodeno = prevVo.Stkmodeno;																				// 選択モード
				nextVo.Syori_ym = prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Syori_ym)].ToString();				// 処理月
				nextVo.Tenpo_cd = BoSystemFormat.formatTenpoCd(prevM1Vo.Dictionary[Tk010p01Constant.DIC_M1TENPO_CD].ToString());	// 店舗コード
				nextVo.Tenpo_nm = prevM1Vo.Dictionary[Tk010p01Constant.DIC_M1TENPO_NM].ToString();									// 店舗名
				nextVo.Syonin_flg_nm = prevM1Vo.M1syonin_flg_nm.ToString();															// 承認状態名称
				nextVo.Kessai_flg_nm = prevM1Vo.M1kessai_flg_nm.ToString();															// 決裁状態名称
				nextVo.Apply_ymd = prevM1Vo.M1apply_ymd.ToString();																	// 申請日
				nextVo.Ikkatsukyakka_kyakkariyu_kb = BoSystemConstant.DROPDOWNLIST_MISENTAKU;										// 一括却下用却下理由区分
				nextVo.Ikkatsukyakka_kyakkariyu = string.Empty;																		// 一括却下用却下理由
				nextVo.Dictionary[Tk010p01Constant.DIC_M1UPD_YMD] = prevM1Vo.Dictionary[Tk010p01Constant.DIC_M1UPD_YMD];			// Ｍ１更新日
				nextVo.Dictionary[Tk010p01Constant.DIC_M1UPD_TM] = prevM1Vo.Dictionary[Tk010p01Constant.DIC_M1UPD_YMD];				// Ｍ１更新時間

				// 合計数量
				nextVo.Gokei_suryo = dGokei_suryo.ToString();
				// 合計原価金額
				nextVo.Haibun_kin_gokei = dGenka_kin_gokei.ToString();
				// 選択明細のVO
				nextVo.Dictionary[Tk010p01Constant.DIC_M1SELCETVO] = prevM1Vo;
				// 選択行のインデックスを設定
				nextVo.Dictionary[Tk010p01Constant.DIC_M1SELCETROWIDX] = facadeContext.CommandInfo.ListIndex.ToString();
				// VOをディクショナリに設定
				nextVo.Dictionary[Tk010p01Constant.DIC_F1VO] = prevVo;

				// 選択した行に対する承認状態の行があった場合、ディクショナリに設定
				for (int i = 0; i < prevM1List.Count; i++)
				{
					Tk010f01M1Form f01m1VO = (Tk010f01M1Form)prevM1List[i];

					// 選択行は飛ばす
					if (f01m1VO.M1rowno.Equals(prevM1Vo.M1rowno))
					{
						continue;
					}

					// 店舗コード、申請日が一致して、承認状態に差異のある行の存在チェック
					if (f01m1VO.Dictionary[Tk010p01Constant.DIC_M1TENPO_CD].ToString().Equals(prevM1Vo.Dictionary[Tk010p01Constant.DIC_M1TENPO_CD].ToString())
						&& f01m1VO.M1apply_ymd.Equals(prevM1Vo.M1apply_ymd)
						&& !f01m1VO.Dictionary[Tk010p01Constant.DIC_M1SYONIN_FLG].ToString().Equals(prevM1Vo.Dictionary[Tk010p01Constant.DIC_M1SYONIN_FLG].ToString()))
					{
						// 対象行をディクショナリに設定
						nextVo.Dictionary[Tk010p01Constant.DIC_M1SELCETVO2] = f01m1VO;
					}
				}

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
			EndMethod(facadeContext, this.GetType().Name + ".DoM1TENPO_CD_FRM");

		}
		#endregion
	}
}
