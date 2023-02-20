using Common.Advanced.Codecondition.Code.Context;
using Common.Advanced.Codecondition.Code.Vo;
using Common.Advanced.Model.Data;
using Common.Standard.Base;
using System;
using System.Text;

namespace com.xebio.bo.Te050p01.Codeex
{
  /// <summary>
  /// フォーム：Te050f01 項目：M1btnirocd の拡張コード参照クラスです。
  /// </summary>
  [Serializable]
	public class Te050f01Codeex_M1btnirocd : StandardBaseCodeex
	{
		public Te050f01Codeex_M1btnirocd()
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

			// 項目追加
			context.Condition.AddExtItemID("M1jisya_hbn");

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

			// 項目の取得
			ISearchValue exeValues = context.ExeValue;
			String sJisyacd = exeValues.InputValues["M1jisya_hbn"] as string;

			StringBuilder sb = new StringBuilder();
			StringBuilder sborder = new StringBuilder();

			// SQL
			sb.Append(" SELECT");
			sb.Append("			 IRO_CD");
			sb.Append("			,IRO_NM IRO_NM_BO1");
			sb.Append(" FROM");
			sb.Append("			MDMT0080");
			sb.Append(" WHERE");
			sb.Append("			EXISTS (");
			sb.Append(" 			SELECT 1 FROM MDMT0130");
			sb.Append("				WHERE");
			sb.Append("						MDMT0130.MAKERCOLOR_CD = MDMT0080.IRO_CD");
			sb.Append("				AND		MDMT0130.XEBIO_CD = :M1jisya_hbn");
			sb.Append("			)");
			sb.Append("	AND		SAKUJYO_FLG = 0");
			// ソート順
			sborder.Append(" ORDER BY IRO_NM");


			StringBuilder sbRow = new StringBuilder();
			sbRow.AppendLine(sb.ToString());
			sbRow.AppendLine(sborder.ToString());

			context.Condition.SQL = sbRow.ToString();
			context.Condition.AddSQLParameter("M1jisya_hbn", new DataParameter(":M1jisya_hbn", null));
			context.Condition.SetSQLParamValue("M1jisya_hbn", sJisyacd, SearchItemType.Equal);

			// 件数調査用SQL
			StringBuilder sbCnt = new StringBuilder();
			sbCnt.Append(" SELECT COUNT(*) FROM (");
			sbCnt.AppendLine(sb.ToString());
			sbCnt.AppendLine(")");

			context.Condition.CountStatement = sbCnt.ToString();

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

