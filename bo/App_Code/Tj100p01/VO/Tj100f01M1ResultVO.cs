using Common.Standard.Base;
using System;
using System.Text;

namespace com.xebio.bo.Tj100p01.VO
{
  /// <summary>
  /// Tj100f01 明細M1のResultVOクラスです。
  ///
  /// </summary>
  [Serializable]
	public class Tj100f01M1ResultVO : StandardBaseVO
	{

		#region フィールド
		/// <summary>
		/// 項目「M1ROWNO(No.)」の値
		/// </summary>
		private string _m1rowno;

		/// <summary>
		/// 項目「M1FACE_NO(フェイスNo)」の値
		/// </summary>
		private string _m1face_no;

		/// <summary>
		/// 項目「M1TANA_DAN(棚段)」の値
		/// </summary>
		private string _m1tana_dan;

		/// <summary>
		/// 項目「M1SELECTORCHECKBOX()」の値
		/// </summary>
		private string _m1selectorcheckbox;

		/// <summary>
		/// 項目「M1ENTERSYORIFLG()」の値
		/// </summary>
		private string _m1entersyoriflg;

		/// <summary>
		/// 項目「M1DTLIROKBN()」の値
		/// </summary>
		private string _m1dtlirokbn;

		/// <summary>
		/// 項目「M1ROWNO2(No.)」の値
		/// </summary>
		private string _m1rowno2;

		/// <summary>
		/// 項目「M1FACE_NO2(フェイスNo)」の値
		/// </summary>
		private string _m1face_no2;

		/// <summary>
		/// 項目「M1TANA_DAN2(棚段)」の値
		/// </summary>
		private string _m1tana_dan2;

		/// <summary>
		/// 項目「M1SELECTORCHECKBOX2()」の値
		/// </summary>
		private string _m1selectorcheckbox2;

		/// <summary>
		/// 項目「M1ENTERSYORIFLG2()」の値
		/// </summary>
		private string _m1entersyoriflg2;

		/// <summary>
		/// 項目「M1DTLIROKBN2()」の値
		/// </summary>
		private string _m1dtlirokbn2;

		/// <summary>
		/// 項目「M1ROWNO3(No.)」の値
		/// </summary>
		private string _m1rowno3;

		/// <summary>
		/// 項目「M1FACE_NO3(フェイスNo)」の値
		/// </summary>
		private string _m1face_no3;

		/// <summary>
		/// 項目「M1TANA_DAN3(棚段)」の値
		/// </summary>
		private string _m1tana_dan3;

		/// <summary>
		/// 項目「M1SELECTORCHECKBOX3()」の値
		/// </summary>
		private string _m1selectorcheckbox3;

		/// <summary>
		/// 項目「M1ENTERSYORIFLG3()」の値
		/// </summary>
		private string _m1entersyoriflg3;

		/// <summary>
		/// 項目「M1DTLIROKBN3()」の値
		/// </summary>
		private string _m1dtlirokbn3;

		/// <summary>
		/// 項目「M1ROWNO4(No.)」の値
		/// </summary>
		private string _m1rowno4;

		/// <summary>
		/// 項目「M1FACE_NO4(フェイスNo)」の値
		/// </summary>
		private string _m1face_no4;

		/// <summary>
		/// 項目「M1TANA_DAN4(棚段)」の値
		/// </summary>
		private string _m1tana_dan4;

		/// <summary>
		/// 項目「M1SELECTORCHECKBOX4()」の値
		/// </summary>
		private string _m1selectorcheckbox4;

		/// <summary>
		/// 項目「M1ENTERSYORIFLG4()」の値
		/// </summary>
		private string _m1entersyoriflg4;

		/// <summary>
		/// 項目「M1DTLIROKBN4()」の値
		/// </summary>
		private string _m1dtlirokbn4;

		/// <summary>
		/// 項目「M1ROWNO5(No.)」の値
		/// </summary>
		private string _m1rowno5;

		/// <summary>
		/// 項目「M1FACE_NO5(フェイスNo)」の値
		/// </summary>
		private string _m1face_no5;

		/// <summary>
		/// 項目「M1TANA_DAN5(棚段)」の値
		/// </summary>
		private string _m1tana_dan5;

		/// <summary>
		/// 項目「M1SELECTORCHECKBOX5()」の値
		/// </summary>
		private string _m1selectorcheckbox5;

		/// <summary>
		/// 項目「M1ENTERSYORIFLG5()」の値
		/// </summary>
		private string _m1entersyoriflg5;

		/// <summary>
		/// 項目「M1DTLIROKBN5()」の値
		/// </summary>
		private string _m1dtlirokbn5;

		/// <summary>
		/// 項目「M1ROWNO6(No.)」の値
		/// </summary>
		private string _m1rowno6;

		/// <summary>
		/// 項目「M1FACE_NO6(フェイスNo)」の値
		/// </summary>
		private string _m1face_no6;

		/// <summary>
		/// 項目「M1TANA_DAN6(棚段)」の値
		/// </summary>
		private string _m1tana_dan6;

		/// <summary>
		/// 項目「M1SELECTORCHECKBOX6()」の値
		/// </summary>
		private string _m1selectorcheckbox6;

		/// <summary>
		/// 項目「M1ENTERSYORIFLG6()」の値
		/// </summary>
		private string _m1entersyoriflg6;

		/// <summary>
		/// 項目「M1DTLIROKBN6()」の値
		/// </summary>
		private string _m1dtlirokbn6;

		/// <summary>
		/// 項目「M1ROWNO7(No.)」の値
		/// </summary>
		private string _m1rowno7;

		/// <summary>
		/// 項目「M1FACE_NO7(フェイスNo)」の値
		/// </summary>
		private string _m1face_no7;

		/// <summary>
		/// 項目「M1TANA_DAN7(棚段)」の値
		/// </summary>
		private string _m1tana_dan7;

		/// <summary>
		/// 項目「M1SELECTORCHECKBOX7()」の値
		/// </summary>
		private string _m1selectorcheckbox7;

		/// <summary>
		/// 項目「M1ENTERSYORIFLG7()」の値
		/// </summary>
		private string _m1entersyoriflg7;

		/// <summary>
		/// 項目「M1DTLIROKBN7()」の値
		/// </summary>
		private string _m1dtlirokbn7;

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
		/// 項目「M1FACE_NO(フェイスNo)」の値を取得または設定する。
		/// </summary>
		public virtual string M1face_no
		{
			get
			{
				return this._m1face_no;
			}
			set
			{
				this._m1face_no = value;
			}
		}

		/// <summary>
		/// 項目「M1TANA_DAN(棚段)」の値を取得または設定する。
		/// </summary>
		public virtual string M1tana_dan
		{
			get
			{
				return this._m1tana_dan;
			}
			set
			{
				this._m1tana_dan = value;
			}
		}

		/// <summary>
		/// 項目「M1SELECTORCHECKBOX()」の値を取得または設定する。
		/// </summary>
		public virtual string M1selectorcheckbox
		{
			get
			{
				return this._m1selectorcheckbox;
			}
			set
			{
				this._m1selectorcheckbox = value;
			}
		}

		/// <summary>
		/// 項目「M1ENTERSYORIFLG()」の値を取得または設定する。
		/// </summary>
		public virtual string M1entersyoriflg
		{
			get
			{
				return this._m1entersyoriflg;
			}
			set
			{
				this._m1entersyoriflg = value;
			}
		}

		/// <summary>
		/// 項目「M1DTLIROKBN()」の値を取得または設定する。
		/// </summary>
		public virtual string M1dtlirokbn
		{
			get
			{
				return this._m1dtlirokbn;
			}
			set
			{
				this._m1dtlirokbn = value;
			}
		}

		/// <summary>
		/// 項目「M1ROWNO2(No.)」の値を取得または設定する。
		/// </summary>
		public virtual string M1rowno2
		{
			get
			{
				return this._m1rowno2;
			}
			set
			{
				this._m1rowno2 = value;
			}
		}

		/// <summary>
		/// 項目「M1FACE_NO2(フェイスNo)」の値を取得または設定する。
		/// </summary>
		public virtual string M1face_no2
		{
			get
			{
				return this._m1face_no2;
			}
			set
			{
				this._m1face_no2 = value;
			}
		}

		/// <summary>
		/// 項目「M1TANA_DAN2(棚段)」の値を取得または設定する。
		/// </summary>
		public virtual string M1tana_dan2
		{
			get
			{
				return this._m1tana_dan2;
			}
			set
			{
				this._m1tana_dan2 = value;
			}
		}

		/// <summary>
		/// 項目「M1SELECTORCHECKBOX2()」の値を取得または設定する。
		/// </summary>
		public virtual string M1selectorcheckbox2
		{
			get
			{
				return this._m1selectorcheckbox2;
			}
			set
			{
				this._m1selectorcheckbox2 = value;
			}
		}

		/// <summary>
		/// 項目「M1ENTERSYORIFLG2()」の値を取得または設定する。
		/// </summary>
		public virtual string M1entersyoriflg2
		{
			get
			{
				return this._m1entersyoriflg2;
			}
			set
			{
				this._m1entersyoriflg2 = value;
			}
		}

		/// <summary>
		/// 項目「M1DTLIROKBN2()」の値を取得または設定する。
		/// </summary>
		public virtual string M1dtlirokbn2
		{
			get
			{
				return this._m1dtlirokbn2;
			}
			set
			{
				this._m1dtlirokbn2 = value;
			}
		}

		/// <summary>
		/// 項目「M1ROWNO3(No.)」の値を取得または設定する。
		/// </summary>
		public virtual string M1rowno3
		{
			get
			{
				return this._m1rowno3;
			}
			set
			{
				this._m1rowno3 = value;
			}
		}

		/// <summary>
		/// 項目「M1FACE_NO3(フェイスNo)」の値を取得または設定する。
		/// </summary>
		public virtual string M1face_no3
		{
			get
			{
				return this._m1face_no3;
			}
			set
			{
				this._m1face_no3 = value;
			}
		}

		/// <summary>
		/// 項目「M1TANA_DAN3(棚段)」の値を取得または設定する。
		/// </summary>
		public virtual string M1tana_dan3
		{
			get
			{
				return this._m1tana_dan3;
			}
			set
			{
				this._m1tana_dan3 = value;
			}
		}

		/// <summary>
		/// 項目「M1SELECTORCHECKBOX3()」の値を取得または設定する。
		/// </summary>
		public virtual string M1selectorcheckbox3
		{
			get
			{
				return this._m1selectorcheckbox3;
			}
			set
			{
				this._m1selectorcheckbox3 = value;
			}
		}

		/// <summary>
		/// 項目「M1ENTERSYORIFLG3()」の値を取得または設定する。
		/// </summary>
		public virtual string M1entersyoriflg3
		{
			get
			{
				return this._m1entersyoriflg3;
			}
			set
			{
				this._m1entersyoriflg3 = value;
			}
		}

		/// <summary>
		/// 項目「M1DTLIROKBN3()」の値を取得または設定する。
		/// </summary>
		public virtual string M1dtlirokbn3
		{
			get
			{
				return this._m1dtlirokbn3;
			}
			set
			{
				this._m1dtlirokbn3 = value;
			}
		}

		/// <summary>
		/// 項目「M1ROWNO4(No.)」の値を取得または設定する。
		/// </summary>
		public virtual string M1rowno4
		{
			get
			{
				return this._m1rowno4;
			}
			set
			{
				this._m1rowno4 = value;
			}
		}

		/// <summary>
		/// 項目「M1FACE_NO4(フェイスNo)」の値を取得または設定する。
		/// </summary>
		public virtual string M1face_no4
		{
			get
			{
				return this._m1face_no4;
			}
			set
			{
				this._m1face_no4 = value;
			}
		}

		/// <summary>
		/// 項目「M1TANA_DAN4(棚段)」の値を取得または設定する。
		/// </summary>
		public virtual string M1tana_dan4
		{
			get
			{
				return this._m1tana_dan4;
			}
			set
			{
				this._m1tana_dan4 = value;
			}
		}

		/// <summary>
		/// 項目「M1SELECTORCHECKBOX4()」の値を取得または設定する。
		/// </summary>
		public virtual string M1selectorcheckbox4
		{
			get
			{
				return this._m1selectorcheckbox4;
			}
			set
			{
				this._m1selectorcheckbox4 = value;
			}
		}

		/// <summary>
		/// 項目「M1ENTERSYORIFLG4()」の値を取得または設定する。
		/// </summary>
		public virtual string M1entersyoriflg4
		{
			get
			{
				return this._m1entersyoriflg4;
			}
			set
			{
				this._m1entersyoriflg4 = value;
			}
		}

		/// <summary>
		/// 項目「M1DTLIROKBN4()」の値を取得または設定する。
		/// </summary>
		public virtual string M1dtlirokbn4
		{
			get
			{
				return this._m1dtlirokbn4;
			}
			set
			{
				this._m1dtlirokbn4 = value;
			}
		}

		/// <summary>
		/// 項目「M1ROWNO5(No.)」の値を取得または設定する。
		/// </summary>
		public virtual string M1rowno5
		{
			get
			{
				return this._m1rowno5;
			}
			set
			{
				this._m1rowno5 = value;
			}
		}

		/// <summary>
		/// 項目「M1FACE_NO5(フェイスNo)」の値を取得または設定する。
		/// </summary>
		public virtual string M1face_no5
		{
			get
			{
				return this._m1face_no5;
			}
			set
			{
				this._m1face_no5 = value;
			}
		}

		/// <summary>
		/// 項目「M1TANA_DAN5(棚段)」の値を取得または設定する。
		/// </summary>
		public virtual string M1tana_dan5
		{
			get
			{
				return this._m1tana_dan5;
			}
			set
			{
				this._m1tana_dan5 = value;
			}
		}

		/// <summary>
		/// 項目「M1SELECTORCHECKBOX5()」の値を取得または設定する。
		/// </summary>
		public virtual string M1selectorcheckbox5
		{
			get
			{
				return this._m1selectorcheckbox5;
			}
			set
			{
				this._m1selectorcheckbox5 = value;
			}
		}

		/// <summary>
		/// 項目「M1ENTERSYORIFLG5()」の値を取得または設定する。
		/// </summary>
		public virtual string M1entersyoriflg5
		{
			get
			{
				return this._m1entersyoriflg5;
			}
			set
			{
				this._m1entersyoriflg5 = value;
			}
		}

		/// <summary>
		/// 項目「M1DTLIROKBN5()」の値を取得または設定する。
		/// </summary>
		public virtual string M1dtlirokbn5
		{
			get
			{
				return this._m1dtlirokbn5;
			}
			set
			{
				this._m1dtlirokbn5 = value;
			}
		}

		/// <summary>
		/// 項目「M1ROWNO6(No.)」の値を取得または設定する。
		/// </summary>
		public virtual string M1rowno6
		{
			get
			{
				return this._m1rowno6;
			}
			set
			{
				this._m1rowno6 = value;
			}
		}

		/// <summary>
		/// 項目「M1FACE_NO6(フェイスNo)」の値を取得または設定する。
		/// </summary>
		public virtual string M1face_no6
		{
			get
			{
				return this._m1face_no6;
			}
			set
			{
				this._m1face_no6 = value;
			}
		}

		/// <summary>
		/// 項目「M1TANA_DAN6(棚段)」の値を取得または設定する。
		/// </summary>
		public virtual string M1tana_dan6
		{
			get
			{
				return this._m1tana_dan6;
			}
			set
			{
				this._m1tana_dan6 = value;
			}
		}

		/// <summary>
		/// 項目「M1SELECTORCHECKBOX6()」の値を取得または設定する。
		/// </summary>
		public virtual string M1selectorcheckbox6
		{
			get
			{
				return this._m1selectorcheckbox6;
			}
			set
			{
				this._m1selectorcheckbox6 = value;
			}
		}

		/// <summary>
		/// 項目「M1ENTERSYORIFLG6()」の値を取得または設定する。
		/// </summary>
		public virtual string M1entersyoriflg6
		{
			get
			{
				return this._m1entersyoriflg6;
			}
			set
			{
				this._m1entersyoriflg6 = value;
			}
		}

		/// <summary>
		/// 項目「M1DTLIROKBN6()」の値を取得または設定する。
		/// </summary>
		public virtual string M1dtlirokbn6
		{
			get
			{
				return this._m1dtlirokbn6;
			}
			set
			{
				this._m1dtlirokbn6 = value;
			}
		}

		/// <summary>
		/// 項目「M1ROWNO7(No.)」の値を取得または設定する。
		/// </summary>
		public virtual string M1rowno7
		{
			get
			{
				return this._m1rowno7;
			}
			set
			{
				this._m1rowno7 = value;
			}
		}

		/// <summary>
		/// 項目「M1FACE_NO7(フェイスNo)」の値を取得または設定する。
		/// </summary>
		public virtual string M1face_no7
		{
			get
			{
				return this._m1face_no7;
			}
			set
			{
				this._m1face_no7 = value;
			}
		}

		/// <summary>
		/// 項目「M1TANA_DAN7(棚段)」の値を取得または設定する。
		/// </summary>
		public virtual string M1tana_dan7
		{
			get
			{
				return this._m1tana_dan7;
			}
			set
			{
				this._m1tana_dan7 = value;
			}
		}

		/// <summary>
		/// 項目「M1SELECTORCHECKBOX7()」の値を取得または設定する。
		/// </summary>
		public virtual string M1selectorcheckbox7
		{
			get
			{
				return this._m1selectorcheckbox7;
			}
			set
			{
				this._m1selectorcheckbox7 = value;
			}
		}

		/// <summary>
		/// 項目「M1ENTERSYORIFLG7()」の値を取得または設定する。
		/// </summary>
		public virtual string M1entersyoriflg7
		{
			get
			{
				return this._m1entersyoriflg7;
			}
			set
			{
				this._m1entersyoriflg7 = value;
			}
		}

		/// <summary>
		/// 項目「M1DTLIROKBN7()」の値を取得または設定する。
		/// </summary>
		public virtual string M1dtlirokbn7
		{
			get
			{
				return this._m1dtlirokbn7;
			}
			set
			{
				this._m1dtlirokbn7 = value;
			}
		}


		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tj100f01M1ResultVO() : base()
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
			Tj100f01M1ResultVO compare = null;
			if (obj is Tj100f01M1ResultVO)
			{
				compare = (Tj100f01M1ResultVO)obj;
			}
			else
			{
				return false;
			}

			if (_m1rowno != compare.M1rowno)
			{
				return false;
			}
			if (_m1face_no != compare.M1face_no)
			{
				return false;
			}
			if (_m1tana_dan != compare.M1tana_dan)
			{
				return false;
			}
			if (_m1selectorcheckbox != compare.M1selectorcheckbox)
			{
				return false;
			}
			if (_m1entersyoriflg != compare.M1entersyoriflg)
			{
				return false;
			}
			if (_m1dtlirokbn != compare.M1dtlirokbn)
			{
				return false;
			}
			if (_m1rowno2 != compare.M1rowno2)
			{
				return false;
			}
			if (_m1face_no2 != compare.M1face_no2)
			{
				return false;
			}
			if (_m1tana_dan2 != compare.M1tana_dan2)
			{
				return false;
			}
			if (_m1selectorcheckbox2 != compare.M1selectorcheckbox2)
			{
				return false;
			}
			if (_m1entersyoriflg2 != compare.M1entersyoriflg2)
			{
				return false;
			}
			if (_m1dtlirokbn2 != compare.M1dtlirokbn2)
			{
				return false;
			}
			if (_m1rowno3 != compare.M1rowno3)
			{
				return false;
			}
			if (_m1face_no3 != compare.M1face_no3)
			{
				return false;
			}
			if (_m1tana_dan3 != compare.M1tana_dan3)
			{
				return false;
			}
			if (_m1selectorcheckbox3 != compare.M1selectorcheckbox3)
			{
				return false;
			}
			if (_m1entersyoriflg3 != compare.M1entersyoriflg3)
			{
				return false;
			}
			if (_m1dtlirokbn3 != compare.M1dtlirokbn3)
			{
				return false;
			}
			if (_m1rowno4 != compare.M1rowno4)
			{
				return false;
			}
			if (_m1face_no4 != compare.M1face_no4)
			{
				return false;
			}
			if (_m1tana_dan4 != compare.M1tana_dan4)
			{
				return false;
			}
			if (_m1selectorcheckbox4 != compare.M1selectorcheckbox4)
			{
				return false;
			}
			if (_m1entersyoriflg4 != compare.M1entersyoriflg4)
			{
				return false;
			}
			if (_m1dtlirokbn4 != compare.M1dtlirokbn4)
			{
				return false;
			}
			if (_m1rowno5 != compare.M1rowno5)
			{
				return false;
			}
			if (_m1face_no5 != compare.M1face_no5)
			{
				return false;
			}
			if (_m1tana_dan5 != compare.M1tana_dan5)
			{
				return false;
			}
			if (_m1selectorcheckbox5 != compare.M1selectorcheckbox5)
			{
				return false;
			}
			if (_m1entersyoriflg5 != compare.M1entersyoriflg5)
			{
				return false;
			}
			if (_m1dtlirokbn5 != compare.M1dtlirokbn5)
			{
				return false;
			}
			if (_m1rowno6 != compare.M1rowno6)
			{
				return false;
			}
			if (_m1face_no6 != compare.M1face_no6)
			{
				return false;
			}
			if (_m1tana_dan6 != compare.M1tana_dan6)
			{
				return false;
			}
			if (_m1selectorcheckbox6 != compare.M1selectorcheckbox6)
			{
				return false;
			}
			if (_m1entersyoriflg6 != compare.M1entersyoriflg6)
			{
				return false;
			}
			if (_m1dtlirokbn6 != compare.M1dtlirokbn6)
			{
				return false;
			}
			if (_m1rowno7 != compare.M1rowno7)
			{
				return false;
			}
			if (_m1face_no7 != compare.M1face_no7)
			{
				return false;
			}
			if (_m1tana_dan7 != compare.M1tana_dan7)
			{
				return false;
			}
			if (_m1selectorcheckbox7 != compare.M1selectorcheckbox7)
			{
				return false;
			}
			if (_m1entersyoriflg7 != compare.M1entersyoriflg7)
			{
				return false;
			}
			if (_m1dtlirokbn7 != compare.M1dtlirokbn7)
			{
				return false;
			}

			return true;
		}
		/// <summary>
		/// 特定の型のハッシュ関数として機能します。
		/// ハッシュ アルゴリズムや、ハッシュ テーブルのようなデータ構造での使用に適しています。
		/// </summary>
		/// <returns>現在のcom.xebio.bo.Tj100p01.Formvo.Tj100f01M1Formのハッシュ コード。</returns>
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
			str.Append("M1face_no:").Append(this._m1face_no).AppendLine();
			str.Append("M1tana_dan:").Append(this._m1tana_dan).AppendLine();
			str.Append("M1selectorcheckbox:").Append(this._m1selectorcheckbox).AppendLine();
			str.Append("M1entersyoriflg:").Append(this._m1entersyoriflg).AppendLine();
			str.Append("M1dtlirokbn:").Append(this._m1dtlirokbn).AppendLine();
			str.Append("M1rowno2:").Append(this._m1rowno2).AppendLine();
			str.Append("M1face_no2:").Append(this._m1face_no2).AppendLine();
			str.Append("M1tana_dan2:").Append(this._m1tana_dan2).AppendLine();
			str.Append("M1selectorcheckbox2:").Append(this._m1selectorcheckbox2).AppendLine();
			str.Append("M1entersyoriflg2:").Append(this._m1entersyoriflg2).AppendLine();
			str.Append("M1dtlirokbn2:").Append(this._m1dtlirokbn2).AppendLine();
			str.Append("M1rowno3:").Append(this._m1rowno3).AppendLine();
			str.Append("M1face_no3:").Append(this._m1face_no3).AppendLine();
			str.Append("M1tana_dan3:").Append(this._m1tana_dan3).AppendLine();
			str.Append("M1selectorcheckbox3:").Append(this._m1selectorcheckbox3).AppendLine();
			str.Append("M1entersyoriflg3:").Append(this._m1entersyoriflg3).AppendLine();
			str.Append("M1dtlirokbn3:").Append(this._m1dtlirokbn3).AppendLine();
			str.Append("M1rowno4:").Append(this._m1rowno4).AppendLine();
			str.Append("M1face_no4:").Append(this._m1face_no4).AppendLine();
			str.Append("M1tana_dan4:").Append(this._m1tana_dan4).AppendLine();
			str.Append("M1selectorcheckbox4:").Append(this._m1selectorcheckbox4).AppendLine();
			str.Append("M1entersyoriflg4:").Append(this._m1entersyoriflg4).AppendLine();
			str.Append("M1dtlirokbn4:").Append(this._m1dtlirokbn4).AppendLine();
			str.Append("M1rowno5:").Append(this._m1rowno5).AppendLine();
			str.Append("M1face_no5:").Append(this._m1face_no5).AppendLine();
			str.Append("M1tana_dan5:").Append(this._m1tana_dan5).AppendLine();
			str.Append("M1selectorcheckbox5:").Append(this._m1selectorcheckbox5).AppendLine();
			str.Append("M1entersyoriflg5:").Append(this._m1entersyoriflg5).AppendLine();
			str.Append("M1dtlirokbn5:").Append(this._m1dtlirokbn5).AppendLine();
			str.Append("M1rowno6:").Append(this._m1rowno6).AppendLine();
			str.Append("M1face_no6:").Append(this._m1face_no6).AppendLine();
			str.Append("M1tana_dan6:").Append(this._m1tana_dan6).AppendLine();
			str.Append("M1selectorcheckbox6:").Append(this._m1selectorcheckbox6).AppendLine();
			str.Append("M1entersyoriflg6:").Append(this._m1entersyoriflg6).AppendLine();
			str.Append("M1dtlirokbn6:").Append(this._m1dtlirokbn6).AppendLine();
			str.Append("M1rowno7:").Append(this._m1rowno7).AppendLine();
			str.Append("M1face_no7:").Append(this._m1face_no7).AppendLine();
			str.Append("M1tana_dan7:").Append(this._m1tana_dan7).AppendLine();
			str.Append("M1selectorcheckbox7:").Append(this._m1selectorcheckbox7).AppendLine();
			str.Append("M1entersyoriflg7:").Append(this._m1entersyoriflg7).AppendLine();
			str.Append("M1dtlirokbn7:").Append(this._m1dtlirokbn7).AppendLine();

			return str.ToString();
		}
		#endregion

	}
}
