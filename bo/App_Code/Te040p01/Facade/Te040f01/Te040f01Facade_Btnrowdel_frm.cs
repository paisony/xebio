﻿using com.xebio.bo.Te040p01.Constant;
using com.xebio.bo.Te040p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01011;
using Common.Standard.Base;
using Common.Standard.Message;
using System.Collections;

namespace com.xebio.bo.Te040p01.Facade
{
  /// <summary>
  /// Te040f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Te040f01Facade : StandardBaseFacade
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
				ArrayList gokeiCalcList = new ArrayList();
				gokeiCalcList.Add(new string[] { "M1syukka_su", "Syukkasuryo_gokei" });
				gokeiCalcList.Add(new string[] { "M1genka_kin", "Genka_kin_gokei" });

				//M1明細リストを取得
				Te040f01Form Te040f01Form = (Te040f01Form)facadeContext.FormVO;
				IDataList m1List = Te040f01Form.GetList("M1");

				// 選択行を削除
				decimal lastRow = DelRowCls.DeleteSelectRow<Te040f01Form, Te040f01M1Form>("M1", "M1rowno", (Te040f01Form)facadeContext.FormVO, gokeiCalcList, 1);

				// 削除行が存在しない場合、エラー。
				if (lastRow == -1)
				{
					// 対象行を選択して下さい。
					ErrMsgCls.AddErrMsg("E119", "対象行", facadeContext);

					//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}
				}
				// 1ページに戻す
				// m1List.SetTopPage();

				// フォーカス行をコードビハインドに戻す
				facadeContext.SetUserObject(Te040p01Constant.FCDUO_FOCUSROW, lastRow.ToString());

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
