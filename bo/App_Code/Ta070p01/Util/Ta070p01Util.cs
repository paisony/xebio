using com.xebio.bo.Ta070p01.Formvo;
using Common.Advanced.Formvo;
using Common.Business.C99999.StringUtil;
using System;
using System.Collections;

namespace com.xebio.bo.Ta070p01.Util
{
  /// <summary>
  /// Td050f01のユーティリティクラスです
  /// </summary>
  public partial class Ta070p01Util
	{
		#region 定数を設定します
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		private Ta070p01Util ()
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
				Ta070f01M1Form m1FormVO = (Ta070f01M1Form)m1List[i];

				// スキャンコード　または　依頼数に入力がある場合
				if (!string.IsNullOrEmpty(m1FormVO.M1scan_cd))
				{
					curRowCnt = i + 1;
					break;
				}
			}
			return curRowCnt;
		}
		#endregion
		#region ロット数チェック
		/// <summary>
		/// ロット数チェック
		/// </summary>
		/// <param name="string">lot_su</param>
		/// <param name="string">irai_su</param>
		/// <returns>bool(true:エラー,false:正常)</returns>
		public static bool ChkLotIrai ( string lot_su, string irai_su )
		{
			bool blRet = false;
			decimal wkLot = Convert.ToDecimal(BoSystemString.Nvl(lot_su, "0"));
			decimal wkIrai = Convert.ToDecimal(BoSystemString.Nvl(irai_su, "0"));

			// ロット数が０の場合
			if (wkLot == 0)
			{
				blRet = true;
			}
			// ロット数の方が大きい場合
			else if (wkLot > wkIrai)
			{
				blRet = true;
			}
			else
			{
				// 依頼数からロット数の剰余を計算
				decimal wkAmari = wkIrai % wkLot;
				// 余りが０でない場合は、エラー
				if (wkAmari != 0)
				{
					blRet = true;
				}
			}
			return blRet;
		}
		#endregion
		#region 売上実績数チェック
		/// <summary>
		/// 売上実績数チェック
		/// </summary>
		/// <param name="string">uriage_su</param>
		/// <param name="string">irai_su</param>
		/// <returns>bool(true:エラー,false:正常)</returns>
		public static bool ChkUriageIai ( string uriage_su, string irai_su )
		{
			bool blRet = false;
			decimal wkLot = Convert.ToDecimal(BoSystemString.Nvl(uriage_su, "0"));
			decimal wkIrai = Convert.ToDecimal(BoSystemString.Nvl(irai_su, "0")) * 2;

			// 依頼数の2倍値が実績数を超える場合
			if (wkLot < wkIrai)
			{
				blRet = true;
			}
			return blRet;
		}
		#endregion
		/// <summary>
		/// 空文字変換
		/// </summary>
		/// <param name="val">対象文字列</param>
		/// <returns>変換後の文字列</returns>
		public static string HashContains ( Hashtable val ,string sKey)
		{
			string rtn = "";
			if (val.ContainsKey(sKey))
			{
				try
				{
					rtn = (string)val[sKey];
				}
				catch
				{
					rtn = "";
				}
			}
			return rtn;
		}
		/// <summary>
		/// 空文字変換
		/// </summary>
		/// <param name="val">対象文字列</param>
		/// <returns>変換後の文字列</returns>
		public static string HashContainsDec ( Hashtable val, string sKey )
		{
			string rtn = "";
			if (val.ContainsKey(sKey))
			{
				try
				{
					rtn = ((decimal)val[sKey]).ToString();
				}
				catch
				{
					rtn = "";
				}
			}
			return rtn;
		}
		/// <summary>
		/// 文字列の右端から指定されたバイト数分の文字列を返します
		/// </summary>
		/// <param name="val">対象文字列</param>
		/// <param name="iByteSize">取り出すバイト数</param>
		/// <returns>変換後の文字列</returns>
		public static string RightB (string sVal,int iByteSize )
		{
			string sRet = sVal;
			if(!string.IsNullOrEmpty(sVal) && sVal.Length >= iByteSize)
			{
				sRet = BoSystemString.RightB(sVal, iByteSize);
			}
			return sRet;
		}
	}
}
