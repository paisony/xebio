using com.xebio.bo.Tk020p01.Constant;
using com.xebio.bo.Tk020p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01019;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;

namespace com.xebio.bo.Tk020p01.Facade
{
  /// <summary>
  /// Tk020f01のFacadeクラスです
  /// 画面データのロード業務ロジックを実装します。
  /// </summary>
  public partial class Tk020f01Facade : StandardBaseFacade
	{
		#region 定数を設定します
		/// <summary>;
		/// プログラムID。
		/// </summary>
		private const string PGID = "Tk020p01";
		/// <summary>
		/// フォームID。
		/// </summary>
		private const string FORMID = "Tk020f01";
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tk020f01Facade()
			: base()
		{
		}
		#endregion

		#region Tk020f01画面データを作成する。
		/// <summary>
		/// Tk020f01画面データを作成する。
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

				#region 初期処理
				//カード部を取得します。
				Tk020f01Form tk020f01Form = (Tk020f01Form)facadeContext.FormVO;

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);
				#endregion

				// 処理月
				tk020f01Form.Syori_ym = sysDateVO.Sysdate.ToString();
				tk020f01Form.Dictionary.Add(Tk020p01Constant.DIC_SYSDATE, sysDateVO.Sysdate.ToString());

				// 明細ソート設定
				if (CheckCompanyCls.IsXebio())
				{
					// 明細ソート[登録順]
					tk020f01Form.Meisai_sort = ConditionMeisai_sort_tk020f01.VALUE_MEISAI_SORT_TK020F011;
				}
				else
				{
					// 明細ソート[メーカー品番順]
					tk020f01Form.Meisai_sort = ConditionMeisai_sort_tk020f01.VALUE_MEISAI_SORT_TK020F012;
				}

				//モデル層処理ロジックを記述してください。
				//カード部 データを取得(要実装)........

				//M1明細部のデータを作成します。
				//DoM1ListLoad(facadeContext);

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
