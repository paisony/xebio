using com.xebio.bo.Tl030p01.Constant;
using com.xebio.bo.Tl030p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;

namespace com.xebio.bo.Tl030p01.Facade
{
  /// <summary>
  /// Tl030f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tl030f01Facade : StandardBaseFacade
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

			////メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoM1BUMON_CD_FRM");

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
				Tl030f01Form prevVo = (Tl030f01Form)facadeContext.FormVO;
				Tl030f02Form nextVo = (Tl030f02Form)facadeContext.GetUserObject(Tl030p01Constant.FCDUO_NEXTVO);

				IDataList prevM1List = prevVo.GetList("M1");
				IDataList nextM1List = nextVo.GetList("M1");

				// 選択行の情報を取得する。
				Tl030f01M1Form prevM1Vo = (Tl030f01M1Form)prevM1List.GetPageViewList()[facadeContext.CommandInfo.ListIndex];

				// 一覧の初期化
				nextM1List.ClearCacheData();
				nextM1List.Clear();

				#endregion

				#region 業務チェック
				#endregion

				#region 検索処理

				// 検索条件設定
				String sSqlId = string.Empty;

				// 選択行.[Dictionary.Ｍ１申請元区分]の内容に応じて、検索テーブルを変更
				// 選択行.[Dictionary.Ｍ１申請元区分]が１：本部の場合、売価変更指示TBLから検索
				// 選択行.[Dictionary.Ｍ１申請元区分]が２：店舗の場合、店舗売変予定TBLから検索
				if (ConditionSinseimoto.VALUE_SINSEIMOTO1.Equals(prevM1Vo.Dictionary[Tl030p01Constant.DIC_M1SINSEIMOTO_KBN].ToString()))
				{
					// SQL設定
					sSqlId = Tl030p01Constant.SQL_ID_04;		
				}
				else if (ConditionSinseimoto.VALUE_SINSEIMOTO2.Equals(prevM1Vo.Dictionary[Tl030p01Constant.DIC_M1SINSEIMOTO_KBN].ToString()))
				{
					sSqlId = Tl030p01Constant.SQL_ID_05;
				}
				else
				{
					// 入らない
				}

				// SQL文作成
				FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(sSqlId, facadeContext.DBContext);

				// バインド値の置き換え

				// 売価変更指示TBLを検索する場合
				if (ConditionSinseimoto.VALUE_SINSEIMOTO1.Equals(prevM1Vo.Dictionary[Tl030p01Constant.DIC_M1SINSEIMOTO_KBN].ToString()))
				{
					// シーケンス
					rtSeach.BindValue("BIND_SEQ", Convert.ToDecimal(prevVo.Dictionary[Tl030p01Constant.DIC_SEQ].ToString()));
					rtSeach.BindValue("BIND_SEQ_02", Convert.ToDecimal(prevVo.Dictionary[Tl030p01Constant.DIC_SEQ].ToString()));

					// 現売価=指示売価のみフラグ
					decimal dBaikaequal_flg = 0;
					if (BoSystemConstant.CHECKBOX_ON.Equals(prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Genbaika_shijibaika_flg)].ToString()))
					{
						dBaikaequal_flg = 1;
					}

					// 現売価=指示売価のみフラグ
					rtSeach.BindValue("BIND_BAIKAEQUAL_FLG_01", dBaikaequal_flg);
					rtSeach.BindValue("BIND_BAIKAEQUAL_FLG_02", dBaikaequal_flg);

					// 店舗コード
					String stenpo_cd = BoSystemFormat.formatTenpoCd(prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Head_tenpo_cd)].ToString());

					rtSeach.BindValue("BIND_TENPO_CD_01", stenpo_cd);
					rtSeach.BindValue("BIND_TENPO_CD_02", stenpo_cd);
					rtSeach.BindValue("BIND_TENPO_CD_03", stenpo_cd);
					rtSeach.BindValue("BIND_TENPO_CD_04", stenpo_cd);
					rtSeach.BindValue("BIND_TENPO_CD_05", stenpo_cd);
					rtSeach.BindValue("BIND_TENPO_CD_06", stenpo_cd);
					rtSeach.BindValue("BIND_TENPO_CD_07", stenpo_cd);
					rtSeach.BindValue("BIND_TENPO_CD_08", stenpo_cd);

					// 売変開始日
					rtSeach.BindValue("BIND_BAIHENKAISI_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(prevM1Vo.M1baihenkaisi_ymd)));

					// 売変No
					rtSeach.BindValue("BIND_BAIHEN_NO", BoSystemFormat.formatBaihen_shiji_no(prevM1Vo.Dictionary[Tl030p01Constant.DIC_M1BAIHEN_NO].ToString()));

					// 部門コード
					rtSeach.BindValue("BIND_BUMON_CD", BoSystemFormat.formatBumonCd(prevM1Vo.Dictionary[Tl030p01Constant.DIC_M1BUMON_CD].ToString()));

					// 売変作業開始日
					rtSeach.BindValue("BIND_BAIHENSAGYOKAISI_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(prevM1Vo.M1baihensagyokaisi_ymd)));

					// 売変理由
					rtSeach.BindValue("BIND_BAIHEN_RIYTU", Convert.ToDecimal(prevM1Vo.Dictionary[Tl030p01Constant.DIC_M1BAIHEN_RIYTU].ToString()));

				}
				// 店舗売変予定TBLを検索する場合
				else if (ConditionSinseimoto.VALUE_SINSEIMOTO2.Equals(prevM1Vo.Dictionary[Tl030p01Constant.DIC_M1SINSEIMOTO_KBN].ToString()))
				{
					// シーケンス
					rtSeach.BindValue("BIND_SEQ", Convert.ToDecimal(prevVo.Dictionary[Tl030p01Constant.DIC_SEQ].ToString()));
					rtSeach.BindValue("BIND_SEQ_02", Convert.ToDecimal(prevVo.Dictionary[Tl030p01Constant.DIC_SEQ].ToString()));

					// 現売価=指示売価のみフラグ
					decimal dBaikaequal_flg = 0;
					if (BoSystemConstant.CHECKBOX_ON.Equals(prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Genbaika_shijibaika_flg)].ToString()))
					{
						dBaikaequal_flg = 1;
					}

					// 現売価=指示売価のみフラグ
					rtSeach.BindValue("BIND_BAIKAEQUAL_FLG_01", dBaikaequal_flg);

					// 店舗コード
					String stenpo_cd = BoSystemFormat.formatTenpoCd(prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Head_tenpo_cd)].ToString());

					rtSeach.BindValue("BIND_TENPO_CD_01", stenpo_cd);
					rtSeach.BindValue("BIND_TENPO_CD_02", stenpo_cd);
					rtSeach.BindValue("BIND_TENPO_CD_03", stenpo_cd);
					rtSeach.BindValue("BIND_TENPO_CD_04", stenpo_cd);
					rtSeach.BindValue("BIND_TENPO_CD_05", stenpo_cd);

					// 売変開始日
					rtSeach.BindValue("BIND_BAIHENKAISI_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(prevM1Vo.M1baihenkaisi_ymd)));

					// 売変No
					rtSeach.BindValue("BIND_BAIHEN_NO", BoSystemFormat.formatBaihen_shiji_no(prevM1Vo.Dictionary[Tl030p01Constant.DIC_M1BAIHEN_NO].ToString()));

					// 部門コード
					rtSeach.BindValue("BIND_BUMON_CD", BoSystemFormat.formatBumonCd(prevM1Vo.Dictionary[Tl030p01Constant.DIC_M1BUMON_CD].ToString()));

				}
				else
				{
					// 例外
				}

				//検索結果を取得します
				rtSeach.CreateDbCommand();

				IList<Hashtable> tableList = rtSeach.Execute();

				// BoSystemLog.logOut("SQL: " + rtSeach.LogSql);

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

				#region 明細部設定

				int iCnt = 0;
				foreach (Hashtable rec in tableList)
				{
					Tl030f02M1Form f02m1VO = new Tl030f02M1Form();
					iCnt++;
					f02m1VO.M1rowno = iCnt.ToString();												// Ｍ１行NO
					f02m1VO.M1hinsyu_ryaku_nm = rec["HINSYU_RYAKU_NM"].ToString();					// Ｍ１品種略名称
					f02m1VO.M1burando_nm = rec["BURANDO_NMK"].ToString();							// Ｍ１ブランド名
					f02m1VO.M1jisya_hbn = rec["JISYA_HBN"].ToString();								// Ｍ１自社品番
					f02m1VO.M1maker_hbn = rec["MAKER_HBN"].ToString();								// Ｍ１メーカー品番
					f02m1VO.M1syonmk = rec["SYONMK"].ToString();									// Ｍ１商品名(カナ)
					f02m1VO.M1iro_nm = rec["IRO_NM"].ToString();									// Ｍ１色
					f02m1VO.M1season_kb = rec["SEASON_KB"].ToString();								// Ｍ１シーズン
					f02m1VO.M1hanbaikanryo_ymd = rec["HANBAIKANRYO_YMD"].ToString();				// Ｍ１販売完了日
					f02m1VO.M1mtobaika_tnk = rec["GENBAIKA_TNK"].ToString();						// Ｍ１元売価
					f02m1VO.M1gen_tnk = rec["GEN_TNK"].ToString();									// Ｍ１原単価
					f02m1VO.M1yobobaika_tnk = rec["SIJIBAIKA_TNK"].ToString();						// Ｍ１要望売価
					f02m1VO.M1kakuteibaika_tnk = rec["KAKUTEIBAIKA_TNK"].ToString();					// Ｍ１確定売価
					f02m1VO.M1neire_rtu_genko = NeireCalc(f02m1VO.M1mtobaika_tnk, f02m1VO.M1gen_tnk).ToString("F1");
																									// Ｍ１値入率現行
					f02m1VO.M1neire_rtu_baihengo = NeireCalc(f02m1VO.M1kakuteibaika_tnk, f02m1VO.M1gen_tnk).ToString("F1");
																									// Ｍ１値入率売変後
					f02m1VO.M1zaiko_su = rec["ZAIKO_SU"].ToString();								// Ｍ１在庫数
					f02m1VO.M1uriage_su = rec["URIAGE_SU"].ToString();								// Ｍ１売上数

					// [売変確定(X)-一覧画面(Dictionary)].Ｍ１カラー展開売変可能フラグ=0の場合チェックボックスはOFFとする
					if(("0").Equals(rec["CHG_FLG"].ToString()))
					{
						f02m1VO.M1syonin_flg = BoSystemConstant.CHECKBOX_OFF;
						f02m1VO.M1kyakka_flg = BoSystemConstant.CHECKBOX_OFF;
					}
					else
					{
						if (ConditionSinseimoto.VALUE_SINSEIMOTO1.Equals(prevM1Vo.Dictionary[Tl030p01Constant.DIC_M1SINSEIMOTO_KBN].ToString()))
						{
							// 本部で承認フラグが3の場合、承認フラグをチェック状態とする
							if (("3").Equals(rec["SHONIN_FLG"].ToString()))
							{
								f02m1VO.M1syonin_flg = BoSystemConstant.CHECKBOX_ON;
							}

							// 本部で承認フラグが4の場合、却下フラグをチェック状態とする
							if (("4").Equals(rec["SHONIN_FLG"].ToString()))
							{
								f02m1VO.M1kyakka_flg = BoSystemConstant.CHECKBOX_ON;
							}

						}
						else if (ConditionSinseimoto.VALUE_SINSEIMOTO2.Equals(prevM1Vo.Dictionary[Tl030p01Constant.DIC_M1SINSEIMOTO_KBN].ToString()))
						{

							// 確定している場合、承認フラグを元に決定する
							if (("1").Equals(rec["SHONIN_FLG"].ToString()))
							{
								f02m1VO.M1syonin_flg = BoSystemConstant.CHECKBOX_ON;
							}
							else if (("2").Equals(rec["SHONIN_FLG"].ToString()))
							{
								f02m1VO.M1kyakka_flg = BoSystemConstant.CHECKBOX_ON;
							}
							else
							{
								// 入らない
							}
						}
					}

					f02m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;			// Ｍ１選択フラグ(隠し)

					if (!String.IsNullOrEmpty(rec["UPD_TANCD_WK"].ToString()))
					{
						f02m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_ARI;	// Ｍ１確定処理フラグ(隠し)
						f02m1VO.Dictionary[Tl030p01Constant.DIC_M1ENTERSYORIFLG] = ConditionKakuteisyori_flg.VALUE_ARI;	// Ｍ１確定処理フラグ(隠し)(初期状態)
					}
					else
					{
						f02m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;	// Ｍ１確定処理フラグ(隠し)
						f02m1VO.Dictionary[Tl030p01Constant.DIC_M1ENTERSYORIFLG] = ConditionKakuteisyori_flg.VALUE_NASI;	// Ｍ１確定処理フラグ(隠し)(初期状態)
					}

					// Dictionary 
					// 売変開始日
					f02m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHENKAISI_YMD] = rec["BAIHENKAISI_YMD"].ToString();
					// 売変終了日
					f02m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHENSYURYO_YMD] = rec["BAIHENSYURYO_YMD"].ToString();
					// 売変№
					f02m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHEN_NO] = rec["BAIHEN_NO"].ToString();
					// 売変行№
					f02m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHENGYO_NO] = rec["BAIHENGYO_NO"].ToString();
					// 品種コード
					f02m1VO.Dictionary[Tl030p01Constant.DIC_M1HINSYU_CD] = rec["HINSYU_CD"].ToString();
					// ブランドコード
					f02m1VO.Dictionary[Tl030p01Constant.DIC_M1BURANDO_CD] = rec["BURANDO_CD"].ToString();
					// 上代１
					f02m1VO.Dictionary[Tl030p01Constant.DIC_M1JODAI1_TNK] = rec["JODAI1_TNK"].ToString();
					// 色コード
					f02m1VO.Dictionary[Tl030p01Constant.DIC_M1IRO_CD] = rec["IRO_CD"].ToString();
					// ハンドラベル
					f02m1VO.Dictionary[Tl030p01Constant.DIC_M1HANDLBL_KB] = rec["HANDLBL_KB"].ToString();
					// 旧自社品番カラー展開フラグ
					f02m1VO.Dictionary[Tl030p01Constant.DIC_M1JISYA_HBN_COLOR_TENKAI_FLG] = rec["OLD_COLOR_FLG"].ToString();
					// カラー展開売変可能フラグ
					f02m1VO.Dictionary[Tl030p01Constant.DIC_M1COLOR_TENKAI_BAIKA_KAHEN_FLG] = rec["CHG_FLG"].ToString();
					// 自社品番件数
					f02m1VO.Dictionary[Tl030p01Constant.DIC_M1JISYA_HBN_KENSU] = rec["JISYA_HBN_CNT"].ToString();

					//リストオブジェクトにM1Formを追加します。
					nextM1List.Add(f02m1VO, true);
				}

				#endregion

				#region カード部設定
				// ヘッダ店舗コード
				nextVo.Head_tenpo_cd = BoSystemFormat.formatTenpoCd(prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Head_tenpo_cd)].ToString());
				// ヘッダ店舗名	
				nextVo.Head_tenpo_nm = BoSystemFormat.formatTenpoCd(prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Head_tenpo_nm)].ToString());
				// 申請元名称
				nextVo.Shinseimoto_nm = prevM1Vo.M1shinseimoto_nm;
				// 申請担当者コード
				nextVo.Sinseitan_cd = prevM1Vo.Dictionary[Tl030p01Constant.DIC_M1SINSEITAN_CD].ToString();
				// 申請担当者名称
				nextVo.Sinseitan_nm = prevM1Vo.M1sinseitan_nm;
				// 部門コード
				nextVo.Bumon_cd = prevM1Vo.Dictionary[Tl030p01Constant.DIC_M1BUMON_CD].ToString();
				// 部門名
				nextVo.Bumon_nm = prevM1Vo.Dictionary[Tl030p01Constant.DIC_M1BUMON_NM].ToString();
				// 売変指示No
				nextVo.Baihen_shiji_no = prevM1Vo.M1baihen_shiji_no;
				// 売変理由名称
				nextVo.Baihen_riyu_nm = prevM1Vo.M1baihen_riyu_nm;
				// 売変作業開始日
				nextVo.Aihensagyokaisi_ymd = prevM1Vo.M1baihensagyokaisi_ymd;
				// 売変作業開始日
				nextVo.Baihenkaisi_ymd = prevM1Vo.M1baihenkaisi_ymd;
				// 現売価 = 指示売価
				nextVo.Dictionary[Tl030p01Constant.DIC_GENBAIKA_SHIJIBAIKA_FLG] = prevVo.Genbaika_shijibaika_flg;
				// シーケンス
				nextVo.Dictionary[Tl030p01Constant.DIC_SEQ] = prevVo.Dictionary[Tl030p01Constant.DIC_SEQ].ToString();

				// 選択明細のVO
				nextVo.Dictionary[Tl030p01Constant.DIC_M1SELCETVO] = prevM1Vo;
				// 選択行のインデックスを設定
				nextVo.Dictionary[Tl030p01Constant.DIC_M1SELCETROWIDX] = facadeContext.CommandInfo.ListIndex.ToString();

				// システム日付をVoに保持する
				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);
				nextVo.Dictionary[Tl030p01Constant.DIC_SYSDATE] = sysDateVO.Sysdate.ToString();

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

		#region ユーザー定義関数

		#region 値入率計算
		/// <summary>
		/// NeireCalc 値入率計算
		/// </summary>
		/// <param name="String">売価(要望売価、確定売価)</param>
		/// <param name="String">原単価</param>
		/// <returns></returns>
		private double NeireCalc(String baika, String tanka)
		{
			double dRt = 0.0;

			// Ｍ１値入率現行計算 (（[M1要望売価] － [M1原単価]）／[M1要望売価]) × 100
			// Ｍ１値入率売変後計算(（[M1確定売価] － [M1原単価]）／[M1確定売価]) × 100
			if (!"0".Equals(baika))
			{
				double baika_tnk = Convert.ToDouble(baika);
				double gen_tnk = Convert.ToDouble(tanka);
				dRt = Math.Round(((baika_tnk - gen_tnk) / baika_tnk) * 100,2);
			}

			return dRt;
		}
		#endregion

		#endregion

	}
}
