using com.xebio.bo.Tk040p01.Formvo;
using Common.Advanced.Web.Context;
using Common.Advanced.Web.Request;
using Common.Standard.Base;
using Common.Standard.Check;

namespace com.xebio.bo.Tk040p01.Request
{
  /// <summary>
  /// Tk040f01Request の概要の説明です。
  /// </summary>
  public abstract class Tk040f01Request:StandardBaseRequest, IActionPreProcessor
	{
		/// <summary>
		/// 入力値を取得します。
		/// </summary>
		/// <param name="pageContext">ページコンテキスト</param>
		public virtual void DoGetRequestValue(IPageContext pageContext)
		{
			//入力値をアンフォーマットしてFormBeanへ値を転送する。
			Tk040f01RequestHelper.GetRequestValue(pageContext);
		}

		/// <summary>
		/// 継承ファイルを拡張します。
		/// </summary>
		/// <param name="pageContext">ページコンテキスト</param>
		public virtual void DoExtItemInfo(IPageContext pageContext)
		{
			Tk040f01RequestHelper.ExtItemInfo(pageContext);
		}

		/// <summary>
		/// 入力値をアンフォーマットします。
		/// </summary>
		/// <param name="pageContext">ページコンテキスト</param>
		public virtual void DoUnformat(IPageContext pageContext)
		{
			Tk040f01RequestHelper.Unformat(pageContext);
		}

		/// <summary>
		/// フォームVOに入力値を設定します。
		/// </summary>
		/// <param name="pageContext">ページコンテキスト</param>
		public virtual void DoCopyForm(IPageContext pageContext)
		{
			Tk040f01RequestHelper.CopyForm(pageContext);
		}

		/// <summary>
		/// 入力値チェックをします。
		/// </summary>
		/// <param name="pageContext">ページコンテキスト</param>
		public virtual void DoValidateInputValue(IPageContext pageContext)
		{
			//サブミット時チェックフラグがfalseなら処理を終了する。
			if (!pageContext.ButtonInfo.IsSubmitCheck) 
			{
				return;
			}

			//チェックマネージャを取得する。
			StandardCheckManager checker = new StandardCheckManager(pageContext);
			//フォームVOを取得する。
			Tk040f01Form formVO=(Tk040f01Form)pageContext.GetFormVO();
		
			//カード部の入力項目
			Tk040f01RequestHelper.ValidateCardInputValue(formVO, checker);
			//明細部の入力項目
			Tk040f01RequestHelper.ValidateM1InputValue(formVO, checker);

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
		public virtual void DoValidateCodeValue(IPageContext pageContext)
		{
			//サブミット時チェックフラグがfalseなら処理を終了する。
			if (!pageContext.ButtonInfo.IsSubmitCheck)
			{
				return;
			}
			//フォームVOを取得する。
			Tk040f01Form formVO = (Tk040f01Form)pageContext.GetFormVO();

			StandardCodeCheckManager codeChecker = new StandardCodeCheckManager(pageContext);

			//カード部コード存在チェック
			Tk040f01RequestHelper.ValidateCardCodeValue(formVO, codeChecker);
			
			//明細部コード存在チェック
			Tk040f01RequestHelper.ValidateM1CodeValue(formVO, codeChecker);

			if (codeChecker.HasError)
			{
				//入力エラーがあった場合は定義に従って処理する
				base.DoError(codeChecker, pageContext);
			}
		}

		/// <summary>
		/// 業務チェックをします。
		/// </summary>
		/// <param name="pageContext">ページコンテキスト</param>
		public virtual void DoValidateBusiness(IPageContext pageContext)
		{
			// 
			// DBアクセスを伴わない項目関連チェックロジックはここに記述してください。
			//
		}
	}
}

