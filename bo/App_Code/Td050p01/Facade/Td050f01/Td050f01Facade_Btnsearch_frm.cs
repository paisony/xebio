using com.xebio.bo.Td050p01.Constant;
using com.xebio.bo.Td050p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01018;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using System;

namespace com.xebio.bo.Td050p01.Facade
{
  /// <summary>
  /// Td050f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Td050f01Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : Btnsearch)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnsearch)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNSEARCH_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNSEARCH_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得して、トランザクションを開始する。
				OpenConnection(facadeContext);

				//以下に業務ロジックを記述する。
				#region 初期化

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Td050f01Form f01VO = (Td050f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// エラー時の画面表示対応 --------------------------------  ADD_STR
				f01VO.Stkmodeno = string.Empty;
				// エラー時の画面表示対応 --------------------------------  ADD_END

				// 一覧の初期化
				m1List.ClearCacheData();
				m1List.Clear();
				// 検索条件を初期化
				SearchConditionSaveCls.SearchConditionRemove(f01VO);
				f01VO.Dictionary[Td050p01Constant.DIC_SEARCH_XEBIOCD] = "";
				#endregion
				#region 業務チェック
				// 単項目チェック
				ChkSelSingleItem(facadeContext, f01VO);
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				// 関連項目チェック
				ChkSelRelatedItem(facadeContext, f01VO);
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#region 件数チェック
				Decimal dCnt = ChkCount(facadeContext, DoSelect(f01VO, facadeContext.DBContext, true));
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion
				#endregion
				#region 検索処理
				//検索処理を行い結果を転記します
				DoCopy(f01VO, m1List, DoSelect(f01VO, facadeContext.DBContext, false));

				// 検索件数の設定
				f01VO.Searchcnt = m1List.Count.ToString();

				// モードNoを選択モードNoへ設定
				f01VO.Stkmodeno = f01VO.Modeno;

				// 検索条件を退避
				SearchConditionSaveCls.SearchConditionSave(f01VO);
				#endregion
				////トランザクションをコミットする。
				//CommitTransaction(facadeContext);
			}
			catch (System.Exception ex)
			{
				////トランザクションをロールバックする。
				//RollbackTransaction(facadeContext);
				//例外処理を実行する。
				ThrowException(ex, facadeContext);
			}
			finally
			{
				//コネクションを開放する。
				CloseConnection(facadeContext);
			}
			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNSEARCH_FRM");

		}
		#endregion
    }
}
