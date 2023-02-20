using com.xebio.bo.Ta080p01.Constant;
using com.xebio.bo.Ta080p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Standard.Base;
using Common.Standard.Message;

namespace com.xebio.bo.Ta080p01.Facade
{
  /// <summary>
  /// Ta080f03のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Ta080f03Facade : StandardBaseFacade
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
				// FormVO取得
				// 画面より情報を取得する。
				Ta080f03Form f03VO = (Ta080f03Form)facadeContext.FormVO;
				IDataList m1List = f03VO.GetList("M1");

				// 遷移元画面情報をdictonaryより取得する。
				Ta080f01Form prevF01Vo = (Ta080f01Form)f03VO.Dictionary[Ta080p01Constant.DIC_SEARCH_F01VO];

				// 一覧の初期化
				//m1List.ClearCacheData();
				//m1List.Clear();

				#endregion
				#region 業務チェック
				// 1.マスタ存在チェック
				ChkSearch1(facadeContext, f03VO);
				// ------------------------------------------------------------------------------------
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				// ------------------------------------------------------------------------------------
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				// 2.関連項目チェック
				ChkSearch2(facadeContext, f03VO);
				// ------------------------------------------------------------------------------------
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				// ------------------------------------------------------------------------------------
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion
				#region 検索処理
				decimal[] dRetList = DoSelect(facadeContext, prevF01Vo, f03VO, m1List);
				// ------------------------------------------------------------------------------------
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				// ------------------------------------------------------------------------------------
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion
				#region 後処理
				#region フッター部設定
				// 合計依頼数量			:Ｍ１依頼数量の合計値
				f03VO.Gokei_irai_su = dRetList[0].ToString();
				// 合計原価金額			:Ｍ１原価金額の合計値
				f03VO.Gokei_genkakin = dRetList[1].ToString();

				#endregion

				#region Dictionary設定
				// 初期合計値をDictionaryに保持 明細画面確定時の一覧明細の更新に使用
				f03VO.Dictionary[Ta080p01Constant.DIC_ATODENAMAEKAERU] = dRetList;
				#endregion

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
