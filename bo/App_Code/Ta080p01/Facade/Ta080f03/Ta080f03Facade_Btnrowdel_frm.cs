using com.xebio.bo.Ta010p01.Constant;
using com.xebio.bo.Ta080p01.Constant;
using com.xebio.bo.Ta080p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01011;
using Common.Business.C99999.Constant;
using Common.Standard.Base;
using Common.Standard.Message;
using System;
using System.Collections;

namespace com.xebio.bo.Ta080p01.Facade
{
  /// <summary>
  /// Ta080f03のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Ta080f03Facade : StandardBaseFacade
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
			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNROWDEL_FRM");

			try
			{
				//DBコンテキストを設定する。
				//SetDBContext(facadeContext);
				//コネクションを取得して、トランザクションを開始する。
				//BeginTransactionWithConnect(facadeContext);
			
				//以下に業務ロジックを記述する。

				//M1明細リストを取得
				Ta080f03Form f03VO = (Ta080f03Form)facadeContext.FormVO;
				IDataList m1List = f03VO.GetList("M1");

				// 削除行をListRemovedDataに追加
				decimal zankin = 0;
				if (Ta080p01Constant.FLG_OFF.Equals(Convert.ToDecimal(f03VO.Dictionary[Ta080p01Constant.DIC_TANPIN_TOUROKU_MODE_FLG]))
					&& BoSystemConstant.MODE_APPLY.Equals(f03VO.Stkmodeno))
				{
					zankin = Convert.ToDecimal(f03VO.Footer_zan_kin);
				}

				for (int iRow = 0; iRow < m1List.Count; iRow++)
				{
					// 明細情報
					Ta080f03M1Form f03MVO = (Ta080f03M1Form)m1List[iRow];

					if (f03MVO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
					{
						if (BoSystemConstant.MODE_APPLY.Equals(f03VO.Stkmodeno))
						{
							// 残金から各行の現価金額を加算
							zankin += Convert.ToDecimal(f03MVO.M1genkakin);
						}

						//リストオブジェクトにM1Formを追加します。
						m1List.ListRemovedData.Add(f03MVO);
					}
				}
				if (Ta080p01Constant.FLG_OFF.Equals(Convert.ToDecimal(f03VO.Dictionary[Ta080p01Constant.DIC_TANPIN_TOUROKU_MODE_FLG]))
					&& BoSystemConstant.MODE_APPLY.Equals(f03VO.Stkmodeno))
				{
					// 残金をフォームに設定
					f03VO.Footer_zan_kin = zankin.ToString();
				}
				ArrayList gokeiCalcList = new ArrayList();
				gokeiCalcList.Add(new string[] { "M1irai_su", "Gokei_irai_su" });
				gokeiCalcList.Add(new string[] { "M1genkakin", "Gokei_genkakin" });
				// 行追加フラグ
				int addRowFlg = Convert.ToInt32(Ta080p01Constant.FLG_OFF);
				// 新規作成時は、行追加フラグをＯＮ
				if (BoSystemConstant.MODE_INSERT.Equals(f03VO.Stkmodeno))
				{
					addRowFlg = Convert.ToInt32(Ta010p01Constant.FLG_ON);
				}
				// 選択行を削除
				decimal lastRow = DelRowCls.DeleteSelectRow<Ta080f03Form, Ta080f03M1Form>("M1", "M1rowno", f03VO, gokeiCalcList, addRowFlg);

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
				// フォーカス行をコードビハインドに戻す
				facadeContext.SetUserObject(Ta010p01Constant.FCDUO_FOCUSROW, lastRow.ToString());

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
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNROWDEL_FRM");

		}
		#endregion
	}
}
