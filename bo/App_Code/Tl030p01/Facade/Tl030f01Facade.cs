using com.xebio.bo.Tl030p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C99999.Constant;
using Common.Business.C99999.LabelUtil;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;

namespace com.xebio.bo.Tl030p01.Facade
{
  /// <summary>
  /// Tl030f01のFacadeクラスです
  /// 画面データのロード業務ロジックを実装します。
  /// </summary>
  public partial class Tl030f01Facade : StandardBaseFacade
	{
		#region 定数を設定します
		/// <summary>;
		/// プログラムID。
		/// </summary>
		private const string PGID = "Tl030p01";
		/// <summary>
		/// フォームID。
		/// </summary>
		private const string FORMID = "Tl030f01";
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tl030f01Facade()
			: base()
		{
		}
		#endregion

		#region Tl030f01画面データを作成する。
		/// <summary>
		/// Tl030f01画面データを作成する。
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
				Tl030f01Form tl030f01Form = (Tl030f01Form)facadeContext.FormVO;
			
				//モデル層処理ロジックを記述してください。
				//カード部 データを取得(要実装)........
				// アルバイトの場合、本部を初期設定
				if (LoginInfoUtil.GetLoginInfo().Kengenkbn == BoSystemConstant.TANTO_KENGEN_ARBEIT)
					tl030f01Form.Sinseimoto = ConditionSinseimoto.VALUE_SINSEIMOTO1;

				// ラベル情報を設定
				BoSystemLabelUtil.SetLabelInfo<Tl030f01Form>(tl030f01Form, facadeContext);
			
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
