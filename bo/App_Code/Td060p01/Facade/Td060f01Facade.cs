using com.xebio.bo.Td060p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Conditions;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Td060p01.Facade
{
  /// <summary>
  /// Td060f01のFacadeクラスです
  /// 画面データのロード業務ロジックを実装します。
  /// </summary>
  public partial class Td060f01Facade : StandardBaseFacade
	{
		#region 定数を設定します
		/// <summary>;
		/// プログラムID。
		/// </summary>
		private const string PGID = "Td060p01";
		/// <summary>
		/// フォームID。
		/// </summary>
		private const string FORMID = "Td060f01";
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Td060f01Facade()
			: base()
		{
		}
		#endregion

		#region Td060f01画面データを作成する。
		/// <summary>
		/// Td060f01画面データを作成する。
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
				Td060f01Form td060f01Form = (Td060f01Form)facadeContext.FormVO;
				
				//モデル層処理ロジックを記述してください。
				//カード部 データを取得(要実装)........

				//業務日付を取得する
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);
				DateTime date = DateTime.Parse(sysDateVO.Sysdate.ToString().Insert(4, "/").Insert(7, "/"));

				//変更日：前日1日
				td060f01Form.Change_ymd_hdn = new DateTime(date.Year, date.Month, date.Day).AddDays(-1).ToString("yyyyMMdd");

				// 出力区分
				td060f01Form.Shuturyoku_kbn = ConditionShuturyoku_joken.VALUE_SHUTURYOKU_JOKEN1;

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
