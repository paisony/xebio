using com.xebio.bo.Tb010p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Conditions;
using Common.Standard.Base;

namespace com.xebio.bo.Tb010p01.Facade
{
  /// <summary>
  /// Tb010f01のFacadeクラスです
  /// 画面データのロード業務ロジックを実装します。
  /// </summary>
  public partial class Tb010f01Facade : StandardBaseFacade
	{
		#region 定数を設定します
		/// <summary>;
		/// プログラムID。
		/// </summary>
		private const string PGID = "Tb010p01";
		/// <summary>
		/// フォームID。
		/// </summary>
		private const string FORMID = "Tb010f01";
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tb010f01Facade()
			: base()
		{
		}
		#endregion

		#region Tb010f01画面データを作成する。
		/// <summary>
		/// Tb010f01画面データを作成する。
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
				Tb010f01Form tb010f01Form = (Tb010f01Form)facadeContext.FormVO;

				#region 初期表示時の設定処理

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				// 仕入確定日の初期設定
				tb010f01Form.Siire_kakutei_ymd_from = sysDateVO.Sysdate.ToString();
				tb010f01Form.Siire_kakutei_ymd_to = sysDateVO.Sysdate.ToString();

				// 伝票状態の初期設定
				tb010f01Form.Denpyo_jyotai = ConditionSiiire_denpyo_jotai.VALUE_SIIIRE_DENPYO_JOTAI1;

				// 営業日（隠し）の初期設定
				tb010f01Form.Eigyo_ymd_hdn = sysDateVO.Sysdate.ToString();

				#endregion
				//	//モデル層処理ロジックを記述してください。
			//	//カード部 データを取得(要実装)........
				
			//	//M1明細部のデータを作成します。
			//	DoM1ListLoad(facadeContext);
				
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
