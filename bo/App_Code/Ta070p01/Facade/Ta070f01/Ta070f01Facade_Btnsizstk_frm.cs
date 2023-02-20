using com.xebio.bo.Ta070p01.Constant;
using com.xebio.bo.Ta070p01.Formvo;
using com.xebio.bo.Ta070p01.Util;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01003;
using Common.Business.C01000.C01007;
using Common.Standard.Base;
using System;
using System.Collections;
using System.Collections.Generic;

namespace com.xebio.bo.Ta070p01.Facade
{
  /// <summary>
  /// Ta070f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Ta070f01Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : Btnsizstk)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnsizstk)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNSIZSTK_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNSIZSTK_FRM");

			try
			{
			//	//DBコンテキストを設定する。
			//	SetDBContext(facadeContext);
			//	//コネクションを取得して、トランザクションを開始する。
			//	BeginTransactionWithConnect(facadeContext);
				
			//	//以下に業務ロジックを記述する。
				// サイズ検索にて選択したレコードを取得
				IList<Hashtable> hachuMstInfo = (IList<Hashtable>)facadeContext.GetUserObject(Ta070p01Constant.KEY_SIZE_SEARCH_RESULT);

				// フォームオブジェクト取得
				Ta070f01Form form = (Ta070f01Form)facadeContext.FormVO;
				// 明細オブジェクト取得
				IDataList m1List = form.GetList("M1");

				// 有効現在行数
				int curRowCnt = Ta070p01Util.GetRowCnt ( m1List );
				// 設定店舗(新規作成時のみ有効のため、ヘッダ情報より設定)
				string setTenpoCd = form.Head_tenpo_cd;
				string setTenpoNm = form.Head_tenpo_nm;

				// 不足行数
				int requiredCnt = curRowCnt + hachuMstInfo.Count - m1List.Count;
				if (requiredCnt > 0)
				{
					// 追加ページ数
					int addPageCnt = (int)Math.Floor(new decimal((requiredCnt - 1) / m1List.DispRow)) + 1;
					// 追加行数
					int addRowCnt = m1List.DispRow * addPageCnt;

					// 行追加
					AddRowCls.AddEmptyRow<Ta070f01M1Form>("M1", "M1rowno", form, addRowCnt);
				}

				int index = curRowCnt;
				foreach (Hashtable hachuMstRow in hachuMstInfo)
				{
					// 発注マスタ情報設定
					DoShohinCopy((Ta070f01M1Form)m1List[index], hachuMstRow, setTenpoCd, true);
					index++;
				}

				// 表示ページ設定
				int dispPageNo;	// 表示ページ番号
				int focusIndex;	// フォーカス行インデックス
				if (index == decimal.ToInt32(GetMaxCntCls.GetMaxCnt(FORMID.ToUpper())))
				{
					// 最終行まで設定された場合
					dispPageNo = decimal.ToInt32(Math.Floor(new decimal((index - 1) / m1List.DispRow))) + 1;
					focusIndex = (index - 1) % m1List.DispRow;
				}
				else
				{
					dispPageNo = decimal.ToInt32(Math.Floor(new decimal(index / m1List.DispRow))) + 1;
					focusIndex = index % m1List.DispRow;
				}
				// 表示ページ設定
				if (dispPageNo > m1List.PageCount)
				{
					// ページ追加処理
					AddRowCls.AddEmptyRow<Ta070f01M1Form>("M1", "M1rowno", form, m1List.DispRow);
				}
				m1List.SetPage(dispPageNo);
				// フォーカス行インデックス設定
				facadeContext.SetUserObject(Ta070p01Constant.KEY_SIZE_FOCUS_INDEX, focusIndex.ToString());

				// 最大件数設定
				form.Searchcnt = m1List.Count.ToString();

				//int dispPageNo = (int)Math.Floor(new decimal((index - 1) / m1List.DispRow)) + 1;
				//m1List.SetPage(dispPageNo);

				//// フォーカス行インデックス
				//facadeContext.SetUserObject(Ta070p01Constant.KEY_SIZE_FOCUS_INDEX, (index % m1List.DispRow).ToString());

			//	//トランザクションをコミットする。
			//	CommitTransaction(facadeContext);
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
			//	//コネクションを開放する。
			//	CloseConnection(facadeContext);
			}
			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNSIZSTK_FRM");

		}
		#endregion
	}
}
