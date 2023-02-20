using com.xebio.bo.Tj090p01.Formvo;
using Common.Advanced.Web.Context;
using Common.Advanced.Web.Request;
using Common.Business.C99999.ControlUtil;
using Common.Standard.Base;
using Common.Standard.Check;

namespace com.xebio.bo.Tj090p01.Request
{
  /// <summary>
  /// Tj090f01Request の概要の説明です。
  /// </summary>
  public abstract class Tj090f01Request:StandardBaseRequest, IActionPreProcessor
	{
		/// <summary>
		/// 入力値を取得します。
		/// </summary>
		/// <param name="pageContext">ページコンテキスト</param>
		public virtual void DoGetRequestValue(IPageContext pageContext)
		{
			//入力値をアンフォーマットしてFormBeanへ値を転送する。
			Tj090f01RequestHelper.GetRequestValue(pageContext);
		}

		/// <summary>
		/// 継承ファイルを拡張します。
		/// </summary>
		/// <param name="pageContext">ページコンテキスト</param>
		public virtual void DoExtItemInfo(IPageContext pageContext)
		{
			Tj090f01RequestHelper.ExtItemInfo(pageContext);
		}

		/// <summary>
		/// 入力値をアンフォーマットします。
		/// </summary>
		/// <param name="pageContext">ページコンテキスト</param>
		public virtual void DoUnformat(IPageContext pageContext)
		{
			Tj090f01RequestHelper.Unformat(pageContext);
		}

		/// <summary>
		/// フォームVOに入力値を設定します。
		/// </summary>
		/// <param name="pageContext">ページコンテキスト</param>
		public virtual void DoCopyForm(IPageContext pageContext)
		{
			Tj090f01RequestHelper.CopyForm(pageContext);
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
			Tj090f01Form formVO=(Tj090f01Form)pageContext.GetFormVO();
		
			//カード部の入力項目
			Tj090f01RequestHelper.ValidateCardInputValue(formVO, checker);
			//明細部の入力項目
			if (BoSystemControl.IsM1CommonCheck(pageContext.ButtonInfo))
			{
				Tj090f01RequestHelper.ValidateM1InputValue(formVO, checker);
			}

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
			Tj090f01Form formVO = (Tj090f01Form)pageContext.GetFormVO();

			StandardCodeCheckManager codeChecker = new StandardCodeCheckManager(pageContext);

			//カード部コード存在チェック
			Tj090f01RequestHelper.ValidateCardCodeValue(formVO, codeChecker);

			//明細部コード存在チェック
			Tj090f01RequestHelper.ValidateM1CodeValue(formVO, codeChecker);

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

