using Common.Advanced.Codecondition.Code.Context;
using Common.Advanced.Model.Data;
using Common.Advanced.Util;
using Common.Business.C99999.StringUtil;
using Common.Standard.Base;
using System;
using System.Text;

namespace com.xebio.bo.Th020p01.Codeex
{
  /// <summary>
  /// フォーム：Th020f01 項目：Btnmaker_hbn の拡張コード参照クラスです。
  /// </summary>
  [Serializable]
	public class Th020f01Codeex_Btnmaker_hbn : StandardBaseCodeex
	{
		public Th020f01Codeex_Btnmaker_hbn()
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

			//context.Condition.ListMode = ListModeCode.PAGE;	// ページ毎にSQL発行
			context.Condition.ListMode = ListModeCode.ALL;	// 初回のみSQL発行

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

			StringBuilder sb = new StringBuilder();
			StringBuilder sborder = new StringBuilder();

			// SQL
			sb.Append(" SELECT");
			sb.Append("			 HIN_NBR");
			sb.Append("			,SYONMK SYONMK_BO1");
			sb.Append(" FROM");
			sb.Append("			MDMT0130");
			sb.Append(" WHERE");
			sb.Append("			HIN_NBR LIKE :Maker_hbn");
			sb.Append(" AND		ITEMKBN <> 0");
			sb.Append(" AND		SAKUJYO_FLG = 0");
			sb.Append(" GROUP BY");
			sb.Append("			 HIN_NBR");
			sb.Append("			,SYONMK");
			// ソート順
			sborder.Append(" ORDER BY HIN_NBR");

			StringBuilder sbRow = new StringBuilder();
			sbRow.Append(" SELECT HIN_NBR, SYONMK_BO1 FROM (");
			sbRow.AppendLine(sb.ToString());
			sbRow.AppendLine(sborder.ToString());
			sbRow.Append(" ) WHERE ROWNUM <= ").Append(context.Condition.MaxRowCount);

			context.Condition.SQL = sbRow.ToString();
			context.Condition.AddSQLParameter("Maker_hbn", new DataParameter(":Maker_hbn", null));

			StringBuilder sbCnt = new StringBuilder();
			sbCnt.Append(" SELECT COUNT(*) FROM (");
			sbCnt.AppendLine(sb.ToString());
			sbCnt.AppendLine(")");

			context.Condition.CountStatement = sbCnt.ToString();

			// 入力値を半角に置き換え
			string inpval = (string)context.ExeValue.InputValues["Maker_hbn"];
			context.ExeValue.InputValues["Maker_hbn"] = BoSystemString.ChangeZenHankaku(inpval, 1);

			// メソッド終了時の共通処理
			base.BeforeSearchEnd(context);
		}
		#endregion
	}
}

