// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Fujitsu.SmartBase.Base.Information
{
	/// <summary>
	/// ID発行時にエラーが起きた際にthrowされる例外クラスです。
	/// </summary>
	public class IDGeneratorException : SystemException
	{
		/// <summary>
		/// メッセージを設定するコンストラクタです。
		/// </summary>
		/// <param name="message">メッセージ</param>
		public IDGeneratorException(string message)
			: base(message)
		{
		}
	}
}
