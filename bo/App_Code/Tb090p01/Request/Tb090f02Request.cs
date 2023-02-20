﻿using com.xebio.bo.Tb090p01.Formvo;
using Common.Advanced.Web.Context;
using Common.Advanced.Web.Request;
using Common.Standard.Base;
using Common.Standard.Check;

namespace com.xebio.bo.Tb090p01.Request
{
  /// <summary>
  /// Tb090f02Request の概要の説明です。
  /// </summary>
  public abstract class Tb090f02Request:StandardBaseRequest, IActionPreProcessor
	{
		/// <summary>
		/// 入力値を取得します。
		/// </summary>
		/// <param name="pageContext">ページコンテキスト</param>
		public virtual void DoGetRequestValue(IPageContext pageContext)
		{
			//入力値をアンフォーマットしてFormBeanへ値を転送する。
			Tb090f02RequestHelper.GetRequestValue(pageContext);
		}

		/// <summary>
		/// 継承ファイルを拡張します。
		/// </summary>
		/// <param name="pageContext">ページコンテキスト</param>
		public virtual void DoExtItemInfo(IPageContext pageContext)
		{
			Tb090f02RequestHelper.ExtItemInfo(pageContext);
		}

		/// <summary>
		/// 入力値をアンフォーマットします。
		/// </summary>
		/// <param name="pageContext">ページコンテキスト</param>
		public virtual void DoUnformat(IPageContext pageContext)
		{
			Tb090f02RequestHelper.Unformat(pageContext);
		}

		/// <summary>
		/// フォームVOに入力値を設定します。
		/// </summary>
		/// <param name="pageContext">ページコンテキスト</param>
		public virtual void DoCopyForm(IPageContext pageContext)
		{
			Tb090f02RequestHelper.CopyForm(pageContext);
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
			Tb090f02Form formVO=(Tb090f02Form)pageContext.GetFormVO();
		
			//カード部の入力項目
			Tb090f02RequestHelper.ValidateCardInputValue(formVO, checker);
			//明細部の入力項目
			Tb090f02RequestHelper.ValidateM1InputValue(formVO, checker);

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

