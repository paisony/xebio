using com.xebio.bo.Tj120p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C99999.FormatUtil;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tj120p01.Facade
{
  /// <summary>
  /// Tj120f01のFacadeクラスです
  /// 画面データのロード業務ロジックを実装します。
  /// </summary>
  public partial class Tj120f01Facade : StandardBaseFacade
	{
		#region 定数を設定します
		/// <summary>;
		/// プログラムID。
		/// </summary>
		private const string PGID = "Tj120p01";
		/// <summary>
		/// フォームID。
		/// </summary>
		private const string FORMID = "Tj120f01";
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tj120f01Facade()
			: base()
		{
		}
		#endregion

		#region Tj120f01画面データを作成する。
		/// <summary>
		/// Tj120f01画面データを作成する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoLoad(IFacadeContext facadeContext)
		{
			//使用時にコメントアウトをはずす。
			////メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoLoad");
			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを開きます。
				OpenConnection(facadeContext);
			
				//以下に業務ロジックを記述する。
			
				//カード部を取得します。
				Tj120f01Form tj120f01Form = (Tj120f01Form)facadeContext.FormVO;
			
				//モデル層処理ロジックを記述してください。
				//カード部 データを取得(要実装)........
			
				#region 画面データ設定

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				//入力日FROM
				// 前月の1日を設定する
				tj120f01Form.Nyuryoku_ymd_from =  GetZebgetsu(sysDateVO.Sysdate.ToString());
				// 入力日TO
				tj120f01Form.Nyuryoku_ymd_to = sysDateVO.Sysdate.ToString();					
				#endregion

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

		#region ユーザー定義関数

		#region 前月取得

		/// <summary>
		/// 前月取得
		/// </summary>
		/// <param name="date">対象年月日</param>
		/// <returns>前月</returns>
		public String GetZebgetsu(String date)
		{
			String t = BoSystemFormat.formatDate(date.ToString(), 1);
			DateTime ts = DateTime.Parse(t).AddMonths(-1);
			return ts.Year.ToString() + ts.Month.ToString("00") + "01";
		}

		#endregion

		#endregion


	}
}
