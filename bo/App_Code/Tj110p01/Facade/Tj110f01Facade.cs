using com.xebio.bo.Tj110p01.Constant;
using com.xebio.bo.Tj110p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01017;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Model.Data;
using System.Collections;
using System.Collections.Generic;

namespace com.xebio.bo.Tj110p01.Facade
{
  /// <summary>
  /// Tj110f01のFacadeクラスです
  /// 画面データのロード業務ロジックを実装します。
  /// </summary>
  public partial class Tj110f01Facade : StandardBaseFacade
	{
		#region 定数を設定します
		/// <summary>;
		/// プログラムID。
		/// </summary>
		private const string PGID = "Tj110p01";
		/// <summary>
		/// フォームID。
		/// </summary>
		private const string FORMID = "Tj110f01";
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tj110f01Facade()
			: base()
		{
		}
		#endregion

		#region Tj110f01画面データを作成する。
		/// <summary>
		/// Tj110f01画面データを作成する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoLoad(IFacadeContext facadeContext)
		{			
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
				Tj110f01Form tj110f01Form = (Tj110f01Form)facadeContext.FormVO;
			
				//モデル層処理ロジックを記述してください。
				//カード部 データを取得(要実装)........

				#region 画面データ設定

				#region 取漏欠番区分初期値設定
				tj110f01Form.Torimore_ketsuban = ConditionTorimore_ketsuban_kbn.VALUE_TORIMORE;
				#endregion

				#region フェイスNoFROMTO初期値設定
				// ログイン情報取得
				LoginInfoVO loginInfVo = LoginInfoUtil.GetLoginInfo();

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);
				
				// 棚卸基準日取得
				Hashtable TanaoroshiYmdList = SearchInventory.SearchMdit0030(loginInfVo.TnpCd, sysDateVO.Sysdate.ToString(), facadeContext, 0);
				if (TanaoroshiYmdList == null || TanaoroshiYmdList.Count == 0)
				{
					return;
				} 
				// [棚卸確定(H)TBL]を検索し、未送信の最大、最小の[フェイス№]を取得する。
				FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(Tj110p01Constant.SQL_ID_01, facadeContext.DBContext);

				// 店舗コード
				rtSeach.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(loginInfVo.TnpCd));
				// 棚卸日
				rtSeach.BindValue("BIND_TANAOROSI_YMD", (decimal)TanaoroshiYmdList["TANAOROSIKIJUN_YMD"]);

				// 検索結果を取得
				rtSeach.CreateDbCommand();
				IList<Hashtable> tableList = rtSeach.Execute();
				BoSystemLog.logOut("SQL: " + rtSeach.LogSql);

				string maxFace = (string)tableList[0]["MAX_FACE"].ToString();
				string minFace = (string)tableList[0]["MIN_FACE"].ToString();

				// 画面に値を設定
				tj110f01Form.Face_no_from = minFace;
				tj110f01Form.Face_no_to = maxFace;
				#endregion
				
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
