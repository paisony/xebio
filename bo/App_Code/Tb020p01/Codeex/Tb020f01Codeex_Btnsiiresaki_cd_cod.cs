using Common.Advanced.Codecondition.Code.Context;
using Common.Standard.Base;
using System;
using System.Text;

namespace com.xebio.bo.Tb020p01.Codeex
{
  /// <summary>
  /// フォーム：Tb020f01 項目：Btnsiiresaki_cd の拡張コード参照クラスです。
  /// </summary>
  [Serializable]
	public class Tb020f01Codeex_Btnsiiresaki_cd : StandardBaseCodeex
	{
		public Tb020f01Codeex_Btnsiiresaki_cd()
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

			sb.Append(" SELECT");
			sb.Append(" 	SIIRESAKI_CD, SIIRESAKI_RYAKU_NM, SAKUJYO_FLG");
			sb.Append(" FROM (");

			sb.Append(" SELECT");
			sb.Append(" 		 SIIRESAKI_CD");
			sb.Append(" 		,NVL(SIIRESAKI_RYAKU_NM, '') AS SIIRESAKI_RYAKU_NM");
			sb.Append(" 		,SAKUJYO_FLG");
			sb.Append(" 		,0 AS SORTNO2");
			sb.Append(" 		,2 AS SORTNO1");
			sb.Append(" FROM");
			sb.Append(" 		MDMT0020");
			sb.Append(" WHERE");
			sb.Append(" 		SIIRESAKI_CD NOT IN (SELECT MEISYO_CD FROM MDMT0100 WHERE SIKIBETSU_CD = 'SCMS' AND SAKUJYO_FLG = 0)");
			sb.Append(" UNION ALL");
			sb.Append(" SELECT");
			sb.Append(" 		 MDMT0020.SIIRESAKI_CD");
			sb.Append(" 		,NVL(MDMT0020.SIIRESAKI_RYAKU_NM, '') AS SIIRESAKI_RYAKU_NM");
			sb.Append(" 		,MDMT0020.SAKUJYO_FLG");
			sb.Append(" 		,TO_NUMBER(MDMT0100.MEISYOKANA_NM) AS SORTNO2");
			sb.Append(" 		,1 AS SORTNO1");
			sb.Append(" FROM");
			sb.Append(" 		MDMT0020");
			sb.Append(" INNER JOIN");
			sb.Append(" 		MDMT0100");
			sb.Append(" ON		MDMT0020.SIIRESAKI_CD = MDMT0100.MEISYO_CD");
			sb.Append(" WHERE");
			sb.Append(" 		SIKIBETSU_CD = 'SCMS'");
			sb.Append(" AND		MDMT0100.SAKUJYO_FLG = 0");

			sb.Append(" )");
			sb.Append(" ORDER BY");
			sb.Append(" 		SORTNO1, SORTNO2, SIIRESAKI_RYAKU_NM");

			context.Condition.SQL = sb.ToString();

			StringBuilder sbCnt = new StringBuilder();
			sbCnt.AppendLine("SELECT COUNT(*) FROM (");
			sbCnt.AppendLine(sb.ToString());
			sbCnt.AppendLine(")");

			context.Condition.CountStatement = sbCnt.ToString();

			// メソッド終了時の共通処理
			base.BeforeSearchEnd(context);
		}
		#endregion
	}
}

