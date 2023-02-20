using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tj160p01.VO
{
  /// <summary>
  /// 棚卸チェックリスト編集用のValueObjectです。
  /// </summary>
  [Serializable]
	public class Tj160M1ModelVO : StandardBaseVO
	{
		#region フィールド
		/// <summary>
		/// 店舗コード
		/// </summary>
		private String _tenpo_cd;
		/// <summary>
		/// 店舗名
		/// </summary>
		private String _tenpo_nm;
		/// <summary>
		/// フェイスNO
		/// </summary>
		private String _face_no;
		/// <summary>
		/// 棚段
		/// </summary>
		private String _tana_dan;
		/// <summary>
		/// 重複
		/// </summary>
		private String _tyohuku;
		/// <summary>
		/// 更新担当者コード
		/// </summary>
		private String _upd_tancd;
		/// <summary>
		/// 担当者名
		/// </summary>
		private String _hanbaiin_nm;
		/// <summary>
		/// データフラグ
		/// </summary>
		private String _data_flg;
		/// <summary>
		/// メモ
		/// </summary>
		private String _memo;

		#endregion

		#region プロパティ
		/// <summary>
		/// 店舗コードを取得または設定します。
		/// </summary>
		public String tenpo_cd
		{
			get { return _tenpo_cd; }
			set { _tenpo_cd = value; }
		}
		/// <summary>
		/// 店舗名を取得または設定します。
		/// </summary>
		public String tenpo_nm
		{
			get { return _tenpo_nm; }
			set { _tenpo_nm = value; }
		}
		/// <summary>
		/// フェイスNOを取得または設定します。
		/// </summary>
		public String face_no
		{
			get { return _face_no; }
			set { _face_no = value; }
		}
		/// <summary>
		/// 棚段を取得または設定します。
		/// </summary>
		public String tana_dan
		{
			get { return _tana_dan; }
			set { _tana_dan = value; }
		}
		/// <summary>
		/// 重複有無を取得または設定します。
		/// </summary>
		public String tyohuku
		{
			get { return _tyohuku; }
			set { _tyohuku = value; }
		}
		/// <summary>
		/// 更新担当者コードを取得または設定します。
		/// </summary>
		public String upd_tancd
		{
			get { return _upd_tancd; }
			set { _upd_tancd = value; }
		}
		/// <summary>
		/// 担当者名を取得または設定します。
		/// </summary>
		public String hanbaiin_nm
		{
			get { return _hanbaiin_nm; }
			set { _hanbaiin_nm = value; }
		}
		/// <summary>
		/// データフラグを取得または設定します。
		/// </summary>
		public String data_flg
		{
			get { return _data_flg; }
			set { _data_flg = value; }
		}
		/// <summary>
		/// メモを取得または設定します。
		/// </summary>
		public String memo
		{
			get { return _memo; }
			set { _memo = value; }
		}
		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tj160M1ModelVO()
			: base()
		{
		}

		#endregion
	}
}