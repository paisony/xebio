using com.xebio.bo.Th020p01.Constant;
using com.xebio.bo.Th020p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C99999.Constant;
using Common.Business.C99999.DbUtil;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.StringUtil;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Data;

namespace com.xebio.bo.Th020p01.Facade
{
  /// <summary>
  /// Th020f03のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Th020f03Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : M1area_ryaku_nm)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(M1area_ryaku_nm)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoM1AREA_RYAKU_NM_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			////メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoM1AREA_RYAKU_NM_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを開きます。
				OpenConnection(facadeContext);
			
				//以下に業務ロジックを記述する。
				#region 初期化

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Th020f03Form prevVo = (Th020f03Form)facadeContext.FormVO;
				Th020f02Form nextVo = (Th020f02Form)facadeContext.GetUserObject(Th020p01Constant.FCDUO_NEXTVO_02);

				IDataList prevM1List = prevVo.GetList("M1");
				IDataList nextM1List = nextVo.GetList("M1");

				// 選択行の情報を取得する。
				Th020f03M1Form prevM1Vo = (Th020f03M1Form)prevM1List.GetPageViewList()[facadeContext.CommandInfo.ListIndex];

				// 一覧の初期化
				nextM1List.ClearCacheData();
				nextM1List.Clear();

				#endregion

				#region 検索処理

				String OraclePackageName = string.Empty;
				ArrayList paramList = new ArrayList();

				// 会社コード設定
				String sCopCd = string.Empty;
				sCopCd = Convert.ToDecimal(BoSystemString.Nvl(prevVo.Kaisya_cd, "0")).ToString();

				OraclePackageName = Th020p01Constant.ORACLE_PACKAGE_TENPO;
				// 会社コード
				StoredProcedureCls.SetStoredParam(ref paramList, "V_KAISYA_CD", OracleDbType.Decimal, ParameterDirection.Input, sCopCd);
				// エリアコード
				StoredProcedureCls.SetStoredParam(ref paramList, "V_AREA_CD", OracleDbType.Char, ParameterDirection.Input, prevM1Vo.Dictionary[Th020p01Constant.DIC_AREA_CD].ToString());
				// 店舗コード
				StoredProcedureCls.SetStoredParam(ref paramList, "V_TENPO_CD", OracleDbType.Char, ParameterDirection.Input, BoSystemFormat.formatTenpoCd(prevVo.Head_tenpo_cd));
				// 自社品番
				StoredProcedureCls.SetStoredParam(ref paramList, "V_JISHAHIN", OracleDbType.Char, ParameterDirection.Input, BoSystemFormat.formatJisyaHbn(prevVo.Jisya_hbn));
				// 色コード
				StoredProcedureCls.SetStoredParam(ref paramList, "V_IRO_CD", OracleDbType.Varchar2, ParameterDirection.Input, BoSystemFormat.formatIroCd(prevVo.Dictionary[Th020p01Constant.DIC_M1MAKERCOLOR_CD].ToString()));

				// 処理呼び出し
				ArrayList rtSeach = StoredProcedureCls.ExecStoredProcedure(facadeContext.DBContext, OraclePackageName, paramList);

				#region ■例外処理
				if (rtSeach != null && rtSeach.Count > 0)
				{
					// エラーコード
					string errCd = rtSeach[0].ToString();

					if (errCd.Equals(BoSystemConstant.STORED_NOT_ERR))
					{
						// 正常終了
					}
					else
					{
						// それ以外の場合
						throw new SystemException("ストアド［" + OraclePackageName + "］実行時にエラーが発生しました。エラーコード：" + errCd);
					}
				}
				else
				{
					// OUTパラメータが取得できない場合
					throw new SystemException("ストアド［" + OraclePackageName + "］実行時にエラーが発生しました。");
				}
				#endregion

				// カーソル取得
				ArrayList rtSeachList = (ArrayList)rtSeach[1];

				Hashtable HeadRec = (Hashtable)rtSeachList[0];

				// カード部設定
				// ヘッダ店舗コード
				nextVo.Head_tenpo_cd = prevVo.Head_tenpo_cd;
				// ヘッダ店舗名
				nextVo.Head_tenpo_nm = prevVo.Head_tenpo_nm;
				// 会社コード
				nextVo.Kaisya_cd = sCopCd;
				// 会社名称
				nextVo.Kaisya_nm = prevVo.Kaisya_nm;
				// 部門コード
				nextVo.Bumon_cd = BoSystemFormat.formatBumonCd(prevVo.Bumon_cd);
				// 部門名
				nextVo.Bumon_nm = prevVo.Bumon_nm;
				// 品種略名称
				nextVo.Hinsyu_ryaku_nm = prevVo.Hinsyu_ryaku_nm;
				// ブランドコード
				nextVo.Burando_cd = BoSystemFormat.formatBrandCd(prevVo.Burando_cd);
				// ブランド名
				nextVo.Burando_nm = prevVo.Burando_nm;
				// 自社品番
				nextVo.Jisya_hbn = BoSystemFormat.formatJisyaHbn(prevVo.Jisya_hbn);
				// メーカー品番
				nextVo.Maker_hbn = prevVo.Maker_hbn;
				// 商品属性
				nextVo.Syohin_zokusei = prevVo.Syohin_zokusei;
				// 商品名(カナ)
				nextVo.Syonmk = prevVo.Syonmk;
				// 色
				nextVo.Iro_nm = prevVo.Iro_nm;
				// 全店在庫数
				nextVo.Zentenzaiko_su = prevVo.Zentenzaiko_su;
				// 全店消化率
				nextVo.Zentensyoka_rtu = prevVo.Zentensyoka_rtu;
				// 明細ヘッダ色(1～30)
				nextVo.Dictionary[Th020p01Constant.DIC_M1HEAD_HASH] = HeadRec;

				// 明細フッター 取得した明細の1行目を設定する
				// 店舗コード
				nextVo.Tenpo_cd = BoSystemFormat.formatTenpoCd(HeadRec["TENPO_CD"].ToString());
				// 店舗名
				nextVo.Tenpo_nm = HeadRec["TENPO_NM"].ToString();
				// 総合計数量
				nextVo.All_gokei_suryo = HeadRec["ZAIKOSU"].ToString();
				// 数量１
				nextVo.Suryo1 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU01", "JAN_CD01");
				// 数量２
				nextVo.Suryo2 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU02", "JAN_CD02");
				// 数量３
				nextVo.Suryo3 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU03", "JAN_CD03");
				// 数量４
				nextVo.Suryo4 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU04", "JAN_CD04");
				// 数量５
				nextVo.Suryo5 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU05", "JAN_CD05");
				// 数量６
				nextVo.Suryo6 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU06", "JAN_CD06");
				// 数量７
				nextVo.Suryo7 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU07", "JAN_CD07");
				// 数量８
				nextVo.Suryo8 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU08", "JAN_CD08");
				// 数量９
				nextVo.Suryo9 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU09", "JAN_CD09");
				// 数量１０
				nextVo.Suryo10 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU10", "JAN_CD10");
				// 数量１１
				nextVo.Suryo11 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU11", "JAN_CD11");
				// 数量１２
				nextVo.Suryo12 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU12", "JAN_CD12");
				// 数量１３
				nextVo.Suryo13 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU13", "JAN_CD13");
				// 数量１４
				nextVo.Suryo14 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU14", "JAN_CD14");
				// 数量１５
				nextVo.Suryo15 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU15", "JAN_CD15");
				// 数量１６
				nextVo.Suryo16 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU16", "JAN_CD16");
				// 数量１７
				nextVo.Suryo17 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU17", "JAN_CD17");
				// 数量１８
				nextVo.Suryo18 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU18", "JAN_CD18");
				// 数量１９
				nextVo.Suryo19 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU19", "JAN_CD19");
				// 数量２０
				nextVo.Suryo20 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU20", "JAN_CD20");
				// 数量２１
				nextVo.Suryo21 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU21", "JAN_CD21");
				// 数量２２
				nextVo.Suryo22 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU22", "JAN_CD22");
				// 数量２３
				nextVo.Suryo23 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU23", "JAN_CD23");
				// 数量２４
				nextVo.Suryo24 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU24", "JAN_CD24");
				// 数量２５
				nextVo.Suryo25 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU25", "JAN_CD25");
				// 数量２６
				nextVo.Suryo26 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU26", "JAN_CD26");
				// 数量２７
				nextVo.Suryo27 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU27", "JAN_CD27");
				// 数量２８
				nextVo.Suryo28 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU28", "JAN_CD28");
				// 数量２９
				nextVo.Suryo29 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU29", "JAN_CD29");
				// 数量３０
				nextVo.Suryo30 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU30", "JAN_CD30");

				// 一覧画面の選択モード
				nextVo.Dictionary[Th020p01Constant.DIC_STKMODENO] = prevVo.Dictionary[Th020p01Constant.DIC_STKMODENO].ToString();
				// 一覧画面のスキャンコードFROM
				nextVo.Dictionary[Th020p01Constant.DIC_SCAN_CD_FROM] = prevVo.Dictionary[Th020p01Constant.DIC_SCAN_CD_FROM].ToString();
				// 一覧画面のスキャンコードTO
				nextVo.Dictionary[Th020p01Constant.DIC_SCAN_CD_TO] = prevVo.Dictionary[Th020p01Constant.DIC_SCAN_CD_TO].ToString();
				// 色コード
				nextVo.Dictionary[Th020p01Constant.DIC_M1MAKERCOLOR_CD] = BoSystemFormat.formatIroCd(prevVo.Dictionary[Th020p01Constant.DIC_M1MAKERCOLOR_CD].ToString());
				// エリアコード
				nextVo.Dictionary[Th020p01Constant.DIC_AREA_CD] = prevM1Vo.Dictionary[Th020p01Constant.DIC_AREA_CD].ToString();
				// 背景色変更エリアコード
				nextVo.Dictionary[Th020p01Constant.DIC_AREA_CD_IROCHANGE] = prevVo.Dictionary[Th020p01Constant.DIC_AREA_CD_IROCHANGE];
				// 展開区分
				nextVo.Dictionary[Th020p01Constant.DIC_TENKAI_KBN] = prevVo.Dictionary[Th020p01Constant.DIC_TENKAI_KBN];
				// 検索時店舗コード
				nextVo.Dictionary[Th020p01Constant.DIC_TENPO_CD] = prevVo.Dictionary[Th020p01Constant.DIC_TENPO_CD];
				// 選択行のインデックスを設定
				nextVo.Dictionary[Th020p01Constant.DIC_M1SELCETROWIDX] = prevVo.Dictionary[Th020p01Constant.DIC_M1SELCETROWIDX].ToString();
				// 前画面フォームID
				nextVo.Dictionary[Th020p01Constant.DIC_PREV_FORMID] = Th020p01Constant.FORMID_03;
				// 在庫検索選択状態
				nextVo.Dictionary[Th020p01Constant.DIC_ZAIKO_SERCHSTK] = prevVo.Dictionary[Th020p01Constant.DIC_ZAIKO_SERCHSTK];
				int iCnt = -1;
				// 明細設定
				foreach (Hashtable rec in rtSeachList)
				{
					Th020f02M1Form f02m1VO = new Th020f02M1Form();

					// 一行目は在庫検索用の物流センターデータのため飛ばす
					if (iCnt == -1)
					{
						iCnt++;
						continue;
					}
					iCnt++;
					// Ｍ１行NO
					f02m1VO.M1rowno = iCnt.ToString();
					// Ｍ１店舗コード
					f02m1VO.M1tenpo_cd = BoSystemFormat.formatTenpoCd(rec["TENPO_CD"].ToString());
					// Ｍ１店舗名
					f02m1VO.M1tenpo_nm = rec["TENPO_NM"].ToString();
					// Ｍ１合計数量
					f02m1VO.M1gokei_suryo = rec["ZAIKOSU"].ToString();
					// Ｍ１消化率
					f02m1VO.M1syoka_rtu = BoSystemString.Nvl(rec["SYOKART"].ToString(),"0.0");
					// Ｍ１数量１
					f02m1VO.M1suryo1 = zaikoSuEdit(rec, "FREEZAIKO_SU01", "JAN_CD01");
					// Ｍ１数量２
					f02m1VO.M1suryo2 = zaikoSuEdit(rec, "FREEZAIKO_SU02", "JAN_CD02");
					// Ｍ１数量３
					f02m1VO.M1suryo3 = zaikoSuEdit(rec, "FREEZAIKO_SU03", "JAN_CD03");
					// Ｍ１数量４
					f02m1VO.M1suryo4 = zaikoSuEdit(rec, "FREEZAIKO_SU04", "JAN_CD04");
					// Ｍ１数量５
					f02m1VO.M1suryo5 = zaikoSuEdit(rec, "FREEZAIKO_SU05", "JAN_CD05");
					// Ｍ１数量６
					f02m1VO.M1suryo6 = zaikoSuEdit(rec, "FREEZAIKO_SU06", "JAN_CD06");
					// Ｍ１数量７
					f02m1VO.M1suryo7 = zaikoSuEdit(rec, "FREEZAIKO_SU07", "JAN_CD07");
					// Ｍ１数量８
					f02m1VO.M1suryo8 = zaikoSuEdit(rec, "FREEZAIKO_SU08", "JAN_CD08");
					// Ｍ１数量９
					f02m1VO.M1suryo9 = zaikoSuEdit(rec, "FREEZAIKO_SU09", "JAN_CD09");
					// Ｍ１数量１０
					f02m1VO.M1suryo10 = zaikoSuEdit(rec, "FREEZAIKO_SU10", "JAN_CD10");
					// Ｍ１数量１１
					f02m1VO.M1suryo11 = zaikoSuEdit(rec, "FREEZAIKO_SU11", "JAN_CD11");
					// Ｍ１数量１２
					f02m1VO.M1suryo12 = zaikoSuEdit(rec, "FREEZAIKO_SU12", "JAN_CD12");
					// Ｍ１数量１３
					f02m1VO.M1suryo13 = zaikoSuEdit(rec, "FREEZAIKO_SU13", "JAN_CD13");
					// Ｍ１数量１４
					f02m1VO.M1suryo14 = zaikoSuEdit(rec, "FREEZAIKO_SU14", "JAN_CD14");
					// Ｍ１数量１５
					f02m1VO.M1suryo15 = zaikoSuEdit(rec, "FREEZAIKO_SU15", "JAN_CD15");
					// Ｍ１数量１６
					f02m1VO.M1suryo16 = zaikoSuEdit(rec, "FREEZAIKO_SU16", "JAN_CD16");
					// Ｍ１数量１７
					f02m1VO.M1suryo17 = zaikoSuEdit(rec, "FREEZAIKO_SU17", "JAN_CD17");
					// Ｍ１数量１８
					f02m1VO.M1suryo18 = zaikoSuEdit(rec, "FREEZAIKO_SU18", "JAN_CD18");
					// Ｍ１数量１９
					f02m1VO.M1suryo19 = zaikoSuEdit(rec, "FREEZAIKO_SU19", "JAN_CD19");
					// Ｍ１数量２０
					f02m1VO.M1suryo20 = zaikoSuEdit(rec, "FREEZAIKO_SU20", "JAN_CD20");
					// Ｍ１数量２１
					f02m1VO.M1suryo21 = zaikoSuEdit(rec, "FREEZAIKO_SU21", "JAN_CD21");
					// Ｍ１数量２２
					f02m1VO.M1suryo22 = zaikoSuEdit(rec, "FREEZAIKO_SU22", "JAN_CD22");
					// Ｍ１数量２３
					f02m1VO.M1suryo23 = zaikoSuEdit(rec, "FREEZAIKO_SU23", "JAN_CD23");
					// Ｍ１数量２４
					f02m1VO.M1suryo24 = zaikoSuEdit(rec, "FREEZAIKO_SU24", "JAN_CD24");
					// Ｍ１数量２５
					f02m1VO.M1suryo25 = zaikoSuEdit(rec, "FREEZAIKO_SU25", "JAN_CD25");
					// Ｍ１数量２６
					f02m1VO.M1suryo26 = zaikoSuEdit(rec, "FREEZAIKO_SU26", "JAN_CD26");
					// Ｍ１数量２７
					f02m1VO.M1suryo27 = zaikoSuEdit(rec, "FREEZAIKO_SU27", "JAN_CD27");
					// Ｍ１数量２８
					f02m1VO.M1suryo28 = zaikoSuEdit(rec, "FREEZAIKO_SU28", "JAN_CD28");
					// Ｍ１数量２９
					f02m1VO.M1suryo29 = zaikoSuEdit(rec, "FREEZAIKO_SU29", "JAN_CD29");
					// Ｍ１数量３０
					f02m1VO.M1suryo30 = zaikoSuEdit(rec, "FREEZAIKO_SU30", "JAN_CD30");
					// Ｍ１選択フラグ(隠し)
					f02m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;
					// Ｍ１確定処理フラグ(隠し)
					f02m1VO.M1selectorcheckbox = ConditionKakuteisyori_flg.VALUE_NASI;
					// Ｍ１明細色区分(隠し)
					// Ｍ１店舗コードとログイン情報の店舗コードが一致した場合、"2"、それ以外の場合、"0"
					if (BoSystemFormat.formatTenpoCd(prevVo.Head_tenpo_cd).Equals(BoSystemFormat.formatTenpoCd(f02m1VO.M1tenpo_cd)))
					{
						f02m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_SHOHIN_SHITEI;
					}
					else
					{
						f02m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;
					}
					//リストオブジェクトにM1Formを追加します。
					nextM1List.Add(f02m1VO, true);

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
			EndMethod(facadeContext, this.GetType().Name + ".DoM1AREA_RYAKU_NM_FRM");

		}
		#endregion

		#region ユーザー定義関数

		#region 在庫数設定

		/// <summary>
		/// 在庫数設定
		/// </summary>
		/// <returns>結果</returns>
		private String zaikoSuEdit(Hashtable rec, String zaiko_su_id, String jan_id)
		{
			String zaiko_su = string.Empty;

			// JANコードが設定済みの場合設定
			if (!string.IsNullOrEmpty(rec[jan_id].ToString()))
			{
				zaiko_su = rec[zaiko_su_id].ToString();
			}

			return zaiko_su;
		}

		#endregion


		#endregion

	}

}
