using com.xebio.bo.Tj190p01.Constant;
using com.xebio.bo.Tj190p01.Formvo;
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

namespace com.xebio.bo.Tj190p01.Facade
{
  /// <summary>
  /// Tj190f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tj190f01Facade : StandardBaseFacade
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
				Tj190f01Form prevVo = (Tj190f01Form)facadeContext.FormVO;
				Tj190f02Form nextVo = (Tj190f02Form)facadeContext.GetUserObject(Tj190p01Constant.FCDUO_NEXTVO);

				IDataList prevM1List = prevVo.GetList("M1");
				IDataList nextM1List = nextVo.GetList("M1");

				// 選択行の情報を取得する。
				Tj190f01M1Form prevM1Vo = (Tj190f01M1Form)prevM1List.GetPageViewList()[facadeContext.CommandInfo.ListIndex];

				// 一覧の初期化
				nextM1List.ClearCacheData();
				nextM1List.Clear();

				#endregion

				#region 業務チェック
				#endregion

				#region 検索処理

				// 検索条件設定
				String sSqlId = string.Empty;
				String sKnrNo = string.Empty;

				// [選択モードNo]が「修正」、「取消」、「照会」、「ロス計算」の場合、[臨時棚卸TBL(B)]から検索する。
				if (BoSystemConstant.MODE_UPD.Equals(prevVo.Stkmodeno)
					|| BoSystemConstant.MODE_DEL.Equals(prevVo.Stkmodeno)
					|| BoSystemConstant.MODE_REF.Equals(prevVo.Stkmodeno)
					|| BoSystemConstant.MODE_LOSSKEISAN.Equals(prevVo.Stkmodeno))
				{
					sSqlId = Tj190p01Constant.SQL_ID_03;
					// 臨棚管理Noを設定
					sKnrNo = prevM1Vo.M1rintana_kanri_no;
				}
				// [選択モードNo]が「ロス取消」、「ロス照会」の場合、[臨時棚卸ロスTBL(B)]から検索する。
				else if (BoSystemConstant.MODE_LOSSDEL.Equals(prevVo.Stkmodeno)
					|| BoSystemConstant.MODE_LOSSREF.Equals(prevVo.Stkmodeno))
				{
					sSqlId = Tj190p01Constant.SQL_ID_04;
					// ロス管理Noを設定
					sKnrNo = prevM1Vo.M1loss_kanri_no;
				}
				else
				{

				}
				FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(sSqlId, facadeContext.DBContext);

				// バインド値の置き換え
				// 店舗コード
				rtSeach.BindValue(Tj190p01Constant.SQL_ID_03_BIND_TENPO_CD, BoSystemFormat.formatTenpoCd(prevM1Vo.M1tenpo_cd));
				// 臨棚管理№/ロス管理No
				rtSeach.BindValue(Tj190p01Constant.SQL_ID_03_BIND_KANRI_NO, Convert.ToDecimal(BoSystemString.Nvl(sKnrNo, "0")));
				// 処理日付
				rtSeach.BindValue(Tj190p01Constant.SQL_ID_03_BIND_SYORI_YMD, Convert.ToDecimal(BoSystemString.Nvl((string)prevM1Vo.Dictionary[Tj190p01Constant.DIC_M1SYORI_YMD], "0")));

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

				#region 明細部設定

				int iCnt = 0;
				String old_xebio_cd = string.Empty;

				// 合計数計算
				Decimal dGokeitanajityobo_su = 0;
				Decimal dGokeitanajisekiso_su = 0;
				Decimal dGokeijitana_su = 0;
				Decimal dGokeiloss_su = 0;
				Decimal dGokeiloss_kin = 0;

				foreach (Hashtable rec in tableList)
				{
					Tj190f02M1Form f02m1VO = new Tj190f02M1Form();
					iCnt++;
					f02m1VO.M1rowno = iCnt.ToString();								// Ｍ１行NO
					f02m1VO.M1hinsyu_ryaku_nm = rec["HINSYU_RYAKU_NM"].ToString();	// Ｍ１品種略名称
					f02m1VO.M1burando_nm = rec["BURANDO_NMK"].ToString();			// Ｍ１ブランド名
					f02m1VO.M1jisya_hbn = rec["JISYA_HBN"].ToString();				// Ｍ１自社品番
					f02m1VO.M1maker_hbn = rec["MAKER_HBN"].ToString();				// Ｍ１メーカー品番
					f02m1VO.M1syonmk = rec["SYONMK"].ToString();					// Ｍ１商品名(カナ)
					f02m1VO.M1iro_nm = rec["IRO_NM"].ToString();					// Ｍ１色
					f02m1VO.M1size_nm = rec["SIZE_NM"].ToString();					// Ｍ１サイズ
					f02m1VO.M1scan_cd = rec["JAN_CD"].ToString();					// Ｍ１スキャンコード
					f02m1VO.M1hyoka_tnk = rec["HYOKA_TNK"].ToString();				// Ｍ１評価単価
					f02m1VO.M1tanajityobo_su = rec["TANAJITYOBO_SU"].ToString();	// Ｍ１棚時帳簿数
					f02m1VO.M1tanajityobo_su_hdn = rec["TANAJITYOBO_SU"].ToString();
																					// Ｍ１棚時帳簿数(隠し)
					f02m1VO.M1tanajisekiso_su = rec["TANAJISEKISO_SU"].ToString();	// Ｍ１棚時積送数
					f02m1VO.M1tanajisekiso_su_hdn = rec["TANAJISEKISO_SU"].ToString();
																					// Ｍ１棚時積送数(隠し)
					f02m1VO.M1jitana_su = rec["JITANA_SU"].ToString();				// Ｍ１実棚数
					f02m1VO.M1jitana_su1_hdn = rec["JITANA_SU"].ToString();			// Ｍ１実棚数（隠し）
					f02m1VO.M1loss_su = rec["LOSS_SU"].ToString();					// Ｍ１ロス数
					f02m1VO.M1loss_kin = rec["LOSS_KIN"].ToString();				// Ｍ１ロス金額
					f02m1VO.M1selectorcheckbox = "0";								// Ｍ１選択フラグ(隠し)
					f02m1VO.M1entersyoriflg = "0";									// Ｍ１確定処理フラグ(隠し)
					f02m1VO.M1dtlirokbn = "";										// Ｍ１明細色区分(隠し)
					// 旧自社品番保持
					old_xebio_cd = rec["OLD_JISYA_HBN"].ToString();

					f02m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;

					// 自社品番が入力されていた場合
					if (!string.IsNullOrEmpty(prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Old_jisya_hbn)].ToString()))
					{
						// 自社品番が一致するか検査
						if (f02m1VO.M1jisya_hbn.Equals(prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Old_jisya_hbn)].ToString()))
						{
							f02m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_SHOHIN_SHITEI;
						}

						// 旧自社品番が一致するか検査
						if (old_xebio_cd.Equals(prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Old_jisya_hbn)].ToString()))
						{
							f02m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_SHOHIN_SHITEI;
						}
					}

					// スキャンコードが入力されていた場合
					if (!string.IsNullOrEmpty(prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Scan_cd)].ToString()))
					{
						// スキャンコードが一致するか検査
						if (f02m1VO.M1scan_cd.Equals(prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Scan_cd)].ToString()))
						{
							f02m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_SHOHIN_SHITEI;
						}
					}

					// Ｍ１棚時帳簿数の合計
					dGokeitanajityobo_su += Convert.ToDecimal(BoSystemString.Nvl(rec["TANAJITYOBO_SU"].ToString(), "0"));
					// Ｍ１棚時積送数の合計
					dGokeitanajisekiso_su += Convert.ToDecimal(BoSystemString.Nvl(rec["TANAJISEKISO_SU"].ToString(), "0"));
					// Ｍ１実棚数の合計
					dGokeijitana_su += Convert.ToDecimal(BoSystemString.Nvl(rec["JITANA_SU"].ToString(), "0"));
					// Ｍ１ロス数の合計
					dGokeiloss_su += Convert.ToDecimal(BoSystemString.Nvl(rec["LOSS_SU"].ToString(), "0"));
					// Ｍ１ロス金額の合計
					dGokeiloss_kin += Convert.ToDecimal(BoSystemString.Nvl(rec["LOSS_KIN"].ToString(), "0"));

					//リストオブジェクトにM1Formを追加します。
					nextM1List.Add(f02m1VO, true);
				}

				#endregion

				#region カード部設定

				nextVo.Head_tenpo_cd = prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Head_tenpo_cd)].ToString();		// ヘッダ店舗コード
				nextVo.Head_tenpo_nm = prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Head_tenpo_nm)].ToString();		// ヘッダ店舗名
				nextVo.Stkmodeno = prevVo.Stkmodeno;																				// 選択モード
				nextVo.Modeno = prevVo.Modeno;																						// 選択モード
				nextVo.Nyuryoku_ymd = prevM1Vo.M1nyuryoku_ymd;																		// 入力日
				nextVo.Rintana_kanri_no = BoSystemString.ZeroToEmpty(prevM1Vo.Dictionary[Tj190p01Constant.DIC_M1RINTANA_KANRI_NO].ToString());
																																	// 臨棚管理№
				nextVo.Loss_kanri_no = BoSystemString.ZeroToEmpty(prevM1Vo.Dictionary[Tj190p01Constant.DIC_M1LOSS_KANRI_NO].ToString());
																																	// ロス管理№
				nextVo.Bumon_cd_bo = prevM1Vo.Dictionary[Tj190p01Constant.DIC_M1BUMON_CD].ToString();								// 部門コード
				nextVo.Bumon_nm = prevM1Vo.Dictionary[Tj190p01Constant.DIC_M1BUMON_NM_MEISAI].ToString();							// 部門名
				nextVo.Nyuryokutan_cd = prevM1Vo.Dictionary[Tj190p01Constant.DIC_M1NYURYOKUTAN_CD].ToString();						// 入力担当者コード
				nextVo.Nyuryokutan_nm = prevM1Vo.M1nyuryokutan_nm;																	// 入力担当者名称
				nextVo.Losskeisan_ymd = prevM1Vo.M1losskeisan_ymd;																	// ロス計算日
				nextVo.Losskeisan_tm = prevM1Vo.M1losskeisan_tm;																	// ロス計算時間
				nextVo.Hinsyu_sitei_flg = prevM1Vo.Dictionary[Tj190p01Constant.DIC_M1HINSYU_SITEI_FLG].ToString();					// 品種指定フラグ
				nextVo.Hinsyu_cd = prevM1Vo.Dictionary[Tj190p01Constant.DIC_M1HINSYU_CD].ToString();								// 品種コード
				nextVo.Hinsyu_ryaku_nm = prevM1Vo.M1hinsyu_ryaku_nm;																// 品種略名称
				nextVo.Burando_sitei_flg = prevM1Vo.Dictionary[Tj190p01Constant.DIC_M1BURANDO_SITEI_FLG].ToString();				// ブランド指定フラグ
				nextVo.Burando_cd = prevM1Vo.Dictionary[Tj190p01Constant.DIC_M1BURANDO_CD].ToString();								// ブランドコード
				nextVo.Burando_nm = prevM1Vo.M1burando_nm1;																			// ブランド名
				nextVo.Burando_cd1 = prevM1Vo.Dictionary[Tj190p01Constant.DIC_M1BURANDO_CD1].ToString();							// ブランドコード1
				nextVo.Burando_nm1 = prevM1Vo.M1burando_nm2;																		// ブランド名1
				nextVo.Burando_cd2 = prevM1Vo.Dictionary[Tj190p01Constant.DIC_M1BURANDO_CD2].ToString();							// ブランドコード2
				nextVo.Burando_nm2 = prevM1Vo.M1burando_nm3;																		// ブランド名2
				nextVo.Burando_cd3 = prevM1Vo.Dictionary[Tj190p01Constant.DIC_M1BURANDO_CD3].ToString();							// ブランドコード3
				nextVo.Burando_nm3 = prevM1Vo.M1burando_nm4;																		// ブランド名3
				nextVo.Burando_cd4 = prevM1Vo.Dictionary[Tj190p01Constant.DIC_M1BURANDO_CD4].ToString();							// ブランドコード4
				nextVo.Burando_nm4 = prevM1Vo.M1burando_nm5;																		// ブランド名4
				nextVo.Burando_cd5 = prevM1Vo.Dictionary[Tj190p01Constant.DIC_M1BURANDO_CD5].ToString();							// ブランドコード5
				nextVo.Burando_nm5 = prevM1Vo.M1burando_nm6;																		// ブランド名5
				nextVo.Burando_cd6 = prevM1Vo.Dictionary[Tj190p01Constant.DIC_M1BURANDO_CD6].ToString();							// ブランドコード6
				nextVo.Burando_nm6 = prevM1Vo.M1burando_nm7;																		// ブランド名6
				nextVo.Burando_cd7 = prevM1Vo.Dictionary[Tj190p01Constant.DIC_M1BURANDO_CD7].ToString();							// ブランドコード7
				nextVo.Burando_nm7 = prevM1Vo.M1burando_nm8;																		// ブランド名7
				nextVo.Gokeitanajityobo_su = dGokeitanajityobo_su.ToString();														// 合計棚時帳簿数
				nextVo.Gokeitanajisekiso_su = dGokeitanajisekiso_su.ToString();														// 合計棚時積送数
				nextVo.Gokeijitana_su = dGokeijitana_su.ToString();																	// 合計実棚数
				nextVo.Gokeiloss_su = dGokeiloss_su.ToString();																		// 合計ロス数
				nextVo.Gokeiloss_kin = dGokeiloss_kin.ToString();																	// 合計ロス金額

				// 店舗コード隠しを設定
				nextVo.Tenpo_cd_hdn = prevM1Vo.M1tenpo_cd;

				// Dictionaryの設定
				nextVo.Dictionary[Tj190p01Constant.DIC_TENPO_CD] = prevM1Vo.M1tenpo_cd;
				nextVo.Dictionary[Tj190p01Constant.DIC_SYORI_YMD] = prevM1Vo.Dictionary[Tj190p01Constant.DIC_M1SYORI_YMD].ToString();
				nextVo.Dictionary[Tj190p01Constant.DIC_SYORI_TM] = prevM1Vo.Dictionary[Tj190p01Constant.DIC_M1SYORI_TM].ToString();
				nextVo.Dictionary[Tj190p01Constant.DIC_M1UPD_YMD] = prevM1Vo.Dictionary[Tj190p01Constant.DIC_M1UPD_YMD].ToString();
				nextVo.Dictionary[Tj190p01Constant.DIC_M1UPD_TM] = prevM1Vo.Dictionary[Tj190p01Constant.DIC_M1UPD_TM].ToString();

				// VOをディクショナリに設定
				nextVo.Dictionary[Tj190p01Constant.DIC_M1VO] = prevVo;
				// 選択明細のVO
				nextVo.Dictionary[Tj190p01Constant.DIC_M1SELCETVO] = prevM1Vo;
				// 選択行のインデックスを設定
				nextVo.Dictionary[Tj190p01Constant.DIC_M1SELCETROWIDX] = facadeContext.CommandInfo.ListIndex.ToString();
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
