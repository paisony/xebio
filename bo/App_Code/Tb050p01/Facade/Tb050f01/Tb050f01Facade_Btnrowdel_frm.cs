using com.xebio.bo.Tb050p01.Constant;
using com.xebio.bo.Tb050p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01008;
using Common.Business.C01000.C01011;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using System.Collections;

namespace com.xebio.bo.Tb050p01.Facade
{
  /// <summary>
  /// Tb050f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tb050f01Facade : StandardBaseFacade
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
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
			//	//コネクションを取得して、トランザクションを開始する。
			//	BeginTransactionWithConnect(facadeContext);
				OpenConnection(facadeContext);
				
				//以下に業務ロジックを記述する。

				LoginInfoVO loginInfVo = LoginInfoUtil.GetLoginInfo();

				Hashtable defVal = null;

				// 権限取得部品の戻り値が"FALSE"の場合
				if (!CheckKengenCls.CheckKengen(loginInfVo))
				{
					// [Ｍ１店舗コード]にログイン情報の店舗コードを設定
					// [Ｍ１店舗名]にログイン情報の所属店舗名を設定
					defVal = new Hashtable();

					defVal.Add("M1tenpo_cd", loginInfVo.TnpCd);
					defVal.Add("M1tenpo_nm", loginInfVo.Tnprksmes);
				}

				decimal lastRow = DelRowCls.DeleteSelectRow<Tb050f01Form, Tb050f01M1Form>("M1", "M1rowno", (Tb050f01Form)facadeContext.FormVO, null, 1, defVal);

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

				// 合計数計算
				this.setGokei((Tb050f01Form)facadeContext.FormVO);

				// フォーカス行をコードビハインドに戻す
				facadeContext.SetUserObject(Tb050p01Constant.FCDUO_FOCUSROW, lastRow);

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
				//コネクションを開放する。
				CloseConnection(facadeContext);
			}
			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNROWDEL_FRM");

		}
		#endregion

		public LoginInfoVO loginInfVO { get; set; }
	}
}
