using Common.IntegrationMD.Interface;

namespace com.xebio.bo.Tm050p01.Formvo
{
  /// <summary>
  /// Tm050f01のFormオブジェクトです。
  /// </summary>
  [System.Serializable]
	public class Tm050f01FormCondition : IConditionVO
	{

		#region 実装可能
		//
		// 原則として、条件記憶対象となる項目のコメントをはずしてください。。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 項目「CSV_NM(CSV名称)」の値
		/// </summary>
		//private string _csv_nm;


		#endregion

		#region プロパティ
		/// <summary>
		/// 項目「CSV_NM(CSV名称)」の値を取得または設定する。
		/// </summary>
		//public virtual string Csv_nm
		//{
		//	get
		//	{
		//		return this._csv_nm;
		//	}
		//	set
		//	{
		//		this._csv_nm = value;
		//	}
		//}
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tm050f01FormCondition() : base()
		{
		}
		#endregion
	}
}
