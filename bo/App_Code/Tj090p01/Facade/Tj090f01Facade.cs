using com.xebio.bo.Tj090p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tj090p01.Facade
{
  /// <summary>
  /// Tj090f01のFacadeクラスです
  /// 画面データのロード業務ロジックを実装します。
  /// </summary>
  public partial class Tj090f01Facade : StandardBaseFacade
	{
		#region 定数を設定します
		/// <summary>;
		/// プログラムID。
		/// </summary>
		private const string PGID = "Tj090p01";
		/// <summary>
		/// フォームID。
		/// </summary>
		private const string FORMID = "Tj090f01";
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tj090f01Facade()
			: base()
		{
		}
		#endregion

		#region Tj090f01画面データを作成する。
		/// <summary>
		/// Tj090f01画面データを作成する。
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
                Tj090f01Form tj090f01Form = (Tj090f01Form)facadeContext.FormVO;

                //モデル層処理ロジックを記述してください。
                //カード部 データを取得(要実装)........

                // 営業日取得
                SysDateVO sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

                // 前月の1日を取得
                DateTime dt = DateTime.Parse(Convert.ToString(sysDateVO.Sysdate).Substring(0, 4) + "/" +
                                             Convert.ToString(sysDateVO.Sysdate).Substring(4, 2) + "/" +
                                             Convert.ToString(sysDateVO.Sysdate).Substring(6, 2));
                DateTime dt2 = dt.AddMonths(-1);
                string strYmdfrom = dt2.Date.ToString("yyyyMM") + "01";

                // 入力日From
                tj090f01Form.Nyuryoku_ymd_from = strYmdfrom;
                // 入力日To
                tj090f01Form.Nyuryoku_ymd_to = Convert.ToString(sysDateVO.Sysdate);


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
