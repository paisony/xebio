using System;

namespace com.xebio.bo.Ta080p01.Util
{
  /// <summary>
  /// 発注マスタ取得の検索用情報を保持するValueObjectです。
  /// </summary>
  [Serializable]
	public class TanpinErrMsgVO
	{
		#region フィールド

		/// <summary>
		/// メッセージID
		/// </summary>
		private string _id = "";
		/// <summary>
		/// パラメータ
		/// </summary>
		private string _param = "";

		/// <summary>
		/// エラー項目
		/// </summary>
		private string[] _item = null;
		/// <summary>
		/// 行番号
		/// </summary>
		private string _num = string.Empty;
		/// <summary>
		/// 行インデックス
		/// </summary>
		private string _index = string.Empty;
		/// <summary>
		/// 明細ID
		/// </summary>
		private string _meisaiid = string.Empty;
		/// <summary>
		/// 明細表示件数
		/// </summary>
		private int _dispRow = 0;

		#endregion

		#region プロパティ


		/// <summary>
		/// メッセージIDを取得または設定します。
		/// </summary>
		public string Id
		{
			get { return _id; }
			set { _id = value; }
		}
		/// <summary>
		/// パラメータを取得または設定します。
		/// </summary>
		public string Param
		{
			get { return _param; }
			set { _param = value; }
		}
		/// <summary>
		/// エラー項目を取得または設定します。
		/// </summary>
		public string[] Item
		{
			get { return _item; }
			set { _item = value; }
		}
		/// <summary>
		/// 行番号 を取得または設定します。
		/// </summary>
		public string Num
		{
			get { return _num; }
			set { _num = value; }
		}
		/// <summary>
		/// 行インデックス を取得または設定します。
		/// </summary>
		public string Index
		{
			get { return _index; }
			set { _index = value; }
		}
		/// <summary>
		/// 明細ID を取得または設定します。
		/// </summary>
		public string Meisaiid
		{
			get { return _meisaiid; }
			set { _meisaiid = value; }
		}
		/// <summary>
		/// 入荷予定数		検索フラグ を取得または設定します。
		/// </summary>
		public int DispRow
		{
			get { return _dispRow; }
			set { _dispRow = value; }
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public TanpinErrMsgVO()
		{
		}

		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		/// <param name="id">メッセージID</param>
		/// <param name="param">パラメータ</param>
		/// <param name="item">エラー項目</param>
		/// <param name="num">行番号</param>
		/// <param name="index">行インデックス</param>
		/// <param name="meisaiid">明細ID</param>
		/// <param name="dispRow">明細表示金数</param>
		public TanpinErrMsgVO(string id,
							string param,
							string[] item,
							string num,
							string index,
							string meisaiid,
							int dispRow
		)
		{
			Id = id;
			Param = param;
			Item = item;
			Num = num;
			Index = index;
			Meisaiid = meisaiid;
			DispRow = dispRow;
		}

		#endregion
	}
}