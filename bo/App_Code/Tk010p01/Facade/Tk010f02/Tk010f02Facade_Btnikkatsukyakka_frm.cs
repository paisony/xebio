using com.xebio.bo.Tk010p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C99999.Constant;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Message;

namespace com.xebio.bo.Tk010p01.Facade
{
  /// <summary>
  /// Tk010f02のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tk010f02Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : Btnikkatsukyakka)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnikkatsukyakka)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNIKKATSUKYAKKA_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNIKKATSUKYAKKA_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得して、トランザクションを開始する。
				OpenConnection(facadeContext);
			
				//以下に業務ロジックを記述する。
				// FormVO取得
				// 画面より情報を取得する。
				Tk010f02Form f01VO = (Tk010f02Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				#region 業務チェック

				// 一括却下用却下理由区分
				// 一括却下用却下理由が入力された場合に、入力されていない場合、エラー
				if (!string.IsNullOrEmpty(f01VO.Ikkatsukyakka_kyakkariyu)
					&& BoSystemConstant.DROPDOWNLIST_MISENTAKU.Equals(f01VO.Ikkatsukyakka_kyakkariyu_kb))
				{
					ErrMsgCls.AddErrMsg("E119", "一括却下用却下理由", facadeContext, new[] { "Ikkatsukyakka_kyakkariyu_kb" });
				}

				// 一括却下用却下理由
				// 一括却下理由区分で[その他]以外選択時、入力されていない場合、エラー
				if (!ConditionHyokason_kyakkariyu.VALUE_HYOKASON_KYAKKARIYU5.Equals(f01VO.Ikkatsukyakka_kyakkariyu_kb)
					&& string.IsNullOrEmpty(f01VO.Ikkatsukyakka_kyakkariyu))
				{
					ErrMsgCls.AddErrMsg("E121", "一括却下用却下理由", facadeContext, new[] { "Ikkatsukyakka_kyakkariyu" });
				}

				// 一括却下用却下理由
				// 一括却下理由区分で[その他]選択時、入力されていない場合、エラー
				if (ConditionHyokason_kyakkariyu.VALUE_HYOKASON_KYAKKARIYU5.Equals(f01VO.Ikkatsukyakka_kyakkariyu_kb)
					&& string.IsNullOrEmpty(f01VO.Ikkatsukyakka_kyakkariyu))
				{
					ErrMsgCls.AddErrMsg("E118", "その他選択時、却下理由", facadeContext, new[] { "Ikkatsukyakka_kyakkariyu" });
				}


				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion


				// 全ての明細行を却下にする
				for (int i = 0; i < m1List.Count; i++)
				{
					Tk010f02M1Form f01m1VO = (Tk010f02M1Form)m1List[i];
					f01m1VO.M1syonin_flg = BoSystemConstant.CHECKBOX_OFF;
					f01m1VO.M1kyakka_flg = BoSystemConstant.CHECKBOX_ON;
					f01m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_ARI;
					// 却下理由を反映する
					f01m1VO.M1kyakkariyu_kb = f01VO.Ikkatsukyakka_kyakkariyu_kb;
					f01m1VO.M1kyakkariyu = f01VO.Ikkatsukyakka_kyakkariyu;
				}
			
			
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
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNIKKATSUKYAKKA_FRM");

		}
		#endregion
	}
}
