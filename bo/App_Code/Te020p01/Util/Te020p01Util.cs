using com.xebio.bo.Te020p01.Formvo;
using Common.Advanced.Formvo;
using Common.Business.C01000.C01024;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.StringUtil;
using Common.Standard.Login;
using System;

namespace com.xebio.bo.Te020p01.Util
{
  /// <summary>
  /// Te020f01のユーティリティクラスです
  /// </summary>
  public partial class Te020p01Util
	{
		#region 定数を設定します
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		private Te020p01Util ()
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
				Te020f01M1Form m1FormVO = (Te020f01M1Form)m1List[i];

				// スキャンコード　または　出荷数量に入力がある場合
				if (!string.IsNullOrEmpty(m1FormVO.M1scan_cd)
				 || !string.IsNullOrEmpty(m1FormVO.M1syukka_su))
				{
					curRowCnt = i + 1;
					break;
				}
			}
			return curRowCnt;
		}
		#endregion
		#region CSV取込チェック情報取得
		/// <summary>
		/// CSV取込チェック情報取得
		/// </summary>
		/// <param name="Te020f01Form">formVo</param>
		/// <returns>現在行数</returns>
		public static CsvCheckInfoVO GetCsvCheckVo (Te020f01Form formVo)
		{
			// ログイン情報取得
			LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();
			// CSVチェック情報を設定
			CsvCheckInfoVO csvCheckInfoVO = new CsvCheckInfoVO();
			csvCheckInfoVO.Index_scan_cd = 2;							// スキャンコードが格納されているインデックス
			// 項目情報
			CsvCheckItemInfoVO item = null;
			// 出荷店コード
			item = new CsvCheckItemInfoVO();
			item.Item_id = "SYUKKA_TENPO_CD";							// 項目ID
			item.Item_name = "出荷店コード";							// 項目名
			item.Required_flg = true;									// 必須チェックフラグ
			item.Type_kbn = CsvCheckItemInfoVO.TYPE_KBN_HALF_NUM;		// 属性チェック区分
			item.Max_length = 4;										// 最大桁数
			item.Mst_check_id = CsvCheckItemInfoVO.MST_CHECK_ID_TENPO;  // マスタチェックID
			item.Shukka_ten_cd = formVo.Head_tenpo_cd;					// 出荷店コード
	
			csvCheckInfoVO.List_csv_item_info.Add(item);
			// 入荷店コード
			item = new CsvCheckItemInfoVO();
			item.Item_id = "JYURYO_TENPO_CD";							// 項目ID
			item.Item_name = "入荷店コード";							// 項目名
			item.Required_flg = true;									// 必須チェックフラグ
			item.Type_kbn = CsvCheckItemInfoVO.TYPE_KBN_HALF_NUM;		// 属性チェック区分
			item.Max_length = 4;										// 最大桁数
			item.Mst_check_id = CsvCheckItemInfoVO.MST_CHECK_ID_TENPO;  // マスタチェックID
			item.Nyuka_ten_cd = formVo.Jyuryoten_cd;					// 入荷店コード
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
			item.Max_length = 6;                                        // 最大桁数
			item.Zero_check_flg = true;                                 // ０チェックフラグ
			csvCheckInfoVO.List_csv_item_info.Add(item);
			return csvCheckInfoVO;
		}
		#endregion
		#region 指示番号後１０桁取得
		/// <summary>
		/// 指示番号後１０桁取得
		/// </summary>
		/// <param name="string">Siji_bango</param>
		/// <returns>現在行数</returns>
		public static decimal GetSijiBango10 ( string Siji_bango )
		{
			// 指示番号設定
			decimal dSijiNo = 0;
			dSijiNo = Convert.ToDecimal(BoSystemString.Nvl(BoSystemFormat.IdoSijiNoGetSijino(Siji_bango),"0"));
			return dSijiNo;
		}
		#endregion
	}
}
