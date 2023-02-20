using com.xebio.bo.Tm050p01.Constant;
using com.xebio.bo.Tm050p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Standard.Base;
using System.Collections;

namespace com.xebio.bo.Tm050p01.Facade
{
  /// <summary>
  /// Tm050f01のFacadeクラスです
  /// 画面データのロード業務ロジックを実装します。
  /// </summary>
  public partial class Tm050f01Facade : StandardBaseFacade
	{
		#region 定数を設定します
		/// <summary>;
		/// プログラムID。
		/// </summary>
		private const string PGID = "Tm050p01";
		/// <summary>
		/// フォームID。
		/// </summary>
		private const string FORMID = "Tm050f01";
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tm050f01Facade()
			: base()
		{
		}
		#endregion

		#region Tm050f01画面データを作成する。
		/// <summary>
		/// Tm050f01画面データを作成する。
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
				////コネクションを開きます。
				//OpenConnection(facadeContext);

				//以下に業務ロジックを記述する。


				//カード部を取得します。
				Tm050f01Form tm050f01Form = (Tm050f01Form)facadeContext.FormVO;

				//モデル層処理ロジックを記述してください。
				//カード部 データを取得(要実装)........

				// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
				#region 画面編集処理
				// コードビハインドで設定したプログラムVOのディクショナリを取得
				IDictionary pgFormDic = (IDictionary)facadeContext.GetUserObject(Tm050p01Constant.FCDUO_PGFORM_DICTIONARY);

				tm050f01Form.Dictionary[Tm050p01Constant.DIC_FORM_ID] = pgFormDic[Tm050p01Constant.DIC_FORM_ID];				// 呼出元画面ID
				tm050f01Form.Dictionary[Tm050p01Constant.DIC_CUR_ROW_CNT] = pgFormDic[Tm050p01Constant.DIC_CUR_ROW_CNT];		// 現在行数
				tm050f01Form.Dictionary[Tm050p01Constant.DIC_MAX_ROW_CNT] = pgFormDic[Tm050p01Constant.DIC_MAX_ROW_CNT];		// 最大行数
				tm050f01Form.Dictionary[Tm050p01Constant.DIC_CSV_CHECK_INFO] = pgFormDic[Tm050p01Constant.DIC_CSV_CHECK_INFO];	// CSVチェック情報

				tm050f01Form.Csv_nm = (string)pgFormDic[Tm050p01Constant.DIC_CSV_NAME];											// CSV名称
				#endregion
				// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

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
				////コネクションを開放する。
				//CloseConnection(facadeContext);
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
