using com.xebio.bo.Tg040p01.Constant;
using com.xebio.bo.Tg040p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.V03000.V03003;
using Common.Standard.Base;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Data;
using System.Text;

namespace com.xebio.bo.Tg040p01.Facade
{
  /// <summary>
  /// Tg040f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tg040f01Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : Btnenter)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnenter)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNENTER_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNENTER_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得して、トランザクションを開始する。
				BeginTransactionWithConnect(facadeContext);

				//以下に業務ロジックを記述する。

				#region 初期化
				// FormVO取得
				// 画面より情報を取得する。
				Tg040f01Form f01VO = (Tg040f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");
				#endregion

				#region 業務チェック
				// 1-1 選択状態
				// 1件も選択されていない場合、エラー
				if (m1List == null || m1List.Count <= 0)
				{
					// 確定対象がありません。
					ErrMsgCls.AddErrMsg("E140", String.Empty, facadeContext);
				}
				else
				{
					int inputflg = 0;
					for (int i = 0; i < m1List.Count; i++)
					{
						Tg040f01M1Form f01m1VO = (Tg040f01M1Form)m1List[i];
						if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
						{
							inputflg = 1;
							break;
						}
					}
					if (inputflg == 0)
					{
						ErrMsgCls.AddErrMsg("E119", "対象行", facadeContext);
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region 排他チェック
				StringBuilder sRepSql = new StringBuilder();

				for (int i = 0; i < m1List.Count; i++)
				{
					Tg040f01M1Form f01m1VO = (Tg040f01M1Form)m1List[i];

					if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
					{
						ArrayList bindList = new ArrayList();
						BindInfoVO bindVO = new BindInfoVO();

						// 店舗コード
						sRepSql.Append(" AND TENPO_CD = :BIND_TENPO_CD");
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_TENPO_CD";
						bindVO.Value = BoSystemFormat.formatTenpoCd((string)f01VO.Dictionary[SearchConditionSaveCls.PREFIX + "Head_tenpo_cd".ToUpper()]);
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						// 管理No
						sRepSql.Append(" AND KANRI_NO = :BIND_KANRI_NO");
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_KANRI_NO";
						bindVO.Value = (string)f01m1VO.Dictionary[Tg040p01Constant.DIC_KANRI_NO];
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						// 処理日付
						sRepSql.Append(" AND SYORI_YMD = :BIND_SYORI_YMD");
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_SYORI_YMD";
						bindVO.Value = (string)f01m1VO.Dictionary[Tg040p01Constant.DIC_SYORI_YMD];
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						// 排他チェック
						V03003Check.CheckHaitaMaxVal(
								Convert.ToDecimal((string)f01m1VO.Dictionary[Tg040p01Constant.DIC_UPD_YMD]),
								Convert.ToDecimal((string)f01m1VO.Dictionary[Tg040p01Constant.DIC_UPD_TM]),
								facadeContext,
								"MDBT0020",
								sRepSql.ToString(),
								bindList,
								1,
								null,
								f01m1VO.M1rowno,
								i.ToString(),
								"M1",
								100
						);

						// ＳＱＬ文初期化
						sRepSql.Length = 0;
					}
				}
			
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region 更新処理
				for (int i = 0; i < m1List.Count; i++)
				{
					Tg040f01M1Form f01m1VO = (Tg040f01M1Form)m1List[i];

					// [Ｍ１選択フラグ(隠し)]が"1"の場合
					if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
					{
						// [商品明細書TBL(H)]を削除する。
						int DelcntMDBT002_1 = Del_MDBT002(facadeContext, f01VO, f01m1VO, Tg040p01Constant.SQL_ID_04);
						// [商品明細書TBL(B)]を削除する。
						int DelcntMDBT002_2 = Del_MDBT002(facadeContext, f01VO, f01m1VO, Tg040p01Constant.SQL_ID_05);
					}
				}
				#endregion

				//トランザクションをコミットする。
				CommitTransaction(facadeContext);
			}
			catch (System.Exception ex)
			{
				//トランザクションをロールバックする。
				RollbackTransaction(facadeContext);
				//例外処理を実行する。
				ThrowException(ex, facadeContext);
			}
			finally
			{
				//コネクションを開放する。
				CloseConnection(facadeContext);
			}
			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNENTER_FRM");

		}
		#endregion

		#region ユーザー定義関数

		#region 商品証明書ＴＢＬ＿削除
		/// <summary>
		/// 商品証明書ＴＢＬ＿削除
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="sqlId">SQLID</param>
		/// <returns>更新件数</returns>
		private int Del_MDBT002(IFacadeContext facadeContext, Tg040f01Form f01VO, Tg040f01M1Form f01m1VO, string sqlId)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(sqlId, facadeContext.DBContext);

			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01VO.Dictionary[SearchConditionSaveCls.PREFIX + "Head_tenpo_cd".ToUpper()]));

			// 管理№
			reader.BindValue("BIND_KANRI_NO", Convert.ToDecimal(f01m1VO.Dictionary[Tg040p01Constant.DIC_KANRI_NO].ToString()));

			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal(f01m1VO.Dictionary[Tg040p01Constant.DIC_SYORI_YMD].ToString()));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#endregion
	}
}
