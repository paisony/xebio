using com.xebio.bo.Te060p01.Constant;
using Common.Business.C01000.C01001;
using Common.Business.C99999.DateUtil;
using System;
using System.Text;

namespace com.xebio.bo.Te060p01.Util
{
  /// <summary>
  /// Te060f01のユーティリティクラスです
  /// </summary>
  public partial class Te060p01Util
	{
		#region 定数を設定します
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		private Te060p01Util ()
		{
		}
		#endregion
		/// <summary>
		/// 販売完了日初期値取得
		/// </summary>
		/// <param name="sysDateVO">SysDateVO</param>
		/// <returns>販売完了日</returns>
		public static string GetHanbaikanryoYmdInit( SysDateVO sysDateVO )
		{
			StringBuilder sbVal = new StringBuilder();
			sbVal.Append("");
			string strYYYY = BoSystemDate.toDatetime(Convert.ToString(sysDateVO.Sysdate)).ToString("yyyy");
			// 月日取得
			decimal dMMDD = Convert.ToDecimal(BoSystemDate.toDatetime(Convert.ToString(sysDateVO.Sysdate)).ToString("MMdd"));

			// システム日付が4/1～9/30の場合、当年の4/1
			if( dMMDD >= Te060p01Constant.DATE_0401_FROM    
			 && dMMDD <= Te060p01Constant.DATE_0401_TO)
			{
				// 当年設定
				sbVal.Append(BoSystemDate.toDatetime(Convert.ToString(sysDateVO.Sysdate)).ToString("yyyy"));
				// 月日設定
				sbVal.Append(Te060p01Constant.HANBAIKANRYO_YMD_DEF_PTN1);

			} 
			// システム日付が10/1～12/31の場合、当年の10/1
			else if(dMMDD >= Te060p01Constant.DATE_1001_FROM    
			     && dMMDD <= Te060p01Constant.DATE_1001_TO)
			{
				// 当年設定
				sbVal.Append(BoSystemDate.toDatetime(Convert.ToString(sysDateVO.Sysdate)).ToString("yyyy"));
				// 月日設定
				sbVal.Append(Te060p01Constant.HANBAIKANRYO_YMD_DEF_PTN2);

			}
			// システム日付が1/1～3/31の場合、前年の10/1
			else if (dMMDD >= Te060p01Constant.DATE_1001_ZEN_FROM
				 && dMMDD <= Te060p01Constant.DATE_1001_ZEN_TO)
			{
				// 前年設定
				sbVal.Append(BoSystemDate.toDatetime(Convert.ToString(sysDateVO.Sysdate)).AddYears(-1).ToString("yyyy"));
				// 月日設定
				sbVal.Append(Te060p01Constant.HANBAIKANRYO_YMD_DEF_PTN2);
			}
			return sbVal.ToString();
		}
	}
}
