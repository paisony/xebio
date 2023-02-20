using com.xebio.bo.Tg010p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C99999.LabelUtil;
using Common.Standard.Base;

namespace com.xebio.bo.Tg010p01.Facade
{
  /// <summary>
  /// Tg010f01のFacadeクラスです
  /// 画面データのロード業務ロジックを実装します。
  /// </summary>
  public partial class Tg010f01Facade : StandardBaseFacade
	{
		#region 定数を設定します
		/// <summary>;
		/// プログラムID。
		/// </summary>
		private const string PGID = "Tg010p01";
		/// <summary>
		/// フォームID。
		/// </summary>
		private const string FORMID = "Tg010f01";
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tg010f01Facade()
			: base()
		{
		}
		#endregion

		#region Tg010f01画面データを作成する。
		/// <summary>
		/// Tg010f01画面データを作成する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoLoad(IFacadeContext facadeContext)
		{
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
				Tg010f01Form tg010f01Form = (Tg010f01Form)facadeContext.FormVO;

				// ラベル情報を設定
				BoSystemLabelUtil.SetLabelInfo<Tg010f01Form>(tg010f01Form, facadeContext);
							

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
