using com.xebio.bo.Tj060p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C99999.Constant;
using Common.Business.V01000.V01019;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using System.Collections;

namespace com.xebio.bo.Tj060p01.Facade
{
  /// <summary>
  /// Tj060f01のFacadeクラスです
  /// 画面データのロード業務ロジックを実装します。
  /// </summary>
  public partial class Tj060f01Facade : StandardBaseFacade
	{
		#region 定数を設定します
		/// <summary>;
		/// プログラムID。
		/// </summary>
		private const string PGID = "Tj060p01";
		/// <summary>
		/// フォームID。
		/// </summary>
		private const string FORMID = "Tj060f01";
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tj060f01Facade()
			: base()
		{
		}
		#endregion

		#region Tj060f01画面データを作成する。
		/// <summary>
		/// Tj060f01画面データを作成する。
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
				Tj060f01Form tj060f01Form = (Tj060f01Form)facadeContext.FormVO;
				
				// 棚卸実施日データを取得
				// ログイン情報取得
				LoginInfoVO loginInfVo = LoginInfoUtil.GetLoginInfo();

				Hashtable resultHash = new Hashtable();
				resultHash = V01019Check.CheckTenpoTanaorosijissiYmd(loginInfVo.TnpCd, BoSystemConstant.MODE_KONKAI, "0", facadeContext, "店舗", new[] { "Head_tenpo_cd" });
				// 名称をラベルに設定
				if (resultHash == null || resultHash.Count == 0) { }
				else{
					tj060f01Form.Head_tenpo_nm = (string)resultHash["TENPO_NM"];
					tj060f01Form.Tanaorosikijun_ymd = resultHash["TANAOROSIKIJUN_YMD_KONKAI"].ToString();
					tj060f01Form.Tanaorosijissi_ymd = resultHash["TANAOROSIJISSI_YMD_KONKAI"].ToString();
					tj060f01Form.Tanaorosikikan_from = resultHash["TANAOROSIKIKAN_FROM_KONKAI"].ToString();
					tj060f01Form.Tanaorosikikan_to = resultHash["TANAOROSIKIKAN_TO_KONAKI"].ToString();
					tj060f01Form.Tanaorosikijun_ymd1 = resultHash["TANAOROSIKIJUN_YMD_ZENKAI"].ToString();
					tj060f01Form.Tanaorosijissi_ymd1 = resultHash["TANAOROSIJISSI_YMD_ZENKAI"].ToString();
					tj060f01Form.Tanaorosikikan_from1 = resultHash["TANAOROSIKIKAN_FROM_ZENKAI"].ToString();
					tj060f01Form.Tanaorosikikan_to1 = resultHash["TANAOROSIKIKAN_TO_ZENKAI"].ToString();
				}
				//初期値設定 
				tj060f01Form.Tanaorosi_hokokusyo_kb = ConditionTanaorosi_hokokusyo_x.VALUE_TANAOROSI_HOKOKUSYO_X1;

			
			
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
