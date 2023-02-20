using com.xebio.bo.Tj190p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01008;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;

namespace com.xebio.bo.Tj190p01.Facade
{
  /// <summary>
  /// Tj190f01のFacadeクラスです
  /// 画面データのロード業務ロジックを実装します。
  /// </summary>
  public partial class Tj190f01Facade : StandardBaseFacade
	{
		#region 定数を設定します
		/// <summary>;
		/// プログラムID。
		/// </summary>
		private const string PGID = "Tj190p01";
		/// <summary>
		/// フォームID。
		/// </summary>
		private const string FORMID = "Tj190f01";
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tj190f01Facade()
			: base()
		{
		}
		#endregion

		#region Tj190f01画面データを作成する。
		/// <summary>
		/// Tj190f01画面データを作成する。
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
				Tj190f01Form tj190f01Form = (Tj190f01Form)facadeContext.FormVO;
			
				//モデル層処理ロジックを記述してください。
				//カード部 データを取得(要実装)........

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				#region 画面データ設定

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);
				
				// 入力日
				tj190f01Form.Nyuryoku_ymd_from = sysDateVO.Sysdate.ToString();
				tj190f01Form.Nyuryoku_ymd_to = sysDateVO.Sysdate.ToString();
				
				// 明細ソート
				tj190f01Form.Meisai_sort = ConditionMeisai_sort_tj190f01.VALUE_MEISAI_SORT_TJ190F011;

				// 権限が本部以外の場合
				if (!CheckKengenCls.CheckKengen(logininfo))
				{
					// 所属店舗コードを設定
					tj190f01Form.Tenpo_cd_from = logininfo.TnpCd;
					tj190f01Form.Tenpo_cd_to = logininfo.TnpCd;

					// 所属店舗名を設定
					tj190f01Form.Tenpo_nm_from = logininfo.Tnprksmes;
					tj190f01Form.Tenpo_nm_to = logininfo.Tnprksmes;
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
