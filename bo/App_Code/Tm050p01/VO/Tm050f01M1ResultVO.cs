﻿using Common.Standard.Base;
using System;
using System.Text;

namespace com.xebio.bo.Tm050p01.VO
{
  /// <summary>
  /// Tm050f01 明細M1のResultVOクラスです。
  ///
  /// </summary>
  [Serializable]
	public class Tm050f01M1ResultVO : StandardBaseVO
	{

		#region フィールド
		/// <summary>
		/// 項目「M1ROWNO(No.)」の値
		/// </summary>
		private string _m1rowno;

		/// <summary>
		/// 項目「M1ERR_NM(エラー内容)」の値
		/// </summary>
		private string _m1err_nm;

		#endregion

		#region プロパティ
		/// <summary>
		/// 項目「M1ROWNO(No.)」の値を取得または設定する。
		/// </summary>
		public virtual string M1rowno
		{
			get
			{
				return this._m1rowno;
			}
			set
			{
				this._m1rowno = value;
			}
		}

		/// <summary>
		/// 項目「M1ERR_NM(エラー内容)」の値を取得または設定する。
		/// </summary>
		public virtual string M1err_nm
		{
			get
			{
				return this._m1err_nm;
			}
			set
			{
				this._m1err_nm = value;
			}
		}


		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tm050f01M1ResultVO() : base()
		{
		}
		#endregion

		#region メソッド
		
		/// <summary>
		/// 引数のオブジェクトと比較する。
		/// </summary>
		/// <param name="obj">比較するオブジェクト</param>
		/// <returns>結果</returns>
		public override bool Equals(object obj)
		{
			Tm050f01M1ResultVO compare = null;
			if (obj is Tm050f01M1ResultVO)
			{
				compare = (Tm050f01M1ResultVO)obj;
			}
			else
			{
				return false;
			}

			if (_m1rowno != compare.M1rowno)
			{
				return false;
			}
			if (_m1err_nm != compare.M1err_nm)
			{
				return false;
			}

			return true;
		}
		/// <summary>
		/// 特定の型のハッシュ関数として機能します。
		/// ハッシュ アルゴリズムや、ハッシュ テーブルのようなデータ構造での使用に適しています。
		/// </summary>
		/// <returns>現在のcom.xebio.bo.Tm050p01.Formvo.Tm050f01M1Formのハッシュ コード。</returns>
		public override int GetHashCode()
		{
			return this.ToString().GetHashCode();
		}
		/// <summary>
		/// このオブジェクトの内容を文字列で取得する。
		/// </summary>
		/// <returns>オブジェクトの内容</returns>
		public override string ToString()
		{
			StringBuilder str = new StringBuilder();

			str.Append("M1rowno:").Append(this._m1rowno).AppendLine();
			str.Append("M1err_nm:").Append(this._m1err_nm).AppendLine();

			return str.ToString();
		}
		#endregion

	}
}
