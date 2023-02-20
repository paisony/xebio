using com.xebio.bo.Ta080p01.Constant;
using com.xebio.bo.Ta080p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01018;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;

namespace com.xebio.bo.Ta080p01.Facade
{
  /// <summary>
  /// Ta080f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Ta080f01Facade : StandardBaseFacade
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
			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNSEARCH_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得して、トランザクションを開始する。
				BeginTransactionWithConnect(facadeContext);
			
				//以下に業務ロジックを記述する。

				#region 初期化
				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Ta080f01Form f01VO = (Ta080f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// エラー時の画面表示対応 --------------------------------  ADD_STR
				f01VO.Stkmodeno = string.Empty;
				// エラー時の画面表示対応 --------------------------------  ADD_END

				// 一覧の初期化
				m1List.ClearCacheData();
				m1List.Clear();
				// 検索条件を初期化
				SearchConditionSaveCls.SearchConditionRemove(f01VO);
				
				#endregion
				#region 業務チェック
				// 1.マスタ存在チェック
				ChkSearch1(facadeContext, f01VO);
				// ------------------------------------------------------------------------------------
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				// ------------------------------------------------------------------------------------
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				
				// 2.関連項目チェック
				ChkSearch2(facadeContext, f01VO);
				// ------------------------------------------------------------------------------------
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				// ------------------------------------------------------------------------------------
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				// 3.検索件数チェック
				ChkSearch3(facadeContext, f01VO);
				// ------------------------------------------------------------------------------------
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				// ------------------------------------------------------------------------------------
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion
				#region 検索処理
				//検索処理を行い結果を画面に転記
				DoSelect(facadeContext, f01VO, m1List);

				// 検索件数の設定
				f01VO.Searchcnt = m1List.Count.ToString();
				#endregion
				#region 後処理
				// モードNoを選択モードNoへ設定
				f01VO.Stkmodeno = f01VO.Modeno;
			
				// 検索条件を退避
				//SearchConditionSaveCls.SearchConditionSave(f01VO);
				f01VO.Dictionary[Ta080p01Constant.DIC_SEARCH_F01VO] = SearchConditionSave(f01VO);
				#endregion

				//トランザクションをコミットする。
				//CommitTransaction(facadeContext);
			}
			catch (System.Exception ex)
			{
				//トランザクションをロールバックする。
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
