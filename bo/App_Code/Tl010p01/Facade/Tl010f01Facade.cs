using com.xebio.bo.Tl010p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C99999.LabelUtil;
using Common.Conditions;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tl010p01.Facade
{
  /// <summary>
  /// Tl010f01のFacadeクラスです
  /// 画面データのロード業務ロジックを実装します。
  /// </summary>
  public partial class Tl010f01Facade : StandardBaseFacade
	{
		#region 定数を設定します
		/// <summary>;
		/// プログラムID。
		/// </summary>
		private const string PGID = "Tl010p01";
		/// <summary>
		/// フォームID。
		/// </summary>
		private const string FORMID = "Tl010f01";
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tl010f01Facade()
			: base()
		{
		}
		#endregion

		#region Tl010f01画面データを作成する。
		/// <summary>
		/// Tl010f01画面データを作成する。
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
				Tl010f01Form tl010f01Form = (Tl010f01Form)facadeContext.FormVO;

				//モデル層処理ロジックを記述してください。
				//カード部 データを取得(要実装)........

				// 営業日の取得
				SysDateVO sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				tl010f01Form.Eigyo_ymd_hdn = sysDateVO.Sysdate.ToString();

				// 営業日 + 1の取得
				DateTime dt = DateTime.Parse(Convert.ToString(sysDateVO.Sysdate).Substring(0, 4) + "/" +
											 Convert.ToString(sysDateVO.Sysdate).Substring(4, 2) + "/" +
											 Convert.ToString(sysDateVO.Sysdate).Substring(6, 2));
				DateTime dt2 = dt.AddDays(1);
				tl010f01Form.Eigyo_ymd_hdn2 = dt2.Date.ToString("yyyyMMdd");


				// 開始状態（開始済）
				tl010f01Form.Kaishi_jyotai = ConditionKaishi_jyotai.VALUE_KAISHI_JYOTAI1;

				// 開始日From、To（営業日）
				tl010f01Form.Baihenkaisi_ymd_from = sysDateVO.Sysdate.ToString();
				tl010f01Form.Baihenkaisi_ymd_to   = sysDateVO.Sysdate.ToString();

				// ラベル情報を設定
				BoSystemLabelUtil.SetLabelInfo<Tl010f01Form>(tl010f01Form, facadeContext);

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
