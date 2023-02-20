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
  /// Th020f02のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Th020f02Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : Btnarea)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnarea)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNAREA_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			////メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNAREA_FRM");

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
				Th020f02Form prevVo = (Th020f02Form)facadeContext.FormVO;
				Th020f03Form nextVo = (Th020f03Form)facadeContext.GetUserObject(Th020p01Constant.FCDUO_NEXTVO_03);

				IDataList prevM1List = prevVo.GetList("M1");
				IDataList nextM1List = nextVo.GetList("M1");

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

				// パラメータ設定
				OraclePackageName = Th020p01Constant.ORACLE_PACKAGE_ERA;
				// 会社コード
				StoredProcedureCls.SetStoredParam(ref paramList, "V_KAISYA_CD", OracleDbType.Decimal, ParameterDirection.Input, sCopCd);
				// エリアコード
				StoredProcedureCls.SetStoredParam(ref paramList, "V_AREA_CD", OracleDbType.Char, ParameterDirection.Input, prevVo.Dictionary[Th020p01Constant.DIC_AREA_CD_IROCHANGE].ToString());
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
				nextVo.Kaisya_cd = BoSystemFormat.formatKaisyaCd(sCopCd);
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
				//明細ヘッダ色１
				nextVo.Meisaihead_iro_nm1 = hyodaiEdit(HeadRec, "SIZE_NM01");
				//明細ヘッダ色２
				nextVo.Meisaihead_iro_nm2 = hyodaiEdit(HeadRec,  "SIZE_NM02");
				//明細ヘッダ色３
				nextVo.Meisaihead_iro_nm3 = hyodaiEdit(HeadRec,  "SIZE_NM03");
				//明細ヘッダ色４
				nextVo.Meisaihead_iro_nm4 = hyodaiEdit(HeadRec,  "SIZE_NM04");
				//明細ヘッダ色５
				nextVo.Meisaihead_iro_nm5 = hyodaiEdit(HeadRec,  "SIZE_NM05");
				//明細ヘッダ色６
				nextVo.Meisaihead_iro_nm6 = hyodaiEdit(HeadRec,  "SIZE_NM06");
				//明細ヘッダ色７
				nextVo.Meisaihead_iro_nm7 = hyodaiEdit(HeadRec,  "SIZE_NM07");
				//明細ヘッダ色８
				nextVo.Meisaihead_iro_nm8 = hyodaiEdit(HeadRec,  "SIZE_NM08");
				//明細ヘッダ色９
				nextVo.Meisaihead_iro_nm9 = hyodaiEdit(HeadRec,  "SIZE_NM09");
				//明細ヘッダ色１０
				nextVo.Meisaihead_iro_nm10 = hyodaiEdit(HeadRec, "SIZE_NM10");
				//明細ヘッダ色１１
				nextVo.Meisaihead_iro_nm11 = hyodaiEdit(HeadRec, "SIZE_NM11");
				//明細ヘッダ色１２
				nextVo.Meisaihead_iro_nm12 = hyodaiEdit(HeadRec, "SIZE_NM12");
				//明細ヘッダ色１３
				nextVo.Meisaihead_iro_nm13 = hyodaiEdit(HeadRec, "SIZE_NM13");
				//明細ヘッダ色１４
				nextVo.Meisaihead_iro_nm14 = hyodaiEdit(HeadRec, "SIZE_NM14");
				//明細ヘッダ色１５
				nextVo.Meisaihead_iro_nm15 = hyodaiEdit(HeadRec, "SIZE_NM15");
				//明細ヘッダ色１６
				nextVo.Meisaihead_iro_nm16 = hyodaiEdit(HeadRec, "SIZE_NM16");
				//明細ヘッダ色１７
				nextVo.Meisaihead_iro_nm17 = hyodaiEdit(HeadRec, "SIZE_NM17");
				//明細ヘッダ色１８
				nextVo.Meisaihead_iro_nm18 = hyodaiEdit(HeadRec, "SIZE_NM18");
				//明細ヘッダ色１９
				nextVo.Meisaihead_iro_nm19 = hyodaiEdit(HeadRec, "SIZE_NM19");
				//明細ヘッダ色２０
				nextVo.Meisaihead_iro_nm20 = hyodaiEdit(HeadRec, "SIZE_NM20");
				//明細ヘッダ色２１
				nextVo.Meisaihead_iro_nm21 = hyodaiEdit(HeadRec, "SIZE_NM21");
				//明細ヘッダ色２２
				nextVo.Meisaihead_iro_nm22 = hyodaiEdit(HeadRec, "SIZE_NM22");
				//明細ヘッダ色２３
				nextVo.Meisaihead_iro_nm23 = hyodaiEdit(HeadRec, "SIZE_NM23");
				//明細ヘッダ色２４
				nextVo.Meisaihead_iro_nm24 = hyodaiEdit(HeadRec, "SIZE_NM24");
				//明細ヘッダ色２５
				nextVo.Meisaihead_iro_nm25 = hyodaiEdit(HeadRec, "SIZE_NM25");
				//明細ヘッダ色２６
				nextVo.Meisaihead_iro_nm26 = hyodaiEdit(HeadRec, "SIZE_NM26");
				//明細ヘッダ色２７
				nextVo.Meisaihead_iro_nm27 = hyodaiEdit(HeadRec, "SIZE_NM27");
				//明細ヘッダ色２８
				nextVo.Meisaihead_iro_nm28 = hyodaiEdit(HeadRec, "SIZE_NM28");
				//明細ヘッダ色２９
				nextVo.Meisaihead_iro_nm29 = hyodaiEdit(HeadRec, "SIZE_NM29");
				//明細ヘッダ色３０
				nextVo.Meisaihead_iro_nm30 = hyodaiEdit(HeadRec, "SIZE_NM30");

				// 明細フッター 取得した明細の1行目を設定する
				// 店舗コード
				nextVo.Tenpo_cd = BoSystemFormat.formatTenpoCd(HeadRec["TENPO_CD"].ToString());
				// 店舗名
				nextVo.Tenpo_nm = HeadRec["TENPO_NM"].ToString();
				// 総合計数量
				nextVo.All_gokei_suryo = HeadRec["ZAIKOSU"].ToString();
				// 合計数量１
				nextVo.Gokei_suryo1 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU01", "JAN_CD01");
				// 合計数量２
				nextVo.Gokei_suryo2 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU02", "JAN_CD02");
				// 合計数量３
				nextVo.Gokei_suryo3 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU03", "JAN_CD03");
				// 合計数量４
				nextVo.Gokei_suryo4 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU04", "JAN_CD04");
				// 合計数量５
				nextVo.Gokei_suryo5 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU05", "JAN_CD05");
				// 合計数量６
				nextVo.Gokei_suryo6 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU06", "JAN_CD06");
				// 合計数量７
				nextVo.Gokei_suryo7 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU07", "JAN_CD07");
				// 合計数量８
				nextVo.Gokei_suryo8 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU08", "JAN_CD08");
				// 合計数量９
				nextVo.Gokei_suryo9 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU09", "JAN_CD09");
				// 合計数量１０
				nextVo.Gokei_suryo10 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU10", "JAN_CD10");
				// 合計数量１１
				nextVo.Gokei_suryo11 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU11", "JAN_CD11");
				// 合計数量１２
				nextVo.Gokei_suryo12 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU12", "JAN_CD12");
				// 合計数量１３
				nextVo.Gokei_suryo13 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU13", "JAN_CD13");
				// 合計数量１４
				nextVo.Gokei_suryo14 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU14", "JAN_CD14");
				// 合計数量１５
				nextVo.Gokei_suryo15 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU15", "JAN_CD15");
				// 合計数量１６
				nextVo.Gokei_suryo16 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU16", "JAN_CD16");
				// 合計数量１７
				nextVo.Gokei_suryo17 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU17", "JAN_CD17");
				// 合計数量１８
				nextVo.Gokei_suryo18 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU18", "JAN_CD18");
				// 合計数量１９
				nextVo.Gokei_suryo19 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU19", "JAN_CD19");
				// 合計数量２０
				nextVo.Gokei_suryo20 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU20", "JAN_CD20");
				// 合計数量２１
				nextVo.Gokei_suryo21 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU21", "JAN_CD21");
				// 合計数量２２
				nextVo.Gokei_suryo22 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU22", "JAN_CD22");
				// 合計数量２３
				nextVo.Gokei_suryo23 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU23", "JAN_CD23");
				// 合計数量２４
				nextVo.Gokei_suryo24 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU24", "JAN_CD24");
				// 合計数量２５
				nextVo.Gokei_suryo25 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU25", "JAN_CD25");
				// 合計数量２６
				nextVo.Gokei_suryo26 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU26", "JAN_CD26");
				// 合計数量２７
				nextVo.Gokei_suryo27 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU27", "JAN_CD27");
				// 合計数量２８
				nextVo.Gokei_suryo28 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU28", "JAN_CD28");
				// 合計数量２９
				nextVo.Gokei_suryo29 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU29", "JAN_CD29");
				// 合計数量３０
				nextVo.Gokei_suryo30 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU30", "JAN_CD30");

				// 明細ヘッダ色(1～30)
				nextVo.Dictionary[Th020p01Constant.DIC_M1HEAD_HASH] = HeadRec;

				// 一覧画面の選択モード
				nextVo.Dictionary[Th020p01Constant.DIC_STKMODENO] = prevVo.Dictionary[Th020p01Constant.DIC_STKMODENO].ToString();
				// 一覧画面のスキャンコードFROM
				nextVo.Dictionary[Th020p01Constant.DIC_SCAN_CD_FROM] = prevVo.Dictionary[Th020p01Constant.DIC_SCAN_CD_FROM].ToString();
				// 一覧画面のスキャンコードTO
				nextVo.Dictionary[Th020p01Constant.DIC_SCAN_CD_TO] = prevVo.Dictionary[Th020p01Constant.DIC_SCAN_CD_TO].ToString();
				// 色コード
				nextVo.Dictionary[Th020p01Constant.DIC_M1MAKERCOLOR_CD] = BoSystemFormat.formatIroCd(prevVo.Dictionary[Th020p01Constant.DIC_M1MAKERCOLOR_CD].ToString());
				// エリアコード
				nextVo.Dictionary[Th020p01Constant.DIC_AREA_CD] = prevVo.Dictionary[Th020p01Constant.DIC_AREA_CD].ToString();
				// 背景色変更エリアコード
				nextVo.Dictionary[Th020p01Constant.DIC_AREA_CD_IROCHANGE] = prevVo.Dictionary[Th020p01Constant.DIC_AREA_CD_IROCHANGE];
				// 展開区分
				nextVo.Dictionary[Th020p01Constant.DIC_TENKAI_KBN] = prevVo.Dictionary[Th020p01Constant.DIC_TENKAI_KBN];
				// 検索時店舗コード
				nextVo.Dictionary[Th020p01Constant.DIC_TENPO_CD] = prevVo.Dictionary[Th020p01Constant.DIC_TENPO_CD];
				// 前画面フォームID
				nextVo.Dictionary[Th020p01Constant.DIC_PREV_FORMID] = Th020p01Constant.FORMID_02;
				// 在庫検索選択状態
				nextVo.Dictionary[Th020p01Constant.DIC_ZAIKO_SERCHSTK] = prevVo.Dictionary[Th020p01Constant.DIC_ZAIKO_SERCHSTK];
				// 選択行のインデックスを設定
				nextVo.Dictionary[Th020p01Constant.DIC_M1SELCETROWIDX] = prevVo.Dictionary[Th020p01Constant.DIC_M1SELCETROWIDX].ToString();

				int iCnt = -1;

				// 明細設定
				foreach (Hashtable rec in rtSeachList)
				{
					Th020f03M1Form f03m1VO = new Th020f03M1Form();

					// 一行目は在庫検索用の物流センターデータのため飛ばす
					if (iCnt == -1)
					{
						iCnt++;
						continue;
					}
					iCnt++;
					// Ｍ１行NO
					f03m1VO.M1rowno = iCnt.ToString();
					// Ｍ１エリアコード
					// f03m1VO.M1area_cd = rec["TENPO_CD"].ToString();
					// Ｍ１エリア略式名称
					f03m1VO.Dictionary[Th020p01Constant.DIC_M1AREA_NM] = rec["TENPO_NM"].ToString();
					// Ｍ１合計数量
					f03m1VO.M1gokei_suryo = rec["ZAIKOSU"].ToString();
					// Ｍ１消化率
					f03m1VO.M1syoka_rtu = BoSystemString.Nvl(rec["SYOKART"].ToString(),"0.0");
					// Ｍ１数量１
					f03m1VO.M1suryo1 = zaikoSuEdit(rec, "FREEZAIKO_SU01", "JAN_CD01");
					// Ｍ１数量２
					f03m1VO.M1suryo2 = zaikoSuEdit(rec, "FREEZAIKO_SU02", "JAN_CD02");
					// Ｍ１数量３
					f03m1VO.M1suryo3 = zaikoSuEdit(rec, "FREEZAIKO_SU03", "JAN_CD03");
					// Ｍ１数量４
					f03m1VO.M1suryo4 = zaikoSuEdit(rec, "FREEZAIKO_SU04", "JAN_CD04");
					// Ｍ１数量５
					f03m1VO.M1suryo5 = zaikoSuEdit(rec, "FREEZAIKO_SU05", "JAN_CD05");
					// Ｍ１数量６
					f03m1VO.M1suryo6 = zaikoSuEdit(rec, "FREEZAIKO_SU06", "JAN_CD06");
					// Ｍ１数量７
					f03m1VO.M1suryo7 = zaikoSuEdit(rec, "FREEZAIKO_SU07", "JAN_CD07");
					// Ｍ１数量８
					f03m1VO.M1suryo8 = zaikoSuEdit(rec, "FREEZAIKO_SU08", "JAN_CD08");
					// Ｍ１数量９
					f03m1VO.M1suryo9 = zaikoSuEdit(rec, "FREEZAIKO_SU09", "JAN_CD09");
					// Ｍ１数量１０
					f03m1VO.M1suryo10 = zaikoSuEdit(rec, "FREEZAIKO_SU10","JAN_CD10");
					// Ｍ１数量１１
					f03m1VO.M1suryo11 = zaikoSuEdit(rec, "FREEZAIKO_SU11","JAN_CD11");
					// Ｍ１数量１２
					f03m1VO.M1suryo12 = zaikoSuEdit(rec, "FREEZAIKO_SU12","JAN_CD12");
					// Ｍ１数量１３
					f03m1VO.M1suryo13 = zaikoSuEdit(rec, "FREEZAIKO_SU13","JAN_CD13");
					// Ｍ１数量１４
					f03m1VO.M1suryo14 = zaikoSuEdit(rec, "FREEZAIKO_SU14","JAN_CD14");
					// Ｍ１数量１５
					f03m1VO.M1suryo15 = zaikoSuEdit(rec, "FREEZAIKO_SU15","JAN_CD15");
					// Ｍ１数量１６
					f03m1VO.M1suryo16 = zaikoSuEdit(rec, "FREEZAIKO_SU16","JAN_CD16");
					// Ｍ１数量１７
					f03m1VO.M1suryo17 = zaikoSuEdit(rec, "FREEZAIKO_SU17","JAN_CD17");
					// Ｍ１数量１８
					f03m1VO.M1suryo18 = zaikoSuEdit(rec, "FREEZAIKO_SU18","JAN_CD18");
					// Ｍ１数量１９
					f03m1VO.M1suryo19 = zaikoSuEdit(rec, "FREEZAIKO_SU19","JAN_CD19");
					// Ｍ１数量２０
					f03m1VO.M1suryo20 = zaikoSuEdit(rec, "FREEZAIKO_SU20","JAN_CD20");
					// Ｍ１数量２１
					f03m1VO.M1suryo21 = zaikoSuEdit(rec, "FREEZAIKO_SU21","JAN_CD21");
					// Ｍ１数量２２
					f03m1VO.M1suryo22 = zaikoSuEdit(rec, "FREEZAIKO_SU22","JAN_CD22");
					// Ｍ１数量２３
					f03m1VO.M1suryo23 = zaikoSuEdit(rec, "FREEZAIKO_SU23","JAN_CD23");
					// Ｍ１数量２４
					f03m1VO.M1suryo24 = zaikoSuEdit(rec, "FREEZAIKO_SU24","JAN_CD24");
					// Ｍ１数量２５
					f03m1VO.M1suryo25 = zaikoSuEdit(rec, "FREEZAIKO_SU25","JAN_CD25");
					// Ｍ１数量２６
					f03m1VO.M1suryo26 = zaikoSuEdit(rec, "FREEZAIKO_SU26","JAN_CD26");
					// Ｍ１数量２７
					f03m1VO.M1suryo27 = zaikoSuEdit(rec, "FREEZAIKO_SU27","JAN_CD27");
					// Ｍ１数量２８
					f03m1VO.M1suryo28 = zaikoSuEdit(rec, "FREEZAIKO_SU28","JAN_CD28");
					// Ｍ１数量２９
					f03m1VO.M1suryo29 = zaikoSuEdit(rec, "FREEZAIKO_SU29","JAN_CD29");
					// Ｍ１数量３０
					f03m1VO.M1suryo30 = zaikoSuEdit(rec, "FREEZAIKO_SU30","JAN_CD30");

					// Ｍ１選択フラグ(隠し)
					f03m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;
					// Ｍ１確定処理フラグ(隠し)
					f03m1VO.M1selectorcheckbox = ConditionKakuteisyori_flg.VALUE_NASI;
					// Ｍ１明細色区分(隠し)
					// 取得したエリアコードとヘッダ店舗コードに紐づくエリアコードが一致した場合、"2"、それ以外の場合、"0"
					if (prevVo.Dictionary[Th020p01Constant.DIC_AREA_CD_IROCHANGE].ToString().Equals(rec["TENPO_CD"].ToString()))
					{
						f03m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_SHOHIN_SHITEI;
					}
					else
					{
						f03m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;
					}

					// M1エリアコード(Dictionary)
					f03m1VO.Dictionary[Th020p01Constant.DIC_AREA_CD] = rec["TENPO_CD"].ToString();

					//リストオブジェクトにM1Formを追加します。
					nextM1List.Add(f03m1VO, true);
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
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNAREA_FRM");

		}
		#endregion

		#region ユーザー定義関数

		#region 明細標題設定

		/// <summary>
		/// 明細標題設定
		/// </summary>
		/// <returns>結果</returns>
		private String hyodaiEdit(Hashtable rec,  String size_nm_id)
		{
			return rec[size_nm_id].ToString();
		}

		#endregion

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
