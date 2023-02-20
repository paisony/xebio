using Common.Advanced.Codecondition.Code.Context;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tj060p01.Codeex
{
  /// <summary>
  /// フォーム：Tj060f01 項目：Btnheadtenpocd の拡張コード参照クラスです。
  /// </summary>
  [Serializable]
	public class Tj060f01Codeex_Btnheadtenpocd : StandardBaseCodeex
	{
		public Tj060f01Codeex_Btnheadtenpocd()
		{
		}

		#region ICodeExtension メンバ

		/// <summary>
		/// コード参照を起動して最初に実行されます。
		/// </summary>
		public override void Initialize(ICodeContext context)
		{
			// メソッド開始時の共通処理
			base.InitializeStart(context);

			// ここでは以下の拡張を行うことができます。
			// 　コード検索ウィンドウの表示情報変更
			// 　検索フォームの変更・拡張
			// 　検索フォームの入力チェック方法の定義
			// 　検索結果表示方法の変更
			// 　明細モードの変更
			// 　呼出元画面からの取得項目の定義
			// 　コード参照ドロップダウンの表示方法変更
			// 　検索先データソースの変更
			// 拡張方法の詳細はマニュアルおよびサンプルを参照してください。

			// メソッド終了時の共通処理
			base.InitializeEnd(context);
		}

		/// <summary>
		/// 呼出元画面の拡張項目を取得後に実行されます。
		/// </summary>
		public override void InitSearch(ICodeContext context)
		{
			// メソッド開始時の共通処理
			base.InitSearchStart(context);

			// ここでは以下の拡張を行うことができます。
			// 　呼出元画面から取得した項目の検索キー設定
			// 　任意の検索キーおよびSQLパラメータの追加
			// 　SQLの全文置換
			//
			// このメソッドに記述した拡張は、コード定義した項目に対し、
			// １度しか実行されません。コード検索ウィンドウの検索フォーム
			// に複数選択を追加した場合はBeforeSearchメソッドで検索条件
			// を設定してください。
			// 拡張方法の詳細はマニュアルおよびサンプルを参照してください。

			context.Condition.AddFindKey(" SAKUJYO_FLG = 0");

			// メソッド終了時の共通処理
			base.InitSearchEnd(context);
		}

		/// <summary>
		/// 検索実行前に毎回実行されます。
		/// </summary>
		public override void BeforeSearch(ICodeContext context)
		{
			// メソッド開始時の共通処理
			base.BeforeSearchStart(context);

			// ここでは以下の拡張を行うことができます。
			// 　コード検索の検索フォームに追加した複数選択コントロールの
			// 　検索条件生成
			//
			// このメソッドに記述した拡張は、DB検索を行う前に必ず実行されます。
			// SQL文を毎回生成しなおす必要がある場合のみ拡張コーディングを記述
			// してください。
			// 拡張方法の詳細はマニュアルおよびサンプルを参照してください。

			// メソッド終了時の共通処理
			base.BeforeSearchEnd(context);
		}
		#endregion
	}
}

