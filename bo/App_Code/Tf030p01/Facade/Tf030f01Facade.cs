using com.xebio.bo.Tf030p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01008;
using Common.Standard.Base;
using Common.Standard.Login;

namespace com.xebio.bo.Tf030p01.Facade
{
  /// <summary>
  /// Tf030f01のFacadeクラスです
  /// 画面データのロード業務ロジックを実装します。
  /// </summary>
  public partial class Tf030f01Facade : StandardBaseFacade
	{
		#region 定数を設定します
		/// <summary>;
		/// プログラムID。
		/// </summary>
		private const string PGID = "Tf030p01";
		/// <summary>
		/// フォームID。
		/// </summary>
		private const string FORMID = "Tf030f01";
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tf030f01Facade()
			: base()
		{
		}
		#endregion

		#region Tf030f01画面データを作成する。
		/// <summary>
		/// Tf030f01画面データを作成する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoLoad(IFacadeContext facadeContext)
		{
			//使用時にコメントアウトをはずす。
			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoLoad");
			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを開きます。
				OpenConnection(facadeContext);

				//以下に業務ロジックを記述する。

				//カード部を取得します。
				Tf030f01Form tf030f01Form = (Tf030f01Form)facadeContext.FormVO;

				//モデル層処理ロジックを記述してください。
				//カード部 データを取得(要実装)........

				LoginInfoVO loginInfVo = LoginInfoUtil.GetLoginInfo();

				// 権限取得部品の戻り値が"FALSE"の場合
				if (!CheckKengenCls.CheckKengen(loginInfVo))
				{
					// 店舗FROM
					tf030f01Form.Tenpo_cd_from = loginInfVo.TnpCd;
					tf030f01Form.Tenpo_nm_from = loginInfVo.Tnprksmes;
					// 店舗TO
					tf030f01Form.Tenpo_cd_to = loginInfVo.TnpCd;
					tf030f01Form.Tenpo_nm_to = loginInfVo.Tnprksmes;
				}

				//M1明細部のデータを作成します。
				DoM1ListLoad(facadeContext);

			}
			catch (System.Exception ex)
			{
				//例外処理を実行する。
				ThrowException(ex, facadeContext);
			}
			finally
			{
				//コネクションを開放する。
				CloseConnection(facadeContext);
			}
			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoLoad");
		}
		#endregion

		
		#region M1明細部データの作成をする。
		/// <summary>
		/// M1明細部データの作成をする。
		/// 明細ID(M1)の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoM1ListLoad(IFacadeContext facadeContext)
		{
			//このメソッドは、M1の明細のデータを生成するために、
			//画面のLoad処理と改ページ処理で呼ばれます。
			//コネクションの開始・終了は呼び出しもとのメソッドで管理されます。
			//必要な処理を実装してください。
			
		}
		#endregion
	}
}
