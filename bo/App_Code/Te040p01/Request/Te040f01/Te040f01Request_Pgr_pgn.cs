﻿using com.xebio.bo.Te040p01.Formvo;
using Common.Advanced.Web.Context;
using Common.Standard.Check;

namespace com.xebio.bo.Te040p01.Request.Te040f01
{
  /// <summary>
  /// Te040f01Request_Pgr の概要の説明です。
  /// </summary>
  public sealed class Te040f01Request_Pgr : Te040f01Request
	{
		/// <summary>
		/// このクラス唯一のインスタンス。
		/// </summary>
		public static readonly Te040f01Request_Pgr Me = new Te040f01Request_Pgr();

		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		private Te040f01Request_Pgr()
		{

		}
		
//		/// <summary>
//		/// 入力値を取得します。
//		/// </summary>
//		/// <param name="pageContext">ページコンテキスト</param>
//		public override void DoGetRequestValue(IPageContext pageContext)
//		{
//			base.DoGetRequestValue(pageContext);
//		}
//
//		/// <summary>
//		/// 継承ファイルを拡張します。
//		/// </summary>
//		/// <param name="pageContext">ページコンテキスト</param>
//		public override void DoExtItemInfo(IPageContext pageContext)
//		{
//		}
//
//		/// <summary>
//		/// 入力値をアンフォーマットします。
//		/// </summary>
//		/// <param name="pageContext">ページコンテキスト</param>
//		public override void DoUnformat(IPageContext pageContext)
//		{
//		}
//
//		/// <summary>
//		/// フォームVOに入力値を設定します。
//		/// </summary>
//		/// <param name="pageContext">ページコンテキスト</param>
//		public override void DoCopyForm(IPageContext pageContext)
//		{
//		}
//
		/// <summary>
		/// 入力値チェックをします。
		/// </summary>
		/// <param name="pageContext">ページコンテキスト</param>
		public override void DoValidateInputValue(IPageContext pageContext)
		{
			//サブミット時チェックフラグがfalseなら処理を終了する。
			if (!pageContext.ButtonInfo.IsSubmitCheck)
			{
				return;
			}

			//チェックマネージャを取得する。
			StandardCheckManager checker = new StandardCheckManager(pageContext);
			//フォームVOを取得する。
			Te040f01Form formVO = (Te040f01Form)pageContext.GetFormVO();

			//明細部の入力項目
			Te040f01RequestHelper.ValidateM1InputValue(formVO, checker);

			if (checker.HasError())
			{
				//入力エラーがあった場合は定義に従って処理する
				base.DoError(checker, pageContext);
			}
		}

		/// <summary>
		/// コード存在チェックをします。
		/// </summary>
		/// <param name="pageContext">ページコンテキスト</param>
		public override void DoValidateCodeValue(IPageContext pageContext)
		{
			//サブミット時チェックフラグがfalseなら処理を終了する。
			if (!pageContext.ButtonInfo.IsSubmitCheck)
			{
				return;
			}
			//コードチェックマネージャを取得する。
			StandardCodeCheckManager codeChecker = new StandardCodeCheckManager(pageContext);
			//フォームVOを取得する。
			Te040f01Form formVO = (Te040f01Form)pageContext.GetFormVO();
			
			//明細部コード存在チェック
			Te040f01RequestHelper.ValidateM1CodeValue(formVO, codeChecker);

			if (codeChecker.HasError)
			{
				//入力エラーがあった場合は定義に従って処理する
				base.DoError(codeChecker, pageContext);
			}
		}
//
//		/// <summary>
//		/// 業務チェックをします。
//		/// </summary>
//		/// <param name="pageContext">ページコンテキスト</param>
//		public override void DoValidateBusiness(IPageContext pageContext)
//		{
//		}
	}
}

