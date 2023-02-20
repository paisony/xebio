using com.xebio.bo.Te010p01.Constant;
using com.xebio.bo.Te010p01.Formvo;
using Common.Business.C99999.Constant;
using Common.Business.C99999.StringUtil;
using Common.Conditions;
using System;

namespace com.xebio.bo.Te010p01.Util
{
  /// <summary>
  /// Te010f01のユーティリティクラスです
  /// </summary>
  public partial class Te010p01Util
	{
		#region 定数を設定します
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		private Te010p01Util ()
		{
		}
		#endregion
		#region 参照テーブル判定
		/// <summary>
		/// GetRefTbl 参照テーブル判定
		/// </summary>
		/// <param name="Denpyo_jyotai">string</param>
		/// <returns>string</returns>
		public static string GetRefTbl ( string Denpyo_jyotai)
		{
			string ref_tbl = "";
			// [伝票状態]が空白、「確定」、「ﾏﾆｭｱﾙ出荷」、「入荷店未処理」、「差異あり」の場合、移動出荷確定テーブルから検索する。
			if (string.IsNullOrEmpty(Denpyo_jyotai)
			|| Denpyo_jyotai.Equals(BoSystemConstant.DROPDOWNLIST_MISENTAKU)
			|| ConditionIdoshukka_denpyo_jotai.VALUE_DENPYO_JOTAI1.Equals(Denpyo_jyotai)
			|| ConditionIdoshukka_denpyo_jotai.VALUE_DENPYO_JOTAI2.Equals(Denpyo_jyotai)
			|| ConditionIdoshukka_denpyo_jotai.VALUE_DENPYO_JOTAI6.Equals(Denpyo_jyotai)
			|| ConditionIdoshukka_denpyo_jotai.VALUE_DENPYO_JOTAI3.Equals(Denpyo_jyotai))
			{
				// 参照テーブル 移動出荷確定TBL
				ref_tbl = Te010p01Constant.REF_TBL_KAKU;
			}
			// [伝票状態]が「登録履歴」、「取消履歴」の場合、移動出荷履歴テーブルから検索する。
			else
			{
				// 参照テーブル 移動出荷履歴TBL
				ref_tbl = Te010p01Constant.REF_TBL_RIREKI;
			}
			return ref_tbl;
		}
		#endregion
		#region 原価金額設定
		/// <summary>
		/// SetGenkaKin 原価金額設定
		/// </summary>
		/// <param name="string">jyuryo_ymd</param>
		/// <param name="Te010f02M1Form">f02m1VO</param>
		/// <returns></returns>
		public static void SetGenkaKin ( string jyuryo_ymd, Te010f02M1Form f02m1VO)
		{
			// Ｍ１出荷数量（梱包単位）
			decimal wkSyukka_su = Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1syukka_su,"0"));
			// Ｍ１確定数量
			decimal wkKakutei_su = Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1kakutei_su,"0"));
			// Ｍ１原単価
			decimal wkGen_tnk = Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1gen_tnk,"0"));

			// 移動出荷検索-一覧の[Ｍ１入荷日]が空白の場合
			if(string.IsNullOrEmpty(jyuryo_ymd))
			{
	　			// [Ｍ１出荷数量（梱包単位）]×[Ｍ１原単価]
				f02m1VO.M1genkakin = (wkSyukka_su * wkGen_tnk).ToString();
			}
			// それ以外
			else
			{
	　			 // [Ｍ１確定数量]×[Ｍ１原単価]
				f02m1VO.M1genkakin = (wkKakutei_su * wkGen_tnk).ToString();
			}
		}
		#endregion

	}
}
