using com.xebio.bo.Td010p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C99999.Constant;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using System;

namespace com.xebio.bo.Td010p01.Facade
{
  /// <summary>
  /// Td010f01のFacadeクラスです
  /// 画面データのロード業務ロジックを実装します。
  /// </summary>
  public partial class Td010f01Facade : StandardBaseFacade
	{
		#region 定数を設定します
		/// <summary>;
		/// プログラムID。
		/// </summary>
		private const string PGID = "Td010p01";
		/// <summary>
		/// フォームID。
		/// </summary>
		private const string FORMID = "Td010f01";
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Td010f01Facade()
			: base()
		{
		}
		#endregion

		#region Td010f01画面データを作成する。
		/// <summary>
		/// Td010f01画面データを作成する。
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
				Td010f01Form td010f01Form = (Td010f01Form)facadeContext.FormVO;

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				DateTime date = DateTime.Parse(sysDateVO.Sysdate.ToString().Insert(4, "/").Insert(7, "/"));

				//返品確定日From：前月1日
				td010f01Form.Henpin_kakutei_ymd_from = new DateTime(date.Year, date.Month, 1).AddMonths(-1).ToString("yyyyMMdd");
				//返品確定日To：業務日付
				td010f01Form.Henpin_kakutei_ymd_to = sysDateVO.Sysdate.ToString();

				// アルバイトの場合、本部指示を初期設定
				if (LoginInfoUtil.GetLoginInfo().Kengenkbn == BoSystemConstant.TANTO_KENGEN_ARBEIT)
					td010f01Form.Henpin_riyu = ConditionHenpin_riyu_kbn.VALUE_HENPIN_RIYU_KBN1;

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
