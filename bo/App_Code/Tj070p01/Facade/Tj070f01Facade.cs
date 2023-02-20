using com.xebio.bo.Tj070p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01008;
using Common.Business.C99999.Constant;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;

namespace com.xebio.bo.Tj070p01.Facade
{
  /// <summary>
  /// Tj070f01のFacadeクラスです
  /// 画面データのロード業務ロジックを実装します。
  /// </summary>
  public partial class Tj070f01Facade : StandardBaseFacade
	{
		#region 定数を設定します
		/// <summary>;
		/// プログラムID。
		/// </summary>
		private const string PGID = "Tj070p01";
		/// <summary>
		/// フォームID。
		/// </summary>
		private const string FORMID = "Tj070f01";
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tj070f01Facade()
			: base()
		{
		}
		#endregion

		#region Tj070f01画面データを作成する。
		/// <summary>
		/// Tj070f01画面データを作成する。
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
				Tj070f01Form tj070f01Form = (Tj070f01Form)facadeContext.FormVO;

				LoginInfoVO loginInfVO = LoginInfoUtil.GetLoginInfo();

				//モデル層処理ロジックを記述してください。
				//カード部 データを取得(要実装)........

				#region 初期表示

				// 今回フラグ
				tj070f01Form.Konkai_flg = BoSystemConstant.CHECKBOX_ON;
				// 明細ソート
				tj070f01Form.Meisai_sort = ConditionMeisai_sort_tj070f01.VALUE_MEISAI_SORT_TJ070F011;

				// 権限取得部品の戻り値が"FALSE"の場合
				if (!CheckKengenCls.CheckKengen(loginInfVO))
				{
					// 店舗コードFROM
					tj070f01Form.Tenpo_cd_from = loginInfVO.TnpCd;
					// 店舗名FROM
					tj070f01Form.Tenpo_nm_from = loginInfVO.Tnprksmes;

					// 店舗コードTO
					tj070f01Form.Tenpo_cd_to = loginInfVO.TnpCd;
					// 店舗名TO
					tj070f01Form.Tenpo_nm_to = loginInfVO.Tnprksmes;
				}

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
	}
}
