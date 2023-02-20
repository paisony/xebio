using com.xebio.bo.Tj170p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C99999.Constant;
using Common.Business.V01000.V01019;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using System.Collections;

namespace com.xebio.bo.Tj170p01.Facade
{
  /// <summary>
  /// Tj170f01のFacadeクラスです
  /// 画面データのロード業務ロジックを実装します。
  /// </summary>
  public partial class Tj170f01Facade : StandardBaseFacade
	{
		#region 定数を設定します
		/// <summary>;
		/// プログラムID。
		/// </summary>
		private const string PGID = "Tj170p01";
		/// <summary>
		/// フォームID。
		/// </summary>
		private const string FORMID = "Tj170f01";
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tj170f01Facade()
			: base()
		{
		}
		#endregion

		#region Tj170f01画面データを作成する。
		/// <summary>
		/// Tj170f01画面データを作成する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoLoad(IFacadeContext facadeContext)
		{
			StartMethod(facadeContext, this.GetType().Name + ".DoLoad");
			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを開きます。
				OpenConnection(facadeContext);
			
				//以下に業務ロジックを記述する。
			
				//カード部を取得します。
				Tj170f01Form tj170f01Form = (Tj170f01Form)facadeContext.FormVO;
			
				//モデル層処理ロジックを記述してください。
				// 棚卸実施日データを取得
				// ログイン情報取得
				LoginInfoVO loginInfVo = LoginInfoUtil.GetLoginInfo();

				Hashtable resultHash = new Hashtable();
				resultHash = V01019Check.CheckTenpoTanaorosijissiYmd(loginInfVo.TnpCd, BoSystemConstant.MODE_KONKAI, "0", facadeContext, "店舗", new[] { "Head_tenpo_cd" });
				// 名称をラベルに設定
				if (resultHash == null || resultHash.Count == 0){}
				else{
					tj170f01Form.Head_tenpo_nm = (string)resultHash["TENPO_NM"];
					tj170f01Form.Tanaorosikijun_ymd = resultHash["TANAOROSIKIJUN_YMD_KONKAI"].ToString();
					tj170f01Form.Tanaorosijissi_ymd1 = resultHash["TANAOROSIJISSI_YMD_KONKAI"].ToString();
					tj170f01Form.Tanaorosikikan_from1 = resultHash["TANAOROSIKIKAN_FROM_KONKAI"].ToString();
					tj170f01Form.Tanaorosikikan_to1 = resultHash["TANAOROSIKIKAN_TO_KONAKI"].ToString();
					tj170f01Form.Tanaorosikijun_ymd1 = resultHash["TANAOROSIKIJUN_YMD_ZENKAI"].ToString();
					tj170f01Form.Tanaorosijissi_ymd11 = resultHash["TANAOROSIJISSI_YMD_ZENKAI"].ToString();
					tj170f01Form.Tanaorosikikan_from11 = resultHash["TANAOROSIKIKAN_FROM_ZENKAI"].ToString();
					tj170f01Form.Tanaorosikikan_to11 = resultHash["TANAOROSIKIKAN_TO_ZENKAI"].ToString();
				}

				// ラジオ[出力単位]の初期値設定
				tj170f01Form.Shuturyoku_tani = ConditionShuturyoku_tani.VALUE_SHUTURYOKU_TANI1;
				// ラジオ[ソート順]の初期値設定
				tj170f01Form.Sort_jun = ConditionMeisai_sort_tj170f01.VALUE_SORT_JUN1;
			
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
