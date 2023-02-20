using com.xebio.bo.Th020p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.V01000.V01006;
using Common.Standard.Base;
using Common.Standard.Login;
using System.Collections;

namespace com.xebio.bo.Th020p01.Facade
{
  /// <summary>
  /// Th020f01のFacadeクラスです
  /// 画面データのロード業務ロジックを実装します。
  /// </summary>
  public partial class Th020f01Facade : StandardBaseFacade
	{
		#region 定数を設定します
		/// <summary>;
		/// プログラムID。
		/// </summary>
		private const string PGID = "Th020p01";
		/// <summary>
		/// フォームID。
		/// </summary>
		private const string FORMID = "Th020f01";
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Th020f01Facade()
			: base()
		{
		}
		#endregion

		#region Th020f01画面データを作成する。
		/// <summary>
		/// Th020f01画面データを作成する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoLoad(IFacadeContext facadeContext)
		{
			// 使用時にコメントアウトをはずす。
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
				Th020f01Form th020f01Form = (Th020f01Form)facadeContext.FormVO;
			
				//モデル層処理ロジックを記述してください。
				//カード部 データを取得(要実装)........

				// URLより店舗コード取得

				// ログイン情報より会社コード取得
				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				th020f01Form.Kaisya_cd = logininfo.CopCd;
				th020f01Form.Kaisya_cd2 = logininfo.CopCd;
				th020f01Form.Kaisya_cd3 = logininfo.CopCd;
				th020f01Form.Kaisya_cd4 = logininfo.CopCd;

				// 会社コードを元に名称マスタを取得
				Hashtable resultHash = new Hashtable();
				resultHash = V01006Check.CheckKaisya(logininfo.CopCd, facadeContext);

				if (resultHash != null)
				{

					th020f01Form.Kaisya_nm = resultHash["MEISYO_NM"].ToString();
					th020f01Form.Kaisya_nm2 = resultHash["MEISYO_NM"].ToString();
					th020f01Form.Kaisya_nm3 = resultHash["MEISYO_NM"].ToString();
					th020f01Form.Kaisya_nm4 = resultHash["MEISYO_NM"].ToString();
				}

			
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
