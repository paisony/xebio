﻿using Common.Advanced.Formvo;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tm050p01.Formvo
{
  /// <summary>
  /// Tm050p01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tm050p01PgForm : StandardBasePgForm, IProgramVO
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region フィールド
		/// <summary>
		/// 画面(TM050F01)のFormVO。
		/// </summary>
		private Tm050f01Form tm050f01Form;
		#endregion

		#region プロパティ
			
		/// <summary>
		/// Tm050f01Form(CSV取込画面)を取得または設定する。
		/// </summary>
		public Tm050f01Form Tm050f01Form
		{
			get
			{
				return this.tm050f01Form;
			}
			set
			{
				this.tm050f01Form = value;
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tm050p01PgForm()
		{
			tm050f01Form = new Tm050f01Form();
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
			if (formId.Equals("Tm050f01"))
			{
				return this.tm050f01Form;
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
			if (formId.Equals("Tm050f01"))
			{
				this.tm050f01Form=(Tm050f01Form)formVO;
			}
		}

		#endregion

	}
}
