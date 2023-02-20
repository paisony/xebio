using com.xebio.bo.Te040p01.Formvo;
using Common.Advanced.Formvo;

namespace com.xebio.bo.Te040p01.Util
{
  /// <summary>
  /// Te040f01のユーティリティクラスです
  /// </summary>
  public partial class Te040p01Util
	{
		#region 定数を設定します
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		private Te040p01Util ()
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
				Te040f01M1Form m1FormVO = (Te040f01M1Form)m1List[i];

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
	}
}
