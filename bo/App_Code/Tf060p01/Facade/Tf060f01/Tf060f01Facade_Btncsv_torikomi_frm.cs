using com.xebio.bo.Tf060p01.Constant;
using com.xebio.bo.Tf060p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01024;
using Common.Standard.Base;
using System.Collections;
using System.Collections.Generic;

namespace com.xebio.bo.Tf060p01.Facade
{
  /// <summary>
  /// Tf060f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tf060f01Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : Btncsv_torikomi)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btncsv_torikomi)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNCSV_TORIKOMI_FRM(IFacadeContext facadeContext)
		{

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNCSV_TORIKOMI_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得する。
				OpenConnection(facadeContext);

				//以下に業務ロジックを記述する。
				// CSV取込にて取り込んだレコードを取得
				IList<Hashtable> csvInfo = (IList<Hashtable>)facadeContext.GetUserObject(Tf060p01Constant.DIC_CSV_IMPORT_RESULT);

				// フォームオブジェクト取得
				Tf060f01Form form = (Tf060f01Form)facadeContext.FormVO;
				IDataList m1List = form.GetList("M1");

				// CSVチェック情報取得
				CsvCheckInfoVO checkInfo = (CsvCheckInfoVO)form.Dictionary[Tf060p01Constant.DIC_CSV_CHECK_INFO];

				int index = 0;

				foreach (Hashtable csvRow in csvInfo)
				{
					Tf060f01M1Form m1Form = (Tf060f01M1Form)m1List[index];

					m1Form.M1bumon1_yosan_kin = csvRow["BUMON1"].ToString();							// Ｍ１部門１予算額
					m1Form.M1bumon2_yosan_kin = csvRow["BUMON2"].ToString();							// Ｍ１部門２予算額
					m1Form.M1bumon3_yosan_kin = csvRow["BUMON3"].ToString();							// Ｍ１部門３予算額
					m1Form.M1bumon4_yosan_kin = csvRow["BUMON4"].ToString();							// Ｍ１部門４予算額
					m1Form.M1bumon5_yosan_kin = csvRow["BUMON5"].ToString();							// Ｍ１部門５予算額

					m1Form.M1bumon1_yosan_kin_hdn = csvRow["BUMON1"].ToString();						// Ｍ１部門１予算額(隠し)
					m1Form.M1bumon2_yosan_kin_hdn = csvRow["BUMON2"].ToString();						// Ｍ１部門２予算額(隠し)
					m1Form.M1bumon3_yosan_kin_hdn = csvRow["BUMON3"].ToString();						// Ｍ１部門３予算額(隠し)
					m1Form.M1bumon4_yosan_kin_hdn = csvRow["BUMON4"].ToString();						// Ｍ１部門４予算額(隠し)
					m1Form.M1bumon5_yosan_kin_hdn = csvRow["BUMON5"].ToString();						// Ｍ１部門５予算額(隠し)

					index++;
				}

				// 合計数計算
				this.setGokei(form ,true);

				//// フォーカス行インデックス
				//facadeContext.SetUserObject(Tf060p01Constant.DIC_FOCUS_INDEX, (index % m1List.DispRow).ToString());

				//トランザクションをコミットする。
				//CommitTransaction(facadeContext);
			}
			catch (System.Exception ex)
			{
				//トランザクションをロールバックする。
				//RollbackTransaction(facadeContext);
				//例外処理を実行する。
				ThrowException(ex, facadeContext);
			}
			finally
			{
				//コネクションを開放する。
				CloseConnection(facadeContext);
			}
			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNCSV_TORIKOMI_FRM");

		}
		#endregion
	}
}
