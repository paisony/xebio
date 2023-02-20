using com.xebio.bo.Td020p01.Constant;
using com.xebio.bo.Td020p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01024;
using Common.Business.C99999.DateUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V01000.V01015;
using Common.Business.V03000.V03002;
using Common.Standard.Login;
using System;
using System.Collections;

namespace com.xebio.bo.Td020p01.Util
{
  /// <summary>
  /// Td020f01のユーティリティクラスです
  /// </summary>
  public partial class Td020p01Util
	{
		#region 定数を設定します
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		private Td020p01Util ()
		{
		}
		#endregion
		#region 現在行数取得
		/// <summary>
		/// 処理種別取得
		/// </summary>
		/// <param name="IDataList">m1List</param>
		/// <returns>現在行数</returns>
		public static int GetRowCnt ( IDataList m1List )
		{
			// 現在行数
			int curRowCnt = 0;
			// 後方から検索
			for (int i = m1List.Count - 1; i >= 0; i--)
			{
				// 行オブジェクト取得
				Td020f01M1Form m1FormVO = (Td020f01M1Form)m1List[i];

				// 店舗コード　または　スキャンコード　または　出荷数量に入力がある場合
				if (!string.IsNullOrEmpty(m1FormVO.M1tenpo_cd)
				 || !string.IsNullOrEmpty(m1FormVO.M1scan_cd)
				 || !string.IsNullOrEmpty(m1FormVO.M1itemsu))
				{
					curRowCnt = i + 1;
					break;
				}
			}
			return curRowCnt;
		}
		#endregion
		#region 返品不可商品チェック
		/// <summary>
		/// 返品不可商品チェック
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="Td020f01Form">f01m1VO</param>
		/// <param name="SysDateVO">sysDateVO</param>
		/// <returns>true:NG,false:Ok</returns>
		public static bool ChkHenpinFuka ( IFacadeContext facadeContext, Td020f01M1Form f01m1VO, SysDateVO sysDateVO )
		{
			Hashtable retHashRtfm = new Hashtable();
			Hashtable retHashRtfd = new Hashtable();
			int iWkRtfm = 0;
			int iWkRtfd = 0;
			bool blRet = false;

			string sSaisinSiire = f01m1VO.Dictionary[Td020p01Constant.DIC_M1SAISIN_SIIRE_YMD].ToString();			// 最新仕入日
			decimal dSaisinSiire = Convert.ToDecimal(BoSystemString.Nvl(sSaisinSiire,"0"));
			string sMongonFlg = f01m1VO.Dictionary[Td020p01Constant.DIC_M1HATTYUSYO_MONGON_INSATSU_FLG].ToString();	// 発注書文言印刷フラグ
			string sTyotatsu  = f01m1VO.Dictionary[Td020p01Constant.DIC_M1TYOTATSU_KB].ToString();					// 調達区分
			decimal dTyotatsu = Convert.ToDecimal(BoSystemString.RightB(BoSystemString.Nvl(sTyotatsu,"0"),1));
			string sHosyousyoFlg = BoSystemString.Nvl(f01m1VO.Dictionary[Td020p01Constant.DIC_M1HOSYOUSYO_HAKKOU_FLG].ToString(),"0");	// 保証書発行フラグ

			// 発注MST.発注書文言印刷フラグ="1"の場合
			if (Td020p01Constant.FLG_ON.ToString().Equals(sMongonFlg)
			 && dSaisinSiire != 0)
			{
				// 発注MST.調達区分の末尾が"1"から"4"(NB商品)以外の場合、以下のチェックを行う。
				if(dTyotatsu < 1 || dTyotatsu > 4 )
				{
					// 発注MST.保証書発行フラグ=0
					if( Td020p01Constant.FLG_OFF.ToString().Equals(sHosyousyoFlg))
					{
						// 月数を取得
						retHashRtfm = V01015Check.CheckMeisyo(
										 Td020p01Constant.SIKIBETSU_CD_RTFM
										,Td020p01Constant.SIKIBETSU_CD_RT_MEISYO_1
										,facadeContext);
						// 日数を取得
						retHashRtfd = V01015Check.CheckMeisyo(
										 Td020p01Constant.SIKIBETSU_CD_RTFD
										,Td020p01Constant.SIKIBETSU_CD_RT_MEISYO_1
										,facadeContext);

					}
					// // 発注MST.保証書発行フラグ=1
					else if( Td020p01Constant.FLG_ON.ToString().Equals(sHosyousyoFlg))
					{
						// 月数を取得
						retHashRtfm = V01015Check.CheckMeisyo(
										 Td020p01Constant.SIKIBETSU_CD_RTFM
										,Td020p01Constant.SIKIBETSU_CD_RT_MEISYO_2
										,facadeContext);
						// 日数を取得
						retHashRtfd = V01015Check.CheckMeisyo(
										 Td020p01Constant.SIKIBETSU_CD_RTFD
										,Td020p01Constant.SIKIBETSU_CD_RT_MEISYO_2
										,facadeContext);
					}
					if(retHashRtfm != null)
					{
						iWkRtfm = Convert.ToInt16(BoSystemString.Nvl(retHashRtfm["MEISYO_NM"].ToString(),"0")) * -1;
					}
					if(retHashRtfd != null)
					{
						iWkRtfd = Convert.ToInt16(BoSystemString.Nvl(retHashRtfd["MEISYO_NM"].ToString(), "0"));
					}

					// 判定日設定
					String wkHanteiYmd = BoSystemDate.toDatetime(Convert.ToString(sysDateVO.Sysdate)).AddMonths(iWkRtfm).AddDays(iWkRtfd).ToString("yyyyMMdd");

					// 発注MST．最新仕入日より判定 ＜＝ 判定日
					blRet = V03002Check.CodeFromToChk(sSaisinSiire, wkHanteiYmd);
				}
			}

			return blRet;
		}
		#endregion
		#region CSV取込チェック情報取得
		/// <summary>
		/// CSV取込チェック情報取得
		/// </summary>
		/// <param name="Td020f01Form">formVo</param>
		/// <returns>現在行数</returns>
		public static CsvCheckInfoVO GetCsvCheckVo (Td020f01Form formVo)
		{
			// ログイン情報取得
			LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();
			// CSVチェック情報を設定
			CsvCheckInfoVO csvCheckInfoVO = new CsvCheckInfoVO();
			csvCheckInfoVO.Index_scan_cd = 1;							// スキャンコードが格納されているインデックス
			// 項目情報
			CsvCheckItemInfoVO item = null;
			// 店舗コード
			item = new CsvCheckItemInfoVO();
			item.Item_id = "TENPO_CD";									// 項目ID
			item.Item_name = "店舗コード";								// 項目名
			item.Required_flg = true;									// 必須チェックフラグ
			item.Type_kbn = CsvCheckItemInfoVO.TYPE_KBN_HALF_NUM;		// 属性チェック区分
			item.Max_length = 4;										// 最大桁数
			item.Mst_check_id = CsvCheckItemInfoVO.MST_CHECK_ID_TENPO;  // マスタチェックID
			csvCheckInfoVO.List_csv_item_info.Add(item);
			// スキャンコード
			item = new CsvCheckItemInfoVO();
			item.Item_id = "SCAN_CD";                                   // 項目ID
			item.Item_name = "スキャンコード";                          // 項目名
			item.Required_flg = true;                                   // 必須チェックフラグ
			item.Type_kbn = CsvCheckItemInfoVO.TYPE_KBN_HALF_NUM;       // 属性チェック区分
			// 最大桁数チェックはIndex_scan_cdにより桁数チェックが行われるため不要
			item.Mst_check_id = CsvCheckItemInfoVO.MST_CHECK_ID_HATCHU; // マスタチェックID
			csvCheckInfoVO.List_csv_item_info.Add(item);
			// 数量
			item = new CsvCheckItemInfoVO();
			item.Item_id = "SURYO";                                     // 項目ID
			item.Item_name = "数量";                                    // 項目名
			item.Required_flg = true;                                   // 必須チェックフラグ
			item.Type_kbn = CsvCheckItemInfoVO.TYPE_KBN_NUMERIC;        // 属性チェック区分
			item.Max_length = 7;                                        // 最大桁数
			item.Zero_check_flg = true;                                 // ０チェックフラグ
			csvCheckInfoVO.List_csv_item_info.Add(item);
			return csvCheckInfoVO;
		}
		#endregion
	}
}
