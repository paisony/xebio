using com.xebio.bo.Ti030p01.Constant;
using com.xebio.bo.Ti030p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C99999.LogUtil;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Model.Data;
using System.Collections;
using System.Collections.Generic;

namespace com.xebio.bo.Ti030p01.Facade
{
  /// <summary>
  /// Ti030f01のFacadeクラスです
  /// 画面データのロード業務ロジックを実装します。
  /// </summary>
  public partial class Ti030f01Facade : StandardBaseFacade
	{
		#region 定数を設定します
		/// <summary>;
		/// プログラムID。
		/// </summary>
		private const string PGID = "Ti030p01";
		/// <summary>
		/// フォームID。
		/// </summary>
		private const string FORMID = "Ti030f01";
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Ti030f01Facade()
			: base()
		{
		}
		#endregion

		#region Ti030f01画面データを作成する。
		/// <summary>
		/// Ti030f01画面データを作成する。
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
				Ti030f01Form ti030f01Form = (Ti030f01Form)facadeContext.FormVO;
			
				//モデル層処理ロジックを記述してください。

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				#region 画面表示

				#region 検索処理

				// 運用管理MSTから検索
				string sSqlId = Ti030p01Constant.SQL_ID_01;

				FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(sSqlId, facadeContext.DBContext);
	
				// 検索結果を取得
				rtSeach.CreateDbCommand();

				IList<Hashtable> tableList = rtSeach.Execute();

				BoSystemLog.logOut("SQL: " + rtSeach.LogSql);
				#endregion

				#region 初期値設定

				if (tableList != null && tableList.Count > 0)
				{
					// 存在した場合、各項目を設定
					ti030f01Form.Syohizei_rtu1 = tableList[0]["SYOHIZEI_RTU1"].ToString();							// 消費税率１
					ti030f01Form.Syohizeikaisi_ymd1 = tableList[0]["SYOHIZEIKAISI_YMD1"].ToString();				// 消費税開始日１
					ti030f01Form.Zeisyori_kb1 = tableList[0]["ZEISYORI_KB1"].ToString();		// 税処理区分1
					ti030f01Form.Syohizei_rtu2 = tableList[0]["SYOHIZEI_RTU2"].ToString();							// 消費税率２
					ti030f01Form.Syohizeikaisi_ymd2 = tableList[0]["SYOHIZEIKAISI_YMD2"].ToString();				// 消費税開始日２
					ti030f01Form.Zeisyori_kb2 = tableList[0]["ZEISYORI_KB2"].ToString();							// 税処理区分２

					// Dictionary
					ti030f01Form.Dictionary.Add(Ti030p01Constant.DIC_UPD_YMD,tableList[0]["UPD_YMD"].ToString());	// 更新日
					ti030f01Form.Dictionary.Add(Ti030p01Constant.DIC_UPD_TM, tableList[0]["UPD_TM"].ToString());	// 更新時間
				}
				else
				{
					// 初期化
					ti030f01Form.Syohizei_rtu1 = string.Empty;														// 消費税率１
					ti030f01Form.Syohizeikaisi_ymd1 = string.Empty; 												// 消費税開始日１
					ti030f01Form.Zeisyori_kb1 = ConditionZeisyori_kbn.VALUE_ZEISYORI_KBN1;							// 税処理区分1(切り捨て)
					ti030f01Form.Syohizei_rtu2 = string.Empty;														// 消費税率２
					ti030f01Form.Syohizeikaisi_ymd2 = string.Empty; 												// 消費税開始日２
					ti030f01Form.Zeisyori_kb2 = ConditionZeisyori_kbn.VALUE_ZEISYORI_KBN1;							// 税処理区分２(切り捨て)

					// Dictionary
					ti030f01Form.Dictionary.Add(Ti030p01Constant.DIC_UPD_YMD, "-1");								// 更新日
					ti030f01Form.Dictionary.Add(Ti030p01Constant.DIC_UPD_TM, "-1");									// 更新時間
				}

				#endregion

				#endregion

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
