﻿using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tg010p01.Formvo
{
  /// <summary>
  /// Tg010p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tg010p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TG010F01)のFormVO。
		/// </summary>
		private Tg010f01Form tg010f01Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tg010f01Form(プライスシール発行)を取得または設定する。
		/// </summary>
		public Tg010f01Form Tg010f01Form
		{
			get
			{
				return this.tg010f01Form;
			}
			set
			{
				this.tg010f01Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tg010p01PgForm()
		{
			tg010f01Form = new Tg010f01Form();
		}
		#endregion

		#region IProgramVO メンバ
		
		/// <summary>
		/// プログラムFormVO内に保持されているFormVOを取得する。
		/// </summary>
		/// <param name="formId">フォームID</param>
		/// <returns>プログラムFormVO内に保持されているFormVO</returns>
		public IFormVO GetFormVO(string formId)
		{
			if (formId.Equals("Tg010f01"))
			{
				return this.tg010f01Form;
			}

			return null;
		}


		
		/// <summary>
		/// プログラムFormVO内に保持されているFormVOに設定する。
		/// </summary>
		/// <param name="formId">フォームID</param>
		/// <param name="formVO">プログラムFormVO内に保持されているFormVO</param>
		public void SetFormVO(string formId, object formVO)
		{
			if (formId.Equals("Tg010f01"))
			{
				this.tg010f01Form=(Tg010f01Form)formVO;
			}
		}

		#endregion

	}
}
