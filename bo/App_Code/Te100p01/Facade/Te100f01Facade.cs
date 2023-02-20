using com.xebio.bo.Te100p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Standard.Base;

namespace com.xebio.bo.Te100p01.Facade
{
  /// <summary>
  /// Te100f01のFacadeクラスです
  /// 画面データのロード業務ロジックを実装します。
  /// </summary>
  public partial class Te100f01Facade : StandardBaseFacade
	{
		#region 定数を設定します
		/// <summary>;
		/// プログラムID。
		/// </summary>
		private const string PGID = "Te100p01";
		/// <summary>
		/// フォームID。
		/// </summary>
		private const string FORMID = "Te100f01";
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Te100f01Facade()
			: base()
		{
		}
		#endregion

		#region Te100f01画面データを作成する。
		/// <summary>
		/// Te100f01画面データを作成する。
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
                Te100f01Form te100f01Form = (Te100f01Form)facadeContext.FormVO;

                //モデル層処理ロジックを記述してください。
                //カード部 データを取得(要実装)........

                // システム日付取得
                SysDateVO sysDateVO = new SysDateVO();
                sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

                te100f01Form.Add_ymd_from = sysDateVO.Sysdate.ToString();
                te100f01Form.Add_ymd_to = sysDateVO.Sysdate.ToString();

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

	}
}
