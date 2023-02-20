using com.xebio.bo.Tf070p01.Constant;
using com.xebio.bo.Tf070p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01011;
using Common.Business.C99999.Constant;
using Common.Standard.Base;
using Common.Standard.Message;
using System.Collections;

namespace com.xebio.bo.Tf070p01.Facade
{
  /// <summary>
  /// Tf070f02のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tf070f02Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : Btnrowdel)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnrowdel)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNROWDEL_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNROWDEL_FRM");

			try
			{
				////DBコンテキストを設定する。
				//SetDBContext(facadeContext);
				////コネクションを取得して、トランザクションを開始する。
				//BeginTransactionWithConnect(facadeContext);

				//以下に業務ロジックを記述する。

				// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
				// 画面オブジェクト取得
				Tf070f02Form form = (Tf070f02Form)facadeContext.FormVO;
				IDataList m1List = form.GetList("M1");

				#region 業務チェック
				// 1-1 選択行
				// 選択行が存在しない場合はエラー
				bool selFlg = false;
				for (int i = 0; i < m1List.Count; i++)
				{
					// 明細行オブジェクト取得
					Tf070f02M1Form m1Form = (Tf070f02M1Form)m1List[i];

					if (m1Form.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
					{
						// 選択フラグＯＮの場合
						selFlg = true;
						break;
					}
				}
				if (!selFlg)
				{
					// 選択されていない場合
					ErrMsgCls.AddErrMsg("E119", "対象行", facadeContext);
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region 行削除処理
				int addRowFlg = 0;
				// モードが「新規作成」の場合
				if (form.Stkmodeno.Equals(BoSystemConstant.MODE_INSERT))
				{
					addRowFlg = 1;	// 行追加あり
				}

				// 合計計算項目の設定
				ArrayList gokeiCalcList = new ArrayList();
				// 計算項目：Ｍ１申請数、合計項目：合計申請数
				string[] sinseiSu = { "M1sinsei_su", "Gokeisinsei_su" };
				gokeiCalcList.Add(sinseiSu);
				// 計算項目：Ｍ１受理数、合計項目：合計受理数
				string[] jyuriSu = { "M1jyuri_su", "Gokeijyuri_su" };
				gokeiCalcList.Add(jyuriSu);
				// 計算項目：Ｍ１売価金額、合計項目：合計売価金額
				string[] baikaKin = { "M1baika_kin", "Gokeibaika_kin" };
				gokeiCalcList.Add(baikaKin);

				// 選択行を削除
				decimal focusIndex = DelRowCls.DeleteSelectRow<Tf070f02Form, Tf070f02M1Form>("M1", "M1rowno", form, gokeiCalcList, addRowFlg);
				#endregion

				// ページインデックス設定
				//SetPageIndex(m1List, addCount);

				// フォーカス行をコードビハインドに戻す
				facadeContext.SetUserObject(Tf070p01Constant.FCDUO_FOCUSROW, focusIndex.ToString());
				// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

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
				////コネクションを開放する。
				//CloseConnection(facadeContext);
			}
			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNROWDEL_FRM");

		}
		#endregion
	}
}
