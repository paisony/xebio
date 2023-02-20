﻿using com.xebio.bo.Ta070p01.Constant;
using com.xebio.bo.Ta070p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01007;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using System.Collections;

namespace com.xebio.bo.Ta070p01.Facade
{
  /// <summary>
  /// Ta070f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Ta070f01Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : Btninsert)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btninsert)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNINSERT_FRM(IFacadeContext facadeContext)
		{
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNINSERT_FRM");

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
				Ta070f01Form f01VO = (Ta070f01Form)facadeContext.FormVO;
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
				// 単項目チェック
				ChkSelSingleItem(facadeContext, f01VO, Ta070p01Constant.CHECK_MODE_BTNINSERT);
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				// 関連項目チェック
				ChkSelRelatedItem(facadeContext, f01VO, Ta070p01Constant.CHECK_MODE_BTNINSERT);
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion
				#region ページ追加
				// 初期値設定
				Hashtable defVal = new Hashtable();
				defVal["M1irairiyu_cd"] = "0";

				// ページを追加
				AddRowCls.AddEmptyRow<Ta070f01M1Form>("M1", "M1rowno", (Ta070f01Form)facadeContext.FormVO, m1List.DispRow, defVal);
				SetPageIndex(m1List, m1List.DispRow);
				// 検索件数の設定
				f01VO.Searchcnt = m1List.Count.ToString();
				#endregion
				#region 後処理
				// 選択モードNoを新規作成に設定
				f01VO.Stkmodeno = BoSystemConstant.MODE_INSERT; ;
				// 検索条件をクリア
				ClearSeachItem(f01VO);
				// 検索条件を退避
				SearchConditionSaveCls.SearchConditionSave(f01VO);
				#endregion

				//	//トランザクションをコミットする。
				//	CommitTransaction(facadeContext);
				//}
			}
			catch (System.Exception ex)
			{
				//	//トランザクションをロールバックする。
				//	RollbackTransaction(facadeContext);
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
